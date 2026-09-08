ocal CC = {}

do

	local _err_msg = {

		timeout = [[ 
★款薕ö

1.鱪¤-эc8蠰

2.-э2k饰鱪輘í

3.鱪菥  -э巳 蹙 T*@逹]],

		server_bug = [[
★ú° ï ÷ 绽å VPN   HTTP ã 緉 ]],

		submit_ip = [[肖葎
¡hIP
cn]],

		not_find = [[*~0-Ь 

1.-э2k饰鱪輘í

2.÷1-э XXTStudio/¨

3.鱪菥  -э巳 蹙 T*@逹]],

		not_init = [[* Ë -§!W

÷羋( 'CC.connect()' 跮 Ë 蚛]]

	}

	local _server = {ip = '', port = '', field = {}}

	local post = function(_mode, mode, data)

		if _server.ip == '' then error(_err_msg.not_init, 3) end

		while true do

			local code, header, body = http.post(

					string.format(

						'http://%s:%s/%s/%s',

						_server.ip, _server.port, _mode, mode

					), 30, {}, ((type(data) == 'table' and json.encode(data)) or data)

				)

			if code == 200 then

				return json.decode(body) or body

			elseif code ~= -1 then

				sys.toast(_err_msg.server_bug .. body)

			else

				sys.toast(_err_msg.timeout)

			end

		end

	end

	local encodeURI = function(s)

		return string.gsub(string.gsub(s, '([^%w%.%- ])', function(c) return string.format('%%%02X', string.byte(c)) end), ' ', '+')

	end

	local send_cc = function(db,m,t)

		local r = post('db', m, json.encode({db=db, data=t}))

		if r.state == 0 then return r.data;else sys.alert(r.message,5);return r.data;end

	end

	CC.connect = function(ip, port)

		if ip and port then

			return CC.set_server_ip(ip, port)

		else

			local args = proc_take('spawn_args')

			if args == '' then

				args = proc_take('CC_args')

			end

			proc_put('spawn_args', args)

			proc_put('CC_args', args)

			local _, args_json = pcall(json.decode, args)

			if _ and type(args_json) == 'table' then

				if type(args_json['server_ip']) == 'table' then

					return CC.set_server_ip(

						args_json['server_ip'],

						args_json['server_port']

					)

				else

					return CC.set_server_ip(

						json.decode(args_json['server_ip']),

						args_json['server_port']

					)

				end

			else

				return false

			end

		end

	end

	CC.set_server_ip = function(...)

		local ip_list = {}

		if type(select(1,...)) == 'table' then

			ip_list = select(1, ...)

		elseif type(select(1,...)) == 'string' then

			ip_list = {select(1, ...)}

		else

			error(_err_msg.submit_ip, 2)

		end

		_server.port = select(2, ...) or 27010

		local socket = require('socket')

		local s = socket.tcp()

		s:settimeout(1)

		for k,v in ipairs(ip_list) do

			local s = socket.tcp()

			s:settimeout(1)

			if s:connect(string.format('%s',v), _server.port) == 1 then

				_server.ip = v

				return true

			end

		end

		if _server.ip == '' then

			error(_err_msg.not_find, 2)

		end

	end

	CC.set_sever_ip = CC.set_server_ip

	CC.log = function(t)

		if _server.ip == '' then error(_err_msg.not_init, 2) end

		if type(t) == 'table' then

			for key, value in pairs(t) do

				_server.field[key] = value

			end

		else

			_server.field['遄'] = tostring(t)

		end

		http.post(('http://%s:%s/log'):format(_server.ip, _server.port), 5, {}, json.encode(_server.field))

	end

	CC.getui = function()

		if _server.ip == '' then error(_err_msg.not_init, 2) end

		while true do

			local r = {http.get(string.format('http://%s:%s/getui', _server.ip, _server.port))}

			if r[1] == 200 then return json.decode(r[3]) end

			sys.sleep(2)

			sys.toast(_err_msg.timeout)

		end

	end

	CC.db = {

		add = (function(db,t)

			return send_cc(db,'add',t)

		end),

		del = (function(db,t)

			return send_cc(db,'del',t)

		end),

		edit = (function(db,t)

			return send_cc(db,'edit',t)

		end),

		get = (function(db,t)

			return send_cc(db,'get',t)

		end),

		list = (function(db,t)

			return send_cc(db,'list',t or {})

		end)

	}

	CC.web_file = {

		take_line = (function(path)

			return post('file','take_line',{path=path}).data

		end),

		take_file = (function(path)

			local r = post('file','take_file',{path=path})

			if r.success then

				return r.data:base64_decode()

			else

				return nil

			end

		end),

		exists = function(path)

			local r = post('file','exists',{path=path})

			if r.info == json.null then

				return false

			else

				return r.info

			end

		end,

		list = (function(path)

			return post('file','list',{path=path}).list

		end),

		size = (function(path)

			return post('file','size',{path=path}).fsize

		end),

		delete = (function(path)

			return post('file','delete',{path=path}).success

		end),

		reads = (function(path)

			local r = post('file','reads',{path=path})

			if r.success then

				return r.data:base64_decode()

			else

				return nil

			end

		end),

		writes = (function(path,data)

			return post('file','writes',{path=path,data=data:base64_encode()}).success

		end),

		appends = (function(path,data)

			return post('file','appends',{path=path,data=data:base64_encode()}).success

		end),

		line_count = (function(path)

			return post('file','line_count',{path=path}).linecount

		end),

		get_line = (function(path,line_number)

			return post('file','get_line',{path=path,line_number=line_number}).line

		end),

		set_line = (function(path,line_number,data)

			return post('file','set_line',{path=path,line_number=line_number,data=data}).success

		end),

		insert_line = (function(path,line_number,data)

			return post('file','insert_line',{path=path,line_number=line_number,data=data}).success

		end),

		remove_line = (function(path,line_number)

			return post('file','remove_line',{path=path,line_number=line_number}).success

		end),

		get_lines = (function(path)

			return post('file','get_lines',{path=path}).lines

		end),

		insert_lines = (function(path,line_number,lines)

			return post('file','insert_lines',{path=path,line_number=line_number,lines=lines}).success

		end),

		update_file = (function(file,path)

			local f, err = io.open(path,'rb')

			if not f then error(err,2) end

			local s = f:read('*a')

			f:close()

			return post('file-byte','update?file=' .. encodeURI(file), s) == 'ok'

		end),

		down_file = (function(file,path)

			local code, header, body

			while true do

				code, header, body = http.get(('http://%s:%s/file-byte/down?file=%s'):format(_server.ip, _server.port, encodeURI(file)), 30)

				if code == 200 or code == 404 then break end

			end

			if code == 404 then

				error('蜀ö
X(',2)

			else

				local f = io.open(path,'wb')

				f:write(body)

				f:close()

				return true

			end

		end),

	}

	CC.web_directory = {

		exists = function(path)

			local r = post('directory','exists',{path=path})

			if type(r.info) == 'userdata' then

				return false

			else

				return r.info

			end

		end,

		create = (function(path)

			return post('directory','create',{path=path}).success

		end),

		delete = (function(path,data)

			return post('directory','delete',{path=path}).success

		end),

	}

	CC.web_directory.exicts = CC.web_directory.exists

	CC.field = CC.log

end



return CC