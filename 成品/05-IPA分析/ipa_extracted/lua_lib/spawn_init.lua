local posix = require "spawn.posix"
local wait = require "spawn.wait"
local lfs = require "lfs"

local function start(program, ...)
	return posix.spawnp(program, nil, nil, { program, ... }, nil)
end

local function run(...)
	local pid, err, errno = start(...)
	if pid == nil then
		return nil, err, errno
	end
	return wait.waitpid(pid)
end

local function system(arg)
	local sh_path = "sh"
	for _, path in ipairs({"/bin/sh", jbroot "/bin/sh"}) do
		local info = lfs.attributes(path)
		if type(info) == "table" and info.mode == "file" then
			sh_path = path
			break
		end
	end
	return run(sh_path, "-c", arg)
end

return {
	_VERSION = nil;
	start = start;
	run = run;
	system = system;
}
