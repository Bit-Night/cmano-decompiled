using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using CoordinateSharp;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Game
{
	public delegate void GameModeChangedEventHandler();

	public delegate void CurrentGameStatusChangedEventHandler();

	public delegate void GameStatusChangeRequestIssuedEventHandler(_GameStatus DesiredStatus);

	public enum _GameMode : byte
	{
		SinglePlayer,
		MultiPlayer,
		ScenEdit,
		MultiplayerScenEdit,
		MonteCarlo
	}

	public enum _MultiplayerGameMode : byte
	{
		None,
		WEGO,
		Realtime,
		RealtimeAC
	}

	public enum _GameStatus : byte
	{
		Paused,
		Running
	}

	public class GamePreferences
	{
		public enum SonobuoyVisibilitySetting : byte
		{
			Normal,
			Ghosted,
			DontShow
		}

		public enum SpeedUnitSetting : byte
		{
			Knots,
			KPH,
			MPH
		}

		public enum DPIScalingMethodSetting : byte
		{
			WindowsInternal,
			Font
		}

		public enum RefPointVisibilitySetting : byte
		{
			Normal,
			Small,
			DontShow
		}

		public enum MapCursorBoxVisibilitySetting : byte
		{
			AtCursor,
			Bottom,
			DontShow
		}

		public enum MapSymbolsSetting : byte
		{
			NTDS,
			Stylized,
			Directional,
			APP6
		}

		public enum GhostedGroupMembersVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum PlottedPathsVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum FlightPlansVisibilitySetting_Airborne : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum WakeCavitationVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum ContrailsVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum FlightPlansVisibilitySetting_Planned : byte
		{
			All,
			SelectedTaskPool,
			SelectedPackage,
			SelectedFlight,
			DontShow
		}

		public enum ObjectVisibilitySetting : short
		{
			All,
			Selected,
			DontShow
		}

		public enum Unit_Behaviour_Bark : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		internal class AltitudeAnd3DRenderPreferences
		{
			private bool bool_0;

			private bool uoByphlMiou;

			private ushort ushort_0;

			private bool bool_1;

			private bool bool_2;

			private bool bool_3;

			private AltitudeAnd3DRenderPreferences rwfypVxtkRl;

			private AltitudeAnd3DRenderPreferences altitudeAnd3DRenderPreferences_0;

			private bool bool_4;

			public bool UnitsAtAltitude
			{
				get
				{
					return bool_0;
				}
				set
				{
					bool_0 = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public bool Show3DTerrain
			{
				get
				{
					return uoByphlMiou;
				}
				set
				{
					uoByphlMiou = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public ushort VerticalScaling
			{
				get
				{
					return ushort_0;
				}
				set
				{
					ushort_0 = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public bool ShowSubsurfaceUnitsAtSurface
			{
				get
				{
					return bool_1;
				}
				set
				{
					bool_1 = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public bool ShowGroundUnitsAtSurface
			{
				get
				{
					return bool_2;
				}
				set
				{
					bool_2 = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public bool UseGroundInsteadOfSurfaceAsRenderReference
			{
				get
				{
					return bool_3;
				}
				set
				{
					bool_3 = value;
					if (!bool_4)
					{
						method_0();
					}
				}
			}

			public AltitudeAnd3DRenderPreferences Unrectified_ForOptionsUIAndIni => rwfypVxtkRl;

			public AltitudeAnd3DRenderPreferences()
			{
				bool_4 = true;
				rwfypVxtkRl = new AltitudeAnd3DRenderPreferences(this);
			}

			private AltitudeAnd3DRenderPreferences(AltitudeAnd3DRenderPreferences rectifiedReference)
			{
				bool_4 = false;
				altitudeAnd3DRenderPreferences_0 = rectifiedReference;
			}

			private void method_0()
			{
				if (altitudeAnd3DRenderPreferences_0 != null)
				{
					method_1(altitudeAnd3DRenderPreferences_0);
				}
			}

			private void method_1(AltitudeAnd3DRenderPreferences altitudeAnd3DRenderPreferences_1)
			{
				altitudeAnd3DRenderPreferences_1.UnitsAtAltitude = UnitsAtAltitude;
				altitudeAnd3DRenderPreferences_1.Show3DTerrain = altitudeAnd3DRenderPreferences_1.UnitsAtAltitude && Show3DTerrain;
				altitudeAnd3DRenderPreferences_1.VerticalScaling = (ushort)((!altitudeAnd3DRenderPreferences_1.Show3DTerrain) ? 1 : ((ushort)Math.Max(1, (int)VerticalScaling)));
				altitudeAnd3DRenderPreferences_1.ShowSubsurfaceUnitsAtSurface = ShowSubsurfaceUnitsAtSurface && !altitudeAnd3DRenderPreferences_1.Show3DTerrain;
				altitudeAnd3DRenderPreferences_1.ShowGroundUnitsAtSurface = ShowGroundUnitsAtSurface && !altitudeAnd3DRenderPreferences_1.Show3DTerrain;
				altitudeAnd3DRenderPreferences_1.UseGroundInsteadOfSurfaceAsRenderReference = UseGroundInsteadOfSurfaceAsRenderReference && !altitudeAnd3DRenderPreferences_1.Show3DTerrain;
			}

			static AltitudeAnd3DRenderPreferences()
			{
				Class72.smethod_20();
			}
		}

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private int int_0;

		private bool dmyyjdOndDE;

		private int int_1;

		private bool bool_5;

		private bool bool_6;

		private bool bool_7;

		private SonobuoyVisibilitySetting sonobuoyVisibilitySetting_0;

		private RefPointVisibilitySetting refPointVisibilitySetting_0;

		private MapSymbolsSetting mapSymbolsSetting_0;

		private MapCursorBoxVisibilitySetting mapCursorBoxVisibilitySetting_0;

		private SpeedUnitSetting speedUnitSetting_0;

		private Parse_Format_Type parse_Format_Type_0;

		private bool bool_8;

		private GhostedGroupMembersVisibilitySetting ghostedGroupMembersVisibilitySetting_0;

		private PlottedPathsVisibilitySetting plottedPathsVisibilitySetting_0;

		private FlightPlansVisibilitySetting_Airborne flightPlansVisibilitySetting_Airborne_0;

		private WakeCavitationVisibilitySetting wakeCavitationVisibilitySetting_0;

		private ContrailsVisibilitySetting contrailsVisibilitySetting_0;

		private string string_0;

		private string string_1;

		private string string_2;

		private FlightPlansVisibilitySetting_Planned flightPlansVisibilitySetting_Planned_0;

		private float float_0;

		private bool bool_9;

		private float float_1;

		private ObjectVisibilitySetting objectVisibilitySetting_0;

		private bool bool_10;

		private bool xrNyjWxqSfu;

		private bool bool_11;

		private bool bool_12;

		private bool bool_13;

		private bool bool_14;

		private int int_2;

		private bool bool_15;

		private bool bool_16;

		private bool bool_17;

		internal AltitudeAnd3DRenderPreferences AltitudeRender;

		private bool bool_18;

		private bool bool_19;

		private bool bool_20;

		private string string_3;

		private bool bool_21;

		private bool bool_22;

		public Dictionary<LoggedMessage.MessageType, LoggedMessage.MessageSettings> MessageLogSettings;

		public bool UsePersonalMapProfile;

		private MapProfile mapProfile_0;

		private SimConfiguration.WindowPauseBehaviour windowPauseBehaviour_0;

		private SimConfiguration.WindowPauseBehaviour windowPauseBehaviour_1;

		private bool bool_23;

		private SlugTrailTimeFrequency slugTrailTimeFrequency_0;

		private bool bool_24;

		private bool bool_25;

		private bool bool_26;

		private bool bool_27;

		private bool bool_28;

		private bool bool_29;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private bool? DquymeWoeHm;

		private bool bool_30;

		private Unit_Behaviour_Bark unit_Behaviour_Bark_0;

		private bool bool_31;

		private bool bool_32;

		[CompilerGenerated]
		private bool CcbymjFafGV;

		[Description("If True, the program will automatically save the current scenario to the file 'Autosave.scen', every 30 seconds.")]
		[DisplayName("Use Autosave")]
		public bool UseAutosave
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		[Description("If True, the core engine will execute multithreaded")]
		[DisplayName("Run core engine multithreaded")]
		public bool RunCoreMultithreaded
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		[Description("Show Diangostics information (number of active units, pulse execution time etc.")]
		[DisplayName("Show Diagnostic Information")]
		public bool ShowDiagnostics
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		public bool MessageLogInWindow
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		public bool GameSounds
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		public int SFXVolume
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public bool GameMusic
		{
			get
			{
				return dmyyjdOndDE;
			}
			set
			{
				dmyyjdOndDE = value;
			}
		}

		public int MusicVolume
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public bool ShowUSUnitsForEditCargo
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		public bool ShowAltitudeInFeet
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		public bool ZoomOnCursor
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		public SonobuoyVisibilitySetting SonobuoyVisibility
		{
			get
			{
				return sonobuoyVisibilitySetting_0;
			}
			set
			{
				sonobuoyVisibilitySetting_0 = value;
			}
		}

		public RefPointVisibilitySetting RefPointVisibility
		{
			get
			{
				return refPointVisibilitySetting_0;
			}
			set
			{
				refPointVisibilitySetting_0 = value;
			}
		}

		public MapSymbolsSetting MapSymbolsSet
		{
			get
			{
				return mapSymbolsSetting_0;
			}
			set
			{
				mapSymbolsSetting_0 = value;
			}
		}

		public SpeedUnitSetting GroundUnitsSpeedUnit
		{
			get
			{
				return speedUnitSetting_0;
			}
			set
			{
				speedUnitSetting_0 = value;
			}
		}

		public Parse_Format_Type GeoCoordinateType
		{
			get
			{
				return parse_Format_Type_0;
			}
			set
			{
				parse_Format_Type_0 = value;
			}
		}

		public MapCursorBoxVisibilitySetting MapCursorBox
		{
			get
			{
				return mapCursorBoxVisibilitySetting_0;
			}
			set
			{
				mapCursorBoxVisibilitySetting_0 = value;
			}
		}

		public bool OnlyShowAvailableLoadouts
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		public GhostedGroupMembersVisibilitySetting ShowGhostedGroupMembers
		{
			get
			{
				return ghostedGroupMembersVisibilitySetting_0;
			}
			set
			{
				ghostedGroupMembersVisibilitySetting_0 = value;
			}
		}

		public ObjectVisibilitySetting ShowMissionArea
		{
			get
			{
				return objectVisibilitySetting_0;
			}
			set
			{
				objectVisibilitySetting_0 = value;
			}
		}

		public PlottedPathsVisibilitySetting ShowPlottedPaths
		{
			get
			{
				return plottedPathsVisibilitySetting_0;
			}
			set
			{
				plottedPathsVisibilitySetting_0 = value;
			}
		}

		public FlightPlansVisibilitySetting_Airborne ShowFlightPlans_Airborne
		{
			get
			{
				return flightPlansVisibilitySetting_Airborne_0;
			}
			set
			{
				flightPlansVisibilitySetting_Airborne_0 = value;
			}
		}

		public WakeCavitationVisibilitySetting ShowWakeCavitation
		{
			get
			{
				return wakeCavitationVisibilitySetting_0;
			}
			set
			{
				wakeCavitationVisibilitySetting_0 = value;
			}
		}

		public ContrailsVisibilitySetting ShowContrails
		{
			get
			{
				return contrailsVisibilitySetting_0;
			}
			set
			{
				contrailsVisibilitySetting_0 = value;
			}
		}

		public FlightPlansVisibilitySetting_Planned ShowFlightPlans_Planned
		{
			get
			{
				return flightPlansVisibilitySetting_Planned_0;
			}
			set
			{
				flightPlansVisibilitySetting_Planned_0 = value;
			}
		}

		public Unit_Behaviour_Bark ShowAU_Behaviour_Bark
		{
			get
			{
				return unit_Behaviour_Bark_0;
			}
			set
			{
				unit_Behaviour_Bark_0 = value;
			}
		}

		public float NavigationMaxDistanceNMSetting
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		public bool RMB_MoveOrder_Enabled
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		public float NavigationThresholdDistanceDegSetting
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		public bool UnitStatusImage
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		public bool SalvoTimeout
		{
			get
			{
				return xrNyjWxqSfu;
			}
			set
			{
				xrNyjWxqSfu = value;
			}
		}

		public bool ShowAutomaticFireInfo
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		public bool ShowGameSpeedButton
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		public bool LogDebugInfoToFile
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		public bool DetectStuckUnitPulses
		{
			get
			{
				return bool_14;
			}
			set
			{
				bool_14 = value;
			}
		}

		public int StuckUnitPulseThresholdMilliseconds
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		public bool PauseOnDetectedStuckUnitPulse
		{
			get
			{
				return bool_15;
			}
			set
			{
				bool_15 = value;
			}
		}

		public bool SaveScenarioCopyOnDetectedStuckUnitPulse
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		public bool DrawOutlines
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		public bool MessageLogCanvas
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		public bool AllowPowerPlanSwitch
		{
			get
			{
				return bool_19;
			}
			set
			{
				bool_19 = value;
			}
		}

		public bool AggressiveTileManagement
		{
			get
			{
				return bool_20;
			}
			set
			{
				bool_20 = value;
			}
		}

		public bool StartFullScreen
		{
			get
			{
				return bool_21;
			}
			set
			{
				bool_21 = value;
			}
		}

		public string TacviewExePath
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		public string WebviewPathCustomRoot
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		public string CustomFolder_WebviewCache
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		public bool ColorDataBlocks
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		public SimConfiguration.WindowPauseBehaviour PauseOnDBView
		{
			get
			{
				return windowPauseBehaviour_0;
			}
			set
			{
				windowPauseBehaviour_0 = value;
			}
		}

		public SimConfiguration.WindowPauseBehaviour PauseOnAirDockOps
		{
			get
			{
				return windowPauseBehaviour_1;
			}
			set
			{
				windowPauseBehaviour_1 = value;
			}
		}

		public SlugTrailTimeFrequency SlugTrailTimeFrequency
		{
			get
			{
				return slugTrailTimeFrequency_0;
			}
			set
			{
				slugTrailTimeFrequency_0 = value;
			}
		}

		public bool SlugTrail_Use
		{
			get
			{
				return bool_24;
			}
			set
			{
				bool_24 = value;
			}
		}

		public bool SlugTrail_OwnAndAllied
		{
			get
			{
				return bool_25;
			}
			set
			{
				bool_25 = value;
			}
		}

		public bool SlugTrail_Friendly
		{
			get
			{
				return bool_26;
			}
			set
			{
				bool_26 = value;
			}
		}

		public bool SlugTrail_Neutral
		{
			get
			{
				return bool_27;
			}
			set
			{
				bool_27 = value;
			}
		}

		public bool SlugTrail_Hostile
		{
			get
			{
				return bool_28;
			}
			set
			{
				bool_28 = value;
			}
		}

		public int SlugTrail_LifeTime
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		public int GroundUnitZoom
		{
			get
			{
				return int_4;
			}
			set
			{
				int_4 = value;
			}
		}

		public int DiamondZoom
		{
			get
			{
				return int_5;
			}
			set
			{
				int_5 = value;
			}
		}

		public int IconZoom
		{
			get
			{
				return int_8;
			}
			set
			{
				int_8 = value;
			}
		}

		public int FlowerZoom
		{
			get
			{
				return int_7;
			}
			set
			{
				int_7 = value;
			}
		}

		public int RectangleZoom
		{
			get
			{
				return int_6;
			}
			set
			{
				int_6 = value;
			}
		}

		public bool? ResetZoomAtStartup
		{
			get
			{
				if (!DquymeWoeHm.HasValue)
				{
					DquymeWoeHm = true;
				}
				return DquymeWoeHm.Value;
			}
			set
			{
				if (value.HasValue)
				{
					DquymeWoeHm = value;
				}
				else
				{
					DquymeWoeHm = true;
				}
			}
		}

		public bool SlugTrail_Unfriendly
		{
			get
			{
				return bool_29;
			}
			set
			{
				bool_29 = value;
			}
		}

		public bool SlugTrail_UnKnown
		{
			get
			{
				return bool_30;
			}
			set
			{
				bool_30 = value;
			}
		}

		public MapProfile PersonalMapProfile
		{
			get
			{
				if (mapProfile_0 == null)
				{
					mapProfile_0 = MapProfile.GetDefaultProfile();
				}
				return mapProfile_0;
			}
			set
			{
				mapProfile_0 = value;
			}
		}

		public bool AllowInGameDownloads
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		public bool ShowProbanner
		{
			[CompilerGenerated]
			get
			{
				return CcbymjFafGV;
			}
			[CompilerGenerated]
			set
			{
				CcbymjFafGV = value;
			}
		}

		public bool AllowSmartRPPlacement
		{
			get
			{
				return bool_31;
			}
			set
			{
				bool_31 = value;
			}
		}

		public bool UseDarkThemeOnLuaConsoles
		{
			get
			{
				return bool_32;
			}
			set
			{
				bool_32 = value;
			}
		}

		public GamePreferences()
		{
			AltitudeRender = new AltitudeAnd3DRenderPreferences();
			MessageLogSettings = new Dictionary<LoggedMessage.MessageType, LoggedMessage.MessageSettings>();
			ShowProbanner = true;
			MessageLogSettings.Add(LoggedMessage.MessageType.AirOps, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.CommsIsolatedMessage, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.CommsRelatedMessage, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.ContactChange, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.DockingOps, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewAirContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewSurfaceContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewUnderwaterContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewGroundContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewMineContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.PointDefence, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.EventEngine, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.SpecialMessage, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: true, _ShowBaloon: false, _SwitchToTimeScale1X: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.CustomUI, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: true, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UI, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitAI, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitDamage, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitLost, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponDamage, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponEndgame, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponLogic, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewWeaponContact, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: true, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnguidedWeaponModifiers, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.const_23, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.Debug, new LoggedMessage.MessageSettings(_ShowOnMessageLog: true, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitAIEmergency, new LoggedMessage.MessageSettings(_ShowOnMessageLog: false, _PopUp: true, _ShowBaloon: true, _SwitchToTimeScale1X: true));
		}

		~GamePreferences()
		{
			base.Finalize();
		}

		static GamePreferences()
		{
			Class72.smethod_20();
		}
	}

	private _GameStatus _GameStatus_0;

	private _GameMode _GameMode_0;

	private _MultiplayerGameMode _MultiplayerGameMode_0;

	[CompilerGenerated]
	private static GameModeChangedEventHandler gameModeChangedEventHandler_0;

	[CompilerGenerated]
	private static CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler_0;

	[CompilerGenerated]
	private static GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler_0;

	public string AALog_Name;

	public const bool PRECISE_ETA_PLOTTEDCOURSE_CALCULATION = false;

	public _GameStatus Status => _GameStatus_0;

	public _GameMode GameMode
	{
		get
		{
			return _GameMode_0;
		}
		set
		{
			bool num = _GameMode_0 != value;
			_GameMode_0 = value;
			if (num)
			{
				gameModeChangedEventHandler_0?.Invoke();
			}
		}
	}

	public _MultiplayerGameMode MultiplayerGameMode
	{
		get
		{
			return _MultiplayerGameMode_0;
		}
		set
		{
			_MultiplayerGameMode_0 = value;
		}
	}

	public bool IsScenEditGameMode => (GameMode == _GameMode.ScenEdit) | (GameMode == _GameMode.MultiplayerScenEdit);

	public static event GameModeChangedEventHandler GameModeChanged
	{
		[CompilerGenerated]
		add
		{
			GameModeChangedEventHandler gameModeChangedEventHandler = gameModeChangedEventHandler_0;
			GameModeChangedEventHandler gameModeChangedEventHandler2;
			do
			{
				gameModeChangedEventHandler2 = gameModeChangedEventHandler;
				GameModeChangedEventHandler value2 = (GameModeChangedEventHandler)Delegate.Combine(gameModeChangedEventHandler2, value);
				gameModeChangedEventHandler = Interlocked.CompareExchange(ref gameModeChangedEventHandler_0, value2, gameModeChangedEventHandler2);
			}
			while ((object)gameModeChangedEventHandler != gameModeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GameModeChangedEventHandler gameModeChangedEventHandler = gameModeChangedEventHandler_0;
			GameModeChangedEventHandler gameModeChangedEventHandler2;
			do
			{
				gameModeChangedEventHandler2 = gameModeChangedEventHandler;
				GameModeChangedEventHandler value2 = (GameModeChangedEventHandler)Delegate.Remove(gameModeChangedEventHandler2, value);
				gameModeChangedEventHandler = Interlocked.CompareExchange(ref gameModeChangedEventHandler_0, value2, gameModeChangedEventHandler2);
			}
			while ((object)gameModeChangedEventHandler != gameModeChangedEventHandler2);
		}
	}

	public static event CurrentGameStatusChangedEventHandler CurrentGameStatusChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler = currentGameStatusChangedEventHandler_0;
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler2;
			do
			{
				currentGameStatusChangedEventHandler2 = currentGameStatusChangedEventHandler;
				CurrentGameStatusChangedEventHandler value2 = (CurrentGameStatusChangedEventHandler)Delegate.Combine(currentGameStatusChangedEventHandler2, value);
				currentGameStatusChangedEventHandler = Interlocked.CompareExchange(ref currentGameStatusChangedEventHandler_0, value2, currentGameStatusChangedEventHandler2);
			}
			while ((object)currentGameStatusChangedEventHandler != currentGameStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler = currentGameStatusChangedEventHandler_0;
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler2;
			do
			{
				currentGameStatusChangedEventHandler2 = currentGameStatusChangedEventHandler;
				CurrentGameStatusChangedEventHandler value2 = (CurrentGameStatusChangedEventHandler)Delegate.Remove(currentGameStatusChangedEventHandler2, value);
				currentGameStatusChangedEventHandler = Interlocked.CompareExchange(ref currentGameStatusChangedEventHandler_0, value2, currentGameStatusChangedEventHandler2);
			}
			while ((object)currentGameStatusChangedEventHandler != currentGameStatusChangedEventHandler2);
		}
	}

	public static event GameStatusChangeRequestIssuedEventHandler GameStatusChangeRequestIssued
	{
		[CompilerGenerated]
		add
		{
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler = gameStatusChangeRequestIssuedEventHandler_0;
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler2;
			do
			{
				gameStatusChangeRequestIssuedEventHandler2 = gameStatusChangeRequestIssuedEventHandler;
				GameStatusChangeRequestIssuedEventHandler value2 = (GameStatusChangeRequestIssuedEventHandler)Delegate.Combine(gameStatusChangeRequestIssuedEventHandler2, value);
				gameStatusChangeRequestIssuedEventHandler = Interlocked.CompareExchange(ref gameStatusChangeRequestIssuedEventHandler_0, value2, gameStatusChangeRequestIssuedEventHandler2);
			}
			while ((object)gameStatusChangeRequestIssuedEventHandler != gameStatusChangeRequestIssuedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler = gameStatusChangeRequestIssuedEventHandler_0;
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler2;
			do
			{
				gameStatusChangeRequestIssuedEventHandler2 = gameStatusChangeRequestIssuedEventHandler;
				GameStatusChangeRequestIssuedEventHandler value2 = (GameStatusChangeRequestIssuedEventHandler)Delegate.Remove(gameStatusChangeRequestIssuedEventHandler2, value);
				gameStatusChangeRequestIssuedEventHandler = Interlocked.CompareExchange(ref gameStatusChangeRequestIssuedEventHandler_0, value2, gameStatusChangeRequestIssuedEventHandler2);
			}
			while ((object)gameStatusChangeRequestIssuedEventHandler != gameStatusChangeRequestIssuedEventHandler2);
		}
	}

	internal static void RequestGameStatusChange(_GameStatus DesiredStatus)
	{
		gameStatusChangeRequestIssuedEventHandler_0?.Invoke(DesiredStatus);
	}

	public void Run()
	{
		if (GameMode != _GameMode.MultiPlayer && MultiplayerGameMode != _MultiplayerGameMode.Realtime)
		{
			_GameStatus_0 = _GameStatus.Running;
			currentGameStatusChangedEventHandler_0?.Invoke();
		}
	}

	public void Pause()
	{
		_GameStatus_0 = _GameStatus.Paused;
		currentGameStatusChangedEventHandler_0?.Invoke();
	}

	public Game()
	{
		DateTime now = DateAndTime.Now;
		AALog_Name = now.Year + "-" + Strings.Right("00" + now.Month, 2).ToString() + "-" + Strings.Right("00" + now.Day, 2).ToString() + "_" + Strings.Right("00" + now.Hour, 2).ToString() + "." + Strings.Right("00" + now.Minute, 2).ToString() + "." + Strings.Right("00" + now.Second, 2).ToString();
	}

	static Game()
	{
		Class72.smethod_20();
	}
}
