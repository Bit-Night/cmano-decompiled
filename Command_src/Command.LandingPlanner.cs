using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class LandingPlanner : DarkSecondaryFormBase
{
	public enum Priority
	{
		Critical,
		High,
		Medium,
		Low,
		Excluded,
		Unavailable
	}

	[DoNotPrune]
	[DoNotPruneType]
	[DoNotObfuscateType]
	private class MissionZoneComboWrapper
	{
		private LandingZoneWrapper landingZoneWrapper_0;

		public LandingZoneWrapper ID
		{
			get
			{
				return landingZoneWrapper_0;
			}
			set
			{
				landingZoneWrapper_0 = value;
			}
		}

		public string Label
		{
			get
			{
				if (!Information.IsNothing((object)landingZoneWrapper_0))
				{
					if (landingZoneWrapper_0.LandingZoneType == LandingType.Airborne)
					{
						return landingZoneWrapper_0.LandingZone.Description + " (LZ)";
					}
					if (landingZoneWrapper_0.LandingZoneType == LandingType.Amphibious)
					{
						return landingZoneWrapper_0.LandingZone.Description + " (CLZ)";
					}
					return landingZoneWrapper_0.LandingZone.Description;
				}
				return "Unallocated";
			}
			set
			{
			}
		}

		public MissionZoneComboWrapper(LandingZoneWrapper landingZoneWrapper_1)
		{
			landingZoneWrapper_0 = landingZoneWrapper_1;
		}

		static MissionZoneComboWrapper()
		{
			Class72.smethod_20();
		}
	}

	[DoNotPrune]
	[DoNotObfuscateType]
	[DoNotPruneType]
	private class UnitTransportComboboxWrapper
	{
		private ActiveUnit activeUnit_0;

		public ActiveUnit ID
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

		public string Label
		{
			get
			{
				if (Information.IsNothing((object)activeUnit_0))
				{
					return "None";
				}
				return activeUnit_0.Name;
			}
			set
			{
			}
		}

		public UnitTransportComboboxWrapper(ActiveUnit activeUnit_1)
		{
			activeUnit_0 = activeUnit_1;
		}

		static UnitTransportComboboxWrapper()
		{
			Class72.smethod_20();
		}
	}

	[DoNotObfuscateType]
	[DoNotPrune]
	[DoNotPruneType]
	private class MothershipItem
	{
		public ActiveUnit activeUnit_0;

		public string Label
		{
			get
			{
				return activeUnit_0.Name;
			}
			set
			{
			}
		}

		public ActiveUnit ID
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

		public MothershipItem(ActiveUnit activeUnit_1)
		{
			activeUnit_0 = activeUnit_1;
		}

		static MothershipItem()
		{
			Class72.smethod_20();
		}
	}

	private enum Enum5
	{

	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("ComboMothership")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboMothership;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Transports")]
	private DarkListView _LV_Transports;

	[AccessedThroughProperty("ButtonClearDGVmain")]
	[CompilerGenerated]
	private DarkUIButton darkUIButton_0;

	[AccessedThroughProperty("ButtonExportToCSV")]
	[CompilerGenerated]
	private DarkUIButton _ButtonExportToCSV;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonLoad")]
	private DarkUIButton _ButtonLoad;

	[AccessedThroughProperty("DGVMain")]
	[CompilerGenerated]
	private DataGridView _DGVMain;

	[AccessedThroughProperty("ButtonConfirmPlan")]
	[CompilerGenerated]
	private DarkUIButton _ButtonConfirmPlan;

	[AccessedThroughProperty("ComboBoxLandingType")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBoxLandingType;

	[AccessedThroughProperty("LV_MissionPrep")]
	[CompilerGenerated]
	private DarkListView _LV_MissionPrep;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonAllowTransport")]
	private DarkUIButton _ButtonAllowTransport;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonGeneratePlan")]
	private DarkUIButton _ButtonGeneratePlan;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_TransportWaveManifest")]
	private ListView _LV_TransportWaveManifest;

	[CompilerGenerated]
	[AccessedThroughProperty("Wave")]
	private ColumnHeader columnHeader_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Area")]
	private ColumnHeader columnHeader_1;

	[AccessedThroughProperty("Weight")]
	[CompilerGenerated]
	private ColumnHeader columnHeader_2;

	[CompilerGenerated]
	[AccessedThroughProperty("Crew")]
	private ColumnHeader columnHeader_3;

	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader1")]
	private ColumnHeader columnHeader_4;

	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader2")]
	private ColumnHeader columnHeader_5;

	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader3")]
	private ColumnHeader columnHeader_6;

	[AccessedThroughProperty("ColumnHeader4")]
	[CompilerGenerated]
	private ColumnHeader columnHeader_7;

	[AccessedThroughProperty("ColumnHeader5")]
	[CompilerGenerated]
	private ColumnHeader columnHeader_8;

	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader6")]
	private ColumnHeader columnHeader_9;

	[AccessedThroughProperty("ButtonToggleEditionMode")]
	[CompilerGenerated]
	private DarkUIButton _ButtonToggleEditionMode;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonProhibitTransport")]
	private DarkUIButton _ButtonProhibitTransport;

	[AccessedThroughProperty("GeneralTooltip")]
	[CompilerGenerated]
	private ToolTip toolTip_0;

	[AccessedThroughProperty("button_exportSpredsheet")]
	[CompilerGenerated]
	private DarkUIButton _button_exportSpredsheet;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonOpenExportFolder")]
	private DarkUIButton _ButtonOpenExportFolder;

	public LandingPlan LandingPlan;

	public LandingPlan_ImportWrapper LandingPlanImport;

	public Dictionary<LandingZoneWrapper, LandingZoneWrapper> AssignedZones;

	public Dictionary<ActiveUnit, Transport> AllowedTransport;

	private BindingSource bindingSource_0;

	public ActiveUnit CurrentMothership;

	private Transport transport_0;

	private TransportWave transportWave_0;

	private Dictionary<string, TransportAvailability> dictionary_0;

	public Dictionary<ActiveUnit, Transport> TransportList;

	private Dictionary<string, List<Transport>> dictionary_1;

	private Dictionary<string, LandingType> dictionary_2;

	private List<ChalkUnit> list_0;

	public Dictionary<Chalk, List<UnitLineWrapper>> ChalkContainer;

	private Dictionary<int, UnitLineWrapper> dictionary_3;

	private Enum5 enum5_0;

	private bool bool_2;

	public Dictionary<Mission, LandingType> GeneratedMissions;

	private ComboBox comboBox_0;

	public bool ForceClose;

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	internal virtual DarkUIComboBox ComboMothership
	{
		[CompilerGenerated]
		get
		{
			return _ComboMothership;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIComboBox darkUIComboBox = _ComboMothership;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboMothership = value;
			darkUIComboBox = _ComboMothership;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	internal virtual DarkListView LV_Transports
	{
		[CompilerGenerated]
		get
		{
			return _LV_Transports;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_20;
			DarkListView darkListView = _LV_Transports;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LV_Transports = value;
			darkListView = _LV_Transports;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	internal virtual DarkUIButton ButtonClearDGVmain
	{
		[CompilerGenerated]
		get
		{
			return darkUIButton_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIButton darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			darkUIButton_0 = value;
			darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonExportToCSV
	{
		[CompilerGenerated]
		get
		{
			return _ButtonExportToCSV;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkUIButton darkUIButton = _ButtonExportToCSV;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonExportToCSV = value;
			darkUIButton = _ButtonExportToCSV;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoad
	{
		[CompilerGenerated]
		get
		{
			return _ButtonLoad;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkUIButton darkUIButton = _ButtonLoad;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonLoad = value;
			darkUIButton = _ButtonLoad;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DataGridView DGVMain
	{
		[CompilerGenerated]
		get
		{
			return _DGVMain;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			EventHandler eventHandler = method_11;
			DataGridViewEditingControlShowingEventHandler val = new DataGridViewEditingControlShowingEventHandler(method_13);
			EventHandler eventHandler2 = method_26;
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_27);
			DataGridView val3 = _DGVMain;
			if (val3 != null)
			{
				val3.SelectionChanged -= eventHandler;
				val3.EditingControlShowing -= val;
				val3.CurrentCellDirtyStateChanged -= eventHandler2;
				val3.CellValueChanged -= val2;
			}
			_DGVMain = value;
			val3 = _DGVMain;
			if (val3 != null)
			{
				val3.SelectionChanged += eventHandler;
				val3.EditingControlShowing += val;
				val3.CurrentCellDirtyStateChanged += eventHandler2;
				val3.CellValueChanged += val2;
			}
		}
	}

	internal virtual DarkUIButton ButtonConfirmPlan
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirmPlan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkUIButton darkUIButton = _ButtonConfirmPlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirmPlan = value;
			darkUIButton = _ButtonConfirmPlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBoxLandingType
	{
		[CompilerGenerated]
		get
		{
			return _ComboBoxLandingType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkUIComboBox darkUIComboBox = _ComboBoxLandingType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBoxLandingType = value;
			darkUIComboBox = _ComboBoxLandingType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkListView LV_MissionPrep
	{
		[CompilerGenerated]
		get
		{
			return _LV_MissionPrep;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_19;
			EventHandler eventHandler = method_36;
			DarkListView darkListView = _LV_MissionPrep;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).Click -= eventHandler;
			}
			_LV_MissionPrep = value;
			darkListView = _LV_MissionPrep;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	[field: AccessedThroughProperty("Button5")]
	internal virtual Button Button5 { get; set; }

	[field: AccessedThroughProperty("LabelSelectedTransport")]
	internal virtual DarkLabel LabelSelectedTransport { get; set; }

	[field: AccessedThroughProperty("LabelUnitListForWave")]
	internal virtual DarkLabel LabelUnitListForWave { get; set; }

	internal virtual DarkUIButton ButtonAllowTransport
	{
		[CompilerGenerated]
		get
		{
			return _ButtonAllowTransport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _ButtonAllowTransport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonAllowTransport = value;
			darkUIButton = _ButtonAllowTransport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonGeneratePlan
	{
		[CompilerGenerated]
		get
		{
			return _ButtonGeneratePlan;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkUIButton darkUIButton = _ButtonGeneratePlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonGeneratePlan = value;
			darkUIButton = _ButtonGeneratePlan;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ListView LV_TransportWaveManifest
	{
		[CompilerGenerated]
		get
		{
			return _LV_TransportWaveManifest;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			ListView val = _LV_TransportWaveManifest;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_LV_TransportWaveManifest = value;
			val = _LV_TransportWaveManifest;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual ColumnHeader Wave
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_0;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_0 = value;
		}
	}

	internal virtual ColumnHeader Area
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_1;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_1 = value;
		}
	}

	internal virtual ColumnHeader Weight
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_2;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_2 = value;
		}
	}

	internal virtual ColumnHeader Crew
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_3;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_3 = value;
		}
	}

	[field: AccessedThroughProperty("LVUnitListInWave")]
	internal virtual ListView LVUnitListInWave { get; set; }

	internal virtual ColumnHeader ColumnHeader1
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_4;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_4 = value;
		}
	}

	internal virtual ColumnHeader ColumnHeader2
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_5;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_5 = value;
		}
	}

	internal virtual ColumnHeader ColumnHeader3
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_6;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_6 = value;
		}
	}

	internal virtual ColumnHeader ColumnHeader4
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_7;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_7 = value;
		}
	}

	internal virtual ColumnHeader ColumnHeader5
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_8;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_8 = value;
		}
	}

	internal virtual ColumnHeader ColumnHeader6
	{
		[CompilerGenerated]
		get
		{
			return columnHeader_9;
		}
		[CompilerGenerated]
		set
		{
			columnHeader_9 = value;
		}
	}

	internal virtual DarkUIButton ButtonToggleEditionMode
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggleEditionMode;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkUIButton darkUIButton = _ButtonToggleEditionMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonToggleEditionMode = value;
			darkUIButton = _ButtonToggleEditionMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_SerialIntegrity")]
	internal virtual DarkCheckBox CB_SerialIntegrity { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIButton ButtonProhibitTransport
	{
		[CompilerGenerated]
		get
		{
			return _ButtonProhibitTransport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _ButtonProhibitTransport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonProhibitTransport = value;
			darkUIButton = _ButtonProhibitTransport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ToolTip GeneralTooltip
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	internal virtual DarkUIButton button_exportSpredsheet
	{
		[CompilerGenerated]
		get
		{
			return _button_exportSpredsheet;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkUIButton darkUIButton = _button_exportSpredsheet;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_button_exportSpredsheet = value;
			darkUIButton = _button_exportSpredsheet;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox4")]
	internal virtual DarkGroupBox DarkGroupBox4 { get; set; }

	internal virtual DarkUIButton ButtonOpenExportFolder
	{
		[CompilerGenerated]
		get
		{
			return _ButtonOpenExportFolder;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkUIButton darkUIButton = _ButtonOpenExportFolder;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonOpenExportFolder = value;
			darkUIButton = _ButtonOpenExportFolder;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	private Transport CurrentTransport
	{
		get
		{
			return transport_0;
		}
		set
		{
			transportWave_0 = null;
			transport_0 = value;
		}
	}

	public LandingPlanner()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		((Form)this).Closing += [SpecialName] (object sender, CancelEventArgs e) =>
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			OperationPlannerForm_Quit(RuntimeHelpers.GetObjectValue(sender), (FormClosingEventArgs)e);
		};
		((Form)this).Load += LandingPlanner_Load;
		LandingPlan = null;
		LandingPlanImport = null;
		AssignedZones = new Dictionary<LandingZoneWrapper, LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		bindingSource_0 = new BindingSource();
		dictionary_0 = new Dictionary<string, TransportAvailability>();
		TransportList = new Dictionary<ActiveUnit, Transport>();
		dictionary_1 = new Dictionary<string, List<Transport>>();
		dictionary_2 = new Dictionary<string, LandingType>();
		list_0 = new List<ChalkUnit>();
		ChalkContainer = new Dictionary<Chalk, List<UnitLineWrapper>>();
		dictionary_3 = new Dictionary<int, UnitLineWrapper>();
		enum5_0 = (Enum5)1;
		GeneratedMissions = new Dictionary<Mission, LandingType>();
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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0809: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Expected O, but got Unknown
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected O, but got Unknown
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Expected O, but got Unknown
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Expected O, but got Unknown
		//IL_0cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc4: Expected O, but got Unknown
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1226: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cd: Expected O, but got Unknown
		//IL_1762: Unknown result type (might be due to invalid IL or missing references)
		//IL_176c: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DarkGroupBox2 = new DarkGroupBox();
		DarkGroupBox4 = new DarkGroupBox();
		ButtonOpenExportFolder = new DarkUIButton();
		ButtonExportToCSV = new DarkUIButton();
		button_exportSpredsheet = new DarkUIButton();
		ButtonLoad = new DarkUIButton();
		CB_SerialIntegrity = new DarkCheckBox();
		ButtonToggleEditionMode = new DarkUIButton();
		ButtonGeneratePlan = new DarkUIButton();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		Button5 = new Button();
		ButtonClearDGVmain = new DarkUIButton();
		DGVMain = new DataGridView();
		ButtonConfirmPlan = new DarkUIButton();
		DarkGroupBox3 = new DarkGroupBox();
		ButtonProhibitTransport = new DarkUIButton();
		LVUnitListInWave = new ListView();
		ColumnHeader1 = new ColumnHeader();
		ColumnHeader6 = new ColumnHeader();
		ColumnHeader2 = new ColumnHeader();
		ColumnHeader3 = new ColumnHeader();
		ColumnHeader4 = new ColumnHeader();
		ColumnHeader5 = new ColumnHeader();
		LV_TransportWaveManifest = new ListView();
		Wave = new ColumnHeader();
		Area = new ColumnHeader();
		Weight = new ColumnHeader();
		Crew = new ColumnHeader();
		ButtonAllowTransport = new DarkUIButton();
		LabelUnitListForWave = new DarkLabel();
		LabelSelectedTransport = new DarkLabel();
		LV_Transports = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		LV_MissionPrep = new DarkListView();
		DarkLabel7 = new DarkLabel();
		ComboMothership = new DarkUIComboBox();
		ComboBoxLandingType = new DarkUIComboBox();
		GeneralTooltip = new ToolTip(icontainer_1);
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox4).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((ISupportInitialize)DGVMain).BeginInit();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)15;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkGroupBox4);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SerialIntegrity);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonToggleEditionMode);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonGeneratePlan);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonClearDGVmain);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DGVMain);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonConfirmPlan);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(12, 200);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(1210, 441);
		((Control)DarkGroupBox2).TabIndex = 0;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Units Assignment";
		((Control)DarkGroupBox4).Anchor = (AnchorStyles)6;
		((Control)DarkGroupBox4).Controls.Add((Control)(object)ButtonOpenExportFolder);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)ButtonExportToCSV);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)button_exportSpredsheet);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)ButtonLoad);
		((Control)DarkGroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox4).Location = new Point(6, 401);
		((Control)DarkGroupBox4).Name = "DarkGroupBox4";
		((Control)DarkGroupBox4).Size = new Size(519, 34);
		((Control)DarkGroupBox4).TabIndex = 17;
		((GroupBox)DarkGroupBox4).TabStop = false;
		((ButtonBase)ButtonOpenExportFolder).BackColor = Color.Transparent;
		((Button)ButtonOpenExportFolder).DialogResult = (DialogResult)0;
		((Control)ButtonOpenExportFolder).ForeColor = SystemColors.Control;
		((Control)ButtonOpenExportFolder).Location = new Point(404, 9);
		((Control)ButtonOpenExportFolder).Name = "ButtonOpenExportFolder";
		ButtonOpenExportFolder.RoundRadius = 0;
		((Control)ButtonOpenExportFolder).Size = new Size(109, 22);
		((Control)ButtonOpenExportFolder).TabIndex = 17;
		ButtonOpenExportFolder.Text = "Open folder";
		((ButtonBase)ButtonExportToCSV).BackColor = Color.Transparent;
		((Button)ButtonExportToCSV).DialogResult = (DialogResult)0;
		((Control)ButtonExportToCSV).ForeColor = SystemColors.Control;
		((Control)ButtonExportToCSV).Location = new Point(6, 9);
		((Control)ButtonExportToCSV).Name = "ButtonExportToCSV";
		ButtonExportToCSV.RoundRadius = 0;
		((Control)ButtonExportToCSV).Size = new Size(92, 22);
		((Control)ButtonExportToCSV).TabIndex = 7;
		ButtonExportToCSV.Text = "Save to file";
		((ButtonBase)button_exportSpredsheet).BackColor = Color.Transparent;
		((Button)button_exportSpredsheet).DialogResult = (DialogResult)0;
		((Control)button_exportSpredsheet).ForeColor = SystemColors.Control;
		((Control)button_exportSpredsheet).Location = new Point(267, 9);
		((Control)button_exportSpredsheet).Name = "button_exportSpredsheet";
		button_exportSpredsheet.RoundRadius = 0;
		((Control)button_exportSpredsheet).Size = new Size(133, 22);
		((Control)button_exportSpredsheet).TabIndex = 16;
		button_exportSpredsheet.Text = "Export To Spreadsheet";
		((ButtonBase)ButtonLoad).BackColor = Color.Transparent;
		((Button)ButtonLoad).DialogResult = (DialogResult)0;
		((Control)ButtonLoad).ForeColor = SystemColors.Control;
		((Control)ButtonLoad).Location = new Point(104, 9);
		((Control)ButtonLoad).Name = "ButtonLoad";
		ButtonLoad.RoundRadius = 0;
		((Control)ButtonLoad).Size = new Size(106, 22);
		((Control)ButtonLoad).TabIndex = 6;
		ButtonLoad.Text = "Load from file";
		((Control)CB_SerialIntegrity).Anchor = (AnchorStyles)9;
		((ButtonBase)CB_SerialIntegrity).AutoSize = true;
		((CheckBox)CB_SerialIntegrity).Checked = true;
		((CheckBox)CB_SerialIntegrity).CheckState = (CheckState)1;
		((Control)CB_SerialIntegrity).Location = new Point(907, 21);
		((Control)CB_SerialIntegrity).Margin = new Padding(2, 3, 2, 3);
		((Control)CB_SerialIntegrity).Name = "CB_SerialIntegrity";
		((Control)CB_SerialIntegrity).Size = new Size(117, 17);
		((Control)CB_SerialIntegrity).TabIndex = 15;
		((ButtonBase)CB_SerialIntegrity).Text = "Keep serial integrity";
		GeneralTooltip.SetToolTip((Control)(object)CB_SerialIntegrity, "Disabling this will allow serials to be separated accross multiple transports");
		((Control)ButtonToggleEditionMode).Anchor = (AnchorStyles)9;
		((ButtonBase)ButtonToggleEditionMode).BackColor = Color.Transparent;
		((Button)ButtonToggleEditionMode).DialogResult = (DialogResult)0;
		((Control)ButtonToggleEditionMode).ForeColor = SystemColors.Control;
		((Control)ButtonToggleEditionMode).Location = new Point(1026, 14);
		((Control)ButtonToggleEditionMode).Name = "ButtonToggleEditionMode";
		ButtonToggleEditionMode.RoundRadius = 0;
		((Control)ButtonToggleEditionMode).Size = new Size(178, 31);
		((Control)ButtonToggleEditionMode).TabIndex = 14;
		ButtonToggleEditionMode.Text = "Edition Mode : Individual Units";
		((Control)ButtonGeneratePlan).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonGeneratePlan).BackColor = Color.Transparent;
		((Button)ButtonGeneratePlan).DialogResult = (DialogResult)0;
		((Control)ButtonGeneratePlan).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonGeneratePlan).ForeColor = SystemColors.Control;
		((Control)ButtonGeneratePlan).Location = new Point(698, 407);
		((Control)ButtonGeneratePlan).Name = "ButtonGeneratePlan";
		ButtonGeneratePlan.RoundRadius = 0;
		((Control)ButtonGeneratePlan).Size = new Size(157, 25);
		((Control)ButtonGeneratePlan).TabIndex = 13;
		ButtonGeneratePlan.Text = "Generate Landing Plan";
		((Control)FlowLayoutPanel3).Anchor = (AnchorStyles)13;
		((ScrollableControl)FlowLayoutPanel3).AutoScroll = true;
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button5);
		((Control)FlowLayoutPanel3).Location = new Point(9, 19);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(703, 31);
		((Control)FlowLayoutPanel3).TabIndex = 12;
		FlowLayoutPanel3.WrapContents = false;
		((ButtonBase)Button5).BackColor = Color.FromArgb(90, 63, 64);
		((ButtonBase)Button5).FlatStyle = (FlatStyle)0;
		((Control)Button5).Font = new Font("Microsoft Sans Serif", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button5).Location = new Point(3, 3);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Size = new Size(65, 23);
		((Control)Button5).TabIndex = 12;
		((ButtonBase)Button5).Text = "Unallocated";
		((ButtonBase)Button5).UseVisualStyleBackColor = false;
		((Control)Button5).Visible = false;
		((Control)ButtonClearDGVmain).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonClearDGVmain).BackColor = Color.Transparent;
		((Button)ButtonClearDGVmain).DialogResult = (DialogResult)0;
		((Control)ButtonClearDGVmain).ForeColor = SystemColors.Control;
		((Control)ButtonClearDGVmain).Location = new Point(590, 407);
		((Control)ButtonClearDGVmain).Name = "ButtonClearDGVmain";
		ButtonClearDGVmain.RoundRadius = 0;
		((Control)ButtonClearDGVmain).Size = new Size(102, 25);
		((Control)ButtonClearDGVmain).TabIndex = 8;
		ButtonClearDGVmain.Text = "Clear";
		DGVMain.AllowUserToAddRows = false;
		DGVMain.AllowUserToDeleteRows = false;
		DGVMain.AllowUserToResizeColumns = false;
		DGVMain.AllowUserToResizeRows = false;
		((Control)DGVMain).Anchor = (AnchorStyles)15;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		DGVMain.ColumnHeadersDefaultCellStyle = val;
		DGVMain.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)32;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(220, 220, 220);
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.ControlText;
		val2.WrapMode = (DataGridViewTriState)2;
		DGVMain.DefaultCellStyle = val2;
		DGVMain.EditMode = (DataGridViewEditMode)0;
		((Control)DGVMain).Location = new Point(9, 51);
		((Control)DGVMain).Name = "DGVMain";
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		DGVMain.RowHeadersDefaultCellStyle = val3;
		DGVMain.RowHeadersVisible = false;
		DGVMain.RowHeadersWidth = 62;
		DGVMain.RowTemplate.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
		DGVMain.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		DGVMain.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		((Control)DGVMain).Size = new Size(1195, 350);
		((Control)DGVMain).TabIndex = 0;
		((Control)ButtonConfirmPlan).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonConfirmPlan).BackColor = Color.Transparent;
		((Button)ButtonConfirmPlan).DialogResult = (DialogResult)0;
		((Control)ButtonConfirmPlan).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonConfirmPlan).ForeColor = SystemColors.Control;
		((Control)ButtonConfirmPlan).Location = new Point(1053, 407);
		((Control)ButtonConfirmPlan).Name = "ButtonConfirmPlan";
		ButtonConfirmPlan.RoundRadius = 0;
		((Control)ButtonConfirmPlan).Size = new Size(151, 25);
		((Control)ButtonConfirmPlan).TabIndex = 5;
		ButtonConfirmPlan.Text = "Confirm Landing Plan";
		((Control)DarkGroupBox3).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox3).Controls.Add((Control)(object)ButtonProhibitTransport);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LVUnitListInWave);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LV_TransportWaveManifest);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)ButtonAllowTransport);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LabelUnitListForWave);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LabelSelectedTransport);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LV_Transports);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(302, 3);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(920, 191);
		((Control)DarkGroupBox3).TabIndex = 10;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "Transports";
		((ButtonBase)ButtonProhibitTransport).BackColor = Color.Transparent;
		((Button)ButtonProhibitTransport).DialogResult = (DialogResult)0;
		((Control)ButtonProhibitTransport).ForeColor = SystemColors.Control;
		((Control)ButtonProhibitTransport).Location = new Point(120, 21);
		((Control)ButtonProhibitTransport).Margin = new Padding(2, 1, 2, 1);
		((Control)ButtonProhibitTransport).Name = "ButtonProhibitTransport";
		ButtonProhibitTransport.RoundRadius = 0;
		((Control)ButtonProhibitTransport).Size = new Size(115, 19);
		((Control)ButtonProhibitTransport).TabIndex = 19;
		ButtonProhibitTransport.Text = "Unassign";
		LVUnitListInWave.Activation = (ItemActivation)1;
		((Control)LVUnitListInWave).Anchor = (AnchorStyles)11;
		LVUnitListInWave.Columns.AddRange((ColumnHeader[])(object)new ColumnHeader[6] { ColumnHeader1, ColumnHeader6, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5 });
		LVUnitListInWave.FullRowSelect = true;
		LVUnitListInWave.GridLines = true;
		LVUnitListInWave.HeaderStyle = (ColumnHeaderStyle)1;
		LVUnitListInWave.HideSelection = false;
		((Control)LVUnitListInWave).ImeMode = (ImeMode)0;
		((Control)LVUnitListInWave).Location = new Point(538, 45);
		((Control)LVUnitListInWave).Margin = new Padding(2, 1, 2, 1);
		LVUnitListInWave.MultiSelect = false;
		((Control)LVUnitListInWave).Name = "LVUnitListInWave";
		((Control)LVUnitListInWave).Size = new Size(377, 143);
		((Control)LVUnitListInWave).TabIndex = 18;
		LVUnitListInWave.UseCompatibleStateImageBehavior = false;
		ColumnHeader1.Text = "Serial";
		ColumnHeader6.Text = "Unit";
		ColumnHeader6.TextAlign = (HorizontalAlignment)2;
		ColumnHeader2.Text = "Area";
		ColumnHeader3.Text = "Weight";
		ColumnHeader4.Text = "PAX";
		ColumnHeader5.Text = "Size Type";
		LV_TransportWaveManifest.Activation = (ItemActivation)1;
		((Control)LV_TransportWaveManifest).Anchor = (AnchorStyles)15;
		LV_TransportWaveManifest.Columns.AddRange((ColumnHeader[])(object)new ColumnHeader[4] { Wave, Area, Weight, Crew });
		LV_TransportWaveManifest.FullRowSelect = true;
		LV_TransportWaveManifest.GridLines = true;
		LV_TransportWaveManifest.HeaderStyle = (ColumnHeaderStyle)1;
		LV_TransportWaveManifest.HideSelection = false;
		((Control)LV_TransportWaveManifest).ImeMode = (ImeMode)0;
		((Control)LV_TransportWaveManifest).Location = new Point(240, 45);
		((Control)LV_TransportWaveManifest).Margin = new Padding(2, 1, 2, 1);
		LV_TransportWaveManifest.MultiSelect = false;
		((Control)LV_TransportWaveManifest).Name = "LV_TransportWaveManifest";
		((Control)LV_TransportWaveManifest).Size = new Size(294, 143);
		((Control)LV_TransportWaveManifest).TabIndex = 17;
		LV_TransportWaveManifest.UseCompatibleStateImageBehavior = false;
		Wave.Text = "Wave";
		Area.Text = "Area";
		Weight.Text = "Weight";
		Crew.Text = "PAX";
		((ButtonBase)ButtonAllowTransport).BackColor = Color.Transparent;
		((Button)ButtonAllowTransport).DialogResult = (DialogResult)0;
		((Control)ButtonAllowTransport).ForeColor = SystemColors.Control;
		((Control)ButtonAllowTransport).Location = new Point(5, 21);
		((Control)ButtonAllowTransport).Margin = new Padding(2, 1, 2, 1);
		((Control)ButtonAllowTransport).Name = "ButtonAllowTransport";
		ButtonAllowTransport.RoundRadius = 0;
		((Control)ButtonAllowTransport).Size = new Size(111, 19);
		((Control)ButtonAllowTransport).TabIndex = 14;
		ButtonAllowTransport.Text = "Assign";
		((Control)LabelUnitListForWave).Anchor = (AnchorStyles)11;
		LabelUnitListForWave.AutoSize = true;
		((Control)LabelUnitListForWave).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelUnitListForWave).Location = new Point(535, 30);
		((Control)LabelUnitListForWave).Name = "LabelUnitListForWave";
		((Control)LabelUnitListForWave).Size = new Size(113, 13);
		((Control)LabelUnitListForWave).TabIndex = 16;
		((Label)LabelUnitListForWave).Text = "List of units for wave 1";
		LabelSelectedTransport.AutoSize = true;
		((Control)LabelSelectedTransport).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelSelectedTransport).Location = new Point(237, 30);
		((Control)LabelSelectedTransport).Name = "LabelSelectedTransport";
		((Control)LabelSelectedTransport).Size = new Size(43, 13);
		((Control)LabelSelectedTransport).TabIndex = 15;
		((Label)LabelSelectedTransport).Text = "LCAC 1";
		((Control)LV_Transports).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_Transports).Location = new Point(5, 45);
		LV_Transports.MultiSelect = true;
		((Control)LV_Transports).Name = "LV_Transports";
		LV_Transports.RelatedInfos = null;
		((Control)LV_Transports).Size = new Size(230, 140);
		((Control)LV_Transports).TabIndex = 0;
		((Control)LV_Transports).Text = "LV_Transports";
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkLabel1);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LV_MissionPrep);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkLabel7);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)ComboMothership);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)ComboBoxLandingType);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(12, 3);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(284, 191);
		((Control)DarkGroupBox1).TabIndex = 6;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Mission Preparation";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(9, 168);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(61, 13);
		((Control)DarkLabel1).TabIndex = 13;
		((Label)DarkLabel1).Text = "Zone type :";
		((Control)LV_MissionPrep).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_MissionPrep).Location = new Point(6, 45);
		((Control)LV_MissionPrep).Name = "LV_MissionPrep";
		LV_MissionPrep.RelatedInfos = null;
		((Control)LV_MissionPrep).Size = new Size(273, 116);
		((Control)LV_MissionPrep).TabIndex = 12;
		((Control)LV_MissionPrep).Text = "LV_MissionPrep";
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(9, 21);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(59, 13);
		((Control)DarkLabel7).TabIndex = 3;
		((Label)DarkLabel7).Text = "Mothership";
		((ComboBox)ComboMothership).BackColor = Color.Transparent;
		((ComboBox)ComboMothership).DrawMode = (DrawMode)1;
		((ComboBox)ComboMothership).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboMothership).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboMothership).FormattingEnabled = true;
		((Control)ComboMothership).Location = new Point(132, 17);
		((Control)ComboMothership).Name = "ComboMothership";
		((Control)ComboMothership).Size = new Size(147, 21);
		((Control)ComboMothership).TabIndex = 2;
		((ComboBox)ComboBoxLandingType).BackColor = Color.Transparent;
		((ComboBox)ComboBoxLandingType).DrawMode = (DrawMode)1;
		((ComboBox)ComboBoxLandingType).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBoxLandingType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBoxLandingType).FormattingEnabled = true;
		((ComboBox)ComboBoxLandingType).Items.AddRange(new object[3] { "Unassigned", "Amphibious (CLZ)", "Airborne (LZ)" });
		((Control)ComboBoxLandingType).Location = new Point(94, 164);
		((Control)ComboBoxLandingType).Name = "ComboBoxLandingType";
		((Control)ComboBoxLandingType).Size = new Size(184, 21);
		((Control)ComboBoxLandingType).TabIndex = 10;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(1234, 649);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Form)this).MinimumSize = new Size(1250, 688);
		((Control)this).Name = "LandingPlanner";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "LandingPlanner";
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((Control)DarkGroupBox4).ResumeLayout(false);
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((ISupportInitialize)DGVMain).EndInit();
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox3).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void OperationPlannerForm_Quit(object sender, FormClosingEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (!ForceClose && (int)DarkMessageBox.ShowWarning("You will lose any progress done in the landing planner, are you sure to close this window?", "Closing landing planner", DarkDialogButton.YesNo) == 7)
		{
			((CancelEventArgs)(object)e).Cancel = true;
		}
	}

	private void LandingPlanner_Load(object sender, EventArgs e)
	{
		foreach (Zone standardZone in Client.CurrentSide.StandardZones)
		{
			LandingZoneWrapper landingZoneWrapper = new LandingZoneWrapper(standardZone, LandingType.Unassigned);
			AssignedZones.Add(landingZoneWrapper, landingZoneWrapper);
		}
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			chalk.Priority = 0;
		}
		if (LandingPlanImport != null)
		{
			foreach (Chalk chalk2 in Client.CurrentSide.Chalks)
			{
				if (LandingPlanImport.SerialToPriority.ContainsKey(chalk2))
				{
					chalk2.Priority = LandingPlanImport.SerialToPriority[chalk2];
				}
			}
		}
		method_2();
		method_5();
		method_4();
		method_33();
		method_23();
		method_3();
		if (CurrentMothership != null)
		{
			((Form)this).Text = "Landing planner for  " + CurrentMothership.Name;
		}
		if (LandingPlanImport != null)
		{
			foreach (ChalkUnit item in list_0)
			{
				if (LandingPlanImport.SerialToZoneAssociation.ContainsKey(item.AssociatedChalk))
				{
					foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in AssignedZones)
					{
						if (Operators.CompareString(assignedZone.Key.LandingZone.ObjectID, LandingPlanImport.SerialToZoneAssociation[item.AssociatedChalk].ObjectID, true) != 0)
						{
							continue;
						}
						item.LandingZone = assignedZone.Value;
						if (!ChalkContainer.ContainsKey(item.AssociatedChalk))
						{
							continue;
						}
						foreach (UnitLineWrapper item2 in ChalkContainer[item.AssociatedChalk])
						{
							DGVMain.Rows[item2.Index].Cells["Landing Zone"].Value = item.LandingZone;
						}
					}
				}
				else if (item.AssociatedChalk.Preboat != null && LandingPlanImport.Preboated.ContainsKey(item.AssociatedChalk.Preboat.ActualTransport))
				{
					foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone2 in AssignedZones)
					{
						if (Operators.CompareString(assignedZone2.Key.LandingZone.ObjectID, LandingPlanImport.Preboated[item.AssociatedChalk.Preboat.ActualTransport].ObjectID, true) != 0)
						{
							continue;
						}
						item.LandingZone = assignedZone2.Value;
						if (!ChalkContainer.ContainsKey(item.AssociatedChalk))
						{
							continue;
						}
						foreach (UnitLineWrapper item3 in ChalkContainer[item.AssociatedChalk])
						{
							DGVMain.Rows[item3.Index].Cells["Landing Zone"].Value = item.LandingZone;
						}
					}
				}
				if (ChalkContainer.Count <= 0 || !LandingPlanImport.SerialAllowedTransportClasses.ContainsKey(item.AssociatedChalk.ID.ToString()))
				{
					continue;
				}
				foreach (KeyValuePair<string, TransportAvailability> item4 in dictionary_0)
				{
					bool flag = LandingPlanImport.SerialAllowedTransportClasses[item.AssociatedChalk.ID.ToString()].Contains(item4.Key);
					foreach (UnitLineWrapper item5 in ChalkContainer[item.AssociatedChalk])
					{
						if (!flag)
						{
							item5.ChalkUnit.TransportAvailable[item4.Key] = TransportAvailability.DontUseTransport;
						}
						else
						{
							item5.ChalkUnit.TransportAvailable[item4.Key] = TransportAvailability.UseTransport;
						}
					}
				}
			}
			method_7();
		}
		LandingPlanImport = null;
	}

	private void method_2()
	{
		((ComboBox)ComboMothership).BeginUpdate();
		((ListControl)ComboMothership).ValueMember = "ID";
		((ListControl)ComboMothership).DisplayMember = "Label";
		int selectedIndex = 0;
		foreach (ActiveUnit unit in Client.CurrentSide.Units)
		{
			if (unit.IsShip && unit.HasCargo && Information.IsNothing((object)unit.DockingOps.CurrentHostUnit))
			{
				((ComboBox)ComboMothership).Items.Add((object)new MothershipItem(unit));
				if (LandingPlanImport != null && LandingPlanImport.Mothership != null && Operators.CompareString(LandingPlanImport.Mothership.ObjectID, unit.ObjectID, true) == 0)
				{
					selectedIndex = ((ComboBox)ComboMothership).Items.Count - 1;
				}
			}
		}
		if (((ComboBox)ComboMothership).Items.Count > 0)
		{
			((ComboBox)ComboMothership).SelectedIndex = selectedIndex;
		}
		((ComboBox)ComboMothership).EndUpdate();
	}

	private void method_3()
	{
		ButtonConfirmPlan.Enabled = bool_2;
	}

	private void method_4()
	{
		LV_Transports.Items.Clear();
		if (CurrentMothership == null)
		{
			return;
		}
		if (LandingPlanImport != null)
		{
			foreach (ActiveUnit allowedTransport in LandingPlanImport.AllowedTransports)
			{
				if (!AllowedTransport.ContainsKey(allowedTransport) && TransportList.ContainsKey(allowedTransport))
				{
					AllowedTransport.Add(allowedTransport, TransportList[allowedTransport]);
				}
			}
			if (LandingPlanImport.AllowedTransportClasses != null)
			{
				foreach (string allowedTransportClass in LandingPlanImport.AllowedTransportClasses)
				{
					foreach (KeyValuePair<ActiveUnit, Transport> transport in TransportList)
					{
						if (Operators.CompareString(transport.Key.UnitClass, allowedTransportClass, true) == 0 && !AllowedTransport.ContainsKey(transport.Key))
						{
							AllowedTransport.Add(transport.Key, transport.Value);
						}
					}
				}
			}
		}
		foreach (KeyValuePair<ActiveUnit, Transport> item in TransportList.OrderBy([SpecialName] (KeyValuePair<ActiveUnit, Transport> x) => x.Value.ActualTransport.Name).ToList())
		{
			if (((ICargoHost)item.Key).GetCargo_Type() != CargoType.NoCargo)
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Tag = item.Value;
				darkListItem.Text = item.Key.Name;
				if (item.Value.ActualTransport.HasCargo)
				{
					darkListItem.Text += " [Pre-loaded]";
				}
				if (!AllowedTransport.ContainsKey(item.Key))
				{
					darkListItem.TextColor = Color.White;
				}
				else
				{
					darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				LV_Transports.Items.Add(darkListItem);
			}
		}
	}

	private void method_5()
	{
		LV_MissionPrep.Items.Clear();
		if (LandingPlanImport != null)
		{
			foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> item in AssignedZones.ToList())
			{
				if (LandingPlanImport.LandingZones.ContainsKey(item.Key.LandingZone))
				{
					item.Key.LandingZoneType = LandingPlanImport.LandingZones[item.Key.LandingZone].LandingZoneType;
				}
			}
		}
		((ComboBox)ComboBoxLandingType).Text = "No Selection";
		foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> item2 in AssignedZones.OrderBy([SpecialName] (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> x) => x.Key.LandingZone.Description).ToList())
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = item2.Key;
			darkListItem.Text = item2.Key.LandingZone.Description;
			if (item2.Key.LandingZoneType == LandingType.Unassigned)
			{
				darkListItem.TextColor = Color.White;
				darkListItem.Text += " (Unassigned)";
			}
			else
			{
				darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				if (item2.Key.LandingZoneType == LandingType.Airborne)
				{
					darkListItem.Text += " (LZ)";
				}
				else
				{
					darkListItem.Text += " (CLZ)";
				}
			}
			LV_MissionPrep.Items.Add(darkListItem);
		}
	}

	private bool method_6(Chalk chalk_0)
	{
		if (ChalkContainer[chalk_0].Count == 0)
		{
			return false;
		}
		foreach (UnitLineWrapper item in ChalkContainer[chalk_0])
		{
			if (!item.ChalkUnit.IsAmphibious)
			{
				return false;
			}
		}
		return true;
	}

	private void method_7()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_0971: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected O, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected O, but got Unknown
		DGVMain.CellValueChanged -= new DataGridViewCellEventHandler(method_27);
		int num = dictionary_0.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			dictionary_0[dictionary_0.ElementAt(i).Key] = TransportAvailability.CantUseTransport;
			foreach (KeyValuePair<ActiveUnit, Transport> item in AllowedTransport)
			{
				if (Operators.CompareString(item.Key.UnitClass, dictionary_0.ElementAt(i).Key, true) == 0)
				{
					dictionary_0[dictionary_0.ElementAt(i).Key] = TransportAvailability.UseTransport;
					break;
				}
			}
		}
		int num2 = DGVMain.Rows.Count - 1;
		for (int j = 0; j <= num2; j++)
		{
			UnitLineWrapper unitLineWrapper = (UnitLineWrapper)bindingSource_0[j];
			int num3 = unitLineWrapper.ChalkUnit.TransportAvailable.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				if (Operators.CompareString(unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key, "Self", true) != 0)
				{
					if (dictionary_0[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.CantUseTransport)
					{
						unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
					}
					else if (unitLineWrapper.ChalkUnit.LandingZone != null && unitLineWrapper.ChalkUnit.LandingZone.LandingZoneType == dictionary_2[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key])
					{
						if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.UseTransport && unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.DontUseTransport)
						{
							unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.UseTransport;
						}
					}
					else
					{
						unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
					}
				}
				else if (unitLineWrapper.ChalkUnit.IsAmphibious && method_6(unitLineWrapper.ChalkUnit.AssociatedChalk) && unitLineWrapper.ChalkUnit.LandingZone != null && unitLineWrapper.ChalkUnit.LandingZone.LandingZoneType == dictionary_2[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key])
				{
					if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.DontUseTransport && unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.UseTransport)
					{
						unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.DontUseTransport;
					}
				}
				else
				{
					unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
				}
				if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.CantUseTransport)
				{
					if (((object)DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key]).GetType() == typeof(DataGridViewCheckBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = true;
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = (DataGridViewCell)new DataGridViewTextBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.LightGray;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = true;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
				}
				else if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.DontUseTransport)
				{
					if (((object)DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key]).GetType() == typeof(DataGridViewTextBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = (DataGridViewCell)new DataGridViewCheckBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = false;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.White;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = false;
				}
				else
				{
					if (((object)DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key]).GetType() == typeof(DataGridViewTextBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = (DataGridViewCell)new DataGridViewCheckBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = true;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.White;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = false;
				}
			}
			DGVMain.Rows[j].Cells["CurrentTransport"].ToolTipText = unitLineWrapper.ChalkUnit.TransportErrorMessagTooltip;
		}
		DGVMain.CellValueChanged += new DataGridViewCellEventHandler(method_27);
		((Control)DGVMain).Refresh();
	}

	private void method_8()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_0a49: Unknown result type (might be due to invalid IL or missing references)
		DGVMain.DataSource = null;
		DGVMain.Rows.Clear();
		DGVMain.Columns.Clear();
		bindingSource_0.Clear();
		if (CurrentMothership == null)
		{
			return;
		}
		DGVMain.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		DGVMain.AutoGenerateColumns = true;
		bindingSource_0.DataSource = typeof(UnitLineWrapper);
		new List<DataGridViewCheckBoxColumn>();
		dictionary_0 = new Dictionary<string, TransportAvailability>();
		dictionary_1 = new Dictionary<string, List<Transport>>();
		dictionary_2 = new Dictionary<string, LandingType>();
		TransportList = new Dictionary<ActiveUnit, Transport>();
		ChalkContainer = new Dictionary<Chalk, List<UnitLineWrapper>>();
		dictionary_3 = new Dictionary<int, UnitLineWrapper>();
		list_0 = new List<ChalkUnit>();
		foreach (ActiveUnit item in CurrentMothership.DockingOps.EmbarkedBoats_ReadOnly)
		{
			Transport transport = new Transport(item);
			if (((ICargoHost)item).GetCargo_Type() != CargoType.NoCargo)
			{
				if (!dictionary_1.ContainsKey(item.UnitClass))
				{
					dictionary_1.Add(item.UnitClass, new List<Transport>());
					dictionary_1[item.UnitClass].Add(transport);
				}
				else
				{
					dictionary_1[item.UnitClass].Add(transport);
				}
				if (!TransportList.ContainsKey(item))
				{
					TransportList.Add(transport.ActualTransport, transport);
				}
				if (!dictionary_0.ContainsKey(item.UnitClass))
				{
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridViewColumn)val).DataPropertyName = "Transport";
					((DataGridViewColumn)val).Name = item.UnitClass;
					((DataGridViewColumn)val).HeaderText = "Use " + item.UnitClass;
					DGVMain.Columns.Add((DataGridViewColumn)(object)val);
					dictionary_0.Add(item.UnitClass, TransportAvailability.Unknown);
					dictionary_2.Add(item.UnitClass, LandingType.Amphibious);
				}
			}
		}
		foreach (Aircraft item2 in CurrentMothership.AirOps.EmbarkedAircraft_ReadOnly)
		{
			Transport transport2 = new Transport(item2);
			if (((ICargoHost)item2).GetCargo_Type() != CargoType.NoCargo)
			{
				if (dictionary_1.ContainsKey(item2.UnitClass))
				{
					dictionary_1[item2.UnitClass].Add(transport2);
				}
				else
				{
					dictionary_1.Add(item2.UnitClass, new List<Transport>());
					dictionary_1[item2.UnitClass].Add(transport2);
				}
				if (!TransportList.ContainsKey(item2))
				{
					TransportList.Add(transport2.ActualTransport, transport2);
				}
				if (!dictionary_0.ContainsKey(item2.UnitClass))
				{
					DataGridViewCheckBoxColumn val2 = new DataGridViewCheckBoxColumn();
					((DataGridViewColumn)val2).DataPropertyName = "Transport";
					((DataGridViewColumn)val2).Name = item2.UnitClass;
					((DataGridViewColumn)val2).HeaderText = "Use " + item2.UnitClass;
					DGVMain.Columns.Add((DataGridViewColumn)(object)val2);
					dictionary_0.Add(item2.UnitClass, TransportAvailability.Unknown);
					dictionary_2.Add(item2.UnitClass, LandingType.Airborne);
				}
			}
		}
		List<Chalk> list = new List<Chalk>();
		foreach (Chalk chalk2 in Client.CurrentSide.Chalks)
		{
			if (chalk2.AssociatedMothership != null && Operators.CompareString(chalk2.AssociatedMothership.ObjectID, CurrentMothership.ObjectID, true) == 0)
			{
				list.Add(chalk2);
			}
		}
		method_9(list);
		foreach (Transport item3 in TransportList.Values.ToList())
		{
			if (item3.ActualTransport.OnboardCargo.Length > 0)
			{
				Chalk chalk = new Chalk(-1, CurrentMothership);
				chalk.Preboat = item3;
				Cargo[] onboardCargo = item3.ActualTransport.OnboardCargo;
				foreach (Cargo cargoToAdd in onboardCargo)
				{
					chalk.AddCargo(cargoToAdd);
				}
				list.Add(chalk);
			}
		}
		int num = default(int);
		foreach (Chalk item4 in list)
		{
			if (Operators.CompareString(item4.AssociatedMothership.ObjectID, CurrentMothership.ObjectID, true) != 0)
			{
				continue;
			}
			bool isSubEntry = false;
			ChalkContainer.Add(item4, new List<UnitLineWrapper>());
			foreach (KeyValuePair<Cargo, int> item5 in item4.Cargo)
			{
				UnitLineWrapper unitLineWrapper = null;
				unitLineWrapper = (Information.IsNothing((object)item4.Preboat) ? new UnitLineWrapper(item4, item5.Key, 0, 0, null, isSubEntry, dictionary_0, null, num) : new UnitLineWrapper(item4, item5.Key, 0, 0, item4.Preboat.ActualTransport, isSubEntry, dictionary_0, null, num));
				dictionary_3.Add(num, unitLineWrapper);
				ChalkContainer[item4].Add(unitLineWrapper);
				list_0.Add(unitLineWrapper.ChalkUnit);
				bindingSource_0.Add((object)unitLineWrapper);
				isSubEntry = true;
				num++;
			}
		}
		new List<DataGridViewCheckBoxColumn>();
		DataGridViewComboBoxColumn val3 = new DataGridViewComboBoxColumn();
		((DataGridViewColumn)val3).DataPropertyName = "Landing Zone";
		((DataGridViewColumn)val3).Name = "Landing Zone";
		val3.ValueMember = "ID";
		val3.DisplayMember = "Label";
		val3.Items.Add((object)new MissionZoneComboWrapper(null));
		foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in AssignedZones)
		{
			val3.Items.Add((object)new MissionZoneComboWrapper(assignedZone.Key));
		}
		DGVMain.DataSource = bindingSource_0;
		DGVMain.AutoGenerateColumns = false;
		DGVMain.Columns.Add((DataGridViewColumn)(object)val3);
		DataGridView dGVMain = DGVMain;
		dGVMain.Columns["Priority"].DisplayIndex = 0;
		dGVMain.Columns["Priority"].ReadOnly = false;
		dGVMain.Columns["Priority"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		dGVMain.Columns["Priority"].Width = 60;
		dGVMain.Columns["Serial"].HeaderText = "Serial (m2 | Tons | PAX)";
		dGVMain.Columns["Serial"].DisplayIndex = 1;
		dGVMain.Columns["Serial"].ReadOnly = true;
		dGVMain.Columns["Serial"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		dGVMain.Columns["Serial"].Width = 155;
		dGVMain.Columns["Unit"].DisplayIndex = 2;
		dGVMain.Columns["Unit"].ReadOnly = true;
		dGVMain.Columns["Landing Zone"].DisplayIndex = 3;
		dGVMain.Columns["Wave"].ReadOnly = true;
		dGVMain.Columns["Wave"].DisplayIndex = 4;
		dGVMain.Columns["Wave"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		dGVMain.Columns["Wave"].Width = 45;
		dGVMain.Columns["CurrentTransport"].ReadOnly = true;
		dGVMain.Columns["CurrentTransport"].DisplayIndex = 5;
		dGVMain.Columns["CurrentTransport"].HeaderText = "Current Transport (m2 | Tons | PAX)";
		if (Conversions.ToBoolean(Operators.NotObject(method_12("Priority"))))
		{
			DGVMain.Columns["Priority"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(method_12("Serial"))))
		{
			DGVMain.Columns["Serial"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(method_12("Unit"))))
		{
			DGVMain.Columns["Unit"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(method_12("Wave"))))
		{
			DGVMain.Columns["Wave"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(method_12("Landing Zone"))))
		{
			DGVMain.Columns["Landing Zone"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(method_12("CurrentTransport"))))
		{
			DGVMain.Columns["CurrentTransport"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		foreach (DataGridViewColumn item6 in (BaseCollection)DGVMain.Columns)
		{
			item6.SortMode = (DataGridViewColumnSortMode)1;
		}
		method_7();
	}

	private void method_9(List<Chalk> list_1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		foreach (Chalk item in list_1)
		{
			foreach (KeyValuePair<Cargo, int> item2 in item.Cargo)
			{
				if (item2.Key.CurrentType == Cargo.CargoObjectType.Vehicle && ((Vehicle)item2.Key.CargoObjectActiveUnit).IsAmphibiousSeaworthy)
				{
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridViewColumn)val).DataPropertyName = "Transport";
					((DataGridViewColumn)val).Name = "Self";
					((DataGridViewColumn)val).HeaderText = "Self";
					DGVMain.Columns.Add((DataGridViewColumn)(object)val);
					dictionary_0.Add("Self", TransportAvailability.Unknown);
					dictionary_2.Add("Self", LandingType.Amphibious);
					return;
				}
			}
		}
	}

	private void method_10()
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		LV_TransportWaveManifest.GridLines = true;
		LV_TransportWaveManifest.View = (View)1;
		LV_TransportWaveManifest.Items.Clear();
		method_22();
		if (CurrentTransport == null)
		{
			((Label)LabelSelectedTransport).Text = "None";
			transportWave_0 = null;
		}
		else
		{
			((Label)LabelSelectedTransport).Text = CurrentTransport.ActualTransport.Name;
			foreach (TransportWave wave in CurrentTransport.Waves)
			{
				ListViewItem val = new ListViewItem(new string[5]
				{
					wave.Wave.ToString(),
					Math.Round(wave.GetAreaTaken(), 1) + "/" + Math.Round(CurrentTransport.AreaCapacity, 1),
					Math.Round(wave.GetMassTaken(), 1) + "/" + Math.Round(CurrentTransport.MassCapacity, 1),
					Math.Round(wave.GetCrewTaken(), 1) + "/" + Math.Round(CurrentTransport.CrewCapacity, 1),
					null
				});
				val.Tag = wave;
				LV_TransportWaveManifest.Items.Add(val);
			}
			if (CurrentTransport.Waves.Count > 0)
			{
				transportWave_0 = CurrentTransport.Waves[CurrentTransport.Waves.Count - 1];
			}
		}
		method_22();
	}

	private void method_11(object sender, EventArgs e)
	{
		if (DGVMain.CurrentCell != null)
		{
			DGVMain.CurrentCell.Selected = Conversions.ToBoolean(method_12(DGVMain.Columns[DGVMain.CurrentCell.ColumnIndex].Name));
		}
	}

	private object method_12(string string_0)
	{
		if (Operators.CompareString(string_0, "Priority", true) != 0)
		{
			if (Operators.CompareString(string_0, "Landing Zone", true) != 0)
			{
				if (Operators.CompareString(string_0, "Serial", true) == 0)
				{
					return false;
				}
				if (Operators.CompareString(string_0, "Unit", true) != 0)
				{
					if (Operators.CompareString(string_0, "Wave", true) != 0)
					{
						if (Operators.CompareString(string_0, "CurrentTransport", true) != 0)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	private void method_13(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		Control editingControl = DGVMain.EditingControl;
		ComboBox val = (ComboBox)(object)((editingControl is ComboBox) ? editingControl : null);
		if (comboBox_0 != null)
		{
			comboBox_0.SelectionChangeCommitted -= method_15;
		}
		if (val != null)
		{
			val.SelectionChangeCommitted += method_15;
			comboBox_0 = val;
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((ComboBox)ComboMothership).SelectedItem)))
		{
			return;
		}
		ActiveUnit currentMothership = CurrentMothership;
		CurrentMothership = ((MothershipItem)((ComboBox)ComboMothership).SelectedItem).ID;
		if (currentMothership != null)
		{
			if (Operators.CompareString(currentMothership.ObjectID, CurrentMothership.ObjectID, true) != 0 && (int)DarkMessageBox.ShowWarning("You will lose any progress done in the landing planner as a landing plan is tied to a mothership, do you really want to switch mothership ?", "Switching mothership", DarkDialogButton.YesNo) == 6)
			{
				method_8();
			}
		}
		else
		{
			method_8();
		}
		method_4();
		method_7();
	}

	private void method_15(object sender, EventArgs e)
	{
		MissionZoneComboWrapper missionZoneComboWrapper = (MissionZoneComboWrapper)((ComboBox)((sender is DataGridViewComboBoxEditingControl) ? sender : null)).SelectedItem;
		ChalkUnit chalkUnit = null;
		if (missionZoneComboWrapper.ID != null)
		{
			LandingZoneWrapper iD = missionZoneComboWrapper.ID;
			chalkUnit = ((UnitLineWrapper)bindingSource_0[DGVMain.CurrentCell.RowIndex]).ChalkUnit;
			if (enum5_0 == (Enum5)1)
			{
				if (ChalkContainer.ContainsKey(chalkUnit.AssociatedChalk))
				{
					foreach (UnitLineWrapper item in ChalkContainer[chalkUnit.AssociatedChalk])
					{
						DGVMain.Rows[item.Index].Cells["Landing Zone"].Value = iD;
						item.ChalkUnit.LandingZone = iD;
					}
				}
			}
			else
			{
				chalkUnit.LandingZone = iD;
			}
		}
		else
		{
			chalkUnit = ((UnitLineWrapper)bindingSource_0[DGVMain.CurrentCell.RowIndex]).ChalkUnit;
			if (enum5_0 == (Enum5)1)
			{
				if (ChalkContainer.ContainsKey(chalkUnit.AssociatedChalk))
				{
					foreach (UnitLineWrapper item2 in ChalkContainer[chalkUnit.AssociatedChalk])
					{
						DGVMain.Rows[item2.Index].Cells["Landing Zone"].Value = null;
						item2.ChalkUnit.LandingZone = null;
					}
				}
			}
			else
			{
				chalkUnit.LandingZone = null;
			}
		}
		method_7();
	}

	private void method_16(object sender, EventArgs e)
	{
	}

	private void method_17(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count == 0)
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_Transports.SelectedItems)
		{
			if (selectedItem != null)
			{
				Transport transport = (Transport)selectedItem.Tag;
				if (transport == null)
				{
					return;
				}
				if (!AllowedTransport.ContainsKey(transport.ActualTransport))
				{
					AllowedTransport.Add(transport.ActualTransport, transport);
				}
			}
		}
		method_23();
		method_4();
		method_7();
	}

	private void method_18(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count == 0)
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_Transports.SelectedItems)
		{
			if (selectedItem != null)
			{
				Transport transport = (Transport)selectedItem.Tag;
				if (transport == null)
				{
					return;
				}
				if (AllowedTransport.ContainsKey(transport.ActualTransport))
				{
					AllowedTransport.Remove(transport.ActualTransport);
				}
			}
		}
		method_23();
		method_4();
		method_7();
	}

	private void method_19(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count != 0 && LV_MissionPrep.SelectedItems.ElementAt(0) != null)
		{
			_ = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count != 0 && LV_Transports.SelectedItems.ElementAt(0) != null)
		{
			CurrentTransport = (Transport)LV_Transports.SelectedItems.ElementAt(0).Tag;
			method_23();
			method_10();
			_ = CurrentTransport;
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		if (LV_TransportWaveManifest.SelectedItems.Count != 0 && LV_TransportWaveManifest.SelectedItems[0] != null)
		{
			transportWave_0 = (TransportWave)LV_TransportWaveManifest.SelectedItems[0].Tag;
			method_22();
		}
	}

	private void method_22()
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		LVUnitListInWave.Items.Clear();
		LVUnitListInWave.GridLines = true;
		LVUnitListInWave.View = (View)1;
		((Label)LabelUnitListForWave).Text = "";
		if (transportWave_0 == null || CurrentTransport == null)
		{
			return;
		}
		((Label)LabelUnitListForWave).Text = "Transport Manifest For Wave #" + transportWave_0.Wave;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in transportWave_0.UnitsInWave)
		{
			string[] array = new string[7];
			if (item.Key.AssociatedChalk.ID == -1)
			{
				array[0] = "Preboated";
			}
			else
			{
				array[0] = item.Key.AssociatedChalk.ID.ToString();
			}
			array[1] = item.Key.Unit.CargoObjectName;
			array[2] = item.Key.Unit.RequiredArea.ToString();
			array[3] = item.Key.Unit.RequiredMass.ToString();
			array[4] = item.Key.Unit.RequiredCrewSpace.ToString();
			array[5] = item.Key.Unit.RequiredCargoType.ToString();
			ListViewItem val = new ListViewItem(array);
			LVUnitListInWave.Items.Add(val);
		}
	}

	private void method_23()
	{
		if (LV_Transports.SelectedItems.Count > 0)
		{
			((Control)ButtonAllowTransport).Visible = true;
			((Control)ButtonProhibitTransport).Visible = true;
		}
		else
		{
			((Control)ButtonAllowTransport).Visible = false;
			((Control)ButtonProhibitTransport).Visible = false;
		}
		((Control)ButtonAllowTransport).Refresh();
	}

	private Mission method_24(Chalk chalk_0, int int_0 = 0)
	{
		if (ChalkContainer[chalk_0].Count == 0)
		{
			return null;
		}
		Zone landingZone = ChalkContainer[chalk_0].ElementAt(0).ChalkUnit.LandingZone.LandingZone;
		if (landingZone == null)
		{
			return null;
		}
		List<ReferencePoint> theCourse = new List<ReferencePoint>();
		Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(landingZone.Area);
		ReferencePoint referencePoint = new ReferencePoint(geopoint_Struct.Longitude, geopoint_Struct.Latitude);
		theCourse.Add(referencePoint);
		referencePoint.IsHighlighted = true;
		Client.CurrentSide.RefPoints.Add(referencePoint);
		Client.MustRefreshMainForm = true;
		Side theSide = Client.CurrentSide;
		Scenario theScen = Client.CurrentScenario;
		SupportMission supportMission = new SupportMission(ref theSide, ref theScen, "", Mission.MissionCategory.Mission, ref theCourse, ValidateArea: false);
		Client.CurrentSide = theSide;
		SupportMission supportMission2 = supportMission;
		supportMission2.MarkAsSatisfiedUponReachingDestination = true;
		supportMission2.RTBUponCompletion = false;
		supportMission2.PriorityWeight = int_0;
		supportMission2.CreationMode = MissionCreationType.LandingPlanner;
		supportMission2.OperationName = "Amphibious Landing - Serials";
		supportMission2.NavigationLoopType = SupportMission.SupportMissionNavigationLoopType.SingleLoop;
		supportMission2.StationThrottle_Facility = ActiveUnit.Throttle.Flank;
		supportMission2.TransitThrottle_Facility = ActiveUnit.Throttle.Flank;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (UnitLineWrapper item in ChalkContainer[chalk_0])
		{
			if (!dictionary.ContainsKey(item.ChalkUnit.AssociatedChalk.ID))
			{
				SupportMission supportMission3;
				(supportMission3 = supportMission2).OperationName = supportMission3.OperationName + " #" + item.ChalkUnit.AssociatedChalk.ID;
				dictionary.Add(item.ChalkUnit.AssociatedChalk.ID, item.ChalkUnit.AssociatedChalk.ID);
			}
		}
		supportMission2.Name = supportMission2.OperationName;
		referencePoint.Name = supportMission2.OperationName;
		foreach (UnitLineWrapper item2 in ChalkContainer[chalk_0])
		{
			item2.ChalkUnit.CurrentTransport.ActualTransport.AssignMissionInQueue(supportMission2);
		}
		return supportMission2;
	}

	private Mission method_25(TransportWave transportWave_1, Mission mission_0 = null, int int_0 = 0)
	{
		Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
		Zone landingZone = transportWave_1.GetLandingZone();
		if (landingZone == null)
		{
			return null;
		}
		CargoMission cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, landingZone.Description + " " + transportWave_1.AssociatedTransport.ActualTransport.Name + " Wave " + transportWave_1.Wave, Mission.MissionCategory.Mission, landingZone.Area, ValidateArea: true);
		transportWave_1.AssociatedTransport.ActualTransport.AssignMissionInQueue(cargoMission);
		cargoMission.MissionCompletedTrigger_LUA = "return(ScenEdit_GetMission('" + Client.CurrentSide.ObjectID + "', '" + cargoMission.ObjectID + "').cargomission.IsFulfilled)";
		cargoMission.MissionCompletedTrigger_LUA_Enabled = true;
		cargoMission.MissionCompletedTrigger_LUADescription = "Unloaded From Mothership";
		cargoMission.PriorityWeight = int_0;
		cargoMission.CreationMode = MissionCreationType.LandingPlanner;
		cargoMission.OperationName = transportWave_1.AssociatedTransport.ActualTransport.Name + " - Serials";
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in transportWave_1.UnitsInWave)
		{
			if (!dictionary.ContainsKey(item.Key.AssociatedChalk.ID))
			{
				CargoMission cargoMission2;
				(cargoMission2 = cargoMission).OperationName = cargoMission2.OperationName + " #" + item.Key.AssociatedChalk.ID;
				dictionary.Add(item.Key.AssociatedChalk.ID, item.Key.AssociatedChalk.ID);
			}
		}
		if (mission_0 == null)
		{
			transportWave_1.IsFirstWave = true;
		}
		else
		{
			cargoMission.MissionStartTrigger_MissionCompleted.Add(mission_0, mission_0);
			cargoMission.MissionStartTrigger_MissionCompleted_Enabled = true;
			transportWave_1.IsFirstWave = false;
		}
		cargoMission.TransportWaveManifest = transportWave_1;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item2 in transportWave_1.UnitsInWave)
		{
			CargoManifestItem.Add(item2.Key.Unit, cargoMission.CargoToUnload);
		}
		return cargoMission;
	}

	private void method_26(object sender, EventArgs e)
	{
		if (DGVMain.IsCurrentCellDirty)
		{
			DGVMain.CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_27(object sender, DataGridViewCellEventArgs e)
	{
		DataGridViewCell currentCell = DGVMain.CurrentCell;
		DataGridViewCheckBoxCell val = (DataGridViewCheckBoxCell)(object)((currentCell is DataGridViewCheckBoxCell) ? currentCell : null);
		if (val == null)
		{
			return;
		}
		foreach (KeyValuePair<string, TransportAvailability> item in dictionary_0)
		{
			if (e.ColumnIndex != ((DataGridViewBand)DGVMain.Columns[item.Key]).Index)
			{
				continue;
			}
			UnitLineWrapper unitLineWrapper = (UnitLineWrapper)bindingSource_0[DGVMain.CurrentCell.RowIndex];
			if (Conversions.ToBoolean(((DataGridViewCell)val).Value))
			{
				if (enum5_0 == (Enum5)1)
				{
					if (!ChalkContainer.ContainsKey(unitLineWrapper.ChalkUnit.AssociatedChalk))
					{
						continue;
					}
					foreach (UnitLineWrapper item2 in ChalkContainer[unitLineWrapper.ChalkUnit.AssociatedChalk])
					{
						item2.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.UseTransport;
					}
				}
				else
				{
					unitLineWrapper.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.UseTransport;
				}
			}
			else if (enum5_0 == (Enum5)1)
			{
				if (!ChalkContainer.ContainsKey(unitLineWrapper.ChalkUnit.AssociatedChalk))
				{
					continue;
				}
				foreach (UnitLineWrapper item3 in ChalkContainer[unitLineWrapper.ChalkUnit.AssociatedChalk])
				{
					item3.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.DontUseTransport;
				}
			}
			else
			{
				unitLineWrapper.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.DontUseTransport;
			}
		}
		method_7();
	}

	private void method_28(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_29(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_30()
	{
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		List<Transport> list = new List<Transport>();
		List<Transport> list2 = new List<Transport>();
		new List<ChalkUnit>();
		bool_2 = false;
		foreach (Transport item in AllowedTransport.Values.ToList())
		{
			item.Waves = new List<TransportWave>();
			list.Add(item);
		}
		foreach (Transport item2 in list)
		{
			foreach (ChalkUnit item3 in list_0)
			{
				if (item3.AssociatedChalk.ID == -1 && item3.AssociatedChalk.Preboat == item2)
				{
					if (item3.LandingZone == null)
					{
						DarkMessageBox.ShowWarning("Pre-boated serials MUST have a landing zone. Aborting generation.", "Assign a landing zone");
						return;
					}
					if (item2.Waves.Count == 0)
					{
						item2.Waves.Add(new TransportWave(item2, item2.Waves.Count + 1, item3.LandingZone));
					}
					item2.Waves.ElementAt(0).TryAddCargo(item3);
				}
			}
		}
		foreach (Chalk key in ChalkContainer.Keys)
		{
			bool flag = true;
			foreach (UnitLineWrapper item4 in ChalkContainer[key])
			{
				int num;
				if (item4.ChalkUnit.TransportAvailable.ContainsKey("Self"))
				{
					if (item4.ChalkUnit.TransportAvailable["Self"] == TransportAvailability.UseTransport)
					{
						continue;
					}
					num = 0;
				}
				else
				{
					num = 0;
				}
				flag = (byte)num != 0;
				break;
			}
			if (!flag)
			{
				continue;
			}
			foreach (UnitLineWrapper item5 in ChalkContainer[key])
			{
				item5.ChalkUnit.CurrentTransport = new Transport(item5.ChalkUnit.Unit.CargoObjectActiveUnit);
				item5.ChalkUnit.Wave = 0;
				item5.ChalkUnit.AssociatedChalk.SelfTransport = true;
				bool_2 = true;
			}
		}
		if (((CheckBox)CB_SerialIntegrity).Checked)
		{
			foreach (Chalk key2 in ChalkContainer.Keys)
			{
				if (ChalkContainer[key2].Count == 0)
				{
					continue;
				}
				LandingZoneWrapper landingZone = ChalkContainer[key2][0].ChalkUnit.LandingZone;
				Dictionary<string, TransportAvailability> transportAvailable = ChalkContainer[key2][0].ChalkUnit.TransportAvailable;
				foreach (UnitLineWrapper item6 in ChalkContainer[key2])
				{
					if (landingZone != item6.ChalkUnit.LandingZone)
					{
						DarkMessageBox.ShowWarning("ERROR," + item6.ChalkUnit.Unit.CargoObjectName + " in serial # " + key2.ID + " : In 'Serial Integrity' mode, the serial's units must share the same landing zone. Aborting . . .", "Error Generating Landing Plan");
						return;
					}
					foreach (KeyValuePair<string, TransportAvailability> item7 in transportAvailable)
					{
						int num2;
						if (item6.ChalkUnit.TransportAvailable.ContainsKey(item7.Key))
						{
							if (item6.ChalkUnit.TransportAvailable[item7.Key] == item7.Value)
							{
								continue;
							}
							num2 = 5;
						}
						else
						{
							num2 = 5;
						}
						string[] array = new string[num2];
						array[0] = "ERROR,";
						array[1] = item6.ChalkUnit.Unit.CargoObjectName;
						array[2] = " in serial # ";
						array[3] = key2.ID.ToString();
						array[4] = " : In 'Serial Integrity' mode, the serial's units must share the same allowed transport configuration. Aborting . . .";
						DarkMessageBox.ShowWarning(string.Concat(array), "Error Generating Landing Plan");
						return;
					}
				}
			}
			List<Chalk> list3 = new List<Chalk>();
			list3 = (from x in ChalkContainer.Keys.ToList()
				orderby x.Priority
				select x).ToList();
			foreach (Chalk item8 in list3)
			{
				if (item8.Cargo.Count == 0 || item8.SelfTransport)
				{
					continue;
				}
				Transport preboat = item8.Preboat;
				ChalkUnit chalkUnit = ChalkContainer[item8][0].ChalkUnit;
				List<string> list4 = new List<string>();
				int num3;
				if (preboat != null)
				{
					list2.Add(preboat);
					num3 = 0;
				}
				else
				{
					list2 = new List<Transport>();
					foreach (Transport item9 in list)
					{
						if (chalkUnit.IsTransportAllowed(item9) && chalkUnit.TransportAvailable[item9.ActualTransport.UnitClass] == TransportAvailability.UseTransport)
						{
							int num4 = -1;
							ActiveUnit actualTransport = item9.ActualTransport;
							float RunRequired = -1f;
							string text = item8.IsTransportEligible(actualTransport, ref RunRequired);
							num4 = (int)Math.Round(RunRequired);
							string text2 = text;
							if (Operators.CompareString(text2, "OK", true) != 0)
							{
								list4.Add(item9.ActualTransport.Name + " : " + text2);
							}
							else if ((float)num4 <= 1f)
							{
								list2.Add(item9);
							}
							else if ((float)num4 > 1f)
							{
								list4.Add(item9.ActualTransport.Name + " : Requires " + num4 + " runs (Serial Integrity Mode)");
							}
						}
					}
					foreach (UnitLineWrapper item10 in ChalkContainer[item8])
					{
						item10.ChalkUnit.TransportErrorMessagTooltip = "Serial Integrity Mode : the serial will not spread accross multiple transports";
						foreach (string item11 in list4)
						{
							ref string transportErrorMessagTooltip = ref item10.ChalkUnit.TransportErrorMessagTooltip;
							transportErrorMessagTooltip = transportErrorMessagTooltip + item11 + Environment.NewLine;
						}
					}
					if (list2.Count == 0)
					{
						foreach (UnitLineWrapper item12 in ChalkContainer[item8])
						{
							if (list4.Count != 0)
							{
								item12.ChalkUnit.TransportErrorMessage = "Impossible (" + list4.Count + " issues...)";
							}
							else
							{
								item12.ChalkUnit.TransportErrorMessage = "None";
							}
						}
						continue;
					}
					num3 = 0;
				}
				bool canAddWave = (byte)num3 != 0;
				bool flag2 = true;
				int num5 = 0;
				int num6 = 1;
				while (true)
				{
					Transport transport = list2.ElementAt(num5);
					if (chalkUnit.AssociatedChalk.ID != -1)
					{
						switch (transport.AddSerialCargoToTransport(item8, chalkUnit.LandingZone, ChalkContainer, canAddWave, num6))
						{
						default:
							flag2 = false;
							num5++;
							if (num5 < list2.Count)
							{
								continue;
							}
							if (!flag2)
							{
								num5 = 0;
								canAddWave = true;
								num6++;
								continue;
							}
							break;
						case AddCargoReturnValue.Success:
							bool_2 = true;
							break;
						case AddCargoReturnValue.Impossible:
							break;
						}
					}
					else
					{
						bool_2 = true;
					}
					break;
				}
			}
		}
		else
		{
			List<ChalkUnit> list5 = new List<ChalkUnit>();
			list5 = list_0.OrderBy([SpecialName] (ChalkUnit x) => x.AssociatedChalk.Priority).ToList();
			foreach (ChalkUnit item13 in list5)
			{
				if (item13.AssociatedChalk.SelfTransport)
				{
					continue;
				}
				item13.CurrentTransport = null;
				item13.Wave = 0;
				int num7;
				if (item13.AssociatedChalk.Preboat == null)
				{
					list2 = new List<Transport>();
					foreach (Transport item14 in list)
					{
						if (item13.IsTransportAllowed(item14) && item13.TransportAvailable[item14.ActualTransport.UnitClass] == TransportAvailability.UseTransport)
						{
							list2.Add(item14);
						}
					}
					if (list2.Count == 0)
					{
						continue;
					}
					num7 = 0;
				}
				else
				{
					list2.Add(item13.AssociatedChalk.Preboat);
					num7 = 0;
				}
				bool canAddWave2 = (byte)num7 != 0;
				bool flag3 = true;
				int num8 = 0;
				int num9 = 1;
				while (true)
				{
					Transport transport2 = list2.ElementAt(num8);
					if (item13.AssociatedChalk.ID != -1)
					{
						switch (transport2.AddCargo(item13, canAddWave2, num9))
						{
						default:
							flag3 = false;
							num8++;
							if (num8 < list2.Count)
							{
								continue;
							}
							if (!flag3)
							{
								num8 = 0;
								canAddWave2 = true;
								num9++;
								continue;
							}
							break;
						case AddCargoReturnValue.Success:
							bool_2 = true;
							break;
						case AddCargoReturnValue.Impossible:
							break;
						}
					}
					else
					{
						bool_2 = true;
					}
					break;
				}
			}
		}
		method_7();
		method_10();
		method_3();
	}

	private void method_31(object sender, EventArgs e)
	{
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		GeneratedMissions.Clear();
		foreach (KeyValuePair<ActiveUnit, Transport> transport in TransportList)
		{
			Mission mission = null;
			int num = transport.Value.Waves.Count * 10;
			foreach (TransportWave item in transport.Value.Waves.ToList())
			{
				mission = method_25(item, mission, num);
				item.AssociatedMission = (CargoMission)mission;
				GeneratedMissions.Add(mission, item.AssociatedTransport.LandingType);
				num--;
			}
		}
		foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item2 in ChalkContainer)
		{
			if (item2.Key.SelfTransport)
			{
				GeneratedMissions.Add(method_24(item2.Key), LandingType.Amphibious);
			}
		}
		if (GeneratedMissions.Count > 0)
		{
			LandingPlan = new LandingPlan(Client.CurrentSide, GeneratedMissions.Keys.ToList(), "Landing from " + CurrentMothership.Name);
			Client.CurrentSide.LandingPlans.Add(LandingPlan);
			((Form)new ConfirmLandingPlanDialog
			{
				landingPlannerWindow = this
			}).ShowDialog();
		}
		else
		{
			MessageBox.Show("The landing plan was not able to generate any mission", "Landing Planner Generation", (MessageBoxButtons)0);
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		if (enum5_0 == (Enum5)0)
		{
			enum5_0 = (Enum5)1;
		}
		else
		{
			enum5_0 = (Enum5)0;
		}
		method_33();
	}

	private void method_33()
	{
		if (enum5_0 == (Enum5)0)
		{
			ButtonToggleEditionMode.Text = "Edition Mode : Individual Units";
		}
		else
		{
			ButtonToggleEditionMode.Text = "Edition Mode : Serial";
		}
	}

	private void method_34(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		ExportImportTool.ExportLandingPlan_Simplified(this, null, ShowErrorLogAsPopup: true, (int)DarkMessageBox.ShowInformation("Would you like to make this savefile into a more accessible, and human-readable format ?" + Environment.NewLine + "In this less reliable format, you must avoid identical names between transports, zones and motherships.", "Export mode", DarkDialogButton.YesNo) == 6);
	}

	private void method_35(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count == 0 || LV_MissionPrep.SelectedItems.ElementAt(0) == null)
		{
			return;
		}
		LandingZoneWrapper landingZoneWrapper = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
		if (landingZoneWrapper == null)
		{
			return;
		}
		if (((ComboBox)ComboBoxLandingType).SelectedIndex != 0)
		{
			if (((ComboBox)ComboBoxLandingType).SelectedIndex == 1)
			{
				AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Amphibious;
			}
			else if (((ComboBox)ComboBoxLandingType).SelectedIndex == 2)
			{
				AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Airborne;
			}
		}
		else
		{
			AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Unassigned;
		}
		method_7();
		method_5();
	}

	private void method_36(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count != 0 && LV_MissionPrep.SelectedItems.ElementAt(0) != null)
		{
			LandingZoneWrapper landingZoneWrapper = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
			if (landingZoneWrapper.LandingZoneType == LandingType.Airborne)
			{
				((ComboBox)ComboBoxLandingType).Text = "Airborne (LZ)";
			}
			else if (landingZoneWrapper.LandingZoneType == LandingType.Amphibious)
			{
				((ComboBox)ComboBoxLandingType).Text = "Amphibious (CLZ)";
			}
			else if (landingZoneWrapper.LandingZoneType == LandingType.Unassigned)
			{
				((ComboBox)ComboBoxLandingType).Text = "Unassigned";
			}
		}
	}

	private void method_37(object sender, EventArgs e)
	{
		ExportImportTool.ImportLandingPlan(this, null, ShowErrorLogAsPopup: true);
	}

	private void method_38(object sender, EventArgs e)
	{
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<DataGridViewColumn> list = new List<DataGridViewColumn>();
			foreach (DataGridViewColumn item2 in (BaseCollection)DGVMain.Columns)
			{
				DataGridViewColumn item = item2;
				list.Add(item);
			}
			list = list.OrderBy([SpecialName] (DataGridViewColumn c) => c.DisplayIndex).ToList();
			List<string> list2 = new List<string>();
			string[] value = (from DataGridViewColumn header in list
				select header.HeaderText).ToArray();
			list2.Add(string.Join(";", value));
			foreach (DataGridViewRow item3 in (IEnumerable)DGVMain.Rows)
			{
				DataGridViewRow val = item3;
				List<string> list3 = new List<string>();
				foreach (DataGridViewColumn item4 in list)
				{
					list3.Add(val.Cells[((DataGridViewBand)item4).Index].FormattedValue.ToString());
				}
				list2.Add(string.Join(";", list3.ToArray()));
			}
			list2.Add("");
			list2.Add("");
			foreach (Transport value2 in AllowedTransport.Values)
			{
				if (value2.Waves.Count == 0)
				{
					continue;
				}
				list2.Add("");
				list2.Add("---- " + value2.ActualTransport.Name + " ----");
				list2.Add("Wave;Area;Weight;PAX");
				foreach (TransportWave wave in value2.Waves)
				{
					list2.Add("");
					list2.Add("Transport Manifest for wave #" + wave.Wave);
					string[] array = new string[7] { "Chalk", "Unit Name", "Area", "Weight", "PAX", "Cargo Type", null };
					list2.Add(string.Join(";", array));
					foreach (KeyValuePair<ChalkUnit, ChalkUnit> item5 in wave.UnitsInWave)
					{
						if (item5.Key.AssociatedChalk == null)
						{
							array[0] = "Preboated";
						}
						else
						{
							array[0] = item5.Key.AssociatedChalk.ID.ToString();
						}
						array[1] = item5.Key.Unit.CargoObjectName;
						array[2] = item5.Key.Unit.RequiredArea.ToString();
						array[3] = item5.Key.Unit.RequiredMass.ToString();
						array[4] = item5.Key.Unit.RequiredCrewSpace.ToString();
						array[5] = item5.Key.Unit.RequiredCargoType.ToString();
						list2.Add(string.Join(";", array));
					}
					list2.Add("TOTAL ; --- ;" + Math.Round(wave.GetAreaTaken(), 1) + ";" + Math.Round(wave.GetMassTaken(), 1) + ";" + Math.Round(wave.GetCrewTaken(), 1));
				}
			}
			string text = Path.Combine(ExportImportTool.CreateDestinationFolder_LandingPlanner(), "LandingPlan_Report_" + CurrentMothership.Name);
			string text2 = "csv";
			int num = 0;
			string path = text + "." + text2;
			while (File.Exists(path))
			{
				num++;
				path = text + " - " + Conversions.ToString(num) + "." + text2;
			}
			File.WriteAllLines(path, list2.ToArray());
			DarkMessageBox.ShowInformation("The landing plan details was successfully exported to LandingPlan_Report_" + CurrentMothership.Name, "Landing Planner Generation");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("The landing plan details failed to export - ERROR : " + ex2.Message, "Landing Planner Generation", (MessageBoxButtons)0);
			ProjectData.ClearProjectError();
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		Process.Start(ExportImportTool.CreateDestinationFolder_LandingPlanner());
	}

	static LandingPlanner()
	{
		Class72.smethod_20();
	}
}
