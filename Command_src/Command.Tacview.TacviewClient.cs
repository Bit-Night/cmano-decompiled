using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Collections.Pooled;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Tacview;

public sealed class TacviewClient
{
	public int FormHeight;

	public int FormWidth;

	internal bool FocusedBefore;

	public static string TacviewTimeSeparator;

	public string Id;

	private bool bool_0;

	private bool bool_1;

	public HashSet<string> CacheSentHashset;

	public Thread myDedicatedThread;

	public Process ManagerProcess;

	public ConcurrentQueue<List<(string, IEventExporter.EventExportNotification)>> EventQueue;

	public string SideID;

	public bool GodsEye;

	public Process TacviewProcess;

	public AnonymousPipeServerStream pipeRead_Telemetry;

	public AnonymousPipeServerStream pipeWrite_Telemetry;

	public AnonymousPipeServerStream pipeRead_Control;

	public AnonymousPipeServerStream pipeWrite_Control;

	public StreamWriter pipeStreamWriter_Telemetry;

	public StreamWriter pipeStreamWriter_Control;

	static TacviewClient()
	{
		Class72.smethod_20();
		TacviewTimeSeparator = ":";
	}

	public static string ACMIHeaderString(Scenario theScen)
	{
		string result;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			string timeSeparator = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			stringBuilder.Append("FileType=text/acmi/tacview").Append("\r\n");
			stringBuilder.Append("FileVersion=2.2").Append("\r\n");
			if (Operators.CompareString(timeSeparator, TacviewTimeSeparator, true) == 0)
			{
				stringBuilder.Append("0,ReferenceTime=" + theScen.ZeroHour.ToString("yyyy-MM-ddThh:mm:ss")).Append("Z").Append("\r\n");
			}
			else
			{
				string text = theScen.ZeroHour.ToString("hh:mm:ss");
				text = text.Replace(timeSeparator, TacviewTimeSeparator);
				stringBuilder.Append("0,ReferenceTime=" + theScen.ZeroHour.ToString("yyyy-MM-ddT")).Append(text).Append("Z")
					.Append("\r\n");
			}
			result = stringBuilder.ToString();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void DumpCurrentState(Scenario theScen)
	{
		try
		{
			TacviewServer.theExporter.InitializingScenario = true;
			if (!Client.CurrentMapProfile.GodsEye)
			{
				if (Client.CurrentSide == null)
				{
					return;
				}
				List<ActiveUnit> list = Client.CurrentSide.get_FriendlyUnits_OperativeOnly(Client.CurrentScenario, IncludeWeapons: true);
				foreach (ActiveUnit item in list)
				{
					if (!item.IsGroup && item.IsOperating())
					{
						item.Kinematics.ExportLocationEvent("DumpCurrentState");
					}
				}
				PooledList<Contact> contacts_List = Client.CurrentSide.Contacts_List;
				{
					foreach (Contact item2 in contacts_List)
					{
						ActiveUnit_Sensory.ExportContactLocationEvent(item2, Client.CurrentSide, Client.CurrentScenario);
					}
					return;
				}
			}
			List<ActiveUnit> list2 = new List<ActiveUnit>(theScen.ActiveUnits_List);
			foreach (ActiveUnit item3 in list2)
			{
				if (!item3.IsGroup && item3.IsOperating())
				{
					item3.Kinematics.ExportLocationEvent("DumpCurrentState");
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
		finally
		{
			TacviewServer.theExporter.InitializingScenario = false;
		}
	}

	public static void RefreshContactsOfCurrentSide()
	{
		if ((Client.CurrentMapProfile != null && Client.CurrentMapProfile.GodsEye) || Client.CurrentSide == null)
		{
			return;
		}
		PooledList<Contact> contacts_List = Client.CurrentSide.Contacts_List;
		foreach (Contact item in contacts_List)
		{
			ActiveUnit_Sensory.ExportContactLocationEvent(item, Client.CurrentSide, Client.CurrentScenario);
		}
	}

	public void Close()
	{
		try
		{
			TacviewProcess.Kill();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			ManagerProcess.Kill();
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeWrite_Telemetry.Close();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeRead_Telemetry.Close();
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeWrite_Control.Close();
		}
		catch (Exception projectError5)
		{
			ProjectData.SetProjectError(projectError5);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeRead_Control.Close();
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			ProjectData.ClearProjectError();
		}
		TacviewServer.Clients.Remove(this);
	}

	private TacviewClient()
	{
		bool_0 = false;
		bool_1 = false;
		CacheSentHashset = new HashSet<string>();
		EventQueue = new ConcurrentQueue<List<(string, IEventExporter.EventExportNotification)>>();
		pipeRead_Telemetry = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
		pipeWrite_Telemetry = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable, 104857600);
		pipeRead_Control = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
		pipeWrite_Control = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
		pipeStreamWriter_Telemetry = new StreamWriter(pipeWrite_Telemetry);
		pipeStreamWriter_Control = new StreamWriter(pipeWrite_Control);
	}

	public void Resize()
	{
		try
		{
			RECT rect_ = default(RECT);
			GetWindowRect(ManagerProcess.MainWindowHandle, ref rect_);
			FormWidth = rect_.Right - rect_.Left + 1;
			FormHeight = rect_.Bottom - rect_.Top + 1;
			pipeStreamWriter_Control.Write("Tacview.UI.SetWindowPosition(0, 0, " + Conversions.ToString(FormWidth) + ", " + Conversions.ToString(FormHeight) + ")\0");
			pipeStreamWriter_Control.Flush();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr intptr_0, ref RECT rect_0);

	public static TacviewClient Factory()
	{
		lock (TacviewServer.ServerLockObj)
		{
			if (Exporter_General.EventExporters_Interactive.Where([SpecialName] (IEventExporter theExp) => theExp.ExporterType == IEventExporter.EventExporterType.TacviewPipe).Count() == 0)
			{
				TacviewServer.AttachExporter();
			}
			Exporter_General.EventExporters_Interactive.Where([SpecialName] (IEventExporter theExp) => theExp.ExporterType == IEventExporter.EventExporterType.TacviewPipe).FirstOrDefault().IsOperating = true;
			TacviewClient tacviewClient = new TacviewClient();
			TacviewServer.Clients.Add(tacviewClient);
			tacviewClient.Id = "tvc-" + Guid.NewGuid().ToString().Substring(0, 4);
			if (Client.CurrentScenario.GetCurrentSide() != null)
			{
				tacviewClient.SideID = Client.CurrentScenario.GetCurrentSide().ObjectID;
			}
			else
			{
				tacviewClient.SideID = "";
			}
			tacviewClient.GodsEye = Client.CurrentMapProfile.GodsEye;
			tacviewClient.ManagerProcess = TacviewServer.LoadApplication("CommandTacviewManager.exe", "", IntPtr.Zero);
			while (tacviewClient.ManagerProcess.MainWindowHandle == IntPtr.Zero)
			{
				Thread.Sleep(10);
			}
			RECT rect_ = default(RECT);
			GetWindowRect(tacviewClient.ManagerProcess.MainWindowHandle, ref rect_);
			tacviewClient.FormWidth = rect_.Right - rect_.Left + 1;
			tacviewClient.FormHeight = rect_.Bottom - rect_.Top + 1;
			string text = Conversions.ToInteger(tacviewClient.pipeWrite_Telemetry.GetClientHandleAsString()).ToString("X");
			string text2 = Conversions.ToInteger(tacviewClient.pipeRead_Telemetry.GetClientHandleAsString()).ToString("X");
			string text3 = Conversions.ToInteger(tacviewClient.pipeWrite_Control.GetClientHandleAsString()).ToString("X");
			string text4 = Conversions.ToInteger(tacviewClient.pipeRead_Control.GetClientHandleAsString()).ToString("X");
			string args = "/RealTimeTelemetryPipe:" + text + ":" + text2 + " /LuaPipe:" + text3 + ":" + text4 + " /ReadOnly:true " + ((!TacviewServer.SupportsFrameRateLimit()) ? string.Empty : "/MaxFrameRate:30 ") + "/ResourceFolder:\"" + GameGeneral.ResourcesFolderPath + "\\Tacview\\\"";
			tacviewClient.TacviewProcess = TacviewServer.LoadApplication(SimConfiguration.DefaultGamePreferences.TacviewExePath, args, tacviewClient.ManagerProcess.MainWindowHandle);
			tacviewClient.pipeRead_Telemetry.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeWrite_Telemetry.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeRead_Control.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeWrite_Control.DisposeLocalCopyOfClientHandle();
			string empty = string.Empty;
			empty += "XtraLib.Stream.0\n";
			empty += "Tacview.RealTimeTelemetry.0\n";
			empty += "CMANO host\n\0";
			tacviewClient.pipeStreamWriter_Telemetry.Write(empty);
			tacviewClient.pipeStreamWriter_Telemetry.Flush();
			string empty2 = string.Empty;
			empty2 += "XtraLib.Stream.0\n";
			empty2 += "Tacview.Lua.0\n";
			empty2 += "CMANO host\n\0";
			tacviewClient.pipeStreamWriter_Control.Write(empty2);
			tacviewClient.pipeStreamWriter_Control.Write("Tacview = require('Tacview180')\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.SetWindowParent(" + Conversions.ToString((int)tacviewClient.ManagerProcess.MainWindowHandle) + ")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.EnterReadMode(true)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Overlay.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Grid.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Direction.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Height.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Labels.Visible\", true)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetString(\"UI.View.Terrain.Mode\", \"Full3D\")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.SetWindowPosition(0, 0, " + Conversions.ToString(tacviewClient.FormWidth) + ", " + Conversions.ToString(tacviewClient.FormHeight) + ")\0");
			tacviewClient.pipeStreamWriter_Control.Flush();
			tacviewClient.myDedicatedThread = new Thread(tacviewClient.StartDedicatedExportThread);
			tacviewClient.myDedicatedThread.Name = tacviewClient.Id + " Thread";
			tacviewClient.myDedicatedThread.Priority = ThreadPriority.Normal;
			tacviewClient.myDedicatedThread.Start();
			tacviewClient.method_0(ACMIHeaderString(Client.CurrentScenario));
			DumpCurrentState(Client.CurrentScenario);
			TacviewClient result = default(TacviewClient);
			return result;
		}
	}

	private void method_0(string string_0)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (pipeWrite_Telemetry.IsConnected)
			{
				pipeStreamWriter_Telemetry.Write(string_0 + "\r\n");
				pipeStreamWriter_Telemetry.Flush();
			}
			else if (!bool_0)
			{
				DarkMessageBox.ShowError("Tacview has disconnected from Command.", "Tacview disconnected");
				bool_0 = true;
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

	private void method_1(string string_0)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (pipeWrite_Control.IsConnected)
			{
				pipeStreamWriter_Control.Write(string_0 + "\0");
				pipeStreamWriter_Control.Flush();
			}
			else if (!bool_0)
			{
				DarkMessageBox.ShowError("Tacview has disconnected from Command.", "Tacview disconnected");
				bool_0 = true;
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

	public void StartDedicatedExportThread()
	{
		int num = 1;
		while (true)
		{
			num++;
			method_2();
			Thread.Sleep(50);
			if (num % 20 == 0)
			{
				num = 1;
				try
				{
					Resize();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (ManagerProcess.HasExited)
				{
					break;
				}
			}
		}
		Close();
	}

	private void method_2()
	{
		try
		{
			List<(string, IEventExporter.EventExportNotification)> result = new List<(string, IEventExporter.EventExportNotification)>(EventQueue.Count * 2);
			while (EventQueue.Count > 0)
			{
				EventQueue.TryDequeue(out result);
				foreach (var item in result)
				{
					method_3(item);
					try
					{
						if (item.Item2.EventType != IEventExporter.ExportedEventType.UnitDestroyed)
						{
							continue;
						}
						if (TacviewServer.EchoDestruction == null)
						{
							TacviewServer.EchoDestruction = new Dictionary<string, float>();
						}
						if (TacviewServer.EchoDestruction.ContainsKey(item.Item1))
						{
							if (TacviewServer.EchoDestruction[item.Item1] >= TacviewServer.EchoCount)
							{
								TacviewServer.EchoDestruction.Remove(item.Item1);
								continue;
							}
							TacviewServer.EchoDestruction[item.Item1] += 1f;
							List<(string, IEventExporter.EventExportNotification)> list = new List<(string, IEventExporter.EventExportNotification)>();
							list.Add(item);
							EventQueue.Enqueue(list);
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			if (!bool_1 && Client.SelectedUnit != null)
			{
				FocusCameraOnUnit(Client.SelectedUnit.ObjectID);
				bool_1 = true;
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FocusCameraOnUnit(string UnitObjectID, int CameraDistance_meters = 0)
	{
		try
		{
			if (TacviewServer.theExporter.DeclaredUnits.Count != 0 && TacviewServer.theExporter.DeclaredUnits.TryGetValue(UnitObjectID, out var value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(0, objectHandle)").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")").Append("\r\n");
				if (CameraDistance_meters != 0)
				{
					stringBuilder.Append("Tacview.Context.Camera.SetRangeToTarget( ").Append(CameraDistance_meters).Append(" )")
						.Append("\r\n");
				}
				string string_ = stringBuilder.ToString();
				method_1(string_);
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

	public void FocusCameraOnUnit_Dogfight(string Unit1ObjectID, string Unit2ObjectID)
	{
		try
		{
			if (TacviewServer.theExporter.DeclaredUnits.Count != 0 && TacviewServer.theExporter.DeclaredUnits.TryGetValue(Unit1ObjectID, out var value) && TacviewServer.theExporter.DeclaredUnits.TryGetValue(Unit2ObjectID, out var value2))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(0, objectHandle)").Append("\r\n");
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value2).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(1, objectHandle)").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Dogfight.Mode\", \"LookAt\")").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetBoolean(\"UI.View.Camera.Dogfight.Enabled\", true)").Append("\r\n");
				stringBuilder.Append("local roll = 10").Append("\r\n");
				stringBuilder.Append("local pitch = 10").Append("\r\n");
				stringBuilder.Append("local yaw = 45").Append("\r\n");
				stringBuilder.Append("Tacview.Context.Camera.SetRotation( math.rad(roll) , math.rad(pitch) , math.rad(yaw) )").Append("\r\n");
				string string_ = stringBuilder.ToString();
				method_1(string_);
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

	private void method_3((string, IEventExporter.EventExportNotification) valueTuple_0)
	{
		try
		{
			string text = default(string);
			switch (valueTuple_0.Item2.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["WeaponID"].Value);
				break;
			case IEventExporter.ExportedEventType.WeaponEndgame:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["WeaponID"].Value);
				break;
			case IEventExporter.ExportedEventType.UnitDestroyed:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.UnitPositions:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				if (!Client.CurrentMapProfile.GodsEye && Client.CurrentSide != null)
				{
					List<ActiveUnit> list = Client.CurrentSide.get_FriendlyUnits_OperativeOnly(Client.CurrentScenario, IncludeWeapons: true).ToList();
					ActiveUnit item = Client.CurrentScenario.ActiveUnits[text];
					if (!list.Contains(item))
					{
						return;
					}
				}
				break;
			case IEventExporter.ExportedEventType.WeaponImpact:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.Explosion:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["ExplosionID"].Value);
				break;
			case IEventExporter.ExportedEventType.AirOps:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.DockingOps:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.WaterSplash:
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.ContactPositions:
			{
				Side side = null;
				side = Client.CurrentScenario.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.Name, valueTuple_0.Item2.EventParameters["ObserverSide"].Value.ToString(), true) == 0).FirstOrDefault();
				if (side == null)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (side != Client.CurrentSide)
				{
					return;
				}
				text = Conversions.ToString(valueTuple_0.Item2.EventParameters["ContactID"].Value);
				break;
			}
			}
			if (!CacheSentHashset.Contains(text))
			{
				CacheSentHashset.Add(text);
				if (TacviewServer.theExporter.NewUnitCache.ContainsKey(text))
				{
					method_0(TacviewServer.theExporter.NewUnitCache[text]);
				}
			}
			method_0(valueTuple_0.Item1);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			method_0(valueTuple_0.Item1);
			ProjectData.ClearProjectError();
		}
	}

	public override string ToString()
	{
		return Id;
	}
}
