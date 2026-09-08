--[[
captcha_recognizer.lua

Created by 苏泽 on 26-03-30.
Copyright (c) 2026年 苏泽. All rights reserved.

基于 XXTouch 内置 onnxruntime 模块的 captcha-recognizer 封装。

原项目地址:
https://github.com/chenwei-zhao/captcha-recognizer

模型文件在这里下载:
https://github.com/chenwei-zhao/captcha-recognizer/tree/main/captcha_recognizer/models

把以下模型文件放到
/var/mobile/Media/1ferver/models/captcha_recognizer/slider.onnx

基础用法:

local captcha_recognizer = require("captcha_recognizer")
local model = captcha_recognizer.Slider() -- 或者 captcha_recognizer.new({ type = "slider" })

local box, confidence = model:identify("/path/to/image.png")
local offset, confidence = model:identify_offset("/path/to/image.png")
model:close()

支持输入:
- 文件路径
- 图片原始字节
- BASE64 字符串
- image 对象

构造参数:
- type = "slider"
- model_path = "/path/to/slider.onnx"
- model_dir = "/path/to/model_dir"
- providers = {"cpu"} 或 {"coreml", "cpu"}
- fallback_to_cpu = true/false
- coreml_compute_units = "all" | "cpu_only" | "cpu_and_gpu" | "cpu_and_neural_engine"
- coreml_enable_on_subgraph = true/false
- coreml_require_static_input_shapes = true/false
- coreml_create_mlprogram = true/false

说明:
- 以上 CoreML 参数会原样透传给 onnxruntime.session(...)
]]

local cv = require("image.cv")
local ort = require("onnxruntime")
local common = require("yolo_backend_common")

local VERSION = "0.1.3"
local INPUT_SIZE = 640
local DEFAULT_CONFIDENCE = 0.5
local DEFAULT_IOU = 0.8
local DEFAULT_Y_IOU = 0.85
local DEFAULT_MASK_COMPARE_SIZE = 64
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/captcha_recognizer"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/captcha_recognizer"
local DEFAULT_MODEL_FILE = "slider.onnx"

local PROVIDERS = ort.providers()
local COREML_SESSION_OPTION_KEYS = {
    "coreml_compute_units",
    "coreml_enable_on_subgraph",
    "coreml_require_static_input_shapes",
    "coreml_create_mlprogram",
}

local SLIDER_DECODER_SCHEMA = {
    task = "detect",
    prediction_layout = "auto",
    box_format = "cxcywh",
    score_mode = "class_only",
    class_start = 4,
    class_end = 5,
}

local instance_mt = {}
instance_mt.__index = instance_mt

local file_exists = common.file_exists
local shallow_copy_table = common.shallow_copy_table
local clone_array = common.clone_array
local normalize_provider_list = common.normalize_provider_list
local provider_list_contains = common.provider_list_contains
local resolve_image_object = common.resolve_image_input
local has_provider = function(full_name)
    return common.available_provider_names_contains(PROVIDERS, full_name)
end

local function ensure_image(input)
    return resolve_image_object(input)
end

local function clone_image_object(img)
    if type(img.copy) == "function" then
        local ok, copied = pcall(img.copy, img)
        if ok and copied then
            return copied
        end
    end
    local png_data = img and img.png_data and img:png_data()
    if png_data then
        return image.load_data(png_data)
    end
    error("图片复制失败: 传入对象缺少 copy() 和 png_data()")
end

local function build_session_options(opts)
    return common.build_ort_session_options(opts, COREML_SESSION_OPTION_KEYS, {
        intra_op_num_threads = 1,
        graph_optimization_level = "all",
    })
end

local function resolve_model_path(opts)
    local explicit = opts.model_path
    if explicit and explicit ~= "" then
        if not file_exists(explicit) then
            error("模型文件不存在: " .. tostring(explicit))
        end
        return explicit
    end

    local roots = common.build_search_roots(opts, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT)

    for i = 1, #roots do
        local candidate = roots[i] .. "/" .. DEFAULT_MODEL_FILE
        if file_exists(candidate) then
            return candidate
        end
    end

    error("未找到 slider.onnx，请通过 model_path 或 model_dir 指定模型路径")
end

local function assert_open(self)
    if self.closed then
        error("对象已关闭")
    end
end

local function make_model_info(model_path, session, opts, used_coreml)
    return common.build_ort_model_info(model_path, session, opts, used_coreml, {
        mode = "slider",
    })
end

local function parse_predict_options(conf, iou, imgsz)
    local options = {
        confidence = 0.25,
        iou = 0.7,
        input_size = INPUT_SIZE,
    }
    if type(conf) == "table" and iou == nil and imgsz == nil then
        local value = conf
        options.confidence = tonumber(value.confidence or value.conf) or options.confidence
        options.iou = tonumber(value.iou) or options.iou
        local size = value.imgsz or value.input_size or value.size
        if type(size) == "table" then
            options.input_size = tonumber(size[1] or size.width or size.w) or options.input_size
        else
            options.input_size = tonumber(size) or options.input_size
        end
        return options
    end
    options.confidence = tonumber(conf) or options.confidence
    options.iou = tonumber(iou) or options.iou
    if type(imgsz) == "table" then
        options.input_size = tonumber(imgsz[1] or imgsz.width or imgsz.w) or options.input_size
    else
        options.input_size = tonumber(imgsz) or options.input_size
    end
    return options
end

local function parse_identify_options(conf, iou, show)
    local options = {
        confidence = DEFAULT_CONFIDENCE,
        iou = DEFAULT_IOU,
        show = false,
        y_iou = DEFAULT_Y_IOU,
        mask_compare_size = DEFAULT_MASK_COMPARE_SIZE,
    }
    if type(conf) == "table" and iou == nil and show == nil then
        local value = conf
        options.confidence = tonumber(value.confidence or value.conf) or options.confidence
        options.iou = tonumber(value.iou) or options.iou
        options.show = value.show == true
        options.y_iou = tonumber(value.y_iou) or options.y_iou
        options.mask_compare_size = tonumber(value.mask_compare_size) or options.mask_compare_size
        return options
    end
    options.confidence = tonumber(conf) or options.confidence
    options.iou = tonumber(iou) or options.iou
    options.show = show == true
    return options
end

local function clip_box(box, width, height)
    if box[1] < 0 then box[1] = 0 end
    if box[2] < 0 then box[2] = 0 end
    if box[3] > width then box[3] = width end
    if box[4] > height then box[4] = height end
    return box
end

local function y_iou(lhs, rhs)
    local start_y = math.max(lhs[2], rhs[2])
    local end_y = math.min(lhs[4], rhs[4])
    local inter = math.max(0.0, end_y - start_y)
    local len_lhs = math.max(0.0, lhs[4] - lhs[2])
    local len_rhs = math.max(0.0, rhs[4] - rhs[2])
    local union = len_lhs + len_rhs - inter
    if union <= 0 then
        return 0.0
    end
    return inter / union
end

local function build_transform_options(meta)
    return {
        offset_x = meta.offset_x,
        offset_y = meta.offset_y,
        scale_x = meta.scale_x,
        scale_y = meta.scale_y,
        clip_width = meta.src_width,
        clip_height = meta.src_height,
    }
end

local function decode_predictions(pred_tensor, meta, conf_threshold, iou_threshold)
    local shape = pred_tensor:shape()
    if #shape ~= 3 then
        error("预测输出维度不受支持")
    end

    local batch = shape[1]
    local channels = shape[2]
    local candidates = shape[3]
    if batch < 1 or candidates < 1 then
        return {}
    end
    if channels <= 5 then
        error("预测输出通道数异常")
    end

    local bundle = assert(ort.decode_matrix_candidates(pred_tensor, SLIDER_DECODER_SCHEMA, {
        confidence = conf_threshold,
        iou = iou_threshold,
        class_aware = true,
        score_threshold = conf_threshold,
    }))
    local scaled_boxes = assert(ort.scale_boxes(bundle.boxes, build_transform_options(meta)))
    local detections = assert(ort.records_from_boxes(
        scaled_boxes,
        bundle.scores,
        bundle.class_ids,
        bundle.keep_indices
    ))
    if #detections == 0 then
        return {}, nil, nil
    end
    for det_index = 1, #detections do
        detections[det_index].class_id = 0
        detections[det_index].box = clip_box(detections[det_index].box, meta.src_width, meta.src_height)
    end
    local selected_shape = assert(bundle.selected_rows:shape())
    local selected_channels = tonumber(selected_shape[2]) or 0
    if selected_channels <= 5 then
        error("筛选后的候选输出通道数异常")
    end
    local coeffs = assert(bundle.selected_rows:slice(2, 6, selected_channels))
    return detections, coeffs, bundle.boxes
end

local function build_proto_masks(proto_tensor, coeff_tensor, box_tensor, detections, image_width, image_height)
    if #detections == 0 then
        return
    end

    local masks = assert(ort.proto_masks(
        proto_tensor,
        coeff_tensor,
        box_tensor,
        image_width,
        image_height
    ))
    for det_index = 1, #detections do
        detections[det_index].mask = masks[det_index]
    end
end

local function pick_out_detection(detections, compare_size, y_iou_threshold)
    if #detections == 0 then
        return nil
    end
    if #detections == 1 then
        return detections[1]
    end

    local slider = detections[1]
    for i = 2, #detections do
        if detections[i].box[1] < slider.box[1] then
            slider = detections[i]
        end
    end

    local filtered = {}
    for i = 1, #detections do
        local det = detections[i]
        if det ~= slider and y_iou(slider.box, det.box) > y_iou_threshold then
            filtered[#filtered + 1] = det
        end
    end
    if #filtered == 0 then
        for i = 1, #detections do
            local det = detections[i]
            if det ~= slider then
                filtered[#filtered + 1] = det
            end
        end
    end
    if #filtered == 0 then
        return slider
    end
    if #filtered == 1 then
        return filtered[1]
    end

    local best = filtered[1]
    local best_score = -1.0
    for i = 1, #filtered do
        local score = assert(ort.mask_iou(slider.mask, filtered[i].mask, {
            compare_size = compare_size,
        }))
        if score > best_score then
            best_score = score
            best = filtered[i]
        end
    end
    return best
end

local function choose_output_tensors(outputs, output_names)
    local first = outputs[output_names[1]] or outputs[1]
    local second = outputs[output_names[2]] or outputs[2]
    if not first or not second then
        error("模型输出数量异常，至少需要两个输出")
    end
    local first_shape = first:shape()
    local second_shape = second:shape()
    if #first_shape == 4 and #second_shape == 3 then
        return second, first
    end
    if #first_shape == 3 and #second_shape == 4 then
        return first, second
    end
    return first, second
end

local function render_detection_preview(img, det)
    local preview = clone_image_object(img)
    local x1 = math.floor(det.box[1] + 0.5)
    local y1 = math.floor(det.box[2] + 0.5)
    local x2 = math.floor(det.box[3] + 0.5)
    local y2 = math.floor(det.box[4] + 0.5)
    preview = cv.rectangle(preview, x1, y1, x2, y2, {255, 80, 60}, 2)
    local label = string.format("%.2f", det.score or 0.0)
    local text_y = y1 > 18 and (y1 - 6) or math.min(y2 + 16, y1 + 16)
    preview = cv.put_text(
        preview,
        label,
        {x = x1, y = text_y},
        "simplex",
        0.5,
        {255, 80, 60},
        1,
        "aa",
        false
    )
    return preview
end

local function run_model(self, input, opts)
    local img = ensure_image(input)
    local tensor, meta = ort.tensor_from_image(img, {
        width = opts.input_size or INPUT_SIZE,
        height = opts.input_size or INPUT_SIZE,
        layout = "nchw",
        add_batch = true,
        channel_order = "rgb",
        data_type = "float32",
        scale = 1.0 / 255.0,
        resize_mode = "letterbox",
        pad_color = 0x727272,
    })
    local outputs = self.session:run({
        [self.model_info.input_name] = tensor,
    }, self.output_names)
    local pred_tensor, proto_tensor = choose_output_tensors(outputs, self.output_names)
    local conf = opts.confidence or DEFAULT_CONFIDENCE
    local iou = opts.iou or DEFAULT_IOU
    local detections, coeff_tensor, box_tensor = decode_predictions(pred_tensor, meta, conf, iou)
    build_proto_masks(proto_tensor, coeff_tensor, box_tensor, detections, meta.dst_width, meta.dst_height)
    return detections, img
end

local function normalize_detect_box(det)
    return {
        det.box[1],
        det.box[2],
        det.box[3],
        det.box[4],
    }
end

function instance_mt:predict(input, conf, iou, imgsz)
    assert_open(self)
    local parsed = parse_predict_options(conf, iou, imgsz)
    local detections = run_model(self, input, parsed)
    local boxes = {}
    local masks = {}
    for i = 1, #detections do
        local det = detections[i]
        boxes[i] = {
            det.box[1],
            det.box[2],
            det.box[3],
            det.box[4],
            det.score,
            det.class_id,
        }
        masks[i] = det.mask
    end
    local batch = {
        boxes,
        masks,
        boxes = boxes,
        masks = masks,
    }
    return {batch}
end

function instance_mt:identify(input, conf, iou, show)
    assert_open(self)
    local opts = parse_identify_options(conf, iou, show)
    local detections, img = run_model(self, input, opts)
    if #detections == 0 then
        return {}, 0.0, opts.show and clone_image_object(img) or nil
    end
    local chosen = pick_out_detection(
        detections,
        opts.mask_compare_size,
        opts.y_iou
    )
    if not chosen then
        return {}, 0.0, opts.show and clone_image_object(img) or nil
    end
    local preview = nil
    if opts.show then
        preview = render_detection_preview(img, chosen)
    end
    return normalize_detect_box(chosen), chosen.score, preview
end

function instance_mt:identify_offset(input, conf, iou, show)
    assert_open(self)
    local opts = parse_identify_options(conf, iou, show)
    local detections, img = run_model(self, input, opts)
    if #detections == 0 then
        return 0, 0.0, opts.show and clone_image_object(img) or nil
    end
    local leftmost = detections[1]
    for i = 2, #detections do
        if detections[i].box[1] < leftmost.box[1] then
            leftmost = detections[i]
        end
    end
    local preview = nil
    if opts.show then
        preview = render_detection_preview(img, leftmost)
    end
    return leftmost.box[1], leftmost.score, preview
end

function instance_mt:get_model_info()
    assert_open(self)
    local info = shallow_copy_table(self.model_info)
    info.input_shape = clone_array(self.model_info.input_shape or {})
    info.providers = clone_array(self.model_info.providers or {})
    info.outputs = {}
    for i = 1, #(self.model_info.outputs or {}) do
        info.outputs[i] = {
            name = self.model_info.outputs[i].name,
            shape = clone_array(self.model_info.outputs[i].shape or {}),
        }
    end
    return info
end

function instance_mt:close()
    if self.session then
        self.session:close()
    end
    self.closed = true
    self.session = nil
    self.output_names = nil
    self.model_info = nil
    return nil
end

function instance_mt:__tostring()
    if self.closed then
        return "captcha_recognizer{closed}"
    end
    return "captcha_recognizer{slider}"
end

local module = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

local function create_slider_instance(opts)
    local normalized = {
        model_path = opts.model_path,
        model_dir = opts.model_dir,
        fallback_to_cpu = opts.fallback_to_cpu,
        providers = normalize_provider_list(opts.providers),
    }
    for i = 1, #COREML_SESSION_OPTION_KEYS do
        local key = COREML_SESSION_OPTION_KEYS[i]
        if opts[key] ~= nil then
            normalized[key] = opts[key]
        end
    end

    local model_path = resolve_model_path(normalized)
    local session = assert(ort.session(model_path, build_session_options(normalized)))
    local used_coreml = provider_list_contains(normalized.providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local model_info = make_model_info(model_path, session, normalized, used_coreml)

    return setmetatable({
        closed = false,
        session = session,
        output_names = session:output_names(),
        model_info = model_info,
        decoder_schema = shallow_copy_table(SLIDER_DECODER_SCHEMA),
    }, instance_mt)
end

function module.new(opts)
    opts = opts or {}
    if type(opts) ~= "table" then
        error("captcha_recognizer.new 期望 table 参数")
    end
    if opts.use_gpu ~= nil then
        error("use_gpu 已移除，请显式传 providers = {\"coreml\", \"cpu\"} 或 providers = {\"cpu\"}")
    end

    local captcha_type = opts.type
    if captcha_type == nil or captcha_type == "" then
        captcha_type = "slider"
    end
    if type(captcha_type) ~= "string" then
        error("captcha_recognizer.new 的 type 期望 string")
    end

    local normalized_type = string.lower(captcha_type)
    if normalized_type == "slider" then
        return create_slider_instance(opts)
    end

    error("不支持的验证码类型: " .. tostring(captcha_type))
end

function module.version()
    return VERSION
end

function module.providers()
    return clone_array(PROVIDERS)
end

module.Slider = create_slider_instance

return module
