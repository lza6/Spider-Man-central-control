--[[

	no_os_execute.lua

	Created by 苏泽 on 22-11-06.
	Copyright (c) 2022年 苏泽. All rights reserved.

	local noexecute = require('no_os_execute')

	-- 不支持通配符，文件名不转义
	errlist = noexecute.cp_r('/var/mobile/Media/1ferver/web', '/var/mobile/Media/1ferver/we b2')
	noexecute.lchmod_r('/var/mobile/Media/1ferver/we b2', 644)
	noexecute.lchown_r('/var/mobile/Media/1ferver/we b2', 501, 501)
	noexecute.mkdir_p('/var/mobile/Media/1ferver/lua/scripts/a/b/c/d')
	noexecute.lchownmod_r('/var/mobile/Media/1ferver/lua/scripts/a', 501, 501, 755)
	errlist = noexecute.rm_rf('/var/mobile/Media/1ferver/we b2', '/var/mobile/Media/1ferver/we b3') -- 递归删除多个目录中所有文件或删除多个文件，返回被删除的文件列表（如果目标文件是个符号链接，则仅删除符号链接，而删除非原文件或指向原目录的所有内容）
	errlist = noexecute.clear_dirs('/var/mobile/Media/1ferver/we b2', '/var/mobile/Media/1ferver/we b3') -- 递归清空目录中所有内容，返回被删除的文件列表（即使是一个指向目录的符号链接也会清空目标目录的内容，但如果目标既不是目录也不是指向目录的符号链接，则什么也不发生）
	noexecute.killall(9, 'XXTExplorer')

	-- 以下方式不推荐用，同样不支持通配符，不转义，支持带空格的命令行参数
	noexecute.run_cmd(jbroot "/usr/bin/killall", "-9", "XXTExplorer")
	noexecute.run_cmd(jbroot "/usr/bin/cp", "-rf", "/var/mobile/Media/1ferver/web", "/var/mobile/Media/1ferver/we b2")
	noexecute.run_cmd(jbroot "/usr/bin/rm", "-rf", "/var/mobile/Media/1ferver/we b2")

--]]

local _ENV = table.deep_copy(_ENV)

local _M = {}

_M._VERSION = "0.4.3"

local lfs = require 'lfs'
local path_manager = require 'path'
local spawn = require 'spawn'

local _debug_getinfo = debug.getinfo
local ok, unix = pcall(require, 'unix')
if not ok then
	unix = {
		kill = sys.kill,
		lchown = sys.lchown,
		lchmod = sys.lchmod,
	}
end
unix.lchmod = unix.lchmod or sys.lchmod or unix.chmod
local ok, stdlib = pcall(require, 'posix.stdlib')
if ok then
	sys.realpath = sys.realpath or stdlib.realpath
end
local _lfs_dir = lfs.dir
local _lfs_attributes = lfs.attributes
local _lfs_symlinkattributes = lfs.symlinkattributes
local _lfs_mkdir = lfs.mkdir
local _lfs_link = lfs.link
local _sys_mkdir_p = sys.mkdir_p
local _os_remove = os.remove
local _io_open = io.open
local _string_format = string.format
functor = type(functor) == 'table' and functor or {
	argth = {
		check_value = function(arg_count, expected_type, ...)
			local argc = select("#", ...)
			if argc < arg_count then
				local dbinfo = _debug_getinfo(2)
				local ftype = (type(dbinfo.namewhat) == "string" and dbinfo.namewhat) or ""
				local fname = (type(dbinfo.name) == "string" and dbinfo.name) or (type(field) == "string" and field) or
				"?"
				local got_type = (type(the_value) == "number" and math.type(the_value)) or type(the_value)
				error(
				_string_format("bad argument #%d%s to%s '%s' (%s expected%s)", arg_count, "", ftype, fname, expected_type,
					", got no value"), 3)
			else
				local the_value = select(arg_count, ...)
				if expected_type == "integer" and tonumber(the_value) and math.tointeger(tonumber(the_value)) then
					return math.tointeger(tonumber(the_value))
				elseif expected_type == "number" and tonumber(the_value) then
					return tonumber(the_value)
				elseif string.find(expected_type, "integer") and tonumber(the_value) and math.tointeger(tonumber(the_value)) then
					return the_value
				elseif string.find(expected_type, "number") and tonumber(the_value) then
					return the_value
				elseif not string.find(expected_type, type(the_value)) then
					local dbinfo = _debug_getinfo(2)
					local ftype = (type(dbinfo.namewhat) == "string" and dbinfo.namewhat) or ""
					local fname = (type(dbinfo.name) == "string" and dbinfo.name) or (type(field) == "string" and field) or
					"?"
					local got_type = (type(the_value) == "number" and math.type(the_value)) or type(the_value)
					error(
					_string_format("bad argument #%d%s to%s '%s' (%s expected%s)", arg_count, "", ftype, fname,
						expected_type, _string_format(", got %s", got_type)), 3)
				else
					return the_value
				end
			end
		end,
	}
}
local _check_value = functor.argth.check_value

local function _directory_all_files(dir, list)
	list = list or {}
	for name in _lfs_dir(dir) do
		if (name ~= '.' and name ~= '..') then
			local item_path = dir .. '/' .. name
			if (_lfs_symlinkattributes(item_path, 'mode') == 'directory') then
				_directory_all_files(item_path, list)
			else
				list[#list + 1] = item_path
			end
		end
	end
	list[#list + 1] = dir
	return list
end

local function _list_all_files(path)
	local list = {}
	local info = _lfs_attributes(path)
	if (type(info) == 'table' and info.mode == 'directory') then
		while path:sub(-1) == '/' do
			path = path:sub(1, -2)
		end
		return _directory_all_files(path, list)
	else
		if (info ~= nil) then
			list[#list + 1] = path
		end
	end
	return list
end

local function _SM(s, o, g, p)
	return s * 8 ^ 3 | o * 8 ^ 2 | g * 8 | p
end

local function _SM_D2O(dmode)
	if (dmode > 7777 or dmode < 0) then
		return nil, _string_format("mode value range 0000 ~ 7777, got %d", dmode)
	end
	local s = dmode - (dmode % 1000)
	local o = dmode - s
	o = o - o % 100
	local g = dmode - s - o
	g = g - g % 10
	local p = dmode % 10
	local math_floor = math.floor
	s = math_floor(s / 1000)
	o = math_floor(o / 100)
	g = math_floor(g / 10)
	if (s > 7 or o > 7 or g > 7 or p > 7) then
		return nil, _string_format("mode value range 0000 ~ 7777, field range 0 ~ 7, got %d%d%d%d", s, o, g, p)
	end
	return _SM(s, o, g, p)
end

function _M.lchmod_r(...) -- (path, dmode)
	local path = _check_value(1, 'string', ...)
	local dmode = _check_value(2, 'integer', ...)
	local sys_lchmod = unix.lchmod
	local mode, err = _SM_D2O(dmode)
	if not mode then
		error("bad argument #2 to '" .. tostring(_debug_getinfo(1).name or "?") .. "' (" .. err .. ")", 2)
	end
	for _, v in ipairs(_list_all_files(path)) do
		sys_lchmod(v, mode)
	end
end

function _M.lchown_r(...) -- (path, uid, gid)
	local path = _check_value(1, 'string', ...)
	local uid = _check_value(2, 'integer', ...)
	local gid = _check_value(3, 'integer', ...)
	local sys_lchown = unix.lchown
	for _, v in ipairs(_list_all_files(path)) do
		sys_lchown(v, uid, gid)
	end
end

function _M.lchownmod_r(...) -- (path, uid, gid, dmode)
	local path = _check_value(1, 'string', ...)
	local uid = _check_value(2, 'integer', ...)
	local gid = _check_value(3, 'integer', ...)
	local dmode = _check_value(4, 'integer', ...)
	local sys_lchown = unix.lchown
	local sys_lchmod = unix.lchmod
	local mode, err = _SM_D2O(dmode)
	if not mode then
		error("bad argument #4 to '" .. tostring(_debug_getinfo(1).name or "?") .. "' (" .. err .. ")", 2)
	end
	for _, v in ipairs(_list_all_files(path)) do
		sys_lchown(v, uid, gid)
		sys_lchmod(v, mode)
	end
end

local function _string_startswith(str, prefix, case_insensitive)
	if #prefix > #str then
		return false
	end
	if case_insensitive then
		str = str:lower()
		prefix = prefix:lower()
	end
	local prefix_len = #prefix
	if str == prefix then
		return true
	elseif #str > prefix_len then
		local s = str:sub(1, prefix_len)
		return s == prefix
	end
	return false
end

local function _clear_dir(dir, errlist)
	errlist = errlist or {}
	if _lfs_attributes(dir, 'mode') == 'directory' then
		local list = _list_all_files(dir)
		list[#list] = nil
		for _, v in ipairs(list) do
			local done, err = _os_remove(v)
			if not done then
				table.insert(errlist, _string_format("%s %q", err, v))
			end
		end
	else
		table.insert(errlist, _string_format("%s %q", 'not a directory', dir))
	end
	return errlist
end

function _M.clear_dirs(...)
	local pathlist = {}
	for i = 1, select("#", ...) do
		local path = _check_value(i, 'string', ...)
		table.insert(pathlist, path)
	end
	local errlist = {}
	for _, path in ipairs(pathlist) do
		_clear_dir(path, errlist)
	end
	return errlist
end

function _M.rm_rf(...) -- (path1, path2, path3, ...)
	local pathlist = {}
	local is_rootful = jbroot('/') == '/'
	for i = 1, select("#", ...) do
		local path = _check_value(i, 'string', ...)
		table.insert(pathlist, path)
		if is_rootful then
			if #path < 10 and (not (_string_startswith(path, '/var/') and #path > 5)) then
				error("bad argument #1 to '" .. tostring(_debug_getinfo(1).name or "?") .. "' (path too short)", 2)
			end
		end
	end
	local errlist = {}
	for _, path in ipairs(pathlist) do
		local done, err = _os_remove(path) -- 如果不是目录或是空目录，直接删除
		if not done then
			if _lfs_attributes(path, 'mode') == 'directory' then
				local list = _list_all_files(path)
				for _, v in ipairs(list) do
					local done, err = _os_remove(v)
					if not done then
						table.insert(errlist, _string_format("%s %q", err, v))
					end
				end
			else
				table.insert(errlist, _string_format("%s %q", err, path))
			end
		end
	end
	return errlist
end

local function _cp_file(src, dest)
	local sf, err = _io_open(src, 'r')
	if sf == nil then
		return nil, _string_format("%s %q", err, src)
	end
	local df, err = _io_open(dest, 'w')
	if df == nil then
		return nil, _string_format("%s %q", err, dest)
	end
	local buf
	repeat
		buf = sf:read(1024 * 1024 * 10)
		if (buf) then
			df:write(buf)
		end
	until not buf
	sf:close()
	df:close()
	return true
end

local function _cp_dir(src_dir, dest_dir, errlist)
	errlist = errlist or {}
	for name in _lfs_dir(src_dir) do
		if (name ~= '.' and name ~= '..') then
			local src_item_path = src_dir .. '/' .. name
			local src_item, src_item_err = _lfs_symlinkattributes(src_item_path)
			local dest_item_path = dest_dir .. '/' .. name
			local dest_item, dest_item_err = _lfs_attributes(dest_item_path)
			if type(src_item) == 'table' then
				if (src_item.mode == 'directory') then
					if dest_item == nil then
						_lfs_mkdir(dest_item_path)
						_cp_dir(src_item_path, dest_item_path, errlist)
					elseif (type(dest_item) == 'table' and dest_item.mode == 'directory') then
						_cp_dir(src_item_path, dest_item_path, errlist)
					else
						errlist[#errlist + 1] = _string_format('cannot overwrite non-directory %q with directory %q',
							dest_item_path, src_item_path)
					end
				elseif (src_item.mode == 'file') then
					if (dest_item == nil or (type(dest_item) == 'table' and dest_item.mode == 'file')) then
						local ok, err = _cp_file(src_item_path, dest_item_path)
						if not ok then
							errlist[#errlist + 1] = err
						end
					else
						errlist[#errlist + 1] = _string_format('cannot overwrite %s %q with file %q', dest_item.mode,
							dest_item_path, src_item_path)
					end
				elseif (src_item.mode == 'link' and type(src_item.target) == 'string') then
					if (dest_item == nil or (type(dest_item) == 'table' and dest_item.mode == 'file')) then
						if dest_item then
							_os_remove(dest_item_path)
						end
						_lfs_link(src_item.target, dest_item_path, true)
					else
						errlist[#errlist + 1] = _string_format('cannot overwrite %s %q with file %q', dest_item.mode,
							dest_item_path, src_item_path)
					end
				end
			else
				errlist[#errlist + 1] = _string_format('%s %q', src_item_err, src_item_path)
			end
		end
	end
	return errlist
end

function _M.cp_r(...)
	local src = _check_value(1, 'string', ...)
	local dest = _check_value(2, 'string', ...)
	local errlist = {}
	local src_real_path = sys.realpath(src)
	local src_parent_path
	local dest_real_path = sys.realpath(dest)
	if not src_real_path then
		errlist[#errlist + 1] = _string_format('No such file or directory %q', src)
		return errlist
	else
		src_parent_path = sys.realpath(path_manager.join(src_real_path, '..'))
	end
	if not dest_real_path then
		local dirname, basename = path_manager.splitpath(dest)
		dest_real_path = sys.realpath(dirname)
		if dest_real_path then
			dest_real_path = path_manager.join(dest_real_path, basename)
		end
	end
	if not dest_real_path then
		errlist[#errlist + 1] = _string_format('cannot create directory %q: No such file or directory', dest)
		return errlist
	end
	if (src_real_path == dest_real_path) or (src_parent_path == dest_real_path) then
		errlist[#errlist + 1] = _string_format('%s == %s', src, dest)
		return errlist
	end
	if src_real_path == '/' then
		error('no!', 2)
	end
	src = path_manager.remove_dir_end(src_real_path)
	dest = path_manager.remove_dir_end(dest_real_path)
	local src_info, err = _lfs_attributes(src)
	local dest_info = _lfs_attributes(dest)
	if (src_info == nil) then
		errlist[#errlist + 1] = err
		return errlist
	end
	if (src_info.mode == 'directory') then
		if (dest_info == nil) then
			local ok, err = _lfs_mkdir(dest)
			if ok then
				_cp_dir(src, dest, errlist)
			else
				errlist[#errlist + 1] = _string_format('%s %q', err, dest)
				return errlist
			end
		elseif (dest_info.mode == 'directory') then
			dest = path_manager.join(dest, path_manager.basename(src))
			if (src == dest) then
				return errlist
			end
			local ok, err = _lfs_attributes(dest)
			if not ok then
				ok, err = _lfs_mkdir(dest)
			end
			if ok then
				_cp_dir(src, dest, errlist)
			else
				errlist[#errlist + 1] = _string_format('%s %q', err, dest)
				return errlist
			end
		else
			errlist[#errlist + 1] = _string_format('cannot overwrite non-directory %q with directory %q', dest, src)
			return errlist
		end
	elseif (src_info.mode == 'file') then
		if (dest_info == nil or dest_info.mode == 'file') then
			local ok, err = _cp_file(src, dest)
			if not ok then
				errlist[#errlist + 1] = err
			end
		elseif (dest_info.mode == 'directory') then
			dest = path_manager.join(dest, path_manager.basename(src))
			if (src == dest) then
				return errlist
			end
			local ok, err = _cp_file(src, dest)
			if not ok then
				errlist[#errlist + 1] = err
			end
		else
			errlist[#errlist + 1] = _string_format('cannot overwrite %s %q with file %q', dest_info.mode, dest, src)
		end
	end
	return errlist
end

function _M.mkdir_p(...)
	local pathlist = {}
	for i = 1, select("#", ...) do
		local path = _check_value(i, 'string', ...)
		table.insert(pathlist, path)
	end
	for _, path in ipairs(pathlist) do
		_sys_mkdir_p(path)
	end
end

function _killall(...)
	local sig = _check_value(1, 'integer', ...)
	local namelist = { select(2, ...) }
	if #namelist <= 0 then
		return
	end
	local procs = app.all_procs()
	local sys_kill = unix.kill
	for _, info in ipairs(procs) do
		if (type(info) == 'table' and type(info.pid) == 'number') then
			for _, name in ipairs(namelist) do
				if (type(name) == 'string' and info.name == name) then
					sys_kill(info.pid, sig)
					break
				end
			end
		end
	end
end

_M.killall = _killall

function _M.respring()
	if type(clear.caches) == 'function' then
		clear.caches { no_uicache = true }
	end
	sys.killall(9, 'SpringBoard', 'backboardd')
end

_M.system = spawn.system
_M.run_cmd = spawn.run

--[[
nLog(_M.cp_r('/var/mobile/Media/1ferver/web', '/var/mobile/Media/1ferver/web2'))
_M.lchmod_r('/var/mobile/Media/1ferver/web2', 644)
_M.lchown_r('/var/mobile/Media/1ferver/web2', 501, 501)
_M.lchownmod_r('/var/mobile/Media/1ferver/web2', 501, 501, 755)
nLog(_M.cp_r('/var/mobile/Media/1ferver/web', '/var/mobile/Media/1ferver/web3'))
nLog(_M.rm_rf('/var/mobile/Media/1ferver/web2', '/var/mobile/Media/1ferver/web3'))
nLog(_M.cp_r('/var/mobile/Media/1ferver/web', '/var/mobile/Media/1ferver/web3'))
nLog(_M.cp_r('/var/mobile/Media/1ferver/web', '/var/mobile/Media/1ferver/web5'))
nLog(_M.clear_dirs('/var/mobile/Media/1ferver/web3', '/var/mobile/Media/1ferver/web4', '/var/mobile/Media/1ferver/web5'))
nLog(_M.rm_rf('/var/mobile/Media/1ferver/web3', '/var/mobile/Media/1ferver/web4', '/var/mobile/Media/1ferver/web5'))
_M.killall(9, 'XXTExplorer')
--]]

return _M
