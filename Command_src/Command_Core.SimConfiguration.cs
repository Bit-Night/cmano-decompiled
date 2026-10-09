using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CoordinateSharp;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

[StandardModule]
public sealed class SimConfiguration
{
	public enum WindowPauseBehaviour
	{
		Pause,
		SlowToRealTime,
		CurrentTimeCompression
	}

	public static string DefaultDB_Hash;

	public static Game.GamePreferences DefaultGamePreferences;

	[SpecialName]
	private static string smethod_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "Command.ini");
	}

	[SpecialName]
	private static string smethod_1()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "CPE.ini");
	}

	[SpecialName]
	private static string smethod_2()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "Beta.ini");
	}

	[SpecialName]
	private static string smethod_3()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "ExternalURLs.ini");
	}

	public static void LoadSettings(ref Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings, ref List<string> RecentlyOpenedFilenames)
	{
		if (!FileExistsNative.FileExistsFast(smethod_0()))
		{
			CreateDefaultSettings();
		}
		IniConfigSource iniConfigSource = new IniConfigSource(smethod_0());
		ObjectPoolingSystem.MaxItem = Conversions.ToInteger(iniConfigSource.Configs["Game Preferences"].Get("ObjectPooling_MaxObject"));
		DefaultDB_Hash = iniConfigSource.Configs["General"].Get("DefaultDB");
		DefaultGamePreferences = new Game.GamePreferences();
		DefaultGamePreferences.UseAutosave = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("UseAutosave"));
		DefaultGamePreferences.RunCoreMultithreaded = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("RunCoreMultithreaded"));
		DefaultGamePreferences.ShowDiagnostics = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("ShowDiagnostics"));
		string text = iniConfigSource.Configs["Game Preferences"].Get("MessageLogInWindow");
		if (text == null)
		{
			DefaultGamePreferences.MessageLogInWindow = false;
		}
		else
		{
			DefaultGamePreferences.MessageLogInWindow = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("GameSounds");
		if (text == null)
		{
			DefaultGamePreferences.GameSounds = true;
		}
		else
		{
			DefaultGamePreferences.GameSounds = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SFXVolume");
		if (text != null)
		{
			DefaultGamePreferences.SFXVolume = Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.SFXVolume = 25;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("GameMusic");
		if (text == null)
		{
			DefaultGamePreferences.GameMusic = true;
		}
		else
		{
			DefaultGamePreferences.GameMusic = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("MusicVolume");
		if (text != null)
		{
			DefaultGamePreferences.MusicVolume = Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.MusicVolume = 25;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowAltitudeInFeet");
		if (text == null)
		{
			DefaultGamePreferences.ShowAltitudeInFeet = false;
		}
		else
		{
			DefaultGamePreferences.ShowAltitudeInFeet = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowUSUnitsInEditCargo");
		if (text != null)
		{
			DefaultGamePreferences.ShowUSUnitsForEditCargo = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.ShowUSUnitsForEditCargo = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("GroundUnitsSpeedUnit");
		if (text == null)
		{
			DefaultGamePreferences.GroundUnitsSpeedUnit = Game.GamePreferences.SpeedUnitSetting.Knots;
		}
		else
		{
			DefaultGamePreferences.GroundUnitsSpeedUnit = (Game.GamePreferences.SpeedUnitSetting)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("GeoCoordinateType");
		if (text == null)
		{
			DefaultGamePreferences.GeoCoordinateType = Parse_Format_Type.Degree_Minute_Second;
		}
		else
		{
			DefaultGamePreferences.GeoCoordinateType = (Parse_Format_Type)Conversions.ToInteger(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ZoomOnCursor");
		if (text != null)
		{
			DefaultGamePreferences.ZoomOnCursor = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.ZoomOnCursor = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SonobuoyVisibility");
		if (text == null)
		{
			DefaultGamePreferences.SonobuoyVisibility = Game.GamePreferences.SonobuoyVisibilitySetting.Normal;
		}
		else
		{
			DefaultGamePreferences.SonobuoyVisibility = (Game.GamePreferences.SonobuoyVisibilitySetting)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("RefPointVisibility");
		if (text == null)
		{
			DefaultGamePreferences.RefPointVisibility = Game.GamePreferences.RefPointVisibilitySetting.Normal;
		}
		else
		{
			DefaultGamePreferences.RefPointVisibility = (Game.GamePreferences.RefPointVisibilitySetting)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("MapSymbolsSet");
		if (text == null)
		{
			DefaultGamePreferences.MapSymbolsSet = Game.GamePreferences.MapSymbolsSetting.Directional;
		}
		else
		{
			DefaultGamePreferences.MapSymbolsSet = (Game.GamePreferences.MapSymbolsSetting)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("MapCursorBox");
		if (text != null)
		{
			DefaultGamePreferences.MapCursorBox = (Game.GamePreferences.MapCursorBoxVisibilitySetting)Conversions.ToByte(text);
		}
		else
		{
			DefaultGamePreferences.MapCursorBox = Game.GamePreferences.MapCursorBoxVisibilitySetting.Bottom;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowGhostedGroupMembers");
		if (text != null)
		{
			DefaultGamePreferences.ShowGhostedGroupMembers = (Game.GamePreferences.GhostedGroupMembersVisibilitySetting)Conversions.ToByte(text);
		}
		else
		{
			DefaultGamePreferences.ShowGhostedGroupMembers = Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowPlottedPaths");
		if (text == null)
		{
			DefaultGamePreferences.ShowPlottedPaths = Game.GamePreferences.PlottedPathsVisibilitySetting.All;
		}
		else
		{
			DefaultGamePreferences.ShowPlottedPaths = (Game.GamePreferences.PlottedPathsVisibilitySetting)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowFlightPlans_Airborne");
		if (text == null)
		{
			DefaultGamePreferences.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.All;
		}
		else
		{
			DefaultGamePreferences.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowWakeCavitation");
		if (text != null)
		{
			DefaultGamePreferences.ShowWakeCavitation = (Game.GamePreferences.WakeCavitationVisibilitySetting)Conversions.ToByte(text);
		}
		else
		{
			DefaultGamePreferences.ShowWakeCavitation = Game.GamePreferences.WakeCavitationVisibilitySetting.All;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowContrails");
		if (text != null)
		{
			DefaultGamePreferences.ShowContrails = (Game.GamePreferences.ContrailsVisibilitySetting)Conversions.ToByte(text);
		}
		else
		{
			DefaultGamePreferences.ShowContrails = Game.GamePreferences.ContrailsVisibilitySetting.All;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowFlightPlans_Planned");
		if (text == null)
		{
			DefaultGamePreferences.ShowFlightPlans_Planned = Game.GamePreferences.FlightPlansVisibilitySetting_Planned.All;
		}
		else
		{
			DefaultGamePreferences.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowAU_Behaviour_Bark");
		if (text == null)
		{
			DefaultGamePreferences.ShowAU_Behaviour_Bark = Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit;
		}
		else
		{
			DefaultGamePreferences.ShowAU_Behaviour_Bark = (Game.GamePreferences.Unit_Behaviour_Bark)Conversions.ToByte(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowMissionArea");
		if (text == null)
		{
			DefaultGamePreferences.ShowMissionArea = Game.GamePreferences.ObjectVisibilitySetting.Selected;
		}
		else
		{
			DefaultGamePreferences.ShowMissionArea = (Game.GamePreferences.ObjectVisibilitySetting)Conversions.ToShort(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("OnlyShowAvailableLoadouts");
		if (text != null)
		{
			DefaultGamePreferences.OnlyShowAvailableLoadouts = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.OnlyShowAvailableLoadouts = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("UnitStatusImage");
		if (text != null)
		{
			DefaultGamePreferences.UnitStatusImage = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.UnitStatusImage = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SalvoTimeout");
		if (text != null)
		{
			DefaultGamePreferences.SalvoTimeout = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.SalvoTimeout = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowAutomaticFireInfo");
		if (text != null)
		{
			DefaultGamePreferences.ShowAutomaticFireInfo = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.ShowAutomaticFireInfo = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowGameSpeedButton");
		if (text == null)
		{
			DefaultGamePreferences.ShowGameSpeedButton = false;
		}
		else
		{
			DefaultGamePreferences.ShowGameSpeedButton = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("LogDebugInfoToFile");
		if (text == null)
		{
			DefaultGamePreferences.LogDebugInfoToFile = false;
		}
		else
		{
			DefaultGamePreferences.LogDebugInfoToFile = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("DetectStuckUnitPulses");
		if (text != null)
		{
			DefaultGamePreferences.DetectStuckUnitPulses = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.DetectStuckUnitPulses = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("StuckUnitPulseThresholdMilliseconds");
		if (text != null)
		{
			DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds = Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds = 5000;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("PauseOnDetectedStuckUnitPulse");
		if (text == null)
		{
			DefaultGamePreferences.PauseOnDetectedStuckUnitPulse = true;
		}
		else
		{
			DefaultGamePreferences.PauseOnDetectedStuckUnitPulse = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SaveScenarioCopyOnDetectedStuckUnitPulse");
		if (text == null)
		{
			DefaultGamePreferences.SaveScenarioCopyOnDetectedStuckUnitPulse = true;
		}
		else
		{
			DefaultGamePreferences.SaveScenarioCopyOnDetectedStuckUnitPulse = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("DrawOutlines");
		if (text == null)
		{
			DefaultGamePreferences.DrawOutlines = true;
		}
		else
		{
			DefaultGamePreferences.DrawOutlines = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_UnitsAtAltitude");
		if (text != null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UnitsAtAltitude = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UnitsAtAltitude = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_Show3DTerrain");
		if (text == null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.Show3DTerrain = false;
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.Show3DTerrain = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_VerticalScaling");
		if (text != null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.VerticalScaling = Conversions.ToUShort(text);
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.VerticalScaling = 10;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_ShowSubsurfaceUnitsAtSurface");
		if (text != null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowSubsurfaceUnitsAtSurface = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowSubsurfaceUnitsAtSurface = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_ShowGroundUnitsAtSurface");
		if (text != null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowGroundUnitsAtSurface = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowGroundUnitsAtSurface = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AltitudeRender_UseGroundInsteadOfSurfaceAsRenderReference");
		if (text != null)
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UseGroundInsteadOfSurfaceAsRenderReference = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UseGroundInsteadOfSurfaceAsRenderReference = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("MessageLogCanvas");
		if (text != null)
		{
			DefaultGamePreferences.MessageLogCanvas = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.MessageLogCanvas = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("NavigationMaxDistanceNMSetting");
		if (text != null)
		{
			DefaultGamePreferences.NavigationMaxDistanceNMSetting = Convert.ToSingle(text, CultureInfo.InvariantCulture);
		}
		else
		{
			DefaultGamePreferences.NavigationMaxDistanceNMSetting = 8f;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("RMB_MoveOrder_Sensivity");
		if (text == null)
		{
			DefaultGamePreferences.RMB_MoveOrder_Enabled = true;
		}
		else
		{
			DefaultGamePreferences.RMB_MoveOrder_Enabled = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("NavigationThresholdDistanceDegSetting");
		if (text != null)
		{
			DefaultGamePreferences.NavigationThresholdDistanceDegSetting = Convert.ToSingle(text, CultureInfo.InvariantCulture);
		}
		else
		{
			DefaultGamePreferences.NavigationThresholdDistanceDegSetting = 0.5f;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AllowPowerPlanSwitch");
		if (text != null)
		{
			DefaultGamePreferences.AllowPowerPlanSwitch = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AllowPowerPlanSwitch = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AggressiveTileManagement");
		if (text != null)
		{
			DefaultGamePreferences.AggressiveTileManagement = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AggressiveTileManagement = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ShowProBanner");
		if (text != null)
		{
			DefaultGamePreferences.ShowProbanner = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.ShowProbanner = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("TacviewExePath");
		if (text != null)
		{
			DefaultGamePreferences.TacviewExePath = text;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("CustomFolder_WebviewCache");
		if (!string.IsNullOrWhiteSpace(text) && text.IndexOfAny(Path.GetInvalidPathChars()) == -1 && Directory.Exists(text))
		{
			DefaultGamePreferences.CustomFolder_WebviewCache = text;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("WebviewPathCustomRoot");
		if (!string.IsNullOrWhiteSpace(text) && text.IndexOfAny(Path.GetInvalidPathChars()) == -1 && Directory.Exists(text))
		{
			DefaultGamePreferences.WebviewPathCustomRoot = text;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ColorDataBlocks");
		if (text == null)
		{
			DefaultGamePreferences.ColorDataBlocks = false;
		}
		else
		{
			DefaultGamePreferences.ColorDataBlocks = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("DedupAlliedMessages");
		if (text != null)
		{
			GameGeneral.DedupAlliedMessages = Conversions.ToBoolean(text);
		}
		else
		{
			GameGeneral.DedupAlliedMessages = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("UsePersonalMapProfile");
		if (text == null)
		{
			DefaultGamePreferences.UsePersonalMapProfile = true;
		}
		else
		{
			DefaultGamePreferences.UsePersonalMapProfile = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("StartFullScreen");
		if (text != null)
		{
			DefaultGamePreferences.StartFullScreen = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.StartFullScreen = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("PersonalMapProfile");
		if (text != null)
		{
			DefaultGamePreferences.PersonalMapProfile = MapProfile.FromXML(Crypto.DecryptStringAES(text, "HermanDingleberry"));
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("RecentlyOpened");
		if (text != null)
		{
			RecentlyOpenedFilenames = text.Split(Conversions.ToCharArrayRankOne("|")).ToList();
		}
		string[] keys = iniConfigSource.Configs["MessageLog Preferences"].GetKeys();
		foreach (string text2 in keys)
		{
			string[] array = iniConfigSource.Configs["MessageLog Preferences"].Get(text2).Split(new char[1] { '|' });
			LoggedMessage.MessageType key;
			int num;
			if (Operators.CompareString(text2, "ScenarioGoalFulfil", false) == 0)
			{
				key = LoggedMessage.MessageType.EventEngine;
				num = 0;
			}
			else
			{
				if (Operators.CompareString(text2, "OECM_Activity", false) == 0)
				{
					continue;
				}
				key = (LoggedMessage.MessageType)Enum.Parse(typeof(LoggedMessage.MessageType), text2, ignoreCase: true);
				num = 0;
			}
			bool showBaloon = (byte)num != 0;
			int num2;
			if (array.Length > 2)
			{
				showBaloon = Conversions.ToBoolean(array[2]);
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			bool switchToTimeScale1X = (byte)num2 != 0;
			if (array.Length > 3)
			{
				switchToTimeScale1X = Conversions.ToBoolean(array[3]);
			}
			DefaultGamePreferences.MessageLogSettings[key] = new LoggedMessage.MessageSettings(Conversions.ToBoolean(array[0]), Conversions.ToBoolean(array[1]), showBaloon, switchToTimeScale1X);
		}
		if (WindowPlacementSettings != null && iniConfigSource.Configs["Secondary Window Settings"] != null)
		{
			WindowPlacementSettings.Clear();
			string[] keys2 = iniConfigSource.Configs["Secondary Window Settings"].GetKeys();
			foreach (string key2 in keys2)
			{
				string[] array = iniConfigSource.Configs["Secondary Window Settings"].Get(key2).Split(new char[1] { '|' });
				WindowPlacementSettings.Add(key2, new Tuple<int, int, int, int>(Conversions.ToInteger(array[0]), Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3])));
			}
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("PauseOnDBView");
		if (text != null)
		{
			if (bool.TryParse(text, out var result))
			{
				switch (result)
				{
				case true:
					DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.Pause;
					break;
				case false:
					DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.CurrentTimeCompression;
					break;
				}
			}
			else
			{
				DefaultGamePreferences.PauseOnDBView = (WindowPauseBehaviour)Conversions.ToInteger(text);
			}
		}
		else
		{
			DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.Pause;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("PauseOnAirDockOps");
		if (text != null)
		{
			DefaultGamePreferences.PauseOnAirDockOps = (WindowPauseBehaviour)Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.PauseOnAirDockOps = WindowPauseBehaviour.Pause;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AllowInGameDownloads");
		if (text != null)
		{
			DefaultGamePreferences.AllowInGameDownloads = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AllowInGameDownloads = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrailTimeFrequency");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrailTimeFrequency = (SlugTrailTimeFrequency)Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrailTimeFrequency = SlugTrailTimeFrequency.FithSecond;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Use");
		if (text == null)
		{
			DefaultGamePreferences.SlugTrail_Use = false;
		}
		else
		{
			DefaultGamePreferences.SlugTrail_Use = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_OwnAndAllied");
		if (text == null)
		{
			DefaultGamePreferences.SlugTrail_OwnAndAllied = false;
		}
		else
		{
			DefaultGamePreferences.SlugTrail_OwnAndAllied = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Neutral");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrail_Neutral = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrail_Neutral = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Hostile");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrail_Hostile = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrail_Hostile = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Friendly");
		if (text == null)
		{
			DefaultGamePreferences.SlugTrail_Friendly = false;
		}
		else
		{
			DefaultGamePreferences.SlugTrail_Friendly = Conversions.ToBoolean(text);
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Unfriendly");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrail_Unfriendly = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrail_Unfriendly = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_UnKnown");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrail_UnKnown = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrail_UnKnown = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_LifeTime");
		if (text != null)
		{
			DefaultGamePreferences.SlugTrail_LifeTime = Conversions.ToInteger(text);
		}
		else
		{
			DefaultGamePreferences.SlugTrail_LifeTime = 180;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("ResetZoomAtStartup");
		if (text == null)
		{
			DefaultGamePreferences.ResetZoomAtStartup = true;
		}
		else
		{
			DefaultGamePreferences.ResetZoomAtStartup = Conversions.ToBoolean(text);
		}
		if (!DefaultGamePreferences.ResetZoomAtStartup.HasValue)
		{
			DefaultGamePreferences.ResetZoomAtStartup = true;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("GroundUnitZoom");
		if (text != null)
		{
			bool? resetZoomAtStartup = DefaultGamePreferences.ResetZoomAtStartup;
			if (((!resetZoomAtStartup) ?? resetZoomAtStartup) == true)
			{
				DefaultGamePreferences.GroundUnitZoom = Conversions.ToInteger(text);
				goto IL_1541;
			}
		}
		DefaultGamePreferences.GroundUnitZoom = 30;
		goto IL_1541;
		IL_1715:
		if (DefaultGamePreferences.ResetZoomAtStartup.HasValue && DefaultGamePreferences.ResetZoomAtStartup.Value)
		{
			DefaultGamePreferences.ResetZoomAtStartup = false;
		}
		if (iniConfigSource.Configs["Game Preferences"].Get("HighSimSpeedTimeSync") != null)
		{
			GameGeneral.Beta_FlameSimSpeedTimeSync = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("HighSimSpeedTimeSync"));
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("AllowSmartRPPlacement");
		if (text != null)
		{
			DefaultGamePreferences.AllowSmartRPPlacement = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.AllowSmartRPPlacement = false;
		}
		text = iniConfigSource.Configs["Game Preferences"].Get("UseDarkThemeOnLuaConsoles");
		if (text != null)
		{
			DefaultGamePreferences.UseDarkThemeOnLuaConsoles = Conversions.ToBoolean(text);
		}
		else
		{
			DefaultGamePreferences.UseDarkThemeOnLuaConsoles = false;
		}
		if (iniConfigSource.Configs["ContactExpire"] != null)
		{
			text = iniConfigSource.Configs["ContactExpire"].Get("Air");
			if (text != null)
			{
				Contact.ExpirationTimes.Air = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Air' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Missile");
			if (text != null)
			{
				Contact.ExpirationTimes.Missile = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Missile' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Orbital");
			if (text != null)
			{
				Contact.ExpirationTimes.Orbital = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Orbital' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Torpedo");
			if (text != null)
			{
				Contact.ExpirationTimes.Torpedo = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Torpedo' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Surface");
			if (text != null)
			{
				Contact.ExpirationTimes.Surface = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Surface' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Mobile");
			if (text != null)
			{
				Contact.ExpirationTimes.Mobile = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Mobile' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("Submarine");
			if (text != null)
			{
				Contact.ExpirationTimes.Submarine = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'Submarine' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
			text = iniConfigSource.Configs["ContactExpire"].Get("AGU");
			if (text != null)
			{
				Contact.ExpirationTimes.AGU = Conversions.ToInteger(text);
				GameGeneral.WriteLogDebugInfoToFile("Setting custom expiration time for 'AGU' contacts: " + Conversions.ToString(Conversions.ToInteger(text)) + " seconds");
			}
		}
		if (!FileExistsNative.FileExistsFast(smethod_2()))
		{
			return;
		}
		GameGeneral.WriteLogDebugInfoToFile("\r\nBeta.ini config file found; Extra settings will be activated if enabled");
		iniConfigSource = new IniConfigSource(smethod_2());
		if (iniConfigSource.Configs["General"].Get("UIGridLines") != null)
		{
			GameGeneral.Beta_UIGridLines = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("UIGridLines"));
		}
		if (GameGeneral.Beta_UIGridLines)
		{
			GameGeneral.WriteLogDebugInfoToFile("UI Grid Lines: Enabled");
		}
		if (iniConfigSource.Configs["General"].Get("ShowAIOODA") != null)
		{
			GameGeneral.Beta_ShowAIOODA = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("ShowAIOODA"));
		}
		if (GameGeneral.Beta_ShowAIOODA)
		{
			GameGeneral.WriteLogDebugInfoToFile("Show AI OODA-loop values: Enabled");
		}
		if (iniConfigSource.Configs["General"].Get("DEFENSIVE_DUE_TO_ILLUMINATION") != null)
		{
			GameGeneral.Beta_DEFENSIVE_DUE_TO_ILLUMINATION = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("DEFENSIVE_DUE_TO_ILLUMINATION"));
		}
		if (GameGeneral.Beta_DEFENSIVE_DUE_TO_ILLUMINATION)
		{
			GameGeneral.WriteLogDebugInfoToFile("Go defensive due to detected illumination: Enabled");
		}
		if (iniConfigSource.Configs["General"].Get("REVISEDSONAR") != null)
		{
			GameGeneral.Beta_RevisedSonarModel = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("REVISEDSONAR"));
			if (GameGeneral.Beta_RevisedSonarModel)
			{
				GameGeneral.WriteLogDebugInfoToFile("Using revised sonar model (Nov 2025)");
			}
		}
		if (iniConfigSource.Configs["General"].Get("PlatformComms") != null)
		{
			GameGeneral.Beta_PlatformComms = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("PlatformComms"));
			if (GameGeneral.Beta_PlatformComms)
			{
				GameGeneral.WriteLogDebugInfoToFile("Using the revised platform comms feature");
			}
		}
		if (iniConfigSource.Configs["General"].Get("HTMLDebug") != null)
		{
			GameGeneral.Beta_HTMLDebug = Conversions.ToBoolean(iniConfigSource.Configs["General"].Get("HTMLDebug"));
			if (GameGeneral.Beta_PlatformComms)
			{
				GameGeneral.WriteLogDebugInfoToFile("HTML debug tools enabled");
			}
		}
		return;
		IL_162b:
		text = iniConfigSource.Configs["Game Preferences"].Get("RectangleZoom");
		if (text != null)
		{
			bool? resetZoomAtStartup = DefaultGamePreferences.ResetZoomAtStartup;
			if (((!resetZoomAtStartup) ?? resetZoomAtStartup) == true)
			{
				DefaultGamePreferences.RectangleZoom = Conversions.ToInteger(text);
				goto IL_16a0;
			}
		}
		DefaultGamePreferences.RectangleZoom = 30;
		goto IL_16a0;
		IL_1541:
		text = iniConfigSource.Configs["Game Preferences"].Get("DiamondZoom");
		if (text != null)
		{
			bool? resetZoomAtStartup = DefaultGamePreferences.ResetZoomAtStartup;
			if (((!resetZoomAtStartup) ?? resetZoomAtStartup) == true)
			{
				DefaultGamePreferences.DiamondZoom = Conversions.ToInteger(text);
				goto IL_15b6;
			}
		}
		DefaultGamePreferences.DiamondZoom = 30;
		goto IL_15b6;
		IL_16a0:
		text = iniConfigSource.Configs["Game Preferences"].Get("FlowerZoom");
		if (text != null)
		{
			bool? resetZoomAtStartup = DefaultGamePreferences.ResetZoomAtStartup;
			if (((!resetZoomAtStartup) ?? resetZoomAtStartup) == true)
			{
				DefaultGamePreferences.FlowerZoom = Conversions.ToInteger(text);
				goto IL_1715;
			}
		}
		DefaultGamePreferences.FlowerZoom = 30;
		goto IL_1715;
		IL_15b6:
		text = iniConfigSource.Configs["Game Preferences"].Get("IconZoom");
		if (text != null)
		{
			bool? resetZoomAtStartup = DefaultGamePreferences.ResetZoomAtStartup;
			if (((!resetZoomAtStartup) ?? resetZoomAtStartup) == true)
			{
				DefaultGamePreferences.IconZoom = Conversions.ToInteger(text);
				goto IL_162b;
			}
		}
		DefaultGamePreferences.IconZoom = 20;
		goto IL_162b;
	}

	public static void CreateDefaultSettings()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			iniConfigSource.AddConfig("General").Set("DefaultDB", 1);
			IConfig config = iniConfigSource.AddConfig("Realism Settings");
			config.Set("DetailedGunFireControl", "True");
			config.Set("UnlimitedAirWeapons", "False");
			config.Set("CommsJamming", "False");
			config.Set("AircraftDamage", "False");
			IConfig config2 = iniConfigSource.AddConfig("Game Preferences");
			config2.Set("UseAutosave", "True");
			config2.Set("RunCoreMultithreaded", "False");
			config2.Set("ShowDiagnostics", "True");
			config2.Set("MessageLogInWindow", "False");
			config2.Set("GameSounds", "True");
			config2.Set("SFXVolume", "75");
			config2.Set("GameMusic", "True");
			config2.Set("MusicVolume", "75");
			config2.Set("ShowAltitudeInFeet", "True");
			config2.Set("AllowSmartRPPlacement", "False");
			config2.Set("ShowUSUnitsInEditCargo", "False");
			config2.Set("SonobuoyVisibility", "1");
			config2.Set("ZoomOnCursor", "False");
			config2.Set("RefPointVisibility", "0");
			config2.Set("MapSymbolsSet", "2");
			config2.Set("MapCursorBox", "0");
			config2.Set("HighFidelityMode", "True");
			config2.Set("NoPulseMapUpdate", "True");
			config2.Set("ShowGhostedGroupMembers", "1");
			config2.Set("NavigationMaxDistanceNMSetting", "8");
			config2.Set("NavigationThresholdDistanceDegSetting", "0.5");
			config2.Set("ShowPlottedPaths", "1");
			config2.Set("ShowFlightPlans", "0");
			config2.Set("ShowMissionArea", "1");
			config2.Set("OnlyShowAvailableLoadouts", "False");
			config2.Set("UnitStatusImage", "True");
			config2.Set("SalvoTimeout", "True");
			config2.Set("DrawOutlines", "True");
			config2.Set("MessageLogCanvas", "True");
			config2.Set("AllowPowerPlanSwitch", "True");
			config2.Set("ShowGameSpeedButton", "False");
			config2.Set("LogDebugInfoToFile", "True");
			config2.Set("DPIScalingMethod", "0");
			IConfig config3 = iniConfigSource.AddConfig("MessageLog Preferences");
			config3.Set("NewContact", "1|0|0|0");
			config3.Set("CommsIsolatedMessage", "1|0|0");
			config3.Set("ContactChange", "1|0|0");
			config3.Set("WeaponEndgame", "1|0|0");
			config3.Set("WeaponDamage", "1|0|0");
			config3.Set("AirOps", "0|0|0");
			config3.Set("UnitLost", "1|1|1|1");
			config3.Set("UnitDamage", "1|0|1|0");
			config3.Set("PointDefence", "0|0|0");
			config3.Set("UI", "1|0|0");
			config3.Set("WeaponLogic", "0|0|0");
			config3.Set("UnitAI", "0|0|0");
			config3.Set("EventEngine", "0|0|0");
			config3.Set("NewWeaponContact", "1|1|1|1");
			config3.Set("DockingOps", "0|0|0");
			config3.Set("SpecialMessage", "1|1|1|1");
			config3.Set("NewMineContact", "1|0|0|1");
			config3.Set("NewAirContact", "1|0|0|0");
			config3.Set("NewSurfaceContact", "1|0|0|0");
			config3.Set("NewUnderwaterContact", "1|0|0|0");
			config3.Set("NewGroundContact", "1|0|0|0");
			config3.Set("UnguidedWeaponModifiers", "0|0|0");
			iniConfigSource.AddConfig("Secondary Window Settings");
			iniConfigSource.Save(smethod_0());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101128", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_4()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			config.Set("UsePitchForWeapons", 1);
			config.Set("CompleteSensorFailureReport", 0);
			config.Set("CustomFolder_GIS", "");
			config.Set("CustomFolder_DB", "");
			config.Set("CustomFolder_WW", "");
			config.Set("Terrain", Terrain.PreferredTerrain);
			IConfig config2 = iniConfigSource.AddConfig("Lua");
			config2.Set("EnableSocket", 0);
			config2.Set("SocketPort", 7777);
			config2.Set("AllowIO", 0);
			iniConfigSource.Save(smethod_1());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 102134523456661184325762356", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_5()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			config.Set("UseV1SaveFormat", 0);
			config.Set("UIGridLines", 0);
			iniConfigSource.Save(smethod_2());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 102134523456632452312312412345", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void SaveSettings(Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings, List<string> RecentlyOpenedFilename)
	{
		if (string.IsNullOrEmpty(DefaultDB_Hash))
		{
			return;
		}
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			if (!string.IsNullOrEmpty(DefaultDB_Hash))
			{
				config.Set("DefaultDB", DefaultDB_Hash);
			}
			config = iniConfigSource.AddConfig("Game Preferences");
			config.Set("UseAutosave", DefaultGamePreferences.UseAutosave.ToString());
			config.Set("RunCoreMultithreaded", DefaultGamePreferences.RunCoreMultithreaded.ToString());
			config.Set("ShowDiagnostics", DefaultGamePreferences.ShowDiagnostics.ToString());
			config.Set("MessageLogInWindow", DefaultGamePreferences.MessageLogInWindow.ToString());
			config.Set("GameSounds", DefaultGamePreferences.GameSounds.ToString());
			config.Set("SFXVolume", DefaultGamePreferences.SFXVolume.ToString());
			config.Set("GameMusic", DefaultGamePreferences.GameMusic.ToString());
			config.Set("MusicVolume", DefaultGamePreferences.MusicVolume.ToString());
			config.Set("ShowAltitudeInFeet", DefaultGamePreferences.ShowAltitudeInFeet.ToString());
			config.Set("AllowSmartRPPlacement", DefaultGamePreferences.AllowSmartRPPlacement.ToString());
			config.Set("ShowUSUnitsInEditCargo", DefaultGamePreferences.ShowUSUnitsForEditCargo.ToString());
			config.Set("GroundUnitsSpeedUnit", ((byte)DefaultGamePreferences.GroundUnitsSpeedUnit).ToString());
			config.Set("GeoCoordinateType", ((byte)DefaultGamePreferences.GeoCoordinateType).ToString());
			config.Set("ZoomOnCursor", DefaultGamePreferences.ZoomOnCursor.ToString());
			config.Set("SonobuoyVisibility", ((int)DefaultGamePreferences.SonobuoyVisibility).ToString());
			config.Set("RefPointVisibility", ((int)DefaultGamePreferences.RefPointVisibility).ToString());
			config.Set("MapSymbolsSet", ((byte)DefaultGamePreferences.MapSymbolsSet).ToString());
			config.Set("MapCursorBox", ((int)DefaultGamePreferences.MapCursorBox).ToString());
			config.Set("OnlyShowAvailableLoadouts", DefaultGamePreferences.OnlyShowAvailableLoadouts.ToString());
			config.Set("ShowAU_Behaviour_Bark", ((byte)DefaultGamePreferences.ShowAU_Behaviour_Bark).ToString());
			config.Set("ShowGhostedGroupMembers", ((byte)DefaultGamePreferences.ShowGhostedGroupMembers).ToString());
			config.Set("NavigationMaxDistanceNMSetting", DefaultGamePreferences.NavigationMaxDistanceNMSetting.ToString());
			config.Set("RMB_MoveOrder_Sensivity", DefaultGamePreferences.RMB_MoveOrder_Enabled.ToString());
			config.Set("NavigationThresholdDistanceDegSetting", DefaultGamePreferences.NavigationThresholdDistanceDegSetting.ToString());
			config.Set("ShowPlottedPaths", ((byte)DefaultGamePreferences.ShowPlottedPaths).ToString());
			config.Set("ShowFlightPlans_Airborne", ((byte)DefaultGamePreferences.ShowFlightPlans_Airborne).ToString());
			config.Set("ShowWakeCavitation", ((byte)DefaultGamePreferences.ShowWakeCavitation).ToString());
			config.Set("ShowContrails", ((byte)DefaultGamePreferences.ShowContrails).ToString());
			config.Set("ShowFlightPlans_Planned", ((byte)DefaultGamePreferences.ShowFlightPlans_Planned).ToString());
			config.Set("ShowMissionArea", ((byte)DefaultGamePreferences.ShowMissionArea).ToString());
			config.Set("UnitStatusImage", DefaultGamePreferences.UnitStatusImage.ToString());
			config.Set("SalvoTimeout", DefaultGamePreferences.SalvoTimeout.ToString());
			config.Set("ShowAutomaticFireInfo", DefaultGamePreferences.ShowAutomaticFireInfo.ToString());
			config.Set("DrawOutlines", DefaultGamePreferences.DrawOutlines.ToString());
			config.Set("AltitudeRender_UnitsAtAltitude", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UnitsAtAltitude.ToString());
			config.Set("AltitudeRender_Show3DTerrain", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.Show3DTerrain.ToString());
			config.Set("AltitudeRender_VerticalScaling", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.VerticalScaling.ToString());
			config.Set("AltitudeRender_ShowSubsurfaceUnitsAtSurface", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowSubsurfaceUnitsAtSurface.ToString());
			config.Set("AltitudeRender_ShowGroundUnitsAtSurface", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowGroundUnitsAtSurface.ToString());
			config.Set("AltitudeRender_UseGroundInsteadOfSurfaceAsRenderReference", DefaultGamePreferences.AltitudeRender.Unrectified_ForOptionsUIAndIni.UseGroundInsteadOfSurfaceAsRenderReference.ToString());
			config.Set("MessageLogCanvas", DefaultGamePreferences.MessageLogCanvas.ToString());
			config.Set("AllowPowerPlanSwitch", DefaultGamePreferences.AllowPowerPlanSwitch.ToString());
			config.Set("AggressiveTileManagement", DefaultGamePreferences.AggressiveTileManagement.ToString());
			config.Set("ShowProBanner", DefaultGamePreferences.ShowProbanner.ToString());
			config.Set("StartFullScreen", DefaultGamePreferences.StartFullScreen.ToString());
			if (!string.IsNullOrEmpty(DefaultGamePreferences.TacviewExePath))
			{
				config.Set("TacviewExePath", DefaultGamePreferences.TacviewExePath);
			}
			if (!string.IsNullOrEmpty(DefaultGamePreferences.WebviewPathCustomRoot))
			{
				config.Set("WebviewPathCustomRoot", DefaultGamePreferences.WebviewPathCustomRoot);
			}
			if (!string.IsNullOrEmpty(DefaultGamePreferences.CustomFolder_WebviewCache))
			{
				config.Set("CustomFolder_WebviewCache", DefaultGamePreferences.CustomFolder_WebviewCache);
			}
			config.Set("ShowGameSpeedButton", DefaultGamePreferences.ShowGameSpeedButton.ToString());
			config.Set("LogDebugInfoToFile", DefaultGamePreferences.LogDebugInfoToFile.ToString());
			config.Set("DetectStuckUnitPulses", DefaultGamePreferences.DetectStuckUnitPulses.ToString());
			config.Set("StuckUnitPulseThresholdMilliseconds", DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds.ToString());
			config.Set("PauseOnDetectedStuckUnitPulse", DefaultGamePreferences.PauseOnDetectedStuckUnitPulse.ToString());
			config.Set("SaveScenarioCopyOnDetectedStuckUnitPulse", DefaultGamePreferences.SaveScenarioCopyOnDetectedStuckUnitPulse.ToString());
			config.Set("UseAutosave", DefaultGamePreferences.UseAutosave.ToString());
			config.Set("ColorDataBlocks", DefaultGamePreferences.ColorDataBlocks.ToString());
			config.Set("DedupAlliedMessages", GameGeneral.DedupAlliedMessages.ToString());
			config.Set("UsePersonalMapProfile", DefaultGamePreferences.UsePersonalMapProfile.ToString());
			config.Set("PersonalMapProfile", Crypto.EncryptStringAES(DefaultGamePreferences.PersonalMapProfile.ToXML(), "HermanDingleberry"));
			config.Set("RecentlyOpened", string.Join("|", RecentlyOpenedFilename));
			config.Set("PauseOnDBView", ((int)DefaultGamePreferences.PauseOnDBView).ToString());
			config.Set("PauseOnAirDockOps", ((int)DefaultGamePreferences.PauseOnAirDockOps).ToString());
			config.Set("AllowInGameDownloads", DefaultGamePreferences.AllowInGameDownloads.ToString());
			config.Set("SlugTrailTimeFrequency", ((int)DefaultGamePreferences.SlugTrailTimeFrequency).ToString());
			config.Set("SlugTrail_Friendly", DefaultGamePreferences.SlugTrail_Friendly.ToString());
			config.Set("SlugTrail_Hostile", DefaultGamePreferences.SlugTrail_Hostile.ToString());
			config.Set("SlugTrail_Neutral", DefaultGamePreferences.SlugTrail_Neutral.ToString());
			config.Set("SlugTrail_OwnAndAllied", DefaultGamePreferences.SlugTrail_OwnAndAllied.ToString());
			config.Set("SlugTrail_Use", DefaultGamePreferences.SlugTrail_Use.ToString());
			config.Set("SlugTrail_Unfriendly", DefaultGamePreferences.SlugTrail_Unfriendly.ToString());
			config.Set("SlugTrail_UnKnown", DefaultGamePreferences.SlugTrail_UnKnown.ToString());
			config.Set("SlugTrail_LifeTime", DefaultGamePreferences.SlugTrail_LifeTime.ToString());
			config.Set("GroundUnitZoom", DefaultGamePreferences.GroundUnitZoom.ToString());
			config.Set("DiamondZoom", DefaultGamePreferences.DiamondZoom.ToString());
			config.Set("FlowerZoom", DefaultGamePreferences.FlowerZoom.ToString());
			config.Set("IconZoom", DefaultGamePreferences.IconZoom.ToString());
			config.Set("RectangleZoom", DefaultGamePreferences.RectangleZoom.ToString());
			config.Set("ResetZoomAtStartup", DefaultGamePreferences.ResetZoomAtStartup.ToString());
			config.Set("UseDarkThemeOnLuaConsoles", DefaultGamePreferences.UseDarkThemeOnLuaConsoles.ToString());
			config = iniConfigSource.AddConfig("MessageLog Preferences");
			foreach (LoggedMessage.MessageType key in DefaultGamePreferences.MessageLogSettings.Keys)
			{
				config.Set(key.ToString(), Conversions.ToString(0 - (DefaultGamePreferences.MessageLogSettings[key].ShowOnMessageLog ? 1 : 0)) + "|" + Conversions.ToString(0 - (DefaultGamePreferences.MessageLogSettings[key].PopUp ? 1 : 0)) + "|" + Conversions.ToString(0 - (DefaultGamePreferences.MessageLogSettings[key].ShowBaloon ? 1 : 0)) + "|" + Conversions.ToString(0 - (DefaultGamePreferences.MessageLogSettings[key].bool_0 ? 1 : 0)));
			}
			try
			{
				config = iniConfigSource.AddConfig("Secondary Window Settings");
				foreach (KeyValuePair<string, Tuple<int, int, int, int>> WindowPlacementSetting in WindowPlacementSettings)
				{
					config.Set(WindowPlacementSetting.Key, Conversions.ToString(WindowPlacementSetting.Value.Item1) + "|" + Conversions.ToString(WindowPlacementSetting.Value.Item2) + "|" + Conversions.ToString(WindowPlacementSetting.Value.Item3) + "|" + Conversions.ToString(WindowPlacementSetting.Value.Item4));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101160", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			config = iniConfigSource.AddConfig("ContactExpire");
			config.Set("Air", Contact.ExpirationTimes.Air);
			config.Set("Missile", Contact.ExpirationTimes.Missile);
			config.Set("Orbital", Contact.ExpirationTimes.Orbital);
			config.Set("Torpedo", Contact.ExpirationTimes.Torpedo);
			config.Set("Surface", Contact.ExpirationTimes.Surface);
			config.Set("Mobile", Contact.ExpirationTimes.Mobile);
			config.Set("Submarine", Contact.ExpirationTimes.Submarine);
			config.Set("AGU", Contact.ExpirationTimes.AGU);
			iniConfigSource.Save(smethod_0());
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101129", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string GetExternalURL(string category, string URLkey)
	{
		string result;
		try
		{
			result = new IniConfigSource(smethod_3()).Configs[category].Get(URLkey);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200500", ex2.Message);
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

	public static string[] GetRemoteImageServers()
	{
		string[] result;
		try
		{
			result = new IniConfigSource(smethod_3()).Configs["RemoteImages"].GetValues();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2032459872349067834596348957", ex2.Message);
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

	static SimConfiguration()
	{
		Class72.smethod_20();
	}
}
