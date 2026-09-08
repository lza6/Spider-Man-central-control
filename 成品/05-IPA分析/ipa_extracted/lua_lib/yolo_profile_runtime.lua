local M = {}
local common = require("yolo_backend_common")
local shallow_copy_table = common.shallow_copy_table
local clone_array = common.clone_array

local SUPPORTED_TASKS = {"detect", "seg", "pose", "obb", "track", "classify"}
local PROFILE_TASK_ALIASES = {
    det = "detect",
    detect = "detect",
    detection = "detect",
    track = "track",
    tracking = "track",
    seg = "seg",
    segment = "seg",
    segmentation = "seg",
    pose = "pose",
    kpt = "pose",
    obb = "obb",
    oriented = "obb",
    oriented_bbox = "obb",
    oriented_box = "obb",
    cls = "classify",
    classify = "classify",
    classification = "classify",
}

function M.deep_copy(value)
    if type(value) ~= "table" then
        return value
    end
    local out = {}
    for key, entry in pairs(value) do
        out[key] = M.deep_copy(entry)
    end
    return out
end

local function is_array_like_table(value)
    if type(value) ~= "table" then
        return false
    end
    local count = 0
    local max_index = 0
    for key, _ in pairs(value) do
        if type(key) ~= "number" or key < 1 or key % 1 ~= 0 then
            return false
        end
        count = count + 1
        if key > max_index then
            max_index = key
        end
    end
    return count == max_index
end

function M.deep_merge(base, override)
    if override == nil then
        return M.deep_copy(base)
    end
    if type(base) ~= "table" or type(override) ~= "table" then
        return M.deep_copy(override)
    end
    local out = M.deep_copy(base)
    for key, value in pairs(override) do
        if type(value) == "table" and type(out[key]) == "table" and
            not is_array_like_table(value) and not is_array_like_table(out[key]) then
            out[key] = M.deep_merge(out[key], value)
        else
            out[key] = M.deep_copy(value)
        end
    end
    return out
end

function M.supported_tasks()
    return clone_array(SUPPORTED_TASKS)
end

function M.normalize_profile_task(task)
    if task == nil then
        return nil
    end
    local normalized = PROFILE_TASK_ALIASES[tostring(task):lower()]
    if not normalized then
        error("unsupported profile task: " .. tostring(task))
    end
    return normalized
end

function M.base_task_for_profile_task(task)
    task = M.normalize_profile_task(task)
    if task == "track" or task == "seg" or task == "pose" then
        return "detect"
    end
    return task
end

function M.parse_task_call_options(conf, iou, opts)
    if type(conf) == "table" and iou == nil and opts == nil then
        opts = conf
        conf = nil
    end
    local out = shallow_copy_table(opts or {})
    if conf ~= nil then
        out.confidence = conf
    end
    if iou ~= nil then
        out.iou = iou
    end
    return out
end

local function resolve_named_output(outputs, output_names, index)
    if type(index) ~= "number" then
        return nil, nil
    end
    local output_name = output_names and output_names[index] or nil
    if output_name ~= nil and outputs[output_name] ~= nil then
        return outputs[output_name], output_name
    end
    if outputs[index] ~= nil then
        return outputs[index], index
    end
    return nil, nil
end

function M.resolve_output_spec(outputs, output_names, spec, fallback_index)
    if type(spec) == "string" and outputs[spec] ~= nil then
        return outputs[spec], spec
    end
    local numeric_spec = tonumber(spec)
    if numeric_spec then
        local output, resolved_spec = resolve_named_output(outputs, output_names, numeric_spec)
        if output ~= nil then
            return output, resolved_spec
        end
    end
    if type(spec) == "table" then
        if spec.name and outputs[spec.name] ~= nil then
            return outputs[spec.name], spec.name
        end
        if spec.index then
            local numeric_index = tonumber(spec.index)
            if numeric_index then
                local output, resolved_spec = resolve_named_output(outputs, output_names, numeric_index)
                if output ~= nil then
                    return output, resolved_spec
                end
            end
        end
    end
    local output, resolved_spec = resolve_named_output(outputs, output_names, fallback_index)
    if output ~= nil then
        return output, resolved_spec
    end
    return outputs[fallback_index], fallback_index
end

function M.select_feature_columns(matrix, start_zero_based, end_exclusive)
    if start_zero_based == nil or end_exclusive == nil or end_exclusive <= start_zero_based then
        return nil
    end
    return assert(matrix:slice(2, start_zero_based + 1, end_exclusive))
end

function M.build_transform_options(meta)
    return {
        offset_x = meta.offset_x,
        offset_y = meta.offset_y,
        scale_x = meta.scale_x,
        scale_y = meta.scale_y,
        clip_width = meta.src_width,
        clip_height = meta.src_height,
    }
end

function M.enrich_detections(detections, meta, class_names, enrich_fn)
    for i = 1, #detections do
        enrich_fn(detections[i], meta, class_names)
    end
    return detections
end

local function class_id_allowed(class_id, allowed)
    if type(allowed) ~= "table" or #allowed == 0 then
        return true
    end
    for i = 1, #allowed do
        if tonumber(allowed[i]) == class_id then
            return true
        end
    end
    return false
end

function M.filter_detections(detections, allowed_class_ids, max_det)
    local filtered = {}
    for i = 1, #detections do
        local det = detections[i]
        if class_id_allowed(det.class_id, allowed_class_ids) then
            filtered[#filtered + 1] = det
            if max_det and max_det > 0 and #filtered >= max_det then
                break
            end
        end
    end
    return filtered
end

function M.materialize_detect_detections(ops, class_names, bundle, meta, build_transform_options)
    local scaled_boxes = assert(ops.scale_boxes(bundle.boxes, build_transform_options(meta)))
    local detections = assert(ops.records_from_boxes(
        scaled_boxes,
        bundle.scores,
        bundle.class_ids,
        bundle.keep_indices
    ))
    M.enrich_detections(detections, meta, class_names, function(det, _, names)
        local class_id = tonumber(det.class_id) or 0
        det.class_id = class_id
        det.x1 = det.box[1]
        det.y1 = det.box[2]
        det.x2 = det.box[3]
        det.y2 = det.box[4]
        if names and names[class_id + 1] then
            det.label = names[class_id + 1]
        end
    end)
    return detections, scaled_boxes
end

function M.materialize_obb_detections(ops, class_names, bundle, meta, profile, enrich_obb_detection)
    local decode = profile.decode or {}
    local detections = assert(ops.obb_records_from_rows(
        bundle.selected_rows,
        bundle.scores,
        bundle.class_ids,
        bundle.angles,
        bundle.keep_indices,
        {
            x_index = tonumber(decode.x_index) or 0,
            y_index = tonumber(decode.y_index) or 1,
            width_index = tonumber(decode.width_index) or 2,
            height_index = tonumber(decode.height_index) or 3,
        }
    ))
    return M.enrich_detections(detections, meta, class_names, function(det, det_meta, names)
        det.class_id = tonumber(det.class_id) or 0
        enrich_obb_detection(det, det_meta, names)
    end)
end

function M.attach_segmentation_masks(ops, resolve_output_spec, output_names, state, outputs, profile, meta, build_transform_options, select_feature_columns)
    if #state.detections == 0 then
        return state.detections
    end
    local seg = profile.seg or {}
    local proto_output = assert(resolve_output_spec(outputs, output_names, (profile.outputs or {}).proto, 2))
    local coeff_start = tonumber(seg.coeff_start)
    local coeff_dim = tonumber(seg.coeff_dim)
    if coeff_start == nil or coeff_dim == nil or coeff_dim <= 0 then
        error("seg profile requires seg.coeff_start and seg.coeff_dim")
    end
    local coeffs = assert(select_feature_columns(state.bundle.selected_rows, coeff_start, coeff_start + coeff_dim))
    local boxes = state.bundle.boxes
    local projection_width = tonumber(meta.dst_width)
    local projection_height = tonumber(meta.dst_height)
    if not boxes or not projection_width or projection_width <= 0 or
        not projection_height or projection_height <= 0 then
        boxes = state.scaled_boxes
        if not boxes then
            boxes = assert(ops.scale_boxes(state.bundle.boxes, build_transform_options(meta)))
            state.scaled_boxes = boxes
        end
        projection_width = meta.src_width
        projection_height = meta.src_height
    end
    local masks = assert(ops.project_masks(
        proto_output,
        coeffs,
        boxes,
        projection_width,
        projection_height,
        {threshold = tonumber(seg.threshold) or 0.0}
    ))
    for i = 1, #state.detections do
        state.detections[i].mask = masks[i]
    end
    return state.detections
end

function M.attach_pose_keypoints(ops, state, profile, meta, build_transform_options, select_feature_columns)
    if #state.detections == 0 then
        return state.detections
    end
    local pose = profile.pose or {}
    local keypoint_start = tonumber(pose.keypoint_start)
    local keypoint_count = tonumber(pose.keypoint_count)
    local keypoint_dim = tonumber(pose.keypoint_dim) or 3
    if keypoint_start == nil or keypoint_count == nil or keypoint_count <= 0 then
        error("pose profile requires pose.keypoint_start and pose.keypoint_count")
    end
    local total_dim = keypoint_count * keypoint_dim
    local keypoint_matrix = assert(select_feature_columns(state.bundle.selected_rows, keypoint_start, keypoint_start + total_dim))
    local scaled = assert(ops.scale_keypoints(keypoint_matrix, build_transform_options(meta), {
        keypoint_count = keypoint_count,
        keypoint_dim = keypoint_dim,
    }))
    local keypoint_sets = assert(ops.points_to_records(scaled))
    for det_index = 1, #state.detections do
        state.detections[det_index].keypoints = keypoint_sets[det_index] or {}
    end
    return state.detections
end

function M.decode_anchor_grid_profile(ops, class_names, output, meta, profile, input_width, input_height, _enrich_detection)
    local decode = profile.decode or {}
    if profile.task ~= "detect" and profile.task ~= "track" then
        error("anchor_grid profile currently only supports detect task")
    end
    if decode.anchors ~= nil then
        error("anchor_grid currently supports only anchor-free dense heads with box_encoding='grid_center_log_wh'; yolov5-style anchor-based raw heads are not supported")
    end
    local box_encoding = decode.box_encoding or "grid_center_log_wh"
    if box_encoding ~= "grid_center_log_wh" then
        error("anchor_grid currently supports only box_encoding='grid_center_log_wh'; yolov5-style anchor-based raw heads are not supported")
    end

    local postprocess = profile.postprocess or {}
    local decoded = assert(ops.decode_dense_detection(output, {
        strides = decode.strides,
        decode_width = tonumber((profile.input or {}).width) or input_width,
        decode_height = tonumber((profile.input or {}).height) or input_height,
        score_threshold = tonumber(postprocess.confidence) or 0.25,
        has_objectness = decode.has_objectness ~= false,
        box_encoding = box_encoding,
        meta = {
            scale_x = meta.scale_x,
            scale_y = meta.scale_y,
            pad_left = meta.offset_x,
            pad_top = meta.offset_y,
            src_width = meta.src_width,
            src_height = meta.src_height,
            dst_width = meta.dst_width,
            dst_height = meta.dst_height,
        },
    }))
    local keep = assert(ops.nms(decoded.boxes, decoded.scores, {
        iou_threshold = tonumber(postprocess.iou) or 0.45,
        class_aware = postprocess.class_aware ~= false,
        class_ids = decoded.labels,
    }))
    local selected_boxes = assert(decoded.boxes:gather(1, keep))
    local selected_scores = assert(decoded.scores:gather(1, keep))
    local selected_labels = assert(decoded.labels:gather(1, keep))
    -- decode_dense_detection 已经按 meta 还原到源图坐标，不能再走会 scale 的通用 enrich_detection。
    local detections = assert(ops.records_from_boxes(
        selected_boxes,
        selected_scores,
        selected_labels,
        keep
    ))
    M.enrich_detections(detections, meta, class_names, function(det, _, names)
        det.class_id = (tonumber(det.class_id) or 1) - 1
        det.x1 = det.box[1]
        det.y1 = det.box[2]
        det.x2 = det.box[3]
        det.y2 = det.box[4]
        det.width = math.max(0, det.x2 - det.x1)
        det.height = math.max(0, det.y2 - det.y1)
        det.cx = det.x1 + det.width / 2
        det.cy = det.y1 + det.height / 2
        if names and names[det.class_id + 1] then
            det.label = names[det.class_id + 1]
        end
    end)
    return {
        detections = M.filter_detections(
            detections,
            postprocess.class_ids,
            tonumber(postprocess.max_det) or 0
        ),
        bundle = {
            selected_rows = output,
            boxes = selected_boxes,
            scaled_boxes = selected_boxes,
            scores = selected_scores,
            class_ids = selected_labels,
            keep_indices = keep,
        },
        scaled_boxes = selected_boxes,
    }
end

function M.decode_classify_tensor(decoder, output, topk, apply_softmax, class_names, flatten_tensor_to_vector, return_logits)
    local classes = assert(decoder:decode(output, {
        top_k = topk,
        apply_softmax = apply_softmax,
    }))
    local logits = return_logits and flatten_tensor_to_vector(output) or nil
    for i = 1, #classes do
        local item = classes[i]
        if class_names and class_names[item.class_id + 1] then
            item.label = class_names[item.class_id + 1]
        end
    end
    local best = classes[1] or nil
    return {
        class_id = best and best.class_id or nil,
        score = best and best.score or nil,
        label = best and best.label or nil,
        classes = classes,
        logits = logits,
    }
end

function M.decode_with_decoder(decoder, output, parsed, meta, class_names, enrich_fn)
    local detections = assert(decoder:decode(output, {
        confidence = parsed.confidence,
        iou = parsed.iou,
        max_det = parsed.max_det,
        class_ids = parsed.class_ids,
        class_aware = parsed.class_aware,
    }))
    return M.enrich_detections(detections, meta, class_names, enrich_fn)
end

local function resolve_profile_value(resolver, self, profile)
    if type(resolver) == "function" then
        return resolver(self, profile)
    end
    return resolver
end

local function call_opts_has_profile(call_opts)
    return type(call_opts) == "table" and call_opts.profile ~= nil
end

local function infer_matrix_rows_and_columns(first_dim, second_dim)
    local dim1 = tonumber(first_dim)
    local dim2 = tonumber(second_dim)
    if not dim1 or not dim2 or dim1 < 5 or dim2 < 5 then
        return nil, nil
    end
    if dim2 >= dim1 then
        return dim2, dim1
    end
    return dim1, dim2
end

local function infer_matrix_shape(shape)
    if type(shape) ~= "table" then
        return nil, nil
    end
    if #shape == 3 then
        return infer_matrix_rows_and_columns(shape[2], shape[3])
    elseif #shape == 2 then
        return infer_matrix_rows_and_columns(shape[1], shape[2])
    end
    return nil, nil
end

local function resolve_inherited_track_base_task(self, fallback_task)
    local base_task = nil
    if self.profile and self.profile.task ~= nil then
        local inherited = M.normalize_profile_task(self.profile.task)
        if inherited ~= "track" then
            base_task = inherited
        end
    end
    if base_task == nil then
        base_task = self.task or fallback_task
    end
    return M.normalize_profile_task(base_task)
end

local function infer_detection_output_index(outputs)
    for i = 1, #(outputs or {}) do
        local rows, cols = infer_matrix_shape(outputs[i] and outputs[i].shape)
        if rows and cols then
            return i, rows, cols
        end
    end
    return nil, nil, nil
end

local function infer_proto_output_index(outputs)
    for i = 1, #(outputs or {}) do
        local shape = outputs[i] and outputs[i].shape
        if type(shape) == "table" and
            (#shape == 4 or (#shape == 3 and not infer_matrix_shape(shape))) then
            return i, shape
        end
    end
    return nil, nil
end

local function infer_proto_channel_count(shape)
    if type(shape) ~= "table" then
        return nil
    end
    if #shape == 4 then
        return tonumber(shape[2]) or nil
    end
    if #shape == 3 then
        local a = tonumber(shape[1])
        local b = tonumber(shape[2])
        local c = tonumber(shape[3])
        if a and b and c then
            return math.min(a, b, c)
        end
    end
    return nil
end

local function infer_pose_layout(column_count, class_start, keypoint_dim)
    if type(column_count) ~= "number" or column_count <= class_start then
        return nil
    end
    keypoint_dim = tonumber(keypoint_dim) or 3
    if keypoint_dim < 2 then
        return nil
    end
    local tail = column_count - class_start
    for class_count = 1, math.min(32, tail - keypoint_dim) do
        local keypoint_values = tail - class_count
        if keypoint_values > 0 and keypoint_values % keypoint_dim == 0 then
            local keypoint_count = keypoint_values / keypoint_dim
            if keypoint_count > 0 then
                return class_start + class_count, keypoint_count
            end
        end
    end
    return nil
end

function M.resolve_runtime_task(self, profile)
    local requested_task = M.normalize_profile_task(profile.task or self.task)
    if requested_task == "track" then
        local track_profile = profile.track or {}
        local base_task = track_profile.task or track_profile.base_task
        if base_task == nil then
            base_task = resolve_inherited_track_base_task(self, "detect")
        else
            base_task = M.normalize_profile_task(base_task)
        end
        if base_task == "track" then
            base_task = "detect"
        end
        if base_task == "classify" then
            error("track requires detect, seg, pose or obb task")
        end
        return base_task, true
    end
    return requested_task, false
end

local function apply_inferred_profile_defaults(self, profile)
    local task = profile.task == "track" and select(1, M.resolve_runtime_task(self, profile)) or profile.task
    local outputs = (self.model_info and self.model_info.outputs) or {}
    local decode = profile.decode or {}
    local output_profile = profile.outputs or {}
    local det_index, _, det_cols = infer_detection_output_index(outputs)

    if (task == "seg" or task == "pose") and output_profile.det == nil and det_index ~= nil then
        output_profile.det = det_index
    end

    if task == "seg" then
        local proto_index, proto_shape = infer_proto_output_index(outputs)
        if output_profile.proto == nil and proto_index ~= nil then
            output_profile.proto = proto_index
        end
        local coeff_dim = tonumber(profile.seg and profile.seg.coeff_dim) or
            infer_proto_channel_count(proto_shape)
        if profile.seg.coeff_dim == nil and coeff_dim ~= nil then
            profile.seg.coeff_dim = coeff_dim
        end
        if decode.class_end == nil and det_cols ~= nil and coeff_dim ~= nil then
            local inferred_end = det_cols - coeff_dim
            if inferred_end > (tonumber(decode.class_start) or 4) then
                decode.class_end = inferred_end
            end
        end
        if profile.seg.coeff_start == nil and decode.class_end ~= nil then
            profile.seg.coeff_start = tonumber(decode.class_end)
        end
    elseif task == "pose" then
        local class_start = tonumber(decode.class_start) or 4
        local keypoint_dim = tonumber(profile.pose and profile.pose.keypoint_dim) or 3
        local inferred_class_end, inferred_keypoint_count =
            infer_pose_layout(det_cols, class_start, keypoint_dim)
        if decode.class_end == nil and inferred_class_end ~= nil then
            decode.class_end = inferred_class_end
        end
        if profile.pose.keypoint_start == nil and decode.class_end ~= nil then
            profile.pose.keypoint_start = tonumber(decode.class_end)
        end
        if profile.pose.keypoint_count == nil and inferred_keypoint_count ~= nil then
            profile.pose.keypoint_count = inferred_keypoint_count
        end
        if profile.pose.keypoint_dim == nil then
            profile.pose.keypoint_dim = keypoint_dim
        end
    end
end

function M.resolve_profile(self, call_opts, forced_task, opts)
    opts = opts or {}
    local profile = nil
    if self.profile then
        profile = M.deep_copy(self.profile)
    end
    if call_opts and call_opts.profile then
        profile = M.deep_merge(profile or {}, call_opts.profile)
    end
    if not profile and not forced_task then
        return nil
    end

    local default_task = opts.default_task or "detect"
    local default_confidence = opts.default_confidence or 0.25
    local default_iou = opts.default_iou or 0.45

    profile = profile or {}
    profile.input = profile.input or {}
    profile.outputs = profile.outputs or {}
    profile.decode = profile.decode or {}
    profile.seg = profile.seg or {}
    profile.pose = profile.pose or {}
    profile.track = profile.track or {}
    profile.postprocess = profile.postprocess or {}
    profile.task = M.normalize_profile_task(forced_task or profile.task or self.task or default_task)
    if profile.task == "track" and profile.track.base_task == nil and profile.track.task == nil then
        profile.track.base_task = resolve_inherited_track_base_task(self, default_task)
    end

    profile.input.width = tonumber(profile.input.width) or self.input_width
    profile.input.height = tonumber(profile.input.height) or self.input_height
    profile.input.layout = profile.input.layout or "nchw"
    profile.input.channel_order = profile.input.channel_order or "rgb"
    profile.input.data_type = profile.input.data_type or "float32"
    profile.input.scale = profile.input.scale or (1.0 / 255.0)
    if profile.input.resize_mode == nil then
        profile.input.resize_mode = resolve_profile_value(opts.default_resize_mode, self, profile)
    end
    if profile.input.letterbox_mode == nil then
        profile.input.letterbox_mode = resolve_profile_value(opts.default_letterbox_mode, self, profile)
    end
    if profile.input.pad_color == nil then
        profile.input.pad_color = resolve_profile_value(opts.default_pad_color, self, profile)
    end
    profile.decode.kind = profile.decode.kind or "decoded_matrix"
    profile.decode.prediction_layout = profile.decode.prediction_layout or "auto"
    profile.decode.box_format = profile.decode.box_format or "cxcywh"
    profile.decode.has_objectness = profile.decode.has_objectness == true
    if profile.decode.objectness_index == nil then
        profile.decode.objectness_index = profile.decode.has_objectness and 4 or nil
    end
    if profile.decode.class_start == nil then
        profile.decode.class_start = profile.decode.has_objectness and 5 or 4
    end
    profile.postprocess.confidence =
        tonumber(call_opts and (call_opts.confidence or call_opts.conf) or
            profile.postprocess.confidence) or self.confidence or default_confidence
    profile.postprocess.iou =
        tonumber(call_opts and call_opts.iou or profile.postprocess.iou) or
        self.iou or default_iou
    profile.postprocess.max_det =
        tonumber(call_opts and call_opts.max_det or profile.postprocess.max_det) or
        self.max_det or nil
    if call_opts and call_opts.class_ids ~= nil then
        profile.postprocess.class_ids = M.deep_copy(call_opts.class_ids)
    end
    if call_opts and type(call_opts.class_agnostic) == "boolean" then
        profile.postprocess.class_aware = not call_opts.class_agnostic
    elseif call_opts and type(call_opts.class_aware) == "boolean" then
        profile.postprocess.class_aware = call_opts.class_aware
    elseif profile.postprocess.class_aware == nil then
        profile.postprocess.class_aware = true
    end
    apply_inferred_profile_defaults(self, profile)
    return profile
end

function M.build_runtime_decoder_schema(task, profile)
    local decode = profile.decode or {}
    local requested_task = M.normalize_profile_task(task)
    local schema_task = requested_task
    if requested_task == "track" then
        local track_profile = profile.track or {}
        schema_task = M.normalize_profile_task(
            track_profile.task or track_profile.base_task or "detect")
    end
    if schema_task == "seg" or schema_task == "pose" or schema_task == "track" then
        schema_task = "detect"
    end
    local schema = {
        task = schema_task,
        prediction_layout = decode.prediction_layout or "auto",
        box_format = decode.box_format or "cxcywh",
        score_mode = decode.score_mode,
        objectness_index = decode.objectness_index,
        angle_index = decode.angle_index,
        class_start = decode.class_start,
        class_end = decode.class_end,
        classification_mode = decode.classification_mode,
    }
    if decode.box_indices then
        schema.box_indices = clone_array(decode.box_indices)
    end
    if schema.score_mode == nil then
        if schema_task == "obb" then
            schema.score_mode = "class_only"
        else
            schema.score_mode = decode.has_objectness and
                "objectness_times_class" or "class_only"
        end
    end
    return schema
end

function M.run_backend_profile_task(self, input, call_opts, forced_task, hooks)
    local profile = hooks.resolve_profile(self, call_opts, forced_task)
    if not profile then
        return nil
    end
    local task, apply_tracking = hooks.resolve_runtime_task(self, profile)
    local img = hooks.resolve_image_object(input)
    local input_value, meta = hooks.prepare_profile_input(self, img, profile, call_opts)
    local outputs = hooks.run_outputs(self, input_value)
    if task == "classify" then
        return hooks.classify_from_outputs(self, outputs, call_opts, profile)
    end

    local det_output = assert(M.resolve_output_spec(
        outputs,
        self.output_names,
        (profile.outputs or {}).det,
        1
    ))
    local decode_kind = (profile.decode or {}).kind
    local state
    if decode_kind == "anchor_grid" then
        state = hooks.decode_anchor_grid_profile(self, det_output, meta, profile)
    elseif decode_kind == "decoded_matrix" then
        state = hooks.decode_dense_matrix_profile(self, det_output, meta, profile, task)
    else
        error("unsupported decode.kind for " .. tostring(hooks.backend_name) ..
            " profile: " .. tostring(decode_kind))
    end

    if task == "seg" then
        state.detections = hooks.attach_segmentation_masks(
            self, state, outputs, profile, meta)
    elseif task == "pose" then
        state.detections = hooks.attach_pose_keypoints(state, profile, meta)
    end

    if apply_tracking then
        local tracker = self.tracker or hooks.tracker_factory(
            call_opts and call_opts.tracker)
        self.tracker = tracker
        return tracker:update(
            state.detections,
            call_opts and call_opts.timestamp or os.time())
    end
    return state.detections
end

function M.pick_first_output(outputs, output_names, missing_message)
    local output = outputs[(output_names and output_names[1]) or 1] or outputs[1]
    if output == nil then
        error(missing_message)
    end
    return output
end

function M.build_public_model_info(self, output_mapper, deep_copy)
    local info = shallow_copy_table(self.model_info)
    info.input_shape = clone_array(self.model_info and self.model_info.input_shape or {})
    info.outputs = {}
    for i = 1, #((self.model_info and self.model_info.outputs) or {}) do
        info.outputs[i] = output_mapper(self.model_info.outputs[i])
    end
    info.input_width = self.input_width
    info.input_height = self.input_height
    info.class_count = self.class_names and #self.class_names or nil
    info.task = self.task
    info.decoder_schema = shallow_copy_table(self.decoder_schema or {})
    info.profile = self.profile and deep_copy(self.profile) or nil
    return info
end

function M.close_instance(self, opts)
    opts = opts or {}
    if opts.before_close then
        opts.before_close(self)
    end
    self.closed = true
    if self.tracker and self.tracker.close then
        self.tracker:close()
    end
    for i = 1, #(opts.fields or {}) do
        local field_name = opts.fields[i]
        local value = self[field_name]
        if value and value.close then
            pcall(value.close, value)
        end
        self[field_name] = nil
    end
    self.tracker = nil
    self.profile = nil
    return nil
end

function M.run_unprofiled_entry(self, input, arg1, arg2, arg3, hooks)
    local call_opts = hooks.parse_task_call_options(arg1, arg2, arg3)
    if self.profile or call_opts_has_profile(call_opts) then
        return assert(hooks.run_profile_task(self, input, call_opts))
    end
    if self.task == "detect" then
        return hooks.detect_impl(self, input, arg1, arg2, arg3)
    end
    if self.task == "classify" then
        return hooks.classify_impl(self, input, type(arg1) == "table" and arg1 or arg3)
    end
    if self.task == "obb" then
        return hooks.obb_impl(self, input, arg1, arg2, arg3)
    end
    error("unsupported task handler: " .. tostring(self.task))
end

function M.run_profiled_entry(self, input, conf, iou, opts, forced_task, hooks)
    return assert(hooks.run_profile_task(self, input, hooks.parse_task_call_options(conf, iou, opts), forced_task))
end

function M.run_detect_entry(self, input, conf, iou, opts, hooks)
    local call_opts = hooks.parse_task_call_options(conf, iou, opts)
    if self.profile or call_opts_has_profile(call_opts) then
        return assert(hooks.run_profile_task(self, input, call_opts, "detect"))
    end
    return hooks.detect_impl(self, input, conf, iou, opts)
end

function M.run_classify_entry(self, input, opts, hooks)
    if self.profile or call_opts_has_profile(opts) then
        return assert(hooks.run_profile_task(self, input, opts or {}, "classify"))
    end
    return hooks.classify_impl(self, input, opts)
end

function M.run_obb_entry(self, input, conf, iou, opts, hooks)
    local call_opts = hooks.parse_task_call_options(conf, iou, opts)
    if self.profile or call_opts_has_profile(call_opts) or type(conf) == "table" then
        return assert(hooks.run_profile_task(self, input, call_opts, "obb"))
    end
    return hooks.obb_impl(self, input, conf, iou, opts)
end

return M
