using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Nancy;
using Nancy.Hosting.Self;
using Newtonsoft.Json.Linq;
using XXTCC;

[StandardModule]
internal sealed class Class9
{
	private delegate void Delegate6(string IP, string Message);

	public static Form_Main_t form_Main_t_0;

	public static OleDbConnection oleDbConnection_0;

	public static DataTable dataTable_0;

	public static Class_UDP class_UDP_0;

	public static NancyHost nancyHost_0;

	public static bool bool_0;

	public static JObject jobject_0;

	public static int int_0;

	public static int int_1;

	public static int int_2;

	public static JObject jobject_1;

	public static JObject jobject_2;

	public static JObject jobject_3;

	public static string string_0;

	public static Queue queue_0;

	private static object object_0;

	static Class9()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		Class14.QwnfEIbzxvDCI();
		oleDbConnection_0 = new OleDbConnection();
		dataTable_0 = new DataTable();
		class_UDP_0 = new Class_UDP();
		bool_0 = true;
		jobject_0 = new JObject();
		int_0 = 2;
		int_1 = 27010;
		int_2 = 27000;
		string_0 = "local CC = {}\r\ndo\r\n\tlocal _err_msg = {\r\n\t\ttimeout = [[与服务端访问超时\r\n1.请确认中控端正常运行\r\n2.中控端防火墙请确保关闭\r\n3.请确保设备与中控端始终处于同一个局域网]],\r\n\t\tserver_bug = [[服务端出现错误，请尝试检查 VPN 或 HTTP 代理设置：]],\r\n\t\tsubmit_ip = [[提交的服务器IP不正确]],\r\n\t\tnot_find = [[未找到中控设备\r\n1.中控端防火墙请确保关闭\r\n2.请由中控端或XXTStudio启动\r\n3.请确保设备与中控端始终处于同一个局域网]],\r\n\t\tnot_init = [[未初始化中控模块\r\n请使用 'CC.connect()' 进行初始化操作]]\r\n\t}\r\n\tlocal _server = {ip = '', port = '', field = {}}\r\n\tlocal post = function(_mode, mode, data)\r\n\t\tif _server.ip == '' then error(_err_msg.not_init, 3) end\r\n\t\twhile true do\r\n\t\t\tlocal code, header, body = http.post(\r\n\t\t\t\t\tstring.format(\r\n\t\t\t\t\t\t'http://%s:%s/%s/%s',\r\n\t\t\t\t\t\t_server.ip, _server.port, _mode, mode\r\n\t\t\t\t\t), 30, {}, ((type(data) == 'table' and json.encode(data)) or data)\r\n\t\t\t\t)\r\n\t\t\tif code == 200 then\r\n\t\t\t\treturn json.decode(body) or body\r\n\t\t\telseif code ~= -1 then\r\n\t\t\t\tsys.toast(_err_msg.server_bug .. body)\r\n\t\t\telse\r\n\t\t\t\tsys.toast(_err_msg.timeout)\r\n\t\t\tend\r\n\t\tend\r\n\tend\r\n\tlocal encodeURI = function(s)\r\n\t\treturn string.gsub(string.gsub(s, '([^%w%.%- ])', function(c) return string.format('%%%02X', string.byte(c)) end), ' ', '+')\r\n\tend\r\n\tlocal send_cc = function(db,m,t)\r\n\t\tlocal r = post('db', m, json.encode({db=db, data=t}))\r\n\t\tif r.state == 0 then return r.data;else sys.alert(r.message,5);return r.data;end\r\n\tend\r\n\tCC.connect = function(ip, port)\r\n\t\tif ip and port then\r\n\t\t\treturn CC.set_server_ip(ip, port)\r\n\t\telse\r\n\t\t\tlocal args = proc_take('spawn_args')\r\n\t\t\tif args == '' then\r\n\t\t\t\targs = proc_take('CC_args')\r\n\t\t\tend\r\n\t\t\tproc_put('spawn_args', args)\r\n\t\t\tproc_put('CC_args', args)\r\n\t\t\tlocal _, args_json = pcall(json.decode, args)\r\n\t\t\tif _ and type(args_json) == 'table' then\r\n\t\t\t\tif type(args_json['server_ip']) == 'table' then\r\n\t\t\t\t\treturn CC.set_server_ip(\r\n\t\t\t\t\t\targs_json['server_ip'],\r\n\t\t\t\t\t\targs_json['server_port']\r\n\t\t\t\t\t)\r\n\t\t\t\telse\r\n\t\t\t\t\treturn CC.set_server_ip(\r\n\t\t\t\t\t\tjson.decode(args_json['server_ip']),\r\n\t\t\t\t\t\targs_json['server_port']\r\n\t\t\t\t\t)\r\n\t\t\t\tend\r\n\t\t\telse\r\n\t\t\t\treturn false\r\n\t\t\tend\r\n\t\tend\r\n\tend\r\n\tCC.set_server_ip = function(...)\r\n\t\tlocal ip_list = {}\r\n\t\tif type(select(1,...)) == 'table' then\r\n\t\t\tip_list = select(1, ...)\r\n\t\telseif type(select(1,...)) == 'string' then\r\n\t\t\tip_list = {select(1, ...)}\r\n\t\telse\r\n\t\t\terror(_err_msg.submit_ip, 2)\r\n\t\tend\r\n\t\t_server.port = select(2, ...) or 27010\r\n\t\tlocal socket = require('socket')\r\n\t\tlocal s = socket.tcp()\r\n\t\ts:settimeout(1)\r\n\t\tfor k,v in ipairs(ip_list) do\r\n\t\t\tlocal s = socket.tcp()\r\n\t\t\ts:settimeout(1)\r\n\t\t\tif s:connect(string.format('%s',v), _server.port) == 1 then\r\n\t\t\t\t_server.ip = v\r\n\t\t\t\treturn true\r\n\t\t\tend\r\n\t\tend\r\n\t\tif _server.ip == '' then\r\n\t\t\terror(_err_msg.not_find, 2)\r\n\t\tend\r\n\tend\r\n\tCC.set_sever_ip = CC.set_server_ip\r\n\tCC.log = function(t)\r\n\t\tif _server.ip == '' then error(_err_msg.not_init, 2) end\r\n\t\tif type(t) == 'table' then\r\n\t\t\tfor key, value in pairs(t) do\r\n\t\t\t\t_server.field[key] = value\r\n\t\t\tend\r\n\t\telse\r\n\t\t\t_server.field['日志'] = tostring(t)\r\n\t\tend\r\n\t\thttp.post(('http://%s:%s/log'):format(_server.ip, _server.port), 5, {}, json.encode(_server.field))\r\n\tend\r\n\tCC.getui = function()\r\n\t\tif _server.ip == '' then error(_err_msg.not_init, 2) end\r\n\t\twhile true do\r\n\t\t\tlocal r = {http.get(string.format('http://%s:%s/getui', _server.ip, _server.port))}\r\n\t\t\tif r[1] == 200 then return json.decode(r[3]) end\r\n\t\t\tsys.sleep(2)\r\n\t\t\tsys.toast(_err_msg.timeout)\r\n\t\tend\r\n\tend\r\n\tCC.db = {\r\n\t\tadd = (function(db,t)\r\n\t\t\treturn send_cc(db,'add',t)\r\n\t\tend),\r\n\t\tdel = (function(db,t)\r\n\t\t\treturn send_cc(db,'del',t)\r\n\t\tend),\r\n\t\tedit = (function(db,t)\r\n\t\t\treturn send_cc(db,'edit',t)\r\n\t\tend),\r\n\t\tget = (function(db,t)\r\n\t\t\treturn send_cc(db,'get',t)\r\n\t\tend),\r\n\t\tlist = (function(db,t)\r\n\t\t\treturn send_cc(db,'list',t or {})\r\n\t\tend)\r\n\t}\r\n\tCC.web_file = {\r\n\t\ttake_line = (function(path)\r\n\t\t\treturn post('file','take_line',{path=path}).data\r\n\t\tend),\r\n\t\ttake_file = (function(path)\r\n\t\t\tlocal r = post('file','take_file',{path=path})\r\n\t\t\tif r.success then\r\n\t\t\t\treturn r.data:base64_decode()\r\n\t\t\telse\r\n\t\t\t\treturn nil\r\n\t\t\tend\r\n\t\tend),\r\n\t\texists = function(path)\r\n\t\t\tlocal r = post('file','exists',{path=path})\r\n\t\t\tif r.info == json.null then\r\n\t\t\t\treturn false\r\n\t\t\telse\r\n\t\t\t\treturn r.info\r\n\t\t\tend\r\n\t\tend,\r\n\t\tlist = (function(path)\r\n\t\t\treturn post('file','list',{path=path}).list\r\n\t\tend),\r\n\t\tsize = (function(path)\r\n\t\t\treturn post('file','size',{path=path}).fsize\r\n\t\tend),\r\n\t\tdelete = (function(path)\r\n\t\t\treturn post('file','delete',{path=path}).success\r\n\t\tend),\r\n\t\treads = (function(path)\r\n\t\t\tlocal r = post('file','reads',{path=path})\r\n\t\t\tif r.success then\r\n\t\t\t\treturn r.data:base64_decode()\r\n\t\t\telse\r\n\t\t\t\treturn nil\r\n\t\t\tend\r\n\t\tend),\r\n\t\twrites = (function(path,data)\r\n\t\t\treturn post('file','writes',{path=path,data=data:base64_encode()}).success\r\n\t\tend),\r\n\t\tappends = (function(path,data)\r\n\t\t\treturn post('file','appends',{path=path,data=data:base64_encode()}).success\r\n\t\tend),\r\n\t\tline_count = (function(path)\r\n\t\t\treturn post('file','line_count',{path=path}).linecount\r\n\t\tend),\r\n\t\tget_line = (function(path,line_number)\r\n\t\t\treturn post('file','get_line',{path=path,line_number=line_number}).line\r\n\t\tend),\r\n\t\tset_line = (function(path,line_number,data)\r\n\t\t\treturn post('file','set_line',{path=path,line_number=line_number,data=data}).success\r\n\t\tend),\r\n\t\tinsert_line = (function(path,line_number,data)\r\n\t\t\treturn post('file','insert_line',{path=path,line_number=line_number,data=data}).success\r\n\t\tend),\r\n\t\tremove_line = (function(path,line_number)\r\n\t\t\treturn post('file','remove_line',{path=path,line_number=line_number}).success\r\n\t\tend),\r\n\t\tget_lines = (function(path)\r\n\t\t\treturn post('file','get_lines',{path=path}).lines\r\n\t\tend),\r\n\t\tinsert_lines = (function(path,line_number,lines)\r\n\t\t\treturn post('file','insert_lines',{path=path,line_number=line_number,lines=lines}).success\r\n\t\tend),\r\n\t\tupdate_file = (function(file,path)\r\n\t\t\tlocal f, err = io.open(path,'rb')\r\n\t\t\tif not f then error(err,2) end\r\n\t\t\tlocal s = f:read('*a')\r\n\t\t\tf:close()\r\n\t\t\treturn post('file-byte','update?file=' .. encodeURI(file), s) == 'ok'\r\n\t\tend),\r\n\t\tdown_file = (function(file,path)\r\n\t\t\tlocal code, header, body\r\n\t\t\twhile true do\r\n\t\t\t\tcode, header, body = http.get(('http://%s:%s/file-byte/down?file=%s'):format(_server.ip, _server.port, encodeURI(file)), 30)\r\n\t\t\t\tif code == 200 or code == 404 then break end\r\n\t\t\tend\r\n\t\t\tif code == 404 then\r\n\t\t\t\terror('文件不存在',2)\r\n\t\t\telse\r\n\t\t\t\tlocal f = io.open(path,'wb')\r\n\t\t\t\tf:write(body)\r\n\t\t\t\tf:close()\r\n\t\t\t\treturn true\r\n\t\t\tend\r\n\t\tend),\r\n\t}\r\n\tCC.web_directory = {\r\n\t\texists = function(path)\r\n\t\t\tlocal r = post('directory','exists',{path=path})\r\n\t\t\tif type(r.info) == 'userdata' then\r\n\t\t\t\treturn false\r\n\t\t\telse\r\n\t\t\t\treturn r.info\r\n\t\t\tend\r\n\t\tend,\r\n\t\tcreate = (function(path)\r\n\t\t\treturn post('directory','create',{path=path}).success\r\n\t\tend),\r\n\t\tdelete = (function(path,data)\r\n\t\t\treturn post('directory','delete',{path=path}).success\r\n\t\tend),\r\n\t}\r\n\tCC.web_directory.exicts = CC.web_directory.exists\r\n\tCC.field = CC.log\r\nend\r\n\r\nreturn CC\r\n\r\n--[[\t中控与IDE启动方式\r\nlocal CC = require('CC')\r\nif not CC.connect() then\r\n\terror('连接失败')\r\nend\r\n--]]\r\n\r\n--[[\t固定IP启动方式\r\nlocal CC = require('CC')\r\nif not CC.connect('10.0.0.88', '27010') then\r\n\terror('连接失败')\r\nend\r\n--]]";
		queue_0 = new Queue();
		object_0 = RuntimeHelpers.GetObjectValue(new object());
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static void smethod_0()
	{
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		Application.EnableVisualStyles();
		ServicePointManager.MaxServicePoints = 512;
		ServicePointManager.DefaultConnectionLimit = 512;
		ServicePointManager.Expect100Continue = false;
		bool flag = false;
		int num = 1;
		checked
		{
			do
			{
				if (!Conversions.ToBoolean(class_UDP_0.Start(int_2)))
				{
					int_2++;
					int_1++;
					num++;
					continue;
				}
				flag = true;
				break;
			}
			while (num <= 10);
			if (!flag)
			{
				MessageBox.Show("服务器启动失败，端口被占用。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.EndApp();
			}
			smethod_2($"http://+:{int_1}/", Environment.UserDomainName, Environment.UserName);
			if (!File.Exists(Application.StartupPath + "\\CC.mdb"))
			{
				if (MessageBox.Show("软件需释放数据库文件", "注意以下可能会出现问题的操作", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
				{
					ProjectData.EndApp();
				}
				File.WriteAllBytes(Application.StartupPath + "\\CC.mdb", Class7.smethod_1());
			}
			if (!Directory.Exists(Application.StartupPath + "\\data"))
			{
				Directory.CreateDirectory(Application.StartupPath + "\\data");
			}
			if (!Directory.Exists(Application.StartupPath + "\\1ferver"))
			{
				Directory.CreateDirectory(Application.StartupPath + "\\1ferver");
			}
			if (!Directory.Exists(Application.StartupPath + "\\1ferver\\lua"))
			{
				Directory.CreateDirectory(Application.StartupPath + "\\1ferver\\lua");
			}
			if (!Directory.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts"))
			{
				Directory.CreateDirectory(Application.StartupPath + "\\1ferver\\lua\\scripts");
			}
			DataColumnCollection columns = dataTable_0.Columns;
			columns.Add("check");
			columns.Add("ip");
			columns.Add("_ip", typeof(long));
			columns.Add("port");
			columns.Add("devname");
			columns.Add("deviceid");
			columns.Add("devsn");
			columns.Add("devmac");
			columns.Add("devtype");
			columns.Add("zeversion");
			columns.Add("sysversion");
			columns.Add("buildid");
			columns.Add("boardconfig");
			columns.Add("ecid");
			columns.Add("message");
			DataColumn[] primaryKey = new DataColumn[1] { dataTable_0.Columns["deviceid"] };
			dataTable_0.PrimaryKey = primaryKey;
			StaticConfiguration.DisableErrorTraces = false;
			try
			{
				oleDbConnection_0 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\CC.mdb");
				oleDbConnection_0.Open();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show("数据库连接失败:" + ex2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.EndApp();
				ProjectData.ClearProjectError();
			}
			nancyHost_0 = new NancyHost(new Uri[1]
			{
				new Uri($"http://localhost:{int_1}")
			});
			try
			{
				if (File.Exists(Application.StartupPath + "\\config.json"))
				{
					jobject_3 = JObject.Parse(File.ReadAllText(Application.StartupPath + "\\config.json"));
				}
				else
				{
					jobject_3 = new JObject();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				jobject_3 = new JObject();
				ProjectData.ClearProjectError();
			}
			form_Main_t_0 = new Form_Main_t();
			Application.Run(form_Main_t_0);
		}
	}

	public static object smethod_1()
	{
		return Math.Abs(Conversion.Val(DateAndTime.DateDiff(DateInterval.Second, DateTimeOffset.UtcNow.UtcDateTime, new DateTime(1970, 1, 1, 0, 0, 0))));
	}

	public static void smethod_2(string string_1, string string_2, string string_3)
	{
		string arguments = $"http delete urlacl url={string_1}";
		string arguments2 = $"http add urlacl url={string_1} user={string_2}\\{string_3}";
		Process.Start(new ProcessStartInfo("netsh", arguments)
		{
			Verb = "runas",
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = false
		}).WaitForExit();
		Process.Start(new ProcessStartInfo("netsh", arguments2)
		{
			Verb = "runas",
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = false
		}).WaitForExit();
	}

	public static string smethod_3(byte[] byte_0)
	{
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array = sHA1CryptoServiceProvider.ComputeHash(byte_0);
		sHA1CryptoServiceProvider.Clear();
		return BitConverter.ToString(array).Replace("-", "").ToLower();
	}

	public static string smethod_4(string string_1)
	{
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] bytes = Encoding.UTF8.GetBytes(string_1);
		byte[] array = sHA1CryptoServiceProvider.ComputeHash(bytes);
		sHA1CryptoServiceProvider.Clear();
		return BitConverter.ToString(array).Replace("-", "").ToLower();
	}

	public static string smethod_5(byte[] byte_0)
	{
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(byte_0);
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	public static string smethod_6(string string_1)
	{
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(string_1));
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	public static void smethod_7(string string_1, string string_2)
	{
		queue_0.Enqueue(new string[2] { string_1, string_2 });
	}

	public static void smethod_8(string string_1, string string_2)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		if (form_Main_t_0.DataGridView_DeviceList.InvokeRequired)
		{
			Delegate6 method = smethod_8;
			form_Main_t_0.DataGridView_DeviceList.Invoke(method, string_1, string_2);
			return;
		}
		object obj = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			if (dataTable_0.Select("ip='" + string_1 + "'").Length == 0)
			{
				return;
			}
			if (Operators.CompareString(Strings.Mid(string_2, 1, 1), "{", TextCompare: false) == 0)
			{
				try
				{
					JObject val = JObject.Parse(string_2);
					foreach (JProperty item in ((JContainer)val).Children())
					{
						JProperty val2 = item;
						if (!dataTable_0.Columns.Contains(val2.Name.ToString()))
						{
							dataTable_0.Columns.Add(new DataColumn(val2.Name.ToString()));
						}
						dataTable_0.Select("ip='" + string_1 + "'")[0][val2.Name.ToString()] = val2.Value.ToString();
					}
					return;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(Strings.Mid(string_2, 1, 1), "[", TextCompare: false) != 0)
			{
				return;
			}
			try
			{
				JArray val3 = JArray.Parse(string_2);
				int num = 1;
				foreach (JValue item2 in ((JContainer)val3).Children())
				{
					JValue val4 = item2;
					if (!dataTable_0.Columns.Contains(num.ToString()))
					{
						dataTable_0.Columns.Add(new DataColumn(num.ToString()));
					}
					dataTable_0.Select("ip='" + string_1 + "'")[0][num.ToString()] = val4.Value.ToString();
					num = checked(num + 1);
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public static JObject YurUbgmNio(string string_1, JArray jarray_0)
	{
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			foreach (JObject item in ((JContainer)jarray_0).Children())
			{
				JObject val2 = item;
				string text = "";
				string text2 = "";
				foreach (JProperty item2 in ((JContainer)val2).Children())
				{
					JProperty val3 = item2;
					text = text + "`" + val3.Name.ToString() + "`";
					text2 = text2 + "'" + val3.Value.ToString() + "'";
					if (((JToken)val3).Next != null)
					{
						text += ",";
						text2 += ",";
					}
				}
				string text3 = ikpUfLfjaf($"INSERT INTO {string_1} ({text}) VALUES ({text2})");
				if (text3 == null)
				{
					using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select top 1 * from {string_1} order by [ID] desc", oleDbConnection_0);
					using DataSet dataSet = new DataSet();
					oleDbDataAdapter.Fill(dataSet);
					using DataTable dataTable = dataSet.Tables[0];
					foreach (DataRow row in dataTable.Rows)
					{
						JObject val4 = new JObject();
						foreach (DataColumn column in dataTable.Columns)
						{
							if (Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column])))
							{
								((JContainer)val4).Add((object)new JProperty(column.ToString(), (object)""));
							}
							else
							{
								((JContainer)val4).Add((object)new JProperty(column.ToString(), RuntimeHelpers.GetObjectValue(row[column])));
							}
						}
						val.Add((JToken)new JObject(new object[3]
						{
							(object)new JProperty("message", (object)"成功"),
							(object)new JProperty("state", (object)true),
							(object)new JProperty("data", (object)val4)
						}));
					}
				}
				else
				{
					val.Add((JToken)new JObject(new object[2]
					{
						(object)new JProperty("message", (object)text3),
						(object)new JProperty("state", (object)false)
					}));
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JObject smethod_9(string string_1, JArray jarray_0)
	{
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Invalid comparison between Unknown and I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			foreach (JObject item in ((JContainer)jarray_0).Children())
			{
				JObject val2 = item;
				if (val2["id"] != null)
				{
					string text = "";
					int num = (int)val2["id"];
					((JToken)val2["id"].Parent).Remove();
					foreach (JProperty item2 in ((JContainer)val2).Children())
					{
						JProperty val3 = item2;
						if ((int)val3.Value.Type != 10)
						{
							text += $"`{val3.Name.ToString()}`='{val3.Value.ToString()} '";
						}
						if (((JToken)val3).Next != null && (int)((JProperty)((JToken)val3).Next).Value.Type != 10)
						{
							text += ",";
						}
					}
					string text2 = ikpUfLfjaf($"Update `{string_1}` Set {text} Where id = {num}");
					if (text2 == null)
					{
						val.Add((JToken)new JObject(new object[2]
						{
							(object)new JProperty("message", (object)"成功"),
							(object)new JProperty("state", (object)true)
						}));
					}
					else
					{
						val.Add((JToken)new JObject(new object[2]
						{
							(object)new JProperty("message", (object)text2),
							(object)new JProperty("state", (object)false)
						}));
					}
				}
				else
				{
					val.Add((JToken)new JObject(new object[2]
					{
						(object)new JProperty("message", (object)"缺少id特征字符"),
						(object)new JProperty("state", (object)false)
					}));
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JObject smethod_10(string string_1, JArray jarray_0)
	{
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			string text = "";
			if (jarray_0 != null && ((JContainer)jarray_0).Count > 0)
			{
				foreach (JProperty item in jarray_0[0].Children())
				{
					JProperty val2 = item;
					text = ((Operators.CompareString(val2.Name.ToString(), "id", TextCompare: false) != 0) ? (text + $"`{val2.Name.ToString()}`='{val2.Value.ToString()} '") : (text + $"`id`={val2.Value.ToString()} "));
					if (((JToken)val2).Next != null)
					{
						text += " and ";
					}
				}
			}
			using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string.Format("select * from {0}{1}", string_1, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(text, "", TextCompare: false) != 0, " where " + text, text))), oleDbConnection_0))
			{
				using DataSet dataSet = new DataSet();
				oleDbDataAdapter.Fill(dataSet);
				using DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					JObject val3 = new JObject();
					foreach (DataColumn column in dataTable.Columns)
					{
						if (Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column])))
						{
							((JContainer)val3).Add((object)new JProperty(column.ToString(), (object)""));
						}
						else
						{
							((JContainer)val3).Add((object)new JProperty(column.ToString(), RuntimeHelpers.GetObjectValue(row[column])));
						}
					}
					val.Add((JToken)(object)val3);
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JObject smethod_11(string string_1, JArray jarray_0)
	{
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			foreach (JObject item in ((JContainer)jarray_0).Children())
			{
				JObject val2 = item;
				string arg = "";
				foreach (JProperty item2 in ((JContainer)val2).Children())
				{
					JProperty val3 = item2;
					if (Operators.CompareString(val3.Name.ToString(), "id", TextCompare: false) == 0)
					{
						arg = val3.Value.ToString();
					}
				}
				string text = ikpUfLfjaf($"DELETE FROM {string_1} WHERE id = {arg}");
				if (text == null)
				{
					val.Add((JToken)new JObject(new object[2]
					{
						(object)new JProperty("message", (object)"成功"),
						(object)new JProperty("state", (object)true)
					}));
				}
				else
				{
					val.Add((JToken)new JObject(new object[2]
					{
						(object)new JProperty("message", (object)text),
						(object)new JProperty("state", (object)false)
					}));
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JObject smethod_12(string string_1, JArray jarray_0)
	{
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			string text = "";
			string text2 = "";
			foreach (JProperty item in jarray_0[0].Children())
			{
				JProperty val2 = item;
				text = ((Operators.CompareString(val2.Name.ToString(), "id", TextCompare: false) != 0) ? (text + $"`{val2.Name.ToString()}`='{val2.Value.ToString()}' ") : (text + $"`id`={val2.Value.ToString()} "));
				if (((JToken)val2).Next != null)
				{
					text += " and ";
				}
			}
			if (((JContainer)jarray_0).Count > 1)
			{
				foreach (JProperty item2 in jarray_0[1].Children())
				{
					JProperty val3 = item2;
					text2 = ((Operators.CompareString(val3.Name.ToString(), "id", TextCompare: false) != 0) ? (text2 + $"`{val3.Name.ToString()}`='{val3.Value.ToString()}' ") : (text2 + $"`id`={val3.Value.ToString()} "));
					if (((JToken)val3).Next != null)
					{
						text2 += " and ";
					}
				}
			}
			using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string.Format("select top 1 * from {0}{1}", string_1, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(text, "", TextCompare: false) != 0, " where " + text, text))), oleDbConnection_0))
			{
				using DataSet dataSet = new DataSet();
				oleDbDataAdapter.Fill(dataSet);
				using DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					JObject val4 = new JObject();
					foreach (DataColumn column in dataTable.Columns)
					{
						if (Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column])))
						{
							((JContainer)val4).Add((object)new JProperty(column.ToString(), (object)""));
						}
						else
						{
							((JContainer)val4).Add((object)new JProperty(column.ToString(), RuntimeHelpers.GetObjectValue(row[column])));
						}
					}
					if (Operators.CompareString(text2, "", TextCompare: false) != 0)
					{
						string text3 = ikpUfLfjaf(string.Format("Update `{0}` Set {1} Where id = {2}", string_1, text2, RuntimeHelpers.GetObjectValue(row["id"])));
						if (text3 == null)
						{
							((JContainer)val4).Add((object)new JProperty("message", (object)"成功"));
							((JContainer)val4).Add((object)new JProperty("state", (object)true));
						}
						else
						{
							((JContainer)val4).Add((object)new JProperty("message", (object)text3));
							((JContainer)val4).Add((object)new JProperty("state", (object)false));
						}
					}
					val.Add((JToken)(object)val4);
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JObject smethod_13(string string_1, string string_2)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		JObject result;
		try
		{
			JArray val = new JArray();
			using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(string_2, oleDbConnection_0))
			{
				using DataSet dataSet = new DataSet();
				oleDbDataAdapter.Fill(dataSet);
				using DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					JObject val2 = new JObject();
					foreach (DataColumn column in dataTable.Columns)
					{
						if (Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column])))
						{
							((JContainer)val2).Add((object)new JProperty(column.ToString(), (object)""));
						}
						else
						{
							((JContainer)val2).Add((object)new JProperty(column.ToString(), RuntimeHelpers.GetObjectValue(row[column])));
						}
					}
					val.Add((JToken)(object)val2);
				}
			}
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)0),
				(object)new JProperty("data", (object)val),
				(object)new JProperty("message", (object)"成功")
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = new JObject(new object[3]
			{
				(object)new JProperty("state", (object)500),
				(object)new JProperty("data", (object)new JArray()),
				(object)new JProperty("message", (object)ex2.Message.ToString())
			});
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string ikpUfLfjaf(string string_1)
	{
		string result;
		try
		{
			using (OleDbCommand oleDbCommand = new OleDbCommand())
			{
				oleDbCommand.CommandText = string_1;
				oleDbCommand.Connection = oleDbConnection_0;
				oleDbCommand.ExecuteNonQuery();
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = ex2.Message.ToString();
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
