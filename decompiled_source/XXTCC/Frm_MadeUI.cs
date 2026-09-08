using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Frm_MadeUI : Form
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__133_002D0
	{
		public TableLayoutPanel _0024VB_0024Local_cfg_Panel;

		public _Closure_0024__133_002D0(_Closure_0024__133_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_cfg_Panel = arg0._0024VB_0024Local_cfg_Panel;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R1(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			JObject val = new JObject();
			checked
			{
				try
				{
					foreach (Control control in _0024VB_0024Local_cfg_Panel.Controls)
					{
						switch (control.GetType().ToString())
						{
						case "System.Windows.Forms.CheckedListBox":
						{
							CheckedListBox checkedListBox = (CheckedListBox)control;
							JArray val2 = new JArray();
							int count = checkedListBox.Items.Count;
							for (int i = 1; i <= count; i++)
							{
								if (checkedListBox.GetItemChecked(i - 1))
								{
									val2.Add(JToken.op_Implicit(i));
								}
							}
							if (val[control.Name] == null)
							{
								((JContainer)val).Add((object)new JProperty(control.Name, (object)val2));
							}
							else
							{
								val[control.Name] = (JToken)(object)val2;
							}
							break;
						}
						case "System.Windows.Forms.ListBox":
						{
							ListBox listBox = (ListBox)control;
							if (val[control.Name] == null)
							{
								((JContainer)val).Add((object)new JProperty(control.Name, (object)(listBox.SelectedIndex + 1)));
							}
							else
							{
								val[control.Name] = JToken.op_Implicit(listBox.SelectedIndex + 1);
							}
							break;
						}
						case "System.Windows.Forms.ComboBox":
						{
							ComboBox comboBox = (ComboBox)control;
							if (val[control.Name] == null)
							{
								((JContainer)val).Add((object)new JProperty(control.Name, (object)(comboBox.SelectedIndex + 1)));
							}
							else
							{
								val[control.Name] = JToken.op_Implicit(comboBox.SelectedIndex + 1);
							}
							break;
						}
						case "System.Windows.Forms.TextBox":
							if (val[control.Name] == null)
							{
								((JContainer)val).Add((object)new JProperty(control.Name, (object)control.Text));
							}
							else
							{
								val[control.Name] = JToken.op_Implicit(control.Text);
							}
							break;
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				MessageBox.Show(JsonConvert.SerializeObject((object)val), "UI提交值", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__141_002D0
	{
		public Form_Key _0024VB_0024Local_f;

		public Frm_MadeUI _0024VB_0024Me;

		public _Closure_0024__141_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ListViewItem value = new ListViewItem
			{
				Text = _0024VB_0024Local_f.TextBox_Name.Text,
				SubItems = { _0024VB_0024Local_f.TextBox_Instructions.Text }
			};
			_0024VB_0024Me.ListView_Key.Items.Add(value);
			_0024VB_0024Local_f.Close();
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object sender, EventArgs e)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Local_f.Close();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__142_002D0
	{
		public ListViewItem _0024VB_0024Local_selectitem;

		public Form_Key _0024VB_0024Local_f;

		public _Closure_0024__142_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object sender, EventArgs e)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Local_selectitem.SubItems[1].Text = _0024VB_0024Local_f.TextBox_Instructions.Text;
			_0024VB_0024Local_f.Close();
		}

		[SpecialName]
		internal void _Lambda_0024__R5(object sender, EventArgs e)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Local_f.Close();
		}
	}

	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SaveUI")]
	private Button _Button_SaveUI;

	[AccessedThroughProperty("TextBox_UI")]
	[CompilerGenerated]
	private TextBox _TextBox_UI;

	[AccessedThroughProperty("_OpenFileDialog")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private Button _Button2;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private Button sflAmoLhox;

	[AccessedThroughProperty("LinkLabel1")]
	[CompilerGenerated]
	private LinkLabel _LinkLabel1;

	[CompilerGenerated]
	[AccessedThroughProperty("添加ToolStripMenuItem")]
	private ToolStripMenuItem _添加ToolStripMenuItem;

	[AccessedThroughProperty("修改ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _修改ToolStripMenuItem;

	[AccessedThroughProperty("删除ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _删除ToolStripMenuItem;

	[field: AccessedThroughProperty("TableLayoutPanel_UI")]
	internal virtual TableLayoutPanel TableLayoutPanel_UI
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_UI_Error")]
	internal virtual GroupBox GroupBox_UI_Error
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_SaveUI
	{
		[CompilerGenerated]
		get
		{
			return _Button_SaveUI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_1;
			Button button = _Button_SaveUI;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_SaveUI = value;
			button = _Button_SaveUI;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TextBox_UI
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_UI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_5;
			TextBox textBox = _TextBox_UI;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			_TextBox_UI = value;
			textBox = _TextBox_UI;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual TabControl TabControl1
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

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2
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

	[field: AccessedThroughProperty("PictureBox_Logo")]
	internal virtual PictureBox PictureBox_Logo
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_Instructions")]
	internal virtual TextBox TextBox_Instructions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_BuyLink")]
	internal virtual TextBox TextBox_BuyLink
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button3
	{
		[CompilerGenerated]
		get
		{
			return sflAmoLhox;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_4;
			Button button = sflAmoLhox;
			if (button != null)
			{
				button.Click -= value2;
			}
			sflAmoLhox = value;
			button = sflAmoLhox;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1
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
			LinkLabelLinkClickedEventHandler value2 = method_6;
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
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

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ListView_Key")]
	internal virtual ListView ListView_Key
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ContextMenuStrip1")]
	internal virtual ContextMenuStrip ContextMenuStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem 添加ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _添加ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_7;
			ToolStripMenuItem toolStripMenuItem = _添加ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_添加ToolStripMenuItem = value;
			toolStripMenuItem = _添加ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 修改ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _修改ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			ToolStripMenuItem toolStripMenuItem = _修改ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_修改ToolStripMenuItem = value;
			toolStripMenuItem = _修改ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 删除ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _删除ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_9;
			ToolStripMenuItem toolStripMenuItem = _删除ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_删除ToolStripMenuItem = value;
			toolStripMenuItem = _删除ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	public Frm_MadeUI()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Frm_MadeUI_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Frm_MadeUI));
		this.TableLayoutPanel_UI = new System.Windows.Forms.TableLayoutPanel();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.GroupBox_UI_Error = new System.Windows.Forms.GroupBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.TextBox_UI = new System.Windows.Forms.TextBox();
		this.Button_SaveUI = new System.Windows.Forms.Button();
		this.vmethod_1(new System.Windows.Forms.OpenFileDialog());
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button1 = new System.Windows.Forms.Button();
		this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
		this.TextBox_Instructions = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.TextBox_BuyLink = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.TextBox_Developer = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.TextBox_ScriptName = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.ListView_Key = new System.Windows.Forms.ListView();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button3 = new System.Windows.Forms.Button();
		this.TableLayoutPanel_UI.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox_UI_Error.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Logo).BeginInit();
		this.TabPage2.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.ContextMenuStrip1.SuspendLayout();
		this.TableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel_UI.ColumnCount = 2;
		this.TableLayoutPanel_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.49119f));
		this.TableLayoutPanel_UI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270f));
		this.TableLayoutPanel_UI.Controls.Add(this.GroupBox1, 0, 2);
		this.TableLayoutPanel_UI.Controls.Add(this.Panel1, 1, 0);
		this.TableLayoutPanel_UI.Controls.Add(this.GroupBox_UI_Error, 0, 1);
		this.TableLayoutPanel_UI.Controls.Add(this.TextBox_UI, 0, 0);
		this.TableLayoutPanel_UI.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_UI.Location = new System.Drawing.Point(3, 3);
		this.TableLayoutPanel_UI.Name = "TableLayoutPanel_UI";
		this.TableLayoutPanel_UI.RowCount = 3;
		this.TableLayoutPanel_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.12953f));
		this.TableLayoutPanel_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62f));
		this.TableLayoutPanel_UI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59f));
		this.TableLayoutPanel_UI.Size = new System.Drawing.Size(805, 366);
		this.TableLayoutPanel_UI.TabIndex = 1;
		this.GroupBox1.Controls.Add(this.LinkLabel1);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox1.Location = new System.Drawing.Point(3, 310);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(529, 53);
		this.GroupBox1.TabIndex = 3;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "相关介绍";
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Location = new System.Drawing.Point(18, 27);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(65, 12);
		this.LinkLabel1.TabIndex = 0;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "UI制作简介";
		this.Panel1.AutoScroll = true;
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Panel1.Location = new System.Drawing.Point(538, 3);
		this.Panel1.Name = "Panel1";
		this.TableLayoutPanel_UI.SetRowSpan(this.Panel1, 3);
		this.Panel1.Size = new System.Drawing.Size(264, 360);
		this.Panel1.TabIndex = 2;
		this.GroupBox_UI_Error.Controls.Add(this.TextBox1);
		this.GroupBox_UI_Error.Controls.Add(this.Label5);
		this.GroupBox_UI_Error.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_UI_Error.Location = new System.Drawing.Point(3, 248);
		this.GroupBox_UI_Error.Name = "GroupBox_UI_Error";
		this.GroupBox_UI_Error.Size = new System.Drawing.Size(529, 56);
		this.GroupBox_UI_Error.TabIndex = 0;
		this.GroupBox_UI_Error.TabStop = false;
		this.GroupBox_UI_Error.Text = "错误信息";
		this.TextBox1.Location = new System.Drawing.Point(55, 25);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(640, 21);
		this.TextBox1.TabIndex = 1;
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(14, 28);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(35, 12);
		this.Label5.TabIndex = 0;
		this.Label5.Text = "错误:";
		this.TextBox_UI.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox_UI.Location = new System.Drawing.Point(3, 3);
		this.TextBox_UI.Multiline = true;
		this.TextBox_UI.Name = "TextBox_UI";
		this.TextBox_UI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.TextBox_UI.Size = new System.Drawing.Size(529, 239);
		this.TextBox_UI.TabIndex = 1;
		this.TextBox_UI.Text = resources.GetString("TextBox_UI.Text");
		this.Button_SaveUI.Location = new System.Drawing.Point(674, 407);
		this.Button_SaveUI.Name = "Button_SaveUI";
		this.Button_SaveUI.Size = new System.Drawing.Size(142, 52);
		this.Button_SaveUI.TabIndex = 1;
		this.Button_SaveUI.Text = "保存配置";
		this.Button_SaveUI.UseVisualStyleBackColor = true;
		this.vmethod_0().FileName = "OpenFileDialog1";
		this.TableLayoutPanel1.SetColumnSpan(this.TabControl1, 3);
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TabControl1.Location = new System.Drawing.Point(3, 3);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(819, 398);
		this.TabControl1.TabIndex = 2;
		this.TabPage1.Controls.Add(this.Button2);
		this.TabPage1.Controls.Add(this.Button1);
		this.TabPage1.Controls.Add(this.PictureBox_Logo);
		this.TabPage1.Controls.Add(this.TextBox_Instructions);
		this.TabPage1.Controls.Add(this.Label4);
		this.TabPage1.Controls.Add(this.TextBox_BuyLink);
		this.TabPage1.Controls.Add(this.Label3);
		this.TabPage1.Controls.Add(this.TextBox_Developer);
		this.TabPage1.Controls.Add(this.Label2);
		this.TabPage1.Controls.Add(this.TextBox_ScriptName);
		this.TabPage1.Controls.Add(this.Label1);
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(811, 372);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "脚本信息";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.Button2.Location = new System.Drawing.Point(712, 213);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(58, 33);
		this.Button2.TabIndex = 10;
		this.Button2.Text = "清除";
		this.Button2.UseVisualStyleBackColor = true;
		this.Button1.Location = new System.Drawing.Point(589, 213);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(117, 33);
		this.Button1.TabIndex = 9;
		this.Button1.Text = "浏览...";
		this.Button1.UseVisualStyleBackColor = true;
		this.PictureBox_Logo.BackColor = System.Drawing.Color.LightBlue;
		this.PictureBox_Logo.Location = new System.Drawing.Point(589, 46);
		this.PictureBox_Logo.Name = "PictureBox_Logo";
		this.PictureBox_Logo.Size = new System.Drawing.Size(181, 161);
		this.PictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox_Logo.TabIndex = 8;
		this.PictureBox_Logo.TabStop = false;
		this.TextBox_Instructions.Location = new System.Drawing.Point(84, 102);
		this.TextBox_Instructions.Multiline = true;
		this.TextBox_Instructions.Name = "TextBox_Instructions";
		this.TextBox_Instructions.Size = new System.Drawing.Size(453, 216);
		this.TextBox_Instructions.TabIndex = 7;
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(19, 105);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(59, 12);
		this.Label4.TabIndex = 6;
		this.Label4.Text = "使用方法:";
		this.TextBox_BuyLink.Location = new System.Drawing.Point(84, 75);
		this.TextBox_BuyLink.Name = "TextBox_BuyLink";
		this.TextBox_BuyLink.Size = new System.Drawing.Size(453, 21);
		this.TextBox_BuyLink.TabIndex = 5;
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(19, 78);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(59, 12);
		this.Label3.TabIndex = 4;
		this.Label3.Text = "购买链接:";
		this.TextBox_Developer.Location = new System.Drawing.Point(84, 48);
		this.TextBox_Developer.Name = "TextBox_Developer";
		this.TextBox_Developer.Size = new System.Drawing.Size(171, 21);
		this.TextBox_Developer.TabIndex = 3;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(19, 51);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(59, 12);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "联系作者:";
		this.TextBox_ScriptName.Location = new System.Drawing.Point(84, 21);
		this.TextBox_ScriptName.Name = "TextBox_ScriptName";
		this.TextBox_ScriptName.Size = new System.Drawing.Size(150, 21);
		this.TextBox_ScriptName.TabIndex = 1;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(19, 24);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(47, 12);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "脚本名:";
		this.TabPage2.Controls.Add(this.TableLayoutPanel_UI);
		this.TabPage2.Location = new System.Drawing.Point(4, 22);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage2.Size = new System.Drawing.Size(811, 372);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "中控UI配置";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.TabPage3.Controls.Add(this.ListView_Key);
		this.TabPage3.Location = new System.Drawing.Point(4, 22);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(811, 372);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "推送配置表";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.ListView_Key.ContextMenuStrip = this.ContextMenuStrip1;
		this.ListView_Key.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView_Key.FullRowSelect = true;
		this.ListView_Key.GridLines = true;
		this.ListView_Key.Location = new System.Drawing.Point(3, 3);
		this.ListView_Key.MultiSelect = false;
		this.ListView_Key.Name = "ListView_Key";
		this.ListView_Key.Size = new System.Drawing.Size(805, 366);
		this.ListView_Key.TabIndex = 0;
		this.ListView_Key.UseCompatibleStateImageBehavior = false;
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.添加ToolStripMenuItem, this.修改ToolStripMenuItem, this.删除ToolStripMenuItem });
		this.ContextMenuStrip1.Name = "ContextMenuStrip1";
		this.ContextMenuStrip1.Size = new System.Drawing.Size(101, 70);
		this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
		this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.添加ToolStripMenuItem.Text = "添加";
		this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
		this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.修改ToolStripMenuItem.Text = "修改";
		this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
		this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.删除ToolStripMenuItem.Text = "删除";
		this.TableLayoutPanel1.ColumnCount = 3;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154f));
		this.TableLayoutPanel1.Controls.Add(this.Button3, 1, 1);
		this.TableLayoutPanel1.Controls.Add(this.Button_SaveUI, 2, 1);
		this.TableLayoutPanel1.Controls.Add(this.TabControl1, 0, 0);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 2;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(825, 462);
		this.TableLayoutPanel1.TabIndex = 3;
		this.Button3.Location = new System.Drawing.Point(522, 407);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(142, 52);
		this.Button3.TabIndex = 4;
		this.Button3.Text = "加载配置";
		this.Button3.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(825, 462);
		base.Controls.Add(this.TableLayoutPanel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimumSize = new System.Drawing.Size(841, 501);
		base.Name = "Frm_MadeUI";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "UI生成器";
		this.TableLayoutPanel_UI.ResumeLayout(false);
		this.TableLayoutPanel_UI.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox_UI_Error.ResumeLayout(false);
		this.GroupBox_UI_Error.PerformLayout();
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Logo).EndInit();
		this.TabPage2.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.ContextMenuStrip1.ResumeLayout(false);
		this.TableLayoutPanel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual OpenFileDialog vmethod_0()
	{
		return openFileDialog_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_1(OpenFileDialog WithEventsValue)
	{
		openFileDialog_0 = WithEventsValue;
	}

	public void LoadInfo(string _file)
	{
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		ListView_Key.Items.Clear();
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(_file));
			TextBox_ScriptName.Text = (string)val["ScriptInfo"][(object)"Name"];
			TextBox_Developer.Text = (string)val["ScriptInfo"][(object)"Developer"];
			TextBox_BuyLink.Text = (string)val["ScriptInfo"][(object)"BuyLink"];
			TextBox_Instructions.Text = (string)val["ScriptInfo"][(object)"Instructions"];
			if (val["ScriptInfo"][(object)"Logo"] != null)
			{
				byte[] array = Convert.FromBase64String((string)val["ScriptInfo"][(object)"Logo"]);
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(array, 0, array.Length);
				PictureBox_Logo.Image = Image.FromStream(memoryStream);
			}
			if (val["KeyList"] != null)
			{
				foreach (JProperty item in val["KeyList"].Children())
				{
					JProperty val2 = item;
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = val2.Name;
					listViewItem.SubItems.Add((string)val2.Value);
					ListView_Key.Items.Add(listViewItem);
				}
			}
			TextBox_UI.Text = val["UI"].ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "加载出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void method_0()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected O, but got Unknown
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Expected O, but got Unknown
		_Closure_0024__133_002D0 arg = default(_Closure_0024__133_002D0);
		_Closure_0024__133_002D0 CS_0024_003C_003E8__locals23 = new _Closure_0024__133_002D0(arg);
		Panel1.Controls.Clear();
		Panel1.VerticalScroll.Enabled = true;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel = new TableLayoutPanel();
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.Parent = Panel1;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.VerticalScroll.Enabled = true;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.AutoSize = true;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.ColumnCount = 2;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.RowCount = 1;
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.ColumnStyles.Add(new ColumnStyle((SizeType)200));
		CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.ColumnStyles.Add(new ColumnStyle((SizeType)200));
		JArray val;
		try
		{
			val = JArray.Parse(TextBox_UI.Text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			TextBox1.Text = ex2.Message;
			ProjectData.ClearProjectError();
			return;
		}
		checked
		{
			foreach (JObject item in ((JContainer)val).Children())
			{
				JObject val2 = item;
				JToken val3 = val2["type"];
				if ((string)val3 == "Label")
				{
					Label label = new Label();
					label.Text = val2["caption"].ToString();
					label.Dock = DockStyle.Fill;
					label.AutoSize = true;
					CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.SetColumnSpan(label, 2);
					label.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
				}
				else if ((string)val3 == "Edit")
				{
					Label label2 = new Label();
					label2.Text = val2["caption"].ToString();
					label2.Dock = DockStyle.Fill;
					label2.AutoSize = false;
					TextBox obj = new TextBox
					{
						Name = val2["caption"].ToString(),
						Text = val2["text"].ToString(),
						Dock = DockStyle.Fill,
						AutoSize = false
					};
					label2.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
					obj.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
				}
				else if ((string)val3 == "ComboBox")
				{
					Label label3 = new Label();
					label3.Text = val2["caption"].ToString();
					label3.Dock = DockStyle.Fill;
					label3.AutoSize = false;
					ComboBox comboBox = new ComboBox();
					comboBox.Name = val2["caption"].ToString();
					comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
					foreach (JValue item2 in val2["item"].Children())
					{
						JValue val4 = item2;
						comboBox.Items.Add(val4.Value.ToString());
					}
					if (comboBox.Items.Count > 0)
					{
						if (val2["select"] != null)
						{
							if (((int)val2["select"] > 0) & ((int)val2["select"] <= comboBox.Items.Count))
							{
								comboBox.SelectedIndex = (int)val2["select"] - 1;
							}
						}
						else
						{
							comboBox.SelectedIndex = 0;
						}
					}
					comboBox.Dock = DockStyle.Fill;
					comboBox.AutoSize = false;
					label3.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
					comboBox.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
				}
				else if ((string)val3 == "RadioGroup")
				{
					Label label4 = new Label();
					label4.Text = val2["caption"].ToString();
					label4.Dock = DockStyle.Fill;
					label4.AutoSize = false;
					ListBox listBox = new ListBox();
					listBox.Name = val2["caption"].ToString();
					foreach (JValue item3 in val2["item"].Children())
					{
						JValue val5 = item3;
						listBox.Items.Add(val5.Value.ToString());
					}
					if (listBox.Items.Count > 0)
					{
						if (val2["select"] != null)
						{
							if (((int)val2["select"] > 0) & ((int)val2["select"] <= listBox.Items.Count))
							{
								listBox.SelectedIndex = (int)val2["select"] - 1;
							}
						}
						else
						{
							listBox.SelectedIndex = 0;
						}
					}
					listBox.Dock = DockStyle.Fill;
					listBox.AutoSize = false;
					label4.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
					listBox.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
				}
				else if ((string)val3 == "CheckBoxGroup")
				{
					Label label5 = new Label();
					label5.Text = val2["caption"].ToString();
					label5.Dock = DockStyle.Fill;
					label5.AutoSize = false;
					CheckedListBox checkedListBox = new CheckedListBox();
					checkedListBox.Name = val2["caption"].ToString();
					foreach (JValue item4 in val2["item"].Children())
					{
						JValue val6 = item4;
						checkedListBox.Items.Add(val6.Value.ToString());
					}
					if (val2["select"] != null)
					{
						foreach (JValue item5 in val2["select"].Children())
						{
							JValue val7 = item5;
							if ((Conversions.ToInteger(val7.Value) > 0) & (Conversions.ToInteger(val7.Value) <= checkedListBox.Items.Count))
							{
								checkedListBox.SetItemChecked(Conversions.ToInteger(Operators.SubtractObject(val7.Value, 1)), value: true);
							}
						}
					}
					checkedListBox.Dock = DockStyle.Fill;
					checkedListBox.AutoSize = false;
					label5.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
					checkedListBox.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
				}
				CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.RowCount = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.RowCount + 1;
			}
			Button button = new Button();
			CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel.SetColumnSpan(button, 2);
			button.Height = 40;
			button.Text = "提交";
			button.Dock = DockStyle.Fill;
			TextBox1.Text = "";
			button.Click += [SpecialName] (object sender, EventArgs e) =>
			{
				CS_0024_003C_003E8__locals23._Lambda_0024__0();
			};
			button.Parent = CS_0024_003C_003E8__locals23._0024VB_0024Local_cfg_Panel;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		checked
		{
			try
			{
				JArray val = JArray.Parse(TextBox_UI.Text);
				JObject val2 = new JObject();
				foreach (ListViewItem item in ListView_Key.Items)
				{
					val2[item.Text] = JToken.op_Implicit(item.SubItems[1].Text);
				}
				JObject val3 = new JObject(new object[3]
				{
					(object)new JProperty("ScriptInfo", (object)new JObject(new object[4]
					{
						(object)new JProperty("Name", (object)TextBox_ScriptName.Text),
						(object)new JProperty("Developer", (object)TextBox_Developer.Text),
						(object)new JProperty("BuyLink", (object)TextBox_BuyLink.Text),
						(object)new JProperty("Instructions", (object)TextBox_Instructions.Text)
					})),
					(object)new JProperty("UI", (object)val),
					(object)new JProperty("KeyList", (object)val2)
				});
				Image image = PictureBox_Logo.Image;
				if (image != null)
				{
					try
					{
						Bitmap bitmap = new Bitmap(image);
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Jpeg);
						byte[] array = new byte[(int)(memoryStream.Length - 1L) + 1];
						memoryStream.Position = 0L;
						memoryStream.Read(array, 0, (int)memoryStream.Length);
						memoryStream.Close();
						string text = Convert.ToBase64String(array);
						val3["ScriptInfo"][(object)"Logo"] = JToken.op_Implicit(text);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						MessageBox.Show(ex2.Message, "Logo 转换失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ProjectData.ClearProjectError();
					}
				}
				OpenFileDialog openFileDialog = vmethod_0();
				openFileDialog.Title = "选择脚本文件(此操作不会修改脚本)";
				openFileDialog.FileName = "";
				openFileDialog.Filter = "脚本文件 (*.lua,*.xxt)|*.lua;*.xxt";
				openFileDialog.FilterIndex = 0;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Multiselect = false;
				openFileDialog.ShowDialog();
				if (Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0)
				{
					File.WriteAllText(Path.GetDirectoryName(openFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog.FileName) + ".json", JsonConvert.SerializeObject((object)val3), Encoding.UTF8);
					MessageBox.Show("写入对应脚本相应的位置", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				openFileDialog = null;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "保存出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = vmethod_0();
		openFileDialog.FileName = "";
		openFileDialog.Filter = "图片文件 (*.png,*.jpg,*.jpeg)|*.png;*.jpg;*.jpeg";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			byte[] array = File.ReadAllBytes(vmethod_0().FileName);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, 0, array.Length);
			PictureBox_Logo.Image = Image.FromStream(memoryStream);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		PictureBox_Logo.Image = null;
	}

	private void method_4(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = vmethod_0();
		openFileDialog.FileName = "";
		openFileDialog.Filter = "配置文件 (*.json)|*.json";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			LoadInfo(vmethod_0().FileName);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_6(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://www.xxtouch.com/xxtcc");
	}

	private void Frm_MadeUI_Load(object sender, EventArgs e)
	{
		ListView_Key.View = View.Details;
		ListView_Key.Columns.Add("键名", 300, HorizontalAlignment.Center);
		ListView_Key.Columns.Add("键简介", 600);
	}

	private void method_7(object sender, EventArgs e)
	{
		_Closure_0024__141_002D0 CS_0024_003C_003E8__locals10 = new _Closure_0024__141_002D0();
		CS_0024_003C_003E8__locals10._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f = new Form_Key();
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.Text = "添加新的键";
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.TextBox_Name.BackColor = Color.White;
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.TextBox_Name.ReadOnly = false;
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
		{
			CS_0024_003C_003E8__locals10._Lambda_0024__0();
		};
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.Button_Cancel.Click += [SpecialName] (object obj, EventArgs e2) =>
		{
			CS_0024_003C_003E8__locals10._Lambda_0024__1();
		};
		CS_0024_003C_003E8__locals10._0024VB_0024Local_f.ShowDialog();
	}

	private void method_8(object sender, EventArgs e)
	{
		_Closure_0024__142_002D0 CS_0024_003C_003E8__locals13 = new _Closure_0024__142_002D0();
		if (ListView_Key.SelectedItems.Count != 0)
		{
			CS_0024_003C_003E8__locals13._0024VB_0024Local_selectitem = ListView_Key.SelectedItems[0];
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f = new Form_Key();
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.Text = "修改<" + CS_0024_003C_003E8__locals13._0024VB_0024Local_selectitem.Text + ">键";
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.TextBox_Name.Text = CS_0024_003C_003E8__locals13._0024VB_0024Local_selectitem.Text;
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.TextBox_Instructions.Text = CS_0024_003C_003E8__locals13._0024VB_0024Local_selectitem.SubItems[1].Text;
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.Button_OK.Click += [SpecialName] (object obj, EventArgs e2) =>
			{
				CS_0024_003C_003E8__locals13._Lambda_0024__0();
			};
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.Button_Cancel.Click += [SpecialName] (object obj, EventArgs e2) =>
			{
				CS_0024_003C_003E8__locals13._Lambda_0024__1();
			};
			CS_0024_003C_003E8__locals13._0024VB_0024Local_f.ShowDialog();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (ListView_Key.SelectedItems.Count != 0)
		{
			ListViewItem item = ListView_Key.SelectedItems[0];
			ListView_Key.Items.Remove(item);
		}
	}
}
