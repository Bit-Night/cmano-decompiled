using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Command_Core;
using Command_Core.LoadSave;
using CommandNetcode.RT;

namespace CommandNetcode;

public static class CommandCoreInterop
{
	public delegate void StringDelegate(string s);

	private static volatile bool bool_0;

	private static volatile bool bool_1;

	private static object object_0;

	public static void MainGameLoopRTMP(RealtimeHost rtHost, Scenario scen, int dt)
	{
		for (int i = 0; i < dt; i++)
		{
			smethod_0(scen);
			rtHost?.OnScenarioAdvanced1Pulse(dt);
		}
	}

	public static void MainGameLoop(Scenario scen, int dt)
	{
		for (int i = 0; i < dt; i++)
		{
			smethod_0(scen);
		}
	}

	private static void smethod_0(Scenario scenario_0)
	{
		scenario_0.GameResolution = 1f;
		try
		{
			GameGeneral.MainGameLoop(ref scenario_0);
		}
		catch (Exception)
		{
			MemoryStream scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
			string scenXML;
			using (scenarioClone)
			{
				scenXML = Command_Core.Misc.ConvertToString(scenarioClone);
			}
			scenario_0 = ScenarioFromXML(scenXML);
			try
			{
				GameGeneral.MainGameLoop(ref scenario_0);
			}
			catch (Exception)
			{
				scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
				using (scenarioClone)
				{
					scenXML = Command_Core.Misc.ConvertToString(scenarioClone);
				}
				scenario_0 = ScenarioFromXML(scenXML);
				try
				{
					GameGeneral.MainGameLoop(ref scenario_0);
				}
				catch (Exception)
				{
					scenarioClone = GameGeneral.GetScenarioClone(scenario_0);
					using (scenarioClone)
					{
						scenXML = Command_Core.Misc.ConvertToString(scenarioClone);
					}
					scenario_0 = ScenarioFromXML(scenXML);
					try
					{
						GameGeneral.MainGameLoop(ref scenario_0);
					}
					catch (Exception)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
			}
		}
	}

	public static Scenario ScenarioFromFile(string filename)
	{
		string ErrorFeedback = "";
		return ScenContainer.LoadFromFile(filename).GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
	}

	public static void ScenarioToFile(string filename, Scenario scen)
	{
		new ScenContainer(scen).SaveToFile(filename);
	}

	public static Scenario ScenarioFromXML(string ScenXML)
	{
		string ErrorFeedback = "";
		try
		{
			return Scenario.FromXmlText(ScenXML, ref ErrorFeedback, null, ForceDeepRebuild: false, bool_3: false);
		}
		catch (Exception ex)
		{
			if (!Debugger.IsAttached)
			{
				GameGeneral.WriteExceptionsToLog(ex);
			}
			else
			{
				Debugger.Break();
			}
			return Scenario.FromXmlText(ScenXML, ref ErrorFeedback, null);
		}
	}

	public static string ScenarioToXML(Scenario scen)
	{
		try
		{
			return scen.ToXML_ViaStream(MinifyText: true);
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return scen.ToXML_ViaStream(MinifyText: true);
		}
	}

	public static void Init(bool full = false, StringDelegate d = null)
	{
		if (d == null)
		{
			d = delegate
			{
			};
		}
		d("prelock");
		lock (object_0)
		{
			d("locked");
			if (SimConfiguration.DefaultGamePreferences == null)
			{
				Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings = new Dictionary<string, Tuple<int, int, int, int>>();
				List<string> RecentlyOpenedFilenames = new List<string>();
				SimConfiguration.LoadSettings(ref WindowPlacementSettings, ref RecentlyOpenedFilenames);
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("Successfully loaded Sim Configuration.");
				}
			}
			if (bool_0)
			{
				GameGeneral.CoreInitialize(CustomDBsEnabled: false);
				bool_0 = false;
			}
			if (full && bool_1)
			{
				d("starting secondary init");
				Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings2 = new Dictionary<string, Tuple<int, int, int, int>>();
				List<string> RecentlyOpenedFilenames2 = new List<string>();
				SimConfiguration.LoadSettings(ref WindowPlacementSettings2, ref RecentlyOpenedFilenames2);
				d("settings loaded");
				KeyValuePair<LoggedMessage.MessageType, LoggedMessage.MessageSettings>[] array = SimConfiguration.DefaultGamePreferences.MessageLogSettings.ToArray();
				foreach (KeyValuePair<LoggedMessage.MessageType, LoggedMessage.MessageSettings> keyValuePair in array)
				{
					SimConfiguration.DefaultGamePreferences.MessageLogSettings[keyValuePair.Key] = new LoggedMessage.MessageSettings(_ShowOnMessageLog: true, _PopUp: false, _ShowBaloon: false, _SwitchToTimeScale1X: false);
				}
				Pathfinding.Initialize();
				d("pathfinding loaded");
				DBOps.ScanDatabases();
				d("databases scanned");
				LandCover.LoadGrids();
				d("land cover loaded");
				SeaIceProvider.Initialize();
				d("sea ice loaded");
				GlobalVariables.Headless = true;
				Command_Core.Misc.AngularDistance_5nm = Math2.Distance_To_AngularDegrees(5.0);
				d("loading complete");
				bool_1 = false;
			}
		}
		d("postlock");
	}

	public static void DestroyScenario(Scenario scen)
	{
		GameGeneral.DestroyPreviousScenario(ref scen, ClearLuaSandbox: true);
		LoadSave.UnloadScenario(scen);
	}

	static CommandCoreInterop()
	{
		Class72.smethod_20();
		bool_0 = true;
		bool_1 = true;
		object_0 = new object();
	}
}
