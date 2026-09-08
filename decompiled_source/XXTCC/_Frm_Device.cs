using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocket4Net;

namespace XXTCC;

[DesignerGenerated]
public class _Frm_Device : Form
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__120_002D0
	{
		public string _0024VB_0024Local_mess;

		public _Frm_Device _0024VB_0024Me;

		public _Closure_0024__120_002D0()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Me.ToolStripStatusLabel_State.Text = "状态:" + _0024VB_0024Local_mess;
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("ImageList_AppLogo")]
	[CompilerGenerated]
	private ImageList imageList_0;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog")]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox_Screen")]
	private PictureBox _PictureBox_Screen;

	[AccessedThroughProperty("MenuStrip1")]
	[CompilerGenerated]
	private MenuStrip DrqaEeklLF;

	[AccessedThroughProperty("Button_Power")]
	[CompilerGenerated]
	private Button _Button_Power;

	[AccessedThroughProperty("ToolStripMenuItem_Shutdown")]
	[CompilerGenerated]
	private ToolStripMenuItem _ToolStripMenuItem_Shutdown;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem_Restart")]
	private ToolStripMenuItem xfqamhprbo;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem_Cancellation")]
	private ToolStripMenuItem _ToolStripMenuItem_Cancellation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Home")]
	private Button _Button_Home;

	[AccessedThroughProperty("ImageList_File")]
	[CompilerGenerated]
	private ImageList imageList_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer_Clipboard")]
	private System.Windows.Forms.Timer timer_0;

	[AccessedThroughProperty("Button_Paste")]
	[CompilerGenerated]
	private Button _Button_Paste;

	[AccessedThroughProperty("Button_Copy")]
	[CompilerGenerated]
	private Button ymfagaseBj;

	[CompilerGenerated]
	[AccessedThroughProperty("截原图ToolStripMenuItem")]
	private ToolStripMenuItem _截原图ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripComboBox_ScreenOrientation")]
	private ToolStripComboBox _ToolStripComboBox_ScreenOrientation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Connect")]
	private Button _Button_Connect;

	private JObject jobject_0;

	public string sip;

	public string sname;

	private int int_0;

	private Thread thread_0;

	private TcpClient beTawNucVR;

	private NetworkStream networkStream_0;

	private bool bool_0;

	private string string_0;

	private string string_1;

	private string dAmaCtuWpq;

	private int int_1;

	private int int_2;

	private Thread thread_1;

	[field: AccessedThroughProperty("ToolStripContainer_Main")]
	internal virtual ToolStripContainer ToolStripContainer_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("StatusStrip_Main")]
	internal virtual StatusStrip StatusStrip_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_State")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_State
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ContextMenuStrip_Main")]
	internal virtual ContextMenuStrip ContextMenuStrip_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Refresh_AppToolStripMenuItem")]
	internal virtual ToolStripMenuItem Refresh_AppToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ClearApp_ToolStripMenuItem")]
	internal virtual ToolStripMenuItem ClearApp_ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PictureBox PictureBox_Screen
	{
		[CompilerGenerated]
		get
		{
			return _PictureBox_Screen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = method_2;
			MouseEventHandler value3 = method_4;
			MouseEventHandler value4 = method_5;
			KeyEventHandler value5 = method_11;
			KeyEventHandler value6 = method_12;
			PictureBox pictureBox = _PictureBox_Screen;
			if (pictureBox != null)
			{
				pictureBox.MouseDown -= value2;
				pictureBox.MouseUp -= value3;
				pictureBox.MouseMove -= value4;
				pictureBox.KeyDown -= value5;
				pictureBox.KeyUp -= value6;
			}
			_PictureBox_Screen = value;
			pictureBox = _PictureBox_Screen;
			if (pictureBox != null)
			{
				pictureBox.MouseDown += value2;
				pictureBox.MouseUp += value3;
				pictureBox.MouseMove += value4;
				pictureBox.KeyDown += value5;
				pictureBox.KeyUp += value6;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_Device")]
	internal virtual GroupBox GroupBox_Device
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel_Screen")]
	internal virtual TableLayoutPanel TableLayoutPanel_Screen
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual MenuStrip MenuStrip1
	{
		[CompilerGenerated]
		get
		{
			return DrqaEeklLF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DrqaEeklLF = value;
		}
	}

	internal virtual Button Button_Power
	{
		[CompilerGenerated]
		get
		{
			return _Button_Power;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			Button button = _Button_Power;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Power = value;
			button = _Button_Power;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("操作设备ToolStripMenuItem")]
	internal virtual ToolStripMenuItem 操作设备ToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Shutdown
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Shutdown;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Shutdown;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Shutdown = value;
			toolStripMenuItem = _ToolStripMenuItem_Shutdown;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Restart
	{
		[CompilerGenerated]
		get
		{
			return xfqamhprbo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_9;
			ToolStripMenuItem toolStripMenuItem = xfqamhprbo;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			xfqamhprbo = value;
			toolStripMenuItem = xfqamhprbo;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_Cancellation
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem_Cancellation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_10;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem_Cancellation;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem_Cancellation = value;
			toolStripMenuItem = _ToolStripMenuItem_Cancellation;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual Button Button_Home
	{
		[CompilerGenerated]
		get
		{
			return _Button_Home;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_14;
			Button button = _Button_Home;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Home = value;
			button = _Button_Home;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel1")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_Paste
	{
		[CompilerGenerated]
		get
		{
			return _Button_Paste;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_16;
			Button button = _Button_Paste;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Paste = value;
			button = _Button_Paste;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_Copy
	{
		[CompilerGenerated]
		get
		{
			return ymfagaseBj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_15;
			Button button = ymfagaseBj;
			if (button != null)
			{
				button.Click -= value2;
			}
			ymfagaseBj = value;
			button = ymfagaseBj;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem 截原图ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _截原图ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_17;
			ToolStripMenuItem toolStripMenuItem = _截原图ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_截原图ToolStripMenuItem = value;
			toolStripMenuItem = _截原图ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripComboBox ToolStripComboBox_ScreenOrientation
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripComboBox_ScreenOrientation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_18;
			ToolStripComboBox toolStripComboBox = _ToolStripComboBox_ScreenOrientation;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.SelectedIndexChanged -= value2;
			}
			_ToolStripComboBox_ScreenOrientation = value;
			toolStripComboBox = _ToolStripComboBox_ScreenOrientation;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Button Button_Connect
	{
		[CompilerGenerated]
		get
		{
			return _Button_Connect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_19;
			Button button = _Button_Connect;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Connect = value;
			button = _Button_Connect;
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
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC._Frm_Device));
		this.ToolStripContainer_Main = new System.Windows.Forms.ToolStripContainer();
		this.StatusStrip_Main = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel_State = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.TableLayoutPanel_Screen = new System.Windows.Forms.TableLayoutPanel();
		this.GroupBox_Device = new System.Windows.Forms.GroupBox();
		this.Button_Connect = new System.Windows.Forms.Button();
		this.Button_Paste = new System.Windows.Forms.Button();
		this.Button_Copy = new System.Windows.Forms.Button();
		this.Button_Home = new System.Windows.Forms.Button();
		this.Button_Power = new System.Windows.Forms.Button();
		this.PictureBox_Screen = new System.Windows.Forms.PictureBox();
		this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
		this.操作设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Shutdown = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Restart = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Cancellation = new System.Windows.Forms.ToolStripMenuItem();
		this.截原图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripComboBox_ScreenOrientation = new System.Windows.Forms.ToolStripComboBox();
		this.ContextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.Refresh_AppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ClearApp_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.vmethod_1(new System.Windows.Forms.ImageList(this.icontainer_0));
		this.vmethod_4(new System.Windows.Forms.ImageList(this.icontainer_0));
		this.BeFcmyCjJG(new System.Windows.Forms.OpenFileDialog());
		this.vmethod_6(new System.Windows.Forms.Timer(this.icontainer_0));
		this.ToolStripContainer_Main.BottomToolStripPanel.SuspendLayout();
		this.ToolStripContainer_Main.ContentPanel.SuspendLayout();
		this.ToolStripContainer_Main.TopToolStripPanel.SuspendLayout();
		this.ToolStripContainer_Main.SuspendLayout();
		this.StatusStrip_Main.SuspendLayout();
		this.TableLayoutPanel_Screen.SuspendLayout();
		this.GroupBox_Device.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Screen).BeginInit();
		this.MenuStrip1.SuspendLayout();
		this.ContextMenuStrip_Main.SuspendLayout();
		base.SuspendLayout();
		this.ToolStripContainer_Main.BottomToolStripPanel.Controls.Add(this.StatusStrip_Main);
		this.ToolStripContainer_Main.ContentPanel.Controls.Add(this.TableLayoutPanel_Screen);
		this.ToolStripContainer_Main.ContentPanel.Size = new System.Drawing.Size(423, 813);
		this.ToolStripContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ToolStripContainer_Main.Location = new System.Drawing.Point(0, 0);
		this.ToolStripContainer_Main.Name = "ToolStripContainer_Main";
		this.ToolStripContainer_Main.Size = new System.Drawing.Size(423, 864);
		this.ToolStripContainer_Main.TabIndex = 0;
		this.ToolStripContainer_Main.Text = "ToolStripContainer1";
		this.ToolStripContainer_Main.TopToolStripPanel.Controls.Add(this.MenuStrip1);
		this.StatusStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
		this.StatusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripStatusLabel_State, this.ToolStripStatusLabel1 });
		this.StatusStrip_Main.Location = new System.Drawing.Point(0, 0);
		this.StatusStrip_Main.Name = "StatusStrip_Main";
		this.StatusStrip_Main.Size = new System.Drawing.Size(423, 22);
		this.StatusStrip_Main.TabIndex = 0;
		this.ToolStripStatusLabel_State.AutoSize = false;
		this.ToolStripStatusLabel_State.Name = "ToolStripStatusLabel_State";
		this.ToolStripStatusLabel_State.Size = new System.Drawing.Size(180, 17);
		this.ToolStripStatusLabel_State.Text = "状态:未知";
		this.ToolStripStatusLabel_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		this.ToolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
		this.ToolStripStatusLabel1.Text = "右击可模拟Home键";
		this.TableLayoutPanel_Screen.ColumnCount = 1;
		this.TableLayoutPanel_Screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Screen.Controls.Add(this.GroupBox_Device, 0, 1);
		this.TableLayoutPanel_Screen.Controls.Add(this.PictureBox_Screen, 0, 0);
		this.TableLayoutPanel_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Screen.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Screen.Name = "TableLayoutPanel_Screen";
		this.TableLayoutPanel_Screen.RowCount = 2;
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel_Screen.Size = new System.Drawing.Size(423, 813);
		this.TableLayoutPanel_Screen.TabIndex = 0;
		this.GroupBox_Device.Controls.Add(this.Button_Connect);
		this.GroupBox_Device.Controls.Add(this.Button_Paste);
		this.GroupBox_Device.Controls.Add(this.Button_Copy);
		this.GroupBox_Device.Controls.Add(this.Button_Home);
		this.GroupBox_Device.Controls.Add(this.Button_Power);
		this.GroupBox_Device.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Device.Location = new System.Drawing.Point(3, 764);
		this.GroupBox_Device.Name = "GroupBox_Device";
		this.GroupBox_Device.Size = new System.Drawing.Size(417, 46);
		this.GroupBox_Device.TabIndex = 5;
		this.GroupBox_Device.TabStop = false;
		this.Button_Connect.Location = new System.Drawing.Point(15, 17);
		this.Button_Connect.Name = "Button_Connect";
		this.Button_Connect.Size = new System.Drawing.Size(69, 23);
		this.Button_Connect.TabIndex = 7;
		this.Button_Connect.Text = "远程控制";
		this.Button_Connect.UseVisualStyleBackColor = true;
		this.Button_Paste.Location = new System.Drawing.Point(162, 17);
		this.Button_Paste.Name = "Button_Paste";
		this.Button_Paste.Size = new System.Drawing.Size(50, 23);
		this.Button_Paste.TabIndex = 6;
		this.Button_Paste.Text = "黏贴";
		this.Button_Paste.UseVisualStyleBackColor = true;
		this.Button_Copy.Location = new System.Drawing.Point(106, 17);
		this.Button_Copy.Name = "Button_Copy";
		this.Button_Copy.Size = new System.Drawing.Size(50, 23);
		this.Button_Copy.TabIndex = 5;
		this.Button_Copy.Text = "复制";
		this.Button_Copy.UseVisualStyleBackColor = true;
		this.Button_Home.Location = new System.Drawing.Point(286, 17);
		this.Button_Home.Name = "Button_Home";
		this.Button_Home.Size = new System.Drawing.Size(62, 23);
		this.Button_Home.TabIndex = 3;
		this.Button_Home.Text = "Home";
		this.Button_Home.UseVisualStyleBackColor = true;
		this.Button_Power.Location = new System.Drawing.Point(218, 17);
		this.Button_Power.Name = "Button_Power";
		this.Button_Power.Size = new System.Drawing.Size(62, 23);
		this.Button_Power.TabIndex = 2;
		this.Button_Power.Text = "电源键";
		this.Button_Power.UseVisualStyleBackColor = true;
		this.PictureBox_Screen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.PictureBox_Screen.Cursor = System.Windows.Forms.Cursors.Cross;
		this.PictureBox_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox_Screen.Location = new System.Drawing.Point(3, 3);
		this.PictureBox_Screen.Name = "PictureBox_Screen";
		this.PictureBox_Screen.Size = new System.Drawing.Size(417, 755);
		this.PictureBox_Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox_Screen.TabIndex = 4;
		this.PictureBox_Screen.TabStop = false;
		this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.操作设备ToolStripMenuItem, this.截原图ToolStripMenuItem, this.ToolStripComboBox_ScreenOrientation });
		this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
		this.MenuStrip1.Name = "MenuStrip1";
		this.MenuStrip1.Size = new System.Drawing.Size(423, 29);
		this.MenuStrip1.TabIndex = 0;
		this.MenuStrip1.Text = "MenuStrip1";
		this.操作设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.ToolStripMenuItem_Shutdown, this.ToolStripMenuItem_Restart, this.ToolStripMenuItem_Cancellation });
		this.操作设备ToolStripMenuItem.Name = "操作设备ToolStripMenuItem";
		this.操作设备ToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
		this.操作设备ToolStripMenuItem.Text = "操作设备";
		this.ToolStripMenuItem_Shutdown.Name = "ToolStripMenuItem_Shutdown";
		this.ToolStripMenuItem_Shutdown.Size = new System.Drawing.Size(180, 22);
		this.ToolStripMenuItem_Shutdown.Text = "关机";
		this.ToolStripMenuItem_Restart.Name = "ToolStripMenuItem_Restart";
		this.ToolStripMenuItem_Restart.Size = new System.Drawing.Size(180, 22);
		this.ToolStripMenuItem_Restart.Text = "重启";
		this.ToolStripMenuItem_Cancellation.Name = "ToolStripMenuItem_Cancellation";
		this.ToolStripMenuItem_Cancellation.Size = new System.Drawing.Size(180, 22);
		this.ToolStripMenuItem_Cancellation.Text = "注销";
		this.截原图ToolStripMenuItem.Name = "截原图ToolStripMenuItem";
		this.截原图ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
		this.截原图ToolStripMenuItem.Text = "截图";
		this.ToolStripComboBox_ScreenOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ToolStripComboBox_ScreenOrientation.Items.AddRange(new object[4] { "竖屏 home 在下", "横屏 home 在右", "横屏 home 在左", "竖屏 home 在上" });
		this.ToolStripComboBox_ScreenOrientation.Name = "ToolStripComboBox_ScreenOrientation";
		this.ToolStripComboBox_ScreenOrientation.Size = new System.Drawing.Size(121, 25);
		this.ContextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.Refresh_AppToolStripMenuItem, this.ClearApp_ToolStripMenuItem });
		this.ContextMenuStrip_Main.Name = "ContextMenuStrip_Main";
		this.ContextMenuStrip_Main.Size = new System.Drawing.Size(125, 48);
		this.Refresh_AppToolStripMenuItem.Name = "Refresh_AppToolStripMenuItem";
		this.Refresh_AppToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
		this.Refresh_AppToolStripMenuItem.Text = "刷新";
		this.ClearApp_ToolStripMenuItem.Name = "ClearApp_ToolStripMenuItem";
		this.ClearApp_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
		this.ClearApp_ToolStripMenuItem.Text = "清空数据";
		this.vmethod_0().ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		this.vmethod_0().ImageSize = new System.Drawing.Size(64, 64);
		this.vmethod_0().TransparentColor = System.Drawing.Color.Transparent;
		this.vmethod_3().ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList_File.ImageStream");
		this.vmethod_3().TransparentColor = System.Drawing.Color.Transparent;
		this.vmethod_3().Images.SetKeyName(0, "file.png");
		this.vmethod_3().Images.SetKeyName(1, "folder.png");
		this.vmethod_2().FileName = "OpenFileDialog1";
		this.vmethod_5().Enabled = true;
		this.vmethod_5().Interval = 500;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(423, 864);
		base.Controls.Add(this.ToolStripContainer_Main);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		base.MainMenuStrip = this.MenuStrip1;
		this.MinimumSize = new System.Drawing.Size(350, 600);
		base.Name = "_Frm_Device";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "设备详情";
		this.ToolStripContainer_Main.BottomToolStripPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.BottomToolStripPanel.PerformLayout();
		this.ToolStripContainer_Main.ContentPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.TopToolStripPanel.ResumeLayout(false);
		this.ToolStripContainer_Main.TopToolStripPanel.PerformLayout();
		this.ToolStripContainer_Main.ResumeLayout(false);
		this.ToolStripContainer_Main.PerformLayout();
		this.StatusStrip_Main.ResumeLayout(false);
		this.StatusStrip_Main.PerformLayout();
		this.TableLayoutPanel_Screen.ResumeLayout(false);
		this.GroupBox_Device.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.PictureBox_Screen).EndInit();
		this.MenuStrip1.ResumeLayout(false);
		this.MenuStrip1.PerformLayout();
		this.ContextMenuStrip_Main.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ImageList vmethod_0()
	{
		return imageList_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_1(ImageList WithEventsValue)
	{
		imageList_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual OpenFileDialog vmethod_2()
	{
		return openFileDialog_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void BeFcmyCjJG(OpenFileDialog WithEventsValue)
	{
		openFileDialog_0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ImageList vmethod_3()
	{
		return imageList_1;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_4(ImageList WithEventsValue)
	{
		imageList_1 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual System.Windows.Forms.Timer vmethod_5()
	{
		return timer_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_6(System.Windows.Forms.Timer WithEventsValue)
	{
		EventHandler value = method_22;
		System.Windows.Forms.Timer timer = timer_0;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		timer_0 = WithEventsValue;
		timer = timer_0;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	public _Frm_Device(object ip, object name)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += YjdAjydnkg;
		base.Closing += _Frm_Device_Closing;
		jobject_0 = new JObject();
		int_0 = 0;
		beTawNucVR = new TcpClient();
		bool_0 = false;
		string_0 = "";
		string_1 = "if not touch then\r\n\tsys.alert('删除设备上的 `/var/mobile/Media/1ferver/caches/1ferver.key` 重新运行任意脚本更新证书。', 0, '证书需要更新')\r\n\tos.exit()\r\nend\r\nlocal ev = require'ev'\r\nlocal loop = ev.Loop.default\r\nlocal websocket = require'websocket'\r\nlocal server = websocket.server.ev.listen{\r\n\tprotocols = {\r\n\t\t['RC'] = function(ws)\r\n\t\t\tsys.toast('已经建立远程控制连接')\r\n\t\t\tlocal index = 5\r\n\t\t\tev.Timer.new(function()\r\n\t\t\t\tif index <= 0 then\r\n\t\t\t\t\tsys.toast('已断开远程控制链接')\r\n\t\t\t\t\tos.exit()\r\n\t\t\t\tend\r\n\t\t\t\tindex = index - 1\r\n\t\t\t\tws:send(json.encode({mode = 'heart'})\r\n\t\t\t)\r\n\t\t\tend, 1, 1 ):start(loop)\r\n\t\t\tws:on_message(function(ws,message,opcode)\r\n\t\t\t\tif opcode == websocket.TEXT then\r\n\t\t\t\t\tlocal jobj = json.decode(message)\r\n\t\t\t\t\tif jobj then\r\n\t\t\t\t\t\tif jobj.mode == 'down' then\r\n\t\t\t\t\t\t\ttouch.down(28,jobj.x,jobj.y)\r\n\t\t\t\t\t\telseif jobj.mode == 'move' then\r\n\t\t\t\t\t\t\ttouch.move(28,jobj.x,jobj.y)\r\n\t\t\t\t\t\telseif jobj.mode == 'up' then\r\n\t\t\t\t\t\t\ttouch.up(28)\r\n\t\t\t\t\t\telseif jobj.mode == 'clipboard' then\r\n\t\t\t\t\t        sys.toast(jobj.data)\r\n\t\t\t\t\t        _old = jobj.data\r\n\t\t\t\t\t        pasteboard.write(jobj.data)\r\n\t\t\t\t        elseif jobj.mode == 'input_down' then\r\n\t\t\t\t\t        key.down(jobj.key)\r\n\t\t\t\t        elseif jobj.mode == 'input_up' then\r\n\t\t\t\t\t        key.up(jobj.key)\r\n\t\t\t\t\t\telseif jobj.mode == 'home' then\r\n\t\t\t\t\t\t\tkey.press(0x0C, 64)\r\n\t\t\t\t\t\telseif jobj.mode == 'power' then\r\n\t\t\t\t\t\t\tkey.press(0x0C, 48)\r\n\t\t\t\t\t\telseif jobj.mode == 'quit' then\r\n\t\t\t\t\t\t\tsys.toast('已断开远程控制链接')\r\n\t\t\t\t\t\t\tos.exit()\r\n\t\t\t\t\t\telseif jobj.mode == 'heart' then\r\n\t\t\t\t\t\t\tindex = 5\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\tend\r\n\t\t\t\t\tend\r\n\t\t\t\tend\r\n\t\t\tend)\r\n\t\tend\r\n\t},\r\n\tport = 46268\r\n}\r\nloop:loop()\r\n";
		dAmaCtuWpq = "local socket = require('socket')\r\nlocal tcp = socket.bind('*',8080)\r\ntcp:settimeout(0)\r\nlocal client\r\nlocal index = 30\r\nwhile true do\r\n\tclient = tcp:accept()\r\n\tif client then break end\r\nend\r\nlocal Listener = (function()\r\n\tlocal _old = pasteboard.read()\r\n\tlocal Pasteboard = thread.dispatch((function()\r\n\t\twhile true do\r\n\t\t\tif _old ~= pasteboard.read() then\r\n\t\t\t\t_old = pasteboard.read()\r\n\t\t\t\tclient:send(json.encode({['mode']='clipboard',['data']=_old})..'\\n')\r\n\t\t\t\tsys.toast(_old)\r\n\t\t\tend\r\n\t\t\tsys.msleep(0.1)\r\n\t\tend\r\n\tend),nLog)\r\n\twhile true do\r\n\t\tlocal s, status, partial = client:receive('*l')\r\n\t\tif s then\r\n\t\t\tlocal jobj = json.decode(s)\r\n\t\t\tif jobj then\r\n\t\t\t\tif jobj.orient then\r\n\t\t\t\t\tscreen.init(jobj.orient)\r\n\t\t\t\tend\r\n\t\t\t\tif jobj.mode == 'down' then\r\n\t\t\t\t\ttouch.old_down(1,jobj.x,jobj.y)\r\n\t\t\t\telseif jobj.mode == 'move' then\r\n\t\t\t\t\ttouch.old_move(1,jobj.x,jobj.y)\r\n\t\t\t\telseif jobj.mode == 'up' then\r\n\t\t\t\t\ttouch.old_up(1,jobj.x,jobj.y)\r\n\t\t\t\telseif jobj.mode == 'clipboard' then\r\n\t\t\t\t\tsys.toast(jobj.data)\r\n\t\t\t\t\t_old = jobj.data\r\n\t\t\t\t\tpasteboard.write(jobj.data)\r\n\t\t\t\telseif jobj.mode == 'input_down' then\r\n\t\t\t\t\tkey.down(jobj.key)\r\n\t\t\t\telseif jobj.mode == 'input_up' then\r\n\t\t\t\t\tkey.up(jobj.key)\r\n\t\t\t\telseif jobj.mode == 'home' then\r\n\t\t\t\t\tkey.press('homebutton')\r\n\t\t\t\telseif jobj.mode == 'power' then\r\n\t\t\t\t\tkey.press('LOCK')\r\n\t\t\t\telse\r\n\t\t\t\t\t\r\n\t\t\t\tend\r\n\t\t\tend\r\n\t\tend\r\n\t\tif status == 'closed' then\r\n\t\t\tbreak\r\n\t\tend\r\n\t\tsys.msleep(0.1)\r\n\tend\r\n\tthread.kill(Pasteboard)\r\n\tclient:close()\r\nend)\r\nlocal tid = thread.dispatch(Listener)";
		int_1 = 0;
		int_2 = 0;
		InitializeComponent();
		sip = Conversions.ToString(ip);
		sname = Conversions.ToString(name);
		Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("设备详情 [", ip), "] ["), name), "]"));
	}

	private void YjdAjydnkg(object sender, EventArgs e)
	{
		thread_0 = new Thread(_SnapShot);
		thread_0.Start();
		ToolStripComboBox_ScreenOrientation.SelectedIndex = 0;
	}

	private void method_0(string string_2)
	{
		_Closure_0024__120_002D0 CS_0024_003C_003E8__locals4 = new _Closure_0024__120_002D0();
		CS_0024_003C_003E8__locals4._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals4._0024VB_0024Local_mess = string_2;
		if (bool_0)
		{
			return;
		}
		try
		{
			Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals4._0024VB_0024Me.ToolStripStatusLabel_State.Text = "状态:" + CS_0024_003C_003E8__locals4._0024VB_0024Local_mess;
			}));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private Image method_1(string string_2)
	{
		Image result;
		try
		{
			byte[] buffer = Convert.FromBase64String(string_2);
			MemoryStream memoryStream = new MemoryStream(buffer);
			Bitmap bitmap = new Bitmap(memoryStream);
			memoryStream.Close();
			result = bitmap;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Base64StringToImage 转换失败\nException：" + ex2.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void _SnapShot()
	{
		do
		{
			Image image = Snapshot(sip, int_0);
			try
			{
				if (image != null)
				{
					PictureBox_Screen.Image = image;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		while (!bool_0);
	}

	public Bitmap Snapshot(string IP, int Orient)
	{
		Bitmap result;
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("http://" + IP + ":46952/snapshot?ext=jpg&compress=0.5&orient=0");
			obj.Timeout = 500;
			obj.Method = "GET";
			obj.ContentType = "application/x-www-form-urlencoded";
			obj.UserAgent = "Tao";
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
			WebResponse response = obj.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Bitmap bitmap = new Bitmap(responseStream);
			responseStream.Close();
			response.Close();
			switch (int_0)
			{
			case 1:
				bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
				break;
			case 2:
				bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
				break;
			case 3:
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
				break;
			}
			result = bitmap;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_2(object sender, MouseEventArgs e)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		PictureBox_Screen.Focus();
		if (PictureBox_Screen.Image == null)
		{
			return;
		}
		if (e.Button == MouseButtons.Right)
		{
			method_7(new JObject((object)new JProperty("mode", (object)"home")));
			return;
		}
		checked
		{
			try
			{
				_ = PictureBox_Screen.Image.Width;
				int num = PictureBox_Screen.Image.Height;
				Rectangle rectangle = (Rectangle)PictureBox_Screen.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(PictureBox_Screen, null);
				int num2 = rectangle.Width;
				int num3 = rectangle.Height;
				double num4 = (double)num3 / (double)num;
				int num5 = (int)Math.Round((num2 == PictureBox_Screen.Width) ? 0.0 : ((double)(PictureBox_Screen.Width - num2) / 2.0));
				int num6 = (int)Math.Round((num3 == PictureBox_Screen.Height) ? 0.0 : ((double)(PictureBox_Screen.Height - num3) / 2.0));
				int num7 = e.X - num5;
				int num8 = e.Y - num6;
				double a = (double)num7 / num4;
				double a2 = (double)num8 / num4;
				int_1 = (int)Math.Round(a);
				int_2 = (int)Math.Round(a2);
				method_7(new JObject(new object[4]
				{
					(object)new JProperty("mode", (object)"down"),
					(object)new JProperty("orient", (object)int_0),
					(object)new JProperty("x", (object)int_1),
					(object)new JProperty("y", (object)int_2)
				}));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		if (PictureBox_Screen.Image != null)
		{
			method_7(new JObject((object)new JProperty("mode", (object)"power")));
		}
	}

	private void method_4(object sender, MouseEventArgs e)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		checked
		{
			if (PictureBox_Screen.Image != null && e.Button == MouseButtons.Left)
			{
				try
				{
					_ = PictureBox_Screen.Image.Width;
					int num = PictureBox_Screen.Image.Height;
					Rectangle rectangle = (Rectangle)PictureBox_Screen.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(PictureBox_Screen, null);
					int num2 = rectangle.Width;
					int num3 = rectangle.Height;
					double num4 = (double)num3 / (double)num;
					int num5 = (int)Math.Round((num2 == PictureBox_Screen.Width) ? 0.0 : ((double)(PictureBox_Screen.Width - num2) / 2.0));
					int num6 = (int)Math.Round((num3 == PictureBox_Screen.Height) ? 0.0 : ((double)(PictureBox_Screen.Height - num3) / 2.0));
					int num7 = e.X - num5;
					int num8 = e.Y - num6;
					double a = (double)num7 / num4;
					double a2 = (double)num8 / num4;
					method_7(new JObject(new object[4]
					{
						(object)new JProperty("mode", (object)"up"),
						(object)new JProperty("orient", (object)int_0),
						(object)new JProperty("x", (object)(int)Math.Round(a)),
						(object)new JProperty("y", (object)(int)Math.Round(a2))
					}));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	private void method_5(object sender, MouseEventArgs e)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		if (e.Button != MouseButtons.Left || PictureBox_Screen.Image == null)
		{
			return;
		}
		checked
		{
			try
			{
				_ = PictureBox_Screen.Image.Width;
				int num = PictureBox_Screen.Image.Height;
				Rectangle rectangle = (Rectangle)PictureBox_Screen.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(PictureBox_Screen, null);
				int num2 = rectangle.Width;
				int num3 = rectangle.Height;
				double num4 = (double)num3 / (double)num;
				int num5 = (int)Math.Round((num2 == PictureBox_Screen.Width) ? 0.0 : ((double)(PictureBox_Screen.Width - num2) / 2.0));
				int num6 = (int)Math.Round((num3 == PictureBox_Screen.Height) ? 0.0 : ((double)(PictureBox_Screen.Height - num3) / 2.0));
				int num7 = e.X - num5;
				int num8 = e.Y - num6;
				double a = (double)num7 / num4;
				double a2 = (double)num8 / num4;
				if ((Math.Abs((int)Math.Round(a) - int_1) > 5) | (Math.Abs((int)Math.Round(a2) - int_2) > 5))
				{
					int_1 = (int)Math.Round(a);
					int_2 = (int)Math.Round(a2);
					method_7(new JObject(new object[4]
					{
						(object)new JProperty("mode", (object)"move"),
						(object)new JProperty("orient", (object)int_0),
						(object)new JProperty("x", (object)int_1),
						(object)new JProperty("y", (object)int_2)
					}));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_6(object sender, MessageReceivedEventArgs e)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		try
		{
			JObject val = JObject.Parse(e.Message);
			JToken val2 = val["mode"];
			if ((string)val2 == "clipboard")
			{
				string_0 = (string)val["data"];
				Clipboard.SetText(string_0);
			}
			else if ((string)val2 == "heart")
			{
				method_7(new JObject((object)new JProperty("mode", (object)"heart")));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(JObject jobject_1)
	{
		try
		{
			if (beTawNucVR.Connected)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)jobject_1) + "\r\n");
				networkStream_0.Write(bytes, 0, bytes.Length);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (beTawNucVR.Connected)
			{
				beTawNucVR.Close();
			}
			Button_Connect.Text = "远程控制";
			ProjectData.ClearProjectError();
		}
	}

	private void _Frm_Device_Closing(object sender, CancelEventArgs e)
	{
		try
		{
			if (beTawNucVR.Connected)
			{
				beTawNucVR.Close();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		bool_0 = true;
	}

	private void method_8(object sender, EventArgs e)
	{
		string text = Class8.smethod_33("http://" + sip + ":46952/halt", "");
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(text);
			if ((int)val["code"] == 0)
			{
				method_0("重启成功");
			}
			else
			{
				method_0((string)val["message"]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			method_0(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		string text = Class8.smethod_33("http://" + sip + ":46952/reboot2", "");
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(text);
			if ((int)val["code"] == 0)
			{
				method_0("重启成功");
			}
			else
			{
				method_0((string)val["message"]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			method_0(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		string text = Class8.smethod_33("http://" + sip + ":46952/respring", "");
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(text);
			if ((int)val["code"] == 0)
			{
				method_0("重启成功");
			}
			else
			{
				method_0((string)val["message"]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			method_0(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(object sender, KeyEventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		PictureBox_Screen.Focus();
		if (PictureBox_Screen.Image != null)
		{
			method_7(new JObject(new object[2]
			{
				(object)new JProperty("mode", (object)"input_down"),
				(object)new JProperty("key", (object)method_13(e.KeyCode))
			}));
		}
	}

	private void method_12(object sender, KeyEventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		PictureBox_Screen.Focus();
		if (PictureBox_Screen.Image != null)
		{
			method_7(new JObject(new object[2]
			{
				(object)new JProperty("mode", (object)"input_up"),
				(object)new JProperty("key", (object)method_13(e.KeyCode))
			}));
		}
	}

	public string method_13(Keys KeyxCode)
	{
		switch (KeyxCode)
		{
		case Keys.OemSemicolon:
			return "SEMICOLON";
		case Keys.Oemplus:
			return "EQUAL";
		case Keys.Oemcomma:
			return "COMMA";
		case Keys.OemMinus:
			return "HYPHEN";
		case Keys.OemQuestion:
			return "SLASH";
		case Keys.Oemtilde:
			return "ACCENT";
		case Keys.Back:
			return "BACKSPACE";
		case Keys.Tab:
			return "TAB";
		case Keys.Return:
			return "RETURN";
		case Keys.ShiftKey:
			return "RIGHTSHIFT";
		case Keys.ControlKey:
			return "RIGHTCONTROL";
		case Keys.Menu:
			return "RIGHTALT";
		case Keys.Pause:
			return "PAUSE";
		case Keys.Capital:
			return "CAPSLOCK";
		case Keys.Escape:
			return "ESCAPE";
		case Keys.Space:
			return "SPACE";
		case Keys.Prior:
			return "PAGEUP";
		case Keys.Next:
			return "PAGEDOWN";
		case Keys.End:
			return "END";
		case Keys.Home:
			return "HOME";
		case Keys.Left:
			return "LEFTARROW";
		case Keys.Up:
			return "UPARROW";
		case Keys.Right:
			return "RIGHTARROW";
		case Keys.Down:
			return "DOWNARROW";
		case Keys.Insert:
			return "INSERT";
		case Keys.Delete:
			return "DELETE";
		case Keys.A:
			return "A";
		case Keys.B:
			return "B";
		case Keys.C:
			return "C";
		case Keys.D:
			return "D";
		case Keys.E:
			return "E";
		case Keys.F:
			return "F";
		case Keys.G:
			return "G";
		case Keys.H:
			return "H";
		case Keys.I:
			return "I";
		case Keys.J:
			return "J";
		case Keys.K:
			return "K";
		case Keys.L:
			return "L";
		case Keys.M:
			return "M";
		case Keys.N:
			return "N";
		case Keys.O:
			return "O";
		case Keys.P:
			return "P";
		case Keys.Q:
			return "Q";
		case Keys.R:
			return "R";
		case Keys.S:
			return "S";
		case Keys.T:
			return "T";
		case Keys.U:
			return "U";
		case Keys.V:
			return "V";
		case Keys.W:
			return "W";
		case Keys.X:
			return "X";
		case Keys.Y:
			return "Y";
		case Keys.Z:
			return "Z";
		case Keys.LWin:
			return "LEFTCOMMAND";
		case Keys.RWin:
			return "RIGHTCOMMAND";
		case Keys.D0:
		case Keys.NumPad0:
			return "0";
		case Keys.D1:
		case Keys.NumPad1:
			return "1";
		case Keys.D2:
		case Keys.NumPad2:
			return "2";
		case Keys.D3:
		case Keys.NumPad3:
			return "3";
		case Keys.D4:
		case Keys.NumPad4:
			return "4";
		case Keys.D5:
		case Keys.NumPad5:
			return "5";
		case Keys.D6:
		case Keys.NumPad6:
			return "6";
		case Keys.D7:
		case Keys.NumPad7:
			return "7";
		case Keys.D8:
		case Keys.NumPad8:
			return "8";
		case Keys.D9:
		case Keys.NumPad9:
			return "9";
		case Keys.F1:
			return "F1";
		case Keys.F2:
			return "F2";
		case Keys.F3:
			return "F3";
		case Keys.F4:
			return "F4";
		case Keys.F5:
			return "F5";
		case Keys.F6:
			return "F6";
		case Keys.F7:
			return "F7";
		case Keys.F8:
			return "F8";
		case Keys.F9:
			return "F9";
		case Keys.F10:
			return "F10";
		case Keys.F11:
			return "F11";
		case Keys.F12:
			return "F12";
		default:
			return "";
		case Keys.OemBackslash:
			return "BACKSLASH";
		case Keys.OemQuotes:
			return "QUOTATION";
		}
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (Operators.CompareString(method_13(keyData), "", TextCompare: false) != 0)
		{
			return false;
		}
		if (keyData == Keys.Tab)
		{
			return false;
		}
		return base.ProcessDialogKey(keyData);
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		if (PictureBox_Screen.Image != null)
		{
			method_7(new JObject((object)new JProperty("mode", (object)"home")));
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_down"),
			(object)new JProperty("key", (object)"LEFTCOMMAND")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_down"),
			(object)new JProperty("key", (object)"C")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_up"),
			(object)new JProperty("key", (object)"C")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_up"),
			(object)new JProperty("key", (object)"LEFTCOMMAND")
		}));
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_down"),
			(object)new JProperty("key", (object)"LEFTCOMMAND")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_down"),
			(object)new JProperty("key", (object)"V")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_up"),
			(object)new JProperty("key", (object)"V")
		}));
		method_7(new JObject(new object[2]
		{
			(object)new JProperty("mode", (object)"input_up"),
			(object)new JProperty("key", (object)"LEFTCOMMAND")
		}));
	}

	private void method_17(object sender, EventArgs e)
	{
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("http://" + sip + ":46952/snapshot");
			obj.Timeout = 500;
			obj.Method = "GET";
			obj.ContentType = "application/x-www-form-urlencoded";
			obj.UserAgent = "Tao";
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
			WebResponse response = obj.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Bitmap bitmap = new Bitmap(responseStream);
			responseStream.Close();
			response.Close();
			if (!Directory.Exists(Application.StartupPath + "\\screenshots"))
			{
				Directory.CreateDirectory(Application.StartupPath + "\\screenshots");
			}
			bitmap.Save(Application.StartupPath + "\\screenshots\\" + sname + "_" + sip + "_" + Strings.Format(DateAndTime.Now, "yyyy.MM.dd HH.mm.ss ffff") + ".png", ImageFormat.Png);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			method_0(ex2.Message.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		int_0 = ToolStripComboBox_ScreenOrientation.SelectedIndex;
	}

	private void method_19(object sender, EventArgs e)
	{
		if (!beTawNucVR.Connected)
		{
			if (Interaction.MsgBox("你正在试图反向控制设备，反向控制功能需要终止正在运行的脚本方能使用，而且可能会引发各类异常，确定要开始反向控制么？", MsgBoxStyle.Exclamation | MsgBoxStyle.OkCancel, "警告") == MsgBoxResult.Cancel)
			{
				return;
			}
			string text = Class8.smethod_33("http://" + sip + ":46952/spawn", dAmaCtuWpq);
			if (Operators.CompareString(text, "", TextCompare: false) == 0)
			{
				return;
			}
			try
			{
				JObject val = JObject.Parse(text);
				if ((int)val["code"] == 0)
				{
					method_0("连接成功");
					beTawNucVR = new TcpClient(sip, 8080);
					thread_1 = new Thread(method_20);
					thread_1.SetApartmentState(ApartmentState.STA);
					thread_1.Start();
					networkStream_0 = beTawNucVR.GetStream();
					beTawNucVR.SendTimeout = 0;
					beTawNucVR.ReceiveTimeout = 0;
					Button_Connect.Text = "关闭";
				}
				else
				{
					method_0((string)val["message"]);
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				method_0(ex2.Message);
				ProjectData.ClearProjectError();
				return;
			}
		}
		beTawNucVR.Close();
		Button_Connect.Text = "远程控制";
	}

	private void method_20()
	{
		try
		{
			while (beTawNucVR.Connected)
			{
				byte[] array = new byte[512];
				networkStream_0.Read(array, 0, array.Length);
				string text = Encoding.UTF8.GetString(array);
				try
				{
					JObject val = JObject.Parse(text);
					if ((string)val["mode"] == "clipboard")
					{
						string_0 = (string)val["data"];
						if (string_0 != null)
						{
							Clipboard.SetText((string)val["data"]);
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(JObject jobject_1)
	{
		try
		{
			if (beTawNucVR.Connected)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)jobject_1) + "\r\n");
				networkStream_0.Write(bytes, 0, bytes.Length);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (beTawNucVR.Connected)
			{
				beTawNucVR.Close();
			}
			Button_Connect.Text = "远程控制";
			ProjectData.ClearProjectError();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		try
		{
			if (Clipboard.ContainsText() && Operators.CompareString(Clipboard.GetText(), string_0, TextCompare: false) != 0)
			{
				string_0 = Clipboard.GetText();
				method_7(new JObject(new object[2]
				{
					(object)new JProperty("mode", (object)"clipboard"),
					(object)new JProperty("data", (object)string_0)
				}));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
