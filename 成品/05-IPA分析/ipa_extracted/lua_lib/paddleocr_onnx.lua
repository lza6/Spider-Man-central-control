--[[
paddleocr_onnx.lua

Created by 苏泽 on 26-03-30.
Copyright (c) 2026年 苏泽. All rights reserved.

基于 XXTouch 内置 onnxruntime 模块的 PaddleOCR 封装。

预期模型文件:
- det.onnx
- rec.onnx
- dict.txt

用法:
local paddleocr = require("paddleocr_onnx")

local ocr = paddleocr.new({
    det_model_path = "/var/mobile/Media/1ferver/models/paddleocr-onnx/chinese/det.onnx",
    rec_model_path = "/var/mobile/Media/1ferver/models/paddleocr-onnx/chinese/rec.onnx",
    dict_path = "/var/mobile/Media/1ferver/models/paddleocr-onnx/chinese/dict.txt",
})

local result = ocr:recognize("/path/to/image.png")
print(result.text)

local line = ocr:recognize_line("/path/to/text-line.png")
print(line.text, line.confidence)
ocr:close()

构造参数:
- det_model_path = "/path/to/det.onnx"
- rec_model_path = "/path/to/rec.onnx"
- dict_path = "/path/to/dict.txt"
- det_model_dir = "/path/to/det_dir"
- rec_model_dir = "/path/to/rec_dir"
- model_dir = "/path/to/model_dir"
- providers = {"cpu"} 或 {"coreml", "cpu"}
- fallback_to_cpu = true/false
- threads = integer
- max_side_len = integer
- det_db_thresh = number
- det_db_box_thresh = number
- det_db_unclip_ratio = number
- det_db_use_dilate = true/false
- det_use_polygon_score = true/false
- rec_batch = true/false
- rec_batch_size = integer
- rec_batch_min_size = integer
- rec_bucket_width = true/false
- rec_bucket_width_stride = integer
- rec_apply_softmax = true/false
- rec_values_are_probabilities = true/false
- use_space_char = true/false
- coreml_compute_units = "all" | "cpu_only" | "cpu_and_gpu" | "cpu_and_neural_engine"
- coreml_enable_on_subgraph = true/false
- coreml_require_static_input_shapes = true/false
- coreml_create_mlprogram = true/false

说明:
- 以上 CoreML 参数会原样透传给 onnxruntime.session(...)
]]

local cv = require("image.cv")
local ort = require("onnxruntime")
local yolo_backend_common = require("yolo_backend_common")

local VERSION = "0.1.1"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/paddleocr_onnx"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/paddleocr_onnx"

local DET_MEAN = {0.485, 0.456, 0.406}
local DET_STD = {0.229, 0.224, 0.225}
local REC_MEAN = {0.5, 0.5, 0.5}
local REC_STD = {0.5, 0.5, 0.5}

local DEFAULT_DET_CONFIG = {
    max_side_len = 960,
    det_db_thresh = 0.3,
    det_db_box_thresh = 0.5,
    det_db_unclip_ratio = 1.6,
    det_db_use_dilate = false,
    det_use_polygon_score = true,
}

local DEFAULT_REC_CONFIG = {
    batch = false,
    batch_size = 8,
    batch_min_size = 3,
    bucket_width = true,
    bucket_width_stride = 16,
    apply_softmax = false,
    values_are_probabilities = true,
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

local shallow_copy_table = yolo_backend_common.shallow_copy_table
local clone_array = yolo_backend_common.clone_array
local clamp = yolo_backend_common.clamp
local resolve_image_object = yolo_backend_common.resolve_image_object
local normalize_provider_list = yolo_backend_common.normalize_provider_list
local provider_list_contains = yolo_backend_common.provider_list_contains
local resolve_named_resource = yolo_backend_common.resolve_named_resource
local has_provider = function(full_name)
    return yolo_backend_common.available_provider_names_contains(PROVIDERS, full_name)
end

local function distance(lhs, rhs)
    local dx = (lhs.x or 0) - (rhs.x or 0)
    local dy = (lhs.y or 0) - (rhs.y or 0)
    return math.sqrt(dx * dx + dy * dy)
end

local function read_dict(path, opts)
    local lines = yolo_backend_common.load_nonempty_lines_from_file(path, "dict")
    local charset = {""}
    local has_space = false
    for i = 1, #lines do
        local line = lines[i]
        charset[#charset + 1] = line
        if line == " " then
            has_space = true
        end
    end
    if opts.use_space_char ~= false and not has_space then
        charset[#charset + 1] = " "
    end
    return charset
end

local function build_search_roots(opts, specific_dir)
    return yolo_backend_common.build_search_roots(opts, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT, specific_dir)
end

local function build_session_options(opts)
    return yolo_backend_common.build_ort_session_options(opts, COREML_SESSION_OPTION_KEYS, {
        intra_op_num_threads = 1,
        graph_optimization_level = "all",
    })
end

local function build_model_info(kind, model_path, session, opts, used_coreml)
    return yolo_backend_common.build_ort_model_info(model_path, session, opts, used_coreml, {
        kind = kind,
    })
end

local function assert_open(self)
    if self.closed then
        error("object is closed")
    end
end

local function run_first_output(session_info, tensor)
    local outputs, err = session_info.session:run({
        [session_info.input_name] = tensor,
    }, session_info.output_names)
    if not outputs then
        error("onnx run failed: " .. tostring(err), 2)
    end

    local first_name = session_info.output_names and session_info.output_names[1]
    local first_output = (first_name and outputs[first_name]) or outputs[1]
    if not first_output then
        error("onnx run returned no outputs", 2)
    end
    return first_output
end

local function det_resize_side(value)
    value = math.max(1, math.floor(value))
    if value % 32 == 0 then
        return value
    end
    if value / 32 < 1 + 1e-5 then
        return 32
    end
    return math.max(32, math.floor(value / 32) * 32)
end

local function compute_det_resize(width, height, max_side_len)
    local ratio = 1.0
    local max_wh = math.max(width, height)
    if max_wh > max_side_len then
        ratio = max_side_len / max_wh
    end
    local resize_h = det_resize_side(height * ratio)
    local resize_w = det_resize_side(width * ratio)
    return resize_w, resize_h, resize_h / math.max(1, height), resize_w / math.max(1, width)
end

local function box_bounds(points)
    local min_x = math.huge
    local min_y = math.huge
    local max_x = -math.huge
    local max_y = -math.huge
    for i = 1, #points do
        min_x = math.min(min_x, points[i].x)
        min_y = math.min(min_y, points[i].y)
        max_x = math.max(max_x, points[i].x)
        max_y = math.max(max_y, points[i].y)
    end
    local x = math.floor(min_x)
    local y = math.floor(min_y)
    local w = math.max(1, math.ceil(max_x) - x)
    local h = math.max(1, math.ceil(max_y) - y)
    return x, y, w, h
end

local function sort_text_boxes(lines)
    table.sort(lines, function(lhs, rhs)
        local ly = lhs.box[1].y
        local ry = rhs.box[1].y
        if math.abs(ly - ry) > 10 then
            return ly < ry
        end
        return lhs.box[1].x < rhs.box[1].x
    end)

    for i = 2, #lines do
        local current = i
        while current > 1 do
            local prev = lines[current - 1]
            local curr = lines[current]
            if math.abs(curr.box[1].y - prev.box[1].y) < 10 and curr.box[1].x < prev.box[1].x then
                lines[current - 1], lines[current] = lines[current], lines[current - 1]
                current = current - 1
            else
                break
            end
        end
    end
    return lines
end

local function join_text(lines)
    local parts = {}
    for i = 1, #lines do
        if lines[i].text and lines[i].text ~= "" then
            parts[#parts + 1] = lines[i].text
        end
    end
    return table.concat(parts, "\n")
end

local function make_bgr_mat(img)
    return cv.cvt_color(cv.from_image(img), "bgra2bgr")
end

local function rotated_box_size(box)
    local width = math.max(1, math.floor(math.max(
        distance(box[1], box[2]),
        distance(box[3], box[4])
    ) + 0.5))
    local height = math.max(1, math.floor(math.max(
        distance(box[1], box[4]),
        distance(box[2], box[3])
    ) + 0.5))
    if height >= width * 1.5 then
        width, height = height, width
    end
    return width, height
end

local function infer_rec_input_size(self, source)
    local width, height
    if type(source) == "table" and source[1] and source[1].x ~= nil and source[1].y ~= nil then
        width, height = rotated_box_size(source)
    else
        width, height = source:size()
    end
    local target_height = 32
    local target_width
    local input_shape = self.rec and self.rec.model_info and self.rec.model_info.input_shape or {}

    if #input_shape >= 4 then
        local maybe_height = tonumber(input_shape[3])
        local maybe_width = tonumber(input_shape[4])
        if maybe_height and maybe_height > 0 then
            target_height = maybe_height
        end
        if maybe_width and maybe_width > 0 then
            target_width = maybe_width
        end
    elseif #input_shape >= 3 then
        local maybe_height = tonumber(input_shape[2])
        local maybe_width = tonumber(input_shape[3])
        if maybe_height and maybe_height > 0 then
            target_height = maybe_height
        end
        if maybe_width and maybe_width > 0 then
            target_width = maybe_width
        end
    end

    local ratio = width / math.max(1, height)
    if not target_width then
        target_width = math.max(1, math.ceil(target_height * ratio))
    end
    return target_width, target_height
end

local function prepare_rec_tensor(self, img)
    local target_width, target_height = infer_rec_input_size(self, img)
    return ort.tensor_from_image(img, {
        width = target_width,
        height = target_height,
        layout = "nchw",
        add_batch = true,
        channel_order = "rgb",
        data_type = "float32",
        scale = 1.0 / 255.0,
        mean = REC_MEAN,
        std = REC_STD,
    })
end

local function round_up_to_multiple(value, multiple)
    if multiple <= 1 then
        return math.max(1, value)
    end
    return math.max(1, math.ceil(value / multiple) * multiple)
end

local function infer_rec_bucket_size(self, source, target_width, target_height)
    local width = target_width
    local height = target_height
    if not width or not height then
        width, height = infer_rec_input_size(self, source)
    end
    if self.rec_config.bucket_width == false then
        return width, height
    end
    local stride = math.max(1, tonumber(self.rec_config.bucket_width_stride) or DEFAULT_REC_CONFIG.bucket_width_stride)
    if stride <= 1 then
        return width, height
    end
    return round_up_to_multiple(width, stride), height
end

local function prepare_rec_tensor_from_quad(self, src_mat, box, bucket_width, bucket_height)
    local target_width, target_height = infer_rec_input_size(self, box)
    local output_width = bucket_width or target_width
    local output_height = bucket_height or target_height
    local resize_mode = "stretch"
    if output_width ~= target_width or output_height ~= target_height then
        -- 批处理分桶时保持文字宽高比，剩余区域统一补边，避免拉伸语义发生偏移。
        resize_mode = "top_left_letterbox"
    end
    return assert(ort.tensor_from_quad(src_mat, box, {
        width = output_width,
        height = output_height,
        content_width = target_width,
        content_height = target_height,
        interpolation = "linear",
        resize_mode = resize_mode,
        layout = "nchw",
        add_batch = true,
        channel_order = "rgb",
        data_type = "float32",
        type = "float32",
        scale = 1.0 / 255.0,
        mean = REC_MEAN,
        std = REC_STD,
        auto_rotate_tall = true,
        border_type = "replicate",
    }))
end

local function prepare_rec_tensor_from_quads(self, src_mat, items, bucket_width, bucket_height)
    local quads = {}
    for i = 1, #items do
        quads[i] = {
            points = items[i].detection.box,
            content_width = items[i].target_width,
            content_height = items[i].target_height,
        }
    end
    return assert(ort.tensor_from_quads(src_mat, quads, {
        width = bucket_width,
        height = bucket_height,
        interpolation = "linear",
        resize_mode = "top_left_letterbox",
        layout = "nchw",
        channel_order = "rgb",
        data_type = "float32",
        type = "float32",
        scale = 1.0 / 255.0,
        mean = REC_MEAN,
        std = REC_STD,
        auto_rotate_tall = true,
        border_type = "replicate",
    }))
end

local function decode_rec_output(self, tensor)
    return assert(ort.ctc_greedy_decode(tensor, {
        blank_index = 0,
        charset = self.charset,
        merge_repeated = true,
        apply_softmax = self.rec_config.apply_softmax,
        values_are_probabilities = self.rec_config.values_are_probabilities,
    }))
end

local function normalize_decoded_batch(decoded)
    if type(decoded) == "table" and decoded[1] ~= nil then
        return decoded
    end
    return {decoded}
end

local function build_rec_line(detection, rec)
    local x, y, w, h = box_bounds(detection.box)
    return {
        text = rec.text or "",
        confidence = tonumber(rec.confidence) or 0.0,
        det_confidence = detection.score,
        box = detection.box,
        x = x,
        y = y,
        w = w,
        h = h,
    }
end

local function detect_image(self, img)
    if not self.det then
        error("det model is not configured")
    end

    local src_width, src_height = img:size()
    local resize_w, resize_h =
        compute_det_resize(src_width, src_height, self.det_config.max_side_len)

    local tensor, meta = ort.tensor_from_image(img, {
        width = resize_w,
        height = resize_h,
        layout = "nchw",
        add_batch = true,
        channel_order = "rgb",
        data_type = "float32",
        scale = 1.0 / 255.0,
        mean = DET_MEAN,
        std = DET_STD,
    })
    local output = run_first_output(self.det, tensor)
    local results = assert(ort.db_postprocess(output, {
        thresh = self.det_config.det_db_thresh,
        box_thresh = self.det_config.det_db_box_thresh,
        unclip_ratio = self.det_config.det_db_unclip_ratio,
        use_dilate = self.det_config.det_db_use_dilate,
        use_polygon_score = self.det_config.det_use_polygon_score,
        max_candidates = 1000,
        meta = meta,
    }))
    return sort_text_boxes(results)
end

local function recognize_line(self, line_img)
    local tensor = prepare_rec_tensor(self, line_img)
    local output = run_first_output(self.rec, tensor)
    local decoded = decode_rec_output(self, output)
    return {
        text = decoded.text or "",
        confidence = tonumber(decoded.confidence) or 0.0,
        indices = decoded.indices,
    }
end

local function build_rec_batch_groups(self, detections)
    local groups = {}
    local ordered_keys = {}
    for i = 1, #detections do
        local detection = detections[i]
        local target_width, target_height = infer_rec_input_size(self, detection.box)
        local bucket_width, bucket_height = infer_rec_bucket_size(self, detection.box, target_width, target_height)
        local key = string.format("%d:%d", bucket_width, bucket_height)
        local group = groups[key]
        if not group then
            group = {
                width = bucket_width,
                height = bucket_height,
                items = {},
            }
            groups[key] = group
            ordered_keys[#ordered_keys + 1] = key
        end
        group.items[#group.items + 1] = {
            index = i,
            detection = detection,
            target_width = target_width,
            target_height = target_height,
        }
    end
    return groups, ordered_keys
end

local function decode_single_rec_item(self, src_mat, item, lines, stats)
    stats.run_count = stats.run_count + 1
    stats.single_count = stats.single_count + 1
    local output = run_first_output(self.rec, prepare_rec_tensor_from_quad(self, src_mat, item.detection.box))
    local rec = decode_rec_output(self, output)
    lines[item.index] = build_rec_line(item.detection, rec)
end

local function fill_chunk(items, start_index, end_index, chunk)
    for i = #chunk, 1, -1 do
        chunk[i] = nil
    end
    local cursor = 1
    for i = start_index, end_index do
        chunk[cursor] = items[i]
        cursor = cursor + 1
    end
    return cursor - 1
end

local function decode_rec_detections(self, src_mat, detections)
    local lines = {}
    local stats = {
        enabled = self.rec_config.batch ~= false,
        requested_batch_size = math.max(1, tonumber(self.rec_config.batch_size) or DEFAULT_REC_CONFIG.batch_size),
        requested_batch_min_size = math.max(1, tonumber(self.rec_config.batch_min_size) or DEFAULT_REC_CONFIG.batch_min_size),
        bucket_width_enabled = self.rec_config.bucket_width ~= false,
        bucket_width_stride = math.max(1, tonumber(self.rec_config.bucket_width_stride) or DEFAULT_REC_CONFIG.bucket_width_stride),
        total_detections = #detections,
        run_count = 0,
        batch_count = 0,
        single_count = 0,
        group_count = 0,
        max_batch = 0,
        padded_count = 0,
        skipped_small_batch_count = 0,
    }
    if #detections == 0 then
        return lines, stats
    end

    local batch_size = stats.requested_batch_size
    local batch_min_size = stats.requested_batch_min_size
    local use_batch = self.rec_config.batch ~= false and batch_size > 1

    if not use_batch then
        for i = 1, #detections do
            decode_single_rec_item(self, src_mat, {
                index = i,
                detection = detections[i],
            }, lines, stats)
        end
        return lines, stats
    end

    local groups, ordered_keys = build_rec_batch_groups(self, detections)
    stats.group_count = #ordered_keys
    local chunk = {}
    for i = 1, #ordered_keys do
        local group = groups[ordered_keys[i]]
        local items = group.items
        for start = 1, #items, batch_size do
            local finish = math.min(#items, start + batch_size - 1)
            local chunk_size = fill_chunk(items, start, finish, chunk)
            if chunk_size < batch_min_size then
                stats.skipped_small_batch_count = stats.skipped_small_batch_count + 1
                for j = 1, chunk_size do
                    decode_single_rec_item(self, src_mat, chunk[j], lines, stats)
                end
            elseif chunk_size == 1 then
                decode_single_rec_item(self, src_mat, chunk[1], lines, stats)
            else
                stats.run_count = stats.run_count + 1
                stats.batch_count = stats.batch_count + 1
                stats.max_batch = math.max(stats.max_batch, chunk_size)
                for j = 1, chunk_size do
                    local item = chunk[j]
                    if item.target_width ~= group.width or item.target_height ~= group.height then
                        stats.padded_count = stats.padded_count + 1
                    end
                end
                local batch_tensor
                batch_tensor = prepare_rec_tensor_from_quads(self, src_mat, chunk, group.width, group.height)
                local decoded_batch = normalize_decoded_batch(decode_rec_output(self, run_first_output(self.rec, batch_tensor)))
                for j = 1, chunk_size do
                    local item = chunk[j]
                    local rec = decoded_batch[j] or {}
                    lines[item.index] = build_rec_line(item.detection, rec)
                end
            end
        end
    end
    return lines, stats
end

local function make_det_session(opts)
    local roots = build_search_roots(opts, opts.det_model_dir)
    local det_path = resolve_named_resource(opts.det_model_path, roots, {"det.onnx"}, false)
    if not det_path then
        return nil
    end
    local session = assert(ort.session(det_path, build_session_options(opts)))
    local requested_providers = normalize_provider_list(opts.providers)
    local used_coreml = provider_list_contains(requested_providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local input_names = session:input_names()
    local session_info = {
        session = session,
        model_path = det_path,
        input_name = input_names[1],
        output_names = session:output_names(),
        model_info = build_model_info("det", det_path, session, opts, used_coreml),
    }
    return session_info
end

local function make_rec_session(opts)
    local roots = build_search_roots(opts, opts.rec_model_dir)
    local rec_path = resolve_named_resource(opts.rec_model_path, roots, {"rec.onnx"}, true)
    local dict_path = resolve_named_resource(opts.dict_path or opts.rec_keys_path, roots, {"dict.txt"}, true)
    local session = ort.session(rec_path, build_session_options(opts))
    local requested_providers = normalize_provider_list(opts.providers)
    local used_coreml = provider_list_contains(requested_providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local input_names = session:input_names()
    local session_info = {
        session = session,
        model_path = rec_path,
        dict_path = dict_path,
        input_name = input_names[1],
        output_names = session:output_names(),
        model_info = build_model_info("rec", rec_path, session, opts, used_coreml),
    }
    return session_info
end

function instance_mt:recognize_line(input, opts)
    assert_open(self)
    opts = opts or {}
    local img = resolve_image_object(input)
    local line = recognize_line(self, img)
    if opts.return_text_only then
        return line.text
    end
    return line
end

function instance_mt:recognize(input, opts)
    assert_open(self)
    opts = opts or {}
    local img = resolve_image_object(input)
    local detections = detect_image(self, img)
    local src_mat = make_bgr_mat(img)
    local lines, rec_stats = decode_rec_detections(self, src_mat, detections)

    sort_text_boxes(lines)
    local result = {
        text = join_text(lines),
        lines = lines,
    }
    if opts.return_stats then
        result.stats = {
            rec = rec_stats,
            det = {
                count = #detections,
            },
        }
    end
    return result
end

function instance_mt:classification(input, opts)
    opts = opts or {}
    if opts.return_details == nil and opts.return_text_only == nil then
        opts.return_text_only = true
    end
    return self:recognize_line(input, opts)
end

function instance_mt:ocr(input, opts)
    return self:recognize(input, opts)
end

function instance_mt:detect(input)
    assert_open(self)
    local img = resolve_image_object(input)
    local detections = detect_image(self, img)
    local lines = {}
    for i = 1, #detections do
        local x, y, w, h = box_bounds(detections[i].box)
        lines[i] = {
            box = detections[i].box,
            confidence = detections[i].score,
            x = x,
            y = y,
            w = w,
            h = h,
        }
    end
    return lines
end

function instance_mt:det(input)
    return self:detect(input)
end

function instance_mt:get_model_info()
    assert_open(self)
    local info = {
        rec = shallow_copy_table(self.rec.model_info),
        det = self.det and shallow_copy_table(self.det.model_info) or nil,
        dict_path = self.rec.dict_path,
        det_config = shallow_copy_table(self.det_config),
        rec_config = shallow_copy_table(self.rec_config),
    }
    if info.rec then
        info.rec.input_shape = clone_array(info.rec.input_shape or {})
        info.rec.providers = clone_array(info.rec.providers or {})
        info.rec.outputs = {}
        for i = 1, #(self.rec.model_info.outputs or {}) do
            info.rec.outputs[i] = {
                name = self.rec.model_info.outputs[i].name,
                shape = clone_array(self.rec.model_info.outputs[i].shape or {}),
            }
        end
    end
    if info.det then
        info.det.input_shape = clone_array(info.det.input_shape or {})
        info.det.providers = clone_array(info.det.providers or {})
        info.det.outputs = {}
        for i = 1, #(self.det.model_info.outputs or {}) do
            info.det.outputs[i] = {
                name = self.det.model_info.outputs[i].name,
                shape = clone_array(self.det.model_info.outputs[i].shape or {}),
            }
        end
    end
    return info
end

function instance_mt:close()
    if self.det and self.det.session then
        self.det.session:close()
    end
    if self.rec and self.rec.session then
        self.rec.session:close()
    end
    self.closed = true
    self.det = nil
    self.rec = nil
    self.charset = nil
    self.det_config = nil
    self.rec_config = nil
    return nil
end

function instance_mt:__tostring()
    if self.closed then
        return "paddleocr_onnx{closed}"
    end
    return "paddleocr_onnx{open}"
end

local M = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

function M.new(opts)
    opts = opts or {}
    if opts.use_gpu ~= nil then
        error("use_gpu has been removed; pass providers = {\"coreml\", \"cpu\"} or providers = {\"cpu\"} explicitly")
    end
    local rec = make_rec_session(opts)
    local det = make_det_session(opts)
    local rec_apply_softmax = opts.rec_apply_softmax == nil and
        DEFAULT_REC_CONFIG.apply_softmax or
        (opts.rec_apply_softmax == true)
    local rec_values_are_probabilities = opts.rec_values_are_probabilities == nil and
        (DEFAULT_REC_CONFIG.values_are_probabilities and not rec_apply_softmax) or
        (opts.rec_values_are_probabilities == true)
    local instance = {
        closed = false,
        rec = rec,
        det = det,
        charset = read_dict(rec.dict_path, opts),
        det_config = {
            max_side_len = tonumber(opts.max_side_len) or DEFAULT_DET_CONFIG.max_side_len,
            det_db_thresh = tonumber(opts.det_db_thresh) or DEFAULT_DET_CONFIG.det_db_thresh,
            det_db_box_thresh = tonumber(opts.det_db_box_thresh) or DEFAULT_DET_CONFIG.det_db_box_thresh,
            det_db_unclip_ratio = tonumber(opts.det_db_unclip_ratio) or DEFAULT_DET_CONFIG.det_db_unclip_ratio,
            det_db_use_dilate = opts.det_db_use_dilate == true or DEFAULT_DET_CONFIG.det_db_use_dilate,
            det_use_polygon_score = opts.det_use_polygon_score == nil and
                DEFAULT_DET_CONFIG.det_use_polygon_score or
                (opts.det_use_polygon_score == true),
        },
        rec_config = {
            batch = opts.rec_batch == nil and DEFAULT_REC_CONFIG.batch or (opts.rec_batch == true),
            batch_size = math.max(1, tonumber(opts.rec_batch_size) or DEFAULT_REC_CONFIG.batch_size),
            batch_min_size = math.max(1, tonumber(opts.rec_batch_min_size) or DEFAULT_REC_CONFIG.batch_min_size),
            bucket_width = opts.rec_bucket_width == nil and DEFAULT_REC_CONFIG.bucket_width or (opts.rec_bucket_width == true),
            bucket_width_stride = math.max(1, tonumber(opts.rec_bucket_width_stride) or DEFAULT_REC_CONFIG.bucket_width_stride),
            apply_softmax = rec_apply_softmax,
            values_are_probabilities = rec_values_are_probabilities,
        },
    }
    return setmetatable(instance, instance_mt)
end

M.create = M.new
M.open = M.new

M.__index = M

return M
