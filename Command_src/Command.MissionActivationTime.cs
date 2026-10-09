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
public sealed class MissionActivationTime : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	public Mission TheMission;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("DateTimePicker1")]
	internal virtual DarkMaskedTextBox DateTimePicker1 { get; set; }

	[field: AccessedThroughProperty("DateTimePicker2")]
	internal virtual DarkMaskedTextBox DateTimePicker2 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

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
			EventHandler eventHandler = method_4;
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

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

	public MissionActivationTime()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosed += new FormClosedEventHandler(MissionActivationTime_FormClosed);
		((Form)this).Load += MissionActivationTime_Load;
		((Control)this).KeyDown += new KeyEventHandler(MissionActivationTime_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(MissionActivationTime_FormClosing);
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
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		DateTimePicker1 = new DarkMaskedTextBox();
		DateTimePicker2 = new DarkMaskedTextBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((TextBoxBase)DateTimePicker1).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker1).Location = new Point(198, 43);
		((Control)DateTimePicker1).Name = "DateTimePicker1";
		((Control)DateTimePicker1).Size = new Size(231, 23);
		((Control)DateTimePicker1).TabIndex = 2;
		((TextBoxBase)DateTimePicker2).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker2).Location = new Point(198, 67);
		((Control)DateTimePicker2).Name = "DateTimePicker2";
		((Control)DateTimePicker2).Size = new Size(231, 23);
		((Control)DateTimePicker2).TabIndex = 3;
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(13, 13);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(41, 13);
		((Control)Label2).TabIndex = 10;
		((Label)Label2).Text = "Label2";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(439, 42);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(86, 48);
		((Control)Button1).TabIndex = 11;
		Button1.Text = "SET";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 47);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(160, 13);
		((Control)Label1).TabIndex = 12;
		((Label)Label1).Text = "Start at this date and time (Zulu):";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(541, 99);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)DateTimePicker2);
		((Control)this).Controls.Add((Control)(object)DateTimePicker1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MissionActivationTime";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Mission Activation Time";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MissionActivationTime_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshMissions();
		}
		Mission.StartTimeChanged -= method_3;
	}

	private void method_2()
	{
		if (!TheMission.StartTime.HasValue)
		{
			if (!TheMission.IsActive)
			{
				((Label)Label2).Text = "Mission is not active.";
			}
			else
			{
				((Label)Label2).Text = "Mission is already active.";
			}
		}
		else if (TheMission.IsActive)
		{
			((Label)Label2).Text = "Mission is already active (Start time: " + TheMission.StartTime.Value.ToShortDateString() + " - " + TheMission.StartTime.Value.ToLongTimeString() + " Zulu)";
		}
		else
		{
			((Label)Label2).Text = "Mission is set to start at: " + TheMission.StartTime.Value.ToShortDateString() + " - " + TheMission.StartTime.Value.ToLongTimeString() + " Zulu";
		}
	}

	private void method_3(Mission mission_0)
	{
		if (mission_0 == TheMission)
		{
			method_2();
		}
	}

	private void MissionActivationTime_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		method_2();
		Mission.StartTimeChanged += method_3;
		((Control)DateTimePicker1).Enabled = true;
		((Control)DateTimePicker2).Enabled = true;
		if (TheMission.StartTime.HasValue)
		{
			DateTime theDate = TheMission.StartTime.Value;
			string theTimeString = default(string);
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			string theDateString = default(string);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DateTimePicker1).Text = theDateString;
			((MaskedTextBox)DateTimePicker2).Text = theTimeString;
		}
		else
		{
			DateTime theDate2 = Client.CurrentScenario.Time;
			string theTimeString2 = default(string);
			GameGeneral.PaddedTimeString(ref theDate2, ref theTimeString2);
			string theDateString2 = default(string);
			GameGeneral.PaddedDateString(ref theDate2, ref theDateString2, AddComma: false);
			((MaskedTextBox)DateTimePicker1).Text = theDateString2;
			((MaskedTextBox)DateTimePicker2).Text = theTimeString2;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		List<string> list = ((MaskedTextBox)DateTimePicker2).Text.Split(new char[1] { ':' }).ToList();
		if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
		{
			return;
		}
		List<string> list2 = ((MaskedTextBox)DateTimePicker1).Text.Split(new char[1] { '-' }).ToList();
		if (!(Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2])))
		{
			return;
		}
		TheMission.StartTime_Set(new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2])), Client.CurrentScenario);
		DateTime? startTime = TheMission.StartTime;
		DateTime time = Client.CurrentScenario.Time;
		if (((!startTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) > 0)) == true)
		{
			TheMission.set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
			if (!Information.IsNothing((object)Client.MissionEditorWindow))
			{
				Client.MissionEditorWindow.RefreshMissions();
			}
		}
	}

	private void MissionActivationTime_KeyDown(object sender, KeyEventArgs e)
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

	private void MissionActivationTime_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static MissionActivationTime()
	{
		Class72.smethod_20();
	}
}
