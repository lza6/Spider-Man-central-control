using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Frm_Auth : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel_Buy")]
	private LinkLabel _LinkLabel_Buy;

	[AccessedThroughProperty("Button_Submit")]
	[CompilerGenerated]
	private Button _Button_Submit;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView_DeviceList")]
	private DataGridView _DataGridView_DeviceList;

	[AccessedThroughProperty("Button_check_auth")]
	[CompilerGenerated]
	private Button _Button_check_auth;

	private bool bool_0;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_DeviceList")]
	internal virtual GroupBox GroupBox_DeviceList
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_AuthKey")]
	internal virtual GroupBox GroupBox_AuthKey
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel LinkLabel_Buy
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel_Buy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_6;
			LinkLabel linkLabel = _LinkLabel_Buy;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel_Buy = value;
			linkLabel = _LinkLabel_Buy;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	internal virtual Button Button_Submit
	{
		[CompilerGenerated]
		get
		{
			return _Button_Submit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			Button button = _Button_Submit;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Submit = value;
			button = _Button_Submit;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox_AuthKey")]
	internal virtual TextBox TextBox_AuthKey
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
			DataGridViewCellMouseEventHandler value2 = method_0;
			EventHandler value3 = method_1;
			DataGridViewCellEventHandler value4 = method_2;
			DataGridView dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick -= value2;
				dataGridView.CurrentCellDirtyStateChanged -= value3;
				dataGridView.CellClick -= value4;
			}
			_DataGridView_DeviceList = value;
			dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick += value2;
				dataGridView.CurrentCellDirtyStateChanged += value3;
				dataGridView.CellClick += value4;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_Config")]
	internal virtual GroupBox GroupBox_Config
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

	internal virtual Button Button_check_auth
	{
		[CompilerGenerated]
		get
		{
			return _Button_check_auth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_7;
			Button button = _Button_check_auth;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_check_auth = value;
			button = _Button_check_auth;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("CheckBox2")]
	internal virtual CheckBox CheckBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Frm_Auth()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += HuaVmjoNcI;
		bool_0 = false;
		InitializeComponent();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Frm_Auth));
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button_Submit = new System.Windows.Forms.Button();
		this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
		this.GroupBox_DeviceList = new System.Windows.Forms.GroupBox();
		this.DataGridView_DeviceList = new System.Windows.Forms.DataGridView();
		this.GroupBox_AuthKey = new System.Windows.Forms.GroupBox();
		this.TextBox_AuthKey = new System.Windows.Forms.TextBox();
		this.GroupBox_Config = new System.Windows.Forms.GroupBox();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.Button_check_auth = new System.Windows.Forms.Button();
		this.LinkLabel_Buy = new System.Windows.Forms.LinkLabel();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
		this.SplitContainer1.Panel1.SuspendLayout();
		this.SplitContainer1.Panel2.SuspendLayout();
		this.SplitContainer1.SuspendLayout();
		this.GroupBox_DeviceList.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).BeginInit();
		this.GroupBox_AuthKey.SuspendLayout();
		this.GroupBox_Config.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel1.AutoScroll = true;
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150f));
		this.TableLayoutPanel1.Controls.Add(this.Button_Submit, 2, 2);
		this.TableLayoutPanel1.Controls.Add(this.SplitContainer1, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.GroupBox_Config, 1, 1);
		this.TableLayoutPanel1.Controls.Add(this.Button_check_auth, 1, 2);
		this.TableLayoutPanel1.Controls.Add(this.LinkLabel_Buy, 0, 1);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
		this.TableLayoutPanel1.RowCount = 3;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(1223, 693);
		this.TableLayoutPanel1.TabIndex = 0;
		this.Button_Submit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Submit.Location = new System.Drawing.Point(1078, 637);
		this.Button_Submit.Margin = new System.Windows.Forms.Padding(10);
		this.Button_Submit.Name = "Button_Submit";
		this.Button_Submit.Size = new System.Drawing.Size(130, 41);
		this.Button_Submit.TabIndex = 3;
		this.Button_Submit.Text = "授权设备";
		this.Button_Submit.UseVisualStyleBackColor = true;
		this.TableLayoutPanel1.SetColumnSpan(this.SplitContainer1, 3);
		this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer1.Location = new System.Drawing.Point(8, 8);
		this.SplitContainer1.Name = "SplitContainer1";
		this.SplitContainer1.Panel1.Controls.Add(this.GroupBox_DeviceList);
		this.SplitContainer1.Panel2.Controls.Add(this.GroupBox_AuthKey);
		this.SplitContainer1.Size = new System.Drawing.Size(1207, 563);
		this.SplitContainer1.SplitterDistance = 896;
		this.SplitContainer1.SplitterWidth = 10;
		this.SplitContainer1.TabIndex = 0;
		this.GroupBox_DeviceList.Controls.Add(this.DataGridView_DeviceList);
		this.GroupBox_DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_DeviceList.Location = new System.Drawing.Point(0, 0);
		this.GroupBox_DeviceList.Name = "GroupBox_DeviceList";
		this.GroupBox_DeviceList.Padding = new System.Windows.Forms.Padding(10);
		this.GroupBox_DeviceList.Size = new System.Drawing.Size(896, 563);
		this.GroupBox_DeviceList.TabIndex = 0;
		this.GroupBox_DeviceList.TabStop = false;
		this.GroupBox_DeviceList.Text = "设备列表";
		this.DataGridView_DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DataGridView_DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DataGridView_DeviceList.Location = new System.Drawing.Point(10, 24);
		this.DataGridView_DeviceList.Name = "DataGridView_DeviceList";
		this.DataGridView_DeviceList.RowTemplate.Height = 23;
		this.DataGridView_DeviceList.Size = new System.Drawing.Size(876, 529);
		this.DataGridView_DeviceList.TabIndex = 1;
		this.GroupBox_AuthKey.Controls.Add(this.TextBox_AuthKey);
		this.GroupBox_AuthKey.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_AuthKey.Location = new System.Drawing.Point(0, 0);
		this.GroupBox_AuthKey.Name = "GroupBox_AuthKey";
		this.GroupBox_AuthKey.Padding = new System.Windows.Forms.Padding(10);
		this.GroupBox_AuthKey.Size = new System.Drawing.Size(301, 563);
		this.GroupBox_AuthKey.TabIndex = 1;
		this.GroupBox_AuthKey.TabStop = false;
		this.GroupBox_AuthKey.Text = "授权码";
		this.TextBox_AuthKey.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_AuthKey.Location = new System.Drawing.Point(10, 24);
		this.TextBox_AuthKey.Multiline = true;
		this.TextBox_AuthKey.Name = "TextBox_AuthKey";
		this.TextBox_AuthKey.Size = new System.Drawing.Size(281, 529);
		this.TextBox_AuthKey.TabIndex = 0;
		this.TableLayoutPanel1.SetColumnSpan(this.GroupBox_Config, 2);
		this.GroupBox_Config.Controls.Add(this.CheckBox2);
		this.GroupBox_Config.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Config.Location = new System.Drawing.Point(921, 577);
		this.GroupBox_Config.Name = "GroupBox_Config";
		this.GroupBox_Config.Size = new System.Drawing.Size(294, 47);
		this.GroupBox_Config.TabIndex = 4;
		this.GroupBox_Config.TabStop = false;
		this.GroupBox_Config.Text = "配置";
		this.CheckBox2.AutoSize = true;
		this.CheckBox2.Location = new System.Drawing.Point(10, 23);
		this.CheckBox2.Name = "CheckBox2";
		this.CheckBox2.Size = new System.Drawing.Size(198, 16);
		this.CheckBox2.TabIndex = 4;
		this.CheckBox2.Text = "强行充值剩余时间大于 7 天设备";
		this.CheckBox2.UseVisualStyleBackColor = true;
		this.Button_check_auth.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_check_auth.Location = new System.Drawing.Point(928, 637);
		this.Button_check_auth.Margin = new System.Windows.Forms.Padding(10);
		this.Button_check_auth.Name = "Button_check_auth";
		this.Button_check_auth.Size = new System.Drawing.Size(130, 41);
		this.Button_check_auth.TabIndex = 5;
		this.Button_check_auth.Text = "检测授权";
		this.Button_check_auth.UseVisualStyleBackColor = true;
		this.LinkLabel_Buy.AutoSize = true;
		this.LinkLabel_Buy.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LinkLabel_Buy.Location = new System.Drawing.Point(8, 574);
		this.LinkLabel_Buy.Name = "LinkLabel_Buy";
		this.TableLayoutPanel1.SetRowSpan(this.LinkLabel_Buy, 2);
		this.LinkLabel_Buy.Size = new System.Drawing.Size(907, 114);
		this.LinkLabel_Buy.TabIndex = 2;
		this.LinkLabel_Buy.TabStop = true;
		this.LinkLabel_Buy.Text = "购买XXTouch授权 https://www.xxtouch.com";
		this.LinkLabel_Buy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1223, 693);
		base.Controls.Add(this.TableLayoutPanel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Frm_Auth";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "XXTouch授权";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.SplitContainer1.Panel1.ResumeLayout(false);
		this.SplitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
		this.SplitContainer1.ResumeLayout(false);
		this.GroupBox_DeviceList.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).EndInit();
		this.GroupBox_AuthKey.ResumeLayout(false);
		this.GroupBox_AuthKey.PerformLayout();
		this.GroupBox_Config.ResumeLayout(false);
		this.GroupBox_Config.PerformLayout();
		base.ResumeLayout(false);
	}

	private void HuaVmjoNcI(object sender, EventArgs e)
	{
		DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
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
		dataGridView_DeviceList.Columns["_ip"].Visible = false;
		dataGridView_DeviceList.Columns["port"].HeaderText = "端口";
		dataGridView_DeviceList.Columns["port"].Visible = false;
		dataGridView_DeviceList.Columns["devname"].HeaderText = "设备名";
		dataGridView_DeviceList.Columns["deviceid"].HeaderText = "设备号";
		dataGridView_DeviceList.Columns["devsn"].HeaderText = "设备串号";
		dataGridView_DeviceList.Columns["devmac"].HeaderText = "设备MAC";
		dataGridView_DeviceList.Columns["devmac"].Visible = false;
		dataGridView_DeviceList.Columns["devtype"].HeaderText = "设备类型";
		dataGridView_DeviceList.Columns["devtype"].Visible = false;
		dataGridView_DeviceList.Columns["zeversion"].HeaderText = "版本";
		dataGridView_DeviceList.Columns["zeversion"].Visible = false;
		dataGridView_DeviceList.Columns["sysversion"].HeaderText = "系统版本";
		dataGridView_DeviceList.Columns["sysversion"].Visible = false;
		dataGridView_DeviceList.Columns["message"].HeaderText = "消息";
		dataGridView_DeviceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_DeviceList.AllowUserToAddRows = false;
		dataGridView_DeviceList.EditMode = DataGridViewEditMode.EditOnEnter;
		dataGridView_DeviceList.BackgroundColor = Color.White;
		dataGridView_DeviceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
		dataGridView_DeviceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		dataGridView_DeviceList.ReadOnly = true;
		dataGridView_DeviceList.AutoGenerateColumns = true;
	}

	private void method_0(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			return;
		}
		if (e.ColumnIndex == 0)
		{
			bool_0 = !bool_0;
			foreach (DataRow row in Class9.dataTable_0.Rows)
			{
				row["check"] = bool_0;
			}
			DataGridView_DeviceList.DataSource = Class9.dataTable_0;
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
	}

	private void method_1(object sender, EventArgs e)
	{
		if (DataGridView_DeviceList.IsCurrentCellDirty)
		{
			DataGridView_DeviceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void method_2(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex == 0)
			{
				DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
				Class9.dataTable_0.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("deviceid='", dataGridView_DeviceList.Rows[e.RowIndex].Cells["deviceid"].Value), "'")))[0]["check"] = !Conversions.ToBoolean(dataGridView_DeviceList[e.ColumnIndex, e.RowIndex].EditedFormattedValue);
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

	private void method_3(object sender, EventArgs e)
	{
		if (Operators.CompareString(TextBox_AuthKey.Text, "", TextCompare: false) == 0)
		{
			return;
		}
		MessageBox.Show("授权开始了,请勿多次点击.", "批量授权", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		DataTable dataTable = new DataTable();
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		DataColumnCollection columns = dataTable.Columns;
		columns.Add("ip");
		columns.Add("deviceid");
		columns.Add("devtype");
		columns.Add("zeversion");
		columns.Add("sysversion");
		columns.Add("devsn");
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				dataTable.Rows.Add(array[i]["ip"], array[i]["deviceid"], array[i]["devtype"], array[i]["zeversion"], array[i]["sysversion"], array[i]["devsn"]);
			}
			string text = "授权成功：\r\n";
			string text2 = "出错设备：\r\n";
			string text3 = "出错授权码：\r\n";
			string text4 = "未使用授权码：\r\n";
			string[] array2 = TextBox_AuthKey.Text.Split('\r');
			int num2 = 0;
			int num3 = 0;
			while (array2.Length > num3 && dataTable.Rows.Count > num2)
			{
				string text5 = Conversions.ToString(dataTable.Rows[num2]["deviceid"]);
				string text6 = Conversions.ToString(dataTable.Rows[num2]["devsn"]);
				string string_ = Conversions.ToString(dataTable.Rows[num2]["ip"]);
				string text7 = array2[num3].Trim(' ', '\n', '\t').Replace(" ", "");
				if ((text7.Length == 16) | (text7.Length == 12))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add("did", text5);
					dictionary.Add("sn", text6);
					if (CheckBox2.Checked)
					{
						dictionary.Add("mustbeless", Conversions.ToString(0));
					}
					else
					{
						dictionary.Add("mustbeless", Conversions.ToString(604800));
					}
					dictionary.Add("code", text7);
					string text8 = Class8.smethod_39("/api/bind_code", dictionary);
					if ((text8 == null) | (Operators.CompareString(text8, "", TextCompare: false) == 0))
					{
						text2 = text2 + text5 + "\t" + text6 + "\t操作超时\r\n";
						Class8.smethod_30(string_, "操作超时");
						continue;
					}
					try
					{
						JObject val = JObject.Parse(text8);
						int num4 = (int)val["code"];
						if (num4 == 0)
						{
							Class8.smethod_30(string_, "授权成功");
							text = text + text5 + "\t" + text6 + "\t" + text7 + "\r\n";
							num2++;
							num3++;
							continue;
						}
						if (num4 == 1)
						{
							Class8.smethod_30(string_, val["message"].ToString());
							text2 = text2 + text5 + "\t" + text6 + "\t" + val["message"].ToString() + "\r\n";
							num2++;
							break;
						}
						if (num4 > 1)
						{
							Class8.smethod_30(string_, val["message"].ToString());
							text2 = text2 + text5 + "\t" + text6 + "\t" + val["message"].ToString() + "\r\n";
							num2++;
							break;
						}
						if (num4 < 0)
						{
							Class8.smethod_30(string_, val["message"].ToString());
							if ((int)val["code"] == -9)
							{
								text2 = text2 + text5 + "\t" + text6 + "\t" + val["message"].ToString() + "\r\n";
								num2++;
							}
							else
							{
								text3 = text3 + text7 + "\t" + val["message"].ToString() + "\r\n";
								num3++;
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Class8.smethod_30(string_, ex2.Message);
						text2 = text2 + text5 + "\t" + text6 + "\t" + ex2.Message + "\r\n";
						num2++;
						ProjectData.ClearProjectError();
					}
				}
				else if (text7.Length != 0)
				{
					text3 = text3 + text7 + "\t授权码长度不正确\r\n";
					num3++;
				}
			}
			int num5 = num3;
			int num6 = array2.Length - 1;
			for (int j = num5; j <= num6; j++)
			{
				string text9 = array2[j].Trim(' ', '\n', '\t').Replace(" ", "");
				text4 = text4 + text9 + "\r\n";
			}
			File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", "=============== " + Conversions.ToString(DateAndTime.Now.ToLocalTime()) + " ===============\r\n" + text + "\r\n" + text2 + "\r\n" + text3 + "\r\n" + text4 + "\r\n");
			MessageBox.Show("请查看目录下的\"授权详细信息.txt\"来查看授权情况", "请确认授权情况", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private byte[] method_4(string string_0)
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

	private int method_5(DataRow dataRow_0, string string_0)
	{
		int result;
		try
		{
			if (string_0.Length != 16)
			{
				Class8.smethod_30(Conversions.ToString(dataRow_0["ip"]), "授权码长度不正确");
				File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow_0["deviceid"], "\t"), dataRow_0["devsn"]), "\t"), string_0), "\t"), "授权码长度不正确"), "\r\n")));
				result = -10;
			}
			else
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("did", Conversions.ToString(dataRow_0["deviceid"]));
				dictionary.Add("sn", Conversions.ToString(dataRow_0["devsn"]));
				if (CheckBox2.Checked)
				{
					dictionary.Add("mustbeless", Conversions.ToString(0));
				}
				else
				{
					dictionary.Add("mustbeless", Conversions.ToString(604800));
				}
				dictionary.Add("code", string_0);
				string text = Class8.smethod_39("/api/bind_code", dictionary);
				if ((text == null) | (Operators.CompareString(text, "", TextCompare: false) == 0))
				{
					Class8.smethod_30(Conversions.ToString(dataRow_0["ip"]), "操作超时");
					File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow_0["deviceid"], "\t"), dataRow_0["devsn"]), "\t"), string_0), "\t"), "操作超时"), "\r\n")));
					result = 1;
				}
				else
				{
					JObject val = JObject.Parse(text);
					if ((int)val["code"] == 0)
					{
						Class8.smethod_30(Conversions.ToString(dataRow_0["ip"]), "授权成功");
						File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow_0["deviceid"], "\t"), dataRow_0["devsn"]), "\t"), string_0), "\t"), "授权成功"), "\r\n")));
						result = 0;
					}
					else
					{
						Class8.smethod_30(Conversions.ToString(dataRow_0["ip"]), val["message"].ToString());
						File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow_0["deviceid"], "\t"), dataRow_0["devsn"]), "\t"), string_0), "\t"), val["message"].ToString()), "\r\n")));
						result = (int)val["code"];
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Class8.smethod_30(Conversions.ToString(dataRow_0["ip"]), ex2.Message.ToString());
			File.AppendAllText(Application.StartupPath + "\\授权详细信息.txt", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataRow_0["deviceid"], "\t"), dataRow_0["devsn"]), "\t"), string_0), "\t"), ex2.Message.ToString()), "\r\n")));
			result = 2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_6(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://www.xxtouch.com");
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		JArray val = new JArray();
		DataRow[] array = Class9.dataTable_0.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			dataRow["message"] = "";
			val.Add((JToken)new JObject(new object[3]
			{
				(object)new JProperty("ip", RuntimeHelpers.GetObjectValue(dataRow["ip"])),
				(object)new JProperty("deviceid", RuntimeHelpers.GetObjectValue(dataRow["deviceid"])),
				(object)new JProperty("devsn", RuntimeHelpers.GetObjectValue(dataRow["devsn"]))
			}));
		}
		new Thread([SpecialName] (object a0) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			Class8.smethod_11((JArray)a0);
		}).Start(val);
	}
}
