using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Form_Key : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private Button yeptCsuZxq;

	[field: AccessedThroughProperty("TableLayoutPanel_Edit")]
	internal virtual TableLayoutPanel TableLayoutPanel_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button_OK
	{
		[CompilerGenerated]
		get
		{
			return yeptCsuZxq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yeptCsuZxq = value;
		}
	}

	[field: AccessedThroughProperty("Button_Cancel")]
	internal virtual Button Button_Cancel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox_Edit")]
	internal virtual GroupBox GroupBox_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox_Name")]
	internal virtual TextBox TextBox_Name
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
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

	public Form_Key()
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
		this.TableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
		this.Button_OK = new System.Windows.Forms.Button();
		this.Button_Cancel = new System.Windows.Forms.Button();
		this.GroupBox_Edit = new System.Windows.Forms.GroupBox();
		this.TextBox_Name = new System.Windows.Forms.TextBox();
		this.TextBox_Instructions = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.TableLayoutPanel_Edit.SuspendLayout();
		this.GroupBox_Edit.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel_Edit.ColumnCount = 3;
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71f));
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_OK, 1, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_Cancel, 2, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.GroupBox_Edit, 0, 0);
		this.TableLayoutPanel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Edit.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Edit.Name = "TableLayoutPanel_Edit";
		this.TableLayoutPanel_Edit.RowCount = 2;
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
		this.TableLayoutPanel_Edit.Size = new System.Drawing.Size(449, 256);
		this.TableLayoutPanel_Edit.TabIndex = 10;
		this.Button_OK.Location = new System.Drawing.Point(312, 224);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(63, 23);
		this.Button_OK.TabIndex = 1;
		this.Button_OK.Text = "确认";
		this.Button_OK.UseVisualStyleBackColor = true;
		this.Button_Cancel.Location = new System.Drawing.Point(381, 224);
		this.Button_Cancel.Name = "Button_Cancel";
		this.Button_Cancel.Size = new System.Drawing.Size(65, 23);
		this.Button_Cancel.TabIndex = 2;
		this.Button_Cancel.Text = "取消";
		this.Button_Cancel.UseVisualStyleBackColor = true;
		this.TableLayoutPanel_Edit.SetColumnSpan(this.GroupBox_Edit, 3);
		this.GroupBox_Edit.Controls.Add(this.TextBox_Name);
		this.GroupBox_Edit.Controls.Add(this.TextBox_Instructions);
		this.GroupBox_Edit.Controls.Add(this.Label2);
		this.GroupBox_Edit.Controls.Add(this.Label1);
		this.GroupBox_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Edit.Location = new System.Drawing.Point(3, 3);
		this.GroupBox_Edit.Name = "GroupBox_Edit";
		this.GroupBox_Edit.Size = new System.Drawing.Size(443, 215);
		this.GroupBox_Edit.TabIndex = 3;
		this.GroupBox_Edit.TabStop = false;
		this.TextBox_Name.BackColor = System.Drawing.SystemColors.ScrollBar;
		this.TextBox_Name.Location = new System.Drawing.Point(155, 43);
		this.TextBox_Name.Name = "TextBox_Name";
		this.TextBox_Name.ReadOnly = true;
		this.TextBox_Name.Size = new System.Drawing.Size(247, 21);
		this.TextBox_Name.TabIndex = 5;
		this.TextBox_Instructions.Location = new System.Drawing.Point(155, 70);
		this.TextBox_Instructions.Multiline = true;
		this.TextBox_Instructions.Name = "TextBox_Instructions";
		this.TextBox_Instructions.Size = new System.Drawing.Size(247, 110);
		this.TextBox_Instructions.TabIndex = 4;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(31, 46);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(35, 12);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "键名:";
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(31, 73);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(47, 12);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "键简介:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(449, 256);
		base.Controls.Add(this.TableLayoutPanel_Edit);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_Key";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TableLayoutPanel_Edit.ResumeLayout(false);
		this.GroupBox_Edit.ResumeLayout(false);
		this.GroupBox_Edit.PerformLayout();
		base.ResumeLayout(false);
	}
}
