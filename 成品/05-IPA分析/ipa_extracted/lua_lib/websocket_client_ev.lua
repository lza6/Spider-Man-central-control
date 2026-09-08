
local socket = require'socket'
local tools = require'websocket.tools'
local frame = require'websocket.frame'
local handshake = require'websocket.handshake'
local debug = require'debug'
local tconcat = table.concat
local tinsert = table.insert

local ev = function(ws)
  ws = ws or {}
  local ev = require'ev'
  local sock
  local loop = ws.loop or ev.Loop.default
  local fd
  local connect_io
  local connect_timer
  local handshake_timer
  local message_io
  local handshake_io
  local send_io_stop
  local async_send
  local active_generation
  local active_socket_error
  local connect_generation = 0
  local pending_sends = {}
  local terminal_error = false
  local self = {}
  self.state = 'CLOSED'
  local close_timer
  local user_on_message
  local user_on_close
  local user_on_open
  local user_on_error
  local cleanup = function()
    connect_generation = connect_generation + 1
    if close_timer then
      close_timer:stop(loop)
      close_timer = nil
    end
    if connect_timer then
      connect_timer:stop(loop)
      connect_timer = nil
    end
    if handshake_timer then
      handshake_timer:stop(loop)
      handshake_timer = nil
    end
    if connect_io then
      connect_io:stop(loop)
      connect_io:clear_pending(loop)
      connect_io = nil
    end
    if handshake_io then
      handshake_io:stop(loop)
      handshake_io:clear_pending(loop)
      handshake_io = nil
    end
    if send_io_stop then
      send_io_stop()
      send_io_stop = nil
    end
    if message_io then
      message_io:stop(loop)
      message_io:clear_pending(loop)
      message_io = nil
    end
    if sock then
      pcall(sock.shutdown,sock)
      pcall(sock.close,sock)
      sock = nil
    end
    fd = nil
    async_send = nil
    active_generation = nil
    active_socket_error = nil
    pending_sends = {}
  end

  local on_close = function(was_clean,code,reason)
    cleanup()
    self.state = 'CLOSED'
    if user_on_close then
      user_on_close(self,was_clean,code,reason or '')
    end
  end
  local on_error = function(err,dont_cleanup)
    if not dont_cleanup then
      cleanup()
    end
    if user_on_error then
      user_on_error(self,err)
    else
      print('Error',err)
    end
  end
  local handle_socket_err
  local fail_connection = function(err)
    if terminal_error then
      return
    end
    terminal_error = true
    self.state = 'CLOSED'
    on_error(err)
  end
  local on_open = function()
    if handshake_timer then
      handshake_timer:stop(loop)
      handshake_timer = nil
    end
    self.state = 'OPEN'
    if #pending_sends > 0 then
      local encoded = tconcat(pending_sends)
      pending_sends = {}
      async_send(encoded, nil, active_socket_error)
    end
    if user_on_open then
      user_on_open(self)
    end
  end
  handle_socket_err = function(err,io,sock)
    if self.state == 'OPEN' then
      on_close(false,1006,err)
    elseif self.state ~= 'CLOSED' then
      fail_connection(err)
    end
  end
  local on_message = function(message,opcode)
    if opcode == frame.TEXT or opcode == frame.BINARY then
      if user_on_message then
        user_on_message(self,message,opcode)
      end
    -- XXT added
    elseif opcode == frame.PING then
      if user_on_message then
        user_on_message(self,message,opcode)
      end
      local encoded = frame.encode(message,frame.PONG,true)
      async_send(encoded, nil, active_socket_error)
    ---------------
    elseif opcode == frame.CLOSE then
      if self.state ~= 'CLOSING' then
        self.state = 'CLOSING'
        local generation = active_generation
        local code,reason = frame.decode_close(message)
        local encoded = frame.encode_close(code)
        encoded = frame.encode(encoded,frame.CLOSE,true)
        async_send(encoded,
          function()
            if generation == connect_generation then
              on_close(true,code or 1005,reason)
            end
          end,active_socket_error)
      else
        on_close(true,1005,'')
      end
    end
  end

  self.send = function(_,message,opcode)
    if self.state ~= 'OPEN' and self.state ~= 'CONNECTING' then
      return nil, 'invalid state: ' .. tostring(self.state)
    end
    local encoded = frame.encode(message,opcode or frame.TEXT,true)
    if self.state == 'CONNECTING' then
      pending_sends[#pending_sends + 1] = encoded
      return true
    end
    if not async_send then
      return nil, 'invalid state: ' .. tostring(self.state)
    end
    async_send(encoded, nil, active_socket_error)
    return true
  end

  self.connect = function(_,url,ws_protocol)
    if self.state ~= 'CLOSED' then
      on_error('wrong state',true)
      return
    end
    local protocol,host,port,uri,host_header = tools.parse_url(url)
    if protocol ~= 'ws' then
      on_error('bad protocol')
      return
    end
    local addresses, resolve_err = tools.resolve_tcp_addresses(socket, host)
    if not addresses then
      on_error('resolve failed: ' .. tostring(resolve_err))
      return
    end
    local ws_protocols_tbl = {''}
    if type(ws_protocol) == 'string' then
        ws_protocols_tbl = {ws_protocol}
    elseif type(ws_protocol) == 'table' then
        ws_protocols_tbl = ws_protocol
    end
    self.state = 'CONNECTING'
    terminal_error = false
    pending_sends = {}
    assert(not sock)
    local address_index = 0
    local connect_timeout = tonumber(ws.connect_timeout)
    if not connect_timeout or connect_timeout <= 0 then
      connect_timeout = nil
    end
    local handshake_timeout = tonumber(ws.handshake_timeout)
    if not handshake_timeout or handshake_timeout <= 0 then
      handshake_timeout = nil
    end

    local function stop_connect_wait()
      if connect_timer then
        connect_timer:stop(loop)
        connect_timer = nil
      end
      if connect_io then
        connect_io:stop(loop)
        connect_io:clear_pending(loop)
        connect_io = nil
      end
    end

    local function close_connect_socket()
      stop_connect_wait()
      if handshake_timer then
        handshake_timer:stop(loop)
        handshake_timer = nil
      end
      if handshake_io then
        handshake_io:stop(loop)
        handshake_io:clear_pending(loop)
        handshake_io = nil
      end
      if send_io_stop then
        send_io_stop()
        send_io_stop = nil
      end
      async_send = nil
      active_generation = nil
      active_socket_error = nil
      if sock then
        pcall(sock.shutdown,sock)
        pcall(sock.close,sock)
        sock = nil
      end
      fd = nil
    end

    local start_next_address
    local function start_upgrade(generation)
      if generation ~= connect_generation or self.state ~= 'CONNECTING' then
        return
      end
      stop_connect_wait()
      local guarded_socket_error = function(err,io,current_sock)
        if generation == connect_generation then
          handle_socket_err(err,io,current_sock)
        end
      end
      active_generation = generation
      active_socket_error = guarded_socket_error
      async_send,send_io_stop = require'websocket.ev_common'.async_send(sock,loop)
      if handshake_timeout then
        local timer
        timer = ev.Timer.new(function(loop,current_timer)
          if generation ~= connect_generation or current_timer ~= handshake_timer or self.state ~= 'CONNECTING' then
            return
          end
          start_next_address('handshake timeout')
        end,handshake_timeout)
        handshake_timer = timer
        timer:start(loop)
      end
      local key = tools.generate_key()
      local req = handshake.upgrade_request
      {
        key = key,
        host = host,
        host_header = host_header,
        port = port,
        protocols = ws_protocols_tbl,
        origin = ws.origin,
        uri = uri
      }
      async_send(
        req,
        function()
          if generation ~= connect_generation or self.state ~= 'CONNECTING' then
            return
          end
          local response = ''
          local read_upgrade = function(loop,read_io)
            if generation ~= connect_generation or not sock then
              read_io:stop(loop)
              if handshake_io == read_io then
                handshake_io = nil
              end
              return
            end
            repeat
              local byte,err = sock:receive(1)
              if byte then
                response = response..byte
              elseif err then
                if err == 'timeout' then
                  return
                else
                  read_io:stop(loop)
                  handshake_io = nil
                  fail_connection('accept failed')
                  return
                end
              end
            until response:sub(#response-3) == '\r\n\r\n'
            read_io:stop(loop)
            handshake_io = nil
            local headers = handshake.http_headers(response)
            local expected_accept = handshake.sec_websocket_accept(key)
            if headers['sec-websocket-accept'] ~= expected_accept then
              fail_connection('accept failed')
              return
            end
            message_io = require'websocket.ev_common'.message_io(
              sock,loop,
              function(message,opcode)
                if generation == connect_generation then
                  on_message(message,opcode)
                end
              end,
              guarded_socket_error)
            on_open(self)
          end
          handshake_io = ev.IO.new(read_upgrade,fd,ev.READ)
          handshake_io:start(loop)-- handshake
        end,
        guarded_socket_error)
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
      local timeout_ok, timeout_result, timeout_err = pcall(sock.settimeout,sock,0)
      if not timeout_ok or not timeout_result then
        start_next_address(timeout_ok and timeout_err or timeout_result)
        return
      end
      pcall(sock.setoption,sock,'tcp-nodelay',true)
      local fd_ok, candidate_fd = pcall(sock.getfd,sock)
      if not fd_ok or not candidate_fd or candidate_fd < 0 then
        start_next_address(fd_ok and 'invalid socket fd' or candidate_fd)
        return
      end
      fd = candidate_fd

      local call_ok, connected, err = pcall(sock.connect,sock,address.addr,port)
      if not call_ok then
        start_next_address(connected)
      elseif connected then
        start_upgrade(generation)
      elseif err == 'timeout' or err == 'Operation already in progress' then
        connect_io = ev.IO.new(function(loop,current_io)
          if generation ~= connect_generation or current_io ~= connect_io or self.state ~= 'CONNECTING' then
            return
          end
          stop_connect_wait()
          local option_ok, connect_err, option_err = pcall(sock.getoption,sock,'error')
          if not option_ok then
            start_next_address(connect_err)
          elseif connect_err or option_err then
            start_next_address(connect_err or option_err)
          else
            start_upgrade(generation)
          end
        end,fd,ev.WRITE)
        connect_io:start(loop)
        if connect_timeout then
          connect_timer = ev.Timer.new(function(loop,current_timer)
            if generation ~= connect_generation or current_timer ~= connect_timer or self.state ~= 'CONNECTING' then
              return
            end
            stop_connect_wait()
            start_next_address('connect timeout')
          end,connect_timeout)
          connect_timer:start(loop)
        end
      else
        start_next_address(err)
      end
    end

    start_next_address()
  end

  self.on_close = function(_,on_close_arg)
    user_on_close = on_close_arg
  end

  self.on_error = function(_,on_error_arg)
    user_on_error = on_error_arg
  end

  self.on_open = function(_,on_open_arg)
    user_on_open = on_open_arg
  end

  self.on_message = function(_,on_message_arg)
    user_on_message = on_message_arg
  end

  self.close = function(_,code,reason,timeout)
    if handshake_io then
      handshake_io:stop(loop)
      handshake_io:clear_pending(loop)
    end
    if self.state == 'CONNECTING' then
      self.state = 'CLOSING'
      on_close(false,1006,'')
      return
    elseif self.state == 'OPEN' then
      self.state = 'CLOSING'
      local generation = connect_generation
      timeout = timeout or 3
      local encoded = frame.encode_close(code or 1000,reason)
      encoded = frame.encode(encoded,frame.CLOSE,true)
      -- this should let the other peer confirm the CLOSE message
      -- by 'echoing' the message.
      async_send(encoded)
      close_timer = ev.Timer.new(function()
          if generation ~= connect_generation then
            return
          end
          close_timer = nil
          on_close(false,1006,'timeout')
        end,timeout)
      close_timer:start(loop)
    end
  end

  return self
end

return ev
