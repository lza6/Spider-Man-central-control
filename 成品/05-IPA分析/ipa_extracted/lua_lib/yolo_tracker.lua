local M = {}
local common = require("yolo_backend_common")

local DEFAULTS = {
    iou_threshold = 0.3,
    max_age = 30,
    min_hits = 1,
}

local tracker_mt = {}
tracker_mt.__index = tracker_mt

local function resolve_native_tracker_factory()
    local ok_ort, ort = pcall(require, "onnxruntime")
    if ok_ort and type(ort) == "table" and type(ort.tracker) == "function" then
        return ort.tracker
    end
    local ok_coreml, coreml = pcall(require, "coreml")
    if ok_coreml and type(coreml) == "table" and type(coreml.tracker) == "function" then
        return coreml.tracker
    end
    return nil
end

local shallow_copy = common.shallow_copy_table

local function clamp_min(value, min_value)
    if value < min_value then
        return min_value
    end
    return value
end

local function box_iou(lhs, rhs)
    local x1 = math.max(lhs[1] or 0, rhs[1] or 0)
    local y1 = math.max(lhs[2] or 0, rhs[2] or 0)
    local x2 = math.min(lhs[3] or 0, rhs[3] or 0)
    local y2 = math.min(lhs[4] or 0, rhs[4] or 0)
    local w = math.max(0, x2 - x1)
    local h = math.max(0, y2 - y1)
    local inter = w * h
    local lhs_area = math.max(0, (lhs[3] or 0) - (lhs[1] or 0)) * math.max(0, (lhs[4] or 0) - (lhs[2] or 0))
    local rhs_area = math.max(0, (rhs[3] or 0) - (rhs[1] or 0)) * math.max(0, (rhs[4] or 0) - (rhs[2] or 0))
    local denom = lhs_area + rhs_area - inter
    if denom <= 0 then
        return 0
    end
    return inter / denom
end

local function detection_box(det)
    return det and det.box
end

local function should_match(track, det, threshold)
    if track.class_id ~= nil and det.class_id ~= nil and track.class_id ~= det.class_id then
        return false, 0
    end
    local iou = box_iou(track.box, detection_box(det))
    return iou >= threshold, iou
end

local function clone_detection(det)
    local out = shallow_copy(det)
    if type(det.box) == "table" then
        out.box = {det.box[1], det.box[2], det.box[3], det.box[4]}
    end
    if type(det.points) == "table" then
        local pts = {}
        for i = 1, #det.points do
            local pt = det.points[i]
            pts[i] = {x = pt.x, y = pt.y}
        end
        out.points = pts
    end
    if type(det.keypoints) == "table" then
        local kpts = {}
        for i = 1, #det.keypoints do
            local pt = det.keypoints[i]
            local copied = {}
            for key, value in pairs(pt) do
                copied[key] = value
            end
            kpts[i] = copied
        end
        out.keypoints = kpts
    end
    return out
end

local function clone_track(track)
    local out = shallow_copy(track)
    if type(track.box) == "table" then
        out.box = {track.box[1], track.box[2], track.box[3], track.box[4]}
    end
    return out
end

function tracker_mt:update(detections, timestamp)
    if self.closed then
        error("tracker is closed")
    end

    detections = detections or {}
    local matches = {}
    local used_tracks = {}
    local used_dets = {}

    for det_index = 1, #detections do
        local det = detections[det_index]
        local best_track_index = nil
        local best_iou = -1
        for track_index = 1, #self.tracks do
            if not used_tracks[track_index] then
                local track = self.tracks[track_index]
                local ok, iou = should_match(track, det, self.config.iou_threshold)
                if ok and iou > best_iou then
                    best_iou = iou
                    best_track_index = track_index
                end
            end
        end
        if best_track_index then
            used_tracks[best_track_index] = true
            used_dets[det_index] = true
            matches[#matches + 1] = {track_index = best_track_index, det_index = det_index}
        end
    end

    for i = 1, #matches do
        local match = matches[i]
        local track = self.tracks[match.track_index]
        local det = detections[match.det_index]
        track.box = {det.box[1], det.box[2], det.box[3], det.box[4]}
        track.score = det.score
        track.class_id = det.class_id
        track.age = 0
        track.hits = (track.hits or 0) + 1
        track.last_seen = timestamp
    end

    for track_index = #self.tracks, 1, -1 do
        if not used_tracks[track_index] then
            local track = self.tracks[track_index]
            track.age = (track.age or 0) + 1
            if track.age > self.config.max_age then
                table.remove(self.tracks, track_index)
            end
        end
    end

    for det_index = 1, #detections do
        if not used_dets[det_index] then
            local det = detections[det_index]
            self.next_id = self.next_id + 1
            self.tracks[#self.tracks + 1] = {
                id = self.next_id,
                box = {det.box[1], det.box[2], det.box[3], det.box[4]},
                score = det.score,
                class_id = det.class_id,
                age = 0,
                hits = 1,
                first_seen = timestamp,
                last_seen = timestamp,
            }
        end
    end

    local annotated = {}
    for det_index = 1, #detections do
        local det = clone_detection(detections[det_index])
        local best_track = nil
        local best_iou = -1
        for track_index = 1, #self.tracks do
            local track = self.tracks[track_index]
            if track.class_id == nil or det.class_id == nil or track.class_id == det.class_id then
                local iou = box_iou(track.box, det.box)
                if iou > best_iou then
                    best_iou = iou
                    best_track = track
                end
            end
        end
        if best_track and best_iou >= self.config.iou_threshold then
            det.track_hits = best_track.hits
            det.track_age = best_track.age
            if (best_track.hits or 0) >= self.config.min_hits then
                det.track_id = best_track.id
            end
        end
        annotated[#annotated + 1] = det
    end

    return annotated
end

function tracker_mt:reset()
    self.tracks = {}
    self.next_id = 0
    return true
end

function tracker_mt:state()
    local out = {}
    for i = 1, #self.tracks do
        out[i] = clone_track(self.tracks[i])
    end
    return out
end

function tracker_mt:close()
    self.closed = true
    self.tracks = {}
    return true
end

local function new_lua_tracker(config)
    local merged = shallow_copy(DEFAULTS)
    for key, value in pairs(config or {}) do
        merged[key] = value
    end
    merged.iou_threshold = tonumber(merged.iou_threshold) or DEFAULTS.iou_threshold
    merged.max_age = clamp_min(tonumber(merged.max_age) or DEFAULTS.max_age, 0)
    merged.min_hits = clamp_min(tonumber(merged.min_hits) or DEFAULTS.min_hits, 1)
    return setmetatable({
        config = merged,
        tracks = {},
        next_id = 0,
        closed = false,
    }, tracker_mt)
end

function M.tracker(config)
    local native_factory = resolve_native_tracker_factory()
    if native_factory then
        return native_factory(config)
    end
    return new_lua_tracker(config)
end

return M
