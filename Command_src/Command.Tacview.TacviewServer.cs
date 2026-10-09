using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using CSMaterial;
using DarkUI.Collections;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Command.Tacview;

[StandardModule]
internal sealed class TacviewServer
{
	public static EventExporter_TacviewPipe theExporter;

	[AccessedThroughProperty("Clients")]
	[CompilerGenerated]
	private static ObservableList<TacviewClient> observableList_0;

	public static readonly LockObject ServerLockObj;

	public static Dictionary<string, float> EchoDestruction;

	public static float EchoCount;

	public static ObservableList<TacviewClient> Clients
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<TacviewClient>> value2 = smethod_2;
			EventHandler<ObservableListModified<TacviewClient>> value3 = smethod_3;
			ObservableList<TacviewClient> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
			}
		}
	}

	static TacviewServer()
	{
		Class72.smethod_20();
		ServerLockObj = new LockObject();
		EchoDestruction = new Dictionary<string, float>();
		EchoCount = 3f;
		Clients = new ObservableList<TacviewClient>();
		MapProfile.GodsEyeStatusChanged += cerwAxIkF;
		Scenario.CurrentSideChanged += smethod_0;
		AttachExporter();
	}

	private static void smethod_0(object object_0)
	{
		if (object_0 == Client.CurrentScenario)
		{
			smethod_1();
		}
	}

	public static void AttachExporter()
	{
		theExporter = new EventExporter_TacviewPipe(IEventExporter.EventExporterRunMode.Interactive);
		ArrayExtensions.Add(ref Exporter_General.EventExporters_Interactive, theExporter);
		theExporter.PipeTelemetryToTacview += PipeTelemetryToTacview;
		theExporter.Start();
	}

	private static void cerwAxIkF(object object_0)
	{
		if (object_0 == Client.CurrentMapProfile)
		{
			smethod_1();
		}
	}

	public static void PipeTelemetryToTacview(List<(string, IEventExporter.EventExportNotification)> tupleList)
	{
		foreach (TacviewClient item in observableList_0)
		{
			item.EventQueue.Enqueue(tupleList);
		}
	}

	public static byte[] ToByteArray(int[] a)
	{
		return a.Select([SpecialName] (int F) => (byte)F).ToArray();
	}

	public static void AutoDiscoverTacviewExePath()
	{
		string path = ((!Environment.Is64BitOperatingSystem) ? "Tacview.exe" : "Tacview64.exe");
		RegistryKey val = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 1174860");
		if (val == null)
		{
			val = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Raia Software\\Tacview\\Local");
			if (val != null)
			{
				string directoryName = Path.GetDirectoryName(Conversions.ToString(val.GetValue("Tacview-x64")));
				SimConfiguration.DefaultGamePreferences.TacviewExePath = Path.Combine(directoryName, path);
			}
		}
		else
		{
			string directoryName = Conversions.ToString(val.GetValue("InstallLocation"));
			SimConfiguration.DefaultGamePreferences.TacviewExePath = Path.Combine(directoryName, path);
		}
	}

	public static Process LoadApplication(string path, string args, IntPtr handle)
	{
		new Stopwatch().Start();
		ProcessStartInfo processStartInfo = new ProcessStartInfo(path);
		processStartInfo.CreateNoWindow = true;
		processStartInfo.UseShellExecute = false;
		Process process = new Process();
		process.StartInfo = processStartInfo;
		process.StartInfo.Arguments = args;
		process.Start();
		return process;
	}

	public static void HandleScenarioChanging()
	{
		smethod_1();
	}

	private static void smethod_1()
	{
		theExporter.DestroyCache();
		int count = observableList_0.Count;
		foreach (TacviewClient item in observableList_0.ToList())
		{
			item.Close();
		}
		if (count != 0)
		{
			SpawnTacviewWindow();
		}
	}

	public static void FocusCameraOnSelectedUnit()
	{
		if (Client.SelectedUnit == null || !observableList_0.Any())
		{
			return;
		}
		Module_Unit.Unit unit;
		if (Client.SelectedUnit.IsGroup)
		{
			unit = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
		}
		else if (!Client.SelectedUnit.IsActiveUnit)
		{
			if (!Client.SelectedUnit.IsContact())
			{
				return;
			}
			unit = (Contact)Client.SelectedUnit;
		}
		else
		{
			unit = (ActiveUnit)Client.SelectedUnit;
		}
		if (!observableList_0[0].FocusedBefore)
		{
			if (!unit.IsActiveUnit)
			{
				observableList_0[0].FocusCameraOnUnit(unit.ObjectID);
			}
			else
			{
				observableList_0[0].FocusCameraOnUnit(unit.ObjectID, (int)Math.Round(2f * ((ActiveUnit)unit).Length));
			}
			observableList_0[0].FocusedBefore = true;
		}
		else
		{
			observableList_0[0].FocusCameraOnUnit(unit.ObjectID);
		}
	}

	public static void FocusCameraOnSelectedUnitAndPrimaryTarget()
	{
		if (Client.SelectedUnit != null && !Client.SelectedUnit.IsGroup && Client.SelectedUnit.IsActiveUnit && ((ActiveUnit)Client.SelectedUnit).AI.PrimaryTarget != null)
		{
			observableList_0[0].FocusCameraOnUnit_Dogfight(Client.SelectedUnit.ObjectID, ((ActiveUnit)Client.SelectedUnit).AI.PrimaryTarget.ActualUnit.ObjectID);
		}
	}

	public static bool SupportsFrameRateLimit()
	{
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(SimConfiguration.DefaultGamePreferences.TacviewExePath);
		if (versionInfo.FileMajorPart >= 1)
		{
			int result;
			if (versionInfo.FileMinorPart == 8 && versionInfo.FileBuildPart >= 7)
			{
				result = 1;
			}
			else
			{
				if (versionInfo.FileMinorPart <= 8)
				{
					goto IL_003b;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
		goto IL_003b;
		IL_003b:
		return false;
	}

	public static void SpawnTacviewWindow()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (OSVersionInfo.MajorVersion >= 10 && !SignatureCheck.ExeHasValidCertificate(SimConfiguration.DefaultGamePreferences.TacviewExePath))
		{
			DarkMessageBox.ShowError("It appears that the Tacview executable you have specified is invalid. Please use a valid executable. For assistance please contact MatrixGames or Raia Software.", "Invalid Tacview exe!");
			return;
		}
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(SimConfiguration.DefaultGamePreferences.TacviewExePath);
		if (versionInfo.FileMajorPart <= 1 && versionInfo.FileMinorPart <= 8 && versionInfo.FileBuildPart < 1)
		{
			DarkMessageBox.ShowError("It appears that you are using an older version of Tacview (" + Conversions.ToString(versionInfo.FileMajorPart) + "." + Conversions.ToString(versionInfo.FileMinorPart) + "." + Conversions.ToString(versionInfo.FileBuildPart) + "). Please download & install at least version 1.8.1. For assistance please contact MatrixGames or Raia Software.", "Out-of-date Tacview version!");
		}
		else if (!observableList_0.Any())
		{
			TacviewClient.Factory();
		}
	}

	private static void smethod_2(object object_0, ObservableListModified<TacviewClient> observableListModified_0)
	{
		theExporter.PipeClientsPresent = true;
	}

	private static void smethod_3(object object_0, ObservableListModified<TacviewClient> observableListModified_0)
	{
		if (observableList_0.Count == 0)
		{
			theExporter.PipeClientsPresent = false;
			theExporter.DestroyCache();
		}
		else
		{
			theExporter.PipeClientsPresent = true;
		}
	}
}
