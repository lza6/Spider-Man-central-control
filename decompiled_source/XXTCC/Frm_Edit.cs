using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

[DesignerGenerated]
public class Frm_Edit : Form
{
	private IContainer icontainer_0;

	[field: AccessedThroughProperty("Button_OK")]
	internal virtual Button Button_OK
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Frm_Edit()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XXTCC.Frm_Edit));
		this.Button_OK = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.Button_OK.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.Button_OK.Location = new System.Drawing.Point(0, 477);
		this.Button_OK.Name = "Button_OK";
		this.Button_OK.Size = new System.Drawing.Size(283, 53);
		this.Button_OK.TabIndex = 2;
		this.Button_OK.Text = "OK";
		this.Button_OK.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(283, 530);
		base.Controls.Add(this.Button_OK);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Frm_Edit";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.TopMost = true;
		base.ResumeLayout(false);
	}
}
