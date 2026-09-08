--[[

	alerthelper.lua

	Created by 苏泽 on 23-08-24.
	Copyright (c) 2023年 苏泽. All rights reserved.

	local alerthelper = require('alerthelper')

    -- 设置弹窗处理规则列表
	alerthelper.setRules(规则列表)

    -- 清空规则列表
    alerthelper.clearRules()

    -- 生成对应字符串中的所有字符都当作普通文字的匹配模式
    str = alerthelper.plainPattern(str)

    -- 生成对应字符串的完全相等匹配模式
    str = alerthelper.equalPattern(str)
	
	该模块无法在安全模式下正常工作
    弹窗匹配规则列表说明
	规则条件 (conditions)
		条件使用 and 匹配，即一条规则的所有条件都必须同时满足才能触发执行它的 actions
		匹配顺序是 bundleIdentifier > processName > parentClassName > className > source > title > message > cancelButton > preferredButton > buttons > textFields
		使用 lua 的模式匹配方式从对应的类名/标题/消息/按钮/文本框阴影文字中匹配
		如果不想使用模式匹配查找，则可使用 plainPattern 将模式转换成以普通字符搜索匹配
		如果需要字符串完全相等匹配，则可使用 equalPattern
	规则动作 (actions)
		动作中的文本不使用 lua 的模式匹配，必须完全一致
		执行顺序 textFields > clickButton > clickCancel > clickPreferred > log
		textFields 填充文本框，可以是文本或表，支持以下方式
			"填充文本1"
				则为填充第一个文本框的文本
			{["文本框阴影文字1"] = "填充文本1", ["文本框阴影文字2"] = "填充文本2"}
				填充对应 文本框阴影文字 的文本框的文本
			{"填充文本1", "填充文本2"}
				按顺序填充文本框
		clickButton 点击按钮，可以是按钮文本标题或数字序号
		clickCancel 点击取消按钮，设为 true 即可
		clickPreferred 点击首选按钮，设为 true 即可
		log 日志输出，设为 true 则使用默认日志输出，设为函数则将 alert 信息传递给该函数由函数决定输出方式
	匹配后继续 (continue)
		规则匹配是从上往下顺序匹配，默认是匹配到一个规则就执行该规则的动作，并且忽略掉之后的所有规则
		当匹配到了某个规则的 continue 为 true 时，会执行完该规则的动作后继续匹配下一个规则
	推迟执行动作 (wait)
		当弹窗条件被匹配后，等待指定的时间后再执行动作，单位为毫秒

    调用示例
        local alerthelper = require('alerthelper')
        local plainPattern = alerthelper.plainPattern
        local equalPattern = alerthelper.equalPattern

        alerthelper.setRules{
            {
                name = "脚本弹出的弹窗",
                conditions = {
                    parentClassName = equalPattern("SBUserNotificationAlert"),
                    source = equalPattern("ReportCrash"),
                },
            },
            {
                name = "推送权限请求弹窗",
                conditions = {
                    parentClassName = equalPattern("SBUserNotificationAlert"),
                    title = "想给.-发送通知",
                    message = "声音和图标标记",
                    buttons = {"不允许", "允许"}, -- buttons 是表则表示它的按钮数量必须对应，而且在对应的按钮的标题必须符合对应的模式
                },
                actions = {
                    clickButton = "允许",
                },
                continue = true, -- 这个规则匹配点了允许后，还会继续往下匹配
            },
            {
                name = "Safari 在别的应用打开",
                conditions = {
					bundleIdentifier = equalPattern("com.apple.mobilesafari"),
					className = "SFDialogController",
                    message = "在.-中打开",
                    buttons = "打开",
                },
                actions = {
                    clickButton = "打开",
                },
                wait = 100,
            },
        }

    以下是规则列表结构的一个模板，可拷贝到脚本中使用
--]]

local function plainPattern(str)
	return (str:gsub("([%^%$%(%)%%%.%[%]%*%+%-%?])", "%%%1"))
end

local function equalPattern(str)
	return "^" .. plainPattern(str) .. "$"
end

local rules = {
	{
		name = "脚本弹出的弹窗",
		conditions = {
			parentClassName = equalPattern("SBUserNotificationAlert"),
			source = equalPattern("ReportCrash"),
		},
	},
	{
		name = "推送权限请求弹窗",
		conditions = {
			parentClassName = equalPattern("SBUserNotificationAlert"),
			title = "想给.-发送通知",
			message = "声音和图标标记",
			buttons = { "不允许", "允许" }, -- buttons 是表则表示它的按钮数量必须对应，而且在对应的按钮的标题必须符合对应的模式
		},
		actions = {
			clickButton = "允许",
		},
		continue = true, -- 这个规则匹配点了允许后，还会继续往下匹配
	},
	{
		name = "英文版推送权限请求弹窗",
		conditions = {
			title = ".-Would Like to Send You Notifications",
			buttons = { "Don.-t Allow", "Allow" }, -- buttons 是表则表示它的按钮数量必须对应，而且在对应的按钮的标题必须符合对应的模式
		},
		actions = {
			clickButton = "Allow",
		},
	},
	{
		name = "Safari 在别的应用打开",
		conditions = {
			bundleIdentifier = equalPattern("com.apple.mobilesafari"),
			className = "SFDialogController",
			message = "在.-中打开",
			buttons = equalPattern("打开"),
		},
		actions = {
			clickButton = "打开",
		},
		wait = 100,
	},
	{
		name = "英文版 Safari 在别的应用打开",
		conditions = {
			bundleIdentifier = equalPattern("com.apple.mobilesafari"),
			className = "SFDialogController",
			message = "Open in .-",
			buttons = equalPattern("Open"),
		},
		actions = {
			clickButton = "Open",
		},
		wait = 100,
	},
	{
		conditions = {
			parentClassName = equalPattern("SBUserNotificationAlert"),
			title = equalPattern("Substitute - Request for Permission"),
			buttons = "^Always Allow$", -- buttons 是字符串表示它至少有一个按钮的标题符合该模式
		},
		actions = {
			clickButton = "Always Allow",
		},
	},
	{
		conditions = {
			source = equalPattern("itunesstored"),
			title = equalPattern("登录"),
			buttons = equalPattern("使用现有的 Apple ID"), -- buttons 是字符串表示它至少有一个按钮的标题符合该模式
		},
		actions = {
			clickButton = "使用现有的 Apple ID",
		},
	},
	{
		conditions = {
			source = equalPattern("itunesstored"),
			title = equalPattern("登录 iTunes Store"),
			buttons = equalPattern("好"), -- buttons 是字符串表示它至少有一个按钮的标题符合该模式
		},
		actions = {
			textFields = {
				"example@icloud.com",
				"password",
			},
			-- clickButton = "好",
		},
	},
	{
		conditions = {
			source = equalPattern("itunesstored"),
			title = equalPattern("验证 Apple ID"),
			buttons = equalPattern("以后"),
		},
		actions = {
			-- clickButton = "以后",
		},
	},
	{
		conditions = {
			source = equalPattern("locationd"),
			title = "使用.-的位置",
			buttons = equalPattern("允许一次"),
		},
		actions = {
			clickButton = "允许一次",
		},
	},
	{
		name = "删除 App 确认弹窗 1",
		conditions = {
			parentClassName = "^SB.-AppIconAlertItem$",
		},
		actions = function(alert)
			-- 啥也不干
		end,
	},
	{
		name = "删除 App 确认弹窗 2",
		conditions = {
			source = equalPattern("installcoordinationd"),
			title = "移除",
			buttons = equalPattern("从主屏幕移除"),
		},
	},
	{
		conditions = {
			source = equalPattern("pasted"), -- 来源是剪贴板服务
			cancelButton = ".-",    -- 有一个取消按钮，随便什么文字都行
			preferredButton = ".-", -- 有一个首选按钮，随便什么文字都行
		},
		actions = {
			clickCancel = true, -- 剪贴板弹窗的 允许粘贴 是 cancelButton
		},
	},
	{                    -- 所有未知的弹窗，不设 conditions，将无条件做出以下动作
		actions = {
			clickCancel = true, -- 点击取消按钮
			log = function(alert) -- 然后调用这个日志输出函数
				sys.log(tostring(alert))
				local f = io.open("/var/mobile/Media/1ferver/log/alerthelper.log", "a")
				if f then
					f:write(tostring(alert) .. "\n")
					f:close()
				end
			end,
		},
	},
}

-------------------------------------------------------------------------------------------------










-------------------------------------------------------------------------------------------------
-- 以下代码是 alerthelper 的主要逻辑实现，与脚本开发无关，无需将它们拷贝到自己的脚本中使用

local function alerthelper_matcher()
	local rules = rules
	local ALWAYS_TRUE = {}
	local NO_ACTIONS = {}

	local function _string_value(value)
		return (type(value) == "string" and value) or (type(value) == "number" and tostring(value)) or ""
	end

	local function compareConditions(rule, alert, conditions, parentClassName, className, source, title, message,
									 cancelButton, preferredButton, buttons, textFields)
		if conditions == ALWAYS_TRUE then
			return true
		end
		if type(conditions) == "function" then
			local done, ret = pcall(conditions, alert)
			if done then
				return ret
			else
				sys.log(string.format("rule[%q].conditions: %s", rule.name, tostring(ret)))
			end
		end
		if type(conditions.bundleIdentifier) == "string" then
			if not _string_value(alert.bundleIdentifier):find(conditions.bundleIdentifier) then
				return false
			end
		end
		if type(conditions.processName) == "string" then
			if not _string_value(alert.processName):find(conditions.processName) then
				return false
			end
		end
		if type(conditions.parentClassName) == "string" then
			if not _string_value(parentClassName):find(conditions.parentClassName) then
				return false
			end
		end
		if type(conditions.className) == "string" then
			if not _string_value(className):find(conditions.className) then
				return false
			end
		end
		if type(conditions.source) == "string" then
			if not _string_value(source):find(conditions.source) then
				return false
			end
		end
		if type(conditions.title) == "string" then
			if not _string_value(title):find(conditions.title) then
				return false
			end
		end
		if type(conditions.message) == "string" then
			if not _string_value(message):find(conditions.message) then
				return false
			end
		end
		if type(conditions.cancelButton) == "string" then
			if type(cancelButton) ~= "string" then
				return false
			end
			if not cancelButton:find(conditions.cancelButton) then
				return false
			end
		end
		if type(conditions.preferredButton) == "string" then
			if type(preferredButton) ~= "string" then
				return false
			end
			if not preferredButton:find(conditions.preferredButton) then
				return false
			end
		end
		if type(conditions.buttons) == "table" then
			if #(conditions.buttons) ~= #(buttons) then
				return false
			end
			for i, btn in ipairs(buttons) do
				if not _string_value(btn):find(tostring(conditions.buttons[i])) then
					return false
				end
			end
		elseif type(conditions.buttons) == "number" then
			if conditions.buttons ~= #(buttons) then
				return false
			end
		elseif type(conditions.buttons) == "string" then
			if not (function()
					for _, btn in ipairs(buttons) do
						if _string_value(btn):find(conditions.buttons) then
							return true
						end
					end
					return false
				end)() then
				return false
			end
		end
		if type(conditions.textFields) == "table" then
			if #(conditions.textFields) ~= #(textFields) then
				return false
			end
			for i, field in ipairs(textFields) do
				local placeholder = field.placeholder
				if not _string_value(placeholder):find(conditions.textFields[i]) then
					return false
				end
			end
		elseif type(conditions.textFields) == "number" then
			if conditions.textFields ~= #(textFields) then
				return false
			end
		elseif type(conditions.textFields) == "string" then
			if not (function()
					for _, field in ipairs(textFields) do
						local placeholder = field.placeholder
						if _string_value(placeholder):find(conditions.textFields) then
							return true
						end
					end
					return false
				end)() then
				return false
			end
		end
		return true
	end

	local function doActions(rule, actions, alert)
		if actions == NO_ACTIONS then
			return
		end
		if type(actions) == "function" then
			local done, ret = pcall(actions, alert)
			if done then
				return ret
			else
				sys.log(string.format("rule[%q].actions: %s", rule.name, tostring(ret)))
			end
		end
		if type(actions.textFields) == "table" or type(actions.textFields) == "string" then
			alert.textFields = actions.textFields
		end
		if type(actions.clickButton) == "string" or type(actions.clickButton) == "number" then
			alert:clickButton(actions.clickButton)
		end
		if actions.clickCancel then
			alert:clickCancel()
		end
		if actions.clickPreferred then
			alert:clickPreferred()
		end
		if type(actions.log) == "function" then
			actions.log(alert)
		elseif actions.log == true then
			sys.log(tostring(alert))
		end
	end

	local function matchDispose(alert, rules)
		local className = alert.className or ""
		local parentClassName = alert.parentClassName or ""
		local source = alert.source
		local title = alert.title
		local preferredButton = alert.preferredButton
		local cancelButton = alert.cancelButton
		local message = alert.message
		local buttons = alert.buttons or {}
		local textFields = alert.textFields or {}
		local count = 0
		for index, rule in ipairs(rules) do
			if type(rule) ~= "table" then
				rule = {}
			end
			rule.name = type(rule.name) == "string" and rule.name or index
			if (type(rule.conditions) ~= "table") and type(rule.actions) ~= "function" and (rule.conditions ~= false) then
				rule.conditions = ALWAYS_TRUE
			end
			if type(rule.actions) ~= "table" and type(rule.actions) ~= "function" then
				rule.actions = NO_ACTIONS
			end
			if compareConditions(rule, alert, rule.conditions, parentClassName, className, source, title, message, cancelButton, preferredButton, buttons, textFields) then
				if type(rule.wait) == "number" then
					rule.wait = math.tointeger(rule.wait) or 0
					if rule.wait < 0 then
						rule.wait = 0
					end
					dispatch_after(rule.wait, dispatch_get_main_queue(), function()
						doActions(rule, rule.actions, alert)
					end)
				else
					doActions(rule, rule.actions, alert)
				end
				count = count + 1
				if not rule.continue then
					return count
				end
			end
		end
		return count
	end

	--[[
        将配置文件 alerthelper.conf 到 [/var/jb]/Library/MobileSubstrate/DynamicLibraries/alerthelper.conf 位置

        修改完配置文件后在脚本中使用以下函数通知系统或者 App 重新加载 alerthelper 配置
        notify_post('xxtouch.alerthelper.reload')

        CatchTheAlert 函数说明
        系统弹窗后，alerthelper 会自动将弹窗信息传递给这个函数
        @param alert       弹窗句柄，可用于点击弹窗按钮，修改弹窗文本框内容等
        alert 参数的字段说明
        只读字段：
            alert.title               弹窗的标题，文本型
            alert.message             弹窗的内容，文本型
            alert.cancelButton        弹窗上的取消按钮的标题，文本型 或 nil
            alert.preferredButton     弹窗上的首选按钮的标题，文本型 或 nil
            alert.buttons             弹窗的按钮，数组型
            alert.textFields          弹窗的文本框，数组型
			alert.processName         弹窗的进程名称
			alert.bundleIdentifier    弹窗的进程的应用包名
            alert.className           弹窗的类名，可用于辅助识别弹窗类型
            alert.parentClassName     弹窗的父对象类名，可用于辅助识别弹窗类型
            alert.pointer             弹窗的指针，可用 objc.object(alert.pointer) 转换成一个 objc 对象以控制它
            alert.parent              弹窗的父对象指针，可用 objc.object(alert.parent) 转换成一个 objc 对象以控制它
            alert.source              弹窗的来源，文本型，可用于辅助识别弹窗类型
        方法字段：
            alert:clickButton(idx)    点击弹窗按钮方法
            alert:clickButton(name)   点击弹窗按钮方法
            alert:clickCancel()       点击弹窗取消按钮方法
            alert:clickPreferred()    点击弹窗首选按钮方法
        可写字段：
            alert.textFields = "name" 设置弹窗文本框第一个框里的内容
            alert.textFields = {"1", "2"} 设置弹窗文本框两个框里的内容
            alert.textFields = {objc.NULL, "2"} 如果仅仅要设置第二个框里的内容，可将第一个设为 objc.NULL 这个值
            alert.textFields = {["字段2"] = "1"} 设置指定 placeholder 文本框的内容
    --]]
	return function(alert)
		if alert.clickButton == nil then
			return
		end
		local done, ret = pcall(matchDispose, alert, rules)
		if done then
			if ret <= 0 then
				sys.log(string.format("alerthelper: Ignored Alert: %s", tostring(alert)))
			else
				sys.log(string.format("alerthelper: Matched Alert: %s", tostring(alert)))
			end
		else
			sys.log(string.format("alerthelper: matchDispose - Runtime Error: %s", tostring(ret)))
		end
	end
end

local function _getTweakDir()
	local lfs = require "lfs"
	for _, tweak_dir in ipairs({ jbroot "/Library/MobileSubstrate/DynamicLibraries", jbroot "/usr/lib/TweakInject" }) do
		local info = lfs.attributes(tweak_dir .. '/1feaks.dylib')
		if type(info) == "table" then
			return tweak_dir
		end
	end
	return nil
end

local function _plugBundleID(bid)
	local tweak_dir = _getTweakDir()
	if not tweak_dir then
		return false
	end
	local tweak_plist = tweak_dir .. "/1feaks.plist"
	local tweak_tab = plist.read(tweak_plist)
	if type(tweak_tab) ~= "table" then
		tweak_tab = {}
	end
	tweak_tab.Filter = type(tweak_tab.Filter) == "table" and tweak_tab.Filter or {}
	tweak_tab.Filter.Bundles = type(tweak_tab.Filter.Bundles) == "table" and tweak_tab.Filter.Bundles or {}
	local bundles = tweak_tab.Filter.Bundles
	for _, value in ipairs(bundles) do
		if value == bid then
			return true
		end
	end
	bundles[#bundles + 1] = bid
	plist.write(tweak_plist, tweak_tab)
	return true
end

local _check_value = functor.argth.check_value
local _cached_rules_fpath = jbroot "/var/mobile/Media/1ferver/caches/alerthelper.rules"
local _alerthelper_conf_filename = "alerthelper.conf"
local _alerthelper_conf_fpath_old = "/var/mobile/Library/Preferences/alerthelper.conf"
local _alerthelper_reload_notify_name = 'xxtouch.alerthelper.reload'

local function _getRules()
	local last_rules
	if file.exists(_cached_rules_fpath) then
		last_rules = table.load_string(file.reads(_cached_rules_fpath))
	end
	return last_rules
end

local function _setRules(...)
	local rules = _check_value(1, "table", ...)
	local rules_ctx = table.deep_dump(rules, true)
	local macher_ctx = string.dump(alerthelper_matcher):to_hex("\\x")
	os.remove(_alerthelper_conf_fpath_old)
	local conf_ctx = string.format([[
		local rules = %s
		local f = load("%s")
		debug.setupvalue(f, 1, rules)
		debug.setupvalue(f, 2, _ENV)
		CatchTheAlert = f()]], rules_ctx, macher_ctx)
	local tweak_dir = _getTweakDir()
	if not tweak_dir then
		return nil
	end
	file.writes(tweak_dir .. "/" .. _alerthelper_conf_filename, conf_ctx)
	local last_rules = _getRules()
	file.writes(_cached_rules_fpath, rules_ctx)
	_plugBundleID("com.apple.mobilesafari")
	_plugBundleID("com.apple.springboard")
	notify_post(_alerthelper_reload_notify_name)
	return last_rules
end

local function _clearRules()
	local tweak_dir = _getTweakDir()
	if not tweak_dir then
		return
	end
	local conf_ctx = string.dump(function() CatchTheAlert = function() end end, true)
	file.writes(tweak_dir .. "/" .. _alerthelper_conf_filename, conf_ctx)
	os.remove(_alerthelper_conf_fpath_old)
	notify_post(_alerthelper_reload_notify_name)
end

return {
	setRules = _setRules,
	getRules = _getRules,
	clearRules = _clearRules,
	equalPattern = equalPattern,
	plainPattern = plainPattern,
	_VERSION = "0.8.4",
}
