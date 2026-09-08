--[[

    开放式自定义 OpenAPI 接口

    兼容 XXTouchNG 接口实现

    本文件仅作为参考，请不要修改本文件
    本文件会在重装、更新时被原版覆盖
    如果要新增 OpenAPI 接口可参考本文件创建名为 custom-http-api.lua 的文件来实现
    例如可将自定义接口部分写在下面文件中
    /var/mobile/Media/1ferver/bin/custom-http-api.lua

--]]

local json = require('cjson.safe')
local lfs = require('lfs')
local noexecute = require('no_os_execute')
local archive = require('archive')
local posix = require('posix')
local path_manager = require('path')
local serpent = require('serpent')

local XXT_PKG_TYPE = XXT_PKG_TYPE

local function stringify(v, opt)
    opt = type(opt) == 'table' and opt or {}
    opt.comment = false
    opt.nocode = true
    return serpent.block(v, opt)
end

local function tar_extract(tar_path, to_path, uid, gid, mode)
    local arfh, err = io.open(tar_path, 'r')
    if not arfh then
        return false, err
    end
    if not to_path then
        to_path = path_manager.ensure_dir_end(path_manager.splitext(tar_path))
    end
    file.remove(to_path) -- 解包之前删除掉原来的目录
    sys.mkdir_p(to_path)
    uid = uid or 501
    gid = gid or 501
    mode = mode or 755
    local ar = archive.read {
        format = 'tar',
        reader = function(reader)
            return arfh:read(1024 * 1024)
        end,
    }
    for h in ar.next_header, ar do
        local fname = path_manager.basename(h:pathname())
        if not (fname == '.DS_Store' or fname:sub(1, 2) == '._') then
            local filepath = path_manager.join(to_path, h:pathname())
            if posix.S_ISDIR(h:mode()) == 1 then
                sys.mkdir_p(filepath)
            else
                local dir = path_manager.dirname(filepath)
                if not path_manager.isdir(dir) then
                    sys.mkdir_p(dir)
                end
                local f, err = io.open(filepath, 'w')
                if not f then
                    return false, err
                end
                for s in ar.data, ar do
                    f:write(s)
                end
                f:close()
            end
        end
    end
    noexecute.lchownmod_r(to_path, uid, gid, mode)
    return true, to_path
end

function file_lastline(filename, last)
    last = tonumber(last) or 1
    last = math.floor(last)
    last = (last > 0 and last) or 1
    local f = io.open(filename, 'r')
    if not f then
        return ''
    end

    local size = f:seek('end')
    if not size or size <= 0 then
        f:close()
        return ''
    end

    local pos = size
    f:seek('end', -1)
    local last_char = f:read(1)
    if last_char == '\n' then
        pos = size - 1
    end

    local buf = ''
    local newline_count = 0
    local chunk_size = 4096

    while pos > 0 and newline_count < last do
        local read_size = chunk_size
        if pos < read_size then
            read_size = pos
        end
        pos = pos - read_size
        f:seek('set', pos)
        local chunk = f:read(read_size)
        if not chunk or chunk == '' then
            break
        end
        buf = chunk .. buf
        for i = 1, #chunk do
            if chunk:byte(i) == 10 then
                newline_count = newline_count + 1
            end
        end
    end
    f:close()

    if buf == '' then
        return ''
    end

    local lines_rev = {}
    local line_end = #buf
    local count = 0
    for i = #buf, 1, -1 do
        if buf:byte(i) == 10 then
            lines_rev[#lines_rev + 1] = buf:sub(i + 1, line_end)
            line_end = i - 1
            count = count + 1
            if count >= last then
                break
            end
        end
    end
    if count < last then
        if line_end >= 1 then
            lines_rev[#lines_rev + 1] = buf:sub(1, line_end)
        else
            lines_rev[#lines_rev + 1] = ''
        end
    end

    if last == 1 then
        return lines_rev[#lines_rev] or ''
    end

    local lines = {}
    for i = #lines_rev, 1, -1 do
        lines[#lines + 1] = lines_rev[i]
    end
    return table.concat(lines, '\r\n')
end

if not lua_is_running then
    function lua_is_running()
        local c, h, r = xxtouch.post('/is_running')
        if c == 200 then
            return (json.decode(r) or { code = 0 }).code ~= 0
        else
            return false
        end
    end
end

if not is_script_paused then
    function is_script_paused()
        local c, _, r = xxtouch.post('/is_script_paused')
        if c == 200 then
            r = json.decode(r) or { data = { is_script_paused = false } }
            return r.data.is_script_paused
        else
            return false
        end
    end
end

if not get_selected_script_file then
    function get_selected_script_file()
        local c, _, r = xxtouch.post('/get_selected_script_file')
        if c ~= 200 then
            return nil
        end
        r = json.decode(r)
        if type(r) == 'table' and r.code == 0 then
            return r.data.filename
        end
        return nil
    end
end

if not select_script_file then
    function select_script_file(filename)
        local c, _, r = xxtouch.post('/select_script_file', '', json.encode { filename = filename })
        if c ~= 200 then
            return false
        end
        r = json.decode(r)
        if type(r) == 'table' and r.code == 0 then
            return true
        end
        return false
    end
end

local function _error_message(ctx, code, msg)
    ctx.status = code
    ctx:header('Content-type', 'application/json; charset=utf-8')
    -- sys.log(string.format([[{"code": %d, "message": %q}]], code, tostring(msg)).." "..json.encode({uri = ctx.uri, method = ctx.request_method, headers = ctx.http_headers, query = ctx.query}))
    return string.format([[{"code": %d, "message": %q}]], code, tostring(msg))
end

local _internal_error_message = _error_message
local _request_error_message = _error_message

local function _sh_escape(path)
    if jbroot('/rootfs') == '/' then
        path = rootfs(path)
    end
    path = string.gsub(path, "([ \\()<>'\"`#&*;?~$|])", "\\%1")
    return path
end

local function _read_conf()
    local conf = json.decode(file.reads(XXT_CONF_FILE_NAME) or "")
    conf = (type(conf) == 'table') and conf or {}
    return conf
end

local function _write_conf(conf)
    if type(conf) ~= 'table' then
        return false, "conf is not a table"
    end
    local conf_str = json.encode(conf)
    if type(conf_str) ~= 'string' then
        return false, "conf is not valid"
    end
    return file.writes(XXT_CONF_FILE_NAME, conf_str)
end

local function _number_range(num, min, max, default)
    default = tonumber(default) or 0
    num = tonumber(num) or default
    num = (num <= max) and num or max
    num = (num >= min) and num or min
    return num
end

local nLog_imp_str = [[
do
    local select = select
    local table = {deep_dump = table.deep_dump, concat = table.concat}
    local sys = {log = sys.log}
    local os = {date = os.date}
    local debug = {getinfo = debug.getinfo}
    local string = {gsub = string.gsub}
    local tostring = tostring
    local print = print
    local type = type
    function nLog(...)
        local outt = {}
        local argc = select("#", ...)
        if argc > 0 then
            for i = 1, argc do
                local arg = select(i, ...)
                if type(arg) == "table" then
                    outt[#outt + 1] = table.deep_dump(arg)
                else
                    local s = tostring(arg)
                    s = string.gsub(s, "%[DATE%]", os.date("[%Y-%m-%d %H:%M:%S]"))
                    s = string.gsub(s, "%[LINE%]", "["..tostring(debug.getinfo(2).currentline).."]")
                    outt[#outt + 1] = s
                end
            end
            sys.log(table.concat(outt, '\t'))
        end
    end
end
]]

nLog_imp_str = nLog_imp_str:gsub("\r", ""):gsub("\n", ";")

local proc_operations = dofile(XXT_BIN_PATH .. '/module-proc-operations.lua')
local proc_value_operations = proc_operations.proc_value_operations
local proc_queue_operations = proc_operations.proc_queue_operations
local proc_dict_operations = proc_operations.proc_dict_operations

local encript = dofile(XXT_BIN_PATH .. '/module-encript.lua')
local touch_drag = dofile(XXT_BIN_PATH .. '/module-touch-drag.lua')

local function _body_boolean(value)
    if value == nil then
        return nil
    elseif type(value) == 'boolean' then
        return value
    elseif type(value) == 'number' then
        if value == 1 then
            return true
        elseif value == 0 then
            return false
        end
    elseif type(value) == 'string' then
        local lower = value:lower()
        if lower == 'true' or lower == '1' then
            return true
        elseif lower == 'false' or lower == '0' then
            return false
        end
    end
    return nil
end

local function _body_number_range(body, key, min_value)
    if body[key] == nil then
        return nil, true
    end
    local value = tonumber(body[key])
    if not value or value < min_value then
        return nil, false
    end
    return value, true
end

local function _body_number_range_alias(body, keys, min_value)
    for _, key in ipairs(keys) do
        if body[key] ~= nil then
            local value = tonumber(body[key])
            if not value or value < min_value then
                return nil, false
            end
            return value, true
        end
    end
    return nil, true
end

local function _body_boolean_alias(body, keys)
    for _, key in ipairs(keys) do
        if body[key] ~= nil then
            local value = _body_boolean(body[key])
            if value == nil then
                return nil, false
            end
            return value, true
        end
    end
    return nil, true
end

local _WHEEL_NUMBER_PARAMS = {
    {'step_px',           {'stepPx'},                         0},
    {'coalesce_ms',       {'coalesceMs'},                     0},
    {'amp',               {'amp'},                            0},
    {'dur_base_ms',       {'durBaseMs', 'durationBaseMs'},    0},
    {'release_delay_ms',  {'releaseDelayMs'},                 0},
    {'brake_reverse_px',  {'brakeReversePx'},                 0},
    {'amp_cap',           {'cap'},                            0},
    {'min_take_ratio',    {'minRatio'},                       0},
    {'max_step_px',       {'maxPx'},                          0},
    {'abs_clamp_factor',  {'clampFactor'},                    0},
    {'duration_scale_ms', {'durationScaleMs'},                0},
    {'duration_min_ms',   {'durationMinMs'},                  0},
    {'duration_max_ms',   {'durationMaxMs'},                  0},
}

local function _body_wheel_options(body)
    local natural, ok = _body_boolean_alias(body, {'natural'})
    if not ok then
        return nil
    end

    local brake_enabled, ok2 = _body_boolean_alias(body, {'brakeEnabled'})
    if not ok2 then
        return nil
    end

    local axis = nil
    if body.axis ~= nil then
        if body.axis == 'x' or body.axis == 'horizontal' then
            axis = 'x'
        elseif body.axis == 'y' or body.axis == 'vertical' then
            axis = 'y'
        else
            return nil
        end
    end

    local result = {}
    result.axis = axis
    result.natural = natural
    result.brake_enabled = brake_enabled
    for _, param in ipairs(_WHEEL_NUMBER_PARAMS) do
        local name, keys, min_value = param[1], param[2], param[3]
        local value, valid = _body_number_range_alias(body, keys, min_value)
        if not valid then
            return nil
        end
        result[name] = value
    end
    return result
end

local function _decode_request_body(ctx)
    local body = json.decode(ctx.content)
    return type(body) == 'table' and body or {}
end

local function _touch_method_not_allowed(ctx)
    return _request_error_message(ctx, 405,
        string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
end

local function _touch_argument_error(ctx)
    return _request_error_message(ctx, 400, string.format('%s: operation failed: argument error', ctx.uri))
end

local function _send_empty_text_response(ctx, status)
    ctx.status = status
    ctx:header('Content-type', 'text/plain; charset=utf-8')
    return ''
end

local function _parse_touch_point_body(body)
    return {
        finger = math.floor(tonumber(body.finger) or 1),
        x = math.floor(tonumber(body.x) or -1),
        y = math.floor(tonumber(body.y) or -1),
    }
end

local function _is_valid_finger(finger)
    return finger >= 0 and finger <= 29
end

local function _is_valid_point(x, y)
    return x >= 0 and y >= 0
end

local function _parse_drag_linear_body(body)
    local duration = tonumber(body.duration)
    return {
        finger = math.floor(tonumber(body.finger) or 1),
        x0 = math.floor(tonumber(body.x0) or -1),
        y0 = math.floor(tonumber(body.y0) or -1),
        x1 = math.floor(tonumber(body.x1) or -1),
        y1 = math.floor(tonumber(body.y1) or -1),
        duration = (duration and duration >= 0) and duration or 50,
    }
end

local function _parse_curve_control_point(body)
    local control_point = type(body.controlPoint) == 'table' and body.controlPoint or nil
    local curve_type = nil
    local cp1x, cp1y, cp2x, cp2y
    if control_point then
        local control_x1 = tonumber(control_point[1])
        local control_y1 = tonumber(control_point[2])
        local control_x2 = tonumber(control_point[3])
        local control_y2 = tonumber(control_point[4])
        if control_x1 and control_y1 and control_x2 and control_y2 then
            curve_type = 'cubic'
            cp1x = math.floor(control_x1)
            cp1y = math.floor(control_y1)
            cp2x = math.floor(control_x2)
            cp2y = math.floor(control_y2)
        elseif control_x1 and control_y1 then
            curve_type = 'quadratic'
            cp1x = math.floor(control_x1)
            cp1y = math.floor(control_y1)
        end
    else
        local body_c1x = tonumber(body.c1x)
        local body_c1y = tonumber(body.c1y)
        local body_c2x = tonumber(body.c2x)
        local body_c2y = tonumber(body.c2y)
        local body_cx = tonumber(body.cx)
        local body_cy = tonumber(body.cy)

        if body_c1x and body_c1y and body_c2x and body_c2y then
        curve_type = 'cubic'
            cp1x = math.floor(body_c1x)
            cp1y = math.floor(body_c1y)
            cp2x = math.floor(body_c2x)
            cp2y = math.floor(body_c2y)
        elseif body_cx and body_cy then
            curve_type = 'quadratic'
            cp1x = math.floor(body_cx)
            cp1y = math.floor(body_cy)
        end
    end
    return curve_type, cp1x, cp1y, cp2x, cp2y
end

local function _parse_drag_curve_body(body)
    local duration = tonumber(body.duration)
    local curve_type, cp1x, cp1y, cp2x, cp2y = _parse_curve_control_point(body)
    return {
        finger = math.floor(tonumber(body.finger) or 1),
        x0 = math.floor(tonumber(body.x0) or -1),
        y0 = math.floor(tonumber(body.y0) or -1),
        x1 = math.floor(tonumber(body.x1) or -1),
        y1 = math.floor(tonumber(body.y1) or -1),
        duration = (duration and duration >= 0) and duration or 50,
        step_len = tonumber(body.stepLen),
        step_delay = tonumber(body.stepDelay),
        off_delay = tonumber(body.offDelay),
        curve_type = curve_type,
        cp1x = cp1x,
        cp1y = cp1y,
        cp2x = cp2x,
        cp2y = cp2y,
    }
end

local function _is_valid_drag_curve_request(request)
    if not (_is_valid_finger(request.finger) and
        _is_valid_point(request.x0, request.y0) and
        _is_valid_point(request.x1, request.y1)) then
        return false
    end
    if request.step_len and request.step_len <= 0 then
        return false
    end
    if request.step_delay and request.step_delay < 0 then
        return false
    end
    if request.off_delay and request.off_delay < 0 then
        return false
    end
    return true
end

local function _parse_wheel_body(body)
    local delta_x = tonumber(body.deltaX)
    local delta_y = tonumber(body.deltaY)
    local delta = tonumber(body.delta)
    return {
        finger = math.floor(tonumber(body.finger) or 29),
        x = math.floor(tonumber(body.x) or -1),
        y = math.floor(tonumber(body.y) or -1),
        delta_spec = {
            delta = delta,
            deltaX = delta_x,
            deltaY = delta_y,
        },
        has_delta = delta ~= nil or delta_x ~= nil or delta_y ~= nil,
        options = _body_wheel_options(body),
    }
end

local function _handle_touch_point_request(ctx, handler)
    if ctx.request_method ~= 'POST' then
        return _touch_method_not_allowed(ctx)
    end
    local request = _parse_touch_point_body(_decode_request_body(ctx))
    if not (_is_valid_finger(request.finger) and _is_valid_point(request.x, request.y)) then
        return _touch_argument_error(ctx)
    end
    handler(request)
    return _send_empty_text_response(ctx, 204)
end

local function _handle_touch_up_request(ctx)
    if ctx.request_method ~= 'POST' then
        return _touch_method_not_allowed(ctx)
    end
    local request = _decode_request_body(ctx)
    local finger = math.floor(tonumber(request.finger) or 1)
    if not _is_valid_finger(finger) then
        return _touch_argument_error(ctx)
    end
    touch.up(finger)
    return _send_empty_text_response(ctx, 204)
end

local function _handle_drag_linear_request(ctx, drag_handler, status)
    if ctx.request_method ~= 'POST' then
        return _touch_method_not_allowed(ctx)
    end
    local request = _parse_drag_linear_body(_decode_request_body(ctx))
    if not (_is_valid_finger(request.finger) and
        _is_valid_point(request.x0, request.y0) and
        _is_valid_point(request.x1, request.y1)) then
        return _touch_argument_error(ctx)
    end
    drag_handler(request.finger, request.x0, request.y0, request.x1, request.y1, request.duration)
    return _send_empty_text_response(ctx, status)
end

local function _handle_drag_curve_request(ctx, drag_handler, status)
    if ctx.request_method ~= 'POST' then
        return _touch_method_not_allowed(ctx)
    end
    local request = _parse_drag_curve_body(_decode_request_body(ctx))
    if not _is_valid_drag_curve_request(request) then
        return _touch_argument_error(ctx)
    end
    drag_handler(request)
    return _send_empty_text_response(ctx, status)
end

local function _handle_wheel_request(ctx, wheel_handler, status)
    if ctx.request_method ~= 'POST' then
        return _touch_method_not_allowed(ctx)
    end
    local request = _parse_wheel_body(_decode_request_body(ctx))
    if not (request.options and _is_valid_finger(request.finger) and _is_valid_point(request.x, request.y) and request.has_delta) then
        return _touch_argument_error(ctx)
    end
    wheel_handler(request.finger, request.x, request.y, request.delta_spec, request.options)
    return _send_empty_text_response(ctx, status)
end

local _http_uri_router_table = {
    -- 兼容截图接口
    ['/api/screen/snapshot'] = function(ctx)
        if ctx.request_method ~= 'GET' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx.status = 200
        local scr_w, scr_h = screen.size()
        local scale = _number_range(ctx.query['scale'], 1, 300, 100)
        local ltx = _number_range(ctx.query['ltx'], 0, scr_w - 1)
        local lty = _number_range(ctx.query['lty'], 0, scr_h - 1)
        local rbx = _number_range(ctx.query['rbx'], 0, scr_w - 1, scr_w - 1)
        local rby = _number_range(ctx.query['rby'], 0, scr_h - 1, scr_h - 1)
        local format = ctx.query['format'] or 'png'
        local function image_data_with_format(img, format)
            if format == 'jpg' or format == 'jpeg' then
                ctx:header('Content-type', 'image/jpeg')
                return img:jpeg_data()
            else
                ctx:header('Content-type', 'image/png')
                return img:png_data()
            end
        end
        if scale == 100 then
            if ltx == 0 and lty == 0 and rbx == 0 and rby == 0 then
                return image_data_with_format(screen.image(), format)
            else
                return image_data_with_format(screen.image(ltx, lty, rbx, rby), format)
            end
        else
            local zoom = scale / 100
            local img
            if ltx == 0 and lty == 0 and rbx == 0 and rby == 0 then
                img = screen.image()
            else
                img = screen.image(ltx, lty, rbx, rby)
            end
            local w, h = img:size()
            require('image.cv')
            return image_data_with_format(img:cv_resize(math.floor(w * zoom), math.floor(h * zoom)), format)
        end
    end,
    ['/api/config'] = function(ctx)
        -- 协议参考
        -- {
        --     "cloud": {
        --         "enable": true,
        --         "address": "ws://192.168.1.100:3000"
        --     },
        --     "notify_stop": false
        -- }
        ctx:header('Content-Type', 'application/json; charset=utf-8')
        if ctx.request_method == 'PUT' then
            ctx.status = 204
            local api_conf = json.decode(ctx.content)
            if type(api_conf) == 'table' then
                local conf = _read_conf()
                if type(api_conf.notify_stop) == 'boolean' then
                    conf.script_end_hint = api_conf.notify_stop
                end
                if type(api_conf.cloud) == 'table' and type(api_conf.cloud.enable) == 'boolean' and type(api_conf.cloud.address) == 'string' then
                    conf.open_cloud_control = api_conf.cloud
                end
                _write_conf(conf)
                noexecute.run_cmd(XXT_EXE_PATH, "dofile", XXT_BIN_PATH .. "/launch.lua")
            end
            return ''
        elseif ctx.request_method == 'GET' then
            ctx.status = 200
            local conf = _read_conf()
            local api_conf = {}
            api_conf.notify_stop = conf.script_end_hint
            api_conf.cloud = type(conf.open_cloud_control) == 'table' and conf.open_cloud_control or
            { enable = false, address = 'ws://127.0.0.1:8888' }
            return json.encode(api_conf)
        end
        return _request_error_message(ctx, 405,
            string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
    end,
    ['/api/system/log'] = function(ctx)
        ctx:header('Content-Type', 'text/html; charset=utf-8')
        if ctx.request_method == 'DELETE' then
            ctx.status = 204
            noexecute.rm_rf(XXT_LOG_PATH .. '/sys.log')
            return ''
        elseif ctx.request_method == 'GET' then
            ctx.status = 200
            local log = file_lastline(XXT_LOG_PATH .. '/sys.log', ctx.query['last'])
            return log
        end
        return _request_error_message(ctx, 405,
            string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
    end,
    ['/api/system/respring'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-Type', 'text/html; charset=utf-8')
        ctx.status = 204
        if get_openapi_func then
            get_openapi_func('/respring')(ctx)
        else
            xxtouch.post('/respring', '', '')
        end
        return ''
    end,
    ['/api/system/reboot'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-Type', 'text/html; charset=utf-8')
        ctx.status = 204
        local hard = false
        local h = ctx.query and ctx.query['hard']
        if h == true or h == 1 or h == '1' or h == 'true' or h == 'yes' then
            hard = true
        end
        if get_openapi_func then
            get_openapi_func('/reboot2')(ctx)
        else
            if hard then
                xxtouch.post('/reboot2?hard=1', '', '')
            else
                xxtouch.post('/reboot2', '', '')
            end
        end
        return ''
    end,
    ['/api/script'] = function(ctx)
        if ctx.request_method ~= 'GET' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx.status = 200
        ctx:header('Content-type', 'application/json; charset=utf-8')
        local retlist = {}
        for name in lfs.dir(XXT_SCRIPTS_PATH) do
            if string.match(name, '.+%.lua') or string.match(name, '.+%.xxt') or string.match(name, '.+%.xpp') --[[or string.match(name, '.+%.tep')]] then
                retlist[#retlist + 1] = name
            end
        end
        return json.encode(retlist)
    end,
    ['/api/app/state'] = function(ctx)
        if ctx.request_method ~= 'GET' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx.status = 200
        ctx:header('Content-type', 'application/json; charset=utf-8')
        local wifi_ip = "127.0.0.1"
        for i, v in ipairs(device.ifaddrs()) do
            if #tostring(v[1]) > 2 and tostring(v[1]):sub(1, 2) == "en" then
                wifi_ip = v[2]
                if tostring(v[1]) == "en0" then
                    break
                end
            end
        end
        get_current_device_expire_time = get_current_device_expire_time or function()
            local ret
            if not get_openapi_func then
                local c, h
                c, h, ret = xxtouch.post('/api/licence/expire-date', '', '')
            else
                ret = get_openapi_func('/api/licence/expire-date')({ header = function(obj, item) end })
            end
            ret = json.decode(ret) or {
                data = { expireDate = 0 }
            }
            return ret.data.expireDate
        end
        local w, h = screen.size()
        local license = "已过期"
        local ets = get_current_device_expire_time()
        if ets and ets > os.time() then
            license = os.date("%Y-%m-%d %H:%M:%S", ets)
        end
        return json.encode {
            app = {
                version = sys.zeversion(),
                license = license,
                pkgtype = XXT_PKG_TYPE,
            },
            script = {
                select = get_selected_script_file() or '',
                running = lua_is_running(),
                paused = is_script_paused(),
            },
            system = {
                scrw = w,
                scrh = h,
                os = 'ios',
                name = device.name(),
                sn = device.serial_number(),
                ndid = string.format("%08X-%016X", sys.MGCopyAnswer('ChipID'), sys.MGCopyAnswer('UniqueChipID')),
                udid = device.udid(),
                version = sys.version(),
                ip = wifi_ip,
                battery = device.battery_level(),
                is_locked = device.is_screen_locked(),
                log = file_lastline(XXT_LOG_PATH .. '/sys.log'),
            }
        }
    end,
    ['/api/app/register'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'text/plain; charset=utf-8')
        local body = json.decode(ctx.content)
        if type(body) ~= 'table' or type(body.code) ~= 'string' or body.code == '' then
            return _request_error_message(ctx, 400, 'argument error.')
        end
        local ret = ''
        if not get_openapi_func then
            local c, h
            c, h, ret = xxtouch.post('/bind_code', '', body.code)
            if c ~= 200 then
                return _request_error_message(ctx, 400, 'connection failed.')
            end
        else
            local fakectx = {}
            local ctxmeta = getmetatable(ctx)
            setmetatable(fakectx, {
                __index = function(obj, name)
                    if name == 'content' then
                        return body.code
                    elseif name == 'header' then
                        return function(obj, item) --[[return ctx:header(item)]] end
                    end
                    return ctxmeta.__index(ctx, name)
                end,
                __newindex = function(obj, name, value)
                    return ctxmeta.__newindex(ctx, name, value)
                end,
            })
            ret = get_openapi_func('/bind_code')(fakectx)
        end
        local t = json.decode(ret)
        if type(t) ~= 'table' or type(t.code) ~= 'number' then
            return _request_error_message(ctx, 400, 'unknown error.')
        end
        if t.code ~= 0 then
            return _request_error_message(ctx, 400, t.message)
        end
        ctx.status = 204
        return ''
    end,
    ['/api/script/selected'] = function(ctx)
        if ctx.request_method == 'GET' then
            local filename = get_selected_script_file()
            if filename then
                ctx.status = 200
                ctx:header('Content-type', 'text/plain; charset=utf-8')
                return filename
            end
            return _request_error_message(ctx, 404, string.format('%s: operation failed: configuration error', ctx.uri))
        elseif ctx.request_method == 'PUT' then
            local body = ctx.content
            local filename = XXT_SCRIPTS_PATH .. '/' .. body
            if not lfs.attributes(filename) then
                if lfs.attributes(body) then
                    filename = body
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: operation failed: script `%s` not found', ctx.uri, body))
                end
            end
            local ok = select_script_file(filename)
            if ok then
                ctx.status = 204
                ctx:header('Content-type', 'text/plain; charset=utf-8')
                return ''
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: configuration error', ctx.uri))
            end
        else
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
    end,
    ['/api/script/run'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'text/plain; charset=utf-8')
        if not get_openapi_func then
            local c, h, r = xxtouch.post('/launch_script_file')
            ctx.status = 204
            return ''
        else
            local ret = get_openapi_func('/launch_script_file')(ctx)
            ctx.status = 204
            return ''
        end
    end,
    ['/api/script/stop'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'text/plain; charset=utf-8')
        if not get_openapi_func then
            local c, h, r = xxtouch.post('/stop_script')
            ctx.status = 204
            return ''
        else
            local ret = get_openapi_func('/stop_script')(ctx)
            ctx.status = 204
            return ''
        end
    end,
    ['/api/script/pause'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'text/plain; charset=utf-8')
        if not get_openapi_func then
            local c, h, r = xxtouch.post('/pause_script')
            ctx.status = 204
            return ''
        else
            local ret = get_openapi_func('/pause_script')(ctx)
            ctx.status = 204
            return ''
        end
    end,
    ['/api/script/resume'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'text/plain; charset=utf-8')
        if not get_openapi_func then
            local c, h, r = xxtouch.post('/resume_script')
            ctx.status = 204
            return ''
        else
            local ret = get_openapi_func('/resume_script')(ctx)
            ctx.status = 204
            return ''
        end
    end,
    ['/api/file/move'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        if type(body.from) ~= 'string' or type(body.to) ~= 'string' then
            return _request_error_message(ctx, 400, 'argument error.')
        end
        body.from = body.from:trim()
        body.to = body.to:trim()
        if body.from == '' or body.to == '' then
            return _request_error_message(ctx, 400, 'argument error.')
        end
        body.from = XXT_HOME_PATH .. "/" .. body.from
        body.to = XXT_HOME_PATH .. "/" .. body.to
        local ok, err = file.move(body.from, body.to)
        if not ok then
            return _request_error_message(ctx, 400, err)
        end
        ctx.status = 204
        return ''
    end,
    ['/api/file/copy'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        if type(body.from) ~= 'string' or type(body.to) ~= 'string' then
            return _request_error_message(ctx, 400, 'argument error.')
        end
        body.from = body.from:trim()
        body.to = body.to:trim()
        if body.from == '' or body.to == '' then
            return _request_error_message(ctx, 400, 'argument error.')
        end
        body.from = XXT_HOME_PATH .. "/" .. body.from
        body.to = XXT_HOME_PATH .. "/" .. body.to
        local ok, err = file.copy(body.from, body.to)
        if not ok then
            return _request_error_message(ctx, 400, err)
        end
        ctx.status = 204
        return ''
    end,
    ['/api/file'] = function(ctx)
        if ctx.request_method == 'GET' then
            local path = ctx.query['path']
            path = type(path) == 'string' and path or '/'
            path = path:trim()
            path = XXT_HOME_PATH .. "/" .. path
            if lfs.attributes(path, 'mode') == 'directory' then
                local retlist = {}
                setmetatable(retlist, json.array_mt)
                for name in lfs.dir(path) do
                    if name ~= '.' and name ~= '..' then
                        local finfo = lfs.attributes(path .. '/' .. name)
                        if type(finfo) == 'table' then
                            finfo.name = name
                            if finfo.mode == 'directory' then
                                finfo.type = 'dir'
                            else
                                finfo.type = 'file'
                            end
                            retlist[#retlist + 1] = finfo
                        end
                    end
                end
                table.sort(retlist, function(a, b)
                    if a.type == 'dir' and b.type == 'file' then
                        return true
                    elseif a.type == 'file' and b.type == 'dir' then
                        return false
                    end
                    return a.name < b.name
                end)
                ctx.status = 200
                ctx:header('Content-type', 'application/json; charset=utf-8')
                return json.encode(retlist)
            else
                local f, errmsg = io.open(path, 'r')
                if f then
                    local s = f:read('*a')
                    f:close()
                    ctx.status = 200
                    ctx:header('Content-type', 'application/octet-stream')
                    if ctx.query['md5'] then
                        ctx:header('Content-MD5', s:md5():from_hex():base64_encode())
                    end
                    return s
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: %s can not open file %q %s', ctx.uri, ctx.request_method, path, errmsg))
                end
            end
        elseif ctx.request_method == 'DELETE' then
            ctx.status = 204
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            local path = ctx.query['path']
            path = type(path) == 'string' and path or ''
            path = path:trim()
            if path == '' or path == '/' then
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s %q', ctx.uri, ctx.request_method, 'invalid path', path))
            end
            path = XXT_HOME_PATH .. "/" .. path
            if lfs.attributes(path, 'mode') then
                noexecute.rm_rf(path)
                return ''
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s %q', ctx.uri, ctx.request_method, 'invalid path', path))
            end
        elseif ctx.request_method == 'PUT' then
            ctx.status = 204
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            local path = ctx.query['path']
            path = type(path) == 'string' and path or ''
            path = path:trim()
            if path == '' or path == '/' then
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s %q', ctx.uri, ctx.request_method, 'invalid path', path))
            end
            path = XXT_HOME_PATH .. "/" .. path
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s %q', ctx.uri, ctx.request_method, 'invalid path', path))
            end
            if not ctx.query['directory'] then
                local dir = path_manager.dirname(path)
                if dir and dir ~= '' then
                    sys.mkdir_p(dir)
                end
                local f, errmsg = io.open(path, 'w')
                if f then
                    f:write(ctx.content)
                    f:close()
                    sys.lchown(path, 501, 501)
                    return ''
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: operation failed: %s %q %s', ctx.uri, ctx.request_method, path, errmsg))
                end
            else
                sys.mkdir_p(path)
                sys.lchown(path, 501, 501)
                return ''
            end
        end
        return _internal_error_message(ctx, 400,
            string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
    end,
    ['/api/touch/down'] = function(ctx)
        return _handle_touch_point_request(ctx, function(request)
            touch.down(request.finger, request.x, request.y)
        end)
    end,
    ['/api/touch/move'] = function(ctx)
        return _handle_touch_point_request(ctx, function(request)
            touch.move(request.finger, request.x, request.y)
        end)
    end,
    ['/api/touch/up'] = function(ctx)
        return _handle_touch_up_request(ctx)
    end,
    ['/api/touch/tap'] = function(ctx)
        return _handle_touch_point_request(ctx, function(request)
            touch.down(request.finger, request.x, request.y)
            touch.up(request.finger)
        end)
    end,
    ['/api/touch/drag-linear'] = function(ctx)
        return _handle_drag_linear_request(ctx, touch_drag.drag_linear, 204)
    end,
    ['/api/touch/drag-linear-async'] = function(ctx)
        return _handle_drag_linear_request(ctx, touch_drag.drag_linear_async, 202)
    end,
    ['/api/touch/drag-curve'] = function(ctx)
        return _handle_drag_curve_request(ctx, touch_drag.drag_curve, 204)
    end,
    ['/api/touch/drag-curve-async'] = function(ctx)
        return _handle_drag_curve_request(ctx, touch_drag.drag_curve_async, 202)
    end,
    ['/api/touch/wheel'] = function(ctx)
        return _handle_wheel_request(ctx, touch_drag.wheel, 204)
    end,
    ['/api/touch/wheel-async'] = function(ctx)
        return _handle_wheel_request(ctx, touch_drag.wheel_async, 202)
    end,
    ['/api/key/down'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        local keycode = type(body.code) == 'string' and body.code or nil
        if keycode then
            if keycode:upper() == "HOME" then
                keycode = "HOMEBUTTON"
            end
            local ok, err = pcall(key.down, keycode)
            if not ok then
                return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
            end
            ctx.status = 204
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            return ''
        end
        return _request_error_message(ctx, 400, string.format('%s: operation failed: argument error', ctx.uri))
    end,
    ['/api/key/up'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        local keycode = type(body.code) == 'string' and body.code or nil
        if keycode then
            if keycode:upper() == "HOME" then
                keycode = "HOMEBUTTON"
            end
            local ok, err = pcall(key.up, keycode)
            if not ok then
                return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
            end
            ctx.status = 204
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            return ''
        end
        return _request_error_message(ctx, 400, string.format('%s: operation failed: argument error', ctx.uri))
    end,
    ['/api/key/press'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        local keycode = type(body.code) == 'string' and body.code or nil
        if keycode then
            if keycode:upper() == "HOME" then
                keycode = "HOMEBUTTON"
            end
            local ok, err = pcall(key.press, keycode)
            if not ok then
                return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
            end
            ctx.status = 204
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            return ''
        end
        return _request_error_message(ctx, 400, string.format('%s: operation failed: argument error', ctx.uri))
    end,
    ['/api/pasteboard/read'] = function(ctx)
        if ctx.request_method ~= 'GET' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx.status = 200
        local data = pasteboard.read("public.plain-text")
        if data ~= "" then
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            return data
        else
            data = pasteboard.read('public.png')
            if data ~= "" then
                ctx:header('Content-type', 'image/png')
                return data
            else
                data = pasteboard.read('public.jpeg')
                if data ~= "" then
                    ctx:header('Content-type', 'image/jpeg')
                    return data
                else
                    ctx:header('Content-type', 'application/json; charset=utf-8')
                    return _request_error_message(ctx, 400,
                        string.format('%s: operation failed: %s', ctx.uri,
                            'supports copying plain text or plain images from devices only.'))
                end
            end
        end
    end,
    ['/api/pasteboard/write'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx.status = 204
        ctx:header('Content-type', 'application/json; charset=utf-8')
        local body = json.decode(ctx.content)
        body = type(body) == 'table' and body or {}
        local uti = type(body.uti) == 'string' and body.uti or "public.plain-text"
        local data = type(body.data) == 'string' and body.data or nil
        if data then
            if uti == "public.plain-text" then
                pasteboard.write(data, uti)
                return ''
            elseif uti == "public.png" or uti == "public.jpeg" or uti == "public.image" then
                local imgdata = data:base64_decode()
                pasteboard.write(imgdata, uti)
                return ''
            else
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri,
                        'transfer of clipboard contents other than plain text and plain images is not supported.'))
            end
        else
            return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, 'argument error.'))
        end
    end,
    ['/api/proc-dict/run'] = function(ctx)
        if ctx.request_method ~= 'POST' then
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end
        ctx:header('Content-type', 'application/json; charset=utf-8')
        local lua_code = ctx.content
        local operation = proc_dict_operations['run']
        if not operation then
            return _request_error_message(ctx, 400,
                string.format('%s: operation failed: %s', ctx.uri, 'operation not found.'))
        end
        local ret, err = operation(lua_code)
        if type(ret) == 'table' then
            ctx.status = 200
            return json.encode(ret)
        else
            return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
        end
    end
}

local function is_hidden_path(path)
    local components = path:split('/')
    for _, component in ipairs(components) do
        if component:sub(1, 1) == '.' and component:sub(1, 8) ~= ".jbroot-" then -- roothide 环境中，越狱根有中间隐藏路径
            return true
        end
    end
    return false
end

local function read_project_config(dir)
    local conf = file.reads(path_manager.join(dir, '.config'))
    if conf then
        conf = json.decode(conf)
        if type(conf) ~= 'table' then
            conf = nil
        end
    end
    conf = conf or {}
    return conf
end

local function load_xpp_info(Info_lua_path, config_dump)
    if lfs.attributes(Info_lua_path, 'mode') ~= 'file' then
        return nil, '`' .. Info_lua_path .. '` is not a file'
    end
    local Info_lua_content = file.reads(Info_lua_path)
    if not Info_lua_content then
        return nil, 'read `Info.lua` failed'
    end
    local info_reader, syntax_error = load(config_dump .. Info_lua_content, 'Info.lua', 't', {
        tostring = tostring,
        tonumber = tonumber,
        type = type,
        os = {
            time = os.time,
            difftime = os.difftime,
            clock = os.clock,
            date = os.date,
        },
        device = {
            type = device.type,
        },
        screen = {
            size = screen.size,
        },
        sys = {
            version = sys.version,
            xtversion = sys.xtversion,
            zeversion = sys.zeversion,
        },
        json = {
            null = json.null,
        },
    })
    if type(info_reader) ~= 'function' then
        return nil, syntax_error
    end
    local _, info = maxline_pcall(1000000, info_reader)
    if type(info) ~= 'table' then
        return nil, tostring(info)
    end
    return info
end

local _http_uri_router_match_table = {
    { -- 兼容
        '/api/script/.+/run',
        function(ctx)
            if ctx.request_method ~= 'POST' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx:header('Content-type', 'application/json; charset=utf-8')
            local path = string.match(ctx.uri, '/api/script/(.+)/run')
            if path then
                path = XXT_SCRIPTS_PATH .. "/" .. path
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s', ctx.uri, 'invalid path'))
            end
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is directory: %s %q', ctx.uri, ctx.request_method, path))
            end
            local ext = path_manager.extension(path):lower()
            local is_classic_xxt_format = false
            local config_meta
            local ok, to_path
            local debugger_ip = ctx.remote_address:split(':')
            table.remove(debugger_ip, #debugger_ip)
            debugger_ip = table.concat(debugger_ip, ':')
            local is_xpp = ext == '.xpp'
            if ext == '.tep' or ext == '.tar' then
                ok, to_path = tar_extract(path)
                if ext == '.tar' then
                    os.remove(path)
                end
                if not ok then
                    return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, to_path))
                end
                to_path = path_manager.remove_dir_end(to_path)
                config_meta = read_project_config(to_path)
                if config_meta.type ~= 'xpp' then
                    local main_path = path_manager.join(to_path, 'main.lua')
                    if lfs.attributes(main_path, 'mode') ~= 'file' then
                        is_classic_xxt_format = true
                        local flist = file.list(to_path, true) or {}
                        for _, full_path in ipairs(flist) do
                            if is_hidden_path(full_path) then
                                goto continue
                            end
                            local mode = lfs.symlinkattributes(full_path, 'mode')
                            if mode ~= 'file' then
                                goto continue
                            end
                            local relative_path = full_path:sub(#to_path + 2)
                            local orig_file = path_manager.join(XXT_HOME_PATH, relative_path)
                            sys.mkdir_p(path_manager.dirname(orig_file))
                            os.remove(orig_file)
                            file.copy(full_path, orig_file)
                            ::continue::
                        end
                        main_path = path_manager.join(XXT_HOME_PATH, 'lua/scripts/main.lua')
                        file.remove(to_path)
                    end
                    path = main_path
                else
                    local xpp_path = to_path .. '.xpp'
                    file.remove(xpp_path)
                    file.move(to_path, xpp_path)
                    to_path = xpp_path
                    local Info_lua_path = path_manager.join(xpp_path, 'Info.lua')
                    local config_dump = '_config = ' .. stringify(config_meta) .. ';_DEBUG = true;'
                    local info, err = load_xpp_info(Info_lua_path, config_dump)
                    if not info then
                        return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
                    end
                    if type(info.BundleDisplayName) == 'string' then
                        info.BundleDisplayName = info.BundleDisplayName .. '-debug'
                    end
                    if type(info.BundleName) == 'string' then
                        info.BundleName = info.BundleName .. '-debug'
                    end
                    file.writes(Info_lua_path, config_dump .. 'return ' .. stringify(info, { indent = '\t' }))
                    local flist = file.list(xpp_path, true) or {}
                    for _, full_path in ipairs(flist) do
                        if is_hidden_path(full_path) then
                            goto continue
                        end
                        local mode = lfs.symlinkattributes(full_path, 'mode')
                        if mode ~= 'file' then
                            goto continue
                        end
                        if full_path:sub(-4) == '.xui' then
                            local xui_content = file.reads(full_path)
                            if not xui_content then
                                return _request_error_message(ctx, 400,
                                    string.format('%s: operation failed: %s', ctx.uri, 'read `' .. full_path ..
                                    '` failed'))
                            end
                            file.writes(full_path, config_dump .. xui_content)
                        end
                        ::continue::
                    end
                    if type(info.Executable) == 'string' then
                        if info.Executable:sub(-4) == '.lua' then
                            local old_Executable = info.Executable
                            local new_Executable = 'debugger-main-' .. utils.gen_uuid() .. '.lua'
                            file.writes(path_manager.join(xpp_path, new_Executable),
                                nLog_imp_str ..
                                string.format(';local main_lua_path = xpp.bundle_path().."/"..%q;dofile(main_lua_path)',
                                    old_Executable))
                            info.Executable = new_Executable
                            file.writes(Info_lua_path, config_dump .. 'return ' .. stringify(info, { indent = '\t' }))
                            file.writes(path_manager.join(xpp_path, 'nLog.lua'), [[return function() return nLog end]])
                        end
                        is_xpp = true
                    elseif type(info.MainInterfaceFile) == 'string' and info.MainInterfaceFile:sub(-4) == '.xui' then
                        app.open_url('xxt://xui/?interactive=false&bundle=' ..
                        string.encode_uri_component(xpp_path) ..
                        '&name=' .. string.encode_uri_component(info.MainInterfaceFile))
                        ctx.status = 204
                        return ''
                    end
                    path = xpp_path
                end
            end
            if not is_xpp and lfs.attributes(path, 'mode') ~= 'file' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is not a file: %s %q', ctx.uri, ctx.request_method, path))
            end
            local fakectx = {}
            local ctxmeta = getmetatable(ctx)
            local code
            if type(to_path) == 'string' then
                if is_classic_xxt_format then
                    code = nLog_imp_str .. string.format(';dofile(%q)', path)
                else
                    if is_xpp then
                        code = string.format('os.restart(%q)', path)
                    else
                        code = nLog_imp_str ..
                        string.format(
                        ';package.path=%q..";"..package.path;package.path=%q..";"..package.path;package.cpath=%q..";"..package.cpath;dofile(%q)',
                            path_manager.join(to_path, "?.xxt"), path_manager.join(to_path, "?.lua"),
                            path_manager.join(to_path, "?.so"), path)
                    end
                end
            else
                if is_xpp or ext == '.xxt' then
                    -- 启动 xpp 或者 xxt 脚本是无法附带 nLog 日志定义的
                    code = string.format('os.restart(%q)', path)
                else
                    code = nLog_imp_str .. string.format(';dofile(%q)', path)
                end
            end
            if not get_openapi_func then
                local c, _, r = xxtouch.post('/spawn', json.encode(ctx.http_headers), code)
                if c == 200 then
                    local ret = json.decode(r)
                    ret = type(ret) == 'table' and ret or { code = 99, 'unknown error' }
                    if ret.code == 0 then
                        ctx.status = 204
                        return ''
                    end
                    ctx.status = 400
                else
                    ctx.status = c
                end
                return r
            end
            setmetatable(fakectx, {
                __index = function(obj, name)
                    if name == 'content' then
                        return code
                    elseif name == 'header' then
                        return function(obj, item) --[[return ctx:header(item)]] end
                    end
                    return ctxmeta.__index(ctx, name)
                end,
                __newindex = function(obj, name, value)
                    return ctxmeta.__newindex(ctx, name, value)
                end,
            })
            local lua_spawn = get_openapi_func('/spawn')
            if lua_spawn then
                local r, errmsg = lua_spawn(fakectx)
                if r then
                    local ret = json.decode(r)
                    ret = type(ret) == 'table' and ret or { code = 99, 'unknown error' }
                    if ret.code == 0 then
                        ctx.status = 204
                        return ''
                    end
                    ctx.status = 400
                    return r
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: operation failed: %s %s', ctx.uri, ctx.request_method, errmsg))
                end
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s', ctx.uri, ctx.request_method, '"/spawn" api not found.'))
            end
        end,
    },
    { -- 兼容
        '^/api/script/.+/debug',
        function(ctx)
            if ctx.request_method ~= 'POST' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx:header('Content-type', 'application/json; charset=utf-8')
            local path = string.match(ctx.uri, '^/api/script/(.+)/debug')
            if path then
                path = XXT_SCRIPTS_PATH .. "/" .. path
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s', ctx.uri, 'invalid path'))
            end
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is directory: %s %q', ctx.uri, ctx.request_method, path))
            end
            local ext = path_manager.extension(path):lower()
            local is_classic_xxt_format = false
            local config_meta
            local debugger_port = 8818
            local ok, to_path
            local debugger_ip = ctx.remote_address:split(':')
            table.remove(debugger_ip, #debugger_ip)
            debugger_ip = table.concat(debugger_ip, ':')
            local function normalize_debug_port(value)
                local port = tonumber(value)
                if port and port > 0 and port <= 65535 then
                    return math.floor(port)
                end
                return nil
            end
            local function apply_debug_port_from_request()
                local query = ctx.query or {}
                local headers = ctx.http_headers or {}
                local override_port = normalize_debug_port(query.debug_port or query.debugPort)
                    or normalize_debug_port(headers.debug_port or headers.debugPort or headers['debug-port'])
                if override_port then
                    debugger_port = override_port
                end
            end
            local function apply_debug_port_from_spawn_args()
                local raw_spawn_args = ctx.http_headers.spawn_args
                if type(raw_spawn_args) ~= 'string' or raw_spawn_args == '' then
                    return
                end
                local spawn_args = json.decode(raw_spawn_args)
                if type(spawn_args) ~= 'table' then
                    return
                end
                local override_port = normalize_debug_port(spawn_args.debug_port or spawn_args.debugPort)
                spawn_args.debug_port = nil
                spawn_args.debugPort = nil
                ctx.http_headers.spawn_args = json.encode(spawn_args) or raw_spawn_args
                if override_port then
                    debugger_port = override_port
                end
            end
            local is_xpp = ext == '.xpp'
            if ext == '.tep' or ext == '.tar' then
                ok, to_path = tar_extract(path)
                if ext == '.tar' then
                    os.remove(path)
                end
                if not ok then
                    return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, to_path))
                end
                local launch_json = file.reads(path_manager.join(to_path, '.vscode/launch.json'))
                if launch_json then
                    local launch_json_tab = json.decode(launch_json)
                    if type(launch_json_tab) == 'table' and type(launch_json_tab.configurations) == 'table' and #(launch_json_tab.configurations) > 0 then
                        local launch_config = launch_json_tab.configurations[1]
                        if type(launch_config) == 'table' then
                            debugger_port = normalize_debug_port(launch_config.connectionPort or launch_config.port) or debugger_port
                        end
                    end
                end
                apply_debug_port_from_request()
                apply_debug_port_from_spawn_args()
                to_path = path_manager.remove_dir_end(to_path)
                config_meta = read_project_config(to_path)
                if config_meta.type ~= 'xpp' then
                    local main_path = path_manager.join(to_path, 'main.lua')
                    if lfs.attributes(main_path, 'mode') ~= 'file' then
                        is_classic_xxt_format = true
                        local flist = file.list(to_path, true) or {}
                        for _, full_path in ipairs(flist) do
                            if is_hidden_path(full_path) then
                                goto continue
                            end
                            local mode = lfs.symlinkattributes(full_path, 'mode')
                            if mode ~= 'file' then
                                goto continue
                            end
                            local relative_path = full_path:sub(#to_path + 2)
                            local orig_file = path_manager.join(XXT_HOME_PATH, relative_path)
                            sys.mkdir_p(path_manager.dirname(orig_file))
                            os.remove(orig_file)
                            file.copy(full_path, orig_file)
                            ::continue::
                        end
                        main_path = path_manager.join(XXT_HOME_PATH, 'lua/scripts/main.lua')
                        file.remove(to_path)
                    end
                    path = main_path
                else
                    local xpp_path = to_path .. '.xpp'
                    file.remove(xpp_path)
                    file.move(to_path, xpp_path)
                    to_path = xpp_path
                    local Info_lua_path = path_manager.join(xpp_path, 'Info.lua')
                    local config_dump = '_config = ' .. stringify(config_meta) .. ';_DEBUG = true;'
                    local info, err = load_xpp_info(Info_lua_path, config_dump)
                    if not info then
                        return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
                    end
                    if type(info.BundleDisplayName) == 'string' then
                        info.BundleDisplayName = info.BundleDisplayName .. '-debug'
                    end
                    if type(info.BundleName) == 'string' then
                        info.BundleName = info.BundleName .. '-debug'
                    end
                    file.writes(Info_lua_path, config_dump .. 'return ' .. stringify(info, { indent = '\t' }))
                    local flist = file.list(xpp_path, true) or {}
                    for _, full_path in ipairs(flist) do
                        if is_hidden_path(full_path) then
                            goto continue
                        end
                        local mode = lfs.symlinkattributes(full_path, 'mode')
                        if mode ~= 'file' then
                            goto continue
                        end
                        if full_path:sub(-4) == '.xui' then
                            local xui_content = file.reads(full_path)
                            if not xui_content then
                                return _request_error_message(ctx, 400,
                                    string.format('%s: operation failed: %s', ctx.uri, 'read `' .. full_path ..
                                    '` failed'))
                            end
                            file.writes(full_path, config_dump .. xui_content)
                        end
                        ::continue::
                    end
                    if type(info.Executable) == 'string' then
                        if info.Executable:sub(-4) == '.lua' then
                            local old_Executable = info.Executable
                            local new_Executable = 'debugger-main-' .. utils.gen_uuid() .. '.lua'
                            file.writes(path_manager.join(xpp_path, new_Executable),
                                nLog_imp_str ..
                                string.format(
                                ';local main_lua_path = xpp.bundle_path().."/"..%q;require("LuaPanda").start(%q, %d);dofile(main_lua_path)',
                                    old_Executable, debugger_ip, debugger_port))
                            info.Executable = new_Executable
                            file.writes(Info_lua_path, config_dump .. 'return ' .. stringify(info, { indent = '\t' }))
                            file.writes(path_manager.join(xpp_path, 'nLog.lua'), [[return function() return nLog end]])
                        else
                            return _request_error_message(ctx, 400,
                                string.format('%s: operation failed: %s', ctx.uri,
                                    'executable `' .. info.Executable .. '` cannot be debugged'))
                        end
                        is_xpp = true
                    elseif type(info.MainInterfaceFile) == 'string' and info.MainInterfaceFile:sub(-4) == '.xui' then
                        app.open_url('xxt://xui/?interactive=false&bundle=' ..
                        string.encode_uri_component(xpp_path) ..
                        '&name=' .. string.encode_uri_component(info.MainInterfaceFile))
                        ctx.status = 204
                        return ''
                    end
                    path = xpp_path
                end
            end
            apply_debug_port_from_request()
            apply_debug_port_from_spawn_args()
            if not is_xpp and lfs.attributes(path, 'mode') ~= 'file' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is not a file: %s %q', ctx.uri, ctx.request_method, path))
            end
            local fakectx = {}
            local ctxmeta = getmetatable(ctx)
            local code
            if type(to_path) == 'string' then
                if is_classic_xxt_format then
                    code = nLog_imp_str ..
                    string.format(';require("LuaPanda").start(%q, %d);dofile(%q)', debugger_ip, debugger_port, path)
                else
                    if is_xpp then
                        code = string.format('os.restart(%q)', path)
                    else
                        code = nLog_imp_str ..
                        string.format(
                        ';package.path=%q..";"..package.path;package.path=%q..";"..package.path;package.cpath=%q..";"..package.cpath;require("LuaPanda").start(%q, %d);dofile(%q)',
                            path_manager.join(to_path, "?.xxt"), path_manager.join(to_path, "?.lua"),
                            path_manager.join(to_path, "?.so"), debugger_ip, debugger_port, path)
                    end
                end
            else
                if is_xpp or ext == '.xxt' then
                    -- 启动 xpp 或者 xxt 脚本是无法附带 nLog 日志定义的
                    -- 也无法附带 LuaPanda 的调试，只能当普通的启动脚本
                    code = string.format('os.restart(%q)', path)
                else
                    code = nLog_imp_str ..
                    string.format(';require("LuaPanda").start(%q, %d);dofile(%q)', debugger_ip, debugger_port, path)
                end
            end
            sys.toast(string.format('调试主机: %s\n调试端口: %d\n调试脚本: %s', debugger_ip, debugger_port, path))
            if not get_openapi_func then
                local c, _, r = xxtouch.post('/spawn', json.encode(ctx.http_headers), code)
                if c == 200 then
                    local ret = json.decode(r)
                    ret = type(ret) == 'table' and ret or { code = 99, 'unknown error' }
                    if ret.code == 0 then
                        ctx.status = 204
                        return ''
                    end
                    ctx.status = 400
                else
                    ctx.status = c
                end
                return r
            end
            setmetatable(fakectx, {
                __index = function(obj, name)
                    if name == 'content' then
                        return code
                    elseif name == 'header' then
                        return function(obj, item) --[[return ctx:header(item)]] end
                    end
                    return ctxmeta.__index(ctx, name)
                end,
                __newindex = function(obj, name, value)
                    return ctxmeta.__newindex(ctx, name, value)
                end,
            })
            local lua_spawn = get_openapi_func('/spawn')
            if lua_spawn then
                local r, errmsg = lua_spawn(fakectx)
                if r then
                    local ret = json.decode(r)
                    ret = type(ret) == 'table' and ret or { code = 99, 'unknown error' }
                    if ret.code == 0 then
                        ctx.status = 204
                        return ''
                    end
                    ctx.status = 400
                    return r
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: operation failed: %s %s', ctx.uri, ctx.request_method, errmsg))
                end
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s %s', ctx.uri, ctx.request_method, '"/spawn" api not found.'))
            end
        end,
    },
    { -- 兼容
        '^/api/script/.+/encrypt',
        function(ctx)
            if ctx.request_method ~= 'POST' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx:header('Content-type', 'application/json; charset=utf-8')
            local path = string.match(ctx.uri, '^/api/script/(.+)/encrypt')
            if path then
                path = XXT_SCRIPTS_PATH .. "/" .. path
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s', ctx.uri, 'invalid path'))
            end
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is directory: %s %q', ctx.uri, ctx.request_method, path))
            end
            local encrypt_args
            local req_headers = ctx.http_headers
            if type(req_headers.args) == 'string' then
                encrypt_args = json.decode(req_headers.args)
            end
            if type(encrypt_args) ~= 'table' then
                encrypt_args = {}
            end
            local ret = encript.pack(path, encrypt_args)
            if ret.code == 0 then
                ctx.status = 200
            else
                ctx.status = 400
            end
            return json.encode(ret)
        end,
    },
    { -- 兼容
        '^/api/script/.+',
        function(ctx)
            local path = string.match(ctx.uri, '^/api/script/(.+)')
            if path then
                path = XXT_SCRIPTS_PATH .. "/" .. path
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: operation failed: %s', ctx.uri, 'invalid path'))
            end
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 404,
                    string.format('%s: path is directory: %s %q', ctx.uri, ctx.request_method, path))
            end
            ctx:header('Content-type', 'text/plain; charset=utf-8')
            if ctx.request_method == 'DELETE' then
                local success, errmsg = os.remove(path)
                if success then
                    ctx.status = 204
                    return ''
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: remove failed: %s %q %s', ctx.uri, ctx.request_method, path, errmsg))
                end
            elseif ctx.request_method == 'PUT' then
                local f, errmsg = io.open(path, 'w')
                if f then
                    f:write(ctx.content or '')
                    f:close()
                    sys.lchown(path, 501, 501)
                    ctx.status = 204
                    return ''
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: write failed: %s %q %s', ctx.uri, ctx.request_method, path, errmsg))
                end
            elseif ctx.request_method == 'GET' then
                local f, errmsg = io.open(path, 'r')
                if f then
                    local s = f:read('*a')
                    f:close()
                    ctx.status = 200
                    return s
                else
                    return _request_error_message(ctx, 404,
                        string.format('%s: read failed: %s %q %s', ctx.uri, ctx.request_method, path, errmsg))
                end
            end
            return _request_error_message(ctx, 405,
                string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
        end,
    },
    {
        '^/api/file/%w+/?$',
        function(ctx)
            if ctx.request_method ~= 'GET' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            local path = ctx.query['path']
            path = type(path) == 'string' and path or '/'
            path = path:trim()
            path = XXT_HOME_PATH .. "/" .. path
            if lfs.attributes(path, 'mode') == 'directory' then
                return _request_error_message(ctx, 400, 'argument error: path is directory.')
            end
            local algorithm = string.match(ctx.uri, '^/api/file/(%w+)/?$')
            algorithm = tostring(algorithm):lower()
            if algorithm ~= 'md5' and algorithm ~= 'sha1' and algorithm ~= 'sha256' and algorithm ~= 'crc32' then
                return _request_error_message(ctx, 400, 'argument error: invalid algorithm ' .. algorithm)
            end
            local hash, errmsg = file[algorithm](path)
            if hash then
                ctx.status = 200
                ctx:header('Content-type', 'text/plain; charset=utf-8')
                ctx:header('File-Size', tostring(lfs.attributes(path, 'size')))
                if type(hash) ~= 'string' then
                    hash = tostring(hash)
                end
                return hash
            else
                return _request_error_message(ctx, 404,
                    string.format('%s: read failed: %s %q %s', ctx.uri, ctx.request_method, path, errmsg))
            end
        end,
    },
    {
        '^/api/path/jbroot/.-',
        function(ctx)
            if ctx.request_method ~= 'GET' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx.status = 200
            ctx:header("Content-type", "text/plain; charset=utf-8")
            local path = string.match(ctx.uri, '^/api/path/jbroot(/.+)')
            if not path or path == '' then
                path = '/'
            end
            return jbroot(path)
        end,
    },
    {
        '^/api/path/rootfs/.-',
        function(ctx)
            if ctx.request_method ~= 'GET' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx.status = 200
            ctx:header("Content-type", "text/plain; charset=utf-8")
            local path = string.match(ctx.uri, '^/api/path/rootfs(/.+)')
            if not path or path == '' then
                path = '/'
            end
            return rootfs(path)
        end,
    },
    {
        '^/api/proc%-value/.-',
        function(ctx)
            if ctx.request_method ~= 'POST' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx:header('Content-type', 'application/json; charset=utf-8')
            local operation_name = string.match(ctx.uri, '^/api/proc%-value/(.+)')
            if type(operation_name) ~= 'string' or operation_name == '' then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'operation not found.'))
            end
            local body = json.decode(ctx.content)
            if type(body) ~= "table" or "string" ~= type(body.key) then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'argument error.'))
            end
            local operation = proc_value_operations[operation_name]
            if not operation then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'operation not found.'))
            end
            local ret, err = operation(body)
            if ret then
                ctx.status = 200
                return json.encode(ret)
            else
                return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
            end
        end,
    },
    {
        '^/api/proc%-queue/.-',
        function(ctx)
            if ctx.request_method ~= 'POST' then
                return _request_error_message(ctx, 405,
                    string.format('%s: operation failed: method %s not allowed', ctx.uri, ctx.request_method))
            end
            ctx:header('Content-type', 'application/json; charset=utf-8')
            local operation_name = string.match(ctx.uri, '^/api/proc%-queue/(.+)')
            if type(operation_name) ~= 'string' or operation_name == '' then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'operation not found.'))
            end
            local body = json.decode(ctx.content)
            if type(body) ~= "table" or "string" ~= type(body.key) then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'argument error.'))
            end
            local operation = proc_queue_operations[operation_name]
            if not operation then
                return _request_error_message(ctx, 400,
                    string.format('%s: operation failed: %s', ctx.uri, 'operation not found.'))
            end
            local ret, err = operation(body)
            if type(ret) == 'table' then
                ctx.status = 200
                return json.encode(ret)
            else
                return _request_error_message(ctx, 400, string.format('%s: operation failed: %s', ctx.uri, err))
            end
        end,
    },
}

local custom_http_api_factor, custom_http_api

local function _uri_router(ctx)
    local handler = _http_uri_router_table[ctx.uri]
    if type(handler) == 'function' then
        local noerr, ret = pcall(handler, ctx)
        if noerr then
            return ret
        else
            return _internal_error_message(ctx, 502, ret)
        end
    end

    for _, handler in ipairs(_http_uri_router_match_table) do
        if string.find(ctx.uri, handler[1]) == 1 then
            local noerr, ret = pcall(handler[2], ctx)
            if noerr then
                return ret
            else
                return _internal_error_message(ctx, 502, ret)
            end
        end
    end

    if not custom_http_api_factor then
        custom_http_api_factor = loadfile(XXT_BIN_PATH .. '/custom-http-api.lua')
    end
    if type(custom_http_api_factor) == 'function' then
        local noerr = nil
        if not custom_http_api then
            noerr, custom_http_api = pcall(custom_http_api_factor)
        else
            noerr = true
        end
        if noerr then
            if type(custom_http_api) == 'function' then
                noerr, ret = pcall(custom_http_api, ctx)
                if noerr then
                    return tostring(ret)
                else
                    return _internal_error_message(ctx, 503, 'custom_http_api: ' .. tostring(ret))
                end
            end
        else
            return _internal_error_message(ctx, 503, 'custom_http_api_factor: ' .. tostring(custom_http_api))
        end
    end
end

return function(ctx)
    -- if ctx.uri ~= '/api/system/log' then
    --     sys.log(json.encode({uri = ctx.uri, method = ctx.request_method, headers = ctx.http_headers, query = ctx.query}))
    -- end
    local noerr, ret = pcall(_uri_router, ctx)
    if noerr then
        if type(ret) == 'string' then
            return ret
        end
    else
        return _internal_error_message(ctx, 501, ret)
    end
    ctx.status = 404
    ctx:header('Content-type', 'application/json; charset=utf-8')
    return [[{"code": 404, "message": "page not found."}]]
end
