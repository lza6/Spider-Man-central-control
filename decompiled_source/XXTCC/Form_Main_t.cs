using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
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
using org.in2bits.MyXls;

namespace XXTCC;

[DesignerGenerated]
public class Form_Main_t : Form
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D0
	{
		public string _0024VB_0024Local_IP;

		public _Closure_0024__18_002D0(_Closure_0024__18_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_IP = arg0._0024VB_0024Local_IP;
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
			Class8.smethod_0(_0024VB_0024Local_IP);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D0
	{
		public Form_Push _0024VB_0024Local_p;

		public Form_Main_t _0024VB_0024Me;

		public _Closure_0024__24_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			_Closure_0024__24_002D1 CS_0024_003C_003E8__locals4 = new _Closure_0024__24_002D1();
			CS_0024_003C_003E8__locals4._0024VB_0024Local_push_jobj = new JObject(new object[2]
			{
				(object)new JProperty("key", RuntimeHelpers.GetObjectValue(_0024VB_0024Local_p.ComboBox_Name.SelectedItem)),
				(object)new JProperty("value", (object)_0024VB_0024Local_p.TextBox_Message.Text)
			});
			_0024VB_0024Local_p.Close();
			CS_0024_003C_003E8__locals4._0024VB_0024Local_list = _0024VB_0024Me.method_45();
			new Thread([SpecialName] () =>
			{
				Class8.smethod_4(CS_0024_003C_003E8__locals4._0024VB_0024Local_list, "proc_put", JsonConvert.SerializeObject((object)CS_0024_003C_003E8__locals4._0024VB_0024Local_push_jobj), "推送成功");
			}).Start();
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object sender, EventArgs e)
		{
			_Lambda_0024__2();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			_0024VB_0024Local_p.Close();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D1
	{
		public JArray _0024VB_0024Local_list;

		public JObject _0024VB_0024Local_push_jobj;

		public _Closure_0024__24_002D1()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			Class8.smethod_4(_0024VB_0024Local_list, "proc_put", JsonConvert.SerializeObject((object)_0024VB_0024Local_push_jobj), "推送成功");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__26_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__26_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_17(_0024VB_0024Local_list, "lua/scripts", _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D0
	{
		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__28_002D0(_Closure_0024__28_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_file_queue = arg0._0024VB_0024Local_file_queue;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			_Lambda_0024__0((JArray)a0);
		}

		[SpecialName]
		internal void _Lambda_0024__0(JArray IP)
		{
			Class8.smethod_17(IP, "lua/scripts", _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__29_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__29_002D0(_Closure_0024__29_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_list = arg0._0024VB_0024Local_list;
				_0024VB_0024Local_file_queue = arg0._0024VB_0024Local_file_queue;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_17(_0024VB_0024Local_list, "res", _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__30_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__30_002D0(_Closure_0024__30_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_list = arg0._0024VB_0024Local_list;
				_0024VB_0024Local_file_queue = arg0._0024VB_0024Local_file_queue;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_17(_0024VB_0024Local_list, "lua", _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__31_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__31_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_17(_0024VB_0024Local_list, "lua", _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__32_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__32_002D0(_Closure_0024__32_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_list = arg0._0024VB_0024Local_list;
				_0024VB_0024Local_file_queue = arg0._0024VB_0024Local_file_queue;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			int num = -1;
			JObject val = null;
			string text = null;
			checked
			{
				while (true)
				{
					if (val == null)
					{
						num++;
						if (((JContainer)_0024VB_0024Local_list).Count <= num)
						{
							return;
						}
						val = (JObject)_0024VB_0024Local_list[num];
					}
					if (text == null)
					{
						if (_0024VB_0024Local_file_queue.Count == 0)
						{
							break;
						}
						text = _0024VB_0024Local_file_queue.Dequeue();
					}
					if (!File.Exists(text))
					{
						continue;
					}
					string text2 = "";
					int int_ = Class9.int_0;
					for (int i = 1; i <= int_; i++)
					{
						text2 = Class8.smethod_35("http://" + val["ip"].ToString() + ":46952/write_file", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject(new object[2]
						{
							(object)new JProperty("filename", (object)("/res/" + Path.GetFileName(text))),
							(object)new JProperty("data", (object)Convert.ToBase64String(File.ReadAllBytes(text)))
						}))));
						if (text2.Contains("message"))
						{
							break;
						}
						Class8.smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(i));
					}
					try
					{
						if (text2.Contains("message"))
						{
							JObject val2 = JObject.Parse(text2);
							if ((int)val2["code"] == 0)
							{
								Class8.smethod_30(val["ip"].ToString(), Path.GetFileName(text) + " 发送成功");
								text = null;
							}
							else
							{
								Class8.smethod_30(val["ip"].ToString(), (string)val2["message"]);
							}
						}
						else
						{
							Class8.smethod_30(val["ip"].ToString(), "超时");
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Class8.smethod_30(val["ip"].ToString(), ex2.Message.ToString());
						ProjectData.ClearProjectError();
					}
					val = null;
				}
				int num2 = num;
				int num3 = ((JContainer)_0024VB_0024Local_list).Count - 1;
				for (int j = num2; j <= num3; j++)
				{
					Class8.smethod_30(_0024VB_0024Local_list[j][(object)"ip"].ToString(), "未发送文件");
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__33_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Queue<string> _0024VB_0024Local_file_queue;

		public _Closure_0024__33_002D0(_Closure_0024__33_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_list = arg0._0024VB_0024Local_list;
				_0024VB_0024Local_file_queue = arg0._0024VB_0024Local_file_queue;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_29(_0024VB_0024Local_list, _0024VB_0024Local_file_queue);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__34_002D0
	{
		public JArray _0024VB_0024Local_list;

		public string _0024VB_0024Local_F_P;

		public _Closure_0024__34_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_14(_0024VB_0024Local_list, _0024VB_0024Local_F_P.Remove(0, 3));
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			Class8.smethod_14(_0024VB_0024Local_list, _0024VB_0024Local_F_P.Remove(0, 3) + "/main.xxt");
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			Class8.smethod_14(_0024VB_0024Local_list, _0024VB_0024Local_F_P.Remove(0, 3) + "/main.lua");
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			Class8.smethod_13(_0024VB_0024Local_list);
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			Class8.smethod_5(_0024VB_0024Local_list, _0024VB_0024Local_F_P);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__51_002D0
	{
		public Frm_Level _0024VB_0024Local_a;

		public _Closure_0024__51_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R19(object a0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			_Lambda_0024__0((JArray)a0);
		}

		[SpecialName]
		internal void _Lambda_0024__0(JArray IP)
		{
			Class8.smethod_25(IP, _0024VB_0024Local_a.TrackBar1.Value);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__52_002D0
	{
		public Frm_Level _0024VB_0024Local_a;

		public _Closure_0024__52_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R20(object a0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			_Lambda_0024__0((JArray)a0);
		}

		[SpecialName]
		internal void _Lambda_0024__0(JArray IP)
		{
			Class8.smethod_26(IP, _0024VB_0024Local_a.TrackBar1.Value);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__53_002D0
	{
		public Frm_User_cfg _0024VB_0024Local_f;

		public _Closure_0024__53_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R21(object a0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			_Lambda_0024__0((JArray)a0);
		}

		[SpecialName]
		internal void _Lambda_0024__0(JArray IP)
		{
			Class8.smethod_28(IP, _0024VB_0024Local_f.setjson);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__55_002D0
	{
		public DataRow _0024VB_0024Local__Datas;

		public _Closure_0024__55_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__55_002D0(_Closure_0024__55_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local__Datas = arg0._0024VB_0024Local__Datas;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_30(Conversions.ToString(_0024VB_0024Local__Datas["ip"]), "处理中");
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			startInfo.FileName = Application.StartupPath + "\\tools\\tsschecker\\tsschecker.exe";
			startInfo.Arguments = string.Format(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_cmd, RuntimeHelpers.GetObjectValue(_0024VB_0024Local__Datas["ecid"]), RuntimeHelpers.GetObjectValue(_0024VB_0024Local__Datas["devtype"]), RuntimeHelpers.GetObjectValue(_0024VB_0024Local__Datas["boardconfig"]));
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardInput = true;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardError = true;
			startInfo.CreateNoWindow = true;
			process.Start();
			string text = process.StandardOutput.ReadToEnd();
			process.Close();
			if (text.Contains("signed"))
			{
				Class8.smethod_30(Conversions.ToString(_0024VB_0024Local__Datas["ip"]), "处理成功");
			}
			else
			{
				Class8.smethod_30(Conversions.ToString(_0024VB_0024Local__Datas["ip"]), "处理失败");
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__55_002D1
	{
		public string _0024VB_0024Local_cmd;

		public _Closure_0024__55_002D1(_Closure_0024__55_002D1 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_cmd = arg0._0024VB_0024Local_cmd;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D0
	{
		public DataGridView _0024VB_0024Local_NDataGridView;

		public JObject _0024VB_0024Local_Columns_Width;

		public bool _0024VB_0024Local_frist_cw;

		public DataTable _0024VB_0024Local_NDataTable;

		public string _0024VB_0024Local_DbName;

		public TreeView _0024VB_0024Local_NTreeView;

		public bool _0024VB_0024Local_SelectAll;

		public VB_0024AnonymousDelegate_3<string, string, bool> _0024VB_0024Local_Run;

		public VB_0024AnonymousDelegate_2<bool> _0024VB_0024Local_ResList;

		public Form_Main_t _0024VB_0024Me;

		public _Closure_0024__58_002D0(_Closure_0024__58_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_NDataGridView = arg0._0024VB_0024Local_NDataGridView;
				_0024VB_0024Local_Columns_Width = arg0._0024VB_0024Local_Columns_Width;
				_0024VB_0024Local_frist_cw = arg0._0024VB_0024Local_frist_cw;
				_0024VB_0024Local_NDataTable = arg0._0024VB_0024Local_NDataTable;
				_0024VB_0024Local_DbName = arg0._0024VB_0024Local_DbName;
				_0024VB_0024Local_NTreeView = arg0._0024VB_0024Local_NTreeView;
				_0024VB_0024Local_SelectAll = arg0._0024VB_0024Local_SelectAll;
				_0024VB_0024Local_Run = arg0._0024VB_0024Local_Run;
				_0024VB_0024Local_ResList = arg0._0024VB_0024Local_ResList;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0()
		{
			foreach (DataGridViewColumn column in _0024VB_0024Local_NDataGridView.Columns)
			{
				_0024VB_0024Local_Columns_Width[column.DataPropertyName] = JToken.op_Implicit(column.Width);
			}
			_0024VB_0024Local_frist_cw = true;
			_0024VB_0024Local_NDataTable.Clear();
			_0024VB_0024Local_NDataGridView.DataSource = null;
			bool result;
			try
			{
				using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select * from `{_0024VB_0024Local_DbName}`", Class9.oleDbConnection_0))
				{
					using DataSet dataSet = new DataSet
					{
						Locale = CultureInfo.InvariantCulture,
						CaseSensitive = true
					};
					oleDbDataAdapter.Fill(dataSet);
					if (dataSet.Tables.Count > 0)
					{
						_0024VB_0024Local_NDataTable = dataSet.Tables[0];
						goto IL_00f3;
					}
					result = false;
				}
				goto end_IL_0078;
				IL_00f3:
				_0024VB_0024Local_NDataTable.Columns.Add("check", typeof(bool));
				_0024VB_0024Local_NDataTable.Columns["check"].SetOrdinal(0);
				goto IL_0144;
				end_IL_0078:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = false;
				ProjectData.ClearProjectError();
			}
			goto IL_03d4;
			IL_03d4:
			return result;
			IL_0144:
			DataGridView dataGridView = _0024VB_0024Local_NDataGridView;
			DataGridViewCheckBoxColumn dataGridViewColumn2 = new DataGridViewCheckBoxColumn
			{
				Width = 30,
				DataPropertyName = "check",
				HeaderText = "选择",
				ReadOnly = false
			};
			dataGridView.Columns.Add(dataGridViewColumn2);
			dataGridView.AutoGenerateColumns = true;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
			dataGridView.BackgroundColor = Color.White;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.Dock = DockStyle.Fill;
			dataGridView.ReadOnly = true;
			dataGridView.DataSource = _0024VB_0024Local_NDataTable;
			dataGridView.Invalidate();
			try
			{
				TreeView treeView = _0024VB_0024Local_NTreeView;
				treeView.CheckBoxes = true;
				treeView.Nodes.Clear();
				foreach (DataGridViewColumn column2 in _0024VB_0024Local_NDataGridView.Columns)
				{
					if ((Operators.CompareString(column2.DataPropertyName, "check", TextCompare: false) != 0) & (Operators.CompareString(column2.DataPropertyName, "id", TextCompare: false) != 0))
					{
						TreeNode treeNode = new TreeNode
						{
							Name = column2.DataPropertyName
						};
						foreach (DataRow row in _0024VB_0024Local_NDataTable.DefaultView.ToTable(column2.DataPropertyName).Rows)
						{
							string text = Conversions.ToString(Interaction.IIf(Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column2.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(row[column2.DataPropertyName])));
							int num = _0024VB_0024Local_NDataTable.Select(column2.DataPropertyName + "='" + text + "'").Length;
							treeNode.Nodes.Add(text, text + " (" + Conversions.ToString(num) + ")");
						}
						treeNode.Text = column2.HeaderText + " (" + Conversions.ToString(treeNode.Nodes.Count) + ")";
						treeView.Nodes.Add(treeNode);
					}
					else if (Operators.CompareString(column2.DataPropertyName, "check", TextCompare: false) == 0)
					{
						column2.Width = 130;
					}
				}
				treeView.Dock = DockStyle.Fill;
				treeView = null;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			result = true;
			goto IL_03d4;
		}

		[SpecialName]
		internal void _Lambda_0024__2(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex != 0)
			{
				return;
			}
			bool flag = _0024VB_0024Local_SelectAll;
			foreach (DataRow row in _0024VB_0024Local_NDataTable.Rows)
			{
				row["check"] = flag;
			}
			_0024VB_0024Local_SelectAll = !_0024VB_0024Local_SelectAll;
			_0024VB_0024Local_NDataGridView.DataSource = _0024VB_0024Local_NDataTable;
		}

		[SpecialName]
		internal void _Lambda_0024__3(object sender, EventArgs e)
		{
			if (_0024VB_0024Local_NDataGridView.IsCurrentCellDirty)
			{
				_0024VB_0024Local_NDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == 0 && e.RowIndex != -1)
				{
					DataGridView dataGridView = _0024VB_0024Local_NDataGridView;
					_0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", _0024VB_0024Local_NDataGridView[1, e.RowIndex].Value), "'")))[0]["check"] = !Conversions.ToBoolean(dataGridView[e.ColumnIndex, e.RowIndex].EditedFormattedValue);
					dataGridView.DataSource = _0024VB_0024Local_NDataTable;
					dataGridView.Invalidate();
					dataGridView = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__5(object sender, EventArgs e)
		{
			_Closure_0024__58_002D1 arg = default(_Closure_0024__58_002D1);
			_Closure_0024__58_002D1 CS_0024_003C_003E8__locals8 = new _Closure_0024__58_002D1(arg);
			CS_0024_003C_003E8__locals8._0024VB_0024NonLocal__0024VB_0024Closure_2 = this;
			if (_0024VB_0024Local_NDataGridView.SelectedRows.Count == 0)
			{
				return;
			}
			CS_0024_003C_003E8__locals8._0024VB_0024Local_v = new Frm_Edit
			{
				Text = "修改数据"
			};
			DataRow dataRow = _0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", _0024VB_0024Local_NDataGridView.SelectedRows[0].Cells["id"].Value), "'")))[0];
			int num = 1;
			checked
			{
				foreach (DataGridViewColumn column in _0024VB_0024Local_NDataGridView.Columns)
				{
					Label label = new Label();
					CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(label);
					Label label2 = label;
					if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0)
					{
						label2.Text = "选择";
					}
					else
					{
						label2.Text = column.HeaderText;
					}
					label2.Left = 12;
					label2.Top = num * 25;
					label2.AutoSize = true;
					label2 = null;
					if (Operators.CompareString(column.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
					{
						CheckBox checkBox = new CheckBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(checkBox);
						CheckBox checkBox2 = checkBox;
						if ((Operators.CompareString(column.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0))
						{
							checkBox2.Enabled = false;
						}
						if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0)
						{
							checkBox2.Checked = false;
						}
						else
						{
							checkBox2.Checked = Operators.ConditionalCompareObjectEqual(dataRow[column.DataPropertyName], "true", TextCompare: false);
						}
						checkBox2.Text = "";
						checkBox2.Left = 96;
						checkBox2.Top = num * 25 - 3;
						checkBox2.Name = column.DataPropertyName;
						checkBox2 = null;
					}
					else
					{
						TextBox textBox = new TextBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(textBox);
						TextBox textBox2 = textBox;
						if ((Operators.CompareString(column.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0))
						{
							textBox2.Enabled = false;
						}
						textBox2.Text = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow[column.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(dataRow[column.DataPropertyName])));
						textBox2.Name = column.DataPropertyName;
						textBox2.Left = 96;
						textBox2.Top = num * 25 - 3;
						textBox2 = null;
					}
					num++;
				}
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
				{
					CS_0024_003C_003E8__locals8._Lambda_0024__6(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
				};
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.ShowDialog();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__8(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (!_0024VB_0024Local_frist_cw)
			{
				return;
			}
			_0024VB_0024Local_NDataGridView.AutoResizeColumns();
			foreach (DataGridViewColumn column in _0024VB_0024Local_NDataGridView.Columns)
			{
				if (_0024VB_0024Local_Columns_Width[column.DataPropertyName] != null)
				{
					column.Width = (int)_0024VB_0024Local_Columns_Width[column.DataPropertyName];
				}
			}
			_0024VB_0024Local_frist_cw = false;
		}

		[SpecialName]
		internal void _Lambda_0024__9(object sender, TreeViewEventArgs e)
		{
			_0024VB_0024Local_NTreeView.BeginUpdate();
			if (Class9.bool_0)
			{
				_0024VB_0024Me.method_48(e.Node, e.Node.Checked);
				_0024VB_0024Me.method_49(e.Node);
				_0024VB_0024Me.method_50(e.Node);
				Class9.bool_0 = true;
			}
			_0024VB_0024Local_NTreeView.EndUpdate();
			if (!Class9.bool_0)
			{
				return;
			}
			string text = "";
			foreach (TreeNode node in _0024VB_0024Local_NTreeView.Nodes)
			{
				foreach (TreeNode node2 in node.Nodes)
				{
					if (node2.Checked)
					{
						text = text + " or " + node.Name + "='" + node2.Name + "'";
					}
				}
			}
			checked
			{
				try
				{
					DataRow[] array = _0024VB_0024Local_NDataTable.Select("check=true");
					for (int i = 0; i < array.Length; i++)
					{
						array[i]["check"] = false;
					}
					if (Operators.CompareString(text, "", TextCompare: false) != 0)
					{
						DataRow[] array2 = _0024VB_0024Local_NDataTable.Select(text.Remove(0, 4));
						for (int j = 0; j < array2.Length; j++)
						{
							array2[j]["check"] = true;
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				_0024VB_0024Local_NDataGridView.DataSource = _0024VB_0024Local_NDataTable;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__10(object sender, EventArgs e)
		{
			_0024VB_0024Local_ResList();
		}

		[SpecialName]
		internal void _Lambda_0024__11(object sender, EventArgs e)
		{
			_Closure_0024__58_002D2 arg = default(_Closure_0024__58_002D2);
			_Closure_0024__58_002D2 CS_0024_003C_003E8__locals8 = new _Closure_0024__58_002D2(arg);
			CS_0024_003C_003E8__locals8._0024VB_0024NonLocal__0024VB_0024Closure_3 = this;
			CS_0024_003C_003E8__locals8._0024VB_0024Local_v = new Frm_Edit
			{
				Text = "重置勾选"
			};
			_0024VB_0024Local_NDataTable.NewRow();
			int num = 1;
			checked
			{
				foreach (DataGridViewColumn column in _0024VB_0024Local_NDataGridView.Columns)
				{
					Label label = new Label();
					CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(label);
					Label label2 = label;
					if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0)
					{
						label2.Text = "选择";
					}
					else
					{
						label2.Text = column.HeaderText;
					}
					label2.Left = 12;
					label2.Top = num * 25;
					label2.AutoSize = true;
					label2 = null;
					if (Operators.CompareString(column.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
					{
						CheckBox checkBox = new CheckBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(checkBox);
						CheckBox checkBox2 = checkBox;
						if ((Operators.CompareString(column.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0))
						{
							checkBox2.Enabled = false;
						}
						checkBox2.Checked = false;
						checkBox2.Text = "";
						checkBox2.Left = 96;
						checkBox2.Top = num * 25 - 3;
						checkBox2.Name = column.DataPropertyName;
						checkBox2 = null;
					}
					else
					{
						TextBox textBox = new TextBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(textBox);
						TextBox textBox2 = textBox;
						if ((Operators.CompareString(column.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0))
						{
							textBox2.Enabled = false;
						}
						textBox2.Text = "(原值)";
						textBox2.Name = column.DataPropertyName;
						textBox2.Left = 96;
						textBox2.Top = num * 25 - 3;
						textBox2 = null;
					}
					num++;
				}
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
				{
					CS_0024_003C_003E8__locals8._Lambda_0024__12(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
				};
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.ShowDialog();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__13(object sender, EventArgs e)
		{
			foreach (DataGridViewRow selectedRow in _0024VB_0024Local_NDataGridView.SelectedRows)
			{
				_0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", selectedRow.Cells["id"].Value), "'")))[0]["check"] = true;
			}
			_0024VB_0024Local_NDataGridView.DataSource = _0024VB_0024Local_NDataTable;
		}

		[SpecialName]
		internal void _Lambda_0024__14(object sender, EventArgs e)
		{
			foreach (DataGridViewRow selectedRow in _0024VB_0024Local_NDataGridView.SelectedRows)
			{
				_0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", selectedRow.Cells["id"].Value), "'")))[0]["check"] = false;
			}
			_0024VB_0024Local_NDataGridView.DataSource = _0024VB_0024Local_NDataTable;
		}

		[SpecialName]
		internal void _Lambda_0024__15(object sender, EventArgs e)
		{
			try
			{
				foreach (DataRow row in _0024VB_0024Local_NDataTable.Rows)
				{
					row["check"] = !Conversions.ToBoolean(row["check"].ToString());
				}
				_0024VB_0024Local_NDataGridView.DataSource = _0024VB_0024Local_NDataTable;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__16(object sender, EventArgs e)
		{
			_Closure_0024__58_002D3 arg = default(_Closure_0024__58_002D3);
			_Closure_0024__58_002D3 CS_0024_003C_003E8__locals8 = new _Closure_0024__58_002D3(arg);
			CS_0024_003C_003E8__locals8._0024VB_0024NonLocal__0024VB_0024Closure_4 = this;
			CS_0024_003C_003E8__locals8._0024VB_0024Local_v = new Frm_Edit
			{
				Text = "添加账号"
			};
			DataRow dataRow = _0024VB_0024Local_NDataTable.NewRow();
			int num = 1;
			checked
			{
				foreach (DataGridViewColumn column in _0024VB_0024Local_NDataGridView.Columns)
				{
					Label label = new Label();
					CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(label);
					Label label2 = label;
					if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0)
					{
						label2.Text = "选择";
					}
					else
					{
						label2.Text = column.HeaderText;
					}
					label2.Left = 12;
					label2.Top = num * 25;
					label2.AutoSize = true;
					label2 = null;
					if (Operators.CompareString(column.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
					{
						CheckBox checkBox = new CheckBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(checkBox);
						CheckBox checkBox2 = checkBox;
						if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) == 0)
						{
							checkBox2.Enabled = false;
						}
						checkBox2.Checked = false;
						checkBox2.Text = "";
						checkBox2.Left = 96;
						checkBox2.Top = num * 25 - 3;
						checkBox2.Name = column.DataPropertyName;
						checkBox2 = null;
					}
					else
					{
						TextBox textBox = new TextBox();
						CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Controls.Add(textBox);
						TextBox textBox2 = textBox;
						if (Operators.CompareString(column.DataPropertyName, "id", TextCompare: false) == 0)
						{
							textBox2.Enabled = false;
						}
						textBox2.Text = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow[column.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(dataRow[column.DataPropertyName])));
						textBox2.Name = column.DataPropertyName;
						textBox2.Left = 96;
						textBox2.Top = num * 25 - 3;
						textBox2 = null;
					}
					num++;
				}
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
				{
					CS_0024_003C_003E8__locals8._Lambda_0024__17(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
				};
				CS_0024_003C_003E8__locals8._0024VB_0024Local_v.ShowDialog();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__18(object sender, EventArgs e)
		{
			DataRow[] array = _0024VB_0024Local_NDataTable.Select("check=true");
			int num = array.Length;
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					string text = "";
					if (!_0024VB_0024Local_Run(string.Format("DELETE FROM {0} WHERE {1}", _0024VB_0024Local_DbName, Operators.ConcatenateObject("id = ", array[i - 1]["id"])), text))
					{
						MessageBox.Show(text, "修改过程中出现错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				_0024VB_0024Local_ResList();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__19(object sender, EventArgs e)
		{
			Form_EditDB form_EditDB = new Form_EditDB();
			form_EditDB.Text = "修改表结构";
			form_EditDB.DbName = _0024VB_0024Local_DbName;
			form_EditDB.Show();
		}

		[SpecialName]
		internal void _Lambda_0024__20(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = _0024VB_0024Me.vmethod_8();
			openFileDialog.Title = "选择要导入的Excel文件";
			openFileDialog.FileName = "";
			openFileDialog.Filter = "Excel 文件 (*.xls)|*.xls";
			openFileDialog.FilterIndex = 0;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ShowDialog();
			if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
			{
				openFileDialog = null;
				if (Operators.CompareString(_0024VB_0024Me.vmethod_8().FileName, "", TextCompare: false) != 0)
				{
					new Excel_class(Class9.oleDbConnection_0, _0024VB_0024Me.vmethod_8().FileName).Import(_0024VB_0024Local_DbName);
				}
				_0024VB_0024Local_ResList();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__21(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = _0024VB_0024Me.vmethod_4();
			saveFileDialog.Title = "选择要导出的Excel文件位置";
			saveFileDialog.FileName = "";
			saveFileDialog.Filter = "Excel 文件 (*.xls)|*.xls|所有文件 (*.*)|*.*";
			saveFileDialog.FilterIndex = 0;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowDialog();
			if (Operators.CompareString(saveFileDialog.FileName, "", TextCompare: false) != 0)
			{
				new Excel_class(Class9.oleDbConnection_0, saveFileDialog.FileName).Export($"SELECT * FROM {_0024VB_0024Local_DbName}");
			}
			saveFileDialog = null;
		}

		[SpecialName]
		internal void _Lambda_0024__22(object sender, EventArgs e)
		{
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			List<int> list = new List<int>();
			SaveFileDialog saveFileDialog = _0024VB_0024Me.vmethod_4();
			saveFileDialog.Title = "选择要导出的Excel文件位置";
			saveFileDialog.FileName = "";
			saveFileDialog.Filter = "Excel 文件 (*.xls)|*.xls|所有文件 (*.*)|*.*";
			saveFileDialog.FilterIndex = 0;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowDialog();
			checked
			{
				if (Operators.CompareString(saveFileDialog.FileName, "", TextCompare: false) != 0)
				{
					try
					{
						foreach (DataRow row in _0024VB_0024Local_NDataTable.Rows)
						{
							if (!Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row["check"])) && Conversions.ToBoolean(row["check"]))
							{
								list.Add(Conversions.ToInteger(row["id"]));
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					try
					{
						XlsDocument val = new XlsDocument();
						val.FileName = saveFileDialog.FileName;
						Worksheet val2 = val.Workbook.Worksheets.Add("sheet1");
						using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"SELECT * FROM {_0024VB_0024Local_DbName}", Class9.oleDbConnection_0);
						using DataSet dataSet = new DataSet();
						oleDbDataAdapter.Fill(dataSet);
						if (dataSet.Tables.Count > 0)
						{
							int count = dataSet.Tables[0].Columns.Count;
							for (int i = 1; i <= count; i++)
							{
								val2.Cells.Add(1, i, (object)dataSet.Tables[0].Columns[i - 1].Caption.ToString());
							}
							int num = 2;
							int num2 = dataSet.Tables[0].Rows.Count + 1;
							for (int j = 2; j <= num2; j++)
							{
								if (list.Contains(Conversions.ToInteger(dataSet.Tables[0].Rows[j - 2]["id"])))
								{
									int count2 = dataSet.Tables[0].Columns.Count;
									for (int k = 1; k <= count2; k++)
									{
										val2.Cells.Add(num, k, (object)dataSet.Tables[0].Rows[j - 2][k - 1].ToString());
									}
									num++;
								}
							}
							val.Save();
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						MessageBox.Show(ex2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
				saveFileDialog = null;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D1
	{
		public Frm_Edit _0024VB_0024Local_v;

		public _Closure_0024__58_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__58_002D1(_Closure_0024__58_002D1 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_v = arg0._0024VB_0024Local_v;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R22(object sender, EventArgs e)
		{
			_Lambda_0024__6(RuntimeHelpers.GetObjectValue(sender), (MouseEventArgs)e);
		}

		[SpecialName]
		internal void _Lambda_0024__6(object sender, MouseEventArgs e)
		{
			string arg = "";
			string text = "";
			checked
			{
				foreach (Control control in _0024VB_0024Local_v.Controls)
				{
					if (control is TextBox)
					{
						if (Operators.CompareString(control.Name, "id", TextCompare: false) == 0)
						{
							arg = "id = " + control.Text;
						}
						else if (control.Enabled)
						{
							text += $"{control.Name} = '{control.Text}'";
							if (_0024VB_0024Local_v.Controls.GetChildIndex(control) + 1 != _0024VB_0024Local_v.Controls.Count)
							{
								text += " , ";
							}
						}
					}
					if (control is CheckBox && control.Enabled)
					{
						CheckBox checkBox = (CheckBox)control;
						text += $"{control.Name} = '{Conversions.ToString(checkBox.Checked).ToLower()}'";
						if (_0024VB_0024Local_v.Controls.GetChildIndex(control) + 1 != _0024VB_0024Local_v.Controls.Count)
						{
							text += " , ";
						}
					}
				}
				string text2 = "";
				if (!_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Run($"Update `{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_DbName}` Set {text} Where {arg}", text2))
				{
					MessageBox.Show(text2, "修改过程中出现错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ResList();
				}
				_0024VB_0024Local_v.Close();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D2
	{
		public Frm_Edit _0024VB_0024Local_v;

		public _Closure_0024__58_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__58_002D2(_Closure_0024__58_002D2 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_v = arg0._0024VB_0024Local_v;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R23(object sender, EventArgs e)
		{
			_Lambda_0024__12(RuntimeHelpers.GetObjectValue(sender), (MouseEventArgs)e);
		}

		[SpecialName]
		internal void _Lambda_0024__12(object sender, MouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				new JArray();
				foreach (DataRow row in _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_NDataTable.Rows)
				{
					if (Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row["check"])) || !Conversions.ToBoolean(row["check"]))
					{
						continue;
					}
					string text = "";
					text = text + "id = " + row["id"].ToString();
					string text2 = "";
					foreach (Control control in _0024VB_0024Local_v.Controls)
					{
						if (control.Enabled)
						{
							if (control is TextBox && Operators.CompareString(control.Text, "(原值)", TextCompare: false) != 0)
							{
								text2 += $"{control.Name} = '{control.Text}'";
								text2 += " , ";
							}
							if (control is CheckBox)
							{
								CheckBox checkBox = (CheckBox)control;
								text2 += $"{control.Name} = '{Conversions.ToString(checkBox.Checked).ToLower()}'";
								text2 += " , ";
							}
						}
					}
					text2 = Strings.Mid(text2, 1, checked(Strings.Len(text2) - 3));
					string text3 = "";
					if (!_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Run($"Update `{_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_DbName}` Set {text2} Where {text}", text3))
					{
						MessageBox.Show(text3, "修改过程中出现错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ResList();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			_0024VB_0024Local_v.Close();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D3
	{
		public Frm_Edit _0024VB_0024Local_v;

		public _Closure_0024__58_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

		public _Closure_0024__58_002D3(_Closure_0024__58_002D3 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_v = arg0._0024VB_0024Local_v;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R24(object sender, EventArgs e)
		{
			_Lambda_0024__17(RuntimeHelpers.GetObjectValue(sender), (MouseEventArgs)e);
		}

		[SpecialName]
		internal void _Lambda_0024__17(object sender, MouseEventArgs e)
		{
			string text = "";
			string text2 = "";
			checked
			{
				foreach (Control control in _0024VB_0024Local_v.Controls)
				{
					if (!control.Enabled)
					{
						continue;
					}
					if (control is TextBox)
					{
						text2 += control.Name;
						text += $"'{control.Text}'";
						if (_0024VB_0024Local_v.Controls.GetChildIndex(control) + 1 != _0024VB_0024Local_v.Controls.Count)
						{
							text2 += " , ";
							text += " , ";
						}
					}
					else if (control is CheckBox)
					{
						CheckBox checkBox = (CheckBox)control;
						text2 += control.Name;
						text += $"'{Conversions.ToString(checkBox.Checked).ToLower()}'";
						if (_0024VB_0024Local_v.Controls.GetChildIndex(control) + 1 != _0024VB_0024Local_v.Controls.Count)
						{
							text2 += " , ";
							text += " , ";
						}
					}
				}
				string text3 = "";
				if (!_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_Run($"INSERT INTO {_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_DbName} ({text2}) VALUES ({text})", text3))
				{
					MessageBox.Show(text3, "修改过程中出现错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_ResList();
				}
				_0024VB_0024Local_v.Close();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__62_002D0
	{
		public JArray _0024VB_0024Local_list;

		public Form_ChangeName _0024VB_0024Local_cn;

		public _Closure_0024__62_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Class8.smethod_27(_0024VB_0024Local_list, _0024VB_0024Local_cn.TextBox1.Text);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__74_002D0
	{
		public JProperty _0024VB_0024Local__devices;

		public Form_Main_t _0024VB_0024Me;

		public _Closure_0024__74_002D0(_Closure_0024__74_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local__devices = arg0._0024VB_0024Local__devices;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R25(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Expected O, but got Unknown
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Expected O, but got Unknown
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Expected O, but got Unknown
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Expected O, but got Unknown
			new JArray();
			JArray val = (JArray)_0024VB_0024Local__devices.Value;
			DataRow[] array = Class9.dataTable_0.Select("check=True");
			foreach (DataRow dataRow in array)
			{
				bool flag = false;
				foreach (JObject item in ((JContainer)val).Children())
				{
					if (Operators.ConditionalCompareObjectEqual(item["deviceid"], dataRow["deviceid"], TextCompare: false))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					val.Add((JToken)new JObject(new object[12]
					{
						(object)new JProperty("ip", RuntimeHelpers.GetObjectValue(dataRow["ip"])),
						(object)new JProperty("port", RuntimeHelpers.GetObjectValue(dataRow["port"])),
						(object)new JProperty("devname", RuntimeHelpers.GetObjectValue(dataRow["devname"])),
						(object)new JProperty("deviceid", RuntimeHelpers.GetObjectValue(dataRow["deviceid"])),
						(object)new JProperty("devmac", RuntimeHelpers.GetObjectValue(dataRow["devmac"])),
						(object)new JProperty("devsn", RuntimeHelpers.GetObjectValue(dataRow["devsn"])),
						(object)new JProperty("devtype", RuntimeHelpers.GetObjectValue(dataRow["devtype"])),
						(object)new JProperty("zeversion", RuntimeHelpers.GetObjectValue(dataRow["zeversion"])),
						(object)new JProperty("sysversion", RuntimeHelpers.GetObjectValue(dataRow["sysversion"])),
						(object)new JProperty("boardconfig", RuntimeHelpers.GetObjectValue(Interaction.IIf(dataRow["boardconfig"] == null, "", RuntimeHelpers.GetObjectValue(dataRow["boardconfig"])))),
						(object)new JProperty("ecid", RuntimeHelpers.GetObjectValue(Interaction.IIf(dataRow["ecid"] == null, "", RuntimeHelpers.GetObjectValue(dataRow["ecid"])))),
						(object)new JProperty("buildid", RuntimeHelpers.GetObjectValue(Interaction.IIf(dataRow["buildid"] == null, "", RuntimeHelpers.GetObjectValue(dataRow["buildid"]))))
					}));
				}
			}
			_0024VB_0024Me.ResList();
			MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__82_002D0
	{
		public TableLayoutPanel _0024VB_0024Local_cfg_Panel;

		public string _0024VB_0024Local__file;

		public Form_Main_t _0024VB_0024Me;

		public _Closure_0024__82_002D0(_Closure_0024__82_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_cfg_Panel = arg0._0024VB_0024Local_cfg_Panel;
				_0024VB_0024Local__file = arg0._0024VB_0024Local__file;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R26(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Expected O, but got Unknown
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Invalid comparison between Unknown and I4
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Invalid comparison between Unknown and I4
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Invalid comparison between Unknown and I4
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Invalid comparison between Unknown and I4
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			JObject val = new JObject();
			TreeNode treeNode;
			checked
			{
				try
				{
					foreach (Control control in _0024VB_0024Local_cfg_Panel.Controls)
					{
						switch (control.GetType().ToString())
						{
						case "System.Windows.Forms.CheckedListBox":
						{
							CheckedListBox checkedListBox = (CheckedListBox)control;
							JArray val2 = new JArray();
							int count = checkedListBox.Items.Count;
							for (int i = 1; i <= count; i++)
							{
								if (checkedListBox.GetItemChecked(i - 1))
								{
									val2.Add(JToken.op_Implicit(i));
								}
							}
							((JContainer)val).Add((object)new JProperty(control.Name, (object)val2));
							break;
						}
						case "System.Windows.Forms.ListBox":
						{
							ListBox listBox = (ListBox)control;
							((JContainer)val).Add((object)new JProperty(control.Name, (object)(listBox.SelectedIndex + 1)));
							break;
						}
						case "System.Windows.Forms.ComboBox":
						{
							ComboBox comboBox = (ComboBox)control;
							((JContainer)val).Add((object)new JProperty(control.Name, (object)(comboBox.SelectedIndex + 1)));
							break;
						}
						case "System.Windows.Forms.TextBox":
							((JContainer)val).Add((object)new JProperty(control.Name, (object)control.Text));
							break;
						}
					}
					JObject val3 = JObject.Parse(File.ReadAllText(_0024VB_0024Local__file));
					val3["Config"] = (JToken)(object)val;
					File.WriteAllText(_0024VB_0024Local__file, JsonConvert.SerializeObject((object)val3));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				Class9.jobject_0 = val;
				if (_0024VB_0024Me.TreeView_Consultation.Nodes.Count != 2)
				{
					return;
				}
				treeNode = _0024VB_0024Me.TreeView_Consultation.Nodes[1];
				treeNode.Nodes.Clear();
			}
			foreach (JProperty item in ((JContainer)Class9.jobject_0).Children())
			{
				JProperty val4 = item;
				TreeNode treeNode2 = treeNode.Nodes.Add(val4.Name);
				if ((int)val4.Value.Type == 2)
				{
					foreach (JValue item2 in val4.Value.Children())
					{
						JValue val5 = item2;
						treeNode2.Nodes.Add(val5.ToString());
					}
				}
				else if ((int)val4.Value.Type == 9)
				{
					treeNode2.Nodes.Add(val4.Value.ToString());
				}
				else if (((int)val4.Value.Type == 8) | ((int)val4.Value.Type == 6))
				{
					treeNode2.Nodes.Add((string)val4.Value);
				}
			}
			treeNode.ExpandAll();
		}
	}

	private object object_0;

	private bool bool_0;

	private JArray jarray_0;

	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ContextMenuStrip_DeviceList")]
	private ContextMenuStrip contextMenuStrip_0;

	[CompilerGenerated]
	[AccessedThroughProperty("SearchToolStripMenuItem")]
	private ToolStripMenuItem _SearchToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView_DeviceList")]
	private DataGridView _DataGridView_DeviceList;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator toolStripSeparator_0;

	[AccessedThroughProperty("ToolStripSeparator3")]
	[CompilerGenerated]
	private ToolStripSeparator toolStripSeparator_1;

	[AccessedThroughProperty("ToolStripMenuItem_Clear")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_Clear;

	[AccessedThroughProperty("ToolStripButton_FindDevice")]
	[CompilerGenerated]
	private ToolStripSplitButton _ToolStripButton_FindDevice;

	[AccessedThroughProperty("ToolStripButton_OpenScript")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton_OpenScript;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton_Stop")]
	private ToolStripButton _ToolStripButton_Stop;

	[AccessedThroughProperty("ToolStripButton_CheckRunning")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton_CheckRunning;

	[AccessedThroughProperty("FindDevice_Udp")]
	[CompilerGenerated]
	private ToolStripMenuItem _FindDevice_Udp;

	[CompilerGenerated]
	[AccessedThroughProperty("_SaveFileDialog")]
	private SaveFileDialog saveFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton_SendScript")]
	private ToolStripSplitButton _ToolStripButton_SendScript;

	[AccessedThroughProperty("ToolStripButton_SendScript_Res")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripButton_SendScript_Res;

	[AccessedThroughProperty("ToolStripButton_SendScript_Lua")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripButton_SendScript_Lua;

	[AccessedThroughProperty("ToolStripButton_SendScript_Script")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripButton_SendScript_Script;

	[AccessedThroughProperty("ToolStripMenuItem_Check_Select")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_Check_Select;

	[AccessedThroughProperty("ToolStripMenuItem_Check_All")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_Check_All;

	[AccessedThroughProperty("ImageList_ListView")]
	[CompilerGenerated]
	private ImageList imageList_0;

	[AccessedThroughProperty("ToolStripMenuItem_UnCheck_Select")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_UnCheck_Select;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem_NotCheck_Select")]
	private ToolStripMenuItem _ToolStripMenuItem_NotCheck_Select;

	[AccessedThroughProperty("ToolStripMenuItem_OutDeviceID")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_OutDeviceID;

	[CompilerGenerated]
	[AccessedThroughProperty("_OpenFileDialog")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("NotifyIcon_Main")]
	[CompilerGenerated]
	private NotifyIcon notifyIcon_0;

	[AccessedThroughProperty("ToolStripMenuItem_ChangeName")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_ChangeName;

	[AccessedThroughProperty("修改屏幕亮度ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _修改屏幕亮度ToolStripMenuItem;

	[AccessedThroughProperty("修改手机音量ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _修改手机音量ToolStripMenuItem;

	[AccessedThroughProperty("用户偏好配置ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _用户偏好配置ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("API方式安装DEBToolStripMenuItem")]
	private ToolStripMenuItem _API方式安装DEBToolStripMenuItem;

	[AccessedThroughProperty("SSH方式安装IPAToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _SSH方式安装IPAToolStripMenuItem;

	[AccessedThroughProperty("SSH扫描功能ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _SSH扫描功能ToolStripMenuItem;

	[AccessedThroughProperty("检测授权ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _检测授权ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("批量授权ToolStripMenuItem1")]
	private ToolStripMenuItem _批量授权ToolStripMenuItem1;

	[AccessedThroughProperty("ToolStripButton_Run")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton_Run;

	[AccessedThroughProperty("关机ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _关机ToolStripMenuItem;

	[AccessedThroughProperty("重启ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _重启ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("注销ToolStripMenuItem")]
	private ToolStripMenuItem _注销ToolStripMenuItem;

	[AccessedThroughProperty("锁屏ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _锁屏ToolStripMenuItem;

	[AccessedThroughProperty("解锁ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _解锁ToolStripMenuItem;

	[AccessedThroughProperty("ToolStripComboBox_ScriptFile")]
	[CompilerGenerated]
	private ToolStripComboBox _ToolStripComboBox_ScriptFile;

	[AccessedThroughProperty("发送CClua至插件目录ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _发送CClua至插件目录ToolStripMenuItem;

	[AccessedThroughProperty("同步脚本ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _同步脚本ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton_ScriptInfo")]
	private ToolStripButton _ToolStripButton_ScriptInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton_Push")]
	private ToolStripButton _ToolStripButton_Push;

	[AccessedThroughProperty("IP端扫描ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _IP端扫描ToolStripMenuItem;

	[AccessedThroughProperty("IP导入ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _IP导入ToolStripMenuItem;

	[AccessedThroughProperty("ToolStripMenuItem_Show_Hide")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_Show_Hide;

	[AccessedThroughProperty("退出ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _退出ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem3")]
	private ToolStripMenuItem _ToolStripMenuItem3;

	[AccessedThroughProperty("ToolStripButton_Find_Device")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton_Find_Device;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	[CompilerGenerated]
	[AccessedThroughProperty("关于本软件ToolStripMenuItem")]
	private ToolStripMenuItem _关于本软件ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("关于XXTouchToolStripMenuItem")]
	private ToolStripMenuItem _关于XXTouchToolStripMenuItem;

	[AccessedThroughProperty("Timer_EditMessage")]
	[CompilerGenerated]
	private System.Windows.Forms.Timer timer_0;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("ToolStripMenuItem_OutDeviceID2")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_OutDeviceID2;

	[CompilerGenerated]
	[AccessedThroughProperty("分发数据至资源目录resToolStripMenuItem")]
	private ToolStripMenuItem _分发数据至资源目录resToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("删除选中设备ToolStripMenuItem")]
	private ToolStripMenuItem _删除选中设备ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("配置ToolStripMenuItem")]
	private ToolStripMenuItem _配置ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("通讯APICCluaToolStripMenuItem")]
	private ToolStripMenuItem _通讯APICCluaToolStripMenuItem;

	[AccessedThroughProperty("创建中控UIToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _创建中控UIToolStripMenuItem;

	[AccessedThroughProperty("导出勾选的设备IPToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _导出勾选的设备IPToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("创建新的数据表ToolStripMenuItem")]
	private ToolStripMenuItem _创建新的数据表ToolStripMenuItem;

	[AccessedThroughProperty("TreeView_Consultation")]
	[CompilerGenerated]
	private TreeView _TreeView_Consultation;

	[CompilerGenerated]
	[AccessedThroughProperty("添加设备分组ToolStripMenuItem")]
	private ToolStripMenuItem _添加设备分组ToolStripMenuItem;

	[AccessedThroughProperty("修改设备组名ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _修改设备组名ToolStripMenuItem;

	[AccessedThroughProperty("删除此设备组ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _删除此设备组ToolStripMenuItem;

	[AccessedThroughProperty("ToolStripButton_pause")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton_pause;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton2")]
	private ToolStripButton _ToolStripButton2;

	[AccessedThroughProperty("备份SHSH2ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _备份SHSH2ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem5")]
	private ToolStripMenuItem _ToolStripMenuItem5;

	internal virtual ToolStripMenuItem SearchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SearchToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			ToolStripMenuItem toolStripMenuItem = _SearchToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_SearchToolStripMenuItem = value;
			toolStripMenuItem = _SearchToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("StatusStrip_Main")]
	internal virtual StatusStrip StatusStrip_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripContainer_Main")]
	internal virtual ToolStripContainer ToolStripContainer_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabControl_Main")]
	internal virtual TabControl TabControl_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage_DataGridView")]
	internal virtual TabPage TabPage_DataGridView
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridView DataGridView_DeviceList
	{
		[CompilerGenerated]
		get
		{
			return _DataGridView_DeviceList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = method_60;
			DataGridViewCellMouseEventHandler value3 = method_61;
			EventHandler value4 = method_62;
			DataGridViewCellEventHandler value5 = method_63;
			EventHandler value6 = method_64;
			DataGridViewCellMouseEventHandler value7 = method_65;
			MouseEventHandler value8 = method_66;
			DataGridViewSortCompareEventHandler value9 = method_67;
			DataGridView dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick -= value2;
				dataGridView.CellMouseUp -= value3;
				dataGridView.CurrentCellDirtyStateChanged -= value4;
				dataGridView.CellClick -= value5;
				dataGridView.DoubleClick -= value6;
				dataGridView.CellMouseDoubleClick -= value7;
				dataGridView.MouseUp -= value8;
				dataGridView.SortCompare -= value9;
			}
			_DataGridView_DeviceList = value;
			dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick += value2;
				dataGridView.CellMouseUp += value3;
				dataGridView.CurrentCellDirtyStateChanged += value4;
				dataGridView.CellClick += value5;
				dataGridView.DoubleClick += value6;
				dataGridView.CellMouseDoubleClick += value7;
				dataGridView.MouseUp += value8;
				dataGridView.SortCompare += value9;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Clear
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Clear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_59;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Clear;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Clear = value;
			toolStripMenuItem = _ToolStripMenuItem_Clear;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage_Data")]
	internal virtual TabPage TabPage_Data
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabControl_Data")]
	internal virtual TabControl TabControl_Data
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStrip_Main")]
	internal virtual ToolStrip ToolStrip_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripSplitButton ToolStripButton_FindDevice
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_FindDevice;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			ToolStripSplitButton toolStripSplitButton = _ToolStripButton_FindDevice;
			if (toolStripSplitButton != null)
			{
				toolStripSplitButton.ButtonClick -= value2;
			}
			_ToolStripButton_FindDevice = value;
			toolStripSplitButton = _ToolStripButton_FindDevice;
			if (toolStripSplitButton != null)
			{
				toolStripSplitButton.ButtonClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator7")]
	internal virtual ToolStripSeparator ToolStripSeparator7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton ToolStripButton_OpenScript
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_OpenScript;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_17;
			ToolStripButton toolStripButton = _ToolStripButton_OpenScript;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_OpenScript = value;
			toolStripButton = _ToolStripButton_OpenScript;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator8")]
	internal virtual ToolStripSeparator ToolStripSeparator8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton ToolStripButton_Stop
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_Stop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_27;
			ToolStripButton toolStripButton = _ToolStripButton_Stop;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_Stop = value;
			toolStripButton = _ToolStripButton_Stop;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator9")]
	internal virtual ToolStripSeparator ToolStripSeparator9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton ToolStripButton_CheckRunning
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_CheckRunning;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_29;
			ToolStripButton toolStripButton = _ToolStripButton_CheckRunning;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_CheckRunning = value;
			toolStripButton = _ToolStripButton_CheckRunning;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem FindDevice_Udp
	{
		[CompilerGenerated]
		get
		{
			return _FindDevice_Udp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			ToolStripMenuItem toolStripMenuItem = _FindDevice_Udp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_FindDevice_Udp = value;
			toolStripMenuItem = _FindDevice_Udp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSplitButton ToolStripButton_SendScript
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_SendScript;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_18;
			ToolStripSplitButton toolStripSplitButton = _ToolStripButton_SendScript;
			if (toolStripSplitButton != null)
			{
				toolStripSplitButton.ButtonClick -= value2;
			}
			_ToolStripButton_SendScript = value;
			toolStripSplitButton = _ToolStripButton_SendScript;
			if (toolStripSplitButton != null)
			{
				toolStripSplitButton.ButtonClick += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripButton_SendScript_Res
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_SendScript_Res;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_21;
			ToolStripMenuItem toolStripMenuItem = _ToolStripButton_SendScript_Res;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripButton_SendScript_Res = value;
			toolStripMenuItem = _ToolStripButton_SendScript_Res;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripButton_SendScript_Lua
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_SendScript_Lua;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_22;
			ToolStripMenuItem toolStripMenuItem = _ToolStripButton_SendScript_Lua;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripButton_SendScript_Lua = value;
			toolStripMenuItem = _ToolStripButton_SendScript_Lua;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripButton_SendScript_Script
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_SendScript_Script;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_20;
			ToolStripMenuItem toolStripMenuItem = _ToolStripButton_SendScript_Script;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripButton_SendScript_Script = value;
			toolStripMenuItem = _ToolStripButton_SendScript_Script;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Check_Select
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Check_Select;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_52;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Check_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Check_Select = value;
			toolStripMenuItem = _ToolStripMenuItem_Check_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Check_All
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Check_All;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_54;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Check_All;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Check_All = value;
			toolStripMenuItem = _ToolStripMenuItem_Check_All;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripSeparator4")]
	internal virtual ToolStripSeparator ToolStripSeparator4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem_Group")]
	internal virtual ToolStripMenuItem ToolStripMenuItem_Group
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_SelectDeviceNum")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_SelectDeviceNum
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_CheckDeviceNum")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_CheckDeviceNum
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_UnCheck_Select
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_UnCheck_Select;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_53;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_UnCheck_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_UnCheck_Select = value;
			toolStripMenuItem = _ToolStripMenuItem_UnCheck_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_NotCheck_Select
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_NotCheck_Select;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rlcmBeEcdE;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_NotCheck_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_NotCheck_Select = value;
			toolStripMenuItem = _ToolStripMenuItem_NotCheck_Select;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator5")]
	internal virtual ToolStripSeparator ToolStripSeparator5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripSeparator6")]
	internal virtual ToolStripSeparator ToolStripSeparator6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_OutDeviceID
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_OutDeviceID;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_55;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_OutDeviceID;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_OutDeviceID = value;
			toolStripMenuItem = _ToolStripMenuItem_OutDeviceID;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("MenuStrip_Main")]
	internal virtual MenuStrip MenuStrip_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_UISet")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_UISet
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripButton_VersionChecking")]
	internal virtual ToolStripDropDownButton ToolStripButton_VersionChecking
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_ChangeName
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_ChangeName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_51;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_ChangeName;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_ChangeName = value;
			toolStripMenuItem = _ToolStripMenuItem_ChangeName;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 修改屏幕亮度ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _修改屏幕亮度ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_41;
			ToolStripMenuItem toolStripMenuItem = _修改屏幕亮度ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_修改屏幕亮度ToolStripMenuItem = value;
			toolStripMenuItem = _修改屏幕亮度ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 修改手机音量ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _修改手机音量ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_42;
			ToolStripMenuItem toolStripMenuItem = _修改手机音量ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_修改手机音量ToolStripMenuItem = value;
			toolStripMenuItem = _修改手机音量ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 用户偏好配置ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _用户偏好配置ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_43;
			ToolStripMenuItem toolStripMenuItem = _用户偏好配置ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_用户偏好配置ToolStripMenuItem = value;
			toolStripMenuItem = _用户偏好配置ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("XXTouch授权ToolStripMenuItem")]
	internal virtual ToolStripMenuItem XXTouch授权ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("安装应用或插件ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 安装应用或插件ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem API方式安装DEBToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _API方式安装DEBToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_33;
			ToolStripMenuItem toolStripMenuItem = _API方式安装DEBToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_API方式安装DEBToolStripMenuItem = value;
			toolStripMenuItem = _API方式安装DEBToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem SSH方式安装IPAToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SSH方式安装IPAToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_34;
			ToolStripMenuItem toolStripMenuItem = _SSH方式安装IPAToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_SSH方式安装IPAToolStripMenuItem = value;
			toolStripMenuItem = _SSH方式安装IPAToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem SSH扫描功能ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SSH扫描功能ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_35;
			ToolStripMenuItem toolStripMenuItem = _SSH扫描功能ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_SSH扫描功能ToolStripMenuItem = value;
			toolStripMenuItem = _SSH扫描功能ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 检测授权ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _检测授权ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_31;
			ToolStripMenuItem toolStripMenuItem = _检测授权ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_检测授权ToolStripMenuItem = value;
			toolStripMenuItem = _检测授权ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 批量授权ToolStripMenuItem1
	{
		[CompilerGenerated]
		get
		{
			return _批量授权ToolStripMenuItem1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_32;
			ToolStripMenuItem toolStripMenuItem = _批量授权ToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_批量授权ToolStripMenuItem1 = value;
			toolStripMenuItem = _批量授权ToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton_Run
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_Run;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_25;
			ToolStripButton toolStripButton = _ToolStripButton_Run;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_Run = value;
			toolStripButton = _ToolStripButton_Run;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripMenuItem1")]
	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 关机ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _关机ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_36;
			ToolStripMenuItem toolStripMenuItem = _关机ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_关机ToolStripMenuItem = value;
			toolStripMenuItem = _关机ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 重启ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _重启ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_37;
			ToolStripMenuItem toolStripMenuItem = _重启ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_重启ToolStripMenuItem = value;
			toolStripMenuItem = _重启ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 注销ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _注销ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_38;
			ToolStripMenuItem toolStripMenuItem = _注销ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_注销ToolStripMenuItem = value;
			toolStripMenuItem = _注销ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripMenuItem2")]
	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 锁屏ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _锁屏ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_40;
			ToolStripMenuItem toolStripMenuItem = _锁屏ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_锁屏ToolStripMenuItem = value;
			toolStripMenuItem = _锁屏ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 解锁ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _解锁ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_39;
			ToolStripMenuItem toolStripMenuItem = _解锁ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_解锁ToolStripMenuItem = value;
			toolStripMenuItem = _解锁ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripComboBox ToolStripComboBox_ScriptFile
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripComboBox_ScriptFile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = method_11;
			DragEventHandler value3 = method_12;
			EventHandler value4 = method_13;
			EventHandler value5 = method_14;
			ToolStripComboBox toolStripComboBox = _ToolStripComboBox_ScriptFile;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.DragEnter -= value2;
				toolStripComboBox.DragDrop -= value3;
				toolStripComboBox.DropDown -= value4;
				toolStripComboBox.TextChanged -= value5;
			}
			_ToolStripComboBox_ScriptFile = value;
			toolStripComboBox = _ToolStripComboBox_ScriptFile;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.DragEnter += value2;
				toolStripComboBox.DragDrop += value3;
				toolStripComboBox.DropDown += value4;
				toolStripComboBox.TextChanged += value5;
			}
		}
	}

	internal virtual ToolStripMenuItem 发送CClua至插件目录ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _发送CClua至插件目录ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_23;
			ToolStripMenuItem toolStripMenuItem = _发送CClua至插件目录ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_发送CClua至插件目录ToolStripMenuItem = value;
			toolStripMenuItem = _发送CClua至插件目录ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 同步脚本ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _同步脚本ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_19;
			ToolStripMenuItem toolStripMenuItem = _同步脚本ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_同步脚本ToolStripMenuItem = value;
			toolStripMenuItem = _同步脚本ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton_ScriptInfo
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_ScriptInfo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_15;
			ToolStripButton toolStripButton = _ToolStripButton_ScriptInfo;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_ScriptInfo = value;
			toolStripButton = _ToolStripButton_ScriptInfo;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton_Push
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_Push;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_16;
			ToolStripButton toolStripButton = _ToolStripButton_Push;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_Push = value;
			toolStripButton = _ToolStripButton_Push;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem IP端扫描ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _IP端扫描ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_9;
			ToolStripMenuItem toolStripMenuItem = _IP端扫描ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_IP端扫描ToolStripMenuItem = value;
			toolStripMenuItem = _IP端扫描ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem IP导入ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _IP导入ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_10;
			ToolStripMenuItem toolStripMenuItem = _IP导入ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_IP导入ToolStripMenuItem = value;
			toolStripMenuItem = _IP导入ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ContextMenuStrip_NotifyIcon")]
	internal virtual ContextMenuStrip ContextMenuStrip_NotifyIcon
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Show_Hide
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Show_Hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = whLbnrbQhi;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Show_Hide;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Show_Hide = value;
			toolStripMenuItem = _ToolStripMenuItem_Show_Hide;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator10")]
	internal virtual ToolStripSeparator ToolStripSeparator10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 退出ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _退出ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_2;
			ToolStripMenuItem toolStripMenuItem = _退出ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_退出ToolStripMenuItem = value;
			toolStripMenuItem = _退出ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_56;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem3 = value;
			toolStripMenuItem = _ToolStripMenuItem3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_Port")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_Port
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton ToolStripButton_Find_Device
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_Find_Device;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_28;
			ToolStripButton toolStripButton = _ToolStripButton_Find_Device;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_Find_Device = value;
			toolStripButton = _ToolStripButton_Find_Device;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("关于ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 关于ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 关于本软件ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _关于本软件ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_7;
			ToolStripMenuItem toolStripMenuItem = _关于本软件ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_关于本软件ToolStripMenuItem = value;
			toolStripMenuItem = _关于本软件ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 关于XXTouchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _关于XXTouchToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BePbxOdtil;
			ToolStripMenuItem toolStripMenuItem = _关于XXTouchToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_关于XXTouchToolStripMenuItem = value;
			toolStripMenuItem = _关于XXTouchToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_24;
			ToolStripButton toolStripButton = _ToolStripButton1;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton1 = value;
			toolStripButton = _ToolStripButton1;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_OutDeviceID2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_OutDeviceID2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_57;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_OutDeviceID2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_OutDeviceID2 = value;
			toolStripMenuItem = _ToolStripMenuItem_OutDeviceID2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 分发数据至资源目录resToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _分发数据至资源目录resToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bUtmgiaAf2;
			ToolStripMenuItem toolStripMenuItem = _分发数据至资源目录resToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_分发数据至资源目录resToolStripMenuItem = value;
			toolStripMenuItem = _分发数据至资源目录resToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 删除选中设备ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _删除选中设备ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_58;
			ToolStripMenuItem toolStripMenuItem = _删除选中设备ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_删除选中设备ToolStripMenuItem = value;
			toolStripMenuItem = _删除选中设备ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("软件ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 软件ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 配置ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _配置ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			ToolStripMenuItem toolStripMenuItem = _配置ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_配置ToolStripMenuItem = value;
			toolStripMenuItem = _配置ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator11")]
	internal virtual ToolStripSeparator ToolStripSeparator11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 通讯APICCluaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _通讯APICCluaToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_4;
			ToolStripMenuItem toolStripMenuItem = _通讯APICCluaToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_通讯APICCluaToolStripMenuItem = value;
			toolStripMenuItem = _通讯APICCluaToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("项目ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 项目ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 创建中控UIToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _创建中控UIToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rbRbcgjweK;
			ToolStripMenuItem toolStripMenuItem = _创建中控UIToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_创建中控UIToolStripMenuItem = value;
			toolStripMenuItem = _创建中控UIToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("设备ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 设备ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("数据库ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 数据库ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 导出勾选的设备IPToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _导出勾选的设备IPToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_5;
			ToolStripMenuItem toolStripMenuItem = _导出勾选的设备IPToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_导出勾选的设备IPToolStripMenuItem = value;
			toolStripMenuItem = _导出勾选的设备IPToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 创建新的数据表ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _创建新的数据表ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_6;
			ToolStripMenuItem toolStripMenuItem = _创建新的数据表ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_创建新的数据表ToolStripMenuItem = value;
			toolStripMenuItem = _创建新的数据表ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual TreeView TreeView_Consultation
	{
		[CompilerGenerated]
		get
		{
			return _TreeView_Consultation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = method_70;
			TreeViewEventHandler value3 = method_71;
			TreeView treeView = _TreeView_Consultation;
			if (treeView != null)
			{
				treeView.MouseDown -= value2;
				treeView.AfterSelect -= value3;
			}
			_TreeView_Consultation = value;
			treeView = _TreeView_Consultation;
			if (treeView != null)
			{
				treeView.MouseDown += value2;
				treeView.AfterSelect += value3;
			}
		}
	}

	[field: AccessedThroughProperty("ContextMenuStrip_DeviceGroups")]
	internal virtual ContextMenuStrip ContextMenuStrip_DeviceGroups
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 添加设备分组ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _添加设备分组ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_72;
			ToolStripMenuItem toolStripMenuItem = _添加设备分组ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_添加设备分组ToolStripMenuItem = value;
			toolStripMenuItem = _添加设备分组ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 修改设备组名ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _修改设备组名ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_73;
			ToolStripMenuItem toolStripMenuItem = _修改设备组名ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_修改设备组名ToolStripMenuItem = value;
			toolStripMenuItem = _修改设备组名ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 删除此设备组ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _删除此设备组ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_74;
			ToolStripMenuItem toolStripMenuItem = _删除此设备组ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_删除此设备组ToolStripMenuItem = value;
			toolStripMenuItem = _删除此设备组ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainer2")]
	internal virtual SplitContainer SplitContainer2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton ToolStripButton_pause
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton_pause;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QlFmpoukVp;
			ToolStripButton toolStripButton = _ToolStripButton_pause;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton_pause = value;
			toolStripButton = _ToolStripButton_pause;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_26;
			ToolStripButton toolStripButton = _ToolStripButton2;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_ToolStripButton2 = value;
			toolStripButton = _ToolStripButton2;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripMenuItem4")]
	internal virtual ToolStripMenuItem ToolStripMenuItem4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 备份SHSH2ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _备份SHSH2ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_44;
			ToolStripMenuItem toolStripMenuItem = _备份SHSH2ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_备份SHSH2ToolStripMenuItem = value;
			toolStripMenuItem = _备份SHSH2ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem5
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_75;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem5 = value;
			toolStripMenuItem = _ToolStripMenuItem5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator12")]
	internal virtual ToolStripSeparator ToolStripSeparator12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_Main_t()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_Main_t_Load;
		base.FormClosing += Form_Main_t_FormClosing;
		bool_0 = false;
		InitializeComponent();
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	private void Form_Main_t_Load(object sender, EventArgs e)
	{
		SplitContainer1.Panel2Collapsed = true;
		ToolStripButton_ScriptInfo.Visible = false;
		ToolStripButton_Push.Visible = false;
		ToolStripButton_Find_Device.Visible = false;
		ToolStripButton_CheckRunning.Visible = false;
		ToolStripButton_VersionChecking.Visible = false;
		通讯APICCluaToolStripMenuItem.Visible = false;
		关于ToolStripMenuItem.Visible = false;
		发送CClua至插件目录ToolStripMenuItem.Visible = false;
		项目ToolStripMenuItem.Visible = false;
		ToolStripComboBox_ScriptFile.AllowDrop = true;
		foreach (DataGridViewColumn column in DataGridView_DeviceList.Columns)
		{
			if (Operators.CompareString(column.DataPropertyName, "check", TextCompare: false) != 0)
			{
				column.SortMode = DataGridViewColumnSortMode.Automatic;
			}
		}
		method_0();
		try
		{
			Class9.nancyHost_0.Start();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show("当前无法监听" + Conversions.ToString(Class9.int_1) + "端口,请检测是否有其它软件冲突", "出了个错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.EndApp();
			ProjectData.ClearProjectError();
		}
		try
		{
			DataTable schema = Class9.oleDbConnection_0.GetSchema("Tables");
			foreach (DataRow row in schema.Rows)
			{
				if (Operators.CompareString(row[3].ToString(), "TABLE", TextCompare: false) == 0)
				{
					method_47(row[2].ToString());
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		try
		{
			ToolStripComboBox_ScriptFile.Text = (string)Class9.jobject_3["Choose"];
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			Class9.jobject_3["Choose"] = JToken.op_Implicit("");
			ProjectData.ClearProjectError();
		}
	}

	public void Check_jobj(ref JObject a)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		if (a == null)
		{
			a = new JObject();
		}
	}

	public void Check_jarr(ref JArray a)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		if (a == null)
		{
			a = new JArray();
		}
	}

	private void method_0()
	{
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
		//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Expected O, but got Unknown
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Invalid comparison between Unknown and I4
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Invalid comparison between Unknown and I4
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Invalid comparison between Unknown and I4
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Invalid comparison between Unknown and I4
		//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c68: Expected O, but got Unknown
		//IL_0c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c81: Expected O, but got Unknown
		//IL_0c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Expected O, but got Unknown
		//IL_0cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb3: Expected O, but got Unknown
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccc: Expected O, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Expected O, but got Unknown
		//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Expected O, but got Unknown
		//IL_0d11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Expected O, but got Unknown
		//IL_0d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d30: Expected O, but got Unknown
		//IL_0d62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d68: Expected O, but got Unknown
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Expected O, but got Unknown
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected O, but got Unknown
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		TreeNode treeNode;
		if (TreeView_Consultation.Nodes.Count > 0)
		{
			treeNode = TreeView_Consultation.Nodes[0];
			treeNode.Nodes.Clear();
		}
		else
		{
			treeNode = TreeView_Consultation.Nodes.Add("设备分组");
		}
		Check_jobj(ref Class9.jobject_3);
		JObject jobject_;
		JObject a = (JObject)(jobject_ = Class9.jobject_3)["DeviceTable"];
		Check_jobj(ref a);
		jobject_["DeviceTable"] = (JToken)(object)a;
		jobject_ = (JObject)(a = Class9.jobject_3)["Interface"];
		Check_jobj(ref jobject_);
		a["Interface"] = (JToken)(object)jobject_;
		if (Class9.jobject_3["Interface"][(object)"HideDbTab"] == null)
		{
			Class9.jobject_3["Interface"][(object)"HideDbTab"] = JToken.op_Implicit(false);
		}
		JToken val;
		object obj;
		JArray a2 = (JArray)(val = Class9.jobject_3["Interface"])[RuntimeHelpers.GetObjectValue(obj = "Column")];
		Check_jarr(ref a2);
		val[RuntimeHelpers.GetObjectValue(obj)] = (JToken)(object)a2;
		a2 = (JArray)(val = Class9.jobject_3["DeviceTable"])[RuntimeHelpers.GetObjectValue(obj = "Devices")];
		Check_jarr(ref a2);
		val[RuntimeHelpers.GetObjectValue(obj)] = (JToken)(object)a2;
		jobject_ = (JObject)(val = Class9.jobject_3["DeviceTable"])[RuntimeHelpers.GetObjectValue(obj = "DeviceGroups")];
		Check_jobj(ref jobject_);
		val[RuntimeHelpers.GetObjectValue(obj)] = (JToken)(object)jobject_;
		a = (JObject)(jobject_ = Class9.jobject_3)["Database"];
		Check_jobj(ref a);
		jobject_["Database"] = (JToken)(object)a;
		if (Class9.jobject_3["Choose"] == null)
		{
			Class9.jobject_3["Choose"] = JToken.op_Implicit("");
		}
		try
		{
			if ((bool)Class9.jobject_3["Interface"][(object)"HidePause"])
			{
				ToolStripButton_pause.Visible = false;
				ToolStripButton2.Visible = false;
			}
			else
			{
				ToolStripButton_pause.Visible = true;
				ToolStripButton2.Visible = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Class9.jobject_3["Interface"][(object)"HidePause"] = JToken.op_Implicit(true);
			ToolStripButton_pause.Visible = false;
			ToolStripButton2.Visible = false;
			ProjectData.ClearProjectError();
		}
		try
		{
			if ((bool)Class9.jobject_3["Interface"][(object)"HideDbTab"])
			{
				TabPage_Data.Parent = null;
			}
			else
			{
				TabPage_Data.Parent = TabControl_Main;
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			Class9.jobject_3["Interface"][(object)"HideDbTab"] = JToken.op_Implicit(false);
			TabPage_Data.Parent = TabControl_Main;
			ProjectData.ClearProjectError();
		}
		try
		{
			bool panel1Collapsed = (bool)Class9.jobject_3["Interface"][(object)"HideDeviceGroups"];
			SplitContainer2.Panel1Collapsed = panel1Collapsed;
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			Class9.jobject_3["Interface"][(object)"HideDeviceGroups"] = JToken.op_Implicit(false);
			SplitContainer2.Panel1Collapsed = false;
			ProjectData.ClearProjectError();
		}
		try
		{
			if ((bool)Class9.jobject_3["Interface"][(object)"HideConfig"])
			{
				if (TreeView_Consultation.Nodes.Count == 2)
				{
					TreeView_Consultation.Nodes.RemoveAt(1);
				}
			}
			else if (TreeView_Consultation.Nodes.Count != 2)
			{
				TreeView_Consultation.Nodes.Add("配置");
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			Class9.jobject_3["Interface"][(object)"HideConfig"] = JToken.op_Implicit(true);
			ProjectData.ClearProjectError();
		}
		try
		{
			JArray jarray_ = (JArray)Class9.jobject_3["Interface"][(object)"Column"];
			method_46(jarray_, (bool)Class9.jobject_3["Interface"][(object)"AutoSizeColumnsMode"]);
		}
		catch (Exception projectError5)
		{
			ProjectData.SetProjectError(projectError5);
			Class9.jobject_3["Interface"][(object)"Column"] = (JToken)new JArray((object)"devname");
			Class9.jobject_3["Interface"][(object)"AutoSizeColumnsMode"] = JToken.op_Implicit(true);
			method_46((JArray)Class9.jobject_3["Interface"][(object)"Column"], (bool)Class9.jobject_3["Interface"][(object)"AutoSizeColumnsMode"]);
			ProjectData.ClearProjectError();
		}
		ToolStripStatusLabel_Port.Text = "端口:" + Conversions.ToString(Class9.int_1);
		if (TreeView_Consultation.Nodes.Count == 2)
		{
			TreeNode treeNode2 = TreeView_Consultation.Nodes[1];
			treeNode2.Nodes.Clear();
			foreach (JProperty item in ((JContainer)Class9.jobject_0).Children())
			{
				JProperty val2 = item;
				TreeNode treeNode3 = treeNode2.Nodes.Add(val2.Name);
				if ((int)val2.Value.Type == 2)
				{
					foreach (JValue item2 in val2.Value.Children())
					{
						JValue val3 = item2;
						treeNode3.Nodes.Add(val3.ToString());
					}
				}
				else if ((int)val2.Value.Type == 9)
				{
					treeNode3.Nodes.Add(val2.Value.ToString());
				}
				else if (((int)val2.Value.Type == 8) | ((int)val2.Value.Type == 6))
				{
					treeNode3.Nodes.Add((string)val2.Value);
				}
			}
			treeNode2.ExpandAll();
		}
		treeNode.Nodes.Add("全部设备");
		try
		{
			foreach (JObject item3 in Class9.jobject_3["DeviceTable"][(object)"Devices"].Children())
			{
				JObject val4 = item3;
				DataRow dataRow = Class9.dataTable_0.NewRow();
				dataRow["check"] = false;
				dataRow["ip"] = val4["ip"].ToString();
				string[] array = (string[])NewLateBinding.LateGet(dataRow["ip"], null, "Split", new object[1] { "." }, null, null, null);
				dataRow["_ip"] = Conversions.ToLong(array[0].PadLeft(3, '0') + array[1].PadLeft(3, '0') + array[2].PadLeft(3, '0') + array[3].PadLeft(3, '0'));
				dataRow["port"] = val4["port"].ToString();
				dataRow["devname"] = val4["devname"].ToString();
				dataRow["deviceid"] = val4["deviceid"].ToString();
				dataRow["devmac"] = val4["devmac"].ToString();
				dataRow["devsn"] = val4["devsn"].ToString();
				dataRow["devtype"] = val4["devtype"].ToString();
				dataRow["zeversion"] = val4["zeversion"].ToString();
				dataRow["sysversion"] = val4["sysversion"].ToString();
				dataRow["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["boardconfig"] == null, "", val4["boardconfig"]));
				dataRow["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["ecid"] == null, "", val4["ecid"]));
				dataRow["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["buildid"] == null, "", val4["buildid"]));
				Class9.dataTable_0.Rows.Add(dataRow);
			}
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (JProperty item4 in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"].Children())
			{
				string name = item4.Name;
				JArray val6 = (JArray)item4.Value;
				treeNode.Nodes.Add(name, name + "(" + Conversions.ToString(((JContainer)val6).Count) + ")");
				foreach (JToken item5 in ((JContainer)val6).Children())
				{
					if (Class9.dataTable_0.Rows.Find(item5[(object)"deviceid"].ToString()) == null)
					{
						DataRow dataRow2 = Class9.dataTable_0.NewRow();
						dataRow2["check"] = false;
						dataRow2["ip"] = item5[(object)"ip"].ToString();
						string[] array2 = item5[(object)"ip"].ToString().Split('.');
						dataRow2["_ip"] = Conversions.ToLong(array2[0].PadLeft(3, '0') + array2[1].PadLeft(3, '0') + array2[2].PadLeft(3, '0') + array2[3].PadLeft(3, '0'));
						dataRow2["port"] = item5[(object)"port"].ToString();
						dataRow2["devname"] = item5[(object)"devname"].ToString();
						dataRow2["deviceid"] = item5[(object)"deviceid"].ToString();
						dataRow2["devmac"] = item5[(object)"devmac"].ToString();
						dataRow2["devsn"] = item5[(object)"devsn"].ToString();
						dataRow2["devtype"] = item5[(object)"devtype"].ToString();
						dataRow2["zeversion"] = item5[(object)"zeversion"].ToString();
						dataRow2["sysversion"] = item5[(object)"sysversion"].ToString();
						dataRow2["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"boardconfig"] == null, "", item5[(object)"boardconfig"]));
						dataRow2["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"ecid"] == null, "", item5[(object)"ecid"]));
						dataRow2["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"buildid"] == null, "", item5[(object)"buildid"]));
						((JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"]).Add((JToken)new JObject(new object[12]
						{
							(object)new JProperty("ip", (object)item5[(object)"ip"]),
							(object)new JProperty("port", (object)item5[(object)"port"]),
							(object)new JProperty("devname", (object)item5[(object)"devname"]),
							(object)new JProperty("deviceid", (object)item5[(object)"deviceid"]),
							(object)new JProperty("devmac", (object)item5[(object)"devmac"]),
							(object)new JProperty("devsn", (object)item5[(object)"devsn"]),
							(object)new JProperty("devtype", (object)item5[(object)"devtype"]),
							(object)new JProperty("zeversion", (object)item5[(object)"zeversion"]),
							(object)new JProperty("sysversion", (object)item5[(object)"sysversion"]),
							(object)new JProperty("boardconfig", RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"boardconfig"] == null, "", item5[(object)"boardconfig"]))),
							(object)new JProperty("ecid", RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"ecid"] == null, "", item5[(object)"ecid"]))),
							(object)new JProperty("buildid", RuntimeHelpers.GetObjectValue(Interaction.IIf(item5[(object)"buildid"] == null, "", item5[(object)"buildid"])))
						}));
						Class9.dataTable_0.Rows.Add(dataRow2);
					}
				}
			}
		}
		catch (Exception projectError7)
		{
			ProjectData.SetProjectError(projectError7);
			ProjectData.ClearProjectError();
		}
		treeNode.Expand();
	}

	private void Form_Main_t_FormClosing(object sender, FormClosingEventArgs e)
	{
		Class9.jobject_3["Choose"] = JToken.op_Implicit(ToolStripComboBox_ScriptFile.Text);
		File.WriteAllText(Application.StartupPath + "\\config.json", JsonConvert.SerializeObject((object)Class9.jobject_3));
		Class9.oleDbConnection_0.Close();
		Class9.nancyHost_0.Stop();
		Class9.class_UDP_0.Close();
	}

	private void whLbnrbQhi(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			base.Visible = false;
			base.WindowState = FormWindowState.Minimized;
			vmethod_10().ShowBalloonTip(1000, Text, "已最小化到系统托盘", ToolTipIcon.Info);
			ToolStripMenuItem_Show_Hide.Text = "显示&&隐藏";
		}
		else
		{
			base.Visible = true;
			base.WindowState = FormWindowState.Normal;
			Show();
		}
	}

	private void method_1(object sender, MouseEventArgs e)
	{
		base.Visible = true;
		base.WindowState = FormWindowState.Normal;
		Show();
	}

	private void method_2(object sender, EventArgs e)
	{
		Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (new Form_Config().ShowDialog() == DialogResult.Yes)
		{
			method_0();
		}
	}

	private void rbRbcgjweK(object sender, EventArgs e)
	{
		Frm_MadeUI frm_MadeUI = new Frm_MadeUI();
		if (Class9.jobject_1 != null)
		{
			frm_MadeUI.TextBox_ScriptName.Text = (string)Class9.jobject_1["Name"];
			frm_MadeUI.TextBox_Developer.Text = (string)Class9.jobject_1["Developer"];
			frm_MadeUI.TextBox_BuyLink.Text = (string)Class9.jobject_1["BuyLink"];
			frm_MadeUI.TextBox_Instructions.Text = (string)Class9.jobject_1["Instructions"];
		}
		try
		{
			string text = ToolStripComboBox_ScriptFile.Text;
			if (text.StartsWith("项目:"))
			{
				ToolStripButton_SendScript.Text = "同步文件";
				if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.lua") | File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.xxt"))
				{
					string text2 = Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.json";
					if (File.Exists(text2))
					{
						frm_MadeUI.LoadInfo(text2);
					}
				}
				else if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 5)))
				{
					text = Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 5);
					string text3 = Path.GetDirectoryName(text) + "\\" + Path.GetFileNameWithoutExtension(text) + ".json";
					if (File.Exists(text3))
					{
						frm_MadeUI.LoadInfo(text3);
					}
				}
			}
			else
			{
				ToolStripButton_SendScript.Text = "发送脚本";
				string text4 = Path.GetDirectoryName(text) + "\\" + Path.GetFileNameWithoutExtension(text) + ".json";
				if (File.Exists(text) & File.Exists(text4))
				{
					frm_MadeUI.LoadInfo(text4);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		frm_MadeUI.ShowDialog();
		method_14(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void method_4(object sender, EventArgs e)
	{
		File.WriteAllText(Application.StartupPath + "\\1ferver\\lua\\CC.lua", Class9.string_0);
		MessageBox.Show("\"CC.lua\"已释放至本软件目录下(" + Application.StartupPath + "\\1ferver\\lua\\)\r\n同步\"CC.lua\"至\"插件目录\"或内嵌至脚本中\r\n使用方式请参照\"CC.lua\"内使用示例来调用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Process.Start(Application.StartupPath + "\\1ferver\\lua\\");
	}

	private void method_5(object sender, EventArgs e)
	{
		string text = "";
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(dataRow["ip"], "\r\n")));
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			SaveFileDialog saveFileDialog = vmethod_4();
			saveFileDialog.Title = "选择要导出的IP列表文件位置";
			saveFileDialog.FileName = "";
			saveFileDialog.Filter = "文本文件 (*.txt)|*.txt";
			saveFileDialog.FilterIndex = 0;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowDialog();
			if (Operators.CompareString(saveFileDialog.FileName, "", TextCompare: false) != 0)
			{
				File.WriteAllText(saveFileDialog.FileName, text, Encoding.UTF8);
				MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			saveFileDialog = null;
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		string text = Interaction.InputBox("输入要创建的表名", "创建表");
		if (Operators.CompareString(text, "", TextCompare: false) != 0 && Class9.ikpUfLfjaf("create table [" + text + "] ([id] int IDENTITY (1,1) PRIMARY KEY )") == null)
		{
			Form_EditDB form_EditDB = new Form_EditDB();
			form_EditDB.Text = "创建新的表";
			form_EditDB.DbName = text;
			form_EditDB.Show();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		Class3.Class4_0.AboutBox.ShowDialog();
	}

	private void BePbxOdtil(object sender, EventArgs e)
	{
		Process.Start("http://www.xxtouch.com");
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				string text = iPAddress.ToString();
				string string_ = JsonConvert.SerializeObject((object)new JObject(new object[2]
				{
					(object)new JProperty("ip", (object)text),
					(object)new JProperty("port", (object)Class9.int_2)
				}));
				string string_2 = Strings.Mid(text, 1, Strings.InStrRev(text, ".")) + "255";
				Class8.smethod_32("255.255.255.255", 46953, string_);
				Class8.smethod_32(string_2, 46953, string_);
			}
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		Class3.Class4_0.Form_Scan.Show();
	}

	private void method_10(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要导入的IP列表文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "IP地址文件 (*.txt)|*.txt";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			string[] array = File.ReadAllLines(vmethod_8().FileName, Encoding.UTF8);
			_Closure_0024__18_002D0 obj = default(_Closure_0024__18_002D0);
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				obj = new _Closure_0024__18_002D0(obj);
				obj._0024VB_0024Local_IP = array[i];
				ThreadPool.QueueUserWorkItem(obj._Lambda_0024__R1);
			}
		}
	}

	private void method_11(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Link;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void method_12(object sender, DragEventArgs e)
	{
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, autoConvert: false);
		if (array.Length <= 1)
		{
			ToolStripComboBox_ScriptFile.Text = array[0];
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		ToolStripComboBox_ScriptFile.Items.Clear();
		string[] directories = Directory.GetDirectories(Application.StartupPath + "\\1ferver\\lua\\scripts\\");
		foreach (string text in directories)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			if (File.Exists(text + "\\main.xxt") | File.Exists(text + "\\main.lua"))
			{
				ToolStripComboBox_ScriptFile.Items.Add("项目:" + directoryInfo.Name);
			}
		}
		string[] files = Directory.GetFiles(Application.StartupPath + "\\1ferver\\lua\\scripts\\");
		foreach (string text2 in files)
		{
			FileInfo fileInfo = new FileInfo(text2);
			string extension = Path.GetExtension(text2);
			if ((Operators.CompareString(extension, ".lua", TextCompare: false) == 0) | (Operators.CompareString(extension, ".xxt", TextCompare: false) == 0))
			{
				ToolStripComboBox_ScriptFile.Items.Add("项目:" + fileInfo.Name);
			}
		}
		ToolStripComboBox_ScriptFile.Items.Add("启动当前选择");
	}

	private void method_14(object sender, EventArgs e)
	{
		try
		{
			string text = ToolStripComboBox_ScriptFile.Text;
			if (text.StartsWith("项目:"))
			{
				ToolStripButton_SendScript.Text = "同步文件";
				if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.lua") | File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.xxt"))
				{
					string text2 = Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 3) + "\\main.json";
					Text = text.Remove(0, 3) + " - 蜘蛛侠中控";
					vmethod_10().Text = Text;
					if (File.Exists(text2))
					{
						SplitContainer1.Panel2Collapsed = false;
						method_69(text2);
					}
					else
					{
						SplitContainer1.Panel2Collapsed = true;
						ToolStripButton_ScriptInfo.Visible = false;
						ToolStripButton_Push.Visible = false;
					}
				}
				else if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 5)))
				{
					text = Application.StartupPath + "\\1ferver\\lua\\scripts\\" + text.Remove(0, 5);
					string text3 = Path.GetDirectoryName(text) + "\\" + Path.GetFileNameWithoutExtension(text) + ".json";
					Text = Path.GetFileNameWithoutExtension(text) + " - 蜘蛛侠中控";
					vmethod_10().Text = Text;
					if (File.Exists(text3))
					{
						SplitContainer1.Panel2Collapsed = false;
						method_69(text3);
					}
					else
					{
						SplitContainer1.Panel2Collapsed = true;
						ToolStripButton_ScriptInfo.Visible = false;
						ToolStripButton_Push.Visible = false;
					}
				}
				else
				{
					SplitContainer1.Panel2Collapsed = true;
					ToolStripButton_ScriptInfo.Visible = false;
					ToolStripButton_Push.Visible = false;
				}
			}
			else
			{
				ToolStripButton_SendScript.Text = "发送脚本";
				string text4 = Path.GetDirectoryName(text) + "\\" + Path.GetFileNameWithoutExtension(text) + ".json";
				SplitContainer1.Panel2Collapsed = false;
				Text = Path.GetFileNameWithoutExtension(text) + " - 蜘蛛侠中控";
				if (File.Exists(text) & File.Exists(text4))
				{
					vmethod_10().Text = Text;
					method_69(text4);
				}
				else
				{
					SplitContainer1.Panel2Collapsed = true;
					ToolStripButton_ScriptInfo.Visible = false;
					ToolStripButton_Push.Visible = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Text = "蜘蛛侠中控";
			vmethod_10().Text = Text;
			SplitContainer1.Panel2Collapsed = true;
			ToolStripButton_ScriptInfo.Visible = false;
			ToolStripButton_Push.Visible = false;
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		Form_ScriptInfo form_ScriptInfo = new Form_ScriptInfo();
		form_ScriptInfo.Text = "关于 " + Class9.jobject_1["Name"].ToString() + " 脚本";
		form_ScriptInfo.PictureBox_Logo.Image = ToolStripButton_ScriptInfo.Image;
		form_ScriptInfo.Show();
	}

	private void method_16(object sender, EventArgs e)
	{
		_Closure_0024__24_002D0 CS_0024_003C_003E8__locals8 = new _Closure_0024__24_002D0();
		CS_0024_003C_003E8__locals8._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals8._0024VB_0024Local_p = new Form_Push();
		CS_0024_003C_003E8__locals8._0024VB_0024Local_p.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
		{
			CS_0024_003C_003E8__locals8._Lambda_0024__0();
		};
		CS_0024_003C_003E8__locals8._0024VB_0024Local_p.Button_Cancel.Click += [SpecialName] (object obj, EventArgs e2) =>
		{
			CS_0024_003C_003E8__locals8._Lambda_0024__2();
		};
		CS_0024_003C_003E8__locals8._0024VB_0024Local_p.ShowDialog();
		CS_0024_003C_003E8__locals8._0024VB_0024Local_p.Dispose();
	}

	private void method_17(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择脚本文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt|图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|文本文件 (*.txt,*.ini,*.log)|*.txt;*.ini;*.log|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			ToolStripComboBox_ScriptFile.Text = openFileDialog.FileName;
			openFileDialog = null;
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		string text = ToolStripComboBox_ScriptFile.Text;
		if (text.StartsWith("项目:"))
		{
			Form_synchronous form_synchronous = new Form_synchronous();
			form_synchronous._IP = method_45();
			form_synchronous.ShowDialog();
		}
		if (File.Exists(text))
		{
			_Closure_0024__26_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__26_002D0();
			CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue = new Queue<string>();
			CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue.Enqueue(text);
			CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
			new Thread([SpecialName] () =>
			{
				Class8.smethod_17(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, "lua/scripts", CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue);
			}).Start();
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		Form_synchronous form_synchronous = new Form_synchronous();
		form_synchronous._IP = method_45();
		form_synchronous.ShowDialog();
	}

	private void method_20(object sender, EventArgs e)
	{
		_Closure_0024__28_002D0 arg = default(_Closure_0024__28_002D0);
		_Closure_0024__28_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__28_002D0(arg);
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要发送至(lua/scripts)的文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt|图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|文本文件 (*.txt,*.ini,*.log)|*.txt;*.ini;*.log|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			CS_0024_003C_003E8__locals3._0024VB_0024Local_file_queue = new Queue<string>();
			string[] fileNames = vmethod_8().FileNames;
			foreach (string item in fileNames)
			{
				CS_0024_003C_003E8__locals3._0024VB_0024Local_file_queue.Enqueue(item);
			}
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				CS_0024_003C_003E8__locals3._Lambda_0024__0((JArray)a0);
			}).Start(method_45());
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		_Closure_0024__29_002D0 arg = default(_Closure_0024__29_002D0);
		_Closure_0024__29_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__29_002D0(arg);
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要发送至(res)的文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt|图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|文本文件 (*.txt,*.ini,*.log)|*.txt;*.ini;*.log|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue = new Queue<string>();
			string[] fileNames = vmethod_8().FileNames;
			foreach (string item in fileNames)
			{
				CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue.Enqueue(item);
			}
			CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
			new Thread([SpecialName] () =>
			{
				Class8.smethod_17(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, "res", CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue);
			}).Start();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		_Closure_0024__30_002D0 arg = default(_Closure_0024__30_002D0);
		_Closure_0024__30_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__30_002D0(arg);
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要发送至(lua)的文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt|图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|文本文件 (*.txt,*.ini,*.log)|*.txt;*.ini;*.log|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue = new Queue<string>();
			string[] fileNames = vmethod_8().FileNames;
			foreach (string item in fileNames)
			{
				CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue.Enqueue(item);
			}
			CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
			new Thread([SpecialName] () =>
			{
				Class8.smethod_17(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, "lua", CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue);
			}).Start();
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		_Closure_0024__31_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__31_002D0();
		File.WriteAllText(Application.StartupPath + "\\CC.lua", Class9.string_0);
		CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue = new Queue<string>();
		CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue.Enqueue(Application.StartupPath + "\\CC.lua");
		CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
		new Thread([SpecialName] () =>
		{
			Class8.smethod_17(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, "lua", CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue);
		}).Start();
	}

	private void bUtmgiaAf2(object sender, EventArgs e)
	{
		_Closure_0024__32_002D0 arg = default(_Closure_0024__32_002D0);
		_Closure_0024__32_002D0 CS_0024_003C_003E8__locals9 = new _Closure_0024__32_002D0(arg);
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要发送至(res)的文件";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt|图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|文本文件 (*.txt,*.ini,*.log)|*.txt;*.ini;*.log|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if (!((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName)))
		{
			return;
		}
		openFileDialog = null;
		CS_0024_003C_003E8__locals9._0024VB_0024Local_file_queue = new Queue<string>();
		string[] fileNames = vmethod_8().FileNames;
		foreach (string item in fileNames)
		{
			CS_0024_003C_003E8__locals9._0024VB_0024Local_file_queue.Enqueue(item);
		}
		CS_0024_003C_003E8__locals9._0024VB_0024Local_list = method_45();
		new Thread(checked([SpecialName] () =>
		{
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			int num = -1;
			JObject val = null;
			string text = null;
			while (true)
			{
				if (val == null)
				{
					num++;
					if (((JContainer)CS_0024_003C_003E8__locals9._0024VB_0024Local_list).Count <= num)
					{
						return;
					}
					val = (JObject)CS_0024_003C_003E8__locals9._0024VB_0024Local_list[num];
				}
				if (text == null)
				{
					if (CS_0024_003C_003E8__locals9._0024VB_0024Local_file_queue.Count == 0)
					{
						break;
					}
					text = CS_0024_003C_003E8__locals9._0024VB_0024Local_file_queue.Dequeue();
				}
				if (File.Exists(text))
				{
					string text2 = "";
					int int_ = Class9.int_0;
					for (int j = 1; j <= int_; j++)
					{
						text2 = Class8.smethod_35("http://" + val["ip"].ToString() + ":46952/write_file", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject(new object[2]
						{
							(object)new JProperty("filename", (object)("/res/" + Path.GetFileName(text))),
							(object)new JProperty("data", (object)Convert.ToBase64String(File.ReadAllBytes(text)))
						}))));
						if (text2.Contains("message"))
						{
							break;
						}
						Class8.smethod_30(val["ip"].ToString(), "超时" + Conversions.ToString(j));
					}
					try
					{
						if (text2.Contains("message"))
						{
							JObject val2 = JObject.Parse(text2);
							if ((int)val2["code"] == 0)
							{
								Class8.smethod_30(val["ip"].ToString(), Path.GetFileName(text) + " 发送成功");
								text = null;
							}
							else
							{
								Class8.smethod_30(val["ip"].ToString(), (string)val2["message"]);
							}
						}
						else
						{
							Class8.smethod_30(val["ip"].ToString(), "超时");
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Class8.smethod_30(val["ip"].ToString(), ex2.Message.ToString());
						ProjectData.ClearProjectError();
					}
					val = null;
				}
			}
			int num2 = num;
			int num3 = ((JContainer)CS_0024_003C_003E8__locals9._0024VB_0024Local_list).Count - 1;
			for (int k = num2; k <= num3; k++)
			{
				Class8.smethod_30(CS_0024_003C_003E8__locals9._0024VB_0024Local_list[k][(object)"ip"].ToString(), "未发送文件");
			}
		})).Start();
	}

	private void method_24(object sender, EventArgs e)
	{
		_Closure_0024__33_002D0 arg = default(_Closure_0024__33_002D0);
		_Closure_0024__33_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__33_002D0(arg);
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要发送至(系统相册)的图片";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "图片文件 (*.gif,*.png,*.jpg,*.jpeg,*.bmp)|*.gif;*.png;*.jpg;*.jpeg;*.bmp|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = true;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue = new Queue<string>();
			string[] fileNames = vmethod_8().FileNames;
			foreach (string item in fileNames)
			{
				CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue.Enqueue(item);
			}
			CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
			new Thread([SpecialName] () =>
			{
				Class8.smethod_29(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, CS_0024_003C_003E8__locals5._0024VB_0024Local_file_queue);
			}).Start();
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		_Closure_0024__34_002D0 CS_0024_003C_003E8__locals17 = new _Closure_0024__34_002D0();
		CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P = ToolStripComboBox_ScriptFile.Text;
		CS_0024_003C_003E8__locals17._0024VB_0024Local_list = method_45();
		if (CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.StartsWith("项目:"))
		{
			if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3)))
			{
				new Thread([SpecialName] () =>
				{
					Class8.smethod_14(CS_0024_003C_003E8__locals17._0024VB_0024Local_list, CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3));
				}).Start();
			}
			else if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3) + "\\main.xxt"))
			{
				new Thread([SpecialName] () =>
				{
					Class8.smethod_14(CS_0024_003C_003E8__locals17._0024VB_0024Local_list, CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3) + "/main.xxt");
				}).Start();
			}
			else if (File.Exists(Application.StartupPath + "\\1ferver\\lua\\scripts\\" + CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3) + "\\main.lua"))
			{
				new Thread([SpecialName] () =>
				{
					Class8.smethod_14(CS_0024_003C_003E8__locals17._0024VB_0024Local_list, CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P.Remove(0, 3) + "/main.lua");
				}).Start();
			}
			else
			{
				MessageBox.Show("未选择脚本或脚本不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else if (Operators.CompareString(CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P, "启动当前选择", TextCompare: false) == 0)
		{
			new Thread([SpecialName] () =>
			{
				Class8.smethod_13(CS_0024_003C_003E8__locals17._0024VB_0024Local_list);
			}).Start();
		}
		else if (!File.Exists(CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P))
		{
			MessageBox.Show("未选择脚本或脚本不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else
		{
			new Thread([SpecialName] () =>
			{
				Class8.smethod_5(CS_0024_003C_003E8__locals17._0024VB_0024Local_list, CS_0024_003C_003E8__locals17._0024VB_0024Local_F_P);
			}).Start();
		}
	}

	private void QlFmpoukVp(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_6((JArray)a0);
		}).Start(method_45());
	}

	private void method_26(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_7((JArray)a0);
		}).Start(method_45());
	}

	private void method_27(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_8((JArray)a0);
		}).Start(method_45());
	}

	private void method_28(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			((VB_0024AnonymousDelegate_1<JArray>)([SpecialName] (JArray IP) =>
			{
				Class8.iDdbiArgcT(IP);
			}))((JArray)a0);
		}).Start(method_45());
	}

	private void method_29(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_10((JArray)a0);
		}).Start(method_45());
	}

	private void method_30(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			((VB_0024AnonymousDelegate_1<JArray>)([SpecialName] (JArray IP) =>
			{
				Class8.smethod_4(IP, "spawn", "device.unlock_screen()now_screen_level=device.brightness();device.set_brightness(1);device.set_volume(1);for i=0,25 do;if i%2==0 then;device.vibrator();webview.show{};device.flash_on();else;webview.hide();device.flash_off();end;if i%15==0 then;device.play_sound('/System/Library/Audio/UISounds/sms-received3.caf');end;sys.msleep(200);end;webview.destroy();device.set_brightness(now_screen_level)", "启动成功", 3000);
			}))((JArray)a0);
		}).Start(method_45());
	}

	private void method_31(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_11((JArray)a0);
		}).Start(method_45());
	}

	private void method_32(object sender, EventArgs e)
	{
		new Frm_Auth().ShowDialog();
	}

	private void method_33(object sender, EventArgs e)
	{
		if (MessageBox.Show("deb安装会造成服务出错,属于正常现象.\r\n重启设备可以解决问题", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
		{
			return;
		}
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要安装至设备的deb安装包";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "deb安装包 (*.deb)|*.deb";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				_Lambda_0024__43_002D0((JArray)a0);
			}).Start(method_45());
		}
	}

	private void method_34(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = vmethod_8();
		openFileDialog.Title = "选择要安装至设备的ipa安装包";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "安装包 (*.ipa)|*.ipa";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				_Lambda_0024__44_002D0((JArray)a0);
			}).Start(method_45());
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		new Frm_SSH().Show();
	}

	private void method_36(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_19((JArray)a0);
		}).Start(method_45());
	}

	private void method_37(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_20((JArray)a0);
		}).Start(method_45());
	}

	private void method_38(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_21((JArray)a0);
		}).Start(method_45());
	}

	private void method_39(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_23((JArray)a0);
		}).Start(method_45());
	}

	private void method_40(object sender, EventArgs e)
	{
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_22((JArray)a0);
		}).Start(method_45());
	}

	private void method_41(object sender, EventArgs e)
	{
		_Closure_0024__51_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__51_002D0();
		CS_0024_003C_003E8__locals3._0024VB_0024Local_a = new Frm_Level();
		JArray val = method_45();
		if (((JContainer)val).Count != 0 && CS_0024_003C_003E8__locals3._0024VB_0024Local_a.ShowDialog() == DialogResult.OK)
		{
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				CS_0024_003C_003E8__locals3._Lambda_0024__0((JArray)a0);
			}).Start(val);
		}
	}

	private void method_42(object sender, EventArgs e)
	{
		_Closure_0024__52_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__52_002D0();
		CS_0024_003C_003E8__locals3._0024VB_0024Local_a = new Frm_Level();
		JArray val = method_45();
		if (((JContainer)val).Count != 0 && CS_0024_003C_003E8__locals3._0024VB_0024Local_a.ShowDialog() == DialogResult.OK)
		{
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				CS_0024_003C_003E8__locals3._Lambda_0024__0((JArray)a0);
			}).Start(val);
		}
	}

	private void method_43(object sender, EventArgs e)
	{
		_Closure_0024__53_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__53_002D0();
		CS_0024_003C_003E8__locals3._0024VB_0024Local_f = new Frm_User_cfg();
		if (CS_0024_003C_003E8__locals3._0024VB_0024Local_f.ShowDialog() == DialogResult.OK)
		{
			new Thread([SpecialName] (object a0) =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Expected O, but got Unknown
				CS_0024_003C_003E8__locals3._Lambda_0024__0((JArray)a0);
			}).Start(method_45());
		}
	}

	private void method_44(object sender, EventArgs e)
	{
		_Closure_0024__55_002D1 obj = new _Closure_0024__55_002D1(obj);
		Frm_Back_SHSH2 frm_Back_SHSH = new Frm_Back_SHSH2();
		if (frm_Back_SHSH.ShowDialog() != DialogResult.Yes)
		{
			return;
		}
		obj._0024VB_0024Local_cmd = "--ecid {0} --device {1} --boardconfig {2}";
		if (frm_Back_SHSH.CheckBox2_Beta.Checked)
		{
			obj._0024VB_0024Local_cmd += " --beta";
		}
		if (frm_Back_SHSH.CheckBox_ChooseV.Checked)
		{
			obj._0024VB_0024Local_cmd = obj._0024VB_0024Local_cmd + " --ios " + frm_Back_SHSH.TextBox3.Text + " --buildid " + frm_Back_SHSH.TextBox4.Text;
		}
		else
		{
			obj._0024VB_0024Local_cmd += " --latest";
		}
		if (Operators.CompareString(frm_Back_SHSH.TextBox1.Text, "", TextCompare: false) != 0)
		{
			obj._0024VB_0024Local_cmd = obj._0024VB_0024Local_cmd + " --apnonce " + frm_Back_SHSH.TextBox1.Text;
		}
		if (Operators.CompareString(frm_Back_SHSH.TextBox2.Text, "", TextCompare: false) != 0)
		{
			obj._0024VB_0024Local_cmd = obj._0024VB_0024Local_cmd + " --sepnonce " + frm_Back_SHSH.TextBox1.Text;
		}
		obj._0024VB_0024Local_cmd += " --save-path ./shsh2/ --save";
		Class_GenThreadPool.GenThreadPoolImpl genThreadPoolImpl = new Class_GenThreadPool.GenThreadPoolImpl(3, 0, 500, debug: false);
		if (!Directory.Exists(Application.StartupPath + "\\shsh2"))
		{
			Directory.CreateDirectory(Application.StartupPath + "\\shsh2");
		}
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		_Closure_0024__55_002D0 obj2 = default(_Closure_0024__55_002D0);
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			obj2 = new _Closure_0024__55_002D0(obj2);
			obj2._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
			obj2._0024VB_0024Local__Datas = array[i];
			if (!Convert.IsDBNull(RuntimeHelpers.GetObjectValue(obj2._0024VB_0024Local__Datas["ecid"])) && Operators.ConditionalCompareObjectNotEqual(obj2._0024VB_0024Local__Datas["ecid"], "", TextCompare: false))
			{
				genThreadPoolImpl.AddJob(new Thread(obj2._Lambda_0024__0));
			}
		}
	}

	private JArray method_45()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		JArray val = new JArray();
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			dataRow["message"] = "队列等待";
			val.Add((JToken)new JObject(new object[5]
			{
				(object)new JProperty("ip", RuntimeHelpers.GetObjectValue(dataRow["ip"])),
				(object)new JProperty("deviceid", RuntimeHelpers.GetObjectValue(dataRow["deviceid"])),
				(object)new JProperty("devsn", RuntimeHelpers.GetObjectValue(dataRow["devsn"])),
				(object)new JProperty("devtype", RuntimeHelpers.GetObjectValue(dataRow["devtype"])),
				(object)new JProperty("sysversion", RuntimeHelpers.GetObjectValue(dataRow["sysversion"]))
			}));
		}
		return val;
	}

	private void method_46(JArray jarray_1 = null, bool bool_1 = true)
	{
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
		dataGridView_DeviceList.Refresh();
		dataGridView_DeviceList.DataSource = null;
		dataGridView_DeviceList.Rows.Clear();
		dataGridView_DeviceList.Columns.Clear();
		DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn
		{
			DataPropertyName = "check",
			HeaderText = "选择",
			ReadOnly = false
		};
		DataGridView_DeviceList.Columns.Add(dataGridViewColumn);
		dataGridView_DeviceList.DataSource = Class9.dataTable_0;
		dataGridView_DeviceList.Columns["ip"].HeaderText = "IP";
		dataGridView_DeviceList.Columns["port"].HeaderText = "端口";
		dataGridView_DeviceList.Columns["devname"].HeaderText = "设备名";
		dataGridView_DeviceList.Columns["deviceid"].HeaderText = "设备号";
		dataGridView_DeviceList.Columns["devsn"].HeaderText = "设备串号";
		dataGridView_DeviceList.Columns["devmac"].HeaderText = "设备MAC";
		dataGridView_DeviceList.Columns["devtype"].HeaderText = "设备类型";
		dataGridView_DeviceList.Columns["zeversion"].HeaderText = "版本";
		dataGridView_DeviceList.Columns["sysversion"].HeaderText = "系统版本";
		dataGridView_DeviceList.Columns["message"].HeaderText = "消息";
		dataGridView_DeviceList.Columns["ecid"].HeaderText = "ECID";
		dataGridView_DeviceList.Columns["buildid"].HeaderText = "BuildID";
		dataGridView_DeviceList.Columns["boardconfig"].HeaderText = "BoardConfig";
		if (jarray_1 == null)
		{
			dataGridView_DeviceList.Columns["_ip"].Visible = false;
			dataGridView_DeviceList.Columns["port"].Visible = false;
			dataGridView_DeviceList.Columns["deviceid"].Visible = false;
			dataGridView_DeviceList.Columns["devsn"].Visible = false;
			dataGridView_DeviceList.Columns["devmac"].Visible = false;
			dataGridView_DeviceList.Columns["devtype"].Visible = false;
			dataGridView_DeviceList.Columns["zeversion"].Visible = false;
			dataGridView_DeviceList.Columns["sysversion"].Visible = false;
			dataGridView_DeviceList.Columns["boardconfig"].Visible = false;
			dataGridView_DeviceList.Columns["ecid"].Visible = false;
			dataGridView_DeviceList.Columns["buildid"].Visible = false;
		}
		else
		{
			dataGridView_DeviceList.Columns["_ip"].Visible = false;
			dataGridView_DeviceList.Columns["port"].Visible = false;
			dataGridView_DeviceList.Columns["devname"].Visible = false;
			dataGridView_DeviceList.Columns["deviceid"].Visible = false;
			dataGridView_DeviceList.Columns["devsn"].Visible = false;
			dataGridView_DeviceList.Columns["devmac"].Visible = false;
			dataGridView_DeviceList.Columns["devtype"].Visible = false;
			dataGridView_DeviceList.Columns["zeversion"].Visible = false;
			dataGridView_DeviceList.Columns["sysversion"].Visible = false;
			dataGridView_DeviceList.Columns["boardconfig"].Visible = false;
			dataGridView_DeviceList.Columns["ecid"].Visible = false;
			dataGridView_DeviceList.Columns["buildid"].Visible = false;
			foreach (JValue item in ((JContainer)jarray_1).Children())
			{
				switch (item.ToString())
				{
				case "sysversion":
					dataGridView_DeviceList.Columns["sysversion"].Visible = true;
					break;
				case "buildid":
					dataGridView_DeviceList.Columns["buildid"].Visible = true;
					break;
				case "port":
					dataGridView_DeviceList.Columns["port"].Visible = true;
					break;
				case "deviceid":
					dataGridView_DeviceList.Columns["deviceid"].Visible = true;
					break;
				case "devmac":
					dataGridView_DeviceList.Columns["devmac"].Visible = true;
					break;
				case "zeversion":
					dataGridView_DeviceList.Columns["zeversion"].Visible = true;
					break;
				case "devname":
					dataGridView_DeviceList.Columns["devname"].Visible = true;
					break;
				case "boardconfig":
					dataGridView_DeviceList.Columns["boardconfig"].Visible = true;
					break;
				case "devsn":
					dataGridView_DeviceList.Columns["devsn"].Visible = true;
					break;
				case "ecid":
					dataGridView_DeviceList.Columns["ecid"].Visible = true;
					break;
				case "devtype":
					dataGridView_DeviceList.Columns["devtype"].Visible = true;
					break;
				}
			}
		}
		dataGridView_DeviceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_DeviceList.AllowUserToAddRows = false;
		dataGridView_DeviceList.EditMode = DataGridViewEditMode.EditOnEnter;
		dataGridView_DeviceList.BackgroundColor = Color.White;
		if (bool_1)
		{
			dataGridView_DeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
		}
		else
		{
			dataGridView_DeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		}
		dataGridView_DeviceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		dataGridView_DeviceList.ReadOnly = true;
		dataGridView_DeviceList.AutoGenerateColumns = true;
		dataGridView_DeviceList.VirtualMode = false;
		dataGridView_DeviceList.AutoResizeColumns();
		dataGridView_DeviceList.Columns["ip"].Width = 130;
		dataGridView_DeviceList.Columns["devname"].Width = 100;
		dataGridView_DeviceList.Columns["message"].Width = 200;
		try
		{
			string sort = (string)Class9.jobject_3["DeviceTable"][(object)"Sort"];
			Class9.dataTable_0.DefaultView.Sort = sort;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Class9.jobject_3["DeviceTable"][(object)"Sort"] = JToken.op_Implicit("_ip asc");
			Class9.dataTable_0.DefaultView.Sort = "_ip asc";
			ProjectData.ClearProjectError();
		}
		dataGridView_DeviceList = null;
	}

	private void method_47(string string_0)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		_Closure_0024__58_002D0 arg = default(_Closure_0024__58_002D0);
		_Closure_0024__58_002D0 CS_0024_003C_003E8__locals126 = new _Closure_0024__58_002D0(arg);
		CS_0024_003C_003E8__locals126._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName = string_0;
		TabPage tabPage = new TabPage();
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView = new DataGridView();
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView = new TreeView();
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable = new DataTable();
		CS_0024_003C_003E8__locals126._0024VB_0024Local_Columns_Width = new JObject();
		CS_0024_003C_003E8__locals126._0024VB_0024Local_frist_cw = false;
		CS_0024_003C_003E8__locals126._0024VB_0024Local_ResList = [SpecialName] () =>
		{
			foreach (DataGridViewColumn column in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
			{
				CS_0024_003C_003E8__locals126._0024VB_0024Local_Columns_Width[column.DataPropertyName] = JToken.op_Implicit(column.Width);
			}
			CS_0024_003C_003E8__locals126._0024VB_0024Local_frist_cw = true;
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Clear();
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = null;
			bool result;
			try
			{
				using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select * from `{CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName}`", Class9.oleDbConnection_0))
				{
					using DataSet dataSet = new DataSet
					{
						Locale = CultureInfo.InvariantCulture,
						CaseSensitive = true
					};
					oleDbDataAdapter.Fill(dataSet);
					if (dataSet.Tables.Count > 0)
					{
						CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable = dataSet.Tables[0];
						goto IL_00f3;
					}
					result = false;
				}
				goto end_IL_0078;
				IL_00f3:
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Columns.Add("check", typeof(bool));
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Columns["check"].SetOrdinal(0);
				goto IL_0144;
				end_IL_0078:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = false;
				ProjectData.ClearProjectError();
			}
			goto IL_03d4;
			IL_03d4:
			return result;
			IL_0144:
			DataGridView dataGridView = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView;
			DataGridViewCheckBoxColumn dataGridViewColumn2 = new DataGridViewCheckBoxColumn
			{
				Width = 30,
				DataPropertyName = "check",
				HeaderText = "选择",
				ReadOnly = false
			};
			dataGridView.Columns.Add(dataGridViewColumn2);
			dataGridView.AutoGenerateColumns = true;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
			dataGridView.BackgroundColor = Color.White;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.Dock = DockStyle.Fill;
			dataGridView.ReadOnly = true;
			dataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
			dataGridView.Invalidate();
			try
			{
				TreeView treeView = CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView;
				treeView.CheckBoxes = true;
				treeView.Nodes.Clear();
				foreach (DataGridViewColumn column2 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
				{
					if ((Operators.CompareString(column2.DataPropertyName, "check", TextCompare: false) != 0) & (Operators.CompareString(column2.DataPropertyName, "id", TextCompare: false) != 0))
					{
						TreeNode treeNode = new TreeNode
						{
							Name = column2.DataPropertyName
						};
						foreach (DataRow row in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.DefaultView.ToTable(column2.DataPropertyName).Rows)
						{
							string text = Conversions.ToString(Interaction.IIf(Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column2.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(row[column2.DataPropertyName])));
							int num = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(column2.DataPropertyName + "='" + text + "'").Length;
							treeNode.Nodes.Add(text, text + " (" + Conversions.ToString(num) + ")");
						}
						treeNode.Text = column2.HeaderText + " (" + Conversions.ToString(treeNode.Nodes.Count) + ")";
						treeView.Nodes.Add(treeNode);
					}
					else if (Operators.CompareString(column2.DataPropertyName, "check", TextCompare: false) == 0)
					{
						column2.Width = 130;
					}
				}
				treeView.Dock = DockStyle.Fill;
				treeView = null;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			result = true;
			goto IL_03d4;
		};
		CS_0024_003C_003E8__locals126._0024VB_0024Local_Run = [SpecialName] (string SqlStr, string ErrorStr) =>
		{
			bool result;
			try
			{
				using (OleDbCommand oleDbCommand = new OleDbCommand())
				{
					oleDbCommand.CommandText = SqlStr;
					oleDbCommand.Connection = Class9.oleDbConnection_0;
					oleDbCommand.ExecuteNonQuery();
				}
				result = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorStr = ex2.Message.ToString();
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		};
		if (!CS_0024_003C_003E8__locals126._0024VB_0024Local_ResList())
		{
			return;
		}
		TabControl_Data.Controls.Add(tabPage);
		tabPage.Text = CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName;
		tabPage.Controls.Add(tableLayoutPanel);
		tableLayoutPanel.ContextMenuStrip = contextMenuStrip;
		tableLayoutPanel.Dock = DockStyle.Fill;
		tableLayoutPanel.ColumnCount = 2;
		tableLayoutPanel.RowCount = 1;
		tableLayoutPanel.Controls.Add(CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView, 0, 0);
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView, 1, 0);
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
		CS_0024_003C_003E8__locals126._0024VB_0024Local_SelectAll = false;
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.ColumnHeaderMouseClick += [SpecialName] (object sender, DataGridViewCellMouseEventArgs e) =>
		{
			if (e.ColumnIndex == 0)
			{
				bool flag = CS_0024_003C_003E8__locals126._0024VB_0024Local_SelectAll;
				foreach (DataRow row2 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Rows)
				{
					row2["check"] = flag;
				}
				CS_0024_003C_003E8__locals126._0024VB_0024Local_SelectAll = !CS_0024_003C_003E8__locals126._0024VB_0024Local_SelectAll;
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
			}
		};
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.CurrentCellDirtyStateChanged += [SpecialName] (object sender, EventArgs e) =>
		{
			if (CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.IsCurrentCellDirty)
			{
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		};
		CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.CellClick += [SpecialName] (object sender, DataGridViewCellEventArgs e) =>
		{
			try
			{
				if (e.ColumnIndex == 0 && e.RowIndex != -1)
				{
					DataGridView dataGridView = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView;
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView[1, e.RowIndex].Value), "'")))[0]["check"] = !Conversions.ToBoolean(dataGridView[e.ColumnIndex, e.RowIndex].EditedFormattedValue);
					dataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
					dataGridView.Invalidate();
					dataGridView = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		};
		checked
		{
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DoubleClick += [SpecialName] (object sender, EventArgs e) =>
			{
				_Closure_0024__58_002D1 arg2 = default(_Closure_0024__58_002D1);
				_Closure_0024__58_002D1 CS_0024_003C_003E8__locals127 = new _Closure_0024__58_002D1(arg2);
				CS_0024_003C_003E8__locals127._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals126;
				if (CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.SelectedRows.Count != 0)
				{
					CS_0024_003C_003E8__locals127._0024VB_0024Local_v = new Frm_Edit
					{
						Text = "修改数据"
					};
					DataRow dataRow = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.SelectedRows[0].Cells["id"].Value), "'")))[0];
					int num = 1;
					foreach (DataGridViewColumn column3 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
					{
						Label label = new Label();
						CS_0024_003C_003E8__locals127._0024VB_0024Local_v.Controls.Add(label);
						Label label2 = label;
						if (Operators.CompareString(column3.DataPropertyName, "check", TextCompare: false) == 0)
						{
							label2.Text = "选择";
						}
						else
						{
							label2.Text = column3.HeaderText;
						}
						label2.Left = 12;
						label2.Top = num * 25;
						label2.AutoSize = true;
						label2 = null;
						if (Operators.CompareString(column3.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
						{
							CheckBox checkBox = new CheckBox();
							CS_0024_003C_003E8__locals127._0024VB_0024Local_v.Controls.Add(checkBox);
							CheckBox checkBox2 = checkBox;
							if ((Operators.CompareString(column3.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column3.DataPropertyName, "check", TextCompare: false) == 0))
							{
								checkBox2.Enabled = false;
							}
							if (Operators.CompareString(column3.DataPropertyName, "check", TextCompare: false) == 0)
							{
								checkBox2.Checked = false;
							}
							else
							{
								checkBox2.Checked = Operators.ConditionalCompareObjectEqual(dataRow[column3.DataPropertyName], "true", TextCompare: false);
							}
							checkBox2.Text = "";
							checkBox2.Left = 96;
							checkBox2.Top = num * 25 - 3;
							checkBox2.Name = column3.DataPropertyName;
							checkBox2 = null;
						}
						else
						{
							TextBox textBox = new TextBox();
							CS_0024_003C_003E8__locals127._0024VB_0024Local_v.Controls.Add(textBox);
							TextBox textBox2 = textBox;
							if ((Operators.CompareString(column3.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column3.DataPropertyName, "check", TextCompare: false) == 0))
							{
								textBox2.Enabled = false;
							}
							textBox2.Text = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow[column3.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(dataRow[column3.DataPropertyName])));
							textBox2.Name = column3.DataPropertyName;
							textBox2.Left = 96;
							textBox2.Top = num * 25 - 3;
							textBox2 = null;
						}
						num++;
					}
					CS_0024_003C_003E8__locals127._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
					{
						CS_0024_003C_003E8__locals127._Lambda_0024__6(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
					};
					CS_0024_003C_003E8__locals127._0024VB_0024Local_v.ShowDialog();
				}
			};
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataError += [SpecialName] (object sender, DataGridViewDataErrorEventArgs e) =>
			{
			};
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataBindingComplete += [SpecialName] (object sender, DataGridViewBindingCompleteEventArgs e) =>
			{
				if (CS_0024_003C_003E8__locals126._0024VB_0024Local_frist_cw)
				{
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.AutoResizeColumns();
					foreach (DataGridViewColumn column4 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
					{
						if (CS_0024_003C_003E8__locals126._0024VB_0024Local_Columns_Width[column4.DataPropertyName] != null)
						{
							column4.Width = (int)CS_0024_003C_003E8__locals126._0024VB_0024Local_Columns_Width[column4.DataPropertyName];
						}
					}
					CS_0024_003C_003E8__locals126._0024VB_0024Local_frist_cw = false;
				}
			};
			CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView.AfterCheck += [SpecialName] (object sender, TreeViewEventArgs e) =>
			{
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView.BeginUpdate();
				if (Class9.bool_0)
				{
					CS_0024_003C_003E8__locals126._0024VB_0024Me.method_48(e.Node, e.Node.Checked);
					CS_0024_003C_003E8__locals126._0024VB_0024Me.method_49(e.Node);
					CS_0024_003C_003E8__locals126._0024VB_0024Me.method_50(e.Node);
					Class9.bool_0 = true;
				}
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView.EndUpdate();
				if (Class9.bool_0)
				{
					string text = "";
					foreach (TreeNode node in CS_0024_003C_003E8__locals126._0024VB_0024Local_NTreeView.Nodes)
					{
						foreach (TreeNode node2 in node.Nodes)
						{
							if (node2.Checked)
							{
								text = text + " or " + node.Name + "='" + node2.Name + "'";
							}
						}
					}
					try
					{
						DataRow[] array = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select("check=true");
						for (int i = 0; i < array.Length; i++)
						{
							array[i]["check"] = false;
						}
						if (Operators.CompareString(text, "", TextCompare: false) != 0)
						{
							DataRow[] array2 = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(text.Remove(0, 4));
							for (int j = 0; j < array2.Length; j++)
							{
								array2[j]["check"] = true;
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
				}
			};
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = "刷新";
			toolStripMenuItem.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				CS_0024_003C_003E8__locals126._0024VB_0024Local_ResList();
			};
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem2.Text = "批量修改勾选";
			toolStripMenuItem2.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				_Closure_0024__58_002D2 arg2 = default(_Closure_0024__58_002D2);
				_Closure_0024__58_002D2 CS_0024_003C_003E8__locals128 = new _Closure_0024__58_002D2(arg2);
				CS_0024_003C_003E8__locals128._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals126;
				CS_0024_003C_003E8__locals128._0024VB_0024Local_v = new Frm_Edit
				{
					Text = "重置勾选"
				};
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.NewRow();
				int num = 1;
				foreach (DataGridViewColumn column5 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
				{
					Label label = new Label();
					CS_0024_003C_003E8__locals128._0024VB_0024Local_v.Controls.Add(label);
					Label label2 = label;
					if (Operators.CompareString(column5.DataPropertyName, "check", TextCompare: false) == 0)
					{
						label2.Text = "选择";
					}
					else
					{
						label2.Text = column5.HeaderText;
					}
					label2.Left = 12;
					label2.Top = num * 25;
					label2.AutoSize = true;
					label2 = null;
					if (Operators.CompareString(column5.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
					{
						CheckBox checkBox = new CheckBox();
						CS_0024_003C_003E8__locals128._0024VB_0024Local_v.Controls.Add(checkBox);
						CheckBox checkBox2 = checkBox;
						if ((Operators.CompareString(column5.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column5.DataPropertyName, "check", TextCompare: false) == 0))
						{
							checkBox2.Enabled = false;
						}
						checkBox2.Checked = false;
						checkBox2.Text = "";
						checkBox2.Left = 96;
						checkBox2.Top = num * 25 - 3;
						checkBox2.Name = column5.DataPropertyName;
						checkBox2 = null;
					}
					else
					{
						TextBox textBox = new TextBox();
						CS_0024_003C_003E8__locals128._0024VB_0024Local_v.Controls.Add(textBox);
						TextBox textBox2 = textBox;
						if ((Operators.CompareString(column5.DataPropertyName, "id", TextCompare: false) == 0) | (Operators.CompareString(column5.DataPropertyName, "check", TextCompare: false) == 0))
						{
							textBox2.Enabled = false;
						}
						textBox2.Text = "(原值)";
						textBox2.Name = column5.DataPropertyName;
						textBox2.Left = 96;
						textBox2.Top = num * 25 - 3;
						textBox2 = null;
					}
					num++;
				}
				CS_0024_003C_003E8__locals128._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
				{
					CS_0024_003C_003E8__locals128._Lambda_0024__12(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
				};
				CS_0024_003C_003E8__locals128._0024VB_0024Local_v.ShowDialog();
			};
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
			toolStripMenuItem3.Text = "勾选选择";
			toolStripMenuItem3.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				foreach (DataGridViewRow selectedRow in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.SelectedRows)
				{
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", selectedRow.Cells["id"].Value), "'")))[0]["check"] = true;
				}
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
			};
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
			toolStripMenuItem4.Text = "不勾选选择";
			toolStripMenuItem4.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				foreach (DataGridViewRow selectedRow2 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.SelectedRows)
				{
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("id='", selectedRow2.Cells["id"].Value), "'")))[0]["check"] = false;
				}
				CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
			};
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
			toolStripMenuItem5.Text = "反向勾选";
			toolStripMenuItem5.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				try
				{
					foreach (DataRow row3 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Rows)
					{
						row3["check"] = !Conversions.ToBoolean(row3["check"].ToString());
					}
					CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.DataSource = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			};
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem();
			toolStripMenuItem6.Text = "添加";
			toolStripMenuItem6.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				_Closure_0024__58_002D3 arg2 = default(_Closure_0024__58_002D3);
				_Closure_0024__58_002D3 CS_0024_003C_003E8__locals129 = new _Closure_0024__58_002D3(arg2);
				CS_0024_003C_003E8__locals129._0024VB_0024NonLocal__0024VB_0024Closure_4 = CS_0024_003C_003E8__locals126;
				CS_0024_003C_003E8__locals129._0024VB_0024Local_v = new Frm_Edit
				{
					Text = "添加账号"
				};
				DataRow dataRow = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.NewRow();
				int num = 1;
				foreach (DataGridViewColumn column6 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataGridView.Columns)
				{
					Label label = new Label();
					CS_0024_003C_003E8__locals129._0024VB_0024Local_v.Controls.Add(label);
					Label label2 = label;
					if (Operators.CompareString(column6.DataPropertyName, "check", TextCompare: false) == 0)
					{
						label2.Text = "选择";
					}
					else
					{
						label2.Text = column6.HeaderText;
					}
					label2.Left = 12;
					label2.Top = num * 25;
					label2.AutoSize = true;
					label2 = null;
					if (Operators.CompareString(column6.CellType.FullName, "System.Windows.Forms.DataGridViewCheckBoxCell", TextCompare: false) == 0)
					{
						CheckBox checkBox = new CheckBox();
						CS_0024_003C_003E8__locals129._0024VB_0024Local_v.Controls.Add(checkBox);
						CheckBox checkBox2 = checkBox;
						if (Operators.CompareString(column6.DataPropertyName, "check", TextCompare: false) == 0)
						{
							checkBox2.Enabled = false;
						}
						checkBox2.Checked = false;
						checkBox2.Text = "";
						checkBox2.Left = 96;
						checkBox2.Top = num * 25 - 3;
						checkBox2.Name = column6.DataPropertyName;
						checkBox2 = null;
					}
					else
					{
						TextBox textBox = new TextBox();
						CS_0024_003C_003E8__locals129._0024VB_0024Local_v.Controls.Add(textBox);
						TextBox textBox2 = textBox;
						if (Operators.CompareString(column6.DataPropertyName, "id", TextCompare: false) == 0)
						{
							textBox2.Enabled = false;
						}
						textBox2.Text = Conversions.ToString(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow[column6.DataPropertyName])), "", RuntimeHelpers.GetObjectValue(dataRow[column6.DataPropertyName])));
						textBox2.Name = column6.DataPropertyName;
						textBox2.Left = 96;
						textBox2.Top = num * 25 - 3;
						textBox2 = null;
					}
					num++;
				}
				CS_0024_003C_003E8__locals129._0024VB_0024Local_v.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
				{
					CS_0024_003C_003E8__locals129._Lambda_0024__17(RuntimeHelpers.GetObjectValue(obj), (MouseEventArgs)e2);
				};
				CS_0024_003C_003E8__locals129._0024VB_0024Local_v.ShowDialog();
			};
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem();
			toolStripMenuItem7.Text = "删除勾选";
			toolStripMenuItem7.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				DataRow[] array = CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Select("check=true");
				int num = array.Length;
				for (int i = 1; i <= num; i++)
				{
					string errorStr = "";
					if (!CS_0024_003C_003E8__locals126._0024VB_0024Local_Run(string.Format("DELETE FROM {0} WHERE {1}", CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName, Operators.ConcatenateObject("id = ", array[i - 1]["id"])), errorStr))
					{
						MessageBox.Show(errorStr, "修改过程中出现错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				CS_0024_003C_003E8__locals126._0024VB_0024Local_ResList();
			};
			ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem();
			toolStripMenuItem8.Text = "修改表结构";
			toolStripMenuItem8.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				Form_EditDB form_EditDB = new Form_EditDB();
				form_EditDB.Text = "修改表结构";
				form_EditDB.DbName = CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName;
				form_EditDB.Show();
			};
			ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem();
			toolStripMenuItem9.Text = "批量导入";
			toolStripMenuItem9.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				OpenFileDialog openFileDialog = CS_0024_003C_003E8__locals126._0024VB_0024Me.vmethod_8();
				openFileDialog.Title = "选择要导入的Excel文件";
				openFileDialog.FileName = "";
				openFileDialog.Filter = "Excel 文件 (*.xls)|*.xls";
				openFileDialog.FilterIndex = 0;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Multiselect = false;
				openFileDialog.ShowDialog();
				if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
				{
					openFileDialog = null;
					if (Operators.CompareString(CS_0024_003C_003E8__locals126._0024VB_0024Me.vmethod_8().FileName, "", TextCompare: false) != 0)
					{
						new Excel_class(Class9.oleDbConnection_0, CS_0024_003C_003E8__locals126._0024VB_0024Me.vmethod_8().FileName).Import(CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName);
					}
					CS_0024_003C_003E8__locals126._0024VB_0024Local_ResList();
				}
			};
			ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem();
			toolStripMenuItem10.Text = "批量导出所有";
			toolStripMenuItem10.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				SaveFileDialog saveFileDialog = CS_0024_003C_003E8__locals126._0024VB_0024Me.vmethod_4();
				saveFileDialog.Title = "选择要导出的Excel文件位置";
				saveFileDialog.FileName = "";
				saveFileDialog.Filter = "Excel 文件 (*.xls)|*.xls|所有文件 (*.*)|*.*";
				saveFileDialog.FilterIndex = 0;
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.ShowDialog();
				if (Operators.CompareString(saveFileDialog.FileName, "", TextCompare: false) != 0)
				{
					new Excel_class(Class9.oleDbConnection_0, saveFileDialog.FileName).Export($"SELECT * FROM {CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName}");
				}
				saveFileDialog = null;
			};
			ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem();
			toolStripMenuItem11.Text = "批量导出勾选部分";
			toolStripMenuItem11.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f2: Expected O, but got Unknown
				List<int> list = new List<int>();
				SaveFileDialog saveFileDialog = CS_0024_003C_003E8__locals126._0024VB_0024Me.vmethod_4();
				saveFileDialog.Title = "选择要导出的Excel文件位置";
				saveFileDialog.FileName = "";
				saveFileDialog.Filter = "Excel 文件 (*.xls)|*.xls|所有文件 (*.*)|*.*";
				saveFileDialog.FilterIndex = 0;
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.ShowDialog();
				if (Operators.CompareString(saveFileDialog.FileName, "", TextCompare: false) != 0)
				{
					try
					{
						foreach (DataRow row4 in CS_0024_003C_003E8__locals126._0024VB_0024Local_NDataTable.Rows)
						{
							if (!Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row4["check"])) && Conversions.ToBoolean(row4["check"]))
							{
								list.Add(Conversions.ToInteger(row4["id"]));
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					try
					{
						XlsDocument val = new XlsDocument();
						val.FileName = saveFileDialog.FileName;
						Worksheet val2 = val.Workbook.Worksheets.Add("sheet1");
						using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"SELECT * FROM {CS_0024_003C_003E8__locals126._0024VB_0024Local_DbName}", Class9.oleDbConnection_0);
						using DataSet dataSet = new DataSet();
						oleDbDataAdapter.Fill(dataSet);
						if (dataSet.Tables.Count > 0)
						{
							int count = dataSet.Tables[0].Columns.Count;
							for (int i = 1; i <= count; i++)
							{
								val2.Cells.Add(1, i, (object)dataSet.Tables[0].Columns[i - 1].Caption.ToString());
							}
							int num = 2;
							int num2 = dataSet.Tables[0].Rows.Count + 1;
							for (int j = 2; j <= num2; j++)
							{
								if (list.Contains(Conversions.ToInteger(dataSet.Tables[0].Rows[j - 2]["id"])))
								{
									int count2 = dataSet.Tables[0].Columns.Count;
									for (int k = 1; k <= count2; k++)
									{
										val2.Cells.Add(num, k, (object)dataSet.Tables[0].Rows[j - 2][k - 1].ToString());
									}
									num++;
								}
							}
							val.Save();
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						MessageBox.Show(ex2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
				saveFileDialog = null;
			};
			ToolStripItemCollection items = contextMenuStrip.Items;
			items.Add(toolStripMenuItem);
			items.Add(toolStripMenuItem2);
			items.Add(new ToolStripSeparator());
			items.Add(toolStripMenuItem3);
			items.Add(toolStripMenuItem4);
			items.Add(toolStripMenuItem5);
			items.Add(new ToolStripSeparator());
			items.Add(toolStripMenuItem6);
			items.Add(toolStripMenuItem7);
			items.Add(new ToolStripSeparator());
			items.Add(toolStripMenuItem8);
			items.Add(new ToolStripSeparator());
			items.Add(toolStripMenuItem9);
			items.Add(toolStripMenuItem11);
			items.Add(toolStripMenuItem10);
		}
	}

	private void method_48(TreeNode treeNode_0, bool bool_1)
	{
		Class9.bool_0 = false;
		foreach (TreeNode node in treeNode_0.Nodes)
		{
			node.Checked = bool_1;
			method_48(node, bool_1);
		}
	}

	private void method_49(TreeNode treeNode_0)
	{
		if (treeNode_0.Checked && treeNode_0.Parent != null)
		{
			treeNode_0.Parent.Checked = true;
			method_49(treeNode_0.Parent);
		}
	}

	private void method_50(TreeNode treeNode_0)
	{
		if (treeNode_0.Checked || treeNode_0.Parent == null)
		{
			return;
		}
		foreach (TreeNode node in treeNode_0.Parent.Nodes)
		{
			if (node.Checked)
			{
				return;
			}
		}
		treeNode_0.Parent.Checked = false;
		method_50(treeNode_0.Parent);
	}

	private void method_51(object sender, EventArgs e)
	{
		_Closure_0024__62_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__62_002D0();
		CS_0024_003C_003E8__locals5._0024VB_0024Local_cn = new Form_ChangeName();
		CS_0024_003C_003E8__locals5._0024VB_0024Local_list = method_45();
		if (CS_0024_003C_003E8__locals5._0024VB_0024Local_cn.ShowDialog() != DialogResult.No)
		{
			new Thread([SpecialName] () =>
			{
				Class8.smethod_27(CS_0024_003C_003E8__locals5._0024VB_0024Local_list, CS_0024_003C_003E8__locals5._0024VB_0024Local_cn.TextBox1.Text);
			}).Start();
		}
	}

	private void method_52(object sender, EventArgs e)
	{
		foreach (DataGridViewRow selectedRow in DataGridView_DeviceList.SelectedRows)
		{
			Class9.dataTable_0.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("deviceid='", selectedRow.Cells["deviceid"].Value), "'")))[0]["check"] = true;
		}
		DataGridView_DeviceList.DataSource = Class9.dataTable_0;
	}

	private void method_53(object sender, EventArgs e)
	{
		foreach (DataGridViewRow selectedRow in DataGridView_DeviceList.SelectedRows)
		{
			Class9.dataTable_0.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("deviceid='", selectedRow.Cells["deviceid"].Value), "'")))[0]["check"] = false;
		}
		DataGridView_DeviceList.DataSource = Class9.dataTable_0;
	}

	private void rlcmBeEcdE(object sender, EventArgs e)
	{
		foreach (DataGridViewRow selectedRow in DataGridView_DeviceList.SelectedRows)
		{
			DataRow dataRow = Class9.dataTable_0.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("deviceid='", selectedRow.Cells["deviceid"].Value), "'")))[0];
			dataRow["check"] = !Conversions.ToBoolean(dataRow["check"]);
		}
		DataGridView_DeviceList.DataSource = Class9.dataTable_0;
	}

	private void method_54(object sender, EventArgs e)
	{
		bool_0 = true;
		foreach (DataRow row in Class9.dataTable_0.Rows)
		{
			row["check"] = true;
		}
		DataGridView_DeviceList.DataSource = Class9.dataTable_0;
	}

	private void method_55(object sender, EventArgs e)
	{
		string left = "";
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			left = Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(dataRow["deviceid"], "\r\n")));
		}
		try
		{
			if (Operators.CompareString(left, "", TextCompare: false) != 0)
			{
				Clipboard.SetText(left);
				MessageBox.Show("已导出设备号至剪切板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Clipboard.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_56(object sender, EventArgs e)
	{
		string left = "";
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			left = Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(dataRow["devsn"], "\r\n")));
		}
		try
		{
			if (Operators.CompareString(left, "", TextCompare: false) != 0)
			{
				Clipboard.SetText(left);
				MessageBox.Show("已导出设备号至剪切板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Clipboard.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_57(object sender, EventArgs e)
	{
		string left = "";
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			left = Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow["deviceid"], "\t"), dataRow["devsn"]), "\r\n")));
		}
		try
		{
			if (Operators.CompareString(left, "", TextCompare: false) != 0)
			{
				Clipboard.SetText(left);
				MessageBox.Show("已导出设备号至剪切板", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Clipboard.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_58(object sender, EventArgs e)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		int num = 0;
		checked
		{
			if (jarray_0 == null)
			{
				try
				{
					DataRow[] array = Class9.dataTable_0.Select("check=True");
					foreach (DataRow dataRow in array)
					{
						JArray val = (JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"];
						num = 0;
						while (num + 1 <= ((JContainer)val).Count)
						{
							JObject val2 = (JObject)val[num];
							if (Operators.ConditionalCompareObjectEqual(dataRow["deviceid"], val2["deviceid"], TextCompare: false))
							{
								((JToken)val2).Remove();
							}
							else
							{
								num++;
							}
						}
						foreach (JProperty item in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"].Children())
						{
							JArray val3 = (JArray)item.Value;
							num = 0;
							while (num + 1 <= ((JContainer)val).Count)
							{
								JObject val4 = (JObject)val3[num];
								if (Operators.ConditionalCompareObjectEqual(dataRow["deviceid"], val4["deviceid"], TextCompare: false))
								{
									((JToken)val4).Remove();
								}
								else
								{
									num++;
								}
							}
						}
						dataRow.Delete();
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
			try
			{
				JArray val5 = jarray_0;
				DataRow[] array2 = Class9.dataTable_0.Select("check=True");
				foreach (DataRow dataRow2 in array2)
				{
					num = 0;
					while (num + 1 <= ((JContainer)val5).Count)
					{
						JObject val6 = (JObject)val5[num];
						if (Operators.ConditionalCompareObjectEqual(dataRow2["deviceid"], val6["deviceid"], TextCompare: false))
						{
							((JToken)val6).Remove();
						}
						else
						{
							num++;
						}
					}
					dataRow2.Delete();
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_59(object sender, EventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (jarray_0 == null)
		{
			try
			{
				((JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"]).Clear();
				foreach (JProperty item in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"].Children())
				{
					((JArray)item.Value).Clear();
				}
				Class9.dataTable_0.Rows.Clear();
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
		}
		try
		{
			jarray_0.Clear();
			Class9.dataTable_0.Rows.Clear();
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	private void method_60(object sender, DataGridViewCellMouseEventArgs e)
	{
		MouseButtons button = e.Button;
		if (button != MouseButtons.Left || e.RowIndex != -1)
		{
			return;
		}
		if (e.ColumnIndex == 0)
		{
			bool_0 = !bool_0;
			foreach (DataGridViewRow item in (IEnumerable)DataGridView_DeviceList.Rows)
			{
				item.Cells[0].Value = bool_0;
			}
		}
		else if (Operators.CompareString(DataGridView_DeviceList.Columns[e.ColumnIndex].DataPropertyName, "ip", TextCompare: false) == 0)
		{
			Class9.dataTable_0.DefaultView.Sort = "_ip asc";
		}
		else
		{
			Class9.dataTable_0.DefaultView.Sort = Conversions.ToString(Operators.ConcatenateObject(DataGridView_DeviceList.Columns[e.ColumnIndex].DataPropertyName, Interaction.IIf(DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending, " desc", " asc")));
			if (DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
			{
				DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
			}
			else
			{
				DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
			}
		}
		Class9.jobject_3["DeviceTable"][(object)"Sort"] = JToken.op_Implicit(Class9.dataTable_0.DefaultView.Sort);
	}

	private void method_61(object sender, DataGridViewCellMouseEventArgs e)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		if (e.Button != MouseButtons.Right)
		{
			return;
		}
		ToolStripMenuItem_Group.DropDownItems.Clear();
		JObject val = (JObject)Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"];
		if (((JContainer)val).Count != 0)
		{
			using IEnumerator<JToken> enumerator = ((JContainer)val).Children().GetEnumerator();
			_Closure_0024__74_002D0 obj = default(_Closure_0024__74_002D0);
			while (enumerator.MoveNext())
			{
				obj = new _Closure_0024__74_002D0(obj);
				obj._0024VB_0024Me = this;
				obj._0024VB_0024Local__devices = (JProperty)enumerator.Current;
				string name = obj._0024VB_0024Local__devices.Name;
				ToolStripMenuItem_Group.DropDownItems.Add(name, null, obj._Lambda_0024__R25);
			}
		}
		else
		{
			ToolStripItem value = new ToolStripMenuItem
			{
				Text = "无",
				Enabled = false
			};
			ToolStripMenuItem_Group.DropDownItems.Add(value);
		}
		vmethod_0().Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
	}

	private void method_62(object sender, EventArgs e)
	{
		if (DataGridView_DeviceList.IsCurrentCellDirty)
		{
			DataGridView_DeviceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void method_63(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex == 0)
			{
				DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
				Class9.dataTable_0.Rows.Find(RuntimeHelpers.GetObjectValue(dataGridView_DeviceList.Rows[e.RowIndex].Cells["deviceid"].Value))["check"] = !Conversions.ToBoolean(dataGridView_DeviceList[e.ColumnIndex, e.RowIndex].EditedFormattedValue);
				dataGridView_DeviceList.DataSource = Class9.dataTable_0;
				dataGridView_DeviceList = null;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_64(object sender, EventArgs e)
	{
	}

	private void method_65(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (DataGridView_DeviceList.SelectedRows.Count != 0)
		{
			new _Frm_Device(RuntimeHelpers.GetObjectValue(DataGridView_DeviceList.SelectedRows[0].Cells["ip"].Value), RuntimeHelpers.GetObjectValue(DataGridView_DeviceList.SelectedRows[0].Cells["devname"].Value)).Show();
		}
	}

	private void method_66(object sender, MouseEventArgs e)
	{
		ToolStripStatusLabel_SelectDeviceNum.Text = "选择" + Conversions.ToString(DataGridView_DeviceList.SelectedRows.Count) + "台";
		ToolStripStatusLabel_CheckDeviceNum.Text = "勾选" + Conversions.ToString(Class9.dataTable_0.Select("check=True").Length) + "台";
	}

	private void method_67(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (Operators.CompareString(e.Column.Name, "ip", TextCompare: false) == 0)
		{
			string[] array = Convert.ToString(RuntimeHelpers.GetObjectValue(e.CellValue1)).Split('.');
			string[] array2 = Convert.ToString(RuntimeHelpers.GetObjectValue(e.CellValue1)).Split('.');
			if (Conversions.ToInteger(array[1]) == Conversions.ToInteger(array2[1]))
			{
				if (Conversions.ToInteger(array[2]) == Conversions.ToInteger(array2[2]))
				{
					if (Conversions.ToInteger(array[3]) == Conversions.ToInteger(array2[3]))
					{
						if (Conversions.ToInteger(array[4]) == Conversions.ToInteger(array2[4]))
						{
							e.SortResult = -1;
						}
						else
						{
							e.SortResult = 0 - ((Conversions.ToInteger(array[4]) > Conversions.ToInteger(array2[4])) ? 1 : 0);
						}
					}
					else
					{
						e.SortResult = 0 - ((Conversions.ToInteger(array[3]) > Conversions.ToInteger(array2[3])) ? 1 : 0);
					}
				}
				else
				{
					e.SortResult = 0 - ((Conversions.ToInteger(array[2]) > Conversions.ToInteger(array2[2])) ? 1 : 0);
				}
			}
			else
			{
				e.SortResult = 0 - ((Conversions.ToInteger(array[1]) > Conversions.ToInteger(array2[1])) ? 1 : 0);
			}
		}
		else
		{
			e.SortResult = string.Compare(Convert.ToString(RuntimeHelpers.GetObjectValue(e.CellValue1)), Convert.ToString(RuntimeHelpers.GetObjectValue(e.CellValue2)));
		}
		e.Handled = true;
	}

	private void method_68(object sender, EventArgs e)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		while (Class9.queue_0.Count != 0)
		{
			string[] array = (string[])Class9.queue_0.Dequeue();
			try
			{
				string text = array[0];
				string text2 = array[1];
				if (Class9.dataTable_0.Select("ip='" + text + "'").Length == 0)
				{
					continue;
				}
				if (Operators.CompareString(Strings.Mid(text2, 1, 1), "{", TextCompare: false) == 0)
				{
					try
					{
						JObject val = JObject.Parse(text2);
						foreach (JProperty item in ((JContainer)val).Children())
						{
							JProperty val2 = item;
							if (!Class9.dataTable_0.Columns.Contains(val2.Name.ToString()))
							{
								Class9.dataTable_0.Columns.Add(new DataColumn(val2.Name.ToString()));
							}
							Class9.dataTable_0.Select("ip='" + text + "'")[0][val2.Name.ToString()] = val2.Value.ToString();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					if (Operators.CompareString(Strings.Mid(text2, 1, 1), "[", TextCompare: false) != 0)
					{
						continue;
					}
					try
					{
						JArray val3 = JArray.Parse(text2);
						int num = 1;
						foreach (JValue item2 in ((JContainer)val3).Children())
						{
							JValue val4 = item2;
							if (!Class9.dataTable_0.Columns.Contains(num.ToString()))
							{
								Class9.dataTable_0.Columns.Add(new DataColumn(num.ToString()));
							}
							Class9.dataTable_0.Select("ip='" + text + "'")[0][num.ToString()] = val4.Value.ToString();
							num = checked(num + 1);
						}
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
					continue;
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_69(string string_0)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Invalid comparison between Unknown and I4
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Invalid comparison between Unknown and I4
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Invalid comparison between Unknown and I4
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Invalid comparison between Unknown and I4
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Expected O, but got Unknown
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected O, but got Unknown
		//IL_0abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected O, but got Unknown
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Expected O, but got Unknown
		_Closure_0024__82_002D0 arg = default(_Closure_0024__82_002D0);
		_Closure_0024__82_002D0 CS_0024_003C_003E8__locals24 = new _Closure_0024__82_002D0(arg);
		CS_0024_003C_003E8__locals24._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals24._0024VB_0024Local__file = string_0;
		SplitContainer1.Panel2.Controls.Clear();
		JArray val2;
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(CS_0024_003C_003E8__locals24._0024VB_0024Local__file));
			Class9.jobject_1 = (JObject)val["ScriptInfo"];
			if ((val["ScriptInfo"] != null) & (val["ScriptInfo"][(object)"Logo"] != null))
			{
				byte[] array = Convert.FromBase64String((string)val["ScriptInfo"][(object)"Logo"]);
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(array, 0, array.Length);
				ToolStripButton_ScriptInfo.Image = Image.FromStream(memoryStream);
			}
			else
			{
				ToolStripButton_ScriptInfo.Image = null;
			}
			ToolStripButton_ScriptInfo.Visible = true;
			if (val["KeyList"] != null)
			{
				Class9.jobject_2 = (JObject)val["KeyList"];
				if (((JContainer)Class9.jobject_2).Count > 0)
				{
					ToolStripButton_Push.Visible = true;
				}
				else
				{
					ToolStripButton_Push.Visible = false;
				}
			}
			else
			{
				ToolStripButton_Push.Visible = false;
			}
			val2 = (JArray)val["UI"];
			if (val["Config"] != null)
			{
				Class9.jobject_0 = (JObject)val["Config"];
			}
			else
			{
				Class9.jobject_0 = new JObject();
			}
			if (TreeView_Consultation.Nodes.Count == 2)
			{
				TreeNode treeNode = TreeView_Consultation.Nodes[1];
				treeNode.Nodes.Clear();
				foreach (JProperty item in ((JContainer)Class9.jobject_0).Children())
				{
					JProperty val3 = item;
					TreeNode treeNode2 = treeNode.Nodes.Add(val3.Name);
					if ((int)val3.Value.Type == 2)
					{
						foreach (JValue item2 in val3.Value.Children())
						{
							JValue val4 = item2;
							treeNode2.Nodes.Add(val4.ToString());
						}
					}
					else if ((int)val3.Value.Type == 9)
					{
						treeNode2.Nodes.Add(val3.Value.ToString());
					}
					else if (((int)val3.Value.Type == 8) | ((int)val3.Value.Type == 6))
					{
						treeNode2.Nodes.Add((string)val3.Value);
					}
				}
				treeNode.ExpandAll();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("出错位置:UI加载环节\r\n错误信息:" + ex2.Message, "UI加载出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			SplitContainer1.Panel2Collapsed = true;
			ToolStripButton_ScriptInfo.Visible = false;
			ToolStripButton_Push.Visible = false;
			ProjectData.ClearProjectError();
			return;
		}
		if (((JContainer)val2).Count == 0)
		{
			SplitContainer1.Panel2Collapsed = true;
			return;
		}
		CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel = new TableLayoutPanel
		{
			Parent = SplitContainer1.Panel2,
			AutoSize = true,
			ColumnCount = 2,
			RowCount = 1
		};
		CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.VerticalScroll.Enabled = true;
		SplitContainer1.Panel2.AutoScroll = true;
		CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.ColumnStyles.Add(new ColumnStyle((SizeType)200));
		CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.ColumnStyles.Add(new ColumnStyle((SizeType)200));
		CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.SetColumnSpan(new Label
		{
			Text = "",
			Dock = DockStyle.Fill,
			AutoSize = true,
			Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
		}, 2);
		checked
		{
			foreach (JObject item3 in ((JContainer)val2).Children())
			{
				JObject val5 = item3;
				JToken val6 = val5["type"];
				if ((string)val6 == "Label")
				{
					Label control = new Label
					{
						Text = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = true,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.SetColumnSpan(control, 2);
				}
				else if ((string)val6 == "Edit")
				{
					new Label
					{
						Text = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					TextBox textBox = new TextBox
					{
						Name = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					if (Class9.jobject_0[val5["caption"].ToString()] != null)
					{
						textBox.Text = Class9.jobject_0[val5["caption"].ToString()].ToString();
					}
					else
					{
						textBox.Text = val5["text"].ToString();
					}
				}
				else if ((string)val6 == "ComboBox")
				{
					new Label
					{
						Text = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					ComboBox comboBox = new ComboBox
					{
						Name = val5["caption"].ToString(),
						DropDownStyle = ComboBoxStyle.DropDownList,
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					foreach (JValue item4 in val5["item"].Children())
					{
						JValue val7 = item4;
						comboBox.Items.Add(val7.Value.ToString());
					}
					if (comboBox.Items.Count > 0)
					{
						if (Class9.jobject_0[val5["caption"].ToString()] != null)
						{
							if (((int)Class9.jobject_0[val5["caption"].ToString()] > 0) & ((int)Class9.jobject_0[val5["caption"].ToString()] <= comboBox.Items.Count))
							{
								comboBox.SelectedIndex = (int)Class9.jobject_0[val5["caption"].ToString()] - 1;
							}
						}
						else if (val5["select"] != null)
						{
							if (((int)val5["select"] > 0) & ((int)val5["select"] <= comboBox.Items.Count))
							{
								comboBox.SelectedIndex = (int)val5["select"] - 1;
							}
						}
						else
						{
							comboBox.SelectedIndex = 0;
						}
					}
				}
				else if ((string)val6 == "RadioGroup")
				{
					new Label
					{
						Text = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					ListBox listBox = new ListBox
					{
						Name = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					foreach (JValue item5 in val5["item"].Children())
					{
						JValue val8 = item5;
						listBox.Items.Add(val8.Value.ToString());
					}
					if (listBox.Items.Count > 0)
					{
						if (Class9.jobject_0[val5["caption"].ToString()] != null)
						{
							if (((int)Class9.jobject_0[val5["caption"].ToString()] > 0) & ((int)Class9.jobject_0[val5["caption"].ToString()] <= listBox.Items.Count))
							{
								listBox.SelectedIndex = (int)Class9.jobject_0[val5["caption"].ToString()] - 1;
							}
						}
						else if (val5["select"] != null)
						{
							if (((int)val5["select"] > 0) & ((int)val5["select"] <= listBox.Items.Count))
							{
								listBox.SelectedIndex = (int)val5["select"] - 1;
							}
						}
						else
						{
							listBox.SelectedIndex = 0;
						}
					}
				}
				else if ((string)val6 == "CheckBoxGroup")
				{
					new Label
					{
						Text = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					CheckedListBox checkedListBox = new CheckedListBox
					{
						Name = val5["caption"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false,
						Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel
					};
					foreach (JValue item6 in val5["item"].Children())
					{
						JValue val9 = item6;
						checkedListBox.Items.Add(val9.Value.ToString());
					}
					if (Class9.jobject_0[val5["caption"].ToString()] != null)
					{
						foreach (JValue item7 in Class9.jobject_0[val5["caption"].ToString()].Children())
						{
							JValue val10 = item7;
							if ((Conversions.ToInteger(val10.Value) > 0) & (Conversions.ToInteger(val10.Value) <= checkedListBox.Items.Count))
							{
								checkedListBox.SetItemChecked(Conversions.ToInteger(Operators.SubtractObject(val10.Value, 1)), value: true);
							}
						}
					}
					else if (val5["select"] != null)
					{
						foreach (JValue item8 in val5["select"].Children())
						{
							JValue val11 = item8;
							if ((Conversions.ToInteger(val11.Value) > 0) & (Conversions.ToInteger(val11.Value) <= checkedListBox.Items.Count))
							{
								checkedListBox.SetItemChecked(Conversions.ToInteger(Operators.SubtractObject(val11.Value, 1)), value: true);
							}
						}
					}
				}
				CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.RowCount = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.RowCount + 1;
			}
			Button button = new Button
			{
				Height = 40,
				Text = "提交",
				Dock = DockStyle.Fill
			};
			CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel.SetColumnSpan(button, 2);
			button.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				CS_0024_003C_003E8__locals24._Lambda_0024__0();
			};
			button.Parent = CS_0024_003C_003E8__locals24._0024VB_0024Local_cfg_Panel;
		}
	}

	public void ResList()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		TreeNode treeNode = TreeView_Consultation.Nodes[0];
		treeNode.Nodes.Clear();
		treeNode.Nodes.Add("全部设备");
		foreach (JProperty item in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"].Children())
		{
			JProperty val = item;
			JArray val2 = (JArray)val.Value;
			treeNode.Nodes.Add(val.Name, val.Name + "(" + Conversions.ToString(((JContainer)val2).Count) + ")");
		}
	}

	private void method_70(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			TreeNode nodeAt = TreeView_Consultation.GetNodeAt(e.X, e.Y);
			if (nodeAt != null)
			{
				TreeView_Consultation.SelectedNode = nodeAt;
			}
		}
	}

	private void method_71(object sender, TreeViewEventArgs e)
	{
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Expected O, but got Unknown
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Expected O, but got Unknown
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		TreeNode node = e.Node;
		if (node.Parent == null || node.Parent.Index != 0)
		{
			return;
		}
		_ = node.Parent;
		Class9.dataTable_0.Rows.Clear();
		if (node.Index == 0)
		{
			try
			{
				foreach (JObject item in Class9.jobject_3["DeviceTable"][(object)"Devices"].Children())
				{
					JObject val = item;
					DataRow dataRow = Class9.dataTable_0.NewRow();
					dataRow["check"] = false;
					dataRow["ip"] = val["ip"].ToString();
					string[] array = (string[])NewLateBinding.LateGet(dataRow["ip"], null, "Split", new object[1] { "." }, null, null, null);
					dataRow["_ip"] = Conversions.ToLong(array[0].PadLeft(3, '0') + array[1].PadLeft(3, '0') + array[2].PadLeft(3, '0') + array[3].PadLeft(3, '0'));
					dataRow["port"] = val["port"].ToString();
					dataRow["devname"] = val["devname"].ToString();
					dataRow["deviceid"] = val["deviceid"].ToString();
					dataRow["devmac"] = val["devmac"].ToString();
					dataRow["devsn"] = val["devsn"].ToString();
					dataRow["devtype"] = val["devtype"].ToString();
					dataRow["zeversion"] = val["zeversion"].ToString();
					dataRow["sysversion"] = val["sysversion"].ToString();
					dataRow["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["boardconfig"] == null, "", val["boardconfig"]));
					dataRow["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["ecid"] == null, "", val["ecid"]));
					dataRow["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val["buildid"] == null, "", val["buildid"]));
					Class9.dataTable_0.Rows.Add(dataRow);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				foreach (JProperty item2 in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"].Children())
				{
					_ = item2.Name;
					JArray val3 = (JArray)item2.Value;
					foreach (JToken item3 in ((JContainer)val3).Children())
					{
						if (Class9.dataTable_0.Rows.Find(item3[(object)"deviceid"].ToString()) == null)
						{
							DataRow dataRow2 = Class9.dataTable_0.NewRow();
							dataRow2["check"] = false;
							dataRow2["ip"] = item3[(object)"ip"].ToString();
							string[] array2 = item3[(object)"ip"].ToString().Split('.');
							dataRow2["_ip"] = Conversions.ToLong(array2[0].PadLeft(3, '0') + array2[1].PadLeft(3, '0') + array2[2].PadLeft(3, '0') + array2[3].PadLeft(3, '0'));
							dataRow2["port"] = item3[(object)"port"].ToString();
							dataRow2["devname"] = item3[(object)"devname"].ToString();
							dataRow2["deviceid"] = item3[(object)"deviceid"].ToString();
							dataRow2["devmac"] = item3[(object)"devmac"].ToString();
							dataRow2["devsn"] = item3[(object)"devsn"].ToString();
							dataRow2["devtype"] = item3[(object)"devtype"].ToString();
							dataRow2["zeversion"] = item3[(object)"zeversion"].ToString();
							dataRow2["sysversion"] = item3[(object)"sysversion"].ToString();
							dataRow2["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"boardconfig"] == null, "", item3[(object)"boardconfig"]));
							dataRow2["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"ecid"] == null, "", item3[(object)"ecid"]));
							dataRow2["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"buildid"] == null, "", item3[(object)"buildid"]));
							((JArray)Class9.jobject_3["DeviceTable"][(object)"Devices"]).Add((JToken)new JObject(new object[12]
							{
								(object)new JProperty("ip", (object)item3[(object)"ip"]),
								(object)new JProperty("port", (object)item3[(object)"port"]),
								(object)new JProperty("devname", (object)item3[(object)"devname"]),
								(object)new JProperty("deviceid", (object)item3[(object)"deviceid"]),
								(object)new JProperty("devmac", (object)item3[(object)"devmac"]),
								(object)new JProperty("devsn", (object)item3[(object)"devsn"]),
								(object)new JProperty("devtype", (object)item3[(object)"devtype"]),
								(object)new JProperty("zeversion", (object)item3[(object)"zeversion"]),
								(object)new JProperty("sysversion", (object)item3[(object)"sysversion"]),
								(object)new JProperty("boardconfig", RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"boardconfig"] == null, "", item3[(object)"boardconfig"]))),
								(object)new JProperty("ecid", RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"ecid"] == null, "", item3[(object)"ecid"]))),
								(object)new JProperty("buildid", RuntimeHelpers.GetObjectValue(Interaction.IIf(item3[(object)"buildid"] == null, "", item3[(object)"buildid"])))
							}));
							Class9.dataTable_0.Rows.Add(dataRow2);
						}
					}
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			jarray_0 = null;
			return;
		}
		try
		{
			foreach (JObject item4 in Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"][(object)node.Name].Children())
			{
				JObject val4 = item4;
				DataRow dataRow3 = Class9.dataTable_0.NewRow();
				dataRow3["check"] = true;
				dataRow3["ip"] = val4["ip"].ToString();
				string[] array3 = (string[])NewLateBinding.LateGet(dataRow3["ip"], null, "Split", new object[1] { "." }, null, null, null);
				dataRow3["_ip"] = Conversions.ToLong(array3[0].PadLeft(3, '0') + array3[1].PadLeft(3, '0') + array3[2].PadLeft(3, '0') + array3[3].PadLeft(3, '0'));
				dataRow3["port"] = val4["port"].ToString();
				dataRow3["devname"] = val4["devname"].ToString();
				dataRow3["deviceid"] = val4["deviceid"].ToString();
				dataRow3["devmac"] = val4["devmac"].ToString();
				dataRow3["devsn"] = val4["devsn"].ToString();
				dataRow3["devtype"] = val4["devtype"].ToString();
				dataRow3["zeversion"] = val4["zeversion"].ToString();
				dataRow3["sysversion"] = val4["sysversion"].ToString();
				dataRow3["boardconfig"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["boardconfig"] == null, "", val4["boardconfig"]));
				dataRow3["ecid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["ecid"] == null, "", val4["ecid"]));
				dataRow3["buildid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(val4["buildid"] == null, "", val4["buildid"]));
				Class9.dataTable_0.Rows.Add(dataRow3);
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		jarray_0 = (JArray)Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"][(object)node.Name];
	}

	private void method_72(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		JObject val = (JObject)Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"];
		string text = Interaction.InputBox("写入设备分组名");
		if (Operators.CompareString(text, "全部设备", TextCompare: false) == 0)
		{
			MessageBox.Show("与系统值冲突", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (text.Contains("("))
		{
			MessageBox.Show("不允许写入\"(\"字段", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		try
		{
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				if (val[text] != null)
				{
					MessageBox.Show("已存在分组", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				((JContainer)val).Add((object)new JProperty(text, (object)new JArray()));
				ResList();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_73(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		JObject val = (JObject)Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"];
		TreeNode selectedNode = TreeView_Consultation.SelectedNode;
		if (selectedNode.Parent != null && ((selectedNode.Parent.Index == 0) & (selectedNode.Index != 0)))
		{
			JArray val2 = (JArray)val[selectedNode.Name];
			string text = Interaction.InputBox("写入设备分组名");
			val[text] = (JToken)(object)val2;
			val.Remove(selectedNode.Name);
			ResList();
		}
	}

	private void method_74(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		JObject val = (JObject)Class9.jobject_3["DeviceTable"][(object)"DeviceGroups"];
		TreeNode selectedNode = TreeView_Consultation.SelectedNode;
		if (selectedNode.Parent != null && ((selectedNode.Parent.Index == 0) & (selectedNode.Index != 0)))
		{
			val.Remove(selectedNode.Name);
			ResList();
		}
	}

	private void method_75(object sender, EventArgs e)
	{
		string data = DataGridView_DeviceList.GetClipboardContent().GetText();
		Clipboard.SetData(DataFormats.Text, data);
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_Main_t));
		this.vmethod_1(new System.Windows.Forms.ContextMenuStrip(this.icontainer_0));
		this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem_Group = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_ChangeName = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem_Check_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_UnCheck_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_NotCheck_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Check_All = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_OutDeviceID = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_OutDeviceID2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.删除选中设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
		this.StatusStrip_Main = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel_SelectDeviceNum = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripStatusLabel_CheckDeviceNum = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripStatusLabel_UISet = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripStatusLabel_Port = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripContainer_Main = new System.Windows.Forms.ToolStripContainer();
		this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
		this.TreeView_Consultation = new System.Windows.Forms.TreeView();
		this.ContextMenuStrip_DeviceGroups = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.添加设备分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改设备组名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.删除此设备组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
		this.TabControl_Main = new System.Windows.Forms.TabControl();
		this.TabPage_DataGridView = new System.Windows.Forms.TabPage();
		this.DataGridView_DeviceList = new System.Windows.Forms.DataGridView();
		this.TabPage_Data = new System.Windows.Forms.TabPage();
		this.TabControl_Data = new System.Windows.Forms.TabControl();
		this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
		this.软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
		this.通讯APICCluaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.创建中控UIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.导出勾选的设备IPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.创建新的数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.关于本软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.关于XXTouchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStrip_Main = new System.Windows.Forms.ToolStrip();
		this.ToolStripButton_FindDevice = new System.Windows.Forms.ToolStripSplitButton();
		this.FindDevice_Udp = new System.Windows.Forms.ToolStripMenuItem();
		this.IP导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.IP端扫描ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripComboBox_ScriptFile = new System.Windows.Forms.ToolStripComboBox();
		this.ToolStripButton_ScriptInfo = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_Push = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_OpenScript = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripButton_SendScript = new System.Windows.Forms.ToolStripSplitButton();
		this.同步脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripButton_SendScript_Script = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripButton_SendScript_Res = new System.Windows.Forms.ToolStripMenuItem();
		this.分发数据至资源目录resToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripButton_SendScript_Lua = new System.Windows.Forms.ToolStripMenuItem();
		this.发送CClua至插件目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_Run = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_pause = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_Find_Device = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton_CheckRunning = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripButton_VersionChecking = new System.Windows.Forms.ToolStripDropDownButton();
		this.XXTouch授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.检测授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.批量授权ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.安装应用或插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.API方式安装DEBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SSH方式安装IPAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SSH扫描功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.锁屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.解锁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.备份SHSH2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改屏幕亮度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改手机音量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.用户偏好配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.vmethod_7(new System.Windows.Forms.ImageList(this.icontainer_0));
		this.vmethod_5(new System.Windows.Forms.SaveFileDialog());
		this.vmethod_9(new System.Windows.Forms.OpenFileDialog());
		this.vmethod_11(new System.Windows.Forms.NotifyIcon(this.icontainer_0));
		this.ContextMenuStrip_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.ToolStripMenuItem_Show_Hide = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
		this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.vmethod_13(new System.Windows.Forms.ToolTip(this.icontainer_0));
		this.vmethod_15(new System.Windows.Forms.Timer(this.icontainer_0));
		this.ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
		this.vmethod_0().SuspendLayout();
		this.StatusStrip_Main.SuspendLayout();
		this.ToolStripContainer_Main.BottomToolStripPanel.SuspendLayout();
		this.ToolStripContainer_Main.ContentPanel.SuspendLayout();
		this.ToolStripContainer_Main.TopToolStripPanel.SuspendLayout();
		this.ToolStripContainer_Main.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer2).BeginInit();
		this.SplitContainer2.Panel1.SuspendLayout();
		this.SplitContainer2.Panel2.SuspendLayout();
		this.SplitContainer2.SuspendLayout();
		this.ContextMenuStrip_DeviceGroups.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
		this.SplitContainer1.Panel1.SuspendLayout();
		this.SplitContainer1.SuspendLayout();
		this.TabControl_Main.SuspendLayout();
		this.TabPage_DataGridView.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).BeginInit();
		this.TabPage_Data.SuspendLayout();
		this.MenuStrip_Main.SuspendLayout();
		this.ToolStrip_Main.SuspendLayout();
		this.ContextMenuStrip_NotifyIcon.SuspendLayout();
		base.SuspendLayout();
		this.vmethod_0().Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
		{
			this.SearchToolStripMenuItem, this.ToolStripSeparator1, this.ToolStripMenuItem_Group, this.ToolStripMenuItem_ChangeName, this.ToolStripSeparator12, this.ToolStripMenuItem5, this.ToolStripSeparator5, this.ToolStripMenuItem_Check_Select, this.ToolStripMenuItem_UnCheck_Select, this.ToolStripMenuItem_NotCheck_Select,
			this.ToolStripMenuItem_Check_All, this.ToolStripSeparator6, this.ToolStripMenuItem_OutDeviceID, this.ToolStripMenuItem3, this.ToolStripMenuItem_OutDeviceID2, this.ToolStripSeparator4, this.删除选中设备ToolStripMenuItem, this.ToolStripMenuItem_Clear
		});
		this.vmethod_0().Name = "ContextMenuStrip_List";
		this.vmethod_0().ShowImageMargin = false;
		this.vmethod_0().Size = new System.Drawing.Size(181, 342);
		this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
		this.SearchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
		this.SearchToolStripMenuItem.Text = "搜索设备";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new System.Drawing.Size(156, 6);
		this.ToolStripMenuItem_Group.Name = "ToolStripMenuItem_Group";
		this.ToolStripMenuItem_Group.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_Group.Text = "添加到分组";
		this.ToolStripMenuItem_ChangeName.Name = "ToolStripMenuItem_ChangeName";
		this.ToolStripMenuItem_ChangeName.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_ChangeName.Text = "重命名";
		this.ToolStripSeparator5.Name = "ToolStripSeparator5";
		this.ToolStripSeparator5.Size = new System.Drawing.Size(156, 6);
		this.ToolStripMenuItem_Check_Select.Name = "ToolStripMenuItem_Check_Select";
		this.ToolStripMenuItem_Check_Select.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_Check_Select.Text = "勾选选择";
		this.ToolStripMenuItem_UnCheck_Select.Name = "ToolStripMenuItem_UnCheck_Select";
		this.ToolStripMenuItem_UnCheck_Select.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_UnCheck_Select.Text = "不勾选选择";
		this.ToolStripMenuItem_NotCheck_Select.Name = "ToolStripMenuItem_NotCheck_Select";
		this.ToolStripMenuItem_NotCheck_Select.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_NotCheck_Select.Text = "反向勾选选择";
		this.ToolStripMenuItem_Check_All.Name = "ToolStripMenuItem_Check_All";
		this.ToolStripMenuItem_Check_All.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_Check_All.Text = "全部勾选";
		this.ToolStripSeparator6.Name = "ToolStripSeparator6";
		this.ToolStripSeparator6.Size = new System.Drawing.Size(156, 6);
		this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
		this.ToolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
		this.ToolStripMenuItem5.Text = "复制选中行（Ctrl + C）";
		this.ToolStripMenuItem_OutDeviceID.Name = "ToolStripMenuItem_OutDeviceID";
		this.ToolStripMenuItem_OutDeviceID.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_OutDeviceID.Text = "导出设备号";
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		this.ToolStripMenuItem3.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem3.Text = "导出设备序列号";
		this.ToolStripMenuItem_OutDeviceID2.Name = "ToolStripMenuItem_OutDeviceID2";
		this.ToolStripMenuItem_OutDeviceID2.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_OutDeviceID2.Text = "导出设备号与序列号";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		this.ToolStripSeparator4.Size = new System.Drawing.Size(156, 6);
		this.删除选中设备ToolStripMenuItem.Name = "删除选中设备ToolStripMenuItem";
		this.删除选中设备ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
		this.删除选中设备ToolStripMenuItem.Text = "删除选中设备";
		this.ToolStripMenuItem_Clear.Name = "ToolStripMenuItem_Clear";
		this.ToolStripMenuItem_Clear.Size = new System.Drawing.Size(159, 22);
		this.ToolStripMenuItem_Clear.Text = "清空设备列表";
		this.StatusStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
		this.StatusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.ToolStripStatusLabel_SelectDeviceNum, this.ToolStripStatusLabel_CheckDeviceNum, this.ToolStripStatusLabel_UISet, this.ToolStripStatusLabel_Port });
		this.StatusStrip_Main.Location = new System.Drawing.Point(0, 0);
		this.StatusStrip_Main.Name = "StatusStrip_Main";
		this.StatusStrip_Main.Size = new System.Drawing.Size(1106, 22);
		this.StatusStrip_Main.TabIndex = 2;
		this.StatusStrip_Main.Text = "StatusStrip1";
		this.ToolStripStatusLabel_SelectDeviceNum.Name = "ToolStripStatusLabel_SelectDeviceNum";
		this.ToolStripStatusLabel_SelectDeviceNum.Size = new System.Drawing.Size(51, 17);
		this.ToolStripStatusLabel_SelectDeviceNum.Text = "选择0台";
		this.ToolStripStatusLabel_CheckDeviceNum.Name = "ToolStripStatusLabel_CheckDeviceNum";
		this.ToolStripStatusLabel_CheckDeviceNum.Size = new System.Drawing.Size(51, 17);
		this.ToolStripStatusLabel_CheckDeviceNum.Text = "勾选0台";
		this.ToolStripStatusLabel_UISet.Name = "ToolStripStatusLabel_UISet";
		this.ToolStripStatusLabel_UISet.Size = new System.Drawing.Size(921, 17);
		this.ToolStripStatusLabel_UISet.Spring = true;
		this.ToolStripStatusLabel_UISet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolStripStatusLabel_Port.Name = "ToolStripStatusLabel_Port";
		this.ToolStripStatusLabel_Port.Size = new System.Drawing.Size(68, 17);
		this.ToolStripStatusLabel_Port.Text = "监听  UDP:";
		this.ToolStripStatusLabel_Port.ToolTipText = "当前与设备通讯所使用的 API 端口";
		this.ToolStripContainer_Main.BottomToolStripPanel.Controls.Add(this.StatusStrip_Main);
		this.ToolStripContainer_Main.ContentPanel.Controls.Add(this.SplitContainer2);
		this.ToolStripContainer_Main.ContentPanel.Size = new System.Drawing.Size(1106, 510);
		this.ToolStripContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ToolStripContainer_Main.Location = new System.Drawing.Point(0, 0);
		this.ToolStripContainer_Main.Name = "ToolStripContainer_Main";
		this.ToolStripContainer_Main.Size = new System.Drawing.Size(1106, 605);
		this.ToolStripContainer_Main.TabIndex = 3;
		this.ToolStripContainer_Main.Text = "ToolStripContainer1";
		this.ToolStripContainer_Main.TopToolStripPanel.Controls.Add(this.MenuStrip_Main);
		this.ToolStripContainer_Main.TopToolStripPanel.Controls.Add(this.ToolStrip_Main);
		this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
		this.SplitContainer2.Name = "SplitContainer2";
		this.SplitContainer2.Panel1.Controls.Add(this.TreeView_Consultation);
		this.SplitContainer2.Panel2.Controls.Add(this.SplitContainer1);
		this.SplitContainer2.Size = new System.Drawing.Size(1106, 510);
		this.SplitContainer2.SplitterDistance = 160;
		this.SplitContainer2.SplitterWidth = 6;
		this.SplitContainer2.TabIndex = 2;
		this.TreeView_Consultation.ContextMenuStrip = this.ContextMenuStrip_DeviceGroups;
		this.TreeView_Consultation.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TreeView_Consultation.Location = new System.Drawing.Point(0, 0);
		this.TreeView_Consultation.Name = "TreeView_Consultation";
		this.TreeView_Consultation.Size = new System.Drawing.Size(160, 510);
		this.TreeView_Consultation.TabIndex = 2;
		this.ContextMenuStrip_DeviceGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.添加设备分组ToolStripMenuItem, this.修改设备组名ToolStripMenuItem, this.删除此设备组ToolStripMenuItem });
		this.ContextMenuStrip_DeviceGroups.Name = "ContextMenuStrip_DeviceGroups";
		this.ContextMenuStrip_DeviceGroups.Size = new System.Drawing.Size(149, 70);
		this.添加设备分组ToolStripMenuItem.Name = "添加设备分组ToolStripMenuItem";
		this.添加设备分组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
		this.添加设备分组ToolStripMenuItem.Text = "添加设备分组";
		this.修改设备组名ToolStripMenuItem.Name = "修改设备组名ToolStripMenuItem";
		this.修改设备组名ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
		this.修改设备组名ToolStripMenuItem.Text = "修改设备组名";
		this.删除此设备组ToolStripMenuItem.Name = "删除此设备组ToolStripMenuItem";
		this.删除此设备组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
		this.删除此设备组ToolStripMenuItem.Text = "删除此设备组";
		this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
		this.SplitContainer1.Name = "SplitContainer1";
		this.SplitContainer1.Panel1.Controls.Add(this.TabControl_Main);
		this.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.SplitContainer1.Panel1MinSize = 10;
		this.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.SplitContainer1.Panel2MinSize = 250;
		this.SplitContainer1.Size = new System.Drawing.Size(940, 510);
		this.SplitContainer1.SplitterDistance = 686;
		this.SplitContainer1.TabIndex = 1;
		this.TabControl_Main.Controls.Add(this.TabPage_DataGridView);
		this.TabControl_Main.Controls.Add(this.TabPage_Data);
		this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
		this.TabControl_Main.Name = "TabControl_Main";
		this.TabControl_Main.SelectedIndex = 0;
		this.TabControl_Main.Size = new System.Drawing.Size(686, 510);
		this.TabControl_Main.TabIndex = 0;
		this.TabPage_DataGridView.Controls.Add(this.DataGridView_DeviceList);
		this.TabPage_DataGridView.Location = new System.Drawing.Point(4, 22);
		this.TabPage_DataGridView.Name = "TabPage_DataGridView";
		this.TabPage_DataGridView.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage_DataGridView.Size = new System.Drawing.Size(678, 484);
		this.TabPage_DataGridView.TabIndex = 1;
		this.TabPage_DataGridView.Text = "设备表";
		this.TabPage_DataGridView.UseVisualStyleBackColor = true;
		this.DataGridView_DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DataGridView_DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DataGridView_DeviceList.Location = new System.Drawing.Point(3, 3);
		this.DataGridView_DeviceList.Name = "DataGridView_DeviceList";
		this.DataGridView_DeviceList.RowTemplate.Height = 23;
		this.DataGridView_DeviceList.Size = new System.Drawing.Size(672, 478);
		this.DataGridView_DeviceList.TabIndex = 0;
		this.TabPage_Data.Controls.Add(this.TabControl_Data);
		this.TabPage_Data.Location = new System.Drawing.Point(4, 22);
		this.TabPage_Data.Name = "TabPage_Data";
		this.TabPage_Data.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage_Data.Size = new System.Drawing.Size(678, 484);
		this.TabPage_Data.TabIndex = 2;
		this.TabPage_Data.Text = "数据表";
		this.TabPage_Data.UseVisualStyleBackColor = true;
		this.TabControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TabControl_Data.Location = new System.Drawing.Point(3, 3);
		this.TabControl_Data.Name = "TabControl_Data";
		this.TabControl_Data.SelectedIndex = 0;
		this.TabControl_Data.Size = new System.Drawing.Size(672, 478);
		this.TabControl_Data.TabIndex = 0;
		this.MenuStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
		this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.软件ToolStripMenuItem, this.项目ToolStripMenuItem, this.设备ToolStripMenuItem, this.数据库ToolStripMenuItem, this.关于ToolStripMenuItem });
		this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
		this.MenuStrip_Main.Name = "MenuStrip_Main";
		this.MenuStrip_Main.Size = new System.Drawing.Size(1106, 25);
		this.MenuStrip_Main.TabIndex = 1;
		this.MenuStrip_Main.Text = "MenuStrip1";
		this.软件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.配置ToolStripMenuItem, this.ToolStripSeparator11, this.通讯APICCluaToolStripMenuItem });
		this.软件ToolStripMenuItem.Name = "软件ToolStripMenuItem";
		this.软件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
		this.软件ToolStripMenuItem.Text = "软件";
		this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
		this.配置ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.配置ToolStripMenuItem.Text = "配置";
		this.ToolStripSeparator11.Name = "ToolStripSeparator11";
		this.ToolStripSeparator11.Size = new System.Drawing.Size(160, 6);
		this.通讯APICCluaToolStripMenuItem.Name = "通讯APICCluaToolStripMenuItem";
		this.通讯APICCluaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.通讯APICCluaToolStripMenuItem.Text = "通讯API(CC.lua)";
		this.项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.创建中控UIToolStripMenuItem });
		this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
		this.项目ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
		this.项目ToolStripMenuItem.Text = "项目";
		this.创建中控UIToolStripMenuItem.Name = "创建中控UIToolStripMenuItem";
		this.创建中控UIToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
		this.创建中控UIToolStripMenuItem.Text = "创建中控UI";
		this.设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.导出勾选的设备IPToolStripMenuItem });
		this.设备ToolStripMenuItem.Name = "设备ToolStripMenuItem";
		this.设备ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
		this.设备ToolStripMenuItem.Text = "设备";
		this.导出勾选的设备IPToolStripMenuItem.Name = "导出勾选的设备IPToolStripMenuItem";
		this.导出勾选的设备IPToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		this.导出勾选的设备IPToolStripMenuItem.Text = "导出勾选的设备IP";
		this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.创建新的数据表ToolStripMenuItem });
		this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
		this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
		this.数据库ToolStripMenuItem.Text = "数据库";
		this.创建新的数据表ToolStripMenuItem.Name = "创建新的数据表ToolStripMenuItem";
		this.创建新的数据表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.创建新的数据表ToolStripMenuItem.Text = "创建新的数据表";
		this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.关于本软件ToolStripMenuItem, this.关于XXTouchToolStripMenuItem });
		this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
		this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
		this.关于ToolStripMenuItem.Text = "关于";
		this.关于本软件ToolStripMenuItem.Name = "关于本软件ToolStripMenuItem";
		this.关于本软件ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
		this.关于本软件ToolStripMenuItem.Text = "关于本软件";
		this.关于XXTouchToolStripMenuItem.Name = "关于XXTouchToolStripMenuItem";
		this.关于XXTouchToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
		this.关于XXTouchToolStripMenuItem.Text = "关于XXTouch";
		this.ToolStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
		this.ToolStrip_Main.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.ToolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[17]
		{
			this.ToolStripButton_FindDevice, this.ToolStripSeparator7, this.ToolStripComboBox_ScriptFile, this.ToolStripButton_ScriptInfo, this.ToolStripButton_Push, this.ToolStripButton_OpenScript, this.ToolStripSeparator8, this.ToolStripButton_SendScript, this.ToolStripButton1, this.ToolStripButton_Run,
			this.ToolStripButton_pause, this.ToolStripButton2, this.ToolStripButton_Stop, this.ToolStripButton_Find_Device, this.ToolStripButton_CheckRunning, this.ToolStripSeparator9, this.ToolStripButton_VersionChecking
		});
		this.ToolStrip_Main.Location = new System.Drawing.Point(3, 25);
		this.ToolStrip_Main.Name = "ToolStrip_Main";
		this.ToolStrip_Main.Size = new System.Drawing.Size(1057, 48);
		this.ToolStrip_Main.TabIndex = 0;
		this.ToolStripButton_FindDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.FindDevice_Udp, this.IP导入ToolStripMenuItem, this.IP端扫描ToolStripMenuItem });
		this.ToolStripButton_FindDevice.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_FindDevice.Image");
		this.ToolStripButton_FindDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_FindDevice.Name = "ToolStripButton_FindDevice";
		this.ToolStripButton_FindDevice.Size = new System.Drawing.Size(72, 45);
		this.ToolStripButton_FindDevice.Text = "搜索设备";
		this.ToolStripButton_FindDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_FindDevice.ToolTipText = "使用UDP广播协议进行发出中控存在位置";
		this.FindDevice_Udp.Name = "FindDevice_Udp";
		this.FindDevice_Udp.Size = new System.Drawing.Size(135, 22);
		this.FindDevice_Udp.Text = "快速扫描";
		this.FindDevice_Udp.ToolTipText = "使用UDP广播协议进行发出中控存在位置";
		this.IP导入ToolStripMenuItem.Name = "IP导入ToolStripMenuItem";
		this.IP导入ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
		this.IP导入ToolStripMenuItem.Text = "IP地址扫描";
		this.IP导入ToolStripMenuItem.ToolTipText = "选择IP列表文本文件进行逐一TCP尝试46952（XXTouch默认端口）通讯";
		this.IP端扫描ToolStripMenuItem.Name = "IP端扫描ToolStripMenuItem";
		this.IP端扫描ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
		this.IP端扫描ToolStripMenuItem.Text = "网段扫描";
		this.IP端扫描ToolStripMenuItem.ToolTipText = "界面内进行选择网段选择协议方式进行发出中控存在位置";
		this.ToolStripSeparator7.Name = "ToolStripSeparator7";
		this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 48);
		this.ToolStripComboBox_ScriptFile.Name = "ToolStripComboBox_ScriptFile";
		this.ToolStripComboBox_ScriptFile.Size = new System.Drawing.Size(200, 48);
		this.ToolStripButton_ScriptInfo.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_ScriptInfo.Image");
		this.ToolStripButton_ScriptInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_ScriptInfo.Name = "ToolStripButton_ScriptInfo";
		this.ToolStripButton_ScriptInfo.Size = new System.Drawing.Size(72, 45);
		this.ToolStripButton_ScriptInfo.Text = "关于本脚本";
		this.ToolStripButton_ScriptInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Push.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_Push.Image");
		this.ToolStripButton_Push.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_Push.Name = "ToolStripButton_Push";
		this.ToolStripButton_Push.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_Push.Text = "推送内容";
		this.ToolStripButton_Push.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Push.ToolTipText = "推送特征信息至设备进程字典内";
		this.ToolStripButton_OpenScript.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_OpenScript.Image");
		this.ToolStripButton_OpenScript.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_OpenScript.Name = "ToolStripButton_OpenScript";
		this.ToolStripButton_OpenScript.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_OpenScript.Text = "打开脚本";
		this.ToolStripButton_OpenScript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_OpenScript.ToolTipText = "选择一个可以运行的脚本文件";
		this.ToolStripSeparator8.Name = "ToolStripSeparator8";
		this.ToolStripSeparator8.Size = new System.Drawing.Size(6, 48);
		this.ToolStripButton_SendScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.同步脚本ToolStripMenuItem, this.ToolStripButton_SendScript_Script, this.ToolStripButton_SendScript_Res, this.分发数据至资源目录resToolStripMenuItem, this.ToolStripButton_SendScript_Lua, this.发送CClua至插件目录ToolStripMenuItem });
		this.ToolStripButton_SendScript.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_SendScript.Image");
		this.ToolStripButton_SendScript.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_SendScript.Name = "ToolStripButton_SendScript";
		this.ToolStripButton_SendScript.Size = new System.Drawing.Size(72, 45);
		this.ToolStripButton_SendScript.Text = "发送脚本";
		this.ToolStripButton_SendScript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_SendScript.ToolTipText = "发送脚本至\"lua/scripts\"目录下";
		this.同步脚本ToolStripMenuItem.Name = "同步脚本ToolStripMenuItem";
		this.同步脚本ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
		this.同步脚本ToolStripMenuItem.Text = "同步主目录(1ferver)";
		this.同步脚本ToolStripMenuItem.ToolTipText = "与主程序相同目录下的\"1ferver\"目录进行同步操作";
		this.ToolStripButton_SendScript_Script.Name = "ToolStripButton_SendScript_Script";
		this.ToolStripButton_SendScript_Script.Size = new System.Drawing.Size(210, 22);
		this.ToolStripButton_SendScript_Script.Text = "发送脚本目录(lua/script)";
		this.ToolStripButton_SendScript_Script.ToolTipText = "发送文件至脚本目录";
		this.ToolStripButton_SendScript_Res.Name = "ToolStripButton_SendScript_Res";
		this.ToolStripButton_SendScript_Res.Size = new System.Drawing.Size(210, 22);
		this.ToolStripButton_SendScript_Res.Text = "发送资源目录(res)";
		this.ToolStripButton_SendScript_Res.ToolTipText = "发送文件至资源目录";
		this.分发数据至资源目录resToolStripMenuItem.Name = "分发数据至资源目录resToolStripMenuItem";
		this.分发数据至资源目录resToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
		this.分发数据至资源目录resToolStripMenuItem.Text = "分发数据至资源目录(res)";
		this.ToolStripButton_SendScript_Lua.Name = "ToolStripButton_SendScript_Lua";
		this.ToolStripButton_SendScript_Lua.Size = new System.Drawing.Size(210, 22);
		this.ToolStripButton_SendScript_Lua.Text = "发送插件目录(lua)";
		this.ToolStripButton_SendScript_Lua.ToolTipText = "发送文件至插件目录";
		this.发送CClua至插件目录ToolStripMenuItem.Name = "发送CClua至插件目录ToolStripMenuItem";
		this.发送CClua至插件目录ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
		this.发送CClua至插件目录ToolStripMenuItem.Text = "发送CC.lua至插件目录";
		this.发送CClua至插件目录ToolStripMenuItem.ToolTipText = "中控API操作库发送至插件目录";
		this.ToolStripButton1.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton1.Image");
		this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton1.Name = "ToolStripButton1";
		this.ToolStripButton1.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton1.Text = "发至相册";
		this.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton1.ToolTipText = "发送至系统相册";
		this.ToolStripButton_Run.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_Run.Image");
		this.ToolStripButton_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_Run.Name = "ToolStripButton_Run";
		this.ToolStripButton_Run.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_Run.Text = "运行脚本";
		this.ToolStripButton_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Run.ToolTipText = "选择的设备进行运行当前选择的脚本或项目";
		this.ToolStripButton_pause.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_pause.Image");
		this.ToolStripButton_pause.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_pause.Name = "ToolStripButton_pause";
		this.ToolStripButton_pause.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_pause.Text = "暂停脚本";
		this.ToolStripButton_pause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton2.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton2.Image");
		this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton2.Name = "ToolStripButton2";
		this.ToolStripButton2.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton2.Text = "继续脚本";
		this.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Stop.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_Stop.Image");
		this.ToolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_Stop.Name = "ToolStripButton_Stop";
		this.ToolStripButton_Stop.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_Stop.Text = "停止脚本";
		this.ToolStripButton_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Stop.ToolTipText = "选择的设备停止脚本";
		this.ToolStripButton_Find_Device.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_Find_Device.Image");
		this.ToolStripButton_Find_Device.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_Find_Device.Name = "ToolStripButton_Find_Device";
		this.ToolStripButton_Find_Device.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_Find_Device.Text = "定位设备";
		this.ToolStripButton_Find_Device.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_Find_Device.ToolTipText = "以设备屏幕闪烁为触发方式进行定位设备所在位置";
		this.ToolStripButton_CheckRunning.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_CheckRunning.Image");
		this.ToolStripButton_CheckRunning.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_CheckRunning.Name = "ToolStripButton_CheckRunning";
		this.ToolStripButton_CheckRunning.Size = new System.Drawing.Size(60, 45);
		this.ToolStripButton_CheckRunning.Text = "检测状态";
		this.ToolStripButton_CheckRunning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.ToolStripButton_CheckRunning.ToolTipText = "检测当前选择设备是否处于运行脚本状态";
		this.ToolStripSeparator9.Name = "ToolStripSeparator9";
		this.ToolStripSeparator9.Size = new System.Drawing.Size(6, 48);
		this.ToolStripButton_VersionChecking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.XXTouch授权ToolStripMenuItem, this.安装应用或插件ToolStripMenuItem, this.ToolStripMenuItem1, this.ToolStripMenuItem2, this.ToolStripMenuItem4, this.修改屏幕亮度ToolStripMenuItem, this.修改手机音量ToolStripMenuItem, this.用户偏好配置ToolStripMenuItem });
		this.ToolStripButton_VersionChecking.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton_VersionChecking.Image");
		this.ToolStripButton_VersionChecking.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton_VersionChecking.Name = "ToolStripButton_VersionChecking";
		this.ToolStripButton_VersionChecking.Size = new System.Drawing.Size(69, 45);
		this.ToolStripButton_VersionChecking.Text = "其他功能";
		this.ToolStripButton_VersionChecking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		this.XXTouch授权ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.检测授权ToolStripMenuItem, this.批量授权ToolStripMenuItem1 });
		this.XXTouch授权ToolStripMenuItem.Name = "XXTouch授权ToolStripMenuItem";
		this.XXTouch授权ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.XXTouch授权ToolStripMenuItem.Text = "XXTouch授权";
		this.检测授权ToolStripMenuItem.Name = "检测授权ToolStripMenuItem";
		this.检测授权ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
		this.检测授权ToolStripMenuItem.Text = "检测授权";
		this.检测授权ToolStripMenuItem.ToolTipText = "检测当前选择设备到期时间";
		this.批量授权ToolStripMenuItem1.Name = "批量授权ToolStripMenuItem1";
		this.批量授权ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
		this.批量授权ToolStripMenuItem1.Text = "批量授权";
		this.批量授权ToolStripMenuItem1.ToolTipText = "批量进行针对选择的设备进行授权操作";
		this.安装应用或插件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.API方式安装DEBToolStripMenuItem, this.SSH方式安装IPAToolStripMenuItem, this.SSH扫描功能ToolStripMenuItem });
		this.安装应用或插件ToolStripMenuItem.Name = "安装应用或插件ToolStripMenuItem";
		this.安装应用或插件ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.安装应用或插件ToolStripMenuItem.Text = "安装应用或插件";
		this.API方式安装DEBToolStripMenuItem.Name = "API方式安装DEBToolStripMenuItem";
		this.API方式安装DEBToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		this.API方式安装DEBToolStripMenuItem.Text = "API方式安装DEB";
		this.API方式安装DEBToolStripMenuItem.ToolTipText = "以 XXTouch API 方式进行安装 deb 安装包";
		this.SSH方式安装IPAToolStripMenuItem.Name = "SSH方式安装IPAToolStripMenuItem";
		this.SSH方式安装IPAToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		this.SSH方式安装IPAToolStripMenuItem.Text = "SSH方式安装IPA";
		this.SSH方式安装IPAToolStripMenuItem.ToolTipText = "使用 SSH 方法进行安装 IPA 文件操作";
		this.SSH扫描功能ToolStripMenuItem.Name = "SSH扫描功能ToolStripMenuItem";
		this.SSH扫描功能ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		this.SSH扫描功能ToolStripMenuItem.Text = "SSH扫描功能";
		this.SSH扫描功能ToolStripMenuItem.ToolTipText = "扫描当前网段内的 22 端口设备，使用 OpenSSH 进行远端操作。（此功能可远程安装 XXTouch）";
		this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.关机ToolStripMenuItem, this.重启ToolStripMenuItem, this.注销ToolStripMenuItem });
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
		this.ToolStripMenuItem1.Text = "关机&&重启";
		this.关机ToolStripMenuItem.Name = "关机ToolStripMenuItem";
		this.关机ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.关机ToolStripMenuItem.Text = "关机";
		this.关机ToolStripMenuItem.ToolTipText = "当前选择设备进行关机操作";
		this.重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
		this.重启ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.重启ToolStripMenuItem.Text = "重启";
		this.重启ToolStripMenuItem.ToolTipText = "当前选择设备进行重启操作";
		this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
		this.注销ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.注销ToolStripMenuItem.Text = "注销";
		this.注销ToolStripMenuItem.ToolTipText = "当前选择设备进行注销操作";
		this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.锁屏ToolStripMenuItem, this.解锁ToolStripMenuItem });
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
		this.ToolStripMenuItem2.Text = "锁屏&&解锁";
		this.锁屏ToolStripMenuItem.Name = "锁屏ToolStripMenuItem";
		this.锁屏ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.锁屏ToolStripMenuItem.Text = "锁屏";
		this.锁屏ToolStripMenuItem.ToolTipText = "当前选择设备进行锁屏操作";
		this.解锁ToolStripMenuItem.Name = "解锁ToolStripMenuItem";
		this.解锁ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.解锁ToolStripMenuItem.Text = "解锁";
		this.解锁ToolStripMenuItem.ToolTipText = "当前选择设备进行解锁屏操作";
		this.ToolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.备份SHSH2ToolStripMenuItem });
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		this.ToolStripMenuItem4.Size = new System.Drawing.Size(160, 22);
		this.ToolStripMenuItem4.Text = "附加功能";
		this.备份SHSH2ToolStripMenuItem.Name = "备份SHSH2ToolStripMenuItem";
		this.备份SHSH2ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
		this.备份SHSH2ToolStripMenuItem.Text = "备份SHSH2";
		this.修改屏幕亮度ToolStripMenuItem.Name = "修改屏幕亮度ToolStripMenuItem";
		this.修改屏幕亮度ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.修改屏幕亮度ToolStripMenuItem.Text = "修改屏幕亮度";
		this.修改屏幕亮度ToolStripMenuItem.ToolTipText = "修改设备当前屏幕亮度";
		this.修改手机音量ToolStripMenuItem.Name = "修改手机音量ToolStripMenuItem";
		this.修改手机音量ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.修改手机音量ToolStripMenuItem.Text = "修改手机音量";
		this.修改手机音量ToolStripMenuItem.ToolTipText = "修改设备当前的音量";
		this.用户偏好配置ToolStripMenuItem.Name = "用户偏好配置ToolStripMenuItem";
		this.用户偏好配置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
		this.用户偏好配置ToolStripMenuItem.Text = "用户偏好配置";
		this.用户偏好配置ToolStripMenuItem.ToolTipText = "用于设置设备端各种状态以确保设备的稳定运行";
		this.vmethod_6().ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList_ListView.ImageStream");
		this.vmethod_6().TransparentColor = System.Drawing.Color.Transparent;
		this.vmethod_6().Images.SetKeyName(0, "group_39.835182250396px_1202761_easyicon.net.png");
		this.vmethod_8().FileName = "打开";
		this.vmethod_10().ContextMenuStrip = this.ContextMenuStrip_NotifyIcon;
		this.vmethod_10().Icon = (System.Drawing.Icon)resources.GetObject("NotifyIcon_Main.Icon");
		this.vmethod_10().Text = "XXTouch 中控";
		this.vmethod_10().Visible = true;
		this.ContextMenuStrip_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.ToolStripMenuItem_Show_Hide, this.ToolStripSeparator10, this.退出ToolStripMenuItem });
		this.ContextMenuStrip_NotifyIcon.Name = "ContextMenuStrip_NotifyIcon";
		this.ContextMenuStrip_NotifyIcon.Size = new System.Drawing.Size(135, 54);
		this.ToolStripMenuItem_Show_Hide.Name = "ToolStripMenuItem_Show_Hide";
		this.ToolStripMenuItem_Show_Hide.Size = new System.Drawing.Size(134, 22);
		this.ToolStripMenuItem_Show_Hide.Text = "显示&&隐藏";
		this.ToolStripSeparator10.Name = "ToolStripSeparator10";
		this.ToolStripSeparator10.Size = new System.Drawing.Size(131, 6);
		this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
		this.退出ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
		this.退出ToolStripMenuItem.Text = "退出";
		this.vmethod_14().Enabled = true;
		this.vmethod_14().Interval = 500;
		this.ToolStripSeparator12.Name = "ToolStripSeparator12";
		this.ToolStripSeparator12.Size = new System.Drawing.Size(156, 6);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1106, 605);
		base.Controls.Add(this.ToolStripContainer_Main);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.MenuStrip_Main;
		this.MinimumSize = new System.Drawing.Size(940, 550);
		base.Name = "Form_Main_t";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "蜘蛛侠中控";
		this.vmethod_0().ResumeLayout(false);
		this.StatusStrip_Main.ResumeLayout(false);
		this.StatusStrip_Main.PerformLayout();
		this.ToolStripContainer_Main.BottomToolStripPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.BottomToolStripPanel.PerformLayout();
		this.ToolStripContainer_Main.ContentPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.TopToolStripPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.TopToolStripPanel.PerformLayout();
		this.ToolStripContainer_Main.ResumeLayout(false);
		this.ToolStripContainer_Main.PerformLayout();
		this.SplitContainer2.Panel1.ResumeLayout(false);
		this.SplitContainer2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer2).EndInit();
		this.SplitContainer2.ResumeLayout(false);
		this.ContextMenuStrip_DeviceGroups.ResumeLayout(false);
		this.SplitContainer1.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
		this.SplitContainer1.ResumeLayout(false);
		this.TabControl_Main.ResumeLayout(false);
		this.TabPage_DataGridView.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).EndInit();
		this.TabPage_Data.ResumeLayout(false);
		this.MenuStrip_Main.ResumeLayout(false);
		this.MenuStrip_Main.PerformLayout();
		this.ToolStrip_Main.ResumeLayout(false);
		this.ToolStrip_Main.PerformLayout();
		this.ContextMenuStrip_NotifyIcon.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ContextMenuStrip vmethod_0()
	{
		return contextMenuStrip_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_1(ContextMenuStrip WithEventsValue)
	{
		contextMenuStrip_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolStripSeparator wDmcUkYmNc()
	{
		return toolStripSeparator_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_2(ToolStripSeparator WithEventsValue)
	{
		toolStripSeparator_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolStripSeparator jhicppZkHv()
	{
		return toolStripSeparator_1;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_3(ToolStripSeparator WithEventsValue)
	{
		toolStripSeparator_1 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual SaveFileDialog vmethod_4()
	{
		return saveFileDialog_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_5(SaveFileDialog WithEventsValue)
	{
		saveFileDialog_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ImageList vmethod_6()
	{
		return imageList_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_7(ImageList WithEventsValue)
	{
		imageList_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual OpenFileDialog vmethod_8()
	{
		return openFileDialog_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_9(OpenFileDialog WithEventsValue)
	{
		openFileDialog_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual NotifyIcon vmethod_10()
	{
		return notifyIcon_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_11(NotifyIcon WithEventsValue)
	{
		MouseEventHandler value = method_1;
		NotifyIcon notifyIcon = notifyIcon_0;
		if (notifyIcon != null)
		{
			notifyIcon.MouseDoubleClick -= value;
		}
		notifyIcon_0 = WithEventsValue;
		notifyIcon = notifyIcon_0;
		if (notifyIcon != null)
		{
			notifyIcon.MouseDoubleClick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip vmethod_12()
	{
		return toolTip_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_13(ToolTip WithEventsValue)
	{
		toolTip_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual System.Windows.Forms.Timer vmethod_14()
	{
		return timer_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_15(System.Windows.Forms.Timer WithEventsValue)
	{
		EventHandler value = method_68;
		System.Windows.Forms.Timer timer = timer_0;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		timer_0 = WithEventsValue;
		timer = timer_0;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__43_002D0(JArray IP)
	{
		Class8.smethod_9(IP, vmethod_8().FileName);
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__44_002D0(JArray IP)
	{
		Class8.smethod_2(IP, vmethod_8().FileName);
	}
}
