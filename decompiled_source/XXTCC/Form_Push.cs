using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace XXTCC;

[DesignerGenerated]
public class Form_Push : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("ComboBox_Name")]
	[CompilerGenerated]
	private ComboBox _ComboBox_Name;

	[field: AccessedThroughProperty("GroupBox_Edit")]
	internal virtual GroupBox GroupBox_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel_Edit")]
	internal virtual TableLayoutPanel TableLayoutPanel_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button_OK")]
	internal virtual Button Button_OK
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button_Cancel")]
	internal virtual Button Button_Cancel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox_Name
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_Name;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_0;
			ComboBox comboBox = _ComboBox_Name;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox_Name = value;
			comboBox = _ComboBox_Name;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
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

	[field: AccessedThroughProperty("TextBox_Message")]
	internal virtual TextBox TextBox_Message
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

	public Form_Push()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		base.Load += Form_Push_Load;
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
		this.GroupBox_Edit = new System.Windows.Forms.GroupBox();
		this.TextBox_Message = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.ComboBox_Name = new System.Windows.Forms.ComboBox();
		this.TextBox_Instructions = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.TableLayoutPanel_Edit = new System.Windows.Forms.TableLayoutPanel();
		this.Button_OK = new System.Windows.Forms.Button();
		this.Button_Cancel = new System.Windows.Forms.Button();
		this.GroupBox_Edit.SuspendLayout();
		this.TableLayoutPanel_Edit.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel_Edit.SetColumnSpan(this.GroupBox_Edit, 3);
		this.GroupBox_Edit.Controls.Add(this.TextBox_Message);
		this.GroupBox_Edit.Controls.Add(this.Label3);
		this.GroupBox_Edit.Controls.Add(this.ComboBox_Name);
		this.GroupBox_Edit.Controls.Add(this.TextBox_Instructions);
		this.GroupBox_Edit.Controls.Add(this.Label2);
		this.GroupBox_Edit.Controls.Add(this.Label1);
		this.GroupBox_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox_Edit.Location = new System.Drawing.Point(3, 3);
		this.GroupBox_Edit.Name = "GroupBox_Edit";
		this.GroupBox_Edit.Size = new System.Drawing.Size(444, 317);
		this.GroupBox_Edit.TabIndex = 3;
		this.GroupBox_Edit.TabStop = false;
		this.TextBox_Message.BackColor = System.Drawing.SystemColors.Window;
		this.TextBox_Message.Location = new System.Drawing.Point(155, 187);
		this.TextBox_Message.Multiline = true;
		this.TextBox_Message.Name = "TextBox_Message";
		this.TextBox_Message.Size = new System.Drawing.Size(247, 110);
		this.TextBox_Message.TabIndex = 7;
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(31, 190);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(59, 12);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "推送内容:";
		this.ComboBox_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox_Name.FormattingEnabled = true;
		this.ComboBox_Name.Location = new System.Drawing.Point(155, 43);
		this.ComboBox_Name.Name = "ComboBox_Name";
		this.ComboBox_Name.Size = new System.Drawing.Size(247, 20);
		this.ComboBox_Name.TabIndex = 5;
		this.TextBox_Instructions.BackColor = System.Drawing.SystemColors.ScrollBar;
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
		this.TableLayoutPanel_Edit.ColumnCount = 3;
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115f));
		this.TableLayoutPanel_Edit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115f));
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_OK, 1, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.Button_Cancel, 2, 1);
		this.TableLayoutPanel_Edit.Controls.Add(this.GroupBox_Edit, 0, 0);
		this.TableLayoutPanel_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TableLayoutPanel_Edit.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel_Edit.Name = "TableLayoutPanel_Edit";
		this.TableLayoutPanel_Edit.RowCount = 2;
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel_Edit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55f));
		this.TableLayoutPanel_Edit.Size = new System.Drawing.Size(450, 378);
		this.TableLayoutPanel_Edit.TabIndex = 11;
		this.Button_OK.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_OK.Location = new System.Drawing.Point(230, 333);
		this.Button_OK.Margin = new System.Windows.Forms.Padding(10);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(95, 35);
		this.Button_OK.TabIndex = 1;
		this.Button_OK.Text = "确认";
		this.Button_OK.UseVisualStyleBackColor = true;
		this.Button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button_Cancel.Location = new System.Drawing.Point(345, 333);
		this.Button_Cancel.Margin = new System.Windows.Forms.Padding(10);
		this.Button_Cancel.Name = "Button_Cancel";
		this.Button_Cancel.Size = new System.Drawing.Size(95, 35);
		this.Button_Cancel.TabIndex = 2;
		this.Button_Cancel.Text = "取消";
		this.Button_Cancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(450, 378);
		base.Controls.Add(this.TableLayoutPanel_Edit);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_Push";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "推送内容";
		this.GroupBox_Edit.ResumeLayout(false);
		this.GroupBox_Edit.PerformLayout();
		this.TableLayoutPanel_Edit.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void Form_Push_Load(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		foreach (JProperty item in ((JContainer)Class9.jobject_2).Children())
		{
			JProperty val = item;
			ComboBox_Name.Items.Add(val.Name);
		}
		ComboBox_Name.SelectedIndex = 0;
	}

	private void method_0(object sender, EventArgs e)
	{
		if (ComboBox_Name.SelectedIndex != -1)
		{
			TextBox_Instructions.Text = (string)Class9.jobject_2[RuntimeHelpers.GetObjectValue(ComboBox_Name.SelectedItem)];
		}
	}
}
