-- GCD-based WebSocket server backend (non-blocking)
-- Depends on: LuaSocket, lobjcextras (dispatch_source_register_callback),
-- websocket.frame, websocket.handshake, websocket.tools

local socket = require 'socket'
local frame = require 'websocket.frame'
local handshake = require 'websocket.handshake'
local ssl = require 'ssl'

local tinsert = table.insert
local tconcat = table.concat

-- helper: nonblocking send with correct index advancement semantics
local function nb_send(sock, buffer, index)
  local start = index or 1
  local sent, err, last = sock:send(buffer, start)
  if sent then
    local next_index = start + sent
    if next_index > #buffer then
      return nil, nil, nil
    else
      return next_index, 'again', nil
    end
  else
    if err == 'timeout' or err == 'wantwrite' or err == 'wantread' then
      local next_index = start
      if type(last) == 'number' and last >= start then next_index = last + 1 end
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

-- Map of protocol -> set of clients
local clients_by_protocol = {}
clients_by_protocol[true] = {}

local function client_new(sock, fd, protocol, queue)
  assert(sock)
  pcall(function() sock:setoption('tcp-nodelay', true) end)

  local self = {}
  self.state = 'OPEN'
  self.sock = sock

  local read_source
  local write_source
  local close_timer
  local cleaning = false

  local sendq = {}
  local sendq_i = 1
  local sendq_off = 1

  local user_on_message
  local user_on_close
  local user_on_error

  local function stop_source(source)
    if source then pcall(function() source:release() end) end
  end

  local function cleanup()
    if cleaning then return end
    cleaning = true
    if close_timer then
      pcall(function() close_timer:release() end)
      close_timer = nil
    end
    if read_source then stop_source(read_source); read_source = nil end
    if write_source then stop_source(write_source); write_source = nil end
    if sock then
      pcall(function() sock:shutdown() end)
      pcall(function() sock:close() end)
      sock = nil
    end
  end

  local function on_close(was_clean, code, reason)
    -- remove from registry
    if clients_by_protocol[protocol] and clients_by_protocol[protocol][self] then
      clients_by_protocol[protocol][self] = nil
    end
    local cb = user_on_close
    dispatch_async(queue, function()
      cleanup()
      self.state = 'CLOSED'
      if cb then pcall(cb, self, was_clean, code, reason or '') end
    end)
  end

  local function on_error(err)
    if clients_by_protocol[protocol] and clients_by_protocol[protocol][self] then
      clients_by_protocol[protocol][self] = nil
    end
    local cb = user_on_error
    dispatch_async(queue, function()
      if cb then
        pcall(cb, self, err)
      else
        print('WebSocket server error', err)
      end
    end)
  end

  local function handle_socket_error(err, context)
    local reason = tostring(err or '')
    if reason == 'closed' then
      if self.state ~= 'CLOSED' then
        on_close(false, 1006, '')
      end
      return
    end
    local message = context and (context .. ': ' .. reason) or reason
    on_error(message)
  end

  local function ensure_write_source()
    if write_source then return end
    write_source = dispatch_source_register_callback('write', fd, 0, function()
      while true do
        local chunk = sendq[sendq_i]
        if not chunk then break end
        local next_index, st, ferr = nb_send(sock, chunk, sendq_off)
        if st == 'fatal' then
          handle_socket_error(ferr, 'send failed')
          return
        end
        if not next_index then
          sendq[sendq_i] = nil
          sendq_i = sendq_i + 1
          sendq_off = 1
        else
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
      -- idle: finalize delayed close or stop write source to avoid busy loop
      if not sendq[sendq_i] then
        if pending_close_wait_send and self.state == 'CLOSING' then
          local code = pending_close_code or 1006
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
  end

  local last
  local frames = {}
  local first_opcode
  local pending_close_wait_send = false
  local pending_close_code
  local pending_close_reason

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
        if not first_opcode then first_opcode = opcode end
        tinsert(frames, decoded)
        encoded = rest
        if fin == true then
          local payload = tconcat(frames)
          local op = first_opcode
          frames = {}
          first_opcode = nil
          if op == frame.TEXT or op == frame.BINARY then
            if user_on_message then pcall(user_on_message, self, payload, op) end
          elseif op == frame.PING then
            -- echo ping to user and auto-reply pong
            if user_on_message then pcall(user_on_message, self, payload, op) end
            local pong = frame.encode(payload, frame.PONG)
            sendq[#sendq + 1] = pong
            ensure_write_source()
          elseif op == frame.CLOSE then
            if self.state ~= 'CLOSING' then
              self.state = 'CLOSING'
              local code, reason = frame.decode_close(payload)
              local encoded_close = frame.encode_close(code)
              encoded_close = frame.encode(encoded_close, frame.CLOSE)
              sendq[#sendq + 1] = encoded_close
              ensure_write_source()
              -- delay close until CLOSE reply is flushed
              pending_close_wait_send = true
              pending_close_code = code or 1006
              pending_close_reason = reason
            else
              on_close(true, 1006, '')
            end
          end
        end
      end
    until not decoded
    if #encoded > 0 then last = encoded end
  end

  local function ensure_read_source()
    if read_source then return end
    read_source = dispatch_source_register_callback('read', fd, 0, function()
      if self.state ~= 'OPEN' then return end
      local encoded, err, part = sock:receive(100000)
      if err then
        if (err == 'timeout' or err == 'wantread') and #(part or '') == 0 then return end
        if err == 'wantwrite' then ensure_write_source(); return end
        if #(part or '') == 0 then
          on_close(false, 1006, '')
          return
        end
      end
      handle_message_bytes(encoded or part)
    end, queue)
  end

  function self:start()
    ensure_read_source()
  end

  function self:send(message, opcode)
    if self.state ~= 'OPEN' then
      return nil, 'invalid state: ' .. tostring(self.state)
    end
    local encoded = frame.encode(message, opcode or frame.TEXT)
    sendq[#sendq + 1] = encoded
    ensure_write_source()
    return true
  end

  function self:on_close(cb)
    user_on_close = cb
  end

  function self:on_error(cb)
    user_on_error = cb
  end

  function self:on_message(cb)
    user_on_message = cb
  end

  function self:broadcast(...)
    for c in pairs(clients_by_protocol[protocol] or {}) do
      if c.state == 'OPEN' then c:send(...) end
    end
  end

  function self:close(code, reason, timeout_ms)
    if clients_by_protocol[protocol] and clients_by_protocol[protocol][self] then
      clients_by_protocol[protocol][self] = nil
    end
    if self.state == 'CLOSING' then
      return nil, 'already closing'
    elseif self.state == 'OPEN' then
      self.state = 'CLOSING'
      local encoded = frame.encode_close(code or 1000, reason or '')
      encoded = frame.encode(encoded, frame.CLOSE)
      sendq[#sendq + 1] = encoded
      ensure_write_source()
      timeout_ms = tonumber(timeout_ms) or 3000
      close_timer = dispatch_source_register_callback('timer', timeout_ms, timeout_ms, function()
        close_timer:release(); close_timer = nil
        on_close(false, 1006, 'timeout')
      end, queue)
    else
      on_close(false, 1006, '')
    end
  end

  return self
end

local function listen(opts)
  assert(opts and (opts.protocols or opts.default))

  -- Resolve target dispatch queue
  local queue = opts.queue
  if not queue then
    if type(dispatch_get_current_queue) == 'function' then
      local ok, q = pcall(dispatch_get_current_queue)
      if ok and q then queue = q end
    end
    queue = queue or 'main'
  end

  local user_on_error
  local function on_error(s, err)
    if user_on_error then
      user_on_error(s, err)
    else
      print(err)
    end
  end

  local protocols = {}
  if opts.protocols then
    for protocol in pairs(opts.protocols) do
      clients_by_protocol[protocol] = clients_by_protocol[protocol] or {}
      tinsert(protocols, protocol)
    end
  end

  local self = {}
  function self.on_error(_, cb)
    user_on_error = cb
  end

  local listener, err = socket.bind(opts.interface or '*', opts.port or 80)
  if not listener then error(err) end
  listener:settimeout(0)

  function self.sock()
    return listener
  end

  local listen_fd = listener:getfd()
  local listen_source

  local function stop_listen()
    if listen_source then pcall(function() listen_source:release() end); listen_source = nil end
    if listener then pcall(function() listener:close() end); listener = nil end
  end

  local ssl_params = opts.ssl_params -- optional; when present, serve wss on this port

  listen_source = dispatch_source_register_callback('read', listen_fd, 0, function()
    local client_sock = listener:accept()
    if not client_sock then return end
    client_sock:settimeout(0)
    local request_lines = {}
    local last
    local cfd = client_sock:getfd()
    local read_src
    local write_src
    local use_tls = (ssl_params ~= nil)
    local tls_wrapped = false
    local tls_done = false
    local csock = client_sock
    local protocol
    local handshake_response
    local handshake_index

    local function progress_tls()
      if not use_tls or tls_done then return true end
      if not tls_wrapped then
        local wrapped, werr = ssl.wrap(csock, ssl_params)
        if not wrapped then
          print('TLS wrap failed:', tostring(werr))
          pcall(function() csock:close() end)
          if read_src then read_src:release() end
          if write_src then write_src:release() end
          return false
        end
        csock = wrapped
        pcall(function() csock:settimeout(0) end)
        tls_wrapped = true
      end
      local ok, herr = csock:dohandshake()
      if ok then
        tls_done = true
        return true
      else
        if herr == 'wantread' or herr == 'wantwrite' or herr == 'timeout' then
          return false
        else
          print('TLS handshake failed:', tostring(herr))
          pcall(function() csock:close() end)
          if read_src then read_src:release() end
          if write_src then write_src:release() end
          return false
        end
      end
    end

    local function resolve_handler()
      if protocol and opts.protocols and opts.protocols[protocol] then
        return protocol, opts.protocols[protocol]
      elseif opts.default then
        return true, opts.default
      end
    end

    local function attach_client()
      local reg_index, handler = resolve_handler()
      if not handler then
        return nil, 'bad_protocol'
      end
      local c = client_new(csock, cfd, reg_index, queue)
      clients_by_protocol[reg_index][c] = true
      handler(c)
      c:start()
      return true
    end

    local function flush_handshake_response()
      if not handshake_response then
        return 'idle'
      end
      local next_index, st, ferr = nb_send(csock, handshake_response, handshake_index)
      if st == 'fatal' then
        print('WebSocket client closed while handshake', ferr)
        return 'fatal', ferr
      end
      handshake_index = next_index
      if not next_index then
        handshake_response = nil
        handshake_index = nil
        local ok, err = attach_client()
        if not ok then
          if err == 'bad_protocol' and on_error then on_error('bad protocol') end
          return 'fatal', err
        end
        return 'done'
      else
        if st == 'again' and ferr == 'wantread' then
          if not read_src then
            read_src = dispatch_source_register_callback('read', cfd, 0, function() end, queue)
          end
        end
        return 'pending'
      end
    end

    local function handle_handshake_write()
      if use_tls and not tls_done then
        if progress_tls() ~= true then
          return
        end
      end
      local status = flush_handshake_response()
      if status == 'fatal' then
        if write_src then write_src:release(); write_src = nil end
        if read_src then read_src:release(); read_src = nil end
        pcall(function() csock:close() end)
        return
      end
      if status == 'done' or status == 'idle' then
        if write_src then write_src:release(); write_src = nil end
      end
    end

    local function ensure_handshake_write_source()
      if write_src then return end
      write_src = dispatch_source_register_callback('write', cfd, 0, handle_handshake_write, queue)
    end

    -- Ensure a write source early to drive TLS handshake when wantwrite
    ensure_handshake_write_source()

    read_src = dispatch_source_register_callback('read', cfd, 0, function()
      if use_tls and not tls_done then
        if progress_tls() ~= true then return end
      end
      repeat
        local line, err, part = csock:receive('*l')
        if line then
          if last then line = last .. line; last = nil end
          request_lines[#request_lines + 1] = line
        elseif err then
          if err == 'timeout' or err == 'wantread' then
            last = part; return
          elseif err == 'wantwrite' then
            -- need write readiness to progress TLS
            return
          else
            on_error(self, 'WebSocket handshake failed: ' .. tostring(err))
            read_src:release(); if write_src then write_src:release() end; pcall(function() csock:close() end)
            return
          end
        end
      until line == ''
      read_src:release()
      local upgrade_request = tconcat(request_lines, '\r\n')
      local response
      response, protocol = handshake.accept_upgrade(upgrade_request, protocols)
      if not response then
        print('Handshake failed, Request:'); print(upgrade_request)
        pcall(function() csock:close() end)
        return
      end
      handshake_response = response
      handshake_index = nil
      -- ensure we have a write source to flush handshake response
      ensure_handshake_write_source()
    end, queue)
  end, queue)

  function self.close(keep_clients)
    stop_listen()
    if not keep_clients then
      for prot, set in pairs(clients_by_protocol) do
        for c in pairs(set) do
          c:close()
        end
      end
    end
  end

  return self
end

return {
  listen = listen
}
