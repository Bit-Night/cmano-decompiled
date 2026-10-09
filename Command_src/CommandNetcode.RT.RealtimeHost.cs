using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core;
using CSMaterial;
using DarkUI.Collections;
using PlayFabParty;
using ServiceStack.Text;

namespace CommandNetcode.RT;

public class RealtimeHost
{
	public class RealtimeClient
	{
		public static class GeoUtil
		{
			public static bool IsPointInsideQuadrilateral(double lat, double lon, (double, double)[] screen)
			{
				Tuple<double, double, double> tuple_ = smethod_0(lat, lon);
				Tuple<double, double, double>[] array = new Tuple<double, double, double>[screen.Length];
				for (int i = 0; i < screen.Length; i++)
				{
					array[i] = smethod_0(screen[i].Item1, screen[i].Item2);
				}
				double num = smethod_3(array);
				double num2 = 0.0;
				for (int j = 0; j < array.Length; j++)
				{
					num2 += smethod_1(tuple_, array[j], array[(j + 1) % array.Length]);
				}
				return Math.Abs(num - num2) < 0.001;
			}

			private static Tuple<double, double, double> smethod_0(double double_0, double double_1)
			{
				double num = Math.PI / 180.0 * double_0;
				double num2 = Math.PI / 180.0 * double_1;
				double item = Math.Cos(num) * Math.Cos(num2);
				double item2 = Math.Cos(num) * Math.Sin(num2);
				double item3 = Math.Sin(num);
				return new Tuple<double, double, double>(item, item2, item3);
			}

			private static double smethod_1(Tuple<double, double, double> tuple_0, Tuple<double, double, double> tuple_1, Tuple<double, double, double> tuple_2)
			{
				double num = Math.Acos(smethod_2(tuple_1, tuple_2));
				double num2 = Math.Acos(smethod_2(tuple_0, tuple_2));
				double num3 = Math.Acos(smethod_2(tuple_0, tuple_1));
				double num4 = (num + num2 + num3) / 2.0;
				double num5 = Math.Tan(num4 / 2.0);
				double num6 = Math.Tan((num4 - num) / 2.0);
				double num7 = Math.Tan((num4 - num2) / 2.0);
				double num8 = Math.Tan((num4 - num3) / 2.0);
				return 4.0 * Math.Atan(Math.Sqrt(Math.Max(0.0, num5 * num6 * num7 * num8))) * 6371.0 * 6371.0;
			}

			private static double smethod_2(Tuple<double, double, double> tuple_0, Tuple<double, double, double> tuple_1)
			{
				return tuple_0.Item1 * tuple_1.Item1 + tuple_0.Item2 * tuple_1.Item2 + tuple_0.Item3 * tuple_1.Item3;
			}

			private static double smethod_3(object object_0)
			{
				if (((Array)object_0).Length >= 4)
				{
					return smethod_1((Tuple<double, double, double>)((object[])object_0)[0], (Tuple<double, double, double>)((object[])object_0)[1], (Tuple<double, double, double>)((object[])object_0)[2]) + smethod_1((Tuple<double, double, double>)((object[])object_0)[0], (Tuple<double, double, double>)((object[])object_0)[2], (Tuple<double, double, double>)((object[])object_0)[3]);
				}
				return 0.0;
			}

			static GeoUtil()
			{
				Class72.smethod_20();
			}
		}

		public string IP;

		[CompilerGenerated]
		private TerminalRights terminalRights_0 = TerminalRights.Player;

		[CompilerGenerated]
		private string string_0 = "";

		[CompilerGenerated]
		private int int_0;

		public readonly Guid Guid = Guid.NewGuid();

		public HashSet<string> Contacts = new HashSet<string>();

		public string Name;

		public string LastMessageType = "";

		public List<(double, double)> Screen = new List<(double, double)>();

		public (double, double) Mouse = (0.0, 0.0);

		public (int, int, int) Color = (255, 255, 255);

		public string ErrorMessage = "";

		public DateTime LastHeard;

		public Connection Connection;

		public RealtimeTerminal Loopback;

		public string SelectedUnit_ObjectID;

		public string SelectedWaypoint_ObjectID;

		public string SelectedDoctrine_ObjectID;

		public List<string> SelectedAirHost_ObjectIDs;

		public List<string> SelectedDockingHost_ObjectIDs;

		public int AutoIncrement;

		public int ErrorCount;

		public string SelectedUnit_Name;

		public string CurrentSide_ObjectID = "";

		public bool Gods_Eye;

		public List<ActiveUnit> PreviousGodsEyeActiveUnits = new List<ActiveUnit>();

		public string CurrentSide_Name;

		public float CPU;

		public int LocalTrafficWaiting;

		public uint LastReportedSimExecutionStep;

		public DateTime LastReportedScenarioTime = new DateTime(1900, 1, 1);

		public TerminalRights TerminalRights
		{
			[CompilerGenerated]
			get
			{
				return terminalRights_0;
			}
			[CompilerGenerated]
			set
			{
				terminalRights_0 = value;
			}
		}

		public string TerminalLockedSide
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public int LastGameSpeedRequested
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public bool LoopbackMode => Loopback != null;

		public bool method_0(Module_Unit.Unit u)
		{
			return method_1(u.get_Latitude((GlobalVariables.BooleanObject)null), u.get_Longitude((GlobalVariables.BooleanObject)null));
		}

		public bool method_1(double lat, double lon)
		{
			try
			{
				return GeoUtil.IsPointInsideQuadrilateral(lat, lon, Screen.ToArray());
			}
			catch (Exception)
			{
				int result;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}

		static RealtimeClient()
		{
			Class72.smethod_20();
		}
	}

	public class Options
	{
		public const string MinimumPort = "2000";

		[Description("Use UPnP to 'punch out' of a LAN to wider internet. Set to false if LAN play is desired.")]
		[Category("Server Settings")]
		[DisplayName("UPnP")]
		public bool UPnP { get; set; }

		[Category("Server Settings")]
		[Description("The port the server listens on. Minimum value is 2000.")]
		[DisplayName("Port")]
		public int Port { get; set; }

		[Browsable(false)]
		[DisplayName("Maximum Players")]
		[Category("Server Rules")]
		[Description("The maximum number of players allowed to connect to the server.")]
		public int MaximumPlayers { get; set; }

		[DisplayName("Autosave Interval")]
		[Category("Server Settings")]
		[Description("Number of seconds between autosaves (0 to disable.)")]
		public int AutosaveInterval { get; set; }

		[Description("Folder in which to store auto-saves")]
		[DisplayName("Autosave Folder")]
		[Browsable(false)]
		[Category("Server Settings")]
		public string AutosaveFolder { get; set; }

		[Browsable(false)]
		[DisplayName("Performance Tracking")]
		[Category("Server Settings")]
		[Description("Enable performance tracking. Disable for higher performance.")]
		public bool PerformanceTracking { get; set; }

		[Description("Process and send sound effect data to players. Disable for better performance.")]
		[DisplayName("Sound Effects")]
		[Browsable(false)]
		[Category("Server Settings")]
		public bool SoundEffects { get; set; }

		public static Options DefaultOptions(RealtimeHost host, RTMP_MultiplayerLicense MultiplayerLicense)
		{
			return new Options
			{
				UPnP = false,
				PerformanceTracking = false,
				Port = 9000,
				AutosaveInterval = 0,
				AutosaveFolder = host.AutosaveDir,
				MaximumPlayers = (MultiplayerLicense?.MaxPlayers ?? 16),
				SoundEffects = true
			};
		}

		static Options()
		{
			Class72.smethod_20();
		}
	}

	public delegate void LogTextDelegate(string s);

	public delegate void UpdatePlayerListDelegate(List<string> players);

	public delegate void BadStateDelegate(string s);

	public delegate void EnableFormDelegate(bool Enabled);

	public delegate void ScenarioChangedDelegate(string scenarioName, TimeSpan elapsed, TimeSpan duration, List<string> sideNames);

	public delegate void ScenarioTimeChangedDelegate(int currentTick_s, TimeSpan Elapsed, TimeSpan Remaining);

	[CompilerGenerated]
	private sealed class <>c__DisplayClass310_0
	{
		public List<Task> list_0;

		public RealtimeHost realtimeHost_0;

		public Action action_0;

		public Action action_1;

		public Action action_2;

		internal void method_0(Action action)
		{
			action();
		}

		internal void method_1()
		{
			realtimeHost_0.method_12(realtimeHost_0.scenario_0, "AC begin " + realtimeHost_0.realtimeClient_0.Name);
		}

		internal void method_2()
		{
			realtimeHost_0.method_12(realtimeHost_0.scenario_0, "AC begin " + realtimeHost_0.realtimeClient_0.Name);
		}

		internal void method_3()
		{
			realtimeHost_0.method_12(realtimeHost_0.scenario_0);
		}

		static <>c__DisplayClass310_0()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct <>c__DisplayClass88_0
	{
		public Dictionary<string, HashSet<string>> dictionary_0;

		public HashSet<ActiveUnit> hashSet_0;
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass89_0
	{
		public Scenario scenario_0;

		internal IEnumerable<ActiveUnit> method_0(IEnumerable<string> objIDs)
		{
			foreach (string objID in objIDs)
			{
				ActiveUnit value = null;
				scenario_0.ActiveUnits.TryGetValue(objID, out value);
				if (value != null)
				{
					yield return value;
				}
			}
		}

		static <>c__DisplayClass89_0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass90_0
	{
		public Scenario scenario_0;

		internal IEnumerable<ActiveUnit> method_0(IEnumerable<string> objIDs)
		{
			foreach (string objID in objIDs)
			{
				ActiveUnit value = null;
				scenario_0.ActiveUnits.TryGetValue(objID, out value);
				if (value != null)
				{
					yield return value;
				}
			}
		}

		static <>c__DisplayClass90_0()
		{
			Class72.smethod_20();
		}
	}

	protected List<Side> SidesWithConnectedPlayers = new List<Side>();

	protected ConcurrentDictionary<Side, List<int>> SoundEffectsBySide = new ConcurrentDictionary<Side, List<int>>();

	protected bool SoundEffectHandlersAreSet;

	private volatile RealtimeClient realtimeClient_0;

	private DateTime dateTime_0 = DateTime.Now;

	private HashSet<RealtimeClient> hashSet_0 = new HashSet<RealtimeClient>();

	public volatile int GameSpeed;

	public GameSpeedType GameSpeedSetBy;

	private List<ChaffCorridorCloud> list_0 = new List<ChaffCorridorCloud>();

	private Dictionary<string, Tuple<byte, int>> dictionary_0 = new Dictionary<string, Tuple<byte, int>>();

	private bool bool_0;

	private static Random random_0;

	private Dictionary<string, Doctrine> dictionary_1 = new Dictionary<string, Doctrine>();

	private bool bool_1;

	private bool bool_2;

	private ConcurrentStack<SensorUpdateMessage.SensorUpdateRecord> concurrentStack_0 = new ConcurrentStack<SensorUpdateMessage.SensorUpdateRecord>();

	private List<UnguidedWeapon> list_1 = new List<UnguidedWeapon>();

	private List<string> list_2;

	private bool bool_3;

	public const int AUTOSAVE_INTERVAL_DEFAULT = 0;

	public const int AUTOSAVE_INTERVAL_MINIMUM = 300;

	public const bool SOUND_DEFAULT = true;

	public const int AUTOSAVE_INTERVAL_NONE = 0;

	public OutgoingPacketStatisticsTracker OutgoingPacketStatisticsTracker;

	public int AutosaveInterval_s;

	public int MaximumNumberOfPlayers = 2;

	public int IntermediateUnitUpdateInterval_s = 15;

	private Dispatcher dispatcher_0;

	[CompilerGenerated]
	private LogTextDelegate logTextDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private UpdatePlayerListDelegate updatePlayerListDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private BadStateDelegate badStateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private EnableFormDelegate enableFormDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ScenarioChangedDelegate scenarioChangedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ScenarioTimeChangedDelegate scenarioTimeChangedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	private readonly object object_0 = new object();

	public string HostInstanceName;

	public string AutosaveDir;

	private List<IGrouping<string, RealtimeClient>> list_3 = new List<IGrouping<string, RealtimeClient>>();

	private ConcurrentDictionary<string, List<ActiveUnit>> concurrentDictionary_0 = new ConcurrentDictionary<string, List<ActiveUnit>>();

	private ConcurrentDictionary<string, List<ActiveUnit>> concurrentDictionary_1 = new ConcurrentDictionary<string, List<ActiveUnit>>();

	private ConcurrentDictionary<string, ActiveUnit> concurrentDictionary_2 = new ConcurrentDictionary<string, ActiveUnit>();

	private ConcurrentDictionary<string, ActiveUnit> concurrentDictionary_3 = new ConcurrentDictionary<string, ActiveUnit>();

	private bool bool_6;

	private ConcurrentDictionary<string, List<ActiveUnit>> concurrentDictionary_4 = new ConcurrentDictionary<string, List<ActiveUnit>>();

	private ConcurrentDictionary<string, List<ActiveUnit>> concurrentDictionary_5 = new ConcurrentDictionary<string, List<ActiveUnit>>();

	private ConcurrentDictionary<string, string> concurrentDictionary_6 = new ConcurrentDictionary<string, string>();

	private bool bool_7;

	private Scenario scenario_0;

	private readonly Guid guid_0 = Guid.NewGuid();

	private List<RealtimeClient> list_4 = new List<RealtimeClient>();

	private RTMP_MultiplayerLicense rtmp_MultiplayerLicense_0;

	private Options options_0;

	private readonly object object_1 = new object();

	private string string_0 = "";

	public static bool RealtimeHostExists;

	private List<Tuple<PacketHeader, Connection, byte[]>> list_5 = new List<Tuple<PacketHeader, Connection, byte[]>>();

	private bool bool_8;

	private string string_1;

	private string string_2;

	private StreamWriter streamWriter_0;

	private static object object_2;

	private volatile int int_0;

	private ConcurrentQueue<Tuple<RTMessage, Connection, RealtimeClient>> concurrentQueue_0 = new ConcurrentQueue<Tuple<RTMessage, Connection, RealtimeClient>>();

	private volatile HostState hostState_0 = HostState.Paused;

	private Thread thread_0;

	private volatile bool bool_9;

	private volatile int int_1;

	private long long_0;

	private volatile int int_2;

	private uint uint_0;

	public bool SyncSimStepForAllClients = true;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	public bool PlaySoundEffects
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool BadState
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		private set
		{
			bool_5 = value;
		}
	}

	public bool IsServerStarted => bool_7;

	public event LogTextDelegate LogTextEvent
	{
		[CompilerGenerated]
		add
		{
			LogTextDelegate logTextDelegate = logTextDelegate_0;
			LogTextDelegate logTextDelegate2;
			do
			{
				logTextDelegate2 = logTextDelegate;
				LogTextDelegate value2 = (LogTextDelegate)Delegate.Combine(logTextDelegate2, value);
				logTextDelegate = Interlocked.CompareExchange(ref logTextDelegate_0, value2, logTextDelegate2);
			}
			while ((object)logTextDelegate != logTextDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			LogTextDelegate logTextDelegate = logTextDelegate_0;
			LogTextDelegate logTextDelegate2;
			do
			{
				logTextDelegate2 = logTextDelegate;
				LogTextDelegate value2 = (LogTextDelegate)Delegate.Remove(logTextDelegate2, value);
				logTextDelegate = Interlocked.CompareExchange(ref logTextDelegate_0, value2, logTextDelegate2);
			}
			while ((object)logTextDelegate != logTextDelegate2);
		}
	}

	public event UpdatePlayerListDelegate UpdatePlayerListEvent
	{
		[CompilerGenerated]
		add
		{
			UpdatePlayerListDelegate updatePlayerListDelegate = updatePlayerListDelegate_0;
			UpdatePlayerListDelegate updatePlayerListDelegate2;
			do
			{
				updatePlayerListDelegate2 = updatePlayerListDelegate;
				UpdatePlayerListDelegate value2 = (UpdatePlayerListDelegate)Delegate.Combine(updatePlayerListDelegate2, value);
				updatePlayerListDelegate = Interlocked.CompareExchange(ref updatePlayerListDelegate_0, value2, updatePlayerListDelegate2);
			}
			while ((object)updatePlayerListDelegate != updatePlayerListDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			UpdatePlayerListDelegate updatePlayerListDelegate = updatePlayerListDelegate_0;
			UpdatePlayerListDelegate updatePlayerListDelegate2;
			do
			{
				updatePlayerListDelegate2 = updatePlayerListDelegate;
				UpdatePlayerListDelegate value2 = (UpdatePlayerListDelegate)Delegate.Remove(updatePlayerListDelegate2, value);
				updatePlayerListDelegate = Interlocked.CompareExchange(ref updatePlayerListDelegate_0, value2, updatePlayerListDelegate2);
			}
			while ((object)updatePlayerListDelegate != updatePlayerListDelegate2);
		}
	}

	public event BadStateDelegate BadStateEvent
	{
		[CompilerGenerated]
		add
		{
			BadStateDelegate badStateDelegate = badStateDelegate_0;
			BadStateDelegate badStateDelegate2;
			do
			{
				badStateDelegate2 = badStateDelegate;
				BadStateDelegate value2 = (BadStateDelegate)Delegate.Combine(badStateDelegate2, value);
				badStateDelegate = Interlocked.CompareExchange(ref badStateDelegate_0, value2, badStateDelegate2);
			}
			while ((object)badStateDelegate != badStateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			BadStateDelegate badStateDelegate = badStateDelegate_0;
			BadStateDelegate badStateDelegate2;
			do
			{
				badStateDelegate2 = badStateDelegate;
				BadStateDelegate value2 = (BadStateDelegate)Delegate.Remove(badStateDelegate2, value);
				badStateDelegate = Interlocked.CompareExchange(ref badStateDelegate_0, value2, badStateDelegate2);
			}
			while ((object)badStateDelegate != badStateDelegate2);
		}
	}

	public event EnableFormDelegate EnableFormEvent
	{
		[CompilerGenerated]
		add
		{
			EnableFormDelegate enableFormDelegate = enableFormDelegate_0;
			EnableFormDelegate enableFormDelegate2;
			do
			{
				enableFormDelegate2 = enableFormDelegate;
				EnableFormDelegate value2 = (EnableFormDelegate)Delegate.Combine(enableFormDelegate2, value);
				enableFormDelegate = Interlocked.CompareExchange(ref enableFormDelegate_0, value2, enableFormDelegate2);
			}
			while ((object)enableFormDelegate != enableFormDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			EnableFormDelegate enableFormDelegate = enableFormDelegate_0;
			EnableFormDelegate enableFormDelegate2;
			do
			{
				enableFormDelegate2 = enableFormDelegate;
				EnableFormDelegate value2 = (EnableFormDelegate)Delegate.Remove(enableFormDelegate2, value);
				enableFormDelegate = Interlocked.CompareExchange(ref enableFormDelegate_0, value2, enableFormDelegate2);
			}
			while ((object)enableFormDelegate != enableFormDelegate2);
		}
	}

	public event ScenarioChangedDelegate ScenarioChangedEvent
	{
		[CompilerGenerated]
		add
		{
			ScenarioChangedDelegate scenarioChangedDelegate = scenarioChangedDelegate_0;
			ScenarioChangedDelegate scenarioChangedDelegate2;
			do
			{
				scenarioChangedDelegate2 = scenarioChangedDelegate;
				ScenarioChangedDelegate value2 = (ScenarioChangedDelegate)Delegate.Combine(scenarioChangedDelegate2, value);
				scenarioChangedDelegate = Interlocked.CompareExchange(ref scenarioChangedDelegate_0, value2, scenarioChangedDelegate2);
			}
			while ((object)scenarioChangedDelegate != scenarioChangedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ScenarioChangedDelegate scenarioChangedDelegate = scenarioChangedDelegate_0;
			ScenarioChangedDelegate scenarioChangedDelegate2;
			do
			{
				scenarioChangedDelegate2 = scenarioChangedDelegate;
				ScenarioChangedDelegate value2 = (ScenarioChangedDelegate)Delegate.Remove(scenarioChangedDelegate2, value);
				scenarioChangedDelegate = Interlocked.CompareExchange(ref scenarioChangedDelegate_0, value2, scenarioChangedDelegate2);
			}
			while ((object)scenarioChangedDelegate != scenarioChangedDelegate2);
		}
	}

	public event ScenarioTimeChangedDelegate ScenarioTimeChangedEvent
	{
		[CompilerGenerated]
		add
		{
			ScenarioTimeChangedDelegate scenarioTimeChangedDelegate = scenarioTimeChangedDelegate_0;
			ScenarioTimeChangedDelegate scenarioTimeChangedDelegate2;
			do
			{
				scenarioTimeChangedDelegate2 = scenarioTimeChangedDelegate;
				ScenarioTimeChangedDelegate value2 = (ScenarioTimeChangedDelegate)Delegate.Combine(scenarioTimeChangedDelegate2, value);
				scenarioTimeChangedDelegate = Interlocked.CompareExchange(ref scenarioTimeChangedDelegate_0, value2, scenarioTimeChangedDelegate2);
			}
			while ((object)scenarioTimeChangedDelegate != scenarioTimeChangedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ScenarioTimeChangedDelegate scenarioTimeChangedDelegate = scenarioTimeChangedDelegate_0;
			ScenarioTimeChangedDelegate scenarioTimeChangedDelegate2;
			do
			{
				scenarioTimeChangedDelegate2 = scenarioTimeChangedDelegate;
				ScenarioTimeChangedDelegate value2 = (ScenarioTimeChangedDelegate)Delegate.Remove(scenarioTimeChangedDelegate2, value);
				scenarioTimeChangedDelegate = Interlocked.CompareExchange(ref scenarioTimeChangedDelegate_0, value2, scenarioTimeChangedDelegate2);
			}
			while ((object)scenarioTimeChangedDelegate != scenarioTimeChangedDelegate2);
		}
	}

	public void OnWeaponFired(Scenario scen, ActiveUnit au, Weapon w)
	{
		if (scen != scenario_0 || au == null || w == null || (w.Fuel_ReadOnly.Count > 0 && w.Fuel_ReadOnly[0].FuelType == FuelRec._FuelType.WeaponCoast))
		{
			return;
		}
		Side side = ((Module_Unit.Unit)au).get_UnitSide(SetSideOnly: false);
		foreach (Side item in SoundEffectsBySide.Keys.ToList())
		{
			if (item != side && !Module_Side.IsAlliedWithThisSide(side, item))
			{
				continue;
			}
			int num = -1;
			switch (w.Type)
			{
			case Weapon._WeaponType.Laser:
			case Weapon._WeaponType.Microwave:
				num = 28;
				break;
			case Weapon._WeaponType.Torpedo:
				num = 27;
				break;
			case Weapon._WeaponType.GuidedWeapon:
				num = ((au.IsAircraft && w.IsAAWCapable) ? (w.HasInfraredSensor ? 21 : 22) : (au.IsShip ? 23 : ((!au.IsFacility) ? ((!(w.MaxRange_NoTargetType < 10f)) ? 26 : 25) : 24)));
				break;
			case Weapon._WeaponType.Rocket:
				num = 20;
				break;
			case Weapon._WeaponType.Gun:
				if (w.Warheads.Length != 0)
				{
					num = w.Warheads[0].Caliber switch
					{
						Warhead.WarheadCaliber.Gun_6_15mm => 13, 
						Warhead.WarheadCaliber.Gun_16_24mm => 14, 
						Warhead.WarheadCaliber.Gun_25_60mm => 15, 
						Warhead.WarheadCaliber.Gun_61_80mm => 16, 
						Warhead.WarheadCaliber.Gun_81_150mm => 17, 
						_ => 19, 
					};
				}
				break;
			}
			if (num > -1 && !SoundEffectsBySide[item].Contains(num))
			{
				SoundEffectsBySide[item].Add(num);
			}
		}
	}

	public void OnWeaponImpact(Scenario scen, Weapon w, Module_Unit.Unit target, bool DirectHit)
	{
		if (scen != scenario_0 || w == null || target == null || SoundEffectsBySide.Keys.Count <= 0)
		{
			return;
		}
		int num = -1;
		if (w.Warheads.Length != 0 && w.Warheads[0].IsCluster)
		{
			num = 29;
		}
		else if (!DirectHit)
		{
			if (!Module_Unit.IsOverLand(w))
			{
				num = 41;
			}
			else
			{
				switch (w.Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.IronBomb:
					if (w.Warheads.Length != 0)
					{
						num = ((!(w.Warheads[0].DP < 50f)) ? ((!(w.Warheads[0].DP < 200f)) ? 36 : 35) : 34);
					}
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.Gun:
					if (w.Warheads.Length != 0)
					{
						num = ((w.Warheads[0].Caliber > Warhead.WarheadCaliber.Gun_61_80mm) ? ((w.Warheads[0].Caliber > Warhead.WarheadCaliber.Gun_151_200mm) ? 36 : 35) : 34);
					}
					break;
				}
			}
		}
		else
		{
			switch (w.Type)
			{
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.IronBomb:
				if (!target.IsAircraft)
				{
					if (w.Warheads.Length != 0)
					{
						num = ((!(w.Warheads[0].DP < 5f)) ? ((!(w.Warheads[0].DP < 50f)) ? ((!(w.Warheads[0].DP < 200f)) ? 33 : 32) : 31) : 30);
					}
				}
				else
				{
					num = 37;
				}
				break;
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.Gun:
				if (w.Warheads.Length != 0)
				{
					num = ((w.Warheads[0].Caliber > Warhead.WarheadCaliber.Gun_61_80mm) ? ((w.Warheads[0].Caliber > Warhead.WarheadCaliber.Gun_151_200mm) ? 33 : 32) : 31);
				}
				break;
			}
		}
		if (num <= -1)
		{
			return;
		}
		foreach (Side key in SoundEffectsBySide.Keys)
		{
			if (!SoundEffectsBySide[key].Contains(num))
			{
				SoundEffectsBySide[key].Add(num);
			}
		}
	}

	public void OnAircraftTakeoff(Aircraft ac)
	{
		if (ac == null)
		{
			return;
		}
		Side key = ((Module_Unit.Unit)ac).get_UnitSide(SetSideOnly: false);
		if (SoundEffectsBySide.ContainsKey(key))
		{
			int num = -1;
			if (!ac.IsHelicopter)
			{
				List<Engine> list = ac.Propulsion.ToList();
				bool flag = list != null && list.Count > 0 && (list[0].Type == Engine.EngineType.Piston || list[0].Type == Engine.EngineType.Turboprop);
				ActiveUnit activeUnit = ac.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				num = ((activeUnit != null && activeUnit.IsShip) ? (flag ? 10 : 11) : (flag ? 8 : 9));
			}
			else
			{
				num = 7;
			}
			if (num > -1 && !SoundEffectsBySide[key].Contains(num))
			{
				SoundEffectsBySide[key].Add(num);
			}
		}
	}

	public void OnNewContactDetected(Side DetectingSide, Contact_Base.ContactType ContactType)
	{
		if (DetectingSide == null)
		{
			return;
		}
		foreach (Side item in SoundEffectsBySide.Keys.ToList())
		{
			int num;
			if (item != DetectingSide)
			{
				if (DetectingSide.get_ConsidersThisSideToBe(item, (Scenario)null) != Command_Core.Misc.PostureStance.Friendly)
				{
					continue;
				}
				num = -1;
			}
			else
			{
				num = -1;
			}
			int num2 = num;
			int num3;
			switch (ContactType)
			{
			default:
				num3 = 0;
				goto IL_008d;
			case Contact_Base.ContactType.Air:
				num2 = 3;
				break;
			case Contact_Base.ContactType.Missile:
				num2 = 1;
				break;
			case Contact_Base.ContactType.Surface:
				num2 = 4;
				break;
			case Contact_Base.ContactType.Submarine:
				num2 = 6;
				break;
			case Contact_Base.ContactType.UndeterminedNaval:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Orbital:
				num3 = 0;
				goto IL_008d;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.AggregateGroundUnit:
				num2 = 5;
				break;
			case Contact_Base.ContactType.Torpedo:
				{
					num2 = 2;
					break;
				}
				IL_008d:
				num2 = num3;
				break;
			}
			if (num2 > -1 && !SoundEffectsBySide[item].Contains(num2))
			{
				SoundEffectsBySide[item].Add(num2);
			}
		}
	}

	public void SendSoundEffects()
	{
		if (!PlaySoundEffects || SoundEffectsBySide.Count <= 0)
		{
			return;
		}
		foreach (Side key in SoundEffectsBySide.Keys)
		{
			List<int> list = SoundEffectsBySide[key];
			if (list != null && list.Count > 0)
			{
				List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(key.ObjectID);
				if (allClientsOnSide.Count > 0)
				{
					method_88(allClientsOnSide, new SoundEffectsMessage
					{
						SoundEffects = list
					}, "UpdateSoundEffects");
				}
			}
		}
		SoundEffectsBySide.Clear();
	}

	private void method_0(RealtimeClient realtimeClient_1, ActiveUnitMiscActionMessage activeUnitMiscActionMessage_0)
	{
		Scenario scenario_0 = this.scenario_0;
		Side side_0 = scenario_0.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (side_0 == null)
		{
			if (Debugger.IsAttached && !string.IsNullOrEmpty(realtimeClient_1.CurrentSide_ObjectID))
			{
				Debugger.Break();
			}
			return;
		}
		List<ActiveUnit> list = (from F in activeUnitMiscActionMessage_0.ObjectIDs
			where scenario_0.ActiveUnits.ContainsKey(F)
			select scenario_0.ActiveUnits[F] into F
			where ((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false) == side_0
			select F).ToList();
		if (list.Count < 1)
		{
			return;
		}
		switch ((ActiveUnitMiscAction)activeUnitMiscActionMessage_0.Action)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case ActiveUnitMiscAction.DisengageTargets:
			CoreClientCode.DisengageTargets_Core(list, side_0);
			break;
		case ActiveUnitMiscAction.UnassignUnitsAndDisengage:
			CoreClientCode.UnassignUnitsAndDisengage_Core(list, scenario_0, side_0);
			break;
		case ActiveUnitMiscAction.RemoveUnitFromMission:
			foreach (ActiveUnit item in list)
			{
				CoreClientCode.RemoveUnitFromMission_Core(item, scenario_0, side_0);
			}
			method_2(realtimeClient_1, list);
			break;
		case ActiveUnitMiscAction.ReturnToBase:
			CoreClientCode.ReturnToBase_Core(list, scenario_0, side_0);
			break;
		case ActiveUnitMiscAction.Group:
			CoreClientCode.GroupUnits_Core(list, side_0, scenario_0, activeUnitMiscActionMessage_0.TargetID);
			foreach (ActiveUnit item2 in list)
			{
				if (item2.IsGroupMember())
				{
					ActiveUnit unit = item2.get_ParentGroup(UsingMissionPlanner: false);
					SendIndividualActiveUnitUpdate(unit);
					break;
				}
			}
			SendGroupMembershipUpdate(list);
			break;
		case ActiveUnitMiscAction.Detach:
			CoreClientCode.DetachUnits_Core(list, side_0, scenario_0);
			SendGroupMembershipUpdate(list);
			break;
		case ActiveUnitMiscAction.DropSonobuoyPassiveDeep:
		{
			foreach (ActiveUnit item3 in list)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, item3, ActiveSonobuoy: false, ShallowSonobuoy: false, IsManual: true);
			}
			break;
		}
		case ActiveUnitMiscAction.DropSonobuoyPassiveShallow:
		{
			foreach (ActiveUnit item4 in list)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, item4, ActiveSonobuoy: false, ShallowSonobuoy: true, IsManual: true);
			}
			break;
		}
		case ActiveUnitMiscAction.DropSonobuoyActiveDeep:
		{
			foreach (ActiveUnit item5 in list)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, item5, ActiveSonobuoy: true, ShallowSonobuoy: false, IsManual: true);
			}
			break;
		}
		case ActiveUnitMiscAction.DropSonobuoyActiveShallow:
		{
			foreach (ActiveUnit item6 in list)
			{
				CoreClientCode.DropSonobuoy_Core(scenario_0, item6, ActiveSonobuoy: true, ShallowSonobuoy: true, IsManual: true);
			}
			break;
		}
		case ActiveUnitMiscAction.DeployDippingSonar:
		{
			foreach (ActiveUnit item7 in list)
			{
				CoreClientCode.DeployDippingSonar_Core(item7);
			}
			break;
		}
		case ActiveUnitMiscAction.DropOneTarget:
		{
			Contact value = null;
			if (!string.IsNullOrEmpty(activeUnitMiscActionMessage_0.TargetID) && side_0.Contacts.TryGetValue(activeUnitMiscActionMessage_0.TargetID, out value))
			{
				CoreClientCode.DropOneTarget_Core(list, side_0, value);
			}
			break;
		}
		case ActiveUnitMiscAction.HoldPositionOn:
			CoreClientCode.HoldPosition_Core(list, OnOrOff: true);
			break;
		case ActiveUnitMiscAction.HoldPositionOff:
			CoreClientCode.HoldPosition_Core(list, OnOrOff: false);
			break;
		case ActiveUnitMiscAction.SummonToReestablishComms:
		{
			foreach (ActiveUnit item8 in list)
			{
				if (item8.IsActiveUnit)
				{
					CoreClientCode.SummonToReestablishComms_Core(item8);
				}
			}
			break;
		}
		case ActiveUnitMiscAction.LeadAllowedToSlowDownOn:
		{
			foreach (ActiveUnit item9 in list)
			{
				if (item9.IsActiveUnit)
				{
					CoreClientCode.LeadAllowedToSlowDown_Core(item9, allowed: true);
				}
			}
			break;
		}
		case ActiveUnitMiscAction.LeadAllowedToSlowDownOff:
		{
			foreach (ActiveUnit item10 in list)
			{
				if (item10.IsActiveUnit)
				{
					CoreClientCode.LeadAllowedToSlowDown_Core(item10, allowed: false);
				}
			}
			break;
		}
		case ActiveUnitMiscAction.ClientRequestsUnitUpdate:
			method_2(realtimeClient_1, list);
			break;
		}
	}

	private void method_1(RealtimeClient realtimeClient_1, AirborneAircraftQuickTurnaroundMessage airborneAircraftQuickTurnaroundMessage_0)
	{
		Scenario scenario = scenario_0;
		ActiveUnit value = null;
		if (scenario.ActiveUnits.TryGetValue(airborneAircraftQuickTurnaroundMessage_0.AircraftID, out value))
		{
			CoreClientCode.SetAirborneAircraftQuickTurnaround_Core(value, airborneAircraftQuickTurnaroundMessage_0.QuickTurnaroundEnabled, airborneAircraftQuickTurnaroundMessage_0.QuickTurnaroundSorties);
		}
	}

	private void method_2(RealtimeClient realtimeClient_1, List<ActiveUnit> list_6, bool bool_14 = false)
	{
		if (hostState_0 == HostState.Running || bool_14)
		{
			if (concurrentDictionary_1.ContainsKey(realtimeClient_1.CurrentSide_ObjectID))
			{
				List<ActiveUnit> value = null;
				if (concurrentDictionary_1.TryRemove(realtimeClient_1.CurrentSide_ObjectID, out value))
				{
					list_6.AddRange(value.Except(list_6));
				}
			}
			concurrentDictionary_1.TryAdd(realtimeClient_1.CurrentSide_ObjectID, list_6);
			return;
		}
		foreach (ActiveUnit item in list_6)
		{
			SendClientIndividualActiveUnitUpdate(realtimeClient_1, item);
		}
	}

	private void method_3()
	{
		lock (object_1)
		{
			foreach (RealtimeClient item in list_4)
			{
				method_5(item);
				SendSelectedWaypointUpdate(item);
			}
			method_4();
			concurrentDictionary_1.Clear();
		}
	}

	private void method_4()
	{
		lock (object_1)
		{
			List<ActiveUnit> value = null;
			List<ActiveUnit> list = null;
			List<ActiveUnit> value2 = null;
			List<ActiveUnit> list2 = null;
			foreach (IGrouping<string, RealtimeClient> item in list_3)
			{
				List<RealtimeClient> list3 = item.ToList();
				if (!concurrentDictionary_4.TryGetValue(item.Key, out value))
				{
					continue;
				}
				list = null;
				concurrentDictionary_1.TryGetValue(item.Key, out list);
				if (concurrentDictionary_5.TryGetValue(item.Key, out value2))
				{
					list2 = value2.Except(value).ToList();
					method_92(list3, list2, bool_14: true);
					if (list != null)
					{
						list = list.Except(list2).ToList();
					}
					list2 = value.Except(value2).ToList();
					method_90(list3, list2, bool_14: true);
					list2.Clear();
				}
				if (list != null && list.Count > 0)
				{
					method_90(list3, list, bool_14: true);
					if (list2 != null)
					{
						list2.AddRange(list);
					}
					else
					{
						list2 = list;
					}
				}
				list2 = ((list2 == null) ? value : value.Except(list2).ToList());
				method_91(list3, list2);
				foreach (RealtimeClient item2 in list3)
				{
					if (!item2.Gods_Eye)
					{
						continue;
					}
					PooledList<ActiveUnit> activeUnits_List = scenario_0.ActiveUnits_List;
					List<ActiveUnit> list4 = activeUnits_List.Where(item2.method_0).ToList();
					if (list4.Count <= 0)
					{
						continue;
					}
					List<RealtimeClient> list_ = new List<RealtimeClient> { item2 };
					List<ActiveUnit> list5 = list4.Except(value).ToList();
					if (list != null)
					{
						list5 = list5.Except(list).ToList();
					}
					if (list5.Count > 0)
					{
						if (item2.PreviousGodsEyeActiveUnits.Count > 0)
						{
							List<ActiveUnit> list_2 = item2.PreviousGodsEyeActiveUnits.Except(activeUnits_List).ToList();
							method_92(list_, list_2);
						}
						List<ActiveUnit> list6 = list5.Except(item2.PreviousGodsEyeActiveUnits).ToList();
						method_90(list_, list6);
						list5 = list5.Except(list6).ToList();
						method_91(list_, list5);
					}
					item2.PreviousGodsEyeActiveUnits = list4;
				}
			}
		}
	}

	private void SendClientIndividualActiveUnitUpdate(RealtimeClient client, ActiveUnit unit)
	{
		if (unit == null)
		{
			return;
		}
		lock (object_1)
		{
			string text = method_74(unit);
			if (text != null)
			{
				method_89(client, new ActiveUnitUpdateMessage
				{
					XML = text,
					HadActiveSensorInLastPulse = unit.Sensory.HadActiveSensorInLastPulse
				}, "SendClientIndividualActiveUnitUpdate");
			}
		}
	}

	private void SendIndividualActiveUnitUpdate(ActiveUnit unit)
	{
		if (unit == null)
		{
			return;
		}
		Side side = ((Module_Unit.Unit)unit).get_UnitSide(SetSideOnly: false);
		lock (object_1)
		{
			foreach (IGrouping<string, RealtimeClient> item in list_3)
			{
				if (item.Key == side.ObjectID)
				{
					string text = method_74(unit);
					if (text != null)
					{
						method_88(item.ToList(), new ActiveUnitUpdateMessage
						{
							XML = text,
							HadActiveSensorInLastPulse = unit.Sensory.HadActiveSensorInLastPulse
						}, "SendIndividualActiveUnitUpdate");
					}
					break;
				}
			}
		}
	}

	private void method_5(RealtimeClient realtimeClient_1)
	{
		lock (object_1)
		{
			if (string.IsNullOrEmpty(realtimeClient_1.SelectedUnit_ObjectID) || !scenario_0.ActiveUnits.ContainsKey(realtimeClient_1.SelectedUnit_ObjectID))
			{
				return;
			}
			ActiveUnit activeUnit = scenario_0.ActiveUnits[realtimeClient_1.SelectedUnit_ObjectID];
			SendClientIndividualActiveUnitUpdate(realtimeClient_1, activeUnit);
			if (!activeUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)activeUnit).Units.Values)
			{
				SendClientIndividualActiveUnitUpdate(realtimeClient_1, value);
			}
		}
	}

	private void method_6(RealtimeClient realtimeClient_1, ActiveUnitHomeBaseMessage activeUnitHomeBaseMessage_0)
	{
		Scenario scenario = scenario_0;
		Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID != null)
		{
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
			ActiveUnit value = null;
			foreach (string objectID in activeUnitHomeBaseMessage_0.ObjectIDs)
			{
				if (scenario.ActiveUnits.TryGetValue(objectID, out value))
				{
					list.Add(value);
				}
			}
			if (scenario.ActiveUnits.TryGetValue(activeUnitHomeBaseMessage_0.HomeBaseID, out value))
			{
				CoreClientCode.SetNewHomeBaseForUnits_Core(sideByID, list, value);
				UpdateUnitsHomeBase(sideByID, activeUnitHomeBaseMessage_0.ObjectIDs, activeUnitHomeBaseMessage_0.HomeBaseID);
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void UpdateUnitsHomeBase(Side side, List<string> list_6, string homeBaseID)
	{
		List<RealtimeClient> ilist_ = list_4.Where((RealtimeClient F) => F.CurrentSide_ObjectID.Equals(side.ObjectID)).ToList();
		method_88(ilist_, new ActiveUnitHomeBaseMessage
		{
			ObjectIDs = list_6,
			HomeBaseID = homeBaseID
		}, "UpdateUnitsHomeBase");
	}

	private void method_7(RealtimeClient realtimeClient_1, UnitRenameMessage unitRenameMessage_0)
	{
		Scenario scenario = scenario_0;
		Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID != null)
		{
			Module_Unit.Unit unit = null;
			if (unitRenameMessage_0.IsContact)
			{
				Contact value = null;
				if (!string.IsNullOrEmpty(unitRenameMessage_0.ID))
				{
					sideByID.Contacts.TryGetValue(unitRenameMessage_0.ID, out value);
				}
				unit = value;
			}
			else
			{
				ActiveUnit value2 = null;
				scenario.ActiveUnits.TryGetValue(unitRenameMessage_0.ID, out value2);
				unit = value2;
			}
			if (unit != null)
			{
				unit.Name = unitRenameMessage_0.Name;
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void method_8(RealtimeClient realtimeClient_1, AbsoluteControlRequestMessage absoluteControlRequestMessage_0)
	{
		if (hostState_0 != HostState.AC && realtimeClient_0 == null)
		{
			realtimeClient_0 = realtimeClient_1;
		}
	}

	private void method_9(RealtimeClient realtimeClient_1, AbsoluteControlReleaseMessage absoluteControlReleaseMessage_0)
	{
		if (hostState_0 != HostState.AC && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (realtimeClient_0 != realtimeClient_1 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (list_4.Count > 0 && list_4[0].LoopbackMode)
		{
			list_4[0].Loopback.DisableCommandCoreEventNotifications();
			RealtimeTerminal.ActiveDeserializationCount++;
		}
		method_55(realtimeClient_1?.Name + " has released Absolute Control.");
		if (absoluteControlReleaseMessage_0.NewClientSideID != realtimeClient_1.CurrentSide_ObjectID)
		{
			string string_ = null;
			if (!string.IsNullOrEmpty(absoluteControlReleaseMessage_0.NewClientSideID))
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side.ObjectID == absoluteControlReleaseMessage_0.NewClientSideID)
					{
						string_ = side.Name;
						break;
					}
				}
			}
			method_20(realtimeClient_1, absoluteControlReleaseMessage_0.NewClientSideID, string_, realtimeClient_1.Gods_Eye, bool_15: false);
		}
		method_64(CommandCoreInterop.ScenarioFromXML(absoluteControlReleaseMessage_0.ScenXML));
		if (list_4.Count > 0 && list_4[0].LoopbackMode)
		{
			list_4[0].Loopback.EnableCommandCoreEventNotifications();
			RealtimeTerminal.ActiveDeserializationCount--;
		}
		Task.Factory.StartNew(delegate
		{
			method_12(scenario_0, "AC end " + realtimeClient_1.Name);
		});
		foreach (RealtimeClient item in list_4)
		{
			hashSet_0.Add(item);
		}
		GameSpeed = 0;
		realtimeClient_0 = null;
		hostState_0 = HostState.Paused;
	}

	public static string CleanFileName1(string filename)
	{
		string text = filename;
		text = string.Concat(text.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
		if (text.Length > 50)
		{
			text = text.Substring(0, 50);
		}
		return text;
	}

	private string method_10(Scenario scenario_1, string string_3 = "")
	{
		if (string_3 != "")
		{
			string_3 = " " + string_3;
		}
		return Path.Combine(AutosaveDir, $"{string_3} Simtime {scenario_1.Time:yyyy MM dd  hh mm ss}.scen");
	}

	private string method_11(Scenario scenario_1, string string_3 = "")
	{
		if (string_3 != "")
		{
			string_3 = " " + string_3;
		}
		return Path.Combine(AutosaveDir, $"Realtime {DateTime.Now:yyyy MM dd   hh mm ss}{string_3}.scen");
	}

	private void method_12(Scenario scenario_1, string string_3 = "")
	{
	}

	private void method_13(RealtimeClient realtimeClient_1, AutosaveRequestMessage autosaveRequestMessage_0)
	{
		method_12(scenario_0, autosaveRequestMessage_0.Tag ?? ("Requested by " + realtimeClient_1.Name));
	}

	private void AutosavesListRequest(RealtimeClient client, AutosavesListRequestMessage msg)
	{
		List<string> autosaveFilenames = (from F in (from F in new DirectoryInfo(AutosaveDir).EnumerateFiles()
				orderby F.CreationTime descending
				select F).Take(msg.Count)
			select F.Name).ToList();
		method_89(client, new AutosavesListReplyMessage
		{
			AutosaveFilenames = autosaveFilenames
		}, "AutosavesListRequest");
	}

	private void method_14(RealtimeClient realtimeClient_1, RewindRequestMessage rewindRequestMessage_0)
	{
		if (hostState_0 != HostState.AC)
		{
			FileInfo fileInfo = new DirectoryInfo(AutosaveDir).EnumerateFiles().FirstOrDefault((FileInfo F) => F.Name == rewindRequestMessage_0.AutosaveFilename);
			if (fileInfo != null)
			{
				Scenario scenario_ = CommandCoreInterop.ScenarioFromFile(fileInfo.FullName);
				method_64(scenario_);
			}
		}
	}

	private void GlobalChat(RealtimeClient client, GlobalChatMessage msg)
	{
		method_55(msg.PlayerName + ": " + msg.Message);
		method_87(msg, "GlobalChat");
	}

	private void Health(RealtimeClient client, HealthMessage msg)
	{
		client.CPU = msg.CPU;
		method_89(client, new HealthReplyMessage(), "Health");
	}

	private void method_15(RealtimeClient realtimeClient_1, LogoutMessage logoutMessage_0)
	{
		CloseConnection(realtimeClient_1);
	}

	private void LoginRequest(RealtimeClient client, LoginRequestMessage msg)
	{
		if (string.IsNullOrWhiteSpace(msg.Name))
		{
			msg.Name = Guid.NewGuid().ToString();
		}
		RealtimeClient realtimeClient = null;
		int num = 0;
		if (list_4.Count > 0)
		{
			IEnumerable<RealtimeClient> source = list_4.Where((RealtimeClient F) => F.Name == msg.Name);
			if (source.Any())
			{
				realtimeClient = source.First();
			}
			num = list_4.Where((RealtimeClient F) => F.Connection != null && F.Connection.ConnectionInfo.ConnectionState == ConnectionState.Established).Count();
		}
		if (realtimeClient != null && realtimeClient != client)
		{
			if (realtimeClient.LoopbackMode || realtimeClient.Connection.ConnectionInfo.ConnectionState == ConnectionState.Established)
			{
				ClientError(client, "Name " + msg.Name + " already in use.");
				CloseConnection(client);
				return;
			}
			CloseConnection(realtimeClient);
		}
		if (string.Compare("v1.10 - Build 1900.20", msg.Version) == 0)
		{
			if (num > MaximumNumberOfPlayers)
			{
				ClientError(client, $"{MaximumNumberOfPlayers} players are already connected to the host.");
				CloseConnection(client);
				return;
			}
			client.IP = $"RELAY {client.Connection.OtherUserID}";
			client.Name = msg.Name;
			client.TerminalLockedSide = msg.LockedSide;
			client.TerminalRights = (TerminalRights)msg.TerminalRights;
			if (client.TerminalRights == TerminalRights.Umpire)
			{
				client.TerminalRights = TerminalRights.Player;
			}
			client.Color = msg.Color;
			hashSet_0.Add(client);
			string text = "";
			string dBFileName = "";
			if (scenario_0 != null)
			{
				DBOps.DBFileCheckResult theResult = DBOps.DBFileCheckResult.Undefined;
				text = scenario_0.DBUsed;
				DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(text, ref theResult, CheckLocalFileExists: true, CheckForTampering: false);
				if (dBRecordByHash != null)
				{
					dBFileName = dBRecordByHash.FileName;
				}
			}
			method_89(client, new LoginReplyMessage
			{
				Name = client.Name,
				Color = client.Color,
				LockedSide = client.TerminalLockedSide,
				TerminalRights = (int)client.TerminalRights,
				DBFileName = dBFileName,
				DBHash = text
			}, "LoginRequest");
			method_56();
			SendAllPeerList();
		}
		else
		{
			ClientError(client, "Version on host 'v1.10 - Build 1900.20' does not match client '" + msg.Version + ".'");
			CloseConnection(client);
		}
	}

	private void ServerInfoRequest(RealtimeClient client, ServerInfoRequest msg)
	{
		if (scenario_0 != null)
		{
			msg.ScenarioTitle = scenario_0.Title;
			msg.PlayableSideNames = new List<string>();
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (!side.IsAIOnly)
				{
					msg.PlayableSideNames.Add(side.Name);
				}
			}
		}
		method_89(client, msg, "ServerInfoRequest");
	}

	private void SendAllPeerList()
	{
		lock (object_1)
		{
			int count = list_4.Count;
			List<string> list = new List<string>(count);
			List<Guid> list2 = new List<Guid>(count);
			List<string> list3 = new List<string>(count);
			List<(int, int, int)> list4 = new List<(int, int, int)>(count);
			List<DateTime> list5 = new List<DateTime>(count);
			List<string> list6 = new List<string>(count);
			List<string> list7 = new List<string>(count);
			List<string> list8 = new List<string>(count);
			List<string> list9 = new List<string>(count);
			List<string> list10 = new List<string>(count);
			List<string> list11 = new List<string>(count);
			List<float> list12 = new List<float>(count);
			List<int> list13 = new List<int>(count);
			List<string> list14 = new List<string>(count);
			for (int i = 0; i < count; i++)
			{
				list3.Add(list_4[i].Name);
				list.Add(list_4[i].IP);
				list2.Add(list_4[i].Guid);
				list4.Add(list_4[i].Color);
				list5.Add(list_4[i].LastHeard);
				list6.Add(list_4[i].SelectedUnit_Name);
				list7.Add(list_4[i].SelectedUnit_ObjectID);
				list8.Add(list_4[i].CurrentSide_Name);
				list9.Add(list_4[i].CurrentSide_ObjectID);
				list10.Add(list_4[i].LastMessageType);
				list11.Add(list_4[i].ErrorMessage);
				list12.Add(list_4[i].CPU);
				list14.Add(list_4[i].TerminalLockedSide);
				list13.Add((int)list_4[i].TerminalRights);
			}
			method_87(new PeerListMessage
			{
				IPs = list,
				Guids = list2,
				Names = list3,
				Colors = list4,
				LastHeards = list5,
				SelectedUnit_Names = list6,
				SelectedUnit_ObjectIDs = list7,
				CurrentSide_Names = list8,
				CurrentSide_ObjectIDs = list9,
				LastMessageTypes = list10,
				ErrorMessages = list11,
				CPUs = list12,
				TerminalLockedSides = list14,
				TerminalRights = list13
			}, "SendAllPeerList");
		}
	}

	private void SendAllPeerScreenMouseUpdate()
	{
		lock (object_1)
		{
			int count = list_4.Count;
			List<string> list = new List<string>(count);
			List<string> list2 = new List<string>(count);
			List<string> list3 = new List<string>(count);
			List<(double, double)> list4 = new List<(double, double)>(count);
			List<List<(double, double)>> list5 = new List<List<(double, double)>>(count);
			List<bool> list6 = new List<bool>(count);
			List<(int, int, int)> list7 = new List<(int, int, int)>(count);
			for (int i = 0; i < count; i++)
			{
				list.Add(list_4[i].Name);
				list2.Add(list_4[i].TerminalLockedSide);
				list3.Add(list_4[i].CurrentSide_Name);
				list4.Add(list_4[i].Mouse);
				list5.Add(list_4[i].Screen);
				list6.Add(item: false);
				list7.Add(list_4[i].Color);
			}
			method_87(new PeerScreenMouseUpdateMessage
			{
				Names = list,
				Mice = list4,
				TerminalLockedSides = list2,
				SideNames = list3,
				Screens = list5,
				Clicks = list6,
				Colors = list7
			}, "SendAllPeerScreenMouseUpdate");
		}
	}

	private void method_16(RealtimeClient realtimeClient_1, PeerListRequestMessage peerListRequestMessage_0)
	{
		SendAllPeerList();
	}

	private void PeerScreenMouseUpdate(RealtimeClient client, PeerScreenMouseUpdateMessage msg)
	{
		if (msg.Names.Count != 1 || msg.Names[0] != client.Name)
		{
			return;
		}
		if (msg.Mice != null)
		{
			client.Mouse = msg.Mice[0];
		}
		if (msg.Screens != null && msg.Screens[0] != null)
		{
			client.Screen = msg.Screens[0];
		}
		if (msg.TerminalLockedSides != null)
		{
			client.TerminalLockedSide = msg.TerminalLockedSides[0];
		}
		if (msg.TerminalRights != null)
		{
			client.TerminalRights = (TerminalRights)msg.TerminalRights[0];
		}
		List<RealtimeClient> ilist_ = list_4.Where(delegate(RealtimeClient F)
		{
			if (F == client)
			{
				return false;
			}
			if (F.CurrentSide_ObjectID == client.CurrentSide_ObjectID)
			{
				return true;
			}
			return F.Gods_Eye ? true : false;
		}).ToList();
		method_88(ilist_, msg, "PeerScreenMouseUpdate");
	}

	private void method_17(IEnumerable<RealtimeClient> ienumerable_0, string string_3, bool bool_14 = false)
	{
		string scenXML = CommandCoreInterop.ScenarioToXML(scenario_0);
		method_88(ienumerable_0.ToList(), new PushStateMessage
		{
			ScenXML = scenXML,
			NewScenario = bool_14
		}, string_3);
		foreach (RealtimeClient item in ienumerable_0)
		{
			method_26(item);
		}
	}

	private void method_18(RealtimeClient realtimeClient_1, SelectionChangeMessage selectionChangeMessage_0)
	{
		if (hostState_0 != HostState.AC)
		{
			if (realtimeClient_1.SelectedUnit_ObjectID != selectionChangeMessage_0.ObjectID)
			{
				realtimeClient_1.SelectedUnit_ObjectID = selectionChangeMessage_0.ObjectID;
				realtimeClient_1.SelectedUnit_Name = selectionChangeMessage_0.Name;
				method_5(realtimeClient_1);
			}
			if (realtimeClient_1.SelectedWaypoint_ObjectID != selectionChangeMessage_0.WaypointID)
			{
				realtimeClient_1.SelectedWaypoint_ObjectID = selectionChangeMessage_0.WaypointID;
				SendSelectedWaypointUpdate(realtimeClient_1);
			}
		}
	}

	private void method_19(RealtimeClient realtimeClient_1, HostUnitSelectionChangeMessage hostUnitSelectionChangeMessage_0)
	{
		if (hostState_0 != HostState.AC)
		{
			List<string> list = null;
			if (hostUnitSelectionChangeMessage_0.HostUnitIDs != null)
			{
				list = new List<string>(hostUnitSelectionChangeMessage_0.HostUnitIDs);
			}
			switch ((HostUnitSelectionChangeMessage.HostType)hostUnitSelectionChangeMessage_0.HostUnitType)
			{
			case HostUnitSelectionChangeMessage.HostType.Docking:
				realtimeClient_1.SelectedDockingHost_ObjectIDs = list;
				break;
			case HostUnitSelectionChangeMessage.HostType.Air:
				realtimeClient_1.SelectedAirHost_ObjectIDs = list;
				break;
			}
		}
	}

	private void method_20(RealtimeClient realtimeClient_1, string string_3, string string_4, bool bool_14, bool bool_15)
	{
		bool flag = string.IsNullOrEmpty(realtimeClient_1.CurrentSide_ObjectID);
		lock (object_1)
		{
			bool flag2 = false;
			bool flag3 = false;
			if (realtimeClient_1.CurrentSide_ObjectID != string_3 || (bool_14 && !realtimeClient_1.Gods_Eye))
			{
				int num;
				if (bool_15)
				{
					if (!hashSet_0.Contains(realtimeClient_1))
					{
						hashSet_0.Add(realtimeClient_1);
						goto IL_0062;
					}
					num = 1;
				}
				else
				{
					num = 1;
				}
				flag2 = (byte)num != 0;
				goto IL_0062;
			}
			goto IL_0068;
			IL_0068:
			realtimeClient_1.CurrentSide_ObjectID = string_3;
			realtimeClient_1.CurrentSide_Name = string_4;
			realtimeClient_1.Gods_Eye = bool_14;
			realtimeClient_1.PreviousGodsEyeActiveUnits.Clear();
			if (!string.IsNullOrEmpty(string_3) && scenario_0 != null)
			{
				Side sideByID = scenario_0.GetSideByID(string_3);
				if (sideByID != null)
				{
					sideByID.IsHumanControlled = true;
					if (realtimeClient_1.TerminalRights == TerminalRights.Player && !sideByID.IsPlayerControlled)
					{
						sideByID.IsPlayerControlled = true;
						sideByID.ScrubMissions(scenario_0);
						scenario_0.TriggerPlayerJoinedSideEvents();
						flag3 = true;
					}
				}
			}
			if (flag2)
			{
				method_26(realtimeClient_1);
			}
			if (flag3)
			{
				foreach (RealtimeClient item in list_4)
				{
					hashSet_0.Add(item);
				}
			}
			goto end_IL_0015;
			IL_0062:
			method_62();
			goto IL_0068;
			end_IL_0015:;
		}
		if (flag)
		{
			SendGlobalChatMessage(realtimeClient_1.Name + " has joined side " + (string_4 ?? "null") + ((!bool_14) ? "" : " with God's Eye View"));
		}
		method_56();
		SendAllPeerList();
	}

	private void nMsLkhabduo(RealtimeClient realtimeClient_1, SideChangeMessage sideChangeMessage_0)
	{
		if (hostState_0 != HostState.AC)
		{
			method_20(realtimeClient_1, sideChangeMessage_0.Side_ObjectID, sideChangeMessage_0.Side_Name, sideChangeMessage_0.Gods_Eye, sideChangeMessage_0.ByPlayer);
		}
	}

	private void method_21(RealtimeClient realtimeClient_1, SpeedRequestMessage speedRequestMessage_0)
	{
		if (hostState_0 == HostState.AC)
		{
			return;
		}
		realtimeClient_1.LastGameSpeedRequested = speedRequestMessage_0.Speed;
		int num = speedRequestMessage_0.Speed;
		GameSpeedType gameSpeedSetBy = GameSpeedType.None;
		if (realtimeClient_1.TerminalRights == TerminalRights.Umpire)
		{
			gameSpeedSetBy = GameSpeedType.Umpire;
		}
		else
		{
			foreach (RealtimeClient item in list_4)
			{
				if (item == realtimeClient_1 || item.LastGameSpeedRequested <= 0 || item.Connection.ConnectionInfo.ConnectionState != ConnectionState.Established)
				{
					continue;
				}
				if (item.LastGameSpeedRequested >= num)
				{
					if (num >= item.LastGameSpeedRequested)
					{
						if (num == item.LastGameSpeedRequested)
						{
							gameSpeedSetBy = GameSpeedType.Agreed;
						}
					}
					else
					{
						gameSpeedSetBy = GameSpeedType.Lowest;
					}
				}
				else
				{
					num = item.LastGameSpeedRequested;
					gameSpeedSetBy = GameSpeedType.Lowest;
				}
			}
		}
		if (num == speedRequestMessage_0.Speed)
		{
			if (num == 0)
			{
				SendGlobalChatMessage(realtimeClient_1.Name + " paused the game");
			}
			else
			{
				SendGlobalChatMessage($"{realtimeClient_1.Name} set game speed to {num}");
			}
		}
		else
		{
			SendGlobalChatMessage($"{realtimeClient_1.Name} requested game speed {speedRequestMessage_0.Speed} but lowest requested speed is {num}");
		}
		GameSpeed = num;
		GameSpeedSetBy = gameSpeedSetBy;
		switch (GameSpeed)
		{
		case 15:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.FifteenSec);
			break;
		case 1:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.OneSec);
			break;
		case 2:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.TwoSec);
			break;
		case 5:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.FiveSec);
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case 60:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.Coarse_FiveSecSlice);
			break;
		case 30:
			scenario_0.TimeCompression_Set_Core(Scenario.enumTimeCompression.Coarse_OneSecSlice);
			break;
		case 0:
			break;
		}
		SendStatusUpdate("Speed Update");
	}

	private void SendStatusUpdate()
	{
		SendStatusUpdate("");
	}

	private void SendStatusUpdate(string Text)
	{
		method_87(new StatusMessage
		{
			AC_Requester_Name = realtimeClient_0?.Name,
			Text = Text,
			Speed = GameSpeed,
			SpeedDecision = (int)GameSpeedSetBy,
			Time = (scenario_0?.Time ?? new DateTime(1900, 1, 1)),
			HostState = hostState_0,
			TimeSinceLastAutosave = DateTime.Now - dateTime_0,
			TrafficWaitingForLock = int_0,
			AutosaveCount = 0,
			ThreadDeltaTime_milliseconds = int_2
		}, "SendStatusUpdate");
	}

	private void SendExecutionSync(uint stepCount, DateTime scenarioTime)
	{
		method_87(new ExecutionSyncMessage
		{
			CurrentStepCount = stepCount,
			CurrentScenarioTime = scenarioTime
		}, "SendExecutionSync");
	}

	private void method_22(RealtimeClient realtimeClient_1, ExecutionSyncMessage executionSyncMessage_0)
	{
		realtimeClient_1.LastReportedSimExecutionStep = executionSyncMessage_0.CurrentStepCount;
		realtimeClient_1.LastReportedScenarioTime = executionSyncMessage_0.CurrentScenarioTime;
	}

	private void SendGameOver(string message)
	{
		method_87(new GameOverMessage
		{
			ScenarioEnd = bool_12,
			DisconnectClients = true,
			Message = message
		}, "SendGameOver");
	}

	private void SendUIResponse(RealtimeClient client, UIMessage msg)
	{
		if (msg.ClientUIEventID != 0)
		{
			UIMessage rtmessage_ = new UIMessage
			{
				ClientUIEventID = msg.ClientUIEventID
			};
			method_89(client, rtmessage_, "SendUIResponse");
		}
	}

	private void SendWeaponSalvos()
	{
		if (!bool_6)
		{
			return;
		}
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		lock (object_1)
		{
			int capacity = scenario.Sides_ReadOnly.Length;
			List<string> list = new List<string>(capacity);
			List<List<(string, string)>> list2 = new List<List<(string, string)>>(capacity);
			Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				list.Add(side.ObjectID);
				List<(string, string)> list3 = new List<(string, string)>(side.WeaponSalvos.Count);
				foreach (WeaponSalvo weaponSalvo in side.WeaponSalvos)
				{
					string text = method_76(weaponSalvo);
					if (text != null)
					{
						list3.Add((weaponSalvo.ObjectID, text));
					}
				}
				list2.Add(list3);
			}
			method_87(new WeaponSalvoUpdateMessage
			{
				FullUpdate = true,
				WeaponSalvos = list2,
				SideIDs = list
			}, "SendWeaponSalvos");
		}
	}

	private void method_23(RealtimeClient realtimeClient_1, TargetingContactAutoEngageMessage targetingContactAutoEngageMessage_0)
	{
		if (targetingContactAutoEngageMessage_0.TargetingIDs.Count < 1)
		{
			return;
		}
		Scenario scenario = GetScenario();
		if (scenario == null)
		{
			return;
		}
		Dictionary<ActiveUnit, List<Contact>> dictionary = new Dictionary<ActiveUnit, List<Contact>>();
		foreach (string item in targetingContactAutoEngageMessage_0.TargetingIDs.Keys.ToList())
		{
			ActiveUnit value = null;
			if (!scenario.ActiveUnits.TryGetValue(item, out value))
			{
				continue;
			}
			List<string> list = targetingContactAutoEngageMessage_0.TargetingIDs[item];
			List<Contact> list2 = new List<Contact>();
			Side side = ((Module_Unit.Unit)value).get_UnitSide(SetSideOnly: false);
			Contact value2 = null;
			foreach (string item2 in list)
			{
				if (!string.IsNullOrEmpty(item2) && (side.Contacts.TryGetValue(item2, out value2) || side.BaseContacts.TryGetValue(item2, ref value2)))
				{
					list2.Add(value2);
				}
			}
			dictionary.Add(value, list2);
		}
		Side side2 = null;
		ReadOnlyCollection<KeyValuePair<Side, Command_Core.Misc.PostureStance>> readOnlyCollection = null;
		Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
		foreach (Side side3 in sides_ReadOnly)
		{
			if (side3.ObjectID == realtimeClient_1.CurrentSide_ObjectID)
			{
				side2 = side3;
				break;
			}
		}
		if (side2 != null)
		{
			readOnlyCollection = new ReadOnlyCollection<KeyValuePair<Side, Command_Core.Misc.PostureStance>>(side2.Postures_ReadOnly);
		}
		CoreClientCode.TargetingContactAutoEngage_Core(dictionary);
		if (readOnlyCollection == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		foreach (KeyValuePair<Side, Command_Core.Misc.PostureStance> item3 in side2.Postures_ReadOnly)
		{
			flag2 = false;
			foreach (KeyValuePair<Side, Command_Core.Misc.PostureStance> item4 in readOnlyCollection)
			{
				if (item3.Key == item4.Key)
				{
					flag2 = true;
					if (item3.Value != item4.Value)
					{
						SendSidePostureUpdate(side2, side2.Postures_ReadOnly.ToList());
						flag = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				SendSidePostureUpdate(side2, side2.Postures_ReadOnly.ToList());
				flag = true;
			}
			if (!flag)
			{
				continue;
			}
			break;
		}
	}

	private void method_24(RealtimeClient realtimeClient_1, TargetingContactManualFireMessage targetingContactManualFireMessage_0)
	{
	}

	public void CreateWeaponSalvoAction(RealtimeClient client, CreateWeaponSalvoActionMessage msg)
	{
		Scenario scenario = scenario_0;
		ActiveUnit value = null;
		if (!scenario.ActiveUnits.TryGetValue(msg.ShooterID, out value))
		{
			return;
		}
		Side side = ((Module_Unit.Unit)value).get_UnitSide(SetSideOnly: false);
		Contact contact = null;
		Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
		foreach (string targetID in msg.TargetIDs)
		{
			if (!string.IsNullOrEmpty(targetID))
			{
				contact = null;
				if (targetID == "BOL")
				{
					contact = new ActivationPointContact(msg.BOL_Latitude, msg.BOL_Longitude);
				}
				if (contact != null || side.Contacts.TryGetValue(targetID, out contact))
				{
					value.Weaponry.CreateSalvo(contact, msg.WeaponDBID, msg.WeaponQuantity, IsManual: true, ref GunStrafingSalvo, msg.ScheduledTime, msg.CreatingSalvoForPalletWeapon, msg.CreatingSalvoForPallettizedWeapon, msg.RebuildSalvoCache, GenerateFiringProposal: true, supplementingShootersOutOfAmmo: false, IsSelfDefence: false, client.Name);
					bool_6 = true;
				}
			}
		}
	}

	public void CancelWeaponSalvoAction(RealtimeClient client, CancelWeaponSalvoActionMessage msg)
	{
		Scenario theScen = scenario_0;
		Side sideByID = scenario_0.GetSideByID(msg.SideID);
		if (sideByID == null)
		{
			return;
		}
		foreach (WeaponSalvo weaponSalvo in sideByID.WeaponSalvos)
		{
			if (!(weaponSalvo.ObjectID == msg.WeaponSalvoID))
			{
				continue;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			foreach (WeaponSalvo.Shooter shooter in shootersList)
			{
				if (shooter.ShooterObjectID == msg.ShooterID)
				{
					shooter.QuantityAssigned = msg.WeaponQuantityAssigned;
					sideByID.AttemptToRemoveWeaponSalvo(ref theScen, weaponSalvo, byUser: true);
					break;
				}
			}
			bool_6 = true;
			break;
		}
	}

	public void ExecuteManualSalvosAction(RealtimeClient client, ExecuteManualWeaponSalvosMessage msg)
	{
		Side sideByID = scenario_0.GetSideByID(msg.SideID);
		if (sideByID != null && sideByID.ExecuteManualSalvos(client.Name))
		{
			bool_6 = true;
		}
	}

	public void SalvoCourseUpdate(RealtimeClient client, SalvoCourseUpdateMessage msg)
	{
		Side sideByID = scenario_0.GetSideByID(msg.SideID);
		if (sideByID == null)
		{
			return;
		}
		foreach (WeaponSalvo weaponSalvo in sideByID.WeaponSalvos)
		{
			if (weaponSalvo.ObjectID == msg.SalvoID)
			{
				weaponSalvo.PlottedCourse = msg.Course.Select(Helper.ToWaypoint).ToArray();
				bool_6 = true;
				break;
			}
		}
	}

	public void UnitCargoAction(RealtimeClient client, UnitCargoActionMessage msg)
	{
		Scenario scenario = scenario_0;
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		ActiveUnit value = null;
		foreach (string unitID in msg.UnitIDs)
		{
			if (scenario.ActiveUnits.TryGetValue(unitID, out value))
			{
				list.Add(value);
			}
		}
		switch ((UnitCargoActions)msg.Action)
		{
		case UnitCargoActions.SetPickupTarget:
			CoreClientCode.SetCargoPickupTargets_Core(list, msg.TargetIDs);
			break;
		case UnitCargoActions.UnloadAllCargo:
			CoreClientCode.UnloadCargoAction_Core(list);
			break;
		case UnitCargoActions.CargoOpsForm:
		{
			ActiveUnit value2 = null;
			if (msg.TargetIDs.Count < 2)
			{
				if (msg.TargetIDs.Count != 0 && !scenario.ActiveUnits.TryGetValue(msg.TargetIDs[0], out value2))
				{
					break;
				}
				List<Cargo> list2 = new List<Cargo>();
				List<ActiveUnit> list3 = new List<ActiveUnit>();
				if (msg.CargoIDs.Count <= 0)
				{
					break;
				}
				foreach (ActiveUnit item in list)
				{
					list3.Add(item);
					Cargo[] onboardCargo = item.OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						if (msg.CargoIDs.Contains(cargo.ObjectID))
						{
							list2.Add(cargo);
						}
					}
				}
				CoreClientCode.CargoOpsAction_Core(list3, value2, list2);
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		}
		}
	}

	public void ContainerCargoAction(RealtimeClient client, ContainerCargoActionMessage msg)
	{
		Scenario scenario = scenario_0;
		ActiveUnit value = null;
		CargoContainer cargoContainer = null;
		List<Cargo> list = new List<Cargo>();
		if (!scenario.ActiveUnits.TryGetValue(msg.UnitID, out value))
		{
			return;
		}
		Cargo[] onboardCargo = value.OnboardCargo;
		foreach (Cargo cargo in onboardCargo)
		{
			if (cargo.CargoObjectContainer != null && cargo.CargoObjectContainer.ObjectID == msg.ContainerID)
			{
				cargoContainer = cargo.CargoObjectContainer;
				break;
			}
		}
		if (cargoContainer == null)
		{
			return;
		}
		for (int j = 0; j < msg.CargoContentTypes.Count; j++)
		{
			switch ((CargoContainerContent.CargoContainerContentType)msg.CargoContentTypes[j])
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case CargoContainerContent.CargoContainerContentType.LiquidFuel:
			{
				CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel((short)msg.CargoContentIDs[j], msg.CargoContentQuantities[j]);
				if (cargoLiquidFuel != null)
				{
					Cargo item2 = new Cargo(null, cargoLiquidFuel, null);
					list.Add(item2);
				}
				break;
			}
			case CargoContainerContent.CargoContainerContentType.Ammunition:
			{
				CargoAmmunition cargoAmmunition = new CargoAmmunition(msg.CargoContentIDs[j], (int)msg.CargoContentQuantities[j], scenario);
				if (cargoAmmunition != null)
				{
					Cargo item = new Cargo(null, cargoAmmunition, null);
					list.Add(item);
				}
				break;
			}
			}
		}
		for (int k = 0; k < msg.CargoContentAUIDs.Count; k++)
		{
			if (string.IsNullOrEmpty(msg.CargoContentAUIDs[k]))
			{
				continue;
			}
			ActiveUnit value2 = null;
			if (!scenario.ActiveUnits.TryGetValue(msg.CargoContentAUIDs[k], out value2))
			{
				continue;
			}
			if (msg.Action == 0)
			{
				onboardCargo = value.OnboardCargo;
				foreach (Cargo cargo2 in onboardCargo)
				{
					if (cargo2.CargoObjectActiveUnit == value2)
					{
						list.Add(cargo2);
						break;
					}
				}
				continue;
			}
			onboardCargo = cargoContainer.OnboardCargo;
			foreach (Cargo cargo3 in onboardCargo)
			{
				if (cargo3.CargoObjectActiveUnit == value2)
				{
					list.Add(cargo3);
					break;
				}
			}
		}
		switch ((ContainerCargoActions)msg.Action)
		{
		case ContainerCargoActions.ContainerOpsFormLoadContainer:
			CoreClientCode.CargoContainerOpsAction_Core(cargoContainer, list, value, SourceIsContainer: false);
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case ContainerCargoActions.ContainerOpsFormUnloadContainer:
			CoreClientCode.CargoContainerOpsAction_Core(cargoContainer, list, value, SourceIsContainer: true);
			break;
		}
		if (GameSpeed == 0)
		{
			SendIndividualActiveUnitUpdate(value);
		}
	}

	public void SendNewChaffClouds()
	{
		if (scenario_0.ChaffClouds.Count > 0)
		{
			foreach (ChaffCorridorCloud item in scenario_0.ChaffClouds.Except(list_0).ToList())
			{
				SendChaffCloudToAll(item);
			}
		}
		list_0 = new List<ChaffCorridorCloud>(scenario_0.ChaffClouds);
	}

	public void SendChaffCloudToAll(ChaffCorridorCloud chaffCloud)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		if (chaffCloud != null)
		{
			string text = "";
			if (concurrentDictionary_6.ContainsKey(chaffCloud.ObjectID))
			{
				text = concurrentDictionary_6[chaffCloud.ObjectID];
			}
			else
			{
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
				HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
				chaffCloud.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.Flush();
				text = stringBuilder.ToString();
				StringBuilderCache.Free(stringBuilder);
				concurrentDictionary_6.TryAdd(chaffCloud.ObjectID, text);
			}
			method_87(new NewChaffCloudMessage
			{
				XML = text
			}, "SendChaffCloudToAll");
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	public void OnHostAircraftLanding(Aircraft aircraft)
	{
		concurrentDictionary_3.TryAdd(aircraft.ObjectID, aircraft);
	}

	public void OnHostUnitDocking(ActiveUnit unit)
	{
		concurrentDictionary_3.TryAdd(unit.ObjectID, unit);
	}

	private void SendConditionUpdate()
	{
		if (!bool_0)
		{
			return;
		}
		lock (object_1)
		{
			ActiveUnit value = null;
			Aircraft aircraft = null;
			List<string> list = new List<string>();
			List<byte> list2 = new List<byte>();
			List<int> list3 = new List<int>();
			List<string> list4 = new List<string>();
			List<string> list5 = new List<string>();
			List<ActiveUnit> list6 = new List<ActiveUnit>();
			Tuple<byte, int> value3;
			foreach (RealtimeClient item in list_4)
			{
				List<ActiveUnit> value2 = null;
				if (string.IsNullOrEmpty(item.CurrentSide_ObjectID) || !concurrentDictionary_4.TryGetValue(item.CurrentSide_ObjectID, out value2))
				{
					continue;
				}
				List<ActiveUnit> list7 = concurrentDictionary_3.Values.ToList();
				if (item.SelectedAirHost_ObjectIDs != null)
				{
					foreach (string selectedAirHost_ObjectID in item.SelectedAirHost_ObjectIDs)
					{
						if (!string.IsNullOrEmpty(selectedAirHost_ObjectID) && scenario_0.ActiveUnits.TryGetValue(selectedAirHost_ObjectID, out value))
						{
							list7.AddRange(value.AirOps.EmbarkedAircraft_ReadOnly);
						}
					}
				}
				if (item.SelectedDockingHost_ObjectIDs != null)
				{
					foreach (string selectedDockingHost_ObjectID in item.SelectedDockingHost_ObjectIDs)
					{
						if (!string.IsNullOrEmpty(selectedDockingHost_ObjectID) && scenario_0.ActiveUnits.TryGetValue(selectedDockingHost_ObjectID, out value))
						{
							list7.AddRange(value.DockingOps.EmbarkedBoats_ReadOnly);
						}
					}
				}
				list7 = list7.Distinct().ToList();
				list7 = list7.Intersect(value2).ToList();
				foreach (ActiveUnit item2 in list7)
				{
					if (!item2.IsAircraft)
					{
						list.Add(item2.ObjectID);
						list2.Add((byte)item2.DockingOps.Condition);
						list3.Add((int)item2.DockingOps.ConditionTimer);
						if (item2.DockingOps.HostDockFacility == null)
						{
							list5.Add("");
							list4.Add("");
						}
						else
						{
							list5.Add(item2.DockingOps.HostDockFacility.ObjectID);
							list4.Add(item2.DockingOps.HostDockFacility.ParentPlatform.ObjectID);
						}
					}
					else
					{
						aircraft = (Aircraft)item2;
						list.Add(aircraft.ObjectID);
						list2.Add((byte)aircraft.AirOps.Condition);
						list3.Add((int)aircraft.AirOps.ConditionTimer);
						if (aircraft.AirOps.HostAirFacility == null)
						{
							list5.Add("");
							list4.Add("");
						}
						else
						{
							list5.Add(aircraft.AirOps.HostAirFacility.ObjectID);
							list4.Add(aircraft.AirOps.HostAirFacility.ParentPlatform.ObjectID);
						}
					}
					if (!list6.Contains(item2))
					{
						list6.Add(item2);
					}
				}
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (dictionary_0.TryGetValue(list[num], out value3) && list2[num] == value3.Item1 && list3[num] == value3.Item2 && !concurrentDictionary_3.ContainsKey(list.ElementAt(num)))
					{
						list.RemoveAt(num);
						list2.RemoveAt(num);
						list3.RemoveAt(num);
						list5.RemoveAt(num);
						list4.RemoveAt(num);
					}
				}
				if (list.Count > 0)
				{
					method_89(item, new ConditionUpdateMessage
					{
						OpsObjectIDs = new List<string>(list),
						OpsConditions = new List<byte>(list2),
						OpsConditionTimers = new List<int>(list3),
						OpsHostUnitIDs = new List<string>(list4),
						OpsHostFacilityIDs = new List<string>(list5)
					}, "SendConditionUpdate");
					list.Clear();
					list2.Clear();
					list3.Clear();
					list4.Clear();
					list5.Clear();
				}
			}
			foreach (ActiveUnit item3 in list6)
			{
				byte condition;
				int num2;
				if (!item3.IsAircraft)
				{
					condition = (byte)item3.DockingOps.Condition;
					num2 = (int)item3.DockingOps.ConditionTimer;
				}
				else
				{
					aircraft = (Aircraft)item3;
					condition = (byte)aircraft.AirOps.Condition;
					num2 = (int)aircraft.AirOps.ConditionTimer;
				}
				if (dictionary_0.TryGetValue(item3.ObjectID, out value3))
				{
					if (condition != value3.Item1 || num2 != value3.Item2)
					{
						dictionary_0[item3.ObjectID] = new Tuple<byte, int>(condition, num2);
					}
				}
				else
				{
					dictionary_0.Add(item3.ObjectID, new Tuple<byte, int>(condition, num2));
				}
			}
			concurrentDictionary_3.Clear();
		}
	}

	private void UpdateContactStance(Side side, Command_Core.Misc.PostureStance stance, bool manual, List<string> list_6)
	{
		lock (object_1)
		{
			List<RealtimeClient> ilist_ = list_4.Where((RealtimeClient F) => F.CurrentSide_ObjectID.Equals(side.ObjectID)).ToList();
			method_88(ilist_, new ContactStanceMessage
			{
				MarkedManually = manual,
				SideID = side.ObjectID,
				Stance = (int)stance,
				ObjectIDs = list_6
			}, "UpdateContactStance");
		}
	}

	private void UpdateContactFilter(Side side, string objectID, bool FilterOut, short Filter)
	{
		lock (object_1)
		{
			List<RealtimeClient> ilist_ = list_4.Where((RealtimeClient F) => F.CurrentSide_ObjectID.Equals(side.ObjectID)).ToList();
			method_88(ilist_, new ContactFilterMessage
			{
				SideID = side.ObjectID,
				ObjectID = objectID,
				FilterState = FilterOut,
				Filter = Filter
			}, "UpdateContactFilter");
		}
	}

	private void UpdateDropContacts(Side side, List<string> list_6)
	{
		lock (object_1)
		{
			List<RealtimeClient> ilist_ = list_4.Where((RealtimeClient F) => F.CurrentSide_ObjectID.Equals(side.ObjectID)).ToList();
			method_88(ilist_, new ContactRemoveMessage
			{
				ObjectID = list_6
			}, "UpdateDropContacts");
		}
	}

	private void method_25(RealtimeClient realtimeClient_1, ContactMiscActionMessage contactMiscActionMessage_0)
	{
		Scenario scenario = scenario_0;
		Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		Contact value = null;
		foreach (string objectID in contactMiscActionMessage_0.ObjectIDs)
		{
			if (!string.IsNullOrEmpty(objectID) && (sideByID.Contacts.TryGetValue(objectID, out value) || sideByID.BaseContacts.TryGetValue(objectID, ref value)))
			{
				list.Add(value);
			}
		}
		switch ((ContactMiscAction)contactMiscActionMessage_0.Action)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case ContactMiscAction.Drop:
			CoreClientCode.DropContacts_Core(sideByID, scenario, list);
			if (hostState_0 == HostState.Paused)
			{
				UpdateDropContacts(sideByID, contactMiscActionMessage_0.ObjectIDs);
			}
			break;
		case ContactMiscAction.MarkFriendly:
			CoreClientCode.MarkContacts_Core(sideByID, scenario, Command_Core.Misc.PostureStance.Friendly, list);
			UpdateContactStance(sideByID, Command_Core.Misc.PostureStance.Friendly, manual: true, contactMiscActionMessage_0.ObjectIDs);
			break;
		case ContactMiscAction.MarkNeutral:
			CoreClientCode.MarkContacts_Core(sideByID, scenario, Command_Core.Misc.PostureStance.Neutral, list);
			UpdateContactStance(sideByID, Command_Core.Misc.PostureStance.Neutral, manual: true, contactMiscActionMessage_0.ObjectIDs);
			break;
		case ContactMiscAction.MarkUnfriendly:
			CoreClientCode.MarkContacts_Core(sideByID, scenario, Command_Core.Misc.PostureStance.Unfriendly, list);
			UpdateContactStance(sideByID, Command_Core.Misc.PostureStance.Unfriendly, manual: true, contactMiscActionMessage_0.ObjectIDs);
			break;
		case ContactMiscAction.MarkHostile:
			CoreClientCode.MarkContacts_Core(sideByID, scenario, Command_Core.Misc.PostureStance.Hostile, list);
			UpdateContactStance(sideByID, Command_Core.Misc.PostureStance.Hostile, manual: true, contactMiscActionMessage_0.ObjectIDs);
			break;
		case ContactMiscAction.MarkPosition:
			if (list.Count > 0)
			{
				CoreClientCode.MarkContactPosition_Core(sideByID, scenario, list.First());
				if (hostState_0 == HostState.Paused)
				{
					SendReferencePointUpdate();
				}
			}
			break;
		case ContactMiscAction.ToggleFilteredOutStatus:
			if (list.Count > 0)
			{
				CoreClientCode.ToggleContactFilteredOutStatus_Core(list.First());
				value = (Contact)list.First();
				UpdateContactFilter(sideByID, contactMiscActionMessage_0.ObjectIDs.First(), value.IsFilteredOut, 1);
			}
			break;
		case ContactMiscAction.FilterOutAllOn:
			CoreClientCode.SetAllContactsFilteredOutStatus_Core(sideByID, filteredOut: true);
			UpdateContactFilter(sideByID, null, FilterOut: true, 2);
			break;
		case ContactMiscAction.FilterOutAllOff:
			CoreClientCode.SetAllContactsFilteredOutStatus_Core(sideByID, filteredOut: false);
			UpdateContactFilter(sideByID, null, FilterOut: false, 2);
			break;
		case ContactMiscAction.FilterOutCivilianOn:
			CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(sideByID, filteredOut: true);
			UpdateContactFilter(sideByID, null, FilterOut: true, 3);
			break;
		case ContactMiscAction.FilterOutCivilianOff:
			CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(sideByID, filteredOut: false);
			UpdateContactFilter(sideByID, null, FilterOut: false, 3);
			break;
		case ContactMiscAction.FilterOutBiologicOn:
			CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(sideByID, filteredOut: true);
			UpdateContactFilter(sideByID, null, FilterOut: true, 4);
			break;
		case ContactMiscAction.FilterOutBiologicOff:
			CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(sideByID, filteredOut: false);
			UpdateContactFilter(sideByID, null, FilterOut: false, 4);
			break;
		case ContactMiscAction.FilterOutNeutralOn:
			CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(sideByID, filteredOut: true);
			UpdateContactFilter(sideByID, null, FilterOut: true, 5);
			break;
		case ContactMiscAction.FilterOutNeutralOff:
			CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(sideByID, filteredOut: false);
			UpdateContactFilter(sideByID, null, FilterOut: false, 5);
			break;
		case ContactMiscAction.FilterOutFriendlyOn:
			CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(sideByID, filteredOut: true);
			UpdateContactFilter(sideByID, null, FilterOut: true, 6);
			break;
		case ContactMiscAction.FilterOutFriendlyOff:
			CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(sideByID, filteredOut: false);
			UpdateContactFilter(sideByID, null, FilterOut: false, 6);
			break;
		case ContactMiscAction.RequestUpdateOnContacts:
		{
			List<Contact> list2 = new List<Contact>();
			foreach (Module_Unit.Unit item in list)
			{
				if (item.IsContact())
				{
					list2.Add((Contact)item);
				}
			}
			SendClientRequestedContactUpdate(realtimeClient_1, sideByID, list2);
			break;
		}
		}
	}

	private void method_26(RealtimeClient realtimeClient_1)
	{
		Side side = scenario_0.Sides_ReadOnly.FirstOrDefault((Side F) => F.ObjectID == realtimeClient_1.CurrentSide_ObjectID);
		if (side != null)
		{
			List<string> list = side.Contacts.Keys.ToList();
			list.AddRange(side.BaseContacts.Keys.ToList());
			realtimeClient_1.Contacts = list.ToHashSet();
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void SendClientRequestedContactUpdate(RealtimeClient client, Side side, List<Contact> list)
	{
		int count = list.Count;
		List<string> list2 = new List<string>(count);
		List<int> list3 = new List<int>(count);
		for (int i = 0; i < count; i++)
		{
			list2.Add(method_75(list[i]));
			list3.Add(list[i].get_KnownIncomingGuidedWeaponsCount(side));
		}
		method_89(client, new ContactAddOrUpdateMessage
		{
			XMLs = list2,
			KnownIncomingGuidedWeaponsCount = list3
		}, "SendClientRequestedContactUpdate");
	}

	private void method_27()
	{
		lock (object_1)
		{
			foreach (RealtimeClient realtimeClient_0 in list_4)
			{
				Side side = scenario_0.Sides_ReadOnly.FirstOrDefault((Side F) => F.ObjectID == realtimeClient_0.CurrentSide_ObjectID);
				if (side == null)
				{
					continue;
				}
				List<Contact> list = side.Contacts.Values.ToList();
				list.AddRange(side.BaseContacts.Values.ToList());
				HashSet<string> hashSet = new HashSet<string>(list.Select((Contact F) => F.ActualUnit.ObjectID));
				HashSet<string> contacts = realtimeClient_0.Contacts;
				List<string> list_ = contacts.Except(hashSet).ToList();
				method_95(new List<RealtimeClient> { realtimeClient_0 }, list_);
				List<string> list2 = hashSet.Except(contacts).ToList();
				List<Contact> sideContactsByID = Helper.GetSideContactsByID(side, list2);
				if (!string.IsNullOrEmpty(realtimeClient_0.SelectedUnit_ObjectID))
				{
					foreach (Contact item in list)
					{
						if (item.ObjectID == realtimeClient_0.SelectedUnit_ObjectID)
						{
							if (!sideContactsByID.Contains(item))
							{
								sideContactsByID.Add(item);
							}
							break;
						}
					}
				}
				method_93(new List<RealtimeClient> { realtimeClient_0 }, side, sideContactsByID);
				realtimeClient_0.Contacts = hashSet;
				List<Contact> list_2 = list.Except(sideContactsByID).Where(realtimeClient_0.method_0).ToList();
				method_94(new List<RealtimeClient> { realtimeClient_0 }, side, list_2);
			}
		}
	}

	private void method_28(int int_3)
	{
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(side.ObjectID);
			if (allClientsOnSide.Count > 0)
			{
				List<Contact> list = side.Contacts.Values.ToList();
				list.AddRange(side.BaseContacts.Values.ToList());
				list = list.Where((Contact C) => C.CurrentSpeed > 0f).ToList();
				if (list.Count > 0)
				{
					method_96(allClientsOnSide, list);
				}
			}
		}
	}

	private void SendCourseUpdate()
	{
		lock (object_1)
		{
			foreach (IGrouping<string, RealtimeClient> item in list_3)
			{
				if (concurrentDictionary_0.TryGetValue(item.Key, out var value) && value.Count > 0)
				{
					int count = value.Count;
					List<string> list = new List<string>(count);
					List<List<CourseUpdateMessage.CourseElement>> list2 = new List<List<CourseUpdateMessage.CourseElement>>(count);
					for (int i = 0; i < count; i++)
					{
						list.Add(value[i].ObjectID);
						list2.Add(value[i].Navigator.PlottedCourse.Select(Helper.ToCourseElement).ToList());
					}
					method_88(item.ToList(), new CourseUpdateMessage
					{
						ObjectID = list,
						Courses = list2
					}, "SendCourseUpdate");
				}
			}
		}
	}

	private void method_29(RealtimeClient realtimeClient_1, CourseUpdateMessage courseUpdateMessage_0)
	{
		int count = courseUpdateMessage_0.ObjectID.Count;
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			if (!scenario.ActiveUnits.ContainsKey(courseUpdateMessage_0.ObjectID[i]))
			{
				continue;
			}
			ActiveUnit activeUnit = scenario.ActiveUnits[courseUpdateMessage_0.ObjectID[i]];
			activeUnit.Navigator.ClearPlottedCourse();
			if (courseUpdateMessage_0.Courses.Count > 0)
			{
				Waypoint[] array = courseUpdateMessage_0.Courses[i].Select(Helper.ToWaypoint).ToArray();
				for (int j = 0; j < array.Length; j++)
				{
					activeUnit.Navigator.AddWaypoint(array[j]);
				}
			}
		}
	}

	public void OnHostDoctrineChanged(ScenarioObject subject, bool? viaMainForm, bool multipleUnits, bool viaDoctrineForm, bool viaRightColumn, bool viaFlightPlanEditor)
	{
		if (dictionary_1.ContainsKey(subject.ObjectID) || RealtimeTerminal.ActiveDeserializationCount > 0)
		{
			return;
		}
		Scenario scenario = scenario_0;
		if (scenario != null && DoctrineHelper.GetSubjectTypeAndDoctrine(scenario, subject, out var subjectType, out var subjectDoctrine))
		{
			switch (subjectType)
			{
			case DoctrineHelper.DoctrineSubject.HostUnit:
			case DoctrineHelper.DoctrineSubject.Side:
			case DoctrineHelper.DoctrineSubject.Mission:
				dictionary_1.Add(subject.ObjectID, subjectDoctrine);
				break;
			case DoctrineHelper.DoctrineSubject.Group:
			case DoctrineHelper.DoctrineSubject.Waypoint:
				break;
			}
		}
	}

	private void method_30()
	{
		if (dictionary_1.Count <= 0)
		{
			return;
		}
		Scenario scenario = scenario_0;
		if (scenario != null)
		{
			foreach (Doctrine item in dictionary_1.Values.ToList())
			{
				DoctrineHelper.DoctrineSubject subjectType = DoctrineHelper.GetSubjectType(item.Subject);
				SendDoctrineUpdate(scenario, item, (short)subjectType, item.Subject.ObjectID);
				if (subjectType == DoctrineHelper.DoctrineSubject.Mission && item.Subject.GetType().Equals(typeof(Strike)))
				{
					Doctrine doctrine_Escorts = ((Strike)item.Subject).Doctrine_Escorts;
					if (item != null)
					{
						SendDoctrineUpdate(scenario, doctrine_Escorts, 6, doctrine_Escorts.Subject.ObjectID);
					}
				}
			}
		}
		dictionary_1.Clear();
	}

	private void SendDoctrineUpdate(Scenario scen, Doctrine doctrine, short subjectType, string subjectID)
	{
		List<RealtimeClient> list = new List<RealtimeClient>();
		try
		{
			foreach (RealtimeClient item in list_4)
			{
				if (item.SelectedDoctrine_ObjectID == doctrine.Subject.ObjectID)
				{
					list.Add(item);
				}
				else
				{
					if (string.IsNullOrEmpty(item.SelectedUnit_ObjectID))
					{
						continue;
					}
					ActiveUnit value = null;
					if (!scen.ActiveUnits.TryGetValue(item.SelectedUnit_ObjectID, out value) || value.Doctrine == null)
					{
						continue;
					}
					bool UnitIsOperating = false;
					Doctrine parentDoctrine = value.Doctrine.GetParentDoctrine(ref UnitIsOperating);
					Doctrine doctrine2 = null;
					while (parentDoctrine != null && parentDoctrine != doctrine2)
					{
						if (!(parentDoctrine.Subject.ObjectID == doctrine.Subject.ObjectID))
						{
							doctrine2 = parentDoctrine;
							parentDoctrine = parentDoctrine.GetParentDoctrine(ref UnitIsOperating);
							continue;
						}
						list.Add(item);
						break;
					}
				}
			}
			if (list.Count > 0)
			{
				string text = method_80(doctrine, scen);
				if (text != null)
				{
					method_88(list, new DoctrineUpdateMessage
					{
						SubjectType = subjectType,
						SubjectID = subjectID,
						DoctrineXML = text
					}, "SendDoctrineUpdate");
				}
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	private void method_31(RealtimeClient realtimeClient_1, SelectDoctrineMessage selectDoctrineMessage_0)
	{
		if (!string.IsNullOrEmpty(selectDoctrineMessage_0.SubjectID))
		{
			realtimeClient_1.SelectedDoctrine_ObjectID = selectDoctrineMessage_0.SubjectID;
		}
		else
		{
			realtimeClient_1.SelectedDoctrine_ObjectID = "";
		}
	}

	private void method_32(RealtimeClient realtimeClient_1, DoctrineChangedMessage doctrineChangedMessage_0)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		try
		{
			Doctrine doctrine = null;
			DoctrineHelper.DoctrineSubject subjectType = (DoctrineHelper.DoctrineSubject)doctrineChangedMessage_0.SubjectType;
			if (realtimeClient_1.LoopbackMode)
			{
				RealtimeTerminal.ActiveDeserializationCount++;
				realtimeClient_1.Loopback.DisableCommandCoreEventNotifications();
			}
			if (DoctrineHelper.UpdateDoctrineFromXML(scenario, doctrineChangedMessage_0.SubjectID, subjectType, doctrineChangedMessage_0.DoctrineXML, out doctrine))
			{
				if (GameSpeed == 0)
				{
					List<ActiveUnit> list = doctrine.AffectedUnits(scenario, subjectType == DoctrineHelper.DoctrineSubject.MissionEscort);
					foreach (ActiveUnit item in list)
					{
						item.Sensory.vmethod_2(item.Sensors_Cached);
					}
					method_2(realtimeClient_1, list, bool_14: true);
				}
				SendDoctrineUpdate(scenario, doctrine, doctrineChangedMessage_0.SubjectType, doctrineChangedMessage_0.SubjectID);
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (realtimeClient_1.LoopbackMode)
		{
			RealtimeTerminal.ActiveDeserializationCount--;
			realtimeClient_1.Loopback.EnableCommandCoreEventNotifications();
		}
	}

	private void SendEmbarkedOpsUpdate()
	{
		lock (object_1)
		{
			<>c__DisplayClass88_0 <>c__DisplayClass88_0_ = default(<>c__DisplayClass88_0);
			<>c__DisplayClass88_0_.dictionary_0 = new Dictionary<string, HashSet<string>>();
			<>c__DisplayClass88_0_.hashSet_0 = new HashSet<ActiveUnit>();
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				AirFacility[] airFacilities_ReadOnly = activeUnits_.AirFacilities_ReadOnly;
				for (int i = 0; i < airFacilities_ReadOnly.Length; i++)
				{
					foreach (Aircraft value in airFacilities_ReadOnly[i].HostedAircraft.Values)
					{
						smethod_1(activeUnits_, value, ref <>c__DisplayClass88_0_);
					}
				}
				DockFacility[] dockFacilities_ReadOnly = activeUnits_.DockFacilities_ReadOnly;
				for (int i = 0; i < dockFacilities_ReadOnly.Length; i++)
				{
					foreach (ActiveUnit value2 in dockFacilities_ReadOnly[i].HostedBoats.Values)
					{
						smethod_1(activeUnits_, value2, ref <>c__DisplayClass88_0_);
					}
				}
			}
			Dictionary<string, int> readyAircraftCount = <>c__DisplayClass88_0_.hashSet_0.ToDictionary((ActiveUnit F) => F.ObjectID, (ActiveUnit F) => F.AirOps.ReadyAircraft.Count());
			Dictionary<string, int> readyBoatCount = <>c__DisplayClass88_0_.hashSet_0.ToDictionary((ActiveUnit F) => F.ObjectID, (ActiveUnit F) => ActiveUnit_DockingOps.ReadyBoats(F.DockingOps).Count());
			method_87(new EmbarkedOpsUpdateMessage
			{
				Embarked = <>c__DisplayClass88_0_.dictionary_0,
				ReadyAircraftCount = readyAircraftCount,
				ReadyBoatCount = readyBoatCount
			}, "SendEmbarkedOpsUpdate");
		}
	}

	private void method_33(RealtimeClient realtimeClient_1, EmbarkedOpsRearmMessage embarkedOpsRearmMessage_0)
	{
		<>c__DisplayClass89_0 <>c__DisplayClass89_ = new <>c__DisplayClass89_0();
		<>c__DisplayClass89_.scenario_0 = scenario_0;
		if (<>c__DisplayClass89_.scenario_0 == null)
		{
			return;
		}
		bool_0 = true;
		if (embarkedOpsRearmMessage_0.DrawWeaponsFromMagazine)
		{
			foreach (Aircraft item in <>c__DisplayClass89_.method_0(embarkedOpsRearmMessage_0.Aircraft).Cast<Aircraft>().ToList())
			{
				item.AirOps.UnloadStores();
			}
		}
		foreach (Aircraft item2 in <>c__DisplayClass89_.method_0(embarkedOpsRearmMessage_0.Aircraft).Cast<Aircraft>().ToList())
		{
			Aircraft_AirOps airOps = item2.AirOps;
			int oldLoadoutID = item2.Loadout?.DBID ?? 0;
			if (item2.Loadout == null || item2.Loadout.Weapons.Length == 0)
			{
				item2.Loadout = null;
				item2.Weaponry.ClearCachedWeapons();
			}
			ActiveUnit currentHostUnit = airOps.CurrentHostUnit;
			Aircraft theAircraft = item2;
			currentHostUnit.AirOps.OutfitAC(ref theAircraft, embarkedOpsRearmMessage_0.LoadoutID, oldLoadoutID, embarkedOpsRearmMessage_0.ReadyImmediately, embarkedOpsRearmMessage_0.ExcludeOptionalWeapons, embarkedOpsRearmMessage_0.DrawWeaponsFromMagazine, embarkedOpsRearmMessage_0.ManualAction, PlayerFeedback: false);
			currentHostUnit.AirOps.RefuelAC_Simple(ref theAircraft);
			currentHostUnit.AirOps.RepairAC(ref theAircraft);
			if (embarkedOpsRearmMessage_0.ReadyImmediately)
			{
				AirFacility hostAirFacility = currentHostUnit.AirOps.WhichFacilityCanHostThis(theAircraft);
				airOps.HostAirFacility = hostAirFacility;
				if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
				{
					airOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
				}
			}
		}
	}

	private void method_34(RealtimeClient realtimeClient_1, EmbarkedOpsLaunchMessage embarkedOpsLaunchMessage_0)
	{
		<>c__DisplayClass90_0 <>c__DisplayClass90_ = new <>c__DisplayClass90_0();
		<>c__DisplayClass90_.scenario_0 = scenario_0;
		if (<>c__DisplayClass90_.scenario_0 == null)
		{
			return;
		}
		bool_0 = true;
		if (embarkedOpsLaunchMessage_0.LaunchAircraftIndividually != null)
		{
			foreach (Aircraft item in <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.LaunchAircraftIndividually).Cast<Aircraft>())
			{
				item.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
			}
		}
		if (embarkedOpsLaunchMessage_0.LaunchAircraftGroup != null)
		{
			IEnumerable<Aircraft> enumerable = <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.LaunchAircraftGroup).Cast<Aircraft>();
			Command_Core.Misc.FormIntoGroups(enumerable.Cast<ActiveUnit>().ToList(), scenario_0, ((Module_Unit.Unit)enumerable.First()).get_UnitSide(SetSideOnly: false), Command_Core.Misc.GroupingLogic.MixedGroup);
			foreach (Aircraft item2 in enumerable)
			{
				item2.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
			}
		}
		if (embarkedOpsLaunchMessage_0.AbortAircraft != null)
		{
			foreach (Aircraft item3 in <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.AbortAircraft).Cast<Aircraft>())
			{
				if (item3.AirOps.IsTakingOff)
				{
					item3.AirOps.AttemptToPark(NormalLandingSequence: true, RearmRefuel: false, AbortLaunch: true);
					if (item3.Navigator.HasFlight)
					{
						item3.Navigator.Flight_C_Sharp.set_Status(scenario_0, Mission._FlightStatus.None);
					}
				}
				if (item3.IsGroupMember())
				{
					((ActiveUnit)item3).set_ParentGroup(UsingMissionPlanner: true, (Group)null);
				}
			}
		}
		if (embarkedOpsLaunchMessage_0.AbortBoats != null)
		{
			foreach (ActiveUnit item4 in <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.AbortBoats))
			{
				if (item4.DockingOps.IsDeploying)
				{
					item4.DockingOps.AttemptToStartDocking(item4.DockingOps.CurrentHostUnit, CancelDeployment: true);
				}
			}
		}
		if (embarkedOpsLaunchMessage_0.LaunchBoatsIndividually != null)
		{
			foreach (ActiveUnit item5 in <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.LaunchBoatsIndividually))
			{
				item5.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			}
		}
		if (embarkedOpsLaunchMessage_0.LaunchBoatsGroup == null)
		{
			return;
		}
		IEnumerable<ActiveUnit> enumerable2 = <>c__DisplayClass90_.method_0(embarkedOpsLaunchMessage_0.LaunchBoatsGroup);
		Command_Core.Misc.FormIntoGroups(enumerable2.Cast<ActiveUnit>().ToList(), scenario_0, ((Module_Unit.Unit)enumerable2.First()).get_UnitSide(SetSideOnly: false), Command_Core.Misc.GroupingLogic.MixedGroup);
		foreach (ActiveUnit item6 in enumerable2)
		{
			item6.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
		}
	}

	public void OnHostScenExplosionAdded(object sender, ObservableListModified<Explosion> e)
	{
		foreach (Explosion item in e.Items)
		{
			SendNewExplosionToAll(item);
		}
	}

	public void SendNewExplosionToAll(Explosion explosion)
	{
		if (explosion != null)
		{
			string text = method_74(explosion);
			if (text != null)
			{
				method_87(new NewExplosionMessage
				{
					XML = text
				}, "SendNewExplosionToAll");
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void method_35(RealtimeClient realtimeClient_1, Scenario scenario_1, Side side_0, Mission mission_0)
	{
		SendUpdateMission(mission_0, side_0.ObjectID, null);
		List<ActiveUnit> unitsAssignedToMission = MissionHelper.GetUnitsAssignedToMission(scenario_1, side_0, mission_0);
		if (unitsAssignedToMission.Count > 0)
		{
			method_2(realtimeClient_1, unitsAssignedToMission, bool_14: true);
		}
	}

	public void MissionGenerateFlightPlans(RealtimeClient client, MissionGenerateFlightPlansMessage msg)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		Side side = Array.Find(scenario.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (side == null)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(side.Missions, msg.MissionID);
		if (mission == null)
		{
			return;
		}
		string text = "OK";
		scenario.MissionPlannerErrorList.Clear();
		switch ((MissionFlightPlanGenerationFlags)msg.Flags)
		{
		case MissionFlightPlanGenerationFlags.CreateNew:
			text = CoreClientCode.GenerateMissionFlightPlans_Core(scenario, side, mission, msg.RequestedFlightSize);
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case MissionFlightPlanGenerationFlags.UpdateTimes:
			MissionPlanner.Update_Mission_times(scenario, mission);
			break;
		}
		if (text == "OK")
		{
			method_35(client, scenario, side, mission);
			SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightPlanGeneration, scenario, mission, null);
		}
		else
		{
			SendMissionEditorWarning(client, "Realtime Flight Planning", text);
		}
	}

	public void MissionGenerateFlightsForTaskPool(RealtimeClient client, MissionGenerateFlightsForTaskPoolMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null)
		{
			return;
		}
		Side theSide = Array.Find(theScen.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (theSide == null)
		{
			return;
		}
		Mission theSpecificMission = MissionHelper.FindMissionByID(theSide.Missions, msg.TaskPoolID);
		if (theSpecificMission == null)
		{
			return;
		}
		List<Mission> list = new List<Mission>();
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		foreach (string packageID in msg.PackageIDs)
		{
			Mission mission = MissionHelper.FindMissionByID(theSide.Missions, packageID);
			if (mission != null)
			{
				CoreClientCode.CreateMissionFlights_Core(mission, theScen, theSide, mission.FlightSize);
				mission.TimeSincePlayerNotification = 0;
				list.Add(mission);
				list2.AddRange(MissionHelper.GetUnitsAssignedToMission(theScen, theSide, mission));
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		GameGeneral.CheckForMissionWakeup(ref theScen, ref theSide, ref theSpecificMission, IncludeEmptySlots: true, OrderTakeOff: false, LaunchPrePlannedPackages: false, 0);
		SendUpdateMission(theSpecificMission, theSide.ObjectID, null);
		foreach (Mission item in list)
		{
			SendUpdateMission(item, theSide.ObjectID, null);
		}
		if (list2.Count > 0)
		{
			method_2(client, list2, bool_14: true);
		}
		SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightPlanGeneration, theScen, null, null);
	}

	public void MissionFillEmptySlots(RealtimeClient client, MissionFillEmptySlotsMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null)
		{
			return;
		}
		Side theSide = Array.Find(theScen.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (theSide == null)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionID);
		if (mission == null)
		{
			return;
		}
		Mission.Flight flight = null;
		if (!string.IsNullOrEmpty(msg.SpecificFlightID))
		{
			foreach (Mission.Flight flight2 in mission.FlightList)
			{
				if (flight2.ObjectID == msg.SpecificFlightID)
				{
					flight = flight2;
					break;
				}
			}
		}
		bool IsManual = msg.IsManual;
		mission.FillEmptySlots(theScen, ref theSide, ref IsManual, flight, msg.FillFlightsWithNoAircraftSpecified);
		mission.ReconfigureMissionForPrePlannedFlights(ref theScen, ref theSide, null);
		mission.TimeSincePlayerNotification = 0;
		method_35(client, theScen, theSide, mission);
		SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightGeneration, theScen, mission, flight);
	}

	public void MissionEditorDeleteFlights(RealtimeClient client, MissionEditorDeleteFlightsMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null)
		{
			return;
		}
		Side theSide = Array.Find(theScen.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (theSide == null)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionID);
		if (mission == null)
		{
			return;
		}
		if (msg.FlightIDs.Count == 0)
		{
			mission.DeleteFlights(ref theScen, ref theSide);
		}
		else
		{
			List<Mission.Flight> list = new List<Mission.Flight>();
			list.AddRange(mission.FlightList);
			foreach (Mission.Flight item in list)
			{
				foreach (string flightID in msg.FlightIDs)
				{
					if (item.ObjectID == flightID)
					{
						Mission.Flight theSelectedFlight = item;
						mission.DeleteFlight(ref theScen, ref theSide, ref theSelectedFlight, theSelectedFlight.ObjectID);
					}
				}
			}
		}
		method_35(client, theScen, theSide, mission);
		SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightGeneration, theScen, mission, null);
	}

	public void SendMissionEditorEvent(RealtimeClient client, MissionEditorEventMessage.EventType theEvent, Scenario scen, Mission mission, Mission.Flight flight)
	{
		List<(string, string, string)> list = null;
		if (scen.MissionPlannerErrorList.Count > 0)
		{
			list = new List<(string, string, string)>();
			foreach (MDSP_Error missionPlannerError in scen.MissionPlannerErrorList)
			{
				list.Add((missionPlannerError.Mission, missionPlannerError.Flight, missionPlannerError.Message));
			}
		}
		method_89(client, new MissionEditorEventMessage
		{
			eventType = (int)theEvent,
			errors = list
		}, "SendMissionEditorFlightPlanGenerationComplete");
	}

	public void SendMissionEditorWarning(RealtimeClient client, string title, string warning)
	{
		method_89(client, new MissionEditorShowWarningMessage
		{
			Title = title,
			Message = warning
		}, "SendMissionEditorWarning");
	}

	public void ChangeFlight(RealtimeClient client, ChangeFlightMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null)
		{
			return;
		}
		Side theSide = Array.Find(theScen.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (theSide == null)
		{
			return;
		}
		Mission theMission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionID);
		if (theMission == null)
		{
			return;
		}
		Mission.Flight theFlight = MissionHelper.FindMissionFlightByID(theMission, msg.FlightID);
		ActiveUnit value = null;
		Module_Unit.Unit theSelectedUnit = null;
		if (!string.IsNullOrEmpty(msg.UnitID))
		{
			if (!theScen.ActiveUnits.TryGetValue(msg.UnitID, out value))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			theSelectedUnit = value;
		}
		List<ActiveUnit> list = null;
		if (msg.UnitListIDs != null)
		{
			list = new List<ActiveUnit>();
			foreach (string unitListID in msg.UnitListIDs)
			{
				_ = unitListID;
				if (theScen.ActiveUnits.TryGetValue(msg.UnitID, out value))
				{
					list.Add(value);
				}
			}
		}
		if (theFlight == null)
		{
			if (msg.ChangeType == 19)
			{
				CoreClientCode.CreateFlight_Core(theScen, theSide, theMission, msg.Value, msg.Flag);
				method_35(client, theScen, theSide, theMission);
				SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightGeneration, theScen, theMission, theFlight);
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		switch ((ChangeFlightType)msg.ChangeType)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case ChangeFlightType.EmptySlots:
			if (!string.IsNullOrEmpty(msg.UnitID))
			{
				theMission.ClearAircraft_ReplaceWithEmptySlot(ref theScen, ref theFlight, ref value);
			}
			else
			{
				theMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref theFlight);
			}
			break;
		case ChangeFlightType.LocationTakeoff:
			CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref theMission, theFlight, ref theFlight.TakeOffLocation_HostUnitObjectName, ref theFlight.TakeOffLocation_HostUnitObjectID, ref theSelectedUnit, IsTakeOffLocation: true, IsLandingLocation: false, IsDiversionLocation: false);
			break;
		case ChangeFlightType.LocationLanding:
			CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref theMission, theFlight, ref theFlight.LandingLocation_HostUnitObjectName, ref theFlight.LandingLocation_HostUnitObjectID, ref theSelectedUnit, IsTakeOffLocation: false, IsLandingLocation: true, IsDiversionLocation: false);
			break;
		case ChangeFlightType.LocationTakeoffAndLanding:
			CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref theMission, theFlight, ref theFlight.TakeOffLocation_HostUnitObjectName, ref theFlight.TakeOffLocation_HostUnitObjectID, ref theSelectedUnit, IsTakeOffLocation: true, IsLandingLocation: true, IsDiversionLocation: false);
			theFlight.LandingLocation_HostUnitObjectName = theFlight.TakeOffLocation_HostUnitObjectName;
			theFlight.LandingLocation_HostUnitObjectID = theFlight.TakeOffLocation_HostUnitObjectID;
			break;
		case ChangeFlightType.LocationDivert:
		{
			string theLocationName = "";
			string theLocationObjectID = "";
			CoreClientCode.ChangeFlightLocation_Core(ref theScen, ref theSide, ref theMission, theFlight, ref theLocationName, ref theLocationObjectID, ref theSelectedUnit, IsTakeOffLocation: false, IsLandingLocation: false, IsDiversionLocation: true);
			break;
		}
		case ChangeFlightType.FlightType:
			CoreClientCode.ChangeFlightType_Core(theFlight, ref theScen, ref theSide, ref theMission, (Mission._FlightType)msg.Value);
			break;
		case ChangeFlightType.AircraftType:
			CoreClientCode.ChangeFlightAircraftType_Core(theScen, theSide, theMission, theFlight, ClearExistingAircraft: false, msg.Value);
			break;
		case ChangeFlightType.AircraftTypeClearExisting:
			CoreClientCode.ChangeFlightAircraftType_Core(theScen, theSide, theMission, theFlight, ClearExistingAircraft: true, msg.Value);
			break;
		case ChangeFlightType.Loadout:
			CoreClientCode.ChangeFlightLoadout_Core(theScen, theSide, theMission, theFlight, ClearExistingAircraft: false, msg.Value, msg.Text);
			break;
		case ChangeFlightType.LoadoutClearExisting:
			CoreClientCode.ChangeFlightLoadout_Core(theScen, theSide, theMission, theFlight, ClearExistingAircraft: true, msg.Value, msg.Text);
			break;
		case ChangeFlightType.AssignedAircraft:
			CoreClientCode.ChangeFlightAssignedUnits_Core(theScen, theSide, theMission, theFlight, list);
			break;
		case ChangeFlightType.SizeDesired:
			theFlight?.ChangeDesiredFlightSize(ref theScen, ref theMission, theSide, msg.Value);
			break;
		case ChangeFlightType.SizeMinimum:
			theFlight?.ChangeMinimumFlightSize(ref theScen, ref theMission, theSide, msg.Value);
			break;
		case ChangeFlightType.Task:
			CoreClientCode.ChangeFlightTask_Core(theScen, theSide, theMission, theFlight, (Mission._FlightTask)msg.Value);
			break;
		case ChangeFlightType.Priority:
			if (theFlight != null)
			{
				theFlight.Priority = (Mission._FlightPriority)msg.Value;
			}
			break;
		case ChangeFlightType.Callsign:
			if (theFlight != null)
			{
				theFlight.RenameFlightplanInFlightplanErrorList(ref theScen, ref theFlight, theFlight.Callsign, msg.Text);
				theFlight.Callsign = msg.Text;
			}
			break;
		case ChangeFlightType.TakeoffWaypointTimeToggle:
			CoreClientCode.ChangeFlightToggleTakeoffWaypointTime_Core(theScen, theSide, theMission, theFlight);
			break;
		case ChangeFlightType.TargetWaypointTimeToggle:
			CoreClientCode.ChangeFlightToggleTargetWaypointTime_Core(theScen, theSide, theMission, theFlight);
			break;
		case ChangeFlightType.CreateNewFlight:
			CoreClientCode.CreateFlight_Core(theScen, theSide, theMission, msg.Value, msg.Flag);
			break;
		case ChangeFlightType.CreateCopyOfFlight:
			CoreClientCode.CopyFlight_Core(theScen, theSide, theMission, theFlight);
			break;
		case ChangeFlightType.DeleteFlight:
			CoreClientCode.DeleteFlight_Core(theScen, theSide, theMission, theFlight);
			break;
		case ChangeFlightType.DeleteFlightPlan:
			theMission.DeleteFlightplan(ref theScen, ref theSide, ref theFlight);
			break;
		case ChangeFlightType.ClearTimes:
		{
			CoreClientCode.ClearFlightTime_Core(theFlight);
			Waypoint[] theFlightplan = theFlight.FlightPlan;
			float NecessaryFuel = 0f;
			float MissionFuel = 0f;
			MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theFlight.get_ReferenceUnit(theScen), theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Command_Core.Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
			break;
		}
		case ChangeFlightType.CreateFlightPlanFull:
			CoreClientCode.GenerateMissionFlightPlanFull_Core(theScen, theSide, theMission, theFlight);
			break;
		case ChangeFlightType.CreateFlightPlanSkeleton:
			CoreClientCode.GenerateMissionFlightPlanSkeleton_Core(theScen, theSide, theMission, theFlight);
			break;
		}
		method_35(client, theScen, theSide, theMission);
		SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightGeneration, theScen, theMission, theFlight);
	}

	public void ChangeFlightPlanWaypoint(RealtimeClient client, ChangeFlightPlanWaypointMessage msg)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		Side side = Array.Find(scenario.Sides_ReadOnly, (Side S) => S.ObjectID == client.CurrentSide_ObjectID);
		if (side == null)
		{
			return;
		}
		Mission theMission = MissionHelper.FindMissionByID(side.Missions, msg.MissionID);
		if (theMission == null)
		{
			return;
		}
		Mission.Flight flight = MissionHelper.FindMissionFlightByID(theMission, msg.FlightID);
		if (flight == null)
		{
			return;
		}
		Waypoint TheWaypoint = Array.Find(flight.FlightPlan, (Waypoint W) => W.ObjectID == msg.WaypointID);
		if (TheWaypoint == null)
		{
			return;
		}
		switch ((ChangeFlightPlanWaypointType)msg.ChangeType)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case ChangeFlightPlanWaypointType.AttackMethod:
			CoreClientCode.ChangeFlightPlanWaypointAttackMethod_Core(scenario, side, theMission, flight, TheWaypoint, (Mission._AttackMethod)msg.Value);
			break;
		case ChangeFlightPlanWaypointType.DateTime:
		{
			DateTime theDateTime = new DateTime(msg.Value);
			float holdSeconds = TheWaypoint.Hold_Time;
			float stationSeconds = TheWaypoint.Station_Time;
			float spacingSeconds = TheWaypoint.SpacingManeuver_Time;
			float separationSeconds = TheWaypoint.Separation_Time;
			Mission.Flight.FlightElement theFlightElement = (Mission.Flight.FlightElement)msg.FlightElement;
			if (msg.values_f != null && msg.values_f.Count > 3)
			{
				holdSeconds = msg.values_f[0];
				stationSeconds = msg.values_f[1];
				spacingSeconds = msg.values_f[2];
				separationSeconds = msg.values_f[3];
			}
			CoreClientCode.ChangeFlightPlanWaypointTime_Core(scenario, side, theMission, flight, theFlightElement, TheWaypoint, theDateTime, holdSeconds, stationSeconds, spacingSeconds, separationSeconds, RunValidation: true);
			break;
		}
		case ChangeFlightPlanWaypointType.WaypointType:
		{
			Waypoint theNextWaypoint2 = null;
			bool refuelAtWaypointOnly = false;
			Waypoint.WaypointType theWayPointType = (Waypoint.WaypointType)msg.Value;
			if (!string.IsNullOrEmpty(msg.NextWaypointID))
			{
				theNextWaypoint2 = Array.Find(flight.FlightPlan, (Waypoint W) => W.ObjectID == msg.NextWaypointID);
			}
			if (msg.values_f != null && msg.values_f.Count > 0)
			{
				refuelAtWaypointOnly = true;
			}
			CoreClientCode.ChangeFlightPlanWaypointType_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint, theWayPointType, theNextWaypoint2, refuelAtWaypointOnly);
			break;
		}
		case ChangeFlightPlanWaypointType.Formation:
		{
			Waypoint theNextWaypoint = null;
			Waypoint thePreviousWaypoint = null;
			Waypoint.Formation theFormation = (Waypoint.Formation)msg.Value;
			if (!string.IsNullOrEmpty(msg.NextWaypointID))
			{
				theNextWaypoint = Array.Find(flight.FlightPlan, (Waypoint W) => W.ObjectID == msg.NextWaypointID);
			}
			if (!string.IsNullOrEmpty(msg.PreviousWaypointID))
			{
				thePreviousWaypoint = Array.Find(flight.FlightPlan, (Waypoint W) => W.ObjectID == msg.PreviousWaypointID);
			}
			CoreClientCode.ChangeFlightPlanWaypointFormation_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint, theFormation, theNextWaypoint, thePreviousWaypoint);
			break;
		}
		case ChangeFlightPlanWaypointType.TurnRate:
			CoreClientCode.ChangeFlightPlanWaypointTurnRate_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint, (Waypoint.TurnRateCategory)msg.Value);
			break;
		case ChangeFlightPlanWaypointType.AARUsage:
			CoreClientCode.ChangeFlightPlanWaypointDoctrineAARUsage_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint, (int)msg.Value);
			break;
		case ChangeFlightPlanWaypointType.AARSelection:
			CoreClientCode.ChangeFlightPlanWaypointDoctrineAARSelection_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint, (int)msg.Value);
			break;
		case ChangeFlightPlanWaypointType.SpeedAdjustmentTOT:
			TheWaypoint.SpeedAdjustmentToT = (Waypoint.SpeedToT)msg.Value;
			break;
		case ChangeFlightPlanWaypointType.UpdateWingmanWaypointLockTargetTimes:
			CoreClientCode.LockWingmanTargetWaypoints_Core(flight, ref theMission, ref TheWaypoint);
			break;
		case ChangeFlightPlanWaypointType.UpdateWingmanWaypointTargetTimesWithLock:
		{
			Waypoint[] theFlightplan2 = flight.FlightPlan;
			CoreClientCode.LockWingmanTargetWaypoints_Core(flight, ref theMission, ref TheWaypoint);
			CoreClientCode.UpdateWingmanWaypoints_Core(flight, ref TheWaypoint, ref theMission, ref theFlightplan2, (Mission.Flight.FlightElement)msg.FlightElement);
			break;
		}
		case ChangeFlightPlanWaypointType.UpdateWingmanWaypointTargetTimesNoLock:
		{
			Waypoint[] theFlightplan = flight.FlightPlan;
			CoreClientCode.UpdateWingmanWaypoints_Core(flight, ref TheWaypoint, ref theMission, ref theFlightplan, (Mission.Flight.FlightElement)msg.FlightElement);
			break;
		}
		case ChangeFlightPlanWaypointType.DeleteWaypoint:
			CoreClientCode.ChangeFightPlanDeleteWaypoint_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint);
			break;
		case ChangeFlightPlanWaypointType.InsertWaypointAfter:
			CoreClientCode.ChangeFightPlanInsertWaypoint_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint);
			break;
		case ChangeFlightPlanWaypointType.ToggleTimeFixedFree:
			CoreClientCode.ChangeFlightPlanToggleWaypointTime_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint);
			break;
		case ChangeFlightPlanWaypointType.ToggleSpeedFixedFree:
			CoreClientCode.ChangeFlightPlanToggleWaypointSpeed_Core(scenario, side, theMission, flight, (Mission.Flight.FlightElement)msg.FlightElement, TheWaypoint);
			break;
		}
		List<ActiveUnit> list = MissionHelper.ResyncFlightPlans(scenario, side, theMission);
		SendUpdateMission(theMission, side.ObjectID, null);
		if (list.Count > 0)
		{
			method_2(client, list, bool_14: true);
		}
		SendMissionEditorEvent(client, MissionEditorEventMessage.EventType.FlightGeneration, scenario, theMission, flight);
	}

	public void OnHostScenGroundImpactAdded(object sender, ObservableListModified<GroundImpact> e)
	{
		foreach (GroundImpact item in e.Items)
		{
			SendNewGroundImpactToAll(item);
		}
	}

	public void SendNewGroundImpactToAll(GroundImpact groundImpact)
	{
		if (groundImpact != null)
		{
			string text = method_74(groundImpact);
			if (text != null)
			{
				method_87(new NewGroundImpactMessage
				{
					XML = text
				}, "SendNewGroundImpactToAll");
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	public void OnHostGroupMembershipChange(Group group, ActiveUnit unit)
	{
		concurrentDictionary_2.TryAdd(unit.ObjectID, unit);
	}

	public void SendSimGroupMembershipUpdates()
	{
		if (concurrentDictionary_2.Any())
		{
			List<ActiveUnit> groupMembers = concurrentDictionary_2.Values.ToList();
			SendGroupMembershipUpdate(groupMembers);
			concurrentDictionary_2.Clear();
		}
	}

	public void SendGroupFullUpdate(RealtimeClient client, Group group)
	{
		foreach (ActiveUnit value in group.Units.Values)
		{
			SendClientIndividualActiveUnitUpdate(client, value);
		}
		SendClientIndividualActiveUnitUpdate(client, group);
	}

	public void SendGroupMembershipUpdate(Group group)
	{
		if (group != null)
		{
			SendGroupMembershipUpdate(group.Units.Values.ToList());
		}
	}

	public void SendGroupMembershipUpdate(List<ActiveUnit> groupMembers)
	{
		if (groupMembers == null || groupMembers.Count < 1)
		{
			return;
		}
		Side side = ((Module_Unit.Unit)groupMembers[0]).get_UnitSide(SetSideOnly: false);
		foreach (IGrouping<string, RealtimeClient> item in list_3)
		{
			if (!(item.Key == side.ObjectID))
			{
				continue;
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			Group obj = null;
			foreach (ActiveUnit groupMember in groupMembers)
			{
				list.Add(groupMember.ObjectID);
				obj = groupMember.get_ParentGroup(UsingMissionPlanner: false);
				if (obj != null)
				{
					list2.Add(obj.ObjectID);
				}
				else
				{
					list2.Add("");
				}
			}
			method_88(item.ToList(), new GroupMembershipUpdateMessage
			{
				UnitIDs = list,
				ParentGroupIDs = list2
			}, "SendGroupMembershipUpdate");
			break;
		}
	}

	public void GroupFormationSet(RealtimeClient client, GroupFormationSetMessage msg)
	{
		ActiveUnit value = null;
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		switch ((GroupFormationFlags)msg.Flags)
		{
		case GroupFormationFlags.None:
			if (scenario.ActiveUnits.TryGetValue(msg.GroupID, out value) && value.IsGroup)
			{
				StandardFormation.SetFormation(value, msg.Formation, msg.Heading, msg.Spacing, msg.SpacingUnits, msg.TeleportUnits);
				SendGroupFullUpdate(client, (Group)value);
			}
			break;
		case GroupFormationFlags.NavalFormationLua:
			if (bool_1)
			{
				try
				{
					scenario.Scenario_LuaSandbox.RunScript(msg.Formation, RunInteractively: false);
					break;
				}
				catch (Exception ex)
				{
					GameGeneral.WriteExceptionsToLog(ex);
					break;
				}
			}
			break;
		}
	}

	public void GroupFormationSetLead(RealtimeClient client, GroupFormationSetLeadMessage msg)
	{
		ActiveUnit value = null;
		if (scenario_0.ActiveUnits.TryGetValue(msg.UnitID, out value))
		{
			Group obj = value.get_ParentGroup(UsingMissionPlanner: false);
			if (obj != null)
			{
				obj.SetGroupLead(value);
				SendGroupFullUpdate(client, obj);
			}
		}
	}

	public void GroupFormationSetStation(RealtimeClient client, GroupFormationSetStationMessage msg)
	{
		ActiveUnit value = null;
		if (scenario_0.ActiveUnits.TryGetValue(msg.UnitID, out value))
		{
			value.Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)msg.BearingType;
			value.Navigator.CalculateFormationStationRelativeData(msg.Longitude, msg.Latitude, ResetValues: true);
			SendClientIndividualActiveUnitUpdate(client, value);
		}
	}

	public void GroupFormationSetSprintDrift(RealtimeClient client, GroupFormationSprintDriftMessage msg)
	{
		ActiveUnit value = null;
		if (scenario_0.ActiveUnits.TryGetValue(msg.UnitID, out value))
		{
			value.Navigator.SprintDrift = msg.SprintDrift;
			SendClientIndividualActiveUnitUpdate(client, value);
		}
	}

	public void ScoringUpdate(RealtimeClient client, ScoringUpdateMessage msg)
	{
		string text = "";
		Scenario scenario = scenario_0;
		Side side = null;
		if (scenario == null)
		{
			return;
		}
		switch ((ScoringInfoType)msg.InformationType)
		{
		case ScoringInfoType.Losses:
			text = GameGeneral.GetAllSideLosses_AsString(scenario);
			break;
		case ScoringInfoType.Scoring:
		{
			text = scenario.Time.ToString() + Environment.NewLine;
			Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (side2.ObjectID == client.CurrentSide_ObjectID)
				{
					side = side2;
					break;
				}
			}
			if (side == null)
			{
				break;
			}
			text = text + side.get_TotalScore((Scenario)null, (string)null) + Environment.NewLine;
			foreach (string item in side.ScoringLog)
			{
				text = text + item + Environment.NewLine;
			}
			break;
		}
		}
		if (!string.IsNullOrEmpty(text))
		{
			method_89(client, new ScoringUpdateMessage
			{
				InformationType = msg.InformationType,
				Info = text
			}, "SendScoringUpdate");
		}
	}

	private void SendMessageLogUpdate()
	{
		if (scenario_0 == null || scenario_0.MessageLog.Count < 1)
		{
			return;
		}
		lock (object_1)
		{
			int num = -1;
			int count = scenario_0.MessageLog.Count;
			if (long_0 == 0L)
			{
				num = 0;
			}
			else
			{
				for (int i = 0; i < count; i++)
				{
					if (scenario_0.MessageLog[i].Increment > long_0)
					{
						num = i;
						break;
					}
				}
			}
			if (num < 0)
			{
				return;
			}
			int capacity = count - num;
			List<long> list = new List<long>(capacity);
			List<string> list2 = new List<string>(capacity);
			List<DateTime> list3 = new List<DateTime>(capacity);
			List<byte> list4 = new List<byte>(capacity);
			List<byte> list5 = new List<byte>(capacity);
			List<string> list6 = new List<string>(capacity);
			List<string> list7 = new List<string>(capacity);
			List<(double, double)> list8 = new List<(double, double)>(capacity);
			List<string> list9 = new List<string>(capacity);
			List<LoggedMessage> messageLog = scenario_0.MessageLog;
			for (int j = num; j < count; j++)
			{
				if (messageLog[j] != null)
				{
					list.Add(messageLog[j].Increment);
					list2.Add(messageLog[j].Text);
					list3.Add(messageLog[j].Timestamp);
					list4.Add(messageLog[j].Level);
					list5.Add((byte)messageLog[j].Type);
					list6.Add(messageLog[j].ReporterID);
					if (messageLog[j].Side == null)
					{
						list7.Add("");
					}
					else
					{
						list7.Add(messageLog[j].Side.ObjectID);
					}
					list8.Add(((!messageLog[j].Location.HasValue) ? 0.0 : messageLog[j].Location.Value.Latitude, messageLog[j].Location.HasValue ? messageLog[j].Location.Value.Longitude : 0.0));
					list9.Add(messageLog[j].Summary);
				}
			}
			long_0 = scenario_0.MessageLog.Last().Increment;
			method_87(new MessageLogUpdateMessage
			{
				Increments = list,
				Texts = list2,
				Timestamps = list3,
				Levels = list4,
				Types = list5,
				ReporterIDs = list6,
				SideID = list7,
				Locations = list8,
				Summarys = list9
			}, "SendMessageLogUpdate");
		}
	}

	private void method_36(RealtimeClient realtimeClient_1, AssignToMissionMessage assignToMissionMessage_0)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		Mission theMission = null;
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (!string.IsNullOrEmpty(assignToMissionMessage_0.MissionID))
		{
			theMission = scenario.Sides_ReadOnly.SelectMany((Side F) => F.Missions).FirstOrDefault((Mission F) => F.ObjectID == assignToMissionMessage_0.MissionID);
			if (theMission == null)
			{
				return;
			}
		}
		foreach (string objectID in assignToMissionMessage_0.ObjectIDs)
		{
			if (scenario.ActiveUnits.ContainsKey(objectID))
			{
				ActiveUnit item = scenario.ActiveUnits[objectID];
				list.Add(item);
			}
		}
		bool isEscort = false;
		if (list.Count > 0)
		{
			if (theMission == null)
			{
				if (assignToMissionMessage_0.AssignmentFlags == 1)
				{
					foreach (ActiveUnit item2 in list)
					{
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						item2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					}
				}
			}
			else
			{
				switch ((MissionAssignmentType)assignToMissionMessage_0.AssignmentFlags)
				{
				case MissionAssignmentType.Unassign:
					foreach (ActiveUnit item3 in list)
					{
						CoreClientCode.MissionEditor_RemoveUnitFromMission_Core(item3, theMission);
					}
					break;
				case MissionAssignmentType.MultiMissionUnassign:
					foreach (ActiveUnit item4 in list)
					{
						Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
						if (theMission == item4.ActiveMissionOrPackage())
						{
							item4.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result2);
						}
						else
						{
							item4.UnassignMissionInQueue(theMission);
						}
					}
					break;
				case MissionAssignmentType.AddToMissionQueue:
					foreach (ActiveUnit item5 in list)
					{
						item5.AssignMissionInQueue(theMission);
					}
					break;
				case MissionAssignmentType.RemoveFromMissionQueue:
					foreach (ActiveUnit item6 in list)
					{
						item6.UnassignMissionInQueue(theMission);
					}
					break;
				case MissionAssignmentType.ToggleMultiMission:
					foreach (ActiveUnit item7 in list)
					{
						if (!item7.AllowMultiMission)
						{
							item7.AssignMissionInQueue(item7.ActiveMissionOrPackage());
						}
						else
						{
							item7.UnassignAllMissionInQueue();
						}
						item7.AllowMultiMission = !item7.AllowMultiMission;
					}
					break;
				case MissionAssignmentType.SetEscort:
					isEscort = true;
					CoreClientCode.AssignUnitToMission_Core(list, scenario, ref theMission, ref isEscort);
					break;
				default:
					CoreClientCode.AssignUnitToMission_Core(list, scenario, ref theMission, ref isEscort);
					break;
				}
			}
		}
		if (list.Count > 0)
		{
			method_2(realtimeClient_1, list);
		}
		if (theMission != null)
		{
			SendUpdateMission(theMission, realtimeClient_1.CurrentSide_ObjectID, null);
		}
	}

	private void SendUpdateMission(Mission mission, string sideID, RealtimeClient clientToOpenEditorWindow)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		List<RealtimeClient> list = new List<RealtimeClient>();
		List<RealtimeClient> list2 = new List<RealtimeClient>();
		foreach (RealtimeClient item in list_4)
		{
			if (item.CurrentSide_ObjectID == sideID)
			{
				if (item == clientToOpenEditorWindow)
				{
					list2.Add(item);
				}
				else
				{
					list.Add(item);
				}
			}
		}
		Side sideByID = scenario.GetSideByID(sideID);
		if (list.Count <= 0 && list2.Count <= 0)
		{
			return;
		}
		string text = method_77(mission, scenario, sideByID);
		if (text != null)
		{
			MissionUpdateMessage rtmessage_ = new MissionUpdateMessage
			{
				OpenMissionEditor = false,
				XML = text
			};
			method_88(list, rtmessage_, "SendUpdateMission");
			if (list2.Count > 0)
			{
				MissionUpdateMessage rtmessage_2 = new MissionUpdateMessage
				{
					OpenMissionEditor = true,
					XML = text
				};
				method_88(list2, rtmessage_2, "SendUpdateMission");
			}
		}
	}

	private void method_37(RealtimeClient realtimeClient_1, MissionUpdateMessage missionUpdateMessage_0)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		Scenario scenario = scenario_0;
		if (scenario == null || scenario.Sides_ReadOnly.Count() < 1)
		{
			return;
		}
		try
		{
			if (realtimeClient_1.LoopbackMode)
			{
				realtimeClient_1.Loopback.DisableCommandCoreEventNotifications();
				RealtimeTerminal.ActiveDeserializationCount++;
			}
			XmlNode val = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(missionUpdateMessage_0.XML)));
			ConcurrentDictionary<string, ScenarioObject> dict = new ConcurrentDictionary<string, ScenarioObject>();
			Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
			string innerText = Command_Core.Misc.GetNodeByName(val.ChildNodes, "ID").InnerText;
			Mission mission = MissionHelper.FindMissionByID(sideByID.Missions, innerText);
			if (mission != null)
			{
				List<ActiveUnit> list = null;
				MissionHelper.smethod_0(mission, scenario, sideByID, val, dict);
				if (mission.HasFlightPlans())
				{
					list = MissionHelper.ResyncFlightPlans(scenario, sideByID, mission);
					Waypoint[] array = null;
					float num = 0f;
					float num2 = 0f;
					foreach (Mission.Flight flight in mission.FlightList)
					{
						array = flight.FlightPlan;
						num = 0f;
						num2 = 0f;
						MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(scenario, mission, flight.get_ReferenceUnit(scenario), flight, ref array, ref num, ref num2, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Command_Core.Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission.TakeOffTime, mission.TimeOnTarget, IsMFP: false);
					}
				}
				SendUpdateMission(mission, sideByID.ObjectID, null);
				if (list != null && list.Count > 0)
				{
					method_2(realtimeClient_1, list);
				}
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (realtimeClient_1.LoopbackMode)
		{
			RealtimeTerminal.ActiveDeserializationCount--;
			realtimeClient_1.Loopback.EnableCommandCoreEventNotifications();
		}
	}

	private void method_38(RealtimeClient realtimeClient_1, MissionCreateMessage missionCreateMessage_0)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		try
		{
			if (realtimeClient_1.LoopbackMode)
			{
				realtimeClient_1.Loopback.DisableCommandCoreEventNotifications();
				RealtimeTerminal.ActiveDeserializationCount++;
			}
			XmlNode node = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(missionCreateMessage_0.MissionXML)));
			ConcurrentDictionary<string, ScenarioObject> dict = new ConcurrentDictionary<string, ScenarioObject>();
			Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
			Mission mission = MissionHelper.CreateNewMissionFromXML(scenario, sideByID, node, dict, useGeneratedID: true);
			if (mission != null)
			{
				RealtimeClient clientToOpenEditorWindow = (missionCreateMessage_0.OpenMissionEditor ? realtimeClient_1 : null);
				if (mission.Category == Mission.MissionCategory.Package)
				{
					TaskPool taskPool = CoreClientCode.AddNewPackageToParentPool_Core(mission, sideByID, missionCreateMessage_0.ParentTaskPoolName);
					SendUpdateMission(mission, sideByID.ObjectID, clientToOpenEditorWindow);
					if (taskPool != null)
					{
						SendUpdateMission(taskPool, sideByID.ObjectID, null);
					}
				}
				else
				{
					SendUpdateMission(mission, sideByID.ObjectID, clientToOpenEditorWindow);
				}
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (realtimeClient_1.LoopbackMode)
		{
			RealtimeTerminal.ActiveDeserializationCount--;
			realtimeClient_1.Loopback.EnableCommandCoreEventNotifications();
		}
	}

	public void RemoveMission(RealtimeClient client, MissionRemoveMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null || theScen.Sides_ReadOnly.Length < 1)
		{
			return;
		}
		Side theSide = theScen.GetSideByID(client.CurrentSide_ObjectID);
		if (theSide != null && theSide.Missions.Count >= 1)
		{
			Mission mission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionID);
			if (mission != null)
			{
				mission.DeleteMission(ref theScen, ref theSide);
				method_87(msg, "RemoveMission");
			}
		}
	}

	public void CloneMission(RealtimeClient client, MissionCloneMessage msg)
	{
		Scenario theScen = scenario_0;
		if (theScen == null || theScen.Sides_ReadOnly.Length < 1)
		{
			return;
		}
		Side theSide = theScen.GetSideByID(client.CurrentSide_ObjectID);
		if (theSide == null || theSide.Missions.Count < 1)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionToBeClonedID);
		if (mission != null)
		{
			Mission mission2 = mission.CloneMission(ref theScen, ref theSide);
			if (mission2 != null)
			{
				SendUpdateMission(mission2, theSide.ObjectID, null);
			}
		}
	}

	public void MissionSetSecondaryAirBase(RealtimeClient client, MissionSetSecondaryBaseMessage msg)
	{
		Scenario scenario = scenario_0;
		if (scenario == null || scenario.Sides_ReadOnly.Length < 1)
		{
			return;
		}
		Side sideByID = scenario.GetSideByID(client.CurrentSide_ObjectID);
		if (sideByID == null || sideByID.Missions.Count < 1)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(sideByID.Missions, msg.MissionID);
		if (mission == null)
		{
			return;
		}
		ActiveUnit value = null;
		if (!string.IsNullOrEmpty(msg.SecondaryBaseID))
		{
			scenario.ActiveUnits.TryGetValue(msg.SecondaryBaseID, out value);
			if (value == null)
			{
				return;
			}
		}
		CoreClientCode.MissionSetSecondaryAirBase_Core(mission, scenario, value);
		List<ActiveUnit> list = MissionHelper.ResyncFlightPlans(scenario, sideByID, mission);
		if (list != null && list.Count > 0)
		{
			method_2(client, list);
		}
		SendUpdateMission(mission, sideByID.ObjectID, null);
	}

	public void SendMissionsChangedUpdate()
	{
		Scenario scenario = scenario_0;
		if (scenario == null || scenario.Sides_ReadOnly.Length < 1)
		{
			return;
		}
		Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Mission mission in side.Missions)
			{
				if (mission == null || !mission.MultiplayerUpdateNeeded)
				{
					continue;
				}
				mission.MultiplayerUpdateNeeded = false;
				foreach (RealtimeClient item in list_4)
				{
					if (item.CurrentSide_ObjectID == side.ObjectID || item.Gods_Eye)
					{
						SendUpdateMission(mission, side.ObjectID, null);
						break;
					}
				}
			}
		}
	}

	private void SendPositionUpdate()
	{
		lock (object_1)
		{
			List<IGrouping<string, RealtimeClient>> list = (from F in list_4
				group F by F.CurrentSide_ObjectID into F
				where !string.IsNullOrEmpty(F.Key)
				select F).ToList();
			List<ActiveUnit> list2 = scenario_0.ActiveUnits_List.ToList();
			foreach (IGrouping<string, RealtimeClient> item in list)
			{
				string string_0 = item.Key;
				List<ActiveUnit> list_ = list2.Where((ActiveUnit F) => ((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false).ObjectID == string_0).ToList();
				method_97(item.ToList(), list_);
			}
			List<RealtimeClient> list_2 = list_4.Where((RealtimeClient F) => F.Gods_Eye).ToList();
			method_97(list_2, list2);
		}
	}

	private void method_39(int int_3)
	{
		List<IGrouping<string, RealtimeClient>> list = (from F in list_4
			group F by F.CurrentSide_ObjectID into F
			where !string.IsNullOrEmpty(F.Key)
			select F).ToList();
		List<ActiveUnit> list2 = scenario_0.ActiveUnits_List.Where((ActiveUnit F) => F.CurrentSpeed > 0f).ToList();
		if (list2.Count <= 0)
		{
			return;
		}
		foreach (IGrouping<string, RealtimeClient> item in list)
		{
			string string_0 = item.Key;
			List<ActiveUnit> list_ = list2.Where((ActiveUnit F) => ((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false).ObjectID == string_0).ToList();
			method_98(item.ToList(), list_);
		}
		List<RealtimeClient> list_2 = list_4.Where((RealtimeClient F) => F.Gods_Eye).ToList();
		method_98(list_2, list2);
	}

	private void TeleportUnit(RealtimeClient client, TeleportUnitMessage msg)
	{
		if (scenario_0.ActiveUnits.ContainsKey(msg.ObjectID))
		{
			ActiveUnit activeUnit = scenario_0.ActiveUnits[msg.ObjectID];
			activeUnit.Teleport(ref scenario_0, msg.Longitude, msg.Latitude);
			method_99(list_4, activeUnit);
		}
	}

	private void SendReferencePointUpdate()
	{
		lock (object_1)
		{
			if (!bool_2)
			{
				return;
			}
			foreach (IGrouping<string, RealtimeClient> item in (from F in list_4
				group F by F.CurrentSide_ObjectID into F
				where !string.IsNullOrEmpty(F.Key)
				select F).ToList())
			{
				Side sideByID = scenario_0.GetSideByID(item.Key);
				if (sideByID != null)
				{
					method_100(item.ToList(), new List<Side> { sideByID });
				}
			}
			List<RealtimeClient> list_ = list_4.Where((RealtimeClient F) => F.Gods_Eye).ToList();
			method_100(list_, scenario_0.Sides_ReadOnly.ToList());
		}
	}

	private void ReferencePointUpdate(RealtimeClient client, ReferencePointUpdateMessage msg)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			bool_2 = true;
			int count = msg.SideID.Count;
			ActiveUnit value = null;
			int int_0 = 0;
			while (int_0 < count)
			{
				Side sideByID = scenario_0.GetSideByID(msg.SideID[int_0]);
				int num2;
				if (sideByID != null)
				{
					int count2 = msg.AllObjectID[int_0].Count;
					int int_1;
					for (int_1 = 0; int_1 < count2; int_1 = num2)
					{
						ReferencePoint referencePoint = sideByID.RefPoints.FirstOrDefault((ReferencePoint F) => F.ObjectID == msg.AllObjectID[int_0][int_1]);
						if (referencePoint != null)
						{
							referencePoint.Name = msg.AllName[int_0][int_1];
							referencePoint.Latitude = msg.AllLatitude[int_0][int_1];
							referencePoint.Longitude = msg.AllLongitude[int_0][int_1];
							referencePoint.IsHighlighted = msg.AllIsHighlighted[int_0][int_1];
							if (!string.IsNullOrEmpty(msg.AllRelativeUnitID[int_0][int_1]))
							{
								if (scenario_0.ActiveUnits.TryGetValue(msg.AllRelativeUnitID[int_0][int_1], out value))
								{
									referencePoint.IsRelativeTo = value;
								}
							}
							else
							{
								referencePoint.IsRelativeTo = null;
							}
							referencePoint.RelativeBearing = msg.AllRelativeBearing[int_0][int_1];
							referencePoint.RelativeDistance = msg.AllRelativeDistance[int_0][int_1];
							referencePoint.BearingType = (ReferencePoint.OrientationType)msg.AllBearingType[int_0][int_1];
							referencePoint.IsLocked = msg.AllIsLocked[int_0][int_1];
							referencePoint.TagsByGuid_Raw = msg.AllTagsByGuid_Raw[int_0][int_1].ToHashSet();
							referencePoint.color = Color.FromArgb(msg.AllColor[int_0][int_1]);
							referencePoint.RenderGroup = (ReferencePoint_Group)msg.AllRenderGroup[int_0][int_1];
							long? num = msg.AllCreationDate[int_0][int_1];
							if (num.HasValue)
							{
								referencePoint.CreationDate = new DateTime(num.Value);
							}
							num = msg.AllExpiration[int_0][int_1];
							if (num.HasValue)
							{
								referencePoint.Expiration = new DateTime(num.Value);
							}
							referencePoint.Fades = msg.AllFades[int_0][int_1];
							referencePoint.ForceMinimize = msg.AllForceMinimize[int_0][int_1];
						}
						num2 = int_1 + 1;
					}
				}
				num2 = int_0 + 1;
				int_0 = num2;
			}
			method_87(msg, "ReferencePointUpdate");
		}
	}

	private void method_40(RealtimeClient realtimeClient_1, CreateReferencePointMessage createReferencePointMessage_0)
	{
		lock (object_1)
		{
			if (hostState_0 != HostState.AC)
			{
				Side sideByID = scenario_0.GetSideByID(createReferencePointMessage_0.SideID);
				if (sideByID != null)
				{
					ReferencePoint item = new ReferencePoint
					{
						Longitude = createReferencePointMessage_0.Lon,
						Latitude = createReferencePointMessage_0.Lat,
						Name = $"{realtimeClient_1.Name}-{++realtimeClient_1.AutoIncrement}",
						IsHighlighted = true
					};
					sideByID.RefPoints.Add(item);
					bool_2 = true;
				}
			}
		}
	}

	private void method_41(RealtimeClient realtimeClient_1, CreateMultipleReferencePointMessage createMultipleReferencePointMessage_0)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			Side sideByID = scenario_0.GetSideByID(createMultipleReferencePointMessage_0.SideID);
			if (sideByID != null)
			{
				int count = createMultipleReferencePointMessage_0.Lats.Count;
				List<ReferencePoint> list = new List<ReferencePoint>();
				for (int i = 0; i < count; i++)
				{
					ReferencePoint item = new ReferencePoint
					{
						Longitude = createMultipleReferencePointMessage_0.Lons[i],
						Latitude = createMultipleReferencePointMessage_0.Lats[i],
						Name = $"{realtimeClient_1.Name}-{++realtimeClient_1.AutoIncrement}",
						IsHighlighted = true
					};
					list.Add(item);
				}
				sideByID.RefPoints.AddRange(list);
				bool_2 = true;
			}
		}
	}

	private void DeleteReferencePoint(RealtimeClient client, DeleteReferencePointMessage msg)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			Side sideByID = scenario_0.GetSideByID(msg.SideID);
			if (sideByID == null)
			{
				return;
			}
			bool_2 = true;
			for (int i = 0; i < msg.RPIDs.Count; i++)
			{
				int num = sideByID.RefPoints.Count - 1;
				while (num >= 0)
				{
					if (!(sideByID.RefPoints[num].ObjectID == msg.RPIDs[i]))
					{
						num--;
						continue;
					}
					sideByID.RefPoints.RemoveAt(num);
					break;
				}
			}
			method_87(new DeleteReferencePointMessage
			{
				SideID = msg.SideID,
				RPIDs = msg.RPIDs
			}, "DeleteReferencePoint");
		}
	}

	private void method_42(RealtimeClient realtimeClient_1, ActiveUnitResupplyActionMessage activeUnitResupplyActionMessage_0)
	{
		Scenario scenario = scenario_0;
		Side sideByID = scenario_0.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		ActiveUnit value = null;
		foreach (string objectID in activeUnitResupplyActionMessage_0.ObjectIDs)
		{
			if (scenario.ActiveUnits.TryGetValue(objectID, out value))
			{
				list.Add(value);
			}
		}
		if (!list.Any())
		{
			return;
		}
		Dictionary<int, Weapon> dictionary = null;
		ActiveUnit value2 = null;
		string Results = "";
		string ResultCategory = "";
		if (activeUnitResupplyActionMessage_0.WeaponID > 0)
		{
			Module_Unit.Unit unit = list.Where((Module_Unit.Unit U) => U.IsActiveUnit).FirstOrDefault();
			if (unit != null)
			{
				PooledDictionary<int, Weapon> pooledDictionary = ((ActiveUnit)unit).Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
				if (pooledDictionary.Keys.Contains(activeUnitResupplyActionMessage_0.WeaponID))
				{
					dictionary = new Dictionary<int, Weapon>();
					dictionary.Add(activeUnitResupplyActionMessage_0.WeaponID, pooledDictionary[activeUnitResupplyActionMessage_0.WeaponID]);
				}
				pooledDictionary.Dispose();
			}
		}
		switch ((ActiveUnitResupplyAction)activeUnitResupplyActionMessage_0.Action)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case ActiveUnitResupplyAction.RefuelAuto:
			CoreClientCode.RefuelIfPossible_Core(scenario, list, (ActiveUnit)null, (List<Mission>)null, ref Results, ref ResultCategory);
			break;
		case ActiveUnitResupplyAction.RefuelTarget:
			if (scenario.ActiveUnits.TryGetValue(activeUnitResupplyActionMessage_0.TargetID, out value2))
			{
				CoreClientCode.RefuelIfPossible_Core(scenario, list, value2, (List<Mission>)null, ref Results, ref ResultCategory);
			}
			break;
		case ActiveUnitResupplyAction.RefuelMission:
		{
			foreach (Mission mission in sideByID.Missions)
			{
				if (mission.ObjectID == activeUnitResupplyActionMessage_0.TargetID)
				{
					CoreClientCode.RefuelIfPossible_Core(scenario, list, null, mission, ref Results, ref ResultCategory);
					break;
				}
			}
			break;
		}
		case ActiveUnitResupplyAction.RearmAuto:
			CoreClientCode.RearmIfPossible_Core(scenario, list, null, dictionary, ref Results, ref ResultCategory);
			break;
		case ActiveUnitResupplyAction.RearmTarget:
			if (scenario.ActiveUnits.TryGetValue(activeUnitResupplyActionMessage_0.TargetID, out value2))
			{
				CoreClientCode.RearmIfPossible_Core(scenario, list, value2, dictionary, ref Results, ref ResultCategory);
			}
			break;
		}
	}

	public void OnHostPlatformComponentStatusChange(PlatformComponent theComponent)
	{
		if (theComponent != null && theComponent.IsSensor)
		{
			Sensor sensor = (Sensor)theComponent;
			SensorUpdateMessage.SensorUpdateRecord item = default(SensorUpdateMessage.SensorUpdateRecord);
			item.unitID = sensor.ParentPlatform?.ObjectID;
			item.sensorID = sensor.ObjectID;
			item.activated = sensor.IsActive();
			if (sensor.IsSensorInLoadout)
			{
				item.poddedSensorDBID = sensor.DBID;
			}
			else
			{
				item.poddedSensorDBID = 0;
			}
			concurrentStack_0.Push(item);
		}
	}

	public void SendSensorUpdates()
	{
		if (concurrentStack_0.Count != 0)
		{
			lock (object_1)
			{
				method_87(new SensorUpdateMessage
				{
					SensorUpdates = concurrentStack_0.ToList()
				}, "SendSensorUpdates");
				concurrentStack_0.Clear();
			}
		}
	}

	public void SensorEMCONUpdate(RealtimeClient client, SensorEMCONUpdateMessage msg)
	{
		ActiveUnit value = null;
		Scenario scenario = scenario_0;
		if (scenario != null && scenario.ActiveUnits.TryGetValue(msg.unitID, out value))
		{
			if (value.Sensory.ObeysEMCON != msg.obeyEMCON)
			{
				value.Sensory.ObeysEMCON = msg.obeyEMCON;
			}
			switch ((SensorEMCONUpdateMessage.EMCON_Inherit_Change)msg.changeEMCONInheritance)
			{
			case SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_YES:
				value.Doctrine.EMCON_Inherits = true;
				break;
			case SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_NO:
				value.Doctrine.EMCON_Inherits = false;
				break;
			case SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_NOCHANGE:
				break;
			}
		}
	}

	public void SensorActivation(RealtimeClient client, SensorUpdateMessage msg)
	{
		ActiveUnit value = null;
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		SensorUpdateMessage.SensorUpdateRecord item = default(SensorUpdateMessage.SensorUpdateRecord);
		foreach (SensorUpdateMessage.SensorUpdateRecord sensorUpdate in msg.SensorUpdates)
		{
			if (value == null || value.ObjectID != sensorUpdate.unitID)
			{
				scenario.ActiveUnits.TryGetValue(sensorUpdate.unitID, out value);
			}
			if (value == null)
			{
				continue;
			}
			List<Sensor> list = new List<Sensor>();
			list.AddRange(value.Sensors_Cached);
			list.AddRange(value.MineCountermeasures);
			foreach (Sensor item2 in list)
			{
				if (!(sensorUpdate.sensorID == item2.ObjectID) && (sensorUpdate.poddedSensorDBID == 0 || !item2.IsSensorInLoadout || sensorUpdate.poddedSensorDBID != item2.DBID))
				{
					continue;
				}
				if (!sensorUpdate.activated)
				{
					item2.GoPassive();
				}
				else
				{
					if (value.Sensory.ObeysEMCON && !item2.IsMineCountermeasure)
					{
						value.Sensory.ObeysEMCON = false;
					}
					item2.GoActive();
				}
				if (hostState_0 == HostState.Paused)
				{
					item.unitID = item2.ParentPlatform?.ObjectID;
					item.sensorID = item2.ObjectID;
					item.activated = item2.IsActive();
					if (!item2.IsSensorInLoadout)
					{
						item.poddedSensorDBID = 0;
					}
					else
					{
						item.poddedSensorDBID = item2.DBID;
					}
					concurrentStack_0.Push(item);
				}
				break;
			}
		}
	}

	public void IntermittentEmissionUpdate(RealtimeClient client, SensorIntermittentEmissionUpdateMessage msg)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		Scenario scenario = scenario_0;
		if (scenario == null || string.IsNullOrEmpty(msg.unitID))
		{
			return;
		}
		ActiveUnit value = null;
		if (scenario.ActiveUnits.TryGetValue(msg.unitID, out value))
		{
			if (string.IsNullOrEmpty(msg.XML))
			{
				value.Sensory.IntermittentEmission = null;
				return;
			}
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(msg.XML)));
			value.Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode);
			value.Sensory.IntermittentEmission?.Initialize(value.Sensory);
		}
	}

	public List<RealtimeClient> GetAllClientsOnSide(string sideID)
	{
		List<RealtimeClient> list = new List<RealtimeClient>();
		foreach (RealtimeClient item in list_4)
		{
			if (item.CurrentSide_ObjectID == sideID)
			{
				list.Add(item);
			}
		}
		return list;
	}

	private void method_43(RealtimeClient realtimeClient_1, SidePosturesUpdateMessage sidePosturesUpdateMessage_0)
	{
		Scenario scenario = scenario_0;
		if (scenario == null)
		{
			return;
		}
		Side sideByID = scenario.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID == null)
		{
			return;
		}
		Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
		foreach (KeyValuePair<string, int> posture in sidePosturesUpdateMessage_0.Postures)
		{
			if (posture.Key == sideByID.ObjectID)
			{
				continue;
			}
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (side.ObjectID == posture.Key)
				{
					sideByID.set_ConsidersThisSideToBe(side, (Scenario)null, (Command_Core.Misc.PostureStance)posture.Value);
					break;
				}
			}
		}
		SendSidePostureUpdate(sideByID, sideByID.Postures_ReadOnly.ToList());
	}

	private void SendSidePostureUpdate(Side clientSide, List<KeyValuePair<Side, Command_Core.Misc.PostureStance>> Postures)
	{
		List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(clientSide.ObjectID);
		if (allClientsOnSide.Count <= 0)
		{
			return;
		}
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		foreach (KeyValuePair<Side, Command_Core.Misc.PostureStance> Posture in Postures)
		{
			list.Add(new KeyValuePair<string, int>(Posture.Key.ObjectID, (int)Posture.Value));
		}
		method_88(allClientsOnSide, new SidePosturesUpdateMessage
		{
			SideID = clientSide.ObjectID,
			Postures = list
		}, "SendSidePostureUpdate");
	}

	private void SendSideUpdate(Side clientSide, Side updateSide)
	{
		List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(clientSide.ObjectID);
		if (allClientsOnSide.Count > 0)
		{
			string text = method_78(updateSide, scenario_0);
			if (text != null)
			{
				method_88(allClientsOnSide, new SideUpdateMessage
				{
					XML = text
				}, "SendSideUpdate");
			}
		}
	}

	private void method_44(RealtimeClient realtimeClient_1, SideAlertnessUpdateMessage sideAlertnessUpdateMessage_0)
	{
		Scenario scenario = scenario_0;
		if (scenario == null || string.IsNullOrEmpty(sideAlertnessUpdateMessage_0.SideID))
		{
			return;
		}
		Side sideByID = scenario.GetSideByID(sideAlertnessUpdateMessage_0.SideID);
		if (sideByID != null)
		{
			sideByID.EmconAlertness.Level = (Alertlevels)sideAlertnessUpdateMessage_0.AlertnessLevel;
			List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(sideAlertnessUpdateMessage_0.SideID);
			if (allClientsOnSide != null && allClientsOnSide.Count > 1)
			{
				allClientsOnSide.Remove(realtimeClient_1);
				method_88(allClientsOnSide, sideAlertnessUpdateMessage_0, "SideAlertnessUpdateMessage");
			}
		}
	}

	public void SideMapPing(RealtimeClient client, SideMapPingMessage msg)
	{
		List<RealtimeClient> allClientsOnSide = GetAllClientsOnSide(client.CurrentSide_ObjectID);
		if (allClientsOnSide.Count > 0)
		{
			Side sideByID = scenario_0.GetSideByID(client.CurrentSide_ObjectID);
			if (sideByID != null)
			{
				scenario_0.AddMessage("Attention to Location!", "Player " + client.Name + " requests attention at a location.", LoggedMessage.MessageType.EventEngine, 0, client.Name, sideByID, new Geopoint_Struct(msg.Longitude, msg.Latitude));
			}
			msg.SourceName = client.Name;
			method_88(allClientsOnSide, msg, "SideMapPingMessage");
		}
	}

	public void SpecialActionExecute(RealtimeClient client, SpecialActionMessage msg)
	{
		Scenario scenario = scenario_0;
		msg.Result = "";
		if (scenario != null)
		{
			Side side = null;
			Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (side2.ObjectID == client.CurrentSide_ObjectID)
				{
					side = side2;
					break;
				}
			}
			if (side != null)
			{
				SpecialAction value = null;
				if (side.SpecialActions.TryGetValue(msg.ActionID, out value) && value != null)
				{
					Side currentSide = scenario.GetCurrentSide();
					scenario.SetCurrentSide(side);
					ReadOnlyCollection<Module_Unit.Unit> selectedUnits = side.SelectedUnits;
					side.SelectedUnits_Clear();
					if (msg.SelectedUnitIDs != null)
					{
						foreach (string selectedUnitID in msg.SelectedUnitIDs)
						{
							ActiveUnit value2 = null;
							if (scenario.ActiveUnits.TryGetValue(selectedUnitID, out value2))
							{
								side.SelectedUnits_Add(value2);
							}
						}
					}
					msg.Result = value.Execute(scenario);
					side.SelectedUnits_Clear();
					if (selectedUnits != null)
					{
						foreach (Module_Unit.Unit item in selectedUnits)
						{
							side.SelectedUnits_Add(item);
						}
					}
					scenario.SetCurrentSide(currentSide);
				}
			}
		}
		method_89(client, msg, "SpecialActionExecute");
	}

	private void method_45(Waypoint waypoint_0, Scenario scenario_1, ActiveUnit activeUnit_0, ThrottleAltUIMessage throttleAltUIMessage_0)
	{
		if (waypoint_0 != null)
		{
			if (throttleAltUIMessage_0.DesiredThrottlePreset.HasValue)
			{
				CoreClientCode.SetWaypointThrottlePreset_Core(waypoint_0, (ActiveUnit_Kinematics.UnitThrottlePreset)throttleAltUIMessage_0.DesiredThrottlePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitudePreset.HasValue)
			{
				CoreClientCode.SetWaypointAltitudePreset_Core(waypoint_0, activeUnit_0, (ActiveUnit_AI.AircraftAltitudePreset)throttleAltUIMessage_0.DesiredAltitudePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepthPreset.HasValue)
			{
				CoreClientCode.SetWaypointDepthPreset_Core(waypoint_0, scenario_1, activeUnit_0, (ActiveUnit_AI.SubmarineDepthPreset)throttleAltUIMessage_0.DesiredDepthPreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredSpeed.HasValue)
			{
				CoreClientCode.SetWaypointDesiredSpeed_Core(waypoint_0, throttleAltUIMessage_0.DesiredSpeed.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitude.HasValue)
			{
				CoreClientCode.SetWaypointDesiredAltitude_Core(waypoint_0, throttleAltUIMessage_0.DesiredAltitude.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepth.HasValue)
			{
				CoreClientCode.SetWaypointDesiredAltitude_Core(waypoint_0, throttleAltUIMessage_0.DesiredDepth.Value);
			}
			if (throttleAltUIMessage_0.SpeedOverride.HasValue)
			{
				CoreClientCode.SetWaypointSpeedOverride_Core(waypoint_0, throttleAltUIMessage_0.SpeedOverride.Value);
			}
			if (throttleAltUIMessage_0.AltitudeOverride.HasValue)
			{
				CoreClientCode.SetWaypointAltitudeOverride_Core(waypoint_0, throttleAltUIMessage_0.AltitudeOverride.Value);
			}
			if (throttleAltUIMessage_0.SprintDrift.HasValue)
			{
				CoreClientCode.SetWaypointSprintDrift_Core(waypoint_0, throttleAltUIMessage_0.SprintDrift.Value);
			}
			if (throttleAltUIMessage_0.AvoidCavitation.HasValue)
			{
				CoreClientCode.SetWaypointAvoidCavitation_Core(waypoint_0, throttleAltUIMessage_0.AvoidCavitation.Value);
			}
			if (throttleAltUIMessage_0.TerrainFollowing.HasValue)
			{
				CoreClientCode.SetWaypointTerrainFollowing_Core(waypoint_0, throttleAltUIMessage_0.TerrainFollowing.Value);
			}
			if (throttleAltUIMessage_0.LandcoverMasking.HasValue)
			{
				CoreClientCode.SetWaypointTerrainFollowingMode_Core(waypoint_0, (ActiveUnit.TerrainFollowMode)throttleAltUIMessage_0.LandcoverMasking.Value);
			}
			if (throttleAltUIMessage_0.ClearSpeedSettings.HasValue)
			{
				CoreClientCode.ClearWaypointDesiredSpeed_Core(waypoint_0);
			}
			if (throttleAltUIMessage_0.ClearAltitudeSettings.HasValue)
			{
				CoreClientCode.ClearWaypointDesiredAltitude_Core(waypoint_0);
			}
		}
	}

	private void method_46(Waypoint waypoint_0, Scenario scenario_1, Mission.Flight flight_0, ActiveUnit activeUnit_0, ThrottleAltUIMessage throttleAltUIMessage_0)
	{
		if (waypoint_0 != null)
		{
			if (throttleAltUIMessage_0.DesiredThrottlePreset.HasValue)
			{
				CoreClientCode.SetFlightplanWaypointThrottlePreset_Core(waypoint_0, scenario_1, flight_0, (ActiveUnit_Kinematics.UnitThrottlePreset)throttleAltUIMessage_0.DesiredThrottlePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitudePreset.HasValue)
			{
				CoreClientCode.SetFlightplanWaypointAltitudePreset_Core(waypoint_0, (ActiveUnit_AI.AircraftAltitudePreset)throttleAltUIMessage_0.DesiredAltitudePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepthPreset.HasValue)
			{
				CoreClientCode.SetFlightplanWaypointDepthPreset_Core(waypoint_0, scenario_1, (ActiveUnit_AI.SubmarineDepthPreset)throttleAltUIMessage_0.DesiredDepthPreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredSpeed.HasValue)
			{
				CoreClientCode.SetFlightplanWaypointDesiredSpeed_Core(waypoint_0, scenario_1, flight_0, throttleAltUIMessage_0.DesiredSpeed.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitude.HasValue)
			{
				CoreClientCode.SetWaypointDesiredAltitude_Core(waypoint_0, throttleAltUIMessage_0.DesiredAltitude.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepth.HasValue)
			{
				CoreClientCode.SetWaypointDesiredAltitude_Core(waypoint_0, throttleAltUIMessage_0.DesiredDepth.Value);
			}
			if (throttleAltUIMessage_0.SpeedOverride.HasValue)
			{
				CoreClientCode.SetFlightplanWaypointSpeedOverride_Core(waypoint_0, scenario_1, flight_0, throttleAltUIMessage_0.SpeedOverride.Value);
			}
			if (throttleAltUIMessage_0.AltitudeOverride.HasValue)
			{
				CoreClientCode.SetWaypointAltitudeOverride_Core(waypoint_0, throttleAltUIMessage_0.AltitudeOverride.Value);
			}
			if (throttleAltUIMessage_0.SprintDrift.HasValue)
			{
				CoreClientCode.SetWaypointSprintDrift_Core(waypoint_0, throttleAltUIMessage_0.SprintDrift.Value);
			}
			if (throttleAltUIMessage_0.AvoidCavitation.HasValue)
			{
				CoreClientCode.SetWaypointAvoidCavitation_Core(waypoint_0, throttleAltUIMessage_0.AvoidCavitation.Value);
			}
			if (throttleAltUIMessage_0.TerrainFollowing.HasValue)
			{
				CoreClientCode.SetWaypointTerrainFollowing_Core(waypoint_0, throttleAltUIMessage_0.TerrainFollowing.Value);
			}
			if (throttleAltUIMessage_0.LandcoverMasking.HasValue)
			{
				CoreClientCode.SetWaypointTerrainFollowingMode_Core(waypoint_0, (ActiveUnit.TerrainFollowMode)throttleAltUIMessage_0.LandcoverMasking.Value);
			}
			if (throttleAltUIMessage_0.ClearSpeedSettings.HasValue)
			{
				CoreClientCode.ClearWaypointDesiredSpeed_Core(waypoint_0);
			}
			if (throttleAltUIMessage_0.ClearAltitudeSettings.HasValue)
			{
				CoreClientCode.ClearWaypointDesiredAltitude_Core(waypoint_0);
			}
		}
	}

	private void method_47(ActiveUnit activeUnit_0, Scenario scenario_1, ThrottleAltUIMessage throttleAltUIMessage_0)
	{
		if (activeUnit_0 != null)
		{
			if (throttleAltUIMessage_0.DesiredThrottlePreset.HasValue)
			{
				CoreClientCode.SetUnitThrottlePreset_Core(activeUnit_0, (ActiveUnit_Kinematics.UnitThrottlePreset)throttleAltUIMessage_0.DesiredThrottlePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitudePreset.HasValue)
			{
				CoreClientCode.SetUnitAltitudePreset_Core(activeUnit_0, (ActiveUnit_AI.AircraftAltitudePreset)throttleAltUIMessage_0.DesiredAltitudePreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepthPreset.HasValue)
			{
				CoreClientCode.SetUnitDepthPreset_Core(activeUnit_0, (ActiveUnit_AI.SubmarineDepthPreset)throttleAltUIMessage_0.DesiredDepthPreset.Value);
			}
			if (throttleAltUIMessage_0.DesiredSpeed.HasValue)
			{
				CoreClientCode.SetUnitDesiredSpeed_Core(activeUnit_0, throttleAltUIMessage_0.DesiredSpeed.Value);
			}
			if (throttleAltUIMessage_0.DesiredAltitude.HasValue)
			{
				CoreClientCode.SetUnitDesiredAltitude_Core(activeUnit_0, throttleAltUIMessage_0.DesiredAltitude.Value);
			}
			if (throttleAltUIMessage_0.DesiredDepth.HasValue)
			{
				CoreClientCode.SetUnitDesiredAltitude_Core(activeUnit_0, throttleAltUIMessage_0.DesiredDepth.Value);
			}
			if (throttleAltUIMessage_0.SpeedOverride.HasValue)
			{
				CoreClientCode.SetUnitSpeedOverride_Core(activeUnit_0, throttleAltUIMessage_0.SpeedOverride.Value);
			}
			if (throttleAltUIMessage_0.AltitudeOverride.HasValue)
			{
				CoreClientCode.SetUnitAltitudeOverride_Core(activeUnit_0, throttleAltUIMessage_0.AltitudeOverride.Value);
			}
			if (throttleAltUIMessage_0.SprintDrift.HasValue)
			{
				CoreClientCode.SetUnitSprintDrift_Core(activeUnit_0, throttleAltUIMessage_0.SprintDrift.Value);
			}
			if (throttleAltUIMessage_0.AvoidCavitation.HasValue)
			{
				CoreClientCode.SetUnitAvoidCavitation_Core(activeUnit_0, throttleAltUIMessage_0.AvoidCavitation.Value);
			}
			if (throttleAltUIMessage_0.TerrainFollowing.HasValue)
			{
				CoreClientCode.SetUnitTerrainFollowing_Core(activeUnit_0, throttleAltUIMessage_0.TerrainFollowing.Value);
			}
			if (throttleAltUIMessage_0.LandcoverMasking.HasValue)
			{
				CoreClientCode.SetUnitTerrainFollowingMode_Core(activeUnit_0, (ActiveUnit.TerrainFollowMode)throttleAltUIMessage_0.LandcoverMasking.Value);
			}
		}
	}

	private Waypoint method_48(Mission mission_0, string string_3, string string_4, ref Mission.Flight flight_0)
	{
		Waypoint waypoint = null;
		if (mission_0 != null && !string.IsNullOrEmpty(string_3) && !string.IsNullOrEmpty(string_4))
		{
			foreach (Mission.Flight flight in mission_0.FlightList)
			{
				if (!flight.ObjectID.Equals(string_3))
				{
					continue;
				}
				Waypoint[] flightPlan = flight.FlightPlan;
				foreach (Waypoint waypoint2 in flightPlan)
				{
					if (!waypoint2.ObjectID.Equals(string_4))
					{
						if (waypoint2.Waypoint_LeadElementWingman != null && waypoint2.Waypoint_LeadElementWingman.ObjectID.Equals(string_4))
						{
							waypoint = waypoint2.Waypoint_LeadElementWingman;
						}
						else if (waypoint2.Waypoint_SecondElement != null && waypoint2.Waypoint_SecondElement.ObjectID.Equals(string_4))
						{
							waypoint = waypoint2.Waypoint_SecondElement;
						}
						else if (waypoint2.Waypoint_SecondElementWingman != null && waypoint2.Waypoint_SecondElementWingman.ObjectID.Equals(string_4))
						{
							waypoint = waypoint2.Waypoint_SecondElementWingman;
						}
						else if (waypoint2.Waypoint_ThirdElement != null && waypoint2.Waypoint_ThirdElement.ObjectID.Equals(string_4))
						{
							waypoint = waypoint2.Waypoint_ThirdElement;
						}
						else if (waypoint2.Waypoint_ThirdElementWingman != null && waypoint2.Waypoint_ThirdElementWingman.ObjectID.Equals(string_4))
						{
							waypoint = waypoint2.Waypoint_ThirdElementWingman;
						}
					}
					else
					{
						waypoint = waypoint2;
					}
					if (waypoint != null)
					{
						if (flight_0 != null)
						{
							flight_0 = flight;
						}
						break;
					}
				}
			}
		}
		return waypoint;
	}

	private Waypoint method_49(ActiveUnit activeUnit_0, Side side_0, string string_3, string string_4, ref Mission.Flight flight_0)
	{
		Waypoint waypoint = null;
		if (!string.IsNullOrEmpty(string_3))
		{
			if (activeUnit_0 != null)
			{
				waypoint = Array.Find(activeUnit_0.Navigator.PlottedCourse, (Waypoint element) => element.ObjectID.Equals(string_3));
				if (waypoint == null && !string.IsNullOrEmpty(string_4))
				{
					waypoint = method_48(activeUnit_0.ActiveMissionOrPackage(), string_4, string_3, ref flight_0);
				}
			}
			else if (string.IsNullOrEmpty(string_4))
			{
				foreach (ActiveUnit unit in side_0.Units)
				{
					waypoint = Array.Find(unit.Navigator.PlottedCourse, (Waypoint element) => element.ObjectID.Equals(string_3));
					if (waypoint != null)
					{
						break;
					}
				}
			}
			else
			{
				foreach (Mission mission in side_0.Missions)
				{
					waypoint = method_48(mission, string_4, string_3, ref flight_0);
					if (waypoint != null)
					{
						break;
					}
				}
			}
		}
		return waypoint;
	}

	public void ThrottleAltUI(RealtimeClient client, ThrottleAltUIMessage msg)
	{
		Scenario scenario = scenario_0;
		Side sideByID = scenario.GetSideByID(client.CurrentSide_ObjectID);
		if (sideByID == null)
		{
			return;
		}
		Mission.Flight flight_ = null;
		ActiveUnit value = null;
		if (!scenario_0.ActiveUnits.TryGetValue(msg.ActiveUnitID, out value))
		{
			return;
		}
		if (string.IsNullOrEmpty(msg.WaypointID))
		{
			method_47(value, scenario, msg);
			return;
		}
		Waypoint waypoint = method_49(value, sideByID, msg.WaypointID, msg.FlightID, ref flight_);
		if (waypoint != null)
		{
			if (waypoint.Category == Waypoint.WaypointCategory.FlightPlan)
			{
				method_46(waypoint, scenario, flight_, value, msg);
			}
			else
			{
				method_45(waypoint, scenario, value, msg);
			}
		}
	}

	public void SendNewUnguidedWeapons()
	{
		List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
		if (list.Count > 0)
		{
			List<UnguidedWeapon> list2 = list.Except(list_1).ToList();
			UnguidedWeapon unguidedWeapon = null;
			list_2 = new List<string>();
			foreach (UnguidedWeapon item in list2)
			{
				if (unguidedWeapon == null)
				{
					unguidedWeapon = item;
					list_2.Clear();
				}
				else if (!unguidedWeapon.HasIdenticalState(item))
				{
					SendNewUnguidedWeaponToAll(unguidedWeapon, list_2);
					unguidedWeapon = null;
				}
				else
				{
					list_2.Add(item.ObjectID);
				}
			}
			if (unguidedWeapon != null)
			{
				SendNewUnguidedWeaponToAll(unguidedWeapon, list_2);
			}
		}
		if (list_1.Count > 0)
		{
			List<UnguidedWeapon> list3 = list_1.Except(list).ToList();
			if (list3.Count > 0)
			{
				list_2 = list3.Select((UnguidedWeapon W) => W.ObjectID).ToList();
				SendRemoveUnguidedWeaponsToAll(list_2);
			}
		}
		list_1 = new List<UnguidedWeapon>(list);
	}

	public void SendNewUnguidedWeaponToAll(UnguidedWeapon newWeapon, List<string> list_6)
	{
		if (newWeapon == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		string text = method_81(newWeapon);
		if (text != null)
		{
			method_87(new NewUnguidedWeaponMessage
			{
				ObjectIDs = list_6,
				XML = text
			}, "SendNewUnguidedWeaponToAll");
		}
	}

	public void SendRemoveUnguidedWeaponsToAll(List<string> list_6)
	{
		method_87(new RemoveUnguidedWeaponsMessage
		{
			ObjectIDs = list_6
		}, "SendRemoveUnguidedWeaponsToAll");
	}

	public void OnHostScenWaterSplashAdded(object sender, ObservableListModified<WaterSplash> e)
	{
		foreach (WaterSplash item in e.Items)
		{
			SendNewWaterSplashToAll(item);
		}
	}

	public void SendNewWaterSplashToAll(WaterSplash waterSplash)
	{
		if (waterSplash != null)
		{
			string text = method_74(waterSplash);
			if (text != null)
			{
				method_87(new NewWaterSplashMessage
				{
					XML = text
				}, "SendNewWaterSplashToAll");
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void SendClientIndividualWaypointUpdate(RealtimeClient client, Module_Unit.Unit unit, Waypoint waypoint)
	{
		if (unit == null || waypoint == null)
		{
			return;
		}
		lock (object_1)
		{
			string text = method_79(waypoint);
			if (text != null)
			{
				method_89(client, new WaypointUpdateMessage
				{
					UnitID = unit.ObjectID,
					XML = text
				}, "SendClientIndividualWaypointUpdate");
			}
		}
	}

	public void SendSelectedWaypointUpdate(RealtimeClient client)
	{
		lock (object_1)
		{
			if (string.IsNullOrEmpty(client.SelectedUnit_ObjectID) || string.IsNullOrEmpty(client.SelectedWaypoint_ObjectID) || !scenario_0.ActiveUnits.ContainsKey(client.SelectedUnit_ObjectID))
			{
				return;
			}
			ActiveUnit activeUnit = scenario_0.ActiveUnits[client.SelectedUnit_ObjectID];
			bool flag = false;
			Waypoint[] plottedCourse = activeUnit.Navigator.PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				if (waypoint.ObjectID == client.SelectedWaypoint_ObjectID)
				{
					SendClientIndividualWaypointUpdate(client, activeUnit, waypoint);
					flag = true;
					break;
				}
			}
			if (flag || !activeUnit.Navigator.HasFlightPlan)
			{
				return;
			}
			plottedCourse = activeUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
			int i = 0;
			Waypoint waypoint2;
			while (true)
			{
				if (i < plottedCourse.Length)
				{
					waypoint2 = plottedCourse[i];
					if (waypoint2.ObjectID == client.SelectedWaypoint_ObjectID)
					{
						break;
					}
					i++;
					continue;
				}
				return;
			}
			SendClientIndividualWaypointUpdate(client, activeUnit, waypoint2);
			flag = true;
		}
	}

	private void method_50(RealtimeClient realtimeClient_1, WaypointUpdateMessage waypointUpdateMessage_0)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Scenario theScen = scenario_0;
		if (theScen == null)
		{
			return;
		}
		Side sideByID = theScen.GetSideByID(realtimeClient_1.CurrentSide_ObjectID);
		if (sideByID == null)
		{
			return;
		}
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(waypointUpdateMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		string innerText = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
		if (!string.IsNullOrEmpty(innerText))
		{
			Waypoint waypoint = MissionHelper.FindFlightPlanWaypointByID(theScen, sideByID, innerText);
			if (waypoint != null)
			{
				Waypoint.FromXML(ref theNode, ref theDictionary, theScen, waypoint);
				waypoint.PostDeserializationHousekeeping(ref theScen, sideByID, GameIsRunning: true);
				Module_Unit.Unit unit = MissionHelper.FindUnitUsingThisFlightPlanWaypoint(theScen, sideByID, waypoint.ObjectID);
				SendClientIndividualWaypointUpdate(realtimeClient_1, unit, waypoint);
			}
		}
	}

	private void method_51(RealtimeClient realtimeClient_1, WaypointSensorMessage waypointSensorMessage_0)
	{
		if (string.IsNullOrEmpty(realtimeClient_1.CurrentSide_ObjectID))
		{
			return;
		}
		Scenario scenario = scenario_0;
		List<ActiveUnit> value = null;
		ActiveUnit activeUnit = null;
		Waypoint waypoint = null;
		if (!concurrentDictionary_0.TryGetValue(realtimeClient_1.CurrentSide_ObjectID, out value))
		{
			return;
		}
		activeUnit = value.Find((ActiveUnit F) => F.ObjectID == waypointSensorMessage_0.UnitID);
		if (activeUnit == null)
		{
			return;
		}
		waypoint = Array.Find(activeUnit.Navigator.PlottedCourse, (Waypoint F) => F.ObjectID == waypointSensorMessage_0.WaypointID);
		if (waypoint == null && activeUnit.Navigator.HasFlightPlan)
		{
			waypoint = Array.Find(activeUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan, (Waypoint F) => F.ObjectID == waypointSensorMessage_0.WaypointID);
		}
		if (waypoint != null)
		{
			WaypointSensorMessage.SensorType eMCON_SensorType = (WaypointSensorMessage.SensorType)waypointSensorMessage_0.EMCON_SensorType;
			Doctrine.EMCONSettings._EMCONSetting newValue = (Doctrine.EMCONSettings._EMCONSetting)waypointSensorMessage_0.EMCON_Setting;
			waypoint.GetDoctrine(scenario).EMCON_Inherits = waypointSensorMessage_0.EMCON_Inherit;
			switch (eMCON_SensorType)
			{
			case WaypointSensorMessage.SensorType.Radar:
				waypoint.GetDoctrine(scenario).SetEMCON_Radar(newValue, scenario);
				break;
			case WaypointSensorMessage.SensorType.Sonar:
				waypoint.GetDoctrine(scenario).SetEMCON_Sonar(newValue, scenario);
				break;
			case WaypointSensorMessage.SensorType.OECM:
				waypoint.GetDoctrine(scenario).SetEMCON_OECM(newValue, scenario);
				break;
			}
			SendClientIndividualWaypointUpdate(realtimeClient_1, activeUnit, waypoint);
		}
	}

	public void OnHostScenWeaponImpactAdded(object sender, ObservableListModified<WeaponImpact> e)
	{
		foreach (WeaponImpact item in e.Items)
		{
			SendNewWeaponImpactToAll(item);
		}
	}

	public void SendNewWeaponImpactToAll(WeaponImpact weaponImpact)
	{
		if (weaponImpact == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		string text = method_74(weaponImpact);
		if (text != null)
		{
			method_87(new NewWeaponImpactMessage
			{
				XML = text
			}, "SendNewWeaponImpactToAll");
		}
	}

	public void WeaponReloadPriorityUI(RealtimeClient client, WeaponReloadPriorityUIMessage msg)
	{
		ActiveUnit value = null;
		if (!scenario_0.ActiveUnits.TryGetValue(msg.ActiveUnitID, out value))
		{
			return;
		}
		foreach (Mount mount in value.Mounts)
		{
			if (!mount.ObjectID.Equals(msg.MountID))
			{
				continue;
			}
			if (!msg.AddPriority)
			{
				if (mount.ReloadPriority.Contains(msg.WeaponDBID))
				{
					mount.ReloadPriority.Remove(msg.WeaponDBID);
				}
			}
			else
			{
				mount.ReloadPriority.Add(msg.WeaponDBID);
			}
			break;
		}
	}

	private void SendZoneUpdate()
	{
		lock (object_1)
		{
			if (!bool_3)
			{
				return;
			}
			foreach (IGrouping<string, RealtimeClient> item in (from F in list_4
				group F by F.CurrentSide_ObjectID into F
				where !string.IsNullOrEmpty(F.Key)
				select F).ToList())
			{
				Side sideByID = scenario_0.GetSideByID(item.Key);
				if (sideByID != null)
				{
					method_101(item.ToList(), new List<Side> { sideByID });
				}
			}
			List<RealtimeClient> list_ = list_4.Where((RealtimeClient F) => F.Gods_Eye).ToList();
			method_101(list_, scenario_0.Sides_ReadOnly.ToList());
		}
	}

	private void method_52(RealtimeClient realtimeClient_1, ZoneUpdateMessage zoneUpdateMessage_0)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			bool_3 = true;
			int count = zoneUpdateMessage_0.SideID.Count;
			for (int i = 0; i < count; i++)
			{
				Side sideByID = scenario_0.GetSideByID(zoneUpdateMessage_0.SideID[i]);
				if (sideByID == null)
				{
					continue;
				}
				Dictionary<string, Zone> dictionary = new Dictionary<string, Zone>();
				foreach (Zone standardZone in sideByID.StandardZones)
				{
					dictionary.Add(standardZone.ObjectID, standardZone);
				}
				foreach (NoNavZone noNavZone in sideByID.NoNavZones)
				{
					dictionary.Add(noNavZone.ObjectID, noNavZone);
				}
				foreach (ExclusionZone exclusionZone2 in sideByID.ExclusionZones)
				{
					dictionary.Add(exclusionZone2.ObjectID, exclusionZone2);
				}
				int count2 = zoneUpdateMessage_0.AllObjectID[i].Count;
				for (int j = 0; j < count2; j++)
				{
					Zone value = null;
					dictionary.TryGetValue(zoneUpdateMessage_0.AllObjectID[i][j], out value);
					if (value == null)
					{
						continue;
					}
					value.Name = zoneUpdateMessage_0.AllName[i][j];
					value.Area = ReferencePoint.FetchReferencePointsFromID(sideByID, zoneUpdateMessage_0.AllRPs[i][j]);
					value.Description = zoneUpdateMessage_0.AllDescription[i][j];
					value.set_Layer(sideByID, zoneUpdateMessage_0.AllLayer[i][j]);
					value.AreaColor = Color.FromArgb(zoneUpdateMessage_0.AllColor[i][j]);
					value.IsActive = zoneUpdateMessage_0.AllIsActive[i][j];
					value.IsLocked = zoneUpdateMessage_0.AllIsLocked[i][j];
					value.AffectedUnitTypes.Clear();
					foreach (int item in zoneUpdateMessage_0.AllAffectedUnitTypes[i][j])
					{
						value.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)item);
					}
					switch ((Zone.ZoneType)zoneUpdateMessage_0.AllType[i][j])
					{
					case Zone.ZoneType.ExclusionZone:
					{
						ExclusionZone exclusionZone = (ExclusionZone)value;
						foreach (var item2 in zoneUpdateMessage_0.AllViolatorsStance[i][j])
						{
							CSMaterial.DictionaryExtensions.AddOrUpdate(exclusionZone.ViolatorsStance, item2.Item1, (Command_Core.Misc.PostureStance)item2.Item2);
						}
						exclusionZone.MarkViolatorAs = (Command_Core.Misc.PostureStance)zoneUpdateMessage_0.AllMarkViolatorAs[i][j];
						exclusionZone.AltitudeEnvelopeMin = zoneUpdateMessage_0.AllAltitudeEnvelopeMin[i][j];
						exclusionZone.AltitudeEnvelopeMax = zoneUpdateMessage_0.AllAltitudeEnvelopeMax[i][j];
						break;
					}
					case Zone.ZoneType.NoNavZone:
						((NoNavZone)value).NoFireZone = zoneUpdateMessage_0.AllNoFireZone[i][j];
						break;
					}
				}
			}
		}
	}

	private void method_53(RealtimeClient realtimeClient_1, CreateZoneMessage createZoneMessage_0)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			Side sideByID = scenario_0.GetSideByID(createZoneMessage_0.SideID);
			if (sideByID == null)
			{
				return;
			}
			Zone zone = Zone.Create((Zone.ZoneType)createZoneMessage_0.Type, sideByID, ReferencePoint.FetchReferencePointsFromID(sideByID, createZoneMessage_0.AllRPs), createZoneMessage_0.Name, Color.FromArgb(createZoneMessage_0.ZoneColor));
			if (zone == null)
			{
				return;
			}
			zone.Description = createZoneMessage_0.Description;
			zone.IsLocked = createZoneMessage_0.IsLocked;
			zone.set_Layer(sideByID, createZoneMessage_0.Layer);
			foreach (int affectedUnitType in createZoneMessage_0.AffectedUnitTypes)
			{
				zone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)affectedUnitType);
			}
			switch (zone.Type)
			{
			case Zone.ZoneType.NoNavZone:
				((NoNavZone)zone).NoFireZone = createZoneMessage_0.NoFireZone;
				break;
			case Zone.ZoneType.ExclusionZone:
			{
				ExclusionZone exclusionZone = (ExclusionZone)zone;
				foreach (var item in createZoneMessage_0.ViolatorsStance)
				{
					exclusionZone.ViolatorsStance.Add(item.Item1, (Command_Core.Misc.PostureStance)item.Item2);
				}
				exclusionZone.MarkViolatorAs = (Command_Core.Misc.PostureStance)createZoneMessage_0.MarkViolatorAs;
				exclusionZone.AltitudeEnvelopeMin = createZoneMessage_0.AltitudeEnvelopeMin;
				exclusionZone.AltitudeEnvelopeMax = createZoneMessage_0.AltitudeEnvelopeMax;
				break;
			}
			case Zone.ZoneType.CustomEnvironmentZone:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			}
			if (createZoneMessage_0.ClientSelectForNewZone)
			{
				method_89(realtimeClient_1, new SelectNewZoneMessage
				{
					ZoneID = zone.ObjectID
				}, "SelectNewZone");
			}
			bool_3 = true;
		}
	}

	private void DeleteZone(RealtimeClient client, DeleteZoneMessage msg)
	{
		lock (object_1)
		{
			if (hostState_0 == HostState.AC)
			{
				return;
			}
			Side sideByID = scenario_0.GetSideByID(msg.SideID);
			if (sideByID == null)
			{
				return;
			}
			bool_3 = true;
			Dictionary<string, Zone> dictionary = new Dictionary<string, Zone>();
			foreach (Zone standardZone in sideByID.StandardZones)
			{
				dictionary.Add(standardZone.ObjectID, standardZone);
			}
			foreach (NoNavZone noNavZone in sideByID.NoNavZones)
			{
				dictionary.Add(noNavZone.ObjectID, noNavZone);
			}
			foreach (ExclusionZone exclusionZone in sideByID.ExclusionZones)
			{
				dictionary.Add(exclusionZone.ObjectID, exclusionZone);
			}
			if (dictionary.Count > 0)
			{
				for (int i = 0; i < msg.ZoneIDs.Count; i++)
				{
					if (dictionary.ContainsKey(msg.ZoneIDs[i]))
					{
						dictionary[msg.ZoneIDs[i]].Remove(sideByID);
					}
				}
			}
			method_87(new DeleteZoneMessage
			{
				SideID = msg.SideID,
				ZoneIDs = msg.ZoneIDs
			}, "DeleteZone");
		}
	}

	private void method_54(string string_3)
	{
		BadState = true;
		string_3 = "An error has occured, and the server's current scenario has been saved to: \n";
		badStateDelegate_0(string_3);
	}

	public RealtimeHost()
	{
		DateTime now = DateTime.Now;
		HostInstanceName = $"Game {now:MMM dd   hh mm}";
		AutosaveDir = Path.Combine(GameGeneral.ScenariosRootPath, "Multiplayer Saves");
		if (!Directory.Exists(AutosaveDir))
		{
			Directory.CreateDirectory(AutosaveDir);
		}
	}

	private void method_55(string string_3)
	{
		try
		{
			dispatcher_0.Invoke((Delegate)logTextDelegate_0, new object[1] { string_3 });
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	private void method_56()
	{
		List<string> list = new List<string>();
		foreach (RealtimeClient item in list_4)
		{
			if (item.LoopbackMode || item.Connection.ConnectionInfo.ConnectionState == ConnectionState.Established)
			{
				if (item.TerminalRights == TerminalRights.Observer)
				{
					list.Add("[OBS] " + item.Name);
				}
				else if (!string.IsNullOrEmpty(item.TerminalLockedSide))
				{
					list.Add(item.Name + " (" + item.TerminalLockedSide + ")");
				}
				else
				{
					list.Add(item.Name);
				}
			}
		}
		dispatcher_0.Invoke((Delegate)updatePlayerListDelegate_0, new object[1] { list });
	}

	public Scenario GetScenario()
	{
		return scenario_0;
	}

	private bool method_57()
	{
		return true;
	}

	private void method_58()
	{
		SoundEffectsBySide.Clear();
		foreach (RealtimeClient realtimeClient_0 in list_4)
		{
			if (!string.IsNullOrEmpty(realtimeClient_0.CurrentSide_ObjectID))
			{
				Side side = scenario_0.Sides_ReadOnly.FirstOrDefault((Side F) => F.ObjectID == realtimeClient_0.CurrentSide_ObjectID);
				if (side != null && !SoundEffectsBySide.ContainsKey(side))
				{
					SoundEffectsBySide.TryAdd(side, new List<int>());
				}
			}
		}
		ActiveUnit_Weaponry.FiredWeapon += OnWeaponFired;
		Weapon.WeaponImpact += OnWeaponImpact;
		Aircraft_AirOps.TookOff += OnAircraftTakeoff;
		ActiveUnit_Sensory.NewContactDetected += OnNewContactDetected;
	}

	private void method_59()
	{
		ActiveUnit_Weaponry.FiredWeapon -= OnWeaponFired;
		Weapon.WeaponImpact -= OnWeaponImpact;
		Aircraft_AirOps.TookOff -= OnAircraftTakeoff;
		ActiveUnit_Sensory.NewContactDetected -= OnNewContactDetected;
	}

	private void method_60()
	{
		PlatformComponent.StatusChanged += OnHostPlatformComponentStatusChange;
		Doctrine.DoctrineChanged += OnHostDoctrineChanged;
		concurrentDictionary_2.Clear();
		Group.UnitAdded += OnHostGroupMembershipChange;
		Group.UnitRemoved += OnHostGroupMembershipChange;
		concurrentDictionary_3.Clear();
		Aircraft_AirOps.Landing += OnHostAircraftLanding;
		ActiveUnit_DockingOps.Docking += OnHostUnitDocking;
		Scenario.CurrentScenarioChanged += OnScenarioChanged;
		Scenario.SidesChanged += OnSidesChanged;
		if (PlaySoundEffects)
		{
			SoundEffectHandlersAreSet = true;
			method_58();
		}
		Scenario.ScenCompleted += OnScenarioEnd;
		method_71();
	}

	public void OnScenarioChanged(Scenario scen)
	{
		bool_11 = true;
	}

	public void OnSidesChanged(Scenario scen, Scenario.SideAdditionOrRemoval addOrRemove)
	{
		bool_11 = true;
	}

	public void OnScenarioEnd(Scenario scen)
	{
		if (scen == scenario_0)
		{
			bool_11 = true;
			bool_12 = true;
		}
	}

	private void method_61()
	{
		PlatformComponent.StatusChanged -= OnHostPlatformComponentStatusChange;
		Doctrine.DoctrineChanged -= OnHostDoctrineChanged;
		Group.UnitAdded -= OnHostGroupMembershipChange;
		Group.UnitRemoved -= OnHostGroupMembershipChange;
		Aircraft_AirOps.Landing -= OnHostAircraftLanding;
		ActiveUnit_DockingOps.Docking -= OnHostUnitDocking;
		Scenario.CurrentScenarioChanged -= OnScenarioChanged;
		Scenario.SidesChanged -= OnSidesChanged;
		if (SoundEffectHandlersAreSet)
		{
			SoundEffectHandlersAreSet = false;
			method_59();
		}
		Scenario.ScenCompleted -= OnScenarioEnd;
		bool_6 = true;
		bool_2 = true;
		bool_0 = true;
		method_72();
	}

	private void method_62()
	{
		bool_10 = true;
		list_3.Clear();
		concurrentDictionary_0.Clear();
		concurrentDictionary_1.Clear();
		concurrentDictionary_4.Clear();
		concurrentDictionary_5.Clear();
		list_1.Clear();
		list_0.Clear();
		concurrentStack_0.Clear();
	}

	private void method_63()
	{
		lock (object_1)
		{
			list_3 = (from F in list_4
				group F by F.CurrentSide_ObjectID into F
				where !string.IsNullOrEmpty(F.Key)
				select F).ToList();
			concurrentDictionary_5.Clear();
			if (concurrentDictionary_4.Count > 0)
			{
				concurrentDictionary_5 = new ConcurrentDictionary<string, List<ActiveUnit>>(concurrentDictionary_4);
			}
			concurrentDictionary_0.Clear();
			concurrentDictionary_4.Clear();
			PooledList<ActiveUnit> activeUnits_List = scenario_0.ActiveUnits_List;
			HashSet<string> hashSet_0 = new HashSet<string>();
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			foreach (Side side_0 in sides_ReadOnly)
			{
				concurrentDictionary_0.TryAdd(side_0.ObjectID, activeUnits_List.Where((ActiveUnit F) => ((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false).ObjectID == side_0.ObjectID).ToList());
				hashSet_0.Clear();
				side_0.GetAllFriendlySides(scenario_0, ref hashSet_0);
				List<ActiveUnit> list = activeUnits_List.Where((ActiveUnit F) => ((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false).ObjectID == side_0.ObjectID || hashSet_0.Contains(((Module_Unit.Unit)F).get_UnitSide(SetSideOnly: false).ObjectID)).ToList();
				List<Contact> list2 = new List<Contact>(side_0.Contacts_List);
				list2.AddRange(side_0.BaseContacts_List);
				foreach (Contact item in list2)
				{
					if (item.ActualUnit != null && !list.Contains(item.ActualUnit))
					{
						list.Add(item.ActualUnit);
					}
				}
				concurrentDictionary_4.TryAdd(side_0.ObjectID, list);
			}
			bool_10 = false;
		}
	}

	public void Shutdown()
	{
		if (!bool_7)
		{
			return;
		}
		method_55("SHUTDOWN");
		bool_9 = true;
		if (thread_0 != null)
		{
			thread_0.Join();
			thread_0 = null;
		}
		lock (object_1)
		{
			Connection.StopListening();
			foreach (RealtimeClient item in new List<RealtimeClient>(list_4))
			{
				CloseConnection(item);
			}
			method_73();
			bool_7 = false;
			if (scenario_0 != null)
			{
				method_72();
				method_12(scenario_0, "Server shutdown");
			}
			scenario_0 = null;
			list_4.Clear();
			RealtimeHostExists = false;
		}
	}

	private void method_64(Scenario scenario_1)
	{
		lock (object_1)
		{
			method_62();
			concurrentDictionary_6.Clear();
			if (scenario_0 == scenario_1)
			{
				method_65();
				return;
			}
			if (scenario_0 != null)
			{
				scenario_0.Explosions.ItemsAdded -= OnHostScenExplosionAdded;
				scenario_0.WeaponImpacts.ItemsAdded -= OnHostScenWeaponImpactAdded;
				scenario_0.GroundImpacts.ItemsAdded -= OnHostScenGroundImpactAdded;
				scenario_0.WaterSplashes.ItemsAdded -= OnHostScenWaterSplashAdded;
				if (scenario_1 != null && scenario_1.TimelineID == scenario_0.TimelineID)
				{
					scenario_1.BranchToNewTimeline();
				}
			}
			scenario_0 = scenario_1;
			GameGeneral.UseDynamicResolution = false;
			GameGeneral.Global_PulseResolution = 1f;
			scenario_0.GameResolution = 1f;
			scenario_0.RunningHeadless = true;
			scenario_0.RunningInRTMPHost = true;
			scenario_0.Scenario_LuaSandbox.RefreshStats(scenario_0);
			scenario_0.Explosions.ItemsAdded += OnHostScenExplosionAdded;
			scenario_0.WeaponImpacts.ItemsAdded += OnHostScenWeaponImpactAdded;
			scenario_0.GroundImpacts.ItemsAdded += OnHostScenGroundImpactAdded;
			scenario_0.WaterSplashes.ItemsAdded += OnHostScenWaterSplashAdded;
			foreach (RealtimeClient item in list_4)
			{
				hashSet_0.Add(item);
			}
			long_0 = scenario_0.MessageLog.LastOrDefault()?.Increment ?? 0L;
			GameSpeed = 0;
			method_65();
		}
	}

	private void method_65()
	{
		TimeSpan timeSpan = scenario_0.Time - scenario_0.StartTime;
		TimeSpan timeSpan2 = scenario_0.Duration - timeSpan;
		List<string> list = new List<string>();
		string text = "";
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			text = side.Name;
			if (!side.IsAIOnly)
			{
				if (side.IsNature)
				{
					text += " (Nature)";
				}
			}
			else
			{
				text += " (AI Only)";
			}
			list.Add(text);
		}
		dispatcher_0.Invoke((Delegate)scenarioChangedDelegate_0, new object[4] { scenario_0.Title, timeSpan, timeSpan2, list });
		dispatcher_0.Invoke((Delegate)scenarioTimeChangedDelegate_0, (DispatcherPriority)1, new object[3] { 0, timeSpan, timeSpan2 });
	}

	public void CloseConnection(RealtimeClient client)
	{
		lock (object_1)
		{
			if (!client.LoopbackMode)
			{
				client.Connection.CloseConnection(b: false);
			}
			else
			{
				client.Loopback = null;
			}
		}
	}

	public void Start(Dispatcher Dispatcher, string path, RTMP_MultiplayerLicense License, Options options = null, bool StandAloneHost = false, string userID = null, string serializedNetworkID = null, string inviteCode = null)
	{
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		if (options == null)
		{
			options = Options.DefaultOptions(this, License);
		}
		if (RealtimeHostExists)
		{
			throw new Exception();
		}
		try
		{
			lock (object_1)
			{
				rtmp_MultiplayerLicense_0 = License;
				dispatcher_0 = Dispatcher;
				PlaySoundEffects = options.SoundEffects;
				AutosaveInterval_s = options.AutosaveInterval;
				if (AutosaveInterval_s > 0 && AutosaveInterval_s < 300)
				{
					options.AutosaveInterval = 300;
					AutosaveInterval_s = options.AutosaveInterval;
				}
				Connection.MyUserID = int.Parse(userID);
				IPAddress loopback = IPAddress.Loopback;
				Connection.StartListening(ConnectionType.TCP, new IPEndPoint(loopback, 0), serializedNetworkID, inviteCode);
				Connection.playFabPartyClient.PeerConnected += delegate(object object_3, uint uint_1)
				{
					method_83(new Connection(uint_1));
				};
				Connection.playFabPartyClient.PeerDisconnected += delegate(object object_3, uint uint_1)
				{
					RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection.OtherUserID == uint_1);
					if (realtimeClient != null)
					{
						method_82(realtimeClient.Connection);
					}
				};
				Connection.playFabPartyClient.MessageReceived += delegate(object sender, ByteArrayMessageEventArgs e)
				{
					RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection.OtherUserID == e.SenderId);
					if (realtimeClient != null)
					{
						Connection connection = realtimeClient.Connection;
						PacketHeader packetHeader_ = new PacketHeader();
						method_68(packetHeader_, connection, e.Message);
					}
				};
				list_5.Clear();
				if (thread_0 != null)
				{
					thread_0.Abort();
				}
				thread_0 = new Thread(HostThreadSubroutine);
				thread_0.Start();
				GameGeneral.CoreToUIMessage += method_66;
				method_64(CommandCoreInterop.ScenarioFromFile(path));
				GameGeneral.CoreToUIMessage -= method_66;
				if (scenario_0 == null)
				{
					return;
				}
				scenario_0.Initialize();
				if (StandAloneHost)
				{
					IujLpaoHbMe();
				}
				try
				{
					string navalFormationEditorScriptResource = GameGeneral.GetNavalFormationEditorScriptResource();
					if (!string.IsNullOrEmpty(navalFormationEditorScriptResource))
					{
						scenario_0.Scenario_LuaSandbox.RunScript(navalFormationEditorScriptResource, RunInteractively: true, "Console");
						bool_1 = true;
					}
				}
				catch (Exception)
				{
					method_55("ERROR: Could not load naval formation editor resources.");
				}
				method_55("Server started. Awaiting connections.");
				bool_7 = true;
				RealtimeHostExists = true;
			}
		}
		catch (Exception ex2)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			MessageBox.Show("Unable to start server. Error: " + ex2.Message);
			Environment.Exit(0);
		}
	}

	private void method_66(string string_3, string string_4, Side side_0, GameGeneral.MessageBoxMessageType messageBoxMessageType_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		MessageBox.Show(string_3, string_4);
	}

	private string method_67(Connection connection_0)
	{
		lock (object_1)
		{
			if (connection_0 != null)
			{
				RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection == connection_0);
				if (realtimeClient != null)
				{
					if (realtimeClient.Name != null)
					{
						return realtimeClient.Name;
					}
					return $"RELAY {realtimeClient.Connection.OtherUserID}";
				}
				return "NULL CLIENT";
			}
			return "LOOPBACK";
		}
	}

	public void SendGlobalChatMessage(string Message)
	{
		if (bool_7)
		{
			method_55(Message);
			method_87(new GlobalChatMessage
			{
				Message = Message,
				PlayerName = "SERVER"
			}, "SendGlobalChatMessage");
		}
	}

	public void QueueMessage(RTMessage msg, Connection connection, RealtimeClient client)
	{
		concurrentQueue_0.Enqueue(new Tuple<RTMessage, Connection, RealtimeClient>(msg, connection, client));
	}

	private void method_68(PacketHeader packetHeader_0, Connection connection_0, byte[] byte_0)
	{
		RTMessage msg = RealtimeSerializer.Deserialize<RTMessage>(byte_0);
		lock (object_1)
		{
			try
			{
				RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection == connection_0);
				if (realtimeClient == null)
				{
					list_5.Add(new Tuple<PacketHeader, Connection, byte[]>(packetHeader_0, connection_0, byte_0));
					return;
				}
				realtimeClient.LastHeard = DateTime.Now;
				byte_0.Count();
				QueueMessage(msg, connection_0, realtimeClient);
			}
			catch (Exception ex)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				try
				{
					method_55("ERROR upon recv message. " + method_67(connection_0) + " E: " + ex.Message);
				}
				catch
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				try
				{
					RealtimeClient realtimeClient2 = list_4.FirstOrDefault((RealtimeClient F) => F.Connection == connection_0);
					if (realtimeClient2 != null)
					{
						ClientError(realtimeClient2, "ERROR upon recv message. " + method_67(connection_0) + " E: " + ex.Message);
					}
					connection_0.CloseConnection(b: false);
				}
				catch
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
			}
		}
	}

	private void ClientError(RealtimeClient client, string msg)
	{
		client.ErrorMessage = msg;
		method_55("CLIENT ERROR");
		method_55("CLIENT ERROR");
		method_55("CLIENT ERROR");
		method_55(method_67(client.Connection) + ": " + msg);
		method_55("CLIENT ERROR");
		method_55("CLIENT ERROR");
		method_55("CLIENT ERROR");
		method_89(client, new ErrorMessage
		{
			Message = msg
		}, "ClientError");
	}

	private void method_69(RealtimeClient realtimeClient_1)
	{
		object obj;
		if (realtimeClient_1 == null)
		{
			obj = null;
		}
		else
		{
			obj = realtimeClient_1.Name;
			if (obj != null)
			{
				goto IL_001b;
			}
		}
		obj = "null";
		goto IL_001b;
		IL_001b:
		SendGlobalChatMessage("Player disconnected: " + (string?)obj);
		if (hostState_0 == HostState.AC && realtimeClient_1 == realtimeClient_0)
		{
			realtimeClient_0 = null;
			hostState_0 = HostState.Paused;
			method_55("Absolute Control released without changes.");
		}
		hostState_0 = HostState.Paused;
		if (!bool_12 && !bool_13)
		{
			string text = scenario_0.Title + " ";
			for (int i = 0; i < list_4.Count; i++)
			{
				text += list_4[i].Name;
				if (i < list_4.Count - 1)
				{
					text += " ";
				}
			}
			string theFileName = method_10(scenario_0, text);
			new ScenContainer(scenario_0).SaveToFile(theFileName);
			SendGameOver("Player " + realtimeClient_1.Name + " has disconnected. An auto-save has been created on the host. Players can resume play by reconnecting from the game lobby using the auto-save.");
			bool_13 = true;
		}
		method_56();
		SendAllPeerList();
	}

	private void method_70(RealtimeClient realtimeClient_1)
	{
		string text = "null";
		if (realtimeClient_1 != null)
		{
			if (string.IsNullOrEmpty(realtimeClient_1.Name))
			{
				if (realtimeClient_1.Connection != null)
				{
					text = realtimeClient_1.Connection.ToString();
				}
			}
			else
			{
				text = realtimeClient_1.Name;
			}
		}
		SendGlobalChatMessage("Player connected: " + text);
		method_56();
	}

	private void IujLpaoHbMe()
	{
	}

	private void method_71()
	{
		if (scenario_0.MessageLog.Count > 32768)
		{
			int count = scenario_0.MessageLog.Count - 32768;
			scenario_0.MessageLog.RemoveRange(0, count);
		}
	}

	private void method_72()
	{
		if (!bool_8)
		{
			return;
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (LoggedMessage item in scenario_0.MessageLog)
			{
				if (!item.ProcessedByClient)
				{
					flag = true;
					string text = ((item.Side != null) ? ("[" + item.Side.Name + "] ") : "");
					stringBuilder.Append(item.Timestamp.ToString() + " - " + text + item.Text + "\r\n\r\n");
					item.ProcessedByClient = true;
				}
			}
			if (flag)
			{
				StreamWriter streamWriter = File.AppendText(string_2);
				streamWriter.Write(stringBuilder.ToString());
				streamWriter.Close();
			}
		}
		catch
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	private void method_73()
	{
		try
		{
			if (bool_8)
			{
				bool_8 = false;
			}
			if (streamWriter_0 != null)
			{
				streamWriter_0.WriteLine("\n");
				streamWriter_0.WriteLine("#######################");
				streamWriter_0.WriteLine("Timeline ID: " + scenario_0.TimelineID);
				streamWriter_0.WriteLine("#######################");
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				foreach (Side theSide in sides_ReadOnly)
				{
					streamWriter_0.WriteLine("\n");
					streamWriter_0.WriteLine(GameGeneral.SideLosses_AsString(theSide, scenario_0));
				}
				streamWriter_0.WriteLine("#######################");
				streamWriter_0.WriteLine("\n");
				streamWriter_0.Close();
				streamWriter_0 = null;
			}
		}
		catch
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	private string method_74(Module_Unit.Unit unit_0)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (unit_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(unit_0.ObjectID))
			{
				return concurrentDictionary_6[unit_0.ObjectID];
			}
			string text = "";
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			if (unit_0.IsGroup)
			{
				Group obj = (Group)unit_0;
				if (obj.GroupLead != null)
				{
					ObjectsAlreadySerialized.Add(obj.GroupLead.ObjectID);
				}
			}
			unit_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.Flush();
			text = stringBuilder.ToString();
			concurrentDictionary_6.TryAdd(unit_0.ObjectID, text);
			return text;
		}
		return null;
	}

	private string method_75(Contact contact_0)
	{
		if (contact_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(contact_0.ObjectID))
			{
				return concurrentDictionary_6[contact_0.ObjectID];
			}
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			string text = contact_0.ToXML(objectsAlreadySerialized, null);
			concurrentDictionary_6.TryAdd(contact_0.ObjectID, text);
			return text;
		}
		return null;
	}

	private string method_76(WeaponSalvo weaponSalvo_0)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		if (weaponSalvo_0 == null)
		{
			return null;
		}
		if (!concurrentDictionary_6.ContainsKey(weaponSalvo_0.ObjectID))
		{
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			weaponSalvo_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.Flush();
			string text = stringBuilder.ToString();
			concurrentDictionary_6.TryAdd(weaponSalvo_0.ObjectID, text);
			return text;
		}
		return concurrentDictionary_6[weaponSalvo_0.ObjectID];
	}

	private string method_77(Mission mission_0, Scenario scenario_1, Side side_0)
	{
		if (mission_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(mission_0.ObjectID))
			{
				return concurrentDictionary_6[mission_0.ObjectID];
			}
			return MissionHelper.smethod_1(mission_0, scenario_1, side_0);
		}
		return null;
	}

	private string method_78(Side side_0, Scenario scenario_1)
	{
		if (side_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(side_0.ObjectID))
			{
				return concurrentDictionary_6[side_0.ObjectID];
			}
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			string text = side_0.ToXML(ref ObjectsAlreadySerialized, ref scenario_1);
			concurrentDictionary_6.TryAdd(side_0.ObjectID, text);
			return text;
		}
		return null;
	}

	private string method_79(Waypoint waypoint_0)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		if (waypoint_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(waypoint_0.ObjectID))
			{
				return concurrentDictionary_6[waypoint_0.ObjectID];
			}
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			waypoint_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.Flush();
			string text = stringBuilder.ToString();
			concurrentDictionary_6.TryAdd(waypoint_0.ObjectID, text);
			return text;
		}
		return null;
	}

	private string method_80(Doctrine doctrine_0, Scenario scenario_1)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		if (doctrine_0 == null)
		{
			return null;
		}
		bool flag = doctrine_0.Subject != null;
		string key = null;
		if (flag)
		{
			key = "D-" + doctrine_0.Subject.ObjectID;
		}
		if (flag && concurrentDictionary_6.ContainsKey(key))
		{
			return concurrentDictionary_6[key];
		}
		StringBuilder stringBuilder = new StringBuilder();
		XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
		doctrine_0.ToXML(ref theWriter, ref scenario_1);
		theWriter.Flush();
		string text = stringBuilder.ToString();
		if (flag)
		{
			concurrentDictionary_6.TryAdd(key, text);
		}
		return text;
	}

	private string method_81(UnguidedWeapon unguidedWeapon_0)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		if (unguidedWeapon_0 != null)
		{
			if (concurrentDictionary_6.ContainsKey(unguidedWeapon_0.ObjectID))
			{
				return concurrentDictionary_6[unguidedWeapon_0.ObjectID];
			}
			string text = "";
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(new StringBuilder()));
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			text = unguidedWeapon_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			concurrentDictionary_6.TryAdd(unguidedWeapon_0.ObjectID, text);
			return text;
		}
		return null;
	}

	public static void WriteToCommandHostLogFile(string output)
	{
		try
		{
			string[] obj = new string[5]
			{
				GameGeneral.LogsPath,
				null,
				null,
				null,
				null
			};
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			obj[1] = directorySeparatorChar.ToString();
			obj[2] = "CommandHostLog_";
			obj[3] = DateTime.Now.ToString("yyyy_MM_dd");
			obj[4] = ".txt";
			string path = string.Concat(obj);
			lock (object_2)
			{
				File.AppendAllText(path, output + Environment.NewLine);
			}
		}
		catch
		{
		}
	}

	internal void ConnectionClosedLoopback(RealtimeTerminal Terminal)
	{
		lock (object_1)
		{
			try
			{
				if (list_4.Count <= 1)
				{
					method_55("Server is currently clientless.");
					GameSpeed = 0;
					hostState_0 = HostState.Paused;
					realtimeClient_0 = null;
					hashSet_0.Clear();
				}
				RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.LoopbackMode);
				if (realtimeClient != null)
				{
					if (realtimeClient.Loopback != Terminal)
					{
						throw new Exception();
					}
					method_69(realtimeClient);
					list_4.Remove(realtimeClient);
				}
			}
			catch (Exception ex)
			{
				try
				{
					method_55("ERROR upon close connection.  " + method_67(null) + " E: " + ex.Message);
					RealtimeClient realtimeClient2 = list_4.FirstOrDefault((RealtimeClient F) => F.Connection == null);
					if (realtimeClient2 != null)
					{
						list_4.Remove(realtimeClient2);
					}
				}
				catch (Exception)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
	}

	private void method_82(Connection connection_0)
	{
		object obj = object_1;
		bool lockTaken = false;
		Monitor.Enter(obj, ref lockTaken);
		RealtimeClient realtimeClient = list_4.First((RealtimeClient F) => F.Connection == connection_0);
		if (realtimeClient == null)
		{
			return;
		}
		method_69(realtimeClient);
		list_4.Remove(realtimeClient);
		if (list_4.Count == 0)
		{
			method_55("Server is currently clientless.");
			GameSpeed = 0;
			hostState_0 = HostState.Paused;
			realtimeClient_0 = null;
			hashSet_0.Clear();
			if (scenario_0 != null)
			{
				TimeSpan timeSpan = scenario_0.Time - scenario_0.StartTime;
				TimeSpan timeSpan2 = scenario_0.Duration - timeSpan;
				dispatcher_0.Invoke((Delegate)scenarioTimeChangedDelegate_0, (DispatcherPriority)1, new object[3] { 0, timeSpan, timeSpan2 });
			}
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				Shutdown();
				Environment.Exit(0);
			}, Array.Empty<object>());
		}
	}

	internal void ConnectionEstablishedLoopback(RealtimeTerminal terminal)
	{
		object obj = object_1;
		bool lockTaken = false;
		Monitor.Enter(obj, ref lockTaken);
		RealtimeClient realtimeClient = new RealtimeClient
		{
			Connection = null,
			Loopback = terminal
		};
		list_4.Add(realtimeClient);
		method_70(realtimeClient);
	}

	private void method_83(Connection connection_0)
	{
		try
		{
			lock (object_1)
			{
				RealtimeClient realtimeClient = new RealtimeClient
				{
					Connection = connection_0
				};
				list_4.Add(realtimeClient);
				method_70(realtimeClient);
				foreach (Tuple<PacketHeader, Connection, byte[]> item in list_5.Where((Tuple<PacketHeader, Connection, byte[]> F) => F.Item2 == connection_0).ToList())
				{
					method_68(item.Item1, item.Item2, item.Item3);
					list_5.Remove(item);
				}
			}
		}
		catch (Exception ex)
		{
			method_55("ERROR CONNECTING " + method_67(connection_0) + " E: " + ex.Message);
			connection_0.CloseConnection(b: true);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal void HandleMessage(RTMessage msg, Connection connection, RealtimeClient client)
	{
		if (connection == null && client == null)
		{
			client = list_4.First((RealtimeClient F) => F.LoopbackMode);
		}
		client.LastHeard = DateTime.Now;
		if (msg.GetType() != typeof(PeerScreenMouseUpdateMessage))
		{
			client.LastMessageType = msg.GetType().Name;
		}
		if (!(msg is PeerScreenMouseUpdateMessage msg2))
		{
			if (!(msg is AutosavesListRequestMessage msg3))
			{
				if (!(msg is ErrorMessage msg4))
				{
					Interlocked.Increment(ref int_0);
					lock (object_1)
					{
						try
						{
							if (client.Name == null && !(msg is LoginRequestMessage) && !(msg is ServerInfoRequest) && !(msg is HealthMessage) && !(msg is GlobalChatMessage))
							{
								method_89(client, new ErrorMessage
								{
									Message = "Unexpected message received from client prior to player login."
								}, "HandleMessage ClientError");
								method_55("Error: Unexpected message received prior to player login - " + method_67(client.Connection));
								CloseConnection(client);
							}
							else
							{
								if (!(msg is GlobalChatMessage msg5))
								{
									if (!(msg is LoginRequestMessage msg6))
									{
										if (msg is ServerInfoRequest msg7)
										{
											ServerInfoRequest(client, msg7);
										}
										else if (msg is EmbarkedOpsRearmMessage embarkedOpsRearmMessage_)
										{
											method_33(client, embarkedOpsRearmMessage_);
										}
										else if (msg is ThrottleAltUIMessage msg8)
										{
											ThrottleAltUI(client, msg8);
										}
										else if (!(msg is SpeedRequestMessage speedRequestMessage_))
										{
											if (msg is AbsoluteControlRequestMessage absoluteControlRequestMessage_)
											{
												method_8(client, absoluteControlRequestMessage_);
											}
											else if (msg is AbsoluteControlReleaseMessage absoluteControlReleaseMessage_)
											{
												method_9(client, absoluteControlReleaseMessage_);
											}
											else if (!(msg is CourseUpdateMessage courseUpdateMessage_))
											{
												if (msg is EmbarkedOpsLaunchMessage embarkedOpsLaunchMessage_)
												{
													method_34(client, embarkedOpsLaunchMessage_);
												}
												else if (!(msg is SelectionChangeMessage selectionChangeMessage_))
												{
													if (!(msg is HostUnitSelectionChangeMessage hostUnitSelectionChangeMessage_))
													{
														if (msg is SideChangeMessage sideChangeMessage_)
														{
															nMsLkhabduo(client, sideChangeMessage_);
														}
														else if (!(msg is TeleportUnitMessage msg9))
														{
															if (!(msg is CreateWeaponSalvoActionMessage msg10))
															{
																if (msg is CancelWeaponSalvoActionMessage msg11)
																{
																	CancelWeaponSalvoAction(client, msg11);
																}
																else if (!(msg is SalvoCourseUpdateMessage msg12))
																{
																	if (!(msg is ExecuteManualWeaponSalvosMessage msg13))
																	{
																		if (msg is CreateReferencePointMessage createReferencePointMessage_)
																		{
																			method_40(client, createReferencePointMessage_);
																		}
																		else if (msg is CreateMultipleReferencePointMessage createMultipleReferencePointMessage_)
																		{
																			method_41(client, createMultipleReferencePointMessage_);
																		}
																		else if (msg is DeleteReferencePointMessage msg14)
																		{
																			DeleteReferencePoint(client, msg14);
																		}
																		else if (msg is ReferencePointUpdateMessage msg15)
																		{
																			ReferencePointUpdate(client, msg15);
																		}
																		else if (msg is CreateZoneMessage createZoneMessage_)
																		{
																			method_53(client, createZoneMessage_);
																		}
																		else if (msg is DeleteZoneMessage msg16)
																		{
																			DeleteZone(client, msg16);
																		}
																		else if (msg is ZoneUpdateMessage zoneUpdateMessage_)
																		{
																			method_52(client, zoneUpdateMessage_);
																		}
																		else if (!(msg is AutosaveRequestMessage autosaveRequestMessage_))
																		{
																			if (msg is RewindRequestMessage rewindRequestMessage_)
																			{
																				method_14(client, rewindRequestMessage_);
																			}
																			else if (!(msg is PeerListRequestMessage peerListRequestMessage_))
																			{
																				if (!(msg is ActiveUnitMiscActionMessage activeUnitMiscActionMessage_))
																				{
																					if (msg is ActiveUnitHomeBaseMessage activeUnitHomeBaseMessage_)
																					{
																						method_6(client, activeUnitHomeBaseMessage_);
																					}
																					else if (msg is ActiveUnitResupplyActionMessage activeUnitResupplyActionMessage_)
																					{
																						method_42(client, activeUnitResupplyActionMessage_);
																					}
																					else if (!(msg is AirborneAircraftQuickTurnaroundMessage airborneAircraftQuickTurnaroundMessage_))
																					{
																						if (msg is UnitRenameMessage unitRenameMessage_)
																						{
																							method_7(client, unitRenameMessage_);
																						}
																						else if (!(msg is LogoutMessage logoutMessage_))
																						{
																							if (!(msg is TargetingContactAutoEngageMessage targetingContactAutoEngageMessage_))
																							{
																								if (msg is TargetingContactManualFireMessage targetingContactManualFireMessage_)
																								{
																									method_24(client, targetingContactManualFireMessage_);
																								}
																								else if (!(msg is AssignToMissionMessage assignToMissionMessage_))
																								{
																									if (!(msg is ContactMiscActionMessage contactMiscActionMessage_))
																									{
																										if (!(msg is WeaponReloadPriorityUIMessage msg17))
																										{
																											if (msg is GroupFormationSetMessage msg18)
																											{
																												GroupFormationSet(client, msg18);
																											}
																											else if (msg is GroupFormationSetLeadMessage msg19)
																											{
																												GroupFormationSetLead(client, msg19);
																											}
																											else if (!(msg is GroupFormationSetStationMessage msg20))
																											{
																												if (msg is GroupFormationSprintDriftMessage msg21)
																												{
																													GroupFormationSetSprintDrift(client, msg21);
																												}
																												else if (!(msg is SensorEMCONUpdateMessage msg22))
																												{
																													if (msg is SensorIntermittentEmissionUpdateMessage msg23)
																													{
																														IntermittentEmissionUpdate(client, msg23);
																													}
																													else if (msg is SideAlertnessUpdateMessage sideAlertnessUpdateMessage_)
																													{
																														method_44(client, sideAlertnessUpdateMessage_);
																													}
																													else if (!(msg is SideMapPingMessage msg24))
																													{
																														if (msg is SensorUpdateMessage msg25)
																														{
																															SensorActivation(client, msg25);
																														}
																														else if (msg is WaypointSensorMessage waypointSensorMessage_)
																														{
																															method_51(client, waypointSensorMessage_);
																														}
																														else if (!(msg is WaypointUpdateMessage waypointUpdateMessage_))
																														{
																															if (msg is SelectDoctrineMessage selectDoctrineMessage_)
																															{
																																method_31(client, selectDoctrineMessage_);
																															}
																															else if (msg is DoctrineChangedMessage doctrineChangedMessage_)
																															{
																																method_32(client, doctrineChangedMessage_);
																															}
																															else if (msg is MissionCreateMessage missionCreateMessage_)
																															{
																																method_38(client, missionCreateMessage_);
																															}
																															else if (msg is MissionRemoveMessage msg26)
																															{
																																RemoveMission(client, msg26);
																															}
																															else if (msg is MissionCloneMessage msg27)
																															{
																																CloneMission(client, msg27);
																															}
																															else if (msg is MissionUpdateMessage missionUpdateMessage_)
																															{
																																method_37(client, missionUpdateMessage_);
																															}
																															else if (msg is MissionSetSecondaryBaseMessage msg28)
																															{
																																MissionSetSecondaryAirBase(client, msg28);
																															}
																															else if (!(msg is MissionGenerateFlightPlansMessage msg29))
																															{
																																if (msg is MissionGenerateFlightsForTaskPoolMessage msg30)
																																{
																																	MissionGenerateFlightsForTaskPool(client, msg30);
																																}
																																else if (!(msg is MissionEditorDeleteFlightsMessage msg31))
																																{
																																	if (!(msg is MissionFillEmptySlotsMessage msg32))
																																	{
																																		if (msg is ChangeFlightMessage msg33)
																																		{
																																			ChangeFlight(client, msg33);
																																		}
																																		else if (!(msg is ChangeFlightPlanWaypointMessage msg34))
																																		{
																																			if (msg is UnitCargoActionMessage msg35)
																																			{
																																				UnitCargoAction(client, msg35);
																																			}
																																			else if (!(msg is ContainerCargoActionMessage msg36))
																																			{
																																				if (!(msg is SpecialActionMessage msg37))
																																				{
																																					if (msg is ScoringUpdateMessage msg38)
																																					{
																																						ScoringUpdate(client, msg38);
																																					}
																																					else if (!(msg is ExecutionSyncMessage executionSyncMessage_))
																																					{
																																						if (msg is SidePosturesUpdateMessage sidePosturesUpdateMessage_)
																																						{
																																							method_43(client, sidePosturesUpdateMessage_);
																																						}
																																						else if (msg is HealthMessage msg39)
																																						{
																																							Health(client, msg39);
																																						}
																																						else if (Debugger.IsAttached)
																																						{
																																							Debugger.Break();
																																						}
																																					}
																																					else
																																					{
																																						method_22(client, executionSyncMessage_);
																																					}
																																				}
																																				else
																																				{
																																					SpecialActionExecute(client, msg37);
																																				}
																																			}
																																			else
																																			{
																																				ContainerCargoAction(client, msg36);
																																			}
																																		}
																																		else
																																		{
																																			ChangeFlightPlanWaypoint(client, msg34);
																																		}
																																	}
																																	else
																																	{
																																		MissionFillEmptySlots(client, msg32);
																																	}
																																}
																																else
																																{
																																	MissionEditorDeleteFlights(client, msg31);
																																}
																															}
																															else
																															{
																																MissionGenerateFlightPlans(client, msg29);
																															}
																														}
																														else
																														{
																															method_50(client, waypointUpdateMessage_);
																														}
																													}
																													else
																													{
																														SideMapPing(client, msg24);
																													}
																												}
																												else
																												{
																													SensorEMCONUpdate(client, msg22);
																												}
																											}
																											else
																											{
																												GroupFormationSetStation(client, msg20);
																											}
																										}
																										else
																										{
																											WeaponReloadPriorityUI(client, msg17);
																										}
																									}
																									else
																									{
																										method_25(client, contactMiscActionMessage_);
																									}
																								}
																								else
																								{
																									method_36(client, assignToMissionMessage_);
																								}
																							}
																							else
																							{
																								method_23(client, targetingContactAutoEngageMessage_);
																							}
																						}
																						else
																						{
																							method_15(client, logoutMessage_);
																						}
																					}
																					else
																					{
																						method_1(client, airborneAircraftQuickTurnaroundMessage_);
																					}
																				}
																				else
																				{
																					method_0(client, activeUnitMiscActionMessage_);
																				}
																			}
																			else
																			{
																				method_16(client, peerListRequestMessage_);
																			}
																		}
																		else
																		{
																			method_13(client, autosaveRequestMessage_);
																		}
																	}
																	else
																	{
																		ExecuteManualSalvosAction(client, msg13);
																	}
																}
																else
																{
																	SalvoCourseUpdate(client, msg12);
																}
															}
															else
															{
																CreateWeaponSalvoAction(client, msg10);
															}
														}
														else
														{
															TeleportUnit(client, msg9);
														}
													}
													else
													{
														method_19(client, hostUnitSelectionChangeMessage_);
													}
												}
												else
												{
													method_18(client, selectionChangeMessage_);
												}
											}
											else
											{
												method_29(client, courseUpdateMessage_);
											}
										}
										else
										{
											method_21(client, speedRequestMessage_);
										}
									}
									else
									{
										LoginRequest(client, msg6);
									}
								}
								else
								{
									GlobalChat(client, msg5);
								}
								if (msg.GetType().IsSubclassOf(typeof(UIMessage)))
								{
									SendUIResponse(client, (UIMessage)msg);
								}
							}
						}
						catch (Exception ex)
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							try
							{
								method_55("ERROR upon recv message. " + method_67(connection) + " E: " + ex.Message);
							}
							catch
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							try
							{
								if (client != null)
								{
									ClientError(client, "ERROR upon recv message. " + method_67(connection) + " E: " + ex.Message);
									client.ErrorCount++;
									if (client.ErrorCount > 2)
									{
										connection?.CloseConnection(b: false);
									}
								}
								GameGeneral.WriteExceptionsToLog(ex);
							}
							catch
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
					}
					Interlocked.Decrement(ref int_0);
				}
				else
				{
					Error(client, msg4);
				}
			}
			else
			{
				AutosavesListRequest(client, msg3);
			}
		}
		else
		{
			PeerScreenMouseUpdate(client, msg2);
		}
	}

	private void Error(RealtimeClient client, ErrorMessage msg)
	{
		client.ErrorCount++;
		method_55("ERROR FROM CLIENT");
		method_55("ERROR FROM CLIENT");
		method_55("ERROR FROM CLIENT");
		method_55(msg.Message);
		method_55("ERROR FROM CLIENT");
		method_55("ERROR FROM CLIENT");
		method_55("ERROR FROM CLIENT");
		if (client.ErrorCount <= 2)
		{
			return;
		}
		object obj;
		if (client == null)
		{
			obj = null;
		}
		else
		{
			obj = client.Name;
			if (obj != null)
			{
				goto IL_0080;
			}
		}
		obj = "null";
		goto IL_0080;
		IL_0080:
		method_55("Closing client " + (string?)obj + " due to excessive errors.");
		client.Connection.CloseConnection(b: false);
	}

	public void OnScenarioAdvanced1Pulse(int simPulsesPerPass)
	{
		SendNewUnguidedWeapons();
		SendNewChaffClouds();
		if (IntermediateUnitUpdateInterval_s > 0)
		{
			uint_0++;
			if (uint_0 == simPulsesPerPass)
			{
				uint_0 = 0u;
				return;
			}
			if (uint_0 % IntermediateUnitUpdateInterval_s == 0L)
			{
				method_39(IntermediateUnitUpdateInterval_s);
				method_28(IntermediateUnitUpdateInterval_s);
				uint_0 = 0u;
			}
		}
		if (simPulsesPerPass > 1)
		{
			method_84();
		}
	}

	private void method_84()
	{
		foreach (RealtimeClient item in list_4)
		{
			item.ErrorCount = 0;
		}
		Tuple<RTMessage, Connection, RealtimeClient> result = null;
		while (!concurrentQueue_0.IsEmpty)
		{
			if (concurrentQueue_0.TryDequeue(out result))
			{
				HandleMessage(result.Item1, result.Item2, result.Item3);
			}
		}
	}

	private bool method_85(uint uint_1)
	{
		if (!bool_9)
		{
			uint num = uint_1;
			if (!SyncSimStepForAllClients && uint_1 > 1)
			{
				num--;
			}
			foreach (RealtimeClient item in list_4)
			{
				if (item.Connection != null && item.Connection.ConnectionInfo.ConnectionState == ConnectionState.Established && item.LastReportedSimExecutionStep != 0 && item.LastReportedSimExecutionStep < num)
				{
					return false;
				}
			}
			return true;
		}
		return true;
	}

	public void HostThreadSubroutine()
	{
		<>c__DisplayClass310_0 CS$<>8__locals16 = new <>c__DisplayClass310_0();
		CS$<>8__locals16.realtimeHost_0 = this;
		method_12(scenario_0, "Initial State");
		CS$<>8__locals16.list_0 = new List<Task>();
		DateTime dateTime = DateTime.Now;
		int num = 0;
		int num2 = 1000;
		bool flag = false;
		bool flag2 = false;
		uint num3 = 0u;
		DateTime dateTime2 = DateTime.Now.AddSeconds(AutosaveInterval_s);
		while (!bool_9)
		{
			try
			{
				int_1++;
				if (bool_9)
				{
					break;
				}
				if (CS$<>8__locals16.list_0.Count > 0)
				{
					Task.WaitAll(CS$<>8__locals16.list_0.ToArray());
					CS$<>8__locals16.list_0.Clear();
				}
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = now - dateTime;
				lock (object_1)
				{
					flag = false;
					flag2 = false;
					bool_6 = false;
					bool_2 = false;
					bool_3 = false;
					bool_0 = false;
					method_84();
					switch (hostState_0)
					{
					default:
						throw new Exception();
					case HostState.Paused:
						if (GameSpeed > 0)
						{
							hostState_0 = HostState.Running;
							SendStatusUpdate();
							flag2 = true;
						}
						if (realtimeClient_0 != null)
						{
							string scenXML2 = CommandCoreInterop.ScenarioToXML(scenario_0);
							CS$<>8__locals16.method_0(delegate
							{
								CS$<>8__locals16.realtimeHost_0.method_12(CS$<>8__locals16.realtimeHost_0.scenario_0, "AC begin " + CS$<>8__locals16.realtimeHost_0.realtimeClient_0.Name);
							});
							method_89(realtimeClient_0, new AbsoluteControlGrantedMessage
							{
								ScenXML = scenXML2
							}, "HostThreadSubroutine Sending the scenXML to the AC Requester (while paused)");
							hostState_0 = HostState.AC;
							method_55(realtimeClient_0?.Name + " has been granted Absolute Control.");
						}
						break;
					case HostState.Running:
						if (GameSpeed == 0)
						{
							hostState_0 = HostState.Paused;
							SendStatusUpdate("Pushing state.");
							method_17(list_4, "HostThreadSubroutine We've paused, so pushing state.");
							hashSet_0.Clear();
							flag = true;
							TimeSpan timeSpan2 = scenario_0.Time - scenario_0.StartTime;
							TimeSpan timeSpan3 = scenario_0.Duration - timeSpan2;
							dispatcher_0.BeginInvoke((Delegate)scenarioTimeChangedDelegate_0, (DispatcherPriority)1, new object[3] { 0, timeSpan2, timeSpan3 });
						}
						else if (realtimeClient_0 == null)
						{
							if (!method_85(num3) || !(timeSpan.TotalMilliseconds + (double)num2 >= 1000.0) || !method_57())
							{
								break;
							}
							dateTime = now;
							bool_11 = false;
							method_60();
							num = Environment.TickCount;
							int gameSpeed = GameSpeed;
							if (gameSpeed > 0)
							{
								CommandCoreInterop.MainGameLoopRTMP(this, scenario_0, gameSpeed);
							}
							num = Environment.TickCount - num;
							if (num == 0)
							{
								num = 15;
							}
							num2 = (num2 + num) / 2;
							num3++;
							method_55($"Sim Tick: {gameSpeed}s in {num}ms");
							TimeSpan timeSpan4 = scenario_0.Time - scenario_0.StartTime;
							TimeSpan timeSpan5 = scenario_0.Duration - timeSpan4;
							dispatcher_0.BeginInvoke((Delegate)scenarioTimeChangedDelegate_0, (DispatcherPriority)1, new object[3] { gameSpeed, timeSpan4, timeSpan5 });
							method_61();
							concurrentDictionary_6.Clear();
							method_84();
							method_63();
							if (bool_11)
							{
								bool_11 = false;
								method_55("Scenario structure has changed! Execution must pause to update all clients.");
								GameSpeed = 0;
								method_64(scenario_0);
								hashSet_0 = new HashSet<RealtimeClient>(list_4);
							}
							else
							{
								SendMissionsChangedUpdate();
								method_3();
								method_27();
								SendMessageLogUpdate();
								SendSensorUpdates();
								method_30();
								SendConditionUpdate();
								SendReferencePointUpdate();
								SendZoneUpdate();
								SendCourseUpdate();
								SendEmbarkedOpsUpdate();
								SendWeaponSalvos();
								SendSimGroupMembershipUpdates();
								if (PlaySoundEffects)
								{
									SendSoundEffects();
								}
							}
							SendExecutionSync(num3, scenario_0?.Time ?? new DateTime(1900, 1, 1));
							flag = true;
						}
						else
						{
							string scenXML = CommandCoreInterop.ScenarioToXML(scenario_0);
							CS$<>8__locals16.method_0(delegate
							{
								CS$<>8__locals16.realtimeHost_0.method_12(CS$<>8__locals16.realtimeHost_0.scenario_0, "AC begin " + CS$<>8__locals16.realtimeHost_0.realtimeClient_0.Name);
							});
							method_89(realtimeClient_0, new AbsoluteControlGrantedMessage
							{
								ScenXML = scenXML
							}, "HostThreadSubroutine Sending the scenXML to the AC Requester (while unpaused).");
							hostState_0 = HostState.AC;
							method_55(realtimeClient_0?.Name + " has been granted Absolute Control.");
						}
						break;
					case HostState.AC:
						break;
					}
					if (hostState_0 != HostState.AC)
					{
						if (hashSet_0.Any())
						{
							SendStatusUpdate("Pushing state.");
							method_17(hashSet_0, "HostThreadSubroutine pushing state because ClientsWhoNeedImmediatePushState.Any()", bool_14: true);
							hashSet_0.Clear();
						}
						if (!flag)
						{
							concurrentDictionary_6.Clear();
							if (bool_10)
							{
								method_63();
							}
							switch (int_1 % 20)
							{
							case 0:
								method_3();
								break;
							case 5:
								method_27();
								break;
							case 12:
								SendEmbarkedOpsUpdate();
								break;
							case 9:
								SendCourseUpdate();
								break;
							}
							SendConditionUpdate();
							SendReferencePointUpdate();
							SendZoneUpdate();
							SendWeaponSalvos();
							SendSensorUpdates();
							method_30();
							SendMessageLogUpdate();
						}
						if (AutosaveInterval_s > 0 && now > dateTime2)
						{
							CS$<>8__locals16.method_0(delegate
							{
								CS$<>8__locals16.realtimeHost_0.method_12(CS$<>8__locals16.realtimeHost_0.scenario_0);
							});
							dateTime2 = now.AddSeconds(AutosaveInterval_s);
						}
					}
					if (int_1 % 15 == 1)
					{
						SendAllPeerScreenMouseUpdate();
					}
					if (int_1 % 30 == 1)
					{
						SendAllPeerList();
					}
					SendStatusUpdate();
					if (bool_12)
					{
						SendGameOver("The scenario has ended.");
					}
				}
				if (!flag2)
				{
					Thread.Sleep(50);
				}
				continue;
			}
			catch (Exception ex)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				GameGeneral.WriteExceptionsToLog(ex);
				continue;
			}
		}
		method_12(scenario_0, "End State");
	}

	private void method_86(Connection connection_0, byte[] byte_0, string string_3)
	{
		OutgoingPacketStatisticsTracker?.TrackOutgoingPacket(string_3, byte_0.Length);
		try
		{
			if (connection_0.ConnectionInfo.ConnectionState == ConnectionState.Established)
			{
				Connection.playFabPartyClient.SendMessage(connection_0.OtherUserID, byte_0);
			}
		}
		catch (Exception ex)
		{
			string string_4 = "ERROR InternalTransmitTo " + method_67(connection_0) + " " + ex.GetType().FullName + " " + ex.Message;
			method_55(string_4);
		}
	}

	private void method_87(RTMessage rtmessage_0, string string_3)
	{
		method_88(list_4.ToList(), rtmessage_0, string_3);
	}

	private void method_88(IList<RealtimeClient> ilist_0, RTMessage rtmessage_0, string string_3)
	{
		rtmessage_0.SimTimeSent = scenario_0?.Time ?? new DateTime(1900, 1, 1);
		if (ilist_0.Count == 0)
		{
			return;
		}
		if (ilist_0.Count() == 1 && ilist_0[0].LoopbackMode)
		{
			ilist_0[0].Loopback.QueueMessage(rtmessage_0, null);
			return;
		}
		byte[] byte_ = RealtimeSerializer.Serialize(rtmessage_0);
		foreach (RealtimeClient item in ilist_0)
		{
			if (item.LoopbackMode)
			{
				item.Loopback.QueueMessage(rtmessage_0, null);
			}
			else
			{
				method_86(item.Connection, byte_, string_3);
			}
		}
	}

	private void method_89(RealtimeClient realtimeClient_1, RTMessage rtmessage_0, string string_3)
	{
		rtmessage_0.SimTimeSent = scenario_0?.Time ?? new DateTime(1900, 1, 1);
		if (realtimeClient_1.LoopbackMode)
		{
			realtimeClient_1.Loopback.QueueMessage(rtmessage_0, null);
			return;
		}
		byte[] byte_ = RealtimeSerializer.Serialize(rtmessage_0);
		method_86(realtimeClient_1.Connection, byte_, string_3);
	}

	static RealtimeHost()
	{
		Class72.smethod_20();
		random_0 = new Random();
		RealtimeHostExists = false;
		object_2 = new object();
	}

	[CompilerGenerated]
	private void method_90(List<RealtimeClient> list_6, List<ActiveUnit> list_7, bool bool_14 = false)
	{
		foreach (ActiveUnit item in list_7)
		{
			string text = method_74(item);
			if (text != null)
			{
				method_88(list_6, new ActiveUnitUpdateMessage
				{
					XML = text,
					HadActiveSensorInLastPulse = item.Sensory.HadActiveSensorInLastPulse
				}, "SendClientsActiveUnitUpdates.XmitActiveUnitUpdateMessage");
				if (item.IsGroup && bool_14)
				{
					SendGroupMembershipUpdate((Group)item);
				}
			}
		}
	}

	[CompilerGenerated]
	internal static bool smethod_0(ActiveUnit au)
	{
		if (au == null)
		{
			return false;
		}
		if (au.IsAircraft)
		{
			return ((Aircraft)au).IsOperating();
		}
		return au.IsOperating();
	}

	[CompilerGenerated]
	private void method_91(List<RealtimeClient> list_6, List<ActiveUnit> list_7)
	{
		if (list_7.Count < 1)
		{
			return;
		}
		int count = list_7.Count;
		List<string> list = new List<string>();
		List<double> list2 = new List<double>();
		List<double> list3 = new List<double>();
		List<float> list4 = new List<float>();
		List<float> list5 = new List<float>();
		List<byte> list6 = new List<byte>();
		List<float> list7 = new List<float>();
		for (int i = 0; i < count; i++)
		{
			if (smethod_0(list_7[i]))
			{
				list.Add(list_7[i].ObjectID);
				list2.Add(((Module_Unit.Unit)list_7[i]).get_Latitude((GlobalVariables.BooleanObject)null));
				list3.Add(((Module_Unit.Unit)list_7[i]).get_Longitude((GlobalVariables.BooleanObject)null));
				list4.Add(list_7[i].CurrentHeading);
				list5.Add(((Module_Unit.Unit)list_7[i]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				list7.Add(list_7[i].CurrentSpeed);
				if (list_7[i].IsAircraft)
				{
					list6.Add((byte)((Aircraft)list_7[i]).AirOps.Condition);
				}
				else
				{
					list6.Add((byte)list_7[i].DockingOps.Condition);
				}
			}
		}
		method_88(list_6, new PositionUpdateMessage
		{
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5,
			Condition = list6,
			Speed = list7
		}, "SendClientsActiveUnitUpdates.XmitActiveUnitStatusMessage");
	}

	[CompilerGenerated]
	private void method_92(List<RealtimeClient> list_6, List<ActiveUnit> list_7, bool bool_14 = false)
	{
		if (list_7.Count < 1)
		{
			return;
		}
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		for (int i = 0; i < count; i++)
		{
			list.Add(list_7[i].ObjectID);
			if (list_7[i].IsGroup && bool_14)
			{
				SendGroupMembershipUpdate((Group)list_7[i]);
			}
		}
		method_88(list_6, new ActiveUnitRemoveMessage
		{
			ObjectID = list
		}, "SendClientsActiveUnitUpdates.XmitActiveUnitRemoveMessage");
	}

	[CompilerGenerated]
	private void method_93(List<RealtimeClient> list_6, Side side_0, List<Contact> list_7)
	{
		if (list_7.Count >= 1)
		{
			int count = list_7.Count;
			List<string> list = new List<string>(count);
			List<int> list2 = new List<int>(count);
			for (int i = 0; i < count; i++)
			{
				list.Add(method_75(list_7[i]));
				list2.Add(list_7[i].get_KnownIncomingGuidedWeaponsCount(side_0));
			}
			method_88(list_6, new ContactAddOrUpdateMessage
			{
				XMLs = list,
				KnownIncomingGuidedWeaponsCount = list2
			}, "SendClientsContactUpdates.XmitContactUpdateMessage");
		}
	}

	[CompilerGenerated]
	private void method_94(List<RealtimeClient> list_6, Side side_0, List<Contact> list_7)
	{
		if (list_7.Count < 1)
		{
			return;
		}
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		List<double> list2 = new List<double>(count);
		List<double> list3 = new List<double>(count);
		List<float> list4 = new List<float>(count);
		List<float> list5 = new List<float>(count);
		List<float> list6 = new List<float>(count);
		List<float> list7 = new List<float>(count);
		List<bool> list8 = new List<bool>(count);
		List<bool> list9 = new List<bool>(count);
		List<bool> list10 = new List<bool>(count);
		List<bool> list11 = new List<bool>(count);
		List<List<ContactStatusMessage.UncertaintyElement>> list12 = new List<List<ContactStatusMessage.UncertaintyElement>>(count);
		List<string> list13 = new List<string>(count);
		List<int> list14 = new List<int>(count);
		List<int> list15 = new List<int>(count);
		List<bool> list16 = new List<bool>(count);
		List<int> list17 = new List<int>(count);
		for (int i = 0; i < count; i++)
		{
			list.Add(list_7[i]._ActualUnitID);
			list2.Add(((Module_Unit.Unit)list_7[i]).get_Latitude((GlobalVariables.BooleanObject)null));
			list3.Add(((Module_Unit.Unit)list_7[i]).get_Longitude((GlobalVariables.BooleanObject)null));
			list4.Add(list_7[i].CurrentHeading);
			list5.Add(((Module_Unit.Unit)list_7[i]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			list6.Add(list_7[i].Altitude_old);
			list7.Add(list_7[i].CurrentSpeed);
			list8.Add(list_7[i].SpeedIsKnown);
			list9.Add(list_7[i].HeadingIsKnown);
			list10.Add(list_7[i].AltitudeIsKnown);
			list11.Add(list_7[i].SideIsKnown);
			list13.Add(list_7[i].Name);
			list14.Add((int)list_7[i].Age);
			list15.Add((int)list_7[i].get_Stance(side_0));
			list16.Add(list_7[i].IsFilteredOut);
			list17.Add(list_7[i].get_KnownIncomingGuidedWeaponsCount(side_0));
			if (list_7[i].UncertaintyArea == null)
			{
				list12.Add(new List<ContactStatusMessage.UncertaintyElement>());
			}
			else
			{
				list12.Add(list_7[i].UncertaintyArea.Select(Helper.ToUncertaintyElement).ToList());
			}
		}
		method_88(list_6, new ContactStatusMessage
		{
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5,
			Altitude_Old = list6,
			Speed = list7,
			SpeedIsKnown = list8,
			HeadingIsKnown = list9,
			AltitudeIsKnown = list10,
			SideIsKnown = list11,
			UncertaintyArea = list12,
			Name = list13,
			Age = list14,
			Stance = list15,
			IsFilteredOut = list16,
			KnownIncomingGuidedWeaponsCount = list17
		}, "SendClientsContactUpdates.XmitContactStatusMessage");
	}

	[CompilerGenerated]
	private void method_95(List<RealtimeClient> list_6, List<string> list_7)
	{
		if (list_7.Count >= 1)
		{
			method_88(list_6, new ContactRemoveMessage
			{
				ObjectID = list_7
			}, "SendClientsContactUpdates.XmitContactRemoveMessage");
		}
	}

	[CompilerGenerated]
	private void method_96(List<RealtimeClient> list_6, List<Contact> list_7)
	{
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		new List<int>(count);
		List<double> list2 = new List<double>(count);
		List<double> list3 = new List<double>(count);
		List<float> list4 = new List<float>(count);
		List<float> list5 = new List<float>(count);
		for (int i = 0; i < count; i++)
		{
			if (list_7[i].ActualUnit == null)
			{
				list.Add(list_7[i].ObjectID);
			}
			else
			{
				list.Add(list_7[i].ActualUnit.ObjectID);
			}
			list2.Add(((Module_Unit.Unit)list_7[i]).get_Latitude((GlobalVariables.BooleanObject)null));
			list3.Add(((Module_Unit.Unit)list_7[i]).get_Longitude((GlobalVariables.BooleanObject)null));
			list4.Add(list_7[i].CurrentHeading);
			list5.Add(((Module_Unit.Unit)list_7[i]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
		method_88(list_6, new IntermediatePositionUpdateMessage
		{
			ObjectType = 2,
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5
		}, "SendPositionUpdate");
	}

	[CompilerGenerated]
	internal static void smethod_1(ActiveUnit host, ActiveUnit parasite, ref <>c__DisplayClass88_0 <>c__DisplayClass88_0_0)
	{
		string objectID = host.ObjectID;
		string objectID2 = parasite.ObjectID;
		if (!<>c__DisplayClass88_0_0.dictionary_0.ContainsKey(objectID))
		{
			<>c__DisplayClass88_0_0.dictionary_0[objectID] = new HashSet<string>();
		}
		<>c__DisplayClass88_0_0.dictionary_0[objectID].Add(objectID2);
		<>c__DisplayClass88_0_0.hashSet_0.Add(host);
	}

	[CompilerGenerated]
	private void method_97(List<RealtimeClient> list_6, List<ActiveUnit> list_7)
	{
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		List<double> list2 = new List<double>(count);
		List<double> list3 = new List<double>(count);
		List<float> list4 = new List<float>(count);
		List<float> list5 = new List<float>(count);
		for (int i = 0; i < count; i++)
		{
			list.Add(list_7[i].ObjectID);
			list2.Add(((Module_Unit.Unit)list_7[i]).get_Latitude((GlobalVariables.BooleanObject)null));
			list3.Add(((Module_Unit.Unit)list_7[i]).get_Longitude((GlobalVariables.BooleanObject)null));
			list4.Add(list_7[i].CurrentHeading);
			list5.Add(((Module_Unit.Unit)list_7[i]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
		method_88(list_6, new PositionUpdateMessage
		{
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5
		}, "SendPositionUpdate");
	}

	[CompilerGenerated]
	private void method_98(List<RealtimeClient> list_6, List<ActiveUnit> list_7)
	{
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		new List<int>(count);
		List<double> list2 = new List<double>(count);
		List<double> list3 = new List<double>(count);
		List<float> list4 = new List<float>(count);
		List<float> list5 = new List<float>(count);
		for (int i = 0; i < count; i++)
		{
			list.Add(list_7[i].ObjectID);
			list2.Add(((Module_Unit.Unit)list_7[i]).get_Latitude((GlobalVariables.BooleanObject)null));
			list3.Add(((Module_Unit.Unit)list_7[i]).get_Longitude((GlobalVariables.BooleanObject)null));
			list4.Add(list_7[i].CurrentHeading);
			list5.Add(((Module_Unit.Unit)list_7[i]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
		method_88(list_6, new IntermediatePositionUpdateMessage
		{
			ObjectType = 0,
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5
		}, "SendPositionUpdate");
	}

	[CompilerGenerated]
	private void method_99(List<RealtimeClient> list_6, ActiveUnit activeUnit_0)
	{
		List<string> list = new List<string>(1);
		List<double> list2 = new List<double>(1);
		List<double> list3 = new List<double>(1);
		List<float> list4 = new List<float>(1);
		List<float> list5 = new List<float>(1);
		list.Add(activeUnit_0.ObjectID);
		list2.Add(((Module_Unit.Unit)activeUnit_0).get_Latitude((GlobalVariables.BooleanObject)null));
		list3.Add(((Module_Unit.Unit)activeUnit_0).get_Longitude((GlobalVariables.BooleanObject)null));
		list4.Add(activeUnit_0.CurrentHeading);
		list5.Add(((Module_Unit.Unit)activeUnit_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		method_88(list_6, new PositionUpdateMessage
		{
			ObjectID = list,
			Latitude = list2,
			Longitude = list3,
			Heading = list4,
			Altitude = list5
		}, "TeleportUnit");
	}

	[CompilerGenerated]
	private void method_100(List<RealtimeClient> list_6, List<Side> list_7)
	{
		if (!list_7.Any() || !list_6.Any())
		{
			return;
		}
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		List<List<string>> list2 = new List<List<string>>(count);
		List<List<double>> list3 = new List<List<double>>(count);
		List<List<double>> list4 = new List<List<double>>(count);
		List<List<string>> list5 = new List<List<string>>(count);
		List<List<bool>> list6 = new List<List<bool>>(count);
		List<List<string>> list7 = new List<List<string>>(count);
		List<List<float>> list8 = new List<List<float>>(count);
		List<List<float>> list9 = new List<List<float>>(count);
		List<List<byte>> list10 = new List<List<byte>>(count);
		List<List<bool>> list11 = new List<List<bool>>(count);
		List<List<int>> list12 = new List<List<int>>(count);
		List<List<int>> list13 = new List<List<int>>(count);
		List<List<long?>> list14 = new List<List<long?>>(count);
		List<List<long?>> list15 = new List<List<long?>>(count);
		List<List<bool>> list16 = new List<List<bool>>(count);
		List<List<bool>> list17 = new List<List<bool>>(count);
		for (int i = 0; i < count; i++)
		{
			Side side = list_7[i];
			List<ReferencePoint> list18 = side.RefPoints.ToList();
			int count2 = list18.Count;
			List<string> list19 = new List<string>(count2);
			List<double> list20 = new List<double>(count2);
			List<double> list21 = new List<double>(count2);
			List<string> list22 = new List<string>(count2);
			List<bool> list23 = new List<bool>(count2);
			List<string> list24 = new List<string>(count2);
			List<float> list25 = new List<float>(count2);
			List<float> list26 = new List<float>(count2);
			List<byte> list27 = new List<byte>(count2);
			List<bool> list28 = new List<bool>(count2);
			List<int> list29 = new List<int>(count);
			List<int> list30 = new List<int>(count);
			List<List<string>> list31 = new List<List<string>>(count);
			List<long?> list32 = new List<long?>(count);
			List<long?> list33 = new List<long?>(count);
			List<bool> list34 = new List<bool>(count);
			List<bool> list35 = new List<bool>(count);
			for (int j = 0; j < count2; j++)
			{
				list19.Add(list18[j].ObjectID);
				list20.Add(list18[j].Latitude);
				list21.Add(list18[j].Longitude);
				list22.Add(list18[j].Name);
				list23.Add(list18[j].IsHighlighted);
				if (list18[j].IsRelativeTo == null)
				{
					list24.Add("");
				}
				else
				{
					list24.Add(list18[j].IsRelativeTo.ObjectID);
				}
				list25.Add(list18[j].RelativeBearing);
				list26.Add(list18[j].RelativeDistance);
				list27.Add((byte)list18[j].BearingType);
				list28.Add(list18[j].IsLocked);
				list31.Add(list18[j].TagsByGuid_Raw.ToList());
				list29.Add(list18[j].color.ToArgb());
				list30.Add((int)list18[j].RenderGroup);
				list32.Add((!list18[j].Expiration.HasValue) ? ((long?)null) : new long?(list18[j].Expiration.Value.Ticks));
				list33.Add((!list18[j].Expiration.HasValue) ? ((long?)null) : new long?(list18[j].Expiration.Value.Ticks));
				list34.Add(list18[j].Fades);
				list35.Add(list18[j].ForceMinimize);
			}
			list.Add(side.ObjectID);
			list2.Add(list19);
			list3.Add(list20);
			list4.Add(list21);
			list5.Add(list22);
			list6.Add(list23);
			list7.Add(list24);
			list8.Add(list25);
			list9.Add(list26);
			list10.Add(list27);
			list11.Add(list28);
			list12.Add(list29);
			list13.Add(list30);
			list14.Add(list32);
			list15.Add(list33);
			list16.Add(list34);
			list17.Add(list35);
		}
		method_88(list_6, new ReferencePointUpdateMessage
		{
			AllObjectID = list2,
			AllLatitude = list3,
			AllLongitude = list4,
			AllName = list5,
			SideID = list,
			AllIsHighlighted = list6,
			AllRelativeUnitID = list7,
			AllRelativeBearing = list8,
			AllRelativeDistance = list9,
			AllBearingType = list10,
			AllIsLocked = list11,
			AllColor = list12,
			AllRenderGroup = list13,
			AllCreationDate = list14,
			AllExpiration = list15,
			AllFades = list16,
			AllForceMinimize = list17
		}, "SendReferencePointUpdate");
	}

	[CompilerGenerated]
	private void method_101(List<RealtimeClient> list_6, List<Side> list_7)
	{
		if (!list_7.Any() || !list_6.Any())
		{
			return;
		}
		int count = list_7.Count;
		List<string> list = new List<string>(count);
		List<List<string>> list2 = new List<List<string>>(count);
		List<List<string>> list3 = new List<List<string>>(count);
		List<List<List<string>>> list4 = new List<List<List<string>>>(count);
		List<List<string>> list5 = new List<List<string>>(count);
		List<List<int>> list6 = new List<List<int>>(count);
		List<List<int>> list7 = new List<List<int>>(count);
		List<List<int>> list8 = new List<List<int>>(count);
		List<List<List<int>>> list9 = new List<List<List<int>>>(count);
		List<List<bool>> list10 = new List<List<bool>>(count);
		List<List<List<(string, int)>>> list11 = new List<List<List<(string, int)>>>(count);
		List<List<int>> list12 = new List<List<int>>(count);
		List<List<float?>> list13 = new List<List<float?>>(count);
		List<List<float?>> list14 = new List<List<float?>>(count);
		List<List<bool>> list15 = new List<List<bool>>(count);
		List<List<bool>> list16 = new List<List<bool>>(count);
		for (int i = 0; i < count; i++)
		{
			Side side = list_7[i];
			List<Zone> list17 = side.StandardZones.ToList();
			list17.AddRange(side.ExclusionZones.ToList());
			list17.AddRange(side.NoNavZones.ToList());
			int count2 = list17.Count;
			List<string> list18 = new List<string>(count2);
			List<string> list19 = new List<string>(count2);
			List<List<string>> list20 = new List<List<string>>(count2);
			List<string> list21 = new List<string>(count2);
			List<int> list22 = new List<int>(count2);
			List<int> list23 = new List<int>(count2);
			List<int> list24 = new List<int>(count2);
			List<List<int>> list25 = new List<List<int>>(count2);
			List<bool> list26 = new List<bool>(count2);
			List<bool> list27 = new List<bool>(count2);
			List<List<(string, int)>> list28 = new List<List<(string, int)>>(count2);
			List<int> list29 = new List<int>(count2);
			List<float?> list30 = new List<float?>(count2);
			List<float?> list31 = new List<float?>(count2);
			List<bool> list32 = new List<bool>(count2);
			for (int j = 0; j < count2; j++)
			{
				list18.Add(list17[j].ObjectID);
				list19.Add(list17[j].Name);
				list20.Add(new List<string>());
				foreach (ReferencePoint item in list17[j].Area)
				{
					list20.ElementAt(list20.Count - 1).Add(item.ObjectID);
				}
				list21.Add(list17[j].Description);
				list22.Add(list17[j].get_Layer((Side)null));
				list23.Add((int)list17[j].Type);
				list24.Add(list17[j].AreaColor.ToArgb());
				list26.Add(list17[j].IsActive);
				list27.Add(list17[j].IsLocked);
				list25.Add(new List<int>());
				foreach (GlobalVariables.ActiveUnitType affectedUnitType in list17[j].AffectedUnitTypes)
				{
					list25.ElementAt(list25.Count - 1).Add((int)affectedUnitType);
				}
				switch (list17[j].Type)
				{
				case Zone.ZoneType.Zone:
					list32.Add(item: false);
					list28.Add(new List<(string, int)>());
					list29.Add(0);
					list30.Add(null);
					list31.Add(null);
					break;
				case Zone.ZoneType.NoNavZone:
				{
					NoNavZone noNavZone = (NoNavZone)list17[j];
					list32.Add(noNavZone.NoFireZone);
					list28.Add(new List<(string, int)>());
					list29.Add(0);
					list30.Add(null);
					list31.Add(null);
					break;
				}
				case Zone.ZoneType.ExclusionZone:
				{
					ExclusionZone exclusionZone = (ExclusionZone)list17[j];
					list28.Add(new List<(string, int)>());
					foreach (KeyValuePair<string, Command_Core.Misc.PostureStance> item2 in exclusionZone.ViolatorsStance)
					{
						list28.ElementAt(list25.Count - 1).Add((item2.Key, (int)item2.Value));
					}
					list29.Add((int)exclusionZone.MarkViolatorAs);
					list30.Add(exclusionZone.AltitudeEnvelopeMin);
					list31.Add(exclusionZone.AltitudeEnvelopeMax);
					list32.Add(item: false);
					break;
				}
				}
			}
			list.Add(side.ObjectID);
			list2.Add(list18);
			list3.Add(list19);
			list4.Add(list20);
			list5.Add(list21);
			list6.Add(list22);
			list7.Add(list23);
			list8.Add(list24);
			list9.Add(list25);
			list10.Add(list26);
			list11.Add(list28);
			list12.Add(list29);
			list13.Add(list30);
			list14.Add(list31);
			list15.Add(list32);
			list16.Add(list27);
		}
		method_88(list_6, new ZoneUpdateMessage
		{
			AllObjectID = list2,
			SideID = list,
			AllName = list3,
			AllRPs = list4,
			AllDescription = list5,
			AllLayer = list6,
			AllType = list7,
			AllColor = list8,
			AllAffectedUnitTypes = list9,
			AllIsActive = list10,
			AllViolatorsStance = list11,
			AllMarkViolatorAs = list12,
			AllAltitudeEnvelopeMin = list13,
			AllAltitudeEnvelopeMax = list14,
			AllNoFireZone = list15,
			AllIsLocked = list16
		}, "SendZoneUpdate");
	}

	[CompilerGenerated]
	private void method_102(object object_3, uint uint_1)
	{
		method_83(new Connection(uint_1));
	}

	[CompilerGenerated]
	private void method_103(object object_3, uint uint_1)
	{
		RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection.OtherUserID == uint_1);
		if (realtimeClient != null)
		{
			method_82(realtimeClient.Connection);
		}
	}

	[CompilerGenerated]
	private void method_104(object sender, ByteArrayMessageEventArgs e)
	{
		RealtimeClient realtimeClient = list_4.FirstOrDefault((RealtimeClient F) => F.Connection.OtherUserID == e.SenderId);
		if (realtimeClient != null)
		{
			Connection connection = realtimeClient.Connection;
			PacketHeader packetHeader_ = new PacketHeader();
			method_68(packetHeader_, connection, e.Message);
		}
	}
}
