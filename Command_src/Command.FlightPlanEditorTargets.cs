using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargets : DarkSecondaryFormBase
{
	public enum WeaponeeringLostTargetSelection : byte
	{
		ExpenOrdnancedOnCoordinate,
		FindNewTarget_OtherwiseExpendOrdnanceOnCoordinate,
		BringBackOrJettisonOrdnance,
		FindNewTarget_OtherwiseBringBackOrJettisonOrdnance
	}

	[CompilerGenerated]
	internal sealed class _Closure$__161-0
	{
		public Waypoint $VB$Local_theWaypoint;

		public _Closure$__161-0(_Closure$__161-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWaypoint = arg0.$VB$Local_theWaypoint;
			}
		}

		[SpecialName]
		internal double _Lambda$__0(Contact theC)
		{
			return Math2.CalcDist_Angular($VB$Local_theWaypoint.Latitude, $VB$Local_theWaypoint.Longitude, ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null));
		}

		static _Closure$__161-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public Waypoint $VB$Local_theWaypoint;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWaypoint = arg0.$VB$Local_theWaypoint;
			}
		}

		[SpecialName]
		internal double _Lambda$__0(Contact theC)
		{
			return Math2.CalcDist_Angular($VB$Local_theWaypoint.Latitude, $VB$Local_theWaypoint.Longitude, ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null));
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("ComboBox_TargteeringMethod")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_TargteeringMethod;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Weaponeering")]
	private DarkTreeGridView _TGV_Weaponeering;

	[AccessedThroughProperty("TGV_Targeteering")]
	[CompilerGenerated]
	private DarkTreeGridView _TGV_Targeteering;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditArea")]
	private DarkButton _Button_EditArea;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditPreliminaryTargetLocation")]
	private DarkButton _Button_EditPreliminaryTargetLocation;

	[AccessedThroughProperty("Button_EditCoordinate")]
	[CompilerGenerated]
	private DarkButton _Button_EditCoordinate;

	[AccessedThroughProperty("Button_AddHighlighted")]
	[CompilerGenerated]
	private DarkButton _Button_AddHighlighted;

	[AccessedThroughProperty("Button_EditRoute")]
	[CompilerGenerated]
	private DarkButton _Button_EditRoute;

	[AccessedThroughProperty("Button_SetTimeReferenceWeapon")]
	[CompilerGenerated]
	private DarkButton _Button_SetTimeReferenceWeapon;

	public int SelectedTargeteeringTab;

	public int SelectedRow;

	private List<WeaponRec> list_0;

	private string string_0;

	public Waypoint TargetWaypoint_Lead;

	public Waypoint IPWaypoint_Lead;

	private bool bool_2;

	private bool bool_3;

	private List<string> list_1;

	private List<string> list_2;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public List<string> AircraftList;

	public string SelectedAircraft;

	internal virtual DarkUIComboBox ComboBox_TargteeringMethod
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_TargteeringMethod;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIComboBox darkUIComboBox = _ComboBox_TargteeringMethod;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_TargteeringMethod = value;
			darkUIComboBox = _ComboBox_TargteeringMethod;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3 { get; set; }

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual TreeGridColumn ID { get; set; }

	[field: AccessedThroughProperty("TargetName")]
	internal virtual DataGridViewTextBoxColumn TargetName { get; set; }

	[field: AccessedThroughProperty("AssignedWeapons")]
	internal virtual DataGridViewTextBoxColumn AssignedWeapons { get; set; }

	[field: AccessedThroughProperty("Time_Zulu")]
	internal virtual DataGridViewTextBoxColumn Time_Zulu { get; set; }

	[field: AccessedThroughProperty("Time_Local")]
	internal virtual DataGridViewTextBoxColumn Time_Local { get; set; }

	[field: AccessedThroughProperty("Coordinates")]
	internal virtual DataGridViewTextBoxColumn Coordinates { get; set; }

	[field: AccessedThroughProperty("WeaponType")]
	internal virtual TreeGridColumn WeaponType { get; set; }

	[field: AccessedThroughProperty("Target")]
	internal virtual DataGridViewComboBoxColumn Target { get; set; }

	[field: AccessedThroughProperty("LostTarget")]
	internal virtual DataGridViewComboBoxColumn LostTarget { get; set; }

	[field: AccessedThroughProperty("WeaponQty")]
	internal virtual DataGridViewComboBoxColumn WeaponQty { get; set; }

	[field: AccessedThroughProperty("FiringRange")]
	internal virtual DataGridViewComboBoxColumn FiringRange { get; set; }

	[field: AccessedThroughProperty("Route")]
	internal virtual DataGridViewTextBoxColumn Route { get; set; }

	[field: AccessedThroughProperty("Button_EditToT")]
	internal virtual DarkButton Button_EditToT { get; set; }

	private virtual DarkTreeGridView TGV_Weaponeering
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Weaponeering;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			ExpandingEventHandler value2 = method_10;
			CollapsingEventHandler value3 = method_12;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_16);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_18);
			EventHandler eventHandler = method_21;
			DarkTreeGridView darkTreeGridView = _TGV_Weaponeering;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
				((DataGridView)darkTreeGridView).CellClick -= val;
				((DataGridView)darkTreeGridView).CellValueChanged -= val2;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged -= eventHandler;
			}
			_TGV_Weaponeering = value;
			darkTreeGridView = _TGV_Weaponeering;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding += value2;
				darkTreeGridView.NodeCollapsing += value3;
				((DataGridView)darkTreeGridView).CellClick += val;
				((DataGridView)darkTreeGridView).CellValueChanged += val2;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button_EditWRA")]
	internal virtual DarkButton Button_EditWRA { get; set; }

	private virtual DarkTreeGridView TGV_Targeteering
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Targeteering;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			ExpandingEventHandler value2 = method_9;
			CollapsingEventHandler value3 = method_11;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_15);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_17);
			EventHandler eventHandler = method_20;
			DarkTreeGridView darkTreeGridView = _TGV_Targeteering;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
				((DataGridView)darkTreeGridView).CellClick -= val;
				((DataGridView)darkTreeGridView).CellValueChanged -= val2;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged -= eventHandler;
			}
			_TGV_Targeteering = value;
			darkTreeGridView = _TGV_Targeteering;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding += value2;
				darkTreeGridView.NodeCollapsing += value3;
				((DataGridView)darkTreeGridView).CellClick += val;
				((DataGridView)darkTreeGridView).CellValueChanged += val2;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_EditArea
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkButton darkButton = _Button_EditArea;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditArea = value;
			darkButton = _Button_EditArea;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button_AddArea")]
	internal virtual DarkButton Button_AddArea { get; set; }

	internal virtual DarkButton Button_EditPreliminaryTargetLocation
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditPreliminaryTargetLocation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkButton darkButton = _Button_EditPreliminaryTargetLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditPreliminaryTargetLocation = value;
			darkButton = _Button_EditPreliminaryTargetLocation;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button_AddPreliminaryTargetLocation")]
	internal virtual DarkButton Button_AddPreliminaryTargetLocation { get; set; }

	internal virtual DarkButton Button_EditCoordinate
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditCoordinate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkButton darkButton = _Button_EditCoordinate;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditCoordinate = value;
			darkButton = _Button_EditCoordinate;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button_AddCoordinate")]
	internal virtual DarkButton Button_AddCoordinate { get; set; }

	[field: AccessedThroughProperty("Button_DecreasePriority")]
	internal virtual DarkButton Button_DecreasePriority { get; set; }

	[field: AccessedThroughProperty("Button_IncreasePriority")]
	internal virtual DarkButton Button_IncreasePriority { get; set; }

	[field: AccessedThroughProperty("Button_RemoveSelected")]
	internal virtual DarkButton Button_RemoveSelected { get; set; }

	internal virtual DarkButton Button_AddHighlighted
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddHighlighted;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkButton darkButton = _Button_AddHighlighted;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_AddHighlighted = value;
			darkButton = _Button_AddHighlighted;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_EditRoute
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditRoute;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkButton darkButton = _Button_EditRoute;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditRoute = value;
			darkButton = _Button_EditRoute;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_SetTimeReferenceWeapon
	{
		[CompilerGenerated]
		get
		{
			return _Button_SetTimeReferenceWeapon;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkButton darkButton = _Button_SetTimeReferenceWeapon;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SetTimeReferenceWeapon = value;
			darkButton = _Button_SetTimeReferenceWeapon;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_PreplannedOnly")]
	internal virtual DarkCheckBox CB_PreplannedOnly { get; set; }

	[field: AccessedThroughProperty("GroupBox_Targeteering")]
	internal virtual DarkGroupBox GroupBox_Targeteering { get; set; }

	[field: AccessedThroughProperty("GroupBox_Weaponeering")]
	internal virtual DarkGroupBox GroupBox_Weaponeering { get; set; }

	public static string TargeteeringMethodtring
	{
		get
		{
			switch (Target)
			{
			default:
				return "None";
			case Mission._TargeteeringMethod.Mission:
				if (theMissionCategory == Mission.MissionCategory.Package)
				{
					return "Use package targets";
				}
				return "Use mission targets";
			case Mission._TargeteeringMethod.Flight:
				return "Use flight targets";
			case Mission._TargeteeringMethod.Individual:
				return "Use individual targets (per-aircraft basis)";
			}
		}
	}

	public FlightPlanEditorTargets()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanEditorTargets_FormClosing);
		((Control)this).VisibleChanged += FlightPlanEditorTargets_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanEditorTargets_KeyDown);
		SelectedRow = 0;
		list_1 = new List<string>();
		list_2 = new List<string>();
		AircraftList = new List<string>();
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
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Expected O, but got Unknown
		//IL_0ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_102c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_111f: Unknown result type (might be due to invalid IL or missing references)
		//IL_122e: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b5: Expected O, but got Unknown
		//IL_148f: Unknown result type (might be due to invalid IL or missing references)
		//IL_150a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1582: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		TGV_Weaponeering = new DarkTreeGridView();
		WeaponType = new TreeGridColumn();
		Target = new DataGridViewComboBoxColumn();
		LostTarget = new DataGridViewComboBoxColumn();
		WeaponQty = new DataGridViewComboBoxColumn();
		FiringRange = new DataGridViewComboBoxColumn();
		Route = new DataGridViewTextBoxColumn();
		TGV_Targeteering = new DarkTreeGridView();
		ID = new TreeGridColumn();
		TargetName = new DataGridViewTextBoxColumn();
		AssignedWeapons = new DataGridViewTextBoxColumn();
		Time_Zulu = new DataGridViewTextBoxColumn();
		Time_Local = new DataGridViewTextBoxColumn();
		Coordinates = new DataGridViewTextBoxColumn();
		SplitContainer1 = new SplitContainer();
		GroupBox_Targeteering = new DarkGroupBox();
		Button_EditArea = new DarkButton();
		Button_AddArea = new DarkButton();
		Button_EditToT = new DarkButton();
		Button_EditPreliminaryTargetLocation = new DarkButton();
		Button_AddPreliminaryTargetLocation = new DarkButton();
		Button_EditCoordinate = new DarkButton();
		Button_AddCoordinate = new DarkButton();
		Button_DecreasePriority = new DarkButton();
		Button_IncreasePriority = new DarkButton();
		Button_RemoveSelected = new DarkButton();
		CB_PreplannedOnly = new DarkCheckBox();
		Button_AddHighlighted = new DarkButton();
		ComboBox_TargteeringMethod = new DarkUIComboBox();
		Label3 = new Label();
		GroupBox_Weaponeering = new DarkGroupBox();
		Button_SetTimeReferenceWeapon = new DarkButton();
		Button_EditRoute = new DarkButton();
		Button_EditWRA = new DarkButton();
		((ISupportInitialize)(object)TGV_Weaponeering).BeginInit();
		((ISupportInitialize)(object)TGV_Targeteering).BeginInit();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((Control)GroupBox_Targeteering).SuspendLayout();
		((Control)GroupBox_Weaponeering).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)TGV_Weaponeering).AllowUserToAddRows = false;
		((DataGridView)TGV_Weaponeering).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Weaponeering).AllowUserToOrderColumns = true;
		((Control)TGV_Weaponeering).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Weaponeering).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		((DataGridView)TGV_Weaponeering).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)11;
		((DataGridView)TGV_Weaponeering).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_Weaponeering).BorderStyle = (BorderStyle)0;
		((DataGridView)TGV_Weaponeering).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Weaponeering).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Weaponeering).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Weaponeering).ColumnHeadersHeight = 34;
		((DataGridView)TGV_Weaponeering).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)WeaponType,
			(DataGridViewColumn)Target,
			(DataGridViewColumn)LostTarget,
			(DataGridViewColumn)WeaponQty,
			(DataGridViewColumn)FiringRange,
			(DataGridViewColumn)Route
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Weaponeering).DefaultCellStyle = val2;
		((DataGridView)TGV_Weaponeering).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Weaponeering).EnableHeadersVisualStyles = false;
		TGV_Weaponeering.ImageList = null;
		((Control)TGV_Weaponeering).Location = new Point(6, 30);
		((DataGridView)TGV_Weaponeering).MultiSelect = false;
		((Control)TGV_Weaponeering).Name = "TGV_Weaponeering";
		((DataGridView)TGV_Weaponeering).RowHeadersVisible = false;
		((DataGridView)TGV_Weaponeering).RowHeadersWidth = 20;
		((DataGridView)TGV_Weaponeering).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Weaponeering.ShowLines = false;
		((Control)TGV_Weaponeering).Size = new Size(1246, 284);
		((Control)TGV_Weaponeering).TabIndex = 9;
		WeaponType.DefaultNodeImage = null;
		((DataGridViewColumn)WeaponType).HeaderText = "Weapon Type";
		((DataGridViewColumn)WeaponType).MinimumWidth = 8;
		((DataGridViewColumn)WeaponType).Name = "WeaponType";
		((DataGridViewColumn)WeaponType).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)WeaponType).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Target).HeaderText = "Target";
		((DataGridViewColumn)Target).MinimumWidth = 8;
		((DataGridViewColumn)Target).Name = "Target";
		((DataGridViewColumn)LostTarget).HeaderText = "Lost Target";
		((DataGridViewColumn)LostTarget).MinimumWidth = 8;
		((DataGridViewColumn)LostTarget).Name = "LostTarget";
		((DataGridViewColumn)WeaponQty).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)WeaponQty).HeaderText = "Qty";
		((DataGridViewColumn)WeaponQty).MinimumWidth = 8;
		((DataGridViewColumn)WeaponQty).Name = "WeaponQty";
		((DataGridViewColumn)WeaponQty).Width = 30;
		((DataGridViewColumn)FiringRange).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)FiringRange).HeaderText = "Firing Range";
		((DataGridViewColumn)FiringRange).MinimumWidth = 8;
		((DataGridViewColumn)FiringRange).Name = "FiringRange";
		((DataGridViewColumn)FiringRange).Width = 69;
		((DataGridViewColumn)Route).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Route).HeaderText = "Route";
		((DataGridViewColumn)Route).MinimumWidth = 8;
		((DataGridViewColumn)Route).Name = "Route";
		Route.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Route).Width = 42;
		((DataGridView)TGV_Targeteering).AllowUserToAddRows = false;
		((DataGridView)TGV_Targeteering).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Targeteering).AllowUserToOrderColumns = true;
		((Control)TGV_Targeteering).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_Targeteering).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		((DataGridView)TGV_Targeteering).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)11;
		((DataGridView)TGV_Targeteering).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_Targeteering).BorderStyle = (BorderStyle)0;
		((DataGridView)TGV_Targeteering).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Targeteering).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = Color.FromArgb(66, 77, 95);
		val3.Font = new Font("Segoe UI", 9f);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val3.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Targeteering).ColumnHeadersDefaultCellStyle = val3;
		((DataGridView)TGV_Targeteering).ColumnHeadersHeight = 34;
		((DataGridView)TGV_Targeteering).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)TargetName,
			(DataGridViewColumn)AssignedWeapons,
			(DataGridViewColumn)Time_Zulu,
			(DataGridViewColumn)Time_Local,
			(DataGridViewColumn)Coordinates
		});
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(60, 63, 65);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Targeteering).DefaultCellStyle = val4;
		((DataGridView)TGV_Targeteering).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Targeteering).EnableHeadersVisualStyles = false;
		TGV_Targeteering.ImageList = null;
		((Control)TGV_Targeteering).Location = new Point(12, 51);
		((DataGridView)TGV_Targeteering).MultiSelect = false;
		((Control)TGV_Targeteering).Name = "TGV_Targeteering";
		((DataGridView)TGV_Targeteering).RowHeadersVisible = false;
		((DataGridView)TGV_Targeteering).RowHeadersWidth = 20;
		((DataGridView)TGV_Targeteering).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Targeteering.ShowLines = false;
		((Control)TGV_Targeteering).Size = new Size(1240, 262);
		((Control)TGV_Targeteering).TabIndex = 11;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		ID.DefaultNodeImage = null;
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)ID).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ID).Width = 22;
		((DataGridViewColumn)TargetName).HeaderText = "Target Name";
		((DataGridViewColumn)TargetName).MinimumWidth = 8;
		((DataGridViewColumn)TargetName).Name = "TargetName";
		TargetName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)AssignedWeapons).HeaderText = "Assigned Weapons";
		((DataGridViewColumn)AssignedWeapons).MinimumWidth = 8;
		((DataGridViewColumn)AssignedWeapons).Name = "AssignedWeapons";
		AssignedWeapons.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Time_Zulu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Zulu).HeaderText = "Zulu Time";
		((DataGridViewColumn)Time_Zulu).MinimumWidth = 8;
		((DataGridViewColumn)Time_Zulu).Name = "Time_Zulu";
		Time_Zulu.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Time_Zulu).Width = 58;
		((DataGridViewColumn)Time_Local).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Local).HeaderText = "Local Time";
		((DataGridViewColumn)Time_Local).MinimumWidth = 8;
		((DataGridViewColumn)Time_Local).Name = "Time_Local";
		Time_Local.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Time_Local).Width = 61;
		((DataGridViewColumn)Coordinates).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Coordinates).HeaderText = "Coordinates";
		((DataGridViewColumn)Coordinates).MinimumWidth = 8;
		((DataGridViewColumn)Coordinates).Name = "Coordinates";
		Coordinates.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Coordinates).Width = 75;
		SplitContainer1.Dock = (DockStyle)5;
		((Control)SplitContainer1).Location = new Point(0, 0);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)GroupBox_Targeteering);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)GroupBox_Weaponeering);
		((Control)SplitContainer1).Size = new Size(1258, 787);
		SplitContainer1.SplitterDistance = 425;
		((Control)SplitContainer1).TabIndex = 6;
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_EditArea);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_AddArea);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_EditToT);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_EditPreliminaryTargetLocation);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_AddPreliminaryTargetLocation);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_EditCoordinate);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_AddCoordinate);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_DecreasePriority);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_IncreasePriority);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_RemoveSelected);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)CB_PreplannedOnly);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Button_AddHighlighted);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)TGV_Targeteering);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)ComboBox_TargteeringMethod);
		((Control)GroupBox_Targeteering).Controls.Add((Control)(object)Label3);
		((Control)GroupBox_Targeteering).Dock = (DockStyle)5;
		((Control)GroupBox_Targeteering).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_Targeteering).Location = new Point(0, 0);
		((Control)GroupBox_Targeteering).Name = "GroupBox_Targeteering";
		((Control)GroupBox_Targeteering).Size = new Size(1258, 425);
		((Control)GroupBox_Targeteering).TabIndex = 4;
		((GroupBox)GroupBox_Targeteering).TabStop = false;
		((GroupBox)GroupBox_Targeteering).Text = "Targeteering";
		((Control)Button_EditArea).Anchor = (AnchorStyles)6;
		((Control)Button_EditArea).Location = new Point(462, 370);
		((Control)Button_EditArea).Name = "Button_EditArea";
		((Control)Button_EditArea).Padding = new Padding(5);
		((Control)Button_EditArea).Size = new Size(144, 41);
		((Control)Button_EditArea).TabIndex = 51;
		Button_EditArea.Text = "Edit Area Target";
		((Control)Button_AddArea).Anchor = (AnchorStyles)6;
		((Control)Button_AddArea).Location = new Point(462, 319);
		((Control)Button_AddArea).Name = "Button_AddArea";
		((Control)Button_AddArea).Padding = new Padding(5);
		((Control)Button_AddArea).Size = new Size(144, 41);
		((Control)Button_AddArea).TabIndex = 50;
		Button_AddArea.Text = "Add Area Target from map";
		((Control)Button_EditToT).Anchor = (AnchorStyles)6;
		((Control)Button_EditToT).Location = new Point(612, 319);
		((Control)Button_EditToT).Name = "Button_EditToT";
		((Control)Button_EditToT).Padding = new Padding(5);
		((Control)Button_EditToT).Size = new Size(144, 41);
		((Control)Button_EditToT).TabIndex = 49;
		Button_EditToT.Text = "Edit Time on Target (ToT)";
		((Control)Button_EditPreliminaryTargetLocation).Anchor = (AnchorStyles)6;
		((Control)Button_EditPreliminaryTargetLocation).Location = new Point(162, 370);
		((Control)Button_EditPreliminaryTargetLocation).Name = "Button_EditPreliminaryTargetLocation";
		((Control)Button_EditPreliminaryTargetLocation).Padding = new Padding(5);
		((Control)Button_EditPreliminaryTargetLocation).Size = new Size(144, 41);
		((Control)Button_EditPreliminaryTargetLocation).TabIndex = 48;
		Button_EditPreliminaryTargetLocation.Text = "Edit preliminary target location";
		((Control)Button_AddPreliminaryTargetLocation).Anchor = (AnchorStyles)6;
		((Control)Button_AddPreliminaryTargetLocation).Location = new Point(162, 319);
		((Control)Button_AddPreliminaryTargetLocation).Name = "Button_AddPreliminaryTargetLocation";
		((Control)Button_AddPreliminaryTargetLocation).Padding = new Padding(5);
		((Control)Button_AddPreliminaryTargetLocation).Size = new Size(144, 41);
		((Control)Button_AddPreliminaryTargetLocation).TabIndex = 47;
		Button_AddPreliminaryTargetLocation.Text = "Add preliminary target location from map";
		((Control)Button_EditCoordinate).Anchor = (AnchorStyles)6;
		((Control)Button_EditCoordinate).Location = new Point(312, 370);
		((Control)Button_EditCoordinate).Name = "Button_EditCoordinate";
		((Control)Button_EditCoordinate).Padding = new Padding(5);
		((Control)Button_EditCoordinate).Size = new Size(144, 41);
		((Control)Button_EditCoordinate).TabIndex = 46;
		Button_EditCoordinate.Text = "Edit Point Target Coordinate";
		((Control)Button_AddCoordinate).Anchor = (AnchorStyles)6;
		((Control)Button_AddCoordinate).Location = new Point(312, 319);
		((Control)Button_AddCoordinate).Name = "Button_AddCoordinate";
		((Control)Button_AddCoordinate).Padding = new Padding(5);
		((Control)Button_AddCoordinate).Size = new Size(144, 41);
		((Control)Button_AddCoordinate).TabIndex = 45;
		Button_AddCoordinate.Text = "Add Point Target Coordinate from map";
		((Control)Button_DecreasePriority).Anchor = (AnchorStyles)6;
		((Control)Button_DecreasePriority).Location = new Point(1098, 351);
		((Control)Button_DecreasePriority).Name = "Button_DecreasePriority";
		((Control)Button_DecreasePriority).Padding = new Padding(5);
		((Control)Button_DecreasePriority).Size = new Size(154, 24);
		((Control)Button_DecreasePriority).TabIndex = 44;
		Button_DecreasePriority.Text = "Decrease Priority";
		((Control)Button_IncreasePriority).Anchor = (AnchorStyles)6;
		((Control)Button_IncreasePriority).Location = new Point(1098, 321);
		((Control)Button_IncreasePriority).Name = "Button_IncreasePriority";
		((Control)Button_IncreasePriority).Padding = new Padding(5);
		((Control)Button_IncreasePriority).Size = new Size(154, 24);
		((Control)Button_IncreasePriority).TabIndex = 43;
		Button_IncreasePriority.Text = "Increase Priority";
		((Control)Button_RemoveSelected).Anchor = (AnchorStyles)6;
		((Control)Button_RemoveSelected).Location = new Point(12, 370);
		((Control)Button_RemoveSelected).Name = "Button_RemoveSelected";
		((Control)Button_RemoveSelected).Padding = new Padding(5);
		((Control)Button_RemoveSelected).Size = new Size(144, 41);
		((Control)Button_RemoveSelected).TabIndex = 41;
		Button_RemoveSelected.Text = "Remove Selected Target";
		((Control)CB_PreplannedOnly).Anchor = (AnchorStyles)6;
		((Control)CB_PreplannedOnly).Location = new Point(1092, 381);
		((Control)CB_PreplannedOnly).MaximumSize = new Size(200, 200);
		((Control)CB_PreplannedOnly).MinimumSize = new Size(0, 40);
		((Control)CB_PreplannedOnly).Name = "CB_PreplannedOnly";
		((Control)CB_PreplannedOnly).Size = new Size(160, 40);
		((Control)CB_PreplannedOnly).TabIndex = 42;
		((ButtonBase)CB_PreplannedOnly).Text = "Pre-planned targets (in target list) only";
		((Control)Button_AddHighlighted).Anchor = (AnchorStyles)6;
		((Control)Button_AddHighlighted).Location = new Point(12, 319);
		((Control)Button_AddHighlighted).Name = "Button_AddHighlighted";
		((Control)Button_AddHighlighted).Padding = new Padding(5);
		((Control)Button_AddHighlighted).Size = new Size(144, 41);
		((Control)Button_AddHighlighted).TabIndex = 40;
		Button_AddHighlighted.Text = "Add units currently selected on map";
		((ComboBox)ComboBox_TargteeringMethod).BackColor = Color.Transparent;
		((ComboBox)ComboBox_TargteeringMethod).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_TargteeringMethod).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_TargteeringMethod).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_TargteeringMethod).FormattingEnabled = true;
		((Control)ComboBox_TargteeringMethod).Location = new Point(139, 19);
		((Control)ComboBox_TargteeringMethod).Name = "ComboBox_TargteeringMethod";
		((Control)ComboBox_TargteeringMethod).Size = new Size(128, 21);
		((Control)ComboBox_TargteeringMethod).TabIndex = 3;
		Label3.AutoSize = true;
		((Control)Label3).Location = new Point(41, 22);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(47, 15);
		((Control)Label3).TabIndex = 2;
		Label3.Text = "Targets:";
		((Control)GroupBox_Weaponeering).Controls.Add((Control)(object)Button_SetTimeReferenceWeapon);
		((Control)GroupBox_Weaponeering).Controls.Add((Control)(object)Button_EditRoute);
		((Control)GroupBox_Weaponeering).Controls.Add((Control)(object)Button_EditWRA);
		((Control)GroupBox_Weaponeering).Controls.Add((Control)(object)TGV_Weaponeering);
		((Control)GroupBox_Weaponeering).Dock = (DockStyle)5;
		((Control)GroupBox_Weaponeering).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_Weaponeering).Location = new Point(0, 0);
		((Control)GroupBox_Weaponeering).Name = "GroupBox_Weaponeering";
		((Control)GroupBox_Weaponeering).Size = new Size(1258, 358);
		((Control)GroupBox_Weaponeering).TabIndex = 5;
		((GroupBox)GroupBox_Weaponeering).TabStop = false;
		((GroupBox)GroupBox_Weaponeering).Text = "Weaponeering";
		((Control)Button_SetTimeReferenceWeapon).Anchor = (AnchorStyles)6;
		((Control)Button_SetTimeReferenceWeapon).Location = new Point(376, 326);
		((Control)Button_SetTimeReferenceWeapon).Name = "Button_SetTimeReferenceWeapon";
		((Control)Button_SetTimeReferenceWeapon).Padding = new Padding(5);
		((Control)Button_SetTimeReferenceWeapon).Size = new Size(176, 26);
		((Control)Button_SetTimeReferenceWeapon).TabIndex = 12;
		Button_SetTimeReferenceWeapon.Text = "Set Time Reference Weapon";
		((Control)Button_EditRoute).Anchor = (AnchorStyles)6;
		((Control)Button_EditRoute).Location = new Point(194, 326);
		((Control)Button_EditRoute).Name = "Button_EditRoute";
		((Control)Button_EditRoute).Padding = new Padding(5);
		((Control)Button_EditRoute).Size = new Size(176, 26);
		((Control)Button_EditRoute).TabIndex = 11;
		Button_EditRoute.Text = "Edit Cruise Missile Route";
		((Control)Button_EditWRA).Anchor = (AnchorStyles)6;
		((Control)Button_EditWRA).Location = new Point(12, 326);
		((Control)Button_EditWRA).Name = "Button_EditWRA";
		((Control)Button_EditWRA).Padding = new Padding(5);
		((Control)Button_EditWRA).Size = new Size(176, 26);
		((Control)Button_EditWRA).TabIndex = 10;
		Button_EditWRA.Text = "Edit WRA for IP waypoint";
		((Control)this).AllowDrop = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoSizeMode = (AutoSizeMode)0;
		((Form)this).ClientSize = new Size(1258, 787);
		((Control)this).Controls.Add((Control)(object)SplitContainer1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(100, 100);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(1024, 730);
		((Control)this).Name = "FlightPlanEditorTargets";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Select targets for flight <Flight> or its individual aircraft";
		((ISupportInitialize)(object)TGV_Weaponeering).EndInit();
		((ISupportInitialize)(object)TGV_Targeteering).EndInit();
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)GroupBox_Targeteering).ResumeLayout(false);
		((Control)GroupBox_Targeteering).PerformLayout();
		((Control)GroupBox_Weaponeering).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void FlightPlanEditorTargets_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FlightPlanEditorTargets_VisibleChanged(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((Control)this).Visible)
		{
			LoadWindow();
			method_26();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		SelectedAircraft = null;
		((DataGridView)TGV_Targeteering).ClearSelection();
		((DataGridView)TGV_Weaponeering).ClearSelection();
		RefreshStats();
	}

	public void RefreshWindow()
	{
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_2(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing((object)scenarioObject_0))
			{
				RefreshStats();
			}
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

	internal void RefreshStats()
	{
		try
		{
			if (Information.IsNothing((object)SelectedFlight))
			{
				((ComboBox)ComboBox_TargteeringMethod).DataSource = null;
				((ComboBox)ComboBox_TargteeringMethod).Items.Clear();
				((ComboBox)ComboBox_TargteeringMethod).SelectedIndex = -1;
				return;
			}
			DataTable theComboBoxDataSource_TargeteeringTarget = new DataTable();
			ComboBoxDataSource_TargeteeringMethod(ref theComboBoxDataSource_TargeteeringTarget, SelectedMission.Category);
			DarkUIComboBox comboBox_TargteeringMethod = ComboBox_TargteeringMethod;
			((ComboBox)comboBox_TargteeringMethod).DataSource = theComboBoxDataSource_TargeteeringTarget;
			((ListControl)comboBox_TargteeringMethod).DisplayMember = "Description";
			((ListControl)comboBox_TargteeringMethod).ValueMember = "ID";
			((ComboBox)comboBox_TargteeringMethod).DropDownWidth = 500;
			((ComboBox)ComboBox_TargteeringMethod).SelectedIndex = TargeteeringMethod_To_TargeteeringMethodSelection((int)TargetWaypoint_Lead.TargeteeringMethod);
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

	public void SnapToNearestTarget(ref ActiveUnit theUnit, ref Mission theMission, bool IgnoreContacStance, Waypoint theWaypoint)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		_Closure$__161-0 arg = default(_Closure$__161-0);
		_Closure$__161-0 CS$<>8__locals5 = new _Closure$__161-0(arg);
		CS$<>8__locals5.$VB$Local_theWaypoint = theWaypoint;
		try
		{
			if ((int)Control.ModifierKeys == 262144)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
			{
				Doctrine._UseShootTourists? canShootTourists = theMission.Doctrine.get_ShootTourists(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (!Client.CurrentSide.Cache_ContactStancesOnThisPulse.TryGetValue(contacts_.ObjectID, out var value))
				{
					value = contacts_.get_Stance(Client.CurrentSide);
					Client.CurrentSide.Cache_ContactStancesOnThisPulse.AddIfNotExists(contacts_.ObjectID, value);
				}
				switch (value)
				{
				case Misc.PostureStance.Unfriendly:
				case Misc.PostureStance.Hostile:
				{
					ActiveUnit_AI aI2 = theUnit.AI;
					Mission theMission3 = theMission;
					Misc.PostureStance? contactStance2 = value;
					string Feedback = "";
					int FeedbackSeverity = 0;
					if (!aI2.ContactIsRelevantToFlightOrMission(contacts_, theMission3, canShootTourists, IgnoreContacStance, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, contactStance2, ref Feedback, ref FeedbackSeverity))
					{
						break;
					}
					if (contacts_.Type == Contact_Base.ContactType.Submarine)
					{
						if (!contacts_.IsClassifiedFalseTarget && !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null)))
						{
							list.Add(contacts_);
						}
						break;
					}
					Lazy<List<Weapon>> lazy = new Lazy<List<Weapon>>(theUnit.Weaponry.AllDistinctWeaponsAboard_Actual);
					ActiveUnit_Weaponry weaponry = theUnit.Weaponry;
					Doctrine doctrine = theUnit.Doctrine;
					Feedback = null;
					FeedbackSeverity = 0;
					if (weaponry.HaveAvailableWeaponSuitableForThisTarget(contacts_, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, lazy.Value))
					{
						list.Add(contacts_);
					}
					break;
				}
				case Misc.PostureStance.Unknown:
				{
					ActiveUnit_AI aI = theUnit.AI;
					Mission theMission2 = theMission;
					Misc.PostureStance? contactStance = value;
					string Feedback = "";
					int FeedbackSeverity = 0;
					if (aI.ContactIsRelevantToFlightOrMission(contacts_, theMission2, canShootTourists, IgnoreContacStance, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, contactStance, ref Feedback, ref FeedbackSeverity) && (contacts_.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null))))
					{
						list.Add(contacts_);
					}
					break;
				}
				}
			}
			if (list.Count > 0)
			{
				IEnumerable<Contact> source = list.OrderBy([SpecialName] (Contact theC) => Math2.CalcDist_Angular(CS$<>8__locals5.$VB$Local_theWaypoint.Latitude, CS$<>8__locals5.$VB$Local_theWaypoint.Longitude, ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null)));
				CS$<>8__locals5.$VB$Local_theWaypoint.Latitude = ((Module_Unit.Unit)source.ElementAtOrDefault(0)).get_Latitude((GlobalVariables.BooleanObject)null);
				CS$<>8__locals5.$VB$Local_theWaypoint.Longitude = ((Module_Unit.Unit)source.ElementAtOrDefault(0)).get_Longitude((GlobalVariables.BooleanObject)null);
			}
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

	public List<Contact> FindMissionTargets()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		List<Contact> result;
		try
		{
			Strike strike = (Strike)SelectedMission;
			new List<Module_Unit.Unit>();
			List<Contact> list = new List<Contact>();
			if (strike.RTB_When_Target_Destroyed)
			{
				if (!strike.RTB_When_Target_Destroyed || strike.TargetCount != 0)
				{
					foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
					{
						if (specificTarget.get_UnitSide(SetSideOnly: false) != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, specificTarget.get_UnitSide(SetSideOnly: false)) && !specificTarget.IsGroup && !specificTarget.IsActiveUnit)
						{
							Contact contact = (Contact)specificTarget;
							if ((Information.IsNothing((object)contact.ActualUnit) || !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID)) && !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && !list.Contains(contact))
							{
								list.Add(contact);
							}
						}
					}
					result = ((list.Count <= 0) ? null : list);
				}
				else
				{
					result = null;
				}
			}
			else
			{
				Interaction.MsgBox((object)"This mission requires pre-planned targets only!", (MsgBoxStyle)0, (object)null);
				result = null;
			}
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
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Contact FindMissionTargetClosestToWaypoint_MissionTargets(Waypoint theWaypoint)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__163-0 arg = default(_Closure$__163-0);
		_Closure$__163-0 CS$<>8__locals3 = new _Closure$__163-0(arg);
		CS$<>8__locals3.$VB$Local_theWaypoint = theWaypoint;
		Contact result;
		try
		{
			Strike strike = (Strike)SelectedMission;
			new List<Module_Unit.Unit>();
			List<Contact> list = new List<Contact>();
			if (!strike.RTB_When_Target_Destroyed)
			{
				Interaction.MsgBox((object)"This mission requires pre-planned targets only!", (MsgBoxStyle)0, (object)null);
				result = null;
			}
			else if (!strike.RTB_When_Target_Destroyed || strike.TargetCount != 0)
			{
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
					if (specificTarget.get_UnitSide(SetSideOnly: false) != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, specificTarget.get_UnitSide(SetSideOnly: false)) && !specificTarget.IsGroup && !specificTarget.IsActiveUnit)
					{
						Contact contact = (Contact)specificTarget;
						if ((Information.IsNothing((object)contact.ActualUnit) || !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID)) && !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && !list.Contains(contact))
						{
							list.Add(contact);
						}
					}
				}
				result = ((list.Count > 0) ? list.OrderBy([SpecialName] (Contact theC) => Math2.CalcDist_Angular(CS$<>8__locals3.$VB$Local_theWaypoint.Latitude, CS$<>8__locals3.$VB$Local_theWaypoint.Longitude, ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null))).ElementAtOrDefault(0) : null);
			}
			else
			{
				result = null;
			}
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
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void FindMissionTargetClosestToWaypoint_FlightTargets()
	{
	}

	public void FindMissionTargetClosestToWaypoint_IndividualTargets()
	{
	}

	private void method_3(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission._TargeteeringMethod theTargeteeringMethod = TargeteeringMethodSelection_To_TargeteeringMethod(((ComboBox)ComboBox_TargteeringMethod).SelectedIndex);
			Scenario theScen = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			ChangeTargeteeringMethod(ref theScen, ref theSide, ref SelectedMission, theTargeteeringMethod);
			Client.CurrentSide = theSide;
			FindAllAircraft();
			LoadGrid(TargeteeringExpandAllNodes: true, WeaponeeringExpandAllNodes: true);
			method_26();
			Client.MustRefreshMainForm = true;
		}
	}

	public void ChangeTargeteeringMethod(ref Scenario theScen, ref Side theSide, ref Mission theMission, Mission._TargeteeringMethod theTargeteeringMethod)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		try
		{
			if ((int)Interaction.MsgBox((object)"You have selected to change the target selection method. This will wipe the existing configuration. Proceed?", (MsgBoxStyle)4, (object)null) == 7)
			{
				return;
			}
			switch (theTargeteeringMethod)
			{
			case Mission._TargeteeringMethod.Mission:
				if (TargetWaypoint_Lead.TargeteeringMethod != Mission._TargeteeringMethod.Mission)
				{
					TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Mission;
					AircraftList.Clear();
					list_1.Clear();
					list_2.Clear();
					TargetWaypoint_Lead.TargeteeringList = null;
					TargetWaypoint_Lead.WeaponeeringList = null;
					if (SelectedFlight.DesiredAircraftQty > 1)
					{
						TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 2)
					{
						TargetWaypoint_Lead.TargeteeringList_SecondElement = null;
						TargetWaypoint_Lead.WeaponeeringList_SecondElement = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 3)
					{
						TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 4)
					{
						TargetWaypoint_Lead.TargeteeringList_ThirdElement = null;
						TargetWaypoint_Lead.WeaponeeringList_ThirdElement = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 4)
					{
						TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = null;
					}
				}
				break;
			case Mission._TargeteeringMethod.Flight:
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					break;
				}
				TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Flight;
				AircraftList.Clear();
				list_1.Clear();
				list_2.Clear();
				TargetWaypoint_Lead.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
				TargetWaypoint_Lead.WeaponeeringList = null;
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElement = null;
					TargetWaypoint_Lead.WeaponeeringList_SecondElement = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElement = null;
					TargetWaypoint_Lead.WeaponeeringList_ThirdElement = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = null;
				}
				List<Contact> list = FindMissionTargets();
				if (Information.IsNothing((object)list) || list.Count <= 0)
				{
					break;
				}
				{
					foreach (Contact item8 in list)
					{
						if (!Information.IsNothing((object)item8))
						{
							Mission.TargeteeringEntry item7 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, item8.Name, item8.ObjectID, item8.ActualUnit.ObjectID, item8.ActualUnit.DBID, ((Module_Unit.Unit)item8).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item8).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
							if (!TargetWaypoint_Lead.TargeteeringList.Contains(item7))
							{
								TargetWaypoint_Lead.TargeteeringList.Add(item7);
							}
						}
					}
					break;
				}
			}
			case Mission._TargeteeringMethod.Individual:
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					break;
				}
				TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Individual;
				AircraftList.Clear();
				list_1.Clear();
				list_2.Clear();
				TargetWaypoint_Lead.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
				TargetWaypoint_Lead.WeaponeeringList = new ConcurrentBag<Mission.WeaponeeringEntry>();
				Contact theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead);
				ActiveUnit theAU;
				Mission.Flight selectedFlight;
				Scenario theScen2;
				if (!Information.IsNothing((object)theNewTarget))
				{
					Mission.TargeteeringEntry item = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
					if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList))
					{
						TargetWaypoint_Lead.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
					}
					if (!TargetWaypoint_Lead.TargeteeringList.Contains(item))
					{
						TargetWaypoint_Lead.TargeteeringList.Add(item);
					}
					theScen2 = Client.CurrentScenario;
					Side theSide2 = Client.CurrentSide;
					ref Mission selectedMission = ref SelectedMission;
					ref Waypoint theAircraftNextWaypoint = ref SelectedFlight.FlightPlan[0];
					theAU = null;
					ActiveUnit theDestroyedUnit = null;
					Scenario currentScenario;
					ActiveUnit theFlightReferenceUnit = (selectedFlight = SelectedFlight).get_ReferenceUnit(currentScenario = Client.CurrentScenario);
					MissionPlanner.UpdateMissionWaypoints_TargetAndIP_GroupLead(0f, ref theScen2, ref theSide2, ref selectedMission, ref theAircraftNextWaypoint, ref theAU, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theFlightReferenceUnit, ref SelectedFlight, ref IPWaypoint_Lead, ref TargetWaypoint_Lead, RunValidation: true);
					selectedFlight.set_ReferenceUnit(currentScenario, theFlightReferenceUnit);
					Client.CurrentSide = theSide2;
				}
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_LeadElementWingman))
					{
						theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_LeadElementWingman);
					}
					if (!Information.IsNothing((object)theNewTarget))
					{
						Mission.TargeteeringEntry item2 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_LeadElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Contains(item2))
						{
							TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Add(item2);
						}
						if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_LeadElementWingman))
						{
							Scenario currentScenario = Client.CurrentScenario;
							Side theSide2 = Client.CurrentSide;
							ref Mission selectedMission2 = ref SelectedMission;
							ref Waypoint theAircraftNextWaypoint2 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit theFlightReferenceUnit = null;
							ActiveUnit theDestroyedUnit = null;
							theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
							MissionPlanner.UpdateMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref currentScenario, ref theSide2, ref selectedMission2, ref theAircraftNextWaypoint2, ref theFlightReferenceUnit, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theAU, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_LeadElementWingman, ref TargetWaypoint_Lead.Waypoint_LeadElementWingman, Mission.Flight.FlightElement.LeadElementWingman, RunValidation: true);
							selectedFlight.set_ReferenceUnit(theScen2, theAU);
							Client.CurrentSide = theSide2;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElement = new WriteLockedList<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_SecondElement = new ConcurrentBag<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElement))
					{
						theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_SecondElement);
					}
					if (!Information.IsNothing((object)theNewTarget))
					{
						Mission.TargeteeringEntry item3 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_SecondElement))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElement = new WriteLockedList<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_SecondElement.Contains(item3))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElement.Add(item3);
						}
						if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElement))
						{
							theScen2 = Client.CurrentScenario;
							Side theSide2 = Client.CurrentSide;
							ref Mission selectedMission3 = ref SelectedMission;
							ref Waypoint theAircraftNextWaypoint3 = ref SelectedFlight.FlightPlan[0];
							theAU = null;
							ActiveUnit theDestroyedUnit = null;
							Scenario currentScenario;
							ActiveUnit theFlightReferenceUnit = (selectedFlight = SelectedFlight).get_ReferenceUnit(currentScenario = Client.CurrentScenario);
							MissionPlanner.UpdateMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref theScen2, ref theSide2, ref selectedMission3, ref theAircraftNextWaypoint3, ref theAU, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theFlightReferenceUnit, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_SecondElement, ref TargetWaypoint_Lead.Waypoint_SecondElement, Mission.Flight.FlightElement.SecondElement, RunValidation: true);
							selectedFlight.set_ReferenceUnit(currentScenario, theFlightReferenceUnit);
							Client.CurrentSide = theSide2;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElementWingman))
					{
						theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_SecondElementWingman);
					}
					if (!Information.IsNothing((object)theNewTarget))
					{
						Mission.TargeteeringEntry item4 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_SecondElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Contains(item4))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Add(item4);
						}
						if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElementWingman))
						{
							Scenario currentScenario = Client.CurrentScenario;
							Side theSide2 = Client.CurrentSide;
							ref Mission selectedMission4 = ref SelectedMission;
							ref Waypoint theAircraftNextWaypoint4 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit theFlightReferenceUnit = null;
							ActiveUnit theDestroyedUnit = null;
							theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
							MissionPlanner.UpdateMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref currentScenario, ref theSide2, ref selectedMission4, ref theAircraftNextWaypoint4, ref theFlightReferenceUnit, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theAU, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_SecondElementWingman, ref TargetWaypoint_Lead.Waypoint_SecondElementWingman, Mission.Flight.FlightElement.SecondElementWingman, RunValidation: true);
							selectedFlight.set_ReferenceUnit(theScen2, theAU);
							Client.CurrentSide = theSide2;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElement = new WriteLockedList<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_ThirdElement = new ConcurrentBag<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElement))
					{
						theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_ThirdElement);
					}
					if (!Information.IsNothing((object)theNewTarget))
					{
						Mission.TargeteeringEntry item5 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_ThirdElement))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElement = new WriteLockedList<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_ThirdElement.Contains(item5))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElement.Add(item5);
						}
						if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElement))
						{
							theScen2 = Client.CurrentScenario;
							Side theSide2 = Client.CurrentSide;
							ref Mission selectedMission5 = ref SelectedMission;
							ref Waypoint theAircraftNextWaypoint5 = ref SelectedFlight.FlightPlan[0];
							theAU = null;
							ActiveUnit theDestroyedUnit = null;
							Scenario currentScenario;
							ActiveUnit theFlightReferenceUnit = (selectedFlight = SelectedFlight).get_ReferenceUnit(currentScenario = Client.CurrentScenario);
							MissionPlanner.UpdateMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref theScen2, ref theSide2, ref selectedMission5, ref theAircraftNextWaypoint5, ref theAU, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theFlightReferenceUnit, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_ThirdElement, ref TargetWaypoint_Lead.Waypoint_ThirdElement, Mission.Flight.FlightElement.ThirdElement, RunValidation: true);
							selectedFlight.set_ReferenceUnit(currentScenario, theFlightReferenceUnit);
							Client.CurrentSide = theSide2;
						}
					}
					TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = new ConcurrentBag<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
					{
						theNewTarget = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_ThirdElementWingman);
					}
					if (!Information.IsNothing((object)theNewTarget))
					{
						Mission.TargeteeringEntry item6 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, theNewTarget.Name, theNewTarget.ObjectID, theNewTarget.ActualUnit.ObjectID, theNewTarget.ActualUnit.DBID, ((Module_Unit.Unit)theNewTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theNewTarget).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						if (Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = new WriteLockedList<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Contains(item6))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Add(item6);
						}
						if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
						{
							Scenario currentScenario = Client.CurrentScenario;
							Side theSide2 = Client.CurrentSide;
							ref Mission selectedMission6 = ref SelectedMission;
							ref Waypoint theAircraftNextWaypoint6 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit theFlightReferenceUnit = null;
							ActiveUnit theDestroyedUnit = null;
							theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
							MissionPlanner.UpdateMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref currentScenario, ref theSide2, ref selectedMission6, ref theAircraftNextWaypoint6, ref theFlightReferenceUnit, ref theNewTarget, ref theDestroyedUnit, IsAirborne: false, ref theAU, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_ThirdElementWingman, ref TargetWaypoint_Lead.Waypoint_ThirdElementWingman, Mission.Flight.FlightElement.ThirdElementWingman, RunValidation: true);
							selectedFlight.set_ReferenceUnit(theScen2, theAU);
							Client.CurrentSide = theSide2;
						}
					}
				}
				method_4();
				theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
				ref Waypoint targetWaypoint_Lead = ref TargetWaypoint_Lead;
				ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList = ref TargetWaypoint_Lead.WeaponeeringList;
				TList<Mission.TargeteeringEntry> tlist_ = TargetWaypoint_Lead.TargeteeringList;
				bool bool_ = false;
				method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead, ref weaponeeringList, tlist_, ref bool_, bool_5: false, ref SelectedFlight, "a/c #1");
				selectedFlight.set_ReferenceUnit(theScen2, theAU);
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					if (Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_LeadElementWingman))
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead2 = ref TargetWaypoint_Lead;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_LeadElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman;
						TList<Mission.TargeteeringEntry> tlist_2 = TargetWaypoint_Lead.TargeteeringList_LeadElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead2, ref weaponeeringList_LeadElementWingman, tlist_2, ref bool_, bool_5: false, ref SelectedFlight, "a/c #2");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					else
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint waypoint_LeadElementWingman = ref TargetWaypoint_Lead.Waypoint_LeadElementWingman;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_LeadElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman;
						TList<Mission.TargeteeringEntry> tlist_3 = TargetWaypoint_Lead.TargeteeringList_LeadElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref waypoint_LeadElementWingman, ref weaponeeringList_LeadElementWingman2, tlist_3, ref bool_, bool_5: false, ref SelectedFlight, "a/c #2");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElement))
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint waypoint_SecondElement = ref TargetWaypoint_Lead.Waypoint_SecondElement;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_SecondElement = ref TargetWaypoint_Lead.WeaponeeringList_SecondElement;
						TList<Mission.TargeteeringEntry> tlist_4 = TargetWaypoint_Lead.TargeteeringList_SecondElement;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref waypoint_SecondElement, ref weaponeeringList_SecondElement, tlist_4, ref bool_, bool_5: false, ref SelectedFlight, "a/c #3");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					else
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead3 = ref TargetWaypoint_Lead;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_SecondElement2 = ref TargetWaypoint_Lead.WeaponeeringList_SecondElement;
						TList<Mission.TargeteeringEntry> tlist_5 = TargetWaypoint_Lead.TargeteeringList_SecondElement;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead3, ref weaponeeringList_SecondElement2, tlist_5, ref bool_, bool_5: false, ref SelectedFlight, "a/c #3");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElementWingman))
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint waypoint_SecondElementWingman = ref TargetWaypoint_Lead.Waypoint_SecondElementWingman;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_SecondElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman;
						TList<Mission.TargeteeringEntry> tlist_6 = TargetWaypoint_Lead.TargeteeringList_SecondElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref waypoint_SecondElementWingman, ref weaponeeringList_SecondElementWingman, tlist_6, ref bool_, bool_5: false, ref SelectedFlight, "a/c #4");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					else
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead4 = ref TargetWaypoint_Lead;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_SecondElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman;
						TList<Mission.TargeteeringEntry> tlist_7 = TargetWaypoint_Lead.TargeteeringList_SecondElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead4, ref weaponeeringList_SecondElementWingman2, tlist_7, ref bool_, bool_5: false, ref SelectedFlight, "a/c #4");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElement))
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint waypoint_ThirdElement = ref TargetWaypoint_Lead.Waypoint_ThirdElement;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_ThirdElement = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement;
						TList<Mission.TargeteeringEntry> tlist_8 = TargetWaypoint_Lead.TargeteeringList_ThirdElement;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref waypoint_ThirdElement, ref weaponeeringList_ThirdElement, tlist_8, ref bool_, bool_5: false, ref SelectedFlight, "a/c #5");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					else
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead5 = ref TargetWaypoint_Lead;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_ThirdElement2 = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement;
						TList<Mission.TargeteeringEntry> tlist_9 = TargetWaypoint_Lead.TargeteeringList_ThirdElement;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead5, ref weaponeeringList_ThirdElement2, tlist_9, ref bool_, bool_5: false, ref SelectedFlight, "a/c #5");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					if (!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint waypoint_ThirdElementWingman = ref TargetWaypoint_Lead.Waypoint_ThirdElementWingman;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_ThirdElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman;
						TList<Mission.TargeteeringEntry> tlist_10 = TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref waypoint_ThirdElementWingman, ref weaponeeringList_ThirdElementWingman, tlist_10, ref bool_, bool_5: false, ref SelectedFlight, "a/c #6");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
					else
					{
						theAU = (selectedFlight = SelectedFlight).get_ReferenceUnit(theScen2 = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead6 = ref TargetWaypoint_Lead;
						ref ConcurrentBag<Mission.WeaponeeringEntry> weaponeeringList_ThirdElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman;
						TList<Mission.TargeteeringEntry> tlist_11 = TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman;
						bool_ = false;
						method_5(ref theScen, ref theSide, ref theAU, ref targetWaypoint_Lead6, ref weaponeeringList_ThirdElementWingman2, tlist_11, ref bool_, bool_5: false, ref SelectedFlight, "a/c #6");
						selectedFlight.set_ReferenceUnit(theScen2, theAU);
					}
				}
				break;
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

	private void method_4()
	{
		try
		{
			if (Information.IsNothing((object)SelectedFlight.get_ReferenceUnit(Client.CurrentScenario)) || !SelectedFlight.get_ReferenceUnit(Client.CurrentScenario).IsAircraft)
			{
				return;
			}
			Aircraft theUnit = (Aircraft)SelectedFlight.get_ReferenceUnit(Client.CurrentScenario);
			if (Information.IsNothing((object)list_0))
			{
				list_0 = new List<WeaponRec>();
			}
			else
			{
				list_0.Clear();
			}
			Weaponeering_RetreiveLoadoutWeapons(theUnit);
			Weaponeering_RetreiveMagazineWeapons(theUnit);
			Weaponeering_RetreiveMountWeapons(theUnit);
			if (list_0.Count <= 0)
			{
				return;
			}
			foreach (WeaponRec item2 in list_0)
			{
				int defaultLoad = item2.DefaultLoad;
				if (defaultLoad <= 0)
				{
					continue;
				}
				Weapon weapon = item2.get_ReferenceWeapon(Client.CurrentScenario);
				string text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList) || TargetWaypoint_Lead.TargeteeringList.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList[0].ObjectID);
				if (!Information.IsNothing((object)text))
				{
					if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
					{
						int int_ = item2.int_3;
						Weapon._WeaponType type = weapon.Type;
						string name = weapon.Name;
						float maxRange_NoTargetType = weapon.MaxRange_NoTargetType;
						float minRange_NoTargetType = weapon.MinRange_NoTargetType;
						bool bearingOnlyLaunch = weapon.Flags.BearingOnlyLaunch;
						string theTargeteeringEntryObjectID = text;
						int defaultLoad2 = item2.DefaultLoad;
						Waypoint[] theRoute = null;
						Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_, type, name, maxRange_NoTargetType, minRange_NoTargetType, bearingOnlyLaunch, theTargeteeringEntryObjectID, 0, -98, defaultLoad2, 0, ref theRoute);
						TargetWaypoint_Lead.WeaponeeringList.Add(item);
					}
					else
					{
						int num = defaultLoad;
						for (int i = 1; i <= num; i++)
						{
							int int_2 = item2.int_3;
							Weapon._WeaponType type2 = weapon.Type;
							string name2 = weapon.Name;
							float maxRange_NoTargetType2 = weapon.MaxRange_NoTargetType;
							float minRange_NoTargetType2 = weapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch2 = weapon.Flags.BearingOnlyLaunch;
							string theTargeteeringEntryObjectID2 = text;
							Waypoint[] theRoute = null;
							Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_2, type2, name2, maxRange_NoTargetType2, minRange_NoTargetType2, bearingOnlyLaunch2, theTargeteeringEntryObjectID2, 0, 0, 0, 0, ref theRoute);
							TargetWaypoint_Lead.WeaponeeringList.Add(item);
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_LeadElementWingman) || TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_LeadElementWingman[0].ObjectID);
					if (!Information.IsNothing((object)text))
					{
						if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_3 = item2.int_3;
							Weapon._WeaponType type3 = weapon.Type;
							string name3 = weapon.Name;
							float maxRange_NoTargetType3 = weapon.MaxRange_NoTargetType;
							float minRange_NoTargetType3 = weapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch3 = weapon.Flags.BearingOnlyLaunch;
							string theTargeteeringEntryObjectID3 = text;
							int defaultLoad3 = item2.DefaultLoad;
							Waypoint[] theRoute = null;
							Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_3, type3, name3, maxRange_NoTargetType3, minRange_NoTargetType3, bearingOnlyLaunch3, theTargeteeringEntryObjectID3, 0, -98, defaultLoad3, 0, ref theRoute);
							TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman.Add(item);
						}
						else
						{
							int num2 = defaultLoad;
							for (int j = 1; j <= num2; j++)
							{
								int int_4 = item2.int_3;
								Weapon._WeaponType type4 = weapon.Type;
								string name4 = weapon.Name;
								float maxRange_NoTargetType4 = weapon.MaxRange_NoTargetType;
								float minRange_NoTargetType4 = weapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch4 = weapon.Flags.BearingOnlyLaunch;
								string theTargeteeringEntryObjectID4 = text;
								Waypoint[] theRoute = null;
								Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_4, type4, name4, maxRange_NoTargetType4, minRange_NoTargetType4, bearingOnlyLaunch4, theTargeteeringEntryObjectID4, 0, 0, 0, 0, ref theRoute);
								TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman.Add(item);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_SecondElement) || TargetWaypoint_Lead.TargeteeringList_SecondElement.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_SecondElement[0].ObjectID);
					if (!Information.IsNothing((object)text))
					{
						if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_5 = item2.int_3;
							Weapon._WeaponType type5 = weapon.Type;
							string name5 = weapon.Name;
							float maxRange_NoTargetType5 = weapon.MaxRange_NoTargetType;
							float minRange_NoTargetType5 = weapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch5 = weapon.Flags.BearingOnlyLaunch;
							string theTargeteeringEntryObjectID5 = text;
							int defaultLoad4 = item2.DefaultLoad;
							Waypoint[] theRoute = null;
							Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_5, type5, name5, maxRange_NoTargetType5, minRange_NoTargetType5, bearingOnlyLaunch5, theTargeteeringEntryObjectID5, 0, -98, defaultLoad4, 0, ref theRoute);
							TargetWaypoint_Lead.WeaponeeringList_SecondElement.Add(item);
						}
						else
						{
							int num3 = defaultLoad;
							for (int k = 1; k <= num3; k++)
							{
								int int_6 = item2.int_3;
								Weapon._WeaponType type6 = weapon.Type;
								string name6 = weapon.Name;
								float maxRange_NoTargetType6 = weapon.MaxRange_NoTargetType;
								float minRange_NoTargetType6 = weapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch6 = weapon.Flags.BearingOnlyLaunch;
								string theTargeteeringEntryObjectID6 = text;
								Waypoint[] theRoute = null;
								Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_6, type6, name6, maxRange_NoTargetType6, minRange_NoTargetType6, bearingOnlyLaunch6, theTargeteeringEntryObjectID6, 0, 0, 0, 0, ref theRoute);
								TargetWaypoint_Lead.WeaponeeringList_SecondElement.Add(item);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_SecondElementWingman) || TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_SecondElementWingman[0].ObjectID);
					if (!Information.IsNothing((object)text))
					{
						if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_7 = item2.int_3;
							Weapon._WeaponType type7 = weapon.Type;
							string name7 = weapon.Name;
							float maxRange_NoTargetType7 = weapon.MaxRange_NoTargetType;
							float minRange_NoTargetType7 = weapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch7 = weapon.Flags.BearingOnlyLaunch;
							string theTargeteeringEntryObjectID7 = text;
							int defaultLoad5 = item2.DefaultLoad;
							Waypoint[] theRoute = null;
							Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_7, type7, name7, maxRange_NoTargetType7, minRange_NoTargetType7, bearingOnlyLaunch7, theTargeteeringEntryObjectID7, 0, -98, defaultLoad5, 0, ref theRoute);
							TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman.Add(item);
						}
						else
						{
							int num4 = defaultLoad;
							for (int l = 1; l <= num4; l++)
							{
								int int_8 = item2.int_3;
								Weapon._WeaponType type8 = weapon.Type;
								string name8 = weapon.Name;
								float maxRange_NoTargetType8 = weapon.MaxRange_NoTargetType;
								float minRange_NoTargetType8 = weapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch8 = weapon.Flags.BearingOnlyLaunch;
								string theTargeteeringEntryObjectID8 = text;
								Waypoint[] theRoute = null;
								Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_8, type8, name8, maxRange_NoTargetType8, minRange_NoTargetType8, bearingOnlyLaunch8, theTargeteeringEntryObjectID8, 0, 0, 0, 0, ref theRoute);
								TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman.Add(item);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_ThirdElement) || TargetWaypoint_Lead.TargeteeringList_ThirdElement.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_ThirdElement[0].ObjectID);
					if (!Information.IsNothing((object)text))
					{
						if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_9 = item2.int_3;
							Weapon._WeaponType type9 = weapon.Type;
							string name9 = weapon.Name;
							float maxRange_NoTargetType9 = weapon.MaxRange_NoTargetType;
							float minRange_NoTargetType9 = weapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch9 = weapon.Flags.BearingOnlyLaunch;
							string theTargeteeringEntryObjectID9 = text;
							int defaultLoad6 = item2.DefaultLoad;
							Waypoint[] theRoute = null;
							Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_9, type9, name9, maxRange_NoTargetType9, minRange_NoTargetType9, bearingOnlyLaunch9, theTargeteeringEntryObjectID9, 0, -98, defaultLoad6, 0, ref theRoute);
							TargetWaypoint_Lead.WeaponeeringList_ThirdElement.Add(item);
						}
						else
						{
							int num5 = defaultLoad;
							for (int m = 1; m <= num5; m++)
							{
								int int_10 = item2.int_3;
								Weapon._WeaponType type10 = weapon.Type;
								string name10 = weapon.Name;
								float maxRange_NoTargetType10 = weapon.MaxRange_NoTargetType;
								float minRange_NoTargetType10 = weapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch10 = weapon.Flags.BearingOnlyLaunch;
								string theTargeteeringEntryObjectID10 = text;
								Waypoint[] theRoute = null;
								Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_10, type10, name10, maxRange_NoTargetType10, minRange_NoTargetType10, bearingOnlyLaunch10, theTargeteeringEntryObjectID10, 0, 0, 0, 0, ref theRoute);
								TargetWaypoint_Lead.WeaponeeringList_ThirdElement.Add(item);
							}
						}
					}
				}
				if (!(SelectedFlight.DesiredAircraftQty > 4))
				{
					continue;
				}
				text = ((Information.IsNothing((object)TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman) || TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman[0].ObjectID);
				if (Information.IsNothing((object)text))
				{
					continue;
				}
				if (weapon.Type != Weapon._WeaponType.GuidedWeapon && weapon.Type != Weapon._WeaponType.GuidedProjectile)
				{
					int int_11 = item2.int_3;
					Weapon._WeaponType type11 = weapon.Type;
					string name11 = weapon.Name;
					float maxRange_NoTargetType11 = weapon.MaxRange_NoTargetType;
					float minRange_NoTargetType11 = weapon.MinRange_NoTargetType;
					bool bearingOnlyLaunch11 = weapon.Flags.BearingOnlyLaunch;
					string theTargeteeringEntryObjectID11 = text;
					int defaultLoad7 = item2.DefaultLoad;
					Waypoint[] theRoute = null;
					Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_11, type11, name11, maxRange_NoTargetType11, minRange_NoTargetType11, bearingOnlyLaunch11, theTargeteeringEntryObjectID11, 0, -98, defaultLoad7, 0, ref theRoute);
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman.Add(item);
					continue;
				}
				int num6 = defaultLoad;
				for (int n = 1; n <= num6; n++)
				{
					int int_12 = item2.int_3;
					Weapon._WeaponType type12 = weapon.Type;
					string name12 = weapon.Name;
					float maxRange_NoTargetType12 = weapon.MaxRange_NoTargetType;
					float minRange_NoTargetType12 = weapon.MinRange_NoTargetType;
					bool bearingOnlyLaunch12 = weapon.Flags.BearingOnlyLaunch;
					string theTargeteeringEntryObjectID12 = text;
					Waypoint[] theRoute = null;
					Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_12, type12, name12, maxRange_NoTargetType12, minRange_NoTargetType12, bearingOnlyLaunch12, theTargeteeringEntryObjectID12, 0, 0, 0, 0, ref theRoute);
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman.Add(item);
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

	private void method_5(ref Scenario scenario_0, ref Side side_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref ConcurrentBag<Mission.WeaponeeringEntry> concurrentBag_0, TList<Mission.TargeteeringEntry> tlist_0, ref bool bool_4, bool bool_5, ref Mission.Flight flight_0, string string_1)
	{
		try
		{
			if (TargetWaypoint_Lead.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
			{
				return;
			}
			bool flag = false;
			if (Information.IsNothing((object)waypoint_0) || waypoint_0.FlightplanPointsList.Count <= 0)
			{
				return;
			}
			int count = waypoint_0.FlightplanPointsList.Count;
			double theLaunchLat;
			double theLaunchLon;
			if (waypoint_0.Type == Waypoint.WaypointType.Target)
			{
				theLaunchLat = waypoint_0.FlightplanPointsList[count - 1].StartLatitude;
				theLaunchLon = waypoint_0.FlightplanPointsList[count - 1].StartLongitude;
			}
			else
			{
				if (waypoint_0.Type != Waypoint.WaypointType.WeaponTarget)
				{
					return;
				}
				theLaunchLat = waypoint_0.FlightplanPointsList[count - 1].EndLatitude;
				theLaunchLon = waypoint_0.FlightplanPointsList[count - 1].EndLongitude;
			}
			Mission.TargeteeringEntry theTargeteeringEntry = default(Mission.TargeteeringEntry);
			foreach (Mission.WeaponeeringEntry item in concurrentBag_0)
			{
				Mission.WeaponeeringEntry theWeaponeeringEntry = item;
				if (!flag)
				{
					theWeaponeeringEntry.IsRouteReference = true;
					flag = true;
				}
				else
				{
					theWeaponeeringEntry.IsRouteReference = false;
				}
				foreach (Mission.TargeteeringEntry item2 in tlist_0)
				{
					if (Operators.CompareString(theWeaponeeringEntry.TargeteeringEntryObjectID, item2.ObjectID, true) == 0)
					{
						theTargeteeringEntry = item2;
						break;
					}
				}
				Weapon theWeapon = Weapon.GetNewWeapon(ref scenario_0, theWeaponeeringEntry.int_0, bool_5: false);
				Contact value = null;
				if (side_0.Contacts.ContainsKey(theTargeteeringEntry.Target_ActualUnitObjectID))
				{
					side_0.Contacts.TryGetValue(theTargeteeringEntry.Target_ActualUnitObjectID, out value);
				}
				double num = ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null);
				double num2 = ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null);
				float theTargetAltitude = ((!value.AltitudeIsKnown) ? ((float)Terrain.GetElevation(num, num2, RequestIsFromGUI: false, scenario_0)) : ((Module_Unit.Unit)value).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				float theLaunchAltitude = 10000f;
				MissionPlanner.CreateWeaponRoute(ref scenario_0, ref activeUnit_0, ref theTargeteeringEntry, ref theWeaponeeringEntry, ref waypoint_0, ref IPWaypoint_Lead, ref theWeaponeeringEntry.Route, ref theWeapon, ref theTargeteeringEntry.Target_Type, ref value, theLaunchLat, theLaunchLon, theLaunchAltitude, num, num2, theTargetAltitude, ref bool_4, bool_5, ref flight_0, string_1);
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
	}

	internal void LoadGrid(bool TargeteeringExpandAllNodes, bool WeaponeeringExpandAllNodes)
	{
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected O, but got Unknown
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Expected O, but got Unknown
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b2: Expected O, but got Unknown
		//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Expected O, but got Unknown
		try
		{
			if (Client.CurrentSide != null || Client.CurrentSide.Units.Count == 0)
			{
				return;
			}
			method_13();
			int num = 0;
			int num2 = 0;
			int firstDisplayedScrollingRowIndex = ((DataGridView)TGV_Targeteering).FirstDisplayedScrollingRowIndex;
			if (((BaseCollection)((DataGridView)TGV_Targeteering).SelectedCells).Count > 0)
			{
				num = ((DataGridView)TGV_Targeteering).SelectedCells[0].RowIndex;
				num2 = ((DataGridView)TGV_Targeteering).SelectedCells[0].ColumnIndex;
			}
			TGV_Targeteering.Nodes.Clear();
			int num3 = 0;
			int num4 = 0;
			int firstDisplayedScrollingRowIndex2 = ((DataGridView)TGV_Weaponeering).FirstDisplayedScrollingRowIndex;
			if (((BaseCollection)((DataGridView)TGV_Weaponeering).SelectedCells).Count > 0)
			{
				num3 = ((DataGridView)TGV_Weaponeering).SelectedCells[0].RowIndex;
				num4 = ((DataGridView)TGV_Weaponeering).SelectedCells[0].ColumnIndex;
			}
			TGV_Weaponeering.Nodes.Clear();
			string string_ = "Name not found!";
			switch (TargetWaypoint_Lead.TargeteeringMethod)
			{
			case Mission._TargeteeringMethod.Mission:
				string_ = "Mission";
				break;
			case Mission._TargeteeringMethod.Flight:
				string_ = "Flight";
				break;
			case Mission._TargeteeringMethod.Individual:
				string_ = "Aircraft #1";
				break;
			}
			method_7(string_, ref TargetWaypoint_Lead.TargeteeringList, ref TargetWaypoint_Lead);
			method_8(string_, ref TargetWaypoint_Lead.TargeteeringList, ref TargetWaypoint_Lead.WeaponeeringList, ref TargetWaypoint_Lead);
			if (AircraftList.Contains("Aircraft #2"))
			{
				Waypoint waypoint_ = ((!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_LeadElementWingman)) ? TargetWaypoint_Lead.Waypoint_LeadElementWingman : TargetWaypoint_Lead);
				string_ = "Aircraft #2";
				method_7(string_, ref TargetWaypoint_Lead.TargeteeringList_LeadElementWingman, ref waypoint_);
				method_8(string_, ref TargetWaypoint_Lead.TargeteeringList_LeadElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman, ref waypoint_);
			}
			if (AircraftList.Contains("Aircraft #3"))
			{
				Waypoint waypoint_ = ((!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElement)) ? TargetWaypoint_Lead.Waypoint_SecondElement : TargetWaypoint_Lead);
				string_ = "Aircraft #3";
				method_7(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElement, ref waypoint_);
				method_8(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElement, ref TargetWaypoint_Lead.WeaponeeringList_SecondElement, ref waypoint_);
			}
			if (AircraftList.Contains("Aircraft #4"))
			{
				Waypoint waypoint_ = (Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_SecondElementWingman) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_SecondElementWingman);
				string_ = "Aircraft #4";
				method_7(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElementWingman, ref waypoint_);
				method_8(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman, ref waypoint_);
			}
			if (AircraftList.Contains("Aircraft #5"))
			{
				Waypoint waypoint_ = (Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElement) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_ThirdElement);
				string_ = "Aircraft #5";
				method_7(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElement, ref waypoint_);
				method_8(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElement, ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement, ref waypoint_);
			}
			if (AircraftList.Contains("Aircraft #6"))
			{
				Waypoint waypoint_ = ((!Information.IsNothing((object)TargetWaypoint_Lead.Waypoint_ThirdElementWingman)) ? TargetWaypoint_Lead.Waypoint_ThirdElementWingman : TargetWaypoint_Lead);
				string_ = "Aircraft #6";
				method_7(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman, ref waypoint_);
				method_8(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman, ref waypoint_);
			}
			if (TargeteeringExpandAllNodes)
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					if (!list_1.Contains("Aircraft #1"))
					{
						list_1.Add("Aircraft #1");
					}
					if (!list_1.Contains("Aircraft #2"))
					{
						list_1.Add("Aircraft #2");
					}
					if (!list_1.Contains("Aircraft #3"))
					{
						list_1.Add("Aircraft #3");
					}
					if (!list_1.Contains("Aircraft #4"))
					{
						list_1.Add("Aircraft #4");
					}
					if (!list_1.Contains("Aircraft #5"))
					{
						list_1.Add("Aircraft #5");
					}
					if (!list_1.Contains("Aircraft #6"))
					{
						list_1.Add("Aircraft #6");
					}
				}
				else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					if (!list_1.Contains("Flight"))
					{
						list_1.Add("Flight");
					}
				}
				else if (!list_1.Contains("Mission"))
				{
					list_1.Add("Mission");
				}
			}
			if (WeaponeeringExpandAllNodes)
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					if (!list_2.Contains("Aircraft #1"))
					{
						list_2.Add("Aircraft #1");
					}
					if (!list_2.Contains("Aircraft #2"))
					{
						list_2.Add("Aircraft #2");
					}
					if (!list_2.Contains("Aircraft #3"))
					{
						list_2.Add("Aircraft #3");
					}
					if (!list_2.Contains("Aircraft #4"))
					{
						list_2.Add("Aircraft #4");
					}
					if (!list_2.Contains("Aircraft #5"))
					{
						list_2.Add("Aircraft #5");
					}
					if (!list_2.Contains("Aircraft #6"))
					{
						list_2.Add("Aircraft #6");
					}
				}
				else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					if (!list_2.Contains("Flight"))
					{
						list_2.Add("Flight");
					}
				}
				else if (!list_2.Contains("Mission"))
				{
					list_2.Add("Mission");
				}
			}
			foreach (string item in list_1)
			{
				foreach (TreeGridNode node in TGV_Targeteering.Nodes)
				{
					try
					{
						if ((object)(string)((DataGridViewBand)node).Tag == item)
						{
							node.Expand();
							break;
						}
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
			}
			foreach (string item2 in list_2)
			{
				foreach (TreeGridNode node2 in TGV_Weaponeering.Nodes)
				{
					try
					{
						if ((object)(string)((DataGridViewBand)node2).Tag == item2)
						{
							node2.Expand();
							break;
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 999999", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (TreeGridNode node3 in TGV_Weaponeering.Nodes)
			{
				try
				{
					foreach (TreeGridNode node4 in node3.Nodes)
					{
						Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)node4).Tag;
						if ((weaponeeringEntry.WeaponType == Weapon._WeaponType.GuidedWeapon) | (weaponeeringEntry.WeaponType == Weapon._WeaponType.GuidedProjectile))
						{
							DataGridViewTextBoxCell val = new DataGridViewTextBoxCell();
							((DataGridViewCell)val).Value = "";
							((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, node4.RowIndex] = (DataGridViewCell)(object)val;
							((DataGridViewCell)val).ReadOnly = true;
						}
						if (Conversions.ToInteger(((DataGridView)TGV_Weaponeering)[((DataGridViewBand)Target).Index, node4.RowIndex].Value) == 0)
						{
							DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
							DataGridViewTextBoxCell val3 = new DataGridViewTextBoxCell();
							DataGridViewTextBoxCell val4 = new DataGridViewTextBoxCell();
							((DataGridViewCell)val2).Value = "";
							((DataGridViewCell)val3).Value = "";
							((DataGridViewCell)val4).Value = "";
							((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, node4.RowIndex] = (DataGridViewCell)(object)val2;
							((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, node4.RowIndex] = (DataGridViewCell)(object)val4;
							((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, node4.RowIndex] = (DataGridViewCell)(object)val3;
							((DataGridViewCell)val2).ReadOnly = true;
							((DataGridViewCell)val3).ReadOnly = true;
							((DataGridViewCell)val4).ReadOnly = true;
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 999999", ex6.Message);
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (TGV_Targeteering.Rows.Count != 0 && num != 0)
			{
				TGV_Targeteering.Rows[num].Cells[num2].Selected = true;
				if (firstDisplayedScrollingRowIndex != -1)
				{
					((DataGridView)TGV_Targeteering).FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				}
			}
			if (TGV_Weaponeering.Rows.Count != 0 && num3 != 0)
			{
				TGV_Weaponeering.Rows[num3].Cells[num4].Selected = true;
				if (firstDisplayedScrollingRowIndex2 != -1)
				{
					((DataGridView)TGV_Weaponeering).FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex2;
				}
			}
			method_26();
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			method_14();
		}
	}

	private void method_7(string string_1, ref WriteLockedList<Mission.TargeteeringEntry> writeLockedList_0, ref Waypoint waypoint_0)
	{
		//IL_0c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6d: Expected O, but got Unknown
		//IL_0c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c73: Expected O, but got Unknown
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Expected O, but got Unknown
		//IL_0c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c81: Expected O, but got Unknown
		//IL_0c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Expected O, but got Unknown
		try
		{
			int num = 0;
			TreeGridNode treeGridNode = TGV_Targeteering.Nodes.Add(string_1, null, null);
			((DataGridViewBand)treeGridNode).Tag = string_1;
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Mission)
			{
				List<Contact> list = FindMissionTargets();
				if (!Information.IsNothing((object)list) && list.Count > 0)
				{
					DateTime? dateTime = default(DateTime?);
					foreach (Contact item in list)
					{
						if (Information.IsNothing((object)item))
						{
							continue;
						}
						string text;
						if (Information.IsNothing((object)waypoint_0.Time_Zulu))
						{
							text = "-";
						}
						else
						{
							dateTime = ((!Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon)) ? waypoint_0.Time_Zulu_Weapon : waypoint_0.Time_Zulu);
							text = ((dateTime.Value.Hour < 10) ? ("0" + dateTime.Value.Hour + ":") : (dateTime.Value.Hour + ":"));
							text = ((dateTime.Value.Minute >= 10) ? (text + dateTime.Value.Minute + ":") : (text + "0" + dateTime.Value.Minute + ":"));
							text = ((dateTime.Value.Second >= 10) ? (text + dateTime.Value.Second) : (text + "0" + dateTime.Value.Second));
							if (waypoint_0.Type == Waypoint.WaypointType.Target || waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
							{
								string text2 = dateTime.Value.Year + "-";
								text2 = ((dateTime.Value.Month >= 10) ? (text2 + dateTime.Value.Month + "-") : (text2 + "0" + dateTime.Value.Month + "-"));
								if (dateTime.Value.Day < 10)
								{
									text2 = text2 + "0" + dateTime.Value.Day;
								}
								else
								{
									text2 += dateTime.Value.Day;
								}
							}
						}
						string text3;
						if (!Information.IsNothing((object)dateTime) && !Information.IsNothing((object)waypoint_0.Time_Local))
						{
							DateTime time = Client.CurrentScenario.Time;
							bool use_DST = Client.CurrentScenario.Use_DST;
							string dST_Start = Client.CurrentScenario.DST_Start;
							string dST_End = Client.CurrentScenario.DST_End;
							DateTime? dateTime2 = (Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Local : waypoint_0.Time_Local_Weapon);
							text3 = ((dateTime2.Value.Hour >= 10) ? (dateTime2.Value.Hour + ":") : ("0" + dateTime2.Value.Hour + ":"));
							text3 = ((dateTime2.Value.Minute >= 10) ? (text3 + dateTime2.Value.Minute + ":") : (text3 + "0" + dateTime2.Value.Minute + ":"));
							text3 = ((dateTime2.Value.Second >= 10) ? (text3 + dateTime2.Value.Second) : (text3 + "0" + dateTime2.Value.Second));
							waypoint_0.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, UseCurrentScenarioTime: false, waypoint_0.Latitude, waypoint_0.Longitude, 0.0);
							if (Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon))
							{
								waypoint_0.Time_Local = Misc.LocalTime(waypoint_0.Time_Zulu.Value, waypoint_0.Longitude, use_DST, dST_Start, dST_End);
							}
							else
							{
								waypoint_0.Time_Local = Misc.LocalTime(waypoint_0.Time_Zulu_Weapon.Value, waypoint_0.Longitude, use_DST, dST_Start, dST_End);
							}
							text3 = text3 + " (" + SunModule.GetTimeOfDay_String(waypoint_0.TimeOfDay, time, waypoint_0.Longitude, use_DST, dST_Start, dST_End) + ")";
						}
						else
						{
							text3 = "-";
						}
						string text4 = Misc.CoordsToEnglish(waypoint_0.Latitude, waypoint_0.Longitude);
						string text5 = "Using WRA";
						num++;
						treeGridNode.Nodes.Add(num, item.Name, text5, text, text3, text4);
					}
				}
			}
			else if (!Information.IsNothing((object)writeLockedList_0))
			{
				DateTime? dateTime3 = default(DateTime?);
				foreach (Mission.TargeteeringEntry item2 in writeLockedList_0)
				{
					string text6;
					if (!Information.IsNothing((object)waypoint_0.Time_Zulu))
					{
						dateTime3 = ((!Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon)) ? waypoint_0.Time_Zulu_Weapon : waypoint_0.Time_Zulu);
						text6 = ((dateTime3.Value.Hour >= 10) ? (dateTime3.Value.Hour + ":") : ("0" + dateTime3.Value.Hour + ":"));
						text6 = ((dateTime3.Value.Minute >= 10) ? (text6 + dateTime3.Value.Minute + ":") : (text6 + "0" + dateTime3.Value.Minute + ":"));
						text6 = ((dateTime3.Value.Second >= 10) ? (text6 + dateTime3.Value.Second) : (text6 + "0" + dateTime3.Value.Second));
						if (waypoint_0.Type == Waypoint.WaypointType.Target || waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
						{
							string text7 = dateTime3.Value.Year + "-";
							text7 = ((dateTime3.Value.Month >= 10) ? (text7 + dateTime3.Value.Month + "-") : (text7 + "0" + dateTime3.Value.Month + "-"));
							if (dateTime3.Value.Day < 10)
							{
								text7 = text7 + "0" + dateTime3.Value.Day;
							}
							else
							{
								text7 += dateTime3.Value.Day;
							}
						}
					}
					else
					{
						text6 = "-";
					}
					string text8;
					if (!Information.IsNothing((object)dateTime3) && !Information.IsNothing((object)waypoint_0.Time_Local))
					{
						DateTime time2 = Client.CurrentScenario.Time;
						bool use_DST2 = Client.CurrentScenario.Use_DST;
						string dST_Start2 = Client.CurrentScenario.DST_Start;
						string dST_End2 = Client.CurrentScenario.DST_End;
						DateTime? dateTime4 = (Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Local : waypoint_0.Time_Local_Weapon);
						text8 = ((dateTime4.Value.Hour >= 10) ? (dateTime4.Value.Hour + ":") : ("0" + dateTime4.Value.Hour + ":"));
						text8 = ((dateTime4.Value.Minute < 10) ? (text8 + "0" + dateTime4.Value.Minute + ":") : (text8 + dateTime4.Value.Minute + ":"));
						text8 = ((dateTime4.Value.Second >= 10) ? (text8 + dateTime4.Value.Second) : (text8 + "0" + dateTime4.Value.Second));
						waypoint_0.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime3.Value.Year, dateTime3.Value.Month, dateTime3.Value.Day, dateTime3.Value.Hour, dateTime3.Value.Minute, dateTime3.Value.Second, UseCurrentScenarioTime: false, waypoint_0.Latitude, waypoint_0.Longitude, 0.0);
						if (Information.IsNothing((object)waypoint_0.Time_Zulu_Weapon))
						{
							waypoint_0.Time_Local = Misc.LocalTime(waypoint_0.Time_Zulu.Value, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2);
						}
						else
						{
							waypoint_0.Time_Local = Misc.LocalTime(waypoint_0.Time_Zulu_Weapon.Value, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2);
						}
						text8 = text8 + " (" + SunModule.GetTimeOfDay_String(waypoint_0.TimeOfDay, time2, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2) + ")";
					}
					else
					{
						text8 = "-";
					}
					string text9 = Misc.CoordsToEnglish(waypoint_0.Latitude, waypoint_0.Longitude);
					string text10 = "Not configured";
					switch (TargetWaypoint_Lead.TargeteeringMethod)
					{
					case Mission._TargeteeringMethod.Mission:
						text10 = "Using WRA";
						break;
					case Mission._TargeteeringMethod.Flight:
						text10 = "Using WRA";
						break;
					case Mission._TargeteeringMethod.Individual:
						text10 = "No weapons assigned";
						break;
					}
					num++;
					((DataGridViewBand)treeGridNode.Nodes.Add(num, item2.Target_Description, text10, text6, text8, text9)).Tag = item2;
				}
			}
			DataGridViewTextBoxCell val = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val3 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val4 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val5 = new DataGridViewTextBoxCell();
			((DataGridViewCell)val).Value = "";
			((DataGridViewCell)val2).Value = "";
			((DataGridViewCell)val3).Value = "";
			((DataGridViewCell)val4).Value = "";
			((DataGridViewCell)val5).Value = "";
			((DataGridView)TGV_Targeteering)[((DataGridViewBand)TargetName).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val;
			((DataGridView)TGV_Targeteering)[((DataGridViewBand)AssignedWeapons).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val2;
			((DataGridView)TGV_Targeteering)[((DataGridViewBand)Time_Zulu).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val3;
			((DataGridView)TGV_Targeteering)[((DataGridViewBand)Time_Local).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val4;
			((DataGridView)TGV_Targeteering)[((DataGridViewBand)Coordinates).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val5;
			((DataGridViewCell)val).ReadOnly = true;
			((DataGridViewCell)val2).ReadOnly = true;
			((DataGridViewCell)val3).ReadOnly = true;
			((DataGridViewCell)val4).ReadOnly = true;
			((DataGridViewCell)val5).ReadOnly = true;
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

	private void method_8(string string_1, ref WriteLockedList<Mission.TargeteeringEntry> writeLockedList_0, ref ConcurrentBag<Mission.WeaponeeringEntry> concurrentBag_0, ref Waypoint waypoint_0)
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		try
		{
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Mission || TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
			{
				return;
			}
			TreeGridNode treeGridNode = TGV_Weaponeering.Nodes.Add(string_1, null, null, null, null, null);
			((DataGridViewBand)treeGridNode).Tag = string_1;
			if (!Information.IsNothing((object)concurrentBag_0))
			{
				foreach (Mission.WeaponeeringEntry item in concurrentBag_0)
				{
					int num = Target_To_TargetSelection(item.TargeteeringEntryObjectID, ref writeLockedList_0);
					string text = "-";
					if (item.Route != null && item.Route.Count() > 0)
					{
						string text2 = "";
						if (item.Route[item.Route.Count() - 1].Time_Zulu.HasValue)
						{
							text2 = "ToT: " + item.Route[item.Route.Count() - 1].Time_Zulu.ToString() + ", ";
						}
						string text3 = "Flight time: " + Conversions.ToString(item.Route[item.Route.Count() - 1].Leg_TotalTime) + ", ";
						string text4 = " Waypoints: " + Conversions.ToString(item.Route.Count());
						text = text2 + text3 + text4;
					}
					string text5 = item.WeaponName;
					if (item.IsRouteReference)
					{
						text5 = "Time ref: " + text5;
					}
					((DataGridViewBand)treeGridNode.Nodes.Add(text5, num, item.LostTarget, WeaponQty_To_WeaponQtySelection(item.WeaponQty), item.FiringRange, text)).Tag = item;
				}
			}
			DataGridViewTextBoxCell val = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val3 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val4 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell val5 = new DataGridViewTextBoxCell();
			((DataGridViewCell)val).Value = "";
			((DataGridViewCell)val2).Value = "";
			((DataGridViewCell)val3).Value = "";
			((DataGridViewCell)val4).Value = "";
			((DataGridViewCell)val5).Value = "";
			((DataGridView)TGV_Weaponeering)[((DataGridViewBand)Target).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val;
			((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val2;
			((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val3;
			((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val4;
			((DataGridView)TGV_Weaponeering)[((DataGridViewBand)Route).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val5;
			((DataGridViewCell)val).ReadOnly = true;
			((DataGridViewCell)val2).ReadOnly = true;
			((DataGridViewCell)val3).ReadOnly = true;
			((DataGridViewCell)val4).ReadOnly = true;
			((DataGridViewCell)val5).ReadOnly = true;
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

	private void method_9(object sender, ExpandingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			string item = (string)((DataGridViewBand)e.Node).Tag;
			if (!list_1.Contains(item))
			{
				list_1.Add(item);
			}
		}
	}

	private void method_10(object sender, ExpandingEventArgs e)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		try
		{
			if (e.Node.Level != 1)
			{
				return;
			}
			string text = (string)((DataGridViewBand)e.Node).Tag;
			if (!list_2.Contains(text))
			{
				list_2.Add(text);
			}
			foreach (TreeGridNode node in e.Node.Nodes)
			{
				DataTable theComboBoxDataSource_WeaponQty = new DataTable();
				DataTable theComboBoxDataSource_Target = new DataTable();
				DataTable theComboBoxDataSource_LostTarget = new DataTable();
				DataTable theComboBoxDataSource_FiringRange = new DataTable();
				DataGridViewComboBoxCell val = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)WeaponQty).Index];
				DataGridViewComboBoxCell val2 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)Target).Index];
				DataGridViewComboBoxCell val3 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)LostTarget).Index];
				DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)FiringRange).Index];
				Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)node).Tag;
				Weapon theWeapon = null;
				ComboBoxDataSource_WeaponQty(ref theComboBoxDataSource_WeaponQty, null, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val).Value), weaponeeringEntry.WeaponMaxQty);
				TList<Mission.TargeteeringEntry> theTargeteeringEntries = ((Operators.CompareString(text, "Aircraft #1", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList) : ((Operators.CompareString(text, "Aircraft #2", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_LeadElementWingman) : ((Operators.CompareString(text, "Aircraft #3", true) != 0) ? ((Operators.CompareString(text, "Aircraft #4", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElementWingman) : ((Operators.CompareString(text, "Aircraft #5", true) != 0) ? ((Operators.CompareString(text, "Aircraft #6", true) != 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList) : ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman)) : ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElement))) : ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElement))));
				ComboBoxDataSource_Target(ref theComboBoxDataSource_Target, Conversions.ToInteger(((DataGridViewCell)val2).Value), ref theTargeteeringEntries);
				ComboBoxDataSource_LostTarget(ref theComboBoxDataSource_LostTarget, Conversions.ToInteger(((DataGridViewCell)val3).Value), weaponeeringEntry.bool_0);
				ComboBoxDataSource_FiringRange(ref theComboBoxDataSource_FiringRange, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(((DataGridViewCell)val4).Value));
				val.DataSource = theComboBoxDataSource_WeaponQty;
				val.DisplayMember = "Description";
				val.ValueMember = "ID";
				val4.DataSource = theComboBoxDataSource_FiringRange;
				val4.DisplayMember = "Description";
				val4.ValueMember = "ID";
				val3.DataSource = theComboBoxDataSource_LostTarget;
				val3.DisplayMember = "Description";
				val3.ValueMember = "ID";
				val2.DataSource = theComboBoxDataSource_Target;
				val2.DisplayMember = "Description";
				val2.ValueMember = "ID";
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

	private void method_11(object sender, CollapsingEventArgs e)
	{
		string item = (string)((DataGridViewBand)e.Node).Tag;
		if (e.Node.Level == 1)
		{
			list_1.Remove(item);
		}
	}

	private void method_12(object sender, CollapsingEventArgs e)
	{
		string item = (string)((DataGridViewBand)e.Node).Tag;
		if (e.Node.Level == 1)
		{
			list_2.Remove(item);
		}
	}

	public void FindAllAircraft()
	{
		try
		{
			AircraftList.Clear();
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
			{
				if (!AircraftList.Contains("Flight"))
				{
					AircraftList.Add("Flight");
				}
			}
			else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
			{
				if (!AircraftList.Contains("Aircraft #1"))
				{
					AircraftList.Add("Aircraft #1");
				}
				if (SelectedFlight.DesiredAircraftQty > 1 && !AircraftList.Contains("Aircraft #2"))
				{
					AircraftList.Add("Aircraft #2");
				}
				if (SelectedFlight.DesiredAircraftQty > 2 && !AircraftList.Contains("Aircraft #3"))
				{
					AircraftList.Add("Aircraft #3");
				}
				if (SelectedFlight.DesiredAircraftQty > 3 && !AircraftList.Contains("Aircraft #4"))
				{
					AircraftList.Add("Aircraft #4");
				}
				if (SelectedFlight.DesiredAircraftQty > 4 && !AircraftList.Contains("Aircraft #5"))
				{
					AircraftList.Add("Aircraft #5");
				}
				if (SelectedFlight.DesiredAircraftQty > 4 && !AircraftList.Contains("Aircraft #6"))
				{
					AircraftList.Add("Aircraft #6");
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

	public void Weaponeering_RetreiveLoadoutWeapons(ActiveUnit theUnit)
	{
		if (Information.IsNothing((object)((Aircraft)theUnit).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
		foreach (WeaponRec weaponRec in weapons)
		{
			Weapon theWeapon = weaponRec.get_ReferenceWeapon(Client.CurrentScenario);
			if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref theWeapon))
			{
				list_0.Add(weaponRec);
			}
		}
	}

	public void Weaponeering_RetreiveMagazineWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Magazine> enumerable = theUnit.SharedMagazines.OrderBy([SpecialName] (Magazine theM) => theM.Name);
		foreach (Magazine item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon theWeapon = weapon.get_ReferenceWeapon(Client.CurrentScenario);
				if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref theWeapon))
				{
					list_0.Add(weapon);
				}
			}
		}
	}

	public void Weaponeering_RetreiveMountWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Mount> enumerable = theUnit.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name);
		foreach (Mount item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon theWeapon = mountWeapon.get_ReferenceWeapon(Client.CurrentScenario);
				if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref theWeapon))
				{
					list_0.Add(mountWeapon);
				}
			}
		}
	}

	public bool StrikeMissionIsSuitableForThisTarget(Scenario theScen, ref Weapon theWeapon)
	{
		bool result;
		try
		{
			switch (((Strike)SelectedMission).Type)
			{
			default:
				result = false;
				break;
			case Strike.StrikeType.Maritime_Strike:
				result = (theWeapon.ValidTargets.SurfaceVessel ? true : false);
				break;
			case Strike.StrikeType.Land_Strike:
			{
				int num;
				if (!theWeapon.ValidTargets.LandStructure_Hard && !theWeapon.ValidTargets.LandStructure_Soft && !theWeapon.ValidTargets.MobileTarget_Hard && !theWeapon.ValidTargets.LandStructure_Soft && !theWeapon.ValidTargets.Radar)
				{
					if (!theWeapon.ValidTargets.Runway)
					{
						result = false;
						break;
					}
					num = 1;
				}
				else
				{
					num = 1;
				}
				result = (byte)num != 0;
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	private void method_13()
	{
		SendMessage(((Control)this).Handle, 11, new IntPtr(0), IntPtr.Zero);
		MyProject.Forms.MainForm.RightColumnWPF1.SuspendRefresh();
	}

	private void method_14(bool bool_4 = true)
	{
		SendMessage(((Control)this).Handle, 11, new IntPtr(-1), IntPtr.Zero);
		if (bool_4)
		{
			((Control)this).Refresh();
		}
		MyProject.Forms.MainForm.RightColumnWPF1.ResumeRefresh();
	}

	internal void RefreshGrid()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedMission))
			{
				if (Information.IsNothing((object)SelectedFlight))
				{
					((Form)this).Text = "Flightplan Editor for flight <NO FLIGHT SELECTED>";
				}
				else if (SelectedMission.HasFlights())
				{
					((Form)this).Text = "Flightplan Editor for flight " + SelectedFlight.Callsign;
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

	private void method_15(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_Targeteering.Nodes)
			{
				if (((DataGridViewRow)node).Selected)
				{
					break;
				}
				foreach (TreeGridNode node2 in node.Nodes)
				{
					_ = ((DataGridViewRow)node2).Selected;
				}
			}
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

	private void method_16(object sender, DataGridViewCellEventArgs e)
	{
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
			{
				if (((DataGridViewRow)node).Selected)
				{
					break;
				}
				string text = (string)((DataGridViewBand)node).Tag;
				foreach (TreeGridNode node2 in node.Nodes)
				{
					if (!((DataGridViewRow)node2).Selected)
					{
						continue;
					}
					DataTable theComboBoxDataSource_Target = new DataTable();
					DataTable theComboBoxDataSource_WeaponQty = new DataTable();
					DataTable theComboBoxDataSource_LostTarget = new DataTable();
					DataTable theComboBoxDataSource_FiringRange = new DataTable();
					DataGridViewColumn val = ((DataGridView)TGV_Weaponeering).Columns[e.ColumnIndex];
					if (Operators.CompareString(val.Name, "Target", true) != 0)
					{
						if (Operators.CompareString(val.Name, "LostTarget", true) != 0)
						{
							if (Operators.CompareString(val.Name, "WeaponQty", true) != 0)
							{
								if (Operators.CompareString(val.Name, "FiringRange", true) == 0)
								{
									if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, node2.RowIndex]).GetType().ToString().Contains("ComboBoxCell"))
									{
										Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)node2).Tag;
										DataGridViewComboBoxCell val2 = (DataGridViewComboBoxCell)node2.Cells[((DataGridViewBand)FiringRange).Index];
										ComboBoxDataSource_FiringRange(ref theComboBoxDataSource_FiringRange, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(((DataGridViewCell)val2).Value));
										val2.DataSource = theComboBoxDataSource_FiringRange;
										val2.DropDownWidth = 500;
										val2.DisplayMember = "Description";
										val2.ValueMember = "ID";
										((DataGridView)TGV_Weaponeering).BeginEdit(true);
										((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_Weaponeering).EditingControl).DroppedDown = true;
									}
									break;
								}
								continue;
							}
							if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, node2.RowIndex]).GetType().ToString().Contains("ComboBoxCell"))
							{
								Mission.WeaponeeringEntry weaponeeringEntry2 = (Mission.WeaponeeringEntry)((DataGridViewBand)node2).Tag;
								DataGridViewComboBoxCell val3 = (DataGridViewComboBoxCell)node2.Cells[((DataGridViewBand)WeaponQty).Index];
								Weapon theWeapon = null;
								ComboBoxDataSource_WeaponQty(ref theComboBoxDataSource_WeaponQty, null, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val3).Value), weaponeeringEntry2.WeaponMaxQty);
								val3.DataSource = theComboBoxDataSource_WeaponQty;
								val3.DropDownWidth = 500;
								val3.DisplayMember = "Description";
								val3.ValueMember = "ID";
								((DataGridView)TGV_Weaponeering).BeginEdit(true);
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_Weaponeering).EditingControl).DroppedDown = true;
							}
							break;
						}
						if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, node2.RowIndex]).GetType().ToString().Contains("ComboBoxCell"))
						{
							Mission.WeaponeeringEntry weaponeeringEntry3 = (Mission.WeaponeeringEntry)((DataGridViewBand)node2).Tag;
							DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)node2.Cells[((DataGridViewBand)LostTarget).Index];
							ComboBoxDataSource_LostTarget(ref theComboBoxDataSource_LostTarget, Conversions.ToInteger(((DataGridViewCell)val4).Value), weaponeeringEntry3.bool_0);
							val4.DataSource = theComboBoxDataSource_LostTarget;
							val4.DisplayMember = "Description";
							val4.ValueMember = "ID";
							val4.DropDownWidth = 500;
							((DataGridView)TGV_Weaponeering).BeginEdit(true);
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_Weaponeering).EditingControl).DroppedDown = true;
						}
						break;
					}
					TList<Mission.TargeteeringEntry> theTargeteeringEntries = ((Operators.CompareString(text, "Aircraft #1", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList) : ((Operators.CompareString(text, "Aircraft #2", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_LeadElementWingman) : ((Operators.CompareString(text, "Aircraft #3", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElement) : ((Operators.CompareString(text, "Aircraft #4", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElementWingman) : ((Operators.CompareString(text, "Aircraft #5", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElement) : ((Operators.CompareString(text, "Aircraft #6", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman) : ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList)))))));
					DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)node2.Cells[((DataGridViewBand)Target).Index];
					ComboBoxDataSource_Target(ref theComboBoxDataSource_Target, Conversions.ToInteger(((DataGridViewCell)val5).Value), ref theTargeteeringEntries);
					val5.DataSource = theComboBoxDataSource_Target;
					val5.DisplayMember = "Description";
					val5.ValueMember = "ID";
					val5.DropDownWidth = 500;
					((DataGridView)TGV_Weaponeering).BeginEdit(true);
					((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_Weaponeering).EditingControl).DroppedDown = true;
					break;
				}
			}
			method_26();
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

	private void method_17(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_2 || ((BaseCollection)((DataGridView)TGV_Targeteering).SelectedRows).Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = default(TreeGridNode);
		bool flag = default(bool);
		foreach (TreeGridNode node in TGV_Targeteering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!Information.IsNothing((object)treeGridNode) && !Information.IsNothing((object)treeGridNode.Parent))
		{
			_ = treeGridNode.Parent;
		}
	}

	private void method_18(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_2 || ((BaseCollection)((DataGridView)TGV_Weaponeering).SelectedRows).Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = default(TreeGridNode);
		bool flag = default(bool);
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!Information.IsNothing((object)treeGridNode) && !Information.IsNothing((object)treeGridNode.Parent))
		{
			TreeGridNode parent = treeGridNode.Parent;
			method_19(e, treeGridNode, parent);
		}
	}

	private void method_19(DataGridViewCellEventArgs dataGridViewCellEventArgs_0, TreeGridNode treeGridNode_0, TreeGridNode treeGridNode_1)
	{
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected O, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected O, but got Unknown
		RuntimeHelpers.GetObjectValue(((DataGridView)TGV_Weaponeering)[dataGridViewCellEventArgs_0.ColumnIndex, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_Weaponeering)[((DataGridViewBand)Target).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue2 = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue3 = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue4 = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)treeGridNode_0).Tag;
		bool flag = default(bool);
		Mission.TargeteeringEntry targeteeringEntry = default(Mission.TargeteeringEntry);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)Target).Index)
		{
			string text = (string)((DataGridViewBand)treeGridNode_1).Tag;
			foreach (string aircraft in AircraftList)
			{
				if (Operators.CompareString(aircraft, text, true) != 0)
				{
					continue;
				}
				flag = true;
				TList<Mission.TargeteeringEntry> theTargeteeringEntries = ((Operators.CompareString(aircraft, "Aircraft #1", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList) : ((Operators.CompareString(aircraft, "Aircraft #2", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_LeadElementWingman) : ((Operators.CompareString(aircraft, "Aircraft #3", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElement) : ((Operators.CompareString(aircraft, "Aircraft #4", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_SecondElementWingman) : ((Operators.CompareString(aircraft, "Aircraft #5", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElement) : ((Operators.CompareString(aircraft, "Aircraft #6", true) == 0) ? ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman) : ((TList<Mission.TargeteeringEntry>)TargetWaypoint_Lead.TargeteeringList)))))));
				targeteeringEntry = TargetSelection_To_Target(RuntimeHelpers.GetObjectValue(objectValue), ref theTargeteeringEntries);
				if (Information.IsNothing((object)targeteeringEntry))
				{
					DataGridViewTextBoxCell val = new DataGridViewTextBoxCell();
					DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
					DataGridViewTextBoxCell val3 = new DataGridViewTextBoxCell();
					((DataGridViewCell)val).Value = "";
					((DataGridViewCell)val2).Value = "";
					((DataGridViewCell)val3).Value = "";
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val;
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val3;
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val2;
					((DataGridViewCell)val).ReadOnly = true;
					((DataGridViewCell)val2).ReadOnly = true;
					((DataGridViewCell)val3).ReadOnly = true;
					break;
				}
				Mission.WeaponeeringEntry weaponeeringEntry2 = (Mission.WeaponeeringEntry)((DataGridViewBand)treeGridNode_0).Tag;
				if (!((weaponeeringEntry2.WeaponType == Weapon._WeaponType.GuidedWeapon) | (weaponeeringEntry2.WeaponType == Weapon._WeaponType.GuidedProjectile)))
				{
					if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, treeGridNode_0.RowIndex]).GetType().ToString().Contains("TextBoxCell"))
					{
						DataGridViewComboBoxCell val4 = new DataGridViewComboBoxCell();
						((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val4;
						((DataGridViewCell)val4).ReadOnly = false;
					}
					DataTable theComboBoxDataSource_WeaponQty = new DataTable();
					DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[((DataGridViewBand)WeaponQty).Index];
					Weapon theWeapon = null;
					ComboBoxDataSource_WeaponQty(ref theComboBoxDataSource_WeaponQty, null, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val5).Value), weaponeeringEntry.WeaponMaxQty);
					val5.DataSource = theComboBoxDataSource_WeaponQty;
					val5.DisplayMember = "Description";
					val5.ValueMember = "ID";
					treeGridNode_0.Cells[((DataGridViewBand)WeaponQty).Index].Value = WeaponQty_To_WeaponQtySelection(weaponeeringEntry.WeaponQty);
				}
				else
				{
					DataGridViewTextBoxCell val6 = new DataGridViewTextBoxCell();
					((DataGridViewCell)val6).Value = "";
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)WeaponQty).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val6;
					((DataGridViewCell)val6).ReadOnly = true;
				}
				if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, treeGridNode_0.RowIndex]).GetType().ToString().Contains("TextBoxCell"))
				{
					DataGridViewComboBoxCell val7 = new DataGridViewComboBoxCell();
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)LostTarget).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val7;
					((DataGridViewCell)val7).ReadOnly = false;
				}
				if (((object)((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, treeGridNode_0.RowIndex]).GetType().ToString().Contains("TextBoxCell"))
				{
					DataGridViewComboBoxCell val8 = new DataGridViewComboBoxCell();
					((DataGridView)TGV_Weaponeering)[((DataGridViewBand)FiringRange).Index, treeGridNode_0.RowIndex] = (DataGridViewCell)(object)val8;
					((DataGridViewCell)val8).ReadOnly = false;
				}
				DataTable theComboBoxDataSource_LostTarget = new DataTable();
				DataTable theComboBoxDataSource_FiringRange = new DataTable();
				DataGridViewComboBoxCell val9 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[((DataGridViewBand)LostTarget).Index];
				DataGridViewComboBoxCell val10 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[((DataGridViewBand)FiringRange).Index];
				ComboBoxDataSource_LostTarget(ref theComboBoxDataSource_LostTarget, Conversions.ToInteger(((DataGridViewCell)val9).Value), weaponeeringEntry.bool_0);
				ComboBoxDataSource_FiringRange(ref theComboBoxDataSource_FiringRange, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(((DataGridViewCell)val10).Value));
				val10.DataSource = theComboBoxDataSource_FiringRange;
				val10.DisplayMember = "Description";
				val10.ValueMember = "ID";
				val9.DataSource = theComboBoxDataSource_LostTarget;
				val9.DisplayMember = "Description";
				val9.ValueMember = "ID";
				treeGridNode_0.Cells[((DataGridViewBand)LostTarget).Index].Value = weaponeeringEntry.LostTarget;
				treeGridNode_0.Cells[((DataGridViewBand)FiringRange).Index].Value = FiringRange_To_FiringRangeSelection(weaponeeringEntry.FiringRange);
				break;
			}
		}
		bool flag2 = default(bool);
		int weaponQty = default(int);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)WeaponQty).Index)
		{
			flag2 = true;
			weaponQty = WeaponQtySelection_To_WeaponQty(RuntimeHelpers.GetObjectValue(objectValue2));
		}
		bool flag3 = default(bool);
		int firingRange = default(int);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)FiringRange).Index)
		{
			flag3 = true;
			firingRange = FiringRangeSelection_To_FiringRange(RuntimeHelpers.GetObjectValue(objectValue4));
		}
		bool flag4 = default(bool);
		int lostTarget = default(int);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)LostTarget).Index)
		{
			flag4 = true;
			lostTarget = (int)LostTargetSelection_To_LostTarget(RuntimeHelpers.GetObjectValue(objectValue3));
		}
		if (Information.IsNothing((object)weaponeeringEntry))
		{
			return;
		}
		if (!flag)
		{
			if (!flag2)
			{
				if (!flag4)
				{
					if (flag3)
					{
						weaponeeringEntry.FiringRange = firingRange;
					}
				}
				else
				{
					weaponeeringEntry.LostTarget = lostTarget;
				}
			}
			else
			{
				weaponeeringEntry.WeaponQty = weaponQty;
			}
		}
		else if (Information.IsNothing((object)targeteeringEntry))
		{
			weaponeeringEntry.TargeteeringEntryObjectID = "";
		}
		else
		{
			weaponeeringEntry.TargeteeringEntryObjectID = targeteeringEntry.ObjectID;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		bool_2 = true;
		if (((DataGridView)TGV_Targeteering).IsCurrentCellDirty)
		{
			((DataGridView)TGV_Targeteering).CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		bool_2 = true;
		if (((DataGridView)TGV_Weaponeering).IsCurrentCellDirty)
		{
			((DataGridView)TGV_Weaponeering).CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || SelectedMission.MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		if (Information.IsNothing((object)SelectedAircraft))
		{
			SelectedAircraft = "Aircraft #1";
		}
		if (!list_1.Contains(SelectedAircraft))
		{
			list_1.Add(SelectedAircraft);
		}
		Waypoint waypoint = ((Operators.CompareString(SelectedAircraft, "Aircraft #1", true) == 0) ? TargetWaypoint_Lead : ((Operators.CompareString(SelectedAircraft, "Aircraft #2", true) == 0) ? TargetWaypoint_Lead.Waypoint_LeadElementWingman : ((Operators.CompareString(SelectedAircraft, "Aircraft #3", true) == 0) ? TargetWaypoint_Lead.Waypoint_SecondElement : ((Operators.CompareString(SelectedAircraft, "Aircraft #4", true) == 0) ? TargetWaypoint_Lead.Waypoint_SecondElementWingman : ((Operators.CompareString(SelectedAircraft, "Aircraft #5", true) == 0) ? TargetWaypoint_Lead.Waypoint_ThirdElement : ((Operators.CompareString(SelectedAircraft, "Aircraft #6", true) == 0) ? TargetWaypoint_Lead.Waypoint_ThirdElementWingman : TargetWaypoint_Lead))))));
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.get_UnitSide(SetSideOnly: false)))
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					bool flag = false;
					foreach (Mission.TargeteeringEntry targeteering in waypoint.TargeteeringList)
					{
						if (Operators.CompareString(targeteering.Target_ActualUnitObjectID, value.ObjectID, true) == 0)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Mission.TargeteeringEntry item = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, value.Name, "", value.ObjectID, value.DBID, value.get_Latitude((GlobalVariables.BooleanObject)null), value.get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						waypoint.TargeteeringList.Add(item);
					}
				}
				if (SelectedMission.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.set_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
				}
			}
			else if (selectedUnit.IsActiveUnit)
			{
				bool flag2 = false;
				foreach (Mission.TargeteeringEntry targeteering2 in waypoint.TargeteeringList)
				{
					if (Operators.CompareString(targeteering2.Target_ActualUnitObjectID, selectedUnit.ObjectID, true) == 0)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Mission.TargeteeringEntry item2 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, selectedUnit.Name, "", ((ActiveUnit)selectedUnit).ObjectID, ((ActiveUnit)selectedUnit).DBID, selectedUnit.get_Latitude((GlobalVariables.BooleanObject)null), selectedUnit.get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
					waypoint.TargeteeringList.Add(item2);
				}
				if (SelectedMission.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.set_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
				}
			}
			else
			{
				Contact contact = (Contact)selectedUnit;
				if (!Information.IsNothing((object)contact.ActualUnit) && Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
				{
					foreach (ActiveUnit value2 in ((Group)contact.ActualUnit).Units.Values)
					{
						bool flag3 = false;
						foreach (Mission.TargeteeringEntry targeteering3 in waypoint.TargeteeringList)
						{
							int num;
							if (Operators.CompareString(targeteering3.Target_ContactObjectID, contact.ObjectID, true) != 0)
							{
								if (Operators.CompareString(targeteering3.Target_ActualUnitObjectID, contact.ActualUnit.ObjectID, true) != 0)
								{
									continue;
								}
								num = 1;
							}
							else
							{
								num = 1;
							}
							flag3 = (byte)num != 0;
							break;
						}
						if (!flag3)
						{
							Mission.TargeteeringEntry item3 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact.Name, contact.ObjectID, value2.ObjectID, value2.DBID, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
							waypoint.TargeteeringList.Add(item3);
						}
					}
				}
				else
				{
					if (Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
					{
						continue;
					}
					bool flag4 = false;
					foreach (Mission.TargeteeringEntry targeteering4 in waypoint.TargeteeringList)
					{
						int num2;
						if (Operators.CompareString(targeteering4.Target_ContactObjectID, contact.ObjectID, true) != 0)
						{
							if (Operators.CompareString(targeteering4.Target_ActualUnitObjectID, contact.ActualUnit.ObjectID, true) != 0)
							{
								continue;
							}
							num2 = 1;
						}
						else
						{
							num2 = 1;
						}
						flag4 = (byte)num2 != 0;
						break;
					}
					if (!flag4)
					{
						Mission.TargeteeringEntry item4 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact.Name, contact.ObjectID, contact.ActualUnit.ObjectID, contact.ActualUnit.DBID, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
						waypoint.TargeteeringList.Add(item4);
					}
				}
				if (SelectedMission.IsActive && contact.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
				{
					contact.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
				}
			}
			foreach (TreeGridNode node in TGV_Targeteering.Nodes)
			{
				try
				{
					if (Operators.CompareString((string)((DataGridViewBand)node).Tag, SelectedAircraft, true) == 0)
					{
						node.Expand();
					}
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
		}
		LoadGrid(TargeteeringExpandAllNodes: false, WeaponeeringExpandAllNodes: false);
		SelectedMission.TimeSincePlayerNotification = 0;
		Client.MustRefreshMainForm = true;
	}

	private void method_23(object sender, EventArgs e)
	{
		((Control)Client.FlightPlanEditorTargetsPreliminaryWindow).Show();
	}

	private void method_24(object sender, EventArgs e)
	{
		((Control)Client.FlightPlanEditorTargetsAreaWindow).Show();
	}

	private void method_25(object sender, EventArgs e)
	{
		((Control)Client.FlightPlanEditorTargetsAreaWindow).Show();
	}

	public void ComboBoxDataSource_WeaponQty(ref DataTable theComboBoxDataSource_WeaponQty, ActiveUnit theActiveUnit, ref Weapon theWeapon, int theComboBoxValue, int WeaponMaxQty)
	{
		if (!theComboBoxDataSource_WeaponQty.Columns.Contains("ID"))
		{
			theComboBoxDataSource_WeaponQty.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_WeaponQty.Columns.Contains("Description"))
		{
			theComboBoxDataSource_WeaponQty.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(0, "Use WRA");
		theComboBoxDataSource_WeaponQty.Rows.Add(1, "All weapons");
		theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapons");
		theComboBoxDataSource_WeaponQty.Rows.Add(3, "1 rnd");
		if (WeaponMaxQty < 2)
		{
			return;
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(4, "2 rnds");
		if (WeaponMaxQty < 3)
		{
			return;
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(5, "3 rnds");
		if (WeaponMaxQty < 4)
		{
			return;
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(6, "4 rnds");
		if (WeaponMaxQty < 5)
		{
			return;
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(7, "5 rnds");
		if (WeaponMaxQty < 6)
		{
			return;
		}
		theComboBoxDataSource_WeaponQty.Rows.Add(8, "6 rnds");
		if (WeaponMaxQty >= 7)
		{
			theComboBoxDataSource_WeaponQty.Rows.Add(9, "7 rnds");
			if (WeaponMaxQty >= 8)
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(10, "8 rnds");
			}
		}
	}

	public static int WeaponQtySelection_To_WeaponQty(object WeaponQty)
	{
		int result;
		try
		{
			result = Conversions.ToInteger(WeaponQty) switch
			{
				0 => -99, 
				1 => -98, 
				2 => -97, 
				3 => 1, 
				4 => 2, 
				5 => 3, 
				6 => 4, 
				7 => 5, 
				8 => 6, 
				9 => 7, 
				_ => -99, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int WeaponQty_To_WeaponQtySelection(int WeaponQty)
	{
		int result;
		try
		{
			result = WeaponQty switch
			{
				1 => 3, 
				2 => 4, 
				3 => 5, 
				4 => 6, 
				5 => 7, 
				6 => 8, 
				7 => 9, 
				8 => 10, 
				-99 => 0, 
				-98 => 1, 
				-97 => 2, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ComboBoxDataSource_LostTarget(ref DataTable theComboBoxDataSource_LostTarget, int theComboBoxValue, bool IsBOLCapable)
	{
		if (!theComboBoxDataSource_LostTarget.Columns.Contains("ID"))
		{
			theComboBoxDataSource_LostTarget.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_LostTarget.Columns.Contains("Description"))
		{
			theComboBoxDataSource_LostTarget.Columns.Add("Description", typeof(string));
		}
		if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && IsBOLCapable)
		{
			theComboBoxDataSource_LostTarget.Rows.Add(0, "BOL on last known coordinate");
		}
		else
		{
			theComboBoxDataSource_LostTarget.Rows.Add(0, "Expend ordnance on last known coordinate");
		}
		switch (TargetWaypoint_Lead.TargeteeringMethod)
		{
		case Mission._TargeteeringMethod.Mission:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && IsBOLCapable)
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in mission's target list if possible, otherwise BOL on last known coordinate");
			}
			else
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in mission's target list if possible, otherwise expend ordnance on last known coordinate");
			}
			break;
		case Mission._TargeteeringMethod.Flight:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && IsBOLCapable)
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in flight's target list if possible, otherwise BOL on last known coordinate");
			}
			else
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in flight's target list if possible, otherwise expend ordnance on last known coordinate");
			}
			break;
		case Mission._TargeteeringMethod.Individual:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && IsBOLCapable)
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in aircraft's target list if possible, otherwise BOL on last known coordinate");
			}
			else
			{
				theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in aircraft's target list if possible, otherwise expend ordnance on last known coordinate");
			}
			break;
		}
		theComboBoxDataSource_LostTarget.Rows.Add(2, "Bring back og jettison ordnance depending on mission setting");
		switch (TargetWaypoint_Lead.TargeteeringMethod)
		{
		case Mission._TargeteeringMethod.Mission:
			theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in mission's target list if possible, otherwise bring back og jettison ordnance depending on mission setting");
			break;
		case Mission._TargeteeringMethod.Flight:
			theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in flight's target list if possible, otherwise bring back og jettison ordnance depending on mission setting");
			break;
		case Mission._TargeteeringMethod.Individual:
			theComboBoxDataSource_LostTarget.Rows.Add(1, "Find new target in aircraft's target list if possible, otherwise bring back og jettison ordnance depending on mission setting");
			break;
		}
	}

	public static WeaponeeringLostTargetSelection LostTargetSelection_To_LostTarget(object LostTarget)
	{
		WeaponeeringLostTargetSelection result;
		try
		{
			result = Conversions.ToInteger(LostTarget) switch
			{
				0 => WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate, 
				1 => WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseExpendOrdnanceOnCoordinate, 
				2 => WeaponeeringLostTargetSelection.BringBackOrJettisonOrdnance, 
				3 => WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseBringBackOrJettisonOrdnance, 
				_ => WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (WeaponeeringLostTargetSelection)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int LostTarget_To_LostTargetSelection(WeaponeeringLostTargetSelection LostTarget)
	{
		int result;
		try
		{
			result = (int)LostTarget switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ComboBoxDataSource_Target(ref DataTable theComboBoxDataSource_Target, int theComboBoxValue, ref TList<Mission.TargeteeringEntry> theTargeteeringEntries)
	{
		if (!theComboBoxDataSource_Target.Columns.Contains("ID"))
		{
			theComboBoxDataSource_Target.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_Target.Columns.Contains("Description"))
		{
			theComboBoxDataSource_Target.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_Target.Rows.Add(0, "No target selected (weapon will not be used)");
		if (!Information.IsNothing((object)theTargeteeringEntries) && theTargeteeringEntries.Count != 0)
		{
			int num = theTargeteeringEntries.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Mission.TargeteeringEntry targeteeringEntry = theTargeteeringEntries[i];
				theComboBoxDataSource_Target.Rows.Add(i + 1, targeteeringEntry.Target_Description);
			}
		}
	}

	public static Mission.TargeteeringEntry TargetSelection_To_Target(object Target, ref TList<Mission.TargeteeringEntry> theTargeteeringEntries)
	{
		Mission.TargeteeringEntry result;
		try
		{
			int num = (int)Target;
			result = ((num == 0) ? null : ((theTargeteeringEntries.Count < num) ? null : theTargeteeringEntries[num - 1]));
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
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int Target_To_TargetSelection(string theTargeteeringEntryObjectID, ref WriteLockedList<Mission.TargeteeringEntry> theTargeteeringEntries)
	{
		int result;
		try
		{
			int num;
			if (theTargeteeringEntries == null)
			{
				num = 0;
				goto IL_0012;
			}
			if (theTargeteeringEntries.Count == 0)
			{
				num = 0;
				goto IL_0012;
			}
			int num2 = theTargeteeringEntries.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (Operators.CompareString(theTargeteeringEntries[num3].ObjectID, theTargeteeringEntryObjectID, true) != 0)
					{
						num3++;
						continue;
					}
					result = num3 + 1;
					break;
				}
				result = 0;
				break;
			}
			goto end_IL_0001;
			IL_0012:
			result = num;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ComboBoxDataSource_FiringRange(ref DataTable theComboBoxDataSource_FiringRange, float MaxRange, float MinRange, int theComboBoxValue)
	{
		if (!theComboBoxDataSource_FiringRange.Columns.Contains("ID"))
		{
			theComboBoxDataSource_FiringRange.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_FiringRange.Columns.Contains("Description"))
		{
			theComboBoxDataSource_FiringRange.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_FiringRange.Rows.Add(0, "Max Range");
		if (MaxRange > 2f && MinRange < 2f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(1, " 2 nm");
		}
		if (MaxRange > 5f && MinRange < 5f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(2, " 5 nm");
		}
		if (MaxRange > 10f && MinRange < 10f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(3, "10 nm");
		}
		if (MaxRange > 15f && MinRange < 15f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(4, "15 nm");
		}
		if (MaxRange > 20f && MinRange < 20f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(5, "20 nm");
		}
		if (MaxRange > 25f && MinRange < 25f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(6, "25 nm");
		}
		if (MaxRange > 30f && MinRange < 30f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(7, "30 nm");
		}
		if (MaxRange > 35f && MinRange < 35f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(8, "35 nm");
		}
		if (MaxRange > 40f && MinRange < 40f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(9, "40 nm");
		}
		if (MaxRange > 45f && MinRange < 45f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(10, "45 nm");
		}
		if (MaxRange > 50f && MinRange < 50f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(11, "50 nm");
		}
		if (MaxRange > 60f && MinRange < 60f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(12, "60 nm");
		}
		if (MaxRange > 70f && MinRange < 70f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(13, "70 nm");
		}
		if (MaxRange > 80f && MinRange < 80f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(14, "80 nm");
		}
		if (MaxRange > 90f && MinRange < 90f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(15, "90 nm");
		}
		if (MaxRange > 100f && MinRange < 100f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(16, "100 nm");
		}
		if (MaxRange > 125f && MinRange < 125f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(17, "125 nm");
		}
		if (MaxRange > 150f && MinRange < 150f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(18, "150 nm");
		}
		if (MaxRange > 175f && MinRange < 175f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(19, "175 nm");
		}
		if (MaxRange > 200f && MinRange < 200f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(20, "200 nm");
		}
		if (MaxRange > 250f && MinRange < 250f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(21, "250 nm");
		}
		if (MaxRange > 300f && MinRange < 300f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(22, "300 nm");
		}
		if (MaxRange > 500f && MinRange < 500f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(23, "500 nm");
		}
		if (MaxRange > 750f && MinRange < 750f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(24, "750 nm");
		}
		if (MaxRange > 1000f && MinRange < 1000f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(25, "1000 nm");
		}
		if (MaxRange > 1500f && MinRange < 1500f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(26, "1500 nm");
		}
		if (MaxRange > 2000f && MinRange < 2000f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(27, "2000 nm");
		}
	}

	public static int FiringRangeSelection_To_FiringRange(object FiringRange)
	{
		int result;
		try
		{
			result = Conversions.ToInteger(FiringRange) switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				7 => 7, 
				8 => 8, 
				9 => 9, 
				10 => 10, 
				11 => 11, 
				12 => 12, 
				13 => 13, 
				14 => 14, 
				15 => 15, 
				16 => 16, 
				17 => 17, 
				18 => 18, 
				19 => 19, 
				20 => 20, 
				21 => 21, 
				22 => 22, 
				23 => 23, 
				24 => 24, 
				25 => 25, 
				26 => 26, 
				27 => 27, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int FiringRange_To_FiringRangeSelection(int FiringRange)
	{
		int result;
		try
		{
			result = FiringRange switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				7 => 7, 
				8 => 8, 
				9 => 9, 
				10 => 10, 
				11 => 11, 
				12 => 12, 
				13 => 13, 
				14 => 14, 
				15 => 15, 
				16 => 16, 
				17 => 17, 
				18 => 18, 
				19 => 19, 
				20 => 20, 
				21 => 21, 
				22 => 22, 
				23 => 23, 
				24 => 24, 
				25 => 25, 
				26 => 26, 
				27 => 27, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ComboBoxDataSource_TargeteeringMethod(ref DataTable theComboBoxDataSource_TargeteeringTarget, Mission.MissionCategory theMissionCategory)
	{
		if (!theComboBoxDataSource_TargeteeringTarget.Columns.Contains("ID"))
		{
			theComboBoxDataSource_TargeteeringTarget.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_TargeteeringTarget.Columns.Contains("Description"))
		{
			theComboBoxDataSource_TargeteeringTarget.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_TargeteeringTarget.Rows.Add(0, FlightPlanEditorTargets.get_TargeteeringMethodtring(Mission._TargeteeringMethod.Mission, theMissionCategory));
		theComboBoxDataSource_TargeteeringTarget.Rows.Add(1, FlightPlanEditorTargets.get_TargeteeringMethodtring(Mission._TargeteeringMethod.Flight, theMissionCategory));
		theComboBoxDataSource_TargeteeringTarget.Rows.Add(2, FlightPlanEditorTargets.get_TargeteeringMethodtring(Mission._TargeteeringMethod.Individual, theMissionCategory));
	}

	public static Mission._TargeteeringMethod TargeteeringMethodSelection_To_TargeteeringMethod(int TargeteeringTarget)
	{
		Mission._TargeteeringMethod result;
		try
		{
			result = TargeteeringTarget switch
			{
				0 => Mission._TargeteeringMethod.Mission, 
				1 => Mission._TargeteeringMethod.Flight, 
				2 => Mission._TargeteeringMethod.Individual, 
				_ => Mission._TargeteeringMethod.Mission, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (Mission._TargeteeringMethod)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int TargeteeringMethod_To_TargeteeringMethodSelection(int TargeteeringTarget)
	{
		int result;
		try
		{
			result = TargeteeringTarget switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void FlightPlanEditorTargets_KeyDown(object sender, KeyEventArgs e)
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

	private void method_26()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedFlight) && !Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)IPWaypoint_Lead) && !Information.IsNothing((object)TargetWaypoint_Lead))
			{
				switch (TargetWaypoint_Lead.TargeteeringMethod)
				{
				case Mission._TargeteeringMethod.Mission:
					((Control)ComboBox_TargteeringMethod).Enabled = true;
					Button_AddHighlighted.Enabled = false;
					Button_RemoveSelected.Enabled = false;
					Button_AddPreliminaryTargetLocation.Enabled = false;
					Button_EditPreliminaryTargetLocation.Enabled = false;
					Button_AddCoordinate.Enabled = false;
					Button_EditCoordinate.Enabled = false;
					Button_AddArea.Enabled = false;
					Button_EditArea.Enabled = false;
					Button_EditToT.Enabled = false;
					Button_IncreasePriority.Enabled = false;
					Button_DecreasePriority.Enabled = false;
					((Control)CB_PreplannedOnly).Enabled = false;
					Button_EditWRA.Enabled = false;
					Button_EditRoute.Enabled = false;
					Button_SetTimeReferenceWeapon.Enabled = false;
					break;
				case Mission._TargeteeringMethod.Flight:
					((Control)ComboBox_TargteeringMethod).Enabled = true;
					Button_AddHighlighted.Enabled = true;
					Button_RemoveSelected.Enabled = true;
					Button_AddPreliminaryTargetLocation.Enabled = false;
					Button_EditPreliminaryTargetLocation.Enabled = false;
					Button_AddCoordinate.Enabled = false;
					Button_EditCoordinate.Enabled = false;
					Button_AddArea.Enabled = false;
					Button_EditArea.Enabled = false;
					Button_EditToT.Enabled = false;
					Button_IncreasePriority.Enabled = false;
					Button_DecreasePriority.Enabled = false;
					((Control)CB_PreplannedOnly).Enabled = false;
					Button_EditWRA.Enabled = false;
					Button_EditRoute.Enabled = false;
					Button_SetTimeReferenceWeapon.Enabled = false;
					break;
				case Mission._TargeteeringMethod.Individual:
				{
					((Control)ComboBox_TargteeringMethod).Enabled = true;
					Button_AddHighlighted.Enabled = true;
					Button_RemoveSelected.Enabled = true;
					Button_AddPreliminaryTargetLocation.Enabled = true;
					Button_EditPreliminaryTargetLocation.Enabled = true;
					Button_AddCoordinate.Enabled = true;
					Button_EditCoordinate.Enabled = true;
					Button_AddArea.Enabled = true;
					Button_EditArea.Enabled = true;
					Button_EditToT.Enabled = true;
					Button_IncreasePriority.Enabled = true;
					Button_DecreasePriority.Enabled = true;
					((Control)CB_PreplannedOnly).Enabled = true;
					Button_EditWRA.Enabled = true;
					if (((BaseCollection)((DataGridView)TGV_Weaponeering).SelectedRows).Count <= 0)
					{
						break;
					}
					string text = "";
					TreeGridNode treeGridNode = default(TreeGridNode);
					bool flag = default(bool);
					foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
					{
						foreach (TreeGridNode node2 in node.Nodes)
						{
							if (((DataGridViewRow)node2).Selected)
							{
								text = (string)((DataGridViewBand)node).Tag;
								treeGridNode = node2;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (!Information.IsNothing((object)treeGridNode) && !Information.IsNothing((object)treeGridNode.Parent))
					{
						Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)treeGridNode).Tag;
						if (Information.IsNothing((object)weaponeeringEntry))
						{
							Button_EditRoute.Enabled = false;
							Button_SetTimeReferenceWeapon.Enabled = false;
							break;
						}
						if (!Information.IsNothing((object)weaponeeringEntry.Route))
						{
							Button_EditRoute.Enabled = true;
						}
						else
						{
							Button_EditRoute.Enabled = false;
						}
						if (TargetWaypoint_Lead.FlightFormation == Waypoint.Formation.Split)
						{
							Button_SetTimeReferenceWeapon.Enabled = true;
							break;
						}
						Mission.Flight.FlightElement flightElement = ((Operators.CompareString(text, "Aircraft #1", true) == 0) ? Mission.Flight.FlightElement.LeadElement : ((Operators.CompareString(text, "Aircraft #2", true) == 0) ? Mission.Flight.FlightElement.LeadElementWingman : ((Operators.CompareString(text, "Aircraft #3", true) == 0) ? Mission.Flight.FlightElement.SecondElement : ((Operators.CompareString(text, "Aircraft #4", true) == 0) ? Mission.Flight.FlightElement.SecondElementWingman : ((Operators.CompareString(text, "Aircraft #5", true) == 0) ? Mission.Flight.FlightElement.ThirdElement : ((Operators.CompareString(text, "Aircraft #6", true) != 0) ? Mission.Flight.FlightElement.LeadElement : Mission.Flight.FlightElement.ThirdElementWingman))))));
						if (flightElement == Mission.Flight.FlightElement.LeadElement)
						{
							Button_SetTimeReferenceWeapon.Enabled = true;
						}
						else
						{
							Button_SetTimeReferenceWeapon.Enabled = false;
						}
					}
					else
					{
						Button_EditRoute.Enabled = false;
						Button_SetTimeReferenceWeapon.Enabled = false;
					}
					break;
				}
				}
			}
			else
			{
				((Control)ComboBox_TargteeringMethod).Enabled = false;
				Button_AddHighlighted.Enabled = false;
				Button_RemoveSelected.Enabled = false;
				Button_AddPreliminaryTargetLocation.Enabled = false;
				Button_EditPreliminaryTargetLocation.Enabled = false;
				Button_AddCoordinate.Enabled = false;
				Button_EditCoordinate.Enabled = false;
				Button_AddArea.Enabled = false;
				Button_EditArea.Enabled = false;
				Button_EditToT.Enabled = false;
				Button_IncreasePriority.Enabled = false;
				Button_DecreasePriority.Enabled = false;
				((Control)CB_PreplannedOnly).Enabled = false;
				Button_EditWRA.Enabled = false;
				Button_EditRoute.Enabled = false;
				Button_SetTimeReferenceWeapon.Enabled = false;
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
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		TreeGridNode treeGridNode = default(TreeGridNode);
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			if (((DataGridViewRow)node).Selected)
			{
				return;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					treeGridNode = node2;
				}
			}
		}
		if (Information.IsNothing((object)treeGridNode))
		{
			return;
		}
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)treeGridNode).Tag;
		if (!Information.IsNothing((object)weaponeeringEntry))
		{
			if (Information.IsNothing((object)weaponeeringEntry.Route))
			{
				Interaction.MsgBox((object)"Weapon route does not exist!", (MsgBoxStyle)0, (object)null);
			}
			Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute = weaponeeringEntry.Route;
			FlightPlanEditorWeaponRoute flightPlanEditorWeaponRouteWindow = Client.FlightPlanEditorWeaponRouteWindow;
			Scenario theScen = Client.CurrentScenario;
			flightPlanEditorWeaponRouteWindow.SelectedWeapon = Weapon.GetNewWeapon(ref theScen, weaponeeringEntry.int_0, bool_5: false);
			if (!((Control)Client.FlightPlanEditorWeaponRouteWindow).Visible)
			{
				((Control)Client.FlightPlanEditorWeaponRouteWindow).Show();
				return;
			}
			Client.FlightPlanEditorWeaponRouteWindow.ReloadWindow();
			((Control)Client.FlightPlanEditorWeaponRouteWindow).BringToFront();
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)TGV_Weaponeering).SelectedRows).Count <= 0)
		{
			return;
		}
		string text = "";
		TreeGridNode treeGridNode = default(TreeGridNode);
		bool flag = default(bool);
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (((DataGridViewRow)node2).Selected)
				{
					text = (string)((DataGridViewBand)node).Tag;
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (Information.IsNothing((object)treeGridNode) || Information.IsNothing((object)treeGridNode.Parent))
		{
			return;
		}
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)((DataGridViewBand)treeGridNode).Tag;
		if (Information.IsNothing((object)weaponeeringEntry))
		{
			return;
		}
		if (Operators.CompareString(text, "Aircraft #1", true) == 0 && !Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList))
		{
			foreach (Mission.WeaponeeringEntry weaponeering in TargetWaypoint_Lead.WeaponeeringList)
			{
				if (weaponeering == weaponeeringEntry)
				{
					weaponeering.IsRouteReference = true;
				}
				else
				{
					weaponeering.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(text, "Aircraft #2", true) == 0 && !Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman))
		{
			foreach (Mission.WeaponeeringEntry item in TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman)
			{
				if (item == weaponeeringEntry)
				{
					item.IsRouteReference = true;
				}
				else
				{
					item.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(text, "Aircraft #3", true) == 0 && !Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList_SecondElement))
		{
			foreach (Mission.WeaponeeringEntry item2 in TargetWaypoint_Lead.WeaponeeringList_SecondElement)
			{
				if (item2 == weaponeeringEntry)
				{
					item2.IsRouteReference = true;
				}
				else
				{
					item2.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(text, "Aircraft #4", true) == 0 && !Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman))
		{
			foreach (Mission.WeaponeeringEntry item3 in TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman)
			{
				if (item3 == weaponeeringEntry)
				{
					item3.IsRouteReference = true;
				}
				else
				{
					item3.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(text, "Aircraft #5", true) == 0 && !Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList_ThirdElement))
		{
			foreach (Mission.WeaponeeringEntry item4 in TargetWaypoint_Lead.WeaponeeringList_ThirdElement)
			{
				if (item4 == weaponeeringEntry)
				{
					item4.IsRouteReference = true;
				}
				else
				{
					item4.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(text, "Aircraft #6", true) != 0 || Information.IsNothing((object)TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman))
		{
			foreach (Mission.WeaponeeringEntry weaponeering2 in TargetWaypoint_Lead.WeaponeeringList)
			{
				weaponeering2.IsRouteReference = false;
			}
		}
		else
		{
			foreach (Mission.WeaponeeringEntry item5 in TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman)
			{
				if (item5 == weaponeeringEntry)
				{
					item5.IsRouteReference = true;
				}
				else
				{
					item5.IsRouteReference = false;
				}
			}
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
		LoadGrid(TargeteeringExpandAllNodes: false, WeaponeeringExpandAllNodes: false);
	}

	static FlightPlanEditorTargets()
	{
		Class72.smethod_20();
	}
}
