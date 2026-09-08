using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_MessageBox : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_Yes")]
	[CompilerGenerated]
	private Button _Button_Yes;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_No")]
	private Button _Button_No;

	[field: AccessedThroughProperty("TextBox_Message")]
	internal virtual TextBox TextBox_Message
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_Yes
	{
		[CompilerGenerated]
		get
		{
			return _Button_Yes;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			Button button = _Button_Yes;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Yes = value;
			button = _Button_Yes;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_No
	{
		[CompilerGenerated]
		get
		{
			return _Button_No;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			Button button = _Button_No;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_No = value;
			button = _Button_No;
			if (button != null)
			{
				button.Click += value2;
			}
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_MessageBox));
		this.TextBox_Message = new System.Windows.Forms.TextBox();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button_Yes = new System.Windows.Forms.Button();
		this.Button_No = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.TextBox_Message.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TableLayoutPanel1.SetColumnSpan(this.TextBox_Message, 2);
		this.TextBox_Message.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_Message.Location = new System.Drawing.Point(13, 13);
		this.TextBox_Message.Multiline = true;
		this.TextBox_Message.Name = "TextBox_Message";
		this.TextBox_Message.Size = new System.Drawing.Size(328, 88);
		this.TextBox_Message.TabIndex = 2;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.TextBox_Message, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button_Yes, 0, 1);
		this.TableLayoutPanel1.Controls.Add(this.Button_No, 1, 1);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
		this.TableLayoutPanel1.RowCount = 2;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(354, 171);
		this.TableLayoutPanel1.TabIndex = 2;
		this.Button_Yes.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button_Yes.Location = new System.Drawing.Point(53, 117);
		this.Button_Yes.Margin = new System.Windows.Forms.Padding(0);
		this.Button_Yes.Name = "Button_Yes";
		this.Button_Yes.Size = new System.Drawing.Size(80, 30);
		this.Button_Yes.TabIndex = 0;
		this.Button_Yes.Text = "立即下载";
		this.Button_Yes.UseVisualStyleBackColor = true;
		this.Button_No.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button_No.Location = new System.Drawing.Point(220, 117);
		this.Button_No.Margin = new System.Windows.Forms.Padding(0);
		this.Button_No.Name = "Button_No";
		this.Button_No.Size = new System.Drawing.Size(80, 30);
		this.Button_No.TabIndex = 1;
		this.Button_No.Text = "取消安装";
		this.Button_No.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(354, 171);
		base.Controls.Add(this.TableLayoutPanel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimumSize = new System.Drawing.Size(370, 210);
		base.Name = "Form_MessageBox";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
	}

	public Form_MessageBox(string msg, string title)
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_MessageBox_Load;
		InitializeComponent();
		TextBox_Message.Text = msg;
		Text = title;
	}

	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
	}

	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}

	private void Form_MessageBox_Load(object sender, EventArgs e)
	{
	}
}
