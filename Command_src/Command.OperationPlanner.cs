using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class OperationPlanner : DarkSecondaryFormBase
{
	public enum SortOrderType
	{
		EstimatedExecutionTime,
		Phase,
		Operation,
		Name
	}

	public class ComboFilterWrapper
	{
		private SortOrderType sortOrderType_0;

		private string Text;

		public SortOrderType Type
		{
			get
			{
				return sortOrderType_0;
			}
			set
			{
				sortOrderType_0 = value;
			}
		}

		public string Label => Text;

		public ComboFilterWrapper(SortOrderType _Type, string _Text)
		{
			sortOrderType_0 = _Type;
			Text = _Text;
		}

		static ComboFilterWrapper()
		{
			Class72.smethod_20();
		}
	}

	[DoNotObfuscateType]
	[DoNotPrune]
	[DoNotPruneType]
	private class MissionPhaseComboWrapper
	{
		private MissionPhase missionPhase_0;

		private string string_0;

		public MissionPhase ID
		{
			get
			{
				return missionPhase_0;
			}
			set
			{
			}
		}

		public string Label
		{
			get
			{
				return string_0;
			}
			set
			{
			}
		}

		public MissionPhaseComboWrapper(MissionPhase missionPhase_1, string string_1)
		{
			string_0 = string_1;
			missionPhase_0 = missionPhase_1;
		}

		static MissionPhaseComboWrapper()
		{
			Class72.smethod_20();
		}
	}

	[DoNotPrune]
	[DoNotObfuscateType]
	[DoNotPruneType]
	private class MissionHL_HourComboWrapper
	{
		private object object_0;

		public Mission ID
		{
			get
			{
				return (Mission)object_0;
			}
			set
			{
			}
		}

		public string Label
		{
			get
			{
				if (!Information.IsNothing(object_0))
				{
					return ((ScenarioObject)object_0).Name;
				}
				return "None";
			}
			set
			{
			}
		}

		public MissionHL_HourComboWrapper(Mission mission_0)
		{
			object_0 = mission_0;
		}

		static MissionHL_HourComboWrapper()
		{
			Class72.smethod_20();
		}
	}

	[DoNotPrune]
	[DoNotPruneType]
	[DoNotObfuscateType]
	private class MissionWrapper
	{
		public object object_0;

		public int Priority
		{
			get
			{
				return ((Mission)object_0).PriorityWeight;
			}
			set
			{
				((Mission)object_0).PriorityWeight = value;
			}
		}

		public string OperationName
		{
			get
			{
				string text = "";
				if (string.IsNullOrEmpty(((Mission)object_0).OperationName))
				{
					text = " Mobilised/Assigned Units [" + ((Mission)object_0).UnitsAssignedToMission.Count + "/" + (((Mission)object_0).UnitsQueuedToMission.Count + ((Mission)object_0).UnitsAssignedToMission.Count) + "]";
				}
				return ((Mission)object_0).OperationName + text;
			}
			set
			{
				((Mission)object_0).OperationName = value;
			}
		}

		public string Name
		{
			get
			{
				return ((ScenarioObject)object_0).Name;
			}
			set
			{
				((ScenarioObject)object_0).Name = value;
			}
		}

		public bool BulkSelection
		{
			get
			{
				return ((Mission)object_0).MarkedForBulkEdition;
			}
			set
			{
				((Mission)object_0).MarkedForBulkEdition = value;
			}
		}

		public bool Activation
		{
			get
			{
				return ((Mission)object_0).IsActive;
			}
			set
			{
				if (!value)
				{
					((Mission)object_0).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
				}
				else
				{
					((Mission)object_0).set_Status(Client.CurrentScenario, Mission.MissionStatus.Active);
				}
			}
		}

		public string ExecutionTime
		{
			get
			{
				if (((Mission)object_0).EstimatedExecutionTime == -500)
				{
					return "- Unpredictable -";
				}
				return "H+ " + new TimeSpan(0, 0, ((Mission)object_0).EstimatedExecutionTime);
			}
			set
			{
			}
		}

		public string Type
		{
			get
			{
				string text = ((Mission)object_0).get_DescriptionString(Client.CurrentScenario);
				if (((Mission)object_0).CreationMode == MissionCreationType.LandingPlanner)
				{
					text += " (Landing plan)";
				}
				else if (((Mission)object_0).CreationMode == MissionCreationType.Generated)
				{
					text += " (generated)";
				}
				return text;
			}
			set
			{
			}
		}

		public MissionWrapper(Mission mission_0)
		{
			object_0 = mission_0;
		}

		static MissionWrapper()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SerialEditor")]
	private DarkUIButton _Button_SerialEditor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LandingPlanner")]
	private DarkUIButton _Button_LandingPlanner;

	[CompilerGenerated]
	[AccessedThroughProperty("MainDGV")]
	private DataGridView _MainDGV;

	[AccessedThroughProperty("Button_MissionEditor")]
	[CompilerGenerated]
	private DarkUIButton _Button_MissionEditor;

	[AccessedThroughProperty("CB_StartOfMission_DateTimeReachedPanel")]
	[CompilerGenerated]
	private DarkCheckBox _CB_StartOfMission_DateTimeReachedPanel;

	[AccessedThroughProperty("CB_DateTimeEndMission")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DateTimeEndMission;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_HHourDate")]
	private DateTimePicker _DatePicker_HHourDate;

	[AccessedThroughProperty("Button_MissionFinishedCriteriaAdd")]
	[CompilerGenerated]
	private DarkUIButton _Button_MissionFinishedCriteriaAdd;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_StartOfMission_UnitUnloadedPctPanel")]
	private DarkCheckBox _CB_StartOfMission_UnitUnloadedPctPanel;

	[CompilerGenerated]
	[AccessedThroughProperty("Combobox_OperatorDateAndTime")]
	private ComboBox _Combobox_OperatorDateAndTime;

	[CompilerGenerated]
	[AccessedThroughProperty("Combobox_OperatorMissionFinished")]
	private ComboBox _Combobox_OperatorMissionFinished;

	[AccessedThroughProperty("ComboMissionEndElapsed")]
	[CompilerGenerated]
	private ComboBox _ComboMissionEndElapsed;

	[AccessedThroughProperty("DatePicker_HHourTime")]
	[CompilerGenerated]
	private DateTimePicker _DatePicker_HHourTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_StartMission_Time")]
	private DateTimePicker _DateTimePicker_StartMission_Time;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_LHourTime")]
	private DateTimePicker _DatePicker_LHourTime;

	[AccessedThroughProperty("DatePicker_LHourDate")]
	[CompilerGenerated]
	private DateTimePicker PtnHoOokvGA;

	[AccessedThroughProperty("Combobox_OperatorLuaScript")]
	[CompilerGenerated]
	private ComboBox _Combobox_OperatorLuaScript;

	[AccessedThroughProperty("CB_LuaScript")]
	[CompilerGenerated]
	private DarkCheckBox _CB_LuaScript;

	[AccessedThroughProperty("ComboBox_HHourMissionStart")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_HHourMissionStart;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_LHourMissionStart")]
	private DarkUIComboBox _ComboBox_LHourMissionStart;

	[CompilerGenerated]
	[AccessedThroughProperty("UiUpdateTimer")]
	private Timer timer_0;

	[AccessedThroughProperty("Button_MissionFinishedCriteriaRemove")]
	[CompilerGenerated]
	private DarkUIButton _Button_MissionFinishedCriteriaRemove;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirmScript")]
	private DarkUIButton _ButtonConfirmScript;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirmScriptMissionComplete")]
	private DarkUIButton _ButtonConfirmScriptMissionComplete;

	[AccessedThroughProperty("ComboBox_EndMissionLuaScript")]
	[CompilerGenerated]
	private ComboBox _ComboBox_EndMissionLuaScript;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EndMissionLua")]
	private DarkCheckBox _CB_EndMissionLua;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonResetTimer")]
	private DarkUIButton _ButtonResetTimer;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker1")]
	private DateTimePicker _DateTimePicker1;

	[AccessedThroughProperty("LabelHPlus")]
	[CompilerGenerated]
	private DarkLabel darkLabel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelLPlus")]
	private DarkLabel darkLabel_1;

	[AccessedThroughProperty("ButtonSImulate")]
	[CompilerGenerated]
	private DarkUIButton _ButtonSImulate;

	[AccessedThroughProperty("DateTimePicker_StartMission_Time_DaysCount")]
	[CompilerGenerated]
	private NumericUpDown _DateTimePicker_StartMission_Time_DaysCount;

	[AccessedThroughProperty("TimeElpasedFulfillTrigger_DayCOunt")]
	[CompilerGenerated]
	private NumericUpDown _TimeElpasedFulfillTrigger_DayCOunt;

	[AccessedThroughProperty("CB_LockHhour_LHour")]
	[CompilerGenerated]
	private CheckBox _CB_LockHhour_LHour;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel10")]
	private DarkLabel darkLabel_2;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel12")]
	private DarkLabel darkLabel_3;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton2")]
	private DarkUIButton _DarkUIButton2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AUTOSIMULATE")]
	private DarkUIButton _CB_AUTOSIMULATE;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel11")]
	private DarkLabel darkLabel_4;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonStartTriggerPlusMinusToggle")]
	private DarkUIButton _ButtonStartTriggerPlusMinusToggle;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel13")]
	private DarkLabel darkLabel_5;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PerformFilter")]
	private DarkUIButton _Button_PerformFilter;

	[AccessedThroughProperty("ComboSortOrder")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboSortOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel14")]
	private DarkLabel darkLabel_6;

	[AccessedThroughProperty("Button_BulkAction_Delete")]
	[CompilerGenerated]
	private DarkUIButton _Button_BulkAction_Delete;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_UnassignAll")]
	private DarkUIButton _Button_BulkAction_UnassignAll;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_Activate")]
	private DarkUIButton _Button_BulkAction_Activate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_Desactivate")]
	private DarkUIButton _Button_BulkAction_Desactivate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_UnassignAllQueud")]
	private DarkUIButton _Button_BulkAction_UnassignAllQueud;

	[AccessedThroughProperty("Button_CheckAll")]
	[CompilerGenerated]
	private DarkUIButton _Button_CheckAll;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UnCheckAll")]
	private DarkUIButton _Button_UnCheckAll;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_BulkPhase")]
	private DarkUIComboBox _ComboBox_BulkPhase;

	private BindingSource bindingSource_0;

	private MissionWrapper missionWrapper_0;

	private Dictionary<Mission, MissionWrapper> dictionary_0;

	private Dictionary<Mission, Mission> dictionary_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private int int_0;

	private int int_1;

	internal virtual DarkUIButton Button_SerialEditor
	{
		[CompilerGenerated]
		get
		{
			return _Button_SerialEditor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _Button_SerialEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_SerialEditor = value;
			darkUIButton = _Button_SerialEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_LandingPlanner
	{
		[CompilerGenerated]
		get
		{
			return _Button_LandingPlanner;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_53;
			DarkUIButton darkUIButton = _Button_LandingPlanner;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_LandingPlanner = value;
			darkUIButton = _Button_LandingPlanner;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DataGridView MainDGV
	{
		[CompilerGenerated]
		get
		{
			return _MainDGV;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			DataGridViewEditingControlShowingEventHandler val = new DataGridViewEditingControlShowingEventHandler(method_26);
			EventHandler eventHandler = method_29;
			DataGridViewCellMouseEventHandler val2 = new DataGridViewCellMouseEventHandler(method_57);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_58);
			DataGridView val4 = _MainDGV;
			if (val4 != null)
			{
				val4.EditingControlShowing -= val;
				val4.SelectionChanged -= eventHandler;
				val4.CellMouseUp -= val2;
				val4.CellValueChanged -= val3;
			}
			_MainDGV = value;
			val4 = _MainDGV;
			if (val4 != null)
			{
				val4.EditingControlShowing += val;
				val4.SelectionChanged += eventHandler;
				val4.CellMouseUp += val2;
				val4.CellValueChanged += val3;
			}
		}
	}

	internal virtual DarkUIButton Button_MissionEditor
	{
		[CompilerGenerated]
		get
		{
			return _Button_MissionEditor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _Button_MissionEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_MissionEditor = value;
			darkUIButton = _Button_MissionEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GP_MissionTriggers")]
	internal virtual DarkGroupBox GP_MissionTriggers { get; set; }

	[field: AccessedThroughProperty("PanelMissionTrigger")]
	internal virtual FlowLayoutPanel PanelMissionTrigger { get; set; }

	[field: AccessedThroughProperty("StartOfMission_DateTimeReachedPanel")]
	internal virtual Panel StartOfMission_DateTimeReachedPanel { get; set; }

	internal virtual DarkCheckBox CB_StartOfMission_DateTimeReachedPanel
	{
		[CompilerGenerated]
		get
		{
			return _CB_StartOfMission_DateTimeReachedPanel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkCheckBox darkCheckBox = _CB_StartOfMission_DateTimeReachedPanel;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_StartOfMission_DateTimeReachedPanel = value;
			darkCheckBox = _CB_StartOfMission_DateTimeReachedPanel;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_DateAndTime")]
	internal virtual DarkLabel LabelStatic_DateAndTime { get; set; }

	[field: AccessedThroughProperty("EndOfMission_UnitUnloadedPctPanel")]
	internal virtual Panel EndOfMission_UnitUnloadedPctPanel { get; set; }

	[field: AccessedThroughProperty("GP_EndMissionCriteria")]
	internal virtual DarkGroupBox GP_EndMissionCriteria { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	[field: AccessedThroughProperty("Panel_DateTimeEndMissionCriteria")]
	internal virtual Panel Panel_DateTimeEndMissionCriteria { get; set; }

	internal virtual DarkCheckBox CB_DateTimeEndMission
	{
		[CompilerGenerated]
		get
		{
			return _CB_DateTimeEndMission;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkCheckBox darkCheckBox = _CB_DateTimeEndMission;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_DateTimeEndMission = value;
			darkCheckBox = _CB_DateTimeEndMission;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_DateAndTimeEndMIssion")]
	internal virtual DarkLabel LabelStatic_DateAndTimeEndMIssion { get; set; }

	internal virtual DateTimePicker DatePicker_HHourDate
	{
		[CompilerGenerated]
		get
		{
			return _DatePicker_HHourDate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DateTimePicker val = _DatePicker_HHourDate;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DatePicker_HHourDate = value;
			val = _DatePicker_HHourDate;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_MissionFinishedCriteriaAdd
	{
		[CompilerGenerated]
		get
		{
			return _Button_MissionFinishedCriteriaAdd;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkUIButton darkUIButton = _Button_MissionFinishedCriteriaAdd;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_MissionFinishedCriteriaAdd = value;
			darkUIButton = _Button_MissionFinishedCriteriaAdd;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_MIssionFinished")]
	internal virtual DarkLabel LabelStatic_MIssionFinished { get; set; }

	internal virtual DarkCheckBox CB_StartOfMission_UnitUnloadedPctPanel
	{
		[CompilerGenerated]
		get
		{
			return _CB_StartOfMission_UnitUnloadedPctPanel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkCheckBox darkCheckBox = _CB_StartOfMission_UnitUnloadedPctPanel;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_StartOfMission_UnitUnloadedPctPanel = value;
			darkCheckBox = _CB_StartOfMission_UnitUnloadedPctPanel;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual ComboBox Combobox_OperatorDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return _Combobox_OperatorDateAndTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_44;
			ComboBox val = _Combobox_OperatorDateAndTime;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_Combobox_OperatorDateAndTime = value;
			val = _Combobox_OperatorDateAndTime;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual ComboBox Combobox_OperatorMissionFinished
	{
		[CompilerGenerated]
		get
		{
			return _Combobox_OperatorMissionFinished;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			ComboBox val = _Combobox_OperatorMissionFinished;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_Combobox_OperatorMissionFinished = value;
			val = _Combobox_OperatorMissionFinished;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual ComboBox ComboMissionEndElapsed
	{
		[CompilerGenerated]
		get
		{
			return _ComboMissionEndElapsed;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_46;
			ComboBox val = _ComboMissionEndElapsed;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_ComboMissionEndElapsed = value;
			val = _ComboMissionEndElapsed;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_HHourTime
	{
		[CompilerGenerated]
		get
		{
			return _DatePicker_HHourTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DateTimePicker val = _DatePicker_HHourTime;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DatePicker_HHourTime = value;
			val = _DatePicker_HHourTime;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DateTimePicker_StartMission_Time
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_StartMission_Time;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DateTimePicker val = _DateTimePicker_StartMission_Time;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DateTimePicker_StartMission_Time = value;
			val = _DateTimePicker_StartMission_Time;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_LHourTime
	{
		[CompilerGenerated]
		get
		{
			return _DatePicker_LHourTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DateTimePicker val = _DatePicker_LHourTime;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DatePicker_LHourTime = value;
			val = _DatePicker_LHourTime;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_LHourDate
	{
		[CompilerGenerated]
		get
		{
			return PtnHoOokvGA;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DateTimePicker val = PtnHoOokvGA;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			PtnHoOokvGA = value;
			val = PtnHoOokvGA;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Panel_LuaScriptCriteria")]
	internal virtual Panel Panel_LuaScriptCriteria { get; set; }

	internal virtual ComboBox Combobox_OperatorLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _Combobox_OperatorLuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_45;
			ComboBox val = _Combobox_OperatorLuaScript;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_Combobox_OperatorLuaScript = value;
			val = _Combobox_OperatorLuaScript;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_LuaScript")]
	internal virtual DarkLabel LabelStatic_LuaScript { get; set; }

	internal virtual DarkCheckBox CB_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return _CB_LuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkCheckBox darkCheckBox = _CB_LuaScript;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_LuaScript = value;
			darkCheckBox = _CB_LuaScript;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("HHourGroupBox")]
	internal virtual DarkGroupBox HHourGroupBox { get; set; }

	internal virtual DarkUIComboBox ComboBox_HHourMissionStart
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_HHourMissionStart;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIComboBox darkUIComboBox = _ComboBox_HHourMissionStart;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_HHourMissionStart = value;
			darkUIComboBox = _ComboBox_HHourMissionStart;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LHourGroupBox")]
	internal virtual DarkGroupBox LHourGroupBox { get; set; }

	internal virtual DarkUIComboBox ComboBox_LHourMissionStart
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_LHourMissionStart;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIComboBox darkUIComboBox = _ComboBox_LHourMissionStart;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox_LHourMissionStart = value;
			darkUIComboBox = _ComboBox_LHourMissionStart;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual Timer UiUpdateTimer
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LV_MissionFinishedCriteriaPool")]
	internal virtual DarkListView LV_MissionFinishedCriteriaPool { get; set; }

	[field: AccessedThroughProperty("LV_MissionFinishedCriteria_ToCheck")]
	internal virtual DarkListView LV_MissionFinishedCriteria_ToCheck { get; set; }

	internal virtual DarkUIButton Button_MissionFinishedCriteriaRemove
	{
		[CompilerGenerated]
		get
		{
			return _Button_MissionFinishedCriteriaRemove;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkUIButton darkUIButton = _Button_MissionFinishedCriteriaRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_MissionFinishedCriteriaRemove = value;
			darkUIButton = _Button_MissionFinishedCriteriaRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIButton ButtonConfirmScript
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirmScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkUIButton darkUIButton = _ButtonConfirmScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirmScript = value;
			darkUIButton = _ButtonConfirmScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("EndMissionTimeElapsedProgressBar")]
	internal virtual DarkUIProgressBar EndMissionTimeElapsedProgressBar { get; set; }

	[field: AccessedThroughProperty("Panel_EndMissionLua")]
	internal virtual Panel Panel_EndMissionLua { get; set; }

	internal virtual DarkUIButton ButtonConfirmScriptMissionComplete
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirmScriptMissionComplete;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			DarkUIButton darkUIButton = _ButtonConfirmScriptMissionComplete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirmScriptMissionComplete = value;
			darkUIButton = _ButtonConfirmScriptMissionComplete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox ComboBox_EndMissionLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_EndMissionLuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			ComboBox val = _ComboBox_EndMissionLuaScript;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_ComboBox_EndMissionLuaScript = value;
			val = _ComboBox_EndMissionLuaScript;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkCheckBox CB_EndMissionLua
	{
		[CompilerGenerated]
		get
		{
			return _CB_EndMissionLua;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkCheckBox darkCheckBox = _CB_EndMissionLua;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_EndMissionLua = value;
			darkCheckBox = _CB_EndMissionLua;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkUITextBox1")]
	internal virtual DarkUITextBox DarkUITextBox1 { get; set; }

	[field: AccessedThroughProperty("Darox1")]
	internal virtual DarkUITextBox Darox1 { get; set; }

	[field: AccessedThroughProperty("DarkRichTextBox1")]
	internal virtual DarkRichTextBox DarkRichTextBox1 { get; set; }

	[field: AccessedThroughProperty("ComboBox1")]
	internal virtual ComboBox ComboBox1 { get; set; }

	internal virtual DarkUIButton ButtonResetTimer
	{
		[CompilerGenerated]
		get
		{
			return _ButtonResetTimer;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_42;
			DarkUIButton darkUIButton = _ButtonResetTimer;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonResetTimer = value;
			darkUIButton = _ButtonResetTimer;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DateTimePicker DateTimePicker1
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			DateTimePicker val = _DateTimePicker1;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DateTimePicker1 = value;
			val = _DateTimePicker1;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DarkLabel LabelHPlus
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

	[field: AccessedThroughProperty("LabelEstimatedTotalTime")]
	internal virtual DarkLabel LabelEstimatedTotalTime { get; set; }

	internal virtual DarkLabel LabelLPlus
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_1;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_1 = value;
		}
	}

	[field: AccessedThroughProperty("Button2")]
	internal virtual Button Button2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	internal virtual DarkUIButton ButtonSImulate
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSImulate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkUIButton darkUIButton = _ButtonSImulate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSImulate = value;
			darkUIButton = _ButtonSImulate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	internal virtual NumericUpDown DateTimePicker_StartMission_Time_DaysCount
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_StartMission_Time_DaysCount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			NumericUpDown val = _DateTimePicker_StartMission_Time_DaysCount;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_DateTimePicker_StartMission_Time_DaysCount = value;
			val = _DateTimePicker_StartMission_Time_DaysCount;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	internal virtual NumericUpDown TimeElpasedFulfillTrigger_DayCOunt
	{
		[CompilerGenerated]
		get
		{
			return _TimeElpasedFulfillTrigger_DayCOunt;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			NumericUpDown val = _TimeElpasedFulfillTrigger_DayCOunt;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_TimeElpasedFulfillTrigger_DayCOunt = value;
			val = _TimeElpasedFulfillTrigger_DayCOunt;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8 { get; set; }

	[field: AccessedThroughProperty("ProgressBarHPlusTriggerStartTime")]
	internal virtual DarkUIProgressBar ProgressBarHPlusTriggerStartTime { get; set; }

	internal virtual CheckBox CB_LockHhour_LHour
	{
		[CompilerGenerated]
		get
		{
			return _CB_LockHhour_LHour;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_52;
			CheckBox val = _CB_LockHhour_LHour;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_LockHhour_LHour = value;
			val = _CB_LockHhour_LHour;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel9")]
	internal virtual DarkLabel DarkLabel9 { get; set; }

	[field: AccessedThroughProperty("StarLuaDescription")]
	internal virtual DarkLabel StarLuaDescription { get; set; }

	internal virtual DarkLabel DarkLabel10
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_2;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_2 = value;
		}
	}

	[field: AccessedThroughProperty("EndMissionLuaDescription")]
	internal virtual DarkLabel EndMissionLuaDescription { get; set; }

	internal virtual DarkLabel DarkLabel12
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_3;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_3 = value;
		}
	}

	[field: AccessedThroughProperty("LabelLHourInitialMission")]
	internal virtual DarkLabel LabelLHourInitialMission { get; set; }

	[field: AccessedThroughProperty("LabelInitialMission")]
	internal virtual DarkLabel LabelInitialMission { get; set; }

	[field: AccessedThroughProperty("CB_AUTOSIMULATEt")]
	internal virtual DarkUICheckBox CB_AUTOSIMULATEt { get; set; }

	internal virtual DarkUIButton DarkUIButton2
	{
		[CompilerGenerated]
		get
		{
			return _DarkUIButton2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkUIButton darkUIButton = _DarkUIButton2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DarkUIButton2 = value;
			darkUIButton = _DarkUIButton2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton CB_AUTOSIMULATE
	{
		[CompilerGenerated]
		get
		{
			return _CB_AUTOSIMULATE;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkUIButton darkUIButton = _CB_AUTOSIMULATE;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_CB_AUTOSIMULATE = value;
			darkUIButton = _CB_AUTOSIMULATE;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkLabel DarkLabel11
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_4;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_4 = value;
		}
	}

	internal virtual DarkUIButton ButtonStartTriggerPlusMinusToggle
	{
		[CompilerGenerated]
		get
		{
			return _ButtonStartTriggerPlusMinusToggle;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_54;
			DarkUIButton darkUIButton = _ButtonStartTriggerPlusMinusToggle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonStartTriggerPlusMinusToggle = value;
			darkUIButton = _ButtonStartTriggerPlusMinusToggle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_FilterMissions")]
	internal virtual DarkTextBox TB_FilterMissions { get; set; }

	internal virtual DarkLabel DarkLabel13
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_5;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_5 = value;
		}
	}

	internal virtual DarkUIButton Button_PerformFilter
	{
		[CompilerGenerated]
		get
		{
			return _Button_PerformFilter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_55;
			DarkUIButton darkUIButton = _Button_PerformFilter;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_PerformFilter = value;
			darkUIButton = _Button_PerformFilter;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboSortOrder
	{
		[CompilerGenerated]
		get
		{
			return _ComboSortOrder;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_56;
			DarkUIComboBox darkUIComboBox = _ComboSortOrder;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboSortOrder = value;
			darkUIComboBox = _ComboSortOrder;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkLabel DarkLabel14
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_6;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_6 = value;
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	internal virtual DarkUIButton Button_BulkAction_Delete
	{
		[CompilerGenerated]
		get
		{
			return _Button_BulkAction_Delete;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkUIButton darkUIButton = _Button_BulkAction_Delete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BulkAction_Delete = value;
			darkUIButton = _Button_BulkAction_Delete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_UnassignAll
	{
		[CompilerGenerated]
		get
		{
			return _Button_BulkAction_UnassignAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_60;
			DarkUIButton darkUIButton = _Button_BulkAction_UnassignAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BulkAction_UnassignAll = value;
			darkUIButton = _Button_BulkAction_UnassignAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_Activate
	{
		[CompilerGenerated]
		get
		{
			return _Button_BulkAction_Activate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_61;
			DarkUIButton darkUIButton = _Button_BulkAction_Activate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BulkAction_Activate = value;
			darkUIButton = _Button_BulkAction_Activate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_Desactivate
	{
		[CompilerGenerated]
		get
		{
			return _Button_BulkAction_Desactivate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_62;
			DarkUIButton darkUIButton = _Button_BulkAction_Desactivate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BulkAction_Desactivate = value;
			darkUIButton = _Button_BulkAction_Desactivate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_UnassignAllQueud
	{
		[CompilerGenerated]
		get
		{
			return _Button_BulkAction_UnassignAllQueud;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_63;
			DarkUIButton darkUIButton = _Button_BulkAction_UnassignAllQueud;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BulkAction_UnassignAllQueud = value;
			darkUIButton = _Button_BulkAction_UnassignAllQueud;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_CheckAll
	{
		[CompilerGenerated]
		get
		{
			return _Button_CheckAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_64;
			DarkUIButton darkUIButton = _Button_CheckAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CheckAll = value;
			darkUIButton = _Button_CheckAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_UnCheckAll
	{
		[CompilerGenerated]
		get
		{
			return _Button_UnCheckAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
			DarkUIButton darkUIButton = _Button_UnCheckAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_UnCheckAll = value;
			darkUIButton = _Button_UnCheckAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_BulkPhase
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_BulkPhase;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_66;
			DarkUIComboBox darkUIComboBox = _ComboBox_BulkPhase;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboBox_BulkPhase = value;
			darkUIComboBox = _ComboBox_BulkPhase;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	public OperationPlanner()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		((Form)this).Load += OperationPlanner_Load;
		((Form)this).Shown += OperationPlanner_Shown;
		bindingSource_0 = new BindingSource();
		dictionary_0 = new Dictionary<Mission, MissionWrapper>();
		dictionary_1 = new Dictionary<Mission, Mission>();
		int_0 = 0;
		int_1 = 0;
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
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Expected O, but got Unknown
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Expected O, but got Unknown
		//IL_0a49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a53: Expected O, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Expected O, but got Unknown
		//IL_0c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c38: Expected O, but got Unknown
		//IL_0e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e50: Expected O, but got Unknown
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1116: Expected O, but got Unknown
		//IL_130e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1318: Expected O, but got Unknown
		//IL_1500: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ab: Expected O, but got Unknown
		//IL_1a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2005: Expected O, but got Unknown
		//IL_20a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b2: Expected O, but got Unknown
		//IL_2239: Unknown result type (might be due to invalid IL or missing references)
		//IL_2243: Expected O, but got Unknown
		//IL_25e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e69: Expected O, but got Unknown
		//IL_2f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f94: Expected O, but got Unknown
		//IL_308a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3094: Expected O, but got Unknown
		//IL_33c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d0: Expected O, but got Unknown
		//IL_3b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b28: Expected O, but got Unknown
		//IL_3b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c05: Expected O, but got Unknown
		//IL_3f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f5b: Expected O, but got Unknown
		//IL_3ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4008: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Button_SerialEditor = new DarkUIButton();
		Button_LandingPlanner = new DarkUIButton();
		Button_MissionEditor = new DarkUIButton();
		MainDGV = new DataGridView();
		UiUpdateTimer = new Timer(icontainer_1);
		ComboBox1 = new ComboBox();
		Button2 = new Button();
		LabelLPlus = new DarkLabel();
		LabelEstimatedTotalTime = new DarkLabel();
		LabelHPlus = new DarkLabel();
		LHourGroupBox = new DarkGroupBox();
		LabelLHourInitialMission = new DarkLabel();
		ComboBox_LHourMissionStart = new DarkUIComboBox();
		DatePicker_LHourDate = new DateTimePicker();
		DatePicker_LHourTime = new DateTimePicker();
		HHourGroupBox = new DarkGroupBox();
		LabelInitialMission = new DarkLabel();
		ComboBox_HHourMissionStart = new DarkUIComboBox();
		DatePicker_HHourDate = new DateTimePicker();
		DatePicker_HHourTime = new DateTimePicker();
		GP_EndMissionCriteria = new DarkGroupBox();
		DarkLabel5 = new DarkLabel();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		Panel_DateTimeEndMissionCriteria = new Panel();
		TimeElpasedFulfillTrigger_DayCOunt = new NumericUpDown();
		DarkLabel8 = new DarkLabel();
		DateTimePicker1 = new DateTimePicker();
		ButtonResetTimer = new DarkUIButton();
		EndMissionTimeElapsedProgressBar = new DarkUIProgressBar();
		ComboMissionEndElapsed = new ComboBox();
		CB_DateTimeEndMission = new DarkCheckBox();
		LabelStatic_DateAndTimeEndMIssion = new DarkLabel();
		Panel_EndMissionLua = new Panel();
		EndMissionLuaDescription = new DarkLabel();
		DarkLabel12 = new DarkLabel();
		ButtonConfirmScriptMissionComplete = new DarkUIButton();
		ComboBox_EndMissionLuaScript = new ComboBox();
		DarkLabel3 = new DarkLabel();
		CB_EndMissionLua = new DarkCheckBox();
		GP_MissionTriggers = new DarkGroupBox();
		PanelMissionTrigger = new FlowLayoutPanel();
		StartOfMission_DateTimeReachedPanel = new Panel();
		DarkLabel11 = new DarkLabel();
		ButtonStartTriggerPlusMinusToggle = new DarkUIButton();
		ProgressBarHPlusTriggerStartTime = new DarkUIProgressBar();
		DateTimePicker_StartMission_Time_DaysCount = new NumericUpDown();
		DarkLabel7 = new DarkLabel();
		DateTimePicker_StartMission_Time = new DateTimePicker();
		Combobox_OperatorDateAndTime = new ComboBox();
		CB_StartOfMission_DateTimeReachedPanel = new DarkCheckBox();
		LabelStatic_DateAndTime = new DarkLabel();
		EndOfMission_UnitUnloadedPctPanel = new Panel();
		LV_MissionFinishedCriteriaPool = new DarkListView();
		Button_MissionFinishedCriteriaRemove = new DarkUIButton();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		LV_MissionFinishedCriteria_ToCheck = new DarkListView();
		Combobox_OperatorMissionFinished = new ComboBox();
		Button_MissionFinishedCriteriaAdd = new DarkUIButton();
		LabelStatic_MIssionFinished = new DarkLabel();
		CB_StartOfMission_UnitUnloadedPctPanel = new DarkCheckBox();
		Panel_LuaScriptCriteria = new Panel();
		StarLuaDescription = new DarkLabel();
		DarkLabel10 = new DarkLabel();
		ButtonConfirmScript = new DarkUIButton();
		Combobox_OperatorLuaScript = new ComboBox();
		LabelStatic_LuaScript = new DarkLabel();
		CB_LuaScript = new DarkCheckBox();
		DarkLabel4 = new DarkLabel();
		DarkRichTextBox1 = new DarkRichTextBox();
		DarkLabel6 = new DarkLabel();
		CB_LockHhour_LHour = new CheckBox();
		DarkLabel9 = new DarkLabel();
		TB_FilterMissions = new DarkTextBox();
		DarkLabel13 = new DarkLabel();
		DarkLabel14 = new DarkLabel();
		DarkGroupBox1 = new DarkGroupBox();
		ButtonSImulate = new DarkUIButton();
		CB_AUTOSIMULATEt = new DarkUICheckBox();
		DarkGroupBox2 = new DarkGroupBox();
		Button_UnCheckAll = new DarkUIButton();
		Button_CheckAll = new DarkUIButton();
		Label1 = new Label();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		Button_BulkAction_Delete = new DarkUIButton();
		Button_BulkAction_UnassignAll = new DarkUIButton();
		Button_BulkAction_UnassignAllQueud = new DarkUIButton();
		Button_BulkAction_Activate = new DarkUIButton();
		Button_BulkAction_Desactivate = new DarkUIButton();
		ComboBox_BulkPhase = new DarkUIComboBox();
		ComboSortOrder = new DarkUIComboBox();
		Button_PerformFilter = new DarkUIButton();
		DarkUITextBox1 = new DarkUITextBox();
		Darox1 = new DarkUITextBox();
		DarkUIButton2 = new DarkUIButton();
		CB_AUTOSIMULATE = new DarkUIButton();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MainDGV).BeginInit();
		((Control)LHourGroupBox).SuspendLayout();
		((Control)HHourGroupBox).SuspendLayout();
		((Control)GP_EndMissionCriteria).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)Panel_DateTimeEndMissionCriteria).SuspendLayout();
		((ISupportInitialize)TimeElpasedFulfillTrigger_DayCOunt).BeginInit();
		((Control)Panel_EndMissionLua).SuspendLayout();
		((Control)GP_MissionTriggers).SuspendLayout();
		((Control)PanelMissionTrigger).SuspendLayout();
		((Control)StartOfMission_DateTimeReachedPanel).SuspendLayout();
		((ISupportInitialize)DateTimePicker_StartMission_Time_DaysCount).BeginInit();
		((Control)EndOfMission_UnitUnloadedPctPanel).SuspendLayout();
		((Control)Panel_LuaScriptCriteria).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)FlowLayoutPanel1).Anchor = (AnchorStyles)9;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_SerialEditor);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_LandingPlanner);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_MissionEditor);
		((Control)FlowLayoutPanel1).Location = new Point(922, 5);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(326, 70);
		((Control)FlowLayoutPanel1).TabIndex = 52;
		((ButtonBase)Button_SerialEditor).BackColor = Color.Transparent;
		((Button)Button_SerialEditor).DialogResult = (DialogResult)0;
		((Control)Button_SerialEditor).Font = new Font("Microsoft Sans Serif", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button_SerialEditor).ForeColor = SystemColors.Control;
		((Control)Button_SerialEditor).Location = new Point(3, 3);
		((Control)Button_SerialEditor).Name = "Button_SerialEditor";
		Button_SerialEditor.RoundRadius = 0;
		((Control)Button_SerialEditor).Size = new Size(91, 31);
		((Control)Button_SerialEditor).TabIndex = 49;
		Button_SerialEditor.Text = "Serial Editor";
		((ButtonBase)Button_LandingPlanner).BackColor = Color.Transparent;
		((Button)Button_LandingPlanner).DialogResult = (DialogResult)0;
		((Control)Button_LandingPlanner).Font = new Font("Microsoft Sans Serif", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button_LandingPlanner).ForeColor = SystemColors.Control;
		((Control)Button_LandingPlanner).Location = new Point(100, 3);
		((Control)Button_LandingPlanner).Name = "Button_LandingPlanner";
		Button_LandingPlanner.RoundRadius = 0;
		((Control)Button_LandingPlanner).Size = new Size(110, 32);
		((Control)Button_LandingPlanner).TabIndex = 50;
		Button_LandingPlanner.Text = "Landing Planner";
		((ButtonBase)Button_MissionEditor).BackColor = Color.Transparent;
		((Button)Button_MissionEditor).DialogResult = (DialogResult)0;
		((Control)Button_MissionEditor).Font = new Font("Microsoft Sans Serif", 10.5f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button_MissionEditor).ForeColor = SystemColors.Control;
		((Control)Button_MissionEditor).Location = new Point(216, 3);
		((Control)Button_MissionEditor).Name = "Button_MissionEditor";
		Button_MissionEditor.RoundRadius = 0;
		((Control)Button_MissionEditor).Size = new Size(104, 32);
		((Control)Button_MissionEditor).TabIndex = 51;
		Button_MissionEditor.Text = "Mission Editor";
		MainDGV.AllowUserToAddRows = false;
		MainDGV.AllowUserToDeleteRows = false;
		MainDGV.AllowUserToResizeColumns = false;
		MainDGV.AllowUserToResizeRows = false;
		((Control)MainDGV).Anchor = (AnchorStyles)15;
		val.Alignment = (DataGridViewContentAlignment)32;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		MainDGV.ColumnHeadersDefaultCellStyle = val;
		MainDGV.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)32;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.ControlText;
		val2.WrapMode = (DataGridViewTriState)2;
		MainDGV.DefaultCellStyle = val2;
		MainDGV.EditMode = (DataGridViewEditMode)0;
		((Control)MainDGV).Location = new Point(8, 106);
		((Control)MainDGV).MinimumSize = new Size(803, 514);
		MainDGV.MultiSelect = false;
		((Control)MainDGV).Name = "MainDGV";
		MainDGV.RowHeadersVisible = false;
		MainDGV.RowHeadersWidth = 62;
		MainDGV.RowTemplate.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
		MainDGV.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		MainDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		((Control)MainDGV).Size = new Size(903, 552);
		((Control)MainDGV).TabIndex = 53;
		UiUpdateTimer.Interval = 250;
		((ListControl)ComboBox1).FormattingEnabled = true;
		ComboBox1.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)ComboBox1).Location = new Point(226, 3);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(55, 21);
		((Control)ComboBox1).TabIndex = 36;
		((ButtonBase)Button2).BackColor = Color.Firebrick;
		((ButtonBase)Button2).FlatStyle = (FlatStyle)0;
		((Control)Button2).Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(128, 40);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Size = new Size(71, 23);
		((Control)Button2).TabIndex = 69;
		((ButtonBase)Button2).Text = "Start Now !";
		((ButtonBase)Button2).UseVisualStyleBackColor = false;
		LabelLPlus.AutoSize = true;
		((Control)LabelLPlus).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LabelLPlus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelLPlus).Location = new Point(6, 43);
		((Control)LabelLPlus).Name = "LabelLPlus";
		((Control)LabelLPlus).Size = new Size(106, 24);
		((Control)LabelLPlus).TabIndex = 68;
		((Label)LabelLPlus).Text = "L+ 00:00:00";
		LabelEstimatedTotalTime.AutoSize = true;
		((Control)LabelEstimatedTotalTime).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LabelEstimatedTotalTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelEstimatedTotalTime).Location = new Point(6, 69);
		((Control)LabelEstimatedTotalTime).Name = "LabelEstimatedTotalTime";
		((Control)LabelEstimatedTotalTime).Size = new Size(163, 24);
		((Control)LabelEstimatedTotalTime).TabIndex = 67;
		((Label)LabelEstimatedTotalTime).Text = "Est. Unpredictable";
		((Label)LabelEstimatedTotalTime).TextAlign = (ContentAlignment)32;
		LabelHPlus.AutoSize = true;
		((Control)LabelHPlus).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LabelHPlus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelHPlus).Location = new Point(6, 17);
		((Control)LabelHPlus).Name = "LabelHPlus";
		((Control)LabelHPlus).Size = new Size(110, 24);
		((Control)LabelHPlus).TabIndex = 66;
		((Label)LabelHPlus).Text = "H+ 50:35:25";
		((Control)LHourGroupBox).Controls.Add((Control)(object)LabelLHourInitialMission);
		((Control)LHourGroupBox).Controls.Add((Control)(object)ComboBox_LHourMissionStart);
		((Control)LHourGroupBox).Controls.Add((Control)(object)DatePicker_LHourDate);
		((Control)LHourGroupBox).Controls.Add((Control)(object)DatePicker_LHourTime);
		((Control)LHourGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LHourGroupBox).Location = new Point(266, 1);
		((Control)LHourGroupBox).Name = "LHourGroupBox";
		((Control)LHourGroupBox).Size = new Size(221, 68);
		((Control)LHourGroupBox).TabIndex = 65;
		((GroupBox)LHourGroupBox).TabStop = false;
		((GroupBox)LHourGroupBox).Text = "L-Hour (Zulu)";
		LabelLHourInitialMission.AutoSize = true;
		((Control)LabelLHourInitialMission).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelLHourInitialMission).Location = new Point(6, 47);
		((Control)LabelLHourInitialMission).Name = "LabelLHourInitialMission";
		((Control)LabelLHourInitialMission).Size = new Size(75, 13);
		((Control)LabelLHourInitialMission).TabIndex = 64;
		((Label)LabelLHourInitialMission).Text = "Initial Mission :";
		((ComboBox)ComboBox_LHourMissionStart).BackColor = Color.Transparent;
		((ComboBox)ComboBox_LHourMissionStart).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_LHourMissionStart).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_LHourMissionStart).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_LHourMissionStart).FormattingEnabled = true;
		((Control)ComboBox_LHourMissionStart).Location = new Point(87, 42);
		((Control)ComboBox_LHourMissionStart).Name = "ComboBox_LHourMissionStart";
		((Control)ComboBox_LHourMissionStart).Size = new Size(128, 21);
		((Control)ComboBox_LHourMissionStart).TabIndex = 62;
		DatePicker_LHourDate.CustomFormat = "d/MM/yyyy";
		DatePicker_LHourDate.Format = (DateTimePickerFormat)2;
		((Control)DatePicker_LHourDate).Location = new Point(6, 18);
		((Control)DatePicker_LHourDate).Name = "DatePicker_LHourDate";
		((Control)DatePicker_LHourDate).Size = new Size(116, 20);
		((Control)DatePicker_LHourDate).TabIndex = 62;
		DatePicker_LHourTime.CustomFormat = "HH:mm:ss";
		DatePicker_LHourTime.Format = (DateTimePickerFormat)8;
		((Control)DatePicker_LHourTime).Location = new Point(128, 18);
		((Control)DatePicker_LHourTime).Name = "DatePicker_LHourTime";
		DatePicker_LHourTime.ShowUpDown = true;
		((Control)DatePicker_LHourTime).Size = new Size(87, 20);
		((Control)DatePicker_LHourTime).TabIndex = 63;
		((Control)HHourGroupBox).Controls.Add((Control)(object)LabelInitialMission);
		((Control)HHourGroupBox).Controls.Add((Control)(object)ComboBox_HHourMissionStart);
		((Control)HHourGroupBox).Controls.Add((Control)(object)DatePicker_HHourDate);
		((Control)HHourGroupBox).Controls.Add((Control)(object)DatePicker_HHourTime);
		((Control)HHourGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)HHourGroupBox).Location = new Point(13, 2);
		((Control)HHourGroupBox).Name = "HHourGroupBox";
		((Control)HHourGroupBox).Size = new Size(221, 68);
		((Control)HHourGroupBox).TabIndex = 64;
		((GroupBox)HHourGroupBox).TabStop = false;
		((GroupBox)HHourGroupBox).Text = "H-Hour (Zulu)";
		LabelInitialMission.AutoSize = true;
		((Control)LabelInitialMission).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelInitialMission).Location = new Point(6, 45);
		((Control)LabelInitialMission).Name = "LabelInitialMission";
		((Control)LabelInitialMission).Size = new Size(75, 13);
		((Control)LabelInitialMission).TabIndex = 63;
		((Label)LabelInitialMission).Text = "Initial Mission :";
		((ComboBox)ComboBox_HHourMissionStart).BackColor = Color.Transparent;
		((ComboBox)ComboBox_HHourMissionStart).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_HHourMissionStart).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_HHourMissionStart).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_HHourMissionStart).FormattingEnabled = true;
		((Control)ComboBox_HHourMissionStart).Location = new Point(87, 41);
		((Control)ComboBox_HHourMissionStart).Name = "ComboBox_HHourMissionStart";
		((Control)ComboBox_HHourMissionStart).Size = new Size(129, 21);
		((Control)ComboBox_HHourMissionStart).TabIndex = 62;
		DatePicker_HHourDate.CustomFormat = "d/MM/yyyy";
		DatePicker_HHourDate.Format = (DateTimePickerFormat)2;
		((Control)DatePicker_HHourDate).Location = new Point(6, 18);
		((Control)DatePicker_HHourDate).Name = "DatePicker_HHourDate";
		((Control)DatePicker_HHourDate).Size = new Size(116, 20);
		((Control)DatePicker_HHourDate).TabIndex = 57;
		DatePicker_HHourTime.CustomFormat = "HH:mm:ss";
		DatePicker_HHourTime.Format = (DateTimePickerFormat)8;
		((Control)DatePicker_HHourTime).Location = new Point(128, 18);
		((Control)DatePicker_HHourTime).Name = "DatePicker_HHourTime";
		DatePicker_HHourTime.ShowUpDown = true;
		((Control)DatePicker_HHourTime).Size = new Size(88, 20);
		((Control)DatePicker_HHourTime).TabIndex = 61;
		((Control)GP_EndMissionCriteria).Anchor = (AnchorStyles)10;
		((Control)GP_EndMissionCriteria).Controls.Add((Control)(object)DarkLabel5);
		((Control)GP_EndMissionCriteria).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)GP_EndMissionCriteria).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GP_EndMissionCriteria).Location = new Point(922, 541);
		((Control)GP_EndMissionCriteria).Name = "GP_EndMissionCriteria";
		((Control)GP_EndMissionCriteria).Size = new Size(322, 158);
		((Control)GP_EndMissionCriteria).TabIndex = 56;
		((GroupBox)GP_EndMissionCriteria).TabStop = false;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(6, -4);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(259, 20);
		((Control)DarkLabel5).TabIndex = 34;
		((Label)DarkLabel5).Text = "Triggers to Tag Mission as Satisfied";
		((Control)FlowLayoutPanel2).Anchor = (AnchorStyles)3;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Panel_DateTimeEndMissionCriteria);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Panel_EndMissionLua);
		FlowLayoutPanel2.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel2).Location = new Point(6, 19);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(311, 133);
		((Control)FlowLayoutPanel2).TabIndex = 32;
		FlowLayoutPanel2.WrapContents = false;
		Panel_DateTimeEndMissionCriteria.BorderStyle = (BorderStyle)1;
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)TimeElpasedFulfillTrigger_DayCOunt);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)DarkLabel8);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)DateTimePicker1);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)ButtonResetTimer);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)EndMissionTimeElapsedProgressBar);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)ComboMissionEndElapsed);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)CB_DateTimeEndMission);
		((Control)Panel_DateTimeEndMissionCriteria).Controls.Add((Control)(object)LabelStatic_DateAndTimeEndMIssion);
		((Control)Panel_DateTimeEndMissionCriteria).Location = new Point(3, 6);
		((Control)Panel_DateTimeEndMissionCriteria).Margin = new Padding(3, 6, 3, 6);
		((Control)Panel_DateTimeEndMissionCriteria).Name = "Panel_DateTimeEndMissionCriteria";
		((Control)Panel_DateTimeEndMissionCriteria).Size = new Size(304, 51);
		((Control)Panel_DateTimeEndMissionCriteria).TabIndex = 9;
		((Control)TimeElpasedFulfillTrigger_DayCOunt).Location = new Point(102, 4);
		((Control)TimeElpasedFulfillTrigger_DayCOunt).Name = "TimeElpasedFulfillTrigger_DayCOunt";
		((Control)TimeElpasedFulfillTrigger_DayCOunt).Size = new Size(35, 20);
		((Control)TimeElpasedFulfillTrigger_DayCOunt).TabIndex = 69;
		DarkLabel8.AutoSize = true;
		((Control)DarkLabel8).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel8).Location = new Point(138, 6);
		((Control)DarkLabel8).Name = "DarkLabel8";
		((Control)DarkLabel8).Size = new Size(34, 15);
		((Control)DarkLabel8).TabIndex = 68;
		((Label)DarkLabel8).Text = "Days";
		((Label)DarkLabel8).TextAlign = (ContentAlignment)16;
		DateTimePicker1.CustomFormat = "HH:mm:ss";
		DateTimePicker1.Format = (DateTimePickerFormat)8;
		((Control)DateTimePicker1).Location = new Point(175, 5);
		DateTimePicker1.MaxDate = new DateTime(2000, 2, 1, 0, 0, 0, 0);
		DateTimePicker1.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		((Control)DateTimePicker1).Name = "DateTimePicker1";
		DateTimePicker1.ShowUpDown = true;
		((Control)DateTimePicker1).Size = new Size(66, 20);
		((Control)DateTimePicker1).TabIndex = 66;
		DateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		((ButtonBase)ButtonResetTimer).BackColor = Color.Transparent;
		((Button)ButtonResetTimer).DialogResult = (DialogResult)0;
		((Control)ButtonResetTimer).ForeColor = SystemColors.Control;
		((Control)ButtonResetTimer).Location = new Point(244, 28);
		((Control)ButtonResetTimer).Name = "ButtonResetTimer";
		ButtonResetTimer.RoundRadius = 0;
		((Control)ButtonResetTimer).Size = new Size(55, 18);
		((Control)ButtonResetTimer).TabIndex = 39;
		ButtonResetTimer.Text = "Reset";
		((Control)EndMissionTimeElapsedProgressBar).BackColor = Color.Transparent;
		EndMissionTimeElapsedProgressBar.CustomForeColor = Color.Transparent;
		((Control)EndMissionTimeElapsedProgressBar).Location = new Point(6, 28);
		EndMissionTimeElapsedProgressBar.Maximum = 100;
		((Control)EndMissionTimeElapsedProgressBar).Name = "EndMissionTimeElapsedProgressBar";
		EndMissionTimeElapsedProgressBar.ShowProgressLines = true;
		EndMissionTimeElapsedProgressBar.ShowProgressValue = true;
		EndMissionTimeElapsedProgressBar.ShowText = false;
		((Control)EndMissionTimeElapsedProgressBar).Size = new Size(235, 18);
		((Control)EndMissionTimeElapsedProgressBar).TabIndex = 40;
		((Control)EndMissionTimeElapsedProgressBar).Text = "DarkUIProgressBar1";
		EndMissionTimeElapsedProgressBar.Value = 0;
		ComboMissionEndElapsed.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)ComboMissionEndElapsed).FormattingEnabled = true;
		ComboMissionEndElapsed.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)ComboMissionEndElapsed).Location = new Point(244, 5);
		((Control)ComboMissionEndElapsed).Name = "ComboMissionEndElapsed";
		((Control)ComboMissionEndElapsed).Size = new Size(55, 21);
		((Control)ComboMissionEndElapsed).TabIndex = 35;
		((ButtonBase)CB_DateTimeEndMission).AutoSize = true;
		((Control)CB_DateTimeEndMission).Location = new Point(7, 7);
		((Control)CB_DateTimeEndMission).Name = "CB_DateTimeEndMission";
		((Control)CB_DateTimeEndMission).Size = new Size(15, 14);
		((Control)CB_DateTimeEndMission).TabIndex = 34;
		LabelStatic_DateAndTimeEndMIssion.AutoSize = true;
		((Control)LabelStatic_DateAndTimeEndMIssion).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelStatic_DateAndTimeEndMIssion).Location = new Point(21, 8);
		((Control)LabelStatic_DateAndTimeEndMIssion).Name = "LabelStatic_DateAndTimeEndMIssion";
		((Control)LabelStatic_DateAndTimeEndMIssion).Size = new Size(71, 13);
		((Control)LabelStatic_DateAndTimeEndMIssion).TabIndex = 32;
		((Label)LabelStatic_DateAndTimeEndMIssion).Text = "Time Elapsed";
		Panel_EndMissionLua.BorderStyle = (BorderStyle)1;
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)EndMissionLuaDescription);
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)DarkLabel12);
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)ButtonConfirmScriptMissionComplete);
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)ComboBox_EndMissionLuaScript);
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)DarkLabel3);
		((Control)Panel_EndMissionLua).Controls.Add((Control)(object)CB_EndMissionLua);
		((Control)Panel_EndMissionLua).Location = new Point(3, 69);
		((Control)Panel_EndMissionLua).Margin = new Padding(3, 6, 3, 6);
		((Control)Panel_EndMissionLua).Name = "Panel_EndMissionLua";
		((Control)Panel_EndMissionLua).Size = new Size(304, 60);
		((Control)Panel_EndMissionLua).TabIndex = 12;
		EndMissionLuaDescription.AutoSize = true;
		((Control)EndMissionLuaDescription).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)EndMissionLuaDescription).Location = new Point(81, 33);
		((Control)EndMissionLuaDescription).Name = "EndMissionLuaDescription";
		((Control)EndMissionLuaDescription).Size = new Size(74, 13);
		((Control)EndMissionLuaDescription).TabIndex = 42;
		((Label)EndMissionLuaDescription).Text = " (25 char max)";
		DarkLabel12.AutoSize = true;
		((Control)DarkLabel12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel12).Location = new Point(8, 33);
		((Control)DarkLabel12).Name = "DarkLabel12";
		((Control)DarkLabel12).Size = new Size(66, 13);
		((Control)DarkLabel12).TabIndex = 41;
		((Label)DarkLabel12).Text = "Description :";
		((ButtonBase)ButtonConfirmScriptMissionComplete).BackColor = Color.Transparent;
		((Button)ButtonConfirmScriptMissionComplete).DialogResult = (DialogResult)0;
		((Control)ButtonConfirmScriptMissionComplete).ForeColor = SystemColors.Control;
		((Control)ButtonConfirmScriptMissionComplete).Location = new Point(123, 4);
		((Control)ButtonConfirmScriptMissionComplete).Name = "ButtonConfirmScriptMissionComplete";
		ButtonConfirmScriptMissionComplete.RoundRadius = 0;
		((Control)ButtonConfirmScriptMissionComplete).Size = new Size(117, 22);
		((Control)ButtonConfirmScriptMissionComplete).TabIndex = 38;
		ButtonConfirmScriptMissionComplete.Text = "Edit Script";
		ComboBox_EndMissionLuaScript.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)ComboBox_EndMissionLuaScript).FormattingEnabled = true;
		ComboBox_EndMissionLuaScript.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)ComboBox_EndMissionLuaScript).Location = new Point(244, 4);
		((Control)ComboBox_EndMissionLuaScript).Name = "ComboBox_EndMissionLuaScript";
		((Control)ComboBox_EndMissionLuaScript).Size = new Size(55, 21);
		((Control)ComboBox_EndMissionLuaScript).TabIndex = 36;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(22, 8);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(53, 13);
		((Control)DarkLabel3).TabIndex = 13;
		((Label)DarkLabel3).Text = "Lua script";
		((ButtonBase)CB_EndMissionLua).AutoSize = true;
		((Control)CB_EndMissionLua).Location = new Point(6, 7);
		((Control)CB_EndMissionLua).Name = "CB_EndMissionLua";
		((Control)CB_EndMissionLua).Size = new Size(15, 14);
		((Control)CB_EndMissionLua).TabIndex = 11;
		((Control)GP_MissionTriggers).Anchor = (AnchorStyles)9;
		((Control)GP_MissionTriggers).Controls.Add((Control)(object)PanelMissionTrigger);
		((Control)GP_MissionTriggers).Controls.Add((Control)(object)DarkLabel4);
		((Control)GP_MissionTriggers).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GP_MissionTriggers).Location = new Point(922, 81);
		((Control)GP_MissionTriggers).Name = "GP_MissionTriggers";
		((Control)GP_MissionTriggers).Size = new Size(322, 401);
		((Control)GP_MissionTriggers).TabIndex = 55;
		((GroupBox)GP_MissionTriggers).TabStop = false;
		((Control)PanelMissionTrigger).Anchor = (AnchorStyles)3;
		((Control)PanelMissionTrigger).Controls.Add((Control)(object)StartOfMission_DateTimeReachedPanel);
		((Control)PanelMissionTrigger).Controls.Add((Control)(object)EndOfMission_UnitUnloadedPctPanel);
		((Control)PanelMissionTrigger).Controls.Add((Control)(object)Panel_LuaScriptCriteria);
		PanelMissionTrigger.FlowDirection = (FlowDirection)1;
		((Control)PanelMissionTrigger).Location = new Point(6, 19);
		((Control)PanelMissionTrigger).Name = "PanelMissionTrigger";
		((Control)PanelMissionTrigger).Size = new Size(311, 376);
		((Control)PanelMissionTrigger).TabIndex = 32;
		PanelMissionTrigger.WrapContents = false;
		StartOfMission_DateTimeReachedPanel.BorderStyle = (BorderStyle)1;
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)DarkLabel11);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)ButtonStartTriggerPlusMinusToggle);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)ProgressBarHPlusTriggerStartTime);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)DateTimePicker_StartMission_Time_DaysCount);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)DarkLabel7);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)DateTimePicker_StartMission_Time);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)Combobox_OperatorDateAndTime);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)CB_StartOfMission_DateTimeReachedPanel);
		((Control)StartOfMission_DateTimeReachedPanel).Controls.Add((Control)(object)LabelStatic_DateAndTime);
		((Control)StartOfMission_DateTimeReachedPanel).Location = new Point(3, 6);
		((Control)StartOfMission_DateTimeReachedPanel).Margin = new Padding(3, 6, 3, 6);
		((Control)StartOfMission_DateTimeReachedPanel).Name = "StartOfMission_DateTimeReachedPanel";
		((Control)StartOfMission_DateTimeReachedPanel).Size = new Size(304, 60);
		((Control)StartOfMission_DateTimeReachedPanel).TabIndex = 9;
		DarkLabel11.AutoSize = true;
		((Control)DarkLabel11).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel11).Location = new Point(59, 9);
		((Control)DarkLabel11).Name = "DarkLabel11";
		((Control)DarkLabel11).Size = new Size(18, 17);
		((Control)DarkLabel11).TabIndex = 70;
		((Label)DarkLabel11).Text = "H";
		((ButtonBase)ButtonStartTriggerPlusMinusToggle).BackColor = Color.Transparent;
		((Button)ButtonStartTriggerPlusMinusToggle).DialogResult = (DialogResult)0;
		((Control)ButtonStartTriggerPlusMinusToggle).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonStartTriggerPlusMinusToggle).ForeColor = SystemColors.Control;
		((Control)ButtonStartTriggerPlusMinusToggle).Location = new Point(77, 7);
		((Control)ButtonStartTriggerPlusMinusToggle).Name = "ButtonStartTriggerPlusMinusToggle";
		ButtonStartTriggerPlusMinusToggle.RoundRadius = 0;
		((Control)ButtonStartTriggerPlusMinusToggle).Size = new Size(20, 22);
		((Control)ButtonStartTriggerPlusMinusToggle).TabIndex = 69;
		ButtonStartTriggerPlusMinusToggle.Text = "+";
		((Control)ProgressBarHPlusTriggerStartTime).BackColor = Color.Transparent;
		ProgressBarHPlusTriggerStartTime.CustomForeColor = Color.Transparent;
		((Control)ProgressBarHPlusTriggerStartTime).Location = new Point(5, 35);
		ProgressBarHPlusTriggerStartTime.Maximum = 100;
		((Control)ProgressBarHPlusTriggerStartTime).Name = "ProgressBarHPlusTriggerStartTime";
		ProgressBarHPlusTriggerStartTime.ShowProgressLines = true;
		ProgressBarHPlusTriggerStartTime.ShowProgressValue = true;
		ProgressBarHPlusTriggerStartTime.ShowText = false;
		((Control)ProgressBarHPlusTriggerStartTime).Size = new Size(294, 18);
		((Control)ProgressBarHPlusTriggerStartTime).TabIndex = 68;
		((Control)ProgressBarHPlusTriggerStartTime).Text = "DarkUIProgressBar1";
		ProgressBarHPlusTriggerStartTime.Value = 0;
		((Control)DateTimePicker_StartMission_Time_DaysCount).Location = new Point(102, 8);
		((Control)DateTimePicker_StartMission_Time_DaysCount).Name = "DateTimePicker_StartMission_Time_DaysCount";
		((Control)DateTimePicker_StartMission_Time_DaysCount).Size = new Size(33, 20);
		((Control)DateTimePicker_StartMission_Time_DaysCount).TabIndex = 67;
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(135, 10);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(34, 15);
		((Control)DarkLabel7).TabIndex = 66;
		((Label)DarkLabel7).Text = "Days";
		((Label)DarkLabel7).TextAlign = (ContentAlignment)16;
		DateTimePicker_StartMission_Time.CustomFormat = "HH:mm:ss";
		DateTimePicker_StartMission_Time.Format = (DateTimePickerFormat)8;
		((Control)DateTimePicker_StartMission_Time).Location = new Point(172, 8);
		DateTimePicker_StartMission_Time.MaxDate = new DateTime(2000, 2, 1, 0, 0, 0, 0);
		DateTimePicker_StartMission_Time.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		((Control)DateTimePicker_StartMission_Time).Name = "DateTimePicker_StartMission_Time";
		DateTimePicker_StartMission_Time.ShowUpDown = true;
		((Control)DateTimePicker_StartMission_Time).Size = new Size(66, 20);
		((Control)DateTimePicker_StartMission_Time).TabIndex = 65;
		DateTimePicker_StartMission_Time.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		Combobox_OperatorDateAndTime.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)Combobox_OperatorDateAndTime).FormattingEnabled = true;
		Combobox_OperatorDateAndTime.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)Combobox_OperatorDateAndTime).Location = new Point(244, 7);
		((Control)Combobox_OperatorDateAndTime).Name = "Combobox_OperatorDateAndTime";
		((Control)Combobox_OperatorDateAndTime).Size = new Size(55, 21);
		((Control)Combobox_OperatorDateAndTime).TabIndex = 37;
		((ButtonBase)CB_StartOfMission_DateTimeReachedPanel).AutoSize = true;
		((Control)CB_StartOfMission_DateTimeReachedPanel).Location = new Point(7, 10);
		((Control)CB_StartOfMission_DateTimeReachedPanel).Name = "CB_StartOfMission_DateTimeReachedPanel";
		((Control)CB_StartOfMission_DateTimeReachedPanel).Size = new Size(15, 14);
		((Control)CB_StartOfMission_DateTimeReachedPanel).TabIndex = 34;
		LabelStatic_DateAndTime.AutoSize = true;
		((Control)LabelStatic_DateAndTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelStatic_DateAndTime).Location = new Point(21, 11);
		((Control)LabelStatic_DateAndTime).Name = "LabelStatic_DateAndTime";
		((Control)LabelStatic_DateAndTime).Size = new Size(39, 13);
		((Control)LabelStatic_DateAndTime).TabIndex = 32;
		((Label)LabelStatic_DateAndTime).Text = "Time >";
		((Control)EndOfMission_UnitUnloadedPctPanel).BackColor = Color.FromArgb(40, 43, 45);
		EndOfMission_UnitUnloadedPctPanel.BorderStyle = (BorderStyle)1;
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)LV_MissionFinishedCriteriaPool);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)Button_MissionFinishedCriteriaRemove);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)DarkLabel2);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)DarkLabel1);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)LV_MissionFinishedCriteria_ToCheck);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)Combobox_OperatorMissionFinished);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)Button_MissionFinishedCriteriaAdd);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)LabelStatic_MIssionFinished);
		((Control)EndOfMission_UnitUnloadedPctPanel).Controls.Add((Control)(object)CB_StartOfMission_UnitUnloadedPctPanel);
		((Control)EndOfMission_UnitUnloadedPctPanel).Location = new Point(3, 78);
		((Control)EndOfMission_UnitUnloadedPctPanel).Margin = new Padding(3, 6, 3, 6);
		((Control)EndOfMission_UnitUnloadedPctPanel).Name = "EndOfMission_UnitUnloadedPctPanel";
		((Control)EndOfMission_UnitUnloadedPctPanel).Size = new Size(304, 222);
		((Control)EndOfMission_UnitUnloadedPctPanel).TabIndex = 10;
		((Control)LV_MissionFinishedCriteriaPool).BackColor = Color.FromArgb(60, 63, 65);
		((Control)LV_MissionFinishedCriteriaPool).Location = new Point(164, 48);
		((Control)LV_MissionFinishedCriteriaPool).Name = "LV_MissionFinishedCriteriaPool";
		LV_MissionFinishedCriteriaPool.RelatedInfos = null;
		((Control)LV_MissionFinishedCriteriaPool).Size = new Size(135, 150);
		((Control)LV_MissionFinishedCriteriaPool).TabIndex = 40;
		((ButtonBase)Button_MissionFinishedCriteriaRemove).BackColor = Color.Transparent;
		((Button)Button_MissionFinishedCriteriaRemove).DialogResult = (DialogResult)0;
		((Control)Button_MissionFinishedCriteriaRemove).ForeColor = SystemColors.Control;
		((Control)Button_MissionFinishedCriteriaRemove).Location = new Point(142, 121);
		((Control)Button_MissionFinishedCriteriaRemove).Name = "Button_MissionFinishedCriteriaRemove";
		Button_MissionFinishedCriteriaRemove.RoundRadius = 0;
		((Control)Button_MissionFinishedCriteriaRemove).Size = new Size(19, 40);
		((Control)Button_MissionFinishedCriteriaRemove).TabIndex = 43;
		Button_MissionFinishedCriteriaRemove.Text = ">";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(178, 33);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(66, 13);
		((Control)DarkLabel2).TabIndex = 42;
		((Label)DarkLabel2).Text = "Mission Pool";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(19, 32);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(92, 13);
		((Control)DarkLabel1).TabIndex = 41;
		((Label)DarkLabel1).Text = "Missions to check";
		((Control)LV_MissionFinishedCriteria_ToCheck).BackColor = Color.FromArgb(60, 63, 65);
		((Control)LV_MissionFinishedCriteria_ToCheck).Location = new Point(4, 48);
		((Control)LV_MissionFinishedCriteria_ToCheck).Name = "LV_MissionFinishedCriteria_ToCheck";
		LV_MissionFinishedCriteria_ToCheck.RelatedInfos = null;
		((Control)LV_MissionFinishedCriteria_ToCheck).Size = new Size(135, 150);
		((Control)LV_MissionFinishedCriteria_ToCheck).TabIndex = 39;
		Combobox_OperatorMissionFinished.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)Combobox_OperatorMissionFinished).FormattingEnabled = true;
		Combobox_OperatorMissionFinished.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)Combobox_OperatorMissionFinished).Location = new Point(244, 3);
		((Control)Combobox_OperatorMissionFinished).Name = "Combobox_OperatorMissionFinished";
		((Control)Combobox_OperatorMissionFinished).Size = new Size(55, 21);
		((Control)Combobox_OperatorMissionFinished).TabIndex = 36;
		((ButtonBase)Button_MissionFinishedCriteriaAdd).BackColor = Color.Transparent;
		((Button)Button_MissionFinishedCriteriaAdd).DialogResult = (DialogResult)0;
		((Control)Button_MissionFinishedCriteriaAdd).ForeColor = SystemColors.Control;
		((Control)Button_MissionFinishedCriteriaAdd).Location = new Point(142, 80);
		((Control)Button_MissionFinishedCriteriaAdd).Name = "Button_MissionFinishedCriteriaAdd";
		Button_MissionFinishedCriteriaAdd.RoundRadius = 0;
		((Control)Button_MissionFinishedCriteriaAdd).Size = new Size(19, 40);
		((Control)Button_MissionFinishedCriteriaAdd).TabIndex = 14;
		Button_MissionFinishedCriteriaAdd.Text = "<";
		LabelStatic_MIssionFinished.AutoSize = true;
		((Control)LabelStatic_MIssionFinished).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelStatic_MIssionFinished).Location = new Point(19, 8);
		((Control)LabelStatic_MIssionFinished).Name = "LabelStatic_MIssionFinished";
		((Control)LabelStatic_MIssionFinished).Size = new Size(96, 13);
		((Control)LabelStatic_MIssionFinished).TabIndex = 13;
		((Label)LabelStatic_MIssionFinished).Text = "Mission(s) Satisfied";
		((ButtonBase)CB_StartOfMission_UnitUnloadedPctPanel).AutoSize = true;
		((Control)CB_StartOfMission_UnitUnloadedPctPanel).Location = new Point(6, 7);
		((Control)CB_StartOfMission_UnitUnloadedPctPanel).Name = "CB_StartOfMission_UnitUnloadedPctPanel";
		((Control)CB_StartOfMission_UnitUnloadedPctPanel).Size = new Size(15, 14);
		((Control)CB_StartOfMission_UnitUnloadedPctPanel).TabIndex = 11;
		Panel_LuaScriptCriteria.BorderStyle = (BorderStyle)1;
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)StarLuaDescription);
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)DarkLabel10);
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)ButtonConfirmScript);
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)Combobox_OperatorLuaScript);
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)LabelStatic_LuaScript);
		((Control)Panel_LuaScriptCriteria).Controls.Add((Control)(object)CB_LuaScript);
		((Control)Panel_LuaScriptCriteria).Location = new Point(3, 312);
		((Control)Panel_LuaScriptCriteria).Margin = new Padding(3, 6, 3, 6);
		((Control)Panel_LuaScriptCriteria).Name = "Panel_LuaScriptCriteria";
		((Control)Panel_LuaScriptCriteria).Size = new Size(305, 61);
		((Control)Panel_LuaScriptCriteria).TabIndex = 11;
		StarLuaDescription.AutoSize = true;
		((Control)StarLuaDescription).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)StarLuaDescription).Location = new Point(78, 31);
		((Control)StarLuaDescription).Name = "StarLuaDescription";
		((Control)StarLuaDescription).Size = new Size(74, 13);
		((Control)StarLuaDescription).TabIndex = 40;
		((Label)StarLuaDescription).Text = " (25 char max)";
		DarkLabel10.AutoSize = true;
		((Control)DarkLabel10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel10).Location = new Point(5, 31);
		((Control)DarkLabel10).Name = "DarkLabel10";
		((Control)DarkLabel10).Size = new Size(66, 13);
		((Control)DarkLabel10).TabIndex = 39;
		((Label)DarkLabel10).Text = "Description :";
		((ButtonBase)ButtonConfirmScript).BackColor = Color.Transparent;
		((Button)ButtonConfirmScript).DialogResult = (DialogResult)0;
		((Control)ButtonConfirmScript).ForeColor = SystemColors.Control;
		((Control)ButtonConfirmScript).Location = new Point(121, 3);
		((Control)ButtonConfirmScript).Name = "ButtonConfirmScript";
		ButtonConfirmScript.RoundRadius = 0;
		((Control)ButtonConfirmScript).Size = new Size(117, 21);
		((Control)ButtonConfirmScript).TabIndex = 38;
		ButtonConfirmScript.Text = "Edit Script";
		Combobox_OperatorLuaScript.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)Combobox_OperatorLuaScript).FormattingEnabled = true;
		Combobox_OperatorLuaScript.Items.AddRange(new object[2] { "OR", "AND" });
		((Control)Combobox_OperatorLuaScript).Location = new Point(244, 3);
		((Control)Combobox_OperatorLuaScript).Name = "Combobox_OperatorLuaScript";
		((Control)Combobox_OperatorLuaScript).Size = new Size(55, 21);
		((Control)Combobox_OperatorLuaScript).TabIndex = 36;
		LabelStatic_LuaScript.AutoSize = true;
		((Control)LabelStatic_LuaScript).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelStatic_LuaScript).Location = new Point(23, 8);
		((Control)LabelStatic_LuaScript).Name = "LabelStatic_LuaScript";
		((Control)LabelStatic_LuaScript).Size = new Size(53, 13);
		((Control)LabelStatic_LuaScript).TabIndex = 13;
		((Label)LabelStatic_LuaScript).Text = "Lua script";
		((ButtonBase)CB_LuaScript).AutoSize = true;
		((Control)CB_LuaScript).Location = new Point(7, 7);
		((Control)CB_LuaScript).Name = "CB_LuaScript";
		((Control)CB_LuaScript).Size = new Size(15, 14);
		((Control)CB_LuaScript).TabIndex = 11;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(2, -3);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(180, 20);
		((Control)DarkLabel4).TabIndex = 33;
		((Label)DarkLabel4).Text = "Triggers to Start Mission";
		((TextBoxBase)DarkRichTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)DarkRichTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkRichTextBox1).Location = new Point(5, 27);
		((Control)DarkRichTextBox1).Name = "DarkRichTextBox1";
		((Control)DarkRichTextBox1).Size = new Size(276, 101);
		((Control)DarkRichTextBox1).TabIndex = 37;
		((RichTextBox)DarkRichTextBox1).Text = "";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(537, 47);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(93, 20);
		((Control)DarkLabel6).TabIndex = 68;
		((Label)DarkLabel6).Text = "L+ 00:00:00";
		((ButtonBase)CB_LockHhour_LHour).AutoSize = true;
		((Control)CB_LockHhour_LHour).Location = new Point(243, 33);
		((Control)CB_LockHhour_LHour).Name = "CB_LockHhour_LHour";
		((Control)CB_LockHhour_LHour).Size = new Size(15, 14);
		((Control)CB_LockHhour_LHour).TabIndex = 70;
		((ButtonBase)CB_LockHhour_LHour).UseVisualStyleBackColor = true;
		DarkLabel9.AutoSize = true;
		((Control)DarkLabel9).Font = new Font("Microsoft Sans Serif", 11f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel9).Location = new Point(232, 30);
		((Control)DarkLabel9).Name = "DarkLabel9";
		((Control)DarkLabel9).Size = new Size(39, 18);
		((Control)DarkLabel9).TabIndex = 71;
		((Label)DarkLabel9).Text = "> >>";
		((TextBoxBase)TB_FilterMissions).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_FilterMissions).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_FilterMissions).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_FilterMissions).Location = new Point(45, 78);
		((Control)TB_FilterMissions).Name = "TB_FilterMissions";
		((Control)TB_FilterMissions).Size = new Size(155, 20);
		((Control)TB_FilterMissions).TabIndex = 73;
		DarkLabel13.AutoSize = true;
		((Control)DarkLabel13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel13).Location = new Point(10, 80);
		((Control)DarkLabel13).Name = "DarkLabel13";
		((Control)DarkLabel13).Size = new Size(29, 13);
		((Control)DarkLabel13).TabIndex = 74;
		((Label)DarkLabel13).Text = "Filter";
		DarkLabel14.AutoSize = true;
		((Control)DarkLabel14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel14).Location = new Point(242, 82);
		((Control)DarkLabel14).Name = "DarkLabel14";
		((Control)DarkLabel14).Size = new Size(53, 13);
		((Control)DarkLabel14).TabIndex = 77;
		((Label)DarkLabel14).Text = "Sort order";
		((Control)DarkGroupBox1).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LabelLPlus);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LabelHPlus);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LabelEstimatedTotalTime);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)ButtonSImulate);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)CB_AUTOSIMULATEt);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(493, 2);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(418, 100);
		((Control)DarkGroupBox1).TabIndex = 78;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Simulation";
		((ButtonBase)ButtonSImulate).BackColor = Color.Transparent;
		((Button)ButtonSImulate).DialogResult = (DialogResult)0;
		((Control)ButtonSImulate).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonSImulate).ForeColor = SystemColors.Control;
		((Control)ButtonSImulate).Location = new Point(269, 10);
		((Control)ButtonSImulate).Name = "ButtonSImulate";
		ButtonSImulate.RoundRadius = 0;
		((Control)ButtonSImulate).Size = new Size(143, 32);
		((Control)ButtonSImulate).TabIndex = 69;
		ButtonSImulate.Text = "Simulate";
		((ButtonBase)CB_AUTOSIMULATEt).BackColor = Color.Transparent;
		((CheckBox)CB_AUTOSIMULATEt).Checked = false;
		((Control)CB_AUTOSIMULATEt).Cursor = Cursors.Hand;
		((Control)CB_AUTOSIMULATEt).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_AUTOSIMULATEt).Location = new Point(269, 48);
		((Control)CB_AUTOSIMULATEt).Name = "CB_AUTOSIMULATEt";
		((Control)CB_AUTOSIMULATEt).Size = new Size(101, 18);
		((Control)CB_AUTOSIMULATEt).TabIndex = 72;
		((ButtonBase)CB_AUTOSIMULATEt).Text = " Auto Refresh";
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)14;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_UnCheckAll);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_CheckAll);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Label1);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(8, 649);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(903, 57);
		((Control)DarkGroupBox2).TabIndex = 79;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Bulk Actions";
		((ButtonBase)Button_UnCheckAll).BackColor = Color.Transparent;
		((Button)Button_UnCheckAll).DialogResult = (DialogResult)0;
		((Control)Button_UnCheckAll).ForeColor = SystemColors.Control;
		((Control)Button_UnCheckAll).Location = new Point(6, 34);
		((Control)Button_UnCheckAll).Name = "Button_UnCheckAll";
		Button_UnCheckAll.RoundRadius = 0;
		((Control)Button_UnCheckAll).Size = new Size(77, 19);
		((Control)Button_UnCheckAll).TabIndex = 81;
		Button_UnCheckAll.Text = "Uncheck All";
		((ButtonBase)Button_CheckAll).BackColor = Color.Transparent;
		((Button)Button_CheckAll).DialogResult = (DialogResult)0;
		((Control)Button_CheckAll).ForeColor = SystemColors.Control;
		((Control)Button_CheckAll).Location = new Point(6, 14);
		((Control)Button_CheckAll).Name = "Button_CheckAll";
		Button_CheckAll.RoundRadius = 0;
		((Control)Button_CheckAll).Size = new Size(77, 19);
		((Control)Button_CheckAll).TabIndex = 80;
		Button_CheckAll.Text = "Check All";
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(93, 26);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(140, 13);
		((Control)Label1).TabIndex = 1;
		Label1.Text = "On checkmarked missions >";
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_BulkAction_Delete);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_BulkAction_UnassignAll);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_BulkAction_UnassignAllQueud);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_BulkAction_Activate);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_BulkAction_Desactivate);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)ComboBox_BulkPhase);
		((Control)FlowLayoutPanel3).Location = new Point(237, 14);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(660, 35);
		((Control)FlowLayoutPanel3).TabIndex = 0;
		((ButtonBase)Button_BulkAction_Delete).BackColor = Color.Transparent;
		((Button)Button_BulkAction_Delete).DialogResult = (DialogResult)0;
		((Control)Button_BulkAction_Delete).ForeColor = SystemColors.Control;
		((Control)Button_BulkAction_Delete).Location = new Point(3, 3);
		((Control)Button_BulkAction_Delete).Name = "Button_BulkAction_Delete";
		Button_BulkAction_Delete.RoundRadius = 0;
		((Control)Button_BulkAction_Delete).Size = new Size(75, 28);
		((Control)Button_BulkAction_Delete).TabIndex = 0;
		Button_BulkAction_Delete.Text = "Delete";
		((ButtonBase)Button_BulkAction_UnassignAll).BackColor = Color.Transparent;
		((Button)Button_BulkAction_UnassignAll).DialogResult = (DialogResult)0;
		((Control)Button_BulkAction_UnassignAll).ForeColor = SystemColors.Control;
		((Control)Button_BulkAction_UnassignAll).Location = new Point(84, 3);
		((Control)Button_BulkAction_UnassignAll).Name = "Button_BulkAction_UnassignAll";
		Button_BulkAction_UnassignAll.RoundRadius = 0;
		((Control)Button_BulkAction_UnassignAll).Size = new Size(114, 28);
		((Control)Button_BulkAction_UnassignAll).TabIndex = 1;
		Button_BulkAction_UnassignAll.Text = "Unassign all units";
		((ButtonBase)Button_BulkAction_UnassignAllQueud).BackColor = Color.Transparent;
		((Button)Button_BulkAction_UnassignAllQueud).DialogResult = (DialogResult)0;
		((Control)Button_BulkAction_UnassignAllQueud).ForeColor = SystemColors.Control;
		((Control)Button_BulkAction_UnassignAllQueud).Location = new Point(204, 3);
		((Control)Button_BulkAction_UnassignAllQueud).Name = "Button_BulkAction_UnassignAllQueud";
		Button_BulkAction_UnassignAllQueud.RoundRadius = 0;
		((Control)Button_BulkAction_UnassignAllQueud).Size = new Size(161, 28);
		((Control)Button_BulkAction_UnassignAllQueud).TabIndex = 4;
		Button_BulkAction_UnassignAllQueud.Text = "Unassign all queued units";
		((ButtonBase)Button_BulkAction_Activate).BackColor = Color.Transparent;
		((Button)Button_BulkAction_Activate).DialogResult = (DialogResult)0;
		((Control)Button_BulkAction_Activate).ForeColor = SystemColors.Control;
		((Control)Button_BulkAction_Activate).Location = new Point(371, 3);
		((Control)Button_BulkAction_Activate).Name = "Button_BulkAction_Activate";
		Button_BulkAction_Activate.RoundRadius = 0;
		((Control)Button_BulkAction_Activate).Size = new Size(59, 28);
		((Control)Button_BulkAction_Activate).TabIndex = 2;
		Button_BulkAction_Activate.Text = "Activate";
		((ButtonBase)Button_BulkAction_Desactivate).BackColor = Color.Transparent;
		((Button)Button_BulkAction_Desactivate).DialogResult = (DialogResult)0;
		((Control)Button_BulkAction_Desactivate).ForeColor = SystemColors.Control;
		((Control)Button_BulkAction_Desactivate).Location = new Point(436, 3);
		((Control)Button_BulkAction_Desactivate).Name = "Button_BulkAction_Desactivate";
		Button_BulkAction_Desactivate.RoundRadius = 0;
		((Control)Button_BulkAction_Desactivate).Size = new Size(74, 28);
		((Control)Button_BulkAction_Desactivate).TabIndex = 3;
		Button_BulkAction_Desactivate.Text = "Desactivate";
		((ComboBox)ComboBox_BulkPhase).BackColor = Color.Transparent;
		((ComboBox)ComboBox_BulkPhase).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_BulkPhase).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_BulkPhase).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_BulkPhase).FormattingEnabled = true;
		((ComboBox)ComboBox_BulkPhase).Items.AddRange(new object[3] { "Satisfied", "Waiting for trigger", "Triggered" });
		((Control)ComboBox_BulkPhase).Location = new Point(516, 7);
		((Control)ComboBox_BulkPhase).Margin = new Padding(3, 7, 3, 3);
		((Control)ComboBox_BulkPhase).Name = "ComboBox_BulkPhase";
		((Control)ComboBox_BulkPhase).Size = new Size(121, 21);
		((Control)ComboBox_BulkPhase).TabIndex = 5;
		((ComboBox)ComboSortOrder).BackColor = Color.Transparent;
		((ComboBox)ComboSortOrder).DrawMode = (DrawMode)1;
		((ComboBox)ComboSortOrder).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboSortOrder).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboSortOrder).FormattingEnabled = true;
		((Control)ComboSortOrder).Location = new Point(301, 77);
		((Control)ComboSortOrder).Name = "ComboSortOrder";
		((Control)ComboSortOrder).Size = new Size(186, 21);
		((Control)ComboSortOrder).TabIndex = 76;
		((ButtonBase)Button_PerformFilter).BackColor = Color.Transparent;
		((Button)Button_PerformFilter).DialogResult = (DialogResult)0;
		((Control)Button_PerformFilter).ForeColor = SystemColors.Control;
		((Control)Button_PerformFilter).Location = new Point(206, 78);
		((Control)Button_PerformFilter).Name = "Button_PerformFilter";
		Button_PerformFilter.RoundRadius = 0;
		((Control)Button_PerformFilter).Size = new Size(28, 20);
		((Control)Button_PerformFilter).TabIndex = 75;
		Button_PerformFilter.Text = "Go";
		DarkUITextBox1.AutoCompleteCustomSource = null;
		DarkUITextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		DarkUITextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)DarkUITextBox1).BackColor = Color.Transparent;
		((Control)DarkUITextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		DarkUITextBox1.Image = null;
		DarkUITextBox1.Lines = null;
		((Control)DarkUITextBox1).Location = new Point(92, 4);
		DarkUITextBox1.MaxLength = 32767;
		DarkUITextBox1.Multiline = false;
		((Control)DarkUITextBox1).Name = "DarkUITextBox1";
		DarkUITextBox1.ReadOnly = false;
		DarkUITextBox1.ScrollBars = (ScrollBars)0;
		DarkUITextBox1.SelectionStart = 0;
		((Control)DarkUITextBox1).Size = new Size(59, 21);
		((Control)DarkUITextBox1).TabIndex = 38;
		DarkUITextBox1.TextAlign = (HorizontalAlignment)0;
		DarkUITextBox1.UseSystemPasswordChar = false;
		DarkUITextBox1.WatermarkText = "Hours . . .";
		Darox1.AutoCompleteCustomSource = null;
		Darox1.AutoCompleteMode = (AutoCompleteMode)0;
		Darox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Darox1).BackColor = Color.Transparent;
		((Control)Darox1).ForeColor = Color.FromArgb(189, 189, 189);
		Darox1.Image = null;
		Darox1.Lines = null;
		((Control)Darox1).Location = new Point(92, 4);
		Darox1.MaxLength = 32767;
		Darox1.Multiline = false;
		((Control)Darox1).Name = "Darox1";
		Darox1.ReadOnly = false;
		Darox1.ScrollBars = (ScrollBars)0;
		Darox1.SelectionStart = 0;
		((Control)Darox1).Size = new Size(59, 21);
		((Control)Darox1).TabIndex = 38;
		Darox1.TextAlign = (HorizontalAlignment)0;
		Darox1.UseSystemPasswordChar = false;
		Darox1.WatermarkText = "Hours . . .";
		((ButtonBase)DarkUIButton2).BackColor = Color.Transparent;
		((Button)DarkUIButton2).DialogResult = (DialogResult)0;
		((Control)DarkUIButton2).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkUIButton2).ForeColor = SystemColors.Control;
		((Control)DarkUIButton2).Location = new Point(632, 43);
		((Control)DarkUIButton2).Name = "DarkUIButton2";
		DarkUIButton2.RoundRadius = 0;
		((Control)DarkUIButton2).Size = new Size(75, 24);
		((Control)DarkUIButton2).TabIndex = 69;
		DarkUIButton2.Text = "Simulate";
		((ButtonBase)CB_AUTOSIMULATE).BackColor = Color.Transparent;
		((Button)CB_AUTOSIMULATE).DialogResult = (DialogResult)0;
		((Control)CB_AUTOSIMULATE).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)CB_AUTOSIMULATE).ForeColor = SystemColors.Control;
		((Control)CB_AUTOSIMULATE).Location = new Point(632, 43);
		((Control)CB_AUTOSIMULATE).Name = "CB_AUTOSIMULATE";
		CB_AUTOSIMULATE.RoundRadius = 0;
		((Control)CB_AUTOSIMULATE).Size = new Size(75, 24);
		((Control)CB_AUTOSIMULATE).TabIndex = 69;
		CB_AUTOSIMULATE.Text = "Simulate";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(1251, 711);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)this).Controls.Add((Control)(object)DarkLabel14);
		((Control)this).Controls.Add((Control)(object)ComboSortOrder);
		((Control)this).Controls.Add((Control)(object)Button_PerformFilter);
		((Control)this).Controls.Add((Control)(object)DarkLabel13);
		((Control)this).Controls.Add((Control)(object)TB_FilterMissions);
		((Control)this).Controls.Add((Control)(object)CB_LockHhour_LHour);
		((Control)this).Controls.Add((Control)(object)DarkLabel9);
		((Control)this).Controls.Add((Control)(object)LHourGroupBox);
		((Control)this).Controls.Add((Control)(object)HHourGroupBox);
		((Control)this).Controls.Add((Control)(object)GP_EndMissionCriteria);
		((Control)this).Controls.Add((Control)(object)GP_MissionTriggers);
		((Control)this).Controls.Add((Control)(object)MainDGV);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Form)this).MinimumSize = new Size(1267, 750);
		((Control)this).Name = "OperationPlanner";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Operation Planner";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MainDGV).EndInit();
		((Control)LHourGroupBox).ResumeLayout(false);
		((Control)LHourGroupBox).PerformLayout();
		((Control)HHourGroupBox).ResumeLayout(false);
		((Control)HHourGroupBox).PerformLayout();
		((Control)GP_EndMissionCriteria).ResumeLayout(false);
		((Control)GP_EndMissionCriteria).PerformLayout();
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)Panel_DateTimeEndMissionCriteria).ResumeLayout(false);
		((Control)Panel_DateTimeEndMissionCriteria).PerformLayout();
		((ISupportInitialize)TimeElpasedFulfillTrigger_DayCOunt).EndInit();
		((Control)Panel_EndMissionLua).ResumeLayout(false);
		((Control)Panel_EndMissionLua).PerformLayout();
		((Control)GP_MissionTriggers).ResumeLayout(false);
		((Control)GP_MissionTriggers).PerformLayout();
		((Control)PanelMissionTrigger).ResumeLayout(false);
		((Control)StartOfMission_DateTimeReachedPanel).ResumeLayout(false);
		((Control)StartOfMission_DateTimeReachedPanel).PerformLayout();
		((ISupportInitialize)DateTimePicker_StartMission_Time_DaysCount).EndInit();
		((Control)EndOfMission_UnitUnloadedPctPanel).ResumeLayout(false);
		((Control)EndOfMission_UnitUnloadedPctPanel).PerformLayout();
		((Control)Panel_LuaScriptCriteria).ResumeLayout(false);
		((Control)Panel_LuaScriptCriteria).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[SpecialName]
	private bool method_2()
	{
		return bool_3;
	}

	[SpecialName]
	private void method_3(bool bool_6)
	{
		bool_3 = bool_6;
		ButtonSImulate.Enabled = !bool_6;
	}

	private void OperationPlanner_Load(object sender, EventArgs e)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		if (Client.CurrentSide != null)
		{
			((Label)LabelEstimatedTotalTime).Text = "Est. " + new TimeSpan(0, 0, Client.CurrentSide.Operation.ComputeEstimatedTimeOfExecution(Client.CurrentScenario, 60)).ToString("hh\\:mm\\:ss");
			((Form)this).TopMost = true;
			UiUpdateTimer.Start();
			((ListControl)ComboSortOrder).DisplayMember = "Label";
			((ComboBox)ComboSortOrder).Items.AddRange(new object[4]
			{
				new ComboFilterWrapper(SortOrderType.EstimatedExecutionTime, "Estimated Execution Time"),
				new ComboFilterWrapper(SortOrderType.Operation, "Description"),
				new ComboFilterWrapper(SortOrderType.Name, "Name"),
				new ComboFilterWrapper(SortOrderType.Phase, "Phase")
			});
			((ComboBox)ComboSortOrder).SelectedIndexChanged -= method_56;
			((ComboBox)ComboSortOrder).SelectedIndex = 0;
			((ComboBox)ComboSortOrder).SelectedIndexChanged += method_56;
			((ComboBox)ComboBox_BulkPhase).SelectedIndexChanged -= method_66;
			((ComboBox)ComboBox_BulkPhase).SelectedIndex = 0;
			((ComboBox)ComboBox_BulkPhase).SelectedIndexChanged += method_66;
			((ListControl)ComboBox_HHourMissionStart).ValueMember = "ID";
			((ListControl)ComboBox_HHourMissionStart).DisplayMember = "Label";
			((ListControl)ComboBox_LHourMissionStart).ValueMember = "ID";
			((ListControl)ComboBox_LHourMissionStart).DisplayMember = "Label";
			Side.MissionsChanged += method_6;
			method_6(Client.CurrentSide);
			method_8();
			method_7();
			method_11();
			method_16();
		}
		else
		{
			DarkMessageBox.ShowError("No side defined, exiting operation planner", "No side defined");
			((Form)this).Close();
		}
	}

	private void method_4(bool bool_6 = true)
	{
		method_3(bool_6: true);
		if (bool_6)
		{
			Client.CurrentSide.Operation.ComputeEstimatedTimeOfExecution(Client.CurrentScenario, 60);
			((Control)MainDGV).Refresh();
		}
	}

	private bool method_5(Mission mission_0, string string_0)
	{
		if (!mission_0.Name.ToLower().Contains(string_0))
		{
			if (!string.IsNullOrEmpty(mission_0.OperationName) && mission_0.OperationName.ToLower().Contains(string_0))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private void method_6(Side side_0)
	{
		Dictionary<Mission, int> dictionary = new Dictionary<Mission, int>();
		Dictionary<Mission, int> dictionary2 = new Dictionary<Mission, int>();
		((ComboBox)ComboBox_HHourMissionStart).Items.Clear();
		((ComboBox)ComboBox_LHourMissionStart).Items.Clear();
		((ComboBox)ComboBox_HHourMissionStart).Items.Add((object)new MissionHL_HourComboWrapper(null));
		((ComboBox)ComboBox_LHourMissionStart).Items.Add((object)new MissionHL_HourComboWrapper(null));
		CB_LockHhour_LHour.Checked = Client.CurrentSide.Operation.H_LHourAreRelative;
		int num = 1;
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			((ComboBox)ComboBox_HHourMissionStart).Items.Add((object)new MissionHL_HourComboWrapper(mission));
			((ComboBox)ComboBox_LHourMissionStart).Items.Add((object)new MissionHL_HourComboWrapper(mission));
			dictionary.Add(mission, num);
			dictionary2.Add(mission, num);
			num++;
		}
		if (((ComboBox)ComboBox_HHourMissionStart).Items.Count > 0)
		{
			if (Client.CurrentSide.Operation.HHourMission == null)
			{
				((ComboBox)ComboBox_HHourMissionStart).SelectedIndex = 0;
			}
			else
			{
				((ComboBox)ComboBox_HHourMissionStart).SelectedIndex = dictionary[Client.CurrentSide.Operation.HHourMission];
			}
			if (Client.CurrentSide.Operation.LHourMission == null)
			{
				((ComboBox)ComboBox_LHourMissionStart).SelectedIndex = 0;
			}
			else
			{
				((ComboBox)ComboBox_LHourMissionStart).SelectedIndex = dictionary2[Client.CurrentSide.Operation.LHourMission];
			}
		}
	}

	private void method_7()
	{
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		bool_2 = true;
		missionWrapper_0 = null;
		MainDGV.DataSource = null;
		MainDGV.Rows.Clear();
		MainDGV.Columns.Clear();
		bindingSource_0.Clear();
		((Control)MainDGV).Refresh();
		MainDGV.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		MainDGV.AutoGenerateColumns = true;
		bindingSource_0.DataSource = typeof(MissionWrapper);
		List<Mission> list = new List<Mission>();
		list = ((ComboFilterWrapper)((ComboBox)ComboSortOrder).SelectedItem).Type switch
		{
			SortOrderType.EstimatedExecutionTime => Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission x) => x.EstimatedExecutionTime).ToList(), 
			SortOrderType.Phase => Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission x) => x.get_Phase(Client.CurrentScenario, Client.CurrentSide)).ToList(), 
			SortOrderType.Operation => Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission x) => x.OperationName).ToList(), 
			SortOrderType.Name => Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission x) => x.Name).ToList(), 
			_ => Client.CurrentSide.Missions.OrderBy([SpecialName] (Mission x) => x.EstimatedExecutionTime).ToList(), 
		};
		dictionary_0.Clear();
		dictionary_1.Clear();
		string string_ = ((TextBox)TB_FilterMissions).Text.ToLower();
		foreach (Mission item in list)
		{
			if (!dictionary_1.ContainsKey(item))
			{
				dictionary_1.Add(item, item);
			}
			if (string.IsNullOrWhiteSpace(((TextBox)TB_FilterMissions).Text) || method_5(item, string_))
			{
				MissionWrapper missionWrapper = new MissionWrapper(item);
				bindingSource_0.Add((object)missionWrapper);
				if (!dictionary_0.ContainsKey(item))
				{
					dictionary_0.Add(item, missionWrapper);
				}
			}
		}
		DataGridViewComboBoxColumn val = new DataGridViewComboBoxColumn();
		((DataGridViewColumn)val).DataPropertyName = "Phase";
		((DataGridViewColumn)val).Name = "Phase";
		val.ValueMember = "ID";
		val.DisplayMember = "Label";
		val.Items.Add((object)new MissionPhaseComboWrapper(MissionPhase.Completed, "Satisfied"));
		val.Items.Add((object)new MissionPhaseComboWrapper(MissionPhase.OnHold, "Waiting for trigger"));
		val.Items.Add((object)new MissionPhaseComboWrapper(MissionPhase.Active, "Triggered"));
		MainDGV.DataSource = bindingSource_0;
		MainDGV.AutoGenerateColumns = false;
		MainDGV.Columns.Add((DataGridViewColumn)(object)val);
		method_17();
		foreach (DataGridViewColumn item2 in (BaseCollection)MainDGV.Columns)
		{
			item2.SortMode = (DataGridViewColumnSortMode)1;
		}
		((Control)MainDGV).Refresh();
	}

	private void method_8()
	{
		DatePicker_LHourTime.ValueChanged -= method_23;
		DatePicker_LHourDate.ValueChanged -= method_22;
		DatePicker_HHourTime.ValueChanged -= method_21;
		DatePicker_HHourDate.ValueChanged -= method_20;
		if (DateTime.Compare(Client.CurrentSide.Operation.HHour, DateTime.MinValue) == 0)
		{
			DatePicker_HHourDate.Value = Client.CurrentScenario.Time;
			DatePicker_HHourTime.Value = Client.CurrentScenario.Time;
		}
		else
		{
			DatePicker_HHourDate.Value = Client.CurrentSide.Operation.HHour;
			DatePicker_HHourTime.Value = Client.CurrentSide.Operation.HHour;
		}
		try
		{
			DatePicker_LHourTime.Value = Client.CurrentSide.Operation.LHour;
			DatePicker_LHourDate.Value = Client.CurrentSide.Operation.LHour;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DatePicker_LHourTime.Value = Client.CurrentScenario.Time;
			DatePicker_LHourDate.Value = Client.CurrentScenario.Time;
			ProjectData.ClearProjectError();
		}
		DatePicker_LHourTime.ValueChanged += method_23;
		DatePicker_LHourDate.ValueChanged += method_22;
		DatePicker_HHourTime.ValueChanged += method_21;
		DatePicker_HHourDate.ValueChanged += method_20;
		bool_2 = false;
	}

	private void method_9()
	{
		if (missionWrapper_0 == null)
		{
			return;
		}
		Color backColor = Color.FromArgb(255, 43, 43, 43);
		Color backColor2 = Color.FromArgb(255, 43, 83, 43);
		Color backColor3 = Color.FromArgb(255, 83, 43, 43);
		if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Enabled)
		{
			if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_LastResult)
			{
				((Control)StartOfMission_DateTimeReachedPanel).BackColor = backColor3;
			}
			else
			{
				((Control)StartOfMission_DateTimeReachedPanel).BackColor = backColor2;
			}
		}
		else
		{
			((Control)StartOfMission_DateTimeReachedPanel).BackColor = backColor;
		}
		if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Enabled)
		{
			if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_LastResult)
			{
				((Control)EndOfMission_UnitUnloadedPctPanel).BackColor = backColor2;
			}
			else
			{
				((Control)EndOfMission_UnitUnloadedPctPanel).BackColor = backColor3;
			}
		}
		else
		{
			((Control)EndOfMission_UnitUnloadedPctPanel).BackColor = backColor;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Enabled)
		{
			((Control)Panel_LuaScriptCriteria).BackColor = backColor;
		}
		else if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_LastResult)
		{
			((Control)Panel_LuaScriptCriteria).BackColor = backColor2;
		}
		else
		{
			((Control)Panel_LuaScriptCriteria).BackColor = backColor3;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Enabled)
		{
			((Control)Panel_EndMissionLua).BackColor = backColor;
		}
		else if (!((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_LastResult)
		{
			((Control)Panel_EndMissionLua).BackColor = backColor3;
		}
		else
		{
			((Control)Panel_EndMissionLua).BackColor = backColor2;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Enabled)
		{
			((Control)Panel_DateTimeEndMissionCriteria).BackColor = backColor;
		}
		else if (!((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_LastResult)
		{
			((Control)Panel_DateTimeEndMissionCriteria).BackColor = backColor3;
		}
		else
		{
			((Control)Panel_DateTimeEndMissionCriteria).BackColor = backColor2;
		}
	}

	private void method_10()
	{
		DateTimePicker_StartMission_Time_DaysCount.ValueChanged -= method_49;
		DateTimePicker_StartMission_Time.ValueChanged -= method_32;
		DateTimePicker1.ValueChanged -= method_50;
		TimeElpasedFulfillTrigger_DayCOunt.ValueChanged -= method_51;
		TimeSpan timeSpan = new TimeSpan(0, 0, Math.Abs((int)Math.Round(((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime / 86400f)));
		TimeSpan timeSpan2 = new TimeSpan(0, 0, Math.Abs((int)Math.Round(((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime)));
		DateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(timeSpan2.TotalSeconds - timeSpan.TotalSeconds);
		TimeElpasedFulfillTrigger_DayCOunt.Value = new decimal((int)Math.Round(timeSpan.TotalDays));
		timeSpan = new TimeSpan(0, 0, Math.Abs((int)Math.Round((double)((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time / 86400.0)));
		timeSpan2 = new TimeSpan(0, 0, Math.Abs(((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time));
		DateTimePicker_StartMission_Time.Value = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(timeSpan2.TotalSeconds - timeSpan.TotalSeconds);
		DateTimePicker_StartMission_Time_DaysCount.Value = new decimal((int)Math.Round(timeSpan.TotalDays));
		if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time < 0)
		{
			ButtonStartTriggerPlusMinusToggle.Text = "-";
		}
		else
		{
			ButtonStartTriggerPlusMinusToggle.Text = "+";
		}
		DateTimePicker_StartMission_Time_DaysCount.ValueChanged += method_49;
		DateTimePicker_StartMission_Time.ValueChanged += method_32;
		DateTimePicker1.ValueChanged += method_50;
		TimeElpasedFulfillTrigger_DayCOunt.ValueChanged += method_51;
	}

	private void method_11()
	{
		if (Information.IsNothing((object)missionWrapper_0))
		{
			method_13(bool_6: false);
			return;
		}
		method_13(bool_6: true);
		((CheckBox)CB_StartOfMission_DateTimeReachedPanel).Checked = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Enabled;
		((CheckBox)CB_StartOfMission_UnitUnloadedPctPanel).Checked = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Enabled;
		((CheckBox)CB_LuaScript).Checked = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Enabled;
		((CheckBox)CB_DateTimeEndMission).Checked = ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Enabled;
		((CheckBox)CB_EndMissionLua).Checked = ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Enabled;
		method_10();
		((Control)ComboBox_EndMissionLuaScript).TextChanged -= method_47;
		((Control)Combobox_OperatorLuaScript).TextChanged -= method_45;
		((Control)Combobox_OperatorMissionFinished).TextChanged -= method_48;
		((Control)ComboMissionEndElapsed).TextChanged -= method_46;
		((Control)Combobox_OperatorDateAndTime).TextChanged -= method_44;
		if (!((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Operator)
		{
			ComboBox_EndMissionLuaScript.SelectedIndex = 0;
		}
		else
		{
			ComboBox_EndMissionLuaScript.SelectedIndex = 1;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Operator)
		{
			Combobox_OperatorLuaScript.SelectedIndex = 0;
		}
		else
		{
			Combobox_OperatorLuaScript.SelectedIndex = 1;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Operator)
		{
			Combobox_OperatorMissionFinished.SelectedIndex = 0;
		}
		else
		{
			Combobox_OperatorMissionFinished.SelectedIndex = 1;
		}
		if (((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Operator)
		{
			ComboMissionEndElapsed.SelectedIndex = 1;
		}
		else
		{
			ComboMissionEndElapsed.SelectedIndex = 0;
		}
		if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Operator)
		{
			Combobox_OperatorDateAndTime.SelectedIndex = 0;
		}
		else
		{
			Combobox_OperatorDateAndTime.SelectedIndex = 1;
		}
		((Control)ComboBox_EndMissionLuaScript).TextChanged += method_47;
		((Control)Combobox_OperatorLuaScript).TextChanged += method_45;
		((Control)Combobox_OperatorMissionFinished).TextChanged += method_48;
		((Control)ComboMissionEndElapsed).TextChanged += method_46;
		((Control)Combobox_OperatorDateAndTime).TextChanged += method_44;
		if (!string.IsNullOrEmpty(((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUADescription))
		{
			((Label)StarLuaDescription).Text = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUADescription;
		}
		else
		{
			((Label)StarLuaDescription).Text = "(25 char max)";
		}
		if (!string.IsNullOrEmpty(((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUADescription))
		{
			((Label)EndMissionLuaDescription).Text = ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUADescription;
		}
		else
		{
			((Label)EndMissionLuaDescription).Text = "(25 char max)";
		}
		method_12();
		method_14();
		method_15();
		method_9();
	}

	private void method_12()
	{
		LV_MissionFinishedCriteria_ToCheck.Items.Clear();
		foreach (KeyValuePair<Mission, Mission> item in ((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted)
		{
			DarkListItem darkListItem = new DarkListItem(item.Key.Name);
			darkListItem.Tag = item.Key;
			LV_MissionFinishedCriteria_ToCheck.Items.Add(darkListItem);
		}
		LV_MissionFinishedCriteriaPool.Items.Clear();
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted.ContainsKey(mission))
			{
				DarkListItem darkListItem2 = new DarkListItem(mission.Name);
				darkListItem2.Tag = mission;
				LV_MissionFinishedCriteriaPool.Items.Add(darkListItem2);
			}
		}
	}

	private void method_13(bool bool_6)
	{
		((Control)GP_EndMissionCriteria).Visible = bool_6;
		((Control)GP_MissionTriggers).Visible = bool_6;
	}

	private void method_14(bool bool_6 = true)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			int value = 0;
			if (((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Current > 0f && ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime > 0f)
			{
				value = (int)Math.Round(((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Current / ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime * 100f);
			}
			EndMissionTimeElapsedProgressBar.Value = value;
		}
	}

	private void method_15(bool bool_6 = true)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			int num = 0;
			int num2 = ((DateTime.Compare(Client.CurrentSide.Operation.HHourEffectiveStartTime, DateTime.MinValue) != 0) ? ((int)Math.Round((Client.CurrentScenario.Time - Client.CurrentSide.Operation.HHourEffectiveStartTime).TotalSeconds)) : 0);
			num = ((num2 != 0 && ((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time != 0) ? ((int)Math.Round((float)num2 / (float)((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time * 100f)) : 0);
			if (num < 0)
			{
				ProgressBarHPlusTriggerStartTime.Value = 100;
			}
			else
			{
				ProgressBarHPlusTriggerStartTime.Value = num;
			}
		}
	}

	private void method_16(bool bool_6 = true)
	{
		if (!Client.CurrentSide.Operation.PhasesValidation || bool_6)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["Phase"].Value = ((Mission)((MissionWrapper)bindingSource_0[i]).object_0).get_Phase(Client.CurrentScenario, Client.CurrentSide);
			}
		}
	}

	private void method_17()
	{
		DataGridView mainDGV = MainDGV;
		mainDGV.Columns["BulkSelection"].DisplayIndex = 0;
		mainDGV.Columns["BulkSelection"].HeaderText = "Bulk action";
		mainDGV.Columns["BulkSelection"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["BulkSelection"].Width = 60;
		mainDGV.Columns["Name"].DisplayIndex = 1;
		mainDGV.Columns["Type"].DisplayIndex = 2;
		mainDGV.Columns["Type"].ReadOnly = true;
		mainDGV.Columns["Type"].Width = 110;
		mainDGV.Columns["Type"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["Type"].ToolTipText = "Mission type as defined when creating a mission.";
		mainDGV.Columns["Type"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		mainDGV.Columns["OperationName"].DisplayIndex = 3;
		mainDGV.Columns["OperationName"].HeaderText = "Description";
		mainDGV.Columns["OperationName"].Width = 180;
		mainDGV.Columns["OperationName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["OperationName"].ToolTipText = "Information to organize missions in categories.";
		mainDGV.Columns["Priority"].DisplayIndex = 4;
		mainDGV.Columns["Priority"].Width = 60;
		mainDGV.Columns["Priority"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["Priority"].ToolTipText = "How important a mission is when assigning a mission to a multi-mission unit. Lowest value has highest priority.";
		mainDGV.Columns["Phase"].DisplayIndex = 5;
		mainDGV.Columns["Phase"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["Phase"].Width = 120;
		mainDGV.Columns["Phase"].ToolTipText = "The current phase of the mission.";
		mainDGV.Columns["ExecutionTime"].HeaderText = "Execution Time";
		mainDGV.Columns["ExecutionTime"].DisplayIndex = 6;
		mainDGV.Columns["ExecutionTime"].ReadOnly = true;
		mainDGV.Columns["ExecutionTime"].Width = 120;
		mainDGV.Columns["ExecutionTime"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["ExecutionTime"].ToolTipText = "Estimated time for the mission to start relative to H hour.";
		mainDGV.Columns["ExecutionTime"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		mainDGV.Columns["Activation"].DisplayIndex = 7;
		mainDGV.Columns["Activation"].HeaderText = "Activated";
		mainDGV.Columns["Activation"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		mainDGV.Columns["Activation"].Width = 60;
		int_0 = ((DataGridViewBand)MainDGV.Columns["BulkSelection"]).Index;
		int_1 = ((DataGridViewBand)MainDGV.Columns["Activation"]).Index;
	}

	private void method_18(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.UnitSerialEditor).Show();
	}

	private void method_19(object sender, EventArgs e)
	{
		((Control)Client.MissionEditorWindow).Show();
		if (missionWrapper_0 != null && missionWrapper_0.object_0 != null)
		{
			Client.MissionEditorWindow.SelectedMission = (Mission)missionWrapper_0.object_0;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.HHour = new DateTime(DatePicker_HHourDate.Value.Year, DatePicker_HHourDate.Value.Month, DatePicker_HHourDate.Value.Day, DatePicker_HHourTime.Value.Hour, DatePicker_HHourTime.Value.Minute, DatePicker_HHourTime.Value.Second);
		method_3(bool_6: false);
		method_8();
	}

	private void method_21(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.HHour = new DateTime(DatePicker_HHourDate.Value.Year, DatePicker_HHourDate.Value.Month, DatePicker_HHourDate.Value.Day, DatePicker_HHourTime.Value.Hour, DatePicker_HHourTime.Value.Minute, DatePicker_HHourTime.Value.Second);
		method_3(bool_6: false);
		method_8();
	}

	private void method_22(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.LHour = new DateTime(DatePicker_LHourDate.Value.Year, DatePicker_LHourDate.Value.Month, DatePicker_LHourDate.Value.Day, DatePicker_LHourTime.Value.Hour, DatePicker_LHourTime.Value.Minute, DatePicker_LHourTime.Value.Second);
		method_3(bool_6: false);
		method_8();
	}

	private void method_23(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.LHour = new DateTime(DatePicker_LHourDate.Value.Year, DatePicker_LHourDate.Value.Month, DatePicker_LHourDate.Value.Day, DatePicker_LHourTime.Value.Hour, DatePicker_LHourTime.Value.Minute, DatePicker_LHourTime.Value.Second);
		method_3(bool_6: false);
		method_8();
	}

	private void method_24(object sender, EventArgs e)
	{
		Mission iD = ((MissionHL_HourComboWrapper)((ComboBox)ComboBox_HHourMissionStart).SelectedItem).ID;
		Client.CurrentSide.Operation.HHourMission = iD;
		method_3(bool_6: false);
		method_8();
	}

	private void method_25(object sender, EventArgs e)
	{
		Mission iD = ((MissionHL_HourComboWrapper)((ComboBox)ComboBox_LHourMissionStart).SelectedItem).ID;
		Client.CurrentSide.Operation.LHourMission = iD;
		method_3(bool_6: false);
		method_8();
	}

	private void method_26(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		Control editingControl = MainDGV.EditingControl;
		ComboBox val = (ComboBox)(object)((editingControl is ComboBox) ? editingControl : null);
		if (val != null)
		{
			val.SelectionChangeCommitted += method_27;
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		MissionPhase iD = ((MissionPhaseComboWrapper)((ComboBox)((sender is DataGridViewComboBoxEditingControl) ? sender : null)).SelectedItem).ID;
		((Mission)((MissionWrapper)bindingSource_0[MainDGV.CurrentCell.RowIndex]).object_0).set_Phase(Client.CurrentScenario, Client.CurrentSide, iD);
		method_3(bool_6: false);
	}

	public void RefreshMainTimerLabels()
	{
		Operation operation = Client.CurrentSide.Operation;
		string text = "H+";
		string text2 = "L+";
		text = ((DateTime.Compare(operation.HHourEffectiveStartTime, DateTime.MinValue) != 0) ? (text + (operation.HHourEffectiveStartTime - Client.CurrentScenario.Time).ToString("hh\\:mm\\:ss")) : (text + " - - -"));
		text2 = ((DateTime.Compare(operation.LHourEffectiveStartTime, DateTime.MinValue) == 0) ? (text2 + " - - -") : (text2 + (operation.LHourEffectiveStartTime - Client.CurrentScenario.Time).ToString("hh\\:mm\\:ss")));
		if (Operators.CompareString(((Label)LabelHPlus).Text, text, true) != 0)
		{
			((Label)LabelHPlus).Text = text;
		}
		if (Operators.CompareString(((Label)LabelLPlus).Text, text2, true) != 0)
		{
			((Label)LabelLPlus).Text = text2;
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		UiRealtimeRefreshTick();
	}

	public void UiRealtimeRefreshTick(bool MissionPanelOnly = false)
	{
		if (!MissionPanelOnly)
		{
			RefreshMainTimerLabels();
			method_16(bool_6: false);
		}
		((Control)MainDGV).Refresh();
		method_15();
		method_9();
		method_14();
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!dictionary_1.ContainsKey(mission))
			{
				method_7();
				break;
			}
		}
		foreach (KeyValuePair<Mission, Mission> item in dictionary_1)
		{
			if (!Client.CurrentSide.Missions.Contains(item.Key))
			{
				method_7();
				break;
			}
		}
		if (!bool_2)
		{
			method_7();
		}
		if (!method_2() && ((CheckBox)CB_AUTOSIMULATEt).Checked)
		{
			method_4();
		}
		if (!bool_5 && Client.CurrentSide.Operation.HHourLocked && Client.CurrentSide.Operation.HHourMission != null)
		{
			((Control)ComboBox_HHourMissionStart).Visible = false;
			bool_5 = true;
			((Label)LabelInitialMission).Text = "Initial Mission : " + Client.CurrentSide.Operation.HHourMission.Name;
		}
		if (!bool_4 && Client.CurrentSide.Operation.LHourLocked && Client.CurrentSide.Operation.LHourMission != null)
		{
			((Control)ComboBox_LHourMissionStart).Visible = false;
			bool_4 = true;
			((Label)LabelLHourInitialMission).Text = "Initial Mission : " + Client.CurrentSide.Operation.LHourMission.Name;
		}
		UiUpdateTimer.Stop();
		UiUpdateTimer.Start();
	}

	private void method_29(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)MainDGV.CurrentCell))
		{
			missionWrapper_0 = (MissionWrapper)bindingSource_0[MainDGV.CurrentCell.RowIndex];
			method_11();
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Enabled = ((CheckBox)CB_StartOfMission_DateTimeReachedPanel).Checked;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Enabled = ((CheckBox)CB_StartOfMission_UnitUnloadedPctPanel).Checked;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
			if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", true) == 0)
			{
				num = -num;
			}
			((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time = num;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
			method_10();
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)missionWrapper_0))
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_MissionFinishedCriteriaPool.SelectedItems)
		{
			Mission mission = (Mission)selectedItem.Tag;
			if (!((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted.ContainsKey(mission))
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted.Add(mission, mission);
			}
		}
		method_3(bool_6: false);
		method_12();
		UiRealtimeRefreshTick(MissionPanelOnly: true);
	}

	private void method_34(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)missionWrapper_0))
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_MissionFinishedCriteria_ToCheck.SelectedItems)
		{
			Mission key = (Mission)selectedItem.Tag;
			if (((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted.ContainsKey(key))
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted.Remove(key);
			}
		}
		method_3(bool_6: false);
		method_12();
		UiRealtimeRefreshTick(MissionPanelOnly: true);
	}

	private void method_35(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Enabled = ((CheckBox)CB_LuaScript).Checked;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_36(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Invalid comparison between Unknown and I4
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			LuaEditorOperationPlanner luaEditorOperationPlanner = new LuaEditorOperationPlanner();
			luaEditorOperationPlanner.TheDescription = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUADescription;
			luaEditorOperationPlanner.TheScript = ((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA;
			if ((int)((Form)luaEditorOperationPlanner).ShowDialog() == 1)
			{
				((Label)StarLuaDescription).Text = luaEditorOperationPlanner.TheDescription;
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUADescription = luaEditorOperationPlanner.TheDescription;
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA = luaEditorOperationPlanner.TheScript;
			}
			method_3(bool_6: false);
		}
	}

	private void method_37(object sender, EventArgs e)
	{
		if (!ButtonConfirmScript.Enabled)
		{
			ButtonConfirmScript.Enabled = true;
		}
		method_3(bool_6: false);
		UiRealtimeRefreshTick(MissionPanelOnly: true);
	}

	private void method_38(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Enabled = ((CheckBox)CB_DateTimeEndMission).Checked;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Enabled = ((CheckBox)CB_EndMissionLua).Checked;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_40(object sender, EventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			LuaEditorOperationPlanner luaEditorOperationPlanner = new LuaEditorOperationPlanner();
			luaEditorOperationPlanner.TheDescription = ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUADescription;
			luaEditorOperationPlanner.TheScript = ((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA;
			if ((int)((Form)luaEditorOperationPlanner).ShowDialog() == 1)
			{
				((Label)EndMissionLuaDescription).Text = luaEditorOperationPlanner.TheDescription;
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUADescription = luaEditorOperationPlanner.TheDescription;
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA = luaEditorOperationPlanner.TheScript;
			}
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_41(object sender, EventArgs e)
	{
		if (!ButtonConfirmScriptMissionComplete.Enabled)
		{
			ButtonConfirmScriptMissionComplete.Enabled = true;
		}
		method_3(bool_6: false);
		UiRealtimeRefreshTick(MissionPanelOnly: true);
	}

	private void method_42(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Current = 0f;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_43(object sender, EventArgs e)
	{
		method_3(bool_6: true);
		((Label)LabelEstimatedTotalTime).Text = "Est. " + new TimeSpan(0, 0, Client.CurrentSide.Operation.ComputeEstimatedTimeOfExecution(Client.CurrentScenario, 60)).ToString("hh\\:mm\\:ss");
		method_7();
	}

	private void method_44(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			if (Combobox_OperatorDateAndTime.SelectedIndex != 0)
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Operator = true;
			}
			else
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time_Operator = false;
			}
			method_3(bool_6: false);
		}
	}

	private void method_45(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			if (Combobox_OperatorLuaScript.SelectedIndex != 0)
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Operator = true;
			}
			else
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_LUA_Operator = false;
			}
			method_3(bool_6: false);
		}
	}

	private void method_46(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			if (ComboMissionEndElapsed.SelectedIndex != 0)
			{
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Operator = true;
			}
			else
			{
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime_Operator = false;
			}
			method_3(bool_6: false);
		}
	}

	private void method_47(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			if (ComboBox_EndMissionLuaScript.SelectedIndex != 0)
			{
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Operator = true;
			}
			else
			{
				((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_LUA_Operator = false;
			}
			method_3(bool_6: false);
		}
	}

	private void method_48(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			if (Combobox_OperatorMissionFinished.SelectedIndex != 0)
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Operator = true;
			}
			else
			{
				((Mission)missionWrapper_0.object_0).MissionStartTrigger_MissionCompleted_Operator = false;
			}
			method_3(bool_6: false);
		}
	}

	private void method_49(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
			if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", true) == 0)
			{
				num = -num;
			}
			if (num < 0)
			{
				DateTime.Compare(Client.CurrentSide.Operation.HHour.AddSeconds(num), Client.CurrentScenario.Time);
			}
			((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time = num;
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_50(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			TimeSpan timeSpan = DateTimePicker1.Value - new DateTime(2000, 1, 1, 0, 0, 0);
			((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime = (int)Math.Round(timeSpan.TotalSeconds) + (int)Math.Round(Convert.ToSingle(TimeElpasedFulfillTrigger_DayCOunt.Value) * 86400f);
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_51(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)missionWrapper_0))
		{
			TimeSpan timeSpan = DateTimePicker1.Value - new DateTime(2000, 1, 1, 0, 0, 0);
			((Mission)missionWrapper_0.object_0).MissionCompletedTrigger_ElapsedTime = (int)Math.Round(timeSpan.TotalSeconds) + (int)Math.Round(Convert.ToSingle(TimeElpasedFulfillTrigger_DayCOunt.Value) * 86400f);
			method_3(bool_6: false);
			UiRealtimeRefreshTick(MissionPanelOnly: true);
		}
	}

	private void method_52(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.H_LHourAreRelative = CB_LockHhour_LHour.Checked;
		method_3(bool_6: false);
	}

	private void method_53(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.LandingPlanner).Show();
	}

	private void method_54(object sender, EventArgs e)
	{
		if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", true) != 0)
		{
			ButtonStartTriggerPlusMinusToggle.Text = "-";
		}
		else
		{
			ButtonStartTriggerPlusMinusToggle.Text = "+";
		}
		int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
		if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", true) == 0)
		{
			num = -num;
		}
		((Mission)missionWrapper_0.object_0).MissionStartTrigger_Time = num;
		method_10();
		((Control)ButtonStartTriggerPlusMinusToggle).Refresh();
		method_3(bool_6: false);
	}

	private void method_55(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_56(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_57(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == int_1 || e.ColumnIndex == int_0)
		{
			MainDGV.EndEdit();
		}
	}

	private void method_58(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == int_1 || e.ColumnIndex == int_0)
		{
			MainDGV.EndEdit();
		}
	}

	private void method_59(object sender, EventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (item.Key.MarkedForBulkEdition && (int)Client.WarnAboutDeletedMissionDependencies(item.Key) != 7)
			{
				Mission key = item.Key;
				Scenario theScen = Client.CurrentScenario;
				Side theSide = Client.CurrentSide;
				key.DeleteMission(ref theScen, ref theSide);
				Client.CurrentSide = theSide;
			}
		}
		method_7();
	}

	private void method_60(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (!item.Key.MarkedForBulkEdition)
			{
				continue;
			}
			foreach (ActiveUnit item2 in Client.CurrentScenario.ActiveUnits.Values.ToList())
			{
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				item2.Set_AssignedMissionOrPackage(null, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
			}
		}
		method_7();
	}

	private void method_61(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				item.Key.set_Status(Client.CurrentScenario, Mission.MissionStatus.Active);
			}
		}
		method_7();
	}

	private void method_62(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				item.Key.set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
			}
		}
		method_7();
	}

	private void method_63(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (!item.Key.MarkedForBulkEdition)
			{
				continue;
			}
			foreach (ActiveUnit item2 in Client.CurrentScenario.ActiveUnits.Values.ToList())
			{
				item2.UnassignMissionInQueue(item.Key);
			}
		}
		method_7();
	}

	private void OperationPlanner_Shown(object sender, EventArgs e)
	{
		((Control)Button_SerialEditor).Visible = GameGeneral.LicenseTierContext != GameGeneral._ProLicenseTier.None;
		((Control)Button_LandingPlanner).Visible = GameGeneral.LicenseTierContext != GameGeneral._ProLicenseTier.None;
	}

	private void method_64(object sender, EventArgs e)
	{
		if (MainDGV.Rows.Count > 0)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["BulkSelection"].Value = true;
			}
			((Control)MainDGV).Refresh();
		}
	}

	private void method_65(object sender, EventArgs e)
	{
		if (MainDGV.Rows.Count > 0)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["BulkSelection"].Value = false;
			}
			((Control)MainDGV).Refresh();
		}
	}

	private void method_66(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in dictionary_0.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				switch (((ComboBox)ComboBox_BulkPhase).SelectedIndex)
				{
				case 0:
					item.Key.set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Completed);
					break;
				case 1:
					item.Key.set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
					break;
				case 2:
					item.Key.set_Phase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
					break;
				}
			}
		}
		method_7();
	}

	static OperationPlanner()
	{
		Class72.smethod_20();
	}
}
