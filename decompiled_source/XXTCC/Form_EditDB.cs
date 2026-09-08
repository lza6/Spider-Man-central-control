using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_EditDB : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ListView_Key")]
	private ListView TnWiVwqxse;

	[CompilerGenerated]
	[AccessedThroughProperty("添加ToolStripMenuItem")]
	private ToolStripMenuItem _添加ToolStripMenuItem;

	[AccessedThroughProperty("修改ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _修改ToolStripMenuItem;

	[AccessedThroughProperty("删除ToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _删除ToolStripMenuItem;

	public string DbName;

	internal virtual ListView ListView_Key
	{
		[CompilerGenerated]
		get
		{
			return TnWiVwqxse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TnWiVwqxse = value;
		}
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
			EventHandler value2 = method_1;
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
			EventHandler value2 = method_2;
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
			EventHandler value2 = method_3;
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

	public Form_EditDB()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_EditDB_Load;
		DbName = "";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Form_EditDB));
		this.ListView_Key = new System.Windows.Forms.ListView();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ContextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.ListView_Key.ContextMenuStrip = this.ContextMenuStrip1;
		this.ListView_Key.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView_Key.FullRowSelect = true;
		this.ListView_Key.GridLines = true;
		this.ListView_Key.Location = new System.Drawing.Point(0, 0);
		this.ListView_Key.MultiSelect = false;
		this.ListView_Key.Name = "ListView_Key";
		this.ListView_Key.Size = new System.Drawing.Size(352, 322);
		this.ListView_Key.TabIndex = 1;
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
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(352, 322);
		base.Controls.Add(this.ListView_Key);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Form_EditDB";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.ContextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void Form_EditDB_Load(object sender, EventArgs e)
	{
		ListView_Key.View = View.Details;
		ListView_Key.Columns.Add("列名", 300, HorizontalAlignment.Center);
		method_0();
	}

	private void method_0()
	{
		ListView_Key.Items.Clear();
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("select * from [" + DbName + "]", Class9.oleDbConnection_0);
		DataTable dataTable = new DataTable();
		oleDbDataAdapter.Fill(dataTable);
		checked
		{
			int num = dataTable.Columns.Count - 1;
			for (int i = 1; i <= num; i++)
			{
				ListView_Key.Items.Add(dataTable.Columns[i].Caption);
			}
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		string text = Interaction.InputBox("输入要添加的列名", "添加");
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			Class9.ikpUfLfjaf("ALTER TABLE [" + DbName + "] ADD [" + text + "] Memo");
			method_0();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (ListView_Key.SelectedItems.Count != 0)
		{
			ListViewItem listViewItem = ListView_Key.SelectedItems[0];
			string text = Interaction.InputBox("输入要修改后的列名", "修改");
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				OleDbCommand oleDbCommand = Class9.oleDbConnection_0.CreateCommand();
				oleDbCommand.CommandText = "alter table [" + DbName + "] add " + text + " Memo";
				oleDbCommand.ExecuteNonQuery();
				oleDbCommand.CommandText = "update [" + DbName + "] set " + text + "=" + listViewItem.Text;
				oleDbCommand.ExecuteNonQuery();
				oleDbCommand.CommandText = "alter table [" + DbName + "] drop " + listViewItem.Text;
				oleDbCommand.ExecuteNonQuery();
				method_0();
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (ListView_Key.SelectedItems.Count != 0)
		{
			ListViewItem listViewItem = ListView_Key.SelectedItems[0];
			if (MessageBox.Show("是否确定要删除此列，也许会出现丢失数据的情况。", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				Class9.ikpUfLfjaf("ALTER TABLE [" + DbName + "] DROP COLUMN [" + listViewItem.Text + "]");
				method_0();
			}
		}
	}
}
