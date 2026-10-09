using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using Command_Core;
using CSMaterial;
using PlayFabParty;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace CommandNetcode.RT;

public class RealtimeTerminal
{
	public delegate void SoundEffectsDelegate(List<int> theSFX);

	public delegate void SelectDelegate(string ObjectID);

	public delegate void ActiveUnitUpdateDelegate(string ObjectID, Waypoint[] newCourse, Waypoint[] newFlightPlan);

	public delegate void AbsoluteControlGrantedDelegate(AbsoluteControlGrantedMessage msg);

	public delegate void AbsoluteControlReleasedDelegate();

	public delegate void AutosavesListReplyDelegate(AutosavesListReplyMessage msg);

	public delegate void GlobalChatDelegate(GlobalChatMessage msg);

	public delegate void LoginResultDelegate(bool result, string msg, string string_0, string DBHash);

	public delegate void ServerInfoDelegate();

	public delegate void PeerListDelegate(PeerListMessage msg);

	public delegate void PushStateDelegate(Scenario CommandScenarioObject, bool isNewScenario);

	public delegate void StatusDelegate(StatusMessage msg);

	public delegate void GameOverDelegate(string Message, bool disconnect);

	public delegate void UIDelegate(UIMessage msg);

	public delegate void WeaponSalvosUpdateDelegate();

	public delegate void ContactFilterChangeDelegate(short Filter, bool State);

	public delegate void ContactUpdateDelegate(string ObjectID);

	public delegate void CourseUpdateDelegate(Module_Unit.Unit unit, Waypoint[] waypoints);

	public delegate void DoctrineUpdateDelegate(Doctrine doctrine);

	public delegate void ShowWarningDelegate(string message, string title);

	public delegate void MissionEditorEventDelegate(int eventType);

	public delegate void ScoringUpdateDelegate(ScoringInfoType UpdateType, string UpdateInfo);

	public delegate void MessageLogUpdateDelegate();

	public delegate void MissionUpdateDelegate(string ObjectID, bool openEditorWindow);

	public delegate void SmartRPUpdateDelegate(ReferencePoint rp);

	public delegate void SensorsUpdateDelegate();

	public delegate void SideMapPingDelegate(string source, double lat, double lon, ushort flags = 0);

	public delegate void SpecialActionUpdateDelegate(string ObjectID, string Result);

	public delegate void SelectedWaypointUpdateDelegate(Waypoint waypoint, double newLat, double newLon);

	public delegate void ZoneUpdateDelegate(string NewSelectObjectID);

	public delegate void DisconnectedDelegate();

	public delegate void AutoreconnectDelegate();

	public delegate void ConnectedDelegate();

	public delegate void ServerErrorDelegate(string message);

	public delegate void LogTextDelegate(string s);

	public class RealtimePeer
	{
		public string Name;

		public (int, int, int) Color = (255, 255, 255);

		public List<(double, double)> Screen = new List<(double, double)>();

		public (double, double) Mouse = (0.0, 0.0);

		public DateTime LastHeard;

		public DateTime LastClick;

		public TerminalRights TerminalRights;

		public string TerminalLockedSide;

		public string CurrentSideName;

		static RealtimePeer()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass203_0
	{
		public Scenario scenario_0;

		internal ActiveUnit method_0(string objID)
		{
			ActiveUnit value = null;
			scenario_0.ActiveUnits.TryGetValue(objID, out value);
			return value;
		}

		static <>c__DisplayClass203_0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private SoundEffectsDelegate soundEffectsDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private SelectDelegate selectDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ActiveUnitUpdateDelegate activeUnitUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private AbsoluteControlGrantedDelegate absoluteControlGrantedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private AbsoluteControlReleasedDelegate absoluteControlReleasedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private AutosavesListReplyDelegate autosavesListReplyDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private GlobalChatDelegate globalChatDelegate_0 = delegate
	{
	};

	private DateTime dateTime_0 = DateTime.Now;

	private DateTime dateTime_1 = DateTime.Now;

	private PerformanceCounter performanceCounter_0;

	public string ClientName;

	public (int, int, int) ClientColor;

	public bool INIFileExists;

	[CompilerGenerated]
	private LoginResultDelegate loginResultDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ServerInfoDelegate serverInfoDelegate_0 = delegate
	{
	};

	public int LoginAttemptCount;

	public bool LoginSuccessful;

	public const bool DisablePeerTransmit = false;

	private DateTime dateTime_2 = DateTime.Now;

	private DateTime dateTime_3 = DateTime.Now;

	private DateTime dateTime_4 = DateTime.Now;

	[CompilerGenerated]
	private PeerListDelegate peerListDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private PushStateDelegate pushStateDelegate_0 = delegate
	{
	};

	public bool PushStateInProgress;

	private string string_0 = "";

	private string string_1 = "";

	[CompilerGenerated]
	private StatusDelegate statusDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private GameOverDelegate gameOverDelegate_0 = delegate
	{
	};

	private HostState hostState_0;

	[CompilerGenerated]
	private int int_0;

	public bool EmbarkedAirOpsNewDataReceived;

	public bool EmbarkedDockingOpsNewDataReceived;

	public string AC_Requester_Name;

	[CompilerGenerated]
	private UIDelegate uidelegate_0 = delegate
	{
	};

	private static volatile uint uint_0;

	private volatile bool bool_1;

	[CompilerGenerated]
	private WeaponSalvosUpdateDelegate weaponSalvosUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ContactFilterChangeDelegate contactFilterChangeDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ContactUpdateDelegate contactUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private CourseUpdateDelegate courseUpdateDelegate_0 = delegate
	{
	};

	private uint uint_1;

	private List<string> list_0 = new List<string>();

	[CompilerGenerated]
	private DoctrineUpdateDelegate doctrineUpdateDelegate_0 = delegate
	{
	};

	private readonly object object_0 = new object();

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private Dictionary<ActiveUnit, HashSet<ActiveUnit>> dictionary_1 = new Dictionary<ActiveUnit, HashSet<ActiveUnit>>();

	private Dictionary<string, int> dictionary_2 = new Dictionary<string, int>();

	private Dictionary<string, int> dictionary_3 = new Dictionary<string, int>();

	[CompilerGenerated]
	private ShowWarningDelegate showWarningDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private MissionEditorEventDelegate missionEditorEventDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ScoringUpdateDelegate scoringUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private MessageLogUpdateDelegate messageLogUpdateDelegate_0 = delegate
	{
	};

	public static int ActiveDeserializationCount;

	[CompilerGenerated]
	private MissionUpdateDelegate missionUpdateDelegate_0 = delegate
	{
	};

	private readonly object object_1 = new object();

	private Dictionary<string, string> dictionary_4 = new Dictionary<string, string>();

	private TList<IntermediatePositionUpdateMessage> tlist_0 = new TList<IntermediatePositionUpdateMessage>(useReadLock: true);

	[CompilerGenerated]
	private SmartRPUpdateDelegate smartRPUpdateDelegate_0 = delegate
	{
	};

	private uint uint_2;

	private List<string> list_1 = new List<string>();

	private List<ReferencePoint> list_2 = new List<ReferencePoint>();

	[CompilerGenerated]
	private SensorsUpdateDelegate sensorsUpdateDelegate_0 = delegate
	{
	};

	private uint uint_3;

	private List<string> list_3 = new List<string>();

	[CompilerGenerated]
	private SideMapPingDelegate sideMapPingDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private SpecialActionUpdateDelegate specialActionUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private SelectedWaypointUpdateDelegate selectedWaypointUpdateDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ZoneUpdateDelegate zoneUpdateDelegate_0 = delegate
	{
	};

	private string string_2 = "";

	public static bool LobbyConnectionRequested;

	public static string LobbyRoutingServerIP;

	public static int LobbyRoutingServerPort;

	public static uint LobbyMyUserID;

	public static uint LobbyServerUserID;

	public static string SerializedNetworID;

	public static string InviteCode;

	public static bool ScenarioBriefingShown;

	[CompilerGenerated]
	private TerminalRights terminalRights_0 = TerminalRights.Umpire;

	[CompilerGenerated]
	private string string_3 = "";

	[CompilerGenerated]
	private string string_4 = "";

	[CompilerGenerated]
	private List<string> list_4 = new List<string>();

	[CompilerGenerated]
	private bool bool_2 = true;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private bool bool_7 = true;

	private ITimingGraph itimingGraph_0;

	private Dispatcher dispatcher_0;

	public InOutDisplay InOutDisplay;

	[CompilerGenerated]
	private DisconnectedDelegate disconnectedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private AutoreconnectDelegate autoreconnectDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ConnectedDelegate connectedDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private ServerErrorDelegate serverErrorDelegate_0 = delegate
	{
	};

	[CompilerGenerated]
	private Connection connection_0;

	private Guid bIeLagkLoHA = Guid.Empty;

	private volatile bool bool_8;

	[CompilerGenerated]
	private LogTextDelegate logTextDelegate_0 = delegate
	{
	};

	private readonly object object_2 = new object();

	[CompilerGenerated]
	private Scenario scenario_0;

	public List<RealtimePeer> Peers = new List<RealtimePeer>();

	public string DefaultIP = "127.0.0.1";

	public int DefaultPort = 9000;

	private RealtimeHost realtimeHost_0;

	public readonly object TerminalLockObj = new object();

	public readonly object TerminalRenderLockObj = new object();

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private int int_1;

	public static PlayFabPartyClient SlitherineRouterClient;

	private Thread thread_0;

	private volatile bool bool_9;

	public static float RT_INTERPOLATION_SPEED_MIN;

	private ConcurrentDictionary<string, DateTime> concurrentDictionary_0 = new ConcurrentDictionary<string, DateTime>();

	public uint currentHostSimExecutionStep;

	public DateTime currentHostScenarioTime = new DateTime(1900, 1, 1);

	public DateTime previousHostScenarioTime = new DateTime(1900, 1, 1);

	public int hostScenarioElapsedTime;

	public float hostRealTimeRatio = 1f;

	public int lastHostUpdateTickTime;

	public int lastHostUpdateTickDuration = 1000;

	public DateTime lastLocalScenarioTime = new DateTime(1900, 1, 1);

	public int lastLocalTickTime;

	public static float DEFAULT_TICK_STEP_MS;

	public bool InterpolateUnitPositions = true;

	public bool InterpolateAmbiguousContactPositions;

	public int InterpolationInterval_Fast_ms = 100;

	public int InterpolationInterval_Slow_ms = 1000;

	private volatile int int_2;

	private volatile int int_3;

	private ConcurrentQueue<Tuple<RTMessage, Connection>> concurrentQueue_0 = new ConcurrentQueue<Tuple<RTMessage, Connection>>();

	private ConcurrentQueue<RTMessage> concurrentQueue_1 = new ConcurrentQueue<RTMessage>();

	private Thread thread_1;

	private Thread thread_2;

	private volatile int int_4;

	private volatile int int_5;

	private string string_6 = string.Empty;

	private string string_7 = string.Empty;

	private DateTime dateTime_5 = DateTime.MinValue;

	public bool HasAbsoluteControl
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		private set
		{
			bool_0 = value;
		}
	}

	public TimeSpan Latency
	{
		get
		{
			TimeSpan timeSpan = dateTime_1 - dateTime_0;
			if (!(timeSpan < TimeSpan.Zero))
			{
				return timeSpan;
			}
			return TimeSpan.Zero;
		}
	}

	public HostState LastHostState => hostState_0;

	public int LastGameSpeed
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		internal set
		{
			int_0 = value;
		}
	}

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
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public string ServerScenarioTitle
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public List<string> ServerScenarioPlayableSideNames
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		set
		{
			list_4 = value;
		}
	}

	public bool ShowPeerViewports
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool LoginPrompt
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool AllowAC
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

	public bool AllowCreateAutoSave
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool AllowLoadAutoSave
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool AllowChangeSimSpeed
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public Scenario ClientScenario
	{
		[CompilerGenerated]
		get
		{
			return scenario_0;
		}
		[CompilerGenerated]
		private set
		{
			scenario_0 = value;
		}
	}

	public bool LoopbackMode => realtimeHost_0 != null;

	public string IP
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		internal set
		{
			string_5 = value;
		}
	}

	public int port
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		internal set
		{
			int_1 = value;
		}
	}

	public int TrafficWaitingForLock => int_2;

	public int MessageCounter => int_3;

	public event SoundEffectsDelegate SoundEffectsEvent
	{
		[CompilerGenerated]
		add
		{
			SoundEffectsDelegate soundEffectsDelegate = soundEffectsDelegate_0;
			SoundEffectsDelegate soundEffectsDelegate2;
			do
			{
				soundEffectsDelegate2 = soundEffectsDelegate;
				SoundEffectsDelegate value2 = (SoundEffectsDelegate)Delegate.Combine(soundEffectsDelegate2, value);
				soundEffectsDelegate = Interlocked.CompareExchange(ref soundEffectsDelegate_0, value2, soundEffectsDelegate2);
			}
			while ((object)soundEffectsDelegate != soundEffectsDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SoundEffectsDelegate soundEffectsDelegate = soundEffectsDelegate_0;
			SoundEffectsDelegate soundEffectsDelegate2;
			do
			{
				soundEffectsDelegate2 = soundEffectsDelegate;
				SoundEffectsDelegate value2 = (SoundEffectsDelegate)Delegate.Remove(soundEffectsDelegate2, value);
				soundEffectsDelegate = Interlocked.CompareExchange(ref soundEffectsDelegate_0, value2, soundEffectsDelegate2);
			}
			while ((object)soundEffectsDelegate != soundEffectsDelegate2);
		}
	}

	public event SelectDelegate SelectEvent
	{
		[CompilerGenerated]
		add
		{
			SelectDelegate selectDelegate = selectDelegate_0;
			SelectDelegate selectDelegate2;
			do
			{
				selectDelegate2 = selectDelegate;
				SelectDelegate value2 = (SelectDelegate)Delegate.Combine(selectDelegate2, value);
				selectDelegate = Interlocked.CompareExchange(ref selectDelegate_0, value2, selectDelegate2);
			}
			while ((object)selectDelegate != selectDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SelectDelegate selectDelegate = selectDelegate_0;
			SelectDelegate selectDelegate2;
			do
			{
				selectDelegate2 = selectDelegate;
				SelectDelegate value2 = (SelectDelegate)Delegate.Remove(selectDelegate2, value);
				selectDelegate = Interlocked.CompareExchange(ref selectDelegate_0, value2, selectDelegate2);
			}
			while ((object)selectDelegate != selectDelegate2);
		}
	}

	public event ActiveUnitUpdateDelegate ActiveUnitUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			ActiveUnitUpdateDelegate activeUnitUpdateDelegate = activeUnitUpdateDelegate_0;
			ActiveUnitUpdateDelegate activeUnitUpdateDelegate2;
			do
			{
				activeUnitUpdateDelegate2 = activeUnitUpdateDelegate;
				ActiveUnitUpdateDelegate value2 = (ActiveUnitUpdateDelegate)Delegate.Combine(activeUnitUpdateDelegate2, value);
				activeUnitUpdateDelegate = Interlocked.CompareExchange(ref activeUnitUpdateDelegate_0, value2, activeUnitUpdateDelegate2);
			}
			while ((object)activeUnitUpdateDelegate != activeUnitUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ActiveUnitUpdateDelegate activeUnitUpdateDelegate = activeUnitUpdateDelegate_0;
			ActiveUnitUpdateDelegate activeUnitUpdateDelegate2;
			do
			{
				activeUnitUpdateDelegate2 = activeUnitUpdateDelegate;
				ActiveUnitUpdateDelegate value2 = (ActiveUnitUpdateDelegate)Delegate.Remove(activeUnitUpdateDelegate2, value);
				activeUnitUpdateDelegate = Interlocked.CompareExchange(ref activeUnitUpdateDelegate_0, value2, activeUnitUpdateDelegate2);
			}
			while ((object)activeUnitUpdateDelegate != activeUnitUpdateDelegate2);
		}
	}

	public event AbsoluteControlGrantedDelegate AbsoluteControlGrantedEvent
	{
		[CompilerGenerated]
		add
		{
			AbsoluteControlGrantedDelegate absoluteControlGrantedDelegate = absoluteControlGrantedDelegate_0;
			AbsoluteControlGrantedDelegate absoluteControlGrantedDelegate2;
			do
			{
				absoluteControlGrantedDelegate2 = absoluteControlGrantedDelegate;
				AbsoluteControlGrantedDelegate value2 = (AbsoluteControlGrantedDelegate)Delegate.Combine(absoluteControlGrantedDelegate2, value);
				absoluteControlGrantedDelegate = Interlocked.CompareExchange(ref absoluteControlGrantedDelegate_0, value2, absoluteControlGrantedDelegate2);
			}
			while ((object)absoluteControlGrantedDelegate != absoluteControlGrantedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AbsoluteControlGrantedDelegate absoluteControlGrantedDelegate = absoluteControlGrantedDelegate_0;
			AbsoluteControlGrantedDelegate absoluteControlGrantedDelegate2;
			do
			{
				absoluteControlGrantedDelegate2 = absoluteControlGrantedDelegate;
				AbsoluteControlGrantedDelegate value2 = (AbsoluteControlGrantedDelegate)Delegate.Remove(absoluteControlGrantedDelegate2, value);
				absoluteControlGrantedDelegate = Interlocked.CompareExchange(ref absoluteControlGrantedDelegate_0, value2, absoluteControlGrantedDelegate2);
			}
			while ((object)absoluteControlGrantedDelegate != absoluteControlGrantedDelegate2);
		}
	}

	public event AbsoluteControlReleasedDelegate AbsoluteControlReleasedEvent
	{
		[CompilerGenerated]
		add
		{
			AbsoluteControlReleasedDelegate absoluteControlReleasedDelegate = absoluteControlReleasedDelegate_0;
			AbsoluteControlReleasedDelegate absoluteControlReleasedDelegate2;
			do
			{
				absoluteControlReleasedDelegate2 = absoluteControlReleasedDelegate;
				AbsoluteControlReleasedDelegate value2 = (AbsoluteControlReleasedDelegate)Delegate.Combine(absoluteControlReleasedDelegate2, value);
				absoluteControlReleasedDelegate = Interlocked.CompareExchange(ref absoluteControlReleasedDelegate_0, value2, absoluteControlReleasedDelegate2);
			}
			while ((object)absoluteControlReleasedDelegate != absoluteControlReleasedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AbsoluteControlReleasedDelegate absoluteControlReleasedDelegate = absoluteControlReleasedDelegate_0;
			AbsoluteControlReleasedDelegate absoluteControlReleasedDelegate2;
			do
			{
				absoluteControlReleasedDelegate2 = absoluteControlReleasedDelegate;
				AbsoluteControlReleasedDelegate value2 = (AbsoluteControlReleasedDelegate)Delegate.Remove(absoluteControlReleasedDelegate2, value);
				absoluteControlReleasedDelegate = Interlocked.CompareExchange(ref absoluteControlReleasedDelegate_0, value2, absoluteControlReleasedDelegate2);
			}
			while ((object)absoluteControlReleasedDelegate != absoluteControlReleasedDelegate2);
		}
	}

	public event AutosavesListReplyDelegate AutosavesListReplyEvent
	{
		[CompilerGenerated]
		add
		{
			AutosavesListReplyDelegate autosavesListReplyDelegate = autosavesListReplyDelegate_0;
			AutosavesListReplyDelegate autosavesListReplyDelegate2;
			do
			{
				autosavesListReplyDelegate2 = autosavesListReplyDelegate;
				AutosavesListReplyDelegate value2 = (AutosavesListReplyDelegate)Delegate.Combine(autosavesListReplyDelegate2, value);
				autosavesListReplyDelegate = Interlocked.CompareExchange(ref autosavesListReplyDelegate_0, value2, autosavesListReplyDelegate2);
			}
			while ((object)autosavesListReplyDelegate != autosavesListReplyDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AutosavesListReplyDelegate autosavesListReplyDelegate = autosavesListReplyDelegate_0;
			AutosavesListReplyDelegate autosavesListReplyDelegate2;
			do
			{
				autosavesListReplyDelegate2 = autosavesListReplyDelegate;
				AutosavesListReplyDelegate value2 = (AutosavesListReplyDelegate)Delegate.Remove(autosavesListReplyDelegate2, value);
				autosavesListReplyDelegate = Interlocked.CompareExchange(ref autosavesListReplyDelegate_0, value2, autosavesListReplyDelegate2);
			}
			while ((object)autosavesListReplyDelegate != autosavesListReplyDelegate2);
		}
	}

	public event GlobalChatDelegate GlobalChatEvent
	{
		[CompilerGenerated]
		add
		{
			GlobalChatDelegate globalChatDelegate = globalChatDelegate_0;
			GlobalChatDelegate globalChatDelegate2;
			do
			{
				globalChatDelegate2 = globalChatDelegate;
				GlobalChatDelegate value2 = (GlobalChatDelegate)Delegate.Combine(globalChatDelegate2, value);
				globalChatDelegate = Interlocked.CompareExchange(ref globalChatDelegate_0, value2, globalChatDelegate2);
			}
			while ((object)globalChatDelegate != globalChatDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GlobalChatDelegate globalChatDelegate = globalChatDelegate_0;
			GlobalChatDelegate globalChatDelegate2;
			do
			{
				globalChatDelegate2 = globalChatDelegate;
				GlobalChatDelegate value2 = (GlobalChatDelegate)Delegate.Remove(globalChatDelegate2, value);
				globalChatDelegate = Interlocked.CompareExchange(ref globalChatDelegate_0, value2, globalChatDelegate2);
			}
			while ((object)globalChatDelegate != globalChatDelegate2);
		}
	}

	public event LoginResultDelegate LoginResultEvent
	{
		[CompilerGenerated]
		add
		{
			LoginResultDelegate loginResultDelegate = loginResultDelegate_0;
			LoginResultDelegate loginResultDelegate2;
			do
			{
				loginResultDelegate2 = loginResultDelegate;
				LoginResultDelegate value2 = (LoginResultDelegate)Delegate.Combine(loginResultDelegate2, value);
				loginResultDelegate = Interlocked.CompareExchange(ref loginResultDelegate_0, value2, loginResultDelegate2);
			}
			while ((object)loginResultDelegate != loginResultDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			LoginResultDelegate loginResultDelegate = loginResultDelegate_0;
			LoginResultDelegate loginResultDelegate2;
			do
			{
				loginResultDelegate2 = loginResultDelegate;
				LoginResultDelegate value2 = (LoginResultDelegate)Delegate.Remove(loginResultDelegate2, value);
				loginResultDelegate = Interlocked.CompareExchange(ref loginResultDelegate_0, value2, loginResultDelegate2);
			}
			while ((object)loginResultDelegate != loginResultDelegate2);
		}
	}

	public event ServerInfoDelegate ServerInfoUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			ServerInfoDelegate serverInfoDelegate = serverInfoDelegate_0;
			ServerInfoDelegate serverInfoDelegate2;
			do
			{
				serverInfoDelegate2 = serverInfoDelegate;
				ServerInfoDelegate value2 = (ServerInfoDelegate)Delegate.Combine(serverInfoDelegate2, value);
				serverInfoDelegate = Interlocked.CompareExchange(ref serverInfoDelegate_0, value2, serverInfoDelegate2);
			}
			while ((object)serverInfoDelegate != serverInfoDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ServerInfoDelegate serverInfoDelegate = serverInfoDelegate_0;
			ServerInfoDelegate serverInfoDelegate2;
			do
			{
				serverInfoDelegate2 = serverInfoDelegate;
				ServerInfoDelegate value2 = (ServerInfoDelegate)Delegate.Remove(serverInfoDelegate2, value);
				serverInfoDelegate = Interlocked.CompareExchange(ref serverInfoDelegate_0, value2, serverInfoDelegate2);
			}
			while ((object)serverInfoDelegate != serverInfoDelegate2);
		}
	}

	public event PeerListDelegate PeerListEvent
	{
		[CompilerGenerated]
		add
		{
			PeerListDelegate peerListDelegate = peerListDelegate_0;
			PeerListDelegate peerListDelegate2;
			do
			{
				peerListDelegate2 = peerListDelegate;
				PeerListDelegate value2 = (PeerListDelegate)Delegate.Combine(peerListDelegate2, value);
				peerListDelegate = Interlocked.CompareExchange(ref peerListDelegate_0, value2, peerListDelegate2);
			}
			while ((object)peerListDelegate != peerListDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			PeerListDelegate peerListDelegate = peerListDelegate_0;
			PeerListDelegate peerListDelegate2;
			do
			{
				peerListDelegate2 = peerListDelegate;
				PeerListDelegate value2 = (PeerListDelegate)Delegate.Remove(peerListDelegate2, value);
				peerListDelegate = Interlocked.CompareExchange(ref peerListDelegate_0, value2, peerListDelegate2);
			}
			while ((object)peerListDelegate != peerListDelegate2);
		}
	}

	public event PushStateDelegate PushStateEvent
	{
		[CompilerGenerated]
		add
		{
			PushStateDelegate pushStateDelegate = pushStateDelegate_0;
			PushStateDelegate pushStateDelegate2;
			do
			{
				pushStateDelegate2 = pushStateDelegate;
				PushStateDelegate value2 = (PushStateDelegate)Delegate.Combine(pushStateDelegate2, value);
				pushStateDelegate = Interlocked.CompareExchange(ref pushStateDelegate_0, value2, pushStateDelegate2);
			}
			while ((object)pushStateDelegate != pushStateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			PushStateDelegate pushStateDelegate = pushStateDelegate_0;
			PushStateDelegate pushStateDelegate2;
			do
			{
				pushStateDelegate2 = pushStateDelegate;
				PushStateDelegate value2 = (PushStateDelegate)Delegate.Remove(pushStateDelegate2, value);
				pushStateDelegate = Interlocked.CompareExchange(ref pushStateDelegate_0, value2, pushStateDelegate2);
			}
			while ((object)pushStateDelegate != pushStateDelegate2);
		}
	}

	public event StatusDelegate StatusEvent
	{
		[CompilerGenerated]
		add
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Combine(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			StatusDelegate statusDelegate = statusDelegate_0;
			StatusDelegate statusDelegate2;
			do
			{
				statusDelegate2 = statusDelegate;
				StatusDelegate value2 = (StatusDelegate)Delegate.Remove(statusDelegate2, value);
				statusDelegate = Interlocked.CompareExchange(ref statusDelegate_0, value2, statusDelegate2);
			}
			while ((object)statusDelegate != statusDelegate2);
		}
	}

	public event GameOverDelegate GameOverEvent
	{
		[CompilerGenerated]
		add
		{
			GameOverDelegate gameOverDelegate = gameOverDelegate_0;
			GameOverDelegate gameOverDelegate2;
			do
			{
				gameOverDelegate2 = gameOverDelegate;
				GameOverDelegate value2 = (GameOverDelegate)Delegate.Combine(gameOverDelegate2, value);
				gameOverDelegate = Interlocked.CompareExchange(ref gameOverDelegate_0, value2, gameOverDelegate2);
			}
			while ((object)gameOverDelegate != gameOverDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GameOverDelegate gameOverDelegate = gameOverDelegate_0;
			GameOverDelegate gameOverDelegate2;
			do
			{
				gameOverDelegate2 = gameOverDelegate;
				GameOverDelegate value2 = (GameOverDelegate)Delegate.Remove(gameOverDelegate2, value);
				gameOverDelegate = Interlocked.CompareExchange(ref gameOverDelegate_0, value2, gameOverDelegate2);
			}
			while ((object)gameOverDelegate != gameOverDelegate2);
		}
	}

	public event UIDelegate UIEvent
	{
		[CompilerGenerated]
		add
		{
			UIDelegate uIDelegate = uidelegate_0;
			UIDelegate uIDelegate2;
			do
			{
				uIDelegate2 = uIDelegate;
				UIDelegate value2 = (UIDelegate)Delegate.Combine(uIDelegate2, value);
				uIDelegate = Interlocked.CompareExchange(ref uidelegate_0, value2, uIDelegate2);
			}
			while ((object)uIDelegate != uIDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			UIDelegate uIDelegate = uidelegate_0;
			UIDelegate uIDelegate2;
			do
			{
				uIDelegate2 = uIDelegate;
				UIDelegate value2 = (UIDelegate)Delegate.Remove(uIDelegate2, value);
				uIDelegate = Interlocked.CompareExchange(ref uidelegate_0, value2, uIDelegate2);
			}
			while ((object)uIDelegate != uIDelegate2);
		}
	}

	public event WeaponSalvosUpdateDelegate WeaponSalvosUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			WeaponSalvosUpdateDelegate weaponSalvosUpdateDelegate = weaponSalvosUpdateDelegate_0;
			WeaponSalvosUpdateDelegate weaponSalvosUpdateDelegate2;
			do
			{
				weaponSalvosUpdateDelegate2 = weaponSalvosUpdateDelegate;
				WeaponSalvosUpdateDelegate value2 = (WeaponSalvosUpdateDelegate)Delegate.Combine(weaponSalvosUpdateDelegate2, value);
				weaponSalvosUpdateDelegate = Interlocked.CompareExchange(ref weaponSalvosUpdateDelegate_0, value2, weaponSalvosUpdateDelegate2);
			}
			while ((object)weaponSalvosUpdateDelegate != weaponSalvosUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			WeaponSalvosUpdateDelegate weaponSalvosUpdateDelegate = weaponSalvosUpdateDelegate_0;
			WeaponSalvosUpdateDelegate weaponSalvosUpdateDelegate2;
			do
			{
				weaponSalvosUpdateDelegate2 = weaponSalvosUpdateDelegate;
				WeaponSalvosUpdateDelegate value2 = (WeaponSalvosUpdateDelegate)Delegate.Remove(weaponSalvosUpdateDelegate2, value);
				weaponSalvosUpdateDelegate = Interlocked.CompareExchange(ref weaponSalvosUpdateDelegate_0, value2, weaponSalvosUpdateDelegate2);
			}
			while ((object)weaponSalvosUpdateDelegate != weaponSalvosUpdateDelegate2);
		}
	}

	public event ContactFilterChangeDelegate ContactFilterChangeEvent
	{
		[CompilerGenerated]
		add
		{
			ContactFilterChangeDelegate contactFilterChangeDelegate = contactFilterChangeDelegate_0;
			ContactFilterChangeDelegate contactFilterChangeDelegate2;
			do
			{
				contactFilterChangeDelegate2 = contactFilterChangeDelegate;
				ContactFilterChangeDelegate value2 = (ContactFilterChangeDelegate)Delegate.Combine(contactFilterChangeDelegate2, value);
				contactFilterChangeDelegate = Interlocked.CompareExchange(ref contactFilterChangeDelegate_0, value2, contactFilterChangeDelegate2);
			}
			while ((object)contactFilterChangeDelegate != contactFilterChangeDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ContactFilterChangeDelegate contactFilterChangeDelegate = contactFilterChangeDelegate_0;
			ContactFilterChangeDelegate contactFilterChangeDelegate2;
			do
			{
				contactFilterChangeDelegate2 = contactFilterChangeDelegate;
				ContactFilterChangeDelegate value2 = (ContactFilterChangeDelegate)Delegate.Remove(contactFilterChangeDelegate2, value);
				contactFilterChangeDelegate = Interlocked.CompareExchange(ref contactFilterChangeDelegate_0, value2, contactFilterChangeDelegate2);
			}
			while ((object)contactFilterChangeDelegate != contactFilterChangeDelegate2);
		}
	}

	public event ContactUpdateDelegate ContactUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			ContactUpdateDelegate contactUpdateDelegate = contactUpdateDelegate_0;
			ContactUpdateDelegate contactUpdateDelegate2;
			do
			{
				contactUpdateDelegate2 = contactUpdateDelegate;
				ContactUpdateDelegate value2 = (ContactUpdateDelegate)Delegate.Combine(contactUpdateDelegate2, value);
				contactUpdateDelegate = Interlocked.CompareExchange(ref contactUpdateDelegate_0, value2, contactUpdateDelegate2);
			}
			while ((object)contactUpdateDelegate != contactUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ContactUpdateDelegate contactUpdateDelegate = contactUpdateDelegate_0;
			ContactUpdateDelegate contactUpdateDelegate2;
			do
			{
				contactUpdateDelegate2 = contactUpdateDelegate;
				ContactUpdateDelegate value2 = (ContactUpdateDelegate)Delegate.Remove(contactUpdateDelegate2, value);
				contactUpdateDelegate = Interlocked.CompareExchange(ref contactUpdateDelegate_0, value2, contactUpdateDelegate2);
			}
			while ((object)contactUpdateDelegate != contactUpdateDelegate2);
		}
	}

	public event CourseUpdateDelegate CourseUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			CourseUpdateDelegate courseUpdateDelegate = courseUpdateDelegate_0;
			CourseUpdateDelegate courseUpdateDelegate2;
			do
			{
				courseUpdateDelegate2 = courseUpdateDelegate;
				CourseUpdateDelegate value2 = (CourseUpdateDelegate)Delegate.Combine(courseUpdateDelegate2, value);
				courseUpdateDelegate = Interlocked.CompareExchange(ref courseUpdateDelegate_0, value2, courseUpdateDelegate2);
			}
			while ((object)courseUpdateDelegate != courseUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			CourseUpdateDelegate courseUpdateDelegate = courseUpdateDelegate_0;
			CourseUpdateDelegate courseUpdateDelegate2;
			do
			{
				courseUpdateDelegate2 = courseUpdateDelegate;
				CourseUpdateDelegate value2 = (CourseUpdateDelegate)Delegate.Remove(courseUpdateDelegate2, value);
				courseUpdateDelegate = Interlocked.CompareExchange(ref courseUpdateDelegate_0, value2, courseUpdateDelegate2);
			}
			while ((object)courseUpdateDelegate != courseUpdateDelegate2);
		}
	}

	public event DoctrineUpdateDelegate DoctrineUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			DoctrineUpdateDelegate doctrineUpdateDelegate = doctrineUpdateDelegate_0;
			DoctrineUpdateDelegate doctrineUpdateDelegate2;
			do
			{
				doctrineUpdateDelegate2 = doctrineUpdateDelegate;
				DoctrineUpdateDelegate value2 = (DoctrineUpdateDelegate)Delegate.Combine(doctrineUpdateDelegate2, value);
				doctrineUpdateDelegate = Interlocked.CompareExchange(ref doctrineUpdateDelegate_0, value2, doctrineUpdateDelegate2);
			}
			while ((object)doctrineUpdateDelegate != doctrineUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DoctrineUpdateDelegate doctrineUpdateDelegate = doctrineUpdateDelegate_0;
			DoctrineUpdateDelegate doctrineUpdateDelegate2;
			do
			{
				doctrineUpdateDelegate2 = doctrineUpdateDelegate;
				DoctrineUpdateDelegate value2 = (DoctrineUpdateDelegate)Delegate.Remove(doctrineUpdateDelegate2, value);
				doctrineUpdateDelegate = Interlocked.CompareExchange(ref doctrineUpdateDelegate_0, value2, doctrineUpdateDelegate2);
			}
			while ((object)doctrineUpdateDelegate != doctrineUpdateDelegate2);
		}
	}

	public event ShowWarningDelegate ShowWarningEvent
	{
		[CompilerGenerated]
		add
		{
			ShowWarningDelegate showWarningDelegate = showWarningDelegate_0;
			ShowWarningDelegate showWarningDelegate2;
			do
			{
				showWarningDelegate2 = showWarningDelegate;
				ShowWarningDelegate value2 = (ShowWarningDelegate)Delegate.Combine(showWarningDelegate2, value);
				showWarningDelegate = Interlocked.CompareExchange(ref showWarningDelegate_0, value2, showWarningDelegate2);
			}
			while ((object)showWarningDelegate != showWarningDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ShowWarningDelegate showWarningDelegate = showWarningDelegate_0;
			ShowWarningDelegate showWarningDelegate2;
			do
			{
				showWarningDelegate2 = showWarningDelegate;
				ShowWarningDelegate value2 = (ShowWarningDelegate)Delegate.Remove(showWarningDelegate2, value);
				showWarningDelegate = Interlocked.CompareExchange(ref showWarningDelegate_0, value2, showWarningDelegate2);
			}
			while ((object)showWarningDelegate != showWarningDelegate2);
		}
	}

	public event MissionEditorEventDelegate MissionFlightPlanRefreshEvent
	{
		[CompilerGenerated]
		add
		{
			MissionEditorEventDelegate missionEditorEventDelegate = missionEditorEventDelegate_0;
			MissionEditorEventDelegate missionEditorEventDelegate2;
			do
			{
				missionEditorEventDelegate2 = missionEditorEventDelegate;
				MissionEditorEventDelegate value2 = (MissionEditorEventDelegate)Delegate.Combine(missionEditorEventDelegate2, value);
				missionEditorEventDelegate = Interlocked.CompareExchange(ref missionEditorEventDelegate_0, value2, missionEditorEventDelegate2);
			}
			while ((object)missionEditorEventDelegate != missionEditorEventDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MissionEditorEventDelegate missionEditorEventDelegate = missionEditorEventDelegate_0;
			MissionEditorEventDelegate missionEditorEventDelegate2;
			do
			{
				missionEditorEventDelegate2 = missionEditorEventDelegate;
				MissionEditorEventDelegate value2 = (MissionEditorEventDelegate)Delegate.Remove(missionEditorEventDelegate2, value);
				missionEditorEventDelegate = Interlocked.CompareExchange(ref missionEditorEventDelegate_0, value2, missionEditorEventDelegate2);
			}
			while ((object)missionEditorEventDelegate != missionEditorEventDelegate2);
		}
	}

	public event ScoringUpdateDelegate ScoringUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			ScoringUpdateDelegate scoringUpdateDelegate = scoringUpdateDelegate_0;
			ScoringUpdateDelegate scoringUpdateDelegate2;
			do
			{
				scoringUpdateDelegate2 = scoringUpdateDelegate;
				ScoringUpdateDelegate value2 = (ScoringUpdateDelegate)Delegate.Combine(scoringUpdateDelegate2, value);
				scoringUpdateDelegate = Interlocked.CompareExchange(ref scoringUpdateDelegate_0, value2, scoringUpdateDelegate2);
			}
			while ((object)scoringUpdateDelegate != scoringUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ScoringUpdateDelegate scoringUpdateDelegate = scoringUpdateDelegate_0;
			ScoringUpdateDelegate scoringUpdateDelegate2;
			do
			{
				scoringUpdateDelegate2 = scoringUpdateDelegate;
				ScoringUpdateDelegate value2 = (ScoringUpdateDelegate)Delegate.Remove(scoringUpdateDelegate2, value);
				scoringUpdateDelegate = Interlocked.CompareExchange(ref scoringUpdateDelegate_0, value2, scoringUpdateDelegate2);
			}
			while ((object)scoringUpdateDelegate != scoringUpdateDelegate2);
		}
	}

	public event MessageLogUpdateDelegate MessageLogUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			MessageLogUpdateDelegate messageLogUpdateDelegate = messageLogUpdateDelegate_0;
			MessageLogUpdateDelegate messageLogUpdateDelegate2;
			do
			{
				messageLogUpdateDelegate2 = messageLogUpdateDelegate;
				MessageLogUpdateDelegate value2 = (MessageLogUpdateDelegate)Delegate.Combine(messageLogUpdateDelegate2, value);
				messageLogUpdateDelegate = Interlocked.CompareExchange(ref messageLogUpdateDelegate_0, value2, messageLogUpdateDelegate2);
			}
			while ((object)messageLogUpdateDelegate != messageLogUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MessageLogUpdateDelegate messageLogUpdateDelegate = messageLogUpdateDelegate_0;
			MessageLogUpdateDelegate messageLogUpdateDelegate2;
			do
			{
				messageLogUpdateDelegate2 = messageLogUpdateDelegate;
				MessageLogUpdateDelegate value2 = (MessageLogUpdateDelegate)Delegate.Remove(messageLogUpdateDelegate2, value);
				messageLogUpdateDelegate = Interlocked.CompareExchange(ref messageLogUpdateDelegate_0, value2, messageLogUpdateDelegate2);
			}
			while ((object)messageLogUpdateDelegate != messageLogUpdateDelegate2);
		}
	}

	public event MissionUpdateDelegate MissionUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			MissionUpdateDelegate missionUpdateDelegate = missionUpdateDelegate_0;
			MissionUpdateDelegate missionUpdateDelegate2;
			do
			{
				missionUpdateDelegate2 = missionUpdateDelegate;
				MissionUpdateDelegate value2 = (MissionUpdateDelegate)Delegate.Combine(missionUpdateDelegate2, value);
				missionUpdateDelegate = Interlocked.CompareExchange(ref missionUpdateDelegate_0, value2, missionUpdateDelegate2);
			}
			while ((object)missionUpdateDelegate != missionUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MissionUpdateDelegate missionUpdateDelegate = missionUpdateDelegate_0;
			MissionUpdateDelegate missionUpdateDelegate2;
			do
			{
				missionUpdateDelegate2 = missionUpdateDelegate;
				MissionUpdateDelegate value2 = (MissionUpdateDelegate)Delegate.Remove(missionUpdateDelegate2, value);
				missionUpdateDelegate = Interlocked.CompareExchange(ref missionUpdateDelegate_0, value2, missionUpdateDelegate2);
			}
			while ((object)missionUpdateDelegate != missionUpdateDelegate2);
		}
	}

	public event SmartRPUpdateDelegate Event_0
	{
		[CompilerGenerated]
		add
		{
			SmartRPUpdateDelegate smartRPUpdateDelegate = smartRPUpdateDelegate_0;
			SmartRPUpdateDelegate smartRPUpdateDelegate2;
			do
			{
				smartRPUpdateDelegate2 = smartRPUpdateDelegate;
				SmartRPUpdateDelegate value2 = (SmartRPUpdateDelegate)Delegate.Combine(smartRPUpdateDelegate2, value);
				smartRPUpdateDelegate = Interlocked.CompareExchange(ref smartRPUpdateDelegate_0, value2, smartRPUpdateDelegate2);
			}
			while ((object)smartRPUpdateDelegate != smartRPUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SmartRPUpdateDelegate smartRPUpdateDelegate = smartRPUpdateDelegate_0;
			SmartRPUpdateDelegate smartRPUpdateDelegate2;
			do
			{
				smartRPUpdateDelegate2 = smartRPUpdateDelegate;
				SmartRPUpdateDelegate value2 = (SmartRPUpdateDelegate)Delegate.Remove(smartRPUpdateDelegate2, value);
				smartRPUpdateDelegate = Interlocked.CompareExchange(ref smartRPUpdateDelegate_0, value2, smartRPUpdateDelegate2);
			}
			while ((object)smartRPUpdateDelegate != smartRPUpdateDelegate2);
		}
	}

	public event SensorsUpdateDelegate SensorsUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			SensorsUpdateDelegate sensorsUpdateDelegate = sensorsUpdateDelegate_0;
			SensorsUpdateDelegate sensorsUpdateDelegate2;
			do
			{
				sensorsUpdateDelegate2 = sensorsUpdateDelegate;
				SensorsUpdateDelegate value2 = (SensorsUpdateDelegate)Delegate.Combine(sensorsUpdateDelegate2, value);
				sensorsUpdateDelegate = Interlocked.CompareExchange(ref sensorsUpdateDelegate_0, value2, sensorsUpdateDelegate2);
			}
			while ((object)sensorsUpdateDelegate != sensorsUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsUpdateDelegate sensorsUpdateDelegate = sensorsUpdateDelegate_0;
			SensorsUpdateDelegate sensorsUpdateDelegate2;
			do
			{
				sensorsUpdateDelegate2 = sensorsUpdateDelegate;
				SensorsUpdateDelegate value2 = (SensorsUpdateDelegate)Delegate.Remove(sensorsUpdateDelegate2, value);
				sensorsUpdateDelegate = Interlocked.CompareExchange(ref sensorsUpdateDelegate_0, value2, sensorsUpdateDelegate2);
			}
			while ((object)sensorsUpdateDelegate != sensorsUpdateDelegate2);
		}
	}

	public event SideMapPingDelegate MapPingEvent
	{
		[CompilerGenerated]
		add
		{
			SideMapPingDelegate sideMapPingDelegate = sideMapPingDelegate_0;
			SideMapPingDelegate sideMapPingDelegate2;
			do
			{
				sideMapPingDelegate2 = sideMapPingDelegate;
				SideMapPingDelegate value2 = (SideMapPingDelegate)Delegate.Combine(sideMapPingDelegate2, value);
				sideMapPingDelegate = Interlocked.CompareExchange(ref sideMapPingDelegate_0, value2, sideMapPingDelegate2);
			}
			while ((object)sideMapPingDelegate != sideMapPingDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SideMapPingDelegate sideMapPingDelegate = sideMapPingDelegate_0;
			SideMapPingDelegate sideMapPingDelegate2;
			do
			{
				sideMapPingDelegate2 = sideMapPingDelegate;
				SideMapPingDelegate value2 = (SideMapPingDelegate)Delegate.Remove(sideMapPingDelegate2, value);
				sideMapPingDelegate = Interlocked.CompareExchange(ref sideMapPingDelegate_0, value2, sideMapPingDelegate2);
			}
			while ((object)sideMapPingDelegate != sideMapPingDelegate2);
		}
	}

	public event SpecialActionUpdateDelegate SpecialActionUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			SpecialActionUpdateDelegate specialActionUpdateDelegate = specialActionUpdateDelegate_0;
			SpecialActionUpdateDelegate specialActionUpdateDelegate2;
			do
			{
				specialActionUpdateDelegate2 = specialActionUpdateDelegate;
				SpecialActionUpdateDelegate value2 = (SpecialActionUpdateDelegate)Delegate.Combine(specialActionUpdateDelegate2, value);
				specialActionUpdateDelegate = Interlocked.CompareExchange(ref specialActionUpdateDelegate_0, value2, specialActionUpdateDelegate2);
			}
			while ((object)specialActionUpdateDelegate != specialActionUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SpecialActionUpdateDelegate specialActionUpdateDelegate = specialActionUpdateDelegate_0;
			SpecialActionUpdateDelegate specialActionUpdateDelegate2;
			do
			{
				specialActionUpdateDelegate2 = specialActionUpdateDelegate;
				SpecialActionUpdateDelegate value2 = (SpecialActionUpdateDelegate)Delegate.Remove(specialActionUpdateDelegate2, value);
				specialActionUpdateDelegate = Interlocked.CompareExchange(ref specialActionUpdateDelegate_0, value2, specialActionUpdateDelegate2);
			}
			while ((object)specialActionUpdateDelegate != specialActionUpdateDelegate2);
		}
	}

	public event SelectedWaypointUpdateDelegate SelectedWaypointUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			SelectedWaypointUpdateDelegate selectedWaypointUpdateDelegate = selectedWaypointUpdateDelegate_0;
			SelectedWaypointUpdateDelegate selectedWaypointUpdateDelegate2;
			do
			{
				selectedWaypointUpdateDelegate2 = selectedWaypointUpdateDelegate;
				SelectedWaypointUpdateDelegate value2 = (SelectedWaypointUpdateDelegate)Delegate.Combine(selectedWaypointUpdateDelegate2, value);
				selectedWaypointUpdateDelegate = Interlocked.CompareExchange(ref selectedWaypointUpdateDelegate_0, value2, selectedWaypointUpdateDelegate2);
			}
			while ((object)selectedWaypointUpdateDelegate != selectedWaypointUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedWaypointUpdateDelegate selectedWaypointUpdateDelegate = selectedWaypointUpdateDelegate_0;
			SelectedWaypointUpdateDelegate selectedWaypointUpdateDelegate2;
			do
			{
				selectedWaypointUpdateDelegate2 = selectedWaypointUpdateDelegate;
				SelectedWaypointUpdateDelegate value2 = (SelectedWaypointUpdateDelegate)Delegate.Remove(selectedWaypointUpdateDelegate2, value);
				selectedWaypointUpdateDelegate = Interlocked.CompareExchange(ref selectedWaypointUpdateDelegate_0, value2, selectedWaypointUpdateDelegate2);
			}
			while ((object)selectedWaypointUpdateDelegate != selectedWaypointUpdateDelegate2);
		}
	}

	public event ZoneUpdateDelegate ZoneUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			ZoneUpdateDelegate zoneUpdateDelegate = zoneUpdateDelegate_0;
			ZoneUpdateDelegate zoneUpdateDelegate2;
			do
			{
				zoneUpdateDelegate2 = zoneUpdateDelegate;
				ZoneUpdateDelegate value2 = (ZoneUpdateDelegate)Delegate.Combine(zoneUpdateDelegate2, value);
				zoneUpdateDelegate = Interlocked.CompareExchange(ref zoneUpdateDelegate_0, value2, zoneUpdateDelegate2);
			}
			while ((object)zoneUpdateDelegate != zoneUpdateDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ZoneUpdateDelegate zoneUpdateDelegate = zoneUpdateDelegate_0;
			ZoneUpdateDelegate zoneUpdateDelegate2;
			do
			{
				zoneUpdateDelegate2 = zoneUpdateDelegate;
				ZoneUpdateDelegate value2 = (ZoneUpdateDelegate)Delegate.Remove(zoneUpdateDelegate2, value);
				zoneUpdateDelegate = Interlocked.CompareExchange(ref zoneUpdateDelegate_0, value2, zoneUpdateDelegate2);
			}
			while ((object)zoneUpdateDelegate != zoneUpdateDelegate2);
		}
	}

	public event DisconnectedDelegate DisconnectedEvent
	{
		[CompilerGenerated]
		add
		{
			DisconnectedDelegate disconnectedDelegate = disconnectedDelegate_0;
			DisconnectedDelegate disconnectedDelegate2;
			do
			{
				disconnectedDelegate2 = disconnectedDelegate;
				DisconnectedDelegate value2 = (DisconnectedDelegate)Delegate.Combine(disconnectedDelegate2, value);
				disconnectedDelegate = Interlocked.CompareExchange(ref disconnectedDelegate_0, value2, disconnectedDelegate2);
			}
			while ((object)disconnectedDelegate != disconnectedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DisconnectedDelegate disconnectedDelegate = disconnectedDelegate_0;
			DisconnectedDelegate disconnectedDelegate2;
			do
			{
				disconnectedDelegate2 = disconnectedDelegate;
				DisconnectedDelegate value2 = (DisconnectedDelegate)Delegate.Remove(disconnectedDelegate2, value);
				disconnectedDelegate = Interlocked.CompareExchange(ref disconnectedDelegate_0, value2, disconnectedDelegate2);
			}
			while ((object)disconnectedDelegate != disconnectedDelegate2);
		}
	}

	public event AutoreconnectDelegate AutoreconnectEvent
	{
		[CompilerGenerated]
		add
		{
			AutoreconnectDelegate autoreconnectDelegate = autoreconnectDelegate_0;
			AutoreconnectDelegate autoreconnectDelegate2;
			do
			{
				autoreconnectDelegate2 = autoreconnectDelegate;
				AutoreconnectDelegate value2 = (AutoreconnectDelegate)Delegate.Combine(autoreconnectDelegate2, value);
				autoreconnectDelegate = Interlocked.CompareExchange(ref autoreconnectDelegate_0, value2, autoreconnectDelegate2);
			}
			while ((object)autoreconnectDelegate != autoreconnectDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AutoreconnectDelegate autoreconnectDelegate = autoreconnectDelegate_0;
			AutoreconnectDelegate autoreconnectDelegate2;
			do
			{
				autoreconnectDelegate2 = autoreconnectDelegate;
				AutoreconnectDelegate value2 = (AutoreconnectDelegate)Delegate.Remove(autoreconnectDelegate2, value);
				autoreconnectDelegate = Interlocked.CompareExchange(ref autoreconnectDelegate_0, value2, autoreconnectDelegate2);
			}
			while ((object)autoreconnectDelegate != autoreconnectDelegate2);
		}
	}

	public event ConnectedDelegate ConnectedEvent
	{
		[CompilerGenerated]
		add
		{
			ConnectedDelegate connectedDelegate = connectedDelegate_0;
			ConnectedDelegate connectedDelegate2;
			do
			{
				connectedDelegate2 = connectedDelegate;
				ConnectedDelegate value2 = (ConnectedDelegate)Delegate.Combine(connectedDelegate2, value);
				connectedDelegate = Interlocked.CompareExchange(ref connectedDelegate_0, value2, connectedDelegate2);
			}
			while ((object)connectedDelegate != connectedDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ConnectedDelegate connectedDelegate = connectedDelegate_0;
			ConnectedDelegate connectedDelegate2;
			do
			{
				connectedDelegate2 = connectedDelegate;
				ConnectedDelegate value2 = (ConnectedDelegate)Delegate.Remove(connectedDelegate2, value);
				connectedDelegate = Interlocked.CompareExchange(ref connectedDelegate_0, value2, connectedDelegate2);
			}
			while ((object)connectedDelegate != connectedDelegate2);
		}
	}

	public event ServerErrorDelegate ServerErrorEvent
	{
		[CompilerGenerated]
		add
		{
			ServerErrorDelegate serverErrorDelegate = serverErrorDelegate_0;
			ServerErrorDelegate serverErrorDelegate2;
			do
			{
				serverErrorDelegate2 = serverErrorDelegate;
				ServerErrorDelegate value2 = (ServerErrorDelegate)Delegate.Combine(serverErrorDelegate2, value);
				serverErrorDelegate = Interlocked.CompareExchange(ref serverErrorDelegate_0, value2, serverErrorDelegate2);
			}
			while ((object)serverErrorDelegate != serverErrorDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			ServerErrorDelegate serverErrorDelegate = serverErrorDelegate_0;
			ServerErrorDelegate serverErrorDelegate2;
			do
			{
				serverErrorDelegate2 = serverErrorDelegate;
				ServerErrorDelegate value2 = (ServerErrorDelegate)Delegate.Remove(serverErrorDelegate2, value);
				serverErrorDelegate = Interlocked.CompareExchange(ref serverErrorDelegate_0, value2, serverErrorDelegate2);
			}
			while ((object)serverErrorDelegate != serverErrorDelegate2);
		}
	}

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

	public void SoundEffectsUpdate(SoundEffectsMessage msg)
	{
		if (msg.SoundEffects != null && msg.SoundEffects.Count > 0)
		{
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				soundEffectsDelegate_0(msg.SoundEffects);
			}, Array.Empty<object>());
		}
	}

	public void SendActiveUnitMiscActionMessage(IEnumerable<Module_Unit.Unit> units, ActiveUnitMiscAction action, string targetID = null)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new ActiveUnitMiscActionMessage
		{
			ObjectIDs = units.Select((Module_Unit.Unit F) => F.ObjectID).ToList(),
			TargetID = targetID,
			Action = (byte)action
		}, "SendActiveUnitMiscActionMessage");
	}

	public void SendActiveUnitMiscActionMessage(Module_Unit.Unit unit, ActiveUnitMiscAction action, string targetID = null)
	{
		if (unit != null)
		{
			if (TerminalRights == TerminalRights.Observer)
			{
				method_55();
				return;
			}
			List<string> list = new List<string>();
			list.Add(unit.ObjectID);
			method_50(new ActiveUnitMiscActionMessage
			{
				ObjectIDs = list,
				TargetID = targetID,
				Action = (byte)action
			}, "SendActiveUnitMiscActionMessage");
		}
	}

	public void SendAirborneAircraftQuickTurnaroundMessage(Aircraft aircraft, bool enableQuickTurnaround, int maxSorties)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new AirborneAircraftQuickTurnaroundMessage
		{
			AircraftID = aircraft.ObjectID,
			QuickTurnaroundEnabled = enableQuickTurnaround,
			QuickTurnaroundSorties = maxSorties
		}, "SendAirborneAircraftQuickTurnaroundMessage");
	}

	public void RequestUpdateOnActiveUnits(IEnumerable<Module_Unit.Unit> units)
	{
		SendActiveUnitMiscActionMessage(units, ActiveUnitMiscAction.ClientRequestsUnitUpdate);
	}

	private void method_0(RTMessage rtmessage_0, ActiveUnit activeUnit_0, float float_0, double double_0, double double_1, float float_1, string string_8 = null)
	{
		IntermediatePositionUpdateMessage intermediatePositionUpdateMessage = method_53(0, rtmessage_0.SimTimeSent);
		if (intermediatePositionUpdateMessage == null)
		{
			intermediatePositionUpdateMessage = new IntermediatePositionUpdateMessage();
			intermediatePositionUpdateMessage.SimTimeSent = rtmessage_0.SimTimeSent;
			intermediatePositionUpdateMessage.ObjectType = 0;
			intermediatePositionUpdateMessage.ObjectID = new List<string> { activeUnit_0.ObjectID };
			intermediatePositionUpdateMessage.Heading = new List<float> { activeUnit_0.CurrentHeading };
			intermediatePositionUpdateMessage.Latitude = new List<double> { ((Module_Unit.Unit)activeUnit_0).get_Latitude((GlobalVariables.BooleanObject)null) };
			intermediatePositionUpdateMessage.Longitude = new List<double> { ((Module_Unit.Unit)activeUnit_0).get_Longitude((GlobalVariables.BooleanObject)null) };
			intermediatePositionUpdateMessage.Altitude = new List<float> { ((Module_Unit.Unit)activeUnit_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) };
			if (InterpolateUnitPositions && LastGameSpeed > 0)
			{
				method_54(intermediatePositionUpdateMessage, activeUnit_0.ObjectID, string_8);
			}
			tlist_0.Add(intermediatePositionUpdateMessage);
		}
		else if (!intermediatePositionUpdateMessage.ObjectID.Contains(activeUnit_0.ObjectID))
		{
			intermediatePositionUpdateMessage.ObjectID.Add(activeUnit_0.ObjectID);
			intermediatePositionUpdateMessage.Heading.Add(activeUnit_0.CurrentHeading);
			intermediatePositionUpdateMessage.Latitude.Add(((Module_Unit.Unit)activeUnit_0).get_Latitude((GlobalVariables.BooleanObject)null));
			intermediatePositionUpdateMessage.Longitude.Add(((Module_Unit.Unit)activeUnit_0).get_Longitude((GlobalVariables.BooleanObject)null));
			intermediatePositionUpdateMessage.Altitude.Add(((Module_Unit.Unit)activeUnit_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			if (InterpolateUnitPositions && LastGameSpeed > 0)
			{
				method_54(intermediatePositionUpdateMessage, activeUnit_0.ObjectID, string_8);
			}
		}
		activeUnit_0.CurrentHeading = float_0;
		((Module_Unit.Unit)activeUnit_0).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, float_1);
		((Module_Unit.Unit)activeUnit_0).set_Latitude((GlobalVariables.BooleanObject)null, double_0);
		((Module_Unit.Unit)activeUnit_0).set_Longitude((GlobalVariables.BooleanObject)null, double_1);
	}

	private void method_1(ActiveUnitUpdateMessage activeUnitUpdateMessage_0)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		lock (TerminalRenderLockObj)
		{
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(activeUnitUpdateMessage_0.XML)));
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			Scenario theScen = ClientScenario;
			if (theScen == null)
			{
				return;
			}
			ActiveUnit value = null;
			List<ActiveUnit> discardList = new List<ActiveUnit>();
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				theDictionary.TryAdd(side.ObjectID, side);
			}
			string string_0 = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (theNode.Name.Equals("Group"))
			{
				XmlNode nodeByName = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "GroupLead");
				if (nodeByName != null && nodeByName.HasChildNodes)
				{
					XmlNode val = nodeByName.ChildNodes[0];
					if (val != null && val.HasChildNodes)
					{
						XmlNode nodeByName2 = Command_Core.Misc.GetNodeByName(val.ChildNodes, "ID");
						if (nodeByName2 != null)
						{
							string innerText = nodeByName2.InnerText;
							ActiveUnit value2 = null;
							if (theScen.ActiveUnits.TryGetValue(innerText, out value2))
							{
								theDictionary.TryAdd(innerText, value2);
							}
						}
					}
				}
			}
			bool flag = LastGameSpeed > 0;
			ActiveDeserializationCount++;
			if (theScen.ActiveUnits.TryGetValue(string_0, out value))
			{
				Waypoint[] plottedCourse = null;
				Waypoint[] waypoint_0 = null;
				Waypoint[] array = null;
				Waypoint[] waypoint_1 = null;
				float currentHeading = 0f;
				float value3 = 0f;
				double value4 = 0.0;
				double value5 = 0.0;
				if (uint_3 != 0 && list_3.Contains(string_0))
				{
					return;
				}
				bool flag2 = value.PlayerIsPlottingCourse;
				bool flag3 = bool_1 && !string.IsNullOrEmpty(string_1);
				bool flag4 = value.ObjectID == this.string_0 && !string.IsNullOrEmpty(string_1);
				if (!flag2 && uint_1 != 0 && list_0.Contains(value.ObjectID))
				{
					flag2 = true;
				}
				if (flag2 || flag3)
				{
					plottedCourse = value.Navigator.PlottedCourse;
				}
				if (flag4 && value.Navigator.HasFlightPlan)
				{
					array = value.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
				}
				if (flag)
				{
					currentHeading = value.CurrentHeading;
					value3 = ((Module_Unit.Unit)value).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					value4 = ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null);
					value5 = ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null);
				}
				if (value.IsActiveUnit && !value.IsDumbAU)
				{
					Side side2 = ((Module_Unit.Unit)value).get_UnitSide(SetSideOnly: false);
					if (side2 != null)
					{
						foreach (Contact contacts_ in side2.Contacts_List)
						{
							theDictionary.TryAdd(contacts_.ObjectID, contacts_);
						}
					}
				}
				value.PrepareForDeserializationToExistingUnit();
				ActiveUnit.FromXML(ref theNode, ref theDictionary, ref theScen, value);
				value.CleanupFromDeserializationToExistingUnit();
				value.PostDeserializationHousekeeping_Groupmembership(ref theScen, theDictionary);
				value.PostDeserializationHousekeeping_General(ref theScen, theDictionary, discardList, GameIsRunning: true);
				value.Sensors_Cached = null;
				if (flag)
				{
					value.CurrentHeading = currentHeading;
					((Module_Unit.Unit)value).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value3);
					((Module_Unit.Unit)value).set_Latitude((GlobalVariables.BooleanObject)null, value4);
					((Module_Unit.Unit)value).set_Longitude((GlobalVariables.BooleanObject)null, value5);
				}
				if (flag3)
				{
					value.Navigator.PlottedCourse = plottedCourse;
				}
				else if (flag2)
				{
					value.Navigator.PlottedCourse = plottedCourse;
				}
				if (flag4 && array != null)
				{
					Mission.Flight flight = value.Navigator.get_Flight(HierarchySearch: true);
					if (flight != null)
					{
						if (value.Navigator.HasFlightPlan)
						{
							waypoint_1 = flight.FlightPlan;
						}
						flight.FlightPlan = array;
					}
				}
				dispatcher_0.BeginInvoke((Delegate)(Action)delegate
				{
					activeUnitUpdateDelegate_0(string_0, waypoint_0, waypoint_1);
				}, Array.Empty<object>());
			}
			else
			{
				value = ActiveUnit.FromXML(ref theNode, ref theDictionary, ref theScen);
				if (value != null)
				{
					value.PostDeserializationHousekeeping_Groupmembership(ref theScen, theDictionary);
					value.PostDeserializationHousekeeping_General(ref theScen, theDictionary, discardList, GameIsRunning: true);
					theScen.ActiveUnits.TryAdd(value.ObjectID, value);
					if (value.IsGroup)
					{
						theScen.Groups.Add((Group)value);
					}
					if (value.IsWeapon && flag && value.CurrentSpeed > 0f)
					{
						ActiveUnit firingParent = ((Weapon)value).FiringParent;
						if (firingParent != null)
						{
							float float_ = Module_Unit.BearingToUnit_True(firingParent, value);
							float float_2 = ((Module_Unit.Unit)firingParent).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							double double_ = ((Module_Unit.Unit)firingParent).get_Latitude((GlobalVariables.BooleanObject)null);
							double double_2 = ((Module_Unit.Unit)firingParent).get_Longitude((GlobalVariables.BooleanObject)null);
							method_0(activeUnitUpdateMessage_0, value, float_, double_, double_2, float_2, firingParent.ObjectID);
						}
					}
				}
			}
			if (value != null)
			{
				if (!value.IsAircraft)
				{
					if (value.DockingOps.CurrentHostUnit != null)
					{
						EmbarkedDockingOpsNewDataReceived = true;
					}
				}
				else if (((Aircraft)value).AirOps.CurrentHostUnit != null)
				{
					EmbarkedAirOpsNewDataReceived = true;
				}
				value.Sensory.HadActiveSensorInLastPulse = activeUnitUpdateMessage_0.HadActiveSensorInLastPulse;
			}
			ActiveDeserializationCount--;
		}
	}

	private void method_2(ActiveUnitRemoveMessage activeUnitRemoveMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		lock (TerminalRenderLockObj)
		{
			int count = activeUnitRemoveMessage_0.ObjectID.Count;
			ActiveUnit value = null;
			for (int i = 0; i < count; i++)
			{
				if (clientScenario.ActiveUnits.TryGetValue(activeUnitRemoveMessage_0.ObjectID[i], out value) && value.IsGroup)
				{
					Group obj = (Group)value;
					List<ActiveUnit> list = obj.Units.Values.ToList();
					clientScenario.Groups.Remove(obj);
					foreach (ActiveUnit item in list)
					{
						item.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
				}
				clientScenario.ActiveUnits.TryRemove(activeUnitRemoveMessage_0.ObjectID[i], out value);
				if (string_0 == activeUnitRemoveMessage_0.ObjectID[i])
				{
					dispatcher_0.BeginInvoke((Delegate)selectDelegate_0, new object[1] { "" });
				}
			}
		}
	}

	private void method_3(ActiveUnitHomeBaseMessage activeUnitHomeBaseMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		ActiveUnit value = null;
		foreach (string objectID in activeUnitHomeBaseMessage_0.ObjectIDs)
		{
			if (clientScenario.ActiveUnits.TryGetValue(objectID, out value))
			{
				list.Add(value);
			}
		}
		if (clientScenario.ActiveUnits.TryGetValue(activeUnitHomeBaseMessage_0.HomeBaseID, out value))
		{
			CoreClientCode.SetNewHomeBaseForUnits_Core(currentSide, list, value);
		}
	}

	public void SendActiveUnitHomeBase(Side side, List<Module_Unit.Unit> unitList, Module_Unit.Unit destination)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else
		{
			if (destination == null || !destination.IsActiveUnit)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (Module_Unit.Unit unit in unitList)
			{
				if (unit.IsActiveUnit && unit.get_UnitSide(SetSideOnly: false) == side)
				{
					list.Add(unit.ObjectID);
				}
			}
			method_50(new ActiveUnitHomeBaseMessage
			{
				ObjectIDs = list,
				HomeBaseID = destination.ObjectID
			}, "SendActiveUnitHomeBase");
		}
	}

	public void SendUnitRename(Module_Unit.Unit unit, string newName)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		string objectID = unit.ObjectID;
		bool isContact = false;
		if (unit.IsContact())
		{
			isContact = true;
			Contact contact = (Contact)unit;
			if (contact.ActualUnit != null)
			{
				objectID = contact.ActualUnit.ObjectID;
			}
		}
		method_50(new UnitRenameMessage
		{
			IsContact = isContact,
			ID = objectID,
			Name = newName
		}, "SendUnitRename");
	}

	private void method_4(AbsoluteControlGrantedMessage absoluteControlGrantedMessage_0)
	{
		HasAbsoluteControl = true;
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			absoluteControlGrantedDelegate_0(absoluteControlGrantedMessage_0);
		}, Array.Empty<object>());
	}

	public void SendAbsoluteControlRequest()
	{
		if (AllowAC)
		{
			method_50(new AbsoluteControlRequestMessage(), "SendAbsoluteControlRequest");
		}
	}

	public void SendAbsoluteControlRelease(string NewSideID)
	{
		if (!HasAbsoluteControl)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		HasAbsoluteControl = false;
		ClientScenario.AddRemoveUnits();
		method_50(new AbsoluteControlReleaseMessage
		{
			ScenXML = CommandCoreInterop.ScenarioToXML(ClientScenario),
			NewClientSideID = NewSideID
		}, "SendAbsoluteControlRelease");
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			absoluteControlReleasedDelegate_0();
		}, Array.Empty<object>());
	}

	private void method_5(AutosavesListReplyMessage autosavesListReplyMessage_0)
	{
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			autosavesListReplyDelegate_0(autosavesListReplyMessage_0);
		}, Array.Empty<object>());
	}

	public void SendAutosavesListRequest(int count)
	{
		method_50(new AutosavesListRequestMessage
		{
			Count = count
		}, "SendAutosavesListRequest");
	}

	public void SendAutosaveRequest(string tag)
	{
		if (AllowCreateAutoSave)
		{
			method_50(new AutosaveRequestMessage
			{
				Tag = tag
			}, "SendAutosaveRequest");
		}
	}

	public void SendRewindRequest(string AutosaveFilename)
	{
		if (AllowLoadAutoSave)
		{
			method_50(new RewindRequestMessage
			{
				AutosaveFilename = AutosaveFilename
			}, "SendRewindRequest");
		}
	}

	public void SendGlobalChat(string msg)
	{
		method_50(new GlobalChatMessage
		{
			PlayerName = ClientName,
			Message = msg
		}, "SendGlobalChat");
	}

	private void GlobalChat(GlobalChatMessage msg)
	{
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			globalChatDelegate_0(msg);
		}, Array.Empty<object>());
	}

	public void SendHealth()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (performanceCounter_0 == null)
		{
			performanceCounter_0 = new PerformanceCounter();
			performanceCounter_0.CategoryName = "Processor";
			performanceCounter_0.CounterName = "% Processor Time";
			performanceCounter_0.InstanceName = "_Total";
		}
		dateTime_0 = DateTime.Now;
		Task.Factory.StartNew(delegate
		{
			method_50(new HealthMessage
			{
				CPU = performanceCounter_0.NextValue(),
				LocalTrafficWaiting = TrafficWaitingForLock
			}, "SendHealth");
			dateTime_0 = DateTime.Now;
		});
	}

	private void method_6(HealthReplyMessage healthReplyMessage_0)
	{
		dateTime_1 = DateTime.Now;
	}

	private void method_7(LoginReplyMessage loginReplyMessage_0)
	{
		ClientName = loginReplyMessage_0.Name;
		ClientColor = loginReplyMessage_0.Color;
		TerminalLockedSide = loginReplyMessage_0.LockedSide;
		TerminalRights = (TerminalRights)loginReplyMessage_0.TerminalRights;
		dispatcher_0.Invoke((Action)delegate
		{
			loginResultDelegate_0(result: true, "Success.", loginReplyMessage_0.DBFileName, loginReplyMessage_0.DBHash);
		});
		LoginSuccessful = true;
	}

	private void ServerInfoRequest(ServerInfoRequest msg)
	{
		ServerScenarioTitle = "(None)";
		ServerScenarioPlayableSideNames = new List<string>();
		if (!string.IsNullOrEmpty(msg.ScenarioTitle))
		{
			ServerScenarioTitle = msg.ScenarioTitle;
		}
		if (msg.PlayableSideNames != null)
		{
			foreach (string playableSideName in msg.PlayableSideNames)
			{
				ServerScenarioPlayableSideNames.Add(playableSideName);
			}
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			serverInfoDelegate_0();
		}, Array.Empty<object>());
	}

	public void SendServerInfoRequest()
	{
		ServerInfoRequest rtmessage_ = new ServerInfoRequest();
		method_51(rtmessage_);
	}

	public void SendLoginRequest()
	{
		LoginRequestMessage rtmessage_ = new LoginRequestMessage
		{
			Name = ClientName,
			Color = ClientColor,
			LockedSide = TerminalLockedSide,
			TerminalRights = (int)TerminalRights,
			Version = "v1.10 - Build 1900.20"
		};
		method_51(rtmessage_);
	}

	public void SendLogout(LogoutMessage msg)
	{
		method_51(msg);
	}

	public bool WantScreenUpdate()
	{
		if (!LoginSuccessful)
		{
			return false;
		}
		return DateTime.Now - dateTime_2 > TimeSpan.FromMilliseconds(500.0);
	}

	public bool WantMouseClickUpdate()
	{
		if (!LoginSuccessful)
		{
			return false;
		}
		return DateTime.Now - dateTime_4 > TimeSpan.FromMilliseconds(50.0);
	}

	public bool WantMouseUpdate()
	{
		if (!LoginSuccessful)
		{
			return false;
		}
		return DateTime.Now - dateTime_3 > TimeSpan.FromMilliseconds(100.0);
	}

	public void SendPeerListRequest()
	{
		method_50(new PeerListRequestMessage(), "SendPeerListRequest");
	}

	public void SendPeerUpdateScreen(List<(double, double)> Screen)
	{
		if (WantScreenUpdate())
		{
			dateTime_2 = DateTime.Now;
			method_50(new PeerScreenMouseUpdateMessage
			{
				Names = new List<string>(1) { ClientName },
				Screens = new List<List<(double, double)>>(1) { Screen },
				TerminalRights = new List<int>(1) { (int)TerminalRights },
				TerminalLockedSides = new List<string>(1) { TerminalLockedSide }
			}, "SendPeerUpdateScreen");
		}
	}

	public void SendPeerUpdateMouse((double, double) Mouse, bool Click)
	{
		if (Click)
		{
			if (WantMouseClickUpdate() || WantMouseUpdate())
			{
				dateTime_3 = (dateTime_4 = DateTime.Now);
				method_50(new PeerScreenMouseUpdateMessage
				{
					Names = new List<string>(1) { ClientName },
					Mice = new List<(double, double)>(1) { Mouse },
					Clicks = new List<bool>(1) { true }
				}, "SendPeerUpdateMouse");
			}
		}
		else if (WantMouseUpdate())
		{
			dateTime_3 = DateTime.Now;
			method_50(new PeerScreenMouseUpdateMessage
			{
				Names = new List<string>(1) { ClientName },
				Mice = new List<(double, double)>(1) { Mouse },
				Clicks = new List<bool>(1) { false }
			}, "SendPeerUpdateMouse");
		}
	}

	private void PeerScreenMouseUpdate(PeerScreenMouseUpdateMessage msg)
	{
		DateTime now = DateTime.Now;
		int count = msg.Names.Count;
		int int_0 = 0;
		while (int_0 < count)
		{
			RealtimePeer realtimePeer = Peers.FirstOrDefault((RealtimePeer F) => F.Name == msg.Names[int_0]);
			if (realtimePeer == null)
			{
				realtimePeer = new RealtimePeer
				{
					Name = msg.Names[int_0]
				};
				Peers.Add(realtimePeer);
			}
			if (msg.Colors != null)
			{
				realtimePeer.Color = msg.Colors[int_0];
			}
			realtimePeer.LastHeard = now;
			if (msg.Mice != null)
			{
				realtimePeer.Mouse = msg.Mice[int_0];
			}
			if (msg.Screens != null)
			{
				realtimePeer.Screen = msg.Screens[int_0] ?? realtimePeer.Screen;
			}
			if (msg.Clicks != null && msg.Clicks[int_0])
			{
				realtimePeer.LastClick = now;
			}
			if (msg.SideNames != null)
			{
				realtimePeer.CurrentSideName = msg.SideNames[int_0];
			}
			if (msg.TerminalLockedSides != null)
			{
				realtimePeer.TerminalLockedSide = msg.TerminalLockedSides[int_0];
			}
			if (msg.TerminalRights != null)
			{
				realtimePeer.TerminalRights = (TerminalRights)msg.TerminalRights[int_0];
			}
			int num = int_0 + 1;
			int_0 = num;
		}
	}

	private void method_8(PeerListMessage peerListMessage_0)
	{
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			peerListDelegate_0(peerListMessage_0);
		}, Array.Empty<object>());
		lock (TerminalRenderLockObj)
		{
			_ = DateTime.Now;
			List<RealtimePeer> list = new List<RealtimePeer>();
			int count = peerListMessage_0.Names.Count;
			int ClrLqysaTru;
			for (ClrLqysaTru = 0; ClrLqysaTru < count; ClrLqysaTru++)
			{
				RealtimePeer realtimePeer = Peers.FirstOrDefault((RealtimePeer F) => F.Name == peerListMessage_0.Names[ClrLqysaTru]);
				if (realtimePeer == null)
				{
					realtimePeer = new RealtimePeer
					{
						Name = peerListMessage_0.Names[ClrLqysaTru]
					};
				}
				realtimePeer.LastHeard = peerListMessage_0.LastHeards[ClrLqysaTru];
				realtimePeer.TerminalLockedSide = peerListMessage_0.TerminalLockedSides[ClrLqysaTru];
				realtimePeer.CurrentSideName = peerListMessage_0.CurrentSide_Names[ClrLqysaTru];
				realtimePeer.TerminalRights = (TerminalRights)peerListMessage_0.TerminalRights[ClrLqysaTru];
				realtimePeer.Color = peerListMessage_0.Colors[ClrLqysaTru];
				list.Add(realtimePeer);
			}
			Peers = list;
		}
	}

	private void method_9(PushStateMessage pushStateMessage_0)
	{
		PushStateInProgress = true;
		try
		{
			DisableCommandCoreEventNotifications();
			Scenario scenario_0 = CommandCoreInterop.ScenarioFromXML(pushStateMessage_0.ScenXML);
			EnableCommandCoreEventNotifications();
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				uidelegate_0(null);
			}, Array.Empty<object>());
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				pushStateDelegate_0(scenario_0, pushStateMessage_0.NewScenario);
			}, Array.Empty<object>());
		}
		catch (Exception ex)
		{
			GameGeneral.WriteExceptionsToLog(ex);
			PushStateInProgress = false;
		}
	}

	public void OnPushStateComplete()
	{
		PushStateInProgress = false;
	}

	public void SendSelectionChange(Module_Unit.Unit unit, Waypoint waypoint)
	{
		string_0 = unit?.ObjectID;
		string_1 = waypoint?.ObjectID;
		method_50(new SelectionChangeMessage
		{
			Name = unit?.Name,
			ObjectID = unit?.ObjectID,
			WaypointID = waypoint?.ObjectID
		}, "SendSelectionChange");
	}

	public void SendAirHostSelectionChange(List<string> unitIDs)
	{
		List<string> hostUnitIDs = null;
		if (unitIDs != null)
		{
			hostUnitIDs = new List<string>(unitIDs);
		}
		method_50(new HostUnitSelectionChangeMessage
		{
			HostUnitIDs = hostUnitIDs,
			HostUnitType = 1
		}, "SendAirHostSelectionChange");
	}

	public void SendDockingHostSelectionChange(List<ActiveUnit> units)
	{
		List<string> hostUnitIDs = null;
		if (units != null)
		{
			hostUnitIDs = units.Select((ActiveUnit F) => F.ObjectID).ToList();
		}
		method_50(new HostUnitSelectionChangeMessage
		{
			HostUnitIDs = hostUnitIDs,
			HostUnitType = 2
		}, "SendDockingHostSelectionChange");
	}

	public void SendSideChange(Side Side, MapProfile MapProfile, bool ByPlayer)
	{
		method_50(new SideChangeMessage
		{
			Side_Name = Side?.Name,
			Side_ObjectID = Side?.ObjectID,
			Gods_Eye = (MapProfile?.GodsEye ?? false),
			ByPlayer = ByPlayer
		}, "SendSideChange");
	}

	public void SendSpeedRequest(int speed)
	{
		if (AllowChangeSimSpeed)
		{
			method_50(new SpeedRequestMessage
			{
				Speed = speed
			}, "SendSpeedRequest");
		}
	}

	public void SendTogglePause()
	{
		if (AllowChangeSimSpeed)
		{
			if (LastGameSpeed == 0)
			{
				SendSpeedRequest(1);
			}
			else
			{
				SendSpeedRequest(0);
			}
		}
	}

	private void Status(StatusMessage msg)
	{
		LastGameSpeed = msg.Speed;
		hostState_0 = msg.HostState;
		AC_Requester_Name = msg.AC_Requester_Name;
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			statusDelegate_0(msg);
		}, Array.Empty<object>());
	}

	private void SendExecutionSync(uint stepCount, DateTime scenarioTime)
	{
		method_50(new ExecutionSyncMessage
		{
			CurrentStepCount = stepCount,
			CurrentScenarioTime = scenarioTime
		}, "SendExecutionSync");
	}

	private void method_10(ExecutionSyncMessage executionSyncMessage_0)
	{
		if (currentHostSimExecutionStep < executionSyncMessage_0.CurrentStepCount)
		{
			currentHostSimExecutionStep = executionSyncMessage_0.CurrentStepCount;
			previousHostScenarioTime = currentHostScenarioTime;
			currentHostScenarioTime = executionSyncMessage_0.CurrentScenarioTime;
			hostScenarioElapsedTime = (int)(currentHostScenarioTime - previousHostScenarioTime).TotalMilliseconds;
			int num = Environment.TickCount & 0x7FFFFFFF;
			lastHostUpdateTickDuration = num - lastHostUpdateTickTime;
			lastHostUpdateTickTime = num;
			if (lastHostUpdateTickDuration > 0)
			{
				hostRealTimeRatio = (float)hostScenarioElapsedTime / (float)lastHostUpdateTickDuration;
			}
		}
		SendExecutionSync(currentHostSimExecutionStep, currentHostScenarioTime);
	}

	private void method_11(GameOverMessage gameOverMessage_0)
	{
		if (gameOverMessage_0.ScenarioEnd)
		{
			if (ClientScenario != null && !ClientScenario.HasEnded)
			{
				ClientScenario.EndScenario();
			}
		}
		else if (!string.IsNullOrEmpty(gameOverMessage_0.Message))
		{
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				gameOverDelegate_0(gameOverMessage_0.Message, gameOverMessage_0.DisconnectClients);
			}, Array.Empty<object>());
		}
	}

	public void SetMouseDownOnWaypoint(bool value)
	{
		bool_1 = value;
	}

	public uint GetNextUIEventID()
	{
		return uint_0++;
	}

	private void UI(UIMessage msg)
	{
		if (uint_1 != 0 && uint_1 == msg.ClientUIEventID)
		{
			uint_1 = 0u;
			list_0.Clear();
		}
		else if (uint_2 != 0 && uint_2 == msg.ClientUIEventID)
		{
			uint_2 = 0u;
			list_1.Clear();
		}
		else if (uint_3 != 0 && uint_3 == msg.ClientUIEventID)
		{
			uint_3 = 0u;
			list_3.Clear();
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			uidelegate_0(msg);
		}, Array.Empty<object>());
	}

	public void SendCreateWeaponSalvoAction(ActiveUnit shooter, Contact target, int int_6, int weaponQuantity, DateTime? scheduledTime = null, bool creatingSalvoForPallettdWeapon = false, bool creatingSalvoForPallettizedWeapon = false, bool rebuildSalvoCache = false)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		List<string> list = new List<string>(1);
		double bOL_Latitude = 0.0;
		double bOL_Longitude = 0.0;
		if (target.ActualUnit != null)
		{
			list.Add(target.ActualUnit.ObjectID);
		}
		else if (target.Type == Contact_Base.ContactType.ActivationPoint)
		{
			list.Add("BOL");
			bOL_Latitude = ((Module_Unit.Unit)target).get_Latitude((GlobalVariables.BooleanObject)null);
			bOL_Longitude = ((Module_Unit.Unit)target).get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			list.Add(target.ObjectID);
		}
		DateTime scheduledTime2 = new DateTime(0L);
		if (scheduledTime.HasValue && scheduledTime.HasValue)
		{
			scheduledTime2 = scheduledTime.Value;
		}
		method_50(new CreateWeaponSalvoActionMessage
		{
			ShooterID = shooter.ObjectID,
			TargetIDs = list,
			WeaponDBID = int_6,
			WeaponQuantity = weaponQuantity,
			BOL_Latitude = bOL_Latitude,
			BOL_Longitude = bOL_Longitude,
			ScheduledTime = scheduledTime2,
			CreatingSalvoForPalletWeapon = creatingSalvoForPallettdWeapon,
			CreatingSalvoForPallettizedWeapon = creatingSalvoForPallettizedWeapon,
			RebuildSalvoCache = rebuildSalvoCache
		}, "SendCreateWeaponSalvoAction");
	}

	public void SendCancelWeaponSalvoAction(ActiveUnit shooter, Side side, WeaponSalvo salvo, int updatedShooterQuantity)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new CancelWeaponSalvoActionMessage
		{
			ShooterID = shooter.ObjectID,
			SideID = side.ObjectID,
			WeaponSalvoID = salvo.ObjectID,
			WeaponQuantityAssigned = updatedShooterQuantity
		}, "SendCancelWeaponSalvoAction");
	}

	public void SendSalvoCourseUpdate(Side side, WeaponSalvo salvo)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (side != null && salvo != null)
		{
			List<CourseUpdateMessage.CourseElement> course = salvo.PlottedCourse.Select(Helper.ToCourseElement).ToList();
			method_50(new SalvoCourseUpdateMessage
			{
				SideID = side.ObjectID,
				SalvoID = salvo.ObjectID,
				Course = course
			}, "SendSalvoCourseUpdate");
		}
	}

	public void SendExecuteManualSalvosUpdate(Side side)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (side != null)
		{
			method_50(new ExecuteManualWeaponSalvosMessage
			{
				SideID = side.ObjectID
			}, "SendExecuteManualSalvosUpdate");
		}
	}

	private void method_12(WeaponSalvoUpdateMessage weaponSalvoUpdateMessage_0)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		Scenario theScen = ClientScenario;
		if (theScen == null)
		{
			return;
		}
		int count = weaponSalvoUpdateMessage_0.SideIDs.Count;
		for (int i = 0; i < count; i++)
		{
			string id = weaponSalvoUpdateMessage_0.SideIDs[i];
			Side sideByID = ClientScenario.GetSideByID(id);
			if (sideByID == null)
			{
				continue;
			}
			if (weaponSalvoUpdateMessage_0.FullUpdate)
			{
				sideByID.ClearWeaponSalvos();
			}
			int count2 = weaponSalvoUpdateMessage_0.WeaponSalvos[i].Count;
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			for (int j = 0; j < count2; j++)
			{
				string string_0 = weaponSalvoUpdateMessage_0.WeaponSalvos[i][j].Item1;
				string item = weaponSalvoUpdateMessage_0.WeaponSalvos[i][j].Item2;
				WeaponSalvo weaponSalvo = null;
				XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(item)));
				ConcurrentDictionary<string, ScenarioObject> concurrentDictionary = new ConcurrentDictionary<string, ScenarioObject>();
				IEnumerable<WeaponSalvo> enumerable = sideByID.WeaponSalvos.Where((WeaponSalvo F) => F.ObjectID == string_0);
				if (enumerable != null && enumerable.Count() > 0)
				{
					weaponSalvo = enumerable.FirstOrDefault();
				}
				XmlNode nodeByName = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "Target");
				if (nodeByName != null && !nodeByName.InnerText.StartsWith("Aimpoint_") && !nodeByName.InnerText.StartsWith("ActivationPoint_"))
				{
					foreach (Contact contacts_ in sideByID.Contacts_List)
					{
						if (contacts_.ObjectID == nodeByName.InnerText)
						{
							concurrentDictionary.TryAdd(nodeByName.InnerText, contacts_);
							break;
						}
					}
				}
				if (weaponSalvo == null)
				{
					WeaponSalvo item2 = WeaponSalvo.FromXML(ref theNode, concurrentDictionary, ref theScen);
					list.Add(item2);
				}
				else
				{
					WeaponSalvo.FromXML(ref theNode, concurrentDictionary, ref theScen, weaponSalvo);
				}
			}
			foreach (WeaponSalvo item3 in list)
			{
				sideByID.AddWeaponSalvo(item3);
			}
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			weaponSalvosUpdateDelegate_0();
		}, Array.Empty<object>());
	}

	public void SendTargetingContactAutoEngage(Dictionary<ActiveUnit, List<Contact>> Targeting)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		foreach (ActiveUnit item in Targeting.Keys.ToList())
		{
			List<string> list = new List<string>();
			foreach (Contact item2 in Targeting[item])
			{
				if (item2.ActualUnit != null)
				{
					list.Add(item2.ActualUnit.ObjectID);
				}
			}
			dictionary.Add(item.ObjectID, list);
		}
		method_50(new TargetingContactAutoEngageMessage
		{
			TargetingIDs = dictionary
		}, "SendTargetingContactAutoEngage");
	}

	private List<string> method_13(List<Module_Unit.Unit> list_5)
	{
		List<string> list = new List<string>();
		foreach (Module_Unit.Unit item in list_5)
		{
			list.Add(item.ObjectID);
		}
		return list;
	}

	public void SendSetPickupTargetAction(List<Module_Unit.Unit> units, List<string> list_5)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (units != null && units.Count >= 1 && list_5 != null && list_5.Count >= 1)
		{
			List<string> unitIDs = method_13(units);
			method_50(new UnitCargoActionMessage
			{
				Action = 0,
				UnitIDs = unitIDs,
				TargetIDs = list_5,
				CargoIDs = null
			}, "SendSetPickupTargetAction");
		}
	}

	public void SendUnloadCargoAction(List<Module_Unit.Unit> units)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (units != null && units.Count >= 1)
		{
			List<string> unitIDs = method_13(units);
			method_50(new UnitCargoActionMessage
			{
				Action = 1,
				UnitIDs = unitIDs,
				TargetIDs = null,
				CargoIDs = null
			}, "SendUnloadCargoAction");
		}
	}

	public void SendCargoOpsAction(List<ActiveUnit> units, ActiveUnit target, List<Cargo> cargo)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else
		{
			if (units == null || units.Count < 1 || cargo == null)
			{
				return;
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			foreach (ActiveUnit unit in units)
			{
				list.Add(unit.ObjectID);
			}
			if (target != null)
			{
				list2.Add(target.ObjectID);
			}
			foreach (Cargo item in cargo)
			{
				list3.Add(item.ObjectID);
			}
			method_50(new UnitCargoActionMessage
			{
				Action = 2,
				UnitIDs = list,
				TargetIDs = list2,
				CargoIDs = list3
			}, "SendCargoOpsAction");
		}
	}

	public void SendCargoContainerOpsAction(CargoContainer container, List<Cargo> contents, ActiveUnit unit, bool SourceIsContainer)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else
		{
			if (container == null || unit == null || contents == null || contents.Count < 1)
			{
				return;
			}
			ushort action = (ushort)(SourceIsContainer ? 1u : 0u);
			List<ushort> list = new List<ushort>();
			List<int> list2 = new List<int>();
			List<float> list3 = new List<float>();
			List<string> list4 = new List<string>();
			foreach (Cargo content in contents)
			{
				if (content.CargoObjectContainerContents == null)
				{
					if (content.CargoObjectActiveUnit != null)
					{
						list4.Add(content.CargoObjectActiveUnit.ObjectID);
					}
					continue;
				}
				CargoContainerContent cargoObjectContainerContents = content.CargoObjectContainerContents;
				switch (cargoObjectContainerContents.ContentType)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					break;
				case CargoContainerContent.CargoContainerContentType.LiquidFuel:
					list.Add((ushort)cargoObjectContainerContents.ContentType);
					list2.Add((int)((CargoLiquidFuel)cargoObjectContainerContents).FuelType);
					list3.Add(((CargoLiquidFuel)cargoObjectContainerContents).CurrentQuantity);
					break;
				case CargoContainerContent.CargoContainerContentType.Ammunition:
					list.Add((ushort)cargoObjectContainerContents.ContentType);
					list2.Add(((CargoAmmunition)cargoObjectContainerContents).int_1);
					list3.Add(((CargoAmmunition)cargoObjectContainerContents).WeaponQuantity);
					break;
				}
			}
			method_50(new ContainerCargoActionMessage
			{
				Action = action,
				ContainerID = container.ObjectID,
				UnitID = unit.ObjectID,
				CargoContentTypes = list,
				CargoContentIDs = list2,
				CargoContentQuantities = list3,
				CargoContentAUIDs = list4
			}, "SendCargoContainerOpsAction");
		}
	}

	private void method_14(NewChaffCloudMessage newChaffCloudMessage_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newChaffCloudMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		ChaffCorridorCloud item = ChaffCorridorCloud.FromXML(ref theNode, ref theDictionary);
		clientScenario.ChaffClouds.Add(item);
	}

	private void method_15(ConditionUpdateMessage conditionUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		ActiveUnit value = null;
		ActiveUnit activeUnit = null;
		Aircraft aircraft = null;
		AirFacility airFacility = null;
		DockFacility dockFacility = null;
		int count = conditionUpdateMessage_0.OpsObjectIDs.Count;
		int int_0;
		for (int_0 = 0; int_0 < count; int_0++)
		{
			activeUnit = null;
			airFacility = null;
			dockFacility = null;
			if (!clientScenario.ActiveUnits.TryGetValue(conditionUpdateMessage_0.OpsObjectIDs[int_0], out value))
			{
				continue;
			}
			if (!string.IsNullOrEmpty(conditionUpdateMessage_0.OpsHostUnitIDs[int_0]) && clientScenario.ActiveUnits.TryGetValue(conditionUpdateMessage_0.OpsHostUnitIDs[int_0], out activeUnit))
			{
				if (!value.IsAircraft)
				{
					dockFacility = activeUnit.DockFacilities_ReadOnly.Where((DockFacility F) => F.ObjectID == conditionUpdateMessage_0.OpsHostFacilityIDs[int_0]).First();
				}
				else
				{
					airFacility = activeUnit.AirFacilities_ReadOnly.Where((AirFacility F) => F.ObjectID == conditionUpdateMessage_0.OpsHostFacilityIDs[int_0]).First();
				}
			}
			if (!value.IsAircraft)
			{
				value.DockingOps.Condition = (ActiveUnit_DockingOps._DockingOpsCondition)conditionUpdateMessage_0.OpsConditions[int_0];
				value.DockingOps.ConditionTimer = conditionUpdateMessage_0.OpsConditionTimers[int_0];
				if (value.DockingOps.HostDockFacility != dockFacility)
				{
					value.DockingOps.HostDockFacility = dockFacility;
				}
				EmbarkedDockingOpsNewDataReceived = true;
				continue;
			}
			aircraft = (Aircraft)value;
			aircraft.AirOps.Condition = (Aircraft_AirOps._AirOpsCondition)conditionUpdateMessage_0.OpsConditions[int_0];
			aircraft.AirOps.ConditionTimer = conditionUpdateMessage_0.OpsConditionTimers[int_0];
			if (aircraft.AirOps.HostAirFacility != airFacility)
			{
				aircraft.AirOps.HostAirFacility = airFacility;
			}
			EmbarkedAirOpsNewDataReceived = true;
		}
	}

	public void SendContactMiscActionMessage(IEnumerable<Module_Unit.Unit> units, ContactMiscAction action)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		List<string> list = new List<string>();
		Contact contact = null;
		foreach (Module_Unit.Unit unit in units)
		{
			if (unit.IsContact())
			{
				contact = (Contact)unit;
				list.Add(contact._ActualUnitID);
			}
		}
		method_50(new ContactMiscActionMessage
		{
			ObjectIDs = list,
			Action = (byte)action
		}, "SendContactMiscActionMessage");
	}

	public void ContactStance(ContactStanceMessage msg)
	{
		_ = msg.ObjectIDs.Count;
		Scenario clientScenario = ClientScenario;
		Contact value = null;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		foreach (string objectID in msg.ObjectIDs)
		{
			if (!string.IsNullOrEmpty(objectID) && (currentSide.Contacts.TryGetValue(objectID, out value) || currentSide.BaseContacts.TryGetValue(objectID, ref value)))
			{
				value.set_Stance(currentSide, msg.MarkedManually, (Command_Core.Misc.PostureStance)msg.Stance);
			}
		}
	}

	public void ContactFilter(ContactFilterMessage msg)
	{
		Scenario clientScenario = ClientScenario;
		Contact value = null;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		switch ((ContactFilter)msg.Filter)
		{
		case CommandNetcode.RT.ContactFilter.IndividualContact:
			if (!string.IsNullOrEmpty(msg.ObjectID) && (currentSide.Contacts.TryGetValue(msg.ObjectID, out value) || currentSide.BaseContacts.TryGetValue(msg.ObjectID, ref value)))
			{
				value.IsFilteredOut = msg.FilterState;
			}
			break;
		case CommandNetcode.RT.ContactFilter.AllContacts:
			CoreClientCode.SetAllContactsFilteredOutStatus_Core(currentSide, msg.FilterState);
			break;
		case CommandNetcode.RT.ContactFilter.CivilianContacts:
			CoreClientCode.SetCivilianContactsFilteredOutStatus_Core(currentSide, msg.FilterState);
			break;
		case CommandNetcode.RT.ContactFilter.BiologicContacts:
			CoreClientCode.SetBiologicContactsFilteredOutStatus_Core(currentSide, msg.FilterState);
			break;
		case CommandNetcode.RT.ContactFilter.NeutralContacts:
			CoreClientCode.SetNeutralContactsFilteredOutStatus_Core(currentSide, msg.FilterState);
			break;
		case CommandNetcode.RT.ContactFilter.FriendlyContacts:
			CoreClientCode.SetFriendlyContactsFilteredOutStatus_Core(currentSide, msg.FilterState);
			break;
		}
		dispatcher_0.BeginInvoke((Delegate)contactFilterChangeDelegate_0, new object[2] { msg.Filter, msg.FilterState });
	}

	public void RequestUpdateOnContacts(IEnumerable<Module_Unit.Unit> units)
	{
		SendContactMiscActionMessage(units, ContactMiscAction.RequestUpdateOnContacts);
	}

	private void method_16(RTMessage rtmessage_0, Contact contact_0, float float_0, double double_0, double double_1, float float_1)
	{
		if (contact_0.ActualUnit == null)
		{
			return;
		}
		bool flag = InterpolateUnitPositions && LastGameSpeed > 0 && contact_0.UncertaintyArea == null;
		IntermediatePositionUpdateMessage intermediatePositionUpdateMessage = method_53(2, rtmessage_0.SimTimeSent);
		if (intermediatePositionUpdateMessage == null)
		{
			intermediatePositionUpdateMessage = new IntermediatePositionUpdateMessage();
			intermediatePositionUpdateMessage.SimTimeSent = rtmessage_0.SimTimeSent;
			intermediatePositionUpdateMessage.ObjectType = 2;
			intermediatePositionUpdateMessage.ObjectID = new List<string> { contact_0.ActualUnit.ObjectID };
			intermediatePositionUpdateMessage.Heading = new List<float> { contact_0.CurrentHeading };
			intermediatePositionUpdateMessage.Latitude = new List<double> { ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null) };
			intermediatePositionUpdateMessage.Longitude = new List<double> { ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null) };
			intermediatePositionUpdateMessage.Altitude = new List<float> { ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) };
			if (flag)
			{
				method_54(intermediatePositionUpdateMessage, contact_0.ActualUnit.ObjectID);
			}
			tlist_0.Add(intermediatePositionUpdateMessage);
		}
		else
		{
			lock (intermediatePositionUpdateMessage)
			{
				intermediatePositionUpdateMessage.ObjectID.Add(contact_0.ActualUnit.ObjectID);
				intermediatePositionUpdateMessage.Heading.Add(contact_0.CurrentHeading);
				intermediatePositionUpdateMessage.Latitude.Add(((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null));
				intermediatePositionUpdateMessage.Longitude.Add(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null));
				intermediatePositionUpdateMessage.Altitude.Add(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			if (flag)
			{
				method_54(intermediatePositionUpdateMessage, contact_0.ActualUnit.ObjectID);
			}
		}
		if (LastGameSpeed > 0 && contact_0.UncertaintyArea == null)
		{
			contact_0.CurrentHeading = float_0;
			((Module_Unit.Unit)contact_0).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, float_1);
			((Module_Unit.Unit)contact_0).set_Latitude((GlobalVariables.BooleanObject)null, double_0);
			((Module_Unit.Unit)contact_0).set_Longitude((GlobalVariables.BooleanObject)null, double_1);
		}
	}

	private void method_17(ContactAddOrUpdateMessage contactAddOrUpdateMessage_0)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		int count = contactAddOrUpdateMessage_0.XMLs.Count;
		for (int i = 0; i < count; i++)
		{
			string text = contactAddOrUpdateMessage_0.XMLs[i];
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(text)));
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			Contact contact_0 = null;
			string innerText = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ActualUnitID").InnerText;
			Scenario theScen = ClientScenario;
			if (theScen == null)
			{
				break;
			}
			Side theSide = theScen.GetCurrentSide();
			ActiveUnit value = null;
			if (theSide == null)
			{
				break;
			}
			bool flag = LastGameSpeed > 0;
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				theDictionary.TryAdd(side.ObjectID, side);
			}
			if (theScen.ActiveUnits.TryGetValue(innerText, out value))
			{
				theDictionary.TryAdd(innerText, value);
			}
			float float_ = 0f;
			float float_2 = 0f;
			double double_ = 0.0;
			double double_2 = 0.0;
			lock (TerminalRenderLockObj)
			{
				if (!theSide.Contacts.TryGetValue(innerText, out contact_0) && !theSide.BaseContacts.TryGetValue(innerText, ref contact_0))
				{
					contact_0 = Contact.FromXML(ref theNode, ref theDictionary);
					contact_0.PostDeserializationHousekeeping(ref theScen, ref theDictionary, ref theSide);
					contact_0.set_KnownIncomingGuidedWeaponsCount(theSide, contactAddOrUpdateMessage_0.KnownIncomingGuidedWeaponsCount[i]);
					if (contact_0.ActualUnit == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						continue;
					}
					((Module_Unit.Unit)contact_0).set_UnitSide(SetSideOnly: false, ((Module_Unit.Unit)contact_0.ActualUnit).get_UnitSide(SetSideOnly: false));
					if (!contact_0.ActualUnit.IsGroup)
					{
						theSide.Contacts.Add(contact_0._ActualUnitID, contact_0);
						continue;
					}
					Group.GroupType type = ((Group)contact_0.ActualUnit).Type;
					if (type - 3 > Group.GroupType.Installation)
					{
						theSide.Contacts.Add(contact_0._ActualUnitID, contact_0);
					}
					else
					{
						theSide.BaseContacts.Add(contact_0._ActualUnitID, contact_0);
					}
				}
				else
				{
					if (flag)
					{
						float_ = contact_0.CurrentHeading;
						float_2 = ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						double_ = ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null);
						double_2 = ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null);
					}
					Contact.FromXML(ref theNode, ref theDictionary, contact_0);
					contact_0.PostDeserializationHousekeeping(ref theScen, ref theDictionary, ref theSide);
					contact_0.set_KnownIncomingGuidedWeaponsCount(theSide, contactAddOrUpdateMessage_0.KnownIncomingGuidedWeaponsCount[i]);
					if (flag)
					{
						method_16(contactAddOrUpdateMessage_0, contact_0, float_, double_, double_2, float_2);
					}
					dispatcher_0.BeginInvoke((Delegate)(Action)delegate
					{
						contactUpdateDelegate_0(contact_0.ObjectID);
					}, Array.Empty<object>());
				}
			}
		}
	}

	private void method_18(ContactRemoveMessage contactRemoveMessage_0)
	{
		int count = contactRemoveMessage_0.ObjectID.Count;
		Side currentSide = ClientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		lock (TerminalRenderLockObj)
		{
			for (int i = 0; i < count; i++)
			{
				if (!currentSide.Contacts.Remove(contactRemoveMessage_0.ObjectID[i]))
				{
					currentSide.BaseContacts.Remove(contactRemoveMessage_0.ObjectID[i]);
				}
			}
		}
	}

	private void method_19(ContactStatusMessage contactStatusMessage_0)
	{
		int count = contactStatusMessage_0.ObjectID.Count;
		Scenario clientScenario = ClientScenario;
		Contact value = null;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		bool flag;
		int num;
		if (!(flag = LastGameSpeed > 0))
		{
			num = 0;
		}
		else
		{
			method_27(2, contactStatusMessage_0.SimTimeSent, contactStatusMessage_0.ObjectID, contactStatusMessage_0.Heading, contactStatusMessage_0.Latitude, contactStatusMessage_0.Longitude, contactStatusMessage_0.Altitude);
			num = 0;
		}
		for (int i = num; i < count; i++)
		{
			if (currentSide.Contacts.TryGetValue(contactStatusMessage_0.ObjectID[i], out value) || currentSide.BaseContacts.TryGetValue(contactStatusMessage_0.ObjectID[i], ref value))
			{
				if (!flag)
				{
					((Module_Unit.Unit)value).set_Latitude((GlobalVariables.BooleanObject)null, contactStatusMessage_0.Latitude[i]);
					((Module_Unit.Unit)value).set_Longitude((GlobalVariables.BooleanObject)null, contactStatusMessage_0.Longitude[i]);
					value.CurrentHeading = contactStatusMessage_0.Heading[i];
					((Module_Unit.Unit)value).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, contactStatusMessage_0.Altitude[i]);
				}
				value.Altitude_old = contactStatusMessage_0.Altitude_Old[i];
				value.CurrentVerticalRate_mpersec = null;
				value.CurrentSpeed = contactStatusMessage_0.Speed[i];
				value.SpeedIsKnown = contactStatusMessage_0.SpeedIsKnown[i];
				value.HeadingIsKnown = contactStatusMessage_0.HeadingIsKnown[i];
				value.AltitudeIsKnown = contactStatusMessage_0.AltitudeIsKnown[i];
				value.SideIsKnown = contactStatusMessage_0.SideIsKnown[i];
				value.Name = contactStatusMessage_0.Name[i];
				value.Age = contactStatusMessage_0.Age[i];
				value.set_Stance(currentSide, MarkManually: false, (Command_Core.Misc.PostureStance)contactStatusMessage_0.Stance[i]);
				value.IsFilteredOut = contactStatusMessage_0.IsFilteredOut[i];
				value.set_KnownIncomingGuidedWeaponsCount(currentSide, contactStatusMessage_0.KnownIncomingGuidedWeaponsCount[i]);
				if (contactStatusMessage_0.UncertaintyArea[i].Count > 0)
				{
					value.UncertaintyArea = new List<Geopoint_Struct>(contactStatusMessage_0.UncertaintyArea[i].Select(Helper.ToGeoPointStruct));
				}
				else
				{
					value.UncertaintyArea = null;
				}
			}
		}
	}

	private void method_20(IntermediatePositionUpdateMessage intermediatePositionUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		int num = 0;
		lock (intermediatePositionUpdateMessage_0)
		{
			num = intermediatePositionUpdateMessage_0.ObjectID.Count;
		}
		for (int i = 0; i < num; i++)
		{
			Contact contact = null;
			if (!currentSide.Contacts.ContainsKey(intermediatePositionUpdateMessage_0.ObjectID[i]))
			{
				if (currentSide.BaseContacts.ContainsKey(intermediatePositionUpdateMessage_0.ObjectID[i]))
				{
					contact = currentSide.BaseContacts[intermediatePositionUpdateMessage_0.ObjectID[i]];
				}
			}
			else
			{
				contact = currentSide.Contacts[intermediatePositionUpdateMessage_0.ObjectID[i]];
			}
			if (contact != null && (intermediatePositionUpdateMessage_0.ObjectType == 2 || InterpolateAmbiguousContactPositions || contact.UncertaintyArea == null))
			{
				contact.CurrentHeading = intermediatePositionUpdateMessage_0.Heading[i];
				((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Latitude[i]);
				((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Longitude[i]);
				((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Altitude[i]);
				if (contact.ActualUnit != null && contact.AltitudeIsKnown)
				{
					contact.ActualUnit.Altitude_old = ((Module_Unit.Unit)contact.ActualUnit).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					((Module_Unit.Unit)contact.ActualUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Altitude[i]);
					Module_Unit.CurrentSpeed_Vertical(contact.ActualUnit, clientScenario, Recompute: true);
				}
			}
		}
	}

	public uint SendCourseUpdate(IList<ActiveUnit> list)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		int count = list.Count;
		List<string> list2 = new List<string>(count);
		List<List<CourseUpdateMessage.CourseElement>> list3 = new List<List<CourseUpdateMessage.CourseElement>>(count);
		uint nextUIEventID = GetNextUIEventID();
		for (int i = 0; i < count; i++)
		{
			list2.Add(list[i].ObjectID);
			list3.Add(list[i].Navigator.PlottedCourse.Select(Helper.ToCourseElement).ToList());
		}
		method_50(new CourseUpdateMessage
		{
			ClientUIEventID = nextUIEventID,
			ObjectID = list2,
			Courses = list3
		}, "SendCourseUpdate");
		uint_1 = nextUIEventID;
		list_0.Clear();
		foreach (ActiveUnit item in list)
		{
			list_0.Add(item.ObjectID);
			if (item.IsGroup)
			{
				Group obj = (Group)item;
				if (obj.GroupLead != null)
				{
					list_0.Add(obj.GroupLead.ObjectID);
				}
			}
			else
			{
				Group obj2 = item.get_ParentGroup(UsingMissionPlanner: false);
				if (obj2 != null && obj2.GroupLead == item)
				{
					list_0.Add(obj2.ObjectID);
				}
			}
		}
		if (bool_1 && !string.IsNullOrEmpty(string_1))
		{
			list_0.Add(string_1);
		}
		return nextUIEventID;
	}

	private void method_21(CourseUpdateMessage courseUpdateMessage_0)
	{
		int count = courseUpdateMessage_0.ObjectID.Count;
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			if ((bool_1 && !string.IsNullOrEmpty(string_1)) || (uint_1 != 0 && list_0.Contains(courseUpdateMessage_0.ObjectID[i])) || !clientScenario.ActiveUnits.ContainsKey(courseUpdateMessage_0.ObjectID[i]))
			{
				continue;
			}
			ActiveUnit activeUnit_0 = clientScenario.ActiveUnits[courseUpdateMessage_0.ObjectID[i]];
			if (!(activeUnit_0.Name == "1"))
			{
				Waypoint[] waypoint_0 = courseUpdateMessage_0.Courses[i].Select(Helper.ToWaypoint).ToArray();
				dispatcher_0.BeginInvoke((Delegate)(Action)delegate
				{
					courseUpdateDelegate_0(activeUnit_0, waypoint_0);
				}, Array.Empty<object>());
			}
		}
	}

	public void PollForLocalDoctrineStateChange(Doctrine CheckDoctrine, ActiveUnit CheckUnit)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		Scenario theScen = ClientScenario;
		if (theScen == null)
		{
			return;
		}
		Side currentSide = theScen.GetCurrentSide();
		if (HasAbsoluteControl || currentSide == null || (CheckDoctrine == null && CheckUnit == null))
		{
			return;
		}
		string text = "";
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		lock (object_0)
		{
			if (CheckDoctrine != null && dictionary_0.ContainsKey(CheckDoctrine.Subject.ObjectID))
			{
				stringBuilder.Clear();
				XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
				CheckDoctrine.ToXML(ref theWriter, ref theScen);
				theWriter.Flush();
				text = stringBuilder.ToString();
				if (dictionary_0[CheckDoctrine.Subject.ObjectID] != text)
				{
					DoctrineHelper.DoctrineSubject subjectType = DoctrineHelper.GetSubjectType(CheckDoctrine.Subject);
					method_50(new DoctrineChangedMessage
					{
						SubjectID = CheckDoctrine.Subject.ObjectID,
						SubjectType = (short)subjectType,
						DoctrineXML = text
					}, "PollForLocalDoctrineStateChange");
					dictionary_0[CheckDoctrine.Subject.ObjectID] = text;
				}
			}
			if (CheckUnit != null && dictionary_0.ContainsKey(CheckUnit.Doctrine.Subject.ObjectID))
			{
				stringBuilder.Clear();
				XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
				CheckUnit.Doctrine.ToXML(ref theWriter, ref theScen);
				theWriter.Flush();
				text = stringBuilder.ToString();
				if (dictionary_0[CheckUnit.Doctrine.Subject.ObjectID] != text)
				{
					DoctrineHelper.DoctrineSubject subjectType = DoctrineHelper.GetSubjectType(CheckUnit);
					method_50(new DoctrineChangedMessage
					{
						SubjectID = CheckUnit.Doctrine.Subject.ObjectID,
						SubjectType = (short)subjectType,
						DoctrineXML = text
					}, "PollForLocalDoctrineStateChange");
					dictionary_0[CheckUnit.Doctrine.Subject.ObjectID] = text;
				}
			}
			StringBuilderCache.Free(stringBuilder);
		}
	}

	private void method_22(DoctrineUpdateMessage doctrineUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		ActiveDeserializationCount++;
		try
		{
			Doctrine doctrine_0 = null;
			DoctrineHelper.DoctrineSubject subjectType = (DoctrineHelper.DoctrineSubject)doctrineUpdateMessage_0.SubjectType;
			if (DoctrineHelper.UpdateDoctrineFromXML(clientScenario, doctrineUpdateMessage_0.SubjectID, subjectType, doctrineUpdateMessage_0.DoctrineXML, out doctrine_0))
			{
				lock (object_0)
				{
					if (!dictionary_0.ContainsKey(doctrine_0.Subject.ObjectID))
					{
						dictionary_0.Add(doctrine_0.Subject.ObjectID, doctrineUpdateMessage_0.DoctrineXML);
					}
					else
					{
						dictionary_0[doctrine_0.Subject.ObjectID] = doctrineUpdateMessage_0.DoctrineXML;
					}
				}
				dispatcher_0.BeginInvoke((Delegate)(Action)delegate
				{
					doctrineUpdateDelegate_0(doctrine_0);
				}, Array.Empty<object>());
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		ActiveDeserializationCount--;
	}

	public void SendDoctrineSelected(ScenarioObject subject)
	{
		string subjectID = "";
		if (subject != null)
		{
			subjectID = subject.ObjectID;
		}
		method_50(new SelectDoctrineMessage
		{
			SubjectID = subjectID
		}, "SendDoctrineSelected");
	}

	public void SendDoctrineChanged(ScenarioObject subject)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		Scenario theScen = ClientScenario;
		if (theScen == null || subject == null)
		{
			return;
		}
		try
		{
			if (DoctrineHelper.GetSubjectTypeAndDoctrine(theScen, subject, out var subjectType, out var subjectDoctrine))
			{
				string text = "";
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
				subjectDoctrine.ToXML(ref theWriter, ref theScen);
				theWriter.Flush();
				text = stringBuilder.ToString();
				StringBuilderCache.Free(stringBuilder);
				method_50(new DoctrineChangedMessage
				{
					SubjectID = subject.ObjectID,
					SubjectType = (short)subjectType,
					DoctrineXML = text
				}, "SendDoctrineChanged");
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

	public void OnDoctrineSelected(ScenarioObject subject)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		SendDoctrineSelected(subject);
		if (subject == null)
		{
			return;
		}
		Scenario theScen = ClientScenario;
		if (theScen != null && !dictionary_0.ContainsKey(subject.ObjectID))
		{
			string text = "";
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			if (DoctrineHelper.GetSubjectTypeAndDoctrine(theScen, subject, out var _, out var subjectDoctrine))
			{
				subjectDoctrine.ToXML(ref theWriter, ref theScen);
				theWriter.Flush();
				text = stringBuilder.ToString();
				dictionary_0.Add(subject.ObjectID, text);
			}
			StringBuilderCache.Free(stringBuilder);
		}
	}

	public int EmbarkedOps_GetReadyAircraftCount(ActiveUnit host)
	{
		if (!dictionary_3.TryGetValue(host.ObjectID, out var value))
		{
			return 0;
		}
		return value;
	}

	public int EmbarkedOps_GetReadyBoatCount(ActiveUnit host)
	{
		if (!dictionary_2.TryGetValue(host.ObjectID, out var value))
		{
			return 0;
		}
		return value;
	}

	public bool EmbarkedOps_HasEmbarkedUnits(ActiveUnit host)
	{
		if (!dictionary_1.TryGetValue(host, out var value))
		{
			return false;
		}
		return value.Count > 0;
	}

	public List<ActiveUnit> EmbarkedOps_GetEmbarkedBoats(ActiveUnit host)
	{
		return (from F in EmbarkedOps_GetEmbarkedUnits(host)
			where F.IsBoat
			select F).ToList();
	}

	public List<Aircraft> EmbarkedOps_GetEmbarkedAircraft(ActiveUnit host)
	{
		return (from F in EmbarkedOps_GetEmbarkedUnits(host)
			where F.IsAircraft
			select F).Cast<Aircraft>().ToList();
	}

	public HashSet<ActiveUnit> EmbarkedOps_GetEmbarkedUnits(ActiveUnit host)
	{
		if (dictionary_1.TryGetValue(host, out var value))
		{
			return value;
		}
		return new HashSet<ActiveUnit>();
	}

	public void SendRearmAircraftMessage(IEnumerable<ActiveUnit> Aircraft, bool ReadyImmediately, bool ManualAction, bool ExcludeOptionalWeapons, bool DrawWeaponsFromMagazine, int LoadoutID, bool CB_QuickTurnaround_Checked)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new EmbarkedOpsRearmMessage
		{
			Aircraft = Aircraft.Select((ActiveUnit F) => F.ObjectID).ToList(),
			ReadyImmediately = ReadyImmediately,
			ManualAction = ManualAction,
			ExcludeOptionalWeapons = ExcludeOptionalWeapons,
			DrawWeaponsFromMagazine = DrawWeaponsFromMagazine,
			LoadoutID = LoadoutID,
			CB_QuickTurnaround_Checked = CB_QuickTurnaround_Checked
		}, "SendRearmAircraftMessage");
	}

	public void SendLaunchEmbarkedUnitMessage(List<string> LaunchAircraftIndividually = null, List<string> LaunchBoatsIndividually = null, List<string> LaunchAircraftGroup = null, List<string> LaunchBoatsGroup = null, List<string> AbortAircraft = null, List<string> AbortBoats = null)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new EmbarkedOpsLaunchMessage
		{
			LaunchAircraftGroup = LaunchAircraftGroup,
			LaunchAircraftIndividually = LaunchAircraftIndividually,
			LaunchBoatsGroup = LaunchBoatsGroup,
			LaunchBoatsIndividually = LaunchBoatsIndividually,
			AbortAircraft = AbortAircraft,
			AbortBoats = AbortBoats
		}, "SendLaunchEmbarkedUnitMessage");
	}

	private void method_23(EmbarkedOpsUpdateMessage embarkedOpsUpdateMessage_0)
	{
		<>c__DisplayClass203_0 CS$<>8__locals4 = new <>c__DisplayClass203_0();
		CS$<>8__locals4.scenario_0 = ClientScenario;
		if (CS$<>8__locals4.scenario_0 == null)
		{
			return;
		}
		dictionary_2 = embarkedOpsUpdateMessage_0.ReadyBoatCount;
		dictionary_3 = embarkedOpsUpdateMessage_0.ReadyAircraftCount;
		dictionary_1 = new Dictionary<ActiveUnit, HashSet<ActiveUnit>>();
		foreach (KeyValuePair<string, HashSet<string>> item in embarkedOpsUpdateMessage_0.Embarked)
		{
			ActiveUnit activeUnit = CS$<>8__locals4.method_0(item.Key);
			if (activeUnit != null)
			{
				dictionary_1.Add(activeUnit, new HashSet<ActiveUnit>(from F in item.Value.Select(delegate(string objID)
					{
						ActiveUnit value = null;
						CS$<>8__locals4.scenario_0.ActiveUnits.TryGetValue(objID, out value);
						return value;
					})
					where F != null
					select F));
			}
		}
		EmbarkedAirOpsNewDataReceived = true;
		EmbarkedDockingOpsNewDataReceived = true;
	}

	private void method_24(NewExplosionMessage newExplosionMessage_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newExplosionMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		Explosion item = Explosion.FromXML(ref theNode, ref theDictionary);
		clientScenario.Explosions.Add(item);
	}

	public void MissionEditorWarningMessage(MissionEditorShowWarningMessage msg)
	{
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			showWarningDelegate_0(msg.Message, msg.Title);
		}, Array.Empty<object>());
	}

	public void MissionEditorEvent(MissionEditorEventMessage msg)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario != null)
		{
			clientScenario.MissionPlannerErrorList.Clear();
			if (msg.errors != null && msg.errors.Count > 0 && clientScenario != null)
			{
				clientScenario.MissionPlannerErrorList.Clear();
				foreach (var error in msg.errors)
				{
					clientScenario.MissionPlannerErrorList.Add(new MDSP_Error(error.Item1, error.Item2, error.Item3));
				}
			}
		}
		MissionEditorEventMessage.EventType eventType = (MissionEditorEventMessage.EventType)msg.eventType;
		if ((uint)(eventType - 1) <= 1u)
		{
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				missionEditorEventDelegate_0(msg.eventType);
			}, Array.Empty<object>());
		}
	}

	public void SendMissionEditorGenerateFlightPlans(Mission mission, int RequestedFlightSize, MissionFlightPlanGenerationFlags flags = MissionFlightPlanGenerationFlags.CreateNew)
	{
		if (mission != null)
		{
			method_50(new MissionGenerateFlightPlansMessage
			{
				MissionID = mission.ObjectID,
				RequestedFlightSize = (short)RequestedFlightSize,
				Flags = (short)flags
			}, "MissionEditorGenerateFlightPlans");
		}
	}

	public void SendMissionEditorGenerateTaskPoolFlights(Mission taskPool, List<Mission> packages)
	{
		if (taskPool == null || packages == null || packages.Count < 1)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (Mission package in packages)
		{
			list.Add(package.ObjectID);
		}
		method_50(new MissionGenerateFlightsForTaskPoolMessage
		{
			TaskPoolID = taskPool.ObjectID,
			PackageIDs = list
		}, "SendMissionEditorGenerateTaskPoolFlights");
	}

	public void SendMissionEditorFillEmptySlots(Mission mission, bool isManual, Mission.Flight specificFlight, bool fillFlightsWithNoAircraftSpecified)
	{
		if (mission != null)
		{
			string specificFlightID = "";
			if (specificFlight != null)
			{
				specificFlightID = specificFlight.ObjectID;
			}
			method_50(new MissionFillEmptySlotsMessage
			{
				MissionID = mission.ObjectID,
				IsManual = isManual,
				SpecificFlightID = specificFlightID,
				FillFlightsWithNoAircraftSpecified = fillFlightsWithNoAircraftSpecified
			}, "SendMissionEditorFillEmptySlots");
		}
	}

	public void SendMissionEditorDeleteFlights(Mission mission, List<Mission.Flight> flights = null)
	{
		if (mission == null)
		{
			return;
		}
		List<string> list = new List<string>();
		if (flights != null)
		{
			foreach (Mission.Flight flight in flights)
			{
				list.Add(flight.ObjectID);
			}
		}
		method_50(new MissionEditorDeleteFlightsMessage
		{
			MissionID = mission.ObjectID,
			FlightIDs = list
		}, "SendMissionEditorDeleteFlights");
	}

	public void SendClearAircraftReplaceWithEmptySlots(Scenario scen, Side side, Mission mission, Mission.Flight flight, ActiveUnit unit = null)
	{
		if (mission != null && flight != null)
		{
			string unitID = "";
			if (unit != null)
			{
				unitID = unit.ObjectID;
			}
			method_50(new ChangeFlightMessage
			{
				ChangeType = 1,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				UnitID = unitID
			}, "SendClearAircraftReplaceWithEmptySlots");
		}
	}

	public void SendChangeFlightLocation(Scenario scen, Side side, Mission mission, Mission.Flight flight, Module_Unit.Unit selectedUnit, bool isTakeoffLocation, bool isLandingLocation, bool isDivertLocation)
	{
		if (mission == null || flight == null || selectedUnit == null)
		{
			return;
		}
		short num = 0;
		if (isTakeoffLocation)
		{
			num = 2;
		}
		else if (isLandingLocation)
		{
			num = 3;
		}
		else
		{
			if (!isDivertLocation)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			num = 5;
		}
		method_50(new ChangeFlightMessage
		{
			ChangeType = num,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			UnitID = selectedUnit.ObjectID
		}, "SendChangeFlightLocation");
	}

	public void SendChangeFlightType(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission._FlightType flightType)
	{
		if (mission != null && flight != null)
		{
			method_50(new ChangeFlightMessage
			{
				ChangeType = 6,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Value = (int)flightType
			}, "SendChangeFlightType");
		}
	}

	public void SendChangeFlightAircraftType(Scenario scen, Side side, Mission mission, Mission.Flight flight, bool ClearExistingAircraft, int AircraftDBID)
	{
		if (mission != null && flight != null)
		{
			short changeType = 7;
			if (ClearExistingAircraft)
			{
				changeType = 8;
			}
			method_50(new ChangeFlightMessage
			{
				ChangeType = changeType,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Value = AircraftDBID
			}, "SendChangeFlightAircraftType");
		}
	}

	public void SendChangeFlightLoadout(Scenario scen, Side side, Mission mission, Mission.Flight flight, bool ClearExistingAircraft, int int_6, string LoadoutName = "")
	{
		if (mission != null && flight != null)
		{
			short changeType = 9;
			if (ClearExistingAircraft)
			{
				changeType = 10;
			}
			method_50(new ChangeFlightMessage
			{
				ChangeType = changeType,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Value = int_6,
				Text = LoadoutName
			}, "SendChangeFlightLoadout");
		}
	}

	public void SendChangeFlightAssignedAircraft(Scenario scen, Side side, Mission mission, Mission.Flight flight, List<ActiveUnit> assignedUnits)
	{
		if (mission == null || flight == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (ActiveUnit assignedUnit in assignedUnits)
		{
			list.Add(assignedUnit.ObjectID);
		}
		method_50(new ChangeFlightMessage
		{
			ChangeType = 11,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			UnitListIDs = list
		}, "SendChangeFlightAssignedAircraft");
	}

	public void SendChangeFlightSize(Scenario scen, Side side, Mission mission, Mission.Flight flight, int DesiredFlightSize, int MinimumFlightSize)
	{
		if (mission == null || flight == null)
		{
			return;
		}
		short num = 0;
		int num2 = 0;
		if (!(DesiredFlightSize != flight.DesiredAircraftQty))
		{
			if (!(MinimumFlightSize != flight.MinimumAircraftQty))
			{
				return;
			}
			num = 13;
			num2 = MinimumFlightSize;
		}
		else
		{
			num = 12;
			num2 = DesiredFlightSize;
		}
		method_50(new ChangeFlightMessage
		{
			ChangeType = num,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			Value = num2
		}, "SendChangeFlightSize");
	}

	public void SendChangeFlightTask(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission._FlightTask task)
	{
		if (mission != null && flight != null)
		{
			method_50(new ChangeFlightMessage
			{
				ChangeType = 14,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Value = (int)task
			}, "SendChangeFlightTask");
		}
	}

	public void SendChangeFlightPriority(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission._FlightPriority priority)
	{
		if (mission != null && flight != null)
		{
			method_50(new ChangeFlightMessage
			{
				ChangeType = 15,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Value = (int)priority
			}, "SendChangeFlightPriority");
		}
	}

	public void SendChangeFlightCallsign(Scenario scen, Side side, Mission mission, Mission.Flight flight, string newCallSign)
	{
		if (mission != null && flight != null)
		{
			method_50(new ChangeFlightMessage
			{
				ChangeType = 16,
				MissionID = mission.ObjectID,
				FlightID = flight.ObjectID,
				Text = newCallSign
			}, "SendChangeFlightCallsign");
		}
	}

	public void SendChangeFlightPlanWaypointAttackMethod(Scenario scen, Side side, Mission mission, Mission.Flight flight, Waypoint waypoint, int AttackMethod)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 1,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			Value = AttackMethod
		}, "SendChangeFlightPlanWaypointAttackMethod");
	}

	public void SendChangeFlightPlanWaypointTime(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightElement, Waypoint waypoint, DateTime dateTime, float holdSeconds, float stationSeconds, float spacingSeconds, float separationSeconds)
	{
		List<float> list = new List<float>();
		list.Add(holdSeconds);
		list.Add(stationSeconds);
		list.Add(spacingSeconds);
		list.Add(separationSeconds);
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 2,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			FlightElement = (short)flightElement,
			WaypointID = waypoint.ObjectID,
			Value = dateTime.Ticks,
			values_f = list
		}, "SendChangeFlightPlanWaypointTime");
	}

	public void SendChangeFlightPlanWaypointUpdateLockWingmanTargetTime(Scenario scen, Side side, Mission mission, Mission.Flight flight, Waypoint waypoint, Mission.Flight.FlightElement flightPlanElement)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 9,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement
		}, "SendChangeFlightPlanWaypointUpdateLockWingmanTargetTime");
	}

	public void SendChangeFlightPlanWaypointUpdateWingmanTargetTime(Scenario scen, Side side, Mission mission, Mission.Flight flight, Waypoint waypoint, Mission.Flight.FlightElement flightPlanElement, bool LockTimes)
	{
		short changeType = 10;
		if (!LockTimes)
		{
			changeType = 11;
		}
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = changeType,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement
		}, "SendChangeFlightPlanWaypointUpdateWingmanTargetTime");
	}

	public void SendChangeFlightPlanWaypointType(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, Waypoint.WaypointType newType, Waypoint nextWaypoint, bool RefuelFromWaypointOnly)
	{
		string nextWaypointID = "";
		if (nextWaypoint != null)
		{
			nextWaypointID = nextWaypoint.ObjectID;
		}
		List<float> list = null;
		if (RefuelFromWaypointOnly)
		{
			list = new List<float>();
			list.Add(1f);
		}
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 3,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			NextWaypointID = nextWaypointID,
			Value = (long)newType,
			values_f = list
		}, "SendChangeFlightPlanWaypointType");
	}

	public void SendChangeFlightPlanWaypointFormation(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, Waypoint.Formation newFormation, Waypoint nextWaypoint, Waypoint previousWaypoint)
	{
		string nextWaypointID = "";
		string previousWaypointID = "";
		if (nextWaypoint != null)
		{
			nextWaypointID = nextWaypoint.ObjectID;
		}
		if (previousWaypoint != null)
		{
			previousWaypointID = previousWaypoint.ObjectID;
		}
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 4,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			NextWaypointID = nextWaypointID,
			PreviousWaypointID = previousWaypointID,
			Value = (long)newFormation
		}, "SendChangeFlightPlanWaypointFormation");
	}

	public void SendChangeFlightPlanWaypointTurnRate(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, Waypoint.TurnRateCategory newRate)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 5,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			Value = (long)newRate
		}, "SendChangeFlightPlanWaypointTurnRate");
	}

	public void SendChangeFlightPlanWaypointDoctriineAARUsage(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, int newUsage)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 6,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			Value = newUsage
		}, "SendChangeFlightPlanWaypointDoctriineAARUsage");
	}

	public void SendChangeFlightPlanWaypointDoctriineAARSelection(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, int newSelection)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 6,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			Value = newSelection
		}, "SendChangeFlightPlanWaypointDoctriineAARSelection");
	}

	public void SendChangeFlightPlanWaypointSpeedTOT(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint, Waypoint.SpeedToT speedToT_0)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 8,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement,
			Value = (long)speedToT_0
		}, "SendChangeFlightPlanWaypointSpeedTOT");
	}

	public void SendChangeFlightPlanDeleteWaypoint(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint waypoint)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 12,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightPlanElement
		}, "SendChangeFlightPlanDeleteWaypoint");
	}

	public void SendChangeFlightInsertWaypointAfter(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightPlanElement, Waypoint preceedingWaypoint)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 13,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = preceedingWaypoint.ObjectID,
			FlightElement = (short)flightPlanElement
		}, "SendChangeFlightInsertWaypointAfter");
	}

	public void SendChangeFlightToggleWaypointTime(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightElement, Waypoint waypoint)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 14,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightElement
		}, "SendChangeFlightToggleWaypointTime");
	}

	public void SendChangeFlightToggleWaypointSpeed(Scenario scen, Side side, Mission mission, Mission.Flight flight, Mission.Flight.FlightElement flightElement, Waypoint waypoint)
	{
		method_50(new ChangeFlightPlanWaypointMessage
		{
			ChangeType = 15,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID,
			WaypointID = waypoint.ObjectID,
			FlightElement = (short)flightElement
		}, "SendChangeFlightToggleWaypointTime");
	}

	public void SendChangeFlightToggleTakeOffWaypointTime(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 17,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendChangeFlightToggleTakeOffWaypointTime");
	}

	public void SendChangeFlightToggleTargetWaypointTime(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 18,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendChangeFlightToggleTargetWaypointTime");
	}

	public void SendMissionDeleteFlight(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 21,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendMissionDeleteFlight");
	}

	public void SendMissionCreateFlight(Scenario scen, Side side, Mission mission, Mission._FlightSize flightSize, bool isEscort)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 19,
			MissionID = mission.ObjectID,
			Value = flightSize,
			Flag = isEscort
		}, "SendMissionCreateFlight");
	}

	public void SendMissionCopyFlight(Scenario scen, Side side, Mission mission, Mission.Flight originalFlight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 20,
			MissionID = mission.ObjectID,
			FlightID = originalFlight.ObjectID
		}, "SendMissionCopyFlight");
	}

	public void SendClearFlightTimes(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 23,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendClearFlightTimes");
	}

	public void SendDeleteFlightPlan(Scenario scen, Side side, Mission mission, Mission.Flight originalFlight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 22,
			MissionID = mission.ObjectID,
			FlightID = originalFlight.ObjectID
		}, "SendDeleteFlightPlan");
	}

	public void SendCreateFlightPlanFull(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 24,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendCreateFlightPlanFull");
	}

	public void SendCreateFlightPlanSkeleton(Scenario scen, Side side, Mission mission, Mission.Flight flight)
	{
		method_50(new ChangeFlightMessage
		{
			ChangeType = 25,
			MissionID = mission.ObjectID,
			FlightID = flight.ObjectID
		}, "SendCreateFlightPlanSkeleton");
	}

	private void method_25(NewGroundImpactMessage newGroundImpactMessage_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newGroundImpactMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		GroundImpact item = GroundImpact.FromXML(ref theNode, ref theDictionary);
		clientScenario.GroundImpacts.Add(item);
	}

	public void GroupMembershipUpdate(GroupMembershipUpdateMessage msg)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		ActiveUnit value = null;
		ActiveUnit value2 = null;
		Group obj = null;
		int count = msg.UnitIDs.Count;
		for (int i = 0; i < count; i++)
		{
			if (clientScenario.ActiveUnits.TryGetValue(msg.UnitIDs[i], out value))
			{
				if (string.IsNullOrEmpty(msg.ParentGroupIDs[i]))
				{
					value.set_ParentGroup(UsingMissionPlanner: true, (Group)null);
				}
				else if (clientScenario.ActiveUnits.TryGetValue(msg.ParentGroupIDs[i], out value2))
				{
					obj = (Group)value2;
					value.set_ParentGroup(UsingMissionPlanner: true, obj);
				}
			}
		}
	}

	public void SendSetFormation(string formationLuaCode)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new GroupFormationSetMessage
		{
			Flags = 1,
			Formation = formationLuaCode
		}, "SendSetFormation");
	}

	public void SendSetFormation(Module_Unit.Unit group, string formationName, float baseHeading, float baseDistance, int distanceUnits, bool teleportUnits)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new GroupFormationSetMessage
		{
			GroupID = group.ObjectID,
			Formation = formationName,
			Heading = baseHeading,
			Spacing = baseDistance,
			SpacingUnits = (short)distanceUnits,
			TeleportUnits = teleportUnits
		}, "SendSetFormation");
	}

	public void SendFormationSetLead(Module_Unit.Unit unit)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new GroupFormationSetLeadMessage
		{
			UnitID = unit.ObjectID
		}, "SendFormationSetLead");
	}

	public void SendFormationSetStation(Module_Unit.Unit unit, Geopoint_Struct station, ReferencePoint.OrientationType bearingType)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new GroupFormationSetStationMessage
		{
			UnitID = unit.ObjectID,
			Latitude = station.Latitude,
			Longitude = station.Longitude,
			BearingType = (short)bearingType
		}, "SendFormationSetStation");
	}

	public void SendFormationSprintDrift(Module_Unit.Unit unit, bool sprintDrift)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new GroupFormationSprintDriftMessage
		{
			UnitID = unit.ObjectID,
			SprintDrift = sprintDrift
		}, "SendFormationSprintDrift");
	}

	public void SendLossesUpdateRequest()
	{
		method_50(new ScoringUpdateMessage
		{
			InformationType = 0
		}, "SendLossesUpdateRequest");
	}

	public void SendScoringUpdateRequest()
	{
		method_50(new ScoringUpdateMessage
		{
			InformationType = 1
		}, "SendScoringUpdateRequest");
	}

	public void ScoringUpdate(ScoringUpdateMessage msg)
	{
		ScoringInfoType informationType = (ScoringInfoType)msg.InformationType;
		if ((uint)informationType <= 1u)
		{
			dispatcher_0.BeginInvoke((Delegate)scoringUpdateDelegate_0, new object[2] { msg.InformationType, msg.Info });
		}
	}

	private void method_26(MessageLogUpdateMessage messageLogUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario != null)
		{
			int count = messageLogUpdateMessage_0.SideID.Count;
			for (int i = 0; i < count; i++)
			{
				clientScenario.AddMessage(messageLogUpdateMessage_0.Texts[i], messageLogUpdateMessage_0.Summarys[i], (LoggedMessage.MessageType)messageLogUpdateMessage_0.Types[i], messageLogUpdateMessage_0.Levels[i], messageLogUpdateMessage_0.ReporterIDs[i], clientScenario.GetSideByID(messageLogUpdateMessage_0.SideID[i]), new Geopoint_Struct
				{
					Latitude = messageLogUpdateMessage_0.Locations[i].Item1,
					Longitude = messageLogUpdateMessage_0.Locations[i].Item2
				}, theForceMapRecentre: false, messageLogUpdateMessage_0.Timestamps[i]);
			}
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				messageLogUpdateDelegate_0();
			}, Array.Empty<object>());
		}
	}

	public void PopulateLastHostMissionStates()
	{
		dictionary_4.Clear();
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		foreach (Mission mission in currentSide.Missions)
		{
			string value = MissionHelper.smethod_1(mission, clientScenario, currentSide);
			if (!string.IsNullOrEmpty(value))
			{
				if (dictionary_4.ContainsKey(mission.ObjectID))
				{
					dictionary_4[mission.ObjectID] = value;
				}
				else
				{
					dictionary_4.Add(mission.ObjectID, value);
				}
			}
		}
	}

	public void PollForLocalMissionStateChange(Mission SelectedMission)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else
		{
			if (SelectedMission == null)
			{
				return;
			}
			lock (object_1)
			{
				if (!dictionary_4.ContainsKey(SelectedMission.ObjectID))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				Scenario clientScenario = ClientScenario;
				if (clientScenario != null)
				{
					Side currentSide = clientScenario.GetCurrentSide();
					string text = MissionHelper.smethod_1(SelectedMission, clientScenario, currentSide);
					if (dictionary_4[SelectedMission.ObjectID] != text)
					{
						method_50(new MissionUpdateMessage
						{
							XML = text,
							OpenMissionEditor = false
						}, "PollForLocalMissionStateChange");
						dictionary_4[SelectedMission.ObjectID] = text;
					}
				}
			}
		}
	}

	public void SendAssignToMission(IEnumerable<ActiveUnit> units, Mission mission, short AssignmentType = 0)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		string missionID = "";
		if (mission != null)
		{
			missionID = mission.ObjectID;
		}
		method_50(new AssignToMissionMessage
		{
			MissionID = missionID,
			ObjectIDs = units.Select((ActiveUnit F) => F.ObjectID).ToList(),
			AssignmentFlags = AssignmentType
		}, "SendAssignToMission");
	}

	public void SendCreateMission(Mission newMission, bool openMissionEditor, string ParentTaskPoolName = "")
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else
		{
			if (newMission == null)
			{
				return;
			}
			Scenario clientScenario = ClientScenario;
			if (clientScenario != null)
			{
				lock (object_1)
				{
					Side currentSide = clientScenario.GetCurrentSide();
					string missionXML = MissionHelper.smethod_1(newMission, clientScenario, currentSide);
					method_50(new MissionCreateMessage
					{
						MissionXML = missionXML,
						OpenMissionEditor = openMissionEditor,
						ParentTaskPoolName = ParentTaskPoolName
					}, "SendCreateMission");
				}
			}
		}
	}

	public void SendRemoveMission(string missionID)
	{
		if (!string.IsNullOrEmpty(missionID))
		{
			method_50(new MissionRemoveMessage
			{
				MissionID = missionID
			}, "SendRemoveMission");
		}
	}

	public void SendCloneMission(string missionID)
	{
		if (!string.IsNullOrEmpty(missionID))
		{
			method_50(new MissionCloneMessage
			{
				MissionToBeClonedID = missionID
			}, "SendCloneMission");
		}
	}

	public void SendSetSecondaryAirBase(Mission mission, ActiveUnit secondaryAirBase)
	{
		if (mission != null)
		{
			string secondaryBaseID = "";
			if (secondaryAirBase != null)
			{
				secondaryBaseID = secondaryAirBase.ObjectID;
			}
			method_50(new MissionSetSecondaryBaseMessage
			{
				MissionID = mission.ObjectID,
				SecondaryBaseID = secondaryBaseID
			}, "SendSetSecondaryAirBase");
		}
	}

	public void UpdateMission(MissionUpdateMessage msg)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		try
		{
			Mission mission_0 = null;
			lock (object_1)
			{
				ActiveDeserializationCount++;
				if (LoopbackMode)
				{
					DisableCommandCoreEventNotifications();
				}
				XmlNode val = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(msg.XML)));
				ConcurrentDictionary<string, ScenarioObject> dict = new ConcurrentDictionary<string, ScenarioObject>();
				Side currentSide = clientScenario.GetCurrentSide();
				string innerText = Command_Core.Misc.GetNodeByName(val.ChildNodes, "ID").InnerText;
				if (currentSide.Missions.Count > 0)
				{
					mission_0 = MissionHelper.FindMissionByID(currentSide.Missions, innerText);
				}
				if (mission_0 != null)
				{
					MissionHelper.smethod_0(mission_0, clientScenario, currentSide, val, dict);
				}
				else
				{
					mission_0 = MissionHelper.CreateNewMissionFromXML(clientScenario, currentSide, val, dict, useGeneratedID: false);
				}
				if (mission_0.Category == Mission.MissionCategory.Package)
				{
					mission_0.get_ParentTaskPoolID(currentSide);
				}
				if (!dictionary_4.ContainsKey(mission_0.ObjectID))
				{
					dictionary_4.Add(mission_0.ObjectID, msg.XML);
				}
				else
				{
					dictionary_4[mission_0.ObjectID] = msg.XML;
				}
			}
			if (mission_0 != null)
			{
				dispatcher_0.BeginInvoke((Delegate)(Action)delegate
				{
					missionUpdateDelegate_0(mission_0.ObjectID, msg.OpenMissionEditor);
				}, Array.Empty<object>());
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		ActiveDeserializationCount--;
		if (LoopbackMode)
		{
			EnableCommandCoreEventNotifications();
		}
	}

	public void RemoveMission(MissionRemoveMessage msg)
	{
		Scenario theScen = ClientScenario;
		if (theScen == null)
		{
			return;
		}
		Side theSide = theScen.GetCurrentSide();
		if (theSide == null || theSide.Missions.Count < 1)
		{
			return;
		}
		Mission mission = MissionHelper.FindMissionByID(theSide.Missions, msg.MissionID);
		if (mission == null)
		{
			return;
		}
		lock (object_1)
		{
			mission.DeleteMission(ref theScen, ref theSide);
			if (dictionary_4.ContainsKey(mission.ObjectID))
			{
				dictionary_4.Remove(mission.ObjectID);
			}
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			missionUpdateDelegate_0("", openEditorWindow: false);
		}, Array.Empty<object>());
	}

	public void OnMissionSelected(Mission selectedMission)
	{
		if (selectedMission != null && !dictionary_4.ContainsKey(selectedMission.ObjectID))
		{
			Scenario clientScenario = ClientScenario;
			if (clientScenario != null)
			{
				Side currentSide = clientScenario.GetCurrentSide();
				string value = MissionHelper.smethod_1(selectedMission, clientScenario, currentSide);
				dictionary_4.Add(selectedMission.ObjectID, value);
			}
		}
	}

	private void method_27(int int_6, DateTime dateTime_6, List<string> list_5, List<float> list_6, List<double> list_7, List<double> list_8, List<float> list_9)
	{
		IntermediatePositionUpdateMessage intermediatePositionUpdateMessage = method_53(int_6, dateTime_6);
		if (intermediatePositionUpdateMessage != null)
		{
			lock (intermediatePositionUpdateMessage)
			{
				intermediatePositionUpdateMessage.ObjectID.AddRange(list_5);
				intermediatePositionUpdateMessage.Heading.AddRange(list_6);
				intermediatePositionUpdateMessage.Latitude.AddRange(list_7);
				intermediatePositionUpdateMessage.Longitude.AddRange(list_8);
				intermediatePositionUpdateMessage.Altitude.AddRange(list_9);
			}
			if (InterpolateUnitPositions && LastGameSpeed > 0)
			{
				method_54(intermediatePositionUpdateMessage);
			}
			return;
		}
		intermediatePositionUpdateMessage = new IntermediatePositionUpdateMessage();
		intermediatePositionUpdateMessage.SimTimeSent = dateTime_6;
		intermediatePositionUpdateMessage.ObjectType = int_6;
		intermediatePositionUpdateMessage.ObjectID = list_5;
		intermediatePositionUpdateMessage.Heading = list_6;
		intermediatePositionUpdateMessage.Latitude = list_7;
		intermediatePositionUpdateMessage.Longitude = list_8;
		intermediatePositionUpdateMessage.Altitude = list_9;
		if (InterpolateUnitPositions && LastGameSpeed > 0)
		{
			method_54(intermediatePositionUpdateMessage);
		}
		tlist_0.Add(intermediatePositionUpdateMessage);
	}

	private void method_28(PositionUpdateMessage positionUpdateMessage_0)
	{
		int count = positionUpdateMessage_0.ObjectID.Count;
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		bool flag;
		int num;
		if (!(flag = LastGameSpeed > 0))
		{
			num = 0;
		}
		else
		{
			method_27(0, positionUpdateMessage_0.SimTimeSent, positionUpdateMessage_0.ObjectID, positionUpdateMessage_0.Heading, positionUpdateMessage_0.Latitude, positionUpdateMessage_0.Longitude, positionUpdateMessage_0.Altitude);
			num = 0;
		}
		for (int i = num; i < count; i++)
		{
			if (!clientScenario.ActiveUnits.ContainsKey(positionUpdateMessage_0.ObjectID[i]))
			{
				continue;
			}
			ActiveUnit activeUnit = clientScenario.ActiveUnits[positionUpdateMessage_0.ObjectID[i]];
			if (!flag)
			{
				activeUnit.CurrentHeading = positionUpdateMessage_0.Heading[i];
				((Module_Unit.Unit)activeUnit).set_Latitude((GlobalVariables.BooleanObject)null, positionUpdateMessage_0.Latitude[i]);
				((Module_Unit.Unit)activeUnit).set_Longitude((GlobalVariables.BooleanObject)null, positionUpdateMessage_0.Longitude[i]);
				((Module_Unit.Unit)activeUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, positionUpdateMessage_0.Altitude[i]);
			}
			if (positionUpdateMessage_0.Speed != null)
			{
				activeUnit.CurrentSpeed = positionUpdateMessage_0.Speed[i];
			}
			if (positionUpdateMessage_0.Condition != null)
			{
				if (activeUnit.IsAircraft)
				{
					((Aircraft)activeUnit).AirOps.Condition = (Aircraft_AirOps._AirOpsCondition)positionUpdateMessage_0.Condition[i];
				}
				else
				{
					activeUnit.DockingOps.Condition = (ActiveUnit_DockingOps._DockingOpsCondition)positionUpdateMessage_0.Condition[i];
				}
			}
		}
	}

	private void vnyLliHlZyO(IntermediatePositionUpdateMessage intermediatePositionUpdateMessage_0)
	{
		method_27(intermediatePositionUpdateMessage_0.ObjectType, intermediatePositionUpdateMessage_0.SimTimeSent, intermediatePositionUpdateMessage_0.ObjectID, intermediatePositionUpdateMessage_0.Heading, intermediatePositionUpdateMessage_0.Latitude, intermediatePositionUpdateMessage_0.Longitude, intermediatePositionUpdateMessage_0.Altitude);
	}

	private void method_29(IntermediatePositionUpdateMessage intermediatePositionUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		int num = 0;
		lock (intermediatePositionUpdateMessage_0)
		{
			num = intermediatePositionUpdateMessage_0.ObjectID.Count;
		}
		for (int i = 0; i < num; i++)
		{
			if (clientScenario.ActiveUnits.ContainsKey(intermediatePositionUpdateMessage_0.ObjectID[i]))
			{
				ActiveUnit activeUnit = clientScenario.ActiveUnits[intermediatePositionUpdateMessage_0.ObjectID[i]];
				if (activeUnit != null)
				{
					activeUnit.CurrentHeading = intermediatePositionUpdateMessage_0.Heading[i];
					((Module_Unit.Unit)activeUnit).set_Latitude((GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Latitude[i]);
					((Module_Unit.Unit)activeUnit).set_Longitude((GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Longitude[i]);
					((Module_Unit.Unit)activeUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, intermediatePositionUpdateMessage_0.Altitude[i]);
				}
			}
		}
	}

	public void SendTeleportUnit(Module_Unit.Unit unit, double Lat, double Lon)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new TeleportUnitMessage
		{
			Latitude = Lat,
			Longitude = Lon,
			ObjectID = unit.ObjectID
		}, "SendTeleportUnit");
	}

	private void ReferencePointUpdate(ReferencePointUpdateMessage msg)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		int count = msg.SideID.Count;
		string text = "";
		ActiveUnit value = null;
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide != null)
		{
			text = currentSide.ObjectID;
		}
		string value2 = ClientName + "-";
		int int_0 = 0;
		while (int_0 < count)
		{
			Side sideByID = clientScenario.GetSideByID(msg.SideID[int_0]);
			int num2;
			if (sideByID != null)
			{
				bool flag = msg.SideID[int_0] == text;
				int count2 = msg.AllObjectID[int_0].Count;
				for (int int_1 = 0; int_1 < count2; num2 = int_1 + 1, int_1 = num2)
				{
					if (flag)
					{
						if (uint_2 != 0 && list_1.Contains(msg.AllObjectID[int_0][int_1]))
						{
							continue;
						}
						if (list_2.Count > 0)
						{
							bool flag2 = false;
							foreach (ReferencePoint item in list_2)
							{
								if (item.ObjectID == msg.AllObjectID[int_0][int_1])
								{
									flag2 = true;
									break;
								}
							}
							if (flag2)
							{
								continue;
							}
						}
					}
					ReferencePoint referencePoint_0 = sideByID.RefPoints.FirstOrDefault((ReferencePoint F) => F.ObjectID == msg.AllObjectID[int_0][int_1]);
					bool flag3 = false;
					bool flag4 = false;
					if (referencePoint_0 == null)
					{
						referencePoint_0 = new ReferencePoint(AssignObjectID: false);
						referencePoint_0.ObjectID = msg.AllObjectID[int_0][int_1];
						sideByID.RefPoints.Add(referencePoint_0);
						flag3 = true;
					}
					referencePoint_0.Name = msg.AllName[int_0][int_1];
					referencePoint_0.Latitude = msg.AllLatitude[int_0][int_1];
					referencePoint_0.Longitude = msg.AllLongitude[int_0][int_1];
					if (flag && flag3 && referencePoint_0.Name.StartsWith(value2))
					{
						referencePoint_0.IsHighlighted = true;
						flag4 = true;
					}
					if (!string.IsNullOrEmpty(msg.AllRelativeUnitID[int_0][int_1]))
					{
						if (clientScenario.ActiveUnits.TryGetValue(msg.AllRelativeUnitID[int_0][int_1], out value))
						{
							referencePoint_0.IsRelativeTo = value;
						}
					}
					else
					{
						referencePoint_0.IsRelativeTo = null;
					}
					referencePoint_0.RelativeBearing = msg.AllRelativeBearing[int_0][int_1];
					referencePoint_0.RelativeDistance = msg.AllRelativeDistance[int_0][int_1];
					referencePoint_0.BearingType = (ReferencePoint.OrientationType)msg.AllBearingType[int_0][int_1];
					referencePoint_0.color = Color.FromArgb(msg.AllColor[int_0][int_1]);
					referencePoint_0.RenderGroup = (ReferencePoint_Group)msg.AllRenderGroup[int_0][int_1];
					long? num = msg.AllCreationDate[int_0][int_1];
					if (num.HasValue)
					{
						referencePoint_0.CreationDate = new DateTime(num.Value);
					}
					num = msg.AllExpiration[int_0][int_1];
					if (num.HasValue)
					{
						referencePoint_0.Expiration = new DateTime(num.Value);
					}
					referencePoint_0.Fades = msg.AllFades[int_0][int_1];
					referencePoint_0.ForceMinimize = msg.AllForceMinimize[int_0][int_1];
					if (flag4)
					{
						dispatcher_0.BeginInvoke((Delegate)(Action)delegate
						{
							smartRPUpdateDelegate_0(referencePoint_0);
						}, Array.Empty<object>());
					}
				}
			}
			num2 = int_0 + 1;
			int_0 = num2;
		}
	}

	public void SetLocalReferencePointHighlightState(Side side, ReferencePoint rp, bool highLight)
	{
		if (rp != null && rp.IsHighlighted != highLight)
		{
			rp.IsHighlighted = highLight;
			SendReferencePointUpdate(side, rp);
		}
	}

	public void IsDraggingReferencePoints(bool isDragging, Side side, List<ReferencePoint> rps)
	{
		if (!isDragging)
		{
			if (list_2.Count > 0)
			{
				SendMultipleReferencePointUpdate(side, list_2);
				list_2.Clear();
			}
		}
		else if (rps != null && rps.Count > 0)
		{
			list_2 = rps.ToList();
		}
	}

	public uint SendMultipleReferencePointUpdate(Side side, List<ReferencePoint> rps)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		if (side != null && rps != null)
		{
			int count = rps.Count;
			List<string> sideID = new List<string>(1) { side.ObjectID };
			List<List<string>> list = new List<List<string>>(1)
			{
				new List<string>(count)
			};
			List<List<double>> list2 = new List<List<double>>(1)
			{
				new List<double>(count)
			};
			List<List<double>> list3 = new List<List<double>>(1)
			{
				new List<double>(count)
			};
			List<List<string>> list4 = new List<List<string>>(1)
			{
				new List<string>(count)
			};
			List<List<bool>> list5 = new List<List<bool>>(1)
			{
				new List<bool>(count)
			};
			List<List<string>> list6 = new List<List<string>>(1)
			{
				new List<string>(count)
			};
			List<List<float>> list7 = new List<List<float>>(1)
			{
				new List<float>(count)
			};
			List<List<float>> list8 = new List<List<float>>(1)
			{
				new List<float>(count)
			};
			List<List<byte>> list9 = new List<List<byte>>(1)
			{
				new List<byte>(count)
			};
			List<List<bool>> list10 = new List<List<bool>>(1)
			{
				new List<bool>(count)
			};
			List<List<List<string>>> list11 = new List<List<List<string>>>(1)
			{
				new List<List<string>>(count)
				{
					new List<string>()
				}
			};
			List<List<int>> list12 = new List<List<int>>(1)
			{
				new List<int>(count)
			};
			List<List<int>> list13 = new List<List<int>>(1)
			{
				new List<int>(count)
			};
			List<List<long?>> list14 = new List<List<long?>>(1)
			{
				new List<long?>(count)
			};
			List<List<long?>> list15 = new List<List<long?>>(1)
			{
				new List<long?>(count)
			};
			List<List<bool>> list16 = new List<List<bool>>(1)
			{
				new List<bool>(count)
			};
			List<List<bool>> list17 = new List<List<bool>>(1)
			{
				new List<bool>(count)
			};
			foreach (ReferencePoint rp in rps)
			{
				if (rp != null)
				{
					list[0].Add(rp.ObjectID);
					list2[0].Add(rp.Latitude);
					list3[0].Add(rp.Longitude);
					list4[0].Add(rp.Name);
					list5[0].Add(rp.IsHighlighted);
					if (rp.IsRelativeTo == null)
					{
						list6[0].Add("");
					}
					else
					{
						list6[0].Add(rp.IsRelativeTo.ObjectID);
					}
					list7[0].Add(rp.RelativeBearing);
					list8[0].Add(rp.RelativeDistance);
					list9[0].Add((byte)rp.BearingType);
					list10[0].Add(rp.IsLocked);
					list11[0].Add(rp.TagsByGuid_Raw.ToList());
					list12[0].Add(rp.color.ToArgb());
					list13[0].Add((int)rp.RenderGroup);
					list14[0].Add(GetNullableDateTick(rp.CreationDate));
					list15[0].Add(GetNullableDateTick(rp.Expiration));
					list16[0].Add(rp.Fades);
					list17[0].Add(rp.ForceMinimize);
				}
			}
			uint_2 = GetNextUIEventID();
			list_1 = list[0].ToList();
			method_50(new ReferencePointUpdateMessage
			{
				ClientUIEventID = uint_2,
				AllObjectID = list,
				AllLatitude = list2,
				AllLongitude = list3,
				AllName = list4,
				SideID = sideID,
				AllIsHighlighted = list5,
				AllRelativeUnitID = list6,
				AllRelativeBearing = list7,
				AllRelativeDistance = list8,
				AllBearingType = list9,
				AllIsLocked = list10,
				AllTagsByGuid_Raw = list11,
				AllColor = list12,
				AllRenderGroup = list13,
				AllCreationDate = list14,
				AllExpiration = list15,
				AllFades = list16,
				AllForceMinimize = list17
			}, "SendMultipleReferencePointUpdate");
			return uint_2;
		}
		return 0u;
	}

	public uint SendReferencePointUpdate(Side side, ReferencePoint rp)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		int result;
		if (side == null)
		{
			result = 0;
		}
		else
		{
			if (rp != null)
			{
				List<List<string>> list = new List<List<string>>(1)
				{
					new List<string>(1) { "" }
				};
				if (rp.IsRelativeTo != null)
				{
					list[0][0] = rp.IsRelativeTo.ObjectID;
				}
				uint_2 = GetNextUIEventID();
				list_1.Clear();
				list_1.Add(rp.ObjectID);
				method_50(new ReferencePointUpdateMessage
				{
					ClientUIEventID = uint_2,
					AllObjectID = new List<List<string>>(1)
					{
						new List<string>(1) { rp.ObjectID }
					},
					AllLatitude = new List<List<double>>(1)
					{
						new List<double>(1) { rp.Latitude }
					},
					AllLongitude = new List<List<double>>(1)
					{
						new List<double>(1) { rp.Longitude }
					},
					AllName = new List<List<string>>(1)
					{
						new List<string>(1) { rp.Name }
					},
					SideID = new List<string>(1) { side.ObjectID },
					AllIsHighlighted = new List<List<bool>>(1)
					{
						new List<bool>(1) { rp.IsHighlighted }
					},
					AllRelativeUnitID = list,
					AllRelativeBearing = new List<List<float>>(1)
					{
						new List<float>(1) { rp.RelativeBearing }
					},
					AllRelativeDistance = new List<List<float>>(1)
					{
						new List<float>(1) { rp.RelativeDistance }
					},
					AllBearingType = new List<List<byte>>(1)
					{
						new List<byte>(1) { (byte)rp.BearingType }
					},
					AllIsLocked = new List<List<bool>>(1)
					{
						new List<bool>(1) { rp.IsLocked }
					},
					AllTagsByGuid_Raw = new List<List<List<string>>>(1)
					{
						new List<List<string>>(1) { rp.TagsByGuid_Raw.ToList() }
					},
					AllColor = new List<List<int>>(1)
					{
						new List<int>(1) { rp.color.ToArgb() }
					},
					AllRenderGroup = new List<List<int>>(1)
					{
						new List<int>(1) { (int)rp.RenderGroup }
					},
					AllCreationDate = new List<List<long?>>(1)
					{
						new List<long?>(1) { GetNullableDateTick(rp.CreationDate) }
					},
					AllExpiration = new List<List<long?>>(1)
					{
						new List<long?>(1) { GetNullableDateTick(rp.Expiration) }
					},
					AllFades = new List<List<bool>>(1)
					{
						new List<bool>(1) { rp.Fades }
					},
					AllForceMinimize = new List<List<bool>>(1)
					{
						new List<bool>(1) { rp.ForceMinimize }
					}
				}, "SendReferencePointUpdate");
				return uint_2;
			}
			result = 0;
		}
		return (uint)result;
	}

	public static long? GetNullableDateTick(DateTime? time)
	{
		if (time.HasValue)
		{
			return time.Value.Ticks;
		}
		return null;
	}

	public void SendCreateReferencePoint(double Lat, double Lon, Side side)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new CreateReferencePointMessage
		{
			Lat = Lat,
			Lon = Lon,
			SideID = side.ObjectID
		}, "SendCreateReferencePoint");
	}

	public void SendCreateMultipleReferencePoints(List<ReferencePoint> rps, Side side)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		foreach (ReferencePoint rp in rps)
		{
			list.Add(rp.Latitude);
			list2.Add(rp.Longitude);
		}
		method_50(new CreateMultipleReferencePointMessage
		{
			Lats = list,
			Lons = list2,
			SideID = side.ObjectID
		}, "SendCreateMultipleReferencePoint");
	}

	public void SendDeleteReferencePoint(Side side, ReferencePoint rp)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new DeleteReferencePointMessage
		{
			SideID = side.ObjectID,
			RPIDs = new List<string>(1) { rp.ObjectID }
		}, "SendDeleteReferencePoint");
	}

	private void DeleteReferencePoint(DeleteReferencePointMessage msg)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null || currentSide.ObjectID != msg.SideID)
		{
			return;
		}
		for (int i = 0; i < msg.RPIDs.Count; i++)
		{
			int num = currentSide.RefPoints.Count - 1;
			while (num >= 0)
			{
				if (!(currentSide.RefPoints[num].ObjectID == msg.RPIDs[i]))
				{
					num--;
					continue;
				}
				currentSide.RefPoints.RemoveAt(num);
				break;
			}
		}
	}

	public void SendActiveUnitResupplyActionMessage(IEnumerable<Module_Unit.Unit> units, ActiveUnitResupplyAction action, string targetID, int dbid = 0)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new ActiveUnitResupplyActionMessage
		{
			ObjectIDs = units.Select((Module_Unit.Unit F) => F.ObjectID).ToList(),
			Action = (byte)action,
			TargetID = targetID,
			WeaponID = dbid
		}, "SendActiveUnitResupplyActionMessage");
	}

	public uint SendSensorEMCONUpdate(Module_Unit.Unit unit, bool bool_10, SensorEMCONUpdateMessage.EMCON_Inherit_Change ChangeInheritance = SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_NOCHANGE)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		if (unit != null)
		{
			uint nextUIEventID = GetNextUIEventID();
			method_50(new SensorEMCONUpdateMessage
			{
				ClientUIEventID = nextUIEventID,
				unitID = unit.ObjectID,
				obeyEMCON = bool_10,
				changeEMCONInheritance = (int)ChangeInheritance
			}, "SendSensorEMCONUpdate");
			if (nextUIEventID != 0)
			{
				uint_3 = nextUIEventID;
				list_3.Clear();
				list_3.Add(unit.ObjectID);
			}
			return nextUIEventID;
		}
		return 0u;
	}

	public uint SendMultipleSensorEMCONUpdate(List<Module_Unit.Unit> UnitList, bool bool_10, SensorEMCONUpdateMessage.EMCON_Inherit_Change ChangeInheritance = SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_NOCHANGE)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		if (UnitList == null)
		{
			return 0u;
		}
		List<string> list = new List<string>();
		uint nextUIEventID = GetNextUIEventID();
		int count = UnitList.Count;
		for (int i = 0; i < count; i++)
		{
			Module_Unit.Unit unit = UnitList[i];
			uint clientUIEventID = 0u;
			list.Add(unit.ObjectID);
			if (i == count - 1)
			{
				clientUIEventID = nextUIEventID;
			}
			method_50(new SensorEMCONUpdateMessage
			{
				ClientUIEventID = clientUIEventID,
				unitID = unit.ObjectID,
				obeyEMCON = bool_10,
				changeEMCONInheritance = (int)ChangeInheritance
			}, "SendSensorEMCONUpdate");
		}
		if (nextUIEventID != 0)
		{
			uint_3 = nextUIEventID;
			list_3 = list;
		}
		return nextUIEventID;
	}

	public uint SendSensorActivation(Module_Unit.Unit unit, Sensor sensor, bool activate)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		int result;
		if (unit == null)
		{
			result = 0;
		}
		else
		{
			if (sensor != null)
			{
				List<SensorUpdateMessage.SensorUpdateRecord> list = new List<SensorUpdateMessage.SensorUpdateRecord>();
				SensorUpdateMessage.SensorUpdateRecord item = default(SensorUpdateMessage.SensorUpdateRecord);
				item.unitID = unit.ObjectID;
				item.sensorID = sensor.ObjectID;
				item.activated = activate;
				if (!sensor.IsSensorInLoadout)
				{
					item.poddedSensorDBID = 0;
				}
				else
				{
					item.poddedSensorDBID = sensor.DBID;
				}
				list.Add(item);
				uint nextUIEventID = GetNextUIEventID();
				method_50(new SensorUpdateMessage
				{
					ClientUIEventID = nextUIEventID,
					SensorUpdates = list
				}, "SendSensorActivation");
				if (nextUIEventID != 0)
				{
					uint_3 = nextUIEventID;
					list_3.Clear();
					list_3.Add(unit.ObjectID);
				}
				return nextUIEventID;
			}
			result = 0;
		}
		return (uint)result;
	}

	public uint SendSensorActivation(Module_Unit.Unit unit, List<Sensor> sensorList, bool activate)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		if (unit != null && sensorList != null)
		{
			List<SensorUpdateMessage.SensorUpdateRecord> list = new List<SensorUpdateMessage.SensorUpdateRecord>();
			SensorUpdateMessage.SensorUpdateRecord item = default(SensorUpdateMessage.SensorUpdateRecord);
			foreach (Sensor sensor in sensorList)
			{
				item.unitID = unit.ObjectID;
				item.sensorID = sensor.ObjectID;
				item.activated = activate;
				if (!sensor.IsSensorInLoadout)
				{
					item.poddedSensorDBID = 0;
				}
				else
				{
					item.poddedSensorDBID = sensor.DBID;
				}
				list.Add(item);
			}
			uint nextUIEventID = GetNextUIEventID();
			method_50(new SensorUpdateMessage
			{
				ClientUIEventID = nextUIEventID,
				SensorUpdates = list
			}, "SendSensorActivation");
			if (nextUIEventID != 0)
			{
				uint_3 = nextUIEventID;
				list_3.Clear();
				list_3.Add(unit.ObjectID);
			}
			return nextUIEventID;
		}
		return 0u;
	}

	public uint SendMultipleSensorActivation(List<Sensor> sensorList, bool activate)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return 0u;
		}
		if (sensorList == null)
		{
			return 0u;
		}
		List<SensorUpdateMessage.SensorUpdateRecord> list = new List<SensorUpdateMessage.SensorUpdateRecord>();
		List<string> list2 = new List<string>();
		SensorUpdateMessage.SensorUpdateRecord item = default(SensorUpdateMessage.SensorUpdateRecord);
		foreach (Sensor sensor in sensorList)
		{
			if (sensor != null && sensor.ParentPlatform != null)
			{
				item.unitID = sensor.ParentPlatform.ObjectID;
				list2.Add(item.unitID);
				item.sensorID = sensor.ObjectID;
				item.activated = activate;
				if (sensor.IsSensorInLoadout)
				{
					item.poddedSensorDBID = sensor.DBID;
				}
				else
				{
					item.poddedSensorDBID = 0;
				}
				list.Add(item);
			}
		}
		uint nextUIEventID = GetNextUIEventID();
		method_50(new SensorUpdateMessage
		{
			ClientUIEventID = nextUIEventID,
			SensorUpdates = list
		}, "SendSensorActivation");
		if (nextUIEventID != 0)
		{
			uint_3 = nextUIEventID;
			list_3 = list2;
		}
		return nextUIEventID;
	}

	public void SensorUpdate(SensorUpdateMessage msg)
	{
		ActiveUnit value = null;
		Scenario clientScenario = ClientScenario;
		bool flag = false;
		if (clientScenario == null)
		{
			return;
		}
		foreach (SensorUpdateMessage.SensorUpdateRecord sensorUpdate in msg.SensorUpdates)
		{
			if (value == null || value.ObjectID != sensorUpdate.unitID)
			{
				clientScenario.ActiveUnits.TryGetValue(sensorUpdate.unitID, out value);
			}
			if (value == null)
			{
				continue;
			}
			if (!flag && ((Module_Unit.Unit)value).get_UnitSide(SetSideOnly: false) == clientScenario.GetCurrentSide())
			{
				flag = true;
			}
			List<Sensor> list = new List<Sensor>();
			list.AddRange(value.Sensors_Cached);
			list.AddRange(value.MineCountermeasures);
			foreach (Sensor item in list)
			{
				if (sensorUpdate.sensorID == item.ObjectID || (sensorUpdate.poddedSensorDBID != 0 && item.IsSensorInLoadout && sensorUpdate.poddedSensorDBID == item.DBID))
				{
					if (!sensorUpdate.activated)
					{
						item.GoPassive();
					}
					else
					{
						item.GoActive();
					}
					break;
				}
			}
		}
		if (flag)
		{
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				sensorsUpdateDelegate_0();
			}, Array.Empty<object>());
		}
	}

	public uint SendIntermittentEmissionUpdate(ActiveUnit au)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		if (au == null)
		{
			return 0u;
		}
		string xML = "";
		ActiveEmissionInterval intermittentEmission = au.Sensory.GetIntermittentEmission();
		if (intermittentEmission != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			intermittentEmission.ToXML(ref theWriter);
			theWriter.Flush();
			xML = stringBuilder.ToString();
		}
		uint nextUIEventID = GetNextUIEventID();
		method_50(new SensorIntermittentEmissionUpdateMessage
		{
			ClientUIEventID = nextUIEventID,
			unitID = au.ObjectID,
			XML = xML
		}, "SendIntermittentEmissionUpdate");
		if (nextUIEventID != 0)
		{
			uint_3 = nextUIEventID;
			list_3.Clear();
			list_3.Add(au.ObjectID);
		}
		return nextUIEventID;
	}

	public void IntermittentEmissionUpdate(SensorIntermittentEmissionUpdateMessage msg)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null || string.IsNullOrEmpty(msg.unitID))
		{
			return;
		}
		ActiveUnit activeUnit_0 = null;
		if (clientScenario.ActiveUnits.TryGetValue(msg.unitID, out activeUnit_0))
		{
			if (!string.IsNullOrEmpty(msg.XML))
			{
				XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(msg.XML)));
				activeUnit_0.Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode);
				activeUnit_0.Sensory.IntermittentEmission?.Initialize(activeUnit_0.Sensory);
			}
			else
			{
				activeUnit_0.Sensory.IntermittentEmission = null;
			}
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			doctrineUpdateDelegate_0(activeUnit_0.Doctrine);
		}, Array.Empty<object>());
	}

	private void method_30(SidePosturesUpdateMessage sidePosturesUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (!(sidePosturesUpdateMessage_0.SideID == currentSide.ObjectID))
		{
			return;
		}
		foreach (KeyValuePair<string, int> posture in sidePosturesUpdateMessage_0.Postures)
		{
			if (posture.Key == currentSide.ObjectID)
			{
				continue;
			}
			Side[] sides_ReadOnly = clientScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side.ObjectID == posture.Key)
				{
					currentSide.set_ConsidersThisSideToBe(side, (Scenario)null, (Command_Core.Misc.PostureStance)posture.Value);
					break;
				}
			}
		}
	}

	public void SendSidePostureUpdate()
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null)
		{
			return;
		}
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		foreach (KeyValuePair<Side, Command_Core.Misc.PostureStance> item in currentSide.Postures_ReadOnly.ToList())
		{
			list.Add(new KeyValuePair<string, int>(item.Key.ObjectID, (int)item.Value));
		}
		method_50(new SidePosturesUpdateMessage
		{
			SideID = currentSide.ObjectID,
			Postures = list
		}, "SendSidePostureUpdate");
	}

	private void method_31(SideUpdateMessage sideUpdateMessage_0)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Scenario theScen = ClientScenario;
		if (theScen == null)
		{
			return;
		}
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(sideUpdateMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		Side side = null;
		string innerText = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side2 in sides_ReadOnly)
		{
			if (side2.ObjectID == innerText)
			{
				side = side2;
				break;
			}
		}
		if (side != null)
		{
			Side.FromXML(ref theNode, ref theScen, ref theDictionary, side);
		}
	}

	private void method_32(SideAlertnessUpdateMessage sideAlertnessUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario != null)
		{
			Side currentSide = clientScenario.GetCurrentSide();
			if (currentSide != null && sideAlertnessUpdateMessage_0.SideID == currentSide.ObjectID)
			{
				currentSide.EmconAlertness.Level = (Alertlevels)sideAlertnessUpdateMessage_0.AlertnessLevel;
			}
		}
	}

	public void SendSideAlertnessUpdate(Side side)
	{
		if (side != null)
		{
			method_50(new SideAlertnessUpdateMessage
			{
				SideID = side.ObjectID,
				AlertnessLevel = (int)side.EmconAlertness.Level
			}, "SendSideAlertnessUpdate");
		}
	}

	public void SendSideMapPing(double lat, double lon)
	{
		method_50(new SideMapPingMessage
		{
			Latitude = lat,
			Longitude = lon
		}, "SendSideMapPing");
	}

	public void SideMapPing(SideMapPingMessage msg)
	{
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			sideMapPingDelegate_0(msg.SourceName, msg.Latitude, msg.Longitude, msg.Flags);
		}, Array.Empty<object>());
	}

	public void SendSpecialActionExecute(string ActionID, Side side)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		List<string> list = new List<string>();
		if (side != null)
		{
			ReadOnlyCollection<Module_Unit.Unit> selectedUnits = side.SelectedUnits;
			if (selectedUnits != null)
			{
				foreach (Module_Unit.Unit item in selectedUnits)
				{
					list.Add(item.ObjectID);
				}
			}
		}
		method_50(new SpecialActionMessage
		{
			ActionID = ActionID,
			SelectedUnitIDs = list
		}, "SendSpecialActionExecute");
	}

	public void SpecialActionResult(SpecialActionMessage msg)
	{
		dispatcher_0.BeginInvoke((Delegate)specialActionUpdateDelegate_0, new object[2] { msg.ActionID, msg.Result });
	}

	public void SendThrottleAltUI(string ActiveUnitID, string WaypointID, string FlightID = "", float? DesiredSpeed = null, byte? DesiredThrottlePreset = null, byte? DesiredAltitudePreset = null, byte? DesiredDepthPreset = null, float? DesiredAltitude = null, float? DesiredDepth = null, bool? SprintDrift = null, bool? AvoidCavitation = null, bool? SpeedOverride = null, bool? AltitudeOverride = null, bool? TerrainFollowing = null, byte? LandcoverMasking = null, bool? ClearSpeedSettings = null, bool? ClearAltitudeSettings = null)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new ThrottleAltUIMessage
		{
			ActiveUnitID = ActiveUnitID,
			WaypointID = WaypointID,
			FlightID = FlightID,
			DesiredSpeed = DesiredSpeed,
			DesiredThrottlePreset = DesiredThrottlePreset,
			DesiredAltitude = DesiredAltitude,
			DesiredDepth = DesiredDepth,
			DesiredAltitudePreset = DesiredAltitudePreset,
			DesiredDepthPreset = DesiredDepthPreset,
			SprintDrift = SprintDrift,
			AvoidCavitation = AvoidCavitation,
			SpeedOverride = SpeedOverride,
			AltitudeOverride = AltitudeOverride,
			TerrainFollowing = TerrainFollowing,
			LandcoverMasking = LandcoverMasking,
			ClearSpeedSettings = ClearSpeedSettings,
			ClearAltitudeSettings = ClearAltitudeSettings
		}, "SendThrottleAltUI");
	}

	private void method_33(NewUnguidedWeaponMessage newUnguidedWeaponMessage_0)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		lock (TerminalRenderLockObj)
		{
			Scenario theScen = ClientScenario;
			Side currentSide = theScen.GetCurrentSide();
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newUnguidedWeaponMessage_0.XML)));
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				theDictionary.TryAdd(side.Name, side);
			}
			string text = "";
			XmlNode nodeByName = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "Target");
			if (nodeByName != null)
			{
				text = nodeByName.InnerText;
			}
			if (!string.IsNullOrEmpty(text))
			{
				foreach (Contact contacts_ in currentSide.Contacts_List)
				{
					if (contacts_.ObjectID.Equals(text))
					{
						theDictionary.TryAdd(text, contacts_);
						break;
					}
				}
			}
			UnguidedWeapon unguidedWeapon = UnguidedWeapon.FromXML(ref theNode, ref theDictionary, ref theScen);
			unguidedWeapon.PostDeserializationHousekeeping(ref theScen);
			if (unguidedWeapon.Target == null && !unguidedWeapon.IsMine)
			{
				return;
			}
			if (!theScen.UnguidedWeapons.ContainsKey(unguidedWeapon.ObjectID))
			{
				theScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon.ObjectID, unguidedWeapon);
			}
			else
			{
				theScen.UnguidedWeapons[unguidedWeapon.ObjectID] = unguidedWeapon;
			}
			foreach (string objectID in newUnguidedWeaponMessage_0.ObjectIDs)
			{
				Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText = objectID;
				unguidedWeapon = UnguidedWeapon.FromXML(ref theNode, ref theDictionary, ref theScen);
				unguidedWeapon.PostDeserializationHousekeeping(ref theScen);
				theScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon.ObjectID, unguidedWeapon);
			}
		}
	}

	private void method_34(RemoveUnguidedWeaponsMessage removeUnguidedWeaponsMessage_0)
	{
		lock (TerminalRenderLockObj)
		{
			Scenario clientScenario = ClientScenario;
			UnguidedWeapon value = null;
			foreach (string objectID in removeUnguidedWeaponsMessage_0.ObjectIDs)
			{
				clientScenario.UnguidedWeapons.TryRemove(objectID, out value);
			}
		}
	}

	private void method_35(NewWaterSplashMessage newWaterSplashMessage_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Scenario clientScenario = ClientScenario;
		XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newWaterSplashMessage_0.XML)));
		ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
		WaterSplash item = WaterSplash.FromXML(ref theNode, ref theDictionary);
		clientScenario.WaterSplashes.Add(item);
	}

	private void method_36(WaypointUpdateMessage waypointUpdateMessage_0)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		lock (TerminalRenderLockObj)
		{
			Scenario theScen = ClientScenario;
			if (theScen == null)
			{
				return;
			}
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(waypointUpdateMessage_0.XML)));
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			ActiveUnit value = null;
			Waypoint waypoint_0 = null;
			bool flag = false;
			string innerText = Command_Core.Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if ((uint_1 != 0 && list_0.Contains(innerText)) || !theScen.ActiveUnits.TryGetValue(waypointUpdateMessage_0.UnitID, out value))
			{
				return;
			}
			Waypoint[] plottedCourse = value.Navigator.PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				if (waypoint.ObjectID == innerText)
				{
					waypoint_0 = waypoint;
					break;
				}
			}
			if (waypoint_0 == null && value.Navigator.HasFlightPlan)
			{
				plottedCourse = value.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
				foreach (Waypoint waypoint2 in plottedCourse)
				{
					if (waypoint2.ObjectID == innerText)
					{
						waypoint_0 = waypoint2;
						flag = true;
						break;
					}
				}
			}
			if (waypoint_0 == null)
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			double double_0 = 0.0;
			double double_1 = 0.0;
			int num3;
			if (!string.IsNullOrEmpty(string_1))
			{
				num3 = ((string_1 == innerText) ? 1 : 0);
				if (num3 != 0)
				{
					num = waypoint_0.Latitude;
					num2 = waypoint_0.Longitude;
				}
			}
			else
			{
				num3 = 0;
			}
			Waypoint.FromXML(ref theNode, ref theDictionary, theScen, waypoint_0);
			waypoint_0.PostDeserializationHousekeeping(ref theScen, ((Module_Unit.Unit)value).get_UnitSide(SetSideOnly: false), GameIsRunning: true);
			if (num3 == 0)
			{
				return;
			}
			bool num4 = waypoint_0.Latitude != num || waypoint_0.Longitude != num2;
			double_0 = waypoint_0.Latitude;
			double_1 = waypoint_0.Longitude;
			waypoint_0.Latitude = num;
			waypoint_0.Longitude = num2;
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				selectedWaypointUpdateDelegate_0(waypoint_0, double_0, double_1);
			}, Array.Empty<object>());
			if (num4 && flag)
			{
				dispatcher_0.BeginInvoke((Delegate)(Action)delegate
				{
					missionEditorEventDelegate_0(1);
				}, Array.Empty<object>());
			}
		}
	}

	public void SendWaypointUpdate(Module_Unit.Unit unit, Waypoint waypoint)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (waypoint != null)
		{
			string unitID = "";
			if (unit != null)
			{
				unitID = unit.ObjectID;
			}
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			XmlWriter theWriter = (XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(stringBuilder));
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			waypoint.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.Flush();
			string xML = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			method_50(new WaypointUpdateMessage
			{
				UnitID = unitID,
				XML = xML
			}, "SendWaypointUpdate");
		}
	}

	private void SendWaypointSensorChange(Module_Unit.Unit unit, Waypoint waypoint, WaypointSensorMessage.SensorType sensorType, Doctrine.EMCONSettings._EMCONSetting setting, bool inherits)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new WaypointSensorMessage
		{
			UnitID = unit.ObjectID,
			WaypointID = waypoint.ObjectID,
			EMCON_SensorType = (short)sensorType,
			EMCON_Setting = (short)setting,
			EMCON_Inherit = inherits
		}, "SendWaypointSensorChange");
	}

	public void SendWaypointSensorChangeRadar(Module_Unit.Unit unit, Waypoint waypoint)
	{
		if (unit != null && waypoint != null && waypoint.HasDoctrine)
		{
			SendWaypointSensorChange(unit, waypoint, WaypointSensorMessage.SensorType.Radar, waypoint.GetDoctrine(ClientScenario).EMCON(ClientScenario).Radar(), waypoint.GetDoctrine(ClientScenario).EMCON_Inherits);
		}
	}

	public void SendWaypointSensorChangeSonar(Module_Unit.Unit unit, Waypoint waypoint)
	{
		if (unit != null && waypoint != null && waypoint.HasDoctrine)
		{
			SendWaypointSensorChange(unit, waypoint, WaypointSensorMessage.SensorType.Sonar, waypoint.GetDoctrine(ClientScenario).EMCON(ClientScenario).Sonar(), waypoint.GetDoctrine(ClientScenario).EMCON_Inherits);
		}
	}

	public void SendWaypointSensorChangeOECM(Module_Unit.Unit unit, Waypoint waypoint)
	{
		if (unit != null && waypoint != null && waypoint.HasDoctrine)
		{
			SendWaypointSensorChange(unit, waypoint, WaypointSensorMessage.SensorType.OECM, waypoint.GetDoctrine(ClientScenario).EMCON(ClientScenario).OECM(), waypoint.GetDoctrine(ClientScenario).EMCON_Inherits);
		}
	}

	private void method_37(NewWeaponImpactMessage newWeaponImpactMessage_0)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		lock (TerminalRenderLockObj)
		{
			Scenario clientScenario = ClientScenario;
			XmlNode theNode = new XmlDocument().ReadNode(XmlReader.Create((TextReader)new StringReader(newWeaponImpactMessage_0.XML)));
			ConcurrentDictionary<string, ScenarioObject> theDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			WeaponImpact item = WeaponImpact.FromXML(ref theNode, ref theDictionary);
			clientScenario.WeaponImpacts.Add(item);
		}
	}

	public void SetWeaponReloadPriority(ActiveUnit unit, Mount mount, int int_6)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (unit != null && mount != null)
		{
			method_50(new WeaponReloadPriorityUIMessage
			{
				ActiveUnitID = unit.ObjectID,
				MountID = mount.ObjectID,
				WeaponDBID = int_6,
				AddPriority = true
			}, "SetWeaponReloadPriority");
		}
	}

	public void RemoveWeaponReloadPriority(ActiveUnit unit, Mount mount, int int_6)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (unit != null && mount != null)
		{
			method_50(new WeaponReloadPriorityUIMessage
			{
				ActiveUnitID = unit.ObjectID,
				MountID = mount.ObjectID,
				WeaponDBID = int_6,
				AddPriority = false
			}, "RemoveWeaponReloadPriority");
		}
	}

	private void method_38(ZoneUpdateMessage zoneUpdateMessage_0)
	{
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		int count = zoneUpdateMessage_0.SideID.Count;
		string text = "";
		Side currentSide = clientScenario.GetCurrentSide();
		int num;
		if (currentSide == null)
		{
			num = 0;
		}
		else
		{
			text = currentSide.ObjectID;
			num = 0;
		}
		for (int i = num; i < count; i++)
		{
			Side sideByID = clientScenario.GetSideByID(zoneUpdateMessage_0.SideID[i]);
			if (sideByID == null)
			{
				continue;
			}
			_ = zoneUpdateMessage_0.SideID[i] == text;
			int count2 = zoneUpdateMessage_0.AllObjectID[i].Count;
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
			for (int j = 0; j < count2; j++)
			{
				Zone value = null;
				dictionary.TryGetValue(zoneUpdateMessage_0.AllObjectID[i][j], out value);
				if (value == null)
				{
					value = Zone.Create((Zone.ZoneType)zoneUpdateMessage_0.AllType[i][j], sideByID, ReferencePoint.FetchReferencePointsFromID(sideByID, zoneUpdateMessage_0.AllRPs[i][j]), zoneUpdateMessage_0.AllDescription[i][j], Color.FromArgb(zoneUpdateMessage_0.AllColor[i][j]));
					value.ObjectID = zoneUpdateMessage_0.AllObjectID[i][j];
					dictionary.Add(value.ObjectID, value);
				}
				value.IsActive = zoneUpdateMessage_0.AllIsActive[i][j];
				value.IsLocked = zoneUpdateMessage_0.AllIsLocked[i][j];
				value.Area = ReferencePoint.FetchReferencePointsFromID(sideByID, zoneUpdateMessage_0.AllRPs[i][j]);
				value.Description = zoneUpdateMessage_0.AllDescription[i][j];
				value.set_Layer(sideByID, zoneUpdateMessage_0.AllLayer[i][j]);
				value.AreaColor = Color.FromArgb(zoneUpdateMessage_0.AllColor[i][j]);
				value.AffectedUnitTypes.Clear();
				foreach (int item in zoneUpdateMessage_0.AllAffectedUnitTypes[i][j])
				{
					value.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)item);
				}
				switch (value.Type)
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
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				zoneUpdateDelegate_0(string_2);
			}, Array.Empty<object>());
			string_2 = "";
		}
	}

	public void SendZoneUpdate(Side side, Zone zone)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
		}
		else if (side != null && zone != null)
		{
			method_50(new ZoneUpdateMessage
			{
				AllObjectID = new List<List<string>>(1)
				{
					new List<string>(1) { zone.ObjectID }
				},
				SideID = new List<string>(1) { side.ObjectID },
				AllName = new List<List<string>>(1)
				{
					new List<string>(1) { zone.Name }
				},
				AllRPs = new List<List<List<string>>>(1)
				{
					new List<List<string>>(1) { ReferencePoint.FetchIDFromReferencePoints(zone.Area) }
				},
				AllDescription = new List<List<string>>(1)
				{
					new List<string>(1) { zone.Description }
				},
				AllLayer = new List<List<int>>(1)
				{
					new List<int>(1) { zone.get_Layer((Side)null) }
				},
				AllType = new List<List<int>>(1)
				{
					new List<int>(1) { (int)zone.Type }
				},
				AllColor = new List<List<int>>(1)
				{
					new List<int>(1) { zone.AreaColor.ToArgb() }
				},
				AllAffectedUnitTypes = new List<List<List<int>>>(1)
				{
					new List<List<int>>(1) { method_39(zone) }
				},
				AllViolatorsStance = new List<List<List<(string, int)>>>(1)
				{
					new List<List<(string, int)>>(1) { method_40(zone) }
				},
				AllMarkViolatorAs = new List<List<int>>(1)
				{
					new List<int>(1) { (int)method_43(zone) }
				},
				AllAltitudeEnvelopeMin = new List<List<float?>>(1)
				{
					new List<float?>(1) { method_44(zone) }
				},
				AllAltitudeEnvelopeMax = new List<List<float?>>(1)
				{
					new List<float?>(1) { method_45(zone) }
				},
				AllNoFireZone = new List<List<bool>>(1)
				{
					new List<bool>(1) { method_41(zone) }
				},
				AllIsLocked = new List<List<bool>>(1)
				{
					new List<bool>(1) { method_42(zone) }
				},
				AllIsActive = new List<List<bool>>(1)
				{
					new List<bool>(1) { zone.IsActive }
				}
			}, "SendZoneUpdate");
		}
	}

	private List<int> method_39(Zone zone_0)
	{
		List<int> list = new List<int>();
		if (zone_0.Type == Zone.ZoneType.ExclusionZone || zone_0.Type == Zone.ZoneType.NoNavZone)
		{
			foreach (GlobalVariables.ActiveUnitType affectedUnitType in zone_0.AffectedUnitTypes)
			{
				list.Add((int)affectedUnitType);
			}
		}
		return list;
	}

	private List<(string, int)> method_40(Zone zone_0)
	{
		List<(string, int)> list = new List<(string, int)>();
		if (zone_0.Type == Zone.ZoneType.ExclusionZone)
		{
			foreach (KeyValuePair<string, Command_Core.Misc.PostureStance> item in ((ExclusionZone)zone_0).ViolatorsStance)
			{
				list.Add((item.Key, (int)item.Value));
			}
		}
		return list;
	}

	private bool method_41(Zone zone_0)
	{
		if (zone_0.Type == Zone.ZoneType.NoNavZone)
		{
			return ((NoNavZone)zone_0).NoFireZone;
		}
		return false;
	}

	private bool method_42(Zone zone_0)
	{
		return zone_0.IsLocked;
	}

	private Command_Core.Misc.PostureStance method_43(Zone zone_0)
	{
		if (zone_0.Type == Zone.ZoneType.ExclusionZone)
		{
			return ((ExclusionZone)zone_0).MarkViolatorAs;
		}
		return Command_Core.Misc.PostureStance.Neutral;
	}

	private float? method_44(Zone zone_0)
	{
		if (zone_0.Type == Zone.ZoneType.ExclusionZone)
		{
			return ((ExclusionZone)zone_0).AltitudeEnvelopeMin;
		}
		return null;
	}

	private float? method_45(Zone zone_0)
	{
		if (zone_0.Type == Zone.ZoneType.ExclusionZone)
		{
			return ((ExclusionZone)zone_0).AltitudeEnvelopeMax;
		}
		return null;
	}

	public void SendCreateZone(Side side, Zone ExistingZone, bool select = false)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new CreateZoneMessage
		{
			SideID = side.ObjectID,
			AllRPs = ReferencePoint.FetchIDFromReferencePoints(side, ExistingZone.Area),
			ZoneColor = ExistingZone.AreaColor.ToArgb(),
			Type = (int)ExistingZone.Type,
			Name = ExistingZone.Description,
			Description = ExistingZone.Description,
			Layer = ExistingZone.get_Layer(side),
			AffectedUnitTypes = method_39(ExistingZone),
			ViolatorsStance = method_40(ExistingZone),
			MarkViolatorAs = (int)method_43(ExistingZone),
			AltitudeEnvelopeMin = method_44(ExistingZone),
			AltitudeEnvelopeMax = method_45(ExistingZone),
			NoFireZone = method_41(ExistingZone),
			IsLocked = method_42(ExistingZone),
			ClientSelectForNewZone = select
		}, "SendCreateZone");
	}

	public void SendCreateZone(Side side, Zone.ZoneType Type, List<ReferencePoint> area, Color color, string Name = "", bool select = false)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new CreateZoneMessage
		{
			SideID = side.ObjectID,
			AllRPs = ReferencePoint.FetchIDFromReferencePoints(side, area),
			ZoneColor = color.ToArgb(),
			Type = (int)Type,
			Name = Name,
			ClientSelectForNewZone = select
		}, "SendCreateZone");
	}

	public void SendDeleteZone(Side side, Zone zone)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		method_50(new DeleteZoneMessage
		{
			SideID = side.ObjectID,
			ZoneIDs = new List<string>(1) { zone.ObjectID }
		}, "SendDeleteZone");
	}

	private void DeleteZone(DeleteZoneMessage msg)
	{
		if (TerminalRights == TerminalRights.Observer)
		{
			method_55();
			return;
		}
		Scenario clientScenario = ClientScenario;
		if (clientScenario == null)
		{
			return;
		}
		Side currentSide = clientScenario.GetCurrentSide();
		if (currentSide == null || currentSide.ObjectID != msg.SideID)
		{
			return;
		}
		Dictionary<string, Zone> dictionary = new Dictionary<string, Zone>();
		foreach (Zone standardZone in currentSide.StandardZones)
		{
			dictionary.Add(standardZone.ObjectID, standardZone);
		}
		foreach (NoNavZone noNavZone in currentSide.NoNavZones)
		{
			dictionary.Add(noNavZone.ObjectID, noNavZone);
		}
		foreach (ExclusionZone exclusionZone in currentSide.ExclusionZones)
		{
			dictionary.Add(exclusionZone.ObjectID, exclusionZone);
		}
		if (dictionary.Count > 0)
		{
			for (int i = 0; i < msg.ZoneIDs.Count; i++)
			{
				if (dictionary.ContainsKey(msg.ZoneIDs[i]))
				{
					dictionary[msg.ZoneIDs[i]].Remove(currentSide);
				}
			}
		}
		dispatcher_0.BeginInvoke((Delegate)(Action)delegate
		{
			zoneUpdateDelegate_0("");
		}, Array.Empty<object>());
	}

	private void SelectNewZone(SelectNewZoneMessage msg)
	{
		string_2 = msg.ZoneID;
	}

	public static void ClearLobbyData()
	{
		LobbyConnectionRequested = false;
		LobbyRoutingServerIP = "";
		LobbyRoutingServerPort = 0;
		LobbyMyUserID = 0u;
		LobbyServerUserID = 0u;
		SerializedNetworID = "";
		InviteCode = "";
		ScenarioBriefingShown = false;
	}

	[SpecialName]
	[CompilerGenerated]
	private Connection method_46()
	{
		return connection_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_47(Connection connection_1)
	{
		connection_0 = connection_1;
	}

	public bool IsConnected()
	{
		if (method_46() != null)
		{
			return true;
		}
		if (realtimeHost_0 == null)
		{
			return false;
		}
		return true;
	}

	public void DisableCommandCoreEventNotifications()
	{
	}

	public void EnableCommandCoreEventNotifications()
	{
	}

	public void SetClientScenario(Scenario newScen)
	{
		DisableCommandCoreEventNotifications();
		dictionary_4.Clear();
		dictionary_0.Clear();
		ClientScenario = newScen;
		PopulateLastHostMissionStates();
		ResetTimeValues();
		EnableCommandCoreEventNotifications();
	}

	public void ResetTimeValues()
	{
		lastLocalScenarioTime = ClientScenario.Time;
		currentHostScenarioTime = lastLocalScenarioTime;
		previousHostScenarioTime = currentHostScenarioTime;
		currentHostSimExecutionStep = 0u;
		hostScenarioElapsedTime = 0;
		hostRealTimeRatio = 1f;
		lastHostUpdateTickTime = 0;
		lastHostUpdateTickDuration = 1000;
		lastLocalTickTime = 0;
	}

	private void method_48(string string_8)
	{
		try
		{
			dispatcher_0.BeginInvoke((Delegate)logTextDelegate_0, new object[1] { string_8 });
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public RealtimeTerminal()
	{
		ClientName = "Player";
		TerminalRights = TerminalRights.Player;
		TerminalLockedSide = "";
		ShowPeerViewports = false;
	}

	public void ConnectNetwork(string ip, int port)
	{
		throw new NotImplementedException("Direct IP connection not available in CIVMP");
	}

	public void ConnectNetwork()
	{
		lock (TerminalLockObj)
		{
			LoginSuccessful = false;
			if (LobbyConnectionRequested)
			{
				IP = LobbyRoutingServerIP;
				port = LobbyRoutingServerPort;
				if (!IsConnected())
				{
					if (!bool_8)
					{
						method_48("Attempting to connect to " + IP);
						try
						{
							if (!LobbyConnectionRequested || LobbyMyUserID == 0)
							{
								throw new Exception();
							}
							uint lobbyMyUserID = LobbyMyUserID;
							if (!LobbyConnectionRequested || LobbyServerUserID == 0)
							{
								throw new Exception();
							}
							uint lobbyServerUserID = LobbyServerUserID;
							SlitherineRouterClient = new PlayFabPartyClient(SerializedNetworID, InviteCode, (int)lobbyMyUserID, (int)lobbyServerUserID);
							method_47(new Connection(lobbyServerUserID));
							Connection.playFabPartyClient = SlitherineRouterClient;
							Connection.playFabPartyClient.PeerConnected += delegate
							{
							};
							Connection.playFabPartyClient.PeerDisconnected += delegate
							{
								ConnectionClosed(method_46());
							};
							SlitherineRouterClient.MessageReceived += delegate(object sender, ByteArrayMessageEventArgs e)
							{
								Connection connection_ = method_46();
								PacketHeader packetHeader_ = new PacketHeader();
								method_49(packetHeader_, connection_, e.Message);
							};
							SlitherineRouterClient.Connect();
							ConnectionEstablished(method_46());
							if (LobbyConnectionRequested)
							{
								ClearLobbyData();
							}
						}
						catch (ConnectionSetupException ex)
						{
							throw ex;
						}
						catch (Exception)
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							method_48("Unable to connect. Please check IP, port, firewall.");
						}
						ClientName = ClientName ?? Dns.GetHostName();
						return;
					}
					throw new Exception("Server is already started?");
				}
				throw new Exception("Server is already connected?!");
			}
			throw new Exception("CIVMP requires LobbyConnectionRequested to be set before calling ConnectNetwork()");
		}
	}

	public void StartLoopback(Dispatcher Dispatcher, RealtimeHost Loopback, ITimingGraph TimingGraph = null)
	{
		throw new NotImplementedException("Loopback not supported in CIVMP");
	}

	public void StartNetwork(Dispatcher Dispatcher, ITimingGraph TimingGraph = null)
	{
		if (RealtimeHost.RealtimeHostExists)
		{
			throw new Exception();
		}
		thread_0 = new Thread(TerminalThreadSubroutine);
		thread_0.Start();
		lock (TerminalLockObj)
		{
			try
			{
				itimingGraph_0 = TimingGraph ?? new NullTimingGraph();
				dispatcher_0 = Dispatcher;
				method_48("STARTING Multiplayer NETWORK REALTIME Client");
				if (bool_8)
				{
					throw new Exception("Client already started.");
				}
				if (thread_1 != null)
				{
					thread_1.Abort();
				}
				thread_1 = new Thread(method_57);
				thread_1.Start();
				if (thread_2 != null)
				{
					thread_2.Abort();
				}
				thread_2 = new Thread(method_56);
				thread_2.Start();
			}
			catch
			{
			}
		}
	}

	private void method_49(PacketHeader packetHeader_0, Connection connection_1, byte[] byte_0)
	{
		byte_0.Count();
		RTMessage msg = RealtimeSerializer.Deserialize<RTMessage>(byte_0);
		lock (TerminalLockObj)
		{
			try
			{
				Interlocked.Add(ref int_4, byte_0.Length);
				QueueMessage(msg, connection_1);
			}
			catch (Exception ex)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				try
				{
					method_48("ERROR upon recv message. E: " + ex.Message);
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
				method_48("Letting server know we ran into a serious error.");
				method_50(new ErrorMessage
				{
					Message = "Ran into an error in ReceivedMessage."
				}, "SeriousError");
			}
		}
	}

	public void ConnectionEstablished(Connection connection)
	{
		lock (TerminalLockObj)
		{
			method_48("CONNECTED");
			method_47(connection);
			bool_8 = true;
			byte[] message = RealtimeSerializer.Serialize(new ServerInfoRequest());
			Connection.playFabPartyClient.SendMessage(connection.OtherUserID, message);
		}
		dispatcher_0.BeginInvoke((Delegate)connectedDelegate_0, Array.Empty<object>());
	}

	public void ConnectionClosed(Connection connection)
	{
		lock (TerminalLockObj)
		{
			LoginSuccessful = false;
			method_48("DISCONNECTED");
			method_47(null);
			bool_8 = false;
			Peers = new List<RealtimePeer>();
		}
		dispatcher_0.BeginInvoke((Delegate)disconnectedDelegate_0, Array.Empty<object>());
	}

	private void ClientError(string msg)
	{
		lock (TerminalLockObj)
		{
			method_48(msg ?? "");
			method_50(new ErrorMessage
			{
				Message = msg
			}, "ClientError");
		}
	}

	private void method_50(RTMessage rtmessage_0, string string_8)
	{
		if (IsConnected())
		{
			rtmessage_0.SimTimeSent = ClientScenario?.Time ?? new DateTime(1900, 1, 1);
			if (bool_8)
			{
				concurrentQueue_1.Enqueue(rtmessage_0);
			}
		}
	}

	private void method_51(RTMessage rtmessage_0)
	{
		if (!IsConnected() || !bool_8)
		{
			return;
		}
		lock (TerminalLockObj)
		{
			try
			{
				if (LoopbackMode)
				{
					try
					{
						string_7 = string_7 + ", " + rtmessage_0.GetType().Name;
						realtimeHost_0.QueueMessage(rtmessage_0, null, null);
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
				byte[] array = RealtimeSerializer.Serialize(rtmessage_0);
				string_7 = string_7 + ", " + rtmessage_0.GetType().Name;
				Interlocked.Add(ref int_5, array.Length);
				method_48($"transmitting to server {array.Count()} bytes {rtmessage_0.GetType().Name}");
				Connection.playFabPartyClient.SendMessage(method_46().OtherUserID, array);
			}
			catch (Exception)
			{
			}
		}
	}

	public void Disconnect()
	{
		lock (TerminalLockObj)
		{
			method_48("Disconnecting");
			if (LoopbackMode)
			{
				realtimeHost_0.ConnectionClosedLoopback(this);
			}
			bIeLagkLoHA = Guid.Empty;
			if (method_46() != null)
			{
				method_46()?.CloseConnection(b: false);
				method_47(null);
			}
		}
	}

	public void Shutdown()
	{
		bool_9 = true;
		if (thread_1 != null)
		{
			thread_1.Join();
			thread_1 = null;
		}
		if (thread_2 != null)
		{
			thread_2.Join();
			thread_2 = null;
		}
		if (thread_0 != null)
		{
			thread_0.Join();
			thread_0 = null;
		}
		lock (TerminalLockObj)
		{
			if (bool_8)
			{
				Disconnect();
				bool_8 = false;
			}
		}
	}

	public void TerminalThreadSubroutine()
	{
		while (!bool_9)
		{
			AdvanceLocalScenarioTime();
			Thread.Sleep(1);
		}
	}

	private void method_52(Module_Unit.Unit unit_0, DateTime dateTime_6)
	{
		if (unit_0 != null)
		{
			unit_0.Latitude_old = unit_0.get_Latitude((GlobalVariables.BooleanObject)null);
			unit_0.Longitude_old = unit_0.get_Longitude((GlobalVariables.BooleanObject)null);
			concurrentDictionary_0.AddOrUpdate(unit_0.ObjectID, dateTime_6, (string key, DateTime oldValue) => dateTime_6);
		}
	}

	public void AdvanceLocalScenarioTime()
	{
		if (ClientScenario == null)
		{
			return;
		}
		int num = Environment.TickCount & 0x7FFFFFFF;
		if ((float)(num - lastLocalTickTime) < DEFAULT_TICK_STEP_MS)
		{
			return;
		}
		if (!(lastLocalScenarioTime == currentHostScenarioTime))
		{
			Scenario theScen = ClientScenario;
			int num2 = (int)(currentHostScenarioTime - lastLocalScenarioTime).TotalMilliseconds;
			float num3 = hostRealTimeRatio;
			if (num2 > 0)
			{
				float num4 = 0f;
				float num5 = 0f;
				num3 = ((num2 > hostScenarioElapsedTime) ? (num3 * 1.025f) : ((num2 >= hostScenarioElapsedTime / 2) ? (num3 * 0.9f) : (num3 * (float)(num2 / (hostScenarioElapsedTime / 2)))));
				float num6 = (float)num2 / 1000f;
				num4 = (float)(num - lastLocalTickTime) / 1000f;
				num4 += num5;
				num4 *= num3;
				if (num4 > num6)
				{
					num4 = num6;
				}
				if (num4 > 0f)
				{
					lock (TerminalRenderLockObj)
					{
						if (theScen.Explosions != null && theScen.Explosions.Count > 0)
						{
							List<Explosion> explosions = theScen.Explosions;
							for (int num7 = explosions.Count - 1; num7 >= 0; num7--)
							{
								Explosion explosion = explosions[num7];
								if (explosion.HasExpired)
								{
									theScen.Explosions.Remove(explosion);
								}
								else
								{
									explosion.ProgressTime(num4);
								}
							}
						}
						if (theScen.WeaponImpacts != null && theScen.WeaponImpacts.Count > 0)
						{
							List<WeaponImpact> weaponImpacts = theScen.WeaponImpacts;
							for (int num8 = weaponImpacts.Count - 1; num8 >= 0; num8--)
							{
								WeaponImpact weaponImpact = weaponImpacts[num8];
								if (weaponImpact.Age > 5f)
								{
									theScen.WeaponImpacts.Remove(weaponImpact);
								}
								else
								{
									weaponImpact.Progress(ref theScen, num4);
								}
							}
						}
						if (theScen.ChaffClouds != null && theScen.ChaffClouds.Count > 0)
						{
							List<ChaffCorridorCloud> chaffClouds = theScen.ChaffClouds;
							for (int num9 = chaffClouds.Count - 1; num9 >= 0; num9--)
							{
								chaffClouds[num9].Progress(num4);
								if (((Module_Unit.Unit)chaffClouds[num9]).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f)
								{
									theScen.ChaffClouds.Remove(chaffClouds[num9]);
								}
							}
						}
						if (theScen.GroundImpacts != null && theScen.GroundImpacts.Count > 0)
						{
							for (int num10 = theScen.GroundImpacts.Count - 1; num10 >= 0; num10--)
							{
								theScen.GroundImpacts[num10].Spread(theScen, num4);
							}
						}
						if (theScen.WaterSplashes != null && theScen.WaterSplashes.Count > 0)
						{
							List<WaterSplash> list = theScen.WaterSplashes.ToList();
							for (int num11 = list.Count - 1; num11 >= 0; num11--)
							{
								list[num11].Spread(theScen, num4);
							}
						}
						if (theScen.UnguidedWeapons != null && theScen.UnguidedWeapons.HasElements())
						{
							List<UnguidedWeapon> list2 = theScen.UnguidedWeapons.Values.ToList();
							for (int num12 = list2.Count - 1; num12 >= 0; num12--)
							{
								list2[num12].SimulateMovement(theScen, num4);
							}
						}
						lastLocalScenarioTime = lastLocalScenarioTime.AddSeconds(num4);
						if (tlist_0.Count > 0)
						{
							List<IntermediatePositionUpdateMessage> list3 = new List<IntermediatePositionUpdateMessage>();
							foreach (IntermediatePositionUpdateMessage item in tlist_0)
							{
								if (item.SimTimeSent <= lastLocalScenarioTime)
								{
									switch ((IntermediatePositionUpdateMessage.UpdateType)item.ObjectType)
									{
									case IntermediatePositionUpdateMessage.UpdateType.CONTACT_POSITION:
									case IntermediatePositionUpdateMessage.UpdateType.CONTACT_CLIENT_INTERPOLATION:
										method_20(item);
										break;
									case IntermediatePositionUpdateMessage.UpdateType.ACTIVEUNIT_POSITION:
									case IntermediatePositionUpdateMessage.UpdateType.ACTIVEUNIT_CLIENT_INTERPOLATION:
										method_29(item);
										break;
									}
									list3.Add(item);
								}
							}
							if (InterpolateUnitPositions)
							{
								bool flag = false;
								bool flag2 = false;
								int num13 = tlist_0.Count - 1;
								while (num13 >= 0 && (!flag || !flag2))
								{
									if (!flag && tlist_0[num13].ObjectType == 0)
									{
										list3.Remove(tlist_0[num13]);
										flag = true;
									}
									else if (!flag2 && tlist_0[num13].ObjectType == 2)
									{
										list3.Remove(tlist_0[num13]);
										flag2 = true;
									}
									num13--;
								}
							}
							lock (tlist_0)
							{
								foreach (IntermediatePositionUpdateMessage item2 in list3)
								{
									tlist_0.Remove(item2);
								}
							}
						}
					}
				}
			}
			lastLocalTickTime = num;
		}
		else
		{
			lastLocalTickTime = num;
		}
	}

	private IntermediatePositionUpdateMessage method_53(int int_6, DateTime dateTime_6)
	{
		lock (tlist_0)
		{
			int num = tlist_0.Count - 1;
			while (num >= 0)
			{
				if (tlist_0[num].ObjectType != int_6 || !(tlist_0[num].SimTimeSent == dateTime_6))
				{
					num--;
					continue;
				}
				return tlist_0[num];
			}
		}
		return null;
	}

	private void method_54(IntermediatePositionUpdateMessage intermediatePositionUpdateMessage_0, string string_8 = null, string string_9 = null)
	{
		try
		{
			IntermediatePositionUpdateMessage intermediatePositionUpdateMessage = null;
			int num = tlist_0.Count - 1;
			while (num >= 0)
			{
				if (tlist_0[num].ObjectType != intermediatePositionUpdateMessage_0.ObjectType || !(tlist_0[num].SimTimeSent < intermediatePositionUpdateMessage_0.SimTimeSent))
				{
					num--;
					continue;
				}
				intermediatePositionUpdateMessage = tlist_0[num];
				break;
			}
			if (intermediatePositionUpdateMessage == null)
			{
				return;
			}
			int num2 = (int)((intermediatePositionUpdateMessage_0.SimTimeSent - intermediatePositionUpdateMessage.SimTimeSent).TotalSeconds * 1000.0);
			if (num2 < 1000)
			{
				return;
			}
			int num3 = InterpolationInterval_Fast_ms;
			float num4 = 0f;
			if (num2 > 15000)
			{
				num3 = InterpolationInterval_Slow_ms;
			}
			List<string> list = new List<string>();
			List<double> list2 = new List<double>();
			List<double> list3 = new List<double>();
			List<float> list4 = new List<float>();
			List<float> list5 = new List<float>();
			List<double> list6 = new List<double>();
			List<double> list7 = new List<double>();
			List<float> list8 = new List<float>();
			List<float> list9 = new List<float>();
			List<float> list10 = new List<float>();
			List<double> list11 = new List<double>();
			List<float> list12 = new List<float>();
			List<float> list13 = new List<float>();
			double num5 = 0.0;
			float num6 = 0f;
			double out_lat = 0.0;
			double out_lon = 0.0;
			bool flag = !string.IsNullOrEmpty(string_8);
			bool flag2 = !string.IsNullOrEmpty(string_9);
			bool flag3 = false;
			string text = "";
			for (int i = 0; i < intermediatePositionUpdateMessage.ObjectID.Count && !flag3; i++)
			{
				if (string.IsNullOrEmpty(intermediatePositionUpdateMessage.ObjectID[i]))
				{
					continue;
				}
				int num7;
				if (flag)
				{
					if (flag2)
					{
						if (string_9 != intermediatePositionUpdateMessage.ObjectID[i])
						{
							continue;
						}
						text = string_8;
						num7 = 0;
					}
					else
					{
						if (string_8 != intermediatePositionUpdateMessage.ObjectID[i])
						{
							continue;
						}
						text = intermediatePositionUpdateMessage.ObjectID[i];
						num7 = 0;
					}
				}
				else
				{
					text = intermediatePositionUpdateMessage.ObjectID[i];
					num7 = 0;
				}
				for (int j = num7; j < intermediatePositionUpdateMessage_0.ObjectID.Count; j++)
				{
					if (!string.IsNullOrEmpty(intermediatePositionUpdateMessage_0.ObjectID[j]) && intermediatePositionUpdateMessage_0.ObjectID[j] == text)
					{
						list.Add(intermediatePositionUpdateMessage_0.ObjectID[j]);
						list6.Add(intermediatePositionUpdateMessage.Latitude[i]);
						list7.Add(intermediatePositionUpdateMessage.Longitude[i]);
						list8.Add(intermediatePositionUpdateMessage.Heading[i]);
						list9.Add(intermediatePositionUpdateMessage.Altitude[i]);
						list10.Add(Math2.CalcAzimuth(intermediatePositionUpdateMessage.Latitude[i], intermediatePositionUpdateMessage.Longitude[i], intermediatePositionUpdateMessage_0.Latitude[j], intermediatePositionUpdateMessage_0.Longitude[j]));
						list11.Add(Math2.CalcDist(intermediatePositionUpdateMessage.Latitude[i], intermediatePositionUpdateMessage.Longitude[i], intermediatePositionUpdateMessage_0.Latitude[j], intermediatePositionUpdateMessage_0.Longitude[j]));
						list12.Add(Command_Core.Misc.RelativeAngleBetweenBearings(intermediatePositionUpdateMessage_0.Heading[j], intermediatePositionUpdateMessage.Heading[i], PreserveLeftRight: true));
						list13.Add(intermediatePositionUpdateMessage_0.Altitude[j] - intermediatePositionUpdateMessage.Altitude[i]);
						if (flag)
						{
							flag3 = true;
						}
						break;
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			for (int k = num3; k <= num2; k += num3)
			{
				num4 = (float)k / (float)num2;
				IntermediatePositionUpdateMessage intermediatePositionUpdateMessage2 = new IntermediatePositionUpdateMessage();
				intermediatePositionUpdateMessage2.SimTimeSent = intermediatePositionUpdateMessage.SimTimeSent.AddMilliseconds(k);
				int num8;
				switch ((IntermediatePositionUpdateMessage.UpdateType)intermediatePositionUpdateMessage.ObjectType)
				{
				default:
					return;
				case IntermediatePositionUpdateMessage.UpdateType.CONTACT_POSITION:
					intermediatePositionUpdateMessage2.ObjectType = 3;
					num8 = 0;
					break;
				case IntermediatePositionUpdateMessage.UpdateType.ACTIVEUNIT_POSITION:
					intermediatePositionUpdateMessage2.ObjectType = 1;
					num8 = 0;
					break;
				}
				for (int l = num8; l < list.Count; l++)
				{
					num5 = list11[l] * (double)num4;
					num6 = list10[l];
					Geodesic_EdWilliams.CalcPoint_Williams_NoRef(list7[l], list6[l], ref out_lon, ref out_lat, ref num5, ref num6);
					list2.Add(out_lat);
					list3.Add(out_lon);
					list4.Add(Math2.NormalizeBearing(list8[l] + num4 * list12[l]));
					list5.Add(list9[l] + num4 * list13[l]);
				}
				intermediatePositionUpdateMessage2.ObjectID = list;
				intermediatePositionUpdateMessage2.Latitude = list2.ToList();
				intermediatePositionUpdateMessage2.Longitude = list3.ToList();
				intermediatePositionUpdateMessage2.Heading = list4.ToList();
				intermediatePositionUpdateMessage2.Altitude = list5.ToList();
				list2.Clear();
				list3.Clear();
				list4.Clear();
				list5.Clear();
				tlist_0.Add(intermediatePositionUpdateMessage2);
			}
		}
		catch
		{
		}
	}

	private void method_55()
	{
	}

	private void method_56()
	{
		while (!bool_9)
		{
			try
			{
				Thread.Sleep(1000);
				if (realtimeHost_0 != null)
				{
					InOutDisplay.OutgoingSummary = "Xmit loopback";
					InOutDisplay.IncommingSummary = "Recv loopback";
				}
				else
				{
					InOutDisplay.OutgoingSummary = $"Xmit: {(double)int_4 * 8.0 / 1024.0 / 1.0:0.0}kbit/sec";
					InOutDisplay.IncommingSummary = $"Recv: {(double)int_5 * 8.0 / 1024.0 / 1.0:0.0}kbit/sec";
					int_4 = 0;
					int_5 = 0;
				}
				if (string_6.Length > 2)
				{
					InOutDisplay.IncommingData = string_6.Substring(2);
				}
				else
				{
					InOutDisplay.IncommingData = "";
				}
				if (string_7.Length > 2)
				{
					InOutDisplay.OutgoingData = string_7.Substring(2);
				}
				else
				{
					InOutDisplay.OutgoingData = "";
				}
				string_6 = string.Empty;
				string_7 = string.Empty;
			}
			catch (ThreadAbortException)
			{
				break;
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

	public void QueueMessage(RTMessage msg, Connection connection)
	{
		concurrentQueue_0.Enqueue(new Tuple<RTMessage, Connection>(msg, connection));
	}

	private void method_57()
	{
		Tuple<RTMessage, Connection> result = null;
		RTMessage result2 = null;
		while (!bool_9)
		{
			try
			{
				while (!concurrentQueue_1.IsEmpty)
				{
					if (concurrentQueue_1.TryDequeue(out result2))
					{
						method_51(result2);
					}
				}
				int millisecondsTimeout;
				while (true)
				{
					if (!concurrentQueue_0.IsEmpty)
					{
						if (!PushStateInProgress)
						{
							if (concurrentQueue_0.TryDequeue(out result))
							{
								string_6 = string_6 + ", " + result.Item1.GetType().Name;
								method_58(result.Item1, result.Item2);
							}
							continue;
						}
						millisecondsTimeout = 1;
						break;
					}
					millisecondsTimeout = 1;
					break;
				}
				Thread.Sleep(millisecondsTimeout);
			}
			catch (ThreadAbortException)
			{
				break;
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

	private void method_58(RTMessage rtmessage_0, Connection connection_1)
	{
		dateTime_5 = DateTime.Now;
		Interlocked.Increment(ref int_3);
		Interlocked.Increment(ref int_2);
		lock (TerminalLockObj)
		{
			try
			{
				if (LoginSuccessful || rtmessage_0 is LoginReplyMessage || rtmessage_0 is ServerInfoRequest || rtmessage_0 is ErrorMessage || rtmessage_0 is GlobalChatMessage)
				{
					if (!(rtmessage_0 is GlobalChatMessage msg))
					{
						if (!(rtmessage_0 is LoginReplyMessage loginReplyMessage_))
						{
							if (!(rtmessage_0 is ServerInfoRequest msg2))
							{
								if (!(rtmessage_0 is EmbarkedOpsUpdateMessage embarkedOpsUpdateMessage_))
								{
									if (!(rtmessage_0 is PushStateMessage pushStateMessage_))
									{
										if (rtmessage_0 is StatusMessage msg3)
										{
											Status(msg3);
										}
										else if (!(rtmessage_0 is PositionUpdateMessage positionUpdateMessage_))
										{
											if (rtmessage_0 is IntermediatePositionUpdateMessage intermediatePositionUpdateMessage_)
											{
												vnyLliHlZyO(intermediatePositionUpdateMessage_);
											}
											else if (rtmessage_0 is ErrorMessage msg4)
											{
												Error(msg4);
											}
											else if (!(rtmessage_0 is AbsoluteControlGrantedMessage absoluteControlGrantedMessage_))
											{
												if (!(rtmessage_0 is CourseUpdateMessage courseUpdateMessage_))
												{
													if (rtmessage_0 is WaypointUpdateMessage waypointUpdateMessage_)
													{
														method_36(waypointUpdateMessage_);
													}
													else if (!(rtmessage_0 is ActiveUnitUpdateMessage activeUnitUpdateMessage_))
													{
														if (rtmessage_0 is ActiveUnitRemoveMessage activeUnitRemoveMessage_)
														{
															method_2(activeUnitRemoveMessage_);
														}
														else if (!(rtmessage_0 is ActiveUnitHomeBaseMessage activeUnitHomeBaseMessage_))
														{
															if (!(rtmessage_0 is DeleteReferencePointMessage msg5))
															{
																if (!(rtmessage_0 is ReferencePointUpdateMessage msg6))
																{
																	if (rtmessage_0 is DeleteZoneMessage msg7)
																	{
																		DeleteZone(msg7);
																	}
																	else if (rtmessage_0 is ZoneUpdateMessage zoneUpdateMessage_)
																	{
																		method_38(zoneUpdateMessage_);
																	}
																	else if (rtmessage_0 is SelectNewZoneMessage msg8)
																	{
																		SelectNewZone(msg8);
																	}
																	else if (!(rtmessage_0 is PeerScreenMouseUpdateMessage msg9))
																	{
																		if (rtmessage_0 is AutosavesListReplyMessage autosavesListReplyMessage_)
																		{
																			method_5(autosavesListReplyMessage_);
																		}
																		else if (rtmessage_0 is PeerListMessage peerListMessage_)
																		{
																			method_8(peerListMessage_);
																		}
																		else if (rtmessage_0 is WeaponSalvoUpdateMessage weaponSalvoUpdateMessage_)
																		{
																			method_12(weaponSalvoUpdateMessage_);
																		}
																		else if (rtmessage_0 is MessageLogUpdateMessage messageLogUpdateMessage_)
																		{
																			method_26(messageLogUpdateMessage_);
																		}
																		else if (!(rtmessage_0 is ContactRemoveMessage contactRemoveMessage_))
																		{
																			if (rtmessage_0 is ContactStatusMessage contactStatusMessage_)
																			{
																				method_19(contactStatusMessage_);
																			}
																			else if (!(rtmessage_0 is ContactAddOrUpdateMessage contactAddOrUpdateMessage_))
																			{
																				if (rtmessage_0 is ContactStanceMessage msg10)
																				{
																					ContactStance(msg10);
																				}
																				else if (rtmessage_0 is ContactFilterMessage msg11)
																				{
																					ContactFilter(msg11);
																				}
																				else if (rtmessage_0 is ConditionUpdateMessage conditionUpdateMessage_)
																				{
																					method_15(conditionUpdateMessage_);
																				}
																				else if (!(rtmessage_0 is NewExplosionMessage newExplosionMessage_))
																				{
																					if (!(rtmessage_0 is NewWeaponImpactMessage newWeaponImpactMessage_))
																					{
																						if (rtmessage_0 is NewGroundImpactMessage newGroundImpactMessage_)
																						{
																							method_25(newGroundImpactMessage_);
																						}
																						else if (!(rtmessage_0 is NewWaterSplashMessage newWaterSplashMessage_))
																						{
																							if (!(rtmessage_0 is NewChaffCloudMessage newChaffCloudMessage_))
																							{
																								if (rtmessage_0 is NewUnguidedWeaponMessage newUnguidedWeaponMessage_)
																								{
																									method_33(newUnguidedWeaponMessage_);
																								}
																								else if (!(rtmessage_0 is RemoveUnguidedWeaponsMessage removeUnguidedWeaponsMessage_))
																								{
																									if (!(rtmessage_0 is SensorUpdateMessage msg12))
																									{
																										if (!(rtmessage_0 is SensorIntermittentEmissionUpdateMessage msg13))
																										{
																											if (!(rtmessage_0 is DoctrineUpdateMessage doctrineUpdateMessage_))
																											{
																												if (!(rtmessage_0 is MissionUpdateMessage msg14))
																												{
																													if (rtmessage_0 is MissionRemoveMessage msg15)
																													{
																														RemoveMission(msg15);
																													}
																													else if (!(rtmessage_0 is MissionEditorShowWarningMessage msg16))
																													{
																														if (!(rtmessage_0 is MissionEditorEventMessage msg17))
																														{
																															if (!(rtmessage_0 is SideUpdateMessage sideUpdateMessage_))
																															{
																																if (rtmessage_0 is SidePosturesUpdateMessage sidePosturesUpdateMessage_)
																																{
																																	method_30(sidePosturesUpdateMessage_);
																																}
																																else if (!(rtmessage_0 is SideAlertnessUpdateMessage sideAlertnessUpdateMessage_))
																																{
																																	if (!(rtmessage_0 is SideMapPingMessage msg18))
																																	{
																																		if (!(rtmessage_0 is ExecutionSyncMessage executionSyncMessage_))
																																		{
																																			if (rtmessage_0 is GroupMembershipUpdateMessage msg19)
																																			{
																																				GroupMembershipUpdate(msg19);
																																			}
																																			else if (!(rtmessage_0 is SpecialActionMessage msg20))
																																			{
																																				if (rtmessage_0 is ScoringUpdateMessage msg21)
																																				{
																																					ScoringUpdate(msg21);
																																				}
																																				else if (!(rtmessage_0 is HealthReplyMessage healthReplyMessage_))
																																				{
																																					if (!(rtmessage_0 is SoundEffectsMessage msg22))
																																					{
																																						if (rtmessage_0 is GameOverMessage gameOverMessage_)
																																						{
																																							method_11(gameOverMessage_);
																																						}
																																						else if (rtmessage_0 is UIMessage msg23)
																																						{
																																							UI(msg23);
																																						}
																																						else if (Debugger.IsAttached)
																																						{
																																							Debugger.Break();
																																						}
																																					}
																																					else
																																					{
																																						SoundEffectsUpdate(msg22);
																																					}
																																				}
																																				else
																																				{
																																					method_6(healthReplyMessage_);
																																				}
																																			}
																																			else
																																			{
																																				SpecialActionResult(msg20);
																																			}
																																		}
																																		else
																																		{
																																			method_10(executionSyncMessage_);
																																		}
																																	}
																																	else
																																	{
																																		SideMapPing(msg18);
																																	}
																																}
																																else
																																{
																																	method_32(sideAlertnessUpdateMessage_);
																																}
																															}
																															else
																															{
																																method_31(sideUpdateMessage_);
																															}
																														}
																														else
																														{
																															MissionEditorEvent(msg17);
																														}
																													}
																													else
																													{
																														MissionEditorWarningMessage(msg16);
																													}
																												}
																												else
																												{
																													UpdateMission(msg14);
																												}
																											}
																											else
																											{
																												method_22(doctrineUpdateMessage_);
																											}
																										}
																										else
																										{
																											IntermittentEmissionUpdate(msg13);
																										}
																									}
																									else
																									{
																										SensorUpdate(msg12);
																									}
																								}
																								else
																								{
																									method_34(removeUnguidedWeaponsMessage_);
																								}
																							}
																							else
																							{
																								method_14(newChaffCloudMessage_);
																							}
																						}
																						else
																						{
																							method_35(newWaterSplashMessage_);
																						}
																					}
																					else
																					{
																						method_37(newWeaponImpactMessage_);
																					}
																				}
																				else
																				{
																					method_24(newExplosionMessage_);
																				}
																			}
																			else
																			{
																				method_17(contactAddOrUpdateMessage_);
																			}
																		}
																		else
																		{
																			method_18(contactRemoveMessage_);
																		}
																	}
																	else
																	{
																		PeerScreenMouseUpdate(msg9);
																	}
																}
																else
																{
																	ReferencePointUpdate(msg6);
																}
															}
															else
															{
																DeleteReferencePoint(msg5);
															}
														}
														else
														{
															method_3(activeUnitHomeBaseMessage_);
														}
													}
													else
													{
														method_1(activeUnitUpdateMessage_);
													}
												}
												else
												{
													method_21(courseUpdateMessage_);
												}
											}
											else
											{
												method_4(absoluteControlGrantedMessage_);
											}
										}
										else
										{
											method_28(positionUpdateMessage_);
										}
									}
									else
									{
										method_9(pushStateMessage_);
									}
								}
								else
								{
									method_23(embarkedOpsUpdateMessage_);
								}
							}
							else
							{
								ServerInfoRequest(msg2);
							}
						}
						else
						{
							method_7(loginReplyMessage_);
						}
					}
					else
					{
						GlobalChat(msg);
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
					method_48("ERROR upon recv message. E: " + ex.Message);
					GameGeneral.WriteExceptionsToLog(ex);
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
				method_48("Letting server know we ran into a serious error.");
				method_50(new ErrorMessage
				{
					Message = "Ran into an error in HandleMessage."
				}, "ClientError");
			}
		}
		Interlocked.Decrement(ref int_2);
	}

	private void Error(ErrorMessage msg)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (LoginSuccessful)
		{
			Disconnect();
			MessageBox.Show(msg.Message);
		}
		else
		{
			dispatcher_0.BeginInvoke((Delegate)(Action)delegate
			{
				loginResultDelegate_0(result: false, msg.Message, string.Empty, string.Empty);
			}, Array.Empty<object>());
		}
	}

	static RealtimeTerminal()
	{
		Class72.smethod_20();
		uint_0 = 0u;
		ActiveDeserializationCount = 0;
		LobbyConnectionRequested = false;
		LobbyRoutingServerIP = "";
		LobbyRoutingServerPort = 0;
		LobbyMyUserID = 0u;
		LobbyServerUserID = 0u;
		SerializedNetworID = "";
		InviteCode = "";
		ScenarioBriefingShown = false;
		RT_INTERPOLATION_SPEED_MIN = 100f;
		DEFAULT_TICK_STEP_MS = 25f;
	}

	[CompilerGenerated]
	private void method_59()
	{
		absoluteControlReleasedDelegate_0();
	}

	[CompilerGenerated]
	private void method_60()
	{
		method_50(new HealthMessage
		{
			CPU = performanceCounter_0.NextValue(),
			LocalTrafficWaiting = TrafficWaitingForLock
		}, "SendHealth");
		dateTime_0 = DateTime.Now;
	}

	[CompilerGenerated]
	private void method_61()
	{
		serverInfoDelegate_0();
	}

	[CompilerGenerated]
	private void method_62()
	{
		weaponSalvosUpdateDelegate_0();
	}

	[CompilerGenerated]
	private void method_63()
	{
		messageLogUpdateDelegate_0();
	}

	[CompilerGenerated]
	private void method_64()
	{
		missionUpdateDelegate_0("", openEditorWindow: false);
	}

	[CompilerGenerated]
	private void method_65()
	{
		sensorsUpdateDelegate_0();
	}

	[CompilerGenerated]
	private void method_66()
	{
		missionEditorEventDelegate_0(1);
	}

	[CompilerGenerated]
	private void method_67()
	{
		zoneUpdateDelegate_0(string_2);
	}

	[CompilerGenerated]
	private void method_68()
	{
		zoneUpdateDelegate_0("");
	}

	[CompilerGenerated]
	private void method_69(object object_3, uint uint_4)
	{
		ConnectionClosed(method_46());
	}

	[CompilerGenerated]
	private void method_70(object sender, ByteArrayMessageEventArgs e)
	{
		Connection connection_ = method_46();
		PacketHeader packetHeader_ = new PacketHeader();
		method_49(packetHeader_, connection_, e.Message);
	}
}
