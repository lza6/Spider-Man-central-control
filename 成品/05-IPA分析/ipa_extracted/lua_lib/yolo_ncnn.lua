--[[
yolo_ncnn.lua

基于 XXTouch 内置 ncnn 模块的 YOLO 封装。

支持任务:
- detect
- classify
- obb
- segment
- pose
- track

构造参数:
- model_dir = "/path/to/model_dir"
- param_path = "/path/to/model.param" 或 "/path/to/model.param.bin"
- model_path = "/path/to/model.bin"
- input_name = "in0"
- output_names = {"out0"}
- task = "detect" | "classify" | "obb" | "segment" | "pose" | "track"
- class_names = {"a", "b"} 或 "/path/to/classes.txt" 或 "coco80"/"imagenet1000"/"dota15"
- profile = table，用于描述非常规输出布局
- use_vulkan_compute = true/false
- fallback_to_cpu = true/false
- threads = integer
- input_width = integer
- input_height = integer
- confidence = number
- iou = number
- max_det = integer
- class_ids = {0, 1, 2}
- class_agnostic = true/false
- resize_mode = "stretch" | "letterbox"
- letterbox_mode = "center" | "top_left"
- pad_color = 0x727272
]]

local ncnn = require("ncnn")
local tracker_module = require("yolo_tracker")
local common = require("yolo_backend_common")
local profile_runtime = require("yolo_profile_runtime")

local VERSION = "0.1.0"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/yolo_ncnn"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/yolo_ncnn"

local DEFAULT_CONFIDENCE = 0.25
local DEFAULT_IOU = 0.45
local DEFAULT_TASK = "detect"

local DEFAULT_INPUT_SIZE_BY_TASK = {
    detect = 640,
    seg = 640,
    pose = 640,
    track = 640,
    classify = 224,
    obb = 1024,
}

local DEFAULT_CLASS_PRESET_BY_TASK = {
    detect = "coco80",
    seg = "coco80",
    pose = "coco80",
    track = "coco80",
    classify = "imagenet1000",
    obb = "dota15",
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

local file_exists = common.file_exists
local resolve_image_object = common.resolve_image_object
local clone_array = common.clone_array
local flatten_tensor_to_vector = common.flatten_tensor_to_vector
local deep_copy = profile_runtime.deep_copy
local deep_merge = profile_runtime.deep_merge
local normalize_profile_task = profile_runtime.normalize_profile_task
local parse_task_call_options = profile_runtime.parse_task_call_options
local resolve_output_spec = profile_runtime.resolve_output_spec
local build_runtime_decoder_schema = profile_runtime.build_runtime_decoder_schema
local resolve_runtime_task = profile_runtime.resolve_runtime_task
local select_feature_columns = profile_runtime.select_feature_columns
local build_transform_options = profile_runtime.build_transform_options

local normalize_task = function(task)
    return normalize_profile_task(task or DEFAULT_TASK)
end

local function decoder_task_for_task(task)
    task = normalize_task(task)
    if task == "seg" or task == "pose" or task == "track" then
        return "detect"
    end
    return task
end

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

local function build_search_roots(opts)
    return common.build_search_roots(opts, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT)
end

local function resolve_model_files(opts)
    if opts.param_path and opts.param_path ~= "" then
        if not file_exists(opts.param_path) then
            error("param file not found: " .. opts.param_path)
        end
        if type(opts.model_path) ~= "string" or opts.model_path == "" then
            error("model_path is required when param_path is specified")
        end
        if not file_exists(opts.model_path) then
            error("model file not found: " .. opts.model_path)
        end
        return opts.param_path, opts.model_path
    end

    local roots = build_search_roots(opts)
    for i = 1, #roots do
        local root = roots[i]
        if root and root ~= "" then
            local bin = root .. "/model.bin"
            local plain = root .. "/model.param"
            local binary = root .. "/model.param.bin"
            if file_exists(bin) and file_exists(plain) then
                return plain, bin
            end
            if file_exists(bin) and file_exists(binary) then
                return binary, bin
            end
        end
    end

    error("ncnn model not found: specify model_dir or param_path/model_path")
end

local function build_label_search_roots(param_path, model_dir)
    return common.build_label_search_roots(param_path, model_dir, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT)
end

local function resolve_class_names(task, class_names, roots)
    local explicit_class_names = class_names ~= nil
    return common.resolve_class_names(task, class_names, roots, {
        default_class_preset_by_task = DEFAULT_CLASS_PRESET_BY_TASK,
        class_name_presets = CLASS_NAME_PRESETS,
        error_on_missing_path = explicit_class_names,
    })
end

local function infer_input_size(task, opts)
    local fallback = DEFAULT_INPUT_SIZE_BY_TASK[task] or 640
    return tonumber(opts.input_width or opts.width) or fallback,
        tonumber(opts.input_height or opts.height) or fallback
end

local function default_output_names_for_task(task)
    if task == "seg" then
        return {"out0", "out1"}
    end
    return {"out0"}
end

local function default_task_for_options(task, opts)
    if task ~= "track" then
        return task
    end
    local profile_track = opts.profile and opts.profile.track or nil
    local base_task = profile_track and (profile_track.task or profile_track.base_task) or
        opts.track_task or opts.base_task
    if base_task == nil then
        return "detect"
    end
    base_task = normalize_task(base_task)
    if base_task == "track" then
        return "detect"
    end
    if base_task == "classify" then
        error("track requires detect, seg, pose or obb task")
    end
    return base_task
end

local function build_decoder_schema(task, opts)
    return common.build_decoder_schema(decoder_task_for_task(task), opts, DECODER_SCHEMA_KEYS, function(value)
        return decoder_task_for_task(value)
    end)
end

local function default_profile_fields_for_task(task, class_names, opts)
    local profile = {task = task}
    if task == "seg" then
        local class_count = tonumber(opts.class_count) or (class_names and #class_names) or 80
        local coeff_dim = tonumber(opts.mask_coeff_dim) or tonumber(opts.coeff_dim) or 32
        local coeff_start = 4 + class_count
        profile.outputs = {det = 1, proto = 2}
        profile.decode = {
            class_start = 4,
            class_end = coeff_start,
        }
        profile.seg = {
            coeff_start = coeff_start,
            coeff_dim = coeff_dim,
            threshold = tonumber(opts.mask_threshold) or 0.0,
        }
    elseif task == "pose" then
        local keypoint_count = tonumber(opts.keypoint_count) or 17
        local keypoint_dim = tonumber(opts.keypoint_dim) or 3
        profile.outputs = {det = 1}
        profile.decode = {
            class_start = 4,
            class_end = tonumber(opts.pose_class_end) or 5,
        }
        profile.pose = {
            keypoint_start = tonumber(opts.keypoint_start) or profile.decode.class_end,
            keypoint_count = keypoint_count,
            keypoint_dim = keypoint_dim,
        }
    end
    return profile
end

local function default_profile_for_task(task, default_task, class_names, opts)
    if task ~= "seg" and task ~= "pose" and task ~= "track" then
        return opts.profile
    end
    local profile
    if task == "track" then
        profile = default_profile_fields_for_task(default_task, class_names, opts)
        profile.task = "track"
        profile.track = profile.track or {}
        profile.track.base_task = default_task
    else
        profile = default_profile_fields_for_task(task, class_names, opts)
    end
    return deep_merge(profile, opts.profile)
end

local function assert_open(self)
    if self.closed then
        error("object is closed")
    end
end

local function default_resize_mode_for_task(task)
    if task == "classify" then
        return "stretch"
    end
    return "letterbox"
end

local function normalize_chw_layout(layout)
    layout = layout or "nchw"
    if layout ~= "nchw" and layout ~= "chw" then
        error("yolo_ncnn only supports CHW input; layout=" .. tostring(layout) .. " is invalid", 3)
    end
    return layout
end

local function prepare_input_mat(self, img, overrides)
    overrides = overrides or {}
    if overrides.add_batch == true then
        error("yolo_ncnn only supports batchless CHW input; add_batch=true is invalid", 2)
    end
    return ncnn.mat_from_image(img, {
        width = tonumber(overrides.width) or self.input_width,
        height = tonumber(overrides.height) or self.input_height,
        layout = normalize_chw_layout(overrides.layout or self.layout),
        add_batch = false,
        channel_order = overrides.channel_order or self.channel_order or "rgb",
        scale = overrides.scale or self.scale or (1.0 / 255.0),
        resize_mode = overrides.resize_mode or self.resize_mode or default_resize_mode_for_task(self.task),
        letterbox_mode = overrides.letterbox_mode or self.letterbox_mode,
        pad_color = overrides.pad_color or self.pad_color or 0x727272,
        mean = overrides.mean or self.mean,
        std = overrides.std or self.std,
    })
end

local function run_outputs(self, mat)
    local outputs, err = self.net:run({
        [self.input_name] = mat,
    }, self.output_names)
    if not outputs then
        error("ncnn run failed: " .. tostring(err), 2)
    end
    return outputs
end

local function pick_output(outputs, output_names, index)
    index = index or 1
    local name = output_names[index]
    local output = name and outputs[name] or nil
    if output == nil then
        output = outputs[index]
    end
    if output == nil then
        error("ncnn run returned no output at index " .. tostring(index), 2)
    end
    return output
end

local function transform_options(meta)
    return {
        offset_x = meta.offset_x or 0,
        offset_y = meta.offset_y or 0,
        scale_x = meta.scale_x or meta.ratio or 1,
        scale_y = meta.scale_y or meta.ratio or 1,
        clip_width = meta.src_width,
        clip_height = meta.src_height,
    }
end

local PROFILE_RESOLVE_OPTIONS = {
    default_task = DEFAULT_TASK,
    default_confidence = DEFAULT_CONFIDENCE,
    default_iou = DEFAULT_IOU,
    default_resize_mode = function(_, profile)
        return default_resize_mode_for_task(profile.task)
    end,
    default_pad_color = 0x727272,
}

local function resolve_profile(self, call_opts, forced_task)
    return profile_runtime.resolve_profile(
        self,
        call_opts,
        forced_task,
        PROFILE_RESOLVE_OPTIONS
    )
end

local function prepare_profile_input_mat(self, img, profile, overrides)
    overrides = overrides or {}
    local input_profile = profile.input or {}
    if overrides.add_batch == true or input_profile.add_batch == true then
        error("yolo_ncnn only supports batchless CHW input; add_batch=true is invalid", 2)
    end
    return ncnn.mat_from_image(img, {
        width = tonumber(overrides.width or input_profile.width) or self.input_width,
        height = tonumber(overrides.height or input_profile.height) or self.input_height,
        layout = normalize_chw_layout(overrides.layout or input_profile.layout or self.layout),
        add_batch = false,
        channel_order = overrides.channel_order or input_profile.channel_order or self.channel_order or "rgb",
        data_type = overrides.data_type or input_profile.data_type or "float32",
        scale = overrides.scale or input_profile.scale or self.scale or (1.0 / 255.0),
        resize_mode = overrides.resize_mode or input_profile.resize_mode or self.resize_mode or
            default_resize_mode_for_task(profile.task),
        letterbox_mode = overrides.letterbox_mode or input_profile.letterbox_mode or self.letterbox_mode,
        pad_color = overrides.pad_color or input_profile.pad_color or self.pad_color or 0x727272,
        mean = overrides.mean or input_profile.mean or self.mean,
        std = overrides.std or input_profile.std or self.std,
    })
end

local function attach_detection_labels(detections, class_names)
    for i = 1, #(detections or {}) do
        local det = detections[i]
        local label = class_names and class_names[(det.class_id or 0) + 1]
        if label then
            det.label = label
        end
    end
    return detections
end

local function materialize_detect_detections(self, bundle, meta)
    return profile_runtime.materialize_detect_detections(
        ncnn,
        self.class_names,
        bundle,
        meta,
        build_transform_options
    )
end

local function materialize_obb_detections(self, bundle, meta, profile)
    return profile_runtime.materialize_obb_detections(
        ncnn,
        self.class_names,
        bundle,
        meta,
        profile,
        common.enrich_obb_detection
    )
end

local function decode_dense_matrix_profile(self, matrix, meta, profile, runtime_task)
    local task = runtime_task or profile.task
    local bundle = assert(ncnn.decode_matrix_candidates(
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
        ncnn,
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
        ncnn,
        state,
        profile,
        meta,
        build_transform_options,
        select_feature_columns
    )
end

local function decode_anchor_grid_profile()
    error("ncnn yolo profile currently requires decoded_matrix outputs")
end

local function decode_with_decoder(self, output, opts, meta)
    opts = opts or {}
    local class_aware = opts.class_aware
    if class_aware == nil then
        class_aware = not self.class_agnostic
    end
    local decode_opts = {
        confidence = opts.confidence or opts.conf or self.confidence,
        iou_threshold = opts.iou_threshold or opts.iou or self.iou,
        max_det = opts.max_det or self.max_det,
        class_ids = opts.class_ids or self.class_ids,
        class_aware = class_aware,
        top_k = opts.top_k,
        apply_softmax = opts.apply_softmax,
    }
    if self.task ~= "obb" then
        for key, value in pairs(transform_options(meta)) do
            decode_opts[key] = value
        end
    end
    local decoded = assert(self.decoder:decode(output, decode_opts))
    if self.task == "obb" then
        return profile_runtime.enrich_detections(
            decoded,
            meta,
            self.class_names,
            common.enrich_obb_detection
        )
    end
    return attach_detection_labels(decoded, self.class_names)
end

local function parse_detect_args(self, conf, iou, opts)
    local parsed = opts or {}
    if type(conf) == "table" then
        parsed = conf
    else
        parsed.confidence = conf or parsed.confidence or self.confidence
        parsed.iou = iou or parsed.iou or self.iou
    end
    return parsed
end

local parse_classify_options = common.parse_classify_options

local function detect_impl(self, input, conf, iou, opts)
    local parsed = parse_detect_args(self, conf, iou, opts)
    local img = resolve_image_object(input)
    local mat, meta = assert(prepare_input_mat(self, img, parsed))
    local outputs = run_outputs(self, mat)
    return decode_with_decoder(self, pick_output(outputs, self.output_names, 1), parsed, meta)
end

local function classify_from_outputs(self, outputs, opts, profile)
    local parsed = parse_classify_options(opts)
    local output_spec = profile and profile.outputs and
        (profile.outputs.classify or profile.outputs.cls or profile.outputs.logits) or nil
    local output = output_spec and select(1, resolve_output_spec(outputs, self.output_names, output_spec, 1)) or nil
    if output == nil then
        output = pick_output(outputs, self.output_names, 1)
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

local function classify_impl(self, input, opts)
    opts = opts or {}
    local img = resolve_image_object(input)
    local mat = assert(prepare_input_mat(self, img, opts))
    local outputs = run_outputs(self, mat)
    return classify_from_outputs(self, outputs, opts, nil)
end

local PROFILE_RUN_HOOKS = {
    backend_name = "ncnn",
    resolve_profile = resolve_profile,
    resolve_runtime_task = resolve_runtime_task,
    resolve_image_object = resolve_image_object,
    prepare_profile_input = prepare_profile_input_mat,
    run_outputs = function(instance, mat)
        return run_outputs(instance, mat)
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

function instance_mt:run(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_unprofiled_entry(self, input, conf, iou, opts, {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
        detect_impl = detect_impl,
        classify_impl = classify_impl,
        obb_impl = detect_impl,
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

function instance_mt:obb(input, conf, iou, opts)
    assert_open(self)
    return profile_runtime.run_obb_entry(self, input, conf, iou, opts, {
        parse_task_call_options = parse_task_call_options,
        run_profile_task = run_profile_task,
        obb_impl = detect_impl,
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

function instance_mt:get_model_info()
    assert_open(self)
    local info = profile_runtime.build_public_model_info(self, function(output)
        return {
            name = output.name,
            shape = clone_array(output.shape or {}),
        }
    end, deep_copy)
    info.param_path = self.param_path
    info.model_path = self.model_path
    info.output_names = clone_array(self.output_names)
    info.input_width = self.input_width
    info.input_height = self.input_height
    info.task = self.task
    info.profile = deep_copy(self.profile)
    info.use_vulkan_compute = self.use_vulkan_compute
    return info
end

function instance_mt:close()
    if self.closed then
        return true
    end
    self.closed = true
    if self.tracker and self.tracker.close then
        pcall(self.tracker.close, self.tracker)
    end
    self.tracker = nil
    if self.net then
        self.net:close()
    end
    self.net = nil
    return true
end

local M = {
    _VERSION = VERSION,
}

function M.new(opts)
    opts = opts or {}
    local profile_task = opts.profile and opts.profile.task or nil
    local task = normalize_task(opts.task or profile_task)
    local default_task = default_task_for_options(task, opts)
    local param_path, model_path = resolve_model_files(opts)
    local class_names = resolve_class_names(
        default_task,
        opts.class_names,
        build_label_search_roots(param_path, opts.model_dir)
    )
    local input_width, input_height = infer_input_size(default_task, opts)
    local output_names = opts.output_names or default_output_names_for_task(default_task)
    local profile = default_profile_for_task(task, default_task, class_names, opts)
    if opts.add_batch == true or (profile and profile.input and profile.input.add_batch == true) then
        error("yolo_ncnn only supports batchless CHW input; add_batch=true is invalid", 2)
    end
    local layout = normalize_chw_layout(opts.layout)
    if profile and profile.input then
        normalize_chw_layout(profile.input.layout)
    end
    local net = assert(ncnn.net({
        param_path = param_path,
        model_path = model_path,
        use_vulkan_compute = opts.use_vulkan_compute == true,
        fallback_to_cpu = opts.fallback_to_cpu ~= false,
        gpu_device = opts.gpu_device or 0,
        threads = opts.threads or 1,
        light_mode = opts.light_mode ~= false,
    }))

    local self = {
        closed = false,
        net = net,
        param_path = param_path,
        model_path = model_path,
        input_name = opts.input_name or "in0",
        output_names = output_names,
        task = task,
        input_width = input_width,
        input_height = input_height,
        class_names = class_names,
        profile = profile,
        confidence = opts.confidence or DEFAULT_CONFIDENCE,
        iou = opts.iou or DEFAULT_IOU,
        max_det = opts.max_det,
        class_ids = opts.class_ids,
        class_agnostic = opts.class_agnostic == true,
        resize_mode = opts.resize_mode,
        letterbox_mode = opts.letterbox_mode,
        pad_color = opts.pad_color,
        channel_order = opts.channel_order,
        layout = layout,
        scale = opts.scale,
        mean = opts.mean,
        std = opts.std,
        use_vulkan_compute = opts.use_vulkan_compute == true and ncnn.has_vulkan(),
        decoder = assert(ncnn.create_decoder(build_decoder_schema(task, opts))),
    }
    local outputs = {}
    for i = 1, #output_names do
        outputs[i] = {
            name = output_names[i],
            shape = opts.output_shapes and clone_array(opts.output_shapes[i] or {}) or {},
        }
    end
    self.model_info = {
        backend = "ncnn",
        param_path = param_path,
        model_path = model_path,
        input_name = self.input_name,
        input_shape = {3, input_height, input_width},
        outputs = outputs,
        providers = {self.use_vulkan_compute and "vulkan" or "cpu"},
    }
    return setmetatable(self, instance_mt)
end

function M.version()
    return VERSION
end

function M.backend_version()
    return ncnn.version()
end

function M.has_vulkan()
    return ncnn.has_vulkan()
end

function M.supported_tasks()
    return profile_runtime.supported_tasks()
end

return M
