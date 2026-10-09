using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Command.Tacview;
using CommandNetcode.RT.PlayFabWrapper;
using DarkUI.Forms;
using Magic.Samples.DisplaySettings;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace Command;

[StandardModule]
internal sealed class Startup
{
	[Flags]
	public enum EXECUTION_STATE : uint
	{
		ES_AWAYMODE_REQUIRED = 0x40u,
		ES_CONTINUOUS = 0x80000000u,
		ES_DISPLAY_REQUIRED = 2u,
		ES_SYSTEM_REQUIRED = 1u
	}

	[CompilerGenerated]
	internal sealed class _Closure$__15-0
	{
		public TacviewClient $VB$Local_tvc;

		public _Closure$__15-0(_Closure$__15-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_tvc = arg0.$VB$Local_tvc;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_tvc.Close();
		}

		static _Closure$__15-0()
		{
			Class72.smethod_20();
		}
	}

	public static List<string> _AssemblyLogBuffer;

	public static CultureInfo InitialCultureInfo;

	static Startup()
	{
		Class77.smethod_3();
		Class72.smethod_20();
		_AssemblyLogBuffer = new List<string>();
	}

	[DllImport("user32.dll")]
	private static extern bool SetProcessDpiAwarenessContext(int int_0);

	[STAThread]
	public static int Main(string[] args)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		Class77.smethod_3();
		try
		{
			SetProcessDpiAwarenessContext(-4);
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyLoad += [SpecialName] (object sender, AssemblyLoadEventArgs e) =>
			{
				smethod_1(RuntimeHelpers.GetObjectValue(sender), e);
			};
			currentDomain.UnhandledException += MainExceptionHandler;
			Application.ApplicationExit += PerformShutdown;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application val = Application.Current;
			if (val == null)
			{
				val = new Application();
			}
			val.ShutdownMode = (ShutdownMode)2;
			smethod_4();
			NetworkChange.NetworkAvailabilityChanged += smethod_2;
			Application.Run((Form)(object)MyProject.Forms.MainForm);
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
		finally
		{
			PerformShutdown();
		}
		return 0;
	}

	private static Assembly smethod_0(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		if (resolveEventArgs_0 != null)
		{
			string text = " ?Resolve assembly: " + resolveEventArgs_0.Name;
			if (_AssemblyLogBuffer != null)
			{
				_AssemblyLogBuffer.Add(text);
			}
			else
			{
				GameGeneral.WriteLogDebugInfoToFile(text);
			}
		}
		return null;
	}

	private static Assembly smethod_1(object object_0, AssemblyLoadEventArgs assemblyLoadEventArgs_0)
	{
		if (assemblyLoadEventArgs_0 != null)
		{
			string text = "!Load assembly: " + assemblyLoadEventArgs_0.LoadedAssembly.FullName;
			try
			{
				text = text + " from " + assemblyLoadEventArgs_0.LoadedAssembly.Location;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (_AssemblyLogBuffer == null)
			{
				GameGeneral.WriteLogDebugInfoToFile(text);
			}
			else
			{
				_AssemblyLogBuffer.Add(text);
			}
		}
		return null;
	}

	public static void MainExceptionHandler(object sender, UnhandledExceptionEventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Exception ex = (Exception)e.ExceptionObject;
		DarkMessageBox.ShowError("Error: " + ex.Message + "\r\n\r\n", "Error");
		GameGeneral.WriteExceptionsToLog(ex);
	}

	private static void smethod_2(object object_0, object object_1)
	{
	}

	public static bool UseCompatibleTextRendering()
	{
		return false;
	}

	private static void smethod_3(object object_0, object object_1)
	{
		PerformShutdown();
	}

	public static void PerformShutdown(object sender = null, EventArgs e = null)
	{
		if (Client.startGameMenuWindow_0 != null)
		{
			StartGameMenuWindow.HideStartWindow();
		}
		Client.ShutdownCleanup();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		Terrain.CleanUp();
		CommandSteam.CloseSteamConnection();
		if (PowerManagement.IsSupportedByOS())
		{
			PowerManagement.ResetToOriginalSetting();
		}
		if (Client.OriginalDisplaySettings.Height > 0)
		{
			DisplayManager.SetDisplaySettings(Client.OriginalDisplaySettings);
		}
		if (Directory.Exists(GameGeneral.TempPath))
		{
			try
			{
				Misc.DeleteEverythingInDirectory(GameGeneral.TempPath);
				Directory.Delete(GameGeneral.TempPath);
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
		if (TacviewServer.Clients.Count > 0)
		{
			_Closure$__15-0 closure$__15- = default(_Closure$__15-0);
			foreach (TacviewClient item in TacviewServer.Clients.ToList())
			{
				closure$__15- = new _Closure$__15-0(closure$__15-);
				closure$__15-.$VB$Local_tvc = item;
				try
				{
					Task.Factory.StartNew(closure$__15-._Lambda$__0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			Thread.Sleep(1000);
		}
		PlayFabClientWrapper.Logout();
		int threadExecutionState;
		if (!RealtimeLobby.IsRTMPHostRunning())
		{
			threadExecutionState = int.MinValue;
		}
		else
		{
			RealtimeLobby.KillRTMPHost();
			threadExecutionState = int.MinValue;
		}
		SetThreadExecutionState((EXECUTION_STATE)threadExecutionState);
		Environment.Exit(0);
	}

	[DllImport("kernel32.dll")]
	private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE execution_STATE_0);

	private static void smethod_4()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_097c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		DpiHelper.SetUnaware();
		SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
		SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(smethod_6);
		try
		{
			RegistryKey val = Registry.CurrentUser.OpenSubKey("SOFTWARE\\WOW6432Node\\Matrix Games\\CMO2");
			if (val != null)
			{
				GameGeneral.TopLevelWritablePath = Conversions.ToString(val.GetValue("TopLevelWritablePath"));
				val.Close();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (FileExistsNative.FileExistsFast(Application.StartupPath + "\\WritableRoot.txt"))
			{
				string text = File.ReadAllText(Application.StartupPath + "\\WritableRoot.txt");
				if (Directory.Exists(text))
				{
					GameGeneral.TopLevelWritablePath = text;
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		if (!Directory.Exists(Path.Combine(GameGeneral.GISFolderPath, "LandCover")))
		{
			DarkMessageBox.ShowError("Land-cover map files not found! Aborting...", "v1.10 - Build 1900.20 - Error");
			Environment.Exit(0);
		}
		GameGeneral.WriteLogDebugInfoToFile("\r\n--------------- Starting new GUI-client session - " + DateTime.Now.ToString() + " Build v1.10 - Build 1900.20 -----------------");
		GameGeneral.WriteLogDebugInfoToFile("\r\n" + DpiHelper.StateDpiAwareness());
		try
		{
			InitialCultureInfo = Thread.CurrentThread.CurrentCulture;
			try
			{
				string text2 = Environment.NewLine + "User's machine " + Environment.NewLine;
				text2 = text2 + "Machine's name : " + Environment.MachineName + Environment.NewLine;
				text2 = text2 + "Thread's culture : " + InitialCultureInfo.Name + Environment.NewLine;
				text2 = text2 + "Installed culture : " + ((ServerComputer)MyProject.Computer).Info.InstalledUICulture.Name + Environment.NewLine;
				text2 = text2 + "Available virtual memory : " + ((double)((ServerComputer)MyProject.Computer).Info.AvailableVirtualMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Available RAM : " + ((double)((ServerComputer)MyProject.Computer).Info.AvailablePhysicalMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Total virtual memory : " + ((double)((ServerComputer)MyProject.Computer).Info.TotalVirtualMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Total RAM : " + ((double)((ServerComputer)MyProject.Computer).Info.TotalPhysicalMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "OS name : " + ((ServerComputer)MyProject.Computer).Info.OSFullName + Environment.NewLine;
				text2 = text2 + "OS platform : " + ((ServerComputer)MyProject.Computer).Info.OSPlatform + Environment.NewLine;
				text2 = text2 + "OS version : " + ((ServerComputer)MyProject.Computer).Info.OSVersion + Environment.NewLine;
				text2 = ((!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)) ? (text2 + ">>Not running as administrator ! <<" + Environment.NewLine) : (text2 + ">>Running as administrator. <<" + Environment.NewLine));
				GameGeneral.WriteLogDebugInfoToFile(text2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200575UMI", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			StartGameMenuWindow.ShowStartWindow();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		try
		{
			try
			{
				if (!Directory.Exists(GameGeneral.ConfigFolderPath))
				{
					Directory.CreateDirectory(GameGeneral.ConfigFolderPath);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				DarkMessageBox.ShowError("Error found during alpha1 application startup. Error details: " + ex4.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				DarkMessageBox.ShowError("Error found during alpha2 application startup. Error details: " + ex6.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				Client.RunningInSteamMode = Application.StartupPath.Contains("steamapps\\common");
				if (FileExistsNative.FileExistsFast(Application.StartupPath + "\\force_steam"))
				{
					Client.RunningInSteamMode = true;
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				DarkMessageBox.ShowError("Error found during alpha3 application startup. Error details: " + ex8.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (Client.RunningInSteamMode)
				{
					if (!File.Exists("steam_appid.txt"))
					{
						try
						{
							File.WriteAllText("steam_appid.txt", "1076160");
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							ProjectData.ClearProjectError();
						}
					}
					CommandSteam.OpenSteamConnection();
					if (!CommandSteam.steamOnline)
					{
						DarkMessageBox.ShowError("It appears you are running Command in Steam mode, but the Steam client does not appear to be running. Please ensure the Steam client is running before starting Command. The game will now exit.", "v1.10 - Build 1900.20 - Steam client Not running!");
						PerformShutdown();
					}
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				DarkMessageBox.ShowError("Error found during alpha4 application startup. Error details:  " + ex10.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (Directory.Exists(GameGeneral.TempPath))
				{
					try
					{
						Misc.DeleteEverythingInDirectory(GameGeneral.TempPath);
						Directory.Delete(GameGeneral.TempPath);
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				DarkMessageBox.ShowError("Error found during alpha5 application startup. Error details: " + ex12.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (!Directory.Exists(GameGeneral.TempPath))
				{
					Directory.CreateDirectory(GameGeneral.TempPath);
				}
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13);
				Exception ex14 = ex13;
				DarkMessageBox.ShowError("Error found during alpha6 application startup. Error details: " + ex14.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				Process.GetCurrentProcess().PriorityBoostEnabled = true;
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15);
				Exception ex16 = ex15;
				ex16?.Data.Add("Error at 200358", ex16.Message);
				GameGeneral.WriteExceptionsToLog(ex16);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
				ProjectData.ClearProjectError();
			}
			try
			{
				Client.ConsolidateConfigFiles();
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17);
				Exception ex18 = ex17;
				DarkMessageBox.ShowError("Error found during beta7 application startup. Error details: " + ex18.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (SimConfiguration.DefaultGamePreferences == null)
				{
					SimConfiguration.LoadSettings(ref WindowPlacement.WindowPlacementSettings, ref Client.RecentFilenames);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("Successfully loaded Sim Configuration.");
					}
				}
			}
			catch (Exception ex19)
			{
				ProjectData.SetProjectError(ex19);
				Exception ex20 = ex19;
				DarkMessageBox.ShowError("Error found during beta-1 application startup. Error details: " + ex20.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				SimConfiguration.CreateDefaultSettings();
				Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings = null;
				SimConfiguration.LoadSettings(ref WindowPlacementSettings, ref Client.RecentFilenames);
				ProjectData.ClearProjectError();
			}
			try
			{
				Process[] processes = Process.GetProcesses();
				string processName = Process.GetCurrentProcess().ProcessName;
				DateTime startTime = Process.GetCurrentProcess().StartTime;
				Process[] array = processes;
				foreach (Process process in array)
				{
					try
					{
						if (Operators.CompareString(process.ProcessName, processName, true) == 0 && DateTime.Compare(process.StartTime, startTime) != 0)
						{
							process.Kill();
						}
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						ProjectData.ClearProjectError();
					}
					try
					{
						if (Operators.CompareString(process.ProcessName, "CommandHost", true) == 0 && Operators.CompareString(process.MainModule.ModuleName, "CommandHost.exe", true) == 0)
						{
							process.Kill();
						}
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex21)
			{
				ProjectData.SetProjectError(ex21);
				Exception ex22 = ex21;
				GameGeneral.WriteLogDebugInfoToFile("Error found during beta4 application startup. Error details: " + ex22.Message);
				ProjectData.ClearProjectError();
			}
			try
			{
				StartGameMenuWindow.UpdateStartWindow();
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (Screen.PrimaryScreen.BitsPerPixel != 32)
				{
					DarkMessageBox.ShowError("Please set your screen's color depth to 32-bit and restart Command.", "v1.10 - Build 1900.20 - Error");
					PerformShutdown();
				}
			}
			catch (Exception ex23)
			{
				ProjectData.SetProjectError(ex23);
				Exception ex24 = ex23;
				DarkMessageBox.ShowError("Error found during beta6 application startup. Error details: " + ex24.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (SimConfiguration.DefaultGamePreferences == null)
				{
					SimConfiguration.LoadSettings(ref WindowPlacement.WindowPlacementSettings, ref Client.RecentFilenames);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("Successfully loaded Sim Configuration.");
					}
				}
			}
			catch (Exception ex25)
			{
				ProjectData.SetProjectError(ex25);
				Exception ex26 = ex25;
				DarkMessageBox.ShowError("Error found during gamma1 application startup. Error details: " + ex26.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			if (GameGeneral.bool_0)
			{
				if (FileExistsNative.FileExistsFast(Application.StartupPath + "\\Multiplayer\\Player.bin"))
				{
					try
					{
						File.Delete(Application.StartupPath + "\\Multiplayer\\Player.bin");
					}
					catch (Exception ex27)
					{
						ProjectData.SetProjectError(ex27);
						Exception ex28 = ex27;
						DarkMessageBox.ShowError("Unable to delete file \\Multiplayer\\Player.bin. Error details: " + ex28.Message, "Error in Application_Startup!");
						ProjectData.ClearProjectError();
					}
				}
				if (FileExistsNative.FileExistsFast(Application.StartupPath + "\\Multiplayer\\Multiplayer.bin"))
				{
					try
					{
						File.Delete(Application.StartupPath + "\\Multiplayer\\Multiplayer.bin");
					}
					catch (Exception ex29)
					{
						ProjectData.SetProjectError(ex29);
						Exception ex30 = ex29;
						DarkMessageBox.ShowError("Unable to delete file \\Multiplayer\\Multiplayer.bin. Error details: " + ex30.Message, "Error in Application_Startup!");
						ProjectData.ClearProjectError();
					}
				}
			}
			try
			{
				Application.ThreadException += new CustomExceptionHandler().ThreadExceptionHandler;
			}
			catch (Exception ex31)
			{
				ProjectData.SetProjectError(ex31);
				Exception ex32 = ex31;
				DarkMessageBox.ShowError("Error found during gamma3 application startup. Error details: " + ex32.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
				throw;
			}
			try
			{
				GameGeneral.WriteLogDebugInfoToFile("Discovering DPI");
				Module1.DiscoverDPISetting_UsingBitmap();
				if (Client.DPI_scale == 0f)
				{
					GameGeneral.WriteLogDebugInfoToFile("DPI_scale = 0");
				}
				if (Client.DPI_scale == 1f)
				{
					((ContainerControl)MyProject.Forms.MainForm).AutoScaleMode = (AutoScaleMode)0;
				}
				if (Client.DPI_scale > 1f)
				{
					GameGeneral.WriteLogDebugInfoToFile("AdjustForHighDPI");
					AdjustForHighDPI();
				}
			}
			catch (Exception ex33)
			{
				ProjectData.SetProjectError(ex33);
				Exception ex34 = ex33;
				GameGeneral.WriteLogDebugInfoToFile("EXCEPTION during DPI");
				GameGeneral.WriteExceptionsToLog(ex34);
				Client.DPI_scale = 1f;
				ProjectData.ClearProjectError();
			}
			try
			{
				GameGeneral.WriteLogDebugInfoToFile("Client.Initalize");
				Client.Initialize();
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				GameGeneral.WriteLogDebugInfoToFile("Client.Initalize FAILED");
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex35)
		{
			ProjectData.SetProjectError(ex35);
			Exception ex36 = ex35;
			ex36?.Data.Add("Error at 200575", ex36.Message);
			GameGeneral.WriteExceptionsToLog(ex36);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("Error found during application startup. Error details: " + ex36.Message, "v1.10 - Build 1900.20 - Error in Application_Startup!");
			ProjectData.ClearProjectError();
		}
	}

	public static void AdjustForHighDPI()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		string text = Path.Combine(Application.StartupPath, Process.GetCurrentProcess().ProcessName + ".exe");
		if (!FileExistsNative.FileExistsFast(text))
		{
			DarkMessageBox.ShowError("File Command.exe not found on this folder. Please run this tool inside the same folder that Command.exe is located. Press any key to exit.", "File not found");
			Environment.Exit(0);
		}
		if (!smethod_5(Registry.CurrentUser, "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers"))
		{
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
		}
		string text2 = Conversions.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)string.Empty));
		if (text2.Contains("~ DPIUNAWARE"))
		{
			return;
		}
		bool flag = false;
		try
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)(text2 + " ~ DPIUNAWARE"));
			text2 = Conversions.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)string.Empty));
			flag = text2.Contains("~ DPIUNAWARE");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = false;
			ProjectData.ClearProjectError();
		}
		if (!flag)
		{
			DarkMessageBox.ShowWarning("CAUTION! Your system appears to be using a high-DPI desktop setting (e.g. a 1440p or 4K monitor). We reccomend that you exit Command and run the 4KFix helper app (located on the same folder as Command.exe) to properly adjust Command for this environment. We apologize for the inconvenience!", "High-DPI settings detected");
			return;
		}
		string path = Path.Combine(GameGeneral.TempPath, "instance");
		if (Directory.Exists(path))
		{
			Directory.Delete(path, recursive: true);
		}
		try
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(text);
			processStartInfo.CreateNoWindow = false;
			processStartInfo.UseShellExecute = false;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			Environment.Exit(0);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	private static bool smethod_5(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.OpenSubKey(string_0) != null;
	}

	private static void smethod_6(object sender, PowerModeChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		PowerModes mode = e.Mode;
		if ((int)mode == 3)
		{
			((Form)MyProject.Forms.MainForm).WindowState = (FormWindowState)1;
		}
	}
}
