-- GCD-based websocket client backend (non-blocking)
-- Depends on: LuaSocket, lobjcextras (dispatch_source_register_callback),
-- websocket.frame, websocket.handshake, websocket.tools

local socket = require 'socket'
local frame = require 'websocket.frame'
local handshake = require 'websocket.handshake'
local tools = require 'websocket.tools'
local ssl = require 'ssl'

local tinsert = table.insert
local tconcat = table.concat

local gcd = function(ws)
  ws = ws or {}

  local self = {}

  -- Resolve target dispatch queue
  local queue = ws.queue
  if not queue then
    if type(dispatch_get_current_queue) == 'function' then
      local ok, q = pcall(dispatch_get_current_queue)
      if ok and q then
        queue = q
      end
    end
    queue = queue or 'main'
  end

  local sock
  local fd

  self.state = 'CLOSED'

  local read_source
  local write_source
  local connect_source
  local connect_timer
  local handshake_timer
  local close_timer
  local connect_generation = 0
  local transport_generation = 0
  local tcp_connected = false
  local terminal_error = false
  local cleanup_pending = false

  -- queued send buffer: list of chunks and cursor
  local sendq = {}
  local sendq_i = 1
  local sendq_off = 1

  local user_on_message
  local user_on_close
  local user_on_open
  local user_on_error

  -- Handshake state
  local upgrading = false
  local upgrade_req
  local upgrade_index
  local upgrade_resp_chunks = {}
  local upgrade_resp_tail = ''
  local expected_accept
  local use_tls = false
  local tls_wrapped = false
  local tls_done = false
  local ssl_params
  local connect_host

  -- Message parser state
  local last
  local frames = {}
  local first_opcode
  local pending_close_wait_send = false
  local pending_close_code
  local pending_close_reason

  -- helper: nonblocking send with correct index advancement semantics
  local function nb_send(sockobj, buffer, index)
    local start = index or 1
    local sent, err, last = sockobj:send(buffer, start)
    if sent then
      local next_index = start + sent
      if next_index > #buffer then
        return nil, nil, nil -- done
      else
        return next_index, 'again', nil
      end
    else
      if err == 'timeout' or err == 'wantwrite' or err == 'wantread' then
        local next_index = start
        if type(last) == 'number' and last >= start then
          next_index = last + 1
        end
        if next_index > #buffer then
          return nil, nil, nil
        else
          return next_index, 'again', err
        end
      else
        return index, 'fatal', err
      end
    end
  end

  local ensure_read_source
  local ensure_write_source

  local function stop_source(source)
    if source then
      pcall(function() source:release() end)
    end
  end

  local function cleanup()
    connect_generation = connect_generation + 1
    if close_timer then
      pcall(function() close_timer:release() end)
      close_timer = nil
    end
    if connect_timer then
      stop_source(connect_timer)
      connect_timer = nil
    end
    if handshake_timer then
      stop_source(handshake_timer)
      handshake_timer = nil
    end
    if connect_source then
      stop_source(connect_source)
      connect_source = nil
    end
    if read_source then
      stop_source(read_source)
      read_source = nil
    end
    if write_source then
      stop_source(write_source)
      write_source = nil
    end
    if sock then
      pcall(function() sock:shutdown() end)
      pcall(function() sock:close() end)
      sock = nil
    end
    fd = nil
    tcp_connected = false
    transport_generation = 0
    sendq = {}
    sendq_i = 1
    sendq_off = 1
    cleanup_pending = false
  end

  local function on_close(was_clean, code, reason)
    -- Detach cleanup and callback to avoid releasing sources inside their own handler
    local cb = user_on_close
    dispatch_async(queue, function()
      cleanup()
      self.state = 'CLOSED'
      if cb then pcall(cb, self, was_clean, code, reason or '') end
    end)
  end

  local function on_error(err, dont_cleanup)
    local cb = user_on_error
    if not dont_cleanup then
      cleanup_pending = true
    end
    dispatch_async(queue, function()
      if not dont_cleanup then cleanup() end
      if cb then
        pcall(cb, self, err)
      else
        print('Error', err)
      end
    end)
  end

  local function fail_connection(err)
    if terminal_error then
      return
    end
    terminal_error = true
    self.state = 'CLOSED'
    on_error(err)
  end

  local function on_open()
    if handshake_timer then
      stop_source(handshake_timer)
      handshake_timer = nil
    end
    self.state = 'OPEN'
    if sendq[sendq_i] then
      ensure_write_source()
    end
    if user_on_open then
      pcall(user_on_open, self)
    end
  end

  local function handle_socket_error(err)
    local reason = tostring(err)
    if self.state == 'OPEN' then
      on_close(false, 1006, reason)
    elseif self.state ~= 'CLOSED' then
      fail_connection(reason)
    end
  end

  local function progress_tls_handshake()
    if self.state ~= 'CONNECTING' or not use_tls or tls_done then
      return true
    end
    if not tls_wrapped then
      local wrapped, werr = ssl.wrap(sock, ssl_params)
      if not wrapped then
        fail_connection('tls wrap failed: ' .. tostring(werr))
        return nil, 'fatal'
      end
      sock = wrapped
      pcall(function() sock:settimeout(0) end)
      local sni_ok, sni_err = pcall(sock.sni, sock, ssl_params.server_name or connect_host)
      if not sni_ok then
        fail_connection('tls sni failed: ' .. tostring(sni_err))
        return nil, 'fatal'
      end
      tls_wrapped = true
    end
    local ok, herr = sock:dohandshake()
    if ok then
      tls_done = true
      return true
    end
    if herr == 'wantread' or herr == 'wantwrite' or herr == 'timeout' then
      return false, herr
    end
    fail_connection('tls handshake failed: ' .. tostring(herr))
    return nil, 'fatal'
  end

  function ensure_write_source()
    if write_source or not tcp_connected or not sock or not fd then return end
    local generation = transport_generation
    local source
    source = dispatch_source_register_callback('write', fd, 0, function()
      if generation ~= connect_generation or source ~= write_source or not tcp_connected then
        return
      end
      if self.state == 'CLOSED' then
        return
      end
      -- Progress TLS handshake if needed
      local handshake_ok, handshake_err = progress_tls_handshake()
      if handshake_ok == nil then
        return
      elseif not handshake_ok then
        if handshake_err == 'wantread' then ensure_read_source() end
        return
      end
      -- During CONNECTING, first write sends the HTTP Upgrade request
      if self.state == 'CONNECTING' and upgrading and upgrade_req then
        local next_index, st, ferr = nb_send(sock, upgrade_req, upgrade_index)
        if st == 'fatal' then
          fail_connection('upgrade write failed: ' .. tostring(ferr))
          return
        end
        upgrade_index = next_index
        if not next_index then
          -- upgrade request fully sent, start reading response
          upgrade_req = nil
          upgrade_index = nil
          ensure_read_source()
        end
      end

      if self.state == 'CONNECTING' then
        if upgrading and not upgrade_req and (not use_tls or tls_done) then
          local s = write_source
          write_source = nil
          pcall(function() s:release() end)
        end
        return
      end

      -- flush queued chunks
      while true do
        local chunk = sendq[sendq_i]
        if not chunk then break end
        local next_index, st, ferr = nb_send(sock, chunk, sendq_off)
        if st == 'fatal' then
          handle_socket_error('send failed: ' .. tostring(ferr))
          return
        end
        if not next_index then
          -- finished this chunk
          sendq[sendq_i] = nil
          sendq_i = sendq_i + 1
          sendq_off = 1
        else
          -- pending
          sendq_off = next_index
          if st == 'again' and ferr == 'wantread' then ensure_read_source() end
          return
        end
      end

      if sendq_i > 1 and sendq[sendq_i] == nil then
        sendq = {}
        sendq_i = 1
        sendq_off = 1
      end

      -- If nothing left to write and no pending handshake write work
      if (sendq[sendq_i] == nil) and (not upgrading) and (not use_tls or tls_done) then
        -- If we're waiting to finish sending CLOSE before closing, align with client_ev semantics
        if pending_close_wait_send and self.state == 'CLOSING' then
          local code = pending_close_code or 1005
          local reason = pending_close_reason
          pending_close_wait_send = false
          pending_close_code = nil
          pending_close_reason = nil
          on_close(true, code, reason)
          return
        end
        local s = write_source
        write_source = nil
        pcall(function() s:release() end)
      end
    end, queue)
    write_source = source
  end

  local function handle_message_bytes(encoded)
    if last then
      encoded = last .. (encoded or '')
      last = nil
    else
      encoded = encoded or ''
    end
    repeat
      local decoded, fin, opcode, rest = frame.decode(encoded)
      if decoded then
        if not first_opcode then
          first_opcode = opcode
        end
        tinsert(frames, decoded)
        encoded = rest
        if fin == true then
          local payload = tconcat(frames)
          local op = first_opcode
          frames = {}
          first_opcode = nil
          -- TEXT/BINARY/PING/CLOSE
          if op == frame.TEXT or op == frame.BINARY then
            if user_on_message then
              pcall(user_on_message, self, payload, op)
            end
          elseif op == frame.PING then
            if user_on_message then
              pcall(user_on_message, self, payload, op)
            end
            -- auto reply PONG
            local encoded_pong = frame.encode(payload, frame.PONG, true)
            sendq[#sendq+1] = encoded_pong
            ensure_write_source()
          elseif op == frame.CLOSE then
            local code, reason = frame.decode_close(payload)
            if self.state ~= 'CLOSING' then
              self.state = 'CLOSING'
              local encoded_close = frame.encode_close(code)
              encoded_close = frame.encode(encoded_close, frame.CLOSE, true)
              sendq[#sendq+1] = encoded_close
              ensure_write_source()
              -- Delay on_close until CLOSE frame is actually sent, align with client_ev
              pending_close_wait_send = true
              pending_close_code = code or 1005
              pending_close_reason = reason
            else
              -- We initiated close earlier; peer echoed CLOSE
              on_close(true, 1005, '')
            end
          end
        end
      end
    until not decoded
    if #encoded > 0 then
      last = encoded
    end
  end

  function ensure_read_source()
    if read_source or not tcp_connected or not sock or not fd then return end
    local generation = transport_generation
    local source
    source = dispatch_source_register_callback('read', fd, 0, function()
      if generation ~= connect_generation or source ~= read_source or not tcp_connected then
        return
      end
      -- Progress TLS handshake if needed
      local handshake_ok, handshake_err = progress_tls_handshake()
      if handshake_ok == nil then
        return
      elseif not handshake_ok then
        if handshake_err == 'wantwrite' then ensure_write_source() end
        return
      end
      if self.state == 'CONNECTING' and upgrading then
        -- Read HTTP Upgrade response until CRLFCRLF
        local chunk, err, part = sock:receive(1024)
        local data = chunk or part or ''
        local combined_tail
        if #data > 0 then
          tinsert(upgrade_resp_chunks, data)
          combined_tail = upgrade_resp_tail .. data
        else
          combined_tail = upgrade_resp_tail
        end
        if err and (err ~= 'timeout' and err ~= 'wantread' and err ~= 'wantwrite') then
          fail_connection('upgrade read failed: ' .. tostring(err))
          return
        end
        if err == 'wantwrite' then ensure_write_source(); return end
        if combined_tail and combined_tail:find('\r\n\r\n', 1, true) then
          -- parse headers
          local full_resp = table.concat(upgrade_resp_chunks)
          local headers = handshake.http_headers(full_resp)
          if headers['sec-websocket-accept'] ~= expected_accept then
            fail_connection('accept failed')
            return
          end
          upgrading = false
          upgrade_resp_chunks = {}
          upgrade_resp_tail = ''
          on_open()
        else
          if combined_tail then
            if #combined_tail >= 3 then
              upgrade_resp_tail = combined_tail:sub(-3)
            else
              upgrade_resp_tail = combined_tail
            end
          end
        end
        return
      end

      if self.state == 'OPEN' then
        local encoded, err, part = sock:receive(100000)
        if err then
          if (err == 'timeout' or err == 'wantread') and #(part or '') == 0 then
            return
          elseif err == 'wantwrite' then
            ensure_write_source(); return
          elseif #(part or '') == 0 then
            -- peer closed or fatal
            handle_socket_error(err)
            return
          end
        end
        handle_message_bytes(encoded or part)
      end
    end, queue)
    read_source = source
  end

  self.send = function(_, message, opcode)
    if self.state ~= 'OPEN' and self.state ~= 'CONNECTING' then
      return nil, 'invalid state: ' .. tostring(self.state)
    end
    local encoded = frame.encode(message, opcode or frame.TEXT, true)
    sendq[#sendq+1] = encoded
    ensure_write_source()
    return true
  end

  self.connect = function(_, url, ws_protocol)
    if self.state ~= 'CLOSED' or cleanup_pending then
      on_error('wrong state', true)
      return
    end
    local protocol, host, port, uri, host_header = tools.parse_url(url)
    use_tls = (protocol == 'wss')
    if protocol ~= 'ws' and protocol ~= 'wss' then
      on_error('bad protocol', true)
      return
    end
    local addresses, resolve_err = tools.resolve_tcp_addresses(socket, host)
    if not addresses then
      on_error('resolve failed: ' .. tostring(resolve_err), true)
      return
    end
    connect_host = host
    self.state = 'CONNECTING'
    terminal_error = false
    tcp_connected = false
    tls_wrapped = false
    tls_done = false
    if use_tls then
      ssl_params = ws.ssl_params or {
        mode = 'client',
        protocol = 'tlsv1_2',
        verify = 'none',
      }
      if type(ssl_params) ~= 'table' then ssl_params = {} end
      ssl_params.mode = ssl_params.mode or 'client'
      ssl_params.protocol = ssl_params.protocol or 'tlsv1_2'
      ssl_params.verify = ssl_params.verify or 'none'
      ssl_params.server = ssl_params.server or connect_host
      ssl_params.server_name = ssl_params.server_name or connect_host -- SNI
    end

    local ws_protocols_tbl = { '' }
    if type(ws_protocol) == 'string' then
      ws_protocols_tbl = { ws_protocol }
    elseif type(ws_protocol) == 'table' then
      ws_protocols_tbl = ws_protocol
    end
    local function prepare_handshake()
      local key = tools.generate_key()
      expected_accept = handshake.sec_websocket_accept(key)
      upgrade_req = handshake.upgrade_request {
        key = key,
        host = host,
        host_header = host_header,
        port = port,
        protocols = ws_protocols_tbl,
        origin = ws.origin,
        uri = uri,
      }
      upgrading = true
      upgrade_index = nil
      upgrade_resp_chunks = {}
      upgrade_resp_tail = ''
      tls_wrapped = false
      tls_done = false
    end

    local address_index = 0
    local connect_timeout = tonumber(ws.connect_timeout)
    local connect_timeout_ms
    if connect_timeout and connect_timeout > 0 then
      connect_timeout_ms = math.max(1, math.floor(connect_timeout * 1000))
    end
    local handshake_timeout = tonumber(ws.handshake_timeout)
    local handshake_timeout_ms
    if handshake_timeout and handshake_timeout > 0 then
      handshake_timeout_ms = math.max(1, math.floor(handshake_timeout * 1000))
    end

    local function stop_connect_wait()
      if connect_timer then
        stop_source(connect_timer)
        connect_timer = nil
      end
      if connect_source then
        stop_source(connect_source)
        connect_source = nil
      end
    end

    local function close_connect_socket()
      stop_connect_wait()
      if handshake_timer then
        stop_source(handshake_timer)
        handshake_timer = nil
      end
      if read_source then
        stop_source(read_source)
        read_source = nil
      end
      if write_source then
        stop_source(write_source)
        write_source = nil
      end
      if sock then
        pcall(function() sock:shutdown() end)
        pcall(function() sock:close() end)
        sock = nil
      end
      fd = nil
      tcp_connected = false
      transport_generation = 0
      upgrading = false
      upgrade_req = nil
      upgrade_index = nil
      upgrade_resp_chunks = {}
      upgrade_resp_tail = ''
      tls_wrapped = false
      tls_done = false
    end

    local start_next_address
    local function start_transport(generation)
      if generation ~= connect_generation or self.state ~= 'CONNECTING' then
        return
      end
      stop_connect_wait()
      local setup_ok, setup_err = pcall(prepare_handshake)
      if not setup_ok then
        fail_connection('handshake setup failed: ' .. tostring(setup_err))
        return
      end
      transport_generation = generation
      tcp_connected = true
      if handshake_timeout_ms then
        local timer
        timer = dispatch_source_register_callback('timer', handshake_timeout_ms, 0, function()
          if generation ~= connect_generation or timer ~= handshake_timer or self.state ~= 'CONNECTING' then
            return
          end
          start_next_address('handshake timeout')
        end, queue)
        handshake_timer = timer
      end
      ensure_read_source()
      ensure_write_source()
    end

    start_next_address = function(last_err)
      close_connect_socket()
      if self.state ~= 'CONNECTING' then
        return
      end
      address_index = address_index + 1
      local address = addresses[address_index]
      if not address then
        fail_connection('connect failed: ' .. tostring(last_err or 'no address'))
        return
      end

      connect_generation = connect_generation + 1
      local generation = connect_generation
      local create_ok, candidate_sock, sock_err = pcall(tools.create_tcp_for_family, socket, address.family)
      if create_ok then
        sock = candidate_sock
      else
        sock_err = candidate_sock
        sock = nil
      end
      if not sock then
        start_next_address(sock_err)
        return
      end
      local timeout_ok, timeout_result, timeout_err = pcall(sock.settimeout, sock, 0)
      if not timeout_ok or not timeout_result then
        start_next_address(timeout_ok and timeout_err or timeout_result)
        return
      end
      pcall(sock.setoption, sock, 'tcp-nodelay', true)
      local fd_ok, candidate_fd = pcall(sock.getfd, sock)
      if not fd_ok or not candidate_fd or candidate_fd < 0 then
        start_next_address(fd_ok and 'invalid socket fd' or candidate_fd)
        return
      end
      fd = candidate_fd

      local call_ok, connected, err = pcall(sock.connect, sock, address.addr, port)
      if not call_ok then
        start_next_address(connected)
      elseif connected then
        start_transport(generation)
      elseif err == 'timeout' or err == 'Operation already in progress' then
        local source
        source = dispatch_source_register_callback('write', fd, 0, function()
          if generation ~= connect_generation or source ~= connect_source or self.state ~= 'CONNECTING' then
            return
          end
          stop_connect_wait()
          local option_ok, connect_err, option_err = pcall(sock.getoption, sock, 'error')
          if not option_ok then
            start_next_address(connect_err)
          elseif connect_err or option_err then
            start_next_address(connect_err or option_err)
          else
            start_transport(generation)
          end
        end, queue)
        connect_source = source
        if connect_timeout_ms then
          local timer
          timer = dispatch_source_register_callback(
            'timer', connect_timeout_ms, 0, function()
              if generation ~= connect_generation or timer ~= connect_timer or self.state ~= 'CONNECTING' then
                return
              end
              stop_connect_wait()
              start_next_address('connect timeout')
            end, queue)
          connect_timer = timer
        end
      else
        start_next_address(err)
      end
    end

    start_next_address()
  end

  self.on_close = function(_, on_close_arg)
    user_on_close = on_close_arg
  end

  self.on_error = function(_, on_error_arg)
    user_on_error = on_error_arg
  end

  self.on_open = function(_, on_open_arg)
    user_on_open = on_open_arg
  end

  self.on_message = function(_, on_message_arg)
    user_on_message = on_message_arg
  end

  self.close = function(_, code, reason, timeout_ms)
    if self.state == 'CONNECTING' then
      self.state = 'CLOSING'
      on_close(false, 1006, '')
      return
    elseif self.state == 'OPEN' then
      self.state = 'CLOSING'
      local encoded = frame.encode_close(code or 1000, reason)
      encoded = frame.encode(encoded, frame.CLOSE, true)
      sendq[#sendq+1] = encoded
      ensure_write_source()
      timeout_ms = tonumber(timeout_ms) or 3000
      local generation = connect_generation
      local timer
      timer = dispatch_source_register_callback('timer', timeout_ms, timeout_ms, function()
        if generation ~= connect_generation or timer ~= close_timer then
          return
        end
        timer:release()
        close_timer = nil
        on_close(false, 1006, 'timeout')
      end, queue)
      close_timer = timer
    end
  end

  return self
end

return gcd
