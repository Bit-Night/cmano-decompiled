using System;
using System.Collections;
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
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AirTaskingOrder : DarkSecondaryFormBase
{
	public enum AirTaskingOrderSortType : byte
	{
		MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout,
		TakeOffTime_Task_Aircraft_Loadout,
		ObjectiveTime_Task_Aircraft_Loadout
	}

	[CompilerGenerated]
	internal sealed class _Closure$__234-0
	{
		public Mission.Flight $VB$Local_theFlight;

		public Func<Mission, bool> $I0;

		public _Closure$__234-0(_Closure$__234-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFlight = arg0.$VB$Local_theFlight;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Mission theM)
		{
			return Operators.CompareString(theM.Name, $VB$Local_theFlight.ParentMissionOrPackageName, true) == 0;
		}

		static _Closure$__234-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_AirTaskingOrder")]
	private DarkDataGridView _DGV_AirTaskingOrder;

	[AccessedThroughProperty("ComboBox_PlannedFlightPlanVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_PlannedFlightPlanVisibility;

	[AccessedThroughProperty("Button_CreateFlight")]
	[CompilerGenerated]
	private DarkUIButton _Button_CreateFlight;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_FlightPlanEditor")]
	private DarkUIButton _Button_FlightPlanEditor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeAircraftType")]
	private DarkUIButton _Button_ChangeAircraftType;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteFlight")]
	private DarkUIButton _Button_DeleteFlight;

	[AccessedThroughProperty("ComboBox_AirborneFlightPlanVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_AirborneFlightPlanVisibility;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CopyFlight")]
	private DarkUIButton _Button_CopyFlight;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeTakeOffTime")]
	private DarkUIButton _Button_ChangeTakeOffTime;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ChangeObjectiveTime")]
	private DarkUIButton _Button_ChangeObjectiveTime;

	[AccessedThroughProperty("Button_ClearTime")]
	[CompilerGenerated]
	private DarkUIButton _Button_ClearTime;

	[AccessedThroughProperty("ComboBox_AirTaskingOrderSorting")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_AirTaskingOrderSorting;

	[AccessedThroughProperty("ComboBox_AirTaskingOrderFilter")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_AirTaskingOrderFilter;

	[CompilerGenerated]
	private bool bool_2;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public List<Mission.Flight> SelectedFlightsList;

	private bool bool_3;

	private string string_0;

	private int int_0;

	private DataTable dataTable_0;

	private AirTaskingOrderSortType airTaskingOrderSortType_0;

	public string AirTaskingOrderFilterSetting;

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

	private Bitmap bitmap_0;

	private Bitmap bitmap_1;

	private Bitmap bitmap_2;

	private Bitmap bitmap_3;

	private Bitmap bitmap_4;

	internal virtual DarkDataGridView DGV_AirTaskingOrder
	{
		[CompilerGenerated]
		get
		{
			return _DGV_AirTaskingOrder;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellPaintingEventHandler val = new DataGridViewCellPaintingEventHandler(method_10);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_11);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_12);
			EventHandler eventHandler = method_13;
			EventHandler eventHandler2 = method_16;
			DarkDataGridView darkDataGridView = _DGV_AirTaskingOrder;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellPainting -= val;
				((DataGridView)darkDataGridView).CellClick -= val2;
				((DataGridView)darkDataGridView).CellValueChanged -= val3;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged -= eventHandler;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler2;
			}
			_DGV_AirTaskingOrder = value;
			darkDataGridView = _DGV_AirTaskingOrder;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellPainting += val;
				((DataGridView)darkDataGridView).CellClick += val2;
				((DataGridView)darkDataGridView).CellValueChanged += val3;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged += eventHandler;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox ComboBox_PlannedFlightPlanVisibility
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_PlannedFlightPlanVisibility;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIComboBox darkUIComboBox = _ComboBox_PlannedFlightPlanVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_PlannedFlightPlanVisibility = value;
			darkUIComboBox = _ComboBox_PlannedFlightPlanVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_CreateFlight
	{
		[CompilerGenerated]
		get
		{
			return _Button_CreateFlight;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _Button_CreateFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CreateFlight = value;
			darkUIButton = _Button_CreateFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_FlightPlanEditor
	{
		[CompilerGenerated]
		get
		{
			return _Button_FlightPlanEditor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _Button_FlightPlanEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_FlightPlanEditor = value;
			darkUIButton = _Button_FlightPlanEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ChangeAircraftType
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeAircraftType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkUIButton darkUIButton = _Button_ChangeAircraftType;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ChangeAircraftType = value;
			darkUIButton = _Button_ChangeAircraftType;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_DeleteFlight
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeleteFlight;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _Button_DeleteFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_DeleteFlight = value;
			darkUIButton = _Button_DeleteFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIComboBox ComboBox_AirborneFlightPlanVisibility
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_AirborneFlightPlanVisibility;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIComboBox darkUIComboBox = _ComboBox_AirborneFlightPlanVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_AirborneFlightPlanVisibility = value;
			darkUIComboBox = _ComboBox_AirborneFlightPlanVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_CopyFlight
	{
		[CompilerGenerated]
		get
		{
			return _Button_CopyFlight;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _Button_CopyFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CopyFlight = value;
			darkUIButton = _Button_CopyFlight;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ChangeTakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeTakeOffTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIButton darkUIButton = _Button_ChangeTakeOffTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ChangeTakeOffTime = value;
			darkUIButton = _Button_ChangeTakeOffTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ChangeObjectiveTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeObjectiveTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIButton darkUIButton = _Button_ChangeObjectiveTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ChangeObjectiveTime = value;
			darkUIButton = _Button_ChangeObjectiveTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIButton darkUIButton = _Button_ClearTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearTime = value;
			darkUIButton = _Button_ClearTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_AirTaskingOrderSorting
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_AirTaskingOrderSorting;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIComboBox darkUIComboBox = _ComboBox_AirTaskingOrderSorting;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_AirTaskingOrderSorting = value;
			darkUIComboBox = _ComboBox_AirTaskingOrderSorting;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_AirTaskingOrderFilter
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_AirTaskingOrderFilter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkUIComboBox darkUIComboBox = _ComboBox_AirTaskingOrderFilter;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_AirTaskingOrderFilter = value;
			darkUIComboBox = _ComboBox_AirTaskingOrderFilter;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("MissionOrPackage")]
	internal virtual DataGridViewTextBoxColumn MissionOrPackage { get; set; }

	[field: AccessedThroughProperty("Callsign")]
	internal virtual DataGridViewTextBoxColumn Callsign { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewComboBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

	[field: AccessedThroughProperty("Task")]
	internal virtual DataGridViewComboBoxColumn Task { get; set; }

	[field: AccessedThroughProperty("AircraftType")]
	internal virtual DataGridViewTextBoxColumn AircraftType { get; set; }

	[field: AccessedThroughProperty("LoadoutType")]
	internal virtual DataGridViewTextBoxColumn LoadoutType { get; set; }

	[field: AccessedThroughProperty("TakeOffTimeZulu")]
	internal virtual DataGridViewTextBoxColumn TakeOffTimeZulu { get; set; }

	[field: AccessedThroughProperty("TakeOffTimeLocal")]
	internal virtual DataGridViewTextBoxColumn TakeOffTimeLocal { get; set; }

	[field: AccessedThroughProperty("TakeOffTimeFixed")]
	internal virtual DataGridViewTextBoxColumn TakeOffTimeFixed { get; set; }

	[field: AccessedThroughProperty("TakeOffTimeImg")]
	internal virtual DataGridViewImageColumn TakeOffTimeImg { get; set; }

	[field: AccessedThroughProperty("ObjectiveTimeZulu")]
	internal virtual DataGridViewTextBoxColumn ObjectiveTimeZulu { get; set; }

	[field: AccessedThroughProperty("ObjectiveTimeLocal")]
	internal virtual DataGridViewTextBoxColumn ObjectiveTimeLocal { get; set; }

	[field: AccessedThroughProperty("ObjectiveTimeFixed")]
	internal virtual DataGridViewTextBoxColumn ObjectiveTimeFixed { get; set; }

	[field: AccessedThroughProperty("ObjectiveTimeImg")]
	internal virtual DataGridViewImageColumn ObjectiveTimeImg { get; set; }

	[field: AccessedThroughProperty("TakeOffLocation")]
	internal virtual DataGridViewTextBoxColumn TakeOffLocation { get; set; }

	[field: AccessedThroughProperty("LandingLocation")]
	internal virtual DataGridViewTextBoxColumn LandingLocation { get; set; }

	[field: AccessedThroughProperty("AlternativeLandingLocation")]
	internal virtual DataGridViewTextBoxColumn AlternativeLandingLocation { get; set; }

	[field: AccessedThroughProperty("DesiredAircraftQty")]
	internal virtual DataGridViewTextBoxColumn DesiredAircraftQty { get; set; }

	[field: AccessedThroughProperty("MinimumAircraftQty")]
	internal virtual DataGridViewTextBoxColumn MinimumAircraftQty { get; set; }

	[field: AccessedThroughProperty("AssignedAircraftQty")]
	internal virtual DataGridViewTextBoxColumn AssignedAircraftQty { get; set; }

	[field: AccessedThroughProperty("ReadyAircraftQty")]
	internal virtual DataGridViewTextBoxColumn ReadyAircraftQty { get; set; }

	[field: AccessedThroughProperty("Priority")]
	internal virtual DataGridViewComboBoxColumn Priority { get; set; }

	[field: AccessedThroughProperty("CreatedBy")]
	internal virtual DataGridViewTextBoxColumn CreatedBy { get; set; }

	[field: AccessedThroughProperty("EditedBy")]
	internal virtual DataGridViewTextBoxColumn EditedBy { get; set; }

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

	public AirTaskingOrder()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AirTaskingOrder_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(AirTaskingOrder_FormClosed);
		((Form)this).Load += AirTaskingOrder_Load;
		((Control)this).VisibleChanged += AirTaskingOrder_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(AirTaskingOrder_KeyDown);
		RTMPEnabled = true;
		SelectedFlightsList = new List<Mission.Flight>();
		bool_3 = true;
		string_0 = "";
		int_0 = 0;
		dataTable_0 = new DataTable();
		airTaskingOrderSortType_0 = AirTaskingOrderSortType.MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout;
		AirTaskingOrderFilterSetting = "";
		bitmap_0 = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		bitmap_1 = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		bitmap_2 = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		bitmap_3 = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		bitmap_4 = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_1556: Unknown result type (might be due to invalid IL or missing references)
		//IL_1560: Expected O, but got Unknown
		//IL_1621: Unknown result type (might be due to invalid IL or missing references)
		//IL_162b: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		Button_DeleteFlight = new DarkUIButton();
		Button_ChangeAircraftType = new DarkUIButton();
		Button_FlightPlanEditor = new DarkUIButton();
		Button_CreateFlight = new DarkUIButton();
		ComboBox_AirborneFlightPlanVisibility = new DarkUIComboBox();
		ComboBox_PlannedFlightPlanVisibility = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		DGV_AirTaskingOrder = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		MissionOrPackage = new DataGridViewTextBoxColumn();
		Callsign = new DataGridViewTextBoxColumn();
		Type = new DataGridViewComboBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		Task = new DataGridViewComboBoxColumn();
		AircraftType = new DataGridViewTextBoxColumn();
		LoadoutType = new DataGridViewTextBoxColumn();
		TakeOffTimeZulu = new DataGridViewTextBoxColumn();
		TakeOffTimeLocal = new DataGridViewTextBoxColumn();
		TakeOffTimeFixed = new DataGridViewTextBoxColumn();
		TakeOffTimeImg = new DataGridViewImageColumn();
		ObjectiveTimeZulu = new DataGridViewTextBoxColumn();
		ObjectiveTimeLocal = new DataGridViewTextBoxColumn();
		ObjectiveTimeFixed = new DataGridViewTextBoxColumn();
		ObjectiveTimeImg = new DataGridViewImageColumn();
		TakeOffLocation = new DataGridViewTextBoxColumn();
		LandingLocation = new DataGridViewTextBoxColumn();
		AlternativeLandingLocation = new DataGridViewTextBoxColumn();
		DesiredAircraftQty = new DataGridViewTextBoxColumn();
		MinimumAircraftQty = new DataGridViewTextBoxColumn();
		AssignedAircraftQty = new DataGridViewTextBoxColumn();
		ReadyAircraftQty = new DataGridViewTextBoxColumn();
		Priority = new DataGridViewComboBoxColumn();
		CreatedBy = new DataGridViewTextBoxColumn();
		EditedBy = new DataGridViewTextBoxColumn();
		Button_CopyFlight = new DarkUIButton();
		Button_ChangeTakeOffTime = new DarkUIButton();
		Button_ChangeObjectiveTime = new DarkUIButton();
		Button_ClearTime = new DarkUIButton();
		ComboBox_AirTaskingOrderSorting = new DarkUIComboBox();
		ComboBox_AirTaskingOrderFilter = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		((ISupportInitialize)(object)DGV_AirTaskingOrder).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Button_DeleteFlight).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_DeleteFlight).BackColor = Color.Transparent;
		((Button)Button_DeleteFlight).DialogResult = (DialogResult)0;
		((Control)Button_DeleteFlight).ForeColor = SystemColors.Control;
		((Control)Button_DeleteFlight).Location = new Point(297, 631);
		((Control)Button_DeleteFlight).Name = "Button_DeleteFlight";
		Button_DeleteFlight.RoundRadius = 0;
		((Control)Button_DeleteFlight).Size = new Size(146, 28);
		((Control)Button_DeleteFlight).TabIndex = 15;
		Button_DeleteFlight.Text = "Delete Flight";
		((Control)Button_ChangeAircraftType).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ChangeAircraftType).BackColor = Color.Transparent;
		((Button)Button_ChangeAircraftType).DialogResult = (DialogResult)0;
		((Control)Button_ChangeAircraftType).ForeColor = SystemColors.Control;
		((Control)Button_ChangeAircraftType).Location = new Point(3, 660);
		((Control)Button_ChangeAircraftType).Name = "Button_ChangeAircraftType";
		Button_ChangeAircraftType.RoundRadius = 0;
		((Control)Button_ChangeAircraftType).Size = new Size(172, 28);
		((Control)Button_ChangeAircraftType).TabIndex = 14;
		Button_ChangeAircraftType.Text = "Change a/c type and loadout";
		((Control)Button_FlightPlanEditor).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_FlightPlanEditor).BackColor = Color.Transparent;
		((Button)Button_FlightPlanEditor).DialogResult = (DialogResult)0;
		((Control)Button_FlightPlanEditor).ForeColor = SystemColors.Control;
		((Control)Button_FlightPlanEditor).Location = new Point(444, 631);
		((Control)Button_FlightPlanEditor).Name = "Button_FlightPlanEditor";
		Button_FlightPlanEditor.RoundRadius = 0;
		((Control)Button_FlightPlanEditor).Size = new Size(146, 28);
		((Control)Button_FlightPlanEditor).TabIndex = 13;
		Button_FlightPlanEditor.Text = "Edit Flightplan";
		((Control)Button_CreateFlight).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_CreateFlight).BackColor = Color.Transparent;
		((Button)Button_CreateFlight).DialogResult = (DialogResult)0;
		((Control)Button_CreateFlight).ForeColor = SystemColors.Control;
		((Control)Button_CreateFlight).Location = new Point(3, 631);
		((Control)Button_CreateFlight).Name = "Button_CreateFlight";
		Button_CreateFlight.RoundRadius = 0;
		((Control)Button_CreateFlight).Size = new Size(146, 28);
		((Control)Button_CreateFlight).TabIndex = 12;
		Button_CreateFlight.Text = "Create Flight";
		((ComboBox)ComboBox_AirborneFlightPlanVisibility).BackColor = Color.Transparent;
		((ComboBox)ComboBox_AirborneFlightPlanVisibility).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_AirborneFlightPlanVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_AirborneFlightPlanVisibility).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_AirborneFlightPlanVisibility).FormattingEnabled = true;
		((ComboBox)ComboBox_AirborneFlightPlanVisibility).Items.AddRange(new object[3] { "All", "Selected unit", "Do not show" });
		((Control)ComboBox_AirborneFlightPlanVisibility).Location = new Point(787, 3);
		((Control)ComboBox_AirborneFlightPlanVisibility).Name = "ComboBox_AirborneFlightPlanVisibility";
		((Control)ComboBox_AirborneFlightPlanVisibility).Size = new Size(214, 21);
		((Control)ComboBox_AirborneFlightPlanVisibility).TabIndex = 11;
		((ComboBox)ComboBox_PlannedFlightPlanVisibility).BackColor = Color.Transparent;
		((ComboBox)ComboBox_PlannedFlightPlanVisibility).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_PlannedFlightPlanVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_PlannedFlightPlanVisibility).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_PlannedFlightPlanVisibility).FormattingEnabled = true;
		((ComboBox)ComboBox_PlannedFlightPlanVisibility).Items.AddRange(new object[5] { "All", "Selected Task Pool (or Mission) ", "Selected Package (or Mission)", "Selected Flight", "Do not show" });
		((Control)ComboBox_PlannedFlightPlanVisibility).Location = new Point(787, 26);
		((Control)ComboBox_PlannedFlightPlanVisibility).Name = "ComboBox_PlannedFlightPlanVisibility";
		((Control)ComboBox_PlannedFlightPlanVisibility).Size = new Size(214, 21);
		((Control)ComboBox_PlannedFlightPlanVisibility).TabIndex = 11;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(554, 7);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(230, 15);
		((Control)Label2).TabIndex = 10;
		((Label)Label2).Text = "Show airborne flightplans on tactical map:";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(554, 30);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(229, 15);
		((Control)Label1).TabIndex = 10;
		((Label)Label1).Text = "Show planned flightplans on tactical map:";
		((DataGridView)DGV_AirTaskingOrder).AllowUserToAddRows = false;
		((DataGridView)DGV_AirTaskingOrder).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AirTaskingOrder).AllowUserToResizeRows = false;
		((Control)DGV_AirTaskingOrder).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_AirTaskingOrder).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_AirTaskingOrder).BorderStyle = (BorderStyle)0;
		((DataGridView)DGV_AirTaskingOrder).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_AirTaskingOrder).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AirTaskingOrder).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_AirTaskingOrder).ColumnHeadersHeight = 18;
		((DataGridView)DGV_AirTaskingOrder).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[26]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)MissionOrPackage,
			(DataGridViewColumn)Callsign,
			(DataGridViewColumn)Type,
			(DataGridViewColumn)Status,
			(DataGridViewColumn)Task,
			(DataGridViewColumn)AircraftType,
			(DataGridViewColumn)LoadoutType,
			(DataGridViewColumn)TakeOffTimeZulu,
			(DataGridViewColumn)TakeOffTimeLocal,
			(DataGridViewColumn)TakeOffTimeFixed,
			(DataGridViewColumn)TakeOffTimeImg,
			(DataGridViewColumn)ObjectiveTimeZulu,
			(DataGridViewColumn)ObjectiveTimeLocal,
			(DataGridViewColumn)ObjectiveTimeFixed,
			(DataGridViewColumn)ObjectiveTimeImg,
			(DataGridViewColumn)TakeOffLocation,
			(DataGridViewColumn)LandingLocation,
			(DataGridViewColumn)AlternativeLandingLocation,
			(DataGridViewColumn)DesiredAircraftQty,
			(DataGridViewColumn)MinimumAircraftQty,
			(DataGridViewColumn)AssignedAircraftQty,
			(DataGridViewColumn)ReadyAircraftQty,
			(DataGridViewColumn)Priority,
			(DataGridViewColumn)CreatedBy,
			(DataGridViewColumn)EditedBy
		});
		((DataGridView)DGV_AirTaskingOrder).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_AirTaskingOrder).EnableHeadersVisualStyles = false;
		((Control)DGV_AirTaskingOrder).Location = new Point(0, 53);
		((Control)DGV_AirTaskingOrder).Name = "DGV_AirTaskingOrder";
		((DataGridView)DGV_AirTaskingOrder).RowHeadersVisible = false;
		((DataGridView)DGV_AirTaskingOrder).RowHeadersWidth = 10;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_AirTaskingOrder).RowsDefaultCellStyle = val2;
		((DataGridView)DGV_AirTaskingOrder).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_AirTaskingOrder).Size = new Size(1008, 576);
		((Control)DGV_AirTaskingOrder).TabIndex = 9;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).Frozen = true;
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)MissionOrPackage).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)MissionOrPackage).DataPropertyName = "MissionOrPackage";
		((DataGridViewColumn)MissionOrPackage).Frozen = true;
		((DataGridViewColumn)MissionOrPackage).HeaderText = "Mission/Package";
		((DataGridViewColumn)MissionOrPackage).Name = "MissionOrPackage";
		((DataGridViewColumn)MissionOrPackage).Width = 120;
		((DataGridViewColumn)Callsign).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Callsign).DataPropertyName = "Callsign";
		((DataGridViewColumn)Callsign).Frozen = true;
		((DataGridViewColumn)Callsign).HeaderText = "Flight Callsign";
		((DataGridViewColumn)Callsign).Name = "Callsign";
		((DataGridViewColumn)Callsign).Width = 105;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		Type.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Type).Width = 55;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Status).DataPropertyName = "Status";
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).Width = 62;
		((DataGridViewColumn)Task).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Task).DataPropertyName = "Task";
		Task.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)Task).HeaderText = "Task";
		((DataGridViewColumn)Task).Name = "Task";
		((DataGridViewColumn)Task).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Task).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Task).Width = 53;
		((DataGridViewColumn)AircraftType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AircraftType).DataPropertyName = "AircraftType";
		((DataGridViewColumn)AircraftType).HeaderText = "Aircraft Type";
		((DataGridViewColumn)AircraftType).Name = "AircraftType";
		((DataGridViewColumn)AircraftType).ReadOnly = true;
		((DataGridViewColumn)AircraftType).Width = 97;
		((DataGridViewColumn)LoadoutType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)LoadoutType).DataPropertyName = "LoadoutType";
		((DataGridViewColumn)LoadoutType).HeaderText = "Loadout Type";
		((DataGridViewColumn)LoadoutType).Name = "LoadoutType";
		((DataGridViewColumn)LoadoutType).Width = 102;
		((DataGridViewColumn)TakeOffTimeZulu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TakeOffTimeZulu).DataPropertyName = "TakeOffTimeZulu";
		((DataGridViewColumn)TakeOffTimeZulu).HeaderText = "Zulu Take-Off Time";
		((DataGridViewColumn)TakeOffTimeZulu).Name = "TakeOffTimeZulu";
		((DataGridViewColumn)TakeOffTimeZulu).Width = 133;
		((DataGridViewColumn)TakeOffTimeLocal).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TakeOffTimeLocal).DataPropertyName = "TakeOffTimeLocal";
		((DataGridViewColumn)TakeOffTimeLocal).HeaderText = "Local Take-Off Time";
		((DataGridViewColumn)TakeOffTimeLocal).Name = "TakeOffTimeLocal";
		((DataGridViewColumn)TakeOffTimeLocal).Width = 137;
		((DataGridViewColumn)TakeOffTimeFixed).DataPropertyName = "TakeOffTimeFixed";
		((DataGridViewColumn)TakeOffTimeFixed).HeaderText = "TakeOffTimeFixed";
		((DataGridViewColumn)TakeOffTimeFixed).Name = "TakeOffTimeFixed";
		((DataGridViewColumn)TakeOffTimeFixed).Visible = false;
		((DataGridViewColumn)TakeOffTimeImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)TakeOffTimeImg).DataPropertyName = "TakeOffTimeImg";
		((DataGridViewColumn)TakeOffTimeImg).HeaderText = "";
		((DataGridViewColumn)TakeOffTimeImg).Name = "TakeOffTimeImg";
		((DataGridViewColumn)TakeOffTimeImg).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)TakeOffTimeImg).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)TakeOffTimeImg).Width = 5;
		((DataGridViewColumn)ObjectiveTimeZulu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ObjectiveTimeZulu).DataPropertyName = "ObjectiveTimeZulu";
		((DataGridViewColumn)ObjectiveTimeZulu).HeaderText = "Time on Target (Zulu)";
		((DataGridViewColumn)ObjectiveTimeZulu).Name = "ObjectiveTimeZulu";
		((DataGridViewColumn)ObjectiveTimeZulu).Width = 137;
		((DataGridViewColumn)ObjectiveTimeLocal).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ObjectiveTimeLocal).DataPropertyName = "ObjectiveTimeLocal";
		((DataGridViewColumn)ObjectiveTimeLocal).HeaderText = "Time on Target (Local)";
		((DataGridViewColumn)ObjectiveTimeLocal).Name = "ObjectiveTimeLocal";
		((DataGridViewColumn)ObjectiveTimeLocal).Width = 141;
		((DataGridViewColumn)ObjectiveTimeFixed).DataPropertyName = "ObjectiveTimeFixed";
		((DataGridViewColumn)ObjectiveTimeFixed).HeaderText = "ObjectiveTimeFixed";
		((DataGridViewColumn)ObjectiveTimeFixed).Name = "ObjectiveTimeFixed";
		((DataGridViewColumn)ObjectiveTimeFixed).Visible = false;
		((DataGridViewColumn)ObjectiveTimeImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)ObjectiveTimeImg).DataPropertyName = "ObjectiveTimeImg";
		((DataGridViewColumn)ObjectiveTimeImg).HeaderText = "";
		((DataGridViewColumn)ObjectiveTimeImg).Name = "ObjectiveTimeImg";
		((DataGridViewColumn)ObjectiveTimeImg).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)ObjectiveTimeImg).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)ObjectiveTimeImg).Width = 5;
		((DataGridViewColumn)TakeOffLocation).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TakeOffLocation).DataPropertyName = "TakeOffLocation";
		((DataGridViewColumn)TakeOffLocation).HeaderText = "Take Off Location";
		((DataGridViewColumn)TakeOffLocation).Name = "TakeOffLocation";
		((DataGridViewColumn)TakeOffLocation).Width = 123;
		((DataGridViewColumn)LandingLocation).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)LandingLocation).DataPropertyName = "LandingLocation";
		((DataGridViewColumn)LandingLocation).HeaderText = "Landing Location";
		((DataGridViewColumn)LandingLocation).Name = "LandingLocation";
		((DataGridViewColumn)LandingLocation).Width = 122;
		((DataGridViewColumn)AlternativeLandingLocation).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AlternativeLandingLocation).DataPropertyName = "AlternativeLandingLocation";
		((DataGridViewColumn)AlternativeLandingLocation).HeaderText = "Diversion Location";
		((DataGridViewColumn)AlternativeLandingLocation).Name = "AlternativeLandingLocation";
		((DataGridViewColumn)AlternativeLandingLocation).Width = 128;
		((DataGridViewColumn)DesiredAircraftQty).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DesiredAircraftQty).DataPropertyName = "DesiredAircraftQty";
		((DataGridViewColumn)DesiredAircraftQty).HeaderText = "Desired Flight Size";
		((DataGridViewColumn)DesiredAircraftQty).Name = "DesiredAircraftQty";
		((DataGridViewColumn)DesiredAircraftQty).Resizable = (DataGridViewTriState)1;
		DesiredAircraftQty.SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)DesiredAircraftQty).Width = 125;
		((DataGridViewColumn)MinimumAircraftQty).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)MinimumAircraftQty).DataPropertyName = "MinimumAircraftQty";
		((DataGridViewColumn)MinimumAircraftQty).HeaderText = "Minimum Flight Size";
		((DataGridViewColumn)MinimumAircraftQty).Name = "MinimumAircraftQty";
		((DataGridViewColumn)MinimumAircraftQty).Resizable = (DataGridViewTriState)1;
		MinimumAircraftQty.SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)MinimumAircraftQty).Width = 139;
		((DataGridViewColumn)AssignedAircraftQty).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AssignedAircraftQty).DataPropertyName = "AssignedAircraftQty";
		((DataGridViewColumn)AssignedAircraftQty).HeaderText = "Assigned a/c";
		((DataGridViewColumn)AssignedAircraftQty).Name = "AssignedAircraftQty";
		((DataGridViewColumn)AssignedAircraftQty).ReadOnly = true;
		((DataGridViewColumn)AssignedAircraftQty).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)AssignedAircraftQty).Width = 98;
		((DataGridViewColumn)ReadyAircraftQty).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ReadyAircraftQty).DataPropertyName = "ReadyAircraftQty";
		((DataGridViewColumn)ReadyAircraftQty).HeaderText = "Ready a/c";
		((DataGridViewColumn)ReadyAircraftQty).Name = "ReadyAircraftQty";
		((DataGridViewColumn)ReadyAircraftQty).ReadOnly = true;
		((DataGridViewColumn)ReadyAircraftQty).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)ReadyAircraftQty).Width = 82;
		((DataGridViewColumn)Priority).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Priority).DataPropertyName = "Priority";
		Priority.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)Priority).HeaderText = "Priority";
		((DataGridViewColumn)Priority).Name = "Priority";
		((DataGridViewColumn)Priority).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Priority).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Priority).Width = 68;
		((DataGridViewColumn)CreatedBy).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)CreatedBy).DataPropertyName = "CreatedBy";
		((DataGridViewColumn)CreatedBy).HeaderText = "Created By";
		((DataGridViewColumn)CreatedBy).Name = "CreatedBy";
		((DataGridViewColumn)CreatedBy).Width = 87;
		((DataGridViewColumn)EditedBy).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)EditedBy).DataPropertyName = "EditedBy";
		((DataGridViewColumn)EditedBy).HeaderText = "Edited By";
		((DataGridViewColumn)EditedBy).Name = "EditedBy";
		((DataGridViewColumn)EditedBy).Width = 79;
		((Control)Button_CopyFlight).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_CopyFlight).BackColor = Color.Transparent;
		((Button)Button_CopyFlight).DialogResult = (DialogResult)0;
		((Control)Button_CopyFlight).ForeColor = SystemColors.Control;
		((Control)Button_CopyFlight).Location = new Point(150, 631);
		((Control)Button_CopyFlight).Name = "Button_CopyFlight";
		Button_CopyFlight.RoundRadius = 0;
		((Control)Button_CopyFlight).Size = new Size(146, 28);
		((Control)Button_CopyFlight).TabIndex = 16;
		Button_CopyFlight.Text = "Copy Flight";
		((Control)Button_ChangeTakeOffTime).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ChangeTakeOffTime).BackColor = Color.Transparent;
		((Button)Button_ChangeTakeOffTime).DialogResult = (DialogResult)0;
		Button_ChangeTakeOffTime.Enabled = false;
		((Control)Button_ChangeTakeOffTime).ForeColor = SystemColors.Control;
		((Control)Button_ChangeTakeOffTime).Location = new Point(176, 660);
		((Control)Button_ChangeTakeOffTime).Name = "Button_ChangeTakeOffTime";
		Button_ChangeTakeOffTime.RoundRadius = 0;
		((Control)Button_ChangeTakeOffTime).Size = new Size(162, 28);
		((Control)Button_ChangeTakeOffTime).TabIndex = 17;
		Button_ChangeTakeOffTime.Text = "Change take-off time";
		((Control)Button_ChangeObjectiveTime).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ChangeObjectiveTime).BackColor = Color.Transparent;
		((Button)Button_ChangeObjectiveTime).DialogResult = (DialogResult)0;
		Button_ChangeObjectiveTime.Enabled = false;
		((Control)Button_ChangeObjectiveTime).ForeColor = SystemColors.Control;
		((Control)Button_ChangeObjectiveTime).Location = new Point(339, 660);
		((Control)Button_ChangeObjectiveTime).Name = "Button_ChangeObjectiveTime";
		Button_ChangeObjectiveTime.RoundRadius = 0;
		((Control)Button_ChangeObjectiveTime).Size = new Size(162, 28);
		((Control)Button_ChangeObjectiveTime).TabIndex = 18;
		Button_ChangeObjectiveTime.Text = "Change Time on Target";
		((Control)Button_ClearTime).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ClearTime).BackColor = Color.Transparent;
		((Button)Button_ClearTime).DialogResult = (DialogResult)0;
		Button_ClearTime.Enabled = false;
		((Control)Button_ClearTime).ForeColor = SystemColors.Control;
		((Control)Button_ClearTime).Location = new Point(502, 660);
		((Control)Button_ClearTime).Name = "Button_ClearTime";
		Button_ClearTime.RoundRadius = 0;
		((Control)Button_ClearTime).Size = new Size(88, 28);
		((Control)Button_ClearTime).TabIndex = 18;
		Button_ClearTime.Text = "Clear Time";
		((ComboBox)ComboBox_AirTaskingOrderSorting).BackColor = Color.Transparent;
		((ComboBox)ComboBox_AirTaskingOrderSorting).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_AirTaskingOrderSorting).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_AirTaskingOrderSorting).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_AirTaskingOrderSorting).FormattingEnabled = true;
		((ComboBox)ComboBox_AirTaskingOrderSorting).Items.AddRange(new object[3] { "All", "Selected unit", "Do not show" });
		((Control)ComboBox_AirTaskingOrderSorting).Location = new Point(93, 26);
		((Control)ComboBox_AirTaskingOrderSorting).Name = "ComboBox_AirTaskingOrderSorting";
		((Control)ComboBox_AirTaskingOrderSorting).Size = new Size(451, 21);
		((Control)ComboBox_AirTaskingOrderSorting).TabIndex = 21;
		((ComboBox)ComboBox_AirTaskingOrderFilter).BackColor = Color.Transparent;
		((ComboBox)ComboBox_AirTaskingOrderFilter).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_AirTaskingOrderFilter).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_AirTaskingOrderFilter).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_AirTaskingOrderFilter).FormattingEnabled = true;
		((ComboBox)ComboBox_AirTaskingOrderFilter).Items.AddRange(new object[5] { "All", "Selected Task Pool (or Mission) ", "Selected Package (or Mission)", "Selected Flight", "Do not show" });
		((Control)ComboBox_AirTaskingOrderFilter).Location = new Point(93, 3);
		((Control)ComboBox_AirTaskingOrderFilter).Name = "ComboBox_AirTaskingOrderFilter";
		((Control)ComboBox_AirTaskingOrderFilter).Size = new Size(451, 21);
		((Control)ComboBox_AirTaskingOrderFilter).TabIndex = 22;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(1, 30);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(89, 15);
		((Control)Label3).TabIndex = 19;
		((Label)Label3).Text = "Sort flights by...";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(1, 7);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(99, 15);
		((Control)Label4).TabIndex = 20;
		((Label)Label4).Text = "Show flights for...";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1008, 691);
		((Control)this).Controls.Add((Control)(object)ComboBox_AirTaskingOrderSorting);
		((Control)this).Controls.Add((Control)(object)ComboBox_AirTaskingOrderFilter);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Button_ClearTime);
		((Control)this).Controls.Add((Control)(object)Button_ChangeObjectiveTime);
		((Control)this).Controls.Add((Control)(object)Button_ChangeTakeOffTime);
		((Control)this).Controls.Add((Control)(object)Button_CopyFlight);
		((Control)this).Controls.Add((Control)(object)Button_DeleteFlight);
		((Control)this).Controls.Add((Control)(object)Button_ChangeAircraftType);
		((Control)this).Controls.Add((Control)(object)Button_FlightPlanEditor);
		((Control)this).Controls.Add((Control)(object)Button_CreateFlight);
		((Control)this).Controls.Add((Control)(object)ComboBox_AirborneFlightPlanVisibility);
		((Control)this).Controls.Add((Control)(object)ComboBox_PlannedFlightPlanVisibility);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)DGV_AirTaskingOrder);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AirTaskingOrder";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Air Tasking Order (ATO)";
		((ISupportInitialize)(object)DGV_AirTaskingOrder).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing((object)scenarioObject_0))
			{
				RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200631", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AirTaskingOrder_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void AirTaskingOrder_FormClosed(object sender, FormClosedEventArgs e)
	{
		MissionEditor.SelectedMissionChanged -= method_2;
	}

	private void AirTaskingOrder_Load(object sender, EventArgs e)
	{
		MissionEditor.SelectedMissionChanged += method_2;
		Side.MissionsChanged += method_3;
	}

	private void method_3(Side side_0)
	{
		if (Operators.CompareString(Client.CurrentSide.ObjectID, side_0.ObjectID, true) == 0)
		{
			LoadWindow();
		}
	}

	private void AirTaskingOrder_VisibleChanged(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (!((Control)this).Visible)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			LoadWindow();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		method_6();
		RefreshStats();
		method_4();
	}

	private void method_4()
	{
		if (!((Control)this).InvokeRequired)
		{
			((Control)Button_ChangeObjectiveTime).Visible = Module1.Time_Visibility;
			((Control)Button_ChangeTakeOffTime).Visible = Module1.Time_Visibility;
			((Control)Button_FlightPlanEditor).Visible = Module1.FlightPlanner_Visibility;
			return;
		}
		method_5([SpecialName] () =>
		{
			((Control)Button_ChangeObjectiveTime).Visible = Module1.Time_Visibility;
			((Control)Button_ChangeTakeOffTime).Visible = Module1.Time_Visibility;
			((Control)Button_FlightPlanEditor).Visible = Module1.FlightPlanner_Visibility;
		});
	}

	public void RefreshWindow()
	{
		method_7();
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_5(Action action_0)
	{
		if (!((Control)this).InvokeRequired)
		{
			action_0();
		}
		else
		{
			((Control)this).Invoke((Delegate)action_0);
		}
	}

	public void RefreshStats()
	{
		try
		{
			method_5([SpecialName] () =>
			{
				((ComboBox)ComboBox_AirborneFlightPlanVisibility).SelectedIndex = (int)SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Airborne;
				((ComboBox)ComboBox_PlannedFlightPlanVisibility).SelectedIndex = (int)SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Planned;
				((ComboBox)ComboBox_AirTaskingOrderFilter).BeginUpdate();
				((ComboBox)ComboBox_AirTaskingOrderFilter).Items.Clear();
				((ComboBox)ComboBox_AirTaskingOrderFilter).Items.Insert(0, (object)"Missions and packages included in the ATO");
				((ComboBox)ComboBox_AirTaskingOrderFilter).Items.Insert(1, (object)"All missions and packages, including those not in the ATO");
				int num = 2;
				bool flag = false;
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (mission.Category != Mission.MissionCategory.TaskPool)
					{
						if (mission.Name == null)
						{
							mission.Name = "";
						}
						((ComboBox)ComboBox_AirTaskingOrderFilter).Items.Insert(num, (object)mission.Name);
						if (Operators.CompareString(mission.ObjectID, AirTaskingOrderFilterSetting, true) == 0)
						{
							((ComboBox)ComboBox_AirTaskingOrderFilter).SelectedIndex = num;
							flag = true;
						}
						num++;
					}
				}
				if (!flag)
				{
					((ComboBox)ComboBox_AirTaskingOrderFilter).SelectedIndex = 0;
				}
				((ComboBox)ComboBox_AirTaskingOrderFilter).EndUpdate();
				((ComboBox)ComboBox_AirTaskingOrderSorting).BeginUpdate();
				((ComboBox)ComboBox_AirTaskingOrderSorting).Items.Clear();
				((ComboBox)ComboBox_AirTaskingOrderSorting).Items.Insert(0, (object)"Mission/Package/Task Pool - Take-Off Time - Task Type - Aircraft - Loadout");
				((ComboBox)ComboBox_AirTaskingOrderSorting).Items.Insert(1, (object)"Take-Off Time - Task Type - Aircraft - Loadout");
				((ComboBox)ComboBox_AirTaskingOrderSorting).Items.Insert(2, (object)"Time on Target - Task Type - Aircraft - Loadout");
				((ComboBox)ComboBox_AirTaskingOrderSorting).SelectedIndex = (int)airTaskingOrderSortType_0;
				((ComboBox)ComboBox_AirTaskingOrderSorting).EndUpdate();
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 0284654521", ex2.Message);
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
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Expected O, but got Unknown
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecb: Expected O, but got Unknown
		try
		{
			int num;
			if (!Information.IsNothing((object)DGV_AirTaskingOrder))
			{
				num = ((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count;
				if (num > 0)
				{
					int_0 = ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index;
					SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
					if (!Information.IsNothing((object)SelectedFlight))
					{
						string_0 = SelectedFlight.ObjectID;
						SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
					}
				}
			}
			else
			{
				num = 0;
				int_0 = 0;
				string_0 = "";
				SelectedFlight = null;
				SelectedMission = null;
			}
			bool_3 = false;
			dataTable_0.Clear();
			SelectedFlightsList.Clear();
			bool_3 = true;
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(string));
				int_1 = 0;
			}
			if (!dataTable_0.Columns.Contains("MissionOrPackage"))
			{
				dataTable_0.Columns.Add("MissionOrPackage", typeof(string));
				int_2 = 1;
			}
			if (!dataTable_0.Columns.Contains("Callsign"))
			{
				dataTable_0.Columns.Add("Callsign", typeof(string));
				int_3 = 2;
			}
			if (!dataTable_0.Columns.Contains("Type"))
			{
				dataTable_0.Columns.Add("Type", typeof(int));
				int_4 = 3;
			}
			if (!dataTable_0.Columns.Contains("Status"))
			{
				dataTable_0.Columns.Add("Status", typeof(string));
				int_6 = 4;
			}
			if (!dataTable_0.Columns.Contains("Task"))
			{
				dataTable_0.Columns.Add("Task", typeof(int));
				int_5 = 5;
			}
			if (!dataTable_0.Columns.Contains("AircraftType"))
			{
				dataTable_0.Columns.Add("AircraftType", typeof(string));
				int_7 = 6;
			}
			if (!dataTable_0.Columns.Contains("LoadoutType"))
			{
				dataTable_0.Columns.Add("LoadoutType", typeof(string));
				int_8 = 7;
			}
			if (!dataTable_0.Columns.Contains("TakeOffTimeZulu"))
			{
				dataTable_0.Columns.Add("TakeOffTimeZulu", typeof(string));
				int_9 = 8;
			}
			if (!dataTable_0.Columns.Contains("TakeOffTimeLocal"))
			{
				dataTable_0.Columns.Add("TakeOffTimeLocal", typeof(string));
				int_10 = 9;
			}
			if (!dataTable_0.Columns.Contains("TakeOffTimeFixed"))
			{
				dataTable_0.Columns.Add("TakeOffTimeFixed", typeof(int));
				int_25 = 10;
			}
			if (!dataTable_0.Columns.Contains("TakeOffTimeImg"))
			{
				dataTable_0.Columns.Add("TakeOffTimeImg", typeof(Image));
				int_11 = 11;
			}
			if (!dataTable_0.Columns.Contains("ObjectiveTimeZulu"))
			{
				dataTable_0.Columns.Add("ObjectiveTimeZulu", typeof(string));
				int_12 = 12;
			}
			if (!dataTable_0.Columns.Contains("ObjectiveTimeLocal"))
			{
				dataTable_0.Columns.Add("ObjectiveTimeLocal", typeof(string));
				int_13 = 13;
			}
			if (!dataTable_0.Columns.Contains("ObjectiveTimeFixed"))
			{
				dataTable_0.Columns.Add("ObjectiveTimeFixed", typeof(int));
				int_26 = 14;
			}
			if (!dataTable_0.Columns.Contains("ObjectiveTimeImg"))
			{
				dataTable_0.Columns.Add("ObjectiveTimeImg", typeof(Image));
				int_14 = 15;
			}
			if (!dataTable_0.Columns.Contains("TakeOffLocation"))
			{
				dataTable_0.Columns.Add("TakeOffLocation", typeof(string));
				int_15 = 16;
			}
			if (!dataTable_0.Columns.Contains("LandingLocation"))
			{
				dataTable_0.Columns.Add("LandingLocation", typeof(string));
				int_16 = 17;
			}
			if (!dataTable_0.Columns.Contains("AlternativeLandingLocation"))
			{
				dataTable_0.Columns.Add("AlternativeLandingLocation", typeof(string));
				int_17 = 18;
			}
			if (!dataTable_0.Columns.Contains("DesiredAircraftQty"))
			{
				dataTable_0.Columns.Add("DesiredAircraftQty", typeof(int));
				int_18 = 19;
			}
			if (!dataTable_0.Columns.Contains("MinimumAircraftQty"))
			{
				dataTable_0.Columns.Add("MinimumAircraftQty", typeof(int));
				int_19 = 20;
			}
			if (!dataTable_0.Columns.Contains("AssignedAircraftQty"))
			{
				dataTable_0.Columns.Add("AssignedAircraftQty", typeof(int));
				int_20 = 21;
			}
			if (!dataTable_0.Columns.Contains("ReadyAircraftQty"))
			{
				dataTable_0.Columns.Add("ReadyAircraftQty", typeof(int));
				int_21 = 22;
			}
			if (!dataTable_0.Columns.Contains("Priority"))
			{
				dataTable_0.Columns.Add("Priority", typeof(int));
				int_22 = 23;
			}
			if (!dataTable_0.Columns.Contains("CreatedBy"))
			{
				dataTable_0.Columns.Add("CreatedBy", typeof(string));
				int_23 = 24;
			}
			if (!dataTable_0.Columns.Contains("EditedBy"))
			{
				dataTable_0.Columns.Add("EditedBy", typeof(string));
				int_24 = 25;
			}
			DataTable theComboBoxDataSource_Type = new DataTable();
			DataTable theComboBoxDataSource_Task = new DataTable();
			DataTable theComboBoxDataSource_Priority = new DataTable();
			new DataTable();
			new DataTable();
			DataGridViewComboBoxColumn val = (DataGridViewComboBoxColumn)((DataGridView)DGV_AirTaskingOrder).Columns[((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Columns["Task"]).Index];
			DataGridViewComboBoxColumn val2 = (DataGridViewComboBoxColumn)((DataGridView)DGV_AirTaskingOrder).Columns[((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Columns["Priority"]).Index];
			_ = (DataGridViewTextBoxColumn)((DataGridView)DGV_AirTaskingOrder).Columns[((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Columns["DesiredAircraftQty"]).Index];
			_ = (DataGridViewTextBoxColumn)((DataGridView)DGV_AirTaskingOrder).Columns[((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Columns["MinimumAircraftQty"]).Index];
			DataGridViewComboBoxColumn val3 = (DataGridViewComboBoxColumn)((DataGridView)DGV_AirTaskingOrder).Columns[((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Columns["Type"]).Index];
			Mission.Flight.ComboBoxDataSource_Type(ref theComboBoxDataSource_Type);
			Mission.Flight.ComboBoxDataSource_Task(ref theComboBoxDataSource_Task);
			Mission.Flight.ComboBoxDataSource_Priority(ref theComboBoxDataSource_Priority);
			val.DataSource = theComboBoxDataSource_Task;
			val.DisplayMember = "Description";
			val.ValueMember = "ID";
			val2.DataSource = theComboBoxDataSource_Priority;
			val2.DisplayMember = "Description";
			val2.ValueMember = "ID";
			val3.DataSource = theComboBoxDataSource_Type;
			val3.DisplayMember = "Description";
			val3.ValueMember = "ID";
			bool_3 = false;
			if (string.IsNullOrEmpty(AirTaskingOrderFilterSetting) || Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", true) == 0 || Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_All", true) == 0)
			{
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", true) == 0 && !mission.IncludeInATO)
					{
						continue;
					}
					foreach (Mission.Flight flight in mission.FlightList)
					{
						SelectedFlightsList.Add(flight);
					}
				}
			}
			else
			{
				foreach (Mission mission2 in Client.CurrentSide.Missions)
				{
					if ((Operators.CompareString(mission2.ObjectID, AirTaskingOrderFilterSetting, true) != 0 && Operators.CompareString(mission2.get_ParentTaskPoolID(Client.CurrentSide), AirTaskingOrderFilterSetting, true) != 0) || mission2.Category == Mission.MissionCategory.TaskPool)
					{
						continue;
					}
					foreach (Mission.Flight flight2 in mission2.FlightList)
					{
						SelectedFlightsList.Add(flight2);
					}
					break;
				}
			}
			if (SelectedFlightsList.Count == 0)
			{
				return;
			}
			foreach (Mission.Flight selectedFlights in SelectedFlightsList)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedFlights.SetTakeOffAndObjectiveTimeString(ref theScen);
			}
			switch (airTaskingOrderSortType_0)
			{
			default:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ParentMissionOrPackageName, theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.get_LoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ParentMissionOrPackageName, theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.get_LoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.TakeOffTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.get_LoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.ObjectiveTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ObjectiveTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.get_LoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			}
			foreach (Mission.Flight selectedFlights2 in SelectedFlightsList)
			{
				_ = selectedFlights2;
				DataRow row = dataTable_0.NewRow();
				dataTable_0.Rows.Add(row);
			}
			if (num == 0 && ((DataGridView)DGV_AirTaskingOrder).Rows.Count > 0)
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
			}
			bool_3 = true;
			method_7();
			bool_3 = false;
			((DataGridView)DGV_AirTaskingOrder).DataSource = new DataView(dataTable_0);
			bool_3 = true;
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_AirTaskingOrder).Rows)
			{
				DataGridViewRow val4 = item;
				foreach (Mission.Flight selectedFlights3 in SelectedFlightsList)
				{
					if (Operators.CompareString(selectedFlights3.ObjectID, Conversions.ToString(val4.Cells["ID"].Value), true) == 0)
					{
						((DataGridViewBand)val4).Tag = selectedFlights3;
						break;
					}
				}
			}
			bool_3 = false;
			if (((DataGridView)DGV_AirTaskingOrder).RowCount <= 0)
			{
				SelectedFlight = null;
				SelectedMission = null;
			}
			else if (int_0 <= ((DataGridView)DGV_AirTaskingOrder).RowCount - 1)
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
				((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = true;
				SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
				if (!Information.IsNothing((object)SelectedFlight))
				{
					string_0 = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
				}
			}
			else
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
				((DataGridView)DGV_AirTaskingOrder).Rows[((DataGridView)DGV_AirTaskingOrder).RowCount - 1].Selected = true;
				SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
				if (!Information.IsNothing((object)SelectedFlight))
				{
					string_0 = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
				}
			}
			bool_3 = true;
			if (Information.IsNothing((object)SelectedFlight) && ((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count > 0)
			{
				SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
				if (!Information.IsNothing((object)SelectedFlight))
				{
					string_0 = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
				}
			}
			DisplayLocks();
			EnableAndDisableButtons();
			EnableAndDisableCells();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7()
	{
		try
		{
			_Closure$__234-0 arg = default(_Closure$__234-0);
			_Closure$__234-0 CS$<>8__locals37 = new _Closure$__234-0(arg);
			if (Information.IsNothing((object)SelectedFlightsList) || SelectedFlightsList.Count == 0)
			{
				return;
			}
			((Control)DGV_AirTaskingOrder).SuspendLayout();
			int count = dataTable_0.Rows.Count;
			try
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					DataRow dataRow = dataTable_0.Rows[i];
					CS$<>8__locals37.$VB$Local_theFlight = SelectedFlightsList[i];
					string objectID = CS$<>8__locals37.$VB$Local_theFlight.ObjectID;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_1]), objectID))
					{
						dataRow[int_1] = objectID;
					}
					if (string.IsNullOrEmpty(CS$<>8__locals37.$VB$Local_theFlight.ParentMissionOrPackageName))
					{
						foreach (Mission mission2 in Client.CurrentSide.Missions)
						{
							if (mission2.FlightList.Contains(CS$<>8__locals37.$VB$Local_theFlight))
							{
								CS$<>8__locals37.$VB$Local_theFlight.ParentMissionOrPackageObjectID = mission2.ObjectID;
								CS$<>8__locals37.$VB$Local_theFlight.ParentMissionOrPackageName = mission2.Name;
								break;
							}
						}
					}
					string parentMissionOrPackageName = CS$<>8__locals37.$VB$Local_theFlight.ParentMissionOrPackageName;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_2]), parentMissionOrPackageName))
					{
						dataRow[int_2] = parentMissionOrPackageName;
					}
					string callsign = CS$<>8__locals37.$VB$Local_theFlight.Callsign;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_3]), callsign))
					{
						dataRow[int_3] = callsign;
					}
					int num2 = Mission.Flight.Type_To_TypeSelection((int)CS$<>8__locals37.$VB$Local_theFlight.Type);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_4]), num2))
					{
						dataRow[int_4] = num2;
					}
					int num3 = Mission.Flight.Task_To_TaskSelection((int)CS$<>8__locals37.$VB$Local_theFlight.Task);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_5]), num3))
					{
						dataRow[int_5] = num3;
					}
					Mission.Flight flight = CS$<>8__locals37.$VB$Local_theFlight;
					Scenario theScen = Client.CurrentScenario;
					flight.SetTakeOffAndObjectiveTimeString(ref theScen);
					string takeOffTimeZuluString = CS$<>8__locals37.$VB$Local_theFlight.TakeOffTimeZuluString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_9]), takeOffTimeZuluString))
					{
						dataRow[int_9] = takeOffTimeZuluString;
					}
					string takeOffTimeLocalString = CS$<>8__locals37.$VB$Local_theFlight.TakeOffTimeLocalString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_10]), takeOffTimeLocalString))
					{
						dataRow[int_10] = takeOffTimeLocalString;
					}
					string objectiveTimeZuluString = CS$<>8__locals37.$VB$Local_theFlight.ObjectiveTimeZuluString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_12]), objectiveTimeZuluString))
					{
						dataRow[int_12] = objectiveTimeZuluString;
					}
					string objectiveTimeLocalString = CS$<>8__locals37.$VB$Local_theFlight.ObjectiveTimeLocalString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_13]), objectiveTimeLocalString))
					{
						dataRow[int_13] = objectiveTimeLocalString;
					}
					int takeOffWaypointFixedTime = (int)CS$<>8__locals37.$VB$Local_theFlight.TakeOffWaypointFixedTime;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_25]), takeOffWaypointFixedTime))
					{
						dataRow[int_25] = takeOffWaypointFixedTime;
					}
					int objectiveWaypointFixedTime = (int)CS$<>8__locals37.$VB$Local_theFlight.ObjectiveWaypointFixedTime;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_26]), objectiveWaypointFixedTime))
					{
						dataRow[int_26] = objectiveWaypointFixedTime;
					}
					string text = CS$<>8__locals37.$VB$Local_theFlight.ReferenceUnit_Name;
					if (string.IsNullOrEmpty(text))
					{
						text = "Not set";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_7]), text))
					{
						dataRow[int_7] = text;
					}
					string text2 = CS$<>8__locals37.$VB$Local_theFlight.get_LoadoutName(Client.CurrentScenario);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_8]), text2))
					{
						dataRow[int_8] = text2;
					}
					string text3 = CS$<>8__locals37.$VB$Local_theFlight.TakeOffLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(text3))
					{
						text3 = "Not set";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_15]), text3))
					{
						dataRow[int_15] = text3;
					}
					string text4 = CS$<>8__locals37.$VB$Local_theFlight.LandingLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(text4))
					{
						text4 = "Not set";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_16]), text4))
					{
						dataRow[int_16] = text4;
					}
					string value = CS$<>8__locals37.$VB$Local_theFlight.AlternativeLandingLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(value))
					{
						value = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_17]), text2))
					{
						dataRow[int_17] = value;
					}
					string text5 = Mission.get_FlightStatusString(CS$<>8__locals37.$VB$Local_theFlight.get_Status(Client.CurrentScenario));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_6]), text5))
					{
						dataRow[int_6] = text5;
					}
					int num4 = Mission.Flight.Priority_To_PrioritySelection((int)CS$<>8__locals37.$VB$Local_theFlight.Priority);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_22]), num4))
					{
						dataRow[int_22] = num4;
					}
					int createdBy = (int)CS$<>8__locals37.$VB$Local_theFlight.CreatedBy;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_23]), createdBy))
					{
						dataRow[int_23] = CS$<>8__locals37.$VB$Local_theFlight.CreatedBy;
					}
					int editedBy = (int)CS$<>8__locals37.$VB$Local_theFlight.EditedBy;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_24]), editedBy))
					{
						dataRow[int_24] = CS$<>8__locals37.$VB$Local_theFlight.EditedBy;
					}
					int num5 = Mission.Flight.AircraftQty_To_AircraftQtySelection(CS$<>8__locals37.$VB$Local_theFlight.DesiredAircraftQty);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_18]), num5))
					{
						dataRow[int_18] = num5;
					}
					int num6 = Mission.Flight.AircraftQty_To_AircraftQtySelection(CS$<>8__locals37.$VB$Local_theFlight.MinimumAircraftQty);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_19]), num6))
					{
						dataRow[int_19] = num6;
					}
					Mission mission = Client.CurrentSide.Missions.Where((CS$<>8__locals37.$I0 != null) ? CS$<>8__locals37.$I0 : (CS$<>8__locals37.$I0 = [SpecialName] (Mission theM) => Operators.CompareString(theM.Name, CS$<>8__locals37.$VB$Local_theFlight.ParentMissionOrPackageName, true) == 0)).ElementAtOrDefault(0);
					mission.ResetFlightReadyAicraftCount(Client.CurrentScenario, CS$<>8__locals37.$VB$Local_theFlight);
					int count2 = CS$<>8__locals37.$VB$Local_theFlight.get_Item(mission, Client.CurrentScenario).Count;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_20]), count2))
					{
						dataRow[int_20] = count2;
					}
					int readyAircraftQty = CS$<>8__locals37.$VB$Local_theFlight.ReadyAircraftQty;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_21]), readyAircraftQty))
					{
						dataRow[int_21] = readyAircraftQty;
					}
				}
			}
			finally
			{
				((Control)DGV_AirTaskingOrder).ResumeLayout();
			}
			if (((DataGridView)DGV_AirTaskingOrder).Rows.Count > 0)
			{
				bool_3 = false;
				method_8();
				if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index > 0 && int_0 != ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index)
				{
					if (int_0 <= ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1)
					{
						((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = false;
					}
					int_0 = ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index;
				}
				((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
				if (((DataGridView)DGV_AirTaskingOrder).RowCount > 0)
				{
					if (int_0 <= ((DataGridView)DGV_AirTaskingOrder).RowCount - 1)
					{
						((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = false;
						((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = true;
					}
					else
					{
						((DataGridView)DGV_AirTaskingOrder).Rows[((DataGridView)DGV_AirTaskingOrder).RowCount - 1].Selected = false;
						((DataGridView)DGV_AirTaskingOrder).Rows[((DataGridView)DGV_AirTaskingOrder).RowCount - 1].Selected = true;
					}
				}
				SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
				if (!Information.IsNothing((object)SelectedFlight))
				{
					string_0 = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
				}
				bool_3 = true;
			}
			else
			{
				SelectedFlight = null;
				SelectedMission = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200583", ex2.Message);
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
		try
		{
			int count = dataTable_0.Rows.Count;
			if (string.IsNullOrEmpty(string_0))
			{
				return;
			}
			int num = count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Mission.Flight flight = SelectedFlightsList[num2];
					if (!Information.IsNothing((object)flight) && Operators.CompareString(flight.ObjectID, string_0, true) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			int count2 = ((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count;
			for (int i = count2 - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)DGV_AirTaskingOrder).SelectedRows[i];
				((DataGridView)DGV_AirTaskingOrder).Rows[((DataGridViewBand)val).Index].Selected = false;
			}
			if (int_0 <= count2 - 1)
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = false;
			}
			((DataGridView)DGV_AirTaskingOrder).Rows[num2].Selected = true;
			int_0 = num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at \u00a8999999", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9()
	{
		try
		{
			int num = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1;
			if (string.IsNullOrEmpty(string_0))
			{
				return;
			}
			int num2 = num;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					Mission.Flight flight = SelectedFlightsList[num3];
					if (!Information.IsNothing((object)flight) && Operators.CompareString(flight.ObjectID, string_0, true) == 0)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			int count = ((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count;
			for (int i = count - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)DGV_AirTaskingOrder).SelectedRows[i];
				((DataGridView)DGV_AirTaskingOrder).Rows[((DataGridViewBand)val).Index].Selected = false;
			}
			if (int_0 <= count - 1)
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = false;
			}
			((DataGridView)DGV_AirTaskingOrder).Rows[num3].Selected = true;
			int_0 = num3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at \u00a8999999", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, DataGridViewCellPaintingEventArgs e)
	{
		try
		{
			if (e.RowIndex == 0 && e.ColumnIndex == int_10)
			{
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds, true);
				e.PaintContent(cellBounds);
			}
			else if (e.RowIndex == 0 && e.ColumnIndex == int_13)
			{
				Rectangle cellBounds2 = e.CellBounds;
				cellBounds2.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds2.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds2, true);
				e.PaintContent(cellBounds2);
			}
			else if (e.RowIndex == 0)
			{
				_ = (e.ColumnIndex == 2) | (e.ColumnIndex == 3);
			}
			if (int_10 == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.SelectionBackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0);
				}
				Rectangle cellBounds3 = e.CellBounds;
				int width = ((DataGridView)DGV_AirTaskingOrder).GetCellDisplayRectangle(int_11, e.RowIndex, true).Width;
				cellBounds3.Width += width;
				ControlPaint.DrawBorder(e.Graphics, cellBounds3, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, Color.Red, 0, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (int_13 == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.SelectionBackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0);
				}
				Rectangle cellBounds4 = e.CellBounds;
				int width2 = ((DataGridView)DGV_AirTaskingOrder).GetCellDisplayRectangle(int_14, e.RowIndex, true).Width;
				cellBounds4.Width += width2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds4, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, Color.Red, 0, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (int_10 == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds5 = e.CellBounds;
				cellBounds5.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds5.Y++;
				cellBounds5.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (int_13 == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds6 = e.CellBounds;
				cellBounds6.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds6.Y++;
				cellBounds6.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (int_11 == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds7 = e.CellBounds;
				cellBounds7.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds7.Height -= 2;
				cellBounds7.Y++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (int_14 == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds8 = e.CellBounds;
				cellBounds8.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds8.Y++;
				cellBounds8.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, ((DataGridView)DGV_AirTaskingOrder).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
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

	public void DisplayLocks()
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		try
		{
			bitmap_0.MakeTransparent(Color.White);
			bitmap_1.MakeTransparent(Color.White);
			bitmap_2.MakeTransparent(Color.White);
			bitmap_3.MakeTransparent(Color.White);
			bitmap_4.MakeTransparent(Color.White);
			bool flag = bool_3;
			bool_3 = false;
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_AirTaskingOrder).Rows)
			{
				DataGridViewRow val = item;
				if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_25].Value), 1))
				{
					if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_25].Value), 0))
					{
						if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_25].Value), 2))
						{
							if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_25].Value), 3))
							{
								if (val.Cells[int_11].Value != bitmap_2)
								{
									val.Cells[int_11].Value = bitmap_2;
								}
							}
							else if (val.Cells[int_11].Value != bitmap_4)
							{
								val.Cells[int_11].Value = bitmap_4;
							}
						}
						else if (val.Cells[int_11].Value != bitmap_3)
						{
							val.Cells[int_11].Value = bitmap_3;
						}
					}
					else if (val.Cells[int_11].Value != bitmap_1)
					{
						val.Cells[int_11].Value = bitmap_1;
					}
				}
				else if (val.Cells[int_11].Value != bitmap_0)
				{
					val.Cells[int_11].Value = bitmap_0;
				}
				if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_26].Value), 1))
				{
					if (val.Cells[int_14].Value != bitmap_0)
					{
						val.Cells[int_14].Value = bitmap_0;
					}
				}
				else if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_26].Value), 0))
				{
					if (val.Cells[int_14].Value != bitmap_1)
					{
						val.Cells[int_14].Value = bitmap_1;
					}
				}
				else if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_26].Value), 2))
				{
					if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells[int_26].Value), 3))
					{
						if (val.Cells[int_14].Value != bitmap_2)
						{
							val.Cells[int_14].Value = bitmap_2;
						}
					}
					else if (val.Cells[int_14].Value != bitmap_4)
					{
						val.Cells[int_14].Value = bitmap_4;
					}
				}
				else if (val.Cells[int_14].Value != bitmap_3)
				{
					val.Cells[int_14].Value = bitmap_3;
				}
				val.Cells[int_18].Value = SelectedFlight.DesiredAircraftQty.value;
				val.Cells[int_19].Value = SelectedFlight.MinimumAircraftQty.value;
			}
			bool_3 = flag;
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

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)DGV_AirTaskingOrder).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				int_0 = i;
				DataGridViewRow val2 = val;
				SelectedFlight = (Mission.Flight)((DataGridViewBand)val2).Tag;
				if (!Information.IsNothing((object)SelectedFlight))
				{
					string_0 = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
				}
				DataGridViewColumn val3 = ((DataGridView)DGV_AirTaskingOrder).Columns[e.ColumnIndex];
				if (Operators.CompareString(val3.Name, "Type", true) != 0)
				{
					if (Operators.CompareString(val3.Name, "Task", true) != 0)
					{
						if (Operators.CompareString(val3.Name, "Priority", true) != 0)
						{
							if (((DataGridViewBand)val3).Index != int_11)
							{
								if (((DataGridViewBand)val3).Index == int_14)
								{
									if (Client.Realtime && !Client.RealtimeAC)
									{
										Client.RealtimeTerminal.SendChangeFlightToggleTargetWaypointTime(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
									}
									else if (CoreClientCode.ChangeFlightToggleTargetWaypointTime_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight))
									{
										flag = true;
										flag4 = true;
										flag2 = true;
									}
									break;
								}
								continue;
							}
							if (Client.Realtime && !Client.RealtimeAC)
							{
								Client.RealtimeTerminal.SendChangeFlightToggleTakeOffWaypointTime(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
							}
							else if (CoreClientCode.ChangeFlightToggleTakeoffWaypointTime_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight))
							{
								flag = true;
								flag4 = true;
								flag2 = true;
							}
							break;
						}
						if (!((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
						{
							DataTable theComboBoxDataSource_Priority = new DataTable();
							DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
							Mission.Flight.ComboBoxDataSource_Priority(ref theComboBoxDataSource_Priority);
							val4.DataSource = theComboBoxDataSource_Priority;
							val4.DisplayMember = "Description";
							val4.ValueMember = "ID";
							val4.DropDownWidth = 500;
						}
						((DataGridView)DGV_AirTaskingOrder).BeginEdit(true);
						if (((DataGridView)DGV_AirTaskingOrder).Rows[e.RowIndex].Cells[((DataGridViewColumn)Task).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_AirTaskingOrder).EditingControl))
						{
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_AirTaskingOrder).EditingControl).DroppedDown = true;
						}
						break;
					}
					if (!((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
					{
						DataTable theComboBoxDataSource_Task = new DataTable();
						DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
						Mission.Flight.ComboBoxDataSource_Task(ref theComboBoxDataSource_Task);
						val5.DataSource = theComboBoxDataSource_Task;
						val5.DisplayMember = "Description";
						val5.ValueMember = "ID";
						val5.DropDownWidth = 500;
					}
					((DataGridView)DGV_AirTaskingOrder).BeginEdit(true);
					if (((DataGridView)DGV_AirTaskingOrder).Rows[e.RowIndex].Cells[((DataGridViewColumn)Task).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_AirTaskingOrder).EditingControl))
					{
						((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_AirTaskingOrder).EditingControl).DroppedDown = true;
					}
					break;
				}
				if (!((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
				{
					DataTable theComboBoxDataSource_Type = new DataTable();
					DataGridViewComboBoxCell val6 = (DataGridViewComboBoxCell)((DataGridView)DGV_AirTaskingOrder)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
					Mission.Flight.ComboBoxDataSource_Type(ref theComboBoxDataSource_Type);
					val6.DataSource = theComboBoxDataSource_Type;
					val6.DisplayMember = "Description";
					val6.ValueMember = "ID";
					val6.DropDownWidth = 200;
				}
				((DataGridView)DGV_AirTaskingOrder).BeginEdit(true);
				if (((DataGridView)DGV_AirTaskingOrder).Rows[e.RowIndex].Cells[((DataGridViewColumn)Task).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_AirTaskingOrder).EditingControl))
				{
					((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_AirTaskingOrder).EditingControl).DroppedDown = true;
				}
				break;
			}
			if (flag3)
			{
				if (((Control)Client.FlightPlanEditorWindow).Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
				{
					Client.FlightPlanEditorWindow.LoadGrid();
				}
			}
			else if (flag && ((Control)Client.FlightPlanEditorWindow).Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
			{
				Client.FlightPlanEditorWindow.RefreshGrid();
				if (flag4)
				{
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				}
			}
			if (flag2)
			{
				method_7();
				DisplayLocks();
			}
			EnableAndDisableButtons();
			Client.MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200583", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RecalculateFlightPlanFuelAndTimes(bool RefreshMainform, bool RefreshFlightplanEditorWindow, bool RefreshFlightplanEditorWindow_ReloadhGrid, bool RefreshFlightplanEditorWindow_DrawLocks)
	{
		try
		{
			if (((Control)Client.FlightPlanEditorWindow).Visible && RefreshFlightplanEditorWindow)
			{
				if (!RefreshFlightplanEditorWindow_ReloadhGrid)
				{
					Client.FlightPlanEditorWindow.RefreshGrid();
					if (RefreshFlightplanEditorWindow_DrawLocks)
					{
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
					}
				}
				else
				{
					Client.FlightPlanEditorWindow.LoadGrid();
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

	private void method_12(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count != 0 && bool_3)
		{
			method_14(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		bool_3 = true;
		if (((DataGridView)DGV_AirTaskingOrder).IsCurrentCellDirty)
		{
			((DataGridView)DGV_AirTaskingOrder).CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_14(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Invalid comparison between Unknown and I4
		Mission.Flight flight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).Rows[e.RowIndex]).Tag;
		if (Information.IsNothing((object)flight))
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		if (e.RowIndex != -1 && e.ColumnIndex == int_4)
		{
			Mission._FlightType flightType = Mission.Flight.TypeSelection_To_Type(Conversions.ToInteger(((DataGridView)DGV_AirTaskingOrder)[e.ColumnIndex, e.RowIndex].Value));
			Scenario theScenario = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			bool num = ValidateChangeFlightType(flight, ref theScenario, ref theSide, ref SelectedMission, flightType);
			Client.CurrentSide = theSide;
			int num2;
			if (num)
			{
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightType(Client.CurrentScenario, Client.CurrentSide, SelectedMission, flight, flightType);
					num2 = 1;
				}
				else
				{
					theScenario = Client.CurrentScenario;
					theSide = Client.CurrentSide;
					ChangeFlightType(flight, ref theScenario, ref theSide, ref SelectedMission, flightType);
					Client.CurrentSide = theSide;
					num2 = 1;
				}
			}
			else
			{
				num2 = 1;
			}
			flag = (byte)num2 != 0;
			flag3 = true;
			flag4 = true;
			flag5 = true;
			flag6 = true;
			flag7 = true;
		}
		if (e.RowIndex != -1 && e.ColumnIndex == int_5)
		{
			Mission._FlightTask flightTask = Mission.Flight.TaskSelection_To_Task(Conversions.ToInteger(((DataGridView)DGV_AirTaskingOrder)[e.ColumnIndex, e.RowIndex].Value));
			if (flightTask == Mission._FlightTask.QRA)
			{
				if (SelectedMission.MissionClass != Mission._MissionClass.Patrol && SelectedMission.MissionClass != Mission._MissionClass.Support)
				{
					Interaction.MsgBox((object)"Only patrol and support missions may use flights of type QRA.", (MsgBoxStyle)0, (object)null);
					RefreshWindow();
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
					RefreshWindow();
					return;
				}
				if (SelectedFlight.FlightPlan.Count() > 0 && !Information.IsNothing((object)SelectedFlight.FlightPlan[0].Time_Zulu) && (int)Interaction.MsgBox((object)"Changing the flight task type to QRA will clear all waypoints times. Continue?", (MsgBoxStyle)4, (object)null) == 7)
				{
					RefreshWindow();
					return;
				}
			}
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendChangeFlightTask(Client.CurrentScenario, Client.CurrentSide, SelectedMission, flight, flightTask);
			}
			else
			{
				CoreClientCode.ChangeFlightTask_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, flight, flightTask);
				flag2 = true;
				flag = true;
				flag3 = true;
			}
		}
		if (e.RowIndex != -1 && e.ColumnIndex == int_22)
		{
			Mission._FlightPriority priority = Mission.Flight.PrioritySelection_To_Priority(Conversions.ToInteger(((DataGridView)DGV_AirTaskingOrder)[e.ColumnIndex, e.RowIndex].Value));
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendChangeFlightPriority(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, priority);
			}
			else
			{
				flight.Priority = priority;
			}
		}
		if (e.RowIndex != -1 && e.ColumnIndex == int_18)
		{
			Mission._FlightSize flightSize = Mission.Flight.AircraftQtySelection_To_AircraftQty(Conversions.ToInteger(((DataGridView)DGV_AirTaskingOrder)[e.ColumnIndex, e.RowIndex].Value));
			if (!Information.IsNothing((object)SelectedFlight))
			{
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightSize(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flightSize, SelectedFlight.MinimumAircraftQty);
				}
				else
				{
					Mission.Flight selectedFlight = SelectedFlight;
					Scenario theScenario = Client.CurrentScenario;
					selectedFlight.ChangeDesiredFlightSize(ref theScenario, ref SelectedMission, Client.CurrentSide, flightSize);
					flag = true;
					flag4 = true;
					flag3 = true;
				}
			}
			AMP_General.RefreshFlightPlanErrorWindow();
			Client.MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		if (e.RowIndex != -1 && e.ColumnIndex == int_19)
		{
			Mission._FlightSize flightSize2 = Mission.Flight.AircraftQtySelection_To_AircraftQty(Conversions.ToInteger(((DataGridView)DGV_AirTaskingOrder)[e.ColumnIndex, e.RowIndex].Value));
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendChangeFlightSize(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, SelectedFlight.DesiredAircraftQty, flightSize2);
			}
			else
			{
				Mission.Flight selectedFlight2 = SelectedFlight;
				Scenario theScenario = Client.CurrentScenario;
				selectedFlight2.ChangeMinimumFlightSize(ref theScenario, ref SelectedMission, Client.CurrentSide, flightSize2);
				flag = true;
				flag4 = true;
			}
		}
		if (!flag3)
		{
			if (flag2 && ((Control)Client.FlightPlanEditorWindow).Visible)
			{
				Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
				Client.FlightPlanEditorWindow.RefreshGrid();
			}
		}
		else if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
			Client.FlightPlanEditorWindow.LoadGrid();
		}
		if (flag && ((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
			Client.AirTaskingOrderWindow.EnableAndDisableButtons();
			if (flag6)
			{
				DisplayLocks();
			}
		}
		if (flag4 && ((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		if (flag5)
		{
			EnableAndDisableCells();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		if (flag7)
		{
			AMP_General.RefreshFlightPlanErrorWindow();
		}
		bool_3 = false;
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight))
		{
			Client.FlightPlanEditorWindow.SelectedMission = SelectedMission;
			Client.FlightPlanEditorWindow.SelectedFlight = SelectedFlight;
			if (((Control)Client.FlightPlanEditorWindow).Visible)
			{
				Client.FlightPlanEditorWindow.ReloadWindow();
				((Control)Client.FlightPlanEditorWindow).BringToFront();
			}
			else
			{
				((Control)Client.FlightPlanEditorWindow).Show();
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("select a Mission and create at least one flight", "Missing mission or flight");
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		if (!bool_3 || ((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count == 0 || ((DataGridView)DGV_AirTaskingOrder).Rows.Count <= 0)
		{
			return;
		}
		if (((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag == null)
		{
			((DataGridView)DGV_AirTaskingOrder).ClearSelection();
			int num = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)DGV_AirTaskingOrder).Rows[0];
				if (!val.Visible)
				{
					continue;
				}
				int num2 = ((BaseCollection)val.Cells).Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (val.Cells[j].Visible)
					{
						((DataGridView)DGV_AirTaskingOrder).SelectionChanged -= method_16;
						((DataGridView)DGV_AirTaskingOrder).CurrentCell = ((DataGridView)DGV_AirTaskingOrder).Rows[i].Cells[j];
						((DataGridView)DGV_AirTaskingOrder).Rows[i].Selected = true;
						((DataGridView)DGV_AirTaskingOrder).SelectionChanged += method_16;
					}
				}
			}
		}
		SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
		if (!Information.IsNothing((object)SelectedFlight))
		{
			string_0 = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
		}
		EnableAndDisableButtons();
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (Client.CurrentSide.Missions.Count == 0)
		{
			return;
		}
		if (Information.IsNothing((object)SelectedMission))
		{
			if (Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", true) == 0 || Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_All", true) == 0 || Operators.CompareString(AirTaskingOrderFilterSetting, "", true) == 0)
			{
				Interaction.MsgBox((object)"Could not determine which mission to create flight for. Select an existing flight to make a new flight for that same mission, or filter the ATO on a specific mission.", (MsgBoxStyle)0, (object)null);
				return;
			}
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (Operators.CompareString(AirTaskingOrderFilterSetting, mission.ObjectID, true) == 0)
				{
					SelectedMission = mission;
				}
			}
		}
		if (!Information.IsNothing((object)SelectedMission))
		{
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendMissionCreateFlight(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedMission.FlightSize, isEscort: false);
			}
			else
			{
				CoreClientCode.CreateFlight_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedMission.FlightSize, isEscort: false);
			}
			method_6();
			if (((Control)Client.FlightPlanEditorWindow).Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
			{
				Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
			}
			if (((Control)Client.MissionEditorWindow).Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count <= 0)
			{
				return;
			}
			int_0 = ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index;
			SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
			if (!Information.IsNothing((object)SelectedFlight))
			{
				string_0 = SelectedFlight.ObjectID;
				SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
			}
			if (int_0 > 0)
			{
				((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
				((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = false;
			}
		}
		else
		{
			Interaction.MsgBox((object)"Could not generate a new flight. Does the side have any missions, and is the ATO filter setting correct?", (MsgBoxStyle)0, (object)null);
		}
	}

	private bool method_18(string string_1)
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (Operators.CompareString(flight.Callsign, string_1, true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	private void method_19(object sender, EventArgs e)
	{
		if (SelectedFlight == null)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendMissionCopyFlight(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			return;
		}
		CoreClientCode.CopyFlight_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
		method_6();
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		if (((Control)Client.FlightPlanEditorWindow).Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
		{
			Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
		}
		AMP_General.RefreshFlightPlanErrorWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
		if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count <= 0)
		{
			return;
		}
		method_9();
		int_0 = ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index;
		SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
		if (!Information.IsNothing((object)SelectedFlight))
		{
			string_0 = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
		}
		if (int_0 > 0)
		{
			((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
			((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = true;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count == 0)
		{
			return;
		}
		if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count == 1)
		{
			if (Information.IsNothing((object)SelectedFlight))
			{
				return;
			}
			if (Information.IsNothing((object)SelectedFlight))
			{
				method_6();
				return;
			}
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendMissionDeleteFlight(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			}
			else
			{
				CoreClientCode.DeleteFlight_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			}
			for (int i = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)DGV_AirTaskingOrder).Rows[i];
				if (val.Selected && !Information.IsNothing((object)(Mission.Flight)((DataGridViewBand)val).Tag))
				{
					((DataGridView)DGV_AirTaskingOrder).Rows.RemoveAt(i);
				}
			}
			SelectedFlight = null;
		}
		else
		{
			for (int j = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1; j >= 0; j += -1)
			{
				DataGridViewRow val2 = ((DataGridView)DGV_AirTaskingOrder).Rows[j];
				if (!val2.Selected)
				{
					continue;
				}
				Mission.Flight flight = (Mission.Flight)((DataGridViewBand)val2).Tag;
				if (Information.IsNothing((object)flight))
				{
					continue;
				}
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (mission.FlightList.Contains(flight))
					{
						if (Client.Realtime && !Client.RealtimeAC)
						{
							Client.RealtimeTerminal.SendMissionDeleteFlight(Client.CurrentScenario, Client.CurrentSide, mission, flight);
						}
						else
						{
							CoreClientCode.DeleteFlight_Core(Client.CurrentScenario, Client.CurrentSide, mission, flight);
						}
						break;
					}
				}
			}
		}
		LoadWindow();
		if (((Control)Client.FlightPlanEditorWindow).Visible && !SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
		{
			Client.FlightPlanEditorWindow.SelectedFlight = null;
			Client.FlightPlanEditorWindow.LoadGrid();
		}
		if (((Control)Client.FlightPlanAircraftLoadoutWindow).Visible && !SelectedMission.FlightList.Contains(Client.FlightPlanAircraftLoadoutWindow.SelectedFlight))
		{
			Client.FlightPlanAircraftLoadoutWindow.SelectedFlight = null;
			Client.FlightPlanAircraftLoadoutWindow.RefreshStats();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		AMP_General.RefreshFlightPlanErrorWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
		if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count <= 0)
		{
			return;
		}
		int_0 = ((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Index;
		SelectedFlight = (Mission.Flight)((DataGridViewBand)((DataGridView)DGV_AirTaskingOrder).SelectedRows[0]).Tag;
		if (!Information.IsNothing((object)SelectedFlight))
		{
			string_0 = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where([SpecialName] (Mission theM) => Operators.CompareString(theM.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, true) == 0).ElementAtOrDefault(0);
		}
		if (int_0 > 0)
		{
			((DataGridView)DGV_AirTaskingOrder).Rows[0].Selected = false;
			((DataGridView)DGV_AirTaskingOrder).Rows[int_0].Selected = true;
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)((ComboBox)ComboBox_PlannedFlightPlanVisibility).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void AirTaskingOrder_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 122 && e.Control && e.Shift && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)((ComboBox)ComboBox_AirborneFlightPlanVisibility).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_23(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight))
		{
			if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				Client.FlightPlanAircraftLoadoutWindow.SelectedMission = SelectedMission;
				Client.FlightPlanAircraftLoadoutWindow.SelectedFlight = SelectedFlight;
				if (!((Control)Client.FlightPlanAircraftLoadoutWindow).Visible)
				{
					((Control)Client.FlightPlanAircraftLoadoutWindow).Show();
					return;
				}
				Client.FlightPlanAircraftLoadoutWindow.ReloadWindow();
				((Control)Client.FlightPlanAircraftLoadoutWindow).BringToFront();
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("select a Mission and create at least one flight", "Missing mission or flight");
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		bool flag = false;
		int num = SelectedFlight.FlightPlan.Count() - 1;
		Waypoint theSelectedWaypoint = default(Waypoint);
		for (int i = 0; i <= num; i++)
		{
			theSelectedWaypoint = SelectedFlight.FlightPlan[i];
			if (theSelectedWaypoint.Type == Waypoint.WaypointType.TakeOff)
			{
				flag = true;
				break;
			}
		}
		if (flag && !Information.IsNothing((object)theSelectedWaypoint))
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = false;
			Client.FlightPlanTimeWindow.RefreshStats(ref SelectedMission, ref SelectedFlight, ref theSelectedWaypoint, Mission.Flight.FlightElement.LeadElement, SetDateTimeIfNeccessary: true);
			((Control)Client.FlightPlanTimeWindow).Show();
			((Control)Client.FlightPlanTimeWindow).BringToFront();
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		bool flag = false;
		int num = SelectedFlight.FlightPlan.Count() - 1;
		int num2 = 0;
		Waypoint theSelectedWaypoint = default(Waypoint);
		while (num2 <= num)
		{
			theSelectedWaypoint = SelectedFlight.FlightPlan[num2];
			int num3;
			if (theSelectedWaypoint.Type != Waypoint.WaypointType.Target && theSelectedWaypoint.Type != Waypoint.WaypointType.WeaponTarget)
			{
				if (!theSelectedWaypoint.IsStationStartWaypoint())
				{
					num2++;
					continue;
				}
				num3 = 1;
			}
			else
			{
				num3 = 1;
			}
			flag = (byte)num3 != 0;
			break;
		}
		if (flag)
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = false;
			Client.FlightPlanTimeWindow.RefreshStats(ref SelectedMission, ref SelectedFlight, ref theSelectedWaypoint, Mission.Flight.FlightElement.LeadElement, SetDateTimeIfNeccessary: true);
			((Control)Client.FlightPlanTimeWindow).Show();
			((Control)Client.FlightPlanTimeWindow).BringToFront();
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		bool isPackage = !Information.IsNothing((object)SelectedMission) && SelectedMission.Category == Mission.MissionCategory.Package;
		if (!ValidateClearFlightTime(SelectedFlight, isPackage))
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendClearFlightTimes(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
			return;
		}
		CoreClientCode.ClearFlightTime_Core(SelectedFlight);
		Mission.Flight selectedFlight2;
		if (!Information.IsNothing((object)SelectedFlight))
		{
			Scenario currentScenario = Client.CurrentScenario;
			Mission selectedMission = SelectedMission;
			ActiveUnit theAU = SelectedFlight.get_ReferenceUnit(Client.CurrentScenario);
			Mission.Flight selectedFlight = SelectedFlight;
			Waypoint[] theFlightplan = (selectedFlight2 = SelectedFlight).FlightPlan;
			float NecessaryFuel = 0f;
			float MissionFuel = 0f;
			MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, selectedMission, theAU, selectedFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SelectedMission.TakeOffTime, SelectedMission.TimeOnTarget, IsMFP: false);
			selectedFlight2.FlightPlan = theFlightplan;
		}
		RecalculateFlightPlanFuelAndTimes(RefreshMainform: false, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: true);
		FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
		Mission theSelectedMission = null;
		selectedFlight2 = null;
		Waypoint theSelectedWaypoint = null;
		flightPlanTimeWindow.RefreshStats(ref theSelectedMission, ref selectedFlight2, ref theSelectedWaypoint, Mission.Flight.FlightElement.None, SetDateTimeIfNeccessary: false);
		method_6();
		AMP_General.RefreshFlightPlanErrorWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void EnableAndDisableButtons()
	{
		try
		{
			if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count == 1)
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				if (Information.IsNothing((object)SelectedFlight))
				{
					Button_CopyFlight.Enabled = false;
					Button_DeleteFlight.Enabled = false;
					Button_FlightPlanEditor.Enabled = false;
					Button_ChangeAircraftType.Enabled = false;
					return;
				}
				Button_CopyFlight.Enabled = true;
				Button_DeleteFlight.Enabled = true;
				Button_FlightPlanEditor.Enabled = true;
				if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					Button_ChangeAircraftType.Enabled = true;
				}
				else
				{
					Button_ChangeAircraftType.Enabled = false;
				}
				if (SelectedFlight.Type != Mission._FlightType.Flightplan || SelectedFlight.Task == Mission._FlightTask.QRA)
				{
					return;
				}
				int num = ((DataGridView)DGV_AirTaskingOrder).Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!((DataGridView)DGV_AirTaskingOrder).Rows[i].Selected || Information.IsNothing((object)SelectedFlight))
					{
						continue;
					}
					if (SelectedFlight.FlightPlan.Count() <= 0)
					{
						break;
					}
					int num2 = SelectedFlight.FlightPlan.Count() - 1;
					bool flag = false;
					int num3 = num2;
					for (int j = 0; j <= num3; j++)
					{
						Waypoint waypoint = SelectedFlight.FlightPlan[j];
						if (!flag && !Information.IsNothing((object)waypoint.Time_Zulu))
						{
							flag = true;
						}
						if (waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
							{
								Button_ChangeTakeOffTime.Enabled = true;
							}
							else
							{
								Button_ChangeTakeOffTime.Enabled = false;
							}
						}
						else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.IsStationStartWaypoint())
						{
							Button_ChangeObjectiveTime.Enabled = true;
							break;
						}
					}
					if (flag)
					{
						Button_ClearTime.Enabled = true;
					}
					break;
				}
			}
			else if (((BaseCollection)((DataGridView)DGV_AirTaskingOrder).SelectedRows).Count <= 1)
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_CopyFlight.Enabled = false;
				Button_DeleteFlight.Enabled = false;
				Button_FlightPlanEditor.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
			}
			else
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_CopyFlight.Enabled = false;
				Button_DeleteFlight.Enabled = true;
				Button_FlightPlanEditor.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
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

	public void EnableAndDisableCells()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		try
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_AirTaskingOrder).Rows)
			{
				DataGridViewRow val = item;
				Mission.Flight flight = (Mission.Flight)((DataGridViewBand)val).Tag;
				if (Information.IsNothing((object)flight))
				{
					continue;
				}
				if (flight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					if (val.Cells["Type"].ReadOnly)
					{
						val.Cells["Type"].ReadOnly = false;
						val.Cells["Type"].Style.BackColor = default(Color);
						val.Cells["Type"].Style.SelectionBackColor = default(Color);
					}
					if (val.Cells["Priority"].ReadOnly)
					{
						val.Cells["Priority"].ReadOnly = false;
						val.Cells["Priority"].Style.BackColor = default(Color);
						val.Cells["Priority"].Style.SelectionBackColor = default(Color);
					}
					if (val.Cells["DesiredAircraftQty"].ReadOnly)
					{
						val.Cells["DesiredAircraftQty"].ReadOnly = false;
						val.Cells["DesiredAircraftQty"].Style.BackColor = default(Color);
						val.Cells["DesiredAircraftQty"].Style.SelectionBackColor = default(Color);
					}
					if (val.Cells["MinimumAircraftQty"].ReadOnly)
					{
						val.Cells["MinimumAircraftQty"].ReadOnly = false;
						val.Cells["MinimumAircraftQty"].Style.BackColor = default(Color);
						val.Cells["MinimumAircraftQty"].Style.SelectionBackColor = default(Color);
					}
				}
				else
				{
					val.Cells["Type"].ReadOnly = true;
					val.Cells["Type"].Style.BackColor = Color.LightGray;
					val.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["Type"].Style.SelectionForeColor = Color.Black;
					val.Cells["Priority"].ReadOnly = true;
					val.Cells["Priority"].Style.BackColor = Color.LightGray;
					val.Cells["Priority"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["Priority"].Style.SelectionForeColor = Color.Black;
					val.Cells["DesiredAircraftQty"].ReadOnly = true;
					val.Cells["DesiredAircraftQty"].Style.BackColor = Color.LightGray;
					val.Cells["DesiredAircraftQty"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["DesiredAircraftQty"].Style.SelectionForeColor = Color.Black;
					val.Cells["MinimumAircraftQty"].ReadOnly = true;
					val.Cells["MinimumAircraftQty"].Style.BackColor = Color.LightGray;
					val.Cells["MinimumAircraftQty"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["MinimumAircraftQty"].Style.SelectionForeColor = Color.Black;
				}
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
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)ComboBox_AirTaskingOrderFilter).SelectedIndex == 0)
		{
			AirTaskingOrderFilterSetting = "Filter_ATO_Only";
			method_6();
			return;
		}
		if (((ComboBox)ComboBox_AirTaskingOrderFilter).SelectedIndex == 1)
		{
			AirTaskingOrderFilterSetting = "Filter_All";
			method_6();
			return;
		}
		string text = Conversions.ToString(((ComboBox)ComboBox_AirTaskingOrderFilter).SelectedItem);
		bool flag = false;
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (Operators.CompareString(mission.Name, text, true) == 0)
			{
				SelectedMission = mission;
				AirTaskingOrderFilterSetting = mission.ObjectID;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			AirTaskingOrderFilterSetting = "";
		}
		if (flag && Operators.CompareString(SelectedMission.Name, text, true) == 0)
		{
			int_0 = 0;
			SelectedFlight = null;
			string_0 = "";
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_AirTaskingOrder).Rows)
		{
			item.Selected = false;
		}
		method_6();
	}

	private void method_28(object sender, EventArgs e)
	{
		airTaskingOrderSortType_0 = (AirTaskingOrderSortType)((ComboBox)ComboBox_AirTaskingOrderSorting).SelectedIndex;
		method_6();
	}

	public static bool ValidateUpdateWingmanWaypoints(Mission theMission, Mission.Flight theFlight, Waypoint theWaypoint, Waypoint[] theFlightplan, Mission.Flight.FlightElement theFlightPlan_Element)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		if (theWaypoint == null)
		{
			return false;
		}
		int result;
		if (theFlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
		{
			Waypoint mainWaypointFromFlightElementWaypoint_Core = CoreClientCode.GetMainWaypointFromFlightElementWaypoint_Core(theFlightplan, theWaypoint, theFlightPlan_Element);
			if (mainWaypointFromFlightElementWaypoint_Core == null)
			{
				result = 0;
				goto IL_006b;
			}
			bool flag = theMission.MissionClass == Mission._MissionClass.Strike && (mainWaypointFromFlightElementWaypoint_Core.Type == Waypoint.WaypointType.Target || mainWaypointFromFlightElementWaypoint_Core.Type == Waypoint.WaypointType.WeaponTarget);
			if (!mainWaypointFromFlightElementWaypoint_Core.Time_Zulu.HasValue)
			{
				return true;
			}
			if (flag && (int)Interaction.MsgBox((object)"You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?", (MsgBoxStyle)4, (object)null) == 6)
			{
				return true;
			}
		}
		result = 0;
		goto IL_006b;
		IL_006b:
		return (byte)result != 0;
	}

	public static void UpdateWingmanWaypoints(Mission.Flight theFlight, ref Waypoint TheWaypoint, ref Mission theMission, ref Waypoint[] theFlightplan, Mission.Flight.FlightElement theFlightPlan_Element)
	{
		try
		{
			bool flag = ValidateLockWingmanTargetWaypoints(theFlight, ref theMission, ref TheWaypoint, AskForConfirmation: true);
			bool flag2 = ValidateUpdateWingmanWaypoints(theMission, theFlight, TheWaypoint, theFlightplan, theFlightPlan_Element);
			if (Client.Realtime && !Client.RealtimeAC)
			{
				if (flag && !flag2)
				{
					Client.RealtimeTerminal.SendChangeFlightPlanWaypointUpdateLockWingmanTargetTime(Client.CurrentScenario, Client.CurrentSide, theMission, theFlight, TheWaypoint, theFlightPlan_Element);
				}
				else
				{
					Client.RealtimeTerminal.SendChangeFlightPlanWaypointUpdateWingmanTargetTime(Client.CurrentScenario, Client.CurrentSide, theMission, theFlight, TheWaypoint, theFlightPlan_Element, flag);
				}
				return;
			}
			if (flag)
			{
				CoreClientCode.LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint);
			}
			if (flag2)
			{
				CoreClientCode.UpdateWingmanWaypoints_Core(theFlight, ref TheWaypoint, ref theMission, ref theFlightplan, theFlightPlan_Element);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101343", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool ValidateChangeFlightType(Mission.Flight theFlight, ref Scenario theScenario, ref Side theSide, ref Mission theMission, Mission._FlightType theFlightType)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if (theFlightType == Mission._FlightType.FlightplanTemplate && (int)Interaction.MsgBox((object)"You have selected to change the flightplan to a Template. This will remove all aircraft (If any) from the flight And remove flightplan waypoint times (If Set). Do you wish To proceed?", (MsgBoxStyle)4, (object)null) == 7)
		{
			return false;
		}
		return true;
	}

	public static void ChangeFlightType(Mission.Flight theFlight, ref Scenario theScenario, ref Side theSide, ref Mission theMission, Mission._FlightType theFlightType)
	{
		try
		{
			CoreClientCode.ChangeFlightType_Core(theFlight, ref theScenario, ref theSide, ref theMission, theFlightType);
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

	public static bool ValidateLockWingmanTargetWaypoints(Mission.Flight theFlight, ref Mission theMission, ref Waypoint TheWaypoint, bool AskForConfirmation)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Invalid comparison between Unknown and I4
		if ((TheWaypoint.Type == Waypoint.WaypointType.Target || TheWaypoint.Type == Waypoint.WaypointType.WeaponTarget) && TheWaypoint.HasWingmanWaypoints())
		{
			bool flag = true;
			if (!Information.IsNothing((object)TheWaypoint.Waypoint_LeadElementWingman) && TheWaypoint.Waypoint_LeadElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing((object)TheWaypoint.Waypoint_SecondElement) && TheWaypoint.Waypoint_SecondElement.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing((object)TheWaypoint.Waypoint_SecondElementWingman) && TheWaypoint.Waypoint_SecondElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing((object)TheWaypoint.Waypoint_ThirdElement) && TheWaypoint.Waypoint_ThirdElement.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing((object)TheWaypoint.Waypoint_ThirdElementWingman) && TheWaypoint.Waypoint_ThirdElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!flag)
			{
				int result;
				if (AskForConfirmation)
				{
					if ((int)Interaction.MsgBox((object)("You have chosen To set And lock the time For a Target waypoint. Would you also Like To set relative times For wingman waypoints? The mission's default time separation interval between aircraft will be used: " + Conversions.ToString(TheWaypoint.Separation_Time) + " seconds."), (MsgBoxStyle)4, (object)null) != 6)
					{
						goto IL_00f8;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			return true;
		}
		goto IL_00f8;
		IL_00f8:
		return false;
	}

	public static void LockWingmanTargetWaypoints(Mission.Flight theFlight, ref Mission theMission, ref Waypoint TheWaypoint, bool AskForConfirmation)
	{
		try
		{
			if (ValidateLockWingmanTargetWaypoints(theFlight, ref theMission, ref TheWaypoint, AskForConfirmation))
			{
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightPlanWaypointUpdateLockWingmanTargetTime(Client.CurrentScenario, Client.CurrentSide, theMission, theFlight, TheWaypoint, Mission.Flight.FlightElement.None);
				}
				else
				{
					CoreClientCode.LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101342", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool ValidateClearFlightTime(Mission.Flight theFlight, bool IsPackage)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		int result;
		if (!IsPackage)
		{
			result = 1;
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Flightplans in packages should always have waypoint times set! Are you sure you want to clear the waypoint times?", (MsgBoxStyle)1, (object)null) == 2)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public static void ClearFlightTime(Mission theMission, Mission.Flight theFlight, bool IsPackage)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		try
		{
			if (!IsPackage || (int)Interaction.MsgBox((object)"Flightplans in packages should always have waypoint times set! Are you sure you want to clear the waypoint times?", (MsgBoxStyle)1, (object)null) != 2)
			{
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendClearFlightTimes(Client.CurrentScenario, Client.CurrentSide, theMission, theFlight);
				}
				else
				{
					CoreClientCode.ClearFlightTime_Core(theFlight);
				}
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

	static AirTaskingOrder()
	{
		Class72.smethod_20();
	}
}
