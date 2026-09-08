using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Form_Scan : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_Search")]
	[CompilerGenerated]
	private Button _Button_Search;

	[AccessedThroughProperty("ListBox_ip_list")]
	[CompilerGenerated]
	private ListBox _ListBox_ip_list;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private Button _Button2;

	[field: AccessedThroughProperty("MaskedTextBox1")]
	internal virtual MaskedTextBox MaskedTextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_Search
	{
		[CompilerGenerated]
		get
		{
			return _Button_Search;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			Button button = _Button_Search;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Search = value;
			button = _Button_Search;
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

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual GroupBox GroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ListBox ListBox_ip_list
	{
		[CompilerGenerated]
		get
		{
			return _ListBox_ip_list;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			EventHandler value3 = method_4;
			ListBox listBox = _ListBox_ip_list;
			if (listBox != null)
			{
				listBox.SelectedValueChanged -= value2;
				listBox.SelectedIndexChanged -= value3;
			}
			_ListBox_ip_list = value;
			listBox = _ListBox_ip_list;
			if (listBox != null)
			{
				listBox.SelectedValueChanged += value2;
				listBox.SelectedIndexChanged += value3;
			}
		}
	}

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_2;
			Button button = _Button1;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button1 = value;
			button = _Button1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			Button button = _Button2;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button2 = value;
			button = _Button2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public Form_Scan()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_Scan_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_Scan));
		this.MaskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
		this.Button_Search = new System.Windows.Forms.Button();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button1 = new System.Windows.Forms.Button();
		this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ListBox_ip_list = new System.Windows.Forms.ListBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
		this.SplitContainer1.Panel1.SuspendLayout();
		this.SplitContainer1.Panel2.SuspendLayout();
		this.SplitContainer1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		base.SuspendLayout();
		this.MaskedTextBox1.Font = new System.Drawing.Font("宋体", 20f);
		this.MaskedTextBox1.Location = new System.Drawing.Point(28, 60);
		this.MaskedTextBox1.Mask = "000.000.000.*";
		this.MaskedTextBox1.Name = "MaskedTextBox1";
		this.MaskedTextBox1.Size = new System.Drawing.Size(252, 38);
		this.MaskedTextBox1.TabIndex = 0;
		this.Button_Search.Location = new System.Drawing.Point(177, 123);
		this.Button_Search.Name = "Button_Search";
		this.Button_Search.Size = new System.Drawing.Size(103, 44);
		this.Button_Search.TabIndex = 1;
		this.Button_Search.Text = "TCP搜索";
		this.Button_Search.UseVisualStyleBackColor = true;
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127f));
		this.TableLayoutPanel1.Controls.Add(this.Button1, 2, 1);
		this.TableLayoutPanel1.Controls.Add(this.SplitContainer1, 0, 0);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 2;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(520, 292);
		this.TableLayoutPanel1.TabIndex = 2;
		this.Button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button1.Location = new System.Drawing.Point(403, 248);
		this.Button1.Margin = new System.Windows.Forms.Padding(10);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(107, 34);
		this.Button1.TabIndex = 2;
		this.Button1.Text = "完成";
		this.Button1.UseVisualStyleBackColor = true;
		this.TableLayoutPanel1.SetColumnSpan(this.SplitContainer1, 3);
		this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
		this.SplitContainer1.Name = "SplitContainer1";
		this.SplitContainer1.Panel1.Controls.Add(this.GroupBox1);
		this.SplitContainer1.Panel2.Controls.Add(this.GroupBox2);
		this.SplitContainer1.Size = new System.Drawing.Size(514, 232);
		this.SplitContainer1.SplitterDistance = 193;
		this.SplitContainer1.SplitterWidth = 10;
		this.SplitContainer1.TabIndex = 3;
		this.GroupBox1.Controls.Add(this.ListBox_ip_list);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox1.Location = new System.Drawing.Point(0, 0);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Padding = new System.Windows.Forms.Padding(10);
		this.GroupBox1.Size = new System.Drawing.Size(193, 232);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "IP段列表";
		this.ListBox_ip_list.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListBox_ip_list.FormattingEnabled = true;
		this.ListBox_ip_list.ItemHeight = 12;
		this.ListBox_ip_list.Location = new System.Drawing.Point(10, 24);
		this.ListBox_ip_list.Name = "ListBox_ip_list";
		this.ListBox_ip_list.Size = new System.Drawing.Size(173, 198);
		this.ListBox_ip_list.TabIndex = 3;
		this.GroupBox2.Controls.Add(this.Button2);
		this.GroupBox2.Controls.Add(this.MaskedTextBox1);
		this.GroupBox2.Controls.Add(this.Button_Search);
		this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox2.Location = new System.Drawing.Point(0, 0);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(311, 232);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "扫描方式";
		this.Button2.Location = new System.Drawing.Point(28, 123);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(103, 44);
		this.Button2.TabIndex = 2;
		this.Button2.Text = "UDP搜索";
		this.Button2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(520, 292);
		base.Controls.Add(this.TableLayoutPanel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_Scan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "网段扫描";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.SplitContainer1.Panel1.ResumeLayout(false);
		this.SplitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
		this.SplitContainer1.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		base.ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		string text = "";
		string[] array = Strings.Split(MaskedTextBox1.Text.Replace(" ", ""), ".");
		int num = 0;
		checked
		{
			while (true)
			{
				if (num < array.Length)
				{
					string text2 = array[num];
					if (text2.Length <= 0)
					{
						break;
					}
					text = text + Conversions.ToString(Conversions.ToInteger(text2)) + ".";
					if (text.Split('.').Length != 4)
					{
						num++;
						continue;
					}
				}
				int num2 = 1;
				do
				{
					ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
					{
						Class8.smethod_0(Conversions.ToString(a0));
					}, text + num2);
					num2++;
				}
				while (num2 <= 255);
				return;
			}
			MessageBox.Show("输入的IP地址不正确", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Form_Scan_Load(object sender, EventArgs e)
	{
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				ListBox_ip_list.Items.Add(iPAddress.ToString());
			}
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		try
		{
			string[] array = ListBox_ip_list.SelectedItem.ToString().ToString().Split('.');
			MaskedTextBox1.Text = $"{array[0].PadRight(3, ' ')}.{array[1].PadRight(3, ' ')}.{array[2].PadRight(3, ' ')}.*";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		string text = "";
		string[] array = Strings.Split(MaskedTextBox1.Text.Replace(" ", ""), ".");
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				string text2 = array[num];
				if (text2.Length <= 0)
				{
					break;
				}
				text = text + Conversions.ToString(Conversions.ToInteger(text2)) + ".";
				if (text.Split('.').Length != 4)
				{
					num = checked(num + 1);
					continue;
				}
			}
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
				{
					string string_ = JsonConvert.SerializeObject((object)new JObject(new object[2]
					{
						(object)new JProperty("ip", (object)iPAddress.ToString()),
						(object)new JProperty("port", (object)27000)
					}));
					Class8.smethod_32(text + "255", 46953, string_);
				}
			}
			return;
		}
		MessageBox.Show("输入的IP地址不正确", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	private void method_4(object sender, EventArgs e)
	{
	}
}
