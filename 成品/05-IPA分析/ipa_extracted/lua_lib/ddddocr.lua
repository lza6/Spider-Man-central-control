--[[
ddddocr.lua

Created by 苏泽 on 26-03-30.
Copyright (c) 2026年 苏泽. All rights reserved.

基于 XXTouch 内置 onnxruntime 模块的 ddddocr 封装。

项目地址:
https://github.com/sml2h3/ddddocr

模型文件和字符集文件在这里下载:
https://github.com/86maid/ddddocr/tree/master/model

把以下模型文件放到
/var/mobile/Media/1ferver/models/ddddocr/common_old.onnx
/var/mobile/Media/1ferver/models/ddddocr/common_old.json
/var/mobile/Media/1ferver/models/ddddocr/common.onnx
/var/mobile/Media/1ferver/models/ddddocr/common.json
/var/mobile/Media/1ferver/models/ddddocr/common_det.onnx

支持能力:
- OCR 文字识别
- DET 目标检测
- slide_match 滑块模板匹配
- slide_comparison 滑块缺口比对

支持的图片输入:
- 文件路径
- 图片原始字节
- BASE64 字符串
- image 对象

示例:

基础用法:

1. OCR

local ddddocr = require("ddddocr")
local ocr = ddddocr.new({
    ocr = true,
    show_ad = false,
})
local text = ocr:classification("/path/to/captcha.png")

带概率输出:

local result = ocr:classification("/path/to/captcha.png", {
    probability = true,
})
print(result.text, result.confidence)

限制字符集:

ocr:set_ranges("0123456789")
local text = ocr:classification("/path/to/captcha.png")

也可以在单次调用里传 charset_range:

local text = ocr:classification("/path/to/captcha.png", {
    charset_range = "ABCDEFG123456",
})

可选 OCR 参数:
- png_fix = true
- color_filter_colors = {"red", "blue"}
- color_filter_custom_ranges = {
    {{h_min, s_min, v_min}, {h_max, s_max, v_max}},
}
- probability = true
- charset_range = "0123456789"

2. DET

local ddddocr = require("ddddocr")
local det = ddddocr.new({
    det = true,
    show_ad = false,
})
local boxes = det:det("/path/to/image.png")
for i = 1, #boxes do
    local box = boxes[i]
    print(box[1], box[2], box[3], box[4])
end

3. Slide

local ddddocr = require("ddddocr")

复杂滑块:
local result = ddddocr.slide_match(target_img, background_img)
print(result.target_x, result.target_y, result.confidence)

简单滑块:
local result = ddddocr.slide_match(target_img, background_img, true)

缺口比对:
local diff = ddddocr.slide_comparison(target_img, background_img)
print(diff.target_x, diff.target_y)

4. 自定义模型

OCR 自定义模型:

local ocr = ddddocr.new({
    ocr = true,
    import_onnx_path = "/path/to/model.onnx",
    charsets_path = "/path/to/model.json",
    show_ad = false,
})

DET 自定义模型:

local det = ddddocr.new({
    det = true,
    import_onnx_path = "/path/to/det.onnx",
    show_ad = false,
})

5. 清理对象

ocr:close()
det:close()

构造参数:
- ocr = true/false
- det = true/false
- old = true/false
- beta = true/false
- show_ad = true/false
- model_dir = "/path/to/model_dir"
- import_onnx_path = "/path/to/model.onnx"
- charsets_path = "/path/to/model.json"
- providers = {"cpu"} 或 {"coreml", "cpu"}
- fallback_to_cpu = true/false
- coreml_compute_units = "all" | "cpu_only" | "cpu_and_gpu" | "cpu_and_neural_engine"
- coreml_enable_on_subgraph = true/false
- coreml_require_static_input_shapes = true/false
- coreml_create_mlprogram = true/false

说明:
- 以上 CoreML 参数会原样透传给 onnxruntime.session(...)
]]
local ort = require("onnxruntime")
local cv = require("image.cv")
local common = require("yolo_backend_common")

local VERSION = "0.1.4"
local XXT_HOME_PATH = XXT_HOME_PATH or "/var/mobile/Media/1ferver"
local PRIMARY_MODEL_ROOT = XXT_HOME_PATH .. "/models/ddddocr"
local LEGACY_MODEL_ROOT = "/var/mobile/Media/1ferver/models/ddddocr"
local DET_INPUT_SIZE = 416
local DET_NMS_BOX_BIAS = assert(ort.tensor("float32", {4}, {0, 0, 1, 1}))

local COLOR_PRESETS = {
    black = {
        {0, 0, 0, 180, 255, 50},
    },
    blue = {
        {100, 50, 50, 130, 255, 255},
    },
    cyan = {
        {80, 50, 50, 100, 255, 255},
    },
    gray = {
        {0, 0, 50, 180, 30, 200},
    },
    green = {
        {40, 50, 50, 80, 255, 255},
    },
    orange = {
        {10, 50, 50, 20, 255, 255},
    },
    purple = {
        {130, 50, 50, 170, 255, 255},
    },
    red = {
        {0, 50, 50, 10, 255, 255},
        {170, 50, 50, 180, 255, 255},
    },
    white = {
        {0, 0, 200, 180, 30, 255},
    },
    yellow = {
        {20, 50, 50, 40, 255, 255},
    },
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

local function sorted_keys(map)
    local keys = {}
    for key in pairs(map) do
        keys[#keys + 1] = key
    end
    table.sort(keys)
    return keys
end

local file_exists = common.file_exists
local clone_array = common.clone_array
local shallow_copy_table = common.shallow_copy_table
local normalize_provider_list = common.normalize_provider_list
local provider_list_contains = common.provider_list_contains
local resolve_image_object = common.resolve_image_input
local has_provider = function(full_name)
    return common.available_provider_names_contains(PROVIDERS, full_name)
end

local function utf8_chars(text)
    local chars = {}
    local starts = {}
    for byte_index in utf8.codes(text) do
        starts[#starts + 1] = byte_index
    end
    if #starts == 0 then
        return chars
    end
    starts[#starts + 1] = #text + 1
    for i = 1, #starts - 1 do
        chars[#chars + 1] = text:sub(starts[i], starts[i + 1] - 1)
    end
    return chars
end

local function dedup_indices(indices)
    local seen = {}
    local out = {}
    for i = 1, #indices do
        local value = indices[i]
        if not seen[value] then
            seen[value] = true
            out[#out + 1] = value
        end
    end
    return out
end

local function is_image_object(value)
    return type(image.is) == "function" and image.is(value)
end

local function ensure_editable_image(input, need_copy)
    local img, owns_image = resolve_image_object(input)
    if need_copy and not owns_image then
        if type(img.copy) == "function" then
            img = img:copy()
        else
            local png_data = img and img.png_data and img:png_data()
            if not png_data then
                error("图片复制失败: 传入对象缺少 copy() 和 png_data()")
            end
            img = image.load_data(png_data)
        end
    end
    return img
end

local function build_slide_result(left, top, width, height, confidence)
    local center_x = math.floor(left + width / 2)
    local center_y = math.floor(top + height / 2)
    return {
        target = { center_x, center_y },
        target_x = center_x,
        target_y = center_y,
        confidence = confidence,
    }
end

local function largest_contour(contours)
    local best_contour
    local best_area = -1
    for i = 1, #contours do
        local contour = contours[i]
        local area = cv.contour_area(contour)
        if area > best_area then
            best_area = area
            best_contour = contour
        end
    end
    return best_contour, best_area
end

local function apply_png_fix(img)
    local normalized = cv.to_image(cv.from_image(img))
    local width, height = normalized:size()
    local flattened = image.new(width, height)
    flattened:replace_color(0x00000000, 0xFFFFFFFF)
    flattened:draw_image(normalized)
    return flattened
end

local function get_color_filter_colors(opts)
    return opts.color_filter_colors
end

local function get_color_filter_custom_ranges(opts)
    return opts.color_filter_custom_ranges
end

local function validate_custom_color_range(range, index)
    if type(range) ~= "table" then
        error("color_filter_custom_ranges[" .. index .. "] 必须是 {{h, s, v}, {h, s, v}} 或 {h_min, s_min, v_min, h_max, s_max, v_max}")
    end

    local entry
    if type(range[1]) == "table" and type(range[2]) == "table" then
        local lower = range[1]
        local upper = range[2]
        entry = {
            lower_h = assert(tonumber(lower[1]), "color_filter_custom_ranges[" .. index .. "][1][1] 必须是数字"),
            lower_s = assert(tonumber(lower[2]), "color_filter_custom_ranges[" .. index .. "][1][2] 必须是数字"),
            lower_v = assert(tonumber(lower[3]), "color_filter_custom_ranges[" .. index .. "][1][3] 必须是数字"),
            upper_h = assert(tonumber(upper[1]), "color_filter_custom_ranges[" .. index .. "][2][1] 必须是数字"),
            upper_s = assert(tonumber(upper[2]), "color_filter_custom_ranges[" .. index .. "][2][2] 必须是数字"),
            upper_v = assert(tonumber(upper[3]), "color_filter_custom_ranges[" .. index .. "][2][3] 必须是数字"),
        }
    else
        entry = {
            lower_h = assert(tonumber(range.lower_h ~= nil and range.lower_h or range[1]), "color_filter_custom_ranges[" .. index .. "][1] 必须是数字"),
            lower_s = assert(tonumber(range.lower_s ~= nil and range.lower_s or range[2]), "color_filter_custom_ranges[" .. index .. "][2] 必须是数字"),
            lower_v = assert(tonumber(range.lower_v ~= nil and range.lower_v or range[3]), "color_filter_custom_ranges[" .. index .. "][3] 必须是数字"),
            upper_h = assert(tonumber(range.upper_h ~= nil and range.upper_h or range[4]), "color_filter_custom_ranges[" .. index .. "][4] 必须是数字"),
            upper_s = assert(tonumber(range.upper_s ~= nil and range.upper_s or range[5]), "color_filter_custom_ranges[" .. index .. "][5] 必须是数字"),
            upper_v = assert(tonumber(range.upper_v ~= nil and range.upper_v or range[6]), "color_filter_custom_ranges[" .. index .. "][6] 必须是数字"),
        }
    end

    if entry.lower_h < 0 or entry.lower_h > 180 or entry.upper_h < 0 or entry.upper_h > 180 or
       entry.lower_s < 0 or entry.lower_s > 255 or entry.upper_s < 0 or entry.upper_s > 255 or
       entry.lower_v < 0 or entry.lower_v > 255 or entry.upper_v < 0 or entry.upper_v > 255 or
       entry.lower_h > entry.upper_h or entry.lower_s > entry.upper_s or entry.lower_v > entry.upper_v then
        error("color_filter_custom_ranges[" .. index .. "] 存在非法 HSV 范围")
    end
    return entry
end

local function normalize_hsv_range(range)
    if range.lower_h ~= nil then
        return range
    end
    return {
        lower_h = range[1],
        lower_s = range[2],
        lower_v = range[3],
        upper_h = range[4],
        upper_s = range[5],
        upper_v = range[6],
    }
end

local function build_hsv_ranges(opts)
    local ranges = {}

    local custom_ranges = get_color_filter_custom_ranges(opts)

    if custom_ranges ~= nil then
        if type(custom_ranges) ~= "table" then
            error("color_filter_custom_ranges 必须是数组")
        end
        for i = 1, #custom_ranges do
            ranges[#ranges + 1] = validate_custom_color_range(custom_ranges[i], i)
        end
    end

    local colors = get_color_filter_colors(opts)
    if colors ~= nil then
        if type(colors) ~= "table" then
            error("color_filter_colors 必须是字符串数组")
        end
        for i = 1, #colors do
            local name = colors[i]
            local preset = COLOR_PRESETS[name]
            if not preset then
                error("不支持的颜色预设: " .. tostring(name))
            end
            for j = 1, #preset do
                ranges[#ranges + 1] = normalize_hsv_range(preset[j])
            end
        end
    end

    return ranges
end

local function apply_color_filter(img, opts)
    local ranges = build_hsv_ranges(opts)
    if #ranges == 0 then
        return img
    end

    local src_mat = cv.cvt_color(cv.from_image(img), "bgra2bgr")
    local hsv_mat = cv.cvt_color(src_mat, "bgr2hsv")
    local mask = nil
    for i = 1, #ranges do
        local range = ranges[i]
        local current = cv.in_range(
            hsv_mat,
            {range.lower_h, range.lower_s, range.lower_v},
            {range.upper_h, range.upper_s, range.upper_v}
        )
        if mask == nil then
            mask = current
        else
            mask = cv.bitwise_or(mask, current)
        end
    end

    local inverse_mask = cv.bitwise_not(mask)
    local foreground = cv.bitwise_and(src_mat, src_mat, mask)
    local background = cv.set_to(src_mat, 0xFFFFFF)
    background = cv.bitwise_and(background, background, inverse_mask)
    return cv.to_image(cv.bitwise_or(foreground, background))
end

local function resolve_resource_path(explicit_path, model_dir, filename)
    return common.resolve_named_resource(explicit_path,
        common.build_search_roots({model_dir = model_dir}, PRIMARY_MODEL_ROOT, LEGACY_MODEL_ROOT),
        {filename},
        true)
end

local function load_charset_config(json_path)
    local payload = file.reads(json_path)
    local object = json.decode(payload)
    if type(object) ~= "table" then
        error("字符集文件解析失败")
    end

    if type(object.charset) ~= "table" or type(object.image) ~= "table" or type(object.word) ~= "boolean" or type(object.channel) ~= "number" then
        error("字符集文件缺少必需字段")
    end

    if #object.charset == 0 then
        error("字符集文件为空")
    end

    local charset = {}
    local character_to_index = {}
    for index = 1, #object.charset do
        local char = object.charset[index]
        if type(char) ~= "string" then
            error("字符集文件格式错误: charset 项必须为字符串")
        end
        charset[index] = char
        if character_to_index[char] == nil then
            character_to_index[char] = index - 1
        end
    end

    local image_shape = {}
    for i = 1, #object.image do
        local dim = tonumber(object.image[i])
        if not dim then
            error("字符集文件格式错误: image 项必须为数字")
        end
        image_shape[i] = dim
    end
    if #image_shape < 2 then
        image_shape = {-1, 64}
    end

    return {
        charset = charset,
        character_to_index = character_to_index,
        word = object.word,
        image = image_shape,
        channel = tonumber(object.channel) or 1,
    }
end

local function build_session_options(opts)
    return common.build_ort_session_options(opts, COREML_SESSION_OPTION_KEYS, {
        intra_op_num_threads = 1,
        graph_optimization_level = "all",
    })
end

local function build_model_info(mode, model_path, session, opts, used_coreml)
    return common.build_ort_model_info(model_path, session, opts, used_coreml, {
        mode = mode,
        device_id = tonumber(opts.device_id) or 0,
    })
end

local function build_charset_selection_from_string(self, text)
    local indices = {}
    for _, char in ipairs(utf8_chars(text)) do
        local index = self.charset_config.character_to_index[char]
        if index ~= nil then
            indices[#indices + 1] = index
        end
    end
    return {
        has_range = true,
        valid_indices = dedup_indices(indices),
    }
end

local function build_charset_selection_from_table(self, values)
    local indices = {}
    for i = 1, #values do
        local char = values[i]
        if type(char) ~= "string" or char == "" then
            error("字符集范围列表中的元素必须是非空字符串")
        end
        local index = self.charset_config.character_to_index[char]
        if index ~= nil then
            indices[#indices + 1] = index
        end
    end
    return {
        has_range = true,
        valid_indices = dedup_indices(indices),
    }
end

local function build_charset_selection_from_prefix(self, max_index)
    if max_index < 0 then
        error("字符集范围索引必须为非负整数")
    end
    local end_index = math.min(max_index, #self.charset_config.charset - 1)
    local indices = {}
    for index = 0, end_index do
        indices[#indices + 1] = index
    end
    return {
        has_range = true,
        valid_indices = indices,
    }
end

local function build_charset_selection(self, value)
    if value == nil then
        return nil
    end
    if self.mode ~= "ocr" then
        error("目标检测模式不支持字符集设置")
    end
    if math.type and math.type(value) == "integer" or type(value) == "number" and value == math.floor(value) then
        return build_charset_selection_from_prefix(self, value)
    end
    if type(value) == "string" then
        return build_charset_selection_from_string(self, value)
    end
    if type(value) == "table" then
        return build_charset_selection_from_table(self, value)
    end
    error("不支持的字符集范围类型")
end

local function build_ctc_charset_table(self, selection)
    if not selection or not selection.has_range then
        return self.charset_config.charset
    end
    local charset = {}
    for i = 1, #selection.valid_indices do
        local index = selection.valid_indices[i]
        local char = self.charset_config.charset[index + 1]
        if char ~= nil then
            charset[index + 1] = char
        end
    end
    return charset
end

local function normalize_ocr_decode_tensor(tensor)
    local shape = tensor:shape()
    if #shape == 3 then
        if shape[2] == 1 then
            return assert(tensor:squeeze(2))
        end
        if shape[1] == 1 then
            return assert(tensor:squeeze(1))
        end
        return assert(tensor:select(1, 1))
    end
    if #shape == 2 then
        return tensor
    end
    if #shape == 1 then
        return assert(tensor:unsqueeze(1))
    end
    error("OCR 输出维度不受支持")
end

local function assert_open(self)
    if self.closed then
        error("对象已关闭")
    end
end

local function flatten_access(data, seq_index, class_index, num_classes)
    return data[(seq_index - 1) * num_classes + class_index]
end

local function build_tensor_flatten_accessor(tensor, shape)
    if #shape == 3 then
        if shape[2] == 1 then
            return function(seq_index, class_index)
                return tensor:get(seq_index, 1, class_index)
            end
        end
        return function(seq_index, class_index)
            return tensor:get(1, seq_index, class_index)
        end
    end
    if #shape == 2 then
        return function(seq_index, class_index)
            return tensor:get(seq_index, class_index)
        end
    end
    if #shape == 1 then
        return function(_, class_index)
            return tensor:get(class_index)
        end
    end

    local data = tensor:to_table()
    return function(seq_index, class_index, num_classes)
        return flatten_access(data, seq_index, class_index, num_classes)
    end
end

local function resolve_ocr_sequence_layout(shape)
    local sequence_length
    local num_classes
    if #shape == 3 then
        if shape[2] == 1 then
            sequence_length = shape[1]
            num_classes = shape[3]
        elseif shape[1] == 1 then
            sequence_length = shape[2]
            num_classes = shape[3]
        else
            sequence_length = shape[2]
            num_classes = shape[3]
        end
    elseif #shape == 2 then
        sequence_length = shape[1]
        num_classes = shape[2]
    elseif #shape == 1 then
        sequence_length = 1
        num_classes = shape[1]
    else
        error("OCR 输出维度不受支持")
    end

    return sequence_length, num_classes
end

local function build_ocr_probability_details(tensor)
    local shape = tensor:shape()
    local read_value = build_tensor_flatten_accessor(tensor, shape)
    local sequence_length, num_classes = resolve_ocr_sequence_layout(shape)

    local probabilities = {}
    local confidence_sum = 0.0
    for seq = 1, sequence_length do
        local row = {}
        local max_value = read_value(seq, 1, num_classes)
        for cls = 2, num_classes do
            local value = read_value(seq, cls, num_classes)
            if value > max_value then
                max_value = value
            end
        end

        local exp_sum = 0.0
        local row_best = 0.0
        for cls = 1, num_classes do
            local probability = math.exp(read_value(seq, cls, num_classes) - max_value)
            row[cls] = probability
            exp_sum = exp_sum + probability
        end
        for cls = 1, num_classes do
            row[cls] = row[cls] / exp_sum
            if row[cls] > row_best then
                row_best = row[cls]
            end
        end
        probabilities[seq] = row
        confidence_sum = confidence_sum + row_best
    end

    return probabilities, sequence_length > 0 and (confidence_sum / sequence_length) or 0.0
end

local function decode_ocr_output(self, tensor, selection, with_probability)
    local decoded = assert(ort.ctc_greedy_decode(
        normalize_ocr_decode_tensor(tensor),
        {
            charset = build_ctc_charset_table(self, selection),
            return_probabilities = with_probability,
        }
    ))

    local result = {
        text = decoded.text or "",
        confidence = tonumber(decoded.confidence) or 0.0,
    }
    if with_probability then
        result.probabilities = decoded.probabilities or {}
        result.charset = clone_array(self.charset_config.charset)
    end

    return result
end

local function compute_ocr_target_size(self, img)
    local width, height = img:size()
    local image_shape = self.charset_config.image
    local resize_width = image_shape[1] or -1
    local resize_height = image_shape[2] or 64
    local dynamic_width = resize_width == -1

    local target_width = width
    local target_height = height
    if dynamic_width then
        if self.charset_config.word then
            target_width = resize_height
            target_height = resize_height
        else
            target_height = resize_height
            local scale = resize_height / math.max(1, height)
            target_width = math.max(1, math.floor(width * scale + 0.5))
        end
    else
        target_width = math.max(1, resize_width)
        target_height = math.max(1, resize_height)
    end
    return target_width, target_height
end

local function prepare_ocr_tensor(self, input, opts)
    local color_filter_colors = get_color_filter_colors(opts)
    local color_filter_custom_ranges = get_color_filter_custom_ranges(opts)
    local need_copy = opts.png_fix or (color_filter_colors and #color_filter_colors > 0) or
        (color_filter_custom_ranges and #color_filter_custom_ranges > 0)
    local img = ensure_editable_image(input, need_copy)

    if opts.png_fix then
        img = apply_png_fix(img)
    end
    if (color_filter_colors and #color_filter_colors > 0) or (color_filter_custom_ranges and #color_filter_custom_ranges > 0) then
        img = apply_color_filter(img, opts)
    end

    local target_width, target_height = compute_ocr_target_size(self, img)
    local tensor = ort.tensor_from_image(img, {
        width = target_width,
        height = target_height,
        layout = "nchw",
        add_batch = true,
        channel_order = self.charset_config.channel == 1 and "gray" or "rgb",
        data_type = "float32",
        scale = 1.0 / 255.0,
    })
    return tensor
end

local function run_single_output(self, tensor)
    local outputs = self.session:run({
        [self.model_info.input_name] = tensor,
    }, self.output_names)

    return outputs[self.output_names[1]] or outputs[1], outputs
end

local function decode_det_output(tensor, meta)
    local decoded = assert(ort.decode_dense_detection(tensor, {
        strides = {8, 16, 32},
        decode_width = DET_INPUT_SIZE,
        decode_height = DET_INPUT_SIZE,
        box_encoding = "grid_center_log_wh",
        has_objectness = true,
        clip_boxes = false,
        score_threshold = 0.1,
        meta = meta,
    }))
    local nms_boxes = assert(decoded.boxes:add(DET_NMS_BOX_BIAS))
    local keep = assert(ort.nms(nms_boxes, decoded.scores, {
        iou_threshold = 0.45,
    }))
    local selected_boxes = assert(decoded.boxes:gather(1, keep))
    local selected_scores = assert(decoded.scores:gather(1, keep))
    local selected_labels = assert(decoded.labels:gather(1, keep))
    local records = assert(ort.records_from_boxes(
        selected_boxes,
        selected_scores,
        selected_labels,
        keep
    ))
    local image_width = meta.src_width or meta.dst_width or DET_INPUT_SIZE
    local image_height = meta.src_height or meta.dst_height or DET_INPUT_SIZE
    local boxes = {}
    for i = 1, #records do
        local box = records[i].box
        boxes[i] = {
            math.max(0, math.floor(box[1])),
            math.max(0, math.floor(box[2])),
            math.min(image_width, math.ceil(box[3])),
            math.min(image_height, math.ceil(box[4])),
        }
    end

    return boxes
end

local function prepare_det_tensor(input)
    local img = ensure_editable_image(input, false)
    local tensor, meta = ort.tensor_from_image(img, {
        width = DET_INPUT_SIZE,
        height = DET_INPUT_SIZE,
        layout = "nchw",
        add_batch = true,
        channel_order = "bgr",
        data_type = "float32",
        scale = 1.0,
        resize_mode = "letterbox",
        letterbox_mode = "top_left",
        pad_color = 0x727272,
    })
    return tensor, meta
end

local function create_ocr_instance(opts)
    if opts.old and opts.beta then
        error("old 和 beta 不能同时为 true")
    end

    local model_path
    local charset_path
    if opts.import_onnx_path and opts.import_onnx_path ~= "" then
        if not opts.charsets_path or opts.charsets_path == "" then
            error("自定义 OCR 模型必须同时提供 charsets_path")
        end
        model_path = resolve_resource_path(opts.import_onnx_path, opts.model_dir, "")
        charset_path = resolve_resource_path(opts.charsets_path, opts.model_dir, "")
    else
        local model_file = opts.beta and "common.onnx" or "common_old.onnx"
        local charset_file = opts.beta and "common.json" or "common_old.json"
        model_path = resolve_resource_path(nil, opts.model_dir, model_file)
        charset_path = resolve_resource_path(nil, opts.model_dir, charset_file)
    end

    local session = assert(ort.session(model_path, build_session_options(opts)))
    local requested_providers = normalize_provider_list(opts.providers)
    local used_coreml = provider_list_contains(requested_providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local charset_config = load_charset_config(charset_path)
    local model_info = build_model_info("ocr", model_path, session, opts, used_coreml)

    return {
        mode = "ocr",
        closed = false,
        session = session,
        model_info = model_info,
        output_names = session:output_names(),
        charset_config = charset_config,
        persistent_charset_range = nil,
        device_id = tonumber(opts.device_id) or 0,
    }
end

local function create_det_instance(opts)
    local model_path = resolve_resource_path(opts.import_onnx_path, opts.model_dir, "common_det.onnx")
    local session = ort.session(model_path, build_session_options(opts))
    local requested_providers = normalize_provider_list(opts.providers)
    local used_coreml = provider_list_contains(requested_providers, "coreml") and has_provider("CoreMLExecutionProvider")
    local model_info = build_model_info("detection", model_path, session, opts, used_coreml)

    return {
        mode = "det",
        closed = false,
        session = session,
        model_info = model_info,
        output_names = session:output_names(),
        device_id = tonumber(opts.device_id) or 0,
    }
end

local function create_slide_instance(opts)
    return {
        mode = "slide",
        closed = false,
        session = nil,
        model_info = {
            mode = "slide",
            model_path = nil,
            used_coreml = false,
            device_id = tonumber(opts.device_id) or 0,
            input_name = nil,
            input_shape = {},
            providers = {},
            outputs = {},
        },
        output_names = {},
        device_id = tonumber(opts.device_id) or 0,
    }
end

local function show_ad()
    print("欢迎使用 ddddocr，本项目专注带动行业内卷，个人博客:wenanzhe.com")
    print("训练数据支持来源于:http://146.56.204.113:19199/preview")
    print("爬虫框架 feapder 可快速一键接入，快速开启爬虫之旅：https://github.com/Boris-code/feapder")
    print("谷歌 reCaptcha / hCaptcha / funCaptcha 商业级识别接口：https://yescaptcha.com/i/NSwk7i")
end

function instance_mt:ocr(input, opts)
    assert_open(self)
    if self.mode ~= "ocr" then
        error("当前识别类型不支持文字识别")
    end
    opts = opts or {}
    local tensor = prepare_ocr_tensor(self, input, opts)
    local output = run_single_output(self, tensor)
    local runtime_range = build_charset_selection(self, opts.charset_range)
    local selection = runtime_range or self.persistent_charset_range
    local result = decode_ocr_output(self, output, selection, opts.probability == true)
    if opts.probability then
        return result
    end
    return result.text
end

function instance_mt:classification(input, opts)
    return self:ocr(input, opts)
end

function instance_mt:det(input)
    assert_open(self)
    if self.mode ~= "det" then
        error("当前识别类型不支持目标检测")
    end
    local tensor, meta = prepare_det_tensor(input)
    local output = run_single_output(self, tensor)
    return decode_det_output(output, meta)
end

function instance_mt:detect(input)
    return self:det(input)
end

function instance_mt:detection(input)
    return self:det(input)
end

local function perform_slide_match(target, background, simple_target)
    local target_img = ensure_editable_image(target, false)
    local background_img = ensure_editable_image(background, false)
    local target_w, target_h = target_img:size()
    local background_gray = cv.cvt_color(background_img, "bgr2gray")
    local target_gray = cv.cvt_color(target_img, "bgr2gray")

    local match_source = background_gray
    local match_target = target_gray
    if simple_target ~= true then
        match_source = cv.canny(background_gray, 50, 150)
        match_target = cv.canny(target_gray, 50, 150)
    end

    local response = cv.match_template(match_source, match_target, "ccoeff_normed")
    local stats = cv.min_max_loc(response)
    return build_slide_result(stats.max_loc.x, stats.max_loc.y, target_w, target_h, stats.max_val)
end

local function perform_slide_comparison(target, background)
    local target_img = ensure_editable_image(target, false)
    local background_img = ensure_editable_image(background, false)
    local target_w, target_h = target_img:size()
    local background_w, background_h = background_img:size()
    if target_w ~= background_w or target_h ~= background_h then
        error("slide_comparison 要求两张图片尺寸一致")
    end

    local diff = cv.absdiff(target_img, background_img)
    local gray = cv.cvt_color(diff, "bgr2gray")
    local binary = cv.threshold(gray, 30, 255, "binary")
    local kernel = cv.get_structuring_element("rect", 3, 3)
    local closed = cv.morphology_ex(binary, "close", kernel)
    local opened = cv.morphology_ex(closed, "open", kernel)
    local contours = cv.find_contours(opened, "external", "simple")
    local contour, area = largest_contour(contours)
    if not contour or area <= 0 then
        return build_slide_result(0, 0, 0, 0, 0.0)
    end

    local rect = cv.bounding_rect(contour)
    return build_slide_result(rect.x, rect.y, rect.width, rect.height, 1.0)
end

function instance_mt:slide_match(target, background, simple_target)
    assert_open(self)
    return perform_slide_match(target, background, simple_target)
end

function instance_mt:slide_comparison(target, background)
    assert_open(self)
    return perform_slide_comparison(target, background)
end

function instance_mt:set_ranges(value)
    assert_open(self)
    if self.mode ~= "ocr" then
        error("目标检测模式不支持字符集设置")
    end
    local selection = build_charset_selection(self, value)
    if not selection then
        error("字符集范围不能为空")
    end
    self.persistent_charset_range = selection
    return true
end

function instance_mt:get_charset()
    assert_open(self)
    if self.mode ~= "ocr" then
        error("目标检测模式不支持字符集获取")
    end
    return clone_array(self.charset_config.charset)
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
    self.model_info = nil
    self.output_names = nil
    self.charset_config = nil
    self.persistent_charset_range = nil
    return nil
end

function instance_mt:__tostring()
    if self.closed then
        return "ddddocr{closed}"
    end
    return string.format("ddddocr{%s}", self.mode or "unknown")
end

local module = {
    VERSION = VERSION,
    AUTHOR = "XXTouch",
}

function module.new(opts)
    opts = opts or {}
    if type(opts) ~= "table" then
        error("ddddocr.new 期望 table 参数")
    end
    if opts.use_gpu ~= nil then
        error("use_gpu 已移除，请显式传 providers = {\"coreml\", \"cpu\"} 或 providers = {\"cpu\"}")
    end

    local normalized = {
        ocr = opts.ocr ~= false,
        det = opts.det == true,
        old = opts.old == true,
        beta = opts.beta == true,
        device_id = opts.device_id or 0,
        show_ad = opts.show_ad ~= false,
        model_dir = opts.model_dir,
        import_onnx_path = opts.import_onnx_path,
        charsets_path = opts.charsets_path,
        fallback_to_cpu = opts.fallback_to_cpu,
        providers = normalize_provider_list(opts.providers),
    }
    for i = 1, #COREML_SESSION_OPTION_KEYS do
        local key = COREML_SESSION_OPTION_KEYS[i]
        if opts[key] ~= nil then
            normalized[key] = opts[key]
        end
    end

    local instance
    if normalized.det then
        instance = create_det_instance(normalized)
    elseif normalized.ocr or (normalized.import_onnx_path and normalized.import_onnx_path ~= "") then
        instance = create_ocr_instance(normalized)
    else
        instance = create_slide_instance(normalized)
    end

    if normalized.show_ad then
        show_ad()
    end

    return setmetatable(instance, instance_mt)
end

function module.available_colors()
    return sorted_keys(COLOR_PRESETS)
end

function module.slide_match(target, background, simple_target)
    return perform_slide_match(target, background, simple_target)
end

function module.slide_comparison(target, background)
    return perform_slide_comparison(target, background)
end

function module.version()
    return VERSION
end

return module
