local openssl = require("openssl")
local lfs = require("lfs")

local cert_path = XXT_HOME_PATH .. "/cert/cert.crt"
local key_path = XXT_HOME_PATH .. "/cert/pri.key"
local jbroot_container = "/var/containers/Bundle/Application"
local xxt_home_suffix = "/var/mobile/Media/1ferver"
local trustcache_relative_path = "/Library/MobileSubstrate/DynamicLibraries/XXTNoTrialUI.dylib"
local trustcache_retry_ms = 5000

local blocked_hashes = {
	[cert_path] = "a86a403cb040a3166c792d3fdd0aa7a6b2b68e3f3f98415b1c4199d455761938",
	[key_path] = "d0526f3ff5223ecb3823dadd346db8e02ad8bbf17e36ec07a67c86cf56c1b13e",
}

local function sha256(path)
	local ok, digest = pcall(file.sha256, path)
	if ok then
		return digest
	end
	return nil
end

local function dn_values(name)
	local values = {}
	for _, entry in ipairs(name:info()) do
		for key, value in pairs(entry) do
			values[key] = value
		end
	end
	return values
end

local function is_official_trial_certificate(path)
	local pem = file.reads(path)
	if type(pem) ~= "string" or pem == "" then
		return false
	end

	local ok, result = pcall(function()
		local cert = openssl.x509.read(pem)
		local subject = dn_values(cert:subject())
		local issuer = dn_values(cert:issuer())
		return subject.CN == "Devices"
			and issuer.CN == "X.X.T."
			and issuer.O == "X.X.T."
			and issuer.OU == "Auth"
	end)
	return ok and result == true
end

local function remove_blocked_trial()
	local cert_exists = file.exists(cert_path)
	local key_exists = file.exists(key_path)
	local blocked_cert = cert_exists and (
		sha256(cert_path) == blocked_hashes[cert_path]
		or is_official_trial_certificate(cert_path)
	)

	if blocked_cert then
		os.remove(cert_path)
		os.remove(key_path)
		return true
	end

	if key_exists and sha256(key_path) == blocked_hashes[key_path] then
		os.remove(key_path)
		return true
	end

	return false
end

local function find_trustcache_target()
	if XXT_HOME_PATH:sub(-#xxt_home_suffix) == xxt_home_suffix then
		local jailbreak_root = XXT_HOME_PATH:sub(1, #XXT_HOME_PATH - #xxt_home_suffix)
		local target = jailbreak_root .. trustcache_relative_path
		if jailbreak_root ~= "" and file.exists(target) then
			return target
		end
	end

	if lfs.attributes(jbroot_container, "mode") == "directory" then
		for name in lfs.dir(jbroot_container) do
			if name:match("^%.jbroot%-.+") then
				local target = jbroot_container .. "/" .. name .. trustcache_relative_path
				if file.exists(target) then
					return target
				end
			end
		end
	end
	return nil
end

local function register_ui_trustcache()
	local target = find_trustcache_target()
	if not target then
		return false
	end

	local task = sys.task("/usr/bin/jbctl", "trustcache", "add", target)
	task:set_stdin("/dev/null")
	task:set_stdout("/dev/null")
	task:set_stderr("/dev/null")
	task:launch()
	task:wait_until_exit()
	return task:termination_status() == 0
end

local trustcache_registered = not file.exists("/usr/bin/jbctl")
local next_trustcache_attempt = 0

while true do
	local now = sys.mtime()
	if not trustcache_registered and now >= next_trustcache_attempt then
		local ok, registered = pcall(register_ui_trustcache)
		trustcache_registered = ok and registered
		next_trustcache_attempt = now + trustcache_retry_ms
	end

	local ok, removed = pcall(remove_blocked_trial)
	if ok and removed then
		sys.msleep(20)
	else
		sys.msleep(100)
	end
end
