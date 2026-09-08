using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Form_synchronous : Form
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__27_002D0
	{
		public string _0024VB_0024Local_NowTime;

		public string _0024VB_0024Local_IP;

		public string _0024VB_0024Local_Text;

		public Form_synchronous _0024VB_0024Me;

		public _Closure_0024__27_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				if (Information.UBound(Strings.Split(_0024VB_0024Me.RichTextBox_Log.Text, "\r\n")) > 300)
				{
					_0024VB_0024Me.RichTextBox_Log.Text = "";
				}
				_0024VB_0024Me.RichTextBox_Log.AppendText(" ");
				_0024VB_0024Me.RichTextBox_Log.SelectionFont = new Font("宋体", 9f, FontStyle.Bold);
				_0024VB_0024Me.RichTextBox_Log.SelectionColor = Color.Red;
				_0024VB_0024Me.RichTextBox_Log.AppendText("[" + _0024VB_0024Local_NowTime + "] [" + _0024VB_0024Local_IP + "]: ");
				_0024VB_0024Me.RichTextBox_Log.SelectionFont = new Font("宋体", 9f, FontStyle.Regular);
				_0024VB_0024Me.RichTextBox_Log.SelectionColor = Color.Black;
				_0024VB_0024Me.RichTextBox_Log.AppendText(" ");
				_0024VB_0024Me.RichTextBox_Log.AppendText(_0024VB_0024Local_Text + "\r\n");
				if (_0024VB_0024Me.RichTextBox_Log.SelectionStart == _0024VB_0024Me.RichTextBox_Log.Text.Length)
				{
					_0024VB_0024Me.RichTextBox_Log.ScrollToCaret();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_Cancel")]
	[CompilerGenerated]
	private Button _Button_Cancel;

	public bool _c;

	public JArray _IP;

	[field: AccessedThroughProperty("ProgressBar1")]
	internal virtual ProgressBar ProgressBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("RichTextBox_Log")]
	internal virtual RichTextBox RichTextBox_Log
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
			EventHandler value2 = method_0;
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

	public Form_synchronous()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += iHatzTujhC;
		base.FormClosing += Form_synchronous_FormClosing;
		_c = false;
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
		this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
		this.RichTextBox_Log = new System.Windows.Forms.RichTextBox();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button_Cancel = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ProgressBar1.Location = new System.Drawing.Point(10, 191);
		this.ProgressBar1.Margin = new System.Windows.Forms.Padding(10);
		this.ProgressBar1.Name = "ProgressBar1";
		this.ProgressBar1.Size = new System.Drawing.Size(195, 33);
		this.ProgressBar1.TabIndex = 0;
		this.RichTextBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TableLayoutPanel1.SetColumnSpan(this.RichTextBox_Log, 2);
		this.RichTextBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
		this.RichTextBox_Log.Location = new System.Drawing.Point(10, 10);
		this.RichTextBox_Log.Margin = new System.Windows.Forms.Padding(10);
		this.RichTextBox_Log.Name = "RichTextBox_Log";
		this.RichTextBox_Log.Size = new System.Drawing.Size(367, 161);
		this.RichTextBox_Log.TabIndex = 1;
		this.RichTextBox_Log.Text = "";
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172f));
		this.TableLayoutPanel1.Controls.Add(this.ProgressBar1, 0, 1);
		this.TableLayoutPanel1.Controls.Add(this.RichTextBox_Log, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button_Cancel, 1, 1);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 2;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(387, 234);
		this.TableLayoutPanel1.TabIndex = 2;
		this.Button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Cancel.Location = new System.Drawing.Point(225, 191);
		this.Button_Cancel.Margin = new System.Windows.Forms.Padding(10);
		this.Button_Cancel.Name = "Button_Cancel";
		this.Button_Cancel.Size = new System.Drawing.Size(152, 33);
		this.Button_Cancel.TabIndex = 2;
		this.Button_Cancel.Text = "取消";
		this.Button_Cancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(387, 234);
		base.Controls.Add(this.TableLayoutPanel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_synchronous";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "同步目录";
		this.TableLayoutPanel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void iHatzTujhC(object sender, EventArgs e)
	{
		ProgressBar1.Maximum = ((JContainer)_IP).Count;
		ProgressBar1.Minimum = 0;
		ProgressBar1.Value = 0;
		new Thread([SpecialName] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			foreach (JObject item in ((JContainer)_IP).Children())
			{
				JObject val = item;
				ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
				{
					syn(Conversions.ToString(a0));
				}, val["ip"].ToString());
			}
		}).Start();
	}

	public void syn(string ip)
	{
		try
		{
			同步(ip, "", "");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			AddLog(ip, "同步出现超时");
			ProjectData.ClearProjectError();
		}
		Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
		{
			ProgressBar1.Value = checked(ProgressBar1.Value + 1);
			if (ProgressBar1.Value == ProgressBar1.Maximum)
			{
				base.DialogResult = DialogResult.OK;
			}
		}));
	}

	public void 同步(string IP, string 目录, string ux目录)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		if (_c)
		{
			return;
		}
		string[] directories = Directory.GetDirectories(Application.StartupPath + "\\1ferver" + 目录.Replace("/", "\\"));
		string[] files = Directory.GetFiles(Application.StartupPath + "\\1ferver" + 目录.Replace("/", "\\"));
		JObject val = JObject.Parse(Class8.smethod_33("http://" + IP + ":46952/file_list", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("directory", (object)ux目录)))));
		string[] array = directories;
		foreach (string path in array)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			string name = directoryInfo.Name;
			bool flag = true;
			foreach (JObject item in (IEnumerable<JToken>)val["data"][(object)"list"])
			{
				JObject val2 = item;
				if ((string)val2["name"] == directoryInfo.Name)
				{
					if (!((string)val2["mode"] == "file"))
					{
						flag = false;
						break;
					}
					Class8.smethod_33("http://" + IP + ":46952/remove_file", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("filename", (object)(ux目录 + "/" + name)))));
				}
			}
			if (flag)
			{
				if (Class8.smethod_35("http://" + IP + ":46952/mkdir", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject((object)new JProperty("directory", (object)(ux目录 + "/" + name)))))).Contains("message"))
				{
					AddLog(IP, "创建目录 " + directoryInfo.Name);
				}
				else
				{
					AddLog(IP, "超时");
				}
			}
			同步(IP, 目录 + "/" + directoryInfo.Name, ux目录 + "/" + name);
		}
		string text = "";
		string[] array2 = files;
		foreach (string text2 in array2)
		{
			FileInfo fileInfo = new FileInfo(text2);
			string name2 = fileInfo.Name;
			bool flag2 = true;
			foreach (JObject item2 in (IEnumerable<JToken>)val["data"][(object)"list"])
			{
				JObject val3 = item2;
				if ((string)val3["name"] == fileInfo.Name)
				{
					if (!((string)val3["mode"] == "file"))
					{
						Class8.smethod_33("http://" + IP + ":46952/rmdir", JsonConvert.SerializeObject((object)new JObject((object)new JProperty("directory", (object)(ux目录 + "/" + name2)))));
					}
					if (Conversion.Val(val3["access"]) == Math.Abs(Conversion.Val(DateAndTime.DateDiff(DateInterval.Second, fileInfo.LastWriteTimeUtc, new DateTime(1970, 1, 1, 0, 0, 0)))))
					{
						flag2 = false;
						break;
					}
				}
			}
			if (flag2)
			{
				if (!Class8.smethod_35("http://" + IP + ":46952/write_file", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)new JObject(new object[2]
				{
					(object)new JProperty("filename", (object)(ux目录 + "/" + name2)),
					(object)new JProperty("data", (object)Convert.ToBase64String(File.ReadAllBytes(text2)))
				})))).Contains("message"))
				{
					AddLog(IP, "超时");
					break;
				}
				text = text + $"string.format(\"touch -acfm -t %s %s\",os.date(\"%Y%m%d%H%M.%S\", {Math.Abs(Conversion.Val(DateAndTime.DateDiff(DateInterval.Second, fileInfo.LastWriteTimeUtc, new DateTime(1970, 1, 1, 0, 0, 0))))}),[=[{name2}]=])" + ",";
				AddLog(IP, "发送 " + fileInfo.Name);
			}
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			AddLog(IP, "修改文件修改时间");
			Class8.smethod_33("http://" + IP + ":46952/command_spawn", "local now_path = '" + ux目录 + "'\r\nos.execute(\r\n\ttable.concat(\r\n\t\t{\r\n\t\t\t'cd /var/mobile/Media/1ferver/' .. now_path,\r\n\t\t\t" + text + "\r\n\t\t}\r\n\t\t,'\\n'\r\n\t)\r\n)");
		}
		AddLog(IP, "同步完毕");
		Class8.smethod_30(IP, "同步完毕");
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (_c)
		{
			return;
		}
		foreach (JObject item in ((JContainer)_IP).Children())
		{
			Class8.smethod_30(item["ip"].ToString(), "同步停止");
		}
		_c = true;
		base.DialogResult = DialogResult.Cancel;
	}

	private void Form_synchronous_FormClosing(object sender, FormClosingEventArgs e)
	{
		_c = true;
	}

	public void AddLog(string IP, string Text)
	{
		_Closure_0024__27_002D0 CS_0024_003C_003E8__locals20 = new _Closure_0024__27_002D0();
		CS_0024_003C_003E8__locals20._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals20._0024VB_0024Local_IP = IP;
		CS_0024_003C_003E8__locals20._0024VB_0024Local_Text = Text;
		CS_0024_003C_003E8__locals20._0024VB_0024Local_NowTime = Strings.Format(DateAndTime.Now, "HH:mm:ss");
		try
		{
			Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				try
				{
					if (Information.UBound(Strings.Split(CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.Text, "\r\n")) > 300)
					{
						CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.Text = "";
					}
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.AppendText(" ");
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.SelectionFont = new Font("宋体", 9f, FontStyle.Bold);
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.SelectionColor = Color.Red;
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.AppendText("[" + CS_0024_003C_003E8__locals20._0024VB_0024Local_NowTime + "] [" + CS_0024_003C_003E8__locals20._0024VB_0024Local_IP + "]: ");
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.SelectionFont = new Font("宋体", 9f, FontStyle.Regular);
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.SelectionColor = Color.Black;
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.AppendText(" ");
					CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.AppendText(CS_0024_003C_003E8__locals20._0024VB_0024Local_Text + "\r\n");
					if (CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.SelectionStart == CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.Text.Length)
					{
						CS_0024_003C_003E8__locals20._0024VB_0024Me.RichTextBox_Log.ScrollToCaret();
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
