using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Command_Core.LoadSave;
using Command_Core.Lua;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using CSMaterial;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using ObservableCollections;
using ThreadSafeCollections;

namespace Command_Core;

[Serializable]
public sealed class Scenario
{
	public delegate void TitleChangedEventHandler(Scenario theScen, string NewTitle);

	public delegate void CurrentScenarioChangedEventHandler(Scenario theNewScen);

	public delegate void CurrentSideChangedEventHandler(Scenario theScen);

	public delegate void SidesChangedEventHandler(Scenario theScen, SideAdditionOrRemoval AddOrRemove);

	public delegate void TimeCompressionChangedEventHandler();

	public delegate void TimeChangedManuallyEventHandler(Scenario theScen, DateTime NewTime);

	public delegate void NewMessageEventHandler(LoggedMessage theM);

	public delegate void UnitAddedEventHandler(Scenario theScen, string theUnitObjectID);

	public delegate void UnitRemovedEventHandler(Scenario theScen, ActiveUnit theUnit);

	public delegate void EventTriggersChangedEventHandler(Scenario theScen);

	public delegate void EventConditionsChangedEventHandler(Scenario theScen);

	public delegate void EventActionsChangedEventHandler(Scenario theScen);

	public delegate void ScenAttachmentsChangedEventHandler();

	public delegate void ScenCompletedEventHandler(Scenario theScen);

	public delegate void UnitSideChangedEventHandler(Scenario theSCen, string theUnitObjectID, string theOldSideID);

	public enum enumTimeCompression : byte
	{
		OneSec,
		TwoSec,
		FiveSec,
		FifteenSec,
		Coarse_OneSecSlice,
		Coarse_FiveSecSlice
	}

	public enum ScenarioFeatureOption
	{
		None = 0,
		DetailedGunFireControl = 1,
		UnlimitedBaseMagazines = 2,
		AircraftDamage = 3,
		CommsJamming = 5,
		CommsDisruption = 6,
		RealisticSubComms = 12,
		LandTypeEffects = 13,
		FixedSideColors = 14,
		WeatherAffectsShipSpeed = 15,
		AllowLandingPlannerInstantLoading = 16,
		LandTypeEffects_Advanced = 17,
		ACS_NAW_Limitations = 18,
		DroneAutonomyLevels = 19,
		ASCMTerrainFollowingRestriction = 20,
		PointToPointComm = 21,
		RealisticOrderChain = 22,
		VariableBurnoutSpeed = 23,
		LimitedSonobuoysInMagazines = 24
	}

	public enum SideAdditionOrRemoval : byte
	{
		Addition,
		Removal
	}

	public enum WeatherModellingLevel : byte
	{
		Level0,
		Level1
	}

	public struct _FeatureCompatibility
	{
		private bool? nullable_0;

		private bool? nullable_1;

		private bool? nullable_2;

		private bool? nullable_3;

		private bool? nullable_4;

		private bool? nullable_5;

		private bool? nullable_6;

		private bool? nullable_7;

		[CompilerGenerated]
		private bool bool_0;

		public bool Hypotheticals
		{
			get
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = DBFunctions.CheckFeatureCompatibility(0, theConn);
				}
				return nullable_0.Value;
			}
		}

		public bool CarrierCapableFlag
		{
			get
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = DBFunctions.CheckFeatureCompatibility(1, theConn);
				}
				return nullable_1.Value;
			}
		}

		public bool WRA
		{
			get
			{
				if (!nullable_2.HasValue)
				{
					nullable_2 = DBFunctions.CheckFeatureCompatibility(2, theConn);
				}
				return nullable_2.Value;
			}
		}

		public bool LPI_Radars
		{
			get
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = DBFunctions.CheckFeatureCompatibility(3, theConn);
				}
				return nullable_3.Value;
			}
		}

		public bool WeaponSnapUpDown
		{
			get
			{
				if (!nullable_4.HasValue)
				{
					nullable_4 = DBFunctions.CheckFeatureCompatibility(4, theConn);
				}
				return nullable_4.Value;
			}
		}

		public bool WeaponAGL_ASL
		{
			get
			{
				if (!nullable_5.HasValue)
				{
					nullable_5 = DBFunctions.CheckFeatureCompatibility(5, theConn);
				}
				return nullable_5.Value;
			}
		}

		public bool RevisedSubOptics
		{
			get
			{
				if (!nullable_6.HasValue)
				{
					nullable_6 = DBFunctions.CheckFeatureCompatibility(7, theConn);
				}
				return nullable_6.Value;
			}
		}

		public bool GuidedWeaponsPitchAttitude => false;

		public bool CockpitVisibility
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		static _FeatureCompatibility()
		{
			Class72.smethod_20();
		}
	}

	internal class NetworkContext
	{
		public readonly Side Side;

		public readonly List<ActiveUnit> AirBases;

		public readonly List<Aircraft> FlyingAircraft;

		public readonly List<Aircraft> AEWList;

		public readonly List<Aircraft> TankerList;

		public readonly List<Ship> ShipList;

		public readonly List<Submarine> SubList;

		public readonly List<Vehicle> VehicleList;

		public readonly List<Group> Groups;

		public NetworkContext(Side theSide)
		{
			Side = theSide;
			AirBases = new List<ActiveUnit>();
			FlyingAircraft = new List<Aircraft>();
			AEWList = new List<Aircraft>();
			TankerList = new List<Aircraft>();
			ShipList = new List<Ship>();
			SubList = new List<Submarine>();
			VehicleList = new List<Vehicle>();
			Groups = new List<Group>();
		}

		static NetworkContext()
		{
			Class72.smethod_20();
		}
	}

	internal class NetworkLog
	{
		public readonly ActiveUnit Unit;

		public readonly CommNetwork.NetworkCreationReason Reason;

		public readonly string Detail;

		public readonly DateTime Timestamp;

		public NetworkLog(ActiveUnit unit, CommNetwork.NetworkCreationReason reason, string detail)
		{
			Unit = unit;
			Reason = reason;
			Detail = detail;
			Timestamp = DateTime.UtcNow;
		}

		public override string ToString()
		{
			return $"[{Timestamp:HH:mm:ss.fff}] {Unit.Name} -> {Reason} ({Detail})";
		}

		static NetworkLog()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__322-0
	{
		public List<XmlNode> $VB$Local_theList_Groups;

		public ActiveUnit[] $VB$Local_theArray_Groups;

		public _Closure$__322-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__322-0(_Closure$__322-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theList_Groups = arg0.$VB$Local_theList_Groups;
				$VB$Local_theArray_Groups = arg0.$VB$Local_theArray_Groups;
			}
		}

		[SpecialName]
		internal void _Lambda$__1(int i)
		{
			XmlNode theNode = $VB$Local_theList_Groups[i];
			Group obj = Group.FromXML(ref theNode, ref $VB$NonLocal_$VB$Closure_3.$VB$Local_ObjectsDictionary, ref $VB$NonLocal_$VB$Closure_3.$VB$Local_theScen);
			$VB$Local_theArray_Groups[i] = obj;
			$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated++;
			$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated / (double)$VB$NonLocal_$VB$Closure_3.$VB$Local_TotalItems);
		}

		static _Closure$__322-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__322-1
	{
		public ConcurrentDictionary<string, ScenarioObject> $VB$Local_ObjectsDictionary;

		public Scenario $VB$Local_theScen;

		public int $VB$Local_ItemsInstantiated;

		public int $VB$Local_TotalItems;

		public _Closure$__322-2 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__322-1(_Closure$__322-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ObjectsDictionary = arg0.$VB$Local_ObjectsDictionary;
				$VB$Local_theScen = arg0.$VB$Local_theScen;
				$VB$Local_ItemsInstantiated = arg0.$VB$Local_ItemsInstantiated;
				$VB$Local_TotalItems = arg0.$VB$Local_TotalItems;
			}
		}

		static _Closure$__322-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__322-2
	{
		public Action<double> $VB$Local_PercentageComplete;

		public _Closure$__322-2(_Closure$__322-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PercentageComplete = arg0.$VB$Local_PercentageComplete;
			}
		}

		static _Closure$__322-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__322-3
	{
		public ActiveUnit $VB$Local_theAU;

		public Func<Module_Unit.Unit, bool> $I2;

		public _Closure$__322-3(_Closure$__322-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Module_Unit.Unit member)
		{
			return Operators.CompareString(member.ObjectID, $VB$Local_theAU.ObjectID, false) == 0;
		}

		static _Closure$__322-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__416-0
	{
		public Side $VB$Local_theNewM_Side;

		public long $VB$Local_theNewM_TimeStamp_ticks;

		public string $VB$Local_theNewM_Text;

		public bool $VB$Local_AlreadyHaveMessage;

		public DateTime $VB$Local_theNewM_TimeStamp;

		public Scenario $VB$Me;

		public _Closure$__416-0(_Closure$__416-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNewM_Side = arg0.$VB$Local_theNewM_Side;
				$VB$Local_theNewM_TimeStamp_ticks = arg0.$VB$Local_theNewM_TimeStamp_ticks;
				$VB$Local_theNewM_Text = arg0.$VB$Local_theNewM_Text;
				$VB$Local_AlreadyHaveMessage = arg0.$VB$Local_AlreadyHaveMessage;
				$VB$Local_theNewM_TimeStamp = arg0.$VB$Local_theNewM_TimeStamp;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(LoggedMessage theLM, ParallelLoopState loopstate)
		{
			if (!$VB$Me.CurrentlyInsertingMessages)
			{
				loopstate.Stop();
			}
			else if (theLM != null && theLM.Side != null && theLM.Side == $VB$Local_theNewM_Side && theLM.Timestamp_ticks == $VB$Local_theNewM_TimeStamp_ticks && string.CompareOrdinal(theLM.Text, $VB$Local_theNewM_Text) == 0)
			{
				$VB$Local_AlreadyHaveMessage = true;
				loopstate.Stop();
			}
		}

		static _Closure$__416-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__416-1
	{
		public Side $VB$Local_ASide;

		public _Closure$__416-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__416-1(_Closure$__416-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ASide = arg0.$VB$Local_ASide;
			}
		}

		static _Closure$__416-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__416-2
	{
		public bool $VB$Local_AlreadyHaveMessage2;

		public _Closure$__416-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__416-2(_Closure$__416-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AlreadyHaveMessage2 = arg0.$VB$Local_AlreadyHaveMessage2;
			}
		}

		[SpecialName]
		internal void _Lambda$__1(LoggedMessage theLM, ParallelLoopState loopstate)
		{
			if (theLM != null && theLM.Side != null && theLM.Side == $VB$NonLocal_$VB$Closure_3.$VB$Local_ASide && DateTime.Compare(theLM.Timestamp, $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theNewM_TimeStamp) == 0 && string.CompareOrdinal(theLM.Text, $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theNewM_Text) == 0)
			{
				$VB$Local_AlreadyHaveMessage2 = true;
				loopstate.Stop();
			}
		}

		static _Closure$__416-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-0
	{
		public Side $VB$Local_theSide;

		public _Closure$__475-0(_Closure$__475-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Side side_0)
		{
			return Operators.CompareString(side_0.ObjectID, $VB$Local_theSide.ObjectID, false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(Side side_0)
		{
			return Operators.CompareString(side_0.ObjectID, $VB$Local_theSide.ObjectID, false) == 0;
		}

		static _Closure$__475-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-1
	{
		public KeyValuePair<Side, Misc.PostureStance> $VB$Local_theKVP;

		public _Closure$__475-1(_Closure$__475-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theKVP = arg0.$VB$Local_theKVP;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(KeyValuePair<Side, Misc.PostureStance> keyValuePair_0)
		{
			return Operators.CompareString(keyValuePair_0.Key.ObjectID, $VB$Local_theKVP.Key.ObjectID, false) == 0;
		}

		static _Closure$__475-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-2
	{
		public ReferencePoint $VB$Local_SourceRP;

		public _Closure$__475-2(_Closure$__475-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SourceRP = arg0.$VB$Local_SourceRP;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint TargetRP)
		{
			return Operators.CompareString(TargetRP.ObjectID, $VB$Local_SourceRP.ObjectID, false) == 0;
		}

		static _Closure$__475-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-3
	{
		public ExclusionZone $VB$Local_SourceEZ;

		public _Closure$__475-3(_Closure$__475-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SourceEZ = arg0.$VB$Local_SourceEZ;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(ExclusionZone TargetEZ)
		{
			return Operators.CompareString(TargetEZ.ObjectID, $VB$Local_SourceEZ.ObjectID, false) == 0;
		}

		static _Closure$__475-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-4
	{
		public NoNavZone $VB$Local_SourceNNZ;

		public _Closure$__475-4(_Closure$__475-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SourceNNZ = arg0.$VB$Local_SourceNNZ;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(NoNavZone noNavZone_0)
		{
			return Operators.CompareString(noNavZone_0.ObjectID, $VB$Local_SourceNNZ.ObjectID, false) == 0;
		}

		static _Closure$__475-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-5
	{
		public Mission $VB$Local_SourceMission;

		public _Closure$__475-5(_Closure$__475-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SourceMission = arg0.$VB$Local_SourceMission;
			}
		}

		[SpecialName]
		internal bool _Lambda$__6(Mission TargetMission)
		{
			return Operators.CompareString(TargetMission.ObjectID, $VB$Local_SourceMission.ObjectID, false) == 0;
		}

		static _Closure$__475-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-6
	{
		public WeaponSalvo $VB$Local_SourceSalvo;

		public _Closure$__475-6(_Closure$__475-6 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SourceSalvo = arg0.$VB$Local_SourceSalvo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__7(WeaponSalvo TargetSalvo)
		{
			return Operators.CompareString(TargetSalvo.ObjectID, $VB$Local_SourceSalvo.ObjectID, false) == 0;
		}

		static _Closure$__475-6()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-7
	{
		public Explosion $VB$Local_theExplosion;

		public _Closure$__475-7(_Closure$__475-7 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theExplosion = arg0.$VB$Local_theExplosion;
			}
		}

		[SpecialName]
		internal bool _Lambda$__8(Explosion Scen1Explosion)
		{
			return Operators.CompareString(Scen1Explosion.ObjectID, $VB$Local_theExplosion.ObjectID, false) == 0;
		}

		static _Closure$__475-7()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-8
	{
		public WeaponImpact $VB$Local_theWI;

		public _Closure$__475-8(_Closure$__475-8 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWI = arg0.$VB$Local_theWI;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(WeaponImpact weaponImpact_0)
		{
			return Operators.CompareString(weaponImpact_0.ObjectID, $VB$Local_theWI.ObjectID, false) == 0;
		}

		static _Closure$__475-8()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__475-9
	{
		public ChaffCorridorCloud $VB$Local_theCloud;

		public _Closure$__475-9(_Closure$__475-9 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theCloud = arg0.$VB$Local_theCloud;
			}
		}

		[SpecialName]
		internal bool _Lambda$__10(ChaffCorridorCloud chaffCorridorCloud_0)
		{
			return Operators.CompareString(chaffCorridorCloud_0.ObjectID, $VB$Local_theCloud.ObjectID, false) == 0;
		}

		static _Closure$__475-9()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__494-0
	{
		public ActiveUnit $VB$Local_theUnit;

		public Func<Aircraft, float> $I0;

		public Func<Aircraft, float> $I1;

		public _Closure$__494-0(_Closure$__494-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(Aircraft theHUB)
		{
			return Math2.CalcDist(theHUB, $VB$Local_theUnit);
		}

		[SpecialName]
		internal float _Lambda$__1(Aircraft theHUB)
		{
			return Math2.CalcDist(theHUB, $VB$Local_theUnit);
		}

		static _Closure$__494-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__495-0
	{
		public ActiveUnit $VB$Local_theUnit;

		public _Closure$__495-0(_Closure$__495-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theOtherAU)
		{
			if (Operators.CompareString(theOtherAU.ObjectID, $VB$Local_theUnit.ObjectID, false) == 0)
			{
				return false;
			}
			return theOtherAU.Comms_ReadOnly.Count() > 0;
		}

		[SpecialName]
		internal float _Lambda$__1(ActiveUnit theOtherAU)
		{
			return Math2.CalcDist($VB$Local_theUnit, theOtherAU);
		}

		static _Closure$__495-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__498-0
	{
		public NetworkRuleExecutionContext $VB$Local_execCtx;

		public Scenario $VB$Me;

		public _Closure$__498-0(_Closure$__498-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_execCtx = arg0.$VB$Local_execCtx;
			}
		}

		[SpecialName]
		internal string _Lambda$__0(string script)
		{
			return $VB$Me.method_28(script, $VB$Local_execCtx);
		}

		static _Closure$__498-0()
		{
			Class72.smethod_20();
		}
	}

	public string TimelineID;

	public string ParentTimelineID;

	public int MonteCarloIteration;

	private string string_0;

	public string ContentTag;

	public string CampaignID;

	public string CampaignSessionID;

	public int CampaignScore;

	public bool RunningHeadless;

	public bool RunningInRTMPHost;

	private string string_1;

	private string string_2;

	private string string_3;

	public short Meta_Complexity;

	public short Meta_Difficulty;

	public string Meta_ScenSetting;

	public string FileName;

	public string FileNamePath;

	private DateTime dateTime_0;

	public DateTime? TimeToHalt;

	public DateTime ZeroHour;

	private bool bool_0;

	private string string_4;

	private string string_5;

	private DateTime? nullable_0;

	private TimeSpan? nullable_1;

	private bool bool_1;

	[AccessedThroughProperty("ActiveUnits")]
	[CompilerGenerated]
	private ConcurrentObservableDictionary<string, ActiveUnit> concurrentObservableDictionary_0;

	public LockObject ActiveUnitsSyncLock;

	private PooledList<ActiveUnit> pooledList_0;

	public TList<Group> Groups;

	private PooledList<Weapon> pooledList_1;

	private List<Weapon> list_0;

	private List<Weapon> list_1;

	private List<Weapon> list_2;

	private enumTimeCompression enumTimeCompression_0;

	private float float_0;

	private Side[] side_0;

	private HashSet<ActiveUnit> hashSet_0;

	private List<UnguidedWeapon> list_3;

	private List<ActiveUnit> list_4;

	public int UnitsAutoIncrement;

	private Side side_1;

	public string GameVersion;

	private bool bool_2;

	public bool SerializationInProgress;

	public float Navigation_FinegrainedThresholdDistance;

	public float Navigation_FinegrainedMaxDistance;

	public Doctrine._WRA_FiringRange DefaultGuidedWeaponsVsAirTargetWRASetting;

	[AccessedThroughProperty("ScenAttachments")]
	[CompilerGenerated]
	private System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject> observableDictionary_0;

	public Queue<LoggedMessage> UnhandledPopUpMessages;

	public List<LoggedMessage> MessageLog;

	private ConcurrentQueue<LoggedMessage> concurrentQueue_0;

	private long long_0;

	internal string MessageLogFilePath;

	private string string_6;

	private bool? nullable_2;

	private bool? nullable_3;

	private SQLiteConnection sqliteConnection_0;

	public bool LoadStockUnits;

	private List<ActiveUnit> list_5;

	private List<ActiveUnit> list_6;

	internal HashSet<XmlNode> UnitsForLateInstantiation;

	public bool SecondIsChangingOnThisPulse;

	public float ElapsedTimeSinceLastSecondChangeCheck;

	public bool FifthSecondIsChangingOnThisPulse;

	public bool FifteenthSecondIsChangingOnThisPulse;

	public bool ThirtiethSecondIsChangingOnThisPulse;

	public bool MinuteIsChangingOnThisPulse;

	public bool FifthMinuteIsChangingOnThisPulse;

	public bool FifteenthMinuteIsChangingOnThisPulse;

	public bool ThirtiethMinuteIsChangingOnThisPulse;

	public bool HourIsChangingOnThisPulse;

	public bool SixHourIsChangingOnThisPulse;

	public bool TwelveHourIsChangingOnThisPulse;

	public bool TwentyFourHourIsChangingOnThisPulse;

	internal ActiveUnit[] Cache_FacilitiesWithPiers;

	public ConcurrentDictionary<int, Weapon> Cache_Weapons;

	public ConcurrentDictionary<int, Sensor> Cache_Sensors;

	internal ConcurrentDictionary<long, bool> Cache_SensorCompatibleFrequencies;

	internal ConcurrentDictionary<string, XSection[]> Cache_XSections;

	internal ConcurrentDictionary<ActiveUnit, bool> Cache_UnitsAffectedByJamming;

	internal ConcurrentDictionary<int, double> Cache_RocketThrusts;

	public bool AllowTimescale1XMessageSetting;

	public RoadSystem RoadSystem;

	public Dictionary<int, Facility.FacilityType> FacilityTypeDictionary;

	internal ConcurrentDictionary<int, int> Cache_FuelForPitchEnabledWeapons;

	internal ConcurrentDictionary<int, (int BurnTime, int FlightEndurance)> Cache_BurnTimesForBoostCoastWeapons;

	public Weather.TTimeOfDayType[][] Cache_TimeOfDay;

	internal ConcurrentDictionary<int, Sensor> Cache_AssociatedSensors;

	internal ConcurrentDictionary<int, AltBand[]> Cache_PowerplantAltBands;

	internal TDictionary<string, List<Platform>> Cache_PrimaryTargetForWhichPlatforms;

	public HashSet<int> Cache_DisabledLoadouts;

	internal ConcurrentDictionary<int, Doctrine.WRA_FiringDoctrineEntry> Cache_WRA_FiringDoctrineEntry_SystemDefault;

	internal ConcurrentDictionary<ulong, int?> Cache_WRA_WeaponQty_SystemDefault;

	internal ConcurrentPagedArray<Weapon._WeaponType> Cache_WeaponTypes;

	internal LockedDictionary<(ActiveUnit theUnit, Contact theContact, float ContactLocalAgeThreshold_sec, Sensor.Sensor_Type SpecificSensorType), bool> Cache_UnitLocalTracksOnContacts;

	internal JaggedConcurrentMap<int> Cache_WeaponMaxSpeedsPerAltitude;

	internal ConcurrentPagedArray<bool> Cache_WeaponIsABMOptimized;

	internal ConcurrentPagedArray<bool> Cache_WeaponIsABMCapable;

	internal List<ActiveUnit> CandidatesForDetectionByMines;

	public List<string> LoadingNotices;

	internal bool ThreadedOpsMustStop;

	public HashSet<ScenarioFeatureOption> DeclaredFeatures;

	public bool LastSavedInScenEdit;

	public _FeatureCompatibility FeatureCompatibility;

	public int? MaxRisingMineRange_meters;

	private LuaSandBox luaSandBox_0;

	public bool UIRefreshTrigger;

	public bool CurrentlyInsertingMessages;

	internal EventWaitHandle EventWaitHandle_FinishPulse;

	public WeatherModellingLevel WeatherLevel;

	internal Weather.WeatherProfile GlobalWeather;

	public TList<MDSP_Error> MissionPlannerErrorList;

	[CompilerGenerated]
	[AccessedThroughProperty("EventTriggers")]
	private ConcurrentObservableDictionary<string, EventTrigger> concurrentObservableDictionary_1;

	[CompilerGenerated]
	[AccessedThroughProperty("EventConditions")]
	private ConcurrentObservableDictionary<string, EventCondition> concurrentObservableDictionary_2;

	[CompilerGenerated]
	[AccessedThroughProperty("EventActions")]
	private ConcurrentObservableDictionary<string, EventAction> concurrentObservableDictionary_3;

	[AccessedThroughProperty("SimEvents")]
	[CompilerGenerated]
	private ConcurrentObservableDictionary<string, SimEvent> concurrentObservableDictionary_4;

	[CompilerGenerated]
	[AccessedThroughProperty("Explosions")]
	private ObservableList<Explosion> observableList_0;

	private List<Explosion> list_7;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponImpacts")]
	private ObservableList<WeaponImpact> observableList_1;

	[CompilerGenerated]
	[AccessedThroughProperty("WaterSplashes")]
	private ObservableList<WaterSplash> observableList_2;

	[AccessedThroughProperty("GroundImpacts")]
	[CompilerGenerated]
	private ObservableList<GroundImpact> observableList_3;

	[AccessedThroughProperty("UnguidedWeapons")]
	[CompilerGenerated]
	private ConcurrentObservableDictionary<string, UnguidedWeapon> concurrentObservableDictionary_5;

	public List<UnguidedWeapon> Mines;

	public System.Collections.ObjectModel.ObservableDictionary<string, UnguidedWeapon> MineAllocation;

	public List<ChaffCorridorCloud> ChaffClouds;

	public ConcurrentHashSet<Side> UnitAutodetectionValidation;

	[CompilerGenerated]
	private static TitleChangedEventHandler titleChangedEventHandler_0;

	[CompilerGenerated]
	private static CurrentScenarioChangedEventHandler currentScenarioChangedEventHandler_0;

	[CompilerGenerated]
	private static CurrentSideChangedEventHandler currentSideChangedEventHandler_0;

	[CompilerGenerated]
	private static SidesChangedEventHandler sidesChangedEventHandler_0;

	[CompilerGenerated]
	private static TimeCompressionChangedEventHandler timeCompressionChangedEventHandler_0;

	[CompilerGenerated]
	private static TimeChangedManuallyEventHandler timeChangedManuallyEventHandler_0;

	[CompilerGenerated]
	private static NewMessageEventHandler newMessageEventHandler_0;

	[CompilerGenerated]
	private static UnitAddedEventHandler unitAddedEventHandler_0;

	[CompilerGenerated]
	private static UnitRemovedEventHandler unitRemovedEventHandler_0;

	[CompilerGenerated]
	private static EventTriggersChangedEventHandler eventTriggersChangedEventHandler_0;

	[CompilerGenerated]
	private static EventConditionsChangedEventHandler eventConditionsChangedEventHandler_0;

	[CompilerGenerated]
	private static EventActionsChangedEventHandler eventActionsChangedEventHandler_0;

	[CompilerGenerated]
	private static ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler_0;

	[CompilerGenerated]
	private static ScenCompletedEventHandler scenCompletedEventHandler_0;

	[CompilerGenerated]
	private static UnitSideChangedEventHandler unitSideChangedEventHandler_0;

	public string LuaXml;

	public string LuaXmlPassed;

	public static List<(string, CargoTracker)> CargoMovement;

	public bool AnyActiveWeaponEffectThreats;

	private LockObject lockObject_0;

	private LockObject lockObject_1;

	public Game _GameContext;

	public bool DEBUG_DiscriminateResolutionAndCompression;

	public float? DEBUG_CustomResolution;

	public enumTimeCompression? DEBUG_CustomCompression;

	public bool HasBeenReleased;

	public static ConcurrentDictionary<(float, double, float), (float, double)> NEZ_DLZ_Cache;

	public bool _LockFidelityResolution;

	private LockObject lockObject_2;

	private LockObject lockObject_3;

	[CompilerGenerated]
	private LockObject lockObject_4;

	private LockObject lockObject_5;

	private PooledList<PooledList<ActiveUnit>> pooledList_2;

	private LockObject lockObject_6;

	internal List<string> WeaponFeedBackMessage;

	internal List<Aircraft> list_8;

	internal List<AreaValidatedObjects> AreaAlreadyValidated;

	public int LastTransmissionId;

	[CompilerGenerated]
	private Dictionary<int, string> dictionary_0;

	public virtual ConcurrentObservableDictionary<string, ActiveUnit> ActiveUnits
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, ActiveUnit>> value2 = method_14;
			ConcurrentObservableDictionary<string, ActiveUnit> concurrentObservableDictionary = concurrentObservableDictionary_0;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged -= value2;
			}
			concurrentObservableDictionary_0 = value;
			concurrentObservableDictionary = concurrentObservableDictionary_0;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public virtual System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject> ScenAttachments
	{
		[CompilerGenerated]
		get
		{
			return observableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, ScenAttachmentObject>.DictionaryChangedEventHandler obj = method_10;
			System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject> observableDictionary = observableDictionary_0;
			if (observableDictionary != null)
			{
				observableDictionary.DictionaryChanged -= obj;
			}
			observableDictionary_0 = value;
			observableDictionary = observableDictionary_0;
			if (observableDictionary != null)
			{
				observableDictionary.DictionaryChanged += obj;
			}
		}
	}

	public bool GenerateAutoDetectableUnitsOnThisPulse => SecondIsChangingOnThisPulse;

	public string FullFilePath
	{
		get
		{
			if (!string.IsNullOrEmpty(FileNamePath) && !string.IsNullOrEmpty(FileName))
			{
				return Path.Combine(FileNamePath, FileName);
			}
			return "";
		}
	}

	public bool ExecutionInProgress
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

	public DataTable Cache_Aircraft_DT => DBFunctions.CurrentDatabaseCache.Cache_Aircraft_DT;

	public DataTable Cache_Ships_DT => DBFunctions.CurrentDatabaseCache.Cache_Ships_DT;

	public DataTable Cache_Subs_DT => DBFunctions.CurrentDatabaseCache.Cache_Subs_DT;

	public DataTable Cache_Facilities_DT => DBFunctions.CurrentDatabaseCache.Cache_Facilities_DT;

	public DataTable Cache_GroundUnits_DT => DBFunctions.CurrentDatabaseCache.Cache_GroundUnits_DT;

	public DataTable Cache_Satellites_DT => DBFunctions.CurrentDatabaseCache.Cache_Satellites_DT;

	public DataTable Cache_Weapons_DT => DBFunctions.CurrentDatabaseCache.Cache_Weapons_DT;

	public DataTable Cache_OperatorCountries_DT => DBFunctions.CurrentDatabaseCache.Cache_OperatorCountries_DT;

	public ConcurrentDictionary<string, HashSet<int>> Cache_AllPossibleEmissionsPerUnit => DBFunctions.CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit;

	public virtual ConcurrentObservableDictionary<string, EventTrigger> EventTriggers
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventTrigger>> value2 = method_15;
			ConcurrentObservableDictionary<string, EventTrigger> concurrentObservableDictionary = concurrentObservableDictionary_1;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged -= value2;
			}
			concurrentObservableDictionary_1 = value;
			concurrentObservableDictionary = concurrentObservableDictionary_1;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public virtual ConcurrentObservableDictionary<string, EventCondition> EventConditions
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventCondition>> value2 = method_16;
			ConcurrentObservableDictionary<string, EventCondition> concurrentObservableDictionary = concurrentObservableDictionary_2;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged -= value2;
			}
			concurrentObservableDictionary_2 = value;
			concurrentObservableDictionary = concurrentObservableDictionary_2;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public virtual ConcurrentObservableDictionary<string, EventAction> EventActions
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventAction>> value2 = method_17;
			ConcurrentObservableDictionary<string, EventAction> concurrentObservableDictionary = concurrentObservableDictionary_3;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged -= value2;
			}
			concurrentObservableDictionary_3 = value;
			concurrentObservableDictionary = concurrentObservableDictionary_3;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public virtual ConcurrentObservableDictionary<string, SimEvent> SimEvents
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_4;
		}
		[CompilerGenerated]
		set
		{
			concurrentObservableDictionary_4 = value;
		}
	}

	public virtual ObservableList<Explosion> Explosions
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Explosion>> value2 = method_13;
			ObservableList<Explosion> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
			}
		}
	}

	public virtual ObservableList<WeaponImpact> WeaponImpacts
	{
		[CompilerGenerated]
		get
		{
			return observableList_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponImpact>> value2 = method_12;
			ObservableList<WeaponImpact> observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
			}
			observableList_1 = value;
			observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
			}
		}
	}

	public virtual ObservableList<WaterSplash> WaterSplashes
	{
		[CompilerGenerated]
		get
		{
			return observableList_2;
		}
		[CompilerGenerated]
		set
		{
			observableList_2 = value;
		}
	}

	public virtual ObservableList<GroundImpact> GroundImpacts
	{
		[CompilerGenerated]
		get
		{
			return observableList_3;
		}
		[CompilerGenerated]
		set
		{
			observableList_3 = value;
		}
	}

	public virtual ConcurrentObservableDictionary<string, UnguidedWeapon> UnguidedWeapons
	{
		[CompilerGenerated]
		get
		{
			return concurrentObservableDictionary_5;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, UnguidedWeapon>> value2 = method_8;
			ConcurrentObservableDictionary<string, UnguidedWeapon> concurrentObservableDictionary = concurrentObservableDictionary_5;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged -= value2;
			}
			concurrentObservableDictionary_5 = value;
			concurrentObservableDictionary = concurrentObservableDictionary_5;
			if (concurrentObservableDictionary != null)
			{
				concurrentObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public LockObject writing
	{
		[CompilerGenerated]
		get
		{
			return lockObject_4;
		}
		[CompilerGenerated]
		set
		{
			lockObject_4 = value;
		}
	}

	public bool LockFidelityResolution
	{
		get
		{
			return _LockFidelityResolution;
		}
		set
		{
			TimeCompression_Set(enumTimeCompression.Coarse_OneSecSlice);
			string messageText = "Unchanged state";
			if (LockFidelityResolution && !value)
			{
				messageText = "Locked -> Unlocked";
			}
			else if (!LockFidelityResolution && value)
			{
				messageText = "Unlocked -> Locked";
			}
			AddMessage(messageText, "Simulation resolution Lock", LoggedMessage.MessageType.SpecialMessage, 1, "");
			_LockFidelityResolution = value;
		}
	}

	public Game GameContext
	{
		get
		{
			if (_GameContext == null)
			{
				_GameContext = new Game();
			}
			return _GameContext;
		}
		set
		{
			_GameContext = value;
		}
	}

	public string Title
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			titleChangedEventHandler_0?.Invoke(this, value);
		}
	}

	public string ObjectID
	{
		get
		{
			if (string.IsNullOrEmpty(string_0))
			{
				string_0 = Guid.NewGuid().ToString();
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string Description
	{
		get
		{
			if (!string.IsNullOrEmpty(string_3))
			{
				if (!string.IsNullOrEmpty(string_3))
				{
					return Crypto.DecryptStringAES(string_3, "DaltonTrumbo");
				}
				return string.Empty;
			}
			return string_2;
		}
		set
		{
			string_2 = string.Empty;
			if (!string.IsNullOrEmpty(value))
			{
				string_3 = Crypto.EncryptStringAES(value, "DaltonTrumbo");
			}
			else
			{
				string_3 = value;
			}
		}
	}

	public IEventExporter[] ApplicableEventExporters => Exporter_General.EventExporters_Interactive;

	public string DBUsed
	{
		get
		{
			return string_6;
		}
		set
		{
			int num;
			bool flag;
			if (string.IsNullOrEmpty(string_6))
			{
				num = 1;
			}
			else
			{
				if (!string.IsNullOrEmpty(value))
				{
					flag = Operators.CompareString(value, string_6, false) != 0;
					goto IL_002d;
				}
				num = 1;
			}
			flag = (byte)num != 0;
			goto IL_002d;
			IL_002d:
			string_6 = value;
			if (flag)
			{
				sqliteConnection_0 = null;
				GameGeneral.Debug_LastLoadedDB = value;
				if (DBConnection != null)
				{
					DBFunctions.CurrentDatabaseCache.BuildCache(string_6, DBConnection);
				}
			}
		}
	}

	public bool IsDBUsedCWDB
	{
		get
		{
			bool result;
			try
			{
				if (!nullable_2.HasValue)
				{
					DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
					DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(DBUsed, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
					nullable_2 = dBRecordByHash.DBID == 2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 854929267518567", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
				goto IL_0082;
			}
			result = nullable_2.Value;
			goto IL_0082;
			IL_0082:
			return result;
		}
	}

	public bool IsDBUsedDB3K
	{
		get
		{
			bool result;
			try
			{
				if (!nullable_3.HasValue)
				{
					DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
					DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(DBUsed, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
					nullable_3 = dBRecordByHash.DBID == 1;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 854929267518567B", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 0;
				}
				else
				{
					Debugger.Break();
					num = 0;
				}
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
				goto IL_0084;
			}
			result = nullable_3.Value;
			goto IL_0084;
			IL_0084:
			return result;
		}
	}

	public LuaSandBox Scenario_LuaSandbox
	{
		get
		{
			if (Information.IsNothing((object)luaSandBox_0))
			{
				if (LuaSandBox.Singleton() != null)
				{
					luaSandBox_0 = LuaSandBox.Singleton();
				}
				else
				{
					luaSandBox_0 = new LuaSandBox();
				}
			}
			return luaSandBox_0;
		}
		set
		{
			luaSandBox_0 = value;
		}
	}

	public bool IsRunningInCampaignMode
	{
		get
		{
			if (string.IsNullOrEmpty(CampaignID))
			{
				return false;
			}
			return !string.IsNullOrEmpty(CampaignSessionID);
		}
	}

	public PooledList<Weapon> GuidedWeaponsInAir
	{
		get
		{
			PooledList<Weapon> result;
			try
			{
				if (pooledList_1 == null || list_1 == null || list_2 == null)
				{
					lock (lockObject_5)
					{
						if (pooledList_1 == null || list_1 == null || list_2 == null)
						{
							PooledList<Weapon> guidedWeapons = new PooledList<Weapon>();
							List<Weapon> decoys = new List<Weapon>();
							List<Weapon> sonobuoys = new List<Weapon>();
							List<Weapon> allWeapons = new List<Weapon>();
							PooledList<ActiveUnit> pooledList;
							for (pooledList = null; pooledList == null; pooledList = ActiveUnits_List)
							{
							}
							if (pooledList != null)
							{
								int count = pooledList.Count;
								ActiveUnit[] array = pooledList.InternalArray();
								ActiveUnit activeUnit = null;
								int num = count - 1;
								for (int i = 0; i <= num; i++)
								{
									try
									{
										activeUnit = array[i];
									}
									catch (Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
										continue;
									}
									if (activeUnit != null)
									{
										AddToWeaponLists(activeUnit, allWeapons, guidedWeapons, decoys, sonobuoys);
									}
								}
								pooledList_1 = guidedWeapons;
								list_0 = decoys;
								list_1 = sonobuoys;
								list_2 = allWeapons;
							}
						}
					}
				}
				result = pooledList_1;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101026", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = pooledList_1;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			pooledList_1 = value;
		}
	}

	public List<Weapon> MobileDecoysActive
	{
		get
		{
			List<Weapon> result;
			try
			{
				if (list_0 == null)
				{
					_ = GuidedWeaponsInAir;
				}
				result = list_0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101274", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = list_0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			list_0 = value;
		}
	}

	public List<Weapon> SonobuoysInWater
	{
		get
		{
			List<Weapon> result;
			try
			{
				if (list_1 == null)
				{
					_ = GuidedWeaponsInAir;
				}
				result = list_1;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101274", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = list_1;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			list_1 = value;
		}
	}

	public List<Weapon> AllWeaponsAlive
	{
		get
		{
			List<Weapon> result;
			try
			{
				if (list_2 == null)
				{
					_ = GuidedWeaponsInAir;
				}
				result = list_2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101275", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = list_2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			list_2 = value;
		}
	}

	public bool HasEnded => bool_1;

	public bool HasStarted => DateTime.Compare(this.Time, StartTime) > 0;

	public DateTime StartTime
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				nullable_0 = this.Time;
			}
			return nullable_0.Value;
		}
		set
		{
			nullable_0 = value;
		}
	}

	public TimeSpan Duration
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				nullable_1 = new TimeSpan(24, 0, 0);
			}
			return nullable_1.Value;
		}
		set
		{
			nullable_1 = value;
		}
	}

	public DateTime Time => dateTime_0;

	public DateTime Time
	{
		set
		{
			try
			{
				if (enumTimeCompression_0 > enumTimeCompression.FifteenSec && float_0 >= 1f)
				{
					SecondIsChangingOnThisPulse = true;
				}
				else if (dateTime_0.Second == value.Second)
				{
					SecondIsChangingOnThisPulse = false;
				}
				else
				{
					SecondIsChangingOnThisPulse = true;
				}
				FifthSecondIsChangingOnThisPulse = false;
				FifteenthSecondIsChangingOnThisPulse = false;
				ThirtiethSecondIsChangingOnThisPulse = false;
				MinuteIsChangingOnThisPulse = false;
				FifthMinuteIsChangingOnThisPulse = false;
				FifteenthMinuteIsChangingOnThisPulse = false;
				ThirtiethMinuteIsChangingOnThisPulse = false;
				HourIsChangingOnThisPulse = false;
				SixHourIsChangingOnThisPulse = false;
				TwelveHourIsChangingOnThisPulse = false;
				TwentyFourHourIsChangingOnThisPulse = false;
				if (SecondIsChangingOnThisPulse)
				{
					if (float_0 > 1f)
					{
						ElapsedTimeSinceLastSecondChangeCheck = float_0;
					}
					else
					{
						ElapsedTimeSinceLastSecondChangeCheck = 1f;
					}
					if (value.Second % 5 == 0)
					{
						FifthSecondIsChangingOnThisPulse = true;
						if (value.Second % 15 == 0)
						{
							FifteenthSecondIsChangingOnThisPulse = true;
							if (value.Second % 30 == 0)
							{
								ThirtiethSecondIsChangingOnThisPulse = true;
								if (value.Second % 60 == 0)
								{
									MinuteIsChangingOnThisPulse = true;
									if (value.Minute % 5 == 0)
									{
										FifthMinuteIsChangingOnThisPulse = true;
										if (value.Minute % 15 == 0)
										{
											FifteenthMinuteIsChangingOnThisPulse = true;
											if (value.Minute % 30 == 0)
											{
												ThirtiethMinuteIsChangingOnThisPulse = true;
												if (dateTime_0.Hour != value.Hour)
												{
													HourIsChangingOnThisPulse = true;
												}
											}
										}
									}
								}
							}
						}
					}
					if (GameResolution > 1f)
					{
						List<DateTime> list = new List<DateTime>();
						int num = (int)Math.Round(GameResolution) - 1;
						for (int i = 1; i <= num; i++)
						{
							DateTime item = value.Subtract(new TimeSpan(0, 0, i));
							list.Add(item);
						}
						foreach (DateTime item2 in list)
						{
							if (item2.Second % 5 != 0)
							{
								continue;
							}
							FifthSecondIsChangingOnThisPulse = true;
							if (item2.Second % 15 != 0)
							{
								continue;
							}
							FifteenthSecondIsChangingOnThisPulse = true;
							if (item2.Second % 30 != 0)
							{
								continue;
							}
							ThirtiethSecondIsChangingOnThisPulse = true;
							if (item2.Second % 60 != 0)
							{
								continue;
							}
							MinuteIsChangingOnThisPulse = true;
							if (item2.Minute % 5 != 0)
							{
								continue;
							}
							FifthMinuteIsChangingOnThisPulse = true;
							if (item2.Minute % 15 != 0)
							{
								continue;
							}
							FifteenthMinuteIsChangingOnThisPulse = true;
							if (item2.Minute % 30 == 0)
							{
								ThirtiethMinuteIsChangingOnThisPulse = true;
								if (dateTime_0.Hour != item2.Hour)
								{
									HourIsChangingOnThisPulse = true;
								}
							}
						}
					}
				}
				TimeSpan timeSpan = value - StartTime;
				if (timeSpan.TotalHours > 0.0 && HourIsChangingOnThisPulse && (timeSpan.Hours % 6 == 0 || timeSpan.TotalHours % 6.0 == 0.0))
				{
					SixHourIsChangingOnThisPulse = true;
					if (timeSpan.Hours % 12 == 0 || timeSpan.TotalHours % 12.0 == 0.0)
					{
						TwelveHourIsChangingOnThisPulse = true;
						if (timeSpan.Hours % 24 == 0 || timeSpan.TotalHours % 24.0 == 0.0)
						{
							TwentyFourHourIsChangingOnThisPulse = true;
						}
					}
				}
				List<EventTrigger> list2 = new List<EventTrigger>();
				if (ManualChange)
				{
					timeChangedManuallyEventHandler_0?.Invoke(this, value);
				}
				else
				{
					foreach (EventTrigger value2 in EventTriggers.Values)
					{
						if (value2.Type == EventTrigger.EventTriggerType.Time && ((EventTrigger_Time)value2).get_IsFulfilled(value))
						{
							list2.Add(value2);
						}
						if (value2.Type == EventTrigger.EventTriggerType.RandomTime && ((EventTrigger_RandomTime)value2).get_IsFulfilled(value))
						{
							list2.Add(value2);
						}
						if (value2.Type == EventTrigger.EventTriggerType.RegularTime && ((EventTrigger_RegularTime)value2).get_IsFulfilled(this))
						{
							list2.Add(value2);
						}
					}
					if (SecondIsChangingOnThisPulse)
					{
						foreach (EventTrigger value3 in EventTriggers.Values)
						{
							if (value3.Type == EventTrigger.EventTriggerType.UnitEntersArea && ((EventTrigger_UnitEntersArea)value3).get_IsFulfilled(this))
							{
								list2.Add(value3);
							}
							if (value3.Type == EventTrigger.EventTriggerType.UnitRemainsInArea && ((EventTrigger_UnitRemainsInArea)value3).get_IsFulfilled(this, GameResolution))
							{
								list2.Add(value3);
							}
						}
					}
				}
				dateTime_0 = value;
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int j = 0; j < sides_ReadOnly.Length; j = checked(j + 1))
				{
					sides_ReadOnly[j].SalvoMaxDistanceToTargetList.Clear();
				}
				FireEvents(list2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101029", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool Use_DST
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

	public string DST_Start
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string DST_End
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public SQLiteConnection DBConnection
	{
		get
		{
			if (sqliteConnection_0 == null)
			{
				if (string.IsNullOrEmpty(DBUsed))
				{
					sqliteConnection_0 = null;
				}
				else
				{
					sqliteConnection_0 = new SQLiteConnection(DBOps.smethod_4(Application.StartupPath, DBUsed));
				}
			}
			return sqliteConnection_0;
		}
	}

	public float GameResolution
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

	public ActiveUnit[] ActiveUnits_List_As_Array_Theadsafe
	{
		get
		{
			ActiveUnit[] result;
			lock (lockObject_0)
			{
				try
				{
					result = ActiveUnits_List.InternalArray();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					result = ActiveUnits.Values.ToArray();
					ProjectData.ClearProjectError();
				}
			}
			return result;
		}
	}

	public PooledList<ActiveUnit> ActiveUnits_List
	{
		get
		{
			PooledList<ActiveUnit> result;
			try
			{
				if (pooledList_0 == null || (pooledList_0 != null && pooledList_0.Count != ActiveUnits.Count_NoLock()))
				{
					lock (lockObject_0)
					{
						if (pooledList_0 == null || pooledList_0.Count != ActiveUnits.Count)
						{
							PooledList<ActiveUnit> pooledList;
							lock (ActiveUnits)
							{
								pooledList = new PooledList<ActiveUnit>(ActiveUnits.Values);
							}
							pooledList_0 = pooledList;
						}
					}
				}
				result = pooledList_0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200053", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new PooledList<ActiveUnit>(ActiveUnits.Values);
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			lock (lockObject_0)
			{
				pooledList_0 = value;
			}
		}
	}

	public Side[] Sides_ReadOnly => side_0;

	public HashSet<ActiveUnit> NewbornUnits => hashSet_0;

	public List<UnguidedWeapon> MorituriUnguidedWeapons => list_3;

	public List<ActiveUnit> DeletedUnits => list_4;

	public int TimeCompression_SimSeconds => enumTimeCompression_0 switch
	{
		enumTimeCompression.OneSec => 1, 
		enumTimeCompression.TwoSec => 2, 
		enumTimeCompression.FiveSec => 5, 
		enumTimeCompression.FifteenSec => 15, 
		enumTimeCompression.Coarse_OneSecSlice => 30, 
		enumTimeCompression.Coarse_FiveSecSlice => 150, 
		_ => 1, 
	};

	public enumTimeCompression TimeCompression => enumTimeCompression_0;

	public long MessageIncrement => long_0;

	public Dictionary<int, string> CommDALError
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		set
		{
			dictionary_0 = value;
		}
	}

	public static event TitleChangedEventHandler TitleChanged
	{
		[CompilerGenerated]
		add
		{
			TitleChangedEventHandler titleChangedEventHandler = titleChangedEventHandler_0;
			TitleChangedEventHandler titleChangedEventHandler2;
			do
			{
				titleChangedEventHandler2 = titleChangedEventHandler;
				TitleChangedEventHandler value2 = (TitleChangedEventHandler)Delegate.Combine(titleChangedEventHandler2, value);
				titleChangedEventHandler = Interlocked.CompareExchange(ref titleChangedEventHandler_0, value2, titleChangedEventHandler2);
			}
			while ((object)titleChangedEventHandler != titleChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TitleChangedEventHandler titleChangedEventHandler = titleChangedEventHandler_0;
			TitleChangedEventHandler titleChangedEventHandler2;
			do
			{
				titleChangedEventHandler2 = titleChangedEventHandler;
				TitleChangedEventHandler value2 = (TitleChangedEventHandler)Delegate.Remove(titleChangedEventHandler2, value);
				titleChangedEventHandler = Interlocked.CompareExchange(ref titleChangedEventHandler_0, value2, titleChangedEventHandler2);
			}
			while ((object)titleChangedEventHandler != titleChangedEventHandler2);
		}
	}

	public static event CurrentScenarioChangedEventHandler CurrentScenarioChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentScenarioChangedEventHandler currentScenarioChangedEventHandler = currentScenarioChangedEventHandler_0;
			CurrentScenarioChangedEventHandler currentScenarioChangedEventHandler2;
			do
			{
				currentScenarioChangedEventHandler2 = currentScenarioChangedEventHandler;
				CurrentScenarioChangedEventHandler value2 = (CurrentScenarioChangedEventHandler)Delegate.Combine(currentScenarioChangedEventHandler2, value);
				currentScenarioChangedEventHandler = Interlocked.CompareExchange(ref currentScenarioChangedEventHandler_0, value2, currentScenarioChangedEventHandler2);
			}
			while ((object)currentScenarioChangedEventHandler != currentScenarioChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentScenarioChangedEventHandler currentScenarioChangedEventHandler = currentScenarioChangedEventHandler_0;
			CurrentScenarioChangedEventHandler currentScenarioChangedEventHandler2;
			do
			{
				currentScenarioChangedEventHandler2 = currentScenarioChangedEventHandler;
				CurrentScenarioChangedEventHandler value2 = (CurrentScenarioChangedEventHandler)Delegate.Remove(currentScenarioChangedEventHandler2, value);
				currentScenarioChangedEventHandler = Interlocked.CompareExchange(ref currentScenarioChangedEventHandler_0, value2, currentScenarioChangedEventHandler2);
			}
			while ((object)currentScenarioChangedEventHandler != currentScenarioChangedEventHandler2);
		}
	}

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

	public static event SidesChangedEventHandler SidesChanged
	{
		[CompilerGenerated]
		add
		{
			SidesChangedEventHandler sidesChangedEventHandler = sidesChangedEventHandler_0;
			SidesChangedEventHandler sidesChangedEventHandler2;
			do
			{
				sidesChangedEventHandler2 = sidesChangedEventHandler;
				SidesChangedEventHandler value2 = (SidesChangedEventHandler)Delegate.Combine(sidesChangedEventHandler2, value);
				sidesChangedEventHandler = Interlocked.CompareExchange(ref sidesChangedEventHandler_0, value2, sidesChangedEventHandler2);
			}
			while ((object)sidesChangedEventHandler != sidesChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SidesChangedEventHandler sidesChangedEventHandler = sidesChangedEventHandler_0;
			SidesChangedEventHandler sidesChangedEventHandler2;
			do
			{
				sidesChangedEventHandler2 = sidesChangedEventHandler;
				SidesChangedEventHandler value2 = (SidesChangedEventHandler)Delegate.Remove(sidesChangedEventHandler2, value);
				sidesChangedEventHandler = Interlocked.CompareExchange(ref sidesChangedEventHandler_0, value2, sidesChangedEventHandler2);
			}
			while ((object)sidesChangedEventHandler != sidesChangedEventHandler2);
		}
	}

	public static event TimeCompressionChangedEventHandler TimeCompressionChanged
	{
		[CompilerGenerated]
		add
		{
			TimeCompressionChangedEventHandler timeCompressionChangedEventHandler = timeCompressionChangedEventHandler_0;
			TimeCompressionChangedEventHandler timeCompressionChangedEventHandler2;
			do
			{
				timeCompressionChangedEventHandler2 = timeCompressionChangedEventHandler;
				TimeCompressionChangedEventHandler value2 = (TimeCompressionChangedEventHandler)Delegate.Combine(timeCompressionChangedEventHandler2, value);
				timeCompressionChangedEventHandler = Interlocked.CompareExchange(ref timeCompressionChangedEventHandler_0, value2, timeCompressionChangedEventHandler2);
			}
			while ((object)timeCompressionChangedEventHandler != timeCompressionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeCompressionChangedEventHandler timeCompressionChangedEventHandler = timeCompressionChangedEventHandler_0;
			TimeCompressionChangedEventHandler timeCompressionChangedEventHandler2;
			do
			{
				timeCompressionChangedEventHandler2 = timeCompressionChangedEventHandler;
				TimeCompressionChangedEventHandler value2 = (TimeCompressionChangedEventHandler)Delegate.Remove(timeCompressionChangedEventHandler2, value);
				timeCompressionChangedEventHandler = Interlocked.CompareExchange(ref timeCompressionChangedEventHandler_0, value2, timeCompressionChangedEventHandler2);
			}
			while ((object)timeCompressionChangedEventHandler != timeCompressionChangedEventHandler2);
		}
	}

	public static event TimeChangedManuallyEventHandler TimeChangedManually
	{
		[CompilerGenerated]
		add
		{
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler = timeChangedManuallyEventHandler_0;
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler2;
			do
			{
				timeChangedManuallyEventHandler2 = timeChangedManuallyEventHandler;
				TimeChangedManuallyEventHandler value2 = (TimeChangedManuallyEventHandler)Delegate.Combine(timeChangedManuallyEventHandler2, value);
				timeChangedManuallyEventHandler = Interlocked.CompareExchange(ref timeChangedManuallyEventHandler_0, value2, timeChangedManuallyEventHandler2);
			}
			while ((object)timeChangedManuallyEventHandler != timeChangedManuallyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler = timeChangedManuallyEventHandler_0;
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler2;
			do
			{
				timeChangedManuallyEventHandler2 = timeChangedManuallyEventHandler;
				TimeChangedManuallyEventHandler value2 = (TimeChangedManuallyEventHandler)Delegate.Remove(timeChangedManuallyEventHandler2, value);
				timeChangedManuallyEventHandler = Interlocked.CompareExchange(ref timeChangedManuallyEventHandler_0, value2, timeChangedManuallyEventHandler2);
			}
			while ((object)timeChangedManuallyEventHandler != timeChangedManuallyEventHandler2);
		}
	}

	public static event NewMessageEventHandler NewMessage
	{
		[CompilerGenerated]
		add
		{
			NewMessageEventHandler newMessageEventHandler = newMessageEventHandler_0;
			NewMessageEventHandler newMessageEventHandler2;
			do
			{
				newMessageEventHandler2 = newMessageEventHandler;
				NewMessageEventHandler value2 = (NewMessageEventHandler)Delegate.Combine(newMessageEventHandler2, value);
				newMessageEventHandler = Interlocked.CompareExchange(ref newMessageEventHandler_0, value2, newMessageEventHandler2);
			}
			while ((object)newMessageEventHandler != newMessageEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NewMessageEventHandler newMessageEventHandler = newMessageEventHandler_0;
			NewMessageEventHandler newMessageEventHandler2;
			do
			{
				newMessageEventHandler2 = newMessageEventHandler;
				NewMessageEventHandler value2 = (NewMessageEventHandler)Delegate.Remove(newMessageEventHandler2, value);
				newMessageEventHandler = Interlocked.CompareExchange(ref newMessageEventHandler_0, value2, newMessageEventHandler2);
			}
			while ((object)newMessageEventHandler != newMessageEventHandler2);
		}
	}

	public static event UnitAddedEventHandler UnitAdded
	{
		[CompilerGenerated]
		add
		{
			UnitAddedEventHandler unitAddedEventHandler = unitAddedEventHandler_0;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Combine(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref unitAddedEventHandler_0, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitAddedEventHandler unitAddedEventHandler = unitAddedEventHandler_0;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Remove(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref unitAddedEventHandler_0, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
	}

	public static event UnitRemovedEventHandler UnitRemoved
	{
		[CompilerGenerated]
		add
		{
			UnitRemovedEventHandler unitRemovedEventHandler = unitRemovedEventHandler_0;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Combine(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref unitRemovedEventHandler_0, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitRemovedEventHandler unitRemovedEventHandler = unitRemovedEventHandler_0;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Remove(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref unitRemovedEventHandler_0, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
	}

	public static event EventTriggersChangedEventHandler EventTriggersChanged
	{
		[CompilerGenerated]
		add
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = eventTriggersChangedEventHandler_0;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Combine(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref eventTriggersChangedEventHandler_0, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = eventTriggersChangedEventHandler_0;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Remove(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref eventTriggersChangedEventHandler_0, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
	}

	public static event EventConditionsChangedEventHandler EventConditionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = eventConditionsChangedEventHandler_0;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Combine(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref eventConditionsChangedEventHandler_0, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = eventConditionsChangedEventHandler_0;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Remove(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref eventConditionsChangedEventHandler_0, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
	}

	public static event EventActionsChangedEventHandler EventActionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = eventActionsChangedEventHandler_0;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Combine(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref eventActionsChangedEventHandler_0, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = eventActionsChangedEventHandler_0;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Remove(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref eventActionsChangedEventHandler_0, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
	}

	public static event ScenAttachmentsChangedEventHandler ScenAttachmentsChanged
	{
		[CompilerGenerated]
		add
		{
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler = scenAttachmentsChangedEventHandler_0;
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler2;
			do
			{
				scenAttachmentsChangedEventHandler2 = scenAttachmentsChangedEventHandler;
				ScenAttachmentsChangedEventHandler value2 = (ScenAttachmentsChangedEventHandler)Delegate.Combine(scenAttachmentsChangedEventHandler2, value);
				scenAttachmentsChangedEventHandler = Interlocked.CompareExchange(ref scenAttachmentsChangedEventHandler_0, value2, scenAttachmentsChangedEventHandler2);
			}
			while ((object)scenAttachmentsChangedEventHandler != scenAttachmentsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler = scenAttachmentsChangedEventHandler_0;
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler2;
			do
			{
				scenAttachmentsChangedEventHandler2 = scenAttachmentsChangedEventHandler;
				ScenAttachmentsChangedEventHandler value2 = (ScenAttachmentsChangedEventHandler)Delegate.Remove(scenAttachmentsChangedEventHandler2, value);
				scenAttachmentsChangedEventHandler = Interlocked.CompareExchange(ref scenAttachmentsChangedEventHandler_0, value2, scenAttachmentsChangedEventHandler2);
			}
			while ((object)scenAttachmentsChangedEventHandler != scenAttachmentsChangedEventHandler2);
		}
	}

	public static event ScenCompletedEventHandler ScenCompleted
	{
		[CompilerGenerated]
		add
		{
			ScenCompletedEventHandler scenCompletedEventHandler = scenCompletedEventHandler_0;
			ScenCompletedEventHandler scenCompletedEventHandler2;
			do
			{
				scenCompletedEventHandler2 = scenCompletedEventHandler;
				ScenCompletedEventHandler value2 = (ScenCompletedEventHandler)Delegate.Combine(scenCompletedEventHandler2, value);
				scenCompletedEventHandler = Interlocked.CompareExchange(ref scenCompletedEventHandler_0, value2, scenCompletedEventHandler2);
			}
			while ((object)scenCompletedEventHandler != scenCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScenCompletedEventHandler scenCompletedEventHandler = scenCompletedEventHandler_0;
			ScenCompletedEventHandler scenCompletedEventHandler2;
			do
			{
				scenCompletedEventHandler2 = scenCompletedEventHandler;
				ScenCompletedEventHandler value2 = (ScenCompletedEventHandler)Delegate.Remove(scenCompletedEventHandler2, value);
				scenCompletedEventHandler = Interlocked.CompareExchange(ref scenCompletedEventHandler_0, value2, scenCompletedEventHandler2);
			}
			while ((object)scenCompletedEventHandler != scenCompletedEventHandler2);
		}
	}

	public static event UnitSideChangedEventHandler UnitSideChanged
	{
		[CompilerGenerated]
		add
		{
			UnitSideChangedEventHandler unitSideChangedEventHandler = unitSideChangedEventHandler_0;
			UnitSideChangedEventHandler unitSideChangedEventHandler2;
			do
			{
				unitSideChangedEventHandler2 = unitSideChangedEventHandler;
				UnitSideChangedEventHandler value2 = (UnitSideChangedEventHandler)Delegate.Combine(unitSideChangedEventHandler2, value);
				unitSideChangedEventHandler = Interlocked.CompareExchange(ref unitSideChangedEventHandler_0, value2, unitSideChangedEventHandler2);
			}
			while ((object)unitSideChangedEventHandler != unitSideChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitSideChangedEventHandler unitSideChangedEventHandler = unitSideChangedEventHandler_0;
			UnitSideChangedEventHandler unitSideChangedEventHandler2;
			do
			{
				unitSideChangedEventHandler2 = unitSideChangedEventHandler;
				UnitSideChangedEventHandler value2 = (UnitSideChangedEventHandler)Delegate.Remove(unitSideChangedEventHandler2, value);
				unitSideChangedEventHandler = Interlocked.CompareExchange(ref unitSideChangedEventHandler_0, value2, unitSideChangedEventHandler2);
			}
			while ((object)unitSideChangedEventHandler != unitSideChangedEventHandler2);
		}
	}

	static Scenario()
	{
		Class72.smethod_20();
		CargoMovement = new List<(string, CargoTracker)>();
		NEZ_DLZ_Cache = new ConcurrentDictionary<(float, double, float), (float, double)>();
	}

	public int GetTotalUnitCount()
	{
		int num = 0;
		Side[] array = side_0;
		foreach (Side side in array)
		{
			num += side.Units.Count;
		}
		return num;
	}

	public void ReleaseReferences()
	{
		try
		{
			ThreadedOpsMustStop = true;
			luaSandBox_0 = null;
			_GameContext = null;
			Pathfinding.ClearAllPathfinderRequests();
			side_1 = null;
			foreach (KeyValuePair<string, ActiveUnit> activeUnit in ActiveUnits)
			{
				if (string.IsNullOrEmpty(activeUnit.Key) | (activeUnit.Value == null))
				{
					Debugger.Break();
				}
				else
				{
					activeUnit.Value.ReleaseReferences();
				}
			}
			if (side_0 != null)
			{
				Side[] array = side_0;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i]?.ReleaseReferences();
				}
			}
			Groups.Clear();
			ActiveUnits.Clear();
			pooledList_0 = null;
			side_0 = new Side[0];
			ScenAttachments = null;
			UnhandledPopUpMessages = null;
			MessageLog = null;
			concurrentQueue_0 = null;
			sqliteConnection_0?.Close();
			sqliteConnection_0 = null;
			DBUsed = null;
			list_5 = null;
			list_6 = null;
			UnitsForLateInstantiation = null;
			Cache_FacilitiesWithPiers = null;
			Cache_Weapons = null;
			Cache_SensorCompatibleFrequencies = null;
			Cache_XSections = null;
			Cache_FuelForPitchEnabledWeapons = null;
			Cache_BurnTimesForBoostCoastWeapons = null;
			Cache_AssociatedSensors = null;
			Cache_PowerplantAltBands = null;
			Cache_PrimaryTargetForWhichPlatforms = null;
			Cache_DisabledLoadouts = null;
			CandidatesForDetectionByMines.Clear();
			EventTriggers = null;
			EventConditions = null;
			EventActions = null;
			SimEvents = new ConcurrentObservableDictionary<string, SimEvent>();
			Explosions = null;
			WeaponImpacts = null;
			WaterSplashes = null;
			GroundImpacts = null;
			UnguidedWeapons = null;
			Mines = null;
			MineAllocation = null;
			ChaffClouds = null;
			HasBeenReleased = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal bool IsEmpty()
	{
		if (side_0.Count() > 0)
		{
			return false;
		}
		if (string_1 == null && string_2 == null && string_3 == null)
		{
			int result;
			if (EventTriggers.Count > 0)
			{
				result = 0;
			}
			else if (EventActions.Count > 0)
			{
				result = 0;
			}
			else
			{
				if (EventConditions.Count <= 0)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public void CheckForUndeclaredFeatures()
	{
		if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsDisruption))
		{
			return;
		}
		foreach (ActiveUnit activeUnits_ in ActiveUnits_List)
		{
			if (activeUnits_ != null && !activeUnits_.CommStuff.IsConnectedToSideNetwork)
			{
				DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
				break;
			}
		}
		using IEnumerator<EventAction> enumerator2 = EventActions.Values.GetEnumerator();
		EventAction current2;
		do
		{
			if (enumerator2.MoveNext())
			{
				current2 = enumerator2.Current;
				continue;
			}
			return;
		}
		while (current2.Type != EventAction.EventActionType.LuaScript || !Misc.Contains(((EventAction_LuaScript)current2).ScriptText, "OUTOFCOMMS", StringComparison.OrdinalIgnoreCase));
		DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
	}

	public void PRE_MDSP_Flightplan_Weapon_Altitude_FIX()
	{
		try
		{
			Side[] sides_ReadOnly = Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (Mission mission in side.Missions)
				{
					if (mission.MissionClass == Mission._MissionClass.Strike)
					{
						FIX_WpnReleaseAltitude(mission);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 903846489276548", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FIX_WpnReleaseAltitude(Mission theMission)
	{
		if (theMission == null || theMission.MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		foreach (KeyValuePair<ActiveUnit, ActiveUnit> item in theMission.UnitsAssignedToMission)
		{
			if (!item.Key.IsAircraft)
			{
				continue;
			}
			Aircraft aircraft = (Aircraft)item.Key;
			if (!aircraft.Navigator.HasFlightPlan)
			{
				continue;
			}
			HashSet<Module_Unit.Unit> specificTargets = ((Strike)theMission).SpecificTargets;
			if (specificTargets == null || specificTargets.Count <= 0)
			{
				continue;
			}
			Contact theTarget;
			if (!specificTargets.ElementAtOrDefault(0).IsActiveUnit)
			{
				if (!specificTargets.ElementAtOrDefault(0).IsContact())
				{
					break;
				}
				theTarget = (Contact)specificTargets.ElementAtOrDefault(0);
			}
			else
			{
				theTarget = Contact.Instantiate((ActiveUnit)specificTargets.ElementAtOrDefault(0), 0, forWRA: true);
			}
			Weapon theW = aircraft.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, aircraft.Doctrine);
			SetWpAltitudeToClampedWpnAltitude(aircraft, theW);
		}
	}

	public void SetWpAltitudeToClampedWpnAltitude(Aircraft theAC, Weapon theW)
	{
		if (theW == null)
		{
			return;
		}
		_ = theW.MinLaunchAlt_AGL;
		_ = theW.MaxLaunchAlt_AGL;
		Waypoint[] flightPlan = ((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
		foreach (Waypoint waypoint in flightPlan)
		{
			if ((waypoint.Type == Waypoint.WaypointType.StrikeIngress) | (waypoint.Type == Waypoint.WaypointType.StrikeEgress) | (waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint) | (waypoint.Type == Waypoint.WaypointType.WeaponTarget))
			{
				float clampedWpnAltitudeForThisWP = GetClampedWpnAltitudeForThisWP(theAC, theW, waypoint);
				float num = clampedWpnAltitudeForThisWP;
				float? desiredAltitude = waypoint.DesiredAltitude;
				if ((desiredAltitude.HasValue ? new bool?(num != desiredAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					waypoint.DesiredAltitude = clampedWpnAltitudeForThisWP;
				}
			}
		}
	}

	public float GetClampedWpnAltitudeForThisWP(Aircraft theAC, Weapon theW, Waypoint theWP)
	{
		float LowerReleaseAltitudeLimit_ASL = 0f;
		float UpperReleaseAltitudeLimit_ASL = 0f;
		float LowerReleaseAltitudeLimit_AGL = 0f;
		float UpperReleaseAltitudeLimit_AGL = 0f;
		theAC.AI.GetWeaponReleaseLimits(GameResolution, theW, ref LowerReleaseAltitudeLimit_ASL, ref UpperReleaseAltitudeLimit_ASL, ref LowerReleaseAltitudeLimit_AGL, ref UpperReleaseAltitudeLimit_AGL, null, short.MinValue, theWP.Latitude, theWP.Longitude);
		float num = (float)((double)LowerReleaseAltitudeLimit_ASL + (double)LowerReleaseAltitudeLimit_ASL * 0.1);
		float num2 = (float)((double)UpperReleaseAltitudeLimit_ASL - (double)UpperReleaseAltitudeLimit_ASL * 0.1);
		if (theWP.DesiredAltitude.HasValue)
		{
			float? desiredAltitude = theWP.DesiredAltitude;
			if (((!desiredAltitude.HasValue) ? ((bool?)null) : new bool?(desiredAltitude.GetValueOrDefault() < num)) != true)
			{
				if (theWP.DesiredAltitude.HasValue)
				{
					desiredAltitude = theWP.DesiredAltitude;
					if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > num2) : ((bool?)null)) != true)
					{
						return theWP.DesiredAltitude.Value;
					}
				}
				return num2;
			}
		}
		return num;
	}

	public static void FIX_FlightPlanWeapon_Altitude(Scenario theScen, Mission theMission, Mission.Flight theFlight = null, bool UICall = false)
	{
		if (theMission.MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		new HashSet<string>();
		IEnumerator<KeyValuePair<ActiveUnit, ActiveUnit>> enumerator = theMission.UnitsAssignedToMission.GetEnumerator();
		while (true)
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<ActiveUnit, ActiveUnit> current = enumerator.Current;
				if (!current.Key.IsAircraft)
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)current.Key;
				if (theFlight != null)
				{
					if (aircraft.Navigator.HasFlight && Operators.CompareString(((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).Callsign, theFlight.Callsign, false) == 0)
					{
					}
				}
				else
				{
					if (!aircraft.Navigator.HasFlightPlan)
					{
						continue;
					}
					HashSet<Module_Unit.Unit> specificTargets = ((Strike)theMission).SpecificTargets;
					if (specificTargets == null || specificTargets.Count <= 0)
					{
						continue;
					}
					Contact theTarget;
					if (specificTargets.ElementAtOrDefault(0).IsActiveUnit)
					{
						theTarget = Contact.Instantiate((ActiveUnit)specificTargets.ElementAtOrDefault(0), 0, forWRA: true);
					}
					else
					{
						if (!specificTargets.ElementAtOrDefault(0).IsContact())
						{
							break;
						}
						theTarget = (Contact)specificTargets.ElementAtOrDefault(0);
					}
					Waypoint[] flightPlan = ((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						if ((waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint))
						{
							Weapon weapon = aircraft.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, aircraft.Doctrine);
							if (weapon.MinLaunchAlt_AGL == 0f)
							{
								weapon.MinLaunchAlt_AGL = float.MinValue;
							}
							if (weapon.MinLaunchAlt_ASL == 0f)
							{
								weapon.MinLaunchAlt_ASL = float.MinValue;
							}
							if (weapon.MaxLaunchAlt_AGL == 0f)
							{
								weapon.MaxLaunchAlt_AGL = 36010f;
							}
							if (weapon.MaxLaunchAlt_ASL == 0f)
							{
								weapon.MaxLaunchAlt_ASL = 36010f;
							}
							if (!((GeoPoint)waypoint).get_IsOverLand(theScen))
							{
								waypoint.DesiredAltitude = (weapon.MaxLaunchAlt_ASL - 10f) * 0.3048f;
								waypoint.DesiredAltitude_TerrainFollowing = null;
							}
							else if (waypoint.TerrainFollowing)
							{
								waypoint.DesiredAltitude_TerrainFollowing = (weapon.MaxLaunchAlt_AGL - 10f) * 0.3048f;
								waypoint.DesiredAltitude = null;
							}
							else
							{
								waypoint.DesiredAltitude = (weapon.MaxLaunchAlt_ASL - 10f) * 0.3048f;
								waypoint.DesiredAltitude_TerrainFollowing = null;
							}
						}
					}
					List<Mission.Flight>.Enumerator enumerator2 = theMission.FlightList.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						theFlight = enumerator2.Current;
						Waypoint[] flightPlan2 = theFlight.FlightPlan;
						for (int j = 0; j < flightPlan2.Length; j = checked(j + 1))
						{
							Waypoint theWP = flightPlan2[j];
							MissionPlanner.ValidateFlightPlans_EnoughFuel(ref theScen, ref theMission, ref theFlight, ref theWP, IsMFP: true);
						}
					}
				}
				continue;
			}
			MissionPlanner.Update_Mission_times(theScen, theMission);
			break;
		}
	}

	public string ToXML_ViaStream(bool MinifyText)
	{
		using MemoryStream theStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		ToXML(theStream, MinifyText);
		return Misc.ConvertToString(theStream);
	}

	public string ToXML_ViaStringBuilder(bool MinifyText)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		StringBuilder sb = new StringBuilder();
		StringWriter stringWriter = new StringWriter(sb);
		XmlTextWriter val = new XmlTextWriter((TextWriter)stringWriter);
		if (!MinifyText)
		{
			val.Formatting = (Formatting)1;
			val.Indentation = 4;
		}
		method_0((XmlWriter)(object)val);
		return stringWriter.ToString();
	}

	public void ToXML(Stream theStream, bool MinifyText)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlWriterSettings val = new XmlWriterSettings();
		if (!MinifyText)
		{
			val.Indent = true;
			val.IndentChars = "    ";
		}
		XmlWriter xmlWriter_ = XmlWriter.Create(theStream, val);
		method_0(xmlWriter_);
	}

	private void method_0(XmlWriter xmlWriter_0)
	{
		try
		{
			HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
			XmlWriter val = xmlWriter_0;
			try
			{
				if (!string.IsNullOrEmpty(ContentTag))
				{
					xmlWriter_0.WriteStartElement("ContentScenario");
				}
				else
				{
					xmlWriter_0.WriteStartElement("Scenario");
				}
				xmlWriter_0.WriteElementString("TimelineID", TimelineID.ToString());
				xmlWriter_0.WriteElementString("ObjectID", ObjectID.ToString());
				xmlWriter_0.WriteElementString("ContentTag", ContentTag);
				xmlWriter_0.WriteElementString("CampaignID", CampaignID);
				xmlWriter_0.WriteElementString("CampaignSessionID", CampaignSessionID);
				xmlWriter_0.WriteElementString("CampaignScore", CampaignScore.ToString());
				xmlWriter_0.WriteElementString("Title", string_1);
				xmlWriter_0.WriteElementString("Description", string_2);
				xmlWriter_0.WriteElementString("Description_Encrypted", string_3);
				xmlWriter_0.WriteElementString("Meta_Complexity", Conversions.ToString((int)Meta_Complexity));
				xmlWriter_0.WriteElementString("Meta_Difficulty", Conversions.ToString((int)Meta_Difficulty));
				xmlWriter_0.WriteElementString("Meta_ScenSetting", Meta_ScenSetting);
				xmlWriter_0.WriteElementString("FileName", FileName);
				xmlWriter_0.WriteElementString("FileNamePath", FileNamePath);
				xmlWriter_0.WriteRaw(RoadSystem.ToXML());
				xmlWriter_0.WriteElementString("Time", dateTime_0.ToBinary().ToString());
				xmlWriter_0.WriteElementString("ZeroHour", ZeroHour.ToBinary().ToString());
				if (nullable_0.HasValue)
				{
					xmlWriter_0.WriteElementString("StartTime", nullable_0.Value.ToBinary().ToString());
				}
				if (nullable_1.HasValue)
				{
					xmlWriter_0.WriteElementString("Duration", nullable_1.Value.Ticks.ToString());
				}
				xmlWriter_0.WriteElementString("DaylightSavingTime", bool_0.ToString());
				if (Information.IsNothing((object)string_4))
				{
					string_4 = "00.00";
				}
				if (Information.IsNothing((object)string_5))
				{
					string_5 = "00.00";
				}
				xmlWriter_0.WriteElementString("DaylightSavingTime_Start", string_4.ToString());
				xmlWriter_0.WriteElementString("DaylightSavingTime_End", string_5.ToString());
				xmlWriter_0.WriteStartElement("Sides");
				Side[] array = side_0;
				foreach (Side side in array)
				{
					XmlWriter obj = xmlWriter_0;
					Scenario theScen = this;
					obj.WriteRaw(side.ToXML(ref ObjectsAlreadySerialized, ref theScen));
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("NonActiveUnits");
				if (Explosions != null)
				{
					xmlWriter_0.WriteStartElement("Explosions");
					foreach (Explosion explosion in Explosions)
					{
						explosion.ToXML(ref xmlWriter_0, ref ObjectsAlreadySerialized);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (WeaponImpacts != null)
				{
					xmlWriter_0.WriteStartElement("WeaponImpacts");
					for (int j = WeaponImpacts.Count - 1; j >= 0; j += -1)
					{
						WeaponImpacts[j].ToXML(ref xmlWriter_0, ref ObjectsAlreadySerialized);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (UnguidedWeapons != null)
				{
					xmlWriter_0.WriteStartElement("UnguidedWeapons");
					foreach (UnguidedWeapon value in UnguidedWeapons.Values)
					{
						xmlWriter_0.WriteRaw(value.ToXML(ref xmlWriter_0, ref ObjectsAlreadySerialized));
					}
					xmlWriter_0.WriteEndElement();
				}
				if (ChaffClouds != null)
				{
					xmlWriter_0.WriteStartElement("ChaffClouds");
					foreach (ChaffCorridorCloud chaffCloud in ChaffClouds)
					{
						chaffCloud.ToXML(ref xmlWriter_0, ref ObjectsAlreadySerialized);
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("ActiveUnits");
				foreach (ActiveUnit activeUnits_ in ActiveUnits_List)
				{
					if (activeUnits_ != null)
					{
						activeUnits_.ToXML(ref xmlWriter_0, ref ObjectsAlreadySerialized);
						xmlWriter_0.Flush();
					}
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("Groups");
				foreach (Group group in Groups)
				{
					if (group != null)
					{
						xmlWriter_0.WriteElementString("ID", group.ObjectID);
					}
				}
				xmlWriter_0.WriteEndElement();
				XmlWriter obj3 = xmlWriter_0;
				byte weatherLevel = (byte)WeatherLevel;
				obj3.WriteElementString("WeatherModel", weatherLevel.ToString());
				xmlWriter_0.WriteStartElement("GlobalWeather");
				GlobalWeather.ToXML(ref xmlWriter_0);
				xmlWriter_0.WriteEndElement();
				if (EventTriggers != null)
				{
					xmlWriter_0.WriteStartElement("EventTriggers");
					foreach (EventTrigger value2 in EventTriggers.Values)
					{
						value2.ToXML(xmlWriter_0, ObjectsAlreadySerialized, this);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (EventConditions != null)
				{
					xmlWriter_0.WriteStartElement("EventConditions");
					foreach (EventCondition value3 in EventConditions.Values)
					{
						value3.ToXML(xmlWriter_0, ObjectsAlreadySerialized, this);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (EventActions != null)
				{
					xmlWriter_0.WriteStartElement("EventActions");
					foreach (EventAction value4 in EventActions.Values)
					{
						value4.ToXML(xmlWriter_0, ObjectsAlreadySerialized, this);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (SimEvents != null)
				{
					xmlWriter_0.WriteStartElement("SimEvents");
					foreach (SimEvent value5 in SimEvents.Values)
					{
						value5.ToXML(xmlWriter_0, ObjectsAlreadySerialized, this);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (ScenAttachments != null)
				{
					xmlWriter_0.WriteStartElement("ScenAttachmentObjects");
					foreach (ScenAttachmentObject value6 in ScenAttachments.Values)
					{
						value6.ToXML(xmlWriter_0, ObjectsAlreadySerialized, this);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (MissionPlannerErrorList != null)
				{
					xmlWriter_0.WriteStartElement("FlightplanErrors");
					foreach (MDSP_Error missionPlannerError in MissionPlannerErrorList)
					{
						missionPlannerError?.ToXML(ObjectsAlreadySerialized);
					}
					xmlWriter_0.WriteEndElement();
				}
				XmlWriter obj4 = xmlWriter_0;
				int num = (int)enumTimeCompression_0;
				obj4.WriteElementString("TimeCompression", num.ToString());
				xmlWriter_0.WriteElementString("GameResolution", XmlConvert.ToString(float_0));
				method_9(xmlWriter_0);
				xmlWriter_0.WriteElementString("MessageIncrement", long_0.ToString());
				xmlWriter_0.WriteElementString("UnitsAutoIncrement", UnitsAutoIncrement.ToString());
				if (!Information.IsNothing((object)GetCurrentSide()))
				{
					xmlWriter_0.WriteElementString("CurrentSide", GetCurrentSide().Name);
				}
				xmlWriter_0.WriteElementString("GameVersion", GameVersion);
				xmlWriter_0.WriteElementString("DBUsed", DBUsed.ToString());
				if (LastSavedInScenEdit)
				{
					xmlWriter_0.WriteElementString("LastSavedInScenEdit", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.ACS_NAW_Limitations))
				{
					xmlWriter_0.WriteElementString("LandingPlan_ACS_NAW_Limitations", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.DroneAutonomyLevels))
				{
					xmlWriter_0.WriteElementString("Realism_DroneAutonomy", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.DetailedGunFireControl))
				{
					xmlWriter_0.WriteElementString("Realism_DetailedGunFireControl", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.UnlimitedBaseMagazines))
				{
					xmlWriter_0.WriteElementString("Realism_UnlimitedBaseMags", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.RealisticSubComms))
				{
					xmlWriter_0.WriteElementString("Realism_RealisticSubComms", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.LandTypeEffects))
				{
					xmlWriter_0.WriteElementString("Realism_LandTypeEffects", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.LandTypeEffects_Advanced))
				{
					xmlWriter_0.WriteElementString("Realism_LandTypeEffects_Advanced", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsJamming))
				{
					xmlWriter_0.WriteElementString("Realism_CommsJamming", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsDisruption))
				{
					xmlWriter_0.WriteElementString("Realism_CommsDisruption", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.AircraftDamage))
				{
					xmlWriter_0.WriteElementString("Realism_AircraftDamage", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.WeatherAffectsShipSpeed))
				{
					xmlWriter_0.WriteElementString("Realism_WeatherAffectsShipSpeed", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.AllowLandingPlannerInstantLoading))
				{
					xmlWriter_0.WriteElementString("LandingPlan_InstLoad", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.ASCMTerrainFollowingRestriction))
				{
					xmlWriter_0.WriteElementString("Realism_ASCMTerrainFollowing", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.PointToPointComm))
				{
					xmlWriter_0.WriteElementString("PointToPointComm", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.RealisticOrderChain))
				{
					xmlWriter_0.WriteElementString("RealisticOrderChain", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.VariableBurnoutSpeed))
				{
					xmlWriter_0.WriteElementString("VariableBurnoutSpeed", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.LimitedSonobuoysInMagazines))
				{
					xmlWriter_0.WriteElementString("LimitedSonobuoys", "True");
				}
				if (!string.IsNullOrEmpty(LuaXml))
				{
					xmlWriter_0.WriteElementString("LuaXml", LuaXml);
				}
				if (!string.IsNullOrEmpty(LuaXmlPassed))
				{
					xmlWriter_0.WriteElementString("LuaXmlPassed", LuaXmlPassed);
				}
				if (DefaultGuidedWeaponsVsAirTargetWRASetting != Doctrine._WRA_FiringRange.NotConfigured)
				{
					XmlWriter obj5 = xmlWriter_0;
					num = (int)DefaultGuidedWeaponsVsAirTargetWRASetting;
					obj5.WriteElementString("DefaultGuidedWeaponsVsAirTargetWRASetting", num.ToString());
				}
				if (GameGeneral.EnableLoadoutFilter)
				{
					xmlWriter_0.WriteElementString("GroupFilter", GameGeneral.FlightGroupFilter.ToString());
				}
				xmlWriter_0.WriteEndElement();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			ObjectsAlreadySerialized = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101022", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Scenario FromXmlText(string string_7, ref string ErrorFeedback, Action<double> PercentageComplete, bool ForceDeepRebuild = false, bool bool_3 = true)
	{
		CMANO.HandleScenarioChanging();
		return FromXMLText_internal(string_7, ref ErrorFeedback, PercentageComplete, ForceDeepRebuild, bool_3);
	}

	public static Scenario FromXMLText_internal(string string_7, ref string ErrorFeedback, Action<double> PercentageComplete, bool ForceDeepRebuild = false, bool bool_3 = true)
	{
		//IL_1b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1f: Expected O, but got Unknown
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e38: Expected O, but got Unknown
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed7: Expected O, but got Unknown
		//IL_0f6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f73: Expected O, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_100f: Expected O, but got Unknown
		//IL_10b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ba: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_117f: Expected O, but got Unknown
		//IL_154f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Expected O, but got Unknown
		//IL_1632: Unknown result type (might be due to invalid IL or missing references)
		//IL_1639: Expected O, but got Unknown
		//IL_16dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e3: Expected O, but got Unknown
		//IL_1782: Unknown result type (might be due to invalid IL or missing references)
		//IL_1789: Expected O, but got Unknown
		//IL_1828: Unknown result type (might be due to invalid IL or missing references)
		//IL_1840: Expected O, but got Unknown
		//IL_18ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Expected O, but got Unknown
		//IL_1970: Unknown result type (might be due to invalid IL or missing references)
		//IL_1977: Expected O, but got Unknown
		_Closure$__322-2 closure$__322- = new _Closure$__322-2(closure$__322-);
		closure$__322-.$VB$Local_PercentageComplete = PercentageComplete;
		if (closure$__322-.$VB$Local_PercentageComplete == null)
		{
			closure$__322-.$VB$Local_PercentageComplete = [SpecialName] (double d) =>
			{
			};
		}
		XmlDocument_wrapper xmlDocument_wrapper = new XmlDocument_wrapper();
		try
		{
			xmlDocument_wrapper.LoadXml(string_7);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200465", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			try
			{
				string_7 = Misc.CleanUpXML_Headers(string_7);
				string_7 = Misc.CleanUpXML_CorruptedSlugTrailNames(string_7);
				xmlDocument_wrapper.LoadXml(string_7);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ex2?.Data.Add("Error at 200466", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				string_7 = Misc.CleanUpXML_IllegalCharacters(string_7.ToCharArray());
				try
				{
					xmlDocument_wrapper.LoadXml(string_7);
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
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		Scenario result;
		try
		{
			_Closure$__322-1 closure$__322-2 = new _Closure$__322-1(closure$__322-2);
			closure$__322-2.$VB$NonLocal_$VB$Closure_2 = closure$__322-;
			closure$__322-2.$VB$Local_theScen = new Scenario("", "", "");
			closure$__322-2.$VB$Local_ObjectsDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			XmlNode val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/Scenario", "");
			string text = ((val != null) ? "Scenario" : "ContentScenario");
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/GameGUID");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.TimelineID = val.InnerText;
			}
			else
			{
				Scenario scenario = closure$__322-2.$VB$Local_theScen;
				XmlNode obj = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/TimelineID");
				scenario.TimelineID = ((obj != null) ? obj.InnerText : null);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/ObjectID");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.ObjectID = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/ContentTag");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.ContentTag = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CampaignID");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.CampaignID = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CampaignSessionID");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.CampaignSessionID = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CampaignScore");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.CampaignScore = Conversions.ToInteger(val.InnerText);
			}
			Scenario scenario2 = closure$__322-2.$VB$Local_theScen;
			XmlNode obj2 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Title");
			scenario2.Title = ((obj2 != null) ? obj2.InnerText : null);
			try
			{
				closure$__322-2.$VB$Local_theScen.string_2 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Description").InnerText;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 2000519999", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				closure$__322-2.$VB$Local_theScen.string_2 = string.Empty;
				ProjectData.ClearProjectError();
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Description_Encrypted");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.string_3 = val.InnerText;
			}
			closure$__322-2.$VB$Local_theScen.Description = closure$__322-2.$VB$Local_theScen.Description.Replace("<HR>", "");
			try
			{
				closure$__322-2.$VB$Local_theScen.Meta_Complexity = Conversions.ToShort(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Meta_Complexity").InnerText);
				closure$__322-2.$VB$Local_theScen.Meta_Difficulty = Conversions.ToShort(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Meta_Difficulty").InnerText);
				closure$__322-2.$VB$Local_theScen.Meta_ScenSetting = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Meta_ScenSetting").InnerText;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 200051", ex6.Message);
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			closure$__322-2.$VB$Local_theScen.FileName = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/FileName").InnerText;
			try
			{
				if (xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/FileNamePath") != null)
				{
					closure$__322-2.$VB$Local_theScen.FileNamePath = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/FileNamePath").InnerText;
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			closure$__322-2.$VB$Local_theScen.dateTime_0 = DateTime.FromBinary(Conversions.ToLong(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Time").InnerText));
			try
			{
				closure$__322-2.$VB$Local_theScen.ZeroHour = DateTime.FromBinary(Conversions.ToLong(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/ZeroHour").InnerText));
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				ProjectData.ClearProjectError();
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/StartTime");
			if (val != null && Operators.CompareString(val.InnerText, "0", false) != 0)
			{
				closure$__322-2.$VB$Local_theScen.nullable_0 = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DaylightSavingTime");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.bool_0 = Conversions.ToBoolean(val.InnerText);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DaylightSavingTime_Start");
			if (val != null && Operators.CompareString(val.InnerText, "0", false) != 0)
			{
				closure$__322-2.$VB$Local_theScen.string_4 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DaylightSavingTime_Start").InnerText.Replace(",", ".");
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Duration");
			if (val != null && Operators.CompareString(val.InnerText, "0", false) != 0)
			{
				closure$__322-2.$VB$Local_theScen.nullable_1 = new TimeSpan(Conversions.ToLong(val.InnerText));
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DaylightSavingTime_End");
			if (val != null && Operators.CompareString(val.InnerText, "0", false) != 0)
			{
				closure$__322-2.$VB$Local_theScen.string_5 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DaylightSavingTime_End").InnerText.Replace(",", ".");
			}
			try
			{
				closure$__322-2.$VB$Local_theScen.DBUsed = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DBUsed").InnerText.ToString();
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 23424444443243434", ex8.Message);
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (string.IsNullOrEmpty(ex8.Message))
				{
					GameGeneral.SendMessageBoxToUI("ERROR! The scenario file is probably corrupted, could not determine which database to use!", null);
				}
				else
				{
					GameGeneral.SendMessageBoxToUI("ERROR: " + ex8.Message, null);
				}
				result = null;
				ProjectData.ClearProjectError();
				goto end_IL_0120;
			}
			if (Versioned.IsNumeric((object)closure$__322-2.$VB$Local_theScen.DBUsed))
			{
				closure$__322-2.$VB$Local_theScen.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(closure$__322-2.$VB$Local_theScen.DBUsed));
			}
			DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(closure$__322-2.$VB$Local_theScen.DBUsed, ref theResult, CheckLocalFileExists: true, bool_3);
			if (dBRecordByHash == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new Exception("Error: " + DBOps.EnglishMessageString(theResult));
			}
			if (dBRecordByHash.IsRegistered)
			{
				bool? isSupportedByGame = dBRecordByHash.IsSupportedByGame;
				if (((!isSupportedByGame) ?? isSupportedByGame) == true)
				{
					ErrorFeedback += "CAUTION! The database version matching this scenario is no longer supported by the simulation engine. The loaded scenario was automatically matched to the current version of this database. This change will persist on the next scenario save.\r\nNOTE: All units in the scenario will be rebuilt as brand-new from the DB (thus erasing any modified state on them, e.g. damage or expended fuel/weapons). Please use the SBR to restore any unit customizations (damage, ammo etc.) after the rebuild process.";
					closure$__322-2.$VB$Local_theScen.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID);
					closure$__322-2.$VB$Local_theScen.LoadStockUnits = true;
				}
			}
			if (ForceDeepRebuild)
			{
				closure$__322-2.$VB$Local_theScen.LoadStockUnits = true;
			}
			DBFunctions.GetPersonnelCargoValues(closure$__322-2.$VB$Local_theScen, ref Mount.PersonnelMass, ref Mount.PersonnelArea);
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Sides");
			XmlNodeList childNodes = default(XmlNodeList);
			if (val != null)
			{
				childNodes = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/NonActiveUnits/Explosions");
			XmlNodeList childNodes2 = default(XmlNodeList);
			if (val != null)
			{
				childNodes2 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/NonActiveUnits/WeaponImpacts");
			XmlNodeList childNodes3 = default(XmlNodeList);
			if (val != null)
			{
				childNodes3 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/NonActiveUnits/UnguidedWeapons");
			XmlNodeList childNodes4 = default(XmlNodeList);
			if (val != null)
			{
				childNodes4 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/NonActiveUnits/ChaffClouds");
			XmlNodeList childNodes5 = default(XmlNodeList);
			if (val != null)
			{
				childNodes5 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/ActiveUnits");
			XmlNodeList childNodes6 = default(XmlNodeList);
			if (val != null)
			{
				childNodes6 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Groups");
			XmlNodeList childNodes7 = default(XmlNodeList);
			if (val != null)
			{
				childNodes7 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/EventTriggers");
			XmlNodeList childNodes8 = default(XmlNodeList);
			if (val != null)
			{
				childNodes8 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/EventConditions");
			XmlNodeList childNodes9 = default(XmlNodeList);
			if (val != null)
			{
				childNodes9 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/EventActions");
			XmlNodeList childNodes10 = default(XmlNodeList);
			if (val != null)
			{
				childNodes10 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/SimEvents");
			XmlNodeList childNodes11 = default(XmlNodeList);
			if (val != null)
			{
				childNodes11 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/ScenAttachmentObjects");
			XmlNodeList childNodes12 = default(XmlNodeList);
			if (val != null)
			{
				childNodes12 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/MessageLog");
			XmlNodeList childNodes13 = default(XmlNodeList);
			if (val != null)
			{
				childNodes13 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/FlightplanErrors");
			XmlNodeList childNodes14 = default(XmlNodeList);
			if (val != null)
			{
				childNodes14 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CustomEnvironmentZones");
			XmlNodeList childNodes15 = default(XmlNodeList);
			if (val != null)
			{
				childNodes15 = val.ChildNodes;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Network");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.RoadSystem = new RoadSystem(val.OuterXml, GlobalInstance: true);
			}
			if (childNodes != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes.Count;
			}
			if (childNodes2 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes2.Count;
			}
			if (childNodes3 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes3.Count;
			}
			if (childNodes4 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes4.Count;
			}
			if (childNodes5 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes5.Count;
			}
			if (childNodes6 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes6.Count;
			}
			if (childNodes7 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes7.Count;
			}
			if (childNodes8 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes8.Count;
			}
			if (childNodes9 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes9.Count;
			}
			if (childNodes10 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes10.Count;
			}
			if (childNodes11 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes11.Count;
			}
			if (childNodes12 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes12.Count;
			}
			if (childNodes13 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes13.Count;
			}
			if (childNodes15 != null)
			{
				closure$__322-2.$VB$Local_TotalItems += childNodes15.Count;
			}
			closure$__322-2.$VB$Local_ItemsInstantiated = 0;
			if (!Information.IsNothing((object)childNodes))
			{
				foreach (XmlNode item5 in childNodes)
				{
					XmlNode theNode = item5;
					Side theSide = Side.FromXML(ref theNode, ref closure$__322-2.$VB$Local_theScen, ref closure$__322-2.$VB$Local_ObjectsDictionary);
					closure$__322-2.$VB$Local_theScen.AddSide(theSide);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (!Information.IsNothing((object)childNodes2))
			{
				foreach (XmlNode item6 in childNodes2)
				{
					XmlNode theNode2 = item6;
					Explosion item = Explosion.FromXML(ref theNode2, ref closure$__322-2.$VB$Local_ObjectsDictionary);
					closure$__322-2.$VB$Local_theScen.Explosions.Add(item);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (!Information.IsNothing((object)childNodes3))
			{
				foreach (XmlNode item7 in childNodes3)
				{
					XmlNode theNode3 = item7;
					WeaponImpact item2 = WeaponImpact.FromXML(ref theNode3, ref closure$__322-2.$VB$Local_ObjectsDictionary);
					closure$__322-2.$VB$Local_theScen.WeaponImpacts.Add(item2);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (!Information.IsNothing((object)childNodes4))
			{
				foreach (XmlNode item8 in childNodes4)
				{
					XmlNode theNode4 = item8;
					UnguidedWeapon unguidedWeapon = UnguidedWeapon.FromXML(ref theNode4, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref closure$__322-2.$VB$Local_theScen);
					closure$__322-2.$VB$Local_theScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon.ObjectID, unguidedWeapon);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (!Information.IsNothing((object)childNodes5))
			{
				foreach (XmlNode item9 in childNodes5)
				{
					XmlNode theNode5 = item9;
					ChaffCorridorCloud item3 = ChaffCorridorCloud.FromXML(ref theNode5, ref closure$__322-2.$VB$Local_ObjectsDictionary);
					closure$__322-2.$VB$Local_theScen.ChaffClouds.Add(item3);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (childNodes6 != null)
			{
				_Closure$__322-0 arg = default(_Closure$__322-0);
				_Closure$__322-0 CS$<>8__locals37 = new _Closure$__322-0(arg);
				CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3 = closure$__322-2;
				List<XmlNode> list = new List<XmlNode>(childNodes6.Count);
				CS$<>8__locals37.$VB$Local_theList_Groups = new List<XmlNode>();
				foreach (XmlNode item10 in childNodes6)
				{
					XmlNode val2 = item10;
					if (Operators.CompareString(val2.Name, "Group", false) == 0)
					{
						CS$<>8__locals37.$VB$Local_theList_Groups.Add(val2);
					}
					else
					{
						list.Add(val2);
					}
				}
				ActiveUnit[] array = new ActiveUnit[list.Count - 1 + 1];
				CS$<>8__locals37.$VB$Local_theArray_Groups = new ActiveUnit[CS$<>8__locals37.$VB$Local_theList_Groups.Count - 1 + 1];
				if (CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen.DBConnection.State == ConnectionState.Closed)
				{
					CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen.DBConnection.Open();
				}
				int num = list.Count - 1;
				for (int num2 = 0; num2 <= num; num2++)
				{
					XmlNode theNode6 = list[num2];
					ActiveUnit activeUnit = ActiveUnit.FromXML(ref theNode6, ref CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ObjectsDictionary, ref CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen);
					if (activeUnit != null && (activeUnit.DBID != 0 || activeUnit.UnitType == GlobalVariables.ActiveUnitType.AggregateGroundUnit))
					{
						array[num2] = activeUnit;
						CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated = CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated + 1;
						CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated / (double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_TotalItems);
					}
				}
				if (CS$<>8__locals37.$VB$Local_theList_Groups.Count > 0)
				{
					Parallel.For(0, CS$<>8__locals37.$VB$Local_theList_Groups.Count, [SpecialName] (int i) =>
					{
						XmlNode theNode13 = CS$<>8__locals37.$VB$Local_theList_Groups[i];
						Group obj4 = Group.FromXML(ref theNode13, ref CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ObjectsDictionary, ref CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen);
						CS$<>8__locals37.$VB$Local_theArray_Groups[i] = obj4;
						CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated = CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated + 1;
						CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated / (double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_TotalItems);
					});
				}
				List<ActiveUnit> list2 = new List<ActiveUnit>(array.Length + CS$<>8__locals37.$VB$Local_theArray_Groups.Length);
				list2.AddRange(array);
				if (CS$<>8__locals37.$VB$Local_theArray_Groups.Length > 0)
				{
					list2.AddRange(CS$<>8__locals37.$VB$Local_theArray_Groups);
				}
				foreach (ActiveUnit item11 in list2)
				{
					if (item11 == null)
					{
						continue;
					}
					if (!CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen.ActiveUnits.ContainsKey(item11.ObjectID))
					{
						CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen.ActiveUnits.TryAdd(item11.ObjectID, item11);
					}
					CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated = CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated + 1;
					CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_ItemsInstantiated / (double)CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_TotalItems);
					if (item11.ActiveMissionOrPackage() != null)
					{
						if (item11.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike && item11.AI.IsEscort)
						{
							item11.AI.IsEscort = false;
						}
					}
					else if (item11.AI.IsEscort)
					{
						item11.AI.IsEscort = false;
					}
				}
				foreach (ActiveUnit value6 in CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen.ActiveUnits.Values)
				{
					if (value6 != null)
					{
						value6.ParentScen = CS$<>8__locals37.$VB$NonLocal_$VB$Closure_3.$VB$Local_theScen;
					}
				}
			}
			foreach (XmlNode item12 in closure$__322-2.$VB$Local_theScen.UnitsForLateInstantiation)
			{
				XmlNode theNode7 = item12;
				ActiveUnit activeUnit2 = ActiveUnit.FromXML(ref theNode7, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref closure$__322-2.$VB$Local_theScen);
				closure$__322-2.$VB$Local_theScen.ActiveUnits[activeUnit2.ObjectID] = activeUnit2;
			}
			closure$__322-2.$VB$Local_theScen.UnitsForLateInstantiation.Clear();
			if (childNodes7 != null)
			{
				foreach (XmlNode item13 in childNodes7)
				{
					XmlNode val3 = item13;
					Group obj3 = null;
					if (!closure$__322-2.$VB$Local_ObjectsDictionary.TryGetValue(val3.InnerText, out var value))
					{
						ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = closure$__322-2.$VB$Local_theScen.ActiveUnits;
						string innerText = val3.InnerText;
						ActiveUnit value2 = null;
						activeUnits.TryRemove(innerText, out value2);
					}
					else
					{
						obj3 = (Group)value;
						closure$__322-2.$VB$Local_theScen.Groups.Add(obj3);
						obj3.ParentScen = closure$__322-2.$VB$Local_theScen;
						obj3.DeserializationInProgress = true;
					}
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (childNodes8 != null)
			{
				foreach (XmlNode item14 in childNodes8)
				{
					XmlNode theNode8 = item14;
					EventTrigger eventTrigger = EventTrigger.FromXML(ref theNode8, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref closure$__322-2.$VB$Local_theScen);
					if (eventTrigger != null)
					{
						closure$__322-2.$VB$Local_theScen.EventTriggers.TryAdd(eventTrigger.ObjectID, eventTrigger);
						closure$__322-2.$VB$Local_ItemsInstantiated++;
						closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
					}
				}
			}
			if (childNodes9 != null)
			{
				foreach (XmlNode item15 in childNodes9)
				{
					XmlNode theNode9 = item15;
					EventCondition eventCondition = EventCondition.FromXML(ref theNode9, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref closure$__322-2.$VB$Local_theScen);
					closure$__322-2.$VB$Local_theScen.EventConditions.TryAdd(eventCondition.ObjectID, eventCondition);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (childNodes10 != null)
			{
				foreach (XmlNode item16 in childNodes10)
				{
					XmlNode theNode10 = item16;
					EventAction eventAction = EventAction.FromXML(ref theNode10, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref closure$__322-2.$VB$Local_theScen);
					closure$__322-2.$VB$Local_theScen.EventActions.TryAdd(eventAction.ObjectID, eventAction);
					closure$__322-2.$VB$Local_ItemsInstantiated++;
					closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
				}
			}
			if (childNodes11 != null)
			{
				foreach (XmlNode item17 in childNodes11)
				{
					SimEvent simEvent = SimEvent.FromXML(item17, closure$__322-2.$VB$Local_ObjectsDictionary, closure$__322-2.$VB$Local_theScen);
					if (simEvent != null)
					{
						closure$__322-2.$VB$Local_theScen.SimEvents.TryAdd(simEvent.ObjectID, simEvent);
						closure$__322-2.$VB$Local_ItemsInstantiated++;
						closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
					}
				}
			}
			if (childNodes12 != null)
			{
				foreach (XmlNode item18 in childNodes12)
				{
					ScenAttachmentObject scenAttachmentObject = ScenAttachmentObject.FromXML(item18, closure$__322-2.$VB$Local_ObjectsDictionary, closure$__322-2.$VB$Local_theScen);
					if (scenAttachmentObject != null)
					{
						closure$__322-2.$VB$Local_theScen.ScenAttachments.Add(scenAttachmentObject.ObjectID, scenAttachmentObject);
						closure$__322-2.$VB$Local_ItemsInstantiated++;
						closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
					}
				}
			}
			if (childNodes14 != null)
			{
				foreach (XmlNode item19 in childNodes14)
				{
					XmlNode theNode11 = item19;
					MDSP_Error item4 = MDSP_Error.FromXML(ref theNode11, ref closure$__322-2.$VB$Local_ObjectsDictionary);
					closure$__322-2.$VB$Local_theScen.MissionPlannerErrorList.Add(item4);
				}
			}
			XmlNode val4 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/WeatherModel");
			if (val4 == null)
			{
				closure$__322-2.$VB$Local_theScen.WeatherLevel = WeatherModellingLevel.Level0;
			}
			else
			{
				closure$__322-2.$VB$Local_theScen.WeatherLevel = (WeatherModellingLevel)Conversions.ToByte(val4.InnerText);
			}
			val4 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/GlobalWeather");
			if (val4 != null)
			{
				closure$__322-2.$VB$Local_theScen.GlobalWeather = Weather.WeatherProfile.FromXML(ref val4);
			}
			string innerText2 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/TimeCompression").InnerText;
			if (Versioned.IsNumeric((object)innerText2))
			{
				try
				{
					closure$__322-2.$VB$Local_theScen.enumTimeCompression_0 = (enumTimeCompression)Conversions.ToByte(innerText2);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					closure$__322-2.$VB$Local_theScen.enumTimeCompression_0 = enumTimeCompression.OneSec;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				closure$__322-2.$VB$Local_theScen.enumTimeCompression_0 = (enumTimeCompression)Enum.Parse(typeof(enumTimeCompression), innerText2, ignoreCase: true);
			}
			closure$__322-2.$VB$Local_theScen.float_0 = XmlConvert.ToSingle(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/GameResolution").InnerText.Replace(",", "."));
			foreach (XmlNode item20 in childNodes13)
			{
				XmlNode theNode12 = item20;
				LoggedMessage loggedMessage = LoggedMessage.FromXML(ref theNode12, ref closure$__322-2.$VB$Local_ObjectsDictionary);
				if (loggedMessage != null)
				{
					closure$__322-2.$VB$Local_theScen.MessageLog.Add(loggedMessage);
				}
				closure$__322-2.$VB$Local_ItemsInstantiated++;
				closure$__322-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_PercentageComplete((double)closure$__322-2.$VB$Local_ItemsInstantiated / (double)closure$__322-2.$VB$Local_TotalItems);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/MessageIncrement");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.long_0 = Conversions.ToInteger(val.InnerText);
			}
			closure$__322-2.$VB$Local_theScen.UnitsAutoIncrement = Conversions.ToInteger(xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/UnitsAutoIncrement").InnerText);
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/MessageIncrement");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.long_0 = Conversions.ToInteger(val.InnerText);
			}
			if (xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CurrentSide") != null)
			{
				string innerText3 = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/CurrentSide").InnerText;
				Side[] sides_ReadOnly = closure$__322-2.$VB$Local_theScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (Operators.CompareString(side.Name, innerText3, false) == 0)
					{
						closure$__322-2.$VB$Local_theScen.SetCurrentSide(side);
					}
				}
			}
			closure$__322-2.$VB$Local_theScen.GameVersion = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/GameVersion").InnerText;
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LastSavedInScenEdit");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.LastSavedInScenEdit = true;
			}
			if (closure$__322-2.$VB$Local_theScen.LastSavedInScenEdit)
			{
				closure$__322-2.$VB$Local_theScen.ZeroHour = closure$__322-2.$VB$Local_theScen.dateTime_0;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_DetailedGunFireControl");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.DetailedGunFireControl);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_RealisticSubComms");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.RealisticSubComms);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_LandTypeEffects");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.LandTypeEffects);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_LandTypeEffects_Advanced");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.LandTypeEffects_Advanced);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_UnlimitedAirWeapons");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.UnlimitedBaseMagazines);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_UnlimitedBaseMags");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.UnlimitedBaseMagazines);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_CommsJamming");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.CommsJamming);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_AircraftDamage");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.AircraftDamage);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LandingPlan_InstLoad");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LandingPlan_ACS_NAW_Limitations");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.ACS_NAW_Limitations);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_DroneAutonomy");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.DroneAutonomyLevels);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_WeatherAffectsShipSpeed");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.WeatherAffectsShipSpeed);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Features_FixedSideColors");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.FixedSideColors);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_CommsDisruption");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/Realism_ASCMTerrainFollowing");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.ASCMTerrainFollowingRestriction);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/PointToPointComm");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.PointToPointComm);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/RealisticOrderChain");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.RealisticOrderChain);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/VariableBurnoutSpeed");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.VariableBurnoutSpeed);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LimitedSonobuoys");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.LimitedSonobuoysInMagazines);
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LuaXml");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.LuaXml = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/LuaXmlPassed");
			if (!Information.IsNothing((object)val))
			{
				closure$__322-2.$VB$Local_theScen.LuaXmlPassed = val.InnerText;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DefaultGuidedWeaponsVsAirTargetWRAToNEZ");
			if (val != null)
			{
				closure$__322-2.$VB$Local_theScen.DefaultGuidedWeaponsVsAirTargetWRASetting = Doctrine._WRA_FiringRange.NoEscapeZone;
			}
			val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/DefaultGuidedWeaponsVsAirTargetWRASetting");
			if (val != null && int.TryParse(val.InnerText, out var result2))
			{
				closure$__322-2.$VB$Local_theScen.DefaultGuidedWeaponsVsAirTargetWRASetting = (Doctrine._WRA_FiringRange)result2;
			}
			if (!GameGeneral.EnableLoadoutFilter)
			{
				GameGeneral.FlightGroupFilter = GameGeneral.FlightGroupFilterOptions.Equipment;
			}
			else
			{
				val = xmlDocument_wrapper.SelectSingleNode(closure$__322-2.$VB$Local_theScen, "/" + text, "/GroupFilter");
				if (val != null)
				{
					if (!Enum.TryParse<GameGeneral.FlightGroupFilterOptions>(val.InnerText, out var result3))
					{
						GameGeneral.FlightGroupFilter = GameGeneral.FlightGroupFilterOptions.Equipment;
					}
					else
					{
						GameGeneral.FlightGroupFilter = result3;
					}
				}
			}
			Side[] sides_ReadOnly2 = closure$__322-2.$VB$Local_theScen.Sides_ReadOnly;
			Side[] sides_ReadOnly4;
			checked
			{
				_Closure$__322-3 closure$__322-3 = default(_Closure$__322-3);
				for (int num4 = 0; num4 < sides_ReadOnly2.Length; num4++)
				{
					Side theSide2 = sides_ReadOnly2[num4];
					theSide2.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen, closure$__322-2.$VB$Local_ObjectsDictionary, GameIsRunning: false);
					List<Contact> list3 = new List<Contact>();
					list3.AddRange(theSide2.Contacts_List);
					foreach (Contact item21 in list3)
					{
						if (!item21.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref theSide2))
						{
							theSide2.Contacts.Remove(item21._ActualUnitID);
						}
						else if (item21.ActualUnit.get_UnitSide(SetSideOnly: false) != null)
						{
							if (item21.ActualUnit.get_IsAutoDetectable(theSide2) && item21.LastDetections.Count == 0 && item21.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
							{
								item21.IsAutoDetection = true;
								item21.AddDetectionRecord(new Contact.Detection_Struct(null, null, 0f, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, item21.ActualUnit.ParentScen.Time));
							}
						}
						else
						{
							theSide2.Contacts.Remove(item21._ActualUnitID);
						}
					}
					List<Contact> list4 = new List<Contact>();
					list4.AddRange(theSide2.BaseContacts_List);
					foreach (Contact item22 in list4)
					{
						if (item22.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen, ref closure$__322-2.$VB$Local_ObjectsDictionary, ref theSide2))
						{
							if (item22.ActualUnit.get_IsAutoDetectable(theSide2) && item22.LastDetections.Count == 0 && item22.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
							{
								item22.IsAutoDetection = true;
								item22.AddDetectionRecord(new Contact.Detection_Struct(null, null, 0f, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, item22.ActualUnit.ParentScen.Time));
							}
						}
						else
						{
							theSide2.BaseContacts.Remove(item22._ActualUnitID);
						}
					}
					foreach (KeyValuePair<string, Contact> contact in theSide2.Contacts)
					{
						if (string.IsNullOrEmpty(contact.Value.Name))
						{
							contact.Value.UpdateContactName(ref closure$__322-2.$VB$Local_theScen, ref theSide2, null, null, IsNCTRupdate: false, bool_5: false, GenerateMessage: false, "", LoggedMessage.MessageType.None, bool_6: false, SahreContacts: false);
						}
					}
					foreach (ReferencePoint refPoint in theSide2.RefPoints)
					{
						refPoint.PostDeserializationHousekeeping(closure$__322-2.$VB$Local_ObjectsDictionary);
					}
					foreach (Mission item23 in theSide2.get_MissionsTotal(closure$__322-2.$VB$Local_theScen))
					{
						if (Information.IsNothing((object)item23))
						{
							continue;
						}
						item23.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen, theSide2, GameIsRunning: false, ref closure$__322-2.$VB$Local_ObjectsDictionary);
						foreach (Mission.Flight flight in item23.FlightList)
						{
							if (!Information.IsNothing((object)flight) && flight.FlightPlan.Count() != 0)
							{
								Waypoint[] flightPlan = flight.FlightPlan;
								for (int num5 = 0; num5 < flightPlan.Length; num5++)
								{
									flightPlan[num5].PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen, theSide2, GameIsRunning: false);
								}
							}
						}
					}
					List<ActiveUnit> list5 = theSide2.Units.ToList();
					foreach (ActiveUnit item24 in list5)
					{
						closure$__322-3 = new _Closure$__322-3(closure$__322-3);
						if (Information.IsNothing((object)item24))
						{
							continue;
						}
						closure$__322-3.$VB$Local_theAU = item24;
						closure$__322-3.$VB$Local_theAU.Sensory.PostDeserializationHousekeeping_LocalAndPrivateContacts(ref closure$__322-3.$VB$Local_theAU, closure$__322-2.$VB$Local_ObjectsDictionary);
						foreach (KeyValuePair<string, CommNetwork> commNetwork in theSide2.CommNetworks)
						{
							Module_Unit.Unit unit = null;
							unit = commNetwork.Value.Members.SingleOrDefault((closure$__322-3.$I2 != null) ? closure$__322-3.$I2 : (closure$__322-3.$I2 = closure$__322-3._Lambda$__2));
							if (unit != null)
							{
								commNetwork.Value.Members.Remove(unit);
								commNetwork.Value.Members.Add(closure$__322-3.$VB$Local_theAU);
							}
						}
					}
				}
				foreach (ActiveUnit value7 in closure$__322-2.$VB$Local_theScen.ActiveUnits.Values)
				{
					value7?.PostDeserializationHousekeeping_Groupmembership(ref closure$__322-2.$VB$Local_theScen, closure$__322-2.$VB$Local_ObjectsDictionary);
				}
				List<ActiveUnit> list6 = new List<ActiveUnit>();
				foreach (ActiveUnit value8 in closure$__322-2.$VB$Local_theScen.ActiveUnits.Values)
				{
					value8.PostDeserializationHousekeeping_General(ref closure$__322-2.$VB$Local_theScen, closure$__322-2.$VB$Local_ObjectsDictionary, list6, GameIsRunning: false);
					if (value8.IsGroup)
					{
						continue;
					}
					List<CommLink> list7 = new List<CommLink>();
					list7.AddRange(value8.CommStuff.CommLinksEstablished_ReadOnly);
					foreach (CommLink item25 in list7)
					{
						try
						{
							item25.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_ObjectsDictionary);
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							value8.CommStuff.DropCommLink(item25);
							ex10?.Data.Add("Error at 200052", ex10.Message);
							GameGeneral.WriteExceptionsToLog(ex10);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					Sensor[] sensors_Cached = value8.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						sensor.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen);
						if (sensor.ParentPlatform == null)
						{
							sensor.ParentPlatform = value8;
						}
					}
				}
				foreach (ActiveUnit item26 in list6)
				{
					ActiveUnit value3 = item26;
					closure$__322-2.$VB$Local_theScen.ActiveUnits.TryRemove(value3.ObjectID, out value3);
				}
				foreach (Explosion explosion in closure$__322-2.$VB$Local_theScen.Explosions)
				{
					explosion.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_ObjectsDictionary);
				}
				foreach (UnguidedWeapon value9 in closure$__322-2.$VB$Local_theScen.UnguidedWeapons.Values)
				{
					value9.PostDeserializationHousekeeping(ref closure$__322-2.$VB$Local_theScen);
				}
				foreach (Group group in closure$__322-2.$VB$Local_theScen.Groups)
				{
					group.DeserializationInProgress = false;
				}
				closure$__322-2.$VB$Local_ObjectsDictionary.Clear();
				foreach (string loadingNotice in closure$__322-2.$VB$Local_theScen.LoadingNotices)
				{
					ErrorFeedback = ErrorFeedback + "\r\n" + loadingNotice + "\r\n";
				}
				closure$__322-2.$VB$Local_theScen.GuidedWeaponsInAir = null;
				closure$__322-2.$VB$Local_theScen.SonobuoysInWater = null;
				closure$__322-2.$VB$Local_theScen.AllWeaponsAlive = null;
				_ = closure$__322-2.$VB$Local_theScen.GuidedWeaponsInAir;
				closure$__322-2.$VB$Local_theScen.method_11();
				Side[] sides_ReadOnly3 = closure$__322-2.$VB$Local_theScen.Sides_ReadOnly;
				foreach (Side side2 in sides_ReadOnly3)
				{
					foreach (ActiveUnit unit2 in side2.Units)
					{
						if (unit2 == null || !unit2.IsAircraft || ((Aircraft)unit2).Loadout == null)
						{
							continue;
						}
						WeaponRec[] weapons = ((Aircraft)unit2).Loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons)
						{
							if (!weaponRec.get_ReferenceWeapon(unit2.ParentScen).IsWeaponPallet || weaponRec.get_ReferenceWeapon(unit2.ParentScen).Warheads.Count() <= 0)
							{
								continue;
							}
							Warhead[] warheads = weaponRec.get_ReferenceWeapon(unit2.ParentScen).Warheads;
							foreach (Warhead warhead in warheads)
							{
								if (warhead.get_CarriedWeapon(unit2.ParentScen) == null)
								{
									continue;
								}
								if (side2.Doctrine.WRA == null)
								{
									side2.Doctrine.WRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
								}
								if (!side2.Doctrine.WRA.ContainsKey(warhead.get_CarriedWeapon(unit2.ParentScen).DBID))
								{
									Weapon myWeapon = warhead.get_CarriedWeapon(unit2.ParentScen);
									Doctrine.WRA_Weapon value4 = new Doctrine.WRA_Weapon(ref myWeapon, unit2.ParentScen);
									if (!side2.Doctrine.WRA.ContainsKey(weaponRec.get_ReferenceWeapon(unit2.ParentScen).DBID))
									{
										side2.Doctrine.WRA[warhead.get_CarriedWeapon(unit2.ParentScen).DBID] = value4;
									}
								}
								if (unit2.Doctrine.WRA == null)
								{
									unit2.Doctrine.WRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
								}
								if (!unit2.Doctrine.WRA.ContainsKey(warhead.get_CarriedWeapon(unit2.ParentScen).DBID))
								{
									Weapon myWeapon = warhead.get_CarriedWeapon(unit2.ParentScen);
									Doctrine.WRA_Weapon value5 = new Doctrine.WRA_Weapon(ref myWeapon, unit2.ParentScen);
									if (!unit2.Doctrine.WRA.ContainsKey(warhead.get_CarriedWeapon(unit2.ParentScen).DBID))
									{
										unit2.Doctrine.WRA[warhead.get_CarriedWeapon(unit2.ParentScen).DBID] = value5;
									}
								}
							}
						}
					}
				}
				sides_ReadOnly4 = closure$__322-2.$VB$Local_theScen.Sides_ReadOnly;
			}
			foreach (Side side3 in sides_ReadOnly4)
			{
				foreach (ActiveUnit unit3 in side3.Units)
				{
					byte? b = (byte?)unit3?.AssignedMissionOrPackage()?.MissionClass;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true || !unit3.Navigator.HasFlightPlan)
					{
						continue;
					}
					Waypoint[] flightPlan2 = unit3.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
					foreach (Waypoint waypoint in flightPlan2)
					{
						if ((waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.WeaponTarget))
						{
							unit3.Navigator.AddUnitToTargeteeringList((Strike)unit3.ActiveMissionOrPackage(), waypoint);
						}
					}
				}
			}
			result = closure$__322-2.$VB$Local_theScen;
			end_IL_0120:;
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			ex12?.Data.Add("Error at 101023", ErrorFeedback);
			GameGeneral.WriteExceptionsToLog(ex12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return result;
	}

	public static Scenario smethod_0(string theFilename, ref string ErrorFeedback, Action<double> PercentageComplete)
	{
		if (PercentageComplete == null)
		{
			PercentageComplete = [SpecialName] (double d) =>
			{
			};
		}
		Scenario result;
		try
		{
			result = FromXmlText(File.ReadAllText(theFilename), ref ErrorFeedback, PercentageComplete);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101025", "");
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

	internal bool UsesHighFidelity()
	{
		return GameResolution == 0.1f;
	}

	public void Initialize()
	{
		GameGeneral.RegisteredExceptions.Clear();
		GameGeneral.VeryHighIntensityResolution = 5f;
		List<EventTrigger> list = new List<EventTrigger>();
		if (EventTriggers != null)
		{
			foreach (EventTrigger value in EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.ScenLoaded)
				{
					list.Add(value);
				}
			}
		}
		if (list.Count > 0)
		{
			FireEvents(list);
		}
		Side[] sides_ReadOnly = Sides_ReadOnly;
		int num = 0;
		while (true)
		{
			if (num < sides_ReadOnly.Length)
			{
				if (sides_ReadOnly[num].IsPlayerControlled)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		TriggerPlayerJoinedSideEvents();
	}

	public static string[] QueryScenario_ScenFileName(string ScenFileName, List<string> QueryKeys)
	{
		string[] array = new string[QueryKeys.Count - 1 + 1];
		string scenarioObject_AsXML = ScenContainer.LoadFromFile(ScenFileName).GetScenarioObject_AsXML();
		int num = QueryKeys.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			XmlReader val = XmlReader.Create((TextReader)new StringReader(scenarioObject_AsXML));
			XmlReader val2 = val;
			try
			{
				if (!val.ReadToDescendant(QueryKeys[i]))
				{
					array[i] = "";
				}
				else
				{
					array[i] = val.ReadElementContentAsString();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		return array;
	}

	public static string QueryScenario_ScenFileName(string ScenFileName, string Query)
	{
		new List<string>();
		return QueryScenario_ScenXML(ScenContainer.LoadFromFile(ScenFileName).GetScenarioObject_AsXML(), Query);
	}

	public static string QueryScenario_ScenXML(string ScenXML, string Query)
	{
		string result;
		try
		{
			XmlReader val = XmlReader.Create((TextReader)new StringReader(ScenXML));
			XmlReader val2 = val;
			try
			{
				result = ((!val.ReadToDescendant(Query)) ? null : val.ReadElementContentAsString());
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101285", "");
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

	protected void AddToWeaponLists(ActiveUnit theAU, List<Weapon> allWeapons, PooledList<Weapon> guidedWeapons, List<Weapon> decoys, List<Weapon> sonobuoys)
	{
		if (!theAU.IsWeapon)
		{
			return;
		}
		Weapon weapon = (Weapon)theAU;
		allWeapons.Add(weapon);
		if (weapon.IsNuke.Value)
		{
			AnyActiveWeaponEffectThreats = true;
		}
		if (!weapon.IsGuidedWeapon() && !weapon.IsGuidedProjectile && !weapon.IsBallisticMissile && !weapon.IsReEntryVehicle && (weapon.Type != Weapon._WeaponType.Torpedo || weapon.Comms_ReadOnly.Length <= 0))
		{
			if (weapon.IsMobileDecoy)
			{
				decoys.Add(weapon);
			}
			else if (weapon.Type == Weapon._WeaponType.Sonobuoy)
			{
				sonobuoys.Add(weapon);
			}
		}
		else
		{
			if (guidedWeapons == null)
			{
				guidedWeapons = new PooledList<Weapon>();
			}
			guidedWeapons.Add(weapon);
		}
	}

	public void PrePulseHouseKeeping(float elaspedTime)
	{
		try
		{
			AnyActiveWeaponEffectThreats = false;
			GuidedWeaponsInAir = null;
			SonobuoysInWater = null;
			AllWeaponsAlive = null;
			Cache_PrimaryTargetForWhichPlatforms.Clear();
			Cache_UnitsAffectedByJamming.Clear();
			Cache_UnitLocalTracksOnContacts.Clear();
			ActiveUnit[] array = ActiveUnits_List.ToArray();
			int num = array.Count();
			ActiveUnit activeUnit = null;
			List<Weapon> allWeapons = new List<Weapon>();
			List<Weapon> decoys = new List<Weapon>();
			List<Weapon> sonobuoys = new List<Weapon>();
			bool generateAutoDetectableUnitsOnThisPulse = GenerateAutoDetectableUnitsOnThisPulse;
			Side[] array2 = null;
			Side side = null;
			int num2 = side_0.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				side_0[i].IndexAtSidesList = i;
			}
			int num3 = default(int);
			if (generateAutoDetectableUnitsOnThisPulse)
			{
				array2 = (Side[])side_0.Clone();
				num3 = array2.Count();
				pooledList_2 = new PooledList<PooledList<ActiveUnit>>();
				int num4 = num3 - 1;
				for (int j = 0; j <= num4; j++)
				{
					pooledList_2.Add(new PooledList<ActiveUnit>());
				}
			}
			int num5 = num - 1;
			PooledList<Weapon> guidedWeapons = default(PooledList<Weapon>);
			for (int k = 0; k <= num5; k++)
			{
				activeUnit = array[k];
				if (activeUnit == null)
				{
					continue;
				}
				AddToWeaponLists(activeUnit, allWeapons, guidedWeapons, decoys, sonobuoys);
				if (!generateAutoDetectableUnitsOnThisPulse)
				{
					continue;
				}
				int num6 = num3 - 1;
				for (int l = 0; l <= num6; l++)
				{
					side = array2[l];
					if (side != null && activeUnit.get_UnitSide(SetSideOnly: false) != side && activeUnit.IsOperating() && activeUnit.get_IsAutoDetectable(side) && !Module_Side.IsAlliedWithThisSide(activeUnit.get_UnitSide(SetSideOnly: false), side))
					{
						pooledList_2[l].Add(activeUnit);
					}
				}
			}
			list_2 = allWeapons;
			pooledList_1 = guidedWeapons;
			list_0 = decoys;
			list_1 = sonobuoys;
			if (generateAutoDetectableUnitsOnThisPulse)
			{
				int num7 = num3 - 1;
				for (int m = 0; m <= num7; m++)
				{
					side = array2[m];
					if (side != null)
					{
						side._AutodetectableUnitsThisPulse = new List<ActiveUnit>(pooledList_2[m]);
					}
				}
			}
			foreach (PooledList<ActiveUnit> item in pooledList_2)
			{
				item.Dispose();
			}
			pooledList_2.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101027", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FireEvents(List<EventTrigger> TriggersFulfilled)
	{
		ActiveUnit activeUnit = null;
		Contact contact = null;
		try
		{
			if (SimEvents == null)
			{
				return;
			}
			foreach (EventTrigger item in TriggersFulfilled)
			{
				List<SimEvent> list;
				try
				{
					list = new List<SimEvent>(SimEvents?.Values);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				foreach (SimEvent item2 in list)
				{
					if (!item2.IsActive)
					{
						continue;
					}
					LuaSandBox.Singleton().EventX = item2;
					if (!item2.Triggers.Contains(item))
					{
						continue;
					}
					if (!item2.get_ConditionsAreMet(this))
					{
						if (item2.IsShown)
						{
							AddMessage("Event: '" + item2.Description + "' was triggered but did NOT fire (at least one condition failed).", "Event triggered but NOT fired (insufficient conditions)", LoggedMessage.MessageType.EventEngine, 1, "");
						}
						if (!item2.IsRepeatable)
						{
							item2.IsActive = false;
						}
						if (item.Type == EventTrigger.EventTriggerType.Time)
						{
							item2.IsActive = false;
						}
						continue;
					}
					if (item2.Probability != 100 && GameGeneral.GlobalRNG.Next(0, 100) > item2.Probability)
					{
						if (item2.IsShown)
						{
							AddMessage("Event: '" + item2.Description + "' was triggered but did NOT fire (failed probability check).", "Event triggered but not fired", LoggedMessage.MessageType.EventEngine, 1, "");
						}
						if (!item2.IsRepeatable)
						{
							item2.IsActive = false;
						}
						continue;
					}
					ActiveUnit activeUnit2 = null;
					activeUnit = null;
					contact = null;
					List<Sensor> sensorsThatMadeDetection = null;
					if (item.Type == EventTrigger.EventTriggerType.UnitRemainsInArea)
					{
						activeUnit2 = ((EventTrigger_UnitRemainsInArea)item).CulpritUnit;
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitEntersArea)
					{
						activeUnit2 = ((EventTrigger_UnitEntersArea)item).CulpritUnit;
						if (!Information.IsNothing((object)activeUnit2))
						{
							if (((EventTrigger_UnitEntersArea)item).Modifier_EXIT)
							{
								if (((EventTrigger_UnitEntersArea)item).JustEnteredArea)
								{
									activeUnit2.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitEntersArea)item).ObjectID);
									activeUnit2 = null;
									continue;
								}
								if (((EventTrigger_UnitEntersArea)item).LeavesArea)
								{
									activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
								}
							}
							else if (((EventTrigger_UnitEntersArea)item).JustEnteredArea)
							{
								activeUnit2.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitEntersArea)item).ObjectID);
							}
							else if (((EventTrigger_UnitEntersArea)item).LeavesArea)
							{
								activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
							}
							if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
							{
								activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
							}
						}
						else if (!((EventTrigger_UnitEntersArea)item).Modifier_NOT)
						{
							continue;
						}
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitDamaged)
					{
						activeUnit2 = ((EventTrigger_UnitDamaged)item).DamagedUnit;
						activeUnit = ((EventTrigger_UnitDamaged)item).DamagingUnit;
						Scenario_LuaSandbox.UnitY = null;
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitDestroyed)
					{
						activeUnit2 = ((EventTrigger_UnitDestroyed)item).DestroyedUnit;
						activeUnit = ((EventTrigger_UnitDestroyed)item).DamagingUnit;
						if (activeUnit2.IsBeingPickedUp && activeUnit2.PickUpUnit != null)
						{
							activeUnit = activeUnit2.PickUpUnit;
						}
						Scenario_LuaSandbox.UnitY = null;
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitDetected)
					{
						activeUnit2 = ((EventTrigger_UnitDetected)item).DetectedUnit;
						activeUnit = ((EventTrigger_UnitDetected)item).DetectingUnit;
						sensorsThatMadeDetection = ((EventTrigger_UnitDetected)item).SensorsThatMadeDetection;
						contact = ((EventTrigger_UnitDetected)item).DetectedAsContact;
						if (((EventTrigger_UnitDetected)item).DetectedInArea.HasValue)
						{
							bool? detectedInArea = ((EventTrigger_UnitDetected)item).DetectedInArea;
							detectedInArea = detectedInArea;
							if (detectedInArea == true && !Information.IsNothing((object)contact))
							{
								contact.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitDetected)item).ObjectID);
							}
						}
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitBaseStatus)
					{
						activeUnit2 = ((EventTrigger_UnitBaseStatus)item).CulpritUnit;
					}
					else if (item.Type == EventTrigger.EventTriggerType.UnitCargoMoved)
					{
						_ = ((EventTrigger_UnitCargoMoved)item).postEvent;
						activeUnit2 = ((EventTrigger_UnitCargoMoved)item).BaseUnit;
					}
					if (!Information.IsNothing((object)activeUnit2))
					{
						Scenario_LuaSandbox.UnitX = activeUnit2;
					}
					if (!(Information.IsNothing((object)activeUnit2) & Information.IsNothing((object)activeUnit) & Information.IsNothing((object)contact)))
					{
						if (Information.IsNothing((object)activeUnit))
						{
							LuaSandBox.Singleton().UnitY = null;
						}
						else
						{
							Scenario_LuaSandbox.UnitY = activeUnit;
							Scenario_LuaSandbox.SensorsThatMadeDetection = sensorsThatMadeDetection;
						}
						if (!Information.IsNothing((object)contact))
						{
							Scenario_LuaSandbox.UnitC = contact;
						}
						else
						{
							LuaSandBox.Singleton().UnitC = null;
						}
					}
					if (item2.IsShown)
					{
						AddMessage("Event: '" + item2.Description + "' has been fired.", "Scenario event fired", LoggedMessage.MessageType.EventEngine, 1, "");
					}
					if (!item2.IsRepeatable)
					{
						item2.IsActive = false;
					}
					if (item.Type == EventTrigger.EventTriggerType.Time)
					{
						item2.IsActive = false;
					}
					List<EventAction> list2 = item2.Actions.ToList();
					foreach (EventAction item3 in list2)
					{
						item3.Execute(this, item2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101028", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Side GetSideByID(string id)
	{
		if (!string.IsNullOrEmpty(id))
		{
			IEnumerable<Side> enumerable = side_0.Where([SpecialName] (Side s) => Operators.CompareString(s.ObjectID, id, false) == 0);
			if (enumerable != null && enumerable.Count() > 0)
			{
				return enumerable.FirstOrDefault();
			}
		}
		return null;
	}

	public void EndScenario()
	{
		bool_1 = true;
		scenCompletedEventHandler_0?.Invoke(this);
	}

	public void AdjustGameResolution()
	{
		if (!LockFidelityResolution)
		{
			if (!RunningHeadless)
			{
				GameResolution = GetAdjustedGameResolution(enumTimeCompression_0);
			}
			else
			{
				GameResolution = GetAdjustedGameResolution(GameGeneral.Global_PulseResolution);
			}
		}
	}

	internal bool anyAntiaerospaceWeaponsInAir()
	{
		PooledList<Weapon> guidedWeaponsInAir = GuidedWeaponsInAir;
		bool result = default(bool);
		foreach (Weapon item in guidedWeaponsInAir)
		{
			if (!item.IsAerospaceUnit)
			{
				continue;
			}
			int num;
			if (!item.IsAAWCapable)
			{
				if (!item.IsASAT)
				{
					if (!item.IsABMCapable())
					{
						continue;
					}
					num = 1;
				}
				else
				{
					num = 1;
				}
			}
			else
			{
				num = 1;
			}
			result = (byte)num != 0;
			return result;
		}
		List<UnguidedWeapon> list = new List<UnguidedWeapon>(UnguidedWeapons.Values);
		foreach (UnguidedWeapon item2 in list)
		{
			if (item2.IsAerospaceWeapon())
			{
				result = true;
				return result;
			}
		}
		return result;
	}

	internal bool anyHGVNearOrInTerminalDivePhase()
	{
		PooledList<Weapon> guidedWeaponsInAir = GuidedWeaponsInAir;
		bool result = default(bool);
		foreach (Weapon item in guidedWeaponsInAir)
		{
			if (item.IsHGV && ((HGV_AI)item.AI).NearOrInTerminalDive)
			{
				result = true;
				return result;
			}
		}
		return result;
	}

	internal bool anyArcraftHeadingToOrPerformingAAR()
	{
		ICollection<ActiveUnit> values = ActiveUnits.Values;
		bool result = default(bool);
		foreach (ActiveUnit item in values)
		{
			if (item != null && item.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)item;
				if (aircraft.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && aircraft.AirOps.A2AR_Destination != null)
				{
					result = true;
					return result;
				}
				if (item.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					result = true;
					return result;
				}
			}
		}
		return result;
	}

	internal float GetAdjustedGameResolution(enumTimeCompression TheTimeCompression)
	{
		switch (TheTimeCompression)
		{
		case enumTimeCompression.Coarse_FiveSecSlice:
			if (!GameGeneral.Beta_FlameSimSpeedTimeSync && (!(GameGeneral.VeryHighIntensityResolution > 0f) || !GameGeneral.UseDynamicResolution) && !anyHGVNearOrInTerminalDivePhase())
			{
				if (!anyArcraftHeadingToOrPerformingAAR())
				{
					if ((GameGeneral.HighIntensityResolution > 0f && GameGeneral.UseDynamicResolution) || anyAntiaerospaceWeaponsInAir())
					{
						return 1f;
					}
					return 5f;
				}
				GameGeneral.HighIntensityResolution = 60f;
				return 1f;
			}
			return 0.1f;
		default:
			return 0.1f;
		case enumTimeCompression.Coarse_OneSecSlice:
			if (!GameGeneral.Beta_FlameSimSpeedTimeSync && (!(GameGeneral.VeryHighIntensityResolution > 0f) || !GameGeneral.UseDynamicResolution) && !anyHGVNearOrInTerminalDivePhase())
			{
				return 1f;
			}
			return 0.1f;
		}
	}

	internal float GetAdjustedGameResolution(float TheSimResolution)
	{
		if (TheSimResolution == 5f)
		{
			return GetAdjustedGameResolution(enumTimeCompression.Coarse_FiveSecSlice);
		}
		if (TheSimResolution == 1f)
		{
			return GetAdjustedGameResolution(enumTimeCompression.Coarse_OneSecSlice);
		}
		return GetAdjustedGameResolution(enumTimeCompression.OneSec);
	}

	public void TimeCompression_Increase()
	{
		if (!LockFidelityResolution && enumTimeCompression_0 < enumTimeCompression.Coarse_FiveSecSlice)
		{
			enumTimeCompression_0++;
			AdjustGameResolution();
			timeCompressionChangedEventHandler_0?.Invoke();
		}
	}

	public void TimeCompression_Decrease()
	{
		if (!LockFidelityResolution && (int)enumTimeCompression_0 > 0)
		{
			enumTimeCompression_0--;
			AdjustGameResolution();
			timeCompressionChangedEventHandler_0?.Invoke();
		}
	}

	public void TimeCompression_Set(enumTimeCompression theValue)
	{
		if (!LockFidelityResolution)
		{
			enumTimeCompression_0 = theValue;
			AdjustGameResolution();
			timeCompressionChangedEventHandler_0?.Invoke();
		}
	}

	internal bool SetSimulationFidelity(float Fidelity, bool Lock = false, bool DisplayInLog = true)
	{
		if (Fidelity != 0.1f && Fidelity != 1f && Fidelity != 5f)
		{
			return false;
		}
		if (LockFidelityResolution != Lock)
		{
			LockFidelityResolution = Lock;
		}
		if (DisplayInLog)
		{
			AddMessage("Changed simulation resolution from " + GameResolution.ToString("#.#") + " to " + Fidelity.ToString("#.#") + " (Locked)", "Simulation resolution changed", LoggedMessage.MessageType.SpecialMessage, 1, "");
		}
		GameResolution = Fidelity;
		return true;
	}

	public void TimeCompression_Set_Core(enumTimeCompression theValue)
	{
		enumTimeCompression_0 = theValue;
		AdjustGameResolution();
	}

	public void SetCurrentSide(Side theSide)
	{
		side_1 = theSide;
		currentSideChangedEventHandler_0?.Invoke(this);
	}

	public Side GetCurrentSide()
	{
		if (Sides_ReadOnly.Length != 0)
		{
			if (side_1 != null)
			{
				return side_1;
			}
			return Sides_ReadOnly[0];
		}
		return null;
	}

	public void BranchToNewTimeline()
	{
		ParentTimelineID = TimelineID;
		TimelineID = Guid.NewGuid().ToString();
	}

	public Scenario()
	{
		RunningHeadless = false;
		RunningInRTMPHost = false;
		ActiveUnits = new ConcurrentObservableDictionary<string, ActiveUnit>(StringComparer.Ordinal);
		ActiveUnitsSyncLock = new LockObject();
		Groups = new TList<Group>();
		list_0 = new List<Weapon>();
		list_1 = new List<Weapon>();
		list_2 = new List<Weapon>();
		side_0 = new Side[0];
		hashSet_0 = new HashSet<ActiveUnit>();
		list_3 = new List<UnguidedWeapon>();
		list_4 = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		DefaultGuidedWeaponsVsAirTargetWRASetting = Doctrine._WRA_FiringRange.NotConfigured;
		ScenAttachments = new System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		concurrentQueue_0 = new ConcurrentQueue<LoggedMessage>();
		MessageLogFilePath = string.Empty;
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		ElapsedTimeSinceLastSecondChangeCheck = 1f;
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<long, bool>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_UnitsAffectedByJamming = new ConcurrentDictionary<ActiveUnit, bool>();
		Cache_RocketThrusts = new ConcurrentDictionary<int, double>();
		AllowTimescale1XMessageSetting = true;
		RoadSystem = new RoadSystem(GlobalInstance: true);
		FacilityTypeDictionary = new Dictionary<int, Facility.FacilityType>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>(StringComparer.Ordinal);
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<int, Doctrine.WRA_FiringDoctrineEntry>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WeaponTypes = new ConcurrentPagedArray<Weapon._WeaponType>();
		Cache_UnitLocalTracksOnContacts = new LockedDictionary<(ActiveUnit, Contact, float, Sensor.Sensor_Type), bool>();
		Cache_WeaponIsABMOptimized = new ConcurrentPagedArray<bool>();
		Cache_WeaponIsABMCapable = new ConcurrentPagedArray<bool>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		GlobalWeather = Weather.DefaultWeather();
		MissionPlannerErrorList = new TList<MDSP_Error>();
		EventTriggers = new ConcurrentObservableDictionary<string, EventTrigger>();
		EventConditions = new ConcurrentObservableDictionary<string, EventCondition>();
		EventActions = new ConcurrentObservableDictionary<string, EventAction>();
		SimEvents = new ConcurrentObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		list_7 = new List<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new ObservableList<WaterSplash>();
		GroundImpacts = new ObservableList<GroundImpact>();
		UnguidedWeapons = new ConcurrentObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new System.Collections.ObjectModel.ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>(useReadLock: false);
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		lockObject_2 = new LockObject();
		lockObject_3 = new LockObject();
		writing = new LockObject();
		lockObject_5 = new LockObject();
		pooledList_2 = new PooledList<PooledList<ActiveUnit>>();
		lockObject_6 = new LockObject();
		WeaponFeedBackMessage = new List<string>();
		list_8 = new List<Aircraft>();
		AreaAlreadyValidated = new List<AreaValidatedObjects>();
		LastTransmissionId = 0;
		CommDALError = new Dictionary<int, string>();
		TimelineID = Guid.NewGuid().ToString();
		string_0 = Guid.NewGuid().ToString();
		ZeroHour = dateTime_0;
	}

	public Scenario(string theTitle, string theDescription, string theFileName)
	{
		RunningHeadless = false;
		RunningInRTMPHost = false;
		ActiveUnits = new ConcurrentObservableDictionary<string, ActiveUnit>(StringComparer.Ordinal);
		ActiveUnitsSyncLock = new LockObject();
		Groups = new TList<Group>();
		list_0 = new List<Weapon>();
		list_1 = new List<Weapon>();
		list_2 = new List<Weapon>();
		side_0 = new Side[0];
		hashSet_0 = new HashSet<ActiveUnit>();
		list_3 = new List<UnguidedWeapon>();
		list_4 = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		DefaultGuidedWeaponsVsAirTargetWRASetting = Doctrine._WRA_FiringRange.NotConfigured;
		ScenAttachments = new System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		concurrentQueue_0 = new ConcurrentQueue<LoggedMessage>();
		MessageLogFilePath = string.Empty;
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		ElapsedTimeSinceLastSecondChangeCheck = 1f;
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<long, bool>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_UnitsAffectedByJamming = new ConcurrentDictionary<ActiveUnit, bool>();
		Cache_RocketThrusts = new ConcurrentDictionary<int, double>();
		AllowTimescale1XMessageSetting = true;
		RoadSystem = new RoadSystem(GlobalInstance: true);
		FacilityTypeDictionary = new Dictionary<int, Facility.FacilityType>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>(StringComparer.Ordinal);
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<int, Doctrine.WRA_FiringDoctrineEntry>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WeaponTypes = new ConcurrentPagedArray<Weapon._WeaponType>();
		Cache_UnitLocalTracksOnContacts = new LockedDictionary<(ActiveUnit, Contact, float, Sensor.Sensor_Type), bool>();
		Cache_WeaponIsABMOptimized = new ConcurrentPagedArray<bool>();
		Cache_WeaponIsABMCapable = new ConcurrentPagedArray<bool>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		GlobalWeather = Weather.DefaultWeather();
		MissionPlannerErrorList = new TList<MDSP_Error>();
		EventTriggers = new ConcurrentObservableDictionary<string, EventTrigger>();
		EventConditions = new ConcurrentObservableDictionary<string, EventCondition>();
		EventActions = new ConcurrentObservableDictionary<string, EventAction>();
		SimEvents = new ConcurrentObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		list_7 = new List<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new ObservableList<WaterSplash>();
		GroundImpacts = new ObservableList<GroundImpact>();
		UnguidedWeapons = new ConcurrentObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new System.Collections.ObjectModel.ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>(useReadLock: false);
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		lockObject_2 = new LockObject();
		lockObject_3 = new LockObject();
		writing = new LockObject();
		lockObject_5 = new LockObject();
		pooledList_2 = new PooledList<PooledList<ActiveUnit>>();
		lockObject_6 = new LockObject();
		WeaponFeedBackMessage = new List<string>();
		list_8 = new List<Aircraft>();
		AreaAlreadyValidated = new List<AreaValidatedObjects>();
		LastTransmissionId = 0;
		CommDALError = new Dictionary<int, string>();
		Title = theTitle;
		Description = theDescription;
		FileName = theFileName;
		this.set_Time(ManualChange: false, DateTime.UtcNow);
		TimelineID = Guid.NewGuid().ToString();
		string_0 = Guid.NewGuid().ToString();
		ZeroHour = dateTime_0;
	}

	public Scenario(string string_7)
	{
		RunningHeadless = false;
		RunningInRTMPHost = false;
		ActiveUnits = new ConcurrentObservableDictionary<string, ActiveUnit>(StringComparer.Ordinal);
		ActiveUnitsSyncLock = new LockObject();
		Groups = new TList<Group>();
		list_0 = new List<Weapon>();
		list_1 = new List<Weapon>();
		list_2 = new List<Weapon>();
		side_0 = new Side[0];
		hashSet_0 = new HashSet<ActiveUnit>();
		list_3 = new List<UnguidedWeapon>();
		list_4 = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		DefaultGuidedWeaponsVsAirTargetWRASetting = Doctrine._WRA_FiringRange.NotConfigured;
		ScenAttachments = new System.Collections.ObjectModel.ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		concurrentQueue_0 = new ConcurrentQueue<LoggedMessage>();
		MessageLogFilePath = string.Empty;
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		ElapsedTimeSinceLastSecondChangeCheck = 1f;
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<long, bool>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_UnitsAffectedByJamming = new ConcurrentDictionary<ActiveUnit, bool>();
		Cache_RocketThrusts = new ConcurrentDictionary<int, double>();
		AllowTimescale1XMessageSetting = true;
		RoadSystem = new RoadSystem(GlobalInstance: true);
		FacilityTypeDictionary = new Dictionary<int, Facility.FacilityType>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>(StringComparer.Ordinal);
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<int, Doctrine.WRA_FiringDoctrineEntry>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WeaponTypes = new ConcurrentPagedArray<Weapon._WeaponType>();
		Cache_UnitLocalTracksOnContacts = new LockedDictionary<(ActiveUnit, Contact, float, Sensor.Sensor_Type), bool>();
		Cache_WeaponIsABMOptimized = new ConcurrentPagedArray<bool>();
		Cache_WeaponIsABMCapable = new ConcurrentPagedArray<bool>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		GlobalWeather = Weather.DefaultWeather();
		MissionPlannerErrorList = new TList<MDSP_Error>();
		EventTriggers = new ConcurrentObservableDictionary<string, EventTrigger>();
		EventConditions = new ConcurrentObservableDictionary<string, EventCondition>();
		EventActions = new ConcurrentObservableDictionary<string, EventAction>();
		SimEvents = new ConcurrentObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		list_7 = new List<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new ObservableList<WaterSplash>();
		GroundImpacts = new ObservableList<GroundImpact>();
		UnguidedWeapons = new ConcurrentObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new System.Collections.ObjectModel.ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>(useReadLock: false);
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		lockObject_2 = new LockObject();
		lockObject_3 = new LockObject();
		writing = new LockObject();
		lockObject_5 = new LockObject();
		pooledList_2 = new PooledList<PooledList<ActiveUnit>>();
		lockObject_6 = new LockObject();
		WeaponFeedBackMessage = new List<string>();
		list_8 = new List<Aircraft>();
		AreaAlreadyValidated = new List<AreaValidatedObjects>();
		LastTransmissionId = 0;
		CommDALError = new Dictionary<int, string>();
		dateTime_0 = DateAndTime.Now.ToUniversalTime();
		DBUsed = string_7;
		TimelineID = Guid.NewGuid().ToString();
		string_0 = Guid.NewGuid().ToString();
		ZeroHour = dateTime_0;
	}

	public void MessageIncrement_Add1()
	{
		long_0++;
	}

	private void method_1()
	{
		CurrentlyInsertingMessages = true;
		_Closure$__416-0 closure$__416- = default(_Closure$__416-0);
		_Closure$__416-1 closure$__416-2 = default(_Closure$__416-1);
		_Closure$__416-2 closure$__416-3 = default(_Closure$__416-2);
		while (true)
		{
			ConcurrentQueue<LoggedMessage> concurrentQueue = concurrentQueue_0;
			bool? flag = ((concurrentQueue != null) ? new bool?(concurrentQueue.Count > 0) : ((bool?)null));
			if (((!flag) ?? false) || !CurrentlyInsertingMessages || !flag.HasValue)
			{
				break;
			}
			try
			{
				closure$__416- = new _Closure$__416-0(closure$__416-);
				closure$__416-.$VB$Me = this;
				concurrentQueue_0.TryDequeue(out var result);
				if (result == null)
				{
					continue;
				}
				closure$__416-.$VB$Local_AlreadyHaveMessage = false;
				closure$__416-.$VB$Local_theNewM_Side = result.Side;
				closure$__416-.$VB$Local_theNewM_TimeStamp = result.Timestamp;
				closure$__416-.$VB$Local_theNewM_Text = result.Text;
				List<LoggedMessage> messageLog = MessageLog;
				closure$__416-.$VB$Local_theNewM_TimeStamp_ticks = result.Timestamp_ticks;
				if (GameGeneral.DedupAlliedMessages && !RunningHeadless && closure$__416-.$VB$Local_theNewM_Side != null)
				{
					try
					{
						Parallel.ForEach(messageLog, closure$__416-._Lambda$__0);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				if (!GameGeneral.DedupAlliedMessages || !closure$__416-.$VB$Local_AlreadyHaveMessage)
				{
					MessageLog.Add(result);
				}
				if (closure$__416-.$VB$Local_theNewM_Side == null || !GameGeneral.DedupAlliedMessages)
				{
					continue;
				}
				LoggedMessage.MessageType type = result.Type;
				if ((type - 1 > LoggedMessage.MessageType.NewContact && type - 6 > LoggedMessage.MessageType.NewContact && type - 19 > LoggedMessage.MessageType.WeaponEndgame) || Sides_ReadOnly == null)
				{
					continue;
				}
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					closure$__416-2 = new _Closure$__416-1(closure$__416-2);
					closure$__416-2.$VB$NonLocal_$VB$Closure_2 = closure$__416-;
					closure$__416-2.$VB$Local_ASide = sides_ReadOnly[i];
					if (closure$__416-2.$VB$Local_ASide == result.Side || result.Side.get_ConsidersThisSideToBe(closure$__416-2.$VB$Local_ASide, (Scenario)null) != Misc.PostureStance.Friendly)
					{
						continue;
					}
					closure$__416-3 = new _Closure$__416-2(closure$__416-3);
					closure$__416-3.$VB$NonLocal_$VB$Closure_3 = closure$__416-2;
					closure$__416-3.$VB$Local_AlreadyHaveMessage2 = false;
					if (!RunningHeadless)
					{
						try
						{
							Parallel.ForEach(messageLog, closure$__416-3._Lambda$__1);
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
					if (!closure$__416-3.$VB$Local_AlreadyHaveMessage2)
					{
						MessageIncrement_Add1();
						LoggedMessage item = new LoggedMessage(long_0, result.Text, result.Summary, result.Type, result.Timestamp, result.ReporterID, result.Level, closure$__416-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_ASide, result.Location);
						MessageLog.Add(item);
					}
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		CurrentlyInsertingMessages = false;
		EventWaitHandle_FinishPulse.Set();
	}

	public void AddMessage(LoggedMessage theNewM)
	{
		if (theNewM == null)
		{
			return;
		}
		newMessageEventHandler_0?.Invoke(theNewM);
		if (SimConfiguration.DefaultGamePreferences.MessageLogSettings[theNewM.Type].ShowOnMessageLog)
		{
			if (MessageLog == null)
			{
				MessageLog = new List<LoggedMessage>();
			}
			if (concurrentQueue_0 == null)
			{
				concurrentQueue_0 = new ConcurrentQueue<LoggedMessage>();
			}
			concurrentQueue_0.Enqueue(theNewM);
			if (!CurrentlyInsertingMessages)
			{
				CurrentlyInsertingMessages = true;
				Task.Factory.StartNew(method_1);
			}
		}
		if (SimConfiguration.DefaultGamePreferences.MessageLogSettings[theNewM.Type].PopUp)
		{
			UnhandledPopUpMessages?.Enqueue(theNewM);
		}
		if (AllowTimescale1XMessageSetting && SimConfiguration.DefaultGamePreferences.MessageLogSettings[theNewM.Type].bool_0 && theNewM.Side == GetCurrentSide())
		{
			TimeCompression_Set(enumTimeCompression.OneSec);
		}
	}

	public void AddMessage_ToUnit(string MessageText, string MessageSummary, LoggedMessage.MessageType MessageType, byte MessageLevel, string ReporterID, Side theSide = null, ActiveUnit theLocation = null, bool theForceMapRecentre = false, DateTime? TimeStamp = null, bool AddBark = false)
	{
		AddMessage(MessageText, MessageSummary, MessageType, MessageLevel, ReporterID, theSide, theLocation.Location, theForceMapRecentre, TimeStamp);
		if (AddBark)
		{
			Notification_Bark.Create_UnitBehaviour(theLocation, MessageText, Color.White);
		}
	}

	public void AddMessage(string MessageText, string MessageSummary, LoggedMessage.MessageType MessageType, byte MessageLevel, string ReporterID, Side theSide = null, Geopoint_Struct theLocation = default(Geopoint_Struct), bool theForceMapRecentre = false, DateTime? TimeStamp = null, bool AddBark = false)
	{
		if (theSide != null && theSide.AwarenessLevel == Side.AwarenessLevel_Enum.Blind && new List<LoggedMessage.MessageType>
		{
			LoggedMessage.MessageType.NewContact,
			LoggedMessage.MessageType.ContactChange,
			LoggedMessage.MessageType.NewWeaponContact,
			LoggedMessage.MessageType.NewMineContact,
			LoggedMessage.MessageType.NewAirContact,
			LoggedMessage.MessageType.NewSurfaceContact,
			LoggedMessage.MessageType.NewUnderwaterContact,
			LoggedMessage.MessageType.NewGroundContact
		}.Contains(MessageType))
		{
			return;
		}
		try
		{
			if (MessageType != LoggedMessage.MessageType.UnguidedWeaponModifiers)
			{
				if (long_0 == long.MaxValue)
				{
					long_0 = 1L;
				}
				else
				{
					long_0++;
				}
				DateTime value = dateTime_0;
				if (TimeStamp.HasValue)
				{
					value = TimeStamp.Value;
				}
				LoggedMessage theNewM = new LoggedMessage(long_0, MessageText, MessageSummary, MessageType, value, ReporterID, MessageLevel, theSide, theLocation, theForceMapRecentre);
				if (AddBark && SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark == Game.GamePreferences.Unit_Behaviour_Bark.All)
				{
					Notification_Bark.Create(theLocation, MessageText, Color.White, MoveUpward: true, Fades: true, 2f);
				}
				AddMessage(theNewM);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101031", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CleanUpExplosions()
	{
		try
		{
			List<Explosion> list = new List<Explosion>();
			foreach (Explosion explosion in Explosions)
			{
				if (explosion.HasExpired)
				{
					list.Add(explosion);
				}
			}
			new List<string>();
			foreach (Explosion item in list)
			{
				if (item.TopParentExplosion != null)
				{
					if (!list_7.Contains(item.TopParentExplosion))
					{
						list_7.Add(item.TopParentExplosion);
					}
				}
				else
				{
					Debugger.Break();
				}
				item.MarkAsCleanedUp();
				Explosions.Remove(item);
			}
			List<Explosion> list2 = new List<Explosion>();
			list2 = Misc.GetClone(list_7);
			using List<Explosion>.Enumerator enumerator3 = list2.GetEnumerator();
			Explosion current3;
			do
			{
				if (enumerator3.MoveNext())
				{
					current3 = enumerator3.Current;
					continue;
				}
				return;
			}
			while (current3.isWaitingSubExplosionEvaluation() || current3.isWaitingSubExplosionCleanUp());
			current3.ExportExplosionResults(this);
			list_7.Remove(current3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101032", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CleanUpWeaponImpacts()
	{
		try
		{
			List<WeaponImpact> list = new List<WeaponImpact>();
			foreach (WeaponImpact weaponImpact in WeaponImpacts)
			{
				if (weaponImpact.Age > 5f)
				{
					list.Add(weaponImpact);
				}
			}
			foreach (WeaponImpact item in list)
			{
				WeaponImpacts.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324052394609", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearMessageLog()
	{
		MessageLog?.Clear();
	}

	public void AddRemoveUnits()
	{
		lock (lockObject_3)
		{
			try
			{
				for (int i = hashSet_0.Count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit = hashSet_0.ElementAtOrDefault(i);
					if (string.IsNullOrEmpty(activeUnit.ObjectID))
					{
						activeUnit.ResetIDs();
					}
					if (ActiveUnits.ContainsKey(activeUnit.ObjectID))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						ActiveUnits.TryAdd(activeUnit.ObjectID, activeUnit);
						hashSet_0.Remove(activeUnit);
					}
				}
				PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
				foreach (ActiveUnit value2 in ActiveUnits.Values)
				{
					if (value2 != null && value2.IsMorituri)
					{
						pooledList.Add(value2);
					}
				}
				foreach (ActiveUnit item in pooledList)
				{
					ActiveUnit activeUnit = item;
					if (list_4.Contains(activeUnit))
					{
						list_4.Remove(activeUnit);
					}
					if (activeUnit != null)
					{
						ActiveUnits.TryRemove(activeUnit?.ObjectID, out activeUnit);
						list_4.Remove(activeUnit);
						try
						{
							activeUnit?.EndgameReport.AttemptEndgameReport(this);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 102345234509", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							ProjectData.ClearProjectError();
						}
						try
						{
							activeUnit?.Destroy(ScenEditAction: false, IsFacilityAimpoint: false, DestroyUnitNow: false, "Final removal");
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
				}
				pooledList.Dispose();
				for (int j = list_4.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = list_4[j];
					activeUnit.Destroy(ScenEditAction: true, IsFacilityAimpoint: false, DestroyUnitNow: false, "Final removal");
					if (activeUnit != null)
					{
						ActiveUnits.TryRemove(activeUnit?.ObjectID, out activeUnit);
						list_4.Remove(activeUnit);
					}
				}
				for (int k = list_3.Count - 1; k >= 0; k += -1)
				{
					UnguidedWeapon value = list_3[k];
					if (UnguidedWeapons.TryRemove(value.ObjectID, out value))
					{
						list_3.Remove(value);
						value.EndgameReport.AttemptEndgameReport(this);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101033", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public void DeleteThisUnit(ActiveUnit theUnit, string WhatCausedDestruction = null)
	{
		if (!list_4.Contains(theUnit))
		{
			list_4.Add(theUnit);
		}
	}

	public void DestroyThisUnit(ActiveUnit theUnit, string theReason, string WhatCausedDestruction = null)
	{
		theUnit.IsMorituri = true;
		if (!theUnit.IsGroup && (!theUnit.IsShip || !((Ship)theUnit).IsSinking))
		{
			ExportUnitDestructionEvent(theUnit, theReason, WhatCausedDestruction);
		}
	}

	public void DestroyThisUnguidedWeapon(UnguidedWeapon theW, string theReason, string WhatCausedDestruction = null)
	{
		if (!list_3.Contains(theW))
		{
			list_3.Add(theW);
		}
		ExportUnitDestructionEvent(theW, theReason, WhatCausedDestruction);
	}

	public void DeleteUnitImmediately(string UnitID, bool ScenEditAction, string theReason, string WhatCausedDestruction = null, bool RegisterAsLosses = true)
	{
		try
		{
			ActiveUnit value = null;
			UnguidedWeapon value2 = null;
			if (!ActiveUnits.TryGetValue(UnitID, out value))
			{
				if (UnguidedWeapons.TryGetValue(UnitID, out value2))
				{
					UnguidedWeapon unguidedWeapon = UnguidedWeapons[UnitID];
					Scenario theScen = this;
					unguidedWeapon.DestroyMe(ref theScen, theReason, WhatCausedDestruction);
				}
				return;
			}
			if (!value.IsGroup)
			{
				ExportUnitDestructionEvent(value, theReason, WhatCausedDestruction);
			}
			if ((GameGeneral.Beta_PlatformComms & DeclaredFeatures.Contains(ScenarioFeatureOption.PointToPointComm)) && value.CommStuff.Networks != null && value.CommStuff.Networks.Count > 0)
			{
				List<CommNetwork> list = new List<CommNetwork>();
				foreach (CommNetwork network in value.CommStuff.Networks)
				{
					if (network != null)
					{
						value.get_UnitSide(SetSideOnly: false).RemoveUnitFromNetwork(network.ID, value);
						if (network.Members.Count == 0)
						{
							list.Add(network);
						}
					}
				}
				foreach (CommNetwork item in list)
				{
					value.get_UnitSide(SetSideOnly: false).RemoveCommNetwork(item.ID);
				}
			}
			value.Destroy(ScenEditAction, IsFacilityAimpoint: false, DestroyUnitNow: false, theReason, WhatCausedDestruction, RegisterAsLosses);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300018", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void ExportUnitDamagedEvent(Module_Unit.Unit theUnit, string theReason, string WhatCausedDamage = null)
	{
		bool flag = false;
		string theValue = "-";
		string theValue2 = "-";
		string theValue3 = "-";
		string theValue4 = "0";
		if (WhatCausedDamage != null)
		{
			theValue = WhatCausedDamage;
		}
		if (theUnit.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)theUnit;
			theValue4 = activeUnit.Damage.DamagePercent.ToString("F6");
			if (activeUnit.Damage.FireIntensity != ActiveUnit_Damage.FireIntensityLevel.NoFire)
			{
				theValue2 = activeUnit.Damage.FireIntensity.ToString();
			}
			if (activeUnit.Damage.FloodIntensity != ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding)
			{
				theValue3 = activeUnit.Damage.FloodIntensity.ToString();
			}
		}
		IEventExporter[] applicableEventExporters = ApplicableEventExporters;
		foreach (IEventExporter eventExporter in applicableEventExporters)
		{
			if (eventExporter.IsOperating && eventExporter.ExportUnitDamaged)
			{
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(this.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + this.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(this.Time.Subtract(ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(theUnit.ObjectID, typeof(string), 40));
				pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(theUnit.Name, typeof(string), 500));
				pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(theUnit.UnitClass, typeof(string), 500));
				pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(theUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				pooledDictionary.Add("DamagePercent", new IEventExporter.EventNotificationParameter(theValue4, typeof(string), 10));
				pooledDictionary.Add("Fire", new IEventExporter.EventNotificationParameter(theValue2, typeof(string)));
				pooledDictionary.Add("Flooding", new IEventExporter.EventNotificationParameter(theValue3, typeof(string)));
				pooledDictionary.Add("Reason", new IEventExporter.EventNotificationParameter(theReason, typeof(string)));
				pooledDictionary.Add("Cause", new IEventExporter.EventNotificationParameter(theValue, typeof(string)));
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitPositions_Destruction, pooledDictionary, this);
				flag = true;
			}
		}
		if (flag)
		{
			if (theUnit.IsActiveUnit)
			{
				((ActiveUnit)theUnit).Kinematics.ExportLocationEvent("Damaged");
			}
			else if ((object)theUnit.GetType() == typeof(UnguidedWeapon))
			{
				((UnguidedWeapon)theUnit).ExportLocationEvent(this, "Damaged");
			}
		}
	}

	internal void ExportUnitDestructionEvent(Module_Unit.Unit theUnit, string theReason, string WhatCausedDestruction = null)
	{
		bool flag = false;
		string theValue = "-";
		if (WhatCausedDestruction != null)
		{
			theValue = WhatCausedDestruction;
		}
		IEventExporter[] applicableEventExporters = ApplicableEventExporters;
		foreach (IEventExporter eventExporter in applicableEventExporters)
		{
			if (eventExporter.IsOperating && eventExporter.ExportUnitDestroyed)
			{
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(TimelineID, typeof(string), 40));
				if (eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(this.Time.Subtract(ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(this.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + this.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(theUnit.ObjectID, typeof(string), 40));
				pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(theUnit.Name, typeof(string), 500));
				pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(theUnit.UnitClass, typeof(string), 500));
				pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(theUnit.get_UnitSide(SetSideOnly: false)?.Name, typeof(string), 500));
				pooledDictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				pooledDictionary.Add("Reason", new IEventExporter.EventNotificationParameter(theReason, typeof(string)));
				pooledDictionary.Add("Cause", new IEventExporter.EventNotificationParameter(theValue, typeof(string)));
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitDestroyed, pooledDictionary, this);
				flag = true;
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		foreach (ISimConnector simConnector in activeSimConnectors)
		{
			if (simConnector.ExportUnitDestroyed && (simConnector.ConnectorType != ISimConnector.SimConnectorType.DIS || theUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.DIS))
			{
				Dictionary<string, (Type, string)> dictionary = new Dictionary<string, (Type, string)>();
				dictionary.Add("TimelineID", (typeof(string), TimelineID));
				dictionary.Add("Time", (typeof(DateTime), this.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + this.Time.Millisecond.ToString("D3")));
				dictionary.Add("UnitID", (typeof(string), theUnit.ObjectID));
				dictionary.Add("UnitName", (typeof(string), theUnit.Name));
				dictionary.Add("UnitClass", (typeof(string), theUnit.UnitClass));
				dictionary.Add("UnitSide", (typeof(string), theUnit.get_UnitSide(SetSideOnly: false).Name));
				dictionary.Add("MiscInfo", (typeof(string), ""));
				dictionary.Add("Reason", (typeof(string), theReason));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.UnitDestroyed, dictionary, this);
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		if (!theUnit.IsActiveUnit)
		{
			if ((object)theUnit.GetType() == typeof(UnguidedWeapon))
			{
				((UnguidedWeapon)theUnit).ExportLocationEvent(this, "Destruction");
			}
		}
		else
		{
			((ActiveUnit)theUnit).Kinematics.ExportLocationEvent("Destruction");
		}
	}

	public void AddThisUnit(ActiveUnit theUnit)
	{
		lock (lockObject_2)
		{
			hashSet_0.Add(theUnit);
		}
	}

	public void AddSide(Side theSide)
	{
		if (!side_0.Contains(theSide))
		{
			theSide.ParentScen = this;
			ArrayExtensions.Add(ref side_0, theSide);
			Side[] array = side_0;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				theSide = array[i];
				theSide.ResetPostureCacheArray();
			}
			sidesChangedEventHandler_0?.Invoke(this, SideAdditionOrRemoval.Addition);
		}
	}

	public void RemoveSide(Side theSide)
	{
		ArrayExtensions.Remove(ref side_0, theSide);
		Side[] array = side_0;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			theSide = array[i];
			theSide.ResetPostureCacheArray();
		}
		sidesChangedEventHandler_0?.Invoke(this, SideAdditionOrRemoval.Removal);
	}

	public void ClearSides()
	{
		sidesChangedEventHandler_0?.Invoke(this, SideAdditionOrRemoval.Removal);
	}

	public static void ChangeCurrentScenarioOnClient(Scenario theNewScen)
	{
		currentScenarioChangedEventHandler_0?.Invoke(theNewScen);
	}

	internal Aircraft AddNewAircraft(Side theSide, string theName, double Longitude, double Latitude, int AircraftDBID, int LoadoutID, float Altitude, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null, bool IgnoreOperationalCeiling = false)
	{
		try
		{
			if (!method_2(theGUID))
			{
				Scenario theScen = this;
				Aircraft theAircraft = new Aircraft(ref theScen, theGUID);
				theScen = this;
				DBFunctions.GetAircraft(ref theScen, ref theAircraft, AircraftDBID);
				if (!IgnoreOperationalCeiling && (double)Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this) >= (double)(theAircraft.Kinematics.GetMaximumAltitude() * 0.9f))
				{
					throw new Exception("You can't place an aircraft which operational ceiling is below 90% this location's altitude.");
				}
				Interlocked.Increment(ref UnitsAutoIncrement);
				theAircraft.Name = theName;
				((ActiveUnit)theAircraft).set_UnitSide(SetSideOnly: false, theSide);
				if (LoadoutID > 0)
				{
					DBFunctions.GetLoadout(ref theAircraft, LoadoutID, ExcludeOptionalWeapons: false);
				}
				theAircraft.SetThrottle(ActiveUnit.Throttle.Loiter);
				theAircraft.Kinematics.DetermineReserveFuelQty();
				theAircraft.CurrentHeading = 0f;
				theAircraft.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
				theAircraft.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
				short elevation = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
				if (Altitude < (float)(elevation + 1))
				{
					theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(elevation + 1));
				}
				else
				{
					theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, Altitude);
				}
				theAircraft.CurrentSpeed = theAircraft.Kinematics.GetMaximumSpeed(Altitude, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
				theAircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				((ActiveUnit)theAircraft).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
				theAircraft.DesiredAltitude = theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				ActiveUnit theUnit = theAircraft;
				theScen = this;
				GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
				if (theAircraft.Loadout != null)
				{
					WeaponRec[] weapons = theAircraft.Loadout.Weapons;
					for (int i = 0; i < weapons.Length; i = checked(i + 1))
					{
						Weapon weapon = weapons[i].get_ReferenceWeapon(theAircraft.ParentScen);
						weapon.set_Longitude((GlobalVariables.BooleanObject)null, theAircraft.get_Longitude((GlobalVariables.BooleanObject)null));
						weapon.set_Latitude((GlobalVariables.BooleanObject)null, theAircraft.get_Latitude((GlobalVariables.BooleanObject)null));
						weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						weapon.CurrentHeading = theAircraft.CurrentHeading;
						weapon.CurrentSpeed = theAircraft.CurrentSpeed;
					}
				}
				theAircraft.Kinematics.ExportLocationEvent("UnitAdded");
				return theAircraft;
			}
			throw new Exception("Requested custom GUID is already in use in this scenario");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101034", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Satellite AddNewSatellite(Side theSide, string theName, int SatelliteDBID, int OrbitIndex, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataSatellite", SatelliteDBID, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (method_2(theGUID))
			{
				throw new Exception("Requested custom GUID is already in use in this scenario");
			}
			Scenario theScen = this;
			Satellite theSatellite = new Satellite(ref theScen, theGUID);
			theSatellite.SpacecraftID = SatelliteDBID + "_" + OrbitIndex;
			theScen = this;
			DBFunctions.GetSatellite(ref theScen, ref theSatellite, SatelliteDBID, OrbitIndex);
			Interlocked.Increment(ref UnitsAutoIncrement);
			theSatellite.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: false, this.Time);
			Side[] sides_ReadOnly = Sides_ReadOnly;
			foreach (Side sideAttemptingDetection in sides_ReadOnly)
			{
				((ActiveUnit)theSatellite).set_IsAutoDetectable(sideAttemptingDetection, value: true);
			}
			if (!string.IsNullOrEmpty(theName))
			{
				theSatellite.Name = theName;
			}
			((ActiveUnit)theSatellite).set_UnitSide(SetSideOnly: false, theSide);
			ActiveUnit theUnit = theSatellite;
			theScen = this;
			GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
			theSatellite.Kinematics.ExportLocationEvent("UnitAdded");
			return theSatellite;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101035", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public AggregateGroundUnit AddAggregateUnit(AggregateGroundUnit theUnit, Side theSide, double Longitude, double Latitude, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
	{
		int elevation = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
		Interlocked.Increment(ref UnitsAutoIncrement);
		theUnit.ParentScen = this;
		((ActiveUnit)theUnit).set_UnitSide(SetSideOnly: false, theSide);
		theUnit.CurrentHeading = 0f;
		theUnit.CurrentSpeed = 0f;
		((ActiveUnit)theUnit).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
		((ActiveUnit)theUnit).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
		((ActiveUnit)theUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)elevation);
		theUnit.DesiredSpeed = 0f;
		((ActiveUnit)theUnit).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
		ActiveUnit theUnit2 = theUnit;
		Scenario theScen = this;
		GameGeneral.AddUnitToCollections(ref theUnit2, ref theScen);
		theUnit.Kinematics.ExportLocationEvent("UnitAdded");
		return theUnit;
	}

	internal Ship AddNewShip(Side theSide, int ShipDBID, string theName, double Longitude, double Latitude, bool IgnoreElevationCheck = false, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (!DBFunctions.CheckObjectIsDeprecated("DataShip", ShipDBID, DBConnection))
			{
				if (!method_2(theGUID))
				{
					double num = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
					if (!IgnoreElevationCheck && num > 0.0)
					{
						throw new Exception("You cannot place a ship overland!");
					}
					Scenario theScen = this;
					Ship theShip = new Ship(ref theScen, theGUID);
					theScen = this;
					DBFunctions.GetShip(ref theScen, ref theShip, ShipDBID);
					Interlocked.Increment(ref UnitsAutoIncrement);
					theShip.Name = theName;
					((ActiveUnit)theShip).set_UnitSide(SetSideOnly: false, theSide);
					theShip.CurrentHeading = 0f;
					theShip.CurrentSpeed = 0f;
					((ActiveUnit)theShip).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
					((ActiveUnit)theShip).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
					theShip.DesiredSpeed = 0f;
					((ActiveUnit)theShip).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
					ActiveUnit theUnit = theShip;
					theScen = this;
					GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
					theShip.Kinematics.ExportLocationEvent("UnitAdded");
					return theShip;
				}
				throw new Exception("Requested custom GUID is already in use in this scenario");
			}
			throw new Exception("The requested object has been deprecated in the database");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101036", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Weapon AddNewWeapon(Side theSide, string theName, double Longitude, double Latitude, int int_0, float Altitude, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (!DBFunctions.CheckObjectIsDeprecated("DataWeapon", int_0, DBConnection))
			{
				if (method_2(theGUID))
				{
					throw new Exception("Requested custom GUID is already in use in this scenario");
				}
				Scenario theScen = this;
				Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, int_0, bool_5: false, theGUID);
				Interlocked.Increment(ref UnitsAutoIncrement);
				newWeapon.Name = theName;
				((ActiveUnit)newWeapon).set_UnitSide(SetSideOnly: false, theSide);
				newWeapon.SetThrottle(ActiveUnit.Throttle.Cruise);
				newWeapon.CurrentHeading = 0f;
				newWeapon.CurrentSpeed = newWeapon.Kinematics.GetMaximumSpeed(Altitude, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
				newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
				newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
				newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, Altitude);
				((ActiveUnit)newWeapon).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
				newWeapon.DesiredAltitude = Altitude;
				ActiveUnit theUnit = newWeapon;
				theScen = this;
				GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
				newWeapon.RemoteSimEntityType = theRemoteSimEntityType;
				newWeapon.Kinematics.ExportLocationEvent("UnitAdded");
				return newWeapon;
			}
			throw new Exception("The requested object has been deprecated in the database");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324958245687345897", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private bool method_2(string string_7)
	{
		if (!string.IsNullOrEmpty(string_7))
		{
			KeyValuePair<string, ActiveUnit>[] array = ActiveUnits.ToArray();
			foreach (KeyValuePair<string, ActiveUnit> keyValuePair in array)
			{
				ActiveUnit value = keyValuePair.Value;
				if (value != null && Operators.CompareString(value.ObjectID, string_7, false) == 0)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	internal Submarine AddNewSubmarine(Side theSide, int SubDBID, string theName, double Longitude, double Latitude, bool IgnoreElevationCheck = false, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (!DBFunctions.CheckObjectIsDeprecated("DataSubmarine", SubDBID, DBConnection))
			{
				if (method_2(theGUID))
				{
					throw new Exception("Requested custom GUID is already in use in this scenario");
				}
				double num = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
				if (!IgnoreElevationCheck && num > 0.0)
				{
					throw new Exception("You cannot place a submarine overland!");
				}
				Scenario theScen = this;
				Submarine theSub = new Submarine(ref theScen, theGUID);
				theScen = this;
				DBFunctions.GetSubmarine(ref theScen, ref theSub, SubDBID);
				Interlocked.Increment(ref UnitsAutoIncrement);
				theSub.Name = theName;
				((ActiveUnit)theSub).set_UnitSide(SetSideOnly: false, theSide);
				theSub.CurrentHeading = 0f;
				theSub.CurrentSpeed = 0f;
				theSub.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, Math.Max(-40f, theSub.Kinematics.GetMinimumAltitude()));
				((ActiveUnit)theSub).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
				((ActiveUnit)theSub).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
				theSub.DesiredSpeed = 0f;
				theSub.set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
				theSub.DesiredAltitude = -20f;
				ActiveUnit theUnit = theSub;
				theScen = this;
				GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
				theSub.Kinematics.ExportLocationEvent("UnitAdded");
				return theSub;
			}
			throw new Exception("The requested object has been deprecated in the database");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101037", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Facility AddNewFacility(Side theSide, int FacilityDBID, string theName, double Longitude, double Latitude, bool IgnoreElevationCheck = false, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (!DBFunctions.CheckObjectIsDeprecated("DataFacility", FacilityDBID, DBConnection))
			{
				if (method_2(theGUID))
				{
					throw new Exception("Requested custom GUID is already in use in this scenario");
				}
				Scenario theScen = this;
				Facility theFac = new Facility(ref theScen, theGUID);
				int elevation = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
				theScen = this;
				DBFunctions.GetFacility(ref theScen, ref theFac, FacilityDBID);
				if (theFac.IsFixedFacility)
				{
					((ActiveUnit)theFac).set_IsAutoDetectable((Side)null, value: true);
				}
				theFac.Name = theName;
				if (!IgnoreElevationCheck && elevation < 0)
				{
					Facility._FacilityCategory category = theFac.Category;
					if (category != Facility._FacilityCategory.Underwater && category != Facility._FacilityCategory.Water_Surface)
					{
						throw new Exception("Attempted to place facility: " + theFac.Name + " (Class: " + theFac.UnitClass + " - DBID: " + Conversions.ToString(theFac.DBID) + ") at coordinates: Lat: " + Conversions.ToString(Latitude) + " - Lon: " + Conversions.ToString(Longitude) + " . This point appears to be underwater. Placement aborted!");
					}
				}
				Interlocked.Increment(ref UnitsAutoIncrement);
				((ActiveUnit)theFac).set_UnitSide(SetSideOnly: false, theSide);
				theFac.CurrentHeading = 0f;
				theFac.CurrentSpeed = 0f;
				((ActiveUnit)theFac).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
				((ActiveUnit)theFac).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
				if (theFac.Category == Facility._FacilityCategory.Water_Surface)
				{
					((ActiveUnit)theFac).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
				}
				else
				{
					((ActiveUnit)theFac).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)elevation);
				}
				theFac.DesiredSpeed = 0f;
				((ActiveUnit)theFac).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
				ActiveUnit theUnit = theFac;
				theScen = this;
				GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
				theFac.Kinematics.ExportLocationEvent("UnitAdded");
				return theFac;
			}
			if (!Debugger.IsAttached)
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101286", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		Facility result = default(Facility);
		return result;
	}

	internal AggregateGroundUnit method_3(Side theSide, string TemplateID, string theName, double Longitude, double Latitude, bool IgnoreElevationCheck = false, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			int elevation = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
			if (!IgnoreElevationCheck && elevation < 0)
			{
				throw new Exception("Attempted to place AGU: " + theName + " at coordinates: Lat: " + Conversions.ToString(Latitude) + " - Lon: " + Conversions.ToString(Longitude) + " . This point appears to be on water. Placement aborted!");
			}
			AggregateGroundUnit aggregateGroundUnit = AGU_DATABASE.GetTemplateByID(TemplateID).ToAggregateUnit(this);
			Interlocked.Increment(ref UnitsAutoIncrement);
			((ActiveUnit)aggregateGroundUnit).set_UnitSide(SetSideOnly: false, theSide);
			aggregateGroundUnit.CurrentHeading = 0f;
			aggregateGroundUnit.CurrentSpeed = 0f;
			((ActiveUnit)aggregateGroundUnit).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
			((ActiveUnit)aggregateGroundUnit).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
			((ActiveUnit)aggregateGroundUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)elevation);
			aggregateGroundUnit.DesiredSpeed = 0f;
			((ActiveUnit)aggregateGroundUnit).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			ActiveUnit theUnit = aggregateGroundUnit;
			Scenario theScen = this;
			GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
			aggregateGroundUnit.Kinematics.ExportLocationEvent("UnitAdded");
			return aggregateGroundUnit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10128754", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Vehicle AddNewVehicle(Side theSide, int int_0, string theName, double Longitude, double Latitude, bool IgnoreElevationCheck = false, Module_Unit.Unit.RemoteSimEntityTypeEnum theRemoteSimEntityType = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string theGUID = null)
	{
		try
		{
			if (!method_2(theGUID))
			{
				Scenario theScen = this;
				Vehicle theVehicle = new Vehicle(ref theScen, theGUID);
				int elevation = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, this);
				theScen = this;
				DBFunctions.GetVehicle(ref theScen, ref theVehicle, int_0);
				if (theVehicle.IsFixedFacility)
				{
					((ActiveUnit)theVehicle).set_IsAutoDetectable((Side)null, value: true);
				}
				theVehicle.Name = theName;
				if (!IgnoreElevationCheck && elevation < 0 && !theVehicle.IsAmphibiousSeaworthy)
				{
					throw new Exception("Attempted to place vehicle: " + theVehicle.Name + " (Class: " + theVehicle.UnitClass + " - DBID: " + Conversions.ToString(theVehicle.DBID) + ") at coordinates: Lat: " + Conversions.ToString(Latitude) + " - Lon: " + Conversions.ToString(Longitude) + " . This point appears to be on water. Placement aborted!");
				}
				Interlocked.Increment(ref UnitsAutoIncrement);
				((ActiveUnit)theVehicle).set_UnitSide(SetSideOnly: false, theSide);
				theVehicle.CurrentHeading = 0f;
				theVehicle.CurrentSpeed = 0f;
				((ActiveUnit)theVehicle).set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
				((ActiveUnit)theVehicle).set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
				((ActiveUnit)theVehicle).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)elevation);
				theVehicle.DesiredSpeed = 0f;
				((ActiveUnit)theVehicle).set_DesiredHeading(ActiveUnit.TurnRate.Max, 0f);
				ActiveUnit theUnit = theVehicle;
				theScen = this;
				GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
				theVehicle.Kinematics.ExportLocationEvent("UnitAdded");
				return theVehicle;
			}
			throw new Exception("Requested custom GUID is already in use in this scenario");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101286", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal UnguidedWeapon AddNewMine(Side theSide, int MineDBID, List<ReferencePoint> theArea, [Optional][DefaultParameterValue(null)] ref string AttemptMessage)
	{
		UnguidedWeapon result;
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataWeapon", MineDBID, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(theArea);
			if (!Information.IsNothing((object)geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
			{
				Weapon theReferenceWeapon = Cache_GetWeapon(MineDBID);
				UnguidedWeapon theM = new UnguidedWeapon(theReferenceWeapon, null, null, 0.0, 0.0);
				if (!theM.IsMine)
				{
					result = null;
				}
				else
				{
					theM.set_UnitSide(SetSideOnly: false, theSide);
					string text = UnguidedWeapon.CanLayMineHere(ref theM, geopoint_Struct.Latitude, geopoint_Struct.Longitude, Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, RequestIsFromGUI: false, this), this);
					if (string.CompareOrdinal(text, "OK") != 0)
					{
						AttemptMessage = text;
						result = null;
					}
					else
					{
						UnguidedWeapons.AddOrUpdate(theM.ObjectID, theM);
						result = theM;
					}
				}
			}
			else
			{
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101039", "");
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

	internal bool ExportUnitsToFile(string InstFilePath, string Instname, string InstComment, int InstDBID, Side theSide, Collection<ActiveUnit> unitList)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		ImportExportRecord importExportRecord = new ImportExportRecord();
		importExportRecord.Name = Instname;
		importExportRecord.Comments = InstComment;
		importExportRecord.DB_ID = InstDBID;
		new XmlWriterSettings
		{
			Indent = true,
			IndentChars = "    ",
			ConformanceLevel = (ConformanceLevel)0
		};
		foreach (ActiveUnit item2 in unitList.Where([SpecialName] (ActiveUnit theU) => theU.IsActiveUnit).ToList())
		{
			ImportExportRecord.MemberRecord item;
			if (!item2.IsGroup)
			{
				item = ExportUnitsToIER(item2);
				importExportRecord.MemberRecords.Add(item);
				continue;
			}
			ActiveUnit groupLead = ((Group)item2).GroupLead;
			item = ExportUnitsToIER(groupLead);
			importExportRecord.MemberRecords.Add(item);
			foreach (ActiveUnit value in ((Group)item2).Units.Values)
			{
				if (!value.IsGroupLead())
				{
					item = ExportUnitsToIER(value);
					importExportRecord.MemberRecords.Add(item);
				}
			}
		}
		StreamWriter streamWriter = new StreamWriter(InstFilePath);
		JsonSerializer jsonSerializer = new JsonSerializer();
		using (streamWriter)
		{
			JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter);
			jsonTextWriter.Formatting = Formatting.Indented;
			using (jsonTextWriter)
			{
				jsonSerializer.Serialize(jsonTextWriter, importExportRecord);
			}
		}
		return true;
	}

	internal ImportExportRecord.MemberRecord ExportUnitsToIER(ActiveUnit theunit)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		val.ConformanceLevel = (ConformanceLevel)0;
		int ErrorCount = 0;
		ImportExportRecord.MemberRecord theRec = new ImportExportRecord.MemberRecord();
		theRec.Member_DBID = theunit.DBID;
		theRec.Member_GUID = theunit.ObjectID;
		switch (theunit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			theRec.MemberType = "Aircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			theRec.MemberType = "Ship";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			theRec.MemberType = "Submarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			theRec.MemberType = "Facility";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			theRec.MemberType = "Weapon";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			theRec.MemberType = "Satellite";
			theRec.LoadoutID = ((Satellite)theunit).SpaceCraftNumber;
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			theRec.MemberType = "Vehicle";
			break;
		}
		theRec.Orientation = theunit.CurrentHeading;
		theRec.Longitude = theunit.get_Longitude((GlobalVariables.BooleanObject)null);
		theRec.Latitude = theunit.get_Latitude((GlobalVariables.BooleanObject)null);
		theRec.MemberName = theunit.Name;
		theRec.Altitude = theunit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		theRec.Speed = theunit.CurrentSpeed;
		if ((object)theunit.GetType() == typeof(Aircraft))
		{
			if (((Aircraft)theunit).Loadout != null)
			{
				theRec.LoadoutID = ((Aircraft)theunit).Loadout.DBID;
			}
			else
			{
				theRec.LoadoutID = 0;
			}
		}
		if (theunit.IsGroupMember())
		{
			theRec.ParentGroupName = theunit.get_ParentGroup(UsingMissionPlanner: false).Name;
			theRec.ParentGroupGUID = theunit.get_ParentGroup(UsingMissionPlanner: false).ObjectID;
		}
		if (theunit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			ActiveUnit groupLead = theunit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			theRec.FormationStationPoint = theunit.Navigator.UnitFormationStation;
			(theRec.FormationLongitude, theRec.FormationLatitude) = theunit.Navigator.UnitFormationStation.get_LatitudeAndLongitude(theunit, groupLead);
			if (theunit.IsGroupLead())
			{
				theRec.LastFormationSet = theunit.get_ParentGroup(UsingMissionPlanner: false).LastFormationSet;
				theRec.LastFormationSpacing = theunit.get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing;
				theRec.LastFormationSpacingUnits = theunit.get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits;
				theRec.GroupLead = true;
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
		try
		{
			val2.WriteStartElement("DeltaUnit");
			StreamWriter logFileWriter = default(StreamWriter);
			SBR.GenerateDeltaFragmentForThisUnit(theunit, theunit.ParentScen, val2, logFileWriter, ref ErrorCount);
			val2.WriteEndElement();
			val2.Flush();
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (Operators.CompareString(Misc.ConvertToString(memoryStream), "<DeltaUnit />", false) != 0)
		{
			theRec.Member_SBR = Misc.ConvertToString(memoryStream);
		}
		SaveHostedAircraft(ref theunit, ref theRec);
		SaveDockedBoats(ref theunit, ref theRec);
		return theRec;
	}

	internal void SaveHostedAircraft(ref ActiveUnit theUnit, ref ImportExportRecord.MemberRecord theRec)
	{
		if (theUnit.AirOps.EmbarkedAircraft_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (Aircraft item in theUnit.AirOps.EmbarkedAircraft_ReadOnly)
		{
			ImportExportRecord.HostedAircraftRecord hostedAircraftRecord = new ImportExportRecord.HostedAircraftRecord(item.Name, item.DBID, (item.Loadout != null) ? item.LoadoutDBID : 0, (int)Math.Round(item.AirOps.ConditionTimer / 60f));
			ImportExportRecord.MemberRecord member = ExportUnitsToIER(item);
			hostedAircraftRecord.Member = member;
			theRec.HostedAircraftRecords.Add(hostedAircraftRecord);
		}
	}

	internal void SaveDockedBoats(ref ActiveUnit theUnit, ref ImportExportRecord.MemberRecord theRec)
	{
		if (theUnit.DockingOps.EmbarkedBoats_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (ActiveUnit item in theUnit.DockingOps.EmbarkedBoats_ReadOnly)
		{
			ImportExportRecord.EmbarkedBoatRecord embarkedBoatRecord = new ImportExportRecord.EmbarkedBoatRecord(item.Name, item.DBID, (int)Math.Round(item.DockingOps.ConditionTimer / 60f), item.UnitType_String);
			ImportExportRecord.MemberRecord member = ExportUnitsToIER(item);
			embarkedBoatRecord.Member = member;
			theRec.EmbarkedBoatRecords.Add(embarkedBoatRecord);
		}
	}

	internal List<ActiveUnit> ImportUnitsFromFile(string InstFilePath, Side theSide)
	{
		List<ActiveUnit> result;
		try
		{
			StreamReader streamReader = new StreamReader(InstFilePath);
			List<ActiveUnit> list_ = new List<ActiveUnit>();
			new List<string>();
			ImportExportRecord importExportRecord;
			using (streamReader)
			{
				importExportRecord = (ImportExportRecord)JsonConvert.DeserializeObject(streamReader.ReadToEnd(), typeof(ImportExportRecord));
			}
			foreach (ImportExportRecord.MemberRecord memberRecord in importExportRecord.MemberRecords)
			{
				try
				{
					method_4(memberRecord, ref list_, ref theSide, importExportRecord.Template);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200054", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			List<Group> list = new List<Group>();
			List<ActiveUnit> list2 = theSide.Units.ToList();
			foreach (ActiveUnit item in list2)
			{
				if (item.IsGroup)
				{
					if (((Group)item).Units.Count < 2)
					{
						list.Add((Group)item);
					}
					((Group)item).DeserializationInProgress = false;
				}
			}
			foreach (Group item2 in list)
			{
				DeleteUnitImmediately(item2.ObjectID, ScenEditAction: true, "Group dissolving", null, RegisterAsLosses: false);
			}
			result = list_;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101040", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_4(ImportExportRecord.MemberRecord memberRecord_0, ref List<ActiveUnit> list_9, ref Side side_2, bool bool_3 = false)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlDocument val = new XmlDocument();
		if (memberRecord_0.MemberType != null)
		{
			if (!string.IsNullOrEmpty(memberRecord_0.Member_SBR) && memberRecord_0.Member_SBR.Length > 0)
			{
				val.LoadXml(memberRecord_0.Member_SBR);
			}
			if (bool_3)
			{
				memberRecord_0.Member_GUID = "";
			}
			ActiveUnit_Navigator.FormationStation formationStationPoint = memberRecord_0.FormationStationPoint;
			double formationLatitude = memberRecord_0.FormationLatitude;
			double formationLongitude = memberRecord_0.FormationLongitude;
			string lastFormationSet = memberRecord_0.LastFormationSet;
			float lastFormationSpacing = memberRecord_0.LastFormationSpacing;
			byte lastFormationSpacingUnits = memberRecord_0.LastFormationSpacingUnits;
			switch (memberRecord_0.MemberType)
			{
			case "Submarine":
			case "Command_Core.Submarine":
			{
				Submarine submarine = AddNewSubmarine(side_2, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				submarine.CurrentHeading = memberRecord_0.Orientation;
				submarine.set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				submarine.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				submarine.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = submarine;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				theActiveUnit = submarine;
				method_5(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				theActiveUnit = submarine;
				method_6(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				list_9.Add(submarine);
				theActiveUnit = submarine;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)submarine).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					submarine.Navigator.UnitFormationStation = formationStationPoint;
					submarine.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (submarine.IsGroupLead())
					{
						((ActiveUnit)submarine).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)submarine).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)submarine).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			case "Ship":
			case "Command_Core.Ship":
			{
				Ship ship = AddNewShip(side_2, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				ship.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)ship).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				((ActiveUnit)ship).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				ship.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = ship;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				theActiveUnit = ship;
				method_5(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				theActiveUnit = ship;
				method_6(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				list_9.Add(ship);
				theActiveUnit = ship;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)ship).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					ship.Navigator.UnitFormationStation = formationStationPoint;
					ship.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (ship.IsGroupLead())
					{
						((ActiveUnit)ship).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)ship).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)ship).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			case "Satellite":
			{
				Satellite satellite = AddNewSatellite(side_2, memberRecord_0.MemberName, memberRecord_0.Member_DBID, memberRecord_0.LoadoutID, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				((ActiveUnit)satellite).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				satellite.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)satellite).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				satellite.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = satellite;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				list_9.Add(satellite);
				theActiveUnit = satellite;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)satellite).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					satellite.Navigator.UnitFormationStation = formationStationPoint;
					satellite.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (satellite.IsGroupLead())
					{
						((ActiveUnit)satellite).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)satellite).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)satellite).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			case "Command_Core.GroundUnit":
			case "Command_Core.Ground Unit":
			case "Vehicle":
			case "Ground Unit":
			case "Command_Core.Vehicle":
			case "GroundUnit":
			{
				Vehicle vehicle = AddNewVehicle(side_2, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				vehicle.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)vehicle).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				((ActiveUnit)vehicle).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				vehicle.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = vehicle;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				theActiveUnit = vehicle;
				method_5(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				theActiveUnit = vehicle;
				method_6(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				list_9.Add(vehicle);
				theActiveUnit = vehicle;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)vehicle).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					vehicle.Navigator.UnitFormationStation = formationStationPoint;
					vehicle.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (vehicle.IsGroupLead())
					{
						((ActiveUnit)vehicle).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)vehicle).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)vehicle).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			case "Command_Core.Aircraft":
			case "Aircraft":
			{
				Aircraft aircraft = AddNewAircraft(side_2, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, memberRecord_0.Member_DBID, memberRecord_0.LoadoutID, (float)memberRecord_0.Altitude, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				aircraft.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)aircraft).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				aircraft.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = aircraft;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				theActiveUnit = aircraft;
				method_5(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				list_9.Add(aircraft);
				theActiveUnit = aircraft;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					aircraft.Navigator.UnitFormationStation = formationStationPoint;
					aircraft.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (aircraft.IsGroupLead())
					{
						((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			case "Facility":
			case "Command_Core.Facility":
			{
				Facility facility = AddNewFacility(side_2, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
				((ActiveUnit)facility).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				facility.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)facility).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)memberRecord_0.Altitude);
				facility.CurrentSpeed = (float)memberRecord_0.Speed;
				ActiveUnit theActiveUnit;
				if (bool_3)
				{
					theActiveUnit = facility;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				else
				{
					theActiveUnit = null;
					SBR.ProcessUnit(this, val, ref theActiveUnit);
				}
				theActiveUnit = facility;
				method_5(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				theActiveUnit = facility;
				method_6(ref theActiveUnit, side_2, ref memberRecord_0, bool_3);
				list_9.Add(facility);
				theActiveUnit = facility;
				method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
				if (((ActiveUnit)facility).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					facility.Navigator.UnitFormationStation = formationStationPoint;
					facility.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
					if (facility.IsGroupLead())
					{
						((ActiveUnit)facility).get_ParentGroup(UsingMissionPlanner: false).LastFormationSet = lastFormationSet;
						((ActiveUnit)facility).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacing = lastFormationSpacing;
						((ActiveUnit)facility).get_ParentGroup(UsingMissionPlanner: false).LastFormationSpacingUnits = lastFormationSpacingUnits;
					}
				}
				break;
			}
			}
		}
		else
		{
			Facility facility2 = AddNewFacility(side_2, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			facility2.CurrentHeading = memberRecord_0.Orientation;
			list_9.Add(facility2);
			ActiveUnit theActiveUnit = facility2;
			method_7(ref memberRecord_0, ref side_2, ref theActiveUnit);
		}
	}

	private void method_5(ref ActiveUnit activeUnit_0, Side side_2, ref ImportExportRecord.MemberRecord memberRecord_0, bool bool_3)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		if (Information.IsNothing((object)memberRecord_0.HostedAircraftRecords) || memberRecord_0.HostedAircraftRecords.Count == 0)
		{
			return;
		}
		XmlDocument val = new XmlDocument();
		try
		{
			foreach (ImportExportRecord.HostedAircraftRecord hostedAircraftRecord in memberRecord_0.HostedAircraftRecords)
			{
				if (bool_3 && hostedAircraftRecord.Member != null)
				{
					hostedAircraftRecord.Member.Member_GUID = "";
				}
				Aircraft aircraft = AddNewAircraft(side_2, hostedAircraftRecord.Name, memberRecord_0.Longitude, memberRecord_0.Latitude, hostedAircraftRecord.AC_DBID, hostedAircraftRecord.Loadout_ID, 0f, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, hostedAircraftRecord.Member?.Member_GUID);
				aircraft.CurrentHeading = memberRecord_0.Orientation;
				((ActiveUnit)aircraft).set_DesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				if (hostedAircraftRecord.Member?.Member_SBR != null && hostedAircraftRecord.Member.Member_SBR.Length > 0)
				{
					val.LoadXml(hostedAircraftRecord.Member.Member_SBR);
					if (bool_3)
					{
						ActiveUnit theActiveUnit = aircraft;
						SBR.ProcessUnit(this, val, ref theActiveUnit);
					}
					else
					{
						ActiveUnit theActiveUnit = null;
						SBR.ProcessUnit(this, val, ref theActiveUnit);
					}
				}
				activeUnit_0.AirOps.AddThisAircraft(aircraft, GameIsRunning: false);
				if (hostedAircraftRecord.ReadyTime_Mins > 0)
				{
					aircraft.AirOps.ConditionTimer = hostedAircraftRecord.ReadyTime_Mins * 60;
				}
				if (aircraft.AirOps.ConditionTimer > 0f)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101041", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(ref ActiveUnit activeUnit_0, Side side_2, ref ImportExportRecord.MemberRecord memberRecord_0, bool bool_3)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		if (Information.IsNothing((object)memberRecord_0.EmbarkedBoatRecords) || memberRecord_0.EmbarkedBoatRecords.Count == 0)
		{
			return;
		}
		XmlDocument val = new XmlDocument();
		try
		{
			foreach (ImportExportRecord.EmbarkedBoatRecord embarkedBoatRecord in memberRecord_0.EmbarkedBoatRecords)
			{
				if (bool_3 && embarkedBoatRecord.Member != null)
				{
					embarkedBoatRecord.Member.Member_GUID = "";
				}
				ActiveUnit activeUnit = null;
				if (Operators.CompareString(embarkedBoatRecord.Type, "Ship", false) != 0)
				{
					if (Operators.CompareString(embarkedBoatRecord.Type, "Submarine", false) == 0)
					{
						activeUnit = AddNewSubmarine(side_2, embarkedBoatRecord.Boat_DBID, embarkedBoatRecord.Name, 0.0, 0.0);
					}
				}
				else
				{
					activeUnit = AddNewShip(side_2, embarkedBoatRecord.Boat_DBID, embarkedBoatRecord.Name, 0.0, 0.0);
				}
				if (activeUnit == null)
				{
					continue;
				}
				if (embarkedBoatRecord.Member?.Member_SBR != null && embarkedBoatRecord.Member.Member_SBR.Length > 0)
				{
					val.LoadXml(embarkedBoatRecord.Member.Member_SBR);
					if (!bool_3)
					{
						ActiveUnit theActiveUnit = null;
						SBR.ProcessUnit(this, val, ref theActiveUnit);
					}
					else
					{
						ActiveUnit theActiveUnit = activeUnit;
						SBR.ProcessUnit(this, val, ref theActiveUnit);
					}
				}
				activeUnit_0.DockingOps.AddThisBoat(activeUnit);
				if (embarkedBoatRecord.ReadyTime_Mins > 0)
				{
					activeUnit.DockingOps.ConditionTimer = embarkedBoatRecord.ReadyTime_Mins * 60;
				}
				if (activeUnit.DockingOps.ConditionTimer > 0f)
				{
					activeUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101041", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(ref ImportExportRecord.MemberRecord memberRecord_0, ref Side side_2, ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (string.IsNullOrEmpty(memberRecord_0.ParentGroupName))
			{
				return;
			}
			if (Misc.ContainsByName(Groups, memberRecord_0.ParentGroupName))
			{
				activeUnit_0.set_ParentGroup(UsingMissionPlanner: false, Misc.GetByName(Groups, memberRecord_0.ParentGroupName));
				if (memberRecord_0.GroupLead)
				{
					activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).DeserializationInProgress = true;
					activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).SetGroupLead(activeUnit_0);
				}
				return;
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.Add(activeUnit_0);
			Scenario theScen = this;
			Group obj = new Group(ref theScen, ref side_2, list);
			obj.Name = memberRecord_0.ParentGroupName;
			if (memberRecord_0.GroupLead)
			{
				obj.DeserializationInProgress = true;
				obj.SetGroupLead(activeUnit_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101042", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CheckForDestroyEvents(ActiveUnit theDestroyedUnit, float DamagePercent)
	{
		try
		{
			if (theDestroyedUnit.IsGroup)
			{
				return;
			}
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value).get_IsFulfilled(theDestroyedUnit, (ActiveUnit)null))
				{
					list.Add(value);
				}
			}
			foreach (EventTrigger value2 in EventTriggers.Values)
			{
				if (value2.Type == EventTrigger.EventTriggerType.UnitDamaged && (float)(int)((EventTrigger_UnitDamaged)value2).DamagePercent > theDestroyedUnit._OldDamagePercent && ((EventTrigger_UnitDamaged)value2).get_IsFulfilled(theDestroyedUnit, DamagePercent, 101f, (ActiveUnit)null))
				{
					list.Add(value2);
				}
			}
			FireEvents(list);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101043", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TriggerPlayerJoinedSideEvents()
	{
		try
		{
			List<EventTrigger> list = new List<EventTrigger>();
			if (EventTriggers != null)
			{
				foreach (EventTrigger value in EventTriggers.Values)
				{
					if (value.Type == EventTrigger.EventTriggerType.PlayerJoinedSide)
					{
						list.Add(value);
					}
				}
			}
			if (list.Count > 0)
			{
				FireEvents(list);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1010434948", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Weapon Cache_GetWeapon(int int_0)
	{
		if (int_0 == -1)
		{
			return null;
		}
		Weapon value = null;
		if (Cache_Weapons == null)
		{
			Scenario theScen = this;
			return Weapon.GetNewWeapon(ref theScen, int_0, bool_5: false);
		}
		if (!Cache_Weapons.TryGetValue(int_0, out value))
		{
			Scenario theScen = this;
			value = Weapon.GetNewWeapon(ref theScen, int_0, bool_5: false);
			Cache_Weapons.TryAdd(int_0, value);
		}
		return value;
	}

	public Sensor Cache_GetSensor(int int_0)
	{
		Sensor value = null;
		if (!Cache_Sensors.TryGetValue(int_0, out value))
		{
			SQLiteConnection dBConnection = DBConnection;
			value = DBFunctions.GetSensor(int_0, ref dBConnection);
			Cache_Sensors.TryAdd(int_0, value);
		}
		return value;
	}

	private void method_8(object sender, ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, UnguidedWeapon> e)
	{
		try
		{
			NotifyCollectionChangedAction action = e.Action;
			if (action == NotifyCollectionChangedAction.Remove)
			{
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					sides_ReadOnly[i].Contacts_NonAU.Remove(e.Key);
				}
			}
			if (Mines == null)
			{
				Mines = new List<UnguidedWeapon>();
			}
			if (e.Action == NotifyCollectionChangedAction.Add && e.NewValue != null && e.NewValue.IsMine)
			{
				Mines.Add(e.NewValue);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101045", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void OnUnitSideChanged(string theUnitID, string theOldSideID)
	{
		unitSideChangedEventHandler_0?.Invoke(this, theUnitID, theOldSideID);
	}

	private void method_9(XmlWriter xmlWriter_0)
	{
		try
		{
			if (MessageLog == null)
			{
				return;
			}
			xmlWriter_0.WriteRaw("<MessageLog>");
			List<LoggedMessage> list = MessageLog.ToList();
			foreach (LoggedMessage item in list)
			{
				try
				{
					if (item != null && (item.Side == null || Sides_ReadOnly.Contains(item.Side)))
					{
						xmlWriter_0.WriteRaw(item.ToXML());
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			xmlWriter_0.WriteRaw("</MessageLog>");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			xmlWriter_0.WriteRaw("</MessageLog>");
			ex2?.Data.Add("Error at 101046", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, NotifyDictionaryChangedEventArgs<string, ScenAttachmentObject> e)
	{
		scenAttachmentsChangedEventHandler_0?.Invoke();
	}

	private void method_11()
	{
		Side[] sides_ReadOnly = Sides_ReadOnly;
		Mission._FlightSize flightSize = default(Mission._FlightSize);
		foreach (Side side in sides_ReadOnly)
		{
			if (Information.IsNothing((object)side.Missions))
			{
				continue;
			}
			foreach (Mission item in side.get_MissionsTotal(this))
			{
				if (Information.IsNothing((object)item))
				{
					continue;
				}
				int num = 99;
				switch (item.MissionClass)
				{
				case Mission._MissionClass.Strike:
					flightSize = ((Strike)item).FlightSize;
					break;
				case Mission._MissionClass.Patrol:
					flightSize = ((Patrol)item).FlightSize;
					break;
				case Mission._MissionClass.Support:
					flightSize = ((SupportMission)item).FlightSize;
					break;
				case Mission._MissionClass.Ferry:
					flightSize = ((FerryMission)item).FlightSize;
					break;
				case Mission._MissionClass.Mining:
					flightSize = ((MiningMission)item).FlightSize;
					break;
				case Mission._MissionClass.MineClearing:
					flightSize = ((MineClearingMission)item).FlightSize;
					break;
				case Mission._MissionClass.Escort:
					flightSize = ((EscortMission)item).FlightSize;
					break;
				}
				if (!(flightSize == 0))
				{
					continue;
				}
				Scenario theScen = this;
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary = item.UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref theScen, GetEscortShooters: false, GetEscortNonShooters: false);
				foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item2 in dictionary)
				{
					Dictionary<string, Dictionary<string, int>> value = item2.Value;
					foreach (KeyValuePair<string, Dictionary<string, int>> item3 in value)
					{
						Dictionary<string, int> value2 = item3.Value;
						foreach (KeyValuePair<string, int> item4 in value2)
						{
							if (item4.Value < num)
							{
								num = item4.Value;
							}
						}
					}
				}
				switch (item.MissionClass)
				{
				case Mission._MissionClass.Strike:
				{
					Strike strike = (Strike)item;
					switch (strike.Type)
					{
					default:
						if (num == 1)
						{
							strike.FlightSize = 1;
						}
						else if (num == 2)
						{
							strike.FlightSize = 2;
						}
						else if (num == 3)
						{
							strike.FlightSize = 3;
						}
						else if (num > 5)
						{
							if (num <= 7)
							{
								strike.FlightSize = 6;
							}
							else
							{
								strike.FlightSize = 4;
							}
						}
						else
						{
							strike.FlightSize = 4;
						}
						break;
					case Strike.StrikeType.Sub_Strike:
						strike.FlightSize = 1;
						break;
					case Strike.StrikeType.Air_Intercept:
						if (num == 1)
						{
							strike.FlightSize = 1;
						}
						else
						{
							strike.FlightSize = 2;
						}
						break;
					}
					break;
				}
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)item;
					switch (patrol.Type)
					{
					case GlobalVariables.PatrolType.ASW:
						patrol.FlightSize = 1;
						break;
					default:
						patrol.FlightSize = 1;
						break;
					case GlobalVariables.PatrolType.AAW:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.ASuW_Land:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.ASuW_Mixed:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.SEAD:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					}
					break;
				}
				case Mission._MissionClass.Support:
					((SupportMission)item).FlightSize = 1;
					break;
				case Mission._MissionClass.Ferry:
				{
					FerryMission ferryMission = (FerryMission)item;
					if (num == 1)
					{
						ferryMission.FlightSize = 1;
					}
					else if (num == 2)
					{
						ferryMission.FlightSize = 2;
					}
					else if (num == 3)
					{
						ferryMission.FlightSize = 3;
					}
					else if (num > 5)
					{
						if (num <= 7)
						{
							ferryMission.FlightSize = 6;
						}
						else
						{
							ferryMission.FlightSize = 4;
						}
					}
					else
					{
						ferryMission.FlightSize = 4;
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)item;
					if (num == 1)
					{
						miningMission.FlightSize = 1;
					}
					else if (num == 2)
					{
						miningMission.FlightSize = 2;
					}
					else if (num == 3)
					{
						miningMission.FlightSize = 3;
					}
					else if (num <= 5)
					{
						miningMission.FlightSize = 4;
					}
					else if (num > 7)
					{
						miningMission.FlightSize = 4;
					}
					else
					{
						miningMission.FlightSize = 6;
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
					((MineClearingMission)item).FlightSize = 1;
					break;
				case Mission._MissionClass.Escort:
					flightSize = ((EscortMission)item).FlightSize;
					break;
				}
			}
		}
	}

	internal List<string> CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref Side theside, ref Mission theMission)
	{
		List<string> list = new List<string>();
		List<string> result;
		if (!Information.IsNothing((object)this) && !Information.IsNothing((object)theMission))
		{
			bool flag = false;
			bool flag2 = false;
			try
			{
				Mission obj = theMission;
				Scenario theScen = this;
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary = obj.UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref theScen, GetEscortShooters: false, GetEscortNonShooters: false);
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary2;
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary3;
				if (theMission.MissionClass == Mission._MissionClass.Strike && ((Strike)theMission).Escort_FlightSize_NonShooter == 0)
				{
					Mission obj2 = theMission;
					theScen = this;
					dictionary2 = obj2.UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref theScen, GetEscortShooters: true, GetEscortNonShooters: true);
					dictionary3 = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
				}
				else
				{
					Mission obj3 = theMission;
					theScen = this;
					dictionary2 = obj3.UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref theScen, GetEscortShooters: true, GetEscortNonShooters: false);
					Mission obj4 = theMission;
					theScen = this;
					dictionary3 = obj4.UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref theScen, GetEscortShooters: false, GetEscortNonShooters: true);
				}
				if (dictionary.Count > 0 || dictionary2.Count > 0 || dictionary3.Count > 0)
				{
					Mission._FlightSize theFlightSize = default(Mission._FlightSize);
					Mission._FlightSize theFlightSize2 = default(Mission._FlightSize);
					Mission._FlightSize theFlightSize3 = default(Mission._FlightSize);
					switch (theMission.MissionClass)
					{
					case Mission._MissionClass.Strike:
					{
						Strike strike = (Strike)theMission;
						theFlightSize = strike.FlightSize;
						theFlightSize2 = strike.Escort_FlightSize_Shooter;
						theFlightSize3 = strike.Escort_FlightSize_NonShooter;
						new int?(strike.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref strike.MinimumNumberOfAircraft));
						new int?(strike.FlightSize_To_ActualAircraftQty(ref theFlightSize2, ref strike.MinimumNumberOfAircraft_Escorts_Shooter));
						new int?(strike.FlightSize_To_ActualAircraftQty(ref theFlightSize3, ref strike.MinimumNumberOfAircraft_Escorts_NonShooter));
						flag = strike.UseFlightSizeHardLimit;
						flag2 = strike.UseFlightSizeHardLimit_Escort;
						break;
					}
					case Mission._MissionClass.Patrol:
					{
						Patrol patrol = (Patrol)theMission;
						theFlightSize = patrol.FlightSize;
						new int?(patrol.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref patrol.MinimumNumberOfAircraft));
						flag = patrol.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Support:
					{
						SupportMission supportMission = (SupportMission)theMission;
						theFlightSize = supportMission.FlightSize;
						new int?(supportMission.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref supportMission.MinimumNumberOfAircraft));
						flag = supportMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Ferry:
					{
						FerryMission obj6 = (FerryMission)theMission;
						theFlightSize = obj6.FlightSize;
						flag = obj6.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Mining:
					{
						MiningMission miningMission = (MiningMission)theMission;
						theFlightSize = miningMission.FlightSize;
						new int?(miningMission.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref miningMission.MinimumNumberOfAircraft));
						flag = miningMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.MineClearing:
					{
						MineClearingMission mineClearingMission = (MineClearingMission)theMission;
						theFlightSize = mineClearingMission.FlightSize;
						new int?(mineClearingMission.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref mineClearingMission.MinimumNumberOfAircraft));
						flag = mineClearingMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Escort:
					{
						EscortMission obj5 = (EscortMission)theMission;
						theFlightSize = obj5.FlightSize;
						flag2 = obj5.UseFlightSizeHardLimit;
						break;
					}
					}
					if (flag)
					{
						foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item4 in dictionary)
						{
							Dictionary<string, Dictionary<string, int>> value = item4.Value;
							string key = item4.Key;
							int num = 0;
							if (GameGeneral.FlightGroupFilter != GameGeneral.FlightGroupFilterOptions.Equipment)
							{
								foreach (KeyValuePair<string, Dictionary<string, int>> item5 in value)
								{
									Dictionary<string, int> value2 = item5.Value;
									foreach (KeyValuePair<string, int> item6 in value2)
									{
										_ = item6.Key;
										num += item6.Value;
									}
								}
							}
							foreach (KeyValuePair<string, Dictionary<string, int>> item7 in value)
							{
								Dictionary<string, int> value3 = item7.Value;
								string key2 = item7.Key;
								foreach (KeyValuePair<string, int> item8 in value3)
								{
									string key3 = item8.Key;
									int num2 = item8.Value;
									if (num > 0)
									{
										num2 = num;
									}
									if (num2 < theFlightSize)
									{
										string item = (Information.IsNothing((object)theside) ? ("Mission: " + theMission.Name + ", aircraft " + key2 + ", loadout " + key3 + " on ship/base " + key + ": Number of aircraft (" + Conversions.ToString(num2) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize.value) + ")") : ("Side: " + theside.Name + ", mission: " + theMission.Name + ", aircraft " + key2 + ", loadout " + key3 + " on ship/base " + key + ": Number of aircraft (" + Conversions.ToString(num2) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize.value) + ")"));
										list.Add(item);
									}
								}
							}
						}
					}
					if (flag2)
					{
						foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item9 in dictionary2)
						{
							Dictionary<string, Dictionary<string, int>> value4 = item9.Value;
							string key4 = item9.Key;
							foreach (KeyValuePair<string, Dictionary<string, int>> item10 in value4)
							{
								Dictionary<string, int> value5 = item10.Value;
								string key5 = item10.Key;
								foreach (KeyValuePair<string, int> item11 in value5)
								{
									string key6 = item11.Key;
									int value6 = item11.Value;
									if (value6 < theFlightSize2)
									{
										string item2 = ((!Information.IsNothing((object)theside)) ? ("Side: " + theside.Name + ", fighter/SEAD escort on mission: " + theMission.Name + ", aircraft " + key5 + ", loadout " + key6 + " on ship/base " + key4 + ": Number of aircraft (" + Conversions.ToString(value6) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize2.value) + ")") : ("Fighter/SEAD escort on mission: " + theMission.Name + ", aircraft " + key5 + ", loadout " + key6 + " on ship/base " + key4 + ": Number of aircraft (" + Conversions.ToString(value6) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize2.value) + ")"));
										list.Add(item2);
									}
								}
							}
						}
						if (!Information.IsNothing((object)theFlightSize3))
						{
							foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item12 in dictionary3)
							{
								Dictionary<string, Dictionary<string, int>> value7 = item12.Value;
								string key7 = item12.Key;
								foreach (KeyValuePair<string, Dictionary<string, int>> item13 in value7)
								{
									Dictionary<string, int> value8 = item13.Value;
									string key8 = item13.Key;
									foreach (KeyValuePair<string, int> item14 in value8)
									{
										string key9 = item14.Key;
										int value9 = item14.Value;
										if (value9 < theFlightSize3)
										{
											string item3 = (Information.IsNothing((object)theside) ? ("Support escort on mission: " + theMission.Name + ", aircraft " + key8 + ", loadout " + key9 + " on ship/base " + key7 + ": Number of aircraft (" + Conversions.ToString(value9) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize3.value) + ")") : ("Side: " + theside.Name + ", support escort on mission: " + theMission.Name + ", aircraft " + key8 + ", loadout " + key9 + " on ship/base " + key7 + ": Number of aircraft (" + Conversions.ToString(value9) + ") is lower than minimum flight size (" + Conversions.ToString(theFlightSize3.value) + ")"));
											list.Add(item3);
										}
									}
								}
							}
						}
					}
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101252", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<string>();
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = list;
		}
		return result;
	}

	private void method_12(object object_0, ObservableListModified<WeaponImpact> observableListModified_0)
	{
		foreach (WeaponImpact item in observableListModified_0.Items)
		{
			WeaponImpact.ExportWeaponImpactEvent(item, this);
		}
	}

	private void method_13(object object_0, ObservableListModified<Explosion> observableListModified_0)
	{
		foreach (Explosion item in observableListModified_0.Items)
		{
			Explosion.ExportExplosionEvent(item, this);
		}
	}

	public static bool MergeScenarios(string Scenario1FileName, string Scenario2FileName, string MergeResultFileName, DBOps.DatabaseMatchToleranceLevel DBMatchToleranceLevel, bool AllowMergingSameSide, ref string ProgressFeedBackString)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool result;
		try
		{
			if (!string.IsNullOrEmpty(Scenario1FileName))
			{
				if (FileExistsNative.FileExistsFast(Scenario1FileName))
				{
					if (!string.IsNullOrEmpty(Scenario2FileName))
					{
						if (FileExistsNative.FileExistsFast(Scenario2FileName))
						{
							if (!string.IsNullOrEmpty(MergeResultFileName))
							{
								if (Directory.Exists(Path.GetDirectoryName(MergeResultFileName)))
								{
									Scenario scenarioObject;
									try
									{
										stringBuilder.Append("Loading scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										ScenContainer scenContainer = ScenContainer.LoadFromFile(Scenario1FileName);
										string ErrorFeedback = null;
										scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
										stringBuilder.Append(" Done.");
										ProgressFeedBackString = stringBuilder.ToString();
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception ex2 = ex;
										stringBuilder.Append(" Error: " + ex2.Message).Append("\r\n").Append("\r\n")
											.Append("Merge aborted, please correct error and try again.");
										ProgressFeedBackString = stringBuilder.ToString();
										result = false;
										ProjectData.ClearProjectError();
										goto end_IL_0007;
									}
									stringBuilder.Append("\r\n").Append("\r\n");
									ProgressFeedBackString = stringBuilder.ToString();
									Scenario scenarioObject2;
									try
									{
										stringBuilder.Append("Loading scenario #2...");
										ProgressFeedBackString = stringBuilder.ToString();
										ScenContainer scenContainer2 = ScenContainer.LoadFromFile(Scenario2FileName);
										string ErrorFeedback = null;
										scenarioObject2 = scenContainer2.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
										stringBuilder.Append(" Done.");
										ProgressFeedBackString = stringBuilder.ToString();
									}
									catch (Exception ex3)
									{
										ProjectData.SetProjectError(ex3);
										Exception ex4 = ex3;
										stringBuilder.Append(" Error: " + ex4.Message).Append("\r\n").Append("\r\n")
											.Append("Merge aborted, please correct error and try again.");
										ProgressFeedBackString = stringBuilder.ToString();
										result = false;
										ProjectData.ClearProjectError();
										goto end_IL_0007;
									}
									DBOps.DatabaseMatchToleranceLevel databaseMatchToleranceLevel = DBOps.smethod_1(scenarioObject.DBUsed, scenarioObject2.DBUsed);
									switch (DBMatchToleranceLevel)
									{
									case DBOps.DatabaseMatchToleranceLevel.SameFamily:
										if (databaseMatchToleranceLevel == DBOps.DatabaseMatchToleranceLevel.ExactVersion || databaseMatchToleranceLevel == DBOps.DatabaseMatchToleranceLevel.SameFamily)
										{
											break;
										}
										stringBuilder.Append("'Same family' DB match level specified, but the two scenarios do not use the same general database. Merge aborted.");
										ProgressFeedBackString = stringBuilder.ToString();
										result = false;
										goto end_IL_0007;
									case DBOps.DatabaseMatchToleranceLevel.ExactVersion:
										if (databaseMatchToleranceLevel == DBOps.DatabaseMatchToleranceLevel.ExactVersion)
										{
											break;
										}
										stringBuilder.Append("'Exact version' DB match level specified, but the two scenarios do not reference the exact same database. Merge aborted.");
										ProgressFeedBackString = stringBuilder.ToString();
										result = false;
										goto end_IL_0007;
									}
									if (scenarioObject2.side_0.Length > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging sides (and their missions, contacts and ref. points) from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										Side[] array = scenarioObject2.side_0;
										_Closure$__475-0 closure$__475- = default(_Closure$__475-0);
										_Closure$__475-1 closure$__475-2 = default(_Closure$__475-1);
										_Closure$__475-2 closure$__475-3 = default(_Closure$__475-2);
										_Closure$__475-3 closure$__475-4 = default(_Closure$__475-3);
										_Closure$__475-4 closure$__475-5 = default(_Closure$__475-4);
										_Closure$__475-5 closure$__475-6 = default(_Closure$__475-5);
										_Closure$__475-6 closure$__475-7 = default(_Closure$__475-6);
										for (int i = 0; i < array.Length; i = checked(i + 1))
										{
											closure$__475- = new _Closure$__475-0(closure$__475-);
											closure$__475-.$VB$Local_theSide = array[i];
											stringBuilder.Append("\r\n").Append(closure$__475-.$VB$Local_theSide.Name).Append(": ");
											ProgressFeedBackString = stringBuilder.ToString();
											bool flag;
											if ((flag = scenarioObject.Sides_ReadOnly.Where(closure$__475-._Lambda$__0).Count() > 0) && !AllowMergingSameSide)
											{
												stringBuilder.Append("A theSide with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else if (flag && AllowMergingSameSide)
											{
												stringBuilder.Append("\r\n").Append("\r\n").Append("A theSide with the same unique ID already exists on scenario #1, and merging theSide clones is allowed. Proceeding... ");
												ProgressFeedBackString = stringBuilder.ToString();
												Side side = closure$__475-.$VB$Local_theSide;
												Side side2 = scenarioObject.Sides_ReadOnly.Where(closure$__475-._Lambda$__1).ElementAtOrDefault(0);
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging postures of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> postures_ReadOnly = side.Postures_ReadOnly;
												if (postures_ReadOnly.Count > 0)
												{
													ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> postures_ReadOnly2 = side2.Postures_ReadOnly;
													using IEnumerator<KeyValuePair<Side, Misc.PostureStance>> enumerator = postures_ReadOnly.GetEnumerator();
													while (enumerator.MoveNext())
													{
														closure$__475-2 = new _Closure$__475-1(closure$__475-2);
														closure$__475-2.$VB$Local_theKVP = enumerator.Current;
														if (postures_ReadOnly2.Where(closure$__475-2._Lambda$__2).Count() == 0)
														{
															side2.set_ConsidersThisSideToBe(closure$__475-2.$VB$Local_theKVP.Key, (Scenario)null, closure$__475-2.$VB$Local_theKVP.Value);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging reference points of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												List<ReferencePoint> list = side.RefPoints.ToList();
												if (list.Count > 0)
												{
													using List<ReferencePoint>.Enumerator enumerator2 = list.GetEnumerator();
													while (enumerator2.MoveNext())
													{
														closure$__475-3 = new _Closure$__475-2(closure$__475-3);
														closure$__475-3.$VB$Local_SourceRP = enumerator2.Current;
														if (side2.RefPoints.Where(closure$__475-3._Lambda$__3).Count() <= 0)
														{
															side2.RefPoints.Add(closure$__475-3.$VB$Local_SourceRP);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging exclusion zones of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												List<ExclusionZone> exclusionZones = side.ExclusionZones;
												if (exclusionZones.Count > 0)
												{
													using List<ExclusionZone>.Enumerator enumerator3 = exclusionZones.GetEnumerator();
													while (enumerator3.MoveNext())
													{
														closure$__475-4 = new _Closure$__475-3(closure$__475-4);
														closure$__475-4.$VB$Local_SourceEZ = enumerator3.Current;
														if (side2.ExclusionZones.Where(closure$__475-4._Lambda$__4).Count() <= 0)
														{
															side2.ExclusionZones.Add(closure$__475-4.$VB$Local_SourceEZ);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging no-nav zones of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												List<NoNavZone> noNavZones = side.NoNavZones;
												if (noNavZones.Count > 0)
												{
													using List<NoNavZone>.Enumerator enumerator4 = noNavZones.GetEnumerator();
													while (enumerator4.MoveNext())
													{
														closure$__475-5 = new _Closure$__475-4(closure$__475-5);
														closure$__475-5.$VB$Local_SourceNNZ = enumerator4.Current;
														if (side2.NoNavZones.Where(closure$__475-5._Lambda$__5).Count() <= 0)
														{
															side2.NoNavZones.Add(closure$__475-5.$VB$Local_SourceNNZ);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging quick-jump slots of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												Dictionary<int, QuickJumpSlot> quickJumpSlots = side.QuickJumpSlots;
												if (quickJumpSlots.Count > 0)
												{
													foreach (KeyValuePair<int, QuickJumpSlot> item in quickJumpSlots)
													{
														if (!side2.QuickJumpSlots.ContainsKey(item.Key))
														{
															side2.QuickJumpSlots.Add(item.Key, item.Value);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging contacts zones of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												ObservableCollections.ObservableDictionary<string, Contact> contacts = side.Contacts;
												if (contacts.Count > 0)
												{
													foreach (KeyValuePair<string, Contact> item2 in contacts)
													{
														if (!side2.Contacts.ContainsKey(item2.Key))
														{
															side2.Contacts.Add(item2.Key, item2.Value);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging base-contacts zones of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												System.Collections.ObjectModel.ObservableDictionary<string, Contact> baseContacts = side.BaseContacts;
												if (baseContacts.Count > 0)
												{
													foreach (KeyValuePair<string, Contact> item3 in baseContacts)
													{
														if (!side2.BaseContacts.ContainsKey(item3.Key))
														{
															side2.BaseContacts.Add(item3.Key, item3.Value);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging non-AU contacts zones of theSide: " + side.Name + "...");
												ProgressFeedBackString = stringBuilder.ToString();
												HashSet<string> contacts_NonAU = side.Contacts_NonAU;
												if (contacts_NonAU.Count > 0)
												{
													foreach (string item4 in contacts_NonAU)
													{
														side2.Contacts_NonAU.Add(item4);
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging missions of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												ReadOnlyCollection<Mission> missions = side.Missions;
												if (missions.Count > 0)
												{
													using IEnumerator<Mission> enumerator9 = missions.GetEnumerator();
													while (enumerator9.MoveNext())
													{
														closure$__475-6 = new _Closure$__475-5(closure$__475-6);
														closure$__475-6.$VB$Local_SourceMission = enumerator9.Current;
														if (side2.Missions.Where(closure$__475-6._Lambda$__6).Count() > 0)
														{
															continue;
														}
														side2.Missions_Add(closure$__475-6.$VB$Local_SourceMission);
														foreach (ActiveUnit activeUnits_ in scenarioObject2.ActiveUnits_List)
														{
															if (activeUnits_.ActiveMissionOrPackage() != null && activeUnits_.ActiveMissionOrPackage() == closure$__475-6.$VB$Local_SourceMission && scenarioObject.ActiveUnits.TryGetValue(activeUnits_.ObjectID, out var value) && value.ActiveMissionOrPackage() == null)
															{
																ActiveUnit activeUnit = value;
																Mission value2 = closure$__475-6.$VB$Local_SourceMission;
																Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
																activeUnit.Set_AssignedMissionOrPackage(value2, SetMissionOnly: true, IgnoreCommsState: false, ref Result);
															}
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging special actions of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												Dictionary<string, SpecialAction> specialActions = side.SpecialActions;
												if (specialActions.Count > 0)
												{
													foreach (KeyValuePair<string, SpecialAction> item5 in specialActions)
													{
														if (!side2.SpecialActions.ContainsKey(item5.Key))
														{
															side2.SpecialActions.Add(item5.Key, item5.Value);
														}
													}
												}
												stringBuilder.Append("\r\n").Append("\r\n").Append("Merging weapon salvos of theSide: " + side.Name + " (base version wins on conflicts)...");
												ProgressFeedBackString = stringBuilder.ToString();
												ObservableList<WeaponSalvo> observableList = new ObservableList<WeaponSalvo>(side.WeaponSalvos.ToList());
												if (observableList.Count > 0)
												{
													using List<WeaponSalvo>.Enumerator enumerator12 = observableList.GetEnumerator();
													while (enumerator12.MoveNext())
													{
														closure$__475-7 = new _Closure$__475-6(closure$__475-7);
														closure$__475-7.$VB$Local_SourceSalvo = enumerator12.Current;
														if (side2.WeaponSalvos.Where(closure$__475-7._Lambda$__7).Count() <= 0)
														{
															side2.AddWeaponSalvo(closure$__475-7.$VB$Local_SourceSalvo);
														}
													}
												}
												stringBuilder.Append("Finished merging objects of theSide: " + side.Name);
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												scenarioObject.AddSide(closure$__475-.$VB$Local_theSide);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.Explosions.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging explosions from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										using List<Explosion>.Enumerator enumerator13 = scenarioObject2.Explosions.GetEnumerator();
										_Closure$__475-7 closure$__475-8 = default(_Closure$__475-7);
										while (enumerator13.MoveNext())
										{
											closure$__475-8 = new _Closure$__475-7(closure$__475-8);
											closure$__475-8.$VB$Local_theExplosion = enumerator13.Current;
											stringBuilder.Append("\r\n").Append(closure$__475-8.$VB$Local_theExplosion.ObjectID).Append(": ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (scenarioObject.Explosions.Where(closure$__475-8._Lambda$__8).Count() <= 0)
											{
												scenarioObject.Explosions.Add(closure$__475-8.$VB$Local_theExplosion);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("An explosion with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.WeaponImpacts.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging weapon impacts from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										using List<WeaponImpact>.Enumerator enumerator14 = scenarioObject2.WeaponImpacts.GetEnumerator();
										_Closure$__475-8 closure$__475-9 = default(_Closure$__475-8);
										while (enumerator14.MoveNext())
										{
											closure$__475-9 = new _Closure$__475-8(closure$__475-9);
											closure$__475-9.$VB$Local_theWI = enumerator14.Current;
											stringBuilder.Append("\r\n").Append(closure$__475-9.$VB$Local_theWI.ObjectID).Append(": ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (scenarioObject.WeaponImpacts.Where(closure$__475-9._Lambda$__9).Count() <= 0)
											{
												scenarioObject.WeaponImpacts.Add(closure$__475-9.$VB$Local_theWI);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("A weapon impact with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.UnguidedWeapons.HasElements())
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging unguided weapons from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in scenarioObject2.UnguidedWeapons)
										{
											stringBuilder.Append("\r\n").Append(unguidedWeapon.Key).Append(" (")
												.Append(unguidedWeapon.Value.Name)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.UnguidedWeapons.ContainsKey(unguidedWeapon.Key))
											{
												scenarioObject.UnguidedWeapons.AddOrUpdate(unguidedWeapon.Key, unguidedWeapon.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("An unguided weapon with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.ChaffClouds.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging chaff clouds from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										using List<ChaffCorridorCloud>.Enumerator enumerator16 = scenarioObject2.ChaffClouds.GetEnumerator();
										_Closure$__475-9 closure$__475-10 = default(_Closure$__475-9);
										while (enumerator16.MoveNext())
										{
											closure$__475-10 = new _Closure$__475-9(closure$__475-10);
											closure$__475-10.$VB$Local_theCloud = enumerator16.Current;
											stringBuilder.Append("\r\n").Append(closure$__475-10.$VB$Local_theCloud.ObjectID).Append(": ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (scenarioObject.ChaffClouds.Where(closure$__475-10._Lambda$__10).Count() > 0)
											{
												stringBuilder.Append("A chaff cloud with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												scenarioObject.ChaffClouds.Add(closure$__475-10.$VB$Local_theCloud);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.ActiveUnits.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging active units from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, ActiveUnit> activeUnit2 in scenarioObject2.ActiveUnits)
										{
											stringBuilder.Append("\r\n").Append(activeUnit2.Value.Name).Append(" (")
												.Append(activeUnit2.Value.UnitClass)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.ActiveUnits.ContainsKey(activeUnit2.Key))
											{
												scenarioObject.ActiveUnits.TryAdd(activeUnit2.Key, activeUnit2.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("An active unit with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.Groups.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging groups from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (Group group in scenarioObject2.Groups)
										{
											stringBuilder.Append("\r\n").Append(group.Name).Append(": ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (Misc.ContainsByName(scenarioObject.Groups, group.Name))
											{
												stringBuilder.Append("A group with the same name already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												scenarioObject.Groups.Add(group);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.EventTriggers.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event triggers from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, EventTrigger> eventTrigger in scenarioObject2.EventTriggers)
										{
											stringBuilder.Append("\r\n").Append(eventTrigger.Value.Name).Append(" (")
												.Append(eventTrigger.Key)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (scenarioObject.EventTriggers.ContainsKey(eventTrigger.Key))
											{
												stringBuilder.Append("An event trigger with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												scenarioObject.EventTriggers.TryAdd(eventTrigger.Key, eventTrigger.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.EventConditions.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event conditions from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, EventCondition> eventCondition in scenarioObject2.EventConditions)
										{
											stringBuilder.Append("\r\n").Append(eventCondition.Value.Name).Append(" (")
												.Append(eventCondition.Key)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.EventConditions.ContainsKey(eventCondition.Key))
											{
												scenarioObject.EventConditions.TryAdd(eventCondition.Key, eventCondition.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("An event condition with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.EventActions.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event actions from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, EventAction> eventAction in scenarioObject2.EventActions)
										{
											stringBuilder.Append("\r\n").Append(eventAction.Value.Name).Append(" (")
												.Append(eventAction.Key)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.EventActions.ContainsKey(eventAction.Key))
											{
												scenarioObject.EventActions.TryAdd(eventAction.Key, eventAction.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("An event action with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.SimEvents.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging sim events from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, SimEvent> simEvent in scenarioObject2.SimEvents)
										{
											stringBuilder.Append("\r\n").Append(simEvent.Value.Name).Append(" (")
												.Append(simEvent.Key)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.SimEvents.ContainsKey(simEvent.Key))
											{
												scenarioObject.SimEvents.TryAdd(simEvent.Key, simEvent.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("A sim event with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									if (scenarioObject2.ScenAttachments.Count > 0)
									{
										stringBuilder.Append("\r\n").Append("\r\n").Append("Merging scenario attachments from scenario #2 into scenario #1...");
										ProgressFeedBackString = stringBuilder.ToString();
										foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in scenarioObject2.ScenAttachments)
										{
											stringBuilder.Append("\r\n").Append(scenAttachment.Value.Name).Append(" (")
												.Append(scenAttachment.Key)
												.Append("): ");
											ProgressFeedBackString = stringBuilder.ToString();
											if (!scenarioObject.ScenAttachments.ContainsKey(scenAttachment.Key))
											{
												scenarioObject.ScenAttachments.Add(scenAttachment.Key, scenAttachment.Value);
												stringBuilder.Append("OK");
												ProgressFeedBackString = stringBuilder.ToString();
											}
											else
											{
												stringBuilder.Append("A scen attachment object with the same unique ID already exists on scenario #1 - skipping.");
												ProgressFeedBackString = stringBuilder.ToString();
											}
										}
									}
									int unitsAutoIncrement = scenarioObject.ActiveUnits.Count + scenarioObject.Groups.Count + scenarioObject.UnguidedWeapons.Count + scenarioObject.Sides_ReadOnly.Select([SpecialName] (Side theSide) => theSide.RefPoints.Count).Sum() + 10;
									scenarioObject.UnitsAutoIncrement = unitsAutoIncrement;
									stringBuilder.Append("\r\n").Append("\r\n").Append("Finished merging objects - saving result...");
									ProgressFeedBackString = stringBuilder.ToString();
									Command_Core.LoadSave.LoadSave.SaveScenario(scenarioObject, scenarioObject.GetCurrentSide(), MergeResultFileName, SBR: false);
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging completed successfully!");
									ProgressFeedBackString = stringBuilder.ToString();
									scenarioObject = null;
									scenarioObject2 = null;
									result = true;
								}
								else
								{
									stringBuilder.Append("The directory set for the merge result file does not exist!");
									ProgressFeedBackString = stringBuilder.ToString();
									result = false;
								}
							}
							else
							{
								stringBuilder.Append("No filename selected for the merge result!");
								ProgressFeedBackString = stringBuilder.ToString();
								result = false;
							}
						}
						else
						{
							stringBuilder.Append("Filename set for scenario #2 is not valid!");
							ProgressFeedBackString = stringBuilder.ToString();
							result = false;
						}
					}
					else
					{
						stringBuilder.Append("No filename selected for scenario #2!");
						ProgressFeedBackString = stringBuilder.ToString();
						result = false;
					}
				}
				else
				{
					stringBuilder.Append("Filename set for scenario #1 is not valid!");
					ProgressFeedBackString = stringBuilder.ToString();
					result = false;
				}
			}
			else
			{
				stringBuilder.Append("No filename selected for scenario #1!");
				ProgressFeedBackString = stringBuilder.ToString();
				result = false;
			}
			end_IL_0007:;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.SendMessageBoxToUI("Unhandled exception during merge: " + ex6.Message + "\r\n\r\nStacktrace: " + ex6.StackTrace, null);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void CreateNatureSideIfNeeded()
	{
		if (!NatureSideExists())
		{
			Scenario theScen = this;
			Side theSide = new Side("Nature", ref theScen, IsNatureSide: true);
			AddSide(theSide);
		}
	}

	public Side GetNatureSide()
	{
		Side[] sides_ReadOnly = Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side.IsNature)
			{
				return side;
			}
		}
		Side result = default(Side);
		return result;
	}

	public bool NatureSideExists()
	{
		bool result;
		try
		{
			if (side_0 != null)
			{
				Side[] array = side_0;
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						if (!array[num].IsNature)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						break;
					}
					result = false;
					break;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string GetConcatenated_MDSP_Errors(string mission, string flight)
	{
		if (MissionPlannerErrorList != null)
		{
			string text = "";
			foreach (MDSP_Error missionPlannerError in MissionPlannerErrorList)
			{
				if (!((Operators.CompareString(mission, "", false) != 0) & (Operators.CompareString(mission, (string)null, false) != 0) & (Operators.CompareString(mission, missionPlannerError.Mission, false) != 0)) && !((Operators.CompareString(flight, "", false) != 0) & (Operators.CompareString(flight, (string)null, false) != 0) & (Operators.CompareString(flight, missionPlannerError.Flight, false) != 0)))
				{
					text = text + Environment.NewLine + " Mission:" + missionPlannerError.Mission + " Flight " + missionPlannerError.Flight + " Error" + missionPlannerError.Message;
				}
			}
			return text;
		}
		string result = default(string);
		return result;
	}

	private void method_14(object sender, ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, ActiveUnit> e)
	{
		lock (lockObject_6)
		{
			try
			{
				pooledList_0 = null;
				if (Sides_ReadOnly == null)
				{
					return;
				}
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					sides_ReadOnly[i].set_FriendlyUnits(this, IncludeWeapons: false, (List<ActiveUnit>)null);
				}
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
					if (!Information.IsNothing((object)e.NewValue.get_UnitSide(SetSideOnly: false)) && !e.NewValue.get_UnitSide(SetSideOnly: false).Units.Contains(e.NewValue))
					{
						e.NewValue.get_UnitSide(SetSideOnly: false).Units.Add(e.NewValue);
						unitAddedEventHandler_0?.Invoke(this, e.NewValue.ObjectID);
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					unitRemovedEventHandler_0?.Invoke(this, e.OldValue);
					if (e.OldValue.get_UnitSide(SetSideOnly: false) != null)
					{
						e.OldValue.get_UnitSide(SetSideOnly: false).Units.Remove(e.OldValue);
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200568", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_15(object sender, ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventTrigger> e)
	{
		eventTriggersChangedEventHandler_0?.Invoke(this);
	}

	private void method_16(object sender, ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventCondition> e)
	{
		eventConditionsChangedEventHandler_0?.Invoke(this);
	}

	private void method_17(object sender, ConcurrentObservableCollections.ConcurrentObservableDictionary.DictionaryChangedEventArgs<string, EventAction> e)
	{
		eventActionsChangedEventHandler_0?.Invoke(this);
	}

	internal int GetNextTransmissionID()
	{
		LastTransmissionId++;
		return LastTransmissionId;
	}

	private NetworkContext method_18(Side side_2)
	{
		NetworkContext networkContext = new NetworkContext(side_2);
		foreach (ActiveUnit unit in side_2.Units)
		{
			if (unit.Comms_ReadOnly.Count() == 0 && !unit.IsGroup)
			{
				continue;
			}
			if (unit.IsGroup)
			{
				networkContext.Groups.Add((Group)unit);
			}
			else
			{
				if (unit.IsGroupMember())
				{
					continue;
				}
				if (unit.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)unit;
					if (method_19(aircraft))
					{
						continue;
					}
					bool flag = true;
					if (aircraft.Type == Aircraft._AircraftType.AEW)
					{
						networkContext.AEWList.Add(aircraft);
					}
					else if (flag == aircraft.IsTanker)
					{
						networkContext.TankerList.Add(aircraft);
					}
					else
					{
						networkContext.FlyingAircraft.Add(aircraft);
					}
				}
				if (unit.IsFacility)
				{
					Facility facility = (Facility)unit;
					if (facility.Category == Facility._FacilityCategory.AirBase)
					{
						networkContext.AirBases.Add(facility);
					}
				}
				if (unit.IsVehicle)
				{
					networkContext.VehicleList.Add((Vehicle)unit);
				}
				if (unit.IsSubmarine)
				{
					Submarine submarine = (Submarine)unit;
					if (!method_20(submarine.DockingOps))
					{
						networkContext.SubList.Add(submarine);
					}
				}
				if (unit.IsShip)
				{
					Ship ship = (Ship)unit;
					if (!method_20(ship.DockingOps))
					{
						networkContext.ShipList.Add(ship);
					}
				}
			}
		}
		return networkContext;
	}

	private bool method_19(Aircraft aircraft_0)
	{
		Aircraft_AirOps._AirOpsCondition condition = aircraft_0.AirOps.Condition;
		int result2;
		if (condition - 1 > Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff && condition != Aircraft_AirOps._AirOpsCondition.PreparingToLaunch)
		{
			if (condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
			{
				bool result = default(bool);
				return result;
			}
			result2 = 1;
		}
		else
		{
			result2 = 1;
		}
		return (byte)result2 != 0;
	}

	private bool method_20(ActiveUnit_DockingOps activeUnit_DockingOps_0)
	{
		if (activeUnit_DockingOps_0.Condition != ActiveUnit_DockingOps._DockingOpsCondition.Docked)
		{
			return activeUnit_DockingOps_0.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Readying;
		}
		return true;
	}

	private ActiveUnit method_21(ActiveUnit activeUnit_0)
	{
		if (!activeUnit_0.IsAircraft)
		{
			if (!activeUnit_0.IsShip)
			{
				if (activeUnit_0.IsSubmarine)
				{
					return ((Submarine)activeUnit_0).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				}
				return null;
			}
			return ((Ship)activeUnit_0).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
		}
		return ((Aircraft)activeUnit_0).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
	}

	private void method_22(Side side_2, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, CommNetwork.NetworkCreationReason networkCreationReason_0, List<NetworkLog> list_9, string string_7)
	{
		if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).Type == Aircraft._AircraftType.AEW)
		{
			networkCreationReason_0 = CommNetwork.NetworkCreationReason.AEWComm;
			KeyValuePair<string, CommNetwork> keyValuePair = side_2.CommNetworks.FirstOrDefault([SpecialName] (KeyValuePair<string, CommNetwork> c) => c.Value.Reason == CommNetwork.NetworkCreationReason.AEWComm);
			if (keyValuePair.Value != null)
			{
				side_2.AddUnitToNetwork(keyValuePair.Value.ID, activeUnit_0);
			}
			else
			{
				side_2.CreateNextNetworkUnitsReason(new HashSet<Module_Unit.Unit> { activeUnit_0 }, networkCreationReason_0);
			}
			list_9.Add(new NetworkLog(activeUnit_0, networkCreationReason_0, string_7));
			return;
		}
		if (activeUnit_1 == null)
		{
			list_9.Add(new NetworkLog(activeUnit_0, networkCreationReason_0, string_7));
			return;
		}
		List<CommNetwork> networks = activeUnit_1.CommStuff.Networks;
		if (networks != null && networks.Count > 0 && networks[0].Reason != CommNetwork.NetworkCreationReason.AEWComm)
		{
			side_2.AddUnitToNetwork(networks[0].ID, activeUnit_0);
		}
		else if (networks != null && networks.Count > 1)
		{
			side_2.AddUnitToNetwork(networks[1].ID, activeUnit_0);
		}
		else
		{
			side_2.CreateNextNetworkUnitsReason(new HashSet<Module_Unit.Unit> { activeUnit_0, activeUnit_1 }, networkCreationReason_0);
		}
		list_9.Add(new NetworkLog(activeUnit_0, networkCreationReason_0, string_7));
	}

	private void method_23(Side side_2, IEnumerable<Module_Unit.Unit> ienumerable_0, CommNetwork.NetworkCreationReason networkCreationReason_0, List<NetworkLog> list_9, string string_7, string string_8)
	{
		HashSet<Module_Unit.Unit> hashSet = ienumerable_0.ToHashSet();
		if (hashSet.Count != 0)
		{
			side_2.CreateNextNetworkUnitsReason(hashSet, networkCreationReason_0, null, string_8);
		}
	}

	private Aircraft method_24(ActiveUnit activeUnit_0, NetworkContext networkContext_0, ref CommNetwork.NetworkCreationReason networkCreationReason_0)
	{
		_Closure$__494-0 arg = default(_Closure$__494-0);
		_Closure$__494-0 CS$<>8__locals14 = new _Closure$__494-0(arg);
		CS$<>8__locals14.$VB$Local_theUnit = activeUnit_0;
		foreach (Aircraft item in networkContext_0.AEWList.OrderBy((CS$<>8__locals14.$I0 != null) ? CS$<>8__locals14.$I0 : (CS$<>8__locals14.$I0 = [SpecialName] (Aircraft theHUB) => Math2.CalcDist(theHUB, CS$<>8__locals14.$VB$Local_theUnit))))
		{
			if (ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(item, CS$<>8__locals14.$VB$Local_theUnit.Comms_ReadOnly, CS$<>8__locals14.$VB$Local_theUnit).EvaluationEnum == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
			{
				networkCreationReason_0 = CommNetwork.NetworkCreationReason.AEWProximity;
				return item;
			}
		}
		if (CS$<>8__locals14.$VB$Local_theUnit.IsAircraft)
		{
			foreach (Aircraft item2 in networkContext_0.TankerList.OrderBy((CS$<>8__locals14.$I1 != null) ? CS$<>8__locals14.$I1 : (CS$<>8__locals14.$I1 = [SpecialName] (Aircraft theHUB) => Math2.CalcDist(theHUB, CS$<>8__locals14.$VB$Local_theUnit))))
			{
				if (ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(item2, CS$<>8__locals14.$VB$Local_theUnit.Comms_ReadOnly, CS$<>8__locals14.$VB$Local_theUnit).EvaluationEnum == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
				{
					networkCreationReason_0 = CommNetwork.NetworkCreationReason.TankerProximity;
					return item2;
				}
			}
		}
		return null;
	}

	private ActiveUnit method_25(ActiveUnit activeUnit_0, Side side_2, bool bool_3)
	{
		_Closure$__495-0 arg = default(_Closure$__495-0);
		_Closure$__495-0 CS$<>8__locals6 = new _Closure$__495-0(arg);
		CS$<>8__locals6.$VB$Local_theUnit = activeUnit_0;
		IOrderedEnumerable<ActiveUnit> orderedEnumerable = from theOtherAU in side_2.Units
			where Operators.CompareString(theOtherAU.ObjectID, CS$<>8__locals6.$VB$Local_theUnit.ObjectID, false) != 0 && theOtherAU.Comms_ReadOnly.Count() > 0
			orderby Math2.CalcDist(CS$<>8__locals6.$VB$Local_theUnit, theOtherAU)
			select theOtherAU;
		foreach (ActiveUnit item in orderedEnumerable)
		{
			if (item.CommStuff.Networks == null || item.CommStuff.Networks.Count == 0)
			{
				continue;
			}
			if (bool_3)
			{
				CommNetwork.NetworkCreationReason reason = item.CommStuff.Networks[0].Reason;
				if (reason == CommNetwork.NetworkCreationReason.HomeBaseComm || reason == CommNetwork.NetworkCreationReason.Generic || ((reason == CommNetwork.NetworkCreationReason.AirBases) & CS$<>8__locals6.$VB$Local_theUnit.IsSingleUnitAirbase))
				{
					continue;
				}
			}
			if (ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(item, CS$<>8__locals6.$VB$Local_theUnit.Comms_ReadOnly, CS$<>8__locals6.$VB$Local_theUnit).EvaluationEnum == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
			{
				return item;
			}
		}
		return null;
	}

	private ActiveUnit method_26(ActiveUnit activeUnit_0, Side side_2)
	{
		return (from u in side_2.Units
			where u != activeUnit_0 && u.CommStuff?.Networks != null && u.CommStuff.Networks.Count > 0
			orderby Math2.CalcDist(activeUnit_0, u)
			select u).FirstOrDefault();
	}

	private bool method_27(ActiveUnit activeUnit_0, NetworkContext networkContext_0, Side side_2, List<NetworkLog> list_9)
	{
		ActiveUnit activeUnit = method_21(activeUnit_0);
		if (activeUnit == null)
		{
			int num;
			if (activeUnit_0.IsAircraft && networkContext_0.AEWList.Contains((Aircraft)activeUnit_0))
			{
				Aircraft activeUnit_1 = networkContext_0.AEWList.Where([SpecialName] (Aircraft theAEW) => Operators.CompareString(theAEW.ObjectID, activeUnit_0.ObjectID, false) != 0).FirstOrDefault();
				method_22(side_2, activeUnit_0, activeUnit_1, CommNetwork.NetworkCreationReason.AEWComm, list_9, $"AEW Comm: {activeUnit_0.Name}");
				num = 0;
			}
			else
			{
				num = 0;
			}
			CommNetwork.NetworkCreationReason networkCreationReason_ = (CommNetwork.NetworkCreationReason)num;
			Aircraft aircraft = method_24(activeUnit_0, networkContext_0, ref networkCreationReason_);
			if (aircraft == null)
			{
				ActiveUnit activeUnit2 = method_25(activeUnit_0, side_2, bool_3: true);
				if (activeUnit2 != null)
				{
					method_22(side_2, activeUnit_0, activeUnit2, CommNetwork.NetworkCreationReason.Generic, list_9, $"nearest comm compatible: {activeUnit2.Name}");
					return true;
				}
				ActiveUnit activeUnit3 = method_25(activeUnit_0, side_2, bool_3: false);
				if (activeUnit3 == null)
				{
					ActiveUnit activeUnit4 = method_26(activeUnit_0, side_2);
					if (activeUnit4 == null)
					{
						HashSet<Module_Unit.Unit> members = new HashSet<Module_Unit.Unit> { activeUnit_0 };
						side_2.CreateNextNetworkUnitsReason(members, CommNetwork.NetworkCreationReason.Generic);
						list_9.Add(new NetworkLog(activeUnit_0, CommNetwork.NetworkCreationReason.Generic, "no network available, created new one"));
						return true;
					}
					side_2.AddUnitToNetwork(activeUnit4.CommStuff.Networks[0].ID, activeUnit_0);
					list_9.Add(new NetworkLog(activeUnit_0, CommNetwork.NetworkCreationReason.Generic, $"geographic fallback: network of {activeUnit4.Name}"));
					return true;
				}
				method_22(side_2, activeUnit_0, activeUnit3, CommNetwork.NetworkCreationReason.Generic, list_9, $"nearest comm compatible (any network): {activeUnit3.Name}");
				return true;
			}
			method_22(side_2, activeUnit_0, aircraft, networkCreationReason_, list_9, $"theHUB: {aircraft.Name}");
			return true;
		}
		method_22(side_2, activeUnit_0, activeUnit, CommNetwork.NetworkCreationReason.HomeBaseComm, list_9, $"home base: {activeUnit.Name}");
		return true;
	}

	public void FullNetworkGeneration(Side thePassedSide = null)
	{
		try
		{
			List<Side> list = new List<Side>(Sides_ReadOnly);
			_Closure$__498-0 closure$__498- = default(_Closure$__498-0);
			foreach (Side item in list)
			{
				try
				{
					if (thePassedSide != null && Operators.CompareString(thePassedSide.ObjectID, item.ObjectID, false) != 0)
					{
						continue;
					}
					item.CommNetworks.Clear();
					item.SelectedNetworks.Clear();
					List<NetworkLog> list2 = new List<NetworkLog>();
					NetworkContext networkContext = method_18(item);
					HashSet<ActiveUnit> hashSet = new HashSet<ActiveUnit>();
					NetworkRuleRegistry networkRuleRegistry = method_29(item, list2);
					bool flag;
					if (flag = networkRuleRegistry != null && networkRuleRegistry.Rules.Count > 0)
					{
						closure$__498- = new _Closure$__498-0(closure$__498-);
						closure$__498-.$VB$Me = this;
						list2.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Registry] Running " + Conversions.ToString(networkRuleRegistry.Rules.Count) + " user rules for side " + item.Name));
						closure$__498-.$VB$Local_execCtx = new NetworkRuleExecutionContext();
						closure$__498-.$VB$Local_execCtx.Side = item;
						closure$__498-.$VB$Local_execCtx.AEWUnits = networkContext.AEWList.Cast<ActiveUnit>();
						closure$__498-.$VB$Local_execCtx.TankerUnits = networkContext.TankerList.Cast<ActiveUnit>();
						closure$__498-.$VB$Local_execCtx.Log = list2;
						closure$__498-.$VB$Local_execCtx.CreateNetwork = method_23;
						closure$__498-.$VB$Local_execCtx.AssignToNetwork = method_22;
						closure$__498-.$VB$Local_execCtx.ExecuteLua = closure$__498-._Lambda$__0;
						int num = 0;
						foreach (NetworkRule rule in networkRuleRegistry.Rules)
						{
							if (!rule.Enabled)
							{
								continue;
							}
							if (closure$__498-.$VB$Local_execCtx.ExecuteLua != null)
							{
								try
								{
									rule.Apply(closure$__498-.$VB$Local_execCtx, hashSet);
									num++;
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception ex2 = ex;
									list2.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[NetworkRule '" + rule.Name + "'] exception: " + ex2.Message));
									ex2?.Data.Add("NetworkRule_" + rule.Name, ex2.Message);
									GameGeneral.WriteExceptionsToLog(ex2);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								list2.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[NetworkRule '" + rule.Name + "'] SKIPPED — ExecuteLua is Nothing"));
							}
						}
						list2.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Registry] " + Conversions.ToString(num) + " rules ran, " + Conversions.ToString(hashSet.Count) + " units networked"));
					}
					else
					{
						list2.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Registry] No user rules — running hardcoded defaults for side " + item.Name));
						if (networkContext.AirBases.Count > 0)
						{
							method_23(item, networkContext.AirBases.Cast<Module_Unit.Unit>(), CommNetwork.NetworkCreationReason.AirBases, list2, null, "airbase network");
							hashSet.UnionWith(networkContext.AirBases);
						}
						if (networkContext.AEWList.Count > 0)
						{
							method_23(item, networkContext.AEWList.Cast<Module_Unit.Unit>(), CommNetwork.NetworkCreationReason.AEWComm, list2, null, "AEW network");
							hashSet.UnionWith(networkContext.AEWList);
						}
						foreach (Group group in networkContext.Groups)
						{
							if (!group.Units.Values.Any([SpecialName] (ActiveUnit u) => u.Comms_ReadOnly.Count() > 0))
							{
								continue;
							}
							method_23(item, group.Units.Values.Cast<Module_Unit.Unit>(), CommNetwork.NetworkCreationReason.Generic, list2, null, "group: " + group.Name);
							foreach (ActiveUnit value2 in group.Units.Values)
							{
								hashSet.Add(value2);
							}
						}
						foreach (Group group2 in networkContext.Groups)
						{
							foreach (KeyValuePair<string, ActiveUnit> unit in group2.Units)
							{
								ActiveUnit value = unit.Value;
								if (value.IsGroupLead())
								{
									ActiveUnit activeUnit = method_21(value);
									if (activeUnit != null)
									{
										method_22(item, value, activeUnit, CommNetwork.NetworkCreationReason.HomeBaseComm, list2, "lead " + value.Name + " -> " + activeUnit.Name);
									}
								}
							}
						}
						List<ActiveUnit> list3 = new List<ActiveUnit>();
						list3.AddRange(networkContext.FlyingAircraft);
						list3.AddRange(networkContext.AEWList);
						list3.AddRange(networkContext.TankerList);
						list3.AddRange(networkContext.ShipList);
						list3.AddRange(networkContext.SubList);
						list3.AddRange(networkContext.VehicleList);
						foreach (ActiveUnit item2 in list3)
						{
							if (!item2.IsGroup && !item2.IsGroupMember())
							{
								ActiveUnit activeUnit2 = method_21(item2);
								if (activeUnit2 != null)
								{
									method_22(item, item2, activeUnit2, CommNetwork.NetworkCreationReason.HomeBaseComm, list2, item2.Name + " -> " + activeUnit2.Name);
									hashSet.Add(item2);
								}
							}
						}
						foreach (Aircraft item3 in networkContext.AEWList.Cast<Aircraft>().Concat(networkContext.TankerList))
						{
							CommNetwork.NetworkCreationReason networkCreationReason_ = (networkContext.AEWList.Contains(item3) ? CommNetwork.NetworkCreationReason.AEWProximity : CommNetwork.NetworkCreationReason.TankerProximity);
							List<Module_Unit.Unit> list4 = new List<Module_Unit.Unit> { item3 };
							foreach (Group group3 in networkContext.Groups)
							{
								ActiveUnit groupLead = group3.GroupLead;
								if (ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(item3, groupLead.Comms_ReadOnly, groupLead).EvaluationEnum == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
								{
									list4.Add(groupLead);
								}
							}
							if (list4.Count > 1)
							{
								method_23(item, list4, networkCreationReason_, list2, null, "HUB " + item3.Name + " groups " + Conversions.ToString(list4.Count - 1) + " leads");
								hashSet.UnionWith(list4.OfType<ActiveUnit>());
								break;
							}
						}
					}
					List<ActiveUnit> list5 = new List<ActiveUnit>();
					list5.AddRange(networkContext.FlyingAircraft);
					list5.AddRange(networkContext.AEWList.Cast<ActiveUnit>());
					list5.AddRange(networkContext.TankerList.Cast<ActiveUnit>());
					list5.AddRange(networkContext.ShipList);
					list5.AddRange(networkContext.SubList);
					list5.AddRange(networkContext.VehicleList);
					List<ActiveUnit> list6 = new List<ActiveUnit>();
					foreach (ActiveUnit item4 in list5)
					{
						if (!item4.IsGroup && !item4.IsGroupMember() && !hashSet.Contains(item4))
						{
							list6.Add(item4);
						}
					}
					if (!flag)
					{
						foreach (ActiveUnit item5 in list6)
						{
							method_27(item5, networkContext, item, list2);
						}
					}
					List<ActiveUnit> list7 = new List<ActiveUnit>();
					foreach (ActiveUnit unit2 in item.Units)
					{
						if (unit2.Comms_ReadOnly != null && unit2.Comms_ReadOnly.Count() > 0 && !unit2.IsGroupMember() && (unit2.CommStuff == null || unit2.CommStuff.Networks == null || unit2.CommStuff.Networks.Count == 0))
						{
							list7.Add(unit2);
						}
					}
					if (list7.Count > 0)
					{
						method_23(item, list7.Cast<Module_Unit.Unit>(), CommNetwork.NetworkCreationReason.Generic, list2, null, "safety net network (" + Conversions.ToString(list7.Count) + " units)");
					}
					foreach (NetworkLog item6 in list2)
					{
						item.LogActionIntoNetworkLog(item6.Detail, item);
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 321654683513", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at FullNetworkGeneration_outer", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string method_28(string string_7, NetworkRuleExecutionContext networkRuleExecutionContext_0)
	{
		string result;
		try
		{
			object[] array = Scenario_LuaSandbox.RunScript(string_7, RunInteractively: false);
			if (array != null && array.Length != 0)
			{
				networkRuleExecutionContext_0.Log.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Lua] resultArray(0) type: " + ((array[0] == null) ? "Nothing" : array[0].GetType().FullName) + " | value: " + ((array[0] == null) ? "Nothing" : array[0].ToString())));
				if (array[0] is Exception)
				{
					Exception ex = (Exception)array[0];
					networkRuleExecutionContext_0.Log.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Lua] script exception: " + ex.Message));
					GameGeneral.WriteExceptionsToLog(ex);
					result = "nil";
				}
				else if (array[0] == null)
				{
					result = "nil";
				}
				else
				{
					string text = array[0].ToString().Trim();
					networkRuleExecutionContext_0.Log.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Lua] result string: '" + text + "'"));
					result = (string.IsNullOrEmpty(text) ? "nil" : text);
				}
			}
			else
			{
				networkRuleExecutionContext_0.Log.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Lua] RunScript returned Nothing or empty array"));
				result = "nil";
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception ex3 = ex2;
			networkRuleExecutionContext_0.Log.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Lua] outer exception: " + ex3.Message + " | script was: " + string_7));
			GameGeneral.WriteExceptionsToLog(ex3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "nil";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private NetworkRuleRegistry method_29(Side side_2, List<NetworkLog> list_9)
	{
		if (side_2.NetworkRuleRegistry != null)
		{
			list_9.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Registry] Side " + side_2.Name + " has " + Conversions.ToString(side_2.NetworkRuleRegistry.Rules.Count) + " rules"));
		}
		else
		{
			side_2.NetworkRuleRegistry = NetworkRuleRegistry.BuildDefaults();
			list_9.Add(new NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, "[Registry] Side " + side_2.Name + " had no registry — built defaults"));
		}
		return side_2.NetworkRuleRegistry;
	}

	internal void ManageUnitAdditionForNetworks(ActiveUnit theAU)
	{
		Side side = theAU.get_UnitSide(SetSideOnly: false);
		List<NetworkLog> list_ = new List<NetworkLog>();
		if (theAU.Comms_ReadOnly.Count() == 0 || theAU.IsGroup || theAU.IsGroupMember())
		{
			return;
		}
		if (side.CommNetworks == null || side.CommNetworks.Count == 0)
		{
			NetworkContext networkContext = method_18(side);
			if (!networkContext.AirBases.Contains(theAU) && (!theAU.IsAircraft || !networkContext.AEWList.Contains((Aircraft)theAU)))
			{
				HashSet<Module_Unit.Unit> members = new HashSet<Module_Unit.Unit> { theAU };
				side.CreateNextNetworkUnitsReason(members, CommNetwork.NetworkCreationReason.Generic);
				return;
			}
		}
		NetworkContext networkContext_ = method_18(side);
		method_27(theAU, networkContext_, side, list_);
	}
}
