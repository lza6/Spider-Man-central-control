--[[

	XXTEnv.lua

	Created by 苏泽 on 23-02-16.
	Copyright (c) 2023年 苏泽. All rights reserved.

	这个模块仅包含 XXT 的一些环境变量的初始化
	该模块仅作开发参考，请不要引用它

--]]

local lfs = require("lfs")

JB_ROOT_DIR = "/"

if jbroot then
	JB_ROOT_DIR = jbroot "/"
else
	if lfs.attributes('/var/jb/bin/sh') then
		JB_ROOT_DIR = "/var/jb/"
	end
end

IS_TROLLSTORE_EDITION = false
ROOT_USR_BIN_PATH = JB_ROOT_DIR .. "usr/bin"
SHELL_EXE_PATH = JB_ROOT_DIR .. "bin/sh"
XXT_EXPLORER_APP_PATH = JB_ROOT_DIR .. "Applications/XXTExplorer.app"
XXT_INTER_NAME = "1ferver"
XXT_SYSTEM_PATH = ROOT_USR_BIN_PATH .. "/" .. XXT_INTER_NAME
XXT_EXE_PATH = XXT_SYSTEM_PATH .. "/ReportCrash"
XXT_IPA_INSTALLER_PATH = XXT_SYSTEM_PATH .. "/1nstaller"
XXT_ADD1S_PATH = XXT_SYSTEM_PATH .. "/add1s"
XXT_HOME_PATH = JB_ROOT_DIR .. "var/mobile/Media/" .. XXT_INTER_NAME
XXT_CONF_FILE_NAME = XXT_HOME_PATH .. "/" .. XXT_INTER_NAME .. '.conf'
XXT_DAEMONS_PATH = XXT_HOME_PATH .. "/daemons"
XXT_UISERVICES_PATH = XXT_HOME_PATH .. "/uiservices"
XXT_BIN_PATH = XXT_HOME_PATH .. "/bin"
XXT_LUA_PATH = XXT_HOME_PATH .. "/lua"
XXT_LIB_PATH = XXT_HOME_PATH .. "/lib"
XXT_RES_PATH = XXT_HOME_PATH .. "/res"
XXT_CACHES_PATH = XXT_HOME_PATH .. "/caches"
XXT_WEB_PATH = XXT_HOME_PATH .. "/web"
XXT_LOG_PATH = XXT_HOME_PATH .. "/log"
XXT_CERT_PATH = XXT_HOME_PATH .. "/cert"
XXT_TESSDATA_PATH = XXT_HOME_PATH .. "/tessdata"
XXT_MODELS_PATH = XXT_HOME_PATH .. "/models"
XXT_SNIPPETS_PATH = XXT_HOME_PATH .. "/snippets"
XXT_SCRIPTS_PATH = XXT_HOME_PATH .. "/lua/scripts"
