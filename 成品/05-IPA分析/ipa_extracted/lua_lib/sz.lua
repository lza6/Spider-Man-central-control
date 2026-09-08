--[[

	sz.lua

	Created by 苏泽 on 17-08-11.
	Copyright (c) 2017年 苏泽. All rights reserved.

	使用说明：
	你们要的 sz 库兼容
	1、将 sz.lua 放到 /var/mobile/Media/1ferver/lua/ 目录下
	2、在自己的脚本中如下例使用
		local sz = require("sz")  -- 引用 sz 库
		-- 然后随便了

--]]

local plist = require('plist')

_G.package.loaded["szocket"] = require('socket')
_G.package.loaded["szocket.ftp"] = require('socket.ftp')
_G.package.loaded["szocket.http"] = require('socket.http')
_G.package.loaded["szocket.smtp"] = require('socket.smtp')
_G.package.loaded["szocket.tp"] = require('socket.tp')
_G.package.loaded["szocket.url"] = require('socket.url')
_G.package.loaded["szocket.headers"] = require('socket.headers')

local function mod_ftp()
	--获取路径
	local function strip_filename(filename)
	  return string.match(filename, "(.+)/[^/]*%.%w+$") --*nix system
	  --return string.match(filename, “(.+)\\[^\\]*%.%w+$”) — windows
	end

	--获取文件名
	local function strip_path(filename)
	  return string.match(filename, ".+/([^/]*%.%w+)$") -- *nix system
	  --return string.match(filename, “.+\\([^\\]*%.%w+)$”) — *nix system
	end

	--去除扩展名
	local function strip_extension(filename)
	  local idx = filename:match(".+()%.%w+$")
	  if(idx) then
	    return filename:sub(1, idx-1)
	  else
	    return filename
	  end
	end

	--获取扩展名
	local function get_extension(filename)
	  return filename:match(".+%.(%w+)$")
	end

	local ftp = {}
	local function fexists(file_name)
	  local f = io.open(file_name, "r")
	  return f and (f:close() or true)
	end

	local function try_connect(host, port, connect_timeout)
	  local socket = require("szocket")
	  local c = socket.tcp()
	  c:settimeout(tonumber(connect_timeout) or 10)
	  local r, e = c:connect(host, port)
	  return r, e
	end

	ftp.try_connect = try_connect

	function ftp.download(remote_file, local_file, connect_timeout)
	  assert(type(remote_file)=="string")
	  assert(type(local_file)=="string")
	  local ftp = require("szocket.ftp")
	  local url = require("szocket.url")
	  local ltn12 = require("ltn12")
	  local p = url.parse(remote_file)
	  if not p then
	    return nil, "host or service not provided, or not known"
	  end
	  local _, err = try_connect(p.host, p.port or 21, connect_timeout)
	  if err then
	    return nil, err
	  end
	  local contents, err = ftp.get(remote_file)
	  if not contents then
	    return nil, err
	  end
	  local f, err = io.open(local_file, "w")
	  if not f then
	    return nil, err
	  end
	  f:write(contents)
	  f:close()
	  return true
	end

	function ftp.upload(local_file, remote_dir, connect_timeout)
	  assert(type(local_file)=="string")
	  assert(type(remote_dir)=="string")
	  local ftp = require("szocket.ftp")
	  local url = require("szocket.url")
	  local ltn12 = require("ltn12")
	  local p = url.parse(remote_dir)
	  if not p then
	    return nil, "host or service not provided, or not known"
	  end
	  local f, err = io.open(local_file, "r")
	  if not f then
	    return nil, err
	  end
	  local _, err = try_connect(p.host, p.port or 21, connect_timeout)
	  if err then
	    return nil, err
	  end
	  if remote_dir:sub(-1, -1)~="/" then
	    remote_dir = remote_dir.."/"
	  end
	  local contents = f:read("*a")
	  f:close()
	  return ftp.put(remote_dir..strip_path(local_file), contents)
	end

	function ftp.cmd(u, cmd)
	  local ftp = require("szocket.ftp")
	  local url = require("szocket.url")
	  local ltn12 = require("ltn12")
	  local t = {}
	  local p = url.parse(u)
	  local _, err = try_connect(p.host, p.port or 21, 10)
	  if err then
	    return nil, err
	  end
	  p.command = cmd or ""
	  p.sink = ltn12.sink.table(t)
	  local r, e = ftp.get(p)
	  return r and table.concat(t), e
	end

	ftp._AUTHOR = "苏泽"
	ftp._VERSION = "1.1"

	return ftp
end

local function mod_http()
	local http = {}

	function http.get(url, timeout, headers)
		local http = require("szocket.http")
		local ltn12 = require("ltn12")
		local orgTIMEOUT = http.TIMEOUT
		post_data = post_data or ""
		post_data = tostring(post_data)
		http.TIMEOUT = tonumber(timeout) or 10
		local body = {}
		headers = headers or {}
		if not headers["Content-Type"] then
			headers["Content-Type"] = "application/x-www-form-urlencoded"
		end
		if not headers["User-Agent"] then
			headers["User-Agent"] = "sz.so"
		end
		local r, c, h = http.request{
			method = "GET",
			url = url,
			headers = headers,
			sink = ltn12.sink.table(body)
		}
		http.TIMEOUT = orgTIMEOUT
		if c~= 200 then
			return nil
		end
		body = table.concat(body)
		return body
	end

	function http.post(url, post_data, timeout, headers)
		local http = require("szocket.http")
		local ltn12 = require("ltn12")
		local orgTIMEOUT = http.TIMEOUT
		post_data = post_data or ""
		post_data = tostring(post_data)
		http.TIMEOUT = tonumber(timeout) or 10
		local body = {}
		headers = headers or {}
		if not headers["Content-Type"] then
			headers["Content-Type"] = "application/x-www-form-urlencoded"
		end
		if not headers["Content-Length"] then
			headers["Content-Length"] = #post_data
		end
		if not headers["User-Agent"] then
			headers["User-Agent"] = "sz.so"
		end
		local r, c, h = http.request{
			method = "POST",
			url = url,
			headers = headers,
			source = ltn12.source.string(post_data),
			sink = ltn12.sink.table(body)
		}
		http.TIMEOUT = orgTIMEOUT
		if c~= 200 then
			return nil
		end
		body = table.concat(body)
		return body
	end

	return http
end

local function mod_i82()
	local i82 = {
		http = {},
	}
	local http = i82.http

	function http.get(url, timeout, headers)
		local http = require("szocket.http")
		local ltn12 = require("ltn12")
		local orgTIMEOUT = http.TIMEOUT
		post_data = post_data or ""
		post_data = tostring(post_data)
		http.TIMEOUT = tonumber(timeout) or 10
		local body = {}
		headers = headers or {}
		if not headers["Content-Type"] then
			headers["Content-Type"] = "application/x-www-form-urlencoded"
		end
		if not headers["User-Agent"] then
			headers["User-Agent"] = "sz.so"
		end
		local r, c, h = http.request{
			method = "GET",
			url = url,
			headers = headers,
			sink = ltn12.sink.table(body)
		}
		http.TIMEOUT = orgTIMEOUT
		body = table.concat(body)
		return c, h, body
	end

	function http.post(url, timeout, headers, post_data)
		local http = require("szocket.http")
		local ltn12 = require("ltn12")
		local orgTIMEOUT = http.TIMEOUT
		post_data = post_data or ""
		post_data = tostring(post_data)
		http.TIMEOUT = tonumber(timeout) or 10
		local body = {}
		headers = headers or {}
		if not headers["Content-Type"] then
			headers["Content-Type"] = "application/x-www-form-urlencoded"
		end
		if not headers["Content-Length"] then
			headers["Content-Length"] = #post_data
		end
		if not headers["User-Agent"] then
			headers["User-Agent"] = "sz.so"
		end
		local r, c, h = http.request{
			method = "POST",
			url = url,
			headers = headers,
			source = ltn12.source.string(post_data),
			sink = ltn12.sink.table(body)
		}
		http.TIMEOUT = orgTIMEOUT
		body = table.concat(body)
		return c, h, body
	end

	return i82
end

return {
	plist = plist,
	pos = pos,
	color = color,
	json = json,
	null = json.null,
	cjson = require('cjson'),
	cjson_safe = require('cjson.safe'),
	system = (function()
		local sys = table.deep_copy(sys)
		local mgcopyanswer = sys.mgcopyanswer
		sys.serialnumber = sys.serial_number
		sys.wifimac = sys.wifi_mac
		sys.btmac = function()
			return mgcopyanswer('BluetoothAddress')
		end
		sys.osversion = sys.version
		sys.localwifiaddr = device.ifaddrs
		return sys
	end)(),
	sqlite3 = require('sqlite3'),
	ftp = mod_ftp(),
	http = mod_http(),
	i82 = mod_i82(),
	_VERSION = '1.5.6',
	_AUTHOR = 'havonz',
	_DESCRIPTION = 'szlib for XXTouch',
}