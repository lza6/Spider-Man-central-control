using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XXTCC;

public class HomeModule : NancyModule
{
	private static object object_0;

	static HomeModule()
	{
		Class14.QwnfEIbzxvDCI();
		object_0 = RuntimeHelpers.GetObjectValue(new object());
	}

	public HomeModule()
	{
		Class14.QwnfEIbzxvDCI();
		((NancyModule)this)._002Ector();
		((NancyModule)this).Get["/getui"] = [SpecialName] (object r) => JsonConvert.SerializeObject((object)Class9.jobject_0);
		((NancyModule)this).Post["/getui"] = [SpecialName] (object r) => JsonConvert.SerializeObject((object)Class9.jobject_0);
		((NancyModule)this).Post["/log"] = [SpecialName] (object r) =>
		{
			string string_ = new StreamReader((Stream)(object)((NancyModule)this).Request.Body, Encoding.GetEncoding("utf-8")).ReadToEnd();
			Class9.smethod_7(((NancyModule)this).Request.UserHostAddress, string_);
			return "ok";
		};
		((NancyModule)this).Post["/db/{mode}"] = [SpecialName] (object r) =>
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Expected O, but got Unknown
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Expected O, but got Unknown
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Expected O, but got Unknown
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Invalid comparison between Unknown and I4
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Expected O, but got Unknown
			object result;
			try
			{
				JObject val = JObject.Parse(new StreamReader((Stream)(object)((NancyModule)this).Request.Body, Encoding.GetEncoding("utf-8")).ReadToEnd());
				object obj = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					object left = NewLateBinding.LateIndexGet(r, new object[1] { "mode" }, null);
					result = (Operators.ConditionalCompareObjectEqual(left, "get", TextCompare: false) ? ((JToken)Class9.smethod_12((string)val["db"], (JArray)val["data"])).ToString() : (Operators.ConditionalCompareObjectEqual(left, "del", TextCompare: false) ? ((JToken)Class9.smethod_11((string)val["db"], (JArray)val["data"])).ToString() : (Operators.ConditionalCompareObjectEqual(left, "edit", TextCompare: false) ? ((JToken)Class9.smethod_9((string)val["db"], (JArray)val["data"])).ToString() : (Operators.ConditionalCompareObjectEqual(left, "add", TextCompare: false) ? ((JToken)Class9.YurUbgmNio((string)val["db"], (JArray)val["data"])).ToString() : (Operators.ConditionalCompareObjectEqual(left, "list", TextCompare: false) ? ((val["data"] == null) ? ((JToken)Class9.smethod_10((string)val["db"], new JArray())).ToString() : (((int)val["data"].Type != 2) ? ((JToken)Class9.smethod_10((string)val["db"], new JArray())).ToString() : ((JToken)Class9.smethod_10((string)val["db"], (JArray)val["data"])).ToString())) : ((!Operators.ConditionalCompareObjectEqual(left, "select", TextCompare: false)) ? JsonConvert.SerializeObject((object)new JObject(new object[3]
					{
						(object)new JProperty("state", (object)1),
						(object)new JProperty("message", (object)"提交数据不正确"),
						(object)new JProperty("data", (object)new JArray())
					})) : ((JToken)Class9.smethod_13((string)val["db"], (string)val["data"])).ToString()))))));
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = ex2.Message;
				ProjectData.ClearProjectError();
			}
			return result;
		};
		((NancyModule)this).Post["/file/{mode}"] = [SpecialName] (object r) =>
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected O, but got Unknown
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Expected O, but got Unknown
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Expected O, but got Unknown
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Expected O, but got Unknown
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Expected O, but got Unknown
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Expected O, but got Unknown
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Expected O, but got Unknown
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Expected O, but got Unknown
			//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bd: Expected O, but got Unknown
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_044f: Expected O, but got Unknown
			//IL_045b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0465: Expected O, but got Unknown
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Expected O, but got Unknown
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Expected O, but got Unknown
			//IL_0520: Unknown result type (might be due to invalid IL or missing references)
			//IL_052a: Expected O, but got Unknown
			//IL_058d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0597: Expected O, but got Unknown
			//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f4: Expected O, but got Unknown
			//IL_0632: Unknown result type (might be due to invalid IL or missing references)
			//IL_063c: Expected O, but got Unknown
			//IL_0680: Unknown result type (might be due to invalid IL or missing references)
			//IL_068a: Expected O, but got Unknown
			//IL_068a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0694: Expected O, but got Unknown
			//IL_070b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0715: Expected O, but got Unknown
			//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ef: Expected O, but got Unknown
			//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fe: Expected O, but got Unknown
			object result;
			try
			{
				JObject val = JObject.Parse(new StreamReader((Stream)(object)((NancyModule)this).Request.Body, Encoding.UTF8).ReadToEnd());
				JObject val2 = new JObject();
				object obj = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					object left = NewLateBinding.LateIndexGet(r, new object[1] { "mode" }, null);
					if (Operators.ConditionalCompareObjectEqual(left, "exicts", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("info", (object)Class8.smethod_40(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "exists", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("info", (object)Class8.smethod_40(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "delete", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_41(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "list", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("list", (object)Class8.JisbjoRiCH(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "size", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("fsize", (object)Class8.smethod_42(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "reads", TextCompare: false))
					{
						byte[] array = Class8.smethod_43(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString());
						if (array != null)
						{
							((JContainer)val2).Add((object)new JProperty("data", (object)Convert.ToBase64String(array)));
							((JContainer)val2).Add((object)new JProperty("success", (object)true));
						}
						else
						{
							((JContainer)val2).Add((object)new JProperty("data", (object)""));
							((JContainer)val2).Add((object)new JProperty("success", (object)false));
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "writes", TextCompare: false))
					{
						byte[] byte_ = Convert.FromBase64String(val["data"].ToString());
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_44(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), byte_)));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "appends", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_45(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), Encoding.UTF8.GetString(Convert.FromBase64String(val["data"].ToString())))));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "line_count", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("linecount", (object)Class8.smethod_46(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "take_line", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("data", (object)Class8.smethod_53(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "take_file", TextCompare: false))
					{
						byte[] array2 = Class8.smethod_54(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString());
						if (array2 != null)
						{
							((JContainer)val2).Add((object)new JProperty("data", (object)Convert.ToBase64String(array2)));
							((JContainer)val2).Add((object)new JProperty("success", (object)true));
						}
						else
						{
							((JContainer)val2).Add((object)new JProperty("data", (object)""));
							((JContainer)val2).Add((object)new JProperty("success", (object)false));
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "get_line", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("line", (object)Class8.ucabvFvLfw(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (int)val["line_number"])));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "set_line", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_47(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (int)val["line_number"], (string)val["data"])));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "insert_line", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_48(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (int)val["line_number"], (string)val["data"])));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "remove_line", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_49(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (int)val["line_number"])));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "get_lines", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("lines", (object)Class8.smethod_50(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "set_lines", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_51(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (JArray)val["lines"])));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "insert_lines", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("success", (object)Class8.smethod_52(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), (int)val["line_number"], (JArray)val["lines"])));
					}
					else
					{
						((JContainer)val2).Add((object)new JProperty("error", (object)"不存在此命令"));
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
				result = JsonConvert.SerializeObject((object)val2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = ex2.Message;
				ProjectData.ClearProjectError();
			}
			return result;
		};
		((NancyModule)this).Post["/directory/{mode}"] = [SpecialName] (object r) =>
		{
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Expected O, but got Unknown
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Expected O, but got Unknown
			object result;
			try
			{
				JObject val = JObject.Parse(new StreamReader((Stream)(object)((NancyModule)this).Request.Body, Encoding.UTF8).ReadToEnd());
				JObject val2 = new JObject();
				object obj = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					object left = NewLateBinding.LateIndexGet(r, new object[1] { "mode" }, null);
					if (Operators.ConditionalCompareObjectEqual(left, "exicts", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("info", (object)Class8.smethod_40(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "exists", TextCompare: false))
					{
						((JContainer)val2).Add((object)new JProperty("info", (object)Class8.smethod_40(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString())));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "create", TextCompare: false))
					{
						try
						{
							Directory.CreateDirectory(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString());
							((JContainer)val2).Add((object)new JProperty("success", (object)true));
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							((JContainer)val2).Add((object)new JProperty("success", (object)false));
							ProjectData.ClearProjectError();
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "delete", TextCompare: false))
					{
						try
						{
							Directory.Delete(Environment.CurrentDirectory + "\\data\\" + val["path"].ToString(), recursive: true);
							((JContainer)val2).Add((object)new JProperty("success", (object)true));
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							((JContainer)val2).Add((object)new JProperty("success", (object)false));
							ProjectData.ClearProjectError();
						}
						((JContainer)val2).Add((object)new JProperty("error", (object)"不存在此命令"));
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
				result = JsonConvert.SerializeObject((object)val2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = ex2.Message;
				ProjectData.ClearProjectError();
			}
			return result;
		};
		((NancyModule)this).Post["/filebyte/down/{file}"] = [SpecialName] (object r) =>
		{
			object obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (File.Exists(Conversions.ToString(Operators.ConcatenateObject(Environment.CurrentDirectory + "\\data\\", NewLateBinding.LateIndexGet(r, new object[1] { "file" }, null)))))
				{
					return File.ReadAllBytes(Conversions.ToString(Operators.ConcatenateObject(Environment.CurrentDirectory + "\\data\\", NewLateBinding.LateIndexGet(r, new object[1] { "file" }, null))));
				}
				((NancyModule)this).Context.Response.StatusCode = (HttpStatusCode)404;
				return "文件不存在";
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		};
		((NancyModule)this).Post["/filebyte/update/{file}"] = [SpecialName] (object r) =>
		{
			object obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			object result;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				try
				{
					using (FileStream destination = new FileStream(Conversions.ToString(Operators.ConcatenateObject(Environment.CurrentDirectory + "\\data\\", NewLateBinding.LateIndexGet(r, new object[1] { "file" }, null))), FileMode.Create))
					{
						((Stream)(object)((NancyModule)this).Request.Body).CopyTo((Stream)destination);
					}
					result = "ok";
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					((NancyModule)this).Context.Response.StatusCode = (HttpStatusCode)503;
					result = ex2.Message;
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
			return result;
		};
		((NancyModule)this).Get["/file-byte/down"] = [SpecialName] (object r) =>
		{
			Type typeFromHandle = typeof(HttpUtility);
			object[] array = new object[2];
			object query;
			object instance = (query = ((NancyModule)this).Request.Query);
			object[] array2 = new object[1];
			object obj = (array2[0] = "file");
			array[0] = NewLateBinding.LateIndexGet(instance, array2, null);
			array[1] = Encoding.UTF8;
			object[] array3 = array;
			bool[] obj2 = new bool[2] { true, false };
			bool[] array4 = obj2;
			object obj3 = NewLateBinding.LateGet(null, typeFromHandle, "UrlDecode", array, null, null, obj2);
			if (array4[0])
			{
				NewLateBinding.LateIndexSetComplex(query, new object[2]
				{
					obj,
					array3[0]
				}, null, OptimisticSet: true, RValueBase: true);
			}
			string text = Conversions.ToString(obj3);
			obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (File.Exists(Environment.CurrentDirectory + "\\data\\" + text))
				{
					return FormatterExtensions.AsFile(((NancyModule)this).Response, Environment.CurrentDirectory + "\\data\\" + text);
				}
				((NancyModule)this).Context.Response.StatusCode = (HttpStatusCode)404;
				return "文件不存在";
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		};
		((NancyModule)this).Post["/file-byte/update"] = [SpecialName] (object r) =>
		{
			Type typeFromHandle = typeof(HttpUtility);
			object[] array = new object[2];
			object query;
			object instance = (query = ((NancyModule)this).Request.Query);
			object[] array2 = new object[1];
			object obj = (array2[0] = "file");
			array[0] = NewLateBinding.LateIndexGet(instance, array2, null);
			array[1] = Encoding.UTF8;
			object[] array3 = array;
			bool[] obj2 = new bool[2] { true, false };
			bool[] array4 = obj2;
			object obj3 = NewLateBinding.LateGet(null, typeFromHandle, "UrlDecode", array, null, null, obj2);
			if (array4[0])
			{
				NewLateBinding.LateIndexSetComplex(query, new object[2]
				{
					obj,
					array3[0]
				}, null, OptimisticSet: true, RValueBase: true);
			}
			string text = Conversions.ToString(obj3);
			obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			object result;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				try
				{
					try
					{
						using (FileStream destination = new FileStream(Environment.CurrentDirectory + "\\data\\" + text, FileMode.Create))
						{
							((Stream)(object)((NancyModule)this).Request.Body).CopyTo((Stream)destination);
						}
						result = "ok";
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						((NancyModule)this).Context.Response.StatusCode = (HttpStatusCode)503;
						result = ex2.Message;
						ProjectData.ClearProjectError();
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					((NancyModule)this).Context.Response.StatusCode = (HttpStatusCode)503;
					result = ex4.Message;
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
			return result;
		};
		((NancyModule)this).Get["/"] = [SpecialName] (object r) =>
		{
			_ = Environment.OSVersion;
			return "Hello Nancy And XXTouch";
		};
	}
}
