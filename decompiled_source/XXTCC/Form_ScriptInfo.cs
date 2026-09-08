using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_ScriptInfo : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("OKButton")]
	private Button _OKButton;

	[AccessedThroughProperty("LinkLabel_BuyLink")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel_BuyLink;

	[field: AccessedThroughProperty("TextBox_Instructions")]
	internal virtual TextBox TextBox_Instructions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button OKButton
	{
		[CompilerGenerated]
		get
		{
			return _OKButton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			Button button = _OKButton;
			if (button != null)
			{
				button.Click -= value2;
			}
			_OKButton = value;
			button = _OKButton;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel LinkLabel_BuyLink
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel_BuyLink;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_0;
			LinkLabel linkLabel = _LinkLabel_BuyLink;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel_BuyLink = value;
			linkLabel = _LinkLabel_BuyLink;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	[field: AccessedThroughProperty("PictureBox_Logo")]
	internal virtual PictureBox PictureBox_Logo
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_ScriptName")]
	internal virtual TextBox TextBox_ScriptName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_Developer")]
	internal virtual TextBox TextBox_Developer
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_ScriptInfo()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_ScriptInfo_Load;
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
		this.TextBox_Instructions = new System.Windows.Forms.TextBox();
		this.OKButton = new System.Windows.Forms.Button();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.LinkLabel_BuyLink = new System.Windows.Forms.LinkLabel();
		this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
		this.TextBox_ScriptName = new System.Windows.Forms.TextBox();
		this.TextBox_Developer = new System.Windows.Forms.TextBox();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Logo).BeginInit();
		base.SuspendLayout();
		this.TextBox_Instructions.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_Instructions.Location = new System.Drawing.Point(56, 365);
		this.TextBox_Instructions.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		this.TextBox_Instructions.Multiline = true;
		this.TextBox_Instructions.Name = "TextBox_Instructions";
		this.TextBox_Instructions.ReadOnly = true;
		this.TextBox_Instructions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.TextBox_Instructions.Size = new System.Drawing.Size(400, 150);
		this.TextBox_Instructions.TabIndex = 0;
		this.TextBox_Instructions.TabStop = false;
		this.TableLayoutPanel1.SetColumnSpan(this.OKButton, 2);
		this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.OKButton.Dock = System.Windows.Forms.DockStyle.Right;
		this.OKButton.Location = new System.Drawing.Point(401, 521);
		this.OKButton.Name = "OKButton";
		this.OKButton.Size = new System.Drawing.Size(105, 34);
		this.OKButton.TabIndex = 0;
		this.OKButton.Text = "确定(&O)";
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50f));
		this.TableLayoutPanel1.Controls.Add(this.LinkLabel_BuyLink, 1, 3);
		this.TableLayoutPanel1.Controls.Add(this.PictureBox_Logo, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.TextBox_Instructions, 1, 4);
		this.TableLayoutPanel1.Controls.Add(this.TextBox_ScriptName, 1, 1);
		this.TableLayoutPanel1.Controls.Add(this.TextBox_Developer, 1, 2);
		this.TableLayoutPanel1.Controls.Add(this.OKButton, 1, 5);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 6;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.03704f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.96296f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(509, 558);
		this.TableLayoutPanel1.TabIndex = 2;
		this.LinkLabel_BuyLink.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LinkLabel_BuyLink.Location = new System.Drawing.Point(53, 330);
		this.LinkLabel_BuyLink.Name = "LinkLabel_BuyLink";
		this.LinkLabel_BuyLink.Size = new System.Drawing.Size(403, 32);
		this.LinkLabel_BuyLink.TabIndex = 6;
		this.LinkLabel_BuyLink.TabStop = true;
		this.LinkLabel_BuyLink.Text = "https://ttaozi.com";
		this.LinkLabel_BuyLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.PictureBox_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox_Logo.Location = new System.Drawing.Point(53, 3);
		this.PictureBox_Logo.Name = "PictureBox_Logo";
		this.PictureBox_Logo.Size = new System.Drawing.Size(403, 256);
		this.PictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox_Logo.TabIndex = 7;
		this.PictureBox_Logo.TabStop = false;
		this.TextBox_ScriptName.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox_ScriptName.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox_ScriptName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_ScriptName.Font = new System.Drawing.Font("宋体", 20f);
		this.TextBox_ScriptName.Location = new System.Drawing.Point(53, 265);
		this.TextBox_ScriptName.Name = "TextBox_ScriptName";
		this.TextBox_ScriptName.ReadOnly = true;
		this.TextBox_ScriptName.Size = new System.Drawing.Size(403, 31);
		this.TextBox_ScriptName.TabIndex = 8;
		this.TextBox_ScriptName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.TextBox_Developer.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox_Developer.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox_Developer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_Developer.Font = new System.Drawing.Font("宋体", 14f);
		this.TextBox_Developer.Location = new System.Drawing.Point(53, 304);
		this.TextBox_Developer.Name = "TextBox_Developer";
		this.TextBox_Developer.ReadOnly = true;
		this.TextBox_Developer.Size = new System.Drawing.Size(403, 22);
		this.TextBox_Developer.TabIndex = 9;
		this.TextBox_Developer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(549, 598);
		base.Controls.Add(this.TableLayoutPanel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_ScriptInfo";
		base.Padding = new System.Windows.Forms.Padding(20);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "XXXX脚本";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Logo).EndInit();
		base.ResumeLayout(false);
	}

	private void Form_ScriptInfo_Load(object sender, EventArgs e)
	{
		TextBox_ScriptName.Text = (string)Class9.jobject_1["Name"];
		TextBox_Developer.Text = (string)Class9.jobject_1["Developer"];
		LinkLabel_BuyLink.Text = (string)Class9.jobject_1["BuyLink"];
		TextBox_Instructions.Text = (string)Class9.jobject_1["Instructions"];
	}

	private void method_0(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(LinkLabel_BuyLink.Text);
	}

	private void method_1(object sender, EventArgs e)
	{
		Close();
	}
}
