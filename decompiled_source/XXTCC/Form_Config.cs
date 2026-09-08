using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Form_Config : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_yes")]
	[CompilerGenerated]
	private Button _Button_yes;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_no")]
	private Button _Button_no;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	public JObject _DisplayName;

	public JObject _dbName;

	[field: AccessedThroughProperty("CheckedListBox_ColumnList")]
	internal virtual CheckedListBox CheckedListBox_ColumnList
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_AutoColumn")]
	internal virtual CheckBox CheckBox_AutoColumn
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel_Main")]
	internal virtual TableLayoutPanel TableLayoutPanel_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_yes
	{
		[CompilerGenerated]
		get
		{
			return _Button_yes;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			Button button = _Button_yes;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_yes = value;
			button = _Button_yes;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_no
	{
		[CompilerGenerated]
		get
		{
			return _Button_no;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			Button button = _Button_no;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_no = value;
			button = _Button_no;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual TabControl TabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_HideDBTab")]
	internal virtual CheckBox CheckBox_HideDBTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_HideDeviceGroups")]
	internal virtual CheckBox CheckBox_HideDeviceGroups
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_HideConfig")]
	internal virtual CheckBox CheckBox_HideConfig
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_HidePause")]
	internal virtual CheckBox CheckBox_HidePause
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_Config()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_Config_Load;
		_DisplayName = new JObject(new object[11]
		{
			(object)new JProperty("port", (object)"端口"),
			(object)new JProperty("devname", (object)"设备名"),
			(object)new JProperty("deviceid", (object)"设备ID"),
			(object)new JProperty("devsn", (object)"序列号"),
			(object)new JProperty("devmac", (object)"Mac"),
			(object)new JProperty("devtype", (object)"类型"),
			(object)new JProperty("zeversion", (object)"xxt版本"),
			(object)new JProperty("sysversion", (object)"系统版本"),
			(object)new JProperty("boardconfig", (object)"BoardConfig"),
			(object)new JProperty("ecid", (object)"ECID"),
			(object)new JProperty("buildid", (object)"BuildID")
		});
		_dbName = new JObject(new object[11]
		{
			(object)new JProperty("端口", (object)"port"),
			(object)new JProperty("设备名", (object)"devname"),
			(object)new JProperty("设备ID", (object)"deviceid"),
			(object)new JProperty("序列号", (object)"devsn"),
			(object)new JProperty("Mac", (object)"devmac"),
			(object)new JProperty("类型", (object)"devtype"),
			(object)new JProperty("xxt版本", (object)"zeversion"),
			(object)new JProperty("系统版本", (object)"sysversion"),
			(object)new JProperty("BoardConfig", (object)"boardconfig"),
			(object)new JProperty("ECID", (object)"ecid"),
			(object)new JProperty("BuildID", (object)"buildid")
		});
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
		this.icontainer_0 = new System.ComponentModel.Container();
		this.CheckedListBox_ColumnList = new System.Windows.Forms.CheckedListBox();
		this.CheckBox_AutoColumn = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
		this.Button_yes = new System.Windows.Forms.Button();
		this.Button_no = new System.Windows.Forms.Button();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.CheckBox_HideConfig = new System.Windows.Forms.CheckBox();
		this.CheckBox_HideDeviceGroups = new System.Windows.Forms.CheckBox();
		this.CheckBox_HideDBTab = new System.Windows.Forms.CheckBox();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.vmethod_1(new System.Windows.Forms.ToolTip(this.icontainer_0));
		this.CheckBox_HidePause = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel_Main.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.TabPage1.SuspendLayout();
		base.SuspendLayout();
		this.CheckedListBox_ColumnList.FormattingEnabled = true;
		this.CheckedListBox_ColumnList.Location = new System.Drawing.Point(23, 54);
		this.CheckedListBox_ColumnList.Name = "CheckedListBox_ColumnList";
		this.CheckedListBox_ColumnList.Size = new System.Drawing.Size(336, 132);
		this.CheckedListBox_ColumnList.TabIndex = 6;
		this.vmethod_0().SetToolTip(this.CheckedListBox_ColumnList, "对应展示列内的默认显示内容");
		this.CheckBox_AutoColumn.AutoSize = true;
		this.CheckBox_AutoColumn.Location = new System.Drawing.Point(23, 20);
		this.CheckBox_AutoColumn.Name = "CheckBox_AutoColumn";
		this.CheckBox_AutoColumn.Size = new System.Drawing.Size(96, 16);
		this.CheckBox_AutoColumn.TabIndex = 9;
		this.CheckBox_AutoColumn.Text = "自动调整列宽";
		this.vmethod_0().SetToolTip(this.CheckBox_AutoColumn, "设备表列表内单元格宽度自动调整（此处修改后会需重启中控方可生效）");
		this.CheckBox_AutoColumn.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Main.ColumnCount = 3;
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
		this.TableLayoutPanel_Main.Controls.Add(this.Button_yes, 1, 1);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_no, 2, 1);
		this.TableLayoutPanel_Main.Controls.Add(this.TabControl1, 0, 0);
		this.TableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main";
		this.TableLayoutPanel_Main.RowCount = 2;
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Main.Size = new System.Drawing.Size(506, 312);
		this.TableLayoutPanel_Main.TabIndex = 10;
		this.Button_yes.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_yes.Location = new System.Drawing.Point(309, 285);
		this.Button_yes.Name = "Button_yes";
		this.Button_yes.Size = new System.Drawing.Size(94, 24);
		this.Button_yes.TabIndex = 1;
		this.Button_yes.Text = "是";
		this.Button_yes.UseVisualStyleBackColor = true;
		this.Button_no.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_no.Location = new System.Drawing.Point(409, 285);
		this.Button_no.Name = "Button_no";
		this.Button_no.Size = new System.Drawing.Size(94, 24);
		this.Button_no.TabIndex = 2;
		this.Button_no.Text = "否";
		this.Button_no.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Main.SetColumnSpan(this.TabControl1, 3);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TabControl1.Location = new System.Drawing.Point(3, 3);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(500, 276);
		this.TabControl1.TabIndex = 3;
		this.TabPage3.Controls.Add(this.CheckBox_HidePause);
		this.TabPage3.Controls.Add(this.CheckBox_HideConfig);
		this.TabPage3.Controls.Add(this.CheckBox_HideDeviceGroups);
		this.TabPage3.Controls.Add(this.CheckBox_HideDBTab);
		this.TabPage3.Location = new System.Drawing.Point(4, 22);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(492, 250);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "界面调整";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.CheckBox_HideConfig.AutoSize = true;
		this.CheckBox_HideConfig.Location = new System.Drawing.Point(57, 106);
		this.CheckBox_HideConfig.Name = "CheckBox_HideConfig";
		this.CheckBox_HideConfig.Size = new System.Drawing.Size(96, 16);
		this.CheckBox_HideConfig.TabIndex = 4;
		this.CheckBox_HideConfig.Text = "隐藏配置信息";
		this.CheckBox_HideConfig.UseVisualStyleBackColor = true;
		this.CheckBox_HideDeviceGroups.AutoSize = true;
		this.CheckBox_HideDeviceGroups.Location = new System.Drawing.Point(22, 69);
		this.CheckBox_HideDeviceGroups.Name = "CheckBox_HideDeviceGroups";
		this.CheckBox_HideDeviceGroups.Size = new System.Drawing.Size(156, 16);
		this.CheckBox_HideDeviceGroups.TabIndex = 3;
		this.CheckBox_HideDeviceGroups.Text = "隐藏设备分组与配置视图";
		this.CheckBox_HideDeviceGroups.UseVisualStyleBackColor = true;
		this.CheckBox_HideDBTab.AutoSize = true;
		this.CheckBox_HideDBTab.Location = new System.Drawing.Point(22, 32);
		this.CheckBox_HideDBTab.Name = "CheckBox_HideDBTab";
		this.CheckBox_HideDBTab.Size = new System.Drawing.Size(108, 16);
		this.CheckBox_HideDBTab.TabIndex = 2;
		this.CheckBox_HideDBTab.Text = "隐藏数据表视图";
		this.CheckBox_HideDBTab.UseVisualStyleBackColor = true;
		this.TabPage1.Controls.Add(this.CheckBox_AutoColumn);
		this.TabPage1.Controls.Add(this.CheckedListBox_ColumnList);
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(492, 250);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "设备表";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.CheckBox_HidePause.AutoSize = true;
		this.CheckBox_HidePause.Location = new System.Drawing.Point(22, 146);
		this.CheckBox_HidePause.Name = "CheckBox_HidePause";
		this.CheckBox_HidePause.Size = new System.Drawing.Size(120, 16);
		this.CheckBox_HidePause.TabIndex = 5;
		this.CheckBox_HidePause.Text = "隐藏暂停继续按钮";
		this.CheckBox_HidePause.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(506, 312);
		base.Controls.Add(this.TableLayoutPanel_Main);
		this.MinimumSize = new System.Drawing.Size(450, 320);
		base.Name = "Form_Config";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "配置";
		this.TableLayoutPanel_Main.ResumeLayout(false);
		this.TabControl1.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.TabPage3.PerformLayout();
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		base.ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip vmethod_0()
	{
		return toolTip_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_1(ToolTip WithEventsValue)
	{
		toolTip_0 = WithEventsValue;
	}

	private void Form_Config_Load(object sender, EventArgs e)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		CheckBox_AutoColumn.Checked = (bool)Class9.jobject_3["Interface"][(object)"AutoSizeColumnsMode"];
		CheckBox_HideDBTab.Checked = (bool)Class9.jobject_3["Interface"][(object)"HideDbTab"];
		CheckBox_HideDeviceGroups.Checked = (bool)Class9.jobject_3["Interface"][(object)"HideDeviceGroups"];
		CheckBox_HideConfig.Checked = (bool)Class9.jobject_3["Interface"][(object)"HideConfig"];
		CheckBox_HidePause.Checked = (bool)Class9.jobject_3["Interface"][(object)"HidePause"];
		foreach (JProperty item in ((JContainer)_dbName).Children())
		{
			JProperty val = item;
			CheckedListBox_ColumnList.Items.Add(val.Name);
		}
		checked
		{
			int num = CheckedListBox_ColumnList.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				foreach (JValue item2 in Class9.jobject_3["Interface"][(object)"Column"].Children())
				{
					if (item2.ToString() == (string)_dbName[RuntimeHelpers.GetObjectValue(CheckedListBox_ColumnList.Items[i])])
					{
						CheckedListBox_ColumnList.SetItemChecked(i, value: true);
						break;
					}
				}
			}
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		JArray val = (JArray)Class9.jobject_3["Interface"][(object)"Column"];
		Class9.jobject_3["Interface"][(object)"AutoSizeColumnsMode"] = JToken.op_Implicit(CheckBox_AutoColumn.Checked);
		Class9.jobject_3["Interface"][(object)"HideDbTab"] = JToken.op_Implicit(CheckBox_HideDBTab.Checked);
		Class9.jobject_3["Interface"][(object)"HideDeviceGroups"] = JToken.op_Implicit(CheckBox_HideDeviceGroups.Checked);
		Class9.jobject_3["Interface"][(object)"HideConfig"] = JToken.op_Implicit(CheckBox_HideConfig.Checked);
		Class9.jobject_3["Interface"][(object)"HidePause"] = JToken.op_Implicit(CheckBox_HidePause.Checked);
		val.Clear();
		checked
		{
			int num = CheckedListBox_ColumnList.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (CheckedListBox_ColumnList.GetItemChecked(i))
				{
					val.Add(_dbName[RuntimeHelpers.GetObjectValue(CheckedListBox_ColumnList.Items[i])]);
				}
			}
			base.DialogResult = DialogResult.Yes;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}
}
