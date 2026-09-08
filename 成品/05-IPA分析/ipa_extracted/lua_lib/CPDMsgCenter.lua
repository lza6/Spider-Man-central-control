local ffi = require("ffi")
local objc = require("objc")

local CFRunLoopRunWithAutoreleasePool = CFRunLoopRunWithAutoreleasePool

local _CenterMap = {}

return function (centerName)
	if _CenterMap[centerName] then
		return _CenterMap[centerName]
	end
	local center_tab = {}
	local center = objc.CPDistributedMessagingCenter.centerNamed(centerName)()
	local centerClass = nil
	center_tab.registerMessage = function(name, callback)
		if centerClass == nil then
			local className = "_XXTNotificationCenter_"..centerName:sha1()
			centerClass = objc.newclass(className, objc.NSObject)
		end
		local sel = objc.SEL("_notifyMessage_"..name:sha1()..":userInfo:")
		center.registerForMessageName(name).target(centerClass).selector(sel)()
		objc.addmethodimp(objc.metaclass(centerClass), sel, function(self, cmd, name, args)
			local ok, err = objc.try(callback, name, args)
			if ok then
				return objc.toobj(err or ffi.nullptr)
			else
				return objc.toobj({ok = false, error = err})
			end
		end, "@@:@@")
	end
	center_tab.sendMessage = function(name, args)
		center.sendMessageName(name).userInfo(args)()
	end
	center_tab.sendMessageAndReceiveReply = function(name, args)
		local reply = center.sendMessageAndReceiveReplyName(name).userInfo(args)()
		return reply
	end
	center_tab.start = function()
		center_tab.start = function() error("Cannot start listening repeatedly.", 2) end
		dispatch_async('main', function()
			UIApp = UIApp or objc.UIApplication.sharedApplication()
			if not CGRectMake then
				function CGRectMake(x, y, width, height)
					frame = ffi.new("CGRect")
					frame.origin.x = x
					frame.origin.y = y
					frame.size.width = width
					frame.size.height = height
					return frame
				end
			end
			if not rootVC then
				rootVC = UIApp.delegate().window().rootViewController()
			end
			center.runServerOnCurrentThread()
			-- CFRunLoopRunWithAutoreleasePool()
		end)
	end
	center_tab.center = center
	_CenterMap[centerName] = center_tab
	return center_tab
end