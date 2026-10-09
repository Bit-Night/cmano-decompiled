using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using CommandNetcode.RT;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditor : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__300-0
	{
		public Mission.Flight $VB$Local_theFlight;

		public _Closure$__300-0(_Closure$__300-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFlight = arg0.$VB$Local_theFlight;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theAU)
		{
			int result;
			if (!theAU.Navigator.HasFlight)
			{
				result = 0;
			}
			else if (!theAU.IsAircraft)
			{
				result = 0;
			}
			else
			{
				if (!theAU.IsOperating())
				{
					return theAU.Navigator.get_Flight(HierarchySearch: true) == $VB$Local_theFlight;
				}
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__300-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl_Aircraft")]
	private DarkUITabControl _TabControl_Aircraft;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_CurrentPackage")]
	private DarkUIComboBox _Combo_CurrentPackage;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_CurrentFlightPlan")]
	private DarkUIComboBox _Combo_CurrentFlightPlan;

	[AccessedThroughProperty("Combo_FlightTask")]
	[CompilerGenerated]
	private DarkUIComboBox _Combo_FlightTask;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_FlightCallsign")]
	private DarkUITextBox _TextBox_FlightCallsign;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_FlightplanType")]
	private DarkUIComboBox _Combo_FlightplanType;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CopyFlightplan")]
	private DarkButton _Button_CopyFlightplan;

	[AccessedThroughProperty("Button_FillEmptySlots")]
	[CompilerGenerated]
	private DarkButton _Button_FillEmptySlots;

	[AccessedThroughProperty("Button_ClearSlots")]
	[CompilerGenerated]
	private DarkButton _Button_ClearSlots;

	[AccessedThroughProperty("Button_ChangeAircraftType")]
	[CompilerGenerated]
	private DarkButton _Button_ChangeAircraftType;

	[AccessedThroughProperty("Button_CreateFlightplanSkeleton")]
	[CompilerGenerated]
	private DarkButton _Button_CreateFlightplanSkeleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteFlightplan")]
	private DarkButton _Button_DeleteFlightplan;

	[AccessedThroughProperty("Label15")]
	[CompilerGenerated]
	private DarkLabel YulHmblfayP;

	[AccessedThroughProperty("Button_ChangeTakeOffTime")]
	[CompilerGenerated]
	private DarkButton _Button_ChangeTakeOffTime;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeObjectiveTime")]
	private DarkButton _Button_ChangeObjectiveTime;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeTakeOffLocation")]
	private DarkButton _Button_ChangeTakeOffLocation;

	[AccessedThroughProperty("Button_ChangeLandingLocation")]
	[CompilerGenerated]
	private DarkButton _Button_ChangeLandingLocation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeDiversionLocation")]
	private DarkButton _Button_ChangeDiversionLocation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CreateFlightplanFull")]
	private DarkButton _Button_CreateFlightplanFull;

	[CompilerGenerated]
	[AccessedThroughProperty("lblFPInUse")]
	private DarkLabel darkLabel_0;

	[CompilerGenerated]
	private bool bool_2;

	public bool WaypointList_Refresh;

	public Mission SelectedMission;

	private Mission.Flight flight_0;

	private List<ActiveUnit> list_0;

	private ActiveUnit activeUnit_0;

	public static List<ReferencePoint> SelectedRPWithLinkedFPInfoList;

	[CompilerGenerated]
	private static bool bool_3;

	private Waypoint waypoint_0;

	public int SelectedRow;

	private bool bool_4;

	public FlightPlanWaypoints theFlightPlanWaypoints;

	private List<TabPage> list_1;

	private List<FlightPlanWaypoints> list_2;

	private List<DataTable> list_3;

	private DataTable dataTable_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	private int int_23;

	private int int_24;

	private int int_25;

	private int int_26;

	private int int_27;

	private int int_28;

	private DataTable dataTable_1;

	private DataTable dataTable_2;

	private DataTable dataTable_3;

	private DataTable dataTable_4;

	private DataTable dataTable_5;

	private DataTable dataTable_6;

	public Bitmap theImageLocked;

	public Bitmap theImageUnlocked;

	public Bitmap theImageNotConfigured;

	public Bitmap theImageNotLockable;

	public Bitmap theImageRelative;

	private bool bool_5;

	[CompilerGenerated]
	private Size size_0;

	internal virtual DarkUITabControl TabControl_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return _TabControl_Aircraft;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUITabControl darkUITabControl = _TabControl_Aircraft;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl_Aircraft = value;
			darkUITabControl = _TabControl_Aircraft;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_CurrentPackage
	{
		[CompilerGenerated]
		get
		{
			return _Combo_CurrentPackage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIComboBox darkUIComboBox = _Combo_CurrentPackage;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_CurrentPackage = value;
			darkUIComboBox = _Combo_CurrentPackage;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_CurrentFlightPlan
	{
		[CompilerGenerated]
		get
		{
			return _Combo_CurrentFlightPlan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIComboBox darkUIComboBox = _Combo_CurrentFlightPlan;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_CurrentFlightPlan = value;
			darkUIComboBox = _Combo_CurrentFlightPlan;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_FlightTask
	{
		[CompilerGenerated]
		get
		{
			return _Combo_FlightTask;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIComboBox darkUIComboBox = _Combo_FlightTask;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_FlightTask = value;
			darkUIComboBox = _Combo_FlightTask;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TextBox_FlightCallsign
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_FlightCallsign;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyPressEventHandler val = new KeyPressEventHandler(method_18);
			EventHandler eventHandler = method_19;
			EventHandler eventHandler2 = method_20;
			DarkUITextBox.TextChangedEventHandler value2 = method_32;
			DarkUITextBox darkUITextBox = _TextBox_FlightCallsign;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).KeyPress -= val;
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
				darkUITextBox.TextChanged -= value2;
			}
			_TextBox_FlightCallsign = value;
			darkUITextBox = _TextBox_FlightCallsign;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).KeyPress += val;
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_FlightplanType
	{
		[CompilerGenerated]
		get
		{
			return _Combo_FlightplanType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIComboBox darkUIComboBox = _Combo_FlightplanType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_FlightplanType = value;
			darkUIComboBox = _Combo_FlightplanType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual DarkButton Button_CopyFlightplan
	{
		[CompilerGenerated]
		get
		{
			return _Button_CopyFlightplan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkButton darkButton = _Button_CopyFlightplan;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_CopyFlightplan = value;
			darkButton = _Button_CopyFlightplan;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_LaunchDateAndTime")]
	internal virtual DarkLabel Label_LaunchDateAndTime { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkButton Button_FillEmptySlots
	{
		[CompilerGenerated]
		get
		{
			return _Button_FillEmptySlots;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkButton darkButton = _Button_FillEmptySlots;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_FillEmptySlots = value;
			darkButton = _Button_FillEmptySlots;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ClearSlots
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearSlots;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkButton darkButton = _Button_ClearSlots;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ClearSlots = value;
			darkButton = _Button_ClearSlots;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AircraftType")]
	internal virtual DarkLabel Label_AircraftType { get; set; }

	[field: AccessedThroughProperty("Label_LoadoutName")]
	internal virtual DarkLabel Label_LoadoutName { get; set; }

	internal virtual DarkButton Button_ChangeAircraftType
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeAircraftType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkButton darkButton = _Button_ChangeAircraftType;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeAircraftType = value;
			darkButton = _Button_ChangeAircraftType;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label_ObjectiveDateAndTime")]
	internal virtual DarkLabel Label_ObjectiveDateAndTime { get; set; }

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	[field: AccessedThroughProperty("Label_FlightStatus")]
	internal virtual DarkLabel Label_FlightStatus { get; set; }

	internal virtual DarkButton Button_CreateFlightplanSkeleton
	{
		[CompilerGenerated]
		get
		{
			return _Button_CreateFlightplanSkeleton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkButton darkButton = _Button_CreateFlightplanSkeleton;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_CreateFlightplanSkeleton = value;
			darkButton = _Button_CreateFlightplanSkeleton;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_DeleteFlightplan
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeleteFlightplan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkButton darkButton = _Button_DeleteFlightplan;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_DeleteFlightplan = value;
			darkButton = _Button_DeleteFlightplan;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_SelectedFlight")]
	internal virtual DarkGroupBox GroupBox_SelectedFlight { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("Label1_LandingLocation")]
	internal virtual DarkLabel Label1_LandingLocation { get; set; }

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

	[field: AccessedThroughProperty("Label_TakeOffLocation")]
	internal virtual DarkLabel Label_TakeOffLocation { get; set; }

	internal virtual DarkLabel Label15
	{
		[CompilerGenerated]
		get
		{
			return YulHmblfayP;
		}
		[CompilerGenerated]
		set
		{
			YulHmblfayP = value;
		}
	}

	[field: AccessedThroughProperty("Label_DiversionAirfield")]
	internal virtual DarkLabel Label_DiversionAirfield { get; set; }

	internal virtual DarkButton Button_ChangeTakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeTakeOffTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkButton darkButton = _Button_ChangeTakeOffTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeTakeOffTime = value;
			darkButton = _Button_ChangeTakeOffTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ChangeObjectiveTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeObjectiveTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkButton darkButton = _Button_ChangeObjectiveTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeObjectiveTime = value;
			darkButton = _Button_ChangeObjectiveTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ChangeTakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeTakeOffLocation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkButton darkButton = _Button_ChangeTakeOffLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeTakeOffLocation = value;
			darkButton = _Button_ChangeTakeOffLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ChangeLandingLocation
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeLandingLocation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkButton darkButton = _Button_ChangeLandingLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeLandingLocation = value;
			darkButton = _Button_ChangeLandingLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ChangeDiversionLocation
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeDiversionLocation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkButton darkButton = _Button_ChangeDiversionLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ChangeDiversionLocation = value;
			darkButton = _Button_ChangeDiversionLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_CreateFlightplanFull
	{
		[CompilerGenerated]
		get
		{
			return _Button_CreateFlightplanFull;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkButton darkButton = _Button_CreateFlightplanFull;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_CreateFlightplanFull = value;
			darkButton = _Button_CreateFlightplanFull;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblWeaponUsed")]
	internal virtual DarkLabel lblWeaponUsed { get; set; }

	[field: AccessedThroughProperty("lblActualWeaponUsage")]
	internal virtual DarkLabel lblActualWeaponUsage { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkLabel lblFPInUse
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_0;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_0 = value;
		}
	}

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

	public ActiveUnit SelectedAircraft
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			activeUnit_0 = value;
		}
	}

	public Mission.Flight SelectedFlight
	{
		get
		{
			return flight_0;
		}
		set
		{
			if (bool_3)
			{
				flight_0 = value;
			}
			else if (flight_0 != value && !method_4())
			{
				flight_0 = value;
			}
		}
	}

	public static bool DoNotNotifyFlightError
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public Waypoint SelectedWaypoint
	{
		get
		{
			return waypoint_0;
		}
		set
		{
			waypoint_0 = value;
		}
	}

	public Size theDefaultSize
	{
		[CompilerGenerated]
		get
		{
			return size_0;
		}
		[CompilerGenerated]
		set
		{
			size_0 = value;
		}
	}

	static FlightPlanEditor()
	{
		Class72.smethod_20();
		SelectedRPWithLinkedFPInfoList = new List<ReferencePoint>();
		DoNotNotifyFlightError = false;
	}

	public FlightPlanEditor()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanEditor_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(FlightPlanEditor_FormClosed);
		((Form)this).Load += FlightPlanEditor_Load;
		((Control)this).VisibleChanged += FlightPlanEditor_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanEditor_KeyDown);
		RTMPEnabled = true;
		WaypointList_Refresh = true;
		SelectedRow = 0;
		bool_4 = false;
		list_1 = new List<TabPage>();
		list_2 = new List<FlightPlanWaypoints>();
		list_3 = new List<DataTable>();
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
		dataTable_2 = new DataTable();
		dataTable_3 = new DataTable();
		dataTable_4 = new DataTable();
		dataTable_5 = new DataTable();
		dataTable_6 = new DataTable();
		theImageLocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		theImageUnlocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		theImageNotConfigured = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		theImageNotLockable = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		theImageRelative = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
		theDefaultSize = new Size(585, 358);
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
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1131: Unknown result type (might be due to invalid IL or missing references)
		//IL_113b: Expected O, but got Unknown
		//IL_157f: Unknown result type (might be due to invalid IL or missing references)
		//IL_160d: Unknown result type (might be due to invalid IL or missing references)
		//IL_169b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1729: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_184e: Unknown result type (might be due to invalid IL or missing references)
		TabControl_Aircraft = new DarkUITabControl();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Combo_CurrentPackage = new DarkUIComboBox();
		Combo_CurrentFlightPlan = new DarkUIComboBox();
		Combo_FlightTask = new DarkUIComboBox();
		TextBox_FlightCallsign = new DarkUITextBox();
		Button_CopyFlightplan = new DarkButton();
		Label_LaunchDateAndTime = new DarkLabel();
		Label6 = new DarkLabel();
		Label7 = new DarkLabel();
		Label5 = new DarkLabel();
		Button_FillEmptySlots = new DarkButton();
		Button_ClearSlots = new DarkButton();
		Label_AircraftType = new DarkLabel();
		Label_LoadoutName = new DarkLabel();
		Button_ChangeAircraftType = new DarkButton();
		Label8 = new DarkLabel();
		Label_ObjectiveDateAndTime = new DarkLabel();
		Label10 = new DarkLabel();
		Label_FlightStatus = new DarkLabel();
		Button_CreateFlightplanSkeleton = new DarkButton();
		Button_DeleteFlightplan = new DarkButton();
		GroupBox_SelectedFlight = new DarkGroupBox();
		Combo_FlightplanType = new DarkUIComboBox();
		Label9 = new DarkLabel();
		Label11 = new DarkLabel();
		Label1_LandingLocation = new DarkLabel();
		Label13 = new DarkLabel();
		Label_TakeOffLocation = new DarkLabel();
		Label15 = new DarkLabel();
		Label_DiversionAirfield = new DarkLabel();
		Button_ChangeTakeOffTime = new DarkButton();
		Button_ChangeObjectiveTime = new DarkButton();
		Button_ChangeTakeOffLocation = new DarkButton();
		Button_ChangeLandingLocation = new DarkButton();
		Button_ChangeDiversionLocation = new DarkButton();
		Button_CreateFlightplanFull = new DarkButton();
		lblWeaponUsed = new DarkLabel();
		lblActualWeaponUsage = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		lblFPInUse = new DarkLabel();
		((Control)GroupBox_SelectedFlight).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabControl_Aircraft).Anchor = (AnchorStyles)15;
		((Control)TabControl_Aircraft).Cursor = Cursors.Hand;
		((TabControl)TabControl_Aircraft).ItemSize = new Size(80, 20);
		((Control)TabControl_Aircraft).Location = new Point(0, 365);
		((Control)TabControl_Aircraft).Name = "TabControl_Aircraft";
		((TabControl)TabControl_Aircraft).SelectedIndex = 0;
		((Control)TabControl_Aircraft).Size = new Size(1479, 309);
		((Control)TabControl_Aircraft).TabIndex = 10;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(6, 20);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(80, 25);
		((Control)Label1).TabIndex = 11;
		((Label)Label1).Text = "Package:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(6, 42);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(60, 25);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "Flight:";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(2, 77);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(77, 25);
		((Control)Label3).TabIndex = 11;
		((Label)Label3).Text = "Callsign:";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(2, 140);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(49, 25);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Task:";
		((ComboBox)Combo_CurrentPackage).BackColor = Color.Transparent;
		((ComboBox)Combo_CurrentPackage).DrawMode = (DrawMode)1;
		((ComboBox)Combo_CurrentPackage).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_CurrentPackage).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_CurrentPackage).FormattingEnabled = true;
		((Control)Combo_CurrentPackage).Location = new Point(62, 16);
		((Control)Combo_CurrentPackage).Name = "Combo_CurrentPackage";
		((Control)Combo_CurrentPackage).Size = new Size(153, 27);
		((Control)Combo_CurrentPackage).TabIndex = 12;
		((ComboBox)Combo_CurrentFlightPlan).BackColor = Color.Transparent;
		((ComboBox)Combo_CurrentFlightPlan).DrawMode = (DrawMode)1;
		((ComboBox)Combo_CurrentFlightPlan).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_CurrentFlightPlan).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_CurrentFlightPlan).FormattingEnabled = true;
		((Control)Combo_CurrentFlightPlan).Location = new Point(62, 38);
		((Control)Combo_CurrentFlightPlan).Name = "Combo_CurrentFlightPlan";
		((Control)Combo_CurrentFlightPlan).Size = new Size(153, 27);
		((Control)Combo_CurrentFlightPlan).TabIndex = 12;
		((ComboBox)Combo_FlightTask).BackColor = Color.Transparent;
		((ComboBox)Combo_FlightTask).DrawMode = (DrawMode)1;
		((ComboBox)Combo_FlightTask).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_FlightTask).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_FlightTask).FormattingEnabled = true;
		((Control)Combo_FlightTask).Location = new Point(98, 136);
		((Control)Combo_FlightTask).Name = "Combo_FlightTask";
		((Control)Combo_FlightTask).Size = new Size(122, 27);
		((Control)Combo_FlightTask).TabIndex = 12;
		TextBox_FlightCallsign.AutoCompleteCustomSource = null;
		TextBox_FlightCallsign.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_FlightCallsign.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_FlightCallsign).BackColor = Color.Transparent;
		((Control)TextBox_FlightCallsign).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FlightCallsign.Image = null;
		TextBox_FlightCallsign.Lines = null;
		((Control)TextBox_FlightCallsign).Location = new Point(98, 73);
		TextBox_FlightCallsign.MaxLength = 32767;
		TextBox_FlightCallsign.Multiline = false;
		((Control)TextBox_FlightCallsign).Name = "TextBox_FlightCallsign";
		TextBox_FlightCallsign.ReadOnly = false;
		TextBox_FlightCallsign.ScrollBars = (ScrollBars)0;
		TextBox_FlightCallsign.SelectionStart = 0;
		((Control)TextBox_FlightCallsign).Size = new Size(122, 20);
		((Control)TextBox_FlightCallsign).TabIndex = 13;
		TextBox_FlightCallsign.TextAlign = (HorizontalAlignment)0;
		TextBox_FlightCallsign.UseSystemPasswordChar = false;
		TextBox_FlightCallsign.WatermarkText = "";
		TextBox_FlightCallsign.WordWrap = false;
		((Control)Button_CopyFlightplan).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_CopyFlightplan).Location = new Point(648, 52);
		((Control)Button_CopyFlightplan).Name = "Button_CopyFlightplan";
		((Control)Button_CopyFlightplan).Padding = new Padding(5);
		((Control)Button_CopyFlightplan).Size = new Size(139, 24);
		((Control)Button_CopyFlightplan).TabIndex = 14;
		Button_CopyFlightplan.Text = "Copy Flightplan";
		Label_LaunchDateAndTime.AutoSize = true;
		((Control)Label_LaunchDateAndTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LaunchDateAndTime).Location = new Point(98, 203);
		((Control)Label_LaunchDateAndTime).Name = "Label_LaunchDateAndTime";
		((Control)Label_LaunchDateAndTime).Size = new Size(206, 25);
		((Control)Label_LaunchDateAndTime).TabIndex = 16;
		((Label)Label_LaunchDateAndTime).Text = "<Launch date and time>";
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(2, 161);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(73, 25);
		((Control)Label6).TabIndex = 19;
		((Label)Label6).Text = "Aircraft:";
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(2, 182);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(82, 25);
		((Control)Label7).TabIndex = 21;
		((Label)Label7).Text = "Loadout:";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(2, 203);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(158, 25);
		((Control)Label5).TabIndex = 23;
		((Label)Label5).Text = "Zulu take-off time:";
		((Control)Button_FillEmptySlots).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_FillEmptySlots).Location = new Point(648, 102);
		((Control)Button_FillEmptySlots).Name = "Button_FillEmptySlots";
		((Control)Button_FillEmptySlots).Padding = new Padding(5);
		((Control)Button_FillEmptySlots).Size = new Size(139, 24);
		((Control)Button_FillEmptySlots).TabIndex = 24;
		Button_FillEmptySlots.Text = "Fill Empty a/c Slots";
		((Control)Button_ClearSlots).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ClearSlots).Location = new Point(648, 77);
		((Control)Button_ClearSlots).Name = "Button_ClearSlots";
		((Control)Button_ClearSlots).Padding = new Padding(5);
		((Control)Button_ClearSlots).Size = new Size(139, 24);
		((Control)Button_ClearSlots).TabIndex = 25;
		Button_ClearSlots.Text = "Clear a/c Slots";
		((Control)Button_ClearSlots).Visible = false;
		Label_AircraftType.AutoSize = true;
		((Control)Label_AircraftType).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AircraftType).Location = new Point(98, 161);
		((Control)Label_AircraftType).Name = "Label_AircraftType";
		((Control)Label_AircraftType).Size = new Size(133, 25);
		((Control)Label_AircraftType).TabIndex = 26;
		((Label)Label_AircraftType).Text = "<Aircraft type>";
		Label_LoadoutName.AutoSize = true;
		((Control)Label_LoadoutName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LoadoutName).Location = new Point(98, 182);
		((Control)Label_LoadoutName).Name = "Label_LoadoutName";
		((Control)Label_LoadoutName).Size = new Size(151, 25);
		((Control)Label_LoadoutName).TabIndex = 27;
		((Label)Label_LoadoutName).Text = "<Loadout name>";
		Button_ChangeAircraftType.Enabled = false;
		((Control)Button_ChangeAircraftType).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeAircraftType).Location = new Point(648, 162);
		((Control)Button_ChangeAircraftType).Name = "Button_ChangeAircraftType";
		((Control)Button_ChangeAircraftType).Padding = new Padding(5);
		((Control)Button_ChangeAircraftType).Size = new Size(139, 42);
		((Control)Button_ChangeAircraftType).TabIndex = 28;
		Button_ChangeAircraftType.Text = "Change a/c type and loadout";
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(2, 224);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(182, 25);
		((Control)Label8).TabIndex = 30;
		((Label)Label8).Text = "Time on Target (Zulu):";
		Label_ObjectiveDateAndTime.AutoSize = true;
		((Control)Label_ObjectiveDateAndTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ObjectiveDateAndTime).Location = new Point(98, 224);
		((Control)Label_ObjectiveDateAndTime).Name = "Label_ObjectiveDateAndTime";
		((Control)Label_ObjectiveDateAndTime).Size = new Size(199, 25);
		((Control)Label_ObjectiveDateAndTime).TabIndex = 29;
		((Label)Label_ObjectiveDateAndTime).Text = "<Target date and time>";
		Label10.AutoSize = true;
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(2, 119);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 25);
		((Control)Label10).TabIndex = 32;
		((Label)Label10).Text = "Status:";
		Label_FlightStatus.AutoSize = true;
		((Control)Label_FlightStatus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_FlightStatus).Location = new Point(98, 119);
		((Control)Label_FlightStatus).Name = "Label_FlightStatus";
		((Control)Label_FlightStatus).Size = new Size(132, 25);
		((Control)Label_FlightStatus).TabIndex = 31;
		((Label)Label_FlightStatus).Text = "<Flight status>";
		Button_CreateFlightplanSkeleton.Enabled = false;
		((Control)Button_CreateFlightplanSkeleton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_CreateFlightplanSkeleton).Location = new Point(648, 2);
		((Control)Button_CreateFlightplanSkeleton).Name = "Button_CreateFlightplanSkeleton";
		((Control)Button_CreateFlightplanSkeleton).Padding = new Padding(5);
		((Control)Button_CreateFlightplanSkeleton).Size = new Size(139, 24);
		((Control)Button_CreateFlightplanSkeleton).TabIndex = 33;
		Button_CreateFlightplanSkeleton.Text = "Create Flightplan";
		Button_DeleteFlightplan.Enabled = false;
		((Control)Button_DeleteFlightplan).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_DeleteFlightplan).Location = new Point(648, 27);
		((Control)Button_DeleteFlightplan).Name = "Button_DeleteFlightplan";
		((Control)Button_DeleteFlightplan).Padding = new Padding(5);
		((Control)Button_DeleteFlightplan).Size = new Size(139, 24);
		((Control)Button_DeleteFlightplan).TabIndex = 34;
		Button_DeleteFlightplan.Text = "Delete Flightplan";
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Combo_CurrentFlightPlan);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Label1);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Label2);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Combo_CurrentPackage);
		((Control)GroupBox_SelectedFlight).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_SelectedFlight).Location = new Point(5, 2);
		((Control)GroupBox_SelectedFlight).Name = "GroupBox_SelectedFlight";
		((Control)GroupBox_SelectedFlight).Size = new Size(225, 68);
		((Control)GroupBox_SelectedFlight).TabIndex = 35;
		((GroupBox)GroupBox_SelectedFlight).TabStop = false;
		((GroupBox)GroupBox_SelectedFlight).Text = "Selected Flight";
		((ComboBox)Combo_FlightplanType).BackColor = Color.Transparent;
		((ComboBox)Combo_FlightplanType).DrawMode = (DrawMode)1;
		((ComboBox)Combo_FlightplanType).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_FlightplanType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_FlightplanType).FormattingEnabled = true;
		((Control)Combo_FlightplanType).Location = new Point(98, 94);
		((Control)Combo_FlightplanType).Name = "Combo_FlightplanType";
		((Control)Combo_FlightplanType).Size = new Size(122, 27);
		((Control)Combo_FlightplanType).TabIndex = 37;
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(2, 98);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(53, 25);
		((Control)Label9).TabIndex = 36;
		((Label)Label9).Text = "Type:";
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(2, 266);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(235, 25);
		((Control)Label11).TabIndex = 41;
		((Label)Label11).Text = "Secondary Landing location:";
		Label1_LandingLocation.AutoSize = true;
		((Control)Label1_LandingLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1_LandingLocation).Location = new Point(184, 266);
		((Control)Label1_LandingLocation).Name = "Label1_LandingLocation";
		((Control)Label1_LandingLocation).Size = new Size(167, 25);
		((Control)Label1_LandingLocation).TabIndex = 40;
		((Label)Label1_LandingLocation).Text = "<Landing location>";
		Label13.AutoSize = true;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(2, 245);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(148, 25);
		((Control)Label13).TabIndex = 39;
		((Label)Label13).Text = "Take-off location:";
		Label_TakeOffLocation.AutoSize = true;
		((Control)Label_TakeOffLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_TakeOffLocation).Location = new Point(98, 245);
		((Control)Label_TakeOffLocation).Name = "Label_TakeOffLocation";
		((Control)Label_TakeOffLocation).Size = new Size(168, 25);
		((Control)Label_TakeOffLocation).TabIndex = 38;
		((Label)Label_TakeOffLocation).Text = "<Take-off location>";
		Label15.AutoSize = true;
		((Control)Label15).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label15).Location = new Point(2, 287);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(158, 25);
		((Control)Label15).TabIndex = 43;
		((Label)Label15).Text = "Diversion location:";
		Label_DiversionAirfield.AutoSize = true;
		((Control)Label_DiversionAirfield).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DiversionAirfield).Location = new Point(98, 287);
		((Control)Label_DiversionAirfield).Name = "Label_DiversionAirfield";
		((Control)Label_DiversionAirfield).Size = new Size(178, 25);
		((Control)Label_DiversionAirfield).TabIndex = 42;
		((Label)Label_DiversionAirfield).Text = "<Diversion location>";
		((Control)Button_ChangeTakeOffTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeTakeOffTime).Location = new Point(648, 204);
		((Control)Button_ChangeTakeOffTime).Name = "Button_ChangeTakeOffTime";
		((Control)Button_ChangeTakeOffTime).Padding = new Padding(5);
		((Control)Button_ChangeTakeOffTime).Size = new Size(139, 21);
		((Control)Button_ChangeTakeOffTime).TabIndex = 44;
		Button_ChangeTakeOffTime.Text = "Change take-off time";
		((Control)Button_ChangeObjectiveTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeObjectiveTime).Location = new Point(648, 225);
		((Control)Button_ChangeObjectiveTime).Name = "Button_ChangeObjectiveTime";
		((Control)Button_ChangeObjectiveTime).Padding = new Padding(5);
		((Control)Button_ChangeObjectiveTime).Size = new Size(139, 21);
		((Control)Button_ChangeObjectiveTime).TabIndex = 45;
		Button_ChangeObjectiveTime.Text = "Change Time on Target";
		((Control)Button_ChangeTakeOffLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeTakeOffLocation).Location = new Point(648, 246);
		((Control)Button_ChangeTakeOffLocation).Name = "Button_ChangeTakeOffLocation";
		((Control)Button_ChangeTakeOffLocation).Padding = new Padding(5);
		((Control)Button_ChangeTakeOffLocation).Size = new Size(139, 21);
		((Control)Button_ChangeTakeOffLocation).TabIndex = 46;
		Button_ChangeTakeOffLocation.Text = "Change take-off location";
		((Control)Button_ChangeLandingLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeLandingLocation).Location = new Point(648, 267);
		((Control)Button_ChangeLandingLocation).Name = "Button_ChangeLandingLocation";
		((Control)Button_ChangeLandingLocation).Padding = new Padding(5);
		((Control)Button_ChangeLandingLocation).Size = new Size(139, 21);
		((Control)Button_ChangeLandingLocation).TabIndex = 47;
		Button_ChangeLandingLocation.Text = "Change landing location";
		((Control)Button_ChangeDiversionLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ChangeDiversionLocation).Location = new Point(648, 288);
		((Control)Button_ChangeDiversionLocation).Name = "Button_ChangeDiversionLocation";
		((Control)Button_ChangeDiversionLocation).Padding = new Padding(5);
		((Control)Button_ChangeDiversionLocation).Size = new Size(139, 21);
		((Control)Button_ChangeDiversionLocation).TabIndex = 48;
		Button_ChangeDiversionLocation.Text = "Change diversion location";
		Button_CreateFlightplanFull.Enabled = false;
		((Control)Button_CreateFlightplanFull).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_CreateFlightplanFull).Location = new Point(516, 27);
		((Control)Button_CreateFlightplanFull).Name = "Button_CreateFlightplanFull";
		((Control)Button_CreateFlightplanFull).Padding = new Padding(5);
		((Control)Button_CreateFlightplanFull).Size = new Size(139, 24);
		((Control)Button_CreateFlightplanFull).TabIndex = 33;
		Button_CreateFlightplanFull.Text = "Create Full Flightplan";
		lblWeaponUsed.AutoSize = true;
		((Control)lblWeaponUsed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblWeaponUsed).Location = new Point(2, 312);
		((Control)lblWeaponUsed).Name = "lblWeaponUsed";
		((Control)lblWeaponUsed).Size = new Size(133, 25);
		((Control)lblWeaponUsed).TabIndex = 50;
		((Label)lblWeaponUsed).Text = "Weapon in use:";
		lblActualWeaponUsage.AutoSize = true;
		((Control)lblActualWeaponUsage).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblActualWeaponUsage).Location = new Point(126, 312);
		((Control)lblActualWeaponUsage).Name = "lblActualWeaponUsage";
		((Control)lblActualWeaponUsage).Size = new Size(78, 25);
		((Control)lblActualWeaponUsage).TabIndex = 49;
		((Label)lblActualWeaponUsage).Text = "No Data";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(2, 337);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(145, 25);
		((Control)DarkLabel1).TabIndex = 52;
		((Label)DarkLabel1).Text = "Flightplan in use:";
		lblFPInUse.AutoSize = true;
		((Control)lblFPInUse).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblFPInUse).Location = new Point(141, 337);
		((Control)lblFPInUse).Name = "lblFPInUse";
		((Control)lblFPInUse).Size = new Size(78, 25);
		((Control)lblFPInUse).TabIndex = 51;
		((Label)lblFPInUse).Text = "No Data";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1484, 691);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)lblFPInUse);
		((Control)this).Controls.Add((Control)(object)lblWeaponUsed);
		((Control)this).Controls.Add((Control)(object)lblActualWeaponUsage);
		((Control)this).Controls.Add((Control)(object)Button_ChangeDiversionLocation);
		((Control)this).Controls.Add((Control)(object)Button_ChangeLandingLocation);
		((Control)this).Controls.Add((Control)(object)Button_ChangeTakeOffLocation);
		((Control)this).Controls.Add((Control)(object)Button_ChangeObjectiveTime);
		((Control)this).Controls.Add((Control)(object)Button_ChangeTakeOffTime);
		((Control)this).Controls.Add((Control)(object)Button_ChangeAircraftType);
		((Control)this).Controls.Add((Control)(object)Combo_FlightplanType);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)Label_FlightStatus);
		((Control)this).Controls.Add((Control)(object)GroupBox_SelectedFlight);
		((Control)this).Controls.Add((Control)(object)Button_DeleteFlightplan);
		((Control)this).Controls.Add((Control)(object)Button_CreateFlightplanFull);
		((Control)this).Controls.Add((Control)(object)Button_CreateFlightplanSkeleton);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)Button_ClearSlots);
		((Control)this).Controls.Add((Control)(object)Button_FillEmptySlots);
		((Control)this).Controls.Add((Control)(object)Button_CopyFlightplan);
		((Control)this).Controls.Add((Control)(object)TextBox_FlightCallsign);
		((Control)this).Controls.Add((Control)(object)Combo_FlightTask);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TabControl_Aircraft);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label_DiversionAirfield);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label1_LandingLocation);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)Label_TakeOffLocation);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label_ObjectiveDateAndTime);
		((Control)this).Controls.Add((Control)(object)Label_LoadoutName);
		((Control)this).Controls.Add((Control)(object)Label_AircraftType);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label_LaunchDateAndTime);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(1500, 730);
		((Control)this).Name = "FlightPlanEditor";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Flightplan Editor for flight <Flight Name>";
		((Control)GroupBox_SelectedFlight).ResumeLayout(false);
		((Control)GroupBox_SelectedFlight).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_6, bool bool_7, bool bool_8, bool bool_9)
	{
		if (!Information.IsNothing((object)scenarioObject_0) && (object)scenarioObject_0.GetType() == typeof(Waypoint) && ((Control)this).Visible && !bool_8 && (bool_7 || bool_9) && (!Client.Realtime || RealtimeTerminal.ActiveDeserializationCount <= 0))
		{
			RefreshGrid();
		}
	}

	private void method_3(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_6, bool bool_7, bool bool_8, bool bool_9)
	{
		if (!Information.IsNothing((object)scenarioObject_0) && (object)scenarioObject_0.GetType() == typeof(Waypoint) && ((Control)this).Visible && !bool_8 && (bool_7 || bool_9))
		{
			RefreshGrid();
		}
	}

	private void FlightPlanEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (method_4())
		{
			((CancelEventArgs)(object)e).Cancel = true;
			return;
		}
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private bool method_4()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		try
		{
			if (SelectedFlight == null)
			{
				return false;
			}
			if (bool_3)
			{
				return false;
			}
			int result;
			if (SelectedFlight == null)
			{
				result = 0;
			}
			else
			{
				if (SelectedFlight.HasCriticalError)
				{
					if (Operators.CompareString(Client.CurrentScenario.GetConcatenated_MDSP_Errors("", SelectedFlight.Callsign), string.Empty, true) == 0)
					{
						SelectedFlight.HasCriticalError = false;
						SelectedFlight.ErrorList = new List<MDSP_Error>();
						return false;
					}
					if ((int)DarkMessageBox.ShowError(Client.CurrentScenario.GetConcatenated_MDSP_Errors("", SelectedFlight.Callsign) + Environment.NewLine + Environment.NewLine + Environment.NewLine + " Do you want to leave the flightplan as it is?", "AT LEAST ONE FLIGHT MIGHT NOT TAKE OFF", DarkDialogButton.YesNo) == 6)
					{
						return false;
					}
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 048745658393654432", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private void FlightPlanEditor_FormClosed(object sender, FormClosedEventArgs e)
	{
		Doctrine.DoctrineChanged -= method_2;
		Doctrine.EmconChanged -= method_3;
		MissionEditor.SelectedMissionChanged -= method_5;
		Client.FlightPlanEditorWindow = null;
	}

	private void FlightPlanEditor_Load(object sender, EventArgs e)
	{
		Doctrine.DoctrineChanged += method_2;
		Doctrine.EmconChanged += method_3;
		MissionEditor.SelectedMissionChanged += method_5;
	}

	private void FlightPlanEditor_VisibleChanged(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (!((Control)this).Visible)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			LoadWindow();
			RefreshGrid();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		LoadGrid();
		RefreshGrid();
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
		}
	}

	public void RefreshWindow()
	{
		RefreshGrid();
		if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
		}
	}

	public void ReloadWindow()
	{
		if (Client.Realtime && !Client.RealtimeAC && SelectedMission != null)
		{
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (Operators.CompareString(mission.ObjectID, SelectedMission.ObjectID, true) == 0)
				{
					SelectedMission = mission;
					break;
				}
			}
			if (SelectedFlight != null)
			{
				foreach (Mission.Flight flight in SelectedMission.FlightList)
				{
					if (Operators.CompareString(flight.ObjectID, SelectedFlight.ObjectID, true) == 0)
					{
						SelectedFlight = flight;
						break;
					}
				}
			}
		}
		LoadWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_5(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing((object)scenarioObject_0))
			{
				LoadGrid();
				RefreshStats(RefreshAircraftNameAndLoadout: false);
				if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
				{
					FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
					ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
					FlightPlanEditor flightPlanEditorWindow;
					Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
					FlightPlanEditor flightPlanEditorWindow2;
					Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
					flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
					flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
					flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200630", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string wUwHjbqpahN(ref ActiveUnit.Throttle throttle_0)
	{
		switch (throttle_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return throttle_0.ToString();
		case ActiveUnit.Throttle.FullStop:
			return "Full Stop";
		case ActiveUnit.Throttle.Loiter:
			return "Loiter";
		case ActiveUnit.Throttle.Cruise:
			return "Cruise";
		case ActiveUnit.Throttle.Full:
			return "Military";
		case ActiveUnit.Throttle.Flank:
			return "Afterburner";
		}
	}

	internal void RefreshStats(bool RefreshAircraftNameAndLoadout)
	{
		try
		{
			((ComboBox)Combo_CurrentPackage).BeginUpdate();
			((ComboBox)Combo_CurrentPackage).Items.Clear();
			int num = 0;
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (mission.Category != Mission.MissionCategory.TaskPool)
				{
					((ComboBox)Combo_CurrentPackage).Items.Insert(num, (object)mission.Name);
					if (mission == SelectedMission)
					{
						((ComboBox)Combo_CurrentPackage).SelectedIndex = num;
					}
					num++;
				}
			}
			((ComboBox)Combo_CurrentPackage).EndUpdate();
			((ComboBox)Combo_CurrentFlightPlan).BeginUpdate();
			((ComboBox)Combo_CurrentFlightPlan).Items.Clear();
			num = 0;
			foreach (Mission.Flight flight in SelectedMission.FlightList)
			{
				((ComboBox)Combo_CurrentFlightPlan).Items.Insert(num, (object)flight.Callsign);
				if (!Information.IsNothing((object)SelectedFlight))
				{
					if (flight == SelectedFlight)
					{
						((ComboBox)Combo_CurrentFlightPlan).SelectedIndex = num;
					}
					num++;
				}
			}
			((ComboBox)Combo_CurrentFlightPlan).EndUpdate();
			if (Information.IsNothing((object)SelectedFlight))
			{
				((ComboBox)Combo_CurrentFlightPlan).SelectedIndex = -1;
				((ComboBox)Combo_CurrentFlightPlan).Text = "";
				TextBox_FlightCallsign.Text = "";
			}
			else
			{
				TextBox_FlightCallsign.Text = SelectedFlight.Callsign;
			}
			if (Information.IsNothing((object)SelectedFlight))
			{
				((ComboBox)Combo_FlightTask).DataSource = null;
				((ComboBox)Combo_FlightTask).Items.Clear();
				((ComboBox)Combo_FlightTask).SelectedIndex = -1;
				((ComboBox)Combo_FlightplanType).DataSource = null;
				((ComboBox)Combo_FlightplanType).Items.Clear();
				((ComboBox)Combo_FlightplanType).SelectedIndex = -1;
			}
			else
			{
				DataTable theComboBoxDataSource_Task = new DataTable();
				Mission.Flight.ComboBoxDataSource_Task(ref theComboBoxDataSource_Task);
				DarkUIComboBox combo_FlightTask = Combo_FlightTask;
				((ComboBox)combo_FlightTask).DataSource = theComboBoxDataSource_Task;
				((ListControl)combo_FlightTask).DisplayMember = "Description";
				((ListControl)combo_FlightTask).ValueMember = "ID";
				((ComboBox)combo_FlightTask).DropDownWidth = 500;
				((ComboBox)Combo_FlightTask).SelectedIndex = Mission.Flight.Task_To_TaskSelection((int)SelectedFlight.Task);
				DataTable theComboBoxDataSource_Type = new DataTable();
				Mission.Flight.ComboBoxDataSource_Type(ref theComboBoxDataSource_Type);
				DarkUIComboBox combo_FlightplanType = Combo_FlightplanType;
				((ComboBox)combo_FlightplanType).DataSource = theComboBoxDataSource_Type;
				((ListControl)combo_FlightplanType).DisplayMember = "Description";
				((ListControl)combo_FlightplanType).ValueMember = "ID";
				((ComboBox)combo_FlightplanType).DropDownWidth = 500;
				((ComboBox)Combo_FlightplanType).SelectedIndex = Mission.Flight.Type_To_TypeSelection((int)SelectedFlight.Type);
			}
			method_6();
			if (RefreshAircraftNameAndLoadout && !Information.IsNothing((object)SelectedFlight))
			{
				((Label)Label_AircraftType).Text = SelectedFlight.ReferenceUnit_Name;
				((Label)Label_LoadoutName).Text = SelectedFlight.get_LoadoutName(Client.CurrentScenario);
			}
			try
			{
				bool flag = false;
				if (SelectedFlight != null)
				{
					Waypoint[] flightPlan = SelectedFlight.FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						if (waypoint == null || waypoint.ReferenceWeapon_ID == 0)
						{
							continue;
						}
						Scenario theScen = Client.CurrentScenario;
						Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, waypoint.ReferenceWeapon_ID, bool_5: false);
						if (newWeapon != null)
						{
							float num2 = 1f;
							string text = "mt";
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								num2 = 3.28084f;
								text = "ft";
							}
							((Label)lblActualWeaponUsage).Text = newWeapon.Name + " " + Math.Round(newWeapon.MinLaunchAlt_AGL * num2) + " " + text + " - " + Math.Round(newWeapon.MaxLaunchAlt_AGL * num2) + " " + text;
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					((Label)lblActualWeaponUsage).Text = "No Data";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedFlight))
			{
				((Control)Combo_FlightplanType).Enabled = false;
				if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					((Control)Combo_FlightplanType).Enabled = true;
				}
				else
				{
					((Control)Combo_FlightplanType).Enabled = false;
				}
				if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					if (SelectedFlight.FlightPlan.Count() <= 0)
					{
						Button_CreateFlightplanSkeleton.Enabled = true;
						Button_CreateFlightplanFull.Enabled = true;
					}
					else
					{
						Button_CreateFlightplanSkeleton.Enabled = false;
						Button_CreateFlightplanFull.Enabled = false;
					}
				}
				else
				{
					Button_CreateFlightplanSkeleton.Enabled = false;
					Button_CreateFlightplanFull.Enabled = false;
				}
				if (SelectedFlight.FlightPlan.Count() <= 0)
				{
					Button_DeleteFlightplan.Enabled = false;
				}
				else
				{
					Button_DeleteFlightplan.Enabled = true;
				}
				Button_CopyFlightplan.Enabled = true;
				if (SelectedFlight.Type != Mission._FlightType.Flightplan)
				{
					Button_ClearSlots.Enabled = false;
					Button_FillEmptySlots.Enabled = false;
				}
				else if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					Button_ClearSlots.Enabled = false;
					foreach (ActiveUnit item in Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario))
					{
						if (item.Navigator.HasFlight && item.Navigator.get_Flight(HierarchySearch: true) == SelectedFlight)
						{
							Button_ClearSlots.Enabled = true;
							break;
						}
					}
					Button_FillEmptySlots.Enabled = false;
					if (!Information.IsNothing((object)SelectedMission.EmptySlotsList))
					{
						foreach (Mission.EmptyAircraftSlot emptySlots in SelectedMission.EmptySlotsList)
						{
							if (Operators.CompareString(emptySlots.MissionFlight_ObjectID, SelectedFlight.ObjectID, true) == 0)
							{
								Button_FillEmptySlots.Enabled = true;
								break;
							}
						}
					}
				}
				else
				{
					Button_ClearSlots.Enabled = false;
					Button_FillEmptySlots.Enabled = false;
				}
				if (SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
				{
					Button_ChangeAircraftType.Enabled = false;
				}
				else
				{
					Button_ChangeAircraftType.Enabled = true;
				}
				if (SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
				{
					Button_ChangeTakeOffLocation.Enabled = false;
					Button_ChangeTakeOffTime.Enabled = false;
				}
				else
				{
					Button_ChangeTakeOffLocation.Enabled = true;
					if (SelectedFlight.FlightPlan.Count() <= 0)
					{
						Button_ChangeTakeOffTime.Enabled = false;
					}
					else if (SelectedFlight.Type == Mission._FlightType.Flightplan)
					{
						Button_ChangeTakeOffTime.Enabled = true;
					}
					else
					{
						Button_ChangeTakeOffTime.Enabled = false;
					}
				}
				Button_ChangeObjectiveTime.Enabled = false;
				if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.Completed)
				{
					Button_ChangeLandingLocation.Enabled = false;
					Button_ChangeDiversionLocation.Enabled = false;
					return;
				}
				Button_ChangeLandingLocation.Enabled = true;
				Button_ChangeDiversionLocation.Enabled = true;
				if (SelectedFlight.Type != Mission._FlightType.Flightplan)
				{
					return;
				}
				Waypoint[] flightPlan = SelectedFlight.FlightPlan;
				int num = 0;
				while (true)
				{
					if (num < flightPlan.Length)
					{
						Waypoint.WaypointType type = flightPlan[num].Type;
						if (type == Waypoint.WaypointType.Target || (uint)(type - 19) <= 5u)
						{
							break;
						}
						num = checked(num + 1);
						continue;
					}
					return;
				}
				Button_ChangeObjectiveTime.Enabled = true;
			}
			else
			{
				Button_DeleteFlightplan.Enabled = false;
				Button_CreateFlightplanSkeleton.Enabled = false;
				Button_CreateFlightplanFull.Enabled = false;
				Button_CopyFlightplan.Enabled = false;
				Button_ClearSlots.Enabled = false;
				Button_FillEmptySlots.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ChangeTakeOffLocation.Enabled = false;
				Button_ChangeLandingLocation.Enabled = false;
				Button_ChangeDiversionLocation.Enabled = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void LoadGrid(bool fromSelectedIndexChange = false)
	{
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_100f: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1075: Unknown result type (might be due to invalid IL or missing references)
		//IL_1085: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db: Unknown result type (might be due to invalid IL or missing references)
		//IL_10eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		if (!fromSelectedIndexChange)
		{
			list_1.Clear();
			list_2.Clear();
			list_3.Clear();
			try
			{
				((TabControl)TabControl_Aircraft).TabPages.Clear();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		if (Information.IsNothing((object)SelectedMission))
		{
			foreach (DataTable item in list_3)
			{
				item.Clear();
			}
			RefreshStats(RefreshAircraftNameAndLoadout: false);
			return;
		}
		if (Information.IsNothing((object)SelectedFlight))
		{
			foreach (DataTable item2 in list_3)
			{
				item2.Clear();
			}
			RefreshStats(RefreshAircraftNameAndLoadout: false);
			return;
		}
		if (SelectedMission.HasFlights())
		{
			try
			{
				bool flag = false;
				if (!fromSelectedIndexChange)
				{
					list_0 = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario)
						where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
						select x).ToList();
					list_0 = list_0.Where([SpecialName] (ActiveUnit x) => x.IsAircraft).ToList();
					list_0 = list_0.Where([SpecialName] (ActiveUnit x) => Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, SelectedFlight.Callsign, true) == 0).ToList();
					if (list_0.Count == 0)
					{
						return;
					}
					list_0 = list_0.OrderByDescending([SpecialName] (ActiveUnit theA) => theA.IsGroupLead()).ToList();
					SelectedAircraft = list_0[0];
					int num = list_0.Count - 1;
					for (int num2 = 0; num2 <= num; num2++)
					{
						TabPage val = new TabPage();
						((Control)val).Size = theDefaultSize;
						string text = "";
						if (list_0[num2].IsGroupLead())
						{
							text = " (Leader)";
						}
						val.Text = list_0[num2].Name + text;
						string ReasonForNot = "";
						if (((Aircraft)list_0[num2]).IsAvailableForOps(ref ReasonForNot) != 0)
						{
							val.Text = val.Text + " " + ReasonForNot;
						}
						FlightPlanWaypoints flightPlanWaypoints = new FlightPlanWaypoints();
						((Control)flightPlanWaypoints).Size = theDefaultSize;
						((Control)flightPlanWaypoints).Dock = (DockStyle)5;
						list_2.Add(flightPlanWaypoints);
						((Control)val).Controls.Add((Control)(object)flightPlanWaypoints);
						list_3.Add(new DataTable());
						((TabControl)TabControl_Aircraft).TabPages.Add(val);
					}
				}
				int num3;
				int num4;
				if (Information.IsNothing((object)theFlightPlanWaypoints))
				{
					num3 = 0;
				}
				else
				{
					if (!Information.IsNothing((object)theFlightPlanWaypoints.DGV_Waypoints))
					{
						num4 = ((BaseCollection)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows).Count;
						if (num4 > 0)
						{
							SelectedRow = ((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index;
							SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow]).Tag;
						}
						goto IL_03d9;
					}
					num3 = 0;
				}
				num4 = num3;
				SelectedRow = 0;
				SelectedWaypoint = null;
				goto IL_03d9;
				IL_03d9:
				if (((TabControl)TabControl_Aircraft).SelectedIndex >= 0)
				{
					_ = SelectedAircraft;
				}
				else
				{
					_ = list_0[0];
				}
				_ = SelectedFlight.FlightPlan;
				method_8();
				switch (((TabControl)TabControl_Aircraft).SelectedIndex)
				{
				default:
				{
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = ActiveUnit.RetrieveFlightRole(((TabControl)TabControl_Aircraft).SelectedIndex + 1);
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = flightElement;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					break;
				}
				case -1:
					return;
				case 0:
				{
					if (list_2 == null)
					{
					}
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.LeadElement;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = Mission.Flight.FlightElement.LeadElement;
					break;
				}
				case 1:
				{
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.LeadElementWingman;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = Mission.Flight.FlightElement.LeadElementWingman;
					break;
				}
				case 2:
				{
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.SecondElement;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = Mission.Flight.FlightElement.SecondElement;
					break;
				}
				case 3:
				{
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.SecondElementWingman;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = Mission.Flight.FlightElement.SecondElementWingman;
					break;
				}
				case 4:
				{
					if (theFlightPlanWaypoints != list_2[((TabControl)TabControl_Aircraft).SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = list_2[((TabControl)TabControl_Aircraft).SelectedIndex];
					list_2[((TabControl)TabControl_Aircraft).SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.ThirdElement;
					dataTable_0 = list_3[((TabControl)TabControl_Aircraft).SelectedIndex];
					Mission.Flight.FlightElement flightElement = Mission.Flight.FlightElement.ThirdElement;
					break;
				}
				}
				WaypointList_Refresh = false;
				dataTable_0.Clear();
				foreach (DataTable item3 in list_3)
				{
					item3.Clear();
					WaypointList_Refresh = true;
				}
				if (dataTable_0.Columns.Count == 0)
				{
					if (!dataTable_0.Columns.Contains("ID"))
					{
						dataTable_0.Columns.Add("ID", typeof(string));
						int_0 = 0;
					}
					if (!dataTable_0.Columns.Contains("ObjectID"))
					{
						dataTable_0.Columns.Add("ObjectID", typeof(string));
						int_1 = 1;
					}
					if (!dataTable_0.Columns.Contains("Type"))
					{
						dataTable_0.Columns.Add("Type", typeof(int));
						int_2 = 2;
					}
					if (!dataTable_0.Columns.Contains("Time_Zulu"))
					{
						dataTable_0.Columns.Add("Time_Zulu", typeof(string));
						int_3 = 3;
					}
					if (!dataTable_0.Columns.Contains("Time_Local"))
					{
						dataTable_0.Columns.Add("Time_Local", typeof(string));
						int_4 = 4;
					}
					if (!dataTable_0.Columns.Contains("TimeFixedImg"))
					{
						dataTable_0.Columns.Add("TimeFixedImg", typeof(Image));
						int_6 = 5;
					}
					if (!dataTable_0.Columns.Contains("TimeFixed"))
					{
						dataTable_0.Columns.Add("TimeFixed", typeof(int));
						int_5 = 6;
					}
					if (!dataTable_0.Columns.Contains("DesiredSpeed"))
					{
						dataTable_0.Columns.Add("DesiredSpeed", typeof(string));
						int_7 = 7;
					}
					if (!dataTable_0.Columns.Contains("SpeedFixedImg"))
					{
						dataTable_0.Columns.Add("SpeedFixedImg", typeof(Image));
						int_9 = 8;
					}
					if (!dataTable_0.Columns.Contains("SpeedFixed"))
					{
						dataTable_0.Columns.Add("SpeedFixed", typeof(int));
						int_8 = 9;
					}
					if (!dataTable_0.Columns.Contains("DesiredAltitude"))
					{
						dataTable_0.Columns.Add("DesiredAltitude", typeof(string));
						int_10 = 10;
					}
					if (!dataTable_0.Columns.Contains("Leg_Distance"))
					{
						dataTable_0.Columns.Add("Leg_Distance", typeof(string));
						int_16 = 11;
					}
					if (!dataTable_0.Columns.Contains("Leg_TotalDistance"))
					{
						dataTable_0.Columns.Add("Leg_TotalDistance", typeof(string));
						int_17 = 12;
					}
					if (!dataTable_0.Columns.Contains("Leg_Time"))
					{
						dataTable_0.Columns.Add("Leg_Time", typeof(string));
						int_13 = 13;
					}
					if (!dataTable_0.Columns.Contains("Hold_Time"))
					{
						dataTable_0.Columns.Add("Hold_Time", typeof(string));
						int_14 = 14;
					}
					if (!dataTable_0.Columns.Contains("Leg_TotalTime"))
					{
						dataTable_0.Columns.Add("Leg_TotalTime", typeof(string));
						int_15 = 15;
					}
					if (!dataTable_0.Columns.Contains("Leg_FuelRequired"))
					{
						dataTable_0.Columns.Add("Leg_FuelRequired", typeof(string));
						int_11 = 16;
					}
					if (!dataTable_0.Columns.Contains("Leg_FuelRemaining"))
					{
						dataTable_0.Columns.Add("Leg_FuelRemaining", typeof(string));
						int_12 = 17;
					}
					if (!dataTable_0.Columns.Contains("SpeedToT"))
					{
						dataTable_0.Columns.Add("SpeedToT", typeof(int));
						int_26 = 18;
					}
					if (!dataTable_0.Columns.Contains("Formation"))
					{
						dataTable_0.Columns.Add("Formation", typeof(int));
						int_18 = 19;
					}
					if (!dataTable_0.Columns.Contains("AARUsage"))
					{
						dataTable_0.Columns.Add("AARUsage", typeof(int));
						int_20 = 20;
					}
					if (!dataTable_0.Columns.Contains("AARSelection"))
					{
						dataTable_0.Columns.Add("AARSelection", typeof(int));
						int_21 = 21;
					}
					if (!dataTable_0.Columns.Contains("AARSettings"))
					{
						dataTable_0.Columns.Add("AARSettings", typeof(int));
						int_19 = 22;
					}
					if (!dataTable_0.Columns.Contains("SensorUsage"))
					{
						dataTable_0.Columns.Add("SensorUsage", typeof(string));
						int_24 = 23;
					}
					if (!dataTable_0.Columns.Contains("Doctrine"))
					{
						dataTable_0.Columns.Add("Doctrine", typeof(string));
						int_23 = 24;
					}
					if (!dataTable_0.Columns.Contains("TurnRate"))
					{
						dataTable_0.Columns.Add("TurnRate", typeof(int));
						int_22 = 25;
					}
					if (!dataTable_0.Columns.Contains("Coordinates"))
					{
						dataTable_0.Columns.Add("Coordinates", typeof(string));
						int_25 = 26;
					}
					if (!dataTable_0.Columns.Contains("Weapon"))
					{
						dataTable_0.Columns.Add("Weapon", typeof(string));
						int_27 = 27;
					}
					if (!dataTable_0.Columns.Contains("Target"))
					{
						dataTable_0.Columns.Add("Target", typeof(string));
						int_28 = 28;
					}
				}
				if (flag)
				{
					DataGridViewComboBoxColumn val2 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_2]).Index];
					Waypoint.ComboBoxDataSource_WaypointType(ref dataTable_1);
					val2.DataSource = dataTable_1;
					val2.DisplayMember = "Description";
					val2.ValueMember = "ID";
					DataGridViewComboBoxColumn val3 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_20]).Index];
					val3.DataSource = dataTable_3;
					val3.DisplayMember = "Description";
					val3.ValueMember = "ID";
					DataGridViewComboBoxColumn val4 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_21]).Index];
					val4.DataSource = dataTable_4;
					val4.DisplayMember = "Description";
					val4.ValueMember = "ID";
					DataGridViewComboBoxColumn val5 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_18]).Index];
					Waypoint.ComboBoxDataSource_Formation(ref dataTable_2);
					val5.DataSource = dataTable_2;
					val5.DisplayMember = "Description";
					val5.ValueMember = "ID";
					DataGridViewComboBoxColumn val6 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_22]).Index];
					Waypoint.ComboBoxDataSource_TurnRate(ref dataTable_5);
					val6.DataSource = dataTable_5;
					val6.DisplayMember = "Description";
					val6.ValueMember = "ID";
					DataGridViewComboBoxColumn val7 = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Columns[int_26]).Index];
					Waypoint.ComboBoxDataSource_SpeedToT(ref dataTable_6);
					val7.DataSource = dataTable_6;
					val7.DisplayMember = "Description";
					val7.ValueMember = "ID";
				}
				WaypointList_Refresh = false;
				ActiveUnit activeUnit = (from x in (from x in (from x in Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario)
							where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
							select x).ToList()
						where x.IsAircraft
						select x).ToList()
					where Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, SelectedFlight.Callsign, true) == 0
					select x).ToList()[((TabControl)TabControl_Aircraft).SelectedIndex];
				int count;
				int num9;
				checked
				{
					if ((GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Equipment) | (((Aircraft)activeUnit).LoadoutDBID == SelectedFlight.int_1))
					{
						Waypoint[] flightPlan = SelectedFlight.FlightPlan;
						for (int num5 = 0; num5 < flightPlan.Length; num5++)
						{
							DataRow row = dataTable_0.NewRow();
							dataTable_0.Rows.Add(row);
						}
					}
					else if (!((GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Aircraft) | (((Aircraft)activeUnit).LoadoutDBID == SelectedFlight.int_1)))
					{
						if (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.FreeForAll)
						{
							if (SelectedFlight.SecondaryFlightPlans != null)
							{
								foreach (SecondaryFlightPlan secondaryFlightPlan in SelectedFlight.SecondaryFlightPlans)
								{
									if (secondaryFlightPlan.Loadout_DBID == ((Aircraft)activeUnit).LoadoutDBID)
									{
										Waypoint[] flightPlan2 = secondaryFlightPlan.FlightPlan;
										for (int num6 = 0; num6 < flightPlan2.Length; num6++)
										{
											DataRow row2 = dataTable_0.NewRow();
											dataTable_0.Rows.Add(row2);
										}
									}
								}
							}
							else if (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Advanced)
							{
								foreach (SecondaryFlightPlan secondaryFlightPlan2 in SelectedFlight.SecondaryFlightPlans)
								{
									if (MissionPlanner.CheckAdvancedGroupCompatibility(secondaryFlightPlan2.DBID, secondaryFlightPlan2.Loadout_DBID, ((Aircraft)activeUnit).DBID, ((Aircraft)activeUnit).LoadoutDBID))
									{
										Waypoint[] flightPlan3 = secondaryFlightPlan2.FlightPlan;
										for (int num7 = 0; num7 < flightPlan3.Length; num7++)
										{
											DataRow row3 = dataTable_0.NewRow();
											dataTable_0.Rows.Add(row3);
										}
									}
								}
							}
						}
					}
					else if (SelectedFlight.SecondaryFlightPlans != null)
					{
						foreach (SecondaryFlightPlan secondaryFlightPlan3 in SelectedFlight.SecondaryFlightPlans)
						{
							if (secondaryFlightPlan3.DBID == ((Aircraft)activeUnit).DBID)
							{
								Waypoint[] flightPlan4 = secondaryFlightPlan3.FlightPlan;
								for (int num8 = 0; num8 < flightPlan4.Length; num8++)
								{
									DataRow row4 = dataTable_0.NewRow();
									dataTable_0.Rows.Add(row4);
								}
							}
						}
					}
					if (num4 == 0 && ((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows.Count > 0)
					{
						((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
					}
					WaypointList_Refresh = true;
					RefreshGrid();
					if (SelectedFlight.FlightPlan.Count() > 0)
					{
						Doctrine doctrine = SelectedFlight.FlightPlan[0].GetDoctrine(Client.CurrentScenario);
						DataTable dT = dataTable_3;
						Doctrine.DoctrineItem_E theDocEnum = Doctrine.DoctrineItem_E.UseReplenishment;
						doctrine.Populate_DataTable_States(dT, ref theDocEnum);
						Doctrine doctrine2 = SelectedFlight.FlightPlan[0].GetDoctrine(Client.CurrentScenario);
						DataTable dT2 = dataTable_4;
						theDocEnum = Doctrine.DoctrineItem_E.ReplenishmentSelection;
						doctrine2.Populate_DataTable_States(dT2, ref theDocEnum);
					}
					WaypointList_Refresh = false;
					((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).DataSource = new DataView(dataTable_0);
					WaypointList_Refresh = true;
					count = ((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows.Count;
					num9 = SelectedFlight.FlightPlan.Count();
				}
				for (int num10 = count - 1; num10 >= 0; num10 += -1)
				{
					if (num10 <= num9 - 1)
					{
						Waypoint theWaypoint = SelectedFlight.FlightPlan[num10];
						if (!Information.IsNothing((object)theWaypoint))
						{
							Waypoint actualWaypoint = FlightPlanWaypoints.GetActualWaypoint(ref theWaypoint, theFlightPlanWaypoints.FlightPlan_Element);
							((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[num10]).Tag = actualWaypoint;
						}
					}
				}
				WaypointList_Refresh = false;
				if (((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount <= 0)
				{
					SelectedWaypoint = null;
				}
				else if (SelectedRow > ((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount - 1)
				{
					((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
					((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount - 1].Selected = true;
					SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[0]).Tag;
				}
				else
				{
					((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
					((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow].Selected = true;
					SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow]).Tag;
				}
				WaypointList_Refresh = true;
				WaypointList_Refresh = false;
				theFlightPlanWaypoints.DisplayLocks();
				WaypointList_Refresh = true;
				theFlightPlanWaypoints.EnableAndDisableCells();
				theFlightPlanWaypoints.EnableAndDisableButtons();
				((Control)list_2[((TabControl)TabControl_Aircraft).SelectedIndex].DGV_Waypoints).ResumeLayout();
				if (Client.FPVisibility == null)
				{
					Client.FPVisibility = new List<FlightPlanVisbileOnMap>();
					Client.FPVisibility.Add(new FlightPlanVisbileOnMap(activeUnit.DBID, ((Aircraft)activeUnit).LoadoutDBID, SelectedFlight, visible: true));
				}
				foreach (FlightPlanVisbileOnMap item4 in Client.FPVisibility.ToList())
				{
					if ((Operators.CompareString(item4.theFlight.Callsign, SelectedFlight.Callsign, true) == 0) & (item4.UnitDBID == activeUnit.DBID) & (item4.int_0 == ((Aircraft)activeUnit).LoadoutDBID))
					{
						((CheckBox)theFlightPlanWaypoints.CB_Filter).Checked = item4.Visible;
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		foreach (DataTable item5 in list_3)
		{
			item5.Clear();
		}
		RefreshStats(RefreshAircraftNameAndLoadout: false);
	}

	private Mission.Flight.FlightElement method_7(int int_29)
	{
		throw new NotImplementedException();
	}

	internal void RefreshGrid()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedMission))
			{
				if (!Information.IsNothing((object)SelectedFlight))
				{
					if (!SelectedMission.HasFlights())
					{
						return;
					}
					((Form)this).Text = "Flightplan Editor for flight " + SelectedFlight.Callsign;
					if (list_0 == null || list_0.Count == 0)
					{
						return;
					}
					Aircraft aircraft = (Aircraft)SelectedAircraft;
					Waypoint[] flightPlan = SelectedFlight.FlightPlan;
					method_8();
					if (flightPlan != null)
					{
						bool flag = false;
						Waypoint[] array = flightPlan;
						foreach (Waypoint waypoint in array)
						{
							if (waypoint != null && waypoint.ReferenceWeapon_ID != 0)
							{
								Scenario theScen = Client.CurrentScenario;
								Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, waypoint.ReferenceWeapon_ID, bool_5: false);
								if (newWeapon != null)
								{
									float num = 1f;
									string text = "mt";
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										num = 3.28084f;
										text = "ft";
									}
									((Label)lblActualWeaponUsage).Text = newWeapon.Name + " " + Math.Round(newWeapon.MinLaunchAlt_AGL * num) + " " + text + " - " + Math.Round(newWeapon.MaxLaunchAlt_AGL * num) + " " + text;
									flag = true;
									break;
								}
							}
							else if (flag)
							{
								break;
							}
						}
					}
					((Label)Label_TakeOffLocation).Text = SelectedFlight.TakeOffLocation_HostUnitObjectName;
					((Label)Label1_LandingLocation).Text = SelectedFlight.LandingLocation_HostUnitObjectName;
					((Label)Label_DiversionAirfield).Text = SelectedFlight.AlternativeLandingLocation_HostUnitObjectName;
					((Label)Label_FlightStatus).Text = Mission.get_FlightStatusString(SelectedFlight.get_Status(Client.CurrentScenario));
					if (string.IsNullOrEmpty(((Label)Label_AircraftType).Text))
					{
						((Label)Label_AircraftType).Text = "Not set";
					}
					if (string.IsNullOrEmpty(((Label)Label_LoadoutName).Text))
					{
						((Label)Label_LoadoutName).Text = "Not set";
					}
					if (string.IsNullOrEmpty(((Label)Label_TakeOffLocation).Text))
					{
						((Label)Label_TakeOffLocation).Text = "Not set";
					}
					if (string.IsNullOrEmpty(((Label)Label1_LandingLocation).Text))
					{
						((Label)Label1_LandingLocation).Text = "Not set";
					}
					if (string.IsNullOrEmpty(((Label)Label_DiversionAirfield).Text))
					{
						((Label)Label_DiversionAirfield).Text = "-";
					}
					int num2;
					if (!string.IsNullOrEmpty(((Label)Label_FlightStatus).Text))
					{
						num2 = 1;
					}
					else
					{
						((Label)Label_FlightStatus).Text = "Not set";
						num2 = 1;
					}
					int num3 = num2;
					DateTime time = Client.CurrentScenario.Time;
					bool use_DST = Client.CurrentScenario.Use_DST;
					string dST_Start = Client.CurrentScenario.DST_Start;
					string dST_End = Client.CurrentScenario.DST_End;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					if (Information.IsNothing((object)theFlightPlanWaypoints))
					{
						return;
					}
					((Control)theFlightPlanWaypoints.DGV_Waypoints).SuspendLayout();
					try
					{
						Waypoint[] array2 = ((aircraft.LoadoutDBID != SelectedFlight.int_1) ? SelectedFlight.RetrieveSecondaryFP(aircraft.DBID, aircraft.LoadoutDBID).FlightPlan : SelectedFlight.FlightPlan);
						int num4 = array2.Count() - 1;
						int num5 = 0;
						DateTime? dateTime = default(DateTime?);
						Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
						Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
						int num10 = default(int);
						while (num5 <= num4)
						{
							Waypoint waypoint2;
							Waypoint waypoint3;
							if (((TabControl)TabControl_Aircraft).SelectedIndex != 0)
							{
								if (((TabControl)TabControl_Aircraft).SelectedIndex == 1)
								{
									if (Information.IsNothing((object)array2[num5].Waypoint_LeadElementWingman))
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5];
									}
									else if (!Information.IsNothing((object)array2[num5].Waypoint_LeadElementWingman) && array2[num5].FlightFormation != Waypoint.Formation.Split)
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5].Waypoint_LeadElementWingman;
									}
									else
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5].Waypoint_LeadElementWingman;
									}
								}
								else if (((TabControl)TabControl_Aircraft).SelectedIndex == 2)
								{
									if (!Information.IsNothing((object)array2[num5].Waypoint_SecondElement))
									{
										if (!Information.IsNothing((object)array2[num5].Waypoint_SecondElement) && array2[num5].FlightFormation != Waypoint.Formation.Split)
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_SecondElement;
										}
										else
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_SecondElement;
										}
									}
									else
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5];
									}
								}
								else if (((TabControl)TabControl_Aircraft).SelectedIndex == 3)
								{
									if (!Information.IsNothing((object)array2[num5].Waypoint_SecondElementWingman))
									{
										if (!Information.IsNothing((object)array2[num5].Waypoint_SecondElementWingman) && array2[num5].FlightFormation != Waypoint.Formation.Split)
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_SecondElementWingman;
										}
										else
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_SecondElementWingman;
										}
									}
									else
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5];
									}
								}
								else if (((TabControl)TabControl_Aircraft).SelectedIndex == 4)
								{
									if (!Information.IsNothing((object)array2[num5].Waypoint_ThirdElement))
									{
										if (!Information.IsNothing((object)array2[num5].Waypoint_ThirdElement) && array2[num5].FlightFormation != Waypoint.Formation.Split)
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_ThirdElement;
										}
										else
										{
											waypoint2 = array2[num5];
											waypoint3 = array2[num5].Waypoint_ThirdElement;
										}
									}
									else
									{
										waypoint2 = array2[num5];
										waypoint3 = array2[num5];
									}
								}
								else if (Information.IsNothing((object)array2[num5].Waypoint_ThirdElementWingman))
								{
									waypoint2 = array2[num5];
									waypoint3 = array2[num5];
								}
								else if (!Information.IsNothing((object)array2[num5].Waypoint_ThirdElementWingman) && array2[num5].FlightFormation != Waypoint.Formation.Split)
								{
									waypoint2 = array2[num5];
									waypoint3 = array2[num5].Waypoint_ThirdElementWingman;
								}
								else
								{
									waypoint2 = array2[num5];
									waypoint3 = array2[num5].Waypoint_ThirdElementWingman;
								}
							}
							else
							{
								waypoint2 = array2[num5];
								waypoint3 = array2[num5];
							}
							DataRow dataRow = dataTable_0.Rows[num5];
							Waypoint waypoint4 = (waypoint2.IsSplitWaypoint() ? waypoint3 : waypoint2);
							int num6 = Waypoint.WaypointType_To_WaypointTypeSelection(waypoint2.Type);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_2]), num6))
							{
								dataRow[int_2] = num6;
							}
							if (waypoint2.Type == Waypoint.WaypointType.StationEnd && waypoint2.Station_Time == 0f)
							{
								flag2 = true;
								flag3 = true;
							}
							string text2 = (string.IsNullOrEmpty(waypoint2.Description) ? Conversions.ToString(num3) : waypoint2.Description);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_0]), text2))
							{
								dataRow[int_0] = text2;
							}
							num3++;
							dataRow[int_1] = waypoint2.ObjectID;
							string text3;
							if (!Information.IsNothing((object)waypoint4.Time_Zulu) && !flag2)
							{
								dateTime = ((!Information.IsNothing((object)waypoint4.Time_Zulu_Weapon)) ? waypoint4.Time_Zulu_Weapon : waypoint4.Time_Zulu);
								text3 = ((dateTime.Value.Hour >= 10) ? (dateTime.Value.Hour + ":") : ("0" + dateTime.Value.Hour + ":"));
								text3 = ((dateTime.Value.Minute >= 10) ? (text3 + dateTime.Value.Minute + ":") : (text3 + "0" + dateTime.Value.Minute + ":"));
								text3 = ((dateTime.Value.Second >= 10) ? (text3 + dateTime.Value.Second) : (text3 + "0" + dateTime.Value.Second));
								if (waypoint4.Type == Waypoint.WaypointType.TakeOff)
								{
									string text4 = dateTime.Value.Year + "-";
									text4 = ((dateTime.Value.Month >= 10) ? (text4 + dateTime.Value.Month + "-") : (text4 + "0" + dateTime.Value.Month + "-"));
									text4 = ((dateTime.Value.Day >= 10) ? (text4 + dateTime.Value.Day) : (text4 + "0" + dateTime.Value.Day));
									string text5 = text4 + ", " + text3;
									int num7;
									if (Operators.CompareString(text5, ((Label)Label_LaunchDateAndTime).Text, true) == 0)
									{
										num7 = 1;
									}
									else
									{
										((Label)Label_LaunchDateAndTime).Text = text5;
										num7 = 1;
									}
									flag4 = (byte)num7 != 0;
								}
								else if (waypoint4.Type == Waypoint.WaypointType.Target || waypoint4.Type == Waypoint.WaypointType.WeaponTarget || waypoint4.IsStationStartWaypoint())
								{
									string text6 = dateTime.Value.Year + "-";
									text6 = ((dateTime.Value.Month >= 10) ? (text6 + dateTime.Value.Month + "-") : (text6 + "0" + dateTime.Value.Month + "-"));
									text6 = ((dateTime.Value.Day >= 10) ? (text6 + dateTime.Value.Day) : (text6 + "0" + dateTime.Value.Day));
									string text7 = text6 + ", " + text3;
									int num8;
									if (Operators.CompareString(text7, ((Label)Label_ObjectiveDateAndTime).Text, true) != 0)
									{
										((Label)Label_ObjectiveDateAndTime).Text = text7;
										num8 = 1;
									}
									else
									{
										num8 = 1;
									}
									flag5 = (byte)num8 != 0;
								}
							}
							else
							{
								text3 = "-";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_3]), text3))
							{
								dataRow[int_3] = text3;
							}
							string text8;
							if (!Information.IsNothing((object)dateTime) && !Information.IsNothing((object)waypoint4.Time_Local) && !flag2)
							{
								DateTime? dateTime2 = (Information.IsNothing((object)waypoint4.Time_Zulu_Weapon) ? waypoint4.Time_Local : waypoint4.Time_Local_Weapon);
								text8 = ((dateTime2.Value.Hour >= 10) ? (dateTime2.Value.Hour + ":") : ("0" + dateTime2.Value.Hour + ":"));
								text8 = ((dateTime2.Value.Minute >= 10) ? (text8 + dateTime2.Value.Minute + ":") : (text8 + "0" + dateTime2.Value.Minute + ":"));
								text8 = ((dateTime2.Value.Second >= 10) ? (text8 + dateTime2.Value.Second) : (text8 + "0" + dateTime2.Value.Second));
								waypoint4.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, UseCurrentScenarioTime: false, waypoint4.Latitude, waypoint4.Longitude, 0.0);
								if (Information.IsNothing((object)waypoint4.Time_Zulu_Weapon))
								{
									waypoint4.Time_Local = Misc.LocalTime(waypoint4.Time_Zulu.Value, waypoint4.Longitude, use_DST, dST_Start, dST_End);
								}
								else
								{
									waypoint4.Time_Local = Misc.LocalTime(waypoint4.Time_Zulu_Weapon.Value, waypoint4.Longitude, use_DST, dST_Start, dST_End);
								}
								text8 = text8 + " (" + SunModule.GetTimeOfDay_String(waypoint4.TimeOfDay, time, waypoint4.Longitude, use_DST, dST_Start, dST_End) + ")";
							}
							else
							{
								text8 = "-";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_4]), text8))
							{
								dataRow[int_4] = text8;
							}
							Waypoint.FixedFree fixedFree = ((Information.IsNothing((object)dateTime) || flag2) ? Waypoint.FixedFree.None : waypoint4.TimeFixed);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_5]), fixedFree))
							{
								dataRow[int_5] = fixedFree;
							}
							if (!waypoint3.GetDoctrine(Client.CurrentScenario).EMCON_Inherits)
							{
								if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
								{
									dataRow[int_24] = "Use mission EMCON";
								}
								else
								{
									string text9 = "";
									if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.Active)
									{
										text9 = "Radar active";
									}
									else if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.Passive)
									{
										text9 = "Radar passive";
									}
									if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.Active)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											text9 += ", ";
										}
										text9 += "Sonar active";
									}
									else if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.Passive)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											text9 += ", ";
										}
										text9 += "Sonar passive";
									}
									if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											text9 += ", ";
										}
										text9 += "OECM active";
									}
									else if (waypoint3.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Passive)
									{
										if (!string.IsNullOrEmpty(text9))
										{
											text9 += ", ";
										}
										text9 += "OECM passive";
									}
									if (string.IsNullOrEmpty(text9))
									{
										text9 = "Not configured";
									}
									if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_24]), text9))
									{
										dataRow[int_24] = text9;
									}
								}
							}
							else
							{
								dataRow[int_24] = "Not configured";
							}
							string text10 = Misc.CoordsToEnglish(waypoint4.Latitude, waypoint4.Longitude);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_25]), text10))
							{
								dataRow[int_25] = text10;
							}
							string text11 = "No Weapon";
							if (waypoint4.ReferenceWeapon_ID != 0)
							{
								Scenario theScen = Client.CurrentScenario;
								text11 = Weapon.GetNewWeapon(ref theScen, waypoint4.ReferenceWeapon_ID, bool_5: false).Name;
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_27]), text11))
							{
								dataRow[int_27] = text11;
							}
							string text12 = "no info";
							if (waypoint3.TargeteeringList != null && waypoint3.TargeteeringList.Count > 0)
							{
								Scenario theScen = Client.CurrentScenario;
								Weapon.GetNewWeapon(ref theScen, waypoint4.ReferenceWeapon_ID, bool_5: false);
								foreach (Mission.TargeteeringEntry targeteering in waypoint3.TargeteeringList)
								{
									if (Operators.CompareString(text12, "no info", true) == 0)
									{
										text12 = "";
									}
									text12 = text12 + " " + targeteering.Target_Description;
								}
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_28]), text12))
							{
								dataRow[int_28] = text12;
							}
							string text13 = "kg";
							if (aircraft.isUAVSizeClass1AndHasDBProvidedEndurance())
							{
								text13 = Aircraft.UAVSizeClass1FuelUnitOfMeasurementString;
							}
							string text14 = ((waypoint2.Leg_FuelRequired < -2.1474836E+09f) ? "Unknown, Aircraft Type and Loadout Type not set" : (((!Information.IsNothing((object)waypoint2.Time_Zulu) || (waypoint2.Type != Waypoint.WaypointType.HoldEnd && waypoint2.Type != Waypoint.WaypointType.StationEnd)) && waypoint2.Type != Waypoint.WaypointType.TakeOff) ? (Conversions.ToString((int)Math.Round(waypoint3.Leg_FuelRequired)) + " " + text13) : "-"));
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_11]), text14))
							{
								dataRow[int_11] = text14;
							}
							string text15;
							if (waypoint2.Type == Waypoint.WaypointType.WeaponTarget)
							{
								text15 = "";
							}
							else if (waypoint2.Leg_FuelRemaining > 2.1474836E+09f)
							{
								text15 = "Unknown";
							}
							else
							{
								byte? b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								bool? flag7 = (!flag6) ?? flag6;
								if (flag7 ?? true)
								{
									b = (byte?)useUnderwayRefuelAndReplenishment;
									bool? flag9;
									bool? flag8 = (flag9 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)));
									bool? flag10;
									flag9 = (flag10 = ((flag8.HasValue && flag9 != true) ? new bool?(false) : (Information.IsNothing((object)useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag9)));
									bool? obj;
									if (flag9.HasValue && flag10 != true)
									{
										obj = false;
									}
									else
									{
										b = (byte?)useUnderwayRefuelAndReplenishment2;
										bool? flag11;
										flag9 = (flag11 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
										obj = ((!flag9.HasValue) ? ((bool?)null) : ((flag11 == true) & flag10));
									}
									flag6 = obj;
									if (((!flag6) ?? flag6) == true && flag7.HasValue)
									{
										text15 = "Unknown, AAR allowed";
										int num9;
										if (((TabControl)TabControl_Aircraft).SelectedIndex != 0)
										{
											if (waypoint2.HasWingmanWaypoints())
											{
												if (((TabControl)TabControl_Aircraft).SelectedIndex == 1)
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_LeadElementWingman)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
												else if (((TabControl)TabControl_Aircraft).SelectedIndex == 2)
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElement)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
												else if (((TabControl)TabControl_Aircraft).SelectedIndex == 3)
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElementWingman)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
												else if (((TabControl)TabControl_Aircraft).SelectedIndex == 4)
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElement)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
												else if (((TabControl)TabControl_Aircraft).SelectedIndex == 5)
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElementWingman)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
												else
												{
													text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", AAR allowed";
													num9 = 0;
												}
											}
											else
											{
												text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", AAR allowed";
												num9 = 0;
											}
										}
										else
										{
											text15 = Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", AAR allowed";
											num9 = 0;
										}
										flag3 = (byte)num9 != 0;
										goto IL_1987;
									}
								}
								if (!flag3)
								{
									text15 = ((((TabControl)TabControl_Aircraft).SelectedIndex == 0) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13) : ((!waypoint2.HasWingmanWaypoints()) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13) : ((((TabControl)TabControl_Aircraft).SelectedIndex == 1) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_LeadElementWingman)) + " " + text13) : ((((TabControl)TabControl_Aircraft).SelectedIndex == 2) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElement)) + " " + text13) : ((((TabControl)TabControl_Aircraft).SelectedIndex == 3) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElementWingman)) + " " + text13) : ((((TabControl)TabControl_Aircraft).SelectedIndex == 4) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElement)) + " " + text13) : ((((TabControl)TabControl_Aircraft).SelectedIndex != 5) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13) : (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElementWingman)) + " " + text13))))))));
								}
								else
								{
									text15 = "Unknown, Station Time not set";
									text15 = ((((TabControl)TabControl_Aircraft).SelectedIndex == 0) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", Station Time not set") : ((!waypoint2.HasWingmanWaypoints()) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", Station Time not set") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 1) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_LeadElementWingman)) + " " + text13 + ", Station Time not set") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 2) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElement)) + " " + text13 + ", Station Time not set") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 3) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_SecondElementWingman)) + " " + text13 + ", Station Time not set") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 4) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElement)) + " " + text13 + ", Station Time not set") : ((((TabControl)TabControl_Aircraft).SelectedIndex != 5) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining)) + " " + text13 + ", Station Time not set") : (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRemaining_ThirdElementWingman)) + " " + text13 + ", Station Time not set"))))))));
								}
							}
							goto IL_1987;
							IL_21bd:
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_21]), num10))
							{
								dataRow[int_21] = num10;
							}
							if (waypoint2.Type == Waypoint.WaypointType.WeaponTarget)
							{
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_10]), "-"))
								{
									dataRow[int_10] = "-";
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_7]), "-"))
								{
									dataRow[int_7] = "-";
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_8]), Waypoint.FixedFree.None))
								{
									dataRow[int_8] = Waypoint.FixedFree.None;
								}
								int num11 = Waypoint.Formation_To_FormationSelection(waypoint2.FlightFormation);
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_18]), num11))
								{
									dataRow[int_18] = num11;
								}
								int tankerMaxDistance_Airborne = waypoint2.TankerMaxDistance_Airborne;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_19]), tankerMaxDistance_Airborne))
								{
									dataRow[int_19] = tankerMaxDistance_Airborne;
								}
								Waypoint.TurnRateCategory turnRate_Navigation = waypoint4.TurnRate_Navigation;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_22]), turnRate_Navigation))
								{
									dataRow[int_22] = turnRate_Navigation;
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_26]), Waypoint.SpeedToT.No))
								{
									dataRow[int_26] = Waypoint.SpeedToT.No;
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_23]), "-"))
								{
									dataRow[int_23] = "-";
								}
							}
							else
							{
								string text16;
								if (!Information.IsNothing((object)waypoint4.DesiredSpeedOverride) && !Information.IsNothing((object)waypoint4.DesiredSpeed))
								{
									float? desiredSpeed;
									float? num12 = (desiredSpeed = waypoint4.DesiredSpeed);
									text16 = (num12.HasValue ? Conversions.ToString(desiredSpeed.GetValueOrDefault()) : null) + " kt";
									if (!Information.IsNothing((object)SelectedFlight.get_ReferenceUnit(Client.CurrentScenario)) && waypoint4.DesiredAltitudeOverride)
									{
										if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											string text17 = text16;
											ActiveUnit.Throttle throttle_ = SelectedFlight.get_ReferenceUnit(Client.CurrentScenario).Kinematics.GetThrottleSuitableForThisSpeed(waypoint4.DesiredAltitude_TerrainFollowing.Value, waypoint4.DesiredSpeed.Value);
											text16 = text17 + " (" + wUwHjbqpahN(ref throttle_) + ")";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											string text18 = text16;
											ActiveUnit.Throttle throttle_ = SelectedFlight.get_ReferenceUnit(Client.CurrentScenario).Kinematics.GetThrottleSuitableForThisSpeed(waypoint4.DesiredAltitude.Value, waypoint4.DesiredSpeed.Value);
											text16 = text18 + " (" + wUwHjbqpahN(ref throttle_) + ")";
										}
									}
								}
								else if (!Information.IsNothing((object)waypoint4.ThrottlePreset) && waypoint4.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
								{
									ActiveUnit.Throttle throttle_ = (ActiveUnit.Throttle)waypoint4.ThrottlePreset;
									text16 = wUwHjbqpahN(ref throttle_);
									if (waypoint4.DesiredAltitudeOverride && !Information.IsNothing((object)waypoint4.DesiredSpeed))
									{
										string text19 = text16;
										float? desiredSpeed;
										float? num12 = (desiredSpeed = waypoint4.DesiredSpeed);
										text16 = text19 + " (" + ((!num12.HasValue) ? null : Conversions.ToString(desiredSpeed.GetValueOrDefault())) + " kt)";
									}
								}
								else
								{
									text16 = "Speed Not set!";
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_7]), text16))
								{
									dataRow[int_7] = text16;
								}
								Waypoint.FixedFree speedFixed = waypoint4.SpeedFixed;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_8]), speedFixed))
								{
									dataRow[int_8] = speedFixed;
								}
								string text20 = "";
								if (!Information.IsNothing((object)waypoint4.DesiredAltitudeOverride) && (!Information.IsNothing((object)waypoint4.DesiredAltitude) || (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))))
								{
									if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = (((int)Math.Round(waypoint4.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint4.DesiredAltitude_TerrainFollowing.Value)) + " m AGL"));
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											if ((int)Math.Round(waypoint4.DesiredAltitude.Value) == 0)
											{
												text20 = "Minimum";
											}
											else
											{
												float? desiredSpeed = waypoint4.DesiredAltitude;
												float num13 = ActiveUnit_AI.ConvertAltitudePresetToValue(ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude);
												if (((!desiredSpeed.HasValue) ? ((bool?)null) : new bool?(desiredSpeed.GetValueOrDefault() == num13)) == true)
												{
													waypoint4.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
													text20 = "Maximum";
												}
												else
												{
													text20 = Conversions.ToString((int)Math.Round(waypoint4.DesiredAltitude.Value)) + " m ASL";
												}
											}
										}
									}
									else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
									{
										text20 = (((int)Math.Round(waypoint4.DesiredAltitude_TerrainFollowing.Value) != 0) ? (Conversions.ToString((int)Math.Round((waypoint4.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " ft AGL") : "Minimum");
									}
									else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
									{
										if ((int)Math.Round(waypoint4.DesiredAltitude.Value) != 0)
										{
											float? desiredSpeed = waypoint4.DesiredAltitude;
											float num13 = ActiveUnit_AI.ConvertAltitudePresetToValue(ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude);
											if ((desiredSpeed.HasValue ? new bool?(desiredSpeed.GetValueOrDefault() == num13) : ((bool?)null)) != true)
											{
												text20 = Conversions.ToString((int)Math.Round((waypoint4.DesiredAltitude * 3.28084f).Value)) + " ft ASL";
											}
											else
											{
												waypoint4.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
												text20 = "Maximum";
											}
										}
										else
										{
											text20 = "Minimum";
										}
									}
								}
								else if (!Information.IsNothing((object)waypoint4.AltitudePreset) && waypoint4.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
								{
									switch (waypoint4.AltitudePreset)
									{
									case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
										text20 = "Minimum";
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
										if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
											{
												text20 = Conversions.ToString(305) + " m AGL";
											}
											else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
											{
												text20 = Conversions.ToString(305) + " m ASL";
											}
										}
										else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = Conversions.ToString(305) + " ft AGL";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											text20 = Conversions.ToString(305) + " ft ASL";
										}
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
										if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
											{
												text20 = Conversions.ToString(610) + " m AGL";
											}
											else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
											{
												text20 = Conversions.ToString(610) + " m ASL";
											}
										}
										else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = Conversions.ToString(610) + " ft AGL";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											text20 = Conversions.ToString(610) + " ft ASL";
										}
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.const_4:
										if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
											{
												text20 = Conversions.ToString(3658) + " m AGL";
											}
											else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
											{
												text20 = Conversions.ToString(3658) + " m ASL";
											}
										}
										else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = Conversions.ToString(3658) + " ft AGL";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											text20 = Conversions.ToString(3658) + " ft ASL";
										}
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.const_5:
										if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
											{
												text20 = Conversions.ToString(7620) + " ft AGL";
											}
											else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
											{
												text20 = Conversions.ToString(7620) + " ft ASL";
											}
										}
										else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = Conversions.ToString(7620) + " m AGL";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											text20 = Conversions.ToString(7620) + " m ASL";
										}
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.const_6:
										if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
											{
												text20 = Conversions.ToString(10973) + " m AGL";
											}
											else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
											{
												text20 = Conversions.ToString(10973) + " m ASL";
											}
										}
										else if (waypoint4.TerrainFollowing && !Information.IsNothing((object)waypoint4.DesiredAltitude_TerrainFollowing))
										{
											text20 = Conversions.ToString(10973) + " ft AGL";
										}
										else if (!Information.IsNothing((object)waypoint4.DesiredAltitude))
										{
											text20 = Conversions.ToString(10973) + " ft ASL";
										}
										break;
									case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
										text20 = "Maximum";
										break;
									}
								}
								else
								{
									text20 = "Altitude not set!";
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_10]), text20))
								{
									dataRow[int_10] = text20;
								}
								int num14 = Waypoint.Formation_To_FormationSelection(waypoint2.FlightFormation);
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_18]), num14))
								{
									dataRow[int_18] = num14;
								}
								int tankerMaxDistance_Airborne2 = waypoint2.TankerMaxDistance_Airborne;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_19]), tankerMaxDistance_Airborne2))
								{
									dataRow[int_19] = tankerMaxDistance_Airborne2;
								}
								Waypoint.TurnRateCategory turnRate_Navigation2 = waypoint4.TurnRate_Navigation;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_22]), turnRate_Navigation2))
								{
									dataRow[int_22] = turnRate_Navigation2;
								}
								Waypoint.SpeedToT speedAdjustmentToT = waypoint4.SpeedAdjustmentToT;
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_26]), speedAdjustmentToT))
								{
									dataRow[int_26] = speedAdjustmentToT;
								}
								if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_23]), "Something whatever"))
								{
									dataRow[int_23] = "Something whatever";
								}
							}
							num5++;
							continue;
							IL_1987:
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_12]), text15))
							{
								dataRow[int_12] = text15;
							}
							useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
							useUnderwayRefuelAndReplenishment = waypoint3.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
							string text21 = Misc.TimeString((long)Math.Round(waypoint3.Leg_Time_Straight + waypoint3.Leg_Time_Turn), 0, ReturnNo: false, ReturnZero: true);
							if (waypoint3.Leg_Time_Weapon > 0f)
							{
								text21 = text21 + " (Weapon: " + Misc.TimeString((long)Math.Round(waypoint3.Leg_Time_Weapon), 0, ReturnNo: false, ReturnZero: true) + ")";
							}
							else if (waypoint2.Type == Waypoint.WaypointType.HoldEnd || waypoint2.Type == Waypoint.WaypointType.StationEnd || waypoint2.Type == Waypoint.WaypointType.TakeOff)
							{
								text21 = "-";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_13]), text21))
							{
								dataRow[int_13] = text21;
							}
							string text22 = ((flag2 || waypoint2.Type == Waypoint.WaypointType.TakeOff) ? "-" : Misc.TimeString((long)Math.Round(waypoint3.Leg_TotalTime), 0, ReturnNo: false, ReturnZero: true));
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_15]), text22))
							{
								dataRow[int_15] = text22;
							}
							string text23 = ((waypoint2.Type == Waypoint.WaypointType.HoldEnd || waypoint2.Type == Waypoint.WaypointType.StationEnd || waypoint2.Type == Waypoint.WaypointType.TakeOff || (int)Math.Round(waypoint3.Leg_Distance_Straight + waypoint3.Leg_Distance_Turn) == 0) ? "-" : (Conversions.ToString((int)Math.Round(waypoint3.Leg_Distance_Straight + waypoint3.Leg_Distance_Turn)) + " nm"));
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_16]), text23))
							{
								dataRow[int_16] = text23;
							}
							string text24 = ((flag2 || waypoint2.Type == Waypoint.WaypointType.TakeOff) ? "-" : ((((TabControl)TabControl_Aircraft).SelectedIndex == 0) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance)) + " nm") : ((!waypoint2.HasWingmanWaypoints()) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance)) + " nm") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 1 && waypoint2.Leg_TotalDistance_LeadElementWingman > 0f) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance_LeadElementWingman)) + " nm") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 2 && waypoint2.Leg_TotalDistance_SecondElement > 0f) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance_SecondElement)) + " nm") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 3 && waypoint2.Leg_TotalDistance_SecondElementWingman > 0f) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance_SecondElementWingman)) + " nm") : ((((TabControl)TabControl_Aircraft).SelectedIndex == 4 && waypoint2.Leg_TotalDistance_ThirdElement > 0f) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance_ThirdElement)) + " nm") : ((((TabControl)TabControl_Aircraft).SelectedIndex != 5 || !(waypoint2.Leg_TotalDistance_ThirdElementWingman > 0f)) ? (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance)) + " nm") : (Conversions.ToString((int)Math.Round(waypoint2.Leg_TotalDistance_ThirdElementWingman)) + " nm")))))))));
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_17]), text24))
							{
								dataRow[int_17] = text24;
							}
							string text25 = ((waypoint4.Hold_Time > 0f && waypoint4.Station_Time == 0f && waypoint4.SpacingManeuver_Time == 0f) ? (Information.IsNothing((object)dateTime) ? "N/A" : (Misc.TimeString((long)Math.Round(waypoint4.Hold_Time), 0, ReturnNo: false, ReturnZero: true) + " Hold")) : ((waypoint4.Hold_Time == 0f && waypoint4.Station_Time == 0f && waypoint4.SpacingManeuver_Time > 0f) ? ((!(waypoint4.Separation_Time > 0f)) ? (Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : (Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " 90/90, " + Misc.TimeString((long)Math.Round(waypoint4.Separation_Time), 0, ReturnNo: false, ReturnZero: true) + " Separation")) : ((waypoint4.Hold_Time > 0f && waypoint4.Station_Time == 0f && waypoint4.SpacingManeuver_Time > 0f) ? ((!Information.IsNothing((object)dateTime)) ? (Misc.TimeString((long)Math.Round(waypoint4.Hold_Time), 0, ReturnNo: false, ReturnZero: true) + " Hold, " + Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : ("N/A Hold, " + Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing")) : ((waypoint4.Station_Time > 0f && SelectedFlight.Type == Mission._FlightType.FlightplanTemplate) ? (Misc.TimeString((long)Math.Round(waypoint4.Station_Time), 0, ReturnNo: false, ReturnZero: true) + " Station") : ((waypoint4.Hold_Time == 0f && waypoint4.Station_Time > 0f && waypoint4.SpacingManeuver_Time == 0f) ? ((!Information.IsNothing((object)dateTime)) ? (Misc.TimeString((long)Math.Round(waypoint4.Station_Time), 0, ReturnNo: false, ReturnZero: true) + " Station") : "N/A") : ((waypoint4.Hold_Time != 0f || !(waypoint4.Station_Time > 0f) || !(waypoint4.SpacingManeuver_Time > 0f)) ? "-" : ((!Information.IsNothing((object)dateTime)) ? (Misc.TimeString((long)Math.Round(waypoint4.Station_Time), 0, ReturnNo: false, ReturnZero: true) + " Station, " + Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : ("N/A Station, " + Misc.TimeString((long)Math.Round(waypoint4.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing"))))))));
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_14]), text25))
							{
								dataRow[int_14] = text25;
							}
							Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment3 = waypoint2.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
							Doctrine._UseUnderwayRefuelAndReplenishment useUnderwayRefuelAndReplenishment4 = (useUnderwayRefuelAndReplenishment3.HasValue ? useUnderwayRefuelAndReplenishment3.Value : Doctrine._UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers);
							int num15 = (int)useUnderwayRefuelAndReplenishment4;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_20]), num15))
							{
								dataRow[int_20] = num15;
							}
							int num16;
							if (waypoint2.GetDoctrine(Client.CurrentScenario).UseReplenishment_Inherits())
							{
								num16 = 0;
							}
							else
							{
								if (useUnderwayRefuelAndReplenishment4 != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
								{
									if (waypoint2.GetDoctrine(Client.CurrentScenario).ReplenishmentSelection_Inherits())
									{
										num10 = 3;
									}
									else
									{
										Doctrine._UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection = waypoint2.GetDoctrine(Client.CurrentScenario).get_ReplenishmentSelection(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
										if (!underwayRefuelAndReplenishmentSelection.HasValue)
										{
											Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection2 = Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest;
										}
										else
										{
											switch (underwayRefuelAndReplenishmentSelection.Value)
											{
											case Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest:
												break;
											case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly:
												num10 = 1;
												goto IL_21bd;
											case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround:
												num10 = 2;
												goto IL_21bd;
											case Doctrine._UnderwayRefuelAndReplenishmentSelection.NotConfigured:
												num10 = 4;
												goto IL_21bd;
											default:
												goto IL_21bd;
											}
										}
										num10 = 0;
									}
									goto IL_21bd;
								}
								num16 = 0;
							}
							num10 = num16;
							goto IL_21bd;
						}
					}
					finally
					{
						((Control)theFlightPlanWaypoints.DGV_Waypoints).ResumeLayout();
					}
					if (!flag4)
					{
						((Label)Label_LaunchDateAndTime).Text = "-";
					}
					if (!flag5)
					{
						((Label)Label_ObjectiveDateAndTime).Text = "-";
					}
					if (((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows.Count > 0)
					{
						WaypointList_Refresh = false;
						if (((BaseCollection)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index > 0 && SelectedRow != ((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index)
						{
							if (SelectedRow <= ((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows.Count - 1)
							{
								((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow].Selected = false;
							}
							SelectedRow = ((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Index;
						}
						((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[0].Selected = false;
						if (((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount > 0)
						{
							if (SelectedRow > ((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount - 1)
							{
								((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount - 1].Selected = false;
								((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).RowCount - 1].Selected = true;
							}
							else
							{
								((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow].Selected = false;
								((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).Rows[SelectedRow].Selected = true;
							}
						}
						SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypoints.DGV_Waypoints).SelectedRows[0]).Tag;
						WaypointList_Refresh = true;
					}
					else
					{
						SelectedWaypoint = null;
					}
				}
				else
				{
					((Form)this).Text = "Flightplan Editor for flight <NO FLIGHT SELECTED>";
				}
			}
			else
			{
				((Form)this).Text = "Flightplan Editor for flight <NO MISSION OR FLIGHT SELECTED>";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8()
	{
		ActiveUnit activeUnit = ((((TabControl)TabControl_Aircraft).SelectedIndex > 0) ? SelectedAircraft : list_0[0]);
		Aircraft aircraft = (Aircraft)activeUnit;
		((Label)Label_AircraftType).Text = aircraft.Name;
		((Label)Label_LoadoutName).Text = aircraft.LoadoutName;
		_ = SelectedFlight.FlightPlan;
		if (SelectedFlight.int_1 != aircraft.LoadoutDBID)
		{
			SecondaryFlightPlan secondaryFlightPlan = SelectedFlight.RetrieveSecondaryFP(aircraft.DBID, aircraft.LoadoutDBID);
			if (secondaryFlightPlan != null)
			{
				((Label)lblFPInUse).Text = " " + secondaryFlightPlan.string_0;
			}
		}
		else
		{
			((Label)lblFPInUse).Text = " Alpha";
		}
	}

	public Color method_9(int number1, int number2)
	{
		int red = number1 * 17 % 256;
		int green = number2 * 29 % 256;
		return Color.FromArgb(red, green, 0);
	}

	private void method_10(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendMissionCopyFlight(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			return;
		}
		CoreClientCode.CopyFlight_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		int mustRefreshMainForm;
		if (!((Control)Client.MissionEditorWindow).Visible)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_11(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendClearAircraftReplaceWithEmptySlots(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			return;
		}
		Mission selectedMission = SelectedMission;
		Scenario theScen = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		Mission.Flight theFlight = SelectedFlight;
		selectedMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref theFlight);
		SelectedFlight = theFlight;
		Client.CurrentSide = theSide;
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		RefreshGrid();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		if (!SelectedFlight.IsEscort && SelectedFlight.FlightPlan.Count() == 0)
		{
			Interaction.MsgBox((object)"Create a flightplan before assigning aircraft", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendMissionEditorFillEmptySlots(SelectedMission, isManual: true, SelectedFlight, fillFlightsWithNoAircraftSpecified: true);
			return;
		}
		Mission selectedMission = SelectedMission;
		Scenario currentScenario = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		bool IsManual = true;
		selectedMission.FillEmptySlots(currentScenario, ref theSide, ref IsManual, SelectedFlight, FillFlightsWithNoAircraftSpecified: true);
		Client.CurrentSide = theSide;
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		RefreshGrid();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.ReloadWindow();
		}
		if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		LoadGrid();
	}

	private void method_13(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Client.FlightPlanAircraftLoadoutWindow.SelectedMission = SelectedMission;
			Client.FlightPlanAircraftLoadoutWindow.SelectedFlight = SelectedFlight;
			if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
			{
				Client.FlightPlanAircraftLoadoutWindow.ReloadWindow();
				((Control)Client.FlightPlanAircraftLoadoutWindow).BringToFront();
			}
			else
			{
				((Control)Client.FlightPlanAircraftLoadoutWindow).Show();
			}
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (Operators.CompareString(mission.Name, Conversions.ToString(((ComboBox)Combo_CurrentPackage).SelectedItem), true) == 0)
			{
				SelectedMission = mission;
				break;
			}
		}
		if (SelectedMission.HasFlights())
		{
			SelectedFlight = SelectedMission.FlightList[0];
		}
		LoadGrid();
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (Operators.CompareString(flight.Callsign, Conversions.ToString(((ComboBox)Combo_CurrentFlightPlan).SelectedItem), true) == 0)
			{
				SelectedFlight = flight;
				break;
			}
		}
		LoadGrid();
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Invalid comparison between Unknown and I4
		if (Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		bool flag = false;
		Mission._FlightTask flightTask = Mission.Flight.TaskSelection_To_Task(((ComboBox)Combo_FlightTask).SelectedIndex);
		if (flightTask == Mission._FlightTask.QRA)
		{
			if (SelectedMission.MissionClass != Mission._MissionClass.Patrol && SelectedMission.MissionClass != Mission._MissionClass.Support)
			{
				Interaction.MsgBox((object)"Only patrol and support missions may use flights of type QRA.", (MsgBoxStyle)0, (object)null);
				RefreshStats(RefreshAircraftNameAndLoadout: false);
				return;
			}
			if (SelectedMission.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)SelectedMission;
				if (!patrol.ContinousCoverage_Enable)
				{
					Interaction.MsgBox((object)"The mission does not have Continous Coverage enabled, so QRA flights will not launch!", (MsgBoxStyle)0, (object)null);
				}
				else if (!patrol.ContinousCoverage_QRAEnable)
				{
					Interaction.MsgBox((object)"The mission does not have QRA enabled, so QRA flights will not launch!", (MsgBoxStyle)0, (object)null);
				}
			}
			if (SelectedMission.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)SelectedMission;
				if (supportMission.ContinousCoverage_Enable)
				{
					if (!supportMission.ContinousCoverage_QRAEnable)
					{
						Interaction.MsgBox((object)"The mission does not have QRA enabled, so QRA flights will not launch!", (MsgBoxStyle)0, (object)null);
					}
				}
				else
				{
					Interaction.MsgBox((object)"The mission does not have Continous Coverage enabled, so QRA flights will not launch!", (MsgBoxStyle)0, (object)null);
				}
			}
			if (!Information.IsNothing((object)SelectedMission) && SelectedMission.Category == Mission.MissionCategory.Package)
			{
				Interaction.MsgBox((object)"Packages cannot use flights of type QRA.", (MsgBoxStyle)0, (object)null);
				RefreshStats(RefreshAircraftNameAndLoadout: false);
				return;
			}
			if (SelectedFlight.FlightPlan.Count() > 0 && !Information.IsNothing((object)SelectedFlight.FlightPlan[0].Time_Zulu))
			{
				if ((int)Interaction.MsgBox((object)"Changing the flight task type to QRA will clear all waypoints times. Continue?", (MsgBoxStyle)4, (object)null) == 7)
				{
					RefreshWindow();
					return;
				}
				flag = true;
			}
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightTask(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flightTask);
			return;
		}
		CoreClientCode.ChangeFlightTask_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flightTask);
		theFlightPlanWaypoints.EnableAndDisableButtons();
		if (flag)
		{
			if (!Information.IsNothing((object)SelectedFlight))
			{
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission = SelectedMission;
				ActiveUnit theAU = SelectedFlight.get_ReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2;
				Waypoint[] theFlightplan = (selectedFlight2 = SelectedFlight).FlightPlan;
				float NecessaryFuel = 0f;
				float MissionFuel = 0f;
				MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, selectedMission, theAU, selectedFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SelectedMission.TakeOffTime, SelectedMission.TimeOnTarget, IsMFP: false);
				selectedFlight2.FlightPlan = theFlightplan;
			}
			RefreshGrid();
			AMP_General.RefreshFlightPlanErrorWindow();
			Client.MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
	}

	private void FlightPlanEditor_KeyDown(object sender, KeyEventArgs e)
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
			((Control)this).Hide();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		LoadGrid(fromSelectedIndexChange: true);
		if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
		}
		if (((((TabControl)TabControl_Aircraft).SelectedIndex > -1) & (list_0 != null)) && list_0.Count > 0)
		{
			SelectedAircraft = list_0[((TabControl)TabControl_Aircraft).SelectedIndex];
		}
	}

	private void method_18(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		bool_4 = true;
	}

	private void method_20(object sender, EventArgs e)
	{
		method_21();
	}

	private void method_21()
	{
		if (bool_4 && !Information.IsNothing((object)SelectedFlight))
		{
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendChangeFlightCallsign(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, TextBox_FlightCallsign.Text);
			}
			else
			{
				Mission.Flight selectedFlight = SelectedFlight;
				Scenario theScen = Client.CurrentScenario;
				Mission.Flight OriginalFlightPlan = SelectedFlight;
				selectedFlight.RenameFlightplanInFlightplanErrorList(ref theScen, ref OriginalFlightPlan, SelectedFlight.Callsign, TextBox_FlightCallsign.Text);
				SelectedFlight = OriginalFlightPlan;
				SelectedFlight.Callsign = TextBox_FlightCallsign.Text;
				if (((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.LoadWindow();
				}
				int mustRefreshMainForm;
				if (((Control)Client.MissionEditorWindow).Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
					mustRefreshMainForm = 1;
				}
				else
				{
					mustRefreshMainForm = 1;
				}
				Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
				MyProject.Forms.MainForm.MapRender_Tactical();
			}
		}
		bool_4 = false;
		RefreshStats(RefreshAircraftNameAndLoadout: false);
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
			{
				return;
			}
			if (SelectedFlight.ReferenceUnit_DBID != 0)
			{
				if (SelectedFlight.int_1 == 0)
				{
					Interaction.MsgBox((object)"Select loadout type before creating a flightplan.", (MsgBoxStyle)0, (object)null);
				}
				else
				{
					if (!method_30())
					{
						return;
					}
					if (Client.Realtime && Client.RealtimeAC)
					{
						Client.RealtimeTerminal.SendCreateFlightPlanSkeleton(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
						return;
					}
					CoreClientCode.GenerateMissionFlightPlanSkeleton_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
					LoadWindow();
					if (((Control)Client.AirTaskingOrderWindow).Visible)
					{
						Client.AirTaskingOrderWindow.RefreshWindow();
					}
					if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
					{
						Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
					}
					int mustRefreshMainForm;
					if (((Control)Client.MissionEditorWindow).Visible)
					{
						Client.MissionEditorWindow.RefreshAssignedUnits();
						Client.MissionEditorWindow.RefreshUnassignedUnits();
						mustRefreshMainForm = 1;
					}
					else
					{
						mustRefreshMainForm = 1;
					}
					Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
					MyProject.Forms.MainForm.MapRender_Tactical();
				}
			}
			else
			{
				Interaction.MsgBox((object)"Select aircraft and loadout type before creating a flightplan.", (MsgBoxStyle)0, (object)null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
			{
				return;
			}
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendDeleteFlightPlan(Client.CurrentScenario, Client.CurrentSide, SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight);
				return;
			}
			Mission selectedMission = SelectedMission;
			Scenario theScen = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			selectedMission.DeleteFlightplan(ref theScen, ref theSide, ref theSelectedFlight);
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
			Client.CurrentSide = theSide;
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			LoadWindow();
			int mustRefreshMainForm;
			if (((Control)Client.MissionEditorWindow).Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
				mustRefreshMainForm = 1;
			}
			else
			{
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		Mission._FlightType flightType = Mission.Flight.TypeSelection_To_Type(((ComboBox)Combo_FlightplanType).SelectedIndex);
		Mission.Flight selectedFlight = SelectedFlight;
		Scenario theScenario = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		bool num = AirTaskingOrder.ValidateChangeFlightType(selectedFlight, ref theScenario, ref theSide, ref SelectedMission, flightType);
		Client.CurrentSide = theSide;
		if (!num)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightType(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flightType);
			return;
		}
		Mission.Flight selectedFlight2 = SelectedFlight;
		theScenario = Client.CurrentScenario;
		theSide = Client.CurrentSide;
		AirTaskingOrder.ChangeFlightType(selectedFlight2, ref theScenario, ref theSide, ref SelectedMission, flightType);
		Client.CurrentSide = theSide;
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		RefreshGrid();
		theFlightPlanWaypoints.EnableAndDisableButtons();
		theFlightPlanWaypoints.DisplayLocks();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		AMP_General.RefreshFlightPlanErrorWindow();
	}

	private void method_25(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing((object)theFlightPlanWaypoints) || Information.IsNothing((object)theFlightPlanWaypoints.DGV_Waypoints) || Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
			{
				return;
			}
			bool flag = false;
			int num = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows.Count - 1;
			Waypoint theSelectedWaypoint = default(Waypoint);
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[i];
				theSelectedWaypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (theSelectedWaypoint.Type != Waypoint.WaypointType.TakeOff)
				{
					if (val.Selected)
					{
						val.Selected = false;
					}
					continue;
				}
				val.Selected = true;
				flag = true;
				break;
			}
			if (flag && !Information.IsNothing((object)theSelectedWaypoint))
			{
				Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref SelectedMission;
				Mission.Flight theSelectedFlight = SelectedFlight;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
				SelectedFlight = theSelectedFlight;
				((Control)Client.FlightPlanTimeWindow).Show();
				((Control)Client.FlightPlanTimeWindow).BringToFront();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Information.IsNothing((object)theFlightPlanWaypoints) || Information.IsNothing((object)theFlightPlanWaypoints.DGV_Waypoints) || Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
			{
				return;
			}
			bool flag = false;
			int num = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows.Count - 1;
			Waypoint theSelectedWaypoint = default(Waypoint);
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[i];
				theSelectedWaypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (theSelectedWaypoint == null)
				{
					DarkMessageBox.ShowInformation("Create a flightplan in order to edit the Time on Target", "Flightplan not found");
				}
				Waypoint.WaypointType type = theSelectedWaypoint.Type;
				if (type != Waypoint.WaypointType.Target && (uint)(type - 19) > 5u)
				{
					if (val.Selected)
					{
						val.Selected = false;
					}
					continue;
				}
				val.Selected = true;
				flag = true;
				break;
			}
			if (flag && !Information.IsNothing((object)theSelectedWaypoint))
			{
				Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref SelectedMission;
				Mission.Flight theSelectedFlight = SelectedFlight;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
				SelectedFlight = theSelectedFlight;
				((Control)Client.FlightPlanTimeWindow).Show();
				((Control)Client.FlightPlanTimeWindow).BringToFront();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		Scenario theScen = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		ref Mission selectedMission = ref SelectedMission;
		Mission.Flight selectedFlight = SelectedFlight;
		ref string takeOffLocation_HostUnitObjectName = ref SelectedFlight.TakeOffLocation_HostUnitObjectName;
		ref string takeOffLocation_HostUnitObjectID = ref SelectedFlight.TakeOffLocation_HostUnitObjectID;
		Module_Unit.Unit theSelectedUnit = Client.SelectedUnit;
		ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = Client.CurrentSide.SelectedUnits;
		bool num = ValidateChangeFlightLocation(ref theScen, ref theSide, ref selectedMission, selectedFlight, ref takeOffLocation_HostUnitObjectName, ref takeOffLocation_HostUnitObjectID, ref theSelectedUnit, ref theSelectedUnits, IsTakeOffLocation: true, IsLandingLocation: false, IsDiversionLocation: false);
		Client.CurrentSide = theSide;
		if (!num)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightLocation(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, Client.SelectedUnit, isTakeoffLocation: true, isLandingLocation: false, isDivertLocation: false);
			return;
		}
		theScen = Client.CurrentScenario;
		theSide = Client.CurrentSide;
		ref Mission selectedMission2 = ref SelectedMission;
		Mission.Flight selectedFlight2 = SelectedFlight;
		ref string takeOffLocation_HostUnitObjectName2 = ref SelectedFlight.TakeOffLocation_HostUnitObjectName;
		ref string takeOffLocation_HostUnitObjectID2 = ref SelectedFlight.TakeOffLocation_HostUnitObjectID;
		theSelectedUnit = Client.SelectedUnit;
		CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref selectedMission2, selectedFlight2, ref takeOffLocation_HostUnitObjectName2, ref takeOffLocation_HostUnitObjectID2, ref theSelectedUnit, IsTakeOffLocation: true, IsLandingLocation: false, IsDiversionLocation: false);
		Client.CurrentSide = theSide;
		LoadWindow();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
		}
		if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		int mustRefreshMainForm;
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_28(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		Scenario theScen = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		ref Mission selectedMission = ref SelectedMission;
		Mission.Flight selectedFlight = SelectedFlight;
		ref string landingLocation_HostUnitObjectName = ref SelectedFlight.LandingLocation_HostUnitObjectName;
		ref string landingLocation_HostUnitObjectID = ref SelectedFlight.LandingLocation_HostUnitObjectID;
		Module_Unit.Unit theSelectedUnit = Client.SelectedUnit;
		ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = Client.CurrentSide.SelectedUnits;
		bool num = ValidateChangeFlightLocation(ref theScen, ref theSide, ref selectedMission, selectedFlight, ref landingLocation_HostUnitObjectName, ref landingLocation_HostUnitObjectID, ref theSelectedUnit, ref theSelectedUnits, IsTakeOffLocation: false, IsLandingLocation: true, IsDiversionLocation: false);
		Client.CurrentSide = theSide;
		if (!num)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightLocation(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, Client.SelectedUnit, isTakeoffLocation: false, isLandingLocation: true, isDivertLocation: false);
			return;
		}
		theScen = Client.CurrentScenario;
		theSide = Client.CurrentSide;
		ref Mission selectedMission2 = ref SelectedMission;
		Mission.Flight selectedFlight2 = SelectedFlight;
		ref string landingLocation_HostUnitObjectName2 = ref SelectedFlight.LandingLocation_HostUnitObjectName;
		ref string landingLocation_HostUnitObjectID2 = ref SelectedFlight.LandingLocation_HostUnitObjectID;
		theSelectedUnit = Client.SelectedUnit;
		CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref selectedMission2, selectedFlight2, ref landingLocation_HostUnitObjectName2, ref landingLocation_HostUnitObjectID2, ref theSelectedUnit, IsTakeOffLocation: false, IsLandingLocation: true, IsDiversionLocation: false);
		Client.CurrentSide = theSide;
		LoadWindow();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
		}
		int mustRefreshMainForm;
		if (!((Control)Client.MissionEditorWindow).Visible)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_29(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		Scenario theScen = Client.CurrentScenario;
		Side theSide = Client.CurrentSide;
		ref Mission selectedMission = ref SelectedMission;
		Mission.Flight selectedFlight = SelectedFlight;
		ref string alternativeLandingLocation_HostUnitObjectName = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectName;
		ref string alternativeLandingLocation_HostUnitObjectID = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectID;
		Module_Unit.Unit theSelectedUnit = Client.SelectedUnit;
		ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = Client.CurrentSide.SelectedUnits;
		bool num = ValidateChangeFlightLocation(ref theScen, ref theSide, ref selectedMission, selectedFlight, ref alternativeLandingLocation_HostUnitObjectName, ref alternativeLandingLocation_HostUnitObjectID, ref theSelectedUnit, ref theSelectedUnits, IsTakeOffLocation: false, IsLandingLocation: false, IsDiversionLocation: true);
		Client.CurrentSide = theSide;
		if (!num)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightLocation(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, Client.SelectedUnit, isTakeoffLocation: false, isLandingLocation: false, isDivertLocation: true);
			return;
		}
		theScen = Client.CurrentScenario;
		theSide = Client.CurrentSide;
		ref Mission selectedMission2 = ref SelectedMission;
		Mission.Flight selectedFlight2 = SelectedFlight;
		ref string alternativeLandingLocation_HostUnitObjectName2 = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectName;
		ref string alternativeLandingLocation_HostUnitObjectID2 = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectID;
		theSelectedUnit = Client.SelectedUnit;
		CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref selectedMission2, selectedFlight2, ref alternativeLandingLocation_HostUnitObjectName2, ref alternativeLandingLocation_HostUnitObjectID2, ref theSelectedUnit, IsTakeOffLocation: false, IsLandingLocation: false, IsDiversionLocation: true);
		Client.CurrentSide = theSide;
		LoadWindow();
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
		}
		int mustRefreshMainForm;
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void RecalculateFlightPlanFuelAndTimes(bool RefreshMainform, bool RefreshFlightplanEditorWindow, bool RefreshFlightplanEditorWindow_Limited, bool RefreshFlightplanEditorWindow_ReloadhGrid, bool RefreshFlightplanEditorWindow_DrawLocks)
	{
		try
		{
			if (Client.Realtime && !Client.RealtimeAC)
			{
				return;
			}
			if (!Information.IsNothing((object)SelectedFlight))
			{
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission = SelectedMission;
				ActiveUnit theAU = SelectedFlight.get_ReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2;
				Waypoint[] theFlightplan = (selectedFlight2 = SelectedFlight).FlightPlan;
				float NecessaryFuel = 0f;
				float MissionFuel = 0f;
				MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, selectedMission, theAU, selectedFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SelectedMission.TakeOffTime, SelectedMission.TimeOnTarget, IsMFP: false);
				selectedFlight2.FlightPlan = theFlightplan;
			}
			if (((Control)this).Visible && RefreshFlightplanEditorWindow)
			{
				if (!RefreshFlightplanEditorWindow_Limited)
				{
					if (RefreshFlightplanEditorWindow_ReloadhGrid)
					{
						LoadGrid();
					}
					else
					{
						RefreshGrid();
						if (RefreshFlightplanEditorWindow_DrawLocks)
						{
							theFlightPlanWaypoints.DisplayLocks();
						}
					}
				}
				else
				{
					Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
					if (RefreshFlightplanEditorWindow_ReloadhGrid)
					{
						LoadGrid();
					}
					else
					{
						RefreshGrid();
						if (RefreshFlightplanEditorWindow_DrawLocks)
						{
							theFlightPlanWaypoints.DisplayLocks();
						}
					}
					Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
				}
			}
			if (RefreshMainform)
			{
				AMP_General.RefreshFlightPlanErrorWindow();
				Client.MustRefreshMainForm = true;
				MyProject.Forms.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_30()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)SelectedFlight))
		{
			if (Information.IsNothing((object)Client.FlightPlanEditorWindow.SelectedFlight.get_ReferenceUnit(Client.CurrentScenario)))
			{
				if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.TakeOffLocation_HostUnitObjectID))
				{
					Interaction.MsgBox((object)"No take-off location has been set. Select the airfield or ship on the tactical map from where you wish to take off, press the 'Change take-off location' button, and try creating the flightplan again.", (MsgBoxStyle)0, (object)null);
					return false;
				}
				if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.LandingLocation_HostUnitObjectID))
				{
					Interaction.MsgBox((object)"No landing location has been set. Select the airfield or ship on the tactical map from where you wish to take off, press the 'Change take-off location' button, and try creating the flightplan again.", (MsgBoxStyle)0, (object)null);
					return false;
				}
			}
			else
			{
				Aircraft aircraft = (Aircraft)Client.FlightPlanEditorWindow.SelectedFlight.get_ReferenceUnit(Client.CurrentScenario);
				if (aircraft.get_Latitude((GlobalVariables.BooleanObject)null) == 0.0 && aircraft.get_Longitude((GlobalVariables.BooleanObject)null) == 0.0)
				{
					if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.TakeOffLocation_HostUnitObjectID))
					{
						Interaction.MsgBox((object)"No take-off location has been set. Select the airfield or ship on the tactical map from where you wish to take off, press the 'Change take-off location' button, and try creating the flightplan again.", (MsgBoxStyle)0, (object)null);
						return false;
					}
					if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.LandingLocation_HostUnitObjectID))
					{
						Interaction.MsgBox((object)"No landing location has been set. Select the airfield or ship on the tactical map from where you wish to take off, press the 'Change take-off location' button, and try creating the flightplan again.", (MsgBoxStyle)0, (object)null);
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	private void method_31(object sender, EventArgs e)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
			{
				return;
			}
			if (SelectedFlight.ReferenceUnit_DBID == 0)
			{
				Interaction.MsgBox((object)"Select aircraft and loadout type before creating a flightplan.", (MsgBoxStyle)0, (object)null);
			}
			else if (SelectedFlight.int_1 != 0)
			{
				if (!method_30())
				{
					return;
				}
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendCreateFlightPlanFull(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
				}
				else
				{
					CoreClientCode.GenerateMissionFlightPlanFull_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
					LoadWindow();
					if (((Control)Client.AirTaskingOrderWindow).Visible)
					{
						Client.AirTaskingOrderWindow.RefreshWindow();
					}
					if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
					{
						Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
					}
					int mustRefreshMainForm;
					if (((Control)Client.MissionEditorWindow).Visible)
					{
						Client.MissionEditorWindow.RefreshAssignedUnits();
						Client.MissionEditorWindow.RefreshUnassignedUnits();
						mustRefreshMainForm = 1;
					}
					else
					{
						mustRefreshMainForm = 1;
					}
					Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
					MyProject.Forms.MainForm.MapRender_Tactical();
				}
				List<ActiveUnit> source = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(Client.FlightPlanEditorWindow.SelectedMission, Client.CurrentScenario)
					where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
					select x).ToList();
				source = source.Where([SpecialName] (ActiveUnit x) => Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, Client.FlightPlanEditorWindow.SelectedFlight.Callsign, true) == 0).ToList();
				string text = "";
				foreach (ActiveUnit item in source)
				{
					float num = 0f;
					int num2 = item.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() - 1;
					for (int num3 = 1; num3 <= num2; num3++)
					{
						num += item.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num3].Leg_Distance_Straight;
					}
					float num4 = item.Kinematics.MaxRange(BingoFuelCheck: true, null, null);
					if (num > num4)
					{
						text = text + Environment.NewLine + "The flightplan distance is " + num + " nm while the aircraft " + item.Name + " maximum range is " + num4;
					}
				}
				if (Operators.CompareString(text, "", true) != 0)
				{
					DarkMessageBox.ShowError(text, "ERROR AT LEAST ONE AIRCRAFT WILL CRASH");
				}
			}
			else
			{
				Interaction.MsgBox((object)"Select loadout type before creating a flightplan.", (MsgBoxStyle)0, (object)null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool ValidateChangeFlightLocation(ref Scenario theScen, ref Side theSide, ref Mission theMission, Mission.Flight theFlight, ref string theLocationName, ref string theLocationObjectID, ref Module_Unit.Unit theSelectedUnit, ref ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits, bool IsTakeOffLocation, bool IsLandingLocation, bool IsDiversionLocation)
	{
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__300-0 arg = default(_Closure$__300-0);
		_Closure$__300-0 CS$<>8__locals8 = new _Closure$__300-0(arg);
		CS$<>8__locals8.$VB$Local_theFlight = theFlight;
		if (theSelectedUnits.Count <= 1)
		{
			if (Information.IsNothing((object)theSelectedUnit))
			{
				Interaction.MsgBox((object)"Error! No unit has been selected on the map. To change the location, select a single base or ship that can host aircraft of this type, and try again.", (MsgBoxStyle)0, (object)null);
				return false;
			}
			if (IsTakeOffLocation && CS$<>8__locals8.$VB$Local_theFlight.get_Status(theScen) != Mission._FlightStatus.None)
			{
				Interaction.MsgBox((object)"Error! The flight has already launched, so cannot change take-off location!", (MsgBoxStyle)0, (object)null);
				int result;
				if (!IsLandingLocation)
				{
					result = 0;
				}
				else
				{
					if (IsDiversionLocation)
					{
						IsTakeOffLocation = false;
						goto IL_0071;
					}
					result = 0;
				}
				return (byte)result != 0;
			}
			goto IL_0071;
		}
		Interaction.MsgBox((object)"Error! Multiple units on the map has been selected. To change the location, select a single base or ship that can host aircraft of this type, and try again.", (MsgBoxStyle)0, (object)null);
		return false;
		IL_0071:
		if (Operators.CompareString(theLocationObjectID, theSelectedUnit.ObjectID, true) != 0)
		{
			if (!theSelectedUnit.IsSubmarine)
			{
				if (theSelectedUnit.IsGroup)
				{
					Group obj = (Group)theSelectedUnit;
					if (obj.Type == Group.GroupType.SurfaceGroup)
					{
						Interaction.MsgBox((object)"Error! Aircraft can only take off or land on ships, not ship groups.", (MsgBoxStyle)0, (object)null);
						return false;
					}
					if (obj.Type == Group.GroupType.SubGroup)
					{
						Interaction.MsgBox((object)"Error! Aircraft can not take off or land on submarines.", (MsgBoxStyle)0, (object)null);
						return false;
					}
				}
				if (IsTakeOffLocation)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen).Where([SpecialName] (ActiveUnit theAU) =>
					{
						int result2;
						if (!theAU.Navigator.HasFlight)
						{
							result2 = 0;
						}
						else if (!theAU.IsAircraft)
						{
							result2 = 0;
						}
						else
						{
							if (!theAU.IsOperating())
							{
								return theAU.Navigator.get_Flight(HierarchySearch: true) == CS$<>8__locals8.$VB$Local_theFlight;
							}
							result2 = 0;
						}
						return (byte)result2 != 0;
					}).ToList());
					if (list.Count > 0 && (int)Interaction.MsgBox((object)"You have selected to change the take-off location for this flightplan. The aircraft will be removed from the flightplan because they are not present at the take-off location, and replaced by empty slots that can be filled with aircraft later on. Do you wish to proceed?", (MsgBoxStyle)4, (object)null) == 7)
					{
						return false;
					}
				}
				if (!theSelectedUnit.IsActiveUnit)
				{
					Interaction.MsgBox((object)"Error! No unit has been selected on the map. To change the location, select a single base or ship that can host aircraft of this type, and try again.", (MsgBoxStyle)0, (object)null);
					return false;
				}
				Aircraft aircraft = (Aircraft)CS$<>8__locals8.$VB$Local_theFlight.get_ReferenceUnit(theScen);
				bool flag = !theSelectedUnit.IsGroup;
				bool flag2 = false;
				bool flag3 = false;
				if (theSelectedUnit.IsGroup)
				{
					if (((Group)theSelectedUnit).Type == Group.GroupType.AirBase)
					{
						flag3 = true;
					}
					else
					{
						flag2 = true;
					}
				}
				if (aircraft != null)
				{
					if ((flag || flag3) && !aircraft.AirOps.ThisUnitCanHostMe((ActiveUnit)theSelectedUnit, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						Interaction.MsgBox((object)("Error! " + theSelectedUnit.Name + " cannot host the aircraft. To change the location, select a single base or ship that can host aircraft of this type, and try again."), (MsgBoxStyle)0, (object)null);
						return false;
					}
					if (flag2)
					{
						Module_Unit.Unit unit = null;
						foreach (ActiveUnit value in ((Group)theSelectedUnit).Units.Values)
						{
							if (aircraft.AirOps.ThisUnitCanHostMe(value, HumanFeedbackNeeded: false).ResponseBoolean)
							{
								unit = value;
								break;
							}
						}
						if (unit == null)
						{
							Interaction.MsgBox((object)("Error! " + theSelectedUnit.Name + " cannot host the aircraft. To change the location, select a single base or ship that can host aircraft of this type, and try again."), (MsgBoxStyle)0, (object)null);
							return false;
						}
					}
				}
				if (IsTakeOffLocation && CS$<>8__locals8.$VB$Local_theFlight.FlightPlan.Count() > 0)
				{
					Waypoint[] flightPlan = CS$<>8__locals8.$VB$Local_theFlight.FlightPlan;
					Waypoint waypoint2 = default(Waypoint);
					foreach (Waypoint waypoint in flightPlan)
					{
						if (waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							waypoint2 = waypoint;
							break;
						}
					}
					if (waypoint2 == null)
					{
						Interaction.MsgBox((object)"Error! Could not find the take-off waypoint in the flightplan!", (MsgBoxStyle)0, (object)null);
						return false;
					}
				}
				if (IsLandingLocation && CS$<>8__locals8.$VB$Local_theFlight.FlightPlan.Count() > 0)
				{
					Waypoint[] flightPlan2 = CS$<>8__locals8.$VB$Local_theFlight.FlightPlan;
					Waypoint waypoint4 = default(Waypoint);
					foreach (Waypoint waypoint3 in flightPlan2)
					{
						if (waypoint3.Type != Waypoint.WaypointType.LandingMarshal && waypoint3.Type == Waypoint.WaypointType.Land)
						{
							waypoint4 = waypoint3;
							break;
						}
					}
					if (waypoint4 == null)
					{
						Interaction.MsgBox((object)"Error! Could not find the land waypoint in the flightplan!", (MsgBoxStyle)0, (object)null);
						return false;
					}
				}
				return !IsDiversionLocation || true;
			}
			Interaction.MsgBox((object)"Error! Aircraft cannot take off or land on submarines.", (MsgBoxStyle)0, (object)null);
			return false;
		}
		return false;
	}

	private void method_32(object object_0)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_5)
		{
			bool_5 = true;
			int num = 1;
			while (method_33() && Operators.CompareString(TextBox_FlightCallsign.Text, "New Flight", true) == 0)
			{
				TextBox_FlightCallsign.Text = "New Flight " + num;
			}
			if (method_33())
			{
				DarkMessageBox.ShowError("Flight witth such name already exists", "wrong flight name");
			}
			bool_5 = false;
		}
	}

	private bool method_33()
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (flight != SelectedFlight && Operators.CompareString(flight.Callsign, TextBox_FlightCallsign.Text, true) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
