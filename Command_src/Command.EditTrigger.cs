using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command_Core.Lua;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditTrigger : DarkSecondaryFormBase
{
	public delegate void EventTriggersChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	[CompilerGenerated]
	internal sealed class _Closure$__473-0
	{
		public List<int> $VB$Local_aircraftThatCanBeCargoDBIDs;

		public _Closure$__473-0(_Closure$__473-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_aircraftThatCanBeCargoDBIDs = arg0.$VB$Local_aircraftThatCanBeCargoDBIDs;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit u)
		{
			return $VB$Local_aircraftThatCanBeCargoDBIDs.Contains(u.DBID);
		}

		static _Closure$__473-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__473-1
	{
		public Side $VB$Local_theSide;

		public _Closure$__473-1(_Closure$__473-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(ActiveUnit u)
		{
			return u.get_UnitSide(SetSideOnly: false) == $VB$Local_theSide;
		}

		static _Closure$__473-1()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox _TextBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private DarkUIButton _Button_OK;

	[AccessedThroughProperty("Button_Cancel")]
	[CompilerGenerated]
	private DarkUIButton _Button_Cancel;

	[AccessedThroughProperty("CB_Points_ReachDirection")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Points_ReachDirection;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Points")]
	private DarkNumericUpDown _NUD_Points;

	[AccessedThroughProperty("CB_Points_Sides")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Points_Sides;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SetTime")]
	private DarkUIButton _Button_SetTime;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_DamagePercent")]
	private DarkNumericUpDown _NUD_DamagePercent;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UnitEntersArea")]
	private DarkUIButton _Button_UnitEntersArea;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnitDetected_Sides")]
	private DarkUIComboBox _CB_UnitDetected_Sides;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_RegularTimeInterval")]
	private DarkUIComboBox _CB_RegularTimeInterval;

	[AccessedThroughProperty("CB_MCL")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MCL;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage10")]
	private TabPage tabPage_0;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitFilter_BaseStatusCheck")]
	private UnitFilter _UnitFilter_BaseStatusCheck;

	[AccessedThroughProperty("TabPage99")]
	[CompilerGenerated]
	private TabPage tabPage_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BaseStatusCheck_BaseSide")]
	private DarkUIComboBox _CB_BaseStatusCheck_BaseSide;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BaseStatusCheck_Condition")]
	private DarkUIComboBox _CB_BaseStatusCheck_Condition;

	[AccessedThroughProperty("TabPage11")]
	[CompilerGenerated]
	private TabPage tabPage_2;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitEmissions_Side")]
	private DarkUIComboBox _UnitEmissions_Side;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitEmissions_MCL")]
	private DarkUIComboBox _UnitEmissions_MCL;

	[AccessedThroughProperty("TabPage12")]
	[CompilerGenerated]
	private TabPage tabPage_3;

	[CompilerGenerated]
	[AccessedThroughProperty("CargoFilter")]
	private CargoFilterObject cargoFilterObject_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnitCargo")]
	private DarkUIComboBox _CB_UnitCargo;

	[AccessedThroughProperty("CB_SideCargo")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SideCargo;

	[AccessedThroughProperty("NUM_RecvThresholdCargo")]
	[CompilerGenerated]
	private DarkNumericUpDown _NUM_RecvThresholdCargo;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CargoSpecificUnitCargo")]
	private DarkUIComboBox _CB_CargoSpecificUnitCargo;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CargoDBIDCargo")]
	private DarkUIComboBox _CB_CargoDBIDCargo;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CargoTypeCargo")]
	private DarkUIComboBox _CB_CargoTypeCargo;

	[CompilerGenerated]
	[AccessedThroughProperty("NUM_SendThresholdCargo")]
	private DarkNumericUpDown _NUM_SendThresholdCargo;

	[AccessedThroughProperty("DarkLabel10")]
	[CompilerGenerated]
	private DarkLabel darkLabel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel11")]
	private DarkLabel darkLabel_1;

	public EventTrigger theTrigger;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventTriggersChangedEventHandler eventTriggersChangedEventHandler_0;

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_4;
			DarkUITextBox darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TextBox1 = value;
			darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OK = value;
			darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TC_TriggerOptions")]
	internal virtual DarkUITabControl TC_TriggerOptions { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	internal virtual DarkUIComboBox CB_Points_ReachDirection
	{
		[CompilerGenerated]
		get
		{
			return _CB_Points_ReachDirection;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_Points_ReachDirection;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_Points_ReachDirection = value;
			darkUIComboBox = _CB_Points_ReachDirection;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkNumericUpDown NUD_Points
	{
		[CompilerGenerated]
		get
		{
			return _NUD_Points;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkNumericUpDown darkNumericUpDown = _NUD_Points;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged -= eventHandler;
			}
			_NUD_Points = value;
			darkNumericUpDown = _NUD_Points;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_Points_Sides
	{
		[CompilerGenerated]
		get
		{
			return _CB_Points_Sides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _CB_Points_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_Points_Sides = value;
			darkUIComboBox = _CB_Points_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	[field: AccessedThroughProperty("DTP_StartTime")]
	internal virtual DarkMaskedTextBox DTP_StartTime { get; set; }

	[field: AccessedThroughProperty("DTP_StartDate")]
	internal virtual DarkMaskedTextBox DTP_StartDate { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	internal virtual DarkUIButton Button_SetTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_SetTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_SetTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_SetTime = value;
			darkUIButton = _Button_SetTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkNumericUpDown NUD_DamagePercent
	{
		[CompilerGenerated]
		get
		{
			return _NUD_DamagePercent;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkNumericUpDown darkNumericUpDown = _NUD_DamagePercent;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged -= eventHandler;
			}
			_NUD_DamagePercent = value;
			darkNumericUpDown = _NUD_DamagePercent;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	[field: AccessedThroughProperty("UnitFilter_UnitInArea")]
	internal virtual UnitFilter UnitFilter_UnitInArea { get; set; }

	[field: AccessedThroughProperty("AreaEditor_UnitInArea")]
	internal virtual AreaEditor AreaEditor_UnitInArea { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("TB_Mins")]
	internal virtual DarkUITextBox TB_Mins { get; set; }

	[field: AccessedThroughProperty("TB_Hours")]
	internal virtual DarkUITextBox TB_Hours { get; set; }

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	[field: AccessedThroughProperty("TB_Days")]
	internal virtual DarkUITextBox TB_Days { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("Label12")]
	internal virtual DarkLabel Label12 { get; set; }

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("TB_Secs")]
	internal virtual DarkUITextBox TB_Secs { get; set; }

	[field: AccessedThroughProperty("TabPage6")]
	internal virtual TabPage TabPage6 { get; set; }

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual DarkGroupBox GroupBox2 { get; set; }

	[field: AccessedThroughProperty("Label_UnitEntersArea_Latest")]
	internal virtual DarkLabel Label_UnitEntersArea_Latest { get; set; }

	[field: AccessedThroughProperty("Label_UnitEntersArea_Earliest")]
	internal virtual DarkLabel Label_UnitEntersArea_Earliest { get; set; }

	[field: AccessedThroughProperty("AreaEditor_UnitEntersArea")]
	internal virtual AreaEditor AreaEditor_UnitEntersArea { get; set; }

	[field: AccessedThroughProperty("UnitFilter_UnitEntersArea")]
	internal virtual UnitFilter UnitFilter_UnitEntersArea { get; set; }

	[field: AccessedThroughProperty("DTP_EnterArea_ETOA_Date")]
	internal virtual DarkMaskedTextBox DTP_EnterArea_ETOA_Date { get; set; }

	[field: AccessedThroughProperty("DTP_EnterArea_LTOA_Date")]
	internal virtual DarkMaskedTextBox DTP_EnterArea_LTOA_Date { get; set; }

	internal virtual DarkUIButton Button_UnitEntersArea
	{
		[CompilerGenerated]
		get
		{
			return _Button_UnitEntersArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _Button_UnitEntersArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_UnitEntersArea = value;
			darkUIButton = _Button_UnitEntersArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DTP_EnterArea_LTOA_Time")]
	internal virtual DarkMaskedTextBox DTP_EnterArea_LTOA_Time { get; set; }

	[field: AccessedThroughProperty("CB_UnitEntersArea_ModifierNOT")]
	internal virtual DarkCheckBox CB_UnitEntersArea_ModifierNOT { get; set; }

	[field: AccessedThroughProperty("CB_UnitEntersArea_ModifierEXIT")]
	internal virtual DarkCheckBox CB_UnitEntersArea_ModifierEXIT { get; set; }

	internal virtual ToolTip ToolTip1
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

	[field: AccessedThroughProperty("DTP_EnterArea_ETOA_Time")]
	internal virtual DarkMaskedTextBox DTP_EnterArea_ETOA_Time { get; set; }

	[field: AccessedThroughProperty("TabPage7")]
	internal virtual TabPage TabPage7 { get; set; }

	[field: AccessedThroughProperty("Label14")]
	internal virtual DarkLabel Label14 { get; set; }

	[field: AccessedThroughProperty("DTP_LatestTime")]
	internal virtual DarkMaskedTextBox DTP_LatestTime { get; set; }

	[field: AccessedThroughProperty("DTP_LatestDate")]
	internal virtual DarkMaskedTextBox DTP_LatestDate { get; set; }

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

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
			EventHandler eventHandler = method_17;
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

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("DTP_EarliestTime")]
	internal virtual DarkMaskedTextBox DTP_EarliestTime { get; set; }

	[field: AccessedThroughProperty("DTP_EarliestDate")]
	internal virtual DarkMaskedTextBox DTP_EarliestDate { get; set; }

	[field: AccessedThroughProperty("TabPage8")]
	internal virtual TabPage TabPage8 { get; set; }

	internal virtual DarkUIComboBox CB_UnitDetected_Sides
	{
		[CompilerGenerated]
		get
		{
			return _CB_UnitDetected_Sides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIComboBox darkUIComboBox = _CB_UnitDetected_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_UnitDetected_Sides = value;
			darkUIComboBox = _CB_UnitDetected_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label15")]
	internal virtual DarkLabel Label15 { get; set; }

	[field: AccessedThroughProperty("TabPage9")]
	internal virtual TabPage TabPage9 { get; set; }

	internal virtual DarkUIComboBox CB_RegularTimeInterval
	{
		[CompilerGenerated]
		get
		{
			return _CB_RegularTimeInterval;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIComboBox darkUIComboBox = _CB_RegularTimeInterval;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_RegularTimeInterval = value;
			darkUIComboBox = _CB_RegularTimeInterval;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label17")]
	internal virtual DarkLabel Label17 { get; set; }

	internal virtual DarkUIComboBox CB_MCL
	{
		[CompilerGenerated]
		get
		{
			return _CB_MCL;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIComboBox darkUIComboBox = _CB_MCL;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MCL = value;
			darkUIComboBox = _CB_MCL;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label16")]
	internal virtual DarkLabel Label16 { get; set; }

	[field: AccessedThroughProperty("AreaEditor_DetectedArea")]
	internal virtual AreaEditor AreaEditor_DetectedArea { get; set; }

	internal virtual TabPage TabPage10
	{
		[CompilerGenerated]
		get
		{
			return tabPage_0;
		}
		[CompilerGenerated]
		set
		{
			tabPage_0 = value;
		}
	}

	internal virtual UnitFilter UnitFilter_BaseStatusCheck
	{
		[CompilerGenerated]
		get
		{
			return _UnitFilter_BaseStatusCheck;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			UnitFilter unitFilter = _UnitFilter_BaseStatusCheck;
			if (unitFilter != null)
			{
				((Control)unitFilter).Leave -= eventHandler;
			}
			_UnitFilter_BaseStatusCheck = value;
			unitFilter = _UnitFilter_BaseStatusCheck;
			if (unitFilter != null)
			{
				((Control)unitFilter).Leave += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("RandomTimeValue")]
	internal virtual DarkLabel RandomTimeValue { get; set; }

	internal virtual TabPage TabPage99
	{
		[CompilerGenerated]
		get
		{
			return tabPage_1;
		}
		[CompilerGenerated]
		set
		{
			tabPage_1 = value;
		}
	}

	[field: AccessedThroughProperty("BaseStatusCheck_Base")]
	internal virtual DarkLabel BaseStatusCheck_Base { get; set; }

	[field: AccessedThroughProperty("CB_BaseStatusCheck_Base")]
	internal virtual DarkUIComboBox CB_BaseStatusCheck_Base { get; set; }

	internal virtual DarkUIComboBox CB_BaseStatusCheck_BaseSide
	{
		[CompilerGenerated]
		get
		{
			return _CB_BaseStatusCheck_BaseSide;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIComboBox darkUIComboBox = _CB_BaseStatusCheck_BaseSide;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_BaseStatusCheck_BaseSide = value;
			darkUIComboBox = _CB_BaseStatusCheck_BaseSide;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("BaseStatusCheck_Unit_Label")]
	internal virtual DarkLabel BaseStatusCheck_Unit_Label { get; set; }

	[field: AccessedThroughProperty("BaseStatusCheck_BaseSide")]
	internal virtual DarkLabel BaseStatusCheck_BaseSide { get; set; }

	internal virtual DarkUIComboBox CB_BaseStatusCheck_Condition
	{
		[CompilerGenerated]
		get
		{
			return _CB_BaseStatusCheck_Condition;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIComboBox darkUIComboBox = _CB_BaseStatusCheck_Condition;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_BaseStatusCheck_Condition = value;
			darkUIComboBox = _CB_BaseStatusCheck_Condition;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual TabPage TabPage11
	{
		[CompilerGenerated]
		get
		{
			return tabPage_2;
		}
		[CompilerGenerated]
		set
		{
			tabPage_2 = value;
		}
	}

	internal virtual DarkUIComboBox UnitEmissions_Side
	{
		[CompilerGenerated]
		get
		{
			return _UnitEmissions_Side;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIComboBox darkUIComboBox = _UnitEmissions_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_UnitEmissions_Side = value;
			darkUIComboBox = _UnitEmissions_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UnitFilter_UnitEmissions")]
	internal virtual UnitFilter UnitFilter_UnitEmissions { get; set; }

	[field: AccessedThroughProperty("UnitEmissions_Side_label")]
	internal virtual DarkLabel UnitEmissions_Side_label { get; set; }

	internal virtual DarkUIComboBox UnitEmissions_MCL
	{
		[CompilerGenerated]
		get
		{
			return _UnitEmissions_MCL;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIComboBox darkUIComboBox = _UnitEmissions_MCL;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_UnitEmissions_MCL = value;
			darkUIComboBox = _UnitEmissions_MCL;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UnitEmissions_MCL_label")]
	internal virtual DarkLabel UnitEmissions_MCL_label { get; set; }

	[field: AccessedThroughProperty("AreaEditor_UnitEmissions")]
	internal virtual AreaEditor AreaEditor_UnitEmissions { get; set; }

	internal virtual TabPage TabPage12
	{
		[CompilerGenerated]
		get
		{
			return tabPage_3;
		}
		[CompilerGenerated]
		set
		{
			tabPage_3 = value;
		}
	}

	internal virtual CargoFilterObject CargoFilter
	{
		[CompilerGenerated]
		get
		{
			return cargoFilterObject_0;
		}
		[CompilerGenerated]
		set
		{
			cargoFilterObject_0 = value;
		}
	}

	[field: AccessedThroughProperty("UnitFilter_UnitDestroyed")]
	internal virtual UnitFilter UnitFilter_UnitDestroyed { get; set; }

	[field: AccessedThroughProperty("UnitFilter_UnitDamaged")]
	internal virtual UnitFilter UnitFilter_UnitDamaged { get; set; }

	[field: AccessedThroughProperty("UnitFilter_UnitDetected")]
	internal virtual UnitFilter UnitFilter_UnitDetected { get; set; }

	internal virtual DarkUIComboBox CB_UnitCargo
	{
		[CompilerGenerated]
		get
		{
			return _CB_UnitCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIComboBox darkUIComboBox = _CB_UnitCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_UnitCargo = value;
			darkUIComboBox = _CB_UnitCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkUIComboBox CB_SideCargo
	{
		[CompilerGenerated]
		get
		{
			return _CB_SideCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkUIComboBox darkUIComboBox = _CB_SideCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_SideCargo = value;
			darkUIComboBox = _CB_SideCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	internal virtual DarkNumericUpDown NUM_RecvThresholdCargo
	{
		[CompilerGenerated]
		get
		{
			return _NUM_RecvThresholdCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkNumericUpDown darkNumericUpDown = _NUM_RecvThresholdCargo;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_NUM_RecvThresholdCargo = value;
			darkNumericUpDown = _NUM_RecvThresholdCargo;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8 { get; set; }

	internal virtual DarkUIComboBox CB_CargoSpecificUnitCargo
	{
		[CompilerGenerated]
		get
		{
			return _CB_CargoSpecificUnitCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkUIComboBox darkUIComboBox = _CB_CargoSpecificUnitCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_CargoSpecificUnitCargo = value;
			darkUIComboBox = _CB_CargoSpecificUnitCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	internal virtual DarkUIComboBox CB_CargoDBIDCargo
	{
		[CompilerGenerated]
		get
		{
			return _CB_CargoDBIDCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkUIComboBox darkUIComboBox = _CB_CargoDBIDCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_CargoDBIDCargo = value;
			darkUIComboBox = _CB_CargoDBIDCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkUIComboBox CB_CargoTypeCargo
	{
		[CompilerGenerated]
		get
		{
			return _CB_CargoTypeCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkUIComboBox darkUIComboBox = _CB_CargoTypeCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_CargoTypeCargo = value;
			darkUIComboBox = _CB_CargoTypeCargo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	internal virtual DarkNumericUpDown NUM_SendThresholdCargo
	{
		[CompilerGenerated]
		get
		{
			return _NUM_SendThresholdCargo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkNumericUpDown darkNumericUpDown = _NUM_SendThresholdCargo;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_NUM_SendThresholdCargo = value;
			darkNumericUpDown = _NUM_SendThresholdCargo;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel9")]
	internal virtual DarkLabel DarkLabel9 { get; set; }

	internal virtual DarkLabel DarkLabel10
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

	[field: AccessedThroughProperty("Label_DescCargo")]
	internal virtual DarkLabel Label_DescCargo { get; set; }

	internal virtual DarkLabel DarkLabel11
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

	public static event EventTriggersChangedEventHandler EventTriggersChanged
	{
		[CompilerGenerated]
		add
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = eventTriggersChangedEventHandler_0;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Combine(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref eventTriggersChangedEventHandler_0, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = eventTriggersChangedEventHandler_0;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Remove(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref eventTriggersChangedEventHandler_0, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
	}

	public EditTrigger()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditTrigger_FormClosing);
		((Form)this).Load += EditTrigger_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditTrigger_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(EditTrigger_FormClosed);
		((Form)this).Closing += EditTrigger_Closing;
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
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Expected O, but got Unknown
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Expected O, but got Unknown
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Expected O, but got Unknown
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da4: Expected O, but got Unknown
		//IL_0fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Expected O, but got Unknown
		//IL_1101: Unknown result type (might be due to invalid IL or missing references)
		//IL_110b: Expected O, but got Unknown
		//IL_11ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f7: Expected O, but got Unknown
		//IL_13e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1448: Unknown result type (might be due to invalid IL or missing references)
		//IL_1452: Expected O, but got Unknown
		//IL_1493: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1507: Expected O, but got Unknown
		//IL_19c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ce: Expected O, but got Unknown
		//IL_1b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b20: Expected O, but got Unknown
		//IL_1c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c71: Expected O, but got Unknown
		//IL_1e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e43: Expected O, but got Unknown
		//IL_23db: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e5: Expected O, but got Unknown
		//IL_2423: Unknown result type (might be due to invalid IL or missing references)
		//IL_298f: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fc: Expected O, but got Unknown
		//IL_2aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aaf: Expected O, but got Unknown
		//IL_2c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c74: Expected O, but got Unknown
		//IL_2d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d15: Expected O, but got Unknown
		//IL_2d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dcd: Expected O, but got Unknown
		//IL_3020: Unknown result type (might be due to invalid IL or missing references)
		//IL_3178: Unknown result type (might be due to invalid IL or missing references)
		//IL_3182: Expected O, but got Unknown
		//IL_32d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_32df: Expected O, but got Unknown
		//IL_3424: Unknown result type (might be due to invalid IL or missing references)
		//IL_349c: Unknown result type (might be due to invalid IL or missing references)
		//IL_34a6: Expected O, but got Unknown
		//IL_36ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_37f6: Expected O, but got Unknown
		//IL_3885: Unknown result type (might be due to invalid IL or missing references)
		//IL_388f: Expected O, but got Unknown
		//IL_3aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aab: Expected O, but got Unknown
		//IL_3cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cbb: Expected O, but got Unknown
		//IL_3f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f8f: Expected O, but got Unknown
		//IL_43b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_43c0: Expected O, but got Unknown
		//IL_44e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ec: Expected O, but got Unknown
		//IL_4614: Unknown result type (might be due to invalid IL or missing references)
		//IL_461e: Expected O, but got Unknown
		//IL_4730: Unknown result type (might be due to invalid IL or missing references)
		//IL_473a: Expected O, but got Unknown
		//IL_484b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4855: Expected O, but got Unknown
		//IL_49e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_49f1: Expected O, but got Unknown
		//IL_4afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b06: Expected O, but got Unknown
		//IL_4c03: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button_OK = new DarkUIButton();
		Button_Cancel = new DarkUIButton();
		Label3 = new DarkLabel();
		TabPage1 = new TabPage();
		UnitFilter_UnitDestroyed = new UnitFilter();
		TC_TriggerOptions = new DarkUITabControl();
		TabPage2 = new TabPage();
		UnitFilter_UnitDamaged = new UnitFilter();
		NUD_DamagePercent = new DarkNumericUpDown();
		Label7 = new DarkLabel();
		TabPage3 = new TabPage();
		CB_Points_ReachDirection = new DarkUIComboBox();
		Label5 = new DarkLabel();
		NUD_Points = new DarkNumericUpDown();
		CB_Points_Sides = new DarkUIComboBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TabPage4 = new TabPage();
		Button_SetTime = new DarkUIButton();
		Label6 = new DarkLabel();
		DTP_StartTime = new DarkMaskedTextBox();
		DTP_StartDate = new DarkMaskedTextBox();
		TabPage5 = new TabPage();
		GroupBox1 = new DarkGroupBox();
		Label12 = new DarkLabel();
		Label11 = new DarkLabel();
		TB_Secs = new DarkUITextBox();
		TB_Mins = new DarkUITextBox();
		TB_Hours = new DarkUITextBox();
		Label10 = new DarkLabel();
		TB_Days = new DarkUITextBox();
		Label9 = new DarkLabel();
		AreaEditor_UnitInArea = new AreaEditor();
		UnitFilter_UnitInArea = new UnitFilter();
		TabPage6 = new TabPage();
		CB_UnitEntersArea_ModifierNOT = new DarkCheckBox();
		CB_UnitEntersArea_ModifierEXIT = new DarkCheckBox();
		GroupBox2 = new DarkGroupBox();
		Button_UnitEntersArea = new DarkUIButton();
		DTP_EnterArea_LTOA_Time = new DarkMaskedTextBox();
		DTP_EnterArea_ETOA_Time = new DarkMaskedTextBox();
		DTP_EnterArea_LTOA_Date = new DarkMaskedTextBox();
		DTP_EnterArea_ETOA_Date = new DarkMaskedTextBox();
		Label_UnitEntersArea_Latest = new DarkLabel();
		Label_UnitEntersArea_Earliest = new DarkLabel();
		AreaEditor_UnitEntersArea = new AreaEditor();
		UnitFilter_UnitEntersArea = new UnitFilter();
		TabPage7 = new TabPage();
		RandomTimeValue = new DarkLabel();
		Label14 = new DarkLabel();
		DTP_LatestTime = new DarkMaskedTextBox();
		DTP_LatestDate = new DarkMaskedTextBox();
		Label13 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label8 = new DarkLabel();
		DTP_EarliestTime = new DarkMaskedTextBox();
		DTP_EarliestDate = new DarkMaskedTextBox();
		TabPage8 = new TabPage();
		UnitFilter_UnitDetected = new UnitFilter();
		AreaEditor_DetectedArea = new AreaEditor();
		CB_MCL = new DarkUIComboBox();
		Label16 = new DarkLabel();
		CB_UnitDetected_Sides = new DarkUIComboBox();
		Label15 = new DarkLabel();
		TabPage9 = new TabPage();
		CB_RegularTimeInterval = new DarkUIComboBox();
		Label17 = new DarkLabel();
		TabPage10 = new TabPage();
		UnitFilter_BaseStatusCheck = new UnitFilter();
		CB_BaseStatusCheck_Base = new DarkUIComboBox();
		CB_BaseStatusCheck_BaseSide = new DarkUIComboBox();
		BaseStatusCheck_Unit_Label = new DarkLabel();
		BaseStatusCheck_BaseSide = new DarkLabel();
		BaseStatusCheck_Base = new DarkLabel();
		CB_BaseStatusCheck_Condition = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		TabPage11 = new TabPage();
		UnitEmissions_MCL = new DarkUIComboBox();
		UnitEmissions_MCL_label = new DarkLabel();
		AreaEditor_UnitEmissions = new AreaEditor();
		UnitFilter_UnitEmissions = new UnitFilter();
		UnitEmissions_Side_label = new DarkLabel();
		UnitEmissions_Side = new DarkUIComboBox();
		TabPage12 = new TabPage();
		Label_DescCargo = new DarkLabel();
		DarkLabel11 = new DarkLabel();
		DarkLabel10 = new DarkLabel();
		NUM_SendThresholdCargo = new DarkNumericUpDown();
		DarkLabel9 = new DarkLabel();
		NUM_RecvThresholdCargo = new DarkNumericUpDown();
		DarkLabel8 = new DarkLabel();
		CB_CargoSpecificUnitCargo = new DarkUIComboBox();
		DarkLabel7 = new DarkLabel();
		CB_CargoDBIDCargo = new DarkUIComboBox();
		DarkLabel5 = new DarkLabel();
		CB_CargoTypeCargo = new DarkUIComboBox();
		DarkLabel6 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		CB_UnitCargo = new DarkUIComboBox();
		DarkLabel3 = new DarkLabel();
		CB_SideCargo = new DarkUIComboBox();
		DarkLabel2 = new DarkLabel();
		TabPage99 = new TabPage();
		ToolTip1 = new ToolTip(icontainer_1);
		((Control)TabPage1).SuspendLayout();
		((Control)TC_TriggerOptions).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((ISupportInitialize)NUD_DamagePercent).BeginInit();
		((Control)TabPage3).SuspendLayout();
		((ISupportInitialize)NUD_Points).BeginInit();
		((Control)TabPage4).SuspendLayout();
		((Control)TabPage5).SuspendLayout();
		((Control)GroupBox1).SuspendLayout();
		((Control)TabPage6).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((Control)TabPage7).SuspendLayout();
		((Control)TabPage8).SuspendLayout();
		((Control)TabPage9).SuspendLayout();
		((Control)TabPage10).SuspendLayout();
		((Control)TabPage11).SuspendLayout();
		((Control)TabPage12).SuspendLayout();
		((ISupportInitialize)NUM_SendThresholdCargo).BeginInit();
		((ISupportInitialize)NUM_RecvThresholdCargo).BeginInit();
		((Control)this).SuspendLayout();
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(4, 10);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(69, 13);
		((Control)Label2).TabIndex = 3;
		((Label)Label2).Text = "Description:";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(90, 6);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(451, 20);
		((Control)TextBox1).TabIndex = 4;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Control)Button_OK).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_OK).BackColor = Color.Transparent;
		((Control)Button_OK).Font = new Font("Segoe UI", 10f);
		((Control)Button_OK).ForeColor = SystemColors.Control;
		((Control)Button_OK).Location = new Point(2, 402);
		((Control)Button_OK).Name = "Button_OK";
		((Control)Button_OK).Padding = new Padding(5);
		Button_OK.RoundRadius = 0;
		((Control)Button_OK).Size = new Size(146, 23);
		((Control)Button_OK).TabIndex = 5;
		Button_OK.Text = "OK";
		((Control)Button_Cancel).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Cancel).BackColor = Color.Transparent;
		((Control)Button_Cancel).Font = new Font("Segoe UI", 10f);
		((Control)Button_Cancel).ForeColor = SystemColors.Control;
		((Control)Button_Cancel).Location = new Point(624, 402);
		((Control)Button_Cancel).Name = "Button_Cancel";
		((Control)Button_Cancel).Padding = new Padding(5);
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(155, 23);
		((Control)Button_Cancel).TabIndex = 6;
		Button_Cancel.Text = "Cancel";
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(1, 43);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(105, 13);
		((Control)Label3).TabIndex = 7;
		((Label)Label3).Text = "Settings for trigger";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)UnitFilter_UnitDestroyed);
		TabPage1.Location = new Point(4, 68);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(779, 265);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Unit is Destroyed";
		((Control)UnitFilter_UnitDestroyed).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitDestroyed.FilterObject = null;
		((Control)UnitFilter_UnitDestroyed).Location = new Point(6, 23);
		((Control)UnitFilter_UnitDestroyed).Name = "UnitFilter_UnitDestroyed";
		((Control)UnitFilter_UnitDestroyed).Size = new Size(311, 215);
		((Control)UnitFilter_UnitDestroyed).TabIndex = 1;
		((Control)TC_TriggerOptions).Anchor = (AnchorStyles)15;
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage1);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage2);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage3);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage4);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage5);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage6);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage7);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage8);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage9);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage10);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage11);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage12);
		((Control)TC_TriggerOptions).Controls.Add((Control)(object)TabPage99);
		((Control)TC_TriggerOptions).Cursor = Cursors.Hand;
		((Control)TC_TriggerOptions).Font = new Font("Segoe UI", 8f);
		((TabControl)TC_TriggerOptions).ItemSize = new Size(80, 32);
		((Control)TC_TriggerOptions).Location = new Point(2, 59);
		((TabControl)TC_TriggerOptions).Multiline = true;
		((Control)TC_TriggerOptions).Name = "TC_TriggerOptions";
		((TabControl)TC_TriggerOptions).SelectedIndex = 0;
		((Control)TC_TriggerOptions).Size = new Size(787, 337);
		((TabControl)TC_TriggerOptions).SizeMode = (TabSizeMode)2;
		((Control)TC_TriggerOptions).TabIndex = 20;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)UnitFilter_UnitDamaged);
		((Control)TabPage2).Controls.Add((Control)(object)NUD_DamagePercent);
		((Control)TabPage2).Controls.Add((Control)(object)Label7);
		TabPage2.Location = new Point(4, 68);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Size = new Size(779, 265);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Unit is Damaged";
		((Control)UnitFilter_UnitDamaged).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitDamaged.FilterObject = null;
		((Control)UnitFilter_UnitDamaged).Location = new Point(2, 1);
		((Control)UnitFilter_UnitDamaged).Name = "UnitFilter_UnitDamaged";
		((Control)UnitFilter_UnitDamaged).Size = new Size(311, 215);
		((Control)UnitFilter_UnitDamaged).TabIndex = 4;
		((UpDownBase)NUD_DamagePercent).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD_DamagePercent).BorderStyle = (BorderStyle)1;
		((Control)NUD_DamagePercent).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUD_DamagePercent).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_DamagePercent).Location = new Point(200, 218);
		((Control)NUD_DamagePercent).Name = "NUD_DamagePercent";
		((Control)NUD_DamagePercent).Size = new Size(74, 25);
		((Control)NUD_DamagePercent).TabIndex = 3;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(18, 224);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(148, 13);
		((Control)Label7).TabIndex = 2;
		((Label)Label7).Text = "Damage Percent Threshold:";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)CB_Points_ReachDirection);
		((Control)TabPage3).Controls.Add((Control)(object)Label5);
		((Control)TabPage3).Controls.Add((Control)(object)NUD_Points);
		((Control)TabPage3).Controls.Add((Control)(object)CB_Points_Sides);
		((Control)TabPage3).Controls.Add((Control)(object)Label4);
		((Control)TabPage3).Controls.Add((Control)(object)Label1);
		TabPage3.Location = new Point(4, 68);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(779, 265);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Side Points";
		((ComboBox)CB_Points_ReachDirection).BackColor = Color.Transparent;
		((ComboBox)CB_Points_ReachDirection).DrawMode = (DrawMode)1;
		((ComboBox)CB_Points_ReachDirection).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Points_ReachDirection).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Points_ReachDirection).FormattingEnabled = true;
		((ComboBox)CB_Points_ReachDirection).Items.AddRange(new object[3] { "exceeds", "reaches exactly", "falls under" });
		((Control)CB_Points_ReachDirection).Location = new Point(153, 126);
		((Control)CB_Points_ReachDirection).Name = "CB_Points_ReachDirection";
		((Control)CB_Points_ReachDirection).Size = new Size(121, 21);
		((Control)CB_Points_ReachDirection).TabIndex = 10;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(351, 128);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(40, 13);
		((Control)Label5).TabIndex = 9;
		((Label)Label5).Text = "points";
		((UpDownBase)NUD_Points).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD_Points).BorderStyle = (BorderStyle)1;
		((Control)NUD_Points).Font = new Font("Segoe UI", 8f);
		((UpDownBase)NUD_Points).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_Points).Location = new Point(280, 126);
		((NumericUpDown)NUD_Points).Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((NumericUpDown)NUD_Points).Minimum = new decimal(new int[4] { 999999, 0, 0, -2147483648 });
		((Control)NUD_Points).Name = "NUD_Points";
		((Control)NUD_Points).Size = new Size(65, 22);
		((Control)NUD_Points).TabIndex = 8;
		((ComboBox)CB_Points_Sides).BackColor = Color.Transparent;
		((ComboBox)CB_Points_Sides).DrawMode = (DrawMode)1;
		((ComboBox)CB_Points_Sides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Points_Sides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Points_Sides).FormattingEnabled = true;
		((Control)CB_Points_Sides).Location = new Point(153, 98);
		((Control)CB_Points_Sides).Name = "CB_Points_Sides";
		((Control)CB_Points_Sides).Size = new Size(192, 21);
		((Control)CB_Points_Sides).TabIndex = 7;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(8, 130);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(146, 13);
		((Control)Label4).TabIndex = 6;
		((Label)Label4).Text = "Trigger activates when side";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(116, 101);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(32, 13);
		((Control)Label1).TabIndex = 5;
		((Label)Label1).Text = "Side:";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)Button_SetTime);
		((Control)TabPage4).Controls.Add((Control)(object)Label6);
		((Control)TabPage4).Controls.Add((Control)(object)DTP_StartTime);
		((Control)TabPage4).Controls.Add((Control)(object)DTP_StartDate);
		TabPage4.Location = new Point(4, 68);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Padding = new Padding(3);
		((Control)TabPage4).Size = new Size(779, 265);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Time";
		((ButtonBase)Button_SetTime).BackColor = Color.Transparent;
		((Control)Button_SetTime).Font = new Font("Segoe UI", 10f);
		((Control)Button_SetTime).ForeColor = SystemColors.Control;
		((Control)Button_SetTime).Location = new Point(229, 139);
		((Control)Button_SetTime).Name = "Button_SetTime";
		((Control)Button_SetTime).Padding = new Padding(5);
		Button_SetTime.RoundRadius = 0;
		((Control)Button_SetTime).Size = new Size(75, 23);
		((Control)Button_SetTime).TabIndex = 25;
		Button_SetTime.Text = "Set Time";
		Label6.AutoSize = true;
		((Control)Label6).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(158, 45);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(41, 13);
		((Control)Label6).TabIndex = 24;
		((Label)Label6).Text = "Label6";
		((TextBoxBase)DTP_StartTime).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_StartTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_StartTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_StartTime).Location = new Point(161, 113);
		((Control)DTP_StartTime).Name = "DTP_StartTime";
		((Control)DTP_StartTime).Size = new Size(223, 22);
		((Control)DTP_StartTime).TabIndex = 23;
		((TextBoxBase)DTP_StartDate).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_StartDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_StartDate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_StartDate).Location = new Point(161, 87);
		((Control)DTP_StartDate).Name = "DTP_StartDate";
		((Control)DTP_StartDate).Size = new Size(223, 22);
		((Control)DTP_StartDate).TabIndex = 22;
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage5).Controls.Add((Control)(object)GroupBox1);
		((Control)TabPage5).Controls.Add((Control)(object)AreaEditor_UnitInArea);
		((Control)TabPage5).Controls.Add((Control)(object)UnitFilter_UnitInArea);
		TabPage5.Location = new Point(4, 68);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Size = new Size(779, 265);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "Unit Remains In Area";
		((Control)GroupBox1).Controls.Add((Control)(object)Label12);
		((Control)GroupBox1).Controls.Add((Control)(object)Label11);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Secs);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Mins);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Hours);
		((Control)GroupBox1).Controls.Add((Control)(object)Label10);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Days);
		((Control)GroupBox1).Controls.Add((Control)(object)Label9);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(387, 15);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(163, 119);
		((Control)GroupBox1).TabIndex = 4;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Required Time Amount";
		Label12.AutoSize = true;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(119, 78);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(28, 13);
		((Control)Label12).TabIndex = 27;
		((Label)Label12).Text = "secs";
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(43, 78);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(31, 13);
		((Control)Label11).TabIndex = 26;
		((Label)Label11).Text = "mins";
		TB_Secs.AutoCompleteCustomSource = null;
		TB_Secs.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Secs.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Secs).BackColor = Color.Transparent;
		TB_Secs.Font = new Font("Segoe UI", 10f);
		((Control)TB_Secs).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Secs.Image = null;
		TB_Secs.Lines = null;
		((Control)TB_Secs).Location = new Point(78, 75);
		TB_Secs.MaxLength = 32767;
		TB_Secs.Multiline = false;
		((Control)TB_Secs).Name = "TB_Secs";
		TB_Secs.ReadOnly = false;
		TB_Secs.ScrollBars = (ScrollBars)0;
		TB_Secs.SelectionStart = 0;
		((Control)TB_Secs).Size = new Size(39, 20);
		((Control)TB_Secs).TabIndex = 25;
		TB_Secs.Text = "0";
		TB_Secs.TextAlign = (HorizontalAlignment)0;
		TB_Secs.UseSystemPasswordChar = false;
		TB_Secs.WatermarkText = "";
		TB_Secs.WordWrap = false;
		TB_Mins.AutoCompleteCustomSource = null;
		TB_Mins.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Mins.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Mins).BackColor = Color.Transparent;
		TB_Mins.Font = new Font("Segoe UI", 10f);
		((Control)TB_Mins).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Mins.Image = null;
		TB_Mins.Lines = null;
		((Control)TB_Mins).Location = new Point(6, 75);
		TB_Mins.MaxLength = 32767;
		TB_Mins.Multiline = false;
		((Control)TB_Mins).Name = "TB_Mins";
		TB_Mins.ReadOnly = false;
		TB_Mins.ScrollBars = (ScrollBars)0;
		TB_Mins.SelectionStart = 0;
		((Control)TB_Mins).Size = new Size(36, 20);
		((Control)TB_Mins).TabIndex = 24;
		TB_Mins.Text = "0";
		TB_Mins.TextAlign = (HorizontalAlignment)0;
		TB_Mins.UseSystemPasswordChar = false;
		TB_Mins.WatermarkText = "";
		TB_Mins.WordWrap = false;
		TB_Hours.AutoCompleteCustomSource = null;
		TB_Hours.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Hours.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Hours).BackColor = Color.Transparent;
		TB_Hours.Font = new Font("Segoe UI", 10f);
		((Control)TB_Hours).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Hours.Image = null;
		TB_Hours.Lines = null;
		((Control)TB_Hours).Location = new Point(78, 35);
		TB_Hours.MaxLength = 32767;
		TB_Hours.Multiline = false;
		((Control)TB_Hours).Name = "TB_Hours";
		TB_Hours.ReadOnly = false;
		TB_Hours.ScrollBars = (ScrollBars)0;
		TB_Hours.SelectionStart = 0;
		((Control)TB_Hours).Size = new Size(39, 20);
		((Control)TB_Hours).TabIndex = 22;
		TB_Hours.Text = "0";
		TB_Hours.TextAlign = (HorizontalAlignment)0;
		TB_Hours.UseSystemPasswordChar = false;
		TB_Hours.WatermarkText = "";
		TB_Hours.WordWrap = false;
		Label10.AutoSize = true;
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(40, 39);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(30, 13);
		((Control)Label10).TabIndex = 19;
		((Label)Label10).Text = "days";
		TB_Days.AutoCompleteCustomSource = null;
		TB_Days.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Days.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Days).BackColor = Color.Transparent;
		TB_Days.Font = new Font("Segoe UI", 10f);
		((Control)TB_Days).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Days.Image = null;
		TB_Days.Lines = null;
		((Control)TB_Days).Location = new Point(7, 35);
		TB_Days.MaxLength = 32767;
		TB_Days.Multiline = false;
		((Control)TB_Days).Name = "TB_Days";
		TB_Days.ReadOnly = false;
		TB_Days.ScrollBars = (ScrollBars)0;
		TB_Days.SelectionStart = 0;
		((Control)TB_Days).Size = new Size(35, 20);
		((Control)TB_Days).TabIndex = 20;
		TB_Days.Text = "0";
		TB_Days.TextAlign = (HorizontalAlignment)0;
		TB_Days.UseSystemPasswordChar = false;
		TB_Days.WatermarkText = "";
		TB_Days.WordWrap = false;
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(119, 39);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(37, 13);
		((Control)Label9).TabIndex = 21;
		((Label)Label9).Text = "hours";
		((Control)AreaEditor_UnitInArea).BackColor = Color.FromArgb(60, 63, 65);
		((Control)AreaEditor_UnitInArea).Location = new Point(387, 170);
		((Control)AreaEditor_UnitInArea).Name = "AreaEditor_UnitInArea";
		((Control)AreaEditor_UnitInArea).Size = new Size(351, 124);
		((Control)AreaEditor_UnitInArea).TabIndex = 3;
		AreaEditor_UnitInArea.Title = "Area To Be Inside";
		((Control)UnitFilter_UnitInArea).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitInArea.FilterObject = null;
		((Control)UnitFilter_UnitInArea).Location = new Point(6, 6);
		((Control)UnitFilter_UnitInArea).MinimumSize = new Size(311, 177);
		((Control)UnitFilter_UnitInArea).Name = "UnitFilter_UnitInArea";
		((Control)UnitFilter_UnitInArea).Size = new Size(311, 204);
		((Control)UnitFilter_UnitInArea).TabIndex = 2;
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage6).Controls.Add((Control)(object)CB_UnitEntersArea_ModifierNOT);
		((Control)TabPage6).Controls.Add((Control)(object)CB_UnitEntersArea_ModifierEXIT);
		((Control)TabPage6).Controls.Add((Control)(object)GroupBox2);
		((Control)TabPage6).Controls.Add((Control)(object)AreaEditor_UnitEntersArea);
		((Control)TabPage6).Controls.Add((Control)(object)UnitFilter_UnitEntersArea);
		TabPage6.Location = new Point(4, 68);
		((Control)TabPage6).Name = "TabPage6";
		((Control)TabPage6).Size = new Size(779, 265);
		TabPage6.TabIndex = 5;
		TabPage6.Text = "Unit Enters Area";
		((ButtonBase)CB_UnitEntersArea_ModifierNOT).AutoSize = true;
		((Control)CB_UnitEntersArea_ModifierNOT).Location = new Point(201, 222);
		((Control)CB_UnitEntersArea_ModifierNOT).Name = "CB_UnitEntersArea_ModifierNOT";
		((Control)CB_UnitEntersArea_ModifierNOT).Size = new Size(99, 17);
		((Control)CB_UnitEntersArea_ModifierNOT).TabIndex = 8;
		((ButtonBase)CB_UnitEntersArea_ModifierNOT).Text = "Modifier: NOT";
		ToolTip1.SetToolTip((Control)(object)CB_UnitEntersArea_ModifierNOT, "\"When checked, the trigger fires if an eligible unit is NOT in the specified area within the specified time frame");
		((ButtonBase)CB_UnitEntersArea_ModifierEXIT).AutoSize = true;
		((Control)CB_UnitEntersArea_ModifierEXIT).Location = new Point(69, 222);
		((Control)CB_UnitEntersArea_ModifierEXIT).Name = "CB_UnitEntersArea_ModifierEXIT";
		((Control)CB_UnitEntersArea_ModifierEXIT).Size = new Size(97, 17);
		((Control)CB_UnitEntersArea_ModifierEXIT).TabIndex = 9;
		((ButtonBase)CB_UnitEntersArea_ModifierEXIT).Text = "Modifier: EXIT";
		ToolTip1.SetToolTip((Control)(object)CB_UnitEntersArea_ModifierEXIT, "\"When checked, the trigger fires if an eligible unit EXITs the specified area within the specified time frame");
		((Control)GroupBox2).Controls.Add((Control)(object)Button_UnitEntersArea);
		((Control)GroupBox2).Controls.Add((Control)(object)DTP_EnterArea_LTOA_Time);
		((Control)GroupBox2).Controls.Add((Control)(object)DTP_EnterArea_ETOA_Time);
		((Control)GroupBox2).Controls.Add((Control)(object)DTP_EnterArea_LTOA_Date);
		((Control)GroupBox2).Controls.Add((Control)(object)DTP_EnterArea_ETOA_Date);
		((Control)GroupBox2).Controls.Add((Control)(object)Label_UnitEntersArea_Latest);
		((Control)GroupBox2).Controls.Add((Control)(object)Label_UnitEntersArea_Earliest);
		((Control)GroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox2).Location = new Point(323, 16);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(415, 130);
		((Control)GroupBox2).TabIndex = 7;
		((GroupBox)GroupBox2).TabStop = false;
		((GroupBox)GroupBox2).Text = "Earliest + Latest Time";
		((Control)Button_UnitEntersArea).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_UnitEntersArea).BackColor = Color.Transparent;
		((Control)Button_UnitEntersArea).Font = new Font("Segoe UI", 10f);
		((Control)Button_UnitEntersArea).ForeColor = SystemColors.Control;
		((Control)Button_UnitEntersArea).Location = new Point(148, 102);
		((Control)Button_UnitEntersArea).Name = "Button_UnitEntersArea";
		((Control)Button_UnitEntersArea).Padding = new Padding(5);
		Button_UnitEntersArea.RoundRadius = 0;
		((Control)Button_UnitEntersArea).Size = new Size(142, 22);
		((Control)Button_UnitEntersArea).TabIndex = 32;
		Button_UnitEntersArea.Text = "SET TIMES";
		((TextBoxBase)DTP_EnterArea_LTOA_Time).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EnterArea_LTOA_Time).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EnterArea_LTOA_Time).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EnterArea_LTOA_Time).Location = new Point(301, 63);
		((Control)DTP_EnterArea_LTOA_Time).Name = "DTP_EnterArea_LTOA_Time";
		((Control)DTP_EnterArea_LTOA_Time).Size = new Size(93, 22);
		((Control)DTP_EnterArea_LTOA_Time).TabIndex = 31;
		((TextBoxBase)DTP_EnterArea_ETOA_Time).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EnterArea_ETOA_Time).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EnterArea_ETOA_Time).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EnterArea_ETOA_Time).Location = new Point(104, 63);
		((Control)DTP_EnterArea_ETOA_Time).Name = "DTP_EnterArea_ETOA_Time";
		((Control)DTP_EnterArea_ETOA_Time).Size = new Size(93, 22);
		((Control)DTP_EnterArea_ETOA_Time).TabIndex = 30;
		((TextBoxBase)DTP_EnterArea_LTOA_Date).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EnterArea_LTOA_Date).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EnterArea_LTOA_Date).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EnterArea_LTOA_Date).Location = new Point(203, 37);
		((Control)DTP_EnterArea_LTOA_Date).Name = "DTP_EnterArea_LTOA_Date";
		((Control)DTP_EnterArea_LTOA_Date).Size = new Size(191, 22);
		((Control)DTP_EnterArea_LTOA_Date).TabIndex = 29;
		((TextBoxBase)DTP_EnterArea_ETOA_Date).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EnterArea_ETOA_Date).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EnterArea_ETOA_Date).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EnterArea_ETOA_Date).Location = new Point(6, 37);
		((Control)DTP_EnterArea_ETOA_Date).Name = "DTP_EnterArea_ETOA_Date";
		((Control)DTP_EnterArea_ETOA_Date).Size = new Size(191, 22);
		((Control)DTP_EnterArea_ETOA_Date).TabIndex = 28;
		Label_UnitEntersArea_Latest.AutoSize = true;
		((Control)Label_UnitEntersArea_Latest).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_UnitEntersArea_Latest).Location = new Point(200, 21);
		((Control)Label_UnitEntersArea_Latest).Name = "Label_UnitEntersArea_Latest";
		((Control)Label_UnitEntersArea_Latest).Size = new Size(40, 13);
		((Control)Label_UnitEntersArea_Latest).TabIndex = 27;
		((Label)Label_UnitEntersArea_Latest).Text = "Latest:";
		Label_UnitEntersArea_Earliest.AutoSize = true;
		((Control)Label_UnitEntersArea_Earliest).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_UnitEntersArea_Earliest).Location = new Point(3, 21);
		((Control)Label_UnitEntersArea_Earliest).Name = "Label_UnitEntersArea_Earliest";
		((Control)Label_UnitEntersArea_Earliest).Size = new Size(47, 13);
		((Control)Label_UnitEntersArea_Earliest).TabIndex = 26;
		((Label)Label_UnitEntersArea_Earliest).Text = "Earliest:";
		((Control)AreaEditor_UnitEntersArea).BackColor = Color.FromArgb(60, 63, 65);
		((Control)AreaEditor_UnitEntersArea).Location = new Point(387, 172);
		((Control)AreaEditor_UnitEntersArea).Name = "AreaEditor_UnitEntersArea";
		((Control)AreaEditor_UnitEntersArea).Size = new Size(351, 125);
		((Control)AreaEditor_UnitEntersArea).TabIndex = 6;
		AreaEditor_UnitEntersArea.Title = "Area To Be Inside";
		((Control)UnitFilter_UnitEntersArea).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitEntersArea.FilterObject = null;
		((Control)UnitFilter_UnitEntersArea).Location = new Point(6, 6);
		((Control)UnitFilter_UnitEntersArea).MinimumSize = new Size(311, 177);
		((Control)UnitFilter_UnitEntersArea).Name = "UnitFilter_UnitEntersArea";
		((Control)UnitFilter_UnitEntersArea).Size = new Size(311, 194);
		((Control)UnitFilter_UnitEntersArea).TabIndex = 5;
		TabPage7.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage7).Controls.Add((Control)(object)RandomTimeValue);
		((Control)TabPage7).Controls.Add((Control)(object)Label14);
		((Control)TabPage7).Controls.Add((Control)(object)DTP_LatestTime);
		((Control)TabPage7).Controls.Add((Control)(object)DTP_LatestDate);
		((Control)TabPage7).Controls.Add((Control)(object)Label13);
		((Control)TabPage7).Controls.Add((Control)(object)Button1);
		((Control)TabPage7).Controls.Add((Control)(object)Label8);
		((Control)TabPage7).Controls.Add((Control)(object)DTP_EarliestTime);
		((Control)TabPage7).Controls.Add((Control)(object)DTP_EarliestDate);
		TabPage7.Location = new Point(4, 68);
		((Control)TabPage7).Name = "TabPage7";
		((Control)TabPage7).Padding = new Padding(3);
		((Control)TabPage7).Size = new Size(779, 265);
		TabPage7.TabIndex = 6;
		TabPage7.Text = "Random Time";
		RandomTimeValue.AutoSize = true;
		((Control)RandomTimeValue).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)RandomTimeValue).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RandomTimeValue).Location = new Point(489, 176);
		((Control)RandomTimeValue).Name = "RandomTimeValue";
		((Control)RandomTimeValue).Size = new Size(74, 13);
		((Control)RandomTimeValue).TabIndex = 34;
		((Label)RandomTimeValue).Text = "Variable time";
		((Control)RandomTimeValue).Visible = false;
		Label14.AutoSize = true;
		((Control)Label14).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label14).Location = new Point(169, 154);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(41, 13);
		((Control)Label14).TabIndex = 33;
		((Label)Label14).Text = "Latest:";
		((TextBoxBase)DTP_LatestTime).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_LatestTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_LatestTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_LatestTime).Location = new Point(172, 196);
		((Control)DTP_LatestTime).Name = "DTP_LatestTime";
		((Control)DTP_LatestTime).Size = new Size(223, 22);
		((Control)DTP_LatestTime).TabIndex = 32;
		((TextBoxBase)DTP_LatestDate).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_LatestDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_LatestDate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_LatestDate).Location = new Point(172, 170);
		((Control)DTP_LatestDate).Name = "DTP_LatestDate";
		((Control)DTP_LatestDate).Size = new Size(223, 22);
		((Control)DTP_LatestDate).TabIndex = 31;
		Label13.AutoSize = true;
		((Control)Label13).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(169, 77);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(47, 13);
		((Control)Label13).TabIndex = 30;
		((Label)Label13).Text = "Earliest:";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(221, 235);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(131, 23);
		((Control)Button1).TabIndex = 29;
		Button1.Text = "Set Random Time";
		Label8.AutoSize = true;
		((Control)Label8).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(170, 23);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(41, 13);
		((Control)Label8).TabIndex = 28;
		((Label)Label8).Text = "Label8";
		((TextBoxBase)DTP_EarliestTime).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EarliestTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EarliestTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EarliestTime).Location = new Point(172, 119);
		((Control)DTP_EarliestTime).Name = "DTP_EarliestTime";
		((Control)DTP_EarliestTime).Size = new Size(223, 22);
		((Control)DTP_EarliestTime).TabIndex = 27;
		((TextBoxBase)DTP_EarliestDate).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DTP_EarliestDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_EarliestDate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_EarliestDate).Location = new Point(172, 93);
		((Control)DTP_EarliestDate).Name = "DTP_EarliestDate";
		((Control)DTP_EarliestDate).Size = new Size(223, 22);
		((Control)DTP_EarliestDate).TabIndex = 26;
		TabPage8.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage8).Controls.Add((Control)(object)UnitFilter_UnitDetected);
		((Control)TabPage8).Controls.Add((Control)(object)AreaEditor_DetectedArea);
		((Control)TabPage8).Controls.Add((Control)(object)CB_MCL);
		((Control)TabPage8).Controls.Add((Control)(object)Label16);
		((Control)TabPage8).Controls.Add((Control)(object)CB_UnitDetected_Sides);
		((Control)TabPage8).Controls.Add((Control)(object)Label15);
		TabPage8.Location = new Point(4, 68);
		((Control)TabPage8).Name = "TabPage8";
		((Control)TabPage8).Padding = new Padding(3);
		((Control)TabPage8).Size = new Size(779, 265);
		TabPage8.TabIndex = 7;
		TabPage8.Text = "Unit is Detected";
		((Control)UnitFilter_UnitDetected).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitDetected.FilterObject = null;
		((Control)UnitFilter_UnitDetected).Location = new Point(7, 9);
		((Control)UnitFilter_UnitDetected).Name = "UnitFilter_UnitDetected";
		((Control)UnitFilter_UnitDetected).Size = new Size(311, 215);
		((Control)UnitFilter_UnitDetected).TabIndex = 13;
		((Control)AreaEditor_DetectedArea).BackColor = Color.FromArgb(60, 63, 65);
		((Control)AreaEditor_DetectedArea).Location = new Point(323, 169);
		((Control)AreaEditor_DetectedArea).Name = "AreaEditor_DetectedArea";
		((Control)AreaEditor_DetectedArea).Size = new Size(351, 125);
		((Control)AreaEditor_DetectedArea).TabIndex = 12;
		AreaEditor_DetectedArea.Title = "Area To Be Inside";
		((ComboBox)CB_MCL).BackColor = Color.Transparent;
		((ComboBox)CB_MCL).DrawMode = (DrawMode)1;
		((ComboBox)CB_MCL).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MCL).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MCL).FormattingEnabled = true;
		((ComboBox)CB_MCL).Items.AddRange(new object[5] { "Unknown", "Known Domain (e.g. ship, aircraft)", "Known Type (e.g. frigate, bomber)", "Known Class (e.g. F-16, Nimitz-class)", "Precise ID (e.g. Air Force One, USS Nimitz)" });
		((Control)CB_MCL).Location = new Point(477, 110);
		((Control)CB_MCL).Name = "CB_MCL";
		((Control)CB_MCL).Size = new Size(197, 21);
		((Control)CB_MCL).TabIndex = 11;
		Label16.AutoSize = true;
		((Control)Label16).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label16).Location = new Point(332, 113);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(153, 13);
		((Control)Label16).TabIndex = 10;
		((Label)Label16).Text = "Minimum classification level:";
		((ComboBox)CB_UnitDetected_Sides).BackColor = Color.Transparent;
		((ComboBox)CB_UnitDetected_Sides).DrawMode = (DrawMode)1;
		((ComboBox)CB_UnitDetected_Sides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_UnitDetected_Sides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_UnitDetected_Sides).FormattingEnabled = true;
		((Control)CB_UnitDetected_Sides).Location = new Point(482, 81);
		((Control)CB_UnitDetected_Sides).Name = "CB_UnitDetected_Sides";
		((Control)CB_UnitDetected_Sides).Size = new Size(192, 21);
		((Control)CB_UnitDetected_Sides).TabIndex = 9;
		Label15.AutoSize = true;
		((Control)Label15).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label15).Location = new Point(350, 86);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(79, 13);
		((Control)Label15).TabIndex = 8;
		((Label)Label15).Text = "Detector Side:";
		TabPage9.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage9).Controls.Add((Control)(object)CB_RegularTimeInterval);
		((Control)TabPage9).Controls.Add((Control)(object)Label17);
		TabPage9.Location = new Point(4, 68);
		((Control)TabPage9).Name = "TabPage9";
		((Control)TabPage9).Padding = new Padding(3);
		((Control)TabPage9).Size = new Size(779, 265);
		TabPage9.TabIndex = 8;
		TabPage9.Text = "Regular Time";
		((ComboBox)CB_RegularTimeInterval).BackColor = Color.Transparent;
		((ComboBox)CB_RegularTimeInterval).DrawMode = (DrawMode)1;
		((ComboBox)CB_RegularTimeInterval).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_RegularTimeInterval).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_RegularTimeInterval).FormattingEnabled = true;
		((ComboBox)CB_RegularTimeInterval).Items.AddRange(new object[13]
		{
			"Every simulation pulse", "One Second", "Five Seconds", "Fifteen Seconds", "Thirty Seconds", "One Minute", "Five Minutes", "Fifteen Minutes", "Thirty Minutes", "One Hour",
			"Six Hours", "Twelve Hours", "Twenty Four Hours"
		});
		((Control)CB_RegularTimeInterval).Location = new Point(227, 98);
		((Control)CB_RegularTimeInterval).Name = "CB_RegularTimeInterval";
		((Control)CB_RegularTimeInterval).Size = new Size(155, 21);
		((Control)CB_RegularTimeInterval).TabIndex = 1;
		Label17.AutoSize = true;
		((Control)Label17).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label17).Location = new Point(115, 101);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(116, 13);
		((Control)Label17).TabIndex = 0;
		((Label)Label17).Text = "Trigger will fire every:";
		TabPage10.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage10).Controls.Add((Control)(object)UnitFilter_BaseStatusCheck);
		((Control)TabPage10).Controls.Add((Control)(object)CB_BaseStatusCheck_Base);
		((Control)TabPage10).Controls.Add((Control)(object)CB_BaseStatusCheck_BaseSide);
		((Control)TabPage10).Controls.Add((Control)(object)BaseStatusCheck_Unit_Label);
		((Control)TabPage10).Controls.Add((Control)(object)BaseStatusCheck_BaseSide);
		((Control)TabPage10).Controls.Add((Control)(object)BaseStatusCheck_Base);
		((Control)TabPage10).Controls.Add((Control)(object)CB_BaseStatusCheck_Condition);
		((Control)TabPage10).Controls.Add((Control)(object)DarkLabel1);
		TabPage10.Location = new Point(4, 68);
		((Control)TabPage10).Name = "TabPage10";
		((Control)TabPage10).Padding = new Padding(3);
		((Control)TabPage10).Size = new Size(779, 265);
		TabPage10.TabIndex = 9;
		TabPage10.Text = "Air/Dock Status Change";
		((Control)UnitFilter_BaseStatusCheck).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_BaseStatusCheck.FilterObject = null;
		((Control)UnitFilter_BaseStatusCheck).Location = new Point(6, 40);
		((Control)UnitFilter_BaseStatusCheck).MinimumSize = new Size(311, 177);
		((Control)UnitFilter_BaseStatusCheck).Name = "UnitFilter_BaseStatusCheck";
		((Control)UnitFilter_BaseStatusCheck).Size = new Size(311, 203);
		((Control)UnitFilter_BaseStatusCheck).TabIndex = 6;
		((ComboBox)CB_BaseStatusCheck_Base).BackColor = Color.Transparent;
		((ComboBox)CB_BaseStatusCheck_Base).DrawMode = (DrawMode)1;
		((ComboBox)CB_BaseStatusCheck_Base).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_BaseStatusCheck_Base).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_BaseStatusCheck_Base).FormattingEnabled = true;
		((Control)CB_BaseStatusCheck_Base).Location = new Point(470, 57);
		((Control)CB_BaseStatusCheck_Base).Name = "CB_BaseStatusCheck_Base";
		((Control)CB_BaseStatusCheck_Base).Size = new Size(245, 21);
		((Control)CB_BaseStatusCheck_Base).TabIndex = 11;
		((ComboBox)CB_BaseStatusCheck_BaseSide).BackColor = Color.Transparent;
		((ComboBox)CB_BaseStatusCheck_BaseSide).DrawMode = (DrawMode)1;
		((ComboBox)CB_BaseStatusCheck_BaseSide).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_BaseStatusCheck_BaseSide).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_BaseStatusCheck_BaseSide).FormattingEnabled = true;
		((Control)CB_BaseStatusCheck_BaseSide).Location = new Point(523, 18);
		((Control)CB_BaseStatusCheck_BaseSide).Name = "CB_BaseStatusCheck_BaseSide";
		((Control)CB_BaseStatusCheck_BaseSide).Size = new Size(192, 21);
		((Control)CB_BaseStatusCheck_BaseSide).TabIndex = 10;
		BaseStatusCheck_Unit_Label.AutoSize = true;
		((Control)BaseStatusCheck_Unit_Label).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BaseStatusCheck_Unit_Label).Location = new Point(80, 18);
		((Control)BaseStatusCheck_Unit_Label).Name = "BaseStatusCheck_Unit_Label";
		((Control)BaseStatusCheck_Unit_Label).Size = new Size(56, 13);
		((Control)BaseStatusCheck_Unit_Label).TabIndex = 3;
		((Label)BaseStatusCheck_Unit_Label).Text = "Unit filter";
		BaseStatusCheck_BaseSide.AutoSize = true;
		((Control)BaseStatusCheck_BaseSide).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BaseStatusCheck_BaseSide).Location = new Point(385, 18);
		((Control)BaseStatusCheck_BaseSide).Name = "BaseStatusCheck_BaseSide";
		((Control)BaseStatusCheck_BaseSide).Size = new Size(117, 13);
		((Control)BaseStatusCheck_BaseSide).TabIndex = 2;
		((Label)BaseStatusCheck_BaseSide).Text = "Side of Base to Check";
		BaseStatusCheck_Base.AutoSize = true;
		((Control)BaseStatusCheck_Base).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BaseStatusCheck_Base).Location = new Point(346, 57);
		((Control)BaseStatusCheck_Base).Name = "BaseStatusCheck_Base";
		((Control)BaseStatusCheck_Base).Size = new Size(97, 13);
		((Control)BaseStatusCheck_Base).TabIndex = 1;
		((Label)BaseStatusCheck_Base).Text = "Base to Check On";
		((ComboBox)CB_BaseStatusCheck_Condition).BackColor = Color.Transparent;
		((ComboBox)CB_BaseStatusCheck_Condition).DrawMode = (DrawMode)1;
		((ComboBox)CB_BaseStatusCheck_Condition).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_BaseStatusCheck_Condition).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_BaseStatusCheck_Condition).FormattingEnabled = true;
		((Control)CB_BaseStatusCheck_Condition).Location = new Point(470, 101);
		((Control)CB_BaseStatusCheck_Condition).Name = "CB_BaseStatusCheck_Condition";
		((Control)CB_BaseStatusCheck_Condition).Size = new Size(245, 21);
		((Control)CB_BaseStatusCheck_Condition).TabIndex = 13;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(346, 101);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(117, 13);
		((Control)DarkLabel1).TabIndex = 12;
		((Label)DarkLabel1).Text = "Target Condition to ..";
		TabPage11.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage11).Controls.Add((Control)(object)UnitEmissions_MCL);
		((Control)TabPage11).Controls.Add((Control)(object)UnitEmissions_MCL_label);
		((Control)TabPage11).Controls.Add((Control)(object)AreaEditor_UnitEmissions);
		((Control)TabPage11).Controls.Add((Control)(object)UnitFilter_UnitEmissions);
		((Control)TabPage11).Controls.Add((Control)(object)UnitEmissions_Side_label);
		((Control)TabPage11).Controls.Add((Control)(object)UnitEmissions_Side);
		TabPage11.Location = new Point(4, 68);
		((Control)TabPage11).Name = "TabPage11";
		((Control)TabPage11).Size = new Size(779, 265);
		TabPage11.TabIndex = 10;
		TabPage11.Text = "Unit Emissions";
		((ComboBox)UnitEmissions_MCL).BackColor = Color.Transparent;
		((ComboBox)UnitEmissions_MCL).DrawMode = (DrawMode)1;
		((ComboBox)UnitEmissions_MCL).DropDownStyle = (ComboBoxStyle)2;
		((Control)UnitEmissions_MCL).Font = new Font("Segoe UI", 7f);
		((ListControl)UnitEmissions_MCL).FormattingEnabled = true;
		((ComboBox)UnitEmissions_MCL).Items.AddRange(new object[5] { "Unknown", "Known Domain (e.g. ship, aircraft)", "Known Type (e.g. frigate, bomber)", "Known Class (e.g. F-16, Nimitz-class)", "Precise ID (e.g. Air Force One, USS Nimitz)" });
		((Control)UnitEmissions_MCL).Location = new Point(482, 88);
		((Control)UnitEmissions_MCL).Name = "UnitEmissions_MCL";
		((Control)UnitEmissions_MCL).Size = new Size(192, 21);
		((Control)UnitEmissions_MCL).TabIndex = 11;
		UnitEmissions_MCL_label.AutoSize = true;
		((Control)UnitEmissions_MCL_label).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UnitEmissions_MCL_label).Location = new Point(332, 91);
		((Control)UnitEmissions_MCL_label).Name = "UnitEmissions_MCL_label";
		((Control)UnitEmissions_MCL_label).Size = new Size(153, 13);
		((Control)UnitEmissions_MCL_label).TabIndex = 10;
		((Label)UnitEmissions_MCL_label).Text = "Minimum classification level:";
		((Control)AreaEditor_UnitEmissions).BackColor = Color.FromArgb(60, 63, 65);
		((Control)AreaEditor_UnitEmissions).Location = new Point(326, 123);
		((Control)AreaEditor_UnitEmissions).Name = "AreaEditor_UnitEmissions";
		((Control)AreaEditor_UnitEmissions).Size = new Size(351, 125);
		((Control)AreaEditor_UnitEmissions).TabIndex = 12;
		AreaEditor_UnitEmissions.Title = "Area To Be Inside";
		((Control)UnitFilter_UnitEmissions).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitEmissions.FilterObject = null;
		((Control)UnitFilter_UnitEmissions).Location = new Point(6, 6);
		((Control)UnitFilter_UnitEmissions).MinimumSize = new Size(311, 177);
		((Control)UnitFilter_UnitEmissions).Name = "UnitFilter_UnitEmissions";
		((Control)UnitFilter_UnitEmissions).Size = new Size(311, 204);
		((Control)UnitFilter_UnitEmissions).TabIndex = 2;
		UnitEmissions_Side_label.AutoSize = true;
		((Control)UnitEmissions_Side_label).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UnitEmissions_Side_label).Location = new Point(349, 63);
		((Control)UnitEmissions_Side_label).Name = "UnitEmissions_Side_label";
		((Control)UnitEmissions_Side_label).Size = new Size(79, 13);
		((Control)UnitEmissions_Side_label).TabIndex = 8;
		((Label)UnitEmissions_Side_label).Text = "Detector Side:";
		((ComboBox)UnitEmissions_Side).BackColor = Color.Transparent;
		((ComboBox)UnitEmissions_Side).DrawMode = (DrawMode)1;
		((ComboBox)UnitEmissions_Side).DropDownStyle = (ComboBoxStyle)2;
		((Control)UnitEmissions_Side).Font = new Font("Segoe UI", 7f);
		((ListControl)UnitEmissions_Side).FormattingEnabled = true;
		((Control)UnitEmissions_Side).Location = new Point(473, 58);
		((Control)UnitEmissions_Side).Name = "UnitEmissions_Side";
		((Control)UnitEmissions_Side).Size = new Size(200, 21);
		((Control)UnitEmissions_Side).TabIndex = 10;
		TabPage12.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage12).Controls.Add((Control)(object)Label_DescCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel11);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel10);
		((Control)TabPage12).Controls.Add((Control)(object)NUM_SendThresholdCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel9);
		((Control)TabPage12).Controls.Add((Control)(object)NUM_RecvThresholdCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel8);
		((Control)TabPage12).Controls.Add((Control)(object)CB_CargoSpecificUnitCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel7);
		((Control)TabPage12).Controls.Add((Control)(object)CB_CargoDBIDCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel5);
		((Control)TabPage12).Controls.Add((Control)(object)CB_CargoTypeCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel6);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel4);
		((Control)TabPage12).Controls.Add((Control)(object)CB_UnitCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel3);
		((Control)TabPage12).Controls.Add((Control)(object)CB_SideCargo);
		((Control)TabPage12).Controls.Add((Control)(object)DarkLabel2);
		TabPage12.Location = new Point(4, 68);
		((Control)TabPage12).Name = "TabPage12";
		((Control)TabPage12).Size = new Size(779, 265);
		TabPage12.TabIndex = 11;
		TabPage12.Text = "Unit Cargo Moved";
		Label_DescCargo.AutoUpdateHeight = true;
		((Control)Label_DescCargo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DescCargo).Location = new Point(315, 18);
		((Control)Label_DescCargo).MaximumSize = new Size(256, 0);
		((Control)Label_DescCargo).Name = "Label_DescCargo";
		((Control)Label_DescCargo).Size = new Size(256, 13);
		((Control)Label_DescCargo).TabIndex = 25;
		((Label)Label_DescCargo).Text = "Triggers When: (NEVER)";
		DarkLabel11.AutoSize = true;
		((Control)DarkLabel11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel11).Location = new Point(373, 141);
		((Control)DarkLabel11).Name = "DarkLabel11";
		((Control)DarkLabel11).Size = new Size(101, 13);
		((Control)DarkLabel11).TabIndex = 24;
		((Label)DarkLabel11).Text = "Trigger Threshold:";
		DarkLabel10.AutoSize = true;
		((Control)DarkLabel10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel10).Location = new Point(80, 125);
		((Control)DarkLabel10).Name = "DarkLabel10";
		((Control)DarkLabel10).Size = new Size(96, 13);
		((Control)DarkLabel10).TabIndex = 23;
		((Label)DarkLabel10).Text = "Cargo Type Filter:";
		((UpDownBase)NUM_SendThresholdCargo).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUM_SendThresholdCargo).BorderStyle = (BorderStyle)1;
		((Control)NUM_SendThresholdCargo).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUM_SendThresholdCargo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUM_SendThresholdCargo).Location = new Point(451, 211);
		((Control)NUM_SendThresholdCargo).Name = "NUM_SendThresholdCargo";
		((Control)NUM_SendThresholdCargo).Size = new Size(74, 25);
		((Control)NUM_SendThresholdCargo).TabIndex = 22;
		DarkLabel9.AutoSize = true;
		((Control)DarkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel9).Location = new Point(351, 216);
		((Control)DarkLabel9).Name = "DarkLabel9";
		((Control)DarkLabel9).Size = new Size(83, 13);
		((Control)DarkLabel9).TabIndex = 21;
		((Label)DarkLabel9).Text = "Send Quantity:";
		((UpDownBase)NUM_RecvThresholdCargo).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUM_RecvThresholdCargo).BorderStyle = (BorderStyle)1;
		((Control)NUM_RecvThresholdCargo).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUM_RecvThresholdCargo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUM_RecvThresholdCargo).Location = new Point(451, 167);
		((Control)NUM_RecvThresholdCargo).Name = "NUM_RecvThresholdCargo";
		((Control)NUM_RecvThresholdCargo).Size = new Size(74, 25);
		((Control)NUM_RecvThresholdCargo).TabIndex = 20;
		DarkLabel8.AutoSize = true;
		((Control)DarkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel8).Location = new Point(339, 172);
		((Control)DarkLabel8).Name = "DarkLabel8";
		((Control)DarkLabel8).Size = new Size(95, 13);
		((Control)DarkLabel8).TabIndex = 19;
		((Label)DarkLabel8).Text = "Receive Quantity:";
		((ComboBox)CB_CargoSpecificUnitCargo).BackColor = Color.Transparent;
		((ComboBox)CB_CargoSpecificUnitCargo).DrawMode = (DrawMode)1;
		((ComboBox)CB_CargoSpecificUnitCargo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CargoSpecificUnitCargo).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CargoSpecificUnitCargo).FormattingEnabled = true;
		((Control)CB_CargoSpecificUnitCargo).Location = new Point(108, 220);
		((Control)CB_CargoSpecificUnitCargo).Name = "CB_CargoSpecificUnitCargo";
		((Control)CB_CargoSpecificUnitCargo).Size = new Size(196, 21);
		((Control)CB_CargoSpecificUnitCargo).TabIndex = 18;
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(10, 223);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(66, 13);
		((Control)DarkLabel7).TabIndex = 17;
		((Label)DarkLabel7).Text = "Cargo Unit:";
		((ComboBox)CB_CargoDBIDCargo).BackColor = Color.Transparent;
		((ComboBox)CB_CargoDBIDCargo).DrawMode = (DrawMode)1;
		((ComboBox)CB_CargoDBIDCargo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CargoDBIDCargo).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CargoDBIDCargo).FormattingEnabled = true;
		((Control)CB_CargoDBIDCargo).Location = new Point(108, 187);
		((Control)CB_CargoDBIDCargo).Name = "CB_CargoDBIDCargo";
		((Control)CB_CargoDBIDCargo).Size = new Size(196, 21);
		((Control)CB_CargoDBIDCargo).TabIndex = 16;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(6, 190);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(70, 13);
		((Control)DarkLabel5).TabIndex = 15;
		((Label)DarkLabel5).Text = "Cargo Class:";
		((ComboBox)CB_CargoTypeCargo).BackColor = Color.Transparent;
		((ComboBox)CB_CargoTypeCargo).DrawMode = (DrawMode)1;
		((ComboBox)CB_CargoTypeCargo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_CargoTypeCargo).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_CargoTypeCargo).FormattingEnabled = true;
		((Control)CB_CargoTypeCargo).Location = new Point(108, 154);
		((Control)CB_CargoTypeCargo).Name = "CB_CargoTypeCargo";
		((Control)CB_CargoTypeCargo).Size = new Size(196, 21);
		((Control)CB_CargoTypeCargo).TabIndex = 14;
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(9, 157);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(67, 13);
		((Control)DarkLabel6).TabIndex = 13;
		((Label)DarkLabel6).Text = "Cargo Type:";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(80, 18);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(71, 13);
		((Control)DarkLabel4).TabIndex = 12;
		((Label)DarkLabel4).Text = "Trigger Unit:";
		((ComboBox)CB_UnitCargo).BackColor = Color.Transparent;
		((ComboBox)CB_UnitCargo).DrawMode = (DrawMode)1;
		((ComboBox)CB_UnitCargo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_UnitCargo).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_UnitCargo).FormattingEnabled = true;
		((Control)CB_UnitCargo).Location = new Point(108, 83);
		((Control)CB_UnitCargo).Name = "CB_UnitCargo";
		((Control)CB_UnitCargo).Size = new Size(196, 21);
		((Control)CB_UnitCargo).TabIndex = 11;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(2, 86);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(74, 13);
		((Control)DarkLabel3).TabIndex = 10;
		((Label)DarkLabel3).Text = "Specific Unit:";
		((ComboBox)CB_SideCargo).BackColor = Color.Transparent;
		((ComboBox)CB_SideCargo).DrawMode = (DrawMode)1;
		((ComboBox)CB_SideCargo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SideCargo).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SideCargo).FormattingEnabled = true;
		((Control)CB_SideCargo).Location = new Point(108, 50);
		((Control)CB_SideCargo).Name = "CB_SideCargo";
		((Control)CB_SideCargo).Size = new Size(196, 21);
		((Control)CB_SideCargo).TabIndex = 9;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(19, 53);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(57, 13);
		((Control)DarkLabel2).TabIndex = 8;
		((Label)DarkLabel2).Text = "Unit Side:";
		TabPage99.Location = new Point(4, 68);
		((Control)TabPage99).Name = "TabPage99";
		((Control)TabPage99).Padding = new Padding(3);
		((Control)TabPage99).Size = new Size(779, 265);
		TabPage99.TabIndex = 99;
		TabPage99.UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(782, 428);
		((Control)this).Controls.Add((Control)(object)TC_TriggerOptions);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Button_OK);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditTrigger";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit event trigger";
		((Control)TabPage1).ResumeLayout(false);
		((Control)TC_TriggerOptions).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
		((ISupportInitialize)NUD_DamagePercent).EndInit();
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage3).PerformLayout();
		((ISupportInitialize)NUD_Points).EndInit();
		((Control)TabPage4).ResumeLayout(false);
		((Control)TabPage4).PerformLayout();
		((Control)TabPage5).ResumeLayout(false);
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)TabPage6).ResumeLayout(false);
		((Control)TabPage6).PerformLayout();
		((Control)GroupBox2).ResumeLayout(false);
		((Control)GroupBox2).PerformLayout();
		((Control)TabPage7).ResumeLayout(false);
		((Control)TabPage7).PerformLayout();
		((Control)TabPage8).ResumeLayout(false);
		((Control)TabPage8).PerformLayout();
		((Control)TabPage9).ResumeLayout(false);
		((Control)TabPage9).PerformLayout();
		((Control)TabPage10).ResumeLayout(false);
		((Control)TabPage10).PerformLayout();
		((Control)TabPage11).ResumeLayout(false);
		((Control)TabPage11).PerformLayout();
		((Control)TabPage12).ResumeLayout(false);
		((Control)TabPage12).PerformLayout();
		((ISupportInitialize)NUM_SendThresholdCargo).EndInit();
		((ISupportInitialize)NUM_RecvThresholdCargo).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EditTrigger_FormClosing(object sender, FormClosingEventArgs e)
	{
		eventTriggersChangedEventHandler_0?.Invoke(Client.CurrentScenario);
		MyProject.Forms.ListTriggers.RefreshGrid();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			theTrigger = null;
			AreaEditor_UnitInArea.ReleaseReferences();
			AreaEditor_UnitEntersArea.ReleaseReferences();
			AreaEditor_DetectedArea.ReleaseReferences();
			AreaEditor_UnitEmissions.ReleaseReferences();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void EditTrigger_Load(object sender, EventArgs e)
	{
		//IL_1387: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_124b: Expected O, but got Unknown
		//IL_0d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d67: Expected O, but got Unknown
		//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb5: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Expected O, but got Unknown
		//IL_0dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc5: Expected O, but got Unknown
		//IL_0efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f01: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Expected O, but got Unknown
		//IL_12a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ab: Expected O, but got Unknown
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1436: Expected O, but got Unknown
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1120: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Expected O, but got Unknown
		//IL_14da: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e1: Expected O, but got Unknown
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b4: Expected O, but got Unknown
		//IL_1002: Unknown result type (might be due to invalid IL or missing references)
		//IL_1009: Expected O, but got Unknown
		if (Information.IsNothing((object)theTrigger))
		{
			((Form)this).Close();
		}
		TextBox1.Text = theTrigger.Description;
		((Control)Button_OK).Visible = Action == _FormAction.AddNew;
		((Control)Button_Cancel).Visible = ((Control)Button_OK).Visible;
		switch (theTrigger.Type)
		{
		case EventTrigger.EventTriggerType.UnitDestroyed:
			((TabControl)TC_TriggerOptions).SelectedIndex = 0;
			((TabControl)TC_TriggerOptions).TabPages[0].Enabled = true;
			UnitFilter_UnitDestroyed.FilterObject = ((EventTrigger_UnitDestroyed)theTrigger).TargetFilter;
			break;
		case EventTrigger.EventTriggerType.Points:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 2;
			((TabControl)TC_TriggerOptions).TabPages[2].Enabled = true;
			((ComboBox)CB_Points_Sides).Items.Clear();
			((ListControl)CB_Points_Sides).DisplayMember = "Content";
			Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side3 in sides_ReadOnly2)
			{
				ComboBoxItem val5 = new ComboBoxItem();
				((ContentControl)val5).Content = side3.Name;
				((FrameworkElement)val5).Tag = side3.ObjectID;
				((ComboBox)CB_Points_Sides).Items.Add((object)val5);
			}
			foreach (ComboBoxItem item in ((ComboBox)CB_Points_Sides).Items)
			{
				ComboBoxItem val6 = item;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val6).Tag), ((EventTrigger_Points)theTrigger).SideID, true) == 0)
				{
					((ComboBox)CB_Points_Sides).SelectedItem = val6;
					break;
				}
			}
			((ComboBox)CB_Points_ReachDirection).SelectedIndex = (int)((EventTrigger_Points)theTrigger).ReachDirection;
			((NumericUpDown)NUD_Points).Value = new decimal(((EventTrigger_Points)theTrigger).PointValue);
			break;
		}
		case EventTrigger.EventTriggerType.Time:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 3;
			((TabControl)TC_TriggerOptions).TabPages[3].Enabled = true;
			DateTime theDate5 = ((EventTrigger_Time)theTrigger).Time;
			((Label)Label6).Text = "Currently set: " + theDate5.ToShortDateString() + " - " + theDate5.ToShortTimeString();
			string theTimeString5 = "";
			string theDateString5 = "";
			GameGeneral.PaddedTimeString(ref theDate5, ref theTimeString5);
			GameGeneral.PaddedDateString(ref theDate5, ref theDateString5, AddComma: false);
			((MaskedTextBox)DTP_StartDate).Text = theDateString5;
			((MaskedTextBox)DTP_StartTime).Text = theTimeString5;
			break;
		}
		case EventTrigger.EventTriggerType.UnitDamaged:
			((TabControl)TC_TriggerOptions).SelectedIndex = 1;
			((TabControl)TC_TriggerOptions).TabPages[1].Enabled = true;
			UnitFilter_UnitDamaged.FilterObject = ((EventTrigger_UnitDamaged)theTrigger).TargetFilter;
			((NumericUpDown)NUD_DamagePercent).Value = new decimal(((EventTrigger_UnitDamaged)theTrigger).DamagePercent);
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 4;
			((TabControl)TC_TriggerOptions).TabPages[4].Enabled = true;
			UnitFilter_UnitInArea.FilterObject = ((EventTrigger_UnitRemainsInArea)theTrigger).TargetFilter;
			AreaEditor_UnitInArea.AreaPoints = ((EventTrigger_UnitRemainsInArea)theTrigger).Area;
			AreaEditor_UnitInArea.RefreshForm();
			TimeSpan timeSpan = TimeSpan.FromSeconds((double)((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration);
			TB_Days.Text = Conversions.ToString(timeSpan.Days);
			TB_Hours.Text = Conversions.ToString(timeSpan.Hours);
			TB_Mins.Text = Conversions.ToString(timeSpan.Minutes);
			TB_Secs.Text = Conversions.ToString(timeSpan.Seconds);
			TB_Days.TextChanged += method_10;
			TB_Hours.TextChanged += method_11;
			TB_Mins.TextChanged += method_12;
			TB_Secs.TextChanged += method_13;
			break;
		}
		case EventTrigger.EventTriggerType.UnitEntersArea:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 5;
			((TabControl)TC_TriggerOptions).TabPages[5].Enabled = true;
			UnitFilter_UnitEntersArea.FilterObject = ((EventTrigger_UnitEntersArea)theTrigger).TargetFilter;
			AreaEditor_UnitEntersArea.AreaPoints = ((EventTrigger_UnitEntersArea)theTrigger).Area;
			AreaEditor_UnitEntersArea.RefreshForm();
			DateTime theDate = ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0;
			DateTime theDate2 = ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1;
			string theTimeString = default(string);
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			string theDateString = default(string);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: true);
			((MaskedTextBox)DTP_EnterArea_ETOA_Date).Text = theDateString;
			((MaskedTextBox)DTP_EnterArea_ETOA_Time).Text = theTimeString;
			string theTimeString2 = default(string);
			GameGeneral.PaddedTimeString(ref theDate2, ref theTimeString2);
			string theDateString2 = default(string);
			GameGeneral.PaddedDateString(ref theDate2, ref theDateString2, AddComma: true);
			((MaskedTextBox)DTP_EnterArea_LTOA_Date).Text = theDateString2;
			((MaskedTextBox)DTP_EnterArea_LTOA_Time).Text = theTimeString2;
			((Label)Label_UnitEntersArea_Earliest).Text = "Earliest: " + theDate.ToShortDateString() + " - " + theDate.ToShortTimeString();
			((Label)Label_UnitEntersArea_Latest).Text = "Latest: " + theDate2.ToShortDateString() + " - " + theDate2.ToShortTimeString();
			((CheckBox)CB_UnitEntersArea_ModifierNOT).Checked = ((EventTrigger_UnitEntersArea)theTrigger).Modifier_NOT;
			((CheckBox)CB_UnitEntersArea_ModifierNOT).CheckedChanged += method_14;
			((CheckBox)CB_UnitEntersArea_ModifierEXIT).Checked = ((EventTrigger_UnitEntersArea)theTrigger).Modifier_EXIT;
			((CheckBox)CB_UnitEntersArea_ModifierEXIT).CheckedChanged += method_15;
			break;
		}
		case EventTrigger.EventTriggerType.RandomTime:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 6;
			((TabControl)TC_TriggerOptions).TabPages[6].Enabled = true;
			DateTime theDate3 = ((EventTrigger_RandomTime)theTrigger).EarliestTime;
			DateTime theDate4 = ((EventTrigger_RandomTime)theTrigger).LatestTime;
			((Label)Label8).Text = "Currently set: \r\nEarliest: " + theDate3.ToShortDateString() + " - " + theDate3.ToShortTimeString() + "\r\nLatest: " + theDate4.ToShortDateString() + " - " + theDate4.ToShortTimeString();
			string theTimeString3 = default(string);
			GameGeneral.PaddedTimeString(ref theDate3, ref theTimeString3);
			string theDateString3 = default(string);
			GameGeneral.PaddedDateString(ref theDate3, ref theDateString3, AddComma: true);
			((MaskedTextBox)DTP_EarliestDate).Text = theDateString3;
			((MaskedTextBox)DTP_EarliestTime).Text = theTimeString3;
			string theTimeString4 = default(string);
			GameGeneral.PaddedTimeString(ref theDate4, ref theTimeString4);
			string theDateString4 = default(string);
			GameGeneral.PaddedDateString(ref theDate4, ref theDateString4, AddComma: true);
			((MaskedTextBox)DTP_LatestDate).Text = theDateString4;
			((MaskedTextBox)DTP_LatestTime).Text = theTimeString4;
			if (!((EventTrigger_RandomTime)theTrigger).isActualTimeSet)
			{
				((Control)RandomTimeValue).Visible = false;
				((Label)RandomTimeValue).Text = "";
			}
			else
			{
				((Control)RandomTimeValue).Visible = true;
				((Label)RandomTimeValue).Text = "Trigger will fire on " + Conversions.ToString(((EventTrigger_RandomTime)theTrigger).ActualTime);
			}
			break;
		}
		case EventTrigger.EventTriggerType.UnitDetected:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 7;
			((TabControl)TC_TriggerOptions).TabPages[7].Enabled = true;
			((ComboBox)CB_UnitDetected_Sides).BeginUpdate();
			((ComboBox)CB_UnitDetected_Sides).Items.Clear();
			((ListControl)CB_UnitDetected_Sides).DisplayMember = "Content";
			Side[] sides_ReadOnly4 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side5 in sides_ReadOnly4)
			{
				ComboBoxItem val9 = new ComboBoxItem();
				((ContentControl)val9).Content = side5.Name;
				((FrameworkElement)val9).Tag = side5.ObjectID;
				((ComboBox)CB_UnitDetected_Sides).Items.Add((object)val9);
			}
			foreach (ComboBoxItem item2 in ((ComboBox)CB_UnitDetected_Sides).Items)
			{
				ComboBoxItem val10 = item2;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val10).Tag), ((EventTrigger_UnitDetected)theTrigger).DetectorSideID, true) == 0)
				{
					((ComboBox)CB_UnitDetected_Sides).SelectedItem = val10;
					break;
				}
			}
			((ComboBox)CB_UnitDetected_Sides).EndUpdate();
			UnitFilter_UnitDetected.FilterObject = ((EventTrigger_UnitDetected)theTrigger).TargetFilter;
			AreaEditor_DetectedArea.AreaPoints = ((EventTrigger_UnitDetected)theTrigger).Area;
			AreaEditor_DetectedArea.RefreshForm();
			((ComboBox)CB_MCL).SelectedIndex = (int)((EventTrigger_UnitDetected)theTrigger).MinimumClassificationLevel;
			break;
		}
		case EventTrigger.EventTriggerType.RegularTime:
			((TabControl)TC_TriggerOptions).SelectedIndex = 8;
			((TabControl)TC_TriggerOptions).TabPages[8].Enabled = true;
			switch (((EventTrigger_RegularTime)theTrigger).Interval)
			{
			case EventTrigger_RegularTime.RegularTimeInterval.OneSecond:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 1;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 2;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 3;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 4;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.OneMinute:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 5;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 6;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 7;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 8;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.OneHour:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 9;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.SixHours:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 10;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.TwelveHours:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 11;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 12;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.EveryPulse:
				((ComboBox)CB_RegularTimeInterval).SelectedIndex = 0;
				break;
			}
			break;
		default:
			((TabControl)TC_TriggerOptions).SelectedIndex = 11;
			((TabControl)TC_TriggerOptions).TabPages[11].Enabled = false;
			((Label)Label3).Text = theTrigger.Type.ToString();
			break;
		case EventTrigger.EventTriggerType.UnitBaseStatus:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 9;
			((TabControl)TC_TriggerOptions).TabPages[9].Enabled = true;
			UnitFilter_BaseStatusCheck.FilterObject = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter;
			((ComboBox)CB_BaseStatusCheck_Condition).BeginUpdate();
			((ComboBox)CB_BaseStatusCheck_Condition).Items.Clear();
			((ListControl)CB_BaseStatusCheck_Condition).DisplayMember = "Content";
			switch (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType)
			{
			default:
			{
				ComboBoxItem val12 = new ComboBoxItem();
				if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0)
				{
					((ContentControl)val12).Content = "Not valid for condition check";
					((FrameworkElement)val12).Tag = null;
					((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val12);
					((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				byte[] array2 = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
				foreach (byte b2 in array2)
				{
					ComboBoxItem val13 = new ComboBoxItem();
					if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
					{
						((ContentControl)val13).Content = "No conditon set";
						((FrameworkElement)val13).Tag = null;
						((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val13);
						((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
					}
					val13 = new ComboBoxItem();
					ComboBoxItem obj2 = val13;
					ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b2;
					((ContentControl)obj2).Content = dockingOpsCondition.ToString();
					((FrameworkElement)val13).Tag = b2;
					((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val13);
					if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b2 >= 0 && Operators.ConditionalCompareObjectEqual((object)b2, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, true))
					{
						((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Condition).Items.Count - 1;
					}
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				byte[] array = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
				foreach (byte b in array)
				{
					switch (b)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 12:
					case 17:
					case 18:
					case 22:
					{
						ComboBoxItem val11 = new ComboBoxItem();
						if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
						{
							((ContentControl)val11).Content = "No conditon set";
							((FrameworkElement)val11).Tag = null;
							((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val11);
							((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
						}
						val11 = new ComboBoxItem();
						ComboBoxItem obj = val11;
						Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
						((ContentControl)obj).Content = airOpsCondition.ToString();
						((FrameworkElement)val11).Tag = b;
						((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val11);
						if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b >= 0 && Operators.ConditionalCompareObjectEqual((object)b, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, true))
						{
							((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Condition).Items.Count - 1;
						}
						break;
					}
					}
				}
				break;
			}
			}
			((ComboBox)CB_BaseStatusCheck_Condition).EndUpdate();
			string text2 = null;
			if (!string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetBaseSide))
			{
				text2 = ((EventTrigger_UnitBaseStatus)theTrigger).TargetBaseSide;
			}
			((ComboBox)CB_BaseStatusCheck_Base).BeginUpdate();
			((ComboBox)CB_BaseStatusCheck_Base).Items.Clear();
			((ListControl)CB_BaseStatusCheck_Base).DisplayMember = "Content";
			if (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType != GlobalVariables.ActiveUnitType.None)
			{
				ComboBoxItem val14 = new ComboBoxItem();
				((ContentControl)val14).Content = "No unit/base limit";
				((FrameworkElement)val14).Tag = "";
				((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val14);
				((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = 0;
				foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
				{
					if (activeUnits_ == null || !activeUnits_.IsActiveUnit || (!activeUnits_.HasAirFacilities && !activeUnits_.HasDockFacilities))
					{
						continue;
					}
					if (activeUnits_.IsGroupMember())
					{
						if (activeUnits_.IsFacility)
						{
							Group obj3 = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
							if (obj3 != null && obj3.HasAirFacilities)
							{
								continue;
							}
						}
						Group obj4 = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
						if (obj4 != null && obj4.HasDockFacilities)
						{
							continue;
						}
					}
					GlobalVariables.ActiveUnitType targetType = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType;
					if (targetType != GlobalVariables.ActiveUnitType.Aircraft)
					{
						if (targetType - 2 > GlobalVariables.ActiveUnitType.Aircraft || !activeUnits_.HasDockFacilities)
						{
							continue;
						}
					}
					else if (!activeUnits_.HasAirFacilities)
					{
						continue;
					}
					val14 = new ComboBoxItem();
					((ContentControl)val14).Content = activeUnits_.Name;
					((FrameworkElement)val14).Tag = activeUnits_.ObjectID;
					((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val14);
					string targetBase = ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase;
					if (targetBase != null && targetBase.Length > 0 && (string.Equals(activeUnits_.Name, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase)))
					{
						((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Base).Items.Count - 1;
					}
				}
				((ComboBox)CB_BaseStatusCheck_Base).EndUpdate();
			}
			((ComboBox)CB_BaseStatusCheck_BaseSide).BeginUpdate();
			((ComboBox)CB_BaseStatusCheck_BaseSide).Items.Clear();
			((ListControl)CB_BaseStatusCheck_BaseSide).DisplayMember = "Content";
			Side[] sides_ReadOnly5 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side6 in sides_ReadOnly5)
			{
				object obj5 = (object)new ComboBoxItem();
				NewLateBinding.LateSet(obj5, (Type)null, "Content", new object[1] { side6.Name }, (string[])null, (Type[])null);
				NewLateBinding.LateSet(obj5, (Type)null, "Tag", new object[1] { side6.ObjectID }, (string[])null, (Type[])null);
				((ComboBox)CB_BaseStatusCheck_BaseSide).Items.Add(RuntimeHelpers.GetObjectValue(obj5));
				if (text2 != null && text2.Length > 0 && string.Equals(side6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
				{
					((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_BaseSide).Items.Count - 1;
				}
			}
			((ComboBox)CB_BaseStatusCheck_BaseSide).EndUpdate();
			break;
		}
		case EventTrigger.EventTriggerType.UnitEmissions:
		{
			((TabControl)TC_TriggerOptions).SelectedIndex = 10;
			((TabControl)TC_TriggerOptions).TabPages[10].Enabled = true;
			((ComboBox)UnitEmissions_Side).BeginUpdate();
			((ComboBox)UnitEmissions_Side).Items.Clear();
			((ListControl)UnitEmissions_Side).DisplayMember = "Content";
			Side[] sides_ReadOnly3 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side4 in sides_ReadOnly3)
			{
				ComboBoxItem val7 = new ComboBoxItem();
				((ContentControl)val7).Content = side4.Name;
				((FrameworkElement)val7).Tag = side4.ObjectID;
				((ComboBox)UnitEmissions_Side).Items.Add((object)val7);
			}
			foreach (ComboBoxItem item3 in ((ComboBox)UnitEmissions_Side).Items)
			{
				ComboBoxItem val8 = item3;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val8).Tag), ((EventTrigger_UnitEmissions)theTrigger).DetectorSideID, true) == 0)
				{
					((ComboBox)UnitEmissions_Side).SelectedItem = val8;
					break;
				}
			}
			((ComboBox)UnitEmissions_Side).EndUpdate();
			UnitFilter_UnitEmissions.FilterObject = ((EventTrigger_UnitEmissions)theTrigger).TargetFilter;
			AreaEditor_UnitEmissions.AreaPoints = ((EventTrigger_UnitEmissions)theTrigger).Area;
			AreaEditor_UnitEmissions.RefreshForm();
			((ComboBox)UnitEmissions_MCL).SelectedIndex = (int)((EventTrigger_UnitEmissions)theTrigger).MinimumClassificationLevel;
			break;
		}
		case EventTrigger.EventTriggerType.UnitCargoMoved:
		{
			if (Client.CurrentScenario.Sides_ReadOnly.Count() == 0)
			{
				DarkMessageBox.ShowError("The scenario must contain at least one side before you can create a unit cargo moved trigger.", "Error");
				((Form)this).Close();
			}
			((TabControl)TC_TriggerOptions).SelectedIndex = 11;
			((TabControl)TC_TriggerOptions).TabPages[11].Enabled = true;
			EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = (EventTrigger_UnitCargoMoved)theTrigger;
			CargoFilter = eventTrigger_UnitCargoMoved.TargetFilter;
			((ComboBox)CB_SideCargo).BeginUpdate();
			((ComboBox)CB_SideCargo).Items.Clear();
			((ListControl)CB_SideCargo).DisplayMember = "Content";
			Side side = null;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (side2.GetAllCargoCapableUnits().Count > 0)
				{
					if (side == null)
					{
						side = side2;
					}
					ComboBoxItem val = new ComboBoxItem();
					((ContentControl)val).Content = side2.Name;
					((FrameworkElement)val).Tag = side2.ObjectID;
					((ComboBox)CB_SideCargo).Items.Add((object)val);
				}
			}
			string text = "";
			if (eventTrigger_UnitCargoMoved.BaseUnit == null)
			{
				if (side != null)
				{
					text = side.ObjectID;
				}
				else
				{
					DarkMessageBox.ShowError("The scenario must contain at least one cargo capable unit before you can create a unit cargo moved trigger.", "Error");
					((Form)this).Close();
				}
			}
			else
			{
				text = eventTrigger_UnitCargoMoved.BaseUnit.get_UnitSide(SetSideOnly: false).ObjectID;
			}
			foreach (ComboBoxItem item4 in ((ComboBox)CB_SideCargo).Items)
			{
				ComboBoxItem val2 = item4;
				if (eventTrigger_UnitCargoMoved.BaseUnit == null)
				{
					((ComboBox)CB_SideCargo).SelectedIndex = 0;
				}
				else if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val2).Tag), text, true) == 0)
				{
					((ComboBox)CB_SideCargo).SelectedItem = val2;
					break;
				}
			}
			((ComboBox)CB_SideCargo).EndUpdate();
			((ComboBox)CB_CargoTypeCargo).BeginUpdate();
			((ComboBox)CB_CargoTypeCargo).Items.Clear();
			((ListControl)CB_CargoTypeCargo).DisplayMember = "Content";
			ComboBoxItem val3 = null;
			foreach (object value in Enum.GetValues(typeof(Cargo.CargoObjectType)))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				if (!Operators.ConditionalCompareObjectEqual(objectValue, (object)Cargo.CargoObjectType.CargoContainerContent, true))
				{
					ComboBoxItem val4 = new ComboBoxItem();
					((ContentControl)val4).Content = CargoUICommon.CargoTypeAsStringForEvent[Conversions.ToInteger(objectValue)];
					((FrameworkElement)val4).Tag = RuntimeHelpers.GetObjectValue(objectValue);
					((ComboBox)CB_CargoTypeCargo).Items.Add((object)val4);
					if (Operators.ConditionalCompareObjectEqual(objectValue, (object)CargoFilter.SpecificObjectType, true))
					{
						val3 = val4;
					}
				}
			}
			if (val3 == null)
			{
				((ComboBox)CB_CargoTypeCargo).SelectedIndex = 0;
			}
			else
			{
				((ComboBox)CB_CargoTypeCargo).SelectedItem = val3;
			}
			((ComboBox)CB_CargoTypeCargo).EndUpdate();
			((NumericUpDown)NUM_SendThresholdCargo).Value = new decimal(CargoFilter.ThresholdSent);
			((NumericUpDown)NUM_RecvThresholdCargo).Value = new decimal(CargoFilter.ThresholdReceived);
			break;
		}
		}
		TC_TriggerOptions.HideNonSelectedTabs();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		switch (theTrigger.Type)
		{
		}
		switch (Action)
		{
		case _FormAction.AddNew:
			Client.CurrentScenario.EventTriggers.TryAdd(theTrigger.ObjectID, theTrigger);
			break;
		}
		((Form)this).Close();
	}

	private void method_4(object object_0)
	{
		theTrigger.Description = TextBox1.Text;
	}

	private void method_5(object sender, EventArgs e)
	{
		((EventTrigger_Points)theTrigger).SideID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_Points_Sides).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
	}

	private void method_6(object sender, EventArgs e)
	{
		((EventTrigger_Points)theTrigger).ReachDirection = (EventTrigger_Points.PointReachDirection)((ComboBox)CB_Points_ReachDirection).SelectedIndex;
	}

	private void method_7(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_Points).Value))
		{
			((EventTrigger_Points)theTrigger).PointValue = Convert.ToInt32(((NumericUpDown)NUD_Points).Value);
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<string> list = ((MaskedTextBox)DTP_StartTime).Text.Split(new char[1] { ':' }).ToList();
			if (Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2]))
			{
				List<string> list2 = ((MaskedTextBox)DTP_StartDate).Text.Split(new char[1] { '-' }).ToList();
				if (Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2]))
				{
					((EventTrigger_Time)theTrigger).Time = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
					((Label)Label6).Text = "Currently set: " + ((EventTrigger_Time)theTrigger).Time.ToShortDateString() + " - " + ((EventTrigger_Time)theTrigger).Time.ToShortTimeString();
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Unable to parse the date and/or time values you entered. Expected format is YYYY-MM-DD and HH:MM:SS.", "Error");
			DateTime theDate = ((EventTrigger_Time)theTrigger).Time;
			string theTimeString = "";
			string theDateString = "";
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DTP_StartDate).Text = theDateString;
			((MaskedTextBox)DTP_StartTime).Text = theTimeString;
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_DamagePercent).Value) && !Information.IsNothing((object)theTrigger))
		{
			((EventTrigger_UnitDamaged)theTrigger).DamagePercent = Convert.ToByte(((NumericUpDown)NUD_DamagePercent).Value);
		}
	}

	private void method_10(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Days.Text))
		{
			TB_Days.Text = "0";
		}
		if (Versioned.IsNumeric((object)TB_Days.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing((object)theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void method_11(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Hours.Text))
		{
			TB_Hours.Text = "0";
		}
		if (Versioned.IsNumeric((object)TB_Hours.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing((object)theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void method_12(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Mins.Text))
		{
			TB_Mins.Text = "0";
		}
		if (Versioned.IsNumeric((object)TB_Mins.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing((object)theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void method_13(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Secs.Text))
		{
			TB_Secs.Text = "0";
		}
		if (Versioned.IsNumeric((object)TB_Secs.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing((object)theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theTrigger))
		{
			((EventTrigger_UnitEntersArea)theTrigger).Modifier_NOT = ((CheckBox)CB_UnitEntersArea_ModifierNOT).Checked;
			if (((CheckBox)CB_UnitEntersArea_ModifierNOT).Checked)
			{
				((CheckBox)CB_UnitEntersArea_ModifierEXIT).Checked = false;
				((Control)this).Refresh();
			}
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theTrigger))
		{
			((EventTrigger_UnitEntersArea)theTrigger).Modifier_EXIT = ((CheckBox)CB_UnitEntersArea_ModifierEXIT).Checked;
			if (((CheckBox)CB_UnitEntersArea_ModifierEXIT).Checked)
			{
				((CheckBox)CB_UnitEntersArea_ModifierNOT).Checked = false;
				((Control)this).Refresh();
			}
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)theTrigger))
		{
			return;
		}
		List<string> list = ((MaskedTextBox)DTP_EnterArea_ETOA_Time).Text.Split(new char[1] { ':' }).ToList();
		if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
		{
			return;
		}
		List<string> list2 = ((MaskedTextBox)DTP_EnterArea_ETOA_Date).Text.Split(new char[1] { '-' }).ToList();
		if (!(Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2])))
		{
			return;
		}
		((EventTrigger_UnitEntersArea)theTrigger).dateTime_0 = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		((Label)Label_UnitEntersArea_Earliest).Text = "Earliest: " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0.ToShortDateString() + " - " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0.ToShortTimeString();
		List<string> list3 = ((MaskedTextBox)DTP_EnterArea_LTOA_Time).Text.Split(new char[1] { ':' }).ToList();
		if (Versioned.IsNumeric((object)list3[0]) & Versioned.IsNumeric((object)list3[1]) & Versioned.IsNumeric((object)list3[2]))
		{
			List<string> list4 = ((MaskedTextBox)DTP_EnterArea_LTOA_Date).Text.Split(new char[1] { '-' }).ToList();
			if (Versioned.IsNumeric((object)list4[0]) & Versioned.IsNumeric((object)list4[1]) & Versioned.IsNumeric((object)list4[2]))
			{
				((EventTrigger_UnitEntersArea)theTrigger).dateTime_1 = new DateTime(Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2]), Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2]));
				((Label)Label_UnitEntersArea_Latest).Text = "Latest: " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1.ToShortDateString() + " - " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1.ToShortTimeString();
			}
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = ((MaskedTextBox)DTP_EarliestTime).Text.Split(new char[1] { ':' }).ToList();
		if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
		{
			return;
		}
		List<string> list2 = ((MaskedTextBox)DTP_EarliestDate).Text.Split(new char[1] { '-' }).ToList();
		if (!(Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2])))
		{
			return;
		}
		((EventTrigger_RandomTime)theTrigger).EarliestTime = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		List<string> list3 = ((MaskedTextBox)DTP_LatestTime).Text.Split(new char[1] { ':' }).ToList();
		if (!(Versioned.IsNumeric((object)list3[0]) & Versioned.IsNumeric((object)list3[1]) & Versioned.IsNumeric((object)list3[2])))
		{
			return;
		}
		List<string> list4 = ((MaskedTextBox)DTP_LatestDate).Text.Split(new char[1] { '-' }).ToList();
		if (Versioned.IsNumeric((object)list4[0]) & Versioned.IsNumeric((object)list4[1]) & Versioned.IsNumeric((object)list4[2]))
		{
			((EventTrigger_RandomTime)theTrigger).LatestTime = new DateTime(Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2]), Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2]));
			if (DateTime.Compare(((EventTrigger_RandomTime)theTrigger).EarliestTime, ((EventTrigger_RandomTime)theTrigger).LatestTime) > 0)
			{
				DarkMessageBox.ShowError("Error! Earliest Time cannot be greater than Latest Time!", "");
				((Label)Label8).Text = "Error! Earliest Time cannot be greater than Latest Time";
				return;
			}
			((Label)Label8).Text = "Currently set: \r\nEarliest: " + ((EventTrigger_RandomTime)theTrigger).EarliestTime.ToShortDateString() + " - " + ((EventTrigger_RandomTime)theTrigger).EarliestTime.ToShortTimeString() + "\r\nLatest: " + ((EventTrigger_RandomTime)theTrigger).LatestTime.ToShortDateString() + " - " + ((EventTrigger_RandomTime)theTrigger).LatestTime.ToShortTimeString();
		}
	}

	private void EditTrigger_KeyDown(object sender, KeyEventArgs e)
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

	private void method_18(object sender, EventArgs e)
	{
		((EventTrigger_UnitDetected)theTrigger).DetectorSideID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_UnitDetected_Sides).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
	}

	private void EditTrigger_FormClosed(object sender, FormClosedEventArgs e)
	{
		TB_Days.TextChanged -= method_10;
		TB_Hours.TextChanged -= method_11;
		TB_Mins.TextChanged -= method_12;
		TB_Secs.TextChanged -= method_13;
	}

	private void method_19(object sender, EventArgs e)
	{
		((EventTrigger_UnitDetected)theTrigger).MinimumClassificationLevel = (Contact_Base.IdentificationStatus)((ComboBox)CB_MCL).SelectedIndex;
	}

	private void method_20(object sender, EventArgs e)
	{
		if (theTrigger != null)
		{
			switch (((ComboBox)CB_RegularTimeInterval).SelectedIndex)
			{
			case 0:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.EveryPulse;
				break;
			case 1:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneSecond;
				break;
			case 2:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds;
				break;
			case 3:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds;
				break;
			case 4:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds;
				break;
			case 5:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneMinute;
				break;
			case 6:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes;
				break;
			case 7:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes;
				break;
			case 8:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes;
				break;
			case 9:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneHour;
				break;
			case 10:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.SixHours;
				break;
			case 11:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.TwelveHours;
				break;
			case 12:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours;
				break;
			}
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_Condition).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null) == null)
		{
			DarkMessageBox.ShowError("Error! A condition must be set for the event", "");
		}
		else
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_Condition).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		((ComboBox)CB_BaseStatusCheck_Condition).BeginUpdate();
		((ComboBox)CB_BaseStatusCheck_Condition).Items.Clear();
		((ListControl)CB_BaseStatusCheck_Condition).DisplayMember = "Content";
		switch (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType)
		{
		case GlobalVariables.ActiveUnitType.Ship:
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			byte[] array2 = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
			foreach (byte b2 in array2)
			{
				ComboBoxItem val2 = new ComboBoxItem();
				if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
				{
					((ContentControl)val2).Content = "No conditon set";
					((FrameworkElement)val2).Tag = null;
					((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val2);
					((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
				}
				val2 = new ComboBoxItem();
				ComboBoxItem obj2 = val2;
				ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b2;
				((ContentControl)obj2).Content = dockingOpsCondition.ToString();
				((FrameworkElement)val2).Tag = b2;
				((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val2);
				if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b2 >= 0 && Operators.ConditionalCompareObjectEqual((object)b2, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, true))
				{
					((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Condition).Items.Count - 1;
				}
			}
			break;
		}
		default:
		{
			ComboBoxItem val3 = new ComboBoxItem();
			if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0)
			{
				((ContentControl)val3).Content = "Not valid for condition check";
				((FrameworkElement)val3).Tag = null;
				((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val3);
				((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
			}
			break;
		}
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			byte[] array = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
			foreach (byte b in array)
			{
				switch (b)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 12:
				case 17:
				case 18:
				case 22:
				{
					ComboBoxItem val = new ComboBoxItem();
					if (((ComboBox)CB_BaseStatusCheck_Condition).Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
					{
						((ContentControl)val).Content = "No conditon set";
						((FrameworkElement)val).Tag = null;
						((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val);
						((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = 0;
					}
					val = new ComboBoxItem();
					ComboBoxItem obj = val;
					Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
					((ContentControl)obj).Content = airOpsCondition.ToString();
					((FrameworkElement)val).Tag = b;
					((ComboBox)CB_BaseStatusCheck_Condition).Items.Add((object)val);
					if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b >= 0 && Operators.ConditionalCompareObjectEqual((object)b, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, true))
					{
						((ComboBox)CB_BaseStatusCheck_Condition).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Condition).Items.Count - 1;
					}
					break;
				}
				}
			}
			break;
		}
		}
		((ComboBox)CB_BaseStatusCheck_Condition).EndUpdate();
		string text = null;
		if (((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedIndex > 0)
		{
			text = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
		((ComboBox)CB_BaseStatusCheck_Base).BeginUpdate();
		((ComboBox)CB_BaseStatusCheck_Base).Items.Clear();
		((ListControl)CB_BaseStatusCheck_Base).DisplayMember = "Content";
		if (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType != GlobalVariables.ActiveUnitType.None)
		{
			ComboBoxItem val4 = new ComboBoxItem();
			((ContentControl)val4).Content = "No unit/base limit";
			((FrameworkElement)val4).Tag = "";
			((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val4);
			((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = 0;
			foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_ == null || !activeUnits_.IsActiveUnit || (text != null && (object)activeUnits_.get_UnitSide(SetSideOnly: false).ObjectID != text) || (!activeUnits_.HasAirFacilities && !activeUnits_.HasDockFacilities))
				{
					continue;
				}
				if (activeUnits_.IsGroupMember())
				{
					if (activeUnits_.IsFacility)
					{
						Group obj3 = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
						if (obj3 != null && obj3.HasAirFacilities)
						{
							continue;
						}
					}
					Group obj4 = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
					if (obj4 != null && obj4.HasDockFacilities)
					{
						continue;
					}
				}
				GlobalVariables.ActiveUnitType targetType = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType;
				if (targetType != GlobalVariables.ActiveUnitType.Aircraft)
				{
					if (targetType - 2 > GlobalVariables.ActiveUnitType.Aircraft || !activeUnits_.HasDockFacilities)
					{
						continue;
					}
				}
				else if (!activeUnits_.HasAirFacilities)
				{
					continue;
				}
				val4 = new ComboBoxItem();
				((ContentControl)val4).Content = activeUnits_.Name;
				((FrameworkElement)val4).Tag = activeUnits_.ObjectID;
				((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val4);
				string targetBase = ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase;
				if (targetBase != null && targetBase.Length > 0 && (string.Equals(activeUnits_.Name, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase)))
				{
					((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Base).Items.Count - 1;
				}
			}
			((ComboBox)CB_BaseStatusCheck_Base).EndUpdate();
		}
		((Control)this).Refresh();
	}

	private void method_23(object sender, EventArgs e)
	{
		if (((ComboBox)CB_BaseStatusCheck_Base).SelectedItem != null)
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetBase = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_Base).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
		if (((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem != null)
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetBaseSide = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
	}

	private void EditTrigger_Closing(object sender, EventArgs e)
	{
		if (((ComboBox)CB_BaseStatusCheck_Base).SelectedItem != null)
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetBase = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_Base).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
		if (((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem != null)
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetBaseSide = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		if (((ComboBox)CB_BaseStatusCheck_Base).SelectedItem == null || ((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem == null)
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		string string_ = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_Base).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		if (PrivateMethods.smethod_1(string_, Client.CurrentScenario) != null && Operators.ConditionalCompareObjectEqual((object)PrivateMethods.smethod_1(string_, Client.CurrentScenario).get_UnitSide(SetSideOnly: false).ObjectID, objectValue, true))
		{
			return;
		}
		((ComboBox)CB_BaseStatusCheck_Base).BeginUpdate();
		((ComboBox)CB_BaseStatusCheck_Base).Items.Clear();
		((ListControl)CB_BaseStatusCheck_Base).DisplayMember = "Content";
		if (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType == GlobalVariables.ActiveUnitType.None)
		{
			return;
		}
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "No unit/base limit";
		((FrameworkElement)val).Tag = "";
		((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val);
		((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = 0;
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			if (activeUnits_ == null || !activeUnits_.IsActiveUnit || (objectValue != null && activeUnits_.get_UnitSide(SetSideOnly: false).ObjectID != objectValue) || (!activeUnits_.HasAirFacilities && !activeUnits_.HasDockFacilities))
			{
				continue;
			}
			if (activeUnits_.IsGroupMember())
			{
				if (activeUnits_.IsFacility)
				{
					Group obj = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
					if (obj != null && obj.HasAirFacilities)
					{
						continue;
					}
				}
				Group obj2 = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
				if (obj2 != null && obj2.HasDockFacilities)
				{
					continue;
				}
			}
			GlobalVariables.ActiveUnitType targetType = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType;
			if (targetType != GlobalVariables.ActiveUnitType.Aircraft)
			{
				if (targetType - 2 > GlobalVariables.ActiveUnitType.Aircraft || !activeUnits_.HasDockFacilities)
				{
					continue;
				}
			}
			else if (!activeUnits_.HasAirFacilities)
			{
				continue;
			}
			val = new ComboBoxItem();
			((ContentControl)val).Content = activeUnits_.Name;
			((FrameworkElement)val).Tag = activeUnits_.ObjectID;
			((ComboBox)CB_BaseStatusCheck_Base).Items.Add((object)val);
			string targetBase = ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase;
			if (targetBase != null && targetBase.Length > 0 && (string.Equals(activeUnits_.Name, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase)))
			{
				((ComboBox)CB_BaseStatusCheck_Base).SelectedIndex = ((ComboBox)CB_BaseStatusCheck_Base).Items.Count - 1;
			}
		}
		((ComboBox)CB_BaseStatusCheck_Base).EndUpdate();
		((EventTrigger_UnitBaseStatus)theTrigger).TargetBaseSide = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_BaseStatusCheck_BaseSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
	}

	private void method_25(object sender, EventArgs e)
	{
		((EventTrigger_UnitEmissions)theTrigger).MinimumClassificationLevel = (Contact_Base.IdentificationStatus)((ComboBox)UnitEmissions_MCL).SelectedIndex;
	}

	private void method_26(object sender, EventArgs e)
	{
		((EventTrigger_UnitEmissions)theTrigger).DetectorSideID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)UnitEmissions_Side).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
	}

	private void method_27(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		if (((ComboBox)CB_SideCargo).SelectedItem == null)
		{
			return;
		}
		Side sideByID = Client.CurrentScenario.GetSideByID(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_SideCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)));
		((ComboBox)CB_UnitCargo).BeginUpdate();
		((ComboBox)CB_UnitCargo).Items.Clear();
		((ListControl)CB_UnitCargo).DisplayMember = "Content";
		List<ActiveUnit> allCargoCapableUnits = sideByID.GetAllCargoCapableUnits();
		ComboBoxItem val = null;
		foreach (ActiveUnit item in allCargoCapableUnits)
		{
			ComboBoxItem val2 = new ComboBoxItem();
			((ContentControl)val2).Content = item.Name;
			((FrameworkElement)val2).Tag = item.ObjectID;
			((ComboBox)CB_UnitCargo).Items.Add((object)val2);
			if (item == ((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit)
			{
				val = val2;
			}
		}
		if (val != null)
		{
			((ComboBox)CB_UnitCargo).SelectedItem = val;
		}
		else
		{
			((ComboBox)CB_UnitCargo).SelectedIndex = 0;
		}
		((ComboBox)CB_UnitCargo).EndUpdate();
		method_34();
	}

	private void method_28(object sender, EventArgs e)
	{
		if (((ComboBox)CB_UnitCargo).SelectedItem != null)
		{
			ActiveUnit value = null;
			if (Client.CurrentScenario.ActiveUnits.TryGetValue(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_UnitCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)), out value))
			{
				((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit = value;
			}
			method_34();
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected O, but got Unknown
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		if (((ComboBox)CB_CargoTypeCargo).SelectedItem == null || CargoFilter == null)
		{
			return;
		}
		_Closure$__473-1 arg = default(_Closure$__473-1);
		_Closure$__473-1 CS$<>8__locals13 = new _Closure$__473-1(arg);
		bool flag = Operators.ConditionalCompareObjectNotEqual((object)CargoFilter.SpecificObjectType, NewLateBinding.LateGet(((ComboBox)CB_CargoTypeCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true);
		CargoFilter.SpecificObjectType = (Cargo.CargoObjectType)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_CargoTypeCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		((ComboBox)CB_CargoDBIDCargo).BeginUpdate();
		((ComboBox)CB_CargoDBIDCargo).Items.Clear();
		((ListControl)CB_CargoDBIDCargo).DisplayMember = "Content";
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "ANY";
		((FrameworkElement)val).Tag = 0;
		((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val);
		string text = "";
		CS$<>8__locals13.$VB$Local_theSide = null;
		if (((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit == null)
		{
			if (((ComboBox)CB_SideCargo).SelectedItem != null)
			{
				text = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_SideCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			}
		}
		else
		{
			text = ((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit.get_UnitSide(SetSideOnly: false).ObjectID;
		}
		if (!string.IsNullOrEmpty(text))
		{
			CS$<>8__locals13.$VB$Local_theSide = Client.CurrentScenario.GetSideByID(text);
		}
		IEnumerable<ActiveUnit> enumerable = null;
		switch (CargoFilter.SpecificObjectType)
		{
		case Cargo.CargoObjectType.None:
			((ComboBox)CB_CargoDBIDCargo).SelectedIndex = 0;
			break;
		case Cargo.CargoObjectType.Mount:
		{
			if (CS$<>8__locals13.$VB$Local_theSide == null)
			{
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				DataTable allCargoMounts = DBFunctions.GetAllCargoMounts(ref sqliteConnection_);
				foreach (object row in allCargoMounts.Rows)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(row);
					ComboBoxItem val4 = new ComboBoxItem();
					((ContentControl)val4).Content = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue2, new object[1] { "Name" }, (string[])null));
					((FrameworkElement)val4).Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue2, new object[1] { "ID" }, (string[])null));
					((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val4);
				}
				break;
			}
			List<int> list2 = new List<int>();
			foreach (ActiveUnit unit in CS$<>8__locals13.$VB$Local_theSide.Units)
			{
				if (Module_ActiveUnit.IsAimpointFacility(unit))
				{
					foreach (Mount mount in unit.Mounts)
					{
						if (mount.Cargo_Type > CargoType.NoCargo && !list2.Contains(mount.DBID))
						{
							ComboBoxItem val5 = new ComboBoxItem();
							((ContentControl)val5).Content = mount.Name;
							((FrameworkElement)val5).Tag = mount.DBID;
							((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val5);
							list2.Add(mount.DBID);
						}
					}
				}
				Cargo[] onboardCargo2 = unit.OnboardCargo;
				foreach (Cargo cargo2 in onboardCargo2)
				{
					if (cargo2.CurrentType == Cargo.CargoObjectType.Mount && !list2.Contains(cargo2.CargoObjectDBID))
					{
						ComboBoxItem val6 = new ComboBoxItem();
						((ContentControl)val6).Content = cargo2.CargoObjectName;
						((FrameworkElement)val6).Tag = cargo2.CargoObjectDBID;
						((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val6);
						list2.Add(cargo2.CargoObjectDBID);
					}
				}
			}
			break;
		}
		case Cargo.CargoObjectType.Vehicle:
			enumerable = Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit u) => u.UnitType == GlobalVariables.ActiveUnitType.Vehicle && u is ICargoClient && ((ICargoClient)u).GetRequiredCargoType() > CargoType.NoCargo);
			break;
		case Cargo.CargoObjectType.Facility:
			enumerable = Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit u) =>
			{
				int result;
				if (u.UnitType == GlobalVariables.ActiveUnitType.Facility)
				{
					if (!u.IsMobileGroundUnit)
					{
						result = 0;
					}
					else
					{
						if (u is ICargoClient)
						{
							return ((ICargoClient)u).GetRequiredCargoType() > CargoType.NoCargo;
						}
						result = 0;
					}
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			});
			break;
		case Cargo.CargoObjectType.CargoContainer:
		{
			SQLiteConnection sqliteConnection_;
			if (CS$<>8__locals13.$VB$Local_theSide != null)
			{
				List<ActiveUnit> allCargoCapableUnits = CS$<>8__locals13.$VB$Local_theSide.GetAllCargoCapableUnits();
				List<int> list = new List<int>();
				foreach (ActiveUnit item2 in allCargoCapableUnits)
				{
					Cargo[] onboardCargo = item2.OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						if (cargo.CargoObjectContainer != null && !list.Contains(cargo.CargoObjectDBID))
						{
							ComboBoxItem val2 = new ComboBoxItem();
							int cargoObjectDBID = cargo.CargoObjectDBID;
							sqliteConnection_ = Client.CurrentScenario.DBConnection;
							((ContentControl)val2).Content = DBFunctions.GetCargoContainerName(cargoObjectDBID, ref sqliteConnection_);
							((FrameworkElement)val2).Tag = cargo.CargoObjectDBID;
							((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val2);
							list.Add(cargo.CargoObjectDBID);
						}
					}
				}
				break;
			}
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			DataTable allCargoContainers = DBFunctions.GetAllCargoContainers(ref sqliteConnection_);
			foreach (object row2 in allCargoContainers.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row2);
				ComboBoxItem val3 = new ComboBoxItem();
				((ContentControl)val3).Content = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				((FrameworkElement)val3).Tag = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val3);
			}
			break;
		}
		case Cargo.CargoObjectType.CargoContainerContent:
			((ComboBox)CB_CargoDBIDCargo).SelectedIndex = 0;
			break;
		case Cargo.CargoObjectType.Aircraft:
		{
			enumerable = Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit u) => u.UnitType == GlobalVariables.ActiveUnitType.Aircraft);
			if (enumerable.Count() <= 0)
			{
				break;
			}
			_Closure$__473-0 arg2 = default(_Closure$__473-0);
			_Closure$__473-0 CS$<>8__locals12 = new _Closure$__473-0(arg2);
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			DataTable allCargoAircraft = DBFunctions.GetAllCargoAircraft(ref sqliteConnection_);
			CS$<>8__locals12.$VB$Local_aircraftThatCanBeCargoDBIDs = new List<int>();
			foreach (object row3 in allCargoAircraft.Rows)
			{
				int item = Conversions.ToInteger(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row3), new object[1] { "ID" }, (string[])null));
				if (!CS$<>8__locals12.$VB$Local_aircraftThatCanBeCargoDBIDs.Contains(item))
				{
					CS$<>8__locals12.$VB$Local_aircraftThatCanBeCargoDBIDs.Add(item);
				}
			}
			enumerable = enumerable.Where([SpecialName] (ActiveUnit u) => CS$<>8__locals12.$VB$Local_aircraftThatCanBeCargoDBIDs.Contains(u.DBID));
			break;
		}
		}
		if (enumerable != null)
		{
			if (CS$<>8__locals13.$VB$Local_theSide != null)
			{
				enumerable = enumerable.Where([SpecialName] (ActiveUnit u) => u.get_UnitSide(SetSideOnly: false) == CS$<>8__locals13.$VB$Local_theSide);
			}
			List<int> list3 = new List<int>();
			foreach (ActiveUnit item3 in enumerable)
			{
				if (!list3.Contains(item3.DBID))
				{
					ComboBoxItem val7 = new ComboBoxItem();
					((ContentControl)val7).Content = item3.UnitClass;
					((FrameworkElement)val7).Tag = item3.DBID;
					((ComboBox)CB_CargoDBIDCargo).Items.Add((object)val7);
					list3.Add(item3.DBID);
				}
			}
		}
		if (flag)
		{
			((ComboBox)CB_CargoDBIDCargo).SelectedIndex = 0;
		}
		else if (CargoFilter.SpecificCargoDBID != 0)
		{
			foreach (object item4 in ((ComboBox)CB_CargoDBIDCargo).Items)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(item4);
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue3, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null), (object)CargoFilter.SpecificCargoDBID, true))
				{
					((ComboBox)CB_CargoDBIDCargo).SelectedItem = RuntimeHelpers.GetObjectValue(objectValue3);
					break;
				}
			}
		}
		else
		{
			((ComboBox)CB_CargoDBIDCargo).SelectedIndex = 0;
		}
		((ComboBox)CB_CargoDBIDCargo).EndUpdate();
		method_34();
	}

	private void method_30(object sender, EventArgs e)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		if (((ComboBox)CB_CargoDBIDCargo).SelectedItem == null || CargoFilter == null)
		{
			return;
		}
		bool flag = Operators.ConditionalCompareObjectNotEqual((object)CargoFilter.SpecificCargoDBID, NewLateBinding.LateGet(((ComboBox)CB_CargoDBIDCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true);
		CargoFilter.SpecificCargoDBID = Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_CargoDBIDCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		((ComboBox)CB_CargoSpecificUnitCargo).BeginUpdate();
		((ComboBox)CB_CargoSpecificUnitCargo).Items.Clear();
		((ListControl)CB_CargoSpecificUnitCargo).DisplayMember = "Content";
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "ANY";
		((FrameworkElement)val).Tag = "";
		((ComboBox)CB_CargoSpecificUnitCargo).Items.Add((object)val);
		if (CargoFilter.SpecificCargoDBID > 0)
		{
			string text = "";
			Side side = null;
			if (((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit != null)
			{
				text = ((EventTrigger_UnitCargoMoved)theTrigger).BaseUnit.get_UnitSide(SetSideOnly: false).ObjectID;
			}
			else if (((ComboBox)CB_SideCargo).SelectedItem != null)
			{
				text = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_SideCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			}
			if (!string.IsNullOrEmpty(text))
			{
				side = Client.CurrentScenario.GetSideByID(text);
			}
			IEnumerable<ActiveUnit> enumerable = null;
			switch (CargoFilter.SpecificObjectType)
			{
			case Cargo.CargoObjectType.None:
				((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
				break;
			case Cargo.CargoObjectType.Mount:
				((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
				break;
			case Cargo.CargoObjectType.Vehicle:
				if (side != null)
				{
					enumerable = side.Units.Where([SpecialName] (ActiveUnit u) => u.UnitType == GlobalVariables.ActiveUnitType.Vehicle && u.DBID == CargoFilter.SpecificCargoDBID);
				}
				break;
			case Cargo.CargoObjectType.Facility:
				if (side != null)
				{
					enumerable = side.Units.Where([SpecialName] (ActiveUnit u) => u.UnitType == GlobalVariables.ActiveUnitType.Facility && u.DBID == CargoFilter.SpecificCargoDBID);
				}
				break;
			case Cargo.CargoObjectType.CargoContainer:
			{
				if (side == null)
				{
					break;
				}
				List<ActiveUnit> allCargoCapableUnits = side.GetAllCargoCapableUnits();
				foreach (ActiveUnit item in allCargoCapableUnits)
				{
					Cargo[] onboardCargo = item.OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						if (cargo.CargoObjectContainer != null && cargo.CargoObjectDBID == CargoFilter.SpecificCargoDBID)
						{
							ComboBoxItem val2 = new ComboBoxItem();
							((ContentControl)val2).Content = cargo.CargoObjectName;
							((FrameworkElement)val2).Tag = cargo.CargoObjectID;
							((ComboBox)CB_CargoSpecificUnitCargo).Items.Add((object)val2);
						}
					}
				}
				break;
			}
			case Cargo.CargoObjectType.CargoContainerContent:
				((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
				break;
			case Cargo.CargoObjectType.Aircraft:
				if (side != null)
				{
					enumerable = side.Units.Where([SpecialName] (ActiveUnit u) => u.UnitType == GlobalVariables.ActiveUnitType.Aircraft && u.DBID == CargoFilter.SpecificCargoDBID);
				}
				break;
			}
			if (enumerable != null)
			{
				foreach (ActiveUnit item2 in enumerable)
				{
					ComboBoxItem val3 = new ComboBoxItem();
					if (!item2.IsAircraft)
					{
						((ContentControl)val3).Content = item2.Name;
					}
					else
					{
						((ContentControl)val3).Content = item2.Name + " (" + item2.UnitClass + ")";
					}
					((FrameworkElement)val3).Tag = item2.ObjectID;
					((ComboBox)CB_CargoSpecificUnitCargo).Items.Add((object)val3);
				}
			}
			if (flag)
			{
				((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
			}
			else if (!string.IsNullOrEmpty(CargoFilter.SpecificCargoObjID))
			{
				foreach (object item3 in ((ComboBox)CB_CargoSpecificUnitCargo).Items)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item3);
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null), (object)CargoFilter.SpecificCargoObjID, true))
					{
						((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem = RuntimeHelpers.GetObjectValue(objectValue);
						break;
					}
				}
			}
			else
			{
				((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
			}
		}
		else
		{
			((ComboBox)CB_CargoSpecificUnitCargo).SelectedIndex = 0;
		}
		((ComboBox)CB_CargoSpecificUnitCargo).EndUpdate();
		method_34();
	}

	private void method_31(object sender, EventArgs e)
	{
		if (((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem != null && CargoFilter != null)
		{
			CargoFilter.SpecificCargoObjID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			method_34();
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		if (CargoFilter != null)
		{
			CargoFilter.ThresholdReceived = Convert.ToInt32(((NumericUpDown)NUM_RecvThresholdCargo).Value);
			method_34();
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		if (CargoFilter != null)
		{
			CargoFilter.ThresholdSent = Convert.ToInt32(((NumericUpDown)NUM_SendThresholdCargo).Value);
			method_34();
		}
	}

	private void method_34()
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		if (CargoFilter != null)
		{
			if (CargoFilter.ThresholdReceived == 0 && CargoFilter.ThresholdSent == 0)
			{
				((Label)Label_DescCargo).Text = "WILL NOT TRIGGER! Both sent and received threshold are currently 0. Set at least one threshold > 0.";
				return;
			}
			EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = (EventTrigger_UnitCargoMoved)theTrigger;
			if (eventTrigger_UnitCargoMoved.BaseUnit == null)
			{
				((Label)Label_DescCargo).Text = "Trigger when: (ERROR - no trigger unit set!)";
				return;
			}
			string name = eventTrigger_UnitCargoMoved.BaseUnit.Name;
			name = name + " (Side " + eventTrigger_UnitCargoMoved.BaseUnit.get_UnitSide(SetSideOnly: false).Name + ")";
			if (CargoFilter.ThresholdReceived <= 0)
			{
				if (CargoFilter.ThresholdSent > 0)
				{
					name = name + " sends " + CargoFilter.ThresholdSent;
				}
			}
			else
			{
				name = name + " receives " + CargoFilter.ThresholdReceived;
				if (CargoFilter.ThresholdSent > 0)
				{
					name = name + " OR sends " + CargoFilter.ThresholdSent;
				}
			}
			name += " movement of ";
			switch (CargoFilter.SpecificObjectType)
			{
			case Cargo.CargoObjectType.None:
				name += "any cargo.";
				break;
			case Cargo.CargoObjectType.Mount:
				name = ((CargoFilter.SpecificCargoDBID == 0 || ((ComboBox)CB_CargoDBIDCargo).SelectedItem == null) ? (name + "any mount.") : Conversions.ToString(Operators.ConcatenateObject((object)(name + "mount of class: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoDBIDCargo).SelectedItem).Content)));
				break;
			case Cargo.CargoObjectType.Vehicle:
				name = ((CargoFilter.SpecificCargoDBID == 0 || ((ComboBox)CB_CargoDBIDCargo).SelectedItem == null) ? (name + "any ground unit.") : ((string.IsNullOrEmpty(CargoFilter.SpecificCargoObjID) || ((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem == null) ? Conversions.ToString(Operators.ConcatenateObject((object)(name + "ground unit of class: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoDBIDCargo).SelectedItem).Content)) : Conversions.ToString(Operators.ConcatenateObject((object)(name + "ground unit: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem).Content))));
				break;
			case Cargo.CargoObjectType.Facility:
				name = ((CargoFilter.SpecificCargoDBID == 0 || ((ComboBox)CB_CargoDBIDCargo).SelectedItem == null) ? (name + "any mobile facility.") : ((string.IsNullOrEmpty(CargoFilter.SpecificCargoObjID) || ((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem == null) ? Conversions.ToString(Operators.ConcatenateObject((object)(name + "mobile facility of class: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoDBIDCargo).SelectedItem).Content)) : Conversions.ToString(Operators.ConcatenateObject((object)(name + "mobile facility: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem).Content))));
				break;
			case Cargo.CargoObjectType.CargoContainer:
				name = ((CargoFilter.SpecificCargoDBID == 0 || ((ComboBox)CB_CargoDBIDCargo).SelectedItem == null) ? (name + "any cargo container.") : ((string.IsNullOrEmpty(CargoFilter.SpecificCargoObjID) || ((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem == null) ? Conversions.ToString(Operators.ConcatenateObject((object)(name + "cargo container of class: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoDBIDCargo).SelectedItem).Content)) : Conversions.ToString(Operators.ConcatenateObject((object)(name + "cargo container: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem).Content))));
				break;
			case Cargo.CargoObjectType.CargoContainerContent:
				name += "any cargo container contents.";
				break;
			case Cargo.CargoObjectType.Aircraft:
				name = ((CargoFilter.SpecificCargoDBID == 0 || ((ComboBox)CB_CargoDBIDCargo).SelectedItem == null) ? (name + "any aircraft.") : ((string.IsNullOrEmpty(CargoFilter.SpecificCargoObjID) || ((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem == null) ? Conversions.ToString(Operators.ConcatenateObject((object)(name + "aircraft of class: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoDBIDCargo).SelectedItem).Content)) : Conversions.ToString(Operators.ConcatenateObject((object)(name + "aircraft: "), ((ContentControl)(ComboBoxItem)((ComboBox)CB_CargoSpecificUnitCargo).SelectedItem).Content))));
				break;
			}
			((Label)Label_DescCargo).Text = "Trigger when: " + name;
		}
		else
		{
			((Label)Label_DescCargo).Text = "Trigger when: (ERROR)";
		}
	}

	static EditTrigger()
	{
		Class72.smethod_20();
	}
}
