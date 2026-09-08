local M = {}

function M.contains_null_byte(text)
    return type(text) == "string" and text:find("\0", 1, true) ~= nil
end

function M.file_exists(path)
    if type(path) ~= "string" or path == "" or M.contains_null_byte(path) then
        return false
    end
    return file.exists(path)
end

function M.shallow_copy_table(src)
    local out = {}
    for key, value in pairs(src or {}) do
        out[key] = value
    end
    return out
end

function M.clone_array(values)
    local out = {}
    for i = 1, #(values or {}) do
        out[i] = values[i]
    end
    return out
end

function M.push_unique(list, seen, value)
    if type(value) ~= "string" or value == "" or seen[value] then
        return
    end
    seen[value] = true
    list[#list + 1] = value
end

function M.parent_dir(path)
    if type(path) ~= "string" or path == "" then
        return nil
    end
    local normalized = path:gsub("/+$", "")
    local dir = normalized:match("^(.*)/[^/]+$")
    if dir == "" then
        return "/"
    end
    return dir
end

function M.clamp(value, min_value, max_value)
    if value < min_value then
        return min_value
    end
    if value > max_value then
        return max_value
    end
    return value
end

function M.ends_with(text, suffix)
    return type(text) == "string" and type(suffix) == "string" and suffix ~= "" and
        text:sub(-#suffix) == suffix
end

local function call_method_bytes(obj, method_name)
    local method = obj and obj[method_name]
    if type(method) ~= "function" then
        return nil
    end
    local ok, result = pcall(method, obj)
    if ok and type(result) == "string" then
        return result
    end
    return nil
end

local function is_image_object(value)
    return type(image.is) == "function" and image.is(value)
end

local function try_load_image_data(data)
    if type(data) ~= "string" or data == "" then
        return nil
    end
    local ok, img = pcall(image.load_data, data)
    if ok and img then
        return img
    end
    return nil
end

local function try_load_image_from_method(input, method_name)
    local data = call_method_bytes(input, method_name)
    if not data then
        return nil
    end
    return try_load_image_data(data)
end

local function array_contains(values, target)
    for i = 1, #(values or {}) do
        if values[i] == target then
            return true
        end
    end
    return false
end

local function assign_detection_label(det, class_names)
    local label = class_names and class_names[det.class_id + 1]
    if label then
        det.label = label
    end
end

function M.resolve_image_object(input)
    if is_image_object(input) then
        return input
    end

    if type(input) == "string" then
        if M.file_exists(input) then
            local ok, img = pcall(image.load_file, input)
            if ok and img then
                return img
            end
        end

        local img_raw = try_load_image_data(input)
        if img_raw then
            return img_raw
        end

        local decoded = input:base64_decode()
        local img_b64 = try_load_image_data(decoded)
        if img_b64 then
            return img_b64
        end

        error("image load failed: unsupported path/raw/base64 input")
    end

    if type(input) == "table" or type(input) == "userdata" then
        local img_png = try_load_image_from_method(input, "png_data")
        if img_png then
            return img_png
        end

        local img_jpeg = try_load_image_from_method(input, "jpeg_data")
        if img_jpeg then
            return img_jpeg
        end
    end

    error("image load failed: expected path, bytes, base64 or image object")
end

function M.resolve_image_input(input)
    if is_image_object(input) then
        return input, false
    end
    return M.resolve_image_object(input), true
end

function M.split_lines(text)
    local normalized = (text or ""):gsub("\r\n", "\n"):gsub("\r", "\n")
    if normalized == "" then
        return {}
    end
    local lines = string.split(normalized, "\n") or {}
    local line_count = #lines
    local last_line = line_count > 0 and lines[line_count] or nil
    if normalized:sub(-1) == "\n" and last_line ~= nil and last_line == "" then
        lines[line_count] = nil
    end
    return lines
end

function M.load_nonempty_lines_from_file(path, kind)
    local lines = M.split_lines(file.reads(path))
    while #lines > 0 do
        local line_count = #lines
        local last_line = line_count > 0 and lines[line_count] or nil
        if last_line == nil or last_line ~= "" then
            break
        end
        lines[line_count] = nil
    end
    if #lines == 0 then
        error(string.format("%s file is empty: %s", kind, path))
    end
    for i = 1, #lines do
        local line = lines[i]
        if line ~= nil and line == "" then
            error(string.format("%s file contains empty line at %d: %s", kind, i, path))
        end
    end
    return lines
end

function M.normalize_class_names(names)
    if names == nil then
        return nil
    end
    if type(names) == "string" then
        error("class_names string should be resolved before normalize_class_names")
    end
    if type(names) ~= "table" then
        error("class_names must be a table")
    end
    if #names > 0 then
        local out = {}
        for i = 1, #names do
            if type(names[i]) == "string" then
                out[i] = names[i]
            end
        end
        return #out > 0 and out or nil
    end

    local out = {}
    for key, value in pairs(names) do
        local idx = tonumber(key)
        if idx and type(value) == "string" and idx >= 0 then
            out[idx + 1] = value
        end
    end
    return next(out) and out or nil
end

function M.build_label_search_roots(model_path, model_dir, primary_root, legacy_root, opts)
    opts = opts or {}
    local roots = {}
    local seen = {}
    M.push_unique(roots, seen, model_dir)
    M.push_unique(roots, seen, M.parent_dir(model_path))
    if opts.include_package_parent then
        local model_parent = M.parent_dir(model_path)
        if model_parent and M.ends_with(model_parent, ".mlpackage") then
            M.push_unique(roots, seen, M.parent_dir(model_parent))
        end
    end
    M.push_unique(roots, seen, primary_root)
    M.push_unique(roots, seen, legacy_root)
    return roots
end

function M.resolve_label_path(name, roots, presets)
    local preset = presets[(name or ""):lower()]
    if not preset then
        return nil
    end
    for i = 1, #(roots or {}) do
        local candidate = roots[i] .. "/" .. preset
        if M.file_exists(candidate) then
            return candidate
        end
    end
    return nil
end

function M.load_class_names_from_file(path)
    return M.load_nonempty_lines_from_file(path, "class_names")
end

function M.provider_list_contains(providers, name)
    return array_contains(providers, name)
end

function M.available_provider_names_contains(provider_names, full_name)
    return array_contains(provider_names, full_name)
end

function M.normalize_provider_list(providers)
    if providers == nil then
        return {"cpu"}
    end
    if type(providers) == "string" then
        if providers == "" then
            error("providers must not be an empty string")
        end
        return {providers}
    end
    if type(providers) ~= "table" then
        error("providers must be a string or string array")
    end
    local normalized = {}
    for i = 1, #providers do
        local value = providers[i]
        if type(value) ~= "string" or value == "" then
            error("providers[" .. i .. "] must be a non-empty string")
        end
        normalized[i] = value
    end
    if #normalized == 0 then
        error("providers must not be empty")
    end
    return normalized
end

function M.build_search_roots(opts, primary_root, legacy_root, specific_dir)
    local roots = {}
    local seen = {}
    M.push_unique(roots, seen, specific_dir)
    M.push_unique(roots, seen, opts and opts.model_dir)
    M.push_unique(roots, seen, primary_root)
    M.push_unique(roots, seen, legacy_root)
    return roots
end

function M.resolve_named_resource(explicit_path, roots, filenames, required)
    if explicit_path and explicit_path ~= "" then
        if not M.file_exists(explicit_path) then
            error("resource not found: " .. explicit_path)
        end
        return explicit_path
    end

    for i = 1, #(roots or {}) do
        local root = roots[i]
        if root and root ~= "" then
            for j = 1, #(filenames or {}) do
                local candidate = root .. "/" .. filenames[j]
                if M.file_exists(candidate) then
                    return candidate
                end
            end
        end
    end

    if required then
        error("resource not found: " .. table.concat(filenames or {}, " or "))
    end
    return nil
end

function M.build_ort_session_options(opts, coreml_keys, defaults)
    opts = opts or {}
    defaults = defaults or {}
    local options = {
        intra_op_num_threads = tonumber(opts.threads) or defaults.intra_op_num_threads or 1,
        graph_optimization_level = defaults.graph_optimization_level or "all",
        fallback_to_cpu = opts.fallback_to_cpu ~= false,
    }
    options.providers = M.normalize_provider_list(opts.providers)
    for i = 1, #(coreml_keys or {}) do
        local key = coreml_keys[i]
        if opts[key] ~= nil then
            options[key] = opts[key]
        end
    end
    return options
end

function M.build_ort_model_info(model_path, session, opts, used_coreml, extra_fields)
    local input_names = session:input_names()
    local output_names = session:output_names()
    local input_info = session:input_info(1)
    local outputs = {}
    for i = 1, #output_names do
        local info = session:output_info(i)
        outputs[i] = {
            name = output_names[i],
            shape = info and info.shape and M.clone_array(info.shape) or {},
        }
    end
    local info = {
        model_path = model_path,
        input_name = input_names[1],
        input_shape = input_info and input_info.shape and M.clone_array(input_info.shape) or {},
        outputs = outputs,
        used_coreml = not not used_coreml,
        providers = M.normalize_provider_list(opts and opts.providers),
    }
    for key, value in pairs(extra_fields or {}) do
        info[key] = value
    end
    return info
end

function M.resolve_class_names(task, class_names, roots, opts)
    opts = opts or {}
    if class_names == nil then
        local presets = opts.default_class_preset_by_task or {}
        class_names = presets[task]
        if class_names == nil then
            return nil
        end
    end
    if type(class_names) == "string" then
        local path = M.resolve_label_path(class_names, roots, opts.class_name_presets or {})
        if not path then
            path = class_names
        end
        if not M.file_exists(path) then
            if opts.error_on_missing_path then
                error("class_names file not found: " .. tostring(class_names))
            end
            return nil
        end
        return M.load_class_names_from_file(path)
    end
    return M.normalize_class_names(class_names)
end

function M.normalize_task(task, default_task)
    task = tostring(task or default_task or "detect"):lower()
    if task == "det" or task == "detect" or task == "detection" then
        return "detect"
    end
    if task == "cls" or task == "classify" or task == "classification" then
        return "classify"
    end
    if task == "obb" or task == "oriented" or task == "oriented_bbox" or task == "oriented_box" then
        return "obb"
    end
    error("unsupported yolo task: " .. tostring(task))
end

function M.copy_decoder_schema_overrides(schema, opts, keys)
    for i = 1, #keys do
        local key = keys[i]
        if schema[key] == nil and opts[key] ~= nil then
            schema[key] = opts[key]
        end
    end
    if schema.box_indices == nil and type(opts.box_indices) == "table" then
        schema.box_indices = M.clone_array(opts.box_indices)
    end
end

function M.build_decoder_schema(task, opts, keys, normalize_task_fn)
    local schema = M.shallow_copy_table(opts.decoder_schema or {})
    schema.task = normalize_task_fn(schema.task or task)
    M.copy_decoder_schema_overrides(schema, opts, keys)

    if schema.task == "detect" then
        local has_objectness = opts.has_objectness == true
        schema.prediction_layout = schema.prediction_layout or "auto"
        schema.box_format = schema.box_format or "cxcywh"
        schema.score_mode = schema.score_mode or
            (has_objectness and "objectness_times_class" or "class_only")
        if has_objectness and schema.objectness_index == nil then
            schema.objectness_index = 4
        end
        if schema.class_start == nil then
            schema.class_start = has_objectness and 5 or 4
        end
    elseif schema.task == "obb" then
        schema.prediction_layout = schema.prediction_layout or "auto"
        schema.box_format = schema.box_format or "cxcywh"
        schema.score_mode = schema.score_mode or "class_only"
        schema.class_start = schema.class_start or 4
        if schema.class_end == nil then
            schema.class_end = -1
        end
        if schema.angle_index == nil then
            schema.angle_index = -1
        end
    elseif schema.task == "classify" then
        schema.prediction_layout = schema.prediction_layout or "auto"
        schema.class_start = schema.class_start or 0
        if schema.classification_mode == nil and type(opts.apply_softmax) == "boolean" then
            schema.classification_mode = opts.apply_softmax and "logits" or "probabilities"
        end
    end

    return schema
end

function M.clip_box(box, width, height)
    return {
        M.clamp(box[1], 0, width),
        M.clamp(box[2], 0, height),
        M.clamp(box[3], 0, width),
        M.clamp(box[4], 0, height),
    }
end

function M.scale_box_to_original(box, meta)
    local scaled = {
        (box[1] - meta.offset_x) / meta.scale_x,
        (box[2] - meta.offset_y) / meta.scale_y,
        (box[3] - meta.offset_x) / meta.scale_x,
        (box[4] - meta.offset_y) / meta.scale_y,
    }
    return M.clip_box(scaled, meta.src_width, meta.src_height)
end

function M.flatten_tensor_to_vector(tensor)
    local out = {}
    local function visit(value)
        if type(value) == "table" then
            for i = 1, #value do
                visit(value[i])
            end
        else
            out[#out + 1] = tonumber(value) or 0.0
        end
    end
    visit(tensor:to_table())
    return out
end

function M.parse_detect_options(conf, iou, opts, default_confidence, default_iou)
    if type(conf) == "table" and iou == nil and opts == nil then
        opts = conf
        conf = nil
    end
    opts = opts or {}
    local class_aware
    if type(opts.class_agnostic) == "boolean" then
        class_aware = not opts.class_agnostic
    else
        class_aware = opts.class_aware ~= false
    end
    return {
        confidence = tonumber(conf or opts.confidence or opts.conf) or default_confidence,
        iou = tonumber(iou or opts.iou) or default_iou,
        class_ids = opts.class_ids,
        class_aware = class_aware,
        max_det = tonumber(opts.max_det) or nil,
    }
end

function M.parse_classify_options(opts)
    opts = opts or {}
    return {
        topk = tonumber(opts.topk) or 5,
        apply_softmax = type(opts.apply_softmax) == "boolean" and opts.apply_softmax or nil,
        return_logits = opts.return_logits == true,
    }
end

function M.obb_points_from_xywhr(cx, cy, width, height, theta)
    local cos_value = math.cos(theta)
    local sin_value = math.sin(theta)
    local vec1x = width / 2 * cos_value
    local vec1y = width / 2 * sin_value
    local vec2x = -height / 2 * sin_value
    local vec2y = height / 2 * cos_value
    return {
        {x = cx + vec1x + vec2x, y = cy + vec1y + vec2y},
        {x = cx + vec1x - vec2x, y = cy + vec1y - vec2y},
        {x = cx - vec1x - vec2x, y = cy - vec1y - vec2y},
        {x = cx - vec1x + vec2x, y = cy - vec1y + vec2y},
    }
end

function M.bounds_from_points(points, width, height)
    local min_x = math.huge
    local min_y = math.huge
    local max_x = -math.huge
    local max_y = -math.huge
    for i = 1, #points do
        local point = points[i]
        point.x = M.clamp(point.x, 0, width)
        point.y = M.clamp(point.y, 0, height)
        if point.x < min_x then min_x = point.x end
        if point.y < min_y then min_y = point.y end
        if point.x > max_x then max_x = point.x end
        if point.y > max_y then max_y = point.y end
    end
    return {min_x, min_y, max_x, max_y}
end

function M.enrich_detection(det, meta, class_names)
    det.box = M.scale_box_to_original(det.box, meta)
    det.x1 = det.box[1]
    det.y1 = det.box[2]
    det.x2 = det.box[3]
    det.y2 = det.box[4]
    det.width = math.max(0, det.x2 - det.x1)
    det.height = math.max(0, det.y2 - det.y1)
    det.cx = det.x1 + det.width / 2
    det.cy = det.y1 + det.height / 2
    assign_detection_label(det, class_names)
    return det
end

function M.enrich_obb_detection(det, meta, class_names)
    local cx = M.clamp((det.cx - meta.offset_x) / meta.scale_x, 0, meta.src_width)
    local cy = M.clamp((det.cy - meta.offset_y) / meta.scale_y, 0, meta.src_height)
    local width = det.w / meta.scale_x
    local height = det.h / meta.scale_y
    local theta = det.theta or 0.0
    local points = M.obb_points_from_xywhr(cx, cy, width, height, theta)
    local box = M.bounds_from_points(points, meta.src_width, meta.src_height)

    det.cx = cx
    det.cy = cy
    det.w = width
    det.h = height
    det.theta = theta
    det.points = points
    det.box = box
    det.x1 = box[1]
    det.y1 = box[2]
    det.x2 = box[3]
    det.y2 = box[4]
    det.width = math.max(0, det.x2 - det.x1)
    det.height = math.max(0, det.y2 - det.y1)
    assign_detection_label(det, class_names)
    return det
end

return M
