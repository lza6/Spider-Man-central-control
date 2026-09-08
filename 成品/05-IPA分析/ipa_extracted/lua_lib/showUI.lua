local lfs = require('lfs')
return function(uitable)
	local selectstyle = {}
	sys.mkdir_p(XXT_HOME_PATH..'/uicfg')
	local tscolor = function(str)
		local r,g,b = str:match('(%d+),(%d+),(%d+)')
		return (r * 65536) + (g * 256) + b
	end
	local file = {
		exist = (function(file) local sFlie,Err = io.open(file,"r+");if Err~=nil then return false end sFlie:close();return true end),
		read = (function(file) local sFlie,Err = io.open(file,"r");if Err~=nil then return nil end local _tmp = sFlie:read("*all");sFlie:close();return _tmp end),
		totable = (function(file) local _tmp = {};local sFlie,Err = io.open(file,"r");if Err~=nil then return {} end;for _line in sFlie:lines() do table.insert(_tmp, string.match(_line,"%C+")) end;sFlie:close();return _tmp; end),
		save = (function(file,data,append) local sFlie,Err = io.open(file,(append and "a") or "w");sFlie:write(data..((append and "\r\n") or ""));sFlie:close() end),
		delete = (function(file) os.remove(file) end)
	}
	style = {
		['default'] = {	--默认样式与处理方式
			Load = function(ut)				--加载方式
				local UIHtml = ''
				local cfglist = {}
				if ut.config then
					local cfg = file.read(string.format(XXT_HOME_PATH..'/uicfg/%s.xcfg',ut.config))
					if cfg then cfglist = cfg:split(',') end
				end
				local _cfgindex = 1			--用于配置文件排序
				for _index = 1, #(ut.views) do
					if (ut.views[_index].type ~= 'Label') and (ut.views[_index].type ~= 'Image') then
						UIHtml=UIHtml..selectstyle.element[ut.views[_index].type](ut.views[_index],cfglist[_cfgindex])
						_cfgindex = _cfgindex + 1
					else
						UIHtml=UIHtml..selectstyle.element[ut.views[_index].type](ut.views[_index])
					end
				end
				return selectstyle.HtmlContent(UIHtml)
			end,
			element = {						--元素处理方式
				Label = (function(val)				--文本(展示内容)
					while string.match(val.text,'\n') do
						local _val = {string.match(val.text,'(.+)\n(.+)')}
						val.text = _val[1]..'<br>'.._val[2]
					end
					
					return string.format('<div class="mui-card" style="%s%s"><h4 align="%s">%s</h4></div>',
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
						(val.align or 'center'),
						val.text or '')
				end),
				Edit = (function(val,cfgv)			--输入框(标题内容,默认内容,灰色内容)
					return string.format('<form class="mui-card" name="input" onsubmit="return false;"><div class="mui-input-row" style="%s%s"><label>%s</label><input type="text" class="mui-input-clear" value="%s" placeholder="%s"></div></form>',
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
						val.caption or '',
						cfgv or val.text or '',
						val.prompt or '')
				end),
				EditMulti = (function(val,cfgv)		--多行文本框(行数,灰色内容,默认内容)
					return string.format('<form class="mui-card" name="input" onsubmit="return false;" style="%s"><div class="mui-input-row" style="%smargin: 5px 2px -15px;"><textarea id="textarea" style="%s" rows="%s" placeholder="%s">%s</textarea></div></form>',
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						val.rows or '1',
						val.prompt or '',
						cfgv or val.text or '')
				end),
				RadioGroup = (function(val,cfgv)	--单选(内容项,默认勾选)
						local _tmp = ''
						local _index = 1
						for _key,_value in ipairs(val.item) do
							if cfgv then
								_tmp = _tmp .. string.format('<div class="mui-input-row mui-radio mui-left"><label>%s</label><input name="vradio" type="radio" %s></div>',
									_value,
									((cfgv == tostring(_index) and ' checked') or ''))
							else
								_tmp = _tmp .. string.format('<div class="mui-input-row mui-radio mui-left"><label>%s</label><input name="vradio" type="radio" %s></div>',
									_value,
									((val.select==_value and ' checked') or ''))
							end
							_index = _index + 1
						end
						return string.format('<form class="mui-card" name="radio" style="%s%s">%s</form>',
							((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
							((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
							_tmp)
					end),
				ComboBox = (function(val,cfgv)		--表框单选(内容项,默认选择)
						local _tmp = ''
						local _index = 1
						for _key,_value in ipairs(val.item) do
							if cfgv then
								_tmp = _tmp .. string.format('<option value="%s" %s>%s</option>',
									_index,
									((cfgv == tostring(_index) and 'selected="selected"') or ''),
									_value)
							else
								_tmp = _tmp .. string.format('<option value="%s" %s>%s</option>',
									_index,
									((val.select==_value and 'selected="selected"') or ''),
									_value)
							end
							_index = _index + 1
						end
						return string.format('<form class="mui-card" name="select" style="%s"><select class="mui-btn mui-btn-block" style="%s%smargin: 0px 20px 0px !important;">%s</select></form>',
							((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
							((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
							((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
							_tmp
							)
					end),
				CheckBoxGroup = (function(val,cfgv)	--多选
					local _tmp = ''
					local _index = 1
					for _key,_value in ipairs(val.item) do
						if cfgv then
							_tmp = _tmp .. string.format('<div class="mui-input-row mui-checkbox mui-left"><label>%s</label><input name="vcheckbox" type="checkbox" %s></div>',
								_value,
								((string.sub(cfgv,_index,_index) == "1" and ' checked') or ''))
						else
							_tmp = _tmp .. string.format('<div class="mui-input-row mui-checkbox mui-left"><label>%s</label><input name="vcheckbox" type="checkbox" %s></div>',
								_value,
								(function() 
									for _k,_v in ipairs(val.select or {}) do
										if _value == _v then
											return ' checked'
										end
									end
									return ''
								end)())
						end
						_index = _index + 1
					end
					return  string.format('<form class="mui-card" name="checkbox" style="%s%s">%s</form>',
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						((val.color and 'color:#' .. string.format("%06X",val.color) .. ';') or ''),
						_tmp
						)
				end),
				Image = (function(val)				--图片
					local ImgStr = val.src or ''
					if val.src:match('(/)') then
						ImgStr = val.src or ''
					else
						if file.exist(XXT_HOME_PATH..'/img/' .. val.src) then
							lfs.link(XXT_HOME_PATH..'/img/' .. val.src, XXT_HOME_PATH..'/web/showUI_Image/' .. val.src, true)
							ImgStr = '/showUI_Image/' .. val.src
						elseif file.exist(XXT_HOME_PATH..'/res/' .. val.src) then
							lfs.link(XXT_HOME_PATH..'/res/' .. val.src, XXT_HOME_PATH..'/web/showUI_Image/' .. val.src, true)
							ImgStr = '/showUI_Image/' .. val.src
						else
							ImgStr = ''
						end
					end
					return string.format('<div class="mui-card" style="%s"><img class="mui-media-icon" src="%s"></div>',
						((val.background and 'background-color: #' .. string.format("%06X",val.background) ..';') or ''),
						ImgStr)
				end),
				Iframe = (function(val)				--Iframe网页内文档
					return string.format('<div class="mui-card"><iframe height=100%% width=100%% src="%s" frameborder=0 allowfullscreen></iframe></div>',
						val.src or '')
				end),
			},
			HtmlContent = function(UIHtml)	--Html拼合
				return [[
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
    <script src="/mui/js/mui.min.js"></script>
	<style>
    	img {
			width: 100%;
			height: 100%;
			max-width: 100%;
			max-height: 100%;
		}
	</style>
	<link rel="stylesheet" href="/mui/css/mui.min.css">
    <title>TestUI</title>
    <script>
		function GetConfig() {
	    	var RetUIArr = new Array;
		    mui(".mui-content-padded form").each(function() {
		        console.log(this.name);
		        switch (this.name) {
		        case 'input':
		        	var ret = '';
		        	var v = this;
		        	for(var i=0; i<v.length;i++){
		            	ret = v[i].value
		        	}
	            	RetUIArr.push(ret);
		            break;
		        case 'select':
		        	var ret = '';
		        	var v = this;
		        	for(var i=0; i<v.length;i++){
		        		ret = v[i].value
		        	}
		            RetUIArr.push(ret);
		            break;
		        case 'checkbox':
		        	var ret = '';
					var v = this;
					for(var i=0; i<v.length;i++){
						if(v[i]['checked']){
							ret += '1';
						}else{
							ret += '0';
						}
					}
		            RetUIArr.push(ret);
		            break;
		        case 'radio':
		        	var ret = '';
					var v = this;
					for(var i=0; i<v.length;i++){
						if(v[i]['checked']){
							ret = i+1;
						}
					}
		            RetUIArr.push(ret.toString());
		            break;
		        default:
					
		        }
		    });
			return RetUIArr;
		}
		
    	function Cancel() {
		    var RetMessage = JSON.stringify(
		    	{
		    		key:"UIWebView",
		    		value:JSON.stringify(
		    			{
		    				Submit:false,
		    				Data:GetConfig()
		    			}
		    		)
		    	}
		    );
		    console.log(RetMessage);
			mui.ajax('/proc_put',{
				data:RetMessage,
				dataType:'json',
				type:'post',
				timeout:10000,
				success:function(request){
					console.log(request.code);
				},
				error:function(xhr,type,errorThrown){
					console.log(type);
				}
			});
    	}
		
	    function Submit() {
		    var RetMessage = JSON.stringify(
		    	{
		    		key:"UIWebView",
		    		value:JSON.stringify(
		    			{
		    				Submit:0,
		    				Data:GetConfig()
		    			}
		    		)
		    	}
		    );
		    console.log(RetMessage);
			mui.ajax('/proc_put',{
				data:RetMessage,
				dataType:'json',
				type:'post',
				timeout:10000,
				success:function(request){
					console.log(request.code);
				},
				error:function(xhr,type,errorThrown){
					console.log(type);
				}
			});
	    }
		function TimeOut(){
			var timex = document.getElementById('timex');
			timex.innerText = timex.innerText - 1;
			if(timex.innerText=='0'){
				var RetMessage = JSON.stringify(
					{
						key:"UIWebView",
						value:JSON.stringify(
							{
								Submit:1,
								Data:GetConfig()
							}
						)
					}
				);
				console.log(RetMessage);
				mui.ajax('/proc_put',{
					data:RetMessage,
					dataType:'json',
					type:'post',
					timeout:10000,
					success:function(request){
						console.log(request.code);
					},
					error:function(xhr,type,errorThrown){
						console.log(type);
					}
				});
			}
		}
		]]..((uitable.timeout and "setInterval(TimeOut,1000);") or '')..[[
    </script>
</head>
<body>
	<header class="mui-bar mui-bar-nav">
		<h1 class="mui-title">]]..(uitable.title or '')..[[</h1>
		<a></a>
		<a id='timex'>]]..(uitable.timeout or '')..[[</a>
	</header>
	<nav class="mui-bar mui-bar-tab">
		<center>
			<button type="button" class="mui-btn mui-btn-danger" style="width: 40%;" onclick="Cancel()"><span class="mui-icon mui-icon-closeempty"></span>]]..uitable.button[1]..[[</button>
			<button type="button" class="mui-btn mui-btn-primary" style="width: 40%;" onclick="Submit()"><span class="mui-icon mui-icon-checkmarkempty"></span>]]..uitable.button[2]..[[</button>
		</center>
	</nav>
	<div class="mui-content">
		<div id="UIlist_b" class="mui-control-content mui-active">
			<div id="UIlist" class="mui-content-padded">
				]]..UIHtml..[[
			</div>
		</div>
	</div>

</body>
</html>
	]]
			end,
			filter = function(ret)			--结果处理
				local RetJson = json.decode(ret)
				if RetJson.Submit then
					if uitable.config then
						file.save(string.format(XXT_HOME_PATH..'/uicfg/%s.xcfg',uitable.config),table.concat(RetJson.Data,","))
					end
					return RetJson.Submit,RetJson.Data
				else
					return RetJson.Submit,RetJson.Data
				end
			end
		},
		['ts'] = {		--兼容狗动
			Load = function(ut)				--加载方式
				local UIHtml = ''
				local cfglist = {}
				if ut.config then
					local cfg = file.read(string.format(XXT_HOME_PATH..'/uicfg/%s.xcfg',ut.config))
					local f = io.open(string.format(XXT_HOME_PATH..'/uicfg/%s.xcfg',ut.config),'r')
					if f then
						local cfg = f:read('*a')
						cfg = cfg:sub(13,-1)
						if cfg then
							cfglist = cfg:split('###')
						end
					end
				end
				local _cfgindex = 1			--用于配置文件排序
				for _index = 1, #(ut.views) do
					if (ut.views[_index].type ~= 'Label') and (ut.views[_index].type ~= 'Image') then
						UIHtml=UIHtml..selectstyle.element[ut.views[_index].type](ut.views[_index],cfglist[_cfgindex])
						_cfgindex = _cfgindex + 1
					else
						UIHtml=UIHtml..selectstyle.element[ut.views[_index].type](ut.views[_index])
					end
				end
				return selectstyle.HtmlContent(UIHtml)
			end,
			element = {
				Label = (function(val)				--文本(展示内容)
					while string.match(val.text,'\n') do
						local _val = {string.match(val.text,'(.+)\n(.+)')}
						val.text = _val[1]..'<br>'.._val[2]
					end
					
					return string.format('<div class="mui-card" style="%s"><h4 align="%s">%s</h4></div>',
						((val.color and 'color:#' .. string.format("%06X",tscolor(val.color)) .. ';') or ''),
						(val.align or 'center'),
						val.text or '')
				end),
				Edit = (function(val,cfgv)		--多行文本框(行数,灰色内容,默认内容)
					return string.format('<form class="mui-card" name="input" onsubmit="return false;"><div class="mui-input-row" style="%smargin: 5px 2px -15px;"><textarea id="textarea" rows="2" placeholder="%s">%s</textarea></div></form>',
						((val.color and 'color:#' .. string.format("%06X",tscolor(val.color)) .. ';') or ''),
						val.prompt or '',
						cfgv or val.text or '')
				end),
				RadioGroup = (function(val,cfgv)	--单选(内容项,默认勾选)
						local _tmp = ''
						local _index = 0
						for _key,_value in ipairs(val.list:split(',')) do
							if cfgv and cfgv ~= '' then
								_tmp = _tmp .. string.format('<div class="mui-input-row mui-radio mui-left"><label>%s</label><input name="vradio" type="radio" %s></div>',
									_value,
									((cfgv == tostring(_index) and ' checked') or ''))
							else
								_tmp = _tmp .. string.format('<div class="mui-input-row mui-radio mui-left"><label>%s</label><input name="vradio" type="radio" %s></div>',
									_value,
									((val.select==tostring(_index) and ' checked') or ''))
							end
							_index = _index + 1
						end
						return string.format('<form class="mui-card" name="radio">%s</form>',_tmp)
					end),
				ComboBox = (function(val,cfgv)		--表框单选(内容项,默认选择)
						local _tmp = ''
						local _index = 0
						for _key,_value in ipairs(val.list:split(',')) do
							if cfgv and cfgv ~= '' then
								_tmp = _tmp .. string.format('<option value="%s" %s>%s</option>',
									_index,
									((cfgv == tostring(_index) and 'selected="selected"') or ''),
									_value)
							else
								_tmp = _tmp .. string.format('<option value="%s" %s>%s</option>',
									_index,
									((val.select==tostring(_index) and 'selected="selected"') or ''),
									_value)
							end
							_index = _index + 1
						end
						return string.format('<form class="mui-card" name="select"><select class="mui-btn mui-btn-block" style="margin: 0px 20px 0px !important;">%s</select></form>',_tmp)
					end),
				CheckBoxGroup = (function(val,cfgv)	--多选
					local _tmp = ''
					local _index = 0
					local check = {}
					if cfgv then
						for k,v in ipairs(cfgv:split('@')) do
							if v:match('%d+') then
								check[tonumber(v)] = true
							end
						end
					else
						for k,v in ipairs(val.select:split('@')) do
							if v:match('%d+') then
								check[tonumber(v)] = true
							end
						end
					end
					for _key,_value in ipairs(val.list:split(',')) do
						_tmp = _tmp .. string.format('<div class="mui-input-row mui-checkbox mui-left"><label>%s</label><input name="vcheckbox" type="checkbox" %s></div>',
							_value,
							(check[_index] and ' checked') or '')
						_index = _index + 1
					end
					return  string.format('<form class="mui-card" name="checkbox">%s</form>',_tmp)
				end),
				Image = (function(val)				--图片
					local ImgStr = val.src or ''
					if val.src:match('(/)') then
						ImgStr = val.src or ''
					else
						if file.exist(XXT_HOME_PATH..'/img/' .. val.src) then
							lfs.link(XXT_HOME_PATH..'/img/' .. val.src, XXT_HOME_PATH..'/web/showUI_Image/' .. val.src, true)
							ImgStr = '/showUI_Image/' .. val.src
						elseif file.exist(XXT_HOME_PATH..'/res/' .. val.src) then
							lfs.link(XXT_HOME_PATH..'/res/' .. val.src, XXT_HOME_PATH..'/web/showUI_Image/' .. val.src, true)
							ImgStr = '/showUI_Image/' .. val.src
						else
							ImgStr = ''
						end
					end
					return string.format('<div class="mui-card"><img class="mui-media-icon" src="%s"></div>',ImgStr)
				end),
			},
			HtmlContent = function(UIHtml)
				return [[
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
    <script src="/mui/js/mui.min.js"></script>
	<style>
    	img {
			width: 100%;
			height: 100%;
			max-width: 100%;
			max-height: 100%;
		}
	</style>
	<link rel="stylesheet" href="/mui/css/mui.min.css">
    <title>TestUI</title>
    <script>
		function GetConfig() {
	    	var RetUIArr = new Array;
		    mui(".mui-content-padded form").each(function() {
		        console.log(this.name);
		        switch (this.name) {
		        case 'input':
		        	var ret = '';
		        	var v = this;
		        	for(var i=0; i<v.length;i++){
		            	ret = v[i].value
		        	}
	            	RetUIArr.push(ret);
		            break;
		        case 'select':
		        	var ret = '';
		        	var v = this;
		        	for(var i=0; i<v.length;i++){
		        		ret = v[i].value
		        	}
		            RetUIArr.push(ret);
		            break;
		        case 'checkbox':
		        	var ret = new Array();
					var v = this;
					var a = 0;
					for(var i=0; i<v.length;i++){
						if(v[i]['checked']){
							ret.push(a);
						};
						a = a + 1;
					}
		            RetUIArr.push(ret.join('@'));
		            break;
		        case 'radio':
		        	var ret = '';
					var v = this;
					for(var i=0; i<v.length;i++){
						if(v[i]['checked']){
							ret = i;
						}
					}
		            RetUIArr.push(ret.toString());
		            break;
		        default:
					
		        }
		    });
			return RetUIArr;
		}
		
    	function Cancel() {
		    var RetMessage = JSON.stringify(
		    	{
		    		key:"UIWebView",
		    		value:JSON.stringify(
		    			{
		    				Submit:0,
		    				Data:GetConfig()
		    			}
		    		)
		    	}
		    );
		    console.log(RetMessage);
			mui.ajax('/proc_put',{
				data:RetMessage,
				dataType:'json',
				type:'post',
				timeout:10000,
				success:function(request){
					console.log(request.code);
				},
				error:function(xhr,type,errorThrown){
					console.log(type);
				}
			});
    	}
		
	    function Submit() {
		    var RetMessage = JSON.stringify(
		    	{
		    		key:"UIWebView",
		    		value:JSON.stringify(
		    			{
		    				Submit:1,
		    				Data:GetConfig()
		    			}
		    		)
		    	}
		    );
		    console.log(RetMessage);
			mui.ajax('/proc_put',{
				data:RetMessage,
				dataType:'json',
				type:'post',
				timeout:10000,
				success:function(request){
					console.log(request.code);
				},
				error:function(xhr,type,errorThrown){
					console.log(type);
				}
			});
	    }
		function TimeOut(){
			var timex = document.getElementById('timex');
			timex.innerText = timex.innerText - 1;
			if(timex.innerText=='0'){
				var RetMessage = JSON.stringify(
					{
						key:"UIWebView",
						value:JSON.stringify(
							{
								Submit:1,
								Data:GetConfig()
							}
						)
					}
				);
				console.log(RetMessage);
				mui.ajax('/proc_put',{
					data:RetMessage,
					dataType:'json',
					type:'post',
					timeout:10000,
					success:function(request){
						console.log(request.code);
					},
					error:function(xhr,type,errorThrown){
						console.log(type);
					}
				});
			}
		}
		]]..((uitable.timer and "setInterval(TimeOut,1000);") or '')..[[
    </script>
</head>
<body>
	<header class="mui-bar mui-bar-nav">
		<h1 class="mui-title">]]..(uitable.title or '')..[[</h1>
		<a></a>
		<a id='timex'>]]..(uitable.timer or '')..[[</a>
	</header>
	<nav class="mui-bar mui-bar-tab">
		<center>
			<button type="button" class="mui-btn mui-btn-danger" style="width: 40%;" onclick="Cancel()"><span class="mui-icon mui-icon-closeempty"></span>]]..(uitable.cancelname or '取消')..[[</button>
			<button type="button" class="mui-btn mui-btn-primary" style="width: 40%;" onclick="Submit()"><span class="mui-icon mui-icon-checkmarkempty"></span>]]..(uitable.okname or '确认')..[[</button>
		</center>
	</nav>
	<div class="mui-content">
		<div id="UIlist_b" class="mui-control-content mui-active">
			<div id="UIlist" class="mui-content-padded">
				]]..UIHtml..[[
			</div>
		</div>
	</div>

</body>
</html>
	]]
			end,
			filter = function(ret)
				local RetJson = json.decode(ret)
				local _R = {}
				if RetJson.Submit == 1 then
					if uitable.config then
						local f,err = io.open(string.format(XXT_HOME_PATH..'/uicfg/%s.xcfg',uitable.config),'w')
						if not f then error('配置无法写入:'..err,2) end
						f:write('ui_input::::' .. table.concat(RetJson.Data,"###"))
						f:close()
					end
					return RetJson.Submit,table.unpack(RetJson.Data)
				else
					return RetJson.Submit
				end
			end
		}
	}
	if type(uitable) == 'string' then
		uitable = json.decode(uitable);
		if type(uitable) ~= 'table' then
			error('传入数据非json',2)
		end
		uitable.style='ts'
	end
	selectstyle = style[uitable.style]
	if not selectstyle then error('样式选择为空',2) end
	sys.mkdir_p(XXT_HOME_PATH..'/web/showUI_Image')
	sys.clear_dir(XXT_HOME_PATH..'/web/showUI_Image')
	webview.show{
		x = ({screen.size()})[1]/2,
		y = ({screen.size()})[2]/2,
		width = 0,
		height = 0,
		alpha = 0,
		animation_duration = 0,
	}
	webview.show{
		html = selectstyle.Load(uitable),
		x = (({screen.size()})[1] - uitable.width) / 2,
		y = (({screen.size()})[2] - uitable.height) / 2,
		width = uitable.width,
		height = uitable.height,
		corner_radius = 10,
		alpha = 1,
		animation_duration = 0.2,
		rotate = rotate_ang,
	}
	local ret = ''
	proc_put('UIWebView','')
	while(true)do
		ret = proc_put("UIWebView","")
		if ret ~= '' then break end
		sys.msleep(10)
	end
	webview.show{
		x = ({screen.size()})[1]/2,
		y = ({screen.size()})[2]/2,
		width = 0,
		height = 0,
		alpha = 0,
		animation_duration = 0.2,
	}
	sys.clear_dir(XXT_HOME_PATH..'/web/showUI_Image')
	sys.msleep(200)
	webview.destroy()
	return selectstyle.filter(ret)
end