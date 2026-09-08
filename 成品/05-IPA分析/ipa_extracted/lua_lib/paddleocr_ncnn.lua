--[[
paddleocr_ncnn.lua

基于 XXTouch 内置 ncnn 模块的 PaddleOCR 封装。

默认模型目录:
- /var/mobile/Media/1ferver/models/paddleocr_ncnn

PP-OCRv5 mobile 默认文件名:
- PP_OCRv5_mobile_det.ncnn.param
- PP_OCRv5_mobile_det.ncnn.bin
- PP_OCRv5_mobile_rec.ncnn.param
- PP_OCRv5_mobile_rec.ncnn.bin
]]

local ncnn = require("ncnn")
local common = require("yolo_backend_common")

local VERSION = "0.1.0"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/paddleocr_ncnn"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/paddleocr_ncnn"

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
    image_height = 48,
    min_width = 16,
    max_width = 960,
    bucket_width = true,
    bucket_width_stride = 16,
    apply_softmax = false,
    values_are_probabilities = true,
}

local DET_PARAM_NAMES = {
    "PP_OCRv5_mobile_det.ncnn.param",
    "det.ncnn.param",
    "det.param",
    "model_det.ncnn.param",
}

local REC_PARAM_NAMES = {
    "PP_OCRv5_mobile_rec.ncnn.param",
    "rec.ncnn.param",
    "rec.param",
    "model_rec.ncnn.param",
}

local instance_mt = {}
instance_mt.__index = instance_mt

local resolve_image_object = common.resolve_image_object
local file_exists = common.file_exists
local shallow_copy_table = common.shallow_copy_table
local clone_array = common.clone_array

local function distance(lhs, rhs)
    local dx = (lhs.x or 0) - (rhs.x or 0)
    local dy = (lhs.y or 0) - (rhs.y or 0)
    return math.sqrt(dx * dx + dy * dy)
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

local function read_dict(path, opts)
    if path and path ~= "" then
        local lines = common.load_nonempty_lines_from_file(path, "dict")
        local charset = {""}
        local has_space = false
        for i = 1, #lines do
            charset[#charset + 1] = lines[i]
            if lines[i] == " " then
                has_space = true
            end
        end
        if opts.use_space_char ~= false and not has_space then
            charset[#charset + 1] = " "
        end
        return charset
    end
    local charset = require("paddleocr_ncnn_dict")
    if opts.use_space_char == false and charset[#charset] == " " then
        local copy = {}
        for i = 1, #charset - 1 do
            copy[i] = charset[i]
        end
        return copy
    end
    return charset
end

local function build_search_roots(opts, specific_dir)
    return common.build_search_roots(opts, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT, specific_dir)
end

local function model_bin_from_param(param_path)
    if type(param_path) ~= "string" then
        return nil
    end
    if param_path:sub(-10) == ".param.bin" then
        return param_path:sub(1, -11) .. ".bin"
    end
    if param_path:sub(-6) == ".param" then
        return param_path:sub(1, -7) .. ".bin"
    end
    return nil
end

local function resolve_pair(explicit_param, explicit_bin, roots, param_names, required, label)
    if explicit_param and explicit_param ~= "" then
        if not file_exists(explicit_param) then
            error(label .. " param file not found: " .. explicit_param)
        end
        local bin = explicit_bin
        if not bin or bin == "" then
            bin = model_bin_from_param(explicit_param)
        end
        if not file_exists(bin) then
            error(label .. " model file not found: " .. tostring(bin))
        end
        return explicit_param, bin
    end

    for i = 1, #roots do
        local root = roots[i]
        if root and root ~= "" then
            for j = 1, #param_names do
                local param = root .. "/" .. param_names[j]
                local bin = model_bin_from_param(param)
                if file_exists(param) and file_exists(bin) then
                    return param, bin
                end
            end
        end
    end

    if required then
        error(label .. " ncnn model not found")
    end
    return nil, nil
end

local function build_net_options(param_path, model_path, opts)
    return {
        param_path = param_path,
        model_path = model_path,
        use_vulkan_compute = opts.use_vulkan_compute == true,
        fallback_to_cpu = opts.fallback_to_cpu ~= false,
        gpu_device = opts.gpu_device or 0,
        threads = opts.threads or 1,
        light_mode = opts.light_mode ~= false,
    }
end

local function run_first_output(session_info, tensor)
    local outputs, err = session_info.session:run({
        [session_info.input_name] = tensor,
    }, session_info.output_names)
    if not outputs then
        error("ncnn run failed: " .. tostring(err), 2)
    end
    local first_name = session_info.output_names and session_info.output_names[1]
    local first_output = (first_name and outputs[first_name]) or outputs[1]
    if not first_output then
        error("ncnn run returned no outputs", 2)
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
    return det_resize_side(width * ratio), det_resize_side(height * ratio)
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

local function round_up_to_multiple(value, multiple)
    if multiple <= 1 then
        return math.max(1, value)
    end
    return math.max(1, math.ceil(value / multiple) * multiple)
end

local function infer_rec_input_size(self, source)
    local width, height
    if type(source) == "table" and source[1] and source[1].x ~= nil and source[1].y ~= nil then
        width, height = rotated_box_size(source)
    else
        width, height = source:size()
    end
    local target_height = self.rec_config.image_height
    local ratio = width / math.max(1, height)
    local target_width = math.max(self.rec_config.min_width, math.ceil(target_height * ratio))
    target_width = math.min(self.rec_config.max_width, target_width)
    if self.rec_config.bucket_width ~= false then
        target_width = round_up_to_multiple(target_width, self.rec_config.bucket_width_stride)
    end
    return target_width, target_height
end

local function prepare_rec_tensor(self, img)
    local target_width, target_height = infer_rec_input_size(self, img)
    return assert(ncnn.tensor_from_image(img, {
        width = target_width,
        height = target_height,
        layout = "nchw",
        add_batch = false,
        channel_order = "rgb",
        type = "float32",
        scale = 1.0 / 255.0,
        mean = REC_MEAN,
        std = REC_STD,
    }))
end

local function prepare_rec_tensor_from_quad(self, img, box)
    local target_width, target_height = infer_rec_input_size(self, box)
    return assert(ncnn.tensor_from_quad(img, box, {
        width = target_width,
        height = target_height,
        interpolation = "bilinear",
        resize_mode = "stretch",
        layout = "nchw",
        add_batch = false,
        channel_order = "rgb",
        type = "float32",
        scale = 1.0 / 255.0,
        mean = REC_MEAN,
        std = REC_STD,
        auto_rotate_tall = true,
    }))
end

local function decode_rec_output(self, tensor)
    return assert(ncnn.ctc_greedy_decode(tensor, {
        blank_index = 0,
        charset = self.charset,
        merge_repeated = true,
        apply_softmax = self.rec_config.apply_softmax,
        values_are_probabilities = self.rec_config.values_are_probabilities,
    }))
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
    if not self.det_session then
        error("det model is not configured")
    end
    local src_width, src_height = img:size()
    local resize_w, resize_h =
        compute_det_resize(src_width, src_height, self.det_config.max_side_len)
    local tensor, meta = assert(ncnn.tensor_from_image(img, {
        width = resize_w,
        height = resize_h,
        layout = "nchw",
        add_batch = false,
        channel_order = "rgb",
        type = "float32",
        scale = 1.0 / 255.0,
        mean = DET_MEAN,
        std = DET_STD,
    }))
    local output = run_first_output(self.det_session, tensor)
    local results = assert(ncnn.db_postprocess(output, {
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
    local output = run_first_output(self.rec, prepare_rec_tensor(self, line_img))
    local decoded = decode_rec_output(self, output)
    return {
        text = decoded.text or "",
        confidence = tonumber(decoded.confidence) or 0.0,
        indices = decoded.indices,
    }
end

local function decode_rec_detections(self, img, detections)
    local lines = {}
    for i = 1, #detections do
        local output = run_first_output(self.rec, prepare_rec_tensor_from_quad(self, img, detections[i].box))
        lines[i] = build_rec_line(detections[i], decode_rec_output(self, output))
    end
    return lines, {
        enabled = false,
        total_detections = #detections,
        run_count = #detections,
        batch_count = 0,
        single_count = #detections,
    }
end

local function make_session_info(kind, param_path, model_path, input_name, output_names, opts)
    local session = assert(ncnn.session(build_net_options(param_path, model_path, opts)))
    return {
        session = session,
        param_path = param_path,
        model_path = model_path,
        input_name = input_name,
        output_names = output_names,
        model_info = {
            kind = kind,
            backend = "ncnn",
            param_path = param_path,
            model_path = model_path,
            input_name = input_name,
            output_names = clone_array(output_names),
            use_vulkan_compute = opts.use_vulkan_compute == true and ncnn.has_vulkan(),
        },
    }
end

local function make_det_session(opts)
    local roots = build_search_roots(opts, opts.det_model_dir)
    local param_path, model_path = resolve_pair(
        opts.det_param_path,
        opts.det_model_path,
        roots,
        DET_PARAM_NAMES,
        false,
        "det"
    )
    if not param_path then
        return nil
    end
    return make_session_info(
        "det",
        param_path,
        model_path,
        opts.det_input_name or opts.input_name or "in0",
        opts.det_output_names or opts.output_names or {"out0"},
        opts
    )
end

local function make_rec_session(opts)
    local roots = build_search_roots(opts, opts.rec_model_dir)
    local param_path, model_path = resolve_pair(
        opts.rec_param_path or opts.param_path,
        opts.rec_model_path or opts.model_path,
        roots,
        REC_PARAM_NAMES,
        true,
        "rec"
    )
    local dict_path = common.resolve_named_resource(
        opts.dict_path or opts.rec_keys_path,
        roots,
        {"dict.txt", "ppocr_keys_v5.txt", "ppocr_keys_v1.txt"},
        false
    )
    local info = make_session_info(
        "rec",
        param_path,
        model_path,
        opts.rec_input_name or opts.input_name or "in0",
        opts.rec_output_names or opts.output_names or {"out0"},
        opts
    )
    info.dict_path = dict_path
    info.model_info.dict_path = dict_path
    return info
end

local function assert_open(self)
    if self.closed then
        error("object is closed")
    end
end

function instance_mt:recognize_line(input, opts)
    assert_open(self)
    opts = opts or {}
    local line = recognize_line(self, resolve_image_object(input))
    if opts.return_text_only then
        return line.text
    end
    return line
end

function instance_mt:classification(input, opts)
    opts = opts or {}
    if opts.return_details == nil and opts.return_text_only == nil then
        opts.return_text_only = true
    end
    return self:recognize_line(input, opts)
end

function instance_mt:recognize(input, opts)
    assert_open(self)
    opts = opts or {}
    local img = resolve_image_object(input)
    local detections = detect_image(self, img)
    local lines, rec_stats = decode_rec_detections(self, img, detections)
    sort_text_boxes(lines)
    local result = {
        text = join_text(lines),
        lines = lines,
    }
    if opts.return_stats then
        result.stats = {
            rec = rec_stats,
            det = {count = #detections},
        }
    end
    return result
end

function instance_mt:ocr(input, opts)
    return self:recognize(input, opts)
end

function instance_mt:detect(input)
    assert_open(self)
    local detections = detect_image(self, resolve_image_object(input))
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
    return {
        rec = shallow_copy_table(self.rec.model_info),
        det = self.det_session and shallow_copy_table(self.det_session.model_info) or nil,
        dict_path = self.rec.dict_path,
        det_config = shallow_copy_table(self.det_config),
        rec_config = shallow_copy_table(self.rec_config),
    }
end

function instance_mt:close()
    if self.closed then
        return true
    end
    self.closed = true
    if self.det_session and self.det_session.session then
        self.det_session.session:close()
    end
    if self.rec and self.rec.session then
        self.rec.session:close()
    end
    self.det_session = nil
    self.rec = nil
    self.charset = nil
    self.det_config = nil
    self.rec_config = nil
    return true
end

function instance_mt:__tostring()
    if self.closed then
        return "paddleocr_ncnn{closed}"
    end
    return "paddleocr_ncnn{open}"
end

local M = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

function M.new(opts)
    opts = opts or {}
    local rec = make_rec_session(opts)
    local det = make_det_session(opts)
    local instance = {
        closed = false,
        rec = rec,
        det_session = det,
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
            image_height = math.max(1, tonumber(opts.rec_image_height or opts.rec_height) or DEFAULT_REC_CONFIG.image_height),
            min_width = math.max(1, tonumber(opts.rec_min_width) or DEFAULT_REC_CONFIG.min_width),
            max_width = math.max(1, tonumber(opts.rec_max_width) or DEFAULT_REC_CONFIG.max_width),
            bucket_width = opts.rec_bucket_width == nil and DEFAULT_REC_CONFIG.bucket_width or (opts.rec_bucket_width == true),
            bucket_width_stride = math.max(1, tonumber(opts.rec_bucket_width_stride) or DEFAULT_REC_CONFIG.bucket_width_stride),
            apply_softmax = opts.rec_apply_softmax == true or DEFAULT_REC_CONFIG.apply_softmax,
            values_are_probabilities = opts.rec_values_are_probabilities == nil and
                DEFAULT_REC_CONFIG.values_are_probabilities or
                (opts.rec_values_are_probabilities == true),
        },
    }
    return setmetatable(instance, instance_mt)
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

M.create = M.new
M.open = M.new
M.__index = M

return M
