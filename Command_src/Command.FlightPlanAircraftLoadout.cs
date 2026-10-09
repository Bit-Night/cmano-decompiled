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
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanAircraftLoadout : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox_AircraftTypes")]
	private DarkListView _ListBox_AircraftTypes;

	[AccessedThroughProperty("ListBox_Loadouts")]
	[CompilerGenerated]
	private DarkListView _ListBox_Loadouts;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox_AssignedAircraft")]
	private DarkListView _ListBox_AssignedAircraft;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_FlightplanType")]
	private DarkUIComboBox _ComboBox_FlightplanType;

	[AccessedThroughProperty("TextBox18")]
	[CompilerGenerated]
	private DarkUITextBox darkUITextBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_StationAltitude")]
	private DarkUITextBox TqfHdadYpgI;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearSlots")]
	private DarkUIButton _Button_ClearSlots;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_FillEmptySlots")]
	private DarkUIButton _Button_FillEmptySlots;

	[CompilerGenerated]
	[AccessedThroughProperty("Label23")]
	private DarkLabel qMoHdUoTuu2;

	[AccessedThroughProperty("Button_ChangeTakeOffLocation")]
	[CompilerGenerated]
	private DarkUIButton _Button_ChangeTakeOffLocation;

	[AccessedThroughProperty("TxtDesiredSize")]
	[CompilerGenerated]
	private DarkUITextBox _TxtDesiredSize;

	[CompilerGenerated]
	[AccessedThroughProperty("TxtMinimumSize")]
	private DarkUITextBox _TxtMinimumSize;

	[AccessedThroughProperty("Button_Change_Landing_location")]
	[CompilerGenerated]
	private DarkUIButton _Button_Change_Landing_location;

	[CompilerGenerated]
	private bool bool_2;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public bool SelectedAircraftChanged;

	public bool SelectedLoadoutChanged;

	public bool SelectedAssignedAircraftChanged;

	internal virtual DarkListView ListBox_AircraftTypes
	{
		[CompilerGenerated]
		get
		{
			return _ListBox_AircraftTypes;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_12;
			MouseEventHandler val = new MouseEventHandler(method_14);
			DarkListView darkListView = _ListBox_AircraftTypes;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).MouseDown -= val;
			}
			_ListBox_AircraftTypes = value;
			darkListView = _ListBox_AircraftTypes;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).MouseDown += val;
			}
		}
	}

	internal virtual DarkListView ListBox_Loadouts
	{
		[CompilerGenerated]
		get
		{
			return _ListBox_Loadouts;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_13;
			MouseEventHandler val = new MouseEventHandler(method_15);
			DarkListView darkListView = _ListBox_Loadouts;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).MouseDown -= val;
			}
			_ListBox_Loadouts = value;
			darkListView = _ListBox_Loadouts;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).MouseDown += val;
			}
		}
	}

	internal virtual DarkListView ListBox_AssignedAircraft
	{
		[CompilerGenerated]
		get
		{
			return _ListBox_AssignedAircraft;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_16;
			MouseEventHandler val = new MouseEventHandler(method_17);
			DarkListView darkListView = _ListBox_AssignedAircraft;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).MouseDown -= val;
			}
			_ListBox_AssignedAircraft = value;
			darkListView = _ListBox_AssignedAircraft;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).MouseDown += val;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_FlightplanType
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_FlightplanType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _ComboBox_FlightplanType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_FlightplanType = value;
			darkUIComboBox = _ComboBox_FlightplanType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox_FormUpTime")]
	internal virtual DarkUITextBox TextBox_FormUpTime { get; set; }

	[field: AccessedThroughProperty("SplitContainer3")]
	internal virtual SplitContainer SplitContainer3 { get; set; }

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

	[field: AccessedThroughProperty("SplitContainer2")]
	internal virtual SplitContainer SplitContainer2 { get; set; }

	[field: AccessedThroughProperty("TextBox_ReserveLoiterAltitude")]
	internal virtual DarkUITextBox TextBox_ReserveLoiterAltitude { get; set; }

	internal virtual DarkUITextBox TextBox18
	{
		[CompilerGenerated]
		get
		{
			return darkUITextBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkUITextBox_0 = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_ReservePercetage")]
	internal virtual DarkUITextBox TextBox_ReservePercetage { get; set; }

	[field: AccessedThroughProperty("TextBox_CombatDuration")]
	internal virtual DarkUITextBox TextBox_CombatDuration { get; set; }

	[field: AccessedThroughProperty("TextBox_CombatAltitude")]
	internal virtual DarkUITextBox TextBox_CombatAltitude { get; set; }

	internal virtual DarkUITextBox TextBox_StationAltitude
	{
		[CompilerGenerated]
		get
		{
			return TqfHdadYpgI;
		}
		[CompilerGenerated]
		set
		{
			TqfHdadYpgI = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_AttackEgressAltitude")]
	internal virtual DarkUITextBox TextBox_AttackEgressAltitude { get; set; }

	[field: AccessedThroughProperty("AttackEgressDistance")]
	internal virtual DarkUITextBox AttackEgressDistance { get; set; }

	[field: AccessedThroughProperty("TextBox_AttackIngressAltitude")]
	internal virtual DarkUITextBox TextBox_AttackIngressAltitude { get; set; }

	[field: AccessedThroughProperty("TextBox_AttackIngressDistance")]
	internal virtual DarkUITextBox TextBox_AttackIngressDistance { get; set; }

	[field: AccessedThroughProperty("CB_CruiseEgressAltitude")]
	internal virtual DarkUITextBox CB_CruiseEgressAltitude { get; set; }

	[field: AccessedThroughProperty("TextBox_CruiseIngressAltitude")]
	internal virtual DarkUITextBox TextBox_CruiseIngressAltitude { get; set; }

	[field: AccessedThroughProperty("TextBox_FormUpAltitude")]
	internal virtual DarkUITextBox TextBox_FormUpAltitude { get; set; }

	[field: AccessedThroughProperty("CB_StationThrottle")]
	internal virtual DarkUIComboBox CB_StationThrottle { get; set; }

	[field: AccessedThroughProperty("CB_AttackEgressThrottle")]
	internal virtual DarkUIComboBox CB_AttackEgressThrottle { get; set; }

	[field: AccessedThroughProperty("CB_AttackIngressThrottle")]
	internal virtual DarkUIComboBox CB_AttackIngressThrottle { get; set; }

	[field: AccessedThroughProperty("CB_CruiseEgressThrottle")]
	internal virtual DarkUIComboBox CB_CruiseEgressThrottle { get; set; }

	[field: AccessedThroughProperty("CB_CruiseIngressThrottle")]
	internal virtual DarkUIComboBox CB_CruiseIngressThrottle { get; set; }

	[field: AccessedThroughProperty("CB_CombatThrottle")]
	internal virtual DarkUIComboBox CB_CombatThrottle { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	internal virtual DarkUIButton Button_ClearSlots
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearSlots;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_ClearSlots;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearSlots = value;
			darkUIButton = _Button_ClearSlots;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_FillEmptySlots
	{
		[CompilerGenerated]
		get
		{
			return _Button_FillEmptySlots;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_FillEmptySlots;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_FillEmptySlots = value;
			darkUIButton = _Button_FillEmptySlots;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label19")]
	internal virtual DarkLabel Label19 { get; set; }

	[field: AccessedThroughProperty("Label18")]
	internal virtual DarkLabel Label18 { get; set; }

	[field: AccessedThroughProperty("Label15")]
	internal virtual DarkLabel Label15 { get; set; }

	[field: AccessedThroughProperty("Label17")]
	internal virtual DarkLabel Label17 { get; set; }

	[field: AccessedThroughProperty("Label12")]
	internal virtual DarkLabel Label12 { get; set; }

	[field: AccessedThroughProperty("Label14")]
	internal virtual DarkLabel Label14 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label27")]
	internal virtual DarkLabel Label27 { get; set; }

	[field: AccessedThroughProperty("Label_ReserveLoiterTime")]
	internal virtual DarkLabel Label_ReserveLoiterTime { get; set; }

	[field: AccessedThroughProperty("Label29")]
	internal virtual DarkLabel Label29 { get; set; }

	[field: AccessedThroughProperty("Label26")]
	internal virtual DarkLabel Label26 { get; set; }

	[field: AccessedThroughProperty("Label25")]
	internal virtual DarkLabel Label25 { get; set; }

	[field: AccessedThroughProperty("Label24")]
	internal virtual DarkLabel Label24 { get; set; }

	internal virtual DarkLabel Label23
	{
		[CompilerGenerated]
		get
		{
			return qMoHdUoTuu2;
		}
		[CompilerGenerated]
		set
		{
			qMoHdUoTuu2 = value;
		}
	}

	[field: AccessedThroughProperty("Label21")]
	internal virtual DarkLabel Label21 { get; set; }

	[field: AccessedThroughProperty("Label31")]
	internal virtual DarkLabel Label31 { get; set; }

	[field: AccessedThroughProperty("Label32")]
	internal virtual DarkLabel Label32 { get; set; }

	[field: AccessedThroughProperty("Label30")]
	internal virtual DarkLabel Label30 { get; set; }

	[field: AccessedThroughProperty("Label33")]
	internal virtual DarkLabel Label33 { get; set; }

	internal virtual DarkUIButton Button_ChangeTakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeTakeOffLocation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Button_ChangeTakeOffLocation;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ChangeTakeOffLocation = value;
			darkUIButton = _Button_ChangeTakeOffLocation;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label34")]
	internal virtual DarkLabel Label34 { get; set; }

	[field: AccessedThroughProperty("Label_TakeOffLocation")]
	internal virtual DarkLabel Label_TakeOffLocation { get; set; }

	[field: AccessedThroughProperty("Label35")]
	internal virtual DarkLabel Label35 { get; set; }

	[field: AccessedThroughProperty("CB_CruiseAtOptimumAltitude")]
	internal virtual DarkCheckBox CB_CruiseAtOptimumAltitude { get; set; }

	[field: AccessedThroughProperty("CB_StationTerrainFollowing")]
	internal virtual DarkCheckBox CB_StationTerrainFollowing { get; set; }

	[field: AccessedThroughProperty("CB_AttackEgressTerrainFollowing")]
	internal virtual DarkCheckBox CB_AttackEgressTerrainFollowing { get; set; }

	[field: AccessedThroughProperty("CB_AttackIngressTerrainFollowing")]
	internal virtual DarkCheckBox CB_AttackIngressTerrainFollowing { get; set; }

	[field: AccessedThroughProperty("CB_CruiseEgressTerrainFollowing")]
	internal virtual DarkCheckBox CB_CruiseEgressTerrainFollowing { get; set; }

	[field: AccessedThroughProperty("CB_CruiseIngressTerrainFollowing")]
	internal virtual DarkCheckBox CB_CruiseIngressTerrainFollowing { get; set; }

	[field: AccessedThroughProperty("CB_DropOrdnanceAtMaxRange")]
	internal virtual DarkCheckBox CB_DropOrdnanceAtMaxRange { get; set; }

	[field: AccessedThroughProperty("Label47")]
	internal virtual DarkLabel Label47 { get; set; }

	[field: AccessedThroughProperty("Label45")]
	internal virtual DarkLabel Label45 { get; set; }

	[field: AccessedThroughProperty("Label44")]
	internal virtual DarkLabel Label44 { get; set; }

	[field: AccessedThroughProperty("Label43")]
	internal virtual DarkLabel Label43 { get; set; }

	[field: AccessedThroughProperty("Label42")]
	internal virtual DarkLabel Label42 { get; set; }

	[field: AccessedThroughProperty("Label41")]
	internal virtual DarkLabel Label41 { get; set; }

	[field: AccessedThroughProperty("Label40")]
	internal virtual DarkLabel Label40 { get; set; }

	[field: AccessedThroughProperty("Label39")]
	internal virtual DarkLabel Label39 { get; set; }

	[field: AccessedThroughProperty("Label_CruiseIngressAltitude")]
	internal virtual DarkLabel Label_CruiseIngressAltitude { get; set; }

	[field: AccessedThroughProperty("Label_FormUpTime")]
	internal virtual DarkLabel Label_FormUpTime { get; set; }

	[field: AccessedThroughProperty("CB_CruiseOneWayOnly")]
	internal virtual DarkCheckBox CB_CruiseOneWayOnly { get; set; }

	[field: AccessedThroughProperty("Label_FormUpAltitude")]
	internal virtual DarkLabel Label_FormUpAltitude { get; set; }

	[field: AccessedThroughProperty("Label_PatrolTransitAltitude_Aircraft")]
	internal virtual DarkLabel Label_PatrolTransitAltitude_Aircraft { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkUITextBox TxtDesiredSize
	{
		[CompilerGenerated]
		get
		{
			return _TxtDesiredSize;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_18;
			DarkUITextBox darkUITextBox = _TxtDesiredSize;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TxtDesiredSize = value;
			darkUITextBox = _TxtDesiredSize;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUITextBox TxtMinimumSize
	{
		[CompilerGenerated]
		get
		{
			return _TxtMinimumSize;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_19;
			DarkUITextBox darkUITextBox = _TxtMinimumSize;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TxtMinimumSize = value;
			darkUITextBox = _TxtMinimumSize;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_Change_Landing_location
	{
		[CompilerGenerated]
		get
		{
			return _Button_Change_Landing_location;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _Button_Change_Landing_location;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Change_Landing_location = value;
			darkUIButton = _Button_Change_Landing_location;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("Label_LandingLocation")]
	internal virtual DarkLabel Label_LandingLocation { get; set; }

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

	public FlightPlanAircraftLoadout()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanAircraftLoadout_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(FlightPlanAircraftLoadout_FormClosed);
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanAircraftLoadout_KeyDown);
		((Control)this).VisibleChanged += FlightPlanAircraftLoadout_VisibleChanged;
		RTMPEnabled = true;
		SelectedAircraftChanged = false;
		SelectedLoadoutChanged = false;
		SelectedAssignedAircraftChanged = false;
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
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Expected O, but got Unknown
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected O, but got Unknown
		//IL_1cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb6: Expected O, but got Unknown
		//IL_1d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d51: Expected O, but got Unknown
		//IL_1de2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dec: Expected O, but got Unknown
		//IL_1f1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f29: Expected O, but got Unknown
		//IL_1fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc2: Expected O, but got Unknown
		//IL_2051: Unknown result type (might be due to invalid IL or missing references)
		//IL_205b: Expected O, but got Unknown
		//IL_20ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f4: Expected O, but got Unknown
		//IL_2183: Unknown result type (might be due to invalid IL or missing references)
		//IL_218d: Expected O, but got Unknown
		//IL_221c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2226: Expected O, but got Unknown
		//IL_2967: Unknown result type (might be due to invalid IL or missing references)
		//IL_2971: Expected O, but got Unknown
		//IL_2aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aad: Expected O, but got Unknown
		//IL_2bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be9: Expected O, but got Unknown
		//IL_2d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d25: Expected O, but got Unknown
		//IL_2e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e61: Expected O, but got Unknown
		//IL_2f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f9d: Expected O, but got Unknown
		//IL_30cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_30d9: Expected O, but got Unknown
		//IL_320b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3215: Expected O, but got Unknown
		//IL_3347: Unknown result type (might be due to invalid IL or missing references)
		//IL_3351: Expected O, but got Unknown
		//IL_3483: Unknown result type (might be due to invalid IL or missing references)
		//IL_348d: Expected O, but got Unknown
		//IL_35bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c9: Expected O, but got Unknown
		//IL_36fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3705: Expected O, but got Unknown
		//IL_3834: Unknown result type (might be due to invalid IL or missing references)
		//IL_383e: Expected O, but got Unknown
		//IL_3bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bd6: Expected O, but got Unknown
		//IL_3c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c73: Expected O, but got Unknown
		//IL_3cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_416d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4177: Expected O, but got Unknown
		//IL_41b5: Unknown result type (might be due to invalid IL or missing references)
		Label1 = new DarkLabel();
		ListBox_AircraftTypes = new DarkListView();
		ListBox_Loadouts = new DarkListView();
		ListBox_AssignedAircraft = new DarkListView();
		ComboBox_FlightplanType = new DarkUIComboBox();
		Label9 = new DarkLabel();
		Button_ClearSlots = new DarkUIButton();
		Button_FillEmptySlots = new DarkUIButton();
		TextBox_FormUpTime = new DarkUITextBox();
		Label27 = new DarkLabel();
		Label_ReserveLoiterTime = new DarkLabel();
		Label29 = new DarkLabel();
		Label26 = new DarkLabel();
		Label25 = new DarkLabel();
		Label19 = new DarkLabel();
		Label18 = new DarkLabel();
		Label15 = new DarkLabel();
		Label17 = new DarkLabel();
		Label12 = new DarkLabel();
		Label14 = new DarkLabel();
		Label8 = new DarkLabel();
		Label24 = new DarkLabel();
		Label23 = new DarkLabel();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label21 = new DarkLabel();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		SplitContainer3 = new SplitContainer();
		SplitContainer1 = new SplitContainer();
		SplitContainer2 = new SplitContainer();
		Label31 = new DarkLabel();
		Label32 = new DarkLabel();
		Label30 = new DarkLabel();
		Label4 = new DarkLabel();
		CB_StationThrottle = new DarkUIComboBox();
		CB_AttackEgressThrottle = new DarkUIComboBox();
		CB_AttackIngressThrottle = new DarkUIComboBox();
		CB_CruiseEgressThrottle = new DarkUIComboBox();
		CB_CruiseIngressThrottle = new DarkUIComboBox();
		CB_CombatThrottle = new DarkUIComboBox();
		Label47 = new DarkLabel();
		Label45 = new DarkLabel();
		Label44 = new DarkLabel();
		Label43 = new DarkLabel();
		Label42 = new DarkLabel();
		Label41 = new DarkLabel();
		Label40 = new DarkLabel();
		Label39 = new DarkLabel();
		Label_CruiseIngressAltitude = new DarkLabel();
		Label_FormUpTime = new DarkLabel();
		CB_CruiseOneWayOnly = new DarkCheckBox();
		Label_FormUpAltitude = new DarkLabel();
		Label_PatrolTransitAltitude_Aircraft = new DarkLabel();
		TextBox_ReserveLoiterAltitude = new DarkUITextBox();
		TextBox18 = new DarkUITextBox();
		TextBox_ReservePercetage = new DarkUITextBox();
		TextBox_CombatDuration = new DarkUITextBox();
		TextBox_CombatAltitude = new DarkUITextBox();
		TextBox_StationAltitude = new DarkUITextBox();
		TextBox_AttackEgressAltitude = new DarkUITextBox();
		AttackEgressDistance = new DarkUITextBox();
		TextBox_AttackIngressAltitude = new DarkUITextBox();
		TextBox_AttackIngressDistance = new DarkUITextBox();
		CB_CruiseEgressAltitude = new DarkUITextBox();
		TextBox_CruiseIngressAltitude = new DarkUITextBox();
		TextBox_FormUpAltitude = new DarkUITextBox();
		CB_CruiseAtOptimumAltitude = new DarkCheckBox();
		CB_StationTerrainFollowing = new DarkCheckBox();
		CB_AttackEgressTerrainFollowing = new DarkCheckBox();
		CB_AttackIngressTerrainFollowing = new DarkCheckBox();
		CB_CruiseEgressTerrainFollowing = new DarkCheckBox();
		CB_CruiseIngressTerrainFollowing = new DarkCheckBox();
		CB_DropOrdnanceAtMaxRange = new DarkCheckBox();
		Label33 = new DarkLabel();
		Button_ChangeTakeOffLocation = new DarkUIButton();
		Label34 = new DarkLabel();
		Label_TakeOffLocation = new DarkLabel();
		Label35 = new DarkLabel();
		Label5 = new DarkLabel();
		TxtDesiredSize = new DarkUITextBox();
		TxtMinimumSize = new DarkUITextBox();
		Button_Change_Landing_location = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		Label_LandingLocation = new DarkLabel();
		((ISupportInitialize)SplitContainer3).BeginInit();
		((Control)SplitContainer3.Panel1).SuspendLayout();
		((Control)SplitContainer3.Panel2).SuspendLayout();
		((Control)SplitContainer3).SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((ISupportInitialize)SplitContainer2).BeginInit();
		((Control)SplitContainer2.Panel1).SuspendLayout();
		((Control)SplitContainer2.Panel2).SuspendLayout();
		((Control)SplitContainer2).SuspendLayout();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 35);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(126, 25);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Form-up time:";
		((Control)ListBox_AircraftTypes).Anchor = (AnchorStyles)15;
		((Control)ListBox_AircraftTypes).Location = new Point(3, 26);
		((Control)ListBox_AircraftTypes).Name = "ListBox_AircraftTypes";
		ListBox_AircraftTypes.RelatedInfos = null;
		((Control)ListBox_AircraftTypes).Size = new Size(624, 307);
		((Control)ListBox_AircraftTypes).TabIndex = 16;
		((Control)ListBox_Loadouts).Anchor = (AnchorStyles)15;
		((Control)ListBox_Loadouts).Location = new Point(3, 26);
		((Control)ListBox_Loadouts).Name = "ListBox_Loadouts";
		ListBox_Loadouts.RelatedInfos = null;
		((Control)ListBox_Loadouts).Size = new Size(829, 307);
		((Control)ListBox_Loadouts).TabIndex = 17;
		((Control)ListBox_AssignedAircraft).Anchor = (AnchorStyles)15;
		((Control)ListBox_AssignedAircraft).Location = new Point(8, 26);
		((Control)ListBox_AssignedAircraft).Name = "ListBox_AssignedAircraft";
		ListBox_AssignedAircraft.RelatedInfos = null;
		((Control)ListBox_AssignedAircraft).Size = new Size(1441, 294);
		((Control)ListBox_AssignedAircraft).TabIndex = 18;
		((ComboBox)ComboBox_FlightplanType).BackColor = Color.Transparent;
		((ComboBox)ComboBox_FlightplanType).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_FlightplanType).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_FlightplanType).Font = new Font("Segoe UI", 7f);
		((ListControl)ComboBox_FlightplanType).FormattingEnabled = true;
		((Control)ComboBox_FlightplanType).Location = new Point(98, 6);
		((Control)ComboBox_FlightplanType).Name = "ComboBox_FlightplanType";
		((Control)ComboBox_FlightplanType).Size = new Size(184, 27);
		((Control)ComboBox_FlightplanType).TabIndex = 39;
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(3, 8);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(134, 25);
		((Control)Label9).TabIndex = 38;
		((Label)Label9).Text = "Flightplan type:";
		((Control)Button_ClearSlots).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ClearSlots).BackColor = Color.Transparent;
		((Control)Button_ClearSlots).Font = new Font("Segoe UI", 10f);
		((Control)Button_ClearSlots).ForeColor = SystemColors.Control;
		((Control)Button_ClearSlots).Location = new Point(-1, 341);
		((Control)Button_ClearSlots).Name = "Button_ClearSlots";
		((Control)Button_ClearSlots).Padding = new Padding(5);
		Button_ClearSlots.RoundRadius = 0;
		((Control)Button_ClearSlots).Size = new Size(139, 24);
		((Control)Button_ClearSlots).TabIndex = 41;
		Button_ClearSlots.Text = "Clear a/c Slots";
		((Control)Button_ClearSlots).Visible = false;
		((Control)Button_FillEmptySlots).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_FillEmptySlots).BackColor = Color.Transparent;
		((Control)Button_FillEmptySlots).Font = new Font("Segoe UI", 10f);
		((Control)Button_FillEmptySlots).ForeColor = SystemColors.Control;
		((Control)Button_FillEmptySlots).Location = new Point(139, 341);
		((Control)Button_FillEmptySlots).Name = "Button_FillEmptySlots";
		((Control)Button_FillEmptySlots).Padding = new Padding(5);
		Button_FillEmptySlots.RoundRadius = 0;
		((Control)Button_FillEmptySlots).Size = new Size(139, 24);
		((Control)Button_FillEmptySlots).TabIndex = 40;
		Button_FillEmptySlots.Text = "Fill Empty a/c Slots";
		((Control)Button_FillEmptySlots).Visible = false;
		TextBox_FormUpTime.AutoCompleteCustomSource = null;
		TextBox_FormUpTime.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_FormUpTime.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_FormUpTime).BackColor = Color.Transparent;
		TextBox_FormUpTime.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_FormUpTime).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FormUpTime.Image = null;
		TextBox_FormUpTime.Lines = null;
		((Control)TextBox_FormUpTime).Location = new Point(150, 30);
		TextBox_FormUpTime.MaxLength = 32767;
		TextBox_FormUpTime.Multiline = false;
		((Control)TextBox_FormUpTime).Name = "TextBox_FormUpTime";
		TextBox_FormUpTime.ReadOnly = false;
		TextBox_FormUpTime.ScrollBars = (ScrollBars)0;
		TextBox_FormUpTime.SelectionStart = 0;
		((Control)TextBox_FormUpTime).Size = new Size(122, 20);
		((Control)TextBox_FormUpTime).TabIndex = 43;
		TextBox_FormUpTime.TextAlign = (HorizontalAlignment)0;
		TextBox_FormUpTime.UseSystemPasswordChar = false;
		TextBox_FormUpTime.WatermarkText = "";
		Label27.AutoSize = true;
		((Control)Label27).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label27).Location = new Point(3, 614);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(218, 25);
		((Control)Label27).TabIndex = 19;
		((Label)Label27).Text = "Fuel reserve loiter altitude:";
		Label_ReserveLoiterTime.AutoSize = true;
		((Control)Label_ReserveLoiterTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ReserveLoiterTime).Location = new Point(3, 593);
		((Control)Label_ReserveLoiterTime).Name = "Label_ReserveLoiterTime";
		((Control)Label_ReserveLoiterTime).Size = new Size(194, 25);
		((Control)Label_ReserveLoiterTime).TabIndex = 18;
		((Label)Label_ReserveLoiterTime).Text = "Fuel reserve loiter time:";
		Label29.AutoSize = true;
		((Control)Label29).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label29).Location = new Point(3, 572);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(202, 25);
		((Control)Label29).TabIndex = 17;
		((Label)Label29).Text = "Fuel reserve percentage:";
		Label26.AutoSize = true;
		((Control)Label26).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label26).Location = new Point(3, 550);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(152, 25);
		((Control)Label26).TabIndex = 16;
		((Label)Label26).Text = "Combat duration:";
		Label25.AutoSize = true;
		((Control)Label25).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label25).Location = new Point(3, 530);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(143, 25);
		((Control)Label25).TabIndex = 16;
		((Label)Label25).Text = "Combat throttle:";
		Label19.AutoSize = true;
		((Control)Label19).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label19).Location = new Point(3, 337);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(192, 25);
		((Control)Label19).TabIndex = 15;
		((Label)Label19).Text = "Attack egress distance:";
		Label18.AutoSize = true;
		((Control)Label18).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label18).Location = new Point(2, 251);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(197, 25);
		((Control)Label18).TabIndex = 14;
		((Label)Label18).Text = "Attack ingress distance:";
		Label15.AutoSize = true;
		((Control)Label15).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label15).Location = new Point(2, 396);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(185, 25);
		((Control)Label15).TabIndex = 13;
		((Label)Label15).Text = "Attack egress throttle:";
		Label17.AutoSize = true;
		((Control)Label17).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label17).Location = new Point(3, 357);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(186, 25);
		((Control)Label17).TabIndex = 11;
		((Label)Label17).Text = "Attack egress altitude:";
		Label12.AutoSize = true;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(3, 315);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(190, 25);
		((Control)Label12).TabIndex = 10;
		((Label)Label12).Text = "Attack ingress throttle:";
		Label14.AutoSize = true;
		((Control)Label14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label14).Location = new Point(2, 272);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(191, 25);
		((Control)Label14).TabIndex = 8;
		((Label)Label14).Text = "Attack ingress altitude:";
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(2, 230);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(183, 25);
		((Control)Label8).TabIndex = 7;
		((Label)Label8).Text = "Cruise egress throttle:";
		Label24.AutoSize = true;
		((Control)Label24).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label24).Location = new Point(3, 508);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(144, 25);
		((Control)Label24).TabIndex = 6;
		((Label)Label24).Text = "Combat altitude:";
		Label23.AutoSize = true;
		((Control)Label23).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label23).Location = new Point(3, 486);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(134, 25);
		((Control)Label23).TabIndex = 6;
		((Label)Label23).Text = "Station throttle:";
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(2, 166);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(188, 25);
		((Control)Label7).TabIndex = 6;
		((Label)Label7).Text = "Cruise ingress throttle:";
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(2, 188);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(184, 25);
		((Control)Label6).TabIndex = 4;
		((Label)Label6).Text = "Cruise egress altitude:";
		Label21.AutoSize = true;
		((Control)Label21).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label21).Location = new Point(3, 441);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(135, 25);
		((Control)Label21).TabIndex = 2;
		((Label)Label21).Text = "Station altitude:";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(3, 120);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(189, 25);
		((Control)Label3).TabIndex = 2;
		((Label)Label3).Text = "Cruise ingress altitude:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(3, 56);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(150, 25);
		((Control)Label2).TabIndex = 1;
		((Label)Label2).Text = "Form-up altitude:";
		((Control)SplitContainer3).Anchor = (AnchorStyles)15;
		((Control)SplitContainer3).Location = new Point(4, 74);
		((Control)SplitContainer3).Name = "SplitContainer3";
		((Control)SplitContainer3.Panel1).Controls.Add((Control)(object)SplitContainer1);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label4);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_StationThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_AttackEgressThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_AttackIngressThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseEgressThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseIngressThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CombatThrottle);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label47);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label45);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label44);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label43);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label42);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label41);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label40);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label39);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label_CruiseIngressAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label_FormUpTime);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseOneWayOnly);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label_FormUpAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label_PatrolTransitAltitude_Aircraft);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_ReserveLoiterAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox18);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_ReservePercetage);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_CombatDuration);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_CombatAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_StationAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_AttackEgressAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)AttackEgressDistance);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_AttackIngressAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_AttackIngressDistance);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseEgressAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_CruiseIngressAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_FormUpAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseAtOptimumAltitude);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_StationTerrainFollowing);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_AttackEgressTerrainFollowing);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_AttackIngressTerrainFollowing);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseEgressTerrainFollowing);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_CruiseIngressTerrainFollowing);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)CB_DropOrdnanceAtMaxRange);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label33);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label27);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)TextBox_FormUpTime);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label_ReserveLoiterTime);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label29);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label26);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label1);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label25);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label2);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label24);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label3);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label19);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label21);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label18);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label15);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label6);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label17);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label12);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label7);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label23);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label14);
		((Control)SplitContainer3.Panel2).Controls.Add((Control)(object)Label8);
		((Control)SplitContainer3.Panel2).Enabled = false;
		((Control)SplitContainer3).Size = new Size(1496, 675);
		SplitContainer3.SplitterDistance = 1452;
		((Control)SplitContainer3).TabIndex = 44;
		SplitContainer1.Dock = (DockStyle)5;
		((Control)SplitContainer1).Location = new Point(0, 0);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)SplitContainer2);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Label30);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Button_ClearSlots);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)ListBox_AssignedAircraft);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Button_FillEmptySlots);
		((Control)SplitContainer1).Size = new Size(1452, 675);
		SplitContainer1.SplitterDistance = 322;
		((Control)SplitContainer1).TabIndex = 45;
		SplitContainer2.Dock = (DockStyle)5;
		((Control)SplitContainer2).Location = new Point(0, 0);
		((Control)SplitContainer2).Name = "SplitContainer2";
		((Control)SplitContainer2.Panel1).Controls.Add((Control)(object)Label31);
		((Control)SplitContainer2.Panel1).Controls.Add((Control)(object)ListBox_AircraftTypes);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)Label32);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)ListBox_Loadouts);
		((Control)SplitContainer2).Size = new Size(1452, 322);
		SplitContainer2.SplitterDistance = 613;
		((Control)SplitContainer2).TabIndex = 0;
		Label31.AutoSize = true;
		((Control)Label31).Font = new Font("Segoe UI", 12f);
		((Control)Label31).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label31).Location = new Point(3, 3);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(144, 32);
		((Control)Label31).TabIndex = 17;
		((Label)Label31).Text = "Aircraft type";
		Label32.AutoSize = true;
		((Control)Label32).Font = new Font("Segoe UI", 12f);
		((Control)Label32).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label32).Location = new Point(3, 3);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(155, 32);
		((Control)Label32).TabIndex = 18;
		((Label)Label32).Text = "Loadout type";
		Label30.AutoSize = true;
		((Control)Label30).Font = new Font("Segoe UI", 12f);
		((Control)Label30).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label30).Location = new Point(3, 3);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(190, 32);
		((Control)Label30).TabIndex = 19;
		((Label)Label30).Text = "Assigned aircraft";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(278, 590);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(42, 25);
		((Control)Label4).TabIndex = 89;
		((Label)Label4).Text = "min";
		((ComboBox)CB_StationThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_StationThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_StationThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_StationThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_StationThrottle).FormattingEnabled = true;
		((Control)CB_StationThrottle).Location = new Point(150, 480);
		((Control)CB_StationThrottle).Name = "CB_StationThrottle";
		((Control)CB_StationThrottle).Size = new Size(122, 27);
		((Control)CB_StationThrottle).TabIndex = 88;
		((ComboBox)CB_AttackEgressThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_AttackEgressThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_AttackEgressThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_AttackEgressThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_AttackEgressThrottle).FormattingEnabled = true;
		((Control)CB_AttackEgressThrottle).Location = new Point(150, 395);
		((Control)CB_AttackEgressThrottle).Name = "CB_AttackEgressThrottle";
		((Control)CB_AttackEgressThrottle).Size = new Size(122, 27);
		((Control)CB_AttackEgressThrottle).TabIndex = 87;
		((ComboBox)CB_AttackIngressThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_AttackIngressThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_AttackIngressThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_AttackIngressThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_AttackIngressThrottle).FormattingEnabled = true;
		((Control)CB_AttackIngressThrottle).Location = new Point(150, 309);
		((Control)CB_AttackIngressThrottle).Name = "CB_AttackIngressThrottle";
		((Control)CB_AttackIngressThrottle).Size = new Size(122, 27);
		((Control)CB_AttackIngressThrottle).TabIndex = 86;
		((ComboBox)CB_CruiseEgressThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_CruiseEgressThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_CruiseEgressThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CruiseEgressThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CruiseEgressThrottle).FormattingEnabled = true;
		((Control)CB_CruiseEgressThrottle).Location = new Point(149, 223);
		((Control)CB_CruiseEgressThrottle).Name = "CB_CruiseEgressThrottle";
		((Control)CB_CruiseEgressThrottle).Size = new Size(122, 27);
		((Control)CB_CruiseEgressThrottle).TabIndex = 85;
		((ComboBox)CB_CruiseIngressThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_CruiseIngressThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_CruiseIngressThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CruiseIngressThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CruiseIngressThrottle).FormattingEnabled = true;
		((Control)CB_CruiseIngressThrottle).Location = new Point(149, 160);
		((Control)CB_CruiseIngressThrottle).Name = "CB_CruiseIngressThrottle";
		((Control)CB_CruiseIngressThrottle).Size = new Size(122, 27);
		((Control)CB_CruiseIngressThrottle).TabIndex = 84;
		((ComboBox)CB_CombatThrottle).BackColor = Color.Transparent;
		((ComboBox)CB_CombatThrottle).DrawMode = (DrawMode)1;
		((ComboBox)CB_CombatThrottle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CombatThrottle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CombatThrottle).FormattingEnabled = true;
		((Control)CB_CombatThrottle).Location = new Point(150, 523);
		((Control)CB_CombatThrottle).Name = "CB_CombatThrottle";
		((Control)CB_CombatThrottle).Size = new Size(122, 27);
		((Control)CB_CombatThrottle).TabIndex = 47;
		Label47.AutoSize = true;
		((Control)Label47).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label47).Location = new Point(278, 611);
		((Control)Label47).Name = "Label47";
		((Control)Label47).Size = new Size(28, 25);
		((Control)Label47).TabIndex = 83;
		((Label)Label47).Text = "m";
		Label45.AutoSize = true;
		((Control)Label45).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label45).Location = new Point(278, 548);
		((Control)Label45).Name = "Label45";
		((Control)Label45).Size = new Size(42, 25);
		((Control)Label45).TabIndex = 81;
		((Label)Label45).Text = "min";
		Label44.AutoSize = true;
		((Control)Label44).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label44).Location = new Point(278, 506);
		((Control)Label44).Name = "Label44";
		((Control)Label44).Size = new Size(28, 25);
		((Control)Label44).TabIndex = 80;
		((Label)Label44).Text = "m";
		Label43.AutoSize = true;
		((Control)Label43).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label43).Location = new Point(278, 335);
		((Control)Label43).Name = "Label43";
		((Control)Label43).Size = new Size(38, 25);
		((Control)Label43).TabIndex = 79;
		((Label)Label43).Text = "nm";
		Label42.AutoSize = true;
		((Control)Label42).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label42).Location = new Point(278, 354);
		((Control)Label42).Name = "Label42";
		((Control)Label42).Size = new Size(28, 25);
		((Control)Label42).TabIndex = 78;
		((Label)Label42).Text = "m";
		Label41.AutoSize = true;
		((Control)Label41).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label41).Location = new Point(277, 269);
		((Control)Label41).Name = "Label41";
		((Control)Label41).Size = new Size(28, 25);
		((Control)Label41).TabIndex = 77;
		((Label)Label41).Text = "m";
		Label40.AutoSize = true;
		((Control)Label40).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label40).Location = new Point(277, 248);
		((Control)Label40).Name = "Label40";
		((Control)Label40).Size = new Size(38, 25);
		((Control)Label40).TabIndex = 76;
		((Label)Label40).Text = "nm";
		Label39.AutoSize = true;
		((Control)Label39).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label39).Location = new Point(277, 185);
		((Control)Label39).Name = "Label39";
		((Control)Label39).Size = new Size(28, 25);
		((Control)Label39).TabIndex = 75;
		((Label)Label39).Text = "m";
		Label_CruiseIngressAltitude.AutoSize = true;
		((Control)Label_CruiseIngressAltitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CruiseIngressAltitude).Location = new Point(278, 117);
		((Control)Label_CruiseIngressAltitude).Name = "Label_CruiseIngressAltitude";
		((Control)Label_CruiseIngressAltitude).Size = new Size(28, 25);
		((Control)Label_CruiseIngressAltitude).TabIndex = 74;
		((Label)Label_CruiseIngressAltitude).Text = "m";
		Label_FormUpTime.AutoSize = true;
		((Control)Label_FormUpTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_FormUpTime).Location = new Point(278, 35);
		((Control)Label_FormUpTime).Name = "Label_FormUpTime";
		((Control)Label_FormUpTime).Size = new Size(42, 25);
		((Control)Label_FormUpTime).TabIndex = 73;
		((Label)Label_FormUpTime).Text = "min";
		((ButtonBase)CB_CruiseOneWayOnly).AutoSize = true;
		((Control)CB_CruiseOneWayOnly).Location = new Point(6, 97);
		((Control)CB_CruiseOneWayOnly).Name = "CB_CruiseOneWayOnly";
		((Control)CB_CruiseOneWayOnly).Size = new Size(196, 29);
		((Control)CB_CruiseOneWayOnly).TabIndex = 72;
		((ButtonBase)CB_CruiseOneWayOnly).Text = "Cruise one way only";
		Label_FormUpAltitude.AutoSize = true;
		((Control)Label_FormUpAltitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_FormUpAltitude).Location = new Point(278, 54);
		((Control)Label_FormUpAltitude).Name = "Label_FormUpAltitude";
		((Control)Label_FormUpAltitude).Size = new Size(28, 25);
		((Control)Label_FormUpAltitude).TabIndex = 71;
		((Label)Label_FormUpAltitude).Text = "m";
		Label_PatrolTransitAltitude_Aircraft.AutoSize = true;
		((Control)Label_PatrolTransitAltitude_Aircraft).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_PatrolTransitAltitude_Aircraft).Location = new Point(278, 441);
		((Control)Label_PatrolTransitAltitude_Aircraft).Name = "Label_PatrolTransitAltitude_Aircraft";
		((Control)Label_PatrolTransitAltitude_Aircraft).Size = new Size(28, 25);
		((Control)Label_PatrolTransitAltitude_Aircraft).TabIndex = 70;
		((Label)Label_PatrolTransitAltitude_Aircraft).Text = "m";
		TextBox_ReserveLoiterAltitude.AutoCompleteCustomSource = null;
		TextBox_ReserveLoiterAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_ReserveLoiterAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_ReserveLoiterAltitude).BackColor = Color.Transparent;
		TextBox_ReserveLoiterAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_ReserveLoiterAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ReserveLoiterAltitude.Image = null;
		TextBox_ReserveLoiterAltitude.Lines = null;
		((Control)TextBox_ReserveLoiterAltitude).Location = new Point(150, 608);
		TextBox_ReserveLoiterAltitude.MaxLength = 32767;
		TextBox_ReserveLoiterAltitude.Multiline = false;
		((Control)TextBox_ReserveLoiterAltitude).Name = "TextBox_ReserveLoiterAltitude";
		TextBox_ReserveLoiterAltitude.ReadOnly = false;
		TextBox_ReserveLoiterAltitude.ScrollBars = (ScrollBars)0;
		TextBox_ReserveLoiterAltitude.SelectionStart = 0;
		((Control)TextBox_ReserveLoiterAltitude).Size = new Size(122, 20);
		((Control)TextBox_ReserveLoiterAltitude).TabIndex = 69;
		TextBox_ReserveLoiterAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_ReserveLoiterAltitude.UseSystemPasswordChar = false;
		TextBox_ReserveLoiterAltitude.WatermarkText = "";
		TextBox18.AutoCompleteCustomSource = null;
		TextBox18.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox18.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox18).BackColor = Color.Transparent;
		TextBox18.Font = new Font("Segoe UI", 8f);
		((Control)TextBox18).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox18.Image = null;
		TextBox18.Lines = null;
		((Control)TextBox18).Location = new Point(150, 587);
		TextBox18.MaxLength = 32767;
		TextBox18.Multiline = false;
		((Control)TextBox18).Name = "TextBox18";
		TextBox18.ReadOnly = false;
		TextBox18.ScrollBars = (ScrollBars)0;
		TextBox18.SelectionStart = 0;
		((Control)TextBox18).Size = new Size(122, 20);
		((Control)TextBox18).TabIndex = 68;
		TextBox18.TextAlign = (HorizontalAlignment)0;
		TextBox18.UseSystemPasswordChar = false;
		TextBox18.WatermarkText = "";
		TextBox_ReservePercetage.AutoCompleteCustomSource = null;
		TextBox_ReservePercetage.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_ReservePercetage.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_ReservePercetage).BackColor = Color.Transparent;
		TextBox_ReservePercetage.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_ReservePercetage).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ReservePercetage.Image = null;
		TextBox_ReservePercetage.Lines = null;
		((Control)TextBox_ReservePercetage).Location = new Point(150, 566);
		TextBox_ReservePercetage.MaxLength = 32767;
		TextBox_ReservePercetage.Multiline = false;
		((Control)TextBox_ReservePercetage).Name = "TextBox_ReservePercetage";
		TextBox_ReservePercetage.ReadOnly = false;
		TextBox_ReservePercetage.ScrollBars = (ScrollBars)0;
		TextBox_ReservePercetage.SelectionStart = 0;
		((Control)TextBox_ReservePercetage).Size = new Size(122, 20);
		((Control)TextBox_ReservePercetage).TabIndex = 67;
		TextBox_ReservePercetage.TextAlign = (HorizontalAlignment)0;
		TextBox_ReservePercetage.UseSystemPasswordChar = false;
		TextBox_ReservePercetage.WatermarkText = "";
		TextBox_CombatDuration.AutoCompleteCustomSource = null;
		TextBox_CombatDuration.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_CombatDuration.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_CombatDuration).BackColor = Color.Transparent;
		TextBox_CombatDuration.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_CombatDuration).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CombatDuration.Image = null;
		TextBox_CombatDuration.Lines = null;
		((Control)TextBox_CombatDuration).Location = new Point(150, 545);
		TextBox_CombatDuration.MaxLength = 32767;
		TextBox_CombatDuration.Multiline = false;
		((Control)TextBox_CombatDuration).Name = "TextBox_CombatDuration";
		TextBox_CombatDuration.ReadOnly = false;
		TextBox_CombatDuration.ScrollBars = (ScrollBars)0;
		TextBox_CombatDuration.SelectionStart = 0;
		((Control)TextBox_CombatDuration).Size = new Size(122, 20);
		((Control)TextBox_CombatDuration).TabIndex = 66;
		TextBox_CombatDuration.TextAlign = (HorizontalAlignment)0;
		TextBox_CombatDuration.UseSystemPasswordChar = false;
		TextBox_CombatDuration.WatermarkText = "";
		TextBox_CombatAltitude.AutoCompleteCustomSource = null;
		TextBox_CombatAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_CombatAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_CombatAltitude).BackColor = Color.Transparent;
		TextBox_CombatAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_CombatAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CombatAltitude.Image = null;
		TextBox_CombatAltitude.Lines = null;
		((Control)TextBox_CombatAltitude).Location = new Point(150, 502);
		TextBox_CombatAltitude.MaxLength = 32767;
		TextBox_CombatAltitude.Multiline = false;
		((Control)TextBox_CombatAltitude).Name = "TextBox_CombatAltitude";
		TextBox_CombatAltitude.ReadOnly = false;
		TextBox_CombatAltitude.ScrollBars = (ScrollBars)0;
		TextBox_CombatAltitude.SelectionStart = 0;
		((Control)TextBox_CombatAltitude).Size = new Size(122, 20);
		((Control)TextBox_CombatAltitude).TabIndex = 65;
		TextBox_CombatAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_CombatAltitude.UseSystemPasswordChar = false;
		TextBox_CombatAltitude.WatermarkText = "";
		TextBox_StationAltitude.AutoCompleteCustomSource = null;
		TextBox_StationAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_StationAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_StationAltitude).BackColor = Color.Transparent;
		TextBox_StationAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_StationAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_StationAltitude.Image = null;
		TextBox_StationAltitude.Lines = null;
		((Control)TextBox_StationAltitude).Location = new Point(150, 436);
		TextBox_StationAltitude.MaxLength = 32767;
		TextBox_StationAltitude.Multiline = false;
		((Control)TextBox_StationAltitude).Name = "TextBox_StationAltitude";
		TextBox_StationAltitude.ReadOnly = false;
		TextBox_StationAltitude.ScrollBars = (ScrollBars)0;
		TextBox_StationAltitude.SelectionStart = 0;
		((Control)TextBox_StationAltitude).Size = new Size(122, 20);
		((Control)TextBox_StationAltitude).TabIndex = 63;
		TextBox_StationAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_StationAltitude.UseSystemPasswordChar = false;
		TextBox_StationAltitude.WatermarkText = "";
		TextBox_AttackEgressAltitude.AutoCompleteCustomSource = null;
		TextBox_AttackEgressAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_AttackEgressAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_AttackEgressAltitude).BackColor = Color.Transparent;
		TextBox_AttackEgressAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_AttackEgressAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackEgressAltitude.Image = null;
		TextBox_AttackEgressAltitude.Lines = null;
		((Control)TextBox_AttackEgressAltitude).Location = new Point(150, 352);
		TextBox_AttackEgressAltitude.MaxLength = 32767;
		TextBox_AttackEgressAltitude.Multiline = false;
		((Control)TextBox_AttackEgressAltitude).Name = "TextBox_AttackEgressAltitude";
		TextBox_AttackEgressAltitude.ReadOnly = false;
		TextBox_AttackEgressAltitude.ScrollBars = (ScrollBars)0;
		TextBox_AttackEgressAltitude.SelectionStart = 0;
		((Control)TextBox_AttackEgressAltitude).Size = new Size(122, 20);
		((Control)TextBox_AttackEgressAltitude).TabIndex = 61;
		TextBox_AttackEgressAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_AttackEgressAltitude.UseSystemPasswordChar = false;
		TextBox_AttackEgressAltitude.WatermarkText = "";
		AttackEgressDistance.AutoCompleteCustomSource = null;
		AttackEgressDistance.AutoCompleteMode = (AutoCompleteMode)0;
		AttackEgressDistance.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)AttackEgressDistance).BackColor = Color.Transparent;
		AttackEgressDistance.Font = new Font("Segoe UI", 8f);
		((Control)AttackEgressDistance).ForeColor = Color.FromArgb(189, 189, 189);
		AttackEgressDistance.Image = null;
		AttackEgressDistance.Lines = null;
		((Control)AttackEgressDistance).Location = new Point(150, 331);
		AttackEgressDistance.MaxLength = 32767;
		AttackEgressDistance.Multiline = false;
		((Control)AttackEgressDistance).Name = "AttackEgressDistance";
		AttackEgressDistance.ReadOnly = false;
		AttackEgressDistance.ScrollBars = (ScrollBars)0;
		AttackEgressDistance.SelectionStart = 0;
		((Control)AttackEgressDistance).Size = new Size(122, 20);
		((Control)AttackEgressDistance).TabIndex = 60;
		AttackEgressDistance.TextAlign = (HorizontalAlignment)0;
		AttackEgressDistance.UseSystemPasswordChar = false;
		AttackEgressDistance.WatermarkText = "";
		TextBox_AttackIngressAltitude.AutoCompleteCustomSource = null;
		TextBox_AttackIngressAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_AttackIngressAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_AttackIngressAltitude).BackColor = Color.Transparent;
		TextBox_AttackIngressAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_AttackIngressAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackIngressAltitude.Image = null;
		TextBox_AttackIngressAltitude.Lines = null;
		((Control)TextBox_AttackIngressAltitude).Location = new Point(149, 266);
		TextBox_AttackIngressAltitude.MaxLength = 32767;
		TextBox_AttackIngressAltitude.Multiline = false;
		((Control)TextBox_AttackIngressAltitude).Name = "TextBox_AttackIngressAltitude";
		TextBox_AttackIngressAltitude.ReadOnly = false;
		TextBox_AttackIngressAltitude.ScrollBars = (ScrollBars)0;
		TextBox_AttackIngressAltitude.SelectionStart = 0;
		((Control)TextBox_AttackIngressAltitude).Size = new Size(122, 20);
		((Control)TextBox_AttackIngressAltitude).TabIndex = 58;
		TextBox_AttackIngressAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_AttackIngressAltitude.UseSystemPasswordChar = false;
		TextBox_AttackIngressAltitude.WatermarkText = "";
		TextBox_AttackIngressDistance.AutoCompleteCustomSource = null;
		TextBox_AttackIngressDistance.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_AttackIngressDistance.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_AttackIngressDistance).BackColor = Color.Transparent;
		TextBox_AttackIngressDistance.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_AttackIngressDistance).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackIngressDistance.Image = null;
		TextBox_AttackIngressDistance.Lines = null;
		((Control)TextBox_AttackIngressDistance).Location = new Point(149, 245);
		TextBox_AttackIngressDistance.MaxLength = 32767;
		TextBox_AttackIngressDistance.Multiline = false;
		((Control)TextBox_AttackIngressDistance).Name = "TextBox_AttackIngressDistance";
		TextBox_AttackIngressDistance.ReadOnly = false;
		TextBox_AttackIngressDistance.ScrollBars = (ScrollBars)0;
		TextBox_AttackIngressDistance.SelectionStart = 0;
		((Control)TextBox_AttackIngressDistance).Size = new Size(122, 20);
		((Control)TextBox_AttackIngressDistance).TabIndex = 57;
		TextBox_AttackIngressDistance.TextAlign = (HorizontalAlignment)0;
		TextBox_AttackIngressDistance.UseSystemPasswordChar = false;
		TextBox_AttackIngressDistance.WatermarkText = "";
		CB_CruiseEgressAltitude.AutoCompleteCustomSource = null;
		CB_CruiseEgressAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		CB_CruiseEgressAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)CB_CruiseEgressAltitude).BackColor = Color.Transparent;
		CB_CruiseEgressAltitude.Font = new Font("Segoe UI", 8f);
		((Control)CB_CruiseEgressAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		CB_CruiseEgressAltitude.Image = null;
		CB_CruiseEgressAltitude.Lines = null;
		((Control)CB_CruiseEgressAltitude).Location = new Point(149, 182);
		CB_CruiseEgressAltitude.MaxLength = 32767;
		CB_CruiseEgressAltitude.Multiline = false;
		((Control)CB_CruiseEgressAltitude).Name = "CB_CruiseEgressAltitude";
		CB_CruiseEgressAltitude.ReadOnly = false;
		CB_CruiseEgressAltitude.ScrollBars = (ScrollBars)0;
		CB_CruiseEgressAltitude.SelectionStart = 0;
		((Control)CB_CruiseEgressAltitude).Size = new Size(122, 20);
		((Control)CB_CruiseEgressAltitude).TabIndex = 55;
		CB_CruiseEgressAltitude.TextAlign = (HorizontalAlignment)0;
		CB_CruiseEgressAltitude.UseSystemPasswordChar = false;
		CB_CruiseEgressAltitude.WatermarkText = "";
		TextBox_CruiseIngressAltitude.AutoCompleteCustomSource = null;
		TextBox_CruiseIngressAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_CruiseIngressAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_CruiseIngressAltitude).BackColor = Color.Transparent;
		TextBox_CruiseIngressAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_CruiseIngressAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CruiseIngressAltitude.Image = null;
		TextBox_CruiseIngressAltitude.Lines = null;
		((Control)TextBox_CruiseIngressAltitude).Location = new Point(150, 114);
		TextBox_CruiseIngressAltitude.MaxLength = 32767;
		TextBox_CruiseIngressAltitude.Multiline = false;
		((Control)TextBox_CruiseIngressAltitude).Name = "TextBox_CruiseIngressAltitude";
		TextBox_CruiseIngressAltitude.ReadOnly = false;
		TextBox_CruiseIngressAltitude.ScrollBars = (ScrollBars)0;
		TextBox_CruiseIngressAltitude.SelectionStart = 0;
		((Control)TextBox_CruiseIngressAltitude).Size = new Size(122, 20);
		((Control)TextBox_CruiseIngressAltitude).TabIndex = 53;
		TextBox_CruiseIngressAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_CruiseIngressAltitude.UseSystemPasswordChar = false;
		TextBox_CruiseIngressAltitude.WatermarkText = "";
		TextBox_FormUpAltitude.AutoCompleteCustomSource = null;
		TextBox_FormUpAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_FormUpAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_FormUpAltitude).BackColor = Color.Transparent;
		TextBox_FormUpAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_FormUpAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FormUpAltitude.Image = null;
		TextBox_FormUpAltitude.Lines = null;
		((Control)TextBox_FormUpAltitude).Location = new Point(150, 51);
		TextBox_FormUpAltitude.MaxLength = 32767;
		TextBox_FormUpAltitude.Multiline = false;
		((Control)TextBox_FormUpAltitude).Name = "TextBox_FormUpAltitude";
		TextBox_FormUpAltitude.ReadOnly = false;
		TextBox_FormUpAltitude.ScrollBars = (ScrollBars)0;
		TextBox_FormUpAltitude.SelectionStart = 0;
		((Control)TextBox_FormUpAltitude).Size = new Size(122, 20);
		((Control)TextBox_FormUpAltitude).TabIndex = 51;
		TextBox_FormUpAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_FormUpAltitude.UseSystemPasswordChar = false;
		TextBox_FormUpAltitude.WatermarkText = "";
		((Control)CB_CruiseAtOptimumAltitude).Location = new Point(6, 75);
		((Control)CB_CruiseAtOptimumAltitude).Name = "CB_CruiseAtOptimumAltitude";
		((Control)CB_CruiseAtOptimumAltitude).Size = new Size(226, 16);
		((Control)CB_CruiseAtOptimumAltitude).TabIndex = 50;
		((ButtonBase)CB_CruiseAtOptimumAltitude).Text = "Cruise at optimum altitude";
		((ButtonBase)CB_StationTerrainFollowing).AutoSize = true;
		((Control)CB_StationTerrainFollowing).Location = new Point(6, 459);
		((Control)CB_StationTerrainFollowing).Name = "CB_StationTerrainFollowing";
		((Control)CB_StationTerrainFollowing).Size = new Size(229, 29);
		((Control)CB_StationTerrainFollowing).TabIndex = 49;
		((ButtonBase)CB_StationTerrainFollowing).Text = "Station terrain-following";
		((Control)CB_AttackEgressTerrainFollowing).Location = new Point(6, 376);
		((Control)CB_AttackEgressTerrainFollowing).Name = "CB_AttackEgressTerrainFollowing";
		((Control)CB_AttackEgressTerrainFollowing).Size = new Size(226, 17);
		((Control)CB_AttackEgressTerrainFollowing).TabIndex = 48;
		((ButtonBase)CB_AttackEgressTerrainFollowing).Text = "Attack egress terrain-following";
		((Control)CB_AttackIngressTerrainFollowing).Location = new Point(6, 290);
		((Control)CB_AttackIngressTerrainFollowing).Name = "CB_AttackIngressTerrainFollowing";
		((Control)CB_AttackIngressTerrainFollowing).Size = new Size(271, 20);
		((Control)CB_AttackIngressTerrainFollowing).TabIndex = 47;
		((ButtonBase)CB_AttackIngressTerrainFollowing).Text = "Attack ingress terrain-following";
		((Control)CB_CruiseEgressTerrainFollowing).Location = new Point(5, 206);
		((Control)CB_CruiseEgressTerrainFollowing).Name = "CB_CruiseEgressTerrainFollowing";
		((Control)CB_CruiseEgressTerrainFollowing).Size = new Size(272, 21);
		((Control)CB_CruiseEgressTerrainFollowing).TabIndex = 46;
		((ButtonBase)CB_CruiseEgressTerrainFollowing).Text = "Cruise egress terrain-following";
		((Control)CB_CruiseIngressTerrainFollowing).Location = new Point(5, 140);
		((Control)CB_CruiseIngressTerrainFollowing).Name = "CB_CruiseIngressTerrainFollowing";
		((Control)CB_CruiseIngressTerrainFollowing).Size = new Size(251, 20);
		((Control)CB_CruiseIngressTerrainFollowing).TabIndex = 45;
		((ButtonBase)CB_CruiseIngressTerrainFollowing).Text = "Cruise ingress terrain-following";
		((ButtonBase)CB_DropOrdnanceAtMaxRange).AutoSize = true;
		((Control)CB_DropOrdnanceAtMaxRange).Location = new Point(6, 414);
		((Control)CB_DropOrdnanceAtMaxRange).Name = "CB_DropOrdnanceAtMaxRange";
		((Control)CB_DropOrdnanceAtMaxRange).Size = new Size(266, 29);
		((Control)CB_DropOrdnanceAtMaxRange).TabIndex = 44;
		((ButtonBase)CB_DropOrdnanceAtMaxRange).Text = "Drop ordnance at max range";
		Label33.AutoSize = true;
		((Control)Label33).Font = new Font("Segoe UI", 12f);
		((Control)Label33).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label33).Location = new Point(21, 3);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(82, 32);
		((Control)Label33).TabIndex = 19;
		((Label)Label33).Text = "Profile";
		((ButtonBase)Button_ChangeTakeOffLocation).BackColor = Color.Transparent;
		((Control)Button_ChangeTakeOffLocation).Font = new Font("Segoe UI", 10f);
		((Control)Button_ChangeTakeOffLocation).ForeColor = SystemColors.Control;
		((Control)Button_ChangeTakeOffLocation).Location = new Point(543, 18);
		((Control)Button_ChangeTakeOffLocation).Name = "Button_ChangeTakeOffLocation";
		((Control)Button_ChangeTakeOffLocation).Padding = new Padding(5);
		Button_ChangeTakeOffLocation.RoundRadius = 0;
		((Control)Button_ChangeTakeOffLocation).Size = new Size(308, 10);
		((Control)Button_ChangeTakeOffLocation).TabIndex = 49;
		Button_ChangeTakeOffLocation.Text = "Change take-off location";
		Label34.AutoSize = true;
		((Control)Label34).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label34).Location = new Point(857, 4);
		((Control)Label34).Name = "Label34";
		((Control)Label34).Size = new Size(148, 25);
		((Control)Label34).TabIndex = 48;
		((Label)Label34).Text = "Take-off location:";
		Label_TakeOffLocation.AutoSize = true;
		((Control)Label_TakeOffLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_TakeOffLocation).Location = new Point(962, 4);
		((Control)Label_TakeOffLocation).Name = "Label_TakeOffLocation";
		((Control)Label_TakeOffLocation).Size = new Size(168, 25);
		((Control)Label_TakeOffLocation).TabIndex = 47;
		((Label)Label_TakeOffLocation).Text = "<Take-off location>";
		Label35.AutoSize = true;
		((Control)Label35).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label35).Location = new Point(302, 7);
		((Control)Label35).Name = "Label35";
		((Control)Label35).Size = new Size(156, 25);
		((Control)Label35).TabIndex = 45;
		((Label)Label35).Text = "Desired flight size:";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(302, 29);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(172, 25);
		((Control)Label5).TabIndex = 90;
		((Label)Label5).Text = "Minimum flight size:";
		TxtDesiredSize.AutoCompleteCustomSource = null;
		TxtDesiredSize.AutoCompleteMode = (AutoCompleteMode)0;
		TxtDesiredSize.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TxtDesiredSize).BackColor = Color.Transparent;
		((Control)TxtDesiredSize).ForeColor = Color.FromArgb(189, 189, 189);
		TxtDesiredSize.Image = null;
		TxtDesiredSize.Lines = null;
		((Control)TxtDesiredSize).Location = new Point(430, 6);
		TxtDesiredSize.MaxLength = 32767;
		TxtDesiredSize.Multiline = false;
		((Control)TxtDesiredSize).Name = "TxtDesiredSize";
		TxtDesiredSize.ReadOnly = false;
		TxtDesiredSize.ScrollBars = (ScrollBars)0;
		TxtDesiredSize.SelectionStart = 0;
		((Control)TxtDesiredSize).Size = new Size(93, 17);
		((Control)TxtDesiredSize).TabIndex = 91;
		TxtDesiredSize.TextAlign = (HorizontalAlignment)0;
		TxtDesiredSize.UseSystemPasswordChar = false;
		TxtDesiredSize.WatermarkText = "";
		TxtMinimumSize.AutoCompleteCustomSource = null;
		TxtMinimumSize.AutoCompleteMode = (AutoCompleteMode)0;
		TxtMinimumSize.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TxtMinimumSize).BackColor = Color.Transparent;
		((Control)TxtMinimumSize).ForeColor = Color.FromArgb(189, 189, 189);
		TxtMinimumSize.Image = null;
		TxtMinimumSize.Lines = null;
		((Control)TxtMinimumSize).Location = new Point(430, 29);
		TxtMinimumSize.MaxLength = 32767;
		TxtMinimumSize.Multiline = false;
		((Control)TxtMinimumSize).Name = "TxtMinimumSize";
		TxtMinimumSize.ReadOnly = false;
		TxtMinimumSize.ScrollBars = (ScrollBars)0;
		TxtMinimumSize.SelectionStart = 0;
		((Control)TxtMinimumSize).Size = new Size(93, 17);
		((Control)TxtMinimumSize).TabIndex = 92;
		TxtMinimumSize.TextAlign = (HorizontalAlignment)0;
		TxtMinimumSize.UseSystemPasswordChar = false;
		TxtMinimumSize.WatermarkText = "";
		((ButtonBase)Button_Change_Landing_location).BackColor = Color.Transparent;
		((Control)Button_Change_Landing_location).Font = new Font("Segoe UI", 10f);
		((Control)Button_Change_Landing_location).ForeColor = SystemColors.Control;
		((Control)Button_Change_Landing_location).Location = new Point(543, 58);
		((Control)Button_Change_Landing_location).Name = "Button_Change_Landing_location";
		((Control)Button_Change_Landing_location).Padding = new Padding(5);
		Button_Change_Landing_location.RoundRadius = 0;
		((Control)Button_Change_Landing_location).Size = new Size(308, 10);
		((Control)Button_Change_Landing_location).TabIndex = 93;
		Button_Change_Landing_location.Text = "Change landing location";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(857, 44);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(147, 25);
		((Control)DarkLabel1).TabIndex = 95;
		((Label)DarkLabel1).Text = "Landing location:";
		Label_LandingLocation.AutoSize = true;
		((Control)Label_LandingLocation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LandingLocation).Location = new Point(962, 44);
		((Control)Label_LandingLocation).Name = "Label_LandingLocation";
		((Control)Label_LandingLocation).Size = new Size(167, 25);
		((Control)Label_LandingLocation).TabIndex = 94;
		((Label)Label_LandingLocation).Text = "<Landing location>";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1497, 751);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)Label_LandingLocation);
		((Control)this).Controls.Add((Control)(object)Button_Change_Landing_location);
		((Control)this).Controls.Add((Control)(object)TxtMinimumSize);
		((Control)this).Controls.Add((Control)(object)TxtDesiredSize);
		((Control)this).Controls.Add((Control)(object)Button_ChangeTakeOffLocation);
		((Control)this).Controls.Add((Control)(object)Label34);
		((Control)this).Controls.Add((Control)(object)Label_TakeOffLocation);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label35);
		((Control)this).Controls.Add((Control)(object)ComboBox_FlightplanType);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)SplitContainer3);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(1024, 730);
		((Control)this).Name = "FlightPlanAircraftLoadout";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Select Aircraft and Loadout for flight <FlightName>";
		((Control)SplitContainer3.Panel1).ResumeLayout(false);
		((Control)SplitContainer3.Panel2).ResumeLayout(false);
		((Control)SplitContainer3.Panel2).PerformLayout();
		((ISupportInitialize)SplitContainer3).EndInit();
		((Control)SplitContainer3).ResumeLayout(false);
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).PerformLayout();
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)SplitContainer2.Panel1).ResumeLayout(false);
		((Control)SplitContainer2.Panel1).PerformLayout();
		((Control)SplitContainer2.Panel2).ResumeLayout(false);
		((Control)SplitContainer2.Panel2).PerformLayout();
		((ISupportInitialize)SplitContainer2).EndInit();
		((Control)SplitContainer2).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void FlightPlanAircraftLoadout_FormClosing(object sender, FormClosingEventArgs e)
	{
		method_18(null);
		method_19(null);
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FlightPlanAircraftLoadout_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void FlightPlanAircraftLoadout_KeyDown(object sender, KeyEventArgs e)
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

	public void ReloadWindow()
	{
		LoadWindow();
	}

	public void LoadWindow()
	{
		TxtMinimumSize.Text = SelectedFlight.MinimumAircraftQty.value.ToString();
		TxtDesiredSize.Text = SelectedFlight.DesiredAircraftQty.value.ToString();
		RefreshStats();
	}

	internal void RefreshStats()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedMission))
			{
				if (!Information.IsNothing((object)SelectedFlight))
				{
					((Form)this).Text = "Flightplan Editor for " + SelectedFlight.Callsign;
				}
				else
				{
					((Form)this).Text = "Flightplan Editor for flight <NO FLIGHT SELECTED>";
				}
				if (!Information.IsNothing((object)SelectedFlight) && SelectedMission.HasFlights())
				{
					if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
					{
						new DataTable();
						new DataTable();
						DataTable theComboBoxDataSource_Type = new DataTable();
						Mission.Flight.ComboBoxDataSource_Type(ref theComboBoxDataSource_Type);
						DarkUIComboBox comboBox_FlightplanType = ComboBox_FlightplanType;
						((ComboBox)comboBox_FlightplanType).DataSource = theComboBoxDataSource_Type;
						((ListControl)comboBox_FlightplanType).DisplayMember = "Description";
						((ListControl)comboBox_FlightplanType).ValueMember = "ID";
						((ComboBox)comboBox_FlightplanType).DropDownWidth = 500;
						((ComboBox)ComboBox_FlightplanType).SelectedIndex = Mission.Flight.Type_To_TypeSelection((int)SelectedFlight.Type);
						method_3();
						if (ListBox_AircraftTypes.Items.Count > 0)
						{
							method_4();
						}
						method_5();
						((Label)Label_TakeOffLocation).Text = SelectedFlight.TakeOffLocation_HostUnitObjectName;
						((Label)Label_LandingLocation).Text = SelectedFlight.LandingLocation_HostUnitObjectName;
					}
				}
				else
				{
					TxtDesiredSize.Text = "";
					TxtMinimumSize.Text = "";
					((ComboBox)ComboBox_FlightplanType).DataSource = null;
					((ComboBox)ComboBox_FlightplanType).Items.Clear();
					((ComboBox)ComboBox_FlightplanType).SelectedIndex = -1;
					ListBox_AircraftTypes.Items.Clear();
					ListBox_Loadouts.Items.Clear();
					ListBox_AssignedAircraft.Items.Clear();
					((Label)Label_TakeOffLocation).Text = "";
					((Label)Label_LandingLocation).Text = "";
				}
				method_2();
				SplitContainer3.Panel2.Visible = false;
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
			ex2?.Data.Add("Error at 999999", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2()
	{
		if (!Information.IsNothing((object)SelectedFlight) && SelectedFlight.Type == Mission._FlightType.Flightplan)
		{
			Button_ClearSlots.Enabled = true;
			Button_FillEmptySlots.Enabled = true;
			((Control)ListBox_AssignedAircraft).Enabled = true;
			((Control)Label30).Enabled = true;
		}
		else
		{
			Button_ClearSlots.Enabled = false;
			Button_FillEmptySlots.Enabled = false;
			((Control)ListBox_AssignedAircraft).Enabled = false;
			((Control)Label30).Enabled = false;
		}
		((Control)Button_FillEmptySlots).Visible = false;
		((Control)Button_ClearSlots).Visible = false;
	}

	private void method_3()
	{
		try
		{
			ListBox_AircraftTypes.Items.Clear();
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario);
			int count = list.Count;
			DarkListItem item = new DarkListItem
			{
				Text = "Any type",
				Tag = 0
			};
			ListBox_AircraftTypes.Items.Add(item);
			list = list.Select([SpecialName] (ActiveUnit theAC) => theAC).OrderBy([SpecialName] (ActiveUnit theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = count - 1;
			for (int num2 = 0; num2 <= num; num2++)
			{
				ActiveUnit activeUnit = list[num2];
				if (Information.IsNothing((object)activeUnit) || !activeUnit.IsAircraft)
				{
					continue;
				}
				int dBID = activeUnit.DBID;
				bool flag = false;
				int num3 = ListBox_AircraftTypes.Items.Count - 1;
				for (int num4 = 0; num4 <= num3; num4++)
				{
					object obj = ListBox_AircraftTypes.Items[num4];
					if (activeUnit.DBID == (int)((DarkListItem)obj).Tag)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					DarkListItem darkListItem = new DarkListItem();
					darkListItem.Text = activeUnit.UnitClass;
					darkListItem.Tag = dBID;
					ListBox_AircraftTypes.Items.Add(darkListItem);
				}
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num5 = ListBox_AircraftTypes.Items.Count - 1;
			int num6 = 0;
			while (true)
			{
				if (num6 <= num5)
				{
					object obj = ListBox_AircraftTypes.Items[num6];
					if (SelectedFlight.ReferenceUnit_DBID == (int)((DarkListItem)obj).Tag)
					{
						break;
					}
					num6++;
					continue;
				}
				return;
			}
			ListBox_AircraftTypes.SelectItem(0);
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

	private void method_4()
	{
		try
		{
			ListBox_Loadouts.Items.Clear();
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = "Any loadout";
			darkListItem.Tag = 0;
			ListBox_Loadouts.Items.Add(darkListItem);
			ListBox_Loadouts.SelectItem(0);
			if (SelectedFlight.ReferenceUnit_DBID == 0)
			{
				return;
			}
			List<Loadout> list = DBFunctions.LoadoutsForThisAircraft(SelectedFlight.ReferenceUnit_DBID, Client.CurrentScenario);
			int count = list.Count;
			list = list.Select([SpecialName] (Loadout theL) => theL).OrderBy([SpecialName] (Loadout theLoadO) => theLoadO.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = count - 1;
			for (int num2 = 0; num2 <= num; num2++)
			{
				Loadout loadout = list[num2];
				DarkListItem darkListItem2 = new DarkListItem();
				darkListItem2.Text = loadout.Name;
				darkListItem2.Tag = loadout.DBID;
				ListBox_Loadouts.Items.Add(darkListItem2);
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num3 = ListBox_Loadouts.Items.Count - 1;
			int num4 = 0;
			while (true)
			{
				if (num4 <= num3)
				{
					object obj = ListBox_Loadouts.Items[num4];
					if (SelectedFlight.int_1 == (int)((DarkListItem)obj).Tag)
					{
						break;
					}
					num4++;
					continue;
				}
				return;
			}
			ListBox_Loadouts.SelectItem(num4);
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

	private void method_5()
	{
		try
		{
			ListBox_AssignedAircraft.Items.Clear();
			if (SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
			{
				return;
			}
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario);
			if (SelectedMission.Category == Mission.MissionCategory.Package)
			{
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (Operators.CompareString(mission.ObjectID, SelectedMission.get_ParentTaskPoolID(Client.CurrentSide), true) != 0)
					{
						continue;
					}
					foreach (ActiveUnit item in mission.get_UnitsAssignedToTaskPool(Client.CurrentScenario))
					{
						if (item.IsAircraft && Information.IsNothing((object)item.ActiveMissionOrPackage()))
						{
							list.Add(item);
						}
					}
				}
			}
			list = list.Select([SpecialName] (ActiveUnit theAC) => theAC).OrderBy([SpecialName] (ActiveUnit theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = list.Count - 1;
			for (int num2 = 0; num2 <= num; num2++)
			{
				ActiveUnit activeUnit = list[num2];
				if (Information.IsNothing((object)activeUnit) || !activeUnit.IsAircraft || (SelectedFlight.ReferenceUnit_DBID > 0 && activeUnit.DBID != SelectedFlight.ReferenceUnit_DBID) || activeUnit.IsOperating())
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				if (Information.IsNothing((object)aircraft.Loadout) || (SelectedFlight.int_1 > 0 && aircraft.LoadoutDBID != SelectedFlight.int_1))
				{
					continue;
				}
				ActiveUnit currentHostUnit = aircraft.AirOps.CurrentHostUnit;
				if (Information.IsNothing((object)currentHostUnit) || Operators.CompareString(currentHostUnit.ObjectID, SelectedFlight.TakeOffLocation_HostUnitObjectID, true) != 0)
				{
					continue;
				}
				bool flag = false;
				if (activeUnit.Navigator.HasFlight)
				{
					if (activeUnit.Navigator.get_Flight(HierarchySearch: true) != SelectedFlight)
					{
						continue;
					}
					flag = true;
				}
				else
				{
					flag = false;
				}
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = activeUnit.Name;
				if (!flag)
				{
					darkListItem.Tag = new Tuple<bool, ActiveUnit>(item1: false, activeUnit);
				}
				else
				{
					darkListItem.Tag = new Tuple<bool, ActiveUnit>(item1: true, activeUnit);
				}
				ListBox_AssignedAircraft.Items.Add(darkListItem);
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num3 = ListBox_AssignedAircraft.Items.Count - 1;
			for (int num4 = 0; num4 <= num3; num4++)
			{
				if (((Tuple<bool, ActiveUnit>)ListBox_AssignedAircraft.Items[num4].Tag).Item1)
				{
					ListBox_AssignedAircraft.SelectItem(num4);
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

	private void FlightPlanAircraftLoadout_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			LoadWindow();
			SelectedAircraftChanged = false;
			SelectedLoadoutChanged = false;
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		Mission._FlightType flightType = Mission.Flight.TypeSelection_To_Type(((ComboBox)ComboBox_FlightplanType).SelectedIndex);
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
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
			Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			Client.FlightPlanEditorWindow.RefreshGrid();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		RefreshStats();
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			method_8();
			if (((Control)Client.FlightPlanEditorWindow).Visible)
			{
				Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
				Client.FlightPlanEditorWindow.RefreshGrid();
			}
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (((Control)Client.MissionEditorWindow).Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			RefreshStats();
		}
	}

	private void method_8()
	{
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (Client.Realtime && !Client.RealtimeAC)
			{
				Client.RealtimeTerminal.SendClearAircraftReplaceWithEmptySlots(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight);
				return;
			}
			Mission selectedMission = SelectedMission;
			Scenario theScen = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			selectedMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref SelectedFlight);
			Client.CurrentSide = theSide;
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendMissionEditorFillEmptySlots(SelectedMission, isManual: true, SelectedFlight, fillFlightsWithNoAircraftSpecified: true);
			return;
		}
		method_10();
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
			Client.FlightPlanEditorWindow.RefreshGrid();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.ReloadWindow();
		}
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		RefreshStats();
	}

	private void method_10()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedFlight.IsEscort && SelectedFlight.FlightPlan.Count() == 0)
			{
				Interaction.MsgBox((object)"Create a flightplan before assigning aircraft", (MsgBoxStyle)0, (object)null);
				return;
			}
			Mission selectedMission = SelectedMission;
			Scenario currentScenario = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			bool IsManual = true;
			selectedMission.FillEmptySlots(currentScenario, ref theSide, ref IsManual, SelectedFlight, FillFlightsWithNoAircraftSpecified: true);
			Client.CurrentSide = theSide;
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
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
		bool num = FlightPlanEditor.ValidateChangeFlightLocation(ref theScen, ref theSide, ref selectedMission, selectedFlight, ref takeOffLocation_HostUnitObjectName, ref takeOffLocation_HostUnitObjectID, ref theSelectedUnit, ref theSelectedUnits, IsTakeOffLocation: true, IsLandingLocation: false, IsDiversionLocation: false);
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
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.LoadWindow();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
		}
		RefreshStats();
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
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Invalid comparison between Unknown and I4
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			SelectedAircraftChanged = false;
		}
		else
		{
			if (!SelectedAircraftChanged)
			{
				return;
			}
			SelectedAircraftChanged = false;
			if (ListBox_AircraftTypes.SelectedIndices.Count < 0 || ListBox_AircraftTypes.SelectedItems.Count <= 0 || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
			{
				return;
			}
			bool flag = false;
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario);
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (!Information.IsNothing((object)activeUnit) && activeUnit.IsAircraft && activeUnit.DBID == SelectedFlight.ReferenceUnit_DBID && activeUnit.Navigator.HasFlight && activeUnit.Navigator.get_Flight(HierarchySearch: true) == SelectedFlight)
				{
					flag = true;
					break;
				}
			}
			if (flag && (int)Interaction.MsgBox((object)"Changing aircraft type will remove existing aircraft from the flight. Proceed?", (MsgBoxStyle)4, (object)null) == 7)
			{
				SelectedAircraftChanged = false;
				ReloadWindow();
				return;
			}
			int num2 = Conversions.ToInteger(ListBox_AircraftTypes.SelectedItems[0].Tag);
			if (SelectedFlight.ReferenceUnit_DBID != num2)
			{
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightAircraftType(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flag, num2);
				}
				else
				{
					CoreClientCode.ChangeFlightAircraftType_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flag, num2);
					if (((Control)Client.FlightPlanEditorWindow).Visible)
					{
						if (SelectedFlight.ReferenceUnit_DBID != 0)
						{
							Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: true);
							if (!Information.IsNothing((object)Client.FlightPlanEditorWindow.theFlightPlanWaypoints))
							{
								Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
							}
							Client.FlightPlanEditorWindow.RefreshGrid();
						}
						else
						{
							Client.FlightPlanEditorWindow.ReloadWindow();
						}
					}
					if (((Control)Client.AirTaskingOrderWindow).Visible)
					{
						Client.AirTaskingOrderWindow.ReloadWindow();
					}
					if (((Control)Client.MissionEditorWindow).Visible)
					{
						Client.MissionEditorWindow.RefreshAssignedUnits();
						Client.MissionEditorWindow.RefreshUnassignedUnits();
					}
					method_5();
				}
			}
			method_4();
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Invalid comparison between Unknown and I4
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedLoadoutChanged)
			{
				return;
			}
			SelectedLoadoutChanged = false;
			if (ListBox_Loadouts.SelectedIndices.Count < 0 || ListBox_Loadouts.SelectedItems.Count <= 0 || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
			{
				return;
			}
			bool flag = false;
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario);
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (!Information.IsNothing((object)activeUnit) && activeUnit.IsAircraft && activeUnit.DBID == SelectedFlight.ReferenceUnit_DBID && activeUnit.Navigator.HasFlight && activeUnit.Navigator.get_Flight(HierarchySearch: true) == SelectedFlight)
				{
					flag = true;
					break;
				}
			}
			if (flag && (int)Interaction.MsgBox((object)"Changing loadout type will remove existing aircraft from the flight. Proceed?", (MsgBoxStyle)4, (object)null) == 7)
			{
				SelectedLoadoutChanged = false;
				ReloadWindow();
				return;
			}
			object obj = ListBox_Loadouts.SelectedItems[0];
			int num2 = Conversions.ToInteger(((DarkListItem)obj).Tag);
			if (SelectedFlight.int_1 != num2)
			{
				string text = ((DarkListItem)obj).Text;
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightLoadout(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flag, num2, text);
				}
				else
				{
					CoreClientCode.ChangeFlightLoadout_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flag, num2, text);
				}
				if (((Control)Client.FlightPlanEditorWindow).Visible)
				{
					Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: true);
				}
				if (((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.ReloadWindow();
				}
				if (((Control)Client.MissionEditorWindow).Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				method_5();
			}
		}
		else
		{
			SelectedLoadoutChanged = false;
		}
	}

	private void method_14(object sender, MouseEventArgs e)
	{
		SelectedAircraftChanged = true;
	}

	private void method_15(object sender, MouseEventArgs e)
	{
		SelectedLoadoutChanged = true;
	}

	private void method_16(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedAssignedAircraftChanged)
			{
				return;
			}
			SelectedAssignedAircraftChanged = false;
			if (ListBox_AssignedAircraft.SelectedIndices.Count < 0)
			{
				if (ListBox_AssignedAircraft.SelectedItems.Count != 0)
				{
					return;
				}
				List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, Client.CurrentScenario);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit theAU = list[i];
					if (!Information.IsNothing((object)theAU) && theAU.IsAircraft && theAU.DBID == SelectedFlight.ReferenceUnit_DBID && theAU.Navigator.HasFlight && theAU.Navigator.get_Flight(HierarchySearch: true) == SelectedFlight)
					{
						if (Client.Realtime && !Client.RealtimeAC)
						{
							Client.RealtimeTerminal.SendClearAircraftReplaceWithEmptySlots(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, theAU);
							continue;
						}
						Mission selectedMission = SelectedMission;
						Scenario theScen = Client.CurrentScenario;
						selectedMission.ClearAircraft_ReplaceWithEmptySlot(ref theScen, ref SelectedFlight, ref theAU);
					}
				}
			}
			else if (SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				int num2 = ListBox_AssignedAircraft.SelectedItems.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					Tuple<bool, ActiveUnit> tuple = (Tuple<bool, ActiveUnit>)ListBox_AssignedAircraft.SelectedItems[j].Tag;
					list2.Add(tuple.Item2);
				}
				if (Client.Realtime && !Client.RealtimeAC)
				{
					Client.RealtimeTerminal.SendChangeFlightAssignedAircraft(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, list2);
				}
				else
				{
					CoreClientCode.ChangeFlightAssignedUnits_Core(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, list2);
				}
			}
		}
		else
		{
			SelectedAssignedAircraftChanged = false;
		}
	}

	private void method_17(object sender, MouseEventArgs e)
	{
		if (!Information.IsNothing((object)SelectedMission) && !Information.IsNothing((object)SelectedFlight) && SelectedFlight.get_Status(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			SelectedAssignedAircraftChanged = true;
		}
	}

	private void method_18(object object_0)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || !Versioned.IsNumeric((object)TxtDesiredSize.Text) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		int num = int.Parse(TxtDesiredSize.Text);
		Mission._FlightSize flightSize = num switch
		{
			1 => 1, 
			2 => 2, 
			3 => 3, 
			4 => 4, 
			6 => 6, 
			_ => new Mission._FlightSize(num), 
		};
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightSize(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, flightSize, SelectedFlight.MinimumAircraftQty);
			return;
		}
		Mission.Flight selectedFlight = SelectedFlight;
		Scenario theScen = Client.CurrentScenario;
		selectedFlight.ChangeDesiredFlightSize(ref theScen, ref SelectedMission, Client.CurrentSide, flightSize);
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.LoadGrid();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		RefreshStats();
		if (((Control)Client.MissionEditorWindow).Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		AMP_General.RefreshFlightPlanErrorWindow();
		Client.MustRefreshMainForm = true;
	}

	private void method_19(object object_0)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || !Versioned.IsNumeric((object)TxtMinimumSize.Text) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
		{
			return;
		}
		int num = int.Parse(TxtMinimumSize.Text);
		Mission._FlightSize flightSize = num switch
		{
			1 => 1, 
			2 => 2, 
			3 => 3, 
			4 => 4, 
			6 => 6, 
			_ => new Mission._FlightSize(num), 
		};
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendChangeFlightSize(Client.CurrentScenario, Client.CurrentSide, SelectedMission, SelectedFlight, SelectedFlight.DesiredAircraftQty, flightSize);
			return;
		}
		Mission.Flight selectedFlight = SelectedFlight;
		Scenario theScen = Client.CurrentScenario;
		selectedFlight.ChangeMinimumFlightSize(ref theScen, ref SelectedMission, Client.CurrentSide, flightSize);
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		RefreshStats();
	}

	private void method_20(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedMission) || Information.IsNothing((object)SelectedFlight) || SelectedFlight.get_Status(Client.CurrentScenario) != Mission._FlightStatus.None)
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
		bool num = FlightPlanEditor.ValidateChangeFlightLocation(ref theScen, ref theSide, ref selectedMission, selectedFlight, ref landingLocation_HostUnitObjectName, ref landingLocation_HostUnitObjectID, ref theSelectedUnit, ref theSelectedUnits, IsTakeOffLocation: false, IsLandingLocation: true, IsDiversionLocation: false);
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
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.LoadWindow();
		}
		if (((Control)Client.AirTaskingOrderWindow).Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
		}
		RefreshStats();
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
	}

	static FlightPlanAircraftLoadout()
	{
		Class72.smethod_20();
	}
}
