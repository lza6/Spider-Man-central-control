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
public class Frm_User_cfg : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel brmAyOruRf;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private Button _Button_OK;

	public JObject setjson;

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return brmAyOruRf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			brmAyOruRf = value;
		}
	}

	[field: AccessedThroughProperty("CheckBox_no_nosim_alert")]
	internal virtual CheckBox CheckBox_no_nosim_alert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_no_low_power_alert")]
	internal virtual CheckBox CheckBox_no_low_power_alert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_no_idle")]
	internal virtual CheckBox CheckBox_no_idle
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox_script_on_daemon")]
	internal virtual CheckBox CheckBox_script_on_daemon
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			Button button = _Button_OK;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_OK = value;
			button = _Button_OK;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public Frm_User_cfg()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
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
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.CheckBox_no_nosim_alert = new System.Windows.Forms.CheckBox();
		this.CheckBox_no_low_power_alert = new System.Windows.Forms.CheckBox();
		this.CheckBox_no_idle = new System.Windows.Forms.CheckBox();
		this.CheckBox_script_on_daemon = new System.Windows.Forms.CheckBox();
		this.Button_OK = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.TableLayoutPanel1.Controls.Add(this.CheckBox_no_nosim_alert, 1, 1);
		this.TableLayoutPanel1.Controls.Add(this.CheckBox_no_low_power_alert, 1, 2);
		this.TableLayoutPanel1.Controls.Add(this.CheckBox_no_idle, 1, 3);
		this.TableLayoutPanel1.Controls.Add(this.CheckBox_script_on_daemon, 1, 4);
		this.TableLayoutPanel1.Controls.Add(this.Button_OK, 1, 5);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 7;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(313, 192);
		this.TableLayoutPanel1.TabIndex = 0;
		this.CheckBox_no_nosim_alert.AutoSize = true;
		this.CheckBox_no_nosim_alert.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBox_no_nosim_alert.Location = new System.Drawing.Point(34, 23);
		this.CheckBox_no_nosim_alert.Name = "CheckBox_no_nosim_alert";
		this.CheckBox_no_nosim_alert.Size = new System.Drawing.Size(244, 19);
		this.CheckBox_no_nosim_alert.TabIndex = 0;
		this.CheckBox_no_nosim_alert.Text = "\"无 SIM 卡\"弹窗不弹出";
		this.CheckBox_no_nosim_alert.UseVisualStyleBackColor = true;
		this.CheckBox_no_low_power_alert.AutoSize = true;
		this.CheckBox_no_low_power_alert.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBox_no_low_power_alert.Location = new System.Drawing.Point(34, 48);
		this.CheckBox_no_low_power_alert.Name = "CheckBox_no_low_power_alert";
		this.CheckBox_no_low_power_alert.Size = new System.Drawing.Size(244, 19);
		this.CheckBox_no_low_power_alert.TabIndex = 1;
		this.CheckBox_no_low_power_alert.Text = "\"低电量\" 弹窗不弹出";
		this.CheckBox_no_low_power_alert.UseVisualStyleBackColor = true;
		this.CheckBox_no_idle.AutoSize = true;
		this.CheckBox_no_idle.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBox_no_idle.Location = new System.Drawing.Point(34, 73);
		this.CheckBox_no_idle.Name = "CheckBox_no_idle";
		this.CheckBox_no_idle.Size = new System.Drawing.Size(244, 19);
		this.CheckBox_no_idle.TabIndex = 2;
		this.CheckBox_no_idle.Text = "失眠模式";
		this.CheckBox_no_idle.UseVisualStyleBackColor = true;
		this.CheckBox_script_on_daemon.AutoSize = true;
		this.CheckBox_script_on_daemon.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBox_script_on_daemon.Location = new System.Drawing.Point(34, 98);
		this.CheckBox_script_on_daemon.Name = "CheckBox_script_on_daemon";
		this.CheckBox_script_on_daemon.Size = new System.Drawing.Size(244, 19);
		this.CheckBox_script_on_daemon.TabIndex = 3;
		this.CheckBox_script_on_daemon.Text = "守护模式";
		this.CheckBox_script_on_daemon.UseVisualStyleBackColor = true;
		this.Button_OK.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_OK.Location = new System.Drawing.Point(34, 123);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(244, 34);
		this.Button_OK.TabIndex = 4;
		this.Button_OK.Text = "设置";
		this.Button_OK.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(313, 192);
		base.Controls.Add(this.TableLayoutPanel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Frm_User_cfg";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "设置用户偏好配置";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		setjson = new JObject();
		((JContainer)setjson).Add((object)new JProperty("no_nosim_alert", (object)CheckBox_no_nosim_alert.Checked));
		((JContainer)setjson).Add((object)new JProperty("no_low_power_alert", (object)CheckBox_no_low_power_alert.Checked));
		((JContainer)setjson).Add((object)new JProperty("no_idle", (object)CheckBox_no_idle.Checked));
		((JContainer)setjson).Add((object)new JProperty("script_on_daemon", (object)CheckBox_script_on_daemon.Checked));
		base.DialogResult = DialogResult.OK;
	}
}
