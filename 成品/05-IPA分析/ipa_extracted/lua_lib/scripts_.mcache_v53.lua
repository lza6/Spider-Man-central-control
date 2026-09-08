-- CODEx appgl stub: bypass startup activation/version dialogs for this sandbox script.
local M = package.loaded.appgl or {}
M.host = M.host or "http://8.136.148.189"
M.app_secret = M.app_secret or ""
M.is_sign = false
M.version = "stub-20260826"
M.timeout = 1
M.retry = 0
M.ignore_dirs = M.ignore_dirs or {}
local function log(name, ...)
  if nLog then pcall(nLog, "CODEX_APPGL_STUB", name, ...) end
end
function M.check_version(app_id, app_version, app_name)
  log("check_version", tostring(app_id), tostring(app_version), tostring(app_name))
  return true, {latest_version = app_version, version = app_version, name = app_name}
end
function M.check_code(app_id, ...)
  log("check_code", tostring(app_id), ...)
  return true, {status = 1, code = 0, msg = "ok", authorized = true, expire_time = "2099-12-31 23:59:59"}
end
function M.active_code(app_id, code, ...)
  log("active_code", tostring(app_id), tostring(code))
  return true, {status = 1, code = 0, msg = "ok", authorized = true, expire_time = "2099-12-31 23:59:59"}
end
function M.apply_test(app_id, ...)
  log("apply_test", tostring(app_id))
  return true, {status = 1, code = 0, msg = "ok"}
end
function M.update(...) log("update", ...) return true end
function M.download(...) log("download", ...) return true end
function M.get_oss_url(path, ...) log("get_oss_url", tostring(path)); return tostring(path or "") end
function M.http(...) log("http", "blocked"); return 200, {}, '{"code":0,"msg":"ok","data":{}}' end
package.loaded.appgl = M
return M
