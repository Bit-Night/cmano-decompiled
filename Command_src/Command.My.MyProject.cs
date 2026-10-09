using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.My;

[HideModuleName]
[StandardModule]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class MyProject
{
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class MyForms
	{
		[ThreadStatic]
		private static System.Collections.Hashtable hashtable_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AboutBox1 m_AboutBox1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddComms m_AddComms;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddHostingFacility m_AddHostingFacility;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddMagazine m_AddMagazine;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddMount m_AddMount;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddPatrol m_AddPatrol;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddRangeSymbol m_AddRangeSymbol;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddReferencePointAtLocation m_AddReferencePointAtLocation;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSatellite m_AddSatellite;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSensor m_AddSensor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSide m_AddSide;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddUnit m_AddUnit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddWeaponRecord m_AddWeaponRecord;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AdvancedDialog m_AdvancedDialog;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AggregateUnitEditor m_AggregateUnitEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AGU_Control m_AGU_Control;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AirOps m_AirOps;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AirTaskingOrder m_AirTaskingOrder;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AttackTarget m_AttackTarget;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BenchmarkForm m_BenchmarkForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BrowseScenarioPlatforms m_BrowseScenarioPlatforms;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BulkCommAddition m_BulkCommAddition;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignEditorWindow m_CampaignEditorWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignEnd m_CampaignEnd;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignPlayWindow m_CampaignPlayWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignScenarioWindow m_CampaignScenarioWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOps m_CargoOps;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOpsContainer m_CargoOpsContainer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOpsV2 m_CargoOpsV2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ChanceOfAppearance m_ChanceOfAppearance;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ChooseSide m_ChooseSide;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CommandDarkFormParent m_CommandDarkFormParent;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CommandFormParent m_CommandFormParent;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CommandSecondaryFormBase m_CommandSecondaryFormBase;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConfirmLandingPlanDialog m_ConfirmLandingPlanDialog;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConsoleWindow2 m_ConsoleWindow2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactReport m_ContactReport;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CopyOverPrompt m_CopyOverPrompt;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CopyOverSimilarityPrompt m_CopyOverSimilarityPrompt;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CPEBannerForm m_CPEBannerForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CurrentFlightPlanEditor m_CurrentFlightPlanEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CustomLayersForm m_CustomLayersForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DamageControlWindow m_DamageControlWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DarkSecondaryFormBase m_DarkSecondaryFormBase;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DarkUIForm m_DarkUIForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DBToolsForm m_DBToolsForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugForm m_DebugForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugOptions m_DebugOptions;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugTool m_DebugTool;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DISAdapterSelectionForm m_DISAdapterSelectionForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DISForm m_DISForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DockingOps m_DockingOps;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DoctrineForm m_DoctrineForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditAC m_EditAC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditAction m_EditAction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditBoats m_EditBoats;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditBriefing m_EditBriefing;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargo m_EditCargo;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargoContainer m_EditCargoContainer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargoV2 m_EditCargoV2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCondition m_EditCondition;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCustomEnvironmentArea m_EditCustomEnvironmentArea;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditEvent m_EditEvent;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditSpecialAction m_EditSpecialAction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditTrigger m_EditTrigger;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditWeather m_EditWeather;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EnablersForm m_EnablersForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ErrorForm m_ErrorForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Evaluation m_Evaluation;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Export_ImportFeedback m_Export_ImportFeedback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ExportImportTool m_ExportImportTool;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FixedFacilityOrientation m_FixedFacilityOrientation;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanAircraftLoadout m_FlightPlanAircraftLoadout;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditor m_FlightPlanEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargets m_FlightPlanEditorTargets;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargetsArea m_FlightPlanEditorTargetsArea;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargetsPreliminary m_FlightPlanEditorTargetsPreliminary;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorWaypointDetails m_FlightPlanEditorWaypointDetails;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorWeaponRoute m_FlightPlanEditorWeaponRoute;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanErrors m_FlightPlanErrors;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanTargets m_FlightPlanTargets;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanTime m_FlightPlanTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FloatingLicenseErrorForm m_FloatingLicenseErrorForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_QuickTurnaround m_Form_QuickTurnaround;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_SetFuelAndAirborneTime m_Form_SetFuelAndAirborneTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FormationEditor m_FormationEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GroupFilterManager m_GroupFilterManager;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HashtableNodeEditor m_HashtableNodeEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Hotkeys m_Hotkeys;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IconeCustomizer m_IconeCustomizer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InputDialog m_InputDialog;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InsufficientLicenseWindow m_InsufficientLicenseWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InteractiveAnalysisForm m_InteractiveAnalysisForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InteractiveManual m_InteractiveManual;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InternalDBViewer m_InternalDBViewer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LandingPlanner m_LandingPlanner;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListActions m_ListActions;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListConditions m_ListConditions;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListEvents m_ListEvents;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListSpecialActions m_ListSpecialActions;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListTriggers m_ListTriggers;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LoadGroup m_LoadGroup;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LoadScenario m_LoadScenario;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Losses m_Losses;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LOSTool m_LOSTool;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LuaEditorOperationPlanner m_LuaEditorOperationPlanner;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LuaSocketClient m_LuaSocketClient;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Magazines m_Magazines;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MainForm m_MainForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MainSplash m_MainSplash;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MapSettings m_MapSettings;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MCMWindow m_MCMWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MessageLogWindow_RawText m_MessageLogWindow_RawText;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Migration m_Migration;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MinefieldForm m_MinefieldForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MissionActivationTime m_MissionActivationTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MissionEditor m_MissionEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultipleUnitSensors m_MultipleUnitSensors;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NavalFormationEditor m_NavalFormationEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NewMessageForm m_NewMessageForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NewMission m_NewMission;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NotifyConnecting m_NotifyConnecting;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OperationPlanner m_OperationPlanner;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Options m_Options;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ORBAT m_ORBAT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PE_LicenseRevoke m_PE_LicenseRevoke;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PE_LicensingForm m_PE_LicensingForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Postures m_Postures;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PriorityTargetForm m_PriorityTargetForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public QuickBattle m_QuickBattle;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ReadyAircraft m_ReadyAircraft;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimeChatInputBar m_RealtimeChatInputBar;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimeLobby m_RealtimeLobby;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimeLobbyLogin m_RealtimeLobbyLogin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimeLobbyLoginWait m_RealtimeLobbyLoginWait;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimePlayerConnect m_RealtimePlayerConnect;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealtimePlayerLogin m_RealtimePlayerLogin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RecorderForm m_RecorderForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ReferencePointManager m_ReferencePointManager;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RenameObject m_RenameObject;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RenameSide m_RenameSide;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ResumeFromSave m_ResumeFromSave;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RoadSystem_Toolbox m_RoadSystem_Toolbox;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SatelliteCustomOrbit m_SatelliteCustomOrbit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SatPredictionForm m_SatPredictionForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SaveGroup m_SaveGroup;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenarioMerge m_ScenarioMerge;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenarioTitle m_ScenarioTitle;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenAttachmentsWindow m_ScenAttachmentsWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScoringWindow m_ScoringWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SelectLoadout m_SelectLoadout;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SelectSAO m_SelectSAO;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Sides m_Sides;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SpecialActionsForm m_SpecialActionsForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SpeedAlt m_SpeedAlt;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SplitUnit m_SplitUnit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StartGame m_StartGame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteamPublishScenarioForm m_SteamPublishScenarioForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteamUpdateScenarioForm m_SteamUpdateScenarioForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TankerPlanner m_TankerPlanner;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimesAndDuration m_TimesAndDuration;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimeToReadyWindow m_TimeToReadyWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimeUnderway m_TimeUnderway;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TitleAndDescription m_TitleAndDescription;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitComms m_UnitComms;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitDecisionChecklistWindow m_UnitDecisionChecklistWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitMessageLog m_UnitMessageLog;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSelection m_UnitSelection;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSensors m_UnitSensors;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSerialEditor m_UnitSerialEditor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public VerticalProfilerRenderer m_VerticalProfilerRenderer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public WeaponsWindow m_WeaponsWindow;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiplayerForm m_WEGOMultiplayerForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public WEGOMultiplayerTimings m_WEGOMultiplayerTimings;

		public AboutBox1 AboutBox1
		{
			get
			{
				m_AboutBox1 = smethod_0(m_AboutBox1);
				return m_AboutBox1;
			}
			set
			{
				if (value != m_AboutBox1)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AboutBox1);
				}
			}
		}

		public AddComms AddComms
		{
			get
			{
				m_AddComms = smethod_0(m_AddComms);
				return m_AddComms;
			}
			set
			{
				if (value != m_AddComms)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddComms);
				}
			}
		}

		public AddHostingFacility AddHostingFacility
		{
			get
			{
				m_AddHostingFacility = smethod_0(m_AddHostingFacility);
				return m_AddHostingFacility;
			}
			set
			{
				if (value != m_AddHostingFacility)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddHostingFacility);
				}
			}
		}

		public AddMagazine AddMagazine
		{
			get
			{
				m_AddMagazine = smethod_0(m_AddMagazine);
				return m_AddMagazine;
			}
			set
			{
				if (value != m_AddMagazine)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddMagazine);
				}
			}
		}

		public AddMount AddMount
		{
			get
			{
				m_AddMount = smethod_0(m_AddMount);
				return m_AddMount;
			}
			set
			{
				if (value != m_AddMount)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddMount);
				}
			}
		}

		public AddPatrol AddPatrol
		{
			get
			{
				m_AddPatrol = smethod_0(m_AddPatrol);
				return m_AddPatrol;
			}
			set
			{
				if (value != m_AddPatrol)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddPatrol);
				}
			}
		}

		public AddRangeSymbol AddRangeSymbol
		{
			get
			{
				m_AddRangeSymbol = smethod_0(m_AddRangeSymbol);
				return m_AddRangeSymbol;
			}
			set
			{
				if (value != m_AddRangeSymbol)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddRangeSymbol);
				}
			}
		}

		public AddReferencePointAtLocation AddReferencePointAtLocation
		{
			get
			{
				m_AddReferencePointAtLocation = smethod_0(m_AddReferencePointAtLocation);
				return m_AddReferencePointAtLocation;
			}
			set
			{
				if (value != m_AddReferencePointAtLocation)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddReferencePointAtLocation);
				}
			}
		}

		public AddSatellite AddSatellite
		{
			get
			{
				m_AddSatellite = smethod_0(m_AddSatellite);
				return m_AddSatellite;
			}
			set
			{
				if (value != m_AddSatellite)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddSatellite);
				}
			}
		}

		public AddSensor AddSensor
		{
			get
			{
				m_AddSensor = smethod_0(m_AddSensor);
				return m_AddSensor;
			}
			set
			{
				if (value != m_AddSensor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddSensor);
				}
			}
		}

		public AddSide AddSide
		{
			get
			{
				m_AddSide = smethod_0(m_AddSide);
				return m_AddSide;
			}
			set
			{
				if (value != m_AddSide)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddSide);
				}
			}
		}

		public AddUnit AddUnit
		{
			get
			{
				m_AddUnit = smethod_0(m_AddUnit);
				return m_AddUnit;
			}
			set
			{
				if (value != m_AddUnit)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddUnit);
				}
			}
		}

		public AddWeaponRecord AddWeaponRecord
		{
			get
			{
				m_AddWeaponRecord = smethod_0(m_AddWeaponRecord);
				return m_AddWeaponRecord;
			}
			set
			{
				if (value != m_AddWeaponRecord)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AddWeaponRecord);
				}
			}
		}

		public AdvancedDialog AdvancedDialog
		{
			get
			{
				m_AdvancedDialog = smethod_0(m_AdvancedDialog);
				return m_AdvancedDialog;
			}
			set
			{
				if (value != m_AdvancedDialog)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AdvancedDialog);
				}
			}
		}

		public AggregateUnitEditor AggregateUnitEditor
		{
			get
			{
				m_AggregateUnitEditor = smethod_0(m_AggregateUnitEditor);
				return m_AggregateUnitEditor;
			}
			set
			{
				if (value != m_AggregateUnitEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AggregateUnitEditor);
				}
			}
		}

		public AGU_Control AGU_Control
		{
			get
			{
				m_AGU_Control = smethod_0(m_AGU_Control);
				return m_AGU_Control;
			}
			set
			{
				if (value != m_AGU_Control)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AGU_Control);
				}
			}
		}

		public AirOps AirOps
		{
			get
			{
				m_AirOps = smethod_0(m_AirOps);
				return m_AirOps;
			}
			set
			{
				if (value != m_AirOps)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AirOps);
				}
			}
		}

		public AirTaskingOrder AirTaskingOrder
		{
			get
			{
				m_AirTaskingOrder = smethod_0(m_AirTaskingOrder);
				return m_AirTaskingOrder;
			}
			set
			{
				if (value != m_AirTaskingOrder)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AirTaskingOrder);
				}
			}
		}

		public AttackTarget AttackTarget
		{
			get
			{
				m_AttackTarget = smethod_0(m_AttackTarget);
				return m_AttackTarget;
			}
			set
			{
				if (value != m_AttackTarget)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_AttackTarget);
				}
			}
		}

		public BenchmarkForm BenchmarkForm
		{
			get
			{
				m_BenchmarkForm = smethod_0(m_BenchmarkForm);
				return m_BenchmarkForm;
			}
			set
			{
				if (value != m_BenchmarkForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_BenchmarkForm);
				}
			}
		}

		public BrowseScenarioPlatforms BrowseScenarioPlatforms
		{
			get
			{
				m_BrowseScenarioPlatforms = smethod_0(m_BrowseScenarioPlatforms);
				return m_BrowseScenarioPlatforms;
			}
			set
			{
				if (value != m_BrowseScenarioPlatforms)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_BrowseScenarioPlatforms);
				}
			}
		}

		public BulkCommAddition BulkCommAddition
		{
			get
			{
				m_BulkCommAddition = smethod_0(m_BulkCommAddition);
				return m_BulkCommAddition;
			}
			set
			{
				if (value != m_BulkCommAddition)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_BulkCommAddition);
				}
			}
		}

		public CampaignEditorWindow CampaignEditorWindow
		{
			get
			{
				m_CampaignEditorWindow = smethod_0(m_CampaignEditorWindow);
				return m_CampaignEditorWindow;
			}
			set
			{
				if (value != m_CampaignEditorWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CampaignEditorWindow);
				}
			}
		}

		public CampaignEnd CampaignEnd
		{
			get
			{
				m_CampaignEnd = smethod_0(m_CampaignEnd);
				return m_CampaignEnd;
			}
			set
			{
				if (value != m_CampaignEnd)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CampaignEnd);
				}
			}
		}

		public CampaignPlayWindow CampaignPlayWindow
		{
			get
			{
				m_CampaignPlayWindow = smethod_0(m_CampaignPlayWindow);
				return m_CampaignPlayWindow;
			}
			set
			{
				if (value != m_CampaignPlayWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CampaignPlayWindow);
				}
			}
		}

		public CampaignScenarioWindow CampaignScenarioWindow
		{
			get
			{
				m_CampaignScenarioWindow = smethod_0(m_CampaignScenarioWindow);
				return m_CampaignScenarioWindow;
			}
			set
			{
				if (value != m_CampaignScenarioWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CampaignScenarioWindow);
				}
			}
		}

		public CargoOps CargoOps
		{
			get
			{
				m_CargoOps = smethod_0(m_CargoOps);
				return m_CargoOps;
			}
			set
			{
				if (value != m_CargoOps)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CargoOps);
				}
			}
		}

		public CargoOpsContainer CargoOpsContainer
		{
			get
			{
				m_CargoOpsContainer = smethod_0(m_CargoOpsContainer);
				return m_CargoOpsContainer;
			}
			set
			{
				if (value != m_CargoOpsContainer)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CargoOpsContainer);
				}
			}
		}

		public CargoOpsV2 CargoOpsV2
		{
			get
			{
				m_CargoOpsV2 = smethod_0(m_CargoOpsV2);
				return m_CargoOpsV2;
			}
			set
			{
				if (value != m_CargoOpsV2)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CargoOpsV2);
				}
			}
		}

		public ChanceOfAppearance ChanceOfAppearance
		{
			get
			{
				m_ChanceOfAppearance = smethod_0(m_ChanceOfAppearance);
				return m_ChanceOfAppearance;
			}
			set
			{
				if (value != m_ChanceOfAppearance)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ChanceOfAppearance);
				}
			}
		}

		public ChooseSide ChooseSide
		{
			get
			{
				m_ChooseSide = smethod_0(m_ChooseSide);
				return m_ChooseSide;
			}
			set
			{
				if (value != m_ChooseSide)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ChooseSide);
				}
			}
		}

		public CommandDarkFormParent CommandDarkFormParent
		{
			get
			{
				m_CommandDarkFormParent = smethod_0(m_CommandDarkFormParent);
				return m_CommandDarkFormParent;
			}
			set
			{
				if (value != m_CommandDarkFormParent)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CommandDarkFormParent);
				}
			}
		}

		public CommandFormParent CommandFormParent
		{
			get
			{
				m_CommandFormParent = smethod_0(m_CommandFormParent);
				return m_CommandFormParent;
			}
			set
			{
				if (value != m_CommandFormParent)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CommandFormParent);
				}
			}
		}

		public CommandSecondaryFormBase CommandSecondaryFormBase
		{
			get
			{
				m_CommandSecondaryFormBase = smethod_0(m_CommandSecondaryFormBase);
				return m_CommandSecondaryFormBase;
			}
			set
			{
				if (value != m_CommandSecondaryFormBase)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CommandSecondaryFormBase);
				}
			}
		}

		public ConfirmLandingPlanDialog ConfirmLandingPlanDialog
		{
			get
			{
				m_ConfirmLandingPlanDialog = smethod_0(m_ConfirmLandingPlanDialog);
				return m_ConfirmLandingPlanDialog;
			}
			set
			{
				if (value != m_ConfirmLandingPlanDialog)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ConfirmLandingPlanDialog);
				}
			}
		}

		public ConsoleWindow2 ConsoleWindow2
		{
			get
			{
				m_ConsoleWindow2 = smethod_0(m_ConsoleWindow2);
				return m_ConsoleWindow2;
			}
			set
			{
				if (value != m_ConsoleWindow2)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ConsoleWindow2);
				}
			}
		}

		public ContactReport ContactReport
		{
			get
			{
				m_ContactReport = smethod_0(m_ContactReport);
				return m_ContactReport;
			}
			set
			{
				if (value != m_ContactReport)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ContactReport);
				}
			}
		}

		public CopyOverPrompt CopyOverPrompt
		{
			get
			{
				m_CopyOverPrompt = smethod_0(m_CopyOverPrompt);
				return m_CopyOverPrompt;
			}
			set
			{
				if (value != m_CopyOverPrompt)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CopyOverPrompt);
				}
			}
		}

		public CopyOverSimilarityPrompt CopyOverSimilarityPrompt
		{
			get
			{
				m_CopyOverSimilarityPrompt = smethod_0(m_CopyOverSimilarityPrompt);
				return m_CopyOverSimilarityPrompt;
			}
			set
			{
				if (value != m_CopyOverSimilarityPrompt)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CopyOverSimilarityPrompt);
				}
			}
		}

		public CPEBannerForm CPEBannerForm
		{
			get
			{
				m_CPEBannerForm = smethod_0(m_CPEBannerForm);
				return m_CPEBannerForm;
			}
			set
			{
				if (value != m_CPEBannerForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CPEBannerForm);
				}
			}
		}

		public CurrentFlightPlanEditor CurrentFlightPlanEditor
		{
			get
			{
				m_CurrentFlightPlanEditor = smethod_0(m_CurrentFlightPlanEditor);
				return m_CurrentFlightPlanEditor;
			}
			set
			{
				if (value != m_CurrentFlightPlanEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CurrentFlightPlanEditor);
				}
			}
		}

		public CustomLayersForm CustomLayersForm
		{
			get
			{
				m_CustomLayersForm = smethod_0(m_CustomLayersForm);
				return m_CustomLayersForm;
			}
			set
			{
				if (value != m_CustomLayersForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_CustomLayersForm);
				}
			}
		}

		public DamageControlWindow DamageControlWindow
		{
			get
			{
				m_DamageControlWindow = smethod_0(m_DamageControlWindow);
				return m_DamageControlWindow;
			}
			set
			{
				if (value != m_DamageControlWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DamageControlWindow);
				}
			}
		}

		public DarkSecondaryFormBase DarkSecondaryFormBase
		{
			get
			{
				m_DarkSecondaryFormBase = smethod_0(m_DarkSecondaryFormBase);
				return m_DarkSecondaryFormBase;
			}
			set
			{
				if (value != m_DarkSecondaryFormBase)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DarkSecondaryFormBase);
				}
			}
		}

		public DarkUIForm DarkUIForm
		{
			get
			{
				m_DarkUIForm = smethod_0(m_DarkUIForm);
				return m_DarkUIForm;
			}
			set
			{
				if (value != m_DarkUIForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DarkUIForm);
				}
			}
		}

		public DBToolsForm DBToolsForm
		{
			get
			{
				m_DBToolsForm = smethod_0(m_DBToolsForm);
				return m_DBToolsForm;
			}
			set
			{
				if (value != m_DBToolsForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DBToolsForm);
				}
			}
		}

		public DebugForm DebugForm
		{
			get
			{
				m_DebugForm = smethod_0(m_DebugForm);
				return m_DebugForm;
			}
			set
			{
				if (value != m_DebugForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DebugForm);
				}
			}
		}

		public DebugOptions DebugOptions
		{
			get
			{
				m_DebugOptions = smethod_0(m_DebugOptions);
				return m_DebugOptions;
			}
			set
			{
				if (value != m_DebugOptions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DebugOptions);
				}
			}
		}

		public DebugTool DebugTool
		{
			get
			{
				m_DebugTool = smethod_0(m_DebugTool);
				return m_DebugTool;
			}
			set
			{
				if (value != m_DebugTool)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DebugTool);
				}
			}
		}

		public DISAdapterSelectionForm DISAdapterSelectionForm
		{
			get
			{
				m_DISAdapterSelectionForm = smethod_0(m_DISAdapterSelectionForm);
				return m_DISAdapterSelectionForm;
			}
			set
			{
				if (value != m_DISAdapterSelectionForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DISAdapterSelectionForm);
				}
			}
		}

		public DISForm DISForm
		{
			get
			{
				m_DISForm = smethod_0(m_DISForm);
				return m_DISForm;
			}
			set
			{
				if (value != m_DISForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DISForm);
				}
			}
		}

		public DockingOps DockingOps
		{
			get
			{
				m_DockingOps = smethod_0(m_DockingOps);
				return m_DockingOps;
			}
			set
			{
				if (value != m_DockingOps)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DockingOps);
				}
			}
		}

		public DoctrineForm DoctrineForm
		{
			get
			{
				m_DoctrineForm = smethod_0(m_DoctrineForm);
				return m_DoctrineForm;
			}
			set
			{
				if (value != m_DoctrineForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_DoctrineForm);
				}
			}
		}

		public EditAC EditAC
		{
			get
			{
				m_EditAC = smethod_0(m_EditAC);
				return m_EditAC;
			}
			set
			{
				if (value != m_EditAC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditAC);
				}
			}
		}

		public EditAction EditAction
		{
			get
			{
				m_EditAction = smethod_0(m_EditAction);
				return m_EditAction;
			}
			set
			{
				if (value != m_EditAction)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditAction);
				}
			}
		}

		public EditBoats EditBoats
		{
			get
			{
				m_EditBoats = smethod_0(m_EditBoats);
				return m_EditBoats;
			}
			set
			{
				if (value != m_EditBoats)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditBoats);
				}
			}
		}

		public EditBriefing EditBriefing
		{
			get
			{
				m_EditBriefing = smethod_0(m_EditBriefing);
				return m_EditBriefing;
			}
			set
			{
				if (value != m_EditBriefing)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditBriefing);
				}
			}
		}

		public EditCargo EditCargo
		{
			get
			{
				m_EditCargo = smethod_0(m_EditCargo);
				return m_EditCargo;
			}
			set
			{
				if (value != m_EditCargo)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditCargo);
				}
			}
		}

		public EditCargoContainer EditCargoContainer
		{
			get
			{
				m_EditCargoContainer = smethod_0(m_EditCargoContainer);
				return m_EditCargoContainer;
			}
			set
			{
				if (value != m_EditCargoContainer)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditCargoContainer);
				}
			}
		}

		public EditCargoV2 EditCargoV2
		{
			get
			{
				m_EditCargoV2 = smethod_0(m_EditCargoV2);
				return m_EditCargoV2;
			}
			set
			{
				if (value != m_EditCargoV2)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditCargoV2);
				}
			}
		}

		public EditCondition EditCondition
		{
			get
			{
				m_EditCondition = smethod_0(m_EditCondition);
				return m_EditCondition;
			}
			set
			{
				if (value != m_EditCondition)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditCondition);
				}
			}
		}

		public EditCustomEnvironmentArea EditCustomEnvironmentArea
		{
			get
			{
				m_EditCustomEnvironmentArea = smethod_0(m_EditCustomEnvironmentArea);
				return m_EditCustomEnvironmentArea;
			}
			set
			{
				if (value != m_EditCustomEnvironmentArea)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditCustomEnvironmentArea);
				}
			}
		}

		public EditEvent EditEvent
		{
			get
			{
				m_EditEvent = smethod_0(m_EditEvent);
				return m_EditEvent;
			}
			set
			{
				if (value != m_EditEvent)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditEvent);
				}
			}
		}

		public EditSpecialAction EditSpecialAction
		{
			get
			{
				m_EditSpecialAction = smethod_0(m_EditSpecialAction);
				return m_EditSpecialAction;
			}
			set
			{
				if (value != m_EditSpecialAction)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditSpecialAction);
				}
			}
		}

		public EditTrigger EditTrigger
		{
			get
			{
				m_EditTrigger = smethod_0(m_EditTrigger);
				return m_EditTrigger;
			}
			set
			{
				if (value != m_EditTrigger)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditTrigger);
				}
			}
		}

		public EditWeather EditWeather
		{
			get
			{
				m_EditWeather = smethod_0(m_EditWeather);
				return m_EditWeather;
			}
			set
			{
				if (value != m_EditWeather)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EditWeather);
				}
			}
		}

		public EnablersForm EnablersForm
		{
			get
			{
				m_EnablersForm = smethod_0(m_EnablersForm);
				return m_EnablersForm;
			}
			set
			{
				if (value != m_EnablersForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_EnablersForm);
				}
			}
		}

		public ErrorForm ErrorForm
		{
			get
			{
				m_ErrorForm = smethod_0(m_ErrorForm);
				return m_ErrorForm;
			}
			set
			{
				if (value != m_ErrorForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ErrorForm);
				}
			}
		}

		public Evaluation Evaluation
		{
			get
			{
				m_Evaluation = smethod_0(m_Evaluation);
				return m_Evaluation;
			}
			set
			{
				if (value != m_Evaluation)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Evaluation);
				}
			}
		}

		public Export_ImportFeedback Export_ImportFeedback
		{
			get
			{
				m_Export_ImportFeedback = smethod_0(m_Export_ImportFeedback);
				return m_Export_ImportFeedback;
			}
			set
			{
				if (value != m_Export_ImportFeedback)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Export_ImportFeedback);
				}
			}
		}

		public ExportImportTool ExportImportTool
		{
			get
			{
				m_ExportImportTool = smethod_0(m_ExportImportTool);
				return m_ExportImportTool;
			}
			set
			{
				if (value != m_ExportImportTool)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ExportImportTool);
				}
			}
		}

		public FixedFacilityOrientation FixedFacilityOrientation
		{
			get
			{
				m_FixedFacilityOrientation = smethod_0(m_FixedFacilityOrientation);
				return m_FixedFacilityOrientation;
			}
			set
			{
				if (value != m_FixedFacilityOrientation)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FixedFacilityOrientation);
				}
			}
		}

		public FlightPlanAircraftLoadout FlightPlanAircraftLoadout
		{
			get
			{
				m_FlightPlanAircraftLoadout = smethod_0(m_FlightPlanAircraftLoadout);
				return m_FlightPlanAircraftLoadout;
			}
			set
			{
				if (value != m_FlightPlanAircraftLoadout)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanAircraftLoadout);
				}
			}
		}

		public FlightPlanEditor FlightPlanEditor
		{
			get
			{
				m_FlightPlanEditor = smethod_0(m_FlightPlanEditor);
				return m_FlightPlanEditor;
			}
			set
			{
				if (value != m_FlightPlanEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditor);
				}
			}
		}

		public FlightPlanEditorTargets FlightPlanEditorTargets
		{
			get
			{
				m_FlightPlanEditorTargets = smethod_0(m_FlightPlanEditorTargets);
				return m_FlightPlanEditorTargets;
			}
			set
			{
				if (value != m_FlightPlanEditorTargets)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditorTargets);
				}
			}
		}

		public FlightPlanEditorTargetsArea FlightPlanEditorTargetsArea
		{
			get
			{
				m_FlightPlanEditorTargetsArea = smethod_0(m_FlightPlanEditorTargetsArea);
				return m_FlightPlanEditorTargetsArea;
			}
			set
			{
				if (value != m_FlightPlanEditorTargetsArea)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditorTargetsArea);
				}
			}
		}

		public FlightPlanEditorTargetsPreliminary FlightPlanEditorTargetsPreliminary
		{
			get
			{
				m_FlightPlanEditorTargetsPreliminary = smethod_0(m_FlightPlanEditorTargetsPreliminary);
				return m_FlightPlanEditorTargetsPreliminary;
			}
			set
			{
				if (value != m_FlightPlanEditorTargetsPreliminary)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditorTargetsPreliminary);
				}
			}
		}

		public FlightPlanEditorWaypointDetails FlightPlanEditorWaypointDetails
		{
			get
			{
				m_FlightPlanEditorWaypointDetails = smethod_0(m_FlightPlanEditorWaypointDetails);
				return m_FlightPlanEditorWaypointDetails;
			}
			set
			{
				if (value != m_FlightPlanEditorWaypointDetails)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditorWaypointDetails);
				}
			}
		}

		public FlightPlanEditorWeaponRoute FlightPlanEditorWeaponRoute
		{
			get
			{
				m_FlightPlanEditorWeaponRoute = smethod_0(m_FlightPlanEditorWeaponRoute);
				return m_FlightPlanEditorWeaponRoute;
			}
			set
			{
				if (value != m_FlightPlanEditorWeaponRoute)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanEditorWeaponRoute);
				}
			}
		}

		public FlightPlanErrors FlightPlanErrors
		{
			get
			{
				m_FlightPlanErrors = smethod_0(m_FlightPlanErrors);
				return m_FlightPlanErrors;
			}
			set
			{
				if (value != m_FlightPlanErrors)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanErrors);
				}
			}
		}

		public FlightPlanTargets FlightPlanTargets
		{
			get
			{
				m_FlightPlanTargets = smethod_0(m_FlightPlanTargets);
				return m_FlightPlanTargets;
			}
			set
			{
				if (value != m_FlightPlanTargets)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanTargets);
				}
			}
		}

		public FlightPlanTime FlightPlanTime
		{
			get
			{
				m_FlightPlanTime = smethod_0(m_FlightPlanTime);
				return m_FlightPlanTime;
			}
			set
			{
				if (value != m_FlightPlanTime)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FlightPlanTime);
				}
			}
		}

		public FloatingLicenseErrorForm FloatingLicenseErrorForm
		{
			get
			{
				m_FloatingLicenseErrorForm = smethod_0(m_FloatingLicenseErrorForm);
				return m_FloatingLicenseErrorForm;
			}
			set
			{
				if (value != m_FloatingLicenseErrorForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FloatingLicenseErrorForm);
				}
			}
		}

		public Form_QuickTurnaround Form_QuickTurnaround
		{
			get
			{
				m_Form_QuickTurnaround = smethod_0(m_Form_QuickTurnaround);
				return m_Form_QuickTurnaround;
			}
			set
			{
				if (value != m_Form_QuickTurnaround)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Form_QuickTurnaround);
				}
			}
		}

		public Form_SetFuelAndAirborneTime Form_SetFuelAndAirborneTime
		{
			get
			{
				m_Form_SetFuelAndAirborneTime = smethod_0(m_Form_SetFuelAndAirborneTime);
				return m_Form_SetFuelAndAirborneTime;
			}
			set
			{
				if (value != m_Form_SetFuelAndAirborneTime)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Form_SetFuelAndAirborneTime);
				}
			}
		}

		public FormationEditor FormationEditor
		{
			get
			{
				m_FormationEditor = smethod_0(m_FormationEditor);
				return m_FormationEditor;
			}
			set
			{
				if (value != m_FormationEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_FormationEditor);
				}
			}
		}

		public GroupFilterManager GroupFilterManager
		{
			get
			{
				m_GroupFilterManager = smethod_0(m_GroupFilterManager);
				return m_GroupFilterManager;
			}
			set
			{
				if (value != m_GroupFilterManager)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_GroupFilterManager);
				}
			}
		}

		public HashtableNodeEditor HashtableNodeEditor
		{
			get
			{
				m_HashtableNodeEditor = smethod_0(m_HashtableNodeEditor);
				return m_HashtableNodeEditor;
			}
			set
			{
				if (value != m_HashtableNodeEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_HashtableNodeEditor);
				}
			}
		}

		public Hotkeys Hotkeys
		{
			get
			{
				m_Hotkeys = smethod_0(m_Hotkeys);
				return m_Hotkeys;
			}
			set
			{
				if (value != m_Hotkeys)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Hotkeys);
				}
			}
		}

		public IconeCustomizer IconeCustomizer
		{
			get
			{
				m_IconeCustomizer = smethod_0(m_IconeCustomizer);
				return m_IconeCustomizer;
			}
			set
			{
				if (value != m_IconeCustomizer)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_IconeCustomizer);
				}
			}
		}

		public InputDialog InputDialog
		{
			get
			{
				m_InputDialog = smethod_0(m_InputDialog);
				return m_InputDialog;
			}
			set
			{
				if (value != m_InputDialog)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_InputDialog);
				}
			}
		}

		public InsufficientLicenseWindow InsufficientLicenseWindow
		{
			get
			{
				m_InsufficientLicenseWindow = smethod_0(m_InsufficientLicenseWindow);
				return m_InsufficientLicenseWindow;
			}
			set
			{
				if (value != m_InsufficientLicenseWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_InsufficientLicenseWindow);
				}
			}
		}

		public InteractiveAnalysisForm InteractiveAnalysisForm
		{
			get
			{
				m_InteractiveAnalysisForm = smethod_0(m_InteractiveAnalysisForm);
				return m_InteractiveAnalysisForm;
			}
			set
			{
				if (value != m_InteractiveAnalysisForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_InteractiveAnalysisForm);
				}
			}
		}

		public InteractiveManual InteractiveManual
		{
			get
			{
				m_InteractiveManual = smethod_0(m_InteractiveManual);
				return m_InteractiveManual;
			}
			set
			{
				if (value != m_InteractiveManual)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_InteractiveManual);
				}
			}
		}

		public InternalDBViewer InternalDBViewer
		{
			get
			{
				m_InternalDBViewer = smethod_0(m_InternalDBViewer);
				return m_InternalDBViewer;
			}
			set
			{
				if (value != m_InternalDBViewer)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_InternalDBViewer);
				}
			}
		}

		public LandingPlanner LandingPlanner
		{
			get
			{
				m_LandingPlanner = smethod_0(m_LandingPlanner);
				return m_LandingPlanner;
			}
			set
			{
				if (value != m_LandingPlanner)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LandingPlanner);
				}
			}
		}

		public ListActions ListActions
		{
			get
			{
				m_ListActions = smethod_0(m_ListActions);
				return m_ListActions;
			}
			set
			{
				if (value != m_ListActions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ListActions);
				}
			}
		}

		public ListConditions ListConditions
		{
			get
			{
				m_ListConditions = smethod_0(m_ListConditions);
				return m_ListConditions;
			}
			set
			{
				if (value != m_ListConditions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ListConditions);
				}
			}
		}

		public ListEvents ListEvents
		{
			get
			{
				m_ListEvents = smethod_0(m_ListEvents);
				return m_ListEvents;
			}
			set
			{
				if (value != m_ListEvents)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ListEvents);
				}
			}
		}

		public ListSpecialActions ListSpecialActions
		{
			get
			{
				m_ListSpecialActions = smethod_0(m_ListSpecialActions);
				return m_ListSpecialActions;
			}
			set
			{
				if (value != m_ListSpecialActions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ListSpecialActions);
				}
			}
		}

		public ListTriggers ListTriggers
		{
			get
			{
				m_ListTriggers = smethod_0(m_ListTriggers);
				return m_ListTriggers;
			}
			set
			{
				if (value != m_ListTriggers)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ListTriggers);
				}
			}
		}

		public LoadGroup LoadGroup
		{
			get
			{
				m_LoadGroup = smethod_0(m_LoadGroup);
				return m_LoadGroup;
			}
			set
			{
				if (value != m_LoadGroup)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LoadGroup);
				}
			}
		}

		public LoadScenario LoadScenario
		{
			get
			{
				m_LoadScenario = smethod_0(m_LoadScenario);
				return m_LoadScenario;
			}
			set
			{
				if (value != m_LoadScenario)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LoadScenario);
				}
			}
		}

		public Losses Losses
		{
			get
			{
				m_Losses = smethod_0(m_Losses);
				return m_Losses;
			}
			set
			{
				if (value != m_Losses)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Losses);
				}
			}
		}

		public LOSTool LOSTool
		{
			get
			{
				m_LOSTool = smethod_0(m_LOSTool);
				return m_LOSTool;
			}
			set
			{
				if (value != m_LOSTool)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LOSTool);
				}
			}
		}

		public LuaEditorOperationPlanner LuaEditorOperationPlanner
		{
			get
			{
				m_LuaEditorOperationPlanner = smethod_0(m_LuaEditorOperationPlanner);
				return m_LuaEditorOperationPlanner;
			}
			set
			{
				if (value != m_LuaEditorOperationPlanner)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LuaEditorOperationPlanner);
				}
			}
		}

		public LuaSocketClient LuaSocketClient
		{
			get
			{
				m_LuaSocketClient = smethod_0(m_LuaSocketClient);
				return m_LuaSocketClient;
			}
			set
			{
				if (value != m_LuaSocketClient)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_LuaSocketClient);
				}
			}
		}

		public Magazines Magazines
		{
			get
			{
				m_Magazines = smethod_0(m_Magazines);
				return m_Magazines;
			}
			set
			{
				if (value != m_Magazines)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Magazines);
				}
			}
		}

		public MainForm MainForm
		{
			get
			{
				m_MainForm = smethod_0(m_MainForm);
				return m_MainForm;
			}
			set
			{
				if (value != m_MainForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MainForm);
				}
			}
		}

		public MainSplash MainSplash
		{
			get
			{
				m_MainSplash = smethod_0(m_MainSplash);
				return m_MainSplash;
			}
			set
			{
				if (value != m_MainSplash)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MainSplash);
				}
			}
		}

		public MapSettings MapSettings
		{
			get
			{
				m_MapSettings = smethod_0(m_MapSettings);
				return m_MapSettings;
			}
			set
			{
				if (value != m_MapSettings)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MapSettings);
				}
			}
		}

		public MCMWindow MCMWindow
		{
			get
			{
				m_MCMWindow = smethod_0(m_MCMWindow);
				return m_MCMWindow;
			}
			set
			{
				if (value != m_MCMWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MCMWindow);
				}
			}
		}

		public MessageLogWindow_RawText MessageLogWindow_RawText
		{
			get
			{
				m_MessageLogWindow_RawText = smethod_0(m_MessageLogWindow_RawText);
				return m_MessageLogWindow_RawText;
			}
			set
			{
				if (value != m_MessageLogWindow_RawText)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MessageLogWindow_RawText);
				}
			}
		}

		public Migration Migration
		{
			get
			{
				m_Migration = smethod_0(m_Migration);
				return m_Migration;
			}
			set
			{
				if (value != m_Migration)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Migration);
				}
			}
		}

		public MinefieldForm MinefieldForm
		{
			get
			{
				m_MinefieldForm = smethod_0(m_MinefieldForm);
				return m_MinefieldForm;
			}
			set
			{
				if (value != m_MinefieldForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MinefieldForm);
				}
			}
		}

		public MissionActivationTime MissionActivationTime
		{
			get
			{
				m_MissionActivationTime = smethod_0(m_MissionActivationTime);
				return m_MissionActivationTime;
			}
			set
			{
				if (value != m_MissionActivationTime)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MissionActivationTime);
				}
			}
		}

		public MissionEditor MissionEditor
		{
			get
			{
				m_MissionEditor = smethod_0(m_MissionEditor);
				return m_MissionEditor;
			}
			set
			{
				if (value != m_MissionEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MissionEditor);
				}
			}
		}

		public MultipleUnitSensors MultipleUnitSensors
		{
			get
			{
				m_MultipleUnitSensors = smethod_0(m_MultipleUnitSensors);
				return m_MultipleUnitSensors;
			}
			set
			{
				if (value != m_MultipleUnitSensors)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_MultipleUnitSensors);
				}
			}
		}

		public NavalFormationEditor NavalFormationEditor
		{
			get
			{
				m_NavalFormationEditor = smethod_0(m_NavalFormationEditor);
				return m_NavalFormationEditor;
			}
			set
			{
				if (value != m_NavalFormationEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_NavalFormationEditor);
				}
			}
		}

		public NewMessageForm NewMessageForm
		{
			get
			{
				m_NewMessageForm = smethod_0(m_NewMessageForm);
				return m_NewMessageForm;
			}
			set
			{
				if (value != m_NewMessageForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_NewMessageForm);
				}
			}
		}

		public NewMission NewMission
		{
			get
			{
				m_NewMission = smethod_0(m_NewMission);
				return m_NewMission;
			}
			set
			{
				if (value != m_NewMission)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_NewMission);
				}
			}
		}

		public NotifyConnecting NotifyConnecting
		{
			get
			{
				m_NotifyConnecting = smethod_0(m_NotifyConnecting);
				return m_NotifyConnecting;
			}
			set
			{
				if (value != m_NotifyConnecting)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_NotifyConnecting);
				}
			}
		}

		public OperationPlanner OperationPlanner
		{
			get
			{
				m_OperationPlanner = smethod_0(m_OperationPlanner);
				return m_OperationPlanner;
			}
			set
			{
				if (value != m_OperationPlanner)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_OperationPlanner);
				}
			}
		}

		public Options Options
		{
			get
			{
				m_Options = smethod_0(m_Options);
				return m_Options;
			}
			set
			{
				if (value != m_Options)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Options);
				}
			}
		}

		public ORBAT ORBAT
		{
			get
			{
				m_ORBAT = smethod_0(m_ORBAT);
				return m_ORBAT;
			}
			set
			{
				if (value != m_ORBAT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ORBAT);
				}
			}
		}

		public PE_LicenseRevoke PE_LicenseRevoke
		{
			get
			{
				m_PE_LicenseRevoke = smethod_0(m_PE_LicenseRevoke);
				return m_PE_LicenseRevoke;
			}
			set
			{
				if (value != m_PE_LicenseRevoke)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_PE_LicenseRevoke);
				}
			}
		}

		public PE_LicensingForm PE_LicensingForm
		{
			get
			{
				m_PE_LicensingForm = smethod_0(m_PE_LicensingForm);
				return m_PE_LicensingForm;
			}
			set
			{
				if (value != m_PE_LicensingForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_PE_LicensingForm);
				}
			}
		}

		public Postures Postures
		{
			get
			{
				m_Postures = smethod_0(m_Postures);
				return m_Postures;
			}
			set
			{
				if (value != m_Postures)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Postures);
				}
			}
		}

		public PriorityTargetForm PriorityTargetForm
		{
			get
			{
				m_PriorityTargetForm = smethod_0(m_PriorityTargetForm);
				return m_PriorityTargetForm;
			}
			set
			{
				if (value != m_PriorityTargetForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_PriorityTargetForm);
				}
			}
		}

		public QuickBattle QuickBattle
		{
			get
			{
				m_QuickBattle = smethod_0(m_QuickBattle);
				return m_QuickBattle;
			}
			set
			{
				if (value != m_QuickBattle)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_QuickBattle);
				}
			}
		}

		public ReadyAircraft ReadyAircraft
		{
			get
			{
				m_ReadyAircraft = smethod_0(m_ReadyAircraft);
				return m_ReadyAircraft;
			}
			set
			{
				if (value != m_ReadyAircraft)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ReadyAircraft);
				}
			}
		}

		public RealtimeChatInputBar RealtimeChatInputBar
		{
			get
			{
				m_RealtimeChatInputBar = smethod_0(m_RealtimeChatInputBar);
				return m_RealtimeChatInputBar;
			}
			set
			{
				if (value != m_RealtimeChatInputBar)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimeChatInputBar);
				}
			}
		}

		public RealtimeLobby RealtimeLobby
		{
			get
			{
				m_RealtimeLobby = smethod_0(m_RealtimeLobby);
				return m_RealtimeLobby;
			}
			set
			{
				if (value != m_RealtimeLobby)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimeLobby);
				}
			}
		}

		public RealtimeLobbyLogin RealtimeLobbyLogin
		{
			get
			{
				m_RealtimeLobbyLogin = smethod_0(m_RealtimeLobbyLogin);
				return m_RealtimeLobbyLogin;
			}
			set
			{
				if (value != m_RealtimeLobbyLogin)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimeLobbyLogin);
				}
			}
		}

		public RealtimeLobbyLoginWait RealtimeLobbyLoginWait
		{
			get
			{
				m_RealtimeLobbyLoginWait = smethod_0(m_RealtimeLobbyLoginWait);
				return m_RealtimeLobbyLoginWait;
			}
			set
			{
				if (value != m_RealtimeLobbyLoginWait)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimeLobbyLoginWait);
				}
			}
		}

		public RealtimePlayerConnect RealtimePlayerConnect
		{
			get
			{
				m_RealtimePlayerConnect = smethod_0(m_RealtimePlayerConnect);
				return m_RealtimePlayerConnect;
			}
			set
			{
				if (value != m_RealtimePlayerConnect)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimePlayerConnect);
				}
			}
		}

		public RealtimePlayerLogin RealtimePlayerLogin
		{
			get
			{
				m_RealtimePlayerLogin = smethod_0(m_RealtimePlayerLogin);
				return m_RealtimePlayerLogin;
			}
			set
			{
				if (value != m_RealtimePlayerLogin)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RealtimePlayerLogin);
				}
			}
		}

		public RecorderForm RecorderForm
		{
			get
			{
				m_RecorderForm = smethod_0(m_RecorderForm);
				return m_RecorderForm;
			}
			set
			{
				if (value != m_RecorderForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RecorderForm);
				}
			}
		}

		public ReferencePointManager ReferencePointManager
		{
			get
			{
				m_ReferencePointManager = smethod_0(m_ReferencePointManager);
				return m_ReferencePointManager;
			}
			set
			{
				if (value != m_ReferencePointManager)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ReferencePointManager);
				}
			}
		}

		public RenameObject RenameObject
		{
			get
			{
				m_RenameObject = smethod_0(m_RenameObject);
				return m_RenameObject;
			}
			set
			{
				if (value != m_RenameObject)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RenameObject);
				}
			}
		}

		public RenameSide RenameSide
		{
			get
			{
				m_RenameSide = smethod_0(m_RenameSide);
				return m_RenameSide;
			}
			set
			{
				if (value != m_RenameSide)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RenameSide);
				}
			}
		}

		public ResumeFromSave ResumeFromSave
		{
			get
			{
				m_ResumeFromSave = smethod_0(m_ResumeFromSave);
				return m_ResumeFromSave;
			}
			set
			{
				if (value != m_ResumeFromSave)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ResumeFromSave);
				}
			}
		}

		public RoadSystem_Toolbox RoadSystem_Toolbox
		{
			get
			{
				m_RoadSystem_Toolbox = smethod_0(m_RoadSystem_Toolbox);
				return m_RoadSystem_Toolbox;
			}
			set
			{
				if (value != m_RoadSystem_Toolbox)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_RoadSystem_Toolbox);
				}
			}
		}

		public SatelliteCustomOrbit SatelliteCustomOrbit
		{
			get
			{
				m_SatelliteCustomOrbit = smethod_0(m_SatelliteCustomOrbit);
				return m_SatelliteCustomOrbit;
			}
			set
			{
				if (value != m_SatelliteCustomOrbit)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SatelliteCustomOrbit);
				}
			}
		}

		public SatPredictionForm SatPredictionForm
		{
			get
			{
				m_SatPredictionForm = smethod_0(m_SatPredictionForm);
				return m_SatPredictionForm;
			}
			set
			{
				if (value != m_SatPredictionForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SatPredictionForm);
				}
			}
		}

		public SaveGroup SaveGroup
		{
			get
			{
				m_SaveGroup = smethod_0(m_SaveGroup);
				return m_SaveGroup;
			}
			set
			{
				if (value != m_SaveGroup)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SaveGroup);
				}
			}
		}

		public ScenarioMerge ScenarioMerge
		{
			get
			{
				m_ScenarioMerge = smethod_0(m_ScenarioMerge);
				return m_ScenarioMerge;
			}
			set
			{
				if (value != m_ScenarioMerge)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ScenarioMerge);
				}
			}
		}

		public ScenarioTitle ScenarioTitle
		{
			get
			{
				m_ScenarioTitle = smethod_0(m_ScenarioTitle);
				return m_ScenarioTitle;
			}
			set
			{
				if (value != m_ScenarioTitle)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ScenarioTitle);
				}
			}
		}

		public ScenAttachmentsWindow ScenAttachmentsWindow
		{
			get
			{
				m_ScenAttachmentsWindow = smethod_0(m_ScenAttachmentsWindow);
				return m_ScenAttachmentsWindow;
			}
			set
			{
				if (value != m_ScenAttachmentsWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ScenAttachmentsWindow);
				}
			}
		}

		public ScoringWindow ScoringWindow
		{
			get
			{
				m_ScoringWindow = smethod_0(m_ScoringWindow);
				return m_ScoringWindow;
			}
			set
			{
				if (value != m_ScoringWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_ScoringWindow);
				}
			}
		}

		public SelectLoadout SelectLoadout
		{
			get
			{
				m_SelectLoadout = smethod_0(m_SelectLoadout);
				return m_SelectLoadout;
			}
			set
			{
				if (value != m_SelectLoadout)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SelectLoadout);
				}
			}
		}

		public SelectSAO SelectSAO
		{
			get
			{
				m_SelectSAO = smethod_0(m_SelectSAO);
				return m_SelectSAO;
			}
			set
			{
				if (value != m_SelectSAO)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SelectSAO);
				}
			}
		}

		public Sides Sides
		{
			get
			{
				m_Sides = smethod_0(m_Sides);
				return m_Sides;
			}
			set
			{
				if (value != m_Sides)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_Sides);
				}
			}
		}

		public SpecialActionsForm SpecialActionsForm
		{
			get
			{
				m_SpecialActionsForm = smethod_0(m_SpecialActionsForm);
				return m_SpecialActionsForm;
			}
			set
			{
				if (value != m_SpecialActionsForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SpecialActionsForm);
				}
			}
		}

		public SpeedAlt SpeedAlt
		{
			get
			{
				m_SpeedAlt = smethod_0(m_SpeedAlt);
				return m_SpeedAlt;
			}
			set
			{
				if (value != m_SpeedAlt)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SpeedAlt);
				}
			}
		}

		public SplitUnit SplitUnit
		{
			get
			{
				m_SplitUnit = smethod_0(m_SplitUnit);
				return m_SplitUnit;
			}
			set
			{
				if (value != m_SplitUnit)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SplitUnit);
				}
			}
		}

		public StartGame StartGame
		{
			get
			{
				m_StartGame = smethod_0(m_StartGame);
				return m_StartGame;
			}
			set
			{
				if (value != m_StartGame)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_StartGame);
				}
			}
		}

		public SteamPublishScenarioForm SteamPublishScenarioForm
		{
			get
			{
				m_SteamPublishScenarioForm = smethod_0(m_SteamPublishScenarioForm);
				return m_SteamPublishScenarioForm;
			}
			set
			{
				if (value != m_SteamPublishScenarioForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SteamPublishScenarioForm);
				}
			}
		}

		public SteamUpdateScenarioForm SteamUpdateScenarioForm
		{
			get
			{
				m_SteamUpdateScenarioForm = smethod_0(m_SteamUpdateScenarioForm);
				return m_SteamUpdateScenarioForm;
			}
			set
			{
				if (value != m_SteamUpdateScenarioForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_SteamUpdateScenarioForm);
				}
			}
		}

		public TankerPlanner TankerPlanner
		{
			get
			{
				m_TankerPlanner = smethod_0(m_TankerPlanner);
				return m_TankerPlanner;
			}
			set
			{
				if (value != m_TankerPlanner)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_TankerPlanner);
				}
			}
		}

		public TimesAndDuration TimesAndDuration
		{
			get
			{
				m_TimesAndDuration = smethod_0(m_TimesAndDuration);
				return m_TimesAndDuration;
			}
			set
			{
				if (value != m_TimesAndDuration)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_TimesAndDuration);
				}
			}
		}

		public TimeToReadyWindow TimeToReadyWindow
		{
			get
			{
				m_TimeToReadyWindow = smethod_0(m_TimeToReadyWindow);
				return m_TimeToReadyWindow;
			}
			set
			{
				if (value != m_TimeToReadyWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_TimeToReadyWindow);
				}
			}
		}

		public TimeUnderway TimeUnderway
		{
			get
			{
				m_TimeUnderway = smethod_0(m_TimeUnderway);
				return m_TimeUnderway;
			}
			set
			{
				if (value != m_TimeUnderway)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_TimeUnderway);
				}
			}
		}

		public TitleAndDescription TitleAndDescription
		{
			get
			{
				m_TitleAndDescription = smethod_0(m_TitleAndDescription);
				return m_TitleAndDescription;
			}
			set
			{
				if (value != m_TitleAndDescription)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_TitleAndDescription);
				}
			}
		}

		public UnitComms UnitComms
		{
			get
			{
				m_UnitComms = smethod_0(m_UnitComms);
				return m_UnitComms;
			}
			set
			{
				if (value != m_UnitComms)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitComms);
				}
			}
		}

		public UnitDecisionChecklistWindow UnitDecisionChecklistWindow
		{
			get
			{
				m_UnitDecisionChecklistWindow = smethod_0(m_UnitDecisionChecklistWindow);
				return m_UnitDecisionChecklistWindow;
			}
			set
			{
				if (value != m_UnitDecisionChecklistWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitDecisionChecklistWindow);
				}
			}
		}

		public UnitMessageLog UnitMessageLog
		{
			get
			{
				m_UnitMessageLog = smethod_0(m_UnitMessageLog);
				return m_UnitMessageLog;
			}
			set
			{
				if (value != m_UnitMessageLog)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitMessageLog);
				}
			}
		}

		public UnitSelection UnitSelection
		{
			get
			{
				m_UnitSelection = smethod_0(m_UnitSelection);
				return m_UnitSelection;
			}
			set
			{
				if (value != m_UnitSelection)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitSelection);
				}
			}
		}

		public UnitSensors UnitSensors
		{
			get
			{
				m_UnitSensors = smethod_0(m_UnitSensors);
				return m_UnitSensors;
			}
			set
			{
				if (value != m_UnitSensors)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitSensors);
				}
			}
		}

		public UnitSerialEditor UnitSerialEditor
		{
			get
			{
				m_UnitSerialEditor = smethod_0(m_UnitSerialEditor);
				return m_UnitSerialEditor;
			}
			set
			{
				if (value != m_UnitSerialEditor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_UnitSerialEditor);
				}
			}
		}

		public VerticalProfilerRenderer VerticalProfilerRenderer
		{
			get
			{
				m_VerticalProfilerRenderer = smethod_0(m_VerticalProfilerRenderer);
				return m_VerticalProfilerRenderer;
			}
			set
			{
				if (value != m_VerticalProfilerRenderer)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_VerticalProfilerRenderer);
				}
			}
		}

		public WeaponsWindow WeaponsWindow
		{
			get
			{
				m_WeaponsWindow = smethod_0(m_WeaponsWindow);
				return m_WeaponsWindow;
			}
			set
			{
				if (value != m_WeaponsWindow)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_WeaponsWindow);
				}
			}
		}

		public MultiplayerForm WEGOMultiplayerForm
		{
			get
			{
				m_WEGOMultiplayerForm = smethod_0(m_WEGOMultiplayerForm);
				return m_WEGOMultiplayerForm;
			}
			set
			{
				if (value != m_WEGOMultiplayerForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_WEGOMultiplayerForm);
				}
			}
		}

		public WEGOMultiplayerTimings WEGOMultiplayerTimings
		{
			get
			{
				m_WEGOMultiplayerTimings = smethod_0(m_WEGOMultiplayerTimings);
				return m_WEGOMultiplayerTimings;
			}
			set
			{
				if (value != m_WEGOMultiplayerTimings)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref m_WEGOMultiplayerTimings);
				}
			}
		}

		private static T smethod_0<T>(T gparam_0) where T : Form, new()
		{
			if (gparam_0 != null && !((Control)gparam_0).IsDisposed)
			{
				return gparam_0;
			}
			if (hashtable_0 != null)
			{
				if (hashtable_0.ContainsKey(typeof(T)))
				{
					throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
				}
			}
			else
			{
				hashtable_0 = new System.Collections.Hashtable();
			}
			hashtable_0.Add(typeof(T), null);
			try
			{
				return new T();
			}
			catch (TargetInvocationException ex) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				ProjectData.SetProjectError((Exception)ex);
				return ex.InnerException != null;
			}).Invoke())
			{
				throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[1] { ex.InnerException.Message }), ex.InnerException);
			}
			finally
			{
				hashtable_0.Remove(typeof(T));
			}
		}

		private void method_0<T>(ref T gparam_0) where T : Form
		{
			((Component)gparam_0/*cast due to .constrained prefix*/).Dispose();
			gparam_0 = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyForms()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		static MyForms()
		{
			Class72.smethod_20();
		}
	}

	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		private static T smethod_0<T>(T gparam_0) where T : new()
		{
			if (gparam_0 == null)
			{
				return new T();
			}
			return gparam_0;
		}

		private void method_0<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyWebServices()
		{
		}

		static MyWebServices()
		{
			Class72.smethod_20();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		[CompilerGenerated]
		[ThreadStatic]
		private static T gparam_0;

		private static object object_0;

		internal T GetInstance
		{
			get
			{
				if (gparam_0 == null)
				{
					gparam_0 = new T();
				}
				return gparam_0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
		}

		static ThreadSafeObjectProvider()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> threadSafeObjectProvider_0;

	private static readonly ThreadSafeObjectProvider<MyApplication> threadSafeObjectProvider_1;

	private static readonly ThreadSafeObjectProvider<User> threadSafeObjectProvider_2;

	private static ThreadSafeObjectProvider<MyForms> threadSafeObjectProvider_3;

	private static readonly ThreadSafeObjectProvider<MyWebServices> threadSafeObjectProvider_4;

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer => threadSafeObjectProvider_0.GetInstance;

	[HelpKeyword("My.Application")]
	internal static MyApplication Application => threadSafeObjectProvider_1.GetInstance;

	[HelpKeyword("My.User")]
	internal static User User => threadSafeObjectProvider_2.GetInstance;

	[HelpKeyword("My.Forms")]
	internal static MyForms Forms => threadSafeObjectProvider_3.GetInstance;

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices => threadSafeObjectProvider_4.GetInstance;

	static MyProject()
	{
		Class72.smethod_20();
		threadSafeObjectProvider_0 = new ThreadSafeObjectProvider<MyComputer>();
		threadSafeObjectProvider_1 = new ThreadSafeObjectProvider<MyApplication>();
		threadSafeObjectProvider_2 = new ThreadSafeObjectProvider<User>();
		threadSafeObjectProvider_3 = new ThreadSafeObjectProvider<MyForms>();
		threadSafeObjectProvider_4 = new ThreadSafeObjectProvider<MyWebServices>();
	}
}
