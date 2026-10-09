using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
public sealed class FlightPlanTime : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DateTimePicker_Date")]
	[CompilerGenerated]
	private DarkMaskedTextBox _DateTimePicker_Date;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_Time")]
	private DarkMaskedTextBox _DateTimePicker_Time;

	[AccessedThroughProperty("DateTimePicker_Hold")]
	[CompilerGenerated]
	private DarkMaskedTextBox _DateTimePicker_Hold;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_Spacing")]
	private DarkMaskedTextBox _DateTimePicker_Spacing;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_Station")]
	private DarkMaskedTextBox _DateTimePicker_Station;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_AttackMethod")]
	private DarkUIComboBox _ComboBox_AttackMethod;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_Separation")]
	private DarkMaskedTextBox _DateTimePicker_Separation;

	[CompilerGenerated]
	private bool bool_2;

	public Waypoint SelectedWaypoint;

	public Mission.Flight SelectedFlight;

	public Mission SelectedMission;

	public Mission.Flight.FlightElement FlightElement;

	public bool ViaFlightPlanEditor;

	private bool bool_3;

	internal virtual DarkMaskedTextBox DateTimePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Date;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = method_16;
			EventHandler eventHandler2 = method_17;
			KeyPressEventHandler val = new KeyPressEventHandler(method_20);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Date;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Date = value;
			darkMaskedTextBox = _DateTimePicker_Date;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Time;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = method_5;
			EventHandler eventHandler2 = method_6;
			KeyPressEventHandler val = new KeyPressEventHandler(method_21);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Time;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Time = value;
			darkMaskedTextBox = _DateTimePicker_Time;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_Hold
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Hold;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = method_7;
			EventHandler eventHandler2 = method_8;
			KeyPressEventHandler val = new KeyPressEventHandler(method_22);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Hold;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Hold = value;
			darkMaskedTextBox = _DateTimePicker_Hold;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_Spacing
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Spacing;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = method_11;
			EventHandler eventHandler2 = method_12;
			KeyPressEventHandler val = new KeyPressEventHandler(method_23);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Spacing;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Spacing = value;
			darkMaskedTextBox = _DateTimePicker_Spacing;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_Station
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Station;
		}
		[CompilerGenerated]
		set
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_9;
			EventHandler eventHandler2 = method_10;
			KeyPressEventHandler val = new KeyPressEventHandler(method_24);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Station;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Station = value;
			darkMaskedTextBox = _DateTimePicker_Station;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_AttackMethod
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_AttackMethod;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIComboBox darkUIComboBox = _ComboBox_AttackMethod;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_AttackMethod = value;
			darkUIComboBox = _ComboBox_AttackMethod;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_Separation
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_Separation;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_13;
			EventHandler eventHandler2 = method_14;
			KeyPressEventHandler val = new KeyPressEventHandler(method_25);
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_Separation;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).KeyPress -= val;
			}
			_DateTimePicker_Separation = value;
			darkMaskedTextBox = _DateTimePicker_Separation;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).KeyPress += val;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

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

	public FlightPlanTime()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += FlightPlanTime_Load;
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanTime_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanTime_FormClosing);
		RTMPEnabled = true;
		bool_3 = false;
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
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected O, but got Unknown
		Label7 = new DarkLabel();
		DateTimePicker_Separation = new DarkMaskedTextBox();
		Label6 = new DarkLabel();
		ComboBox_AttackMethod = new DarkUIComboBox();
		Label5 = new DarkLabel();
		DateTimePicker_Station = new DarkMaskedTextBox();
		Label4 = new DarkLabel();
		DateTimePicker_Spacing = new DarkMaskedTextBox();
		Label3 = new DarkLabel();
		DateTimePicker_Hold = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		DateTimePicker_Time = new DarkMaskedTextBox();
		DateTimePicker_Date = new DarkMaskedTextBox();
		((Control)this).SuspendLayout();
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(13, 172);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(107, 15);
		((Control)Label7).TabIndex = 22;
		((Label)Label7).Text = "Aircraft separation:";
		((TextBoxBase)DateTimePicker_Separation).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Separation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Separation).Location = new Point(198, 168);
		((Control)DateTimePicker_Separation).Name = "DateTimePicker_Separation";
		((Control)DateTimePicker_Separation).Size = new Size(115, 23);
		((Control)DateTimePicker_Separation).TabIndex = 21;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(323, 175);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(52, 15);
		((Control)Label6).TabIndex = 20;
		((Label)Label6).Text = "Method:";
		((ComboBox)ComboBox_AttackMethod).BackColor = Color.Transparent;
		((ComboBox)ComboBox_AttackMethod).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_AttackMethod).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_AttackMethod).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_AttackMethod).FormattingEnabled = true;
		((Control)ComboBox_AttackMethod).Location = new Point(381, 169);
		((Control)ComboBox_AttackMethod).Name = "ComboBox_AttackMethod";
		((Control)ComboBox_AttackMethod).Size = new Size(121, 21);
		((Control)ComboBox_AttackMethod).TabIndex = 19;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(13, 120);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(95, 15);
		((Control)Label5).TabIndex = 18;
		((Label)Label5).Text = "Station duration:";
		((TextBoxBase)DateTimePicker_Station).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Station).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Station).Location = new Point(198, 116);
		((Control)DateTimePicker_Station).Name = "DateTimePicker_Station";
		((Control)DateTimePicker_Station).Size = new Size(115, 23);
		((Control)DateTimePicker_Station).TabIndex = 17;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(13, 146);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(139, 15);
		((Control)Label4).TabIndex = 16;
		((Label)Label4).Text = "Spacing maneuver delay:";
		((TextBoxBase)DateTimePicker_Spacing).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Spacing).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Spacing).Location = new Point(198, 142);
		((Control)DateTimePicker_Spacing).Name = "DateTimePicker_Spacing";
		((Control)DateTimePicker_Spacing).Size = new Size(115, 23);
		((Control)DateTimePicker_Spacing).TabIndex = 15;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(13, 95);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(84, 15);
		((Control)Label3).TabIndex = 14;
		((Label)Label3).Text = "Hold duration:";
		((TextBoxBase)DateTimePicker_Hold).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Hold).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Hold).Location = new Point(198, 91);
		((Control)DateTimePicker_Hold).Name = "DateTimePicker_Hold";
		((Control)DateTimePicker_Hold).Size = new Size(115, 23);
		((Control)DateTimePicker_Hold).TabIndex = 13;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 37);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(119, 15);
		((Control)Label1).TabIndex = 12;
		((Label)Label1).Text = "Date and time (Zulu):";
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(13, 13);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(41, 13);
		((Control)Label2).TabIndex = 10;
		((Label)Label2).Text = "Label2";
		((TextBoxBase)DateTimePicker_Time).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Time).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Time).Location = new Point(198, 61);
		((Control)DateTimePicker_Time).Name = "DateTimePicker_Time";
		((Control)DateTimePicker_Time).Size = new Size(115, 23);
		((Control)DateTimePicker_Time).TabIndex = 3;
		((TextBoxBase)DateTimePicker_Date).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_Date).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DateTimePicker_Date).Location = new Point(198, 37);
		((Control)DateTimePicker_Date).Name = "DateTimePicker_Date";
		((Control)DateTimePicker_Date).Size = new Size(115, 23);
		((Control)DateTimePicker_Date).TabIndex = 2;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(541, 205);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Separation);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)ComboBox_AttackMethod);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Station);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Spacing);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Hold);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Time);
		((Control)this).Controls.Add((Control)(object)DateTimePicker_Date);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(557, 244);
		((Control)this).Name = "FlightPlanTime";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Waypoint Time";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2()
	{
		if (Information.IsNothing((object)SelectedFlight))
		{
			((Label)Label2).Text = "No flight selected!";
			((Form)Client.FlightPlanTimeWindow).Text = "Waypoint time for flight <NO FLIGHT OR WAYPOINT SELECTED>";
		}
		else if (!Information.IsNothing((object)SelectedWaypoint))
		{
			int num;
			if (SelectedWaypoint.Time_Zulu.HasValue)
			{
				if (SelectedFlight.get_IsActive((IList<ActiveUnit>)SelectedFlight.get_Item(SelectedMission, Client.CurrentScenario)))
				{
					((Label)Label2).Text = "Mission is already active (Start time: " + SelectedWaypoint.Time_Zulu.Value.ToShortDateString() + " - " + SelectedWaypoint.Time_Zulu.Value.ToLongTimeString() + " Zulu)";
					num = 7;
				}
				else
				{
					((Label)Label2).Text = "Mission is being planned.";
					num = 7;
				}
			}
			else
			{
				((Label)Label2).Text = "Mission has no waypoint times set.";
				num = 7;
			}
			string[] array = new string[num];
			array[0] = "Waypoint time for ";
			array[1] = SelectedFlight.Callsign;
			array[2] = ", waypoint ";
			array[3] = SelectedWaypoint.Description;
			array[4] = " (";
			array[5] = Waypoint.get_WaypointTypeString(SelectedWaypoint.Type);
			array[6] = ")";
			string text = string.Concat(array);
			((Form)this).Text = text;
		}
		else
		{
			((Label)Label2).Text = "No waypoint selected!";
			((Form)Client.FlightPlanTimeWindow).Text = "Waypoint time for flight <NO WAYPOINT SELECTED>";
		}
	}

	private void FlightPlanTime_Load(object sender, EventArgs e)
	{
		bool_3 = false;
		((Control)DateTimePicker_Date).Enabled = true;
		((Control)DateTimePicker_Time).Enabled = true;
		bool_3 = true;
	}

	public void RefreshStats(ref Mission theSelectedMission, ref Mission.Flight theSelectedFlight, ref Waypoint theSelectedWaypoint, Mission.Flight.FlightElement theFlightElement, bool SetDateTimeIfNeccessary)
	{
		try
		{
			if (SetDateTimeIfNeccessary && bool_3)
			{
				bool_3 = false;
				Mission mission_ = null;
				Mission.Flight flight_ = null;
				Waypoint waypoint_ = null;
				method_19(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_4: true);
			}
			if (!Information.IsNothing((object)theSelectedMission))
			{
				SelectedMission = theSelectedMission;
			}
			if (!Information.IsNothing((object)theSelectedFlight))
			{
				SelectedFlight = theSelectedFlight;
			}
			if (!Information.IsNothing((object)theSelectedWaypoint))
			{
				SelectedWaypoint = theSelectedWaypoint;
			}
			if (theFlightElement != Mission.Flight.FlightElement.None)
			{
				FlightElement = theFlightElement;
			}
			method_2();
			if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || Information.IsNothing((object)SelectedWaypoint))
			{
				return;
			}
			if (SelectedFlight.Type != Mission._FlightType.FlightplanTemplate)
			{
				if (SelectedWaypoint.Time_Zulu_Weapon.HasValue && SelectedWaypoint.Leg_Time_Weapon > 0f)
				{
					DateTime theDate = SelectedWaypoint.Time_Zulu_Weapon.Value;
					string theTimeString = default(string);
					GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
					string theDateString = default(string);
					GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
					((MaskedTextBox)DateTimePicker_Date).Text = theDateString;
					((MaskedTextBox)DateTimePicker_Time).Text = theTimeString;
				}
				else if (!SelectedWaypoint.Time_Zulu.HasValue)
				{
					DateTime theDate2 = Client.CurrentScenario.StartTime;
					string theTimeString2 = default(string);
					GameGeneral.PaddedTimeString(ref theDate2, ref theTimeString2);
					string theDateString2 = default(string);
					GameGeneral.PaddedDateString(ref theDate2, ref theDateString2, AddComma: false);
					((MaskedTextBox)DateTimePicker_Date).Text = theDateString2;
					((MaskedTextBox)DateTimePicker_Time).Text = theTimeString2;
				}
				else
				{
					DateTime theDate3 = SelectedWaypoint.Time_Zulu.Value;
					string theTimeString3 = default(string);
					GameGeneral.PaddedTimeString(ref theDate3, ref theTimeString3);
					string theDateString3 = default(string);
					GameGeneral.PaddedDateString(ref theDate3, ref theDateString3, AddComma: false);
					((MaskedTextBox)DateTimePicker_Date).Text = theDateString3;
					((MaskedTextBox)DateTimePicker_Time).Text = theTimeString3;
				}
			}
			else
			{
				DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
				((Control)DateTimePicker_Date).Enabled = false;
				dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
				((Control)DateTimePicker_Time).Enabled = false;
				string theTimeString4 = default(string);
				GameGeneral.PaddedTimeString(ref dateTime, ref theTimeString4);
				string theDateString4 = default(string);
				GameGeneral.PaddedDateString(ref dateTime, ref theDateString4, AddComma: false);
				((MaskedTextBox)DateTimePicker_Date).Text = theDateString4;
				((MaskedTextBox)DateTimePicker_Time).Text = theTimeString4;
			}
			if (SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
			{
				goto IL_02a0;
			}
			int year;
			int month;
			int day;
			int hour;
			int minute;
			int second;
			if (SelectedWaypoint.Type != Waypoint.WaypointType.Assemble)
			{
				if (SelectedWaypoint.Type != Waypoint.WaypointType.HoldEnd)
				{
					goto IL_02a0;
				}
				year = 2000;
				month = 1;
				day = 1;
				hour = 0;
				minute = 0;
				second = 1;
			}
			else
			{
				year = 2000;
				month = 1;
				day = 1;
				hour = 0;
				minute = 0;
				second = 1;
			}
			DateTime dateTime2 = new DateTime(year, month, day, hour, minute, second);
			((Control)DateTimePicker_Hold).Enabled = true;
			dateTime2 = dateTime2.AddSeconds(SelectedWaypoint.Hold_Time - 1f);
			string theTimeString5 = default(string);
			GameGeneral.PaddedTimeString(ref dateTime2, ref theTimeString5);
			((MaskedTextBox)DateTimePicker_Hold).Text = theTimeString5;
			goto IL_02d3;
			IL_02d3:
			if (SelectedWaypoint.Type == Waypoint.WaypointType.StationEnd)
			{
				DateTime dateTime3 = new DateTime(2000, 1, 1, 0, 0, 1);
				((Control)DateTimePicker_Station).Enabled = true;
				dateTime3 = dateTime3.AddSeconds(SelectedWaypoint.Station_Time - 1f);
				string theTimeString6 = default(string);
				GameGeneral.PaddedTimeString(ref dateTime3, ref theTimeString6);
				((MaskedTextBox)DateTimePicker_Station).Text = theTimeString6;
			}
			else
			{
				DateTime theDate4 = new DateTime(2000, 1, 1, 0, 0, 0);
				((Control)DateTimePicker_Station).Enabled = false;
				string theTimeString7 = default(string);
				GameGeneral.PaddedTimeString(ref theDate4, ref theTimeString7);
				((MaskedTextBox)DateTimePicker_Station).Text = theTimeString7;
			}
			if (SelectedFlight.Type != Mission._FlightType.FlightplanTemplate && !SelectedWaypoint.IsStationWaypoint() && SelectedWaypoint.Type != Waypoint.WaypointType.TakeOff && SelectedWaypoint.Type != Waypoint.WaypointType.Land && SelectedWaypoint.Type != Waypoint.WaypointType.LandingMarshal && !SelectedWaypoint.IsHoldOrAssembleWaypoint())
			{
				DateTime dateTime4 = new DateTime(2000, 1, 1, 0, 0, 1);
				if (!method_3())
				{
					((ComboBox)ComboBox_AttackMethod).DataSource = null;
					((ComboBox)ComboBox_AttackMethod).Items.Clear();
					((Control)ComboBox_AttackMethod).Enabled = false;
				}
				else
				{
					DataTable theComboBoxDataSource = new DataTable();
					DarkUIComboBox combobox = ComboBox_AttackMethod;
					MissionEditor.BindComboBox_AttackMethod(ref combobox, ref theComboBoxDataSource, SelectedWaypoint.AttackMethod);
					ComboBox_AttackMethod = combobox;
					((Control)ComboBox_AttackMethod).Enabled = true;
				}
				if (method_4())
				{
					((Control)DateTimePicker_Separation).Enabled = true;
					DateTime theDate5 = dateTime4.AddSeconds(SelectedWaypoint.Separation_Time - 1f);
					string theTimeString8 = default(string);
					GameGeneral.PaddedTimeString(ref theDate5, ref theTimeString8);
					((MaskedTextBox)DateTimePicker_Separation).Text = theTimeString8;
				}
				else
				{
					DateTime theDate6 = new DateTime(2000, 1, 1, 0, 0, 0);
					((Control)DateTimePicker_Separation).Enabled = false;
					string theTimeString9 = default(string);
					GameGeneral.PaddedTimeString(ref theDate6, ref theTimeString9);
					((MaskedTextBox)DateTimePicker_Separation).Text = theTimeString9;
				}
				((Control)DateTimePicker_Spacing).Enabled = true;
				DateTime theDate7 = dateTime4.AddSeconds(SelectedWaypoint.SpacingManeuver_Time - 1f);
				string theTimeString10 = default(string);
				GameGeneral.PaddedTimeString(ref theDate7, ref theTimeString10);
				((MaskedTextBox)DateTimePicker_Spacing).Text = theTimeString10;
			}
			else
			{
				((Control)DateTimePicker_Spacing).Enabled = false;
				((Control)DateTimePicker_Separation).Enabled = false;
				((ComboBox)ComboBox_AttackMethod).DataSource = null;
				((ComboBox)ComboBox_AttackMethod).Items.Clear();
				((Control)ComboBox_AttackMethod).Enabled = false;
				DateTime theDate8 = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(SelectedWaypoint.SpacingManeuver_Time);
				string theTimeString11 = default(string);
				GameGeneral.PaddedTimeString(ref theDate8, ref theTimeString11);
				((MaskedTextBox)DateTimePicker_Spacing).Text = theTimeString11;
				theDate8 = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(SelectedWaypoint.Separation_Time);
				theTimeString11 = "";
				GameGeneral.PaddedTimeString(ref theDate8, ref theTimeString11);
				((MaskedTextBox)DateTimePicker_Separation).Text = theTimeString11;
			}
			return;
			IL_02a0:
			DateTime theDate9 = new DateTime(2000, 1, 1, 0, 0, 0);
			((Control)DateTimePicker_Hold).Enabled = false;
			string theTimeString12 = default(string);
			GameGeneral.PaddedTimeString(ref theDate9, ref theTimeString12);
			((MaskedTextBox)DateTimePicker_Hold).Text = theTimeString12;
			goto IL_02d3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101344", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_3()
	{
		bool result;
		try
		{
			int num;
			if (Information.IsNothing((object)SelectedWaypoint))
			{
				result = false;
			}
			else
			{
				if (SelectedWaypoint.Type == Waypoint.WaypointType.Target && !SelectedWaypoint.HasWingmanWaypoints() && !SelectedWaypoint.IsSplitWaypoint())
				{
					if (!Information.IsNothing((object)SelectedFlight))
					{
						if (SelectedFlight.FlightPlan.Count() <= 0)
						{
							num = 1;
							goto IL_015d;
						}
						Waypoint[] flightPlan = SelectedFlight.FlightPlan;
						int num2 = 0;
						while (num2 < flightPlan.Length)
						{
							Waypoint waypoint = flightPlan[num2];
							if (waypoint != SelectedWaypoint)
							{
								if (Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != SelectedWaypoint)
								{
									if (Information.IsNothing((object)waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != SelectedWaypoint)
									{
										if (Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != SelectedWaypoint)
										{
											if (Information.IsNothing((object)waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != SelectedWaypoint)
											{
												if (Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) || waypoint.Waypoint_ThirdElementWingman != SelectedWaypoint)
												{
													num2 = checked(num2 + 1);
													continue;
												}
												result = false;
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
							else
							{
								result = true;
							}
							goto end_IL_0001;
						}
					}
					num = 1;
					goto IL_015d;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_015d:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_4()
	{
		bool result;
		try
		{
			if (SelectedWaypoint.Type != Waypoint.WaypointType.Target && SelectedWaypoint.Type != Waypoint.WaypointType.WeaponTarget)
			{
				result = false;
			}
			else if (!SelectedWaypoint.HasWingmanWaypoints() && SelectedWaypoint.AttackMethod != Mission._AttackMethod.EchelonAtActionPoint && SelectedWaypoint.AttackMethod != Mission._AttackMethod.SplitAtActionPoint)
			{
				result = false;
			}
			else
			{
				int num2;
				if (!Information.IsNothing((object)SelectedFlight) && SelectedFlight.FlightPlan.Count() > 0)
				{
					Waypoint[] flightPlan = SelectedFlight.FlightPlan;
					int num = 0;
					while (true)
					{
						if (num >= flightPlan.Length)
						{
							num2 = 1;
							break;
						}
						Waypoint waypoint = flightPlan[num];
						if (Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != SelectedWaypoint)
						{
							if (Information.IsNothing((object)waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != SelectedWaypoint)
							{
								if (Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != SelectedWaypoint)
								{
									if (Information.IsNothing((object)waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != SelectedWaypoint)
									{
										if (Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) || waypoint.Waypoint_ThirdElementWingman != SelectedWaypoint)
										{
											num = checked(num + 1);
											continue;
										}
										result = false;
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
							else
							{
								result = false;
							}
						}
						else
						{
							result = false;
						}
						goto end_IL_0001;
					}
				}
				else
				{
					num2 = 1;
				}
				result = (byte)num2 != 0;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_5(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_6(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_7(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_8(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_9(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_10(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_11(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_12(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_13(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_14(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_15()
	{
		if (bool_3)
		{
			bool_3 = false;
			Mission mission_ = null;
			Mission.Flight flight_ = null;
			Waypoint waypoint_ = null;
			method_19(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_4: false);
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_17(object sender, EventArgs e)
	{
		method_18();
	}

	private void method_18()
	{
		if (bool_3)
		{
			bool_3 = false;
			Mission mission_ = null;
			Mission.Flight flight_ = null;
			Waypoint waypoint_ = null;
			method_19(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_4: false);
		}
	}

	private void method_19(ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, Mission.Flight.FlightElement flightElement_0, bool bool_4)
	{
		try
		{
			if (!Information.IsNothing((object)mission_0))
			{
				SelectedMission = mission_0;
			}
			if (!Information.IsNothing((object)flight_0))
			{
				SelectedFlight = flight_0;
			}
			if (!Information.IsNothing((object)waypoint_0))
			{
				SelectedWaypoint = waypoint_0;
			}
			if (flightElement_0 != Mission.Flight.FlightElement.None)
			{
				FlightElement = flightElement_0;
			}
			List<string> list = ((MaskedTextBox)DateTimePicker_Time).Text.Split(new char[1] { ':' }).ToList();
			if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
			{
				return;
			}
			List<string> list2 = ((MaskedTextBox)DateTimePicker_Date).Text.Split(new char[1] { '-' }).ToList();
			if (!(Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2])))
			{
				return;
			}
			DateTime dateTime = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
			List<string> list3 = ((MaskedTextBox)DateTimePicker_Hold).Text.Split(new char[1] { ':' }).ToList();
			if (!(Versioned.IsNumeric((object)list3[0]) & Versioned.IsNumeric((object)list3[1]) & Versioned.IsNumeric((object)list3[2])))
			{
				return;
			}
			float holdSeconds = (float)new TimeSpan(Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2])).TotalSeconds;
			List<string> list4 = ((MaskedTextBox)DateTimePicker_Station).Text.Split(new char[1] { ':' }).ToList();
			if (!(Versioned.IsNumeric((object)list4[0]) & Versioned.IsNumeric((object)list4[1]) & Versioned.IsNumeric((object)list4[2])))
			{
				return;
			}
			float stationSeconds = (float)new TimeSpan(Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2])).TotalSeconds;
			List<string> list5 = ((MaskedTextBox)DateTimePicker_Spacing).Text.Split(new char[1] { ':' }).ToList();
			if (!(Versioned.IsNumeric((object)list5[0]) & Versioned.IsNumeric((object)list5[1]) & Versioned.IsNumeric((object)list5[2])))
			{
				return;
			}
			float spacingSeconds = (float)new TimeSpan(Conversions.ToInteger(list5[0]), Conversions.ToInteger(list5[1]), Conversions.ToInteger(list5[2])).TotalSeconds;
			List<string> list6 = ((MaskedTextBox)DateTimePicker_Separation).Text.Split(new char[1] { ':' }).ToList();
			if (!(Versioned.IsNumeric((object)list6[0]) & Versioned.IsNumeric((object)list6[1]) & Versioned.IsNumeric((object)list6[2])))
			{
				return;
			}
			float separationSeconds = (float)new TimeSpan(Conversions.ToInteger(list6[0]), Conversions.ToInteger(list6[1]), Conversions.ToInteger(list6[2])).TotalSeconds;
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendChangeFlightPlanWaypointTime(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, FlightElement, SelectedWaypoint, dateTime, holdSeconds, stationSeconds, spacingSeconds, separationSeconds);
				return;
			}
			CoreClientCode.ChangeFlightPlanWaypointTime_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, FlightElement, SelectedWaypoint, dateTime, holdSeconds, stationSeconds, spacingSeconds, separationSeconds, bool_4);
			AMP_General.RefreshFlightPlanErrorWindow();
			if (((Control)Client.FlightPlanEditorWindow).Visible)
			{
				if (((BaseCollection)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).SelectedRows).Count > 0)
				{
					Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
					Client.FlightPlanEditorWindow.SelectedRow = ((DataGridViewBand)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index;
					Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[Client.FlightPlanEditorWindow.SelectedRow]).Tag;
					((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
					Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
				}
				Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
				Client.FlightPlanEditorWindow.RefreshGrid();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			Mission theSelectedMission = null;
			Mission.Flight theSelectedFlight = null;
			Waypoint theSelectedWaypoint = null;
			RefreshStats(ref theSelectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Mission.Flight.FlightElement.None, SetDateTimeIfNeccessary: true);
			Client.MustRefreshMainForm = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101345", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_21(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_22(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_23(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_24(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_25(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void FlightPlanTime_KeyDown(object sender, KeyEventArgs e)
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

	private void FlightPlanTime_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		if (((Control)DateTimePicker_Date).Focused)
		{
			method_18();
		}
		if (((Control)DateTimePicker_Time).Focused)
		{
			method_15();
		}
		if (((Control)DateTimePicker_Hold).Focused)
		{
			method_15();
		}
		if (((Control)DateTimePicker_Spacing).Focused)
		{
			method_15();
		}
		if (((Control)DateTimePicker_Separation).Focused)
		{
			method_15();
		}
		((Control)Label2).Select();
		((Control)this).Hide();
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshMissions();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_26(object sender, EventArgs e)
	{
		DarkUIComboBox comboBox_AttackMethod = ComboBox_AttackMethod;
		int theSelectedIndex = ((ComboBox)comboBox_AttackMethod).SelectedIndex;
		Mission._AttackMethod theAttackMethod = default(Mission._AttackMethod);
		Mission.Flight.Combobox_AttackMethod(ref theSelectedIndex, ref theAttackMethod);
		((ComboBox)comboBox_AttackMethod).SelectedIndex = theSelectedIndex;
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightPlanWaypointAttackMethod(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, SelectedWaypoint, (int)theAttackMethod);
			return;
		}
		CoreClientCode.ChangeFlightPlanWaypointAttackMethod_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, SelectedWaypoint, theAttackMethod);
		AMP_General.RefreshFlightPlanErrorWindow();
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			if (((BaseCollection)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).SelectedRows).Count > 0)
			{
				Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
				Client.FlightPlanEditorWindow.SelectedRow = ((DataGridViewBand)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index;
				Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[Client.FlightPlanEditorWindow.SelectedRow]).Tag;
				((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
				Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
			}
			Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
			Client.FlightPlanEditorWindow.RefreshGrid();
			Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		Mission theSelectedMission = null;
		Mission.Flight theSelectedFlight = null;
		Waypoint theSelectedWaypoint = null;
		RefreshStats(ref theSelectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Mission.Flight.FlightElement.None, SetDateTimeIfNeccessary: true);
		Client.MustRefreshMainForm = true;
	}

	static FlightPlanTime()
	{
		Class72.smethod_20();
	}
}
