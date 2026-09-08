using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_Declare : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_No")]
	private Button _Button_No;

	[AccessedThroughProperty("Button_Yes")]
	[CompilerGenerated]
	private Button _Button_Yes;

	[field: AccessedThroughProperty("TableLayoutPanel_Declare")]
	internal virtual TableLayoutPanel TableLayoutPanel_Declare
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_Declare")]
	internal virtual TextBox TextBox_Declare
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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
			EventHandler value2 = method_0;
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
			EventHandler value2 = lpmtSkFjgu;
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

	[field: AccessedThroughProperty("PictureBox_Donation")]
	internal virtual PictureBox PictureBox_Donation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_Declare()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_Declare));
		this.TableLayoutPanel_Declare = new System.Windows.Forms.TableLayoutPanel();
		this.Button_No = new System.Windows.Forms.Button();
		this.TextBox_Declare = new System.Windows.Forms.TextBox();
		this.Button_Yes = new System.Windows.Forms.Button();
		this.PictureBox_Donation = new System.Windows.Forms.PictureBox();
		this.TableLayoutPanel_Declare.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Donation).BeginInit();
		base.SuspendLayout();
		this.TableLayoutPanel_Declare.ColumnCount = 2;
		this.TableLayoutPanel_Declare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel_Declare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel_Declare.Controls.Add(this.Button_No, 1, 1);
		this.TableLayoutPanel_Declare.Controls.Add(this.TextBox_Declare, 0, 0);
		this.TableLayoutPanel_Declare.Controls.Add(this.Button_Yes, 0, 1);
		this.TableLayoutPanel_Declare.Controls.Add(this.PictureBox_Donation, 1, 0);
		this.TableLayoutPanel_Declare.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Declare.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Declare.Name = "TableLayoutPanel_Declare";
		this.TableLayoutPanel_Declare.RowCount = 2;
		this.TableLayoutPanel_Declare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Declare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48f));
		this.TableLayoutPanel_Declare.Size = new System.Drawing.Size(716, 406);
		this.TableLayoutPanel_Declare.TabIndex = 0;
		this.Button_No.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_No.Location = new System.Drawing.Point(361, 361);
		this.Button_No.Name = "Button_No";
		this.Button_No.Size = new System.Drawing.Size(352, 42);
		this.Button_No.TabIndex = 2;
		this.Button_No.Text = "不同意";
		this.Button_No.UseVisualStyleBackColor = true;
		this.TextBox_Declare.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_Declare.Location = new System.Drawing.Point(3, 3);
		this.TextBox_Declare.Multiline = true;
		this.TextBox_Declare.Name = "TextBox_Declare";
		this.TextBox_Declare.ReadOnly = true;
		this.TextBox_Declare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.TextBox_Declare.Size = new System.Drawing.Size(352, 352);
		this.TextBox_Declare.TabIndex = 0;
		this.TextBox_Declare.Text = resources.GetString("TextBox_Declare.Text");
		this.Button_Yes.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Yes.Location = new System.Drawing.Point(3, 361);
		this.Button_Yes.Name = "Button_Yes";
		this.Button_Yes.Size = new System.Drawing.Size(352, 42);
		this.Button_Yes.TabIndex = 1;
		this.Button_Yes.Text = "同意";
		this.Button_Yes.UseVisualStyleBackColor = true;
		this.PictureBox_Donation.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox_Donation.Image = (System.Drawing.Image)resources.GetObject("PictureBox_Donation.Image");
		this.PictureBox_Donation.Location = new System.Drawing.Point(361, 3);
		this.PictureBox_Donation.Name = "PictureBox_Donation";
		this.PictureBox_Donation.Size = new System.Drawing.Size(352, 352);
		this.PictureBox_Donation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox_Donation.TabIndex = 3;
		this.PictureBox_Donation.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(716, 406);
		base.Controls.Add(this.TableLayoutPanel_Declare);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Form_Declare";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "XXTouch中控免责条款";
		this.TableLayoutPanel_Declare.ResumeLayout(false);
		this.TableLayoutPanel_Declare.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Donation).EndInit();
		base.ResumeLayout(false);
	}

	private void lpmtSkFjgu(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
	}

	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
	}
}
