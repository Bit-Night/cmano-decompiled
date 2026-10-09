using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_Weaponry
{
	public delegate void FiredWeaponEventHandler(Scenario theScen, ActiveUnit theFiringUnit, Weapon theWeapon);

	public sealed class WeaponSalvoWpnQty
	{
		public int? WeaponQty_ToFire;

		public int? WeaponQty_Available;

		public WeaponSalvoWpnQty(int? theWeaponQty_ToFire, int? theWeaponQty_Available)
		{
			WeaponQty_ToFire = theWeaponQty_ToFire;
			WeaponQty_Available = theWeaponQty_Available;
		}

		static WeaponSalvoWpnQty()
		{
			Class72.smethod_20();
		}
	}

	public enum WeaponryAltitudeCheckResult
	{
		OK,
		Fail
	}

	public enum WeaponPrefireChecklistEvaluation
	{
		OK,
		NeedHighQualityLocalTrackOrCEC,
		OutsideBoresightLimits,
		WithinMinimumRange,
		OutOfRange,
		InsufficientQualityGrade,
		OtherNegative,
		CannotIlluminate_NoDirectorAvailable,
		CannotIlluminate_NoChannelAvailable,
		CannotIlluminate_InsufficientReflectionOrBlocked
	}

	private sealed class Class8
	{
		public float float_0;

		public ActiveUnit activeUnit_0;

		public WeaponRec weaponRec_0;

		public object object_0;

		public Mount mount_0;

		public Class8(ref float float_1, ActiveUnit activeUnit_1, ref WeaponRec weaponRec_1, ref ActiveUnit activeUnit_2, ref Mount mount_1)
		{
			float_0 = float_1;
			activeUnit_0 = activeUnit_1;
			weaponRec_0 = weaponRec_1;
			object_0 = activeUnit_2;
			mount_0 = mount_1;
		}

		static Class8()
		{
			Class72.smethod_20();
		}
	}

	public enum PointDefenceResult
	{
		Undefined,
		WeaponDefeated,
		WeaponSurvived
	}

	public enum DLZResultEnum
	{
		None,
		Success,
		Fail_OutOfEnergy,
		Fail_OutsideValidAltitudeEnvelope,
		Fail_CannotPlotIntercept,
		Fail_TargetNotDefined,
		Fail_ExhaustedConsumables,
		Fail_CodeError,
		Fail_TargetWillImpactBeforeIntercept,
		Fail_InsideMinimumRange,
		Fail_MAXRangeWRA,
		Fail_ScenarioDuration,
		Fail_LowAltTerrainCrash
	}

	public enum AssumedDLZTargetBehavior
	{
		ContinuesAsCurrent,
		RunStraightAway,
		Loiter
	}

	public struct DatalinkedWeaponsInAirByTrackState
	{
		public PooledList<Weapon> thatNeedTrack;

		public PooledList<Weapon> thatHaveTrack;
	}

	[CompilerGenerated]
	internal sealed class _Closure$__130-0
	{
		public Contact $VB$Local_theTarget;

		public Func<Contact, double> $I0;

		public _Closure$__130-0(_Closure$__130-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theTarget = arg0.$VB$Local_theTarget;
			}
		}

		[SpecialName]
		internal double _Lambda$__0(Contact theC)
		{
			return Geodesic_Haversine.Distance_Horiz_Approx_nm(((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
		}

		static _Closure$__130-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__141-0
	{
		public Sensor $VB$Local_theSensor;

		public _Closure$__141-0(_Closure$__141-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSensor = arg0.$VB$Local_theSensor;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(Module_Unit.Unit theUnit)
		{
			return $VB$Local_theSensor.ParentPlatform.RangeToUnit_Horiz(theUnit);
		}

		static _Closure$__141-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__141-1
	{
		public float $VB$Local_BearingToNearestTarget;

		public _Closure$__141-1(_Closure$__141-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_BearingToNearestTarget = arg0.$VB$Local_BearingToNearestTarget;
			}
		}

		[SpecialName]
		internal int _Lambda$__1(int x, int y)
		{
			if (!(Math.Abs((float)x - $VB$Local_BearingToNearestTarget) >= Math.Abs((float)y - $VB$Local_BearingToNearestTarget)))
			{
				return x;
			}
			return y;
		}

		static _Closure$__141-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__143-0
	{
		public ActiveUnit $VB$Local_FiringUnit;

		public _Closure$__143-0(_Closure$__143-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_FiringUnit = arg0.$VB$Local_FiringUnit;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(ActiveUnit theU)
		{
			return $VB$Local_FiringUnit.RangeToUnit_Horiz(theU);
		}

		static _Closure$__143-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__43-0
	{
		public Weapon $VB$Local_PalletWeapon;

		public Func<WeaponRec, bool> $I0;

		public _Closure$__43-0(_Closure$__43-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PalletWeapon = arg0.$VB$Local_PalletWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponRec thePWR)
		{
			return thePWR.int_3 == $VB$Local_PalletWeapon.DBID;
		}

		static _Closure$__43-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__44-0
	{
		public Weapon $VB$Local_PalletWeapon;

		public Func<WeaponRec, bool> $I0;

		public _Closure$__44-0(_Closure$__44-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PalletWeapon = arg0.$VB$Local_PalletWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponRec thePWR)
		{
			return thePWR.int_3 == $VB$Local_PalletWeapon.DBID;
		}

		static _Closure$__44-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__45-0
	{
		public Weapon $VB$Local_PalletWeapon;

		public Func<WeaponRec, bool> $I0;

		public _Closure$__45-0(_Closure$__45-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PalletWeapon = arg0.$VB$Local_PalletWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponRec thePWR)
		{
			return thePWR.int_3 == $VB$Local_PalletWeapon.DBID;
		}

		static _Closure$__45-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__59-0
	{
		public int $VB$Local_theWeaponDBID;

		public Contact $VB$Local_theTarget;

		public ActiveUnit_Weaponry $VB$Me;

		public Func<Warhead, bool> $I0;

		public Func<Warhead, bool> $I1;

		public Func<Warhead, bool> $I2;

		public Func<Warhead, bool> $I3;

		public _Closure$__59-0(_Closure$__59-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponDBID = arg0.$VB$Local_theWeaponDBID;
				$VB$Local_theTarget = arg0.$VB$Local_theTarget;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Warhead x)
		{
			return x.DP == (float)$VB$Local_theWeaponDBID;
		}

		[SpecialName]
		internal bool _Lambda$__1(Warhead x)
		{
			return x.DP == (float)$VB$Local_theWeaponDBID;
		}

		[SpecialName]
		internal bool _Lambda$__2(Warhead x)
		{
			return x.DP == (float)$VB$Local_theWeaponDBID;
		}

		[SpecialName]
		internal bool _Lambda$__3(Warhead x)
		{
			return x.DP == (float)$VB$Local_theWeaponDBID;
		}

		[SpecialName]
		internal int _Lambda$__7(WeaponRec theRec)
		{
			ActiveUnit_Weaponry activeUnit_Weaponry = $VB$Me;
			Weapon theWeapon = theRec.get_ReferenceWeapon($VB$Me.myUnit.ParentScen);
			return activeUnit_Weaponry.WeaponSuitabilityForThisTarget(ref theWeapon, ref $VB$Local_theTarget, CheckIfWithinRange: false);
		}

		[SpecialName]
		internal float _Lambda$__8(WeaponRec theRec)
		{
			return theRec.get_ReferenceWeapon($VB$Me.myUnit.ParentScen).get_MaxRangeForThisTarget($VB$Me.myUnit, $VB$Local_theTarget, CheckWRA: true, $VB$Me.myUnit.Doctrine, ManualFire: false);
		}

		static _Closure$__59-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__76-0
	{
		public (int, string, bool) $VB$Local_theTuple;

		public _Closure$__76-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__76-0(_Closure$__76-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theTuple = arg0.$VB$Local_theTuple;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			_Closure$__76-2 arg = default(_Closure$__76-2);
			_Closure$__76-2 CS$<>8__locals3 = new _Closure$__76-2(arg);
			Weapon weapon = null;
			Contact contact = null;
			try
			{
				int item = $VB$Local_theTuple.Item1;
				CS$<>8__locals3.$VB$Local_TargetObjectID = $VB$Local_theTuple.Item2;
				bool item2 = $VB$Local_theTuple.Item3;
				try
				{
					List<Contact> list = $VB$NonLocal_$VB$Closure_2.$VB$Local_TargetsReadOnlySafeCopy.Where([SpecialName] (Contact theC) => Operators.CompareString(theC.ObjectID, CS$<>8__locals3.$VB$Local_TargetObjectID, false) == 0).ToList();
					if (list.Count > 0)
					{
						contact = list[0];
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200441", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
				if (contact == null)
				{
					return;
				}
				Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = $VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.Doctrine.get_GunStrafing($VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				PooledList<Weapon> pooledList = $VB$NonLocal_$VB$Closure_2.$VB$Me.SuitableWeaponsForThisTarget(contact, ref GunStrafingSalvo);
				if (pooledList != null)
				{
					foreach (Weapon item3 in pooledList)
					{
						if (item3.DBID == item)
						{
							weapon = item3;
							break;
						}
					}
					pooledList.Dispose();
				}
				if (weapon != null)
				{
					(DLZResultEnum, float) value = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_10(contact, weapon, item2, HumanFeedbackNeeded: false);
					if ($VB$NonLocal_$VB$Closure_2.$VB$Me.DLZ_ResultsCache == null)
					{
						$VB$NonLocal_$VB$Closure_2.$VB$Me.DLZ_ResultsCache = new TDictionary<(int, string, bool), (DLZResultEnum, float)>();
					}
					$VB$NonLocal_$VB$Closure_2.$VB$Me.DLZ_ResultsCache.AddIfNotExistsElseUpdate((item, CS$<>8__locals3.$VB$Local_TargetObjectID, item2), value);
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

		static _Closure$__76-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__76-1
	{
		public List<Contact> $VB$Local_TargetsReadOnlySafeCopy;

		public ActiveUnit_Weaponry $VB$Me;

		public _Closure$__76-1(_Closure$__76-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TargetsReadOnlySafeCopy = arg0.$VB$Local_TargetsReadOnlySafeCopy;
			}
		}

		static _Closure$__76-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__76-2
	{
		public string $VB$Local_TargetObjectID;

		public _Closure$__76-2(_Closure$__76-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TargetObjectID = arg0.$VB$Local_TargetObjectID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Contact theC)
		{
			return Operators.CompareString(theC.ObjectID, $VB$Local_TargetObjectID, false) == 0;
		}

		static _Closure$__76-2()
		{
			Class72.smethod_20();
		}
	}

	private bool bool_0;

	private bool bool_1;

	protected ActiveUnit myUnit;

	protected List<WeaponAssignment> WeaponAssignments;

	private TDictionary<(int, string, bool), (DLZResultEnum, float)> tdictionary_0;

	internal HashSet<(int, string, bool)> DLZ_ChecksRequested;

	[CompilerGenerated]
	private static FiredWeaponEventHandler firedWeaponEventHandler_0;

	private bool bool_2;

	public bool LayChaffStream;

	public bool bool_3;

	internal ActiveUnit._ActiveUnitWeaponState Cache_CurrentWeaponState;

	private ConcurrentDictionary<(ActiveUnit, int, ScenarioObject), double> concurrentDictionary_0;

	private float[] float_0;

	protected List<Weapon> _AllDistinctWeaponsAboard_Actual;

	private List<Weapon> list_0;

	[ThreadStatic]
	private List<WeaponSalvo> list_1;

	[ThreadStatic]
	private Dictionary<int, WeaponSalvoWpnQty> dictionary_0;

	[ThreadStatic]
	private List<WeaponRec> list_2;

	private ThreadLocal<List<Weapon>> threadLocal_0;

	internal List<Task> TaskList_DLZChecks;

	private readonly bool bool_4;

	[ThreadStatic]
	private StringBuilder stringBuilder_0;

	[ThreadStatic]
	private List<WeaponSalvo> list_3;

	[ThreadStatic]
	private List<WeaponSalvo> list_4;

	[ThreadStatic]
	private List<WeaponRec> list_5;

	[ThreadStatic]
	private List<WeaponRec> list_6;

	[ThreadStatic]
	private List<WeaponRec> list_7;

	[ThreadStatic]
	private List<WeaponRec> list_8;

	private Weapon weapon_0;

	private bool bool_5;

	private Weapon weapon_1;

	private Weapon weapon_2;

	private bool bool_6;

	private bool bool_7;

	private Weapon weapon_3;

	private Weapon weapon_4;

	private bool bool_8;

	private bool bool_9;

	private Weapon weapon_5;

	private bool bool_10;

	[CompilerGenerated]
	private bool bool_11;

	public LockObject SalvoLock;

	public static int DLZ_Nm_tolerance;

	public static FixedSizeQueue<DLZCAche> DLZCacheList;

	public ConcurrentDictionary<(ActiveUnit, int, ScenarioObject), double> ETA_ResultsCache
	{
		get
		{
			if (concurrentDictionary_0 == null)
			{
				concurrentDictionary_0 = new ConcurrentDictionary<(ActiveUnit, int, ScenarioObject), double>();
			}
			return concurrentDictionary_0;
		}
		set
		{
			concurrentDictionary_0 = value;
		}
	}

	public TDictionary<(int, string, bool), (DLZResultEnum, float)> DLZ_ResultsCache
	{
		get
		{
			return tdictionary_0;
		}
		set
		{
			tdictionary_0 = value;
		}
	}

	public bool HasChaffBundles
	{
		get
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.CurrentLoad != 0 && mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).IsChaffBundle && mount.Status == PlatformComponent._ComponentStatus.Operational)
					{
						return true;
					}
				}
			}
			int result;
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec obj in weapons)
				{
					obj.ParentMount = null;
					if (obj.get_ReferenceWeapon(myUnit.ParentScen).IsChaffBundle)
					{
						return true;
					}
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public virtual Weapon PrimaryAttackWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad != 0)
				{
					Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon.IsASuW_Land || weapon.IsASuW_Naval)
					{
						list2.Add(weapon);
					}
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
			{
				IEnumerable<Weapon> source = list2.Where([SpecialName] (Weapon theWeap) => theWeap.IsMine);
				if (source.Count() <= 0)
				{
					return list2.OrderByDescending([SpecialName] (Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
				}
				return source.ElementAtOrDefault(0);
			}
			return list2.OrderByDescending([SpecialName] (Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public virtual Weapon PrimaryDefenceWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad != 0)
				{
					Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon.IsAAWCapable || weapon.IsASW)
					{
						list2.Add(weapon);
					}
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			return list2.OrderByDescending([SpecialName] (Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public virtual Weapon PrimaryAttackWeapon_Actual
	{
		get
		{
			List<Weapon> list = AllDistinctWeaponsAboard_Actual();
			if (list != null && list.Count > 0)
			{
				List<Weapon> list2 = new List<Weapon>();
				foreach (Weapon item in list)
				{
					if (item.IsASuW_Land || item.IsASuW_Naval)
					{
						list2.Add(item);
					}
				}
				if (list2.Count <= 0)
				{
					return null;
				}
				return list2.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
			}
			return null;
		}
	}

	public virtual Weapon PrimaryDefenceWeapon_Actual
	{
		get
		{
			List<Weapon> list = AllDistinctWeaponsAboard_Actual();
			if (list != null && list.Count > 0)
			{
				List<Weapon> list2 = new List<Weapon>();
				foreach (Weapon item in list)
				{
					if (item != null && (item.IsAAWCapable || item.IsASW))
					{
						list2.Add(item);
					}
				}
				if (list2.Count <= 0)
				{
					return null;
				}
				return list2.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
			}
			return null;
		}
	}

	public bool DebugNEZ
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public static event FiredWeaponEventHandler FiredWeapon
	{
		[CompilerGenerated]
		add
		{
			FiredWeaponEventHandler firedWeaponEventHandler = firedWeaponEventHandler_0;
			FiredWeaponEventHandler firedWeaponEventHandler2;
			do
			{
				firedWeaponEventHandler2 = firedWeaponEventHandler;
				FiredWeaponEventHandler value2 = (FiredWeaponEventHandler)Delegate.Combine(firedWeaponEventHandler2, value);
				firedWeaponEventHandler = Interlocked.CompareExchange(ref firedWeaponEventHandler_0, value2, firedWeaponEventHandler2);
			}
			while ((object)firedWeaponEventHandler != firedWeaponEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			FiredWeaponEventHandler firedWeaponEventHandler = firedWeaponEventHandler_0;
			FiredWeaponEventHandler firedWeaponEventHandler2;
			do
			{
				firedWeaponEventHandler2 = firedWeaponEventHandler;
				FiredWeaponEventHandler value2 = (FiredWeaponEventHandler)Delegate.Remove(firedWeaponEventHandler2, value);
				firedWeaponEventHandler = Interlocked.CompareExchange(ref firedWeaponEventHandler_0, value2, firedWeaponEventHandler2);
			}
			while ((object)firedWeaponEventHandler != firedWeaponEventHandler2);
		}
	}

	static ActiveUnit_Weaponry()
	{
		Class72.smethod_20();
		DLZ_Nm_tolerance = 5;
		DLZCacheList = new FixedSizeQueue<DLZCAche>(500);
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit_Weaponry");
			List<WeaponAssignment> weaponAssignments = WeaponAssignments;
			if (weaponAssignments != null && weaponAssignments.Count > 0)
			{
				theWriter.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
				theWriter.WriteEndElement();
			}
			if (LayChaffStream)
			{
				theWriter.WriteElementString("LCS", "True");
			}
			if (bool_3)
			{
				theWriter.WriteElementString("IDLZ", "True");
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100284", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		ActiveUnit_Weaponry result;
		try
		{
			ActiveUnit_Weaponry activeUnit_Weaponry = new ActiveUnit_Weaponry();
			activeUnit_Weaponry.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "HF":
					if (theAU.Doctrine != null && Misc.ParseBool(val.InnerText))
					{
						theAU.Doctrine.set_WeaponControlStatus_Air(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
					break;
				case "IDLZ":
					activeUnit_Weaponry.bool_3 = true;
					break;
				case "LCS":
					activeUnit_Weaponry.LayChaffStream = true;
					break;
				case "WeaponAssignments":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref theNode2, theDictionary, ref theAU.ParentScen);
						if (weaponAssignment.Target != null)
						{
							if (activeUnit_Weaponry.WeaponAssignments == null)
							{
								activeUnit_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
							}
							activeUnit_Weaponry.WeaponAssignments.Add(weaponAssignment);
						}
					}
					break;
				}
			}
			result = activeUnit_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100285", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_Weaponry();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private ActiveUnit_Weaponry()
	{
		bool_0 = false;
		bool_1 = true;
		Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.Undefined;
		TaskList_DLZChecks = new List<Task>();
		bool_4 = false;
		stringBuilder_0 = StringBuilderCache.Allocate();
		DebugNEZ = false;
		SalvoLock = new LockObject();
		float_0 = new float[5900];
		int num = float_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			float_0[i] = -1f;
		}
	}

	public ActiveUnit_Weaponry(ActiveUnit theUnit)
	{
		bool_0 = false;
		bool_1 = true;
		Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.Undefined;
		TaskList_DLZChecks = new List<Task>();
		bool_4 = false;
		stringBuilder_0 = StringBuilderCache.Allocate();
		DebugNEZ = false;
		SalvoLock = new LockObject();
		myUnit = theUnit;
		float_0 = new float[5900];
		int num = float_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			float_0[i] = -1f;
		}
	}

	public int HowManyWeaponCanFireConcurrently(float theWeaponDBID)
	{
		int num = 0;
		if (myUnit.IsAircraft)
		{
			WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if ((float)weaponRec.get_ReferenceWeapon(myUnit.ParentScen).DBID == theWeaponDBID)
				{
					if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.IronBomb)
					{
						return num + weaponRec.MaxLoad;
					}
					num++;
				}
			}
		}
		foreach (Mount mount in myUnit.Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				if ((float)mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).DBID == theWeaponDBID)
				{
					if (mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.IronBomb)
					{
						num += mountWeapon.MaxLoad;
						return num;
					}
					num++;
				}
			}
		}
		return num;
	}

	public bool ContactIsWithinSelfDefenceRange(Contact theTarget)
	{
		if (theTarget == null)
		{
			return false;
		}
		bool result = default(bool);
		try
		{
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Contact.WRA_DetermineTargetType(ref theTarget, null, ref GlobalVariables.ObjectFalse);
			float num = 0f;
			float num2 = float_0[(int)wRA_WeaponTargetType];
			if (num2 == -1f)
			{
				List<Weapon> list = AllDistinctWeaponsAboard_Actual();
				foreach (Weapon item in list)
				{
					if (item == null || item.Type == Weapon._WeaponType.Sonobuoy || item.IsFuelTank || item.IsDecoy)
					{
						continue;
					}
					Doctrine doctrine = myUnit.Doctrine;
					Doctrine doctrine2 = myUnit.Doctrine;
					Scenario parentScen = myUnit.ParentScen;
					float? TargetType_InheriteSelfDefenceRange = null;
					float? TargetType_UnspecifiedSelfDefenceRange = null;
					float? num3 = doctrine.WRA_SelfDefenceRange_AnyTargetType(doctrine2, parentScen, item, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheriteSelfDefenceRange, ref TargetType_UnspecifiedSelfDefenceRange);
					if (num3.HasValue)
					{
						TargetType_UnspecifiedSelfDefenceRange = num3;
						if ((TargetType_UnspecifiedSelfDefenceRange.HasValue ? new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() == -99f) : ((bool?)null)) == true)
						{
							num3 = item.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
						}
						TargetType_UnspecifiedSelfDefenceRange = num3;
						if ((TargetType_UnspecifiedSelfDefenceRange.HasValue ? new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() > num) : ((bool?)null)) == true)
						{
							num = num3.Value;
						}
					}
				}
				float_0[(int)wRA_WeaponTargetType] = num;
			}
			else
			{
				num = num2;
			}
			result = num > 0f && num > myUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 456877623894759023486", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Current_WeaponRecs(bool IncludeAviationMags)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> result = default(List<WeaponRec>);
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item = weapons[k];
						list.Add(item);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (sharedMagazines != null)
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (IncludeAviationMags || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item = weapons2[m];
							list.Add(item);
						}
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item = weapons3[n];
					list.Add(item);
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 103245230948568", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Default_WeaponRecs(bool IncludeAviationMags)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> result = default(List<WeaponRec>);
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item = weapons[k];
						list.Add(item);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing((object)sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (IncludeAviationMags || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item = weapons2[m];
							list.Add(item);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item = weapons3[n];
					list.Add(item);
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101300", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<WeaponRec> AllDistinctWeaponsAboard_Actual_WeaponRecs(bool IncludeAviationMags)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> result;
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec item = mountWeapons[j];
						list.Add(item);
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec item = weapons[k];
						list.Add(item);
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing((object)sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (IncludeAviationMags || !magazine.IsAviationMag)
					{
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec item = weapons2[m];
							list.Add(item);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec item = weapons3[n];
					list.Add(item);
				}
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324502345239204859038532985", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Dictionary<int, WeaponRec> AllDistinctWeaponsAboard_Potential_WeaponRecs(bool IncludeAviationMags)
	{
		Dictionary<int, WeaponRec> dictionary = new Dictionary<int, WeaponRec>();
		Dictionary<int, WeaponRec> result = default(Dictionary<int, WeaponRec>);
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec weaponRec = mountWeapons[j];
						if (!dictionary.ContainsKey(weaponRec.int_3))
						{
							dictionary.Add(weaponRec.int_3, weaponRec);
						}
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec weaponRec = weapons[k];
						if (!dictionary.ContainsKey(weaponRec.int_3))
						{
							dictionary.Add(weaponRec.int_3, weaponRec);
						}
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (!Information.IsNothing((object)sharedMagazines))
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (!IncludeAviationMags && magazine.IsAviationMag)
					{
						continue;
					}
					ObservableList<WeaponRec> weapons2 = magazine.Weapons;
					int num5 = weapons2.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						WeaponRec weaponRec = weapons2[m];
						if (!dictionary.ContainsKey(weaponRec.int_3))
						{
							dictionary.Add(weaponRec.int_3, weaponRec);
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec weaponRec = weapons3[n];
					if (!dictionary.ContainsKey(weaponRec.int_3))
					{
						dictionary.Add(weaponRec.int_3, weaponRec);
					}
				}
			}
			result = dictionary;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101301", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public PooledDictionary<int, Weapon> AllDistinctWeaponsAboard_Potential(bool IncludeAviationMags)
	{
		PooledDictionary<int, Weapon> pooledDictionary = new PooledDictionary<int, Weapon>();
		PooledDictionary<int, Weapon> result = default(PooledDictionary<int, Weapon>);
		try
		{
			ObservableList<Mount> mounts = myUnit.Mounts;
			if (mounts.Count > 0)
			{
				int num = mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = mounts[i];
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					int num2 = mountWeapons.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						WeaponRec weaponRec = mountWeapons[j];
						if (!pooledDictionary.ContainsKey(weaponRec.int_3))
						{
							pooledDictionary.Add(weaponRec.int_3, weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
						}
					}
					ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
					int num3 = weapons.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						WeaponRec weaponRec = weapons[k];
						if (!pooledDictionary.ContainsKey(weaponRec.int_3))
						{
							pooledDictionary.Add(weaponRec.int_3, weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
						}
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (sharedMagazines != null)
			{
				int num4 = sharedMagazines.Length - 1;
				for (int l = 0; l <= num4; l++)
				{
					Magazine magazine = sharedMagazines[l];
					if (!IncludeAviationMags && magazine.IsAviationMag)
					{
						continue;
					}
					ObservableList<WeaponRec> weapons2 = magazine.Weapons;
					int num5 = weapons2.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						WeaponRec weaponRec = weapons2[m];
						if (!pooledDictionary.ContainsKey(weaponRec.int_3))
						{
							pooledDictionary.Add(weaponRec.int_3, weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
				int num6 = weapons3.Length - 1;
				for (int n = 0; n <= num6; n++)
				{
					WeaponRec weaponRec = weapons3[n];
					if (!pooledDictionary.ContainsKey(weaponRec.int_3))
					{
						pooledDictionary.Add(weaponRec.int_3, weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
					}
				}
			}
			result = pooledDictionary;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100287", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Housekeeping_PrePulse()
	{
		if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
		{
			ClearCachedWeapons();
		}
	}

	public virtual void ClearCachedWeapons()
	{
		_AllDistinctWeaponsAboard_Actual = null;
		list_0 = null;
		weapon_2 = null;
		weapon_1 = null;
		bool_7 = false;
		bool_6 = false;
		weapon_0 = null;
		bool_5 = false;
		weapon_4 = null;
		weapon_3 = null;
		bool_9 = false;
		bool_8 = false;
		weapon_5 = null;
		bool_10 = false;
		int num = float_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			float_0[i] = -1f;
		}
	}

	public virtual List<Weapon> AllDistinctWeaponsAboard_Actual()
	{
		if (_AllDistinctWeaponsAboard_Actual == null)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<Weapon> list = new List<Weapon>();
			try
			{
				if (myUnit.IsPalletWeapon)
				{
					if (((Weapon)myUnit).WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in ((Weapon)myUnit).WeaponWeapons)
					{
						Weapon weapon = weaponWeapon.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon != null)
						{
							list.Add(weapon);
						}
					}
				}
				ObservableList<Mount> mounts = myUnit.Mounts;
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								Weapon weapon2 = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon2 != null)
								{
									list.Add(weapon2);
								}
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec = weapons[k];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								Weapon weapon3 = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon3 != null)
								{
									list.Add(weapon3);
								}
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (sharedMagazines != null)
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						Magazine magazine = sharedMagazines[l];
						if (magazine.IsAviationMag)
						{
							continue;
						}
						ObservableList<WeaponRec> weapons2 = magazine.Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec = weapons2[m];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								Weapon weapon4 = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon4 != null)
								{
									list.Add(weapon4);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100288", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			_AllDistinctWeaponsAboard_Actual = list;
		}
		return _AllDistinctWeaponsAboard_Actual;
	}

	public virtual List<Weapon> AllDistinctWeaponsAboard_Actual_InclAviation()
	{
		if (list_0 == null)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<Weapon> list = new List<Weapon>();
			try
			{
				ObservableList<Mount> mounts = myUnit.Mounts;
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec = weapons[k];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (!Information.IsNothing((object)sharedMagazines))
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						ObservableList<WeaponRec> weapons2 = sharedMagazines[l].Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec = weapons2[m];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_3))
							{
								dictionary.Add(weaponRec.int_3, 0);
								list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 10028123459085", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			list_0 = list;
		}
		return list_0;
	}

	public bool TargetIsWithinGunRange_Horiz(Contact theTarget)
	{
		bool result = default(bool);
		try
		{
			float num = 0f;
			foreach (Weapon item in AllDistinctWeaponsAboard_Actual())
			{
				if (item.Type == Weapon._WeaponType.Gun)
				{
					float num2 = item.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			if (num == 0f)
			{
				result = false;
				return result;
			}
			result = myUnit.RangeToUnit_Horiz(theTarget) < num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100289", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int TotalDefaultCapacityForThisWeapon(int int_0)
	{
		int result = default(int);
		try
		{
			int num = default(int);
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Operational)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0)
					{
						num += mountWeapon.DefaultLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_3 == int_0)
					{
						num += weapon.DefaultLoad;
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			foreach (Magazine magazine in sharedMagazines)
			{
				if (magazine.Status != PlatformComponent._ComponentStatus.Operational)
				{
					continue;
				}
				foreach (WeaponRec weapon2 in magazine.Weapons)
				{
					if (weapon2.int_3 == int_0)
					{
						num += weapon2.MaxLoad;
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.int_3 == int_0)
					{
						num += weaponRec.DefaultLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100290", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int TotalMaximumCapacityForThisWeapon(int int_0, bool IncludeNonOperationalMountsAndMags, Weapon PalletWeapon = null)
	{
		_Closure$__43-0 arg = default(_Closure$__43-0);
		_Closure$__43-0 CS$<>8__locals7 = new _Closure$__43-0(arg);
		CS$<>8__locals7.$VB$Local_PalletWeapon = PalletWeapon;
		int result = default(int);
		try
		{
			int num = default(int);
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0)
					{
						num += mountWeapon.MaxLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_3 == int_0)
					{
						num += weapon.MaxLoad;
					}
				}
			}
			if (myUnit.SharedMagazines != null)
			{
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				foreach (Magazine magazine in sharedMagazines)
				{
					if (magazine.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_3 == int_0)
						{
							num += weapon2.MaxLoad;
						}
					}
				}
			}
			if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.int_3 == int_0)
					{
						num += weaponRec.MaxLoad;
						continue;
					}
					if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
					{
						if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_3 == int_0)
							{
								CS$<>8__locals7.$VB$Local_PalletWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
							}
						}
					}
					if (CS$<>8__locals7.$VB$Local_PalletWeapon == null || CS$<>8__locals7.$VB$Local_PalletWeapon.Warheads.Count() <= 0)
					{
						continue;
					}
					int currentLoad = ((Aircraft)myUnit).Loadout.Weapons.Where([SpecialName] (WeaponRec thePWR) => thePWR.int_3 == CS$<>8__locals7.$VB$Local_PalletWeapon.DBID).First().CurrentLoad;
					if (CS$<>8__locals7.$VB$Local_PalletWeapon.WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon2 in CS$<>8__locals7.$VB$Local_PalletWeapon.WeaponWeapons)
					{
						if (weaponWeapon2.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num = weaponWeapon2.MaxLoad * currentLoad;
						}
					}
				}
			}
			if (myUnit.IsPalletWeapon)
			{
				foreach (WeaponRec weaponWeapon3 in ((Weapon)myUnit).WeaponWeapons)
				{
					if (weaponWeapon3.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
					{
						num = weaponWeapon3.MaxLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1002901111", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int TotalAvailableInventoryForThisWeapon(int int_0, bool IncludeNonOperationalMountsAndMags, Weapon PalletWeapon = null)
	{
		_Closure$__44-0 arg = default(_Closure$__44-0);
		_Closure$__44-0 CS$<>8__locals7 = new _Closure$__44-0(arg);
		CS$<>8__locals7.$VB$Local_PalletWeapon = PalletWeapon;
		int result = default(int);
		try
		{
			int num = default(int);
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0)
					{
						num += mountWeapon.CurrentLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_3 == int_0)
					{
						num += weapon.CurrentLoad;
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (sharedMagazines != null)
			{
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (magazine.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_3 == int_0)
						{
							num += weapon2.CurrentLoad;
						}
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.int_3 == int_0)
					{
						num += weaponRec.CurrentLoad;
						continue;
					}
					if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
					{
						if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_3 == int_0)
							{
								CS$<>8__locals7.$VB$Local_PalletWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
							}
						}
					}
					if (CS$<>8__locals7.$VB$Local_PalletWeapon == null || CS$<>8__locals7.$VB$Local_PalletWeapon.Warheads.Count() <= 0)
					{
						continue;
					}
					int currentLoad = ((Aircraft)myUnit).Loadout.Weapons.Where([SpecialName] (WeaponRec thePWR) => thePWR.int_3 == CS$<>8__locals7.$VB$Local_PalletWeapon.DBID).First().CurrentLoad;
					if (CS$<>8__locals7.$VB$Local_PalletWeapon.WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon2 in CS$<>8__locals7.$VB$Local_PalletWeapon.WeaponWeapons)
					{
						if (weaponWeapon2.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num += weaponWeapon2.CurrentLoad * currentLoad;
						}
					}
				}
			}
			if (myUnit.IsPalletWeapon)
			{
				foreach (WeaponRec weaponWeapon3 in ((Weapon)myUnit).WeaponWeapons)
				{
					if (weaponWeapon3.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
					{
						num = weaponWeapon3.CurrentLoad;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100292", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public (int CurrentInventory, int TotalCapacity) CurrentInventoryAndTotalCapacityForThisWeapon(int int_0, bool IncludeNonOperationalMountsAndMags, Weapon PalletWeapon = null)
	{
		_Closure$__45-0 arg = default(_Closure$__45-0);
		_Closure$__45-0 CS$<>8__locals10 = new _Closure$__45-0(arg);
		CS$<>8__locals10.$VB$Local_PalletWeapon = PalletWeapon;
		(int, int) result = default((int, int));
		try
		{
			int num = default(int);
			int num2 = default(int);
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0)
					{
						num += mountWeapon.CurrentLoad;
						num2 += mountWeapon.MaxLoad;
					}
				}
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					if (weapon.int_3 == int_0)
					{
						num += weapon.CurrentLoad;
						num2 += weapon.MaxLoad;
					}
				}
			}
			Magazine[] sharedMagazines = myUnit.SharedMagazines;
			if (sharedMagazines != null)
			{
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (magazine.Status != PlatformComponent._ComponentStatus.Operational && !IncludeNonOperationalMountsAndMags)
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_3 == int_0)
						{
							num += weapon2.CurrentLoad;
							num2 += weapon2.MaxLoad;
						}
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.int_3 == int_0)
					{
						num += weaponRec.CurrentLoad;
						continue;
					}
					if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
					{
						if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_3 == int_0)
							{
								CS$<>8__locals10.$VB$Local_PalletWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
							}
						}
					}
					if (CS$<>8__locals10.$VB$Local_PalletWeapon == null || CS$<>8__locals10.$VB$Local_PalletWeapon.Warheads.Count() <= 0)
					{
						continue;
					}
					int currentLoad = ((Aircraft)myUnit).Loadout.Weapons.Where((CS$<>8__locals10.$I0 != null) ? CS$<>8__locals10.$I0 : (CS$<>8__locals10.$I0 = [SpecialName] (WeaponRec thePWR) => thePWR.int_3 == CS$<>8__locals10.$VB$Local_PalletWeapon.DBID)).First().CurrentLoad;
					if (CS$<>8__locals10.$VB$Local_PalletWeapon.WeaponWeapons.Count == 0)
					{
						((Weapon)myUnit).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon2 in CS$<>8__locals10.$VB$Local_PalletWeapon.WeaponWeapons)
					{
						if (weaponWeapon2.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num += weaponWeapon2.CurrentLoad * currentLoad;
							num2 += weaponWeapon2.MaxLoad * currentLoad;
						}
					}
				}
			}
			if (myUnit.IsPalletWeapon)
			{
				foreach (WeaponRec weaponWeapon3 in ((Weapon)myUnit).WeaponWeapons)
				{
					if (weaponWeapon3.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
					{
						num = weaponWeapon3.CurrentLoad;
						num2 = weaponWeapon3.MaxLoad;
					}
				}
			}
			result = (num, num2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 3249804329586734598", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool HaveAvailableWeaponSuitableForThisTarget(Contact theTarget, bool CheckWRA, Doctrine theDoc, ref string Feedback, ref int FeedbackSeverity, bool HumanFeedBackNeeded, List<Weapon> AvailableWeapons = null)
	{
		bool result = default(bool);
		try
		{
			List<Weapon> list = ((AvailableWeapons == null) ? AllDistinctWeaponsAboard_Actual() : AvailableWeapons);
			if (list.Count == 0)
			{
				result = false;
				return result;
			}
			if (theTarget == null)
			{
				result = false;
				return result;
			}
			GlobalVariables.BooleanObject TargetIsDestroyed = Misc.ToBooleanObject(theTarget.get_IsDestroyed(myUnit.ParentScen));
			if (TargetIsDestroyed == GlobalVariables.ObjectTrue)
			{
				result = false;
				return result;
			}
			int num = list.Count - 1;
			int num2 = 0;
			Weapon theWeapon = default(Weapon);
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = default(Doctrine._GunStrafeGroundTargets?);
			while (true)
			{
				if (num2 <= num)
				{
					theWeapon = list[num2];
					if (myUnit.IsAircraft && theTarget.isSurfaceOrLandContact && theWeapon.Type == Weapon._WeaponType.Gun)
					{
						if (!gunStrafeGroundTargets.HasValue)
						{
							gunStrafeGroundTargets = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						}
						byte? b = (byte?)gunStrafeGroundTargets;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
						{
							if (FeedbackSeverity < 2)
							{
								if (HumanFeedBackNeeded)
								{
									Feedback = "No contacts can be engaged by the available weapons (the only suitable weapon is gun, but doctrine forbids gun strafing).";
								}
								FeedbackSeverity = 2;
							}
							goto IL_02b0;
						}
					}
					if (theWeapon.IsNominallySuitableForThisTarget(myUnit, ref theTarget, ref TargetIsDestroyed))
					{
						if (!CheckWRA)
						{
							break;
						}
						if (theDoc != null && theDoc.WRA_RelevantWeapon(ref theWeapon))
						{
							theWeapon.FiringParent = myUnit;
							Weapon theW = theWeapon;
							GlobalVariables.BooleanObject EmitterClassificable = null;
							Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW, ref EmitterClassificable);
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
							Scenario parentScen = theWeapon.ParentScen;
							Weapon theWeapon2 = theWeapon;
							int? TargetType_InheritedWeaponQty = null;
							int? TargetType_UnspecifiedWeaponQty = null;
							TargetType_UnspecifiedWeaponQty = Doctrine.WRA_WeaponQty_AnyTargetType(theDoc, parentScen, theWeapon2, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
							if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0)) != true)
							{
								Scenario parentScen2 = theWeapon.ParentScen;
								int dBID = theWeapon.DBID;
								float? TargetType_InheritedFiringRange = null;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num3 = theDoc.WRA_FiringRange_AnyTargetType(theDoc, parentScen2, dBID, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
								int num4;
								if (num3.HasValue)
								{
									TargetType_UnspecifiedFiringRange = num3;
									if (((!TargetType_UnspecifiedFiringRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f)) == true)
									{
										if (FeedbackSeverity < 5)
										{
											if (HumanFeedBackNeeded)
											{
												Feedback = "No contacts can be engaged by the available weapons  " + theWeapon.Name + "  (Weapon Release Authorization - Firing Range).";
											}
											FeedbackSeverity = 5;
										}
										goto IL_02b0;
									}
									num4 = 1;
								}
								else
								{
									num4 = 1;
								}
								result = (byte)num4 != 0;
								return result;
							}
							if (FeedbackSeverity < 4)
							{
								if (HumanFeedBackNeeded)
								{
									Feedback = "No contacts can be engaged by the available weapons " + theWeapon.Name + " (Weapon Release Authorization - Target Type).";
								}
								FeedbackSeverity = 4;
							}
						}
					}
					goto IL_02b0;
				}
				int num5;
				if (FeedbackSeverity < 3)
				{
					if (HumanFeedBackNeeded)
					{
						Feedback = "No contacts can be engaged by the available weapons  " + theWeapon.Name + "  (not suitable).";
					}
					FeedbackSeverity = 3;
					num5 = 0;
				}
				else
				{
					num5 = 0;
				}
				result = (byte)num5 != 0;
				return result;
				IL_02b0:
				num2++;
			}
			result = true;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100293", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AttemptToLayMine(float elapsedTime, long ArmDelay)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<Mount> list2 = new List<Mount>();
		List<Mount> list3 = new List<Mount>();
		List<Mount> list4 = new List<Mount>();
		try
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					Weapon weapon = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
					if (!weapon.IsMine)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list4.Contains(mount))
					{
						list4.Add(mount);
					}
					if (myUnit.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(myUnit.ParentScen.DBConnection) && weapon.MaxLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_AGL == 0f)
					{
						if (weapon.MaxLaunchAlt_ASL < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) || weapon.MinLaunchAlt_ASL > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							continue;
						}
					}
					else if (!myUnit.IsAircraft)
					{
						if (weapon.MaxLaunchAlt_ASL < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) || weapon.MinLaunchAlt_ASL > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							continue;
						}
					}
					else if (weapon.MaxLaunchAlt_AGL < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) || !(weapon.MinLaunchAlt_AGL <= myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
					{
						continue;
					}
					if (mountWeapon.CurrentLoad == 0 || mount.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list3.Contains(mount))
					{
						list3.Add(mount);
					}
					if (mount.TimeToFire != 0f || mountWeapon.TimeToFire != 0f)
					{
						continue;
					}
					if (mount.ReloadPriority.Count == 0 && !list2.Contains(mount))
					{
						list2.Add(mount);
					}
					UnguidedWeapon theM = new UnguidedWeapon(weapon, null, null, 0.0, 0.0);
					string text = UnguidedWeapon.CanLayMineHere(ref theM, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen);
					if (string.CompareOrdinal(text, "OK") == 0)
					{
						list.Add(mountWeapon);
						continue;
					}
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						_ = " (" + myUnit.UnitClass + ")";
					}
					myUnit.EndgameReport.AddEndGameMessage(hit: false, "Can not lay mine of type " + weapon.Name + ": " + text);
				}
			}
			if (myUnit.IsAircraft)
			{
				if (((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					foreach (WeaponRec current2 in weapons)
					{
						current2.ParentMount = null;
						Weapon weapon2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
						if (!weapon2.IsMine)
						{
							continue;
						}
						if (myUnit.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(myUnit.ParentScen.DBConnection) && weapon2.MaxLaunchAlt_AGL == 0f)
						{
							if (weapon2.MaxLaunchAlt_ASL < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
							{
								continue;
							}
						}
						else if (weapon2.MaxLaunchAlt_AGL < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							continue;
						}
						if (current2.CurrentLoad != 0 && !(current2.TimeToFire > 0f))
						{
							UnguidedWeapon theM2 = new UnguidedWeapon(weapon2, null, null, 0.0, 0.0);
							if (string.CompareOrdinal(UnguidedWeapon.CanLayMineHere(ref theM2, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen), "OK") == 0)
							{
								list.Add(current2);
							}
						}
					}
				}
				if (list.Count == 0)
				{
					return;
				}
			}
			if (!myUnit.IsAircraft)
			{
				if (list.Count == 0 && list4.Count == 0)
				{
					return;
				}
				if (list.Count == 0 && list3.Count == list2.Count)
				{
					Mount mount_ = list4[GameGeneral.GlobalRNG.Next(0, list4.Count)];
					WeaponRec weaponRec_ = mount_.MountWeapons.FirstOrDefault([SpecialName] (WeaponRec s) => s.CurrentLoad > 0);
					WeaponRec weaponRec_2 = mount_.MountWeapons.FirstOrDefault([SpecialName] (WeaponRec s) => s.get_ReferenceWeapon(myUnit.ParentScen).IsMine);
					if (weaponRec_ != null && weaponRec_2 != null)
					{
						method_17(ref mount_, ref weaponRec_);
						method_18(ref mount_, ref weaponRec_2);
					}
					return;
				}
				if (list.Count == 0)
				{
					return;
				}
			}
			WeaponRec theWeaponRec = ((list.Count != 1) ? list[GameGeneral.GlobalRNG.Next(0, list.Count)] : list[0]);
			int NumberOfWeaponsFired = 0;
			WeaponSalvo theWeaponSalvo = null;
			FireWeapon_Normal(elapsedTime, ref theWeaponRec, null, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, ArmDelay, ref theWeaponSalvo);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100294", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		if (myUnit.Mounts.Count == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		ActiveUnit._ActiveUnitWeaponState result = default(ActiveUnit._ActiveUnitWeaponState);
		try
		{
			myUnit.Mounts.Where([SpecialName] (Mount theM) => theM.IsEmpty).Count();
			if (myUnit.Mounts.Count == 0)
			{
				result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100295", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void ExecuteWeaponAssignments(float elapsedTime)
	{
		if (WeaponAssignments == null || WeaponAssignments.Count == 0)
		{
			return;
		}
		List<WeaponAssignment> list = new List<WeaponAssignment>();
		try
		{
			Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = default(Doctrine._GunStrafeGroundTargets?);
			foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
			{
				if (myUnit.Weaponry.CreateSalvo(weaponAssignment.Target, weaponAssignment.Weapon.DBID, weaponAssignment.Quantity, weaponAssignment.ManualFire, ref GunStrafingSalvo, weaponAssignment.ScheduledFireTime, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: false))
				{
					list.Add(weaponAssignment);
				}
			}
			foreach (WeaponAssignment item in list)
			{
				WeaponAssignments.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100297", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Doctrine._WCS GetWCSForThisTargetType(Contact_Base.ContactType TargetType)
	{
		switch (TargetType)
		{
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
		case Contact_Base.ContactType.Decoy_Air:
			return myUnit.Doctrine.get_WeaponControlStatus_Air(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Torpedo:
		case Contact_Base.ContactType.Decoy_Sub:
			return myUnit.Doctrine.get_WeaponControlStatus_Submarine(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.Decoy_Surface:
		case Contact_Base.ContactType.ActivationPoint:
			return myUnit.Doctrine.get_WeaponControlStatus_Surface(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.Decoy_Land:
		case Contact_Base.ContactType.Installation:
		case Contact_Base.ContactType.AirBase:
		case Contact_Base.ContactType.NavalBase:
		case Contact_Base.ContactType.MobileGroup:
		case Contact_Base.ContactType.AggregateGroundUnit:
			return myUnit.Doctrine.get_WeaponControlStatus_Land(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
		}
	}

	public virtual void ExecuteWeaponSalvos(float elapsedTime)
	{
		lock (SalvoLock)
		{
			if (myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count == 0 || (myUnit.IsFacility && (int)Math.Round(myUnit.CurrentSpeed) > 0 && !((Facility)myUnit).CanFireOnTheMove) || (myUnit.IsPalletWeapon & (myUnit.Attitude_Pitch != -85f)))
			{
				return;
			}
			bool flag = false;
			PooledDictionary<string, WeaponSalvo> pooledDictionary = new PooledDictionary<string, WeaponSalvo>(ClearMode.Always);
			PooledList<WeaponSalvo> pooledList = new PooledList<WeaponSalvo>();
			try
			{
				bool_2 = false;
				PooledList<WeaponSalvo> pooledList2 = new PooledList<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count);
				PooledList<WeaponSalvo> pooledList3;
				try
				{
					pooledList3 = new PooledList<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					pooledList3 = new PooledList<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
					ProjectData.ClearProjectError();
				}
				foreach (WeaponSalvo item in pooledList3)
				{
					if (item == null)
					{
						pooledList.Add(item);
					}
					else
					{
						if (DateTime.Compare(item.ScheduledFireTime, myUnit.ParentScen.Time) >= 0)
						{
							continue;
						}
						bool flag2 = false;
						WeaponSalvo.Shooter[] shootersList = item.ShootersList;
						for (int i = 0; i < shootersList.Length; i = checked(i + 1))
						{
							if (Operators.CompareString(shootersList[i]?.ShooterObjectID, myUnit.ObjectID, false) == 0)
							{
								flag2 = true;
							}
						}
						if (flag2)
						{
							if (item.ShootersList.Length == 0 && item.WpnQuantityAssigned == 0 && item.WpnQuantityFired == 0)
							{
								pooledList.Add(item);
							}
							pooledList2.Add(item);
						}
					}
				}
				pooledList3.Dispose();
				if (pooledList.Count > 0)
				{
					foreach (WeaponSalvo item2 in pooledList)
					{
						myUnit.get_UnitSide(SetSideOnly: false).RemoveWeaponSalvo(item2);
					}
					pooledList.Clear();
				}
				if (list_1 == null)
				{
					list_1 = new List<WeaponSalvo>();
				}
				else
				{
					list_1.Clear();
				}
				PooledList<WeaponSalvo> pooledList4 = new PooledList<WeaponSalvo>();
				foreach (WeaponSalvo item3 in pooledList2)
				{
					WeaponSalvo.Shooter shooter = null;
					WeaponSalvo.Shooter[] array = item3.ShootersList.ToArray();
					foreach (WeaponSalvo.Shooter shooter2 in array)
					{
						if (shooter2 != null && myUnit.ParentScen.ActiveUnits.TryGetValue(shooter2.ShooterObjectID, out var value) && myUnit == value)
						{
							shooter = shooter2;
							break;
						}
					}
					if ((shooter != null) & !item3.Target.get_IsDestroyed(myUnit.ParentScen))
					{
						list_1.Add(item3);
					}
					else if (item3.Target.get_IsDestroyed(myUnit.ParentScen))
					{
						pooledList4.Add(item3);
					}
				}
				pooledList2.Dispose();
				foreach (WeaponSalvo item4 in pooledList4)
				{
					try
					{
						myUnit.get_UnitSide(SetSideOnly: false).RemoveWeaponSalvo(item4);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
				Doctrine._WCS wCS = default(Doctrine._WCS);
				int? ASL_atFiringUnit = default(int?);
				foreach (WeaponSalvo item5 in list_1)
				{
					WeaponSalvo theWeaponSalvo = item5;
					WeaponSalvo.Shooter shooter3 = ((theWeaponSalvo.ShootersList.Length != 1) ? theWeaponSalvo.ShootersList.Where([SpecialName] (WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, myUnit.ObjectID, false) == 0).ElementAtOrDefault(0) : theWeaponSalvo.ShootersList[0]);
					if (shooter3.Timeout >= 40 && !theWeaponSalvo.ManualFire)
					{
						if (SimConfiguration.DefaultGamePreferences.SalvoTimeout)
						{
							if (!pooledDictionary.ContainsKey(shooter3.ShooterObjectID))
							{
								pooledDictionary.Add(shooter3.ShooterObjectID, theWeaponSalvo);
							}
							continue;
						}
					}
					else if (theWeaponSalvo.WeaponList.Count != 0)
					{
						shooter3.Timeout = 0;
					}
					else
					{
						if (myUnit.IsPalletWeapon)
						{
							shooter3.WeaponIsReadyToFire = true;
						}
						if (shooter3.WeaponIsReadyToFire)
						{
							shooter3.Timeout++;
						}
						else
						{
							shooter3.Timeout = 1;
						}
					}
					if (!theWeaponSalvo.ManualFire && wCS == Doctrine._WCS.Hold)
					{
						Side side = myUnit.get_UnitSide(SetSideOnly: false);
						ref Scenario parentScen = ref myUnit.ParentScen;
						ref ActiveUnit theAU = ref myUnit;
						Contact theTarget = null;
						side.StopShootingSalvo(ref parentScen, ref theAU, ref theTarget, ref theWeaponSalvo);
						continue;
					}
					if (!theWeaponSalvo.ManualFire && shooter3.QuantityAssigned == 0 && shooter3.QuantityFired == 0)
					{
						pooledList.Add(theWeaponSalvo);
						continue;
					}
					int num = shooter3.QuantityAssigned - shooter3.QuantityFired;
					if (num <= 0)
					{
						myUnit.get_UnitSide(SetSideOnly: false).AttemptToRemoveWeaponSalvo(ref myUnit.ParentScen, theWeaponSalvo);
						continue;
					}
					if (theWeaponSalvo.Target.IsShipContact)
					{
						byte? b = (byte?)theWeaponSalvo.Target.BDA_StructuralIntegrity;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
						{
							Side side2 = myUnit.get_UnitSide(SetSideOnly: false);
							ref Scenario parentScen2 = ref myUnit.ParentScen;
							ref ActiveUnit theAU2 = ref myUnit;
							Contact theTarget = null;
							side2.StopShootingSalvo(ref parentScen2, ref theAU2, ref theTarget, ref theWeaponSalvo);
							continue;
						}
					}
					if (!theWeaponSalvo.FireSimultaneouslyFromMultipleMounts && (theWeaponSalvo.Target.IsFacility || theWeaponSalvo.Target.IsShip || theWeaponSalvo.Target.IsSubmarine))
					{
						bool_2 = true;
					}
					if (shooter3.TimeToNextLaunch > 1)
					{
						shooter3.TimeToNextLaunch--;
						continue;
					}
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						for (int num2 = 0; num2 < weapons.Length; num2 = checked(num2 + 1))
						{
							weapons[num2].get_ReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
						}
						IEnumerable<WeaponRec> enumerable = from $VB$It in ((Aircraft)myUnit).Loadout.Weapons.OrderByDescending([SpecialName] (WeaponRec WeaponRec) => WeaponRec.CurrentLoad).GroupBy([SpecialName] (WeaponRec WeaponRec) => WeaponRec.int_3, [SpecialName] (int int_0, IEnumerable<WeaponRec> $VB$ItAnonymous) => new VB$AnonymousType_4<int, IEnumerable<WeaponRec>>(int_0, $VB$ItAnonymous))
							select $VB$It.G.First();
						foreach (WeaponRec item6 in enumerable)
						{
							WeaponRec theWeaponRec = item6;
							Weapon weapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
							if ((weapon.IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse) || theWeaponSalvo.int_1 != theWeaponRec.int_3)
							{
								continue;
							}
							if (theWeaponRec.CurrentLoad != 0)
							{
								if (theWeaponRec.TimeToFire != 0f)
								{
									shooter3.WeaponIsReadyToFire = false;
									continue;
								}
								shooter3.WeaponIsReadyToFire = true;
								if (shooter3.Timeout <= 1 && !theWeaponSalvo.ManualFire)
								{
									_ = shooter3.QuantityFired == 0;
								}
								if (!weapon.IsWeaponPallet)
								{
									ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
									Weapon theWeapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
									Contact target = theWeaponSalvo.Target;
									bool manualFire = theWeaponSalvo.ManualFire;
									Sensor SuitableDirectorSensor = null;
									if (weaponry.CanThisWeaponEngageThisTarget(theWeapon, target, ref ASL_atFiringUnit, manualFire, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor, DLZCheckRequested: true, theWeaponSalvo.PlottedCourse).EvaluationEnum != WeaponPrefireChecklistEvaluation.OK)
									{
										continue;
									}
								}
								else
								{
									bool flag3 = false;
									if (weapon.Warheads.Count() > 0)
									{
										Warhead[] warheads = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen).Warheads;
										foreach (Warhead warhead in warheads)
										{
											if (flag3)
											{
												break;
											}
											if (warhead.get_CarriedWeapon(myUnit.ParentScen) != null)
											{
												Weapon theWeapon2 = warhead.get_CarriedWeapon(myUnit.ParentScen);
												Contact target2 = theWeaponSalvo.Target;
												bool manualFire2 = theWeaponSalvo.ManualFire;
												Sensor SuitableDirectorSensor = null;
												if (CanThisWeaponEngageThisTarget(theWeapon2, target2, ref ASL_atFiringUnit, manualFire2, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor, DLZCheckRequested: true, theWeaponSalvo.PlottedCourse).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
												{
													flag3 = true;
												}
											}
										}
										if (!flag3)
										{
											continue;
										}
									}
								}
								int quantityFired = shooter3.QuantityFired;
								ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
								Contact target3 = theWeaponSalvo.Target;
								int NumberOfWeaponsFired = theWeaponSalvo.WpnQuantityFired;
								shooter3.QuantityFired = quantityFired + weaponry2.FireWeapon_Normal(elapsedTime, ref theWeaponRec, target3, ref NumberOfWeaponsFired, num, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo).Count;
							}
							else if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false) > 0)
							{
								shooter3.WeaponIsReadyToFire = false;
							}
							else
							{
								shooter3.WeaponIsReadyToFire = true;
								WeaponSalvo.Shooter value2 = theWeaponSalvo.ShootersList.Where([SpecialName] (WeaponSalvo.Shooter x) => Operators.CompareString(x.ShooterObjectID, myUnit.ObjectID, false) == 0).FirstOrDefault();
								ArrayExtensions.Remove(ref theWeaponSalvo.ShootersList, value2);
							}
						}
					}
					if (myUnit.IsPalletWeapon)
					{
						Warhead[] warheads2 = ((Weapon)myUnit).Warheads;
						foreach (Warhead warhead2 in warheads2)
						{
							if (warhead2.get_CarriedWeapon(myUnit.ParentScen) != null)
							{
								warhead2.get_CarriedWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
							}
						}
						if (((Weapon)myUnit).WeaponWeapons.Count == 0)
						{
							((Weapon)myUnit).InitializeWeaponWeaponsPallet();
						}
						List<WeaponRec> weaponWeapons = ((Weapon)myUnit).WeaponWeapons;
						foreach (WeaponRec item7 in weaponWeapons)
						{
							WeaponRec theWeaponRec2 = item7;
							Weapon weapon2 = theWeaponRec2.get_ReferenceWeapon(myUnit.ParentScen);
							if ((weapon2.IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse) || theWeaponSalvo.int_1 != theWeaponRec2.int_3)
							{
								continue;
							}
							if (theWeaponRec2.CurrentLoad != 0)
							{
								shooter3.WeaponIsReadyToFire = true;
								if (shooter3.Timeout <= 1 && !theWeaponSalvo.ManualFire)
								{
									_ = shooter3.QuantityFired == 0;
								}
								ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
								Weapon theWeapon3 = theWeaponRec2.get_ReferenceWeapon(myUnit.ParentScen);
								Contact target4 = theWeaponSalvo.Target;
								bool manualFire3 = theWeaponSalvo.ManualFire;
								Sensor SuitableDirectorSensor = null;
								if (weaponry3.CanThisWeaponEngageThisTarget(theWeapon3, target4, ref ASL_atFiringUnit, manualFire3, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor, DLZCheckRequested: true, theWeaponSalvo.PlottedCourse).EvaluationEnum != WeaponPrefireChecklistEvaluation.OK)
								{
									continue;
								}
								int NumberOfWeaponsFired2 = 0;
								foreach (Weapon item8 in myUnit.ParentScen.AllWeaponsAlive)
								{
									if (item8.FiringParent != null && Operators.CompareString(item8.FiringParent.ObjectID, myUnit.ObjectID, false) == 0 && item8.AI.PrimaryTarget != null && Operators.CompareString(item8.AI.PrimaryTarget.ObjectID, theWeaponSalvo.Target.ObjectID, false) == 0)
									{
										NumberOfWeaponsFired2++;
									}
								}
								myUnit.Weaponry.FireWeapon_Normal(elapsedTime, ref theWeaponRec2, theWeaponSalvo.Target, ref NumberOfWeaponsFired2, num, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
								shooter3.QuantityFired += NumberOfWeaponsFired2;
								if (NumberOfWeaponsFired2 == 0)
								{
									flag = true;
								}
								if (NumberOfWeaponsFired2 > 0 && !theWeaponSalvo.FireSimultaneouslyFromMultipleMounts)
								{
									return;
								}
							}
							else if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon2.DBID, IncludeNonOperationalMountsAndMags: false) > 0)
							{
								shooter3.WeaponIsReadyToFire = false;
							}
							else
							{
								shooter3.WeaponIsReadyToFire = true;
							}
						}
					}
					try
					{
						if (!flag)
						{
							bool flag4 = false;
							foreach (Mount mount in myUnit.Mounts)
							{
								if (!theWeaponSalvo.ManualFire && Operators.CompareString(shooter3.PreferredMountObjectID, "", false) != 0 && Operators.CompareString(mount.ObjectID, shooter3.PreferredMountObjectID, false) != 0)
								{
									continue;
								}
								int NumberOfWeaponsFired3 = shooter3.QuantityFired;
								foreach (WeaponRec mountWeapon in mount.MountWeapons)
								{
									WeaponRec theWeaponRec3 = mountWeapon;
									if (theWeaponSalvo.int_1 != theWeaponRec3.int_3 || theWeaponRec3.CurrentLoad == 0)
									{
										continue;
									}
									if (mount.Status != PlatformComponent._ComponentStatus.Operational)
									{
										break;
									}
									if (mount.TimeToFire == 0f && mount.MountMagazine.TimeToFire == 0f)
									{
										if (theWeaponRec3.TimeToFire != 0f)
										{
											continue;
										}
										flag4 = true;
										Weapon weapon3 = theWeaponRec3.get_ReferenceWeapon(myUnit.ParentScen);
										if (weapon3.IsGuidedWeapon() && !myUnit.ParentScen.SecondIsChangingOnThisPulse)
										{
											continue;
										}
										shooter3.WeaponIsReadyToFire = true;
										if (shooter3.Timeout <= 1 && !theWeaponSalvo.ManualFire)
										{
											_ = shooter3.QuantityFired == 0;
										}
										ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
										Weapon theWeapon4 = theWeaponRec3.get_ReferenceWeapon(myUnit.ParentScen);
										Contact target5 = theWeaponSalvo.Target;
										bool manualFire4 = theWeaponSalvo.ManualFire;
										Sensor SuitableDirectorSensor = null;
										(string, WeaponPrefireChecklistEvaluation) tuple = weaponry4.CanThisWeaponEngageThisTarget(theWeapon4, target5, ref ASL_atFiringUnit, manualFire4, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, mount, ref SuitableDirectorSensor, DLZCheckRequested: true, theWeaponSalvo.PlottedCourse);
										if (tuple.Item2 != WeaponPrefireChecklistEvaluation.OK)
										{
											string text = "The Unit " + myUnit.Name + " cannot fire against " + theWeaponSalvo.Target.Name + " with weapon " + theWeaponSalvo.get_ReferenceWeapon(myUnit.ParentScen).Name + ". REASON: " + tuple.Item1;
											if (!myUnit.ParentScen.WeaponFeedBackMessage.Contains(text))
											{
												myUnit.ParentScen.AddMessage(text, myUnit.Name + " cannot fire at " + theWeaponSalvo.Target.Name, LoggedMessage.MessageType.WeaponLogic, 1, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
												myUnit.ParentScen.WeaponFeedBackMessage.Add(text);
											}
											if (tuple.Item2 == WeaponPrefireChecklistEvaluation.WithinMinimumRange && !myUnit.IsAircraft)
											{
												pooledList4.Add(theWeaponSalvo);
												num = 0;
											}
											continue;
										}
										if (weapon3.IsGuidedWeapon() && weapon3.IsAAW_GuidedMissile_ARH && theWeaponSalvo.Target.IsAir_Missile_Orbital_Contact && !myUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(theWeaponSalvo.Target) && !method_9(weapon3, theWeaponSalvo.Target))
										{
											shooter3.NeedsSensorTrack_AAWFireControlGrade = true;
											if (!myUnit.Sensory.ActivateToObtainTrack_AAWFireControlGrade(theWeaponSalvo.Target))
											{
												string text2 = "The Unit " + myUnit.Name + " cannot fire against " + theWeaponSalvo.Target.Name + " with weapon " + theWeaponSalvo.get_ReferenceWeapon(myUnit.ParentScen).Name + ". REASON: Firing unit must obtain (from itself or another CEC-enabled platform) a high-quality track on the target before firing";
												if (!myUnit.ParentScen.WeaponFeedBackMessage.Contains(text2))
												{
													myUnit.ParentScen.AddMessage(text2, myUnit.Name + " cannot fire at " + theWeaponSalvo.Target.Name, LoggedMessage.MessageType.WeaponLogic, 1, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
													myUnit.ParentScen.WeaponFeedBackMessage.Add(text2);
												}
											}
											continue;
										}
										shooter3.NeedsSensorTrack_AAWFireControlGrade = false;
										myUnit.Weaponry.FireWeapon_Normal(elapsedTime, ref theWeaponRec3, theWeaponSalvo.Target, ref NumberOfWeaponsFired3, num, 0f, ActiveUnit.Throttle.Flank, mount, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
										if (theWeaponRec3.ParentMount != null)
										{
											theWeaponRec3.ParentMount.TimeToFire = theWeaponRec3.ParentMount.ROF;
										}
										shooter3.QuantityFired = NumberOfWeaponsFired3;
										if (NumberOfWeaponsFired3 == 0)
										{
											flag = true;
										}
										if (NumberOfWeaponsFired3 > 0)
										{
											if (theWeaponRec3.CurrentLoad == 0)
											{
												int theQty_FullyLoadedCells = 0;
												int theQty_PartiallyLoadedCells = 0;
												if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) == 0)
												{
													mount.TimeToReloadAttempt = 0f;
													goto IL_11c2;
												}
											}
											if (mount.TimeToReloadAttempt < 300f)
											{
												mount.TimeToReloadAttempt = mount.TimeToFire + 300f;
											}
											goto IL_11c2;
										}
										goto IL_1200;
									}
									shooter3.WeaponIsReadyToFire = false;
									break;
									IL_11c2:
									if (theWeaponSalvo.ManualFire || !mount.ReserveTarget || theWeaponRec3.CurrentLoad != 0 || !theWeaponSalvo.Target.IsAir_Missile_Orbital_Contact)
									{
										num = shooter3.QuantityAssigned - NumberOfWeaponsFired3;
										if (!theWeaponSalvo.FireSimultaneouslyFromMultipleMounts)
										{
											if (num > 0)
											{
												if (theWeaponRec3.CurrentLoad == 0)
												{
													shooter3.PreferredMountObjectID = "";
													shooter3.TimeToNextLaunch = (int)Math.Round(theWeaponRec3.TimeToFire);
												}
												else
												{
													shooter3.PreferredMountObjectID = mount.ObjectID;
													shooter3.TimeToNextLaunch = (int)Math.Round(theWeaponRec3.TimeToFire);
												}
											}
											else
											{
												shooter3.PreferredMountObjectID = mount.ObjectID;
												shooter3.TimeToNextLaunch = 0;
											}
											return;
										}
										goto IL_1200;
									}
									Side side3 = myUnit.get_UnitSide(SetSideOnly: false);
									ref Scenario parentScen3 = ref myUnit.ParentScen;
									ref ActiveUnit theAU3 = ref myUnit;
									Contact theTarget = null;
									side3.StopShootingSalvo(ref parentScen3, ref theAU3, ref theTarget, ref theWeaponSalvo);
									return;
									IL_1200:
									if (num <= 0)
									{
										break;
									}
								}
								if (num <= 0)
								{
									break;
								}
							}
							if (!theWeaponSalvo.ManualFire && !flag4 && !shooter3.WeaponIsReadyToFire && shooter3.Timeout > 0)
							{
								myUnit.get_UnitSide(SetSideOnly: false).RemoveThisUnitFromThisSalvos(ref myUnit.ParentScen, myUnit.ObjectID, ref theWeaponSalvo);
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 101210", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (!theWeaponSalvo.ManualFire && flag && shooter3.Timeout == 1 && theWeaponSalvo.WeaponList.Count == 0)
					{
						pooledList.Add(theWeaponSalvo);
					}
				}
				foreach (KeyValuePair<string, WeaponSalvo> item9 in pooledDictionary)
				{
					Side side4 = myUnit.get_UnitSide(SetSideOnly: false);
					ref Scenario parentScen4 = ref myUnit.ParentScen;
					string key = item9.Key;
					WeaponSalvo theSalvo = item9.Value;
					side4.RemoveThisUnitFromThisSalvos(ref parentScen4, key, ref theSalvo);
				}
				pooledDictionary.Dispose();
				if (pooledList.Count > 0)
				{
					foreach (WeaponSalvo item10 in pooledList)
					{
						try
						{
							myUnit.get_UnitSide(SetSideOnly: false).RemoveWeaponSalvo(item10);
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							ProjectData.ClearProjectError();
						}
					}
				}
				pooledList.Dispose();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200578", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	internal bool TargetIsWithinWeaponBoresightArc(Weapon theWeapon, Contact theTarget, [Optional][DefaultParameterValue("")] ref string feedBackMessage)
	{
		bool flag = false;
		bool result;
		try
		{
			float BoresightLimit = default(float);
			theWeapon.GetBoresightLimit(myUnit, theTarget, ref BoresightLimit, ref flag);
			if (flag)
			{
				double BearingAngle = default(double);
				double VerticalAngle = default(double);
				Module_Unit.AngleOffThisUnitsBoresight3D(theTarget, myUnit, ref BearingAngle, ref VerticalAngle);
				bool flag2 = true;
				float num = 0f;
				if (Math.Abs(BearingAngle) > (double)BoresightLimit)
				{
					flag2 = false;
					feedBackMessage = "Target is outside horizontal boresight limit";
				}
				if (myUnit.IsAircraft)
				{
					num = method_0();
				}
				if (Math.Abs(VerticalAngle) > (double)(BoresightLimit + num))
				{
					flag2 = false;
					if (Operators.CompareString(feedBackMessage, "", false) != 0)
					{
						feedBackMessage = "Target is outside horizontal and vertical boresight limits, check observer altitude, orientation and pitch ";
					}
					else
					{
						feedBackMessage += "Target is outside vertical boresight limit, check observer altitude and pitch";
					}
				}
				result = flag2;
			}
			else
			{
				ActiveUnit observerUnit = myUnit;
				string feedbackMessage = "";
				if (Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(theTarget, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue)) < BoresightLimit)
				{
					result = true;
				}
				else
				{
					feedBackMessage = "Target is outside horizontal boresight limit";
					result = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100298", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private float method_0()
	{
		if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f)
		{
			return 0f;
		}
		return (float)(Math.Atan((float)((double)Module_Unit.CurrentSpeed_Horizontal(myUnit) * 0.514444) / myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 57.2957795130823);
	}

	public bool CanPhysicallyAttackThisTargetRightNow(Contact theTarget, bool IgnoreAircraftOrientation, bool IgnoreWeaponRecTimeToFire)
	{
		int? ASL_atFiringUnit = default(int?);
		if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
		{
			WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				weapons[i].get_ReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
			}
			WeaponRec[] weapons2 = ((Aircraft)myUnit).Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons2)
			{
				if (weaponRec.CurrentLoad != 0 && (IgnoreWeaponRecTimeToFire || !(weaponRec.TimeToFire > 0f)))
				{
					ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
					Weapon theWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
					Sensor SuitableDirectorSensor = null;
					if (weaponry.CanThisWeaponEngageThisTarget(theWeapon, theTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
					{
						return true;
					}
				}
			}
		}
		foreach (Mount mount in myUnit.Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				if (mountWeapon.CurrentLoad != 0 && (IgnoreWeaponRecTimeToFire || !(mountWeapon.TimeToFire > 0f)))
				{
					ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
					Weapon theWeapon2 = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
					Sensor SuitableDirectorSensor = null;
					if (weaponry2.CanThisWeaponEngageThisTarget(theWeapon2, theTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation, HumanFeedBackNeeded: false, mount, ref SuitableDirectorSensor).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool CreateSalvo(Contact theTarget, int theWeaponDBID, int theWeaponQty, bool IsManual, ref Doctrine._GunStrafeGroundTargets? GunStrafingSalvo, DateTime theScheduledTime, bool CreatingSalvoForPalletWeapon, bool CreatingSalvoForPallettizedWeapon, bool RebuildSalvoCache, bool GenerateFiringProposal = true, bool supplementingShootersOutOfAmmo = false, bool IsSelfDefence = false, string SalvoTag = "")
	{
		_Closure$__59-0 arg = default(_Closure$__59-0);
		_Closure$__59-0 CS$<>8__locals106 = new _Closure$__59-0(arg);
		CS$<>8__locals106.$VB$Me = this;
		CS$<>8__locals106.$VB$Local_theTarget = theTarget;
		CS$<>8__locals106.$VB$Local_theWeaponDBID = theWeaponDBID;
		if (RebuildSalvoCache)
		{
			myUnit.get_UnitSide(SetSideOnly: false).RebuildSalvoCache();
		}
		if (IsManual)
		{
			myUnit.AI.ManuallyMarkTargetHostile(ref CS$<>8__locals106.$VB$Local_theTarget, IsManual);
		}
		else if (GetWCSForThisTargetType(CS$<>8__locals106.$VB$Local_theTarget.Type) == Doctrine._WCS.Hold)
		{
			return false;
		}
		switch (CS$<>8__locals106.$VB$Local_theTarget.Type)
		{
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
		case Contact_Base.ContactType.AggregateGroundUnit:
			if (bool_2)
			{
				return false;
			}
			goto default;
		case Contact_Base.ContactType.Decoy_Air:
			if (!bool_2)
			{
				bool flag = false;
				if (CS$<>8__locals106.$VB$Local_theTarget.DetectedEmissions.Count != 0)
				{
					foreach (KeyValuePair<int, EmissionContainer> detectedEmission in CS$<>8__locals106.$VB$Local_theTarget.DetectedEmissions)
					{
						if (detectedEmission.Value.get_AssociatedSensor(detectedEmission.Key, myUnit.ParentScen).IsOECM)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					return false;
				}
				goto default;
			}
			return false;
		default:
		{
			if (CS$<>8__locals106.$VB$Local_theTarget.BDA_StructuralIntegrity.HasValue)
			{
				byte? b = (byte?)CS$<>8__locals106.$VB$Local_theTarget.BDA_StructuralIntegrity;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
				{
					return false;
				}
			}
			List<WeaponSalvo> list;
			int num2;
			if (IsSelfDefence)
			{
				PooledList<WeaponSalvo> pooledList = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref myUnit, CS$<>8__locals106.$VB$Local_theTarget);
				int num;
				if (pooledList == null)
				{
					list = new List<WeaponSalvo>();
					num = 0;
				}
				else
				{
					list = pooledList.ToList();
					num = 0;
				}
				GenerateFiringProposal = (byte)num != 0;
				num2 = 0;
			}
			else
			{
				list = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosForThisTarget(CS$<>8__locals106.$VB$Local_theTarget);
				num2 = 0;
			}
			bool flag2 = (byte)num2 != 0;
			bool flag3 = false;
			bool flag4 = true;
			WeaponSalvo theSalvo = null;
			if (IsManual)
			{
				foreach (WeaponSalvo item4 in list)
				{
					if (item4.Target == CS$<>8__locals106.$VB$Local_theTarget && CS$<>8__locals106.$VB$Local_theWeaponDBID == item4.int_1)
					{
						int num3 = item4.ShootersList.Length - 1;
						for (int i = 0; i <= num3; i++)
						{
							WeaponSalvo.Shooter shooter;
							try
							{
								shooter = item4.ShootersList[i];
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								ProjectData.ClearProjectError();
								continue;
							}
							if (string.CompareOrdinal(shooter.ShooterObjectID, myUnit.ObjectID) == 0)
							{
								theSalvo = item4;
								break;
							}
						}
					}
					if (theSalvo != null)
					{
						break;
					}
				}
			}
			else
			{
				if (GenerateFiringProposal && myUnit.get_UnitSide(SetSideOnly: false).FiringProposals != null)
				{
					IEnumerator<KeyValuePair<string, FiringProposal>> enumerator3 = myUnit.get_UnitSide(SetSideOnly: false).FiringProposals.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						FiringProposal value = enumerator3.Current.Value;
						if (string.CompareOrdinal(value.Target.ObjectID, CS$<>8__locals106.$VB$Local_theTarget.ObjectID) == 0 && string.CompareOrdinal(value.FiringUnit.ObjectID, myUnit.ObjectID) == 0)
						{
							return false;
						}
					}
				}
				int num4 = list.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					try
					{
						WeaponSalvo weaponSalvo = list[j];
						if (weaponSalvo.Target == CS$<>8__locals106.$VB$Local_theTarget)
						{
							int num5 = weaponSalvo.ShootersList.Length - 1;
							for (int k = 0; k <= num5; k++)
							{
								WeaponSalvo.Shooter shooter;
								try
								{
									shooter = weaponSalvo.ShootersList[k];
								}
								catch (Exception projectError2)
								{
									ProjectData.SetProjectError(projectError2);
									ProjectData.ClearProjectError();
									continue;
								}
								if (string.CompareOrdinal(shooter?.ShooterObjectID, myUnit?.ObjectID) == 0)
								{
									if (myUnit.IsAircraft)
									{
										return false;
									}
									flag3 = true;
								}
							}
							if (!weaponSalvo.FireSimultaneouslyFromMultipleMounts)
							{
								flag2 = true;
							}
						}
						if (flag4 && weaponSalvo.get_ReferenceWeapon(myUnit.ParentScen) != null && !weaponSalvo.get_ReferenceWeapon(myUnit.ParentScen).IsMobileDecoy)
						{
							flag4 = false;
						}
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
					}
				}
			}
			Weapon weapon = myUnit.ParentScen.Cache_GetWeapon(CS$<>8__locals106.$VB$Local_theWeaponDBID);
			if (weapon == null)
			{
				weapon = Weapon.GetNewWeapon(ref myUnit.ParentScen, CS$<>8__locals106.$VB$Local_theWeaponDBID, bool_5: false);
			}
			if (CS$<>8__locals106.$VB$Local_theWeaponDBID == 0)
			{
				weapon = MostSuitableWeaponForThisTarget(CS$<>8__locals106.$VB$Local_theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
				SQLiteConnection sqliteConnection_;
				if (weapon != null)
				{
					Weapon weapon2 = weapon;
					int dBID = MostSuitableWeaponForThisTarget(CS$<>8__locals106.$VB$Local_theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine).DBID;
					sqliteConnection_ = CS$<>8__locals106.$VB$Local_theTarget.ActualUnit.ParentScen.DBConnection;
					weapon2.ValidTargets = new WeaponTargets(dBID, ref sqliteConnection_);
				}
				else
				{
					Weapon weapon3 = weapon;
					sqliteConnection_ = CS$<>8__locals106.$VB$Local_theTarget.ActualUnit.ParentScen.DBConnection;
					weapon3.ValidTargets = new WeaponTargets(0, ref sqliteConnection_);
				}
				Weapon weapon4 = weapon;
				sqliteConnection_ = CS$<>8__locals106.$VB$Local_theTarget.ActualUnit.ParentScen.DBConnection;
				weapon4.ValidTargets = new WeaponTargets(0, ref sqliteConnection_);
			}
			ref Contact theTarget2 = ref CS$<>8__locals106.$VB$Local_theTarget;
			Weapon theW = weapon;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget2, theW, ref EmitterClassificable);
			if (theTargetType == Doctrine._WRA_WeaponTargetType.Emitter_Unspecified || theTargetType == Doctrine._WRA_WeaponTargetType.Emitter_Radar || theTargetType == Doctrine._WRA_WeaponTargetType.Emitter_Jammer)
			{
				List<Weapon> list2 = AllDistinctWeaponsAboard_Actual();
				new List<Weapon>();
				Weapon weapon5 = default(Weapon);
				foreach (Weapon item5 in list2)
				{
					if (item5.ValidTargets.Radar)
					{
						weapon5 = item5;
						break;
					}
				}
				if (weapon5 == null)
				{
					theTargetType = Contact.WRA_DetermineTargetType(ref CS$<>8__locals106.$VB$Local_theTarget, weapon, ref GlobalVariables.ObjectFalse);
				}
			}
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<int, WeaponSalvoWpnQty>();
			}
			else
			{
				dictionary_0.Clear();
			}
			WeaponRec weaponRec = null;
			float? num6 = null;
			float? num7 = null;
			float? num8 = null;
			bool result = true;
			bool flag5 = false;
			if (list_2 == null)
			{
				list_2 = new List<WeaponRec>();
			}
			else
			{
				list_2.Clear();
			}
			int? num9 = default(int?);
			GlobalVariables.BooleanObject TargetIsDestroyed = default(GlobalVariables.BooleanObject);
			float? num11 = default(float?);
			int? num13 = default(int?);
			int? ASL_atFiringUnit = default(int?);
			WeaponRec weaponRec3 = default(WeaponRec);
			Weapon theWeapon;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = default(Doctrine._WRA_WeaponTargetType);
			if (myUnit.IsPalletWeapon)
			{
				WeaponRec weaponRec2 = default(WeaponRec);
				try
				{
					foreach (WeaponRec weaponWeapon in ((Weapon)myUnit).WeaponWeapons)
					{
						if (weaponWeapon.get_ReferenceWeapon(myUnit.ParentScen).DBID == CS$<>8__locals106.$VB$Local_theWeaponDBID)
						{
							weaponRec2 = weaponWeapon;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 1654165432138", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				weaponRec2.ParentMount = null;
				if (!IsManual)
				{
					if (weaponRec2.CurrentLoad == 0)
					{
						return false;
					}
					if (weaponRec2.TimeToFire > 0f)
					{
						return false;
					}
					try
					{
						if (dictionary_0.ContainsKey(weaponRec2.int_3))
						{
							int? weaponQty_Available = dictionary_0[weaponRec2.int_3].WeaponQty_Available;
							int result2;
							if (Information.IsNothing((object)weaponQty_Available))
							{
								weaponQty_Available = weaponRec2.CurrentLoad;
								result2 = 0;
							}
							else
							{
								weaponQty_Available += weaponRec2.CurrentLoad;
								result2 = 0;
							}
							return (byte)result2 != 0;
						}
						num9 = weaponRec2.CurrentLoad;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 10113874573878333238", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					try
					{
						if (dictionary_0.ContainsKey(weaponRec2.int_3))
						{
							int? weaponQty_Available2 = dictionary_0[weaponRec2.int_3].WeaponQty_Available;
							weaponQty_Available2 = (weaponQty_Available2.HasValue ? (weaponQty_Available2 + num9) : num9);
							dictionary_0[weaponRec2.int_3].WeaponQty_Available = weaponQty_Available2;
							return false;
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 1012333410038", "");
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (theSalvo != null)
					{
						return false;
					}
					theWeapon = weaponRec2.get_ReferenceWeapon(myUnit.ParentScen);
					Weapon._WeaponType type = theWeapon.Type;
					try
					{
						if (type == Weapon._WeaponType.Gun && CS$<>8__locals106.$VB$Local_theTarget.isSurfaceOrLandContact)
						{
							if (!GunStrafingSalvo.HasValue)
							{
								GunStrafingSalvo = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							}
							byte? b = (byte?)GunStrafingSalvo;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
							{
								return false;
							}
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at 1011235661238", "");
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					float num10 = default(float);
					try
					{
						if (!theWeapon.IsNominallySuitableForThisTarget(myUnit, ref CS$<>8__locals106.$VB$Local_theTarget, ref TargetIsDestroyed))
						{
							return false;
						}
						num10 = WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ManualFire: false);
						if (type == Weapon._WeaponType.Gun && Information.IsNothing((object)num7))
						{
							num7 = Module_Unit.RangeToUnit_Slant(myUnit, CS$<>8__locals106.$VB$Local_theTarget);
						}
						else if (!num6.HasValue)
						{
							num11 = myUnit.RangeToUnit_Horiz(CS$<>8__locals106.$VB$Local_theTarget);
							num6 = num11;
						}
						float? num12;
						if (type == Weapon._WeaponType.Gun)
						{
							num12 = num7;
							if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() > num10)) == true)
							{
								return false;
							}
						}
						num12 = num6;
						if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() > num10)) == true)
						{
							return false;
						}
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						ex10?.Data.Add("Error at 10112313121238", "");
						GameGeneral.WriteExceptionsToLog(ex10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					num8 = ((type != Weapon._WeaponType.Gun) ? num6 : num7);
					if (myUnit.Doctrine.WRA_RelevantWeapon(ref theWeapon))
					{
						try
						{
							wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
							Doctrine doctrine = myUnit.Doctrine;
							Scenario parentScen = myUnit.ParentScen;
							Weapon theWeapon2 = theWeapon;
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType = wRA_WeaponTargetType;
							int? TargetType_InheritedWeaponQty = null;
							int? TargetType_UnspecifiedWeaponQty = null;
							num13 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon2, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
							TargetType_UnspecifiedWeaponQty = num13;
							if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0) : ((bool?)null)) == true)
							{
								return false;
							}
							TargetType_UnspecifiedWeaponQty = num13;
							if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty == -99)) == true)
							{
								num13 = int.MaxValue;
							}
							if (!num13.HasValue)
							{
								return false;
							}
							Doctrine doctrine2 = myUnit.Doctrine;
							Doctrine doctrine3 = myUnit.Doctrine;
							Scenario parentScen2 = myUnit.ParentScen;
							int dBID2 = theWeapon.DBID;
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType2 = wRA_WeaponTargetType;
							float? num12 = null;
							float? TargetType_UnspecifiedFiringRange = null;
							float? num14 = doctrine2.WRA_FiringRange_AnyTargetType(doctrine3, parentScen2, dBID2, selectedNodeTargetType2, FindInheritedValuesOnly: false, ref num12, ref TargetType_UnspecifiedFiringRange);
							if (Information.IsNothing((object)num14))
							{
								num14 = -99f;
							}
							TargetType_UnspecifiedFiringRange = num14;
							if (((!TargetType_UnspecifiedFiringRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f)) == true)
							{
								return false;
							}
							TargetType_UnspecifiedFiringRange = num14;
							bool? flag6 = (TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == -99f) : ((bool?)null));
							if (((!flag6) ?? flag6) == true)
							{
								float num15 = theWeapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: true, myUnit.Doctrine, IsManual);
								if ((num8.HasValue ? new bool?(num15 < num8.GetValueOrDefault()) : ((bool?)null)) == true)
								{
									return false;
								}
							}
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 10131111236567678", "");
							GameGeneral.WriteExceptionsToLog(ex12);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							float? num16;
							float? num12;
							if (IsSelfDefence || (list.Count > 0 && !flag4 && !theWeapon.IsMobileDecoy))
							{
								if (CS$<>8__locals106.$VB$Local_theTarget.IsAir_Missile_Orbital_Contact)
								{
									bool flag7 = false;
									foreach (WeaponSalvo item6 in list)
									{
										if (item6.int_1 == theWeapon.DBID)
										{
											flag7 = true;
											break;
										}
									}
									if (flag7)
									{
										return false;
									}
								}
								Doctrine doctrine4 = myUnit.Doctrine;
								Doctrine doctrine5 = myUnit.Doctrine;
								Scenario parentScen3 = myUnit.ParentScen;
								Weapon theWeapon3 = theWeapon;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType3 = wRA_WeaponTargetType;
								float? TargetType_UnspecifiedFiringRange = null;
								num12 = null;
								num16 = doctrine4.WRA_SelfDefenceRange_AnyTargetType(doctrine5, parentScen3, theWeapon3, selectedNodeTargetType3, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedFiringRange, ref num12);
								num12 = num16;
								if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() == -99f)) == true)
								{
									num16 = (int)Math.Round(num10);
								}
								if (IsSelfDefence)
								{
									if (num16.HasValue)
									{
										int result3;
										if (num16.Value != 0f)
										{
											float value2 = num16.Value;
											if ((num8.HasValue ? new bool?(value2 < num8.GetValueOrDefault()) : ((bool?)null)) != true)
											{
												goto IL_0f8e;
											}
											result3 = 0;
										}
										else
										{
											result3 = 0;
										}
										return (byte)result3 != 0;
									}
									return false;
								}
								goto IL_0f8e;
							}
							goto end_IL_0e22;
							IL_105b:
							int num17;
							bool flag8 = (byte)num17 != 0;
							foreach (WeaponSalvo item7 in list)
							{
								if (item7.int_1 != theWeapon.DBID || item7.ShootersList.Length >= item7.MaxNumberOfShooters)
								{
									continue;
								}
								int num18;
								if (item7.MaxNumberOfWeapons != int.MaxValue)
								{
									if (item7.MaxNumberOfWeapons <= item7.WpnQuantityAssigned)
									{
										continue;
									}
									num18 = 1;
								}
								else
								{
									num18 = 1;
								}
								flag8 = (byte)num18 != 0;
								break;
							}
							if (!flag8)
							{
								return false;
							}
							goto end_IL_0e22;
							IL_0f8e:
							num12 = num16;
							if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 0f) : ((bool?)null)) == true)
							{
								num17 = 0;
								goto IL_105b;
							}
							num12 = num16;
							bool? flag6 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() > 0f) : ((bool?)null));
							if ((flag6 ?? true) && ((num16.HasValue & num8.HasValue) ? new bool?(num16.GetValueOrDefault() < num8.GetValueOrDefault()) : ((bool?)null)) == true && flag6.HasValue)
							{
								num17 = 0;
								goto IL_105b;
							}
							end_IL_0e22:;
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception ex14 = ex13;
							ex14?.Data.Add("Error at 10123131231313448", "");
							GameGeneral.WriteExceptionsToLog(ex14);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					try
					{
						if (list.Count > 0)
						{
							bool flag9 = false;
							foreach (WeaponSalvo item8 in list)
							{
								if (item8.int_1 != theWeapon.DBID)
								{
									continue;
								}
								if (item8.WpnQuantityAssigned >= item8.MaxNumberOfWeapons && item8.MaxNumberOfWeapons != int.MaxValue)
								{
									flag9 = true;
								}
								if (!flag9)
								{
									WeaponSalvo.Shooter[] shootersList = item8.ShootersList;
									foreach (WeaponSalvo.Shooter shooter in shootersList)
									{
										if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
										{
											flag9 = true;
											break;
										}
									}
								}
								if (!flag9 && !GenerateFiringProposal && item8.ShootersList.Length < item8.MaxNumberOfShooters)
								{
									theSalvo = item8;
									break;
								}
							}
							if (flag9)
							{
								return false;
							}
						}
					}
					catch (Exception ex15)
					{
						ProjectData.SetProjectError(ex15);
						Exception ex16 = ex15;
						ex16?.Data.Add("Error at 1012389175046", "");
						GameGeneral.WriteExceptionsToLog(ex16);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					try
					{
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Weapon theWeapon4 = theWeapon;
						Contact theTarget3 = CS$<>8__locals106.$VB$Local_theTarget;
						Sensor SuitableDirectorSensor = null;
						WeaponPrefireChecklistEvaluation item = weaponry.CanThisWeaponEngageThisTarget(theWeapon4, theTarget3, ref ASL_atFiringUnit, IsManual, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum;
						if (item != WeaponPrefireChecklistEvaluation.OK)
						{
							method_1(CS$<>8__locals106.$VB$Local_theTarget, item);
							return false;
						}
					}
					catch (Exception ex17)
					{
						ProjectData.SetProjectError(ex17);
						Exception ex18 = ex17;
						ex18?.Data.Add("Error at 10134515772438", "");
						GameGeneral.WriteExceptionsToLog(ex18);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (weaponRec3 != null)
				{
					list_2.Add(weaponRec3);
				}
				else
				{
					list_2.Add(weaponRec2);
				}
				if (!IsManual)
				{
					WeaponSalvoWpnQty value3 = new WeaponSalvoWpnQty(num13, num9);
					if (weaponRec3 != null)
					{
						dictionary_0.Add(weaponRec3.int_3, value3);
					}
					else
					{
						dictionary_0.Add(weaponRec2.int_3, value3);
					}
				}
			}
			WeaponRec weaponRec4 = default(WeaponRec);
			if (myUnit.IsAircraft)
			{
				if (((Aircraft)myUnit).Loadout != null)
				{
					try
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						foreach (WeaponRec weaponRec2 in weapons)
						{
							weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).CurrentHeading = myUnit.CurrentHeading;
						}
						int num19 = 0;
						WeaponRec[] weapons2 = ((Aircraft)myUnit).Loadout.Weapons;
						foreach (WeaponRec weaponRec2 in weapons2)
						{
							num19 += weaponRec2.CurrentLoad;
						}
						foreach (Mount mount in ((Aircraft)myUnit).Mounts)
						{
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								num19 += mountWeapon.CurrentLoad;
							}
						}
						if (num19 == 0)
						{
							return false;
						}
					}
					catch (Exception ex19)
					{
						ProjectData.SetProjectError(ex19);
						Exception ex20 = ex19;
						ex20?.Data.Add("Error at 10238t211", "");
						GameGeneral.WriteExceptionsToLog(ex20);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					int num20 = 0;
					int num21 = 0;
					WeaponRec[] weapons3 = ((Aircraft)myUnit).Loadout.Weapons;
					float num24 = default(float);
					bool MissionProfileAttackIngressAltitudeTerrainFollowing = default(bool);
					foreach (WeaponRec weaponRec2 in weapons3)
					{
						if (theSalvo != null)
						{
							try
							{
								bool flag10 = false;
								if (weaponRec2.int_3 != CS$<>8__locals106.$VB$Local_theWeaponDBID)
								{
									if (weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet && weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Count() > 0)
									{
										weaponRec4 = weaponRec2;
										flag10 = true;
										num20 = weaponRec2.MaxLoad * weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Where([SpecialName] (Warhead x) => x.DP == (float)CS$<>8__locals106.$VB$Local_theWeaponDBID).Count();
										num21 = weaponRec2.CurrentLoad * weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Where([SpecialName] (Warhead x) => x.DP == (float)CS$<>8__locals106.$VB$Local_theWeaponDBID).Count();
										if (num21 > 0)
										{
											flag10 = true;
										}
										weaponRec3 = new WeaponRec(ref myUnit.ParentScen, CS$<>8__locals106.$VB$Local_theWeaponDBID, num21, num20, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
									}
								}
								else
								{
									flag10 = true;
								}
								if (!flag10 & (CS$<>8__locals106.$VB$Local_theWeaponDBID != 0))
								{
									continue;
								}
							}
							catch (Exception ex21)
							{
								ProjectData.SetProjectError(ex21);
								Exception ex22 = ex21;
								ex22?.Data.Add("Error at 54238134567", "");
								GameGeneral.WriteExceptionsToLog(ex22);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							try
							{
								bool flag11 = false;
								if (weaponRec2.int_3 != CS$<>8__locals106.$VB$Local_theWeaponDBID)
								{
									if (weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet && weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Count() > 0)
									{
										weaponRec4 = weaponRec2;
										flag11 = true;
										num20 = weaponRec2.MaxLoad * weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Where((CS$<>8__locals106.$I2 != null) ? CS$<>8__locals106.$I2 : (CS$<>8__locals106.$I2 = [SpecialName] (Warhead x) => x.DP == (float)CS$<>8__locals106.$VB$Local_theWeaponDBID)).Count();
										num21 = weaponRec2.CurrentLoad * weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Warheads.Where((CS$<>8__locals106.$I3 != null) ? CS$<>8__locals106.$I3 : (CS$<>8__locals106.$I3 = [SpecialName] (Warhead x) => x.DP == (float)CS$<>8__locals106.$VB$Local_theWeaponDBID)).Count();
										if (num21 > 0)
										{
											flag11 = true;
										}
										weaponRec3 = new WeaponRec(ref myUnit.ParentScen, CS$<>8__locals106.$VB$Local_theWeaponDBID, num21, num20, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
									}
								}
								else
								{
									flag11 = true;
								}
								if (!flag11 & (CS$<>8__locals106.$VB$Local_theWeaponDBID != 0))
								{
									continue;
								}
							}
							catch (Exception ex23)
							{
								ProjectData.SetProjectError(ex23);
								Exception ex24 = ex23;
								ex24?.Data.Add("Error at 09348675234", "");
								GameGeneral.WriteExceptionsToLog(ex24);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						weaponRec2.ParentMount = null;
						if (!IsManual)
						{
							try
							{
								if (weaponRec2.CurrentLoad != 0 && weaponRec2.TimeToFire <= 0f)
								{
									if (!dictionary_0.ContainsKey(weaponRec2.int_3))
									{
										num9 = weaponRec2.CurrentLoad;
										goto IL_18f8;
									}
									int? weaponQty_Available3 = dictionary_0[weaponRec2.int_3].WeaponQty_Available;
									if (!Information.IsNothing((object)weaponQty_Available3))
									{
										weaponQty_Available3 += weaponRec2.CurrentLoad;
									}
									else
									{
										weaponQty_Available3 = weaponRec2.CurrentLoad;
									}
								}
							}
							catch (Exception ex25)
							{
								ProjectData.SetProjectError(ex25);
								Exception ex26 = ex25;
								ex26?.Data.Add("Error at 321655724357", "");
								GameGeneral.WriteExceptionsToLog(ex26);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								goto IL_18f8;
							}
							continue;
						}
						goto IL_2549;
						IL_1d06:
						Weapon._WeaponType type2;
						num8 = ((type2 != Weapon._WeaponType.Gun) ? num6 : num7);
						if (myUnit.Doctrine.WRA_RelevantWeapon(ref theWeapon))
						{
							try
							{
								wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
								int? TargetType_InheritedWeaponQty;
								if (!theWeapon.IsWeaponPallet)
								{
									Doctrine doctrine6 = myUnit.Doctrine;
									Scenario parentScen4 = myUnit.ParentScen;
									Weapon theWeapon5 = theWeapon;
									Doctrine._WRA_WeaponTargetType selectedNodeTargetType4 = wRA_WeaponTargetType;
									int? TargetType_UnspecifiedWeaponQty = null;
									TargetType_InheritedWeaponQty = null;
									num13 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine6, parentScen4, theWeapon5, selectedNodeTargetType4, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedWeaponQty, ref TargetType_InheritedWeaponQty);
								}
								else
								{
									num13 = 1;
								}
								TargetType_InheritedWeaponQty = num13;
								if (((!TargetType_InheritedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() == 0)) == true)
								{
									continue;
								}
								TargetType_InheritedWeaponQty = num13;
								if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty == -99) : ((bool?)null)) == true)
								{
									num13 = myUnit.Weaponry.HowManyOfThisWeapon(theWeapon.DBID) * Doctrine.GetShooterNumber(theWeapon, myUnit, CS$<>8__locals106.$VB$Local_theTarget, theTargetType);
								}
								TargetType_InheritedWeaponQty = num13;
								if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
								{
									num13 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num13, ref myUnit, ref CS$<>8__locals106.$VB$Local_theTarget, ref theWeapon);
								}
								if (!num13.HasValue)
								{
									continue;
								}
								Doctrine doctrine7 = myUnit.Doctrine;
								Doctrine doctrine8 = myUnit.Doctrine;
								Scenario parentScen5 = myUnit.ParentScen;
								int dBID3 = theWeapon.DBID;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType5 = wRA_WeaponTargetType;
								float? num12 = null;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num14 = doctrine7.WRA_FiringRange_AnyTargetType(doctrine8, parentScen5, dBID3, selectedNodeTargetType5, FindInheritedValuesOnly: false, ref num12, ref TargetType_UnspecifiedFiringRange);
								if (!num14.HasValue)
								{
									num14 = -99f;
								}
								TargetType_UnspecifiedFiringRange = num14;
								if (((!TargetType_UnspecifiedFiringRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f)) != true)
								{
									TargetType_UnspecifiedFiringRange = num14;
									bool? flag6 = (TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == -99f) : ((bool?)null));
									if (((!flag6) ?? flag6) != true)
									{
										goto IL_201f;
									}
									float num23 = theWeapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: true, myUnit.Doctrine, IsManual);
									if (((!num8.HasValue) ? ((bool?)null) : new bool?(num23 < num8.GetValueOrDefault())) != true)
									{
										goto IL_201f;
									}
								}
							}
							catch (Exception ex27)
							{
								ProjectData.SetProjectError(ex27);
								Exception ex28 = ex27;
								ex28?.Data.Add("Error at 752245228227", "");
								GameGeneral.WriteExceptionsToLog(ex28);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								goto IL_201f;
							}
							continue;
						}
						goto IL_22dd;
						IL_2549:
						try
						{
							if (weaponRec3 != null)
							{
								list_2.Add(weaponRec3);
							}
							else
							{
								list_2.Add(weaponRec2);
							}
							if (!IsManual)
							{
								WeaponSalvoWpnQty value4 = new WeaponSalvoWpnQty(num13, num9);
								if (weaponRec3 != null)
								{
									dictionary_0.Add(weaponRec3.int_3, value4);
								}
								else
								{
									dictionary_0.Add(weaponRec2.int_3, value4);
								}
								continue;
							}
						}
						catch (Exception ex29)
						{
							ProjectData.SetProjectError(ex29);
							Exception ex30 = ex29;
							ex30?.Data.Add("Error at 321654654354", "");
							GameGeneral.WriteExceptionsToLog(ex30);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							continue;
						}
						break;
						IL_201f:
						bool flag12 = method_2(CS$<>8__locals106.$VB$Local_theTarget) || IsSelfDefence;
						try
						{
							int num25;
							if (list.Count > 0 && !flag4 && !theWeapon.IsMobileDecoy)
							{
								if (CS$<>8__locals106.$VB$Local_theTarget.IsAir_Missile_Orbital_Contact)
								{
									bool flag13 = false;
									foreach (WeaponSalvo item9 in list)
									{
										if (item9.int_1 == theWeapon.DBID)
										{
											flag13 = true;
											break;
										}
									}
									if (flag13 && !flag12)
									{
										continue;
									}
								}
								Doctrine doctrine9 = myUnit.Doctrine;
								Doctrine doctrine10 = myUnit.Doctrine;
								Scenario parentScen6 = myUnit.ParentScen;
								Weapon theWeapon6 = theWeapon;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType6 = wRA_WeaponTargetType;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num12 = null;
								float? num16 = doctrine9.WRA_SelfDefenceRange_AnyTargetType(doctrine10, parentScen6, theWeapon6, selectedNodeTargetType6, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedFiringRange, ref num12);
								num12 = num16;
								if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() == -99f)) == true)
								{
									num16 = (int)Math.Round(num24);
								}
								num12 = num16;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 0f) : ((bool?)null)) == true)
								{
									num25 = 0;
									goto IL_2208;
								}
								num12 = num16;
								bool? flag6 = (num12.HasValue ? new bool?(num12.GetValueOrDefault() > 0f) : ((bool?)null));
								if ((flag6 ?? true) && ((!(num16.HasValue & num8.HasValue)) ? ((bool?)null) : new bool?(num16.GetValueOrDefault() < num8.GetValueOrDefault())) == true && flag6.HasValue)
								{
									num25 = 0;
									goto IL_2208;
								}
							}
							goto end_IL_2034;
							IL_2208:
							bool flag14 = (byte)num25 != 0;
							foreach (WeaponSalvo item10 in list)
							{
								if (item10.int_1 != theWeapon.DBID || item10.ShootersList.Length >= item10.MaxNumberOfShooters)
								{
									continue;
								}
								int num26;
								if (item10.MaxNumberOfWeapons != int.MaxValue)
								{
									if (item10.MaxNumberOfWeapons <= item10.WpnQuantityAssigned)
									{
										continue;
									}
									num26 = 1;
								}
								else
								{
									num26 = 1;
								}
								flag14 = (byte)num26 != 0;
								break;
							}
							if (flag12 && !flag14)
							{
								list = new List<WeaponSalvo>();
							}
							else if (!flag14)
							{
								continue;
							}
							end_IL_2034:;
						}
						catch (Exception ex31)
						{
							ProjectData.SetProjectError(ex31);
							Exception ex32 = ex31;
							ex32?.Data.Add("Error at 321354687351", "");
							GameGeneral.WriteExceptionsToLog(ex32);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						goto IL_22dd;
						IL_22dd:
						try
						{
							if (list.Count > 0)
							{
								bool flag15 = false;
								foreach (WeaponSalvo item11 in list)
								{
									if (item11.int_1 != theWeapon.DBID)
									{
										continue;
									}
									if (item11.WpnQuantityAssigned >= item11.MaxNumberOfWeapons && item11.MaxNumberOfWeapons != int.MaxValue)
									{
										flag15 = true;
									}
									if (!flag15)
									{
										WeaponSalvo.Shooter[] shootersList2 = item11.ShootersList;
										foreach (WeaponSalvo.Shooter shooter in shootersList2)
										{
											if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
											{
												flag15 = true;
												break;
											}
										}
									}
									if (!flag15 && !GenerateFiringProposal && item11.ShootersList.Length < item11.MaxNumberOfShooters)
									{
										theSalvo = item11;
										break;
									}
								}
								if (flag15)
								{
									continue;
								}
							}
						}
						catch (Exception ex33)
						{
							ProjectData.SetProjectError(ex33);
							Exception ex34 = ex33;
							ex34?.Data.Add("Error at 35478413241", "");
							GameGeneral.WriteExceptionsToLog(ex34);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						bool flag16 = false;
						try
						{
							if (theWeapon.IsWeaponPallet)
							{
								if (theWeapon.WeaponWeapons.Count == 0)
								{
									theWeapon.InitializeWeaponWeaponsPallet();
								}
								foreach (WeaponRec weaponWeapon2 in theWeapon.WeaponWeapons)
								{
									Weapon theWeapon7 = weaponWeapon2.get_ReferenceWeapon(myUnit.ParentScen);
									ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
									Contact theTarget4 = CS$<>8__locals106.$VB$Local_theTarget;
									Sensor SuitableDirectorSensor = null;
									if (weaponry2.CanThisWeaponEngageThisTarget(theWeapon7, theTarget4, ref ASL_atFiringUnit, IsManual, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == WeaponPrefireChecklistEvaluation.OK)
									{
										flag16 = true;
										break;
									}
								}
								if (flag16)
								{
									goto IL_24d6;
								}
							}
							else
							{
								ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
								Weapon theWeapon8 = theWeapon;
								Contact theTarget5 = CS$<>8__locals106.$VB$Local_theTarget;
								Sensor SuitableDirectorSensor = null;
								WeaponPrefireChecklistEvaluation item2 = weaponry3.CanThisWeaponEngageThisTarget(theWeapon8, theTarget5, ref ASL_atFiringUnit, IsManual, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum;
								if (item2 == WeaponPrefireChecklistEvaluation.OK)
								{
									goto IL_24d6;
								}
								method_1(CS$<>8__locals106.$VB$Local_theTarget, item2);
							}
							goto end_IL_2408;
							IL_24d6:
							if (!myUnit.AI.DropTargetDueToRearwardFiringDoctrine(CS$<>8__locals106.$VB$Local_theTarget, theWeapon))
							{
								goto IL_2549;
							}
							end_IL_2408:;
						}
						catch (Exception ex35)
						{
							ProjectData.SetProjectError(ex35);
							Exception ex36 = ex35;
							ex36?.Data.Add("Error at 321135743541", "");
							GameGeneral.WriteExceptionsToLog(ex36);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_2549;
						}
						continue;
						IL_18f8:
						try
						{
							if (!dictionary_0.ContainsKey(weaponRec2.int_3))
							{
								if (theSalvo == null)
								{
									goto IL_19d2;
								}
							}
							else
							{
								int? weaponQty_Available4 = dictionary_0[weaponRec2.int_3].WeaponQty_Available;
								weaponQty_Available4 = (weaponQty_Available4.HasValue ? (weaponQty_Available4 + num9) : num9);
								dictionary_0[weaponRec2.int_3].WeaponQty_Available = weaponQty_Available4;
							}
						}
						catch (Exception ex37)
						{
							ProjectData.SetProjectError(ex37);
							Exception ex38 = ex37;
							ex38?.Data.Add("Error at 3568768735192", "");
							GameGeneral.WriteExceptionsToLog(ex38);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_19d2;
						}
						continue;
						IL_19d2:
						theWeapon = weaponRec2.get_ReferenceWeapon(myUnit.ParentScen);
						type2 = theWeapon.Type;
						try
						{
							theWeapon = ((weaponRec3 == null) ? weaponRec2.get_ReferenceWeapon(myUnit.ParentScen) : weaponRec3.get_ReferenceWeapon(myUnit.ParentScen));
							if (type2 != Weapon._WeaponType.Gun || !CS$<>8__locals106.$VB$Local_theTarget.isSurfaceOrLandContact)
							{
								goto IL_1ac1;
							}
							if (!GunStrafingSalvo.HasValue)
							{
								GunStrafingSalvo = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							}
							byte? b = (byte?)GunStrafingSalvo;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
							{
								goto IL_1ac1;
							}
							goto end_IL_19ed;
							IL_1ac1:
							if (!theWeapon.IsNominallySuitableForThisTarget(myUnit, ref CS$<>8__locals106.$VB$Local_theTarget, ref TargetIsDestroyed))
							{
								continue;
							}
							if (theWeapon.IsWeaponPallet)
							{
								if (theWeapon.WeaponWeapons.Count == 0)
								{
									theWeapon.InitializeWeaponWeaponsPallet();
								}
								foreach (WeaponRec weaponWeapon3 in theWeapon.WeaponWeapons)
								{
									Weapon theWeapon9 = weaponWeapon3.get_ReferenceWeapon(myUnit.ParentScen);
									float num28 = WeaponOuterRangeLimit(ref myUnit, ref theWeapon9, ref CS$<>8__locals106.$VB$Local_theTarget, ManualFire: false);
									if (num28 > num24)
									{
										num24 = num28;
									}
								}
							}
							else
							{
								num24 = WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ManualFire: false);
							}
							if (type2 == Weapon._WeaponType.Gun && Information.IsNothing((object)num7))
							{
								num7 = Module_Unit.RangeToUnit_Slant(myUnit, CS$<>8__locals106.$VB$Local_theTarget);
							}
							else if (!num6.HasValue)
							{
								num11 = myUnit.RangeToUnit_Horiz(CS$<>8__locals106.$VB$Local_theTarget);
								num6 = num11;
							}
							if (type2 != Weapon._WeaponType.Gun)
							{
								goto IL_1c12;
							}
							float? num12 = num7;
							if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() > num24)) != true)
							{
								goto IL_1c12;
							}
							goto end_IL_19ed;
							IL_1c12:
							num12 = num6;
							if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() > num24) : ((bool?)null)) != true)
							{
								goto IL_1d06;
							}
							if (myUnit.IsAircraft && myUnit.AI.PrimaryTarget == null)
							{
								ActiveUnit activeUnit = myUnit;
								Aircraft_AI aI = ((Aircraft)myUnit).AI;
								Aircraft theAircraft = (Aircraft)myUnit;
								activeUnit.DesiredAltitude = aI.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
								if (!myUnit.IsGroupWingman())
								{
									myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing);
								}
							}
							end_IL_19ed:;
						}
						catch (Exception ex39)
						{
							ProjectData.SetProjectError(ex39);
							Exception ex40 = ex39;
							ex40?.Data.Add("Error at 14155112451", "");
							GameGeneral.WriteExceptionsToLog(ex40);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_1d06;
						}
					}
				}
			}
			else
			{
				try
				{
					if (list.Count > 0)
					{
						foreach (WeaponSalvo item12 in list)
						{
							if (item12.int_1 != CS$<>8__locals106.$VB$Local_theWeaponDBID)
							{
								continue;
							}
							int num29;
							if (item12.WpnQuantityAssigned < item12.MaxNumberOfWeapons)
							{
								num29 = 0;
							}
							else
							{
								if (item12.MaxNumberOfWeapons != int.MaxValue)
								{
									break;
								}
								num29 = 0;
							}
							bool flag17 = (byte)num29 != 0;
							bool flag18 = false;
							WeaponSalvo.Shooter[] shootersList3 = item12.ShootersList;
							foreach (WeaponSalvo.Shooter shooter in shootersList3)
							{
								if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) != 0)
								{
									if ((myUnit.IsFacility || myUnit.IsMobileGroundUnit) && myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.ContainsKey(shooter.ShooterObjectID))
									{
										flag18 = true;
										break;
									}
									continue;
								}
								flag17 = true;
								break;
							}
							if (!flag17 && !GenerateFiringProposal && (item12.ShootersList.Length < item12.MaxNumberOfShooters || supplementingShootersOutOfAmmo || flag18))
							{
								theSalvo = item12;
								break;
							}
						}
					}
				}
				catch (Exception ex41)
				{
					ProjectData.SetProjectError(ex41);
					Exception ex42 = ex41;
					ex42?.Data.Add("Error at 13124154555", "");
					GameGeneral.WriteExceptionsToLog(ex42);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (list_2.Count == 0)
			{
				bool flag19 = method_2(CS$<>8__locals106.$VB$Local_theTarget) || IsSelfDefence;
				float num32 = default(float);
				foreach (Mount mount2 in myUnit.Mounts)
				{
					if (!IsManual && (mount2.TimeToFire != 0f || mount2.MountMagazine.TimeToFire != 0f))
					{
						continue;
					}
					foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
					{
						if (theSalvo != null)
						{
							if (mountWeapon2.int_3 != theSalvo.int_1)
							{
								continue;
							}
						}
						else if (IsManual && mountWeapon2.int_3 != CS$<>8__locals106.$VB$Local_theWeaponDBID)
						{
							continue;
						}
						mountWeapon2.ParentMount = mount2;
						if (!IsManual)
						{
							try
							{
								if (mount2.Status != PlatformComponent._ComponentStatus.Operational || mountWeapon2.TimeToFire != 0f || mountWeapon2.CurrentLoad == 0)
								{
									continue;
								}
								num9 = mountWeapon2.CurrentLoad;
								if (mount2.MountMagazine.Weapons.Count > 0)
								{
									bool flag20 = false;
									if (mount2.MountMagazine.Weapons.Count > 1)
									{
										foreach (WeaponRec mountWeapon3 in mount2.MountWeapons)
										{
											if (mountWeapon3.get_HasManualReloadPriority(mount2))
											{
												flag20 = true;
												break;
											}
										}
									}
									if (!flag20)
									{
										num9 += HowManyOfThisWeaponOnMountMagazine(mount2, mountWeapon2.int_3);
									}
								}
								int? TargetType_InheritedWeaponQty = num9;
								if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() == 0) : ((bool?)null)) == true)
								{
									continue;
								}
								if (dictionary_0.ContainsKey(mountWeapon2.int_3))
								{
									int? weaponQty_Available5 = dictionary_0[mountWeapon2.int_3].WeaponQty_Available;
									weaponQty_Available5 = (weaponQty_Available5.HasValue ? (weaponQty_Available5 + num9) : num9);
									dictionary_0[mountWeapon2.int_3].WeaponQty_Available = weaponQty_Available5;
									continue;
								}
								if (theSalvo == null)
								{
									goto IL_2a68;
								}
								list_2.Add(mountWeapon2);
								WeaponSalvoWpnQty value5 = new WeaponSalvoWpnQty(num13, num9);
								dictionary_0.Add(mountWeapon2.int_3, value5);
							}
							catch (Exception ex43)
							{
								ProjectData.SetProjectError(ex43);
								Exception ex44 = ex43;
								ex44?.Data.Add("Error at 416578788633", "");
								GameGeneral.WriteExceptionsToLog(ex44);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								goto IL_2a68;
							}
							continue;
						}
						goto IL_37dc;
						IL_3560:
						if (list.Count > 0)
						{
							try
							{
								bool flag21 = false;
								foreach (WeaponSalvo item13 in list)
								{
									if (item13.int_1 != theWeapon.DBID)
									{
										continue;
									}
									if (item13.WpnQuantityAssigned >= item13.MaxNumberOfWeapons && item13.MaxNumberOfWeapons != int.MaxValue)
									{
										flag21 = true;
									}
									if (!flag21)
									{
										WeaponSalvo.Shooter[] shootersList4 = item13.ShootersList;
										foreach (WeaponSalvo.Shooter shooter in shootersList4)
										{
											if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
											{
												flag21 = true;
												break;
											}
										}
									}
									if (!flag21 && !GenerateFiringProposal && item13.ShootersList.Length < item13.MaxNumberOfShooters)
									{
										theSalvo = item13;
										break;
									}
								}
								if (!flag21)
								{
									goto IL_3689;
								}
							}
							catch (Exception ex45)
							{
								ProjectData.SetProjectError(ex45);
								Exception ex46 = ex45;
								ex46?.Data.Add("Error at 245252625257", "");
								GameGeneral.WriteExceptionsToLog(ex46);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								goto IL_3689;
							}
							continue;
						}
						goto IL_3689;
						IL_37dc:
						list_2.Add(mountWeapon2);
						if (!IsManual)
						{
							WeaponSalvoWpnQty value6 = new WeaponSalvoWpnQty(num13, num9);
							dictionary_0.Add(mountWeapon2.int_3, value6);
							continue;
						}
						break;
						IL_2cf4:
						if (myUnit.Doctrine.WRA_RelevantWeapon(ref theWeapon))
						{
							try
							{
								wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
								Doctrine doctrine11 = myUnit.Doctrine;
								Scenario parentScen7 = myUnit.ParentScen;
								Weapon theWeapon10 = theWeapon;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType7 = wRA_WeaponTargetType;
								int? TargetType_InheritedWeaponQty = null;
								int? TargetType_UnspecifiedWeaponQty = null;
								num13 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine11, parentScen7, theWeapon10, selectedNodeTargetType7, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
								TargetType_UnspecifiedWeaponQty = num13;
								if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0)) == true)
								{
									continue;
								}
								TargetType_UnspecifiedWeaponQty = num13;
								if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty == -99) : ((bool?)null)) == true)
								{
									num13 = int.MaxValue;
								}
								if (!num13.HasValue)
								{
									continue;
								}
								Doctrine doctrine12 = myUnit.Doctrine;
								Doctrine doctrine13 = myUnit.Doctrine;
								Scenario parentScen8 = myUnit.ParentScen;
								int dBID4 = theWeapon.DBID;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType8 = wRA_WeaponTargetType;
								float? num12 = null;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num14 = doctrine12.WRA_FiringRange_AnyTargetType(doctrine13, parentScen8, dBID4, selectedNodeTargetType8, FindInheritedValuesOnly: false, ref num12, ref TargetType_UnspecifiedFiringRange);
								if (!num14.HasValue)
								{
									num14 = (float)Doctrine.WRA_FiringRange_GetDefaultFiringRange(myUnit.ParentScen, theWeapon.DBID, wRA_WeaponTargetType);
								}
								TargetType_UnspecifiedFiringRange = num14;
								if ((TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f) : ((bool?)null)) == true)
								{
									continue;
								}
								TargetType_UnspecifiedFiringRange = num14;
								num12 = TargetType_UnspecifiedFiringRange;
								if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() == -99f)) != true)
								{
									num12 = TargetType_UnspecifiedFiringRange;
									if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() == -97f)) == true)
									{
										num32 = theWeapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: false, myUnit.Doctrine, IsManual) * 0.75f;
									}
									else
									{
										num12 = TargetType_UnspecifiedFiringRange;
										if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == -96f) : ((bool?)null)) == true)
										{
											num32 = theWeapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: false, myUnit.Doctrine, IsManual) * 0.5f;
										}
										else
										{
											num12 = TargetType_UnspecifiedFiringRange;
											if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == -95f) : ((bool?)null)) != true)
											{
												num12 = TargetType_UnspecifiedFiringRange;
												if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == -102f) : ((bool?)null)) != true)
												{
													if (num14.HasValue)
													{
														num12 = num14;
														if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() > 0f) : ((bool?)null)) == true)
														{
															num32 = num14.Value;
														}
													}
												}
												else
												{
													(int, string, bool) tuple = (theWeapon.DBID, CS$<>8__locals106.$VB$Local_theTarget.ObjectID, mount2?.IsVLS ?? false);
													if (DLZ_ResultsCache == null)
													{
														DLZ_ResultsCache = new TDictionary<(int, string, bool), (DLZResultEnum, float)>();
													}
													if (DLZ_ChecksRequested == null)
													{
														DLZ_ChecksRequested = new HashSet<(int, string, bool)>();
													}
													DLZ_ChecksRequested.Add(tuple);
													if (!DLZ_ResultsCache.TryGetValue(tuple, out var value7))
													{
														value7 = method_10(CS$<>8__locals106.$VB$Local_theTarget, theWeapon, mount2?.IsVLS ?? false, HumanFeedbackNeeded: false);
														DLZ_ResultsCache.AddIfNotExistsElseUpdate(tuple, value7);
													}
													if (value7.Item1 != DLZResultEnum.Success)
													{
														return false;
													}
													num32 = (float)Math.Round(Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals106.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2);
												}
											}
											else
											{
												num32 = theWeapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: false, myUnit.Doctrine, IsManual) * 0.25f;
											}
										}
									}
								}
								num12 = num14;
								bool? flag22 = ((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() == -99f));
								bool? flag6 = (!flag22) ?? flag22;
								if (!((!flag6) ?? false) && ((!num8.HasValue) ? ((bool?)null) : new bool?(num32 < num8.GetValueOrDefault())) == true && flag6.HasValue)
								{
									continue;
								}
								if (IsSelfDefence || (list.Count > 0 && !flag4 && !theWeapon.IsMobileDecoy))
								{
									if (!CS$<>8__locals106.$VB$Local_theTarget.IsAir_Missile_Orbital_Contact)
									{
										goto IL_32a3;
									}
									bool flag23 = false;
									int num33 = list.Count - 1;
									for (int num34 = 0; num34 <= num33; num34++)
									{
										try
										{
											WeaponSalvo weaponSalvo2 = list[num34];
											if (weaponSalvo2.int_1 == theWeapon.DBID && weaponSalvo2.ShootersList.Count() > 0)
											{
												flag23 = true;
												break;
											}
										}
										catch (Exception projectError4)
										{
											ProjectData.SetProjectError(projectError4);
											ProjectData.ClearProjectError();
										}
									}
									if (!flag23 || flag19)
									{
										goto IL_32a3;
									}
									continue;
								}
								goto IL_3560;
								IL_32a3:
								Doctrine doctrine14 = myUnit.Doctrine;
								Doctrine doctrine15 = myUnit.Doctrine;
								Scenario parentScen9 = myUnit.ParentScen;
								Weapon theWeapon11 = theWeapon;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType9 = wRA_WeaponTargetType;
								num12 = null;
								float? TargetType_UnspecifiedSelfDefenceRange = null;
								float? num16 = doctrine14.WRA_SelfDefenceRange_AnyTargetType(doctrine15, parentScen9, theWeapon11, selectedNodeTargetType9, FindInheritedValuesOnly: false, ref num12, ref TargetType_UnspecifiedSelfDefenceRange);
								TargetType_UnspecifiedSelfDefenceRange = num16;
								if (((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() == -99f)) == true)
								{
									num16 = (int)Math.Round(num32);
								}
								if (!IsSelfDefence)
								{
									goto IL_3389;
								}
								if (num16.HasValue && num16.Value != 0f)
								{
									float value2 = num16.Value;
									if ((num8.HasValue ? new bool?(value2 < num8.GetValueOrDefault()) : ((bool?)null)) != true)
									{
										goto IL_3389;
									}
								}
								goto end_IL_2d0c;
								IL_3389:
								TargetType_UnspecifiedSelfDefenceRange = num16;
								if (((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() == 0f)) == true)
								{
									goto IL_346f;
								}
								TargetType_UnspecifiedSelfDefenceRange = num16;
								flag6 = ((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() > 0f));
								if ((flag6 ?? true) && ((!(num16.HasValue & num8.HasValue)) ? ((bool?)null) : new bool?(num16.GetValueOrDefault() < num8.GetValueOrDefault())) == true && flag6.HasValue)
								{
									goto IL_346f;
								}
								if (flag3 && (theWeapon.IsGuidedWeapon() || theWeapon.IsTorpedo) && !IsSelfDefence)
								{
									continue;
								}
								goto IL_3560;
								IL_346f:
								if (!(!flag2 || flag19) || (!theWeapon.IsGuidedWeapon() && !theWeapon.IsTorpedo))
								{
									bool flag24 = false;
									foreach (WeaponSalvo item14 in list)
									{
										if (item14.int_1 != theWeapon.DBID || !(item14.ShootersList.Length < item14.MaxNumberOfShooters || supplementingShootersOutOfAmmo))
										{
											continue;
										}
										int num35;
										if (item14.MaxNumberOfWeapons != int.MaxValue)
										{
											if (item14.MaxNumberOfWeapons <= item14.WpnQuantityAssigned)
											{
												continue;
											}
											num35 = 1;
										}
										else
										{
											num35 = 1;
										}
										flag24 = (byte)num35 != 0;
										break;
									}
									if (!flag24)
									{
										continue;
									}
									goto IL_3560;
								}
								goto IL_3560;
								end_IL_2d0c:;
							}
							catch (Exception ex47)
							{
								ProjectData.SetProjectError(ex47);
								Exception ex48 = ex47;
								ex48?.Data.Add("Error at 52755545544541", "");
								GameGeneral.WriteExceptionsToLog(ex48);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								goto IL_3560;
							}
							continue;
						}
						goto IL_3560;
						IL_3689:
						float num36 = 0f;
						try
						{
							num36 = theWeapon.CurrentHeading;
							ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
							Weapon theWeapon12 = theWeapon;
							Contact theTarget6 = CS$<>8__locals106.$VB$Local_theTarget;
							Sensor SuitableDirectorSensor = null;
							WeaponPrefireChecklistEvaluation item3 = weaponry4.CanThisWeaponEngageThisTarget(theWeapon12, theTarget6, ref ASL_atFiringUnit, IsManual, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, mount2, ref SuitableDirectorSensor).EvaluationEnum;
							if (num36 != 0f)
							{
								theWeapon.CurrentHeading = num36;
							}
							if (item3 != WeaponPrefireChecklistEvaluation.OK)
							{
								method_1(CS$<>8__locals106.$VB$Local_theTarget, item3);
							}
							else
							{
								if (myUnit.AI.DropTargetDueToRearwardFiringDoctrine(CS$<>8__locals106.$VB$Local_theTarget, theWeapon))
								{
									continue;
								}
								if (!flag5 && theWeapon.IsGuidedWeapon())
								{
									int num37;
									if (!theWeapon.Flags.TerminalIllumination)
									{
										if (theWeapon.Flags.IlluminateAtLaunch)
										{
											num37 = 1;
										}
										else
										{
											if (theWeapon.Comms_ReadOnly.Count() <= 0)
											{
												goto IL_3749;
											}
											num37 = 1;
										}
									}
									else
									{
										num37 = 1;
									}
									flag5 = (byte)num37 != 0;
									result = true;
								}
								goto IL_3749;
							}
							goto end_IL_3690;
							IL_3749:
							float? TargetType_UnspecifiedSelfDefenceRange = num8;
							bool? flag6 = ((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() < 5f));
							if ((flag6 ?? true) && !flag5 && flag6.HasValue)
							{
								result = false;
							}
							goto IL_37dc;
							end_IL_3690:;
						}
						catch (Exception ex49)
						{
							ProjectData.SetProjectError(ex49);
							Exception ex50 = ex49;
							ex50?.Data.Add("Error at 354321687", "");
							GameGeneral.WriteExceptionsToLog(ex50);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_37dc;
						}
						continue;
						IL_2a68:
						theWeapon = mountWeapon2.get_ReferenceWeapon(myUnit.ParentScen);
						Weapon._WeaponType type3 = theWeapon.Type;
						theWeapon.FiringParent = myUnit;
						try
						{
							if (myUnit.IsAircraft && type3 == Weapon._WeaponType.Gun && CS$<>8__locals106.$VB$Local_theTarget.isSurfaceOrLandContact)
							{
								if (!GunStrafingSalvo.HasValue)
								{
									GunStrafingSalvo = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
								}
								byte? b = (byte?)GunStrafingSalvo;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
								{
									continue;
								}
							}
						}
						catch (Exception ex51)
						{
							ProjectData.SetProjectError(ex51);
							Exception ex52 = ex51;
							ex52?.Data.Add("Error at 134124131", "");
							GameGeneral.WriteExceptionsToLog(ex52);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!theWeapon.IsNominallySuitableForThisTarget(myUnit, ref CS$<>8__locals106.$VB$Local_theTarget, ref TargetIsDestroyed))
							{
								continue;
							}
							num32 = WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ManualFire: false);
							if (type3 == Weapon._WeaponType.Gun && Information.IsNothing((object)num7))
							{
								num7 = Module_Unit.RangeToUnit_Slant(myUnit, CS$<>8__locals106.$VB$Local_theTarget);
							}
							else if (!num6.HasValue)
							{
								if (!num11.HasValue)
								{
									num11 = myUnit.RangeToUnit_Horiz(CS$<>8__locals106.$VB$Local_theTarget);
								}
								num6 = num11;
							}
							if (type3 != Weapon._WeaponType.Gun)
							{
								goto IL_2c67;
							}
							float? num12 = num7;
							if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12.GetValueOrDefault() > num32)) != true)
							{
								goto IL_2c67;
							}
							goto end_IL_2b8b;
							IL_2c67:
							num12 = num6;
							if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() > num32) : ((bool?)null)) == true)
							{
								continue;
							}
							num8 = ((type3 != Weapon._WeaponType.Gun) ? num6 : num7);
							goto IL_2cf4;
							end_IL_2b8b:;
						}
						catch (Exception ex53)
						{
							ProjectData.SetProjectError(ex53);
							Exception ex54 = ex53;
							ex54?.Data.Add("Error at 14155112451", "");
							GameGeneral.WriteExceptionsToLog(ex54);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_2cf4;
						}
					}
					if (IsManual && list_2.Count > 0)
					{
						break;
					}
				}
			}
			try
			{
				if (!IsManual && myUnit.IsAircraft && GunStrafingSalvo.HasValue)
				{
					byte? b = (byte?)GunStrafingSalvo;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true && list_2.Count > 1 && CS$<>8__locals106.$VB$Local_theTarget.isSurfaceOrLandContact)
					{
						PooledList<Weapon> pooledList2 = SuitableWeaponsForThisTarget(CS$<>8__locals106.$VB$Local_theTarget, ref GunStrafingSalvo);
						if (pooledList2 != null)
						{
							if ((from result5 in pooledList2
								select (result5) into weapon6
								where weapon6.Type != Weapon._WeaponType.Gun
								select weapon6).Count() > 0)
							{
								List<WeaponRec> list3 = new List<WeaponRec>(list_2);
								foreach (WeaponRec item15 in list3)
								{
									if (item15.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
									{
										list_2.Remove(item15);
									}
								}
							}
							pooledList2.Dispose();
						}
					}
				}
			}
			catch (Exception ex55)
			{
				ProjectData.SetProjectError(ex55);
				Exception ex56 = ex55;
				ex56?.Data.Add("Error at 52757274724", "");
				GameGeneral.WriteExceptionsToLog(ex56);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			theWeapon = null;
			int? theShooterQty = default(int?);
			try
			{
				if (list_2.Count > 0)
				{
					if (IsManual)
					{
						weaponRec = list_2[0];
						theWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
					}
					else
					{
						weaponRec = ((list_2.Count <= 1) ? list_2[0] : list_2.Select([SpecialName] (WeaponRec theRec) => theRec).OrderByDescending([SpecialName] (WeaponRec theRec) =>
						{
							ActiveUnit_Weaponry activeUnit_Weaponry = CS$<>8__locals106.$VB$Me;
							Weapon theWeapon15 = theRec.get_ReferenceWeapon(CS$<>8__locals106.$VB$Me.myUnit.ParentScen);
							return activeUnit_Weaponry.WeaponSuitabilityForThisTarget(ref theWeapon15, ref CS$<>8__locals106.$VB$Local_theTarget, CheckIfWithinRange: false);
						}).ThenBy([SpecialName] (WeaponRec theRec) => theRec.get_ReferenceWeapon(CS$<>8__locals106.$VB$Me.myUnit.ParentScen).get_MaxRangeForThisTarget(CS$<>8__locals106.$VB$Me.myUnit, CS$<>8__locals106.$VB$Local_theTarget, CheckWRA: true, CS$<>8__locals106.$VB$Me.myUnit.Doctrine, ManualFire: false))
							.ElementAtOrDefault(0));
						theWeapon = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
						int? TargetType_InheritedWeaponQty;
						if (!theShooterQty.HasValue)
						{
							wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
							Doctrine doctrine16 = myUnit.Doctrine;
							Scenario parentScen10 = myUnit.ParentScen;
							Weapon theWeapon13 = theWeapon;
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType10 = wRA_WeaponTargetType;
							int? TargetType_UnspecifiedWeaponQty = null;
							TargetType_InheritedWeaponQty = null;
							theShooterQty = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine16, parentScen10, theWeapon13, selectedNodeTargetType10, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedWeaponQty, ref TargetType_InheritedWeaponQty);
						}
						TargetType_InheritedWeaponQty = theShooterQty;
						if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty == -99) : ((bool?)null)) == true)
						{
							theShooterQty = int.MaxValue;
						}
					}
				}
			}
			catch (Exception ex57)
			{
				ProjectData.SetProjectError(ex57);
				Exception ex58 = ex57;
				ex58?.Data.Add("Error at 12326226625", "");
				GameGeneral.WriteExceptionsToLog(ex58);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (weaponRec != null)
			{
				try
				{
					if (IsManual)
					{
						num13 = theWeaponQty;
						num9 = theWeaponQty;
					}
					else
					{
						num13 = dictionary_0[weaponRec.int_3].WeaponQty_ToFire;
						num9 = HowManyOfThisWeapon(weaponRec.int_3);
						int num38 = method_15(weaponRec.int_3);
						num9 = Math.Max(0, num9.Value - num38);
						int? TargetType_InheritedWeaponQty = num13;
						bool? flag6 = ((!TargetType_InheritedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() < 0));
						if (flag6 ?? true)
						{
							TargetType_InheritedWeaponQty = num13;
							bool? flag22 = (TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty == -99) : ((bool?)null));
							if (((!flag22) ?? flag22) == true && flag6.HasValue)
							{
								num13 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num13, ref myUnit, ref CS$<>8__locals106.$VB$Local_theTarget, ref theWeapon);
							}
						}
						TargetType_InheritedWeaponQty = num13;
						if (((!TargetType_InheritedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedWeaponQty.GetValueOrDefault() < 1)) == true)
						{
							num13 = 1;
						}
						flag6 = ((!(num9.HasValue & num13.HasValue)) ? ((bool?)null) : new bool?(num9.GetValueOrDefault() > num13.GetValueOrDefault()));
						if (flag6 ?? true)
						{
							TargetType_InheritedWeaponQty = num13;
							bool? flag22 = ((!TargetType_InheritedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedWeaponQty == -99));
							if (((!flag22) ?? flag22) == true && flag6.HasValue)
							{
								num9 = num13;
							}
						}
					}
				}
				catch (Exception ex59)
				{
					ProjectData.SetProjectError(ex59);
					Exception ex60 = ex59;
					ex60?.Data.Add("Error at 1546141341445555", "");
					GameGeneral.WriteExceptionsToLog(ex60);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (!IsManual)
				{
					try
					{
						if (weaponRec.CurrentLoad != 0)
						{
							int result4;
							if (CreatingSalvoForPallettizedWeapon && weaponRec4 != null && weaponRec3 != null)
							{
								Weapon theParentWeapon = weaponRec4.get_ReferenceWeapon(myUnit.ParentScen);
								Weapon theSubWeapon = weaponRec3.get_ReferenceWeapon(myUnit.ParentScen);
								CreateSalvo_PalletizedWeapons(CS$<>8__locals106.$VB$Local_theTarget, theParentWeapon, theSubWeapon, num13.Value, IsManual, SalvoTag);
								result4 = 1;
							}
							else if (theSalvo != null)
							{
								myUnit.get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, theSalvo.MaxNumberOfWeapons, 0, num9, IsManual, ref myUnit.ObjectID);
								result4 = 1;
							}
							else if (!GenerateFiringProposal)
							{
								WeaponSalvo weaponSalvo3 = myUnit.get_UnitSide(SetSideOnly: false).AssignSalvoToTarget(myUnit.ParentScen, ref theWeapon, ref CS$<>8__locals106.$VB$Local_theTarget, num13, 0, num9, IsManual, ref myUnit.ObjectID, ref theShooterQty, theScheduledTime, DateTime.MinValue);
								if (weaponSalvo3 != null)
								{
									weaponSalvo3.Tag = SalvoTag;
									result4 = 1;
								}
								else
								{
									result4 = 1;
								}
							}
							else
							{
								DateTime theETA = RetrieveWeaponETA(CS$<>8__locals106.$VB$Local_theTarget, theWeapon);
								myUnit.get_UnitSide(SetSideOnly: false).AddFiringProposal(myUnit, theWeapon, num13.Value, num9.Value, CS$<>8__locals106.$VB$Local_theTarget, theETA);
								result4 = 1;
							}
							return (byte)result4 != 0;
						}
						return false;
					}
					catch (Exception ex61)
					{
						ProjectData.SetProjectError(ex61);
						Exception ex62 = ex61;
						ex62?.Data.Add("Error at 2986724242", "");
						GameGeneral.WriteExceptionsToLog(ex62);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else if (theSalvo == null)
				{
					try
					{
						if (CreatingSalvoForPallettizedWeapon && weaponRec4 != null && weaponRec3 != null)
						{
							Weapon theParentWeapon2 = weaponRec4.get_ReferenceWeapon(myUnit.ParentScen);
							Weapon theSubWeapon2 = weaponRec3.get_ReferenceWeapon(myUnit.ParentScen);
							CreateSalvo_PalletizedWeapons(CS$<>8__locals106.$VB$Local_theTarget, theParentWeapon2, theSubWeapon2, num13.Value, IsManual, SalvoTag);
						}
						else
						{
							Side side = myUnit.get_UnitSide(SetSideOnly: false);
							Scenario parentScen11 = myUnit.ParentScen;
							Weapon theWeapon14 = weaponRec.get_ReferenceWeapon(myUnit.ParentScen);
							WeaponSalvo weaponSalvo4 = side.AssignSalvoToTarget(parentScen11, ref theWeapon14, ref CS$<>8__locals106.$VB$Local_theTarget, num13, 0, num9, IsManual, ref myUnit.ObjectID, ref theShooterQty, theScheduledTime, DateTime.MinValue);
							if (weaponSalvo4 != null)
							{
								weaponSalvo4.Tag = SalvoTag;
								return true;
							}
						}
						if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							myUnit.Navigator.ClearPlottedCourse();
						}
					}
					catch (Exception ex63)
					{
						ProjectData.SetProjectError(ex63);
						Exception ex64 = ex63;
						ex64?.Data.Add("Error at 57527525285254", "");
						GameGeneral.WriteExceptionsToLog(ex64);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						int value8 = num13.Value;
						int wpnQuantityAssigned = theSalvo.WpnQuantityAssigned;
						if (((!num13.HasValue) ? ((bool?)null) : new bool?(wpnQuantityAssigned < num13.GetValueOrDefault())) == true || IsManual)
						{
							myUnit.get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, value8, 0, num9, IsManual, ref myUnit.ObjectID);
							if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
							{
								if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
								{
									weaponRec.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
								}
								foreach (WeaponRec weaponWeapon4 in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
								{
									CreateSalvo(CS$<>8__locals106.$VB$Local_theTarget, weaponWeapon4.get_ReferenceWeapon(myUnit.ParentScen).DBID, num13.Value * weaponWeapon4.CurrentLoad, IsManual, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: true, RebuildSalvoCache: false);
								}
							}
						}
						return result;
					}
					catch (Exception ex65)
					{
						ProjectData.SetProjectError(ex65);
						Exception ex66 = ex65;
						ex66?.Data.Add("Error at 4177418", "");
						GameGeneral.WriteExceptionsToLog(ex66);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			return false;
		}
		case Contact_Base.ContactType.Decoy_Surface:
		case Contact_Base.ContactType.Decoy_Land:
		case Contact_Base.ContactType.Decoy_Sub:
			return false;
		}
	}

	private void method_1(Contact contact_0, WeaponPrefireChecklistEvaluation weaponPrefireChecklistEvaluation_0)
	{
		switch (weaponPrefireChecklistEvaluation_0)
		{
		case WeaponPrefireChecklistEvaluation.CannotIlluminate_InsufficientReflectionOrBlocked:
			if (myUnit.IsAircraft && !((Aircraft)myUnit).Kinematics.DesiredAltitudeOverride)
			{
				if (((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 2f;
				}
				else
				{
					myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 2f;
				}
			}
			break;
		case WeaponPrefireChecklistEvaluation.OutsideBoresightLimits:
			if (myUnit.IsAircraft && myUnit.AI.PrimaryTarget == null)
			{
				ActiveUnit activeUnit = myUnit;
				Aircraft_AI aI = ((Aircraft)myUnit).AI;
				Aircraft theAircraft = (Aircraft)myUnit;
				bool MissionProfileAttackIngressAltitudeTerrainFollowing = default(bool);
				activeUnit.DesiredAltitude = aI.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
				if (!myUnit.IsGroupWingman())
				{
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing);
				}
			}
			break;
		case WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC:
			if (myUnit.AI.PrimaryTarget == null)
			{
				myUnit.AI.PrimaryTarget = contact_0;
			}
			break;
		}
	}

	private bool method_2(Contact contact_0)
	{
		if (bool_0)
		{
			return true;
		}
		bool result = false;
		if (bool_1 && contact_0.ActualUnit != null && !contact_0.ActualUnit.IsAircraft && myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
		{
			Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
			if (!strike.SpecificTargets.Contains(contact_0) && !strike.SpecificTargets.Contains(contact_0.ActualUnit))
			{
				if (myUnit.AI.PrimaryTarget != null && Operators.CompareString(myUnit.AI.PrimaryTarget.ObjectID, contact_0.ObjectID, false) == 0)
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
		}
		return result;
	}

	internal DateTime RetrieveWeaponETA(Contact theTarget, Weapon theWeapon)
	{
		DateTime dateTime;
		if (ETA_ResultsCache != null && ETA_ResultsCache.Count > 0 && myUnit != null)
		{
			KeyValuePair<(ActiveUnit, int, ScenarioObject), double> keyValuePair = ETA_ResultsCache.Where([SpecialName] (KeyValuePair<(ActiveUnit, int, ScenarioObject), double> theRes) => (Operators.CompareString(theRes.Key.Item1.ObjectID, myUnit.ObjectID, false) == 0) & (theRes.Key.Item2 == theWeapon.DBID) & (Operators.CompareString(theRes.Key.Item3.ObjectID, theTarget.ObjectID, false) == 0)).FirstOrDefault();
			dateTime = ((keyValuePair.Value == 0.0) ? method_3(theTarget, theWeapon) : myUnit.ParentScen.Time.AddSeconds(keyValuePair.Value));
		}
		else
		{
			dateTime = method_3(theTarget, theWeapon);
		}
		if (DateTime.Compare(dateTime, DateTime.MinValue) == 0 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return dateTime;
	}

	internal DateTime method_3(Contact theTarget, Weapon theWeapon)
	{
		double num = 0.0;
		double value = 0.0;
		DateTime time = default(DateTime);
		if (!(theWeapon.SupportsWaypoints & !theWeapon.IsBallisticMissile))
		{
			if (!theWeapon.IsUnguidedBallisticWeapon)
			{
				if (!theWeapon.IsHGV && !theWeapon.method_16())
				{
					if (theWeapon.IsBallisticMissile)
					{
						bool high = !theWeapon.Flags.DepressedBallisticTrajectory;
						BallisticTrajectory ballisticTrajectory = BallisticTrajectory.Factory(myUnit, theTarget, Math.Max(theWeapon.MaxSurfaceRange, theWeapon.MaxLandRange), high, 60.0);
						bool flag = false;
						if (ballisticTrajectory.CurrentRecord.Radius_km <= (double)(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f) + 6371.0)
						{
							flag = true;
						}
						while (flag | ((ballisticTrajectory.CurrentRecord.Radius_km > (double)(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f) + 6371.0) & (ballisticTrajectory.CurrentRecord.Phase != 2)))
						{
							ballisticTrajectory.CurrentRecord = ballisticTrajectory.NextRecord;
							ballisticTrajectory.NextRecord = BallisticTrajectory.ComputeNextRecord(ballisticTrajectory, ballisticTrajectory.CurrentRecord, 1.0);
							if (ballisticTrajectory.CurrentRecord.Radius_km > (double)(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f) + 6371.0)
							{
								flag = false;
							}
						}
						time = myUnit.ParentScen.Time;
						value = ballisticTrajectory.NextRecord.Time_s;
						time = time.AddSeconds(value);
					}
					else if (theWeapon.IsGuidedWeapon())
					{
						time = myUnit.ParentScen.Time;
						float num2 = method_4(theWeapon, theTarget, DogLegCalculation: false);
						time = time.AddSeconds(num2);
					}
					else if (!theWeapon.IsContactExplosive)
					{
						if (!theWeapon.IsLaserShot && theWeapon.Type != Weapon._WeaponType.Microwave)
						{
							if (theWeapon.Type == Weapon._WeaponType.Dispenser)
							{
								value = 0.0;
								time = myUnit.ParentScen.Time;
							}
							else
							{
								num = theWeapon.MaxSpeed;
								if (num == 0.0 && theWeapon.IsGuidedProjectile)
								{
									num = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, theWeapon.MaxRange_NoTargetType, parabolicTrajectory: true);
								}
								if (num != 0.0)
								{
									time = myUnit.ParentScen.Time;
									value = (double)Module_Unit.RangeToUnit_Slant(myUnit, theTarget) * 1852.0 / num;
									time = time.AddSeconds(value);
								}
								else if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
						else
						{
							time = myUnit.ParentScen.Time.AddSeconds(2.0);
						}
					}
					else
					{
						num = myUnit.MaxSpeed;
						if (num != 0.0)
						{
							time = myUnit.ParentScen.Time;
							value = (double)Module_Unit.RangeToUnit_Slant(myUnit, theTarget) * 1852.0 / num;
							time = time.AddSeconds(value);
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				else
				{
					value = method_10(theTarget, theWeapon, AssumeVerticalLaunch: false, HumanFeedbackNeeded: false).Item2;
					time = myUnit.ParentScen.Time.AddSeconds(value);
				}
			}
			else
			{
				num = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, theWeapon.MaxRange_NoTargetType, parabolicTrajectory: true);
				if (num != 0.0)
				{
					time = myUnit.ParentScen.Time;
					value = (double)Module_Unit.RangeToUnit_Slant(myUnit, theTarget) * 1852.0 / num;
					time = time.AddSeconds(value);
				}
			}
			ETA_ResultsCache.TryAdd((myUnit, theWeapon.DBID, theTarget), value);
			return time;
		}
		theWeapon.FiringParent = myUnit;
		((ActiveUnit)theWeapon).set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
		theWeapon.AI.PrimaryTarget = theTarget;
		Weapon_Navigator navigator = theWeapon.Navigator;
		Waypoint[] theArray = navigator.PlottedCourse;
		ArrayExtensions.Clear(ref theArray);
		navigator.PlottedCourse = theArray;
		theWeapon.AI.PrimaryTarget = theTarget;
		value = theWeapon.Navigator.PlanComplexCourse(myUnit).ETA;
		if (value == 0.0 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		time = myUnit.ParentScen.Time.AddSeconds(value);
		ETA_ResultsCache.TryAdd((theWeapon.FiringParent, theWeapon.DBID, theTarget), value);
		return time;
	}

	internal float method_4(Weapon theWeapon, Contact theTarget, bool DogLegCalculation)
	{
		if (!DogLegCalculation)
		{
			return method_10(theTarget, theWeapon, AssumeVerticalLaunch: false, HumanFeedbackNeeded: false).Item2;
		}
		return 0f;
	}

	internal int GetMissileDefenceForContact(ref Contact theContact)
	{
		int result;
		if (theContact.ActualUnit == null)
		{
			result = 0;
		}
		else
		{
			if (theContact.ActualUnit.IsShip)
			{
				return Math.Max((int)((Ship)theContact.ActualUnit).MissileDefense, 1);
			}
			if (theContact.ActualUnit.IsFacility)
			{
				return Math.Max(((Facility)theContact.ActualUnit).MissileDefense, 1);
			}
			if (theContact.ActualUnit.IsVehicle)
			{
				return Math.Max(((Vehicle)theContact.ActualUnit).MissileDefense, 1);
			}
			result = 0;
		}
		return result;
	}

	internal PooledList<Weapon> SuitableWeaponsForThisTarget(Contact theTarget, ref Doctrine._GunStrafeGroundTargets? GunStrafingSalvo)
	{
		PooledList<Weapon> result = default(PooledList<Weapon>);
		try
		{
			List<Weapon> list = AllDistinctWeaponsAboard_Actual();
			GlobalVariables.BooleanObject TargetIsDestroyed = default(GlobalVariables.BooleanObject);
			PooledList<Weapon> pooledList = default(PooledList<Weapon>);
			foreach (Weapon item in list)
			{
				if (!item.IsNominallySuitableForThisTarget(myUnit, ref theTarget, ref TargetIsDestroyed))
				{
					continue;
				}
				if (myUnit.IsAircraft && item.Type == Weapon._WeaponType.Gun && theTarget.isSurfaceOrLandContact)
				{
					if (!GunStrafingSalvo.HasValue)
					{
						GunStrafingSalvo = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					}
					byte? b = (byte?)GunStrafingSalvo;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Weapon>(list.Count, Pools<Weapon>.Local);
						}
						pooledList.Add(item);
					}
				}
				else
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<Weapon>(list.Count, Pools<Weapon>.Local);
					}
					pooledList.Add(item);
				}
			}
			result = pooledList;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100300", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int WeaponSuitabilityForThisTarget(ref Weapon theWeapon, ref Contact theTarget, bool CheckIfWithinRange)
	{
		if (theWeapon == null)
		{
			return 0;
		}
		if (theTarget != null)
		{
			int result = default(int);
			try
			{
				Weapon obj = theWeapon;
				ActiveUnit theAttackingUnit = myUnit;
				GlobalVariables.BooleanObject TargetIsDestroyed = null;
				if (!obj.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed))
				{
					result = 0;
					return result;
				}
				if (theWeapon.IsNuke.Value)
				{
					byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (((!flag) ?? flag) == true)
					{
						result = 0;
						return result;
					}
				}
				int num;
				if (!CheckIfWithinRange)
				{
					num = 1;
				}
				else
				{
					float targetRange = ((theWeapon.Type != Weapon._WeaponType.Gun) ? myUnit.RangeToUnit_Horiz(theTarget) : Module_Unit.RangeToUnit_Slant(myUnit, theTarget));
					if (!theWeapon.IsWithinMaxRangeOfTarget(targetRange, theTarget))
					{
						result = 0;
						return result;
					}
					if (theWeapon.IsWithinMinRangeOfTarget(targetRange, theTarget))
					{
						result = 0;
						return result;
					}
					num = 1;
				}
				int num2 = num;
				if (myUnit.IsAircraft && theWeapon.Type == Weapon._WeaponType.Gun)
				{
					num2 -= 2;
				}
				if (theWeapon.Warheads.Length > 0)
				{
					Warhead warhead = theWeapon.Warheads[0];
					switch (theTarget.Type)
					{
					case Contact_Base.ContactType.AggregateGroundUnit:
						if (theWeapon.IsASuW_Land && !theWeapon.IsAAWCapable)
						{
							num2++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.Incendiary:
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.SuperFrag:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.Cluster_AP:
						case Warhead.WarheadType.Cluster_AT:
						case Warhead.WarheadType.Cluster_SmartSubs:
						case Warhead.WarheadType.Landmine_AP:
						case Warhead.WarheadType.Landmine_AT:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num2++;
							break;
						}
						if (warhead.IsAreaEffect)
						{
							num2 += 3;
						}
						break;
					case Contact_Base.ContactType.Air:
						if (theWeapon.Type == Weapon._WeaponType.Gun && theWeapon.IsAAWCapable && !theWeapon.IsASuW_Land && !theWeapon.IsASuW_Naval)
						{
							num2++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.ContinuousRod:
						case Warhead.WarheadType.Nuclear:
							num2++;
							break;
						case Warhead.WarheadType.Fragmentation_ABM:
							num2 += 2;
							break;
						}
						break;
					case Contact_Base.ContactType.Missile:
						if (theWeapon.Type == Weapon._WeaponType.Gun && theWeapon.IsAAWCapable && !theWeapon.IsASuW_Land && !theWeapon.IsASuW_Naval)
						{
							num2++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.Fragmentation_ABM:
							num2 += 2;
							break;
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.ContinuousRod:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Laser_COIL:
						case Warhead.WarheadType.Laser_CarbonDioxide:
						case Warhead.WarheadType.Laser_DeuteriumFluoride:
						case Warhead.WarheadType.Laser_SolidStateFiber:
						case Warhead.WarheadType.Kinetic:
							num2++;
							break;
						}
						break;
					case Contact_Base.ContactType.Surface:
						if (theWeapon.IsASuW_Naval && !theWeapon.IsAAWCapable)
						{
							num2++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.SemiAP:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.HardTargetPenetrator:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num2++;
							break;
						}
						break;
					case Contact_Base.ContactType.Submarine:
					{
						Warhead.WarheadType type = warhead.Type;
						if (type == Warhead.WarheadType.HEAT || type == Warhead.WarheadType.HESH || (uint)(type - 3001) <= 1u)
						{
							num2++;
						}
						break;
					}
					case Contact_Base.ContactType.Facility_Fixed:
						if (theWeapon.IsASuW_Land && !theWeapon.IsAAWCapable)
						{
							num2 += 2;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.Incendiary:
						case Warhead.WarheadType.SemiAP:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.HardTargetPenetrator:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.Cluster_Penetrator:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num2++;
							break;
						}
						if (!Information.IsNothing((object)theTarget.ActualUnit) && Module_ActiveUnit.IsAimpointFacility(theTarget.ActualUnit) && warhead.IsAreaEffect)
						{
							num2 += 3;
						}
						break;
					case Contact_Base.ContactType.Facility_Mobile:
						if (theWeapon.IsASuW_Land && !theWeapon.IsAAWCapable)
						{
							num2++;
						}
						switch (warhead.Type)
						{
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.ArmorPiercing:
						case Warhead.WarheadType.HEAT:
						case Warhead.WarheadType.Incendiary:
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.HESH:
						case Warhead.WarheadType.SuperFrag:
						case Warhead.WarheadType.Nuclear:
						case Warhead.WarheadType.Cluster_AP:
						case Warhead.WarheadType.Cluster_AT:
						case Warhead.WarheadType.Cluster_SmartSubs:
						case Warhead.WarheadType.Landmine_AP:
						case Warhead.WarheadType.Landmine_AT:
						case Warhead.WarheadType.LongRodPenetrator:
						case Warhead.WarheadType.Kinetic:
							num2++;
							break;
						}
						if (!Information.IsNothing((object)theTarget.ActualUnit) && Module_ActiveUnit.IsAimpointFacility(theTarget.ActualUnit) && warhead.IsAreaEffect)
						{
							num2 += 3;
						}
						break;
					}
					if (theTarget.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
					{
						int num3;
						GlobalVariables.ArmorRating armorRating = default(GlobalVariables.ArmorRating);
						switch (theTarget.Type)
						{
						default:
							num3 = 2001;
							goto IL_0700;
						case Contact_Base.ContactType.AggregateGroundUnit:
							if (theTarget.ActualUnit.IsAggregatedUnit)
							{
								armorRating = ((AggregateGroundUnit)theTarget.ActualUnit).GetMostCommonArmorRating();
							}
							break;
						case Contact_Base.ContactType.Surface:
						{
							ActiveUnit actualUnit3 = theTarget.ActualUnit;
							if (actualUnit3 != null)
							{
								if (actualUnit3.IsShip)
								{
									armorRating = ((Ship)actualUnit3).Armor_Belt;
								}
								else if (!actualUnit3.IsSubmarine)
								{
									if (actualUnit3.IsFacility)
									{
										armorRating = ((Facility)actualUnit3).Armor_General;
									}
								}
								else
								{
									armorRating = GlobalVariables.ArmorRating.Light;
								}
							}
							else
							{
								armorRating = GlobalVariables.ArmorRating.None;
							}
							break;
						}
						case Contact_Base.ContactType.Submarine:
							armorRating = (((Submarine)theTarget.ActualUnit).Flags.DoubleHull ? GlobalVariables.ArmorRating.Medium : GlobalVariables.ArmorRating.Light);
							break;
						case Contact_Base.ContactType.UndeterminedNaval:
						case Contact_Base.ContactType.Aimpoint:
							num3 = 2001;
							goto IL_0700;
						case Contact_Base.ContactType.Facility_Fixed:
						{
							ActiveUnit actualUnit4 = theTarget.ActualUnit;
							if (actualUnit4 == null || !Module_ActiveUnit.IsAimpointFacility(actualUnit4))
							{
								if (theTarget?.ActualUnit != null)
								{
									armorRating = ((Facility)theTarget.ActualUnit).Armor_General;
								}
							}
							else
							{
								armorRating = ((theTarget.ActualUnit.Mounts.Count <= 0) ? ((Facility)theTarget.ActualUnit).Armor_General : theTarget.ActualUnit.Mounts[0].ArmorRating);
							}
							break;
						}
						case Contact_Base.ContactType.Facility_Mobile:
						{
							ActiveUnit actualUnit = theTarget.ActualUnit;
							if (actualUnit != null && actualUnit.IsMobileGroundUnit)
							{
								armorRating = ((IMobileGroundUnit)theTarget.ActualUnit).Armor_General;
								break;
							}
							ActiveUnit actualUnit2 = theTarget.ActualUnit;
							if (actualUnit2 != null && Module_ActiveUnit.IsAimpointFacility(actualUnit2))
							{
								armorRating = ((theTarget.ActualUnit.Mounts.Count <= 0) ? ((Facility)theTarget.ActualUnit).Armor_General : theTarget.ActualUnit.Mounts[0].ArmorRating);
							}
							else if (theTarget?.ActualUnit != null)
							{
								armorRating = ((Facility)theTarget.ActualUnit).Armor_General;
							}
							break;
						}
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Missile:
						case Contact_Base.ContactType.Orbital:
						case Contact_Base.ContactType.Torpedo:
						case Contact_Base.ContactType.Mine:
							{
								armorRating = GlobalVariables.ArmorRating.None;
								break;
							}
							IL_0700:
							armorRating = (GlobalVariables.ArmorRating)num3;
							break;
						}
						switch (armorRating)
						{
						default:
						{
							Warhead.WarheadType? warheadType = warhead?.Type;
							int? num4 = (int?)warheadType;
							bool? flag3;
							bool? flag2 = (flag3 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2002)));
							bool? obj2;
							bool? flag4;
							if (flag2.HasValue && flag3 == true)
							{
								obj2 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag2 = (flag4 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 6002)));
								obj2 = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3));
							}
							bool? flag5 = obj2;
							flag4 = obj2;
							bool? obj3;
							bool? flag6;
							if (flag4.HasValue && flag5 == true)
							{
								obj3 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag4 = (flag6 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 6003)));
								obj3 = ((!flag4.HasValue) ? ((bool?)null) : ((flag6 == true) | flag5));
							}
							bool? flag7 = obj3;
							flag6 = obj3;
							bool? obj4;
							bool? flag8;
							if (flag6.HasValue && flag7 == true)
							{
								obj4 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag6 = (flag8 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 6012)));
								obj4 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag7));
							}
							bool? flag9 = obj4;
							flag8 = obj4;
							bool? obj5;
							bool? flag10;
							if (flag8.HasValue && flag9 == true)
							{
								obj5 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag8 = (flag10 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 9801)));
								obj5 = ((!flag8.HasValue) ? ((bool?)null) : ((flag10 == true) | flag9));
							}
							bool? flag11 = obj5;
							flag10 = obj5;
							bool? obj6;
							bool? flag12;
							if (flag10.HasValue && flag11 == true)
							{
								obj6 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag10 = (flag12 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2009)));
								obj6 = ((!flag10.HasValue) ? ((bool?)null) : ((flag12 == true) | flag11));
							}
							bool? flag13 = obj6;
							flag12 = obj6;
							bool? obj7;
							bool? flag14;
							if (flag12.HasValue && flag13 == true)
							{
								obj7 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag12 = (flag14 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2003)));
								obj7 = ((!flag12.HasValue) ? ((bool?)null) : ((flag14 == true) | flag13));
							}
							bool? flag15 = obj7;
							flag14 = obj7;
							bool? obj8;
							bool? flag16;
							if (flag14.HasValue && flag15 == true)
							{
								obj8 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag14 = (flag16 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2007)));
								obj8 = ((!flag14.HasValue) ? ((bool?)null) : ((flag16 == true) | flag15));
							}
							bool? flag17 = obj8;
							flag16 = obj8;
							bool? obj9;
							bool? flag18;
							if (flag16.HasValue && flag17 == true)
							{
								obj9 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag16 = (flag18 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 7002)));
								obj9 = ((!flag16.HasValue) ? ((bool?)null) : ((flag18 == true) | flag17));
							}
							bool? flag19 = obj9;
							flag18 = obj9;
							bool? obj10;
							bool? flag20;
							if (flag18.HasValue && flag19 == true)
							{
								obj10 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag18 = (flag20 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 8001)));
								obj10 = ((!flag18.HasValue) ? ((bool?)null) : ((flag20 == true) | flag19));
							}
							bool? flag = obj10;
							flag20 = obj10;
							bool? obj11;
							bool? flag21;
							if (flag20.HasValue && flag == true)
							{
								obj11 = true;
							}
							else
							{
								num4 = (int?)warheadType;
								flag20 = (flag21 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2006)));
								obj11 = ((!flag20.HasValue) ? ((bool?)null) : ((flag21 == true) | flag));
							}
							flag21 = obj11;
							if (flag21 == true)
							{
								num2++;
							}
							if (theWeapon.Type == Weapon._WeaponType.Gun)
							{
								num2 = ((warhead.Caliber <= Warhead.WarheadCaliber.Gun_61_80mm) ? (num2 - 1) : (num2 + 1));
							}
							break;
						}
						case GlobalVariables.ArmorRating.Light:
							if (warhead.Type == Warhead.WarheadType.SuperFrag)
							{
								num2++;
							}
							break;
						case GlobalVariables.ArmorRating.None:
							switch (warhead.Type)
							{
							case Warhead.WarheadType.HE_BlastFrag:
							case Warhead.WarheadType.Incendiary:
							case Warhead.WarheadType.Fragmentation:
							case Warhead.WarheadType.ContinuousRod:
							case Warhead.WarheadType.Fragmentation_ABM:
							case Warhead.WarheadType.DepthCharge:
							case Warhead.WarheadType.Nuclear:
							case Warhead.WarheadType.Cluster_AP:
							case Warhead.WarheadType.Landmine_AP:
								num2++;
								break;
							}
							if (theWeapon.Type == Weapon._WeaponType.Gun)
							{
								num2 = ((warhead.Caliber > Warhead.WarheadCaliber.Gun_61_80mm) ? (num2 - 1) : (num2 + 1));
							}
							break;
						}
					}
				}
				result = num2;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100301", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		return 0;
	}

	public Weapon LongestRangedSuitableWeaponForThisTarget(Contact theTarget)
	{
		PooledList<Weapon> pooledList = default(PooledList<Weapon>);
		Weapon result = default(Weapon);
		try
		{
			Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
			pooledList = SuitableWeaponsForThisTarget(theTarget, ref GunStrafingSalvo);
			if (pooledList != null)
			{
				switch (pooledList.Count)
				{
				case 0:
					result = null;
					return result;
				default:
				{
					Weapon weapon = null;
					float num = 0f;
					foreach (Weapon item in pooledList)
					{
						if (!item.IsDecoy)
						{
							float num2 = item.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
							if (num2 > num)
							{
								weapon = item;
								num = num2;
							}
						}
					}
					result = weapon;
					return result;
				}
				case 1:
					result = pooledList[0];
					return result;
				}
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100302", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
		}
		return result;
	}

	public Weapon MostSuitableWeaponForThisTarget(Contact theTarget, bool CheckIfWithinRange, bool CheckIfWithinAltitude, bool CheckWRA, Doctrine theDoc, bool excludeChaffsAndCounterMeasures = false, bool CheckWeaponQuantity = false, bool CheckWRASelfDefenceRange = false)
	{
		PooledList<Weapon> pooledList = default(PooledList<Weapon>);
		Weapon result;
		try
		{
			if (!myUnit.IsWeapon)
			{
				Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = theDoc.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				pooledList = SuitableWeaponsForThisTarget(theTarget, ref GunStrafingSalvo);
				if (pooledList != null && pooledList.Count != 0)
				{
					float num = myUnit.RangeToUnit_Horiz_Alt(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					if (threadLocal_0 == null)
					{
						threadLocal_0 = new ThreadLocal<List<Weapon>>();
					}
					if (!threadLocal_0.IsValueCreated)
					{
						threadLocal_0.Value = new List<Weapon>();
					}
					else
					{
						threadLocal_0.Value.Clear();
					}
					List<Weapon> value = threadLocal_0.Value;
					PooledList<Weapon> pooledList2 = default(PooledList<Weapon>);
					if (theDoc != null && (theTarget.isSurfaceOrLandContact | theTarget.IsFacility | (theTarget.ActualUnit != null && theTarget.ActualUnit.IsFacility)))
					{
						byte? b = (byte?)theDoc.get_UseSAMsOnASuW(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
						{
							foreach (Weapon item in pooledList)
							{
								if (item.IsMissile && item.IsAAWOriented)
								{
									if (pooledList2 == null)
									{
										pooledList2 = new PooledList<Weapon>(pooledList.Count, Pools<Weapon>.Local);
									}
									pooledList2.Add(item);
								}
							}
							if (pooledList2 != null)
							{
								foreach (Weapon item2 in pooledList2)
								{
									pooledList.Remove(item2);
								}
							}
						}
					}
					pooledList2?.Dispose();
					if (CheckWRA && CheckIfWithinRange)
					{
						if (!CheckIfWithinAltitude || !theTarget.AltitudeIsKnown)
						{
							foreach (Weapon item3 in pooledList)
							{
								Weapon theWeapon = item3;
								float num2 = 0f;
								Doctrine doctrine = myUnit.Doctrine;
								Scenario parentScen = myUnit.ParentScen;
								int dBID = theWeapon.DBID;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Contact.WRA_DetermineTargetType(ref theTarget, null, ref GlobalVariables.ObjectFalse);
								float? TargetType_InheritedFiringRange = null;
								float? TargetType_UnspecifiedFiringRange = null;
								float? num3 = theDoc.WRA_FiringRange_AnyTargetType(doctrine, parentScen, dBID, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
								num2 = ((((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() != -99f)) != true) ? myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref theTarget, ManualFire: true) : theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, theDoc, ManualFire: false));
								if (num2 >= num)
								{
									value.Add(theWeapon);
								}
							}
						}
						else
						{
							foreach (Weapon item4 in pooledList)
							{
								Weapon theWeapon2 = item4;
								float num4 = 0f;
								Doctrine doctrine2 = myUnit.Doctrine;
								Scenario parentScen2 = myUnit.ParentScen;
								int dBID2 = theWeapon2.DBID;
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType2 = Contact.WRA_DetermineTargetType(ref theTarget, null, ref GlobalVariables.ObjectFalse);
								float? TargetType_UnspecifiedFiringRange = null;
								float? TargetType_InheritedFiringRange = null;
								float? num3 = theDoc.WRA_FiringRange_AnyTargetType(doctrine2, parentScen2, dBID2, selectedNodeTargetType2, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedFiringRange, ref TargetType_InheritedFiringRange);
								num4 = ((((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() != -99f)) == true) ? theWeapon2.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, theDoc, ManualFire: false) : myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon2, ref theTarget, ManualFire: true));
								if (num4 >= num && string.CompareOrdinal(method_5(theWeapon2, theTarget), "OK") == 0)
								{
									Weapon theWeapon3 = theWeapon2;
									Contact theTarget2 = theTarget;
									int? ASL_atFiringUnit = null;
									if (IsWeaponWithinFiringParams_LaunchAltitude(theWeapon3, theTarget2, ref ASL_atFiringUnit, HumanFeedbackNeeded: false).Result == WeaponryAltitudeCheckResult.OK)
									{
										value.Add(theWeapon2);
									}
								}
							}
						}
					}
					else if (CheckWRA && !CheckIfWithinRange)
					{
						if (!CheckIfWithinAltitude || !theTarget.AltitudeIsKnown)
						{
							foreach (Weapon item5 in pooledList)
							{
								if (item5.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, theDoc, ManualFire: false) > 0f)
								{
									value.Add(item5);
								}
							}
						}
						else
						{
							foreach (Weapon item6 in pooledList)
							{
								if (item6.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, theDoc, ManualFire: false) > 0f && string.CompareOrdinal(method_5(item6, theTarget), "OK") == 0)
								{
									Contact theTarget3 = theTarget;
									int? ASL_atFiringUnit = null;
									if (IsWeaponWithinFiringParams_LaunchAltitude(item6, theTarget3, ref ASL_atFiringUnit, HumanFeedbackNeeded: false).Result == WeaponryAltitudeCheckResult.OK)
									{
										value.Add(item6);
									}
								}
							}
						}
					}
					else if (!CheckWRA && CheckIfWithinRange)
					{
						if (!CheckIfWithinAltitude || !theTarget.AltitudeIsKnown)
						{
							foreach (Weapon item7 in pooledList)
							{
								Weapon theWeapon4 = item7;
								if (myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon4, ref theTarget, ManualFire: true) >= num)
								{
									value.Add(theWeapon4);
								}
							}
						}
						else
						{
							foreach (Weapon item8 in pooledList)
							{
								Weapon theWeapon5 = item8;
								if (myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon5, ref theTarget, ManualFire: true) >= num && string.CompareOrdinal(method_5(theWeapon5, theTarget), "OK") == 0)
								{
									Weapon theWeapon6 = theWeapon5;
									Contact theTarget4 = theTarget;
									int? ASL_atFiringUnit = null;
									if (IsWeaponWithinFiringParams_LaunchAltitude(theWeapon6, theTarget4, ref ASL_atFiringUnit, HumanFeedbackNeeded: false).Result == WeaponryAltitudeCheckResult.OK)
									{
										value.Add(theWeapon5);
									}
								}
							}
						}
					}
					else
					{
						value.AddRange(pooledList);
					}
					if (excludeChaffsAndCounterMeasures)
					{
						value.RemoveAll([SpecialName] (Weapon toBeRem) => toBeRem?.IsChaff_CM_SG ?? false);
					}
					if (CheckWeaponQuantity && value.Count > 0)
					{
						for (int num5 = value.Count - 1; num5 >= 0; num5 += -1)
						{
							if (HowManyOfThisWeapon(value[num5].DBID) == 0)
							{
								value.RemoveAt(num5);
							}
						}
					}
					if (CheckWRASelfDefenceRange)
					{
						Doctrine._WRA_WeaponTargetType selectedNodeTargetType3 = Contact.WRA_DetermineTargetType(ref theTarget, null, ref GlobalVariables.ObjectFalse);
						PooledList<Weapon> pooledList3 = default(PooledList<Weapon>);
						foreach (Weapon item9 in value)
						{
							Doctrine doctrine3 = myUnit.Doctrine;
							Doctrine doctrine4 = myUnit.Doctrine;
							Scenario parentScen3 = myUnit.ParentScen;
							float? num3 = null;
							float? TargetType_UnspecifiedFiringRange = null;
							float? num6 = doctrine3.WRA_SelfDefenceRange_AnyTargetType(doctrine4, parentScen3, item9, selectedNodeTargetType3, FindInheritedValuesOnly: false, ref num3, ref TargetType_UnspecifiedFiringRange);
							if (num6.HasValue)
							{
								TargetType_UnspecifiedFiringRange = num6;
								if ((TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == -99f) : ((bool?)null)) == true)
								{
									if (CheckIfWithinRange)
									{
										continue;
									}
									num6 = item9.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
								}
								TargetType_UnspecifiedFiringRange = num6;
								if ((TargetType_UnspecifiedFiringRange.HasValue ? new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() < num) : ((bool?)null)) == true)
								{
									if (pooledList3 == null)
									{
										pooledList3 = new PooledList<Weapon>(Pools<Weapon>.Local);
									}
									pooledList3.Add(item9);
								}
							}
							else
							{
								if (pooledList3 == null)
								{
									pooledList3 = new PooledList<Weapon>(Pools<Weapon>.Local);
								}
								pooledList3.Add(item9);
							}
						}
						if (pooledList3 != null)
						{
							foreach (Weapon item10 in pooledList3)
							{
								value.Remove(item10);
							}
						}
						pooledList3?.Dispose();
					}
					switch (value.Count)
					{
					case 0:
						result = null;
						break;
					default:
					{
						Weapon weapon = null;
						double num7 = double.MinValue;
						double num8 = double.MinValue;
						foreach (Weapon item11 in value)
						{
							Weapon theWeapon7 = item11;
							if (theWeapon7 != null)
							{
								double num9 = WeaponSuitabilityForThisTarget(ref theWeapon7, ref theTarget, CheckIfWithinRange);
								if (weapon == null || num9 > num7 || (num9 == num7 && (double)theWeapon7.DP_Total > num8))
								{
									weapon = theWeapon7;
									num7 = num9;
									num8 = theWeapon7.DP_Total;
								}
							}
						}
						result = weapon;
						break;
					}
					case 1:
						result = value[0];
						break;
					}
				}
				else
				{
					result = null;
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
			ex2?.Data.Add("Error at 100303", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
		}
		return result;
	}

	public virtual void ReduceTimesToFire(float elapsedTime)
	{
		Mount[] mounts_AsArray = myUnit.Mounts_AsArray;
		try
		{
			int num = mounts_AsArray.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					Mount mount = mounts_AsArray[i];
					if (mount.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					float num2 = 0f;
					if (mount.TimeToFire > 0f)
					{
						mount.TimeToFire = Math.Max(0f, mount.TimeToFire - elapsedTime);
						num2 = mount.TimeToFire;
					}
					Magazine mountMagazine = mount.MountMagazine;
					ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
					if (mountMagazine.TimeToFire > 0f && mountMagazine.TimeToFire > num2)
					{
						num2 = mountMagazine.TimeToFire;
					}
					int num3 = mountWeapons.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						try
						{
							WeaponRec weaponRec = mountWeapons[j];
							WeaponRec weaponRec2 = weaponRec;
							if (weaponRec2.TimeToFire > 0f)
							{
								weaponRec2.TimeToFire -= elapsedTime;
								if (weaponRec2.TimeToFire < 0f)
								{
									weaponRec2.TimeToFire = 0f;
								}
								if (weaponRec2.TimeToFire > num2)
								{
									num2 = weaponRec2.TimeToFire;
								}
							}
							weaponRec2 = null;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200437", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (mountMagazine.TimeToFire > 0f)
					{
						mountMagazine.TimeToFire = Math.Max(0f, mountMagazine.TimeToFire - elapsedTime);
					}
					ObservableList<WeaponRec> weapons = mountMagazine.Weapons;
					int num4 = weapons.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						try
						{
							WeaponRec weaponRec = weapons[j];
							WeaponRec weaponRec3 = weaponRec;
							if (weaponRec3.TimeToFire > 0f)
							{
								weaponRec3.TimeToFire -= elapsedTime;
								if (weaponRec3.TimeToFire < 0f)
								{
									weaponRec3.TimeToFire = 0f;
								}
								if (weaponRec3.TimeToFire > num2)
								{
									num2 = weaponRec3.TimeToFire;
								}
							}
							weaponRec3 = null;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200438", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (num2 <= 0f)
					{
						mount.ReloadStatus = Mount._ReloadStatus.Ready;
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 200439", ex6.Message);
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!myUnit.IsPlatform)
			{
				return;
			}
			Magazine[] magazines = ((Platform)myUnit).Magazines;
			for (int k = 0; k < magazines.Length; k = checked(k + 1))
			{
				ObservableList<WeaponRec> weapons2 = magazines[k].Weapons;
				int num5 = weapons2.Count - 1;
				for (int j = 0; j <= num5; j++)
				{
					try
					{
						WeaponRec weaponRec = weapons2[j];
						if (weaponRec.TimeToFire > 0f)
						{
							weaponRec.TimeToFire -= elapsedTime;
							if (weaponRec.TimeToFire < 0f)
							{
								weaponRec.TimeToFire = 0f;
							}
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at 200440", ex8.Message);
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 100304", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HaveSuitableWeaponForAmbigousTarget(Contact theTarget, bool CheckCanShootRightNow)
	{
		bool result = default(bool);
		try
		{
			int num;
			if (!theTarget.isSurfaceOrLandContact && !theTarget.ActualUnit.IsSubmarine)
			{
				num = 0;
			}
			else
			{
				List<Weapon> list = AllDistinctWeaponsAboard_Actual();
				if (list.Count > 0)
				{
					GlobalVariables.BooleanObject TargetIsDestroyed = default(GlobalVariables.BooleanObject);
					foreach (Weapon item in list)
					{
						if (!item.IsNominallySuitableForThisTarget(myUnit, ref theTarget, ref TargetIsDestroyed) || string.CompareOrdinal(IsWeaponSuitableForTargetAmbiguity(item, theTarget), "OK") != 0)
						{
							continue;
						}
						int num2;
						if (CheckCanShootRightNow)
						{
							Contact theTarget2 = theTarget;
							int? ASL_atFiringUnit = null;
							Sensor SuitableDirectorSensor = null;
							if (CanThisWeaponEngageThisTarget(item, theTarget2, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum != WeaponPrefireChecklistEvaluation.OK)
							{
								continue;
							}
							num2 = 1;
						}
						else
						{
							num2 = 1;
						}
						result = (byte)num2 != 0;
						return result;
					}
				}
				num = 0;
			}
			result = (byte)num != 0;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100305", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string IsWeaponSuitableForTargetAmbiguity(Weapon theWeapon, Contact theTarget)
	{
		string result;
		try
		{
			if (!theWeapon.IsNuke.Value)
			{
				goto IL_0091;
			}
			byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b != 1)) != true)
			{
				goto IL_0091;
			}
			result = "Nuclear weapons not authorized";
			goto end_IL_0001;
			IL_0245:
			float num = Module_Contact.DownRangeAmbiguity(theTarget, myUnit);
			float num2 = (float)Math.Round(theWeapon.AcceptableDownRangeAmbiguity, 1);
			int num3 = default(int);
			string text = ((num3 > 1) ? " " : (" " + Conversions.ToString(num3) + "x "));
			if (Math.Round(num, 1) > Math.Round(num2 * (float)num3, 1))
			{
				result = "The target's downrange ambiguity (" + $"{num:0.0}" + "nm) is larger than" + text + "the weapon's acceptable limit (" + $"{num2:0.0}" + "nm)";
			}
			else
			{
				float num4 = Module_Contact.CrossRangeAmbiguity(theTarget, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				float num5 = (float)Math.Round(theWeapon.AcceptableCrossRangeAmbiguity, 1);
				result = ((!(Math.Round(num4, 1) > Math.Round(num5, 1))) ? "OK" : ("The target's cross-range ambiguity (" + $"{num4:0.0}" + "nm) is larger than" + text + "the weapon's acceptable limit (" + $"{num5:0.0}" + "nm)"));
			}
			goto end_IL_0001;
			IL_0091:
			Doctrine._BehaviorTowardsTargetAmbiguity? behaviorTowardsTargetAmbiguity = myUnit.Doctrine.get_BehaviorTowardsAmbigousTarget(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			b = (byte?)behaviorTowardsTargetAmbiguity;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				result = "OK";
			}
			else
			{
				b = (byte?)behaviorTowardsTargetAmbiguity;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
				{
					b = (byte?)behaviorTowardsTargetAmbiguity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
					{
						num3 = 1;
					}
				}
				else
				{
					num3 = 3;
				}
				if (theWeapon.IsMobileDecoy)
				{
					result = "OK";
				}
				else
				{
					if (!theTarget.IsSubmergedContact)
					{
						goto IL_0245;
					}
					if (num3 == 1)
					{
						if (!(theTarget.Age > 120f))
						{
							goto IL_0245;
						}
						result = "The target's last known location is outdated (" + Misc.TimeString((long)Math.Round(theTarget.Age)) + " seconds). (Pessimistic)";
					}
					else
					{
						if (!(theTarget.Age > 600f))
						{
							goto IL_0245;
						}
						result = "The target's last known location is outdated (" + Misc.TimeString((long)Math.Round(theTarget.Age)) + " seconds). (Optimistic)";
					}
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100306", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float WeaponOuterRangeLimit(ref ActiveUnit theShooter, ref Weapon theWeapon, ref Contact theTarget, bool ManualFire)
	{
		if (theWeapon != null && theTarget != null)
		{
			if (theWeapon.IsMissile && NeedToCheckDLZ(theWeapon, theTarget) && theTarget.CurrentSpeed != 0f)
			{
				if (theTarget.isSurfaceOrLandContact)
				{
					return theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
				}
				if (!theTarget.IsBallisticTarget() && !theTarget.ActualUnit.IsSatellite && (!theTarget.ActualUnit.IsWeapon || !((Weapon)theTarget.ActualUnit).IsHGV))
				{
					double num = Physics.ComputeMach(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theShooter.CurrentSpeed + theTarget.CurrentSpeed);
					return (float)((double)theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) * (1.0 + num));
				}
				return theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) * 100f;
			}
			if (theWeapon.IsTorpedo)
			{
				byte? b = (byte?)myUnit.Doctrine.get_UseKinematicRangeForTorpedoes(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
				{
					goto IL_01ec;
				}
				if (ManualFire)
				{
					b = (byte?)myUnit.Doctrine.get_UseKinematicRangeForTorpedoes(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
					{
						goto IL_01ec;
					}
				}
			}
			if (theWeapon.Type == Weapon._WeaponType.Gun && theTarget.IsGuidedWeaponContact && theTarget.ActualUnit != null && theTarget.ActualUnit.AI.PrimaryTarget != null && theTarget.ActualUnit.AI.PrimaryTarget.ActualUnit != null && theTarget.ActualUnit.AI.PrimaryTarget.ActualUnit == theShooter)
			{
				if (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 650f)
				{
					return (float)Math.Min((double)theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) * 1.5, 1.5);
				}
				float num2 = ((!(theTarget.CurrentSpeed < 1000f)) ? 2f : 1.5f);
				float num3 = (float)((double)Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 1852.0);
				return (float)Math.Sqrt(num2 * num2 + num3 * num3);
			}
			if (theWeapon.Type == Weapon._WeaponType.Aircraft)
			{
				Aircraft theAircraft = new Aircraft(ref myUnit.ParentScen);
				DBFunctions.GetAircraft(ref myUnit.ParentScen, ref theAircraft, (int)Math.Round(theWeapon.Warheads[0].DP));
				float maximumAltitude = theAircraft.Kinematics.GetMaximumAltitude();
				float num4 = theAircraft.Kinematics.GetMaximumSpeed(maximumAltitude, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false, ConsiderDamage: false);
				float result = (float)((double)theAircraft.get_FuelEndurance(ActiveUnit.Throttle.Cruise, (AltBand)null, (float?)num4, (float?)maximumAltitude) / 3600.0 * (double)num4);
				theAircraft = null;
				return result;
			}
			return theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, myUnit.Doctrine, ManualFire);
		}
		return 0f;
		IL_01ec:
		Torpedo torpedo = (Torpedo)theWeapon;
		return Math.Max(torpedo.MaxKinematicRange_Cruise, torpedo.MaxKinematicRange_Full);
	}

	public void PrecacheDLZchecks()
	{
		_Closure$__76-1 closure$__76- = new _Closure$__76-1(closure$__76-);
		closure$__76-.$VB$Me = this;
		if (!myUnit.IsGroup && DLZ_ResultsCache != null)
		{
			DLZ_ResultsCache.Clear();
		}
		if (DLZ_ChecksRequested == null || DLZ_ChecksRequested.Count == 0)
		{
			return;
		}
		TaskList_DLZChecks.Clear();
		closure$__76-.$VB$Local_TargetsReadOnlySafeCopy = myUnit.AI.Targets_ReadOnly.ToList();
		using (HashSet<(int, string, bool)>.Enumerator enumerator = DLZ_ChecksRequested.GetEnumerator())
		{
			_Closure$__76-0 closure$__76-2 = default(_Closure$__76-0);
			while (enumerator.MoveNext())
			{
				closure$__76-2 = new _Closure$__76-0(closure$__76-2);
				closure$__76-2.$VB$NonLocal_$VB$Closure_2 = closure$__76-;
				closure$__76-2.$VB$Local_theTuple = enumerator.Current;
				Task task = new Task(closure$__76-2._Lambda$__0);
				TaskList_DLZChecks.Add(task);
				task.Start();
			}
		}
		DLZ_ChecksRequested.Clear();
	}

	private string method_5(Weapon weapon_6, Contact contact_0)
	{
		string result;
		try
		{
			if (contact_0.IsBallisticTarget() || contact_0.Type == Contact_Base.ContactType.Surface)
			{
				goto IL_03b5;
			}
			if (!(weapon_6.MaxTargetAlt_AGL > 0f))
			{
				goto IL_0119;
			}
			float num = ((!myUnit.IsFacility) ? weapon_6.MaxTargetAlt_AGL : (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + weapon_6.MaxTargetAlt_AGL));
			if (!(contact_0.CurrentAltitude_AGL > num) || !Module_Unit.IsOverLand(contact_0))
			{
				goto IL_0119;
			}
			result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Target altitude (" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL * 3.28084f)) + " ft AGL) is higher than the weapon's ceiling (" + Conversions.ToString((int)Math.Round(num * 3.28084f)) + " ft AGL)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL)) + " m AGL) is higher than the weapon's ceiling (" + Conversions.ToString(num) + " m AGL)"));
			goto end_IL_0001;
			IL_03b5:
			result = "OK";
			goto end_IL_0001;
			IL_0119:
			if (weapon_6.MaxTargetAlt_ASL > 0f && ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > weapon_6.MaxTargetAlt_ASL)
			{
				result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) + " m ASL) is higher than the weapon's ceiling (" + Conversions.ToString(weapon_6.MaxTargetAlt_ASL) + " m ASL)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft ASL) is higher than the weapon's ceiling (" + Conversions.ToString((int)Math.Round(weapon_6.MaxTargetAlt_ASL * 3.28084f)) + " ft ASL)"));
			}
			else
			{
				if (!(weapon_6.MinTargetAlt_AGL > 0f))
				{
					goto IL_02d8;
				}
				float minTargetAlt_AGL = weapon_6.MinTargetAlt_AGL;
				if (!(contact_0.CurrentAltitude_AGL < minTargetAlt_AGL) || contact_0.Type == Contact_Base.ContactType.ActivationPoint)
				{
					goto IL_02d8;
				}
				result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Target altitude (" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL * 3.28084f)) + " ft AGL) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString((int)Math.Round(minTargetAlt_AGL * 3.28084f)) + " ft AGL)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(contact_0.CurrentAltitude_AGL)) + " m AGL) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString(minTargetAlt_AGL) + " m AGL)"));
			}
			goto end_IL_0001;
			IL_02d8:
			if (!(weapon_6.MinTargetAlt_ASL > 0f) || !(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < weapon_6.MinTargetAlt_ASL))
			{
				goto IL_03b5;
			}
			result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) + " m ASL) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString(weapon_6.MinTargetAlt_ASL) + " m ASL)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft ASL) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString((int)Math.Round(weapon_6.MinTargetAlt_ASL * 3.28084f)) + " ft ASL)"));
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal (string ResultString, WeaponryAltitudeCheckResult Result) IsWeaponWithinFiringParams_LaunchAltitude(Weapon theWeapon, Contact theTarget, ref int? ASL_atFiringUnit, bool HumanFeedbackNeeded)
	{
		(string, WeaponryAltitudeCheckResult) result;
		try
		{
			if (myUnit.IsAircraft && !theTarget.IsOrbitalContact && (theWeapon.MinLaunchAlt_AGL != 0f || theWeapon.MaxLaunchAlt_AGL != 0f || theWeapon.MinLaunchAlt_ASL != 0f || theWeapon.MaxLaunchAlt_ASL != 0f))
			{
				if (!ASL_atFiringUnit.HasValue)
				{
					ASL_atFiringUnit = (short)Math.Max(0, ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
				}
				int value = ASL_atFiringUnit.Value;
				if (theWeapon.MaxLaunchAlt_AGL > 0f && (double)(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)value) > (double)theWeapon.MaxLaunchAlt_AGL + 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value > 0)
						{
							if (theWeapon.MinLaunchAlt_AGL > 0f)
							{
								if (HumanFeedbackNeeded)
								{
									return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (theWeapon.MinLaunchAlt_ASL > 0f)
							{
								if (HumanFeedbackNeeded)
								{
									return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL maximum, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_AGL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_ASL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL maximum)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (value > 0)
					{
						if (theWeapon.MinLaunchAlt_AGL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_ASL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL maximum, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MinLaunchAlt_AGL > 0f)
					{
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MinLaunchAlt_ASL > 0f)
					{
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (!HumanFeedbackNeeded)
					{
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL maximum)", Result: WeaponryAltitudeCheckResult.Fail);
				}
				if (theWeapon.MaxLaunchAlt_ASL > 0f && (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (double)theWeapon.MaxLaunchAlt_ASL + 0.1)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value > 0)
						{
							if (theWeapon.MinLaunchAlt_AGL > 0f)
							{
								if (!HumanFeedbackNeeded)
								{
									return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (theWeapon.MinLaunchAlt_ASL > 0f)
							{
								if (!HumanFeedbackNeeded)
								{
									return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL maximum, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_AGL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_ASL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL maximum)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (value > 0)
					{
						if (theWeapon.MinLaunchAlt_AGL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MinLaunchAlt_ASL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL maximum, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MinLaunchAlt_AGL > 0f)
					{
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MinLaunchAlt_ASL > 0f)
					{
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (!HumanFeedbackNeeded)
					{
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					return (ResultString: "Aircraft altitude too high (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL maximum)", Result: WeaponryAltitudeCheckResult.Fail);
				}
				if (theWeapon.MinLaunchAlt_AGL > 0f && (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (double)(theWeapon.MinLaunchAlt_AGL + (float)value) - 0.1)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value > 0)
						{
							if (theWeapon.MaxLaunchAlt_AGL > 0f)
							{
								if (!HumanFeedbackNeeded)
								{
									return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (theWeapon.MaxLaunchAlt_ASL > 0f)
							{
								if (HumanFeedbackNeeded)
								{
									return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL minimum, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_AGL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL)) + " m AGL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_ASL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL)) + " m ASL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL)) + " m AGL minimum)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (value > 0)
					{
						if (theWeapon.MaxLaunchAlt_AGL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_ASL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL minimum, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MaxLaunchAlt_AGL > 0f)
					{
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MaxLaunchAlt_ASL > 0f)
					{
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (!HumanFeedbackNeeded)
					{
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)) + " ft AGL minimum)", Result: WeaponryAltitudeCheckResult.Fail);
				}
				if (theWeapon.MinLaunchAlt_ASL > 0f && (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (double)theWeapon.MinLaunchAlt_ASL - 0.1)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (value > 0)
						{
							if (theWeapon.MaxLaunchAlt_AGL > 0f)
							{
								if (HumanFeedbackNeeded)
								{
									return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL + (float)value)) + " m AGL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (theWeapon.MaxLaunchAlt_ASL > 0f)
							{
								if (HumanFeedbackNeeded)
								{
									return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL + (float)value)) + " m ASL, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
								}
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL minimum, terrain elevation " + Conversions.ToString(value) + " m)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_AGL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL + (float)value)) + " m AGL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_ASL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL + (float)value)) + " m ASL)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL)) + " m ASL minimum)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (value > 0)
					{
						if (theWeapon.MaxLaunchAlt_AGL > 0f)
						{
							if (HumanFeedbackNeeded)
							{
								return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round((theWeapon.MaxLaunchAlt_AGL + (float)value) * 3.28084f)) + " ft AGL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (theWeapon.MaxLaunchAlt_ASL > 0f)
						{
							if (!HumanFeedbackNeeded)
							{
								return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
							}
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round((theWeapon.MaxLaunchAlt_ASL + (float)value) * 3.28084f)) + " ft ASL, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL minimum, terrain elevation " + Conversions.ToString((int)Math.Round((float)value * 3.28084f)) + " ft)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MaxLaunchAlt_AGL > 0f)
					{
						if (HumanFeedbackNeeded)
						{
							return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f)) + " ft AGL)", Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (theWeapon.MaxLaunchAlt_ASL > 0f)
					{
						if (!HumanFeedbackNeeded)
						{
							return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
						}
						return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL to " + Conversions.ToString((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f)) + " ft ASL)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					if (HumanFeedbackNeeded)
					{
						return (ResultString: "Aircraft altitude too low (Valid: " + Conversions.ToString((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)) + " ft ASL minimum)", Result: WeaponryAltitudeCheckResult.Fail);
					}
					return (ResultString: null, Result: WeaponryAltitudeCheckResult.Fail);
				}
			}
			return (ResultString: null, Result: WeaponryAltitudeCheckResult.OK);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = ("Error", WeaponryAltitudeCheckResult.Fail);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public (string EvaluationString, WeaponPrefireChecklistEvaluation EvaluationEnum) CanThisWeaponEngageThisTarget(Weapon theWeapon, Contact TheTarget, ref int? ASL_atFiringUnit, bool ManualFire, bool IgnoreAircraftOrientation, bool HumanFeedBackNeeded, Mount theMount = null, [Optional][DefaultParameterValue(null)] ref Sensor SuitableDirectorSensor, bool DLZCheckRequested = true, Waypoint[] ExplicitCourse = null)
	{
		(string, WeaponPrefireChecklistEvaluation) result;
		if (bool_4)
		{
			if (myUnit.IsAircraft)
			{
				Mission mission = myUnit.AssignedMissionOrPackage();
				if (mission != null && mission.MissionClass == Mission._MissionClass.Strike && ((Aircraft)myUnit).Navigator.HasReachedWeaponReleasePoint(fromUI: false))
				{
					result = ((!HumanFeedBackNeeded) ? ("WeaponRelease PointReached Shortcut", WeaponPrefireChecklistEvaluation.OK) : ("OK", WeaponPrefireChecklistEvaluation.OK));
					goto IL_01ec;
				}
			}
			if (myUnit.IsPerformingStandoffAttack)
			{
				result = (HumanFeedBackNeeded ? ("OK", WeaponPrefireChecklistEvaluation.OK) : ("Performing Standoff attack Shortcut", WeaponPrefireChecklistEvaluation.OK));
				goto IL_01ec;
			}
		}
		(string, WeaponPrefireChecklistEvaluation) result2 = CanThisWeaponEngageThisTarget_Internal(theWeapon, TheTarget, ref ASL_atFiringUnit, ManualFire, IgnoreAircraftOrientation, HumanFeedBackNeeded, theMount, ref SuitableDirectorSensor, DLZCheckRequested, ExplicitCourse);
		if (result2.Item2 == WeaponPrefireChecklistEvaluation.OK && theWeapon.IsGuidedWeapon() && theWeapon.IsAAW_GuidedMissile_ARH && TheTarget.IsAir_Missile_Orbital_Contact && !myUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(TheTarget) && !myUnit.Sensory.ActivateToObtainTrack_AAWFireControlGrade(TheTarget) && method_6(theWeapon, TheTarget, HumanFeedBackNeeded).Item2 != WeaponPrefireChecklistEvaluation.OK)
		{
			string item = "Firing unit must obtain (from itself Or another CEC-enabled platform) a high-quality track On the target before firing";
			result = (item, WeaponPrefireChecklistEvaluation.OtherNegative);
			goto IL_01ec;
		}
		if (Debugger.IsAttached && result2.Item2 != WeaponPrefireChecklistEvaluation.OK && TheTarget != null)
		{
			string text = result2.Item2.ToString() + " " + result2.Item1 + " Target " + TheTarget.Name + " Weapon: " + theWeapon.Name;
			if (Operators.CompareString(Misc.LastBarkText, text, false) != 0 && Operators.CompareString(myUnit.LastBarkText, Misc.LastBarkText, false) != 0)
			{
				Notification_Bark.Create_UnitBehaviour(myUnit, text);
				Misc.LastBarkText = text;
				myUnit.LastBarkText = text;
			}
		}
		return result2;
		IL_01ec:
		return result;
	}

	public (string EvaluationString, WeaponPrefireChecklistEvaluation EvaluationEnum) CanThisWeaponEngageThisTarget_Internal(Weapon theWeapon, Contact theTarget, ref int? ASL_atFiringUnit, bool ManualFire, bool IgnoreAircraftOrientation, bool HumanFeedBackNeeded, Mount theMount = null, [Optional][DefaultParameterValue(null)] ref Sensor SuitableDirectorSensor, bool DLZCheckRequested = true, Waypoint[] ExplicitCourse = null)
	{
		Weapon._WeaponType type = theWeapon.Type;
		bool flag;
		(string, WeaponPrefireChecklistEvaluation) result;
		if (theWeapon != null)
		{
			flag = theMount?.IsVLS ?? false;
			theWeapon.FiringParent = myUnit;
			if (theTarget == null)
			{
				result = (HumanFeedBackNeeded ? ("Target is null", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
			}
			else
			{
				if ((theTarget.isSurfaceOrLandContact || theTarget.IsSubmergedContact) && GameGeneral.Beta_PlatformComms && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
				{
					ActiveUnit_CommStuff.TransmissionContactData contactGradeInfo = myUnit.CommStuff.GetContactGradeInfo(theTarget.ObjectID);
					if (!string.IsNullOrEmpty(contactGradeInfo.TransmittedBy))
					{
						string commQualitySlide = EnumCommExtensions.GetCommQualitySlide(WeaponCommMatrix.GetMinBandwidth(type));
						string commLatencySlide = EnumCommExtensions.GetCommLatencySlide(WeaponCommMatrix.GetMinLatency(type));
						if ((int)contactGradeInfo.Bandwith < WeaponCommMatrix.GetMinBandwidth(type) || (int)contactGradeInfo.Latency < WeaponCommMatrix.GetMinLatency(type))
						{
							result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.InsufficientQualityGrade) : ("Target quality grade (" + EnumCommExtensions.GetDescriptionAsSlide(contactGradeInfo.Bandwith) + ") is insufficient for this engagement  Min Bandwith: " + commQualitySlide + " Min Latency:" + commLatencySlide, WeaponPrefireChecklistEvaluation.InsufficientQualityGrade));
							goto IL_3458;
						}
					}
				}
				if (theWeapon.Type == Weapon._WeaponType.AttachedMine && theTarget.CurrentSpeed > 0f)
				{
					result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Limpet mine cannot be attached to moving vessel", WeaponPrefireChecklistEvaluation.OtherNegative));
				}
				else if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Shooter is a drone in isolation with insufficient autonomy to target contacts on its own", WeaponPrefireChecklistEvaluation.OtherNegative));
				}
				else if (theWeapon.Guidance == Weapon.WeaponGuidanceType.CommandGuided_Datalinked && theTarget.Age > 0f)
				{
					result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Cannot fire command-guided weapon against aged target.", WeaponPrefireChecklistEvaluation.OtherNegative));
				}
				else if (type == Weapon._WeaponType.Decoy_Expendable || type == Weapon._WeaponType.Decoy_Towed)
				{
					result = (HumanFeedBackNeeded ? ("Weapon is decoy, will deploy automatically", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
				}
				else
				{
					try
					{
						if (theWeapon.IsMine)
						{
							UnguidedWeapon theM = new UnguidedWeapon(theWeapon, null, null, 0.0, 0.0);
							string text = UnguidedWeapon.CanLayMineHere(ref theM, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen);
							if (string.CompareOrdinal(text, "OK") != 0)
							{
								result = (text, WeaponPrefireChecklistEvaluation.OtherNegative);
								return result;
							}
							result = ("Can lay mine here. Assign unit to Mine Laying mission.", WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 9876543210000", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					try
					{
						Weapon weapon = theWeapon;
						ActiveUnit theAttackingUnit = myUnit;
						GlobalVariables.BooleanObject TargetIsDestroyed = null;
						if (!weapon.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed))
						{
							if (!HumanFeedBackNeeded)
							{
								result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
								return result;
							}
							result = ("Weapon is not suitable for this target", WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 9876543210001", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (theMount == null)
					{
						goto IL_043c;
					}
					if (theMount.Status != PlatformComponent._ComponentStatus.Operational)
					{
						result = (HumanFeedBackNeeded ? ("Weapon mount is not operational", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
					}
					else if (theMount.ReloadStatus == Mount._ReloadStatus.Reloading)
					{
						result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Weapon is reloading", WeaponPrefireChecklistEvaluation.OtherNegative));
					}
					else if (theMount.ReloadStatus == Mount._ReloadStatus.Unloading)
					{
						result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Weapon is unloading", WeaponPrefireChecklistEvaluation.OtherNegative));
					}
					else if (theMount.IsLauncherOccupied())
					{
						result = (HumanFeedBackNeeded ? ("The launcher is still linked to a wire-guided weapon", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
					}
					else
					{
						if (!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) || !theWeapon.IsGuidedOrUnguidedGun())
						{
							goto IL_043c;
						}
						result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Guns cannot fire underwater", WeaponPrefireChecklistEvaluation.OtherNegative));
					}
				}
			}
		}
		else
		{
			result = ("Weapon is null", WeaponPrefireChecklistEvaluation.OtherNegative);
		}
		goto IL_3458;
		IL_3458:
		return result;
		IL_2976:
		if (theWeapon.Guidance != Weapon.WeaponGuidanceType.BeamRiding)
		{
			goto IL_2a86;
		}
		bool flag2 = false;
		bool flag3 = false;
		Sensor[] sensors_Cached = myUnit.Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			try
			{
				if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.CanIlluminateForThisWeapon(ref theWeapon))
				{
					flag2 = true;
					if (sensor.TargetsTrackedForFireControl_Readonly.Count < sensor.MaxIlluminate || sensor.IsTrackingThisTargetForFireControl(ref theTarget))
					{
						SuitableDirectorSensor = sensor;
						flag3 = true;
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 987654321000029", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (!flag2)
		{
			result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("No weapons director available to illuminate the target", WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		else
		{
			if (flag3)
			{
				goto IL_2a86;
			}
			result = (HumanFeedBackNeeded ? ("All illumination channels suitable for this weapon are in use", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		goto IL_3458;
		IL_31f2:
		if (!bool_3 && DLZCheckRequested && NeedToCheckDLZ(theWeapon, theTarget))
		{
			(int, string, bool) tuple = (theWeapon.DBID, theTarget.ObjectID, flag);
			if (DLZ_ChecksRequested == null)
			{
				DLZ_ChecksRequested = new HashSet<(int, string, bool)>();
			}
			DLZ_ChecksRequested.Add(tuple);
			if (!HumanFeedBackNeeded && DLZ_ResultsCache != null && DLZ_ResultsCache.TryGetValue(tuple, out var value))
			{
				try
				{
					if (value.Item1 != DLZResultEnum.Success && !(value.Item1 == DLZResultEnum.Fail_MAXRangeWRA && ManualFire))
					{
						return (EvaluationString: Module_ActiveUnit_Weaponry.ToEnglishString(value.Item1), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 34567571887978", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				try
				{
					(DLZResultEnum, float) value2 = method_10(theTarget, theWeapon, flag, HumanFeedBackNeeded, null, null, ManualFire);
					if (DLZ_ResultsCache == null)
					{
						DLZ_ResultsCache = new TDictionary<(int, string, bool), (DLZResultEnum, float)>();
					}
					DLZ_ResultsCache.AddIfNotExistsElseUpdate(tuple, value2);
					if (value2.Item1 != DLZResultEnum.Success)
					{
						return (EvaluationString: Module_ActiveUnit_Weaponry.ToEnglishString(value2.Item1), EvaluationEnum: WeaponPrefireChecklistEvaluation.OtherNegative);
					}
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at 986575487587", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		result = ("OK", WeaponPrefireChecklistEvaluation.OK);
		goto IL_3458;
		IL_2e58:
		try
		{
			if (theWeapon.IsGuidedWeapon() && theTarget.ActualUnit.IsAerospaceUnit && theWeapon.IsAAW_GuidedMissile_ARH && !myUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(theTarget, ignoreOperatingState: true, ignoreTrackingState: true))
			{
				(string, WeaponPrefireChecklistEvaluation) tuple2 = method_6(theWeapon, theTarget, HumanFeedBackNeeded);
				if (tuple2.Item2 != WeaponPrefireChecklistEvaluation.OK)
				{
					result = tuple2;
					return result;
				}
			}
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			ex12?.Data.Add("Error at 987654321000032", "");
			GameGeneral.WriteExceptionsToLog(ex12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (!theWeapon.ValidTargets.Radar)
		{
			goto IL_3000;
		}
		if (theWeapon.IsDualModeARM)
		{
			if (theTarget.HasDetectedEmissions)
			{
				Weapon weapon2 = theWeapon;
				TObservableDictionary<int, EmissionContainer> detectedEmissions = theTarget.DetectedEmissions;
				Side theSide = myUnit.get_UnitSide(SetSideOnly: false);
				Contact theTarget2 = theTarget;
				Random theRNG = GameGeneral.GlobalRNG;
				if (weapon2.ARM_DetermineEmissionToTrack(detectedEmissions, theSide, theTarget2, ShootAtTurnedOffRadar: false, ref theRNG))
				{
					goto IL_3000;
				}
			}
			if (theTarget.IsFirm)
			{
				goto IL_3000;
			}
			result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC) : ("Target is not radiating and target location is not firm enough to launch dual mode ARM in INS/GPS mode.", WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC));
		}
		else if (!theTarget.HasDetectedEmissions)
		{
			result = ((!theTarget.IsAutoDetection) ? (HumanFeedBackNeeded ? ("Target is not radiating", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative)) : ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Target is autodetectable but not radiating", WeaponPrefireChecklistEvaluation.OtherNegative)));
		}
		else
		{
			Weapon weapon3 = theWeapon;
			TObservableDictionary<int, EmissionContainer> detectedEmissions2 = theTarget.DetectedEmissions;
			Side theSide2 = myUnit.get_UnitSide(SetSideOnly: false);
			Contact theTarget3 = theTarget;
			Random theRNG = GameGeneral.GlobalRNG;
			if (weapon3.ARM_DetermineEmissionToTrack(detectedEmissions2, theSide2, theTarget3, ShootAtTurnedOffRadar: false, ref theRNG))
			{
				goto IL_3000;
			}
			result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("No threat emitters are currently radiating", WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		goto IL_3458;
		IL_3000:
		if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction) || !theWeapon.Flags.LevelCruiseFlight || (!(theWeapon.CruiseAltitude_ASL > 0f) && !(theWeapon.CruiseAltitude_AGL > 0f)) || !theWeapon.IsASCMwithoutTFcapability())
		{
			goto IL_31f2;
		}
		PooledList<TrajectoryPoint> trajectory = new PooledList<TrajectoryPoint>();
		Scenario parentScen = myUnit.ParentScen;
		int dBID = theWeapon.DBID;
		ActiveUnit firingUnit = myUnit;
		double launchLongitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		double launchLatitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
		float launchAltitude = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		int launchSpeed = (int)Math.Round(myUnit.CurrentSpeed);
		double targetLongitude = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
		double targetLatitude = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
		float currentHeading = theTarget.CurrentHeading;
		bool headingIsKnown = theTarget.HeadingIsKnown;
		int targetSpeed = (int)Math.Round(Module_Unit.CurrentSpeed_Horizontal(theTarget));
		bool speedIsKnown = theTarget.SpeedIsKnown;
		float targetAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		bool altitudeIsKnown = theTarget.AltitudeIsKnown;
		float targetVerticalSpeed_mpersec = Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen);
		Contact_Base.ContactType type2 = theTarget.Type;
		GeoPoint InterceptPoint = null;
		string FeedbackText = null;
		float currentHeading2 = myUnit.CurrentHeading;
		int maxQuantity = theWeapon.Fuel_ReadOnly[0].MaxQuantity;
		float FlightTime = 0f;
		(DLZResultEnum, float) tuple3 = TargetIsWithinDLZ(parentScen, dBID, firingUnit, AssumeVerticalLaunch: false, launchLongitude, launchLatitude, launchAltitude, launchSpeed, targetLongitude, targetLatitude, currentHeading, headingIsKnown, targetSpeed, speedIsKnown, targetAltitude, altitudeIsKnown, targetVerticalSpeed_mpersec, type2, ref InterceptPoint, TargetIsTerminalDiving: false, ref FeedbackText, HumanFeedBackNeeded: false, currentHeading2, ActiveUnit.Throttle.Full, ExplicitCourse, maxQuantity, trajectory, ref FlightTime);
		var (dLZResultEnum, _) = tuple3;
		if (dLZResultEnum == DLZResultEnum.Fail_OutOfEnergy)
		{
			result = (HumanFeedBackNeeded ? ("Missile will not be able to reach its target", WeaponPrefireChecklistEvaluation.OutOfRange) : (null, WeaponPrefireChecklistEvaluation.OutOfRange));
		}
		else
		{
			if (dLZResultEnum != DLZResultEnum.Fail_LowAltTerrainCrash)
			{
				goto IL_31f2;
			}
			float num = Math.Max(theWeapon.CruiseAltitude_ASL, theWeapon.CruiseAltitude_AGL);
			result = (HumanFeedBackNeeded ? ("Missile with cruise altitude " + Conversions.ToString(num) + "m will impact terrain elevation on its plotted course, " + Conversions.ToString(tuple3.Item2) + " sec after launch", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		goto IL_3458;
		IL_043c:
		try
		{
			if (theWeapon.IsNuke.Value && myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value != Doctrine._UseNukesAllowed.Yes && !myUnit.IsBallisticMissile)
			{
				if (!HumanFeedBackNeeded)
				{
					result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
					return result;
				}
				result = ("Unit is not authorized to use nuclear weapons", WeaponPrefireChecklistEvaluation.OtherNegative);
				return result;
			}
		}
		catch (Exception ex13)
		{
			ProjectData.SetProjectError(ex13);
			Exception ex14 = ex13;
			ex14?.Data.Add("Error at 9876543210002", "");
			GameGeneral.WriteExceptionsToLog(ex14);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		float num2 = default(float);
		float num3 = default(float);
		float num4;
		if (theWeapon.IsUnguidedBallisticWeapon && theTarget.Type == Contact_Base.ContactType.Facility_Mobile && theTarget.CurrentSpeed > 0f && theTarget.Age > 5f)
		{
			result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Target age is more than 5 secs - need current targeting data to use unguided weapon", WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		else
		{
			try
			{
				num2 = myUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				num3 = Module_Unit.RangeToUnit_Slant(myUnit, theTarget, num2, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				if (type == Weapon._WeaponType.Dispenser && num2 * 1852f > (float)theWeapon.Warheads[0].ClusterBombDispersionAreaLength)
				{
					if (HumanFeedBackNeeded)
					{
						result = ("Target is out of weapon range", WeaponPrefireChecklistEvaluation.OutOfRange);
						return result;
					}
					result = (null, WeaponPrefireChecklistEvaluation.OutOfRange);
					return result;
				}
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15);
				Exception ex16 = ex15;
				ex16?.Data.Add("Error at 98765432100003", "");
				GameGeneral.WriteExceptionsToLog(ex16);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (theTarget.IsBallisticTarget() && (!theTarget.HeadingIsKnown || !theTarget.SpeedIsKnown || !theTarget.AltitudeIsKnown))
			{
				result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Insufficient tracking data for BMD engagement", WeaponPrefireChecklistEvaluation.OtherNegative));
			}
			else if (theWeapon.IsTorpedo && myUnit.IsAircraft && theTarget.Type == Contact_Base.ContactType.Submarine && num2 > 1f)
			{
				result = (HumanFeedBackNeeded ? ("ASW torpedo must be dropped within 1nm of contact/aimpoint", WeaponPrefireChecklistEvaluation.OutOfRange) : (null, WeaponPrefireChecklistEvaluation.OutOfRange));
			}
			else
			{
				num4 = 0f;
				try
				{
					num4 = WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref theTarget, ManualFire);
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ex18?.Data.Add("Error at 98765432100004", "");
					GameGeneral.WriteExceptionsToLog(ex18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (num4 == 0f)
				{
					_ = Debugger.IsAttached;
				}
				if (!theWeapon.IsGuidedOrUnguidedGun())
				{
					if (!(num4 < num2))
					{
						goto IL_073e;
					}
					result = (HumanFeedBackNeeded ? ("Target is out of weapon range (horiz)", WeaponPrefireChecklistEvaluation.OutOfRange) : (null, WeaponPrefireChecklistEvaluation.OutOfRange));
				}
				else
				{
					if (!(num4 < num3))
					{
						goto IL_073e;
					}
					result = (HumanFeedBackNeeded ? ("Target is out of weapon range (slant)", WeaponPrefireChecklistEvaluation.OutOfRange) : (null, WeaponPrefireChecklistEvaluation.OutOfRange));
				}
			}
		}
		goto IL_3458;
		IL_2013:
		int num5;
		bool gunDirectorFound = (byte)num5 != 0;
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl))
		{
			try
			{
				if (!myUnit.IsAircraft && type == Weapon._WeaponType.Gun && !theWeapon.IsMortarRound() && theTarget.Type != Contact_Base.ContactType.Facility_Fixed && theTarget.Type != Contact_Base.ContactType.Facility_Mobile && theTarget.Type != Contact_Base.ContactType.AggregateGroundUnit && theMount != null && !theMount.LocalControl)
				{
					if (method_11(theMount, theTarget).Count == 0)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						result = ("Gun has no local control and no available directors", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					gunDirectorFound = true;
				}
			}
			catch (Exception ex19)
			{
				ProjectData.SetProjectError(ex19);
				Exception ex20 = ex19;
				ex20?.Data.Add("Error at 987654321000024", "");
				GameGeneral.WriteExceptionsToLog(ex20);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			gunDirectorFound = true;
		}
		List<ActiveUnit> list = default(List<ActiveUnit>);
		if (!theTarget.IsFirm && !theWeapon.CanBeFiredOnAmbigousTarget(theTarget, gunDirectorFound))
		{
			bool flag4 = false;
			Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
			foreach (Sensor sensor2 in sensors_Cached2)
			{
				try
				{
					if (!sensor2.CanIlluminateForThisWeapon(ref theWeapon) || !sensor2.get_IsPrecise(num3))
					{
						continue;
					}
					if (list == null)
					{
						list = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
					}
					float targetSlantRange = (theWeapon.IsGuidedOrUnguidedGun() ? num3 : num2);
					ActiveUnit sensorParent = myUnit;
					ActiveUnit actualUnit = theTarget.ActualUnit;
					List<Geopoint_Struct> UncertaintyArea = null;
					Dictionary<int, EmissionContainer> DetectedEmissions = null;
					List<ActiveUnit> affectingJammers = list;
					bool? LOS_Exists_Radar = null;
					bool? LOS_Exists_RadarSW = null;
					Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Sonar = null;
					bool? LOS_Exists_ESM = null;
					bool? LOS_Exists_ESM_SW = null;
					if (!sensor2.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, sensorParent, actualUnit, ref UncertaintyArea, targetSlantRange, ref DetectedEmissions, affectingJammers, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
					{
						continue;
					}
					float num6 = ((!theWeapon.IsGuidedOrUnguidedGun()) ? myUnit.RangeToUnit_Horiz(theTarget.ActualUnit) : Module_Unit.RangeToUnit_Slant(myUnit, theTarget.ActualUnit));
					ActiveUnit sensorParent2 = myUnit;
					ActiveUnit actualUnit2 = theTarget.ActualUnit;
					UncertaintyArea = null;
					DetectedEmissions = null;
					List<ActiveUnit> affectingJammers2 = list;
					LOS_Exists_ESM_SW = null;
					LOS_Exists_ESM = null;
					LOS_Exists_Visual = null;
					LOS_Exists_Sonar = null;
					LOS_Exists_RadarSW = null;
					LOS_Exists_Radar = null;
					if (!sensor2.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, sensorParent2, actualUnit2, ref UncertaintyArea, num6, ref DetectedEmissions, affectingJammers2, ref LOS_Exists_ESM_SW, ref LOS_Exists_ESM, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_RadarSW, ref LOS_Exists_Radar))
					{
						continue;
					}
					if (type == Weapon._WeaponType.Dispenser && num6 * 1852f > (float)theWeapon.Warheads[0].ClusterBombDispersionAreaLength)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						result = ("Weapon is unable to engage imprecise target that is out of weapon range", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					if (theWeapon.IsTorpedo && myUnit.IsAircraft && theTarget.Type == Contact_Base.ContactType.Submarine && (double)num6 > 0.4)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						result = ("Weapon is unable to engage imprecise target since ASW torpedo must be dropped within 0.4nm of contact/aimpoint", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					if (WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref theTarget, ManualFire) < num6)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						result = ("Weapon is unable to engage imprecise target that is out of weapon range", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					if (!theWeapon.IsWithinMinRangeOfTarget(num6, theTarget))
					{
						flag4 = true;
						break;
					}
					if (HumanFeedBackNeeded)
					{
						result = ("Weapon is unable to engage imprecise target that is within weapon minimum range", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
					return result;
				}
				catch (Exception ex21)
				{
					ProjectData.SetProjectError(ex21);
					Exception ex22 = ex21;
					ex22?.Data.Add("Error at 987654321000025", "");
					GameGeneral.WriteExceptionsToLog(ex22);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!flag4)
			{
				result = (HumanFeedBackNeeded ? ("Weapon is unable to engage imprecise target", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
				goto IL_3458;
			}
		}
		if (theWeapon.Guidance == Weapon.WeaponGuidanceType.Passive && (!theWeapon.IsMissile || theTarget.Type != Contact_Base.ContactType.Air || !myUnit.IsAircraft || !((Aircraft)myUnit).HasHelmetMountedSight))
		{
			try
			{
				Sensor sensor3 = theWeapon.WeaponSensors()[0];
				Weapon sensorParent3 = theWeapon;
				ActiveUnit actualUnit3 = theTarget.ActualUnit;
				List<Geopoint_Struct> UncertaintyArea = null;
				float targetSlantRange2 = num2;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Sonar = null;
				bool? LOS_Exists_ESM = null;
				bool? LOS_Exists_ESM_SW = null;
				Dictionary<int, EmissionContainer> DetectedEmissions2 = default(Dictionary<int, EmissionContainer>);
				if (!sensor3.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, sensorParent3, actualUnit3, ref UncertaintyArea, targetSlantRange2, ref DetectedEmissions2, null, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
				{
					if (HumanFeedBackNeeded)
					{
						result = ("Weapon must detect target prior to firing", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
					result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
					return result;
				}
			}
			catch (Exception ex23)
			{
				ProjectData.SetProjectError(ex23);
				Exception ex24 = ex23;
				ex24?.Data.Add("Error at 987654321000026", "");
				GameGeneral.WriteExceptionsToLog(ex24);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		CommDevice[] comms_ReadOnly = theWeapon.Comms_ReadOnly;
		if (comms_ReadOnly.Length > 0 && !comms_ReadOnly[0].IsOptional && ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(theWeapon, comms_ReadOnly, myUnit, IgnoreChannelCount: false, null, null, onlyOneRequired: true).CommDevice == null)
		{
			result = (HumanFeedBackNeeded ? ("Unable to connect to firing unit with mandatory datalink", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		else
		{
			int num7;
			if (theWeapon.Flags.IlluminateAtLaunch)
			{
				num7 = 0;
			}
			else
			{
				if (!theWeapon.Flags.TerminalIllumination)
				{
					goto IL_2976;
				}
				num7 = 0;
			}
			bool flag5 = (byte)num7 != 0;
			bool flag6 = false;
			bool flag7 = false;
			List<Sensor> list2 = new List<Sensor>();
			Sensor[] sensors_Cached3 = myUnit.Sensors_Cached;
			foreach (Sensor sensor4 in sensors_Cached3)
			{
				if (sensor4.Status == PlatformComponent._ComponentStatus.Operational && sensor4.CanIlluminateForThisWeapon(ref theWeapon))
				{
					list2.Add(sensor4);
				}
			}
			if (list2.Count > 0)
			{
				flag5 = true;
				List<Sensor> list3 = new List<Sensor>();
				foreach (Sensor item in list2)
				{
					if (theWeapon.Guidance == Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive)
					{
						list3.Add(item);
					}
					else if (item.TargetsTrackedForFireControl_Readonly.Count < item.MaxIlluminate || item.IsTrackingThisTargetForFireControl(ref theTarget))
					{
						list3.Add(item);
					}
				}
				if (list3.Count > 0)
				{
					flag6 = true;
					new List<Sensor>();
					Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual2 = null;
					bool? LOS_Exists_Radar2 = null;
					bool? LOS_Exists_RadarSW2 = null;
					bool? LOS_Exists_Sonar2 = null;
					foreach (Sensor item2 in list3)
					{
						try
						{
							if (item2.Type == Sensor.Sensor_Type.Radar && list == null)
							{
								list = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
							}
							if (item2.CanIlluminateTarget(myUnit, ref theTarget, ref myUnit.ParentScen, num3, list, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar2, ref LOS_Exists_RadarSW2, ref LOS_Exists_Visual2, ref LOS_Exists_Sonar2) == Sensor.SensorDetectionCheckResult.Success)
							{
								SuitableDirectorSensor = item2;
								flag7 = true;
								break;
							}
						}
						catch (Exception ex25)
						{
							ProjectData.SetProjectError(ex25);
							Exception ex26 = ex25;
							ex26?.Data.Add("Error at 987654321000027", "");
							GameGeneral.WriteExceptionsToLog(ex26);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			if (!flag5 || !flag6 || !flag7)
			{
				try
				{
					Sensor SuitableIlluminator = default(Sensor);
					if (myUnit.IsMobileGroundUnit && myUnit.IsGroupMember())
					{
						List<ActiveUnit> list4 = theWeapon.FetchAvailableIlluminators_VehicleGroup(new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values), theTarget);
						foreach (ActiveUnit item3 in list4)
						{
							if (item3 != null)
							{
								ActiveUnit_Sensory sensory = item3.Sensory;
								Contact theContact = theTarget;
								Weapon theWeapon2 = theWeapon;
								bool? LOS_Exists_ESM_SW = null;
								bool? LOS_Exists_ESM = null;
								Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
								bool? LOS_Exists_Sonar = null;
								if (sensory.CanIlluminateThisContactForThisWeapon(theContact, theWeapon2, ref SuitableIlluminator, ref LOS_Exists_ESM_SW, ref LOS_Exists_ESM, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
								{
									SuitableDirectorSensor = SuitableIlluminator;
								}
							}
						}
					}
					else if (theWeapon.Flags.SupportsBuddyIllumination)
					{
						PooledList<ActiveUnit> pooledList = theWeapon.FetchAvailableBuddyIlluminatorUnits(myUnit.get_UnitSide(SetSideOnly: false), theTarget);
						if (pooledList != null)
						{
							foreach (ActiveUnit item4 in pooledList)
							{
								if (item4 != null)
								{
									ActiveUnit_Sensory sensory2 = item4.Sensory;
									Contact theContact2 = theTarget;
									Weapon theWeapon3 = theWeapon;
									bool? LOS_Exists_Sonar = null;
									bool? LOS_Exists_ESM = null;
									Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
									bool? LOS_Exists_ESM_SW = null;
									if (sensory2.CanIlluminateThisContactForThisWeapon(theContact2, theWeapon3, ref SuitableIlluminator, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_Visual, ref LOS_Exists_ESM_SW))
									{
										SuitableDirectorSensor = SuitableIlluminator;
									}
								}
							}
							pooledList.Dispose();
						}
					}
				}
				catch (Exception ex27)
				{
					ProjectData.SetProjectError(ex27);
					Exception ex28 = ex27;
					ex28?.Data.Add("Error at 987654321000028", "");
					GameGeneral.WriteExceptionsToLog(ex28);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (SuitableDirectorSensor != null)
			{
				goto IL_2976;
			}
			if (!flag5)
			{
				result = (HumanFeedBackNeeded ? ("No weapons director available to illuminate the target", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.CannotIlluminate_NoDirectorAvailable));
			}
			else if (!flag6)
			{
				result = (HumanFeedBackNeeded ? ("All illumination channels suitable for this weapon are in use", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.CannotIlluminate_NoChannelAvailable));
			}
			else
			{
				if (flag7)
				{
					goto IL_2976;
				}
				result = (HumanFeedBackNeeded ? ("No directors are able to illuminate this target (insufficient reflection, no LOS etc)", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.CannotIlluminate_InsufficientReflectionOrBlocked));
			}
		}
		goto IL_3458;
		IL_2c3c:
		TrajectoryPoint[] futureBallisticPath;
		int num8;
		bool flag8;
		if (flag8)
		{
			if (flag8 && futureBallisticPath.Length > 1)
			{
				if (num8 != 0)
				{
					if (num8 == futureBallisticPath.Length)
					{
						num8 = futureBallisticPath.Length - 1;
					}
				}
				else
				{
					num8 = 1;
				}
				TrajectoryPoint trajectoryPoint = futureBallisticPath[num8 - 1];
				TrajectoryPoint trajectoryPoint2 = futureBallisticPath[num8];
				double num9 = trajectoryPoint.Latitude * 3.14159265358979 / 180.0;
				double num10 = trajectoryPoint.Longitude * 3.14159265358979 / 180.0;
				double num11 = trajectoryPoint2.Latitude * 3.14159265358979 / 180.0;
				double num12 = trajectoryPoint2.Longitude * 3.14159265358979 / 180.0;
				double num13 = num11 - num9;
				double num14 = num12 - num10;
				double num15 = Math.Pow(Math.Sin(num13 / 2.0), 2.0) + Math.Cos(num9) * Math.Cos(num11) * Math.Pow(Math.Sin(num14 / 2.0), 2.0);
				double num16 = 2.0 * Math.Atan2(Math.Sqrt(num15), Math.Sqrt(1.0 - num15));
				double x = 6371.0 * num16;
				double x2 = trajectoryPoint2.Altitude * 0.3048f - trajectoryPoint.Altitude * 0.3048f;
				float float_ = Convert.ToSingle(Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(x2, 2.0)));
				try
				{
					(string, WeaponPrefireChecklistEvaluation) tuple5 = method_8(theWeapon, null, float_, HumanFeedBackNeeded);
					if (tuple5.Item2 != WeaponPrefireChecklistEvaluation.OK)
					{
						result = tuple5;
						return result;
					}
				}
				catch (Exception ex29)
				{
					ProjectData.SetProjectError(ex29);
					Exception ex30 = ex29;
					ex30?.Data.Add("Error at 987654321000031", "");
					GameGeneral.WriteExceptionsToLog(ex30);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			goto IL_2e58;
		}
		result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("No point in the target's estimated trajectory is within the weapon's engagement envelope", WeaponPrefireChecklistEvaluation.OtherNegative));
		goto IL_3458;
		IL_073e:
		try
		{
			if (num2 > num4 && Module_Unit.ClosureSpeed(myUnit, theTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading) <= 0f)
			{
				if (!HumanFeedBackNeeded)
				{
					result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
					return result;
				}
				result = ("Impossible to intercept target", WeaponPrefireChecklistEvaluation.OtherNegative);
				return result;
			}
		}
		catch (Exception ex31)
		{
			ProjectData.SetProjectError(ex31);
			Exception ex32 = ex31;
			ex32?.Data.Add("Error at 98765432100006", "");
			GameGeneral.WriteExceptionsToLog(ex32);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (theWeapon.IsGuidedOrUnguidedGun())
			{
				if (theWeapon.IsWithinMinRangeOfTarget(num3, theTarget))
				{
					if (!HumanFeedBackNeeded)
					{
						result = (null, WeaponPrefireChecklistEvaluation.WithinMinimumRange);
						return result;
					}
					result = ("Target is within weapon minimum range", WeaponPrefireChecklistEvaluation.WithinMinimumRange);
					return result;
				}
			}
			else if (theWeapon.isLoiterCapable && theWeapon.LaunchPoint != null)
			{
				float num17 = num2;
				float num18 = theWeapon.MinRangeForTarget(theTarget);
				Geopoint_Struct Point = theWeapon.LaunchPoint.ToGeopoint_Struct();
				Geopoint_Struct Point2 = theTarget.Location;
				if (num17 < num18 - Math2.CalcDist(ref Point, ref Point2))
				{
					if (HumanFeedBackNeeded)
					{
						result = ("Target is within weapon minimum range", WeaponPrefireChecklistEvaluation.WithinMinimumRange);
						return result;
					}
					result = (null, WeaponPrefireChecklistEvaluation.WithinMinimumRange);
					return result;
				}
			}
			else if (theWeapon.IsWithinMinRangeOfTarget(num2, theTarget))
			{
				if (!HumanFeedBackNeeded)
				{
					result = (null, WeaponPrefireChecklistEvaluation.WithinMinimumRange);
					return result;
				}
				result = ("Target is within weapon minimum range", WeaponPrefireChecklistEvaluation.WithinMinimumRange);
				return result;
			}
		}
		catch (Exception ex33)
		{
			ProjectData.SetProjectError(ex33);
			Exception ex34 = ex33;
			ex34?.Data.Add("Error at 87641841987491847", "");
			GameGeneral.WriteExceptionsToLog(ex34);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		ActiveUnit actualUnit4 = theTarget.ActualUnit;
		if (actualUnit4 != null && actualUnit4.IsAerospaceUnit && theTarget.ActualUnit.CurrentAltitude_AGL < theWeapon.MinTargetAlt_AGL)
		{
			result = (HumanFeedBackNeeded ? ("Target is below the weapon's minimum AGL engagement altitude", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
		}
		else
		{
			if (myUnit.IsAircraft && !theTarget.IsAir_Missile_Orbital_Contact && !theTarget.IsSubmergedContact && theWeapon.IsUnguidedBallisticWeapon)
			{
				try
				{
					float num19 = theWeapon.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, theTarget.Type);
					if (num19 >= 0f && num2 > num19)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						stringBuilder_0.Clear();
						stringBuilder_0.Append("Horizontal range to target (").Append(Math.Round(num2, 1)).Append("nm) is greater than the weapon's downrange at this altitude (")
							.Append(Math.Round(num19))
							.Append("nm)");
						result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
				}
				catch (Exception ex35)
				{
					ProjectData.SetProjectError(ex35);
					Exception ex36 = ex35;
					ex36?.Data.Add("Error at 98765432100007", "");
					GameGeneral.WriteExceptionsToLog(ex36);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (theWeapon.IsMissile && theWeapon.IsAAWCapable)
				{
					Contact_Base.ContactType type3 = theTarget.Type;
					if (type3 == Contact_Base.ContactType.Surface && myUnit.Doctrine.get_UseSAMsOnASuW(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value != Doctrine._UseSAMsAgainstShips.Yes)
					{
						if (!HumanFeedBackNeeded)
						{
							result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
							return result;
						}
						result = ("Unit is not authorized to use SAMs against surface targets", WeaponPrefireChecklistEvaluation.OtherNegative);
						return result;
					}
				}
			}
			catch (Exception ex37)
			{
				ProjectData.SetProjectError(ex37);
				Exception ex38 = ex37;
				ex38?.Data.Add("Error at 98765432100008", "");
				GameGeneral.WriteExceptionsToLog(ex38);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (!theTarget.IsBallisticTarget())
			{
				try
				{
					(string, WeaponPrefireChecklistEvaluation) tuple6 = method_8(theWeapon, theTarget, 0f, HumanFeedBackNeeded);
					if (tuple6.Item2 != WeaponPrefireChecklistEvaluation.OK)
					{
						result = tuple6;
						return result;
					}
				}
				catch (Exception ex39)
				{
					ProjectData.SetProjectError(ex39);
					Exception ex40 = ex39;
					ex40?.Data.Add("Error at 98765432100009", "");
					GameGeneral.WriteExceptionsToLog(ex40);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (theTarget.Type == Contact_Base.ContactType.ActivationPoint && !theWeapon.BOL_Capable && !theWeapon.IsDeployablePlatform())
			{
				result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Weapon is not BOL-capable", WeaponPrefireChecklistEvaluation.OtherNegative));
			}
			else
			{
				string text2 = method_5(theWeapon, theTarget);
				if (string.CompareOrdinal(text2, "OK") == 0)
				{
					if (!theTarget.IsBallisticTarget() && myUnit.ParentScen.FeatureCompatibility.get_WeaponSnapUpDown(myUnit.ParentScen.DBConnection))
					{
						try
						{
							if (theWeapon.SnapUpDown > 0f && theTarget.IsAir_Missile_Orbital_Contact)
							{
								float num20 = Math.Abs(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
								if (num20 > theWeapon.SnapUpDown)
								{
									if (!HumanFeedBackNeeded)
									{
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									stringBuilder_0.Clear();
									if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										stringBuilder_0.Append("Difference in altitude (").Append((int)Math.Round(num20)).Append(" m) is larger than the weapon's snap-up/down ability (")
											.Append((int)Math.Round(theWeapon.SnapUpDown))
											.Append(" m)");
										result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									stringBuilder_0.Append("Difference in altitude (").Append((int)Math.Round(num20 * 3.28084f)).Append(" ft) is larger than the weapon's snap-up/down ability (")
										.Append((int)Math.Round(theWeapon.SnapUpDown * 3.28084f))
										.Append(" ft)");
									result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
									return result;
								}
							}
						}
						catch (Exception ex41)
						{
							ProjectData.SetProjectError(ex41);
							Exception ex42 = ex41;
							ex42?.Data.Add("Error at 987654321000010", "");
							GameGeneral.WriteExceptionsToLog(ex42);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!theWeapon.IsNuke.Value && theTarget.Type == Contact_Base.ContactType.Submarine && (type == Weapon._WeaponType.DepthCharge || type == Weapon._WeaponType.Rocket) && theTarget.UncertaintyArea != null)
					{
						result = (HumanFeedBackNeeded ? ("Weapon needs a precise target location", WeaponPrefireChecklistEvaluation.OtherNegative) : (null, WeaponPrefireChecklistEvaluation.OtherNegative));
					}
					else
					{
						if (theMount != null)
						{
							int num21 = default(int);
							foreach (WeaponRec mountWeapon in theMount.MountWeapons)
							{
								if (mountWeapon.int_3 == theWeapon.DBID)
								{
									num21 += mountWeapon.CurrentLoad;
								}
							}
							if (num21 == 0)
							{
								result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Weapon is not loaded on mount", WeaponPrefireChecklistEvaluation.OtherNegative));
								goto IL_3458;
							}
						}
						try
						{
							theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, myUnit.get_Latitude(GlobalVariables.ObjectTrue));
							theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, myUnit.get_Longitude(GlobalVariables.ObjectTrue));
							if (theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
							{
								theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							}
							if (!myUnit.IsAircraft)
							{
								if (!myUnit.IsFacility && !myUnit.IsShip)
								{
									if (myUnit.IsSubmarine)
									{
										if (theWeapon.IsAAWCapable)
										{
											theWeapon.CurrentHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
										}
										else
										{
											theWeapon.CurrentHeading = myUnit.CurrentHeading;
										}
									}
								}
								else
								{
									theWeapon.CurrentHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
								}
							}
							else
							{
								theWeapon.CurrentHeading = myUnit.CurrentHeading;
							}
						}
						catch (Exception ex43)
						{
							ProjectData.SetProjectError(ex43);
							Exception ex44 = ex43;
							ex44?.Data.Add("Error at 987654321000011", "");
							GameGeneral.WriteExceptionsToLog(ex44);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							(string, WeaponryAltitudeCheckResult) tuple7 = IsWeaponWithinFiringParams_LaunchAltitude(theWeapon, theTarget, ref ASL_atFiringUnit, HumanFeedBackNeeded);
							if (tuple7.Item2 != WeaponryAltitudeCheckResult.OK)
							{
								result = (tuple7.Item1, WeaponPrefireChecklistEvaluation.OtherNegative);
								return result;
							}
						}
						catch (Exception ex45)
						{
							ProjectData.SetProjectError(ex45);
							Exception ex46 = ex45;
							ex46?.Data.Add("Error at 987654321000012", "");
							GameGeneral.WriteExceptionsToLog(ex46);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (myUnit.IsSubmarine)
						{
							if (!theWeapon.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(theWeapon.ParentScen.DBConnection))
							{
								try
								{
									if ((double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (double)theWeapon.MaxLaunchAlt_AGL + 0.1)
									{
										if (!HumanFeedBackNeeded)
										{
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										stringBuilder_0.Clear();
										if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											stringBuilder_0.Append("Submarine too shallow to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)).Append(" to ")
												.Append((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f))
												.Append(" ft)");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										stringBuilder_0.Append("Submarine too shallow to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_AGL)).Append(" to ")
											.Append((int)Math.Round(theWeapon.MaxLaunchAlt_AGL))
											.Append(" m)");
										result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									if ((double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (double)theWeapon.MinLaunchAlt_AGL - 0.1)
									{
										if (HumanFeedBackNeeded)
										{
											stringBuilder_0.Clear();
											if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												stringBuilder_0.Append("Submarine too deep to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_AGL * 3.28084f)).Append(" to ")
													.Append((int)Math.Round(theWeapon.MaxLaunchAlt_AGL * 3.28084f))
													.Append(" ft)");
												result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
												return result;
											}
											stringBuilder_0.Append("Submarine too deep to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_AGL)).Append(" to ")
												.Append((int)Math.Round(theWeapon.MaxLaunchAlt_AGL))
												.Append(" m)");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
								catch (Exception ex47)
								{
									ProjectData.SetProjectError(ex47);
									Exception ex48 = ex47;
									ex48?.Data.Add("Error at 987654321000013", "");
									GameGeneral.WriteExceptionsToLog(ex48);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								try
								{
									if ((double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (double)theWeapon.MaxLaunchAlt_ASL + 0.1)
									{
										if (!HumanFeedBackNeeded)
										{
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										stringBuilder_0.Clear();
										if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
										{
											stringBuilder_0.Append("Submarine too shallow to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)).Append(" to ")
												.Append((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f))
												.Append(" ft)");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										stringBuilder_0.Append("Submarine too shallow to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_ASL)).Append(" to ")
											.Append((int)Math.Round(theWeapon.MaxLaunchAlt_ASL))
											.Append(" m)");
										result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
								catch (Exception ex49)
								{
									ProjectData.SetProjectError(ex49);
									Exception ex50 = ex49;
									ex50?.Data.Add("Error at 987654321000014", "");
									GameGeneral.WriteExceptionsToLog(ex50);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
								try
								{
									if ((double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (double)theWeapon.MinLaunchAlt_ASL - 0.1)
									{
										if (HumanFeedBackNeeded)
										{
											stringBuilder_0.Clear();
											if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
											{
												stringBuilder_0.Append("Submarine too deep to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_ASL)).Append(" to ")
													.Append((int)Math.Round(theWeapon.MaxLaunchAlt_ASL))
													.Append(" m)");
												result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
												return result;
											}
											stringBuilder_0.Append("Submarine too deep to launch (Valid: ").Append((int)Math.Round(theWeapon.MinLaunchAlt_ASL * 3.28084f)).Append(" to ")
												.Append((int)Math.Round(theWeapon.MaxLaunchAlt_ASL * 3.28084f))
												.Append(" ft)");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
								catch (Exception ex51)
								{
									ProjectData.SetProjectError(ex51);
									Exception ex52 = ex51;
									ex52?.Data.Add("Error at 987654321000015", "");
									GameGeneral.WriteExceptionsToLog(ex52);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						if (!IgnoreAircraftOrientation && !theWeapon.IsDeployablePlatform())
						{
							try
							{
								if (myUnit.IsAircraft && myUnit.CurrentSpeed > 0f)
								{
									if (theMount != null)
									{
										if (!theMount.TargetIsWithinCoverageArc(theTarget))
										{
											if (HumanFeedBackNeeded)
											{
												result = ("Target is outside the weapon mount's engagement arc (within 5nm)", WeaponPrefireChecklistEvaluation.OtherNegative);
												return result;
											}
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
									}
									else
									{
										string feedBackMessage = string.Empty;
										if (!TargetIsWithinWeaponBoresightArc(theWeapon, theTarget, ref feedBackMessage))
										{
											result = (feedBackMessage, WeaponPrefireChecklistEvaluation.OutsideBoresightLimits);
											return result;
										}
									}
								}
							}
							catch (Exception ex53)
							{
								ProjectData.SetProjectError(ex53);
								Exception ex54 = ex53;
								ex54?.Data.Add("Error at 987654321000016", "");
								GameGeneral.WriteExceptionsToLog(ex54);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (theTarget.Type == Contact_Base.ContactType.Air)
						{
							try
							{
								if (theWeapon.Flags.SternChase_AAM)
								{
									Weapon weapon4 = theWeapon;
									Contact observerUnit = theTarget;
									FeedbackText = "";
									float num22 = Module_Unit.AngleOffThisUnitsBoresight(weapon4, observerUnit, DistinguishBetweenStarboardAndPort: true, ref FeedbackText, GlobalVariables.ObjectTrue);
									if (Math.Abs(num22) < 130f)
									{
										if (HumanFeedBackNeeded)
										{
											stringBuilder_0.Clear();
											stringBuilder_0.Append("Target aspect (").Append(Math.Abs((int)Math.Round(num22))).Append(" deg) is out of envelope for a stern-chase weapon");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
								if (theWeapon.Flags.RearAspect_AAM)
								{
									Weapon weapon5 = theWeapon;
									Contact observerUnit2 = theTarget;
									FeedbackText = "";
									float num23 = Module_Unit.AngleOffThisUnitsBoresight(weapon5, observerUnit2, DistinguishBetweenStarboardAndPort: true, ref FeedbackText, GlobalVariables.ObjectTrue);
									if (Math.Abs(num23) < 100f)
									{
										if (HumanFeedBackNeeded)
										{
											stringBuilder_0.Clear();
											stringBuilder_0.Append("Target aspect (").Append(Math.Abs((int)Math.Round(num23))).Append(" deg) is out of envelope for a rear-aspect weapon");
											result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
							}
							catch (Exception ex55)
							{
								ProjectData.SetProjectError(ex55);
								Exception ex56 = ex55;
								ex56?.Data.Add("Error at 987654321000017", "");
								GameGeneral.WriteExceptionsToLog(ex56);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (myUnit.IsAircraft)
						{
							try
							{
								float num24 = myUnit.AI.TargetingDelayForThisTarget(theTarget);
								if (num24 > 0f)
								{
									if (!HumanFeedBackNeeded)
									{
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									stringBuilder_0.Clear();
									stringBuilder_0.Append("Weapon cannot engage this target for another ").Append(Math.Round(num24, 1)).Append("sec (OODA loop limitation)");
									result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
									return result;
								}
							}
							catch (Exception ex57)
							{
								ProjectData.SetProjectError(ex57);
								Exception ex58 = ex57;
								ex58?.Data.Add("Error at 987654321000018", "");
								GameGeneral.WriteExceptionsToLog(ex58);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else if (theMount != null)
						{
							try
							{
								if (!theMount.IsAutonomous)
								{
									float num25 = myUnit.AI.TargetingDelayForThisTarget(theTarget);
									if (num25 > 0f)
									{
										if (!HumanFeedBackNeeded)
										{
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										stringBuilder_0.Clear();
										stringBuilder_0.Append("Weapon cannot engage this target for another ").Append(Math.Round(num25, 1)).Append("sec (OODA loop limitation)");
										result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
							}
							catch (Exception ex59)
							{
								ProjectData.SetProjectError(ex59);
								Exception ex60 = ex59;
								ex60?.Data.Add("Error at 987654321000019", "");
								GameGeneral.WriteExceptionsToLog(ex60);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						try
						{
							if (theMount != null && num2 <= 5f && !theMount.TargetIsWithinCoverageArc(theTarget))
							{
								result = ("Target is outside the weapon mount's engagement arc (within 5nm)", WeaponPrefireChecklistEvaluation.OtherNegative);
								return result;
							}
						}
						catch (Exception ex61)
						{
							ProjectData.SetProjectError(ex61);
							Exception ex62 = ex61;
							ex62?.Data.Add("Error at 987654321000020", "");
							GameGeneral.WriteExceptionsToLog(ex62);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (theTarget.Type == Contact_Base.ContactType.ActivationPoint)
						{
							result = ("OK", WeaponPrefireChecklistEvaluation.OK);
						}
						else if (theTarget.ActualUnit == null)
						{
							result = ((!myUnit.IsWeapon) ? ("Contact vanished", WeaponPrefireChecklistEvaluation.OtherNegative) : ("OK", WeaponPrefireChecklistEvaluation.OK));
						}
						else
						{
							try
							{
								if (theTarget.ActualUnit.IsShip || theTarget.ActualUnit.IsSubmarine || theTarget.ActualUnit.IsFacility)
								{
									string text3 = IsWeaponSuitableForTargetAmbiguity(theWeapon, theTarget);
									if (string.CompareOrdinal(text3, "OK") != 0)
									{
										result = (text3, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
							}
							catch (Exception ex63)
							{
								ProjectData.SetProjectError(ex63);
								Exception ex64 = ex63;
								ex64?.Data.Add("Error at 987654321000021", "");
								GameGeneral.WriteExceptionsToLog(ex64);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								if (SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null)))
								{
									if ((myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && theTarget.ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) || (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && theTarget.ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f))
									{
										if (HumanFeedBackNeeded)
										{
											result = ("Cannot fire weapon through ice", WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && theWeapon.IsMissile)
									{
										if (HumanFeedBackNeeded)
										{
											result = ("Cannot fire missile while under ice", WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && theWeapon.IsTorpedo)
									{
										if (!HumanFeedBackNeeded)
										{
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = ("Cannot use torpedo on ice", WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
									if (theTarget.IsSubmergedContact && myUnit.IsShip && theWeapon.IsMissile)
									{
										if (!HumanFeedBackNeeded)
										{
											result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
											return result;
										}
										result = ("Cannot use missiles against under-ice submarine", WeaponPrefireChecklistEvaluation.OtherNegative);
										return result;
									}
								}
							}
							catch (Exception ex65)
							{
								ProjectData.SetProjectError(ex65);
								Exception ex66 = ex65;
								ex66?.Data.Add("Error at 987654321000022", "");
								GameGeneral.WriteExceptionsToLog(ex66);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							if ((type != Weapon._WeaponType.Laser && type != Weapon._WeaponType.Microwave && type != Weapon._WeaponType.LaserDazzler) || theTarget.ActualUnit == null || Module_Unit.Has_Visual_LOS_ToUnit(myUnit, null, theTarget.ActualUnit, ref myUnit.ParentScen, ConsiderClouds: true) == Module_Unit.Unit.LOSCheckResult.Success)
							{
								if (type == Weapon._WeaponType.Microwave && theMount != null)
								{
									Mount mount = null;
									foreach (UnguidedWeapon value3 in myUnit.ParentScen.UnguidedWeapons.Values)
									{
										if (value3.Type != Weapon._WeaponType.Microwave || (object)value3.Target != theTarget.ActualUnit || string.IsNullOrEmpty(value3.FiringWeaponRec_ID))
										{
											continue;
										}
										foreach (Mount mount2 in myUnit.Mounts)
										{
											foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
											{
												if (Operators.CompareString(mountWeapon2.ObjectID, value3.FiringWeaponRec_ID, false) == 0)
												{
													mount = mount2;
													break;
												}
											}
										}
									}
									if (mount == theMount)
									{
										result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Mount already beaming at this target", WeaponPrefireChecklistEvaluation.OtherNegative));
										goto IL_3458;
									}
									int num26 = 0;
									foreach (UnguidedWeapon value4 in myUnit.ParentScen.UnguidedWeapons.Values)
									{
										if (value4.Type != Weapon._WeaponType.Microwave || string.IsNullOrEmpty(value4.FiringWeaponRec_ID))
										{
											continue;
										}
										foreach (WeaponRec mountWeapon3 in theMount.MountWeapons)
										{
											if (Operators.CompareString(mountWeapon3.ObjectID, value4.FiringWeaponRec_ID, false) == 0)
											{
												num26++;
											}
										}
									}
									Sensor sensor5 = default(Sensor);
									try
									{
										sensor5 = theWeapon.Sensors_Cached[0];
									}
									catch (Exception ex67)
									{
										ProjectData.SetProjectError(ex67);
										Exception ex68 = ex67;
										ex68?.Data.Add("Error at 987654321000022", "");
										GameGeneral.WriteExceptionsToLog(ex68);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
									if (num26 > sensor5.MaxIlluminate)
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
											num5 = 0;
											goto IL_2013;
										}
									}
									else
									{
										if (num26 == sensor5.MaxIlluminate)
										{
											result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Mount already fully committed", WeaponPrefireChecklistEvaluation.OtherNegative));
											goto IL_3458;
										}
										if (num26 > 0)
										{
											List<Module_Unit.Unit> list5 = new List<Module_Unit.Unit>();
											foreach (UnguidedWeapon value5 in myUnit.ParentScen.UnguidedWeapons.Values)
											{
												if (value5.FiringParent != myUnit)
												{
													continue;
												}
												foreach (WeaponRec mountWeapon4 in theMount.MountWeapons)
												{
													if (Operators.CompareString(mountWeapon4.ObjectID, value5.FiringWeaponRec_ID, false) == 0)
													{
														list5.Add(value5.Target);
													}
												}
											}
											if (list5.Count != 0)
											{
												try
												{
													list5.Add(theTarget);
													if (!BearingForSensorBoresightToCoverMultipleTargets(sensor5, list5).HasValue)
													{
														if (!HumanFeedBackNeeded)
														{
															result = (null, WeaponPrefireChecklistEvaluation.OtherNegative);
															return result;
														}
														result = ("Mount cannot engage this target without interrupting existing engagements", WeaponPrefireChecklistEvaluation.OtherNegative);
														return result;
													}
												}
												catch (Exception ex69)
												{
													ProjectData.SetProjectError(ex69);
													Exception ex70 = ex69;
													ex70?.Data.Add("Error at 987654321000023", "");
													GameGeneral.WriteExceptionsToLog(ex70);
													if (Debugger.IsAttached)
													{
														Debugger.Break();
													}
													ProjectData.ClearProjectError();
												}
											}
										}
									}
								}
								num5 = 0;
								goto IL_2013;
							}
							result = ((!HumanFeedBackNeeded) ? (null, WeaponPrefireChecklistEvaluation.OtherNegative) : ("Weapon has no visual LOS to target", WeaponPrefireChecklistEvaluation.OtherNegative));
						}
					}
				}
				else
				{
					result = (text2, WeaponPrefireChecklistEvaluation.OtherNegative);
				}
			}
		}
		goto IL_3458;
		IL_2a86:
		Weapon weapon6 = null;
		if (theTarget.ActualUnit.IsWeapon)
		{
			weapon6 = (Weapon)theTarget.ActualUnit;
		}
		if (theTarget.IsBallisticTarget() && (weapon6 == null || !weapon6.IsHGV || weapon6.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 200000f))
		{
			if (theTarget.FutureBallisticPath.Length == 0)
			{
				theTarget.FutureBallisticPath = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(theTarget, myUnit.ParentScen);
			}
			futureBallisticPath = theTarget.FutureBallisticPath;
			float maxTargetAlt_ASL = theWeapon.MaxTargetAlt_ASL;
			float minTargetAlt_ASL = theWeapon.MinTargetAlt_ASL;
			double num27 = Math.Sqrt(Math.Pow(theWeapon.MaxRange_NoTargetType, 2.0) + Math.Pow((double)theWeapon.Kinematics.GetMaximumAltitude() * 0.000539957, 2.0));
			flag8 = false;
			num8 = 0;
			int num30;
			if (type != Weapon._WeaponType.Laser)
			{
				if (type != Weapon._WeaponType.Microwave)
				{
					flag8 = false;
					double num28 = myUnit.get_Latitude(GlobalVariables.ObjectTrue);
					double lon = myUnit.get_Longitude(GlobalVariables.ObjectTrue);
					double double_ = Math.Sin(num28 * 0.0174532925199433);
					double double_2 = Math.Cos(num28 * 0.0174532925199433);
					TrajectoryPoint[] array = futureBallisticPath;
					for (int l = 0; l < array.Length; l = checked(l + 1))
					{
						TrajectoryPoint thePoint = array[l];
						if (thePoint.Altitude <= maxTargetAlt_ASL && thePoint.Altitude >= minTargetAlt_ASL)
						{
							float num29 = Math2.CalcDist(double_, double_2, num28, lon, thePoint.Latitude, thePoint.Longitude);
							if ((double)num29 < num27 && !((double)myUnit.RangeToPoint_Slant(thePoint, GlobalVariables.ObjectTrue, num29) >= num27))
							{
								flag8 = true;
								break;
							}
						}
						num8++;
					}
					goto IL_2c3c;
				}
				num30 = 1;
			}
			else
			{
				num30 = 1;
			}
			flag8 = (byte)num30 != 0;
			goto IL_2c3c;
		}
		goto IL_2e58;
	}

	private (string, WeaponPrefireChecklistEvaluation) method_6(Weapon weapon_6, Contact contact_0, bool bool_12)
	{
		(string, WeaponPrefireChecklistEvaluation) result = default((string, WeaponPrefireChecklistEvaluation));
		if (!GameGeneral.Beta_PlatformComms || !myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
		{
			result = (method_9(weapon_6, contact_0) ? ("Weapon can be fired at the target using CEC/IFC capability", WeaponPrefireChecklistEvaluation.OK) : (bool_12 ? ("Firing unit must obtain (from itself or another CEC-enabled platform) a high-quality track on the target before firing", WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC) : (null, WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC)));
		}
		else
		{
			bool flag = false;
			CommDevice.EnumCommQuality enumCommQuality = ((!((double)contact_0.CurrentSpeed > 5831.53)) ? CommDevice.EnumCommQuality.AAW : CommDevice.EnumCommQuality.BMD);
			ActiveUnit_CommStuff.TransmissionContactData contactGradeInfo = myUnit.CommStuff.GetContactGradeInfo(contact_0.ObjectID);
			if (!string.IsNullOrEmpty(contactGradeInfo.TransmittedBy) && contactGradeInfo.Bandwith >= enumCommQuality && contact_0.Age == 0f)
			{
				flag = true;
			}
			if (!flag && method_9(weapon_6, contact_0))
			{
				flag = true;
			}
			if (!flag)
			{
				result = ((!bool_12) ? ("Weapon can be fired at the target using CEC/IFC capability ", WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC) : ("Firing unit has no track or insufficient-quality track on the target, and no CEC/IFC option available", WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC));
			}
		}
		return result;
	}

	private string method_7(WeaponCommMatrix.IFCVariant ifcvariant_0)
	{
		List<string> list = new List<string>();
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.PrecisionCue) == WeaponCommMatrix.IFCVariant.PrecisionCue)
		{
			list.Add("Precision Cue");
		}
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.LaunchOnRemote) == WeaponCommMatrix.IFCVariant.LaunchOnRemote)
		{
			list.Add("Launch on Remote");
		}
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.EngageOnRemote) == WeaponCommMatrix.IFCVariant.EngageOnRemote)
		{
			list.Add("Engage on Remote");
		}
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.ForwardPass) == WeaponCommMatrix.IFCVariant.ForwardPass)
		{
			list.Add("Forward Pass");
		}
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.RemoteFire) == WeaponCommMatrix.IFCVariant.RemoteFire)
		{
			list.Add("Remote Fire");
		}
		if ((ifcvariant_0 & WeaponCommMatrix.IFCVariant.PreferredShooterDetermination) == WeaponCommMatrix.IFCVariant.PreferredShooterDetermination)
		{
			list.Add("PSD");
		}
		if (list.Count <= 0)
		{
			return "None";
		}
		return string.Join(" + ", list);
	}

	private (string, WeaponPrefireChecklistEvaluation) method_8(Weapon weapon_6, Contact contact_0, float float_1, bool bool_12)
	{
		float num = 0f;
		num = contact_0?.CurrentSpeed ?? float_1;
		if (weapon_6.MaxTargetSpeed <= 0)
		{
			goto IL_0146;
		}
		(string, WeaponPrefireChecklistEvaluation) result;
		if (num > (float)weapon_6.MaxTargetSpeed * 1.2f && contact_0 != null && contact_0.Type != Contact_Base.ContactType.Orbital)
		{
			if (!bool_12)
			{
				result = ("Other", WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			else
			{
				stringBuilder_0.Clear();
				stringBuilder_0.Append("Target speed (").Append((int)Math.Round(num)).Append(" kts) is much higher than the weapon's maximum target speed (")
					.Append(weapon_6.MaxTargetSpeed)
					.Append(" kts)");
				result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
			}
		}
		else
		{
			if (!(num < (float)weapon_6.MinTargetSpeed * 0.8f) || contact_0 == null || contact_0.Type == Contact_Base.ContactType.Orbital)
			{
				goto IL_0146;
			}
			if (bool_12)
			{
				stringBuilder_0.Clear();
				stringBuilder_0.Append("Target speed (").Append((int)Math.Round(num)).Append(" kts) is much lower than the weapon's minimum target speed (")
					.Append(weapon_6.MinTargetSpeed)
					.Append(" kts)");
				result = (stringBuilder_0.ToString(), WeaponPrefireChecklistEvaluation.OtherNegative);
			}
			else
			{
				result = ("Other", WeaponPrefireChecklistEvaluation.OtherNegative);
			}
		}
		goto IL_0153;
		IL_0153:
		return result;
		IL_0146:
		result = ("OK", WeaponPrefireChecklistEvaluation.OK);
		goto IL_0153;
	}

	private bool method_9(Weapon weapon_6, Contact contact_0)
	{
		bool result;
		try
		{
			if (!weapon_6.Flags.LOAL_CEC && ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(weapon_6, weapon_6.Comms_ReadOnly, weapon_6.FiringParent).CommDevice == null)
			{
				result = false;
			}
			else if (contact_0.UncertaintyArea == null)
			{
				float num = 0f;
				CommDevice[] comms_ReadOnly = weapon_6.Comms_ReadOnly;
				foreach (CommDevice commDevice in comms_ReadOnly)
				{
					if (!commDevice.ParentSpecific && commDevice.Range > num)
					{
						num = commDevice.Range;
					}
				}
				PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units, Pools<ActiveUnit>.Local);
				ActiveUnit[] array = Geodesic_Haversine.UnitsWithinDistanceFromPoint(pooledList, AssumeAllUnitsAreOperating: false, myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), num);
				pooledList.Dispose();
				bool flag = false;
				ActiveUnit[] array2 = array;
				foreach (ActiveUnit activeUnit in array2)
				{
					if (activeUnit != null && !activeUnit.IsGroup && activeUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(contact_0) && ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(weapon_6, weapon_6.Comms_ReadOnly, activeUnit).CommDevice != null)
					{
						flag = true;
						break;
					}
				}
				ArrayPool<ActiveUnit>.Shared.Return(array, clearArray: true);
				result = flag;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1032450239658340", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public (DLZResultEnum, float) method_10(Contact theTarget, Weapon theWeapon, bool AssumeVerticalLaunch, bool HumanFeedbackNeeded, Action<string> theLogger = null, Action<DLZResultData> theResultOutputter = null, bool bool_12 = false)
	{
		Math2.CalcDist_Slant_Cartesian_Double(theTarget, myUnit);
		float FlightTime = 0f;
		(DLZResultEnum, float) result = default((DLZResultEnum, float));
		try
		{
			if (theTarget == null)
			{
				result = (DLZResultEnum.Fail_TargetNotDefined, FlightTime);
				return result;
			}
			float initialHeading = ((!myUnit.IsAircraft) ? 0f : myUnit.CurrentHeading);
			GeoPoint InterceptPoint = null;
			theWeapon.FiringParent = myUnit;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, myUnit.ParentScen, myUnit.IsAircraft || myUnit.IsMissile, myUnit.CurrentSpeed, theLogger);
			(DLZResultEnum, float) tuple;
			int customWeaponFuel;
			int num2;
			string FeedbackText;
			if (theTarget.IsBallisticTarget())
			{
				Scenario parentScen = myUnit.ParentScen;
				int dBID = theWeapon.DBID;
				ActiveUnit firingUnit = myUnit;
				double launchLongitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double launchLatitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				float launchAltitude = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				int launchSpeed = (int)Math.Round(myUnit.CurrentSpeed);
				Contact theTarget2 = theTarget;
				GeoPoint InterceptPoint2 = null;
				FeedbackText = "";
				tuple = TargetIsWithinDLZ_BallisticTarget(parentScen, dBID, firingUnit, AssumeVerticalLaunch, launchLongitude, launchLatitude, launchAltitude, launchSpeed, theTarget2, initialHeading, ActiveUnit.Throttle.Cruise, ref InterceptPoint2, ref FeedbackText, null, null, ref FlightTime, theLogger, theResultOutputter);
			}
			else
			{
				if (!theTarget.IsOrbitalContact)
				{
					float num = 0.1f;
					int num3;
					if (theWeapon.Propulsion[0].Type != Engine.EngineType.Nuclear)
					{
						if (theWeapon.Fuel_ReadOnly.Count != 0)
						{
							customWeaponFuel = (int)Math.Round((float)theWeapon.Fuel_ReadOnly[0].MaxQuantity * (1f - num));
							num2 = 3;
							goto IL_0178;
						}
						num3 = int.MaxValue;
					}
					else
					{
						num3 = int.MaxValue;
					}
					customWeaponFuel = num3;
					num2 = 3;
					goto IL_0178;
				}
				tuple = TargetIsWithinDLZ_OrbitalTarget(myUnit.ParentScen, theWeapon.DBID, myUnit, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), (int)Math.Round(myUnit.CurrentSpeed), theTarget, 0f, ActiveUnit.Throttle.Cruise, ref FlightTime);
			}
			goto IL_03fc;
			IL_03fc:
			result = tuple;
			return result;
			IL_0178:
			ActiveUnit.Throttle throttleSetting = (ActiveUnit.Throttle)num2;
			if (theWeapon.IsTorpedo)
			{
				throttleSetting = ActiveUnit.Throttle.Cruise;
			}
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theWeapon, ref EmitterClassificable);
			float? num4 = myUnit.Doctrine.WRA_FiringRange_CurrentTargetType(myUnit.Doctrine, myUnit.ParentScen, theWeapon.DBID, theTargetType);
			if (!num4.HasValue)
			{
				Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_DetermineTargetType_Unspecified(ref theTargetType);
				num4 = myUnit.Doctrine.WRA_FiringRange_CurrentTargetType(myUnit.Doctrine, myUnit.ParentScen, theWeapon.DBID, selectedNodeTargetType);
				if (!num4.HasValue && Doctrine.WRA_FiringRange_GetDefaultFiringRange(myUnit.ParentScen, theWeapon.DBID, theTargetType) == Doctrine._WRA_FiringRange.NoEscapeZone)
				{
					num4 = -102f;
				}
			}
			int num5 = (int)Math.Round(Module_Unit.CurrentSpeed_Horizontal(theTarget));
			int maximumSpeed = theTarget.ActualUnit.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			AssumedDLZTargetBehavior assumedDLZTargetBehavior = default(AssumedDLZTargetBehavior);
			if (num4.HasValue)
			{
				if (num4.Value == -102f)
				{
					if (!(Doctrine.IsNEZValidTarget(theWeapon, theTarget) && !bool_12))
					{
						assumedDLZTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent;
					}
					else
					{
						assumedDLZTargetBehavior = AssumedDLZTargetBehavior.RunStraightAway;
						if (theTarget.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
						{
							num5 = maximumSpeed;
						}
					}
				}
				else
				{
					assumedDLZTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent;
				}
			}
			if (assumedDLZTargetBehavior == AssumedDLZTargetBehavior.ContinuesAsCurrent && theTarget.AppearsToBeLoitering)
			{
				assumedDLZTargetBehavior = AssumedDLZTargetBehavior.Loiter;
			}
			Scenario parentScen2 = myUnit.ParentScen;
			int dBID2 = theWeapon.DBID;
			ActiveUnit firingUnit2 = myUnit;
			double launchLongitude2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			double launchLatitude2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			float launchAltitude2 = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			int launchSpeed2 = (int)Math.Round(myUnit.CurrentSpeed);
			double targetLongitude = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
			double targetLatitude = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
			float currentHeading = theTarget.CurrentHeading;
			bool headingIsKnown = theTarget.HeadingIsKnown;
			int targetSpeed = num5;
			bool speedIsKnown = theTarget.SpeedIsKnown;
			float targetAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			bool altitudeIsKnown = theTarget.AltitudeIsKnown;
			float targetVerticalSpeed_mpersec = Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen);
			Contact_Base.ContactType type = theTarget.Type;
			bool targetIsTerminalDiving = theTarget.ActualUnit.IsGuidedWeapon() && ((Weapon)theTarget.ActualUnit).AI.TerminalDive;
			FeedbackText = null;
			tuple = TargetIsWithinDLZ(parentScen2, dBID2, firingUnit2, AssumeVerticalLaunch, launchLongitude2, launchLatitude2, launchAltitude2, launchSpeed2, targetLongitude, targetLatitude, currentHeading, headingIsKnown, targetSpeed, speedIsKnown, targetAltitude, altitudeIsKnown, targetVerticalSpeed_mpersec, type, ref InterceptPoint, targetIsTerminalDiving, ref FeedbackText, HumanFeedbackNeeded, initialHeading, throttleSetting, null, customWeaponFuel, null, ref FlightTime, theLogger, theResultOutputter, assumedDLZTargetBehavior);
			goto IL_03fc;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32452390866543698", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string CanThisWeaponEngageThisTarget_AttemptRetargeting(Weapon theWeapon, Contact theTarget)
	{
		string result;
		try
		{
			if (Information.IsNothing((object)theTarget))
			{
				result = "Target is null";
			}
			else
			{
				if (!theWeapon.IsMissile || !theWeapon.IsAAWCapable)
				{
					goto IL_0075;
				}
				Contact_Base.ContactType type = theTarget.Type;
				if ((type != Contact_Base.ContactType.Surface && type - 7 > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.AggregateGroundUnit) || myUnit.Doctrine.get_UseSAMsOnASuW(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value == Doctrine._UseSAMsAgainstShips.Yes)
				{
					goto IL_0075;
				}
				result = "Unit is not authorized to use SAMs against surface targets";
			}
			goto end_IL_0001;
			IL_0322:
			float num;
			if (theTarget.Type == Contact_Base.ContactType.ActivationPoint)
			{
				result = "OK";
			}
			else if (!theWeapon.IsNuke.Value && theTarget.Type == Contact_Base.ContactType.Submarine && (theWeapon.Type == Weapon._WeaponType.DepthCharge || theWeapon.Type == Weapon._WeaponType.Rocket) && theTarget.UncertaintyArea != null)
			{
				result = "Weapon needs a precise target location";
			}
			else
			{
				Weapon weapon = theWeapon;
				ActiveUnit theAttackingUnit = myUnit;
				GlobalVariables.BooleanObject TargetIsDestroyed = null;
				if (weapon.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed))
				{
					num = ((theWeapon.Type != Weapon._WeaponType.Gun) ? myUnit.RangeToUnit_Horiz(theTarget) : Module_Unit.RangeToUnit_Slant(myUnit, theTarget));
					if (theWeapon.Type == Weapon._WeaponType.Dispenser && (double)(num * 1852f) > (double)theWeapon.Warheads[0].ClusterBombDispersionAreaLength / 2.0)
					{
						result = "Target is out of weapon range";
					}
					else
					{
						float num2 = ((!theWeapon.IsMissile || !NeedToCheckDLZ(theWeapon, theTarget) || theTarget.CurrentSpeed == 0f) ? theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) : ((theTarget.Type != Contact_Base.ContactType.Surface) ? ((float)((double)theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) * 1.5)) : theWeapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false)));
						if (!(num2 >= num))
						{
							result = "Target is out of weapon range";
						}
						else if (theTarget.Type == Contact_Base.ContactType.ActivationPoint)
						{
							result = "OK";
						}
						else if (!Information.IsNothing((object)theTarget.ActualUnit))
						{
							if (!theTarget.ActualUnit.IsShip && !theTarget.ActualUnit.IsFacility && !theTarget.ActualUnit.IsSubmarine)
							{
								goto IL_04ee;
							}
							string text = IsWeaponSuitableForTargetAmbiguity(theWeapon, theTarget);
							if (string.CompareOrdinal(text, "OK") == 0)
							{
								goto IL_04ee;
							}
							result = text;
						}
						else
						{
							result = "Unit vanished";
						}
					}
				}
				else
				{
					result = "Weapon is not suitable for this target";
				}
			}
			goto end_IL_0001;
			IL_083e:
			if (theWeapon.Guidance != Weapon.WeaponGuidanceType.BeamRiding)
			{
				goto IL_08d6;
			}
			bool flag = false;
			bool flag2 = false;
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			Sensor sensor2 = default(Sensor);
			foreach (Sensor sensor in sensors_Cached)
			{
				if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.CanIlluminateForThisWeapon(ref theWeapon))
				{
					flag = true;
					if (sensor.TargetsTrackedForFireControl_Readonly.Count < sensor.MaxIlluminate || sensor.IsTrackingThisTargetForFireControl(ref theTarget))
					{
						sensor2 = sensor;
						flag2 = true;
					}
				}
			}
			if (flag)
			{
				if (flag2)
				{
					goto IL_08d6;
				}
				result = "All illumination channels suitable for this weapon are in use";
			}
			else
			{
				result = "No weapons director available to illuminate the target";
			}
			goto end_IL_0001;
			IL_04ee:
			if (!theTarget.IsFirm && !theWeapon.CanBeFiredOnAmbigousTarget(theTarget, GunDirectorFound: false))
			{
				result = "Weapon is unable to engage imprecise target";
			}
			else
			{
				if (theWeapon.Guidance != Weapon.WeaponGuidanceType.Passive)
				{
					goto IL_0582;
				}
				Sensor sensor3 = theWeapon.WeaponSensors()[0];
				Weapon sensorParent = theWeapon;
				ActiveUnit actualUnit = theTarget.ActualUnit;
				List<Geopoint_Struct> UncertaintyArea = null;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Sonar = null;
				bool? LOS_Exists_ESM = null;
				bool? LOS_Exists_ESM_SW = null;
				Dictionary<int, EmissionContainer> DetectedEmissions = default(Dictionary<int, EmissionContainer>);
				if (sensor3.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, sensorParent, actualUnit, ref UncertaintyArea, num, ref DetectedEmissions, null, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
				{
					goto IL_0582;
				}
				result = "Weapon must detect target prior to firing";
			}
			goto end_IL_0001;
			IL_08d6:
			float initialHeading = (myUnit.IsAircraft ? myUnit.CurrentHeading : 0f);
			GeoPoint InterceptPoint = null;
			if (!NeedToCheckDLZ(theWeapon, theTarget))
			{
				goto IL_0bd1;
			}
			(int, string, bool) key = (theWeapon.DBID, theTarget.ObjectID, false);
			if (DLZ_ResultsCache != null && DLZ_ResultsCache.ContainsKey(key))
			{
				if (DLZ_ResultsCache[key].Item1 == DLZResultEnum.Success)
				{
					goto IL_0bd1;
				}
				result = DLZ_ResultsCache[key].ToString();
			}
			else
			{
				(DLZResultEnum, float) value;
				if (theTarget.IsBallisticTarget())
				{
					Scenario parentScen = myUnit.ParentScen;
					int dBID = theWeapon.DBID;
					ActiveUnit firingUnit = myUnit;
					double launchLongitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double launchLatitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					float launchAltitude = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					int launchSpeed = (int)Math.Round(myUnit.CurrentSpeed);
					Contact theTarget2 = theTarget;
					GeoPoint InterceptPoint2 = null;
					string FeedbackText = "";
					float FlightTime = 0f;
					value = TargetIsWithinDLZ_BallisticTarget(parentScen, dBID, firingUnit, AssumeVerticalLaunch: false, launchLongitude, launchLatitude, launchAltitude, launchSpeed, theTarget2, initialHeading, ActiveUnit.Throttle.Cruise, ref InterceptPoint2, ref FeedbackText, null, null, ref FlightTime);
				}
				else if (!theTarget.IsOrbitalContact)
				{
					float num3 = 0.1f;
					Scenario parentScen2 = myUnit.ParentScen;
					int dBID2 = theWeapon.DBID;
					ActiveUnit firingUnit2 = myUnit;
					double launchLongitude2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double launchLatitude2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					float launchAltitude2 = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					int launchSpeed2 = (int)Math.Round(myUnit.CurrentSpeed);
					double targetLongitude = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					double targetLatitude = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
					float currentHeading = theTarget.CurrentHeading;
					bool headingIsKnown = theTarget.HeadingIsKnown;
					int targetSpeed = (int)Math.Round(Module_Unit.CurrentSpeed_Horizontal(theTarget));
					bool speedIsKnown = theTarget.SpeedIsKnown;
					float targetAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					bool altitudeIsKnown = theTarget.AltitudeIsKnown;
					float targetVerticalSpeed_mpersec = Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen);
					Contact_Base.ContactType type2 = theTarget.Type;
					bool targetIsTerminalDiving = theTarget.ActualUnit.IsGuidedWeapon() && ((Weapon)theTarget.ActualUnit).AI.TerminalDive;
					string FeedbackText = null;
					int customWeaponFuel = (int)Math.Round((float)theWeapon.Fuel_ReadOnly[0].MaxQuantity * (1f - num3));
					float FlightTime = 0f;
					value = TargetIsWithinDLZ(parentScen2, dBID2, firingUnit2, AssumeVerticalLaunch: false, launchLongitude2, launchLatitude2, launchAltitude2, launchSpeed2, targetLongitude, targetLatitude, currentHeading, headingIsKnown, targetSpeed, speedIsKnown, targetAltitude, altitudeIsKnown, targetVerticalSpeed_mpersec, type2, ref InterceptPoint, targetIsTerminalDiving, ref FeedbackText, HumanFeedBackNeeded: false, initialHeading, ActiveUnit.Throttle.Cruise, null, customWeaponFuel, null, ref FlightTime);
				}
				else
				{
					Scenario parentScen3 = myUnit.ParentScen;
					int dBID3 = theWeapon.DBID;
					ActiveUnit theFiringUnit = myUnit;
					double launchLongitude3 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double launchLatitude3 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					float launchAltitude3 = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					int launchSpeed3 = (int)Math.Round(myUnit.CurrentSpeed);
					Contact theTarget3 = theTarget;
					float FlightTime = 0f;
					value = TargetIsWithinDLZ_OrbitalTarget(parentScen3, dBID3, theFiringUnit, launchLongitude3, launchLatitude3, launchAltitude3, launchSpeed3, theTarget3, 0f, ActiveUnit.Throttle.Cruise, ref FlightTime);
				}
				if (DLZ_ResultsCache == null)
				{
					DLZ_ResultsCache = new TDictionary<(int, string, bool), (DLZResultEnum, float)>();
				}
				DLZ_ResultsCache.AddIfNotExistsElseUpdate(key, value);
				if (value.Item1 == DLZResultEnum.Success)
				{
					goto IL_0bd1;
				}
				result = Module_ActiveUnit_Weaponry.ToEnglishString(value.Item1);
			}
			goto end_IL_0001;
			IL_0582:
			int num4;
			if (!theWeapon.Flags.IlluminateAtLaunch)
			{
				if (!theWeapon.Flags.TerminalIllumination)
				{
					goto IL_083e;
				}
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			bool flag3 = (byte)num4 != 0;
			bool flag4 = false;
			bool flag5 = false;
			List<Sensor> list = new List<Sensor>();
			Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
			foreach (Sensor sensor4 in sensors_Cached2)
			{
				if (sensor4.Status == PlatformComponent._ComponentStatus.Operational && sensor4.CanIlluminateForThisWeapon(ref theWeapon))
				{
					list.Add(sensor4);
				}
			}
			if (list.Count > 0)
			{
				flag3 = true;
				List<Sensor> list2 = new List<Sensor>();
				foreach (Sensor item in list)
				{
					if (theWeapon.Guidance == Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive)
					{
						list2.Add(item);
					}
					else if (item.TargetsTrackedForFireControl_Readonly.Count < item.MaxIlluminate || item.IsTrackingThisTargetForFireControl(ref theTarget))
					{
						list2.Add(item);
					}
				}
				if (list2.Count > 0)
				{
					flag4 = true;
					new List<Sensor>();
					Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual2 = null;
					bool? LOS_Exists_Radar2 = null;
					bool? LOS_Exists_RadarSW2 = null;
					bool? LOS_Exists_Sonar2 = null;
					float targetSlantRange = Module_Unit.RangeToUnit_Slant(myUnit, theTarget);
					List<ActiveUnit> list3 = default(List<ActiveUnit>);
					foreach (Sensor item2 in list2)
					{
						if (item2.Type == Sensor.Sensor_Type.Radar && Information.IsNothing((object)list3))
						{
							list3 = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
						}
						if (item2.CanIlluminateTarget(myUnit, ref theTarget, ref myUnit.ParentScen, targetSlantRange, list3, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar2, ref LOS_Exists_RadarSW2, ref LOS_Exists_Visual2, ref LOS_Exists_Sonar2) == Sensor.SensorDetectionCheckResult.Success)
						{
							sensor2 = item2;
							flag5 = true;
							break;
						}
					}
				}
			}
			if ((!flag3 || !flag4 || !flag5) && theWeapon.Flags.SupportsBuddyIllumination)
			{
				PooledList<ActiveUnit> pooledList = theWeapon.FetchAvailableBuddyIlluminatorUnits(myUnit.get_UnitSide(SetSideOnly: false), theTarget);
				if (pooledList != null)
				{
					Sensor SuitableIlluminator = default(Sensor);
					foreach (ActiveUnit item3 in pooledList)
					{
						if (item3 != null)
						{
							ActiveUnit_Sensory sensory = item3.Sensory;
							Contact theContact = theTarget;
							Weapon theWeapon2 = theWeapon;
							bool? LOS_Exists_ESM_SW = null;
							bool? LOS_Exists_ESM = null;
							Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
							bool? LOS_Exists_Sonar = null;
							if (sensory.CanIlluminateThisContactForThisWeapon(theContact, theWeapon2, ref SuitableIlluminator, ref LOS_Exists_ESM_SW, ref LOS_Exists_ESM, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
							{
								sensor2 = SuitableIlluminator;
							}
						}
					}
					pooledList.Dispose();
				}
			}
			if (sensor2 != null)
			{
				goto IL_083e;
			}
			if (flag3)
			{
				if (!flag4)
				{
					result = "All illumination channels suitable for this weapon are in use";
				}
				else
				{
					if (flag5)
					{
						goto IL_083e;
					}
					result = "All directors are unable to illuminate this target (insufficient reflection, no LOS etc)";
				}
			}
			else
			{
				result = "No weapons director available to illuminate the target";
			}
			goto end_IL_0001;
			IL_0c39:
			result = "OK";
			goto end_IL_0001;
			IL_0075:
			if (theWeapon.MaxTargetSpeed > 0 && theTarget.CurrentSpeed > (float)theWeapon.MaxTargetSpeed * 1.2f)
			{
				result = "Target speed (" + Conversions.ToString((int)Math.Round(theTarget.CurrentSpeed)) + " kts) is much higher than the weapon's maximum target speed (" + Conversions.ToString(theWeapon.MaxTargetSpeed) + " kts)";
			}
			else if (theWeapon.MinTargetSpeed >= 0 && theTarget.CurrentSpeed < (float)theWeapon.MinTargetSpeed * 0.8f)
			{
				result = "Target speed (" + Conversions.ToString((int)Math.Round(theTarget.CurrentSpeed)) + " kts) is much lower than the weapon's minimum target speed (" + Conversions.ToString(theWeapon.MinTargetSpeed) + " kts)";
			}
			else
			{
				if (theTarget.IsBallisticTarget() || theTarget.Type == Contact_Base.ContactType.Surface)
				{
					goto IL_0322;
				}
				if (theWeapon.MaxTargetAlt_AGL > 0f && ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > theWeapon.MaxTargetAlt_AGL)
				{
					result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft) is higher than the weapon's ceiling (" + Conversions.ToString((int)Math.Round(theWeapon.MaxTargetAlt_AGL * 3.28084f)) + " ft)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) + " m) is higher than the weapon's ceiling (" + Conversions.ToString(theWeapon.MaxTargetAlt_AGL) + " m)"));
				}
				else
				{
					if (!(theWeapon.MinTargetAlt_AGL > 0f) || !(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < theWeapon.MinTargetAlt_AGL))
					{
						goto IL_0322;
					}
					result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) + " m) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString(theWeapon.MinTargetAlt_AGL) + " m)") : ("Target altitude (" + Conversions.ToString((int)Math.Round(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft) is lower than the weapon's minimum engagement altitude (" + Conversions.ToString((int)Math.Round(theWeapon.MinTargetAlt_AGL * 3.28084f)) + " ft)"));
				}
			}
			goto end_IL_0001;
			IL_0bd1:
			if (!theWeapon.ValidTargets.Radar)
			{
				goto IL_0c39;
			}
			if (theWeapon.IsDualModeARM)
			{
				if (theTarget.IsPreciselyLocatedOnThisPulse)
				{
					goto IL_0c39;
				}
				result = "Target is not radiating, and lacking a precise location to launch dual mode ARM in INS/GPS mode.";
			}
			else if (theTarget.HasDetectedEmissions)
			{
				Weapon weapon2 = theWeapon;
				TObservableDictionary<int, EmissionContainer> detectedEmissions = theTarget.DetectedEmissions;
				Side theSide = myUnit.get_UnitSide(SetSideOnly: false);
				Contact theTarget4 = theTarget;
				Random theRNG = GameGeneral.GlobalRNG;
				if (weapon2.ARM_DetermineEmissionToTrack(detectedEmissions, theSide, theTarget4, ShootAtTurnedOffRadar: false, ref theRNG))
				{
					goto IL_0c39;
				}
				result = "No threat emitters are currently radiating";
			}
			else
			{
				result = "Target is not radiating";
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100307", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error occured";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private List<Sensor> method_11(Mount mount_0, Contact contact_0)
	{
		List<Sensor> list = new List<Sensor>();
		Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
		bool? LOS_Exists_Radar = null;
		bool? LOS_Exists_RadarSW = null;
		bool? LOS_Exists_Sonar = null;
		bool? LOS_Exists_ESM = null;
		bool? LOS_Exists_ESM_SW = null;
		List<Sensor> result = default(List<Sensor>);
		try
		{
			List<ActiveUnit> list2 = null;
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if (sensor.Status == PlatformComponent._ComponentStatus.Operational && mount_0.CompatibleDirectors.Contains(sensor.DBID) && (sensor.HasFireControlChannelAvailable() || sensor.TargetsTrackedForFireControl_Readonly.Contains(contact_0)))
				{
					if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing((object)list2))
					{
						list2 = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
					}
					ActiveUnit sensorParent = myUnit;
					ActiveUnit actualUnit = contact_0.ActualUnit;
					List<Geopoint_Struct> UncertaintyArea = null;
					float targetSlantRange = myUnit.RangeToUnit_Horiz(contact_0);
					Dictionary<int, EmissionContainer> DetectedEmissions = null;
					if (sensor.CanDetectTarget(Sensor.DetectionAttemptType.WeaponGuidance, sensorParent, actualUnit, ref UncertaintyArea, targetSlantRange, ref DetectedEmissions, list2, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
					{
						list.Add(sensor);
					}
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100308", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool NeedToCheckDLZ(Weapon theWeapon, Contact theTarget)
	{
		if (theTarget == null)
		{
			return false;
		}
		bool result = default(bool);
		try
		{
			switch (theWeapon.Type)
			{
			default:
				result = false;
				return result;
			case Weapon._WeaponType.RV:
				result = true;
				return result;
			case Weapon._WeaponType.Torpedo:
				result = true;
				return result;
			case Weapon._WeaponType.GuidedWeapon:
				if (theWeapon.IsBallisticMissile && theWeapon.HasRVs.Value)
				{
					result = false;
					return result;
				}
				if (!theWeapon.IsLongFlightCruiseMissile)
				{
					int num;
					switch (theTarget.Type)
					{
					case Contact_Base.ContactType.Orbital:
						num = 1;
						break;
					default:
						if (theWeapon.Flags.IsBallisticMissile && theWeapon.Warheads.Length > 0 && theWeapon.Warheads[0].Type == Warhead.WarheadType.Weapon)
						{
							result = false;
							return result;
						}
						if (myUnit.IsAircraft)
						{
							result = true;
							return result;
						}
						if (theWeapon.IsAAWCapable)
						{
							Contact_Base.ContactType type = theTarget.Type;
							int num2;
							if (type != Contact_Base.ContactType.Surface && type - 7 > Contact_Base.ContactType.Missile)
							{
								if (type != Contact_Base.ContactType.AggregateGroundUnit)
								{
									goto IL_00ed;
								}
								num2 = 1;
							}
							else
							{
								num2 = 1;
							}
							result = (byte)num2 != 0;
							return result;
						}
						goto IL_00ed;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						{
							num = 1;
							break;
						}
						IL_00ed:
						result = false;
						return result;
					}
					result = (byte)num != 0;
					return result;
				}
				result = false;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100309", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ResolvePointDefence(float elapsedTime, ref Weapon AttackWeapon)
	{
		if (AttackWeapon.TimeToReseek > 0f)
		{
			return;
		}
		List<string> PointDefenceMessages = new List<string>();
		PointDefenceResult pointDefenceResult = PointDefenceResult.Undefined;
		int num = 0;
		int num2 = 0;
		bool flag = false;
		try
		{
			if (AttackWeapon.WeaponSensors().Count > 0)
			{
				foreach (Sensor item4 in AttackWeapon.WeaponSensors())
				{
					if (item4.Type == Sensor.Sensor_Type.ESM)
					{
						if (!AttackWeapon.ValidTargets.Radar)
						{
							continue;
						}
					}
					else if (item4.Type == Sensor.Sensor_Type.ECM || !item4.get_IsSuitableForThisTarget(myUnit))
					{
						continue;
					}
					num2++;
				}
			}
			if (AttackWeapon.WeaponSensors().Count > 0 || AttackWeapon.Guidance == Weapon.WeaponGuidanceType.TVM)
			{
				bool hasLaserSpotTracker = AttackWeapon.HasLaserSpotTracker;
				bool flag2 = false;
				if (hasLaserSpotTracker)
				{
					Sensor[] sensors_Cached = AttackWeapon.AI.PrimaryTarget.ActualUnit.Sensors_Cached;
					for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
					{
						if (sensors_Cached[i].Role == Sensor.Sensor_Role.ESM_LWR)
						{
							flag2 = true;
						}
					}
				}
				if (AttackWeapon.AI.PrimaryTarget.ActualUnit.get_UnitSide(SetSideOnly: false).HasDetectedThisUnit(AttackWeapon) || (hasLaserSpotTracker && flag2))
				{
					List<Class8> list = new List<Class8>();
					foreach (Mount mount in myUnit.Mounts)
					{
						Mount mount_ = mount;
						if (mount_.Status != PlatformComponent._ComponentStatus.Operational || !(mount_.TimeToFire <= 1f))
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount_.MountWeapons)
						{
							WeaponRec weaponRec_ = mountWeapon;
							if (weaponRec_.CurrentLoad > 0)
							{
								weaponRec_.ParentMount = mount_;
								if (method_12(weaponRec_, mount_, AttackWeapon))
								{
									ActiveUnit activeUnit_ = myUnit;
									ActiveUnit activeUnit_2 = AttackWeapon;
									Class8 item = new Class8(ref elapsedTime, activeUnit_, ref weaponRec_, ref activeUnit_2, ref mount_);
									list.Add(item);
								}
							}
						}
					}
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						for (int j = 0; j < weapons.Length; j = checked(j + 1))
						{
							WeaponRec weaponRec_ = weapons[j];
							if (weaponRec_.CurrentLoad <= 0)
							{
								continue;
							}
							Weapon weapon = weaponRec_.get_ReferenceWeapon(myUnit.ParentScen);
							if (weapon.IsSensorPod)
							{
								foreach (WeaponRec weaponWeapon in weapon.WeaponWeapons)
								{
									WeaponRec weaponRec_2 = weaponWeapon;
									if (weaponRec_2.CurrentLoad > 0 && method_13(weaponRec_2, AttackWeapon))
									{
										ActiveUnit activeUnit_3 = myUnit;
										ActiveUnit activeUnit_2 = AttackWeapon;
										Mount mount_2 = null;
										Class8 item2 = new Class8(ref elapsedTime, activeUnit_3, ref weaponRec_2, ref activeUnit_2, ref mount_2);
										list.Add(item2);
									}
								}
							}
							else if (method_13(weaponRec_, AttackWeapon))
							{
								ActiveUnit activeUnit_4 = myUnit;
								ActiveUnit activeUnit_2 = AttackWeapon;
								Mount mount_2 = null;
								Class8 item3 = new Class8(ref elapsedTime, activeUnit_4, ref weaponRec_, ref activeUnit_2, ref mount_2);
								list.Add(item3);
							}
						}
					}
					if (list.Count > 0)
					{
						flag = true;
						IEnumerable<Class8> enumerable = from theE in list
							select (theE) into theE
							orderby theE.weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).BasePoK_AnyTarget() descending
							select theE;
						HashSet<int> dBIDsOfDecoysAlreadyTried = new HashSet<int>();
						Contact contact = null;
						foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
						{
							if (contacts_.ActualUnit == AttackWeapon)
							{
								contact = contacts_;
								break;
							}
						}
						foreach (Class8 item5 in enumerable)
						{
							ref WeaponRec weaponRec_3 = ref item5.weaponRec_0;
							Contact theTarget = contact;
							int NumberOfWeaponsFired = 0;
							FireWeapon_PointDefenceMode(ref weaponRec_3, theTarget, ref PointDefenceMessages, ref NumberOfWeaponsFired, dBIDsOfDecoysAlreadyTried);
							if (item5.mount_0 == null)
							{
								continue;
							}
							if (item5.weaponRec_0.CurrentLoad == 0)
							{
								Mount mount_3 = item5.mount_0;
								NumberOfWeaponsFired = 0;
								int theQty_PartiallyLoadedCells = 0;
								if (mount_3.CurrentCapacity(ref NumberOfWeaponsFired, ref theQty_PartiallyLoadedCells) == 0)
								{
									item5.mount_0.TimeToReloadAttempt = 0f;
									continue;
								}
							}
							if (item5.mount_0.TimeToReloadAttempt < 300f)
							{
								item5.mount_0.TimeToReloadAttempt = item5.mount_0.TimeToFire + 300f;
							}
						}
					}
				}
			}
			Sensor TargetSensor = default(Sensor);
			if (AttackWeapon.WeaponSensors().Count > 0)
			{
				foreach (Sensor item6 in AttackWeapon.WeaponSensors())
				{
					if (item6.Type == Sensor.Sensor_Type.ESM)
					{
						if (!AttackWeapon.ValidTargets.Radar)
						{
							continue;
						}
					}
					else if (item6.Type == Sensor.Sensor_Type.ECM || !item6.get_IsSuitableForThisTarget(myUnit))
					{
						continue;
					}
					if (item6.IsNeutralized == true)
					{
						num++;
					}
				}
				if (num >= num2 && num2 > 0)
				{
					string message = "All seekers were spoofed  - missed target";
					AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
					if (AttackWeapon.Flags.ReAttack_Capability)
					{
						AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, "Will re-attack");
						PointDefenceMessages?.Add("Weapon: " + AttackWeapon.Name + " will re-attack");
						ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponDefeated, PointDefenceMessages);
						AttackWeapon.PrepareForReattack(myUnit);
						AttackWeapon.EndgameReport.ReportEndgameAfterReattackTriggered(AttackWeapon.ParentScen);
						return;
					}
					AttackWeapon.ParentScen.DestroyThisUnit(AttackWeapon, "Weapon missed target and does not have ReAttack Capability", "Missed");
				}
			}
			else if (AttackWeapon.Guidance == Weapon.WeaponGuidanceType.TVM)
			{
				TargetSensor = AttackWeapon.SensorProvidingFireControlForMe;
				if (TargetSensor != null)
				{
					if (TargetSensor.IsNeutralized == true)
					{
						string message = "Radar providing guidance for TVM/SAGG-guided weapon was spoofed - could not impact";
						AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
						if (AttackWeapon.Flags.ReAttack_Capability)
						{
							PointDefenceMessages?.Add("Weapon will re-attack");
							ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponDefeated, PointDefenceMessages);
							AttackWeapon.PrepareForReattack(myUnit);
							AttackWeapon.EndgameReport.ReportEndgameAfterReattackTriggered(AttackWeapon.ParentScen);
							return;
						}
						AttackWeapon.ParentScen.DestroyThisUnit(AttackWeapon, "Radar providing guidance for TVM/SAGG-guided weapon was spoofed - cannot impact", "Spoofed");
					}
				}
				else
				{
					string message = "No radar providing guidance for weapon: " + AttackWeapon.Name + " (" + AttackWeapon.UnitClass + ") - cannot impact";
					AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
				}
			}
			if (AttackWeapon.IsMorituri)
			{
				pointDefenceResult = PointDefenceResult.WeaponDefeated;
			}
			if (pointDefenceResult != PointDefenceResult.WeaponDefeated)
			{
				if (AttackWeapon.WeaponSensors().Count > 0)
				{
					bool flag3 = !myUnit.IsAircraft;
					foreach (Sensor item7 in AttackWeapon.WeaponSensors())
					{
						Sensor TargetSensor2 = item7;
						if (TargetSensor2.IsNeutralized == true)
						{
							continue;
						}
						if (TargetSensor2.Type == Sensor.Sensor_Type.ESM)
						{
							if (!AttackWeapon.ValidTargets.Radar)
							{
								continue;
							}
						}
						else if (TargetSensor2.Type == Sensor.Sensor_Type.ECM || !TargetSensor2.get_IsSuitableForThisTarget(myUnit))
						{
							continue;
						}
						Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
						foreach (Sensor sensor in sensors_Cached2)
						{
							if (sensor.IsDECM && (!flag3 || sensor.TargetIsWithinCoverageArc(AttackWeapon)) && sensor.get_CanSpoofThisSensor(TargetSensor2))
							{
								flag = true;
								if (sensor.PointDefenceJam(ref TargetSensor2, ref myUnit, PointDefenceMessages))
								{
									num++;
									TargetSensor2.IsNeutralized = true;
								}
							}
						}
					}
				}
				else if (AttackWeapon.Guidance == Weapon.WeaponGuidanceType.TVM)
				{
					TargetSensor = AttackWeapon.SensorProvidingFireControlForMe;
					if (TargetSensor != null)
					{
						bool? isNeutralized = TargetSensor.IsNeutralized;
						if (((!isNeutralized) ?? isNeutralized) == true)
						{
							Sensor[] sensors_Cached3 = myUnit.Sensors_Cached;
							foreach (Sensor sensor2 in sensors_Cached3)
							{
								if (sensor2.IsDECM && sensor2.get_CanSpoofThisSensor(TargetSensor))
								{
									flag = true;
									if (sensor2.PointDefenceJam(ref TargetSensor, ref myUnit, PointDefenceMessages))
									{
										TargetSensor.IsNeutralized = true;
										string message = "Radar providing guidance for TVM/SAGG-guided weapon was spoofed - could not impact";
										AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
										PointDefenceMessages?.Add("Radar providing guidance for TVM/SAGG-guided weapon was spoofed - cannot impact");
										break;
									}
								}
							}
						}
					}
				}
				if (AttackWeapon.WeaponSensors().Count > 0)
				{
					if (num >= num2 && num2 > 0)
					{
						string message = "All weapon seekers were spoofed - weapon missed target";
						AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
						PointDefenceMessages?.Add("All weapon seekers were spoofed - weapon missed target");
						ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponDefeated, PointDefenceMessages);
						if (AttackWeapon.Flags.ReAttack_Capability)
						{
							PointDefenceMessages?.Add("Weapon will re-attack");
							ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponDefeated, PointDefenceMessages);
							AttackWeapon.PrepareForReattack(myUnit);
							AttackWeapon.EndgameReport.ReportEndgameAfterReattackTriggered(AttackWeapon.ParentScen);
							return;
						}
						AttackWeapon.ParentScen.DestroyThisUnit(AttackWeapon, "All weapon seekers were spoofed - weapon missed target", "Spoofed");
					}
					else
					{
						if (num > 0)
						{
							string message = "Only " + Conversions.ToString(num) + " out of " + Conversions.ToString(num2) + " weapon sensors spoofed";
							AttackWeapon.EndgameReport.AddEndGameMessage(hit: false, message);
							PointDefenceMessages?.Add("Only " + Conversions.ToString(num) + " out of " + Conversions.ToString(num2) + " weapon sensors spoofed");
						}
						if (flag)
						{
							PointDefenceMessages.Add("Point defence systems on " + myUnit.Name + " defeated by weapon " + AttackWeapon.Name);
						}
						else
						{
							PointDefenceMessages.Add("No point defence systems employed by " + myUnit.Name + " against weapon " + AttackWeapon.Name);
						}
						ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponSurvived, PointDefenceMessages);
						Weapon obj = AttackWeapon;
						ActiveUnit theTarget2 = myUnit;
						Scenario parentScen = myUnit.ParentScen;
						List<string> PointDefenceMessages2 = null;
						obj.ResolveImpact(theTarget2, parentScen, IsPointDefenceMode: false, ref PointDefenceMessages2);
					}
				}
				else if (TargetSensor != null && TargetSensor.IsNeutralized == true)
				{
					ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponDefeated, PointDefenceMessages);
				}
				else
				{
					if (flag)
					{
						PointDefenceMessages.Add("Point defence systems on " + myUnit.Name + " defeated by weapon " + AttackWeapon.Name);
					}
					else
					{
						PointDefenceMessages.Add("No point defence systems employed by " + myUnit.Name + " against weapon " + AttackWeapon.Name);
					}
					ExportResolvePointDefence(AttackWeapon, myUnit, PointDefenceResult.WeaponSurvived, PointDefenceMessages);
					Weapon obj2 = AttackWeapon;
					ActiveUnit theTarget3 = myUnit;
					Scenario parentScen2 = myUnit.ParentScen;
					List<string> PointDefenceMessages2 = null;
					obj2.ResolveImpact(theTarget3, parentScen2, IsPointDefenceMode: false, ref PointDefenceMessages2);
				}
			}
			if (AttackWeapon.Guidance == Weapon.WeaponGuidanceType.TVM)
			{
				if (TargetSensor != null && TargetSensor.IsNeutralized.HasValue)
				{
					TargetSensor.IsNeutralized = null;
				}
				return;
			}
			foreach (Sensor item8 in AttackWeapon.WeaponSensors())
			{
				if (item8.IsNeutralized.HasValue)
				{
					item8.IsNeutralized = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100310", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportResolvePointDefence(Weapon AttackWeapon, Module_Unit.Unit theTarget, PointDefenceResult theResult, List<string> theMessages)
	{
		try
		{
			IEventExporter[] applicableEventExporters = AttackWeapon.ParentScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (AttackWeapon.ParentScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(AttackWeapon.ParentScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(AttackWeapon.ParentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(AttackWeapon.ParentScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(AttackWeapon.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + AttackWeapon.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(AttackWeapon.ParentScen.Time.Subtract(AttackWeapon.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(AttackWeapon.ObjectID, typeof(string), 40));
				pooledDictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(AttackWeapon.Name, typeof(string), 500));
				pooledDictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(((ActiveUnit)AttackWeapon).get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				if (Information.IsNothing((object)AttackWeapon.FiringParent))
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(AttackWeapon.FiringParent.ObjectID, typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(AttackWeapon.FiringParent.Name, typeof(string), 500));
				}
				if (Information.IsNothing((object)theTarget))
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter("-", typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter("-", typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter("-", typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter("-", typeof(float)));
				}
				else
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(theTarget.ObjectID, typeof(string), 40));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(theTarget.Name, typeof(string), 500));
					if (Information.IsNothing((object)theTarget.get_UnitSide(SetSideOnly: false)))
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(theTarget.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					}
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(theTarget.CurrentAltitude_AGL, typeof(float)));
				}
				if (!Information.IsNothing((object)AttackWeapon.FiringParent))
				{
					pooledDictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(AttackWeapon.RangeToUnit_Horiz(AttackWeapon.FiringParent), typeof(float)));
				}
				else
				{
					pooledDictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
				}
				switch (theResult)
				{
				case PointDefenceResult.Undefined:
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("UNDEFINED", typeof(string), 20));
					break;
				case PointDefenceResult.WeaponDefeated:
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("POINTDEF:SUCCESS", typeof(string), 20));
					break;
				case PointDefenceResult.WeaponSurvived:
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("POINTDEF:FAILURE", typeof(string), 20));
					break;
				}
				if (Information.IsNothing((object)(theMessages.Count == 0)))
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				}
				else
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(string.Join("|", theMessages), typeof(string)));
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, pooledDictionary, AttackWeapon.ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10123453204592340", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_12(WeaponRec weaponRec_0, Mount mount_0, Weapon weapon_6)
	{
		bool result;
		try
		{
			switch (weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).Type)
			{
			case Weapon._WeaponType.Microwave:
				result = false;
				break;
			case Weapon._WeaponType.Laser:
				result = false;
				break;
			case Weapon._WeaponType.GuidedWeapon:
				result = false;
				break;
			case Weapon._WeaponType.Rocket:
				result = false;
				break;
			default:
				if (mount_0.Status != PlatformComponent._ComponentStatus.Operational)
				{
					result = false;
				}
				else if (weaponRec_0.CurrentLoad != 0)
				{
					Weapon weapon = weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen);
					float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null));
					Weapon._WeaponType type = weapon_6.Type;
					float num2 = ((type != Weapon._WeaponType.Torpedo) ? weapon.MinAirRange : weapon.MinSubsurfaceRange);
					if (num < num2)
					{
						result = false;
						break;
					}
					if (!mount_0.IsAutonomous && !mount_0.IsCountermeasuresDispenser)
					{
						result = false;
						break;
					}
					if (weapon.Type != Weapon._WeaponType.Decoy_Expendable && weapon.Type != Weapon._WeaponType.Decoy_Towed)
					{
						if (weaponRec_0.TimeToFire > 0f)
						{
							result = false;
							break;
						}
					}
					else if (weaponRec_0.TimeToFire > 1f)
					{
						result = false;
						break;
					}
					result = !(mount_0.TimeToFire > 0f) && (method_14(weaponRec_0, weapon_6) ? true : false);
				}
				else
				{
					result = false;
				}
				break;
			case Weapon._WeaponType.Gun:
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100311", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_13(WeaponRec weaponRec_0, Weapon weapon_6)
	{
		bool result;
		try
		{
			float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null));
			result = weaponRec_0.CurrentLoad != 0 && !(num < weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).MinAirRange) && (method_14(weaponRec_0, weapon_6) ? true : false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100312", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_14(WeaponRec weaponRec_0, Weapon weapon_6)
	{
		bool result = default(bool);
		try
		{
			Weapon weapon = weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen);
			if (weapon.IsDecoy)
			{
				int num;
				if (weapon.Type != Weapon._WeaponType.Decoy_Vehicle)
				{
					if (weapon.Type != Weapon._WeaponType.UAV_Expendable)
					{
						bool flag = default(bool);
						switch (weapon_6.AI.PrimaryTarget.Type)
						{
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Missile:
							flag = weapon.ValidTargets.Aircraft;
							break;
						case Contact_Base.ContactType.Surface:
							flag = weapon.ValidTargets.SurfaceVessel;
							break;
						case Contact_Base.ContactType.Submarine:
							flag = weapon.ValidTargets.Submarine;
							break;
						case Contact_Base.ContactType.Facility_Fixed:
							flag = weapon.ValidTargets.LandStructure_Soft || weapon.ValidTargets.LandStructure_Hard;
							break;
						case Contact_Base.ContactType.Facility_Mobile:
						case Contact_Base.ContactType.AggregateGroundUnit:
							flag = weapon.ValidTargets.MobileTarget_Soft || weapon.ValidTargets.MobileTarget_Hard;
							break;
						}
						if (!flag)
						{
							result = false;
							return result;
						}
						bool flag2 = false;
						if (weapon_6.Guidance == Weapon.WeaponGuidanceType.TVM)
						{
							if (weapon.IsRadarCountermeasure)
							{
								flag2 = true;
							}
						}
						else if (!weapon_6.HasInfraredSensor)
						{
							if (!weapon_6.HasLaserSpotTracker)
							{
								foreach (Sensor item in weapon_6.WeaponSensors())
								{
									if (item.IsSonar)
									{
										if (weapon.IsSonarCountermeasure)
										{
											flag2 = true;
										}
										continue;
									}
									switch (item.Type)
									{
									case Sensor.Sensor_Type.Radar:
									case Sensor.Sensor_Type.SemiActive:
										if (weapon.IsRadarCountermeasure)
										{
											flag2 = true;
										}
										break;
									case Sensor.Sensor_Type.Visual:
										if (weapon.IsVisualCountermeasure)
										{
											flag2 = true;
										}
										break;
									case Sensor.Sensor_Type.Infrared:
										if (weapon.IsIRCountermeasure)
										{
											flag2 = true;
										}
										break;
									}
								}
							}
							else if (weapon.IsSmokeGrenade)
							{
								flag2 = true;
							}
						}
						else if (weapon.IsIRCountermeasure)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							result = false;
							return result;
						}
						result = true;
						return result;
					}
					num = 0;
				}
				else
				{
					num = 0;
				}
				result = (byte)num != 0;
				return result;
			}
			switch (weapon_6.Type)
			{
			case Weapon._WeaponType.Torpedo:
				result = weapon.ValidTargets.Torpedo;
				return result;
			case Weapon._WeaponType.GuidedWeapon:
				result = weapon.ValidTargets.Missile && !weapon_6.ValidTargets.Aircraft && !weapon_6.ValidTargets.Missile;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100313", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int HowManyOfThisWeapon(int int_0)
	{
		int num = default(int);
		foreach (Mount mount in myUnit.Mounts)
		{
			num += myUnit.Weaponry.HowManyOfThisWeaponOnMountTotal(mount, int_0);
			num += myUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount, int_0);
		}
		if (myUnit.IsAircraft)
		{
			num += myUnit.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)myUnit).Loadout, int_0);
		}
		return num + myUnit.Weaponry.HowManyOfThisWeaponOnMagazines(int_0);
	}

	public int HowManyOfThisWeaponOnMountTotal(Mount theMount, int int_0)
	{
		int num = 0;
		int result = default(int);
		try
		{
			foreach (WeaponRec mountWeapon in theMount.MountWeapons)
			{
				if (mountWeapon.int_3 == int_0)
				{
					num += mountWeapon.CurrentLoad;
				}
			}
			foreach (WeaponRec weapon in theMount.MountMagazine.Weapons)
			{
				if (weapon.int_3 == int_0)
				{
					num += weapon.CurrentLoad;
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100314", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int HowManyOfThisWeaponOnMountMagazine(Mount theMount, int int_0)
	{
		int num = 0;
		int result = default(int);
		try
		{
			foreach (WeaponRec weapon in theMount.MountMagazine.Weapons)
			{
				if (weapon.int_3 == int_0)
				{
					num += weapon.CurrentLoad;
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100315", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual int HowManyOfThisWeaponOnMagazines(int int_0)
	{
		int num = 0;
		int result = default(int);
		try
		{
			Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation) ? myUnit.SharedMagazines : myUnit.get_ParentGroup(UsingMissionPlanner: false).SharedMagazines);
			if (array != null)
			{
				Magazine[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					ObservableList<WeaponRec> weapons = array2[i].Weapons;
					foreach (WeaponRec item in weapons)
					{
						if (item.int_3 == int_0)
						{
							num += item.CurrentLoad;
						}
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100316", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual int HowManyOfThisWeaponOnLoadout(Loadout theLoadout, int int_0, int PalletWeaponID = 0, Scenario TheScen = null)
	{
		int num = 0;
		int result = default(int);
		try
		{
			if (PalletWeaponID != 0)
			{
				if (TheScen == null)
				{
					throw new Exception("Scenario is requested when checking the loadout for a Pallet Weapon");
				}
				WeaponRec[] weapons = theLoadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.int_3 != PalletWeaponID)
					{
						continue;
					}
					Warhead[] warheads = weaponRec.get_ReferenceWeapon(TheScen).Warheads;
					for (int j = 0; j < warheads.Length; j = checked(j + 1))
					{
						if (warheads[j].get_CarriedWeapon(TheScen) != null)
						{
							num += 1 * weaponRec.CurrentLoad;
						}
					}
				}
				result = num;
				return result;
			}
			WeaponRec[] weapons2 = theLoadout.Weapons;
			foreach (WeaponRec weaponRec2 in weapons2)
			{
				if (weaponRec2.int_3 == int_0)
				{
					num += weaponRec2.CurrentLoad;
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100317", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private int method_15(int int_0)
	{
		int num = 0;
		int result = default(int);
		try
		{
			WeaponSalvo[] array = myUnit.get_UnitSide(SetSideOnly: false).GetWeaponSalvos().ToArray();
			foreach (WeaponSalvo weaponSalvo in array)
			{
				if (weaponSalvo == null || weaponSalvo.int_1 != int_0)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
					{
						int num2 = shooter.QuantityAssigned - shooter.QuantityFired;
						if (num2 > 0 && int.MaxValue - num >= num2)
						{
							num += num2;
						}
						break;
					}
				}
			}
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 234509238456094256", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ReloadMounts()
	{
		try
		{
			if (myUnit.IsAircraft || myUnit.IsWeapon || myUnit.Mounts.Count == 0)
			{
				return;
			}
			int count = myUnit.Mounts.Count;
			int num = myUnit.SharedMagazines.Length;
			Dictionary<int, WeaponSalvo.Shooter> dictionary = new Dictionary<int, WeaponSalvo.Shooter>();
			Doctrine._WCS value = myUnit.Doctrine.get_WeaponControlStatus_Air(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			if (list_3 != null)
			{
				list_3.Clear();
			}
			else
			{
				list_3 = new List<WeaponSalvo>();
			}
			if (list_4 == null)
			{
				list_4 = new List<WeaponSalvo>();
			}
			else
			{
				list_4.Clear();
			}
			List<WeaponSalvo> list;
			try
			{
				list = new List<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				list = new List<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
				ProjectData.ClearProjectError();
			}
			for (int i = list.Count - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo;
				try
				{
					weaponSalvo = list[i];
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
					continue;
				}
				if (weaponSalvo == null || (!weaponSalvo.ManualFire && value == Doctrine._WCS.Hold))
				{
					continue;
				}
				for (int j = weaponSalvo.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter;
					try
					{
						shooter = weaponSalvo.ShootersList[j];
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
						continue;
					}
					if (Operators.CompareString(myUnit.ObjectID, shooter?.ShooterObjectID, false) != 0)
					{
						continue;
					}
					if (shooter.QuantityFired < shooter.QuantityAssigned && !dictionary.ContainsKey(weaponSalvo.int_1))
					{
						dictionary.Add(weaponSalvo.int_1, shooter);
						list_3.Add(weaponSalvo);
						if (weaponSalvo.ManualFire)
						{
							list_4.Add(weaponSalvo);
						}
					}
					break;
				}
			}
			int num2 = count - 1;
			int theQty_FullyLoadedCells2 = default(int);
			int theQty_PartiallyLoadedCells3 = default(int);
			GlobalVariables.BooleanObject TargetIsDestroyed = default(GlobalVariables.BooleanObject);
			int theQty_FullyLoadedCells3 = default(int);
			int theQty_PartiallyLoadedCells5 = default(int);
			for (int k = 0; k <= num2; k++)
			{
				Mount mount_ = myUnit.Mounts[k];
				bool flag = false;
				if (myUnit.AI.PrimaryTarget != null && value != Doctrine._WCS.Hold && myUnit.AI.PrimaryTarget != null && mount_.TargetIsWithinCoverageArc(myUnit.AI.PrimaryTarget))
				{
					foreach (WeaponRec mountWeapon in mount_.MountWeapons)
					{
						if (mountWeapon.CurrentLoad > 0)
						{
							Weapon theWeapon = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
							ActiveUnit_AI aI;
							Contact theTarget = (aI = myUnit.AI).PrimaryTarget;
							int num3 = WeaponSuitabilityForThisTarget(ref theWeapon, ref theTarget, CheckIfWithinRange: true);
							aI.PrimaryTarget = theTarget;
							if (num3 > 0)
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					continue;
				}
				if (mount_.TimeToReloadAttempt > 0f)
				{
					bool flag2 = false;
					foreach (WeaponRec mountWeapon2 in mount_.MountWeapons)
					{
						Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(mountWeapon2.int_3, myUnit.ParentScen);
						int num4;
						if (weaponType != Weapon._WeaponType.Laser)
						{
							if (weaponType != Weapon._WeaponType.LaserDazzler)
							{
								continue;
							}
							num4 = 1;
						}
						else
						{
							num4 = 1;
						}
						flag2 = (byte)num4 != 0;
						break;
					}
					if (!flag2)
					{
						mount_.TimeToReloadAttempt -= 1f;
						continue;
					}
				}
				if (!myUnit.IsFacility && num == 0 && mount_.MountMagazine.Weapons.Count == 0)
				{
					continue;
				}
				if (list_5 != null)
				{
					list_5.Clear();
				}
				else
				{
					list_5 = new List<WeaponRec>();
				}
				if (list_6 != null)
				{
					list_6.Clear();
				}
				else
				{
					list_6 = new List<WeaponRec>();
				}
				if (list_7 == null)
				{
					list_7 = new List<WeaponRec>();
				}
				else
				{
					list_7.Clear();
				}
				if (mount_.Status != PlatformComponent._ComponentStatus.Operational || mount_.MountMagazine.TimeToFire > 0f)
				{
					continue;
				}
				bool flag3 = false;
				foreach (WeaponRec mountWeapon3 in mount_.MountWeapons)
				{
					if (mountWeapon3.MaxLoad == mount_.MaxCapacity)
					{
						flag3 = true;
						break;
					}
				}
				int theQty_PartiallyLoadedCells2;
				if (mount_.MountWeapons.Count <= 1 || !flag3)
				{
					foreach (WeaponRec mountWeapon4 in mount_.MountWeapons)
					{
						WeaponRec weaponRec_ = mountWeapon4;
						if (weaponRec_.CurrentLoad < weaponRec_.MaxLoad && method_18(ref mount_, ref weaponRec_))
						{
							break;
						}
					}
				}
				else
				{
					int num5 = mount_.MountWeapons.Count - 1;
					for (int l = 0; l <= num5; l++)
					{
						WeaponRec weaponRec = mount_.MountWeapons[l];
						if (!weaponRec.get_HasManualReloadPriority(mount_))
						{
							list_7.Add(weaponRec);
							continue;
						}
						if (weaponRec.CurrentLoad < weaponRec.MaxLoad)
						{
							bool flag4 = false;
							foreach (WeaponRec weapon3 in mount_.MountMagazine.Weapons)
							{
								if (weapon3.int_3 == weaponRec.int_3 && weapon3.CurrentLoad > 0)
								{
									flag4 = true;
									break;
								}
							}
							if (!flag4)
							{
								Magazine[] magazines = ((Platform)myUnit).Magazines;
								foreach (Magazine magazine in magazines)
								{
									if (magazine.Status == PlatformComponent._ComponentStatus.Destroyed)
									{
										continue;
									}
									foreach (WeaponRec weapon4 in magazine.Weapons)
									{
										if (weapon4.int_3 == weaponRec.int_3 && weapon4.CurrentLoad > 0)
										{
											flag4 = true;
											break;
										}
									}
									if (flag4)
									{
										break;
									}
								}
							}
							if (flag4)
							{
								list_6.Add(weaponRec);
							}
						}
						list_5.Add(weaponRec);
					}
					foreach (WeaponRec item in list_6)
					{
						WeaponRec weaponRec_2 = item;
						if (weaponRec_2.CurrentLoad >= weaponRec_2.MaxLoad)
						{
							continue;
						}
						if (list_7.Count > 0)
						{
							int num6 = list_7.Count - 1;
							for (int n = 0; n <= num6; n++)
							{
								WeaponRec weaponRec_3 = list_7[n];
								if (weaponRec_3.CurrentLoad > 0)
								{
									Mount mount = mount_;
									int theQty_FullyLoadedCells = 0;
									int theQty_PartiallyLoadedCells = 0;
									if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) >= mount_.MaxCapacity && method_17(ref mount_, ref weaponRec_3))
									{
										method_18(ref mount_, ref weaponRec_2);
									}
								}
							}
						}
						if (list_5.Count > 1)
						{
							int theQty_PartiallyLoadedCells = list_5.Count - 1;
							for (int num7 = 0; num7 <= theQty_PartiallyLoadedCells; num7++)
							{
								WeaponRec weaponRec_3 = list_5[num7];
								if (weaponRec_3 != weaponRec_2 && (double)weaponRec_3.CurrentLoad / (double)weaponRec_3.Multiple - 1.0 > (double)weaponRec_2.CurrentLoad)
								{
									Mount mount2 = mount_;
									int theQty_FullyLoadedCells = 0;
									theQty_PartiallyLoadedCells2 = 0;
									if (mount2.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) >= mount_.MaxCapacity && method_17(ref mount_, ref weaponRec_3))
									{
										method_18(ref mount_, ref weaponRec_2);
									}
								}
							}
						}
						mount_.CurrentCapacity(ref theQty_FullyLoadedCells2, ref theQty_PartiallyLoadedCells3);
						if (theQty_PartiallyLoadedCells3 <= 0 || weaponRec_2.Multiple != 1 || theQty_FullyLoadedCells2 + theQty_PartiallyLoadedCells3 < mount_.MaxCapacity)
						{
							method_18(ref mount_, ref weaponRec_2);
						}
					}
					bool flag5 = false;
					if (dictionary.Count > 0 && list_5.Count == 0)
					{
						if (mount_.MountMagazine.Weapons.Count > 0)
						{
							foreach (WeaponRec mountWeapon5 in mount_.MountWeapons)
							{
								WeaponRec weaponRec_4 = mountWeapon5;
								if (weaponRec_4.get_HasManualReloadPriority(mount_))
								{
									continue;
								}
								Weapon._WeaponType weaponType2 = DBFunctions.GetWeaponType(weaponRec_4.int_3, myUnit.ParentScen);
								if ((uint)(weaponType2 - 2005) <= 2u || HowManyOfThisWeaponOnMountMagazine(mount_, weaponRec_4.int_3) == 0 || !dictionary.ContainsKey(weaponRec_4.int_3))
								{
									continue;
								}
								WeaponSalvo.Shooter shooter2 = dictionary[weaponRec_4.int_3];
								if (Operators.CompareString(shooter2.PreferredMountObjectID, "", false) != 0 && Operators.CompareString(shooter2.PreferredMountObjectID, mount_.ObjectID, false) != 0)
								{
									continue;
								}
								Mount mount3 = mount_;
								theQty_PartiallyLoadedCells2 = 0;
								int theQty_FullyLoadedCells = 0;
								if (mount3.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_FullyLoadedCells) >= mount_.MaxCapacity)
								{
									foreach (WeaponRec mountWeapon6 in mount_.MountWeapons)
									{
										WeaponRec weaponRec_5 = mountWeapon6;
										if (weaponRec_5 != weaponRec_4 && method_17(ref mount_, ref weaponRec_5))
										{
											method_18(ref mount_, ref weaponRec_4);
											break;
										}
									}
								}
								else
								{
									method_18(ref mount_, ref weaponRec_4);
								}
								dictionary.Remove(weaponRec_4.int_3);
								flag5 = true;
								break;
							}
						}
						else if (list_4.Count > 0)
						{
							Mount mount4 = mount_;
							int theQty_FullyLoadedCells = 0;
							theQty_PartiallyLoadedCells2 = 0;
							if (mount4.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) >= mount_.MaxCapacity)
							{
								foreach (WeaponRec mountWeapon7 in mount_.MountWeapons)
								{
									foreach (WeaponSalvo item2 in list_4)
									{
										if (mountWeapon7.int_3 == item2.int_1 && mountWeapon7.CurrentLoad > 0)
										{
											flag5 = true;
											break;
										}
									}
									if (flag5)
									{
										break;
									}
								}
							}
							if (flag5)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon8 in mount_.MountWeapons)
							{
								WeaponRec weaponRec_6 = mountWeapon8;
								if (weaponRec_6.get_HasManualReloadPriority(mount_))
								{
									continue;
								}
								Weapon._WeaponType weaponType3 = DBFunctions.GetWeaponType(weaponRec_6.int_3, myUnit.ParentScen);
								if ((uint)(weaponType3 - 2005) <= 2u || HowManyOfThisWeaponOnMagazines(weaponRec_6.int_3) == 0)
								{
									continue;
								}
								foreach (WeaponSalvo item3 in list_4)
								{
									if (item3.int_1 != weaponRec_6.int_3 || !dictionary.ContainsKey(weaponRec_6.int_3))
									{
										continue;
									}
									WeaponSalvo.Shooter shooter3 = dictionary[weaponRec_6.int_3];
									if (Operators.CompareString(shooter3.PreferredMountObjectID, "", false) != 0 && Operators.CompareString(shooter3.PreferredMountObjectID, mount_.ObjectID, false) != 0)
									{
										continue;
									}
									Mount mount5 = mount_;
									theQty_PartiallyLoadedCells2 = 0;
									theQty_FullyLoadedCells = 0;
									int num10;
									if (mount5.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_FullyLoadedCells) >= mount_.MaxCapacity)
									{
										int num8 = 0;
										theQty_FullyLoadedCells = count - 1;
										for (int num9 = 0; num9 <= theQty_FullyLoadedCells; num9++)
										{
											Mount mount6 = myUnit.Mounts[num9];
											foreach (WeaponRec mountWeapon9 in mount6.MountWeapons)
											{
												if (mountWeapon9.CurrentLoad != 0 && mountWeapon9.int_3 == item3.int_1)
												{
													num8++;
												}
											}
										}
										if (num8 < shooter3.QuantityAssigned - shooter3.QuantityFired)
										{
											foreach (WeaponRec mountWeapon10 in mount_.MountWeapons)
											{
												WeaponRec weaponRec_7 = mountWeapon10;
												if (weaponRec_7.CurrentLoad != 0 && weaponRec_7 != weaponRec_6 && method_17(ref mount_, ref weaponRec_7))
												{
													method_18(ref mount_, ref weaponRec_6);
													break;
												}
											}
										}
									}
									else if (weaponRec_6.CurrentLoad < weaponRec_6.MaxLoad)
									{
										method_18(ref mount_, ref weaponRec_6);
										num10 = 1;
										goto IL_0beb;
									}
									num10 = 1;
									goto IL_0beb;
									IL_0beb:
									flag5 = (byte)num10 != 0;
									break;
								}
								if (flag5)
								{
									break;
								}
							}
						}
						else if (list_3.Count > 0)
						{
							Mount mount7 = mount_;
							theQty_PartiallyLoadedCells2 = 0;
							int theQty_PartiallyLoadedCells4 = 0;
							if (mount7.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_PartiallyLoadedCells4) >= mount_.MaxCapacity)
							{
								foreach (WeaponRec mountWeapon11 in mount_.MountWeapons)
								{
									foreach (WeaponSalvo item4 in list_3)
									{
										if (mountWeapon11.int_3 == item4.int_1 && mountWeapon11.CurrentLoad > 0)
										{
											flag5 = true;
											break;
										}
									}
									if (flag5)
									{
										break;
									}
								}
							}
							if (flag5)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon12 in mount_.MountWeapons)
							{
								WeaponRec weaponRec_8 = mountWeapon12;
								if (weaponRec_8.get_HasManualReloadPriority(mount_))
								{
									continue;
								}
								Weapon._WeaponType weaponType4 = DBFunctions.GetWeaponType(weaponRec_8.int_3, myUnit.ParentScen);
								if ((uint)(weaponType4 - 2005) <= 2u || HowManyOfThisWeaponOnMagazines(weaponRec_8.int_3) == 0)
								{
									continue;
								}
								foreach (WeaponSalvo item5 in list_3)
								{
									if (item5.int_1 != weaponRec_8.int_3 || !dictionary.ContainsKey(weaponRec_8.int_3))
									{
										continue;
									}
									WeaponSalvo.Shooter shooter4 = dictionary[weaponRec_8.int_3];
									if (Operators.CompareString(shooter4.PreferredMountObjectID, "", false) != 0 && Operators.CompareString(shooter4.PreferredMountObjectID, mount_.ObjectID, false) != 0)
									{
										continue;
									}
									Mount mount8 = mount_;
									theQty_PartiallyLoadedCells4 = 0;
									theQty_PartiallyLoadedCells2 = 0;
									int num11;
									if (mount8.CurrentCapacity(ref theQty_PartiallyLoadedCells4, ref theQty_PartiallyLoadedCells2) >= mount_.MaxCapacity)
									{
										foreach (WeaponRec mountWeapon13 in mount_.MountWeapons)
										{
											WeaponRec weaponRec_9 = mountWeapon13;
											if (weaponRec_9.CurrentLoad != 0 && weaponRec_9 != weaponRec_8 && method_17(ref mount_, ref weaponRec_9))
											{
												method_18(ref mount_, ref weaponRec_8);
												break;
											}
										}
									}
									else if (weaponRec_8.CurrentLoad < weaponRec_8.MaxLoad)
									{
										method_18(ref mount_, ref weaponRec_8);
										num11 = 1;
										goto IL_0e4b;
									}
									num11 = 1;
									goto IL_0e4b;
									IL_0e4b:
									flag5 = (byte)num11 != 0;
									break;
								}
								if (flag5)
								{
									break;
								}
							}
						}
					}
					if (flag5)
					{
						continue;
					}
					bool flag6 = false;
					if (!flag5 && list_5.Count == 0 && (myUnit.AI.PrimaryTarget != null || myUnit.AI.Targets_ReadOnly.Length > 0))
					{
						if (list_8 != null)
						{
							list_8.Clear();
						}
						else
						{
							list_8 = new List<WeaponRec>();
						}
						List<WeaponRec> list2;
						if (myUnit.AI.PrimaryTarget != null)
						{
							foreach (WeaponRec mountWeapon14 in mount_.MountWeapons)
							{
								Weapon weapon = mountWeapon14.get_ReferenceWeapon(myUnit.ParentScen);
								if (!weapon.IsDecoy && !weapon.IsTrainingRound)
								{
									ActiveUnit theAttackingUnit = myUnit;
									ActiveUnit_AI aI;
									Contact theTarget = (aI = myUnit.AI).PrimaryTarget;
									bool num12 = weapon.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed);
									aI.PrimaryTarget = theTarget;
									if (num12)
									{
										list_8.Add(mountWeapon14);
									}
								}
							}
							list2 = list_8.OrderByDescending([SpecialName] (WeaponRec theWR) =>
							{
								Weapon theWeapon2 = theWR.get_ReferenceWeapon(myUnit.ParentScen);
								ActiveUnit_AI aI2;
								Contact theTarget2 = (aI2 = myUnit.AI).PrimaryTarget;
								int result = WeaponSuitabilityForThisTarget(ref theWeapon2, ref theTarget2, CheckIfWithinRange: true);
								aI2.PrimaryTarget = theTarget2;
								return result;
							}).ToList();
						}
						else
						{
							foreach (WeaponRec mountWeapon15 in mount_.MountWeapons)
							{
								Weapon weapon2 = mountWeapon15.get_ReferenceWeapon(myUnit.ParentScen);
								if (!weapon2.IsDecoy && !weapon2.IsTrainingRound && weapon2.IsAAWCapable)
								{
									list_8.Add(mountWeapon15);
								}
							}
							list2 = list_8.OrderByDescending([SpecialName] (WeaponRec theWR) => theWR.get_ReferenceWeapon(myUnit.ParentScen).MaxAirRange).ToList();
						}
						if (list2.Count > 0)
						{
							foreach (WeaponRec item6 in list2)
							{
								WeaponRec weaponRec_10 = item6;
								if (HowManyOfThisWeaponOnMountMagazine(mount_, weaponRec_10.int_3) == 0 && HowManyOfThisWeaponOnMagazines(weaponRec_10.int_3) == 0)
								{
									continue;
								}
								Mount mount9 = mount_;
								theQty_PartiallyLoadedCells2 = 0;
								int theQty_PartiallyLoadedCells4 = 0;
								if (mount9.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_PartiallyLoadedCells4) < mount_.MaxCapacity)
								{
									method_18(ref mount_, ref weaponRec_10);
									flag6 = true;
									break;
								}
								foreach (WeaponRec mountWeapon16 in mount_.MountWeapons)
								{
									WeaponRec weaponRec_11 = mountWeapon16;
									if (weaponRec_11 == weaponRec_10 || weaponRec_11.get_HasManualReloadPriority(mount_) || weaponRec_11.CurrentLoad <= 0)
									{
										continue;
									}
									Weapon._WeaponType weaponType5 = DBFunctions.GetWeaponType(weaponRec_11.int_3, myUnit.ParentScen);
									if ((uint)(weaponType5 - 2005) > 2u && myUnit.AI.PrimaryTarget != null)
									{
										Weapon theWeapon = weaponRec_11.get_ReferenceWeapon(myUnit.ParentScen);
										ActiveUnit_AI aI;
										Contact theTarget = (aI = myUnit.AI).PrimaryTarget;
										int num13 = WeaponSuitabilityForThisTarget(ref theWeapon, ref theTarget, CheckIfWithinRange: true);
										aI.PrimaryTarget = theTarget;
										theWeapon = weaponRec_10.get_ReferenceWeapon(myUnit.ParentScen);
										theTarget = (aI = myUnit.AI).PrimaryTarget;
										int num14 = WeaponSuitabilityForThisTarget(ref theWeapon, ref theTarget, CheckIfWithinRange: true);
										aI.PrimaryTarget = theTarget;
										if (num13 < num14 && method_17(ref mount_, ref weaponRec_11))
										{
											method_18(ref mount_, ref weaponRec_10);
											flag6 = true;
											break;
										}
									}
								}
							}
						}
					}
					if (!flag6 && !flag5)
					{
						mount_.CurrentCapacity(ref theQty_FullyLoadedCells3, ref theQty_PartiallyLoadedCells5);
						if (theQty_FullyLoadedCells3 < mount_.MaxCapacity && list_6.Count <= 0)
						{
							int theQty_PartiallyLoadedCells4 = list_7.Count - 1;
							for (int num15 = 0; num15 <= theQty_PartiallyLoadedCells4; num15++)
							{
								WeaponRec weaponRec_3 = list_7[num15];
								if ((theQty_PartiallyLoadedCells5 <= 0 || weaponRec_3.Multiple != 1 || theQty_FullyLoadedCells3 + theQty_PartiallyLoadedCells5 < mount_.MaxCapacity) && DBFunctions.GetWeaponType(weaponRec_3.int_3, myUnit.ParentScen) != Weapon._WeaponType.TrainingRound && weaponRec_3.CurrentLoad < weaponRec_3.MaxLoad)
								{
									method_18(ref mount_, ref weaponRec_3);
								}
							}
						}
					}
				}
				theQty_PartiallyLoadedCells2 = mount_.MountMagazine.Weapons.Count - 1;
				for (int num16 = 0; num16 <= theQty_PartiallyLoadedCells2; num16++)
				{
					WeaponRec weaponRec_3 = mount_.MountMagazine.Weapons[num16];
					if (DBFunctions.GetWeaponType(weaponRec_3.int_3, myUnit.ParentScen) == Weapon._WeaponType.TrainingRound || weaponRec_3.CurrentLoad >= weaponRec_3.MaxLoad)
					{
						continue;
					}
					while (weaponRec_3.CurrentLoad < weaponRec_3.MaxLoad)
					{
						float MagazineReloadTime = 0f;
						if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec_3.int_3, LoadingAircraft: false, ref MagazineReloadTime), "OK") != 0)
						{
							break;
						}
						weaponRec_3.CurrentLoad++;
						mount_.TimeToFire += MagazineReloadTime;
						Mount mount10 = mount_;
						int theQty_FullyLoadedCells4 = 0;
						int theQty_PartiallyLoadedCells6 = 0;
						if (mount10.CurrentCapacity(ref theQty_FullyLoadedCells4, ref theQty_PartiallyLoadedCells6) >= mount_.MaxCapacity)
						{
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100318", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_16(Mount mount_0, List<WeaponRec> list_9)
	{
		bool result = default(bool);
		try
		{
			if (list_9.Count == 0)
			{
				result = false;
				return result;
			}
			foreach (WeaponRec item in list_9)
			{
				foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
				{
					if (weapon.int_3 == item.int_3 && weapon.CurrentLoad > 0)
					{
						result = true;
						return result;
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				foreach (Magazine magazine in sharedMagazines)
				{
					if (magazine.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						if (weapon2.int_3 == item.int_3 && weapon2.CurrentLoad > 0)
						{
							result = true;
							return result;
						}
					}
				}
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100319", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_17(ref Mount mount_0, ref WeaponRec weaponRec_0)
	{
		Mount obj = mount_0;
		int theQty_FullyLoadedCells = 0;
		int theQty_PartiallyLoadedCells = 0;
		bool result;
		if (obj.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) != 0)
		{
			if (weaponRec_0.CurrentLoad != 0)
			{
				if (weaponRec_0.TimeToFire > 0f)
				{
					result = false;
				}
				else
				{
					try
					{
						foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
						{
							WeaponRec weaponRec_1 = weapon;
							if (weaponRec_1.int_3 != weaponRec_0.int_3 || string.CompareOrdinal(method_20(ref weaponRec_1), "OK") != 0)
							{
								continue;
							}
							if (weaponRec_0.Multiple > 1)
							{
								theQty_PartiallyLoadedCells = weaponRec_0.Multiple;
								for (int i = 1; i <= theQty_PartiallyLoadedCells; i++)
								{
									weaponRec_0.CurrentLoad -= 1;
									float num = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
									if (num == (float)(int)Math.Round(num))
									{
										break;
									}
								}
							}
							else
							{
								weaponRec_0.CurrentLoad -= 1;
							}
							weaponRec_0.ResetTimeToFire();
							mount_0.ReloadStatus = Mount._ReloadStatus.Unloading;
							mount_0.MountMagazine.ResetTimeToFire();
							result = true;
							goto end_IL_0037;
						}
						if (string.CompareOrdinal(AddWeaponToMagazines(weaponRec_0.int_3, PriorityToAviationMags: false, AllowAddingNewWeaponRec: true, AllowOverfill: true), "OK") != 0)
						{
							result = false;
						}
						else
						{
							if (weaponRec_0.Multiple > 1)
							{
								theQty_FullyLoadedCells = weaponRec_0.Multiple;
								for (int j = 1; j <= theQty_FullyLoadedCells; j++)
								{
									weaponRec_0.CurrentLoad -= 1;
									float num2 = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
									if (num2 == (float)(int)Math.Round(num2))
									{
										break;
									}
								}
							}
							else
							{
								weaponRec_0.CurrentLoad -= 1;
							}
							mount_0.ReloadStatus = Mount._ReloadStatus.Unloading;
							weaponRec_0.ResetTimeToFire();
							result = true;
						}
						end_IL_0037:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 100320", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						int num3;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num3 = 0;
						}
						else
						{
							num3 = 0;
						}
						result = (byte)num3 != 0;
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				result = false;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool method_18(ref Mount mount_0, ref WeaponRec weaponRec_0)
	{
		bool result = default(bool);
		if (!mount_0.IsLauncherOccupied())
		{
			Mount obj = mount_0;
			int theQty_PartiallyLoadedCells = 0;
			int theQty_FullyLoadedCells = default(int);
			obj.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
			if (theQty_FullyLoadedCells < mount_0.MaxCapacity)
			{
				try
				{
					while (weaponRec_0.CurrentLoad < weaponRec_0.MaxLoad)
					{
						if (weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).IsLaserShot && weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).Warheads[0].LaserType == Warhead._LaserType.SolidState && myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse && (myUnit.IsFacility || myUnit.Propulsion.Count > 0 || myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() > 0))
						{
							weaponRec_0.CurrentLoad += 1;
							result = true;
							break;
						}
						foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
						{
							WeaponRec weaponRec_1 = weapon;
							if (weaponRec_1.int_3 != weaponRec_0.int_3 || string.CompareOrdinal(method_19(ref weaponRec_1), "OK") != 0)
							{
								continue;
							}
							if (weaponRec_0.Multiple > 1)
							{
								theQty_PartiallyLoadedCells = weaponRec_0.Multiple;
								for (int num = 1; num <= theQty_PartiallyLoadedCells; num++)
								{
									weaponRec_0.CurrentLoad += 1;
									float num2 = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
									if (num2 == (float)(int)Math.Round(num2))
									{
										break;
									}
								}
							}
							else
							{
								weaponRec_0.CurrentLoad += 1;
							}
							mount_0.TimeToFire += mount_0.MountMagazine.ROF;
							if (mount_0.TimeToFire > (float)(mount_0.MaxCapacity * mount_0.MountMagazine.ROF))
							{
								mount_0.TimeToFire = mount_0.MaxCapacity * mount_0.MountMagazine.ROF;
							}
							mount_0.ReloadStatus = Mount._ReloadStatus.Reloading;
							Mount obj2 = mount_0;
							int theQty_FullyLoadedCells2 = 0;
							int theQty_PartiallyLoadedCells2 = 0;
							if (obj2.CurrentCapacity(ref theQty_FullyLoadedCells2, ref theQty_PartiallyLoadedCells2) >= mount_0.MaxCapacity)
							{
								result = true;
								goto end_IL_0341;
							}
						}
						float MagazineReloadTime = 0f;
						bool flag = false;
						if (weaponRec_0.Multiple > 1)
						{
							int theQty_PartiallyLoadedCells2 = weaponRec_0.Multiple;
							for (int num3 = 1; num3 <= theQty_PartiallyLoadedCells2; num3++)
							{
								if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec_0.int_3, LoadingAircraft: false, ref MagazineReloadTime), "OK") == 0)
								{
									flag = true;
									weaponRec_0.CurrentLoad += 1;
									float num4 = (float)weaponRec_0.CurrentLoad / (float)weaponRec_0.Multiple;
									if (num4 == (float)(int)Math.Round(num4))
									{
										break;
									}
								}
							}
						}
						else if (string.CompareOrdinal(RemoveWeaponFromMagazines(weaponRec_0.int_3, LoadingAircraft: false, ref MagazineReloadTime), "OK") == 0)
						{
							flag = true;
							weaponRec_0.CurrentLoad += 1;
						}
						if (flag)
						{
							mount_0.TimeToFire += MagazineReloadTime;
							if (mount_0.TimeToFire > (float)mount_0.MaxCapacity * MagazineReloadTime)
							{
								mount_0.TimeToFire = (float)mount_0.MaxCapacity * MagazineReloadTime;
							}
							mount_0.ReloadStatus = Mount._ReloadStatus.Reloading;
							Mount obj3 = mount_0;
							int theQty_FullyLoadedCells2 = 0;
							obj3.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_FullyLoadedCells2);
							if (theQty_FullyLoadedCells == mount_0.MaxCapacity)
							{
								result = true;
								break;
							}
							continue;
						}
						result = false;
						break;
						continue;
						end_IL_0341:
						break;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100321", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num5;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num5 = 0;
					}
					else
					{
						num5 = 0;
					}
					result = (byte)num5 != 0;
					ProjectData.ClearProjectError();
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public virtual string CanAddWeaponToUnit(int int_0, bool IsAircraftWeapon, bool AllowCreatingNewWeaponRecOnMagazines)
	{
		string result = default(string);
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			foreach (Magazine magazine in array)
			{
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				if (magazine.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) >= magazine.Capacity)
				{
					continue;
				}
				foreach (WeaponRec weapon in magazine.Weapons)
				{
					if (weapon.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			if (AllowCreatingNewWeaponRecOnMagazines && ((Platform)myUnit).SharedMagazines.Length > 0)
			{
				totalMagazines = ((Platform)myUnit).SharedMagazines;
				if (IsAircraftWeapon)
				{
					totalMagazines = totalMagazines.OrderByDescending([SpecialName] (Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
				}
				Magazine magazine2 = totalMagazines[0];
				int theQty_PartiallyLoadedCells2;
				int theQty_FullyLoadedCells;
				if (totalMagazines.Count() > 1)
				{
					Magazine[] array2 = totalMagazines;
					foreach (Magazine magazine3 in array2)
					{
						theQty_FullyLoadedCells = 0;
						theQty_PartiallyLoadedCells2 = 0;
						if (magazine3.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) < magazine3.Capacity)
						{
							magazine2 = magazine3;
							break;
						}
					}
				}
				Magazine magazine4 = magazine2;
				theQty_PartiallyLoadedCells2 = 0;
				theQty_FullyLoadedCells = 0;
				if (magazine4.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_FullyLoadedCells) < magazine2.Capacity)
				{
					result = "OK";
					return result;
				}
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells2 = 0;
				if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual string CanReplenishWeaponToUnit(int int_0, bool IsAircraftWeapon, bool AllowCreatingNewWeaponRecOnMagazines)
	{
		string result = default(string);
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			foreach (Magazine magazine in array)
			{
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				if (magazine.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) >= magazine.Capacity)
				{
					continue;
				}
				foreach (WeaponRec weapon in magazine.Weapons)
				{
					if (weapon.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad && (weapon.WRecDBID.HasValue || weapon.MaxLoad < 10000))
					{
						result = "OK";
						return result;
					}
				}
			}
			if (AllowCreatingNewWeaponRecOnMagazines && ((Platform)myUnit).SharedMagazines.Length > 0)
			{
				totalMagazines = ((Platform)myUnit).SharedMagazines;
				if (IsAircraftWeapon)
				{
					totalMagazines = totalMagazines.OrderByDescending([SpecialName] (Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
				}
				Magazine magazine2 = totalMagazines[0];
				int theQty_PartiallyLoadedCells2;
				int theQty_FullyLoadedCells;
				if (totalMagazines.Count() > 1)
				{
					Magazine[] array2 = totalMagazines;
					foreach (Magazine magazine3 in array2)
					{
						theQty_FullyLoadedCells = 0;
						theQty_PartiallyLoadedCells2 = 0;
						if (magazine3.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) < magazine3.Capacity)
						{
							magazine2 = magazine3;
							break;
						}
					}
				}
				Magazine magazine4 = magazine2;
				theQty_PartiallyLoadedCells2 = 0;
				theQty_FullyLoadedCells = 0;
				if (magazine4.CurrentCapacity(ref theQty_PartiallyLoadedCells2, ref theQty_FullyLoadedCells) < magazine2.Capacity)
				{
					result = "OK";
					return result;
				}
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells2 = 0;
				if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells2) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual string AddWeaponToUnit(int int_0, bool IsAircraftWeapon, bool AllowCreatingNewWeaponRecOnMagazines)
	{
		string result = default(string);
		try
		{
			if (Operators.CompareString(AddWeaponToMagazines(int_0, IsAircraftWeapon, AllowCreatingNewWeaponRecOnMagazines), "OK", false) == 0)
			{
				result = "OK";
				return result;
			}
			foreach (Mount mount in myUnit.Mounts)
			{
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) >= mount.MaxCapacity)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.int_3 == int_0 && mountWeapon.CurrentLoad < mountWeapon.MaxLoad)
					{
						mountWeapon.CurrentLoad++;
						result = "OK";
						return result;
					}
				}
			}
			result = "Failed";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100322", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual string AddWeaponToMagazines(int int_0, bool PriorityToAviationMags, bool AllowAddingNewWeaponRec, bool AllowOverfill = false)
	{
		string result = default(string);
		try
		{
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			Magazine[] array = totalMagazines;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (string.CompareOrdinal(array[num].AddWeapon(int_0, AllowOverfill), "OK") == 0)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				if (AllowAddingNewWeaponRec && ((Platform)myUnit).SharedMagazines.Length > 0)
				{
					totalMagazines = ((Platform)myUnit).SharedMagazines;
					if (PriorityToAviationMags)
					{
						totalMagazines = totalMagazines.OrderByDescending([SpecialName] (Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
					}
					Magazine magazine = totalMagazines[0];
					if (totalMagazines.Count() > 1)
					{
						Magazine[] array2 = totalMagazines;
						foreach (Magazine magazine2 in array2)
						{
							int theQty_FullyLoadedCells = 0;
							int theQty_PartiallyLoadedCells = 0;
							if (magazine2.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) < magazine2.Capacity)
							{
								magazine = magazine2;
								break;
							}
						}
					}
					if (magazine.Capacity != 10000)
					{
						Magazine magazine3 = magazine;
						int theQty_PartiallyLoadedCells = 0;
						int theQty_FullyLoadedCells = 0;
						if (magazine3.CurrentCapacity(ref theQty_PartiallyLoadedCells, ref theQty_FullyLoadedCells) >= magazine.Capacity)
						{
							goto IL_0161;
						}
					}
					WeaponRec item = new WeaponRec(ref myUnit.ParentScen, int_0, 0, 10000, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
					magazine.Weapons.Add(item);
					if (string.CompareOrdinal(magazine.AddWeapon(int_0), "OK") == 0)
					{
						magazine.RaiseEventStatusChanged();
						result = "OK";
						return result;
					}
				}
				goto IL_0161;
				IL_0161:
				result = "Failed";
				return result;
			}
			result = "OK";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100323", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual string RemoveWeaponFromMagazines(int int_0, bool LoadingAircraft, ref float MagazineReloadTime)
	{
		string result = default(string);
		try
		{
			if (LoadingAircraft && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				result = "OK";
				return result;
			}
			Magazine[] magazines = ((Platform)myUnit).Magazines;
			int num = 0;
			Magazine magazine;
			while (true)
			{
				if (num < magazines.Length)
				{
					magazine = magazines[num];
					if (magazine.Status != PlatformComponent._ComponentStatus.Destroyed && Operators.CompareString(magazine.RemoveWeapon(int_0, LoadingAircraft, ref MagazineReloadTime), "OK", false) == 0)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = "Weapon not found in magazines";
				return result;
			}
			MagazineReloadTime = magazine.ROF;
			result = "OK";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100324", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string method_19(ref WeaponRec weaponRec_0)
	{
		string result = default(string);
		try
		{
			if (weaponRec_0.TimeToFire > 0f)
			{
				result = "Cannot yet load/fire from this weapon record (TimeToFire > 0)";
				return result;
			}
			if (weaponRec_0.CurrentLoad != 0)
			{
				weaponRec_0.CurrentLoad -= 1;
				result = "OK";
				return result;
			}
			result = "Weapon record is empty";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100325", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string method_20(ref WeaponRec weaponRec_0)
	{
		string result = default(string);
		try
		{
			if (weaponRec_0.CurrentLoad == weaponRec_0.MaxLoad)
			{
				result = "Weapon record is full";
				return result;
			}
			weaponRec_0.CurrentLoad += 1;
			result = "OK";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100326", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void FireChaffBundle(float elapsedTime)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		try
		{
			foreach (Mount mount in myUnit.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.CurrentLoad != 0 && mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).IsChaffBundle && mount.Status == PlatformComponent._ComponentStatus.Operational && mount.TimeToFire == 0f && mountWeapon.TimeToFire == 0f)
					{
						list.Add(mountWeapon);
					}
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec current2 in weapons)
				{
					current2.ParentMount = null;
					if (current2.get_ReferenceWeapon(myUnit.ParentScen).IsChaffBundle && current2.CurrentLoad != 0 && !(current2.TimeToFire > 0f))
					{
						list.Add(current2);
					}
				}
			}
			switch (list.Count)
			{
			default:
			{
				WeaponRec theWeaponRec2 = list[GameGeneral.GlobalRNG.Next(0, list.Count)];
				int NumberOfWeaponsFired = 0;
				WeaponSalvo theWeaponSalvo = null;
				FireWeapon_Normal(elapsedTime, ref theWeaponRec2, null, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
				break;
			}
			case 1:
			{
				List<WeaponRec> list2;
				WeaponRec theWeaponRec = (list2 = list)[0];
				int NumberOfWeaponsFired = 0;
				WeaponSalvo theWeaponSalvo = null;
				FireWeapon_Normal(elapsedTime, ref theWeaponRec, null, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
				list2[0] = theWeaponRec;
				break;
			}
			case 0:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100476", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(ActiveUnit activeUnit_0, ref UnguidedWeapon unguidedWeapon_0, StringBuilder stringBuilder_1)
	{
		try
		{
			if (activeUnit_0.IsAircraft)
			{
				switch (((Aircraft)activeUnit_0).BombSightTech)
				{
				case Aircraft._BombsightTech.Basic:
					stringBuilder_1?.Append("Basic-tech bombsight - accuracy unaffected. ");
					break;
				case Aircraft._BombsightTech.Ballistic:
					unguidedWeapon_0.CEP_Land = (float)(0.75 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.75 * (double)unguidedWeapon_0.CEP_Surface);
					stringBuilder_1?.Append("Ballistic-tech bombsight - accuracy improved by 25%. ");
					break;
				case Aircraft._BombsightTech.Computing:
					unguidedWeapon_0.CEP_Land = (float)(0.5 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.5 * (double)unguidedWeapon_0.CEP_Surface);
					stringBuilder_1?.Append("Computing-tech bombsight - accuracy improved by 50%. ");
					break;
				case Aircraft._BombsightTech.Advanced:
					unguidedWeapon_0.CEP_Land = (float)(0.2 * (double)unguidedWeapon_0.CEP_Land);
					unguidedWeapon_0.CEP_Surface = (float)(0.2 * (double)unguidedWeapon_0.CEP_Surface);
					stringBuilder_1?.Append("Advanced-tech bombsight - accuracy improved by 80%. ");
					break;
				}
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit_0.Proficiency;
				int? num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					unguidedWeapon_0.CEP_Land *= 2f;
					unguidedWeapon_0.CEP_Surface *= 2f;
					stringBuilder_1?.Append("Crew is Novice - accuracy reduced by 100%. ");
				}
				else
				{
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
					{
						num = (int?)proficiency;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
						{
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
							stringBuilder_1?.Append("Crew is Regular - accuracy reduced by 20%. ");
						}
						else
						{
							num = (int?)proficiency;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
							{
								num = (int?)proficiency;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
								{
									unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.5);
									unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.5);
									stringBuilder_1?.Append("Crew is Ace - accuracy improved by 100%. ");
								}
							}
							else
							{
								stringBuilder_1?.Append("Crew is Veteran - accuracy unaffected. ");
							}
						}
					}
					else
					{
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						stringBuilder_1?.Append("Crew is Cadet - accuracy reduced by 50%. ");
					}
				}
				if (unguidedWeapon_0.Type != Weapon._WeaponType.IronBomb || !(activeUnit_0.CurrentAltitude_AGL > 609.60004f))
				{
					return;
				}
				float num2 = (activeUnit_0.CurrentAltitude_AGL - 609.60004f) / 1500f;
				if (num2 > 0f)
				{
					switch (((Aircraft)activeUnit_0).BombSightTech)
					{
					case Aircraft._BombsightTech.Basic:
						unguidedWeapon_0.CEP_Land += num2 * 100f;
						unguidedWeapon_0.CEP_Surface += num2 * 100f;
						stringBuilder_1?.Append("Basic-tech bombsight and ").Append(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)).Append("m altitude - accuracy decreased by ")
							.Append((int)Math.Round(num2))
							.Append("%. ");
						break;
					case Aircraft._BombsightTech.Ballistic:
						unguidedWeapon_0.CEP_Land += num2 * 75f;
						unguidedWeapon_0.CEP_Surface += num2 * 75f;
						stringBuilder_1?.Append("Ballistic-tech bombsight and ").Append(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)).Append("m altitude - accuracy decreased by ")
							.Append((int)Math.Round(num2))
							.Append("%. ");
						break;
					case Aircraft._BombsightTech.Computing:
						unguidedWeapon_0.CEP_Land += num2 * 50f;
						unguidedWeapon_0.CEP_Surface += num2 * 50f;
						stringBuilder_1?.Append("Computing-tech bombsight and ").Append(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)).Append("m altitude - accuracy decreased by ")
							.Append((int)Math.Round(num2))
							.Append("%. ");
						break;
					case Aircraft._BombsightTech.Advanced:
						unguidedWeapon_0.CEP_Land += num2 * 25f;
						unguidedWeapon_0.CEP_Surface += num2 * 25f;
						stringBuilder_1?.Append("Advanced-tech bombsight and ").Append(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)).Append("m altitude - accuracy decreased by ")
							.Append((int)Math.Round(num2))
							.Append("%. ");
						break;
					}
				}
			}
			else
			{
				if (!activeUnit_0.IsShip)
				{
					return;
				}
				int seaState = Weather.get_WeatherAtThisTimeAndPlace(activeUnit_0.ParentScen, activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), 0).SeaState;
				switch (((Ship)activeUnit_0).VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
						stringBuilder_1?.Append("Sea state 0-2 & very small ship - accuracy unaffected. ");
						break;
					case 3:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						stringBuilder_1?.Append("Sea state 3 & very small ship - accuracy decreased by 10%. ");
						break;
					case 4:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						stringBuilder_1?.Append("Sea state 4 & very small ship - accuracy decreased by 20%. ");
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						stringBuilder_1?.Append("Sea state 5 & very small ship - accuracy decreased by 20%. ");
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						stringBuilder_1?.Append("Sea state 6 & very small ship - accuracy decreased by 50%. ");
						break;
					case 7:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						stringBuilder_1?.Append("Sea state 7 & very small ship - accuracy decreased by 100%. ");
						break;
					case 8:
						unguidedWeapon_0.CEP_Land *= 3f;
						unguidedWeapon_0.CEP_Surface *= 3f;
						stringBuilder_1?.Append("Sea state 8 & very small ship - accuracy decreased by 200%. ");
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 4f;
						unguidedWeapon_0.CEP_Surface *= 4f;
						stringBuilder_1?.Append("Sea state 9 & very small ship - accuracy decreased by 300%. ");
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
						stringBuilder_1?.Append("Sea state 0-3 & small ship - accuracy unaffected. ");
						break;
					case 4:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						stringBuilder_1?.Append("Sea state 4 & small ship - accuracy decreased by 10%. ");
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						stringBuilder_1?.Append("Sea state 5 & small ship - accuracy decreased by 20%. ");
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						stringBuilder_1?.Append("Sea state 6 & small ship - accuracy decreased by 30%. ");
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						stringBuilder_1?.Append("Sea state 7 & small ship - accuracy decreased by 50%. ");
						break;
					case 8:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						stringBuilder_1?.Append("Sea state 8 & small ship - accuracy decreased by 100%. ");
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 3f;
						unguidedWeapon_0.CEP_Surface *= 3f;
						stringBuilder_1?.Append("Sea state 9 & small ship - accuracy decreased by 200%. ");
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
						stringBuilder_1?.Append("Sea state 0-4 & medium ship - accuracy unaffected. ");
						break;
					case 5:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						stringBuilder_1?.Append("Sea state 5 & medium ship - accuracy decreased by 10%. ");
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						stringBuilder_1?.Append("Sea state 6 & medium ship - accuracy decreased by 20%. ");
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						stringBuilder_1?.Append("Sea state 7 & medium ship - accuracy decreased by 30%. ");
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						stringBuilder_1?.Append("Sea state 8 & medium ship - accuracy decreased by 50%. ");
						break;
					case 9:
						unguidedWeapon_0.CEP_Land *= 2f;
						unguidedWeapon_0.CEP_Surface *= 2f;
						stringBuilder_1?.Append("Sea state 9 & medium ship - accuracy decreased by 100%. ");
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						stringBuilder_1?.Append("Sea state 0-5 & large ship - accuracy unaffected. ");
						break;
					case 6:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						stringBuilder_1?.Append("Sea state 6 & large ship - accuracy decreased by 10%. ");
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						stringBuilder_1?.Append("Sea state 7 & large ship - accuracy decreased by 20%. ");
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						stringBuilder_1?.Append("Sea state 8 & large ship - accuracy decreased by 30%. ");
						break;
					case 9:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
						stringBuilder_1?.Append("Sea state 9 & large ship - accuracy decreased by 50%. ");
						break;
					}
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					switch (seaState)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						stringBuilder_1?.Append("Sea state 0-6 & very large ship - accuracy unaffected. ");
						break;
					case 7:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.1);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.1);
						stringBuilder_1?.Append("Sea state 7 & very large ship - accuracy decreased by 10%. ");
						break;
					case 8:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
						stringBuilder_1?.Append("Sea state 8 & very large ship - accuracy decreased by 20%. ");
						break;
					case 9:
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.3);
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.3);
						stringBuilder_1?.Append("Sea state 9 & very large ship - accuracy decreased by 30%. ");
						break;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100328", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_22(WeaponRec weaponRec_0, Weapon weapon_6, WeaponSalvo weaponSalvo_0, Contact contact_0)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		stringBuilder.Clear();
		string name = weaponRec_0.get_ReferenceWeapon(myUnit.ParentScen).Name;
		new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null));
		stringBuilder.Append("Attacks with contact bomb: ").Append(name);
		myUnit.EndgameReport.AddEndGameMessage(hit: false, stringBuilder.ToString());
		weaponRec_0.CurrentLoad--;
		weaponRec_0.ResetTimeToFire();
		float num = weapon_6.BasePoK_AnyTarget();
		if ((float)GameGeneral.GlobalRNG.Next(1, 101) < num)
		{
			if (weapon_6.Warheads.Count() > 0)
			{
				Weapon.RaiseEvent_WeaponImpact(myUnit.ParentScen, weapon_6, contact_0, DirectHit: true);
			}
			float theAltitude = ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			if (contact_0.ActualUnit != null)
			{
				theAltitude = contact_0.ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			Warhead[] warheads = weapon_6.Warheads;
			foreach (Warhead warhead in warheads)
			{
				new Explosion(ref myUnit.ParentScen, null, ref contact_0, ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), contact_0.CurrentHeading, theAltitude, weapon_6.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, contact_0.ActualUnit, null, myUnit, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads, warhead.DP).CurrentHeading = myUnit.CurrentHeading;
			}
			if (weaponSalvo_0 != null)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
					{
						shooter.QuantityFired++;
					}
				}
				myUnit.get_UnitSide(SetSideOnly: false).AttemptToRemoveWeaponSalvo(ref myUnit.ParentScen, weaponSalvo_0);
			}
			string text = "Has detonated on the target";
			if (weapon_6.Type == Weapon._WeaponType.ContactBomb_Suicide)
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, "Contact bomb detonated", "Self-destruct");
				text = text + ", " + myUnit.Name + " was destroyed";
			}
			myUnit.EndgameReport.AddEndGameMessage(hit: true, text);
			StringBuilderCache.Free(stringBuilder);
		}
		else
		{
			myUnit.EndgameReport.AddEndGameMessage(hit: false, "Has malfunctioned");
			myUnit.ParentScen.DestroyThisUnit(myUnit, "Has malfunctioned", "Malfunction");
		}
	}

	private void method_23(Weapon weapon_6)
	{
		if (weapon_6.Warheads.Count() > 0)
		{
			switch (weapon_6.Warheads[0].Caliber)
			{
			case Warhead.WarheadCaliber.Rocket_6_15mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 2f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 2f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Acoustic_AirGround, 2f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_16_24mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 4f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 4f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_25_60mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 8f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 8f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_61_80mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 14f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 14f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_81_150mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 25f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 25f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_151_200mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 35f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 35f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_201_350mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 45f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 45f, 4);
				break;
			case Warhead.WarheadCaliber.Rocket_351_450mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 55f, 4);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 55f, 4);
				break;
			case Warhead.WarheadCaliber.Gun_6_15mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 2f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 2f);
				break;
			case Warhead.WarheadCaliber.Gun_16_24mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 4f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 4f);
				break;
			case Warhead.WarheadCaliber.Gun_25_60mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 8f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 8f);
				break;
			case Warhead.WarheadCaliber.Gun_61_80mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 14f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 14f);
				break;
			case Warhead.WarheadCaliber.Gun_81_150mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 25f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 25f);
				break;
			case Warhead.WarheadCaliber.Gun_151_200mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 35f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 35f);
				break;
			case Warhead.WarheadCaliber.Gun_201_350mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 45f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 45f);
				break;
			case Warhead.WarheadCaliber.Gun_351_450mm:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 55f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 55f);
				break;
			case Warhead.WarheadCaliber.None:
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Visual_Detect, 20f);
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.IR_Detect, 20f);
				break;
			}
			if (weapon_6.Warheads[0].Caliber != Warhead.WarheadCaliber.None)
			{
				myUnit.TemporarySignatureIncrease_Absolute(XSection._SignatureType.Acoustic_AirGround, 1f, 4);
			}
		}
	}

	private void method_24(string string_0, Mount mount_0)
	{
		if (mount_0 != null)
		{
			mount_0.LastFiredWeaponID = string_0;
		}
	}

	internal List<Module_Unit.Unit> FireWeapon_Normal(float elapsedTime, ref WeaponRec theWeaponRec, Contact theTarget, ref int NumberOfWeaponsFired, int SpecificNumberOfWeaponsToFire = 0, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Flank, Mount FiringMount = null, SonarModel.PositionRelativeToThermocline SonobuoyDepthSetting = SonarModel.PositionRelativeToThermocline.Above, long ArmDelay_sec = 0L, [Optional][DefaultParameterValue(null)] ref WeaponSalvo theWeaponSalvo)
	{
		_Closure$__130-0 arg = default(_Closure$__130-0);
		_Closure$__130-0 CS$<>8__locals65 = new _Closure$__130-0(arg);
		CS$<>8__locals65.$VB$Local_theTarget = theTarget;
		float num = default(float);
		if (CS$<>8__locals65.$VB$Local_theTarget != null)
		{
			num = myUnit.RangeToUnit_Horiz(CS$<>8__locals65.$VB$Local_theTarget);
		}
		Weapon weapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		try
		{
			method_23(weapon);
			long num2;
			MiningMission miningMission;
			Waypoint waypoint2;
			GeoPoint geoPoint2;
			Waypoint waypoint;
			float bearing;
			UnguidedWeapon unguidedWeapon;
			double lon;
			double lat;
			double out_lon;
			GeoPoint geoPoint;
			double out_lat;
			GeoPoint geoPoint3;
			switch (weapon.Type)
			{
			case Weapon._WeaponType.Sonobuoy:
			{
				Weapon newWeapon3 = Weapon.GetNewWeapon(ref myUnit.ParentScen, theWeaponRec.int_3, bool_5: false);
				newWeapon3.CEP_Surface = newWeapon3.CEP_Surface_Nominal;
				newWeapon3.CEP_Land = newWeapon3.CEP_Land_Nominal;
				FireGuidedWeapon(elapsedTime, myUnit, newWeapon3, theWeaponRec.int_3, null, FiringMount, myUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, SonobuoyDepthSetting);
				theWeaponRec.CurrentLoad -= 1;
				theWeaponRec.ResetTimeToFire();
				NumberOfWeaponsFired = 1;
				list.Add(newWeapon3);
				break;
			}
			case Weapon._WeaponType.AttachedMine:
			{
				Mission mission = myUnit.ActiveMissionOrPackage();
				int num3;
				if (mission != null)
				{
					if (mission.MissionClass == Mission._MissionClass.Mining)
					{
						num2 = ((MiningMission)myUnit.ActiveMissionOrPackage()).ArmDelay;
						goto IL_01b1;
					}
					num3 = 7200;
				}
				else
				{
					num3 = 7200;
				}
				num2 = num3;
				goto IL_01b1;
			}
			case Weapon._WeaponType.BottomMine:
			case Weapon._WeaponType.MooredMine:
			case Weapon._WeaponType.FloatingMine:
			case Weapon._WeaponType.MovingMine:
			case Weapon._WeaponType.RisingMine:
			case Weapon._WeaponType.DriftingMine:
			case Weapon._WeaponType.DummyMine:
			{
				UnguidedWeapon theM = new UnguidedWeapon(weapon, null, null, 0.0, 0.0, ArmDelay_sec);
				theM.set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
				if (string.CompareOrdinal(UnguidedWeapon.CanLayMineHere(ref theM, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen), "OK") != 0)
				{
					break;
				}
				myUnit.ParentScen.UnguidedWeapons.AddOrUpdate(theM.ObjectID, theM);
				theWeaponRec.CurrentLoad -= 1;
				theWeaponRec.ResetTimeToFire();
				NumberOfWeaponsFired = 1;
				list.Add(theM);
				ActivationPointContact theTarget2 = new ActivationPointContact(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				theM.FiringParent = myUnit;
				theM.FiringParent_ID = myUnit.ObjectID;
				ExportWeaponFireEvent(theTarget2, theM, theWeaponSalvo);
				Mission mission2 = myUnit.ActiveMissionOrPackage();
				bool? flag = ((mission2 == null) ? ((bool?)null) : new bool?(mission2.MissionClass == Mission._MissionClass.Mining));
				if (((!flag) ?? false) || myUnit.IsAircraft || !flag.HasValue)
				{
					break;
				}
				miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
				if (myUnit.AI.MiningInfo == null)
				{
					myUnit.AI.MiningInfo = new MiningMission.MiningInformation(theM, miningMission.MinesLaidInSets, miningMission.MinesLaidInterval, miningMission.MinesLaidMethod, miningMission.MinesLaidSetInterval);
					if (myUnit.AI.MiningInfo.Sequence.HasValue)
					{
						myUnit.AI.MiningInfo.Sequence--;
					}
				}
				else
				{
					myUnit.AI.MiningInfo.LastMineLocal = theM;
					if (myUnit.AI.MiningInfo.Sequence.HasValue)
					{
						myUnit.AI.MiningInfo.Sequence--;
					}
				}
				if (miningMission.MovementStyle != Patrol.PatrolMovementStyle.RandomWithinArea || miningMission.Area.Count <= 2)
				{
					break;
				}
				if (myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Creator == Waypoint.WaypointCreator.Manual)
				{
					if (myUnit.AI.MiningInfo == null)
					{
						break;
					}
					int? sequence = myUnit.AI.MiningInfo.Sequence;
					if ((sequence.HasValue ? new bool?(sequence.GetValueOrDefault() < 1) : ((bool?)null)) != true)
					{
						if (miningMission.MinesLaidMethod.HasValue)
						{
							sequence = miningMission.MinesLaidMethod;
							if (((!sequence.HasValue) ? ((bool?)null) : new bool?(sequence == 1)) != true)
							{
							}
						}
					}
					else
					{
						myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
					}
					break;
				}
				waypoint2 = null;
				if (myUnit.Navigator.PlottedCourse.Count() == 1)
				{
					waypoint2 = myUnit.Navigator.PlottedCourse[0];
				}
				else if (myUnit.Navigator.PlottedCourse.Count() > 1)
				{
					waypoint2 = myUnit.Navigator.PlottedCourse[1];
				}
				myUnit.Navigator.ClearPlottedCourse();
				geoPoint2 = new GeoPoint();
				waypoint = new Waypoint();
				float desiredHeading = myUnit.DesiredHeading;
				bearing = desiredHeading;
				if (miningMission.MinesLaidMethod.HasValue)
				{
					int? sequence = miningMission.MinesLaidMethod;
					if (((!sequence.HasValue) ? ((bool?)null) : new bool?(sequence.GetValueOrDefault() == 0)) == true)
					{
						bearing = desiredHeading;
						goto IL_07cc;
					}
				}
				bearing = Math2.NormalizeBearing(desiredHeading + (float)GameGeneral.GlobalRNG.Next(45) - (float)GameGeneral.GlobalRNG.Next(45));
				goto IL_07cc;
			}
			case Weapon._WeaponType.Decoy_Expendable:
			{
				Weapon newWeapon2 = Weapon.GetNewWeapon(ref myUnit.ParentScen, theWeaponRec.int_3, bool_5: false);
				if (newWeapon2.IsChaffBundle)
				{
					ChaffCorridorCloud item = new ChaffCorridorCloud(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentHeading);
					myUnit.ParentScen.ChaffClouds.Add(item);
				}
				theWeaponRec.CurrentLoad -= 1;
				theWeaponRec.ResetTimeToFire();
				NumberOfWeaponsFired = 1;
				list.Add(newWeapon2);
				break;
			}
			case Weapon._WeaponType.ContactBomb_Suicide:
			case Weapon._WeaponType.ContactBomb_Sabotage:
				method_22(theWeaponRec, weapon, theWeaponSalvo, CS$<>8__locals65.$VB$Local_theTarget);
				NumberOfWeaponsFired = 1;
				break;
			default:
				switch (weapon.Type)
				{
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				{
					int num8 = 150;
					if (SpecificNumberOfWeaponsToFire > 0 && num8 > SpecificNumberOfWeaponsToFire)
					{
						num8 = SpecificNumberOfWeaponsToFire;
					}
					if (num8 > theWeaponRec.CurrentLoad)
					{
						num8 = theWeaponRec.CurrentLoad;
					}
					Sensor sensor_3 = null;
					stringBuilder.Append(myUnit.Name).Append(" attacks with unguided weapon(s): ").Append(num8)
						.Append("x ")
						.Append(theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					method_27(ref CS$<>8__locals65.$VB$Local_theTarget, FiringMount, ref sensor_3);
					int num9 = num8;
					for (int num10 = 1; num10 <= num9; num10++)
					{
						if (theWeaponRec.CurrentLoad == 0)
						{
							break;
						}
						UnguidedWeapon unguidedWeapon_2 = new UnguidedWeapon(weapon, CS$<>8__locals65.$VB$Local_theTarget, myUnit, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
						if (num10 == 1)
						{
							switch (CS$<>8__locals65.$VB$Local_theTarget.Type)
							{
							case Contact_Base.ContactType.Air:
							case Contact_Base.ContactType.Missile:
								stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon_2.AirPOK).Append("%. ");
								break;
							case Contact_Base.ContactType.Surface:
								stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon_2.CEP_Surface).Append("m. ");
								break;
							case Contact_Base.ContactType.Submarine:
								stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon_2.SubPOK).Append("%. ");
								break;
							case Contact_Base.ContactType.Facility_Fixed:
							case Contact_Base.ContactType.Facility_Mobile:
							case Contact_Base.ContactType.AggregateGroundUnit:
								stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon_2.CEP_Land).Append("m. ");
								break;
							}
						}
						if (unguidedWeapon_2.Type != Weapon._WeaponType.IronBomb && !myUnit.IsAircraft)
						{
							double num11 = num / weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
							unguidedWeapon_2.CEP_Surface = (int)Math.Round((double)weapon.CEP_Surface * num11);
							unguidedWeapon_2.CEP_Land = (int)Math.Round((double)weapon.CEP_Land * num11);
							if (num10 == 1)
							{
								stringBuilder.Append("Range is ").Append((int)Math.Round(100.0 * num11)).Append("% of maximum, CEP adjusted to same. ");
								myUnit.AddMessage(stringBuilder.ToString(), "CEP adjusted for range", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (num10 == 1)
						{
							method_26(ref FiringMount, unguidedWeapon_2, sensor_3, CS$<>8__locals65.$VB$Local_theTarget, theWeaponSalvo, stringBuilder);
						}
						else
						{
							method_26(ref FiringMount, unguidedWeapon_2, sensor_3, CS$<>8__locals65.$VB$Local_theTarget, theWeaponSalvo, null);
						}
						method_21(myUnit, ref unguidedWeapon_2, stringBuilder);
						float? num12 = (float?)ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon_2.CurrentSpeed);
						if (!num12.HasValue)
						{
							(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, Module_Unit.CurrentSpeed_Horizontal(unguidedWeapon_2), CS$<>8__locals65.$VB$Local_theTarget);
							if (!tuple2.Item1.HasZeroCoords)
							{
								num12 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
							}
						}
						if (!num12.HasValue)
						{
							unguidedWeapon_2.CurrentHeading = myUnit.AI.BearingToUnit_True(CS$<>8__locals65.$VB$Local_theTarget);
						}
						else
						{
							unguidedWeapon_2.CurrentHeading = num12.Value;
						}
						unguidedWeapon_2.set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
						((Module_Unit.Unit)unguidedWeapon_2).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						myUnit.ParentScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon_2.ObjectID, unguidedWeapon_2);
						theWeaponRec.CurrentLoad -= 1;
						NumberOfWeaponsFired++;
						list.Add(unguidedWeapon_2);
						unguidedWeapon_2.FiringParent = myUnit;
						unguidedWeapon_2.FiringParent_ID = myUnit.ObjectID;
						if (sensor_3 != null)
						{
							unguidedWeapon_2.DirectorDBID = sensor_3.DBID;
						}
						switch (CS$<>8__locals65.$VB$Local_theTarget.Type)
						{
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Missile:
							stringBuilder.Append("Final PoH at fire/launch point: ").Append(unguidedWeapon_2.AirPOK).Append("%. ");
							break;
						case Contact_Base.ContactType.Surface:
							stringBuilder.Append("Final CEP at fire/launch point: ").Append(unguidedWeapon_2.CEP_Surface).Append("m. ");
							break;
						case Contact_Base.ContactType.Submarine:
							stringBuilder.Append("Final PoH at fire/launch point: ").Append(unguidedWeapon_2.SubPOK).Append("%. ");
							break;
						case Contact_Base.ContactType.Facility_Fixed:
						case Contact_Base.ContactType.Facility_Mobile:
						case Contact_Base.ContactType.AggregateGroundUnit:
							stringBuilder.Append("Final CEP at fire/launch point: ").Append(unguidedWeapon_2.CEP_Land).Append("m. ");
							break;
						}
						myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon_2.Name + " being fired", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						ExportWeaponFireEvent(CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon_2, theWeaponSalvo);
						method_24(unguidedWeapon_2.ObjectID, FiringMount);
						if (theWeaponSalvo != null)
						{
							string objectID5 = unguidedWeapon_2.ObjectID;
							theWeaponSalvo.WeaponList.TryAdd(objectID5, 0);
						}
					}
					break;
				}
				case Weapon._WeaponType.Microwave:
				{
					UnguidedWeapon unguidedWeapon2 = new UnguidedWeapon(weapon, CS$<>8__locals65.$VB$Local_theTarget, myUnit, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					if (weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) > 0f)
					{
						unguidedWeapon2.CEP_Surface = (int)Math.Round((float)weapon.CEP_Surface_Nominal * num / weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false));
						unguidedWeapon2.CEP_Land = (int)Math.Round((float)weapon.CEP_Land_Nominal * num / weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false));
					}
					Sensor sensor_2 = null;
					stringBuilder.Append(myUnit.Name).Append(" attacks with weapon: ").Append(theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					switch (CS$<>8__locals65.$VB$Local_theTarget.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon2.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon2.CEP_Surface).Append("m. ");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon2.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon2.CEP_Land).Append("m. ");
						break;
					}
					method_27(ref CS$<>8__locals65.$VB$Local_theTarget, FiringMount, ref sensor_2);
					Sensor sensor = unguidedWeapon2.ReferenceWeapon.Sensors_Cached[0];
					if (sensor.MaxIlluminate > 1)
					{
						List<Module_Unit.Unit> list3 = new List<Module_Unit.Unit>();
						foreach (UnguidedWeapon value in myUnit.ParentScen.UnguidedWeapons.Values)
						{
							if (value.FiringParent != myUnit)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in FiringMount.MountWeapons)
							{
								if (Operators.CompareString(mountWeapon.ObjectID, value.FiringWeaponRec_ID, false) == 0)
								{
									list3.Add(value.Target);
								}
							}
						}
						if (list3.Count == 0)
						{
							FiringMount.Boresight = Module_Unit.BearingToUnit_True(myUnit, CS$<>8__locals65.$VB$Local_theTarget);
						}
						else
						{
							list3.Add(CS$<>8__locals65.$VB$Local_theTarget);
							int? num7 = BearingForSensorBoresightToCoverMultipleTargets(sensor, list3);
							if (num7.HasValue)
							{
								FiringMount.Boresight = num7.Value;
							}
						}
					}
					else
					{
						FiringMount.Boresight = Module_Unit.BearingToUnit_True(myUnit, CS$<>8__locals65.$VB$Local_theTarget);
					}
					unguidedWeapon2.set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.ParentScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon2.ObjectID, unguidedWeapon2);
					theWeaponRec.CurrentLoad -= 1;
					NumberOfWeaponsFired = 1;
					list.Add(unguidedWeapon2);
					theWeaponRec.ResetTimeToFire();
					unguidedWeapon2.LaunchPoint = new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					unguidedWeapon2.FiringParent = myUnit;
					unguidedWeapon2.FiringParent_ID = myUnit.ObjectID;
					unguidedWeapon2.FiringWeaponRec_ID = theWeaponRec.ObjectID;
					method_24(unguidedWeapon2.ObjectID, FiringMount);
					if (theWeaponSalvo != null)
					{
						string objectID4 = unguidedWeapon2.ObjectID;
						theWeaponSalvo.WeaponList.TryAdd(objectID4, 0);
					}
					myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon2.Name + " being fired", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ExportWeaponFireEvent(CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon2, theWeaponSalvo);
					CheckForImmediateDefensiveResolution(unguidedWeapon2, CS$<>8__locals65.$VB$Local_theTarget, elapsedTime);
					break;
				}
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.LaserDazzler:
				{
					UnguidedWeapon unguidedWeapon_ = new UnguidedWeapon(weapon, CS$<>8__locals65.$VB$Local_theTarget, myUnit, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					if (weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) > 0f)
					{
						unguidedWeapon_.CEP_Surface = (int)Math.Round((float)weapon.CEP_Surface_Nominal * num / weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false));
						unguidedWeapon_.CEP_Land = (int)Math.Round((float)weapon.CEP_Land_Nominal * num / weapon.get_MaxRangeForThisTarget(myUnit, CS$<>8__locals65.$VB$Local_theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false));
					}
					Sensor sensor_ = null;
					stringBuilder.Append(myUnit.Name).Append(" attacks with weapon: ").Append(theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen).Name)
						.Append(". ");
					switch (CS$<>8__locals65.$VB$Local_theTarget.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon_.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon_.CEP_Surface).Append("m. ");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("Nominal PoH: ").Append(unguidedWeapon_.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						stringBuilder.Append("Nominal CEP: ").Append(unguidedWeapon_.CEP_Land).Append("m. ");
						break;
					}
					method_27(ref CS$<>8__locals65.$VB$Local_theTarget, FiringMount, ref sensor_);
					method_26(ref FiringMount, unguidedWeapon_, sensor_, CS$<>8__locals65.$VB$Local_theTarget, theWeaponSalvo, stringBuilder);
					method_21(myUnit, ref unguidedWeapon_, stringBuilder);
					float? num6 = (float?)ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon_.CurrentSpeed);
					if (!num6.HasValue)
					{
						(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, unguidedWeapon_.CurrentSpeed, CS$<>8__locals65.$VB$Local_theTarget);
						if (!tuple.Item1.HasZeroCoords)
						{
							num6 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
						}
					}
					if (num6.HasValue)
					{
						unguidedWeapon_.CurrentHeading = num6.Value;
					}
					else
					{
						unguidedWeapon_.CurrentHeading = myUnit.AI.BearingToUnit_True(CS$<>8__locals65.$VB$Local_theTarget);
					}
					unguidedWeapon_.set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.ParentScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon_.ObjectID, unguidedWeapon_);
					theWeaponRec.CurrentLoad -= 1;
					NumberOfWeaponsFired++;
					list.Add(unguidedWeapon_);
					theWeaponRec.ResetTimeToFire();
					unguidedWeapon_.LaunchPoint = new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					unguidedWeapon_.FiringParent = myUnit;
					unguidedWeapon_.FiringParent_ID = myUnit.ObjectID;
					unguidedWeapon_.FiringWeaponRec_ID = theWeaponRec.ObjectID;
					if (sensor_ != null)
					{
						unguidedWeapon_.DirectorDBID = sensor_.DBID;
					}
					method_24(unguidedWeapon_.ObjectID, FiringMount);
					if (theWeaponSalvo != null)
					{
						string objectID3 = unguidedWeapon_.ObjectID;
						theWeaponSalvo.WeaponList.TryAdd(objectID3, 0);
					}
					switch (CS$<>8__locals65.$VB$Local_theTarget.Type)
					{
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						stringBuilder.Append("Final PoH at fire/launch point: ").Append(unguidedWeapon_.AirPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Surface:
						stringBuilder.Append("Final CEP at fire/launch point: ").Append(unguidedWeapon_.CEP_Surface).Append("m. ");
						break;
					case Contact_Base.ContactType.Submarine:
						stringBuilder.Append("Final PoH at fire/launch point: ").Append(unguidedWeapon_.SubPOK).Append("%. ");
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						stringBuilder.Append("Final CEP at fire/launch point: ").Append(unguidedWeapon_.CEP_Land).Append("m. ");
						break;
					}
					myUnit.AddMessage(stringBuilder.ToString(), unguidedWeapon_.Name + " being fired", LoggedMessage.MessageType.UnguidedWeaponModifiers, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ExportWeaponFireEvent(CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon_, theWeaponSalvo);
					if (weapon.Type != Weapon._WeaponType.DepthCharge)
					{
						CheckForImmediateDefensiveResolution(unguidedWeapon_, CS$<>8__locals65.$VB$Local_theTarget, elapsedTime);
					}
					break;
				}
				case Weapon._WeaponType.Dispenser:
				{
					Weapon newWeapon = Weapon.GetNewWeapon(ref myUnit.ParentScen, theWeaponRec.int_3, bool_5: false);
					((ActiveUnit)newWeapon).set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
					Warhead[] warheads = newWeapon.Warheads;
					foreach (Warhead warhead in warheads)
					{
						new Explosion(ref myUnit.ParentScen, newWeapon, ref CS$<>8__locals65.$VB$Local_theTarget, ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), weapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, 10f, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads).CurrentHeading = myUnit.CurrentHeading;
					}
					theWeaponRec.CurrentLoad -= 1;
					NumberOfWeaponsFired = 1;
					list.Add(newWeapon);
					theWeaponRec.ResetTimeToFire();
					ExportWeaponFireEvent(CS$<>8__locals65.$VB$Local_theTarget, newWeapon, theWeaponSalvo);
					method_24(newWeapon.ObjectID, FiringMount);
					if (theWeaponSalvo != null)
					{
						string objectID2 = newWeapon.ObjectID;
						theWeaponSalvo.WeaponList.TryAdd(objectID2, 0);
					}
					break;
				}
				}
				break;
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.Decoy_Vehicle:
			case Weapon._WeaponType.GuidedProjectile:
			case Weapon._WeaponType.UAV_Expendable:
			case Weapon._WeaponType.Torpedo:
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.PalletWeapon:
			case Weapon._WeaponType.HGV:
				try
				{
					int num4 = 0;
					while (num4 <= SpecificNumberOfWeaponsToFire && (myUnit.IsPalletWeapon || theWeaponRec.TimeToFire == 0f) && theWeaponRec.CurrentLoad != 0)
					{
						Weapon theWeapon = Weapon.GetNewWeapon(ref myUnit.ParentScen, theWeaponRec.int_3, bool_5: false);
						theWeapon.CEP_Surface = theWeapon.CEP_Surface_Nominal;
						theWeapon.CEP_Land = theWeapon.CEP_Land_Nominal;
						try
						{
							if (theWeaponSalvo != null)
							{
							}
							if (myUnit.IsAircraft)
							{
								theWeapon.FiringParent = (Aircraft)myUnit;
								FireGuidedWeapon(elapsedTime, myUnit, theWeapon, theWeaponRec.int_3, CS$<>8__locals65.$VB$Local_theTarget, FiringMount, myUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, SonobuoyDepthSetting, theWeaponSalvo);
							}
							else
							{
								FireGuidedWeapon(elapsedTime, myUnit, theWeapon, theWeaponRec.int_3, CS$<>8__locals65.$VB$Local_theTarget, FiringMount, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null)), ActiveUnit.Throttle.Cruise, SonobuoyDepthSetting, theWeaponSalvo);
							}
							if (myUnit.IsWeapon)
							{
								theWeapon.FiringParent = ((Weapon)myUnit).FiringParent;
							}
							method_24(theWeapon.ObjectID, FiringMount);
							if (theWeaponSalvo == null)
							{
								if (myUnit.IsWeapon)
								{
									if (CS$<>8__locals65.$VB$Local_theTarget.Type == Contact_Base.ContactType.Aimpoint)
									{
										List<Contact> list2 = new List<Contact>();
										if (myUnit.AI.Targets_ReadOnly.Length > 0)
										{
											list2.AddRange(myUnit.AI.Targets_ReadOnly);
										}
										if (myUnit.AI.PrimaryTarget != null && myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
										{
											list2.Add(myUnit.AI.PrimaryTarget);
										}
										if (list2.Count != 0)
										{
											list2 = list2.OrderBy((CS$<>8__locals65.$I0 != null) ? CS$<>8__locals65.$I0 : (CS$<>8__locals65.$I0 = [SpecialName] (Contact theC) => Geodesic_Haversine.Distance_Horiz_Approx_nm(((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null)))).ToList();
											CS$<>8__locals65.$VB$Local_theTarget = list2[0];
										}
									}
									theWeapon.CreateSalvo_Airborne(ref theWeapon, ref CS$<>8__locals65.$VB$Local_theTarget, myUnit.ParentScen);
								}
							}
							else
							{
								string objectID = theWeapon.ObjectID;
								theWeaponSalvo.WeaponList.TryAdd(objectID, 0);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 100333", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						theWeaponRec.CurrentLoad -= 1;
						theWeaponRec.ResetTimeToFire();
						if (theWeapon.ValidTargets.Radar && !Information.IsNothing((object)weapon.ARM_SpecifiedEMission) && weapon.ARM_SpecifiedEMission.Key != 0)
						{
							theWeapon.ARM_SpecifiedEMission = weapon.ARM_SpecifiedEMission;
							theWeapon.ARM_SpecifiedEmissionIsMandatory = true;
						}
						if (theWeapon.Type == Weapon._WeaponType.RV || theWeapon.Type == Weapon._WeaponType.HGV)
						{
							theWeapon.CEP_Surface = ((Weapon)myUnit).CEP_Surface;
							theWeapon.CEP_Land = ((Weapon)myUnit).CEP_Land;
						}
						NumberOfWeaponsFired++;
						list.Add(theWeapon);
						if (theWeapon.Flags.SearchPattern)
						{
							if (myUnit.IsAircraft && theWeapon.IsTorpedo)
							{
								theWeapon.SearchPatternType = Weapon.WeaponSearchPatternType.Circle;
							}
							else
							{
								theWeapon.SearchPatternType = Weapon.WeaponSearchPatternType.Snake;
							}
						}
						if (theWeapon.UsesGNSSTerminalGuidance())
						{
							if (theWeapon.RecentPNTChecks == null)
							{
								theWeapon.RecentPNTChecks = new FixedSizeQueue<bool>(50);
							}
							theWeapon.RecentPNTChecks.Enqueue(item: true);
						}
						num4++;
						if (theWeapon.IsWeaponPallet)
						{
							myUnit.get_UnitSide(SetSideOnly: false).AllocatePallettizedSalvoToPalletWeapons();
						}
						num4++;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 100332", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case Weapon._WeaponType.Aircraft:
				{
					Scenario parentScen = myUnit.ParentScen;
					Aircraft aircraft = parentScen.AddNewAircraft(myUnit.get_UnitSide(SetSideOnly: false), weapon.Name + " #" + Conversions.ToString(Interlocked.Increment(ref parentScen.UnitsAutoIncrement)), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), (int)Math.Round(weapon.Warheads[0].DP), 0, Math.Max(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 1f));
					if (CS$<>8__locals65.$VB$Local_theTarget != null)
					{
						aircraft.Navigator.AddWaypoint(new Waypoint(((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
					theWeaponRec.CurrentLoad -= 1;
					theWeaponRec.ResetTimeToFire();
					list.Add(weapon);
					NumberOfWeaponsFired = 1;
					break;
				}
				IL_01b1:
				unguidedWeapon = new UnguidedWeapon(weapon, null, null, 0.0, 0.0, num2);
				unguidedWeapon.set_UnitSide(SetSideOnly: false, myUnit.get_UnitSide(SetSideOnly: false));
				myUnit.ParentScen.UnguidedWeapons.AddOrUpdate(unguidedWeapon.ObjectID, unguidedWeapon);
				theWeaponRec.CurrentLoad -= 1;
				theWeaponRec.ResetTimeToFire();
				NumberOfWeaponsFired = 1;
				list.Add(unguidedWeapon);
				Weapon.GetNewWeapon(ref myUnit.ParentScen, theWeaponRec.int_3, bool_5: false);
				unguidedWeapon.FiringParent = myUnit;
				unguidedWeapon.FiringParent_ID = myUnit.ObjectID;
				unguidedWeapon.Target = CS$<>8__locals65.$VB$Local_theTarget;
				unguidedWeapon.TimeToDetonate = num2;
				((Module_Unit.Unit)unguidedWeapon).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)unguidedWeapon).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)CS$<>8__locals65.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
				ExportWeaponFireEvent(CS$<>8__locals65.$VB$Local_theTarget, unguidedWeapon, theWeaponSalvo);
				break;
				IL_07cc:
				lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				out_lon = (geoPoint = geoPoint2).Longitude;
				out_lat = (geoPoint3 = geoPoint2).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, 0.9, bearing);
				geoPoint3.Latitude = out_lat;
				geoPoint.Longitude = out_lon;
				if (myUnit.AI.MiningInfo != null)
				{
					int? sequence = myUnit.AI.MiningInfo.Sequence;
					if (((!sequence.HasValue) ? ((bool?)null) : new bool?(sequence.GetValueOrDefault() < 1)) != true)
					{
						waypoint.Longitude = geoPoint2.Longitude;
						waypoint.Latitude = geoPoint2.Latitude;
						waypoint.Type = Waypoint.WaypointType.PatrolStation;
						waypoint.Creator = Waypoint.WaypointCreator.Navigator;
						waypoint.Category = Waypoint.WaypointCategory.PlottedCourse;
						waypoint.Name = "Mining Mission Drop point";
						myUnit.Navigator.AddWaypoint(waypoint);
						if (waypoint2 != null && myUnit.AI.MiningInfo.Sequence.HasValue)
						{
							waypoint2.Name = "Mining Mission Staion";
							myUnit.Navigator.AddWaypoint(waypoint2);
						}
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geoPoint2.Latitude, geoPoint2.Longitude)));
					}
					else
					{
						myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
						myUnit.Navigator.PreviousWaypointTime = null;
						myUnit.Navigator.PreviousWaypointLatitude = null;
						myUnit.Navigator.PreviousWaypointLongitude = null;
						myUnit.Navigator.PreviousWaypointType = null;
						myUnit.Navigator.PlotCourseToArea(miningMission.Area);
					}
				}
				else
				{
					myUnit.Navigator.AddWaypoint(geoPoint2.Latitude, geoPoint2.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geoPoint2.Latitude, geoPoint2.Longitude)));
				}
				break;
			}
			if (myUnit.IsAircraft && weapon.EmptyWeight > 0 && ((Aircraft)myUnit).Loadout.PayloadWeight > 0)
			{
				AdjustLoadoutPayloadWeight();
			}
			StringBuilderCache.Free(stringBuilder);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100331", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
			for (int num13 = 0; num13 < sides_ReadOnly.Length; num13 = checked(num13 + 1))
			{
				sides_ReadOnly[num13].HandleUnitHasFiredWeapon(myUnit, CS$<>8__locals65.$VB$Local_theTarget, theWeaponRec);
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100330", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (list.Count > 0)
			{
				myUnit.get_UnitSide(SetSideOnly: false).AAR.AddToExpenditures(theWeaponRec.int_3, list.Count);
				firedWeaponEventHandler_0?.Invoke(myUnit.ParentScen, myUnit, weapon);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 100328", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	internal List<Module_Unit.Unit> FireWeapon_PointDefenceMode(ref WeaponRec theWeaponRec, Contact theTarget, ref List<string> PointDefenceMessages, ref int NumberOfWeaponsFired, HashSet<int> DBIDsOfDecoysAlreadyTried)
	{
		if (theTarget != null)
		{
			myUnit.RangeToUnit_Horiz(theTarget);
		}
		Weapon weapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		new StringBuilder();
		try
		{
			Weapon._WeaponType type = weapon.Type;
			bool flag;
			if ((uint)(type - 2005) <= 1u)
			{
				if (DBIDsOfDecoysAlreadyTried.Contains(weapon.DBID))
				{
					flag = false;
				}
				else
				{
					Weapon AttackingWeapon = (Weapon)theTarget.ActualUnit;
					flag = weapon.ResolveDecoyAttempt(ref AttackingWeapon, ref myUnit, ref PointDefenceMessages);
					DBIDsOfDecoysAlreadyTried.Add(weapon.DBID);
				}
			}
			else
			{
				new UnguidedWeapon(weapon, theTarget, myUnit, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				flag = weapon.ResolveImpact(theTarget.ActualUnit, myUnit.ParentScen, IsPointDefenceMode: true, ref PointDefenceMessages);
			}
			if (weapon.Type == Weapon._WeaponType.Decoy_Towed)
			{
				if (flag && GameGeneral.GlobalRNG.Next(0, 101) > 50)
				{
					theWeaponRec.CurrentLoad -= 1;
					NumberOfWeaponsFired = 1;
					list.Add(weapon);
				}
			}
			else
			{
				theWeaponRec.CurrentLoad -= 1;
				theWeaponRec.ResetTimeToFire();
				NumberOfWeaponsFired = 1;
				list.Add(weapon);
			}
			if (myUnit.IsAircraft && weapon.EmptyWeight > 0 && ((Aircraft)myUnit).Loadout.PayloadWeight > 0)
			{
				AdjustLoadoutPayloadWeight();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1003245023495023495", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitHasFiredWeapon(myUnit, theTarget, theWeaponRec);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 1023450923845902386524598", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (list.Count > 0)
			{
				myUnit.get_UnitSide(SetSideOnly: false).AAR.AddToExpenditures(theWeaponRec.int_3, list.Count);
				firedWeaponEventHandler_0?.Invoke(myUnit.ParentScen, myUnit, weapon);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 10354329054823906834905634", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public void CheckForImmediateDefensiveResolution(UnguidedWeapon theWeapon, Contact theTarget, float elapsedTime)
	{
		if (theTarget.ActualUnit != null && theTarget.ActualUnit.IsWeapon && theTarget.ActualUnit.AI.PrimaryTarget != null && theTarget.ActualUnit.AI.PrimaryTarget.ActualUnit == myUnit && ((Weapon)theTarget.ActualUnit).ImpactsOnThisPulse_ActualUnit && theWeapon.WillImpactTargetThisPulse(elapsedTime))
		{
			ref Scenario parentScen = ref myUnit.ParentScen;
			LockRandom theRNG = GameGeneral.GlobalRNG;
			theWeapon.ResolveImpactResults(ref parentScen, elapsedTime, ref theRNG);
		}
	}

	public void AdjustLoadoutPayloadWeight()
	{
		try
		{
			if (!Information.IsNothing((object)((Aircraft)myUnit).Loadout))
			{
				Loadout theLoadout = ((Aircraft)myUnit).Loadout;
				DBFunctions.GetLoadoutPayloadTakeOffWeight_Current(ref myUnit.ParentScen, ref theLoadout);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100334", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_25(Weapon weapon_6, Contact contact_0)
	{
		try
		{
			if (contact_0 != null)
			{
				if (weapon_6.IsMobileDecoy && weapon_6.Warheads.Count() == 0 && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
				{
					double lat = ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null);
					double lon = ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null);
					if (contact_0.UncertaintyArea != null)
					{
						Geopoint_Struct geopoint_Struct = Misc.Center(contact_0.UncertaintyArea);
						double latitude = geopoint_Struct.Latitude;
						double longitude = geopoint_Struct.Longitude;
						bool CheckNoNavZones = true;
						bool CheckForMines = false;
						List<ActiveUnit> ProvidedPiers = null;
						string UserFeedback = "";
						bool AllowBounce = false;
						int MovementCost = default(int);
						if (weapon_6.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: false, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
						{
							lat = geopoint_Struct.Latitude;
							lon = geopoint_Struct.Longitude;
						}
						else
						{
							Weapon_Navigator navigator = weapon_6.Navigator;
							double startLat = weapon_6.get_Latitude((GlobalVariables.BooleanObject)null);
							double startLon = weapon_6.get_Longitude((GlobalVariables.BooleanObject)null);
							double latitude2 = geopoint_Struct.Latitude;
							double longitude2 = geopoint_Struct.Longitude;
							ProvidedPiers = null;
							GeoPoint geoPoint = navigator.LastAccessiblePointOnPath(startLat, startLon, latitude2, longitude2, 0f, null, 0f, ref ProvidedPiers);
							if (geoPoint != null)
							{
								lat = geoPoint.Latitude;
								lon = geoPoint.Longitude;
							}
						}
					}
					weapon_6.AI.PrimaryTarget = new ActivationPointContact(lat, lon);
					weapon_6.AI.PrimaryTarget_Type = Contact_Base.ContactType.ActivationPoint;
				}
				else if (contact_0.Type == Contact_Base.ContactType.ActivationPoint && weapon_6.Flags.LoiterCapability)
				{
					float num = Math.Min(weapon_6.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), weapon_6.Kinematics.GetMaximumAltitude());
					if (weapon_6.CruiseAltitude_ASL > num)
					{
						num = weapon_6.CruiseAltitude_ASL;
					}
					else if (weapon_6.CruiseAltitude_AGL > 0f)
					{
						num = Math.Max(num, weapon_6.CruiseAltitude_AGL + (float)Terrain.GetElevation(((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
					}
					weapon_6.AI.PrimaryTarget = new ActivationPointContact(((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null));
					((Module_Unit.Unit)weapon_6.AI.PrimaryTarget).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, num);
				}
			}
			if (weapon_6.isUAV)
			{
				weapon_6.DesiredAltitude = weapon_6.Kinematics.GetMaximumAltitude();
			}
			if (contact_0 != null && weapon_6.IsMissile && (contact_0.Type == Contact_Base.ContactType.Submarine || contact_0.Type == Contact_Base.ContactType.Submarine || contact_0.Type == Contact_Base.ContactType.ActivationPoint || weapon_6.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint) && weapon_6.HasTorpedoPayload)
			{
				if (weapon_6.WeaponSensors().Count > 0)
				{
					weapon_6.ClearAllSensors();
					weapon_6.DetermineGuidance();
				}
				if (weapon_6.Comms_ReadOnly.Length > 0)
				{
					weapon_6.ClearAllComms();
					weapon_6.DetermineGuidance();
				}
			}
			if (contact_0 == null || contact_0.ActualUnit == null || !weapon_6.IsMissile || contact_0.Type != Contact_Base.ContactType.Facility_Fixed || weapon_6.WeaponSensors().Count <= 0)
			{
				return;
			}
			bool flag = false;
			foreach (Sensor item in weapon_6.WeaponSensors())
			{
				if (item.get_IsSuitableForThisTarget(contact_0.ActualUnit))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				weapon_6.WeaponSensors().Clear();
				weapon_6.DetermineGuidance();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100335", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void FireGuidedWeapon(float elapsedTime, ActiveUnit FiringUnit, Weapon theWeapon, int WeaponID, Contact theTarget, Mount FiringMount, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Cruise, SonarModel.PositionRelativeToThermocline SonobuoyDepthSetting = SonarModel.PositionRelativeToThermocline.Above, WeaponSalvo ParentSalvo = null)
	{
		try
		{
			theWeapon.FiringParent = FiringUnit;
			if (!FiringUnit.Weaponry.bool_3 && NeedToCheckDLZ(theWeapon, theTarget))
			{
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, FiringUnit.ParentScen, myUnit.IsAircraft || myUnit.IsMissile, myUnit.CurrentSpeed);
			}
			theWeapon.Name = theWeapon.Name + " #" + Conversions.ToString(Interlocked.Increment(ref FiringUnit.ParentScen.UnitsAutoIncrement));
			((ActiveUnit)theWeapon).set_UnitSide(SetSideOnly: false, FiringUnit.get_UnitSide(SetSideOnly: false));
			theWeapon.AI.PrimaryTarget = theTarget;
			if (theTarget != null)
			{
				theWeapon.AI.PrimaryTarget_Type = theTarget.Type;
			}
			if (FiringUnit.CurrentSpeed > 0f && !theWeapon.IsReEntryVehicle)
			{
				theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)FiringUnit).get_Longitude_next(elapsedTime));
				theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)FiringUnit).get_Latitude_next(elapsedTime));
			}
			else
			{
				theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, FiringUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, FiringUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			}
			if (!theWeapon.IsMissile)
			{
				theWeapon.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			else
			{
				theWeapon.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, Math.Max(0f, FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				if (theWeapon.FiringParent.IsFacility || theWeapon.FiringParent.IsVehicle)
				{
					theWeapon.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null) += 2f;
				}
			}
			if (theWeapon.IsWeaponPallet)
			{
				theWeapon.DesiredPitch = -85f;
				theWeapon.Attitude_Pitch = FiringUnit.Attitude_Pitch;
				theWeapon.CurrentSpeed = FiringUnit.CurrentSpeed;
				theWeapon.ThrottleSetting = ActiveUnit.Throttle.Cruise;
				theWeapon.CurrentHeading = FiringUnit.CurrentHeading;
				theWeapon.DesiredAltitude = 0f;
				theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			if (theWeapon.IsTorpedo)
			{
				try
				{
					if (theWeapon.MaxPossibleThrottleSetting >= ActiveUnit.Throttle.Full)
					{
						Scenario parentScen = myUnit.ParentScen;
						int dBID = theWeapon.DBID;
						ActiveUnit firingUnit = myUnit;
						double launchLongitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						double launchLatitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						float launchAltitude = (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						int launchSpeed = (int)Math.Round(myUnit.CurrentSpeed);
						double targetLongitude = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
						double targetLatitude = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
						float currentHeading = theTarget.CurrentHeading;
						bool headingIsKnown = theTarget.HeadingIsKnown;
						int targetSpeed = (int)Math.Round(Module_Unit.CurrentSpeed_Horizontal(theTarget));
						bool speedIsKnown = theTarget.SpeedIsKnown;
						float targetAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						bool altitudeIsKnown = theTarget.AltitudeIsKnown;
						float targetVerticalSpeed_mpersec = Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen);
						Contact_Base.ContactType type = theTarget.Type;
						GeoPoint InterceptPoint = null;
						string FeedbackText = null;
						float currentHeading2 = myUnit.CurrentHeading;
						int customWeaponFuel = (int)Math.Round((double)(float)theWeapon.Fuel_ReadOnly[0].MaxQuantity * 0.8999999985098839);
						float FlightTime = 0f;
						if (TargetIsWithinDLZ(parentScen, dBID, firingUnit, AssumeVerticalLaunch: false, launchLongitude, launchLatitude, launchAltitude, launchSpeed, targetLongitude, targetLatitude, currentHeading, headingIsKnown, targetSpeed, speedIsKnown, targetAltitude, altitudeIsKnown, targetVerticalSpeed_mpersec, type, ref InterceptPoint, TargetIsTerminalDiving: false, ref FeedbackText, HumanFeedBackNeeded: false, currentHeading2, ActiveUnit.Throttle.Full, null, customWeaponFuel, null, ref FlightTime).DLZREsult == DLZResultEnum.Success)
						{
							ThrottleSetting = ActiveUnit.Throttle.Full;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 98365476866", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			theWeapon.SetThrottle(ThrottleSetting);
			float currentSpeed = theWeapon.Kinematics.GetMaximumSpeed(theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
			if (theWeapon.IsTorpedo)
			{
				theWeapon.CurrentSpeed = currentSpeed;
			}
			else if (theWeapon.Type == Weapon._WeaponType.GuidedProjectile)
			{
				theWeapon.CurrentSpeed = currentSpeed;
			}
			else if (theWeapon.IsReEntryVehicle)
			{
				theWeapon.CurrentSpeed = FiringUnit.CurrentSpeed;
			}
			else
			{
				theWeapon.CurrentSpeed = FiringUnit.CurrentSpeed + theWeapon.Kinematics.Acceleration_Actual(theWeapon.ThrottleSetting, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed);
			}
			if (theWeapon.Type == Weapon._WeaponType.Sonobuoy)
			{
				theWeapon.CurrentSpeed = 0f;
			}
			theWeapon.DesiredSpeed = theWeapon.CurrentSpeed;
			try
			{
				method_25(theWeapon, theTarget);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 9836547683335", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (theWeapon.IsHGV && FiringUnit.IsMissile)
			{
				ActiveUnit_Navigator navigator = FiringUnit.Navigator;
				if (navigator != null && navigator.HasPlottedCourse())
				{
					theWeapon.Navigator.PlottedCourse = FiringUnit.Navigator.PlottedCourse;
					Waypoint waypoint = theWeapon.Navigator.PlottedCourse[0];
					InitialHeading = Module_Unit.BearingToPoint_True(FiringUnit, waypoint.Latitude, waypoint.Longitude);
				}
			}
			if (InitialHeading == 0f)
			{
				if (FiringUnit.IsAircraft)
				{
					theWeapon.CurrentHeading = FiringUnit.CurrentHeading;
				}
				else if (!FiringUnit.IsSubmarine)
				{
					theWeapon.CurrentHeading = Math2.CalcAzimuth(FiringUnit.get_Latitude((GlobalVariables.BooleanObject)null), FiringUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				}
				else if (theWeapon.IsAAWCapable)
				{
					theWeapon.CurrentHeading = Math2.CalcAzimuth(FiringUnit.get_Latitude((GlobalVariables.BooleanObject)null), FiringUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				}
				else
				{
					theWeapon.CurrentHeading = FiringUnit.CurrentHeading;
				}
			}
			else
			{
				theWeapon.CurrentHeading = InitialHeading;
			}
			if (((ActiveUnit)theWeapon).DesiredHeading == 0f)
			{
				((ActiveUnit)theWeapon).set_DesiredHeading(ActiveUnit.TurnRate.Max, theWeapon.CurrentHeading);
			}
			try
			{
				if (theWeapon.IsGuidedProjectile && !FiringUnit.IsAircraft)
				{
					double? num = ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, theWeapon.AI.PrimaryTarget, theWeapon.CurrentSpeed);
					if (!num.HasValue)
					{
						(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, theWeapon.CurrentSpeed, theTarget);
						if (!tuple.Item1.HasZeroCoords)
						{
							num = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
						}
					}
					if (num.HasValue)
					{
						theWeapon.CurrentHeading = (float)num.Value;
						((ActiveUnit)theWeapon).set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num.Value);
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 983654768633321115", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (theWeapon.AI.PrimaryTarget != null && theWeapon.Comms_ReadOnly.Count() == 0 && theWeapon.AI.PrimaryTarget.IsLandContact && theWeapon.Flags.Navigation_INS_GPS && !theWeapon.ValidTargets.Radar && theWeapon.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && theWeapon.ValidTargets.SurfaceVessel)
			{
				foreach (Sensor item in theWeapon.WeaponSensors())
				{
					if (item.Type == Sensor.Sensor_Type.Radar)
					{
						theWeapon.GoDumb(ComputeTerminalPoint: false);
						break;
					}
				}
			}
			if (theTarget != null)
			{
				if (theWeapon.SupportsWaypoints && FiringUnit.IsAircraft && ((FiringUnit.Navigator.IsOnAutoPlannerPlottedCourse && !Information.IsNothing((object)FiringUnit.Navigator.PlottedCourse[0].Time_Zulu)) || (FiringUnit.IsGroupMember() && !Information.IsNothing((object)FiringUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && FiringUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse && !Information.IsNothing((object)FiringUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Time_Zulu))))
				{
					if (theWeapon.AI.PrimaryTarget != null)
					{
						theWeapon.Navigator.AddWaypoint(new Waypoint(((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
				}
				else if (ParentSalvo != null && ParentSalvo.PlottedCourse != null)
				{
					if (ParentSalvo.PlottedCourse.Count() > 0)
					{
						float num2 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ParentSalvo.PlottedCourse.First().Latitude, ParentSalvo.PlottedCourse.First().Longitude);
						int num3 = ParentSalvo.PlottedCourse.Count() - 2;
						for (int i = 0; i <= num3; i++)
						{
							num2 += Math2.CalcDist(ParentSalvo.PlottedCourse[i].Latitude, ParentSalvo.PlottedCourse[i].Longitude, ParentSalvo.PlottedCourse[i + 1].Latitude, ParentSalvo.PlottedCourse[i + 1].Longitude);
						}
						num2 += Math2.CalcDist(ParentSalvo.PlottedCourse.Last().Latitude, ParentSalvo.PlottedCourse.Last().Longitude, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
						if (theWeapon.get_MaxRangeForThisTarget(FiringUnit, theTarget, CheckWRA: false, FiringUnit.Doctrine, ManualFire: false) < num2)
						{
							theWeapon.Navigator.PlanComplexCourse(FiringUnit);
						}
						else
						{
							Waypoint[] plottedCourse = ParentSalvo.PlottedCourse;
							foreach (Waypoint waypoint2 in plottedCourse)
							{
								theWeapon.Navigator.AddWaypoint(new Waypoint(waypoint2.Longitude, waypoint2.Latitude, 0f, waypoint2.Type, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse));
							}
						}
					}
					else if (theWeapon.SupportsWaypoints)
					{
						Weapon_Navigator navigator2 = theWeapon.Navigator;
						if (navigator2 != null && !navigator2.HasPlottedCourse())
						{
							theWeapon.Navigator.PlanComplexCourse(FiringUnit);
							ArrayExtensions.Clear(ref ParentSalvo.PlottedCourse);
							Waypoint[] plottedCourse2 = theWeapon.Navigator.PlottedCourse;
							foreach (Waypoint waypoint3 in plottedCourse2)
							{
								ArrayExtensions.Add(ref ParentSalvo.PlottedCourse, new Waypoint(waypoint3.Longitude, waypoint3.Latitude, 0f, waypoint3.Type, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse));
							}
						}
					}
				}
			}
			float weaponNominalSpeed = default(float);
			if (theTarget != null && (theWeapon.Is_LOAL_capable || theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial || (theWeapon.HasTorpedoPayload && (theWeapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || theWeapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || theWeapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))))
			{
				float num4 = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				float minimumAltitude = theWeapon.Kinematics.GetMinimumAltitude();
				float maximumAltitude = theWeapon.Kinematics.GetMaximumAltitude();
				if (num4 > maximumAltitude)
				{
					num4 = maximumAltitude;
				}
				if (num4 < minimumAltitude)
				{
					num4 = minimumAltitude;
				}
				if (!theWeapon.IsBallisticMissile)
				{
					weaponNominalSpeed = ((theWeapon.CruiseAltitude_AGL != 0f) ? ((float)theWeapon.Kinematics.GetMaximumSpeed(theWeapon.CruiseAltitude_AGL, ThrottleSetting, ValidateAndFixAltitude: false)) : ((theWeapon.CruiseAltitude_ASL == 0f) ? ((float)theWeapon.Kinematics.GetMaximumSpeed(num4, ThrottleSetting, ValidateAndFixAltitude: false)) : ((float)theWeapon.Kinematics.GetMaximumSpeed(theWeapon.CruiseAltitude_ASL, ThrottleSetting, ValidateAndFixAltitude: false))));
					theWeapon.Navigator.ComputeTerminalPoint(weaponNominalSpeed, FiringUnit.IsAircraft && theWeapon.IsTorpedo);
				}
				else
				{
					method_31(theWeapon);
				}
				if (ParentSalvo != null && ParentSalvo.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
				{
					if (theWeapon.CruiseAltitude_AGL > 0f)
					{
						theWeapon.Navigator.PlottedCourse[0].Altitude = theWeapon.CruiseAltitude_AGL;
					}
					else if (theWeapon.CruiseAltitude_ASL > 0f)
					{
						theWeapon.Navigator.PlottedCourse[0].Altitude = theWeapon.CruiseAltitude_ASL;
					}
					else
					{
						theWeapon.Navigator.PlottedCourse[0].Altitude = theWeapon.Kinematics.GetMaximumAltitude();
					}
				}
				if (theWeapon.IsReEntryVehicle && !theWeapon.HasTerminalGuidance && FiringUnit.Navigator.HasPlottedCourse() && theWeapon.Navigator.HasPlottedCourse())
				{
					theWeapon.Navigator.PlottedCourse.Last().Altitude = Math.Min(FiringUnit.Navigator.PlottedCourse.Last().Altitude, FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
				if (theWeapon.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					((ActiveUnit)theWeapon).set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), theWeapon.Navigator.PlottedCourse[0].Latitude, theWeapon.Navigator.PlottedCourse[0].Longitude));
				}
			}
			if (theWeapon.Type == Weapon._WeaponType.Sonobuoy)
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), theWeapon.ParentScen);
				if (SonobuoyDepthSetting != SonarModel.PositionRelativeToThermocline.Above)
				{
					if (thermalLayerAtThisLocation.Strength > 0f)
					{
						theWeapon.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, (float)(thermalLayerAtThisLocation.Floor - 20));
					}
					else
					{
						theWeapon.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, (float)Math.Min(-40.0, Math.Max(-300.0, (double)((Module_Unit.Unit)theWeapon).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) / 2.0)));
					}
					theWeapon._TimeToDetonate = 240f;
				}
				else
				{
					theWeapon.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, -40f);
					theWeapon._TimeToDetonate = 120f;
				}
				theWeapon.DesiredAltitude = theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			if (theWeapon.Guidance == Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active)
			{
				theWeapon.DataLinkParent = FiringUnit;
			}
			Warhead[] warheads = theWeapon.Warheads;
			foreach (Warhead warhead in warheads)
			{
				if ((warhead.Type == Warhead.WarheadType.Weapon) & !theWeapon.IsWeaponPallet)
				{
					warhead.get_CarriedWeapon(theWeapon.ParentScen).AI.PrimaryTarget = theWeapon.AI.PrimaryTarget;
					warhead.get_CarriedWeapon(theWeapon.ParentScen).AI.PrimaryTarget_Type = theWeapon.AI.PrimaryTarget.Type;
				}
			}
			if (FiringUnit.IsAircraft && theWeapon.IsTorpedo)
			{
				foreach (Sensor item2 in theWeapon.WeaponSensors())
				{
					if (item2.CanBeActive)
					{
						item2.GoActive();
					}
				}
			}
			if (theWeapon.IsMIRVedMissile.Value)
			{
				theWeapon.Warheads[0].get_CarriedWeapon(FiringUnit.ParentScen).AI.PrimaryTarget = theWeapon.AI.PrimaryTarget;
				theWeapon.Warheads[0].get_CarriedWeapon(FiringUnit.ParentScen).AI.PrimaryTarget_Type = theWeapon.AI.PrimaryTarget.Type;
				((BallisticMissile_AI)theWeapon.AI).method_19();
			}
			if ((theWeapon.Warheads.Any() & !theWeapon.IsWeaponPallet) && theWeapon.Warheads[0].Type == Warhead.WarheadType.EMP_Directed)
			{
				Contact[] targets_ReadOnly = FiringUnit.AI.Targets_ReadOnly;
				foreach (Contact contact in targets_ReadOnly)
				{
					if (contact != theTarget && FiringUnit.AI.IsClearedToEngageThisTarget(theTarget))
					{
						theWeapon.AI.TargetThisContact(contact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			theWeapon.Kinematics.SetActualLoftAltitude(FiringUnit, theTarget);
			if (theWeapon.CruiseAltitude_ASL > 0f && theWeapon.UsesBoostCoastModel.Value)
			{
				theWeapon.Navigator.RefineTerminalPoint_BoostCoast(weaponNominalSpeed, FiringUnit.IsAircraft && theWeapon.IsTorpedo);
			}
			if (theWeapon.IsBallisticMissile && theWeapon.Warheads.Any() && theWeapon.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				Weapon weapon = theWeapon.Warheads[0].get_CarriedWeapon(myUnit.ParentScen);
				if (theWeapon.CruiseAltitude_ASL > 0f)
				{
					float maximumAltitude2 = weapon.Kinematics.GetMaximumAltitude();
					if (theWeapon.CruiseAltitude_ASL > maximumAltitude2)
					{
						theWeapon.CruiseAltitude_ASL = maximumAltitude2 - 10f;
					}
				}
			}
			if (theWeapon.SupportsAttitude_Pitch)
			{
				if (myUnit.IsAircraft && !((Aircraft)myUnit).IsHelicopter)
				{
					theWeapon.Attitude_Pitch = myUnit.Attitude_Pitch;
				}
				else if (!theWeapon.IsHGV)
				{
					if (!theWeapon.IsASuW_Land && !theWeapon.IsASuW_Naval)
					{
						if (theWeapon.IsABMOptimized() || (FiringMount != null && FiringMount.IsVLS) || (theWeapon.IsAAW_GuidedMissile && (myUnit.IsFacility || myUnit.IsMobileGroundUnit)))
						{
							theWeapon.Attitude_Pitch = 90f;
						}
					}
					else if (FiringMount != null)
					{
						if (!theWeapon.IsBallisticMissile)
						{
							if (!FiringMount.IsVLS)
							{
								if (FiringMount.IsRail && theTarget.AltitudeIsKnown)
								{
									float num5 = (float)((double)Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0);
									theWeapon.Attitude_Pitch = (int)Math.Round(Math2.Arctand(num5 / ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
									if (theWeapon.Attitude_Pitch < 0f)
									{
										theWeapon.Attitude_Pitch = 0f;
									}
								}
								else
								{
									theWeapon.Attitude_Pitch = 45f;
								}
							}
							else
							{
								theWeapon.Attitude_Pitch = 90f;
							}
						}
						else
						{
							theWeapon.Attitude_Pitch = 90f;
						}
					}
				}
				else
				{
					theWeapon.Attitude_Pitch = FiringUnit.Attitude_Pitch;
				}
				if (theWeapon.Type == Weapon._WeaponType.RV)
				{
					theWeapon.Attitude_Pitch = 0f - (float)Geodesic_Vincenty.ApproxGrazingAngle(myUnit.RangeToUnit_Horiz(theTarget), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
			}
			method_28(ref FiringUnit, ref theWeapon, ref theTarget);
			smethod_0(FiringUnit, theWeapon, theTarget);
			theWeapon.LaunchPoint = new GeoPoint(theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			theWeapon.LaunchSpeed = FiringUnit.CurrentSpeed;
			theWeapon.Altitude_old = myUnit.Altitude_old;
			FiringUnit.ParentScen.AddThisUnit(theWeapon);
			if (theTarget != null)
			{
				if (myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactIncomingWeapons.ContainsKey(theTarget.ObjectID))
				{
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactIncomingWeapons[theTarget.ObjectID]++;
				}
				else
				{
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactIncomingWeapons.AddIfNotExistsElseUpdate(theTarget.ObjectID, 1);
				}
			}
			ExportWeaponFireEvent(theTarget, theWeapon, ParentSalvo);
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100336", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ExportWeaponFireEvent(Contact theTarget, Module_Unit.Unit theWeapon, WeaponSalvo theSalvo)
	{
		if (theTarget != null)
		{
			IEventExporter[] applicableEventExporters = myUnit.ParentScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportWeaponFired)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (myUnit.ParentScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string)));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("FiringUnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string), 40));
				pooledDictionary.Add("FiringUnitDBID", new IEventExporter.EventNotificationParameter(myUnit.DBID, typeof(string), 10));
				pooledDictionary.Add("FiringUnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string), 500));
				pooledDictionary.Add("FiringUnitType", new IEventExporter.EventNotificationParameter(myUnit.UnitType_String, typeof(string), 20));
				pooledDictionary.Add("FiringUnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string), 500));
				pooledDictionary.Add("FiringUnitSide", new IEventExporter.EventNotificationParameter(myUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				pooledDictionary.Add("FiringUnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("FiringUnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("FiringUnitCourse", new IEventExporter.EventNotificationParameter(myUnit.CurrentHeading, typeof(double)));
				pooledDictionary.Add("FiringUnitSpeed_kts", new IEventExporter.EventNotificationParameter(myUnit.CurrentSpeed, typeof(float)));
				pooledDictionary.Add("FiringUnitAltitude_m", new IEventExporter.EventNotificationParameter(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
				pooledDictionary.Add("FiringUnitAGL_m", new IEventExporter.EventNotificationParameter(myUnit.CurrentAltitude_AGL, typeof(float)));
				pooledDictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(theWeapon.ObjectID, typeof(string), 40));
				pooledDictionary.Add("WeaponDBID", new IEventExporter.EventNotificationParameter((!theWeapon.IsActiveUnit) ? ((UnguidedWeapon)theWeapon).ReferenceWeapon.DBID : ((ActiveUnit)theWeapon).DBID, typeof(string), 10));
				string theValue = (theWeapon.IsActiveUnit ? Misc.ToEnglishString(((Weapon)theWeapon).Type) : Misc.ToEnglishString(((UnguidedWeapon)theWeapon).ReferenceWeapon.Type));
				pooledDictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(theWeapon.Name, typeof(string), 500));
				pooledDictionary.Add("WeaponType", new IEventExporter.EventNotificationParameter(theValue, typeof(string), 200));
				pooledDictionary.Add("WeaponClass", new IEventExporter.EventNotificationParameter(theWeapon.UnitClass, typeof(string), 500));
				pooledDictionary.Add("TargetContactID", new IEventExporter.EventNotificationParameter(theTarget.ObjectID, typeof(string), 40));
				pooledDictionary.Add("TargetContactLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetContactLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetContactHeading", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(theTarget.HeadingIsKnown, (object)theTarget.CurrentHeading, (object)"")), typeof(float)));
				pooledDictionary.Add("TargetContactSpeed", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(theTarget.SpeedIsKnown, (object)theTarget.CurrentSpeed, (object)"")), typeof(float)));
				pooledDictionary.Add("TargetContactAltitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(theTarget.AltitudeIsKnown, (object)((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null).ToString(), (object)"")), typeof(float)));
				pooledDictionary.Add("TargetContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(myUnit.RangeToUnit_Horiz(theTarget), typeof(float)));
				pooledDictionary.Add("TargetContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(myUnit, theTarget), typeof(float)));
				if (theTarget.ActualUnit != null)
				{
					pooledDictionary.Add("TargetContactActualUnitID", new IEventExporter.EventNotificationParameter(theTarget.ActualUnit.ObjectID, typeof(string), 40));
					pooledDictionary.Add("TargetContactActualUnitName", new IEventExporter.EventNotificationParameter(theTarget.ActualUnit.Name, typeof(string), 500));
					pooledDictionary.Add("TargetContactActualUnitClass", new IEventExporter.EventNotificationParameter(theTarget.ActualUnit.UnitClass, typeof(string), 500));
					pooledDictionary.Add("TargetContactActualUnitSide", new IEventExporter.EventNotificationParameter(theTarget.ActualUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				}
				else
				{
					pooledDictionary.Add("TargetContactActualUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					pooledDictionary.Add("TargetContactActualUnitName", new IEventExporter.EventNotificationParameter(theTarget.Name, typeof(string), 500));
					pooledDictionary.Add("TargetContactActualUnitClass", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					pooledDictionary.Add("TargetContactActualUnitSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				pooledDictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter((theSalvo != null) ? theSalvo.ObjectID : string.Empty, typeof(string)));
				string theValue2 = string.Empty;
				if (theTarget.IsWeaponContact)
				{
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					List<WeaponRec> list = myUnit.Weaponry.AllDistinctWeaponsAboard_Current_WeaponRecs(IncludeAviationMags: false);
					foreach (WeaponRec item in list)
					{
						if (item.CurrentLoad == 0)
						{
							continue;
						}
						Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
						ActiveUnit theAttackingUnit = myUnit;
						GlobalVariables.BooleanObject TargetIsDestroyed = null;
						if (weapon.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed))
						{
							if (!dictionary.ContainsKey(item.int_3))
							{
								dictionary.Add(item.int_3, item.CurrentLoad);
							}
							else
							{
								dictionary[item.int_3] += item.CurrentLoad;
							}
						}
					}
					List<string> list2 = new List<string>();
					foreach (KeyValuePair<int, int> item2 in dictionary)
					{
						list2.Add(Conversions.ToString(item2.Value) + "x " + Conversions.ToString(item2.Key));
					}
					theValue2 = string.Join("|", list2);
				}
				pooledDictionary.Add("CountermeasuresRemaining", new IEventExporter.EventNotificationParameter(theValue2, typeof(string)));
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponFired, pooledDictionary, myUnit.ParentScen);
			}
		}
		if (!theWeapon.IsActiveUnit)
		{
			((UnguidedWeapon)theWeapon).ExportLocationEvent(myUnit.ParentScen, "WeaponFireEvent");
		}
		else
		{
			((ActiveUnit)theWeapon).Kinematics.ExportLocationEvent("WeaponFireEvent");
		}
	}

	public static void DropPassiveSonobuoy(Module_Unit.Unit SelectedUnit, bool ShallowSonobuoy, bool IsManual, ref string UserFeedback)
	{
		if (SelectedUnit != null && SelectedUnit.IsAircraft)
		{
			if (!ShallowSonobuoy)
			{
				((Aircraft)SelectedUnit).Weaponry.DropSonobuoy(((ActiveUnit)SelectedUnit).ParentScen.GameResolution, IsManual, ref UserFeedback, SonarModel.PositionRelativeToThermocline.Below, false);
			}
			else
			{
				((Aircraft)SelectedUnit).Weaponry.DropSonobuoy(((ActiveUnit)SelectedUnit).ParentScen.GameResolution, IsManual, ref UserFeedback, SonarModel.PositionRelativeToThermocline.Above, false);
			}
		}
	}

	public static void DropActiveSonobuoy(Module_Unit.Unit SelectedUnit, bool ShallowSonobuoy, bool IsManual, ref string UserFeedback)
	{
		if (SelectedUnit != null && SelectedUnit.IsAircraft)
		{
			if (ShallowSonobuoy)
			{
				((Aircraft)SelectedUnit).Weaponry.DropSonobuoy(((ActiveUnit)SelectedUnit).ParentScen.GameResolution, IsManual, ref UserFeedback, SonarModel.PositionRelativeToThermocline.Above, true);
			}
			else
			{
				((Aircraft)SelectedUnit).Weaponry.DropSonobuoy(((ActiveUnit)SelectedUnit).ParentScen.GameResolution, IsManual, ref UserFeedback, SonarModel.PositionRelativeToThermocline.Below, true);
			}
		}
	}

	private void method_26(ref Mount mount_0, UnguidedWeapon unguidedWeapon_0, Sensor sensor_0, Contact contact_0, WeaponSalvo weaponSalvo_0, StringBuilder stringBuilder_1)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl) || myUnit.IsAircraft || mount_0 == null)
			{
				return;
			}
			if (mount_0.LocalControl && mount_0.CompatibleDirectors.Count == 0)
			{
				flag2 = true;
			}
			if (sensor_0 == null)
			{
				int num;
				if (stringBuilder_1 == null)
				{
					num = 1;
				}
				else
				{
					stringBuilder_1.Append("Not using any director (manual aiming). ");
					num = 1;
				}
				flag = (byte)num != 0;
				if (contact_0.CurrentSpeed > 0f && contact_0.Age == 0f && contact_0.ActualUnit != null && unguidedWeapon_0.Type != Weapon._WeaponType.Laser && (unguidedWeapon_0.Type != Weapon._WeaponType.Microwave || unguidedWeapon_0.Type == Weapon._WeaponType.LaserDazzler))
				{
					double num2 = contact_0.ActualUnit.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
					if (num2 > 0.0)
					{
						double num3 = (double)contact_0.CurrentSpeed / num2;
						stringBuilder_1?.Append("Target is moving at ").Append((int)Math.Round(100.0 * num3)).Append("% of its maximum speed; accuracy adjusted to same. ");
						unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * (1.0 + num3));
						unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * (1.0 + num3));
					}
					else
					{
						double num3 = 0.0;
					}
				}
			}
			else if (unguidedWeapon_0.Type != Weapon._WeaponType.Laser && unguidedWeapon_0.Type != Weapon._WeaponType.Microwave && unguidedWeapon_0.Type != Weapon._WeaponType.LaserDazzler)
			{
				switch (sensor_0.Type)
				{
				case Sensor.Sensor_Type.LaserDesignator:
					unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.2);
					unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.2);
					unguidedWeapon_0.AirPOK = (float)((double)(long)Math.Round(unguidedWeapon_0.AirPOK) / 1.2);
					stringBuilder_1?.Append("Director (").Append(sensor_0.Name).Append(") is laser; accuracy decreased by 20%. ");
					break;
				case Sensor.Sensor_Type.Visual:
				case Sensor.Sensor_Type.Infrared:
					unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 1.5);
					unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 1.5);
					unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK / 1.5);
					stringBuilder_1?.Append("Director (").Append(sensor_0.Name).Append(") is visual/EO/IR; accuracy decreased by 50%. ");
					break;
				case Sensor.Sensor_Type.Radar:
					stringBuilder_1?.Append("Director (").Append(sensor_0.Name).Append(") is radar; accuracy unaffected. ");
					break;
				}
			}
			if (!flag && weaponSalvo_0 != null)
			{
				WeaponSalvo.Shooter[] shootersList = weaponSalvo_0.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) != 0)
					{
						continue;
					}
					int quantityFired = shooter.QuantityFired;
					if (quantityFired >= 4)
					{
						if (quantityFired < 8)
						{
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.9);
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.9);
							unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.1);
							stringBuilder_1?.Append("A few (less than 8) rounds already fired in salvo; accuracy improving slightly. ");
						}
						else if (quantityFired < 12)
						{
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.8);
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.8);
							unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.25);
							stringBuilder_1?.Append("Some (less than 12) rounds already fired in salvo; accuracy improving measurably. ");
						}
						else if (quantityFired < 15)
						{
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.7);
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.7);
							unguidedWeapon_0.AirPOK = (float)((double)unguidedWeapon_0.AirPOK * 1.5);
							stringBuilder_1?.Append("Quite a few (less than 15) rounds already fired in salvo; accuracy improving substantially. ");
						}
						else
						{
							unguidedWeapon_0.CEP_Surface = (float)((double)unguidedWeapon_0.CEP_Surface * 0.2);
							unguidedWeapon_0.CEP_Land = (float)((double)unguidedWeapon_0.CEP_Land * 0.2);
							unguidedWeapon_0.AirPOK *= 2f;
							stringBuilder_1?.Append("Lots of rounds already fired in salvo; accuracy improving tremendously. ");
						}
					}
				}
			}
			if (flag && !flag2)
			{
				unguidedWeapon_0.CEP_Surface *= 3f;
				unguidedWeapon_0.CEP_Land *= 3f;
				unguidedWeapon_0.AirPOK /= 3f;
				unguidedWeapon_0.SubPOK /= 3f;
				stringBuilder_1?.Append("Aiming manually in system not primarily designed for local control; accuracy sharply reduced. ");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100337", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_27(ref Contact contact_0, Mount mount_0, ref Sensor sensor_0)
	{
		if (mount_0 == null)
		{
			return;
		}
		try
		{
			List<Sensor> list = method_11(mount_0, contact_0);
			if (list.Count <= 0)
			{
				return;
			}
			IEnumerable<Sensor> source = list.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar);
			if (source.Count() <= 0)
			{
				IEnumerable<Sensor> source2 = list.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.LaserDesignator);
				if (source2.Count() <= 0)
				{
					IEnumerable<Sensor> source3 = list.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.Visual || theS.Type == Sensor.Sensor_Type.Infrared);
					if (source3.Count() > 0)
					{
						sensor_0 = source3.ElementAtOrDefault(0);
						sensor_0.TrackTargetForFireControl(ref contact_0);
					}
				}
				else
				{
					sensor_0 = source2.ElementAtOrDefault(0);
					sensor_0.TrackTargetForFireControl(ref contact_0);
				}
			}
			else
			{
				sensor_0 = source.ElementAtOrDefault(0);
				sensor_0.TrackTargetForFireControl(ref contact_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100338", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public int? BearingForSensorBoresightToCoverMultipleTargets(Sensor theSensor, List<Module_Unit.Unit> theList)
	{
		_Closure$__141-0 arg = default(_Closure$__141-0);
		_Closure$__141-0 CS$<>8__locals7 = new _Closure$__141-0(arg);
		CS$<>8__locals7.$VB$Local_theSensor = theSensor;
		List<int> list = new List<int>();
		int num = 0;
		do
		{
			if (!Sensor.CanTrackAllTargetsAtThisBoresightBearing(CS$<>8__locals7.$VB$Local_theSensor, num, theList))
			{
				num++;
				continue;
			}
			list.Add(num);
			break;
		}
		while (num <= 359);
		int count = list.Count;
		int? result;
		if (count == 0)
		{
			result = null;
		}
		else
		{
			int value;
			if (count != 1)
			{
				if (theList.Count == 1)
				{
					value = (int)Math.Round(Module_Unit.BearingToUnit_True(CS$<>8__locals7.$VB$Local_theSensor.ParentPlatform, theList[0]));
				}
				else
				{
					_Closure$__141-1 arg2 = default(_Closure$__141-1);
					_Closure$__141-1 CS$<>8__locals9 = new _Closure$__141-1(arg2);
					Module_Unit.Unit theUnit = theList.OrderBy([SpecialName] (Module_Unit.Unit targetUnit) => CS$<>8__locals7.$VB$Local_theSensor.ParentPlatform.RangeToUnit_Horiz(targetUnit)).ElementAtOrDefault(0);
					CS$<>8__locals9.$VB$Local_BearingToNearestTarget = Module_Unit.BearingToUnit_True(CS$<>8__locals7.$VB$Local_theSensor.ParentPlatform, theUnit);
					value = list.Aggregate([SpecialName] (int x, int y) => (!(Math.Abs((float)x - CS$<>8__locals9.$VB$Local_BearingToNearestTarget) >= Math.Abs((float)y - CS$<>8__locals9.$VB$Local_BearingToNearestTarget))) ? x : y);
				}
			}
			else
			{
				value = list[0];
			}
			result = value;
		}
		return result;
	}

	private bool method_28(ref ActiveUnit activeUnit_0, ref Weapon weapon_6, ref Contact contact_0)
	{
		if (contact_0 == null)
		{
			return false;
		}
		bool result = default(bool);
		try
		{
			int num;
			if (!weapon_6.Flags.IlluminateAtLaunch)
			{
				num = 0;
			}
			else
			{
				Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				bool? LOS_Exists_Sonar = null;
				Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
				List<ActiveUnit> list = default(List<ActiveUnit>);
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.Status != PlatformComponent._ComponentStatus.Operational || !sensor.CanIlluminateForThisWeapon(ref weapon_6))
					{
						continue;
					}
					if (sensor.Type == Sensor.Sensor_Type.Radar && list == null)
					{
						list = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
					}
					if (sensor.CanIlluminateTarget(activeUnit_0, contact_0.ActualUnit, Module_Unit.RangeToUnit_Slant(activeUnit_0, contact_0), list, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar) != Sensor.SensorDetectionCheckResult.Success)
					{
						continue;
					}
					if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.TargetsTrackedForFireControl_Readonly.Count > 1)
					{
						List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>(sensor.TargetsTrackedForFireControl_Readonly);
						list2.Add(contact_0);
						int? num2 = BearingForSensorBoresightToCoverMultipleTargets(sensor, list2);
						if (!num2.HasValue)
						{
							continue;
						}
						sensor.Boresight = num2.Value;
					}
					else
					{
						sensor.Boresight = Module_Unit.BearingToUnit_True(sensor.ParentPlatform, contact_0);
					}
					if (!sensor.IsTrackingThisTargetForFireControl(ref contact_0))
					{
						if (!sensor.HasFireControlChannelAvailable())
						{
							continue;
						}
						sensor.TrackTargetForFireControl(ref contact_0);
					}
					if (!sensor.SemiActiveWeaponsGuided.Contains(weapon_6))
					{
						sensor.SemiActiveWeaponsGuided.Add(weapon_6);
						weapon_6.SensorProvidingFireControlForMe = sensor;
					}
					int num3;
					if (!sensor.IsActive())
					{
						sensor.GoActive();
						num3 = 1;
					}
					else
					{
						num3 = 1;
					}
					result = (byte)num3 != 0;
					return result;
				}
				num = 0;
			}
			result = (byte)num != 0;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100339", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_0(ActiveUnit activeUnit_0, object object_0, Contact contact_0)
	{
		_Closure$__143-0 arg = default(_Closure$__143-0);
		_Closure$__143-0 CS$<>8__locals7 = new _Closure$__143-0(arg);
		CS$<>8__locals7.$VB$Local_FiringUnit = activeUnit_0;
		if (contact_0 == null)
		{
			return false;
		}
		bool result = default(bool);
		try
		{
			CommDevice[] comms_ReadOnly = ((Weapon)object_0).Comms_ReadOnly;
			int num;
			if (comms_ReadOnly.Count() <= 0)
			{
				num = 0;
			}
			else
			{
				if (((Weapon)object_0).Flags.LOAL_CEC && ((Weapon)object_0).IsAAWCapable)
				{
					ActiveUnit[] array = CS$<>8__locals7.$VB$Local_FiringUnit.get_UnitSide(SetSideOnly: false).Units.OrderBy([SpecialName] (ActiveUnit theU) => CS$<>8__locals7.$VB$Local_FiringUnit.RangeToUnit_Horiz(theU)).ToArray();
					foreach (ActiveUnit activeUnit in array)
					{
						if (activeUnit != CS$<>8__locals7.$VB$Local_FiringUnit)
						{
							CommDevice item = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit((ActiveUnit)object_0, comms_ReadOnly, activeUnit).CommDevice;
							if (item != null && activeUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(contact_0) && ((Weapon)object_0).CommStuff.EstablishCommLinkToUnit(item, activeUnit, Is_CEC_Connection: true))
							{
								((Weapon)object_0).DataLinkParent = activeUnit;
								result = true;
								return result;
							}
						}
					}
				}
				if (ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit((ActiveUnit)object_0, comms_ReadOnly, CS$<>8__locals7.$VB$Local_FiringUnit, IgnoreChannelCount: false, null, null, onlyOneRequired: false, MustCheckLOS: false).CommDevice != null && ((Weapon)object_0).CommStuff.EstablishCommLinkToUnit(null, CS$<>8__locals7.$VB$Local_FiringUnit, Is_CEC_Connection: false, MustCheckLOS: false))
				{
					((Weapon)object_0).DataLinkParent = CS$<>8__locals7.$VB$Local_FiringUnit;
					result = true;
					return result;
				}
				num = 0;
			}
			result = (byte)num != 0;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100340", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool TargetIsWithinNEZ(Contact theTarget, Weapon theWeapon, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Flank)
	{
		Weapon._WeaponType type = theWeapon.Type;
		if (type != Weapon._WeaponType.GuidedWeapon && type != Weapon._WeaponType.Torpedo)
		{
			return true;
		}
		int num = (int)Math.Round(theWeapon.Fuel_ReadOnly[0].CurrentQuantity);
		float num2 = myUnit.RangeToUnit_Horiz(theTarget) + theTarget.CurrentSpeed * (float)num / 3600f;
		theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
		theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, myUnit.get_Latitude((GlobalVariables.BooleanObject)null));
		theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		theWeapon.SetThrottle(ThrottleSetting);
		theWeapon.CurrentSpeed = myUnit.CurrentSpeed;
		theWeapon.DesiredSpeed = theWeapon.Kinematics.GetMaximumSpeed(theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
		theWeapon.DesiredAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		theWeapon.AI.PrimaryTarget = theTarget;
		theWeapon.AI.PrimaryTarget_Type = theTarget.Type;
		if (InitialHeading == 0f)
		{
			if ((object)myUnit.GetType() != typeof(Aircraft) && (object)myUnit.GetType() != typeof(Submarine))
			{
				theWeapon.CurrentHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theWeapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			}
			else
			{
				theWeapon.CurrentHeading = myUnit.CurrentHeading;
			}
		}
		else
		{
			theWeapon.CurrentHeading = InitialHeading;
		}
		int num3 = num;
		for (int i = 1; i <= num3; i++)
		{
			theWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, myUnit.ParentScen.Time.AddSeconds(i));
		}
		return Math2.CalcDist(theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) > num2;
	}

	private static DLZResultEnum smethod_1(Weapon weapon_6, Module_Unit.Unit unit_0)
	{
		if (Terrain.PointIsOverland(weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null)).IsOverland)
		{
			if (weapon_6.MaxTargetAlt_AGL > 0f && unit_0.CurrentAltitude_AGL > weapon_6.MaxTargetAlt_AGL)
			{
				return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
			}
			if (weapon_6.MinTargetAlt_AGL > 0f && unit_0.CurrentAltitude_AGL < weapon_6.MinTargetAlt_AGL)
			{
				return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
			}
		}
		else
		{
			if (weapon_6.MaxTargetAlt_ASL > 0f && unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > weapon_6.MaxTargetAlt_ASL)
			{
				return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
			}
			if (weapon_6.MinTargetAlt_ASL > 0f && unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < weapon_6.MinTargetAlt_ASL)
			{
				return DLZResultEnum.Fail_OutsideValidAltitudeEnvelope;
			}
		}
		return DLZResultEnum.Success;
	}

	public static (DLZResultEnum, float) TargetIsWithinDLZ_BallisticTarget(Scenario theScen, int WeaponID, ActiveUnit FiringUnit, bool AssumeVerticalLaunch, double LaunchLongitude, double LaunchLatitude, float LaunchAltitude, int LaunchSpeed, Contact theTarget, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Cruise, [Optional][DefaultParameterValue(null)] ref GeoPoint InterceptPoint, [Optional][DefaultParameterValue("")] ref string FeedbackText, List<float> XDAT = null, List<float> YDAT = null, [Optional][DefaultParameterValue(0f)] ref float FlightTime, Action<string> theLogger = null, Action<DLZResultData> theResultOutputter = null)
	{
		InterceptPoint = null;
		(DLZResultEnum, float) result;
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
			newWeapon.IsDLZconstruct = true;
			if (newWeapon.Fuel_ReadOnly.Count == 0)
			{
				newWeapon.AddFuelRec(new FuelRec(0, 0));
			}
			newWeapon.FiringParent = FiringUnit;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, theScen, FiringUnit.IsAircraft || FiringUnit.IsMissile, FiringUnit.CurrentSpeed);
			Weapon newWeapon2 = Weapon.GetNewWeapon(ref theTarget.ActualUnit.ParentScen, theTarget.ActualUnit.DBID, bool_5: true);
			newWeapon2.IsDLZconstruct = true;
			newWeapon2.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			newWeapon2.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
			newWeapon2.CurrentHeading = theTarget.CurrentHeading;
			newWeapon2.CurrentSpeed = theTarget.CurrentSpeed;
			newWeapon2.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			newWeapon2.Attitude_Pitch = theTarget.ActualUnit.Attitude_Pitch;
			newWeapon2.FiringParent = ((Weapon)theTarget.ActualUnit).FiringParent;
			newWeapon2.LaunchPoint = ((Weapon)theTarget.ActualUnit).LaunchPoint;
			if (newWeapon2.FiringParent != null)
			{
				newWeapon2.LaunchSpeed = newWeapon2.FiringParent.CurrentSpeed;
			}
			newWeapon2.ThrottleSetting = ActiveUnit.Throttle.Flank;
			newWeapon2.IsDLZconstruct = true;
			int num;
			if (theTarget.ActualUnit is BallisticMissile)
			{
				newWeapon2.AI.PrimaryTarget = ((BallisticMissile)theTarget.ActualUnit).GetTargetAimpoint();
				num = 0;
			}
			else
			{
				newWeapon2.AI.PrimaryTarget = theTarget.ActualUnit.AI.PrimaryTarget;
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (theTarget.ActualUnit.IsWeapon & ((Weapon)theTarget.ActualUnit).IsHGV)
			{
				newWeapon2.AI.TerminalDive = ((HGV)theTarget.ActualUnit).AI.TerminalDive;
				flag = true;
			}
			if (theTarget.ActualUnit.IsBallisticMissile && !flag)
			{
				newWeapon2.TimeSinceBurnout = ((BallisticMissile)theTarget.ActualUnit).TimeSinceBurnout;
				newWeapon2.TimeSinceLaunch = ((BallisticMissile)theTarget.ActualUnit).TimeSinceLaunch;
			}
			newWeapon2.Navigator.ClearPlottedCourse();
			Waypoint[] plottedCourse = ((Weapon)theTarget.ActualUnit).Navigator.PlottedCourse;
			foreach (Waypoint theWP in plottedCourse)
			{
				newWeapon2.Navigator.AddWaypoint(theWP);
			}
			newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, LaunchLongitude);
			newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, LaunchLatitude);
			newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, LaunchAltitude);
			newWeapon.CurrentSpeed = LaunchSpeed;
			if (ThrottleSetting <= newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(ThrottleSetting);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (InitialHeading > 0f)
			{
				newWeapon.CurrentHeading = InitialHeading;
			}
			else
			{
				newWeapon.CurrentHeading = Math2.CalcAzimuth(LaunchLatitude, LaunchLongitude, newWeapon2.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon2.get_Longitude((GlobalVariables.BooleanObject)null));
			}
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			newWeapon.LaunchSpeed = FiringUnit.CurrentSpeed;
			if (!AssumeVerticalLaunch)
			{
				if (!FiringUnit.IsAerospaceUnit)
				{
					double num2 = Math.Atan2(newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (double)FiringUnit.RangeToUnit_Horiz(newWeapon2) * 1852.0) * 57.2957795130823;
					newWeapon.Attitude_Pitch = (float)num2;
				}
				else
				{
					newWeapon.Attitude_Pitch = FiringUnit.Attitude_Pitch;
				}
			}
			else
			{
				newWeapon.Attitude_Pitch = 90f;
			}
			Contact contact = Contact.Instantiate(newWeapon2);
			contact.CurrentSpeed = theTarget.CurrentSpeed;
			contact.SpeedIsKnown = theTarget.SpeedIsKnown;
			contact.CurrentHeading = theTarget.CurrentHeading;
			contact.HeadingIsKnown = theTarget.HeadingIsKnown;
			((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			contact.AltitudeIsKnown = theTarget.AltitudeIsKnown;
			contact.FutureBallisticPath = theTarget.FutureBallisticPath;
			newWeapon.AI.PrimaryTarget = contact;
			newWeapon.Kinematics.SetActualLoftAltitude(FiringUnit, contact);
			if (newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
			{
				float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
				float weaponNominalSpeed = ((!(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)) ? ((float)newWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false)) : ((float)newWeapon.Kinematics.GetMaximumSpeed(maximumAltitude)));
				newWeapon.Navigator.ABMInterceptPoint = null;
				if (!newWeapon.Navigator.ComputeTerminalPoint(weaponNominalSpeed, IsAirdroppedTorpedo: false).HasValue)
				{
					FeedbackText = "Unable to calculate intercept course";
					return (DLZResultEnum.Fail_CannotPlotIntercept, FlightTime);
				}
			}
			float num3 = newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			if (num3 <= 0f)
			{
				num3 = 1f;
			}
			float num4 = newWeapon.Fuel_ReadOnly[0].CurrentQuantity / num3 - 1f;
			bool flag2 = false;
			long num5 = (long)Math.Round(86400.0 + theScen.Duration.TotalSeconds);
			long num6 = ((!newWeapon.UsesBoostCoastModel.Value) ? ((long)Math.Round(num4 * 2f)) : long.MaxValue);
			bool flag3 = num6 > num5;
			long num7 = num6;
			long num8 = 0L;
			bool flag4 = default(bool);
			int item;
			while (true)
			{
				if (num8 <= num7)
				{
					newWeapon.Navigator.ABMInterceptPoint = null;
					if (!(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation) || contact.CurrentAltitude_AGL >= 10f)
					{
						if (newWeapon.UsesBoostCoastModel.Value)
						{
							if (newWeapon.TimeSinceLaunch > (float)newWeapon.TotalBurnTime && newWeapon.CurrentSpeed < (float)newWeapon.Kinematics.StallSpeed(newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
							{
								FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num8) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
								return (DLZResultEnum.Fail_OutOfEnergy, FlightTime);
							}
						}
						else if ((float)num8 > num4)
						{
							if (!newWeapon.SupportsAttitude_Pitch)
							{
								FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num8) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
								return (DLZResultEnum.Fail_OutOfEnergy, FlightTime);
							}
							if (newWeapon.Attitude_Pitch >= newWeapon.InfiniteGlideAngle)
							{
								FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num8) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
								return (DLZResultEnum.Fail_OutOfEnergy, FlightTime);
							}
						}
						newWeapon2.AI.DetermineDesiredAttitudeAndThrottle(1f);
						newWeapon2.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num8));
						if (newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != 0f)
						{
							if (!(newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation) || newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)Terrain.GetElevation(newWeapon2.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon2.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen))
							{
								if (!(newWeapon2.Attitude_Pitch < 0f) || newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > newWeapon2.ImpactAltitude)
								{
									contact.CurrentSpeed = newWeapon2.CurrentSpeed;
									contact.CurrentHeading = newWeapon2.CurrentHeading;
									((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, newWeapon2.get_Longitude((GlobalVariables.BooleanObject)null));
									((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, newWeapon2.get_Latitude((GlobalVariables.BooleanObject)null));
									((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, newWeapon2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
									newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
									if (ThrottleSetting <= newWeapon.MaxPossibleThrottleSetting)
									{
										newWeapon.SetThrottle(ThrottleSetting);
									}
									else
									{
										newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
									}
									newWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num8));
									XDAT?.Add(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)));
									YDAT?.Add(newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
									if ((float)num8 != num4 && newWeapon.RangeToUnit_Horiz(contact) < Math.Max(2f, (newWeapon.CurrentSpeed + contact.CurrentSpeed) / 2400f))
									{
										if (newWeapon.AboutToImpact(newWeapon2, 1f, CheckDistranceBasedOnClosureSpeed: true))
										{
											double lon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
											double lat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
											Contact contact2;
											double out_lon = ((Module_Unit.Unit)(contact2 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
											Contact contact3;
											double out_lat = ((Module_Unit.Unit)(contact3 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
											Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
											((Module_Unit.Unit)contact3).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
											((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
											newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
											newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
											newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
											InterceptPoint = new GeoPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
											flag4 = true;
											FlightTime = num8;
											if (!(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > newWeapon.MaxTargetAlt_ASL) && ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= newWeapon.MinTargetAlt_ASL)
											{
												if (Module_Unit.RangeToPoint_Slant(contact, newWeapon.LaunchPoint) < newWeapon.MinRange_NoTargetType)
												{
													FeedbackText = "FAILURE! Estimated intercept point (" + Conversions.ToString(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) + "m) is within the weapon's minimum range.";
													return (DLZResultEnum.Fail_InsideMinimumRange, FlightTime);
												}
												goto IL_0bf2;
											}
											FeedbackText = "FAILURE! Altitude of estimated intercept point (" + Conversions.ToString(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) + "m) is outside weapon's min/max target altitude envelope.";
											return (DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, FlightTime);
										}
										float num9 = Module_Unit.BearingToUnit_Relative(newWeapon, contact);
										int num10;
										if (!(num9 < 90f))
										{
											if (!(num9 > 270f))
											{
												if (!flag2)
												{
													goto IL_080e;
												}
												if (((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > newWeapon.MaxTargetAlt_ASL || ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < newWeapon.MinTargetAlt_ASL)
												{
													FeedbackText = "FAILURE! Altitude of estimated intercept point (" + Conversions.ToString(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) + "m) is outside weapon's min/max target altitude envelope.";
													return (DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, FlightTime);
												}
												goto IL_0bf2;
											}
											num10 = 1;
										}
										else
										{
											num10 = 1;
										}
										flag2 = (byte)num10 != 0;
									}
									goto IL_080e;
								}
								return (DLZResultEnum.Fail_TargetWillImpactBeforeIntercept, FlightTime);
							}
							item = 8;
							break;
						}
						item = 8;
						break;
					}
					FeedbackText = "Ballistic Contact impacted ground";
					return (DLZResultEnum.Fail_TargetWillImpactBeforeIntercept, FlightTime);
				}
				goto IL_0bf2;
				IL_0bf2:
				switch (flag4)
				{
				case true:
					FeedbackText = "SUCCESS! Weapon reached target after " + Conversions.ToString(num8) + " seconds. Distance from launch point is " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
					break;
				case false:
					FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num8) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
					break;
				}
				contact = null;
				if (!flag4)
				{
					return (DLZResultEnum.Fail_OutOfEnergy, FlightTime);
				}
				return (DLZResultEnum.Success, FlightTime);
				IL_080e:
				if (!flag3 || num8 <= num5)
				{
					num8++;
					continue;
				}
				return (DLZResultEnum.Fail_ScenarioDuration, FlightTime);
			}
			return ((DLZResultEnum)item, FlightTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100343", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (DLZResultEnum.Fail_CodeError, FlightTime);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public (DLZResultEnum, float) TargetIsWithinDLZ_OrbitalTarget(Scenario theScen, int WeaponID, ActiveUnit theFiringUnit, double LaunchLongitude, double LaunchLatitude, float LaunchAltitude, int LaunchSpeed, Contact theTarget, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Cruise, [Optional][DefaultParameterValue(0f)] ref float FlightTime)
	{
		(DLZResultEnum, float) result = default((DLZResultEnum, float));
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
			newWeapon.FiringParent = theFiringUnit;
			newWeapon.IsDLZconstruct = true;
			Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, theScen, myUnit.IsAircraft || myUnit.IsMissile, myUnit.CurrentSpeed);
			Satellite theSatellite = new Satellite(ref theScen);
			theSatellite.IsDLZconstruct = true;
			int spacecraftNumber = Conversions.ToInteger(((Satellite)theTarget.ActualUnit).SpacecraftID.Split(Conversions.ToCharArrayRankOne("_"))[1]);
			DBFunctions.GetSatellite(ref theScen, ref theSatellite, theTarget.ActualUnit.DBID, spacecraftNumber, LoadComponents: false);
			((ActiveUnit)theSatellite).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theTarget.ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			theSatellite.CurrentSpeed = theTarget.ActualUnit.CurrentSpeed;
			theSatellite.CurrentHeading = theTarget.ActualUnit.CurrentHeading;
			((ActiveUnit)theSatellite).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			((ActiveUnit)theSatellite).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
			newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, LaunchLongitude);
			newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, LaunchLatitude);
			newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, LaunchAltitude);
			newWeapon.CurrentSpeed = LaunchSpeed;
			newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			if (InitialHeading > 0f)
			{
				newWeapon.CurrentHeading = InitialHeading;
			}
			else
			{
				newWeapon.CurrentHeading = Math2.CalcAzimuth(LaunchLatitude, LaunchLongitude, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			}
			newWeapon.LaunchPoint = new GeoPoint(LaunchLongitude, LaunchLatitude, LaunchAltitude);
			newWeapon.LaunchSpeed = theFiringUnit.CurrentSpeed;
			if (theFiringUnit.IsAerospaceUnit)
			{
				newWeapon.Attitude_Pitch = theFiringUnit.Attitude_Pitch;
			}
			else if (theFiringUnit.IsFacility || theFiringUnit.IsVehicle || theFiringUnit.IsShip || theFiringUnit.IsSubmarine)
			{
				newWeapon.Attitude_Pitch = 90f;
			}
			float num = (int)Math.Round(newWeapon.Fuel_ReadOnly[0].CurrentQuantity);
			Contact contact = Contact.Instantiate(theSatellite);
			((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			contact.CurrentSpeed = theSatellite.CurrentSpeed;
			contact.CurrentHeading = theSatellite.CurrentHeading;
			((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_Longitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_Latitude((GlobalVariables.BooleanObject)null));
			contact.HeadingIsKnown = theTarget.HeadingIsKnown;
			contact.SpeedIsKnown = theTarget.SpeedIsKnown;
			contact.AltitudeIsKnown = theTarget.AltitudeIsKnown;
			newWeapon.AI.PrimaryTarget = contact;
			if (newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
			{
				float weaponNominalSpeed = newWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false, ConsiderDamage: false);
				if (!newWeapon.Navigator.ComputeTerminalPoint(weaponNominalSpeed, IsAirdroppedTorpedo: false).HasValue)
				{
					result = (DLZResultEnum.Fail_CannotPlotIntercept, FlightTime);
					return result;
				}
			}
			float num2 = num - 1f;
			bool flag = default(bool);
			for (float num3 = 0f; num3 <= num2; num3 += 1f)
			{
				theSatellite.AI.DetermineDesiredAttitudeAndThrottle(1f);
				theSatellite.SetThrottle(theSatellite.MaxPossibleThrottleSetting);
				theSatellite.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num3));
				((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				contact.CurrentSpeed = theSatellite.CurrentSpeed;
				contact.CurrentHeading = theSatellite.CurrentHeading;
				((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)theSatellite).get_Latitude((GlobalVariables.BooleanObject)null));
				newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
				newWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num3));
				if (num3 != num && newWeapon.AboutToImpact_Contact(1f))
				{
					double lon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
					double lat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
					Contact contact2;
					double out_lon = ((Module_Unit.Unit)(contact2 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
					Contact contact3;
					double out_lat = ((Module_Unit.Unit)(contact3 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
					Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					((Module_Unit.Unit)contact3).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
					newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
					newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					flag = true;
					FlightTime = num3;
					break;
				}
			}
			if (!flag)
			{
				result = (DLZResultEnum.Fail_OutOfEnergy, FlightTime);
				return result;
			}
			result = (DLZResultEnum.Success, FlightTime);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100342", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static (DLZResultEnum, float) TargetIsWithinDLZ_BoostCoast(Scenario theScen, int WeaponID, Weapon theWeapon, ActiveUnit FiringUnit, bool AssumeVerticalLaunch, double LaunchLongitude, double LaunchLatitude, float LaunchAltitude, int LaunchSpeed, double TargetLongitude, double TargetLatitude, float TargetHeading, bool TargetHeadingKnown, int TargetSpeed, bool TargetSpeedKnown, float TargetAltitude, bool TargetAltitudeKnown, float TargetVerticalSpeed_mpersec, Contact_Base.ContactType TargetType, ref GeoPoint InterceptPoint, bool TargetIsTerminalDiving, ref string FeedbackText, bool IsPartOfBurnCalc, bool HumanFeedBackNeeded, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Cruise, int CustomBurnTime = 0, PooledList<TrajectoryPoint> Trajectory = null, [Optional][DefaultParameterValue(0f)] ref float FlightTime, Action<string> theLogger = null, Action<DLZResultData> theResultOutputter = null, AssumedDLZTargetBehavior theTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent, bool bool_12 = false, float customBodyDiameter_m = 0f, float customBodyLength_m = 0f, int customLaunchWeight_kg = 0, int customBurnoutWeight_kg = 0)
	{
		InterceptPoint = null;
		(DLZResultEnum, float) result;
		try
		{
			if (theWeapon == null)
			{
				theWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
			}
			theWeapon.IsDLZconstruct = true;
			if (customBodyDiameter_m > 0f)
			{
				theWeapon.Diameter = customBodyDiameter_m;
			}
			if (customBodyLength_m > 0f)
			{
				theWeapon.Length = customBodyLength_m;
			}
			if (customLaunchWeight_kg > 0)
			{
				theWeapon.MaxWeight = customLaunchWeight_kg;
			}
			if (customBurnoutWeight_kg > 0)
			{
				theWeapon._BurnoutWeight_DB = customBurnoutWeight_kg;
			}
			theWeapon.FiringParent = FiringUnit;
			if (!IsPartOfBurnCalc)
			{
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, theScen, FiringUnit.IsAircraft || FiringUnit.IsMissile, FiringUnit.CurrentSpeed, theLogger);
			}
			float maximumAltitude = theWeapon.Kinematics.GetMaximumAltitude();
			if (!TargetAltitudeKnown || !(TargetAltitude > maximumAltitude))
			{
				goto IL_015e;
			}
			if (TargetVerticalSpeed_mpersec >= 0f)
			{
				FeedbackText = "Target is higher than weapon ceiling";
				result = (DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, FlightTime);
			}
			else
			{
				if (!((TargetAltitude + (float?)theWeapon.FlightEndurance * TargetVerticalSpeed_mpersec).Value > maximumAltitude))
				{
					goto IL_015e;
				}
				FeedbackText = "Target will be higher than weapon ceiling throughout the weapon's flight";
				result = (DLZResultEnum.Fail_OutsideValidAltitudeEnvelope, FlightTime);
			}
			goto end_IL_0004;
			IL_015e:
			ActiveUnit activeUnit;
			switch (TargetType)
			{
			case Contact_Base.ContactType.Missile:
				activeUnit = new Weapon(theScen);
				((Weapon)activeUnit).Type = Weapon._WeaponType.GuidedWeapon;
				break;
			case Contact_Base.ContactType.Orbital:
				activeUnit = new Satellite(ref theScen);
				break;
			case Contact_Base.ContactType.Torpedo:
				activeUnit = new Weapon(theScen);
				((Weapon)activeUnit).Type = Weapon._WeaponType.Torpedo;
				break;
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Decoy_Air:
				activeUnit = new Aircraft(ref theScen);
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Decoy_Sub:
				activeUnit = new Submarine(ref theScen);
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				activeUnit = new Facility(ref theScen);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.ActivationPoint:
				activeUnit = new Ship(ref theScen);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Installation:
			case Contact_Base.ContactType.AirBase:
			case Contact_Base.ContactType.NavalBase:
			case Contact_Base.ContactType.AggregateGroundUnit:
				activeUnit = new Facility(ref theScen);
				break;
			}
			activeUnit.IsDLZconstruct = true;
			activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, TargetLongitude);
			activeUnit.set_Latitude((GlobalVariables.BooleanObject)null, TargetLatitude);
			if (theTargetBehavior == AssumedDLZTargetBehavior.ContinuesAsCurrent)
			{
				activeUnit.CurrentHeading = TargetHeading;
			}
			else if (theTargetBehavior == AssumedDLZTargetBehavior.RunStraightAway && !bool_12)
			{
				activeUnit.CurrentHeading = Module_Unit.BearingToUnit_True(FiringUnit, activeUnit);
			}
			if (theTargetBehavior == AssumedDLZTargetBehavior.Loiter)
			{
				activeUnit.CurrentSpeed = 0f;
			}
			else
			{
				activeUnit.CurrentSpeed = TargetSpeed;
			}
			activeUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, TargetAltitude);
			if (TargetType == Contact_Base.ContactType.Missile && TargetIsTerminalDiving)
			{
				((Weapon)activeUnit).AI.TerminalDive = true;
			}
			theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, LaunchLongitude);
			theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, LaunchLatitude);
			theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, LaunchAltitude);
			theWeapon.CurrentSpeed = LaunchSpeed;
			float num = theWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
			if (ThrottleSetting <= theWeapon.MaxPossibleThrottleSetting)
			{
				theWeapon.SetThrottle(ThrottleSetting);
			}
			else
			{
				theWeapon.SetThrottle(theWeapon.MaxPossibleThrottleSetting);
			}
			if (InitialHeading > 0f)
			{
				theWeapon.CurrentHeading = InitialHeading;
			}
			else
			{
				theWeapon.CurrentHeading = Math2.CalcAzimuth(LaunchLatitude, LaunchLongitude, TargetLatitude, TargetLongitude);
			}
			if (CustomBurnTime > 0)
			{
				theWeapon.TotalBurnTime = CustomBurnTime;
			}
			theWeapon.LaunchPoint = new GeoPoint(theWeapon.get_Longitude(GlobalVariables.ObjectTrue), theWeapon.get_Latitude(GlobalVariables.ObjectTrue), num);
			theWeapon.LaunchSpeed = FiringUnit.CurrentSpeed;
			if (AssumeVerticalLaunch)
			{
				theWeapon.Attitude_Pitch = 90f;
			}
			else if (!FiringUnit.IsAerospaceUnit)
			{
				double num2 = Math.Atan2(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (double)FiringUnit.RangeToUnit_Horiz(activeUnit) * 1852.0) * 57.2957795130823;
				theWeapon.Attitude_Pitch = (float)num2;
			}
			else
			{
				theWeapon.Attitude_Pitch = FiringUnit.Attitude_Pitch;
			}
			Contact contact = Contact.Instantiate(activeUnit);
			((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, TargetAltitude);
			contact.Altitude_old = ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - TargetVerticalSpeed_mpersec;
			if (theWeapon.IsTorpedo)
			{
				contact.AltitudeIsKnown = true;
			}
			else
			{
				contact.AltitudeIsKnown = TargetAltitudeKnown;
			}
			contact.CurrentSpeed = activeUnit.CurrentSpeed;
			contact.SpeedIsKnown = TargetSpeedKnown;
			contact.CurrentHeading = activeUnit.CurrentHeading;
			contact.HeadingIsKnown = TargetHeadingKnown;
			((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			theWeapon.AI.PrimaryTarget = contact;
			theWeapon.Kinematics.SetActualLoftAltitude(FiringUnit, contact);
			if ((theWeapon.Is_LOAL_capable || theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && !theWeapon.Navigator.ComputeTerminalPoint(theWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false).HasValue)
			{
				FeedbackText = "Unable to calculate intercept course";
				result = (DLZResultEnum.Fail_CannotPlotIntercept, FlightTime);
			}
			else
			{
				theWeapon.FuelConsumption(theWeapon.ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				long num3 = (long)Math.Round(86400.0 + theScen.Duration.TotalSeconds);
				float num4 = 0f;
				double out_lon = default(double);
				double out_lat = default(double);
				bool flag2 = default(bool);
				while (true)
				{
					if (!IsPartOfBurnCalc)
					{
						float timeSinceLaunch = theWeapon.TimeSinceLaunch;
						float? num5 = theWeapon.FlightEndurance;
						if (((!num5.HasValue) ? ((bool?)null) : new bool?(timeSinceLaunch > num5.GetValueOrDefault())) == true)
						{
							goto IL_090a;
						}
					}
					if (!(theWeapon.TimeSinceLaunch > (float)theWeapon.TotalBurnTime) || !(theWeapon.CurrentSpeed < (float)theWeapon.Kinematics.StallSpeed(num)))
					{
						if (contact.CurrentSpeed != 0f)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
							activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
							activeUnit.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
							activeUnit.Altitude_old = activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							activeUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) + TargetVerticalSpeed_mpersec);
							((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
							((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
							contact.Altitude_old = ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue));
						}
						if ((theWeapon.Is_LOAL_capable || theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && theWeapon.Navigator.HasPlottedCourse())
						{
							bool flag = false;
							float timeSinceLaunch = Module_Unit.RangeToUnit_Slant(theWeapon, contact);
							if (timeSinceLaunch > 50f)
							{
								if (num4 % 5f == 0f)
								{
									flag = true;
								}
							}
							else if (timeSinceLaunch > 25f)
							{
								if (num4 % 2f == 0f)
								{
									flag = true;
								}
							}
							else
							{
								flag = true;
							}
							if (flag)
							{
								theWeapon.Navigator.ComputeTerminalPoint(theWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false);
							}
						}
						theWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
						if (ThrottleSetting <= theWeapon.MaxPossibleThrottleSetting)
						{
							theWeapon.SetThrottle(ThrottleSetting);
						}
						else
						{
							theWeapon.SetThrottle(theWeapon.MaxPossibleThrottleSetting);
						}
						theWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num4));
						num = theWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
						Trajectory?.Add(new TrajectoryPoint(theWeapon.get_Longitude(GlobalVariables.ObjectTrue), theWeapon.get_Latitude(GlobalVariables.ObjectTrue), theWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), theScen.Time.AddSeconds(num4)));
						if (!theWeapon.AboutToImpact_Contact(1f) || (!theWeapon.IsABMOptimized() && theWeapon.RangeToUnit_Horiz(contact, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) >= 1f))
						{
							num4 += 1f;
							if (!(num4 > (float)num3))
							{
								continue;
							}
							try
							{
								string newLine = Environment.NewLine;
								string text = "--TARGET--" + newLine;
								string text2 = "--WEAPON--" + newLine;
								text2 = text2 + "Type " + Misc.ToEnglishString(theWeapon.Type) + newLine + "DBID " + Conversions.ToString(theWeapon.DBID) + newLine + "Name " + theWeapon.Name + newLine + "Heading " + Conversions.ToString(theWeapon.CurrentHeading) + newLine + "Altitude " + Conversions.ToString(num) + newLine + "LAT,LONG" + Conversions.ToString(theWeapon.get_Latitude((GlobalVariables.BooleanObject)null)) + "," + Conversions.ToString(theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)) + "last speed " + newLine + Conversions.ToString(theWeapon.CurrentSpeed) + newLine + newLine;
								text = text + "Type " + TargetType.ToString() + newLine + "Heading " + Conversions.ToString(TargetHeading) + newLine + "Altitude " + Conversions.ToString(TargetAltitude) + newLine + "LAT,LONG" + Conversions.ToString(TargetLatitude) + "," + Conversions.ToString(TargetLongitude) + newLine + "Last speed " + Conversions.ToString(TargetSpeed) + newLine + newLine;
								GameGeneral.WriteExceptionsToLog(new Exception("DLZ boost coast failed solution computation duration " + num3 + "seconds)" + newLine + text + text2));
								result = (DLZResultEnum.Fail_ScenarioDuration, FlightTime);
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								int item;
								if (!Debugger.IsAttached)
								{
									item = 11;
								}
								else
								{
									Debugger.Break();
									item = 11;
								}
								result = ((DLZResultEnum)item, FlightTime);
								ProjectData.ClearProjectError();
							}
							break;
						}
						double lon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
						double lat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
						Contact contact2;
						double out_lon2 = ((Module_Unit.Unit)(contact2 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
						Contact contact3;
						double out_lat2 = ((Module_Unit.Unit)(contact3 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon2, ref out_lat2, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
						((Module_Unit.Unit)contact3).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
						((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
						theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
						theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
						theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						num = theWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
						InterceptPoint = new GeoPoint(theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), num);
						flag2 = true;
						FlightTime = num4;
					}
					goto IL_090a;
					IL_090a:
					if (HumanFeedBackNeeded)
					{
						switch (flag2)
						{
						case true:
							FeedbackText = "SUCCESS! Weapon reached target after " + Conversions.ToString(num4) + " seconds. Distance from launch point is " + Conversions.ToString(Math.Round(Math2.CalcDist(theWeapon.LaunchPoint.Latitude, theWeapon.LaunchPoint.Longitude, theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
							break;
						case false:
							if (theTargetBehavior == AssumedDLZTargetBehavior.RunStraightAway && !bool_12)
							{
								FeedbackText = "FAILURE! Target was outside NEZ " + Conversions.ToString(num4) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(theWeapon.LaunchPoint.Latitude, theWeapon.LaunchPoint.Longitude, theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
							}
							else
							{
								FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num4) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(theWeapon.LaunchPoint.Latitude, theWeapon.LaunchPoint.Longitude, theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
							}
							break;
						}
					}
					contact = null;
					if (!flag2)
					{
						result = ((theTargetBehavior != AssumedDLZTargetBehavior.RunStraightAway) ? (DLZResultEnum.Fail_OutOfEnergy, num4) : (DLZResultEnum.Fail_MAXRangeWRA, num4));
						break;
					}
					int item2;
					if (!IsPartOfBurnCalc)
					{
						item2 = 1;
					}
					else
					{
						float num6 = 0.67f * (float)theWeapon.Kinematics.GetMaximumSpeed(theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * theWeapon.Kinematics.MinimumDesiredAverageSpeedMultiplier();
						if (theWeapon.CurrentSpeed < num6)
						{
							result = (DLZResultEnum.Fail_OutOfEnergy, num4);
							break;
						}
						item2 = 1;
					}
					result = ((DLZResultEnum)item2, num4);
					break;
				}
			}
			end_IL_0004:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100343", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (DLZResultEnum.Fail_CodeError, 0f);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static (DLZResultEnum DLZREsult, float FlightTime) TargetIsWithinDLZ(Scenario theScen, int WeaponID, ActiveUnit FiringUnit, bool AssumeVerticalLaunch, double LaunchLongitude, double LaunchLatitude, float LaunchAltitude, int LaunchSpeed, double TargetLongitude, double TargetLatitude, float TargetHeading, bool TargetHeadingKnown, int TargetSpeed, bool TargetSpeedKnown, float TargetAltitude, bool TargetAltitudeKnown, float TargetVerticalSpeed_mpersec, Contact_Base.ContactType TargetType, ref GeoPoint InterceptPoint, bool TargetIsTerminalDiving, ref string FeedbackText, bool HumanFeedBackNeeded, float InitialHeading = 0f, ActiveUnit.Throttle ThrottleSetting = ActiveUnit.Throttle.Cruise, Waypoint[] ComplexCourse = null, int CustomWeaponFuel = 0, PooledList<TrajectoryPoint> Trajectory = null, [Optional][DefaultParameterValue(0f)] ref float FlightTime, Action<string> theLogger = null, Action<DLZResultData> theResultOutputter = null, AssumedDLZTargetBehavior theTargetBehavior = AssumedDLZTargetBehavior.ContinuesAsCurrent, bool bool_12 = false)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
		newWeapon.FiringParent = FiringUnit;
		(DLZResultEnum, float) result;
		if (!newWeapon.UsesBoostCoastModel.Value)
		{
			InterceptPoint = null;
			try
			{
				newWeapon.IsDLZconstruct = true;
				if (newWeapon.Fuel_ReadOnly.Count == 0)
				{
					newWeapon.AddFuelRec(new FuelRec(0, 0));
				}
				Weapon.RecalculateWeaponFlightEnergyIfNecessary(newWeapon, theScen, FiringUnit.IsAircraft || FiringUnit.IsMissile, FiringUnit.CurrentSpeed);
				if (newWeapon.Flags.SearchPattern)
				{
					newWeapon.Flags.SearchPattern = false;
				}
				ActiveUnit activeUnit;
				switch (TargetType)
				{
				case Contact_Base.ContactType.Missile:
					activeUnit = new Weapon(theScen);
					((Weapon)activeUnit).Type = Weapon._WeaponType.GuidedWeapon;
					break;
				case Contact_Base.ContactType.Orbital:
					activeUnit = new Satellite(ref theScen);
					break;
				case Contact_Base.ContactType.Torpedo:
					activeUnit = new Weapon(theScen);
					((Weapon)activeUnit).Type = Weapon._WeaponType.Torpedo;
					break;
				case Contact_Base.ContactType.Air:
				case Contact_Base.ContactType.Decoy_Air:
					activeUnit = new Aircraft(ref theScen);
					break;
				case Contact_Base.ContactType.Submarine:
				case Contact_Base.ContactType.Decoy_Sub:
					activeUnit = new Submarine(ref theScen);
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					activeUnit = new Facility(ref theScen);
					break;
				case Contact_Base.ContactType.Surface:
				case Contact_Base.ContactType.Aimpoint:
				case Contact_Base.ContactType.Decoy_Surface:
				case Contact_Base.ContactType.ActivationPoint:
					activeUnit = new Ship(ref theScen);
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.Decoy_Land:
				case Contact_Base.ContactType.Installation:
				case Contact_Base.ContactType.AirBase:
				case Contact_Base.ContactType.NavalBase:
				case Contact_Base.ContactType.AggregateGroundUnit:
					activeUnit = new Facility(ref theScen);
					break;
				}
				activeUnit.IsDLZconstruct = true;
				activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, TargetLongitude);
				activeUnit.set_Latitude((GlobalVariables.BooleanObject)null, TargetLatitude);
				if (!(theTargetBehavior == AssumedDLZTargetBehavior.RunStraightAway && !bool_12))
				{
					activeUnit.CurrentHeading = TargetHeading;
				}
				else
				{
					activeUnit.CurrentHeading = Module_Unit.BearingToUnit_True(FiringUnit, activeUnit);
				}
				if (theTargetBehavior == AssumedDLZTargetBehavior.Loiter)
				{
					activeUnit.CurrentSpeed = 0f;
				}
				else
				{
					activeUnit.CurrentSpeed = TargetSpeed;
				}
				activeUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, TargetAltitude);
				if (TargetType == Contact_Base.ContactType.Missile && TargetIsTerminalDiving)
				{
					((Weapon)activeUnit).AI.TerminalDive = true;
				}
				newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, LaunchLongitude);
				newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, LaunchLatitude);
				newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, LaunchAltitude);
				newWeapon.CurrentSpeed = LaunchSpeed;
				if (ThrottleSetting <= newWeapon.MaxPossibleThrottleSetting)
				{
					newWeapon.SetThrottle(ThrottleSetting);
				}
				else
				{
					newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
				}
				if (InitialHeading > 0f)
				{
					newWeapon.CurrentHeading = InitialHeading;
				}
				else
				{
					newWeapon.CurrentHeading = Math2.CalcAzimuth(LaunchLatitude, LaunchLongitude, TargetLatitude, TargetLongitude);
				}
				if (CustomWeaponFuel > 0)
				{
					newWeapon.Fuel_ReadOnly[0].CurrentQuantity = CustomWeaponFuel;
				}
				newWeapon.LaunchPoint = new GeoPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				newWeapon.LaunchSpeed = FiringUnit.CurrentSpeed;
				if (FiringUnit.IsAerospaceUnit)
				{
					newWeapon.Attitude_Pitch = FiringUnit.Attitude_Pitch;
				}
				Contact contact = Contact.Instantiate(activeUnit);
				((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, TargetAltitude);
				contact.Altitude_old = ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - TargetVerticalSpeed_mpersec;
				if (!newWeapon.IsTorpedo)
				{
					contact.AltitudeIsKnown = TargetAltitudeKnown;
				}
				else
				{
					contact.AltitudeIsKnown = true;
				}
				contact.CurrentSpeed = activeUnit.CurrentSpeed;
				contact.SpeedIsKnown = TargetSpeedKnown;
				contact.CurrentHeading = activeUnit.CurrentHeading;
				contact.HeadingIsKnown = TargetHeadingKnown;
				((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
				newWeapon.AI.PrimaryTarget = contact;
				newWeapon.Kinematics.SetActualLoftAltitude(FiringUnit, contact);
				if (ComplexCourse != null)
				{
					foreach (Waypoint theAC in ComplexCourse)
					{
						Weapon_Navigator navigator = newWeapon.Navigator;
						Waypoint[] theArray = navigator.PlottedCourse;
						ArrayExtensions.Add(ref theArray, theAC);
						navigator.PlottedCourse = theArray;
					}
				}
				if ((newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && !newWeapon.Navigator.ComputeTerminalPoint(newWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false).HasValue)
				{
					FeedbackText = "Unable to calculate intercept course";
					return (DLZREsult: DLZResultEnum.Fail_CannotPlotIntercept, FlightTime: 0f);
				}
				float num = newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				if (num <= 0f)
				{
					num = 1f;
				}
				float num2 = newWeapon.Fuel_ReadOnly[0].CurrentQuantity / num - 1f;
				bool flag = false;
				bool flag2 = false;
				if (theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction) && newWeapon.Flags.LevelCruiseFlight && (newWeapon.CruiseAltitude_ASL > 0f || newWeapon.CruiseAltitude_AGL > 0f) && newWeapon.IsASCMwithoutTFcapability())
				{
					flag2 = true;
				}
				float val = Math.Max(newWeapon.CruiseAltitude_ASL, newWeapon.CruiseAltitude_AGL);
				float num3 = num2 * 2f;
				float num4;
				double out_lon = default(double);
				double out_lat = default(double);
				bool flag3 = default(bool);
				for (num4 = 0f; num4 <= num3 && (!(num4 > num2) || (newWeapon.SupportsAttitude_Pitch && newWeapon.Attitude_Pitch < newWeapon.InfiniteGlideAngle)); num4 += 1f)
				{
					if (contact.CurrentSpeed != 0f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
						activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
						activeUnit.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
						activeUnit.Altitude_old = activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) += TargetVerticalSpeed_mpersec;
						((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
						((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
						contact.Altitude_old = ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
					if (ThrottleSetting <= newWeapon.MaxPossibleThrottleSetting)
					{
						newWeapon.SetThrottle(ThrottleSetting);
					}
					else
					{
						newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
					}
					newWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, theScen.Time.AddSeconds(num4), GhostMovement: true);
					Trajectory?.Add(new TrajectoryPoint(newWeapon.get_Longitude(GlobalVariables.ObjectTrue), newWeapon.get_Latitude(GlobalVariables.ObjectTrue), newWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), theScen.Time.AddSeconds(num4)));
					if (!flag2 || (float)Terrain.GetElevation(newWeapon.get_Latitude(GlobalVariables.ObjectTrue), newWeapon.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, theScen) <= Math.Max(val, newWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue)))
					{
						if (num4 == num2 || !(newWeapon.RangeToUnit_Horiz(contact, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < Math.Max(1f, (newWeapon.CurrentSpeed + contact.CurrentSpeed) / 2400f)))
						{
							continue;
						}
						if (!newWeapon.AboutToImpact(contact, 1f, CheckDistranceBasedOnClosureSpeed: true))
						{
							float num5 = Module_Unit.BearingToUnit_Relative(newWeapon, contact);
							int num6;
							if (!(num5 >= 90f))
							{
								num6 = 1;
							}
							else
							{
								if (!(num5 > 270f))
								{
									if (flag)
									{
										DLZResultEnum dLZResultEnum = smethod_1(newWeapon, contact);
										if (dLZResultEnum == DLZResultEnum.Success)
										{
											break;
										}
										return (DLZREsult: dLZResultEnum, FlightTime: 0f);
									}
									continue;
								}
								num6 = 1;
							}
							flag = (byte)num6 != 0;
							continue;
						}
						DLZResultEnum dLZResultEnum2 = smethod_1(newWeapon, contact);
						if (dLZResultEnum2 != DLZResultEnum.Success)
						{
							return (DLZREsult: dLZResultEnum2, FlightTime: 0f);
						}
						double lon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
						double lat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
						Contact contact2;
						double out_lon2 = ((Module_Unit.Unit)(contact2 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
						Contact contact3;
						double out_lat2 = ((Module_Unit.Unit)(contact3 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon2, ref out_lat2, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
						((Module_Unit.Unit)contact3).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
						((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
						newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
						newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
						newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						InterceptPoint = new GeoPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						flag3 = true;
						FlightTime = num4;
						break;
					}
					return (DLZREsult: DLZResultEnum.Fail_LowAltTerrainCrash, FlightTime: num4);
				}
				switch (flag3)
				{
				case false:
					FeedbackText = "FAILURE! Weapon fell short of the target after " + Conversions.ToString(num4) + " seconds, covering " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm. Remaining distance to target is " + Conversions.ToString(Math.Round(Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
					break;
				case true:
					FeedbackText = "SUCCESS! Weapon reached target after " + Conversions.ToString(num4) + " seconds. Distance from launch point is " + Conversions.ToString(Math.Round(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)), 2)) + "nm.";
					break;
				}
				contact = null;
				if (!flag3)
				{
					return (DLZREsult: DLZResultEnum.Fail_OutOfEnergy, FlightTime: 0f);
				}
				return (DLZREsult: DLZResultEnum.Success, FlightTime: FlightTime);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100343", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = (DLZResultEnum.Fail_CodeError, FlightTime);
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			(DLZResultEnum, float) tuple = TargetIsWithinDLZ_BoostCoast(theScen, WeaponID, newWeapon, FiringUnit, AssumeVerticalLaunch, LaunchLongitude, LaunchLatitude, LaunchAltitude, LaunchSpeed, TargetLongitude, TargetLatitude, TargetHeading, TargetHeadingKnown, TargetSpeed, TargetSpeedKnown, TargetAltitude, TargetAltitudeKnown, TargetVerticalSpeed_mpersec, TargetType, ref InterceptPoint, TargetIsTerminalDiving, ref FeedbackText, IsPartOfBurnCalc: false, HumanFeedBackNeeded, InitialHeading, ThrottleSetting, 0, Trajectory, ref FlightTime, theLogger, theResultOutputter, theTargetBehavior, bool_12);
			result = ((tuple.Item1 == DLZResultEnum.Success) ? (tuple.Item1, FlightTime) : (tuple.Item1, 0f));
		}
		return result;
	}

	private int? method_29(ref Contact contact_0, ref Weapon weapon_6)
	{
		int? result = default(int?);
		if (weapon_6 != null)
		{
			if (contact_0 != null && (weapon_6.IsGuidedOrUnguidedGun() & contact_0.isSurfaceOrLandContact))
			{
				Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (gunStrafeGroundTargets.HasValue)
				{
					byte? b = (byte?)gunStrafeGroundTargets;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
					{
						result = 0;
						goto IL_0245;
					}
				}
			}
			if (contact_0 != null)
			{
				if (myUnit.Doctrine.WRA_RelevantWeapon(ref weapon_6))
				{
					weapon_6.FiringParent = myUnit;
					Weapon theW = weapon_6;
					GlobalVariables.BooleanObject EmitterClassificable = null;
					Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref contact_0, theW, ref EmitterClassificable);
					Doctrine._WRA_WeaponTargetType theTargetType2 = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_6, ref contact_0, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
					if (theTargetType2 == Doctrine._WRA_WeaponTargetType.None)
					{
						result = 0;
					}
					else
					{
						Doctrine doctrine = myUnit.Doctrine;
						Scenario parentScen = weapon_6.ParentScen;
						Weapon theWeapon = weapon_6;
						Doctrine._WRA_WeaponTargetType selectedNodeTargetType = theTargetType2;
						int? TargetType_InheritedWeaponQty = null;
						int? TargetType_UnspecifiedWeaponQty = null;
						int? num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
						if (!num.HasValue)
						{
							num = Doctrine.WRA_WeaponQty_SystemDefault(weapon_6, theTargetType2);
							if (!num.HasValue)
							{
								Doctrine._WRA_WeaponTargetType selectedNodeTargetType2 = Doctrine.WRA_DetermineTargetType_Unspecified(ref theTargetType2);
								num = Doctrine.WRA_WeaponQty_SystemDefault(weapon_6, selectedNodeTargetType2);
							}
						}
						TargetType_UnspecifiedWeaponQty = num;
						if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0)) != true)
						{
							Doctrine doctrine2 = myUnit.Doctrine;
							Doctrine doctrine3 = myUnit.Doctrine;
							Scenario parentScen2 = weapon_6.ParentScen;
							int dBID = weapon_6.DBID;
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType3 = theTargetType2;
							float? TargetType_InheritedFiringRange = null;
							float? TargetType_UnspecifiedFiringRange = null;
							TargetType_UnspecifiedFiringRange = doctrine2.WRA_FiringRange_AnyTargetType(doctrine3, parentScen2, dBID, selectedNodeTargetType3, FindInheritedValuesOnly: false, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
							if (((!TargetType_UnspecifiedFiringRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedFiringRange.GetValueOrDefault() == 0f)) == true)
							{
								result = 0;
							}
						}
						else
						{
							result = 0;
						}
					}
				}
			}
			else
			{
				result = -98;
			}
		}
		else
		{
			result = -98;
		}
		goto IL_0245;
		IL_0245:
		return result;
	}

	internal Weapon GetLongestRange_AAWeapon_For_Target_engage(Contact theContact, ref List<int> Except)
	{
		Weapon weapon = null;
		HashSet<int> hashSet = new HashSet<int>();
		Weapon result;
		try
		{
			float maxAirRange = default(float);
			foreach (Mount mount in myUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Operational || mount.MountMagazine.TimeToFire > 0f)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					WeaponRec weaponRec = mountWeapon;
					Weapon weapon_ = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon_.IsSoftKill)
					{
						continue;
					}
					if (weapon_.IsNuke.Value)
					{
						byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						if (((!flag) ?? flag) == true)
						{
							continue;
						}
					}
					if (((weapon_.MaxAirRange > maxAirRange) & !Except.Contains(weapon_.DBID)) && weaponRec.CurrentLoad > 0 && (weapon_.ValidTargets.Aircraft || weapon_.ValidTargets.Missile))
					{
						if (hashSet.Contains(weapon_.DBID))
						{
							continue;
						}
						int? num = method_29(ref theContact, ref weapon_);
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
						{
							hashSet.Add(weapon_.DBID);
							continue;
						}
						weapon = weapon_;
						maxAirRange = weapon_.MaxAirRange;
					}
					weaponRec = null;
				}
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
				foreach (WeaponRec current2 in weapons)
				{
					WeaponRec weaponRec2 = current2;
					if (current2.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
					{
						if (current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
						{
							current2.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
						{
							_ = weaponWeapon;
							Weapon weapon2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
							if (weapon2.IsSoftKill)
							{
								continue;
							}
							if (weapon2.IsNuke.Value)
							{
								byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
								bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if (((!flag) ?? flag) == true)
								{
									continue;
								}
							}
							if (((weapon2.MaxAirRange > maxAirRange) & !Except.Contains(weapon2.DBID)) && weaponRec2.CurrentLoad > 0 && (weapon2.ValidTargets.Aircraft || weapon2.ValidTargets.Missile || weapon2.ValidTargets.Satellite))
							{
								weapon = weapon2;
								maxAirRange = weapon2.MaxAirRange;
							}
						}
					}
					Weapon weapon_2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon_2.IsSoftKill)
					{
						continue;
					}
					if (weapon_2.IsNuke.Value)
					{
						byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						if (((!flag) ?? flag) == true)
						{
							continue;
						}
					}
					if (weapon_2.MaxAirRange > maxAirRange && weaponRec2.CurrentLoad > 0 && (weapon_2.ValidTargets.Aircraft || weapon_2.ValidTargets.Missile || (weapon_2.ValidTargets.Satellite & !Except.Contains(weapon_2.DBID))))
					{
						if (hashSet.Contains(weapon_2.DBID))
						{
							continue;
						}
						int? num = method_29(ref theContact, ref weapon_2);
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true)
						{
							hashSet.Add(weapon_2.DBID);
							continue;
						}
						weapon = weapon_2;
						maxAirRange = weapon_2.MaxAirRange;
					}
					weaponRec2 = null;
				}
			}
			result = weapon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200296", ex2.Message);
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

	internal Weapon GetLongestRange_AAWeapon(Contact theContact)
	{
		Weapon result;
		try
		{
			if (theContact != null || weapon_0 == null || !bool_5)
			{
				PooledSet<int> pooledSet = null;
				float maxAirRange = default(float);
				if (myUnit.Mounts.Count > 0)
				{
					for (int i = myUnit.Mounts.Count - 1; i >= 0; i += -1)
					{
						try
						{
							Mount mount = myUnit.Mounts[i];
							if (mount.Status != PlatformComponent._ComponentStatus.Operational || mount.MountMagazine.TimeToFire > 0f)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								WeaponRec weaponRec = mountWeapon;
								Weapon weapon_ = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon_.IsSoftKill)
								{
									continue;
								}
								if (weapon_.IsNuke.Value)
								{
									byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
									if (((!flag) ?? flag) == true)
									{
										continue;
									}
								}
								if (weapon_.MaxAirRange > maxAirRange && weaponRec.CurrentLoad > 0 && (weapon_.ValidTargets.Aircraft || weapon_.ValidTargets.Missile))
								{
									if (pooledSet == null)
									{
										pooledSet = new PooledSet<int>();
									}
									if (pooledSet.Contains(weapon_.DBID))
									{
										continue;
									}
									int? num = method_29(ref theContact, ref weapon_);
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true)
									{
										pooledSet.Add(weapon_.DBID);
										continue;
									}
									weapon_0 = weapon_;
									maxAirRange = weapon_.MaxAirRange;
								}
								weaponRec = null;
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
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					foreach (WeaponRec current in weapons)
					{
						WeaponRec weaponRec2 = current;
						Weapon weapon_2 = current.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon_2.IsWeaponPallet)
						{
							if (weapon_2.WeaponWeapons.Count == 0)
							{
								weapon_2.InitializeWeaponWeaponsPallet();
							}
							foreach (WeaponRec weaponWeapon in weapon_2.WeaponWeapons)
							{
								_ = weaponWeapon;
								Weapon weapon = current.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon.IsSoftKill)
								{
									continue;
								}
								if (weapon.IsNuke.Value)
								{
									byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
									if (((!flag) ?? flag) == true)
									{
										continue;
									}
								}
								if (weapon.MaxAirRange > maxAirRange && weaponRec2.CurrentLoad > 0 && (weapon.ValidTargets.Aircraft || weapon.ValidTargets.Missile || weapon.ValidTargets.Satellite))
								{
									weapon_0 = weapon;
									maxAirRange = weapon.MaxAirRange;
								}
							}
						}
						if (weapon_2.IsSoftKill)
						{
							continue;
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if (weapon_2.MaxAirRange > maxAirRange && weaponRec2.CurrentLoad > 0 && (weapon_2.ValidTargets.Aircraft || weapon_2.ValidTargets.Missile || weapon_2.ValidTargets.Satellite))
						{
							if (pooledSet == null)
							{
								pooledSet = new PooledSet<int>();
							}
							if (pooledSet.Contains(weapon_2.DBID))
							{
								continue;
							}
							int? num = method_29(ref theContact, ref weapon_2);
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true)
							{
								pooledSet.Add(weapon_2.DBID);
								continue;
							}
							weapon_0 = weapon_2;
							maxAirRange = weapon_2.MaxAirRange;
						}
						weaponRec2 = null;
					}
				}
				bool_5 = true;
				pooledSet?.Dispose();
			}
			result = weapon_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200296", ex2.Message);
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

	internal Weapon GetLongestRange_ASWeapon(Contact theContact = null, bool ExcludeICBMs = false)
	{
		return GetLongestRange_ASWeapon(theContact, ExcludeICBMs);
	}

	internal Weapon GetLongestRange_ASWeapon(bool ExcludeICBMs, Contact theContact = null)
	{
		Weapon result;
		try
		{
			if ((weapon_1 == null && !ExcludeICBMs && !bool_6) || (weapon_2 == null && ExcludeICBMs && !bool_7))
			{
				method_30(ExcludeICBMs, theContact);
			}
			if (!ExcludeICBMs)
			{
				if (theContact != null)
				{
					int? num = method_29(ref theContact, ref weapon_2);
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true)
					{
						method_30(ExcludeICBMs, theContact);
					}
				}
				result = weapon_1;
			}
			else
			{
				if (theContact != null)
				{
					int? num = method_29(ref theContact, ref weapon_2);
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true)
					{
						method_30(ExcludeICBMs, theContact);
					}
				}
				result = weapon_2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200297", ex2.Message);
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

	private void method_30(bool bool_12, Contact contact_0)
	{
		HashSet<int> hashSet = new HashSet<int>();
		List<Mount> list = new List<Mount>(myUnit.Mounts);
		float num2 = default(float);
		foreach (Mount item in list)
		{
			if (item.MountMagazine.TimeToFire > 0f || item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon_ = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
				if (weapon_.IsNuke.Value)
				{
					byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (((!flag) ?? flag) == true)
					{
						continue;
					}
				}
				if ((weapon_.IsSoftKill && !weapon_.IsMobileDecoy) || (bool_12 && weapon_.MaxSurfaceRange > 5400f))
				{
					continue;
				}
				float num = ((!myUnit.IsAircraft || !weapon_.IsUnguidedBallisticWeapon) ? weapon_.MaxSurfaceRange : weapon_.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
				if (!(num > num2) || mountWeapon.CurrentLoad <= 0 || (!weapon_.ValidTargets.SurfaceVessel && !weapon_.ValidTargets.Radar) || hashSet.Contains(weapon_.DBID))
				{
					continue;
				}
				int? num3 = method_29(ref contact_0, ref weapon_);
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : ((bool?)null)) != true)
				{
					if (bool_12)
					{
						this.weapon_2 = weapon_;
					}
					else
					{
						weapon_1 = weapon_;
					}
					num2 = num;
				}
				else
				{
					hashSet.Add(weapon_.DBID);
				}
			}
		}
		if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
		{
			WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
			foreach (WeaponRec current2 in weapons)
			{
				Weapon weapon_2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
				float num4;
				int? num3;
				if (current2.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
				{
					if (current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
					{
						current2.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
					{
						Weapon weapon_3 = weaponWeapon.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon_3.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if ((weapon_3.IsSoftKill && !weapon_3.IsMobileDecoy) || (bool_12 && weapon_3.MaxSurfaceRange > 5400f))
						{
							continue;
						}
						num4 = ((!myUnit.IsAircraft || !weapon_3.IsUnguidedBallisticWeapon) ? weapon_3.MaxSurfaceRange : weapon_3.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
						if (!(num4 > num2) || current2.CurrentLoad <= 0 || (!weapon_3.ValidTargets.SurfaceVessel && !weapon_3.ValidTargets.Radar) || hashSet.Contains(weapon_3.DBID))
						{
							continue;
						}
						num3 = method_29(ref contact_0, ref weapon_3);
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : ((bool?)null)) == true)
						{
							hashSet.Add(weapon_3.DBID);
							continue;
						}
						if (!bool_12)
						{
							weapon_1 = weapon_3;
						}
						else
						{
							this.weapon_2 = weapon_3;
						}
						num2 = num4;
					}
				}
				if (weapon_2.IsNuke.Value)
				{
					byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (((!flag) ?? flag) == true)
					{
						continue;
					}
				}
				if ((weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy) || (bool_12 && weapon_2.MaxSurfaceRange > 5400f))
				{
					continue;
				}
				num4 = ((!myUnit.IsAircraft || !weapon_2.IsUnguidedBallisticWeapon) ? weapon_2.MaxSurfaceRange : weapon_2.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Surface));
				if (!(num4 > num2) || current2.CurrentLoad <= 0 || (!weapon_2.ValidTargets.SurfaceVessel && !weapon_2.ValidTargets.Radar) || hashSet.Contains(weapon_2.DBID))
				{
					continue;
				}
				num3 = method_29(ref contact_0, ref weapon_2);
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
				{
					if (!bool_12)
					{
						weapon_1 = weapon_2;
					}
					else
					{
						this.weapon_2 = weapon_2;
					}
					num2 = num4;
				}
				else
				{
					hashSet.Add(weapon_2.DBID);
				}
			}
		}
		if (!bool_12)
		{
			bool_6 = true;
		}
		else
		{
			bool_7 = true;
		}
	}

	internal Weapon GetLongestRange_AGWeapon(Contact theContact = null, bool ExcludeICBMs = false)
	{
		return GetLongestRange_AGWeapon(ExcludeICBMs, theContact);
	}

	internal Weapon GetLongestRange_AGWeapon(bool ExcludeICBMs, Contact theContact = null)
	{
		Weapon result;
		try
		{
			if ((this.weapon_3 == null && !ExcludeICBMs && !bool_8) || (Information.IsNothing((object)weapon_4) && ExcludeICBMs && !bool_9))
			{
				HashSet<int> hashSet = new HashSet<int>();
				List<Mount> list = new List<Mount>(myUnit.Mounts);
				float num2 = default(float);
				foreach (Mount item in list)
				{
					if (item.MountMagazine.TimeToFire > 0f || item.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						Weapon weapon_ = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if ((weapon_.IsSoftKill && !weapon_.IsMobileDecoy) || (ExcludeICBMs && weapon_.MaxLandRange > 5400f))
						{
							continue;
						}
						float num = ((!myUnit.IsAircraft || !weapon_.IsUnguidedBallisticWeapon) ? weapon_.MaxLandRange : weapon_.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
						if (!(num > num2) || mountWeapon.CurrentLoad <= 0 || (!weapon_.ValidTargets.LandStructure_Hard && !weapon_.ValidTargets.MobileTarget_Hard && !weapon_.ValidTargets.LandStructure_Soft && !weapon_.ValidTargets.Radar && !weapon_.ValidTargets.Runway && !weapon_.ValidTargets.MobileTarget_Soft) || hashSet.Contains(weapon_.DBID))
						{
							continue;
						}
						int? num3 = method_29(ref theContact, ref weapon_);
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) == true)
						{
							hashSet.Add(weapon_.DBID);
							continue;
						}
						if (ExcludeICBMs)
						{
							weapon_4 = weapon_;
						}
						else
						{
							this.weapon_3 = weapon_;
						}
						num2 = num;
					}
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					foreach (WeaponRec current2 in weapons)
					{
						Weapon weapon_2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
						float num4;
						int? num3;
						if (current2.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
						{
							if (current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count == 0)
							{
								current2.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
							}
							foreach (WeaponRec weaponWeapon in current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
							{
								Weapon weapon_3 = weaponWeapon.get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon_3.IsNuke.Value)
								{
									byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
									if (((!flag) ?? flag) == true)
									{
										continue;
									}
								}
								if ((weapon_3.IsSoftKill && !weapon_3.IsMobileDecoy) || (ExcludeICBMs && weapon_3.MaxLandRange > 5400f))
								{
									continue;
								}
								num4 = ((!myUnit.IsAircraft || !weapon_3.IsUnguidedBallisticWeapon) ? weapon_3.MaxLandRange : weapon_3.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
								if (!(num4 > num2) || current2.CurrentLoad <= 0 || (!weapon_3.ValidTargets.LandStructure_Hard && !weapon_3.ValidTargets.MobileTarget_Hard && !weapon_3.ValidTargets.LandStructure_Soft && !weapon_3.ValidTargets.Radar && !weapon_3.ValidTargets.Runway && !weapon_3.ValidTargets.MobileTarget_Soft) || hashSet.Contains(weapon_3.DBID))
								{
									continue;
								}
								num3 = method_29(ref theContact, ref weapon_3);
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
								{
									if (!ExcludeICBMs)
									{
										this.weapon_3 = weapon_3;
									}
									else
									{
										weapon_4 = weapon_3;
									}
									num2 = num4;
								}
								else
								{
									hashSet.Add(weapon_3.DBID);
								}
							}
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if ((weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy) || (ExcludeICBMs && weapon_2.MaxLandRange > 5400f))
						{
							continue;
						}
						num4 = ((!myUnit.IsAircraft || !weapon_2.IsUnguidedBallisticWeapon) ? weapon_2.MaxLandRange : weapon_2.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed));
						if (!(num4 > num2) || current2.CurrentLoad <= 0 || (!weapon_2.ValidTargets.LandStructure_Hard && !weapon_2.ValidTargets.MobileTarget_Hard && !weapon_2.ValidTargets.LandStructure_Soft && !weapon_2.ValidTargets.Radar && !weapon_2.ValidTargets.Runway && !weapon_2.ValidTargets.MobileTarget_Soft) || hashSet.Contains(weapon_2.DBID))
						{
							continue;
						}
						num3 = method_29(ref theContact, ref weapon_2);
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : ((bool?)null)) != true)
						{
							if (ExcludeICBMs)
							{
								weapon_4 = weapon_2;
							}
							else
							{
								this.weapon_3 = weapon_2;
							}
							num2 = num4;
						}
						else
						{
							hashSet.Add(weapon_2.DBID);
						}
					}
				}
				if (!ExcludeICBMs)
				{
					bool_8 = true;
				}
				else
				{
					bool_9 = true;
				}
			}
			result = (ExcludeICBMs ? weapon_4 : this.weapon_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200298", ex2.Message);
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

	internal Weapon GetLongestRange_ASWWeapon(Contact theContact = null)
	{
		Weapon result;
		try
		{
			if (weapon_5 == null && !bool_10)
			{
				HashSet<int> hashSet = new HashSet<int>();
				List<Mount> list = new List<Mount>(myUnit.Mounts);
				float maxSubsurfaceRange = default(float);
				foreach (Mount item in list)
				{
					if (item.MountMagazine.TimeToFire > 0f || item.Status != PlatformComponent._ComponentStatus.Operational)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in item.MountWeapons)
					{
						Weapon weapon_ = mountWeapon.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon_.IsSoftKill && !weapon_.IsMobileDecoy_Sub)
						{
							continue;
						}
						if (weapon_.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if (!(weapon_.MaxSubsurfaceRange > maxSubsurfaceRange) || mountWeapon.CurrentLoad <= 0 || (!weapon_.ValidTargets.Mine && !weapon_.ValidTargets.Submarine && !weapon_.ValidTargets.Torpedo))
						{
							continue;
						}
						weapon_5 = weapon_;
						if (!hashSet.Contains(weapon_.DBID))
						{
							int? num = method_29(ref theContact, ref weapon_);
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
							{
								maxSubsurfaceRange = weapon_.MaxSubsurfaceRange;
							}
							else
							{
								hashSet.Add(weapon_.DBID);
							}
						}
					}
				}
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					foreach (WeaponRec current2 in weapons)
					{
						Weapon weapon_2 = current2.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon_2.IsSoftKill && !weapon_2.IsMobileDecoy_Sub)
						{
							continue;
						}
						if (weapon_2.IsNuke.Value)
						{
							byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
							if (((!flag) ?? flag) == true)
							{
								continue;
							}
						}
						if (weapon_2.MaxSubsurfaceRange > maxSubsurfaceRange && current2.CurrentLoad > 0 && (weapon_2.ValidTargets.Mine || weapon_2.ValidTargets.Submarine || weapon_2.ValidTargets.Torpedo) && !hashSet.Contains(weapon_2.DBID))
						{
							int? num = method_29(ref theContact, ref weapon_2);
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
							{
								hashSet.Add(weapon_2.DBID);
								continue;
							}
							weapon_5 = weapon_2;
							maxSubsurfaceRange = weapon_2.MaxSubsurfaceRange;
						}
					}
				}
				bool_10 = true;
			}
			result = weapon_5;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200299", ex2.Message);
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

	public bool IsGuidingThisWeapon(Weapon theW)
	{
		if (myUnit.ParentScen.GuidedWeaponsInAir.Count == 0)
		{
			return false;
		}
		if (theW.DataLinkParent != null && theW.DataLinkParent == myUnit)
		{
			return true;
		}
		if (theW.Guidance == Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive && theW.FiringParent == myUnit)
		{
			return true;
		}
		if (theW.Guidance == Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active && theW.FiringParent == myUnit)
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.TargetIsWithinIlluminateCoverageArc(theW.AI.PrimaryTarget))
				{
					return true;
				}
			}
		}
		Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
		int num = 0;
		while (true)
		{
			if (num < sensors_Cached2.Length)
			{
				Sensor sensor2 = sensors_Cached2[num];
				if (sensor2.SemiActiveWeaponsGuided.Count > 0 && sensor2.SemiActiveWeaponsGuided.Contains(theW))
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

	public List<Weapon> IsGuidingWeaponsInAir_List()
	{
		List<Weapon> list = new List<Weapon>();
		PooledList<Weapon> guidedWeaponsInAir = myUnit.ParentScen.GuidedWeaponsInAir;
		int count = guidedWeaponsInAir.Count;
		if (count == 0)
		{
			return list;
		}
		Weapon[] array = guidedWeaponsInAir.InternalArray();
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Weapon weapon = array[i];
			if (IsGuidingThisWeapon(weapon))
			{
				list.Add(weapon);
			}
		}
		return list;
	}

	public bool IsGuidingWeaponsInAir()
	{
		if (myUnit.ParentScen.GuidedWeaponsInAir.Count != 0)
		{
			Weapon[] array = myUnit.ParentScen.GuidedWeaponsInAir.ToArray();
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					Weapon theW = array[num];
					if (IsGuidingThisWeapon(theW))
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
		return false;
	}

	public bool IsGuidingWeaponsOntoThisContact(Contact theContact, bool ForceTargetCheck = false)
	{
		bool result;
		try
		{
			int num;
			if (myUnit == null)
			{
				result = false;
			}
			else if (theContact == null)
			{
				result = false;
			}
			else if (theContact.ActualUnit != null)
			{
				if (myUnit.Sensory.IsIlluminatingThisContact(theContact) && !ForceTargetCheck)
				{
					result = true;
				}
				else
				{
					PooledList<Weapon> guidedWeaponsInAir = myUnit.ParentScen.GuidedWeaponsInAir;
					if (guidedWeaponsInAir == null)
					{
						num = 0;
						goto IL_00c0;
					}
					if (guidedWeaponsInAir.Count == 0)
					{
						num = 0;
						goto IL_00c0;
					}
					Weapon[] array = guidedWeaponsInAir.InternalArray();
					int num2 = guidedWeaponsInAir.Count - 1;
					int num3 = 0;
					while (true)
					{
						if (num3 <= num2)
						{
							Weapon weapon = array[num3];
							Contact primaryTarget = weapon.AI.PrimaryTarget;
							if (primaryTarget == null || !primaryTarget.Equals(theContact) || !IsGuidingThisWeapon(weapon))
							{
								num3++;
								continue;
							}
							result = true;
							break;
						}
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_00c0:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100347", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (!Debugger.IsAttached)
			{
				num4 = 0;
			}
			else
			{
				Debugger.Break();
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_31(Weapon weapon_6)
	{
		try
		{
			int num;
			if (weapon_6.IsBallisticMissile)
			{
				num = 0;
			}
			else
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					return;
				}
				num = 0;
			}
			TrajectoryPoint[] array = new TrajectoryPoint[num];
			array = BallisticMissile_Kinematics.EstimatedFutureBallisticPath(weapon_6, weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), weapon_6.AI.PrimaryTarget, weapon_6.ParentScen);
			float weaponNominalSpeed = ((array.Length <= 0) ? ((float)weapon_6.Kinematics.GetMaximumSpeed(weapon_6.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false)) : (Math2.CalcDist(weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), array.Last().Latitude, array.Last().Longitude) / ((float)array.Length / 3600f)));
			weapon_6.Navigator.ComputeTerminalPoint(weaponNominalSpeed, IsAirdroppedTorpedo: false);
			if (weapon_6.Navigator.PlottedCourse.Count() <= 0 || !weapon_6.HasTerminalGuidance)
			{
				return;
			}
			if (weapon_6.AI.PrimaryTarget != null && weapon_6.AI.PrimaryTarget.CurrentSpeed > 0f)
			{
				float num2 = Module_Unit.BearingToPoint_True(weapon_6, weapon_6.Navigator.PlottedCourse[0].Latitude, weapon_6.Navigator.PlottedCourse[0].Longitude);
				Geopoint_Struct thePoint = MathFunctions.Intersection(weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), num2, ((Module_Unit.Unit)weapon_6.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)weapon_6.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), weapon_6.AI.PrimaryTarget.CurrentHeading);
				if (!thePoint.HasZeroCoords && Module_Unit.RangeToPoint_Horiz(myUnit, thePoint) <= weapon_6.get_MaxRangeForThisTarget((ActiveUnit)null, weapon_6.AI.PrimaryTarget, CheckWRA: false, (Doctrine)null, ManualFire: false))
				{
					Contact theTarget = new AimpointContact(thePoint.Latitude, thePoint.Longitude);
					array = BallisticMissile_Kinematics.EstimatedFutureBallisticPath(weapon_6, weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), theTarget, weapon_6.ParentScen);
				}
			}
			if (array.Length <= 0)
			{
				return;
			}
			float num3 = Math2.CalcDist(weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), weapon_6.Navigator.PlottedCourse[0].Latitude, weapon_6.Navigator.PlottedCourse[0].Longitude);
			int num4 = array.Length - 1;
			while (true)
			{
				if (num4 > 0)
				{
					if (!(Math2.CalcDist(weapon_6.get_Latitude((GlobalVariables.BooleanObject)null), weapon_6.get_Longitude((GlobalVariables.BooleanObject)null), array[num4].Latitude, array[num4].Longitude) > num3))
					{
						break;
					}
					num4--;
					continue;
				}
				return;
			}
			weapon_6.Navigator.PlottedCourse[0].Altitude = array[num4].Altitude;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 98365476444241865", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Disarm()
	{
		if (myUnit.Mounts != null)
		{
			myUnit.Mounts.Clear();
		}
		if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
		{
			((Aircraft)myUnit).Loadout.ClearAllWeapons();
		}
		if (myUnit.SharedMagazines != null)
		{
			Magazine[] theArray = myUnit.SharedMagazines;
			ArrayExtensions.Clear(ref theArray);
		}
		if (myUnit.TotalMagazines != null)
		{
			Magazine[] theArray = myUnit.TotalMagazines;
			ArrayExtensions.Clear(ref theArray);
		}
	}

	internal List<Weapon> getSemiActiveGuidedWeaponsInAir()
	{
		List<Weapon> list = new List<Weapon>();
		Weapon[] array = myUnit.ParentScen.GuidedWeaponsInAir.InternalArray();
		foreach (Weapon weapon in array)
		{
			if (weapon != null && weapon.GuidanceHasSemiActivePhase && weapon.AI.PrimaryTarget == myUnit.AI.PrimaryTarget && weapon.FiringParent == myUnit)
			{
				list.Add(weapon);
			}
		}
		return list;
	}

	internal DatalinkedWeaponsInAirByTrackState getDataLinkeGuidedWeaponsInAirThatNeedTrack()
	{
		DatalinkedWeaponsInAirByTrackState result = new DatalinkedWeaponsInAirByTrackState
		{
			thatNeedTrack = new PooledList<Weapon>(),
			thatHaveTrack = new PooledList<Weapon>()
		};
		Weapon[] array = myUnit.ParentScen.GuidedWeaponsInAir.InternalArray();
		foreach (Weapon weapon in array)
		{
			if (weapon != null && weapon.AI.PrimaryTarget != null && !weapon.HasGoneAutonomous && weapon.GuidanceHasDataLink && weapon.DataLinkParent == myUnit)
			{
				if (myUnit.Sensory.CanTrackThisContact_AAWFireControlGrade(weapon.AI.PrimaryTarget))
				{
					result.thatHaveTrack.Add(weapon);
				}
				else
				{
					result.thatNeedTrack.Add(weapon);
				}
			}
		}
		return result;
	}

	protected bool CreateSalvo_PalletizedWeapons(Contact theTarget, Weapon theParentWeapon, Weapon theSubWeapon, int theSubWeaponQty, bool IsManual, string SalvoTag = "")
	{
		int result2;
		if (theParentWeapon != null)
		{
			if (theSubWeapon != null)
			{
				if (theParentWeapon.WeaponWeapons.Count == 0)
				{
					return false;
				}
				int currentLoad = theParentWeapon.WeaponWeapons[0].CurrentLoad;
				int numberOfUnallocatedSubWeaponsInExsitingSalvos = GetNumberOfUnallocatedSubWeaponsInExsitingSalvos(theParentWeapon.DBID, theSubWeapon.DBID);
				int num = myUnit.Weaponry.HowManyOfThisWeapon(theParentWeapon.DBID);
				num -= GetNumberOfAllocatedWeaponsInExistingSalvos(theParentWeapon.DBID);
				if (!IsManual)
				{
					GlobalVariables.BooleanObject EmitterClassificable = null;
					Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theSubWeapon, ref EmitterClassificable);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theSubWeapon, ref theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
					Doctrine doctrine = myUnit.Doctrine;
					Scenario parentScen = myUnit.ParentScen;
					Weapon theWeapon = theSubWeapon;
					int? TargetType_InheritedWeaponQty = null;
					int? TargetType_UnspecifiedWeaponQty = null;
					int? num2 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
					TargetType_UnspecifiedWeaponQty = num2;
					int num3;
					if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty == -99)) != true)
					{
						TargetType_UnspecifiedWeaponQty = num2;
						if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
						{
							num2 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num2, ref myUnit, ref theTarget, ref theSubWeapon);
							num3 = 0;
						}
						else
						{
							num3 = 0;
						}
					}
					else
					{
						num2 = myUnit.Weaponry.HowManyOfThisWeapon(theSubWeapon.DBID) * Doctrine.GetShooterNumber(theSubWeapon, myUnit, theTarget, wRA_WeaponTargetType);
						num3 = 0;
					}
					int num4 = num3;
					foreach (WeaponSalvo weaponSalvo2 in myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos)
					{
						if (Operators.CompareString(weaponSalvo2.Target.ObjectID, theTarget.ObjectID, false) == 0 && weaponSalvo2.int_1 == theSubWeapon.DBID)
						{
							num4 += weaponSalvo2.WpnQuantityAssigned;
						}
					}
					if ((num2.HasValue ? new bool?(num4 >= num2.GetValueOrDefault()) : ((bool?)null)) == true)
					{
						return false;
					}
				}
				bool result = false;
				WeaponSalvo weaponSalvo = null;
				if (numberOfUnallocatedSubWeaponsInExsitingSalvos >= theSubWeaponQty)
				{
					Side side = myUnit.get_UnitSide(SetSideOnly: false);
					Scenario parentScen2 = myUnit.ParentScen;
					int? theQuantity_ToFire = theSubWeaponQty;
					int? theQuantity_Available = theSubWeaponQty;
					ref string objectID = ref myUnit.ObjectID;
					int? TargetType_UnspecifiedWeaponQty = null;
					side.AssignSalvoToTarget(parentScen2, ref theSubWeapon, ref theTarget, theQuantity_ToFire, 0, theQuantity_Available, IsManual, ref objectID, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, DateTime.MinValue);
				}
				else
				{
					int num5 = theSubWeaponQty;
					if (numberOfUnallocatedSubWeaponsInExsitingSalvos > 0)
					{
						Side side2 = myUnit.get_UnitSide(SetSideOnly: false);
						Scenario parentScen3 = myUnit.ParentScen;
						int? theQuantity_ToFire2 = numberOfUnallocatedSubWeaponsInExsitingSalvos;
						int? theQuantity_Available2 = numberOfUnallocatedSubWeaponsInExsitingSalvos;
						ref string objectID2 = ref myUnit.ObjectID;
						int? TargetType_UnspecifiedWeaponQty = null;
						side2.AssignSalvoToTarget(parentScen3, ref theSubWeapon, ref theTarget, theQuantity_ToFire2, 0, theQuantity_Available2, IsManual, ref objectID2, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, DateTime.MinValue);
						num5 -= numberOfUnallocatedSubWeaponsInExsitingSalvos;
					}
					while (num5 > 0 && num > 0)
					{
						if (!IsManual)
						{
							Side side3 = myUnit.get_UnitSide(SetSideOnly: false);
							Scenario parentScen4 = myUnit.ParentScen;
							int? theQuantity_ToFire3 = 1;
							int? theQuantity_Available3 = 1;
							ref string objectID3 = ref myUnit.ObjectID;
							int? TargetType_UnspecifiedWeaponQty = null;
							weaponSalvo = side3.AssignSalvoToTarget(parentScen4, ref theParentWeapon, ref theTarget, theQuantity_ToFire3, 0, theQuantity_Available3, IsManual, ref objectID3, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_IMMEDIATELY, DateTime.MinValue);
						}
						else
						{
							Side side4 = myUnit.get_UnitSide(SetSideOnly: false);
							Scenario parentScen5 = myUnit.ParentScen;
							int? theQuantity_ToFire4 = 1;
							int? theQuantity_Available4 = 1;
							ref string objectID4 = ref myUnit.ObjectID;
							int? TargetType_UnspecifiedWeaponQty = null;
							weaponSalvo = side4.AssignSalvoToTarget(parentScen5, ref theParentWeapon, ref theTarget, theQuantity_ToFire4, 0, theQuantity_Available4, IsManual, ref objectID4, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_AS_MANUAL, DateTime.MinValue);
						}
						if (weaponSalvo != null)
						{
							weaponSalvo.Tag = SalvoTag;
						}
						num--;
						result = true;
						if (currentLoad < num5)
						{
							Side side5 = myUnit.get_UnitSide(SetSideOnly: false);
							Scenario parentScen6 = myUnit.ParentScen;
							int? theQuantity_ToFire5 = currentLoad;
							int? theQuantity_Available5 = currentLoad;
							ref string objectID5 = ref myUnit.ObjectID;
							int? TargetType_UnspecifiedWeaponQty = null;
							side5.AssignSalvoToTarget(parentScen6, ref theSubWeapon, ref theTarget, theQuantity_ToFire5, 0, theQuantity_Available5, IsManual, ref objectID5, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, DateTime.MinValue);
							num5 -= currentLoad;
						}
						else
						{
							Side side6 = myUnit.get_UnitSide(SetSideOnly: false);
							Scenario parentScen7 = myUnit.ParentScen;
							int? theQuantity_ToFire6 = num5;
							int? theQuantity_Available6 = num5;
							ref string objectID6 = ref myUnit.ObjectID;
							int? TargetType_UnspecifiedWeaponQty = null;
							side6.AssignSalvoToTarget(parentScen7, ref theSubWeapon, ref theTarget, theQuantity_ToFire6, 0, theQuantity_Available6, IsManual, ref objectID6, ref TargetType_UnspecifiedWeaponQty, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, DateTime.MinValue);
							num5 = 0;
						}
					}
				}
				return result;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	protected int GetNumberOfAllocatedWeaponsInExistingSalvos(int theWeaponDBID)
	{
		int num = 0;
		List<WeaponSalvo> list = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref myUnit);
		if (list != null && list.Count > 0)
		{
			foreach (WeaponSalvo item in list)
			{
				if (item.int_1 == theWeaponDBID)
				{
					num += item.WpnQuantityAssigned;
				}
			}
		}
		return num;
	}

	public int GetNumberOfUnallocatedSubWeaponsInExsitingSalvos(int int_0, int theSubWeaponDBID)
	{
		int result = 0;
		int num = 0;
		int num2 = 0;
		List<WeaponSalvo> list = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref myUnit);
		if (list != null && list.Count > 0)
		{
			foreach (WeaponSalvo item in list)
			{
				if (item.int_1 == int_0)
				{
					Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon != null)
					{
						if (weapon.WeaponWeapons.Count == 0)
						{
							weapon.InitializeWeaponWeaponsPallet();
						}
						if (weapon.WeaponWeapons.Count > 0)
						{
							num += (item.WpnQuantityAssigned - item.WpnQuantityFired) * weapon.WeaponWeapons[0].CurrentLoad;
						}
					}
				}
				else if (item.int_1 == theSubWeaponDBID && DateTime.Compare(item.ScheduledFireTime, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON) == 0)
				{
					num2 += item.WpnQuantityAssigned;
				}
			}
			result = Math.Max(0, num - num2);
		}
		return result;
	}

	public bool IsFiringWeaponSalvos()
	{
		List<WeaponSalvo> list = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref myUnit);
		if (list.Count > 0)
		{
			foreach (WeaponSalvo item in list)
			{
				if (HowManyOfThisWeapon(item.int_1) <= 0)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0 && shooter.QuantityFired < shooter.QuantityAssigned)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
}
