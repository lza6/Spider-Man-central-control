using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Frm_Level : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private Button _Button_OK;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private Button _Button_Cancel;

	[field: AccessedThroughProperty("TrackBar1")]
	internal virtual TrackBar TrackBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_Edit")]
	internal virtual GroupBox GroupBox_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel_Edit")]
	internal virtual TableLayoutPanel TableLayoutPanel_Edit
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

	internal virtual Button Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			Button button = _Button_Cancel;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Cancel = value;
			button = _Button_Cancel;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public Frm_Level()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Frm_Level_Load;
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
		this.TrackBar1 = new System.Windows.Forms.TrackBar();
		this.GroupBox_Edit = new System.Windows.Forms.GroupBox();
		this.TableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
		this.Button_OK = new System.Windows.Forms.Button();
		this.Button_Cancel = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).BeginInit();
		this.GroupBox_Edit.SuspendLayout();
		this.TableLayoutPanel_Edit.SuspendLayout();
		base.SuspendLayout();
		this.TrackBar1.Location = new System.Drawing.Point(26, 42);
		this.TrackBar1.Maximum = 100;
		this.TrackBar1.Name = "TrackBar1";
		this.TrackBar1.Size = new System.Drawing.Size(382, 45);
		this.TrackBar1.TabIndex = 1;
		this.TrackBar1.Value = 50;
		this.TableLayoutPanel_Edit.SetColumnSpan(this.GroupBox_Edit, 3);
		this.GroupBox_Edit.Controls.Add(this.TrackBar1);
		this.GroupBox_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Edit.Location = new System.Drawing.Point(3, 3);
		this.GroupBox_Edit.Name = "GroupBox_Edit";
		this.GroupBox_Edit.Size = new System.Drawing.Size(427, 137);
		this.GroupBox_Edit.TabIndex = 3;
		this.GroupBox_Edit.TabStop = false;
		this.TableLayoutPanel_Edit.ColumnCount = 3;
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115f));
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_OK, 1, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_Cancel, 2, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.GroupBox_Edit, 0, 0);
		this.TableLayoutPanel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Edit.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Edit.Name = "TableLayoutPanel_Edit";
		this.TableLayoutPanel_Edit.RowCount = 2;
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55f));
		this.TableLayoutPanel_Edit.Size = new System.Drawing.Size(433, 198);
		this.TableLayoutPanel_Edit.TabIndex = 12;
		this.Button_OK.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_OK.Location = new System.Drawing.Point(213, 153);
		this.Button_OK.Margin = new System.Windows.Forms.Padding(10);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(95, 35);
		this.Button_OK.TabIndex = 1;
		this.Button_OK.Text = "确认";
		this.Button_OK.UseVisualStyleBackColor = true;
		this.Button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Cancel.Location = new System.Drawing.Point(328, 153);
		this.Button_Cancel.Margin = new System.Windows.Forms.Padding(10);
		this.Button_Cancel.Name = "Button_Cancel";
		this.Button_Cancel.Size = new System.Drawing.Size(95, 35);
		this.Button_Cancel.TabIndex = 2;
		this.Button_Cancel.Text = "取消";
		this.Button_Cancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(433, 198);
		base.Controls.Add(this.TableLayoutPanel_Edit);
		base.Name = "Frm_Level";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "设置数值";
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).EndInit();
		this.GroupBox_Edit.ResumeLayout(false);
		this.GroupBox_Edit.PerformLayout();
		this.TableLayoutPanel_Edit.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}

	private void Frm_Level_Load(object sender, EventArgs e)
	{
	}
}
