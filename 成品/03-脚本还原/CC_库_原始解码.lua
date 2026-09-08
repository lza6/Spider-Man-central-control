R穕ocal CC = {}
do
	local _err_msg = {
		timeout = [[ ★款薕ö
1.鱪¤-эc8蠰
2.-э2k饰鱪輘í
3.鱪菥  -э巳 蹙 T*@逹]],
		server_bug = [[★ú° ï ÷ 绽å VPN   HTTP ã 緉 ]],
		submit_ip = [[肖葎¡hIPcn]],
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
			return CC