--[[
yolo_coreml.lua

Created by 苏泽 on 26-03-30.
Copyright (c) 2026年 苏泽. All rights reserved.

基于 XXTouch 内置 CoreML 模块的 YOLO 封装。

支持任务:
- detect
- classify
- obb

构造参数:
- compiled_model_path = "/path/to/model.mlmodelc"
- model_dir = "/path/to/model_dir"
- task = "detect" | "classify" | "obb"
- class_names = {"a", "b"} 或 "/path/to/classes.txt" 或 "coco80"/"imagenet1000"/"dota15"
- uses_cpu_only = true/false
- input_width = integer
- input_height = integer
- confidence = number
- iou = number
- max_det = integer
- class_ids = {0, 1, 2}
- class_aware = true/false
- class_agnostic = true/false
- resize_mode = "stretch" | "letterbox"
- letterbox_mode = "center" | "top_left"
- pad_color = 0x727272

说明:
- 兼容 CoreML 的 image input 和 multi-array input 两种模型。
- `yolov8n*.mlpackage` 这类 image input 模型默认使用图像预处理路径。

工具函数:
- yolo_coreml.compile_model_cached("/path/to/model.mlpackage|.mlmodel") -> "/path/to/model.mlmodelc"
- yolo_coreml.clear_compiled_model_cache("/path/to/model.mlpackage|.mlmodel") -> 被清理的缓存条目数量

示例:
local yolo_coreml = require("yolo_coreml")
local compiled_model_path = assert(yolo_coreml.compile_model_cached(
    XXT_HOME_PATH.."/models/yolo_coreml/yolo11n.mlpackage"
))
local model = assert(yolo_coreml.new({
    compiled_model_path = compiled_model_path,
}))
local detections = assert(model:detect(XXT_HOME_PATH.."/models/yolo_coreml/bus.jpg"))
model:close()

assert(yolo_coreml.clear_compiled_model_cache(
    XXT_HOME_PATH.."/models/yolo_coreml/yolo11n.mlpackage"
))
]]

local coreml = assert(rawget(_G, "coreml"))
local path = require("path")
local tracker_module = require("yolo_tracker")
local profile_runtime = require("yolo_profile_runtime")
local common = require("yolo_backend_common")

local VERSION = "0.1.1"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/yolo_coreml"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/yolo_coreml"

local DEFAULT_CONFIDENCE = 0.25
local DEFAULT_IOU = 0.45
local DEFAULT_TASK = "detect"

local DEFAULT_INPUT_SIZE_BY_TASK = {
    detect = 640,
    classify = 224,
    obb = 1024,
}

local DEFAULT_CLASS_PRESET_BY_TASK = {
    detect = "coco80",
    classify = "imagenet1000",
    obb = "dota15",
}

local SUPPORTED_TASKS = {
    detect = true,
    classify = true,
    obb = true,
}

local CLASS_NAME_PRESETS = {
    coco80 = "coco80.txt",
    coco = "coco80.txt",
    imagenet1000 = "imagenet1000.txt",
    imagenet = "imagenet1000.txt",
    dota15 = "dota15.txt",
    dota = "dota15.txt",
}

local instance_mt = {}
instance_mt.__index = instance_mt

local run_outputs
local enrich_detection
local enrich_obb_detection
local classify_impl
local prepare_input

local DECODER_SCHEMA_KEYS = {
    "prediction_layout",
    "box_format",
    "score_mode",
    "classification_mode",
    "objectness_index",
    "angle_index",
    "class_start",
    "class_end",
    "class_aware",
    "apply_softmax",
    "score_threshold",
    "iou_threshold",
    "top_k",
}

local file_exists = common.file_exists
local clone_array = common.clone_array
local ends_with = common.ends_with
local parent_dir = common.parent_dir
local resolve_image_object = common.resolve_image_object
local flatten_tensor_to_vector = common.flatten_tensor_to_vector

local function build_search_roots(opts)
    local roots = {}
    if opts.model_dir and opts.model_dir ~= "" then
        roots[#roots + 1] = opts.model_dir
    end
    roots[#roots + 1] = PRIMARY_MODEL_ROOT
    if LEGACY_MODEL_ROOT ~= PRIMARY_MODEL_ROOT then
        roots[#roots + 1] = LEGACY_MODEL_ROOT
    end
    return roots
end

local function resolve_compiled_model_path(opts)
    local compiled_model_path = opts.compiled_model_path
    if type(compiled_model_path) ~= "string" or compiled_model_path == "" then
        error("compiled_model_path is required")
    end
    if not ends_with(compiled_model_path, ".mlmodelc") then
        error("compiled_model_path must end with .mlmodelc")
    end
    if not file_exists(compiled_model_path) then
        error("compiled model not found: " .. compiled_model_path)
    end
    return compiled_model_path
end

local function resolve_source_model_path(model_path)
    if type(model_path) ~= "string" or model_path == "" then
        error("model_path is required")
    end
    if ends_with(model_path, ".mlmodelc") then
        error("model_path must be .mlpackage or .mlmodel when compiling cache")
    end
    if not (ends_with(model_path, ".mlpackage") or ends_with(model_path, ".mlmodel")) then
        error("model_path must end with .mlpackage or .mlmodel")
    end
    if not file_exists(model_path) then
        error("model file not found: " .. model_path)
    end
    return model_path
end

local function compiled_cache_path_for_model(model_path)
    local dir = assert(parent_dir(model_path), "failed to resolve model directory")
    local name = model_path:match("([^/]+)$") or model_path
    if ends_with(name, ".mlpackage") then
        name = name:sub(1, -#".mlpackage" - 1)
    elseif ends_with(name, ".mlmodel") then
        name = name:sub(1, -#".mlmodel" - 1)
    else
        error("model_path must end with .mlpackage or .mlmodel")
    end
    return dir .. "/" .. name .. ".mlmodelc"
end

local function move_compiled_model_artifact(temp_compiled_model_path, target_compiled_model_path)
    local function shell_quote(text)
        return "'" .. tostring(text):gsub("'", "'\\''") .. "'"
    end
    local function shell_tool(name)
        local jb_path = "/var/jb/usr/bin/" .. name
        if path.isfile(jb_path) then
            return jb_path
        end
        return "/bin/" .. name
    end

    if temp_compiled_model_path == target_compiled_model_path then
        return target_compiled_model_path
    end
    local ok, err = path.rename(temp_compiled_model_path, target_compiled_model_path, true)
    if ok ~= nil and ok ~= false then
        return target_compiled_model_path
    end
    if file_exists(target_compiled_model_path) then
        local removed, remove_err = path.remove(target_compiled_model_path, {
            recurse = true,
        })
        if removed == nil or removed == false then
            error("failed to replace compiled model cache: " .. tostring(remove_err))
        end
    end
    local command = string.format(
        "%s -R %s %s && %s -rf %s",
        shell_quote(shell_tool("cp")),
        shell_quote(temp_compiled_model_path),
        shell_quote(target_compiled_model_path),
        shell_quote(shell_tool("rm")),
        shell_quote(temp_compiled_model_path)
    )
    local status_ok, why, status_code = os.execute(command)
    if status_ok == true or status_ok == 0 or status_code == 0 then
        return target_compiled_model_path
    end
    error(string.format(
        "failed to move compiled model cache: %s (command=%s, os.execute=%s/%s/%s)",
        tostring(err),
        command,
        tostring(status_ok),
        tostring(why),
        tostring(status_code)
    ))
end

local function compiled_cache_is_fresh(model_path, compiled_model_path)
    if not file_exists(compiled_model_path) then
        return false
    end
    local source_mtime = path.mtime(model_path)
    local compiled_mtime = path.mtime(compiled_model_path)
    if type(source_mtime) ~= "number" or type(compiled_mtime) ~= "number" then
        return false
    end
    return compiled_mtime >= source_mtime
end

local function compile_model_cached(model_path)
    model_path = resolve_source_model_path(model_path)
    local target_compiled_model_path = compiled_cache_path_for_model(model_path)
    if compiled_cache_is_fresh(model_path, target_compiled_model_path) then
        return target_compiled_model_path
    end
    local temp_compiled_model_path = assert(coreml.compile_model(model_path))
    return move_compiled_model_artifact(
        temp_compiled_model_path,
        target_compiled_model_path
    )
end

local function remove_compiled_model_artifact(compiled_model_path)
    if type(compiled_model_path) ~= "string" or compiled_model_path == "" then
        return 0
    end
    if not file_exists(compiled_model_path) then
        return 0
    end
    local ok, err = path.remove(compiled_model_path, {
        recurse = true,
    })
    if ok == nil or ok == false then
        error("failed to remove compiled model cache: " .. tostring(err))
    end
    return ok
end

local function clear_compiled_model_cache(model_path)
    model_path = resolve_source_model_path(model_path)
    local compiled_model_path = compiled_cache_path_for_model(model_path)
    if file_exists(compiled_model_path) then
        remove_compiled_model_artifact(compiled_model_path)
        return 1
    end
    return 0
end

local function build_label_search_roots(model_path, model_dir)
    return common.build_label_search_roots(model_path, model_dir, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT, {
        include_package_parent = true,
    })
end

local function resolve_class_names(task, class_names, roots)
    return common.resolve_class_names(task, class_names, roots, {
        default_class_preset_by_task = DEFAULT_CLASS_PRESET_BY_TASK,
        class_name_presets = CLASS_NAME_PRESETS,
    })
end

local function build_label_to_id(class_names)
    if type(class_names) ~= "table" then
        return nil
    end
    local out = {}
    for i = 1, #class_names do
        local label = class_names[i]
        if type(label) == "string" and label ~= "" and out[label] == nil then
            out[label] = i - 1
        end
    end
    return next(out) and out or nil
end

local function normalize_task(task)
    return common.normalize_task(task, DEFAULT_TASK)
end

local deep_copy = profile_runtime.deep_copy
local deep_merge = profile_runtime.deep_merge
local normalize_profile_task = profile_runtime.normalize_profile_task
local base_task_for_profile_task = profile_runtime.base_task_for_profile_task
local parse_task_call_options = profile_runtime.parse_task_call_options
local resolve_output_spec = profile_runtime.resolve_output_spec
local build_runtime_decoder_schema = profile_runtime.build_runtime_decoder_schema
local resolve_runtime_task = profile_runtime.resolve_runtime_task
local select_feature_columns = profile_runtime.select_feature_columns
local build_transform_options = profile_runtime.build_transform_options

local PROFILE_RESOLVE_OPTIONS = {
    default_task = DEFAULT_TASK,
    default_confidence = DEFAULT_CONFIDENCE,
    default_iou = DEFAULT_IOU,
    default_resize_mode = function(self)
        return self.resize_mode or "letterbox"
    end,
    default_letterbox_mode = function(self)
        return self.letterbox_mode or "center"
    end,
    default_pad_color = function(self)
        return self.pad_color or 0x727272
    end,
}

local function resolve_profile(self, call_opts, forced_task)
    return profile_runtime.resolve_profile(
        self,
        call_opts,
        forced_task,
        PROFILE_RESOLVE_OPTIONS
    )
end

local function prepare_profile_input(self, img, profile, overrides)
    overrides = overrides or {}
    local input_profile = profile.input or {}
    return prepare_input(self, img, {
        width = tonumber(overrides.width or input_profile.width) or self.input_width,
        height = tonumber(overrides.height or input_profile.height) or self.input_height,
        resize_mode = overrides.resize_mode or input_profile.resize_mode or self.resize_mode,
        letterbox_mode = overrides.letterbox_mode or input_profile.letterbox_mode or self.letterbox_mode,
        pad_color = overrides.pad_color or input_profile.pad_color or self.pad_color,
        channel_order = overrides.channel_order or input_profile.channel_order or "rgb",
        layout = overrides.layout or input_profile.layout or "nchw",
        data_type = overrides.data_type or input_profile.data_type or "float32",
        scale = overrides.scale or input_profile.scale or (1.0 / 255.0),
    })
end

local function materialize_detect_detections(self, bundle, meta)
    return profile_runtime.materialize_detect_detections(
        coreml,
        self.class_names,
        bundle,
        meta,
        build_transform_options
    )
end

local function materialize_obb_detections(self, bundle, meta, profile)
    return profile_runtime.materialize_obb_detections(
        coreml,
        self.class_names,
        bundle,
        meta,
        profile,
        enrich_obb_detection
    )
end

local function decode_dense_matrix_profile(self, matrix, meta, profile, runtime_task)
    local task = runtime_task or profile.task
    local bundle = assert(coreml.decode_matrix_candidates(
        matrix,
        build_runtime_decoder_schema(task, profile),
        {
            confidence = tonumber((profile.postprocess or {}).confidence) or DEFAULT_CONFIDENCE,
            iou = tonumber((profile.postprocess or {}).iou) or DEFAULT_IOU,
            max_det = tonumber((profile.postprocess or {}).max_det) or nil,
            class_aware = (profile.postprocess or {}).class_aware ~= false,
            class_ids = (profile.postprocess or {}).class_ids,
        }
    ))
    local detections, scaled_boxes
    if task == "obb" then
        detections = materialize_obb_detections(self, bundle, meta, profile)
    else
        detections, scaled_boxes = materialize_detect_detections(self, bundle, meta)
    end
    return {
        detections = detections,
        bundle = bundle,
        scaled_boxes = scaled_boxes,
    }
end

local function attach_segmentation_masks(self, state, outputs, profile, meta)
    return profile_runtime.attach_segmentation_masks(
        coreml,
        resolve_output_spec,
        self.output_names,
        state,
        outputs,
        profile,
        meta,
        build_transform_options,
        select_feature_columns
    )
end

local function attach_pose_keypoints(state, profile, meta)
    return profile_runtime.attach_pose_keypoints(
        coreml,
        state,
        profile,
        meta,
        build_transform_options,
        select_feature_columns
    )
end

local function decode_anchor_grid_profile(self, det_output, meta, profile)
    return profile_runtime.decode_anchor_grid_profile(
        coreml,
        self.class_names,
        det_output,
        meta,
        profile,
        self.input_width,
        self.input_height,
        enrich_detection
    )
end

local classify_from_outputs

local PROFILE_RUN_HOOKS = {
    backend_name = "coreml",
    resolve_profile = resolve_profile,
    resolve_runtime_task = resolve_runtime_task,
    resolve_image_object = resolve_image_object,
    prepare_profile_input = prepare_profile_input,
    run_outputs = function(instance, input_value)
        return run_outputs(instance, input_value)
    end,
    classify_from_outputs = function(instance, outputs, call_opts, profile)
        return classify_from_outputs(instance, outputs, call_opts, profile)
    end,
    decode_anchor_grid_profile = decode_anchor_grid_profile,
    decode_dense_matrix_profile = decode_dense_matrix_profile,
    attach_segmentation_masks = attach_segmentation_masks,
    attach_pose_keypoints = attach_pose_keypoints,
    tracker_factory = function(opts)
        return tracker_module.tracker(opts)
    end,
}

local function run_profile_task(self, input, call_opts, forced_task)
    return profile_runtime.run_backend_profile_task(
        self,
        input,
        call_opts,
        forced_task,
        PROFILE_RUN_HOOKS
    )
end

local function build_decoder_schema(task, opts)
    return common.build_decoder_schema(task, opts, DECODER_SCHEMA_KEYS, normalize_task)
end

local function default_task_for_options(requested_task, options)
    if requested_task ~= "track" then
        return normalize_task(base_task_for_profile_task(requested_task)), requested_task
    end
    local track_profile = options.profile and options.profile.track or nil
    local base_task = track_profile and (track_profile.task or track_profile.base_task) or
        options.track_task or options.base_task
    if base_task == nil then
        return "detect", "detect"
    end
    base_task = normalize_profile_task(base_task)
    if base_task == "track" then
        return "detect", "detect"
    end
    if base_task == "classify" then
        error("track requires detect, seg, pose or obb task")
    end
    return normalize_task(base_task_for_profile_task(base_task)), base_task
end

local function first_feature_name(names)
    return type(names) == "table" and names[1] or nil
end

local function infer_input_size_from_rows(rows, strides)
    if type(rows) ~= "number" or rows <= 0 then
        return nil
    end
    strides = strides or {8, 16, 32}
    for size = 32, 2048, 32 do
        local total = 0
        for i = 1, #strides do
            local stride = strides[i]
            total = total + (size / stride) * (size / stride)
        end
        if total == rows then
            return size, size
        end
    end
    return nil
end

local function infer_output_rows(shape)
    if type(shape) ~= "table" or #shape < 2 then
        return nil
    end
    if #shape == 3 then
        local dim2 = tonumber(shape[2])
        local dim3 = tonumber(shape[3])
        if dim2 and dim3 then
            if dim2 >= 5 and dim3 > dim2 then
                return dim3
            end
            if dim3 >= 5 and dim2 > dim3 then
                return dim2
            end
        end
    elseif #shape == 2 then
        local dim1 = tonumber(shape[1])
        local dim2 = tonumber(shape[2])
        if dim1 and dim2 then
            return math.max(dim1, dim2)
        end
    end
    return nil
end

local function infer_input_hw(task, input_info, outputs, preferred_width, preferred_height)
    local width = tonumber(preferred_width)
    local height = tonumber(preferred_height)
    if width and height and width > 0 and height > 0 then
        return width, height
    end

    local shape = input_info and input_info.shape or {}
    if #shape >= 4 then
        local maybe_height = tonumber(shape[#shape - 1])
        local maybe_width = tonumber(shape[#shape])
        if maybe_width and maybe_height and maybe_width > 0 and maybe_height > 0 then
            return maybe_width, maybe_height
        end
    end

    if task == "detect" or task == "obb" then
        local output_shape = outputs and outputs[1] and outputs[1].shape or nil
        local rows = infer_output_rows(output_shape)
        local inferred_width, inferred_height = infer_input_size_from_rows(rows)
        if inferred_width and inferred_height then
            return inferred_width, inferred_height
        end
    end

    local fallback = DEFAULT_INPUT_SIZE_BY_TASK[task] or 640
    return fallback, fallback
end

local function compute_resize_meta(src_width, src_height, dst_width, dst_height, resize_mode, letterbox_mode)
    resize_mode = resize_mode or "letterbox"
    letterbox_mode = letterbox_mode or "center"

    local resized_width = dst_width
    local resized_height = dst_height
    local pad_left = 0
    local pad_top = 0
    local pad_right = 0
    local pad_bottom = 0
    local scale_x
    local scale_y
    local ratio

    if resize_mode == "letterbox" then
        ratio = math.min(dst_width / src_width, dst_height / src_height)
        resized_width = math.max(1, math.floor(src_width * ratio + 0.5))
        resized_height = math.max(1, math.floor(src_height * ratio + 0.5))
        local total_pad_x = math.max(0, dst_width - resized_width)
        local total_pad_y = math.max(0, dst_height - resized_height)
        if letterbox_mode == "center" then
            pad_left = math.floor(total_pad_x / 2)
            pad_top = math.floor(total_pad_y / 2)
        end
        pad_right = total_pad_x - pad_left
        pad_bottom = total_pad_y - pad_top
        scale_x = ratio
        scale_y = ratio
    else
        scale_x = dst_width / src_width
        scale_y = dst_height / src_height
        ratio = nil
    end

    return {
        src_width = src_width,
        src_height = src_height,
        dst_width = dst_width,
        dst_height = dst_height,
        resized_width = resized_width,
        resized_height = resized_height,
        scale_x = scale_x,
        scale_y = scale_y,
        ratio = ratio,
        pad_left = pad_left,
        pad_top = pad_top,
        pad_right = pad_right,
        pad_bottom = pad_bottom,
        offset_x = pad_left,
        offset_y = pad_top,
        resize_mode = resize_mode,
        letterbox_mode = resize_mode == "letterbox" and letterbox_mode or "stretch",
    }
end

local function create_letterboxed_image(img, dst_width, dst_height, pad_color, letterbox_mode)
    local src_width, src_height = img:size()
    local meta = compute_resize_meta(src_width, src_height, dst_width, dst_height, "letterbox", letterbox_mode)
    local resized = assert(img:resize_copy(meta.resized_width, meta.resized_height))
    local canvas = image.new(dst_width, dst_height)
    canvas:replace_color(0x00000000, pad_color or 0x727272)
    canvas:draw_image(resized, {
        left = meta.pad_left,
        top = meta.pad_top,
    })
    return canvas, meta
end

local function create_stretched_image(img, dst_width, dst_height)
    local src_width, src_height = img:size()
    local meta = compute_resize_meta(src_width, src_height, dst_width, dst_height, "stretch", "stretch")
    return assert(img:resize_copy(dst_width, dst_height)), meta
end

local function prepare_image_input(self, img, overrides)
    overrides = overrides or {}
    local resize_mode = overrides.resize_mode or self.resize_mode
    local letterbox_mode = overrides.letterbox_mode or self.letterbox_mode
    local pad_color = overrides.pad_color or self.pad_color
    if resize_mode == "letterbox" then
        return create_letterboxed_image(img,
            overrides.width or self.input_width,
            overrides.height or self.input_height,
            pad_color,
            letterbox_mode)
    end
    return create_stretched_image(img,
        overrides.width or self.input_width,
        overrides.height or self.input_height)
end

local function prepare_multi_array_input(self, img, overrides)
    overrides = overrides or {}
    return assert(coreml.tensor_from_image(img, {
        width = overrides.width or self.input_width,
        height = overrides.height or self.input_height,
        resize_mode = overrides.resize_mode or self.resize_mode,
        letterbox_mode = overrides.letterbox_mode or self.letterbox_mode,
        pad_color = overrides.pad_color or self.pad_color,
        channel_order = overrides.channel_order or "rgb",
        layout = overrides.layout or "nchw",
        data_type = overrides.data_type or "float32",
        scale = overrides.scale or (1.0 / 255.0),
    }))
end

prepare_input = function(self, img, overrides)
    if self.input_type == "image" then
        return prepare_image_input(self, img, overrides)
    end
    return prepare_multi_array_input(self, img, overrides)
end

local function parse_detect_options(conf, iou, opts)
    return common.parse_detect_options(conf, iou, opts, DEFAULT_CONFIDENCE, DEFAULT_IOU)
end

local function parse_classify_options(opts)
    return common.parse_classify_options(opts)
end

enrich_detection = common.enrich_detection
enrich_obb_detection = common.enrich_obb_detection

local function make_sorted_classes_from_prob_table(prob_table, topk, label_to_id)
    local items = {}
    for label, score in pairs(prob_table or {}) do
        if type(score) == "number" then
            local class_id = label_to_id and label_to_id[label] or tonumber(label)
            if class_id ~= nil then
                class_id = tonumber(class_id)
            end
            items[#items + 1] = {
                class_id = class_id,
                label = tostring(label),
                score = score,
            }
        end
    end
    table.sort(items, function(lhs, rhs)
        return lhs.score > rhs.score
    end)
    local out = {}
    local limit = math.min(topk or 5, #items)
    for i = 1, limit do
        out[i] = items[i]
    end
    return out
end

local function build_model_info(model_path, compiled_model_path, request, task, opts)
    local input_names = assert(request:input_names())
    local output_names = assert(request:output_names())
    local input_name = assert(first_feature_name(input_names), "model has no input names")
    local input_features = assert(request:input_features())
    local output_features = assert(request:output_features())
    local input_info = input_features[input_name] or {}
    local outputs = {}
    for i = 1, #output_names do
        local info = output_features[output_names[i]] or {}
        outputs[i] = {
            name = output_names[i],
            shape = clone_array(info.shape or {}),
            type = info.type,
        }
    end
    local input_width, input_height = infer_input_hw(task, input_info, outputs, opts.input_width, opts.input_height)
    return {
        model_path = model_path,
        compiled_model_path = compiled_model_path,
        input_name = input_name,
        input_shape = clone_array(input_info.shape or {}),
        input_type = input_info.type,
        outputs = outputs,
        input_width = input_width,
        input_height = input_height,
        uses_cpu_only = opts.uses_cpu_only and true or false,
    }
end

local function assert_open(self)
    if self.closed then
        error("object is closed")
    end
end

local function pick_first_output(outputs, output_names)
    return profile_runtime.pick_first_output(outputs, output_names, "coreml predict returned no outputs")
end

classify_from_outputs = function(self, outputs, opts, profile)
    local parsed = parse_classify_options(opts)
    local probs_key = profile and profile.outputs and (profile.outputs.class_probs or profile.outputs.classify_probs or profile.outputs.probs) or nil
    local label_key = profile and profile.outputs and (profile.outputs.class_label or profile.outputs.classify_label or profile.outputs.label) or nil
    local probs = probs_key and outputs[probs_key] or outputs.classLabel_probs
    local output_label = label_key and outputs[label_key] or outputs.classLabel
    if type(probs) == "table" then
        local classes = make_sorted_classes_from_prob_table(probs, parsed.topk, self.label_to_id)
        local best = classes[1]
        return {
            class_id = best and best.class_id or nil,
            score = best and best.score or nil,
            label = best and best.label or output_label or nil,
            classes = classes,
            logits = nil,
        }
    end

    local output_spec = profile and profile.outputs and (profile.outputs.classify or profile.outputs.cls or profile.outputs.logits) or nil
    local output = output_spec and select(1, resolve_output_spec(outputs, self.output_names, output_spec, 1)) or nil
    if output == nil then
        output = pick_first_output(outputs, self.output_names)
    end
    return profile_runtime.decode_classify_tensor(
        self.decoder,
        output,
        parsed.topk,
        parsed.apply_softmax,
        self.class_names,
        flatten_tensor_to_vector,
        parsed.return_logits
    )
end

run_outputs = function(self, input_value)
    local outputs, err = self.request:predict({
        [self.model_info.input_name] = input_value,
    }, {
        multi_array_output = "MLMultiArray",
    })
    if not outputs then
        error("coreml predict failed: " .. tostring(err), 2)
    end
    return outputs
end

classify_impl = function(self, input, opts)
    local img = resolve_image_object(input)
    local input_value = select(1, prepare_input(self, img, opts))
    local outputs = run_outputs(self, input_value)
    return classify_from_outputs(self, outputs, opts, nil)
end

local function detect_impl(self, input, conf, iou, opts)
    local parsed = parse_detect_options(conf, iou, opts)
    local img = resolve_image_object(input)
    local input_value, meta = prepare_input(self, img, opts)
    local outputs = run_outputs(self, input_value)
    return profile_runtime.decode_with_decoder(
        self.decoder,
        pick_first_output(outputs, self.output_names),
        parsed,
        meta,
        self.class_names,
        enrich_detection
    )
end

local function obb_impl(self, input, conf, iou, opts)
    local parsed = parse_detect_options(conf, iou, opts)
    local img = resolve_image_object(input)
    local input_value, meta = prepare_input(self, img, opts)
    local outputs = run_outputs(self, input_value)
    return profile_runtime.decode_with_decoder(
        self.decoder,
        pick_first_output(outputs, self.output_names),
        parsed,
        meta,
        self.class_names,
        enrich_obb_detection
    )
end

local function new_instance(options)
    options = options or {}

    local profile_task = options.profile and options.profile.task or nil
    local requested_task = normalize_profile_task(options.task or profile_task or DEFAULT_TASK)
    local task, profile_base_task = default_task_for_options(requested_task, options)
    local compiled_model_path = resolve_compiled_model_path(options)
    local model_path = compiled_model_path

    local request = assert(coreml.new_model_request({
        compiled_model_path = compiled_model_path,
        uses_cpu_only = options.uses_cpu_only,
    }))

    local model_info = build_model_info(model_path, compiled_model_path, request, task, options)
    local roots = build_label_search_roots(model_path, options.model_dir)
    local class_names = resolve_class_names(task, options.class_names, roots)
    local decoder_schema = build_decoder_schema(task, options)
    local decoder = assert(coreml.create_decoder(decoder_schema))
    local profile = options.profile and deep_copy(options.profile) or nil
    if requested_task == "track" then
        profile = deep_merge({
            task = "track",
            track = {
                base_task = profile_base_task,
            },
        }, options.profile)
        if type(profile.track) == "table" and
            profile.track.task == nil and profile.track.base_task == nil then
            profile.track.base_task = profile_base_task
        end
    end

    return setmetatable({
        task = task,
        model_path = model_path,
        compiled_model_path = compiled_model_path,
        request = request,
        decoder = decoder,
        decoder_schema = decoder_schema,
        model_info = model_info,
        output_names = clone_array(request:output_names() or {}),
        input_width = model_info.input_width,
        input_height = model_info.input_height,
        input_type = model_info.input_type,
        uses_cpu_only = options.uses_cpu_only and true or false,
        confidence = tonumber(options.confidence) or DEFAULT_CONFIDENCE,
        iou = tonumber(options.iou) or DEFAULT_IOU,
        max_det = tonumber(options.max_det) or nil,
        resize_mode = options.resize_mode or ((task == "classify") and "stretch" or "letterbox"),
        letterbox_mode = options.letterbox_mode or "center",
        pad_color = options.pad_color or 0x727272,
        profile = profile,
        tracker = options.tracker and tracker_module.tracker(options.tracker) or nil,
        class_names = class_names,
        label_to_id = build_label_to_id(class_names),
        closed = false,
    }, instance_mt)
end

function instance_mt:run(input, arg1, arg2, arg3)
    assert_open(self)
    return profile_runtime.run_unprofiled_entry(self, input, arg1, arg2, arg3, {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
        detect_impl = detect_impl,
        classify_impl = classify_impl,
        obb_impl = obb_impl,
    })
end

function instance_mt:detect(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_detect_entry(self, input, conf, iou, opts, {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
        detect_impl = detect_impl,
    })
end

function instance_mt:predict(input, conf, iou, opts)
    return self:run(input, conf, iou, opts)
end

function instance_mt:classify(input, opts)
    assert_open(self)
    return profile_runtime.run_classify_entry(self, input, opts, {
        run_profile_task = run_profile_task,
        classify_impl = classify_impl,
    })
end

function instance_mt:segment(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_profiled_entry(self, input, conf, iou, opts, "seg", {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
    })
end

function instance_mt:pose(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_profiled_entry(self, input, conf, iou, opts, "pose", {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
    })
end

function instance_mt:track(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_profiled_entry(self, input, conf, iou, opts, "track", {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
    })
end

function instance_mt:detect_obb(input, conf, iou, opts)
    assert_open(self)
    return obb_impl(self, input, conf, iou, opts)
end

function instance_mt:obb(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_obb_entry(self, input, conf, iou, opts, {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
        obb_impl = obb_impl,
    })
end

function instance_mt:get_model_info()
    assert_open(self)
    return profile_runtime.build_public_model_info(self, function(output)
        return {
            name = output.name,
            shape = clone_array(output.shape or {}),
            type = output.type,
        }
    end, deep_copy)
end

function instance_mt:close()
    return profile_runtime.close_instance(self, {
        fields = {
            "request",
            "decoder",
            "decoder_schema",
            "model_info",
            "output_names",
        },
    })
end

function instance_mt:__tostring()
    if self.closed then
        return "yolo_coreml{closed}"
    end
    return "yolo_coreml{open}"
end

local M = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

function M.supported_tasks()
    return profile_runtime.supported_tasks()
end

function M.new(opts)
    return new_instance(opts)
end

function M.compile_model_cached(model_path)
    return compile_model_cached(model_path)
end

function M.clear_compiled_model_cache(model_path)
    return clear_compiled_model_cache(model_path)
end

M.tracker = tracker_module.tracker

M.create = M.new
M.open = M.new

return M
