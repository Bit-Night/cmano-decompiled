// Command.Client: whole-type decompilation failed; members decompiled one by one.
using System.Windows.Threading;

public static Dispatcher Dispatcher;

using Magic.Samples.DisplaySettings;

internal static DisplaySettings OriginalDisplaySettings;

internal static bool MainFormHasLoaded;

public static bool MustRefreshMainForm;

using System.Threading;

public static Thread SimulationThread;

using System.Collections.Generic;
using System.Drawing;

public static Dictionary<string, Bitmap> MapSymbolBitmaps;

using System.Runtime.CompilerServices;
using Command_Core;

[AccessedThroughProperty("_CurrentScenario")]
[CompilerGenerated]
private static Scenario scenario_0;

internal static string CurrentScenarioFullFilePath;

using System.Runtime.CompilerServices;
using Command_Core;

[AccessedThroughProperty("_CurrentSide")]
[CompilerGenerated]
private static Side side_0;

private static UserAction userAction_0;

private static UserAction userAction_1;

using System.Collections.Generic;
using Command_Core;

public static List<ReferencePoint> PoligonDrawReferencePoints;

using System.Collections.Generic;
using Command_Core;

public static List<ReferencePoint> SmartRPPlacementReferencePoints;

internal static bool RunningInVM;

using Command_Core;

private static DBRecord dbrecord_0;

using Command_Core;

internal static RecorderTape CurrentTape;

private static bool bool_0;

internal static RecorderForm theRecorderForm;

internal static bool VCRPlaybackInProgress;

private static bool bool_1;

internal static int Diagnostic_AUCount;

internal static float Diagnostic_PulseTime;

internal static double Diagnostic_PathFinderQueue;

internal static string Diagnostic_PathFinderUnit;

using System.Threading;

private static ThreadPriority threadPriority_0;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

[AccessedThroughProperty("Timer1")]
[CompilerGenerated]
private static Timer timer_0;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

[AccessedThroughProperty("SteamDownloadCheckTimer")]
[CompilerGenerated]
private static Timer timer_1;

private static bool bool_2;

using Command_Core;

internal static ReferencePoint.OrientationType SelectedBearingType;

internal static float DPI_scale;

internal static string ScenLoadErrorFeedback;

using Command_Core;

private static Module_Unit.Unit unit_0;

using Command_Core;

private static AggregateGroundUnit_Engagment aggregateGroundUnit_Engagment_0;

internal static bool ShutdownInitiated;

using ExWorldWind;

internal static WorldWindow MainFormWorldWindow;

public static int CloneScenarioInterval;

private static int int_0;

using Command_Core;

internal static Mount SelectedMountForArcDisplay;

using Command_Core;

internal static WeaponSalvo SelectedSalvoForPlotCourse;

internal static int ContactReport_LastSelectedTabIndex;

using System.Windows.Forms;

internal static ToolStrip MainForm_MainToolstrip;

private static bool bool_3;

using System;

internal static Exception AutosaveException;

using System.Collections.Generic;

internal static Queue<string> CustomLayerQueue;

public static string SaveScenarioPath;

using System.Drawing;

private static Bitmap bitmap_0;

using Command_Core;

internal static LockObject SteamWorkshop_LockObj;

using System;
using System.Collections.Generic;
using System.Drawing;

public static Dictionary<Image, IntPtr> Cache_GDIBitmapHandles;

using System.Drawing;

internal static Font _drawFont;

using System.Drawing;

public static Font CommandDefaultFont;

using System;

public static DateTime? RunToThisTime;

using System.Collections.Generic;

public static List<string> RecentFilenames;

private static int int_1;

public static bool bool_4;

public static string IgnoredCoreUIMessages;

public static string OSMstylesFolder;

using Command_Core;

private static ReferencePoint referencePoint_0;

using Command_Core;

public static ReferencePoint SelectedRefPoint;

using Command_Core;

public static Zone ZoneClipBoard;

using System.Collections.Generic;
using Command_Core;

public static List<Module_Unit.Unit> MapVisibleUnits;

using System.Collections.Generic;
using Command_Core;

public static Dictionary<Module_Unit.Unit, MainForm.RenderLocation_Struct> MapVisibleUnit_ScreenCoords;

using System.Collections.Generic;
using Command_Core;

public static List<Module_Unit.Unit> MapSelectableUnits;

public static bool MainWindowsUseFullScreen;

using Command_Core.Lua;

private static LuaSandBox luaSandBox_0;

using System.Collections.Generic;
using System.Drawing;

internal static Dictionary<string, Image> Cache_RotatedImages;

using System.Collections.Generic;
using System.Drawing;

internal static Dictionary<Image, Image> Cache_GhostedBitmaps;

using System.Collections.Generic;
using System.Drawing;

internal static Dictionary<Image, Image> Cache_ScaledBitmaps;

using System.Drawing;

internal static Color Color_Friendly;

using System.Drawing;

internal static Color Color_Unknown;

using System.Drawing;

internal static Color Color_Neutral;

using System.Drawing;

internal static Color Color_Unfriendly;

using System.Drawing;

internal static Color Color_Hostile;

using System.Drawing;

internal static Color Color_LOSShade;

using System.Drawing;

internal static Color Color_RPShade;

using System.Drawing;

internal static Color Color_PC_WPShade;

using Command_Core;

private static MapProfile mapProfile_0;

using Command_Core;

private static Waypoint waypoint_0;

public static double GroupOpacity;

public static byte GroupAlpha;

public static byte SensorOpacity;

using System;

private static Lazy<WeaponsWindow> lazy_0;

private static bool bool_5;

using System.Runtime.CompilerServices;

[CompilerGenerated]
[AccessedThroughProperty("_theSensorsWindow")]
private static UnitSensors unitSensors_0;

private static bool bool_6;

using System.Runtime.CompilerServices;

[AccessedThroughProperty("_theCommsWindow")]
[CompilerGenerated]
private static UnitComms unitComms_0;

private static DamageControlWindow damageControlWindow_0;

public static Magazines theMagazinesWindow;

public static CampaignEditorWindow theCampaignEditorWindow;

public static StartGameMenuWindow startGameMenuWindow_0;

public static TimeUnderway theTimeUnderwayWindow;

using System.ComponentModel;
using System.Runtime.CompilerServices;

[AccessedThroughProperty("BW_ShowLoadingDB")]
[CompilerGenerated]
private static BackgroundWorker backgroundWorker_0;

private static NewMission newMission_0;

public static FlightPlanErrors FlightPlanErrorsWindow;

public static FlightPlanTime FlightPlanTimeWindow;

internal static string AddUnit_LastUsedKeyword;

internal static byte? AddUnit_LastUsedType;

internal static int? AddUnit_LastUsedCountry;

private static bool ExkSdJeRkI;

using System.Collections.Generic;
using Command_Core;

public static Dictionary<LoggedMessage.MessageType, NewMessageForm> OpenMessageWindows;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static ScenarioChangingEventHandler scenarioChangingEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static SelectedUnitChangedEventHandler selectedUnitChangedEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static CurrentSideChangedEventHandler currentSideChangedEventHandler_0;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private static TimeAdvancedEventHandler timeAdvancedEventHandler_0;

using System.Windows.Threading;

public static Dispatcher MainThreadDispatcher;

using System.Windows.Forms.Integration;

public static ElementHost theElementHostRightColumn;

public static OrbitAnchor OrbitAnchorWindow;

public static LicenseTweaker theLT;

public static ScenarioFeatures ScenarioFeaturesWindow;

using System.Collections.Generic;
using Command_Core;

public static List<Geopoint_Struct[]> LOS_ShadedArea;

public static int LOS_HowManyThreads;

public static bool LoadingTimerLock;

using System.Collections.Generic;

public static List<FlightPlanVisbileOnMap> FPVisibility;

public static bool IsRealtime;

public static bool ScenarioWasLoadedAsBlank;

public static bool SkipOtherAreaValidationMessages;

private static bool bool_7;

using Command_Core;

public static VisualIndicator @ref;

private static FlightPlanAircraftLoadout flightPlanAircraftLoadout_0;

private static FlightPlanEditorTargets flightPlanEditorTargets_0;

private static FlightPlanEditorTargetsArea flightPlanEditorTargetsArea_0;

private static FlightPlanEditorTargetsPreliminary flightPlanEditorTargetsPreliminary_0;

private static FlightPlanEditorWeaponRoute aojSgikIhF;

private static AttackTarget attackTarget_0;

private static MissionEditor missionEditor_0;

private static CommData commData_0;

private static ReferencePointManager referencePointManager_0;

private static AirTaskingOrder airTaskingOrder_0;

private static FlightPlanEditor flightPlanEditor_0;

internal static FloatingLicenseErrorForm theFloatingLicenseErrorForm;

private static string string_0;

using Command_Core;

private static Module_Unit.Unit unit_1;

using Command_Core;

private static ActiveUnit activeUnit_0;

using Command_Core;

private static Contact contact_0;

using System.Runtime.CompilerServices;
using System.Threading;

[AccessedThroughProperty("Timer_Autosave")]
[CompilerGenerated]
private static Timer timer_2;

private static bool bool_8;

using Command_Core;

private static LockObject lockObject_0;

using System.Windows.Forms;

private static KeysConverter keysConverter_0;

private static bool bool_9;

public static string FloatingLicenseErrorMessage;

public const int AUTOSAVE_INTERVAL_DEFAULT = 20000;

public const int AUTOSAVE_INTERVAL_RESET = 0;

private static DoctrineForm doctrineForm_0;

public static readonly string RequiresAbsoluteControlMessage;

public static readonly string RequiresAbsoluteControlTitle;

public static readonly string CivRTMPFeatureNotSupported;

public static readonly string CivRTMPFeatureNotSupportedTitle;

using Command_Core;

public static Game CurrentGame => scenario_0.GameContext;

public static UnitSensors theSensorsWindow
{
	get
	{
		if (unitSensors_0 == null)
		{
			smethod_4(new UnitSensors());
		}
		return unitSensors_0;
	}
	set
	{
		smethod_4(value);
	}
}

public static UnitComms theCommsWindow
{
	get
	{
		if (unitComms_0 == null)
		{
			smethod_5(new UnitComms());
		}
		return unitComms_0;
	}
	set
	{
		smethod_5(value);
	}
}

public static DamageControlWindow theDamageControlWindow
{
	get
	{
		if (damageControlWindow_0 == null)
		{
			damageControlWindow_0 = new DamageControlWindow();
		}
		return damageControlWindow_0;
	}
	set
	{
		damageControlWindow_0 = value;
	}
}

public static NewMission NewMissionWindow
{
	get
	{
		if (newMission_0 == null)
		{
			newMission_0 = new NewMission();
		}
		return newMission_0;
	}
	set
	{
		newMission_0 = value;
	}
}

public static bool AddingDecoyPlatform
{
	get
	{
		return bool_7;
	}
	set
	{
		bool_7 = value;
		AddUnit.Unarmed = value;
	}
}

using System.IO;
using Command_Core;

internal static string SteamWorkshopFolder => Path.Combine(GameGeneral.TopLevelWritablePath, "Scenarios", "Steam Workshop");

using System.Windows;

public static bool MainFormShownComplete
{
	get
	{
		return bool_3;
	}
	set
	{
		bool_3 = value;
		if (value && startGameMenuWindow_0 != null && ((UIElement)startGameMenuWindow_0).IsVisible)
		{
			startGameMenuWindow_0.ShowButtons();
		}
	}
}

public static FlightPlanAircraftLoadout FlightPlanAircraftLoadoutWindow
{
	get
	{
		if (flightPlanAircraftLoadout_0 == null)
		{
			flightPlanAircraftLoadout_0 = new FlightPlanAircraftLoadout();
		}
		return flightPlanAircraftLoadout_0;
	}
}

using Microsoft.VisualBasic;

public static FlightPlanEditorTargets FlightPlanEditorTargetsWindow
{
	get
	{
		if (Information.IsNothing((object)flightPlanEditorTargets_0))
		{
			flightPlanEditorTargets_0 = new FlightPlanEditorTargets();
		}
		return flightPlanEditorTargets_0;
	}
}

using Microsoft.VisualBasic;

public static FlightPlanEditorTargetsArea FlightPlanEditorTargetsAreaWindow
{
	get
	{
		if (Information.IsNothing((object)flightPlanEditorTargetsArea_0))
		{
			flightPlanEditorTargetsArea_0 = new FlightPlanEditorTargetsArea();
		}
		return flightPlanEditorTargetsArea_0;
	}
}

using Microsoft.VisualBasic;

public static FlightPlanEditorTargetsPreliminary FlightPlanEditorTargetsPreliminaryWindow
{
	get
	{
		if (Information.IsNothing((object)flightPlanEditorTargetsPreliminary_0))
		{
			flightPlanEditorTargetsPreliminary_0 = new FlightPlanEditorTargetsPreliminary();
		}
		return flightPlanEditorTargetsPreliminary_0;
	}
}

using Microsoft.VisualBasic;

public static FlightPlanEditorWeaponRoute FlightPlanEditorWeaponRouteWindow
{
	get
	{
		if (Information.IsNothing((object)aojSgikIhF))
		{
			aojSgikIhF = new FlightPlanEditorWeaponRoute();
		}
		return aojSgikIhF;
	}
}

using Microsoft.VisualBasic;

public static AttackTarget WeapAllocWindow
{
	get
	{
		if (Information.IsNothing((object)attackTarget_0))
		{
			attackTarget_0 = new AttackTarget();
		}
		return attackTarget_0;
	}
	set
	{
		attackTarget_0 = value;
	}
}

using Command_Core.Lua;
using Microsoft.VisualBasic;

public static LuaSandBox LuaSandbox
{
	get
	{
		if (Information.IsNothing((object)luaSandBox_0))
		{
			luaSandBox_0 = new LuaSandBox();
		}
		return luaSandBox_0;
	}
	set
	{
		luaSandBox_0 = value;
	}
}

using System.Drawing;
using Command_Core;

internal static Color ColorFromStance
{
	get
	{
		Color color = default(Color);
		return theStance switch
		{
			Misc.PostureStance.Neutral => Color_Neutral, 
			Misc.PostureStance.Friendly => Color_Friendly, 
			Misc.PostureStance.Unfriendly => Color_Unfriendly, 
			Misc.PostureStance.Hostile => Color_Hostile, 
			Misc.PostureStance.Unknown => Color_Unknown, 
			_ => color, 
		};
	}
}

using Microsoft.VisualBasic;

public static MissionEditor MissionEditorWindow
{
	get
	{
		if (Information.IsNothing((object)missionEditor_0))
		{
			missionEditor_0 = new MissionEditor();
		}
		return missionEditor_0;
	}
}

using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static CommData CommDataWindow
{
	get
	{
		if (GameGeneral.Beta_PlatformComms && scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
		{
			if (side_0 == null)
			{
				return null;
			}
			if (Information.IsNothing((object)commData_0) || ((Control)commData_0).IsDisposed)
			{
				commData_0 = new CommData(side_0.MinuteTransmissionQueue, side_0.MinuteFeedbackList);
			}
			if (SelectedUnit != null && Operators.CompareString(SelectedUnit.get_UnitSide(SetSideOnly: false).ObjectID, side_0.ObjectID, true) == 0 && SelectedUnit.IsActiveUnit)
			{
				if (((Control)commData_0).Visible)
				{
					commData_0.ReloadData(side_0.MinuteTransmissionQueue, side_0.MinuteFeedbackList);
					commData_0.ReloadNetworks();
				}
				((Control)commData_0).Show();
				((Control)commData_0).BringToFront();
			}
			return commData_0;
		}
		return null;
	}
}

public static ReferencePointManager ReferencePointManagerWindow
{
	get
	{
		if (referencePointManager_0 == null)
		{
			referencePointManager_0 = new ReferencePointManager();
		}
		return referencePointManager_0;
	}
}

using Microsoft.VisualBasic;

public static AirTaskingOrder AirTaskingOrderWindow
{
	get
	{
		if (Information.IsNothing((object)airTaskingOrder_0))
		{
			airTaskingOrder_0 = new AirTaskingOrder();
		}
		return airTaskingOrder_0;
	}
}

using Microsoft.VisualBasic;

public static FlightPlanEditor FlightPlanEditorWindow
{
	get
	{
		if (Information.IsNothing((object)flightPlanEditor_0))
		{
			flightPlanEditor_0 = new FlightPlanEditor();
		}
		return flightPlanEditor_0;
	}
	set
	{
		flightPlanEditor_0 = value;
	}
}

public static WeaponsWindow theWeaponsWindow => lazy_0.Value;

public static bool RunningInSteamMode
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

using Command_Core;

public static DBRecord CurrentDB
{
	get
	{
		return dbrecord_0;
	}
	set
	{
		bool num = value != dbrecord_0;
		DBRecord object_ = dbrecord_0;
		dbrecord_0 = value;
		if (num)
		{
			smethod_23(object_);
		}
	}
}

using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

internal static AggregateGroundUnit_Engagment MouseHoverAGUEngagement
{
	get
	{
		return aggregateGroundUnit_Engagment_0;
	}
	set
	{
		bool flag = ((!Information.IsNothing((object)aggregateGroundUnit_Engagment_0)) ? (aggregateGroundUnit_Engagment_0 != value) : (!Information.IsNothing((object)value)));
		if (flag)
		{
			MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		aggregateGroundUnit_Engagment_0 = value;
		if (flag)
		{
			MyProject.Forms.MainForm.MapRender_UI();
		}
		if (flag)
		{
			MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
	}
}

using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

internal static Module_Unit.Unit MouseHoveredUnit
{
	get
	{
		return unit_0;
	}
	set
	{
		bool flag = ((unit_0 != null) ? (unit_0 != value) : (value != null));
		if (flag && !Information.IsNothing((object)unit_0) && unit_0.IsContact() && ((Contact)unit_0).IsFilteredOut)
		{
			MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		unit_0 = value;
		if (flag)
		{
			MyProject.Forms.MainForm.MapRender_UI();
		}
		if (flag && !Information.IsNothing((object)unit_0) && unit_0.IsContact() && ((Contact)unit_0).IsFilteredOut)
		{
			MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
		}
		MyProject.Forms.MainForm.UpdateHoverInfo(flag);
	}
}

using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using Command.My;

internal static bool RecordingInProgress
{
	set
	{
		bool_0 = value;
		if (value)
		{
			MyProject.Forms.MainForm.TSB_Record.Checked = true;
			((ToolStripItem)MyProject.Forms.MainForm.TSB_Record).Text = "Stop rec";
			((ToolStripItem)MyProject.Forms.MainForm.TSB_Record).Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Stop_16.gif");
		}
		else
		{
			MyProject.Forms.MainForm.TSB_Record.Checked = false;
			((ToolStripItem)MyProject.Forms.MainForm.TSB_Record).Text = "Record";
			((ToolStripItem)MyProject.Forms.MainForm.TSB_Record).Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\record_button_16.png");
		}
	}
}

using Command_Core;

public static Scenario CurrentScenario => scenario_0;

using System;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

public static Side CurrentSide
{
	get
	{
		return side_0;
	}
	set
	{
		Side side = side_0;
		smethod_1(value);
		if (side == value)
		{
			return;
		}
		SelectThisUnit(null, ThisUnitOnly: true);
		if (side != null)
		{
			side.IsHumanControlled = false;
			side.IsPlayerControlled = false;
		}
		int currentUserAction;
		if (value == null)
		{
			currentUserAction = 0;
		}
		else
		{
			value.IsHumanControlled = true;
			if (CurrentGame.GameMode != Game._GameMode.ScenEdit && !Realtime)
			{
				value.IsPlayerControlled = true;
				value.ScrubMissions(scenario_0);
				if (LuaSandbox.ScenarioContextHasBeenInitalized())
				{
					scenario_0.TriggerPlayerJoinedSideEvents();
				}
			}
			if (!SimConfiguration.DefaultGamePreferences.UsePersonalMapProfile)
			{
				CurrentMapProfile = value.SideMapProfile;
			}
			else
			{
				CurrentMapProfile = SimConfiguration.DefaultGamePreferences.PersonalMapProfile;
			}
			try
			{
				MyProject.Forms.MainForm.AdjustQuickJumpMenu();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			scenario_0.AddMessage("Switched side to: " + value.Name, "Switched side", LoggedMessage.MessageType.UI, 0, null);
			currentUserAction = 0;
		}
		CurrentUserAction = (UserAction)currentUserAction;
		currentSideChangedEventHandler_0?.Invoke();
	}
}

using System;
using System.IO;
using Command_Core;
using Command.My;
using DXRenderer;
using Microsoft.VisualBasic.CompilerServices;
using VectorTileRenderer;

public static MapProfile CurrentMapProfile
{
	get
	{
		if (SimConfiguration.DefaultGamePreferences.UsePersonalMapProfile && SimConfiguration.DefaultGamePreferences.PersonalMapProfile != null)
		{
			return SimConfiguration.DefaultGamePreferences.PersonalMapProfile;
		}
		if (mapProfile_0 == null)
		{
			mapProfile_0 = MapProfile.GetDefaultProfile();
		}
		return mapProfile_0;
	}
	set
	{
		mapProfile_0 = value;
		if (!string.IsNullOrEmpty(mapProfile_0.SelectedVectorMapStyle))
		{
			string path = Path.Combine(OSMstylesFolder, mapProfile_0.SelectedVectorMapStyle);
			if (File.Exists(path))
			{
				if (TileCache.theVectorTileSource == null)
				{
					TileCache.InstantiateVectorTileSource();
				}
				TileCache.theVectorTileSource.Style = GlMapStyle.FromFile(path);
			}
		}
		try
		{
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Collections.Pooled;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static Module_Unit.Unit SelectedUnit
{
	get
	{
		Module_Unit.Unit result;
		try
		{
			if (string.IsNullOrEmpty(string_0))
			{
				unit_1 = null;
				result = null;
			}
			else if (!IsRealtime && unit_1 != null && string.CompareOrdinal(unit_1.ObjectID, string_0) == 0)
			{
				result = unit_1;
			}
			else if (scenario_0.ActiveUnits.TryGetValue(string_0, out activeUnit_0))
			{
				unit_1 = activeUnit_0;
				result = activeUnit_0;
			}
			else
			{
				if (!string.IsNullOrEmpty(CurrentMapProfile.IsolatedPOVObjectID) && scenario_0.ActiveUnits.ContainsKey(CurrentMapProfile.IsolatedPOVObjectID))
				{
					PooledList<Contact> pooledList = Module_ActiveUnit_Sensory.ContactsVisibleToMe(scenario_0.ActiveUnits[CurrentMapProfile.IsolatedPOVObjectID].Sensory);
					foreach (Contact item in pooledList)
					{
						if (string.CompareOrdinal(item.ObjectID, string_0) != 0)
						{
							continue;
						}
						unit_1 = item;
						result = item;
						goto end_IL_0001;
					}
					goto IL_01fd;
				}
				if (side_0 == null)
				{
					goto IL_01fd;
				}
				int count = side_0.Contacts.Count;
				PooledList<Contact> contacts_List = side_0.Contacts_List;
				int num = count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						try
						{
							Contact contact = contacts_List[num2];
							if (string.CompareOrdinal(contact.ObjectID, string_0) == 0)
							{
								unit_1 = contact;
								result = contact;
								break;
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						num2++;
						continue;
					}
					int count2 = side_0.BaseContacts_List.Count;
					List<Contact> baseContacts_List = side_0.BaseContacts_List;
					int num3 = count2 - 1;
					for (int i = 0; i <= num3; i++)
					{
						try
						{
							Contact contact = baseContacts_List[i];
							if (string.CompareOrdinal(contact.ObjectID, string_0) == 0)
							{
								unit_1 = contact;
								result = contact;
								goto end_IL_0146;
							}
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
					goto IL_01fd;
					continue;
					end_IL_0146:
					break;
				}
			}
			goto end_IL_0001;
			IL_01fd:
			result = null;
			end_IL_0001:;
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}

using System;
using System.Diagnostics;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static Waypoint SelectedWaypoint
{
	get
	{
		return waypoint_0;
	}
	set
	{
		try
		{
			bool flag = false;
			if (value != waypoint_0)
			{
				int num;
				if (value != null && waypoint_0 != null)
				{
					if (Operators.CompareString(waypoint_0.ObjectID, value.ObjectID, true) == 0)
					{
						goto IL_0034;
					}
					num = 1;
				}
				else
				{
					num = 1;
				}
				flag = (byte)num != 0;
			}
			goto IL_0034;
			IL_0034:
			if (flag)
			{
				selectedWaypointPreChangeEventHandler_0?.Invoke();
			}
			waypoint_0 = value;
			int mustRefreshMainForm;
			if (flag)
			{
				selectedWaypointChangedEventHandler_0?.Invoke(value);
				if (!Realtime)
				{
					mustRefreshMainForm = 1;
				}
				else
				{
					RealtimeTerminal.SendSelectionChange(SelectedUnit, waypoint_0);
					mustRefreshMainForm = 1;
				}
			}
			else
			{
				mustRefreshMainForm = 1;
			}
			MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200629", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}

using System.Collections.Generic;
using Command_Core;
using Microsoft.VisualBasic;

public static List<ReferencePoint> HighlightedRefPoints
{
	get
	{
		if (!Information.IsNothing((object)side_0))
		{
			List<ReferencePoint> list = new List<ReferencePoint>();
			foreach (ReferencePoint refPoint in side_0.RefPoints)
			{
				if (!Information.IsNothing((object)refPoint) && refPoint.IsHighlighted)
				{
					list.Add(refPoint);
				}
			}
			return list;
		}
		return null;
	}
}

using System.Collections.Generic;
using System.Windows.Forms;
using Command_Core;
using Command.My;

public static UserAction CurrentUserAction
{
	get
	{
		if (userAction_0 != UserAction.None)
		{
			return userAction_0;
		}
		return userAction_1;
	}
	set
	{
		UserAction userAction = userAction_0;
		bool flag;
		if ((flag = userAction_0 != value) && (userAction == UserAction.PlottingCourse || value == UserAction.PlottingCourse))
		{
			bool flag2 = value == UserAction.PlottingCourse;
			List<ActiveUnit> selectedActiveUnitsForCoursePlot = GetSelectedActiveUnitsForCoursePlot();
			foreach (ActiveUnit item in selectedActiveUnitsForCoursePlot)
			{
				item.PlayerIsPlottingCourse = flag2;
			}
			if (Realtime && !flag2)
			{
				RealtimeTerminal.SendCourseUpdate(selectedActiveUnitsForCoursePlot);
			}
		}
		userAction_0 = value;
		int addingDecoyPlatform;
		if (flag)
		{
			if (userAction_0 == UserAction.PlottingCourseForSalvo)
			{
				MustRefreshMainForm = true;
				((Control)WeapAllocWindow).Hide();
			}
			if (userAction == UserAction.PlottingCourseForSalvo)
			{
				if (!((Control)WeapAllocWindow).IsDisposed)
				{
					WeapAllocWindow.RefreshForm();
					((Control)WeapAllocWindow).Show();
				}
				if (Realtime)
				{
					RealtimeTerminal.SendSalvoCourseUpdate(side_0, SelectedSalvoForPlotCourse);
				}
			}
			MyProject.Forms.MainForm.AdjustToUserActionChange();
			addingDecoyPlatform = 0;
		}
		else
		{
			addingDecoyPlatform = 0;
		}
		AddingDecoyPlatform = (byte)addingDecoyPlatform != 0;
	}
}

public static UserAction CurrentUserAction_Hovering
{
	get
	{
		return userAction_1;
	}
	set
	{
		userAction_1 = value;
	}
}

using Command.My;
using CommandNetcode.RT;

public static RealtimeTerminal RealtimeTerminal
{
	get
	{
		if (MyProject.Forms.m_MainForm == null)
		{
			return null;
		}
		return MyProject.Forms.MainForm.RealtimeTerminal;
	}
}

using Command.My;

public static bool RealtimeAC
{
	get
	{
		if (!ShutdownInitiated)
		{
			if (MyProject.Forms.m_MainForm == null)
			{
				return false;
			}
			return MyProject.Forms.MainForm.RealtimeAC;
		}
		return false;
	}
}

using Command.My;

public static bool Realtime
{
	get
	{
		if (ShutdownInitiated)
		{
			return false;
		}
		if (MyProject.Forms.m_MainForm != null)
		{
			return MyProject.Forms.MainForm.Realtime;
		}
		return false;
	}
}

public static bool AllowEditModeActions
{
	get
	{
		if (!Realtime)
		{
			return CurrentGame != null && CurrentGame.IsScenEditGameMode;
		}
		return RealtimeAC && CurrentGame != null && CurrentGame.IsScenEditGameMode;
	}
}

public static bool AllowGodModeActions
{
	get
	{
		if (CurrentGame == null)
		{
			return false;
		}
		return CurrentGame.IsScenEditGameMode;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event ScenarioChangingEventHandler ScenarioChanging
{
	[CompilerGenerated]
	add
	{
		ScenarioChangingEventHandler scenarioChangingEventHandler = scenarioChangingEventHandler_0;
		ScenarioChangingEventHandler scenarioChangingEventHandler2;
		do
		{
			scenarioChangingEventHandler2 = scenarioChangingEventHandler;
			ScenarioChangingEventHandler value2 = (ScenarioChangingEventHandler)Delegate.Combine(scenarioChangingEventHandler2, value);
			scenarioChangingEventHandler = Interlocked.CompareExchange(ref scenarioChangingEventHandler_0, value2, scenarioChangingEventHandler2);
		}
		while ((object)scenarioChangingEventHandler != scenarioChangingEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		ScenarioChangingEventHandler scenarioChangingEventHandler = scenarioChangingEventHandler_0;
		ScenarioChangingEventHandler scenarioChangingEventHandler2;
		do
		{
			scenarioChangingEventHandler2 = scenarioChangingEventHandler;
			ScenarioChangingEventHandler value2 = (ScenarioChangingEventHandler)Delegate.Remove(scenarioChangingEventHandler2, value);
			scenarioChangingEventHandler = Interlocked.CompareExchange(ref scenarioChangingEventHandler_0, value2, scenarioChangingEventHandler2);
		}
		while ((object)scenarioChangingEventHandler != scenarioChangingEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event SelectedUnitChangedEventHandler SelectedUnitChanged
{
	[CompilerGenerated]
	add
	{
		SelectedUnitChangedEventHandler selectedUnitChangedEventHandler = selectedUnitChangedEventHandler_0;
		SelectedUnitChangedEventHandler selectedUnitChangedEventHandler2;
		do
		{
			selectedUnitChangedEventHandler2 = selectedUnitChangedEventHandler;
			SelectedUnitChangedEventHandler value2 = (SelectedUnitChangedEventHandler)Delegate.Combine(selectedUnitChangedEventHandler2, value);
			selectedUnitChangedEventHandler = Interlocked.CompareExchange(ref selectedUnitChangedEventHandler_0, value2, selectedUnitChangedEventHandler2);
		}
		while ((object)selectedUnitChangedEventHandler != selectedUnitChangedEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		SelectedUnitChangedEventHandler selectedUnitChangedEventHandler = selectedUnitChangedEventHandler_0;
		SelectedUnitChangedEventHandler selectedUnitChangedEventHandler2;
		do
		{
			selectedUnitChangedEventHandler2 = selectedUnitChangedEventHandler;
			SelectedUnitChangedEventHandler value2 = (SelectedUnitChangedEventHandler)Delegate.Remove(selectedUnitChangedEventHandler2, value);
			selectedUnitChangedEventHandler = Interlocked.CompareExchange(ref selectedUnitChangedEventHandler_0, value2, selectedUnitChangedEventHandler2);
		}
		while ((object)selectedUnitChangedEventHandler != selectedUnitChangedEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event SelectedWaypointChangedEventHandler SelectedWaypointChanged
{
	[CompilerGenerated]
	add
	{
		SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler = selectedWaypointChangedEventHandler_0;
		SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler2;
		do
		{
			selectedWaypointChangedEventHandler2 = selectedWaypointChangedEventHandler;
			SelectedWaypointChangedEventHandler value2 = (SelectedWaypointChangedEventHandler)Delegate.Combine(selectedWaypointChangedEventHandler2, value);
			selectedWaypointChangedEventHandler = Interlocked.CompareExchange(ref selectedWaypointChangedEventHandler_0, value2, selectedWaypointChangedEventHandler2);
		}
		while ((object)selectedWaypointChangedEventHandler != selectedWaypointChangedEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler = selectedWaypointChangedEventHandler_0;
		SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler2;
		do
		{
			selectedWaypointChangedEventHandler2 = selectedWaypointChangedEventHandler;
			SelectedWaypointChangedEventHandler value2 = (SelectedWaypointChangedEventHandler)Delegate.Remove(selectedWaypointChangedEventHandler2, value);
			selectedWaypointChangedEventHandler = Interlocked.CompareExchange(ref selectedWaypointChangedEventHandler_0, value2, selectedWaypointChangedEventHandler2);
		}
		while ((object)selectedWaypointChangedEventHandler != selectedWaypointChangedEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event SelectedUnitPreChangeEventHandler SelectedUnitPreChange
{
	[CompilerGenerated]
	add
	{
		SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler = selectedUnitPreChangeEventHandler_0;
		SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler2;
		do
		{
			selectedUnitPreChangeEventHandler2 = selectedUnitPreChangeEventHandler;
			SelectedUnitPreChangeEventHandler value2 = (SelectedUnitPreChangeEventHandler)Delegate.Combine(selectedUnitPreChangeEventHandler2, value);
			selectedUnitPreChangeEventHandler = Interlocked.CompareExchange(ref selectedUnitPreChangeEventHandler_0, value2, selectedUnitPreChangeEventHandler2);
		}
		while ((object)selectedUnitPreChangeEventHandler != selectedUnitPreChangeEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler = selectedUnitPreChangeEventHandler_0;
		SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler2;
		do
		{
			selectedUnitPreChangeEventHandler2 = selectedUnitPreChangeEventHandler;
			SelectedUnitPreChangeEventHandler value2 = (SelectedUnitPreChangeEventHandler)Delegate.Remove(selectedUnitPreChangeEventHandler2, value);
			selectedUnitPreChangeEventHandler = Interlocked.CompareExchange(ref selectedUnitPreChangeEventHandler_0, value2, selectedUnitPreChangeEventHandler2);
		}
		while ((object)selectedUnitPreChangeEventHandler != selectedUnitPreChangeEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event SelectedWaypointPreChangeEventHandler SelectedWaypointPreChange
{
	[CompilerGenerated]
	add
	{
		SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler = selectedWaypointPreChangeEventHandler_0;
		SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler2;
		do
		{
			selectedWaypointPreChangeEventHandler2 = selectedWaypointPreChangeEventHandler;
			SelectedWaypointPreChangeEventHandler value2 = (SelectedWaypointPreChangeEventHandler)Delegate.Combine(selectedWaypointPreChangeEventHandler2, value);
			selectedWaypointPreChangeEventHandler = Interlocked.CompareExchange(ref selectedWaypointPreChangeEventHandler_0, value2, selectedWaypointPreChangeEventHandler2);
		}
		while ((object)selectedWaypointPreChangeEventHandler != selectedWaypointPreChangeEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler = selectedWaypointPreChangeEventHandler_0;
		SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler2;
		do
		{
			selectedWaypointPreChangeEventHandler2 = selectedWaypointPreChangeEventHandler;
			SelectedWaypointPreChangeEventHandler value2 = (SelectedWaypointPreChangeEventHandler)Delegate.Remove(selectedWaypointPreChangeEventHandler2, value);
			selectedWaypointPreChangeEventHandler = Interlocked.CompareExchange(ref selectedWaypointPreChangeEventHandler_0, value2, selectedWaypointPreChangeEventHandler2);
		}
		while ((object)selectedWaypointPreChangeEventHandler != selectedWaypointPreChangeEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event CurrentSideChangedEventHandler CurrentSideChanged
{
	[CompilerGenerated]
	add
	{
		CurrentSideChangedEventHandler currentSideChangedEventHandler = currentSideChangedEventHandler_0;
		CurrentSideChangedEventHandler currentSideChangedEventHandler2;
		do
		{
			currentSideChangedEventHandler2 = currentSideChangedEventHandler;
			CurrentSideChangedEventHandler value2 = (CurrentSideChangedEventHandler)Delegate.Combine(currentSideChangedEventHandler2, value);
			currentSideChangedEventHandler = Interlocked.CompareExchange(ref currentSideChangedEventHandler_0, value2, currentSideChangedEventHandler2);
		}
		while ((object)currentSideChangedEventHandler != currentSideChangedEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		CurrentSideChangedEventHandler currentSideChangedEventHandler = currentSideChangedEventHandler_0;
		CurrentSideChangedEventHandler currentSideChangedEventHandler2;
		do
		{
			currentSideChangedEventHandler2 = currentSideChangedEventHandler;
			CurrentSideChangedEventHandler value2 = (CurrentSideChangedEventHandler)Delegate.Remove(currentSideChangedEventHandler2, value);
			currentSideChangedEventHandler = Interlocked.CompareExchange(ref currentSideChangedEventHandler_0, value2, currentSideChangedEventHandler2);
		}
		while ((object)currentSideChangedEventHandler != currentSideChangedEventHandler2);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;

public static event TimeAdvancedEventHandler TimeAdvanced
{
	[CompilerGenerated]
	add
	{
		TimeAdvancedEventHandler timeAdvancedEventHandler = timeAdvancedEventHandler_0;
		TimeAdvancedEventHandler timeAdvancedEventHandler2;
		do
		{
			timeAdvancedEventHandler2 = timeAdvancedEventHandler;
			TimeAdvancedEventHandler value2 = (TimeAdvancedEventHandler)Delegate.Combine(timeAdvancedEventHandler2, value);
			timeAdvancedEventHandler = Interlocked.CompareExchange(ref timeAdvancedEventHandler_0, value2, timeAdvancedEventHandler2);
		}
		while ((object)timeAdvancedEventHandler != timeAdvancedEventHandler2);
	}
	[CompilerGenerated]
	remove
	{
		TimeAdvancedEventHandler timeAdvancedEventHandler = timeAdvancedEventHandler_0;
		TimeAdvancedEventHandler timeAdvancedEventHandler2;
		do
		{
			timeAdvancedEventHandler2 = timeAdvancedEventHandler;
			TimeAdvancedEventHandler value2 = (TimeAdvancedEventHandler)Delegate.Remove(timeAdvancedEventHandler2, value);
			timeAdvancedEventHandler = Interlocked.CompareExchange(ref timeAdvancedEventHandler_0, value2, timeAdvancedEventHandler2);
		}
		while ((object)timeAdvancedEventHandler != timeAdvancedEventHandler2);
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;

static Client()
{
	//IL_005b: Unknown result type (might be due to invalid IL or missing references)
	//IL_0065: Expected O, but got Unknown
	//IL_0070: Unknown result type (might be due to invalid IL or missing references)
	//IL_007a: Expected O, but got Unknown
	//IL_0246: Unknown result type (might be due to invalid IL or missing references)
	//IL_0250: Expected O, but got Unknown
	Class72.smethod_20();
	MainFormHasLoaded = false;
	PoligonDrawReferencePoints = new List<ReferencePoint>();
	SmartRPPlacementReferencePoints = new List<ReferencePoint>();
	theRecorderForm = new RecorderForm();
	ScenLoadErrorFeedback = "";
	bool_3 = false;
	SteamWorkshop_LockObj = new LockObject();
	Cache_GDIBitmapHandles = new Dictionary<Image, IntPtr>();
	_drawFont = new Font("Verdana", 9f, (FontStyle)1);
	CommandDefaultFont = new Font("Segoe UI", 9f, (FontStyle)0);
	RecentFilenames = new List<string>();
	int_1 = 300;
	bool_4 = true;
	IgnoredCoreUIMessages = "";
	MapVisibleUnits = new List<Module_Unit.Unit>();
	MapVisibleUnit_ScreenCoords = new Dictionary<Module_Unit.Unit, MainForm.RenderLocation_Struct>();
	MapSelectableUnits = new List<Module_Unit.Unit>();
	Cache_RotatedImages = new Dictionary<string, Image>();
	Cache_GhostedBitmaps = new Dictionary<Image, Image>();
	Cache_ScaledBitmaps = new Dictionary<Image, Image>();
	Color_Friendly = Color.FromArgb(255, 128, 224, 255);
	Color_Unknown = Color.Yellow;
	Color_Neutral = Color.FromArgb(255, 137, 254, 137);
	Color_Unfriendly = Color.FromArgb(255, 255, 104, 1);
	Color_Hostile = Color.FromArgb(255, 219, 0, 0);
	Color_LOSShade = Color.FromArgb(75, Color.DodgerBlue);
	Color_RPShade = Color.FromArgb(255, Color.White);
	Color_PC_WPShade = Color.FromArgb(255, Color.White);
	GroupOpacity = 0.6;
	GroupAlpha = 100;
	SensorOpacity = 55;
	lazy_0 = new Lazy<WeaponsWindow>();
	theMagazinesWindow = new Magazines();
	theCampaignEditorWindow = new CampaignEditorWindow();
	theTimeUnderwayWindow = new TimeUnderway();
	FlightPlanErrorsWindow = new FlightPlanErrors();
	FlightPlanTimeWindow = new FlightPlanTime();
	ExkSdJeRkI = false;
	OrbitAnchorWindow = new OrbitAnchor();
	theLT = new LicenseTweaker();
	LOS_HowManyThreads = Environment.ProcessorCount - 1;
	LoadingTimerLock = false;
	FPVisibility = new List<FlightPlanVisbileOnMap>();
	IsRealtime = false;
	ScenarioWasLoadedAsBlank = false;
	SkipOtherAreaValidationMessages = false;
	bool_7 = false;
	theFloatingLicenseErrorForm = new FloatingLicenseErrorForm();
	bool_8 = false;
	lockObject_0 = new LockObject();
	keysConverter_0 = new KeysConverter();
	bool_9 = false;
	doctrineForm_0 = null;
	RequiresAbsoluteControlMessage = "Absolute Control is required to use this feature during a Real Time Multi-Player session. Use the multi-player panel to request Absolute Control of the scenario.";
	RequiresAbsoluteControlTitle = "Absolute Control Required";
	CivRTMPFeatureNotSupported = "This feature is not currently available in Real Time Multiplayer.";
	CivRTMPFeatureNotSupportedTitle = "Feature Not Available";
}

using System.Runtime.CompilerServices;
using Command_Core;

[SpecialName]
[CompilerGenerated]
private static void smethod_0(Scenario scenario_1)
{
	scenario_0 = scenario_1;
}

using System.Runtime.CompilerServices;
using Command_Core;

[SpecialName]
[CompilerGenerated]
private static void smethod_1(Side side_1)
{
	side_0 = side_1;
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SpecialName]
[CompilerGenerated]
private static void smethod_2(Timer timer_3)
{
	EventHandler eventHandler = smethod_38;
	Timer val = timer_0;
	if (val != null)
	{
		val.Tick -= eventHandler;
	}
	timer_0 = timer_3;
	val = timer_0;
	if (val != null)
	{
		val.Tick += eventHandler;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SpecialName]
[CompilerGenerated]
private static void smethod_3(Timer timer_3)
{
	EventHandler eventHandler = smethod_44;
	Timer val = timer_1;
	if (val != null)
	{
		val.Tick -= eventHandler;
	}
	timer_1 = timer_3;
	val = timer_1;
	if (val != null)
	{
		val.Tick += eventHandler;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SpecialName]
[CompilerGenerated]
private static void smethod_4(UnitSensors unitSensors_1)
{
	EventHandler eventHandler = smethod_46;
	UnitSensors unitSensors = unitSensors_0;
	if (unitSensors != null)
	{
		((Control)unitSensors).VisibleChanged -= eventHandler;
	}
	unitSensors_0 = unitSensors_1;
	unitSensors = unitSensors_0;
	if (unitSensors != null)
	{
		((Control)unitSensors).VisibleChanged += eventHandler;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SpecialName]
[CompilerGenerated]
private static void smethod_5(UnitComms unitComms_1)
{
	EventHandler eventHandler = smethod_47;
	UnitComms unitComms = unitComms_0;
	if (unitComms != null)
	{
		((Control)unitComms).VisibleChanged -= eventHandler;
	}
	unitComms_0 = unitComms_1;
	unitComms = unitComms_0;
	if (unitComms != null)
	{
		((Control)unitComms).VisibleChanged += eventHandler;
	}
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

[SpecialName]
[CompilerGenerated]
private static BackgroundWorker smethod_6()
{
	return backgroundWorker_0;
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

[SpecialName]
[CompilerGenerated]
private static void smethod_7(BackgroundWorker backgroundWorker_1)
{
	backgroundWorker_0 = backgroundWorker_1;
}

using System.Windows.Forms;

public static string GetCustomIconPath(string name)
{
	return Application.StartupPath + "\\Symbols\\Custom\\" + name;
}

private static void smethod_8()
{
	MustRefreshMainForm = true;
}

private static void smethod_9(string string_1)
{
	FloatingLicenseErrorMessage = string_1;
}

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static void Initialize()
{
	//IL_0417: Unknown result type (might be due to invalid IL or missing references)
	//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
	//IL_034b: Unknown result type (might be due to invalid IL or missing references)
	//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
	//IL_0130: Unknown result type (might be due to invalid IL or missing references)
	//IL_013a: Expected O, but got Unknown
	//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
	//IL_04e1: Expected O, but got Unknown
	try
	{
		foreach (string item in Startup._AssemblyLogBuffer)
		{
			GameGeneral.WriteLogDebugInfoToFile(item);
		}
		Startup._AssemblyLogBuffer = null;
		Dispatcher = Dispatcher.CurrentDispatcher;
		PlatformComponent.StatusChanged += smethod_27;
		ActiveUnit_Damage.DamageSustained += smethod_28;
		Scenario.CurrentSideChanged += smethod_25;
		Scenario.SidesChanged += smethod_26;
		Scenario.ScenCompleted += smethod_19;
		Scenario.CurrentScenarioChanged += smethod_10;
		Side.ScoreChanged += smethod_43;
		SAO_OverlaySingle.UseMapOverlay += smethod_42;
		GameGeneral.CoreToUIMessage += smethod_11;
		LuaSandbox.actionUIwindow += smethod_45;
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Initialization started.");
		}
		Thread thread = new Thread(UnitImageCaching.DownloadDBImages);
		thread.Name = "DB Images download thread";
		thread.Priority = ThreadPriority.Lowest;
		thread.Start();
		smethod_2(new Timer());
		timer_0.Interval = 1000;
		timer_0.Start();
		MyProject.Forms.MainForm.theBM_HostedUnits = null;
		MyProject.Forms.MainForm.initializeIcons();
		if (!Directory.Exists(SteamWorkshopFolder))
		{
			Directory.CreateDirectory(SteamWorkshopFolder);
		}
		int customDBsEnabled;
		if (!Directory.Exists(GameGeneral.AttachmentRepoPath))
		{
			Directory.CreateDirectory(GameGeneral.AttachmentRepoPath);
			customDBsEnabled = 0;
		}
		else
		{
			customDBsEnabled = 0;
		}
		GameGeneral.CoreInitialize((byte)customDBsEnabled != 0);
		Licensing.Initialize(bool_1);
		UnitImageCaching.Initialize();
		ParseCustomICons();
		if (!Directory.Exists(GameGeneral.LogsPath))
		{
			Directory.CreateDirectory(GameGeneral.LogsPath);
		}
		Sound.CreateSoundHandlers();
		try
		{
			AGU_CONFIG.LoadSettings();
			AGU_DATABASE.smethod_0();
			Helper.HANNIBAL_LoadStrings();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			GameGeneral.WriteLogDebugInfoToFile("AGU initialization failed: " + ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully initialized Sim Core.");
		}
		if (PowerManagement.IsSupportedByOS() && SimConfiguration.DefaultGamePreferences.AllowPowerPlanSwitch)
		{
			PowerManagement.SwitchToHighPerformance();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("Successfully switched to High Performance power plan.");
			}
		}
		LuaUIFunctions.RegisterLuaUIHandlers();
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully loaded Lua UI Handlers.");
		}
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully created new game.");
		}
		string text = SimConfiguration.DefaultDB_Hash;
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				GameGeneral.WriteLogDebugInfoToFile("Fetching most recent database hash (1).");
				text = (SimConfiguration.DefaultDB_Hash = DBOps.GetHashForMostRecentVersionOfThisDB(1));
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			DarkMessageBox.ShowError("DB hash fetching error (1): " + ex4.Message + "\r\n\r\n", "Error");
			ex4.Data.Add("Error at 441568", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (Versioned.IsNumeric((object)text))
			{
				GameGeneral.WriteLogDebugInfoToFile("Fetching most recent database hash (2).");
				text = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(text));
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			DarkMessageBox.ShowError("DB hash fetching error (2): " + ex6.Message + "\r\n\r\n", "Error");
			ex6.Data.Add("Error at 441580", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			ProjectData.ClearProjectError();
		}
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully set database hash value.");
		}
		GameGeneral.WriteLogDebugInfoToFile("Starting checks for known interfering processes.");
		try
		{
			rbcuxpXdK();
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			DarkMessageBox.ShowError("Error: " + ex8.Message + "\r\n\r\n", "Error");
			GameGeneral.WriteExceptionsToLog(ex8);
			ProjectData.ClearProjectError();
		}
		GameGeneral.WriteLogDebugInfoToFile("Setting initial scenario.");
		try
		{
			SetCurrentScenario(new Scenario(text), bool_10: false);
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			DarkMessageBox.ShowError("Error: " + ex10.Message + "\r\n\r\nAborting...", "Error");
			GameGeneral.WriteExceptionsToLog(ex10);
			try
			{
				Startup.PerformShutdown();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		SimulationThread = new Thread(CoreSimulation_Main);
		SimulationThread.Priority = ThreadPriority.Lowest;
		SimulationThread.Start();
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully completed Set Current Scenario.");
		}
		smethod_13();
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully initialized Lua.");
		}
		CacheMapUnitSymbols();
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully cached map symbols.");
		}
		CreateNewScenario();
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Successfully created new scenario.");
		}
		smethod_3(new Timer());
		timer_1.Interval = 60000;
		timer_1.Start();
		OSMstylesFolder = Path.Combine(GameGeneral.GISFolderPath, "OSM_Vector\\styles");
		MyProject.Forms.SpeedAlt.RefreshForm(RefreshEvenIfNotVisible: true);
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Initialization completed.");
		}
		smethod_22(new Timer(smethod_20, null, 20000, 20000));
		CurrentUserAction = UserAction.None;
	}
	catch (Exception ex11)
	{
		ProjectData.SetProjectError(ex11);
		Exception ex12 = ex11;
		ex12?.Data.Add("Error at 200576", ex12.Message);
		GameGeneral.WriteExceptionsToLog(ex12);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void ParseCustomICons(string AssociationFile, int DBID_Enum, bool CreateFileAutomatically = true)
{
	//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
	if (!FileExistsNative.FileExistsFast(GameGeneral.CustomIconPath + AssociationFile))
	{
		if (CreateFileAutomatically)
		{
			FileStream fileStream = File.Create(GameGeneral.CustomIconPath + AssociationFile);
			new StreamWriter(fileStream).Close();
			fileStream.Dispose();
			ParseCustomICons(AssociationFile, DBID_Enum, CreateFileAutomatically: false);
		}
		return;
	}
	GameGeneral.CustomIconCollection.Add(DBID_Enum, new Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, GameGeneral.CustomIconWrapper>>());
	GameGeneral.CustomIconCollection_Parent.Add(DBID_Enum, new Dictionary<GlobalVariables.ActiveUnitType, GameGeneral.CustomIconWrapper>());
	foreach (object value in Enum.GetValues(typeof(GlobalVariables.ActiveUnitType)))
	{
		GlobalVariables.ActiveUnitType key = (GlobalVariables.ActiveUnitType)Conversions.ToByte(value);
		GameGeneral.CustomIconCollection[DBID_Enum].Add(key, new Dictionary<int, GameGeneral.CustomIconWrapper>());
	}
	new OpenFileDialog();
	string[] array = Strings.Split(new StreamReader(GameGeneral.CustomIconPath + AssociationFile).ReadToEnd().Replace("\r", "\r\n").Replace("\n", "\r\n"), "\r\n", -1, (CompareMethod)1);
	foreach (string text in array)
	{
		if (string.IsNullOrEmpty(text))
		{
			continue;
		}
		string[] array2 = Strings.Split(text, ";", -1, (CompareMethod)1);
		if (array2.Count() < 3)
		{
			continue;
		}
		string text2 = array2[0].ToLower();
		int result;
		if (Operators.CompareString(array2[1], "*", true) != 0)
		{
			if (!int.TryParse(array2[1], out result))
			{
				continue;
			}
		}
		else
		{
			result = -1;
		}
		string text3 = array2[2];
		int result2 = -1;
		int num;
		if (array2.Count() > 3)
		{
			int.TryParse(array2[3], out result2);
			num = 0;
		}
		else
		{
			num = 0;
		}
		bool rotatable = (byte)num != 0;
		int num2;
		if (array2.Count() <= 4)
		{
			num2 = 0;
		}
		else if (Operators.CompareString(array2[4].ToLower().Trim(), "rot", true) != 0)
		{
			num2 = 0;
		}
		else
		{
			rotatable = true;
			num2 = 0;
		}
		GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)num2;
		if (Operators.CompareString(text2, "#ship", true) == 0)
		{
			activeUnitType = GlobalVariables.ActiveUnitType.Ship;
		}
		else if (Operators.CompareString(text2, "#aircraft", true) != 0)
		{
			if (Operators.CompareString(text2, "#vehicle", true) == 0)
			{
				activeUnitType = GlobalVariables.ActiveUnitType.Vehicle;
			}
			else if (Operators.CompareString(text2, "#facility", true) == 0)
			{
				activeUnitType = GlobalVariables.ActiveUnitType.Facility;
			}
			else if (Operators.CompareString(text2, "#submarine", true) != 0)
			{
				if (Operators.CompareString(text2, "#weapon", true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Weapon;
				}
				else if (Operators.CompareString(text2, "#satellite", true) != 0)
				{
					if (Operators.CompareString(text2, "#personnel", true) == 0)
					{
						activeUnitType = GlobalVariables.ActiveUnitType.Personnel;
					}
				}
				else
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Satellite;
				}
			}
			else
			{
				activeUnitType = GlobalVariables.ActiveUnitType.Submarine;
			}
		}
		else
		{
			activeUnitType = GlobalVariables.ActiveUnitType.Aircraft;
		}
		if (result == -1)
		{
			if (!GameGeneral.CustomIconCollection_Parent[DBID_Enum].ContainsKey(activeUnitType))
			{
				GameGeneral.CustomIconCollection_Parent[DBID_Enum].Add(activeUnitType, new GameGeneral.CustomIconWrapper(text3, result2, rotatable));
			}
		}
		else if (activeUnitType != GlobalVariables.ActiveUnitType.None && FileExistsNative.FileExistsFast(GameGeneral.CustomIconPath + text3) && !GameGeneral.CustomIconCollection[DBID_Enum][activeUnitType].ContainsKey(result))
		{
			GameGeneral.CustomIconCollection[DBID_Enum][activeUnitType].Add(result, new GameGeneral.CustomIconWrapper(text3, result2, rotatable));
		}
	}
}

using System;
using System.IO;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static void ParseCustomICons()
{
	//IL_0062: Unknown result type (might be due to invalid IL or missing references)
	GameGeneral.CustomIconCollection.Clear();
	GameGeneral.CustomIconCollection_Parent.Clear();
	try
	{
		if (!Directory.Exists(GameGeneral.CustomIconPath))
		{
			Directory.CreateDirectory(GameGeneral.CustomIconPath);
		}
		ParseCustomICons("Associations_DB3000.csv", 1);
		ParseCustomICons("Associations_CWDB.csv", 2);
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		DarkMessageBox.ShowError("Failed to load and parse custom icons. Please check that you are running Command as administrator." + ex2.Message, "Error");
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

private static void rbcuxpXdK()
{
	//IL_0169: Unknown result type (might be due to invalid IL or missing references)
	List<string> list = new List<string>();
	list.Add("Nahimic");
	list.Add("NvidiaShare");
	list.Add("RivaTuner");
	list.Add("Raptr");
	list.Add("MSIAfterburn");
	List<string> list2 = new List<string>();
	List<int> list3 = new List<int>();
	Process[] processes = Process.GetProcesses();
	foreach (Process process in processes)
	{
		foreach (string item in list)
		{
			if (process.ProcessName.Replace(" ", "").ToLowerInvariant().Contains(item.Replace(" ", "").ToLowerInvariant()))
			{
				if (!list2.Contains(process.ProcessName))
				{
					list2.Add(process.ProcessName);
				}
				list3.Add(process.Id);
			}
		}
	}
	if (list2.Count <= 0)
	{
		return;
	}
	string text = default(string);
	foreach (string item2 in list2)
	{
		text = text + " " + item2 + Environment.NewLine;
	}
	DarkMessageBox.ShowWarning("These processes are known to cause instability/performance/UI glitches when running alongside Command! It is recommended to close them (either through their own UI or through Task Manager) before continuing. " + Environment.NewLine + text, "Warning");
	try
	{
		GameGeneral.WriteExceptionsToLog(new Exception("WARNING: one or more program known for cause instability is running " + Environment.NewLine + text));
	}
	catch (Exception projectError)
	{
		ProjectData.SetProjectError(projectError);
		ProjectData.ClearProjectError();
	}
}

using System.Collections.Generic;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static DialogResult WarnAboutDeletedMissionDependencies(Mission theMission)
{
	//IL_001d: Unknown result type (might be due to invalid IL or missing references)
	//IL_0023: Invalid comparison between Unknown and I4
	//IL_0026: Unknown result type (might be due to invalid IL or missing references)
	//IL_00df: Unknown result type (might be due to invalid IL or missing references)
	//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
	//IL_009c: Unknown result type (might be due to invalid IL or missing references)
	//IL_00a2: Invalid comparison between Unknown and I4
	//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
	if ((theMission.CreationMode == MissionCreationType.LandingPlanner || theMission.CreationMode == MissionCreationType.Generated) && (int)DarkMessageBox.ShowWarning("WARNING ! Deleting a generated mission may break inter-mission relationships. Do you want to proceed ?", "Deletion may break relationships", DarkDialogButton.YesNo) == 7)
	{
		return (DialogResult)7;
	}
	foreach (Mission mission in side_0.Missions)
	{
		theMission = mission;
		foreach (KeyValuePair<Mission, Mission> item in theMission.MissionStartTrigger_MissionCompleted)
		{
			if (Operators.CompareString(item.Key.ObjectID, theMission.ObjectID, true) == 0 && (int)DarkMessageBox.ShowWarning("WARNING ! A mission depends on the mission you are about to delete, this will break the relationship and could prevent " + item.Value.Name + " to ever start! Do you want to proceed ?", "Deletion breaks a relationship", DarkDialogButton.YesNo) == 7)
			{
				return (DialogResult)7;
			}
		}
	}
	return (DialogResult)6;
}

using Command_Core;

private static void smethod_10(Scenario scenario_1)
{
	SetCurrentScenario(scenario_1, bool_10: false);
}

public static void SetAllowCoreUIMessages(bool allow)
{
	if (!allow && bool_4)
	{
		IgnoredCoreUIMessages = "";
	}
	bool_4 = allow;
}

using System;
using System.Runtime.CompilerServices;
using Command_Core;
using DarkUI.Forms;

private static void smethod_11(string string_1, string string_2, object object_0, GameGeneral.MessageBoxMessageType messageBoxMessageType_0)
{
	if (!bool_4)
	{
		IgnoredCoreUIMessages = IgnoredCoreUIMessages + string_1 + "\r\n";
	}
	else
	{
		if (object_0 != null && side_0 != null && object_0 != side_0)
		{
			return;
		}
		switch (messageBoxMessageType_0)
		{
		case GameGeneral.MessageBoxMessageType.Information:
			Dispatcher.InvokeAsync((Action)([SpecialName] () =>
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				DarkMessageBox.ShowInformation(string_1, string_2);
			}));
			break;
		case GameGeneral.MessageBoxMessageType.Warning:
			Dispatcher.InvokeAsync((Action)([SpecialName] () =>
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				DarkMessageBox.ShowWarning(string_1, string_2);
			}));
			break;
		case GameGeneral.MessageBoxMessageType.ErrorMessage:
			Dispatcher.InvokeAsync((Action)([SpecialName] () =>
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				DarkMessageBox.ShowError(string_1, string_2);
			}));
			break;
		}
	}
}

using System.Diagnostics;
using Command_Core;

private static void smethod_12(Game._GameStatus _GameStatus_0)
{
	switch (_GameStatus_0)
	{
	case Game._GameStatus.Paused:
		CurrentGame.Pause();
		return;
	case Game._GameStatus.Running:
		CurrentGame.Run();
		return;
	}
	if (Debugger.IsAttached)
	{
		Debugger.Break();
	}
}

using System;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_13()
{
	//IL_002b: Unknown result type (might be due to invalid IL or missing references)
	try
	{
		_ = scenario_0.Scenario_LuaSandbox;
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		DarkMessageBox.ShowError("Failed to load Lua! Error: " + ex2.Message, "Error");
		Startup.PerformShutdown();
		ProjectData.ClearProjectError();
	}
}

using System;
using Microsoft.VisualBasic.CompilerServices;

public static void ReleaseReferences()
{
	try
	{
		if (MapVisibleUnits != null)
		{
			MapVisibleUnits.Clear();
		}
		if (MapVisibleUnit_ScreenCoords != null)
		{
			MapVisibleUnit_ScreenCoords.Clear();
		}
		if (MapSelectableUnits != null)
		{
			MapSelectableUnits.Clear();
		}
		SelectedRefPoint = null;
		SelectedMountForArcDisplay = null;
		SelectedSalvoForPlotCourse = null;
		ZoneClipBoard = null;
		ClearMessageLog();
		referencePointManager_0?.ReleaseReferences();
	}
	catch (Exception projectError)
	{
		ProjectData.SetProjectError(projectError);
		ProjectData.ClearProjectError();
	}
}

// FAILED Command.Client.SetCurrentScenario (token 0x0600032a): ArgumentNullException: Value cannot be null. (Parameter 'methodReference')
using Command_Core;
using DarkUI.Forms;

public static bool PlayerWantsFullNetwork(Side theSide = null)
{
	//IL_0039: Unknown result type (might be due to invalid IL or missing references)
	//IL_003f: Invalid comparison between Unknown and I4
	bool result = false;
	if (!GlobalVariables.Headless)
	{
		string text = "";
		if (theSide != null)
		{
			text = " for Side " + theSide.Name;
		}
		if ((int)DarkMessageBox.ShowInformation("Do you want to run Full Comm Network generation" + text + "?", "Full network gneration", DarkDialogButton.YesNo) == 6)
		{
			result = true;
		}
		return result;
	}
	return true;
}

using System;
using System.Diagnostics;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_14(Scenario scenario_1)
{
	ActiveUnit[] array = scenario_1.ActiveUnits_List.InternalArray();
	int count = scenario_1.ActiveUnits_List.Count;
	if (count == 0)
	{
		return;
	}
	try
	{
		ActiveUnit activeUnit = null;
		for (int i = count - 1; i >= 0; i += -1)
		{
			activeUnit = array[i];
			if (activeUnit != null && activeUnit.ChanceOfAppearance != 0 && activeUnit.ChanceOfAppearance != 100 && GameGeneral.GlobalRNG.Next(0, 101) > activeUnit.ChanceOfAppearance)
			{
				scenario_1.DeleteUnitImmediately(activeUnit.ObjectID, ScenEditAction: true, "Chance of appearance failed", null, RegisterAsLosses: false);
			}
		}
	}
	catch (Exception projectError)
	{
		ProjectData.SetProjectError(projectError);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static void ValidateScenarioAreas(Scenario theScen, bool UseSBR, ref string ReturnStringSBR)
{
	//IL_0075: Unknown result type (might be due to invalid IL or missing references)
	//IL_007b: Invalid comparison between Unknown and I4
	//IL_0440: Unknown result type (might be due to invalid IL or missing references)
	//IL_0446: Invalid comparison between Unknown and I4
	//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
	//IL_03e7: Invalid comparison between Unknown and I4
	//IL_0130: Unknown result type (might be due to invalid IL or missing references)
	//IL_0136: Invalid comparison between Unknown and I4
	//IL_0514: Unknown result type (might be due to invalid IL or missing references)
	//IL_051a: Invalid comparison between Unknown and I4
	//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
	//IL_01db: Invalid comparison between Unknown and I4
	//IL_026a: Unknown result type (might be due to invalid IL or missing references)
	//IL_0270: Invalid comparison between Unknown and I4
	//IL_0300: Unknown result type (might be due to invalid IL or missing references)
	//IL_0306: Invalid comparison between Unknown and I4
	try
	{
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				string UserFeedback = "";
				if (ActiveUnit_Navigator.ValidateArea(noNavZone.Area, ref UserFeedback, side, theScen, "No-Navigation Zone '" + noNavZone.Description + "'"))
				{
					continue;
				}
				if (!UseSBR)
				{
					if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback + " Contact the scenario designer", "Warning") == 2)
					{
						SkipOtherAreaValidationMessages = true;
					}
				}
				else
				{
					ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback + "\r\n";
				}
			}
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				string UserFeedback2 = "";
				if (!ActiveUnit_Navigator.ValidateArea(exclusionZone.Area, ref UserFeedback2, side, theScen, "Exclusion Zone '" + exclusionZone.Description + "'"))
				{
					if (UseSBR)
					{
						ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback2 + "\r\n";
					}
					else if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback2 + " Contact the scenario designer", "Warning") == 2)
					{
						SkipOtherAreaValidationMessages = true;
					}
				}
			}
			foreach (Mission mission in side.Missions)
			{
				string UserFeedback3 = "";
				if (mission.MissionClass == Mission._MissionClass.Patrol)
				{
					if (ActiveUnit_Navigator.ValidateArea(((Patrol)mission).PatrolArea, ref UserFeedback3, side, theScen, "patrol mission '" + mission.Name + "'"))
					{
						continue;
					}
					if (!UseSBR)
					{
						if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback3 + " Contact the scenario designer", "Warning") == 2)
						{
							SkipOtherAreaValidationMessages = true;
						}
					}
					else
					{
						ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback3 + "\r\n";
					}
				}
				else
				{
					if (mission.MissionClass == Mission._MissionClass.Support)
					{
						continue;
					}
					if (mission.MissionClass == Mission._MissionClass.Mining)
					{
						if (ActiveUnit_Navigator.ValidateArea(((MiningMission)mission).Area, ref UserFeedback3, side, theScen, "mining mission '" + mission.Name + "'"))
						{
							continue;
						}
						if (!UseSBR)
						{
							if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback3 + " Contact the scenario designer", "Warning") == 2)
							{
								SkipOtherAreaValidationMessages = true;
							}
						}
						else
						{
							ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback3 + "\r\n";
						}
					}
					else if (mission.MissionClass == Mission._MissionClass.MineClearing && !ActiveUnit_Navigator.ValidateArea(((MineClearingMission)mission).Area, ref UserFeedback3, side, theScen, "mine clearing mission '" + mission.Name + "'"))
					{
						if (UseSBR)
						{
							ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback3 + "\r\n";
						}
						else if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback3 + " Contact the scenario designer", "Warning") == 2)
						{
							SkipOtherAreaValidationMessages = true;
						}
					}
				}
			}
		}
		foreach (EventTrigger value in theScen.EventTriggers.Values)
		{
			switch (value.Type)
			{
			case EventTrigger.EventTriggerType.UnitEntersArea:
			{
				string UserFeedback5 = "";
				if (!ActiveUnit_Navigator.ValidateArea(((EventTrigger_UnitEntersArea)value).Area, ref UserFeedback5, null, theScen, "Unit Remains In Area trigger '" + value.Description + "'"))
				{
					if (UseSBR)
					{
						ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback5 + "\r\n";
					}
					else if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback5 + " Contact the scenario designer", "Warning") == 2)
					{
						SkipOtherAreaValidationMessages = true;
					}
				}
				break;
			}
			case EventTrigger.EventTriggerType.UnitRemainsInArea:
			{
				string UserFeedback4 = "";
				if (ActiveUnit_Navigator.ValidateArea(((EventTrigger_UnitRemainsInArea)value).Area, ref UserFeedback4, null, theScen, "Unit Remains In Area trigger '" + value.Description + "'"))
				{
					break;
				}
				if (!UseSBR)
				{
					if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback4 + " Contact the scenario designer", "Warning") == 2)
					{
						SkipOtherAreaValidationMessages = true;
					}
				}
				else
				{
					ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback4 + "\r\n";
				}
				break;
			}
			}
		}
		foreach (EventAction value2 in theScen.EventActions.Values)
		{
			EventAction.EventActionType type = value2.Type;
			if (type != EventAction.EventActionType.TeleportInArea)
			{
				continue;
			}
			string UserFeedback6 = "";
			if (!ActiveUnit_Navigator.ValidateArea(((EventAction_TeleportInArea)value2).Area, ref UserFeedback6, null, theScen, "Teleport In Area action '" + value2.Description + "'"))
			{
				if (UseSBR)
				{
					ReturnStringSBR = ReturnStringSBR + "    " + UserFeedback6 + "\r\n";
				}
				else if (!SkipOtherAreaValidationMessages && (int)DarkMessageBox.ShowWarningWithSkip(UserFeedback6 + " Contact the scenario designer", "Warning") == 2)
				{
					SkipOtherAreaValidationMessages = true;
				}
			}
		}
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 101269", "");
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

private static void smethod_15()
{
}

public static void ForceReFetchOfSelectedUnit()
{
	unit_1 = null;
}

using System.Collections.Generic;
using Command_Core;
using DarkUI.Forms;

public static void AssignToMission(object sender, IEnumerable<ActiveUnit> theSelectedUnits, ref Mission theMission, ref bool isEscort)
{
	//IL_0024: Unknown result type (might be due to invalid IL or missing references)
	if (!Realtime)
	{
		string text = CoreClientCode.AssignUnitToMission_Core(theSelectedUnits, scenario_0, ref theMission, ref isEscort);
		if (!string.IsNullOrEmpty(text))
		{
			DarkMessageBox.ShowWarning(text, "Mission Assignment");
		}
		theMission.TimeSincePlayerNotification = 0;
		MustRefreshMainForm = true;
	}
	else if (!isEscort)
	{
		RealtimeTerminal.SendAssignToMission(theSelectedUnits, theMission, 0);
	}
	else
	{
		RealtimeTerminal.SendAssignToMission(theSelectedUnits, theMission, 6);
	}
}

using System.Collections.Generic;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void SelectMultipleUnits(List<Module_Unit.Unit> Units)
{
	if (Units.Count == 0 || side_0 == null)
	{
		return;
	}
	if (Units.Count == 1)
	{
		SelectThisUnit(Units[Units.Count - 1], ThisUnitOnly: true);
		return;
	}
	side_0.SelectedUnits_Clear(WillRaiseEvent: false);
	foreach (Module_Unit.Unit Unit in Units)
	{
		side_0.SelectedUnits_Add(Unit, WillRaiseEvent: false);
	}
	side_0.RaiseSelectedUnitsChanged();
	smethod_16(bool_10: true, Units[0]);
	if (!Units[0].IsGroup && !Information.IsNothing((object)Units[0].get_UnitSide(SetSideOnly: false)))
	{
		if (Units[0].get_UnitSide(SetSideOnly: false) == side_0 && Units[0].IsActiveUnit)
		{
			ActiveUnit theSelectedUnit = (ActiveUnit)Units[0];
			if (((Control)theSensorsWindow).Visible)
			{
				theSensorsWindow.BuildForm();
			}
			if (((Control)theWeaponsWindow).Visible)
			{
				theWeaponsWindow.theSelectedUnit = theSelectedUnit;
				theWeaponsWindow.BuildForm();
			}
			if (((Control)theCommsWindow).Visible)
			{
				theCommsWindow.BuildForm();
			}
		}
		else
		{
			if (((Control)theSensorsWindow).Visible)
			{
				((Control)theSensorsWindow).Visible = false;
			}
			if (((Control)theWeaponsWindow).Visible)
			{
				((Control)theWeaponsWindow).Visible = false;
			}
			if (((Control)theCommsWindow).Visible)
			{
				((Control)theCommsWindow).Visible = false;
			}
		}
	}
	int mustRefreshMainForm;
	if (SelectedUnit.get_UnitSide(SetSideOnly: false) == side_0)
	{
		Side theSide = side_0;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string ReasonWhyNot = null;
		if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
		{
			if (!SelectedUnit.IsActiveUnit)
			{
				mustRefreshMainForm = 1;
			}
			else
			{
				MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
				MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
				MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
				MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
				MyProject.Forms.SpeedAlt.LoadForm();
				mustRefreshMainForm = 1;
			}
			goto IL_021a;
		}
	}
	mustRefreshMainForm = 1;
	goto IL_021a;
	IL_021a:
	MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
}

using Command_Core;
using Command.My;

public static void SelectThisUnitAndCenterMap(Module_Unit.Unit theUnit)
{
	SelectThisUnit(theUnit, ThisUnitOnly: true);
	MyProject.Forms.MainForm.set_MapCenter(MustRender: true, theUnit.Location.ToGeoPoint());
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

public static void SelectThisUnit(Module_Unit.Unit theUnit, bool ThisUnitOnly, bool clearWaypointSelection = true)
{
	try
	{
		if (side_0 == null)
		{
			return;
		}
		if (theUnit == null)
		{
			foreach (Module_Unit.Unit selectedUnit2 in side_0.SelectedUnits)
			{
				if (selectedUnit2.IsActiveUnit)
				{
					ActiveUnit activeUnit = (ActiveUnit)selectedUnit2;
					if (activeUnit.Navigator.HasPlottedCourse() && activeUnit.Navigator.PlottedCourse.Contains(waypoint_0))
					{
						return;
					}
				}
				if (selectedUnit2.IsActiveUnit)
				{
					ActiveUnit activeUnit2 = (ActiveUnit)selectedUnit2;
					if (activeUnit2.Navigator.HasFlightPlan && activeUnit2.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Contains(waypoint_0))
					{
						return;
					}
				}
			}
		}
		if (theUnit != null && theUnit.get_UnitSide(SetSideOnly: false) != null && GameGeneral.Beta_PlatformComms && scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticOrderChain) && !CurrentGame.IsScenEditGameMode && !CurrentMapProfile.GodsEye && theUnit.IsActiveUnit && !((ActiveUnit)theUnit).CommStuff.CheckIfUnitIsInContactWithHQ(theUnit.get_UnitSide(SetSideOnly: false), theUnit))
		{
			Notification_Bark.Create(theUnit.Location, "Not in communication with HQ", Color.Red, MoveUpward: true, Fades: true, 4f, 20f);
			return;
		}
		if (ThisUnitOnly)
		{
			side_0.SelectedUnits_Clear();
		}
		if (theUnit != null)
		{
			side_0.SelectedUnits_Add(theUnit);
		}
		if (Realtime && theUnit != SelectedUnit)
		{
			RealtimeTerminal.SendSelectionChange(theUnit, null);
			MyProject.Forms.MainForm.Realtime_UI_Tick();
		}
		int mustRefreshMainForm;
		checked
		{
			if (ThisUnitOnly)
			{
				smethod_16(ThisUnitOnly, theUnit);
				if (waypoint_0 != null && theUnit != null && theUnit.IsActiveUnit)
				{
					ActiveUnit activeUnit3 = (ActiveUnit)theUnit;
					Waypoint[] plottedCourse = activeUnit3.Navigator.PlottedCourse;
					for (int i = 0; i < plottedCourse.Length; i++)
					{
						if (plottedCourse[i] == waypoint_0)
						{
							clearWaypointSelection = false;
							break;
						}
					}
					if (clearWaypointSelection & activeUnit3.Navigator.HasFlightPlan)
					{
						Waypoint[] flightPlan = activeUnit3.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
						for (int j = 0; j < flightPlan.Length; j++)
						{
							if (flightPlan[j] == waypoint_0)
							{
								clearWaypointSelection = false;
								break;
							}
						}
					}
				}
				if (clearWaypointSelection)
				{
					SelectedWaypoint = null;
				}
			}
			if (theUnit == null)
			{
				if (!((Control)MyProject.Forms.SpeedAlt).Visible)
				{
					goto IL_0532;
				}
				((Control)MyProject.Forms.SpeedAlt).Hide();
				mustRefreshMainForm = 1;
			}
			else
			{
				if (!theUnit.IsGroup && theUnit.get_UnitSide(SetSideOnly: false) != null)
				{
					if (theUnit.get_UnitSide(SetSideOnly: false) == side_0 && theUnit.IsActiveUnit)
					{
						ActiveUnit theSelectedUnit = (ActiveUnit)theUnit;
						if (((Control)theSensorsWindow).Visible)
						{
							theSensorsWindow.BuildForm();
						}
						if (((Control)theWeaponsWindow).Visible)
						{
							theWeaponsWindow.theSelectedUnit = theSelectedUnit;
							theWeaponsWindow.BuildForm();
						}
						if (((Control)theCommsWindow).Visible)
						{
							theCommsWindow.theSelectedUnit = theSelectedUnit;
							theCommsWindow.BuildForm();
						}
					}
					else
					{
						if (((Control)theSensorsWindow).Visible)
						{
							((Control)theSensorsWindow).Visible = false;
						}
						if (((Control)theWeaponsWindow).Visible)
						{
							((Control)theWeaponsWindow).Visible = false;
						}
						if (((Control)theCommsWindow).Visible)
						{
							((Control)theCommsWindow).Visible = false;
						}
					}
				}
				if (SelectedUnit != null && SelectedUnit.get_UnitSide(SetSideOnly: false) == side_0)
				{
					Side theSide = side_0;
					Module_Unit.Unit selectedUnit = SelectedUnit;
					string ReasonWhyNot = null;
					if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
					{
						if (!SelectedUnit.IsActiveUnit)
						{
							mustRefreshMainForm = 1;
						}
						else
						{
							MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
							MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
							MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
							MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
							MyProject.Forms.SpeedAlt.LoadForm();
							mustRefreshMainForm = 1;
						}
						goto IL_0533;
					}
				}
				bool? flag2;
				bool? flag = (flag2 = ((SelectedUnit == null) ? new bool?(false) : SelectedUnit?.IsActiveUnit));
				bool? flag3;
				flag2 = (flag3 = ((flag.HasValue && flag2 != true) ? new bool?(false) : ((((ActiveUnit)SelectedUnit).UnitType == GlobalVariables.ActiveUnitType.Submarine) & flag2)));
				bool? flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : (((ActiveUnit)SelectedUnit).CommStuff.IsConnectedToSideNetwork ? new bool?(false) : flag3));
				if ((!flag4) ?? false)
				{
					mustRefreshMainForm = 1;
				}
				else
				{
					if (!side_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms) || !flag4.HasValue)
					{
						goto IL_0532;
					}
					MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
					MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
					MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
					MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
					MyProject.Forms.SpeedAlt.LoadForm();
					mustRefreshMainForm = 1;
				}
			}
			goto IL_0533;
		}
		IL_0532:
		mustRefreshMainForm = 1;
		goto IL_0533;
		IL_0533:
		MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 200587", ex2.Message);
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Command.Tacview;
using Microsoft.VisualBasic.CompilerServices;

[SpecialName]
private static void smethod_16(bool bool_10 = true, Module_Unit.Unit unit_2)
{
	Module_Unit.Unit selectedUnit = SelectedUnit;
	bool flag;
	int num;
	if (unit_2 != null)
	{
		if (selectedUnit != null)
		{
			flag = (object)selectedUnit.ObjectID != unit_2.ObjectID;
			goto IL_0025;
		}
		num = 1;
	}
	else
	{
		num = 1;
	}
	flag = (byte)num != 0;
	goto IL_0025;
	IL_0025:
	if (flag)
	{
		selectedUnitPreChangeEventHandler_0?.Invoke();
	}
	Module_Unit.Unit previousUnit = selectedUnit;
	if (unit_2 != null)
	{
		string_0 = unit_2.ObjectID;
	}
	if (flag)
	{
		selectedUnitChangedEventHandler_0?.Invoke(unit_2);
		if (GameGeneral.TacviewPipeEnabled && unit_2 != null)
		{
			TacviewServer.FocusCameraOnSelectedUnit();
		}
	}
	if (bool_10 && flag && bool_3)
	{
		try
		{
			MyProject.Forms.MainForm.RightColumn1.AdjustToSelectionChange(unit_2, previousUnit);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
	if (unit_2 != null && flag)
	{
		if (((Control)MyProject.Forms.InternalDBViewer).Visible)
		{
			if (SelectedUnit == null)
			{
				return;
			}
			ActiveUnit activeUnit = default(ActiveUnit);
			if (SelectedUnit.IsActiveUnit)
			{
				activeUnit = (ActiveUnit)SelectedUnit;
			}
			if (SelectedUnit.IsContact() && ((Contact)SelectedUnit).IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
			{
				activeUnit = ((Contact)SelectedUnit).ActualUnit;
			}
			if (SelectedUnit.IsGroup && ((Group)SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				activeUnit = ((Group)SelectedUnit).Units.Values.ElementAtOrDefault(0);
			}
			if (activeUnit != null)
			{
				smethod_18(activeUnit);
			}
		}
		if (!ExkSdJeRkI)
		{
			MyProject.Forms.MainForm.Slide_RC_In();
			ExkSdJeRkI = true;
		}
	}
	if (unit_2 == null)
	{
		string_0 = null;
	}
	Side theSide = side_0;
	Module_Unit.Unit selectedUnit2 = SelectedUnit;
	string ReasonWhyNot = null;
	int mustRefreshMainForm;
	if (!GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit2, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
	{
		smethod_33();
		mustRefreshMainForm = 1;
	}
	else
	{
		smethod_32();
		mustRefreshMainForm = 1;
	}
	MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
}

public static void smethod_17(string SelectedObjectType, int selectedObjectID, string HighlightTarget = null)
{
	DBViewer.OpenNewDatabaseWindow(SelectedObjectType, selectedObjectID, HighlightTarget);
}

using Command_Core;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

public static void smethod_18(ActiveUnit theAU, string HighlightTarget = null)
{
	string text = "";
	if (Information.IsNothing((object)theAU) || theAU.IsGroup)
	{
		return;
	}
	if (!theAU.IsAircraft)
	{
		if (theAU.IsShip)
		{
			text = "Ship";
		}
		else if (theAU.IsSubmarine)
		{
			text = "Submarine";
		}
		else if (theAU.IsFacility)
		{
			text = "Facility";
		}
		else if (theAU.IsMobileGroundUnit)
		{
			text = "Ground Unit";
		}
		else if (!theAU.IsSatellite)
		{
			if (theAU.IsWeapon)
			{
				text = "Weapon";
			}
		}
		else
		{
			text = "Satellite";
		}
	}
	else
	{
		text = "Aircraft";
	}
	InternalDBViewer lastOpenedDBViewer = GlobalSingleton.GetInstance().GetLastOpenedDBViewer();
	if (lastOpenedDBViewer != null && !((Computer)MyProject.Computer).Keyboard.CtrlKeyDown)
	{
		lastOpenedDBViewer.HighlightTarget = HighlightTarget;
		lastOpenedDBViewer.DisplayDataBaseEntry(theAU.DBID, text);
	}
	else
	{
		DBViewer.OpenNewDatabaseWindow(text, theAU.DBID, HighlightTarget);
	}
}

private static void smethod_19(object object_0)
{
	if (scenario_0 == object_0 && scenario_0.Sides_ReadOnly.Length > 0)
	{
		bool_2 = true;
	}
}

public static void ShutdownCleanup()
{
}

private static void smethod_20(object object_0)
{
	bool_8 = true;
}

using System.Runtime.CompilerServices;
using System.Threading;

[SpecialName]
[CompilerGenerated]
private static Timer smethod_21()
{
	return timer_2;
}

using System.Runtime.CompilerServices;
using System.Threading;

[SpecialName]
[CompilerGenerated]
private static void smethod_22(Timer timer_3)
{
	timer_2 = timer_3;
}

using System;
using System.Diagnostics;
using Command_Core;

public static void CoreSimulation_Main()
{
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	long num = 0L;
	long num2 = 0L;
	long num3 = 0L;
	long num4 = 0L;
	Scenario scenario = null;
	bool flag = false;
	Scenario.enumTimeCompression enumTimeCompression = Scenario.enumTimeCompression.OneSec;
	while (true)
	{
		LuaDispatcher.ProcessLuaQueue();
		if (scenario_0?._GameContext == null)
		{
			continue;
		}
		if (bool_8)
		{
			lock (lockObject_0)
			{
				bool_8 = false;
				smethod_35();
			}
		}
		if (scenario != scenario_0)
		{
			scenario = scenario_0;
			flag = true;
		}
		num = (int)Math.Round(scenario_0.GameResolution * 1000f);
		byte? b = (byte?)scenario_0?._GameContext?.Status;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
		{
			flag = true;
			continue;
		}
		if (scenario_0 != null && scenario_0.TimeCompression != enumTimeCompression)
		{
			enumTimeCompression = scenario_0.TimeCompression;
			flag = true;
		}
		if (Debugger.IsAttached && stopwatch.ElapsedMilliseconds > 5000L)
		{
			flag = true;
		}
		stopwatch.Restart();
		Run1Turn();
		smethod_36();
		if (GameGeneral.Beta_FlameSimSpeedTimeSync || scenario_0.TimeCompression < Scenario.enumTimeCompression.Coarse_OneSecSlice)
		{
			if (flag)
			{
				num = (int)Math.Round(scenario_0.GameResolution * 1000f);
				num2 = 0L;
				num3 = 0L;
				num4 = 0L;
				flag = false;
			}
			num2 += num;
			while (stopwatch.ElapsedMilliseconds < num + num4)
			{
			}
			stopwatch.Stop();
			num3 += stopwatch.ElapsedMilliseconds;
			num4 = num2 - num3;
		}
	}
}

using Command.My;
using Microsoft.VisualBasic;

private static void smethod_23(object object_0)
{
	int mustRefreshMainForm;
	if (!Information.IsNothing(object_0))
	{
		MyProject.Forms.MainForm.DBMenu_Build();
		mustRefreshMainForm = 1;
	}
	else
	{
		mustRefreshMainForm = 1;
	}
	MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Command_Core;
using Command.My;

public static void CacheMapUnitSymbols()
{
	//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
	//IL_00bf: Expected O, but got Unknown
	//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
	//IL_00c6: Expected O, but got Unknown
	//IL_0163: Unknown result type (might be due to invalid IL or missing references)
	//IL_016d: Expected O, but got Unknown
	Cache_RotatedImages.Clear();
	Cache_GhostedBitmaps.Clear();
	Cache_ScaledBitmaps.Clear();
	Dictionary<string, Bitmap> dictionary = new Dictionary<string, Bitmap>();
	string text = "";
	switch (SimConfiguration.DefaultGamePreferences.MapSymbolsSet)
	{
	default:
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		break;
	case Game.GamePreferences.MapSymbolsSetting.NTDS:
		text = "NTDS";
		break;
	case Game.GamePreferences.MapSymbolsSetting.Stylized:
		text = "Stylized";
		break;
	case Game.GamePreferences.MapSymbolsSetting.Directional:
		text = "Directional";
		break;
	case Game.GamePreferences.MapSymbolsSetting.APP6:
		text = "APP6";
		break;
	}
	string[] files = Directory.GetFiles(GlobalVariables.ApplicationStartupPath + "\\Symbols\\" + text);
	foreach (string text2 in files)
	{
		if (text2.EndsWith(".png") | text2.EndsWith(".gif"))
		{
			Bitmap val = new Bitmap(text2);
			Bitmap val2 = new Bitmap((Image)(object)val);
			Bitmap value = val2.Clone(new Rectangle(0, 0, ((Image)val2).Width, ((Image)val2).Height), (PixelFormat)2498570);
			dictionary.Add(Path.GetFileName(text2), value);
		}
	}
	if (SimConfiguration.DefaultGamePreferences.MapSymbolsSet == Game.GamePreferences.MapSymbolsSetting.Directional)
	{
		string[] files2 = Directory.GetFiles(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Stylized");
		foreach (string text3 in files2)
		{
			if ((text3.EndsWith(".png") | text3.EndsWith(".gif")) && !dictionary.ContainsKey(Path.GetFileName(text3)))
			{
				bitmap_0 = (Bitmap)Image.FromFile(text3);
				dictionary.Add(Path.GetFileName(text3), bitmap_0);
			}
		}
	}
	MapSymbolBitmaps = dictionary;
	MyProject.Forms.MainForm.theBM_HostedUnits = dictionary["hosted_units.png"];
}

using System;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_24(object object_0)
{
	if (object_0 != scenario_0)
	{
		return;
	}
	CurrentSide = scenario_0.GetCurrentSide();
	if (side_0 != null)
	{
		try
		{
			((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Switched side to: " + side_0.Name;
			MyProject.Forms.MainForm.MessageLogOuterControl1.VM.HandleCurrentSideChanged();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		MustRefreshMainForm = true;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;

private static void smethod_25(Scenario scenario_1)
{
	if (Thread.CurrentThread.ManagedThreadId != Dispatcher.Thread.ManagedThreadId)
	{
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			smethod_24(scenario_1);
		}));
	}
	else
	{
		smethod_24(scenario_1);
	}
}

using System.Linq;
using Command_Core;

private static void smethod_26(object object_0, Scenario.SideAdditionOrRemoval sideAdditionOrRemoval_0)
{
	if (object_0 != scenario_0)
	{
		return;
	}
	if (sideAdditionOrRemoval_0 == Scenario.SideAdditionOrRemoval.Removal && !scenario_0.Sides_ReadOnly.Contains(side_0))
	{
		if (scenario_0.Sides_ReadOnly.Length <= 0)
		{
			scenario_0.SetCurrentSide(null);
		}
		else
		{
			scenario_0.SetCurrentSide(scenario_0.Sides_ReadOnly[0]);
		}
	}
	Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
	if (sides_ReadOnly != null && sides_ReadOnly.Length == 1)
	{
		scenario_0.SetCurrentSide(scenario_0.Sides_ReadOnly[0]);
	}
}

using System.Collections.Generic;
using System.Windows.Forms;
using Command_Core;

public static void AdjustForUnitSelectionChanges()
{
	if (side_0 == null || scenario_0 == null || side_0.SelectedUnits == null)
	{
		return;
	}
	if (!side_0.SelectedUnits.Contains(SelectedUnit))
	{
		SelectThisUnit(null, ThisUnitOnly: true);
	}
	List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		if (selectedUnit.IsActiveUnit && (((ActiveUnit)selectedUnit).IsMorituri || !((ActiveUnit)selectedUnit).IsOperating()))
		{
			list.Add(selectedUnit);
		}
	}
	foreach (Module_Unit.Unit item in list)
	{
		side_0.SelectedUnits_Remove(item);
	}
	if (SelectedUnit != null)
	{
		if ((object)SelectedUnit.GetType() == typeof(Contact))
		{
			if (!scenario_0.ActiveUnits.Values.Contains(((Contact)SelectedUnit).ActualUnit))
			{
				SelectThisUnit(null, ThisUnitOnly: true);
			}
		}
		else if (!scenario_0.ActiveUnits.ContainsKey(SelectedUnit.ObjectID))
		{
			SelectThisUnit(null, ThisUnitOnly: true);
		}
	}
	if (side_0.SelectedUnits.Count == 0)
	{
		SelectThisUnit(null, ThisUnitOnly: true);
	}
	else
	{
		SelectThisUnit(side_0.SelectedUnits[side_0.SelectedUnits.Count - 1], ThisUnitOnly: true);
	}
	if (SelectedUnit == null && ((Control)theWeaponsWindow).Visible)
	{
		((Control)theWeaponsWindow).Hide();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_27(PlatformComponent platformComponent_0)
{
	_Closure$__320-0 arg = default(_Closure$__320-0);
	_Closure$__320-0 CS$<>8__locals10 = new _Closure$__320-0(arg);
	CS$<>8__locals10.$VB$Local_theComponent = platformComponent_0;
	Type type = CS$<>8__locals10.$VB$Local_theComponent.GetType();
	if (type == typeof(Sensor))
	{
		if (unitSensors_0 == null || !bool_5)
		{
			return;
		}
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			if (!Realtime)
			{
				if (((Sensor)CS$<>8__locals10.$VB$Local_theComponent).ParentPlatform == SelectedUnit)
				{
					theSensorsWindow.Timer_Refresh.Start();
				}
				else if (CS$<>8__locals10.$VB$Local_theComponent.ParentPlatform != null && CS$<>8__locals10.$VB$Local_theComponent.ParentPlatform.IsWeapon)
				{
					Module_Unit.Unit selectedUnit = SelectedUnit;
					if (selectedUnit != null && selectedUnit.IsActiveUnit)
					{
						using (IEnumerator<Sensor> enumerator = ((ActiveUnit)SelectedUnit).Sensors_Cached.Where((CS$<>8__locals10.$I1 != null) ? CS$<>8__locals10.$I1 : (CS$<>8__locals10.$I1 = [SpecialName] (Sensor theSensor) => Operators.CompareString(theSensor.ObjectID, CS$<>8__locals10.$VB$Local_theComponent.ObjectID, true) == 0)).GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								_ = enumerator.Current;
								theSensorsWindow.Timer_Refresh.Start();
							}
						}
					}
				}
			}
		}));
	}
	else
	{
		if (!(type == typeof(CommDevice)) || unitComms_0 == null || !bool_6 || ((CommDevice)CS$<>8__locals10.$VB$Local_theComponent).ParentPlatform != SelectedUnit)
		{
			return;
		}
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			if (((Control)theCommsWindow).Visible)
			{
				theCommsWindow.Timer_Refresh.Start();
			}
		}));
	}
}

using System.Windows.Forms;

private static void smethod_28(object object_0)
{
	if (object_0 == SelectedUnit && ((Control)theSensorsWindow).Visible)
	{
		theSensorsWindow.Timer_Refresh.Start();
	}
}

using System.Windows.Forms;
using Command_Core;
using Command.My;

public static void AddSide(string SideName, ref Scenario theScen)
{
	Side side = new Side(SideName, ref theScen);
	scenario_0.AddSide(side);
	if (scenario_0.Sides_ReadOnly.Length == 1)
	{
		CurrentSide = side;
	}
	if (((Control)MyProject.Forms.Sides).Visible)
	{
		MyProject.Forms.Sides.RefreshForm();
	}
}

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Command_Core;
using Command_Core.LoadSave;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

public static void SaveCurrentScenario(bool SBR, string CustomFileName = "", bool MarkAsCampaignCheckpoint = false)
{
	bool flag;
	if (flag = CurrentGame.Status == Game._GameStatus.Running)
	{
		CurrentGame.Pause();
	}
	scenario_0.DBUsed = dbrecord_0.Hash;
	scenario_0.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
	int num = 0;
	do
	{
		try
		{
			if (!GameGeneral.PE_SaveAsXML)
			{
				if (!string.IsNullOrEmpty(CustomFileName))
				{
					LoadSave.SaveScenario(scenario_0, side_0, CustomFileName, SBR, MarkAsCampaignCheckpoint);
				}
				else
				{
					LoadSave.SaveScenario(scenario_0, side_0, ((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName, SBR, MarkAsCampaignCheckpoint);
				}
				break;
			}
			MemoryStream scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
			using (scenarioClone)
			{
				if (!string.IsNullOrEmpty(CustomFileName))
				{
					LoadSave.SaveScenario_XML(CustomFileName, scenarioClone);
				}
				else
				{
					LoadSave.SaveScenario_XML(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName, scenarioClone);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200360", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			goto IL_0123;
		}
		break;
		IL_0123:
		num++;
	}
	while (num <= 4);
	if (flag)
	{
		CurrentGame.Run();
	}
	((Control)MyProject.Forms.MainForm).Enabled = true;
	CurrentUserAction = UserAction.None;
}

using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void CreateNewScenario()
{
	SetCurrentScenario(new Scenario(dbrecord_0.Hash), bool_10: false);
	MyProject.Forms.MainForm?.MessageLogControlViewModel?.ResetLog();
	scenario_0.set_Time(ManualChange: false, DateAndTime.Now.ToUniversalTime());
	scenario_0.GameResolution = 1f;
	scenario_0.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
	scenario_0.LastSavedInScenEdit = true;
	scenario_0.FileName = null;
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
	ScenarioWasLoadedAsBlank = true;
	SaveScenarioPath = null;
	CurrentSide = null;
	MustRefreshMainForm = true;
}

using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void CreateNewScenario(string string_1)
{
	SetCurrentScenario(new Scenario(string_1), bool_10: false);
	MyProject.Forms.MainForm?.MessageLogControlViewModel?.ResetLog();
	scenario_0.set_Time(ManualChange: false, DateAndTime.Now.ToUniversalTime());
	scenario_0.GameResolution = 1f;
	scenario_0.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
	scenario_0.LastSavedInScenEdit = true;
	scenario_0.FileName = null;
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
	scenario_0.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
	ScenarioWasLoadedAsBlank = true;
	SaveScenarioPath = null;
	CurrentSide = null;
	MustRefreshMainForm = true;
}

using System.Diagnostics;
using Command_Core;

public static bool CanSeeThisUnitsPositionAndHeading(ActiveUnit theAU)
{
	if (theAU == null)
	{
		int result;
		if (!Debugger.IsAttached)
		{
			result = 0;
		}
		else
		{
			Debugger.Break();
			result = 0;
		}
		return (byte)result != 0;
	}
	if (side_0.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient)
	{
		return true;
	}
	return CanSeeAllPrivateInformationOnThisUnit(theAU);
}

using System.Diagnostics;
using Command_Core;

public static bool CanSeeAllPrivateInformationOnThisUnit(ActiveUnit theAU)
{
	if (theAU == null)
	{
		int result;
		if (!Debugger.IsAttached)
		{
			result = 0;
		}
		else
		{
			Debugger.Break();
			result = 0;
		}
		return (byte)result != 0;
	}
	int result2;
	if (!CurrentMapProfile.GodsEye)
	{
		if (theAU.IsWeapon)
		{
			Weapon weapon = (Weapon)theAU;
			if (weapon.DataLinkParent != null && CanSeeAllPrivateInformationOnThisUnit(weapon.DataLinkParent))
			{
				return true;
			}
		}
		if (theAU.get_UnitSide(SetSideOnly: false) == null)
		{
			result2 = 0;
		}
		else
		{
			if (string.IsNullOrEmpty(CurrentMapProfile.IsolatedPOVObjectID))
			{
				if ((theAU.get_UnitSide(SetSideOnly: false) == side_0 || theAU.get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(side_0, (Scenario)null) == Misc.PostureStance.Friendly) && theAU.CommStuff.IsConnectedToSideNetwork)
				{
					return true;
				}
			}
			else if (theAU.get_UnitSide(SetSideOnly: false) == side_0)
			{
				if (Module1.IsSelectedForIsolatedPOV(theAU))
				{
					return true;
				}
				result2 = 0;
				goto IL_00bf;
			}
			result2 = 0;
		}
		goto IL_00bf;
	}
	return true;
	IL_00bf:
	return (byte)result2 != 0;
}

using Command_Core;

private static bool smethod_29()
{
	IEventExporter[] eventExporters_Interactive = Exporter_General.EventExporters_Interactive;
	int num = 0;
	while (true)
	{
		if (num < eventExporters_Interactive.Length)
		{
			IEventExporter eventExporter = eventExporters_Interactive[num];
			if (eventExporter.UsesRAMQueue && eventExporter.QueueLength > 1000000)
			{
				break;
			}
			num = checked(num + 1);
			continue;
		}
		return false;
	}
	return true;
}

using System;
using System.Diagnostics;
using System.Threading;
using Command_Core;
using Command.Tacview;
using Microsoft.VisualBasic.CompilerServices;

public static void Run1Turn()
{
	try
	{
		Diagnostic_AUCount = scenario_0.ActiveUnits_List.Count;
		Diagnostic_PathFinderQueue = Pathfinding.PathfindRequestCount();
		Diagnostic_PathFinderUnit = Pathfinding.PathfindRequestCurrentUnit();
		if (ScenarioWasLoadedAsBlank)
		{
			ScenarioWasLoadedAsBlank = false;
			return;
		}
		int timeCompression_SimSeconds = scenario_0.TimeCompression_SimSeconds;
		for (int i = 1; i <= timeCompression_SimSeconds; i++)
		{
			if (RunToThisTime.HasValue)
			{
				DateTime time = scenario_0.Time;
				DateTime? runToThisTime = RunToThisTime;
				if ((runToThisTime.HasValue ? new bool?(DateTime.Compare(time, runToThisTime.GetValueOrDefault()) >= 0) : ((bool?)null)) == true)
				{
					RunToThisTime = null;
					CurrentGame.Pause();
					break;
				}
			}
			if (scenario_0.TimeToHalt.HasValue)
			{
				DateTime time = scenario_0.Time;
				DateTime? runToThisTime = scenario_0.TimeToHalt;
				if ((runToThisTime.HasValue ? new bool?(DateTime.Compare(time, runToThisTime.GetValueOrDefault()) >= 0) : ((bool?)null)) == true)
				{
					CurrentGame.Pause();
					scenario_0.TimeToHalt = null;
					break;
				}
			}
			if (CurrentGame.Status == Game._GameStatus.Paused)
			{
				break;
			}
			while (smethod_29())
			{
				Thread.Sleep(1000);
			}
			Advance1Pulse(scenario_0, ref Diagnostic_PulseTime);
			if (scenario_0.FifteenthSecondIsChangingOnThisPulse)
			{
				GameGeneral.ProcessAndTruncateMessageLog(scenario_0, WriteToLog: true, scenario_0.MessageLogFilePath);
			}
			foreach (LoggedMessage unhandledPopUpMessage in scenario_0.UnhandledPopUpMessages)
			{
				if (unhandledPopUpMessage.Side == side_0)
				{
					CurrentGame.Pause();
					break;
				}
			}
			if (scenario_0.TimeCompression_SimSeconds > 1)
			{
				MustRefreshMainForm = true;
			}
			if (GameGeneral.TacviewPipeEnabled)
			{
				TacviewClient.RefreshContactsOfCurrentSide();
			}
		}
		GameGeneral.ProcessAndTruncateMessageLog(scenario_0, WriteToLog: true, scenario_0.MessageLogFilePath);
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 200658", ex2.Message);
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Diagnostics;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

internal static void Advance1Pulse(Scenario theScen, ref float WallTimeElapsed)
{
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	try
	{
		try
		{
			GameGeneral.MainGameLoop(ref theScen);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200362", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
	catch (Exception ex3)
	{
		ProjectData.SetProjectError(ex3);
		Exception ex4 = ex3;
		ex4?.Data.Add("Error at 101163", ex4.Message);
		GameGeneral.WriteExceptionsToLog(ex4);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw;
	}
	stopwatch.Stop();
	WallTimeElapsed = stopwatch.ElapsedMilliseconds;
	MustRefreshMainForm = true;
	if (!theScen.HasBeenReleased)
	{
		timeAdvancedEventHandler_0?.Invoke(theScen);
	}
}

using Command_Core;

public static void ConfigureCommandCoreSettings(ref Scenario theScen)
{
	theScen.Navigation_FinegrainedMaxDistance = SimConfiguration.DefaultGamePreferences.NavigationMaxDistanceNMSetting;
	theScen.Navigation_FinegrainedThresholdDistance = SimConfiguration.DefaultGamePreferences.NavigationThresholdDistanceDegSetting;
}

using Command_Core;

public static void TimeStep_15sec()
{
	if (CurrentGame.Status != Game._GameStatus.Running)
	{
		RunToThisTime = scenario_0.Time.AddSeconds(15.0);
		CurrentGame.Run();
	}
}

using Command_Core;

public static void TimeStep_1min()
{
	if (CurrentGame.Status != Game._GameStatus.Running)
	{
		RunToThisTime = scenario_0.Time.AddSeconds(60.0);
		CurrentGame.Run();
	}
}

using Command_Core;

public static void TimeStep_5min()
{
	if (CurrentGame.Status != Game._GameStatus.Running)
	{
		RunToThisTime = scenario_0.Time.AddMinutes(5.0);
		CurrentGame.Run();
	}
}

using Command_Core;

public static void TimeStep_15min()
{
	if (CurrentGame.Status != Game._GameStatus.Running)
	{
		RunToThisTime = scenario_0.Time.AddMinutes(15.0);
		CurrentGame.Run();
	}
}

using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void QuickJumpSlot_Retrieve(int theIndex)
{
	//IL_003b: Unknown result type (might be due to invalid IL or missing references)
	if (!side_0.QuickJumpSlots.ContainsKey(theIndex))
	{
		return;
	}
	side_0.QuickJumpSlots.TryGetValue(theIndex, out var value);
	if (Information.IsNothing((object)value))
	{
		DarkMessageBox.ShowError("No slot with such ID present!", "Incorrect quick-jump slot!");
		return;
	}
	string text = value.LocationString.Split(new char[1] { '_' })[0];
	if (Operators.CompareString(text, "AU", true) != 0)
	{
		if (Operators.CompareString(text, "Con", true) == 0)
		{
			side_0.Contacts.TryGetValue(value.LocationString.Split(new char[1] { '_' })[1], out var value2);
			if (!Information.IsNothing((object)value2))
			{
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(((Module_Unit.Unit)value2).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)value2).get_Latitude((GlobalVariables.BooleanObject)null)));
				MyProject.Forms.MainForm.CameraAltitude = value.CameraAlt;
				MyProject.Forms.MainForm.TrackCamActive = value.Tracking;
				((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Jumped to slot #" + Conversions.ToString(theIndex);
			}
		}
	}
	else
	{
		scenario_0.ActiveUnits.TryGetValue(value.LocationString.Split(new char[1] { '_' })[1], out var value3);
		if (!Information.IsNothing((object)value3))
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(value3.get_Longitude((GlobalVariables.BooleanObject)null), value3.get_Latitude((GlobalVariables.BooleanObject)null)));
			MyProject.Forms.MainForm.CameraAltitude = value.CameraAlt;
			MyProject.Forms.MainForm.TrackCamActive = value.Tracking;
			((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Jumped to slot #" + Conversions.ToString(theIndex);
		}
	}
}

using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;

public static void ShowDamageDetails()
{
	if (!Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit)
	{
		Side theSide = side_0;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string ReasonWhyNot = null;
		if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) && (Information.IsNothing((object)theDamageControlWindow) || !((Control)theDamageControlWindow).Visible) && SelectedUnit.IsPlatform)
		{
			theDamageControlWindow = new DamageControlWindow();
			theDamageControlWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
			theDamageControlWindow.theCurrentGame = CurrentGame;
			((Control)theDamageControlWindow).Show();
		}
	}
}

using System.Linq;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;

public static void ShowMags()
{
	//IL_0180: Unknown result type (might be due to invalid IL or missing references)
	//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
	//IL_01da: Unknown result type (might be due to invalid IL or missing references)
	//IL_0145: Unknown result type (might be due to invalid IL or missing references)
	if (Information.IsNothing((object)SelectedUnit) || (!Information.IsNothing((object)theMagazinesWindow) && ((Control)theMagazinesWindow).Visible) || !SelectedUnit.IsActiveUnit)
	{
		return;
	}
	if (SelectedUnit.IsPlatform)
	{
		if (!Information.IsNothing((object)((Platform)SelectedUnit).Magazines))
		{
			if (!AllowEditModeActions && ((Platform)SelectedUnit).Magazines.Count() <= 0)
			{
				bool flag = default(bool);
				if ((SelectedUnit.IsShip || SelectedUnit.IsFacility || SelectedUnit.IsMobileGroundUnit) && ((Platform)SelectedUnit).Mounts.Count > 0)
				{
					foreach (Mount mount in ((Platform)SelectedUnit).Mounts)
					{
						if (mount.MountMagazine.Weapons.Count > 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					theMagazinesWindow = new Magazines();
					theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
					((Control)theMagazinesWindow).Show();
				}
				else
				{
					DarkMessageBox.ShowError("Selected unit has no magazines.", "No mags!");
				}
			}
			else
			{
				theMagazinesWindow = new Magazines();
				theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
				((Control)theMagazinesWindow).Show();
			}
		}
		else
		{
			DarkMessageBox.ShowError("Selected unit has no magazines.", "No mags!");
		}
	}
	else if (SelectedUnit.IsGroup)
	{
		if (Information.IsNothing((object)((Group)SelectedUnit).SharedMagazines))
		{
			DarkMessageBox.ShowError("Selected unit has no magazines.", "No mags!");
			return;
		}
		if (((Group)SelectedUnit).SharedMagazines.Length <= 0)
		{
			DarkMessageBox.ShowError("Selected group has no magazines.", "No mags!");
			return;
		}
		theMagazinesWindow = new Magazines();
		theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
		((Control)theMagazinesWindow).Show();
	}
}

using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;

public static void ShowDaysUnderway()
{
	if (!Information.IsNothing((object)SelectedUnit) && !((Control)theTimeUnderwayWindow).Visible && SelectedUnit.IsActiveUnit)
	{
		theTimeUnderwayWindow = new TimeUnderway();
		theTimeUnderwayWindow.theAU = (ActiveUnit)SelectedUnit;
		((Control)theTimeUnderwayWindow).Show();
	}
}

using System.Windows.Forms;
using Command.My;

public static void ShowSetUnitProperties()
{
	if (SelectedUnit != null && !((Control)MyProject.Forms.Form_SetFuelAndAirborneTime).Visible && SelectedUnit.IsActiveUnit)
	{
		((Control)MyProject.Forms.Form_SetFuelAndAirborneTime).Show();
	}
}

using System.Windows.Forms;
using Command.My;

public static void ClearMessageLog()
{
	scenario_0.ClearMessageLog();
	if (MyProject.Forms.MainForm.MessageLogOuterControl1.VM != null)
	{
		MyProject.Forms.MainForm.MessageLogOuterControl1.VM.ClearLog();
		MyProject.Forms.MainForm.MessageLogOuterControl1.VM.RefreshLoggedMessages();
	}
	int mustRefreshMainForm;
	if (!((Control)MyProject.Forms.MessageLogWindow_RawText).Visible && MyProject.Forms.MainForm.gclass1_0 == null)
	{
		mustRefreshMainForm = 1;
	}
	else
	{
		MyProject.Forms.MainForm.MessageLogControlViewModel.ClearLog();
		MyProject.Forms.MainForm.MessageLogControlViewModel.RefreshLoggedMessages();
		mustRefreshMainForm = 1;
	}
	MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
}

using System;
using System.Collections;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

public static void CloseAllOpenWindows(bool Exclude3DView)
{
	//IL_0016: Unknown result type (might be due to invalid IL or missing references)
	//IL_001c: Expected O, but got Unknown
	foreach (Form item in (ReadOnlyCollectionBase)(object)Application.OpenForms)
	{
		Form val = item;
		if ((object)val != MyProject.Forms.m_MainForm && ((Control)val).Visible && (object)val != MyProject.Forms.m_WEGOMultiplayerForm && (object)val != MyProject.Forms.m_DISForm)
		{
			try
			{
				((Control)val).Hide();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void ShowThrottleAlt()
{
	if (AGU_CONFIG.Instance.Enabled && SelectedUnit != null && SelectedUnit.IsAggregatedUnit)
	{
		((Control)MyProject.Forms.AGU_Control).Show();
		MyProject.Forms.AGU_Control.RefreshForm((AggregateGroundUnit)SelectedUnit);
		((Form)MyProject.Forms.AGU_Control).TopMost = true;
		return;
	}
	if (waypoint_0 != null && waypoint_0.Category == Waypoint.WaypointCategory.FlightPlan)
	{
		bool flag = false;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				foreach (Mission.Flight flight in mission.FlightList)
				{
					for (int j = flight.FlightPlan.Count() - 1; j >= 0; j += -1)
					{
						Waypoint waypoint = flight.FlightPlan[j];
						if (waypoint == waypoint_0)
						{
							flag = true;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) && waypoint.Waypoint_LeadElementWingman == waypoint_0)
						{
							flag = true;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement) && waypoint.Waypoint_SecondElement == waypoint_0)
						{
							flag = true;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) && waypoint.Waypoint_SecondElementWingman == waypoint_0)
						{
							flag = true;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement) && waypoint.Waypoint_ThirdElement == waypoint_0)
						{
							flag = true;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == waypoint_0)
						{
							flag = true;
						}
						if (flag)
						{
							MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = null;
							MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = waypoint_0;
							MyProject.Forms.SpeedAlt.SpeedAlt_Flight = flight;
							MyProject.Forms.SpeedAlt.SpeedAlt_Mission = mission;
							((Control)MyProject.Forms.SpeedAlt).Show();
							return;
						}
					}
				}
			}
		}
	}
	if (SelectedUnit == null || !SelectedUnit.IsActiveUnit || SelectedUnit.IsSatellite || (SelectedUnit.IsWeapon && Information.IsNothing((object)((Weapon)SelectedUnit).DataLinkParent)) || (MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint != null && ((Control)MyProject.Forms.SpeedAlt).Visible) || SelectedUnit == null)
	{
		return;
	}
	Side theSide = side_0;
	Module_Unit.Unit selectedUnit = SelectedUnit;
	string ReasonWhyNot = null;
	if (!GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) || SelectedUnit.get_UnitSide(SetSideOnly: false) != side_0)
	{
		return;
	}
	if (SelectedUnit.IsGroup)
	{
		MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
		MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
		MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
		MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
		MyProject.Forms.SpeedAlt.LoadForm();
		((Control)MyProject.Forms.SpeedAlt).Show();
	}
	else if (!((ActiveUnit)SelectedUnit).IsFixedFacility)
	{
		MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
		MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
		MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
		MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
		if (!SelectedUnit.IsWeapon || ((Weapon)SelectedUnit).Type != Weapon._WeaponType.Sonobuoy)
		{
			MyProject.Forms.SpeedAlt.LoadForm();
			((Control)MyProject.Forms.SpeedAlt).Show();
		}
	}
}

using System.Collections.Generic;
using Command_Core;

public static List<ActiveUnit> GetSelectedActiveUnitsForCoursePlot()
{
	List<ActiveUnit> list = new List<ActiveUnit>();
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		Side theSide = side_0;
		string ReasonWhyNot = null;
		if (!GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) || selectedUnit.IsSatellite || (selectedUnit.IsFacility && ((Facility)selectedUnit).IsFixedFacility))
		{
			continue;
		}
		if (selectedUnit.IsGroup)
		{
			switch (((Group)selectedUnit).Type)
			{
			case Group.GroupType.Installation:
			case Group.GroupType.AirBase:
			case Group.GroupType.NavalBase:
				continue;
			}
		}
		list.Add((ActiveUnit)selectedUnit);
	}
	return list;
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;

public static List<ActiveUnit> GetActiveUnitsForPlottedCourseWaypoint(Waypoint theWaypoint)
{
	List<ActiveUnit> list = new List<ActiveUnit>();
	foreach (ActiveUnit unit in side_0.Units)
	{
		if (unit.Navigator.PlottedCourse.Contains(theWaypoint))
		{
			list.Add(unit);
			break;
		}
	}
	return list;
}

using System.Windows.Forms;
using Command_Core;

public static void Split()
{
	if (SelectedUnit != null && SelectedUnit.IsFacility && ((ActiveUnit)SelectedUnit).IsSplittable())
	{
		((Control)new SplitUnit
		{
			SourceUnit = (ActiveUnit)SelectedUnit
		}).Show();
	}
}

using System.Linq;
using Command_Core;
using Microsoft.VisualBasic;

public static void Merge()
{
	if (Information.IsNothing((object)side_0) || side_0.SelectedUnits.Count <= 1)
	{
		return;
	}
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
		if (selectedUnit.get_UnitSide(SetSideOnly: false) != side_0 || !activeUnit.IsSplittable() || !(side_0.SelectedUnits.ElementAt(0).RangeToUnit_Horiz(selectedUnit) <= 0.2f))
		{
			return;
		}
	}
	ActiveUnit activeUnit2 = (ActiveUnit)side_0.SelectedUnits.ElementAt(0);
	for (int i = side_0.SelectedUnits.Count - 1; i >= 1; i += -1)
	{
		foreach (Mount item in ((ActiveUnit)side_0.SelectedUnits.ElementAt(i)).Mounts.ToList())
		{
			activeUnit2.Mounts.Add(item);
			((ActiveUnit)side_0.SelectedUnits.ElementAt(i)).Mounts.Remove(item);
		}
		((ActiveUnit)side_0.SelectedUnits.ElementAt(i)).Destroy(ScenEditAction: true, IsFacilityAimpoint: true, DestroyUnitNow: true, "Unit Merged", null, RegisterAsLosses: false);
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void PlotCourse()
{
	if (SelectedUnit == null)
	{
		return;
	}
	try
	{
		bool flag = default(bool);
		if (SelectedUnit != null)
		{
			Side theSide = side_0;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string ReasonWhyNot = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
			{
				flag = true;
			}
		}
		if (!flag)
		{
			foreach (Module_Unit.Unit selectedUnit2 in side_0.SelectedUnits)
			{
				string ReasonWhyNot2 = null;
				if (!selectedUnit2.IsActiveUnit || selectedUnit2.get_UnitSide(SetSideOnly: false) != side_0)
				{
					continue;
				}
				if (!GameGeneral.CanIssueOrdersToThisUnit(side_0, selectedUnit2, IncludeSonobuoys: false, ref ReasonWhyNot2, CurrentMapProfile.IsolatedPOVObjectID))
				{
					if (!string.IsNullOrEmpty(ReasonWhyNot2))
					{
						((ActiveUnit)selectedUnit2).AddMessage(selectedUnit2.Name + " cannot be instructed to change course (" + ReasonWhyNot2 + ")", selectedUnit2.Name + " cannot be ordered", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(selectedUnit2.get_Longitude((GlobalVariables.BooleanObject)null), selectedUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else
				{
					flag = true;
				}
			}
		}
		if (!flag || SelectedUnit.IsSatellite)
		{
			return;
		}
		if (SelectedUnit != null && waypoint_0 != null)
		{
			if (SelectedUnit.get_UnitSide(SetSideOnly: false) == side_0)
			{
				int num = Array.IndexOf(((ActiveUnit)SelectedUnit).Navigator.PlottedCourse, waypoint_0);
				int num2 = ((ActiveUnit)SelectedUnit).Navigator.PlottedCourse.Count() - 1;
				int num3 = num + 1;
				for (int i = num2; i >= num3; i += -1)
				{
					((ActiveUnit)SelectedUnit).Navigator.RemoveWaypoint_Soft(((ActiveUnit)SelectedUnit).Navigator.PlottedCourse[i], RemoveWingmanWaypoints: true);
				}
				CurrentUserAction = UserAction.PlottingCourse;
				MustRefreshMainForm = true;
			}
			return;
		}
		int currentUserAction;
		if (CurrentUserAction != UserAction.PlottingCourse)
		{
			if (CurrentUserAction != UserAction.PlottingCourseForSalvo)
			{
				List<ActiveUnit> selectedActiveUnitsForCoursePlot = GetSelectedActiveUnitsForCoursePlot();
				if (selectedActiveUnitsForCoursePlot.Count == 0)
				{
					return;
				}
				foreach (ActiveUnit item in selectedActiveUnitsForCoursePlot)
				{
					item.Navigator.ClearPlottedCourse(PlayerIsPlottingCourse: true);
				}
				CurrentUserAction = UserAction.PlottingCourse;
				if (Realtime)
				{
					RealtimeTerminal.SendCourseUpdate(selectedActiveUnitsForCoursePlot);
				}
				return;
			}
			currentUserAction = 0;
		}
		else
		{
			currentUserAction = 0;
		}
		CurrentUserAction = (UserAction)currentUserAction;
		MustRefreshMainForm = true;
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 101143", "");
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_30(int int_2)
{
	if (side_0 == null)
	{
		return;
	}
	if (SelectedUnit != null)
	{
		QuickJumpSlot quickJumpSlot = new QuickJumpSlot();
		quickJumpSlot.Index = int_2;
		if (SelectedUnit.IsActiveUnit)
		{
			quickJumpSlot.LocationString = "AU_" + SelectedUnit.ObjectID;
		}
		else
		{
			quickJumpSlot.LocationString = "Con_" + ((Contact)SelectedUnit).ActualUnit.ObjectID;
		}
		quickJumpSlot.CameraAlt = MyProject.Forms.MainForm.CameraAltitude;
		quickJumpSlot.Tracking = MyProject.Forms.MainForm.TrackCamActive;
		if (!side_0.QuickJumpSlots.ContainsKey(quickJumpSlot.Index))
		{
			side_0.QuickJumpSlots.Add(quickJumpSlot.Index, quickJumpSlot);
		}
		else
		{
			side_0.QuickJumpSlots[quickJumpSlot.Index] = quickJumpSlot;
		}
		((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Stored as quick-jump slot #" + Conversions.ToString(int_2);
		MyProject.Forms.MainForm.AdjustQuickJumpMenu();
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void HandleGlobalHotkeys(Keys theKeyData)
{
	//IL_0023: Unknown result type (might be due to invalid IL or missing references)
	//IL_0024: Unknown result type (might be due to invalid IL or missing references)
	//IL_0026: Unknown result type (might be due to invalid IL or missing references)
	//IL_002d: Invalid comparison between Unknown and I4
	//IL_1221: Unknown result type (might be due to invalid IL or missing references)
	//IL_1228: Invalid comparison between Unknown and I4
	//IL_0032: Unknown result type (might be due to invalid IL or missing references)
	//IL_0039: Invalid comparison between Unknown and I4
	//IL_13e2: Unknown result type (might be due to invalid IL or missing references)
	//IL_13e9: Invalid comparison between Unknown and I4
	//IL_122d: Unknown result type (might be due to invalid IL or missing references)
	//IL_1234: Invalid comparison between Unknown and I4
	//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
	//IL_0ad4: Invalid comparison between Unknown and I4
	//IL_003e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0045: Invalid comparison between Unknown and I4
	//IL_1464: Unknown result type (might be due to invalid IL or missing references)
	//IL_146b: Invalid comparison between Unknown and I4
	//IL_13eb: Unknown result type (might be due to invalid IL or missing references)
	//IL_13f2: Invalid comparison between Unknown and I4
	//IL_127a: Unknown result type (might be due to invalid IL or missing references)
	//IL_1281: Invalid comparison between Unknown and I4
	//IL_1236: Unknown result type (might be due to invalid IL or missing references)
	//IL_123d: Invalid comparison between Unknown and I4
	//IL_0b25: Unknown result type (might be due to invalid IL or missing references)
	//IL_0b2c: Invalid comparison between Unknown and I4
	//IL_0ad6: Unknown result type (might be due to invalid IL or missing references)
	//IL_0add: Invalid comparison between Unknown and I4
	//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
	//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
	//IL_0298: Expected I4, but got Unknown
	//IL_0047: Unknown result type (might be due to invalid IL or missing references)
	//IL_004e: Invalid comparison between Unknown and I4
	//IL_14e3: Unknown result type (might be due to invalid IL or missing references)
	//IL_14ea: Invalid comparison between Unknown and I4
	//IL_146d: Unknown result type (might be due to invalid IL or missing references)
	//IL_1474: Unknown result type (might be due to invalid IL or missing references)
	//IL_149a: Expected I4, but got Unknown
	//IL_13f4: Unknown result type (might be due to invalid IL or missing references)
	//IL_13fb: Invalid comparison between Unknown and I4
	//IL_1390: Unknown result type (might be due to invalid IL or missing references)
	//IL_1397: Invalid comparison between Unknown and I4
	//IL_1286: Unknown result type (might be due to invalid IL or missing references)
	//IL_128d: Unknown result type (might be due to invalid IL or missing references)
	//IL_12ab: Expected I4, but got Unknown
	//IL_123f: Unknown result type (might be due to invalid IL or missing references)
	//IL_1246: Invalid comparison between Unknown and I4
	//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
	//IL_0b61: Invalid comparison between Unknown and I4
	//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0b35: Invalid comparison between Unknown and I4
	//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
	//IL_0ae6: Invalid comparison between Unknown and I4
	//IL_0298: Unknown result type (might be due to invalid IL or missing references)
	//IL_029f: Unknown result type (might be due to invalid IL or missing references)
	//IL_02b1: Expected I4, but got Unknown
	//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
	//IL_00ab: Invalid comparison between Unknown and I4
	//IL_0050: Unknown result type (might be due to invalid IL or missing references)
	//IL_0057: Invalid comparison between Unknown and I4
	//IL_14ef: Unknown result type (might be due to invalid IL or missing references)
	//IL_14f6: Invalid comparison between Unknown and I4
	//IL_149a: Unknown result type (might be due to invalid IL or missing references)
	//IL_14a1: Invalid comparison between Unknown and I4
	//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
	//IL_1404: Invalid comparison between Unknown and I4
	//IL_1399: Unknown result type (might be due to invalid IL or missing references)
	//IL_13a0: Invalid comparison between Unknown and I4
	//IL_12ab: Unknown result type (might be due to invalid IL or missing references)
	//IL_12b2: Invalid comparison between Unknown and I4
	//IL_1248: Unknown result type (might be due to invalid IL or missing references)
	//IL_124f: Invalid comparison between Unknown and I4
	//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
	//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
	//IL_0c5f: Expected I4, but got Unknown
	//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
	//IL_0b3e: Invalid comparison between Unknown and I4
	//IL_0ae8: Unknown result type (might be due to invalid IL or missing references)
	//IL_0aef: Invalid comparison between Unknown and I4
	//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
	//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
	//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
	//IL_02b8: Invalid comparison between Unknown and I4
	//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
	//IL_00b4: Invalid comparison between Unknown and I4
	//IL_0059: Unknown result type (might be due to invalid IL or missing references)
	//IL_0060: Invalid comparison between Unknown and I4
	//IL_1429: Unknown result type (might be due to invalid IL or missing references)
	//IL_1389: Unknown result type (might be due to invalid IL or missing references)
	//IL_0084: Unknown result type (might be due to invalid IL or missing references)
	//IL_008a: Invalid comparison between Unknown and I4
	//IL_0ff0: Unknown result type (might be due to invalid IL or missing references)
	//IL_10c2: Unknown result type (might be due to invalid IL or missing references)
	//IL_110e: Unknown result type (might be due to invalid IL or missing references)
	//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
	//IL_03ff: Invalid comparison between Unknown and I4
	if (!MainFormHasLoaded || ((Control)MyProject.Forms.MainForm.txtMenuSearch).Focused)
	{
		return;
	}
	if ((int)theKeyData <= 131162)
	{
		if ((int)theKeyData <= 65619)
		{
			if ((int)theKeyData > 65581)
			{
				if ((int)theKeyData <= 65603)
				{
					if ((int)theKeyData != 65582)
					{
						if ((int)theKeyData == 65603)
						{
							CloneUnit();
						}
					}
					else if (CurrentGame.GameMode == Game._GameMode.ScenEdit && (int)DarkMessageBox.ShowWarning("This will remove all units in the scenario, except the selection. Proceed ?", string.Empty, DarkDialogButton.YesNoCancel) == 6)
					{
						DeleteAllUnit(side_0.SelectedUnits.ToHashSet());
					}
				}
				else if ((int)theKeyData != 65604)
				{
					if ((int)theKeyData == 65619)
					{
						Set_UnitIsSpotted();
					}
				}
				else
				{
					DeployDippingSonar();
				}
				return;
			}
			switch (theKeyData - 8)
			{
			case 0:
				SelectPreviousUnit();
				return;
			case 5:
				goto IL_02e3;
			case 19:
				goto IL_031b;
			case 24:
				RunPauseTimeToggle();
				return;
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
				if (side_0 != null)
				{
					QuickJumpSlot_Retrieve(Conversions.ToInteger(((TypeConverter)(object)keysConverter_0).ConvertToString((object?)theKeyData)));
				}
				return;
			case 57:
				goto IL_04b7;
			case 58:
				if (!Information.IsNothing((object)side_0))
				{
					ReturnToBase();
				}
				return;
			case 59:
				goto IL_05fc;
			case 60:
				DetachUnits();
				return;
			case 61:
				MyProject.Forms.MainForm.DropTargets();
				return;
			case 62:
				MarkContactFriendly();
				return;
			case 63:
				MyProject.Forms.MainForm.GroupUnits();
				return;
			case 64:
				MarkContactHostile();
				return;
			case 65:
				goto IL_0648;
			case 68:
			{
				if (side_0 == null)
				{
					return;
				}
				bool MenuItemChecked = true;
				foreach (Module_Unit.Unit selectedUnit2 in side_0.SelectedUnits)
				{
					if (selectedUnit2.IsActiveUnit && selectedUnit2.get_UnitSide(SetSideOnly: false) == side_0 && ((selectedUnit2.IsFacility && !((ActiveUnit)selectedUnit2).IsFixedFacility) || selectedUnit2.IsMobileGroundUnit) && !((ActiveUnit)selectedUnit2).AI.HoldPosition)
					{
						MenuItemChecked = false;
						break;
					}
				}
				HoldPosition(ref MenuItemChecked);
				return;
			}
			case 69:
				MoveUnit();
				return;
			case 70:
				MarkContactNeutral();
				return;
			case 71:
				if (!Information.IsNothing((object)side_0))
				{
					((Control)MyProject.Forms.ORBAT).Show();
				}
				return;
			case 73:
				MyProject.Forms.MainForm.DXPrototypeMainClearTiles = true;
				return;
			case 74:
				RenameUnitOrContact();
				return;
			case 76:
				MyProject.Forms.MainForm.ToggleTrackcam();
				return;
			case 77:
				UnassignUnitsAndDisengage();
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(scenario_0, side_0, SelectedUnit, v: false);
				return;
			case 80:
				MyProject.Forms.MainForm.ZoomOut();
				return;
			case 82:
				MyProject.Forms.MainForm.ZoomIn(ViaMouseWheel: false);
				return;
			case 84:
				if (SelectedUnit != null)
				{
					Point point = WWC.WWC_WorldToScreen(MyProject.Forms.MainForm.WorldWindow1, SelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null), SelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					if (SelectedUnit.IsActiveUnit)
					{
						MyProject.Forms.MainForm.ShowUnitContextMenu(SelectedUnit, point.X, point.Y);
					}
					if (SelectedUnit.IsContact())
					{
						MyProject.Forms.MainForm.ShowContactContextMenu((Contact)SelectedUnit, point.X, point.Y);
					}
				}
				return;
			case 37:
			case 88:
				if (AllowEditModeActions)
				{
					CurrentUserAction = UserAction.AddingPlatform;
				}
				return;
			case 27:
			case 89:
				CurrentMapProfile.ShowIlluminationVectors += 1;
				MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
				return;
			case 32:
			case 90:
				MyProject.Forms.MainForm.PanMapDown();
				return;
			case 72:
			case 91:
				DropSelectedContacts();
				return;
			case 29:
			case 92:
				MyProject.Forms.MainForm.PanMapLeft();
				return;
			case 31:
			case 94:
				MyProject.Forms.MainForm.PanMapRight();
				return;
			case 28:
			case 95:
				CurrentMapProfile.ShowTargetingVectors += 1;
				MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
				return;
			case 30:
			case 96:
				MyProject.Forms.MainForm.PanMapUp();
				return;
			case 25:
			case 78:
			case 97:
				MyProject.Forms.MainForm.SwitchView();
				return;
			case 98:
				CurrentMapProfile.ShowDatablocks += 1;
				MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
				return;
			case 38:
			case 102:
				if (waypoint_0 == null)
				{
					DeleteUnit();
				}
				else
				{
					DeleteWaypoint();
				}
				RoadSystemEditor.SelectedSegment_Delete();
				return;
			case 103:
				CurrentMapProfile.ShowDatalinks += 1;
				MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
				return;
			case 104:
				AttackTarget_Auto();
				return;
			case 105:
				ShowThrottleAlt();
				return;
			case 106:
				PlotCourse();
				return;
			case 107:
				EditFormation();
				return;
			case 108:
				ShowMags();
				return;
			case 109:
				ShowAirOps();
				return;
			case 110:
				ShowDockingOps();
				return;
			case 111:
				ShowWeaponDetails();
				return;
			case 112:
				if (side_0 != null)
				{
					ShowSensorsForSelectedUnit();
				}
				return;
			case 113:
				ShowDamageDetails();
				return;
			case 114:
				goto IL_0aa9;
			case 75:
				goto IL_15e1;
			case 1:
			case 2:
			case 3:
			case 4:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 20:
			case 21:
			case 22:
			case 23:
			case 26:
			case 33:
			case 34:
			case 35:
			case 36:
			case 39:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 66:
			case 67:
			case 79:
			case 81:
			case 83:
			case 85:
			case 86:
			case 87:
			case 93:
			case 99:
			case 100:
			case 101:
				return;
			}
			switch (theKeyData - 219)
			{
			case 0:
				DispatchSimpleUnitAction(SelectedUnit, SimpleUnitAction.DropSonobuoyPassiveDeep);
				return;
			case 1:
				SelectNextUnit();
				return;
			case 2:
				DispatchSimpleUnitAction(SelectedUnit, SimpleUnitAction.DropSonobuoyActiveDeep);
				return;
			}
			if ((int)theKeyData != 65581)
			{
				return;
			}
		}
		else
		{
			if ((int)theKeyData > 65651)
			{
				if ((int)theKeyData <= 65757)
				{
					if ((int)theKeyData != 65755)
					{
						if ((int)theKeyData == 65757)
						{
							DispatchSimpleUnitAction(SelectedUnit, SimpleUnitAction.DropSonobuoyActiveShallow);
						}
					}
					else
					{
						DispatchSimpleUnitAction(SelectedUnit, SimpleUnitAction.DropSonobuoyPassiveShallow);
					}
					return;
				}
				if ((int)theKeyData != 131085)
				{
					switch (theKeyData - 131104)
					{
					default:
						return;
					case 0:
					{
						float WallTimeElapsed = 0f;
						if (scenario_0.DEBUG_DiscriminateResolutionAndCompression)
						{
							Advance1Pulse(scenario_0, ref WallTimeElapsed);
						}
						Notification.AddNotification(WallTimeElapsed + "ms", "", NotificationType.Information, 3f);
						return;
					}
					case 3:
						_ = side_0.RefPoints;
						foreach (ReferencePoint highlightedRefPoint in HighlightedRefPoints)
						{
							if (!Realtime)
							{
								highlightedRefPoint.IsHighlighted = false;
							}
							else
							{
								RealtimeTerminal.SetLocalReferencePointHighlightState(side_0, highlightedRefPoint, highLight: false);
							}
						}
						MustRefreshMainForm = true;
						return;
					case 13:
						CurrentUserAction = UserAction.AddingReferencePoint;
						SelectedRefPoint = null;
						return;
					case 16:
						smethod_30(0);
						return;
					case 17:
						smethod_30(1);
						return;
					case 18:
						smethod_30(2);
						return;
					case 19:
						smethod_30(3);
						return;
					case 20:
						smethod_30(4);
						return;
					case 21:
						smethod_30(5);
						return;
					case 22:
						smethod_30(6);
						return;
					case 23:
						smethod_30(7);
						return;
					case 24:
						smethod_30(8);
						return;
					case 25:
						smethod_30(9);
						return;
					case 33:
					{
						if (side_0 == null)
						{
							return;
						}
						bool flag = true;
						foreach (ActiveUnit unit in side_0.Units)
						{
							if (unit.IsActiveUnit && ((Module_Unit.Unit)unit).get_UnitSide(SetSideOnly: false) == side_0 && !unit.IsWeapon)
							{
								byte? b = (byte?)unit.Doctrine.get_WeaponControlStatus_Air(scenario_0, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2));
								if (((!flag2) ?? flag2) == true)
								{
									flag = false;
									break;
								}
							}
						}
						if (!flag)
						{
							Doctrine._WCS? theWCS = Doctrine._WCS.Hold;
							WeaponsHold_AllUnits(ref theWCS);
						}
						else
						{
							Doctrine._WCS? theWCS = null;
							WeaponsHold_AllUnits(ref theWCS);
						}
						return;
					}
					case 35:
						CopyGUID();
						return;
					case 36:
						ToggleDistanceMeasure();
						return;
					case 37:
						DisengageTargets();
						return;
					case 40:
						MarkContactUnfriendly();
						return;
					case 41:
					{
						if (side_0 == null)
						{
							return;
						}
						bool flag3 = true;
						foreach (ActiveUnit unit2 in side_0.Units)
						{
							if (unit2.IsActiveUnit && ((Module_Unit.Unit)unit2).get_UnitSide(SetSideOnly: false) == side_0 && !unit2.IsWeapon)
							{
								byte? b = (byte?)unit2.Doctrine.get_IgnorePlottedCourse(scenario_0, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if (((!flag2) ?? flag2) == true)
								{
									flag3 = false;
									break;
								}
							}
						}
						if (!flag3)
						{
							Doctrine._UseIgnorePlottedCourse? theIPC = Doctrine._UseIgnorePlottedCourse.Yes;
							IgnorePlottedCourse_AllUnits(ref theIPC);
						}
						else
						{
							Doctrine._UseIgnorePlottedCourse? theIPC = null;
							IgnorePlottedCourse_AllUnits(ref theIPC);
						}
						return;
					}
					case 43:
						if (side_0 != null)
						{
							CurrentUserAction = UserAction.DefiningArea_Rectangle;
							return;
						}
						DarkMessageBox.ShowError("You must have at least one side in order to define a rectangle.", "No sides present!");
						((Control)MyProject.Forms.Sides).Show();
						((Button)MyProject.Forms.Sides.btnAddSide).PerformClick();
						return;
					case 44:
					{
						if (side_0 == null)
						{
							return;
						}
						bool MenuItemChecked2 = true;
						foreach (ActiveUnit unit3 in side_0.Units)
						{
							if (unit3.IsActiveUnit && unit3.get_UnitSide(SetSideOnly: false) == side_0 && ((unit3.IsFacility && !unit3.IsFixedFacility) || unit3.IsMobileGroundUnit) && !unit3.AI.HoldPosition)
							{
								MenuItemChecked2 = false;
								break;
							}
						}
						HoldPositionAllUnits(ref MenuItemChecked2);
						return;
					}
					case 45:
						ClearMessageLog();
						return;
					case 47:
						if (side_0 == null)
						{
							DarkMessageBox.ShowError("You must have at least one side in order to define a circle.", "No sides present!");
							((Control)MyProject.Forms.Sides).Show();
							((Button)MyProject.Forms.Sides.btnAddSide).PerformClick();
						}
						else
						{
							CurrentUserAction = UserAction.DefiningArea_Circle;
						}
						return;
					case 48:
						if (side_0 != null)
						{
							CurrentUserAction = UserAction.DefiningArea_Polygon;
							return;
						}
						DarkMessageBox.ShowError("You must have at least one side in order to define a polygon.", "No sides present!");
						((Control)MyProject.Forms.Sides).Show();
						((Button)MyProject.Forms.Sides.btnAddSide).PerformClick();
						return;
					case 50:
						RenameRefPoint();
						return;
					case 54:
						if (AllowGodModeActions)
						{
							GodsEyeView();
						}
						return;
					case 55:
						DeleteWaypoint();
						return;
					case 56:
						if (!Information.IsNothing((object)MyProject.Forms.MainForm.WorldWindow1))
						{
							WorldWindow worldWindow = MyProject.Forms.MainForm.WorldWindow1;
							ref Point currentMousePosition = ref MyProject.Forms.MainForm.CurrentMousePosition;
							int PointX = currentMousePosition.X;
							ref Point currentMousePosition2 = ref MyProject.Forms.MainForm.CurrentMousePosition;
							int PointY = currentMousePosition2.Y;
							double WorldLon = default(double);
							double WorldLat = default(double);
							WWC.WWC_ScreenToWorld(worldWindow, ref PointX, ref PointY, ref WorldLon, ref WorldLat);
							currentMousePosition2.Y = PointY;
							currentMousePosition.X = PointX;
							Clipboard.SetText("latitude='" + Conversions.ToString(WorldLat) + "', longitude='" + Conversions.ToString(WorldLon) + "'");
						}
						else
						{
							GameGeneral.WriteLogDebugInfoToFile("WorldWindow1 object not found! Error 200594");
						}
						return;
					case 58:
						CopyRefPoints();
						return;
					case 14:
						break;
					case 1:
					case 2:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 15:
					case 26:
					case 27:
					case 28:
					case 29:
					case 30:
					case 31:
					case 32:
					case 34:
					case 38:
					case 39:
					case 42:
					case 46:
					case 49:
					case 51:
					case 52:
					case 53:
					case 57:
						return;
					}
					goto IL_1258;
				}
				RunPauseTimeToggle();
				return;
			}
			if ((int)theKeyData != 65632)
			{
				if ((int)theKeyData != 65648)
				{
					if ((int)theKeyData == 65651)
					{
						((Control)MyProject.Forms.NavalFormationEditor).Show();
					}
				}
				else
				{
					AttackTarget_Manual();
				}
				return;
			}
		}
		if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			CurrentUserAction = UserAction.AddingPlatform;
			AddingDecoyPlatform = true;
		}
		return;
	}
	if ((int)theKeyData <= 196685)
	{
		if ((int)theKeyData <= 131184)
		{
			if ((int)theKeyData != 131168)
			{
				if ((int)theKeyData != 131182)
				{
					if ((int)theKeyData == 131184)
					{
						smethod_31();
					}
					return;
				}
				goto IL_1258;
			}
			CurrentUserAction = UserAction.AddingReferencePoint;
			SelectedRefPoint = null;
			return;
		}
		if ((int)theKeyData <= 196675)
		{
			switch (theKeyData - 131189)
			{
			default:
				if ((int)theKeyData == 196675 && AllowEditModeActions)
				{
					((Control)MyProject.Forms.ConsoleWindow2).Show();
				}
				break;
			case 0:
				if (AllowEditModeActions)
				{
					MyProject.Forms.MainForm.AddRemoveAircraft();
				}
				break;
			case 1:
				if (AllowEditModeActions)
				{
					MyProject.Forms.MainForm.AddRemoveDockedBoats();
				}
				break;
			case 3:
				if (SelectedUnit != null && side_0.SelectedUnits.Count != 0)
				{
					MainForm mainForm = MyProject.Forms.MainForm;
					Module_Unit.Unit selectedUnit = SelectedUnit;
					ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = side_0.SelectedUnits;
					List<ActiveUnit> theSelectedActiveUnit = null;
					mainForm.ShowDoctrineROE(selectedUnit, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: true);
				}
				else if (waypoint_0 != null)
				{
					MainForm mainForm2 = MyProject.Forms.MainForm;
					Waypoint theScenObject = waypoint_0;
					ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
					List<ActiveUnit> theSelectedActiveUnit = null;
					mainForm2.ShowDoctrineROE(theScenObject, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: true);
				}
				break;
			case 5:
				if (side_0 != null)
				{
					((Control)NewMissionWindow).Show();
				}
				else
				{
					DarkMessageBox.ShowError("You must have a side selected.", "No side selected!");
				}
				break;
			case 2:
			case 4:
				break;
			}
		}
		else if ((int)theKeyData != 196681)
		{
			if ((int)theKeyData == 196685)
			{
				MyProject.Forms.MainForm.ToggleMessageLogInSeparateWindow();
				MustRefreshMainForm = true;
				((Control)MyProject.Forms.MainForm).BringToFront();
			}
		}
		else if (side_0 != null)
		{
			MyProject.Forms.MainForm.ToggleIsolatedPOV();
		}
		return;
	}
	if ((int)theKeyData <= 262157)
	{
		if ((int)theKeyData != 196728)
		{
			if ((int)theKeyData != 196730)
			{
				if ((int)theKeyData == 262157)
				{
					MyProject.Forms.MainForm.ToggleFullScreen();
				}
			}
			else if (side_0 == null)
			{
				DarkMessageBox.ShowWarning("You must have a side selected.", "No side selected!");
			}
			else
			{
				((Control)AirTaskingOrderWindow).Show();
			}
		}
		else if (side_0 != null)
		{
			MainForm mainForm3 = MyProject.Forms.MainForm;
			Side theScenObject2 = side_0;
			ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
			List<ActiveUnit> theSelectedActiveUnit = null;
			mainForm3.ShowDoctrineROE(theScenObject2, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: true);
		}
		return;
	}
	if ((int)theKeyData <= 262212)
	{
		switch (theKeyData - 262189)
		{
		default:
			if ((int)theKeyData == 262212)
			{
				((Control)MyProject.Forms.DebugTool).Show();
			}
			break;
		case 0:
			if (AGU_CONFIG.Instance.Enabled)
			{
				CurrentUserAction = UserAction.AddingAggregateUnit;
			}
			break;
		case 4:
			TimeStep_15sec();
			break;
		case 5:
			TimeStep_1min();
			break;
		case 6:
			TimeStep_5min();
			break;
		case 7:
			TimeStep_15min();
			break;
		case 1:
		case 2:
		case 3:
			break;
		}
		return;
	}
	if ((int)theKeyData != 262225)
	{
		if ((int)theKeyData == 262227 && AllowGodModeActions && scenario_0.Sides_ReadOnly.Count() > 1)
		{
			CloseAllOpenWindows(Exclude3DView: true);
			int num = Array.IndexOf(scenario_0.Sides_ReadOnly.OrderBy([SpecialName] (Side theS) => theS.Name).ToArray(), side_0);
			int num2 = ((num != scenario_0.Sides_ReadOnly.Count() - 1) ? (num + 1) : 0);
			scenario_0.SetCurrentSide(scenario_0.Sides_ReadOnly.OrderBy([SpecialName] (Side theS) => theS.Name).ToArray()[num2]);
			if (Realtime)
			{
				RealtimeTerminal.SendSideChange(side_0, CurrentMapProfile, ByPlayer: true);
			}
		}
		return;
	}
	goto IL_15e1;
	IL_02e3:
	if (!Realtime)
	{
		scenario_0.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		MyProject.Forms.MainForm.HandleTimeCompressionChanged();
	}
	else
	{
		MyProject.Forms.MainForm.GameControlBar1.RTMPSetTimeCompression(0);
	}
	return;
	IL_04b7:
	bool flag4 = true;
	if (side_0 == null)
	{
		return;
	}
	foreach (Module_Unit.Unit selectedUnit3 in side_0.SelectedUnits)
	{
		if (selectedUnit3.IsActiveUnit && selectedUnit3.get_UnitSide(SetSideOnly: false) == side_0 && !selectedUnit3.IsWeapon)
		{
			byte? b = (byte?)((ActiveUnit)selectedUnit3).Doctrine.get_WeaponControlStatus_Air(scenario_0, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2));
			if (((!flag2) ?? flag2) == true)
			{
				flag4 = false;
				break;
			}
		}
	}
	if (flag4)
	{
		Doctrine._WCS? theWCS = null;
		WeaponsHold_SelectedUnits(ref theWCS);
	}
	else
	{
		Doctrine._WCS? theWCS = Doctrine._WCS.Hold;
		WeaponsHold_SelectedUnits(ref theWCS);
	}
	return;
	IL_15e1:
	if (CurrentUserAction != UserAction.RPSmartPlacement)
	{
		ActivateRPSmartPlacement(isActive: true);
	}
	return;
	IL_0648:
	if (side_0 == null)
	{
		return;
	}
	bool flag5 = true;
	foreach (Module_Unit.Unit selectedUnit4 in side_0.SelectedUnits)
	{
		if (selectedUnit4.IsActiveUnit && selectedUnit4.get_UnitSide(SetSideOnly: false) == side_0 && !selectedUnit4.IsWeapon)
		{
			byte? b = (byte?)((ActiveUnit)selectedUnit4).Doctrine.get_IgnorePlottedCourse(scenario_0, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			if (((!flag2) ?? flag2) == true)
			{
				flag5 = false;
				break;
			}
		}
	}
	if (flag5)
	{
		Doctrine._UseIgnorePlottedCourse? theIPC = null;
		IgnorePlottedCourse_SelectedUnits(ref theIPC);
	}
	else
	{
		Doctrine._UseIgnorePlottedCourse? theIPC = Doctrine._UseIgnorePlottedCourse.Yes;
		IgnorePlottedCourse_SelectedUnits(ref theIPC);
	}
	return;
	IL_05fc:
	if (Realtime && !AllowEditModeActions)
	{
		OpenChatPanel();
	}
	else
	{
		CopyUnit();
	}
	return;
	IL_031b:
	if (CurrentUserAction == UserAction.DefiningArea_Polygon && PoligonDrawReferencePoints != null && PoligonDrawReferencePoints.Count > 0)
	{
		Side side = side_0;
		if (side != null && side.RefPoints.Count > 0)
		{
			foreach (ReferencePoint item in side_0?.RefPoints)
			{
				item.IsHighlighted = false;
			}
		}
		foreach (ReferencePoint poligonDrawReferencePoint in PoligonDrawReferencePoints)
		{
			poligonDrawReferencePoint.IsHighlighted = true;
			if (Realtime)
			{
				RealtimeTerminal.SendReferencePointUpdate(side_0, poligonDrawReferencePoint);
			}
		}
		if ((int)DarkMessageBox.ShowInformation("Do you want to create a zone entity from this defined area ?", "Creating a standard zone", DarkDialogButton.YesNo) == 6)
		{
			Zone zone = new Zone(InputDialog.CallDialog("Zone name", "Enter zone's name . . .", "New Zone"), PoligonDrawReferencePoints);
			zone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			side_0.StandardZones.Add(zone);
		}
		PoligonDrawReferencePoints = null;
	}
	if (CurrentUserAction != UserAction.None)
	{
		CurrentUserAction = UserAction.None;
	}
	RoadSystemEditor.SelectedRoadNodes.Clear();
	RoadSystemEditor.SelectedRoadSegments.Clear();
	if (RoadSystemEditor.SegmentStartingPoint.HasValue)
	{
		RoadSystemEditor.SegmentStartingPoint = null;
	}
	else
	{
		RoadSystemEditor.DrawSegmentMode = false;
	}
	return;
	IL_1258:
	if (!Information.IsNothing((object)side_0))
	{
		DeleteRefPoint();
	}
	return;
	IL_0aa9:
	if (side_0 == null)
	{
		DarkMessageBox.ShowError("You must have a side selected.", "No side selected!");
	}
	else
	{
		((Control)MissionEditorWindow).Show();
	}
}

using System;
using System.Diagnostics;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void test()
{
	float num = 0.0001f;
	float num2 = 5f;
	float num3 = 0.1f;
	long num4 = 0L;
	long num5 = 0L;
	long num6 = 0L;
	long num7 = 0L;
	long num8 = 0L;
	float num9 = num3;
	bool flag = num9 >= 0f;
	double X = default(double);
	double Y = default(double);
	double LatitudeD = default(double);
	double LongitudeD = default(double);
	for (float num10 = -180f; flag ? (num10 <= 180f) : (num10 >= 180f); num10 += num9)
	{
		float num11 = num3;
		bool flag2 = num11 >= 0f;
		for (float num12 = -90f; (!flag2) ? (num12 >= 90f) : (num12 <= 90f); num12 += num11)
		{
			double num13 = 0.0;
			double num14 = 0.0;
			try
			{
				num13 = Geodesic_Vincenty.ClosureRate(20.0, 15.0, 0.5, 50.0, num12, num10, 0.8, 25.0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				Debugger.Break();
				num7++;
				ProjectData.ClearProjectError();
			}
			try
			{
				num14 = MercatorProjection.ClosureRate_Geocentric(20.0, 15.0, 100.0, 50.0, num10, num12, 100.0, 25.0);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				Debugger.Break();
				num8++;
				ProjectData.ClearProjectError();
			}
			try
			{
				Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(num12, num10);
				tLocalTM.method_0(num12, num10, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false);
				tLocalTM.method_1(X, Y, ref LatitudeD, ref LongitudeD);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				Debugger.Break();
				num5++;
				ProjectData.ClearProjectError();
			}
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num10, num12);
				MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(mercatorPixel.x, mercatorPixel.y);
				if (Math.Abs(LatitudeD - tCoord.Lat) > (double)num)
				{
					num4++;
				}
				if (Math.Abs(LongitudeD - tCoord.Lon) > (double)num)
				{
					num4++;
				}
				if (num13 != 0.0 && Math.Abs(num13 - num14) > (double)num2)
				{
					num4++;
				}
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				Debugger.Break();
				num6++;
				ProjectData.ClearProjectError();
			}
		}
	}
}

using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;

public static void ActivateRPSmartPlacement(bool isActive)
{
	if (scenario_0.Sides_ReadOnly.Count() == 0 || !SimConfiguration.DefaultGamePreferences.AllowSmartRPPlacement)
	{
		return;
	}
	if (isActive)
	{
		Side side = side_0;
		if (side != null && side.RefPoints.Count > 0)
		{
			foreach (ReferencePoint item in side_0?.RefPoints)
			{
				item.IsHighlighted = false;
			}
		}
		SmartRPPlacementReferencePoints = null;
		CurrentUserAction = UserAction.RPSmartPlacement;
		return;
	}
	if (CurrentUserAction == UserAction.RPSmartPlacement && SmartRPPlacementReferencePoints != null && SmartRPPlacementReferencePoints.Count > 0)
	{
		Side side2 = side_0;
		if (side2 != null && side2.RefPoints.Count > 0)
		{
			foreach (ReferencePoint item2 in side_0?.RefPoints)
			{
				item2.IsHighlighted = false;
			}
		}
		foreach (ReferencePoint smartRPPlacementReferencePoint in SmartRPPlacementReferencePoints)
		{
			smartRPPlacementReferencePoint.IsHighlighted = true;
			if (Realtime)
			{
				RealtimeTerminal.SendReferencePointUpdate(side_0, smartRPPlacementReferencePoint);
			}
		}
		Point currentMousePosition = MyProject.Forms.MainForm.CurrentMousePosition;
		if (SmartRPPlacementReferencePoints.Count >= 2)
		{
			((ToolStrip)MyProject.Forms.MainForm.SmartRPControl).Items[0].Enabled = true;
			((ToolStrip)MyProject.Forms.MainForm.SmartRPControl).Items[1].Enabled = true;
		}
		else
		{
			((ToolStrip)MyProject.Forms.MainForm.SmartRPControl).Items[0].Enabled = false;
			((ToolStrip)MyProject.Forms.MainForm.SmartRPControl).Items[1].Enabled = false;
		}
		((ToolStripDropDown)MyProject.Forms.MainForm.SmartRPControl).Show((Control)(object)MyProject.Forms.MainForm.WorldWindow1, currentMousePosition.X, currentMousePosition.Y);
	}
	if (CurrentUserAction != UserAction.None)
	{
		CurrentUserAction = UserAction.None;
	}
	RoadSystemEditor.SelectedRoadNodes.Clear();
	RoadSystemEditor.SelectedRoadSegments.Clear();
	if (!RoadSystemEditor.SegmentStartingPoint.HasValue)
	{
		RoadSystemEditor.DrawSegmentMode = false;
	}
	else
	{
		RoadSystemEditor.SegmentStartingPoint = null;
	}
}

public static void SmartRpPlacement_Clear()
{
	DeleteRefPoint();
}

using System.Drawing;
using Command_Core;

public static void SmartRPPlacement_NewArea(Zone.ZoneType zoneType)
{
	switch (zoneType)
	{
	case Zone.ZoneType.Zone:
	{
		Zone zone = new Zone(InputDialog.CallDialog("Zone name", "Enter zone's name . . .", "New Zone"), SmartRPPlacementReferencePoints);
		zone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		if (!Realtime)
		{
			side_0.StandardZones.Add(zone);
		}
		else
		{
			RealtimeTerminal.SendCreateZone(side_0, zone);
		}
		break;
	}
	case Zone.ZoneType.NoNavZone:
	{
		NoNavZone noNavZone = new NoNavZone(InputDialog.CallDialog("Zone name", "Enter zone's name . . .", "New Zone"), SmartRPPlacementReferencePoints, scenario_0, side_0);
		if (!Realtime)
		{
			side_0.NoNavZones.Add(noNavZone);
		}
		else
		{
			RealtimeTerminal.SendCreateZone(side_0, noNavZone);
		}
		break;
	}
	case Zone.ZoneType.ExclusionZone:
	{
		ExclusionZone exclusionZone = new ExclusionZone(InputDialog.CallDialog("Zone name", "Enter zone's name . . .", "New Zone"), scenario_0, side_0, SmartRPPlacementReferencePoints, Misc.PostureStance.Unknown);
		if (Realtime)
		{
			RealtimeTerminal.SendCreateZone(side_0, exclusionZone);
		}
		else
		{
			side_0.ExclusionZones.Add(exclusionZone);
		}
		break;
	}
	case Zone.ZoneType.CustomEnvironmentZone:
	{
		CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone(InputDialog.CallDialog("Zone name", "Enter zone's name . . .", "New Zone"), SmartRPPlacementReferencePoints, scenario_0, side_0, Weather.DefaultWeather());
		customEnvironmentZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		if (!Realtime)
		{
			ArrayExtensions.Add(ref side_0.CustomEnvironmentZones, customEnvironmentZone);
		}
		else
		{
			RealtimeTerminal.SendCreateZone(side_0, customEnvironmentZone);
		}
		break;
	}
	}
	SmartRPPlacementReferencePoints = null;
}

using Command_Core;

public static void SmartRPPlacement_NewMission(Mission._MissionClass missionClass, GlobalVariables.PatrolType patrolType = GlobalVariables.PatrolType.ASW)
{
	Mission mission = null;
	switch (missionClass)
	{
	case Mission._MissionClass.Patrol:
		mission = new Patrol(side_0, scenario_0, InputDialog.CallDialog("Patrol Name", "Enter new Patrol name . . .", "Patrol Mission " + side_0.Missions.Count), Mission.MissionCategory.Mission, SmartRPPlacementReferencePoints, patrolType, ValidateArea: true);
		break;
	case Mission._MissionClass.Support:
	{
		Side theSide = side_0;
		Scenario theScen = scenario_0;
		SupportMission supportMission = new SupportMission(ref theSide, ref theScen, InputDialog.CallDialog("Support Mission Name", "Enter new Support Mission name . . .", "Support Mission " + side_0.Missions.Count), Mission.MissionCategory.Mission, ref SmartRPPlacementReferencePoints, ValidateArea: true);
		CurrentSide = theSide;
		mission = supportMission;
		break;
	}
	case Mission._MissionClass.Mining:
		mission = new MiningMission(side_0, scenario_0, InputDialog.CallDialog("Mining Mission Name", "Enter new Mining Mission name . . .", "Mining Mission " + side_0.Missions.Count), Mission.MissionCategory.Mission, SmartRPPlacementReferencePoints, ValidateArea: true);
		break;
	case Mission._MissionClass.MineClearing:
		mission = new MineClearingMission(side_0, scenario_0, InputDialog.CallDialog("Mine Clearing Mission Name", "Enter new Mine Clearing Mission name . . .", "Mine Clearing Mission " + side_0.Missions.Count), Mission.MissionCategory.Mission, SmartRPPlacementReferencePoints, ValidateArea: true);
		break;
	case Mission._MissionClass.Cargo:
		mission = new CargoMission(side_0, scenario_0, InputDialog.CallDialog("Cargo Mission Name", "Enter new Cargo Mission name . . .", "Cargo Mission " + side_0.Missions.Count), Mission.MissionCategory.Mission, SmartRPPlacementReferencePoints, ValidateArea: true);
		break;
	}
	if (mission != null && Realtime)
	{
		RealtimeTerminal.SendCreateMission(mission, openMissionEditor: false, string.Empty);
		Mission mission2 = mission;
		Scenario theScen = scenario_0;
		Side theSide = side_0;
		mission2.DeleteMission(ref theScen, ref theSide);
		CurrentSide = theSide;
	}
	SmartRPPlacementReferencePoints = null;
}

using System.Collections.Generic;
using Command_Core;

public static void ReturnToBase(Module_Unit.Unit Unit = null)
{
	if (side_0 == null)
	{
		return;
	}
	if (Unit == null)
	{
		if (side_0.SelectedUnits.Count != 0)
		{
			DispatchSimpleUnitActionMultipleUnits(side_0.SelectedUnits, SimpleUnitAction.ReturnToBase);
		}
	}
	else
	{
		DispatchSimpleUnitActionMultipleUnits(new List<Module_Unit.Unit> { Unit }, SimpleUnitAction.ReturnToBase);
	}
}

public static void UnassignUnitsAndDisengage()
{
	if (side_0 != null && side_0.SelectedUnits.Count != 0)
	{
		DispatchSimpleUnitActionMultipleUnits(side_0.SelectedUnits, SimpleUnitAction.UnassignUnitsAndDisengage);
	}
}

using Command_Core;

public static void RemoveUnitFromMission(ref ActiveUnit theAU)
{
	DispatchSimpleUnitAction(theAU, SimpleUnitAction.RemoveUnitFromMission);
}

using Command_Core;
using Command.My;

public static void ToggleDistanceMeasure()
{
	SelectedRefPoint = null;
	if (CurrentUserAction == UserAction.MeasuringDistance)
	{
		MyProject.Forms.MainForm.StartOfMeasurement = default(Geopoint_Struct);
		CurrentUserAction = UserAction.None;
	}
	else
	{
		MyProject.Forms.MainForm.StartOfMeasurement = default(Geopoint_Struct);
		CurrentUserAction = UserAction.MeasuringDistance;
	}
}

public static void DeployDippingSonar()
{
	DispatchSimpleUnitAction(SelectedUnit, SimpleUnitAction.DeployDippingSonar);
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic;

public static void HoldPosition(ref bool MenuItemChecked)
{
	if (Information.IsNothing((object)side_0) || Information.IsNothing((object)SelectedUnit) || side_0.SelectedUnits.Count == 0)
	{
		return;
	}
	MenuItemChecked = !MenuItemChecked;
	List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		if (selectedUnit.IsActiveUnit && selectedUnit.get_UnitSide(SetSideOnly: false) == side_0 && ((selectedUnit.IsFacility && !((Facility)selectedUnit).IsFixedFacility) || selectedUnit.IsMobileGroundUnit))
		{
			list.Add(selectedUnit);
		}
	}
	if (list.Any())
	{
		if (!MenuItemChecked)
		{
			DispatchSimpleUnitActionMultipleUnits(list, SimpleUnitAction.HoldPositionOff);
		}
		else
		{
			DispatchSimpleUnitActionMultipleUnits(list, SimpleUnitAction.HoldPositionOn);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic;

public static void HoldPositionAllUnits(ref bool MenuItemChecked)
{
	if (Information.IsNothing((object)side_0) || side_0.Units.Count == 0)
	{
		return;
	}
	MenuItemChecked = !MenuItemChecked;
	List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
	foreach (ActiveUnit unit in side_0.Units)
	{
		if (unit.IsActiveUnit && ((Module_Unit.Unit)unit).get_UnitSide(SetSideOnly: false) == side_0 && ((unit.IsFacility && !((Facility)unit).IsFixedFacility) || unit.IsMobileGroundUnit))
		{
			list.Add(unit);
		}
	}
	if (list.Any())
	{
		if (MenuItemChecked)
		{
			DispatchSimpleUnitActionMultipleUnits(list, SimpleUnitAction.HoldPositionOn);
		}
		else
		{
			DispatchSimpleUnitActionMultipleUnits(list, SimpleUnitAction.HoldPositionOff);
		}
	}
}

public static void DropSelectedContacts()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(side_0.SelectedUnits, SimpleContactAction.Drop);
	}
}

using System.Windows.Forms;
using Command_Core;

public static void ShowWeaponDetails()
{
	if (SelectedUnit != null && !SelectedUnit.IsGroup && SelectedUnit.IsActiveUnit)
	{
		Side theSide = side_0;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string ReasonWhyNot = null;
		if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
		{
			theWeaponsWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
			((Control)theWeaponsWindow).Show();
		}
	}
}

using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;

public static void ShowCommsDetails()
{
	if (SelectedUnit != null && !SelectedUnit.IsGroup && SelectedUnit.IsActiveUnit)
	{
		Side theSide = side_0;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string ReasonWhyNot = null;
		if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) && (Information.IsNothing((object)theCommsWindow) || !((Control)theCommsWindow).Visible))
		{
			theCommsWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
			smethod_5(new UnitComms());
			((Control)theCommsWindow).Show();
		}
	}
}

public static void DetachUnits()
{
	if (side_0 != null)
	{
		DispatchSimpleUnitActionMultipleUnits(side_0.SelectedUnits, SimpleUnitAction.Detach);
	}
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic;

public static void SelectNextUnit()
{
	if (!Information.IsNothing((object)side_0) && CurrentUserAction == UserAction.None)
	{
		List<Module_Unit.Unit> list = MapVisibleUnits.ToList();
		if (list.Count > 0)
		{
			Module_Unit.Unit theUnit = ((Information.IsNothing((object)SelectedUnit) || !list.Contains(SelectedUnit)) ? list[0] : ((list.IndexOf(SelectedUnit) != list.Count - 1) ? list[list.IndexOf(SelectedUnit) + 1] : list[0]));
			side_0.SelectedUnits_Clear();
			list.Clear();
			list = null;
			SelectThisUnit(theUnit, ThisUnitOnly: true);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic;

public static void SelectPreviousUnit()
{
	if (!Information.IsNothing((object)side_0))
	{
		List<Module_Unit.Unit> list = MapVisibleUnits.ToList();
		if (list.Count > 0)
		{
			Module_Unit.Unit theUnit = ((Information.IsNothing((object)SelectedUnit) || !list.Contains(SelectedUnit)) ? list[list.Count - 1] : ((list.IndexOf(SelectedUnit) == 0) ? list[list.Count - 1] : list[list.IndexOf(SelectedUnit) - 1]));
			side_0.SelectedUnits_Clear();
			list.Clear();
			list = null;
			SelectThisUnit(theUnit, ThisUnitOnly: true);
		}
	}
}

using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void RenameUnitOrContact()
{
	//IL_0054: Unknown result type (might be due to invalid IL or missing references)
	if (Information.IsNothing((object)side_0) || CurrentUserAction != UserAction.None)
	{
		return;
	}
	if (side_0.SelectedUnits.Count == 1)
	{
		if (!Information.IsNothing((object)SelectedUnit))
		{
			MyProject.Forms.RenameObject.RenamingOption = RenameObject.E_RenamingOption.Unit;
			((Form)MyProject.Forms.RenameObject).ShowDialog();
		}
	}
	else if (side_0.SelectedUnits.Count > 1)
	{
		scenario_0.AddMessage("Can only rename one unit, group or contact at a time.", null, LoggedMessage.MessageType.SpecialMessage, 1, null, side_0);
	}
	else
	{
		scenario_0.AddMessage("Select a unit, group or contact to rename.", null, LoggedMessage.MessageType.SpecialMessage, 1, null, side_0);
	}
}

using System.Linq;
using Command_Core;
using Command.My;

public static void GodsEyeView()
{
	if (scenario_0.Sides_ReadOnly.Count() == 0)
	{
		return;
	}
	bool godsEye;
	if (godsEye = CurrentMapProfile.GodsEye)
	{
		if (godsEye)
		{
			CurrentMapProfile.GodsEye = false;
			scenario_0.AddMessage("GOD'S EYE DISABLED.", "GOD'S EYE", LoggedMessage.MessageType.UI, 5, null, side_0);
		}
	}
	else
	{
		CurrentMapProfile.GodsEye = true;
		scenario_0.AddMessage("GOD'S EYE ENABLED.", "GOD'S EYE", LoggedMessage.MessageType.UI, 5, null, side_0);
	}
	MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	MustRefreshMainForm = true;
	if (Realtime)
	{
		RealtimeTerminal.SendSideChange(side_0, CurrentMapProfile, ByPlayer: true);
	}
}

using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void RenameRefPoint()
{
	//IL_0040: Unknown result type (might be due to invalid IL or missing references)
	if (!Information.IsNothing((object)side_0) && CurrentUserAction == UserAction.None)
	{
		if (HighlightedRefPoints.Count == 1)
		{
			MyProject.Forms.RenameObject.RenamingOption = RenameObject.E_RenamingOption.ReferencePoint;
			((Form)MyProject.Forms.RenameObject).ShowDialog();
		}
		else if (HighlightedRefPoints.Count <= 1)
		{
			scenario_0.AddMessage("Select a reference point to rename.", null, LoggedMessage.MessageType.SpecialMessage, 1, null, side_0);
		}
		else
		{
			scenario_0.AddMessage("Can only rename one reference point at a time. Deselect all reference points but one.", null, LoggedMessage.MessageType.SpecialMessage, 1, null, side_0);
		}
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void Set_UnitIsSpotted()
{
	if (CurrentGame.GameMode != Game._GameMode.ScenEdit || Information.IsNothing((object)side_0) || side_0.SelectedUnits.Count == 0)
	{
		return;
	}
	ActiveUnit activeUnit = default(ActiveUnit);
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		if (selectedUnit.IsWeapon)
		{
			continue;
		}
		if (!selectedUnit.IsContact())
		{
			if (selectedUnit.IsActiveUnit)
			{
				activeUnit = (ActiveUnit)selectedUnit;
			}
		}
		else
		{
			activeUnit = ((Contact)selectedUnit).ActualUnit;
		}
		if (activeUnit != null)
		{
			string name = activeUnit.SubTypeDescription + " " + activeUnit.UnitType_String + " at " + scenario_0.Time.ToShortDateString() + "-" + scenario_0.Time.ToShortTimeString();
			ReferencePoint referencePoint = new ReferencePoint(selectedUnit.get_Longitude((GlobalVariables.BooleanObject)null), selectedUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			referencePoint.Name = name;
			referencePoint.IsHighlighted = true;
			side_0.RefPoints.Add(referencePoint);
			MustRefreshMainForm = true;
			continue;
		}
		break;
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void CloneUnit()
{
	if (!Information.IsNothing((object)side_0) && AllowEditModeActions)
	{
		SelectedRefPoint = null;
		if (!Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit && ((ActiveUnit)SelectedUnit).get_UnitSide(SetSideOnly: false) == side_0)
		{
			CurrentUserAction = UserAction.CloningAUnit;
		}
	}
}

using Microsoft.VisualBasic;

public static void CopyUnit()
{
	if (!Information.IsNothing((object)side_0) && AllowEditModeActions)
	{
		SelectedRefPoint = null;
		if (!Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit)
		{
			CurrentUserAction = UserAction.CopyingAUnit;
		}
	}
}

using System.Text;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using ServiceStack.Text;

public static void CopyGUID()
{
	StringBuilder stringBuilder = StringBuilderCache.Allocate();
	bool flag = false;
	Side side = side_0;
	if (side != null && side.SelectedUnits.Count > 0)
	{
		foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
		{
			if (!Information.IsNothing((object)selectedUnit))
			{
				if (flag)
				{
					stringBuilder.Append(" , ");
				}
				stringBuilder.Append("{name='" + selectedUnit.Name.ToString() + "', guid='" + selectedUnit.ObjectID + "'}");
				flag = true;
			}
		}
		Clipboard.SetText(stringBuilder.ToString());
	}
	StringBuilderCache.Free(stringBuilder);
}

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

public static void CopyRefPoints()
{
	if (side_0 == null)
	{
		return;
	}
	StringBuilder stringBuilder = StringBuilderCache.Allocate();
	bool flag = false;
	_ = side_0.RefPoints;
	List<ReferencePoint> highlightedRefPoints = HighlightedRefPoints;
	if (highlightedRefPoints.Count > 0)
	{
		foreach (ReferencePoint item in highlightedRefPoints)
		{
			if (item == null)
			{
				if (flag)
				{
					stringBuilder.Append(" , ");
				}
				stringBuilder.Append("{name='" + item.Name.ToString() + "', guid='" + item.ObjectID + "', latitude='" + Conversions.ToString(item.Latitude) + "', longitude='" + Conversions.ToString(item.Longitude) + "'}");
				flag = true;
			}
		}
		Clipboard.SetText(stringBuilder.ToString());
	}
	StringBuilderCache.Free(stringBuilder);
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void AttackTarget_Auto()
{
	//IL_0026: Unknown result type (might be due to invalid IL or missing references)
	if (Information.IsNothing((object)side_0))
	{
		return;
	}
	if (CurrentMapProfile.GodsEye)
	{
		DarkMessageBox.ShowError("You cannot order an attack while using God's Eye mode!", "");
		return;
	}
	try
	{
		if (side_0.SelectedUnits.Count == 0)
		{
			return;
		}
		using IEnumerator<Module_Unit.Unit> enumerator = side_0.SelectedUnits.GetEnumerator();
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Module_Unit.Unit current = enumerator.Current;
				string ReasonWhyNot = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(side_0, current, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
				{
					break;
				}
				if (current.IsActiveUnit)
				{
					((ActiveUnit)current).AddMessage(current.Name + " cannot participate in attack (" + ReasonWhyNot + ")", current.Name + " cannot join attack", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(current.get_Longitude((GlobalVariables.BooleanObject)null), current.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				continue;
			}
			return;
		}
		CurrentUserAction = UserAction.TargetingContact_AutoEngage;
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 101140", "");
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void AttackTarget_Manual()
{
	//IL_0166: Unknown result type (might be due to invalid IL or missing references)
	if (Information.IsNothing((object)side_0))
	{
		return;
	}
	if (!CurrentMapProfile.GodsEye)
	{
		try
		{
			if (side_0.SelectedUnits.Count != 0)
			{
				using (IEnumerator<Module_Unit.Unit> enumerator = side_0.SelectedUnits.GetEnumerator())
				{
					int currentUserAction;
					while (true)
					{
						if (!enumerator.MoveNext())
						{
							return;
						}
						Module_Unit.Unit current = enumerator.Current;
						string ReasonWhyNot = null;
						if (GameGeneral.CanIssueOrdersToThisUnit(side_0, current, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
						{
							if (!current.IsWeapon)
							{
								currentUserAction = 17;
								break;
							}
							if (current.IsWeapon & ((Weapon)current).IsWeaponPallet)
							{
								currentUserAction = 17;
								break;
							}
						}
						else if (current.IsActiveUnit && !string.IsNullOrEmpty(ReasonWhyNot))
						{
							((ActiveUnit)current).AddMessage(current.Name + " cannot participate in attack (" + ReasonWhyNot + ")", current.Name + " cannot join attack", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(current.get_Longitude((GlobalVariables.BooleanObject)null), current.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					CurrentUserAction = (UserAction)currentUserAction;
					return;
				}
			}
			return;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101141", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return;
		}
	}
	DarkMessageBox.ShowError("You cannot order an attack While Using God's Eye mode!", "");
}

using System.Windows.Forms;
using Command_Core;
using Command.My;

public static void EditFormation()
{
	if (SelectedUnit == null || SelectedUnit.get_UnitSide(SetSideOnly: false) != side_0)
	{
		return;
	}
	Side theSide = side_0;
	Module_Unit.Unit selectedUnit = SelectedUnit;
	string ReasonWhyNot = null;
	if (GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) && (SelectedUnit.IsGroup || (SelectedUnit.IsActiveUnit && ((ActiveUnit)SelectedUnit).get_ParentGroup(UsingMissionPlanner: false) != null)))
	{
		MyProject.Forms.MainForm.CameraAltitude = 20000;
		MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(SelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null), SelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		if (SelectedUnit.IsGroup)
		{
			MyProject.Forms.FormationEditor.SelectedGroup = (Group)SelectedUnit;
		}
		else
		{
			MyProject.Forms.FormationEditor.SelectedGroup = ((ActiveUnit)SelectedUnit).get_ParentGroup(UsingMissionPlanner: false);
		}
		((Control)MyProject.Forms.FormationEditor).Show();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static void smethod_31()
{
	//IL_00da: Unknown result type (might be due to invalid IL or missing references)
	if (side_0 == null)
	{
		return;
	}
	if (!CurrentMapProfile.GodsEye)
	{
		try
		{
			if (side_0.SelectedUnits.Count != 0)
			{
				using (IEnumerator<Module_Unit.Unit> enumerator = side_0.SelectedUnits.GetEnumerator())
				{
					Module_Unit.Unit current;
					Side theSide;
					string ReasonWhyNot;
					do
					{
						if (!enumerator.MoveNext())
						{
							return;
						}
						current = enumerator.Current;
						theSide = side_0;
						ReasonWhyNot = null;
					}
					while (!GameGeneral.CanIssueOrdersToThisUnit(theSide, current, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID) || current.IsWeapon);
					CurrentUserAction = UserAction.const_18;
					return;
				}
			}
			return;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101142", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return;
		}
	}
	DarkMessageBox.ShowError("You cannot order an attack while using God's Eye mode!", "Error");
}

using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void ShowAirOps()
{
	MyProject.Forms.AirOps.SelectedHosts_IDs.Clear();
	if (side_0 == null)
	{
		return;
	}
	if (((Control)MyProject.Forms.AirOps).Visible)
	{
		((Form)MyProject.Forms.AirOps).Close();
	}
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		if (Information.IsNothing((object)selectedUnit) || !selectedUnit.IsActiveUnit)
		{
			continue;
		}
		if (selectedUnit.IsGroup && ((Group)selectedUnit).Type == Group.GroupType.SurfaceGroup)
		{
			foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
			{
				if (value.AirFacilities_ReadOnly.Length > 0)
				{
					MyProject.Forms.AirOps.SelectedHosts_IDs.Add(value.ObjectID);
				}
			}
		}
		else if (((ActiveUnit)selectedUnit).AirFacilities_ReadOnly.Length > 0)
		{
			MyProject.Forms.AirOps.SelectedHosts_IDs.Add(selectedUnit.ObjectID);
		}
	}
	if (MyProject.Forms.AirOps.SelectedHosts_IDs.Count <= 0 && !Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit)
	{
		if (SelectedUnit.IsGroup && ((Group)SelectedUnit).Type == Group.GroupType.SurfaceGroup)
		{
			foreach (ActiveUnit value2 in ((Group)SelectedUnit).Units.Values)
			{
				if (value2.AirFacilities_ReadOnly.Length > 0)
				{
					MyProject.Forms.AirOps.SelectedHosts_IDs.Add(value2.ObjectID);
				}
			}
		}
		else if (((ActiveUnit)SelectedUnit).AirFacilities_ReadOnly.Length > 0)
		{
			MyProject.Forms.AirOps.SelectedHosts_IDs.Add(SelectedUnit.ObjectID);
		}
	}
	if (MyProject.Forms.AirOps.SelectedHosts_IDs.Count <= 0)
	{
		if (AllowEditModeActions && side_0.SelectedUnits.Count == 1 && side_0.SelectedUnits.First().IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)side_0.SelectedUnits.First();
			MyProject.Forms.AirOps.SelectedHosts_IDs.Add(activeUnit.ObjectID);
			((TabControl)MyProject.Forms.AirOps.TabControl1).SelectTab(1);
			((Control)MyProject.Forms.AirOps).Show();
		}
	}
	else
	{
		((Control)MyProject.Forms.AirOps).Show();
	}
}

using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void ShowDockingOps()
{
	MyProject.Forms.DockingOps.SelectedHosts.Clear();
	if (side_0 == null)
	{
		return;
	}
	if (((Control)MyProject.Forms.DockingOps).Visible)
	{
		((Form)MyProject.Forms.DockingOps).Close();
	}
	foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
	{
		if (Information.IsNothing((object)selectedUnit) || !selectedUnit.IsActiveUnit)
		{
			continue;
		}
		if (selectedUnit.IsGroup && (((Group)selectedUnit).Type == Group.GroupType.SurfaceGroup || ((Group)selectedUnit).Type == Group.GroupType.SubGroup))
		{
			foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
			{
				if (value.DockFacilities_ReadOnly.Length > 0)
				{
					MyProject.Forms.DockingOps.SelectedHosts.Add(value);
				}
			}
		}
		else if (((ActiveUnit)selectedUnit).DockFacilities_ReadOnly.Length > 0)
		{
			MyProject.Forms.DockingOps.SelectedHosts.Add((ActiveUnit)selectedUnit);
		}
	}
	if (MyProject.Forms.DockingOps.SelectedHosts.Count <= 0 && !Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit)
	{
		if (SelectedUnit.IsGroup && (((Group)SelectedUnit).Type == Group.GroupType.SurfaceGroup || ((Group)SelectedUnit).Type == Group.GroupType.SubGroup))
		{
			foreach (ActiveUnit value2 in ((Group)SelectedUnit).Units.Values)
			{
				if (value2.DockFacilities_ReadOnly.Length > 0)
				{
					MyProject.Forms.DockingOps.SelectedHosts.Add(value2);
				}
			}
		}
		else if (((ActiveUnit)SelectedUnit).DockFacilities_ReadOnly.Length > 0)
		{
			MyProject.Forms.DockingOps.SelectedHosts.Add((ActiveUnit)SelectedUnit);
		}
	}
	if (MyProject.Forms.DockingOps.SelectedHosts.Count <= 0)
	{
		if (AllowEditModeActions && side_0.SelectedUnits.Count == 1 && side_0.SelectedUnits.First().IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)side_0.SelectedUnits.First();
			MyProject.Forms.DockingOps.SelectedHosts.Add(activeUnit);
			((TabControl)MyProject.Forms.DockingOps.TabControl1).SelectTab(1);
			((Control)MyProject.Forms.DockingOps).Show();
			MyProject.Forms.AddHostingFacility.Mode = 1;
			MyProject.Forms.AddHostingFacility.ParentForm = (Form)(object)MyProject.Forms.DockingOps;
			MyProject.Forms.AddHostingFacility.theSelectedUnit = activeUnit;
			((Control)MyProject.Forms.AddHostingFacility).Show();
		}
	}
	else
	{
		((Control)MyProject.Forms.DockingOps).Show();
	}
}

using System.Linq;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;

public static void ShowSensorsForSelectedUnit()
{
	if (Information.IsNothing((object)SelectedUnit) || !SelectedUnit.IsActiveUnit)
	{
		return;
	}
	Side theSide = side_0;
	Module_Unit.Unit selectedUnit = SelectedUnit;
	string ReasonWhyNot = null;
	if (!GameGeneral.CanIssueOrdersToThisUnit(theSide, selectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, CurrentMapProfile.IsolatedPOVObjectID))
	{
		return;
	}
	if (Information.IsNothing((object)waypoint_0))
	{
		if ((!SelectedUnit.IsWeapon || !Information.IsNothing((object)((Weapon)SelectedUnit).DataLinkParent)) && SelectedUnit.get_UnitSide(SetSideOnly: false) == side_0)
		{
			if (side_0.SelectedUnits.Count > 1)
			{
				MyProject.Forms.MultipleUnitSensors.SelectedUnits = side_0.SelectedUnits.ToList();
				((Control)MyProject.Forms.MultipleUnitSensors).Show();
			}
			else if (!SelectedUnit.IsGroup)
			{
				OpenSensorsWindow();
			}
			else
			{
				MyProject.Forms.MultipleUnitSensors.SelectedUnits = ((Group)SelectedUnit).ToList();
				((Control)MyProject.Forms.MultipleUnitSensors).Show();
			}
		}
	}
	else
	{
		((Control)MyProject.Forms.MultipleUnitSensors).Show();
	}
}

using Microsoft.VisualBasic;

public static void MoveUnit()
{
	if (AllowEditModeActions)
	{
		SelectedRefPoint = null;
		if (CurrentUserAction == UserAction.None && !Information.IsNothing((object)SelectedUnit))
		{
			CurrentUserAction = UserAction.const_11;
		}
	}
}

using Command_Core;
using DarkUI.Collections;
using Microsoft.VisualBasic;

public static void DeleteRefPoint()
{
	if (Information.IsNothing((object)side_0))
	{
		return;
	}
	ObservableList<ReferencePoint> refPoints = side_0.RefPoints;
	foreach (ReferencePoint highlightedRefPoint in HighlightedRefPoints)
	{
		if (!highlightedRefPoint.IsLocked)
		{
			if (Realtime)
			{
				RealtimeTerminal.SendDeleteReferencePoint(side_0, highlightedRefPoint);
			}
			else
			{
				refPoints.Remove(highlightedRefPoint);
			}
		}
	}
	SelectedRefPoint = null;
	MustRefreshMainForm = true;
}

public static void MarkContactHostile()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(side_0.SelectedUnits, SimpleContactAction.MarkHostile);
	}
}

public static void MarkContactUnfriendly()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(side_0.SelectedUnits, SimpleContactAction.MarkUnfriendly);
	}
}

public static void MarkContactNeutral()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(side_0.SelectedUnits, SimpleContactAction.MarkNeutral);
	}
}

public static void MarkContactFriendly()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(side_0.SelectedUnits, SimpleContactAction.MarkFriendly);
	}
}

using System.Collections.Generic;
using Command_Core;

public static void MarkContactPosition()
{
	if (side_0 != null && SelectedUnit != null && SelectedUnit.IsContact())
	{
		DispatchSimpleContactActionMultipleContacts(new List<Module_Unit.Unit> { SelectedUnit }, SimpleContactAction.MarkPosition);
	}
}

using System.Collections.Generic;
using Command_Core;

public static void ToggleContactFilteredOutStatus()
{
	if (SelectedUnit != null && SelectedUnit.IsContact())
	{
		DispatchSimpleContactActionMultipleContacts(new List<Module_Unit.Unit> { SelectedUnit }, SimpleContactAction.ToggleFilteredOutStatus);
	}
}

using System.Collections.Generic;
using Command_Core;

public static void FilterOutAllContactsOn()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(new List<Module_Unit.Unit>(), SimpleContactAction.FilterOutAllOn);
	}
}

using System.Collections.Generic;
using Command_Core;

public static void FilterOutAllContactsOff()
{
	if (side_0 != null)
	{
		DispatchSimpleContactActionMultipleContacts(new List<Module_Unit.Unit>(), SimpleContactAction.FilterOutAllOff);
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void IgnorePlottedCourse_SelectedUnits(ref Doctrine._UseIgnorePlottedCourse? theIPC)
{
	if (side_0.SelectedUnits.Count > 0)
	{
		foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && selectedUnit.get_UnitSide(SetSideOnly: false) == side_0 && !selectedUnit.IsWeapon)
			{
				Doctrine doctrine = ((ActiveUnit)selectedUnit).Doctrine;
				if (doctrine.get_IgnorePlottedCourse_PlayerEditable(scenario_0))
				{
					bool? viaMainForm = false;
					if (!Information.IsNothing((object)SelectedUnit) && selectedUnit == SelectedUnit)
					{
						viaMainForm = true;
					}
					doctrine.set_IgnorePlottedCourse(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theIPC);
					if (Realtime)
					{
						RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine, (ActiveUnit)selectedUnit);
					}
				}
			}
		}
		return;
	}
	if (Information.IsNothing((object)SelectedUnit) || !SelectedUnit.IsActiveUnit || SelectedUnit.get_UnitSide(SetSideOnly: false) != side_0 || SelectedUnit.IsWeapon)
	{
		return;
	}
	Doctrine doctrine2 = ((ActiveUnit)SelectedUnit).Doctrine;
	if (doctrine2.get_IgnorePlottedCourse_PlayerEditable(scenario_0))
	{
		doctrine2.set_IgnorePlottedCourse(scenario_0, MultipleUnits: false, (bool?)true, ViaDoctrineForm: false, ViaRightColumn: false, theIPC);
		if (Realtime)
		{
			RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine2, (ActiveUnit)SelectedUnit);
		}
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void IgnorePlottedCourse_AllUnits(ref Doctrine._UseIgnorePlottedCourse? theIPC)
{
	if (Information.IsNothing((object)side_0))
	{
		return;
	}
	foreach (ActiveUnit unit in side_0.Units)
	{
		if (!unit.IsActiveUnit || ((Module_Unit.Unit)unit).get_UnitSide(SetSideOnly: false) != side_0 || unit.IsWeapon)
		{
			continue;
		}
		Doctrine doctrine = unit.Doctrine;
		if (doctrine.get_IgnorePlottedCourse_PlayerEditable(scenario_0))
		{
			bool? viaMainForm = false;
			if (!Information.IsNothing((object)SelectedUnit) && unit == SelectedUnit)
			{
				viaMainForm = true;
			}
			doctrine.set_IgnorePlottedCourse(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theIPC);
			if (Realtime)
			{
				RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine, unit);
			}
		}
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void WeaponsHold_AllUnits(ref Doctrine._WCS? theWCS)
{
	if (side_0.Units.Count == 0)
	{
		return;
	}
	foreach (ActiveUnit unit in side_0.Units)
	{
		if (unit.IsActiveUnit && ((Module_Unit.Unit)unit).get_UnitSide(SetSideOnly: false) == side_0 && !unit.IsWeapon)
		{
			bool? viaMainForm = false;
			if (!Information.IsNothing((object)SelectedUnit) && unit == SelectedUnit)
			{
				viaMainForm = true;
			}
			Doctrine doctrine = unit.Doctrine;
			if (doctrine.get_WeaponControlStatus_Air_PlayerEditable(scenario_0))
			{
				doctrine.set_WeaponControlStatus_Air(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
			}
			if (doctrine.get_WeaponControlStatus_Surface_PlayerEditable(scenario_0))
			{
				doctrine.set_WeaponControlStatus_Surface(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
			}
			if (doctrine.get_WeaponControlStatus_Submarine_PlayerEditable(scenario_0))
			{
				doctrine.set_WeaponControlStatus_Submarine(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
			}
			if (doctrine.get_WeaponControlStatus_Land_PlayerEditable(scenario_0))
			{
				doctrine.set_WeaponControlStatus_Land(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
			}
			if (Realtime)
			{
				RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine, unit);
			}
		}
	}
}

using Command_Core;
using Microsoft.VisualBasic;

public static void WeaponsHold_SelectedUnits(ref Doctrine._WCS? theWCS)
{
	if (Information.IsNothing((object)side_0))
	{
		return;
	}
	if (side_0.SelectedUnits.Count > 0)
	{
		foreach (Module_Unit.Unit selectedUnit in side_0.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && selectedUnit.get_UnitSide(SetSideOnly: false) == side_0 && !selectedUnit.IsWeapon)
			{
				bool? viaMainForm = false;
				if (!Information.IsNothing((object)SelectedUnit) && selectedUnit == SelectedUnit)
				{
					viaMainForm = true;
				}
				Doctrine doctrine = ((ActiveUnit)selectedUnit).Doctrine;
				if (doctrine.get_WeaponControlStatus_Air_PlayerEditable(scenario_0))
				{
					doctrine.set_WeaponControlStatus_Air(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
				}
				if (doctrine.get_WeaponControlStatus_Surface_PlayerEditable(scenario_0))
				{
					doctrine.set_WeaponControlStatus_Surface(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
				}
				if (doctrine.get_WeaponControlStatus_Submarine_PlayerEditable(scenario_0))
				{
					doctrine.set_WeaponControlStatus_Submarine(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
				}
				if (doctrine.get_WeaponControlStatus_Land_PlayerEditable(scenario_0))
				{
					doctrine.set_WeaponControlStatus_Land(scenario_0, MultipleUnits: false, viaMainForm, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
				}
				if (Realtime)
				{
					RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine, (ActiveUnit)selectedUnit);
				}
			}
		}
		return;
	}
	if (!Information.IsNothing((object)SelectedUnit) && SelectedUnit.IsActiveUnit && SelectedUnit.get_UnitSide(SetSideOnly: false) == side_0 && !SelectedUnit.IsWeapon)
	{
		Doctrine doctrine2 = ((ActiveUnit)SelectedUnit).Doctrine;
		if (doctrine2.get_WeaponControlStatus_Air_PlayerEditable(scenario_0))
		{
			doctrine2.set_WeaponControlStatus_Air(scenario_0, MultipleUnits: false, (bool?)true, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
		}
		if (doctrine2.get_WeaponControlStatus_Surface_PlayerEditable(scenario_0))
		{
			doctrine2.set_WeaponControlStatus_Surface(scenario_0, MultipleUnits: false, (bool?)true, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
		}
		if (doctrine2.get_WeaponControlStatus_Submarine_PlayerEditable(scenario_0))
		{
			doctrine2.set_WeaponControlStatus_Submarine(scenario_0, MultipleUnits: false, (bool?)true, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
		}
		if (doctrine2.get_WeaponControlStatus_Land_PlayerEditable(scenario_0))
		{
			doctrine2.set_WeaponControlStatus_Land(scenario_0, MultipleUnits: false, (bool?)true, ViaDoctrineForm: false, ViaRightColumn: false, theWCS);
		}
		if (Realtime)
		{
			RealtimeTerminal.PollForLocalDoctrineStateChange(doctrine2, (ActiveUnit)SelectedUnit);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void DeselectAllUnits(List<Module_Unit.Unit> except)
{
	MainForm.POVString = "";
	if (side_0 == null)
	{
		return;
	}
	foreach (Module_Unit.Unit item in side_0.SelectedUnits.ToList())
	{
		if (except != null && except.Count > 0)
		{
			foreach (Module_Unit.Unit item2 in except)
			{
				Operators.CompareString(item.ObjectID, item2.ObjectID, true);
			}
			side_0.SelectedUnits_Remove(item);
		}
		if (except == null || except.Count == 0)
		{
			SelectThisUnit(null, ThisUnitOnly: true, clearWaypointSelection: false);
		}
	}
	smethod_32();
}

using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_32()
{
	if (GameGeneral.Beta_PlatformComms & scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
	{
		if (SelectedUnit == null)
		{
			smethod_33();
		}
		else if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticOrderChain))
		{
			if (side_0.HQ_ID == null)
			{
				MainForm.POVString = "Viewing map from " + SelectedUnit.Name + " Perspective";
			}
			else if (Operators.CompareString(SelectedUnit.ObjectID, side_0.HQ_ID, true) != 0)
			{
				MainForm.POVString = "Viewing map from " + SelectedUnit.Name + " Perspective";
			}
			else
			{
				MainForm.POVString = "Viewing map from designated HQ Perspective " + SelectedUnit.Name;
			}
		}
		else
		{
			MainForm.POVString = "Viewing map from " + SelectedUnit.Name + " Perspective";
		}
	}
	else
	{
		MainForm.POVString = "";
	}
}

using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_33()
{
	if (!scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticOrderChain))
	{
		MainForm.POVString = "Viewing map from global perspective";
		return;
	}
	if (side_0.HQ_ID == null)
	{
		MainForm.POVString = "HQ Destroyed or not set";
		return;
	}
	ActiveUnit activeUnit = side_0.Units.Where([SpecialName] (ActiveUnit theU) => Operators.CompareString(theU.ObjectID, CurrentSide.HQ_ID, true) == 0).FirstOrDefault();
	if (activeUnit != null)
	{
		MainForm.POVString = "Viewing map from designated HQ Perspective " + activeUnit.Name;
	}
	else
	{
		MainForm.POVString = "HQ Destroyed or not set";
	}
}

using Command_Core;

public static void DeselectThisUnit(Module_Unit.Unit theUnit)
{
	if (side_0.SelectedUnits.Contains(theUnit))
	{
		side_0.SelectedUnits_Remove(theUnit);
		SelectThisUnit(null, ThisUnitOnly: true);
	}
}

using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;

public static void OpenSensorsWindow()
{
	if (!Information.IsNothing((object)SelectedUnit) && (!SelectedUnit.IsWeapon || !Information.IsNothing((object)((Weapon)SelectedUnit).DataLinkParent)) && (Information.IsNothing((object)theSensorsWindow) || !((Control)theSensorsWindow).Visible))
	{
		smethod_4(new UnitSensors());
		((Control)theSensorsWindow).Show();
	}
}

using System.Windows.Forms;
using Command.My;

public static void OpenChatPanel()
{
	if ((Realtime && MyProject.Forms.m_RealtimeChatInputBar == null) || !((Control)MyProject.Forms.RealtimeChatInputBar).Visible)
	{
		((Form)MyProject.Forms.RealtimeChatInputBar).Show((IWin32Window)(object)MyProject.Forms.MainForm);
	}
}

using System.Windows.Forms;
using Command.My;

public static void CloseChatPanel()
{
	if (MyProject.Forms.m_RealtimeChatInputBar != null && ((Control)MyProject.Forms.RealtimeChatInputBar).Visible)
	{
		((Form)MyProject.Forms.RealtimeChatInputBar).Close();
	}
}

public static void DisengageTargets()
{
	if (side_0 != null && side_0.SelectedUnits.Count != 0)
	{
		DispatchSimpleUnitActionMultipleUnits(side_0.SelectedUnits, SimpleUnitAction.DisengageTargets);
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;

public static void DeleteWaypoint()
{
	//IL_002b: Unknown result type (might be due to invalid IL or missing references)
	//IL_0049: Unknown result type (might be due to invalid IL or missing references)
	//IL_0069: Unknown result type (might be due to invalid IL or missing references)
	//IL_0089: Unknown result type (might be due to invalid IL or missing references)
	//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
	//IL_0406: Unknown result type (might be due to invalid IL or missing references)
	//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
	//IL_035a: Unknown result type (might be due to invalid IL or missing references)
	//IL_036f: Unknown result type (might be due to invalid IL or missing references)
	//IL_0384: Unknown result type (might be due to invalid IL or missing references)
	//IL_0399: Unknown result type (might be due to invalid IL or missing references)
	//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
	if (side_0 == null || waypoint_0 == null)
	{
		return;
	}
	if (waypoint_0.IsStationWaypoint())
	{
		DarkMessageBox.ShowWarning("Cannot delete a Station waypoint! Change the waypoint type in the Flightplan Editor, and try again.", string.Empty);
	}
	else if (waypoint_0.IsHoldWaypoint())
	{
		DarkMessageBox.ShowWarning("Cannot delete a Hold waypoint! Change the waypoint type in the Flightplan Editor, and try again.", string.Empty);
	}
	else if (waypoint_0.Type == Waypoint.WaypointType.TakeOff)
	{
		DarkMessageBox.ShowWarning("Cannot delete a Take-Off waypoint! Remove the waypoint in the Flightplan Editor.", string.Empty);
	}
	else if (waypoint_0.Type == Waypoint.WaypointType.LandingMarshal)
	{
		DarkMessageBox.ShowWarning("Cannot delete a Landing Marshal waypoint! Remove the waypoint in the Flightplan Editor.", string.Empty);
	}
	else if (waypoint_0.Type == Waypoint.WaypointType.Land)
	{
		DarkMessageBox.ShowWarning("Cannot delete a Landing waypoint! Remove the waypoint in the Flightplan Editor.", string.Empty);
	}
	else if (!waypoint_0.IsSplitWaypoint())
	{
		bool flag = false;
		List<ActiveUnit> list = null;
		foreach (ActiveUnit unit in side_0.Units)
		{
			if (!unit.Navigator.PlottedCourse.Contains(waypoint_0))
			{
				continue;
			}
			if (Realtime && unit.Navigator.PlottedCourse.Count() == 1)
			{
				unit.Navigator.ClearPlottedCourse();
			}
			else
			{
				unit.Navigator.RemoveWaypoint_Soft(waypoint_0, RemoveWingmanWaypoints: true);
			}
			if (Realtime)
			{
				if (list == null)
				{
					list = new List<ActiveUnit>();
				}
				list.Add(unit);
			}
		}
		if (Realtime && list != null && list.Count > 0)
		{
			RealtimeTerminal.SendCourseUpdate(list);
			return;
		}
		if (!flag)
		{
			foreach (Mission mission in side_0.Missions)
			{
				if (mission.HasFlightPlans())
				{
					foreach (Mission.Flight flight in mission.FlightList)
					{
						Waypoint[] flightPlan = flight.FlightPlan;
						foreach (Waypoint waypoint in flightPlan)
						{
							if (waypoint != waypoint_0)
							{
								if (Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != waypoint_0)
								{
									if (Information.IsNothing((object)waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != waypoint_0)
									{
										if (Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != waypoint_0)
										{
											if (Information.IsNothing((object)waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != waypoint_0)
											{
												if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == waypoint_0)
												{
													DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
													flag = true;
													break;
												}
												continue;
											}
											DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
											flag = true;
											break;
										}
										DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
										flag = true;
										break;
									}
									DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
									flag = true;
									break;
								}
								DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
								flag = true;
								break;
							}
							if (waypoint.IsSplitWaypoint())
							{
								DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
							}
							else
							{
								ActiveUnit_Navigator.RemoveWaypoint_Hard(scenario_0, mission, flight, waypoint_0);
								AMP_General.RefreshFlightPlanErrorWindow();
								if (((Control)FlightPlanEditorWindow).Visible)
								{
									FlightPlanEditorWindow.LoadGrid();
								}
								if (((Control)AirTaskingOrderWindow).Visible)
								{
									AirTaskingOrderWindow.RefreshWindow();
								}
								if (((Control)FlightPlanTimeWindow).Visible)
								{
									((Control)FlightPlanTimeWindow).Visible = false;
								}
							}
							int num;
							if (!Realtime)
							{
								num = 1;
							}
							else
							{
								RealtimeTerminal.PollForLocalMissionStateChange(mission);
								num = 1;
							}
							flag = (byte)num != 0;
							break;
						}
						if (flag)
						{
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		SelectedWaypoint = null;
		MustRefreshMainForm = true;
	}
	else
	{
		DarkMessageBox.ShowWarning("Cannot delete waypoints with Split formation. Change the formation in the Flightplan Editor and try again.", string.Empty);
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void DeleteUnit()
{
	//IL_0064: Unknown result type (might be due to invalid IL or missing references)
	//IL_006a: Invalid comparison between Unknown and I4
	//IL_0088: Unknown result type (might be due to invalid IL or missing references)
	//IL_008e: Invalid comparison between Unknown and I4
	//IL_025e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0264: Invalid comparison between Unknown and I4
	try
	{
		if (!AllowEditModeActions)
		{
			return;
		}
		Module_Unit.Unit selectedUnit = SelectedUnit;
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>();
		foreach (Module_Unit.Unit selectedUnit2 in side_0.SelectedUnits)
		{
			if (!selectedUnit2.IsGroup || (int)DarkMessageBox.ShowWarning("Delete only the group unit " + selectedUnit2.Name + " and not units in the group?", "Group delete", DarkDialogButton.OkCancel) == 1)
			{
				continue;
			}
			if ((int)DarkMessageBox.ShowWarning("Delete the group " + selectedUnit2.Name + " and all unit(s) in group?", "Group delete", DarkDialogButton.OkCancel) == 1)
			{
				foreach (ActiveUnit value in ((Group)SelectedUnit).Units.Values)
				{
					list.Add(value);
				}
			}
			else
			{
				list2.Add(selectedUnit2);
			}
		}
		if (list.Count > 0)
		{
			foreach (Module_Unit.Unit item in list)
			{
				side_0.SelectedUnits_Add(item, WillRaiseEvent: false);
			}
		}
		if (list2.Count > 0)
		{
			foreach (Module_Unit.Unit item2 in list2)
			{
				side_0.SelectedUnits_Remove(item2);
			}
		}
		if (side_0.SelectedUnits.Count <= 1)
		{
			if (side_0.SelectedUnits.Count == 1)
			{
				if (!Information.IsNothing((object)SelectedUnit))
				{
					if (SelectedUnit.IsContact())
					{
						side_0.Contacts.Remove(SelectedUnit.ObjectID);
						side_0.BaseContacts.Remove(SelectedUnit.ObjectID);
					}
					else
					{
						scenario_0.DeleteUnitImmediately(SelectedUnit.ObjectID, ScenEditAction: true, "Unit deleted", null, RegisterAsLosses: false);
					}
					SelectThisUnit(null, ThisUnitOnly: true);
					MustRefreshMainForm = true;
				}
			}
			else
			{
				SelectThisUnit(selectedUnit, ThisUnitOnly: true);
			}
		}
		else if ((int)DarkMessageBox.ShowWarning("Delete " + Conversions.ToString(side_0.SelectedUnits.Count) + " units?", "Multiple unit delete", DarkDialogButton.OkCancel) == 1)
		{
			List<ActiveUnit> list3 = new List<ActiveUnit>();
			foreach (Module_Unit.Unit selectedUnit3 in side_0.SelectedUnits)
			{
				if (!selectedUnit3.IsActiveUnit)
				{
					if (selectedUnit3.IsContact())
					{
						side_0.Contacts.Remove(selectedUnit3.ObjectID);
						side_0.BaseContacts.Remove(selectedUnit3.ObjectID);
					}
				}
				else
				{
					list3.Add((ActiveUnit)selectedUnit3);
				}
			}
			foreach (ActiveUnit item3 in list3)
			{
				scenario_0.DeleteUnitImmediately(item3.ObjectID, ScenEditAction: true, "Unit deleted", null, RegisterAsLosses: false);
			}
			List<ActiveUnit> list4 = new List<ActiveUnit>();
			foreach (ActiveUnit value2 in scenario_0.ActiveUnits.Values)
			{
				if (value2.IsMorituri && value2.IsGroup)
				{
					list4.Add(value2);
				}
			}
			foreach (ActiveUnit item4 in list4)
			{
				scenario_0.DeleteUnitImmediately(item4.ObjectID, ScenEditAction: true, "Group deleted", null, RegisterAsLosses: false);
			}
			SelectThisUnit(null, ThisUnitOnly: true);
			MustRefreshMainForm = true;
		}
		else
		{
			if (list.Count <= 0)
			{
				return;
			}
			{
				foreach (Module_Unit.Unit item5 in list)
				{
					side_0.SelectedUnits_Remove(item5);
				}
				return;
			}
		}
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 101144", "");
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void DeleteAllUnit(HashSet<Module_Unit.Unit> SparedUnits = null)
{
	try
	{
		if (SparedUnits != null)
		{
			HashSet<Module_Unit.Unit> hashSet = new HashSet<Module_Unit.Unit>();
			foreach (Module_Unit.Unit SparedUnit in SparedUnits)
			{
				if (SparedUnit.IsContact())
				{
					ActiveUnit actualUnit = ((Contact)SparedUnit).ActualUnit;
					if (!hashSet.Contains(actualUnit) && !SparedUnits.Contains(actualUnit))
					{
						hashSet.Add(actualUnit);
					}
				}
			}
			SparedUnits.UnionWith(hashSet);
		}
		if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			return;
		}
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (ActiveUnit item in side.Units.ToList())
			{
				if (SparedUnits == null || !SparedUnits.Contains(item))
				{
					scenario_0.DeleteUnitImmediately(item.ObjectID, ScenEditAction: true, "Unit deleted");
				}
			}
		}
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 101144_b", "");
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System.Collections.Generic;
using Command_Core;

public static int IndexOf_Fast(this List<LoggedMessage> theList, LoggedMessage theLM)
{
	int num = theList.Count - 1;
	int num2 = 0;
	while (true)
	{
		if (num2 <= num)
		{
			if (theList[num2] == theLM)
			{
				break;
			}
			num2++;
			continue;
		}
		return -1;
	}
	return num2;
}

using Command_Core;

public static bool CanBeShownGhosted(ref ActiveUnit theUnit, bool MergedRangeSymbols, Contact theContact, Module_Unit.Unit theSelectedUnit)
{
	if (MergedRangeSymbols)
	{
		return true;
	}
	switch (CurrentMapProfile.ViewMode)
	{
	case MapProfile.MapViewMode.GroupView:
	{
		if (!theUnit.IsGroupMember())
		{
			return true;
		}
		if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers == Game.GamePreferences.GhostedGroupMembersVisibilitySetting.All)
		{
			return true;
		}
		if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers == Game.GamePreferences.GhostedGroupMembersVisibilitySetting.SelectedUnit)
		{
			if (theContact == null)
			{
				return theUnit.IsWithinGroupHierarchy(SelectedUnit);
			}
			if (!theUnit.IsFacility && !theUnit.IsMobileGroundUnit)
			{
				return true;
			}
			int result;
			if (SelectedUnit != null)
			{
				if (SelectedUnit.IsContact())
				{
					return theUnit.IsWithinGroupHierarchy(((Contact)SelectedUnit).ActualUnit);
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers != Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow)
		{
			break;
		}
		if (theContact == null)
		{
			return false;
		}
		int result2;
		if (theUnit.IsFacility)
		{
			result2 = 0;
		}
		else
		{
			if (!theUnit.IsMobileGroundUnit)
			{
				return true;
			}
			result2 = 0;
		}
		return (byte)result2 != 0;
	}
	case MapProfile.MapViewMode.UnitView:
		return true;
	}
	return false;
}

private static bool smethod_34()
{
	if (scenario_0.TimeCompression_SimSeconds == 1)
	{
		if (scenario_0.Time.Millisecond - 100 > 0)
		{
			return false;
		}
		return true;
	}
	return true;
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_35()
{
	try
	{
		if (CurrentGame == null || scenario_0.Sides_ReadOnly == null || scenario_0.Sides_ReadOnly.Length == 0 || VCRPlaybackInProgress || bool_9 || !SimConfiguration.DefaultGamePreferences.UseAutosave)
		{
			return;
		}
		Task.Factory.StartNew([SpecialName] () =>
		{
			bool_9 = true;
			try
			{
				PerformAutosave(CurrentScenario);
				bool_9 = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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
				bool_9 = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
		});
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 200656", ex2.Message);
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_36()
{
	try
	{
		if (!bool_0 || !smethod_34())
		{
			return;
		}
		_Closure$__418-0 arg = default(_Closure$__418-0);
		_Closure$__418-0 CS$<>8__locals5 = new _Closure$__418-0(arg);
		while (scenario_0.SerializationInProgress)
		{
			Thread.Sleep(20);
		}
		CS$<>8__locals5.$VB$Local_ScenClone = GameGeneral.GetScenarioClone(scenario_0);
		CS$<>8__locals5.$VB$Local_ScenTime = scenario_0.Time;
		if (CS$<>8__locals5.$VB$Local_ScenClone.Length > 0L)
		{
			Task.Factory.StartNew([SpecialName] () =>
			{
				CurrentTape.QueueSnapshotToSave(CS$<>8__locals5.$VB$Local_ScenTime, CS$<>8__locals5.$VB$Local_ScenClone);
			});
		}
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		ex2?.Data.Add("Error at 200657", ex2.Message);
		GameGeneral.WriteExceptionsToLog(ex2);
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		ProjectData.ClearProjectError();
	}
}

using System;
using System.IO;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void PerformAutosave(Scenario theScen)
{
	try
	{
		if (CurrentGame.Status != Game._GameStatus.Paused)
		{
			if (string.IsNullOrEmpty(scenario_0.Title))
			{
				scenario_0.Title = "Untitled";
			}
			scenario_0.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
			ScenContainer scenContainer = new ScenContainer(scenario_0);
			MemoryStream scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
			using (scenarioClone)
			{
				scenContainer.AttachAndCompressScenarioObject(scenarioClone);
			}
			string text = GameGeneral.ScenariosRootPath + "\\Autosaves";
			string text2 = scenario_0.Title;
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char c in invalidFileNameChars)
			{
				text2 = text2.Replace(Conversions.ToString(c), "");
			}
			text2 = text2.TrimEnd(new char[1] { ' ' });
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			text = text + "\\" + text2;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			scenContainer.SaveToFile(text + "\\Temp.scen");
			if (FileExistsNative.FileExistsFast(text + "\\Autosave_100sec.scen"))
			{
				File.Delete(text + "\\Autosave_100sec.scen");
			}
			if (FileExistsNative.FileExistsFast(text + "\\Autosave_80sec.scen"))
			{
				File.Move(text + "\\Autosave_80sec.scen", text + "\\Autosave_100sec.scen");
			}
			if (FileExistsNative.FileExistsFast(text + "\\Autosave_60sec.scen"))
			{
				File.Move(text + "\\Autosave_60sec.scen", text + "\\Autosave_80sec.scen");
			}
			if (FileExistsNative.FileExistsFast(text + "\\Autosave_40sec.scen"))
			{
				File.Move(text + "\\Autosave_40sec.scen", text + "\\Autosave_60sec.scen");
			}
			if (FileExistsNative.FileExistsFast(text + "\\Autosave_20sec.scen"))
			{
				File.Move(text + "\\Autosave_20sec.scen", text + "\\Autosave_40sec.scen");
			}
			if (FileExistsNative.FileExistsFast(text + "\\Autosave.scen"))
			{
				File.Move(text + "\\Autosave.scen", text + "\\Autosave_20sec.scen");
			}
			File.Move(text + "\\Temp.scen", text + "\\Autosave.scen");
			File.Delete(GameGeneral.ScenariosRootPath + "\\Autosave.scen");
			File.Copy(text + "\\Autosave.scen", GameGeneral.ScenariosRootPath + "\\Autosave.scen");
		}
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception autosaveException = ex;
		string text3 = GameGeneral.ScenariosRootPath + "\\Autosaves";
		if (Directory.Exists(text3))
		{
			string text4 = scenario_0.Title;
			if (string.IsNullOrEmpty(text4))
			{
				text4 = "Unnamed";
			}
			char[] invalidFileNameChars2 = Path.GetInvalidFileNameChars();
			foreach (char c2 in invalidFileNameChars2)
			{
				text4 = text4.Replace(Conversions.ToString(c2), "");
			}
			text3 = text3 + "\\" + text4;
			if (Directory.Exists(text3) && File.Exists(text3 + "\\Temp.scen"))
			{
				File.Delete(text3 + "\\Temp.scen");
			}
		}
		AutosaveException = autosaveException;
		MustRefreshMainForm = true;
		ProjectData.ClearProjectError();
	}
}

using System;
using System.IO;
using System.Windows.Forms;
using Command_Core;

public static void GraphicsCrash()
{
	//IL_000b: Unknown result type (might be due to invalid IL or missing references)
	//IL_0011: Invalid comparison between Unknown and I4
	//IL_001e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0024: Invalid comparison between Unknown and I4
	if ((int)MessageBox.Show("DirectX has experienced an error with the GPU, attempting to restart graphics engine.", "Command", (MessageBoxButtons)2) != 3)
	{
		return;
	}
	int exitCode;
	if ((int)MessageBox.Show("Attempt to save?", "Command", (MessageBoxButtons)4) == 6)
	{
		scenario_0.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
		ScenContainer scenContainer = new ScenContainer(scenario_0);
		MemoryStream scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
		using (scenarioClone)
		{
			scenContainer.AttachAndCompressScenarioObject(scenarioClone);
		}
		scenContainer.SaveToFile(GameGeneral.ScenariosRootPath + "\\LastDitchAutosave.scen");
		exitCode = 0;
	}
	else
	{
		exitCode = 0;
	}
	Environment.Exit(exitCode);
}

using Command_Core;

public static void AdjustTransparency(ref float theOpacity, ref int theAlpha, ActiveUnit theUnit)
{
	switch (CurrentMapProfile.ViewMode)
	{
	case MapProfile.MapViewMode.GroupView:
		if (theUnit.IsGroup)
		{
			theOpacity = 1f;
			theAlpha = 255;
		}
		else if (theUnit.IsGroupMember())
		{
			theOpacity = (float)GroupOpacity;
			theAlpha = GroupAlpha;
		}
		else
		{
			theOpacity = 1f;
			theAlpha = 255;
		}
		break;
	case MapProfile.MapViewMode.UnitView:
		if (!theUnit.IsGroup)
		{
			theOpacity = 1f;
			theAlpha = 255;
		}
		else
		{
			theOpacity = (float)GroupOpacity;
			theAlpha = GroupAlpha;
		}
		break;
	}
	if (theUnit != null && !theUnit.CommStuff.IsConnectedToSideNetwork && !CurrentMapProfile.GodsEye && !Module1.IsSelectedForIsolatedPOV(theUnit))
	{
		theAlpha = 128;
		theOpacity = 0.25f;
	}
	if (theUnit.IsWeapon && ((Weapon)theUnit).Type == Weapon._WeaponType.Sonobuoy && SimConfiguration.DefaultGamePreferences.SonobuoyVisibility == Game.GamePreferences.SonobuoyVisibilitySetting.Ghosted)
	{
		theAlpha = 128;
		theOpacity = 0.25f;
	}
}

using System.Collections.Generic;
using System.IO;
using System.Text;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

public static void smethod_37(bool dumpToFile = false)
{
	//IL_033e: Unknown result type (might be due to invalid IL or missing references)
	StringBuilder stringBuilder = StringBuilderCache.Allocate();
	stringBuilder.Clear();
	if (dumpToFile)
	{
		List<LoggedMessage> messageLog = scenario_0.MessageLog;
		if (messageLog != null)
		{
			foreach (LoggedMessage item in messageLog)
			{
				if (item.Side != null)
				{
					stringBuilder.Append(item.Timestamp.ToString() + " - [" + item.Side.Name + "] " + item.Text + "\r\n\r\n");
				}
				else
				{
					stringBuilder.Append(item.Timestamp.ToString() + " - " + item.Text + "\r\n\r\n");
				}
			}
		}
		string text = DateAndTime.Now.Year + Strings.Right("00" + DateAndTime.Now.Month, 2) + Strings.Right("00" + DateAndTime.Now.Day, 2) + Strings.Right("00" + DateAndTime.Now.Hour, 2) + Strings.Right("00" + DateAndTime.Now.Minute, 2) + Strings.Right("00" + DateAndTime.Now.Second, 2);
		StreamWriter streamWriter = File.CreateText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "AALog_" + text + ".txt");
		streamWriter.Write(stringBuilder.ToString());
		streamWriter.Close();
	}
	else
	{
		List<LoggedMessage> messageLog = side_0.get_MessageLog_Hybrid(scenario_0);
		if (messageLog != null)
		{
			foreach (LoggedMessage item2 in messageLog)
			{
				if (item2.Side != null)
				{
					stringBuilder.Append(item2.Timestamp.ToString() + " - [" + item2.Side.Name + "] " + item2.Text + "\r\n\r\n");
				}
				else
				{
					stringBuilder.Append(item2.Timestamp.ToString() + " - " + item2.Text + "\r\n\r\n");
				}
			}
		}
		StreamWriter streamWriter2 = File.CreateText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "AALog.txt");
		streamWriter2.Write(stringBuilder.ToString());
		streamWriter2.Close();
		DarkMessageBox.ShowInformation("AALog exported!", "");
	}
	StringBuilderCache.Free(stringBuilder);
}

using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

internal static void SwitchDB(string SelectedDB_Hash)
{
	//IL_004b: Unknown result type (might be due to invalid IL or missing references)
	if (Versioned.IsNumeric((object)SelectedDB_Hash))
	{
		SelectedDB_Hash = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(SelectedDB_Hash));
	}
	DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
	CurrentDB = DBOps.GetDBRecordByHash(SelectedDB_Hash, ref theResult);
	if (Information.IsNothing((object)dbrecord_0))
	{
		DarkMessageBox.ShowError("Error: " + DBOps.EnglishMessageString(theResult) + "\r\nAborting...", "Error");
	}
	else
	{
		scenario_0.DBUsed = SelectedDB_Hash;
	}
}

using System.Windows.Forms;
using Command.My;
using DarkUI.Forms;

private static void smethod_38(object object_0, object object_1)
{
	//IL_0022: Unknown result type (might be due to invalid IL or missing references)
	if (bool_2)
	{
		CurrentGame.Pause();
		bool_2 = false;
		DarkMessageBox.ShowInformation("The scenario has concluded. You will now be presented with the evaluation of your performance.", "Scenario End");
		((Control)MyProject.Forms.Evaluation).Show();
	}
}

using System.Linq;
using Command_Core;

public static void AddFileNameToRecentList(string ScenFileName)
{
	if (!RecentFilenames.Contains(ScenFileName))
	{
		RecentFilenames.Insert(0, ScenFileName);
		if (RecentFilenames.Count > 10)
		{
			RecentFilenames.Remove(RecentFilenames.Last());
		}
	}
	else
	{
		int index = RecentFilenames.IndexOf(ScenFileName);
		RecentFilenames.RemoveAt(index);
		RecentFilenames.Insert(0, ScenFileName);
	}
	SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, RecentFilenames);
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Collections.Pooled;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

public static void HandleScenarioLoaded(Scenario theLoadedScenario, string ScenFileName)
{
	//IL_0092: Unknown result type (might be due to invalid IL or missing references)
	//IL_0098: Invalid comparison between Unknown and I4
	//IL_027e: Unknown result type (might be due to invalid IL or missing references)
	//IL_011a: Unknown result type (might be due to invalid IL or missing references)
	//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
	if (CurrentGame.Status == Game._GameStatus.Running)
	{
		CurrentGame.Pause();
	}
	AddFileNameToRecentList(ScenFileName);
	theLoadedScenario.CheckForUndeclaredFeatures();
	List<Scenario.ScenarioFeatureOption> list = new List<Scenario.ScenarioFeatureOption>();
	foreach (Scenario.ScenarioFeatureOption declaredFeature in theLoadedScenario.DeclaredFeatures)
	{
		if (!Licensing.UserHasLicenseForThisFeature(declaredFeature))
		{
			list.Add(declaredFeature);
		}
	}
	if (list.Count > 0)
	{
		if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			UnlicensedFeaturesWindow unlicensedFeaturesWindow = new UnlicensedFeaturesWindow();
			((FrameworkElement)unlicensedFeaturesWindow).DataContext = new LicenseDialogViewModel(list);
			((Window)unlicensedFeaturesWindow).Show();
			return;
		}
		if ((int)DarkMessageBox.ShowWarning("This scenario contains features that aren't licenced, would you like to remove any content that isn't licenced? (This likely will make the scenario unplayable, press No if you are unsure)", "Warning", DarkDialogButton.YesNo) == 7)
		{
			UnlicensedFeaturesWindow unlicensedFeaturesWindow2 = new UnlicensedFeaturesWindow();
			((FrameworkElement)unlicensedFeaturesWindow2).DataContext = new LicenseDialogViewModel(list);
			((Window)unlicensedFeaturesWindow2).Show();
			return;
		}
		smethod_41(theLoadedScenario);
		theLoadedScenario.CheckForUndeclaredFeatures();
		List<Scenario.ScenarioFeatureOption> list2 = new List<Scenario.ScenarioFeatureOption>();
		foreach (Scenario.ScenarioFeatureOption declaredFeature2 in theLoadedScenario.DeclaredFeatures)
		{
			if (!Licensing.UserHasLicenseForThisFeature(declaredFeature2))
			{
				list2.Add(declaredFeature2);
			}
		}
		if (list2.Count > 0)
		{
			DarkMessageBox.ShowError("Unable to completely remove unlicenced features.", "Error");
			UnlicensedFeaturesWindow unlicensedFeaturesWindow3 = new UnlicensedFeaturesWindow();
			((FrameworkElement)unlicensedFeaturesWindow3).DataContext = new LicenseDialogViewModel(list);
			((Window)unlicensedFeaturesWindow3).Show();
			return;
		}
	}
	if (!theLoadedScenario.LastSavedInScenEdit)
	{
		SetCurrentScenario(theLoadedScenario, bool_10: false);
		CurrentSide = scenario_0.GetCurrentSide();
		if (!Information.IsNothing((object)side_0))
		{
			MyProject.Forms.MainForm.CameraAltitude = (int)Math.Round(side_0.CameraAlt);
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, side_0.MapCenter);
		}
		else
		{
			MyProject.Forms.MainForm.CameraAltitude = 4000000;
		}
		CurrentGame.Pause();
		MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
		MyProject.Forms.MainForm.RefreshCaption();
		if (CurrentGame.Status == Game._GameStatus.Running)
		{
			CurrentGame.Pause();
		}
		MyProject.Forms.MainForm.HandleTimeCompressionChanged();
		((Control)MyProject.Forms.MainForm).Enabled = true;
		StartGameMenuWindow.HideStartWindow();
	}
	else
	{
		MyProject.Forms.ChooseSide.theSelectedScenario = theLoadedScenario;
		MyProject.Forms.ChooseSide.selectedScenarioFile = ScenFileName;
		((Control)MyProject.Forms.ChooseSide).Show();
	}
	if (!string.IsNullOrEmpty(ScenLoadErrorFeedback))
	{
		DarkMessageBox.ShowError(ScenLoadErrorFeedback, "Error");
		ScenLoadErrorFeedback = "";
	}
	if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
	{
		List<string> list3 = new List<string>();
		int num = 4;
		int num2 = 1;
		Side[] sides_ReadOnly = theLoadedScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			Side theside = sides_ReadOnly[i];
			if (Information.IsNothing((object)theside.Missions))
			{
				continue;
			}
			foreach (Mission item in theside.get_MissionsTotal(theLoadedScenario))
			{
				Mission theMission = item;
				list3.AddRange(theLoadedScenario.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref theside, ref theMission));
			}
		}
		string text = "";
		if (list3.Count > 0)
		{
			text = "WARNING! SOME AIRCRAFT IN THIS SCENARIO WILL NOT BE ABLE TO TAKE OFF DUE TO THE MISSION'S FLIGHT SIZE RESTRICTIONS!\r\n\r\nTo rectify this, you can change the flight size of the mission, add more aircraft to the mission, change loadouts on existing aircraft so there are enough aircraft armed with identical loadouts, or uncheck the flag Aircraft numbers below Flight Size do not take off.\r\n\r\n";
			foreach (string item2 in list3)
			{
				text = text + "\r\n" + item2;
				num2++;
				if (num2 == num)
				{
					break;
				}
			}
			if (list3.Count > num)
			{
				text = text + "\r\n+" + Conversions.ToString(list3.Count - num) + " more...";
			}
			if (!string.IsNullOrEmpty(text))
			{
				DarkMessageBox.ShowError(text, "Error");
			}
		}
	}
	Side[] sides_ReadOnly2 = theLoadedScenario.Sides_ReadOnly;
	_Closure$__426-0 closure$__426- = default(_Closure$__426-0);
	foreach (Side side in sides_ReadOnly2)
	{
		List<WeaponSalvo> list4 = new List<WeaponSalvo>();
		foreach (WeaponSalvo weaponSalvo in side.WeaponSalvos)
		{
			if (weaponSalvo.ShootersList.Length == 0)
			{
				list4.Add(weaponSalvo);
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			for (int k = 0; k < shootersList.Length; k = checked(k + 1))
			{
				closure$__426- = new _Closure$__426-0(closure$__426-);
				closure$__426-.$VB$Local_theShooter = shootersList[k];
				PooledList<ActiveUnit> units = side.Units;
				if (units == null || units.Count <= 0)
				{
					continue;
				}
				ActiveUnit activeUnit = null;
				IEnumerable<ActiveUnit> source = side.Units.Where(closure$__426-._Lambda$__0);
				if (source.Count() > 0)
				{
					activeUnit = source.FirstOrDefault();
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (activeUnit == null)
				{
					list4.Add(weaponSalvo);
					continue;
				}
				if (activeUnit.IsAircraft)
				{
					WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						if (weaponRec.get_ReferenceWeapon(theLoadedScenario).DBID == weaponSalvo.get_ReferenceWeapon(theLoadedScenario).DBID && weaponRec.CurrentLoad == 0)
						{
							list4.Add(weaponSalvo);
						}
					}
				}
				foreach (Mount mount in activeUnit.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						if (mountWeapon.get_ReferenceWeapon(theLoadedScenario).DBID == weaponSalvo.get_ReferenceWeapon(theLoadedScenario).DBID && mountWeapon.CurrentLoad == 0)
						{
							list4.Add(weaponSalvo);
						}
					}
				}
			}
		}
		foreach (WeaponSalvo item3 in list4)
		{
			side.RemoveWeaponSalvo(item3);
		}
	}
	CurrentScenarioFullFilePath = ScenFileName;
	smethod_40();
}

using System.Runtime.CompilerServices;
using Command_Core;

[SpecialName]
private static string smethod_39()
{
	return ("Command_v1.10 - Build 1900.20_" + GameGeneral.ReleaseDate.Date.ToString("yyyy-MM-dd")).Replace(".", "_").Replace("/", "_").Replace(":", "_")
		.Replace("-", "_");
}

using System.Runtime.CompilerServices;

[AsyncStateMachine(typeof(VB$StateMachine_429_Execute_Startup_Lua_Folder_Script))]
private static void smethod_40()
{
	VB$StateMachine_429_Execute_Startup_Lua_Folder_Script stateMachine = default(VB$StateMachine_429_Execute_Startup_Lua_Folder_Script);
	stateMachine.$State = -1;
	stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
	stateMachine.$Builder.Start(ref stateMachine);
}

using System.Text;
using DarkUI.Forms;
using ServiceStack.Text;

private static void smethod_41(object object_0)
{
	//IL_0026: Unknown result type (might be due to invalid IL or missing references)
	StringBuilder stringBuilder = StringBuilderCache.Allocate();
	DarkMessageBox.ShowInformation(string.Format("Removed the following items from the scenario: {0}{1}{2}", "\r\n", "\r\n", stringBuilder.ToString()), "");
	StringBuilderCache.Free(stringBuilder);
}

using System;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

public static void LoadCustomLayer_Dialog()
{
	//IL_0041: Unknown result type (might be due to invalid IL or missing references)
	//IL_0047: Invalid comparison between Unknown and I4
	//IL_0089: Unknown result type (might be due to invalid IL or missing references)
	((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
	((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "Image Files(*.tif;*.jpg;*.png;*.bmp)|*.tif;*.jpg;*.png;*.bmp|Geographic information files (*.tfw;*.jgw;*.pgw;*.bpw)|*.tfw;*.jgw;*.pgw;*.bpw|All files (*.*)|*.*";
	if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
	{
		return;
	}
	string[] fileNames = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileNames;
	foreach (string theFileName in fileNames)
	{
		try
		{
			LoadCustomLayer(theFileName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError(ex2.Message, "An error occurred while loading custom layer");
			ProjectData.ClearProjectError();
		}
	}
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using DXRenderer;
using Microsoft.VisualBasic.CompilerServices;

public static void LoadCustomLayer(string theFileName)
{
	//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
	//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
	//IL_028e: Unknown result type (might be due to invalid IL or missing references)
	//IL_008b: Unknown result type (might be due to invalid IL or missing references)
	//IL_0091: Expected O, but got Unknown
	//IL_026c: Unknown result type (might be due to invalid IL or missing references)
	string extension = Path.GetExtension(theFileName);
	if (Operators.CompareString(extension, ".tfw", true) != 0)
	{
		if (Operators.CompareString(extension, ".jgw", true) == 0)
		{
			theFileName = Path.ChangeExtension(theFileName, ".jpg");
		}
		else if (Operators.CompareString(extension, ".pgw", true) == 0)
		{
			theFileName = Path.ChangeExtension(theFileName, ".png");
		}
		else if (Operators.CompareString(extension, ".bpw", true) == 0)
		{
			theFileName = Path.ChangeExtension(theFileName, ".bmp");
		}
	}
	else
	{
		theFileName = Path.ChangeExtension(theFileName, ".tif");
	}
	if (File.Exists(theFileName))
	{
		Bitmap val;
		try
		{
			val = new Bitmap(theFileName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("Unable to load the custom layer image file" + Environment.NewLine + ex2.Message, "An error occurred while loading custom layer");
			ProjectData.ClearProjectError();
			return;
		}
		new CultureInfo("en-US");
		string extension2 = Path.GetExtension(theFileName);
		extension2 = ((extension2.Length != 4) ? (extension2 + "w") : (Conversions.ToString(extension2[0]) + Conversions.ToString(extension2[1]) + Conversions.ToString(extension2[extension2.Length - 1]) + "w"));
		string text = Path.ChangeExtension(theFileName, extension2);
		if (FileExistsNative.FileExistsFast(text))
		{
			string text2 = File.ReadAllText(text);
			text2 = text2.Replace(",", ".");
			File.WriteAllText(text, text2);
			TextReader textReader = File.OpenText(text);
			double geolocation_pxLenghtX;
			double geoLocation_pxLenghtY;
			double geoLocation_startX;
			double geoLocation_startY;
			try
			{
				geolocation_pxLenghtX = Math2.ParseDouble(textReader.ReadLine());
				Math2.ParseDouble(textReader.ReadLine());
				Math2.ParseDouble(textReader.ReadLine());
				geoLocation_pxLenghtY = Math2.ParseDouble(textReader.ReadLine());
				geoLocation_startX = Math2.ParseDouble(textReader.ReadLine());
				geoLocation_startY = Math2.ParseDouble(textReader.ReadLine());
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200369", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				DarkMessageBox.ShowError("Custom layer world file is not valid", "An error occurred while loading custom layer");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				textReader.Close();
			}
			MyProject.Forms.MainForm.MapRender_Geo();
			Main instance = Main.Instance;
			_ = CurrentMapProfile;
			instance?.LoadCustomOverlay(theFileName, val, geolocation_pxLenghtX, geoLocation_pxLenghtY, geoLocation_startX, geoLocation_startY);
			((Image)val).Dispose();
		}
		else
		{
			DarkMessageBox.ShowError("Custom layer directory must also contain the world file with geolocation data for the image" + Environment.NewLine + Path.GetFileName(Path.ChangeExtension(theFileName, extension2)), "An error occurred while loading custom layer");
		}
	}
	else
	{
		DarkMessageBox.ShowError("Custom layer image file not found" + Environment.NewLine + Path.GetFileName(theFileName), "An error occurred while loading custom layer");
	}
}

private static void smethod_42(object object_0)
{
	CustomLayerQueue.Enqueue((string)object_0);
	MustRefreshMainForm = true;
}

using Command_Core;

private static void smethod_43(Side side_1)
{
	if (side_1 != side_0 || !scenario_0.IsRunningInCampaignMode)
	{
		return;
	}
	int? campaignScenarioPassScore = Campaign.GetCampaignScenarioPassScore(scenario_0);
	if (campaignScenarioPassScore.HasValue)
	{
		int num = side_1.get_TotalScore(scenario_0, (string)null);
		if (((!campaignScenarioPassScore.HasValue) ? ((bool?)null) : new bool?(num >= campaignScenarioPassScore.GetValueOrDefault())) == true)
		{
			scenario_0.EndScenario();
		}
	}
}

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

private static void smethod_44(object object_0, object object_1)
{
	Task.Factory.StartNew([SpecialName] () =>
	{
		SteamWorkshop.UpdateSubscribedItems();
	});
}

using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

private static void smethod_45(string string_1, bool bool_10)
{
	string text = string_1.ToLower();
	if (Operators.CompareString(text, "orbat", true) == 0)
	{
		if (!bool_10)
		{
			((Form)MyProject.Forms.ORBAT).Close();
		}
		else
		{
			((Control)MyProject.Forms.ORBAT).Show();
		}
	}
	else if (Operators.CompareString(text, "missioneditor", true) != 0)
	{
		if (Operators.CompareString(text, "speedalt", true) != 0)
		{
			if (Operators.CompareString(text, "exclusionzoneswindow", true) == 0)
			{
				if (!bool_10)
				{
					((Form)MyProject.Forms.ReferencePointManager).Close();
				}
				else
				{
					MyProject.Forms.ReferencePointManager.ShowWithZoneType(Zone.ZoneType.ExclusionZone);
				}
			}
			else if (Operators.CompareString(text, "nonavzoneswindow", true) != 0)
			{
				if (Operators.CompareString(text, "consolewindow2", true) == 0)
				{
					if (!bool_10)
					{
						((Form)MyProject.Forms.ConsoleWindow2).Close();
					}
					else
					{
						((Control)MyProject.Forms.ConsoleWindow2).Show();
					}
				}
				else if (Operators.CompareString(text, "airops", true) != 0)
				{
					if (Operators.CompareString(text, "boatops", true) != 0)
					{
						if (Operators.CompareString(text, "readyarm", true) != 0)
						{
							if (Operators.CompareString(text, "mounts", true) != 0)
							{
								if (Operators.CompareString(text, "sensors", true) != 0)
								{
									if (Operators.CompareString(text, "emcon", true) != 0)
									{
										if (Operators.CompareString(text, "magazines", true) != 0)
										{
											return;
										}
										if (!bool_10)
										{
											if (theMagazinesWindow != null)
											{
												((Form)theMagazinesWindow).Close();
											}
										}
										else
										{
											ShowMags();
										}
									}
									else if (!bool_10)
									{
										if (doctrineForm_0 != null)
										{
											((Form)doctrineForm_0).Close();
											doctrineForm_0 = null;
										}
									}
									else if (SelectedUnit != null)
									{
										if (doctrineForm_0 == null)
										{
											doctrineForm_0 = new DoctrineForm();
										}
										doctrineForm_0.Subject = SelectedUnit;
										((TabControl)doctrineForm_0.TabControl1A).SelectedIndex = 1;
										((Control)doctrineForm_0).Show();
									}
								}
								else if (bool_10)
								{
									ShowSensorsForSelectedUnit();
								}
								else if (theSensorsWindow != null)
								{
									((Form)theSensorsWindow).Close();
								}
							}
							else if (bool_10)
							{
								ShowWeaponDetails();
							}
							else if (theWeaponsWindow != null)
							{
								((Form)theWeaponsWindow).Close();
							}
						}
						else if (bool_10)
						{
							if (MyProject.Forms.m_AirOps != null && ((Control)MyProject.Forms.AirOps).Visible)
							{
								((ToolStripItem)MyProject.Forms.AirOps.TSL_ReadyAC).PerformClick();
							}
						}
						else if (MyProject.Forms.m_ReadyAircraft != null)
						{
							((Form)MyProject.Forms.ReadyAircraft).Close();
						}
					}
					else if (bool_10)
					{
						ShowDockingOps();
					}
					else if (MyProject.Forms.m_DockingOps != null)
					{
						((Form)MyProject.Forms.DockingOps).Close();
					}
				}
				else if (bool_10)
				{
					ShowAirOps();
				}
				else if (MyProject.Forms.m_AirOps != null)
				{
					((Form)MyProject.Forms.AirOps).Close();
				}
			}
			else if (!bool_10)
			{
				((Form)MyProject.Forms.ReferencePointManager).Close();
			}
			else
			{
				MyProject.Forms.ReferencePointManager.ShowWithZoneType(Zone.ZoneType.NoNavZone);
			}
		}
		else if (bool_10)
		{
			((Control)MyProject.Forms.SpeedAlt).Show();
		}
		else
		{
			((Form)MyProject.Forms.SpeedAlt).Close();
		}
	}
	else if (bool_10)
	{
		((Control)MissionEditorWindow).Show();
	}
	else
	{
		((Form)MissionEditorWindow).Close();
	}
}

using System.IO;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

public static void ConsolidateConfigFiles()
{
	if (!Directory.Exists(GameGeneral.ConfigFolderPath))
	{
		Directory.CreateDirectory(GameGeneral.ConfigFolderPath);
	}
	string[] files = Directory.GetFiles(Application.StartupPath);
	foreach (string text in files)
	{
		if (Operators.CompareString(Path.GetExtension(text).ToLower(), ".ini", true) == 0)
		{
			string text2 = Path.Combine(GameGeneral.ConfigFolderPath, Path.GetFileNameWithoutExtension(text)) + ".ini";
			if (FileExistsNative.FileExistsFast(text2))
			{
				File.Delete(text2);
			}
			File.Move(text, text2);
		}
	}
}

public static string EvaluateScoring()
{
	string result = "";
	if (side_0 != null)
	{
		int num = side_0.get_TotalScore(scenario_0, (string)null);
		int? scoring_Triumph;
		if (side_0.Scoring_Triumph.HasValue)
		{
			int num2 = num;
			scoring_Triumph = side_0.Scoring_Triumph;
			if ((scoring_Triumph.HasValue ? new bool?(num2 >= scoring_Triumph.GetValueOrDefault()) : ((bool?)null)) == true)
			{
				result = "Triumph";
			}
		}
		scoring_Triumph = side_0.Scoring_Triumph;
		bool? flag = ((!scoring_Triumph.HasValue) ? ((bool?)null) : new bool?(scoring_Triumph.GetValueOrDefault() > num));
		if ((flag ?? true) && num >= side_0.Scoring_MajorVictory && flag.HasValue)
		{
			result = "Major Victory";
		}
		if (side_0.Scoring_MajorVictory > num && num >= side_0.Scoring_MinorVictory)
		{
			result = "Minor Victory";
		}
		if (side_0.Scoring_MinorVictory > num && num > side_0.Scoring_MinorDefeat)
		{
			result = "Average";
		}
		if (side_0.Scoring_MinorDefeat >= num && num > side_0.Scoring_MajorDefeat)
		{
			result = "Minor Defeat";
		}
		if (side_0.Scoring_MajorDefeat >= num)
		{
			int num2 = num;
			scoring_Triumph = side_0.Scoring_Disaster;
			if ((scoring_Triumph.HasValue ? new bool?(num2 > scoring_Triumph.GetValueOrDefault()) : ((bool?)null)) == true)
			{
				result = "Major Defeat";
			}
		}
		if (side_0.Scoring_Disaster.HasValue)
		{
			int num2 = side_0.get_TotalScore(scenario_0, (string)null);
			scoring_Triumph = side_0.Scoring_Disaster;
			if (((!scoring_Triumph.HasValue) ? ((bool?)null) : new bool?(num2 <= scoring_Triumph.GetValueOrDefault())) == true)
			{
				result = "Disaster";
			}
		}
	}
	return result;
}

using DarkUI.Forms;

public static void ShowACRequiredWarning()
{
	//IL_000b: Unknown result type (might be due to invalid IL or missing references)
	DarkMessageBox.ShowWarning(CivRTMPFeatureNotSupported, CivRTMPFeatureNotSupportedTitle);
}

using Command.My;

public static void IncreaseTimeCompression()
{
	if (Realtime)
	{
		MyProject.Forms.MainForm.GameControlBar1.RTMPSetTimeCompressionRelative(1);
	}
	else
	{
		scenario_0.TimeCompression_Increase();
	}
}

using Command.My;

public static void DecreaseTimeCompression()
{
	if (!Realtime)
	{
		scenario_0.TimeCompression_Decrease();
	}
	else
	{
		MyProject.Forms.MainForm.GameControlBar1.RTMPSetTimeCompressionRelative(-1);
	}
}

using Command_Core;
using Command.My;

public static void RunPauseTimeToggle()
{
	if (Realtime)
	{
		MyProject.Forms.MainForm.GameControlBar1.method_1();
		return;
	}
	switch (CurrentGame.Status)
	{
	case Game._GameStatus.Running:
		CurrentGame.Pause();
		break;
	case Game._GameStatus.Paused:
		CurrentGame.Run();
		break;
	}
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using CommandNetcode.RT;

public static void DispatchSimpleUnitAction(Module_Unit.Unit theUnit, SimpleUnitAction theAction)
{
	if (Realtime)
	{
		switch (theAction)
		{
		case SimpleUnitAction.DisengageTargets:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DisengageTargets);
			return;
		case SimpleUnitAction.UnassignUnitsAndDisengage:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.UnassignUnitsAndDisengage);
			return;
		case SimpleUnitAction.RemoveUnitFromMission:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.RemoveUnitFromMission);
			return;
		case SimpleUnitAction.ReturnToBase:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.ReturnToBase);
			return;
		case SimpleUnitAction.Group:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.Group);
			return;
		case SimpleUnitAction.Detach:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.Detach);
			return;
		case SimpleUnitAction.DropSonobuoyPassiveDeep:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DropSonobuoyPassiveDeep);
			return;
		case SimpleUnitAction.DropSonobuoyPassiveShallow:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DropSonobuoyPassiveShallow);
			return;
		case SimpleUnitAction.DropSonobuoyActiveDeep:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DropSonobuoyActiveDeep);
			return;
		case SimpleUnitAction.DropSonobuoyActiveShallow:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DropSonobuoyActiveShallow);
			return;
		case SimpleUnitAction.DeployDippingSonar:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.DeployDippingSonar);
			return;
		case SimpleUnitAction.HoldPositionOn:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.HoldPositionOn);
			return;
		case SimpleUnitAction.HoldPositionOff:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.HoldPositionOff);
			return;
		case SimpleUnitAction.SummonToReestablishComms:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.SummonToReestablishComms);
			return;
		case SimpleUnitAction.LeadAllowedToSlowDownOn:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.LeadAllowedToSlowDownOn);
			return;
		case SimpleUnitAction.LeadAllowedToSlowDownOff:
			RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnit, ActiveUnitMiscAction.LeadAllowedToSlowDownOff);
			return;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return;
	}
	switch (theAction)
	{
	default:
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		break;
	case SimpleUnitAction.DisengageTargets:
		CoreClientCode.DisengageTargets_Core(new List<Module_Unit.Unit> { theUnit }, side_0);
		MustRefreshMainForm = true;
		break;
	case SimpleUnitAction.UnassignUnitsAndDisengage:
		CoreClientCode.UnassignUnitsAndDisengage_Core(new List<Module_Unit.Unit> { theUnit }, scenario_0, side_0);
		MustRefreshMainForm = true;
		break;
	case SimpleUnitAction.RemoveUnitFromMission:
		CoreClientCode.RemoveUnitFromMission_Core((ActiveUnit)theUnit, scenario_0, side_0);
		MustRefreshMainForm = true;
		break;
	case SimpleUnitAction.ReturnToBase:
		CoreClientCode.ReturnToBase_Core(new List<Module_Unit.Unit> { theUnit }, scenario_0, side_0);
		MustRefreshMainForm = true;
		break;
	case SimpleUnitAction.Group:
	{
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit> { theUnit };
		int mustRefreshMainForm;
		switch (CoreClientCode.GroupUnits_Core(list, side_0, scenario_0, "1", FromUI: true))
		{
		case 0:
			CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
			((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Selected units grouped together - Switched to GROUP VIEW";
			mustRefreshMainForm = 1;
			break;
		default:
			mustRefreshMainForm = 1;
			break;
		case 1:
			foreach (Module_Unit.Unit item in list)
			{
				if (item.IsActiveUnit && ((ActiveUnit)item).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					SelectThisUnit(((ActiveUnit)item).get_ParentGroup(UsingMissionPlanner: false), ThisUnitOnly: true);
					break;
				}
			}
			CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
			((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Selected units added to selected group";
			mustRefreshMainForm = 1;
			break;
		}
		MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		break;
	}
	case SimpleUnitAction.Detach:
		CoreClientCode.DetachUnits_Core(new List<Module_Unit.Unit> { theUnit }, side_0, scenario_0);
		MustRefreshMainForm = true;
		break;
	case SimpleUnitAction.DropSonobuoyPassiveDeep:
		CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit, ActiveSonobuoy: false, ShallowSonobuoy: false, IsManual: true);
		break;
	case SimpleUnitAction.DropSonobuoyPassiveShallow:
		CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit, ActiveSonobuoy: false, ShallowSonobuoy: true, IsManual: true);
		break;
	case SimpleUnitAction.DropSonobuoyActiveDeep:
		CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit, ActiveSonobuoy: true, ShallowSonobuoy: false, IsManual: true);
		break;
	case SimpleUnitAction.DropSonobuoyActiveShallow:
		CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit, ActiveSonobuoy: true, ShallowSonobuoy: true, IsManual: true);
		break;
	case SimpleUnitAction.DeployDippingSonar:
		CoreClientCode.DeployDippingSonar_Core(theUnit);
		break;
	case SimpleUnitAction.HoldPositionOn:
		if (theUnit.IsActiveUnit)
		{
			CoreClientCode.HoldPosition_Core((ActiveUnit)theUnit, OnOrOff: true);
		}
		break;
	case SimpleUnitAction.HoldPositionOff:
		if (theUnit.IsActiveUnit)
		{
			CoreClientCode.HoldPosition_Core((ActiveUnit)theUnit, OnOrOff: false);
		}
		break;
	case SimpleUnitAction.SummonToReestablishComms:
		if (theUnit.IsActiveUnit)
		{
			CoreClientCode.SummonToReestablishComms_Core((ActiveUnit)theUnit);
		}
		break;
	case SimpleUnitAction.LeadAllowedToSlowDownOn:
		CoreClientCode.LeadAllowedToSlowDown_Core((ActiveUnit)theUnit, allowed: true);
		break;
	case SimpleUnitAction.LeadAllowedToSlowDownOff:
		CoreClientCode.LeadAllowedToSlowDown_Core((ActiveUnit)theUnit, allowed: false);
		break;
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using CommandNetcode.RT;
using DarkUI.Forms;

public static void DispatchSimpleUnitActionMultipleUnits(IEnumerable<Module_Unit.Unit> theUnits, SimpleUnitAction theAction)
{
	//IL_0130: Unknown result type (might be due to invalid IL or missing references)
	//IL_0136: Invalid comparison between Unknown and I4
	string text = string.Empty;
	if (theAction == SimpleUnitAction.Group)
	{
		text = 1.ToString();
		if (theUnits.Count() > 1 && theUnits.Where([SpecialName] (Module_Unit.Unit theAU) => theAU.IsGroup).Count() == 0)
		{
			if ((from theAU in theUnits
				select (theAU) into theAU
				where theAU.IsAircraft
				select theAU).Count() == theUnits.Count())
			{
				int num;
				if (theUnits.Select([SpecialName] (Module_Unit.Unit AU) => ((Aircraft)AU).LoadoutDBID).Distinct().Count() <= 1)
				{
					num = 1;
				}
				else
				{
					if ((int)DarkMessageBox.ShowInformation("There are different types of aircraft in the current selection. Do you want to :" + Environment.NewLine + "-[yes] Enforce a wing with homogenous types of aircrafts, thus splitting it into multiple wings " + Environment.NewLine + "-[No] Force the entire selection into a mixed group ?", "Confirm", DarkDialogButton.YesNo) == 6)
					{
						text = 0.ToString();
						goto IL_015d;
					}
					num = 1;
				}
				int num2 = num;
				text = num2.ToString();
			}
			else
			{
				text = 1.ToString();
			}
		}
	}
	goto IL_015d;
	IL_015d:
	if (!Realtime)
	{
		switch (theAction)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case SimpleUnitAction.DisengageTargets:
			CoreClientCode.DisengageTargets_Core(theUnits, side_0);
			MustRefreshMainForm = true;
			break;
		case SimpleUnitAction.UnassignUnitsAndDisengage:
			CoreClientCode.UnassignUnitsAndDisengage_Core(theUnits, scenario_0, side_0);
			MustRefreshMainForm = true;
			break;
		case SimpleUnitAction.RemoveUnitFromMission:
			foreach (Module_Unit.Unit theUnit in theUnits)
			{
				if (theUnit.IsActiveUnit)
				{
					CoreClientCode.RemoveUnitFromMission_Core((ActiveUnit)theUnit, scenario_0, side_0);
				}
			}
			MustRefreshMainForm = true;
			break;
		case SimpleUnitAction.ReturnToBase:
			CoreClientCode.ReturnToBase_Core(theUnits, scenario_0, side_0);
			MustRefreshMainForm = true;
			break;
		case SimpleUnitAction.Group:
		{
			int mustRefreshMainForm;
			switch (CoreClientCode.GroupUnits_Core(theUnits, side_0, scenario_0, text, FromUI: true))
			{
			case 0:
				CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
				((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Selected units grouped together - Switched to GROUP VIEW";
				mustRefreshMainForm = 1;
				break;
			default:
				mustRefreshMainForm = 1;
				break;
			case 1:
				foreach (Module_Unit.Unit theUnit2 in theUnits)
				{
					if (theUnit2.IsActiveUnit && ((ActiveUnit)theUnit2).get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						SelectThisUnit(((ActiveUnit)theUnit2).get_ParentGroup(UsingMissionPlanner: false), ThisUnitOnly: true);
						break;
					}
				}
				CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
				((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Selected units added to selected group";
				mustRefreshMainForm = 1;
				break;
			}
			MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			break;
		}
		case SimpleUnitAction.Detach:
			if (theUnits.Count() > 0)
			{
				CoreClientCode.DetachUnits_Core(theUnits, side_0, scenario_0);
				MustRefreshMainForm = true;
				((ToolStripItem)MyProject.Forms.MainForm.TSL_Status).Text = "Selected unit(s) detached from group.";
			}
			break;
		case SimpleUnitAction.DropSonobuoyPassiveDeep:
		{
			foreach (Module_Unit.Unit theUnit3 in theUnits)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit3, ActiveSonobuoy: false, ShallowSonobuoy: false, IsManual: true);
			}
			break;
		}
		case SimpleUnitAction.DropSonobuoyPassiveShallow:
		{
			foreach (Module_Unit.Unit theUnit4 in theUnits)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit4, ActiveSonobuoy: false, ShallowSonobuoy: true, IsManual: true);
			}
			break;
		}
		case SimpleUnitAction.DropSonobuoyActiveDeep:
		{
			foreach (Module_Unit.Unit theUnit5 in theUnits)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit5, ActiveSonobuoy: true, ShallowSonobuoy: false, IsManual: true);
			}
			break;
		}
		case SimpleUnitAction.DropSonobuoyActiveShallow:
		{
			foreach (Module_Unit.Unit theUnit6 in theUnits)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, theUnit6, ActiveSonobuoy: true, ShallowSonobuoy: true, IsManual: true);
			}
			break;
		}
		case SimpleUnitAction.DeployDippingSonar:
		{
			foreach (Module_Unit.Unit theUnit7 in theUnits)
			{
				CoreClientCode.DeployDippingSonar_Core(theUnit7);
			}
			break;
		}
		case SimpleUnitAction.HoldPositionOn:
		{
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			foreach (Module_Unit.Unit theUnit8 in theUnits)
			{
				if (theUnit8.IsActiveUnit)
				{
					list2.Add((ActiveUnit)theUnit8);
				}
			}
			CoreClientCode.HoldPosition_Core(list2, OnOrOff: true);
			break;
		}
		case SimpleUnitAction.HoldPositionOff:
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (Module_Unit.Unit theUnit9 in theUnits)
			{
				if (theUnit9.IsActiveUnit)
				{
					list.Add((ActiveUnit)theUnit9);
				}
			}
			CoreClientCode.HoldPosition_Core(list, OnOrOff: false);
			break;
		}
		case SimpleUnitAction.SummonToReestablishComms:
		{
			foreach (Module_Unit.Unit theUnit10 in theUnits)
			{
				if (theUnit10.IsActiveUnit)
				{
					CoreClientCode.SummonToReestablishComms_Core((ActiveUnit)theUnit10);
				}
			}
			break;
		}
		}
		return;
	}
	switch (theAction)
	{
	case SimpleUnitAction.DisengageTargets:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DisengageTargets);
		return;
	case SimpleUnitAction.UnassignUnitsAndDisengage:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.UnassignUnitsAndDisengage);
		return;
	case SimpleUnitAction.RemoveUnitFromMission:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.RemoveUnitFromMission);
		return;
	case SimpleUnitAction.ReturnToBase:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.ReturnToBase);
		return;
	case SimpleUnitAction.Group:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.Group, text);
		return;
	case SimpleUnitAction.Detach:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.Detach);
		return;
	case SimpleUnitAction.DropSonobuoyPassiveDeep:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DropSonobuoyPassiveDeep);
		return;
	case SimpleUnitAction.DropSonobuoyPassiveShallow:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DropSonobuoyPassiveShallow);
		return;
	case SimpleUnitAction.DropSonobuoyActiveDeep:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DropSonobuoyActiveDeep);
		return;
	case SimpleUnitAction.DropSonobuoyActiveShallow:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DropSonobuoyActiveShallow);
		return;
	case SimpleUnitAction.DeployDippingSonar:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.DeployDippingSonar);
		return;
	case SimpleUnitAction.HoldPositionOn:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.HoldPositionOn);
		return;
	case SimpleUnitAction.HoldPositionOff:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.HoldPositionOff);
		return;
	case SimpleUnitAction.SummonToReestablishComms:
		RealtimeTerminal.SendActiveUnitMiscActionMessage(theUnits, ActiveUnitMiscAction.SummonToReestablishComms);
		return;
	}
	if (Debugger.IsAttached)
	{
		Debugger.Break();
	}
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Command_Core;
using CommandNetcode.RT;

public static void DispatchSimpleContactActionMultipleContacts(IEnumerable<Module_Unit.Unit> theContacts, SimpleContactAction theAction)
{
	if (Realtime)
	{
		switch (theAction)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case SimpleContactAction.Drop:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.Drop);
			break;
		case SimpleContactAction.MarkFriendly:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.MarkFriendly);
			break;
		case SimpleContactAction.MarkNeutral:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.MarkNeutral);
			break;
		case SimpleContactAction.MarkUnfriendly:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.MarkUnfriendly);
			break;
		case SimpleContactAction.MarkHostile:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.MarkHostile);
			break;
		case SimpleContactAction.MarkPosition:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.MarkPosition);
			break;
		case SimpleContactAction.ToggleFilteredOutStatus:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.ToggleFilteredOutStatus);
			foreach (Module_Unit.Unit theContact in theContacts)
			{
				CoreClientCode.ToggleContactFilteredOutStatus_Core(theContact);
			}
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutAllOn:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutAllOn);
			CoreClientCode.SetAllContactsFilteredOutStatus_Core(side_0, filteredOut: true);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutAllOff:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutAllOff);
			CoreClientCode.SetAllContactsFilteredOutStatus_Core(side_0, filteredOut: false);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutCivilianOn:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutCivilianOn);
			CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(side_0, filteredOut: true);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutCivilianOff:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutCivilianOff);
			CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(side_0, filteredOut: false);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutBiologicOn:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutBiologicOn);
			CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(side_0, filteredOut: true);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutBiologicOff:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutBiologicOff);
			CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(side_0, filteredOut: false);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutNeutralOn:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutNeutralOn);
			CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(side_0, filteredOut: true);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutNeutralOff:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutNeutralOff);
			CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(side_0, filteredOut: false);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutFriendlyOn:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutFriendlyOn);
			CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(side_0, filteredOut: true);
			MustRefreshMainForm = true;
			break;
		case SimpleContactAction.FilterOutFriendlyOff:
			RealtimeTerminal.SendContactMiscActionMessage(theContacts, ContactMiscAction.FilterOutFriendlyOff);
			CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(side_0, filteredOut: false);
			MustRefreshMainForm = true;
			break;
		}
		return;
	}
	List<Module_Unit.Unit> list = theContacts.ToList();
	switch (theAction)
	{
	default:
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		break;
	case SimpleContactAction.Drop:
		CoreClientCode.DropContacts_Core(side_0, scenario_0, list);
		break;
	case SimpleContactAction.MarkFriendly:
		CoreClientCode.MarkContacts_Core(side_0, scenario_0, Misc.PostureStance.Friendly, list);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.MarkNeutral:
		CoreClientCode.MarkContacts_Core(side_0, scenario_0, Misc.PostureStance.Neutral, list);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.MarkUnfriendly:
		CoreClientCode.MarkContacts_Core(side_0, scenario_0, Misc.PostureStance.Unfriendly, list);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.MarkHostile:
		CoreClientCode.MarkContacts_Core(side_0, scenario_0, Misc.PostureStance.Hostile, list);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.MarkPosition:
		foreach (Module_Unit.Unit item in list)
		{
			CoreClientCode.MarkContactPosition_Core(side_0, scenario_0, item);
		}
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.ToggleFilteredOutStatus:
		foreach (Module_Unit.Unit theContact2 in theContacts)
		{
			CoreClientCode.ToggleContactFilteredOutStatus_Core(theContact2);
		}
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutAllOn:
		CoreClientCode.SetAllContactsFilteredOutStatus_Core(side_0, filteredOut: true);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutAllOff:
		CoreClientCode.SetAllContactsFilteredOutStatus_Core(side_0, filteredOut: false);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutCivilianOn:
		CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(side_0, filteredOut: true);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutCivilianOff:
		CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(side_0, filteredOut: false);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutBiologicOn:
		CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(side_0, filteredOut: true);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutBiologicOff:
		CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(side_0, filteredOut: false);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutNeutralOn:
		CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(side_0, filteredOut: true);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutNeutralOff:
		CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(side_0, filteredOut: false);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutFriendlyOn:
		CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(side_0, filteredOut: true);
		MustRefreshMainForm = true;
		break;
	case SimpleContactAction.FilterOutFriendlyOff:
		CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(side_0, filteredOut: false);
		MustRefreshMainForm = true;
		break;
	}
}

using System.Windows.Forms;

private static void smethod_46(object object_0, object object_1)
{
	bool_5 = ((Control)unitSensors_0).Visible;
}

using System.Windows.Forms;

private static void smethod_47(object object_0, object object_1)
{
	bool_6 = ((Control)unitComms_0).Visible;
}

public delegate void ScenarioChangingEventHandler();

using Command_Core;

public delegate void SelectedUnitChangedEventHandler(Module_Unit.Unit theUnit);

using Command_Core;

public delegate void SelectedWaypointChangedEventHandler(Waypoint theWaypoint);

public delegate void SelectedUnitPreChangeEventHandler();

public delegate void SelectedWaypointPreChangeEventHandler();

public delegate void CurrentSideChangedEventHandler();

using Command_Core;

public delegate void TimeAdvancedEventHandler(Scenario theScen);

public enum UserAction
{
	None,
	MeasuringDistance,
	AddingPlatform,
	CreatingNewScenario,
	EditingScenarioTitleDescription,
	SavingScenario,
	PlottingCourse,
	SettingBaseForUnit,
	AddingReferencePoint,
	MovingReferencePoint,
	DroppingATarget,
	const_11,
	CopyingAUnit,
	SettingGroupLead,
	AddingFormationStation,
	SettingRefPointsRelativeTo,
	TargetingContact_AutoEngage,
	TargetingContact_ManualFire,
	const_18,
	DefiningArea_Rectangle,
	RequestSatellitePrediction,
	CloningAUnit,
	PackingScenarioForDistribution,
	PlottingCourseForSalvo,
	SelectingTanker,
	DefiningArea_Circle,
	SelectingPickupTarget,
	RTB,
	JoingGroupAsEscort,
	InvestigateContact,
	RefuelAtTarget,
	HoveringOnInteractableContact,
	SelectingRearmSupply,
	AddingAggregateUnit,
	EditingAggregateUnit,
	DefiningArea_Polygon,
	RPSmartPlacement
}

public enum SimpleUnitAction
{
	None,
	DisengageTargets,
	UnassignUnitsAndDisengage,
	RemoveUnitFromMission,
	ReturnToBase,
	Group,
	Detach,
	DropSonobuoyPassiveDeep,
	DropSonobuoyPassiveShallow,
	DropSonobuoyActiveDeep,
	DropSonobuoyActiveShallow,
	DeployDippingSonar,
	HoldPositionOn,
	HoldPositionOff,
	SummonToReestablishComms,
	LeadAllowedToSlowDownOn,
	LeadAllowedToSlowDownOff
}

public enum SimpleContactAction
{
	None,
	Drop,
	MarkFriendly,
	MarkNeutral,
	MarkUnfriendly,
	MarkHostile,
	MarkPosition,
	ToggleFilteredOutStatus,
	FilterOutAllOn,
	FilterOutAllOff,
	FilterOutCivilianOn,
	FilterOutCivilianOff,
	FilterOutBiologicOn,
	FilterOutBiologicOff,
	FilterOutNeutralOn,
	FilterOutNeutralOff,
	FilterOutFriendlyOn,
	FilterOutFriendlyOff
}

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

[StructLayout(LayoutKind.Auto)]
[CompilerGenerated]
private struct VB$StateMachine_429_Execute_Startup_Lua_Folder_Script : IAsyncStateMachine
{
	public int $State;

	public AsyncVoidMethodBuilder $Builder;

	internal string[] $S0;

	internal _Closure$__429-0 $VB$ResumableLocal_$VB$Closure_$1;

	internal int $S2;

	internal TaskAwaiter<string> $A0;

	[CompilerGenerated]
	internal void MoveNext()
	{
		int num = $State;
		checked
		{
			try
			{
				if (num != -3)
				{
				}
				try
				{
					if (num == -3 || num == 0)
					{
						goto IL_0081;
					}
					$VB$ResumableLocal_$VB$Closure_$1 = new _Closure$__429-0($VB$ResumableLocal_$VB$Closure_$1);
					if (Directory.Exists(smethod_39()))
					{
						string[] files = Directory.GetFiles(Path.Combine("Lua", smethod_39()), "*.lua");
						$VB$ResumableLocal_$VB$Closure_$1.$VB$Local_theSB = CurrentScenario.Scenario_LuaSandbox;
						$S0 = files;
						$S2 = 0;
						goto IL_0171;
					}
					goto end_IL_0012;
					IL_0081:
					string path = default(string);
					try
					{
						if (num == -3)
						{
							num = -1;
							$State = -1;
							return;
						}
						TaskAwaiter<string> awaiter;
						if (num == 0)
						{
							num = -1;
							$State = -1;
							awaiter = $A0;
							$A0 = default(TaskAwaiter<string>);
						}
						else
						{
							_Closure$__429-1 closure$__429- = new _Closure$__429-1(closure$__429-)
							{
								$VB$NonLocal_$VB$Closure_2 = $VB$ResumableLocal_$VB$Closure_$1,
								$VB$Local_fileContent = File.ReadAllText(path)
							};
							awaiter = LuaDispatcher.EnqueueAsync((Func<string>)closure$__429-._Lambda$__0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								$State = 0;
								$A0 = awaiter;
								$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						string result = awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						LuaUtility.LuaInterpret(result);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						if (!ex2.Message.Contains("unfinished string near"))
						{
							_ = "Internal ERROR: " + ex2.Message;
						}
						ProjectData.ClearProjectError();
					}
					$S2++;
					goto IL_0171;
					IL_0171:
					if ($S2 < $S0.Length)
					{
						path = $S0[$S2];
						goto IL_0081;
					}
					end_IL_0012:;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception = ex3;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult();
		}
	}

	void IAsyncStateMachine.MoveNext()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
		this.MoveNext();
	}

	void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
	{
		$Builder.SetStateMachine(stateMachine);
	}

	static VB$StateMachine_429_Execute_Startup_Lua_Folder_Script()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

[Serializable]
[CompilerGenerated]
internal sealed class _Closure$__
{
	public static readonly _Closure$__ $I;

	public static Action $I266-1;

	public static Func<ActiveUnit, bool> $I266-2;

	public static Func<KeyValuePair<string, CommNetwork>, bool> $I266-3;

	public static Action $I320-2;

	public static Func<Side, string> $I351-0;

	public static Func<Side, string> $I351-1;

	public static Func<ActiveUnit, bool> $I401-0;

	public static Action $I417-0;

	public static Action $I435-0;

	public static Func<Module_Unit.Unit, bool> $I460-0;

	public static Func<Module_Unit.Unit, Module_Unit.Unit> $I460-1;

	public static Func<Module_Unit.Unit, bool> $I460-2;

	public static Func<Module_Unit.Unit, int> $I460-3;

	static _Closure$__()
	{
		Class72.smethod_20();
		$I = new _Closure$__();
	}

	[SpecialName]
	internal void _Lambda$__266-1()
	{
		MyProject.Forms.MainForm?.MessageLogOuterControl1?.VM?.HandleCurrentScenarioChanged();
	}

	[SpecialName]
	internal bool _Lambda$__266-2(ActiveUnit x)
	{
		if (x.Comms_ReadOnly != null && x.Comms_ReadOnly.Count() > 0)
		{
			return !x.IsWeapon;
		}
		return false;
	}

	[SpecialName]
	internal bool _Lambda$__266-3(KeyValuePair<string, CommNetwork> x)
	{
		return x.Value.Members.Count > 0;
	}

	[SpecialName]
	internal void _Lambda$__320-2()
	{
		if (((Control)theCommsWindow).Visible)
		{
			theCommsWindow.Timer_Refresh.Start();
		}
	}

	[SpecialName]
	internal string _Lambda$__351-0(Side theS)
	{
		return theS.Name;
	}

	[SpecialName]
	internal string _Lambda$__351-1(Side theS)
	{
		return theS.Name;
	}

	[SpecialName]
	internal bool _Lambda$__401-0(ActiveUnit theU)
	{
		return Operators.CompareString(theU.ObjectID, CurrentSide.HQ_ID, true) == 0;
	}

	[SpecialName]
	internal void _Lambda$__417-0()
	{
		bool_9 = true;
		try
		{
			PerformAutosave(CurrentScenario);
			bool_9 = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int bool_;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				bool_ = 0;
			}
			else
			{
				bool_ = 0;
			}
			bool_9 = (byte)bool_ != 0;
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	internal void _Lambda$__435-0()
	{
		SteamWorkshop.UpdateSubscribedItems();
	}

	[SpecialName]
	internal bool _Lambda$__460-0(Module_Unit.Unit theAU)
	{
		return theAU.IsGroup;
	}

	[SpecialName]
	internal Module_Unit.Unit _Lambda$__460-1(Module_Unit.Unit theAU)
	{
		return theAU;
	}

	[SpecialName]
	internal bool _Lambda$__460-2(Module_Unit.Unit theAU)
	{
		return theAU.IsAircraft;
	}

	[SpecialName]
	internal int _Lambda$__460-3(Module_Unit.Unit AU)
	{
		return ((Aircraft)AU).LoadoutDBID;
	}
}

using System.Runtime.CompilerServices;
using DarkUI.Forms;

[CompilerGenerated]
internal sealed class _Closure$__245-0
{
	public string $VB$Local_theMessage;

	public string $VB$Local_theHeader;

	[SpecialName]
	internal void _Lambda$__0()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox.ShowInformation($VB$Local_theMessage, $VB$Local_theHeader);
	}

	[SpecialName]
	internal void _Lambda$__1()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox.ShowWarning($VB$Local_theMessage, $VB$Local_theHeader);
	}

	[SpecialName]
	internal void _Lambda$__2()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox.ShowError($VB$Local_theMessage, $VB$Local_theHeader);
	}

	static _Closure$__245-0()
	{
		Class72.smethod_20();
	}
}

// FAILED Command.Client._Closure$__266-0 (token 0x0200003a): ArgumentNullException: Value cannot be null. (Parameter 'methodReference')
using System.Runtime.CompilerServices;
using Command_Core;

[CompilerGenerated]
internal sealed class _Closure$__317-0
{
	public Scenario $VB$Local_theScen;

	[SpecialName]
	internal void _Lambda$__0()
	{
		smethod_24($VB$Local_theScen);
	}

	static _Closure$__317-0()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

[CompilerGenerated]
internal sealed class _Closure$__320-0
{
	public PlatformComponent $VB$Local_theComponent;

	public Func<Sensor, bool> $I1;

	public _Closure$__320-0(_Closure$__320-0 arg0)
	{
		if (arg0 != null)
		{
			$VB$Local_theComponent = arg0.$VB$Local_theComponent;
		}
	}

	[SpecialName]
	internal void _Lambda$__0()
	{
		if (Realtime)
		{
			return;
		}
		if (((Sensor)$VB$Local_theComponent).ParentPlatform == SelectedUnit)
		{
			theSensorsWindow.Timer_Refresh.Start();
		}
		else
		{
			if ($VB$Local_theComponent.ParentPlatform == null || !$VB$Local_theComponent.ParentPlatform.IsWeapon)
			{
				return;
			}
			Module_Unit.Unit selectedUnit = SelectedUnit;
			if (selectedUnit == null || !selectedUnit.IsActiveUnit)
			{
				return;
			}
			using IEnumerator<Sensor> enumerator = ((ActiveUnit)SelectedUnit).Sensors_Cached.Where(($I1 != null) ? $I1 : ($I1 = [SpecialName] (Sensor theSensor) => Operators.CompareString(theSensor.ObjectID, $VB$Local_theComponent.ObjectID, true) == 0)).GetEnumerator();
			if (enumerator.MoveNext())
			{
				_ = enumerator.Current;
				theSensorsWindow.Timer_Refresh.Start();
			}
		}
	}

	[SpecialName]
	internal bool _Lambda$__1(Sensor theSensor)
	{
		return Operators.CompareString(theSensor.ObjectID, $VB$Local_theComponent.ObjectID, true) == 0;
	}

	static _Closure$__320-0()
	{
		Class72.smethod_20();
	}
}

using System;
using System.IO;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class _Closure$__418-0
{
	public DateTime $VB$Local_ScenTime;

	public MemoryStream $VB$Local_ScenClone;

	public _Closure$__418-0(_Closure$__418-0 arg0)
	{
		if (arg0 != null)
		{
			$VB$Local_ScenTime = arg0.$VB$Local_ScenTime;
			$VB$Local_ScenClone = arg0.$VB$Local_ScenClone;
		}
	}

	[SpecialName]
	internal void _Lambda$__0()
	{
		CurrentTape.QueueSnapshotToSave($VB$Local_ScenTime, $VB$Local_ScenClone);
	}

	static _Closure$__418-0()
	{
		Class72.smethod_20();
	}
}

using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

[CompilerGenerated]
internal sealed class _Closure$__426-0
{
	public WeaponSalvo.Shooter $VB$Local_theShooter;

	public _Closure$__426-0(_Closure$__426-0 arg0)
	{
		if (arg0 != null)
		{
			$VB$Local_theShooter = arg0.$VB$Local_theShooter;
		}
	}

	[SpecialName]
	internal bool _Lambda$__0(ActiveUnit theUn)
	{
		if (theUn == null)
		{
			return false;
		}
		return Operators.CompareString(theUn.ObjectID, $VB$Local_theShooter.ShooterObjectID, true) == 0;
	}

	static _Closure$__426-0()
	{
		Class72.smethod_20();
	}
}

using System.Runtime.CompilerServices;
using Command_Core.Lua;

[CompilerGenerated]
internal sealed class _Closure$__429-0
{
	public LuaSandBox $VB$Local_theSB;

	public _Closure$__429-0(_Closure$__429-0 arg0)
	{
		if (arg0 != null)
		{
			$VB$Local_theSB = arg0.$VB$Local_theSB;
		}
	}

	static _Closure$__429-0()
	{
		Class72.smethod_20();
	}
}

using System.Runtime.CompilerServices;
using Command_Core;

[CompilerGenerated]
internal sealed class _Closure$__429-1
{
	public string $VB$Local_fileContent;

	public _Closure$__429-0 $VB$NonLocal_$VB$Closure_2;

	public _Closure$__429-1(_Closure$__429-1 arg0)
	{
		if (arg0 != null)
		{
			$VB$Local_fileContent = arg0.$VB$Local_fileContent;
		}
	}

	[SpecialName]
	internal string _Lambda$__0()
	{
		return LuaUtility.LuaInterpret($VB$NonLocal_$VB$Closure_2.$VB$Local_theSB.RunScript($VB$Local_fileContent, RunInteractively: true));
	}

	static _Closure$__429-1()
	{
		Class72.smethod_20();
	}
}

