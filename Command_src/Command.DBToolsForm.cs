using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace Command;

[DesignerGenerated]
public class DBToolsForm : DarkSecondaryFormBase
{
	public enum MergeCandidateStatus
	{
		Pending,
		Successful,
		Failed
	}

	public class MergeCandidateWrapper
	{
		public DBToolsForm Ui;

		public string ID;

		private MergeCandidateStatus mergeCandidateStatus_0;

		public MergeCandidateWrapper(string ID, DBToolsForm UI)
		{
			this.ID = ID;
			Ui = UI;
			mergeCandidateStatus_0 = MergeCandidateStatus.Pending;
		}

		public void SetStatus(MergeCandidateStatus value, bool RefreshUI)
		{
			mergeCandidateStatus_0 = value;
			if (RefreshUI)
			{
				Ui.Refresh_LV_CopyOverStatus();
			}
		}

		public MergeCandidateStatus GetStatus()
		{
			return mergeCandidateStatus_0;
		}

		static MergeCandidateWrapper()
		{
			Class72.smethod_20();
		}
	}

	public class LV_Item_ComboMergeCandidate
	{
		public string Table;

		public string _Name;

		public DBToolsForm MainFormReference;

		public string Name => _Name;

		public LV_Item_ComboMergeCandidate(string _Value, string _DisplayName, DBToolsForm _FormRef)
		{
			Table = _Value;
			_Name = _DisplayName;
			MainFormReference = _FormRef;
		}

		static LV_Item_ComboMergeCandidate()
		{
			Class72.smethod_20();
		}
	}

	public enum OperationFilterType
	{
		RamdbRoutine,
		RamDB,
		SQL
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("OpenFileDialog_SourceDB")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("OpenFileDialog_TargetDB")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[AccessedThroughProperty("BW_ConvertDB")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_UpdateSchema")]
	private BackgroundWorker backgroundWorker_1;

	[AccessedThroughProperty("Button_CreateRamDBPair")]
	[CompilerGenerated]
	private DarkButton _Button_CreateRamDBPair;

	[AccessedThroughProperty("Button_StartImport")]
	[CompilerGenerated]
	private DarkButton _Button_StartImport;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel FfbOqYlkde;

	[AccessedThroughProperty("Button_DeepCopyLoadouts")]
	[CompilerGenerated]
	private DarkButton _Button_DeepCopyLoadouts;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("SelectAll")]
	private DarkCheckBox _SelectAll;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_CSVOutput")]
	private DarkCheckBox _CheckBox_CSVOutput;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkButton _Button4;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CSVExportFilePathBrowse")]
	private DarkButton _Button_CSVExportFilePathBrowse;

	[AccessedThroughProperty("OpenFileDialog_CSVExportPath")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_2;

	[AccessedThroughProperty("CSV_Update_Button")]
	[CompilerGenerated]
	private DarkButton _CSV_Update_Button;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_3;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkButton _Button5;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_SImilarityThreshold")]
	private TrackBar _TB_SImilarityThreshold;

	[AccessedThroughProperty("Toggle_MergeMethod")]
	[CompilerGenerated]
	private DarkButton _Toggle_MergeMethod;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SelectTargetDB")]
	private DarkButton _Button_SelectTargetDB;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SelectSourceDB")]
	private DarkButton _Button_SelectSourceDB;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_MergeCandidate")]
	private DarkRichTextBox _TB_MergeCandidate;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_MergeCandidate")]
	private ComboBox _Combo_MergeCandidate;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_WorkNode")]
	private DarkListView _LV_WorkNode;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LuaClear")]
	private DarkButton _Button_LuaClear;

	[AccessedThroughProperty("Button_LuaRun")]
	[CompilerGenerated]
	private DarkButton _Button_LuaRun;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AutoCopyOverMode_External")]
	private DarkCheckBox uZcAlAgvWf;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LoadSetup")]
	private DarkButton _Button_LoadSetup;

	[CompilerGenerated]
	[AccessedThroughProperty("BrowseDatabasePairButton")]
	private DarkButton _BrowseDatabasePairButton;

	[CompilerGenerated]
	[AccessedThroughProperty("PerformCopyOverButton")]
	private DarkButton _PerformCopyOverButton;

	[CompilerGenerated]
	[AccessedThroughProperty("LuaPrintMethods")]
	private DarkButton _LuaPrintMethods;

	[CompilerGenerated]
	[AccessedThroughProperty("FilterRamDBRoutine")]
	private DarkButton UvwArVrxVY;

	[AccessedThroughProperty("FilterRamDB")]
	[CompilerGenerated]
	private DarkButton _FilterRamDB;

	[CompilerGenerated]
	[AccessedThroughProperty("FilterSQL")]
	private DarkButton darkButton_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonSaveOperationStack")]
	private DarkButton RbjAbdlWaG;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRamDBJson")]
	private DarkButton _ButtonRamDBJson;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BoostCoastTweaker")]
	private DarkButton _Button_BoostCoastTweaker;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BoostCoastTweak_SelectDB")]
	private DarkButton _Button_BoostCoastTweak_SelectDB;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_Validate")]
	private BackgroundWorker backgroundWorker_2;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_CopyOver")]
	private BackgroundWorker backgroundWorker_3;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_Import")]
	private BackgroundWorker backgroundWorker_4;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private Exception exception_0;

	private bool bool_2;

	public bool DebugMode;

	public string DebugPath;

	public Dictionary<OperationFilterType, Button> OperationFilters;

	public HashSet<OperationFilterType> OperationFiltersState;

	public List<(OperationFilterType, string)> OperationStack;

	public bool bool_3;

	private string string_0;

	private string string_1;

	public Dictionary<string, Dictionary<int, int>> dictionary_0;

	public string EligibleCSV_Path;

	public JsonCollection_RamDBConfigs Config;

	private MergeMethod_E mergeMethod_E_0;

	public ComparisonDepth MergeComparisonResolution;

	public bool _PendingCopyOverAbortion;

	public RamDB_Lua LuaInterpreter;

	public CopyOver copyoverins;

	public Dictionary<string, Dictionary<string, MergeCandidateWrapper>> MergeCandidates;

	public string currentMergeCandidateTableSelection;

	private OpenFileDialog openFileDialog_4;

	internal virtual OpenFileDialog OpenFileDialog_SourceDB
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

	internal virtual OpenFileDialog OpenFileDialog_TargetDB
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_1;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_1 = value;
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
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

	internal virtual BackgroundWorker BW_ConvertDB
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_7;
			RunWorkerCompletedEventHandler value3 = method_8;
			BackgroundWorker backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			backgroundWorker_0 = value;
			backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("CB_OperationalYearsAndService")]
	public virtual DarkCheckBox CB_OperationalYearsAndService { get; set; }

	[field: AccessedThroughProperty("CB_CopyOver")]
	public virtual DarkCheckBox CB_CopyOver { get; set; }

	[field: AccessedThroughProperty("CB_MissingComponents")]
	public virtual DarkCheckBox CB_MissingComponents { get; set; }

	[field: AccessedThroughProperty("CB_Aircraft")]
	internal virtual DarkCheckBox CB_Aircraft { get; set; }

	[field: AccessedThroughProperty("CB_Weapons")]
	internal virtual DarkCheckBox CB_Weapons { get; set; }

	[field: AccessedThroughProperty("CB_Satellites")]
	internal virtual DarkCheckBox CB_Satellites { get; set; }

	[field: AccessedThroughProperty("CB_Facilities")]
	internal virtual DarkCheckBox CB_Facilities { get; set; }

	[field: AccessedThroughProperty("CB_Submarines")]
	internal virtual DarkCheckBox CB_Submarines { get; set; }

	[field: AccessedThroughProperty("CB_Ships")]
	internal virtual DarkCheckBox CB_Ships { get; set; }

	[field: AccessedThroughProperty("CB_Propulsion")]
	internal virtual DarkCheckBox CB_Propulsion { get; set; }

	[field: AccessedThroughProperty("CB_Mounts")]
	internal virtual DarkCheckBox CB_Mounts { get; set; }

	[field: AccessedThroughProperty("CB_Magazines")]
	internal virtual DarkCheckBox CB_Magazines { get; set; }

	[field: AccessedThroughProperty("CB_CommDevices")]
	internal virtual DarkCheckBox CB_CommDevices { get; set; }

	[field: AccessedThroughProperty("CB_DockFacs")]
	internal virtual DarkCheckBox CB_DockFacs { get; set; }

	[field: AccessedThroughProperty("CB_AirFacs")]
	internal virtual DarkCheckBox CB_AirFacs { get; set; }

	[field: AccessedThroughProperty("CB_Loadouts")]
	internal virtual DarkCheckBox CB_Loadouts { get; set; }

	[field: AccessedThroughProperty("CB_Sensors")]
	internal virtual DarkCheckBox CB_Sensors { get; set; }

	[field: AccessedThroughProperty("CB_Warheads")]
	internal virtual DarkCheckBox CB_Warheads { get; set; }

	[field: AccessedThroughProperty("CB_FuelRec")]
	internal virtual DarkCheckBox CB_FuelRec { get; set; }

	[field: AccessedThroughProperty("CB_WeaponRec")]
	internal virtual DarkCheckBox CB_WeaponRec { get; set; }

	[field: AccessedThroughProperty("CB_ValidateCargo")]
	internal virtual DarkCheckBox CB_ValidateCargo { get; set; }

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	internal virtual DarkButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkButton darkButton = _Button1;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkButton = _Button1;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual BackgroundWorker BW_UpdateSchema
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_1;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_12;
			RunWorkerCompletedEventHandler value3 = method_13;
			BackgroundWorker backgroundWorker = backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			backgroundWorker_1 = value;
			backgroundWorker = backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	internal virtual DarkButton Button_CreateRamDBPair
	{
		[CompilerGenerated]
		get
		{
			return _Button_CreateRamDBPair;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkButton darkButton = _Button_CreateRamDBPair;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_CreateRamDBPair = value;
			darkButton = _Button_CreateRamDBPair;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkButton Button_StartImport
	{
		[CompilerGenerated]
		get
		{
			return _Button_StartImport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = gKnIpnfmb3;
			DarkButton darkButton = _Button_StartImport;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_StartImport = value;
			darkButton = _Button_StartImport;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return FfbOqYlkde;
		}
		[CompilerGenerated]
		set
		{
			FfbOqYlkde = value;
		}
	}

	[field: AccessedThroughProperty("TabPage6")]
	internal virtual TabPage TabPage6 { get; set; }

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual DarkGroupBox GroupBox2 { get; set; }

	internal virtual DarkButton Button_DeepCopyLoadouts
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeepCopyLoadouts;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkButton darkButton = _Button_DeepCopyLoadouts;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_DeepCopyLoadouts = value;
			darkButton = _Button_DeepCopyLoadouts;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_DeepCopyLoadouts_RemoveExistingLoadouts")]
	internal virtual DarkCheckBox CB_DeepCopyLoadouts_RemoveExistingLoadouts { get; set; }

	[field: AccessedThroughProperty("TB_DeepCopyLoadouts_TargetID")]
	internal virtual DarkTextBox TB_DeepCopyLoadouts_TargetID { get; set; }

	[field: AccessedThroughProperty("TB_DeepCopyLoadouts_SourceID")]
	internal virtual DarkTextBox TB_DeepCopyLoadouts_SourceID { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual DarkButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkButton darkButton = _Button2;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkButton = _Button2;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_DeprecationChecks")]
	internal virtual DarkCheckBox CB_DeprecationChecks { get; set; }

	internal virtual DarkCheckBox SelectAll
	{
		[CompilerGenerated]
		get
		{
			return _SelectAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkCheckBox darkCheckBox = _SelectAll;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_SelectAll = value;
			darkCheckBox = _SelectAll;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_CSVOutput
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_CSVOutput;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkCheckBox darkCheckBox = _CheckBox_CSVOutput;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_CSVOutput = value;
			darkCheckBox = _CheckBox_CSVOutput;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CheckBox1")]
	internal virtual DarkCheckBox CheckBox1 { get; set; }

	internal virtual DarkButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkButton darkButton = _Button4;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button4 = value;
			darkButton = _Button4;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual DarkGroupBox GroupBox3 { get; set; }

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual DarkGroupBox GroupBox4 { get; set; }

	[field: AccessedThroughProperty("GroupBox5")]
	internal virtual DarkGroupBox GroupBox5 { get; set; }

	[field: AccessedThroughProperty("CSVOutputFilePath")]
	internal virtual DarkTextBox CSVOutputFilePath { get; set; }

	internal virtual DarkButton Button_CSVExportFilePathBrowse
	{
		[CompilerGenerated]
		get
		{
			return _Button_CSVExportFilePathBrowse;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkButton darkButton = _Button_CSVExportFilePathBrowse;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_CSVExportFilePathBrowse = value;
			darkButton = _Button_CSVExportFilePathBrowse;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog_CSVExportPath
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_2;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_2 = value;
		}
	}

	internal virtual DarkButton CSV_Update_Button
	{
		[CompilerGenerated]
		get
		{
			return _CSV_Update_Button;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkButton darkButton = _CSV_Update_Button;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_CSV_Update_Button = value;
			darkButton = _CSV_Update_Button;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_3;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_3 = value;
		}
	}

	internal virtual DarkButton Button5
	{
		[CompilerGenerated]
		get
		{
			return _Button5;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkButton darkButton = _Button5;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button5 = value;
			darkButton = _Button5;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LV_Loading")]
	internal virtual DarkListView LV_Loading { get; set; }

	[field: AccessedThroughProperty("Report")]
	internal virtual DarkRichTextBox Report { get; set; }

	[field: AccessedThroughProperty("Label_SimilarityThreshold")]
	internal virtual DarkLabel Label_SimilarityThreshold { get; set; }

	internal virtual TrackBar TB_SImilarityThreshold
	{
		[CompilerGenerated]
		get
		{
			return _TB_SImilarityThreshold;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			TrackBar val = _TB_SImilarityThreshold;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_SImilarityThreshold = value;
			val = _TB_SImilarityThreshold;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TBMergeMethodDescription")]
	internal virtual DarkRichTextBox TBMergeMethodDescription { get; set; }

	[field: AccessedThroughProperty("DataRlationGB")]
	internal virtual DarkGroupBox DataRlationGB { get; set; }

	[field: AccessedThroughProperty("ComparisonMethodGB")]
	internal virtual DarkGroupBox ComparisonMethodGB { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("ProgressBar_Job")]
	internal virtual DarkUIProgressBar ProgressBar_Job { get; set; }

	[field: AccessedThroughProperty("Label_JobInProgress")]
	internal virtual DarkLabel Label_JobInProgress { get; set; }

	internal virtual DarkButton Toggle_MergeMethod
	{
		[CompilerGenerated]
		get
		{
			return _Toggle_MergeMethod;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkButton darkButton = _Toggle_MergeMethod;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Toggle_MergeMethod = value;
			darkButton = _Toggle_MergeMethod;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_SelectTargetDB
	{
		[CompilerGenerated]
		get
		{
			return _Button_SelectTargetDB;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkButton darkButton = _Button_SelectTargetDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SelectTargetDB = value;
			darkButton = _Button_SelectTargetDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_SelectSourceDB
	{
		[CompilerGenerated]
		get
		{
			return _Button_SelectSourceDB;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkButton darkButton = _Button_SelectSourceDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SelectSourceDB = value;
			darkButton = _Button_SelectSourceDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkRichTextBox TB_MergeCandidate
	{
		[CompilerGenerated]
		get
		{
			return _TB_MergeCandidate;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(method_46);
			DarkRichTextBox darkRichTextBox = _TB_MergeCandidate;
			if (darkRichTextBox != null)
			{
				((Control)darkRichTextBox).KeyDown -= val;
			}
			_TB_MergeCandidate = value;
			darkRichTextBox = _TB_MergeCandidate;
			if (darkRichTextBox != null)
			{
				((Control)darkRichTextBox).KeyDown += val;
			}
		}
	}

	[field: AccessedThroughProperty("MergeCandidatesGB")]
	internal virtual DarkGroupBox MergeCandidatesGB { get; set; }

	internal virtual ComboBox Combo_MergeCandidate
	{
		[CompilerGenerated]
		get
		{
			return _Combo_MergeCandidate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			ComboBox val = _Combo_MergeCandidate;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_Combo_MergeCandidate = value;
			val = _Combo_MergeCandidate;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SetupGB")]
	internal virtual DarkGroupBox SetupGB { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("CB_AutoCopyOverMode")]
	internal virtual DarkCheckBox CB_AutoCopyOverMode { get; set; }

	internal virtual DarkListView LV_WorkNode
	{
		[CompilerGenerated]
		get
		{
			return _LV_WorkNode;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(method_34);
			DarkListView darkListView = _LV_WorkNode;
			if (darkListView != null)
			{
				((Control)darkListView).KeyDown -= val;
			}
			_LV_WorkNode = value;
			darkListView = _LV_WorkNode;
			if (darkListView != null)
			{
				((Control)darkListView).KeyDown += val;
			}
		}
	}

	[field: AccessedThroughProperty("ToggleComparisonResolution")]
	internal virtual DarkLabel ToggleComparisonResolution { get; set; }

	[field: AccessedThroughProperty("TB_LuaOutput")]
	internal virtual DarkRichTextBox TB_LuaOutput { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("LV_CopyOverStatus")]
	internal virtual DarkListView LV_CopyOverStatus { get; set; }

	internal virtual DarkButton Button_LuaClear
	{
		[CompilerGenerated]
		get
		{
			return _Button_LuaClear;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkButton darkButton = _Button_LuaClear;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_LuaClear = value;
			darkButton = _Button_LuaClear;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_LuaRun
	{
		[CompilerGenerated]
		get
		{
			return _Button_LuaRun;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkButton darkButton = _Button_LuaRun;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_LuaRun = value;
			darkButton = _Button_LuaRun;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GB_Automation")]
	internal virtual DarkGroupBox GB_Automation { get; set; }

	[field: AccessedThroughProperty("CB_AutoCopyOver_Commit")]
	internal virtual DarkCheckBox CB_AutoCopyOver_Commit { get; set; }

	internal virtual DarkCheckBox CB_AutoCopyOverMode_External
	{
		[CompilerGenerated]
		get
		{
			return uZcAlAgvWf;
		}
		[CompilerGenerated]
		set
		{
			uZcAlAgvWf = value;
		}
	}

	[field: AccessedThroughProperty("Label_DBStack")]
	internal virtual DarkRichTextBox Label_DBStack { get; set; }

	[field: AccessedThroughProperty("LablCurrentCallStack")]
	internal virtual DarkLabel LablCurrentCallStack { get; set; }

	[field: AccessedThroughProperty("RT_LuaInput")]
	internal virtual DarkRichTextBox RT_LuaInput { get; set; }

	internal virtual DarkButton Button_LoadSetup
	{
		[CompilerGenerated]
		get
		{
			return _Button_LoadSetup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkButton darkButton = _Button_LoadSetup;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_LoadSetup = value;
			darkButton = _Button_LoadSetup;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PairGB")]
	internal virtual DarkGroupBox PairGB { get; set; }

	[field: AccessedThroughProperty("GroupBox9")]
	internal virtual DarkGroupBox GroupBox9 { get; set; }

	internal virtual DarkButton BrowseDatabasePairButton
	{
		[CompilerGenerated]
		get
		{
			return _BrowseDatabasePairButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			DarkButton darkButton = _BrowseDatabasePairButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_BrowseDatabasePairButton = value;
			darkButton = _BrowseDatabasePairButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CopyOverGB")]
	internal virtual DarkGroupBox CopyOverGB { get; set; }

	internal virtual DarkButton PerformCopyOverButton
	{
		[CompilerGenerated]
		get
		{
			return _PerformCopyOverButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkButton darkButton = _PerformCopyOverButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_PerformCopyOverButton = value;
			darkButton = _PerformCopyOverButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PairTitle")]
	internal virtual DarkLabel PairTitle { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	[field: AccessedThroughProperty("Panel2")]
	internal virtual Panel Panel2 { get; set; }

	[field: AccessedThroughProperty("Panel3")]
	internal virtual Panel Panel3 { get; set; }

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

	[field: AccessedThroughProperty("DatabasePairSelectionGB")]
	internal virtual DarkGroupBox DatabasePairSelectionGB { get; set; }

	[field: AccessedThroughProperty("LuaConsoleGB")]
	internal virtual DarkGroupBox LuaConsoleGB { get; set; }

	internal virtual DarkButton LuaPrintMethods
	{
		[CompilerGenerated]
		get
		{
			return _LuaPrintMethods;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkButton darkButton = _LuaPrintMethods;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_LuaPrintMethods = value;
			darkButton = _LuaPrintMethods;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton FilterRamDBRoutine
	{
		[CompilerGenerated]
		get
		{
			return UvwArVrxVY;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			DarkButton darkButton = UvwArVrxVY;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			UvwArVrxVY = value;
			darkButton = UvwArVrxVY;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton FilterRamDB
	{
		[CompilerGenerated]
		get
		{
			return _FilterRamDB;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_42;
			DarkButton darkButton = _FilterRamDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_FilterRamDB = value;
			darkButton = _FilterRamDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton FilterSQL
	{
		[CompilerGenerated]
		get
		{
			return darkButton_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkButton darkButton = darkButton_0;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			darkButton_0 = value;
			darkButton = darkButton_0;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonSaveOperationStack
	{
		[CompilerGenerated]
		get
		{
			return RbjAbdlWaG;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = [SpecialName] (object sender, EventArgs e) =>
			{
				method_44(RuntimeHelpers.GetObjectValue(sender), e);
			};
			DarkButton darkButton = RbjAbdlWaG;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			RbjAbdlWaG = value;
			darkButton = RbjAbdlWaG;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_AutoPrimary")]
	internal virtual DarkCheckBox CB_AutoPrimary { get; set; }

	[field: AccessedThroughProperty("CB_AutoSecondary")]
	internal virtual DarkCheckBox CB_AutoSecondary { get; set; }

	internal virtual DarkButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkButton darkButton = _Button3;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkButton = _Button3;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonRamDBJson
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRamDBJson;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkButton darkButton = _ButtonRamDBJson;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonRamDBJson = value;
			darkButton = _ButtonRamDBJson;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Title")]
	internal virtual DarkLabel Title { get; set; }

	[field: AccessedThroughProperty("InfoMergeID")]
	internal virtual DarkButton InfoMergeID { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("InfoComparisonMethod")]
	internal virtual DarkButton InfoComparisonMethod { get; set; }

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

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("Label_BoostCoastTweaker_WeaponName")]
	internal virtual DarkLabel Label_BoostCoastTweaker_WeaponName { get; set; }

	internal virtual DarkButton Button_BoostCoastTweaker
	{
		[CompilerGenerated]
		get
		{
			return _Button_BoostCoastTweaker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			DarkButton darkButton = _Button_BoostCoastTweaker;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_BoostCoastTweaker = value;
			darkButton = _Button_BoostCoastTweaker;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_BoostCoastTweak_WeaponID")]
	internal virtual DarkTextBox TB_BoostCoastTweak_WeaponID { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("Label_BoostCoastTweaker_BoostTime")]
	internal virtual DarkLabel Label_BoostCoastTweaker_BoostTime { get; set; }

	[field: AccessedThroughProperty("TB_BoostCoastTweak_BurnoutWeight")]
	internal virtual DarkTextBox TB_BoostCoastTweak_BurnoutWeight { get; set; }

	[field: AccessedThroughProperty("TB_BoostCoastTweak_LaunchWeight")]
	internal virtual DarkTextBox TB_BoostCoastTweak_LaunchWeight { get; set; }

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("TB_BoostCoastTweak_BodyLength")]
	internal virtual DarkTextBox TB_BoostCoastTweak_BodyLength { get; set; }

	[field: AccessedThroughProperty("TB_BoostCoastTweak_BodyDiameter")]
	internal virtual DarkTextBox TB_BoostCoastTweak_BodyDiameter { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkButton Button_BoostCoastTweak_SelectDB
	{
		[CompilerGenerated]
		get
		{
			return _Button_BoostCoastTweak_SelectDB;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			DarkButton darkButton = _Button_BoostCoastTweak_SelectDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_BoostCoastTweak_SelectDB = value;
			darkButton = _Button_BoostCoastTweak_SelectDB;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_BoostCoastTweak_DBFile")]
	internal virtual DarkTextBox TB_BoostCoastTweak_DBFile { get; set; }

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	public string SourceDBPath
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			Button_SelectSourceDB.Text = "TO : " + Path.GetFileNameWithoutExtension(value);
		}
	}

	public string TargetDBPath
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			Button_SelectTargetDB.Text = "FROM : " + Path.GetFileNameWithoutExtension(value);
		}
	}

	public MergeMethod_E MergeMethod
	{
		get
		{
			return mergeMethod_E_0;
		}
		set
		{
			mergeMethod_E_0 = value;
			Toggle_MergeMethod.Text = MergeMethod.ToString().Replace("_", " ");
			if (mergeMethod_E_0 != MergeMethod_E.Same_Branch)
			{
				if (mergeMethod_E_0 == MergeMethod_E.Different_Branch)
				{
					((RichTextBox)TBMergeMethodDescription).Text = "Different branch : we assume that most IDs between both DBs are referencing  different types of items, the engine will perform comparison and suggest a list of candidates.";
				}
				else
				{
					((RichTextBox)TBMergeMethodDescription).Text = "NOT IMPLEMENTED";
				}
			}
			else
			{
				((RichTextBox)TBMergeMethodDescription).Text = "Same branch: we assume that both database are of the same type and that most IDs correlate in both DBs.";
			}
		}
	}

	public DBToolsForm()
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((Form)this).Load += DBToolsForm_Load;
		((Form)this).Shown += DBToolsForm_Shown;
		vmethod_1(new BackgroundWorker());
		vmethod_3(new BackgroundWorker());
		vmethod_5(new BackgroundWorker());
		bool_2 = true;
		DebugMode = false;
		DebugPath = "";
		OperationFilters = new Dictionary<OperationFilterType, Button>();
		OperationFiltersState = new HashSet<OperationFilterType>();
		OperationStack = new List<(OperationFilterType, string)>();
		bool_3 = false;
		mergeMethod_E_0 = MergeMethod_E.Different_Branch;
		MergeComparisonResolution = ComparisonDepth.Shallow;
		_PendingCopyOverAbortion = false;
		LuaInterpreter = new RamDB_Lua();
		MergeCandidates = new Dictionary<string, Dictionary<string, MergeCandidateWrapper>>();
		currentMergeCandidateTableSelection = "";
		openFileDialog_4 = new OpenFileDialog();
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Expected O, but got Unknown
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Expected O, but got Unknown
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1388: Unknown result type (might be due to invalid IL or missing references)
		//IL_1392: Expected O, but got Unknown
		//IL_19bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3d: Expected O, but got Unknown
		//IL_1c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5a: Expected O, but got Unknown
		//IL_1d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4d: Expected O, but got Unknown
		//IL_21f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2288: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_2afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3287: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae2: Expected O, but got Unknown
		//IL_3d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e73: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_414a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4154: Expected O, but got Unknown
		//IL_4229: Unknown result type (might be due to invalid IL or missing references)
		//IL_43f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4402: Expected O, but got Unknown
		//IL_45b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_469c: Unknown result type (might be due to invalid IL or missing references)
		//IL_48ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_48f7: Expected O, but got Unknown
		//IL_4944: Unknown result type (might be due to invalid IL or missing references)
		//IL_5062: Unknown result type (might be due to invalid IL or missing references)
		//IL_506c: Expected O, but got Unknown
		//IL_50b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_5265: Unknown result type (might be due to invalid IL or missing references)
		//IL_52ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_5377: Unknown result type (might be due to invalid IL or missing references)
		//IL_54cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_54d9: Expected O, but got Unknown
		//IL_5526: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		Button3 = new DarkButton();
		OpenFileDialog_SourceDB = new OpenFileDialog();
		OpenFileDialog_TargetDB = new OpenFileDialog();
		Timer1 = new Timer(icontainer_1);
		BW_ConvertDB = new BackgroundWorker();
		GroupBox1 = new DarkGroupBox();
		GroupBox5 = new DarkGroupBox();
		CB_FuelRec = new DarkCheckBox();
		CB_ValidateCargo = new DarkCheckBox();
		CB_WeaponRec = new DarkCheckBox();
		CB_DeprecationChecks = new DarkCheckBox();
		CB_CopyOver = new DarkCheckBox();
		CB_OperationalYearsAndService = new DarkCheckBox();
		CB_MissingComponents = new DarkCheckBox();
		GroupBox4 = new DarkGroupBox();
		CB_Warheads = new DarkCheckBox();
		CB_AirFacs = new DarkCheckBox();
		CB_Propulsion = new DarkCheckBox();
		CB_Loadouts = new DarkCheckBox();
		CB_DockFacs = new DarkCheckBox();
		CB_Sensors = new DarkCheckBox();
		CB_Weapons = new DarkCheckBox();
		CB_CommDevices = new DarkCheckBox();
		CB_Mounts = new DarkCheckBox();
		CB_Magazines = new DarkCheckBox();
		SelectAll = new DarkCheckBox();
		GroupBox3 = new DarkGroupBox();
		CB_Aircraft = new DarkCheckBox();
		CheckBox1 = new DarkCheckBox();
		CB_Satellites = new DarkCheckBox();
		CB_Submarines = new DarkCheckBox();
		CB_Ships = new DarkCheckBox();
		CB_Facilities = new DarkCheckBox();
		CheckBox_CSVOutput = new DarkCheckBox();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		Button_CSVExportFilePathBrowse = new DarkButton();
		CSVOutputFilePath = new DarkTextBox();
		Button4 = new DarkButton();
		TabPage3 = new TabPage();
		Button1 = new DarkButton();
		TabPage4 = new TabPage();
		ButtonRamDBJson = new DarkButton();
		Title = new DarkLabel();
		PairGB = new DarkGroupBox();
		LuaConsoleGB = new DarkGroupBox();
		LuaPrintMethods = new DarkButton();
		Button_LuaClear = new DarkButton();
		TB_LuaOutput = new DarkRichTextBox();
		Button_LuaRun = new DarkButton();
		RT_LuaInput = new DarkRichTextBox();
		GroupBox9 = new DarkGroupBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Panel1 = new Panel();
		Report = new DarkRichTextBox();
		Label5 = new DarkLabel();
		Panel2 = new Panel();
		Label4 = new DarkLabel();
		LV_Loading = new DarkListView();
		Panel3 = new Panel();
		FilterRamDBRoutine = new DarkButton();
		FilterRamDB = new DarkButton();
		FilterSQL = new DarkButton();
		ButtonSaveOperationStack = new DarkButton();
		Label13 = new DarkLabel();
		LV_WorkNode = new DarkListView();
		BrowseDatabasePairButton = new DarkButton();
		CopyOverGB = new DarkGroupBox();
		DarkGroupBox1 = new DarkGroupBox();
		LablCurrentCallStack = new DarkLabel();
		Label_DBStack = new DarkRichTextBox();
		LV_CopyOverStatus = new DarkListView();
		PerformCopyOverButton = new DarkButton();
		ComparisonMethodGB = new DarkGroupBox();
		InfoComparisonMethod = new DarkButton();
		ToggleComparisonResolution = new DarkLabel();
		TB_SImilarityThreshold = new TrackBar();
		Label_SimilarityThreshold = new DarkLabel();
		GB_Automation = new DarkGroupBox();
		CB_AutoPrimary = new DarkCheckBox();
		CB_AutoSecondary = new DarkCheckBox();
		CB_AutoCopyOver_Commit = new DarkCheckBox();
		CB_AutoCopyOverMode_External = new DarkCheckBox();
		CB_AutoCopyOverMode = new DarkCheckBox();
		MergeCandidatesGB = new DarkGroupBox();
		InfoMergeID = new DarkButton();
		Combo_MergeCandidate = new ComboBox();
		TB_MergeCandidate = new DarkRichTextBox();
		Label9 = new DarkLabel();
		PairTitle = new DarkLabel();
		SetupGB = new DarkGroupBox();
		DatabasePairSelectionGB = new DarkGroupBox();
		Button_SelectTargetDB = new DarkButton();
		Button_SelectSourceDB = new DarkButton();
		Button_LoadSetup = new DarkButton();
		DataRlationGB = new DarkGroupBox();
		Toggle_MergeMethod = new DarkButton();
		Label1 = new DarkLabel();
		TBMergeMethodDescription = new DarkRichTextBox();
		Label_JobInProgress = new DarkLabel();
		Button_CreateRamDBPair = new DarkButton();
		ProgressBar_Job = new DarkUIProgressBar();
		TabPage5 = new TabPage();
		Label6 = new DarkLabel();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Button_StartImport = new DarkButton();
		TabPage6 = new TabPage();
		DarkGroupBox2 = new DarkGroupBox();
		Button_BoostCoastTweak_SelectDB = new DarkButton();
		TB_BoostCoastTweak_DBFile = new DarkTextBox();
		DarkLabel8 = new DarkLabel();
		Label_BoostCoastTweaker_BoostTime = new DarkLabel();
		TB_BoostCoastTweak_BurnoutWeight = new DarkTextBox();
		TB_BoostCoastTweak_LaunchWeight = new DarkTextBox();
		DarkLabel6 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		TB_BoostCoastTweak_BodyLength = new DarkTextBox();
		TB_BoostCoastTweak_BodyDiameter = new DarkTextBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		Label_BoostCoastTweaker_WeaponName = new DarkLabel();
		Button_BoostCoastTweaker = new DarkButton();
		TB_BoostCoastTweak_WeaponID = new DarkTextBox();
		DarkLabel2 = new DarkLabel();
		Button5 = new DarkButton();
		CSV_Update_Button = new DarkButton();
		Button2 = new DarkButton();
		GroupBox2 = new DarkGroupBox();
		Button_DeepCopyLoadouts = new DarkButton();
		CB_DeepCopyLoadouts_RemoveExistingLoadouts = new DarkCheckBox();
		TB_DeepCopyLoadouts_TargetID = new DarkTextBox();
		TB_DeepCopyLoadouts_SourceID = new DarkTextBox();
		Label8 = new DarkLabel();
		Label7 = new DarkLabel();
		BW_UpdateSchema = new BackgroundWorker();
		OpenFileDialog_CSVExportPath = new OpenFileDialog();
		OpenFileDialog1 = new OpenFileDialog();
		ToolTip1 = new ToolTip(icontainer_1);
		DarkLabel1 = new DarkLabel();
		((Control)GroupBox1).SuspendLayout();
		((Control)GroupBox5).SuspendLayout();
		((Control)GroupBox4).SuspendLayout();
		((Control)GroupBox3).SuspendLayout();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((Control)PairGB).SuspendLayout();
		((Control)LuaConsoleGB).SuspendLayout();
		((Control)GroupBox9).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)Panel2).SuspendLayout();
		((Control)Panel3).SuspendLayout();
		((Control)CopyOverGB).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)ComparisonMethodGB).SuspendLayout();
		((ISupportInitialize)TB_SImilarityThreshold).BeginInit();
		((Control)GB_Automation).SuspendLayout();
		((Control)MergeCandidatesGB).SuspendLayout();
		((Control)SetupGB).SuspendLayout();
		((Control)DatabasePairSelectionGB).SuspendLayout();
		((Control)DataRlationGB).SuspendLayout();
		((Control)TabPage5).SuspendLayout();
		((Control)TabPage6).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Button3).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button3).ForeColor = Color.SeaGreen;
		((Control)Button3).Location = new Point(15, 17);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		((Control)Button3).Size = new Size(595, 575);
		((Control)Button3).TabIndex = 7;
		Button3.Text = "Convert MS-Access to SQLite";
		((FileDialog)OpenFileDialog_SourceDB).FileName = "OpenFileDialog1";
		((FileDialog)OpenFileDialog_TargetDB).FileName = "OpenFileDialog2";
		((Control)GroupBox1).Controls.Add((Control)(object)GroupBox5);
		((Control)GroupBox1).Controls.Add((Control)(object)GroupBox4);
		((Control)GroupBox1).Controls.Add((Control)(object)SelectAll);
		((Control)GroupBox1).Controls.Add((Control)(object)GroupBox3);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(9, 12);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(607, 305);
		((Control)GroupBox1).TabIndex = 9;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Select Components for Validation";
		((Control)GroupBox5).Controls.Add((Control)(object)CB_FuelRec);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_ValidateCargo);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_WeaponRec);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_DeprecationChecks);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_CopyOver);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_OperationalYearsAndService);
		((Control)GroupBox5).Controls.Add((Control)(object)CB_MissingComponents);
		((Control)GroupBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox5).Location = new Point(400, 47);
		((Control)GroupBox5).Name = "GroupBox5";
		((Control)GroupBox5).Size = new Size(200, 252);
		((Control)GroupBox5).TabIndex = 2;
		((GroupBox)GroupBox5).TabStop = false;
		((GroupBox)GroupBox5).Text = "Miscellaneous";
		((ButtonBase)CB_FuelRec).AutoSize = true;
		((CheckBox)CB_FuelRec).Checked = true;
		((CheckBox)CB_FuelRec).CheckState = (CheckState)1;
		((Control)CB_FuelRec).Location = new Point(6, 19);
		((Control)CB_FuelRec).Name = "CB_FuelRec";
		((Control)CB_FuelRec).Size = new Size(93, 19);
		((Control)CB_FuelRec).TabIndex = 19;
		((ButtonBase)CB_FuelRec).Text = "Fuel Records";
		((ButtonBase)CB_ValidateCargo).AutoSize = true;
		((CheckBox)CB_ValidateCargo).Checked = true;
		((CheckBox)CB_ValidateCargo).CheckState = (CheckState)1;
		((Control)CB_ValidateCargo).Location = new Point(6, 66);
		((Control)CB_ValidateCargo).Name = "CB_ValidateCargo";
		((Control)CB_ValidateCargo).Size = new Size(58, 19);
		((Control)CB_ValidateCargo).TabIndex = 20;
		((ButtonBase)CB_ValidateCargo).Text = "Cargo";
		((ButtonBase)CB_WeaponRec).AutoSize = true;
		((CheckBox)CB_WeaponRec).Checked = true;
		((CheckBox)CB_WeaponRec).CheckState = (CheckState)1;
		((Control)CB_WeaponRec).Location = new Point(6, 43);
		((Control)CB_WeaponRec).Name = "CB_WeaponRec";
		((Control)CB_WeaponRec).Size = new Size(115, 19);
		((Control)CB_WeaponRec).TabIndex = 18;
		((ButtonBase)CB_WeaponRec).Text = "Weapon Records";
		((ButtonBase)CB_DeprecationChecks).AutoSize = true;
		((CheckBox)CB_DeprecationChecks).Checked = true;
		((CheckBox)CB_DeprecationChecks).CheckState = (CheckState)1;
		((Control)CB_DeprecationChecks).Location = new Point(6, 89);
		((Control)CB_DeprecationChecks).Name = "CB_DeprecationChecks";
		((Control)CB_DeprecationChecks).Size = new Size(129, 19);
		((Control)CB_DeprecationChecks).TabIndex = 21;
		((ButtonBase)CB_DeprecationChecks).Text = "Record deprecation";
		((ButtonBase)CB_CopyOver).AutoSize = true;
		((Control)CB_CopyOver).Location = new Point(6, 111);
		((Control)CB_CopyOver).Name = "CB_CopyOver";
		((Control)CB_CopyOver).Size = new Size(84, 19);
		((Control)CB_CopyOver).TabIndex = 0;
		((ButtonBase)CB_CopyOver).Text = "Copy-Over";
		((ButtonBase)CB_OperationalYearsAndService).AutoSize = true;
		((Control)CB_OperationalYearsAndService).Location = new Point(6, 133);
		((Control)CB_OperationalYearsAndService).Name = "CB_OperationalYearsAndService";
		((Control)CB_OperationalYearsAndService).Size = new Size(180, 19);
		((Control)CB_OperationalYearsAndService).TabIndex = 1;
		((ButtonBase)CB_OperationalYearsAndService).Text = "Operational years and service";
		((ButtonBase)CB_MissingComponents).AutoSize = true;
		((Control)CB_MissingComponents).Location = new Point(6, 156);
		((Control)CB_MissingComponents).Name = "CB_MissingComponents";
		((Control)CB_MissingComponents).Size = new Size(137, 19);
		((Control)CB_MissingComponents).TabIndex = 2;
		((ButtonBase)CB_MissingComponents).Text = "Missing components";
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Warheads);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_AirFacs);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Propulsion);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Loadouts);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_DockFacs);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Sensors);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Weapons);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_CommDevices);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Mounts);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_Magazines);
		((Control)GroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox4).Location = new Point(195, 47);
		((Control)GroupBox4).Name = "GroupBox4";
		((Control)GroupBox4).Size = new Size(198, 252);
		((Control)GroupBox4).TabIndex = 1;
		((GroupBox)GroupBox4).TabStop = false;
		((GroupBox)GroupBox4).Text = "Components";
		((ButtonBase)CB_Warheads).AutoSize = true;
		((CheckBox)CB_Warheads).Checked = true;
		((CheckBox)CB_Warheads).CheckState = (CheckState)1;
		((Control)CB_Warheads).Location = new Point(6, 202);
		((Control)CB_Warheads).Name = "CB_Warheads";
		((Control)CB_Warheads).Size = new Size(78, 19);
		((Control)CB_Warheads).TabIndex = 17;
		((ButtonBase)CB_Warheads).Text = "Warheads";
		((ButtonBase)CB_AirFacs).AutoSize = true;
		((CheckBox)CB_AirFacs).Checked = true;
		((CheckBox)CB_AirFacs).CheckState = (CheckState)1;
		((Control)CB_AirFacs).Location = new Point(6, 19);
		((Control)CB_AirFacs).Name = "CB_AirFacs";
		((Control)CB_AirFacs).Size = new Size(89, 19);
		((Control)CB_AirFacs).TabIndex = 13;
		((ButtonBase)CB_AirFacs).Text = "Air Facilities";
		((ButtonBase)CB_Propulsion).AutoSize = true;
		((CheckBox)CB_Propulsion).Checked = true;
		((CheckBox)CB_Propulsion).CheckState = (CheckState)1;
		((Control)CB_Propulsion).Location = new Point(6, 156);
		((Control)CB_Propulsion).Name = "CB_Propulsion";
		((Control)CB_Propulsion).Size = new Size(83, 19);
		((Control)CB_Propulsion).TabIndex = 12;
		((ButtonBase)CB_Propulsion).Text = "Propulsion";
		((ButtonBase)CB_Loadouts).AutoSize = true;
		((CheckBox)CB_Loadouts).Checked = true;
		((CheckBox)CB_Loadouts).CheckState = (CheckState)1;
		((Control)CB_Loadouts).Location = new Point(6, 88);
		((Control)CB_Loadouts).Name = "CB_Loadouts";
		((Control)CB_Loadouts).Size = new Size(75, 19);
		((Control)CB_Loadouts).TabIndex = 15;
		((ButtonBase)CB_Loadouts).Text = "Loadouts";
		((ButtonBase)CB_DockFacs).AutoSize = true;
		((CheckBox)CB_DockFacs).Checked = true;
		((CheckBox)CB_DockFacs).CheckState = (CheckState)1;
		((Control)CB_DockFacs).Location = new Point(6, 66);
		((Control)CB_DockFacs).Name = "CB_DockFacs";
		((Control)CB_DockFacs).Size = new Size(118, 19);
		((Control)CB_DockFacs).TabIndex = 14;
		((ButtonBase)CB_DockFacs).Text = "Docking Facilities";
		((ButtonBase)CB_Sensors).AutoSize = true;
		((CheckBox)CB_Sensors).Checked = true;
		((CheckBox)CB_Sensors).CheckState = (CheckState)1;
		((Control)CB_Sensors).Location = new Point(6, 179);
		((Control)CB_Sensors).Name = "CB_Sensors";
		((Control)CB_Sensors).Size = new Size(66, 19);
		((Control)CB_Sensors).TabIndex = 16;
		((ButtonBase)CB_Sensors).Text = "Sensors";
		((ButtonBase)CB_Weapons).AutoSize = true;
		((CheckBox)CB_Weapons).Checked = true;
		((CheckBox)CB_Weapons).CheckState = (CheckState)1;
		((Control)CB_Weapons).Location = new Point(6, 225);
		((Control)CB_Weapons).Name = "CB_Weapons";
		((Control)CB_Weapons).Size = new Size(75, 19);
		((Control)CB_Weapons).TabIndex = 8;
		((ButtonBase)CB_Weapons).Text = "Weapons";
		((ButtonBase)CB_CommDevices).AutoSize = true;
		((CheckBox)CB_CommDevices).Checked = true;
		((CheckBox)CB_CommDevices).CheckState = (CheckState)1;
		((Control)CB_CommDevices).Location = new Point(6, 43);
		((Control)CB_CommDevices).Name = "CB_CommDevices";
		((Control)CB_CommDevices).Size = new Size(118, 19);
		((Control)CB_CommDevices).TabIndex = 9;
		((ButtonBase)CB_CommDevices).Text = "Communications";
		((ButtonBase)CB_Mounts).AutoSize = true;
		((CheckBox)CB_Mounts).Checked = true;
		((CheckBox)CB_Mounts).CheckState = (CheckState)1;
		((Control)CB_Mounts).Location = new Point(6, 133);
		((Control)CB_Mounts).Name = "CB_Mounts";
		((Control)CB_Mounts).Size = new Size(67, 19);
		((Control)CB_Mounts).TabIndex = 11;
		((ButtonBase)CB_Mounts).Text = "Mounts";
		((ButtonBase)CB_Magazines).AutoSize = true;
		((CheckBox)CB_Magazines).Checked = true;
		((CheckBox)CB_Magazines).CheckState = (CheckState)1;
		((Control)CB_Magazines).Location = new Point(6, 111);
		((Control)CB_Magazines).Name = "CB_Magazines";
		((Control)CB_Magazines).Size = new Size(82, 19);
		((Control)CB_Magazines).TabIndex = 10;
		((ButtonBase)CB_Magazines).Text = "Magazines";
		((ButtonBase)SelectAll).AutoSize = true;
		((CheckBox)SelectAll).Checked = true;
		((CheckBox)SelectAll).CheckState = (CheckState)1;
		((Control)SelectAll).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)2, (GraphicsUnit)3, (byte)0);
		((Control)SelectAll).Location = new Point(201, 19);
		((Control)SelectAll).Name = "SelectAll";
		((Control)SelectAll).Size = new Size(196, 17);
		((Control)SelectAll).TabIndex = 22;
		((ButtonBase)SelectAll).Text = "Select/Deselect All Routine Checks";
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Aircraft);
		((Control)GroupBox3).Controls.Add((Control)(object)CheckBox1);
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Satellites);
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Submarines);
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Ships);
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Facilities);
		((Control)GroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox3).Location = new Point(6, 47);
		((Control)GroupBox3).Name = "GroupBox3";
		((Control)GroupBox3).Size = new Size(182, 252);
		((Control)GroupBox3).TabIndex = 0;
		((GroupBox)GroupBox3).TabStop = false;
		((GroupBox)GroupBox3).Text = "Platforms";
		((ButtonBase)CB_Aircraft).AutoSize = true;
		((CheckBox)CB_Aircraft).Checked = true;
		((CheckBox)CB_Aircraft).CheckState = (CheckState)1;
		((Control)CB_Aircraft).Location = new Point(6, 19);
		((Control)CB_Aircraft).Name = "CB_Aircraft";
		((Control)CB_Aircraft).Size = new Size(65, 19);
		((Control)CB_Aircraft).TabIndex = 3;
		((ButtonBase)CB_Aircraft).Text = "Aircraft";
		((ButtonBase)CheckBox1).AutoSize = true;
		((CheckBox)CheckBox1).Checked = true;
		((CheckBox)CheckBox1).CheckState = (CheckState)1;
		((Control)CheckBox1).ForeColor = Color.Coral;
		((Control)CheckBox1).Location = new Point(6, 65);
		((Control)CheckBox1).Name = "CheckBox1";
		((Control)CheckBox1).Size = new Size(96, 19);
		((Control)CheckBox1).TabIndex = 20;
		((ButtonBase)CheckBox1).Text = "Ground Units";
		((ButtonBase)CB_Satellites).AutoSize = true;
		((CheckBox)CB_Satellites).Checked = true;
		((CheckBox)CB_Satellites).CheckState = (CheckState)1;
		((Control)CB_Satellites).Location = new Point(6, 88);
		((Control)CB_Satellites).Name = "CB_Satellites";
		((Control)CB_Satellites).Size = new Size(72, 19);
		((Control)CB_Satellites).TabIndex = 7;
		((ButtonBase)CB_Satellites).Text = "Satellites";
		((ButtonBase)CB_Submarines).AutoSize = true;
		((CheckBox)CB_Submarines).Checked = true;
		((CheckBox)CB_Submarines).CheckState = (CheckState)1;
		((Control)CB_Submarines).Location = new Point(6, 134);
		((Control)CB_Submarines).Name = "CB_Submarines";
		((Control)CB_Submarines).Size = new Size(88, 19);
		((Control)CB_Submarines).TabIndex = 5;
		((ButtonBase)CB_Submarines).Text = "Submarines";
		((ButtonBase)CB_Ships).AutoSize = true;
		((CheckBox)CB_Ships).Checked = true;
		((CheckBox)CB_Ships).CheckState = (CheckState)1;
		((Control)CB_Ships).Location = new Point(6, 111);
		((Control)CB_Ships).Name = "CB_Ships";
		((Control)CB_Ships).Size = new Size(54, 19);
		((Control)CB_Ships).TabIndex = 4;
		((ButtonBase)CB_Ships).Text = "Ships";
		((ButtonBase)CB_Facilities).AutoSize = true;
		((CheckBox)CB_Facilities).Checked = true;
		((CheckBox)CB_Facilities).CheckState = (CheckState)1;
		((Control)CB_Facilities).Location = new Point(6, 43);
		((Control)CB_Facilities).Name = "CB_Facilities";
		((Control)CB_Facilities).Size = new Size(71, 19);
		((Control)CB_Facilities).TabIndex = 6;
		((ButtonBase)CB_Facilities).Text = "Facilities";
		((ButtonBase)CheckBox_CSVOutput).AutoSize = true;
		((CheckBox)CheckBox_CSVOutput).CheckAlign = (ContentAlignment)64;
		((CheckBox)CheckBox_CSVOutput).Checked = true;
		((CheckBox)CheckBox_CSVOutput).CheckState = (CheckState)1;
		((Control)CheckBox_CSVOutput).Location = new Point(15, 323);
		((Control)CheckBox_CSVOutput).Name = "CheckBox_CSVOutput";
		((Control)CheckBox_CSVOutput).Size = new Size(88, 19);
		((Control)CheckBox_CSVOutput).TabIndex = 23;
		((ButtonBase)CheckBox_CSVOutput).Text = "CSV Output";
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage4);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage5);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage6);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Dock = (DockStyle)5;
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(1482, 676);
		((Control)TabControl1).TabIndex = 10;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)Button3);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(1474, 648);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Convert DB";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)Button_CSVExportFilePathBrowse);
		((Control)TabPage2).Controls.Add((Control)(object)CSVOutputFilePath);
		((Control)TabPage2).Controls.Add((Control)(object)CheckBox_CSVOutput);
		((Control)TabPage2).Controls.Add((Control)(object)Button4);
		((Control)TabPage2).Controls.Add((Control)(object)GroupBox1);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(1474, 648);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Validate DB";
		((Control)Button_CSVExportFilePathBrowse).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_CSVExportFilePathBrowse).Location = new Point(103, 321);
		((Control)Button_CSVExportFilePathBrowse).Name = "Button_CSVExportFilePathBrowse";
		((Control)Button_CSVExportFilePathBrowse).Padding = new Padding(5);
		((Control)Button_CSVExportFilePathBrowse).Size = new Size(95, 23);
		((Control)Button_CSVExportFilePathBrowse).TabIndex = 25;
		Button_CSVExportFilePathBrowse.Text = "Browse...";
		((TextBoxBase)CSVOutputFilePath).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)CSVOutputFilePath).BorderStyle = (BorderStyle)1;
		((TextBoxBase)CSVOutputFilePath).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CSVOutputFilePath).Location = new Point(204, 321);
		((Control)CSVOutputFilePath).Name = "CSVOutputFilePath";
		CSVOutputFilePath.PlaceholderText = "";
		((Control)CSVOutputFilePath).Size = new Size(412, 23);
		((Control)CSVOutputFilePath).TabIndex = 24;
		((TextBox)CSVOutputFilePath).Text = "C:\\Users\\rory\\Desktop\\ValidationResults.csv";
		((Control)Button4).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button4).ForeColor = Color.Green;
		((Control)Button4).Location = new Point(70, 562);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		((Control)Button4).Size = new Size(484, 39);
		((Control)Button4).TabIndex = 8;
		Button4.Text = "Validate";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)Button1);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(1474, 648);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Update schema";
		((Control)Button1).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button1).ForeColor = Color.Green;
		((Control)Button1).Location = new Point(15, 17);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		((Control)Button1).Size = new Size(595, 575);
		((Control)Button1).TabIndex = 0;
		Button1.Text = "Update database to current schema";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)ButtonRamDBJson);
		((Control)TabPage4).Controls.Add((Control)(object)Title);
		((Control)TabPage4).Controls.Add((Control)(object)PairGB);
		((Control)TabPage4).Controls.Add((Control)(object)SetupGB);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Size = new Size(1474, 648);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "RamDB";
		((Control)ButtonRamDBJson).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonRamDBJson).Location = new Point(137, 138);
		((Control)ButtonRamDBJson).Name = "ButtonRamDBJson";
		((Control)ButtonRamDBJson).Padding = new Padding(5);
		((Control)ButtonRamDBJson).Size = new Size(126, 26);
		((Control)ButtonRamDBJson).TabIndex = 36;
		ButtonRamDBJson.Text = "RamDB_Config.json";
		Title.AutoSize = true;
		((Control)Title).Font = new Font("Segoe UI", 20f);
		((Control)Title).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Title).Location = new Point(147, 99);
		((Control)Title).Name = "Title";
		((Control)Title).Size = new Size(104, 37);
		((Control)Title).TabIndex = 40;
		((Label)Title).Text = "RamDB";
		((Control)PairGB).Controls.Add((Control)(object)LuaConsoleGB);
		((Control)PairGB).Controls.Add((Control)(object)GroupBox9);
		((Control)PairGB).Controls.Add((Control)(object)BrowseDatabasePairButton);
		((Control)PairGB).Controls.Add((Control)(object)CopyOverGB);
		((Control)PairGB).Controls.Add((Control)(object)PairTitle);
		((Control)PairGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)PairGB).Location = new Point(397, 5);
		((Control)PairGB).Name = "PairGB";
		((Control)PairGB).Size = new Size(1069, 637);
		((Control)PairGB).TabIndex = 39;
		((GroupBox)PairGB).TabStop = false;
		((Control)LuaConsoleGB).Anchor = (AnchorStyles)15;
		((Control)LuaConsoleGB).Controls.Add((Control)(object)LuaPrintMethods);
		((Control)LuaConsoleGB).Controls.Add((Control)(object)Button_LuaClear);
		((Control)LuaConsoleGB).Controls.Add((Control)(object)TB_LuaOutput);
		((Control)LuaConsoleGB).Controls.Add((Control)(object)Button_LuaRun);
		((Control)LuaConsoleGB).Controls.Add((Control)(object)RT_LuaInput);
		((Control)LuaConsoleGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LuaConsoleGB).Location = new Point(6, 31);
		((Control)LuaConsoleGB).Name = "LuaConsoleGB";
		((Control)LuaConsoleGB).Size = new Size(287, 600);
		((Control)LuaConsoleGB).TabIndex = 47;
		((GroupBox)LuaConsoleGB).TabStop = false;
		((GroupBox)LuaConsoleGB).Text = "LUA console [EXPERIMENTAL]";
		((Control)LuaPrintMethods).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LuaPrintMethods).Location = new Point(6, 19);
		((Control)LuaPrintMethods).Name = "LuaPrintMethods";
		((Control)LuaPrintMethods).Padding = new Padding(5);
		((Control)LuaPrintMethods).Size = new Size(91, 23);
		((Control)LuaPrintMethods).TabIndex = 47;
		LuaPrintMethods.Text = "Print methods";
		((Control)Button_LuaClear).Anchor = (AnchorStyles)9;
		((Control)Button_LuaClear).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_LuaClear).Location = new Point(190, 19);
		((Control)Button_LuaClear).Name = "Button_LuaClear";
		((Control)Button_LuaClear).Padding = new Padding(5);
		((Control)Button_LuaClear).Size = new Size(91, 23);
		((Control)Button_LuaClear).TabIndex = 45;
		Button_LuaClear.Text = "Clear";
		((Control)TB_LuaOutput).Anchor = (AnchorStyles)15;
		((TextBoxBase)TB_LuaOutput).BackColor = Color.FromArgb(64, 64, 64);
		((RichTextBox)TB_LuaOutput).ForeColor = SystemColors.Info;
		((Control)TB_LuaOutput).Location = new Point(6, 46);
		((Control)TB_LuaOutput).Name = "TB_LuaOutput";
		((TextBoxBase)TB_LuaOutput).ReadOnly = true;
		((Control)TB_LuaOutput).Size = new Size(275, 398);
		((Control)TB_LuaOutput).TabIndex = 42;
		((RichTextBox)TB_LuaOutput).Text = "";
		((Control)Button_LuaRun).Anchor = (AnchorStyles)14;
		((Control)Button_LuaRun).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_LuaRun).Location = new Point(6, 564);
		((Control)Button_LuaRun).Name = "Button_LuaRun";
		((Control)Button_LuaRun).Padding = new Padding(5);
		((Control)Button_LuaRun).Size = new Size(275, 30);
		((Control)Button_LuaRun).TabIndex = 44;
		Button_LuaRun.Text = "Run";
		((Control)RT_LuaInput).Anchor = (AnchorStyles)14;
		((TextBoxBase)RT_LuaInput).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)RT_LuaInput).ForeColor = SystemColors.Desktop;
		((Control)RT_LuaInput).Location = new Point(6, 450);
		((Control)RT_LuaInput).Name = "RT_LuaInput";
		((Control)RT_LuaInput).Size = new Size(275, 108);
		((Control)RT_LuaInput).TabIndex = 46;
		((RichTextBox)RT_LuaInput).Text = "";
		((Control)GroupBox9).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)GroupBox9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox9).Location = new Point(721, 28);
		((Control)GroupBox9).Name = "GroupBox9";
		((Control)GroupBox9).Size = new Size(342, 603);
		((Control)GroupBox9).TabIndex = 42;
		((GroupBox)GroupBox9).TabStop = false;
		((GroupBox)GroupBox9).Text = "REPORTS";
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Panel1);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Panel2);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Panel3);
		((Control)FlowLayoutPanel1).Location = new Point(9, 18);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(333, 579);
		((Control)FlowLayoutPanel1).TabIndex = 33;
		Panel1.AutoSize = true;
		((Control)Panel1).Controls.Add((Control)(object)Report);
		((Control)Panel1).Controls.Add((Control)(object)Label5);
		((Control)Panel1).Location = new Point(3, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(324, 212);
		((Control)Panel1).TabIndex = 30;
		((Control)Report).Anchor = (AnchorStyles)15;
		((TextBoxBase)Report).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)Report).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Report).Location = new Point(3, 22);
		((Control)Report).Name = "Report";
		((Control)Report).Size = new Size(318, 187);
		((Control)Report).TabIndex = 15;
		((RichTextBox)Report).Text = "";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(3, 4);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(97, 15);
		((Control)Label5).TabIndex = 28;
		((Label)Label5).Text = "DB update report";
		Panel2.AutoSize = true;
		((Control)Panel2).Controls.Add((Control)(object)Label4);
		((Control)Panel2).Controls.Add((Control)(object)LV_Loading);
		((Control)Panel2).Location = new Point(3, 221);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(324, 153);
		((Control)Panel2).TabIndex = 31;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(3, 3);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(127, 15);
		((Control)Label4).TabIndex = 27;
		((Label)Label4).Text = "RAMDB Main Routines";
		((Control)LV_Loading).Anchor = (AnchorStyles)15;
		LV_Loading.ItemHeight = 15;
		((Control)LV_Loading).Location = new Point(3, 23);
		((Control)LV_Loading).Name = "LV_Loading";
		LV_Loading.RelatedInfos = null;
		((Control)LV_Loading).Size = new Size(318, 109);
		((Control)LV_Loading).TabIndex = 14;
		((Control)Panel3).Controls.Add((Control)(object)FilterRamDBRoutine);
		((Control)Panel3).Controls.Add((Control)(object)FilterRamDB);
		((Control)Panel3).Controls.Add((Control)(object)FilterSQL);
		((Control)Panel3).Controls.Add((Control)(object)ButtonSaveOperationStack);
		((Control)Panel3).Controls.Add((Control)(object)Label13);
		((Control)Panel3).Controls.Add((Control)(object)LV_WorkNode);
		((Control)Panel3).Location = new Point(3, 380);
		((Control)Panel3).Name = "Panel3";
		((Control)Panel3).Size = new Size(324, 193);
		((Control)Panel3).TabIndex = 32;
		((ButtonBase)FilterRamDBRoutine).BackColor = Color.FromArgb(192, 255, 192);
		((Control)FilterRamDBRoutine).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FilterRamDBRoutine).Location = new Point(100, 6);
		((Control)FilterRamDBRoutine).Name = "FilterRamDBRoutine";
		((Control)FilterRamDBRoutine).Padding = new Padding(5);
		((Control)FilterRamDBRoutine).Size = new Size(114, 23);
		((Control)FilterRamDBRoutine).TabIndex = 32;
		FilterRamDBRoutine.Text = "RamDB Routines";
		((Control)FilterRamDB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FilterRamDB).Location = new Point(216, 6);
		((Control)FilterRamDB).Name = "FilterRamDB";
		((Control)FilterRamDB).Padding = new Padding(5);
		((Control)FilterRamDB).Size = new Size(57, 23);
		((Control)FilterRamDB).TabIndex = 31;
		FilterRamDB.Text = "RamDB";
		((Control)FilterSQL).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FilterSQL).Location = new Point(274, 6);
		((Control)FilterSQL).Name = "FilterSQL";
		((Control)FilterSQL).Padding = new Padding(5);
		((Control)FilterSQL).Size = new Size(47, 23);
		((Control)FilterSQL).TabIndex = 30;
		FilterSQL.Text = "SQL";
		((Control)ButtonSaveOperationStack).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonSaveOperationStack).Location = new Point(233, 165);
		((Control)ButtonSaveOperationStack).Name = "ButtonSaveOperationStack";
		((Control)ButtonSaveOperationStack).Padding = new Padding(5);
		((Control)ButtonSaveOperationStack).Size = new Size(84, 23);
		((Control)ButtonSaveOperationStack).TabIndex = 33;
		ButtonSaveOperationStack.Text = "Save to File";
		Label13.AutoSize = true;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(3, 10);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(91, 15);
		((Control)Label13).TabIndex = 27;
		((Label)Label13).Text = "Operation Stack";
		((Control)LV_WorkNode).Anchor = (AnchorStyles)15;
		LV_WorkNode.ItemHeight = 15;
		((Control)LV_WorkNode).Location = new Point(3, 32);
		((Control)LV_WorkNode).Name = "LV_WorkNode";
		LV_WorkNode.RelatedInfos = null;
		((Control)LV_WorkNode).Size = new Size(318, 154);
		((Control)LV_WorkNode).TabIndex = 29;
		((Control)BrowseDatabasePairButton).Anchor = (AnchorStyles)13;
		((Control)BrowseDatabasePairButton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BrowseDatabasePairButton).Location = new Point(862, 0);
		((Control)BrowseDatabasePairButton).Name = "BrowseDatabasePairButton";
		((Control)BrowseDatabasePairButton).Padding = new Padding(5);
		((Control)BrowseDatabasePairButton).Size = new Size(201, 24);
		((Control)BrowseDatabasePairButton).TabIndex = 37;
		BrowseDatabasePairButton.Text = "Browse the Databases";
		((Control)CopyOverGB).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)CopyOverGB).Controls.Add((Control)(object)PerformCopyOverButton);
		((Control)CopyOverGB).Controls.Add((Control)(object)ComparisonMethodGB);
		((Control)CopyOverGB).Controls.Add((Control)(object)GB_Automation);
		((Control)CopyOverGB).Controls.Add((Control)(object)MergeCandidatesGB);
		((Control)CopyOverGB).Controls.Add((Control)(object)Label9);
		((Control)CopyOverGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CopyOverGB).Location = new Point(299, 31);
		((Control)CopyOverGB).Name = "CopyOverGB";
		((Control)CopyOverGB).Size = new Size(416, 600);
		((Control)CopyOverGB).TabIndex = 40;
		((GroupBox)CopyOverGB).TabStop = false;
		((GroupBox)CopyOverGB).Text = "COPY OVER";
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LablCurrentCallStack);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)Label_DBStack);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LV_CopyOverStatus);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(6, 395);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(404, 197);
		((Control)DarkGroupBox1).TabIndex = 40;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Status";
		LablCurrentCallStack.AutoSize = true;
		((Control)LablCurrentCallStack).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LablCurrentCallStack).Location = new Point(6, 27);
		((Control)LablCurrentCallStack).Name = "LablCurrentCallStack";
		((Control)LablCurrentCallStack).Size = new Size(95, 15);
		((Control)LablCurrentCallStack).TabIndex = 32;
		((Label)LablCurrentCallStack).Text = "Current callstack";
		((TextBoxBase)Label_DBStack).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)Label_DBStack).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DBStack).Location = new Point(6, 45);
		((Control)Label_DBStack).Name = "Label_DBStack";
		((Control)Label_DBStack).Size = new Size(175, 146);
		((Control)Label_DBStack).TabIndex = 31;
		((RichTextBox)Label_DBStack).Text = "";
		LV_CopyOverStatus.ItemHeight = 15;
		((Control)LV_CopyOverStatus).Location = new Point(187, 27);
		((Control)LV_CopyOverStatus).Name = "LV_CopyOverStatus";
		LV_CopyOverStatus.RelatedInfos = null;
		((Control)LV_CopyOverStatus).Size = new Size(211, 164);
		((Control)LV_CopyOverStatus).TabIndex = 40;
		((Control)PerformCopyOverButton).Anchor = (AnchorStyles)13;
		((Control)PerformCopyOverButton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)PerformCopyOverButton).Location = new Point(6, 346);
		((Control)PerformCopyOverButton).Name = "PerformCopyOverButton";
		((Control)PerformCopyOverButton).Padding = new Padding(5);
		((Control)PerformCopyOverButton).Size = new Size(404, 43);
		((Control)PerformCopyOverButton).TabIndex = 37;
		PerformCopyOverButton.Text = "Perfom CopyOver";
		((Control)ComparisonMethodGB).Anchor = (AnchorStyles)13;
		((Control)ComparisonMethodGB).Controls.Add((Control)(object)InfoComparisonMethod);
		((Control)ComparisonMethodGB).Controls.Add((Control)(object)ToggleComparisonResolution);
		((Control)ComparisonMethodGB).Controls.Add((Control)(object)TB_SImilarityThreshold);
		((Control)ComparisonMethodGB).Controls.Add((Control)(object)Label_SimilarityThreshold);
		((Control)ComparisonMethodGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ComparisonMethodGB).Location = new Point(208, 153);
		((Control)ComparisonMethodGB).Name = "ComparisonMethodGB";
		((Control)ComparisonMethodGB).Size = new Size(202, 187);
		((Control)ComparisonMethodGB).TabIndex = 23;
		((GroupBox)ComparisonMethodGB).TabStop = false;
		((GroupBox)ComparisonMethodGB).Text = "Comparison method";
		((Control)InfoComparisonMethod).Anchor = (AnchorStyles)9;
		((ButtonBase)InfoComparisonMethod).BackColor = Color.Wheat;
		((Control)InfoComparisonMethod).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)InfoComparisonMethod).Location = new Point(175, 0);
		((Control)InfoComparisonMethod).Name = "InfoComparisonMethod";
		((Control)InfoComparisonMethod).Padding = new Padding(5);
		((Control)InfoComparisonMethod).Size = new Size(21, 20);
		((Control)InfoComparisonMethod).TabIndex = 44;
		InfoComparisonMethod.Text = "?";
		ToolTip1.SetToolTip((Control)(object)InfoComparisonMethod, "The minimum required similarity to to validate a candidate");
		((Control)InfoComparisonMethod).Visible = false;
		ToggleComparisonResolution.AutoSize = true;
		((Control)ToggleComparisonResolution).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ToggleComparisonResolution).Location = new Point(149, 32);
		((Control)ToggleComparisonResolution).Name = "ToggleComparisonResolution";
		((Control)ToggleComparisonResolution).Size = new Size(37, 15);
		((Control)ToggleComparisonResolution).TabIndex = 18;
		((Label)ToggleComparisonResolution).Text = "------";
		((Control)ToggleComparisonResolution).Visible = false;
		((Control)TB_SImilarityThreshold).Location = new Point(6, 56);
		TB_SImilarityThreshold.Maximum = 100;
		TB_SImilarityThreshold.Minimum = 10;
		((Control)TB_SImilarityThreshold).Name = "TB_SImilarityThreshold";
		((Control)TB_SImilarityThreshold).Size = new Size(180, 45);
		((Control)TB_SImilarityThreshold).TabIndex = 16;
		TB_SImilarityThreshold.Value = 10;
		Label_SimilarityThreshold.AutoSize = true;
		((Control)Label_SimilarityThreshold).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SimilarityThreshold).Location = new Point(3, 32);
		((Control)Label_SimilarityThreshold).Name = "Label_SimilarityThreshold";
		((Control)Label_SimilarityThreshold).Size = new Size(117, 15);
		((Control)Label_SimilarityThreshold).TabIndex = 17;
		((Label)Label_SimilarityThreshold).Text = "Similarities threshold";
		((Control)GB_Automation).Anchor = (AnchorStyles)13;
		((Control)GB_Automation).Controls.Add((Control)(object)CB_AutoPrimary);
		((Control)GB_Automation).Controls.Add((Control)(object)CB_AutoSecondary);
		((Control)GB_Automation).Controls.Add((Control)(object)CB_AutoCopyOver_Commit);
		((Control)GB_Automation).Controls.Add((Control)(object)CB_AutoCopyOverMode_External);
		((Control)GB_Automation).Controls.Add((Control)(object)CB_AutoCopyOverMode);
		((Control)GB_Automation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_Automation).Location = new Point(6, 21);
		((Control)GB_Automation).Name = "GB_Automation";
		((Control)GB_Automation).Size = new Size(404, 126);
		((Control)GB_Automation).TabIndex = 42;
		((GroupBox)GB_Automation).TabStop = false;
		((GroupBox)GB_Automation).Text = "Automation";
		((ButtonBase)CB_AutoPrimary).AutoSize = true;
		((CheckBox)CB_AutoPrimary).Checked = true;
		((CheckBox)CB_AutoPrimary).CheckState = (CheckState)1;
		((Control)CB_AutoPrimary).Location = new Point(6, 17);
		((Control)CB_AutoPrimary).Name = "CB_AutoPrimary";
		((Control)CB_AutoPrimary).Size = new Size(104, 19);
		((Control)CB_AutoPrimary).TabIndex = 41;
		((ButtonBase)CB_AutoPrimary).Text = "Primary Nodes";
		((ButtonBase)CB_AutoSecondary).AutoSize = true;
		((CheckBox)CB_AutoSecondary).Checked = true;
		((CheckBox)CB_AutoSecondary).CheckState = (CheckState)1;
		((Control)CB_AutoSecondary).Location = new Point(6, 38);
		((Control)CB_AutoSecondary).Name = "CB_AutoSecondary";
		((Control)CB_AutoSecondary).Size = new Size(118, 19);
		((Control)CB_AutoSecondary).TabIndex = 40;
		((ButtonBase)CB_AutoSecondary).Text = "Secondary Nodes";
		((ButtonBase)CB_AutoCopyOver_Commit).AutoSize = true;
		((CheckBox)CB_AutoCopyOver_Commit).Checked = true;
		((CheckBox)CB_AutoCopyOver_Commit).CheckState = (CheckState)1;
		((Control)CB_AutoCopyOver_Commit).Location = new Point(6, 103);
		((Control)CB_AutoCopyOver_Commit).Name = "CB_AutoCopyOver_Commit";
		((Control)CB_AutoCopyOver_Commit).Size = new Size(97, 19);
		((Control)CB_AutoCopyOver_Commit).TabIndex = 39;
		((ButtonBase)CB_AutoCopyOver_Commit).Text = "Auto commit";
		((ButtonBase)CB_AutoCopyOverMode_External).AutoSize = true;
		((CheckBox)CB_AutoCopyOverMode_External).Checked = true;
		((CheckBox)CB_AutoCopyOverMode_External).CheckState = (CheckState)1;
		((Control)CB_AutoCopyOverMode_External).Location = new Point(6, 81);
		((Control)CB_AutoCopyOverMode_External).Name = "CB_AutoCopyOverMode_External";
		((Control)CB_AutoCopyOverMode_External).Size = new Size(189, 19);
		((Control)CB_AutoCopyOverMode_External).TabIndex = 38;
		((ButtonBase)CB_AutoCopyOverMode_External).Text = "Auto similarity check (External)";
		((ButtonBase)CB_AutoCopyOverMode).AutoSize = true;
		((CheckBox)CB_AutoCopyOverMode).Checked = true;
		((CheckBox)CB_AutoCopyOverMode).CheckState = (CheckState)1;
		((Control)CB_AutoCopyOverMode).Location = new Point(6, 60);
		((Control)CB_AutoCopyOverMode).Name = "CB_AutoCopyOverMode";
		((Control)CB_AutoCopyOverMode).Size = new Size(173, 19);
		((Control)CB_AutoCopyOverMode).TabIndex = 37;
		((ButtonBase)CB_AutoCopyOverMode).Text = "Auto similarity check (Own)";
		((Control)MergeCandidatesGB).Controls.Add((Control)(object)InfoMergeID);
		((Control)MergeCandidatesGB).Controls.Add((Control)(object)Combo_MergeCandidate);
		((Control)MergeCandidatesGB).Controls.Add((Control)(object)TB_MergeCandidate);
		((Control)MergeCandidatesGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MergeCandidatesGB).Location = new Point(6, 151);
		((Control)MergeCandidatesGB).Name = "MergeCandidatesGB";
		((Control)MergeCandidatesGB).Size = new Size(196, 189);
		((Control)MergeCandidatesGB).TabIndex = 35;
		((GroupBox)MergeCandidatesGB).TabStop = false;
		((GroupBox)MergeCandidatesGB).Text = "Merge ID candidates";
		((Control)InfoMergeID).Anchor = (AnchorStyles)9;
		((ButtonBase)InfoMergeID).BackColor = Color.Wheat;
		((Control)InfoMergeID).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)InfoMergeID).Location = new Point(169, 0);
		((Control)InfoMergeID).Name = "InfoMergeID";
		((Control)InfoMergeID).Padding = new Padding(5);
		((Control)InfoMergeID).Size = new Size(21, 20);
		((Control)InfoMergeID).TabIndex = 43;
		InfoMergeID.Text = "?";
		ToolTip1.SetToolTip((Control)(object)InfoMergeID, "The IDs that will be merged. No entry will perform an entire copy-over. Format example (without the quotes) : \"253,55,89\" - \"ALL\" for everything");
		((Control)InfoMergeID).Visible = false;
		Combo_MergeCandidate.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)Combo_MergeCandidate).FormattingEnabled = true;
		((Control)Combo_MergeCandidate).Location = new Point(6, 29);
		((Control)Combo_MergeCandidate).Name = "Combo_MergeCandidate";
		((Control)Combo_MergeCandidate).Size = new Size(184, 23);
		((Control)Combo_MergeCandidate).TabIndex = 34;
		((TextBoxBase)TB_MergeCandidate).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TB_MergeCandidate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_MergeCandidate).Location = new Point(6, 58);
		((Control)TB_MergeCandidate).Name = "TB_MergeCandidate";
		((Control)TB_MergeCandidate).Size = new Size(184, 125);
		((Control)TB_MergeCandidate).TabIndex = 33;
		((RichTextBox)TB_MergeCandidate).Text = "";
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(190, 440);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(95, 15);
		((Control)Label9).TabIndex = 41;
		((Label)Label9).Text = "Copy over status";
		PairTitle.AutoSize = true;
		((Control)PairTitle).Font = new Font("Microsoft Sans Serif", 18.25f);
		((Control)PairTitle).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)PairTitle).Location = new Point(7, -5);
		((Control)PairTitle).Name = "PairTitle";
		((Control)PairTitle).Size = new Size(252, 29);
		((Control)PairTitle).TabIndex = 38;
		((Label)PairTitle).Text = "DB3K <> CWDB Pair";
		((Control)SetupGB).Controls.Add((Control)(object)DatabasePairSelectionGB);
		((Control)SetupGB).Controls.Add((Control)(object)Button_LoadSetup);
		((Control)SetupGB).Controls.Add((Control)(object)DataRlationGB);
		((Control)SetupGB).Controls.Add((Control)(object)Label_JobInProgress);
		((Control)SetupGB).Controls.Add((Control)(object)Button_CreateRamDBPair);
		((Control)SetupGB).Controls.Add((Control)(object)ProgressBar_Job);
		((Control)SetupGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SetupGB).Location = new Point(4, 295);
		((Control)SetupGB).Name = "SetupGB";
		((Control)SetupGB).Size = new Size(382, 345);
		((Control)SetupGB).TabIndex = 37;
		((GroupBox)SetupGB).TabStop = false;
		((GroupBox)SetupGB).Text = "SETUP";
		((Control)DatabasePairSelectionGB).Controls.Add((Control)(object)Button_SelectTargetDB);
		((Control)DatabasePairSelectionGB).Controls.Add((Control)(object)Button_SelectSourceDB);
		((Control)DatabasePairSelectionGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DatabasePairSelectionGB).Location = new Point(5, 198);
		((Control)DatabasePairSelectionGB).Name = "DatabasePairSelectionGB";
		((Control)DatabasePairSelectionGB).Size = new Size(371, 69);
		((Control)DatabasePairSelectionGB).TabIndex = 39;
		((GroupBox)DatabasePairSelectionGB).TabStop = false;
		((GroupBox)DatabasePairSelectionGB).Text = "Database Pair Selection (.mdb)";
		((Control)Button_SelectTargetDB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SelectTargetDB).Location = new Point(6, 27);
		((Control)Button_SelectTargetDB).Name = "Button_SelectTargetDB";
		((Control)Button_SelectTargetDB).Padding = new Padding(5);
		((Control)Button_SelectTargetDB).Size = new Size(170, 28);
		((Control)Button_SelectTargetDB).TabIndex = 32;
		Button_SelectTargetDB.Text = "FROM [select DB]";
		((Control)Button_SelectSourceDB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SelectSourceDB).Location = new Point(179, 27);
		((Control)Button_SelectSourceDB).Name = "Button_SelectSourceDB";
		((Control)Button_SelectSourceDB).Padding = new Padding(5);
		((Control)Button_SelectSourceDB).Size = new Size(185, 28);
		((Control)Button_SelectSourceDB).TabIndex = 31;
		Button_SelectSourceDB.Text = "TO [select DB]";
		((Control)Button_LoadSetup).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_LoadSetup).Location = new Point(227, 2);
		((Control)Button_LoadSetup).Name = "Button_LoadSetup";
		((Control)Button_LoadSetup).Padding = new Padding(5);
		((Control)Button_LoadSetup).Size = new Size(147, 20);
		((Control)Button_LoadSetup).TabIndex = 25;
		Button_LoadSetup.Text = "Load Setup From File";
		((Control)DataRlationGB).Controls.Add((Control)(object)Toggle_MergeMethod);
		((Control)DataRlationGB).Controls.Add((Control)(object)Label1);
		((Control)DataRlationGB).Controls.Add((Control)(object)TBMergeMethodDescription);
		((Control)DataRlationGB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DataRlationGB).Location = new Point(6, 28);
		((Control)DataRlationGB).Name = "DataRlationGB";
		((Control)DataRlationGB).Size = new Size(368, 164);
		((Control)DataRlationGB).TabIndex = 22;
		((GroupBox)DataRlationGB).TabStop = false;
		((GroupBox)DataRlationGB).Text = "Database Relation";
		((Control)Toggle_MergeMethod).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Toggle_MergeMethod).Location = new Point(172, 23);
		((Control)Toggle_MergeMethod).Name = "Toggle_MergeMethod";
		((Control)Toggle_MergeMethod).Padding = new Padding(5);
		((Control)Toggle_MergeMethod).Size = new Size(187, 23);
		((Control)Toggle_MergeMethod).TabIndex = 24;
		Toggle_MergeMethod.Text = "Toggle_MergeMethod";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(6, 27);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(164, 15);
		((Control)Label1).TabIndex = 22;
		((Label)Label1).Text = "Source <-> Target DB relation";
		((TextBoxBase)TBMergeMethodDescription).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TBMergeMethodDescription).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TBMergeMethodDescription).Location = new Point(9, 62);
		((Control)TBMergeMethodDescription).Name = "TBMergeMethodDescription";
		((TextBoxBase)TBMergeMethodDescription).ReadOnly = true;
		((Control)TBMergeMethodDescription).Size = new Size(350, 87);
		((Control)TBMergeMethodDescription).TabIndex = 20;
		((RichTextBox)TBMergeMethodDescription).Text = "Same branch: we assume that both database are of the same type and that most IDs correlate in both DBs.";
		((Control)Label_JobInProgress).Anchor = (AnchorStyles)14;
		Label_JobInProgress.AutoSize = true;
		((Control)Label_JobInProgress).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label_JobInProgress).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_JobInProgress).Location = new Point(12, 319);
		((Control)Label_JobInProgress).Name = "Label_JobInProgress";
		((Control)Label_JobInProgress).Size = new Size(0, 15);
		((Control)Label_JobInProgress).TabIndex = 29;
		((Label)Label_JobInProgress).TextAlign = (ContentAlignment)32;
		((ButtonBase)Button_CreateRamDBPair).BackColor = Color.FromArgb(60, 63, 65);
		((Control)Button_CreateRamDBPair).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_CreateRamDBPair).Location = new Point(5, 273);
		((Control)Button_CreateRamDBPair).Name = "Button_CreateRamDBPair";
		((Control)Button_CreateRamDBPair).Padding = new Padding(5);
		((Control)Button_CreateRamDBPair).Size = new Size(371, 34);
		((Control)Button_CreateRamDBPair).TabIndex = 8;
		Button_CreateRamDBPair.Text = "Create RAMDB pair instance";
		((Control)ProgressBar_Job).Anchor = (AnchorStyles)14;
		((Control)ProgressBar_Job).BackColor = Color.Transparent;
		ProgressBar_Job.CustomForeColor = Color.Transparent;
		((Control)ProgressBar_Job).Location = new Point(6, 314);
		ProgressBar_Job.Maximum = 100;
		((Control)ProgressBar_Job).Name = "ProgressBar_Job";
		ProgressBar_Job.ShowProgressLines = true;
		ProgressBar_Job.ShowProgressValue = true;
		ProgressBar_Job.ShowText = false;
		((Control)ProgressBar_Job).Size = new Size(370, 25);
		((Control)ProgressBar_Job).TabIndex = 23;
		ProgressBar_Job.Value = 0;
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage5).Controls.Add((Control)(object)Label6);
		((Control)TabPage5).Controls.Add((Control)(object)Label3);
		((Control)TabPage5).Controls.Add((Control)(object)Label2);
		((Control)TabPage5).Controls.Add((Control)(object)Button_StartImport);
		TabPage5.Location = new Point(4, 24);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Size = new Size(1474, 648);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "Import";
		((Control)Label6).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(8, 81);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(354, 32);
		((Control)Label6).TabIndex = 12;
		((Label)Label6).Text = "IMPORTANT! All existing content of the target database will be deleted.";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(8, 33);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(354, 45);
		((Control)Label3).TabIndex = 11;
		((Label)Label3).Text = "Useful for transfering the content of a DB with an older schema to a DB with new schema, or for transferring an old DB to a upgraded DB-editor application.";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(8, 10);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(357, 23);
		((Control)Label2).TabIndex = 10;
		((Label)Label2).Text = "Overwrite all data tables in one database with data from another database.";
		((Control)Button_StartImport).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_StartImport).Location = new Point(8, 169);
		((Control)Button_StartImport).Name = "Button_StartImport";
		((Control)Button_StartImport).Padding = new Padding(5);
		((Control)Button_StartImport).Size = new Size(354, 45);
		((Control)Button_StartImport).TabIndex = 9;
		Button_StartImport.Text = "Start Import";
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage6).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)TabPage6).Controls.Add((Control)(object)Button5);
		((Control)TabPage6).Controls.Add((Control)(object)CSV_Update_Button);
		((Control)TabPage6).Controls.Add((Control)(object)Button2);
		((Control)TabPage6).Controls.Add((Control)(object)GroupBox2);
		TabPage6.Location = new Point(4, 24);
		((Control)TabPage6).Name = "TabPage6";
		((Control)TabPage6).Padding = new Padding(3);
		((Control)TabPage6).Size = new Size(1474, 648);
		TabPage6.TabIndex = 5;
		TabPage6.Text = "Utilities";
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel1);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_BoostCoastTweak_SelectDB);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_DBFile);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel8);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Label_BoostCoastTweaker_BoostTime);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_BurnoutWeight);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_LaunchWeight);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel6);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel5);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_BodyLength);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_BodyDiameter);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel4);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel3);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Label_BoostCoastTweaker_WeaponName);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_BoostCoastTweaker);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TB_BoostCoastTweak_WeaponID);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel2);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(8, 102);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(430, 204);
		((Control)DarkGroupBox2).TabIndex = 4;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Boost-Coast Tweaker";
		((Control)Button_BoostCoastTweak_SelectDB).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_BoostCoastTweak_SelectDB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_BoostCoastTweak_SelectDB).Location = new Point(249, 20);
		((Control)Button_BoostCoastTweak_SelectDB).Name = "Button_BoostCoastTweak_SelectDB";
		((Control)Button_BoostCoastTweak_SelectDB).Padding = new Padding(5);
		((Control)Button_BoostCoastTweak_SelectDB).Size = new Size(75, 23);
		((Control)Button_BoostCoastTweak_SelectDB).TabIndex = 18;
		Button_BoostCoastTweak_SelectDB.Text = "Select...";
		((TextBoxBase)TB_BoostCoastTweak_DBFile).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_DBFile).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_DBFile).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_DBFile).Location = new Point(57, 20);
		((Control)TB_BoostCoastTweak_DBFile).Name = "TB_BoostCoastTweak_DBFile";
		TB_BoostCoastTweak_DBFile.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_DBFile).Size = new Size(186, 23);
		((Control)TB_BoostCoastTweak_DBFile).TabIndex = 17;
		DarkLabel8.AutoSize = true;
		((Control)DarkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel8).Location = new Point(7, 22);
		((Control)DarkLabel8).Name = "DarkLabel8";
		((Control)DarkLabel8).Size = new Size(44, 15);
		((Control)DarkLabel8).TabIndex = 16;
		((Label)DarkLabel8).Text = "DB file:";
		Label_BoostCoastTweaker_BoostTime.AutoSize = true;
		((Control)Label_BoostCoastTweaker_BoostTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_BoostCoastTweaker_BoostTime).Location = new Point(208, 171);
		((Control)Label_BoostCoastTweaker_BoostTime).Name = "Label_BoostCoastTweaker_BoostTime";
		((Control)Label_BoostCoastTweaker_BoostTime).Size = new Size(95, 15);
		((Control)Label_BoostCoastTweaker_BoostTime).TabIndex = 15;
		((Label)Label_BoostCoastTweaker_BoostTime).Text = "Boost time (sec):";
		((TextBoxBase)TB_BoostCoastTweak_BurnoutWeight).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_BurnoutWeight).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_BurnoutWeight).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_BurnoutWeight).Location = new Point(326, 138);
		((Control)TB_BoostCoastTweak_BurnoutWeight).Name = "TB_BoostCoastTweak_BurnoutWeight";
		TB_BoostCoastTweak_BurnoutWeight.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_BurnoutWeight).Size = new Size(66, 23);
		((Control)TB_BoostCoastTweak_BurnoutWeight).TabIndex = 14;
		((TextBox)TB_BoostCoastTweak_BurnoutWeight).Text = "0";
		((TextBoxBase)TB_BoostCoastTweak_LaunchWeight).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_LaunchWeight).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_LaunchWeight).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_LaunchWeight).Location = new Point(326, 109);
		((Control)TB_BoostCoastTweak_LaunchWeight).Name = "TB_BoostCoastTweak_LaunchWeight";
		TB_BoostCoastTweak_LaunchWeight.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_LaunchWeight).Size = new Size(66, 23);
		((Control)TB_BoostCoastTweak_LaunchWeight).TabIndex = 13;
		((TextBox)TB_BoostCoastTweak_LaunchWeight).Text = "0";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(208, 140);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(116, 15);
		((Control)DarkLabel6).TabIndex = 12;
		((Label)DarkLabel6).Text = "Burnout weight (kg):";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(208, 111);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(112, 15);
		((Control)DarkLabel5).TabIndex = 11;
		((Label)DarkLabel5).Text = "Launch weight (kg):";
		((TextBoxBase)TB_BoostCoastTweak_BodyLength).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_BodyLength).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_BodyLength).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_BodyLength).Location = new Point(122, 138);
		((Control)TB_BoostCoastTweak_BodyLength).Name = "TB_BoostCoastTweak_BodyLength";
		TB_BoostCoastTweak_BodyLength.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_BodyLength).Size = new Size(66, 23);
		((Control)TB_BoostCoastTweak_BodyLength).TabIndex = 10;
		((TextBox)TB_BoostCoastTweak_BodyLength).Text = "0";
		((TextBoxBase)TB_BoostCoastTweak_BodyDiameter).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_BodyDiameter).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_BodyDiameter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_BodyDiameter).Location = new Point(122, 109);
		((Control)TB_BoostCoastTweak_BodyDiameter).Name = "TB_BoostCoastTweak_BodyDiameter";
		TB_BoostCoastTweak_BodyDiameter.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_BodyDiameter).Size = new Size(66, 23);
		((Control)TB_BoostCoastTweak_BodyDiameter).TabIndex = 9;
		((TextBox)TB_BoostCoastTweak_BodyDiameter).Text = "0";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(7, 140);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(96, 15);
		((Control)DarkLabel4).TabIndex = 8;
		((Label)DarkLabel4).Text = "Body length (m):";
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(7, 111);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(109, 15);
		((Control)DarkLabel3).TabIndex = 7;
		((Label)DarkLabel3).Text = "Body diameter (m):";
		Label_BoostCoastTweaker_WeaponName.AutoSize = true;
		((Control)Label_BoostCoastTweaker_WeaponName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_BoostCoastTweaker_WeaponName).Location = new Point(149, 57);
		((Control)Label_BoostCoastTweaker_WeaponName).Name = "Label_BoostCoastTweaker_WeaponName";
		((Control)Label_BoostCoastTweaker_WeaponName).Size = new Size(94, 15);
		((Control)Label_BoostCoastTweaker_WeaponName).TabIndex = 6;
		((Label)Label_BoostCoastTweaker_WeaponName).Text = "[Weapon Name]";
		((Control)Button_BoostCoastTweaker).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_BoostCoastTweaker).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_BoostCoastTweaker).Location = new Point(10, 167);
		((Control)Button_BoostCoastTweaker).Name = "Button_BoostCoastTweaker";
		((Control)Button_BoostCoastTweaker).Padding = new Padding(5);
		((Control)Button_BoostCoastTweaker).Size = new Size(178, 23);
		((Control)Button_BoostCoastTweaker).TabIndex = 5;
		Button_BoostCoastTweaker.Text = "RUN";
		((TextBoxBase)TB_BoostCoastTweak_WeaponID).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_BoostCoastTweak_WeaponID).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_BoostCoastTweak_WeaponID).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_BoostCoastTweak_WeaponID).Location = new Point(88, 55);
		((Control)TB_BoostCoastTweak_WeaponID).Name = "TB_BoostCoastTweak_WeaponID";
		TB_BoostCoastTweak_WeaponID.PlaceholderText = "";
		((Control)TB_BoostCoastTweak_WeaponID).Size = new Size(55, 23);
		((Control)TB_BoostCoastTweak_WeaponID).TabIndex = 2;
		((TextBox)TB_BoostCoastTweak_WeaponID).Text = "0";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(7, 58);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(68, 15);
		((Control)DarkLabel2).TabIndex = 0;
		((Label)DarkLabel2).Text = "Weapon ID:";
		((Control)Button5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button5).Location = new Point(8, 526);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Padding = new Padding(5);
		((Control)Button5).Size = new Size(430, 36);
		((Control)Button5).TabIndex = 3;
		Button5.Text = "Generate GUIDs for a database";
		((Control)CSV_Update_Button).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CSV_Update_Button).Location = new Point(8, 484);
		((Control)CSV_Update_Button).Name = "CSV_Update_Button";
		((Control)CSV_Update_Button).Padding = new Padding(5);
		((Control)CSV_Update_Button).Size = new Size(430, 36);
		((Control)CSV_Update_Button).TabIndex = 2;
		CSV_Update_Button.Text = "Apply CSV Update";
		((Control)Button2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button2).Location = new Point(8, 439);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		((Control)Button2).Size = new Size(430, 39);
		((Control)Button2).TabIndex = 1;
		Button2.Text = "Fix RCS of mobile facilities";
		((Control)GroupBox2).Controls.Add((Control)(object)Button_DeepCopyLoadouts);
		((Control)GroupBox2).Controls.Add((Control)(object)CB_DeepCopyLoadouts_RemoveExistingLoadouts);
		((Control)GroupBox2).Controls.Add((Control)(object)TB_DeepCopyLoadouts_TargetID);
		((Control)GroupBox2).Controls.Add((Control)(object)TB_DeepCopyLoadouts_SourceID);
		((Control)GroupBox2).Controls.Add((Control)(object)Label8);
		((Control)GroupBox2).Controls.Add((Control)(object)Label7);
		((Control)GroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox2).Location = new Point(8, 6);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(430, 80);
		((Control)GroupBox2).TabIndex = 0;
		((GroupBox)GroupBox2).TabStop = false;
		((GroupBox)GroupBox2).Text = "Deep-Copy AC Loadouts";
		((Control)Button_DeepCopyLoadouts).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_DeepCopyLoadouts).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_DeepCopyLoadouts).Location = new Point(211, 45);
		((Control)Button_DeepCopyLoadouts).Name = "Button_DeepCopyLoadouts";
		((Control)Button_DeepCopyLoadouts).Padding = new Padding(5);
		((Control)Button_DeepCopyLoadouts).Size = new Size(75, 23);
		((Control)Button_DeepCopyLoadouts).TabIndex = 5;
		Button_DeepCopyLoadouts.Text = "RUN";
		((ButtonBase)CB_DeepCopyLoadouts_RemoveExistingLoadouts).AutoSize = true;
		((CheckBox)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Checked = true;
		((CheckBox)CB_DeepCopyLoadouts_RemoveExistingLoadouts).CheckState = (CheckState)1;
		((Control)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Location = new Point(211, 19);
		((Control)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Name = "CB_DeepCopyLoadouts_RemoveExistingLoadouts";
		((Control)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Size = new Size(212, 19);
		((Control)CB_DeepCopyLoadouts_RemoveExistingLoadouts).TabIndex = 4;
		((ButtonBase)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Text = "Remove existing loadouts on target";
		((TextBoxBase)TB_DeepCopyLoadouts_TargetID).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_DeepCopyLoadouts_TargetID).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_DeepCopyLoadouts_TargetID).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_DeepCopyLoadouts_TargetID).Location = new Point(88, 45);
		((Control)TB_DeepCopyLoadouts_TargetID).Name = "TB_DeepCopyLoadouts_TargetID";
		TB_DeepCopyLoadouts_TargetID.PlaceholderText = "";
		((Control)TB_DeepCopyLoadouts_TargetID).Size = new Size(100, 23);
		((Control)TB_DeepCopyLoadouts_TargetID).TabIndex = 3;
		((TextBoxBase)TB_DeepCopyLoadouts_SourceID).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_DeepCopyLoadouts_SourceID).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_DeepCopyLoadouts_SourceID).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_DeepCopyLoadouts_SourceID).Location = new Point(88, 17);
		((Control)TB_DeepCopyLoadouts_SourceID).Name = "TB_DeepCopyLoadouts_SourceID";
		TB_DeepCopyLoadouts_SourceID.PlaceholderText = "";
		((Control)TB_DeepCopyLoadouts_SourceID).Size = new Size(100, 23);
		((Control)TB_DeepCopyLoadouts_SourceID).TabIndex = 2;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(7, 48);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(76, 15);
		((Control)Label8).TabIndex = 1;
		((Label)Label8).Text = "Target AC ID:";
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(7, 20);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(79, 15);
		((Control)Label7).TabIndex = 0;
		((Label)Label7).Text = "Source AC ID:";
		OpenFileDialog_CSVExportPath.CheckFileExists = false;
		((FileDialog)OpenFileDialog_CSVExportPath).DefaultExt = "csv";
		((FileDialog)OpenFileDialog_CSVExportPath).FileName = "ValidationResults.csv";
		((FileDialog)OpenFileDialog1).DefaultExt = "csv";
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog_CSVUpdateFile";
		((FileDialog)OpenFileDialog1).Filter = "CSV Files|*.csv";
		((FileDialog)OpenFileDialog1).InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.Desktop)";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(7, 88);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(174, 15);
		((Control)DarkLabel1).TabIndex = 19;
		((Label)DarkLabel1).Text = "Tweak values (0 = use DB stock)";
		((Form)this).ClientSize = new Size(1482, 676);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).MaximumSize = new Size(1498, 715);
		((Form)this).MinimumSize = new Size(1498, 715);
		((Control)this).Name = "DBToolsForm";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Command-PE DB Tools v1.11";
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)GroupBox5).ResumeLayout(false);
		((Control)GroupBox5).PerformLayout();
		((Control)GroupBox4).ResumeLayout(false);
		((Control)GroupBox4).PerformLayout();
		((Control)GroupBox3).ResumeLayout(false);
		((Control)GroupBox3).PerformLayout();
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage4).ResumeLayout(false);
		((Control)TabPage4).PerformLayout();
		((Control)PairGB).ResumeLayout(false);
		((Control)PairGB).PerformLayout();
		((Control)LuaConsoleGB).ResumeLayout(false);
		((Control)GroupBox9).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)Panel2).ResumeLayout(false);
		((Control)Panel2).PerformLayout();
		((Control)Panel3).ResumeLayout(false);
		((Control)Panel3).PerformLayout();
		((Control)CopyOverGB).ResumeLayout(false);
		((Control)CopyOverGB).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)ComparisonMethodGB).ResumeLayout(false);
		((Control)ComparisonMethodGB).PerformLayout();
		((ISupportInitialize)TB_SImilarityThreshold).EndInit();
		((Control)GB_Automation).ResumeLayout(false);
		((Control)GB_Automation).PerformLayout();
		((Control)MergeCandidatesGB).ResumeLayout(false);
		((Control)SetupGB).ResumeLayout(false);
		((Control)SetupGB).PerformLayout();
		((Control)DatabasePairSelectionGB).ResumeLayout(false);
		((Control)DataRlationGB).ResumeLayout(false);
		((Control)DataRlationGB).PerformLayout();
		((Control)TabPage5).ResumeLayout(false);
		((Control)TabPage6).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((Control)GroupBox2).ResumeLayout(false);
		((Control)GroupBox2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_0()
	{
		return backgroundWorker_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_4;
		RunWorkerCompletedEventHandler value2 = method_5;
		BackgroundWorker backgroundWorker = backgroundWorker_2;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_2 = WithEventsValue;
		backgroundWorker = backgroundWorker_2;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_2()
	{
		return backgroundWorker_3;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_3(BackgroundWorker WithEventsValue)
	{
		backgroundWorker_3 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_4()
	{
		return backgroundWorker_4;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_5(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_15;
		RunWorkerCompletedEventHandler value2 = method_16;
		BackgroundWorker backgroundWorker = backgroundWorker_4;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_4 = WithEventsValue;
		backgroundWorker = backgroundWorker_4;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public string PreloadRamDBConfigsFromFile()
	{
		string result;
		try
		{
			result = new StreamReader(Path.Combine(GameGeneral.ConfigFolderPath, "RamDB_Config.json")).ReadToEnd();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Refresh_LV_CopyOverStatus()
	{
		LV_CopyOverStatus.Items.Clear();
		foreach (KeyValuePair<string, Dictionary<string, MergeCandidateWrapper>> mergeCandidate in MergeCandidates)
		{
			if (mergeCandidate.Value.Count <= 0)
			{
				continue;
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<string, MergeCandidateWrapper> item in mergeCandidate.Value)
			{
				if (item.Value.GetStatus() == MergeCandidateStatus.Failed)
				{
					num2++;
				}
				else if (item.Value.GetStatus() == MergeCandidateStatus.Successful)
				{
					num++;
				}
			}
			string text = "";
			text = mergeCandidate.Key + "[" + (num + num2) + "/" + mergeCandidate.Value.Count + "]";
			if (num2 > 0)
			{
				text = text + " " + num2 + " failures";
			}
			LV_CopyOverStatus.Items.Add(new DarkListItem(text));
		}
	}

	public void RefreshMergeCandidatesList(string TargetTable)
	{
		((RichTextBox)TB_MergeCandidate).Text = "";
		if (!MergeCandidates.ContainsKey(TargetTable))
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, MergeCandidateWrapper> item in MergeCandidates[TargetTable])
		{
			list.Add(item.Key);
		}
		((RichTextBox)TB_MergeCandidate).Text = string.Join(",", list);
	}

	public void SaveMergeCandidatesList()
	{
		if (string.IsNullOrEmpty(currentMergeCandidateTableSelection))
		{
			return;
		}
		Dictionary<string, MergeCandidateWrapper> value = null;
		if (!MergeCandidates.TryGetValue(currentMergeCandidateTableSelection, out value))
		{
			return;
		}
		value.Clear();
		foreach (string item in from i in ((RichTextBox)TB_MergeCandidate).Text.Split(new char[1] { ',' })
			where !string.IsNullOrWhiteSpace(i)
			select i)
		{
			if (!value.ContainsKey(item))
			{
				value.Add(item, new MergeCandidateWrapper(item, this));
			}
		}
		Refresh_LV_CopyOverStatus();
	}

	private void DBToolsForm_Load(object sender, EventArgs e)
	{
		ToggleRamDBInstanceViewerPanel(value: false);
		OperationFilters.Add(OperationFilterType.RamdbRoutine, (Button)(object)FilterRamDBRoutine);
		OperationFilters.Add(OperationFilterType.RamDB, (Button)(object)FilterRamDB);
		OperationFilters.Add(OperationFilterType.SQL, (Button)(object)FilterSQL);
		EnableOperationStackFilter(OperationFilterType.RamDB);
		EnableOperationStackFilter(OperationFilterType.RamdbRoutine);
		EnableOperationStackFilter(OperationFilterType.SQL);
		((ListControl)Combo_MergeCandidate).DisplayMember = "Name";
		Config = Ram_Database.LoadRamDBConfigs();
		if (Information.IsNothing((object)Config))
		{
			return;
		}
		foreach (HashTableNodeConfig item in Config.ConfigCollection)
		{
			MergeCandidates.Add(item.PrimaryElevation, new Dictionary<string, MergeCandidateWrapper>());
			Combo_MergeCandidate.Items.Add((object)new LV_Item_ComboMergeCandidate(item.PrimaryElevation, item.DisplayName, this));
		}
		if (Combo_MergeCandidate.Items.Count > 0)
		{
			Combo_MergeCandidate.SelectedIndex = 0;
		}
		MergeMethod = MergeMethod_E.Different_Branch;
		((Label)ToggleComparisonResolution).Text = TB_SImilarityThreshold.ToString() + "%";
		TB_SImilarityThreshold.Value = 80;
		method_26();
	}

	public void ResetRamDBUI()
	{
		((Label)Label_JobInProgress).Text = "";
		ProgressBar_Job.Value = 0;
		TargetDBPath = "";
		SourceDBPath = "";
		Button_SelectSourceDB.Text = "Copied TO [Select DB]";
		Button_SelectTargetDB.Text = "Copied FROM [Select DB]";
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)OpenFileDialog_SourceDB).Title = "Select MS Access database to convert to SQLite...";
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() == 1)
		{
			Button3.Enabled = false;
			Button3.Text = "Conversion in progress...";
			BW_ConvertDB.RunWorkerAsync();
		}
		ErrorManagement.ShowErrorMessages();
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).Text = Common.StatusString;
		Application.DoEvents();
	}

	private void method_4(object sender, DoWorkEventArgs e)
	{
		Common.theSourceDB = ((DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")))).OpenDatabase(Common.theSourceMsAccessFileName, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
		DataValidateAllInOne.Options_ValidateAircraft = ((CheckBox)CB_Aircraft).Checked;
		DataValidateAllInOne.Options_ValidateShips = ((CheckBox)CB_Ships).Checked;
		DataValidateAllInOne.Options_ValidateSubs = ((CheckBox)CB_Submarines).Checked;
		DataValidateAllInOne.Options_ValidateFacilities = ((CheckBox)CB_Facilities).Checked;
		DataValidateAllInOne.Options_ValidateSatellites = ((CheckBox)CB_Satellites).Checked;
		DataValidateAllInOne.Options_ValidateWeapons = ((CheckBox)CB_Weapons).Checked;
		DataValidateAllInOne.Options_ValidateMounts = ((CheckBox)CB_Mounts).Checked;
		DataValidateAllInOne.Options_ValidateSensors = ((CheckBox)CB_Sensors).Checked;
		DataValidateAllInOne.Options_ValidateMags = ((CheckBox)CB_Magazines).Checked;
		DataValidateAllInOne.Options_ValidateLoadouts = ((CheckBox)CB_Loadouts).Checked;
		DataValidateAllInOne.Options_ValidateAirFacs = ((CheckBox)CB_AirFacs).Checked;
		DataValidateAllInOne.Options_ValidateDockFacs = ((CheckBox)CB_DockFacs).Checked;
		DataValidateAllInOne.Options_ValidateWarheads = ((CheckBox)CB_Warheads).Checked;
		DataValidateAllInOne.Options_ValidateComms = ((CheckBox)CB_CommDevices).Checked;
		DataValidateAllInOne.Options_ValidatePropulsion = ((CheckBox)CB_Propulsion).Checked;
		DataValidateAllInOne.Options_ValidateWeaponRecs = ((CheckBox)CB_WeaponRec).Checked;
		DataValidateAllInOne.Options_ValidateFuelRecs = ((CheckBox)CB_FuelRec).Checked;
		DataValidateAllInOne.Options_ValidateCargo = ((CheckBox)CB_ValidateCargo).Checked;
		DataValidateAllInOne.Options_ValidateDeprecationChecks = ((CheckBox)CB_DeprecationChecks).Checked;
		DataValidateAllInOne.Options_ValidateCopyOver = ((CheckBox)CB_CopyOver).Checked;
		DataValidateAllInOne.Options_ValidateOperationalYearAndService = ((CheckBox)CB_OperationalYearsAndService).Checked;
		DataValidateAllInOne.Options_ValidateMissingComponents = ((CheckBox)CB_MissingComponents).Checked;
		dateTime_0 = DateTime.Now;
		try
		{
			exception_0 = null;
			DataValidateAllInOne.RunValidationAllInOne();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			exception_0 = theExc;
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		dateTime_1 = DateTime.Now;
		if (!Information.IsNothing((object)exception_0))
		{
			Interaction.MsgBox((object)("Exception: " + exception_0.ToString()), (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = method_10((long)Math.Round((dateTime_1 - dateTime_0).TotalSeconds));
		if (Common.theSourceDB.OpenRecordset("Select * from Validation", RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value)).EOF)
		{
			Interaction.MsgBox((object)("Data validation completed, no errors found! Job duration: " + text), (MsgBoxStyle)64, (object)"Data Validation");
		}
		else if (!bool_2)
		{
			Interaction.MsgBox((object)("Validation errors present, please check the table named Validation. Job duration: " + text), (MsgBoxStyle)64, (object)"Data Validation");
		}
		else
		{
			_ = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Database_Validation.csv";
			method_6(text);
		}
		ErrorManagement.ShowErrorMessages();
		((Control)GroupBox1).Enabled = true;
	}

	private void method_6(string string_2)
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		string text = ((TextBox)CSVOutputFilePath).Text;
		int num = 0;
		while (File.Exists(text))
		{
			num++;
			text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Database_Validation" + Conversions.ToString(num) + ".csv";
			if (num > 9999)
			{
				break;
			}
		}
		DataTable dataTable = Common.get_Validation(Common.mySourceDB_Helper);
		StreamWriter streamWriter = ((ServerComputer)MyProject.Computer).FileSystem.OpenTextFileWriter(text, false);
		streamWriter.WriteLine("SourceAnnex, ComponentID, Errortext");
		foreach (DataRow row in dataTable.Rows)
		{
			streamWriter.WriteLine(Conversions.ToString(row["SourceAnnex"]) + ", " + Conversions.ToString(row["ComponentID"]) + ", " + Conversions.ToString(row["ErrorText"]).Replace(",", ";"));
		}
		streamWriter.Close();
		Interaction.MsgBox((object)(Conversions.ToString(dataTable.Rows.Count) + " validation errors present: Check " + text + ".\r\nJob duration: " + string_2), (MsgBoxStyle)64, (object)"Data Validation");
	}

	private void method_7(object sender, DoWorkEventArgs e)
	{
		dateTime_0 = DateTime.Now;
		try
		{
			exception_0 = null;
			Conversion.ConvertToSQLite(((FileDialog)OpenFileDialog_SourceDB).FileName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			exception_0 = theExc;
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		dateTime_1 = DateTime.Now;
		if (Information.IsNothing((object)exception_0))
		{
			string text = method_10((long)Math.Round((dateTime_1 - dateTime_0).TotalSeconds));
			Interaction.MsgBox((object)("DB Conversion Finished! Job duration: " + text), (MsgBoxStyle)0, (object)null);
		}
		else
		{
			Interaction.MsgBox((object)("An error was encountered: " + exception_0.Message + "\r\n\r\nConversion aborted, please try again."), (MsgBoxStyle)0, (object)null);
		}
		Button3.Enabled = true;
		Button3.Text = "Convert MS-Access to SQLite";
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() == 1)
		{
			((Control)GroupBox1).Enabled = false;
			Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
			Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
			Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
			Timer1.Start();
			vmethod_0().RunWorkerAsync();
		}
	}

	private string method_10(long long_0)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		string result;
		if (long_0 > 2147483647L)
		{
			result = "Very long";
		}
		else
		{
			TimeSpan timeSpan;
			try
			{
				timeSpan = TimeSpan.FromSeconds((double)long_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at 200091", ex2.Message);
				Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = "N/A";
				ProjectData.ClearProjectError();
				goto IL_02f0;
			}
			int num = (int)Math.Floor((double)timeSpan.Days / 7.0);
			int num2 = (int)Math.Floor((double)timeSpan.Days / 30.0);
			int num3 = (int)Math.Floor((double)timeSpan.Days / 365.0);
			result = ((num3 > 0) ? (Conversions.ToString(num3) + " y" + ((num2 - num3 * 12 == 0) ? "" : (" " + Conversions.ToString(num2 - num3 * 12) + " mon")).ToString()) : ((num2 > 0) ? (Conversions.ToString(num2) + " mon" + ((num - num2 * 4 == 0) ? "" : (" " + Conversions.ToString(num - num2 * 4) + " d")).ToString()) : ((num > 0) ? (Conversions.ToString(num) + " w" + ((timeSpan.Days - num * 7 == 0) ? "" : (" " + Conversions.ToString(timeSpan.Days - num * 7) + " d")).ToString()) : ((timeSpan.Days > 0) ? (Conversions.ToString(timeSpan.Days) + " d" + ((timeSpan.Hours != 0) ? (" " + Conversions.ToString(timeSpan.Hours) + " hrs") : "").ToString()) : ((timeSpan.Hours > 0) ? (Conversions.ToString(timeSpan.Hours) + " hrs" + ((timeSpan.Minutes != 0) ? (" " + Conversions.ToString(timeSpan.Minutes) + " min") : "").ToString()) : ((timeSpan.Minutes > 0) ? (Conversions.ToString(timeSpan.Minutes) + " min" + ((timeSpan.Seconds != 0) ? (" " + Conversions.ToString(timeSpan.Seconds) + " sec") : "").ToString()) : ((timeSpan.Seconds > 0) ? (Conversions.ToString(timeSpan.Seconds) + " sec") : ((timeSpan.Seconds == 0) ? "0" : "Error!"))))))));
		}
		goto IL_02f0;
		IL_02f0:
		return result;
	}

	private void method_11(object sender, EventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() == 1)
		{
			Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
			Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
			Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
			Button1.Enabled = false;
			Button1.Text = "Schema update in progress...";
			BW_UpdateSchema.RunWorkerAsync();
		}
	}

	private void method_12(object sender, DoWorkEventArgs e)
	{
		dateTime_0 = DateTime.Now;
		try
		{
			exception_0 = null;
			SchemaUpdate.PerformSchemaUpdate();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			exception_0 = theExc;
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		dateTime_1 = DateTime.Now;
		if (Information.IsNothing((object)exception_0))
		{
			string text = method_10((long)Math.Round((dateTime_1 - dateTime_0).TotalSeconds));
			Button1.Enabled = true;
			Button1.Text = "Update database to current schema";
			Interaction.MsgBox((object)("Import Finished! Job duration: " + text), (MsgBoxStyle)0, (object)null);
			ErrorManagement.ShowErrorMessages();
		}
		else
		{
			Interaction.MsgBox((object)("Exception: " + exception_0.ToString()), (MsgBoxStyle)0, (object)null);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		try
		{
			ToggleRamDBInstanceViewerPanel(value: false);
			string text = "";
			SaveMergeCandidatesList();
			if (string.IsNullOrEmpty(SourceDBPath))
			{
				text = text + "No Source DB" + Environment.NewLine;
			}
			if (Operators.CompareString(((FileDialog)OpenFileDialog_SourceDB).FileName, ((FileDialog)OpenFileDialog_TargetDB).FileName, true) == 0)
			{
				Interaction.MsgBox((object)"Source and target database is the same file! Aborting...", (MsgBoxStyle)0, (object)null);
				return;
			}
			if (string.IsNullOrEmpty(TargetDBPath))
			{
				text = text + "No Target DB" + Environment.NewLine;
			}
			if (Operators.CompareString(text, "", true) != 0)
			{
				text += "Aborting. . .";
				MessageBox.Show(text, "ERROR");
				return;
			}
			Common.theSourceMsAccessFileName = SourceDBPath;
			Common.theTargetMsAccessFileName = TargetDBPath;
			Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
			Common.myTargetDB_Conn = new OleDbConnection(Common.theTargetDBConnectionString);
			Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
			Common.myTargetDB_Helper = new MSAccessHelper(Common.myTargetDB_Conn);
			DBEngine dBEngine = (DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")));
			DBEngine obj = (DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")));
			Common.theSourceDB = dBEngine.OpenDatabase(SourceDBPath, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Common.theTargetDB = obj.OpenDatabase(TargetDBPath, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			LV_Loading.Items.Clear();
			((RichTextBox)Report).Text = "";
			ToggleCopyOverInteraction(value: false);
			copyoverins = new CopyOver();
			ToggleRamDBInstanceViewerPanel(value: true);
			Refresh_LV_CopyOverStatus();
			ToggleCopyOverInteraction(value: true);
			ResetRamDBUI();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at DB_01", ex2.Message);
			Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ResetRamDBUI();
			ProjectData.ClearProjectError();
		}
		ErrorManagement.ShowErrorMessages();
	}

	public void ToggleRamDBInstanceViewerPanel(bool value)
	{
		if (!Information.IsNothing((object)copyoverins))
		{
			((Control)PairGB).Visible = value;
			((Label)PairTitle).Text = copyoverins.SourceDB_Ram.Name + "<>" + copyoverins.TargetDB_Ram.Name + " pair";
		}
		else
		{
			((Control)PairGB).Visible = false;
		}
	}

	public void ToggleCopyOverInteraction(bool value)
	{
		if (!value)
		{
			Button_SelectSourceDB.Enabled = false;
			Button_SelectTargetDB.Enabled = false;
			Button_CreateRamDBPair.Enabled = false;
			Button_CreateRamDBPair.Text = "Creating RAMDB pair instance...";
		}
		else
		{
			Button_SelectSourceDB.Enabled = true;
			Button_SelectTargetDB.Enabled = true;
			Button_CreateRamDBPair.Enabled = true;
			Button_CreateRamDBPair.Text = "Create RAMDB pair instance";
		}
	}

	private void method_15(object sender, DoWorkEventArgs e)
	{
		dateTime_0 = DateTime.Now;
		try
		{
			exception_0 = null;
			Import.DoImportDatabase();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			exception_0 = theExc;
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		dateTime_1 = DateTime.Now;
		if (Information.IsNothing((object)exception_0))
		{
			string text = method_10((long)Math.Round((dateTime_1 - dateTime_0).TotalSeconds));
			Button_StartImport.Enabled = true;
			Button_StartImport.Text = "Start Import";
			Interaction.MsgBox((object)("Import Finished! Job duration: " + text), (MsgBoxStyle)0, (object)null);
			ErrorManagement.ShowErrorMessages();
		}
		else
		{
			Interaction.MsgBox((object)("Exception: " + exception_0.ToString()), (MsgBoxStyle)0, (object)null);
			Button_StartImport.Enabled = true;
		}
	}

	private void gKnIpnfmb3(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"This will DELETE all data in the target database and replace them with those from the source database. Are you sure you want to continue?", (MsgBoxStyle)4, (object)null) == 7)
		{
			return;
		}
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)OpenFileDialog_SourceDB).Title = "Select SOURCE database, where components are drawn FROM...";
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() != 1)
		{
			return;
		}
		if (!string.IsNullOrEmpty(((FileDialog)OpenFileDialog_SourceDB).InitialDirectory))
		{
			((FileDialog)OpenFileDialog_TargetDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			((FileDialog)OpenFileDialog_TargetDB).Title = "Select TARGET database, where components are imported TO...";
			if ((int)((CommonDialog)OpenFileDialog_TargetDB).ShowDialog() != 1)
			{
				return;
			}
			if (!string.IsNullOrEmpty(((FileDialog)OpenFileDialog_TargetDB).InitialDirectory))
			{
				Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
				Common.theTargetMsAccessFileName = ((FileDialog)OpenFileDialog_TargetDB).FileName;
				if (Operators.CompareString(Common.theSourceMsAccessFileName, Common.theTargetMsAccessFileName, true) == 0)
				{
					Interaction.MsgBox((object)"Source and target database is the same file! Aborting...", (MsgBoxStyle)0, (object)null);
					return;
				}
				Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
				Common.myTargetDB_Conn = new OleDbConnection(Common.theTargetDBConnectionString);
				Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
				Common.myTargetDB_Helper = new MSAccessHelper(Common.myTargetDB_Conn);
				DBEngine dBEngine = (DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")));
				DBEngine obj = (DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")));
				Common.theSourceDB = dBEngine.OpenDatabase(Common.theSourceMsAccessFileName, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Common.theTargetDB = obj.OpenDatabase(Common.theTargetMsAccessFileName, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Common.mySourceDB_Category = Common.get_GetDatabaseCategory(Common.theSourceDB, Common.mySourceDB_Helper);
				if (Information.IsNothing((object)Common.mySourceDB_Category))
				{
					Interaction.MsgBox((object)"Source database does not know what database category it is! Make sure to set the correct DatabaseCategory flag in the ManagementMisc table for the Target database after import.", (MsgBoxStyle)0, (object)null);
				}
				Common.myTargetDB_Category = Common.get_GetDatabaseCategory(Common.theTargetDB, Common.myTargetDB_Helper);
				Button_StartImport.Enabled = false;
				Button_StartImport.Text = "Import in progress...";
				vmethod_4().RunWorkerAsync();
			}
			else
			{
				Interaction.MsgBox((object)"Target database not fount!", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			Interaction.MsgBox((object)"Source database not found!", (MsgBoxStyle)0, (object)null);
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		if (!string.IsNullOrEmpty(((TextBox)TB_DeepCopyLoadouts_SourceID).Text) && Versioned.IsNumeric((object)((TextBox)TB_DeepCopyLoadouts_SourceID).Text))
		{
			int sourceAircraftID = Conversions.ToInteger(((TextBox)TB_DeepCopyLoadouts_SourceID).Text);
			if (!string.IsNullOrEmpty(((TextBox)TB_DeepCopyLoadouts_TargetID).Text) && Versioned.IsNumeric((object)((TextBox)TB_DeepCopyLoadouts_TargetID).Text))
			{
				int targetAircraftID = Conversions.ToInteger(((TextBox)TB_DeepCopyLoadouts_TargetID).Text);
				((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				((FileDialog)OpenFileDialog_SourceDB).Title = "Select the database:";
				if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() == 1)
				{
					Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
					Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
					Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
					Button_DeepCopyLoadouts.Enabled = false;
					DeepCopyAircraftLoadouts.PerformDeepCopy(sourceAircraftID, targetAircraftID, ((CheckBox)CB_DeepCopyLoadouts_RemoveExistingLoadouts).Checked);
					Button_DeepCopyLoadouts.Enabled = true;
					ErrorManagement.ShowErrorMessages();
				}
			}
			else
			{
				Interaction.MsgBox((object)"You must provide a valid target AC ID!", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			Interaction.MsgBox((object)"You must provide a valid source AC ID!", (MsgBoxStyle)0, (object)null);
		}
	}

	private void DBToolsForm_Shown(object sender, EventArgs e)
	{
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)OpenFileDialog_SourceDB).Title = "Select database to apply fix to:";
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() == 1)
		{
			Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
			Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
			Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
			if (Conversions.ToInteger(Common.mySourceDB_Helper.ExecuteScalar("Select count(*) from ModifierFacilitySignatureRadar where ID=3000")) == 0)
			{
				Common.mySourceDB_Helper.ExecuteNonQuery("INSERT INTO ModifierFacilitySignatureRadar (ID, Description, ModifierAtoD, ModifierEtoM) VALUES ('3000', 'Human Personnel', 0, 0)");
			}
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=3 , ModifierEtoM=3 where ID=2001");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=5 , ModifierEtoM=5 where ID=2002");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=20 , ModifierEtoM=20 where ID=2003");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=30 , ModifierEtoM=30 where ID=2004");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=40 , ModifierEtoM=40 where ID=2005");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=15 , ModifierEtoM=15 where ID=3001");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=20 , ModifierEtoM=20 where ID=3002");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=22.5 , ModifierEtoM=22.5 where ID=3003");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=25 , ModifierEtoM=25 where ID=3004");
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE ModifierFacilitySignatureRadar set ModifierAtoD=5 , ModifierEtoM=5 where ID=3011");
		}
		OleDbDataReader val = Common.mySourceDB_Helper.ExecuteReader("SELECT ID from DataFacility where category in (5001, 5002)");
		while (val.Read())
		{
			string text = "Select ModifierAtoD from ModifierFacilitySignatureRadar where ID = (Select ModifierRadar from MiscFacility where ID=" + Conversions.ToString(Conversions.ToInteger(val["ID"])) + ")";
			float num = Conversions.ToSingle(Common.mySourceDB_Helper.ExecuteScalar(text));
			text = "UPDATE DataFacilitySignatures set Front=" + Conversions.ToString(num) + ", Side=" + Conversions.ToString(num) + ", Rear=" + Conversions.ToString(num) + ", [Top]=" + Conversions.ToString(num) + " where ID=" + Conversions.ToString(Conversions.ToInteger(val["ID"])) + " and Type in (5001, 5002)";
			Common.mySourceDB_Helper.ExecuteNonQuery(text);
		}
		Interaction.MsgBox((object)"Finished!", (MsgBoxStyle)0, (object)null);
		ErrorManagement.ShowErrorMessages();
	}

	private void method_19(object sender, EventArgs e)
	{
		List<CheckBox> list = new List<CheckBox>
		{
			(CheckBox)(object)CB_Aircraft,
			(CheckBox)(object)CB_AirFacs,
			(CheckBox)(object)CB_CommDevices,
			(CheckBox)(object)CB_DeprecationChecks,
			(CheckBox)(object)CB_DockFacs,
			(CheckBox)(object)CB_Facilities,
			(CheckBox)(object)CB_FuelRec,
			(CheckBox)(object)CB_Loadouts,
			(CheckBox)(object)CB_Magazines,
			(CheckBox)(object)CB_Mounts,
			(CheckBox)(object)CB_Propulsion,
			(CheckBox)(object)CB_Satellites,
			(CheckBox)(object)CB_Sensors,
			(CheckBox)(object)CB_Ships,
			(CheckBox)(object)CB_Submarines,
			(CheckBox)(object)CB_ValidateCargo,
			(CheckBox)(object)CB_Warheads,
			(CheckBox)(object)CB_WeaponRec,
			(CheckBox)(object)CB_Weapons
		};
		foreach (CheckBox item in list)
		{
			item.Checked = ((CheckBox)SelectAll).Checked;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (!((CheckBox)CheckBox_CSVOutput).Checked)
		{
			bool_2 = false;
		}
		else
		{
			bool_2 = true;
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog_CSVExportPath).InitialDirectory = ((TextBox)CSVOutputFilePath).Text;
		if ((int)((CommonDialog)OpenFileDialog_CSVExportPath).ShowDialog() == 1)
		{
			((TextBox)CSVOutputFilePath).Text = ((FileDialog)OpenFileDialog_CSVExportPath).FileName;
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f4: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Invalid comparison between Unknown and I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		List<List<string>> list = new List<List<string>>();
		((FileDialog)OpenFileDialog_SourceDB).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)OpenFileDialog_SourceDB).Title = "Select the database:";
		if ((int)((CommonDialog)OpenFileDialog_SourceDB).ShowDialog() != 1)
		{
			return;
		}
		Common.theSourceMsAccessFileName = ((FileDialog)OpenFileDialog_SourceDB).FileName;
		Common.mySourceDB_Conn = new OleDbConnection(Common.theSourceDBConnectionString);
		Common.mySourceDB_Helper = new MSAccessHelper(Common.mySourceDB_Conn);
		((FileDialog)OpenFileDialog_CSVExportPath).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)OpenFileDialog_CSVExportPath).Title = "Select the auto-update CSV:";
		if ((int)((CommonDialog)OpenFileDialog_CSVExportPath).ShowDialog() != 1)
		{
			return;
		}
		bool flag = false;
		string text = "";
		string fileName = ((FileDialog)OpenFileDialog_CSVExportPath).FileName;
		TextFieldParser val = new TextFieldParser(fileName);
		try
		{
			val.TextFieldType = (FieldType)0;
			val.SetDelimiters(new string[1] { "," });
			while (!val.EndOfData)
			{
				try
				{
					string[] source = val.ReadFields();
					list.Add(source.ToList());
				}
				catch (MalformedLineException ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					MalformedLineException ex2 = ex;
					flag = true;
					text = "Line " + ((Exception)(object)ex2).Message + "is not valid and will be skipped.\\n";
					ProjectData.ClearProjectError();
				}
			}
			if (flag)
			{
				Interaction.MsgBox((object)text, (MsgBoxStyle)0, (object)null);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		CSV_Update_Button.Enabled = false;
		CSVUpdate.Run(list);
		CSV_Update_Button.Enabled = true;
		ErrorManagement.ShowErrorMessages();
	}

	private void method_23(object sender, EventArgs e)
	{
	}

	private void method_24(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).Filter = "All files (*.*)|*.*";
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		if (!string.IsNullOrEmpty(((FileDialog)val).FileName))
		{
			Stream stream = val.OpenFile();
			new StreamReader(stream).ReadToEnd().Split(new char[1] { ',' });
			dictionary_0 = new Dictionary<string, Dictionary<int, int>>();
			dictionary_0.Clear();
			TextFieldParser val2 = new TextFieldParser(((FileDialog)val).FileName);
			val2.Delimiters = new string[2] { ",", " " };
			val2.TextFieldType = (FieldType)0;
			string[] array = val2.ReadFields();
			foreach (string key in array)
			{
				dictionary_0.Add(key, new Dictionary<int, int>());
			}
			if (dictionary_0.Count != 0)
			{
				return;
			}
			MessageBox.Show("The file does not contain any DBID entry", "No DBID");
			Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
			int num = 1;
			int num2 = 0;
			int num3 = 0;
			while (!val2.EndOfData)
			{
				string[] array2 = val2.ReadFields();
				int num4 = 0;
				string[] array3 = array2;
				foreach (string text in array3)
				{
					int result = -1;
					if (string.IsNullOrEmpty(text) && !int.TryParse(text, out result))
					{
						if (!string.IsNullOrEmpty(text))
						{
							if (!dictionary.ContainsKey(dictionary_0.ElementAt(num4).Key))
							{
								dictionary.Add(dictionary_0.ElementAt(num4).Key, new List<int>());
							}
							dictionary[dictionary_0.ElementAt(num4).Key].Add(num);
							num3++;
						}
					}
					else
					{
						dictionary_0.ElementAt(num4).Value.Add(result, result);
						num2++;
					}
					num4++;
				}
				num++;
			}
			if (num3 > 0)
			{
				string text2 = default(string);
				foreach (KeyValuePair<string, List<int>> item in dictionary)
				{
					text2 = text2 + item.Key + " in line(s) : ";
					foreach (int item2 in item.Value)
					{
						text2 = text2 + item2 + ", ";
					}
					text2 += " ; ";
				}
				MessageBox.Show(num3 + " errors and " + num2 + " successes when parsing the DBIDs. " + text2, "Content format invalid");
			}
			if (num2 == 0)
			{
				MessageBox.Show("The file does not contain any valid DBID entry", "No DBID");
				return;
			}
			if (num2 > 0)
			{
				MessageBox.Show(num2 + " DBIDs were successfully parsed", "Successfull parsing");
			}
			EligibleCSV_Path = ((FileDialog)val).FileName;
		}
		else
		{
			MessageBox.Show("Filename is empty", "Empty Filename");
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		method_26();
	}

	private void method_26()
	{
		((Label)Label_SimilarityThreshold).Text = "Similarities threshold " + TB_SImilarityThreshold.Value + " %";
	}

	private void method_27(object sender, EventArgs e)
	{
		int num = (int)(MergeMethod + 1);
		if (num > Enum.GetValues(typeof(MergeMethod_E)).GetUpperBound(0))
		{
			num = 0;
		}
		MergeMethod = (MergeMethod_E)num;
	}

	private void method_28(object sender, EventArgs e)
	{
		int num = (int)(MergeComparisonResolution + 1);
		if (num > Enum.GetValues(typeof(ComparisonDepth)).GetUpperBound(0))
		{
			num = 0;
		}
		MergeComparisonResolution = (ComparisonDepth)num;
	}

	private void method_29(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)val).Title = "Select SOURCE database, where components are copied TO...";
		((FileDialog)val).Filter = "Microsoft Access Database Files(*.mdb)|*.mdb|All files (*.*)|*.*";
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			if (string.IsNullOrEmpty(((FileDialog)val).InitialDirectory))
			{
				Interaction.MsgBox((object)"Source database not found!", (MsgBoxStyle)0, (object)null);
			}
			else if (!string.IsNullOrEmpty(((FileDialog)val).FileName))
			{
				SourceDBPath = ((FileDialog)val).FileName;
			}
			else
			{
				MessageBox.Show("Filename is empty", "Empty Filename");
			}
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)val).Title = "Select TARGET database, where components are copied FROM...";
		((FileDialog)val).Filter = "Microsoft Access Database Files(*.mdb)|*.mdb|All files (*.*)|*.*";
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			if (string.IsNullOrEmpty(((FileDialog)val).InitialDirectory))
			{
				Interaction.MsgBox((object)"Target database not found!", (MsgBoxStyle)0, (object)null);
				return;
			}
			if (string.IsNullOrEmpty(((FileDialog)val).FileName))
			{
				MessageBox.Show("Filename is empty", "Empty Filename");
				return;
			}
			TargetDBPath = ((FileDialog)val).FileName;
			Button_SelectTargetDB.Text = "FROM : " + val.SafeFileName;
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		method_32();
	}

	private void method_32()
	{
		SaveMergeCandidatesList();
		if (Combo_MergeCandidate.SelectedItem != null)
		{
			currentMergeCandidateTableSelection = ((LV_Item_ComboMergeCandidate)Combo_MergeCandidate.SelectedItem).Table;
			RefreshMergeCandidatesList(currentMergeCandidateTableSelection);
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		Process.Start(Path.Combine(GameGeneral.ConfigFolderPath, "RamDB_Config.json"));
	}

	private void method_34(object sender, KeyEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		if (!e.Control || (int)e.KeyCode != 67)
		{
			return;
		}
		if (e.Shift)
		{
			string text = "";
			foreach (DarkListItem item in LV_WorkNode.Items)
			{
				text += item.ToString();
				text += Environment.NewLine;
			}
			Clipboard.SetData(DataFormats.StringFormat, (object)text);
		}
		else if (LV_WorkNode.SelectedItems.Count > 0)
		{
			string text2 = LV_WorkNode.SelectedItems[0].ToString();
			Clipboard.SetData(DataFormats.StringFormat, (object)text2);
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		((RichTextBox)TB_LuaOutput).Text = "";
	}

	private void method_36(object sender, EventArgs e)
	{
		LuaInterpreter.ExecuteCode(((RichTextBox)RT_LuaInput).Text);
		ErrorManagement.ShowErrorMessages();
	}

	private void method_37(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		DebugMode = true;
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		((FileDialog)val).Title = "Select a RAMDB setup file";
		((FileDialog)val).Filter = "All files (*.*)|*.*";
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		if (string.IsNullOrEmpty(((FileDialog)val).InitialDirectory))
		{
			Interaction.MsgBox((object)"File not found!", (MsgBoxStyle)0, (object)null);
		}
		else if (!string.IsNullOrEmpty(((FileDialog)val).FileName))
		{
			string[] array = Strings.Split(new StreamReader(((FileDialog)val).FileName).ReadToEnd(), "\r\n", -1, (CompareMethod)1);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (HashTableNodeConfig item in Config.ConfigCollection)
			{
				if (!dictionary.ContainsKey(item.DisplayName.ToLowerInvariant()))
				{
					dictionary.Add(item.DisplayName.ToLowerInvariant(), item.PrimaryElevation);
				}
			}
			DebugPath = Path.GetDirectoryName(((FileDialog)val).FileName);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i = checked(i + 1))
			{
				string text = array2[i].Replace(" ", "");
				if (text.Contains("differentbranch"))
				{
					MergeMethod = MergeMethod_E.Different_Branch;
				}
				else if (!text.Contains("samebranch"))
				{
					if (!text.Contains("from"))
					{
						if (text.Contains("to"))
						{
							string text2 = text.Replace("to", "");
							if (!string.IsNullOrEmpty(text2))
							{
								string text3 = DebugPath + Conversions.ToString(Path.DirectorySeparatorChar) + text2 + ".mdb";
								if (File.Exists(text3))
								{
									SourceDBPath = text3;
								}
							}
							continue;
						}
						foreach (KeyValuePair<string, string> item2 in dictionary)
						{
							if (!text.ToLowerInvariant().Contains(item2.Key))
							{
								continue;
							}
							string[] array3 = text.Replace(item2.Key, "").Split(new char[1] { ',' });
							foreach (string text4 in array3)
							{
								int result = 0;
								if (int.TryParse(text4, out result) && !MergeCandidates[item2.Value].ContainsKey(text4))
								{
									MergeCandidates[item2.Value].Add(text4, new MergeCandidateWrapper(text4, this));
								}
							}
							break;
						}
						continue;
					}
					string text5 = text.Replace("from", "");
					if (!string.IsNullOrEmpty(text5))
					{
						string text6 = DebugPath + Conversions.ToString(Path.DirectorySeparatorChar) + text5 + ".mdb";
						if (File.Exists(text6))
						{
							TargetDBPath = text6;
						}
					}
				}
				else
				{
					MergeMethod = MergeMethod_E.Same_Branch;
				}
			}
		}
		else
		{
			MessageBox.Show("Filename is empty", "Empty Filename");
		}
	}

	private void method_38(object sender, EventArgs e)
	{
		LuaInterpreter.FetchMethods();
	}

	private void method_39(object sender, EventArgs e)
	{
		copyoverins.DoCopyOver();
	}

	private void method_40(object sender, EventArgs e)
	{
		copyoverins.OpenRamDBBrowser();
	}

	private void method_41(object sender, EventArgs e)
	{
		ToggleOperationStackFilter(OperationFilterType.RamdbRoutine);
	}

	public bool IsOperationStackFilterEnabled(OperationFilterType type)
	{
		return OperationFiltersState.Contains(type);
	}

	public void EnableOperationStackFilter(OperationFilterType type)
	{
		if (!IsOperationStackFilterEnabled(type))
		{
			OperationFiltersState.Add(type);
			RebuildOperationStackFilter();
			((ButtonBase)OperationFilters[type]).BackColor = Color.FromArgb(255, 192, 255, 192);
		}
	}

	public void DisableOperationStackFilter(OperationFilterType type)
	{
		if (IsOperationStackFilterEnabled(type))
		{
			OperationFiltersState.Remove(type);
			RebuildOperationStackFilter();
			((ButtonBase)OperationFilters[type]).BackColor = SystemColors.Control;
		}
	}

	public void ToggleOperationStackFilter(OperationFilterType type)
	{
		if (IsOperationStackFilterEnabled(type))
		{
			DisableOperationStackFilter(type);
		}
		else
		{
			EnableOperationStackFilter(type);
		}
	}

	public void RebuildOperationStackFilter()
	{
		LV_WorkNode.Items.Clear();
		foreach (var item in OperationStack)
		{
			if (IsOperationStackFilterEnabled(item.Item1))
			{
				LV_WorkNode.Items.Add(new DarkListItem(item.Item2));
			}
		}
	}

	private void method_42(object sender, EventArgs e)
	{
		ToggleOperationStackFilter(OperationFilterType.RamDB);
	}

	private void method_43(object sender, EventArgs e)
	{
		ToggleOperationStackFilter(OperationFilterType.SQL);
	}

	public void ClearOperationStack()
	{
		OperationStack.Clear();
		LV_WorkNode.Items.Clear();
	}

	public bool SaveOperationStack()
	{
		bool result;
		try
		{
			RebuildOperationStackFilter();
			List<string> list = new List<string>();
			foreach (OperationFilterType item in OperationFiltersState)
			{
				list.Add(item.ToString());
			}
			if (list.Count > 0)
			{
				string text = string.Join("_", list);
				StreamWriter streamWriter = new StreamWriter(DebugPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Operations_" + text + ".txt", append: false);
				foreach (DarkListItem item2 in LV_WorkNode.Items)
				{
					streamWriter.WriteLine(item2.ToString());
				}
				streamWriter.Close();
				result = true;
				goto IL_010e;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_010e;
		}
		result = false;
		goto IL_010e;
		IL_010e:
		return result;
	}

	public void AddToOperationStack(OperationFilterType type, string description)
	{
		OperationStack.Add((type, description));
	}

	private bool method_44(object object_0, EventArgs eventArgs_0)
	{
		return SaveOperationStack();
	}

	private void method_45(object sender, EventArgs e)
	{
	}

	private void method_46(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			e.SuppressKeyPress = true;
			method_32();
		}
	}

	private void method_47(object sender, EventArgs e)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		Button_BoostCoastTweaker.Enabled = false;
		try
		{
			if (!Versioned.IsNumeric((object)((TextBox)TB_BoostCoastTweak_WeaponID).Text))
			{
				Interaction.MsgBox((object)"Weapon ID must be a valid number", (MsgBoxStyle)0, (object)null);
			}
			else if (Versioned.IsNumeric((object)((TextBox)TB_BoostCoastTweak_BodyDiameter).Text))
			{
				if (Versioned.IsNumeric((object)((TextBox)TB_BoostCoastTweak_BodyLength).Text))
				{
					if (!Versioned.IsNumeric((object)((TextBox)TB_BoostCoastTweak_LaunchWeight).Text))
					{
						Interaction.MsgBox((object)"Launch weight must be a valid number", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (!Versioned.IsNumeric((object)((TextBox)TB_BoostCoastTweak_BurnoutWeight).Text))
					{
						Interaction.MsgBox((object)"Burnout weight must be a valid number", (MsgBoxStyle)0, (object)null);
						return;
					}
					Button_BoostCoastTweaker.Enabled = false;
					Scenario theScen = new Scenario("Test", null, null);
					theScen.DBUsed = Crypto.GetFileHashFromFilename(((FileDialog)openFileDialog_4).FileName);
					((Label)Label_BoostCoastTweaker_BoostTime).Text = "Loading DB...";
					Application.DoEvents();
					Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, Conversions.ToInteger(((TextBox)TB_BoostCoastTweak_WeaponID).Text), bool_5: true);
					if (!newWeapon.UsesBoostCoastModel.Value)
					{
						Interaction.MsgBox((object)"Selected weapon does not use boost-coast propulsion model", (MsgBoxStyle)0, (object)null);
						return;
					}
					((Label)Label_BoostCoastTweaker_WeaponName).Text = newWeapon.Name;
					((Label)Label_BoostCoastTweaker_BoostTime).Text = "Calculating...";
					Application.DoEvents();
					bool assumeAirLaunch = DBFunctions.CheckWeaponIsInAircraftLoadouts(theScen.DBConnection, newWeapon.DBID) || newWeapon.MinLaunchAlt_AGL > 0f || newWeapon.MinLaunchAlt_ASL > 0f;
					(int, int) tuple = DBValidation.CalculateWeaponBurnTime(newWeapon.DBID, theScen, assumeAirLaunch, Conversions.ToSingle(((TextBox)TB_BoostCoastTweak_BodyDiameter).Text), Conversions.ToSingle(((TextBox)TB_BoostCoastTweak_BodyLength).Text), Conversions.ToInteger(((TextBox)TB_BoostCoastTweak_LaunchWeight).Text), Conversions.ToInteger(((TextBox)TB_BoostCoastTweak_BurnoutWeight).Text));
					((Label)Label_BoostCoastTweaker_BoostTime).Text = "Boost time: " + Conversions.ToString(tuple.Item1) + " sec";
				}
				else
				{
					Interaction.MsgBox((object)"Body length must be a valid number", (MsgBoxStyle)0, (object)null);
				}
			}
			else
			{
				Interaction.MsgBox((object)"Body diameter must be a valid number", (MsgBoxStyle)0, (object)null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			Button_BoostCoastTweaker.Enabled = true;
		}
	}

	private void method_48(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)openFileDialog_4).ShowDialog() == 1)
		{
			((TextBox)TB_BoostCoastTweak_DBFile).Text = Path.GetFileName(((FileDialog)openFileDialog_4).FileName);
		}
	}

	static DBToolsForm()
	{
		Class72.smethod_20();
	}
}
