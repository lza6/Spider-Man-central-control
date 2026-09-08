--[[

	dm.lua

	Created by 苏泽 on 16-10-13.
	Copyright (c) 2016年 苏泽. All rights reserved.


	使用说明：
	1、将 dm.lua 放到 /var/mobile/Media/1ferver/lua/ 目录下
	2、在自己的脚本中如下例使用
		local dm = require("dm")                    -- 引用 dm 库
		dm.SetPath("/var/mobile/Media/1ferver/res") -- 设置字库查找目录，默认 /var/mobile/Media/1ferver/res
		dm.SetDict(0, "dm_soft.txt")                -- 设置一个编号对应的字库文件
		dm.UseDict(0)                               -- 选择字库编号，默认 0

		local found, x, y, boxes = dm.FindStr(0, 0, 307, 215, "相机", "4d4226-404010", 1.0)
		nLog(found, x, y, boxes)

		local text, boxes = dm.Ocr(0, 0, 307, 215, "4d4226-404010", 1.0)
		nLog(text, boxes)

		-- 脑洞做个找点阵函数
		local found, x, y, text, boxes = dm.FindMatrix(0, 0, 0, 0
		, "00201C0780F01E07C0F80E01EE3BE7FFEFFCFF1FFBF93E21C0380717E2FF7FFFFEFFFF9FEBFC7F0FE1F0380700E00C01801$两朵花$8.0.398$18"
		, "CB4503-141004", 1.0)
		nLog(found, x, y, text, boxes)

--]]

local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local XXT_RES_PATH = XXT_RES_PATH or XXT_HOME_PATH .. "/res"
local lfs = require("lfs")
local lfs_attributes = lfs.attributes

local check_value = functor.argth.check_value
local opt_value = functor.argth.opt_value

local matrix_dict_load_file = matrix_dict.load_file
local matrix_dict_load_string = matrix_dict.load_string
local matrix_dict_new = matrix_dict.new

local _dict_table = {}
local _dict_root_path = XXT_RES_PATH
local _used_dict = 0

local _ENV = {
	type = type,
	error = error,
	ipairs = ipairs,
	tonumber = tonumber,
	string = {
		format = string.format
	},
	math = {
		floor = math.floor,
		type = math.type,
	},
	screen = {
		image = screen.image,
	},
	table = {
		concat = table.concat,
	},
}

local function set_path(...)
	local dict_root_path = check_value(1, "string", ...)
	local dict_dir_info, err = lfs_attributes(dict_root_path)
	if type(dict_dir_info) == "table" then
		if dict_dir_info.mode == "directory" then
			_dict_root_path = dict_root_path
		else
			error(string.format("`SetPath`: `%s` is not a directory", dict_root_path), 2)
		end
	else
		error("`SetPath`: " .. err, 2)
	end
end

local function set_dict(...)
	local index = check_value(1, "integer", ...)
	local dict_path = _dict_root_path .. "/" .. check_value(2, "string", ...)
	local dict_file_info, err = lfs_attributes(dict_path)
	if type(dict_file_info) == "table" then
		if dict_file_info.mode == "file" then
			_dict_table[index] = matrix_dict_load_file(dict_path)
		else
			error(string.format("`SetDict`: `%s` is not a file", dict_path), 2)
		end
	else
		error("`SetDict`: " .. err, 2)
	end
end

local function load_dict(...)
	local index = check_value(1, "integer", ...)
	local dict_str = check_value(2, "string", ...)
	_dict_table[index] = matrix_dict_load_string(dict_str)
end

local function use_dict(...)
	local index = check_value(1, "integer", ...)
	_used_dict = index
end

local function find_str(...)
	local rect_x1 = math.floor(check_value(1, "number", ...))
	local rect_y1 = math.floor(check_value(2, "number", ...))
	local rect_x2 = math.floor(check_value(3, "number", ...))
	local rect_y2 = math.floor(check_value(4, "number", ...))
	if rect_x2 < rect_x1 or rect_y2 < rect_y1 then
		error(string.format("bad argument rect(%d, %d, %d, %d) to `FindStr`", rect_x1, rect_y1, rect_x2, rect_y2), 2)
	end
	local rect_img
	if rect_x1 == rect_x2 and rect_y1 == rect_y2 and rect_x1 == 0 and rect_y1 == 0 then
		rect_img = screen.image() -- 四个零代表全屏
	else
		rect_img = screen.image(rect_x1, rect_y1, rect_x2, rect_y2)
	end

	local need_find = check_value(5, "string", ...)
	local need_find_table = need_find:split("|")

	local color_offset = check_value(6, "string", ...)
	local color_offset_table = {}
	color_offset = table.concat(color_offset:split("|"), ',')
	for _, v in ipairs(color_offset:split(",")) do
		local oc = v:split("-")
		_ = #oc == 2 or
			error(
				string.format("bad argument #6 to `FindStr` string as `XXXXXX-XXXXXX,...` expected (got `%s`)",
					color_offset), 2)
		oc[1] = tonumber(oc[1], 16)
		oc[2] = tonumber(oc[2], 16)
		if oc[1] and oc[2] then
			color_offset_table[#color_offset_table + 1] = { oc[1], oc[2] }
		end
	end

	if not _dict_table[_used_dict] then
		error("`FindStr`: no dictionary loaded for index " .. _used_dict, 2)
	end

	rect_img = rect_img:binaryzation(color_offset_table)

	local sim = math.floor(check_value(7, "number", ...) * 100)
	sim = (sim <= 100 and sim) or 100

	if _dict_table[_used_dict] then
		local x, y, boxes = rect_img:dm_find_str(_dict_table[_used_dict], { sim = sim, find = need_find_table })
		boxes = boxes or {}
		for _, v in ipairs(boxes) do
			v.x = v.x + rect_x1
			v.y = v.y + rect_y1
		end
		if x ~= -1 then
			return true, rect_x1 + x, rect_y1 + y, boxes
		end
	end

	return false, -1, -1, {}
end

local function ocr(...)
	local rect_x1 = math.floor(check_value(1, "number", ...))
	local rect_y1 = math.floor(check_value(2, "number", ...))
	local rect_x2 = math.floor(check_value(3, "number", ...))
	local rect_y2 = math.floor(check_value(4, "number", ...))
	if rect_x2 < rect_x1 or rect_y2 < rect_y1 then
		error(string.format("bad argument rect(%d, %d, %d, %d) to `Ocr`", rect_x1, rect_y1, rect_x2, rect_y2), 2)
	end
	local rect_img
	if rect_x1 == rect_x2 and rect_y1 == rect_y2 and rect_x1 == 0 and rect_y1 == 0 then
		rect_img = screen.image() -- 四个零代表全屏
	else
		rect_img = screen.image(rect_x1, rect_y1, rect_x2, rect_y2)
	end

	local color_offset = check_value(5, "string", ...)
	local color_offset_table = {}
	color_offset = table.concat(color_offset:split("|"), ',')
	for _, v in ipairs(color_offset:split(",")) do
		local oc = v:split("-")
		_ = #oc == 2 or
			error(
				string.format("bad argument #5 to `Ocr` string as `XXXXXX-XXXXXX,...` expected (got `%s`)", color_offset),
				2)
		oc[1] = tonumber(oc[1], 16)
		oc[2] = tonumber(oc[2], 16)
		if oc[1] and oc[2] then
			color_offset_table[#color_offset_table + 1] = { oc[1], oc[2] }
		end
	end

	if not _dict_table[_used_dict] then
		error("`Ocr`: no dictionary loaded for index " .. _used_dict, 2)
	end

	rect_img = rect_img:binaryzation(color_offset_table)

	local sim = math.floor(check_value(6, "number", ...) * 100)
	sim = (sim <= 100 and sim) or 100

	if _dict_table[_used_dict] then
		local text, boxes = rect_img:dm_ocr(_dict_table[_used_dict], sim)
		boxes = boxes or {}
		for _, v in ipairs(boxes) do
			v.x = v.x + rect_x1
			v.y = v.y + rect_y1
		end
		return text, boxes
	end

	return "", {}
end

local function find_matrix(...)
	local rect_x1 = math.floor(check_value(1, "number", ...))
	local rect_y1 = math.floor(check_value(2, "number", ...))
	local rect_x2 = math.floor(check_value(3, "number", ...))
	local rect_y2 = math.floor(check_value(4, "number", ...))
	if rect_x2 < rect_x1 or rect_y2 < rect_y1 then
		error(string.format("bad argument rect(%d, %d, %d, %d) to `FindMatrix`", rect_x1, rect_y1, rect_x2, rect_y2), 2)
	end
	local rect_img
	if rect_x1 == rect_x2 and rect_y1 == rect_y2 and rect_x1 == 0 and rect_y1 == 0 then
		rect_img = screen.image() -- 四个零代表全屏
	else
		rect_img = screen.image(rect_x1, rect_y1, rect_x2, rect_y2)
	end

	local matrix_list_string = check_value(5, "string", ...)
	local need_find_table = {}

	local current_dict = matrix_dict_new()
	for idx, matrix in ipairs(matrix_list_string:split("\n")) do
		if matrix:trim() ~= "" then
			local mt = matrix:split("$")
			if #mt < 4 or current_dict:add_with_string(matrix) ~= 1 then
				error(
					string.format("bad argument #5[%d] to `FindMatrix` matrix_string expected (got `%s`)", idx, matrix),
					2)
			else
				need_find_table[#need_find_table + 1] = mt[2]
			end
		end
	end

	local color_offset = check_value(6, "string", ...)
	local color_offset_table = {}
	color_offset = table.concat(color_offset:split("|"), ',')
	for _, v in ipairs(color_offset:split(",")) do
		local oc = v:split("-")
		_ = #oc == 2 or
			error(
				string.format("bad argument #6 to `FindMatrix` string as `XXXXXX-XXXXXX,...` expected (got `%s`)",
					color_offset),
				2)
		oc[1] = tonumber(oc[1], 16)
		oc[2] = tonumber(oc[2], 16)
		if oc[1] and oc[2] then
			color_offset_table[#color_offset_table + 1] = { oc[1], oc[2] }
		end
	end

	rect_img = rect_img:binaryzation(color_offset_table)

	local sim = math.floor(check_value(7, "number", ...) * 100)
	sim = (sim <= 100 and sim) or 100

	for _, v in ipairs(need_find_table) do
		local x, y, boxes = rect_img:dm_find_str(current_dict, sim, v)
		boxes = boxes or {}
		for _, v in ipairs(boxes) do
			v.x = v.x + rect_x1
			v.y = v.y + rect_y1
		end
		if x ~= -1 then
			return true, rect_x1 + x, rect_y1 + y, v, boxes
		end
	end

	return false, -1, -1, "", {}
end

return {
	SetPath     = set_path,
	SetDict     = set_dict,
	LoadDict    = load_dict,
	UseDict     = use_dict,
	FindStr     = find_str,
	FindMatrix  = find_matrix,
	Ocr         = ocr,

	setPath     = set_path,
	setDict     = set_dict,
	loadDict    = load_dict,
	useDict     = use_dict,
	findStr     = find_str,
	findMatrix  = find_matrix,
	ocr         = ocr,

	set_path    = set_path,
	set_dict    = set_dict,
	load_dict   = load_dict,
	use_dict    = use_dict,
	find_str    = find_str,
	find_matrix = find_matrix,

	_VERSION    = "0.1.2",
	_AUTHOR     = "苏泽",
}
