using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using CommandNetcode.RT;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DoctrineForm : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("TabControl1A")]
	[CompilerGenerated]
	private DarkUITabControl _TabControl1A;

	[AccessedThroughProperty("CB_EMCON_Radar")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_EMCON_Radar;

	[AccessedThroughProperty("CB_EMCON_Inherits")]
	[CompilerGenerated]
	private DarkCheckBox _CB_EMCON_Inherits;

	[AccessedThroughProperty("CB_EMCON_OECM")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_EMCON_OECM;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_Sonar")]
	private DarkUIComboBox _CB_EMCON_Sonar;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_WRA")]
	private DarkTreeGridView _TGV_WRA;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetCurrent_WRA")]
	private DarkUIButton TtoSdWysmEr;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedMissions_Doctrine")]
	private DarkUIButton _Button_ResetAffectedMissions_Doctrine;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedUnits_Doctrine")]
	private DarkUIButton _Button_ResetAffectedUnits_Doctrine;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetCurrent_Doctrine")]
	private DarkUIButton _Button_ResetCurrent_Doctrine;

	[AccessedThroughProperty("Button_ResetAffectedMissions_WRA")]
	[CompilerGenerated]
	private DarkUIButton _Button_ResetAffectedMissions_WRA;

	[AccessedThroughProperty("Button_ResetAffectedUnits_WRA")]
	[CompilerGenerated]
	private DarkUIButton _Button_ResetAffectedUnits_WRA;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedMissions_EMCON")]
	private DarkUIButton _Button_ResetAffectedMissions_EMCON;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedUnits_EMCON")]
	private DarkUIButton _Button_ResetAffectedUnits_EMCON;

	[AccessedThroughProperty("Button_ResetCurrent_EMCON")]
	[CompilerGenerated]
	private DarkUIButton _Button_ResetCurrent_EMCON;

	[AccessedThroughProperty("EmissionIntervalTABControl")]
	[CompilerGenerated]
	private DarkUITabControl _EmissionIntervalTABControl;

	[CompilerGenerated]
	[AccessedThroughProperty("CBWakeWhenDetectingThreat")]
	private DarkUICheckBox _CBWakeWhenDetectingThreat;

	[AccessedThroughProperty("IntermittantToggle")]
	[CompilerGenerated]
	private DarkUIButton _IntermittantToggle;

	[AccessedThroughProperty("Combo_AlertLevel")]
	[CompilerGenerated]
	private DarkUIComboBox _Combo_AlertLevel;

	[AccessedThroughProperty("DEBUGINTERMITTENT1")]
	[CompilerGenerated]
	private DarkLabel darkLabel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IncludesID_Unknown")]
	private CheckBox _CB_IncludesID_Unknown;

	[AccessedThroughProperty("CB_IncludesStance_Unknown")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesStance_Unknown;

	[AccessedThroughProperty("CB_IncludesStance_Hostile")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesStance_Hostile;

	[AccessedThroughProperty("CB_IncludesStance_Unfriendly")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesStance_Unfriendly;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IncludesStance_Neutral")]
	private CheckBox _CB_IncludesStance_Neutral;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IncludesStance_Friendly")]
	private CheckBox _CB_IncludesStance_Friendly;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EmconFollowsWRARules")]
	private DarkUICheckBox _CB_EmconFollowsWRARules;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IncludesID_KnownDomain")]
	private CheckBox _CB_IncludesID_KnownDomain;

	[AccessedThroughProperty("CB_IncludesID_KnownID")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesID_KnownID;

	[AccessedThroughProperty("CB_IncludesID_KnowType")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesID_KnowType;

	[AccessedThroughProperty("CB_IncludesID_KnownClass")]
	[CompilerGenerated]
	private CheckBox _CB_IncludesID_KnownClass;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IntermittentEmission_USECUSTOM")]
	private DarkUICheckBox _CB_IntermittentEmission_USECUSTOM;

	[AccessedThroughProperty("CBIntermittentEmission_InheritFromGroup")]
	[CompilerGenerated]
	private DarkUICheckBox _CBIntermittentEmission_InheritFromGroup;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUICheckBox1")]
	private DarkUICheckBox TowSjqYbyIA;

	[AccessedThroughProperty("DarkLabel9")]
	[CompilerGenerated]
	private DarkLabel davSjwwpRyF;

	[CompilerGenerated]
	[AccessedThroughProperty("SaveTemplate")]
	private DarkUIButton _SaveTemplate;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadTemplate")]
	private DarkUIButton _LoadTemplate;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel13")]
	private DarkLabel darkLabel_1;

	[AccessedThroughProperty("DarkLabel12")]
	[CompilerGenerated]
	private DarkLabel darkLabel_2;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel11")]
	private DarkLabel darkLabel_3;

	[AccessedThroughProperty("DarkLabel10")]
	[CompilerGenerated]
	private DarkLabel darkLabel_4;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_PTLDelete")]
	private DarkUIButton _Btn_PTLDelete;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_PTLAdd")]
	private DarkUIButton _Btn_PTLAdd;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_PTLMoveDown")]
	private DarkUIButton _Btn_PTLMoveDown;

	[AccessedThroughProperty("Btn_PTLMoveUp")]
	[CompilerGenerated]
	private DarkUIButton _Btn_PTLMoveUp;

	[AccessedThroughProperty("List_TargetPriority")]
	[CompilerGenerated]
	private DarkListView _List_TargetPriority;

	[AccessedThroughProperty("Btn_PTLRemove")]
	[CompilerGenerated]
	private DarkUIButton _Btn_PTLRemove;

	[AccessedThroughProperty("Btn_PTLCreate")]
	[CompilerGenerated]
	private DarkUIButton _Btn_PTLCreate;

	[CompilerGenerated]
	[AccessedThroughProperty("DocUC_WithdrawDamageThreshold")]
	private DoctrineItem_uc BulSjOfoOyP;

	private ScenarioObject scenarioObject_0;

	[CompilerGenerated]
	private bool bool_2;

	public List<ActiveUnit> _SelectedUnits;

	public bool UnitIsOperating;

	private Doctrine doctrine_0;

	private Dictionary<int, Doctrine.WRA_Weapon> dictionary_0;

	private List<int> rgcSmyflIiU;

	private bool bool_3;

	public bool isAirOps;

	public bool isBoatOps;

	public bool isMissionEdit;

	public bool isEscorts;

	private bool bool_4;

	public Alertlevels? IntermittentEmissionSelectedAlertLevel;

	private ActiveEmissionInterval_Config activeEmissionInterval_Config_0;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ImportTemplate")]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ExportTemplate")]
	private SaveFileDialog saveFileDialog_0;

	public int[] IntervalComboboxReference;

	private Keys[] keys_0;

	private bool bool_5;

	private bool bool_6;

	internal virtual DarkUITabControl TabControl1A
	{
		[CompilerGenerated]
		get
		{
			return _TabControl1A;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUITabControl darkUITabControl = _TabControl1A;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl1A = value;
			darkUITabControl = _TabControl1A;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	internal virtual DarkUIComboBox CB_EMCON_Radar
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_Radar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_Radar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_Radar = value;
			darkUIComboBox = _CB_EMCON_Radar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	internal virtual DarkCheckBox CB_EMCON_Inherits
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_Inherits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkCheckBox darkCheckBox = _CB_EMCON_Inherits;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_EMCON_Inherits = value;
			darkCheckBox = _CB_EMCON_Inherits;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_EMCON_OECM
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_OECM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_OECM;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_OECM = value;
			darkUIComboBox = _CB_EMCON_OECM;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	internal virtual DarkUIComboBox CB_EMCON_Sonar
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_Sonar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_Sonar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_Sonar = value;
			darkUIComboBox = _CB_EMCON_Sonar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	private virtual DarkTreeGridView TGV_WRA
	{
		[CompilerGenerated]
		get
		{
			return _TGV_WRA;
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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_18);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_19);
			DataGridViewDataErrorEventHandler val3 = new DataGridViewDataErrorEventHandler(method_20);
			EventHandler eventHandler = method_21;
			ExpandingEventHandler value2 = method_24;
			CollapsingEventHandler value3 = method_25;
			DarkTreeGridView darkTreeGridView = _TGV_WRA;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellClick -= val;
				((DataGridView)darkTreeGridView).CellValueChanged -= val2;
				((DataGridView)darkTreeGridView).DataError -= val3;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged -= eventHandler;
				darkTreeGridView.NodeExpanding -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
			}
			_TGV_WRA = value;
			darkTreeGridView = _TGV_WRA;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).CellClick += val;
				((DataGridView)darkTreeGridView).CellValueChanged += val2;
				((DataGridView)darkTreeGridView).DataError += val3;
				((DataGridView)darkTreeGridView).CurrentCellDirtyStateChanged += eventHandler;
				darkTreeGridView.NodeExpanding += value2;
				darkTreeGridView.NodeCollapsing += value3;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetCurrent_WRA
	{
		[CompilerGenerated]
		get
		{
			return TtoSdWysmEr;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIButton darkUIButton = TtoSdWysmEr;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			TtoSdWysmEr = value;
			darkUIButton = TtoSdWysmEr;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedMissions_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedMissions_Doctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkUIButton darkUIButton = _Button_ResetAffectedMissions_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedMissions_Doctrine = value;
			darkUIButton = _Button_ResetAffectedMissions_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedUnits_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedUnits_Doctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkUIButton darkUIButton = _Button_ResetAffectedUnits_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedUnits_Doctrine = value;
			darkUIButton = _Button_ResetAffectedUnits_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetCurrent_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetCurrent_Doctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkUIButton darkUIButton = _Button_ResetCurrent_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetCurrent_Doctrine = value;
			darkUIButton = _Button_ResetCurrent_Doctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedMissions_WRA
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedMissions_WRA;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkUIButton darkUIButton = _Button_ResetAffectedMissions_WRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedMissions_WRA = value;
			darkUIButton = _Button_ResetAffectedMissions_WRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedUnits_WRA
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedUnits_WRA;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIButton darkUIButton = _Button_ResetAffectedUnits_WRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedUnits_WRA = value;
			darkUIButton = _Button_ResetAffectedUnits_WRA;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedMissions_EMCON
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedMissions_EMCON;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkUIButton darkUIButton = _Button_ResetAffectedMissions_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedMissions_EMCON = value;
			darkUIButton = _Button_ResetAffectedMissions_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetAffectedUnits_EMCON
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetAffectedUnits_EMCON;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkUIButton darkUIButton = _Button_ResetAffectedUnits_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetAffectedUnits_EMCON = value;
			darkUIButton = _Button_ResetAffectedUnits_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetCurrent_EMCON
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetCurrent_EMCON;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkUIButton darkUIButton = _Button_ResetCurrent_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetCurrent_EMCON = value;
			darkUIButton = _Button_ResetCurrent_EMCON;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	[field: AccessedThroughProperty("Label43")]
	internal virtual DarkLabel Label43 { get; set; }

	[field: AccessedThroughProperty("TargetType")]
	internal virtual TreeGridColumn TargetType { get; set; }

	[field: AccessedThroughProperty("WeaponsPerSalvo")]
	internal virtual DataGridViewComboBoxColumn WeaponsPerSalvo { get; set; }

	[field: AccessedThroughProperty("ShootersPerSalvo")]
	internal virtual DataGridViewComboBoxColumn ShootersPerSalvo { get; set; }

	[field: AccessedThroughProperty("FiringRange")]
	internal virtual DataGridViewComboBoxColumn FiringRange { get; set; }

	[field: AccessedThroughProperty("SelfDefenceRange")]
	internal virtual DataGridViewComboBoxColumn SelfDefenceRange { get; set; }

	[field: AccessedThroughProperty("UseIntervalGroup")]
	internal virtual DarkGroupBox UseIntervalGroup { get; set; }

	internal virtual DarkUITabControl EmissionIntervalTABControl
	{
		[CompilerGenerated]
		get
		{
			return _EmissionIntervalTABControl;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkUITabControl darkUITabControl = _EmissionIntervalTABControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_EmissionIntervalTABControl = value;
			darkUITabControl = _EmissionIntervalTABControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GreenAlert")]
	internal virtual TabPage GreenAlert { get; set; }

	[field: AccessedThroughProperty("BlueAlert")]
	internal virtual TabPage BlueAlert { get; set; }

	[field: AccessedThroughProperty("Label_AEI_2")]
	internal virtual DarkLabel Label_AEI_2 { get; set; }

	[field: AccessedThroughProperty("IntervalVariation")]
	internal virtual DarkUITextBox IntervalVariation { get; set; }

	[field: AccessedThroughProperty("Interval")]
	internal virtual DarkUITextBox Interval { get; set; }

	[field: AccessedThroughProperty("YellowAlert")]
	internal virtual TabPage YellowAlert { get; set; }

	[field: AccessedThroughProperty("OrangeAlert")]
	internal virtual TabPage OrangeAlert { get; set; }

	[field: AccessedThroughProperty("Label_AEI_3")]
	internal virtual DarkLabel Label_AEI_3 { get; set; }

	[field: AccessedThroughProperty("BackToSleepTime")]
	internal virtual DarkUITextBox BackToSleepTime { get; set; }

	internal virtual DarkUICheckBox CBWakeWhenDetectingThreat
	{
		[CompilerGenerated]
		get
		{
			return _CBWakeWhenDetectingThreat;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_55;
			DarkUICheckBox darkUICheckBox = _CBWakeWhenDetectingThreat;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CBWakeWhenDetectingThreat = value;
			darkUICheckBox = _CBWakeWhenDetectingThreat;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AEI_1")]
	internal virtual DarkLabel Label_AEI_1 { get; set; }

	[field: AccessedThroughProperty("RedAlert")]
	internal virtual TabPage RedAlert { get; set; }

	internal virtual DarkUIButton IntermittantToggle
	{
		[CompilerGenerated]
		get
		{
			return _IntermittantToggle;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			DarkUIButton darkUIButton = _IntermittantToggle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_IntermittantToggle = value;
			darkUIButton = _IntermittantToggle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AEI_0")]
	internal virtual DarkLabel Label_AEI_0 { get; set; }

	[field: AccessedThroughProperty("EmissionIntervalPhonyTab")]
	internal virtual Panel EmissionIntervalPhonyTab { get; set; }

	[field: AccessedThroughProperty("EmissionDurationTextBox")]
	internal virtual DarkUITextBox EmissionDurationTextBox { get; set; }

	internal virtual DarkUIComboBox Combo_AlertLevel
	{
		[CompilerGenerated]
		get
		{
			return _Combo_AlertLevel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_56;
			DarkUIComboBox darkUIComboBox = _Combo_AlertLevel;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_Combo_AlertLevel = value;
			darkUIComboBox = _Combo_AlertLevel;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkLabel DEBUGINTERMITTENT1
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

	[field: AccessedThroughProperty("LabelPlus")]
	internal virtual DarkLabel LabelPlus { get; set; }

	[field: AccessedThroughProperty("DefoncLabel2")]
	internal virtual DarkLabel DefoncLabel2 { get; set; }

	[field: AccessedThroughProperty("WakeGroupBox")]
	internal virtual DarkGroupBox WakeGroupBox { get; set; }

	internal virtual CheckBox CB_IncludesID_Unknown
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesID_Unknown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_62;
			CheckBox val = _CB_IncludesID_Unknown;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesID_Unknown = value;
			val = _CB_IncludesID_Unknown;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesStance_Unknown
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesStance_Unknown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_61;
			CheckBox val = _CB_IncludesStance_Unknown;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesStance_Unknown = value;
			val = _CB_IncludesStance_Unknown;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesStance_Hostile
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesStance_Hostile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_60;
			CheckBox val = _CB_IncludesStance_Hostile;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesStance_Hostile = value;
			val = _CB_IncludesStance_Hostile;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesStance_Unfriendly
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesStance_Unfriendly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			CheckBox val = _CB_IncludesStance_Unfriendly;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesStance_Unfriendly = value;
			val = _CB_IncludesStance_Unfriendly;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesStance_Neutral
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesStance_Neutral;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_58;
			CheckBox val = _CB_IncludesStance_Neutral;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesStance_Neutral = value;
			val = _CB_IncludesStance_Neutral;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesStance_Friendly
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesStance_Friendly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			CheckBox val = _CB_IncludesStance_Friendly;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesStance_Friendly = value;
			val = _CB_IncludesStance_Friendly;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUICheckBox CB_EmconFollowsWRARules
	{
		[CompilerGenerated]
		get
		{
			return _CB_EmconFollowsWRARules;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_67;
			DarkUICheckBox darkUICheckBox = _CB_EmconFollowsWRARules;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_EmconFollowsWRARules = value;
			darkUICheckBox = _CB_EmconFollowsWRARules;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("IncludesIDGroup")]
	internal virtual DarkGroupBox IncludesIDGroup { get; set; }

	internal virtual CheckBox CB_IncludesID_KnownDomain
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesID_KnownDomain;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_63;
			CheckBox val = _CB_IncludesID_KnownDomain;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesID_KnownDomain = value;
			val = _CB_IncludesID_KnownDomain;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesID_KnownID
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesID_KnownID;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_66;
			CheckBox val = _CB_IncludesID_KnownID;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesID_KnownID = value;
			val = _CB_IncludesID_KnownID;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesID_KnowType
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesID_KnowType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_64;
			CheckBox val = _CB_IncludesID_KnowType;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesID_KnowType = value;
			val = _CB_IncludesID_KnowType;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_IncludesID_KnownClass
	{
		[CompilerGenerated]
		get
		{
			return _CB_IncludesID_KnownClass;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
			CheckBox val = _CB_IncludesID_KnownClass;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_IncludesID_KnownClass = value;
			val = _CB_IncludesID_KnownClass;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Includes")]
	internal virtual DarkGroupBox Includes { get; set; }

	internal virtual DarkUICheckBox CB_IntermittentEmission_USECUSTOM
	{
		[CompilerGenerated]
		get
		{
			return _CB_IntermittentEmission_USECUSTOM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_68;
			DarkUICheckBox darkUICheckBox = _CB_IntermittentEmission_USECUSTOM;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_IntermittentEmission_USECUSTOM = value;
			darkUICheckBox = _CB_IntermittentEmission_USECUSTOM;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Custom")]
	internal virtual TabPage Custom { get; set; }

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	internal virtual DarkUICheckBox CBIntermittentEmission_InheritFromGroup
	{
		[CompilerGenerated]
		get
		{
			return _CBIntermittentEmission_InheritFromGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_69;
			DarkUICheckBox darkUICheckBox = _CBIntermittentEmission_InheritFromGroup;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CBIntermittentEmission_InheritFromGroup = value;
			darkUICheckBox = _CBIntermittentEmission_InheritFromGroup;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUICheckBox DarkUICheckBox1
	{
		[CompilerGenerated]
		get
		{
			return TowSjqYbyIA;
		}
		[CompilerGenerated]
		set
		{
			TowSjqYbyIA = value;
		}
	}

	internal virtual DarkLabel DarkLabel9
	{
		[CompilerGenerated]
		get
		{
			return davSjwwpRyF;
		}
		[CompilerGenerated]
		set
		{
			davSjwwpRyF = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkUIButton SaveTemplate
	{
		[CompilerGenerated]
		get
		{
			return _SaveTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SaveTemplate_Click;
			DarkUIButton darkUIButton = _SaveTemplate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_SaveTemplate = value;
			darkUIButton = _SaveTemplate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton LoadTemplate
	{
		[CompilerGenerated]
		get
		{
			return _LoadTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LoadTemplate_Click;
			DarkUIButton darkUIButton = _LoadTemplate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_LoadTemplate = value;
			darkUIButton = _LoadTemplate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	internal virtual DarkLabel DarkLabel13
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

	internal virtual DarkLabel DarkLabel12
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

	internal virtual DarkLabel DarkLabel11
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

	internal virtual DarkLabel DarkLabel10
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

	internal virtual DarkUIButton Btn_PTLDelete
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLDelete;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_73;
			DarkUIButton darkUIButton = _Btn_PTLDelete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLDelete = value;
			darkUIButton = _Btn_PTLDelete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_PTLAdd
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLAdd;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_72;
			DarkUIButton darkUIButton = _Btn_PTLAdd;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLAdd = value;
			darkUIButton = _Btn_PTLAdd;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_PTLMoveDown
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLMoveDown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_71;
			DarkUIButton darkUIButton = _Btn_PTLMoveDown;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLMoveDown = value;
			darkUIButton = _Btn_PTLMoveDown;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_PTLMoveUp
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLMoveUp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_70;
			DarkUIButton darkUIButton = _Btn_PTLMoveUp;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLMoveUp = value;
			darkUIButton = _Btn_PTLMoveUp;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkListView List_TargetPriority
	{
		[CompilerGenerated]
		get
		{
			return _List_TargetPriority;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_74;
			DarkListView darkListView = _List_TargetPriority;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_List_TargetPriority = value;
			darkListView = _List_TargetPriority;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Btn_PTLRemove
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLRemove;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_77;
			DarkUIButton darkUIButton = _Btn_PTLRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLRemove = value;
			darkUIButton = _Btn_PTLRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_PTLCreate
	{
		[CompilerGenerated]
		get
		{
			return _Btn_PTLCreate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_76;
			DarkUIButton darkUIButton = _Btn_PTLCreate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_PTLCreate = value;
			darkUIButton = _Btn_PTLCreate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_PTLSource")]
	internal virtual DarkLabel Label_PTLSource { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DoctrineItem_uc DocUC_WithdrawDamageThreshold
	{
		[CompilerGenerated]
		get
		{
			return BulSjOfoOyP;
		}
		[CompilerGenerated]
		set
		{
			BulSjOfoOyP = value;
		}
	}

	[field: AccessedThroughProperty("DocUC_WithdrawFuelThreshold")]
	internal virtual DoctrineItem_uc DocUC_WithdrawFuelThreshold { get; set; }

	[field: AccessedThroughProperty("DocUC_WithdrawAttackThreshold")]
	internal virtual DoctrineItem_uc DocUC_WithdrawAttackThreshold { get; set; }

	[field: AccessedThroughProperty("DocUC_WithdrawDefenceThreshold")]
	internal virtual DoctrineItem_uc DocUC_WithdrawDefenceThreshold { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DocUC_DeplDamageThreshold")]
	internal virtual DoctrineItem_uc DocUC_DeplDamageThreshold { get; set; }

	[field: AccessedThroughProperty("DocUC_DeplFuelThreshold")]
	internal virtual DoctrineItem_uc DocUC_DeplFuelThreshold { get; set; }

	[field: AccessedThroughProperty("DocUC_DeplAttackThreshold")]
	internal virtual DoctrineItem_uc DocUC_DeplAttackThreshold { get; set; }

	[field: AccessedThroughProperty("DocUC_DeplDefenceThreshold")]
	internal virtual DoctrineItem_uc DocUC_DeplDefenceThreshold { get; set; }

	[field: AccessedThroughProperty("DoctrineControl1")]
	internal virtual DoctrineControl DoctrineControl1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel4")]
	internal virtual FlowLayoutPanel FlowLayoutPanel4 { get; set; }

	public ScenarioObject Subject
	{
		get
		{
			return scenarioObject_0;
		}
		set
		{
			scenarioObject_0 = value;
			if (!Information.IsNothing((object)scenarioObject_0))
			{
				method_4();
			}
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

	public List<ActiveUnit> SelectedUnits
	{
		get
		{
			if (!isMissionEdit)
			{
				return _SelectedUnits;
			}
			return null;
		}
		set
		{
			_SelectedUnits = value;
		}
	}

	internal virtual OpenFileDialog FD_ImportTemplate
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual SaveFileDialog FD_ExportTemplate
	{
		[CompilerGenerated]
		get
		{
			return saveFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			saveFileDialog_0 = value;
		}
	}

	public ActiveEmissionInterval_Config IntervalConfigs
	{
		get
		{
			if (Information.IsNothing((object)activeEmissionInterval_Config_0))
			{
				activeEmissionInterval_Config_0 = method_44();
			}
			return activeEmissionInterval_Config_0;
		}
		set
		{
			activeEmissionInterval_Config_0 = value;
		}
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
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_0915: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c28: Expected O, but got Unknown
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce3: Expected O, but got Unknown
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1458: Unknown result type (might be due to invalid IL or missing references)
		//IL_1462: Expected O, but got Unknown
		//IL_151f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d3: Expected O, but got Unknown
		//IL_19b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af5: Expected O, but got Unknown
		//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb4: Expected O, but got Unknown
		//IL_1bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c77: Expected O, but got Unknown
		//IL_1cb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2490: Unknown result type (might be due to invalid IL or missing references)
		//IL_249a: Expected O, but got Unknown
		//IL_24d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e6f: Expected O, but got Unknown
		//IL_2f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f3e: Expected O, but got Unknown
		//IL_2f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3003: Expected O, but got Unknown
		//IL_3041: Unknown result type (might be due to invalid IL or missing references)
		//IL_30be: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c8: Expected O, but got Unknown
		//IL_3102: Unknown result type (might be due to invalid IL or missing references)
		//IL_3184: Unknown result type (might be due to invalid IL or missing references)
		//IL_318e: Expected O, but got Unknown
		//IL_3298: Unknown result type (might be due to invalid IL or missing references)
		//IL_32a2: Expected O, but got Unknown
		//IL_33ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3409: Expected O, but got Unknown
		//IL_3573: Unknown result type (might be due to invalid IL or missing references)
		//IL_35e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ed: Expected O, but got Unknown
		//IL_362b: Unknown result type (might be due to invalid IL or missing references)
		//IL_36a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b2: Expected O, but got Unknown
		//IL_36f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_376d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3777: Expected O, but got Unknown
		//IL_37b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_39cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_39d6: Expected O, but got Unknown
		//IL_3a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cea: Expected O, but got Unknown
		//IL_3d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4180: Unknown result type (might be due to invalid IL or missing references)
		//IL_4282: Unknown result type (might be due to invalid IL or missing references)
		//IL_428c: Expected O, but got Unknown
		//IL_433e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4348: Expected O, but got Unknown
		//IL_43f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4401: Expected O, but got Unknown
		//IL_44b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ba: Expected O, but got Unknown
		//IL_4596: Unknown result type (might be due to invalid IL or missing references)
		//IL_4636: Unknown result type (might be due to invalid IL or missing references)
		//IL_46d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4776: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		UseIntervalGroup = new DarkGroupBox();
		CBIntermittentEmission_InheritFromGroup = new DarkUICheckBox();
		DarkUICheckBox1 = new DarkUICheckBox();
		CB_IntermittentEmission_USECUSTOM = new DarkUICheckBox();
		EmissionIntervalTABControl = new DarkUITabControl();
		GreenAlert = new TabPage();
		BlueAlert = new TabPage();
		YellowAlert = new TabPage();
		OrangeAlert = new TabPage();
		RedAlert = new TabPage();
		Custom = new TabPage();
		SaveTemplate = new DarkUIButton();
		LoadTemplate = new DarkUIButton();
		IntermittantToggle = new DarkUIButton();
		Label_AEI_3 = new DarkLabel();
		BackToSleepTime = new DarkUITextBox();
		CBWakeWhenDetectingThreat = new DarkUICheckBox();
		Label_AEI_1 = new DarkLabel();
		IntervalVariation = new DarkUITextBox();
		Interval = new DarkUITextBox();
		Label_AEI_2 = new DarkLabel();
		TGV_WRA = new DarkTreeGridView();
		TargetType = new TreeGridColumn();
		WeaponsPerSalvo = new DataGridViewComboBoxColumn();
		ShootersPerSalvo = new DataGridViewComboBoxColumn();
		FiringRange = new DataGridViewComboBoxColumn();
		SelfDefenceRange = new DataGridViewComboBoxColumn();
		TabControl1A = new DarkUITabControl();
		TabPage1 = new TabPage();
		FlowLayoutPanel4 = new FlowLayoutPanel();
		Button_ResetAffectedMissions_Doctrine = new DarkUIButton();
		Button_ResetCurrent_Doctrine = new DarkUIButton();
		Button_ResetAffectedUnits_Doctrine = new DarkUIButton();
		DoctrineControl1 = new DoctrineControl();
		TabPage2 = new TabPage();
		DarkLabel9 = new DarkLabel();
		DefoncLabel2 = new DarkLabel();
		DEBUGINTERMITTENT1 = new DarkLabel();
		EmissionIntervalPhonyTab = new Panel();
		WakeGroupBox = new DarkGroupBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		IncludesIDGroup = new DarkGroupBox();
		CB_IncludesID_Unknown = new CheckBox();
		CB_IncludesID_KnownDomain = new CheckBox();
		CB_IncludesID_KnownID = new CheckBox();
		CB_IncludesID_KnowType = new CheckBox();
		CB_IncludesID_KnownClass = new CheckBox();
		Includes = new DarkGroupBox();
		CB_IncludesStance_Hostile = new CheckBox();
		CB_IncludesStance_Friendly = new CheckBox();
		CB_IncludesStance_Neutral = new CheckBox();
		CB_IncludesStance_Unfriendly = new CheckBox();
		CB_IncludesStance_Unknown = new CheckBox();
		CB_EmconFollowsWRARules = new DarkUICheckBox();
		LabelPlus = new DarkLabel();
		EmissionDurationTextBox = new DarkUITextBox();
		Label_AEI_0 = new DarkLabel();
		Combo_AlertLevel = new DarkUIComboBox();
		Button_ResetAffectedMissions_EMCON = new DarkUIButton();
		Button_ResetAffectedUnits_EMCON = new DarkUIButton();
		Button_ResetCurrent_EMCON = new DarkUIButton();
		CB_EMCON_Sonar = new DarkUIComboBox();
		Label9 = new DarkLabel();
		CB_EMCON_OECM = new DarkUIComboBox();
		Label8 = new DarkLabel();
		CB_EMCON_Inherits = new DarkCheckBox();
		CB_EMCON_Radar = new DarkUIComboBox();
		Label3 = new DarkLabel();
		TabPage3 = new TabPage();
		Button_ResetAffectedMissions_WRA = new DarkUIButton();
		Button_ResetAffectedUnits_WRA = new DarkUIButton();
		Button_ResetCurrent_WRA = new DarkUIButton();
		TabPage4 = new TabPage();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Label43 = new DarkLabel();
		DocUC_WithdrawDamageThreshold = new DoctrineItem_uc();
		DocUC_WithdrawFuelThreshold = new DoctrineItem_uc();
		DocUC_WithdrawAttackThreshold = new DoctrineItem_uc();
		DocUC_WithdrawDefenceThreshold = new DoctrineItem_uc();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		DarkLabel2 = new DarkLabel();
		DocUC_DeplDamageThreshold = new DoctrineItem_uc();
		DocUC_DeplFuelThreshold = new DoctrineItem_uc();
		DocUC_DeplAttackThreshold = new DoctrineItem_uc();
		DocUC_DeplDefenceThreshold = new DoctrineItem_uc();
		TabPage5 = new TabPage();
		Btn_PTLRemove = new DarkUIButton();
		Btn_PTLCreate = new DarkUIButton();
		Label_PTLSource = new DarkLabel();
		DarkLabel13 = new DarkLabel();
		DarkLabel12 = new DarkLabel();
		DarkLabel11 = new DarkLabel();
		DarkLabel10 = new DarkLabel();
		Btn_PTLDelete = new DarkUIButton();
		Btn_PTLAdd = new DarkUIButton();
		Btn_PTLMoveDown = new DarkUIButton();
		Btn_PTLMoveUp = new DarkUIButton();
		List_TargetPriority = new DarkListView();
		((Control)UseIntervalGroup).SuspendLayout();
		((Control)EmissionIntervalTABControl).SuspendLayout();
		((ISupportInitialize)(object)TGV_WRA).BeginInit();
		((Control)TabControl1A).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)FlowLayoutPanel4).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)EmissionIntervalPhonyTab).SuspendLayout();
		((Control)WakeGroupBox).SuspendLayout();
		((Control)IncludesIDGroup).SuspendLayout();
		((Control)Includes).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)TabPage5).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)UseIntervalGroup).Controls.Add((Control)(object)CBIntermittentEmission_InheritFromGroup);
		((Control)UseIntervalGroup).Controls.Add((Control)(object)DarkUICheckBox1);
		((Control)UseIntervalGroup).Controls.Add((Control)(object)CB_IntermittentEmission_USECUSTOM);
		((Control)UseIntervalGroup).Controls.Add((Control)(object)EmissionIntervalTABControl);
		((Control)UseIntervalGroup).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UseIntervalGroup).Location = new Point(12, 152);
		((Control)UseIntervalGroup).Name = "UseIntervalGroup";
		((Control)UseIntervalGroup).Size = new Size(473, 301);
		((Control)UseIntervalGroup).TabIndex = 18;
		((GroupBox)UseIntervalGroup).TabStop = false;
		((GroupBox)UseIntervalGroup).Text = "Active Emission Intervals";
		((ButtonBase)CBIntermittentEmission_InheritFromGroup).BackColor = Color.Transparent;
		((Control)CBIntermittentEmission_InheritFromGroup).Cursor = Cursors.Hand;
		((Control)CBIntermittentEmission_InheritFromGroup).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CBIntermittentEmission_InheritFromGroup).Location = new Point(154, 274);
		((Control)CBIntermittentEmission_InheritFromGroup).Name = "CBIntermittentEmission_InheritFromGroup";
		((Control)CBIntermittentEmission_InheritFromGroup).Size = new Size(186, 18);
		((Control)CBIntermittentEmission_InheritFromGroup).TabIndex = 36;
		((ButtonBase)CBIntermittentEmission_InheritFromGroup).Text = "Use parent group parameters";
		((ButtonBase)DarkUICheckBox1).BackColor = Color.Transparent;
		((Control)DarkUICheckBox1).Cursor = Cursors.Hand;
		((Control)DarkUICheckBox1).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)DarkUICheckBox1).Location = new Point(143, 141);
		((Control)DarkUICheckBox1).Name = "DarkUICheckBox1";
		((Control)DarkUICheckBox1).Size = new Size(186, 18);
		((Control)DarkUICheckBox1).TabIndex = 36;
		((ButtonBase)DarkUICheckBox1).Text = "Use custom preset only";
		((ButtonBase)CB_IntermittentEmission_USECUSTOM).BackColor = Color.Transparent;
		((Control)CB_IntermittentEmission_USECUSTOM).Cursor = Cursors.Hand;
		((Control)CB_IntermittentEmission_USECUSTOM).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_IntermittentEmission_USECUSTOM).Location = new Point(6, 274);
		((Control)CB_IntermittentEmission_USECUSTOM).Name = "CB_IntermittentEmission_USECUSTOM";
		((Control)CB_IntermittentEmission_USECUSTOM).Size = new Size(186, 18);
		((Control)CB_IntermittentEmission_USECUSTOM).TabIndex = 35;
		((ButtonBase)CB_IntermittentEmission_USECUSTOM).Text = "Use custom preset only";
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)GreenAlert);
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)BlueAlert);
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)YellowAlert);
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)OrangeAlert);
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)RedAlert);
		((Control)EmissionIntervalTABControl).Controls.Add((Control)(object)Custom);
		((Control)EmissionIntervalTABControl).Cursor = Cursors.Hand;
		((TabControl)EmissionIntervalTABControl).ItemSize = new Size(80, 20);
		((Control)EmissionIntervalTABControl).Location = new Point(6, 21);
		((Control)EmissionIntervalTABControl).Name = "EmissionIntervalTABControl";
		((TabControl)EmissionIntervalTABControl).SelectedIndex = 0;
		((Control)EmissionIntervalTABControl).Size = new Size(458, 247);
		((Control)EmissionIntervalTABControl).TabIndex = 0;
		GreenAlert.BackColor = Color.FromArgb(60, 63, 65);
		GreenAlert.Location = new Point(4, 24);
		((Control)GreenAlert).Name = "GreenAlert";
		((Control)GreenAlert).Padding = new Padding(3);
		((Control)GreenAlert).Size = new Size(450, 219);
		GreenAlert.TabIndex = 0;
		((Control)GreenAlert).Tag = "Green";
		GreenAlert.Text = "Green";
		BlueAlert.BackColor = Color.FromArgb(60, 63, 65);
		BlueAlert.Location = new Point(4, 24);
		((Control)BlueAlert).Name = "BlueAlert";
		((Control)BlueAlert).Padding = new Padding(3);
		((Control)BlueAlert).Size = new Size(450, 219);
		BlueAlert.TabIndex = 1;
		((Control)BlueAlert).Tag = "Blue";
		BlueAlert.Text = "Blue";
		YellowAlert.BackColor = Color.FromArgb(60, 63, 65);
		YellowAlert.Location = new Point(4, 24);
		((Control)YellowAlert).Name = "YellowAlert";
		((Control)YellowAlert).Size = new Size(450, 219);
		YellowAlert.TabIndex = 2;
		((Control)YellowAlert).Tag = "Yellow";
		YellowAlert.Text = "Yellow";
		OrangeAlert.BackColor = Color.FromArgb(60, 63, 65);
		OrangeAlert.Location = new Point(4, 24);
		((Control)OrangeAlert).Name = "OrangeAlert";
		((Control)OrangeAlert).Size = new Size(450, 219);
		OrangeAlert.TabIndex = 3;
		((Control)OrangeAlert).Tag = "Orange";
		OrangeAlert.Text = "Orange";
		RedAlert.BackColor = Color.FromArgb(60, 63, 65);
		RedAlert.Location = new Point(4, 24);
		((Control)RedAlert).Name = "RedAlert";
		((Control)RedAlert).Size = new Size(450, 219);
		RedAlert.TabIndex = 4;
		((Control)RedAlert).Tag = "Red";
		RedAlert.Text = "Red";
		Custom.BackColor = Color.FromArgb(60, 63, 65);
		Custom.Location = new Point(4, 24);
		((Control)Custom).Name = "Custom";
		((Control)Custom).Size = new Size(450, 219);
		Custom.TabIndex = 5;
		((Control)Custom).Tag = "Custom";
		Custom.Text = "Custom";
		((Control)SaveTemplate).Anchor = (AnchorStyles)10;
		((ButtonBase)SaveTemplate).BackColor = Color.Transparent;
		((Control)SaveTemplate).Font = new Font("Segoe UI", 8.25f);
		((Control)SaveTemplate).ForeColor = SystemColors.Control;
		((Control)SaveTemplate).Location = new Point(856, 3);
		((Control)SaveTemplate).Name = "SaveTemplate";
		((Control)SaveTemplate).Padding = new Padding(5);
		SaveTemplate.RoundRadius = 0;
		((Control)SaveTemplate).Size = new Size(87, 23);
		((Control)SaveTemplate).TabIndex = 9;
		SaveTemplate.Text = "Save Template";
		((Control)LoadTemplate).Anchor = (AnchorStyles)10;
		((ButtonBase)LoadTemplate).BackColor = Color.Transparent;
		((Control)LoadTemplate).Font = new Font("Segoe UI", 8.25f);
		((Control)LoadTemplate).ForeColor = SystemColors.Control;
		((Control)LoadTemplate).Location = new Point(762, 3);
		((Control)LoadTemplate).Name = "LoadTemplate";
		((Control)LoadTemplate).Padding = new Padding(5);
		LoadTemplate.RoundRadius = 0;
		((Control)LoadTemplate).Size = new Size(88, 23);
		((Control)LoadTemplate).TabIndex = 8;
		LoadTemplate.Text = "Load Template";
		((ButtonBase)IntermittantToggle).BackColor = Color.Transparent;
		((Control)IntermittantToggle).ForeColor = SystemColors.Control;
		((Control)IntermittantToggle).Location = new Point(3, 6);
		((Control)IntermittantToggle).Name = "IntermittantToggle";
		((Control)IntermittantToggle).Padding = new Padding(5);
		IntermittantToggle.RoundRadius = 0;
		((Control)IntermittantToggle).Size = new Size(188, 40);
		((Control)IntermittantToggle).TabIndex = 22;
		IntermittantToggle.Text = "INTERMITTENT mode";
		Label_AEI_3.AutoSize = true;
		((Control)Label_AEI_3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AEI_3).Location = new Point(3, 21);
		((Control)Label_AEI_3).Name = "Label_AEI_3";
		((Control)Label_AEI_3).Size = new Size(171, 13);
		((Control)Label_AEI_3).TabIndex = 21;
		((Label)Label_AEI_3).Text = "Time until sleep mode (seconds)";
		BackToSleepTime.AutoCompleteCustomSource = null;
		BackToSleepTime.AutoCompleteMode = (AutoCompleteMode)0;
		BackToSleepTime.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)BackToSleepTime).BackColor = Color.Transparent;
		((Control)BackToSleepTime).ForeColor = Color.FromArgb(189, 189, 189);
		BackToSleepTime.Image = null;
		BackToSleepTime.Lines = null;
		((Control)BackToSleepTime).Location = new Point(6, 37);
		BackToSleepTime.MaxLength = 32767;
		BackToSleepTime.Multiline = false;
		((Control)BackToSleepTime).Name = "BackToSleepTime";
		BackToSleepTime.ReadOnly = false;
		BackToSleepTime.ScrollBars = (ScrollBars)0;
		BackToSleepTime.SelectionStart = 0;
		((Control)BackToSleepTime).Size = new Size(159, 24);
		((Control)BackToSleepTime).TabIndex = 20;
		BackToSleepTime.Text = "5";
		BackToSleepTime.TextAlign = (HorizontalAlignment)2;
		BackToSleepTime.UseSystemPasswordChar = false;
		BackToSleepTime.WatermarkText = "";
		BackToSleepTime.WordWrap = false;
		((ButtonBase)CBWakeWhenDetectingThreat).BackColor = Color.Transparent;
		((Control)CBWakeWhenDetectingThreat).Cursor = Cursors.Hand;
		((Control)CBWakeWhenDetectingThreat).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CBWakeWhenDetectingThreat).Location = new Point(19, 92);
		((Control)CBWakeWhenDetectingThreat).Name = "CBWakeWhenDetectingThreat";
		((Control)CBWakeWhenDetectingThreat).Size = new Size(172, 18);
		((Control)CBWakeWhenDetectingThreat).TabIndex = 19;
		((ButtonBase)CBWakeWhenDetectingThreat).Text = "Wake when detecting threat";
		Label_AEI_1.AutoSize = true;
		((Control)Label_AEI_1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AEI_1).Location = new Point(208, 46);
		((Control)Label_AEI_1).Name = "Label_AEI_1";
		((Control)Label_AEI_1).Size = new Size(191, 13);
		((Control)Label_AEI_1).TabIndex = 18;
		((Label)Label_AEI_1).Text = "Interval Random Variation (seconds)";
		IntervalVariation.AutoCompleteCustomSource = null;
		IntervalVariation.AutoCompleteMode = (AutoCompleteMode)0;
		IntervalVariation.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)IntervalVariation).BackColor = Color.Transparent;
		((Control)IntervalVariation).ForeColor = Color.FromArgb(189, 189, 189);
		IntervalVariation.Image = null;
		IntervalVariation.Lines = null;
		((Control)IntervalVariation).Location = new Point(211, 62);
		IntervalVariation.MaxLength = 32767;
		IntervalVariation.Multiline = false;
		((Control)IntervalVariation).Name = "IntervalVariation";
		IntervalVariation.ReadOnly = false;
		IntervalVariation.ScrollBars = (ScrollBars)0;
		IntervalVariation.SelectionStart = 0;
		((Control)IntervalVariation).Size = new Size(188, 24);
		((Control)IntervalVariation).TabIndex = 16;
		IntervalVariation.Text = "20";
		IntervalVariation.TextAlign = (HorizontalAlignment)2;
		IntervalVariation.UseSystemPasswordChar = false;
		IntervalVariation.WatermarkText = "";
		IntervalVariation.WordWrap = false;
		Interval.AutoCompleteCustomSource = null;
		Interval.AutoCompleteMode = (AutoCompleteMode)0;
		Interval.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Interval).BackColor = Color.Transparent;
		((Control)Interval).ForeColor = Color.FromArgb(189, 189, 189);
		Interval.Image = null;
		Interval.Lines = null;
		((Control)Interval).Location = new Point(3, 62);
		Interval.MaxLength = 32767;
		Interval.Multiline = false;
		((Control)Interval).Name = "Interval";
		Interval.ReadOnly = false;
		Interval.ScrollBars = (ScrollBars)0;
		Interval.SelectionStart = 0;
		((Control)Interval).Size = new Size(188, 24);
		((Control)Interval).TabIndex = 15;
		Interval.Text = "90";
		Interval.TextAlign = (HorizontalAlignment)2;
		Interval.UseSystemPasswordChar = false;
		Interval.WatermarkText = "";
		Interval.WordWrap = false;
		Label_AEI_2.AutoSize = true;
		((Control)Label_AEI_2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AEI_2).Location = new Point(3, 46);
		((Control)Label_AEI_2).Name = "Label_AEI_2";
		((Control)Label_AEI_2).Size = new Size(96, 13);
		((Control)Label_AEI_2).TabIndex = 17;
		((Label)Label_AEI_2).Text = "Interval (seconds)";
		((DataGridView)TGV_WRA).AllowUserToAddRows = false;
		((DataGridView)TGV_WRA).AllowUserToDeleteRows = false;
		((DataGridView)TGV_WRA).AllowUserToOrderColumns = true;
		((Control)TGV_WRA).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_WRA).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_WRA).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_WRA).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_WRA).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_WRA).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_WRA).ColumnHeadersHeight = 34;
		((DataGridView)TGV_WRA).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)TargetType,
			(DataGridViewColumn)WeaponsPerSalvo,
			(DataGridViewColumn)ShootersPerSalvo,
			(DataGridViewColumn)FiringRange,
			(DataGridViewColumn)SelfDefenceRange
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_WRA).DefaultCellStyle = val2;
		((DataGridView)TGV_WRA).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_WRA).EnableHeadersVisualStyles = false;
		TGV_WRA.ImageList = null;
		((Control)TGV_WRA).Location = new Point(0, 0);
		((DataGridView)TGV_WRA).MultiSelect = false;
		((Control)TGV_WRA).Name = "TGV_WRA";
		((DataGridView)TGV_WRA).RowHeadersVisible = false;
		((DataGridView)TGV_WRA).RowHeadersWidth = 20;
		((DataGridView)TGV_WRA).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_WRA.ShowLines = false;
		((Control)TGV_WRA).Size = new Size(192, 43);
		((Control)TGV_WRA).TabIndex = 8;
		((DataGridViewColumn)TargetType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		TargetType.DefaultNodeImage = null;
		((DataGridViewColumn)TargetType).HeaderText = "Weapon Vs. Target Type";
		((DataGridViewColumn)TargetType).MinimumWidth = 8;
		((DataGridViewColumn)TargetType).Name = "TargetType";
		((DataGridViewColumn)TargetType).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)TargetType).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)WeaponsPerSalvo).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		WeaponsPerSalvo.DropDownWidth = 2;
		WeaponsPerSalvo.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)WeaponsPerSalvo).HeaderText = "Weapons per Salvo";
		WeaponsPerSalvo.MaxDropDownItems = 20;
		((DataGridViewColumn)WeaponsPerSalvo).MinimumWidth = 170;
		((DataGridViewColumn)WeaponsPerSalvo).Name = "WeaponsPerSalvo";
		((DataGridViewColumn)WeaponsPerSalvo).Width = 170;
		((DataGridViewColumn)ShootersPerSalvo).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		ShootersPerSalvo.DropDownWidth = 2;
		ShootersPerSalvo.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)ShootersPerSalvo).HeaderText = "Shooters Per Salvo";
		ShootersPerSalvo.MaxDropDownItems = 20;
		((DataGridViewColumn)ShootersPerSalvo).MinimumWidth = 170;
		((DataGridViewColumn)ShootersPerSalvo).Name = "ShootersPerSalvo";
		((DataGridViewColumn)ShootersPerSalvo).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)ShootersPerSalvo).Width = 170;
		((DataGridViewColumn)FiringRange).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		FiringRange.DropDownWidth = 2;
		FiringRange.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)FiringRange).HeaderText = "Automatic Firing Range";
		((DataGridViewColumn)FiringRange).MinimumWidth = 170;
		((DataGridViewColumn)FiringRange).Name = "FiringRange";
		((DataGridViewColumn)FiringRange).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)FiringRange).Width = 170;
		((DataGridViewColumn)SelfDefenceRange).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		SelfDefenceRange.DropDownWidth = 2;
		SelfDefenceRange.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)SelfDefenceRange).HeaderText = "Self Defence";
		SelfDefenceRange.MaxDropDownItems = 20;
		((DataGridViewColumn)SelfDefenceRange).MinimumWidth = 170;
		((DataGridViewColumn)SelfDefenceRange).Name = "SelfDefenceRange";
		((DataGridViewColumn)SelfDefenceRange).Width = 170;
		((Control)TabControl1A).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1A).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1A).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1A).Controls.Add((Control)(object)TabPage4);
		((Control)TabControl1A).Controls.Add((Control)(object)TabPage5);
		((Control)TabControl1A).Cursor = Cursors.Hand;
		((Control)TabControl1A).Dock = (DockStyle)5;
		((Control)TabControl1A).Font = new Font("Segoe UI", 8f);
		((TabControl)TabControl1A).ItemSize = new Size(80, 32);
		((Control)TabControl1A).Location = new Point(0, 0);
		((Control)TabControl1A).Name = "TabControl1A";
		((TabControl)TabControl1A).SelectedIndex = 0;
		((Control)TabControl1A).Size = new Size(984, 701);
		((Control)TabControl1A).TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)FlowLayoutPanel4);
		((Control)TabPage1).Controls.Add((Control)(object)DoctrineControl1);
		TabPage1.Dock = (DockStyle)5;
		TabPage1.Location = new Point(4, 36);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(976, 661);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "General";
		((Control)FlowLayoutPanel4).Anchor = (AnchorStyles)14;
		((Control)FlowLayoutPanel4).Controls.Add((Control)(object)Button_ResetAffectedMissions_Doctrine);
		((Control)FlowLayoutPanel4).Controls.Add((Control)(object)Button_ResetCurrent_Doctrine);
		((Control)FlowLayoutPanel4).Controls.Add((Control)(object)Button_ResetAffectedUnits_Doctrine);
		((Control)FlowLayoutPanel4).Controls.Add((Control)(object)LoadTemplate);
		((Control)FlowLayoutPanel4).Controls.Add((Control)(object)SaveTemplate);
		((Control)FlowLayoutPanel4).Location = new Point(0, 630);
		((Control)FlowLayoutPanel4).Name = "FlowLayoutPanel4";
		((Control)FlowLayoutPanel4).Size = new Size(976, 31);
		((Control)FlowLayoutPanel4).TabIndex = 11;
		((Control)Button_ResetAffectedMissions_Doctrine).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedMissions_Doctrine).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedMissions_Doctrine).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedMissions_Doctrine).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedMissions_Doctrine).Location = new Point(3, 3);
		((Control)Button_ResetAffectedMissions_Doctrine).Name = "Button_ResetAffectedMissions_Doctrine";
		((Control)Button_ResetAffectedMissions_Doctrine).Padding = new Padding(5);
		Button_ResetAffectedMissions_Doctrine.RoundRadius = 0;
		((Control)Button_ResetAffectedMissions_Doctrine).Size = new Size(271, 23);
		((Control)Button_ResetAffectedMissions_Doctrine).TabIndex = 2;
		Button_ResetAffectedMissions_Doctrine.Text = "Reset affected missions (inherit from above Doctrine)";
		((Control)Button_ResetCurrent_Doctrine).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetCurrent_Doctrine).BackColor = Color.Transparent;
		((Control)Button_ResetCurrent_Doctrine).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetCurrent_Doctrine).ForeColor = SystemColors.Control;
		((Control)Button_ResetCurrent_Doctrine).Location = new Point(280, 3);
		((Control)Button_ResetCurrent_Doctrine).Name = "Button_ResetCurrent_Doctrine";
		((Control)Button_ResetCurrent_Doctrine).Padding = new Padding(5);
		Button_ResetCurrent_Doctrine.RoundRadius = 0;
		((Control)Button_ResetCurrent_Doctrine).Size = new Size(215, 23);
		((Control)Button_ResetCurrent_Doctrine).TabIndex = 0;
		Button_ResetCurrent_Doctrine.Text = "Reset Doctrine (use inherited settings)";
		((Control)Button_ResetAffectedUnits_Doctrine).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedUnits_Doctrine).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedUnits_Doctrine).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedUnits_Doctrine).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedUnits_Doctrine).Location = new Point(501, 3);
		((Control)Button_ResetAffectedUnits_Doctrine).Name = "Button_ResetAffectedUnits_Doctrine";
		((Control)Button_ResetAffectedUnits_Doctrine).Padding = new Padding(5);
		Button_ResetAffectedUnits_Doctrine.RoundRadius = 0;
		((Control)Button_ResetAffectedUnits_Doctrine).Size = new Size(255, 23);
		((Control)Button_ResetAffectedUnits_Doctrine).TabIndex = 1;
		Button_ResetAffectedUnits_Doctrine.Text = "Reset affected units (inherit from above Doctrine)";
		((Control)DoctrineControl1).Anchor = (AnchorStyles)15;
		((UserControl)DoctrineControl1).AutoSizeMode = (AutoSizeMode)0;
		((Control)DoctrineControl1).BackColor = Color.FromArgb(60, 63, 65);
		((Control)DoctrineControl1).Location = new Point(0, 0);
		((Control)DoctrineControl1).Margin = new Padding(0);
		((Control)DoctrineControl1).MinimumSize = new Size(829, 559);
		((Control)DoctrineControl1).Name = "DoctrineControl1";
		DoctrineControl1.SelectedUnits = null;
		((Control)DoctrineControl1).Size = new Size(976, 627);
		((Control)DoctrineControl1).TabIndex = 10;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)DarkLabel9);
		((Control)TabPage2).Controls.Add((Control)(object)DefoncLabel2);
		((Control)TabPage2).Controls.Add((Control)(object)DEBUGINTERMITTENT1);
		((Control)TabPage2).Controls.Add((Control)(object)EmissionIntervalPhonyTab);
		((Control)TabPage2).Controls.Add((Control)(object)Combo_AlertLevel);
		((Control)TabPage2).Controls.Add((Control)(object)UseIntervalGroup);
		((Control)TabPage2).Controls.Add((Control)(object)Button_ResetAffectedMissions_EMCON);
		((Control)TabPage2).Controls.Add((Control)(object)Button_ResetAffectedUnits_EMCON);
		((Control)TabPage2).Controls.Add((Control)(object)Button_ResetCurrent_EMCON);
		((Control)TabPage2).Controls.Add((Control)(object)CB_EMCON_Sonar);
		((Control)TabPage2).Controls.Add((Control)(object)Label9);
		((Control)TabPage2).Controls.Add((Control)(object)CB_EMCON_OECM);
		((Control)TabPage2).Controls.Add((Control)(object)Label8);
		((Control)TabPage2).Controls.Add((Control)(object)CB_EMCON_Inherits);
		((Control)TabPage2).Controls.Add((Control)(object)CB_EMCON_Radar);
		((Control)TabPage2).Controls.Add((Control)(object)Label3);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(192, 72);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "EMCON Settings";
		DarkLabel9.AutoSize = true;
		((Control)DarkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel9).Location = new Point(11, 31);
		((Control)DarkLabel9).Name = "DarkLabel9";
		((Control)DarkLabel9).Size = new Size(34, 13);
		((Control)DarkLabel9).TabIndex = 28;
		((Label)DarkLabel9).Text = "Alert:";
		DefoncLabel2.AutoSize = true;
		((Control)DefoncLabel2).ForeColor = Color.IndianRed;
		((Control)DefoncLabel2).Location = new Point(229, 31);
		((Control)DefoncLabel2).Name = "DefoncLabel2";
		((Control)DefoncLabel2).Size = new Size(147, 13);
		((Control)DefoncLabel2).TabIndex = 27;
		((Label)DefoncLabel2).Text = "! Affects the side alertness !";
		DEBUGINTERMITTENT1.AutoSize = true;
		((Control)DEBUGINTERMITTENT1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DEBUGINTERMITTENT1).Location = new Point(15, 471);
		((Control)DEBUGINTERMITTENT1).Name = "DEBUGINTERMITTENT1";
		((Control)DEBUGINTERMITTENT1).Size = new Size(194, 13);
		((Control)DEBUGINTERMITTENT1).TabIndex = 26;
		((Label)DEBUGINTERMITTENT1).Text = "DEBUG INTERVAL TIME REMAINING : ";
		((Control)DEBUGINTERMITTENT1).Visible = false;
		((Control)EmissionIntervalPhonyTab).BackColor = Color.Magenta;
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)CBWakeWhenDetectingThreat);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)WakeGroupBox);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)LabelPlus);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)EmissionDurationTextBox);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)Label_AEI_0);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)IntermittantToggle);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)Label_AEI_2);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)Interval);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)IntervalVariation);
		((Control)EmissionIntervalPhonyTab).Controls.Add((Control)(object)Label_AEI_1);
		((Control)EmissionIntervalPhonyTab).Location = new Point(21, 197);
		((Control)EmissionIntervalPhonyTab).Name = "EmissionIntervalPhonyTab";
		((Control)EmissionIntervalPhonyTab).Size = new Size(450, 218);
		((Control)EmissionIntervalPhonyTab).TabIndex = 19;
		((Control)WakeGroupBox).Controls.Add((Control)(object)DarkLabel5);
		((Control)WakeGroupBox).Controls.Add((Control)(object)DarkLabel7);
		((Control)WakeGroupBox).Controls.Add((Control)(object)DarkLabel6);
		((Control)WakeGroupBox).Controls.Add((Control)(object)IncludesIDGroup);
		((Control)WakeGroupBox).Controls.Add((Control)(object)Includes);
		((Control)WakeGroupBox).Controls.Add((Control)(object)CB_EmconFollowsWRARules);
		((Control)WakeGroupBox).Controls.Add((Control)(object)BackToSleepTime);
		((Control)WakeGroupBox).Controls.Add((Control)(object)Label_AEI_3);
		((Control)WakeGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)WakeGroupBox).Location = new Point(6, 92);
		((Control)WakeGroupBox).Name = "WakeGroupBox";
		((Control)WakeGroupBox).Size = new Size(439, 122);
		((Control)WakeGroupBox).TabIndex = 27;
		((GroupBox)WakeGroupBox).TabStop = false;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(284, 51);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(28, 13);
		((Control)DarkLabel5).TabIndex = 37;
		((Label)DarkLabel5).Text = "And";
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(284, 65);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(29, 13);
		((Control)DarkLabel7).TabIndex = 36;
		((Label)DarkLabel7).Text = "Also";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).Font = new Font("Segoe UI", 8.25f);
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(0, 481);
		((Control)DarkLabel6).Margin = new Padding(0, 6, 0, 0);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(28, 13);
		((Control)DarkLabel6).TabIndex = 35;
		((Label)DarkLabel6).Text = "And";
		((Control)IncludesIDGroup).Controls.Add((Control)(object)CB_IncludesID_Unknown);
		((Control)IncludesIDGroup).Controls.Add((Control)(object)CB_IncludesID_KnownDomain);
		((Control)IncludesIDGroup).Controls.Add((Control)(object)CB_IncludesID_KnownID);
		((Control)IncludesIDGroup).Controls.Add((Control)(object)CB_IncludesID_KnowType);
		((Control)IncludesIDGroup).Controls.Add((Control)(object)CB_IncludesID_KnownClass);
		((Control)IncludesIDGroup).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)IncludesIDGroup).Location = new Point(314, 18);
		((Control)IncludesIDGroup).Name = "IncludesIDGroup";
		((Control)IncludesIDGroup).Size = new Size(119, 98);
		((Control)IncludesIDGroup).TabIndex = 34;
		((GroupBox)IncludesIDGroup).TabStop = false;
		((GroupBox)IncludesIDGroup).Text = "Includes ID";
		((ButtonBase)CB_IncludesID_Unknown).AutoSize = true;
		((Control)CB_IncludesID_Unknown).Location = new Point(7, 16);
		((Control)CB_IncludesID_Unknown).Name = "CB_IncludesID_Unknown";
		((Control)CB_IncludesID_Unknown).Size = new Size(77, 17);
		((Control)CB_IncludesID_Unknown).TabIndex = 28;
		((ButtonBase)CB_IncludesID_Unknown).Text = "Unknown";
		((ButtonBase)CB_IncludesID_Unknown).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesID_KnownDomain).AutoSize = true;
		((Control)CB_IncludesID_KnownDomain).Location = new Point(7, 32);
		((Control)CB_IncludesID_KnownDomain).Name = "CB_IncludesID_KnownDomain";
		((Control)CB_IncludesID_KnownDomain).Size = new Size(105, 17);
		((Control)CB_IncludesID_KnownDomain).TabIndex = 29;
		((ButtonBase)CB_IncludesID_KnownDomain).Text = "Known Domain";
		((ButtonBase)CB_IncludesID_KnownDomain).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesID_KnownID).AutoSize = true;
		((Control)CB_IncludesID_KnownID).Location = new Point(7, 78);
		((Control)CB_IncludesID_KnownID).Name = "CB_IncludesID_KnownID";
		((Control)CB_IncludesID_KnownID).Size = new Size(76, 17);
		((Control)CB_IncludesID_KnownID).TabIndex = 32;
		((ButtonBase)CB_IncludesID_KnownID).Text = "Known ID";
		((ButtonBase)CB_IncludesID_KnownID).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesID_KnowType).AutoSize = true;
		((Control)CB_IncludesID_KnowType).Location = new Point(7, 48);
		((Control)CB_IncludesID_KnowType).Name = "CB_IncludesID_KnowType";
		((Control)CB_IncludesID_KnowType).Size = new Size(88, 17);
		((Control)CB_IncludesID_KnowType).TabIndex = 30;
		((ButtonBase)CB_IncludesID_KnowType).Text = "Known Type";
		((ButtonBase)CB_IncludesID_KnowType).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesID_KnownClass).AutoSize = true;
		((Control)CB_IncludesID_KnownClass).Location = new Point(7, 63);
		((Control)CB_IncludesID_KnownClass).Name = "CB_IncludesID_KnownClass";
		((Control)CB_IncludesID_KnownClass).Size = new Size(91, 17);
		((Control)CB_IncludesID_KnownClass).TabIndex = 31;
		((ButtonBase)CB_IncludesID_KnownClass).Text = "Known Class";
		((ButtonBase)CB_IncludesID_KnownClass).UseVisualStyleBackColor = true;
		((Control)Includes).Controls.Add((Control)(object)CB_IncludesStance_Hostile);
		((Control)Includes).Controls.Add((Control)(object)CB_IncludesStance_Friendly);
		((Control)Includes).Controls.Add((Control)(object)CB_IncludesStance_Neutral);
		((Control)Includes).Controls.Add((Control)(object)CB_IncludesStance_Unfriendly);
		((Control)Includes).Controls.Add((Control)(object)CB_IncludesStance_Unknown);
		((Control)Includes).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Includes).Location = new Point(180, 18);
		((Control)Includes).Name = "Includes";
		((Control)Includes).Size = new Size(102, 98);
		((Control)Includes).TabIndex = 33;
		((GroupBox)Includes).TabStop = false;
		((GroupBox)Includes).Text = "Includes Stance";
		((ButtonBase)CB_IncludesStance_Hostile).AutoSize = true;
		((Control)CB_IncludesStance_Hostile).Location = new Point(6, 62);
		((Control)CB_IncludesStance_Hostile).Name = "CB_IncludesStance_Hostile";
		((Control)CB_IncludesStance_Hostile).Size = new Size(62, 17);
		((Control)CB_IncludesStance_Hostile).TabIndex = 26;
		((ButtonBase)CB_IncludesStance_Hostile).Text = "Hostile";
		((ButtonBase)CB_IncludesStance_Hostile).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesStance_Friendly).AutoSize = true;
		((Control)CB_IncludesStance_Friendly).Location = new Point(6, 15);
		((Control)CB_IncludesStance_Friendly).Name = "CB_IncludesStance_Friendly";
		((Control)CB_IncludesStance_Friendly).Size = new Size(67, 17);
		((Control)CB_IncludesStance_Friendly).TabIndex = 23;
		((ButtonBase)CB_IncludesStance_Friendly).Text = "Friendly";
		((ButtonBase)CB_IncludesStance_Friendly).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesStance_Neutral).AutoSize = true;
		((Control)CB_IncludesStance_Neutral).Location = new Point(6, 31);
		((Control)CB_IncludesStance_Neutral).Name = "CB_IncludesStance_Neutral";
		((Control)CB_IncludesStance_Neutral).Size = new Size(64, 17);
		((Control)CB_IncludesStance_Neutral).TabIndex = 24;
		((ButtonBase)CB_IncludesStance_Neutral).Text = "Neutral";
		((ButtonBase)CB_IncludesStance_Neutral).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesStance_Unfriendly).AutoSize = true;
		((Control)CB_IncludesStance_Unfriendly).Location = new Point(6, 47);
		((Control)CB_IncludesStance_Unfriendly).Name = "CB_IncludesStance_Unfriendly";
		((Control)CB_IncludesStance_Unfriendly).Size = new Size(80, 17);
		((Control)CB_IncludesStance_Unfriendly).TabIndex = 25;
		((ButtonBase)CB_IncludesStance_Unfriendly).Text = "Unfriendly";
		((ButtonBase)CB_IncludesStance_Unfriendly).UseVisualStyleBackColor = true;
		((ButtonBase)CB_IncludesStance_Unknown).AutoSize = true;
		((Control)CB_IncludesStance_Unknown).Location = new Point(6, 77);
		((Control)CB_IncludesStance_Unknown).Name = "CB_IncludesStance_Unknown";
		((Control)CB_IncludesStance_Unknown).Size = new Size(77, 17);
		((Control)CB_IncludesStance_Unknown).TabIndex = 27;
		((ButtonBase)CB_IncludesStance_Unknown).Text = "Unknown";
		((ButtonBase)CB_IncludesStance_Unknown).UseVisualStyleBackColor = true;
		((ButtonBase)CB_EmconFollowsWRARules).BackColor = Color.Transparent;
		((Control)CB_EmconFollowsWRARules).Cursor = Cursors.Hand;
		((Control)CB_EmconFollowsWRARules).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_EmconFollowsWRARules).Location = new Point(6, 67);
		((Control)CB_EmconFollowsWRARules).Name = "CB_EmconFollowsWRARules";
		((Control)CB_EmconFollowsWRARules).Size = new Size(171, 18);
		((Control)CB_EmconFollowsWRARules).TabIndex = 22;
		((ButtonBase)CB_EmconFollowsWRARules).Text = "Follow WRA rules";
		((Control)CB_EmconFollowsWRARules).Visible = false;
		LabelPlus.AutoSize = true;
		((Control)LabelPlus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelPlus).Location = new Point(193, 66);
		((Control)LabelPlus).Name = "LabelPlus";
		((Control)LabelPlus).Size = new Size(15, 13);
		((Control)LabelPlus).TabIndex = 26;
		((Label)LabelPlus).Text = "+";
		EmissionDurationTextBox.AutoCompleteCustomSource = null;
		EmissionDurationTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		EmissionDurationTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)EmissionDurationTextBox).BackColor = Color.Transparent;
		((Control)EmissionDurationTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		EmissionDurationTextBox.Image = null;
		EmissionDurationTextBox.Lines = null;
		((Control)EmissionDurationTextBox).Location = new Point(211, 22);
		EmissionDurationTextBox.MaxLength = 32767;
		EmissionDurationTextBox.Multiline = false;
		((Control)EmissionDurationTextBox).Name = "EmissionDurationTextBox";
		EmissionDurationTextBox.ReadOnly = false;
		EmissionDurationTextBox.ScrollBars = (ScrollBars)0;
		EmissionDurationTextBox.SelectionStart = 0;
		((Control)EmissionDurationTextBox).Size = new Size(188, 24);
		((Control)EmissionDurationTextBox).TabIndex = 25;
		EmissionDurationTextBox.Text = "20";
		EmissionDurationTextBox.TextAlign = (HorizontalAlignment)2;
		EmissionDurationTextBox.UseSystemPasswordChar = false;
		EmissionDurationTextBox.WatermarkText = "";
		EmissionDurationTextBox.WordWrap = false;
		Label_AEI_0.AutoSize = true;
		((Control)Label_AEI_0).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AEI_0).Location = new Point(208, 6);
		((Control)Label_AEI_0).Name = "Label_AEI_0";
		((Control)Label_AEI_0).Size = new Size(158, 13);
		((Control)Label_AEI_0).TabIndex = 24;
		((Label)Label_AEI_0).Text = "Emission Duration (seconds) :";
		((ComboBox)Combo_AlertLevel).BackColor = Color.Transparent;
		((ComboBox)Combo_AlertLevel).DrawMode = (DrawMode)1;
		((ComboBox)Combo_AlertLevel).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_AlertLevel).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_AlertLevel).FormattingEnabled = true;
		((ComboBox)Combo_AlertLevel).Items.AddRange(new object[5] { "Green", "Blue", "Yellow", "Orange", "Red" });
		((Control)Combo_AlertLevel).Location = new Point(75, 29);
		((Control)Combo_AlertLevel).Name = "Combo_AlertLevel";
		((Control)Combo_AlertLevel).Size = new Size(146, 21);
		((Control)Combo_AlertLevel).TabIndex = 24;
		((Control)Button_ResetAffectedMissions_EMCON).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedMissions_EMCON).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedMissions_EMCON).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedMissions_EMCON).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedMissions_EMCON).Location = new Point(531, 52);
		((Control)Button_ResetAffectedMissions_EMCON).Name = "Button_ResetAffectedMissions_EMCON";
		((Control)Button_ResetAffectedMissions_EMCON).Padding = new Padding(5);
		Button_ResetAffectedMissions_EMCON.RoundRadius = 0;
		((Control)Button_ResetAffectedMissions_EMCON).Size = new Size(272, 23);
		((Control)Button_ResetAffectedMissions_EMCON).TabIndex = 14;
		Button_ResetAffectedMissions_EMCON.Text = "Reset affected missions (inherit from above EMCON)";
		((Control)Button_ResetAffectedUnits_EMCON).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedUnits_EMCON).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedUnits_EMCON).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedUnits_EMCON).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedUnits_EMCON).Location = new Point(265, 52);
		((Control)Button_ResetAffectedUnits_EMCON).Name = "Button_ResetAffectedUnits_EMCON";
		((Control)Button_ResetAffectedUnits_EMCON).Padding = new Padding(5);
		Button_ResetAffectedUnits_EMCON.RoundRadius = 0;
		((Control)Button_ResetAffectedUnits_EMCON).Size = new Size(265, 23);
		((Control)Button_ResetAffectedUnits_EMCON).TabIndex = 13;
		Button_ResetAffectedUnits_EMCON.Text = "Reset affected units (inherit from above EMCON)";
		((Control)Button_ResetCurrent_EMCON).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetCurrent_EMCON).BackColor = Color.Transparent;
		((Control)Button_ResetCurrent_EMCON).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetCurrent_EMCON).ForeColor = SystemColors.Control;
		((Control)Button_ResetCurrent_EMCON).Location = new Point(-1, 52);
		((Control)Button_ResetCurrent_EMCON).Name = "Button_ResetCurrent_EMCON";
		((Control)Button_ResetCurrent_EMCON).Padding = new Padding(5);
		Button_ResetCurrent_EMCON.RoundRadius = 0;
		((Control)Button_ResetCurrent_EMCON).Size = new Size(265, 23);
		((Control)Button_ResetCurrent_EMCON).TabIndex = 12;
		Button_ResetCurrent_EMCON.Text = "Reset EMCON (use inherited settings)";
		((ComboBox)CB_EMCON_Sonar).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_Sonar).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_Sonar).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_Sonar).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_EMCON_Sonar).FormattingEnabled = true;
		((Control)CB_EMCON_Sonar).Location = new Point(75, 86);
		((Control)CB_EMCON_Sonar).Name = "CB_EMCON_Sonar";
		((Control)CB_EMCON_Sonar).Size = new Size(146, 21);
		((Control)CB_EMCON_Sonar).TabIndex = 6;
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(11, 86);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(40, 13);
		((Control)Label9).TabIndex = 5;
		((Label)Label9).Text = "Sonar:";
		((ComboBox)CB_EMCON_OECM).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_OECM).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_OECM).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_OECM).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_EMCON_OECM).FormattingEnabled = true;
		((Control)CB_EMCON_OECM).Location = new Point(75, 112);
		((Control)CB_EMCON_OECM).Name = "CB_EMCON_OECM";
		((Control)CB_EMCON_OECM).Size = new Size(146, 21);
		((Control)CB_EMCON_OECM).TabIndex = 4;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(11, 114);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(42, 13);
		((Control)Label8).TabIndex = 3;
		((Label)Label8).Text = "OECM:";
		((Control)CB_EMCON_Inherits).Location = new Point(12, 6);
		((Control)CB_EMCON_Inherits).Name = "CB_EMCON_Inherits";
		((Control)CB_EMCON_Inherits).Size = new Size(111, 17);
		((Control)CB_EMCON_Inherits).TabIndex = 2;
		((ButtonBase)CB_EMCON_Inherits).Text = "Inherit from parent";
		((ComboBox)CB_EMCON_Radar).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_Radar).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_Radar).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_Radar).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_EMCON_Radar).FormattingEnabled = true;
		((Control)CB_EMCON_Radar).Location = new Point(75, 56);
		((Control)CB_EMCON_Radar).Name = "CB_EMCON_Radar";
		((Control)CB_EMCON_Radar).Size = new Size(146, 21);
		((Control)CB_EMCON_Radar).TabIndex = 1;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(11, 58);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(40, 13);
		((Control)Label3).TabIndex = 0;
		((Label)Label3).Text = "Radar:";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)Button_ResetAffectedMissions_WRA);
		((Control)TabPage3).Controls.Add((Control)(object)Button_ResetAffectedUnits_WRA);
		((Control)TabPage3).Controls.Add((Control)(object)Button_ResetCurrent_WRA);
		((Control)TabPage3).Controls.Add((Control)(object)TGV_WRA);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(192, 72);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Weapon Release Authorization (WRA)";
		((Control)Button_ResetAffectedMissions_WRA).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedMissions_WRA).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedMissions_WRA).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedMissions_WRA).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedMissions_WRA).Location = new Point(542, 49);
		((Control)Button_ResetAffectedMissions_WRA).Name = "Button_ResetAffectedMissions_WRA";
		((Control)Button_ResetAffectedMissions_WRA).Padding = new Padding(5);
		Button_ResetAffectedMissions_WRA.RoundRadius = 0;
		((Control)Button_ResetAffectedMissions_WRA).Size = new Size(265, 23);
		((Control)Button_ResetAffectedMissions_WRA).TabIndex = 11;
		Button_ResetAffectedMissions_WRA.Text = "Reset affected missions (inherit from above WRA)";
		((Control)Button_ResetAffectedUnits_WRA).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetAffectedUnits_WRA).BackColor = Color.Transparent;
		((Control)Button_ResetAffectedUnits_WRA).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetAffectedUnits_WRA).ForeColor = SystemColors.Control;
		((Control)Button_ResetAffectedUnits_WRA).Location = new Point(271, 49);
		((Control)Button_ResetAffectedUnits_WRA).Name = "Button_ResetAffectedUnits_WRA";
		((Control)Button_ResetAffectedUnits_WRA).Padding = new Padding(5);
		Button_ResetAffectedUnits_WRA.RoundRadius = 0;
		((Control)Button_ResetAffectedUnits_WRA).Size = new Size(265, 23);
		((Control)Button_ResetAffectedUnits_WRA).TabIndex = 10;
		Button_ResetAffectedUnits_WRA.Text = "Reset affected units (inherit from above WRA)";
		((Control)Button_ResetCurrent_WRA).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ResetCurrent_WRA).BackColor = Color.Transparent;
		((Control)Button_ResetCurrent_WRA).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetCurrent_WRA).ForeColor = SystemColors.Control;
		((Control)Button_ResetCurrent_WRA).Location = new Point(0, 49);
		((Control)Button_ResetCurrent_WRA).Name = "Button_ResetCurrent_WRA";
		((Control)Button_ResetCurrent_WRA).Padding = new Padding(5);
		Button_ResetCurrent_WRA.RoundRadius = 0;
		((Control)Button_ResetCurrent_WRA).Size = new Size(265, 23);
		((Control)Button_ResetCurrent_WRA).TabIndex = 9;
		Button_ResetCurrent_WRA.Text = "Reset WRA (use inherited settings)";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)FlowLayoutPanel3);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Size = new Size(192, 72);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Withdraw & Redeploy (Ships / Subs / Land)";
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)FlowLayoutPanel3).Location = new Point(3, 3);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(395, 315);
		((Control)FlowLayoutPanel3).TabIndex = 21;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label43);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DocUC_WithdrawDamageThreshold);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DocUC_WithdrawFuelThreshold);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DocUC_WithdrawAttackThreshold);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DocUC_WithdrawDefenceThreshold);
		((Control)FlowLayoutPanel1).Location = new Point(3, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(377, 144);
		((Control)FlowLayoutPanel1).TabIndex = 19;
		Label43.AutoSize = true;
		((Control)Label43).Font = new Font("Segoe UI", 16f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label43).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label43).Location = new Point(3, 0);
		((Control)Label43).Name = "Label43";
		((Control)Label43).Size = new Size(184, 30);
		((Control)Label43).TabIndex = 4;
		((Label)Label43).Text = "Withdraw when....";
		((Control)DocUC_WithdrawDamageThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_WithdrawDamageThreshold).Location = new Point(0, 30);
		((Control)DocUC_WithdrawDamageThreshold).Margin = new Padding(0);
		((Control)DocUC_WithdrawDamageThreshold).Name = "DocUC_WithdrawDamageThreshold";
		((Control)DocUC_WithdrawDamageThreshold).Size = new Size(360, 28);
		((Control)DocUC_WithdrawDamageThreshold).TabIndex = 18;
		((Control)DocUC_WithdrawFuelThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_WithdrawFuelThreshold).Location = new Point(0, 58);
		((Control)DocUC_WithdrawFuelThreshold).Margin = new Padding(0);
		((Control)DocUC_WithdrawFuelThreshold).Name = "DocUC_WithdrawFuelThreshold";
		((Control)DocUC_WithdrawFuelThreshold).Size = new Size(360, 28);
		((Control)DocUC_WithdrawFuelThreshold).TabIndex = 19;
		((Control)DocUC_WithdrawAttackThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_WithdrawAttackThreshold).Location = new Point(0, 86);
		((Control)DocUC_WithdrawAttackThreshold).Margin = new Padding(0);
		((Control)DocUC_WithdrawAttackThreshold).Name = "DocUC_WithdrawAttackThreshold";
		((Control)DocUC_WithdrawAttackThreshold).Size = new Size(360, 28);
		((Control)DocUC_WithdrawAttackThreshold).TabIndex = 20;
		((Control)DocUC_WithdrawDefenceThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_WithdrawDefenceThreshold).Location = new Point(0, 114);
		((Control)DocUC_WithdrawDefenceThreshold).Margin = new Padding(0);
		((Control)DocUC_WithdrawDefenceThreshold).Name = "DocUC_WithdrawDefenceThreshold";
		((Control)DocUC_WithdrawDefenceThreshold).Size = new Size(360, 28);
		((Control)DocUC_WithdrawDefenceThreshold).TabIndex = 21;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkLabel2);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DocUC_DeplDamageThreshold);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DocUC_DeplFuelThreshold);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DocUC_DeplAttackThreshold);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DocUC_DeplDefenceThreshold);
		((Control)FlowLayoutPanel2).Location = new Point(3, 153);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(377, 146);
		((Control)FlowLayoutPanel2).TabIndex = 20;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).Font = new Font("Segoe UI", 16f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(3, 0);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(182, 30);
		((Control)DarkLabel2).TabIndex = 22;
		((Label)DarkLabel2).Text = "Redeploy when....";
		((Control)DocUC_DeplDamageThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_DeplDamageThreshold).Location = new Point(0, 30);
		((Control)DocUC_DeplDamageThreshold).Margin = new Padding(0);
		((Control)DocUC_DeplDamageThreshold).Name = "DocUC_DeplDamageThreshold";
		((Control)DocUC_DeplDamageThreshold).Size = new Size(360, 28);
		((Control)DocUC_DeplDamageThreshold).TabIndex = 18;
		((Control)DocUC_DeplFuelThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_DeplFuelThreshold).Location = new Point(0, 58);
		((Control)DocUC_DeplFuelThreshold).Margin = new Padding(0);
		((Control)DocUC_DeplFuelThreshold).Name = "DocUC_DeplFuelThreshold";
		((Control)DocUC_DeplFuelThreshold).Size = new Size(360, 28);
		((Control)DocUC_DeplFuelThreshold).TabIndex = 19;
		((Control)DocUC_DeplAttackThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_DeplAttackThreshold).Location = new Point(0, 86);
		((Control)DocUC_DeplAttackThreshold).Margin = new Padding(0);
		((Control)DocUC_DeplAttackThreshold).Name = "DocUC_DeplAttackThreshold";
		((Control)DocUC_DeplAttackThreshold).Size = new Size(360, 28);
		((Control)DocUC_DeplAttackThreshold).TabIndex = 20;
		((Control)DocUC_DeplDefenceThreshold).BackColor = Color.FromArgb(60, 60, 60);
		((Control)DocUC_DeplDefenceThreshold).Location = new Point(0, 114);
		((Control)DocUC_DeplDefenceThreshold).Margin = new Padding(0);
		((Control)DocUC_DeplDefenceThreshold).Name = "DocUC_DeplDefenceThreshold";
		((Control)DocUC_DeplDefenceThreshold).Size = new Size(360, 28);
		((Control)DocUC_DeplDefenceThreshold).TabIndex = 21;
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLRemove);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLCreate);
		((Control)TabPage5).Controls.Add((Control)(object)Label_PTLSource);
		((Control)TabPage5).Controls.Add((Control)(object)DarkLabel13);
		((Control)TabPage5).Controls.Add((Control)(object)DarkLabel12);
		((Control)TabPage5).Controls.Add((Control)(object)DarkLabel11);
		((Control)TabPage5).Controls.Add((Control)(object)DarkLabel10);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLDelete);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLAdd);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLMoveDown);
		((Control)TabPage5).Controls.Add((Control)(object)Btn_PTLMoveUp);
		((Control)TabPage5).Controls.Add((Control)(object)List_TargetPriority);
		TabPage5.Location = new Point(4, 24);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Size = new Size(192, 72);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "Targeting Priority";
		((Control)Btn_PTLRemove).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLRemove).BackColor = Color.Transparent;
		((Control)Btn_PTLRemove).ForeColor = Color.Red;
		((Control)Btn_PTLRemove).Location = new Point(92, 31);
		((Control)Btn_PTLRemove).Name = "Btn_PTLRemove";
		((Control)Btn_PTLRemove).Padding = new Padding(5);
		Btn_PTLRemove.RoundRadius = 0;
		((Control)Btn_PTLRemove).Size = new Size(75, 23);
		((Control)Btn_PTLRemove).TabIndex = 11;
		Btn_PTLRemove.Text = "Remove ";
		((Control)Btn_PTLCreate).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLCreate).BackColor = Color.Transparent;
		((Control)Btn_PTLCreate).ForeColor = SystemColors.Control;
		((Control)Btn_PTLCreate).Location = new Point(11, 31);
		((Control)Btn_PTLCreate).Name = "Btn_PTLCreate";
		((Control)Btn_PTLCreate).Padding = new Padding(5);
		Btn_PTLCreate.RoundRadius = 0;
		((Control)Btn_PTLCreate).Size = new Size(75, 23);
		((Control)Btn_PTLCreate).TabIndex = 10;
		Btn_PTLCreate.Text = "Create";
		((Control)Label_PTLSource).Anchor = (AnchorStyles)6;
		Label_PTLSource.AutoSize = true;
		((Control)Label_PTLSource).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_PTLSource).Location = new Point(8, 584);
		((Control)Label_PTLSource).Name = "Label_PTLSource";
		((Control)Label_PTLSource).Size = new Size(133, 13);
		((Control)Label_PTLSource).TabIndex = 9;
		((Label)Label_PTLSource).Text = "Inherited From Doctrine:";
		((Control)DarkLabel13).Anchor = (AnchorStyles)13;
		DarkLabel13.AutoSize = true;
		((Control)DarkLabel13).Font = new Font("Segoe UI", 9.25f, (FontStyle)1);
		((Control)DarkLabel13).ForeColor = Color.FromArgb(220, 220, 220);
		((Label)DarkLabel13).ImageAlign = (ContentAlignment)512;
		((Control)DarkLabel13).Location = new Point(822, 8);
		((Control)DarkLabel13).Name = "DarkLabel13";
		((Control)DarkLabel13).Size = new Size(133, 17);
		((Control)DarkLabel13).TabIndex = 8;
		((Label)DarkLabel13).Text = "Engagement Timing";
		((Control)DarkLabel12).Anchor = (AnchorStyles)13;
		DarkLabel12.AutoSize = true;
		((Control)DarkLabel12).Font = new Font("Segoe UI", 9.25f, (FontStyle)1);
		((Control)DarkLabel12).ForeColor = Color.FromArgb(220, 220, 220);
		((Label)DarkLabel12).ImageAlign = (ContentAlignment)512;
		((Control)DarkLabel12).Location = new Point(418, 8);
		((Control)DarkLabel12).Name = "DarkLabel12";
		((Control)DarkLabel12).Size = new Size(69, 17);
		((Control)DarkLabel12).TabIndex = 7;
		((Label)DarkLabel12).Text = "Unit Class";
		((Control)DarkLabel11).Anchor = (AnchorStyles)13;
		DarkLabel11.AutoSize = true;
		((Control)DarkLabel11).Font = new Font("Segoe UI", 9.25f, (FontStyle)1);
		((Control)DarkLabel11).ForeColor = Color.FromArgb(220, 220, 220);
		((Label)DarkLabel11).ImageAlign = (ContentAlignment)512;
		((Control)DarkLabel11).Location = new Point(204, 8);
		((Control)DarkLabel11).Name = "DarkLabel11";
		((Control)DarkLabel11).Size = new Size(88, 17);
		((Control)DarkLabel11).TabIndex = 6;
		((Label)DarkLabel11).Text = "Unit Subtype";
		((Control)DarkLabel10).Anchor = (AnchorStyles)13;
		DarkLabel10.AutoSize = true;
		((Control)DarkLabel10).Font = new Font("Segoe UI", 9.25f, (FontStyle)1);
		((Control)DarkLabel10).ForeColor = Color.FromArgb(220, 220, 220);
		((Label)DarkLabel10).ImageAlign = (ContentAlignment)512;
		((Control)DarkLabel10).Location = new Point(44, 8);
		((Control)DarkLabel10).Name = "DarkLabel10";
		((Control)DarkLabel10).Size = new Size(67, 17);
		((Control)DarkLabel10).TabIndex = 5;
		((Label)DarkLabel10).Text = "Unit Type";
		((Control)Btn_PTLDelete).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLDelete).BackColor = Color.Transparent;
		((Control)Btn_PTLDelete).ForeColor = SystemColors.Control;
		((Control)Btn_PTLDelete).Location = new Point(620, 31);
		((Control)Btn_PTLDelete).Name = "Btn_PTLDelete";
		((Control)Btn_PTLDelete).Padding = new Padding(5);
		Btn_PTLDelete.RoundRadius = 0;
		((Control)Btn_PTLDelete).Size = new Size(75, 23);
		((Control)Btn_PTLDelete).TabIndex = 4;
		Btn_PTLDelete.Text = "Delete Item";
		((Control)Btn_PTLAdd).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLAdd).BackColor = Color.Transparent;
		((Control)Btn_PTLAdd).ForeColor = SystemColors.Control;
		((Control)Btn_PTLAdd).Location = new Point(539, 31);
		((Control)Btn_PTLAdd).Name = "Btn_PTLAdd";
		((Control)Btn_PTLAdd).Padding = new Padding(5);
		Btn_PTLAdd.RoundRadius = 0;
		((Control)Btn_PTLAdd).Size = new Size(75, 23);
		((Control)Btn_PTLAdd).TabIndex = 3;
		Btn_PTLAdd.Text = "Add Item";
		((Control)Btn_PTLMoveDown).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLMoveDown).BackColor = Color.Transparent;
		((Control)Btn_PTLMoveDown).ForeColor = SystemColors.Control;
		((Control)Btn_PTLMoveDown).Location = new Point(413, 31);
		((Control)Btn_PTLMoveDown).Name = "Btn_PTLMoveDown";
		((Control)Btn_PTLMoveDown).Padding = new Padding(5);
		Btn_PTLMoveDown.RoundRadius = 0;
		((Control)Btn_PTLMoveDown).Size = new Size(75, 23);
		((Control)Btn_PTLMoveDown).TabIndex = 2;
		Btn_PTLMoveDown.Text = "Move Down";
		((Control)Btn_PTLMoveUp).Anchor = (AnchorStyles)6;
		((ButtonBase)Btn_PTLMoveUp).BackColor = Color.Transparent;
		((Control)Btn_PTLMoveUp).ForeColor = SystemColors.Control;
		((Control)Btn_PTLMoveUp).Location = new Point(332, 31);
		((Control)Btn_PTLMoveUp).Name = "Btn_PTLMoveUp";
		((Control)Btn_PTLMoveUp).Padding = new Padding(5);
		Btn_PTLMoveUp.RoundRadius = 0;
		((Control)Btn_PTLMoveUp).Size = new Size(75, 23);
		((Control)Btn_PTLMoveUp).TabIndex = 1;
		Btn_PTLMoveUp.Text = "Move Up";
		((Control)List_TargetPriority).Anchor = (AnchorStyles)15;
		((Control)List_TargetPriority).Location = new Point(3, 28);
		((Control)List_TargetPriority).Name = "List_TargetPriority";
		List_TargetPriority.RelatedInfos = null;
		((Control)List_TargetPriority).Size = new Size(188, 0);
		((Control)List_TargetPriority).TabIndex = 0;
		((Control)List_TargetPriority).Text = "DarkListView1";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(984, 701);
		((Control)this).Controls.Add((Control)(object)TabControl1A);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(1000, 740);
		((Control)this).Name = "DoctrineForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "DoctrineForm";
		((Control)UseIntervalGroup).ResumeLayout(false);
		((Control)EmissionIntervalTABControl).ResumeLayout(false);
		((ISupportInitialize)(object)TGV_WRA).EndInit();
		((Control)TabControl1A).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)FlowLayoutPanel4).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
		((Control)EmissionIntervalPhonyTab).ResumeLayout(false);
		((Control)EmissionIntervalPhonyTab).PerformLayout();
		((Control)WakeGroupBox).ResumeLayout(false);
		((Control)WakeGroupBox).PerformLayout();
		((Control)IncludesIDGroup).ResumeLayout(false);
		((Control)IncludesIDGroup).PerformLayout();
		((Control)Includes).ResumeLayout(false);
		((Control)Includes).PerformLayout();
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage4).ResumeLayout(false);
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)FlowLayoutPanel2).PerformLayout();
		((Control)TabPage5).ResumeLayout(false);
		((Control)TabPage5).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void Show(string[] argsArray)
	{
		DoctrineForm doctrineForm = new DoctrineForm();
		doctrineForm.Subject = Misc.GetActiveUnitByNameOrID(argsArray[0], Client.CurrentScenario);
		if (argsArray.Length <= 1)
		{
			((TabControl)doctrineForm.TabControl1A).SelectedIndex = 0;
		}
		else
		{
			((TabControl)doctrineForm.TabControl1A).SelectedIndex = Conversions.ToInteger(argsArray[1]);
		}
		doctrineForm.Refreshinfo();
		((Control)doctrineForm).Show();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			Subject = null;
			SelectedUnits = null;
			doctrine_0 = null;
			dictionary_0 = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (((ContainerControl)this).ParentForm == null)
		{
			Keys[] array = keys_0;
			foreach (Keys val in array)
			{
				if (keyData == val)
				{
					int result;
					if (((Control)this).Visible)
					{
						((Form)this).Close();
						result = 1;
					}
					else
					{
						result = 1;
					}
					return (byte)result != 0;
				}
			}
			return false;
		}
		bool result2 = default(bool);
		return result2;
	}

	private void method_2(ScenarioObject scenarioObject_1, bool? nullable_0, bool bool_7, bool bool_8, bool bool_9, bool bool_10)
	{
		try
		{
			if (bool_4 && RealtimeTerminal.ActiveDeserializationCount > 0)
			{
				return;
			}
			if (bool_8)
			{
				if (bool_4 && RealtimeTerminal.ActiveDeserializationCount == 0)
				{
					Client.RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine_0, null);
				}
			}
			else if (!bool_10 && !Information.IsNothing((object)scenarioObject_1))
			{
				if (bool_4 && !scenarioObject_1.IsActiveUnit)
				{
					RefreshForm();
				}
				if (scenarioObject_1.IsActiveUnit && ((ActiveUnit)scenarioObject_1).IsOperating() && (!bool_7 || scenarioObject_1 == Client.SelectedUnit) && !Information.IsNothing((object)nullable_0) && ((Control)this).Visible && (scenarioObject_1 == Subject || Information.IsNothing((object)Subject)) && ((TabControl)TabControl1A).SelectedIndex == 0)
				{
					Refreshinfo();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 999999", "");
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(ScenarioObject scenarioObject_1, bool? nullable_0, bool bool_7, bool bool_8, bool bool_9, bool bool_10)
	{
		try
		{
			if (!bool_8)
			{
				if (!bool_10 && !Information.IsNothing((object)scenarioObject_1) && scenarioObject_1.IsActiveUnit && (!bool_7 || scenarioObject_1 == Client.SelectedUnit) && bool_3 && !Information.IsNothing((object)nullable_0) && ((Control)this).Visible && (scenarioObject_1 == Subject || Information.IsNothing((object)Subject)) && ((TabControl)TabControl1A).SelectedIndex == 1)
				{
					Refreshinfo();
				}
			}
			else if (bool_4 && RealtimeTerminal.ActiveDeserializationCount == 0)
			{
				Client.RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine_0, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 999999", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DoctrineForm_Load(object sender, EventArgs e)
	{
		Doctrine.DoctrineChanged += method_2;
		Doctrine.EmconChanged += method_3;
		Interval.TextChanged += method_52;
		IntervalVariation.TextChanged += method_52;
		BackToSleepTime.TextChanged += method_52;
		EmissionDurationTextBox.TextChanged += method_52;
		bool_4 = Client.Realtime;
		((TabControl)TabControl1A).SizeMode = (TabSizeMode)0;
		method_5();
	}

	private void method_4()
	{
		List<ActiveUnit> selectedUnits = SelectedUnits;
		if (selectedUnits != null && selectedUnits.Count > 0)
		{
			if (!isAirOps)
			{
				if (!isBoatOps)
				{
					((Form)this).Text = "Doctrine & ROE for multiple units";
				}
				else
				{
					((Form)this).Text = "Doctrine & ROE for boats in dock / davit";
				}
			}
			else
			{
				((Form)this).Text = "Doctrine & ROE for aircraft on ground";
			}
			doctrine_0 = DoctrineControl1.GetDoctrine_MultipleUnit(SelectedUnits);
			return;
		}
		if ((object)Subject?.GetType() == typeof(Side))
		{
			((Form)this).Text = "Doctrine & ROE for side: " + ((Side)Subject).Name;
			doctrine_0 = ((Side)Subject).Doctrine;
		}
		else
		{
			ScenarioObject subject = Subject;
			if (subject != null && subject.IsMission)
			{
				if (!isEscorts)
				{
					((Form)this).Text = "Doctrine & ROE for mission: " + ((Mission)Subject).Name;
					doctrine_0 = ((Mission)Subject).Doctrine;
				}
				else
				{
					((Form)this).Text = "Doctrine & ROE for mission escorts: " + ((Mission)Subject).Name;
					doctrine_0 = ((Strike)Subject).Doctrine_Escorts;
				}
			}
			else if ((object)Subject?.GetType() == typeof(Group))
			{
				((Form)this).Text = "Doctrine & ROE for group: " + ((Group)Subject).Name;
				doctrine_0 = ((Group)Subject).Doctrine;
			}
			else if ((object)Subject?.GetType() == typeof(Waypoint))
			{
				string text = ((Waypoint)Subject).Name;
				if (string.IsNullOrEmpty(text))
				{
					text = "Not named";
				}
				((Form)this).Text = "Doctrine & ROE for waypoint: " + text + " (Type: " + Waypoint.get_WaypointTypeString(((Waypoint)Subject).Type) + ")";
				doctrine_0 = ((Waypoint)Subject).GetDoctrine(Client.CurrentScenario);
			}
			else
			{
				ScenarioObject subject2 = Subject;
				if (subject2 != null && subject2.IsActiveUnit)
				{
					((Form)this).Text = "Doctrine & ROE for unit: " + ((ActiveUnit)Subject).Name;
					ActiveUnit activeUnit = (ActiveUnit)Subject;
					doctrine_0 = activeUnit.Doctrine;
				}
			}
		}
		if (doctrine_0 != null)
		{
			doctrine_0.ClearCachedParentDoctrine();
		}
		if (Subject != null && bool_4)
		{
			Client.RealtimeTerminal.OnDoctrineSelected(Subject);
		}
	}

	private void method_5()
	{
		float[] tabStops = new float[4]
		{
			((Control)DarkLabel10).Left - ((Control)List_TargetPriority).Left,
			((Control)DarkLabel11).Left - ((Control)DarkLabel10).Left,
			((Control)DarkLabel12).Left - ((Control)DarkLabel11).Left,
			((Control)DarkLabel13).Left - ((Control)DarkLabel12).Left
		};
		List_TargetPriority.tabStops = tabStops;
	}

	private void method_6()
	{
		try
		{
			method_37();
			if (!Information.IsNothing((object)Subject))
			{
				if ((object)Subject.GetType() == typeof(Side))
				{
					Button_ResetCurrent_Doctrine.Enabled = false;
					Button_ResetAffectedUnits_Doctrine.Enabled = true;
					Button_ResetAffectedMissions_Doctrine.Enabled = true;
				}
				else if (!Subject.IsMission)
				{
					if ((object)Subject.GetType() == typeof(Group))
					{
						Button_ResetCurrent_Doctrine.Enabled = true;
						Button_ResetAffectedUnits_Doctrine.Enabled = true;
						Button_ResetAffectedMissions_Doctrine.Enabled = false;
					}
					else if ((object)Subject.GetType() == typeof(Waypoint))
					{
						Button_ResetCurrent_Doctrine.Enabled = false;
						Button_ResetAffectedUnits_Doctrine.Enabled = false;
						Button_ResetAffectedMissions_Doctrine.Enabled = false;
					}
					else
					{
						Button_ResetCurrent_Doctrine.Enabled = true;
						Button_ResetAffectedUnits_Doctrine.Enabled = false;
						Button_ResetAffectedMissions_Doctrine.Enabled = false;
					}
				}
				else
				{
					Button_ResetCurrent_Doctrine.Enabled = true;
					Button_ResetAffectedUnits_Doctrine.Enabled = true;
					Button_ResetAffectedMissions_Doctrine.Enabled = false;
				}
			}
			else
			{
				Button_ResetCurrent_Doctrine.Enabled = true;
				Button_ResetAffectedUnits_Doctrine.Enabled = false;
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					if (selectedUnit.IsGroup)
					{
						Button_ResetAffectedUnits_Doctrine.Enabled = true;
						break;
					}
				}
				Button_ResetAffectedMissions_Doctrine.Enabled = false;
			}
			if (SelectedUnits == null)
			{
				if (Subject.IsActiveUnit && Subject.IsGroup)
				{
					DoctrineControl1.GetDoctrine_Group((Group)Subject);
					Doctrine doctrine = doctrine_0;
					bool UnitIsOperating = true;
					doctrine.GetParentDoctrine(ref UnitIsOperating);
				}
				else if (Subject.IsActiveUnit)
				{
					Doctrine doctrine2 = doctrine_0;
					bool UnitIsOperating = true;
					doctrine2.GetParentDoctrine(ref UnitIsOperating);
				}
			}
			else
			{
				doctrine_0 = DoctrineControl1.GetDoctrine_MultipleUnit(SelectedUnits);
			}
			if (doctrine_0 != null)
			{
				_ = Client.AllowEditModeActions;
				_ = Color.Red;
				_ = Color.Yellow;
				_ = Color.Orange;
				DoctrineControl1.RefreshForm(doctrine_0, null, DoctrineControl.DoctrineControl_Config.DefaultConfig());
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			method_38();
		}
	}

	private void method_7()
	{
		try
		{
			method_37();
			method_40();
			if (Information.IsNothing((object)this.Subject))
			{
				Button_ResetCurrent_EMCON.Enabled = true;
				Button_ResetAffectedUnits_EMCON.Enabled = false;
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					if (selectedUnit.IsGroup)
					{
						Button_ResetAffectedUnits_EMCON.Enabled = true;
						break;
					}
				}
				Button_ResetAffectedMissions_EMCON.Enabled = false;
			}
			else if ((object)this.Subject.GetType() == typeof(Side))
			{
				Button_ResetCurrent_EMCON.Enabled = false;
				Button_ResetAffectedUnits_EMCON.Enabled = true;
				Button_ResetAffectedMissions_EMCON.Enabled = true;
			}
			else if (this.Subject.IsMission)
			{
				Button_ResetCurrent_EMCON.Enabled = true;
				Button_ResetAffectedUnits_EMCON.Enabled = true;
				Button_ResetAffectedMissions_EMCON.Enabled = false;
			}
			else if ((object)this.Subject.GetType() == typeof(Group))
			{
				Button_ResetCurrent_EMCON.Enabled = true;
				Button_ResetAffectedUnits_EMCON.Enabled = true;
				Button_ResetAffectedMissions_EMCON.Enabled = false;
			}
			else if ((object)this.Subject.GetType() == typeof(Waypoint))
			{
				Button_ResetCurrent_EMCON.Enabled = false;
				Button_ResetAffectedUnits_EMCON.Enabled = false;
				Button_ResetAffectedMissions_EMCON.Enabled = false;
			}
			else
			{
				Button_ResetCurrent_EMCON.Enabled = true;
				Button_ResetAffectedUnits_EMCON.Enabled = false;
				Button_ResetAffectedMissions_EMCON.Enabled = false;
			}
			if (!Information.IsNothing((object)SelectedUnits))
			{
				doctrine_0 = DoctrineControl1.GetDoctrine_MultipleUnit(SelectedUnits);
			}
			doctrine_0.DoctrineRefresh = true;
			Doctrine doctrine = doctrine_0;
			DarkCheckBox cB_EMCON_Inherits = CB_EMCON_Inherits;
			ScenarioObject Subject = this.Subject;
			doctrine.Set_Checkbox_EMCON_Inherit((CheckBox)(object)cB_EMCON_Inherits, ref Subject, ref doctrine_0);
			this.Subject = Subject;
			doctrine_0.DoctrineRefresh = false;
			Doctrine doctrine2 = doctrine_0;
			DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
			Scenario CurrentScenario = Client.CurrentScenario;
			doctrine2.Populate_Combo_EMCON_Radar((ComboBox)(object)cB_EMCON_Radar, ref CurrentScenario, ref doctrine_0);
			Doctrine doctrine3 = doctrine_0;
			DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
			CurrentScenario = Client.CurrentScenario;
			doctrine3.Populate_Combo_EMCON_OECM((ComboBox)(object)cB_EMCON_OECM, ref CurrentScenario, ref doctrine_0);
			Doctrine doctrine4 = doctrine_0;
			DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
			CurrentScenario = Client.CurrentScenario;
			doctrine4.Populate_Combo_EMCON_Sonar((ComboBox)(object)cB_EMCON_Sonar, ref CurrentScenario, ref doctrine_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			method_38();
		}
	}

	private void method_8()
	{
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		if (bool_6)
		{
			RefreshSelectedUnits(Subject);
		}
		if (Subject != null)
		{
			if ((object)Subject.GetType() == typeof(Side))
			{
				Button_ResetCurrent_WRA.Enabled = true;
				Button_ResetAffectedUnits_WRA.Enabled = true;
				Button_ResetAffectedMissions_WRA.Enabled = true;
				Button_ResetCurrent_WRA.Text = "Reset WRA (use system defaults)";
			}
			else if (Subject.IsMission)
			{
				Button_ResetCurrent_WRA.Enabled = true;
				Button_ResetAffectedUnits_WRA.Enabled = true;
				Button_ResetAffectedMissions_WRA.Enabled = false;
			}
			else if ((object)Subject.GetType() == typeof(Group))
			{
				Button_ResetCurrent_WRA.Enabled = true;
				Button_ResetAffectedUnits_WRA.Enabled = true;
				Button_ResetAffectedMissions_WRA.Enabled = false;
			}
			else if ((object)Subject.GetType() == typeof(Waypoint))
			{
				Button_ResetCurrent_WRA.Enabled = false;
				Button_ResetAffectedUnits_WRA.Enabled = false;
				Button_ResetAffectedMissions_WRA.Enabled = false;
			}
			else
			{
				Button_ResetCurrent_WRA.Enabled = true;
				Button_ResetAffectedUnits_WRA.Enabled = false;
				Button_ResetAffectedMissions_WRA.Enabled = false;
			}
		}
		else
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = false;
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsGroup)
				{
					Button_ResetAffectedUnits_WRA.Enabled = true;
					break;
				}
			}
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		try
		{
			if (Client.CurrentSide == null || Client.CurrentSide.Units.Count == 0)
			{
				return;
			}
			method_37();
			int num = 0;
			int num2 = 0;
			int firstDisplayedScrollingRowIndex = ((DataGridView)TGV_WRA).FirstDisplayedScrollingRowIndex;
			if (((BaseCollection)((DataGridView)TGV_WRA).SelectedCells).Count > 0)
			{
				num = ((DataGridView)TGV_WRA).SelectedCells[0].RowIndex;
				num2 = ((DataGridView)TGV_WRA).SelectedCells[0].ColumnIndex;
			}
			TGV_WRA.Nodes.Clear();
			dictionary_0 = new Dictionary<int, Doctrine.WRA_Weapon>();
			if (!Information.IsNothing((object)SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					method_11(ref selectedUnit2.Doctrine);
				}
			}
			else
			{
				method_11(ref doctrine_0);
			}
			if (!Information.IsNothing((object)Subject) && (object)Subject.GetType() == typeof(Side))
			{
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in dictionary_0)
				{
					int key = item.Key;
					Weapon weapon = item.Value.ReferenceWeapon(Client.CurrentScenario, key);
					if (Information.IsNothing((object)weapon.Doctrine.WRA))
					{
						continue;
					}
					foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item2 in weapon.Doctrine.WRA)
					{
						foreach (Doctrine.WRA_FiringDoctrineEntry value in item2.Value.WRA_WeaponTargets.Values)
						{
							foreach (Doctrine.WRA_FiringDoctrineEntry value2 in item.Value.WRA_WeaponTargets.Values)
							{
								if (value2.TargetType == value.TargetType)
								{
									value2.WeaponQty = -1;
									value2.ShooterQty = -1;
									value2.SelfDefenceRange = -1f;
									break;
								}
							}
						}
					}
				}
			}
			if (!Information.IsNothing((object)SelectedUnits))
			{
				method_36();
			}
			method_12(ref doctrine_0);
			List<KeyValuePair<int, Doctrine.WRA_Weapon>> list = dictionary_0.OrderBy([SpecialName] (KeyValuePair<int, Doctrine.WRA_Weapon> theKVP) => theKVP.Value.ReferenceWeapon(Client.CurrentScenario, theKVP.Key).Name, new NaturalSortComparer<string[]>()).ToList();
			int num3 = rgcSmyflIiU.Count;
			foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item3 in list)
			{
				TreeGridNode treeGridNode = TGV_WRA.Nodes.Add(item3.Value.ReferenceWeapon(Client.CurrentScenario, item3.Key).Name, null, null);
				((DataGridViewBand)treeGridNode).Tag = item3;
				treeGridNode.Nodes.Add("Temp only");
				DataGridViewTextBoxCell val = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell val2 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell val3 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell val4 = new DataGridViewTextBoxCell();
				((DataGridViewCell)val3).Value = "";
				((DataGridView)TGV_WRA)[((DataGridViewBand)WeaponsPerSalvo).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val;
				((DataGridView)TGV_WRA)[((DataGridViewBand)ShootersPerSalvo).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val4;
				((DataGridView)TGV_WRA)[((DataGridViewBand)FiringRange).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val2;
				((DataGridView)TGV_WRA)[((DataGridViewBand)SelfDefenceRange).Index, treeGridNode.RowIndex] = (DataGridViewCell)(object)val3;
				((DataGridViewCell)val).ReadOnly = true;
				((DataGridViewCell)val2).ReadOnly = true;
				((DataGridViewCell)val3).ReadOnly = true;
				((DataGridViewCell)val4).ReadOnly = true;
				if (num3 > 0 && rgcSmyflIiU.Contains(item3.Key))
				{
					num3--;
					treeGridNode.Expand();
				}
			}
			if (TGV_WRA.Rows.Count != 0 && num != 0)
			{
				TGV_WRA.Rows[num].Cells[num2].Selected = true;
				if (firstDisplayedScrollingRowIndex != -1)
				{
					((DataGridView)TGV_WRA).FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				}
			}
			method_38();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101195", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			try
			{
				method_38();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9()
	{
		try
		{
			method_37();
			if (!Information.IsNothing((object)SelectedUnits) && SelectedUnits.Count > 0)
			{
				doctrine_0 = DoctrineControl1.GetDoctrine_MultipleUnit(SelectedUnits);
			}
			else if (doctrine_0 == null)
			{
				method_4();
			}
			if (doctrine_0 != null)
			{
				DocUC_WithdrawAttackThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.WithdrawAttack), Client.CurrentScenario, "OR the primary attack weapon is at less than:");
				DocUC_WithdrawDamageThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.WithdrawDamage), Client.CurrentScenario, "Damage is more than:");
				DocUC_WithdrawDefenceThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.WithdrawDefence), Client.CurrentScenario, "OR the primary defence weapon is at less than:");
				DocUC_WithdrawFuelThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.WithdrawFuel), Client.CurrentScenario, "OR Fuel is less than:");
				DocUC_DeplAttackThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.DeployAttack), Client.CurrentScenario, "AND the primary attack weapon is at least at:");
				DocUC_DeplDamageThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.DeployDamage), Client.CurrentScenario, "Damage is less than:");
				DocUC_DeplDefenceThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.DeployDefence), Client.CurrentScenario, "AND the primary defence weapon is at least at:");
				DocUC_DeplFuelThreshold.RefreshPanel(doctrine_0.GetElement(Doctrine.DoctrineItem_E.DeployFuel), Client.CurrentScenario, "AND Fuel is at least at:");
			}
		}
		finally
		{
			method_38();
		}
	}

	private void method_10()
	{
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		List_TargetPriority.Items.Clear();
		Doctrine priorityTargetListDoctrine = doctrine_0.GetPriorityTargetListDoctrine(Client.CurrentScenario);
		if (priorityTargetListDoctrine == null)
		{
			((Control)Label_PTLSource).ForeColor = Color.Red;
			((Label)Label_PTLSource).Text = "No Priority Target List exists for this Doctrine or any parent Doctrine. Use 'Create' to create one for this Doctrine.";
			((Control)List_TargetPriority).Enabled = false;
			Btn_PTLCreate.Enabled = true;
			Btn_PTLRemove.Enabled = false;
			Btn_PTLDelete.Enabled = false;
			Btn_PTLAdd.Enabled = false;
			Btn_PTLMoveDown.Enabled = false;
			Btn_PTLMoveUp.Enabled = false;
			return;
		}
		if (priorityTargetListDoctrine == doctrine_0)
		{
			((Control)Label_PTLSource).ForeColor = Color.White;
			((Label)Label_PTLSource).Text = "Editing Priority Target List for this Doctrine. 'Remove' will completely delete the Priority Target List from this Doctrine.";
			Btn_PTLCreate.Enabled = false;
			Btn_PTLRemove.Enabled = true;
			doctrine_0.Populate_List_PriorityTarget(List_TargetPriority, Client.CurrentScenario);
			((Control)List_TargetPriority).Enabled = true;
			bool enabled = List_TargetPriority.SelectedIndices.Count > 0;
			Btn_PTLDelete.Enabled = enabled;
			Btn_PTLAdd.Enabled = enabled;
			enabled = List_TargetPriority.Items.Count > 1;
			Btn_PTLMoveDown.Enabled = enabled;
			Btn_PTLMoveUp.Enabled = enabled;
			if (((Control)this).Visible)
			{
				string text = doctrine_0.VerifyPriorityTargetList(Client.CurrentScenario);
				if (!string.IsNullOrEmpty(text))
				{
					DarkMessageBox.ShowInformation(text, "Doctrine", DarkDialogButton.Close);
				}
			}
			return;
		}
		string text2 = "Priority Target List inherited from Doctrine for '";
		if ((object)priorityTargetListDoctrine.Subject.GetType() == typeof(Side))
		{
			text2 = text2 + "side: " + ((Side)priorityTargetListDoctrine.Subject).Name;
		}
		else if (priorityTargetListDoctrine.Subject.IsMission)
		{
			text2 = text2 + "mission: " + ((Mission)priorityTargetListDoctrine.Subject).Name;
		}
		else if ((object)priorityTargetListDoctrine.Subject.GetType() == typeof(Group))
		{
			text2 = text2 + "group: " + ((Group)priorityTargetListDoctrine.Subject).Name;
		}
		else if ((object)priorityTargetListDoctrine.Subject.GetType() == typeof(Waypoint))
		{
			string text3 = ((Waypoint)priorityTargetListDoctrine.Subject).Name;
			int num;
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "Not named";
				num = 6;
			}
			else
			{
				num = 6;
			}
			string[] array = new string[num];
			array[0] = text2;
			array[1] = "waypoint: ";
			array[2] = text3;
			array[3] = " (Type: ";
			array[4] = Waypoint.get_WaypointTypeString(((Waypoint)priorityTargetListDoctrine.Subject).Type);
			array[5] = ")";
			text2 = string.Concat(array);
		}
		else if (priorityTargetListDoctrine.Subject.IsActiveUnit)
		{
			text2 = text2 + "unit: " + ((ActiveUnit)priorityTargetListDoctrine.Subject).Name;
		}
		text2 += "' Open that Doctrine to edit the list or use 'Create' to override in this Doctrine.";
		((Control)Label_PTLSource).ForeColor = Color.Red;
		((Label)Label_PTLSource).Text = text2;
		priorityTargetListDoctrine.Populate_List_PriorityTarget(List_TargetPriority, Client.CurrentScenario);
		((Control)List_TargetPriority).Enabled = true;
		Btn_PTLCreate.Enabled = true;
		Btn_PTLRemove.Enabled = false;
		Btn_PTLDelete.Enabled = false;
		Btn_PTLAdd.Enabled = false;
		Btn_PTLMoveDown.Enabled = false;
		Btn_PTLMoveUp.Enabled = false;
	}

	public void RefreshPriorityTargetList(Doctrine theDoctrine, int newSelIndex = -1)
	{
		method_10();
		if (newSelIndex >= 0)
		{
			if (newSelIndex >= List_TargetPriority.Items.Count)
			{
				newSelIndex = List_TargetPriority.Items.Count - 1;
			}
			List_TargetPriority.SelectItem(newSelIndex);
		}
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine_0, null);
		}
	}

	private void method_11(ref Doctrine doctrine_1)
	{
		foreach (ActiveUnit item in doctrine_1.AffectedUnits(Client.CurrentScenario, isEscorts))
		{
			if (item != null && item.get_UnitSide(SetSideOnly: false) == Client.CurrentSide && !item.IsGroup)
			{
				if (item.IsAircraft)
				{
					WRA_RetreiveMountWeapons(item);
					WRA_RetreiveLoadoutWeapons(item);
				}
				else if (item.IsPalletWeapon)
				{
					WRA_RetreiveePalletWeapons(item);
				}
				else if (!item.IsWeapon)
				{
					WRA_RetreiveMountWeapons(item);
					WRA_RetreiveMagazineWeapons(item);
				}
			}
		}
	}

	private void method_12(ref Doctrine doctrine_1)
	{
		if (Information.IsNothing((object)doctrine_1.WRA))
		{
			return;
		}
		foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in doctrine_1.WRA)
		{
			int key = item.Key;
			foreach (Doctrine.WRA_FiringDoctrineEntry value2 in item.Value.WRA_WeaponTargets.Values)
			{
				if (!dictionary_0.ContainsKey(key))
				{
					continue;
				}
				Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
				dictionary_0.TryGetValue(key, out value);
				foreach (Doctrine.WRA_FiringDoctrineEntry value3 in value.WRA_WeaponTargets.Values)
				{
					if (value3.TargetType == value2.TargetType)
					{
						value3.WeaponQty = value2.WeaponQty;
						value3.ShooterQty = value2.ShooterQty;
						value3.SelfDefenceRange = value2.SelfDefenceRange;
						value3.FiringRange = value2.FiringRange;
						break;
					}
				}
			}
		}
	}

	public void WRA_RetreiveLoadoutWeapons(ActiveUnit theUnit)
	{
		if (Information.IsNothing((object)((Aircraft)theUnit).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
		foreach (WeaponRec weaponRec in weapons)
		{
			if (weaponRec.get_ReferenceWeapon(theUnit.ParentScen).IsWeaponPallet)
			{
				if (weaponRec.get_ReferenceWeapon(theUnit.ParentScen).Warheads.Count() <= 0)
				{
					continue;
				}
				Warhead[] warheads = weaponRec.get_ReferenceWeapon(theUnit.ParentScen).Warheads;
				foreach (Warhead warhead in warheads)
				{
					if (warhead.get_CarriedWeapon(theUnit.ParentScen) != null && !dictionary_0.ContainsKey(warhead.get_CarriedWeapon(theUnit.ParentScen).DBID))
					{
						Weapon theWeapon = warhead.get_CarriedWeapon(theUnit.ParentScen);
						WRA_AddWeapon(ref theWeapon);
					}
				}
			}
			else
			{
				Doctrine doctrine = doctrine_0;
				Weapon theWeapon = weaponRec.get_ReferenceWeapon(theUnit.ParentScen);
				if (doctrine.WRA_RelevantWeapon(ref theWeapon))
				{
					theWeapon = weaponRec.get_ReferenceWeapon(theUnit.ParentScen);
					WRA_AddWeapon(ref theWeapon);
				}
			}
		}
	}

	public void WRA_RetreiveePalletWeapons(ActiveUnit theUnit)
	{
		if (Information.IsNothing((object)(Weapon)theUnit))
		{
			return;
		}
		if (((Weapon)theUnit).WeaponWeapons.Count == 0)
		{
			((Weapon)theUnit).InitializeWeaponWeaponsPallet();
		}
		foreach (WeaponRec weaponWeapon in ((Weapon)theUnit).WeaponWeapons)
		{
			if (!weaponWeapon.get_ReferenceWeapon(theUnit.ParentScen).IsWeaponPallet)
			{
				Doctrine doctrine = doctrine_0;
				Weapon theWeapon = weaponWeapon.get_ReferenceWeapon(theUnit.ParentScen);
				if (doctrine.WRA_RelevantWeapon(ref theWeapon))
				{
					theWeapon = weaponWeapon.get_ReferenceWeapon(theUnit.ParentScen);
					WRA_AddWeapon(ref theWeapon);
				}
			}
			else
			{
				if (weaponWeapon.get_ReferenceWeapon(theUnit.ParentScen).Warheads.Count() <= 0)
				{
					continue;
				}
				Warhead[] warheads = weaponWeapon.get_ReferenceWeapon(theUnit.ParentScen).Warheads;
				foreach (Warhead warhead in warheads)
				{
					if (warhead.get_CarriedWeapon(theUnit.ParentScen) != null && !dictionary_0.ContainsKey(warhead.get_CarriedWeapon(theUnit.ParentScen).DBID))
					{
						Weapon theWeapon = warhead.get_CarriedWeapon(theUnit.ParentScen);
						WRA_AddWeapon(ref theWeapon);
					}
				}
			}
		}
	}

	public void WRA_RetreiveMagazineWeapons(ActiveUnit theUnit)
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
				if (theWeapon != null && doctrine_0.WRA_RelevantWeapon(ref theWeapon))
				{
					WRA_AddWeapon(ref theWeapon);
				}
			}
		}
	}

	public void WRA_RetreiveMountWeapons(ActiveUnit theUnit)
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
				if (doctrine_0.WRA_RelevantWeapon(ref theWeapon))
				{
					WRA_AddWeapon(ref theWeapon);
				}
			}
		}
	}

	public void WRA_AddWeapon(ref Weapon theWeapon)
	{
		if (!dictionary_0.ContainsKey(theWeapon.DBID))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon(ref theWeapon, Client.CurrentScenario);
			dictionary_0.Add(theWeapon.DBID, value);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		Refreshinfo();
	}

	internal void Refreshinfo()
	{
		if (!MyProject.Forms.MainForm.RightColumnWPF1.Refreshing && (Subject != null || SelectedUnits != null))
		{
			switch (((TabControl)TabControl1A).SelectedIndex)
			{
			case 0:
				method_6();
				break;
			case 1:
				method_7();
				break;
			case 2:
				method_8();
				break;
			case 3:
				method_9();
				break;
			case 4:
				method_10();
				break;
			}
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		Doctrine theDoc = doctrine_0;
		theDoc.Set_Checkbox_State_Visibility_EMCON((CheckBox)(object)CB_EMCON_Inherits, (ComboBox)(object)CB_EMCON_Radar, (ComboBox)(object)CB_EMCON_OECM, (ComboBox)(object)CB_EMCON_Sonar, ref theDoc, Client.CurrentScenario, ViaDoctrineForm: true, ViaRightColumn: false);
		Doctrine doctrine = theDoc;
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario CurrentScenario = Client.CurrentScenario;
		doctrine.Populate_Combo_EMCON_Radar((ComboBox)(object)cB_EMCON_Radar, ref CurrentScenario, ref theDoc);
		Doctrine doctrine2 = theDoc;
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		CurrentScenario = Client.CurrentScenario;
		doctrine2.Populate_Combo_EMCON_OECM((ComboBox)(object)cB_EMCON_OECM, ref CurrentScenario, ref theDoc);
		Doctrine doctrine3 = theDoc;
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		CurrentScenario = Client.CurrentScenario;
		doctrine3.Populate_Combo_EMCON_Sonar((ComboBox)(object)cB_EMCON_Sonar, ref CurrentScenario, ref theDoc);
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				Doctrine doctrine4 = selectedUnit.Doctrine;
				Side CurrentSide = Client.CurrentSide;
				CurrentScenario = Client.CurrentScenario;
				doctrine4.ApplyEMCON_For_AffectedUnits(ref CurrentSide, ref CurrentScenario, ref isEscorts);
				Client.CurrentSide = CurrentSide;
			}
		}
		else
		{
			Doctrine doctrine5 = doctrine_0;
			Side CurrentSide = Client.CurrentSide;
			CurrentScenario = Client.CurrentScenario;
			doctrine5.ApplyEMCON_For_AffectedUnits(ref CurrentSide, ref CurrentScenario, ref isEscorts);
			Client.CurrentSide = CurrentSide;
		}
		bool_3 = false;
		doctrine_0.FireEvent_EmconChanged(Subject, false, !Information.IsNothing((object)SelectedUnits) && SelectedUnits.Count > 1, ViaDoctrineForm: true, ViaRightColumn: false, viaFlightPlanEditor: false);
		bool_3 = true;
		Client.MustRefreshMainForm = true;
	}

	private void method_15(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario CurrentScenario = Client.CurrentScenario;
		ref Doctrine thedoc = ref doctrine_0;
		bool AskObedience = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_Radar((ComboBox)(object)cB_EMCON_Radar, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref isEscorts, ViaDoctrineForm: true, ViaRightColumn: false);
		Client.MustRefreshMainForm = true;
		Refreshinfo();
	}

	private void method_16(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		Scenario CurrentScenario = Client.CurrentScenario;
		ref Doctrine thedoc = ref doctrine_0;
		bool AskObedience = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_OECM((ComboBox)(object)cB_EMCON_OECM, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref isEscorts, ViaDoctrineForm: true, ViaRightColumn: false);
		Client.MustRefreshMainForm = true;
		Refreshinfo();
	}

	private void method_17(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		Scenario CurrentScenario = Client.CurrentScenario;
		ref Doctrine thedoc = ref doctrine_0;
		bool AskObedience = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_Sonar((ComboBox)(object)cB_EMCON_Sonar, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref isEscorts, ViaDoctrineForm: true, ViaRightColumn: false);
		Client.MustRefreshMainForm = true;
		Refreshinfo();
	}

	private void DoctrineForm_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Invalid comparison between Unknown and I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Invalid comparison between Unknown and I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Invalid comparison between Unknown and I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		if (((ContainerControl)this).ParentForm == null)
		{
			if ((int)e.KeyCode == 27 && ((Control)this).Visible)
			{
				((Form)this).Close();
				return;
			}
			if ((int)e.KeyCode == 120 && e.Control && ((Control)this).Visible)
			{
				((Form)this).Close();
				return;
			}
		}
		if (((ContainerControl)this).ParentForm == null && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void LoadTemplate_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		FD_ImportTemplate = new OpenFileDialog();
		((FileDialog)FD_ImportTemplate).InitialDirectory = GameGeneral.ScenariosRootPath;
		if ((int)((CommonDialog)FD_ImportTemplate).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			object parentObject = doctrine_0.Subject;
			OpenFileDialog fD_ImportTemplate;
			string doctrineFileName = ((FileDialog)(fD_ImportTemplate = FD_ImportTemplate)).FileName;
			ref Doctrine doc = ref doctrine_0;
			Scenario scenariocontext = Client.CurrentScenario;
			LuaDoctrine.FromXML_Private(ref parentObject, ref doctrineFileName, ref doc, ref scenariocontext);
			((FileDialog)fD_ImportTemplate).FileName = doctrineFileName;
			method_27();
			DarkMessageBox.ShowInformation("Doctrine loaded", "Doctrine", DarkDialogButton.Close);
			((Form)this).Close();
			if (!((Control)Client.MissionEditorWindow).Visible)
			{
				if (Client.SelectedUnit != null && SelectedUnits != null && SelectedUnits.Count != 0)
				{
					MainForm mainForm = MyProject.Forms.MainForm;
					Module_Unit.Unit selectedUnit = Client.SelectedUnit;
					ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = Client.CurrentSide.SelectedUnits;
					List<ActiveUnit> theSelectedActiveUnit = null;
					mainForm.ShowDoctrineROE(selectedUnit, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: true);
				}
				else
				{
					MainForm mainForm2 = MyProject.Forms.MainForm;
					ScenarioObject subject = Subject;
					ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
					List<ActiveUnit> theSelectedActiveUnit = SelectedUnits;
					mainForm2.ShowDoctrineROE(subject, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating);
					SelectedUnits = theSelectedActiveUnit;
				}
			}
			else if (Client.MissionEditorWindow.SelectedMission != null)
			{
				((Control)Client.MissionEditorWindow.EMCON_WRA_Panel).Controls.Clear();
				if (Information.IsNothing((object)Client.MissionEditorWindow.SelectedMission))
				{
					return;
				}
				MyProject.Forms.MissionEditor.theDoctrineForm.isEscorts = false;
				MyProject.Forms.MissionEditor.theDoctrineForm.Subject = Client.MissionEditorWindow.SelectedMission;
				MyProject.Forms.MissionEditor.theDoctrineForm = MissionEditor.PrepareDoctrineFormForMissionEditor(MyProject.Forms.MissionEditor.theDoctrineForm);
				((Control)Client.MissionEditorWindow.EMCON_WRA_Panel).Controls.Add((Control)(object)MyProject.Forms.MissionEditor.theDoctrineForm);
				((Control)MyProject.Forms.MissionEditor.theDoctrineForm).Show();
				Client.MissionEditorWindow.EMCON_WRA_Mission = Client.MissionEditorWindow.SelectedMission.ObjectID;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in DoctrineForm", "LoadTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void SaveTemplate_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		FD_ExportTemplate = new SaveFileDialog();
		((FileDialog)FD_ExportTemplate).InitialDirectory = GameGeneral.ScenariosRootPath;
		if ((int)((CommonDialog)FD_ExportTemplate).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			FileStream fileStream = File.Create(((FileDialog)FD_ExportTemplate).FileName);
			using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
			{
				ref Doctrine doc = ref doctrine_0;
				MemoryStream theStream = memoryStream;
				Scenario scenariocontext = Client.CurrentScenario;
				LuaDoctrine.ToXML_Private(ref doc, ref theStream, ref scenariocontext);
				fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
				fileStream.Close();
			}
			DarkMessageBox.ShowInformation("Doctrine saved as " + ((FileDialog)FD_ExportTemplate).FileName, "Doctrine", DarkDialogButton.Close);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in DoctrineForm", "SaveTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void method_18(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_WRA.Nodes)
			{
				if (((DataGridViewRow)node).Selected)
				{
					break;
				}
				int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)node).Tag).Key;
				Weapon theWeapon = ((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)node).Tag).Value.ReferenceWeapon(Client.CurrentScenario, key);
				foreach (TreeGridNode node2 in node.Nodes)
				{
					int rowIndex = node2.RowIndex;
					object objectValue = RuntimeHelpers.GetObjectValue(((DataGridViewBand)node2).Tag);
					if (((DataGridViewRow)node2).Selected && rowIndex != -1)
					{
						DataTable theComboBoxDataSource_WeaponQty = new DataTable();
						DataTable theComboBoxDataSource_ShooterQty = new DataTable();
						DataTable theComboBoxDataSource_SelfDefenceRange = new DataTable();
						DataTable theComboBoxDataSource_FiringRange = new DataTable();
						Doctrine._WRA_WeaponTargetType targetType = ((Doctrine.WRA_FiringDoctrineEntry)objectValue).TargetType;
						DataGridViewColumn val = ((DataGridView)TGV_WRA).Columns[e.ColumnIndex];
						if (Operators.CompareString(val.Name, "WeaponsPerSalvo", true) == 0)
						{
							DataGridViewComboBoxCell val2 = (DataGridViewComboBoxCell)((DataGridView)TGV_WRA)[((DataGridViewBand)WeaponsPerSalvo).Index, rowIndex];
							doctrine_0.ComboBoxDataSource_WeaponQty(ref theComboBoxDataSource_WeaponQty, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val2).Value));
							val2.DataSource = theComboBoxDataSource_WeaponQty;
							val2.DisplayMember = "Description";
							val2.ValueMember = "ID";
							val2.DropDownWidth = 500;
							((DataGridView)TGV_WRA).BeginEdit(true);
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_WRA).EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(val.Name, "ShootersPerSalvo", true) == 0)
						{
							DataGridViewComboBoxCell val3 = (DataGridViewComboBoxCell)((DataGridView)TGV_WRA)[((DataGridViewBand)ShootersPerSalvo).Index, rowIndex];
							doctrine_0.ComboBoxDataSource_ShooterQty(ref theComboBoxDataSource_ShooterQty, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val3).Value));
							val3.DataSource = theComboBoxDataSource_ShooterQty;
							val3.DisplayMember = "Description";
							val3.ValueMember = "ID";
							val3.DropDownWidth = 500;
							((DataGridView)TGV_WRA).BeginEdit(true);
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_WRA).EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(val.Name, "SelfDefenceRange", true) == 0)
						{
							DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)((DataGridView)TGV_WRA)[((DataGridViewBand)SelfDefenceRange).Index, rowIndex];
							doctrine_0.ComboBoxDataSource_SelfDefenceRange(ref theComboBoxDataSource_SelfDefenceRange, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val4).Value));
							val4.DataSource = theComboBoxDataSource_SelfDefenceRange;
							val4.DropDownWidth = 500;
							val4.DisplayMember = "Description";
							val4.ValueMember = "ID";
							((DataGridView)TGV_WRA).BeginEdit(true);
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_WRA).EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(val.Name, "FiringRange", true) == 0)
						{
							DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)((DataGridView)TGV_WRA)[((DataGridViewBand)FiringRange).Index, rowIndex];
							doctrine_0.ComboBoxDataSource_FiringRange(ref theComboBoxDataSource_FiringRange, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val5).Value));
							val5.DataSource = theComboBoxDataSource_FiringRange;
							val5.DropDownWidth = 500;
							val5.DisplayMember = "Description";
							val5.ValueMember = "ID";
							((DataGridView)TGV_WRA).BeginEdit(true);
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)TGV_WRA).EditingControl).DroppedDown = true;
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 20012300002", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_19(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)TGV_WRA).SelectedRows).Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = default(TreeGridNode);
		bool flag = default(bool);
		foreach (TreeGridNode node in TGV_WRA.Nodes)
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
		if (treeGridNode != null && treeGridNode.Parent != null)
		{
			TreeGridNode parent = treeGridNode.Parent;
			method_22(e, treeGridNode, parent);
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		if (((DataGridView)TGV_WRA).IsCurrentCellDirty)
		{
			bool_5 = true;
			((DataGridView)TGV_WRA).CommitEdit((DataGridViewDataErrorContexts)512);
			bool_5 = false;
			method_8();
		}
	}

	private void method_22(DataGridViewCellEventArgs dataGridViewCellEventArgs_0, TreeGridNode treeGridNode_0, TreeGridNode treeGridNode_1)
	{
		RuntimeHelpers.GetObjectValue(((DataGridView)TGV_WRA)[dataGridViewCellEventArgs_0.ColumnIndex, dataGridViewCellEventArgs_0.RowIndex].Value);
		object WeaponsPerSalvoValue = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_WRA)[((DataGridViewBand)WeaponsPerSalvo).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object ShootersPerSalvoValue = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_WRA)[((DataGridViewBand)ShootersPerSalvo).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object SelfDefenceRange = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_WRA)[((DataGridViewBand)this.SelfDefenceRange).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object FiringRange = RuntimeHelpers.GetObjectValue(((DataGridView)TGV_WRA)[((DataGridViewBand)this.FiringRange).Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		Doctrine._WRA_WeaponTargetType WeaponTargetType = ((Doctrine.WRA_FiringDoctrineEntry)((DataGridViewBand)treeGridNode_0).Tag).TargetType;
		bool bool_ = default(bool);
		int? nullable_ = default(int?);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)WeaponsPerSalvo).Index)
		{
			bool_ = true;
			nullable_ = doctrine_0.WeaponsPerSalvoSelection_To_WeaponQty(ref WeaponTargetType, ref WeaponsPerSalvoValue);
		}
		bool bool_2 = default(bool);
		int? nullable_2 = default(int?);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)ShootersPerSalvo).Index)
		{
			bool_2 = true;
			nullable_2 = doctrine_0.ShootersPerSalvoSelection_To_ShooterQty(ref ShootersPerSalvoValue);
		}
		bool bool_3 = default(bool);
		float? nullable_3 = default(float?);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)this.SelfDefenceRange).Index)
		{
			bool_3 = true;
			nullable_3 = doctrine_0.SelfDefenceRangeSelection_To_SelfDefenceRange(ref WeaponTargetType, ref SelfDefenceRange);
		}
		bool bool_4 = default(bool);
		float? nullable_4 = default(float?);
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ((DataGridViewBand)this.FiringRange).Index)
		{
			bool_4 = true;
			nullable_4 = doctrine_0.FiringRangeSelection_To_FiringRange(ref FiringRange);
		}
		int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)treeGridNode_1).Tag).Key;
		_ = (KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)treeGridNode_1).Tag;
		method_23(ref doctrine_0, nullable_, bool_, nullable_2, bool_2, nullable_4, bool_4, nullable_3, bool_3, key, WeaponTargetType);
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendDoctrineChanged(doctrine_0.Subject);
		}
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				method_23(ref selectedUnit.Doctrine, nullable_, bool_, nullable_2, bool_2, nullable_4, bool_4, nullable_3, bool_3, key, WeaponTargetType);
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendDoctrineChanged(selectedUnit);
				}
			}
		}
		if (Doctrine.WRA_IsTopNodeTargetType(ref WeaponTargetType) && !bool_5)
		{
			Refreshinfo();
		}
	}

	private void method_23(ref Doctrine doctrine_1, int? nullable_0, bool bool_7, int? nullable_1, bool bool_8, float? nullable_2, bool bool_9, float? nullable_3, bool bool_10, int int_0, Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		new Doctrine.WRA_FiringDoctrineEntry();
		bool flag = default(bool);
		if (doctrine_1.WRA != null && doctrine_1.WRA.ContainsKey(int_0))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
			doctrine_1.WRA.TryGetValue(int_0, out value);
			if (value != null)
			{
				foreach (Doctrine.WRA_FiringDoctrineEntry value4 in value.WRA_WeaponTargets.Values)
				{
					if (value4.TargetType != _WRA_WeaponTargetType_0)
					{
						continue;
					}
					int num;
					if (bool_7)
					{
						value4.WeaponQty = nullable_0;
						num = 1;
					}
					else if (bool_8)
					{
						value4.ShooterQty = nullable_1;
						num = 1;
					}
					else if (!bool_10)
					{
						if (bool_9)
						{
							value4.FiringRange = nullable_2;
							num = 1;
						}
						else
						{
							num = 1;
						}
					}
					else
					{
						value4.SelfDefenceRange = nullable_3;
						num = 1;
					}
					flag = (byte)num != 0;
				}
			}
		}
		if (!flag)
		{
			if (doctrine_1.WRA == null)
			{
				doctrine_1.WRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
			}
			if (!doctrine_1.WRA.ContainsKey(int_0))
			{
				doctrine_1.WRA[int_0] = null;
			}
			Doctrine.WRA_Weapon value2 = new Doctrine.WRA_Weapon();
			doctrine_1.WRA.TryGetValue(int_0, out value2);
			if (value2 == null)
			{
				value2 = new Doctrine.WRA_Weapon();
				if (doctrine_1.WRA.ContainsKey(int_0))
				{
					doctrine_1.WRA[int_0] = value2;
				}
			}
			bool flag2 = default(bool);
			foreach (Doctrine.WRA_FiringDoctrineEntry value5 in value2.WRA_WeaponTargets.Values)
			{
				if (value5.TargetType == _WRA_WeaponTargetType_0)
				{
					flag2 = true;
					break;
				}
			}
			Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new Doctrine.WRA_FiringDoctrineEntry(_WRA_WeaponTargetType_0);
			if (!flag2)
			{
				if (!bool_7)
				{
					if (bool_8)
					{
						wRA_FiringDoctrineEntry.ShooterQty = nullable_1;
					}
					else if (!bool_10)
					{
						if (bool_9)
						{
							wRA_FiringDoctrineEntry.FiringRange = nullable_2;
						}
					}
					else
					{
						wRA_FiringDoctrineEntry.SelfDefenceRange = nullable_3;
					}
				}
				else
				{
					wRA_FiringDoctrineEntry.WeaponQty = nullable_0;
				}
				value2.AddTo_WRAWeaponTargets(wRA_FiringDoctrineEntry);
			}
		}
		if (doctrine_1.WRA == null || nullable_0.HasValue || nullable_1.HasValue || nullable_3.HasValue || nullable_2.HasValue)
		{
			return;
		}
		List<Doctrine.WRA_FiringDoctrineEntry> list = new List<Doctrine.WRA_FiringDoctrineEntry>();
		Doctrine.WRA_Weapon value3 = new Doctrine.WRA_Weapon();
		if (doctrine_1.WRA.Count > 0)
		{
			doctrine_1.WRA.TryGetValue(int_0, out value3);
			if (value3.WRA_WeaponTargets != null)
			{
				foreach (Doctrine.WRA_FiringDoctrineEntry value6 in value3.WRA_WeaponTargets.Values)
				{
					if (value6.TargetType == _WRA_WeaponTargetType_0 && !value6.WeaponQty.HasValue && !value6.SelfDefenceRange.HasValue && !value6.FiringRange.HasValue)
					{
						list.Add(value6);
					}
				}
				if (list.Count > 0)
				{
					foreach (Doctrine.WRA_FiringDoctrineEntry item in list)
					{
						value3.WRA_WeaponTargets.Remove((int)item.TargetType);
					}
				}
				if (value3.WRA_WeaponTargets.Count == 0)
				{
					value3.WRA_WeaponTargets = null;
				}
			}
		}
		if (value3.WRA_WeaponTargets == null)
		{
			doctrine_1.WRA.Remove(int_0);
		}
		if (doctrine_1.WRA == null || doctrine_1.WRA.Count == 0)
		{
			doctrine_1.WRA = null;
		}
	}

	private void method_24(object sender, ExpandingEventArgs e)
	{
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		if (e.Node.Level != 1)
		{
			return;
		}
		int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)e.Node).Tag).Key;
		if (!rgcSmyflIiU.Contains(key))
		{
			rgcSmyflIiU.Add(key);
		}
		Weapon theWeapon = ((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)e.Node).Tag).Value.ReferenceWeapon(Client.CurrentScenario, key);
		KeyValuePair<int, Doctrine.WRA_Weapon> keyValuePair = (KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)e.Node).Tag;
		e.Node.Nodes.Clear();
		Contact theTarget = default(Contact);
		if (Client.SelectedUnit != null)
		{
			theTarget = ((!Client.SelectedUnit.IsContact()) ? Client.CurrentSide.Contacts.Where([SpecialName] (KeyValuePair<string, Contact> x) => x.Value.ActualUnit != null && Operators.CompareString(x.Value.ActualUnit.ObjectID, Client.SelectedUnit.ObjectID, true) == 0).FirstOrDefault().Value : ((Contact)Client.SelectedUnit));
		}
		foreach (Doctrine.WRA_FiringDoctrineEntry value in keyValuePair.Value.WRA_WeaponTargets.Values)
		{
			int num = doctrine_0.WeaponQty_To_WeaponsPerSalvoSelection(ref value.TargetType, value.WeaponQty);
			int num2 = doctrine_0.ShooterQty_To_ShootersPerSalvoSelection(value.ShooterQty);
			int num3 = doctrine_0.SelfDefenceRange_To_SelfDefenceRangeSelection(ref value.TargetType, value.SelfDefenceRange);
			int num4 = doctrine_0.FiringRange_To_FiringRangeSelection(value.FiringRange);
			TreeGridNode treeGridNode = e.Node.Nodes.Add(Doctrine.WRA_TargetType_String(null, value.TargetType, EmitterClassifiable: false), num, num2, num4, num3);
			((DataGridViewBand)treeGridNode).Tag = value;
			if (Doctrine.WRA_IsTopNodeTargetType(ref value.TargetType))
			{
				((DataGridViewRow)treeGridNode).DefaultCellStyle.Font = new Font(((Control)this).Font, (FontStyle)1);
			}
			if (theTarget != null)
			{
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theWeapon, ref GlobalVariables.ObjectFalse);
				Weapon theW = theWeapon;
				GlobalVariables.BooleanObject EmitterClassificable = null;
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType2 = Contact.WRA_DetermineTargetType(ref theTarget, theW, ref EmitterClassificable);
				if ((value.TargetType == wRA_WeaponTargetType) | (value.TargetType == wRA_WeaponTargetType2))
				{
					((DataGridViewRow)treeGridNode).DefaultCellStyle.ForeColor = Color.LightGreen;
				}
			}
		}
		foreach (TreeGridNode node in e.Node.Nodes)
		{
			DataTable theComboBoxDataSource_WeaponQty = new DataTable();
			DataTable theComboBoxDataSource_ShooterQty = new DataTable();
			DataTable theComboBoxDataSource_SelfDefenceRange = new DataTable();
			DataTable theComboBoxDataSource_FiringRange = new DataTable();
			Doctrine._WRA_WeaponTargetType targetType = ((Doctrine.WRA_FiringDoctrineEntry)((DataGridViewBand)node).Tag).TargetType;
			DataGridViewComboBoxCell val = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)WeaponsPerSalvo).Index];
			DataGridViewComboBoxCell val2 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)ShootersPerSalvo).Index];
			DataGridViewComboBoxCell val3 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)SelfDefenceRange).Index];
			DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)node.Cells[((DataGridViewBand)FiringRange).Index];
			doctrine_0.ComboBoxDataSource_WeaponQty(ref theComboBoxDataSource_WeaponQty, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val).Value));
			doctrine_0.ComboBoxDataSource_ShooterQty(ref theComboBoxDataSource_ShooterQty, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val2).Value));
			doctrine_0.ComboBoxDataSource_SelfDefenceRange(ref theComboBoxDataSource_SelfDefenceRange, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val3).Value));
			doctrine_0.ComboBoxDataSource_FiringRange(ref theComboBoxDataSource_FiringRange, targetType, ref theWeapon, Conversions.ToInteger(((DataGridViewCell)val4).Value));
			if (Conversions.ToInteger(((DataGridViewCell)val3).Value) > theComboBoxDataSource_SelfDefenceRange.Rows.Count)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(((DataGridViewCell)val3).Value, doctrine_0.WRA_SelfDefenceRangeString(((Doctrine.WRA_FiringDoctrineEntry)((DataGridViewBand)node).Tag).SelfDefenceRange, TargetTypeUnspecified: false));
			}
			if (Conversions.ToInteger(((DataGridViewCell)val4).Value) > theComboBoxDataSource_FiringRange.Rows.Count)
			{
				theComboBoxDataSource_FiringRange.Rows.Add(((DataGridViewCell)val4).Value, doctrine_0.WRA_FiringRangeString(((Doctrine.WRA_FiringDoctrineEntry)((DataGridViewBand)node).Tag).FiringRange, TargetTypeUnspecified: false));
			}
			val.DataSource = theComboBoxDataSource_WeaponQty;
			val.DisplayMember = "Description";
			val.ValueMember = "ID";
			val2.DataSource = theComboBoxDataSource_ShooterQty;
			val2.DisplayMember = "Description";
			val2.ValueMember = "ID";
			val3.DataSource = theComboBoxDataSource_SelfDefenceRange;
			val3.DisplayMember = "Description";
			val3.ValueMember = "ID";
			val4.DataSource = theComboBoxDataSource_FiringRange;
			val4.DisplayMember = "Description";
			val4.ValueMember = "ID";
		}
	}

	private void method_25(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			rgcSmyflIiU.Remove(((KeyValuePair<int, Doctrine.WRA_Weapon>)((DataGridViewBand)e.Node).Tag).Key);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedUnits))
		{
			if (!Information.IsNothing((object)doctrine_0.WRA))
			{
				doctrine_0.WRA = null;
			}
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (!Information.IsNothing((object)selectedUnit.Doctrine.WRA))
				{
					selectedUnit.Doctrine.WRA = null;
				}
			}
		}
		else if ((object)Subject.GetType() == typeof(Side))
		{
			if (!Information.IsNothing((object)((Side)Subject).Doctrine.WRA))
			{
				((Side)Subject).Doctrine.WRA = null;
			}
		}
		else if (!Subject.IsMission)
		{
			if (Subject.IsGroup)
			{
				if (!Information.IsNothing((object)((Group)Subject).Doctrine.WRA))
				{
					((Group)Subject).Doctrine.WRA = null;
				}
			}
			else if (Subject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				if (activeUnit.IsWeapon)
				{
					return;
				}
				if (!Information.IsNothing((object)activeUnit.Doctrine.WRA))
				{
					activeUnit.Doctrine.WRA = null;
				}
			}
		}
		else if (isEscorts)
		{
			if (((Strike)Subject).MissionClass == Mission._MissionClass.Strike && !Information.IsNothing((object)((Strike)Subject).Doctrine_Escorts.WRA))
			{
				((Strike)Subject).Doctrine_Escorts.WRA = null;
			}
		}
		else if (!Information.IsNothing((object)((Mission)Subject).Doctrine.WRA))
		{
			((Mission)Subject).Doctrine.WRA = null;
		}
		method_8();
	}

	private void method_27()
	{
		try
		{
			if (!Information.IsNothing((object)SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					foreach (ActiveUnit item in selectedUnit.Doctrine.AffectedUnits(Client.CurrentScenario, isEscorts))
					{
						if (!item.IsWeapon)
						{
							item.Doctrine.ClearCachedParentDoctrine();
						}
					}
				}
				return;
			}
			if (Information.IsNothing((object)Subject))
			{
				return;
			}
			if ((object)Subject.GetType() != typeof(Side))
			{
				{
					foreach (ActiveUnit item2 in doctrine_0.AffectedUnits(Client.CurrentScenario, isEscorts))
					{
						if (!item2.IsWeapon)
						{
							item2.Doctrine.ClearCachedParentDoctrine();
						}
					}
					return;
				}
			}
			foreach (ActiveUnit unit in Client.CurrentSide.Units)
			{
				if (!unit.IsWeapon)
				{
					unit.Doctrine.ClearCachedParentDoctrine();
				}
			}
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				mission.Doctrine.ClearCachedParentDoctrine();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 9992496", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				foreach (ActiveUnit item in selectedUnit.Doctrine.AffectedUnits(Client.CurrentScenario, isEscorts))
				{
					if (item.IsGroup)
					{
						if (!Information.IsNothing((object)item.Doctrine.WRA))
						{
							item.Doctrine.WRA = null;
						}
					}
					else if (item.IsActiveUnit && !item.IsWeapon && !Information.IsNothing((object)item.Doctrine.WRA))
					{
						item.Doctrine.WRA = null;
					}
				}
			}
			return;
		}
		if (Information.IsNothing((object)Subject))
		{
			return;
		}
		if ((object)Subject.GetType() != typeof(Side))
		{
			{
				foreach (ActiveUnit item2 in doctrine_0.AffectedUnits(Client.CurrentScenario, isEscorts))
				{
					if (!item2.IsGroup)
					{
						if (item2.IsActiveUnit && !item2.IsWeapon && !Information.IsNothing((object)item2.Doctrine.WRA))
						{
							item2.Doctrine.WRA = null;
						}
					}
					else if (!Information.IsNothing((object)item2.Doctrine.WRA))
					{
						item2.Doctrine.WRA = null;
					}
				}
				return;
			}
		}
		foreach (ActiveUnit unit in Client.CurrentSide.Units)
		{
			if (!unit.IsWeapon && !Information.IsNothing((object)unit.Doctrine.WRA))
			{
				unit.Doctrine.WRA = null;
			}
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)Subject) || (object)Subject.GetType() != typeof(Side))
		{
			return;
		}
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!Information.IsNothing((object)mission.Doctrine.WRA))
			{
				mission.Doctrine.WRA = null;
			}
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedUnits))
		{
			if ((object)Subject.GetType() != typeof(Side))
			{
				if (!Subject.IsMission)
				{
					if (!Subject.IsGroup)
					{
						if (Subject.IsActiveUnit)
						{
							ActiveUnit activeUnit = (ActiveUnit)Subject;
							if (activeUnit.IsWeapon)
							{
								return;
							}
							Doctrine.ResetDoctrineSettings(activeUnit, ref activeUnit.Doctrine);
						}
					}
					else
					{
						Doctrine theDoctrine = ((Group)Subject).Doctrine;
						Doctrine.ResetDoctrineSettings(null, ref theDoctrine);
					}
				}
				else
				{
					Doctrine theDoctrine2 = (isEscorts ? ((Strike)Subject).Doctrine_Escorts : ((Mission)Subject).Doctrine);
					Doctrine.ResetDoctrineSettings(null, ref theDoctrine2);
				}
			}
			doctrine_0.ClearCachedParentDoctrine();
		}
		else
		{
			Doctrine.ResetDoctrineSettings(null, ref doctrine_0);
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (!selectedUnit.IsWeapon)
				{
					Doctrine.ResetDoctrineSettings(selectedUnit, ref selectedUnit.Doctrine);
				}
			}
		}
		MyProject.Forms.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(v: true);
		method_6();
	}

	private void method_31(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				foreach (ActiveUnit item in selectedUnit.Doctrine.AffectedUnits(Client.CurrentScenario, isEscorts))
				{
					if (item.IsGroup)
					{
						Doctrine.ResetDoctrineSettings(item, ref item.Doctrine);
					}
					else if (item.IsActiveUnit && !item.IsWeapon)
					{
						Doctrine.ResetDoctrineSettings(item, ref item.Doctrine);
					}
				}
			}
			return;
		}
		if (!Information.IsNothing((object)Subject))
		{
			if ((object)Subject.GetType() != typeof(Side))
			{
				foreach (ActiveUnit item2 in doctrine_0.AffectedUnits(Client.CurrentScenario, isEscorts))
				{
					if (!item2.IsGroup)
					{
						if (item2.IsActiveUnit && !item2.IsWeapon)
						{
							Doctrine.ResetDoctrineSettings(item2, ref item2.Doctrine);
						}
					}
					else
					{
						Doctrine.ResetDoctrineSettings(item2, ref item2.Doctrine);
					}
				}
			}
			else
			{
				foreach (ActiveUnit unit in Client.CurrentSide.Units)
				{
					if (!unit.IsGroup)
					{
						if (unit.IsActiveUnit && !unit.IsWeapon)
						{
							Doctrine.ResetDoctrineSettings(unit, ref unit.Doctrine);
						}
					}
					else
					{
						Doctrine.ResetDoctrineSettings(unit, ref unit.Doctrine);
					}
				}
			}
		}
		MyProject.Forms.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(v: true);
		method_6();
	}

	private void method_32(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Subject) && (object)Subject.GetType() == typeof(Side))
		{
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				Doctrine.ResetDoctrineSettings(null, ref mission.Doctrine);
			}
		}
		MyProject.Forms.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(v: true);
		method_6();
	}

	private void method_33(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SelectedUnits))
		{
			if ((object)Subject.GetType() != typeof(Side))
			{
				if (Subject.IsMission)
				{
					if (!isEscorts)
					{
						if (!((Mission)Subject).Doctrine.EMCON_Inherits)
						{
							((Mission)Subject).Doctrine.EMCON_Inherits = true;
						}
					}
					else if (!((Strike)Subject).Doctrine_Escorts.EMCON_Inherits)
					{
						((Strike)Subject).Doctrine_Escorts.EMCON_Inherits = true;
					}
				}
				else if (!Subject.IsGroup)
				{
					if (Subject.IsActiveUnit)
					{
						ActiveUnit activeUnit = (ActiveUnit)Subject;
						if (activeUnit.IsWeapon)
						{
							return;
						}
						if (!activeUnit.Doctrine.EMCON_Inherits)
						{
							activeUnit.Doctrine.EMCON_Inherits = true;
						}
					}
				}
				else if (!((Group)Subject).Doctrine.EMCON_Inherits)
				{
					((Group)Subject).Doctrine.EMCON_Inherits = true;
				}
			}
		}
		else
		{
			Doctrine.ResetDoctrineSettings(null, ref doctrine_0);
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (!selectedUnit.IsGroup)
				{
					if (selectedUnit.IsActiveUnit)
					{
						ActiveUnit activeUnit2 = selectedUnit;
						if (activeUnit2.IsWeapon)
						{
							return;
						}
						if (!activeUnit2.Doctrine.EMCON_Inherits)
						{
							activeUnit2.Doctrine.EMCON_Inherits = true;
						}
					}
				}
				else if (!((Group)selectedUnit).Doctrine.EMCON_Inherits)
				{
					((Group)selectedUnit).Doctrine.EMCON_Inherits = true;
				}
			}
		}
		if (!isAirOps && !isBoatOps)
		{
			Scenario CurrentScenario = Client.CurrentScenario;
			EmconControl.AskEMCONObedience(ref CurrentScenario, ref doctrine_0, ref isEscorts, ViaDoctrineForm: true, ViaRightColumn: false);
			Client.MustRefreshMainForm = true;
		}
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
		method_7();
	}

	private void method_34(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				foreach (ActiveUnit item in selectedUnit.Doctrine.AffectedUnits(Client.CurrentScenario, isEscorts))
				{
					if (item.IsGroup)
					{
						if (!item.Doctrine.EMCON_Inherits)
						{
							item.Doctrine.EMCON_Inherits = true;
						}
					}
					else if (item.IsActiveUnit)
					{
						if (item.IsWeapon)
						{
							continue;
						}
						if (!item.Doctrine.EMCON_Inherits)
						{
							item.Doctrine.EMCON_Inherits = true;
						}
					}
					item.Sensory.vmethod_2(item.Sensors_Cached);
				}
			}
		}
		else if ((object)Subject.GetType() != typeof(Side))
		{
			foreach (ActiveUnit item2 in doctrine_0.AffectedUnits(Client.CurrentScenario, isEscorts))
			{
				if (!item2.IsGroup)
				{
					if (item2.IsActiveUnit)
					{
						if (item2.IsWeapon)
						{
							continue;
						}
						if (!item2.Doctrine.EMCON_Inherits)
						{
							item2.Doctrine.EMCON_Inherits = true;
						}
					}
				}
				else if (!item2.Doctrine.EMCON_Inherits)
				{
					item2.Doctrine.EMCON_Inherits = true;
				}
				item2.Sensory.vmethod_2(item2.Sensors_Cached);
			}
		}
		else
		{
			foreach (ActiveUnit unit in Client.CurrentSide.Units)
			{
				if (!unit.IsGroup)
				{
					if (unit.IsActiveUnit)
					{
						if (unit.IsWeapon)
						{
							continue;
						}
						if (!unit.Doctrine.EMCON_Inherits)
						{
							unit.Doctrine.EMCON_Inherits = true;
						}
					}
				}
				else if (!unit.Doctrine.EMCON_Inherits)
				{
					unit.Doctrine.EMCON_Inherits = true;
				}
				unit.Sensory.vmethod_2(unit.Sensors_Cached);
			}
		}
		int mustRefreshMainForm;
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit2 in SelectedUnits)
			{
				selectedUnit2.Doctrine.FireEvent_EmconChanged(selectedUnit2, false, MultipleUnits: true, ViaDoctrineForm: true, ViaRightColumn: false, viaFlightPlanEditor: false);
			}
			mustRefreshMainForm = 1;
		}
		else
		{
			doctrine_0.FireEvent_EmconChanged(Subject, false, MultipleUnits: false, ViaDoctrineForm: true, ViaRightColumn: false, viaFlightPlanEditor: false);
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
		method_7();
	}

	private void method_35(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Subject) && (object)Subject.GetType() == typeof(Side))
		{
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (!mission.Doctrine.EMCON_Inherits)
				{
					mission.Doctrine.EMCON_Inherits = true;
				}
			}
		}
		int mustRefreshMainForm;
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				selectedUnit.Doctrine.FireEvent_EmconChanged(selectedUnit, false, MultipleUnits: true, ViaDoctrineForm: true, ViaRightColumn: false, viaFlightPlanEditor: false);
			}
			mustRefreshMainForm = 1;
		}
		else
		{
			doctrine_0.FireEvent_EmconChanged(Subject, false, MultipleUnits: false, ViaDoctrineForm: true, ViaRightColumn: false, viaFlightPlanEditor: false);
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
		method_7();
	}

	private void DoctrineForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		Doctrine.DoctrineChanged -= method_2;
		Doctrine.EmconChanged -= method_3;
	}

	private void DoctrineForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (Information.IsNothing((object)Subject) || (object)Subject.GetType() != typeof(Waypoint))
		{
			return;
		}
		bool flag = false;
		Waypoint value = (Waypoint)Subject;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				foreach (Mission.Flight flight2 in mission.FlightList)
				{
					if (flight2.FlightPlan.Contains(value))
					{
						Scenario currentScenario = Client.CurrentScenario;
						ActiveUnit theAU = flight2.get_ReferenceUnit(Client.CurrentScenario);
						Mission.Flight flight;
						Waypoint[] theFlightplan = (flight = flight2).FlightPlan;
						float NecessaryFuel = 0f;
						float MissionFuel = 0f;
						MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, mission, theAU, flight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission.TakeOffTime, mission.TimeOnTarget, IsMFP: false);
						flight.FlightPlan = theFlightplan;
						AMP_General.RefreshFlightPlanErrorWindow();
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (((Control)Client.FlightPlanEditorWindow).Visible)
		{
			Client.FlightPlanEditorWindow.RefreshGrid();
		}
	}

	private void method_36()
	{
		int num = 0;
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			num++;
			if (num == 1)
			{
				if (Information.IsNothing((object)selectedUnit.Doctrine.WRA))
				{
					continue;
				}
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in selectedUnit.Doctrine.WRA)
				{
					int key = item.Key;
					Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
					selectedUnit.Doctrine.WRA.TryGetValue(key, out value);
					foreach (Doctrine.WRA_FiringDoctrineEntry value9 in value.WRA_WeaponTargets.Values)
					{
						if (doctrine_0.WRA == null)
						{
							doctrine_0.WRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
						}
						if (!doctrine_0.WRA.ContainsKey(key))
						{
							Doctrine.WRA_Weapon value2 = new Doctrine.WRA_Weapon();
							doctrine_0.WRA[key] = value2;
						}
						if (doctrine_0.WRA.ContainsKey(key))
						{
							Doctrine.WRA_Weapon value3 = new Doctrine.WRA_Weapon();
							doctrine_0.WRA.TryGetValue(key, out value3);
							Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new Doctrine.WRA_FiringDoctrineEntry(value9.TargetType);
							wRA_FiringDoctrineEntry.WeaponQty = value9.WeaponQty;
							wRA_FiringDoctrineEntry.ShooterQty = value9.ShooterQty;
							wRA_FiringDoctrineEntry.SelfDefenceRange = value9.SelfDefenceRange;
							wRA_FiringDoctrineEntry.FiringRange = value9.FiringRange;
							value3.AddTo_WRAWeaponTargets(wRA_FiringDoctrineEntry);
						}
					}
				}
				continue;
			}
			if (!Information.IsNothing((object)doctrine_0.WRA))
			{
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item2 in doctrine_0.WRA)
				{
					int key2 = item2.Key;
					Doctrine.WRA_Weapon value4 = new Doctrine.WRA_Weapon();
					doctrine_0.WRA.TryGetValue(key2, out value4);
					foreach (Doctrine.WRA_FiringDoctrineEntry value10 in value4.WRA_WeaponTargets.Values)
					{
						if (Information.IsNothing((object)selectedUnit.Doctrine.WRA) || !selectedUnit.Doctrine.WRA.ContainsKey(key2))
						{
							continue;
						}
						Doctrine.WRA_Weapon value5 = new Doctrine.WRA_Weapon();
						selectedUnit.Doctrine.WRA.TryGetValue(key2, out value5);
						if (Information.IsNothing((object)value5))
						{
							continue;
						}
						foreach (Doctrine.WRA_FiringDoctrineEntry value11 in value5.WRA_WeaponTargets.Values)
						{
							if (value10.TargetType == value11.TargetType)
							{
								_ = value11.ShooterQty;
								break;
							}
						}
					}
				}
			}
			if (Information.IsNothing((object)selectedUnit.Doctrine.WRA))
			{
				continue;
			}
			foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item3 in selectedUnit.Doctrine.WRA)
			{
				int key3 = item3.Key;
				Doctrine.WRA_Weapon value6 = new Doctrine.WRA_Weapon();
				selectedUnit.Doctrine.WRA.TryGetValue(key3, out value6);
				foreach (Doctrine.WRA_FiringDoctrineEntry value12 in value6.WRA_WeaponTargets.Values)
				{
					if (Information.IsNothing((object)doctrine_0.WRA))
					{
						doctrine_0.WRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
					}
					if (!doctrine_0.WRA.ContainsKey(key3))
					{
						Doctrine.WRA_Weapon value7 = new Doctrine.WRA_Weapon();
						doctrine_0.WRA[key3] = value7;
					}
					if (!doctrine_0.WRA.ContainsKey(key3))
					{
						continue;
					}
					Doctrine.WRA_Weapon value8 = new Doctrine.WRA_Weapon();
					doctrine_0.WRA.TryGetValue(key3, out value8);
					bool flag = false;
					foreach (Doctrine.WRA_FiringDoctrineEntry value13 in value8.WRA_WeaponTargets.Values)
					{
						if (value13.TargetType != value12.TargetType)
						{
							continue;
						}
						flag = true;
						int? weaponQty = value13.WeaponQty;
						bool? flag2 = ((!weaponQty.HasValue) ? ((bool?)null) : new bool?(weaponQty == -100));
						int? weaponQty2;
						if (((!flag2) ?? flag2) == true || Information.IsNothing((object)value13.WeaponQty))
						{
							if (!Information.IsNothing((object)value13.WeaponQty) && !Information.IsNothing((object)value12.WeaponQty))
							{
								weaponQty = value13.WeaponQty;
								weaponQty2 = value12.WeaponQty;
								if (((!(weaponQty.HasValue & weaponQty2.HasValue)) ? ((bool?)null) : new bool?(weaponQty.GetValueOrDefault() != weaponQty2.GetValueOrDefault())) == true)
								{
									value13.WeaponQty = -100;
								}
							}
							else if (Information.IsNothing((object)value13.WeaponQty) && !Information.IsNothing((object)value12.WeaponQty))
							{
								value13.WeaponQty = -100;
							}
							else if (!Information.IsNothing((object)value13.WeaponQty) && Information.IsNothing((object)value12.WeaponQty))
							{
								value13.WeaponQty = -100;
							}
						}
						weaponQty2 = value13.ShooterQty;
						flag2 = (weaponQty2.HasValue ? new bool?(weaponQty2 == -100) : ((bool?)null));
						if (((!flag2) ?? flag2) == true || Information.IsNothing((object)value13.ShooterQty))
						{
							if (!Information.IsNothing((object)value13.ShooterQty) && !Information.IsNothing((object)value12.ShooterQty))
							{
								weaponQty2 = value13.ShooterQty;
								weaponQty = value12.ShooterQty;
								if (((!(weaponQty2.HasValue & weaponQty.HasValue)) ? ((bool?)null) : new bool?(weaponQty2.GetValueOrDefault() != weaponQty.GetValueOrDefault())) == true)
								{
									value13.ShooterQty = -100;
								}
							}
							else if (Information.IsNothing((object)value13.ShooterQty) && !Information.IsNothing((object)value12.ShooterQty))
							{
								value13.ShooterQty = -100;
							}
							else if (!Information.IsNothing((object)value13.ShooterQty) && Information.IsNothing((object)value12.ShooterQty))
							{
								value13.ShooterQty = -100;
							}
						}
						float? selfDefenceRange = value13.SelfDefenceRange;
						flag2 = (selfDefenceRange.HasValue ? new bool?(selfDefenceRange.GetValueOrDefault() == -100f) : ((bool?)null));
						float? selfDefenceRange2;
						if (((!flag2) ?? flag2) == true || Information.IsNothing((object)value13.SelfDefenceRange))
						{
							if (!Information.IsNothing((object)value13.SelfDefenceRange) && !Information.IsNothing((object)value12.SelfDefenceRange))
							{
								selfDefenceRange = value13.SelfDefenceRange;
								selfDefenceRange2 = value12.SelfDefenceRange;
								if (((!(selfDefenceRange.HasValue & selfDefenceRange2.HasValue)) ? ((bool?)null) : new bool?(selfDefenceRange.GetValueOrDefault() != selfDefenceRange2.GetValueOrDefault())) == true)
								{
									value13.SelfDefenceRange = -100f;
								}
							}
							else if (Information.IsNothing((object)value13.SelfDefenceRange) && !Information.IsNothing((object)value12.SelfDefenceRange))
							{
								value13.SelfDefenceRange = -100f;
							}
							else if (!Information.IsNothing((object)value13.SelfDefenceRange) && Information.IsNothing((object)value12.SelfDefenceRange))
							{
								value13.SelfDefenceRange = -100f;
							}
						}
						selfDefenceRange2 = value13.FiringRange;
						flag2 = (selfDefenceRange2.HasValue ? new bool?(selfDefenceRange2.GetValueOrDefault() == -100f) : ((bool?)null));
						if (((!flag2) ?? flag2) != true && !Information.IsNothing((object)value13.FiringRange))
						{
							break;
						}
						if (!Information.IsNothing((object)value13.FiringRange) && !Information.IsNothing((object)value12.FiringRange))
						{
							selfDefenceRange2 = value13.FiringRange;
							selfDefenceRange = value12.FiringRange;
							if (((!(selfDefenceRange2.HasValue & selfDefenceRange.HasValue)) ? ((bool?)null) : new bool?(selfDefenceRange2.GetValueOrDefault() != selfDefenceRange.GetValueOrDefault())) == true)
							{
								value13.FiringRange = -100f;
							}
						}
						else if (Information.IsNothing((object)value13.FiringRange) && !Information.IsNothing((object)value12.FiringRange))
						{
							value13.FiringRange = -100f;
						}
						else if (!Information.IsNothing((object)value13.FiringRange) && Information.IsNothing((object)value12.FiringRange))
						{
							value13.FiringRange = -100f;
						}
						break;
					}
					if (!flag)
					{
						Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 = new Doctrine.WRA_FiringDoctrineEntry(value12.TargetType);
						if (!Information.IsNothing((object)value12.WeaponQty))
						{
							wRA_FiringDoctrineEntry2.WeaponQty = -100;
						}
						if (!Information.IsNothing((object)value12.ShooterQty))
						{
							wRA_FiringDoctrineEntry2.ShooterQty = -100;
						}
						if (!Information.IsNothing((object)value12.SelfDefenceRange))
						{
							wRA_FiringDoctrineEntry2.SelfDefenceRange = -100f;
						}
						if (!Information.IsNothing((object)value12.FiringRange))
						{
							wRA_FiringDoctrineEntry2.FiringRange = -100f;
						}
						value8.AddTo_WRAWeaponTargets(wRA_FiringDoctrineEntry2);
					}
				}
			}
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	public DoctrineForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((Form)this).Load += DoctrineForm_Load;
		((Control)this).KeyDown += new KeyEventHandler(DoctrineForm_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(DoctrineForm_FormClosed);
		((Form)this).FormClosing += new FormClosingEventHandler(DoctrineForm_FormClosing);
		((Form)this).FormClosing += new FormClosingEventHandler(DoctrineForm_FormClosing_1);
		((Form)this).Shown += DoctrineForm_Shown;
		RTMPEnabled = true;
		rgcSmyflIiU = new List<int>();
		bool_3 = true;
		isAirOps = false;
		isBoatOps = false;
		isMissionEdit = false;
		isEscorts = false;
		bool_4 = false;
		IntermittentEmissionSelectedAlertLevel = null;
		IntervalComboboxReference = new int[13];
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
		bool_5 = false;
		bool_6 = true;
		InitializeComponent_1();
	}

	private void method_37()
	{
		SendMessage(((Control)this).Handle, 11, new IntPtr(0), IntPtr.Zero);
		MyProject.Forms.MainForm.RightColumnWPF1.SuspendRefresh();
	}

	private void method_38(bool bool_7 = true)
	{
		SendMessage(((Control)this).Handle, 11, new IntPtr(-1), IntPtr.Zero);
		if (bool_7)
		{
			((Control)this).Refresh();
		}
		MyProject.Forms.MainForm.RightColumnWPF1.ResumeRefresh();
	}

	public void RefreshSelectedUnits(ScenarioObject theScenObject, ref ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits, ref List<ActiveUnit> theSelectedActiveUnit)
	{
		bool_6 = false;
		if (!Information.IsNothing((object)theSelectedActiveUnit))
		{
			if (theSelectedActiveUnit.Count == 1)
			{
				if (!theSelectedActiveUnit[0].IsContact() && theSelectedActiveUnit[0].get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					Subject = theSelectedActiveUnit[0];
					SelectedUnits = null;
				}
				return;
			}
			SelectedUnits = new List<ActiveUnit>();
			isAirOps = true;
			foreach (ActiveUnit item2 in theSelectedActiveUnit)
			{
				if (!item2.IsContact() && item2.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					SelectedUnits.Add(item2);
				}
			}
			Subject = null;
		}
		else if (!Information.IsNothing((object)theSelectedUnits) && theSelectedUnits.Count > 1)
		{
			SelectedUnits = new List<ActiveUnit>();
			foreach (Module_Unit.Unit theSelectedUnit in theSelectedUnits)
			{
				if (!theSelectedUnit.IsContact() && theSelectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide && !theSelectedUnit.IsWeapon)
				{
					ActiveUnit item = (ActiveUnit)theSelectedUnit;
					SelectedUnits.Add(item);
				}
			}
			Subject = null;
		}
		else
		{
			if (Information.IsNothing((object)theScenObject))
			{
				return;
			}
			if (theScenObject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)theScenObject;
				if (!activeUnit.IsContact() && activeUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					Subject = theScenObject;
				}
			}
			else if ((object)theScenObject.GetType() == typeof(Side))
			{
				Subject = theScenObject;
			}
			else if ((object)theScenObject.GetType() == typeof(Waypoint))
			{
				Subject = theScenObject;
			}
		}
	}

	public void RefreshSelectedUnits(ScenarioObject theScenObject)
	{
		if (theScenObject != null && (object)theScenObject.GetType() == typeof(Side))
		{
			return;
		}
		if (theScenObject != null && (object)theScenObject.GetType() == typeof(Waypoint))
		{
			SelectedUnits = null;
			Subject = theScenObject;
			return;
		}
		if (!Information.IsNothing((object)SelectedUnits))
		{
			SelectedUnits.Clear();
		}
		else
		{
			SelectedUnits = new List<ActiveUnit>();
		}
		Subject = null;
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (!Information.IsNothing((object)theScenObject))
		{
			if (theScenObject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)theScenObject;
				if (activeUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					Subject = theScenObject;
					list.Add(activeUnit);
				}
			}
			else if ((object)theScenObject.GetType() == typeof(Side))
			{
				Subject = theScenObject;
				list.AddRange(((Side)Subject).Units);
			}
			else if (!theScenObject.IsMission)
			{
				if (theScenObject.IsGroup)
				{
					Subject = theScenObject;
					list.AddRange(((Group)Subject).Units.Values);
				}
			}
			else
			{
				Subject = theScenObject;
				list.AddRange(((Mission)Subject).UnitsAssignedToMission.Values);
				list.AddRange(((Mission)Subject).UnitsQueuedToMission.Values);
			}
		}
		for (int i = list.Count - 1; i >= 0; i += -1)
		{
			if (list[i].IsContact() || list[i].IsWeapon)
			{
				list.RemoveAt(i);
			}
		}
		if (!isMissionEdit)
		{
			SelectedUnits.AddRange(list);
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		IntermittentEmissionSelectedAlertLevel = EmconLevel.GetAlertEnumWithString(((Control)((TabControl)EmissionIntervalTABControl).SelectedTab).Tag.ToString());
		method_40();
	}

	private void method_40()
	{
		try
		{
			if (!Information.IsNothing((object)Subject) && Subject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				EmconLevel emconAlertness = activeUnit.get_UnitSide(SetSideOnly: false).EmconAlertness;
				if (!IntermittentEmissionSelectedAlertLevel.HasValue)
				{
					if (!activeUnit.Sensory.GetIntermittentEmission().UseCustomPresetOnly)
					{
						IntermittentEmissionSelectedAlertLevel = emconAlertness.Level;
					}
					else
					{
						IntermittentEmissionSelectedAlertLevel = Alertlevels.Custom;
					}
				}
				int? num = (int?)IntermittentEmissionSelectedAlertLevel;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num != 999)) == true)
				{
					((TabControl)EmissionIntervalTABControl).SelectedIndex = (int)IntermittentEmissionSelectedAlertLevel.Value;
				}
				((ComboBox)Combo_AlertLevel).SelectedIndex = (int)activeUnit.get_UnitSide(SetSideOnly: false).EmconAlertness.Level;
				if (!activeUnit.IsGroup)
				{
					if (activeUnit.Sensors_ReadOnly().Length == 0)
					{
						method_47(bool_7: false);
						return;
					}
					((Control)CBIntermittentEmission_InheritFromGroup).Visible = true;
				}
				else
				{
					((Control)CBIntermittentEmission_InheritFromGroup).Visible = false;
				}
				IntervalConfigs = method_44();
				ActiveEmissionInterval intermittentEmission = activeUnit.Sensory.GetIntermittentEmission();
				if (IntervalConfigs != null)
				{
					method_47(bool_7: true);
					method_46(IntervalConfigs.UseEmissionInterval);
					if (IntervalConfigs.UseEmissionInterval)
					{
						IntermittantToggle.Text = "INTERMITTENT mode";
					}
					else
					{
						IntermittantToggle.Text = "CONTINUOUS mode";
					}
					Interval.Text = IntervalConfigs.EmissionInterval.ToString();
					IntervalVariation.Text = IntervalConfigs.EmissionIntervalVariation.ToString();
					((CheckBox)CBWakeWhenDetectingThreat).Checked = IntervalConfigs.WakeWhenDetectingThreat;
					BackToSleepTime.Text = IntervalConfigs.SleepModeDelay.ToString();
					((CheckBox)CB_IntermittentEmission_USECUSTOM).Checked = intermittentEmission.UseCustomPresetOnly;
					((CheckBox)CBIntermittentEmission_InheritFromGroup).Checked = intermittentEmission.InheritParentGroupConfig;
					method_41(activeUnit);
					EmissionDurationTextBox.Text = IntervalConfigs.EmissionDuration.ToString();
					((Label)DEBUGINTERMITTENT1).Text = intermittentEmission.GetTimeRemainingNextInterval().ToString();
					((Control)EmissionIntervalPhonyTab).BackColor = EmconLevel.GetAlertColor(IntermittentEmissionSelectedAlertLevel.Value, DarkenedColor: true);
					method_42();
				}
			}
			else
			{
				method_47(bool_7: false);
				((ComboBox)Combo_AlertLevel).SelectedIndex = (int)Client.CurrentSide.EmconAlertness.Level;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at INTER_E_01", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_41(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing((object)activeUnit_0))
		{
			activeUnit_0 = (ActiveUnit)Subject;
		}
		if (!Information.IsNothing((object)activeUnit_0))
		{
			if (Information.IsNothing((object)activeUnit_0.get_ParentGroup(UsingMissionPlanner: false)))
			{
				((Control)CB_IntermittentEmission_USECUSTOM).Visible = true;
				((Control)CBIntermittentEmission_InheritFromGroup).Visible = false;
			}
			else
			{
				((Control)CB_IntermittentEmission_USECUSTOM).Visible = !activeUnit_0.Sensory.GetIntermittentEmission().InheritParentGroupConfig;
				((Control)CBIntermittentEmission_InheritFromGroup).Visible = true;
			}
		}
	}

	private void method_42()
	{
		((Control)CBWakeWhenDetectingThreat).Visible = IntervalConfigs.UseEmissionInterval;
		((Control)WakeGroupBox).Visible = IntervalConfigs.UseEmissionInterval && IntervalConfigs.WakeWhenDetectingThreat;
		if (IntervalConfigs.WakeWhenDetectingThreat)
		{
			BackToSleepTime.Text = IntervalConfigs.SleepModeDelay.ToString();
			CB_IncludesStance_Friendly.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Friendly];
			CB_IncludesStance_Neutral.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Neutral];
			CB_IncludesStance_Unfriendly.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly];
			CB_IncludesStance_Hostile.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Hostile];
			CB_IncludesStance_Unknown.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unknown];
			CB_IncludesID_Unknown.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown];
			CB_IncludesID_KnownDomain.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain];
			CB_IncludesID_KnowType.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType];
			CB_IncludesID_KnownClass.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass];
			CB_IncludesID_KnownID.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID];
		}
	}

	private void method_43(bool bool_7)
	{
		((Control)Label_AEI_3).Visible = bool_7;
		((Control)BackToSleepTime).Visible = bool_7;
		((Control)Includes).Visible = bool_7;
		((Control)CB_IncludesStance_Friendly).Visible = bool_7;
		((Control)CB_IncludesStance_Neutral).Visible = bool_7;
		((Control)CB_IncludesStance_Unfriendly).Visible = bool_7;
		((Control)CB_IncludesStance_Hostile).Visible = bool_7;
		((Control)CB_IncludesStance_Unknown).Visible = bool_7;
		((Control)DarkLabel6).Visible = bool_7;
		((Control)DarkLabel7).Visible = bool_7;
		((Control)IncludesIDGroup).Visible = bool_7;
		((Control)CB_IncludesID_Unknown).Visible = bool_7;
		((Control)CB_IncludesID_KnownDomain).Visible = bool_7;
		((Control)CB_IncludesID_KnowType).Visible = bool_7;
		((Control)CB_IncludesID_KnownClass).Visible = bool_7;
		((Control)CB_IncludesID_KnownID).Visible = bool_7;
	}

	private ActiveEmissionInterval_Config method_44()
	{
		if (!Information.IsNothing((object)Subject) && Subject.IsActiveUnit)
		{
			ActiveEmissionInterval intermittentEmission = ((ActiveUnit)Subject).Sensory.GetIntermittentEmission();
			if (IntermittentEmissionSelectedAlertLevel.HasValue)
			{
				return intermittentEmission.Configs[IntermittentEmissionSelectedAlertLevel.Value];
			}
		}
		return null;
	}

	private ActiveEmissionInterval method_45()
	{
		if (IntervalConfigs != null)
		{
			if (!Information.IsNothing((object)Subject) && Subject.IsActiveUnit)
			{
				return ((ActiveUnit)Subject).Sensory.GetIntermittentEmission();
			}
			return null;
		}
		return null;
	}

	private void method_46(bool bool_7, bool bool_8 = true)
	{
		((Control)IntermittantToggle).Visible = bool_8;
		((Control)EmissionDurationTextBox).Visible = bool_7;
		((Control)Interval).Visible = bool_7;
		((Control)IntervalVariation).Visible = bool_7;
		((Control)LabelPlus).Visible = bool_7;
		((Control)BackToSleepTime).Visible = bool_7;
		((Control)Label_AEI_0).Visible = bool_7;
		((Control)Label_AEI_1).Visible = bool_7;
		((Control)Label_AEI_2).Visible = bool_7;
		((Control)Label_AEI_3).Visible = bool_7;
	}

	private void method_47(bool bool_7)
	{
		((Control)UseIntervalGroup).Visible = bool_7;
		((Control)EmissionIntervalPhonyTab).Visible = bool_7;
	}

	private void method_48()
	{
		try
		{
			if (!Client.Realtime || Subject == null || !Subject.IsActiveUnit)
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)Subject;
			object terminalRenderLockObj = Client.RealtimeTerminal.TerminalRenderLockObj;
			ObjectFlowControl.CheckForSyncLockOnValueType(terminalRenderLockObj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(terminalRenderLockObj, ref lockTaken);
				if (IntervalConfigs != null && IntermittentEmissionSelectedAlertLevel.HasValue)
				{
					ActiveEmissionInterval intermittentEmission = activeUnit.Sensory.GetIntermittentEmission();
					if (intermittentEmission.Configs.ContainsKey(IntermittentEmissionSelectedAlertLevel.Value))
					{
						intermittentEmission.Configs[IntermittentEmissionSelectedAlertLevel.Value] = IntervalConfigs;
					}
					else
					{
						intermittentEmission.Configs.Add(IntermittentEmissionSelectedAlertLevel.Value, IntervalConfigs);
					}
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(terminalRenderLockObj);
				}
			}
			Client.RealtimeTerminal.SendIntermittentEmissionUpdate(activeUnit);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 999999", "");
			ProjectData.ClearProjectError();
		}
	}

	private void method_49()
	{
		if (Client.Realtime && Client.CurrentSide != null)
		{
			Client.RealtimeTerminal.SendSideAlertnessUpdate(Client.CurrentSide);
		}
	}

	private void method_50(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = method_45();
		if (activeEmissionInterval != null)
		{
			activeEmissionInterval.ToggleEmissionMode(method_44());
			method_48();
			method_40();
		}
	}

	private void method_51(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = method_45();
		if (activeEmissionInterval != null)
		{
			activeEmissionInterval.ToggleSleep_Wake();
			method_48();
			method_40();
		}
	}

	private void method_52(object object_0)
	{
		if (IntervalConfigs == null)
		{
			return;
		}
		Control val = (Control)((object_0 is Control) ? object_0 : null);
		if (val == null || !float.TryParse(val.Text, out var result))
		{
			return;
		}
		string name = val.Name;
		if (Operators.CompareString(name, "Interval", true) == 0)
		{
			IntervalConfigs.EmissionInterval = result;
		}
		else if (Operators.CompareString(name, "IntervalVariation", true) != 0)
		{
			if (Operators.CompareString(name, "BackToSleepTime", true) == 0)
			{
				IntervalConfigs.SleepModeDelay = result;
			}
			else if (Operators.CompareString(name, "EmissionDurationTextBox", true) == 0)
			{
				IntervalConfigs.EmissionDuration = result;
			}
		}
		else
		{
			IntervalConfigs.EmissionIntervalVariation = result;
		}
		method_48();
	}

	private void DoctrineForm_FormClosing_1(object sender, FormClosingEventArgs e)
	{
		((Form)this).ValidateChildren();
		method_53();
	}

	private void method_53()
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.EmissionInterval = method_54(Interval.Text);
			IntervalConfigs.EmissionIntervalVariation = method_54(IntervalVariation.Text);
			IntervalConfigs.SleepModeDelay = method_54(BackToSleepTime.Text);
			IntervalConfigs.EmissionDuration = method_54(EmissionDurationTextBox.Text);
			method_48();
		}
	}

	private float method_54(string string_0)
	{
		if (!float.TryParse(string_0, out var result))
		{
			return 0f;
		}
		return result;
	}

	private void method_55(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.WakeWhenDetectingThreat = ((CheckBox)CBWakeWhenDetectingThreat).Checked;
			method_48();
			method_42();
		}
	}

	private void method_56(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Client.CurrentSide))
		{
			Client.CurrentSide.EmconAlertness.Level = (Alertlevels)((ComboBox)Combo_AlertLevel).SelectedIndex;
			method_49();
		}
	}

	private void method_57(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Friendly] = CB_IncludesStance_Friendly.Checked;
			method_48();
		}
	}

	private void method_58(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Neutral] = CB_IncludesStance_Neutral.Checked;
			method_48();
		}
	}

	private void method_59(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = CB_IncludesStance_Unfriendly.Checked;
			method_48();
		}
	}

	private void method_60(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Hostile] = CB_IncludesStance_Hostile.Checked;
			method_48();
		}
	}

	private void method_61(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unknown] = CB_IncludesStance_Unknown.Checked;
			method_48();
		}
	}

	private void method_62(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = CB_IncludesID_Unknown.Checked;
			method_48();
		}
	}

	private void method_63(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = CB_IncludesID_KnownDomain.Checked;
			method_48();
		}
	}

	private void method_64(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = CB_IncludesID_KnowType.Checked;
			method_48();
		}
	}

	private void method_65(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = CB_IncludesID_KnownClass.Checked;
			method_48();
		}
	}

	private void method_66(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = CB_IncludesID_KnownID.Checked;
			method_48();
		}
	}

	private void method_67(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.FollowWRAforWakeBehavior = ((CheckBox)CB_EmconFollowsWRARules).Checked;
			method_48();
		}
	}

	private void method_68(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = method_45();
		if (activeEmissionInterval != null && IntervalConfigs != null)
		{
			activeEmissionInterval.UseCustomPresetOnly = ((CheckBox)CB_IntermittentEmission_USECUSTOM).Checked;
			method_48();
			method_41(null);
		}
	}

	private void method_69(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = method_45();
		if (activeEmissionInterval != null && IntervalConfigs != null)
		{
			activeEmissionInterval.InheritParentGroupConfig = ((CheckBox)CBIntermittentEmission_InheritFromGroup).Checked;
			method_48();
			method_41(null);
		}
	}

	private void method_70(object sender, EventArgs e)
	{
		int num = method_75();
		if (num > -1)
		{
			doctrine_0.SwapPriorityTargetListEntry(num, up: true);
			if (num > 0)
			{
				RefreshPriorityTargetList(doctrine_0, num - 1);
			}
		}
	}

	private void DoctrineForm_Shown(object sender, EventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).SuspendLayout();
		method_4();
		Refreshinfo();
		IntermittentEmissionSelectedAlertLevel = null;
		if (((TabControl)TabControl1A).SelectedIndex == 1)
		{
			method_40();
		}
		IntervalComboboxReference = new int[12]
		{
			1, 5, 10, 15, 30, 45, 60, 300, 600, 900,
			3600, 7200
		};
		foreach (TabPage tabPage in ((TabControl)TabControl1A).TabPages)
		{
			tabPage.BackColor = Colors.GreyBackground;
		}
		((Control)this).ResumeLayout();
	}

	public void RefreshForm()
	{
		Refreshinfo();
	}

	private void method_71(object sender, EventArgs e)
	{
		int num = method_75();
		if (num > -1)
		{
			doctrine_0.SwapPriorityTargetListEntry(num, up: false);
			RefreshPriorityTargetList(doctrine_0, num + 1);
		}
	}

	private void method_72(object sender, EventArgs e)
	{
		MyProject.Forms.PriorityTargetForm.ParentDoctrine = doctrine_0;
		MyProject.Forms.PriorityTargetForm.MainDoctrineForm = this;
		MyProject.Forms.PriorityTargetForm.InsertIndex = method_75();
		((Control)MyProject.Forms.PriorityTargetForm).Show();
	}

	private void method_73(object sender, EventArgs e)
	{
		int num = method_75();
		if (num > -1)
		{
			doctrine_0.DeletePriorityTargetListEntry(num);
			RefreshPriorityTargetList(doctrine_0, num);
		}
	}

	private void method_74(object sender, EventArgs e)
	{
	}

	private int method_75()
	{
		if (List_TargetPriority.SelectedIndices != null && List_TargetPriority.SelectedIndices.Count > 0)
		{
			return List_TargetPriority.SelectedIndices.FirstOrDefault();
		}
		return -1;
	}

	private void method_76(object sender, EventArgs e)
	{
		doctrine_0.CreatePriorityTargetList();
		method_10();
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine_0, null);
		}
	}

	private void method_77(object sender, EventArgs e)
	{
		doctrine_0.RemovePriorityTargetList();
		method_10();
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine_0, null);
		}
	}

	static DoctrineForm()
	{
		Class72.smethod_20();
	}
}
