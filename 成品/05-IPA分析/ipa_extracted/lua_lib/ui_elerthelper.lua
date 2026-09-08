--[[

	ui_elerthelper.lua

	基于 ui_element 的系统弹窗处理服务管理模块。
	ui_elerthelper 不是拼写错误，而是 ui_ele(ment) + alerthelper 的组合命名，
	用于区分基于注入 tweak 的 alerthelper。

	规则会保存到：
		/var/mobile/Media/1ferver/caches/ui-elerthelper.rules

	服务由配置文件中的 ui_elerthelper 开关控制，启用后由 watchdogd
	以内置 keepalive 服务方式启动：
		/var/mobile/Media/1ferver/bin/ui-elerthelper-service.lua

	API：
		local ui_elerthelper = require("ui_elerthelper")

		ui_elerthelper.setRules(rules)         -- 设置规则并通知服务重载
		ui_elerthelper.getRules()              -- 读取当前缓存规则
		ui_elerthelper.clearRules()            -- 清空规则并通知服务重载

		ui_elerthelper.enable([rules])         -- 启用服务，可同时设置规则
		ui_elerthelper.disable([opts])         -- 禁用服务，opts.clearRules=true 时同时清空规则
		ui_elerthelper.isEnabled()             -- 返回服务配置开关状态

		ui_elerthelper.reload()                -- 仅通知服务重载规则
		ui_elerthelper.stop()                  -- 仅停止当前服务实例，不修改配置

		ui_elerthelper.plainPattern(str)       -- 生成普通文本匹配模式
		ui_elerthelper.equalPattern(str)       -- 生成完全相等匹配模式
		ui_elerthelper.plain(str)              -- plainPattern 的别名
		ui_elerthelper.eq(str)                 -- equalPattern 的别名

	规则列表说明：
		规则按顺序匹配。默认命中一条规则后停止继续匹配；规则设置
		continue=true 时，执行完当前规则后会继续匹配后续规则。

		conditions 使用 and 匹配，即一条规则内所有条件都满足才会触发。
		支持字段：
			title       弹窗标题，Lua pattern
			message     弹窗消息，Lua pattern
			buttons     字符串表示任意按钮匹配；数组表示数量和顺序匹配；数字表示按钮数量
			textFields 文本框数量或按顺序匹配 placeholder/value 的数组
			pid         进程 ID，能获取到时匹配
			bundle      兼容字段，优先取弹窗命中元素 bundle，取不到时退回前台 app bundle
			hostBundle  弹窗命中元素所属 bundle，系统弹窗常见值为 com.apple.springboard，Lua pattern
			frontBundle 事件触发时的前台 app bundle，Lua pattern
			systemAlert SpringBoard 远程状态是否认为系统 app 正在显示弹窗，布尔值

		actions 定义命中后的动作。
		支持字段：
			wait           动作前延迟，单位毫秒；纯点击默认 0，textFields 默认 300
			clickButton    按按钮文本或序号点击，序号遵循 Lua 习惯从 1 开始
			clickCancel    点击第一个按钮
			clickPreferred 点击最后一个按钮
			textFields     字符串/数字、数组或 { [placeholder] = value }
			log            true 或函数

	调用示例：
		local ui_elerthelper = require("ui_elerthelper")

		ui_elerthelper.enable({
			{
				name = "通知权限",
				conditions = {
					title = "想给.-发送通知",
					buttons = { "不允许", "允许" },
				},
				actions = {
					wait = 500,
					clickButton = "允许",
				},
			},
		})

		ui_elerthelper.enable({
			{
				name = "登录弹窗-按顺序填充",
				conditions = {
					title = ui_elerthelper.eq("登录 iTunes Store"),
					textFields = 2,
					buttons = "好",
				},
				actions = {
					textFields = { "user@example.com", "password" },
					clickButton = "好",
				},
			},
		})

		ui_elerthelper.enable({
			{
				name = "登录弹窗-按占位文本填充",
				conditions = {
					title = "登录",
					textFields = { "Apple ID", "密码" },
				},
				actions = {
					textFields = {
						["Apple ID"] = "user@example.com",
						["密码"] = "password",
					},
					clickPreferred = true,
				},
			},
		})

--]]

local json = require("cjson.safe")

local RULES_PATH = (XXT_CACHES_PATH or "/var/mobile/Media/1ferver/caches") .. "/ui-elerthelper.rules"
local CONF_PATH = XXT_CONF_FILE_NAME or "/var/mobile/Media/1ferver/1ferver.conf"
local SERVICE_PATH = (XXT_BIN_PATH or "/var/mobile/Media/1ferver/bin") .. "/ui-elerthelper-service.lua"
local LAUNCH_PATH = (XXT_BIN_PATH or "/var/mobile/Media/1ferver/bin") .. "/launch.lua"
local RELOAD_NOTIFY_NAME = "xxtouch.ui-elerthelper/reload"
local EXIT_NOTIFY_NAME = "xxtouch.ui-elerthelper/exit"

local function ensure_parent_dir(path)
	local dir = path:match("^(.*)/[^/]+$")
	if dir and dir ~= "" then
		sys.mkdir_p(dir)
	end
end

local function plainPattern(str)
	return tostring(str or ""):gsub("([%^%$%(%)%%%.%[%]%*%+%-%?])", "%%%1")
end

local function equalPattern(str)
	return "^" .. plainPattern(str) .. "$"
end

local function read_conf()
	local conf = json.decode(file.reads(CONF_PATH) or "")
	return type(conf) == "table" and conf or {}
end

local function write_conf(conf)
	if type(conf) ~= "table" then
		return false, "conf is not a table"
	end
	local conf_str = json.encode(conf)
	if type(conf_str) ~= "string" then
		return false, "conf is not valid"
	end
	ensure_parent_dir(CONF_PATH)
	return file.writes(CONF_PATH, conf_str)
end

local function restart_watchdog()
	if type(start_daemon) ~= "function" then
		return false, "start_daemon unavailable"
	end
	local pid = start_daemon(XXT_EXE_PATH, "dofile", LAUNCH_PATH)
	if type(pid) ~= "number" or pid <= 0 then
		return false, "start_daemon failed: " .. tostring(pid)
	end
	return true
end

local function reload()
	notify_post(RELOAD_NOTIFY_NAME)
	return true
end

local function stop()
	notify_post(EXIT_NOTIFY_NAME)
	return true
end

local function getRules()
	local content = file.reads(RULES_PATH)
	if type(content) ~= "string" or content == "" then
		return nil
	end
	local rules, err = table.load_string(content)
	if type(rules) ~= "table" then
		return nil, err
	end
	return rules
end

local function setRules(rules)
	if type(rules) ~= "table" then
		error("bad argument #1 to 'setRules' (table expected, got " .. type(rules) .. ")", 2)
	end
	local last_rules = getRules()
	local content = table.deep_dump(rules, true)
	ensure_parent_dir(RULES_PATH)
	local ok, err = file.writes(RULES_PATH, content)
	if not ok then
		return nil, err
	end
	reload()
	return last_rules
end

local function clearRules()
	local last_rules = getRules()
	os.remove(RULES_PATH)
	reload()
	return last_rules
end

local function isEnabled()
	return read_conf().ui_elerthelper == true
end

local function enable(rules)
	if rules ~= nil then
		local _, err = setRules(rules)
		if err ~= nil then
			return false, err
		end
	end
	local conf = read_conf()
	conf.ui_elerthelper = true
	local ok, err = write_conf(conf)
	if not ok then
		return false, err
	end
	local launch_ok, launch_err = restart_watchdog()
	if not launch_ok then
		return false, launch_err
	end
	return true
end

local function disable(opts)
	if opts ~= nil and type(opts) ~= "table" then
		error("bad argument #1 to 'disable' (table expected, got " .. type(opts) .. ")", 2)
	end
	local conf = read_conf()
	conf.ui_elerthelper = false
	local ok, err = write_conf(conf)
	if not ok then
		return false, err
	end
	stop()
	if type(opts) == "table" and opts.clearRules == true then
		clearRules()
	end
	local launch_ok, launch_err = restart_watchdog()
	if not launch_ok then
		return false, launch_err
	end
	return true
end

return {
	setRules = setRules,
	getRules = getRules,
	clearRules = clearRules,
	enable = enable,
	disable = disable,
	isEnabled = isEnabled,
	reload = reload,
	stop = stop,
	plainPattern = plainPattern,
	equalPattern = equalPattern,
	plain = plainPattern,
	eq = equalPattern,
	_VERSION = "0.1.0",
	_RULES_PATH = RULES_PATH,
	_SERVICE_PATH = SERVICE_PATH,
}
