using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace XXTCC;

public class Class_UDP
{
	private delegate void Delegate0(string Message);

	private UdpClient udpClient_0;

	private Thread thread_0;

	private static object object_0;

	static Class_UDP()
	{
		Class14.QwnfEIbzxvDCI();
		object_0 = RuntimeHelpers.GetObjectValue(new object());
	}

	public Class_UDP()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public object Start(int iPort = 27000)
	{
		object result;
		try
		{
			udpClient_0 = new UdpClient(iPort);
			thread_0 = new Thread(method_0);
			thread_0.Start();
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

	private void method_0(object object_1)
	{
		IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
		while (true)
		{
			try
			{
				byte[] bytes = udpClient_0.Receive(ref remoteEP);
				string message = Encoding.UTF8.GetString(bytes);
				AddWarning(message);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void AddWarning(string Message)
	{
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		if (Class9.form_Main_t_0.DataGridView_DeviceList.InvokeRequired)
		{
			Delegate0 method = AddWarning;
			Class9.form_Main_t_0.DataGridView_DeviceList.Invoke(method, Message);
			return;
		}
		object obj = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				JObject val = JObject.Parse(Message);
				DataRow dataRow = Class9.dataTable_0.Rows.Find(val["deviceid"].ToString());
				if (dataRow == null)
				{
					DataRow dataRow2 = Class9.dataTable_0.NewRow();
					dataRow2["check"] = false;
					dataRow2["ip"] = val["ip"].ToString();
					string[] array = val["ip"].ToString().Split('.');
					dataRow2["_ip"] = Conversions.ToLong(array[0].PadLeft(3, '0') + array[1].PadLeft(3, '0') + array[2].PadLeft(3, '0') + array[3].PadLeft(3, '0'));
					dataRow2["port"] = val["port"].ToString();
					dataRow2["devname"] = val["devname"].ToString();
					dataRow2["deviceid"] = val["deviceid"].ToString();
					dataRow2["devmac"] = val["devmac"].ToString();
					dataRow2["devsn"] = val["devsn"].ToString();
					dataRow2["devtype"] = val["devtype"].ToString();
					dataRow2["zeversion"] = val["zeversion"].ToString();
					dataRow2["sysversion"] = val["sysversion"].ToString();
					dataRow2["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["boardconfig"] == null, "", val["boardconfig"]));
					dataRow2["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["ecid"] == null, "", val["ecid"]));
					dataRow2["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["buildid"] == null, "", val["buildid"]));
					Class9.dataTable_0.Rows.Add(dataRow2);
					((JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"]).Add((JToken)(object)val);
					return;
				}
				DataRow dataRow3 = dataRow;
				dataRow3["ip"] = val["ip"].ToString();
				string[] array2 = val["ip"].ToString().Split('.');
				dataRow3["_ip"] = Conversions.ToLong(array2[0].PadLeft(3, '0') + array2[1].PadLeft(3, '0') + array2[2].PadLeft(3, '0') + array2[3].PadLeft(3, '0'));
				dataRow3["port"] = val["port"].ToString();
				dataRow3["devname"] = val["devname"].ToString();
				dataRow3["devsn"] = val["devsn"].ToString();
				dataRow3["devmac"] = val["devmac"].ToString();
				dataRow3["devtype"] = val["devtype"].ToString();
				dataRow3["zeversion"] = val["zeversion"].ToString();
				dataRow3["sysversion"] = val["sysversion"].ToString();
				dataRow3["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["boardconfig"] == null, "", val["boardconfig"]));
				dataRow3["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["ecid"] == null, "", val["ecid"]));
				dataRow3["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["buildid"] == null, "", val["buildid"]));
				JArray val2 = (JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"];
				using IEnumerator<JToken> enumerator = ((JContainer)val2).Children().GetEnumerator();
				JObject val3;
				do
				{
					if (enumerator.MoveNext())
					{
						val3 = (JObject)enumerator.Current;
						continue;
					}
					return;
				}
				while (Operators.CompareString(val3["deviceid"].ToString(), val["deviceid"].ToString(), TextCompare: false) != 0);
				val3["ip"] = JToken.op_Implicit(val["ip"].ToString());
				val3["port"] = JToken.op_Implicit(val["port"].ToString());
				val3["devname"] = JToken.op_Implicit(val["devname"].ToString());
				val3["devsn"] = JToken.op_Implicit(val["devsn"].ToString());
				val3["devmac"] = JToken.op_Implicit(val["devmac"].ToString());
				val3["devtype"] = JToken.op_Implicit(val["devtype"].ToString());
				val3["zeversion"] = JToken.op_Implicit(val["zeversion"].ToString());
				val3["sysversion"] = JToken.op_Implicit(val["sysversion"].ToString());
				val3["boardconfig"] = JToken.op_Implicit(Interaction.IIf(val["boardconfig"] == null, "", val["boardconfig"]).ToString());
				val3["ecid"] = JToken.op_Implicit(Interaction.IIf(val["ecid"] == null, "", val["ecid"]).ToString());
				val3["buildid"] = JToken.op_Implicit(Interaction.IIf(val["buildid"] == null, "", val["buildid"]).ToString());
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

	public void Close()
	{
		try
		{
			Thread.Sleep(5);
			udpClient_0.Close();
			thread_0.Abort();
			thread_0 = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
