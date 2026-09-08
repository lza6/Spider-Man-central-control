using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using XXTCC.Utility;

namespace XXTCC;

[DesignerGenerated]
public class Frm_SSH : Form
{
	private delegate void Delegate1(string IP, string Message, int OSV);

	private delegate void Delegate2(string ip);

	[CompilerGenerated]
	internal sealed class _Closure_0024__145_002D0
	{
		public ToolStripProgressBar _0024VB_0024Local_prog;

		public string _0024VB_0024Local_filename;

		public ToolStripStatusLabel _0024VB_0024Local_label1;

		public float _0024VB_0024Local_percent;

		public Frm_SSH _0024VB_0024Me;

		public VB_0024AnonymousDelegate_0 _0024I3;

		public _Closure_0024__145_002D0(_Closure_0024__145_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_prog = arg0._0024VB_0024Local_prog;
				_0024VB_0024Local_filename = arg0._0024VB_0024Local_filename;
				_0024VB_0024Local_label1 = arg0._0024VB_0024Local_label1;
				_0024VB_0024Local_percent = arg0._0024VB_0024Local_percent;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.ToolStripStatusLabel_FileName.Text = Path.GetFileName(_0024VB_0024Local_filename);
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Local_label1.Text = "下载进度：" + _0024VB_0024Local_percent + "%";
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			_0024VB_0024Local_prog.Value = _0024VB_0024Local_prog.Maximum;
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			_0024VB_0024Local_label1.Text = "下载进度：100%";
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__145_002D1
	{
		public long _0024VB_0024Local_totalBytes;

		public long _0024VB_0024Local_totalDownloadedByte;

		public _Closure_0024__145_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__145_002D1(_Closure_0024__145_002D1 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_totalBytes = arg0._0024VB_0024Local_totalBytes;
				_0024VB_0024Local_totalDownloadedByte = arg0._0024VB_0024Local_totalDownloadedByte;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_prog.Maximum = checked((int)_0024VB_0024Local_totalBytes);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_prog.Value = checked((int)_0024VB_0024Local_totalDownloadedByte);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__163_002D0
	{
		public bool _0024VB_0024Local_deb_download;

		public Frm_SSH _0024VB_0024Me;

		public _Closure_0024__163_002D0(_Closure_0024__163_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_deb_download = arg0._0024VB_0024Local_deb_download;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			List<string> list = new List<string>();
			DataRow[] array = _0024VB_0024Me._DeviceList.Select("check=True");
			foreach (DataRow dataRow in array)
			{
				if (_0024VB_0024Me.Test_Get_OSV(Conversions.ToString(dataRow["ip"])))
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLessEqual(dataRow["OSVersion"], 11, TextCompare: false), Operators.CompareObjectGreaterEqual(dataRow["OSVersion"], 6, TextCompare: false))))
					{
						list.Add(dataRow["ip"].ToString());
						_0024VB_0024Local_deb_download = true;
					}
					else if (!Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 0, TextCompare: false))
					{
						_0024VB_0024Me.AddList(Conversions.ToString(dataRow["ip"]), "不支持当前系统");
					}
				}
			}
			if (list.Count == 0)
			{
				MessageBox.Show("请先扫描并勾选至少一台设备", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			int count = list.Count;
			checked
			{
				for (int j = 1; j <= count; j++)
				{
					ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
					{
						_0024VB_0024Me.Install_Other(Conversions.ToString(a0));
					}, list[j - 1]);
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__164_002D0
	{
		public bool _0024VB_0024Local_deb_download;

		public bool _0024VB_0024Local_shift_b;

		public Frm_SSH _0024VB_0024Me;

		public _Closure_0024__164_002D0(_Closure_0024__164_002D0 arg0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			if (arg0 != null)
			{
				_0024VB_0024Local_deb_download = arg0._0024VB_0024Local_deb_download;
				_0024VB_0024Local_shift_b = arg0._0024VB_0024Local_shift_b;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			bool flag = Operators.CompareString(_0024VB_0024Me.PostCode("https://www.baidu.com", ""), "", TextCompare: false) != 0;
			List<string> list = new List<string>();
			DataRow[] array = _0024VB_0024Me._DeviceList.Select("check=True");
			foreach (DataRow dataRow in array)
			{
				if (_0024VB_0024Me.Test_Get_OSV(Conversions.ToString(dataRow["ip"])))
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLessEqual(dataRow["OSVersion"], 11, TextCompare: false), Operators.CompareObjectGreaterEqual(dataRow["OSVersion"], 6, TextCompare: false))))
					{
						list.Add(dataRow["ip"].ToString());
						_0024VB_0024Local_deb_download = true;
					}
					else if (!Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 0, TextCompare: false))
					{
						_0024VB_0024Me.AddList(Conversions.ToString(dataRow["ip"]), "不支持当前系统");
					}
				}
			}
			if (list.Count == 0)
			{
				MessageBox.Show("请先扫描并勾选至少一台设备", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			checked
			{
				if (_0024VB_0024Local_shift_b)
				{
					int count = list.Count;
					for (int j = 1; j <= count; j++)
					{
						ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
						{
							_0024VB_0024Me.Install_Other(Conversions.ToString(a0));
						}, list[j - 1]);
					}
					return;
				}
				if (flag & _0024VB_0024Local_deb_download)
				{
					Frm_SSH frm_SSH = _0024VB_0024Me;
					string package = "xxtouch";
					if (!frm_SSH.Get_Lastst(ref package, ref _0024VB_0024Me.string_0))
					{
						return;
					}
				}
				int count2 = list.Count;
				for (int num = 1; num <= count2; num++)
				{
					ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
					{
						_0024VB_0024Me.Install_XXTouch(Conversions.ToString(a0));
					}, list[num - 1]);
				}
			}
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("_OpenFileDialog")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("ContextMenuStrip_DeviceList")]
	[CompilerGenerated]
	private ContextMenuStrip contextMenuStrip_0;

	[AccessedThroughProperty("DataGridView_DeviceList")]
	[CompilerGenerated]
	private DataGridView _DataGridView_DeviceList;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label nJmErwjDel;

	[AccessedThroughProperty("ListBox_ip_list")]
	[CompilerGenerated]
	private ListBox _ListBox_ip_list;

	[AccessedThroughProperty("Button_TCP_Search")]
	[CompilerGenerated]
	private Button _Button_TCP_Search;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_InstallXXTouch")]
	private Button _Button_InstallXXTouch;

	[AccessedThroughProperty("Button_Reboot")]
	[CompilerGenerated]
	private Button _Button_Reboot;

	[AccessedThroughProperty("Button_Cancellation")]
	[CompilerGenerated]
	private Button _Button_Cancellation;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox ihcEhlxpsB;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Install_deb")]
	private Button _Button_Install_deb;

	public DataTable _DeviceList;

	private string string_0;

	private int int_0;

	private string string_1;

	private object object_0;

	private object qjuEePytKH;

	private string string_2;

	private bool bool_0;

	[field: AccessedThroughProperty("ToolStripMenuItem_Check_Select")]
	internal virtual ToolStripMenuItem ToolStripMenuItem_Check_Select
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem_UnCheck_Select")]
	internal virtual ToolStripMenuItem ToolStripMenuItem_UnCheck_Select
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem_NotCheck_Select")]
	internal virtual ToolStripMenuItem ToolStripMenuItem_NotCheck_Select
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem_Check_All")]
	internal virtual ToolStripMenuItem ToolStripMenuItem_Check_All
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel1")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripProgressBar1")]
	internal virtual ToolStripProgressBar ToolStripProgressBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel_FileName")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel_FileName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("StatusStrip1")]
	internal virtual StatusStrip StatusStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripStatusLabel2")]
	internal virtual ToolStripStatusLabel ToolStripStatusLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripContainer1")]
	internal virtual ToolStripContainer ToolStripContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SplitContainer_Main")]
	internal virtual SplitContainer SplitContainer_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridView DataGridView_DeviceList
	{
		[CompilerGenerated]
		get
		{
			return _DataGridView_DeviceList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = method_10;
			EventHandler value3 = method_11;
			DataGridViewCellEventHandler value4 = method_12;
			DataGridView dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick -= value2;
				dataGridView.CurrentCellDirtyStateChanged -= value3;
				dataGridView.CellClick -= value4;
			}
			_DataGridView_DeviceList = value;
			dataGridView = _DataGridView_DeviceList;
			if (dataGridView != null)
			{
				dataGridView.ColumnHeaderMouseClick += value2;
				dataGridView.CurrentCellDirtyStateChanged += value3;
				dataGridView.CellClick += value4;
			}
		}
	}

	[field: AccessedThroughProperty("ContextMenuStrip1")]
	internal virtual ContextMenuStrip ContextMenuStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem1")]
	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem2")]
	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem3")]
	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem4")]
	internal virtual ToolStripMenuItem ToolStripMenuItem4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel_Main")]
	internal virtual TableLayoutPanel TableLayoutPanel_Main
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

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return nJmErwjDel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nJmErwjDel = value;
		}
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
			EventHandler value2 = method_2;
			ListBox listBox = _ListBox_ip_list;
			if (listBox != null)
			{
				listBox.SelectedValueChanged -= value2;
			}
			_ListBox_ip_list = value;
			listBox = _ListBox_ip_list;
			if (listBox != null)
			{
				listBox.SelectedValueChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_HeaderIP")]
	internal virtual Label Label_HeaderIP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("MaskedTextBox_HeaderIP")]
	internal virtual MaskedTextBox MaskedTextBox_HeaderIP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_TCP_Search
	{
		[CompilerGenerated]
		get
		{
			return _Button_TCP_Search;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			Button button = _Button_TCP_Search;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_TCP_Search = value;
			button = _Button_TCP_Search;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_InstallXXTouch
	{
		[CompilerGenerated]
		get
		{
			return _Button_InstallXXTouch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_7;
			Button button = _Button_InstallXXTouch;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_InstallXXTouch = value;
			button = _Button_InstallXXTouch;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_Reboot
	{
		[CompilerGenerated]
		get
		{
			return _Button_Reboot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_9;
			Button button = _Button_Reboot;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Reboot = value;
			button = _Button_Reboot;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button_Cancellation
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancellation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_8;
			Button button = _Button_Cancellation;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Cancellation = value;
			button = _Button_Cancellation;
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
			return ihcEhlxpsB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ihcEhlxpsB = value;
		}
	}

	internal virtual OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			openFileDialog_1 = value;
		}
	}

	internal virtual Button Button_Install_deb
	{
		[CompilerGenerated]
		get
		{
			return _Button_Install_deb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_6;
			Button button = _Button_Install_deb;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button_Install_deb = value;
			button = _Button_Install_deb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public Frm_SSH()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += xToVvoeLfX;
		_DeviceList = new DataTable();
		string_0 = "com.1func.xxtouch.ios_1.2-3_iphoneos-arm.deb";
		int_0 = 22;
		string_1 = "alpine";
		object_0 = RuntimeHelpers.GetObjectValue(new object());
		qjuEePytKH = RuntimeHelpers.GetObjectValue(new object());
		string_2 = "";
		bool_0 = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Frm_SSH));
		this.vmethod_3(new System.Windows.Forms.ContextMenuStrip(this.icontainer_0));
		this.ToolStripMenuItem_Check_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_UnCheck_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_NotCheck_Select = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_Check_All = new System.Windows.Forms.ToolStripMenuItem();
		this.vmethod_1(new System.Windows.Forms.OpenFileDialog());
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.ToolStripStatusLabel_FileName = new System.Windows.Forms.ToolStripStatusLabel();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
		this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
		this.DataGridView_DeviceList = new System.Windows.Forms.DataGridView();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.TableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.ListBox_ip_list = new System.Windows.Forms.ListBox();
		this.Label_HeaderIP = new System.Windows.Forms.Label();
		this.MaskedTextBox_HeaderIP = new System.Windows.Forms.MaskedTextBox();
		this.Button_TCP_Search = new System.Windows.Forms.Button();
		this.Button_InstallXXTouch = new System.Windows.Forms.Button();
		this.Button_Reboot = new System.Windows.Forms.Button();
		this.Button_Cancellation = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Button_Install_deb = new System.Windows.Forms.Button();
		this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.vmethod_2().SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
		this.ToolStripContainer1.ContentPanel.SuspendLayout();
		this.ToolStripContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer_Main).BeginInit();
		this.SplitContainer_Main.Panel1.SuspendLayout();
		this.SplitContainer_Main.Panel2.SuspendLayout();
		this.SplitContainer_Main.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).BeginInit();
		this.ContextMenuStrip1.SuspendLayout();
		this.TableLayoutPanel_Main.SuspendLayout();
		base.SuspendLayout();
		this.vmethod_2().Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.ToolStripMenuItem_Check_Select, this.ToolStripMenuItem_UnCheck_Select, this.ToolStripMenuItem_NotCheck_Select, this.ToolStripMenuItem_Check_All });
		this.vmethod_2().Name = "ContextMenuStrip_List";
		this.vmethod_2().ShowImageMargin = false;
		this.vmethod_2().Size = new System.Drawing.Size(124, 92);
		this.ToolStripMenuItem_Check_Select.Name = "ToolStripMenuItem_Check_Select";
		this.ToolStripMenuItem_Check_Select.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem_Check_Select.Text = "勾选选择";
		this.ToolStripMenuItem_UnCheck_Select.Name = "ToolStripMenuItem_UnCheck_Select";
		this.ToolStripMenuItem_UnCheck_Select.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem_UnCheck_Select.Text = "不勾选选择";
		this.ToolStripMenuItem_NotCheck_Select.Name = "ToolStripMenuItem_NotCheck_Select";
		this.ToolStripMenuItem_NotCheck_Select.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem_NotCheck_Select.Text = "反向勾选选择";
		this.ToolStripMenuItem_Check_All.Name = "ToolStripMenuItem_Check_All";
		this.ToolStripMenuItem_Check_All.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem_Check_All.Text = "全部勾选";
		this.vmethod_0().FileName = "OpenFileDialog1";
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		this.ToolStripStatusLabel1.Size = new System.Drawing.Size(401, 17);
		this.ToolStripStatusLabel1.Spring = true;
		this.ToolStripStatusLabel1.Text = "XXTouch 安装工具";
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		this.ToolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
		this.ToolStripProgressBar1.Value = 100;
		this.ToolStripStatusLabel_FileName.AutoSize = false;
		this.ToolStripStatusLabel_FileName.Name = "ToolStripStatusLabel_FileName";
		this.ToolStripStatusLabel_FileName.Size = new System.Drawing.Size(600, 17);
		this.ToolStripStatusLabel_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.ToolStripStatusLabel_FileName, this.ToolStripProgressBar1, this.ToolStripStatusLabel2, this.ToolStripStatusLabel1 });
		this.StatusStrip1.Location = new System.Drawing.Point(0, 0);
		this.StatusStrip1.Name = "StatusStrip1";
		this.StatusStrip1.Size = new System.Drawing.Size(1218, 22);
		this.StatusStrip1.TabIndex = 0;
		this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
		this.ToolStripStatusLabel2.Size = new System.Drawing.Size(100, 17);
		this.ToolStripStatusLabel2.Text = "下载进度：100%";
		this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip1);
		this.ToolStripContainer1.ContentPanel.Controls.Add(this.SplitContainer_Main);
		this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1218, 532);
		this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
		this.ToolStripContainer1.Name = "ToolStripContainer1";
		this.ToolStripContainer1.Size = new System.Drawing.Size(1218, 579);
		this.ToolStripContainer1.TabIndex = 9;
		this.ToolStripContainer1.Text = "ToolStripContainer1";
		this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
		this.SplitContainer_Main.Name = "SplitContainer_Main";
		this.SplitContainer_Main.Panel1.Controls.Add(this.DataGridView_DeviceList);
		this.SplitContainer_Main.Panel2.Controls.Add(this.TableLayoutPanel_Main);
		this.SplitContainer_Main.Size = new System.Drawing.Size(1218, 532);
		this.SplitContainer_Main.SplitterDistance = 885;
		this.SplitContainer_Main.TabIndex = 7;
		this.DataGridView_DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DataGridView_DeviceList.ContextMenuStrip = this.ContextMenuStrip1;
		this.DataGridView_DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DataGridView_DeviceList.Location = new System.Drawing.Point(0, 0);
		this.DataGridView_DeviceList.Name = "DataGridView_DeviceList";
		this.DataGridView_DeviceList.RowTemplate.Height = 23;
		this.DataGridView_DeviceList.Size = new System.Drawing.Size(885, 532);
		this.DataGridView_DeviceList.TabIndex = 5;
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.ToolStripMenuItem1, this.ToolStripMenuItem2, this.ToolStripMenuItem3, this.ToolStripMenuItem4 });
		this.ContextMenuStrip1.Name = "ContextMenuStrip_List";
		this.ContextMenuStrip1.ShowImageMargin = false;
		this.ContextMenuStrip1.Size = new System.Drawing.Size(124, 92);
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem1.Text = "勾选选择";
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem2.Text = "不勾选选择";
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		this.ToolStripMenuItem3.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem3.Text = "反向勾选选择";
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		this.ToolStripMenuItem4.Size = new System.Drawing.Size(123, 22);
		this.ToolStripMenuItem4.Text = "全部勾选";
		this.TableLayoutPanel_Main.ColumnCount = 2;
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.45283f));
		this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.54717f));
		this.TableLayoutPanel_Main.Controls.Add(this.TextBox2, 1, 2);
		this.TableLayoutPanel_Main.Controls.Add(this.Label2, 0, 2);
		this.TableLayoutPanel_Main.Controls.Add(this.Label1, 0, 3);
		this.TableLayoutPanel_Main.Controls.Add(this.ListBox_ip_list, 0, 0);
		this.TableLayoutPanel_Main.Controls.Add(this.Label_HeaderIP, 0, 1);
		this.TableLayoutPanel_Main.Controls.Add(this.MaskedTextBox_HeaderIP, 1, 1);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_TCP_Search, 0, 4);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_InstallXXTouch, 0, 6);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_Reboot, 0, 8);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_Cancellation, 0, 7);
		this.TableLayoutPanel_Main.Controls.Add(this.TextBox1, 1, 3);
		this.TableLayoutPanel_Main.Controls.Add(this.Button_Install_deb, 0, 5);
		this.TableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main";
		this.TableLayoutPanel_Main.RowCount = 10;
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Main.Size = new System.Drawing.Size(329, 532);
		this.TableLayoutPanel_Main.TabIndex = 0;
		this.TextBox2.Location = new System.Drawing.Point(109, 123);
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.Size = new System.Drawing.Size(136, 21);
		this.TextBox2.TabIndex = 14;
		this.TextBox2.Text = "22";
		this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label2.Location = new System.Drawing.Point(3, 120);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(100, 30);
		this.Label2.TabIndex = 12;
		this.Label2.Text = "SSH端口：";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label1.Location = new System.Drawing.Point(3, 150);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(100, 30);
		this.Label1.TabIndex = 11;
		this.Label1.Text = "SSH密码：";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.TableLayoutPanel_Main.SetColumnSpan(this.ListBox_ip_list, 2);
		this.ListBox_ip_list.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListBox_ip_list.FormattingEnabled = true;
		this.ListBox_ip_list.ItemHeight = 12;
		this.ListBox_ip_list.Location = new System.Drawing.Point(3, 3);
		this.ListBox_ip_list.Name = "ListBox_ip_list";
		this.ListBox_ip_list.Size = new System.Drawing.Size(323, 84);
		this.ListBox_ip_list.TabIndex = 9;
		this.Label_HeaderIP.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label_HeaderIP.Location = new System.Drawing.Point(3, 90);
		this.Label_HeaderIP.Name = "Label_HeaderIP";
		this.Label_HeaderIP.Size = new System.Drawing.Size(100, 30);
		this.Label_HeaderIP.TabIndex = 5;
		this.Label_HeaderIP.Text = "网段：";
		this.Label_HeaderIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.MaskedTextBox_HeaderIP.Dock = System.Windows.Forms.DockStyle.Fill;
		this.MaskedTextBox_HeaderIP.Location = new System.Drawing.Point(109, 93);
		this.MaskedTextBox_HeaderIP.Mask = "000.000.000.*";
		this.MaskedTextBox_HeaderIP.Name = "MaskedTextBox_HeaderIP";
		this.MaskedTextBox_HeaderIP.Size = new System.Drawing.Size(217, 21);
		this.MaskedTextBox_HeaderIP.TabIndex = 2;
		this.TableLayoutPanel_Main.SetColumnSpan(this.Button_TCP_Search, 2);
		this.Button_TCP_Search.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_TCP_Search.Location = new System.Drawing.Point(3, 183);
		this.Button_TCP_Search.Name = "Button_TCP_Search";
		this.Button_TCP_Search.Size = new System.Drawing.Size(323, 34);
		this.Button_TCP_Search.TabIndex = 3;
		this.Button_TCP_Search.Text = "扫描有安装SSH的设备";
		this.Button_TCP_Search.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Main.SetColumnSpan(this.Button_InstallXXTouch, 2);
		this.Button_InstallXXTouch.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_InstallXXTouch.Location = new System.Drawing.Point(3, 263);
		this.Button_InstallXXTouch.Name = "Button_InstallXXTouch";
		this.Button_InstallXXTouch.Size = new System.Drawing.Size(323, 34);
		this.Button_InstallXXTouch.TabIndex = 6;
		this.Button_InstallXXTouch.Text = "安装 XXTouch";
		this.Button_InstallXXTouch.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Main.SetColumnSpan(this.Button_Reboot, 2);
		this.Button_Reboot.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Reboot.Location = new System.Drawing.Point(3, 343);
		this.Button_Reboot.Name = "Button_Reboot";
		this.Button_Reboot.Size = new System.Drawing.Size(323, 34);
		this.Button_Reboot.TabIndex = 7;
		this.Button_Reboot.Text = "重启设备";
		this.Button_Reboot.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Main.SetColumnSpan(this.Button_Cancellation, 2);
		this.Button_Cancellation.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Cancellation.Location = new System.Drawing.Point(3, 303);
		this.Button_Cancellation.Name = "Button_Cancellation";
		this.Button_Cancellation.Size = new System.Drawing.Size(323, 34);
		this.Button_Cancellation.TabIndex = 8;
		this.Button_Cancellation.Text = "注销设备";
		this.Button_Cancellation.UseVisualStyleBackColor = true;
		this.TextBox1.Location = new System.Drawing.Point(109, 153);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(136, 21);
		this.TextBox1.TabIndex = 13;
		this.TextBox1.Text = "alpine";
		this.TableLayoutPanel_Main.SetColumnSpan(this.Button_Install_deb, 2);
		this.Button_Install_deb.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Install_deb.Location = new System.Drawing.Point(3, 223);
		this.Button_Install_deb.Name = "Button_Install_deb";
		this.Button_Install_deb.Size = new System.Drawing.Size(323, 34);
		this.Button_Install_deb.TabIndex = 15;
		this.Button_Install_deb.Text = "安装插件";
		this.Button_Install_deb.UseVisualStyleBackColor = true;
		this.OpenFileDialog1.FileName = "OpenFileDialog1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1218, 579);
		base.Controls.Add(this.ToolStripContainer1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Frm_SSH";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "SSH 扫描器";
		this.vmethod_2().ResumeLayout(false);
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
		this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
		this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
		this.ToolStripContainer1.ResumeLayout(false);
		this.ToolStripContainer1.PerformLayout();
		this.SplitContainer_Main.Panel1.ResumeLayout(false);
		this.SplitContainer_Main.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer_Main).EndInit();
		this.SplitContainer_Main.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DataGridView_DeviceList).EndInit();
		this.ContextMenuStrip1.ResumeLayout(false);
		this.TableLayoutPanel_Main.ResumeLayout(false);
		this.TableLayoutPanel_Main.PerformLayout();
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

	[SpecialName]
	[CompilerGenerated]
	internal virtual ContextMenuStrip vmethod_2()
	{
		return contextMenuStrip_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void vmethod_3(ContextMenuStrip WithEventsValue)
	{
		contextMenuStrip_0 = WithEventsValue;
	}

	private void method_0()
	{
		int_0 = checked((int)Math.Round(Conversion.Val(TextBox2.Text)));
		string_1 = TextBox1.Text;
	}

	private int method_1(int int_1)
	{
		if (int_1 >= 1443)
		{
			return 11;
		}
		if (int_1 >= 1348 && int_1 <= 1443)
		{
			return 10;
		}
		if (int_1 >= 1240 && int_1 <= 1348)
		{
			return 9;
		}
		if (int_1 >= 1140 && int_1 <= 1240)
		{
			return 8;
		}
		if (int_1 >= 847 && int_1 <= 1140)
		{
			return 7;
		}
		if (int_1 >= 793 && int_1 <= 847)
		{
			return 6;
		}
		return 5;
	}

	private void xToVvoeLfX(object sender, EventArgs e)
	{
		_DeviceList.Clear();
		_DeviceList.Columns.Clear();
		_DeviceList.Rows.Clear();
		DataColumnCollection columns = _DeviceList.Columns;
		columns.Add("check", typeof(bool));
		columns.Add("ip", typeof(string));
		columns.Add("OSVersion", typeof(long));
		columns.Add("message", typeof(string));
		DataColumn[] primaryKey = new DataColumn[1] { _DeviceList.Columns["ip"] };
		_DeviceList.PrimaryKey = primaryKey;
		DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
		dataGridView_DeviceList.DataSource = null;
		dataGridView_DeviceList.Rows.Clear();
		dataGridView_DeviceList.Columns.Clear();
		DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn
		{
			DataPropertyName = "check",
			HeaderText = "选择",
			ReadOnly = false
		};
		DataGridView_DeviceList.Columns.Add(dataGridViewColumn);
		dataGridView_DeviceList.DataSource = _DeviceList;
		dataGridView_DeviceList.Columns["ip"].HeaderText = "IP";
		dataGridView_DeviceList.Columns["message"].HeaderText = "状态";
		dataGridView_DeviceList.Columns["OSVersion"].HeaderText = "系统版本";
		dataGridView_DeviceList.Columns["OSVersion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView_DeviceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_DeviceList.AllowUserToAddRows = false;
		dataGridView_DeviceList.EditMode = DataGridViewEditMode.EditOnEnter;
		dataGridView_DeviceList.BackgroundColor = Color.White;
		dataGridView_DeviceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		dataGridView_DeviceList.ReadOnly = true;
		dataGridView_DeviceList.AutoGenerateColumns = true;
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (!(iPAddress.IsIPv6LinkLocal | iPAddress.IsIPv6Multicast | iPAddress.IsIPv6SiteLocal | (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)))
			{
				ListBox_ip_list.Items.Add(iPAddress.ToString());
			}
		}
		if (ListBox_ip_list.Items.Count > 0)
		{
			ListBox_ip_list.SelectedIndex = 0;
		}
	}

	public string PostCode(string Url, string PostData, int TimeOut = 5000)
	{
		string result;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ServicePoint.ConnectionLimit = 200;
			httpWebRequest.AllowAutoRedirect = true;
			httpWebRequest.KeepAlive = false;
			httpWebRequest.Timeout = TimeOut;
			httpWebRequest.ReadWriteTimeout = 100000;
			byte[] bytes = Encoding.UTF8.GetBytes(PostData);
			httpWebRequest.ContentLength = bytes.Length;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
				stream.Close();
			}
			string text;
			using (WebResponse webResponse = httpWebRequest.GetResponse())
			{
				using (Stream stream2 = webResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(stream2))
					{
						text = streamReader.ReadToEnd();
						streamReader.Close();
					}
					stream2.Close();
				}
				webResponse.Close();
			}
			httpWebRequest = null;
			result = text;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool HttpDownload(string url, string path, ToolStripProgressBar prog, ToolStripStatusLabel label1)
	{
		string obj = Path.GetDirectoryName(path) + "\\temp";
		Directory.CreateDirectory(obj);
		string text = obj + "\\" + Path.GetFileName(path) + ".temp";
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		bool result;
		try
		{
			FileStream fileStream = new FileStream(text, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
			Stream responseStream = ((WebRequest.Create(url) as HttpWebRequest).GetResponse() as HttpWebResponse).GetResponseStream();
			byte[] array = new byte[1024];
			for (int num = responseStream.Read(array, 0, array.Length); num > 0; num = responseStream.Read(array, 0, array.Length))
			{
				fileStream.Write(array, 0, num);
			}
			fileStream.Close();
			responseStream.Close();
			File.Move(text, path);
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool DownloadFile(string URL, string filename, ToolStripProgressBar prog, ToolStripStatusLabel label1)
	{
		_Closure_0024__145_002D0 arg = default(_Closure_0024__145_002D0);
		_Closure_0024__145_002D0 CS_0024_003C_003E8__locals27 = new _Closure_0024__145_002D0(arg);
		CS_0024_003C_003E8__locals27._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals27._0024VB_0024Local_filename = filename;
		CS_0024_003C_003E8__locals27._0024VB_0024Local_prog = prog;
		CS_0024_003C_003E8__locals27._0024VB_0024Local_label1 = label1;
		CS_0024_003C_003E8__locals27._0024VB_0024Local_percent = 0f;
		checked
		{
			bool result;
			try
			{
				try
				{
					_Closure_0024__145_002D1 arg2 = default(_Closure_0024__145_002D1);
					_Closure_0024__145_002D1 CS_0024_003C_003E8__locals24 = new _Closure_0024__145_002D1(arg2);
					CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals27;
					HttpWebResponse httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(URL)).GetResponse();
					CS_0024_003C_003E8__locals24._0024VB_0024Local_totalBytes = httpWebResponse.ContentLength;
					Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
					{
						CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_prog.Maximum = (int)CS_0024_003C_003E8__locals24._0024VB_0024Local_totalBytes;
					}));
					Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
					{
						CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.ToolStripStatusLabel_FileName.Text = Path.GetFileName(CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_filename);
					}));
					Stream responseStream = httpWebResponse.GetResponseStream();
					Stream stream = new FileStream(CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_filename, FileMode.Create);
					CS_0024_003C_003E8__locals24._0024VB_0024Local_totalDownloadedByte = 0L;
					byte[] array = new byte[10231];
					int num = responseStream.Read(array, 0, array.Length);
					while (num > 0)
					{
						CS_0024_003C_003E8__locals24._0024VB_0024Local_totalDownloadedByte = num + CS_0024_003C_003E8__locals24._0024VB_0024Local_totalDownloadedByte;
						Application.DoEvents();
						stream.Write(array, 0, num);
						Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
						{
							CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_prog.Value = (int)CS_0024_003C_003E8__locals24._0024VB_0024Local_totalDownloadedByte;
						}));
						num = responseStream.Read(array, 0, array.Length);
						CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_percent = (float)CS_0024_003C_003E8__locals24._0024VB_0024Local_totalDownloadedByte / (float)CS_0024_003C_003E8__locals24._0024VB_0024Local_totalBytes * 100f;
						Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
						{
							CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_label1.Text = "下载进度：" + CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_percent + "%";
						}));
						Application.DoEvents();
					}
					stream.Close();
					responseStream.Close();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
				Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
				{
					CS_0024_003C_003E8__locals27._0024VB_0024Local_prog.Value = CS_0024_003C_003E8__locals27._0024VB_0024Local_prog.Maximum;
				}));
				Invoke((VB_0024AnonymousDelegate_0)([SpecialName] () =>
				{
					CS_0024_003C_003E8__locals27._0024VB_0024Local_label1.Text = "下载进度：100%";
				}));
				result = true;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool Get_Lastst(ref string package, ref string filename)
	{
		bool result;
		try
		{
			string text = PostCode("https://www.xxtouch.com/check-update?p=" + package, "");
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				JObject val = JObject.Parse(text);
				filename = val["path"].ToString();
				if (File.Exists(Application.StartupPath + "\\" + val["path"].ToString()))
				{
					if (Operators.CompareString(GetMD5HashFromFile(Application.StartupPath + "\\" + val["path"].ToString()).ToLower(), val["md5"].ToString().ToLower(), TextCompare: false) == 0)
					{
						result = true;
					}
					else if (new Form_MessageBox("新版更新：\r\n" + val["description"].ToString() + "\r\n\r\n是否立即下载？", "需要下载新版安装包 " + val["latest"].ToString()).ShowDialog() == DialogResult.Yes)
					{
						if (DownloadFile(val["url"].ToString(), Application.StartupPath + "\\" + val["path"].ToString(), ToolStripProgressBar1, ToolStripStatusLabel2))
						{
							result = true;
						}
						else
						{
							MessageBox.Show("无法获取最新版 XXTouch 安装包", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							result = false;
						}
					}
					else
					{
						result = false;
					}
				}
				else if (new Form_MessageBox("新版更新：\r\n" + val["description"].ToString() + "\r\n\r\n是否立即下载？", "需要下载新版安装包 " + val["latest"].ToString()).ShowDialog() == DialogResult.Yes)
				{
					if (DownloadFile(val["url"].ToString(), Application.StartupPath + "\\" + val["path"].ToString(), ToolStripProgressBar1, ToolStripStatusLabel2))
					{
						result = true;
					}
					else
					{
						MessageBox.Show("无法获取最新版 XXTouch 安装包", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string GetMD5HashFromFile(string fileName)
	{
		checked
		{
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Open);
				byte[] array = new MD5CryptoServiceProvider().ComputeHash(fileStream);
				fileStream.Close();
				StringBuilder stringBuilder = new StringBuilder();
				int num = array.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				return stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new Exception("GetMD5HashFromFile() fail,error:" + ex2.Message);
			}
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			string[] array = ListBox_ip_list.SelectedItem.ToString().ToString().Split('.');
			MaskedTextBox_HeaderIP.Text = $"{array[0].PadRight(3, ' ')}.{array[1].PadRight(3, ' ')}.{array[2].PadRight(3, ' ')}.*";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		string text = "";
		string[] array = Strings.Split(MaskedTextBox_HeaderIP.Text.Replace(" ", ""), ".");
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
				method_0();
				int num2 = 1;
				do
				{
					ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
					{
						TestLink(Conversions.ToString(a0));
					}, text + Conversions.ToString(num2));
					num2++;
				}
				while (num2 <= 255);
				GC.Collect();
				return;
			}
			MessageBox.Show("IP 地址不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public void TestLink(string IP)
	{
		try
		{
			new TcpClientWithTimeout(IP, int_0, 500).Connect().Close();
			AddDevice(IP);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public bool Test_Get_OSV(string IP)
	{
		bool result;
		try
		{
			SFTPOperation sFTPOperation = new SFTPOperation(IP, Conversions.ToString(int_0), "root", string_1);
			Path.GetFileName(string_2);
			string text = sFTPOperation.Execute("cfversion");
			if (text != null && Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				int oSV = method_1(Conversions.ToInteger(text));
				AddList(IP, "", oSV);
				result = true;
			}
			else
			{
				AddList(IP, "无法操作该设备");
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddList(IP, ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AddList(string IP, string Message, int OSV = -1)
	{
		if (base.InvokeRequired)
		{
			Delegate1 method = AddList;
			Invoke(method, IP, Message, OSV);
			return;
		}
		object obj = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				DataRow dataRow = _DeviceList.Select("ip='" + IP + "'")[0];
				dataRow["message"] = Message;
				if (OSV > -1)
				{
					dataRow["OSVersion"] = OSV;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public void AddDevice(string ip)
	{
		if (DataGridView_DeviceList.InvokeRequired)
		{
			Delegate2 method = AddDevice;
			DataGridView_DeviceList.Invoke(method, ip);
			return;
		}
		object obj = qjuEePytKH;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			try
			{
				if (_DeviceList.Rows.Find(ip) == null)
				{
					DataRow dataRow = _DeviceList.NewRow();
					dataRow["check"] = false;
					dataRow["ip"] = ip;
					dataRow["OSVersion"] = 0;
					dataRow["message"] = "";
					_DeviceList.Rows.Add(dataRow);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private void method_4(string string_3)
	{
		try
		{
			SFTPOperation sFTPOperation = new SFTPOperation(string_3, Conversions.ToString(int_0), "root", string_1);
			AddList(string_3, "重启中");
			if (sFTPOperation.Execute("reboot") == null)
			{
				AddList(string_3, "重启失败");
			}
			else
			{
				AddList(string_3, "重启成功");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddList(string_3, ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(string string_3)
	{
		try
		{
			SFTPOperation sFTPOperation = new SFTPOperation(string_3, Conversions.ToString(int_0), "root", string_1);
			AddList(string_3, "注销中");
			if (sFTPOperation.Execute("killall -9 backboardd") == null)
			{
				AddList(string_3, "注销失败");
			}
			else
			{
				AddList(string_3, "注销成功");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddList(string_3, ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void Install_XXTouch(string ip)
	{
		try
		{
			SFTPOperation sFTPOperation = new SFTPOperation(ip, Conversions.ToString(int_0), "root", string_1);
			AddList(ip, "检测系统版本");
			string text = sFTPOperation.Execute("cfversion");
			if (text != null && Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				int num = method_1(Conversions.ToInteger(text));
				if ((num <= 11) & (num > 5))
				{
					AddList(ip, "iOS " + Conversions.ToString(num) + " 正在安装");
					text = sFTPOperation.Execute("dpkg -s mobilesubstrate");
					if (!text.Contains("install ok installed"))
					{
						AddList(ip, "请先从 Cydia 安装基础依赖 Substrate");
						return;
					}
					text = sFTPOperation.Put(Application.StartupPath + "\\" + string_0, "/tmp/" + string_0);
					if (text == null)
					{
						text = sFTPOperation.Execute("dpkg -i /tmp/" + string_0 + "  && echo ILoveXXTouch");
						text = ((!text.Contains("ILoveXXTouch")) ? "安装失败" : "安装成功");
						sFTPOperation.Delete("/tmp/" + string_0);
						AddList(ip, text);
					}
					else
					{
						AddList(ip, "安装失败");
					}
				}
				else
				{
					AddList(ip, "低于 iOS 5 设备无法安装");
				}
			}
			else
			{
				AddList(ip, "检测设备版本失败");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddList(ip, ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void Install_Other(string ip)
	{
		try
		{
			SFTPOperation sFTPOperation = new SFTPOperation(ip, Conversions.ToString(int_0), "root", string_1);
			string text = "xxt_tmp";
			AddList(ip, "检测系统版本");
			string text2 = sFTPOperation.Execute("cfversion");
			if (text2 != null && Operators.CompareString(text2, "", TextCompare: false) != 0)
			{
				int num = method_1(Conversions.ToInteger(text2));
				if ((num <= 11) & (num > 5))
				{
					if (Operators.CompareString(Path.GetExtension(string_2), ".deb", TextCompare: false) == 0)
					{
						AddList(ip, "iOS " + Conversions.ToString(num) + " 正在安装");
						text2 = sFTPOperation.Put(string_2, "/tmp/" + text + ".deb");
						if (text2 == null)
						{
							text2 = sFTPOperation.Execute("dpkg -i /tmp/" + text + ".deb && echo ILoveXXTouch");
							text2 = ((!text2.Contains("ILoveXXTouch")) ? "安装失败" : "安装成功");
							sFTPOperation.Delete("/tmp/" + text + ".deb");
							AddList(ip, text2);
						}
						else
						{
							AddList(ip, "安装失败");
						}
					}
					else
					{
						AddList(ip, "iOS " + Conversions.ToString(num) + " 系统无法安装此安装包");
					}
				}
				else
				{
					AddList(ip, "低于 iOS 5 设备无法安装");
				}
			}
			else
			{
				AddList(ip, "检测设备版本失败");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddList(ip, ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		_Closure_0024__163_002D0 arg = default(_Closure_0024__163_002D0);
		_Closure_0024__163_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__163_002D0(arg);
		CS_0024_003C_003E8__locals3._0024VB_0024Me = this;
		method_0();
		CS_0024_003C_003E8__locals3._0024VB_0024Local_deb_download = false;
		OpenFileDialog openFileDialog = vmethod_0();
		openFileDialog.Title = "选择要安装至设备的安装包";
		openFileDialog.FileName = "";
		openFileDialog.InitialDirectory = Application.StartupPath;
		openFileDialog.Filter = "插件安装包 (*.deb)|*.deb|所有文件 (*.*)|*.*";
		openFileDialog.FilterIndex = 0;
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		openFileDialog.ShowDialog();
		if ((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName))
		{
			openFileDialog = null;
			string_2 = vmethod_0().FileName;
			ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
			{
				CS_0024_003C_003E8__locals3._Lambda_0024__0();
			});
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		_Closure_0024__164_002D0 arg = default(_Closure_0024__164_002D0);
		_Closure_0024__164_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__164_002D0(arg);
		CS_0024_003C_003E8__locals5._0024VB_0024Me = this;
		method_0();
		CS_0024_003C_003E8__locals5._0024VB_0024Local_deb_download = false;
		CS_0024_003C_003E8__locals5._0024VB_0024Local_shift_b = Control.ModifierKeys == Keys.Shift;
		if (CS_0024_003C_003E8__locals5._0024VB_0024Local_shift_b)
		{
			OpenFileDialog openFileDialog = vmethod_0();
			openFileDialog.Title = "选择要安装至设备的安装包";
			openFileDialog.FileName = "";
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.Filter = "插件安装包 (*.deb)|*.deb|所有文件 (*.*)|*.*";
			openFileDialog.FilterIndex = 0;
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.ShowDialog();
			if (!((Operators.CompareString(openFileDialog.FileName, "", TextCompare: false) != 0) & File.Exists(openFileDialog.FileName)))
			{
				return;
			}
			openFileDialog = null;
			string_2 = vmethod_0().FileName;
		}
		ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
		{
			CS_0024_003C_003E8__locals5._Lambda_0024__0();
		});
	}

	private void method_8(object sender, EventArgs e)
	{
		method_0();
		ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
		{
			_Lambda_0024__165_002D0();
		});
	}

	private void method_9(object sender, EventArgs e)
	{
		method_0();
		ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
		{
			_Lambda_0024__166_002D0();
		});
	}

	private void method_10(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 0)
		{
			bool_0 = !bool_0;
			foreach (DataRow row in _DeviceList.Rows)
			{
				row["check"] = bool_0;
			}
			DataGridView_DeviceList.DataSource = _DeviceList;
		}
		else
		{
			_DeviceList.DefaultView.Sort = Conversions.ToString(Operators.ConcatenateObject(DataGridView_DeviceList.Columns[e.ColumnIndex].DataPropertyName, Interaction.IIf(DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending, " desc", " asc")));
			if (DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
			{
				DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
			}
			else
			{
				DataGridView_DeviceList.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
			}
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (DataGridView_DeviceList.IsCurrentCellDirty)
		{
			DataGridView_DeviceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void method_12(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex == 0)
			{
				DataGridView dataGridView_DeviceList = DataGridView_DeviceList;
				_DeviceList.Rows.Find(RuntimeHelpers.GetObjectValue(dataGridView_DeviceList.Rows[e.RowIndex].Cells["ip"].Value))["check"] = !Conversions.ToBoolean(dataGridView_DeviceList[e.ColumnIndex, e.RowIndex].EditedFormattedValue);
				dataGridView_DeviceList.DataSource = _DeviceList;
				dataGridView_DeviceList = null;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__165_002D0()
	{
		List<string> list = new List<string>();
		DataRow[] array = _DeviceList.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			if (Test_Get_OSV(Conversions.ToString(dataRow["ip"])))
			{
				if (Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 11, TextCompare: false))
				{
					list.Add(dataRow["ip"].ToString());
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(dataRow["OSVersion"], 11, TextCompare: false), Operators.CompareObjectGreaterEqual(dataRow["OSVersion"], 6, TextCompare: false))))
				{
					list.Add(dataRow["ip"].ToString());
				}
				else if (!Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 0, TextCompare: false))
				{
					AddList(Conversions.ToString(dataRow["ip"]), "不支持当前系统");
				}
			}
		}
		if (list.Count == 0)
		{
			MessageBox.Show("请先扫描并勾选至少一台设备", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int count = list.Count;
		checked
		{
			for (int j = 1; j <= count; j++)
			{
				ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
				{
					method_5(Conversions.ToString(a0));
				}, list[j - 1]);
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__166_002D0()
	{
		List<string> list = new List<string>();
		DataRow[] array = _DeviceList.Select("check=True");
		foreach (DataRow dataRow in array)
		{
			if (Test_Get_OSV(Conversions.ToString(dataRow["ip"])))
			{
				if (Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 11, TextCompare: false))
				{
					list.Add(dataRow["ip"].ToString());
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(dataRow["OSVersion"], 11, TextCompare: false), Operators.CompareObjectGreaterEqual(dataRow["OSVersion"], 6, TextCompare: false))))
				{
					list.Add(dataRow["ip"].ToString());
				}
				else if (!Operators.ConditionalCompareObjectEqual(dataRow["OSVersion"], 0, TextCompare: false))
				{
					AddList(Conversions.ToString(dataRow["ip"]), "不支持当前系统");
				}
			}
		}
		if (list.Count == 0)
		{
			MessageBox.Show("请先扫描并勾选至少一台设备", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int count = list.Count;
		checked
		{
			for (int j = 1; j <= count; j++)
			{
				ThreadPool.QueueUserWorkItem([SpecialName] (object a0) =>
				{
					method_4(Conversions.ToString(a0));
				}, list[j - 1]);
			}
		}
	}
}
