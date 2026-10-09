using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TimeToReadyWindow : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	public List<ActiveUnit> SelectedUnits;

	[field: AccessedThroughProperty("MaskedTextBox1")]
	internal virtual DarkMaskedTextBox MaskedTextBox1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public TimeToReadyWindow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += TimeToReadyWindow_Shown;
		((Control)this).KeyDown += new KeyEventHandler(TimeToReadyWindow_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(TimeToReadyWindow_FormClosing);
		((Form)this).Load += TimeToReadyWindow_Load;
		SelectedUnits = new List<ActiveUnit>();
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
		MaskedTextBox1 = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Button1 = new DarkUIButton();
		((Control)this).SuspendLayout();
		((TextBoxBase)MaskedTextBox1).BorderStyle = (BorderStyle)1;
		((TextBoxBase)MaskedTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MaskedTextBox1).Location = new Point(105, 6);
		((MaskedTextBox)MaskedTextBox1).Mask = "00:00:00";
		((Control)MaskedTextBox1).Name = "MaskedTextBox1";
		((Control)MaskedTextBox1).Size = new Size(86, 23);
		((Control)MaskedTextBox1).TabIndex = 0;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 9);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(96, 15);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Days:Hours:Mins";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(197, 6);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(81, 23);
		((Control)Button1).TabIndex = 2;
		Button1.Text = "OK";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(284, 31);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)MaskedTextBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "TimeToReadyWindow";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Time To Ready";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TimeToReadyWindow_Shown(object sender, EventArgs e)
	{
		if (SelectedUnits.Count == 0)
		{
			((Form)this).Close();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		List<string> list = ((MaskedTextBox)MaskedTextBox1).Text.Replace(".", ":").Split(Conversions.ToCharArrayRankOne(":")).ToList();
		if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
		{
			return;
		}
		TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]), 0);
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			if (!selectedUnit.IsAircraft)
			{
				selectedUnit.DockingOps.ConditionTimer = (float)timeSpan.TotalSeconds;
				continue;
			}
			((Aircraft_AirOps)selectedUnit.AirOps).ConditionTimer = (float)timeSpan.TotalSeconds;
			if (((Aircraft_AirOps)selectedUnit.AirOps).ConditionTimer > 0f)
			{
				if (((Aircraft_AirOps)selectedUnit.AirOps).Condition == Aircraft_AirOps._AirOpsCondition.Parked)
				{
					((Aircraft_AirOps)selectedUnit.AirOps).Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
			}
			else if (((Aircraft_AirOps)selectedUnit.AirOps).Condition == Aircraft_AirOps._AirOpsCondition.Readying)
			{
				((Aircraft_AirOps)selectedUnit.AirOps).Condition = Aircraft_AirOps._AirOpsCondition.Parked;
			}
		}
		if (!Information.IsNothing((object)MyProject.Forms.AirOps) && ((Control)MyProject.Forms.AirOps).Visible)
		{
			MyProject.Forms.AirOps.RefreshAll();
		}
		if (!Information.IsNothing((object)MyProject.Forms.DockingOps) && ((Control)MyProject.Forms.DockingOps).Visible)
		{
			MyProject.Forms.DockingOps.RefreshAll();
		}
		((Form)this).Close();
	}

	private void TimeToReadyWindow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void TimeToReadyWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void TimeToReadyWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static TimeToReadyWindow()
	{
		Class72.smethod_20();
	}
}
