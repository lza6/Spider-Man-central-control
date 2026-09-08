using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public sealed class AboutBox : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("OKButton")]
	[CompilerGenerated]
	private Button _OKButton;

	[AccessedThroughProperty("LinkLabel1")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("LinkLabel2")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel2;

	[AccessedThroughProperty("LinkLabel3")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel3;

	[AccessedThroughProperty("LinkLabel4")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel4;

	[field: AccessedThroughProperty("TableLayoutPanel")]
	internal virtual TableLayoutPanel TableLayoutPanel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LogoPictureBox")]
	internal virtual PictureBox LogoPictureBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelProductName")]
	internal virtual Label LabelProductName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelVersion")]
	internal virtual Label LabelVersion
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelCopyright")]
	internal virtual Label LabelCopyright
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelCompanyName")]
	internal virtual Label LabelCompanyName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBoxDescription")]
	internal virtual TextBox TextBoxDescription
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
			EventHandler value2 = method_0;
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

	internal virtual LinkLabel LinkLabel1
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_1;
			LinkLabel linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel1 = value;
			linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	internal virtual LinkLabel LinkLabel2
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_2;
			LinkLabel linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel2 = value;
			linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	internal virtual LinkLabel LinkLabel3
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_3;
			LinkLabel linkLabel = _LinkLabel3;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel3 = value;
			linkLabel = _LinkLabel3;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	internal virtual LinkLabel LinkLabel4
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = method_4;
			LinkLabel linkLabel = _LinkLabel4;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel4 = value;
			linkLabel = _LinkLabel4;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	public AboutBox()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += AboutBox_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.AboutBox));
		this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
		this.LinkLabel4 = new System.Windows.Forms.LinkLabel();
		this.LogoPictureBox = new System.Windows.Forms.PictureBox();
		this.LabelProductName = new System.Windows.Forms.Label();
		this.LabelVersion = new System.Windows.Forms.Label();
		this.LabelCopyright = new System.Windows.Forms.Label();
		this.LabelCompanyName = new System.Windows.Forms.Label();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
		this.OKButton = new System.Windows.Forms.Button();
		this.TextBoxDescription = new System.Windows.Forms.TextBox();
		this.LinkLabel3 = new System.Windows.Forms.LinkLabel();
		this.TableLayoutPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.LogoPictureBox).BeginInit();
		base.SuspendLayout();
		this.TableLayoutPanel.ColumnCount = 3;
		this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186f));
		this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24f));
		this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel.Controls.Add(this.LinkLabel4, 2, 7);
		this.TableLayoutPanel.Controls.Add(this.LogoPictureBox, 0, 0);
		this.TableLayoutPanel.Controls.Add(this.LabelProductName, 2, 0);
		this.TableLayoutPanel.Controls.Add(this.LabelVersion, 2, 1);
		this.TableLayoutPanel.Controls.Add(this.LabelCopyright, 2, 2);
		this.TableLayoutPanel.Controls.Add(this.LabelCompanyName, 2, 3);
		this.TableLayoutPanel.Controls.Add(this.LinkLabel1, 2, 4);
		this.TableLayoutPanel.Controls.Add(this.LinkLabel2, 2, 5);
		this.TableLayoutPanel.Controls.Add(this.OKButton, 2, 9);
		this.TableLayoutPanel.Controls.Add(this.TextBoxDescription, 2, 8);
		this.TableLayoutPanel.Controls.Add(this.LinkLabel3, 2, 6);
		this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel.Location = new System.Drawing.Point(9, 8);
		this.TableLayoutPanel.Name = "TableLayoutPanel";
		this.TableLayoutPanel.RowCount = 10;
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28859f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28859f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28859f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28859f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28859f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28038f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.27669f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142f));
		this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36f));
		this.TableLayoutPanel.Size = new System.Drawing.Size(630, 379);
		this.TableLayoutPanel.TabIndex = 0;
		this.LinkLabel4.AutoSize = true;
		this.LinkLabel4.Location = new System.Drawing.Point(213, 175);
		this.LinkLabel4.Name = "LinkLabel4";
		this.LinkLabel4.Size = new System.Drawing.Size(77, 12);
		this.LinkLabel4.TabIndex = 5;
		this.LinkLabel4.TabStop = true;
		this.LinkLabel4.Text = "中控使用帮助";
		this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LogoPictureBox.Image = (System.Drawing.Image)resources.GetObject("LogoPictureBox.Image");
		this.LogoPictureBox.Location = new System.Drawing.Point(3, 3);
		this.LogoPictureBox.Name = "LogoPictureBox";
		this.TableLayoutPanel.SetRowSpan(this.LogoPictureBox, 10);
		this.LogoPictureBox.Size = new System.Drawing.Size(180, 373);
		this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.LogoPictureBox.TabIndex = 0;
		this.LogoPictureBox.TabStop = false;
		this.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LabelProductName.Location = new System.Drawing.Point(216, 0);
		this.LabelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.LabelProductName.MaximumSize = new System.Drawing.Size(0, 16);
		this.LabelProductName.Name = "LabelProductName";
		this.LabelProductName.Size = new System.Drawing.Size(411, 16);
		this.LabelProductName.TabIndex = 0;
		this.LabelProductName.Text = "产品名称";
		this.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LabelVersion.Location = new System.Drawing.Point(216, 25);
		this.LabelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.LabelVersion.MaximumSize = new System.Drawing.Size(0, 16);
		this.LabelVersion.Name = "LabelVersion";
		this.LabelVersion.Size = new System.Drawing.Size(411, 16);
		this.LabelVersion.TabIndex = 0;
		this.LabelVersion.Text = "版本";
		this.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LabelCopyright.Location = new System.Drawing.Point(216, 50);
		this.LabelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.LabelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
		this.LabelCopyright.Name = "LabelCopyright";
		this.LabelCopyright.Size = new System.Drawing.Size(411, 16);
		this.LabelCopyright.TabIndex = 0;
		this.LabelCopyright.Text = "版权";
		this.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LabelCompanyName.Location = new System.Drawing.Point(216, 75);
		this.LabelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.LabelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
		this.LabelCompanyName.Name = "LabelCompanyName";
		this.LabelCompanyName.Size = new System.Drawing.Size(411, 16);
		this.LabelCompanyName.TabIndex = 0;
		this.LabelCompanyName.Text = "公司名称";
		this.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Location = new System.Drawing.Point(213, 100);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(137, 12);
		this.LinkLabel1.TabIndex = 2;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "http://www.xxtouch.com";
		this.LinkLabel2.AutoSize = true;
		this.LinkLabel2.Location = new System.Drawing.Point(213, 125);
		this.LinkLabel2.Name = "LinkLabel2";
		this.LinkLabel2.Size = new System.Drawing.Size(131, 12);
		this.LinkLabel2.TabIndex = 3;
		this.LinkLabel2.TabStop = true;
		this.LinkLabel2.Text = "QQ群:XXTouch 40898074";
		this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.OKButton.Dock = System.Windows.Forms.DockStyle.Right;
		this.OKButton.Location = new System.Drawing.Point(494, 344);
		this.OKButton.Name = "OKButton";
		this.OKButton.Size = new System.Drawing.Size(133, 32);
		this.OKButton.TabIndex = 0;
		this.OKButton.Text = "确定(&O)";
		this.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBoxDescription.Location = new System.Drawing.Point(216, 202);
		this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		this.TextBoxDescription.Multiline = true;
		this.TextBoxDescription.Name = "TextBoxDescription";
		this.TextBoxDescription.ReadOnly = true;
		this.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.TextBoxDescription.Size = new System.Drawing.Size(411, 136);
		this.TextBoxDescription.TabIndex = 0;
		this.TextBoxDescription.TabStop = false;
		this.TextBoxDescription.Text = "说明 :\r\n\r\n(在运行时，将用应用程序的程序集信息替换这些标签的文本。\r\n在";
		this.LinkLabel3.AutoSize = true;
		this.LinkLabel3.Location = new System.Drawing.Point(213, 150);
		this.LinkLabel3.Name = "LinkLabel3";
		this.LinkLabel3.Size = new System.Drawing.Size(155, 12);
		this.LinkLabel3.TabIndex = 4;
		this.LinkLabel3.TabStop = true;
		this.LinkLabel3.Text = "反馈建议:270001300@qq.com";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.OKButton;
		base.ClientSize = new System.Drawing.Size(648, 395);
		base.Controls.Add(this.TableLayoutPanel);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AboutBox";
		base.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "AboutBox1";
		this.TableLayoutPanel.ResumeLayout(false);
		this.TableLayoutPanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.LogoPictureBox).EndInit();
		base.ResumeLayout(false);
	}

	private void AboutBox_Load(object sender, EventArgs e)
	{
		string arg = ((Operators.CompareString(Class3.Class1_0.Info.Title, "", TextCompare: false) == 0) ? Path.GetFileNameWithoutExtension(Class3.Class1_0.Info.AssemblyName) : Class3.Class1_0.Info.Title);
		Text = $"关于 {arg}";
		LabelProductName.Text = Class3.Class1_0.Info.ProductName;
		LabelVersion.Text = $"版本 {Class3.Class1_0.Info.Version.ToString()}";
		LabelCopyright.Text = Class3.Class1_0.Info.Copyright;
		LabelCompanyName.Text = Class3.Class1_0.Info.CompanyName;
		TextBoxDescription.Text = "\r\n中控为良性软件,不会加入涉及设备数据或PC数据的操作 \r\n软件如果出现任何BUG可以反馈给我,但不接受任何私有化建议.\r\n";
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://www.xxtouch.com");
	}

	private void method_2(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://jq.qq.com/?_wv=1027&k=2BJwk9B");
	}

	private void method_3(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("mailto:270001300@qq.com");
	}

	private void method_4(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://www.xxtouch.com/xxtcc");
	}
}
