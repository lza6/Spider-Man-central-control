using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Frm_Back_SHSH2 : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	[AccessedThroughProperty("Button_yes")]
	[CompilerGenerated]
	private Button _Button_yes;

	[AccessedThroughProperty("Button_no")]
	[CompilerGenerated]
	private Button _Button_no;

	[AccessedThroughProperty("CheckBox_ChooseV")]
	[CompilerGenerated]
	private CheckBox _CheckBox_ChooseV;

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
			EventHandler value2 = method_1;
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
			EventHandler value2 = method_2;
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

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
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

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual TextBox TextBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox4")]
	internal virtual TextBox TextBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox3")]
	internal virtual TextBox TextBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckBox_ChooseV
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_ChooseV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			CheckBox checkBox = _CheckBox_ChooseV;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_CheckBox_ChooseV = value;
			checkBox = _CheckBox_ChooseV;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckBox2_Beta")]
	internal virtual CheckBox CheckBox2_Beta
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Frm_Back_SHSH2()
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
		this.icontainer_0 = new System.ComponentModel.Container();
		this.TableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
		this.Button_yes = new System.Windows.Forms.Button();
		this.Button_no = new System.Windows.Forms.Button();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.TextBox4 = new System.Windows.Forms.TextBox();
		this.TextBox3 = new System.Windows.Forms.TextBox();
		this.CheckBox_ChooseV = new System.Windows.Forms.CheckBox();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.Label3 = new System.Windows.Forms.Label();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.vmethod_1(new System.Windows.Forms.ToolTip(this.icontainer_0));
		this.CheckBox2_Beta = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel_Main.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.TabPage1.SuspendLayout();
		base.SuspendLayout();
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
		this.TableLayoutPanel_Main.Size = new System.Drawing.Size(434, 281);
		this.TableLayoutPanel_Main.TabIndex = 11;
		this.Button_yes.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_yes.Location = new System.Drawing.Point(237, 254);
		this.Button_yes.Name = "Button_yes";
		this.Button_yes.Size = new System.Drawing.Size(94, 24);
		this.Button_yes.TabIndex = 1;
		this.Button_yes.Text = "是";
		this.Button_yes.UseVisualStyleBackColor = true;
		this.Button_no.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_no.Location = new System.Drawing.Point(337, 254);
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
		this.TabControl1.Size = new System.Drawing.Size(428, 245);
		this.TabControl1.TabIndex = 3;
		this.TabPage3.Controls.Add(this.CheckBox2_Beta);
		this.TabPage3.Controls.Add(this.TextBox4);
		this.TabPage3.Controls.Add(this.TextBox3);
		this.TabPage3.Controls.Add(this.CheckBox_ChooseV);
		this.TabPage3.Location = new System.Drawing.Point(4, 22);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(420, 219);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "备份系统设置";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.TextBox4.Enabled = false;
		this.TextBox4.Location = new System.Drawing.Point(153, 57);
		this.TextBox4.Name = "TextBox4";
		this.TextBox4.Size = new System.Drawing.Size(101, 21);
		this.TextBox4.TabIndex = 2;
		this.TextBox4.Text = "15F79";
		this.TextBox3.Enabled = false;
		this.TextBox3.Location = new System.Drawing.Point(54, 57);
		this.TextBox3.Name = "TextBox3";
		this.TextBox3.Size = new System.Drawing.Size(84, 21);
		this.TextBox3.TabIndex = 1;
		this.TextBox3.Text = "11.4";
		this.CheckBox_ChooseV.AutoSize = true;
		this.CheckBox_ChooseV.Location = new System.Drawing.Point(26, 25);
		this.CheckBox_ChooseV.Name = "CheckBox_ChooseV";
		this.CheckBox_ChooseV.Size = new System.Drawing.Size(72, 16);
		this.CheckBox_ChooseV.TabIndex = 0;
		this.CheckBox_ChooseV.Text = "指定版本";
		this.CheckBox_ChooseV.UseVisualStyleBackColor = true;
		this.TabPage1.Controls.Add(this.Label3);
		this.TabPage1.Controls.Add(this.TextBox2);
		this.TabPage1.Controls.Add(this.Label2);
		this.TabPage1.Controls.Add(this.TextBox1);
		this.TabPage1.Controls.Add(this.Label1);
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(420, 219);
		this.TabPage1.TabIndex = 3;
		this.TabPage1.Text = "固定随机因子";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(25, 145);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(89, 12);
		this.Label3.TabIndex = 4;
		this.Label3.Text = "留空则随机生成";
		this.TextBox2.Location = new System.Drawing.Point(88, 75);
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.Size = new System.Drawing.Size(183, 21);
		this.TextBox2.TabIndex = 3;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(25, 78);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(53, 12);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "sepnonce";
		this.TextBox1.Location = new System.Drawing.Point(88, 36);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(183, 21);
		this.TextBox1.TabIndex = 1;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(25, 39);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(47, 12);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "apnonce";
		this.CheckBox2_Beta.AutoSize = true;
		this.CheckBox2_Beta.Checked = true;
		this.CheckBox2_Beta.CheckState = System.Windows.Forms.CheckState.Checked;
		this.CheckBox2_Beta.Location = new System.Drawing.Point(26, 95);
		this.CheckBox2_Beta.Name = "CheckBox2_Beta";
		this.CheckBox2_Beta.Size = new System.Drawing.Size(78, 16);
		this.CheckBox2_Beta.TabIndex = 3;
		this.CheckBox2_Beta.Text = "Beta 版本";
		this.CheckBox2_Beta.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(434, 281);
		base.Controls.Add(this.TableLayoutPanel_Main);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(450, 320);
		base.Name = "Frm_Back_SHSH2";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "SHSH2备份";
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

	private void method_0(object sender, EventArgs e)
	{
		if (CheckBox_ChooseV.Checked)
		{
			TextBox3.Enabled = true;
			TextBox4.Enabled = true;
		}
		else
		{
			TextBox3.Enabled = false;
			TextBox4.Enabled = false;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
	}

	private void method_2(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}
}
