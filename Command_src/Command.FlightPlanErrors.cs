using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanErrors : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	private bool bool_2;

	public const int SW_SHOWNA = 8;

	[field: AccessedThroughProperty("DarkTextBox1")]
	internal virtual DarkTextBox DarkTextBox1 { get; set; }

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public FlightPlanErrors()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanErrors_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(FlightPlanErrors_FormClosed);
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanErrors_KeyDown);
		((Form)this).Shown += FlightPlanErrors_Shown;
		((Form)this).Load += FlightPlanErrors_Load;
		RTMPEnabled = true;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		DarkTextBox1 = new DarkTextBox();
		((Control)this).SuspendLayout();
		((TextBoxBase)DarkTextBox1).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)DarkTextBox1).BorderStyle = (BorderStyle)1;
		((Control)DarkTextBox1).Dock = (DockStyle)5;
		((TextBoxBase)DarkTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkTextBox1).Location = new Point(0, 0);
		((TextBox)DarkTextBox1).Multiline = true;
		((Control)DarkTextBox1).Name = "DarkTextBox1";
		((Control)DarkTextBox1).Size = new Size(1312, 558);
		((Control)DarkTextBox1).TabIndex = 0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1312, 558);
		((Control)this).Controls.Add((Control)(object)DarkTextBox1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "FlightPlanErrors";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Flightplan Errors";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void FlightPlanErrors_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FlightPlanErrors_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void FlightPlanErrors_KeyDown(object sender, KeyEventArgs e)
	{
		MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void FlightPlanErrors_Shown(object sender, EventArgs e)
	{
	}

	private void FlightPlanErrors_Load(object sender, EventArgs e)
	{
	}

	public void RefreshForm()
	{
		((TextBoxBase)DarkTextBox1).Clear();
		((TextBox)DarkTextBox1).Text = Client.CurrentScenario.GetConcatenated_MDSP_Errors("", "");
		((Control)Client.FlightPlanErrorsWindow).Invalidate();
	}

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int ShowWindow(IntPtr handle, int nCmdShow);

	static FlightPlanErrors()
	{
		Class72.smethod_20();
	}
}
