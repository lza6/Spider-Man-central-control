--[[
yolo_onnx.lua

Created by 苏泽 on 26-03-30.
Copyright (c) 2026年 苏泽. All rights reserved.

基于 XXTouch 内置 onnxruntime 模块的 YOLO 封装。

支持任务:
- detect
- classify
- obb

构造参数:
- model_path = "/path/to/model.onnx"
- model_dir = "/path/to/model_dir"
- task = "detect" | "classify" | "obb"
- class_names = {"a", "b"} 或 "/path/to/classes.txt" 或 "coco80"/"imagenet1000"/"dota15"
- providers = {"cpu"} 或 {"coreml", "cpu"}
- fallback_to_cpu = true/false
- threads = integer
- input_width = integer
- input_height = integer
- confidence = number
- iou = number
- max_det = integer
- class_ids = {0, 1, 2}
- class_agnostic = true/false
- coreml_compute_units = "all" | "cpu_only" | "cpu_and_gpu" | "cpu_and_neural_engine"
- coreml_enable_on_subgraph = true/false
- coreml_require_static_input_shapes = true/false
- coreml_create_mlprogram = true/false

说明:
- 以上 CoreML 参数会原样透传给 onnxruntime.session(...)

示例:
local yolo_onnx = require("yolo_onnx")

local detector = assert(yolo_onnx.new({
    model_path = XXT_HOME_PATH.."/models/yolo_onnx/yolo11n.onnx",
}))
local detections = assert(detector:detect(XXT_HOME_PATH.."/models/yolo_onnx/bus.jpg"))
detector:close()

local classifier = assert(yolo_onnx.new({
    model_path = XXT_HOME_PATH.."/models/yolo_onnx/yolo11n-cls.onnx",
    task = "classify",
}))
local result = assert(classifier:classify(XXT_HOME_PATH.."/models/yolo_onnx/bus.jpg", {
    return_logits = true,
}))
print(result.class_id, result.score)
classifier:close()
]]

local ort = require("onnxruntime")
local tracker_module = require("yolo_tracker")
local profile_runtime = require("yolo_profile_runtime")
local common = require("yolo_backend_common")

local VERSION = "0.1.2"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/yolo_onnx"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/yolo_onnx"

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

local PROVIDERS = ort.providers()
local COREML_SESSION_OPTION_KEYS = {
    "coreml_compute_units",
    "coreml_enable_on_subgraph",
    "coreml_require_static_input_shapes",
    "coreml_create_mlprogram",
}

local instance_mt = {}
instance_mt.__index = instance_mt

local run_outputs
local enrich_detection
local enrich_obb_detection
local classify_impl

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
local resolve_image_object = common.resolve_image_object
local flatten_tensor_to_vector = common.flatten_tensor_to_vector
local normalize_provider_list = common.normalize_provider_list
local provider_list_contains = common.provider_list_contains
local has_provider = function(full_name)
    return common.available_provider_names_contains(PROVIDERS, full_name)
end

local function build_search_roots(opts)
    return common.build_search_roots(opts, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT)
end

local function resolve_model_path(opts)
    if opts.model_path and opts.model_path ~= "" then
        if not file_exists(opts.model_path) then
            error("model file not found: " .. opts.model_path)
        end
        return opts.model_path
    end

    local roots = build_search_roots(opts)
    for i = 1, #roots do
        local root = roots[i]
        if root and root ~= "" then
            local candidate = root .. "/model.onnx"
            if file_exists(candidate) then
                return candidate
            end
        end
    end

    error("model file not found: specify model_path")
end

local function build_session_options(opts)
    return common.build_ort_session_options(opts, COREML_SESSION_OPTION_KEYS, {
        intra_op_num_threads = 1,
        graph_optimization_level = "all",
    })
end

local function build_model_info(model_path, session, opts, used_coreml)
    return common.build_ort_model_info(model_path, session, opts, used_coreml)
end

local function assert_open(self)
    if self.closed then
        error("object is closed")
    end
end

local function build_label_search_roots(model_path, model_dir)
    return common.build_label_search_roots(model_path, model_dir, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT)
end

local function resolve_class_names(task, class_names, roots)
    local explicit_class_names = class_names ~= nil
    return common.resolve_class_names(task, class_names, roots, {
        default_class_preset_by_task = DEFAULT_CLASS_PRESET_BY_TASK,
        class_name_presets = CLASS_NAME_PRESETS,
        error_on_missing_path = explicit_class_names,
    })
end

local function default_resize_mode_for_task(task)
    if task == "classify" then
        return "stretch"
    end
    return "letterbox"
end

local function infer_input_hw(shape, fallback_width, fallback_height)
    local width = fallback_width or DEFAULT_INPUT_SIZE_BY_TASK.detect
    local height = fallback_height or DEFAULT_INPUT_SIZE_BY_TASK.detect
    if #shape >= 4 then
        local maybe_height = tonumber(shape[3])
        local maybe_width = tonumber(shape[4])
        if maybe_height and maybe_height > 0 then
            height = maybe_height
        end
        if maybe_width and maybe_width > 0 then
            width = maybe_width
        end
    end
    return width, height
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

local function default_task_for_options(requested_task, opts)
    if requested_task ~= "track" then
        return requested_task
    end
    local track_profile = opts.profile and opts.profile.track or nil
    local base_task = track_profile and (track_profile.task or track_profile.base_task) or
        opts.track_task or opts.base_task
    if base_task == nil then
        return "detect"
    end
    base_task = normalize_profile_task(base_task)
    if base_task == "track" then
        return "detect"
    end
    if base_task == "classify" then
        error("track requires detect, seg, pose or obb task")
    end
    return base_task
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

local function prepare_profile_input_tensor(self, img, profile, overrides)
    overrides = overrides or {}
    local input_profile = profile.input or {}
    return ort.tensor_from_image(img, {
        width = tonumber(overrides.width or input_profile.width) or self.input_width,
        height = tonumber(overrides.height or input_profile.height) or self.input_height,
        layout = overrides.layout or input_profile.layout or "nchw",
        add_batch = true,
        channel_order = overrides.channel_order or input_profile.channel_order or "rgb",
        data_type = overrides.data_type or input_profile.data_type or "float32",
        scale = overrides.scale or input_profile.scale or (1.0 / 255.0),
        resize_mode = overrides.resize_mode or input_profile.resize_mode or "letterbox",
        letterbox_mode = overrides.letterbox_mode or input_profile.letterbox_mode,
        pad_color = overrides.pad_color or input_profile.pad_color or 0x727272,
    })
end

local function materialize_detect_detections(self, bundle, meta)
    return profile_runtime.materialize_detect_detections(
        ort,
        self.class_names,
        bundle,
        meta,
        build_transform_options
    )
end

local function materialize_obb_detections(self, bundle, meta, profile)
    return profile_runtime.materialize_obb_detections(
        ort,
        self.class_names,
        bundle,
        meta,
        profile,
        enrich_obb_detection
    )
end

local function decode_dense_matrix_profile(self, matrix, meta, profile, runtime_task)
    local task = runtime_task or profile.task
    local bundle = assert(ort.decode_matrix_candidates(
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
        ort,
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
        ort,
        state,
        profile,
        meta,
        build_transform_options,
        select_feature_columns
    )
end

local function decode_anchor_grid_profile(self, det_output, meta, profile)
    return profile_runtime.decode_anchor_grid_profile(
        ort,
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
    backend_name = "onnx",
    resolve_profile = resolve_profile,
    resolve_runtime_task = resolve_runtime_task,
    resolve_image_object = resolve_image_object,
    prepare_profile_input = prepare_profile_input_tensor,
    run_outputs = function(instance, tensor)
        return run_outputs(instance, tensor)
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

run_outputs = function(self, tensor)
    local outputs, err = self.session:run({
        [self.model_info.input_name] = tensor,
    }, self.output_names)
    if not outputs then
        error("onnx run failed: " .. tostring(err), 2)
    end
    return outputs
end

local function pick_first_output(outputs, output_names)
    return profile_runtime.pick_first_output(outputs, output_names, "onnx run returned no outputs")
end

local function prepare_input_tensor(self, img)
    return ort.tensor_from_image(img, {
        width = self.input_width,
        height = self.input_height,
        layout = "nchw",
        add_batch = true,
        channel_order = "rgb",
        data_type = "float32",
        scale = 1.0 / 255.0,
        resize_mode = default_resize_mode_for_task(self.task),
        pad_color = 0x727272,
    })
end

local function parse_detect_options(conf, iou, opts)
    return common.parse_detect_options(conf, iou, opts, DEFAULT_CONFIDENCE, DEFAULT_IOU)
end

local function parse_classify_options(opts)
    return common.parse_classify_options(opts)
end

classify_from_outputs = function(self, outputs, opts, profile)
    local parsed = parse_classify_options(opts)
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

enrich_detection = common.enrich_detection
enrich_obb_detection = common.enrich_obb_detection

classify_impl = function(self, input, opts)
    local img = resolve_image_object(input)
    local tensor = prepare_input_tensor(self, img)
    local outputs = run_outputs(self, tensor)
    return classify_from_outputs(self, outputs, opts, nil)
end

local function detect_impl(self, input, conf, iou, opts)
    local parsed = parse_detect_options(conf, iou, opts)
    local img = resolve_image_object(input)
    local tensor, meta = prepare_input_tensor(self, img)
    local outputs = run_outputs(self, tensor)
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
    local tensor, meta = prepare_input_tensor(self, img)
    local outputs = run_outputs(self, tensor)
    return profile_runtime.decode_with_decoder(
        self.decoder,
        pick_first_output(outputs, self.output_names),
        parsed,
        meta,
        self.class_names,
        enrich_obb_detection
    )
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
    local info = profile_runtime.build_public_model_info(self, function(output)
        local item = {
            name = output.name,
            shape = clone_array(output.shape or {}),
        }
        return item
    end, deep_copy)
    info.providers = clone_array(self.model_info.providers or {})
    return info
end

function instance_mt:close()
    return profile_runtime.close_instance(self, {
        before_close = function(instance)
            if instance.session then
                instance.session:close()
            end
        end,
        fields = {
            "session",
            "decoder",
            "decoder_schema",
            "model_info",
            "output_names",
            "class_names",
        },
    })
end

function instance_mt:__tostring()
    if self.closed then
        return "yolo_onnx{closed}"
    end
    return "yolo_onnx{open}"
end

local M = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

function M.supported_tasks()
    return profile_runtime.supported_tasks()
end

function M.new(opts)
    opts = opts or {}
    if opts.use_gpu ~= nil then
        error("use_gpu has been removed; pass providers = {\"coreml\", \"cpu\"} or providers = {\"cpu\"} explicitly")
    end
    local model_path = resolve_model_path(opts)
    local profile_task = opts.profile and opts.profile.task or nil
    local requested_task = normalize_profile_task(opts.task or profile_task or DEFAULT_TASK)
    local default_task = default_task_for_options(requested_task, opts)
    local task = normalize_task(base_task_for_profile_task(default_task))
    if not SUPPORTED_TASKS[task] then
        error("unsupported yolo task: " .. tostring(task))
    end
    local class_name_roots = build_label_search_roots(model_path, opts.model_dir)
    local session = assert(ort.session(model_path, build_session_options(opts)))
    local requested_providers = normalize_provider_list(opts.providers)
    local used_coreml = provider_list_contains(requested_providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local model_info = build_model_info(model_path, session, opts, used_coreml)
    local fallback_size = DEFAULT_INPUT_SIZE_BY_TASK[default_task] or DEFAULT_INPUT_SIZE_BY_TASK.detect
    local input_width, input_height = infer_input_hw(
        model_info.input_shape,
        opts.input_width or fallback_size,
        opts.input_height or fallback_size
    )
    local decoder_schema = build_decoder_schema(task, opts)
    local decoder = assert(ort.create_decoder(decoder_schema))
    local profile = opts.profile and deep_copy(opts.profile) or nil
    if requested_task == "track" then
        profile = deep_merge({
            task = "track",
            track = {
                base_task = default_task,
            },
        }, opts.profile)
    end
    return setmetatable({
        closed = false,
        session = session,
        decoder = decoder,
        decoder_schema = decoder_schema,
        output_names = session:output_names(),
        model_info = model_info,
        input_width = input_width,
        input_height = input_height,
        task = task,
        profile = profile,
        confidence = tonumber(opts.confidence) or DEFAULT_CONFIDENCE,
        iou = tonumber(opts.iou) or DEFAULT_IOU,
        max_det = tonumber(opts.max_det) or nil,
        tracker = opts.tracker and tracker_module.tracker(opts.tracker) or nil,
        class_names = resolve_class_names(default_task, opts.class_names, class_name_roots),
    }, instance_mt)
end

    M.tracker = tracker_module.tracker

M.create = M.new
M.open = M.new

return M
