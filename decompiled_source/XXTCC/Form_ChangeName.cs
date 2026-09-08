using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_ChangeName : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private Button _Button_OK;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private Button _Button_Cancel;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip toolTip_0;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox _TextBox1;

	[field: AccessedThroughProperty("TableLayoutPanel_Main")]
	internal virtual TableLayoutPanel TableLayoutPanel_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_Main")]
	internal virtual GroupBox GroupBox_Main
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
			EventHandler value2 = yKeHfYgUp;
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

	internal virtual TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_2;
			TextBox textBox = _TextBox1;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			_TextBox1 = value;
			textBox = _TextBox1;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
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

	public Form_ChangeName()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_ChangeName));
		this.TableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
		this.GroupBox_Main = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Button_OK = new System.Windows.Forms.Button();
		this.Button_Cancel = new System.Windows.Forms.Button();
		this.vmethod_1(new System.Windows.Forms.ToolTip(this.icontainer_0));
		this.TableLayoutPanel_Main.SuspendLayout();
		this.GroupBox_Main.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel_Main.ColumnCount = 3;
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
		this.TableLayoutPanel_Main.Controls.Add(this.GroupBox_Main, 0, 0);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_OK, 1, 1);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_Cancel, 2, 1);
		this.TableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main";
		this.TableLayoutPanel_Main.RowCount = 2;
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Main.Size = new System.Drawing.Size(434, 281);
		this.TableLayoutPanel_Main.TabIndex = 11;
		this.TableLayoutPanel_Main.SetColumnSpan(this.GroupBox_Main, 3);
		this.GroupBox_Main.Controls.Add(this.Label2);
		this.GroupBox_Main.Controls.Add(this.Label1);
		this.GroupBox_Main.Controls.Add(this.TextBox1);
		this.GroupBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Main.Location = new System.Drawing.Point(3, 3);
		this.GroupBox_Main.Name = "GroupBox_Main";
		this.GroupBox_Main.Size = new System.Drawing.Size(428, 245);
		this.GroupBox_Main.TabIndex = 0;
		this.GroupBox_Main.TabStop = false;
		this.GroupBox_Main.Text = "更名规则";
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(243, 42);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(0, 12);
		this.Label2.TabIndex = 2;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(31, 75);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(281, 96);
		this.Label1.TabIndex = 1;
		this.Label1.Text = resources.GetString("Label1.Text");
		this.TextBox1.Location = new System.Drawing.Point(33, 39);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(204, 21);
		this.TextBox1.TabIndex = 0;
		this.TextBox1.Text = "{devtype} {ip:4}";
		this.Button_OK.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_OK.Location = new System.Drawing.Point(237, 254);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(94, 24);
		this.Button_OK.TabIndex = 1;
		this.Button_OK.Text = "是";
		this.Button_OK.UseVisualStyleBackColor = true;
		this.Button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Cancel.Location = new System.Drawing.Point(337, 254);
		this.Button_Cancel.Name = "Button_Cancel";
		this.Button_Cancel.Size = new System.Drawing.Size(94, 24);
		this.Button_Cancel.TabIndex = 2;
		this.Button_Cancel.Text = "否";
		this.Button_Cancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(434, 281);
		base.Controls.Add(this.TableLayoutPanel_Main);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimumSize = new System.Drawing.Size(450, 320);
		base.Name = "Form_ChangeName";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "重命名设备";
		this.TableLayoutPanel_Main.ResumeLayout(false);
		this.GroupBox_Main.ResumeLayout(false);
		this.GroupBox_Main.PerformLayout();
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
		base.DialogResult = DialogResult.OK;
	}

	private void yKeHfYgUp(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}

	private object method_1(object object_0)
	{
		object result = default(object);
		return result;
	}

	private void method_2(object sender, EventArgs e)
	{
		string text = "";
		text = TextBox1.Text;
		text = text.Replace("{ip}", "192.168.0.100");
		text = text.Replace("{ip:1}", "192");
		text = text.Replace("{ip:2}", "168");
		text = text.Replace("{ip:3}", "0");
		text = text.Replace("{ip:4}", "100");
		text = text.Replace("{index}", "1");
		text = text.Replace("{devtype}", "iPhone5,3");
		text = text.Replace("{sysversion}", "10.3.3");
		Label2.Text = text;
	}
}
