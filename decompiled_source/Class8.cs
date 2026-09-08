using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XXTCC;
using XXTCC.Utility;
using XXTCC.aliyun_api_gateway_sdk.Util;

[StandardModule]
internal sealed class Class8
{
	private delegate void Delegate3(JObject jobj, string ip);

	private delegate void Delegate4(string IP, string Message);

	private delegate void Delegate5(string IP, string _Name);

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public JObject _0024VB_0024Local__IP;

		public _Closure_0024__6_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local__IP = arg0._0024VB_0024Local__IP;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R1(object a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				SFTPOperation sFTPOperation = new SFTPOperation((string)_0024VB_0024Local__IP["ip"], "22", "root", "alpine");
				smethod_30(_0024VB_0024Local__IP["ip"].ToString(), "传输文件中");
				sFTPOperation.Delete("/tz.ipa");
				string text = sFTPOperation.Put(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_IPA_File, "/private/var/tmp/tz.ipa");
				if (text == null)
				{
					sFTPOperation.Write(Class7.smethod_0(), "/private/var/tmp/1nstaller");
					sFTPOperation.Execute("chmod 777 /private/var/tmp/1nstaller;chown 0:0 /private/var/tmp/1nstaller");
					smethod_30(_0024VB_0024Local__IP["ip"].ToString(), "安装中");
					text = sFTPOperation.Execute("/private/var/tmp/1nstaller -f /private/var/tmp/tz.ipa");
					if (!text.Contains("uccessfully"))
					{
						text = ((!text.Contains("downgrade")) ? ("安装失败," + text) : "安装失败,需卸载原有版本");
					}
					else
					{
						text = "安装成功";
						smethod_30(_0024VB_0024Local__IP["ip"].ToString(), "修改权限中");
						sFTPOperation.EditAuthority("/var/mobile/Applications/");
					}
					sFTPOperation.Execute("killall -9 installd");
					smethod_30(_0024VB_0024Local__IP["ip"].ToString(), text);
				}
				else
				{
					smethod_30(_0024VB_0024Local__IP["ip"].ToString(), text);
				}
				sFTPOperation.Delete("/private/var/tmp/1nstaller");
				sFTPOperation.Delete("/private/var/tmp/tz.ipa");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				smethod_30(_0024VB_0024Local__IP["ip"].ToString(), ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D1
	{
		public string _0024VB_0024Local_IPA_File;

		public _Closure_0024__6_002D1(_Closure_0024__6_002D1 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_IPA_File = arg0._0024VB_0024Local_IPA_File;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D0
	{
		public JObject _0024VB_0024Local__IP;

		public _Closure_0024__7_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local__IP = arg0._0024VB_0024Local__IP;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			string text = "";
			int int_ = Class9.int_0;
			for (int i = 1; i <= int_; i = checked(i + 1))
			{
				text = smethod_35("http://" + _0024VB_0024Local__IP["ip"].ToString() + ":46952/" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Prot, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_SendData, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TimeOut, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_spawn_args);
				if (text.Contains("message"))
				{
					break;
				}
				smethod_30(_0024VB_0024Local__IP["ip"].ToString(), "超时" + Conversions.ToString(i) + "次");
			}
			try
			{
				if (text.Contains("message"))
				{
					JObject val = JObject.Parse(text);
					if ((int)val["code"] == 0)
					{
						smethod_30(_0024VB_0024Local__IP["ip"].ToString(), _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Success);
					}
					else
					{
						smethod_30(_0024VB_0024Local__IP["ip"].ToString(), (string)val["message"]);
					}
				}
				else
				{
					smethod_30(_0024VB_0024Local__IP["ip"].ToString(), "超时");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				smethod_30(_0024VB_0024Local__IP["ip"].ToString(), ex2.Message.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D1
	{
		public string _0024VB_0024Local_Prot;

		public byte[] _0024VB_0024Local_SendData;

		public int _0024VB_0024Local_TimeOut;

		public string _0024VB_0024Local_spawn_args;

		public string _0024VB_0024Local_Success;

		public _Closure_0024__7_002D1(_Closure_0024__7_002D1 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_Prot = arg0._0024VB_0024Local_Prot;
				_0024VB_0024Local_SendData = arg0._0024VB_0024Local_SendData;
				_0024VB_0024Local_TimeOut = arg0._0024VB_0024Local_TimeOut;
				_0024VB_0024Local_spawn_args = arg0._0024VB_0024Local_spawn_args;
				_0024VB_0024Local_Success = arg0._0024VB_0024Local_Success;
			}
		}
	}

	private static object object_0;

	private static object object_1;

	private static object object_2;

	static Class8()
	{
		Class14.QwnfEIbzxvDCI();
		object_0 = RuntimeHelpers.GetObjectValue(new object());
		object_1 = RuntimeHelpers.GetObjectValue(new object());
		object_2 = RuntimeHelpers.GetObjectValue(new object());
	}

	public static object smethod_0(string string_0)
	{
		object result;
		try
		{
			new TcpClientWithTimeout(string_0, 46952, 500).Connect().Close();
			string text = smethod_33("http://" + string_0 + ":46952/deviceinfo", "", 500);
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				JObject val = JObject.Parse(text);
				if ((int)val["code"] == 0)
				{
					smethod_1(val, string_0);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void smethod_1(JObject jobject_0, string string_0)
	{
		if (Class9.form_Main_t_0.DataGridView_DeviceList.InvokeRequired)
		{
			Delegate3 method = smethod_1;
			Class9.form_Main_t_0.DataGridView_DeviceList.Invoke(method, jobject_0, string_0);
			return;
		}
		object obj = object_1;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				if (Class9.dataTable_0.Rows.Find(jobject_0["data"][(object)"deviceid"].ToString()) == null)
				{
					DataRow dataRow = Class9.dataTable_0.NewRow();
					dataRow["check"] = false;
					dataRow["ip"] = string_0;
					string[] array = string_0.Split('.');
					dataRow["_ip"] = Conversions.ToLong(array[0].PadLeft(3, '0') + array[1].PadLeft(3, '0') + array[2].PadLeft(3, '0') + array[3].PadLeft(3, '0'));
					dataRow["port"] = jobject_0["data"][(object)"port"].ToString();
					dataRow["devname"] = jobject_0["data"][(object)"devname"].ToString();
					dataRow["deviceid"] = jobject_0["data"][(object)"deviceid"].ToString();
					dataRow["devsn"] = jobject_0["data"][(object)"devsn"].ToString();
					dataRow["devmac"] = jobject_0["data"][(object)"devmac"].ToString();
					dataRow["devtype"] = jobject_0["data"][(object)"devtype"].ToString();
					dataRow["zeversion"] = jobject_0["data"][(object)"zeversion"].ToString();
					dataRow["sysversion"] = jobject_0["data"][(object)"sysversion"].ToString();
					Class9.dataTable_0.Rows.Add(dataRow);
				}
				else
				{
					DataRow dataRow2 = Class9.dataTable_0.Rows.Find(jobject_0["data"][(object)"deviceid"].ToString());
					dataRow2["ip"] = string_0;
					string[] array2 = string_0.Split('.');
					dataRow2["_ip"] = Conversions.ToLong(array2[0].PadLeft(3, '0') + array2[1].PadLeft(3, '0') + array2[2].PadLeft(3, '0') + array2[3].PadLeft(3, '0'));
					dataRow2["port"] = jobject_0["data"][(object)"port"].ToString();
					dataRow2["devname"] = jobject_0["data"][(object)"devname"].ToString();
					dataRow2["devsn"] = jobject_0["data"][(object)"devsn"].ToString();
					dataRow2["devmac"] = jobject_0["data"][(object)"devmac"].ToString();
					dataRow2["devtype"] = jobject_0["data"][(object)"devtype"].ToString();
					dataRow2["zeversion"] = jobject_0["data"][(object)"zeversion"].ToString();
					dataRow2["sysversion"] = jobject_0["data"][(object)"sysvertion"].ToString();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void smethod_2(JArray jarray_0, string string_0)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		_Closure_0024__6_002D1 obj = new _Closure_0024__6_002D1(obj);
		obj._0024VB_0024Local_IPA_File = string_0;
		File.ReadAllBytes(obj._0024VB_0024Local_IPA_File);
		using IEnumerator<JToken> enumerator = ((JContainer)jarray_0).Children().GetEnumerator();
		_Closure_0024__6_002D0 obj2 = default(_Closure_0024__6_002D0);
		while (enumerator.MoveNext())
		{
			obj2 = new _Closure_0024__6_002D0(obj2);
			obj2._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
			obj2._0024VB_0024Local__IP = (JObject)enumerator.Current;
			ThreadPool.QueueUserWorkItem(obj2._Lambda_0024__R1);
		}
	}

	public static void smethod_3(JArray jarray_0, string string_0, byte[] byte_0, string string_1, int int_0 = 20000, string string_2 = "")
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		_Closure_0024__7_002D1 obj = new _Closure_0024__7_002D1(obj);
		obj._0024VB_0024Local_Prot = string_0;
		obj._0024VB_0024Local_SendData = byte_0;
		obj._0024VB_0024Local_Success = string_1;
		obj._0024VB_0024Local_TimeOut = int_0;
		obj._0024VB_0024Local_spawn_args = string_2;
		using IEnumerator<JToken> enumerator = ((JContainer)jarray_0).Children().GetEnumerator();
		_Closure_0024__7_002D0 obj2 = default(_Closure_0024__7_002D0);
		while (enumerator.MoveNext())
		{
			obj2 = new _Closure_0024__7_002D0(obj2);
			obj2._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
			obj2._0024VB_0024Local__IP = (JObject)enumerator.Current;
			ThreadPool.QueueUserWorkItem(obj2._Lambda_0024__R2);
		}
	}

	public static void smethod_4(JArray jarray_0, string string_0, string string_1, string string_2, int int_0 = 10000, string string_3 = "")
	{
		smethod_3(jarray_0, string_0, Encoding.UTF8.GetBytes(string_1), string_2, int_0, string_3);
	}

	public static void smethod_5(JArray jarray_0, string string_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		JArray val = new JArray();
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				val.Add(JToken.op_Implicit(iPAddress.ToString()));
			}
		}
		JObject val2 = (JObject)((JToken)Class9.jobject_0).DeepClone();
		val2["server_ip"] = (JToken)(object)val;
		val2["server_port"] = JToken.op_Implicit(Class9.int_1);
		smethod_3(jarray_0, "spawn", File.ReadAllBytes(string_0), "启动成功", 30000, JsonConvert.SerializeObject((object)val2));
	}

	public static void smethod_6(JArray jarray_0)
	{
		smethod_4(jarray_0, "pause_script", "", "暂停中", 1000);
	}

	public static void smethod_7(JArray jarray_0)
	{
		smethod_4(jarray_0, "resume_script", "", "运行中", 1000);
	}

	public static void smethod_8(JArray jarray_0)
	{
		smethod_4(jarray_0, "recycle", "", "停止成功", 1000);
	}

	public static void smethod_9(JArray jarray_0, string string_0)
	{
		smethod_3(jarray_0, "install_deb", File.ReadAllBytes(string_0), "安装成功", 60000);
	}

	public static void smethod_10(JArray jarray_0)
	{
		smethod_4(jarray_0, "is_running", "", "未运行脚本", 1000);
	}

	public static void smethod_11(JArray jarray_0)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				int num = (int)Math.Round(Math.Floor((double)((JContainer)jarray_0).Count / 100.0));
				for (int i = 0; i <= num; i++)
				{
					JArray val = new JArray();
					JArray val2 = new JArray();
					string[] array = new string[100];
					string[] array2 = new string[100];
					int num2 = 0;
					do
					{
						if (((JContainer)jarray_0).Count >= i * 100 + num2 + 1 && jarray_0[i * 100 + num2] != null)
						{
							val.Add(jarray_0[i * 100 + num2][(object)"deviceid"]);
							val2.Add(jarray_0[i * 100 + num2][(object)"devsn"]);
							array[num2] = (string)jarray_0[i * 100 + num2][(object)"deviceid"];
							array2[num2] = (string)jarray_0[i * 100 + num2][(object)"devsn"];
						}
						num2++;
					}
					while (num2 <= 99);
					string text = Class9.smethod_1().ToString();
					string value = Class9.smethod_3(smethod_38(smethod_38(smethod_38(smethod_12(Strings.Join(array, "")), Encoding.UTF8.GetBytes(Strings.Join(array2, ""))), smethod_12("8d4d305a0725b8e9bc1faa765a013a7362d03f72")), Encoding.UTF8.GetBytes(text)));
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add("dids", JsonConvert.SerializeObject((object)val));
					dictionary.Add("sns", JsonConvert.SerializeObject((object)val2));
					dictionary.Add("ts", text);
					dictionary.Add("sign", value);
					dictionary.Add("v", "2");
					string text2 = smethod_39("/api/devices_info", dictionary);
					if (text2 == null || Operators.CompareString(text2, "", TextCompare: false) == 0)
					{
						foreach (JObject item in jarray_0)
						{
							smethod_30(item["ip"].ToString(), "超时");
						}
						continue;
					}
					JObject val3 = JObject.Parse(text2);
					if ((int)val3["code"] == 0)
					{
						JArray val4 = (JArray)val3["data"][(object)"expireDates"];
						int num3 = ((JContainer)val4).Count - 1;
						for (int j = 0; j <= num3; j++)
						{
							if ((int)val4[j] - (int)val3["data"][(object)"nowDate"] < 0)
							{
								smethod_30((string)jarray_0[i * 100 + j][(object)"ip"], "未授权");
								continue;
							}
							DateTime dateTime = new DateTime(621356256000000000L).AddSeconds((int)val4[j]);
							if ((int)val4[j] == 2147454847)
							{
								smethod_30(jarray_0[i * 100 + j][(object)"ip"].ToString(), "永久授权");
							}
							else
							{
								smethod_30(jarray_0[i * 100 + j][(object)"ip"].ToString(), "到期时间:" + dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
							}
						}
						continue;
					}
					int num4 = 0;
					do
					{
						if (((JContainer)jarray_0).Count >= i * 100 + num4 + 1 && jarray_0[i * 100 + num4] != null)
						{
							smethod_30(jarray_0[i * 100 + num4][(object)"ip"].ToString(), (string)val3["message"]);
						}
						num4++;
					}
					while (num4 <= 99);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				foreach (JObject item2 in jarray_0)
				{
					smethod_30(item2["ip"].ToString(), ex2.Message);
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private static byte[] smethod_12(string string_0)
	{
		checked
		{
			byte[] array = new byte[(int)Math.Round((double)string_0.Length / 2.0 - 1.0) + 1];
			int num = (int)Math.Round((double)string_0.Length / 2.0 - 1.0);
			for (int i = 0; i <= num; i++)
			{
				array[i] = Convert.ToByte(string_0.Substring(i * 2, 2), 16);
			}
			return array;
		}
	}

	public static void smethod_13(JArray jarray_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		JArray val = new JArray();
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				val.Add(JToken.op_Implicit(iPAddress.ToString()));
			}
		}
		JObject jobject_ = Class9.jobject_0;
		jobject_["server_ip"] = (JToken)(object)val;
		jobject_["server_port"] = JToken.op_Implicit(Class9.int_1);
		foreach (JObject item in ((JContainer)jarray_0).Children())
		{
			JObject val2 = item;
			try
			{
				if ((int)JObject.Parse(smethod_33("http://" + val2["ip"].ToString() + ":46952/proc_put", JsonConvert.SerializeObject((object)new JObject(new object[2]
				{
					(object)new JProperty("key", (object)"CC_args"),
					(object)new JProperty("value", (object)JsonConvert.SerializeObject((object)jobject_))
				}))))["code"] != 0)
				{
					smethod_30((string)val2["ip"], "无法传递参数");
					break;
				}
				JObject val3 = JObject.Parse(smethod_33("http://" + val2["ip"].ToString() + ":46952/launch_script_file", ""));
				smethod_30((string)val2["ip"], (string)val3["message"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				smethod_30((string)val2["ip"], ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void smethod_14(JArray jarray_0, string string_0 = "")
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		JArray val = new JArray();
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				val.Add(JToken.op_Implicit(iPAddress.ToString()));
			}
		}
		JObject jobject_ = Class9.jobject_0;
		jobject_["server_ip"] = (JToken)(object)val;
		jobject_["server_port"] = JToken.op_Implicit(Class9.int_1);
		if (new Form_synchronous
		{
			_IP = jarray_0
		}.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		foreach (JObject item in ((JContainer)jarray_0).Children())
		{
			JObject val2 = item;
			try
			{
				smethod_30(val2["ip"].ToString(), "同步结束");
				if ((int)JObject.Parse(smethod_33("http://" + val2["ip"].ToString() + ":46952/proc_put", JsonConvert.SerializeObject((object)new JObject(new object[2]
				{
					(object)new JProperty("key", (object)"CC_args"),
					(object)new JProperty("value", (object)JsonConvert.SerializeObject((object)jobject_))
				}))))["code"] != 0)
				{
					smethod_30((string)val2["ip"], "无法传递参数");
					break;
				}
				JObject val3 = JObject.Parse(smethod_33("http://" + val2["ip"].ToString() + ":46952/launch_script_file", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("filename", (object)("/var/mobile/Media/1ferver/lua/scripts/" + string_0))))));
				smethod_30((string)val2["ip"], (string)val3["message"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				smethod_30((string)val2["ip"], ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void iDdbiArgcT(JArray jarray_0)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		string s = "os.remove('/var/mobile/Media/1ferver/bin/location.lua')\r\nlocal socket = require('socket')\r\nlocal json = require 'cjson.safe'\r\nfunction sys.msleep(n) socket.select(nil, nil, n / 1000) end\r\nfunction sys.sleep(n) socket.select(nil, nil, n) end\r\nlocal http = {\r\n\tpost = (function(host, port, path, data)\r\n\t\tlocal curl = require('curl.safe')\r\n\r\n\t\tlocal buffer = {}\r\n\t\tlocal function writef(s)\r\n\t\t\tbuffer[#buffer + 1] = s\r\n\t\tend\r\n\t\tlocal code = 0\r\n\t\tpcall(function()\r\n\t\t\tlocal c = curl.easy()\r\n\t\t\t\t:setopt(curl.OPT_URL, string.format('http://%s:%s/%s',host, port, path))\r\n\t\t\t\t:setopt(curl.OPT_CONNECTTIMEOUT, 2)\r\n\t\t\t\t:setopt(curl.OPT_TIMEOUT, 2)\r\n\t\t\t\r\n\t\t\tc:setopt_postfields(data)\r\n\t\t\t\t:setopt_writefunction(writef)\r\n\t\t\t\t:perform()\r\n\r\n\t\t\tcode = c:getinfo(curl.INFO_RESPONSE_CODE)\r\n\t\t\tc:close()\r\n\t\tend)\r\n\t\t\r\n\t\tlocal body\r\n\t\t\r\n\t\tif (code == 0) then\r\n\t\t\tcode = -1\r\n\t\telse\r\n\t\t\tbody = table.concat(buffer)\r\n\t\tend\r\n\t\treturn math.floor(code), body\r\n\tend)\r\n}\r\nhttp.post('127.0.0.1', 46952, 'unlock_screen', '')\r\nfor i1 = 1, 5 do\r\n\tfor i2 = 0, 10, 1 do\r\n\t\thttp.post('127.0.0.1', 46952, 'set_brightness', json.encode({level = i2 / 10}))\r\n\t\tsys.msleep(0.2)\r\n\tend\r\n\tfor i2 = 10, 0, -1 do\r\n\t\thttp.post('127.0.0.1', 46952, 'set_brightness', json.encode({level = i2 / 10}))\r\n\t\tsys.msleep(0.2)\r\n\tend\r\nend\r\nhttp.post('127.0.0.1', 46952, 'set_brightness', json.encode({level = 1}))\r\n";
		smethod_4(jarray_0, "write_file", JsonConvert.SerializeObject((object)new JObject(new object[2]
		{
			(object)new JProperty("filename", (object)"/bin/location.lua"),
			(object)new JProperty("data", (object)Convert.ToBase64String(Encoding.UTF8.GetBytes(s)))
		})), "定位设备中");
		smethod_4(jarray_0, "command_spawn", "/usr/bin/1ferver/ReportCrash dofile /var/mobile/Media/1ferver/bin/location.lua &", "定位设备中");
	}

	public static string smethod_15(string string_0, string string_1)
	{
		string[] obj = new string[5] { "http://xxtouch.566.sh:42356/", "http://139.129.39.141:42356/", "http://xxtauth.ttaozi.com:80/", "http://xxtauth.sozereal.com:80/", "http://xxtauth1.sozereal.com:80/" };
		Random random = new Random();
		string[] array = obj;
		int num = 0;
		string text;
		while (true)
		{
			if (num < array.Length)
			{
				text = smethod_16(array[num] + string_0 + "?r=" + Conversions.ToString(random.Next()), string_1, 3000);
				if (Operators.CompareString(text, "", TextCompare: false) != 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return "";
		}
		return text;
	}

	public static string smethod_16(string string_0, string string_1, int int_0 = 5000)
	{
		string result;
		try
		{
			ServicePointManager.MaxServicePoints = 512;
			ServicePointManager.DefaultConnectionLimit = 250;
			ServicePointManager.Expect100Continue = false;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Timeout = int_0;
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.Headers.Add("Accept-Language", "zh-cn");
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
			}
			string text;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using Stream stream2 = webResponse.GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream2);
				text = streamReader.ReadToEnd();
			}
			httpWebRequest = null;
			result = text;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void smethod_17(JArray jarray_0, string string_0, Queue<string> queue_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		foreach (JObject item in ((JContainer)jarray_0).Children())
		{
			JObject val = item;
			Queue queue = new Queue(queue_0);
			string text = "";
			try
			{
				while (queue.Count != 0)
				{
					string path = Conversions.ToString(queue.Dequeue());
					if (!File.Exists(path))
					{
						continue;
					}
					int int_ = Class9.int_0;
					for (int i = 1; i <= int_; i = checked(i + 1))
					{
						text = smethod_35("http://" + val["ip"].ToString() + ":46952/write_file", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject(new object[2]
						{
							(object)new JProperty("filename", (object)(string_0 + "/" + Path.GetFileName(path))),
							(object)new JProperty("data", (object)Convert.ToBase64String(File.ReadAllBytes(path)))
						}))));
						if (text.Contains("message"))
						{
							break;
						}
						smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(i));
					}
					try
					{
						if (text.Contains("message"))
						{
							JObject val2 = JObject.Parse(text);
							if ((int)val2["code"] == 0)
							{
								smethod_30(val["ip"].ToString(), Path.GetFileName(path) + " 发送成功");
							}
							else
							{
								smethod_30(val["ip"].ToString(), (string)val2["message"]);
							}
						}
						else
						{
							smethod_30(val["ip"].ToString(), "超时");
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						smethod_30(val["ip"].ToString(), ex2.Message.ToString());
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				smethod_30(val["ip"].ToString(), ex4.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void smethod_18(JArray jarray_0, string string_0, Queue<string> queue_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		foreach (JObject item in ((JContainer)jarray_0).Children())
		{
			JObject val = item;
			Queue queue = new Queue(queue_0);
			string text = "";
			try
			{
				while (queue.Count != 0)
				{
					string path = Conversions.ToString(queue.Dequeue());
					if (!File.Exists(path))
					{
						continue;
					}
					int int_ = Class9.int_0;
					for (int i = 1; i <= int_; i = checked(i + 1))
					{
						text = smethod_35("http://" + val["ip"].ToString() + ":46952/write_file", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject(new object[2]
						{
							(object)new JProperty("filename", (object)(string_0 + "/" + Path.GetFileName(path))),
							(object)new JProperty("data", (object)Convert.ToBase64String(File.ReadAllBytes(path)))
						}))));
						if (text.Contains("message"))
						{
							break;
						}
						smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(i));
					}
					try
					{
						if (text.Contains("message"))
						{
							JObject val2 = JObject.Parse(text);
							if ((int)val2["code"] == 0)
							{
								smethod_30(val["ip"].ToString(), Path.GetFileName(path) + " 发送成功");
							}
							else
							{
								smethod_30(val["ip"].ToString(), (string)val2["message"]);
							}
						}
						else
						{
							smethod_30(val["ip"].ToString(), "超时");
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						smethod_30(val["ip"].ToString(), ex2.Message.ToString());
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				smethod_30(val["ip"].ToString(), ex4.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void smethod_19(JArray jarray_0)
	{
		smethod_4(jarray_0, "halt", "", "已关机");
	}

	public static void smethod_20(JArray jarray_0)
	{
		smethod_4(jarray_0, "reboot2", "", "已重启");
	}

	public static void smethod_21(JArray jarray_0)
	{
		smethod_4(jarray_0, "respring", "", "已注销");
	}

	public static void smethod_22(JArray jarray_0)
	{
		smethod_4(jarray_0, "lock_screen", "device.lock_screen()", "锁屏成功");
	}

	public static void smethod_23(JArray jarray_0)
	{
		smethod_4(jarray_0, "unlock_screen", "device.unlock_screen()", "解锁成功");
	}

	public static void smethod_24(JArray jarray_0)
	{
		smethod_4(jarray_0, "clear_all", "", "全清成功");
	}

	public static void smethod_25(JArray jarray_0, int int_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		smethod_4(jarray_0, "set_brightness", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("level", (object)((double)int_0 / 100.0)))), "设置成功");
	}

	public static void smethod_26(JArray jarray_0, int int_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		smethod_4(jarray_0, "set_volume", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("level", (object)((double)int_0 / 100.0)))), "设置成功");
	}

	public static void smethod_27(JArray jarray_0, string string_0)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		int num = 1;
		checked
		{
			foreach (JObject item in ((JContainer)jarray_0).Children())
			{
				JObject val = item;
				string text = "";
				string text2 = string_0;
				string[] array = val["ip"].ToString().Split('.');
				text2 = text2.Replace("{ip}", val["ip"].ToString());
				text2 = text2.Replace("{ip:1}", array[0]);
				text2 = text2.Replace("{ip:2}", array[1]);
				text2 = text2.Replace("{ip:3}", array[2]);
				text2 = text2.Replace("{ip:4}", array[3]);
				text2 = text2.Replace("{index}", Conversions.ToString(num));
				text2 = text2.Replace("{devtype}", val["devtype"].ToString());
				text2 = text2.Replace("{sysversion}", val["sysversion"].ToString());
				int int_ = Class9.int_0;
				for (int i = 1; i <= int_; i++)
				{
					text = smethod_33("http://" + val["ip"].ToString() + ":46952/set_device_name", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("name", (object)text2))));
					if (text.Contains("message"))
					{
						break;
					}
					smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(i) + "次");
				}
				try
				{
					if (text.Contains("message"))
					{
						JObject val2 = JObject.Parse(text);
						if ((int)val2["code"] == 0)
						{
							smethod_31(val["ip"].ToString(), text2);
							smethod_30(val["ip"].ToString(), "改名成功");
							num++;
						}
						else
						{
							smethod_30(val["ip"].ToString(), (string)val2["message"]);
						}
					}
					else
					{
						smethod_30(val["ip"].ToString(), "超时");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					smethod_30(val["ip"].ToString(), ex2.Message.ToString());
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public static void smethod_28(JArray jarray_0, JObject jobject_0)
	{
		smethod_3(jarray_0, "set_user_conf", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)jobject_0)), "设置成功");
	}

	public static void smethod_29(JArray jarray_0, Queue<string> queue_0)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		string text = "";
		foreach (JObject item in ((JContainer)jarray_0).Children())
		{
			JObject val = item;
			Queue queue = new Queue(queue_0);
			while (queue.Count != 0)
			{
				string path = Conversions.ToString(queue.Dequeue());
				if (!File.Exists(path))
				{
					continue;
				}
				int int_ = Class9.int_0;
				for (int i = 1; i <= int_; i = checked(i + 1))
				{
					text = smethod_35("http://" + val["ip"].ToString() + ":46952/image_to_album", File.ReadAllBytes(path));
					if (text.Contains("message"))
					{
						break;
					}
					smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(i) + "次");
				}
				try
				{
					if (text.Contains("message"))
					{
						JObject val2 = JObject.Parse(text);
						if ((int)val2["code"] == 0)
						{
							smethod_30(val["ip"].ToString(), Path.GetFileName(path) + " 发送成功");
						}
						else
						{
							smethod_30(val["ip"].ToString(), (string)val2["message"]);
						}
					}
					else
					{
						smethod_30(val["ip"].ToString(), "超时");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					smethod_30(val["ip"].ToString(), ex2.Message.ToString());
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public static void smethod_30(string string_0, string string_1)
	{
		if (Class9.form_Main_t_0.DataGridView_DeviceList.InvokeRequired)
		{
			Delegate4 method = smethod_30;
			Class9.form_Main_t_0.DataGridView_DeviceList.Invoke(method, string_0, string_1);
			return;
		}
		object obj = object_2;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				Class9.dataTable_0.Select("ip='" + string_0 + "'")[0]["message"] = string_1;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void smethod_31(string string_0, string string_1)
	{
		if (Class9.form_Main_t_0.InvokeRequired)
		{
			Delegate5 method = smethod_31;
			Class9.form_Main_t_0.Invoke(method, string_0, string_1);
			return;
		}
		object obj = object_2;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				Class9.dataTable_0.Select("ip='" + string_0 + "'")[0]["devname"] = string_1;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void smethod_32(string string_0, int int_0, string string_1)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			using UdpClient udpClient = new UdpClient();
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(string_0), int_0);
			udpClient.Send(bytes, bytes.Length, endPoint);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static string fjEboebqnu(string string_0, int int_0 = 5000, CookieContainer cookieContainer_0 = null)
	{
		string result;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Timeout = int_0;
			httpWebRequest.ReadWriteTimeout = int_0;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Method = "GET";
			if (cookieContainer_0 != null)
			{
				httpWebRequest.CookieContainer = cookieContainer_0;
			}
			if (Operators.CompareString(httpWebRequest.ContentType, "", TextCompare: false) == 0)
			{
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			}
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
			string text;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using Stream stream = webResponse.GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream);
				text = streamReader.ReadToEnd();
			}
			result = text;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string smethod_33(string string_0, string string_1, int int_0 = 5000, string string_2 = "")
	{
		string result;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ServicePoint.ConnectionLimit = 200;
			httpWebRequest.AllowAutoRedirect = true;
			httpWebRequest.KeepAlive = false;
			httpWebRequest.Timeout = int_0;
			httpWebRequest.ReadWriteTimeout = 100000;
			if (Operators.CompareString(string_2, "", TextCompare: false) != 0)
			{
				httpWebRequest.Headers.Add("spawn_args", string_2);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
				stream.Close();
			}
			string text;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using (Stream stream2 = webResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(stream2))
					{
						text = streamReader.ReadToEnd();
						streamReader.Close();
					}
					stream2.Close();
				}
				webResponse.Close();
			}
			httpWebRequest = null;
			result = text;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string smethod_34(string string_0, JObject jobject_0, int int_0 = 5000, string string_1 = "")
	{
		return smethod_33(string_0, JsonConvert.SerializeObject((object)jobject_0), int_0, string_1);
	}

	public static string smethod_35(string string_0, byte[] byte_0, int int_0 = 5000, string string_1 = "")
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		string result;
		try
		{
			Uri uri = new Uri(string_0);
			TcpClient tcpClient = new TcpClient
			{
				SendTimeout = int_0,
				ReceiveTimeout = int_0
			};
			tcpClient.Client.ReceiveTimeout = int_0;
			tcpClient.Connect(uri.Host, uri.Port);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("POST " + uri.PathAndQuery + " HTTP/1.1\r\n");
			if (Operators.CompareString(string_1, "", TextCompare: false) != 0)
			{
				stringBuilder.Append("spawn_args: " + string_1 + "\r\n");
			}
			stringBuilder.Append("Host:" + uri.Host + "\r\n");
			stringBuilder.Append("Content-Length: " + Conversions.ToString(byte_0.Length) + "\r\n\r\n");
			byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
			tcpClient.Client.Send(smethod_38(bytes, byte_0));
			int num = 0;
			JObject val = new JObject();
			string text = "";
			bool flag = false;
			int num2 = Conversions.ToInteger(Class9.smethod_1());
			do
			{
				byte[] array = new byte[1024000];
				try
				{
					int num3 = tcpClient.Client.Receive(array);
					if (num3 <= 0)
					{
						continue;
					}
					string[] array2 = Encoding.UTF8.GetString(array, 0, num3).Split('\r');
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						string text2 = array2[i];
						text2 = text2.Trim();
						if (num == 0)
						{
							num = Conversions.ToInteger(text2.Split(' ')[1]);
						}
						else if (flag)
						{
							text += text2;
							if (Encoding.UTF8.GetBytes(text).Length == (int)val["Content-Length"])
							{
								goto end_IL_00ff;
							}
						}
						else if (text2.Split(':').Length > 1)
						{
							((JContainer)val).Add((object)new JProperty(text2.Split(':')[0], (object)text2.Split(':')[1]));
						}
						else
						{
							flag = true;
							if (val["Content-Length"] == null)
							{
								goto end_IL_00ff;
							}
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				continue;
				end_IL_00ff:
				break;
			}
			while (tcpClient.Client.Connected && !Operators.ConditionalCompareObjectGreater(Operators.SubtractObject(Class9.smethod_1(), num2), (double)int_0 / 1000.0, TextCompare: false));
			tcpClient.Close();
			result = text;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static byte[] smethod_36(string string_0, string string_1)
	{
		byte[] result;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Timeout = 2000;
			httpWebRequest.ReadWriteTimeout = 2000;
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			object obj = null;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
				using MemoryStream memoryStream = new MemoryStream();
				streamReader.BaseStream.CopyTo(memoryStream);
				obj = memoryStream.ToArray();
			}
			result = (byte[])obj;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static byte[] smethod_37(string string_0)
	{
		byte[] result;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Timeout = 2000;
			httpWebRequest.Method = "GET";
			if (Operators.CompareString(httpWebRequest.ContentType, "", TextCompare: false) == 0)
			{
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			}
			object obj = null;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
				using MemoryStream memoryStream = new MemoryStream();
				streamReader.BaseStream.CopyTo(memoryStream);
				obj = memoryStream.ToArray();
			}
			result = (byte[])obj;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static byte[] smethod_38(byte[] byte_0, byte[] byte_1)
	{
		List<byte> list = new List<byte>();
		list.AddRange(byte_0);
		list.AddRange(byte_1);
		byte_0 = new byte[checked(list.Count - 1 + 1)];
		list.CopyTo(byte_0);
		return byte_0;
	}

	public static string smethod_39(string string_0, Dictionary<string, string> dictionary_0)
	{
		string appKey = "23559128";
		string appSecret = "5f3cadc6a99078eb0ef3b5dccec5fec7";
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Dictionary<string, string> querys = new Dictionary<string, string>();
		List<string> list = new List<string>();
		dictionary.Add("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
		dictionary.Add("Accept", "application/json; charset=utf-8");
		list.Add("X-Ca-Timestamp");
		using HttpWebResponse httpWebResponse = HttpUtil.HttpPost("http://api.xxtouch.com", string_0, appKey, appSecret, 30000, dictionary, querys, dictionary_0, list);
		Console.WriteLine((int)httpWebResponse.StatusCode);
		Console.WriteLine(httpWebResponse.Method);
		Console.WriteLine(httpWebResponse.Headers);
		Stream responseStream = httpWebResponse.GetResponseStream();
		return new StreamReader(responseStream, Encoding.GetEncoding("utf-8")).ReadToEnd();
	}

	public static string smethod_40(string string_0)
	{
		if (File.Exists(string_0))
		{
			return "file";
		}
		if (Directory.Exists(string_0))
		{
			return "directory";
		}
		return null;
	}

	public static bool smethod_41(string string_0)
	{
		if (File.Exists(string_0))
		{
			File.Delete(string_0);
			return true;
		}
		return false;
	}

	public static JArray JisbjoRiCH(string string_0)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		if (Directory.Exists(string_0))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			JArray val = new JArray();
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				val.Add((JToken)new JValue(directoryInfo2.Name));
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				val.Add((JToken)new JValue(fileInfo.Name));
			}
			return val;
		}
		return null;
	}

	public static int smethod_42(string string_0)
	{
		if (File.Exists(string_0))
		{
			return checked((int)new FileInfo(string_0).Length);
		}
		return -1;
	}

	public static byte[] smethod_43(string string_0)
	{
		if (File.Exists(string_0))
		{
			return File.ReadAllBytes(string_0);
		}
		return null;
	}

	public static bool smethod_44(string string_0, byte[] byte_0)
	{
		bool result;
		try
		{
			File.WriteAllBytes(string_0, byte_0);
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool smethod_45(string string_0, string string_1)
	{
		bool result;
		try
		{
			File.AppendAllText(string_0, string_1, Encoding.UTF8);
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int smethod_46(string string_0)
	{
		if (File.Exists(string_0))
		{
			return File.ReadAllLines(string_0, Encoding.UTF8).Length;
		}
		return -1;
	}

	public static string ucabvFvLfw(string string_0, int int_0)
	{
		if (File.Exists(string_0))
		{
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			int_0 %= array.Length;
			checked
			{
				if (int_0 > 0)
				{
					return array[int_0 - 1];
				}
				if (int_0 < 0)
				{
					return array[array.Length - (int_0 - 1)];
				}
				return array[array.Length - 1];
			}
		}
		return null;
	}

	public static bool smethod_47(string string_0, int int_0, string string_1)
	{
		if (File.Exists(string_0))
		{
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			int_0 %= array.Length;
			checked
			{
				if (int_0 > 0)
				{
					array[int_0 - 1] = string_1;
				}
				else if (int_0 < 0)
				{
					array[array.Length - (int_0 - 1)] = string_1;
				}
				else
				{
					array[array.Length - 1] = string_1;
				}
				File.WriteAllLines(string_0, array, Encoding.UTF8);
				return true;
			}
		}
		return false;
	}

	public static bool smethod_48(string string_0, int int_0, string string_1)
	{
		if (File.Exists(string_0))
		{
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			List<string> list = array.ToList();
			int_0 %= array.Length;
			checked
			{
				if (int_0 > 0)
				{
					list.Insert(int_0 - 1, string_1);
				}
				else if (int_0 < 0)
				{
					list.Insert(array.Length - (int_0 - 1), string_1);
				}
				else
				{
					list.Insert(array.Length, string_1);
				}
				array = list.ToArray();
				File.WriteAllLines(string_0, array, Encoding.UTF8);
				return true;
			}
		}
		return false;
	}

	public static bool smethod_49(string string_0, int int_0)
	{
		bool result;
		try
		{
			if (File.Exists(string_0))
			{
				string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
				List<string> list = array.ToList();
				int_0 %= array.Length;
				checked
				{
					if (int_0 > 0)
					{
						list.RemoveAt(int_0 - 1);
					}
					else if (int_0 < 0)
					{
						list.RemoveAt(array.Length + int_0);
					}
					else
					{
						list.RemoveAt(array.Length - 1);
					}
					array = list.ToArray();
					File.WriteAllLines(string_0, array, Encoding.UTF8);
					result = true;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static JArray smethod_50(string string_0)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		if (File.Exists(string_0))
		{
			JArray val = new JArray();
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			foreach (string text in array)
			{
				val.Add((JToken)new JValue(text));
			}
			return val;
		}
		return null;
	}

	public static string smethod_51(string string_0, JArray jarray_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (File.Exists(string_0))
		{
			string[] source = File.ReadAllLines(string_0, Encoding.UTF8);
			List<string> list = source.ToList();
			foreach (JToken item2 in ((JContainer)jarray_0).Children())
			{
				string item = (string)item2;
				list.Add(item);
			}
			source = list.ToArray();
			File.WriteAllLines(string_0, source, Encoding.UTF8);
			return Conversions.ToString(Value: true);
		}
		return Conversions.ToString(Value: false);
	}

	public static bool smethod_52(string string_0, int int_0, JArray jarray_0)
	{
		if (File.Exists(string_0))
		{
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			List<string> list = array.ToList();
			int_0 %= array.Length;
			checked
			{
				for (int i = ((JContainer)jarray_0).Count - 1; i >= 0; i += -1)
				{
					if (int_0 > 0)
					{
						list.Insert(int_0 - 1, (string)jarray_0[i]);
					}
					else if (int_0 < 0)
					{
						list.Insert(array.Length - (int_0 - 1), (string)jarray_0[i]);
					}
					else
					{
						list.Insert(int_0 - 1, (string)jarray_0[i]);
					}
				}
				array = list.ToArray();
				File.WriteAllLines(string_0, array, Encoding.UTF8);
				return true;
			}
		}
		return false;
	}

	public static string smethod_53(string string_0)
	{
		if (File.Exists(string_0))
		{
			string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
			if (array.Length == 0)
			{
				return "";
			}
			List<string> list = array.ToList();
			string result = list[0];
			list.RemoveAt(0);
			array = list.ToArray();
			File.WriteAllLines(string_0, array, Encoding.UTF8);
			return result;
		}
		return "";
	}

	public static byte[] smethod_54(string string_0)
	{
		if (Directory.Exists(string_0))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			if (directoryInfo.GetFiles().Length > 0)
			{
				byte[] result = File.ReadAllBytes(string_0 + directoryInfo.GetFiles().First().Name);
				File.Delete(string_0 + directoryInfo.GetFiles().First().Name);
				return result;
			}
			return null;
		}
		return null;
	}
}
