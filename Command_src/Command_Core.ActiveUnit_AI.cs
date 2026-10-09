using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using CSMaterial;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_AI
{
	internal enum AIMissionState : uint
	{
		None = 0u,
		AircraftHasRefueledThisLegOfFlightPlan = 1u,
		ActiveUnitHasReachedPatrolStationThisSortie = 2u,
		ActiveUnitFerryCycleLegIsOutbound = 4u
	}

	public enum SubmarineDepthPreset : byte
	{
		None,
		Periscope,
		Shallow,
		OverLayer,
		UnderLayer,
		MaxDepth,
		Surface,
		Custom
	}

	public enum AircraftAltitudePreset : byte
	{
		None,
		MinAltitude,
		Low1000,
		Low2000,
		const_4,
		const_5,
		const_6,
		MaxAltitude,
		Custom,
		LoadoutAltitude
	}

	public enum WithdrawReason
	{
		HighDamage,
		LowFuel,
		LowAttackAmmo,
		LowDefenceAmmo
	}

	public sealed class TargetingEntry
	{
		public enum _TargetingBehavior : short
		{
			NotTargeted = -1,
			AutoTargeted,
			ManualWeaponAlloc,
			ManualTargeted,
			AutoSelfDefence
		}

		private _TargetingBehavior _TargetingBehavior_0;

		public Contact Target;

		public double RangeToTarget_Angular;

		public float TimeSinceRangeEvaluation;

		public _TargetingBehavior Behavior
		{
			get
			{
				return _TargetingBehavior_0;
			}
			set
			{
				_TargetingBehavior_0 = value;
			}
		}

		public override string ToString()
		{
			return Target.Name + " " + _TargetingBehavior_0;
		}

		public string ToXML(Side theSide)
		{
			try
			{
				if (Target != null)
				{
					if (stringBuilder_0 != null)
					{
						stringBuilder_0.Clear();
					}
					else
					{
						stringBuilder_0 = new StringBuilder();
					}
					stringBuilder_0.Append("<TE>");
					if (_TargetingBehavior_0 != _TargetingBehavior.AutoTargeted)
					{
						StringBuilder stringBuilder = stringBuilder_0.Append("<BHVR>");
						short targetingBehavior_ = (short)_TargetingBehavior_0;
						stringBuilder.Append(targetingBehavior_.ToString()).Append("</BHVR>");
					}
					if (Target.ActualUnit != null && theSide != null && theSide.Contacts.ContainsKey(Target.ActualUnit.ObjectID))
					{
						stringBuilder_0.Append("<TGT>").Append(Target.ObjectID).Append("</TGT>");
					}
					else
					{
						stringBuilder_0.Append("<TGT>");
						stringBuilder_0.Append(Target.ToXML(null, theSide));
						stringBuilder_0.Append("</TGT>");
					}
					stringBuilder_0.Append("</TE>");
					return stringBuilder_0.ToString();
				}
				return null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100069", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		public static TargetingEntry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			TargetingEntry result;
			try
			{
				TargetingEntry targetingEntry = new TargetingEntry();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode theNode2 = childNode;
					string innerText = theNode2.InnerText;
					switch (theNode2.Name)
					{
					case "Target":
					case "TGT":
						if (innerText.StartsWith("ActivationPoint_"))
						{
							targetingEntry.Target = ActivationPointContact.FromString(theNode2.ChildNodes[0].ChildNodes[0].InnerText);
						}
						else if (innerText.StartsWith("Aimpoint_"))
						{
							targetingEntry.Target = AimpointContact.FromString(theNode2.ChildNodes[0].ChildNodes[0].InnerText);
						}
						else if (theNode2.ChildNodes.Count <= 1)
						{
							targetingEntry.Target = Contact.FromXML(innerText, ref theDictionary);
						}
						else
						{
							targetingEntry.Target = Contact.FromXML(ref theNode2, ref theDictionary);
						}
						break;
					case "Behavior":
					case "BHVR":
						if (!Versioned.IsNumeric((object)innerText))
						{
							targetingEntry._TargetingBehavior_0 = (_TargetingBehavior)Enum.Parse(typeof(_TargetingBehavior), innerText, ignoreCase: true);
						}
						else
						{
							targetingEntry._TargetingBehavior_0 = (_TargetingBehavior)Conversions.ToShort(innerText);
						}
						break;
					}
				}
				result = targetingEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100070", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new TargetingEntry();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		static TargetingEntry()
		{
			Class72.smethod_20();
		}
	}

	protected class PersistentManeuver
	{
		public enum TurnDirection : byte
		{
			Nearest = 0,
			Left = 1,
			Right = 2,
			Port = 1,
			Starboard = 2
		}

		public ActiveUnit MyUnit;

		public Contact TargetContact;

		public float OriginalRange;

		public float DesiredHeading;

		public float DesiredAltitude;

		public ActiveUnit.Throttle DesiredThrottle;

		public TurnDirection Direction;

		public PersistentManeuver()
		{
		}

		public PersistentManeuver(ActiveUnit au, Contact theContact, float theRange)
		{
			MyUnit = au;
			TargetContact = theContact;
			OriginalRange = theRange;
		}

		static PersistentManeuver()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__117-0
	{
		public Aircraft $VB$Local_theTanker;

		public Func<Aircraft, bool> $I0;

		public _Closure$__117-0(_Closure$__117-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theTanker = arg0.$VB$Local_theTanker;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Aircraft theAC)
		{
			return theAC != $VB$Local_theTanker;
		}

		static _Closure$__117-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__187-0
	{
		public List<Contact> $VB$Local_tempList;

		public _Closure$__187-0(_Closure$__187-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_tempList = arg0.$VB$Local_tempList;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5((int, Contact) theContact)
		{
			return $VB$Local_tempList.Contains(theContact.Item2);
		}

		static _Closure$__187-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__189-0
	{
		public ActiveUnit $VB$Local_myUnit;

		public _Closure$__189-0(_Closure$__189-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myUnit = arg0.$VB$Local_myUnit;
			}
		}

		[SpecialName]
		internal double _Lambda$__0(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		[SpecialName]
		internal double _Lambda$__1(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		[SpecialName]
		internal double _Lambda$__2(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		[SpecialName]
		internal double _Lambda$__3(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		[SpecialName]
		internal double _Lambda$__4(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		[SpecialName]
		internal double _Lambda$__5(Contact theC)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular($VB$Local_myUnit, theC);
		}

		static _Closure$__189-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__208-0
	{
		public bool $VB$Local_ShouldDropMines;

		public _Closure$__208-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__208-0(_Closure$__208-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ShouldDropMines = arg0.$VB$Local_ShouldDropMines;
			}
		}

		[SpecialName]
		internal void _Lambda$__1(UnguidedWeapon theMine, ParallelLoopState loopstate)
		{
			if ((double)$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.RangeToUnit_Horiz(theMine) * 1852.0 < (double)$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.get_SafeDistanceAgainstKnownMineType_meters(theMine.Type, UsePathfindingBufferDistance: false) * 1.5)
			{
				$VB$Local_ShouldDropMines = false;
				loopstate.Stop();
			}
			else
			{
				if ($VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo == null)
				{
					return;
				}
				GeoPoint thePoint = new GeoPoint(((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), AssignObjectID: false);
				if ($VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.SpacingSet.HasValue && $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineSet != null && $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineSet == theMine)
				{
					double num = (double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint) * 1852.0;
					double? num2 = $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.SpacingSet;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num < num2.GetValueOrDefault())) == true)
					{
						$VB$Local_ShouldDropMines = false;
						loopstate.Stop();
						return;
					}
				}
				if ($VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.Spacing.HasValue && $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineLocal != null && $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineLocal == theMine)
				{
					double num = (double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint) * 1852.0;
					double? num2 = $VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.Spacing;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num < num2.GetValueOrDefault())) == true)
					{
						$VB$Local_ShouldDropMines = false;
						loopstate.Stop();
						return;
					}
				}
				if (((MiningMission)$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinesLaidInterval.HasValue)
				{
					double num = (double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint) * 1852.0;
					double? num2 = ((MiningMission)$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinesLaidInterval;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num < num2.GetValueOrDefault())) == true)
					{
						$VB$Local_ShouldDropMines = false;
						loopstate.Stop();
					}
				}
			}
		}

		static _Closure$__208-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__208-1
	{
		public Mission $VB$Local_theMission;

		public Weapon $VB$Local_theWeaponCANDIDATE;

		public ActiveUnit_AI $VB$Me;

		public Func<Weapon, bool> $I2;

		public _Closure$__208-1(_Closure$__208-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMission = arg0.$VB$Local_theMission;
				$VB$Local_theWeaponCANDIDATE = arg0.$VB$Local_theWeaponCANDIDATE;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Weapon theW)
		{
			return theW.DBID == $VB$Local_theWeaponCANDIDATE.DBID;
		}

		static _Closure$__208-1()
		{
			Class72.smethod_20();
		}
	}

	internal float ActiveSecondsLeftInDebugModeAI;

	internal const int MAX_STATUS_EVALUATION_DEBUGHISTORY_COUNT = 5;

	internal Queue<(DateTime, List<DecisionChecklist.Result>)> StatusEvaluationDebugHistory;

	internal ActiveUnit myUnit;

	protected Contact _PrimaryTarget;

	protected Contact_Base.ContactType _PrimaryTarget_Type;

	public double PrimaryTarget_LastKnown_Lat;

	public double PrimaryTarget_LastKnown_Lon;

	public float PrimaryTarget_LastKnown_Altitude;

	protected Contact _PrimaryThreat;

	protected HashSet<string> PickupTargets;

	public string EscortTargetID;

	public float TimeToNextTargetsEvaluation;

	public float TimeToNextThreatEvaluation;

	public float? TimeToNextSpeedAdjustmentForToTEvaluation;

	protected bool PrimaryTargetOverrideExists;

	[CompilerGenerated]
	[AccessedThroughProperty("_TargetList")]
	private ObservableDictionary<string, TargetingEntry> observableDictionary_0;

	protected List<Contact> _DoNotTargetList;

	protected List<Contact> _Threats;

	protected GeoPoint _LastKnownTargetLocation;

	protected bool _TerrainFollowing;

	protected float? SnakeAxis;

	protected int MaxSnakeAngle;

	public Geopoint_Struct NavDestination;

	public bool IsEscort;

	public bool HasCaughtUpWithGroup;

	public bool HoldPosition;

	public Geopoint_Struct? RaceTrackPoint;

	protected bool PathBlockCheckInProgress;

	public bool CalculatedDesiredPitchThisPulse;

	internal PooledList<Contact> theContactsVisibleToMe;

	internal PooledList<(Contact, Misc.PostureStance)> ContactStanceCache;

	public List<TargetingEntry> TargetsSortedByRange;

	public bool IsPerformingSpeedAdjustmentToT;

	public float? SpeedAdjustmentToT_OriginalSpeed;

	public float? SpeedAdjustmentToT_OriginalSpeedOverride;

	public ActiveUnit.Throttle? SpeedAdjustmentToT_OriginalThrottle;

	public ActiveUnit_Kinematics.UnitThrottlePreset? SpeedAdjustmentToT_OriginalThrottlePreset;

	public bool LeadMustSlowDownDueToBingo;

	public bool EvaluateTargets_Enabled;

	public bool DeterminePrimaryTarget_Enabled;

	public bool CheckPossibleABMOrASATEngagement;

	public Module_Unit.Unit WeaponThreat;

	public MiningMission.MiningInformation MiningInfo;

	protected PersistentManeuver EvasionManeuver;

	private LockObject lockObject_0;

	private LockObject lockObject_1;

	protected ActiveUnit._ActiveUnitWeaponState Cache_CurrentWeaponState;

	protected uint _Mission_State_Flags;

	protected ActiveUnit _PrimaryPickupTarget;

	private long long_0;

	private Contact[] contact_0;

	private List<TargetingEntry> list_0;

	private Contact contact_1;

	private Contact contact_2;

	private Contact contact_3;

	private Contact contact_4;

	private float? nullable_0;

	private float? nullable_1;

	private float? nullable_2;

	private float? nullable_3;

	public bool CalculatedNearestTargetsThisPulse;

	protected List<Contact> _SelfDefenceTargets;

	private List<TargetingEntry> list_1;

	private List<TargetingEntry> list_2;

	private TargetingEntry targetingEntry_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	private List<(double, double, float, float)> list_3;

	public static float TorpedoEvasionEmergencyRange;

	public static float TorpedoEvasionCloseRange;

	protected virtual ObservableDictionary<string, TargetingEntry> _TargetList
	{
		[CompilerGenerated]
		get
		{
			return observableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, TargetingEntry>.DictionaryChangedEventHandler obj = method_10;
			ObservableDictionary<string, TargetingEntry> observableDictionary = observableDictionary_0;
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

	public GeoPoint LastKnownTargetLocation => _LastKnownTargetLocation;

	public virtual Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				if (myUnit == null)
				{
					return;
				}
				if (value != _PrimaryTarget)
				{
					Contact primaryTarget = _PrimaryTarget;
					if (value != null)
					{
						try
						{
							if (myUnit == null)
							{
								return;
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101190", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (myUnit != null && myUnit.Navigator != null && myUnit.Navigator.HasPathfindingPlottedCourse)
					{
						if (!myUnit.IsAircraft)
						{
							myUnit.Navigator.ClearPathfindingWaypoints();
						}
						else
						{
							Aircraft aircraft = (Aircraft)myUnit;
							bool flag = myUnit.IsRTB || aircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.RTB;
							if (myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
							{
								flag = flag || ActiveUnit.get_IsRTB(myUnit._StatusBefore_WaitForPathfinder);
							}
							if ((myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || !aircraft.Navigator.PathfindingPlottedCourseLeadsToA2ARDestination) && !flag && myUnit.Status != ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
							{
								myUnit.Navigator.ClearPathfindingWaypoints();
							}
						}
					}
					_PrimaryTarget = value;
					if (value != null)
					{
						_PrimaryTarget_Type = value.Type;
					}
					if (primaryTarget != null)
					{
						myUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.Remove(primaryTarget.ObjectID);
					}
					if (value != null)
					{
						myUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.Remove(value.ObjectID);
					}
				}
				if (value != null)
				{
					PrimaryTarget_LastKnown_Lat = ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null);
					PrimaryTarget_LastKnown_Lon = ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null);
					PrimaryTarget_LastKnown_Altitude = ((Module_Unit.Unit)value).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100023", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual Contact PrimaryThreat
	{
		get
		{
			return _PrimaryThreat;
		}
		set
		{
			_PrimaryThreat = value;
		}
	}

	public virtual Contact_Base.ContactType PrimaryTarget_Type
	{
		get
		{
			return _PrimaryTarget_Type;
		}
		set
		{
			_PrimaryTarget_Type = value;
		}
	}

	internal ActiveUnit PrimaryPickupTarget
	{
		get
		{
			return _PrimaryPickupTarget;
		}
		set
		{
			try
			{
				_PrimaryPickupTarget = value;
				if (value == null && myUnit != null && myUnit.Navigator.HasPlottedCourse())
				{
					Waypoint? waypoint = myUnit.Navigator.PlottedCourse.LastOrDefault();
					if (waypoint != null && waypoint.Type == Waypoint.WaypointType.PickupPoint)
					{
						myUnit.Navigator.ClearPlottedCourse();
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 098764534", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual bool ConsidersToBeUnderAttack
	{
		get
		{
			bool result = default(bool);
			PooledList<ActiveUnit> pooledList = default(PooledList<ActiveUnit>);
			try
			{
				if (myUnit != null)
				{
					if (IgnoreThreatIfNoSensor && myUnit.Sensors_Cached.Count() < 1)
					{
						result = false;
					}
					else
					{
						if (_Threats != null)
						{
							foreach (Contact threat in _Threats)
							{
								if (threat?.ActualUnit?.AI?.PrimaryTarget?.ActualUnit != myUnit)
								{
									if (!ContactAppearsToBeInterceptingMe(threat))
									{
										if (!myUnit.IsGroupMember())
										{
											continue;
										}
										try
										{
											pooledList = new PooledList<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values, Pools<ActiveUnit>.Local);
										}
										catch (Exception projectError)
										{
											ProjectData.SetProjectError(projectError);
											pooledList = new PooledList<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values, Pools<ActiveUnit>.Local);
											ProjectData.ClearProjectError();
										}
										foreach (ActiveUnit item in pooledList)
										{
											if (item != null && item.AI.ContactAppearsToBeInterceptingMe(threat))
											{
												long_0 = myUnit.ParentScen.Time.Ticks;
												goto end_IL_0165;
											}
										}
										continue;
									}
									long_0 = myUnit.ParentScen.Time.Ticks;
									break;
								}
								long_0 = myUnit.ParentScen.Time.Ticks;
								break;
								continue;
								end_IL_0165:
								break;
							}
						}
						result = myUnit.ParentScen.Time.Ticks - long_0 < 200000000L;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100774", "");
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
			}
			finally
			{
				pooledList?.Dispose();
			}
			return result;
		}
	}

	public Contact[] Targets_ReadOnly
	{
		get
		{
			PooledList<Contact> pooledList = default(PooledList<Contact>);
			Contact[] result;
			try
			{
				if (contact_0 == null || contact_0.Count() == 0)
				{
					Contact[] array = Array.Empty<Contact>();
					if (_TargetList != null && _TargetList.Count > 0)
					{
						IEnumerator<KeyValuePair<string, TargetingEntry>> enumerator = _TargetList.GetEnumerator();
						while (enumerator.MoveNext())
						{
							TargetingEntry value = enumerator.Current.Value;
							if (value != null && value.Target != null)
							{
								if (pooledList == null)
								{
									pooledList = new PooledList<Contact>(Pools<Contact>.Local);
								}
								pooledList.Add(value.Target);
							}
						}
						array = new Contact[pooledList.Count - 1 + 1];
						Contact[] array2 = pooledList.InternalArray();
						int num = pooledList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							array[i] = array2[i];
						}
					}
					contact_0 = array;
				}
				if (GameGeneral.Beta_PlatformComms && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
				{
					List<Contact> list = new List<Contact>();
					PooledList<Contact> pooledList2 = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
					Contact[] array3 = contact_0;
					foreach (Contact item in array3)
					{
						if (!pooledList2.Contains(item))
						{
							list.Add(item);
						}
					}
					foreach (Contact item2 in list)
					{
						ArrayExtensions.Remove(ref contact_0, item2);
					}
					foreach (Contact item3 in Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory))
					{
						if (!contact_0.Contains(item3))
						{
							ArrayExtensions.Add(ref contact_0, item3);
						}
					}
				}
				result = (Contact[])contact_0.Clone();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100024", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Contact[] array4 = Array.Empty<Contact>();
				contact_0 = array4;
				result = contact_0;
				ProjectData.ClearProjectError();
			}
			finally
			{
				pooledList?.Dispose();
			}
			return result;
		}
	}

	public List<TargetingEntry> SortTargetsByRange_ReadOnly
	{
		get
		{
			List<TargetingEntry> result = default(List<TargetingEntry>);
			try
			{
				if (_TargetList != null)
				{
					list_0 = method_8(_TargetList);
					method_0(list_0);
				}
				result = list_0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101271", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public List<Contact> Threats_ReadOnly
	{
		get
		{
			if (_Threats == null)
			{
				_Threats = new List<Contact>();
			}
			return _Threats;
		}
	}

	public bool IsAssignedToMission
	{
		get
		{
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (myUnit.AssignedTaskPool != null)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea_2nmBuffer
	{
		get
		{
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					return false;
				}
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (myUnit.Navigator.IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea_10nmBuffer
	{
		get
		{
			if (myUnit.ActiveMissionOrPackage() == null)
			{
				return false;
			}
			if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
			{
				return false;
			}
			Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
			if (myUnit.Navigator.IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_10nm_Buffered, ref patrol.PatrolArea_10nm_ChangeCheck, 10, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				return true;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea_NoBuffer
	{
		get
		{
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					return false;
				}
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				ref List<ReferencePoint> patrolArea = ref patrol.PatrolArea;
				List<ReferencePoint> theArea_Buffer = null;
				if (!navigator.IsInsideMissionArea(ref patrolArea, ref theArea_Buffer, ref patrol.PatrolArea_ChangeCheck, 0, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool MayTargetNonAUs
	{
		get
		{
			if (myUnit.IsMCMPlatform_ThisPulse == -1)
			{
				myUnit.Determine_IsMCMPlatform();
			}
			if (myUnit.IsMCMPlatform_ThisPulse == 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsAllowedToRedeploy_Damage
	{
		get
		{
			Doctrine._DamageThreshold? damageThreshold = myUnit.Doctrine.get_RedeployDamageThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			short? num = (short?)damageThreshold;
			int result;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
			{
				result = 1;
			}
			else
			{
				num = (short?)damageThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (short?)damageThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
					{
						if (myUnit.Damage.DamagePercent >= 25f)
						{
							return false;
						}
					}
					else
					{
						num = (short?)damageThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (short?)damageThreshold;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true)
							{
								result = 1;
								goto IL_0232;
							}
							if (myUnit.Damage.DamagePercent >= 75f)
							{
								return false;
							}
						}
						else if (myUnit.Damage.DamagePercent >= 50f)
						{
							return false;
						}
					}
				}
				else if (myUnit.Damage.DamagePercent >= 5f)
				{
					return false;
				}
				result = 1;
			}
			goto IL_0232;
			IL_0232:
			return (byte)result != 0;
		}
	}

	public bool IsAllowedToRedeploy_Fuel
	{
		get
		{
			if (!myUnit.IsFacility)
			{
				Doctrine._FuelQuantityThreshold? fuelQuantityThreshold = myUnit.Doctrine.get_RedeployFuelThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				short? num = (short?)fuelQuantityThreshold;
				int result;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					result = 1;
				}
				else
				{
					num = (short?)fuelQuantityThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
					{
						num = (short?)fuelQuantityThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
						{
							double TotalCurrent = default(double);
							double TotalMax = default(double);
							if ((int)Math.Round(myUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0) < 25)
							{
								return false;
							}
						}
						else
						{
							num = (short?)fuelQuantityThreshold;
							double TotalCurrent4 = default(double);
							double TotalMax4 = default(double);
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
							{
								num = (short?)fuelQuantityThreshold;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
								{
									double TotalCurrent2 = default(double);
									double TotalMax2 = default(double);
									if ((int)Math.Round(myUnit.FuelPercent(ref TotalCurrent2, ref TotalMax2, MissionFuel: false) * 100.0) < 75)
									{
										return false;
									}
								}
								else
								{
									num = (short?)fuelQuantityThreshold;
									double TotalCurrent3 = default(double);
									double TotalMax3 = default(double);
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5)) == true && (int)Math.Round(myUnit.FuelPercent(ref TotalCurrent3, ref TotalMax3, MissionFuel: false) * 100.0) < 100)
									{
										return false;
									}
								}
							}
							else if ((int)Math.Round(myUnit.FuelPercent(ref TotalCurrent4, ref TotalMax4, MissionFuel: false) * 100.0) < 50)
							{
								return false;
							}
						}
					}
					else if (myUnit.IsBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						return false;
					}
					result = 1;
				}
				return (byte)result != 0;
			}
			return true;
		}
	}

	public bool IsAllowedToRedeploy_AttackWeapon
	{
		get
		{
			bool result;
			try
			{
				Doctrine._WeaponQuantityThreshold? weaponQuantityThreshold = myUnit.Doctrine.get_RedeployAttackThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				short? num = (short?)weaponQuantityThreshold;
				int num2;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					num2 = 1;
					goto IL_0532;
				}
				num = (short?)weaponQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
				{
					Weapon primaryAttackWeapon_Default = myUnit.Weaponry.PrimaryAttackWeapon_Default;
					if (Information.IsNothing((object)primaryAttackWeapon_Default))
					{
						num2 = 1;
						goto IL_0532;
					}
					if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default.DBID, IncludeNonOperationalMountsAndMags: false) != 0)
					{
						num2 = 1;
						goto IL_0532;
					}
					result = false;
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (short?)weaponQuantityThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) == true)
						{
							Weapon primaryAttackWeapon_Default2 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
							if (Information.IsNothing((object)primaryAttackWeapon_Default2))
							{
								num2 = 1;
								goto IL_0532;
							}
							int num3 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default2.DBID, IncludeNonOperationalMountsAndMags: false);
							int num4 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default2.DBID);
							int num5;
							if (num3 != 0)
							{
								if (!((double)num3 / (double)num4 < 0.5))
								{
									goto IL_0531;
								}
								num5 = 0;
							}
							else
							{
								num5 = 0;
							}
							result = (byte)num5 != 0;
						}
						else
						{
							num = (short?)weaponQuantityThreshold;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
							{
								Weapon primaryAttackWeapon_Default3 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
								if (Information.IsNothing((object)primaryAttackWeapon_Default3))
								{
									goto IL_0531;
								}
								int num6 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default3.DBID, IncludeNonOperationalMountsAndMags: false);
								int num7 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default3.DBID);
								int num8;
								if (num6 != 0)
								{
									if (!((double)num6 / (double)num7 < 0.75))
									{
										goto IL_0531;
									}
									num8 = 0;
								}
								else
								{
									num8 = 0;
								}
								result = (byte)num8 != 0;
							}
							else
							{
								num = (short?)weaponQuantityThreshold;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5)) != true)
								{
									num = (short?)weaponQuantityThreshold;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)) != true)
									{
										num2 = 1;
										goto IL_0532;
									}
									List<WeaponRec> list = myUnit.Weaponry.AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
									foreach (WeaponRec item in list)
									{
										if (item.DefaultLoad == 0)
										{
											continue;
										}
										Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
										if (!weapon.IsASuW_Land && !weapon.IsASuW_Naval)
										{
											continue;
										}
										int num9 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false);
										int num10 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(weapon.DBID);
										int num11;
										if (num9 != 0)
										{
											if (num9 == num10)
											{
												continue;
											}
											num11 = 0;
										}
										else
										{
											num11 = 0;
										}
										result = (byte)num11 != 0;
										goto end_IL_0001;
									}
									goto IL_0531;
								}
								Weapon primaryAttackWeapon_Default4 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
								if (Information.IsNothing((object)primaryAttackWeapon_Default4))
								{
									goto IL_0531;
								}
								int num12 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default4.DBID, IncludeNonOperationalMountsAndMags: false);
								int num13 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default4.DBID);
								int num14;
								if (num12 != 0)
								{
									if (num12 == num13)
									{
										goto IL_0531;
									}
									num14 = 0;
								}
								else
								{
									num14 = 0;
								}
								result = (byte)num14 != 0;
							}
						}
					}
					else
					{
						Weapon primaryAttackWeapon_Default5 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
						if (Information.IsNothing((object)primaryAttackWeapon_Default5))
						{
							goto IL_0531;
						}
						int num15 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default5.DBID, IncludeNonOperationalMountsAndMags: false);
						int num16 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default5.DBID);
						int num17;
						if (num15 != 0)
						{
							if (!((double)num15 / (double)num16 < 0.25))
							{
								goto IL_0531;
							}
							num17 = 0;
						}
						else
						{
							num17 = 0;
						}
						result = (byte)num17 != 0;
					}
				}
				goto end_IL_0001;
				IL_0532:
				result = (byte)num2 != 0;
				goto end_IL_0001;
				IL_0531:
				num2 = 1;
				goto IL_0532;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101356", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num18;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num18 = 0;
				}
				else
				{
					num18 = 0;
				}
				result = (byte)num18 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsAllowedToRedeploy_DefenceWeapon
	{
		get
		{
			bool result;
			try
			{
				Doctrine._WeaponQuantityThreshold? weaponQuantityThreshold = myUnit.Doctrine.get_RedeployDefenceThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				short? num = (short?)weaponQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					goto IL_0533;
				}
				num = (short?)weaponQuantityThreshold;
				int num2;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (short?)weaponQuantityThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (short?)weaponQuantityThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (short?)weaponQuantityThreshold;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true)
							{
								num = (short?)weaponQuantityThreshold;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5)) != true)
								{
									num = (short?)weaponQuantityThreshold;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)) != true)
									{
										num2 = 1;
										goto IL_0534;
									}
									List<WeaponRec> list = myUnit.Weaponry.AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
									foreach (WeaponRec item in list)
									{
										if (item.DefaultLoad == 0)
										{
											continue;
										}
										Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
										if (!weapon.IsAAWCapable && !weapon.IsASW)
										{
											continue;
										}
										int num3 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false);
										int num4 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(weapon.DBID);
										int num5;
										if (num3 != 0)
										{
											if (num3 == num4)
											{
												continue;
											}
											num5 = 0;
										}
										else
										{
											num5 = 0;
										}
										result = (byte)num5 != 0;
										goto end_IL_0001;
									}
									goto IL_0533;
								}
								Weapon primaryDefenceWeapon_Actual = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
								if (Information.IsNothing((object)primaryDefenceWeapon_Actual))
								{
									num2 = 1;
									goto IL_0534;
								}
								int num6 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual.DBID, IncludeNonOperationalMountsAndMags: false);
								int num7 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual.DBID);
								int num8;
								if (num6 != 0)
								{
									if (num6 == num7)
									{
										goto IL_0533;
									}
									num8 = 0;
								}
								else
								{
									num8 = 0;
								}
								result = (byte)num8 != 0;
							}
							else
							{
								Weapon primaryDefenceWeapon_Actual2 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
								if (Information.IsNothing((object)primaryDefenceWeapon_Actual2))
								{
									goto IL_0533;
								}
								int num9 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual2.DBID, IncludeNonOperationalMountsAndMags: false);
								int num10 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual2.DBID);
								int num11;
								if (num9 != 0)
								{
									if (!((double)num9 / (double)num10 < 0.75))
									{
										goto IL_0533;
									}
									num11 = 0;
								}
								else
								{
									num11 = 0;
								}
								result = (byte)num11 != 0;
							}
						}
						else
						{
							Weapon primaryDefenceWeapon_Actual3 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
							if (Information.IsNothing((object)primaryDefenceWeapon_Actual3))
							{
								goto IL_0533;
							}
							int num12 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual3.DBID, IncludeNonOperationalMountsAndMags: false);
							int num13 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual3.DBID);
							int num14;
							if (num12 != 0)
							{
								if (!((double)num12 / (double)num13 < 0.5))
								{
									goto IL_0533;
								}
								num14 = 0;
							}
							else
							{
								num14 = 0;
							}
							result = (byte)num14 != 0;
						}
					}
					else
					{
						Weapon primaryDefenceWeapon_Actual4 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
						if (Information.IsNothing((object)primaryDefenceWeapon_Actual4))
						{
							goto IL_0533;
						}
						int num15 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual4.DBID, IncludeNonOperationalMountsAndMags: false);
						int num16 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual4.DBID);
						int num17;
						if (num15 == 0)
						{
							num17 = 0;
						}
						else
						{
							if (!((double)num15 / (double)num16 < 0.25))
							{
								goto IL_0533;
							}
							num17 = 0;
						}
						result = (byte)num17 != 0;
					}
				}
				else
				{
					Weapon primaryDefenceWeapon_Actual5 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
					if (Information.IsNothing((object)primaryDefenceWeapon_Actual5))
					{
						num2 = 1;
						goto IL_0534;
					}
					if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual5.DBID, IncludeNonOperationalMountsAndMags: false) != 0)
					{
						goto IL_0533;
					}
					result = false;
				}
				goto end_IL_0001;
				IL_0534:
				result = (byte)num2 != 0;
				goto end_IL_0001;
				IL_0533:
				num2 = 1;
				goto IL_0534;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101357", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num18;
				if (!Debugger.IsAttached)
				{
					num18 = 0;
				}
				else
				{
					Debugger.Break();
					num18 = 0;
				}
				result = (byte)num18 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsAllowedToRedeploy_AllChecks
	{
		get
		{
			if (IsAllowedToRedeploy_Damage)
			{
				if (IsAllowedToRedeploy_Fuel)
				{
					if (!IsAllowedToRedeploy_AttackWeapon)
					{
						return false;
					}
					if (IsAllowedToRedeploy_DefenceWeapon)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	static ActiveUnit_AI()
	{
		Class72.smethod_20();
		TorpedoEvasionEmergencyRange = 2.5f;
		TorpedoEvasionCloseRange = 5f;
	}

	internal bool GetMissionStateFlag(uint theFlag)
	{
		return (long)(_Mission_State_Flags & theFlag) > 0L;
	}

	internal void SetMissionStateFlag(uint theFlag, bool theValue)
	{
		if (!theValue)
		{
			_Mission_State_Flags &= ~theFlag;
		}
		else
		{
			_Mission_State_Flags |= theFlag;
		}
	}

	internal void ClearMissionStateFlags()
	{
		_Mission_State_Flags = 0u;
	}

	~ActiveUnit_AI()
	{
		if (theContactsVisibleToMe != null)
		{
			theContactsVisibleToMe.Dispose();
		}
		if (ContactStanceCache != null)
		{
			ContactStanceCache.Dispose();
		}
		base.Finalize();
	}

	public void AddTargetList_Threadsafe(string ObjectID, TargetingEntry Entry)
	{
		lock (lockObject_0)
		{
			if (!_TargetList.ContainsKey(ObjectID))
			{
				if (_TargetList == null)
				{
					_TargetList = new ObservableDictionary<string, TargetingEntry>();
				}
				_TargetList.Add(ObjectID, Entry);
			}
		}
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (PrimaryTarget != null)
			{
				theWriter.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
			}
			XmlWriter obj = theWriter;
			int primaryTarget_Type = (int)_PrimaryTarget_Type;
			obj.WriteElementString("PrimaryTarget_Type", primaryTarget_Type.ToString());
			if (_PrimaryThreat != null)
			{
				theWriter.WriteElementString("PrimaryThreat", _PrimaryThreat.ObjectID);
			}
			if (PrimaryTarget_LastKnown_Lat != 0.0)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Lat", XmlConvert.ToString(PrimaryTarget_LastKnown_Lat));
			}
			if (PrimaryTarget_LastKnown_Lon != 0.0)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Lon", XmlConvert.ToString(PrimaryTarget_LastKnown_Lon));
			}
			if (PrimaryTarget_LastKnown_Altitude != 0f)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Alt", XmlConvert.ToString(PrimaryTarget_LastKnown_Altitude));
			}
			if (TimeToNextTargetsEvaluation != 0f)
			{
				theWriter.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			}
			theWriter.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			theWriter.WriteElementString("HPos", HoldPosition.ToString());
			if (!EvaluateTargets_Enabled)
			{
				theWriter.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				theWriter.WriteElementString("DPT_E", "False");
			}
			if (IsEscort)
			{
				theWriter.WriteElementString("IE", IsEscort.ToString());
			}
			if (_LastKnownTargetLocation != null)
			{
				theWriter.WriteStartElement("LKTL");
				theWriter.WriteRaw(_LastKnownTargetLocation.ToXML(ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (PrimaryPickupTarget != null)
			{
				theWriter.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
			if (_TargetList != null && _TargetList.Count > 0)
			{
				theWriter.WriteStartElement("TargetList");
				try
				{
					foreach (TargetingEntry value in _TargetList.Values)
					{
						theWriter.WriteRaw(value.ToXML(myUnit.get_UnitSide(SetSideOnly: false)));
						theWriter.Flush();
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
					theWriter.WriteEndElement();
				}
			}
			if (_Threats != null && _Threats.Count > 0)
			{
				theWriter.WriteStartElement("Threats");
				List<Contact> list = new List<Contact>(_Threats);
				foreach (Contact item in list)
				{
					if (item != null)
					{
						theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized, myUnit.get_UnitSide(SetSideOnly: false)));
						theWriter.Flush();
					}
				}
				theWriter.WriteEndElement();
			}
			if (SnakeAxis.HasValue)
			{
				theWriter.WriteElementString("SnakeAxis", Conversions.ToString(SnakeAxis.Value));
			}
			if (MiningInfo != null)
			{
				MiningInfo.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			}
			if ((long)_Mission_State_Flags > 0L)
			{
				theWriter.WriteElementString("MSF", _Mission_State_Flags.ToString());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100021", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theAU)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		try
		{
			ActiveUnit_AI activeUnit_AI = new ActiveUnit_AI();
			activeUnit_AI.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "SnakeAxis":
					activeUnit_AI.SnakeAxis = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "PrimaryTarget":
					activeUnit_AI._PrimaryTarget = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "MSF":
					uint.TryParse(theNode2.InnerText, out activeUnit_AI._Mission_State_Flags);
					break;
				case "Threats":
					if (activeUnit_AI._Threats == null)
					{
						activeUnit_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Contact item = Contact.FromXML(ref theNode3, ref theDictionary);
						activeUnit_AI._Threats.Add(item);
					}
					break;
				case "PrimaryThreat":
					activeUnit_AI._PrimaryThreat = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "IE":
					activeUnit_AI.IsEscort = true;
					break;
				case "LKTL":
					activeUnit_AI._LastKnownTargetLocation = GeoPoint.FromXML(ref theNode2, ref theDictionary);
					break;
				case "DPT_E":
					activeUnit_AI.DeterminePrimaryTarget_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "TTNPTE":
					activeUnit_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "FerryCycleLegIsOutbound":
				case "FCLIO":
					activeUnit_AI.SetMissionStateFlag(4u, Misc.ParseBool(theNode2.InnerText));
					break;
				case "PrimaryTarget_LastKnown_Lat":
					FastDoubleParse.FastTryParseDouble(theNode2.InnerText, out activeUnit_AI.PrimaryTarget_LastKnown_Lat);
					break;
				case "PrimaryTarget_LastKnown_Lon":
					FastDoubleParse.FastTryParseDouble(theNode2.InnerText, out activeUnit_AI.PrimaryTarget_LastKnown_Lon);
					break;
				case "PrimaryPickupTarget":
					activeUnit_AI._PrimaryPickupTarget = ActiveUnit.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "TargetList":
					activeUnit_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode4, ref theDictionary);
						activeUnit_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
					}
					break;
				case "ET_E":
					activeUnit_AI.EvaluateTargets_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PTOE":
				case "PrimaryTargetOverrideExists":
					activeUnit_AI.PrimaryTargetOverrideExists = Misc.ParseBool(theNode2.InnerText);
					break;
				case "HP":
				case "HPos":
					activeUnit_AI.HoldPosition = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IgnorePlottedCourse":
				case "IPC":
				{
					bool num = Misc.ParseBool(theNode2.InnerText);
					if (!Information.IsNothing((object)theAU.Doctrine))
					{
						theAU.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)(Doctrine._UseIgnorePlottedCourse)(0u - (Misc.ParseBool(theNode2.InnerText) ? 1u : 0u)));
					}
					if (num && !Information.IsNothing((object)theAU.ActiveMissionOrPackage()))
					{
						Mission mission = theAU.ActiveMissionOrPackage();
						if (mission.MissionClass == Mission._MissionClass.Patrol)
						{
							mission.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
						}
					}
					break;
				}
				case "MiningInformation":
					activeUnit_AI.MiningInfo = MiningMission.MiningInformation.FromXML(ref theNode2, ref theDictionary, activeUnit_AI);
					break;
				case "PrimaryTarget_LastKnown_Alt":
					activeUnit_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(theNode2.InnerText);
					break;
				case "PrimaryTarget_Type":
					if (!Versioned.IsNumeric((object)theNode2.InnerText))
					{
						activeUnit_AI._PrimaryTarget_Type = (Contact_Base.ContactType)Enum.Parse(typeof(Contact_Base.ContactType), theNode2.InnerText, ignoreCase: true);
					}
					else
					{
						activeUnit_AI._PrimaryTarget_Type = (Contact_Base.ContactType)Conversions.ToByte(theNode2.InnerText);
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100022", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ActiveUnit_AI()
	{
		ActiveSecondsLeftInDebugModeAI = 0f;
		_DoNotTargetList = new List<Contact>();
		NavDestination = default(Geopoint_Struct);
		HasCaughtUpWithGroup = false;
		theContactsVisibleToMe = new PooledList<Contact>();
		LeadMustSlowDownDueToBingo = false;
		EvaluateTargets_Enabled = true;
		DeterminePrimaryTarget_Enabled = true;
		CheckPossibleABMOrASATEngagement = false;
		WeaponThreat = null;
		MiningInfo = null;
		EvasionManeuver = null;
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		long_0 = 0L;
		CalculatedNearestTargetsThisPulse = false;
		_SelfDefenceTargets = new List<Contact>();
		list_1 = new List<TargetingEntry>();
		list_2 = new List<TargetingEntry>();
		list_3 = new List<(double, double, float, float)>();
	}

	public Contact GetContactForThisUnit(Module_Unit.Unit u)
	{
		if (u == null)
		{
			return null;
		}
		if (!u.IsContact())
		{
			if (u.IsActiveUnit)
			{
				Contact value;
				if (myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					if (myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(u.ObjectID, out value))
					{
						return value;
					}
				}
				else if (myUnit.Sensory.Contacts_Local_ReadOnly.TryGetValue(u.ObjectID, out value))
				{
					return value;
				}
			}
			return null;
		}
		return (Contact)u;
	}

	public bool IsTargetingThisContact(Contact theC)
	{
		if (PrimaryTarget != null && PrimaryTarget == theC)
		{
			return true;
		}
		return _TargetList != null && _TargetList.ContainsKey(theC.ObjectID);
	}

	public void EvaluateMissionStatus(Scenario TheScen)
	{
		Mission mission = myUnit.ActiveMissionOrPackage();
		if (mission == null)
		{
			if (myUnit.AssignedMissionsQueue.Count <= 0)
			{
				return;
			}
			int num = int.MaxValue;
			Mission mission2 = null;
			foreach (KeyValuePair<Mission, Mission> item in myUnit.AssignedMissionsQueue)
			{
				if (item.Key.PriorityWeight < num && item.Value.get_Phase(TheScen, myUnit.get_UnitSide(SetSideOnly: false)) == MissionPhase.Active)
				{
					mission2 = item.Key;
					num = item.Key.PriorityWeight;
				}
			}
			if (mission == null || (mission != null && mission2 != null && mission2.PriorityWeight < mission.PriorityWeight))
			{
				ActiveUnit activeUnit = myUnit;
				Mission value = mission2;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(value, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
				if (mission2 != null)
				{
					myUnit.AssignedMissionsQueue.Remove(mission2);
				}
			}
		}
		else
		{
			if (mission.get_Phase(TheScen, myUnit.get_UnitSide(SetSideOnly: false)) != MissionPhase.Completed || myUnit.AssignedMissionsQueue.Count <= 0)
			{
				return;
			}
			Dictionary<int, List<Mission>> dictionary = new Dictionary<int, List<Mission>>();
			int num2 = int.MaxValue;
			Mission mission3 = mission;
			foreach (KeyValuePair<Mission, Mission> item2 in myUnit.AssignedMissionsQueue)
			{
				if (!dictionary.ContainsKey(item2.Key.PriorityWeight))
				{
					dictionary.Add(item2.Key.PriorityWeight, new List<Mission>());
				}
				dictionary[item2.Key.PriorityWeight].Add(item2.Key);
				if (item2.Key.PriorityWeight < num2 && (item2.Value.get_Phase(TheScen, myUnit.get_UnitSide(SetSideOnly: false)) == MissionPhase.Active || item2.Value.get_Phase(TheScen, myUnit.get_UnitSide(SetSideOnly: false)) == MissionPhase.Completed))
				{
					mission3 = item2.Key;
					num2 = item2.Key.PriorityWeight;
				}
			}
			if (mission == null || (mission != null && mission3 != null && mission3.PriorityWeight < mission.PriorityWeight))
			{
				List<Mission> list = dictionary[mission3.PriorityWeight];
				Mission mission4 = list.ElementAt(0);
				if (list.Count > 1)
				{
					mission4 = list.ElementAt(GlobalSingleton.GetInstance().Random.Next(0, list.Count));
				}
				ActiveUnit activeUnit2 = myUnit;
				Mission value2 = mission4;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit2.Set_AssignedMissionOrPackage(value2, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
				if (mission3 != null)
				{
					myUnit.UnassignMissionInQueue(mission3);
				}
				myUnit.AssignMissionInQueue(mission);
			}
		}
	}

	internal virtual void DeterminePrimaryPickupTarget()
	{
		try
		{
			if (_PrimaryPickupTarget != null)
			{
				if (!_PrimaryPickupTarget.IsMorituri && _PrimaryPickupTarget.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						List<ActiveUnit> list = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList();
						foreach (ActiveUnit item in list)
						{
							if (item != myUnit && item.AI.PrimaryPickupTarget == _PrimaryPickupTarget)
							{
								PrimaryPickupTarget = null;
								break;
							}
						}
					}
				}
				else
				{
					PrimaryPickupTarget = null;
				}
			}
			if (_PrimaryPickupTarget != null)
			{
				return;
			}
			if (PickupTargets != null && PickupTargets.Count != 0)
			{
				bool flag = myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null && (((Aircraft)myUnit).Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || ((Aircraft)myUnit).Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue);
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				int num = PickupTargets.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = PickupTargets.ElementAtOrDefault(i);
					if (!string.IsNullOrEmpty(text) && text.StartsWith("ActiveUnit_"))
					{
						string text2 = text.Split(new char[1] { '_' })[1];
						if (myUnit.ParentScen.ActiveUnits.ContainsKey(text2))
						{
							ActiveUnit activeUnit = myUnit.ParentScen.ActiveUnits[text2];
							if (!activeUnit.IsMorituri && activeUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && !myUnit.ObjectID.Equals(text2))
							{
								bool flag2 = false;
								if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
								{
									List<ActiveUnit> list3 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList();
									foreach (ActiveUnit item2 in list3)
									{
										if (item2 != myUnit && item2.AI.PrimaryPickupTarget == activeUnit)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (flag2)
								{
									PickupTargets.Remove(text);
									if (activeUnit == PrimaryPickupTarget)
									{
										PrimaryPickupTarget = null;
									}
									continue;
								}
								if (activeUnit.EligibleForSAR && flag)
								{
									list2.Add(activeUnit);
									continue;
								}
								if (myUnit.IsAircraft && (myUnit.Kinematics.GetMinimumAltitude() > 150f || myUnit.MinPossibleThrottleSetting != ActiveUnit.Throttle.FullStop))
								{
									string text3 = " (Reason: Can't satisfy pickup requirements for min speed (stop) or altitude (150m))";
									myUnit.AddMessage(myUnit.Name + " is aborting pickup from " + activeUnit.Name + text3, myUnit.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
									PickupTargets.Remove(text);
									if (activeUnit == PrimaryPickupTarget)
									{
										PrimaryPickupTarget = null;
									}
									continue;
								}
								if (activeUnit.IsAircraft && (activeUnit.CurrentAltitude_AGL > 150f || activeUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop))
								{
									string text4 = " (Reason: Target does not meet pickup requirements for min speed (stop) or altitude (150m))";
									myUnit.AddMessage(myUnit.Name + " is aborting pickup from " + activeUnit.Name + text4, myUnit.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
									PickupTargets.Remove(text);
									if (activeUnit == PrimaryPickupTarget)
									{
										PrimaryPickupTarget = null;
									}
									continue;
								}
								List<CargoManifestItem> list4 = Cargo.GenerateCargoManifest(activeUnit);
								if (list4.Count != 0)
								{
									if (ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)activeUnit, (ICargoHost)myUnit, list4).Count == 0)
									{
										myUnit.AddMessage(myUnit.Name + " is aborting pickup from " + activeUnit.Name + " (Reason: Cannot transfer any of the available cargo items)", myUnit.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
										PickupTargets.Remove(text);
										if (activeUnit == PrimaryPickupTarget)
										{
											PrimaryPickupTarget = null;
										}
									}
									else
									{
										list2.Add(activeUnit);
									}
									continue;
								}
								string text5 = " (Reason: The transfer source does not have any cargo item to retrieve)";
								if (flag)
								{
									text5 = " (Reason: The transfer source is not eligible for C/SAR)";
								}
								myUnit.AddMessage(myUnit.Name + " is aborting pickup from " + activeUnit.Name + text5, myUnit.Name + " aborting pickup", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								PickupTargets.Remove(text);
								if (activeUnit == PrimaryPickupTarget)
								{
									PrimaryPickupTarget = null;
								}
							}
							else
							{
								PickupTargets.Remove(text);
								if (activeUnit == PrimaryPickupTarget)
								{
									PrimaryPickupTarget = null;
								}
							}
						}
						else
						{
							PickupTargets.Remove(text);
							if (!Information.IsNothing((object)PrimaryPickupTarget) && PrimaryPickupTarget.IsActiveUnit && Operators.CompareString(PrimaryPickupTarget.ObjectID, text2, false) == 0)
							{
								PrimaryPickupTarget = null;
							}
						}
					}
					else
					{
						PickupTargets.Remove(text);
					}
				}
				switch (list2.Count)
				{
				case 0:
					PrimaryPickupTarget = null;
					return;
				case 1:
					PrimaryPickupTarget = list2[0];
					return;
				}
				PrimaryPickupTarget = list2.OrderBy([SpecialName] (ActiveUnit theC) => myUnit.RangeToUnit_Horiz(theC)).ElementAtOrDefault(0);
			}
			else
			{
				PrimaryPickupTarget = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 56785678599", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_0(IList<TargetingEntry> ilist_0)
	{
		CalculatedNearestTargetsThisPulse = true;
		contact_1 = null;
		contact_2 = null;
		contact_3 = null;
		contact_4 = null;
		nullable_0 = null;
		nullable_1 = null;
		nullable_2 = null;
		nullable_3 = null;
		foreach (TargetingEntry item in ilist_0)
		{
			if (item.Target != null)
			{
				if (item.Target.IsAir_Missile_Orbital_Contact && contact_1 == null)
				{
					contact_1 = item.Target;
				}
				if (item.Target.IsShipContact && contact_2 == null)
				{
					contact_2 = item.Target;
				}
				if (item.Target.isSurfaceOrLandContact && contact_2 == null)
				{
					contact_2 = item.Target;
				}
				if (item.Target.IsSubmergedContact && contact_3 == null)
				{
					contact_3 = item.Target;
				}
				if (item.Target.IsLandContact && contact_4 == null)
				{
					contact_4 = item.Target;
				}
			}
		}
		if (contact_1 != null)
		{
			nullable_0 = myUnit.RangeToUnit_Horiz_Alt(contact_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		}
		if (contact_2 != null)
		{
			nullable_1 = myUnit.RangeToUnit_Horiz_Alt(contact_2, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		}
		if (contact_3 != null)
		{
			nullable_2 = myUnit.RangeToUnit_Horiz_Alt(contact_3, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		}
		if (contact_4 != null)
		{
			nullable_3 = myUnit.RangeToUnit_Horiz_Alt(contact_4, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		}
	}

	public virtual void ClearManualOrders()
	{
		PrimaryPickupTarget = null;
		if (PickupTargets != null)
		{
			PickupTargets.Clear();
		}
	}

	internal bool HasPickupTargets()
	{
		if (PickupTargets != null)
		{
			return PickupTargets.Count > 0;
		}
		return false;
	}

	public void AddPickupTarget(string theID)
	{
		if (PickupTargets == null)
		{
			PickupTargets = new HashSet<string>();
		}
		if (!PickupTargets.Contains(theID))
		{
			PickupTargets.Add(theID);
		}
	}

	public void RemovePickupTarget(string theID)
	{
		string[] array = theID.Split(new char[1] { '_' });
		string text = default(string);
		if (PickupTargets != null)
		{
			if (Operators.CompareString(array[0], "ActiveUnit", false) != 0 && Operators.CompareString(array[0], "Contact", false) != 0)
			{
				text = theID;
				PickupTargets.Remove("ActiveUnit_" + theID);
			}
			else
			{
				text = array[1];
				PickupTargets.Remove(theID);
			}
		}
		if (PickupTargets == null)
		{
			PrimaryPickupTarget = null;
		}
		if (PrimaryPickupTarget != null && Operators.CompareString(PrimaryPickupTarget.ObjectID, text, false) == 0)
		{
			PrimaryPickupTarget = null;
		}
	}

	internal GeoPoint IntermediateTargetPointForRefuelCalcs()
	{
		GeoPoint result;
		try
		{
			GeoPoint geoPoint = null;
			ActiveUnit._ActiveUnitStatus status = myUnit.Status;
			if (status <= ActiveUnit._ActiveUnitStatus.OnFerryMission)
			{
				if (status <= ActiveUnit._ActiveUnitStatus.RTB)
				{
					if (status != ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
					{
						if (status == ActiveUnit._ActiveUnitStatus.RTB)
						{
							goto IL_038e;
						}
					}
					else
					{
						geoPoint = (myUnit.Navigator.HasPlottedCourse() ? myUnit.Navigator.PlottedCourse.First() : new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else
				{
					if (status == ActiveUnit._ActiveUnitStatus.RTB_Manual)
					{
						goto IL_038e;
					}
					if (status == ActiveUnit._ActiveUnitStatus.OnFerryMission)
					{
						ActiveUnit activeUnit = (myUnit.IsAircraft ? ((Aircraft)myUnit).AirOps.ActualDestinationHost : myUnit.DockingOps.ActualDestinationHost);
						if (activeUnit != null)
						{
							geoPoint = new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
						}
					}
				}
				goto IL_010e;
			}
			if (status <= ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
			{
				if (status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && status - 19 > ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
				{
					goto IL_010e;
				}
			}
			else if (status != ActiveUnit._ActiveUnitStatus.RTB_CommsLost && status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion)
			{
				goto IL_010e;
			}
			goto IL_038e;
			IL_038e:
			result = null;
			goto end_IL_0001;
			IL_010e:
			if (myUnit.Navigator.HasPlottedCourse())
			{
				geoPoint = myUnit.Navigator.PlottedCourse.First();
			}
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				switch (myUnit.ActiveMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
					if (myUnit.Navigator.HasPlottedCourse() || (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse()))
					{
						geoPoint = ((!myUnit.Navigator.NextWaypointIsManual) ? ((!myUnit.IsGroupWingman() || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse()) ? myUnit.Navigator.PlottedCourse.First() : myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.First()) : myUnit.Navigator.PlottedCourse.First());
					}
					else if (PrimaryTarget == null)
					{
						if (myUnit.Navigator.PlottedCourse.Count() <= 0)
						{
							break;
						}
						Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
						foreach (Waypoint waypoint in plottedCourse)
						{
							if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponLaunch)
							{
								geoPoint = new GeoPoint(waypoint.Longitude, waypoint.Latitude);
								break;
							}
						}
					}
					else if ((PrimaryTarget.Type != Contact_Base.ContactType.Air && PrimaryTarget.Type != Contact_Base.ContactType.Missile) || !(myUnit.RangeToUnit_Horiz(PrimaryTarget) < 150f))
					{
						geoPoint = new GeoPoint(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null));
					}
					break;
				case Mission._MissionClass.Patrol:
				{
					GeoPoint patrolLoop_NextRefPoint = myUnit.Navigator.PatrolLoop_NextRefPoint;
					geoPoint = ((patrolLoop_NextRefPoint != null) ? patrolLoop_NextRefPoint : Misc.Center(((Patrol)myUnit.ActiveMissionOrPackage()).PatrolArea).ToGeoPoint());
					break;
				}
				case Mission._MissionClass.Support:
					geoPoint = myUnit.Navigator.SupportMission_NextRefPoint;
					break;
				}
			}
			result = geoPoint;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100025", "");
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

	public ActiveUnit_AI(ActiveUnit theUnit)
	{
		ActiveSecondsLeftInDebugModeAI = 0f;
		_DoNotTargetList = new List<Contact>();
		NavDestination = default(Geopoint_Struct);
		HasCaughtUpWithGroup = false;
		theContactsVisibleToMe = new PooledList<Contact>();
		LeadMustSlowDownDueToBingo = false;
		EvaluateTargets_Enabled = true;
		DeterminePrimaryTarget_Enabled = true;
		CheckPossibleABMOrASATEngagement = false;
		WeaponThreat = null;
		MiningInfo = null;
		EvasionManeuver = null;
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		long_0 = 0L;
		CalculatedNearestTargetsThisPulse = false;
		_SelfDefenceTargets = new List<Contact>();
		list_1 = new List<TargetingEntry>();
		list_2 = new List<TargetingEntry>();
		list_3 = new List<(double, double, float, float)>();
		myUnit = theUnit;
	}

	public float TargetingDelayForThisTarget(Contact theTarget)
	{
		float result;
		try
		{
			float num;
			if (theTarget != null)
			{
				if (myUnit == null)
				{
					result = 30f;
				}
				else if (theTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					result = 0f;
				}
				else
				{
					num = 0f;
					if (theTarget.ActualUnit == null)
					{
						goto IL_0092;
					}
					if (!theTarget.IsAutoDetection)
					{
						if (num == 0f && theTarget.ActualUnit.IsFixedFacility)
						{
							num = theTarget.TimeSinceDetection;
						}
						if (num == 0f && myUnit.IsAircraft && !theTarget.IsAir_Missile_Orbital_Contact)
						{
							num = theTarget.TimeSinceDetection;
						}
						goto IL_0092;
					}
					result = 0f;
				}
			}
			else
			{
				result = 30f;
			}
			goto end_IL_0001;
			IL_0092:
			if (num == 0f)
			{
				float? timeSinceDetection_Local = myUnit.Sensory.GetTimeSinceDetection_Local(ref theTarget);
				num = ((!timeSinceDetection_Local.HasValue) ? theTarget.TimeSinceDetection : timeSinceDetection_Local.Value);
			}
			if (num < theTarget.TimeSinceDetection && myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				num = theTarget.TimeSinceDetection;
			}
			if (myUnit.OODA_Targeting_Actual == 0)
			{
				myUnit.Proficiency = myUnit.Proficiency;
			}
			result = Math.Max((float)myUnit.OODA_Targeting_Actual - num, 0f);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100026", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 30f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public TargetingEntry._TargetingBehavior TargetingBehaviorForThisTarget(Contact theTarget, ObservableDictionary<string, TargetingEntry> theTargetList)
	{
		TargetingEntry._TargetingBehavior result;
		try
		{
			if (theTargetList == null)
			{
				theTargetList = _TargetList;
			}
			int num;
			if (theTarget == null)
			{
				result = TargetingEntry._TargetingBehavior.NotTargeted;
			}
			else
			{
				TargetingEntry value = null;
				if (theTargetList == null)
				{
					num = -1;
					goto IL_0037;
				}
				if (!theTargetList.TryGetValue(theTarget.ObjectID, ref value))
				{
					num = -1;
					goto IL_0037;
				}
				result = value.Behavior;
			}
			goto end_IL_0001;
			IL_0037:
			result = (TargetingEntry._TargetingBehavior)num;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100027", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = -1;
			}
			else
			{
				Debugger.Break();
				num2 = -1;
			}
			result = (TargetingEntry._TargetingBehavior)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool ContactAppearsToBeInterceptingMe(Contact theC)
	{
		if (myUnit == null)
		{
			return false;
		}
		int result;
		if (theC != null)
		{
			if (theC.HeadingIsKnown)
			{
				return Math.Abs(theC.CurrentHeading - MercatorProjection.BearingToUnit_True(((Module_Unit.Unit)theC).get_Latitude(GlobalVariables.ObjectTrue), ((Module_Unit.Unit)theC).get_Longitude(GlobalVariables.ObjectTrue), myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue))) < 5f;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void HeadToNearestEscortSubject()
	{
		try
		{
			List<ActiveUnit> list;
			lock (myUnit.get_UnitSide(SetSideOnly: false).Units)
			{
				list = new List<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
			}
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			Mission mission = myUnit.ActiveMissionOrPackage();
			try
			{
				foreach (ActiveUnit item in list)
				{
					if (item != null && item.IsOperating() && !item.IsGroup)
					{
						Mission mission2 = item.ActiveMissionOrPackage();
						if (mission != null && mission2 == mission && !item.AI.IsEscort)
						{
							list2.Add(item);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101347_1", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (list2.Count == 0)
			{
				return;
			}
			ActiveUnit activeUnit = list2.OrderBy([SpecialName] (ActiveUnit theU) => theU.RangeToUnit_Horiz(myUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)).ToList()[0];
			float num2 = default(float);
			try
			{
				List<Weapon> list3 = myUnit.Weaponry.AllDistinctWeaponsAboard_Actual();
				if (list3.Count > 0)
				{
					float num = list3.Select([SpecialName] (Weapon theW) => theW.MaxRange_NoTargetType).Max();
					num2 = Math.Min(5f, num / 3f);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101347_2", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (myUnit.RangeToUnit_Horiz(activeUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) > num2)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(myUnit, activeUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
					_ = activeUnit.DesiredSpeed;
					myUnit.DesiredSpeed = (float)((double)activeUnit.CurrentSpeed + (double)activeUnit.CurrentSpeed * 0.5);
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				}
				else
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit.CurrentHeading);
					myUnit.DesiredSpeed = activeUnit.CurrentSpeed;
					myUnit.Kinematics.DesiredSpeedOverride = null;
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 101347_3", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 101347", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HeadToGroupLead(float elapsedTime, ref Aircraft_AirOps theAO)
	{
		float num = 1f;
		float num2 = 3f;
		float num3 = 45f;
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
			{
				HasCaughtUpWithGroup = false;
				return;
			}
			myUnit.Navigator.ClearPathfindingWaypoints();
			ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			int num4;
			if (!myUnit.IsGroupLead())
			{
				if (myUnit.Navigator.HasPlottedCourse() && (myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Assemble || myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldStart || myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldEnd))
				{
					goto IL_0196;
				}
				if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Assemble || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldStart)
					{
						goto IL_0196;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.HoldEnd)
					{
						num4 = 1;
						goto IL_0197;
					}
				}
			}
			int num5;
			if (myUnit.Navigator.HasPlottedCourse())
			{
				num5 = 0;
			}
			else
			{
				if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
					{
						num5 = 0;
						goto IL_0249;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].HasWingmanWaypoints())
					{
						((Aircraft)myUnit).Kinematics.Loiter(elapsedTime);
						return;
					}
				}
				num5 = 0;
			}
			goto IL_0249;
			IL_0196:
			num4 = 1;
			goto IL_0197;
			IL_0197:
			bool flag = (byte)num4 != 0;
			goto IL_024b;
			IL_024b:
			bool flag2 = myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || theAO.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel;
			bool flag3 = groupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling;
			if (flag2 && flag3)
			{
				if (theAO.A2AR_Destination == null && ((Aircraft)groupLead).AirOps.A2AR_Destination != null && myUnit != ((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps.A2AR_Destination)
				{
					theAO.A2AR_Destination = ((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps.A2AR_Destination;
				}
				if (theAO.A2AR_Destination != null)
				{
					myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.A2AR_Destination.get_Latitude((GlobalVariables.BooleanObject)null), theAO.A2AR_Destination.get_Longitude((GlobalVariables.BooleanObject)null)));
					Aircraft_AirOps obj = theAO;
					Aircraft a2AR_Destination = theAO.A2AR_Destination;
					bool MissionPlanner_PostponedRefuelling = false;
					obj.AttemptToRendezvousWithTanker(a2AR_Destination, ref MissionPlanner_PostponedRefuelling, IsManual: false, IsForced: false);
					HasCaughtUpWithGroup = false;
					return;
				}
			}
			else
			{
				if (flag2 && theAO.A2AR_Destination == null && myUnit.IsAircraft && ((Aircraft)myUnit).IsTanker)
				{
					((Aircraft)myUnit).AI.AssistRefuellingClients();
					HasCaughtUpWithGroup = false;
					return;
				}
				float num6 = Module_Unit.BearingToUnit_Relative(groupLead, myUnit);
				float num7 = myUnit.RangeToUnit_Horiz(groupLead);
				double decelerationCapacity = myUnit.Kinematics.GetDecelerationCapacity(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed, 1f);
				double num8 = (double)(myUnit.CurrentSpeed - groupLead.CurrentSpeed) / decelerationCapacity;
				double num9 = num8 * (double)((myUnit.CurrentSpeed + groupLead.CurrentSpeed) / 2f);
				double num10 = num8 * (double)groupLead.CurrentSpeed;
				double num11 = num9 - num10;
				if (num7 < num || (flag && !(myUnit.RangeToUnit_Horiz(groupLead) >= 4f)))
				{
					HasCaughtUpWithGroup = true;
					MatchGroupLead();
					return;
				}
				if (num7 < num2 && num6 > 180f - num3 && num6 < 180f + num3)
				{
					HasCaughtUpWithGroup = true;
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(groupLead.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num / 2f, Math2.NormalizeBearing(groupLead.CurrentHeading + 180f));
					myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
					if (num11 >= (double)(num7 - num))
					{
						myUnit.DesiredSpeed = groupLead.DesiredSpeed;
					}
					else
					{
						myUnit.DesiredSpeed = groupLead.DesiredSpeed * 1.2f;
					}
					return;
				}
				double out_lon2 = default(double);
				double out_lat2 = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(groupLead.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, num / 2f, Math2.NormalizeBearing(groupLead.CurrentHeading + 180f));
				myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat2, out_lon2));
				HasCaughtUpWithGroup = false;
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				myUnit.DesiredAltitude = groupLead.DesiredAltitude;
				myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, groupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit));
			}
			if (myUnit.Navigator.HasPathfindingPlottedCourse)
			{
				if (myUnit.RangeToUnit_Horiz(groupLead) > 50f)
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
				else
				{
					myUnit.Navigator.ClearPathfindingWaypoints();
				}
			}
			else if (myUnit.CurrentSpeed > 0f && !flag)
			{
				float num12 = Module_Unit.BearingToUnit_Relative(groupLead, myUnit);
				if (!(num12 < 90f) && num12 <= 270f)
				{
					float num13 = myUnit.ETA_To_Location(myUnit.CurrentSpeed, Module_Unit.RangeToPoint_Horiz(myUnit, groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null)));
					float distance_NM = myUnit.CurrentSpeed * num13 / 3600f;
					double out_lon3 = default(double);
					double out_lat3 = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(groupLead.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon3, ref out_lat3, distance_NM, groupLead.CurrentHeading);
					double out_lon4 = default(double);
					double out_lat4 = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(groupLead.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon4, ref out_lat4, num, Math2.NormalizeBearing(groupLead.CurrentHeading + 180f));
					myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat4, out_lon4));
				}
				else
				{
					myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null)));
				}
				if (myUnit.Navigator.bool_0 && !myUnit.Navigator.HasPathfindingPlottedCourse && !myUnit.Navigator.PathFindingInProgress && myUnit.RangeToUnit_Horiz(groupLead) > 50f)
				{
					double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double destLat = groupLead.get_Latitude((GlobalVariables.BooleanObject)null);
					double destLon = groupLead.get_Longitude((GlobalVariables.BooleanObject)null);
					ActiveUnit_Navigator navigator = myUnit.Navigator;
					float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
					int ReasonForInterrupt = 0;
					GeoPoint InterruptLocation = null;
					if (navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
					{
						myUnit.Navigator.TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, destLat, destLon, myUnit.ParentScen, ManouverTowardsTarget: false);
					}
				}
			}
			else
			{
				myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null)));
			}
			myUnit.Kinematics.DesiredSpeedOverride = null;
			if (groupLead.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
			{
				return;
			}
			if (myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					if (groupLead.ThrottleSetting <= ActiveUnit.Throttle.Cruise)
					{
						myUnit.SetThrottle(groupLead.ThrottleSetting);
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else
				{
					myUnit.SetThrottle(groupLead.ThrottleSetting);
				}
			}
			else if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				if (groupLead.ThrottleSetting <= ActiveUnit.Throttle.Cruise)
				{
					myUnit.SetThrottle(groupLead.ThrottleSetting + 1);
				}
				else
				{
					myUnit.SetThrottle(groupLead.ThrottleSetting);
				}
			}
			else
			{
				myUnit.SetThrottle(groupLead.ThrottleSetting + 1);
			}
			return;
			IL_0249:
			flag = (byte)num5 != 0;
			goto IL_024b;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200334", ex2.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public void MatchGroupLead()
	{
		try
		{
			if (Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				return;
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride && !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.IsShip)
			{
				if (myUnit.DesiredAltitude != myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude)
				{
					myUnit.DesiredAltitude = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude;
				}
				if (myUnit.DesiredAltitude_AGL != myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL)
				{
					myUnit.DesiredAltitude_AGL = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL;
				}
				if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit) != myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
				{
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead));
				}
			}
			myUnit.set_DesiredHeading(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredHeading);
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
			{
				myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed;
			}
			else
			{
				myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredSpeed;
			}
			if (myUnit.ThrottleSetting != myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting)
			{
				myUnit.SetThrottle(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting, myUnit.DesiredSpeed);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100029", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSpeedAlt_MatchGroupLead()
	{
		try
		{
			if (myUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
				{
					if (!value.IsGroupLead())
					{
						value.AI.MatchGroupLead();
					}
				}
				return;
			}
			if (!myUnit.IsGroupWingman())
			{
				if (!myUnit.IsGroupLead())
				{
					return;
				}
				{
					foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (!value2.IsGroupLead())
						{
							value2.AI.MatchGroupLead();
						}
					}
					return;
				}
			}
			myUnit.AI.MatchGroupLead();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101348", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool HaveTankersWithinTacticalRadiusFromTarget(double theLatitude, double theLongitude, float theTacRadius, float? theAltitude, [Optional][DefaultParameterValue("")] ref string reason)
	{
		bool result;
		try
		{
			Aircraft obj = (Aircraft)myUnit;
			Aircraft_AirOps airOps = obj.AirOps;
			bool IsManual = false;
			ActiveUnit ManuallySelectedUnit = null;
			string UserFeedback = "";
			List<Aircraft> potentialTankers = airOps.GetPotentialTankers(ref IsManual, ref ManuallySelectedUnit, MustBeAbleToReachItDirectly: false, null, ref UserFeedback);
			float num = obj.Kinematics.MaxRange(BingoFuelCheck: false, null, theAltitude);
			if (potentialTankers.Count > 1)
			{
				List<Aircraft> list = new List<Aircraft>();
				using (List<Aircraft>.Enumerator enumerator = potentialTankers.GetEnumerator())
				{
					_Closure$__117-0 closure$__117- = default(_Closure$__117-0);
					while (enumerator.MoveNext())
					{
						closure$__117- = new _Closure$__117-0(closure$__117-);
						closure$__117-.$VB$Local_theTanker = enumerator.Current;
						bool flag = false;
						foreach (Aircraft item in potentialTankers.Where(closure$__117-._Lambda$__0).ToList())
						{
							if (!(closure$__117-.$VB$Local_theTanker.RangeToUnit_Horiz(item) >= num))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(closure$__117-.$VB$Local_theTanker);
						}
					}
				}
				foreach (Aircraft item2 in list)
				{
					potentialTankers.Remove(item2);
				}
			}
			bool flag2 = default(bool);
			foreach (Aircraft item3 in potentialTankers)
			{
				if (!(item3.RangeToUnit_Horiz(myUnit) >= num))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				bool flag3 = default(bool);
				foreach (Aircraft item4 in potentialTankers)
				{
					if (!(Module_Unit.RangeToPoint_Horiz(item4, theLatitude, theLongitude) >= theTacRadius))
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					result = true;
				}
				else
				{
					reason = "no tankers within range are also within the aircraft's tactical radius (" + (int)Math.Round(theTacRadius) + "nm) to the target / station area.";
					result = false;
				}
			}
			else
			{
				reason = "no tankers are within the aircraft's maximum range (" + (long)Math.Round(num) + "nm) from base.";
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101349", "");
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

	internal bool CanReachTarget_AirIntercept(Contact theTarget, int theMinRange, int theMaxRange, Doctrine._UseUnderwayRefuelAndReplenishment? TankerUsage, bool LaunchWithoutTankersInPlace, ref string FlightPlanFeedback)
	{
		bool result;
		try
		{
			string reason = "";
			int num3;
			if (!Information.IsNothing((object)theTarget))
			{
				float num = myUnit.RangeToUnit_Horiz(theTarget);
				if (theMaxRange != 0 && num > (float)theMaxRange)
				{
					FlightPlanFeedback = "The mission is configured to not launch for targets beyond " + Conversions.ToString(theMaxRange) + " nm while the distance to the target is " + Conversions.ToString((int)Math.Round(num)) + " nm.";
					result = false;
				}
				else if (theMinRange != 0 && num < (float)theMinRange)
				{
					FlightPlanFeedback = "The mission is configured to not launch for targets closer than " + Conversions.ToString(theMinRange) + " nm while the distance to the target is " + Conversions.ToString((int)Math.Round(num)) + " nm.";
					result = false;
				}
				else
				{
					Aircraft aircraft = (Aircraft)myUnit;
					float num2 = aircraft.Kinematics.TacticalRadius();
					Weapon longestRange_AAWeapon = aircraft.Weaponry.GetLongestRange_AAWeapon(null);
					if (!Information.IsNothing((object)longestRange_AAWeapon))
					{
						num2 += longestRange_AAWeapon.MaxAirRange;
					}
					if (num < num2)
					{
						result = true;
					}
					else if (!aircraft.BoomRefuelling && !aircraft.ProbeRefuelling)
					{
						FlightPlanFeedback = "The target is out of range.";
						result = false;
					}
					else
					{
						byte? b = (byte?)TankerUsage;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
						{
							FlightPlanFeedback = "The mission is configured to NOT use air-to-air refuelling and the target is out of range.";
							result = false;
						}
						else
						{
							float bingoFuelAltitude = default(float);
							if (!LaunchWithoutTankersInPlace)
							{
								Aircraft_Navigator navigator = aircraft.Navigator;
								bool theAltitude_TerrainFollowing = false;
								bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
							}
							if (LaunchWithoutTankersInPlace)
							{
								num3 = 1;
								goto IL_01e6;
							}
							if (HaveTankersWithinTacticalRadiusFromTarget(((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), aircraft.Loadout.CombatRadius, bingoFuelAltitude, ref reason))
							{
								num3 = 1;
								goto IL_01e6;
							}
							FlightPlanFeedback = "The mission is configured to use air-to-air refuelling, but " + reason;
							result = false;
						}
					}
				}
			}
			else
			{
				FlightPlanFeedback = "The target does not exist!";
				result = false;
			}
			goto end_IL_0001;
			IL_01e6:
			result = (byte)num3 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101249", "");
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

	internal float LongestRangeWeaponForStrikeMission(ref Strike.StrikeType theStrikeType)
	{
		float result;
		try
		{
			Aircraft aircraft = (Aircraft)myUnit;
			switch (theStrikeType)
			{
			case Strike.StrikeType.Land_Strike:
			{
				Weapon longestRange_ASWWeapon = aircraft.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false);
				if (Information.IsNothing((object)longestRange_ASWWeapon))
				{
					break;
				}
				result = longestRange_ASWWeapon.MaxLandRange;
				goto end_IL_0001;
			}
			case Strike.StrikeType.Maritime_Strike:
			{
				Weapon longestRange_ASWWeapon = aircraft.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false);
				if (Information.IsNothing((object)longestRange_ASWWeapon))
				{
					break;
				}
				result = longestRange_ASWWeapon.MaxSurfaceRange;
				goto end_IL_0001;
			}
			case Strike.StrikeType.Sub_Strike:
			{
				Weapon longestRange_ASWWeapon = aircraft.Weaponry.GetLongestRange_ASWWeapon();
				if (Information.IsNothing((object)longestRange_ASWWeapon))
				{
					break;
				}
				result = longestRange_ASWWeapon.MaxSubsurfaceRange;
				goto end_IL_0001;
			}
			}
			result = 0f;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101350", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool CheckIfEnoughFuelToReachNewPrimaryTarget(ref Mission.Flight theMasterFlightPlanEntry, ref float FuelQtyRequired, Contact NewPrimaryTarget, ref string FlightPlanFeedback)
	{
		if (!Information.IsNothing((object)theMasterFlightPlanEntry) && !Information.IsNothing((object)theMasterFlightPlanEntry.FlightPlan))
		{
			Waypoint[] theArray = new Waypoint[0];
			Waypoint[] flightPlan = theMasterFlightPlanEntry.FlightPlan;
			for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
			{
				Waypoint theOriginalWaypoint = flightPlan[i];
				if (theOriginalWaypoint.Type != Waypoint.WaypointType.InitialPoint && theOriginalWaypoint.Type != Waypoint.WaypointType.WeaponLaunch)
				{
					ref Scenario parentScen = ref myUnit.ParentScen;
					Doctrine FlightLeadDoctrine = null;
					Waypoint waypoint = Waypoint.CopyWaypoint(ref parentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
					if (waypoint.Type == Waypoint.WaypointType.Target || theOriginalWaypoint.Type == Waypoint.WaypointType.WeaponTarget)
					{
						waypoint.Latitude = ((Module_Unit.Unit)NewPrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
						waypoint.Longitude = ((Module_Unit.Unit)NewPrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					}
					ArrayExtensions.Add(ref theArray, waypoint);
				}
			}
			Aircraft aircraft = (Aircraft)myUnit;
			float MissionFuel = default(float);
			if (MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(aircraft.ParentScen, aircraft.ActiveMissionOrPackage(), aircraft, ((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true), ref theArray, ref FuelQtyRequired, ref MissionFuel, RangeCheck: true, RunValidation: false, RunFreeSpeedChecks: false, SetWaypointTimes: false, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: false, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: true, BananaSplitRedSection: false, aircraft.ActiveMissionOrPackage().TakeOffTime, aircraft.ActiveMissionOrPackage().TimeOnTarget, IsMFP: true))
			{
				return true;
			}
			FlightPlanFeedback = "Not enough fuel to reach the target. Mission fuel (not counting reserves) is " + Conversions.ToString((int)Math.Round(MissionFuel)) + " kg while fuel requirement for flightplan would be " + Conversions.ToString((int)Math.Round(FuelQtyRequired)) + " kg.";
			return false;
		}
		FlightPlanFeedback = "No flightplan found!";
		return false;
	}

	internal bool CanReachTarget_Strike(ref Scenario thescen, ref Side theSide, ref Mission theMission, ref Mission.Flight theMasterFlightPlanEntry, ref Contact theTarget, int theMinRange, int theMaxRange, Doctrine._UseUnderwayRefuelAndReplenishment? TankerUsage, bool LaunchWithoutTankersInPlace, Mission._RadarBehaviour RadarUsage, bool AttemptPathfinderFlightPlan, bool SeparateIngressEgressPathfinderFlightPlans, bool AircraftIsAirborne, bool UseAutoPlanner, ref float FuelQtyRequired, ref string FlightPlanFeedback, bool CallNavigatorImmediately, ref bool IsBananaSplitRedSection, bool UsePreDefinedOffsets, ref float Offset_Ingress, ref float Offset_Egress, bool CreateFlightPlan, Contact NewPrimaryTarget, bool IsCreatedManually, DateTime? theTakeOffTime, DateTime? theObjectiveTime, bool IsContinousCoverage, bool IsMFP)
	{
		bool num = method_1(ref thescen, ref theSide, ref theMission, ref theMasterFlightPlanEntry, theTarget, theMinRange, theMaxRange, TankerUsage, LaunchWithoutTankersInPlace, RadarUsage, ref AttemptPathfinderFlightPlan, SeparateIngressEgressPathfinderFlightPlans, AircraftIsAirborne, UseAutoPlanner, ref FuelQtyRequired, ref FlightPlanFeedback, CallNavigatorImmediately, ref IsBananaSplitRedSection, UsePreDefinedOffsets, ref Offset_Ingress, ref Offset_Egress, ref CreateFlightPlan, NewPrimaryTarget, IsCreatedManually, theTakeOffTime, theObjectiveTime, IsMFP);
		if (num)
		{
			thescen.FIX_WpnReleaseAltitude(theMission);
		}
		return num;
	}

	private bool method_1(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, Contact contact_5, int int_0, int int_1, Doctrine._UseUnderwayRefuelAndReplenishment? nullable_4, bool bool_0, Mission._RadarBehaviour _RadarBehaviour_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref float float_0, ref string string_0, bool bool_5, ref bool bool_6, bool bool_7, ref float float_1, ref float float_2, ref bool bool_8, Contact contact_6, bool bool_9, DateTime? nullable_5, DateTime? nullable_6, bool bool_10)
	{
		bool result;
		if (myUnit == null)
		{
			result = false;
		}
		else
		{
			Aircraft theAC = (Aircraft)myUnit;
			try
			{
				string reason = "";
				if (contact_5 != null)
				{
					float num = ((theAC.AirOps.ActualDestinationHost == null) ? theAC.RangeToUnit_Horiz(contact_5) : theAC.AirOps.ActualDestinationHost.RangeToUnit_Horiz(contact_5));
					if (int_1 != 0 && num > (float)int_1)
					{
						if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							Mission.Flight obj = flight_0;
							Waypoint[] theArray = obj.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref theArray);
							obj.FlightPlan_Pathfinder_Ingress_1 = theArray;
						}
						string_0 = "The mission is configured to not strike targets beyond " + Conversions.ToString(int_1) + " nm while the distance from base to the target is " + Conversions.ToString((int)Math.Round(num)) + " nm. No flightplan has been generated and the mission will not launch.";
						result = false;
					}
					else if (int_0 != 0 && num < (float)int_0)
					{
						if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							Mission.Flight obj2 = flight_0;
							Waypoint[] theArray = obj2.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref theArray);
							obj2.FlightPlan_Pathfinder_Ingress_1 = theArray;
						}
						string_0 = "The mission is configured to not strike targets closer than " + Conversions.ToString(int_0) + " nm while the distance from base to the target is " + Conversions.ToString((int)Math.Round(num)) + " nm. No flightplan has been generated and the mission will not launch.";
						result = false;
					}
					else
					{
						Weapon StrikeWeapon = theAC.Weaponry.MostSuitableWeaponForThisTarget(contact_5, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, theAC.Doctrine);
						if (StrikeWeapon == null)
						{
							string_0 = "Could not determine the most suitable weapon. Are the aircraft loaded with correct weapons for the mission type? No flightplan has been created.";
							result = false;
						}
						else
						{
							float num2 = StrikeWeapon.get_MaxRangeForThisTarget((ActiveUnit)theAC, contact_5, CheckWRA: true, theAC.Doctrine, ManualFire: false) * 0.9f;
							bool flag = false;
							int? num3 = theAC?.Loadout?.CombatRadius;
							bool? flag2 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() > 0));
							if (flag2 ?? true)
							{
								num3 = theAC?.Loadout?.TimeOnStation_Minutes;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) == true && flag2.HasValue)
								{
									flag = true;
								}
							}
							float num4 = ((!flag) ? theAC.Kinematics.TacticalRadius() : ((float)theAC.Loadout.CombatRadius));
							if (num <= num4 + num2)
							{
								if (mission_0.MissionClass == Mission._MissionClass.Strike && ((Strike)mission_0).Type == Strike.StrikeType.Sub_Strike)
								{
									bool_8 = false;
								}
								result = (bool_8 ? MissionPlanner.GenerateFlightPlan_Strike(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref theAC, null, contact_5, _RadarBehaviour_0, ref bool_1, bool_2, bool_3, bool_4, ref float_0, ref string_0, bool_5, ref bool_6, bool_7, ref float_1, ref float_2, MustUseTanker: false, num, ref StrikeWeapon, num2, bool_9, nullable_5, nullable_6, bool_10) : (contact_6 == null || CheckIfEnoughFuelToReachNewPrimaryTarget(ref flight_0, ref float_0, contact_6, ref string_0)));
							}
							else if (!theAC.BoomRefuelling && !theAC.ProbeRefuelling)
							{
								string_0 = "The target is out of range. Distance to target is " + Conversions.ToString((int)Math.Round(num)) + " nm while combat radius is " + Conversions.ToString(num4) + " nm and max weapon range is " + Conversions.ToString(num2) + " nm.";
								result = false;
							}
							else
							{
								byte? b = (byte?)nullable_4;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
								{
									if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
									{
										Mission.Flight obj3 = flight_0;
										Waypoint[] theArray = obj3.FlightPlan_Pathfinder_Ingress_1;
										ArrayExtensions.Clear(ref theArray);
										obj3.FlightPlan_Pathfinder_Ingress_1 = theArray;
									}
									string_0 = "The mission is configured to NOT use air-to-air refuelling and the target is out of range. No flightplan has been generated and the mission will not launch.";
									result = false;
								}
								else
								{
									b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
									{
										float bingoFuelAltitude = default(float);
										if (!bool_0)
										{
											Aircraft_Navigator navigator = theAC.Navigator;
											bool theAltitude_TerrainFollowing = false;
											bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
										}
										if (bool_0 || HaveTankersWithinTacticalRadiusFromTarget(((Module_Unit.Unit)contact_5).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_5).get_Longitude((GlobalVariables.BooleanObject)null), num4, bingoFuelAltitude, ref reason))
										{
											result = !bool_8 || MissionPlanner.GenerateFlightPlan_Strike(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref theAC, true, contact_5, _RadarBehaviour_0, ref bool_1, bool_2, bool_3, bool_4, ref float_0, ref string_0, bool_5, ref bool_6, bool_7, ref float_1, ref float_2, MustUseTanker: true, num, ref StrikeWeapon, num2, bool_9, nullable_5, nullable_6, bool_10);
										}
										else
										{
											if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
											{
												Mission.Flight obj4 = flight_0;
												Waypoint[] theArray = obj4.FlightPlan_Pathfinder_Ingress_1;
												ArrayExtensions.Clear(ref theArray);
												obj4.FlightPlan_Pathfinder_Ingress_1 = theArray;
											}
											string_0 = "The mission is configured to use air-to-air refuelling, but " + reason + "\r\n\r\nNo flightplan has been generated and the mission will not launch. This security check might be ignored by checking the relative option from Mission Setting --> Tanker --> Configure";
											result = false;
										}
									}
									else
									{
										if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
										{
											Mission.Flight obj5 = flight_0;
											Waypoint[] theArray = obj5.FlightPlan_Pathfinder_Ingress_1;
											ArrayExtensions.Clear(ref theArray);
											obj5.FlightPlan_Pathfinder_Ingress_1 = theArray;
										}
										string text = "";
										if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
										{
											text = " (" + myUnit.UnitClass + ")";
										}
										string_0 = myUnit.Name + text + " has a doctrine setting that forbids air-to-air refuelling and the target is out of range. No flightplan has been generated and the mission will not launch.";
										result = false;
									}
								}
							}
						}
					}
				}
				else
				{
					string_0 = "The target does not exist!";
					result = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100399", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num5;
				if (!Debugger.IsAttached)
				{
					num5 = 0;
				}
				else
				{
					Debugger.Break();
					num5 = 0;
				}
				result = (byte)num5 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	internal bool CanReachStation(ref Mission.Flight theMasterFlightPlanEntry, Doctrine._UseUnderwayRefuelAndReplenishment? TankerUsage, bool LaunchWithoutTankersInPlace, bool AttemptPathfinderFlightPlan, bool SeparateIngressEgressPathfinderFlightPlans, bool AircraftIsAirborne, ref float FuelQtyRequired, ref string FlightPlanFeedback, bool CallNavigatorImmediately, bool CreateFlightPlan, double StationStart_Lat, double StationStart_Lon, double StationEnd_Lat, double StationEnd_Lon, Waypoint.WaypointType thePointType, Waypoint.TurnRateCategory theStationTurnRate, bool IsCreatedManually, DateTime? theTakeOffTime, DateTime? theObjectiveTime, bool IsContinousCoverage, bool IsMFP)
	{
		bool result;
		try
		{
			string reason = "";
			Aircraft theAC = (Aircraft)myUnit;
			float num;
			int num2;
			if (!Information.IsNothing((object)theAC.AirOps.ActualDestinationHost))
			{
				num = Module_Unit.RangeToPoint_Horiz(theAC.AirOps.ActualDestinationHost, StationStart_Lat, StationStart_Lon);
				num2 = 0;
			}
			else
			{
				num = Module_Unit.RangeToPoint_Horiz(theAC, StationStart_Lat, StationStart_Lon);
				num2 = 0;
			}
			bool flag = (byte)num2 != 0;
			if (theAC.Loadout.CombatRadius > 0 && theAC.Loadout.TimeOnStation_Minutes == 0)
			{
				flag = true;
			}
			float num3 = (flag ? ((float)theAC.Loadout.CombatRadius) : theAC.Kinematics.TacticalRadius());
			if (num <= num3)
			{
				if (CreateFlightPlan)
				{
					ref Scenario parentScen = ref myUnit.ParentScen;
					ActiveUnit activeUnit;
					Side theSide = (activeUnit = myUnit).get_UnitSide(SetSideOnly: false);
					Mission theMission = myUnit.ActiveMissionOrPackage();
					bool num4 = MissionPlanner.GenerateFlightPlan_Station(ref parentScen, ref theSide, ref theMission, ref theMasterFlightPlanEntry, ref theAC, null, ref AttemptPathfinderFlightPlan, SeparateIngressEgressPathfinderFlightPlans, AircraftIsAirborne, ref FuelQtyRequired, ref FlightPlanFeedback, CallNavigatorImmediately, Information.IsNothing((object)TankerUsage) || TankerUsage.Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never, num, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, thePointType, theStationTurnRate, IsCreatedManually, theTakeOffTime, theObjectiveTime, IsMFP);
					activeUnit.set_UnitSide(SetSideOnly: false, theSide);
					result = num4;
				}
				else
				{
					result = true;
				}
			}
			else if (!theAC.BoomRefuelling && !theAC.ProbeRefuelling)
			{
				FlightPlanFeedback = "The station area is out of range. Distance to target is " + Conversions.ToString((int)Math.Round(num)) + " nm while combat radius is " + Conversions.ToString(num3) + " nm.";
				result = false;
			}
			else
			{
				byte? b = (byte?)TankerUsage;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					if (theMasterFlightPlanEntry.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						Mission.Flight obj = theMasterFlightPlanEntry;
						Waypoint[] theArray = obj.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref theArray);
						obj.FlightPlan_Pathfinder_Ingress_1 = theArray;
					}
					FlightPlanFeedback = "The mission is configured to NOT use air-to-air refuelling and the target is out of range. No flightplan has been generated and the mission will not launch.";
					result = false;
				}
				else
				{
					float bingoFuelAltitude = default(float);
					if (!LaunchWithoutTankersInPlace)
					{
						Aircraft_Navigator navigator = theAC.Navigator;
						bool theAltitude_TerrainFollowing = false;
						bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
					}
					if (!LaunchWithoutTankersInPlace && !HaveTankersWithinTacticalRadiusFromTarget(StationStart_Lat, StationStart_Lon, num3, bingoFuelAltitude, ref reason))
					{
						if (theMasterFlightPlanEntry.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							Mission.Flight obj2 = theMasterFlightPlanEntry;
							Waypoint[] theArray = obj2.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref theArray);
							obj2.FlightPlan_Pathfinder_Ingress_1 = theArray;
						}
						FlightPlanFeedback = "The mission is configured to use air-to-air refuelling, but " + reason + "\r\n\r\nNo flightplan has been generated and the mission will not launch.";
						result = false;
					}
					else if (CreateFlightPlan)
					{
						ref Scenario parentScen2 = ref myUnit.ParentScen;
						ActiveUnit activeUnit;
						Side theSide = (activeUnit = myUnit).get_UnitSide(SetSideOnly: false);
						Mission theMission = myUnit.ActiveMissionOrPackage();
						bool num5 = MissionPlanner.GenerateFlightPlan_Station(ref parentScen2, ref theSide, ref theMission, ref theMasterFlightPlanEntry, ref theAC, null, ref AttemptPathfinderFlightPlan, SeparateIngressEgressPathfinderFlightPlans, AircraftIsAirborne, ref FuelQtyRequired, ref FlightPlanFeedback, CallNavigatorImmediately, MustUseTanker: true, num, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, thePointType, theStationTurnRate, IsCreatedManually, theTakeOffTime, theObjectiveTime, IsMFP);
						activeUnit.set_UnitSide(SetSideOnly: false, theSide);
						result = num5;
					}
					else
					{
						result = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 098653434765", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (!Debugger.IsAttached)
			{
				num6 = 0;
			}
			else
			{
				Debugger.Break();
				num6 = 0;
			}
			result = (byte)num6 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool CanMissionTargetThisContactBasedOnPostureStance(ref Strike theStrikeMission, Misc.PostureStance theContactStance)
	{
		switch (theStrikeMission.MinimumContactStanceToTrigger)
		{
		default:
			return false;
		case Misc.PostureStance.Unfriendly:
			if (theContactStance != Misc.PostureStance.Hostile && theContactStance != Misc.PostureStance.Unfriendly)
			{
				return false;
			}
			return true;
		case Misc.PostureStance.Hostile:
			if (theContactStance != Misc.PostureStance.Hostile)
			{
				return false;
			}
			return true;
		case Misc.PostureStance.Unknown:
			return true;
		}
	}

	public void HandleContactBeingDropped(ref Contact theContact, ref Side theSide)
	{
		try
		{
			if ((myUnit == null || theSide == myUnit.get_UnitSide(SetSideOnly: false)) && _TargetList != null && _TargetList.ContainsKey(theContact.ObjectID))
			{
				DropTarget(theContact);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100031", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearMissionTargets(Mission theMission)
	{
		try
		{
			if (myUnit == null || theMission == null)
			{
				return;
			}
			lock (lockObject_0)
			{
				if (_TargetList == null || _TargetList.Count <= 0)
				{
					return;
				}
				List<TargetingEntry> list = _TargetList.Values.ToList();
				Side side = myUnit.get_UnitSide(SetSideOnly: false);
				foreach (TargetingEntry item in list)
				{
					if (item.Behavior == TargetingEntry._TargetingBehavior.ManualTargeted || item.Behavior == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						continue;
					}
					ref Contact target = ref item.Target;
					string string_ = "";
					int int_ = 0;
					if (method_3(ref target, theMission, null, bool_0: true, bool_1: true, ref string_, ref int_, side, item.Target.get_Stance(side)))
					{
						if (!myUnit.IsWeapon)
						{
							Side side2 = myUnit.get_UnitSide(SetSideOnly: false);
							ref Scenario parentScen = ref myUnit.ParentScen;
							ref ActiveUnit theAU = ref myUnit;
							ref Contact target2 = ref item.Target;
							WeaponSalvo theSalvo = null;
							side2.StopShootingSalvo(ref parentScen, ref theAU, ref target2, ref theSalvo);
							myUnit.get_UnitSide(SetSideOnly: false).RemoveFireProposal(myUnit, item.Target);
						}
						if (PrimaryTarget == item.Target)
						{
							PrimaryTarget = null;
						}
						method_6(item.Target);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200327M", ex2.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllTargets(ref ActiveUnit theAU)
	{
		try
		{
			if (myUnit == null)
			{
				return;
			}
			lock (lockObject_0)
			{
				if (!theAU.IsWeapon)
				{
					Side side = myUnit.get_UnitSide(SetSideOnly: false);
					ref Scenario parentScen = ref myUnit.ParentScen;
					ref ActiveUnit theAU2 = ref myUnit;
					Contact theTarget = null;
					WeaponSalvo theSalvo = null;
					side.StopShootingSalvo(ref parentScen, ref theAU2, ref theTarget, ref theSalvo);
				}
				if (_TargetList != null)
				{
					_TargetList.Clear();
				}
				PrimaryTarget = null;
				TimeToNextTargetsEvaluation = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200327", ex2.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllThreats()
	{
		lock (lockObject_1)
		{
			if (_Threats != null)
			{
				_Threats.Clear();
			}
		}
	}

	public void ClearAllNonImminentThreats(float elapsedTime)
	{
		int num = 10;
		int num2 = 5;
		lock (lockObject_1)
		{
			if (_Threats == null)
			{
				return;
			}
			PooledList<Contact> pooledList = null;
			foreach (Contact threat in _Threats)
			{
				if (threat == null)
				{
					continue;
				}
				if (threat._ActualUnitID != null && myUnit.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(threat._ActualUnitID))
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<Contact>();
					}
					pooledList.Add(threat);
					continue;
				}
				float totalSecondsContactHasBeenOrphaned = threat.GetTotalSecondsContactHasBeenOrphaned(myUnit.ParentScen.Time);
				Contact_Base.ContactType type = threat.Type;
				if (type == Contact_Base.ContactType.Missile)
				{
					if (totalSecondsContactHasBeenOrphaned > (float)num)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Contact>();
						}
						pooledList.Add(threat);
					}
				}
				else if (totalSecondsContactHasBeenOrphaned > (float)num2)
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<Contact>();
					}
					pooledList.Add(threat);
				}
			}
			if (pooledList == null)
			{
				return;
			}
			foreach (Contact item in pooledList)
			{
				_Threats.Remove(item);
			}
			pooledList.Dispose();
		}
	}

	public virtual bool ClosingWithinWeaponRangeOfPrimaryTarget()
	{
		return false;
	}

	public virtual void InterceptPrimaryTarget()
	{
	}

	public bool ContactIsThreatToUnit(Contact theContact, ActiveUnit theUnit, int theMaxResponseRadius)
	{
		bool result;
		try
		{
			int num;
			if (theContact.Type == Contact_Base.ContactType.Aimpoint)
			{
				num = 0;
				goto IL_030d;
			}
			if (theContact.Type == Contact_Base.ContactType.ActivationPoint)
			{
				num = 0;
				goto IL_030d;
			}
			if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(theContact.ObjectID, out var value))
			{
				value = theContact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
				myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExistsElseUpdate(theContact.ObjectID, value);
			}
			float num2;
			float num3;
			if (value != Misc.PostureStance.Friendly && value != Misc.PostureStance.Neutral)
			{
				num2 = theUnit.RangeToUnit_Horiz(theContact);
				num3 = 0f;
				float? num4 = null;
				float? num5 = null;
				switch (theUnit.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
					num4 = theContact.MaxPotentialWeaponRange_ASuW_Naval();
					num5 = theContact.MaxPotentialActiveSensorRange_ASuW();
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					num4 = theContact.MaxPotentialWeaponRange_ASW();
					num5 = theContact.MaxPotentialActiveSensorRange_ASW();
					break;
				case GlobalVariables.ActiveUnitType.Aimpoint:
					result = false;
					goto end_IL_0001;
				case GlobalVariables.ActiveUnitType.Aircraft:
				case GlobalVariables.ActiveUnitType.Weapon:
					num4 = theContact.MaxPotentialWeaponRange_AAW();
					num5 = theContact.MaxPotentialActiveSensorRange_AAW();
					break;
				case GlobalVariables.ActiveUnitType.Facility:
				case GlobalVariables.ActiveUnitType.Vehicle:
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					num4 = theContact.MaxPotentialWeaponRange_ASuW_Land();
					num5 = theContact.MaxPotentialActiveSensorRange_ASuW();
					break;
				}
				if (!num4.HasValue || !num5.HasValue)
				{
					if (!num4.HasValue)
					{
						if (num5.HasValue)
						{
							num3 = num5.Value;
						}
					}
					else
					{
						num3 = num4.Value;
					}
					goto IL_0199;
				}
				if (num4.Value != 0f || num5.Value != 0f)
				{
					num3 = Math.Max(num4.Value, num5.Value);
					goto IL_0199;
				}
				result = false;
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_030d:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_0231:
			try
			{
				if ((theContact.IsLandContact || theContact.IsShipContact) && num2 < (float)theMaxResponseRadius && theContact.HasDetectedEmissions)
				{
					foreach (KeyValuePair<int, EmissionContainer> detectedEmission in theContact.DetectedEmissions)
					{
						Sensor sensor = detectedEmission.Value.get_AssociatedSensor(detectedEmission.Key, myUnit.ParentScen);
						if (sensor == null)
						{
							continue;
						}
						int num6;
						if (!sensor.IsPureIlluminator)
						{
							if (!sensor.IsFireControlRadar)
							{
								continue;
							}
							num6 = 1;
						}
						else
						{
							num6 = 1;
						}
						result = (byte)num6 != 0;
						goto end_IL_0001;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200275", ex2.Message);
				_ = Debugger.IsAttached;
				GameGeneral.WriteExceptionsToLog(ex2);
				ProjectData.ClearProjectError();
			}
			result = false;
			goto end_IL_0001;
			IL_0199:
			if (num3 > 0f && num2 <= Math.Min(num3 * 1.5f, theMaxResponseRadius))
			{
				result = true;
			}
			else
			{
				if (theContact.Type != Contact_Base.ContactType.Air)
				{
					goto IL_0231;
				}
				if (theMaxResponseRadius > 0)
				{
					if (!(num2 < (float)theMaxResponseRadius) || !(Module_Unit.ClosureSpeed(theUnit, theContact, myUnit.CurrentSpeed, myUnit.CurrentHeading) > 0f))
					{
						goto IL_0231;
					}
					result = true;
				}
				else
				{
					if (!(num2 < 30f) || !(Module_Unit.ClosureSpeed(theUnit, theContact, myUnit.CurrentSpeed, myUnit.CurrentHeading) > 0f))
					{
						goto IL_0231;
					}
					result = true;
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100033", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num7;
			if (!Debugger.IsAttached)
			{
				num7 = 0;
			}
			else
			{
				Debugger.Break();
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool ContactIsThreatToMissionUnits(Contact theContact)
	{
		bool result;
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null)
			{
				result = false;
			}
			else if (theContact.ActualUnit == null)
			{
				result = false;
			}
			else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
			{
				result = false;
			}
			else if (myUnit.IsAircraft && !((Aircraft)myUnit).AI.ContactIsRelevantToEscortsLoadout(theContact))
			{
				result = false;
			}
			else
			{
				Weapon longestRange_AAWeapon = myUnit.Weaponry.GetLongestRange_AAWeapon(theContact);
				Weapon longestRange_AGWeapon = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, theContact);
				Weapon longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, theContact);
				Weapon longestRange_ASWWeapon = myUnit.Weaponry.GetLongestRange_ASWWeapon(theContact);
				Mission mission = myUnit.ActiveMissionOrPackage();
				int num = default(int);
				if (mission.MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)mission;
					num = strike.Escort_ResponseRadius;
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout.IsSEAD)
					{
						num = strike.Escort_ResponseRadius_SEAD;
					}
				}
				if (myUnit.Navigator.HasFlightPlan)
				{
					switch (theContact.Type)
					{
					case Contact_Base.ContactType.Air:
						if (longestRange_AAWeapon == null || !(Module_Unit.RangeToUnit_Slant(myUnit, theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_AAWeapon.MaxAirRange), num)))
						{
							break;
						}
						result = true;
						goto end_IL_0001;
					case Contact_Base.ContactType.Submarine:
						if (longestRange_ASWWeapon == null || !(myUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_ASWWeapon.MaxSubsurfaceRange), num)))
						{
							break;
						}
						result = true;
						goto end_IL_0001;
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						if (longestRange_AGWeapon == null || !(myUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_AGWeapon.MaxLandRange), num)))
						{
							break;
						}
						result = true;
						goto end_IL_0001;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.UndeterminedNaval:
					case Contact_Base.ContactType.Mine:
						if (longestRange_ASWeapon == null || !(myUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_ASWeapon.MaxSurfaceRange), num)))
						{
							break;
						}
						result = true;
						goto end_IL_0001;
					}
				}
				ActiveUnit[] array = myUnit.get_UnitSide(SetSideOnly: false).Units.InternalArray();
				int num2 = 0;
				while (true)
				{
					if (num2 < array.Length)
					{
						ActiveUnit activeUnit = array[num2];
						if (activeUnit != null && activeUnit.IsOperating() && !activeUnit.IsGroup && activeUnit.ActiveMissionOrPackage() != null && activeUnit.ActiveMissionOrPackage() == myUnit.ActiveMissionOrPackage() && !activeUnit.AI.IsEscort)
						{
							switch (theContact.Type)
							{
							case Contact_Base.ContactType.Air:
								if (longestRange_AAWeapon != null)
								{
									if (!myUnit.Navigator.HasFlightPlan)
									{
										if (Module_Unit.RangeToUnit_Slant(activeUnit, theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_AAWeapon.MaxAirRange), num))
										{
											result = true;
											break;
										}
									}
									else if (Module_Unit.RangeToUnit_Slant(activeUnit, theContact) < (float)num)
									{
										result = true;
										break;
									}
								}
								goto default;
							case Contact_Base.ContactType.Submarine:
								if (longestRange_ASWWeapon != null)
								{
									if (!myUnit.Navigator.HasFlightPlan)
									{
										if (activeUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_ASWWeapon.MaxSubsurfaceRange), num))
										{
											result = true;
											break;
										}
									}
									else if (activeUnit.RangeToUnit_Horiz(theContact) < (float)num)
									{
										result = true;
										break;
									}
								}
								goto default;
							case Contact_Base.ContactType.Aimpoint:
							case Contact_Base.ContactType.Facility_Fixed:
							case Contact_Base.ContactType.Facility_Mobile:
							case Contact_Base.ContactType.AggregateGroundUnit:
								if (longestRange_AGWeapon != null)
								{
									if (myUnit.Navigator.HasFlightPlan)
									{
										if (activeUnit.RangeToUnit_Horiz(theContact) < (float)num)
										{
											result = true;
											break;
										}
									}
									else if (activeUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_AGWeapon.MaxLandRange), num))
									{
										result = true;
										break;
									}
								}
								goto default;
							case Contact_Base.ContactType.Surface:
							case Contact_Base.ContactType.UndeterminedNaval:
							case Contact_Base.ContactType.Mine:
								if (longestRange_ASWeapon != null)
								{
									if (!myUnit.Navigator.HasFlightPlan)
									{
										if (activeUnit.RangeToUnit_Horiz(theContact) < Math.Min(Math.Max(5f, theContact.ContactRangeModifier() * longestRange_ASWeapon.MaxSurfaceRange), num))
										{
											result = true;
											break;
										}
									}
									else if (!(activeUnit.RangeToUnit_Horiz(theContact) >= (float)num))
									{
										result = true;
										break;
									}
								}
								goto default;
							default:
								if (!ContactIsThreatToUnit(theContact, activeUnit, num))
								{
									goto IL_04c3;
								}
								result = true;
								break;
							}
							break;
						}
						goto IL_04c3;
					}
					result = false;
					break;
					IL_04c3:
					num2 = checked(num2 + 1);
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101352", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsWithinBufferLine(GeoPoint Source, GeoPoint Point_A, GeoPoint Point_B, float Buffer)
	{
		PointF ThePerpendicularPoint = default(PointF);
		MathFunctions.FindDistanceToSegment(new PointF((float)Source.Latitude, (float)Source.Longitude), new PointF((float)Point_A.Latitude, (float)Point_A.Longitude), new PointF((float)Point_B.Latitude, (float)Point_B.Longitude), ref ThePerpendicularPoint);
		return (double)Buffer > MathFunctions.PosDist(Source.Latitude, Source.Longitude, ThePerpendicularPoint.X, ThePerpendicularPoint.Y);
	}

	internal bool IsWithinBufferPath(GeoPoint Source, List<ReferencePoint> Rps, float buffer)
	{
		if (Rps.Count <= 1)
		{
			return false;
		}
		int num = Rps.Count - 2;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (IsWithinBufferLine(Source, new GeoPoint(Rps[num2].Longitude, Rps[num2].Latitude), new GeoPoint(Rps[num2 + 1].Longitude, Rps[num2 + 1].Latitude), buffer))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	public bool IsInsideMiningArea_2nmBuffer()
	{
		if (myUnit.ActiveMissionOrPackage() != null)
		{
			if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
			{
				return false;
			}
			MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
			if (myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public bool IsInsideMiningArea_10nmBuffer()
	{
		if (myUnit.ActiveMissionOrPackage() == null)
		{
			return false;
		}
		if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
		{
			return false;
		}
		MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
		if (myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_10nm_Buffered, ref miningMission.Area_10nm_ChangeCheck, 10, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			return true;
		}
		return false;
	}

	public bool IsInsideMiningArea_NoBuffer()
	{
		if (myUnit.ActiveMissionOrPackage() == null)
		{
			return false;
		}
		if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
		{
			return false;
		}
		MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
		ActiveUnit_Navigator navigator = myUnit.Navigator;
		ref List<ReferencePoint> area = ref miningMission.Area;
		List<ReferencePoint> theArea_Buffer = null;
		if (navigator.IsInsideMissionArea(ref area, ref theArea_Buffer, ref miningMission.Area_ChangeCheck, 0, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			return true;
		}
		return false;
	}

	internal List<Contact> CheckTargetNoNavZoneLogic(HashSet<Contact> myTargets)
	{
		List<Contact> result;
		try
		{
			List<Contact> list = new List<Contact>();
			if (myUnit.get_UnitSide(SetSideOnly: false).NoNavZones.Count > 0)
			{
				ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
				foreach (Contact myTarget in myTargets)
				{
					Contact theTarget = myTarget;
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.TryGetValue(theTarget.ObjectID, out var value))
					{
						if (theTarget == null)
						{
							continue;
						}
						if (TargetingBehaviorForThisTarget(theTarget, targetList) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
						{
							Side side = myUnit.get_UnitSide(SetSideOnly: false);
							ref ActiveUnit theAttacker = ref myUnit;
							TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
							if (side.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker, ref theTarget, ref theTargetBehaviour) > 0)
							{
								continue;
							}
						}
						foreach (NoNavZone noNavZone in myUnit.get_UnitSide(SetSideOnly: false).NoNavZones)
						{
							if (((Zone)noNavZone).get_AffectsThisUnit(myUnit) && noNavZone.Area.Count != 0 && noNavZone.NoFireZone && ((Module_Unit.Unit)theTarget).get_IsInsideThisArea((List<ReferencePoint>)noNavZone.Area, myUnit.ParentScen, UseCache: true))
							{
								list.Add(theTarget);
								myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.AddIfNotExistsElseUpdate(theTarget.ObjectID, value: true);
							}
						}
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.AddIfNotExistsElseUpdate(theTarget.ObjectID, value: false);
					}
					else if (value)
					{
						list.Add(theTarget);
					}
				}
				if (list.Count > 0)
				{
					foreach (Contact item in list)
					{
						DropTarget(item);
						Contact current2 = null;
					}
				}
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2345092384590283", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<Contact>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool ContactIsInsideNoNavZone(Contact theTarget)
	{
		if (theTarget != null)
		{
			if (myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.TryGetValue(theTarget.ObjectID, out var value) && value)
			{
				return true;
			}
			if (TargetingBehaviorForThisTarget(theTarget, _TargetList) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
			{
				Side side = myUnit.get_UnitSide(SetSideOnly: false);
				ref ActiveUnit theAttacker = ref myUnit;
				TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
				if (side.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker, ref theTarget, ref theTargetBehaviour) > 0)
				{
					return false;
				}
			}
			foreach (NoNavZone noNavZone in myUnit.get_UnitSide(SetSideOnly: false).NoNavZones)
			{
				if (((Zone)noNavZone).get_AffectsThisUnit(myUnit) && noNavZone.Area.Count != 0 && noNavZone.NoFireZone && ((Module_Unit.Unit)theTarget).get_IsInsideThisArea((GeoPoint[])noNavZone.Area_AsArray, myUnit.ParentScen, UseCache: true))
				{
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.AddIfNotExists(theTarget.ObjectID, value: true);
					return true;
				}
			}
			myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideNoNavZones.AddIfNotExists(theTarget.ObjectID, value: false);
			return false;
		}
		return false;
	}

	internal PooledSet<Contact> CheckTargetNoNavZoneLogic(Contact[] myTargets)
	{
		PooledSet<Contact> result;
		try
		{
			PooledSet<Contact> pooledSet = new PooledSet<Contact>();
			if (myUnit.get_UnitSide(SetSideOnly: false).NoNavZones.Count > 0)
			{
				_ = _TargetList;
				foreach (Contact contact in myTargets)
				{
					if (ContactIsInsideNoNavZone(contact))
					{
						pooledSet.Add(contact);
					}
				}
				if (pooledSet.Count > 0)
				{
					foreach (Contact item in pooledSet)
					{
						bool? flag = _Threats?.Contains(item);
						if (((!flag) ?? flag) == true)
						{
							DropTarget(item);
							Contact current = null;
						}
					}
				}
			}
			result = pooledSet;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 213598236984367", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new PooledSet<Contact>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledSet<Contact> CheckTargetNoNavZoneLogic(Contact myTarget)
	{
		return CheckTargetNoNavZoneLogic(new Contact[1] { myTarget });
	}

	public bool ContactIsRelevantToFlightOrMission(Contact theContact, Mission theMission, Doctrine._UseShootTourists? CanShootTourists, bool IgnoreContacStance, bool MyUnitIsInsidePatrolArea, bool IgnoreNeutralContacts, Misc.PostureStance? ContactStance, ref string Feedback, ref int FeedbackSeverity, PooledList<(ActiveUnit theAU, Mission AssignedMission)> SameSideOperatingNonEscortUnits = null, bool IgnoreMissionSpecificTargetList = false)
	{
		bool result;
		if (myUnit == null)
		{
			result = false;
		}
		else
		{
			PooledSet<Contact> pooledSet = null;
			try
			{
				if (theMission == null)
				{
					int num;
					if (FeedbackSeverity >= 1)
					{
						num = 0;
					}
					else
					{
						Feedback = "Mission not found!";
						FeedbackSeverity = 1;
						num = 0;
					}
					result = (byte)num != 0;
				}
				else if (theContact.ActualUnit != null)
				{
					if (!theMission.IsActive)
					{
						int num2;
						if (FeedbackSeverity >= 1)
						{
							num2 = 0;
						}
						else
						{
							Feedback = "Mission is currently inactive.";
							FeedbackSeverity = 1;
							num2 = 0;
						}
						result = (byte)num2 != 0;
					}
					else if (theMission.MissionClass == Mission._MissionClass.Support)
					{
						result = false;
					}
					else
					{
						Side side_ = myUnit.get_UnitSide(SetSideOnly: false);
						Misc.PostureStance value;
						if (ContactStance.HasValue)
						{
							value = ContactStance.Value;
						}
						else
						{
							string objectID = theContact.ObjectID;
							if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out value))
							{
								value = theContact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
								myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(theContact.ObjectID, value);
							}
						}
						if (value == Misc.PostureStance.Friendly)
						{
							int num3;
							if (FeedbackSeverity >= 2)
							{
								num3 = 0;
							}
							else
							{
								Feedback = "Contacts are friendly.";
								FeedbackSeverity = 2;
								num3 = 0;
							}
							result = (byte)num3 != 0;
						}
						else if (IgnoreNeutralContacts && value == Misc.PostureStance.Neutral)
						{
							int num4;
							if (FeedbackSeverity >= 3)
							{
								num4 = 0;
							}
							else
							{
								Feedback = "Contacts are neutral.";
								FeedbackSeverity = 3;
								num4 = 0;
							}
							result = (byte)num4 != 0;
						}
						else if (method_3(ref theContact, theMission, CanShootTourists, IgnoreContacStance, MyUnitIsInsidePatrolArea, ref Feedback, ref FeedbackSeverity, side_, value, SameSideOperatingNonEscortUnits, IgnoreMissionSpecificTargetList))
						{
							bool flag;
							result = theMission.MissionClass != Mission._MissionClass.Strike || ((flag = ContactIsRelevantToFlight(theContact)) ? flag : IsWRACoveredForAllFlightPlanTargets());
						}
						else
						{
							int num5;
							if (FeedbackSeverity >= 1)
							{
								num5 = 0;
							}
							else
							{
								Feedback = "No relevant contact types found.";
								FeedbackSeverity = 1;
								num5 = 0;
							}
							result = (byte)num5 != 0;
						}
					}
				}
				else
				{
					int num6;
					if (FeedbackSeverity >= 1)
					{
						num6 = 0;
					}
					else
					{
						Feedback = "Contact's unit does not exist!";
						FeedbackSeverity = 1;
						num6 = 0;
					}
					result = (byte)num6 != 0;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100034", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num7;
				if (!Debugger.IsAttached)
				{
					num7 = 0;
				}
				else
				{
					Debugger.Break();
					num7 = 0;
				}
				result = (byte)num7 != 0;
				ProjectData.ClearProjectError();
			}
			finally
			{
				pooledSet?.Dispose();
			}
		}
		return result;
	}

	public bool IsWRACoveredForAllFlightPlanTargets()
	{
		HashSet<Module_Unit.Unit> targetsFromFlightPlan = MissionPlanner.GetTargetsFromFlightPlan(myUnit);
		try
		{
			if (targetsFromFlightPlan != null)
			{
				foreach (Module_Unit.Unit item in targetsFromFlightPlan)
				{
					PooledList<WeaponSalvo> pooledList = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref myUnit, item);
					int result;
					if (pooledList != null)
					{
						if (pooledList.Count >= 1)
						{
							foreach (WeaponSalvo item2 in pooledList)
							{
								if (item2.WpnQuantityFired < item2.WpnQuantityAssigned)
								{
									pooledList.Dispose();
									return false;
								}
							}
							pooledList?.Dispose();
							continue;
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return true;
	}

	public bool ContactIsRelevantToFlight(Module_Unit.Unit thePassedTarget)
	{
		Mission mission = myUnit.ActiveMissionOrPackage();
		int result;
		if (mission == null)
		{
			result = 0;
		}
		else
		{
			if (mission.MissionClass == Mission._MissionClass.Strike)
			{
				if (!myUnit.Navigator.HasFlightPlan)
				{
					return true;
				}
				bool value = false;
				if (myUnit.Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.TryGetValue(thePassedTarget, out value))
				{
					return value;
				}
				Contact theTarget;
				if (thePassedTarget.IsContact())
				{
					theTarget = (Contact)thePassedTarget;
				}
				else
				{
					theTarget = new Contact((ActiveUnit)thePassedTarget);
					theTarget.set_IDStatus(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: true, Contact_Base.IdentificationStatus.PreciseID);
				}
				string objectID = theTarget.ObjectID;
				string strB = theTarget.ActualUnit?.ObjectID;
				bool flag = true;
				Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
				foreach (Waypoint waypoint in flightPlan)
				{
					if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponLaunch && waypoint.Type != Waypoint.WaypointType.WeaponTarget)
					{
						continue;
					}
					WriteLockedList<Mission.TargeteeringEntry> targeteeringList = waypoint.TargeteeringList;
					if (targeteeringList == null || targeteeringList.Count <= 0 || waypoint.ReferenceWeapon_ID == 0)
					{
						continue;
					}
					Weapon theWeapon = myUnit.ParentScen.Cache_GetWeapon(waypoint.ReferenceWeapon_ID);
					if (theWeapon == null)
					{
						continue;
					}
					int num = waypoint.TargeteeringList.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						Mission.TargeteeringEntry targeteeringEntry = waypoint.TargeteeringList[j];
						if (targeteeringEntry == null || (string.CompareOrdinal(targeteeringEntry.Target_ContactObjectID, objectID) != 0 && string.CompareOrdinal(targeteeringEntry.Target_ActualUnitObjectID, strB) != 0))
						{
							continue;
						}
						Weapon theW = theWeapon;
						GlobalVariables.BooleanObject EmitterClassificable = null;
						Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW, ref EmitterClassificable);
						if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None)
						{
							continue;
						}
						Doctrine doctrine = myUnit.Doctrine;
						Scenario parentScen = myUnit.ParentScen;
						Weapon theWeapon2 = theWeapon;
						int? TargetType_InheritedWeaponQty = null;
						int? TargetType_UnspecifiedWeaponQty = null;
						int? num2 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon2, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
						TargetType_UnspecifiedWeaponQty = num2;
						if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty == -99) : ((bool?)null)) != true)
						{
							TargetType_UnspecifiedWeaponQty = num2;
							if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
							{
								num2 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num2, ref myUnit, ref theTarget, ref theWeapon);
							}
						}
						else
						{
							num2 = myUnit.Weaponry.HowManyOfThisWeapon(theWeapon.DBID) * Doctrine.GetShooterNumber(theWeapon, myUnit, theTarget, wRA_WeaponTargetType);
						}
						if (!thePassedTarget.IsContact())
						{
							foreach (ActiveUnit unit in myUnit.get_UnitSide(SetSideOnly: false).Units)
							{
								if (string.CompareOrdinal(unit.ObjectID, targeteeringEntry.Target_ContactObjectID) == 0 || string.CompareOrdinal(unit.ObjectID, targeteeringEntry.Target_ActualUnitObjectID) == 0)
								{
									flag = unit.IncomingGuidedWeaponsList.Count() < num2.Value;
									myUnit.Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.AddIfNotExistsElseUpdate(thePassedTarget, flag);
									return flag;
								}
							}
							continue;
						}
						Contact value2 = null;
						if (myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(targeteeringEntry.Target_ActualUnitObjectID, out value2) || myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(targeteeringEntry.Target_ContactObjectID, out value2))
						{
							TargetType_UnspecifiedWeaponQty = value2.IncomingGuidedWeapons?.Count();
							int value3 = num2.Value;
							flag = ((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < value3)).Value;
							myUnit.Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.AddIfNotExistsElseUpdate(thePassedTarget, flag);
							return flag;
						}
						foreach (KeyValuePair<string, Contact> contact in myUnit.get_UnitSide(SetSideOnly: false).Contacts)
						{
							if (string.CompareOrdinal(contact.Key, targeteeringEntry.Target_ContactObjectID) == 0)
							{
								TargetType_UnspecifiedWeaponQty = contact.Value.IncomingGuidedWeapons?.Count();
								int value3 = num2.Value;
								flag = ((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < value3)).Value;
								myUnit.Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.AddIfNotExistsElseUpdate(thePassedTarget, flag);
								return flag;
							}
						}
					}
				}
				myUnit.Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.AddIfNotExistsElseUpdate(thePassedTarget, value: false);
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_2(Strike strike_0, ref List<Module_Unit.Unit> list_4, Waypoint waypoint_0)
	{
		double num = 0.5;
		if (strike_0.SpecificTargets != null && strike_0.SpecificTargets.Count > 0)
		{
			if (list_4 == null)
			{
				list_4 = new List<Module_Unit.Unit>(strike_0.SpecificTargets);
			}
			int num2 = list_4.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				Module_Unit.Unit unit = list_4[i];
				if (unit.get_Latitude((GlobalVariables.BooleanObject)null) > waypoint_0.Latitude - num && unit.get_Latitude((GlobalVariables.BooleanObject)null) < waypoint_0.Latitude + num && unit.get_Longitude((GlobalVariables.BooleanObject)null) > waypoint_0.Longitude - num && !(unit.get_Longitude((GlobalVariables.BooleanObject)null) >= waypoint_0.Longitude + num))
				{
					myUnit.Navigator.AddTargeteeringEntryToWP(unit, waypoint_0);
					return true;
				}
			}
		}
		bool result = default(bool);
		return result;
	}

	public bool ContactIsRelevantToMyStrikeMissionSpecificTargetsSettings(ref Contact theContact, Strike theStrike, bool ShootTouristsAllowed)
	{
		if (theContact == null)
		{
			return false;
		}
		if (theStrike == null)
		{
			return true;
		}
		bool flag = theStrike.SpecificTargets == null || theStrike.SpecificTargets.Count == 0;
		int? elementState = myUnit.Doctrine.GetElementState(Doctrine.DoctrineItem_E.StrikeMemberFocus);
		if (elementState.HasValue)
		{
			if (elementState.Value == 2)
			{
				if (flag)
				{
					return false;
				}
			}
			else
			{
				if (elementState.Value != 1)
				{
					return true;
				}
				if (flag)
				{
					if (!theStrike.RTB_When_Target_Destroyed)
					{
						return true;
					}
					return false;
				}
			}
		}
		foreach (Module_Unit.Unit specificTarget in theStrike.SpecificTargets)
		{
			Contact contactForThisUnit = GetContactForThisUnit(specificTarget);
			if (contactForThisUnit == null)
			{
				continue;
			}
			int result;
			if (contactForThisUnit != theContact)
			{
				if (contactForThisUnit.ActualUnit != theContact.ActualUnit)
				{
					continue;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	private bool method_3(ref Contact contact_5, Mission mission_0, Doctrine._UseShootTourists? nullable_4, bool bool_0, bool bool_1, ref string string_0, ref int int_0, Side side_0, Misc.PostureStance postureStance_0, PooledList<(ActiveUnit, Mission)> pooledList_0 = null, bool bool_2 = false)
	{
		bool flag = nullable_4.HasValue && nullable_4.Value == Doctrine._UseShootTourists.Yes;
		switch (mission_0.MissionClass)
		{
		case Mission._MissionClass.Patrol:
		{
			byte? b = (byte?)nullable_4;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
			{
				ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
				Contact theTarget = contact_5;
				Doctrine doctrine = myUnit.Doctrine;
				string Feedback = string.Empty;
				int FeedbackSeverity = 0;
				if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
				{
					if (!myUnit.IsAircraft)
					{
						int result15;
						if (int_0 < 5)
						{
							string_0 = "No relevant contacts can be engaged by the available weapons.";
							int_0 = 5;
							result15 = 0;
						}
						else
						{
							result15 = 0;
						}
						return (byte)result15 != 0;
					}
					Aircraft aircraft = (Aircraft)myUnit;
					if (aircraft.Loadout == null)
					{
						int result16;
						if (int_0 < 6)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 6;
							result16 = 0;
						}
						else
						{
							result16 = 0;
						}
						return (byte)result16 != 0;
					}
					if ((aircraft.Loadout.Role != Loadout.LoadoutRole.Maritime_Surveillance || contact_5.Type != Contact_Base.ContactType.Surface) && (aircraft.Loadout.Role != Loadout.LoadoutRole.ASW_Patrol || contact_5.Type != Contact_Base.ContactType.Surface) && (aircraft.Loadout.Role != Loadout.LoadoutRole.Area_Surveillance || !contact_5.IsLandContact))
					{
						int result17;
						if (int_0 < 6)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 6;
							result17 = 0;
						}
						else
						{
							result17 = 0;
						}
						return (byte)result17 != 0;
					}
				}
			}
			else
			{
				switch (((Patrol)mission_0).Type)
				{
				case GlobalVariables.PatrolType.ASW:
				{
					Contact_Base.ContactType type7 = contact_5.Type;
					if (type7 - 3 <= Contact_Base.ContactType.Missile)
					{
						ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
						Contact theTarget3 = contact_5;
						Doctrine doctrine3 = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (!weaponry3.HaveAvailableWeaponSuitableForThisTarget(theTarget3, CheckWRA: true, doctrine3, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Unknown)
						{
							return false;
						}
						break;
					}
					int result20;
					if (int_0 < 5)
					{
						string_0 = "No relevant contact types found.";
						int_0 = 5;
						result20 = 0;
					}
					else
					{
						result20 = 0;
					}
					return (byte)result20 != 0;
				}
				case GlobalVariables.PatrolType.ASuW_Naval:
				{
					Contact_Base.ContactType type8 = contact_5.Type;
					if (type8 != Contact_Base.ContactType.Surface && type8 != Contact_Base.ContactType.UndeterminedNaval)
					{
						int result30;
						if (int_0 < 5)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 5;
							result30 = 0;
						}
						else
						{
							result30 = 0;
						}
						return (byte)result30 != 0;
					}
					ActiveUnit_Weaponry weaponry7 = myUnit.Weaponry;
					Contact theTarget7 = contact_5;
					Doctrine doctrine5 = myUnit.Doctrine;
					string Feedback = string.Empty;
					int FeedbackSeverity = 0;
					if (!weaponry7.HaveAvailableWeaponSuitableForThisTarget(theTarget7, CheckWRA: true, doctrine5, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Unknown)
					{
						return false;
					}
					break;
				}
				case GlobalVariables.PatrolType.AAW:
					switch (contact_5.Type)
					{
					default:
					{
						int result22;
						if (int_0 < 5)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 5;
							result22 = 0;
						}
						else
						{
							result22 = 0;
						}
						return (byte)result22 != 0;
					}
					case Contact_Base.ContactType.Orbital:
						if (myUnit.IsAircraft)
						{
							Loadout loadout = ((Aircraft)myUnit).Loadout;
							bool? flag3 = ((loadout != null) ? new bool?(loadout.Role == Loadout.LoadoutRole.AntiSatellite_Intercept) : ((bool?)null));
							if (((!flag3) ?? flag3) == true)
							{
								return false;
							}
						}
						break;
					case Contact_Base.ContactType.Missile:
						if (((Weapon)contact_5.ActualUnit).IsAAWCapable)
						{
							int result21;
							if (int_0 < 5)
							{
								string_0 = "No relevant contact types found.";
								int_0 = 5;
								result21 = 0;
							}
							else
							{
								result21 = 0;
							}
							return (byte)result21 != 0;
						}
						break;
					case Contact_Base.ContactType.Air:
						break;
					}
					break;
				case GlobalVariables.PatrolType.ASuW_Land:
				{
					Contact_Base.ContactType type6 = contact_5.Type;
					if (type6 != Contact_Base.ContactType.Aimpoint && type6 - 7 > Contact_Base.ContactType.Missile && type6 != Contact_Base.ContactType.AggregateGroundUnit)
					{
						int result19;
						if (int_0 < 5)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 5;
							result19 = 0;
						}
						else
						{
							result19 = 0;
						}
						return (byte)result19 != 0;
					}
					break;
				}
				case GlobalVariables.PatrolType.ASuW_Mixed:
					switch (contact_5.Type)
					{
					case Contact_Base.ContactType.Surface:
					{
						ActiveUnit_Weaponry weaponry6 = myUnit.Weaponry;
						Contact theTarget6 = contact_5;
						Doctrine doctrine4 = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (!weaponry6.HaveAvailableWeaponSuitableForThisTarget(theTarget6, CheckWRA: true, doctrine4, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Unknown)
						{
							return false;
						}
						break;
					}
					default:
					{
						int result29;
						if (int_0 < 5)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 5;
							result29 = 0;
						}
						else
						{
							result29 = 0;
						}
						return (byte)result29 != 0;
					}
					case Contact_Base.ContactType.UndeterminedNaval:
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						break;
					}
					break;
				case GlobalVariables.PatrolType.SEAD:
				{
					bool flag4 = false;
					bool flag5 = false;
					Patrol patrol = (Patrol)mission_0;
					if (flag)
					{
						if (contact_5.IsAutoDetection)
						{
							return true;
						}
					}
					else if (patrol.ProsecutionArea != null && patrol.ProsecutionArea.Count > 0)
					{
						if (((Module_Unit.Unit)contact_5).get_IsInsideThisArea(patrol.ProsecutionArea, myUnit.ParentScen, UseCache: true))
						{
							return true;
						}
					}
					else if (patrol.PatrolArea != null && patrol.PatrolArea.Count > 0 && ((Module_Unit.Unit)contact_5).get_IsInsideThisArea(patrol.ProsecutionArea, myUnit.ParentScen, UseCache: true))
					{
						return true;
					}
					if (contact_5.HasPreciselyDetectedEmissions)
					{
						float? num2 = contact_5.MaxPotentialActiveSensorRange_AAW();
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() >= 10f) : ((bool?)null)) == true)
						{
							flag4 = true;
						}
					}
					if (!flag4)
					{
						IEnumerator<KeyValuePair<int, EmissionContainer>> enumerator = contact_5.DetectedEmissions.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<int, EmissionContainer> current = enumerator.Current;
								Sensor sensor = current.Value.get_AssociatedSensor(current.Key, myUnit.ParentScen);
								int num3;
								if (!sensor.IsGNSSJammer)
								{
									if (!sensor.IsOECM)
									{
										continue;
									}
									num3 = 1;
								}
								else
								{
									num3 = 1;
								}
								flag5 = (byte)num3 != 0;
								break;
							}
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
					if (!flag4 && !flag5)
					{
						int result23;
						if (int_0 < 5)
						{
							string_0 = "No relevant contact types found (identified jammers or AAW radars with range greater than 10nm).";
							int_0 = 5;
							result23 = 0;
						}
						else
						{
							result23 = 0;
						}
						return (byte)result23 != 0;
					}
					switch (contact_5.IDStatus)
					{
					case Contact_Base.IdentificationStatus.Unknown:
					case Contact_Base.IdentificationStatus.KnownDomain:
					{
						bool flag11 = false;
						if (contact_5.DetectedEmissions.Count != 0)
						{
							List<KeyValuePair<int, EmissionContainer>> list = new List<KeyValuePair<int, EmissionContainer>>(contact_5.DetectedEmissions.Count);
							foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_5.DetectedEmissions)
							{
								list.Add(detectedEmission);
							}
							foreach (KeyValuePair<int, EmissionContainer> item in list)
							{
								if (!(item.Value.Age <= 30f))
								{
									continue;
								}
								Sensor sensor2 = item.Value.get_AssociatedSensor(item.Key, myUnit.ParentScen);
								int num5;
								if (!sensor2.IsPureIlluminator)
								{
									if (!sensor2.IsFireControlRadar)
									{
										continue;
									}
									num5 = 1;
								}
								else
								{
									num5 = 1;
								}
								flag11 = (byte)num5 != 0;
								break;
							}
						}
						if (!flag11)
						{
							int result28;
							if (int_0 < 6)
							{
								string_0 = "No relevant contact types found.";
								int_0 = 6;
								result28 = 0;
							}
							else
							{
								result28 = 0;
							}
							return (byte)result28 != 0;
						}
						break;
					}
					case Contact_Base.IdentificationStatus.KnownType:
					{
						if (contact_5.ActualUnit.IsFacility)
						{
							IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = ((Facility)contact_5.ActualUnit).MobileUnitCategory();
							if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
							{
								int result26;
								if (int_0 < 6)
								{
									string_0 = "No relevant contact types found.";
									int_0 = 6;
									result26 = 0;
								}
								else
								{
									result26 = 0;
								}
								return (byte)result26 != 0;
							}
						}
						bool flag10 = false;
						ActiveUnit_Weaponry weaponry5 = myUnit.Weaponry;
						Contact theTarget5 = contact_5;
						Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
						PooledList<Weapon> pooledList2 = weaponry5.SuitableWeaponsForThisTarget(theTarget5, ref GunStrafingSalvo);
						if (pooledList2 != null)
						{
							foreach (Weapon item2 in pooledList2)
							{
								if (!item2.IsAntiradar)
								{
									flag10 = true;
									break;
								}
							}
							pooledList2.Dispose();
						}
						if (!flag10 && contact_5.DetectedEmissions.Count == 0)
						{
							int result27;
							if (int_0 < 6)
							{
								string_0 = "No relevant contact types found.";
								int_0 = 6;
								result27 = 0;
							}
							else
							{
								result27 = 0;
							}
							return (byte)result27 != 0;
						}
						break;
					}
					case Contact_Base.IdentificationStatus.KnownClass:
					case Contact_Base.IdentificationStatus.PreciseID:
					{
						float? num2 = contact_5.MaxPotentialWeaponRange_AAW();
						bool? flag7;
						bool? flag6 = (flag7 = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() < 1f)));
						bool? obj;
						if (flag6.HasValue && flag7 != true)
						{
							obj = false;
						}
						else
						{
							num2 = contact_5.MaxPotentialActiveSensorRange_AAW();
							bool? flag8;
							flag6 = (flag8 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() < 10f) : ((bool?)null)));
							obj = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) & flag7));
						}
						bool? flag3 = obj;
						int num4;
						if ((!flag3) ?? false)
						{
							num4 = 0;
						}
						else
						{
							if (!flag5 && flag3.HasValue)
							{
								int result24;
								if (int_0 < 6)
								{
									string_0 = "No relevant contact types found.";
									int_0 = 6;
									result24 = 0;
								}
								else
								{
									result24 = 0;
								}
								return (byte)result24 != 0;
							}
							num4 = 0;
						}
						bool flag9 = (byte)num4 != 0;
						ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
						Contact theTarget4 = contact_5;
						Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
						PooledList<Weapon> pooledList = weaponry4.SuitableWeaponsForThisTarget(theTarget4, ref GunStrafingSalvo);
						if (pooledList != null)
						{
							foreach (Weapon item3 in pooledList)
							{
								if (!item3.IsAntiradar)
								{
									flag9 = true;
									break;
								}
							}
							pooledList.Dispose();
						}
						if (!flag9 && contact_5.DetectedEmissions.Count == 0)
						{
							int result25;
							if (int_0 < 6)
							{
								string_0 = "No relevant contact types found.";
								int_0 = 6;
								result25 = 0;
							}
							else
							{
								result25 = 0;
							}
							return (byte)result25 != 0;
						}
						break;
					}
					}
					break;
				}
				case GlobalVariables.PatrolType.SeaControl:
				{
					Contact_Base.ContactType type5 = contact_5.Type;
					if (type5 - 2 <= Contact_Base.ContactType.Surface)
					{
						ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
						Contact theTarget2 = contact_5;
						Doctrine doctrine2 = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (!weaponry2.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Unknown)
						{
							return false;
						}
						break;
					}
					int result18;
					if (int_0 < 5)
					{
						string_0 = "No relevant contact types found.";
						int_0 = 5;
						result18 = 0;
					}
					else
					{
						result18 = 0;
					}
					return (byte)result18 != 0;
				}
				}
			}
			Patrol patrol2 = (Patrol)mission_0;
			bool flag12 = patrol2.TargetIsInRelevantMissionSpace(contact_5);
			bool flag13 = bool_1 || (patrol2.HasProsecutionArea && ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(patrol2.ProsecutionArea, myUnit.ParentScen, UseCache: true));
			bool flag14 = patrol2.get_InvestigateOutsidePatrolArea(myUnit.ParentScen) && !patrol2.HasProsecutionArea;
			bool flag15 = patrol2.get_InvestigateWithinWeaponRange(myUnit.ParentScen);
			Weapon weapon = null;
			float num6 = 0f;
			if (flag15)
			{
				weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(contact_5);
				if (weapon != null)
				{
					num6 = weapon.get_MaxRangeForThisTarget(myUnit, contact_5, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
				}
			}
			if (!flag12)
			{
				if (!flag14 && !flag15)
				{
					int result31;
					if (int_0 < 7)
					{
						if (!patrol2.HasProsecutionArea)
						{
							string_0 = "No relevant contact types found inside the patrol area.";
						}
						else
						{
							string_0 = "No relevant contact types found inside the patrol or prosecution areas.";
						}
						int_0 = 7;
						result31 = 0;
					}
					else
					{
						result31 = 0;
					}
					return (byte)result31 != 0;
				}
				if (!flag14)
				{
					if (flag15 && (num6 == 0f || myUnit.RangeToUnit_Horiz(contact_5) > num6))
					{
						int result32;
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found in the patrol/prosecution area or within weapon range.";
							int_0 = 7;
							result32 = 0;
						}
						else
						{
							result32 = 0;
						}
						return (byte)result32 != 0;
					}
				}
				else if (flag15)
				{
					if (num6 < 1f)
					{
						int result33;
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found within weapon range of the patrol/prosecution area.";
							int_0 = 7;
							result33 = 0;
						}
						else
						{
							result33 = 0;
						}
						return (byte)result33 != 0;
					}
					List<Geopoint_Struct> BufferedArea_GeoPoints = new List<Geopoint_Struct>();
					List<ReferencePoint> theArea = patrol2.PatrolArea;
					if (patrol2.HasProsecutionArea)
					{
						theArea = patrol2.ProsecutionArea;
					}
					float proximityThreshold_nm = num6;
					List<ReferencePoint> ChangeCheck_RefPoints = null;
					ActiveUnit_Navigator.CalculateAreaWithThresholdAdded_NM(proximityThreshold_nm, ref theArea, ref BufferedArea_GeoPoints, ref ChangeCheck_RefPoints);
					if (!((Module_Unit.Unit)contact_5).get_IsInsideThisArea(BufferedArea_GeoPoints, myUnit.ParentScen, UseCache: false))
					{
						int result34;
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found within weapon range of the patrol/prosecution area.";
							int_0 = 7;
							result34 = 0;
						}
						else
						{
							result34 = 0;
						}
						return (byte)result34 != 0;
					}
				}
			}
			if (!flag13)
			{
				if (postureStance_0 == Misc.PostureStance.Unfriendly)
				{
					int result35;
					if (int_0 < 7)
					{
						string_0 = "Unit not on station.";
						int_0 = 7;
						result35 = 0;
					}
					else
					{
						result35 = 0;
					}
					return (byte)result35 != 0;
				}
				if (flag12)
				{
					float num7 = 0f;
					float num8 = 0f;
					ActiveUnit_Weaponry weaponry8 = myUnit.Weaponry;
					Contact theTarget8 = contact_5;
					Doctrine doctrine6 = myUnit.Doctrine;
					string Feedback = string.Empty;
					int FeedbackSeverity = 0;
					if (!weaponry8.HaveAvailableWeaponSuitableForThisTarget(theTarget8, CheckWRA: true, doctrine6, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
					{
						int result36;
						if (int_0 < 7)
						{
							string_0 = "Unit not on station.";
							int_0 = 7;
							result36 = 0;
						}
						else
						{
							result36 = 0;
						}
						return (byte)result36 != 0;
					}
					Weapon weapon2 = null;
					num8 = myUnit.Weaponry.MostSuitableWeaponForThisTarget(contact_5, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine)?.get_MaxRangeForThisTarget(myUnit, contact_5, CheckWRA: true, myUnit.Doctrine, ManualFire: false) ?? 0f;
					if (!patrol2.HasProsecutionArea || !GetMissionStateFlag(2u))
					{
						float? num9 = (myUnit.IsAircraft ? patrol2.AttackDistance_Aircraft : (myUnit.IsSubmarine ? patrol2.AttackDistance_Submarine : patrol2.AttackDistance_Ship));
						num7 = (num9.HasValue ? ((float)((double?)num9 + (double)num8 * 0.8).Value) : ((float)Math.Max(10f + num8, (double)num8 * 1.2)));
						if (myUnit.RangeToUnit_Horiz(contact_5) > num7)
						{
							int result37;
							if (int_0 < 7)
							{
								string_0 = "Unit not on station.";
								int_0 = 7;
								result37 = 0;
							}
							else
							{
								result37 = 0;
							}
							return (byte)result37 != 0;
						}
					}
				}
			}
			if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(contact_5.ObjectID, out var value))
			{
				value = contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
				myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(contact_5.ObjectID, postureStance_0);
			}
			if (value != Misc.PostureStance.Neutral && value != Misc.PostureStance.Unknown)
			{
				if (myUnit.Weaponry.IsGuidingWeaponsOntoThisContact(contact_5))
				{
					return true;
				}
				Weapon theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(contact_5, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true);
				if (theW == null)
				{
					return false;
				}
				Weapon theW2 = theW;
				GlobalVariables.BooleanObject EmitterClassificable = null;
				Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref contact_5, theW2, ref EmitterClassificable);
				Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theW, ref contact_5, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
				Doctrine doctrine7 = myUnit.Doctrine;
				Scenario parentScen = theW.ParentScen;
				Weapon theWeapon = theW;
				int? TargetType_InheritedWeaponQty = null;
				int? TargetType_UnspecifiedWeaponQty = null;
				TargetType_UnspecifiedWeaponQty = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine7, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
				if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == 0)) == true)
				{
					return false;
				}
			}
			return true;
		}
		case Mission._MissionClass.Strike:
		{
			Strike theStrikeMission = (Strike)mission_0;
			int result3;
			if (IsEscort)
			{
				if (myUnit.IsAircraft)
				{
					bool flag2 = ((Aircraft)myUnit).AI.ContactIsRelevantToEscortsLoadout(contact_5);
					byte? b = (byte?)nullable_4;
					bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if ((flag3 ?? true) && flag2 && flag3.HasValue)
					{
						return true;
					}
					if (!flag2)
					{
						int result2;
						if (int_0 < 5)
						{
							string_0 = "No contact is relevant for the escort's loadout.";
							int_0 = 5;
							result2 = 0;
						}
						else
						{
							result2 = 0;
						}
						return (byte)result2 != 0;
					}
				}
				int theMaxResponseRadius = theStrikeMission.Escort_ResponseRadius;
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout.IsSEAD)
				{
					theMaxResponseRadius = theStrikeMission.Escort_ResponseRadius_SEAD;
				}
				if (pooledList_0 == null)
				{
					for (int i = side_0.Units.Count - 1; i >= 0; i += -1)
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = side_0.Units[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							continue;
						}
						bool? flag3 = activeUnit?.IsGroup;
						if (((!flag3) ?? flag3) == true && activeUnit.IsOperating() && !activeUnit.AI.IsEscort)
						{
							Mission mission = activeUnit.ActiveMissionOrPackage();
							if (mission != null && mission == mission_0 && ContactIsThreatToUnit(contact_5, activeUnit, theMaxResponseRadius))
							{
								return true;
							}
						}
					}
					result3 = 1;
				}
				else
				{
					(ActiveUnit, Mission)[] array = pooledList_0.InternalArray();
					int num = pooledList_0.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						var (theUnit, mission2) = array[j];
						if (mission2 != null && mission2 == mission_0 && ContactIsThreatToUnit(contact_5, theUnit, theMaxResponseRadius))
						{
							return true;
						}
					}
					result3 = 1;
				}
			}
			else
			{
				if (!bool_0 && !CanMissionTargetThisContactBasedOnPostureStance(ref theStrikeMission, postureStance_0))
				{
					int result4;
					if (int_0 < 6)
					{
						string_0 = "No contact with relevant posture stance found .";
						int_0 = 6;
						result4 = 0;
					}
					else
					{
						result4 = 0;
					}
					return (byte)result4 != 0;
				}
				switch (((Strike)mission_0).Type)
				{
				default:
					result3 = 1;
					break;
				case Strike.StrikeType.Air_Intercept:
				{
					Contact_Base.ContactType type4 = contact_5.Type;
					if (type4 != Contact_Base.ContactType.Air)
					{
						if (type4 != Contact_Base.ContactType.Missile)
						{
							if (type4 != Contact_Base.ContactType.Orbital)
							{
								int result14;
								if (int_0 < 7)
								{
									string_0 = "No relevant contact found for this mission type (Air Intercept).";
									int_0 = 7;
									result14 = 0;
								}
								else
								{
									result14 = 0;
								}
								return (byte)result14 != 0;
							}
							if (!myUnit.IsAircraft)
							{
								result3 = 1;
								break;
							}
							if (((Aircraft)myUnit).Loadout.Role != Loadout.LoadoutRole.AntiSatellite_Intercept)
							{
								return false;
							}
							result3 = 1;
							break;
						}
						return !((Weapon)contact_5.ActualUnit).IsAAWCapable;
					}
					return true;
				}
				case Strike.StrikeType.Land_Strike:
				{
					Contact_Base.ContactType type2 = contact_5.Type;
					if (type2 != Contact_Base.ContactType.Aimpoint && type2 - 7 > Contact_Base.ContactType.Missile && type2 != Contact_Base.ContactType.AggregateGroundUnit)
					{
						int result8;
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 7;
							result8 = 0;
						}
						else
						{
							result8 = 0;
						}
						return (byte)result8 != 0;
					}
					int result10;
					if (!bool_2)
					{
						if (!ContactIsRelevantToMyStrikeMissionSpecificTargetsSettings(ref contact_5, theStrikeMission, flag))
						{
							int result9;
							if (int_0 < 9)
							{
								string_0 = "The mission can only target pre-planned targets, and no targets remain.";
								int_0 = 9;
								result9 = 0;
							}
							else
							{
								result9 = 0;
							}
							return (byte)result9 != 0;
						}
						result10 = 1;
					}
					else
					{
						result10 = 1;
					}
					return (byte)result10 != 0;
				}
				case Strike.StrikeType.Maritime_Strike:
				{
					Contact_Base.ContactType type3 = contact_5.Type;
					if (type3 != Contact_Base.ContactType.Surface && type3 - 4 > Contact_Base.ContactType.Missile)
					{
						int result11;
						if (int_0 < 7)
						{
							string_0 = "No relevant contact types found.";
							int_0 = 7;
							result11 = 0;
						}
						else
						{
							result11 = 0;
						}
						return (byte)result11 != 0;
					}
					int result12;
					if (bool_2)
					{
						result12 = 1;
					}
					else
					{
						if (!ContactIsRelevantToMyStrikeMissionSpecificTargetsSettings(ref contact_5, theStrikeMission, flag))
						{
							int result13;
							if (int_0 < 9)
							{
								string_0 = "The mission can only target pre-planned targets, and no targets remain.";
								int_0 = 9;
								result13 = 0;
							}
							else
							{
								result13 = 0;
							}
							return (byte)result13 != 0;
						}
						result12 = 1;
					}
					return (byte)result12 != 0;
				}
				case Strike.StrikeType.Sub_Strike:
				{
					Contact_Base.ContactType type = contact_5.Type;
					if (type - 3 <= Contact_Base.ContactType.Missile)
					{
						int result5;
						if (bool_2)
						{
							result5 = 1;
						}
						else
						{
							if (!ContactIsRelevantToMyStrikeMissionSpecificTargetsSettings(ref contact_5, theStrikeMission, flag))
							{
								int result6;
								if (int_0 < 9)
								{
									string_0 = "The mission can only target pre-planned targets, and no targets remain.";
									int_0 = 9;
									result6 = 0;
								}
								else
								{
									result6 = 0;
								}
								return (byte)result6 != 0;
							}
							result5 = 1;
						}
						return (byte)result5 != 0;
					}
					int result7;
					if (int_0 < 7)
					{
						string_0 = "No relevant contact types found.";
						int_0 = 7;
						result7 = 0;
					}
					else
					{
						result7 = 0;
					}
					return (byte)result7 != 0;
				}
				}
			}
			return (byte)result3 != 0;
		}
		default:
		{
			bool result = default(bool);
			return result;
		}
		}
	}

	public void InitializeCycleFerry()
	{
		SetMissionStateFlag(4u, theValue: true);
	}

	public void ChangeCycleLeg()
	{
		SetMissionStateFlag(4u, !GetMissionStateFlag(4u));
	}

	public void DeterminePrimaryTarget_SEAD_Prioritize(List<Contact> TargetList, int MaxNumberOfFlightsEngagingContact, int MaxNumberOfFlightsInvestigatingContact, float theWingmanEngageDistance, float elapsedtime)
	{
		try
		{
			if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				return;
			}
			List<Contact> list = (from theC in TargetList.Where([SpecialName] (Contact theC) =>
				{
					bool? obj;
					bool? flag3;
					if (theC.IsAir_Missile_Orbital_Contact)
					{
						obj = false;
					}
					else
					{
						bool? obj2;
						if (!theC.HasPreciselyDetectedEmissions)
						{
							obj2 = true;
						}
						else
						{
							float? num = theC.MaxPotentialActiveSensorRange_AAW();
							obj2 = (num.HasValue ? new bool?(num.GetValueOrDefault() > 0f) : ((bool?)null));
						}
						bool? flag = obj2;
						bool? flag2 = obj2;
						if (flag2.HasValue && flag == true)
						{
							obj = true;
						}
						else
						{
							float? num = theC.MaxPotentialWeaponRange_AAW();
							flag2 = (flag3 = (num.HasValue ? new bool?(num.GetValueOrDefault() > 0f) : ((bool?)null)));
							obj = ((!flag2.HasValue) ? ((bool?)null) : ((flag3 == true) | flag));
						}
					}
					flag3 = obj;
					return flag3 == true;
				})
				orderby theC.MaxPotentialWeaponRange_AAW() * 2f + theC.MaxPotentialActiveSensorRange_AAW() descending
				select theC).ToList();
			if (!Information.IsNothing((object)list) && list.Count > 0)
			{
				DeterminePrimaryTarget_PatrolAndEscortLogic(myUnit, list, MaxNumberOfFlightsEngagingContact, MaxNumberOfFlightsInvestigatingContact, theWingmanEngageDistance, elapsedtime);
			}
			else
			{
				PrimaryTarget = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100035", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private HashSet<Contact> method_4()
	{
		return new HashSet<Contact>(Targets_ReadOnly);
	}

	private void method_5()
	{
		try
		{
			WeaponSalvo[] array = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.ToArray();
			int num = array.Length;
			if (num <= 0)
			{
				return;
			}
			Lazy<HashSet<Contact>> lazy = new Lazy<HashSet<Contact>>(method_4);
			for (int i = array.Length - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo;
				try
				{
					int num2 = i;
					if (num == 0)
					{
						continue;
					}
					if (num - 1 < i)
					{
						num2 = num - 1;
					}
					weaponSalvo = array[num2];
					goto IL_00af;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200425", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				continue;
				IL_00af:
				if (weaponSalvo == null || weaponSalvo.ShootersList == null)
				{
					continue;
				}
				WeaponSalvo.Shooter[] array2 = weaponSalvo.ShootersList.ToArray();
				int num3 = array2.Length;
				if (num3 <= 0)
				{
					continue;
				}
				for (int j = num3 - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter;
					try
					{
						if (num3 == 0)
						{
							continue;
						}
						if (j < 0)
						{
							break;
						}
						shooter = array2[j];
						goto IL_014d;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200426", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					continue;
					IL_014d:
					if (shooter != null && Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0 && shooter.QuantityAssigned > shooter.QuantityFired && !lazy.Value.Contains(weaponSalvo.Target))
					{
						TargetingEntry targetingEntry = new TargetingEntry();
						targetingEntry.Target = weaponSalvo.Target;
						targetingEntry.Behavior = TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
						if (_TargetList == null)
						{
							_TargetList = new ObservableDictionary<string, TargetingEntry>();
						}
						if (!_TargetList.ContainsKey(targetingEntry.Target.ObjectID))
						{
							AddTargetList_Threadsafe(targetingEntry.Target.ObjectID, targetingEntry);
						}
					}
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 200640", ex6.Message);
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal AmbiguityLevel GetTargetAmbiguity(Contact Target, float MaxAmbiguity)
	{
		try
		{
			int result;
			if (Target.UncertaintyArea == null)
			{
				result = 5;
			}
			else
			{
				if (Target.UncertaintyArea.Count != 0)
				{
					float num = Module_Contact.DownRangeAmbiguity(Target, myUnit);
					float num2 = Module_Contact.CrossRangeAmbiguity(Target, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					if ((num > MaxAmbiguity || num2 > MaxAmbiguity) && Target.HeldFor < 15f)
					{
						return AmbiguityLevel.ExtremelyAmbiguous;
					}
					int result5;
					if (!(num > MaxAmbiguity / 3f))
					{
						if (!(num2 > MaxAmbiguity / 3f))
						{
							int result4;
							if (!(num > MaxAmbiguity / 9f))
							{
								if (!(num2 > MaxAmbiguity / 9f))
								{
									int result3;
									if (!(num > MaxAmbiguity / 27f))
									{
										if (!(num2 > MaxAmbiguity / 27f))
										{
											int result2;
											if (!(num > 0f))
											{
												if (!(num2 > 0f))
												{
													return AmbiguityLevel.NoAmbiguity;
												}
												result2 = 4;
											}
											else
											{
												result2 = 4;
											}
											return (AmbiguityLevel)result2;
										}
										result3 = 3;
									}
									else
									{
										result3 = 3;
									}
									return (AmbiguityLevel)result3;
								}
								result4 = 2;
							}
							else
							{
								result4 = 2;
							}
							return (AmbiguityLevel)result4;
						}
						result5 = 1;
					}
					else
					{
						result5 = 1;
					}
					return (AmbiguityLevel)result5;
				}
				result = 5;
			}
			return (AmbiguityLevel)result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public virtual bool DropTargetDueToRearwardFiringDoctrine(Contact theContact, Weapon theWeapon = null)
	{
		if (theContact == null)
		{
			return false;
		}
		int? elementState = myUnit.Doctrine.GetElementState(Doctrine.DoctrineItem_E.MissileEngagement_FireOverTheShoulder);
		int? num = elementState;
		if ((num.HasValue ? new bool?(num == 1) : ((bool?)null)) != true)
		{
			num = elementState;
			if ((num.HasValue ? new bool?(num == 2) : ((bool?)null)) == true)
			{
				if (theContact.Type != Contact_Base.ContactType.Air)
				{
					return false;
				}
			}
			else
			{
				num = elementState;
				if ((num.HasValue ? new bool?(num == 3) : ((bool?)null)) != true)
				{
					return false;
				}
				if (theContact.Type != Contact_Base.ContactType.Missile)
				{
					return false;
				}
			}
		}
		else if (theContact.Type != Contact_Base.ContactType.Air && theContact.Type != Contact_Base.ContactType.Missile)
		{
			return false;
		}
		float bearing = Module_Unit.BearingToUnit_True(myUnit, theContact, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		int result;
		if (!theContact.HeadingIsKnown)
		{
			result = 0;
		}
		else
		{
			if (Misc.RelativeAngleBetweenBearings(bearing, theContact.CurrentHeading) < 90f)
			{
				return true;
			}
			if (theWeapon == null)
			{
				theWeapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theContact, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true);
			}
			if (theWeapon == null)
			{
				result = 0;
			}
			else if (!theWeapon.IsGuidedWeapon())
			{
				result = 0;
			}
			else
			{
				Geopoint_Struct geopoint_Struct = Weapon_Navigator.ComputeInterceptPoint_Theoretical(theWeapon, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theContact);
				if (geopoint_Struct.HasZeroCoords)
				{
					result = 0;
				}
				else
				{
					if (Misc.RelativeAngleBetweenBearings(Module_Unit.BearingToPoint_True(myUnit, geopoint_Struct.Latitude, geopoint_Struct.Longitude, GlobalVariables.ObjectTrue), theContact.CurrentHeading) < 90f)
					{
						return true;
					}
					result = 0;
				}
			}
		}
		return (byte)result != 0;
	}

	public virtual void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
		if (!EvaluateTargets_Enabled)
		{
			return;
		}
		try
		{
			CheckPossibleABMOrASATEngagement = false;
			if (myUnit == null || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork))
			{
				return;
			}
			_DoNotTargetList.Clear();
			method_5();
			_ = IsInsidePatrolArea_10nmBuffer;
			if (PrimaryTarget != null)
			{
				if (PrimaryTarget.get_IsDestroyed(myUnit.ParentScen))
				{
					DropTarget(PrimaryTarget);
				}
				else if (PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					Side side = myUnit.get_UnitSide(SetSideOnly: false);
					ref ActiveUnit theAttacker = ref myUnit;
					Contact theTarget = PrimaryTarget;
					TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
					int num = side.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker, ref theTarget, ref theTargetBehaviour);
					PrimaryTarget = theTarget;
					if (num == 0)
					{
						DropTarget(PrimaryTarget);
					}
				}
			}
			bool flag = myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && ((Patrol)myUnit.ActiveMissionOrPackage()).get_InvestigateOutsidePatrolArea(myUnit.ParentScen);
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				((Patrol)myUnit.ActiveMissionOrPackage()).get_InvestigateWithinWeaponRange(myUnit.ParentScen);
			}
			if (myUnit.IsOnActiveStrike)
			{
				Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
				Contact contact = null;
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
					contact = GetContactForThisUnit(specificTarget);
					if (contact == null)
					{
						continue;
					}
					if (IsEscort)
					{
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact theTarget2 = contact;
						Doctrine doctrine = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
						{
							continue;
						}
					}
					if (!IsTargetingThisContact(contact))
					{
						TargetThisContact(contact, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			Contact[] array = Targets_ReadOnly;
			if (array.Length <= 0)
			{
				return;
			}
			PooledList<(Contact, string, TargetingEntry._TargetingBehavior)> pooledList = new PooledList<(Contact, string, TargetingEntry._TargetingBehavior)>();
			bool hasValue;
			Doctrine._UseShootTourists value = default(Doctrine._UseShootTourists);
			if (hasValue = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).HasValue)
			{
				value = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			}
			Misc.ShuffleArray(ref array);
			ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
			Contact[] array2 = array;
			Weapon longestRange_ASWeapon = default(Weapon);
			Weapon longestRange_AGWeapon = default(Weapon);
			for (int FeedbackSeverity = 0; FeedbackSeverity < array2.Length; FeedbackSeverity = checked(FeedbackSeverity + 1))
			{
				Contact theTarget3 = array2[FeedbackSeverity];
				if (theTarget3 == null)
				{
					continue;
				}
				TargetingEntry._TargetingBehavior targetingBehavior = TargetingBehaviorForThisTarget(theTarget3, targetList);
				if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(theTarget3.ObjectID, out var value2))
				{
					value2 = theTarget3.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(theTarget3.ObjectID, value2);
				}
				if (value2 == Misc.PostureStance.Friendly)
				{
					pooledList.Add((theTarget3, "The target is friendly", targetingBehavior));
					continue;
				}
				if (theTarget3.get_IsDestroyed(myUnit.ParentScen))
				{
					if (!myUnit.Sensory.IsIlluminatingThisContact(theTarget3))
					{
						pooledList.Add((theTarget3, "The target is destroyed", targetingBehavior));
						continue;
					}
				}
				else if ((Immediately || myUnit.ParentScen.FifthSecondIsChangingOnThisPulse) && myUnit.IsAircraft)
				{
					if (theTarget3.Type == Contact_Base.ContactType.Submarine)
					{
						ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
						Contact theTarget4 = theTarget3;
						Doctrine doctrine2 = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity2 = 0;
						if (!weaponry2.HaveAvailableWeaponSuitableForThisTarget(theTarget4, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false) && value2 != Misc.PostureStance.Unknown && !myUnit.Sensory.IsIlluminatingThisContact(theTarget3))
						{
							pooledList.Add((theTarget3, "No suitable weapons available or allowed (Doctrine/WCS/WRA)", targetingBehavior));
							continue;
						}
					}
					else if (theTarget3.isSurfaceOrLandContact && targetingBehavior == TargetingEntry._TargetingBehavior.ManualTargeted)
					{
						ActiveUnit_Weaponry weaponry3 = myUnit.Weaponry;
						Contact theTarget5 = theTarget3;
						Doctrine doctrine3 = myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity2 = 0;
						if (!weaponry3.HaveAvailableWeaponSuitableForThisTarget(theTarget5, CheckWRA: true, doctrine3, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false) && value2 != Misc.PostureStance.Unknown && !myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget)
						{
							pooledList.Add((theTarget3, "No suitable weapons available or allowed (Doctrine/WCS/WRA)", targetingBehavior));
							continue;
						}
					}
				}
				bool? flag2 = ((theTarget3.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : theTarget3.ActualUnit?.IsWeapon);
				if ((flag2 ?? true) && ((Weapon)theTarget3.ActualUnit).IsMobileDecoy && flag2.HasValue)
				{
					bool flag3 = false;
					Sensor[] sensors_Cached = theTarget3.ActualUnit.Sensors_Cached;
					for (int FeedbackSeverity2 = 0; FeedbackSeverity2 < sensors_Cached.Length; FeedbackSeverity2 = checked(FeedbackSeverity2 + 1))
					{
						if (sensors_Cached[FeedbackSeverity2].IsOECM)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						pooledList.Add((theTarget3, "Target is a non-jamming decoy (waste of ammo)", targetingBehavior));
						continue;
					}
				}
				if ((Immediately || myUnit.ParentScen.FifthSecondIsChangingOnThisPulse) && (!myUnit.Navigator.HasFlightPlan || array.Count() > 1) && TargetIsWasteOfAmmo(theTarget3) && (targetingBehavior == TargetingEntry._TargetingBehavior.AutoTargeted || targetingBehavior == TargetingEntry._TargetingBehavior.AutoSelfDefence))
				{
					pooledList.Add((theTarget3, "Target is a waste of ammo", targetingBehavior));
					continue;
				}
				switch (theTarget3.Type)
				{
				case Contact_Base.ContactType.Installation:
				case Contact_Base.ContactType.AirBase:
				case Contact_Base.ContactType.NavalBase:
				case Contact_Base.ContactType.MobileGroup:
					pooledList.Add((theTarget3, "Cannot target installation complexes directly (target individual facilities instead)", targetingBehavior));
					continue;
				case Contact_Base.ContactType.Sonobuoy:
					pooledList.Add((theTarget3, "Cannot target sonobuoys", targetingBehavior));
					continue;
				}
				if (!theTarget3.IsClassifiedFalseTarget)
				{
					if (theTarget3.IsSubmergedContact && (myUnit.IsShip || myUnit.IsAircraft) && SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)theTarget3).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget3).get_Latitude((GlobalVariables.BooleanObject)null)))
					{
						pooledList.Add((theTarget3, "Target is a submerged contact under ice", targetingBehavior));
						continue;
					}
					if ((Immediately || myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse) && value2 <= Misc.PostureStance.Friendly)
					{
						switch (targetingBehavior)
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							pooledList.Add((theTarget3, "Target is friendly or neutral and has no manually-assigned weapons to it", targetingBehavior));
							break;
						case TargetingEntry._TargetingBehavior.AutoTargeted:
						case TargetingEntry._TargetingBehavior.AutoSelfDefence:
							pooledList.Add((theTarget3, "Target is friendly or neutral and has no manually-assigned weapons to it", targetingBehavior));
							break;
						}
					}
					if (myUnit.Weaponry.ContactIsWithinSelfDefenceRange(theTarget3))
					{
						if (targetingBehavior == TargetingEntry._TargetingBehavior.AutoSelfDefence)
						{
							continue;
						}
					}
					else if (targetingBehavior == TargetingEntry._TargetingBehavior.AutoSelfDefence)
					{
						TargetThisContact(theTarget3, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
					byte? b;
					if (myUnit.IsOnActiveStrike && (Strike)myUnit.ActiveMissionOrPackage() != null)
					{
						Strike strike2 = (Strike)myUnit.ActiveMissionOrPackage();
						if (!IsEscort && !theTarget3.get_IsSpecificTargetForThisStrike(strike2) && strike2.get_FocusEntirelyOnStrikeTargets(myUnit))
						{
							if (myUnit.IsAircraft && myUnit.Navigator.HasFlightPlan)
							{
								pooledList.Add((theTarget3, "Unit is on strike mission and this contact is not an explicit target", targetingBehavior));
								continue;
							}
							flag2 = theTarget3.ActualUnit?.IsAerospaceUnit;
							if (((!flag2) ?? flag2) == true)
							{
								b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b != 1)) == true && targetingBehavior == TargetingEntry._TargetingBehavior.AutoTargeted)
								{
									pooledList.Add((theTarget3, string.Empty, targetingBehavior));
									continue;
								}
							}
						}
					}
					if ((Immediately || myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse) && myUnit.IsOnActivePatrol() && !theTarget3.IsAir_Missile_Submarine_Contact)
					{
						Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						if (patrol.HasProsecutionArea)
						{
							(Contact, Patrol) key = (theTarget3, patrol);
							if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsidePatrolAreas.TryGetValue(key, out var value3))
							{
								value3 = ((Module_Unit.Unit)theTarget3).get_IsInsideThisArea(patrol.PatrolArea, myUnit.ParentScen, UseCache: true);
								myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsidePatrolAreas.AddIfNotExists(key, value3);
							}
							if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideProsecutionAreas.TryGetValue(key, out var value4))
							{
								value4 = ((Module_Unit.Unit)theTarget3).get_IsInsideThisArea(patrol.ProsecutionArea, myUnit.ParentScen, UseCache: true);
								myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsideProsecutionAreas.AddIfNotExists(key, value4);
							}
							if (!value3 && !value4 && targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !myUnit.Sensory.IsIlluminatingThisContact(theTarget3))
							{
								if (!patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
								{
									pooledList.Add((theTarget3, "The target is outside the unit's patrol station/prosecution area)", targetingBehavior));
									continue;
								}
								if (longestRange_ASWeapon == null)
								{
									longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, theTarget3);
								}
								if (longestRange_AGWeapon == null)
								{
									longestRange_AGWeapon = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, theTarget3);
								}
								if (!TargetIsEligibleBasedOnWeaponRange(theTarget3, value2, hasValue, value, myUnit.Weaponry.GetLongestRange_AAWeapon(theTarget3), myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, theTarget3), myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, theTarget3), myUnit.Weaponry.GetLongestRange_ASWWeapon(theTarget3)))
								{
									pooledList.Add((theTarget3, "The target is outside the unit's station/prosecution area and outside weapon range", targetingBehavior));
									continue;
								}
							}
						}
						else if (!flag && theTarget3.Type != Contact_Base.ContactType.Missile)
						{
							(Contact, Patrol) key2 = (theTarget3, patrol);
							if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsidePatrolAreas.TryGetValue(key2, out var value5))
							{
								value5 = ((Module_Unit.Unit)theTarget3).get_IsInsideThisArea(patrol.PatrolArea, myUnit.ParentScen, UseCache: true);
								myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactsInsidePatrolAreas.AddIfNotExists(key2, value5);
							}
							if (!value5 && targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !myUnit.Sensory.IsIlluminatingThisContact(theTarget3))
							{
								if (!patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
								{
									pooledList.Add((theTarget3, "The target is outside the unit's station area, and the unit is not authorize to prosecute outside the area", targetingBehavior));
									continue;
								}
								if (longestRange_ASWeapon == null)
								{
									longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, theTarget3);
								}
								if (longestRange_AGWeapon == null)
								{
									longestRange_AGWeapon = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, theTarget3);
								}
								if (!TargetIsEligibleBasedOnWeaponRange(theTarget3, value2, hasValue, value, myUnit.Weaponry.GetLongestRange_AAWeapon(theTarget3), myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, theTarget3), myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, theTarget3), myUnit.Weaponry.GetLongestRange_ASWWeapon(theTarget3)))
								{
									pooledList.Add((theTarget3, "The target is outside the unit's station area and outside weapon range, and the unit is not authorize to prosecute outside the area", targetingBehavior));
									continue;
								}
							}
						}
					}
					if ((Immediately || myUnit.ParentScen.FifthSecondIsChangingOnThisPulse) && targetingBehavior == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						Side side2 = myUnit.get_UnitSide(SetSideOnly: false);
						ref ActiveUnit theAttacker2 = ref myUnit;
						TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
						if (side2.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker2, ref theTarget3, ref theTargetBehaviour) == 0 && theTarget3.IncomingGuidedWeapons.Length == 0)
						{
							pooledList.Add((theTarget3, "The target is not auto-targeted, and no outstanding weapons or assignments against it exist", targetingBehavior));
							continue;
						}
					}
					b = (byte?)theTarget3.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) != true)
					{
						if ((Immediately || myUnit.ParentScen.FifthSecondIsChangingOnThisPulse) && IsEscort)
						{
							ActiveUnit_Weaponry weaponry4 = myUnit.Weaponry;
							Contact theTarget6 = theTarget3;
							Doctrine doctrine4 = myUnit.Doctrine;
							string Feedback = string.Empty;
							int FeedbackSeverity3 = 0;
							if (!weaponry4.HaveAvailableWeaponSuitableForThisTarget(theTarget6, CheckWRA: true, doctrine4, ref Feedback, ref FeedbackSeverity3, HumanFeedBackNeeded: false))
							{
								pooledList.Add((theTarget3, "Unit is escort and has no suitable weapons for this target", targetingBehavior));
								continue;
							}
							if (value2 == Misc.PostureStance.Friendly && (targetingBehavior == TargetingEntry._TargetingBehavior.AutoTargeted || targetingBehavior == TargetingEntry._TargetingBehavior.AutoSelfDefence))
							{
								pooledList.Add((theTarget3, "Target is a friendly", targetingBehavior));
								continue;
							}
						}
						if ((Immediately || myUnit.ParentScen.MinuteIsChangingOnThisPulse) && myUnit.IsSubmarine && theTarget3.HeadingIsKnown && theTarget3.SpeedIsKnown && !CanCatchUpWithTarget(theTarget3, AddTarget: false))
						{
							pooledList.Add((theTarget3, "Cannot intercept target at max speed at current depth", targetingBehavior));
							continue;
						}
						if (theTarget3.UncertaintyArea != null && GetTargetAmbiguity(theTarget3, 100f) == AmbiguityLevel.ExtremelyAmbiguous)
						{
							pooledList.Add((theTarget3, "Contact is extremely ambiguous", targetingBehavior));
							continue;
						}
						if (!CheckPossibleABMOrASATEngagement && (theTarget3.IsBallisticTarget() || theTarget3.IsSatellite))
						{
							ActiveUnit_Weaponry weaponry5 = myUnit.Weaponry;
							Contact theTarget7 = theTarget3;
							Doctrine doctrine5 = myUnit.Doctrine;
							string Feedback = string.Empty;
							int FeedbackSeverity3 = 0;
							if (weaponry5.HaveAvailableWeaponSuitableForThisTarget(theTarget7, CheckWRA: true, doctrine5, ref Feedback, ref FeedbackSeverity3, HumanFeedBackNeeded: false))
							{
								CheckPossibleABMOrASATEngagement = true;
							}
						}
						if (DropTargetDueToRearwardFiringDoctrine(theTarget3))
						{
							if (!_DoNotTargetList.Contains(theTarget3))
							{
								_DoNotTargetList.Add(theTarget3);
							}
							if (!myUnit.Weaponry.IsGuidingWeaponsOntoThisContact(theTarget3, ForceTargetCheck: true))
							{
								pooledList.Add((theTarget3, "AAW rearward engagement doctrine prevents firing at this target", targetingBehavior));
							}
						}
					}
					else
					{
						pooledList.Add((theTarget3, "Target assessed as destroyed", targetingBehavior));
					}
				}
				else
				{
					pooledList.Add((theTarget3, "Contact is classified as a false-target", targetingBehavior));
				}
			}
			Geopoint_Struct theLocation = new Geopoint_Struct(myUnit.get_Longitude(GlobalVariables.ObjectTrue), myUnit.get_Latitude(GlobalVariables.ObjectTrue));
			foreach (var (contact2, text, targetingBehavior2) in pooledList)
			{
				DropTarget(contact2);
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = "";
					if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						text2 = " (" + myUnit.UnitClass + ")";
					}
					myUnit.AddMessage(myUnit.Name + text2 + " is dropping " + contact2.Name + " from its target list (Reason: " + text + ")", myUnit.Name + text2 + " dropped target " + contact2.Name, LoggedMessage.MessageType.UnitAI, 5, theLocation);
					if ((uint)(targetingBehavior2 - 1) <= 1u)
					{
						Notification_Bark.Create_UnitBehaviour(myUnit, "Dropping target: " + contact2.Name + " (" + text + ")", Color.Yellow);
					}
				}
			}
			pooledList.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200328", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool TargetIsEligibleBasedOnWeaponRange(Contact theContact, Misc.PostureStance theStance, bool Doctrine_ShootTourists_HasValue, Doctrine._UseShootTourists Doctrine_ShootTourists_Value, Weapon LongestWeapon_AAW, Weapon LongestWeapon_ASuW, Weapon LongestWeapon_AG, Weapon LongestWeapon_ASW)
	{
		bool result;
		try
		{
			int num;
			switch (theContact.Type)
			{
			default:
				num = 0;
				break;
			case Contact_Base.ContactType.Air:
				if (!myUnit.IsSubmarine)
				{
					if (LongestWeapon_AAW == null || !(Module_Unit.RangeToUnit_Slant(myUnit, theContact) < theContact.ContactRangeModifier() * LongestWeapon_AAW.MaxAirRange))
					{
						goto IL_05ae;
					}
					result = true;
				}
				else
				{
					if (theContact.ActualUnit == null)
					{
						goto IL_05ae;
					}
					if (!theContact.ActualUnit.IsAircraft)
					{
						num = 0;
						break;
					}
					if (theContact.IDStatus < Contact_Base.IdentificationStatus.KnownType)
					{
						goto IL_05ae;
					}
					Aircraft._AircraftType type = ((Aircraft)theContact.ActualUnit).Type;
					if ((uint)(type - 6001) > 1u || (theStance != Misc.PostureStance.Hostile && theStance != Misc.PostureStance.Unfriendly))
					{
						goto IL_05ae;
					}
					if (LongestWeapon_AAW == null)
					{
						num = 0;
						break;
					}
					float distance_nm4 = theContact.ContactRangeModifier() * LongestWeapon_AAW.MaxAirRange;
					if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), distance_nm4))
					{
						num = 0;
						break;
					}
					result = true;
				}
				goto end_IL_0001;
			case Contact_Base.ContactType.Missile:
				if (myUnit.IsSubmarine)
				{
					result = false;
				}
				else
				{
					if (LongestWeapon_AAW == null)
					{
						num = 0;
						break;
					}
					if (!(Module_Unit.RangeToUnit_Slant(myUnit, theContact) < theContact.ContactRangeModifier() * LongestWeapon_AAW.MaxAirRange))
					{
						goto IL_05ae;
					}
					result = true;
				}
				goto end_IL_0001;
			case Contact_Base.ContactType.Submarine:
				if (LongestWeapon_ASW == null)
				{
					num = 0;
					break;
				}
				if (theContact.IsClassifiedFalseTarget)
				{
					result = false;
				}
				else if (!myUnit.IsSubmarine)
				{
					if (!myUnit.IsFacility && !myUnit.IsShip)
					{
						if (SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)))
						{
							result = false;
						}
						else
						{
							float distance_nm = theContact.ContactRangeModifier() * LongestWeapon_ASW.MaxSubsurfaceRange;
							int num2;
							if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), distance_nm))
							{
								if (!Patrol_ShouldEngageWithinRange(theContact, Doctrine_ShootTourists_Value))
								{
									goto IL_05ae;
								}
								num2 = 1;
							}
							else
							{
								num2 = 1;
							}
							result = (byte)num2 != 0;
						}
					}
					else if (SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)))
					{
						result = false;
					}
					else
					{
						float maxSubsurfaceRange = LongestWeapon_ASW.MaxSubsurfaceRange;
						int num3;
						if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), maxSubsurfaceRange))
						{
							if (!Patrol_ShouldEngageWithinRange(theContact, Doctrine_ShootTourists_Value))
							{
								goto IL_05ae;
							}
							num3 = 1;
						}
						else
						{
							num3 = 1;
						}
						result = (byte)num3 != 0;
					}
				}
				else
				{
					float maxSubsurfaceRange2 = LongestWeapon_ASW.MaxSubsurfaceRange;
					if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), maxSubsurfaceRange2) && !Patrol_ShouldEngageWithinRange(theContact, Doctrine_ShootTourists_Value))
					{
						num = 0;
						break;
					}
					result = true;
				}
				goto end_IL_0001;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.UndeterminedNaval:
			{
				bool flag = false;
				if (Patrol_ShouldEngageWithinRange(theContact, Doctrine_ShootTourists_Value))
				{
					flag = true;
				}
				if ((!Doctrine_ShootTourists_HasValue || Doctrine_ShootTourists_Value != Doctrine._UseShootTourists.Yes) && !flag)
				{
					num = 0;
					break;
				}
				if (LongestWeapon_ASuW == null)
				{
					goto IL_05ae;
				}
				if (!myUnit.IsSubmarine)
				{
					if (!myUnit.IsFacility && !myUnit.IsShip)
					{
						float distance_nm2 = theContact.ContactRangeModifier() * LongestWeapon_ASuW.MaxSurfaceRange;
						if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), distance_nm2))
						{
							goto IL_05ae;
						}
						result = true;
					}
					else
					{
						float maxSurfaceRange = LongestWeapon_ASuW.MaxSurfaceRange;
						if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), maxSurfaceRange))
						{
							goto IL_05ae;
						}
						result = true;
					}
				}
				else
				{
					float maxSurfaceRange2 = LongestWeapon_ASuW.MaxSurfaceRange;
					if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), maxSurfaceRange2))
					{
						goto IL_05ae;
					}
					result = true;
				}
				goto end_IL_0001;
			}
			case Contact_Base.ContactType.Orbital:
			{
				if (!Doctrine_ShootTourists_HasValue || Doctrine_ShootTourists_Value != Doctrine._UseShootTourists.Yes)
				{
					goto IL_05ae;
				}
				ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
				Doctrine doctrine = myUnit.Doctrine;
				string Feedback = string.Empty;
				int FeedbackSeverity = 0;
				if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theContact, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
				{
					goto IL_05ae;
				}
				if (LongestWeapon_AAW == null)
				{
					num = 0;
					break;
				}
				if (!(Module_Unit.RangeToUnit_Slant(myUnit, theContact) < theContact.ContactRangeModifier() * LongestWeapon_AAW.MaxAirRange))
				{
					goto IL_05ae;
				}
				result = true;
				goto end_IL_0001;
			}
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.AggregateGroundUnit:
				if (Patrol_ShouldEngageWithinRange(theContact, Doctrine_ShootTourists_Value))
				{
					result = true;
				}
				else
				{
					if (!Doctrine_ShootTourists_HasValue)
					{
						num = 0;
						break;
					}
					if (Doctrine_ShootTourists_Value != Doctrine._UseShootTourists.Yes || LongestWeapon_AG == null)
					{
						goto IL_05ae;
					}
					if (!myUnit.IsSubmarine && !myUnit.IsFacility && !myUnit.IsShip)
					{
						float distance_nm3 = LongestWeapon_AG.MaxLandRange * theContact.ContactRangeModifier();
						if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), distance_nm3))
						{
							goto IL_05ae;
						}
						result = true;
					}
					else
					{
						float maxLandRange = LongestWeapon_AG.MaxLandRange;
						if (!Geodesic_Haversine.PointIsWithinDistanceFromPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), maxLandRange))
						{
							num = 0;
							break;
						}
						result = true;
					}
				}
				goto end_IL_0001;
			case Contact_Base.ContactType.Torpedo:
				{
					if (!myUnit.IsShip || LongestWeapon_ASW == null || !(Module_Unit.RangeToUnit_Slant(myUnit, theContact) < LongestWeapon_ASW.MaxSubsurfaceRange * 2f))
					{
						goto IL_05ae;
					}
					result = true;
					goto end_IL_0001;
				}
				IL_05ae:
				num = 0;
				break;
			}
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 341165438765", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool Patrol_ShouldEngageWithinRange(Contact theContact, Doctrine._UseShootTourists? CanShootTourists)
	{
		Mission mission = myUnit.ActiveMissionOrPackage();
		if (mission == null)
		{
			return false;
		}
		if (!myUnit.IsOnActivePatrol(mission))
		{
			goto IL_010e;
		}
		Patrol patrol = (Patrol)mission;
		Weapon weapon = null;
		float num = 0f;
		int result;
		if (!patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
		{
			result = 0;
		}
		else
		{
			bool isInsidePatrolArea_10nmBuffer = IsInsidePatrolArea_10nmBuffer;
			string Feedback = "";
			int FeedbackSeverity = 99;
			if (!ContactIsRelevantToFlightOrMission(theContact, patrol, CanShootTourists, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: false, null, ref Feedback, ref FeedbackSeverity))
			{
				return false;
			}
			weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(theContact);
			if (weapon == null)
			{
				result = 0;
			}
			else
			{
				num = weapon.get_MaxRangeForThisTarget(myUnit, theContact, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
				if (!(num > 0f))
				{
					goto IL_010e;
				}
				List<Geopoint_Struct> BufferedArea_GeoPoints = new List<Geopoint_Struct>();
				List<ReferencePoint> theArea = patrol.PatrolArea;
				if (patrol.HasProsecutionArea)
				{
					theArea = patrol.ProsecutionArea;
				}
				float proximityThreshold_nm = num;
				List<ReferencePoint> ChangeCheck_RefPoints = null;
				ActiveUnit_Navigator.CalculateAreaWithThresholdAdded_NM(proximityThreshold_nm, ref theArea, ref BufferedArea_GeoPoints, ref ChangeCheck_RefPoints);
				if (((Module_Unit.Unit)theContact).get_IsInsideThisArea(BufferedArea_GeoPoints, myUnit.ParentScen, UseCache: false))
				{
					return true;
				}
				result = 0;
			}
		}
		goto IL_010f;
		IL_010e:
		result = 0;
		goto IL_010f;
		IL_010f:
		return (byte)result != 0;
	}

	internal bool CanCatchUpWithTarget(Contact theTarget, bool AddTarget)
	{
		bool result;
		try
		{
			Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
			double out_lat = default(double);
			double out_lon = default(double);
			if (Information.IsNothing((object)weapon))
			{
				out_lat = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				out_lon = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				goto IL_012c;
			}
			float num = myUnit.RangeToUnit_Horiz(theTarget);
			if (num < weapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, myUnit.Doctrine, ManualFire: false))
			{
				result = true;
			}
			else
			{
				Weapon._WeaponType type = weapon.Type;
				if ((uint)(type - 2001) > 1u && type != Weapon._WeaponType.Gun && (uint)(type - 6001) > 2u)
				{
					out_lat = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
					out_lon = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					goto IL_012c;
				}
				float num2 = weapon.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
				if (num > num2)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num - num2, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
					goto IL_012c;
				}
				result = true;
			}
			goto end_IL_0001;
			IL_012c:
			result = (CanInterceptTargetAtCurrentAltSpeed(out_lat, out_lon, theTarget.CurrentHeading, theTarget.CurrentSpeed, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), myUnit.CurrentHeading, null, IgnoreMotionVectors: false, AddTarget) ? true : false);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200591", "");
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

	public virtual void EvaluateUnitCargoStatus(float elapsedTime)
	{
		if (!myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse || myUnit.IsAircraft || !(myUnit is ICargoHost) || myUnit.OnboardCargo.Count() <= 0)
		{
			return;
		}
		bool flag = false;
		List<CargoMission> list = new List<CargoMission>();
		Cargo[] theArray = myUnit.OnboardCargo;
		Cargo[] theArray2 = new Cargo[0];
		if (myUnit.HasDockFacilities || myUnit.HasAirFacilities)
		{
			ReadOnlyCollection<Mission> missions = myUnit.get_UnitSide(SetSideOnly: false).Missions;
			foreach (Mission item in missions)
			{
				if (item.MissionClass != Mission._MissionClass.Cargo)
				{
					continue;
				}
				bool flag2 = false;
				CargoMission cargoMission = (CargoMission)item;
				List<ActiveUnit> list2 = cargoMission.get_AssignedUnits_Cached(myUnit.ParentScen);
				foreach (ActiveUnit item2 in list2)
				{
					if (item2.IsAircraft)
					{
						if (((Aircraft)item2).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) == myUnit)
						{
							flag2 = true;
						}
					}
					else
					{
						int num;
						if (item2 != myUnit)
						{
							if (item2.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != myUnit)
							{
								goto IL_013e;
							}
							num = 1;
						}
						else
						{
							num = 1;
						}
						flag2 = (byte)num != 0;
					}
					goto IL_013e;
					IL_013e:
					if (flag2)
					{
						list.Add(cargoMission);
						break;
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (CargoMission item3 in list)
				{
					foreach (CargoManifestItem item4 in item3.CargoToUnload)
					{
						if (item4.quantity == 0)
						{
							continue;
						}
						int num2 = item4.quantity;
						for (int i = theArray.Count() - 1; i >= 0; i += -1)
						{
							Cargo cargo = theArray[i];
							if (Operators.CompareString(cargo.CargoObjectID, item4.ObjectID, false) == 0)
							{
								if ((item3.AllowSelfDeliveryFromCargo || item3.AllowAllSelfDelivery) && cargo.CargoObjectActiveUnit != null && cargo.CargoObjectActiveUnit.IsVehicle && cargo.CargoObjectActiveUnit.ActiveMissionOrPackage() == item3)
								{
									ArrayExtensions.Add(ref theArray2, cargo);
								}
								ArrayExtensions.Remove(ref theArray, cargo);
								num2--;
								if (num2 < 1)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
		Cargo[] array = theArray2;
		foreach (Cargo theAC in array)
		{
			ArrayExtensions.Add(ref theArray, theAC);
		}
		Cargo[] array2 = theArray;
		foreach (Cargo cargo2 in array2)
		{
			if (!cargo2.WantsToUnload())
			{
				continue;
			}
			ActiveUnit cargoObjectActiveUnit = cargo2.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit == null)
			{
				continue;
			}
			if (!myUnit.IsShip && !myUnit.IsSubmarine)
			{
				if (myUnit.IsFixedFacility && ((Platform)cargoObjectActiveUnit).RepresentsMobileGroundUnit)
				{
					Cargo.UnloadSingleCargoAtLocation(myUnit, ref myUnit.OnboardCargo, cargo2, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
					flag = true;
				}
			}
			else if (cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsAmphibiousSeaworthy)
			{
				ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
				DockFacility bestFacility = null;
				if (dockingOps.CanHostThisBoat(cargoObjectActiveUnit, ref bestFacility))
				{
					ArrayExtensions.Remove(ref myUnit.OnboardCargo, cargo2);
					cargoObjectActiveUnit.DockingOps.UnloadFromCargo();
					myUnit.DockingOps.AddThisBoat(cargoObjectActiveUnit);
					flag = true;
				}
				else if (myUnit.IsShip && ((Ship)myUnit).Flags.CanLaunchCargoDirectlyToSea)
				{
					Cargo.UnloadSingleCargoAtLocation(myUnit, ref myUnit.OnboardCargo, cargo2, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
					flag = true;
				}
			}
			if (flag)
			{
				break;
			}
		}
	}

	protected void CheckIfReachedPatrolAreaThiSortie()
	{
		if (!GetMissionStateFlag(2u))
		{
			SetMissionStateFlag(2u, IsInsidePatrolArea_10nmBuffer);
		}
	}

	public virtual void EvaluateUnitStatus(float elapsedTime, bool ForceFuelStateCheck, bool ForceWeaponStateCheck)
	{
		try
		{
			if (myUnit == null)
			{
				return;
			}
			EvaluateUnitCargoStatus(elapsedTime);
			if (myUnit.IsDrone() && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				ActiveUnit.DroneAutonomyLevel autonomyLevel = myUnit.AutonomyLevel;
				if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering)
				{
					if (myUnit.CommStuff.TimeOffComms > 0f)
					{
						return;
					}
				}
				else if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.ChangeableMission)
				{
					if (myUnit.CommStuff.TimeOffComms > 0f)
					{
						if (myUnit.CommStuff.TimeOffComms <= 30f)
						{
							myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.HoldingPattern_CommsLost;
							return;
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CommsLost;
						myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
						return;
					}
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_CommsLost)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
					}
				}
			}
			WeaponThreat = null;
			byte? b = (byte?)myUnit.Doctrine.get_AutoEvade(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				if (myUnit.ParentScen.AnyActiveWeaponEffectThreats)
				{
					Module_Unit.Unit unit = DetermineWeaponEffectThreat();
					if (unit != null)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects;
						WeaponThreat = unit;
						return;
					}
				}
				if (!Information.IsNothing((object)_PrimaryThreat))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					myUnit.Status = myUnit._StatusBefore_EngagedDefensive;
				}
			}
			ActiveUnit theUnit = myUnit;
			Exception ThrownError = null;
			if (Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
			}
			else
			{
				if (myUnit.IsRTB)
				{
					return;
				}
				if (myUnit.IsAircraft && myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
				{
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = myUnit.Weaponry.IsWinchesterOrShotgun();
					if ((activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun) && ((Aircraft)myUnit).AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
					{
						return;
					}
				}
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse() || myUnit.Navigator.HasRoadSystemPlottedCourse())
				{
					bool? obj;
					if (Information.IsNothing((object)PrimaryTarget))
					{
						obj = false;
					}
					else
					{
						b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
						obj = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					}
					bool? flag = obj;
					if (((!flag) ?? flag) == true)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
				}
				if (!Information.IsNothing((object)PrimaryTarget))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					return;
				}
				if (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup && myUnit.get_ParentGroup(UsingMissionPlanner: false).Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (!myUnit.IsGroup && !myUnit.IsWeapon && myUnit.ActiveMissionOrPackage() != null && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					if (!myUnit.ActiveMissionOrPackage().IsActive)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else
					{
						if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							CheckIfReachedPatrolAreaThiSortie();
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
							return;
						}
						if (!myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							return;
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200345", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Contact GetNearestTarget(List<Contact> TargetList)
	{
		Contact result;
		try
		{
			Contact contact = null;
			double num = 20000.0;
			foreach (Contact Target in TargetList)
			{
				double num2 = Module_Unit.RangeToUnit_Slant(myUnit, Target);
				if (num2 < num)
				{
					contact = Target;
					num = num2;
				}
			}
			result = contact;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100038", "");
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

	internal float? AdjustAltitudeForMinelaying(float? altitudeValueCheck = null)
	{
		float? result = null;
		try
		{
			Weapon[] array = (from theW in myUnit.Weaponry.AllDistinctWeaponsAboard_Actual()
				where theW.IsMine
				select theW).ToArray();
			if (array.Count() == 0)
			{
				return null;
			}
			Weapon[] array2 = array;
			float num2 = default(float);
			float num3 = default(float);
			foreach (Weapon weapon in array2)
			{
				if (myUnit.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(myUnit.ParentScen.DBConnection) && weapon.MaxLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_AGL == 0f)
				{
					num2 = weapon.MaxLaunchAlt_ASL;
					num3 = weapon.MinLaunchAlt_ASL;
				}
				else
				{
					num2 = weapon.MaxLaunchAlt_AGL;
					num3 = weapon.MinLaunchAlt_AGL;
				}
			}
			if (altitudeValueCheck.HasValue)
			{
				float? num4 = altitudeValueCheck;
				if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() > num2)) == true)
				{
					result = num2 - 10f;
				}
				num4 = altitudeValueCheck;
				if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() < num3)) == true)
				{
					result = num3 + 10f;
				}
			}
			else
			{
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > num2 || myUnit.DesiredAltitude > num2)
				{
					result = num2 - 10f;
				}
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < num3 || myUnit.DesiredAltitude < num3)
				{
					result = num3 + 10f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100039", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsOnMiningRun(float elapsedTime)
	{
		bool result;
		try
		{
			if (myUnit != null)
			{
				if (myUnit.IsMineLayingPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMineLayingPlatform();
				}
				if (myUnit.IsMineLayingPlatform_ThisPulse != 0)
				{
					if (myUnit.ActiveMissionOrPackage() == null)
					{
						result = false;
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
					{
						result = false;
					}
					else if (!myUnit.ActiveMissionOrPackage().IsActive)
					{
						result = false;
					}
					else
					{
						MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
						bool flag = false;
						if ((from theW in myUnit.Weaponry.AllDistinctWeaponsAboard_Actual()
							where theW.IsMine
							select theW).ToArray().Count() > 0)
						{
							if (Module_Unit.IsOverLand(myUnit))
							{
								flag = false;
							}
							else if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
							{
								switch (miningMission.MovementStyle)
								{
								case Patrol.PatrolMovementStyle.RandomWithinArea:
								{
									if (miningMission.Area.Count > 2)
									{
										if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area, ref miningMission.Area_ChangeCheck, 0, IgnoreTimeToNextEvaluation: true, IsProsecutionArea: false))
										{
											break;
										}
										int num;
										if (myUnit.Navigator.PlottedCourse.Count() <= 0 && !myUnit.IsGroupMember())
										{
											if (miningMission.MovementStyle != Patrol.PatrolMovementStyle.RepeatableLoop)
											{
												break;
											}
											num = 1;
										}
										else
										{
											num = 1;
										}
										flag = (byte)num != 0;
										break;
									}
									Waypoint waypoint = ((myUnit.Navigator.PlottedCourse.Count() > 0) ? myUnit.Navigator.PlottedCourse[0] : null);
									if (!myUnit.Navigator.PreviousWaypointType.HasValue)
									{
										if (waypoint != null && myUnit.Navigator.HaveReachedPoint(waypoint, elapsedTime, waypoint.OvershootWaypoint) && (myUnit.Navigator.PreviousWaypointType.HasValue || (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PreviousWaypointType.HasValue)))
										{
											flag = true;
										}
									}
									else
									{
										flag = true;
									}
									break;
								}
								case Patrol.PatrolMovementStyle.RepeatableLoop:
									flag = ((myUnit.Navigator.SupportMission_NextRefPoint != miningMission.Area[0]) ? true : false);
									break;
								}
							}
						}
						if (flag && myUnit.AI.MiningInfo == null)
						{
							myUnit.AI.MiningInfo = new MiningMission.MiningInformation(null, miningMission.MinesLaidInSets, miningMission.MinesLaidInterval, miningMission.MinesLaidMethod, miningMission.MinesLaidSetInterval);
						}
						result = flag;
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100040", "");
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

	public bool TurnToUnmaskPrimaryWeapon(ref Weapon theW, Contact theTarget, [Optional][DefaultParameterValue(null)] ref (Mount, float, bool) theMountDetails)
	{
		bool result = default(bool);
		try
		{
			if (theTarget != null)
			{
				if (theW != null)
				{
					Mount mount = null;
					foreach (Mount mount2 in myUnit.Mounts)
					{
						if ((myUnit.IsAircraft && !mount2.IsTrainable) || mount2.Status != PlatformComponent._ComponentStatus.Operational || mount2.ReloadStatus != Mount._ReloadStatus.Ready)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount2.MountWeapons)
						{
							if (mountWeapon.int_3 == theW.DBID && mountWeapon.CurrentLoad > 0)
							{
								if (mount2.TargetIsWithinCoverageArc(theTarget))
								{
									theMountDetails = (mount2, -1f, false);
									result = false;
									return result;
								}
								if (mount == null)
								{
									mount = mount2;
								}
							}
						}
					}
					int num;
					if (mount == null)
					{
						num = 0;
					}
					else
					{
						if (theW.Type == Weapon._WeaponType.DepthCharge)
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, theTarget));
							theMountDetails = (mount, Module_Unit.BearingToUnit_True(myUnit, theTarget), true);
							result = true;
							return result;
						}
						int num2 = 1;
						do
						{
							int num3 = Math2.NormalizeBearing((int)Math.Round(myUnit.CurrentHeading + (float)num2));
							if (!mount.TargetIsWithinCoverageArc(theTarget, num3))
							{
								num3 = Math2.NormalizeBearing((int)Math.Round(myUnit.CurrentHeading - (float)num2));
								if (!mount.TargetIsWithinCoverageArc(theTarget, num3))
								{
									num2 += 10;
									continue;
								}
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num3);
								theMountDetails = (mount, num3, true);
								result = true;
								return result;
							}
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num3);
							theMountDetails = (mount, num3, true);
							result = true;
							return result;
						}
						while (num2 <= 180);
						num = 0;
					}
					result = (byte)num != 0;
					return result;
				}
				result = false;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101353", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ManuallyMarkTargetHostile(ref Contact theContact, bool AddedManually)
	{
		if (AddedManually && theContact.Type != Contact_Base.ContactType.Aimpoint && theContact.Type != Contact_Base.ContactType.ActivationPoint && theContact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Hostile)
		{
			theContact.set_Stance(myUnit.get_UnitSide(SetSideOnly: false), MarkManually: true, Misc.PostureStance.Hostile);
			myUnit.AddMessage("Contact: " + theContact.Name + " has been manually marked as hostile!", "Manual target classification", LoggedMessage.MessageType.ContactChange, 0);
		}
	}

	public virtual void TargetThisContact(Contact theContact, bool AddedManually, bool PriorityTarget, TargetingEntry._TargetingBehavior TargetingBehavior)
	{
		try
		{
			int num;
			if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				if (!myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					if (AddedManually)
					{
						Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " is a drone in isolation with insufficient autonomy to target contacts on its own!");
					}
					return;
				}
				num = 0;
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				Mission mission = myUnit.ActiveMissionOrPackage();
				if (mission.MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)mission;
					if (strike.SpecificTargets != null && strike.SpecificTargets.Count > 0)
					{
						foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
						{
							if (!specificTarget.IsContact())
							{
								if (specificTarget.IsActiveUnit && Operators.CompareString(specificTarget.ObjectID, theContact.ActualUnit.ObjectID, false) == 0)
								{
									flag = true;
									break;
								}
							}
							else if (Operators.CompareString(specificTarget.ObjectID, theContact.ObjectID, false) == 0)
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			if (myUnit == null || theContact.Type == Contact_Base.ContactType.Sonobuoy || theContact.get_IsDestroyed(myUnit.ParentScen) || (!AddedManually && TargetIsWasteOfAmmo(theContact)))
			{
				return;
			}
			if (theContact.Type == Contact_Base.ContactType.Missile)
			{
				Weapon weapon = (Weapon)theContact.ActualUnit;
				if (weapon.IsAAWCapable)
				{
					ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
					Contact theTarget = theContact;
					Doctrine doctrine = myUnit.Doctrine;
					string Feedback = string.Empty;
					int FeedbackSeverity = 0;
					if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: false, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
					{
						if (Information.IsNothing((object)weapon.AI.PrimaryTarget) || Information.IsNothing((object)weapon.AI.PrimaryTarget.ActualUnit))
						{
							if (AddedManually)
							{
								myUnit.Message = "Cannot shoot at an AAW weapon!";
							}
							return;
						}
						if (!weapon.AI.PrimaryTarget.ActualUnit.IsShip && (!weapon.AI.PrimaryTarget.ActualUnit.IsSubmarine || !((Submarine)weapon.AI.PrimaryTarget.ActualUnit).IsSurfaced))
						{
							if (AddedManually)
							{
								myUnit.Message = "Cannot shoot at an AAW weapon!";
							}
							return;
						}
					}
				}
			}
			if (myUnit.IsWeapon && PriorityTarget)
			{
				ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
				Weapon theWeapon = (Weapon)myUnit;
				Contact theTarget2 = theContact;
				int? ASL_atFiringUnit = Math.Max(0, ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
				Sensor SuitableDirectorSensor = null;
				(string, ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation) tuple = weaponry2.CanThisWeaponEngageThisTarget(theWeapon, theTarget2, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor);
				if (tuple.Item2 != ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
				{
					myUnit.AddMessage("Weapon " + myUnit.Name + " is not capable against this target type! Reason: " + tuple.Item1, "Weapon not capable against this target!", LoggedMessage.MessageType.WeaponLogic, 0);
					return;
				}
			}
			ManuallyMarkTargetHostile(ref theContact, AddedManually);
			if (_TargetList != null && _TargetList.ContainsKey(theContact.ObjectID))
			{
				if (_TargetList[theContact.ObjectID].Behavior != TargetingBehavior)
				{
					_TargetList[theContact.ObjectID].Behavior = TargetingBehavior;
				}
			}
			else
			{
				TargetingEntry targetingEntry = new TargetingEntry();
				targetingEntry.Target = theContact;
				targetingEntry.Behavior = TargetingBehavior;
				if (_TargetList == null)
				{
					_TargetList = new ObservableDictionary<string, TargetingEntry>();
				}
				AddTargetList_Threadsafe(theContact.ObjectID, targetingEntry);
			}
			byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				bool? obj;
				if (flag)
				{
					obj = true;
				}
				else
				{
					int? ASL_atFiringUnit = (int?)plottedCourse?.FirstOrDefault()?.Category;
					bool? flag3;
					bool? flag2 = (flag3 = ((!ASL_atFiringUnit.HasValue) ? ((bool?)null) : new bool?(ASL_atFiringUnit == 1)));
					if (flag2.HasValue && flag3 == true)
					{
						obj = true;
					}
					else
					{
						ASL_atFiringUnit = (int?)plottedCourse?.FirstOrDefault()?.Type;
						bool? flag4;
						flag2 = (flag4 = ((!ASL_atFiringUnit.HasValue) ? ((bool?)null) : new bool?(ASL_atFiringUnit.GetValueOrDefault() == 0)));
						obj = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3));
					}
				}
				bool? flag5 = obj;
				if (((!flag5) ?? flag5) == true)
				{
					bool flag6 = true;
					if (myUnit.IsShip && theContact.IsAir_Missile_Orbital_Contact)
					{
						flag6 = false;
					}
					if (flag6 && ((myUnit.get_UnitSide(SetSideOnly: false).NoNavZones != null) & (myUnit.get_UnitSide(SetSideOnly: false).NoNavZones.Count > 0)))
					{
						foreach (NoNavZone noNavZone in myUnit.get_UnitSide(SetSideOnly: false).NoNavZones)
						{
							if (((Module_Unit.Unit)theContact).get_IsInsideThisArea((List<ReferencePoint>)noNavZone.Area, myUnit.ParentScen, UseCache: true))
							{
								flag6 = false;
							}
						}
					}
					if (flag6)
					{
						Mission mission2 = myUnit.ActiveMissionOrPackage();
						if (mission2 != null && flag6)
						{
							if (mission2.MissionClass == Mission._MissionClass.Patrol)
							{
								if (flag)
								{
									myUnit.Navigator.ClearPlottedCourse();
								}
							}
							else
							{
								myUnit.Navigator.ClearPlottedCourse();
							}
						}
					}
				}
			}
			if (PriorityTarget || (AddedManually && myUnit.IsWeapon))
			{
				PrimaryTarget = theContact;
				PrimaryTargetOverrideExists = true;
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			}
			TimeToNextTargetsEvaluation = 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100041", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void AddContactToThreatList(Contact theContact)
	{
		lock (lockObject_1)
		{
			if (_Threats != null)
			{
				if (_Threats.Contains(theContact))
				{
					return;
				}
			}
			else
			{
				_Threats = new List<Contact>();
			}
			_Threats.Add(theContact);
			if (_Threats.Count == 0 && Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public virtual void DropThreat(Contact theThreat)
	{
		lock (lockObject_1)
		{
			if (_Threats != null)
			{
				if (!_Threats.Contains(theThreat))
				{
					return;
				}
				_Threats.Remove(theThreat);
			}
			if (theThreat == _PrimaryThreat)
			{
				_PrimaryThreat = null;
			}
		}
	}

	public virtual void DropTarget(Contact theTarget, bool IgnoreTargetIllumination = true)
	{
		try
		{
			if (theTarget == null || myUnit == null || myUnit.IsMorituri || (myUnit.IsShip && ((Ship)myUnit).IsSinking) || (!IgnoreTargetIllumination && myUnit.get_IsPaintingThisTarget(theTarget)))
			{
				return;
			}
			if (theTarget == PrimaryTarget)
			{
				if (!myUnit.IsWeapon)
				{
					PrimaryTarget = null;
					PrimaryTargetOverrideExists = false;
				}
				else if (myUnit.IsGuidedWeapon() & myUnit.isUAV)
				{
					EngageTargets((int)myUnit.ParentScen.TimeCompression);
					if (PrimaryTarget == null)
					{
						myUnit.AI.PrimaryTarget = ((BallisticMissile)theTarget.ActualUnit).GetTargetAimpoint();
					}
				}
			}
			method_6(theTarget);
			if (myUnit == null)
			{
				return;
			}
			if (!myUnit.IsWeapon)
			{
				Side side = myUnit.get_UnitSide(SetSideOnly: false);
				ref Scenario parentScen = ref myUnit.ParentScen;
				ref ActiveUnit theAU = ref myUnit;
				WeaponSalvo theSalvo = null;
				side.StopShootingSalvo(ref parentScen, ref theAU, ref theTarget, ref theSalvo);
			}
			if (myUnit == null)
			{
				return;
			}
			if (myUnit != null)
			{
				Sensor[] array = new Sensor[myUnit.Sensors_Cached.Length - 1 + 1];
				Array.Copy(myUnit.Sensors_Cached, array, myUnit.Sensors_Cached.Length);
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor.IsTrackingThisTargetForFireControl(ref theTarget))
					{
						sensor.StopTrackingTarget(theTarget);
					}
					if (myUnit == null)
					{
						return;
					}
				}
			}
			myUnit.get_UnitSide(SetSideOnly: false)?.RemoveFireProposal(myUnit, theTarget);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200326", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(Contact contact_5)
	{
		if (contact_5 == null)
		{
			return;
		}
		lock (lockObject_0)
		{
			if (_TargetList != null)
			{
				_TargetList.Remove(contact_5.ObjectID);
			}
		}
	}

	internal bool ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref Contact theC)
	{
		PooledList<WeaponSalvo> pooledList = default(PooledList<WeaponSalvo>);
		bool result;
		try
		{
			pooledList = new PooledList<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			int count = pooledList.Count;
			WeaponSalvo[] array = pooledList.InternalArray();
			int num = count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					WeaponSalvo weaponSalvo = array[num2];
					if (weaponSalvo.ManualFire && weaponSalvo.Target == theC && weaponSalvo.WpnQuantityAssigned != weaponSalvo.WpnQuantityFired)
					{
						WeaponSalvo.Shooter[] array2 = weaponSalvo.ShootersList.ToArray();
						foreach (WeaponSalvo.Shooter shooter in array2)
						{
							if (Operators.CompareString(myUnit.ObjectID, shooter.ShooterObjectID, false) == 0 && shooter.QuantityFired < shooter.QuantityAssigned && shooter.WeaponIsReadyToFire && shooter.Timeout > 0)
							{
								result = true;
								goto end_IL_00c8;
							}
						}
					}
					num2++;
					continue;
				}
				result = false;
				break;
				continue;
				end_IL_00c8:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101354", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList.Dispose();
		}
		return result;
	}

	public virtual void CalculateDesiredRoll()
	{
	}

	public virtual void DeterminePrimaryTarget(float elapsedTime, bool IgnoreTimeToNextEvaluation, bool CheckCombatRadius)
	{
		if (!DeterminePrimaryTarget_Enabled)
		{
			return;
		}
		lock (myUnit)
		{
			try
			{
				if (myUnit == null)
				{
					return;
				}
				if (myUnit.IsRTB_Or_CalledOff)
				{
					PrimaryTarget = null;
				}
				else
				{
					if (PrimaryTargetOverrideExists && _PrimaryThreat == null)
					{
						return;
					}
					if (myUnit.IsDrone() && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						ActiveUnit.DroneAutonomyLevel autonomyLevel = myUnit.AutonomyLevel;
						if (autonomyLevel == ActiveUnit.DroneAutonomyLevel.RemotelyPiloted || autonomyLevel == ActiveUnit.DroneAutonomyLevel.SelfRecovering)
						{
							return;
						}
					}
					if (myUnit.IsWeapon || _TargetList == null || _TargetList.Count <= 0)
					{
						return;
					}
					list_1.Clear();
					foreach (KeyValuePair<string, TargetingEntry> target2 in _TargetList)
					{
						list_1.Add(target2.Value);
					}
					list_2.Clear();
					if (myUnit.IsShip)
					{
						foreach (TargetingEntry item in list_1)
						{
							targetingEntry_0 = item;
							Contact target = targetingEntry_0.Target;
							if (target.IsShipContact || target.IsSubmergedContact || target.IsGroundContact)
							{
								list_2.Add(targetingEntry_0);
							}
						}
					}
					else if (myUnit.IsSubmarine)
					{
						foreach (TargetingEntry item2 in list_1)
						{
							targetingEntry_0 = item2;
							Contact target = targetingEntry_0.Target;
							if (target.ActualUnit != null && !target.ActualUnit.IsMissile && !target.ActualUnit.IsTorpedo && (target.IsShipContact || target.IsSubmergedContact || (target.IsGroundContact && myUnit.AI.IsClearedToEngageThisTarget(target))))
							{
								list_2.Add(targetingEntry_0);
							}
						}
					}
					else if (myUnit.IsFacility)
					{
						foreach (TargetingEntry item3 in list_1)
						{
							targetingEntry_0 = item3;
							Contact target = targetingEntry_0.Target;
							if (target.IsGroundContact)
							{
								list_2.Add(targetingEntry_0);
							}
						}
					}
					else if (!myUnit.IsSatellite)
					{
						list_2 = list_1.ToList();
					}
					if (list_2.Count != 0)
					{
						List<Contact> list = new List<Contact>();
						foreach (TargetingEntry item4 in list_2)
						{
							Contact target = item4.Target;
							switch (item4.Behavior)
							{
							case TargetingEntry._TargetingBehavior.ManualTargeted:
								if (myUnit.IsShip)
								{
									if (target.IsShipContact || target.IsSubmergedContact || target.IsGroundContact)
									{
										list.Add(target);
									}
								}
								else if (myUnit.IsSubmarine)
								{
									if (target.IsShipContact || target.IsSubmergedContact)
									{
										list.Add(target);
									}
								}
								else if (!myUnit.IsFacility)
								{
									if (!myUnit.IsSatellite)
									{
										list.Add(target);
									}
								}
								else if (target.IsGroundContact)
								{
									list.Add(target);
								}
								break;
							case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
								if (myUnit.IsShip)
								{
									if ((target.IsShipContact || target.IsSubmergedContact || target.IsGroundContact) && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref target))
									{
										list.Add(target);
									}
								}
								else if (myUnit.IsSubmarine)
								{
									if ((target.IsShipContact || target.IsSubmergedContact) && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref target))
									{
										list.Add(target);
									}
								}
								else if (!myUnit.IsFacility)
								{
									if (!myUnit.IsSatellite && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref target))
									{
										list.Add(target);
									}
								}
								else if (target.IsGroundContact && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref target))
								{
									list.Add(target);
								}
								break;
							}
						}
						PooledList<Contact> pooledList = new PooledList<Contact>();
						foreach (Contact item5 in list)
						{
							if (ContactIsInsideNoNavZone(item5))
							{
								pooledList.Add(item5);
							}
						}
						foreach (Contact item6 in pooledList)
						{
							list.Remove(item6);
						}
						pooledList.Dispose();
						if (list.Count > 0)
						{
							if (list.Count == 1)
							{
								PrimaryTarget = list[0];
								return;
							}
							Contact[] array = (from theCon in list
								select (theCon) into theCon
								orderby myUnit.RangeToUnit_Horiz(theCon)
								select theCon).ToArray();
							PrimaryTarget = array[0];
						}
						else if (myUnit.IsOnActiveMission)
						{
							List<Contact> list2 = list_2.Select([SpecialName] (TargetingEntry theTE) => theTE.Target).ToList();
							pooledList = new PooledList<Contact>();
							foreach (Contact item7 in list2)
							{
								if (ContactIsInsideNoNavZone(item7))
								{
									pooledList.Add(item7);
								}
							}
							foreach (Contact item8 in pooledList)
							{
								list2.Remove(item8);
							}
							pooledList.Dispose();
							if (IsEscort)
							{
								if (!myUnit.IsShip && !myUnit.IsSubmarine)
								{
									List<Contact> list3 = (from theContact in list2.Where([SpecialName] (Contact theContact) =>
										{
											ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
											Doctrine doctrine = myUnit.Doctrine;
											string Feedback = string.Empty;
											int FeedbackSeverity = 0;
											return weaponry.HaveAvailableWeaponSuitableForThisTarget(theContact, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && ContactIsThreatToMissionUnits(theContact);
										})
										orderby myUnit.RangeToUnit_Horiz(theContact)
										select theContact).ToList();
									if (list3.Count > 0)
									{
										PrimaryTarget = list3[0];
									}
									else
									{
										PrimaryTarget = null;
									}
								}
								else
								{
									Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
									ActiveUnit activeUnit = myUnit;
									List<Contact> targetList = list2;
									Mission._GroupSize theGroupSize = 1;
									int maxNumberOfFlightsEngagingContact = strike.GroupSize_To_ActualGroupQty(ref theGroupSize, ref strike.Escort_NumberOfBoats_Engage);
									theGroupSize = 1;
									DeterminePrimaryTarget_PatrolAndEscortLogic(activeUnit, targetList, maxNumberOfFlightsEngagingContact, strike.GroupSize_To_ActualGroupQty(ref theGroupSize, ref strike.Escort_NumberOfBoats_Investigate), strike.Escort_GroupMemberEngageDistance, elapsedTime);
								}
							}
							else if (myUnit.IsOnActivePatrol() && (myUnit.IsShip || myUnit.IsSubmarine))
							{
								Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
								GlobalVariables.PatrolType type = ((Patrol)myUnit.ActiveMissionOrPackage()).Type;
								if (type == GlobalVariables.PatrolType.SEAD)
								{
									DeterminePrimaryTarget_SEAD_Prioritize(list2, (int)patrol.NumberOfFlights_Engage, (int)patrol.NumberOfFlights_Investigate, patrol.WingmanEngageDistance, elapsedTime);
								}
								else if (myUnit.IsShip || myUnit.IsSubmarine)
								{
									ActiveUnit activeUnit2 = myUnit;
									List<Contact> targetList2 = list2;
									Mission._GroupSize theGroupSize = 1;
									int maxNumberOfFlightsEngagingContact2 = patrol.GroupSize_To_ActualGroupQty(ref theGroupSize, ref patrol.NumberOfBoats_Engage);
									theGroupSize = 1;
									DeterminePrimaryTarget_PatrolAndEscortLogic(activeUnit2, targetList2, maxNumberOfFlightsEngagingContact2, patrol.GroupSize_To_ActualGroupQty(ref theGroupSize, ref patrol.NumberOfBoats_Investigate), patrol.GroupMemberEngageDistance, elapsedTime);
								}
							}
							else if (myUnit.IsOnActiveStrike && ((Strike)myUnit.ActiveMissionOrPackage()).RTB_When_Target_Destroyed && ((Strike)myUnit.ActiveMissionOrPackage()).TargetCount > 0)
							{
								Strike strike2 = (Strike)myUnit.ActiveMissionOrPackage();
								if (strike2.TargetCount > 0)
								{
									List<(int, Contact)> list4 = new List<(int, Contact)>();
									int num = 0;
									foreach (Contact item9 in list2)
									{
										if (item9.get_IsSpecificTargetForThisStrike(strike2))
										{
											list4.Add((num, item9));
										}
										num++;
									}
									if (list4.Count > 0)
									{
										if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
										{
											_Closure$__187-0 arg = default(_Closure$__187-0);
											_Closure$__187-0 CS$<>8__locals5 = new _Closure$__187-0(arg);
											CS$<>8__locals5.$VB$Local_tempList = new List<Contact>();
											foreach (var item10 in list4)
											{
												CS$<>8__locals5.$VB$Local_tempList.Add(item10.Item2);
											}
											CS$<>8__locals5.$VB$Local_tempList = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, CS$<>8__locals5.$VB$Local_tempList);
											list4 = list4.Where([SpecialName] ((int, Contact) theContact) => CS$<>8__locals5.$VB$Local_tempList.Contains(theContact.Item2)).ToList();
										}
										List<(int, Contact)> list5 = (from theContact in list4
											select (theContact) into theContact
											orderby theContact.Item1
											select theContact).ToList();
										PrimaryTarget = list5[0].Item2;
									}
									else
									{
										PrimaryTarget = null;
									}
								}
							}
							else if (myUnit.CommStuff.IsConnectedToSideNetwork)
							{
								foreach (Contact item11 in list2)
								{
									myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactIncomingWeapons.AddIfNotExistsElseUpdate(item11.ObjectID, item11.IncomingGuidedWeapons.Length);
								}
								if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
								{
									list2 = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list2);
								}
								List<IGrouping<int, Contact>> list6 = (from theContact in list2
									select (theContact) into theContact
									group theContact by myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactIncomingWeapons[theContact.ObjectID]).ToList();
								if (list6.Count > 0)
								{
									PrimaryTarget = list6[0].OrderBy([SpecialName] (Contact theContact) => myUnit.RangeToUnit_Horiz(theContact)).ToList()[0];
								}
							}
							else
							{
								if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
								{
									list2 = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list2);
								}
								PrimaryTarget = list2.OrderBy([SpecialName] (Contact theContact) => myUnit.RangeToUnit_Horiz(theContact)).ToList()[0];
							}
							if (PrimaryTarget != null && myUnit.IsSubmarine && myUnit.IsOnActiveStrike && myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true) == null)
							{
								PrimaryTarget = null;
								return;
							}
							List<Contact> list7 = new List<Contact>();
							if (myUnit == null)
							{
								return;
							}
							foreach (Contact item12 in list2)
							{
								if (_Threats != null && _Threats.Contains(item12) && Module_Unit.RangeToUnit_Slant(myUnit, item12) < 10f)
								{
									list7.Add(item12);
								}
								if (list7.Count == 1)
								{
									PrimaryTarget = list7[0];
								}
								double num2 = 20000.0;
								foreach (Contact item13 in list7)
								{
									double num3 = Module_Unit.RangeToUnit_Slant(myUnit, item13);
									if (num3 < num2)
									{
										PrimaryTarget = item13;
										num2 = num3;
									}
								}
							}
							list7 = null;
						}
						else
						{
							PrimaryTarget = null;
						}
					}
					else
					{
						PrimaryTarget = null;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100043", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	internal bool IsContactTooAmbiguousForEvaluation(Contact theContact, float Factor = 1f)
	{
		int result;
		switch (theContact.Type)
		{
		case Contact_Base.ContactType.Air:
			if (GetTargetAmbiguity(theContact, 30f * Factor) != AmbiguityLevel.ExtremelyAmbiguous)
			{
				result = 0;
				goto IL_008e;
			}
			return true;
		case Contact_Base.ContactType.Missile:
			if (GetTargetAmbiguity(theContact, 30f * Factor) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			goto IL_0063;
		default:
			if (GetTargetAmbiguity(theContact, 500f * Factor) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return true;
			}
			goto IL_0063;
		case Contact_Base.ContactType.Submarine:
			if (GetTargetAmbiguity(theContact, 50f * Factor) != AmbiguityLevel.ExtremelyAmbiguous)
			{
				result = 0;
				goto IL_008e;
			}
			return true;
		case Contact_Base.ContactType.UndeterminedNaval:
			{
				if (GetTargetAmbiguity(theContact, 50f * Factor) != AmbiguityLevel.ExtremelyAmbiguous)
				{
					result = 0;
					goto IL_008e;
				}
				return true;
			}
			IL_008e:
			return (byte)result != 0;
			IL_0063:
			result = 0;
			goto IL_008e;
		}
	}

	public static void DeterminePrimaryTarget_PatrolAndEscortLogic(ActiveUnit myUnit, List<Contact> TargetList, int MaxNumberOfFlightsEngagingContact, int MaxNumberOfFlightsInvestigatingContact, float theWingmanEngageDistance, float elapsedtime)
	{
		_Closure$__189-0 arg = default(_Closure$__189-0);
		_Closure$__189-0 CS$<>8__locals115 = new _Closure$__189-0(arg);
		CS$<>8__locals115.$VB$Local_myUnit = myUnit;
		try
		{
			if (CS$<>8__locals115.$VB$Local_myUnit == null || CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage() == null)
			{
				return;
			}
			ConcurrentQueue<Contact> concurrentQueue = new ConcurrentQueue<Contact>();
			if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage() != null && CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				((Patrol)CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage()).get_InvestigateOutsidePatrolArea(CS$<>8__locals115.$VB$Local_myUnit.ParentScen);
			}
			if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage() != null && CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				((Patrol)CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage()).get_InvestigateWithinWeaponRange(CS$<>8__locals115.$VB$Local_myUnit.ParentScen);
			}
			bool isInsidePatrolArea_10nmBuffer = default(bool);
			if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				_ = (Patrol)CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
				isInsidePatrolArea_10nmBuffer = CS$<>8__locals115.$VB$Local_myUnit.AI.IsInsidePatrolArea_10nmBuffer;
				foreach (Contact Target in TargetList)
				{
					if (Target == null)
					{
						continue;
					}
					ActiveUnit_AI aI = CS$<>8__locals115.$VB$Local_myUnit.AI;
					Mission theMission = CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
					Doctrine._UseShootTourists? canShootTourists = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.get_ShootTourists(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool myUnitIsInsidePatrolArea = isInsidePatrolArea_10nmBuffer;
					string Feedback = "";
					int FeedbackSeverity = 0;
					if (!aI.ContactIsRelevantToFlightOrMission(Target, theMission, canShootTourists, IgnoreContacStance: false, myUnitIsInsidePatrolArea, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
					{
						continue;
					}
					bool isAircraft = CS$<>8__locals115.$VB$Local_myUnit.IsAircraft;
					if (CS$<>8__locals115.$VB$Local_myUnit.AI.IsClearedToEngageThisTarget(Target, isAircraft))
					{
						ActiveUnit_Weaponry weaponry = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
						Doctrine doctrine = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
						Feedback = string.Empty;
						FeedbackSeverity = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(Target, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
						{
							concurrentQueue.Enqueue(Target);
						}
					}
				}
			}
			else if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				foreach (Contact Target2 in TargetList)
				{
					if (Target2 != null)
					{
						ActiveUnit_Weaponry weaponry2 = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
						Doctrine doctrine2 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (weaponry2.HaveAvailableWeaponSuitableForThisTarget(Target2, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && CS$<>8__locals115.$VB$Local_myUnit.AI.ContactIsThreatToMissionUnits(Target2))
						{
							concurrentQueue.Enqueue(Target2);
						}
					}
				}
			}
			if (concurrentQueue.Count > 0)
			{
				if (CS$<>8__locals115.$VB$Local_myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					if (!CS$<>8__locals115.$VB$Local_myUnit.IsGroupWingman())
					{
						CS$<>8__locals115.$VB$Local_myUnit.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue.ToList(), MaxNumberOfFlightsEngagingContact);
					}
					else
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(CS$<>8__locals115.$VB$Local_myUnit, concurrentQueue, theWingmanEngageDistance, elapsedtime, MaxNumberOfFlightsEngagingContact);
					}
				}
				else if (CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget == null || !concurrentQueue.Contains(CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget))
				{
					if (concurrentQueue.Count == 1)
					{
						CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = concurrentQueue.ElementAtOrDefault(0);
					}
					else if (!CS$<>8__locals115.$VB$Local_myUnit.Doctrine.HasPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen))
					{
						List<Contact> list = concurrentQueue.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)).ToList();
						CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = list[0];
					}
					else
					{
						List<Contact> list = (from theC in CS$<>8__locals115.$VB$Local_myUnit.Doctrine.ApplyPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, concurrentQueue.ToList())
							orderby Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)
							select theC).ToList();
						CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = list[0];
					}
				}
			}
			if (concurrentQueue.Count != 0 && (concurrentQueue.Count <= 0 || CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget != null))
			{
				return;
			}
			if (CS$<>8__locals115.$VB$Local_myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				ConcurrentQueue<Contact> concurrentQueue2 = new ConcurrentQueue<Contact>();
				if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					foreach (Contact Target3 in TargetList)
					{
						if (Target3 != null && Target3.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_AI aI2 = CS$<>8__locals115.$VB$Local_myUnit.AI;
							Mission theMission2 = CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
							Doctrine._UseShootTourists? canShootTourists2 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.get_ShootTourists(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool myUnitIsInsidePatrolArea2 = isInsidePatrolArea_10nmBuffer;
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (aI2.ContactIsRelevantToFlightOrMission(Target3, theMission2, canShootTourists2, IgnoreContacStance: false, myUnitIsInsidePatrolArea2, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
							{
								concurrentQueue2.Enqueue(Target3);
							}
						}
					}
				}
				else if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					foreach (Contact Target4 in TargetList)
					{
						if (Target4.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_Weaponry weaponry3 = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
							Doctrine doctrine3 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
							string Feedback = string.Empty;
							int FeedbackSeverity = 0;
							if (weaponry3.HaveAvailableWeaponSuitableForThisTarget(Target4, CheckWRA: true, doctrine3, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && CS$<>8__locals115.$VB$Local_myUnit.AI.ContactIsThreatToMissionUnits(Target4))
							{
								concurrentQueue2.Enqueue(Target4);
							}
						}
					}
				}
				if (concurrentQueue2 != null && concurrentQueue2.Count > 0)
				{
					if (!CS$<>8__locals115.$VB$Local_myUnit.IsGroupWingman())
					{
						CS$<>8__locals115.$VB$Local_myUnit.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue2.ToList(), MaxNumberOfFlightsInvestigatingContact);
					}
					else
					{
						DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(CS$<>8__locals115.$VB$Local_myUnit, concurrentQueue2, theWingmanEngageDistance, elapsedtime, MaxNumberOfFlightsInvestigatingContact);
					}
				}
				else if (CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget != null && !CS$<>8__locals115.$VB$Local_myUnit.Weaponry.IsGuidingWeaponsOntoThisContact(CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget))
				{
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = null;
				}
			}
			else
			{
				TList<Contact> tList = new TList<Contact>();
				if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					foreach (Contact Target5 in TargetList)
					{
						if (Target5.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							ActiveUnit_AI aI3 = CS$<>8__locals115.$VB$Local_myUnit.AI;
							Mission theMission3 = CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
							Doctrine._UseShootTourists? canShootTourists3 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.get_ShootTourists(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool myUnitIsInsidePatrolArea3 = isInsidePatrolArea_10nmBuffer;
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (aI3.ContactIsRelevantToFlightOrMission(Target5, theMission3, canShootTourists3, IgnoreContacStance: false, myUnitIsInsidePatrolArea3, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
							{
								tList.Add(Target5);
							}
						}
					}
				}
				else if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					foreach (Contact Target6 in TargetList)
					{
						ActiveUnit_Weaponry weaponry4 = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
						Doctrine doctrine4 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity = 0;
						if (weaponry4.HaveAvailableWeaponSuitableForThisTarget(Target6, CheckWRA: true, doctrine4, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && CS$<>8__locals115.$VB$Local_myUnit.AI.ContactIsThreatToMissionUnits(Target6))
						{
							tList.Add(Target6);
						}
					}
				}
				switch (tList.Count)
				{
				default:
				{
					if (!CS$<>8__locals115.$VB$Local_myUnit.Doctrine.HasPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen))
					{
						CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = tList.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)).ElementAtOrDefault(0);
						break;
					}
					List<Contact> source = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.ApplyPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, tList.ToList());
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = source.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)).ElementAtOrDefault(0);
					break;
				}
				case 1:
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = tList[0];
					break;
				case 0:
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = null;
					break;
				}
			}
			if (CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget != null)
			{
				return;
			}
			if (!CS$<>8__locals115.$VB$Local_myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				TList<Contact> tList2 = new TList<Contact>();
				if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					foreach (Contact Target7 in TargetList)
					{
						if (Target7.get_Stance(CS$<>8__locals115.$VB$Local_myUnit.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Unfriendly)
						{
							ActiveUnit_AI aI4 = CS$<>8__locals115.$VB$Local_myUnit.AI;
							Mission theMission4 = CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
							Doctrine._UseShootTourists? canShootTourists4 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.get_ShootTourists(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							bool myUnitIsInsidePatrolArea4 = isInsidePatrolArea_10nmBuffer;
							string Feedback = "";
							int FeedbackSeverity2 = 0;
							if (aI4.ContactIsRelevantToFlightOrMission(Target7, theMission4, canShootTourists4, IgnoreContacStance: false, myUnitIsInsidePatrolArea4, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity2))
							{
								tList2.Add(Target7);
							}
						}
					}
				}
				else if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					foreach (Contact Target8 in TargetList)
					{
						ActiveUnit_Weaponry weaponry5 = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
						Doctrine doctrine5 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity2 = 0;
						if (weaponry5.HaveAvailableWeaponSuitableForThisTarget(Target8, CheckWRA: true, doctrine5, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false) && CS$<>8__locals115.$VB$Local_myUnit.AI.ContactIsThreatToMissionUnits(Target8))
						{
							tList2.Add(Target8);
						}
					}
				}
				switch (tList2.Count)
				{
				case 0:
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = null;
					return;
				case 1:
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = tList2[0];
					return;
				}
				if (CS$<>8__locals115.$VB$Local_myUnit.Doctrine.HasPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen))
				{
					List<Contact> source2 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.ApplyPriorityTargetList(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, tList2.ToList());
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = source2.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)).ElementAtOrDefault(0);
				}
				else
				{
					CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = tList2.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals115.$VB$Local_myUnit, theC)).ElementAtOrDefault(0);
				}
				return;
			}
			ConcurrentQueue<Contact> concurrentQueue3 = new ConcurrentQueue<Contact>();
			if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				foreach (Contact Target9 in TargetList)
				{
					if (Target9.get_Stance(CS$<>8__locals115.$VB$Local_myUnit.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Unfriendly)
					{
						ActiveUnit_AI aI5 = CS$<>8__locals115.$VB$Local_myUnit.AI;
						Mission theMission5 = CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage();
						Doctrine._UseShootTourists? canShootTourists5 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine.get_ShootTourists(CS$<>8__locals115.$VB$Local_myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						bool myUnitIsInsidePatrolArea5 = isInsidePatrolArea_10nmBuffer;
						string Feedback = "";
						int FeedbackSeverity3 = 0;
						if (aI5.ContactIsRelevantToFlightOrMission(Target9, theMission5, canShootTourists5, IgnoreContacStance: false, myUnitIsInsidePatrolArea5, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity3))
						{
							concurrentQueue3.Enqueue(Target9);
						}
					}
				}
			}
			else if (CS$<>8__locals115.$VB$Local_myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				foreach (Contact Target10 in TargetList)
				{
					if (Target10.get_Stance(CS$<>8__locals115.$VB$Local_myUnit.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Unfriendly)
					{
						ActiveUnit_Weaponry weaponry6 = CS$<>8__locals115.$VB$Local_myUnit.Weaponry;
						Doctrine doctrine6 = CS$<>8__locals115.$VB$Local_myUnit.Doctrine;
						string Feedback = string.Empty;
						int FeedbackSeverity3 = 0;
						if (weaponry6.HaveAvailableWeaponSuitableForThisTarget(Target10, CheckWRA: true, doctrine6, ref Feedback, ref FeedbackSeverity3, HumanFeedBackNeeded: false) && CS$<>8__locals115.$VB$Local_myUnit.AI.ContactIsThreatToMissionUnits(Target10))
						{
							concurrentQueue3.Enqueue(Target10);
						}
					}
				}
			}
			if (concurrentQueue3.Count == 0)
			{
				CS$<>8__locals115.$VB$Local_myUnit.AI.PrimaryTarget = null;
			}
			else if (!CS$<>8__locals115.$VB$Local_myUnit.IsGroupWingman())
			{
				CS$<>8__locals115.$VB$Local_myUnit.AI.DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(concurrentQueue3.ToList(), MaxNumberOfFlightsInvestigatingContact);
			}
			else
			{
				DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(CS$<>8__locals115.$VB$Local_myUnit, concurrentQueue3, theWingmanEngageDistance, elapsedtime, MaxNumberOfFlightsInvestigatingContact);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 567876978", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PatrolAndEscortLogic_Wingman_ShouldEngage(Contact theTarget, List<ActiveUnit> otherUnits = null)
	{
		if (theTarget != null)
		{
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (otherUnits == null)
				{
					otherUnits = Module_Mission.UnitsAssignedToMissionOrPackage(myUnit.ActiveMissionOrPackage(), myUnit.ParentScen);
				}
				foreach (ActiveUnit otherUnit in otherUnits)
				{
					if (otherUnit != null && otherUnit != myUnit && otherUnit.IsAircraft && otherUnit.AI.PrimaryTarget == theTarget)
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public static void DeterminePrimaryTarget_PatrolAndEscortLogic_Wingman(ActiveUnit myUnit, IEnumerable<Contact> EngageableTargets, float theWingmanEngageDistance, float elapsedtime, int maxNumberOfEngagingFlights = int.MaxValue)
	{
		try
		{
			ActiveUnit activeUnit;
			if (Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false)))
			{
				activeUnit = myUnit;
			}
			else
			{
				activeUnit = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			}
			if (!(theWingmanEngageDistance > 0f) || EngageableTargets == null || EngageableTargets.Count() <= 0)
			{
				return;
			}
			if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
			{
				EngageableTargets = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, EngageableTargets.ToList());
			}
			List<Contact> list = (from theC in EngageableTargets
				where theC != null && activeUnit != null && !myUnit.AI.TargetIsWasteOfAmmo(theC)
				orderby Module_Unit.RangeToUnit_Horiz_Angular(activeUnit, theC)
				select theC).ToList();
			if (list != null && list.Count > 0)
			{
				float num = Math2.CalcDist(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)list[0]).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)list[0]).get_Longitude((GlobalVariables.BooleanObject)null));
				if (theWingmanEngageDistance > num)
				{
					if (activeUnit != myUnit && !Information.IsNothing((object)activeUnit.AI.PrimaryTarget) && EngageableTargets.Contains(activeUnit.AI.PrimaryTarget))
					{
						List<Contact> list2 = (from theC in EngageableTargets
							where activeUnit.RangeToUnit_Horiz(theC) <= theWingmanEngageDistance
							orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC)
							select theC).ToList();
						if (list2.Count == 0)
						{
							myUnit.AI.PrimaryTarget = null;
							return;
						}
						if (list2.Count == 1)
						{
							myUnit.AI.PrimaryTarget = list2[0];
							return;
						}
						list2.Remove(activeUnit.AI.PrimaryTarget);
						myUnit.AI.PrimaryTarget = list2[0];
					}
					else
					{
						myUnit.AI.PrimaryTarget = list[0];
					}
					return;
				}
				Contact contact = null;
				List<ActiveUnit> otherUnits = Module_Mission.UnitsAssignedToMissionOrPackage(myUnit.ActiveMissionOrPackage(), myUnit.ParentScen);
				Parallel.ForEach(list, [SpecialName] (Contact theContact, ParallelLoopState loopstate) =>
				{
					Weapon weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(theContact);
					if (weapon != null && myUnit.AI.PatrolAndEscortLogic_Wingman_ShouldEngage(theContact, otherUnits) && weapon.get_MaxRangeForThisTarget(myUnit, theContact, CheckWRA: true, myUnit.Doctrine, ManualFire: false) + theWingmanEngageDistance > Math2.CalcDist(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						contact = theContact;
						loopstate.Stop();
					}
				});
				if (contact != null)
				{
					if (Module_Contact.IsPrimaryTargetForThesePlatforms(contact, myUnit.get_UnitSide(SetSideOnly: false), GroupsOnly: true, myUnit).Count < maxNumberOfEngagingFlights)
					{
						myUnit.AI.PrimaryTarget = contact;
					}
				}
				else if (activeUnit != myUnit && !Information.IsNothing((object)activeUnit.AI.PrimaryTarget) && (activeUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive || activeUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive) && EngageableTargets.Contains(activeUnit.AI.PrimaryTarget))
				{
					Contact primaryTarget = activeUnit.AI.PrimaryTarget;
					myUnit.AI.PrimaryTarget = primaryTarget;
				}
				else
				{
					myUnit.AI.PrimaryTarget = null;
				}
			}
			else if (activeUnit != myUnit)
			{
				if (activeUnit != null && Information.IsNothing((object)activeUnit.AI.PrimaryTarget) && EngageableTargets.Contains(activeUnit.AI.PrimaryTarget))
				{
					Contact primaryTarget2 = activeUnit.AI.PrimaryTarget;
					myUnit.AI.PrimaryTarget = primaryTarget2;
				}
				else
				{
					myUnit.AI.PrimaryTarget = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 592384765238475", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeterminePrimaryTarget_PatrolAndEscortLogic_Lead(List<Contact> EngageableTargets, int MaxNumberOfFlights)
	{
		try
		{
			int count = EngageableTargets.Count;
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			double num3 = double.MaxValue;
			PooledDictionary<Contact, int> pooledDictionary = default(PooledDictionary<Contact, int>);
			foreach (Contact EngageableTarget in EngageableTargets)
			{
				if (pooledDictionary == null)
				{
					pooledDictionary = new PooledDictionary<Contact, int>();
				}
				if (!pooledDictionary.ContainsKey(EngageableTarget))
				{
					pooledDictionary.Add(EngageableTarget, 0);
				}
			}
			foreach (Contact EngageableTarget2 in EngageableTargets)
			{
				if (pooledDictionary == null)
				{
					pooledDictionary = new PooledDictionary<Contact, int>();
				}
				int count2 = Module_Contact.IsPrimaryTargetForThesePlatforms(EngageableTarget2, myUnit.get_UnitSide(SetSideOnly: false), GroupsOnly: true, myUnit).Count;
				pooledDictionary[EngageableTarget2] = count2;
			}
			if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
			{
				EngageableTargets = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, EngageableTargets);
				count = EngageableTargets.Count;
			}
			Contact contact = default(Contact);
			Contact contact2 = default(Contact);
			Contact contact3 = default(Contact);
			for (int i = count - 1; i >= 0; i += -1)
			{
				Contact current = EngageableTargets[i];
				if (TargetIsWasteOfAmmo(current))
				{
					continue;
				}
				if (pooledDictionary == null)
				{
					pooledDictionary = new PooledDictionary<Contact, int>();
				}
				int num4 = pooledDictionary[current];
				double num5 = Module_Unit.RangeToUnit_Horiz_Angular(myUnit, current);
				if (num4 < MaxNumberOfFlights)
				{
					if (num4 > 0)
					{
						if (num5 < num2)
						{
							contact = current;
							num2 = num5;
						}
					}
					else if (num5 < num)
					{
						contact2 = current;
						num = num5;
					}
				}
				else if (num4 != MaxNumberOfFlights)
				{
					if (PrimaryTarget != null)
					{
						PrimaryTarget = null;
					}
					continue;
				}
				if (num5 < num3)
				{
					contact3 = current;
					num3 = num5;
				}
			}
			pooledDictionary?.Dispose();
			Contact contact4 = default(Contact);
			if (contact3 != null)
			{
				Weapon weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(contact3);
				if (weapon != null)
				{
					float num6 = weapon.get_MaxRangeForThisTarget(myUnit, contact3, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
					contact4 = ((!(Math.Max((double)num6 * 1.2, num6 + 5f) > (double)Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact3).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact3).get_Longitude((GlobalVariables.BooleanObject)null)))) ? null : contact3);
				}
				else
				{
					contact4 = null;
				}
			}
			if (contact4 != null)
			{
				PrimaryTarget = contact4;
			}
			else if (contact2 != null)
			{
				PrimaryTarget = contact2;
			}
			else if (contact == null)
			{
				PrimaryTarget = null;
			}
			else
			{
				PrimaryTarget = contact;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 31241234125", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual Module_Unit.Unit DetermineWeaponEffectThreat()
	{
		List<Module_Unit.Unit> list = myUnit.get_UnitSide(SetSideOnly: false).get_KnownActiveNuclearWeapons(myUnit.ParentScen);
		Module_Unit.Unit result = null;
		if (list != null && list.Count > 0)
		{
			double num = double.MaxValue;
			float num4 = default(float);
			foreach (Module_Unit.Unit item in list)
			{
				if (item == null)
				{
					continue;
				}
				Weapon weapon;
				Contact contact2;
				if (item.IsContact())
				{
					Contact contact = (Contact)item;
					if (contact == PrimaryTarget || (!myUnit.CommStuff.IsConnectedToSideNetwork && !myUnit.Sensory.HasLocalTrackOnThisContact(contact, 30f, Sensor.Sensor_Type.None)) || !contact.IsWeaponContact)
					{
						continue;
					}
					weapon = (Weapon)contact.ActualUnit;
					contact2 = weapon.AI.PrimaryTarget;
				}
				else if (!item.IsWeapon)
				{
					if ((object)item.GetType() != typeof(UnguidedWeapon))
					{
						if ((object)item.GetType() == typeof(Explosion))
						{
							Explosion explosion = (Explosion)item;
							double num2 = Module_Unit.RangeToPoint_Slant(myUnit, ((Module_Unit.Unit)explosion).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)explosion).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)explosion).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							double num3 = Math.Pow(explosion.ExpYield / 1000000.0, 0.33);
							if (num2 < num3 && num2 < num)
							{
								result = item;
								num = num2;
							}
						}
						continue;
					}
					UnguidedWeapon unguidedWeapon = (UnguidedWeapon)item;
					if (!myUnit.CommStuff.IsConnectedToSideNetwork && unguidedWeapon.FiringParent != myUnit)
					{
						continue;
					}
					weapon = unguidedWeapon.ReferenceWeapon;
					contact2 = unguidedWeapon.Target;
					num4 = unguidedWeapon.TimeToDetonate;
				}
				else
				{
					weapon = (Weapon)item;
					if (!myUnit.CommStuff.IsConnectedToSideNetwork && weapon.FiringParent != myUnit)
					{
						continue;
					}
					contact2 = weapon.AI.PrimaryTarget;
				}
				if (contact2 != null && weapon.Warheads.Count() > 0)
				{
					double num5 = Module_Unit.RangeToPoint_Slant(myUnit, ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					double num6 = Math.Pow(weapon.Warheads[0].DP / 1000000f, 0.33);
					if (myUnit.IsSubmarine && weapon.IsUnderwater)
					{
						num6 *= 2.0;
					}
					if (num4 == 0f && weapon.CurrentSpeed > 0f)
					{
						num4 = Module_Unit.RangeToPoint_Horiz(weapon, ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null)) / weapon.CurrentSpeed * 3600f;
					}
					if (!((double)(myUnit.MaxSpeed * num4 / 3600f) * 0.8 > num6) && num5 < num6 && num5 < num)
					{
						result = item;
						num = num5;
					}
				}
			}
		}
		return result;
	}

	public virtual void DeterminePrimaryThreat(float elapsedTime)
	{
		try
		{
			if (myUnit == null || myUnit.IsWeapon)
			{
				return;
			}
			if (myUnit.IsPlatform)
			{
				Platform platform = (Platform)myUnit;
				if (platform.Crew == 0 && !platform.CommStuff.IsConnectedToSideNetwork)
				{
					ActiveUnit.DroneAutonomyLevel autonomyLevel = platform.AutonomyLevel;
					if (autonomyLevel == ActiveUnit.DroneAutonomyLevel.RemotelyPiloted || autonomyLevel == ActiveUnit.DroneAutonomyLevel.SelfRecovering)
					{
						return;
					}
				}
			}
			if (_Threats == null || _Threats.Count == 0)
			{
				EvaluateThreats(elapsedTime);
			}
			if (_Threats == null)
			{
				_PrimaryThreat = null;
				return;
			}
			switch (_Threats.Count)
			{
			case 1:
				_PrimaryThreat = _Threats[0];
				return;
			case 0:
				_PrimaryThreat = null;
				return;
			}
			float num = 20000f;
			foreach (Contact threat in _Threats)
			{
				Contact theThreat = threat;
				if (theThreat == null || ((Module_Unit.Unit)theThreat).get_Longitude((GlobalVariables.BooleanObject)null) == 0.0 || ((Module_Unit.Unit)theThreat).get_Latitude((GlobalVariables.BooleanObject)null) == 0.0 || theThreat.CurrentSpeed == 0f)
				{
					continue;
				}
				float num2 = Module_Unit.ClosureSpeed(myUnit, theThreat, myUnit.CurrentSpeed, myUnit.CurrentHeading);
				if (num2 > 0f)
				{
					float num3 = myUnit.ETA_To_Location(num2, DistanceFromThreat(myUnit, ref theThreat));
					if (num3 < num)
					{
						_PrimaryThreat = theThreat;
						num = num3;
					}
				}
			}
			if (_PrimaryThreat != null || !myUnit.IsGroupMember() || (!myUnit.IsShip && !myUnit.IsFacility && !myUnit.IsVehicle))
			{
				return;
			}
			List<ActiveUnit> list = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList();
			list.OrderBy([SpecialName] (ActiveUnit u) => myUnit.RangeToUnit_Horiz(u));
			using List<ActiveUnit>.Enumerator enumerator2 = list.GetEnumerator();
			ActiveUnit current;
			do
			{
				if (enumerator2.MoveNext())
				{
					current = enumerator2.Current;
					continue;
				}
				return;
			}
			while (current == myUnit || current.AI._PrimaryThreat == null);
			_PrimaryThreat = current.AI._PrimaryThreat;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100044", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void ManouverTowardsTarget(float elapsedTime)
	{
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			if (myUnit.Navigator.HasPathfindingPlottedCourse)
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				return;
			}
			if (!PrimaryTarget.HeadingIsKnown)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
			}
			else
			{
				double num = Math.Abs(MathFunctions.AngularDifference(Module_Unit.BearingToUnit_True(PrimaryTarget, myUnit), PrimaryTarget.CurrentHeading));
				if (!(num > 60.0) || !(num < 120.0) || 1 == 0)
				{
					float elapsedTime2 = elapsedTime;
					float? estimatedAverageSpeed = myUnit.DesiredSpeed;
					bool AllowAfterburner = false;
					Manouver_InterceptCourse(elapsedTime2, estimatedAverageSpeed, ref AllowAfterburner);
				}
				else
				{
					Manouver_PurePursuit(elapsedTime, 0f, 0f);
				}
			}
			if (myUnit.Navigator.bool_0 && !PathBlockCheckInProgress)
			{
				PathBlockCheckInProgress = true;
				Task.Factory.StartNew([SpecialName] () =>
				{
					method_7(elapsedTime, bool_0: true);
				});
			}
			if (myUnit.RangeToUnit_Horiz(PrimaryTarget) < 1f && PrimaryTarget.UncertaintyArea != null && !myUnit.Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, CheckCanShootRightNow: true))
			{
				myUnit.Navigator.PlotLocalizationCourse();
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100045", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(float float_0, bool bool_0)
	{
		if (myUnit.AI.HoldPosition)
		{
			return;
		}
		PathBlockCheckInProgress = true;
		try
		{
			if (!myUnit.Navigator.PathFindingInProgress)
			{
				(double, double)? tuple = null;
				if (myUnit.Navigator.PlottedCourse.Length > 0)
				{
					Waypoint waypoint = myUnit.Navigator.PlottedCourse.ElementAt(0);
					if (waypoint.Type == Waypoint.WaypointType.PathfindingPoint)
					{
						tuple = (waypoint.Latitude, waypoint.Longitude);
					}
				}
				if (!tuple.HasValue)
				{
					tuple = (((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				}
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double item = tuple.Value.Item1;
				double item2 = tuple.Value.Item2;
				float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
				int ReasonForInterrupt = 0;
				GeoPoint InterruptLocation = null;
				if (navigator.PathLineIsInterrupted(startLat, startLon, item, item2, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
				{
					Waypoint[] source = myUnit.Navigator.PlottedCourse.ToArray();
					if (myUnit.Navigator.HasPathfindingPlottedCourse)
					{
						Waypoint waypoint2 = source.Where([SpecialName] (Waypoint theWP) => !Information.IsNothing((object)theWP) && theWP.Type == Waypoint.WaypointType.PathfindingPoint).Last();
						Weapon weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget);
						float num = (Information.IsNothing((object)weapon) ? 1f : weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: false, (Doctrine)null, ManualFire: false));
						if (Math2.CalcDist(waypoint2.Latitude, waypoint2.Longitude, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) > num)
						{
							myUnit.Navigator.TriggerPathfinderThread(waypoint2, myUnit, null, theIngressPath: false, 0.15f, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, bool_0);
						}
						else
						{
							myUnit.Navigator.FollowPlottedCourse(float_0);
						}
					}
					else if (PrimaryTarget != null)
					{
						myUnit.Navigator.TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, bool_0);
					}
				}
				else if (myUnit.Navigator.HasPathfindingPlottedCourse)
				{
					myUnit.Navigator.ClearPathfindingWaypoints();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100046", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathBlockCheckInProgress = false;
	}

	public virtual bool CanInterceptTargetAtCurrentAltSpeed(double TargetLat, double TargetLon, float TargetHeading, float TargetSpeed, float theAltitude, float OwnSpeed, float OwnHeading, float? SafetyMargin, bool IgnoreMotionVectors, bool AddTarget)
	{
		bool result;
		try
		{
			if (Information.IsNothing((object)SafetyMargin))
			{
				SafetyMargin = 0.1f;
			}
			float num = Module_Unit.RangeToPoint_Horiz(myUnit, TargetLat, TargetLon);
			float num2;
			if (float.IsNaN(num))
			{
				result = true;
			}
			else if (IgnoreMotionVectors)
			{
				num2 = OwnSpeed;
				int num3;
				if (!(OwnSpeed <= 0f))
				{
					if (!double.IsNaN(OwnSpeed))
					{
						goto IL_00e1;
					}
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				result = (byte)num3 != 0;
			}
			else
			{
				if (AddTarget)
				{
					num2 = Module_Unit.ClosureSpeed(myUnit, TargetLat, TargetLon, TargetHeading, TargetSpeed, OwnSpeed, OwnHeading);
				}
				else
				{
					float ownHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null));
					num2 = Module_Unit.ClosureSpeed(myUnit, TargetLat, TargetLon, TargetHeading, TargetSpeed, OwnSpeed, ownHeading);
				}
				int num4;
				if (!(num2 <= 0f))
				{
					if (!double.IsNaN(num2))
					{
						goto IL_00e1;
					}
					num4 = 0;
				}
				else
				{
					num4 = 0;
				}
				result = (byte)num4 != 0;
			}
			goto end_IL_0001;
			IL_00e1:
			long num5 = (long)Math.Round(num / num2 * 3600f);
			float? num6 = (float)myUnit.Kinematics.RemainingEndurance(OwnSpeed, theAltitude, !myUnit.IsAircraft, myUnit.IsAircraft) * (1f + SafetyMargin);
			float num7 = num5;
			result = ((((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() > num7)) == true) ? true : false);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100047", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num8;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num8 = 0;
			}
			else
			{
				num8 = 0;
			}
			result = (byte)num8 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool CanInterceptTargetAtCurrentAltSpeed(Module_Unit.Unit theTarget, float? theTargetDistance, float theAltitude, float OwnSpeed, float OwnHeading, float? SafetyMargin, bool IgnoreMotionVectors, bool TotalRemainingEndurance, bool BingoFuelEndurance)
	{
		bool result;
		try
		{
			if (Information.IsNothing((object)SafetyMargin))
			{
				SafetyMargin = 0.1f;
			}
			if (Information.IsNothing((object)theTargetDistance))
			{
				theTargetDistance = myUnit.RangeToUnit_Horiz(theTarget);
			}
			float num;
			if (Information.IsNothing((object)theTargetDistance))
			{
				result = true;
			}
			else
			{
				if (!IgnoreMotionVectors && theTarget != null && theTarget.IsContact())
				{
					IgnoreMotionVectors = ((Contact)theTarget).AppearsToBeLoitering;
				}
				if (!IgnoreMotionVectors)
				{
					num = Module_Unit.ClosureSpeed(myUnit, theTarget, OwnSpeed, OwnHeading);
					if (!(num <= 0f) && !double.IsNaN(num))
					{
						goto IL_00bd;
					}
					result = false;
				}
				else
				{
					num = OwnSpeed;
					int num2;
					if (!(OwnSpeed <= 0f))
					{
						if (!double.IsNaN(OwnSpeed))
						{
							goto IL_00bd;
						}
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					result = (byte)num2 != 0;
				}
			}
			goto end_IL_0001;
			IL_00bd:
			long num3 = (long)Math.Round((theTargetDistance / num * 3600f).Value);
			float? num4 = (float)myUnit.Kinematics.RemainingEndurance(OwnSpeed, theAltitude, TotalRemainingEndurance, BingoFuelEndurance) * (1f + SafetyMargin);
			float num5 = num3;
			result = ((((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() > num5)) == true) ? true : false);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100047", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num6 = 0;
			}
			else
			{
				num6 = 0;
			}
			result = (byte)num6 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool CanInterceptTarget(Module_Unit.Unit theTarget, float? theTargetDistance, float theAltitude, float? theSpeed, float theHeading, ActiveUnit.Throttle theThrottle, float? SafetyMargin, bool IgnoreMotionVectors, bool TotalRemainingEndurance, ref bool BingoFuelEndurance)
	{
		bool result;
		try
		{
			if (myUnit == null)
			{
				result = false;
			}
			else
			{
				if (!theSpeed.HasValue)
				{
					theSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theThrottle, ValidateAndFixAltitude: false);
				}
				result = CanInterceptTargetAtCurrentAltSpeed(theTarget, theTargetDistance, theAltitude, theSpeed.Value, theHeading, SafetyMargin, IgnoreMotionVectors, TotalRemainingEndurance, BingoFuelEndurance);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100048", "");
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
		}
		return result;
	}

	public int? MinimumSpeedToInterceptTarget(ActiveUnit theTarget)
	{
		int? result = default(int?);
		try
		{
			int maximumSpeed = myUnit.Kinematics.GetMaximumSpeed();
			int num = Math.Max(1, (int)Math.Round((double)maximumSpeed / 100.0));
			int num2 = maximumSpeed;
			int num3 = num;
			for (int i = 1; ((num3 >> 31) ^ i) <= ((num3 >> 31) ^ num2); i += num3)
			{
				if (ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, theTarget, i).HasValue)
				{
					result = i;
					return result;
				}
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100049", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Manouver_PurePursuit(float elapsedTime, float Buffer_Seconds, float Buffer_Distance_nm)
	{
		try
		{
			if (myUnit.Navigator.PlottedCourse != null && myUnit.Navigator.PlottedCourse.Count() > 0)
			{
				Waypoint? waypoint = myUnit.Navigator.PlottedCourse.FirstOrDefault();
				if (waypoint != null && waypoint.Type == Waypoint.WaypointType.LocalizationRun)
				{
					if (PrimaryTarget.UncertaintyArea != null)
					{
						return;
					}
					myUnit.Navigator.RemoveWaypoint_Soft(myUnit.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
				}
			}
			bool flag = myUnit.get_WillNeedToPaintThisTarget(PrimaryTarget);
			if (PrimaryTarget.IsAircraftContact)
			{
				Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true);
				if (weapon != null)
				{
					if (weapon.MinAirRange > 0f && myUnit.RangeToUnit_Horiz(PrimaryTarget) <= weapon.MinAirRange && !flag)
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget) + 90f));
						return;
					}
					if (weapon.Flags.RearAspect_AAM || weapon.Flags.SternChase_AAM)
					{
						double out_lon = default(double);
						double out_lat = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, (double)weapon.MinAirRange + 0.5, Math2.NormalizeBearing(PrimaryTarget.CurrentHeading + 180f));
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, out_lat, out_lon));
						return;
					}
				}
			}
			float value = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			if (!(PrimaryTarget.CurrentSpeed > myUnit.CurrentSpeed / 2f))
			{
				Misc.ExtendPhase phase = Misc.ExtendPhase.Standard;
				if (myUnit.IsAircraft)
				{
					Weapon theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true);
					if (theW != null)
					{
						float num = theW.MinRangeForTarget(PrimaryTarget);
						float BoresightLimit = 0f;
						bool bool_ = false;
						theW.GetBoresightLimit(myUnit, PrimaryTarget, ref BoresightLimit, ref bool_);
						if (num > 0f || BoresightLimit > 0f)
						{
							float val = 2f;
							float num2 = theW.MinRangeForTarget(PrimaryTarget);
							if (theW.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false) - num2 > 5f)
							{
								num2 *= 2f;
							}
							float desiredHeading = myUnit.DesiredHeading;
							(Mount, float, bool) theMountDetails = (null, -1f, false);
							TurnToUnmaskPrimaryWeapon(ref theW, PrimaryTarget, ref theMountDetails);
							float num3 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
							Buffer_Distance_nm = Math.Max(Math.Max(num2, Buffer_Distance_nm), val);
							if (theMountDetails.Item1 != null && theMountDetails.Item3)
							{
								if (!theW.IsWithinMaxRangeOfTarget(num3, PrimaryTarget))
								{
									value = (theMountDetails.Item3 ? theMountDetails.Item2 : myUnit.DesiredHeading);
								}
								else
								{
									myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, desiredHeading);
								}
							}
							else
							{
								if (theMountDetails.Item1 == null || theMountDetails.Item2 != -1f)
								{
									float value2 = 0f;
									if (BoresightLimit > 0f)
									{
										double BearingAngle = default(double);
										double VerticalAngle = default(double);
										Module_Unit.AngleOffThisUnitsBoresight3D(PrimaryTarget, myUnit, ref BearingAngle, ref VerticalAngle);
										Contact primaryTarget = PrimaryTarget;
										ActiveUnit observerUnit = myUnit;
										string feedbackMessage = "";
										value2 = Module_Unit.AngleOffThisUnitsBoresight(primaryTarget, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
									}
									if (myUnit.IsAircraft && Math.Abs(value2) < 90f && flag)
									{
										myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
										myUnit.Navigator.ExtendTimer = 0.0;
										return;
									}
									if (num2 == 0f || num3 > num2)
									{
										phase = ((Math.Abs(value2) > BoresightLimit) ? ((!(num3 < Buffer_Distance_nm)) ? Misc.ExtendPhase.LiningUp : Misc.ExtendPhase.Extending) : Misc.ExtendPhase.FinalApproach);
									}
									ActiveUnit_Navigator navigator = myUnit.Navigator;
									Waypoint theWaypoint = null;
									if (!navigator.ExtendIfNecessary(elapsedTime, ref theWaypoint, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), Buffer_Seconds, Buffer_Distance_nm, myUnit.Kinematics.TurnRate(), phase))
									{
										myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
									}
									return;
								}
								value = myUnit.DesiredHeading;
							}
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
							return;
						}
					}
				}
			}
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100050", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Manouver_CollisionCourse(float elapsedTime)
	{
		try
		{
			double num = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
			if (270.0 > num && num > 90.0)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			float num2 = myUnit.ETA_To_Location(Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading), myUnit.RangeToUnit_Horiz(PrimaryTarget));
			float distance_NM = PrimaryTarget.CurrentSpeed / 3600f * num2;
			Waypoint waypoint = new Waypoint();
			double lon = ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
			double lat = ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
			Waypoint waypoint2;
			double out_lon = (waypoint2 = waypoint).Longitude;
			Waypoint waypoint3;
			double out_lat = (waypoint3 = waypoint).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, distance_NM, PrimaryTarget.CurrentHeading);
			waypoint3.Latitude = out_lat;
			waypoint2.Longitude = out_lon;
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude)));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100051", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual Geopoint_Struct? Manouver_InterceptCourse(float elapsedTime, float? EstimatedAverageSpeed, ref bool AllowAfterburner)
	{
		Geopoint_Struct? result = default(Geopoint_Struct?);
		try
		{
			if (PrimaryTarget != null)
			{
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				if (plottedCourse == null || plottedCourse.Length <= 0 || plottedCourse[0].Type != Waypoint.WaypointType.LocalizationRun)
				{
					goto IL_005f;
				}
				if (PrimaryTarget.UncertaintyArea == null)
				{
					myUnit.Navigator.RemoveWaypoint_Soft(plottedCourse[0], RemoveWingmanWaypoints: false);
					goto IL_005f;
				}
				result = null;
			}
			else
			{
				result = null;
			}
			goto end_IL_0001;
			IL_005f:
			if (!PrimaryTarget.AppearsToBeLoitering && PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
			{
				float num = (EstimatedAverageSpeed.HasValue ? EstimatedAverageSpeed.Value : myUnit.CurrentSpeed);
				Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
				if (weapon != null)
				{
					if (weapon.MinAirRange > 0f && myUnit.RangeToUnit_Horiz(PrimaryTarget) <= weapon.MinAirRange)
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget) + 90f));
						result = PrimaryTarget.Location;
						return result;
					}
					if (weapon.Flags.RearAspect_AAM || weapon.Flags.SternChase_AAM)
					{
						double out_lon = default(double);
						double out_lat = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, weapon.MinAirRange + 1f, Math2.NormalizeBearing(PrimaryTarget.CurrentHeading + 180f));
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, out_lat, out_lon));
						result = new Geopoint_Struct(out_lon, out_lat);
						return result;
					}
				}
				double? num2 = ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, PrimaryTarget, num, 0.05f);
				if (!num2.HasValue)
				{
					(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, num, PrimaryTarget);
					if (!tuple.Item1.HasZeroCoords)
					{
						num2 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
					}
				}
				if (num2.HasValue)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num2.Value);
					double Lon = default(double);
					double Lat = default(double);
					Math2.CalcPoint_Vincenty(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref Lon, ref Lat, 100.0, num2.Value);
					double Lon2 = default(double);
					double Lat2 = default(double);
					Math2.CalcPoint_Vincenty(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref Lon2, ref Lat2, 100.0, PrimaryTarget.CurrentHeading);
					result = GeoPoint.GeoSegmentIntersect_Geodesic(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Lon, Lat, ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), Lon2, Lat2);
					return result;
				}
				if (myUnit.CurrentSpeed < PrimaryTarget.CurrentSpeed)
				{
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.DesiredHeading, Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget))) > 15f)
					{
						Manouver_PurePursuit(elapsedTime, 0f, 0f);
					}
					AllowAfterburner = true;
					result = PrimaryTarget.Location;
					return result;
				}
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				AllowAfterburner = true;
				result = PrimaryTarget.Location;
				return result;
			}
			Manouver_PurePursuit(elapsedTime, 0f, 0f);
			result = PrimaryTarget.Location;
			return result;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100052", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Manouver_ProportionalNavigation(float elapsedTime)
	{
		try
		{
			float num;
			if (!myUnit.IsWeapon)
			{
				num = 1f;
			}
			else
			{
				float num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
				num = Math.Min(64f, num2 / (myUnit.CurrentSpeed / 3600f));
			}
			float num3 = Module_Unit.BearingToUnit_Relative(myUnit, PrimaryTarget);
			if (270f > num3 && num3 > 90f)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			float num4 = PrimaryTarget.AngleRateFromThisUnitsPOV(myUnit);
			if (!float.IsNaN(num4))
			{
				switch (PrimaryTarget.IsMovingTowardsPortOrStarboardOfThisUnit(myUnit))
				{
				case Misc.TurnDirection.TurnRight:
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(num3 + num * num4));
					break;
				case Misc.TurnDirection.TurnLeft:
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(num3 - num * num4));
					break;
				}
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, num3);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100053", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual void Manouver_CargoMission(float elapsedTime)
	{
	}

	public virtual void EmployUntargetedWeapons(float elapsedTime)
	{
	}

	public bool TargetIsWasteOfAmmo(Contact theTarget)
	{
		bool result;
		try
		{
			int num;
			int num2;
			if (theTarget.ActualUnit != null && theTarget.ActualUnit.get_isTaggedAsDecoyByThisSide(myUnit.get_UnitSide(SetSideOnly: false)?.ObjectID))
			{
				result = true;
			}
			else if ((theTarget.Type == Contact_Base.ContactType.ActivationPoint && theTarget.Type != Contact_Base.ContactType.Aimpoint) || theTarget.ActualUnit != null)
			{
				ActiveUnit actualUnit = theTarget.ActualUnit;
				if (actualUnit == null)
				{
					if (theTarget.Type == Contact_Base.ContactType.Aimpoint)
					{
						num = 0;
						goto IL_007d;
					}
					if (theTarget.Type == Contact_Base.ContactType.ActivationPoint)
					{
						num = 0;
						goto IL_007d;
					}
					result = true;
				}
				else
				{
					if (!actualUnit.IsFacility)
					{
						num2 = 0;
						goto IL_0103;
					}
					if (!theTarget.BDA_StructuralIntegrity.HasValue || theTarget.BDA_StructuralIntegrity.Value != Contact.BDA_StructuralIntegrityLevel.HeavyDamage)
					{
						num2 = 0;
						goto IL_0103;
					}
					if (actualUnit.AirFacilities_ReadOnly.Length <= 0)
					{
						num2 = 0;
						goto IL_0103;
					}
					if (actualUnit.AirFacilities_ReadOnly.Length != actualUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Count())
					{
						num2 = 0;
						goto IL_0103;
					}
					result = true;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_007d:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_0103:
			result = (byte)num2 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101355", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void EngageTargets(float elapsedTime)
	{
		if (myUnit.Weaponry.TaskList_DLZChecks.Count > 0)
		{
			Task.WaitAll(myUnit.Weaponry.TaskList_DLZChecks.ToArray());
		}
		PooledList<TargetingEntry> pooledList = default(PooledList<TargetingEntry>);
		try
		{
			_Closure$__208-1 arg = default(_Closure$__208-1);
			_Closure$__208-1 CS$<>8__locals56 = new _Closure$__208-1(arg);
			CS$<>8__locals56.$VB$Me = this;
			if (myUnit == null)
			{
				return;
			}
			CS$<>8__locals56.$VB$Local_theMission = myUnit.ActiveMissionOrPackage();
			if (IsOnMiningRun(elapsedTime))
			{
				try
				{
					_Closure$__208-0 arg2 = default(_Closure$__208-0);
					_Closure$__208-0 CS$<>8__locals55 = new _Closure$__208-0(arg2);
					CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals56;
					CS$<>8__locals55.$VB$Local_ShouldDropMines = true;
					if (myUnit.AI.MiningInfo != null)
					{
						if (!myUnit.IsGroupMember())
						{
							if (myUnit.Navigator.HasPlottedCourse())
							{
								Waypoint thePoint = ((myUnit.Navigator.PlottedCourse.Count() > 0) ? myUnit.Navigator.PlottedCourse[0] : null);
								Waypoint waypoint = ((myUnit.Navigator.PlottedCourse.Count() <= 1 || myUnit.Navigator.PlottedCourse[1].Creator != Waypoint.WaypointCreator.Manual) ? null : myUnit.Navigator.PlottedCourse[1]);
								if (myUnit.Navigator.HaveReachedPoint(thePoint, elapsedTime))
								{
									MiningMission.MiningInformation miningInfo = myUnit.AI.MiningInfo;
									if (miningInfo != null && !miningInfo.StartedMining)
									{
										myUnit.AI.MiningInfo.StartedMining = true;
										if (waypoint == null)
										{
											myUnit.Navigator.PlotCourseToArea(((MiningMission)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).Area);
										}
									}
								}
								CS$<>8__locals55.$VB$Local_ShouldDropMines = myUnit.AI.MiningInfo.StartedMining;
							}
						}
						else
						{
							ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
							if (groupLead.AI.MiningInfo.StartedMining)
							{
								if (groupLead != myUnit)
								{
									myUnit.AI.MiningInfo.StartedMining = true;
								}
								CS$<>8__locals55.$VB$Local_ShouldDropMines = myUnit.AI.MiningInfo.StartedMining;
							}
							else if (groupLead.Navigator.HasPlottedCourse())
							{
								Waypoint thePoint2 = ((groupLead.Navigator.PlottedCourse.Count() > 0) ? groupLead.Navigator.PlottedCourse[0] : null);
								Waypoint waypoint2 = ((groupLead.Navigator.PlottedCourse.Count() <= 1 || groupLead.Navigator.PlottedCourse[1].Creator != Waypoint.WaypointCreator.Manual) ? null : groupLead.Navigator.PlottedCourse[1]);
								if (groupLead.Navigator.HaveReachedPoint(thePoint2, elapsedTime))
								{
									MiningMission.MiningInformation miningInfo2 = groupLead.AI.MiningInfo;
									if (miningInfo2 != null && !miningInfo2.StartedMining)
									{
										groupLead.AI.MiningInfo.StartedMining = true;
										if (groupLead != myUnit)
										{
											myUnit.AI.MiningInfo.StartedMining = true;
										}
										if (waypoint2 == null)
										{
											groupLead.Navigator.PlotCourseToArea(((MiningMission)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).Area);
										}
									}
								}
								CS$<>8__locals55.$VB$Local_ShouldDropMines = myUnit.AI.MiningInfo.StartedMining;
							}
						}
					}
					if (CS$<>8__locals55.$VB$Local_ShouldDropMines)
					{
						List<UnguidedWeapon> mines = myUnit.ParentScen.Mines;
						if (mines != null && mines.Count > 0)
						{
							Parallel.ForEach(myUnit.ParentScen.Mines.Where([SpecialName] (UnguidedWeapon unguidedWeapon) => unguidedWeapon.get_UnitSide(SetSideOnly: false) == myUnit.get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(myUnit.get_UnitSide(SetSideOnly: false), unguidedWeapon.get_UnitSide(SetSideOnly: false))).ToArray(), [SpecialName] (UnguidedWeapon theMine, ParallelLoopState loopstate) =>
							{
								if ((double)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.RangeToUnit_Horiz(theMine) * 1852.0 < (double)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.get_SafeDistanceAgainstKnownMineType_meters(theMine.Type, UsePathfindingBufferDistance: false) * 1.5)
								{
									CS$<>8__locals55.$VB$Local_ShouldDropMines = false;
									loopstate.Stop();
								}
								else if (CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo != null)
								{
									GeoPoint thePoint3 = new GeoPoint(((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), AssignObjectID: false);
									if (CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.SpacingSet.HasValue && CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineSet != null && CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineSet == theMine)
									{
										double num36 = (double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint3) * 1852.0;
										double? num37 = CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.SpacingSet;
										if (((!num37.HasValue) ? ((bool?)null) : new bool?(num36 < num37.GetValueOrDefault())) == true)
										{
											CS$<>8__locals55.$VB$Local_ShouldDropMines = false;
											loopstate.Stop();
											return;
										}
									}
									if (CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.Spacing.HasValue && CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineLocal != null && CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.LastMineLocal == theMine)
									{
										double num36 = (double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint3) * 1852.0;
										double? num37 = CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.MiningInfo.Spacing;
										if (((!num37.HasValue) ? ((bool?)null) : new bool?(num36 < num37.GetValueOrDefault())) == true)
										{
											CS$<>8__locals55.$VB$Local_ShouldDropMines = false;
											loopstate.Stop();
											return;
										}
									}
									if (((MiningMission)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinesLaidInterval.HasValue)
									{
										double num36 = (double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, thePoint3) * 1852.0;
										double? num37 = ((MiningMission)CS$<>8__locals55.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinesLaidInterval;
										if (((!num37.HasValue) ? ((bool?)null) : new bool?(num36 < num37.GetValueOrDefault())) == true)
										{
											CS$<>8__locals55.$VB$Local_ShouldDropMines = false;
											loopstate.Stop();
										}
									}
								}
							});
						}
					}
					if (CS$<>8__locals55.$VB$Local_ShouldDropMines)
					{
						Mission mission = myUnit.ActiveMissionOrPackage();
						long armDelay = ((mission != null && mission.MissionClass == Mission._MissionClass.Mining) ? ((MiningMission)myUnit.ActiveMissionOrPackage()).ArmDelay : (myUnit.IsAircraft ? 0L : 3600L));
						myUnit.Weaponry.AttemptToLayMine(elapsedTime, armDelay);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100054_000012", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (Targets_ReadOnly.Length == 0)
			{
				EmployUntargetedWeapons(elapsedTime);
			}
			if (Targets_ReadOnly.Length == 0)
			{
				return;
			}
			Doctrine._WCS? wCS = myUnit.Doctrine.get_WeaponControlStatus_Air(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Doctrine._WCS? wCS2 = myUnit.Doctrine.get_WeaponControlStatus_Surface(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Doctrine._WCS? wCS3 = myUnit.Doctrine.get_WeaponControlStatus_Submarine(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Doctrine._WCS? wCS4 = myUnit.Doctrine.get_WeaponControlStatus_Land(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			_ = myUnit.Doctrine.GetElementState(Doctrine.DoctrineItem_E.MissileEngagement_FireOverTheShoulder).Value;
			byte? b = (byte?)wCS;
			bool? flag2;
			bool? flag = (flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)));
			bool? obj;
			bool? flag3;
			if (flag.HasValue && flag2 != true)
			{
				obj = false;
			}
			else
			{
				b = (byte?)wCS2;
				flag = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)));
				obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) & flag2));
			}
			bool? flag4 = obj;
			flag3 = obj;
			bool? obj2;
			if (flag3.HasValue && flag4 != true)
			{
				obj2 = false;
			}
			else
			{
				b = (byte?)wCS3;
				bool? flag5;
				flag3 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)));
				obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) & flag4));
			}
			bool? flag6 = obj2;
			if (flag6 ?? true)
			{
				b = (byte?)wCS4;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true && flag6.HasValue)
				{
					return;
				}
			}
			if (TargetsSortedByRange == null)
			{
				return;
			}
			CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE = null;
			pooledList = new PooledList<TargetingEntry>(TargetsSortedByRange, Pools<TargetingEntry>.Local);
			List<Contact> list = null;
			bool flag7 = false;
			bool flag8 = true;
			bool flag9 = true;
			bool flag10 = true;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			bool excludeICBMs = true;
			b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				excludeICBMs = false;
			}
			if (!CalculatedNearestTargetsThisPulse)
			{
				method_0(pooledList);
			}
			if (nullable_1.HasValue)
			{
				Weapon longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_ASWeapon(excludeICBMs);
				if (longestRange_ASWeapon != null)
				{
					num = longestRange_ASWeapon.MaxSurfaceRange;
					flag8 = nullable_1.Value > Math.Max(15f, num);
				}
			}
			if (nullable_2.HasValue)
			{
				Weapon longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_ASWWeapon();
				if (longestRange_ASWeapon != null)
				{
					num2 = longestRange_ASWeapon.MaxSubsurfaceRange;
					flag10 = nullable_2.Value > Math.Max(15f, num2);
				}
			}
			if (nullable_3.HasValue)
			{
				Weapon longestRange_ASWeapon = myUnit.Weaponry.GetLongestRange_AGWeapon(excludeICBMs);
				if (longestRange_ASWeapon != null)
				{
					num3 = longestRange_ASWeapon.MaxLandRange;
					flag9 = nullable_3.Value > Math.Max(15f, num3);
				}
			}
			int? num32 = default(int?);
			Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = default(Doctrine._GunStrafeGroundTargets?);
			while (!flag7)
			{
				foreach (TargetingEntry item in pooledList)
				{
					Contact theTarget = item.Target;
					if (theTarget == null || theTarget.ActualUnit == null || _DoNotTargetList.Contains(theTarget))
					{
						continue;
					}
					int num4;
					if (!myUnit.AI.IsEscort && myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
						bool flag11 = false;
						foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
						{
							if (!specificTarget.IsActiveUnit)
							{
								if (specificTarget.IsContact() && string.CompareOrdinal(((Contact)specificTarget).ObjectID, theTarget.ObjectID) == 0)
								{
									flag11 = true;
									break;
								}
							}
							else if (string.CompareOrdinal(((ActiveUnit)specificTarget).ObjectID, theTarget.ActualUnit.ObjectID) == 0)
							{
								flag11 = true;
								break;
							}
						}
						if (!flag11 && strike.Type != Strike.StrikeType.Air_Intercept && strike.get_FocusEntirelyOnStrikeTargets(myUnit))
						{
							return;
						}
						if (!flag11)
						{
							num4 = 0;
							goto IL_0b9c;
						}
						if (myUnit.IsAircraft && myUnit.Navigator.HasFlightPlan && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && !((Aircraft)myUnit).Navigator.HasReachedWeaponReleasePoint(fromUI: false))
						{
							continue;
						}
					}
					else if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						ActiveUnit escortedUnitsLead = myUnit.getEscortedUnitsLead();
						if (escortedUnitsLead != null)
						{
							Strike obj3 = (Strike)myUnit.AssignedMissionOrPackage();
							int escort_ResponseRadius = obj3.Escort_ResponseRadius;
							int escort_ResponseRadius_SEAD = obj3.Escort_ResponseRadius_SEAD;
							float num5 = Math2.CalcDist(item.Target, escortedUnitsLead);
							if (!myUnit.IsAircraft || !((Aircraft)myUnit).Loadout.IsSEAD)
							{
								if (num5 > (float)escort_ResponseRadius)
								{
									continue;
								}
								num4 = 0;
								goto IL_0b9c;
							}
							if (num5 > (float)escort_ResponseRadius_SEAD)
							{
								continue;
							}
						}
					}
					num4 = 0;
					goto IL_0b9c;
					IL_1607:
					float num6;
					if (num6 == -1f)
					{
						num6 = myUnit.RangeToUnit_Horiz_Alt(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					}
					float? num7;
					bool? obj4 = ((!num7.HasValue) ? ((bool?)null) : new bool?(num6 <= num7.GetValueOrDefault()));
					int num8;
					bool flag12;
					if ((theTarget.IsWeaponContact & obj4) != true)
					{
						num8 = 0;
					}
					else
					{
						flag12 = true;
						item.Behavior = TargetingEntry._TargetingBehavior.AutoSelfDefence;
						num8 = 0;
					}
					goto IL_167e;
					IL_0b9c:
					bool flag13 = (byte)num4 != 0;
					num6 = -1f;
					TargetingEntry._TargetingBehavior behavior = item.Behavior;
					if (behavior != TargetingEntry._TargetingBehavior.AutoTargeted && (uint)(behavior - 2) > 1u)
					{
						continue;
					}
					float num9 = 0f;
					if (!theTarget.IsBallisticTarget() && !theTarget.IsOrbitalContact)
					{
						if (!theTarget.IsAir_Missile_Orbital_Contact)
						{
							if (theTarget.IsShipContact)
							{
								if (flag8)
								{
									continue;
								}
								b = (byte?)wCS2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
									{
										Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " is on HOLD against surface targets");
									}
									continue;
								}
								num9 = num;
							}
							else if (theTarget.IsSubmergedContact)
							{
								if (flag10)
								{
									continue;
								}
								b = (byte?)wCS3;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
									{
										Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " is on HOLD against submerged targets");
									}
									continue;
								}
								num9 = num2;
							}
							else if (theTarget.IsLandContact)
							{
								if (flag9 && flag8)
								{
									continue;
								}
								b = (byte?)wCS4;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
									{
										Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " is on HOLD against land targets");
									}
									continue;
								}
								num9 = num3;
							}
						}
						else
						{
							b = (byte?)wCS;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
							{
								if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
								{
									Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " is on HOLD against air targets");
								}
								continue;
							}
							Weapon theWeapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true, CheckWRASelfDefenceRange: true);
							if (theWeapon == null)
							{
								theWeapon = myUnit.Weaponry.GetLongestRange_AAWeapon(theTarget);
							}
							num9 = myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon, ref theTarget, item.Behavior == TargetingEntry._TargetingBehavior.ManualTargeted);
						}
					}
					else
					{
						b = (byte?)wCS;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
						{
							continue;
						}
						Weapon theWeapon2 = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true, CheckWRASelfDefenceRange: true);
						if (theWeapon2 == null)
						{
							theWeapon2 = myUnit.Weaponry.GetLongestRange_AAWeapon(theTarget);
						}
						num9 = myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref theWeapon2, ref theTarget, item.Behavior == TargetingEntry._TargetingBehavior.ManualTargeted);
					}
					if (GameGeneral.HighIntensityResolution < 4f)
					{
						flag13 = true;
						float num10 = theTarget.ActualUnit.MaxSpeed + myUnit.MaxSpeed;
						if (num10 > 0f && Module_Unit.RangeToUnit_Slant(myUnit, theTarget, 0f, GlobalVariables.ObjectTrue) / num10 * 3600f < 20f)
						{
							GameGeneral.HighIntensityResolution = 4f;
						}
					}
					num6 = myUnit.RangeToUnit_Horiz_Alt(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					if (num6 > num9 && num9 > 0f)
					{
						continue;
					}
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(theTarget.ObjectID, out var value))
					{
						value = theTarget.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(theTarget.ObjectID, value);
					}
					if (value != Misc.PostureStance.Hostile)
					{
						if (theTarget.IsAir_Missile_Orbital_Contact)
						{
							b = (byte?)wCS;
							flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
							if (((!flag6) ?? flag6) == true)
							{
								continue;
							}
						}
						else if (theTarget.IsShipContact)
						{
							b = (byte?)wCS2;
							flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
							if (((!flag6) ?? flag6) == true)
							{
								continue;
							}
						}
						else if (theTarget.IsSubmergedContact)
						{
							if (theTarget.Type != Contact_Base.ContactType.Torpedo)
							{
								b = (byte?)wCS3;
								flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
								if (((!flag6) ?? flag6) == true)
								{
									continue;
								}
							}
						}
						else
						{
							b = (byte?)wCS4;
							flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
							if (((!flag6) ?? flag6) == true)
							{
								continue;
							}
						}
					}
					if (!theTarget.IsWeaponContact && (Threats_ReadOnly == null || !Threats_ReadOnly.Contains(theTarget)) && myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen) && theTarget != PrimaryTarget)
					{
						b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b != 1)) == true && pooledList.Count > 1)
						{
							if (list == null)
							{
								list = new List<Contact>();
								foreach (TargetingEntry item2 in pooledList)
								{
									list.Add(item2.Target);
								}
								list = myUnit.Doctrine.SortTargetsByPriority(myUnit.ParentScen, list);
							}
							if (!AllHigherPriorityTargetsAreCoveredByExistingSalvos(list, theTarget))
							{
								continue;
							}
						}
					}
					CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true);
					if (CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE == null)
					{
						continue;
					}
					int? num11 = 0;
					ref Weapon theW = ref CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE;
					Weapon theW2 = CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE;
					GlobalVariables.BooleanObject EmitterClassificable = null;
					Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW2, ref EmitterClassificable);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theW, ref theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
					float num12 = myUnit.Weaponry.WeaponOuterRangeLimit(ref myUnit, ref CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE, ref theTarget, ManualFire: false);
					Doctrine doctrine = myUnit.Doctrine;
					Doctrine doctrine2 = myUnit.Doctrine;
					Scenario parentScen = myUnit.ParentScen;
					Weapon theWeapon3 = CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE;
					float? TargetType_InheriteSelfDefenceRange = null;
					float? TargetType_UnspecifiedSelfDefenceRange = null;
					num7 = doctrine.WRA_SelfDefenceRange_AnyTargetType(doctrine2, parentScen, theWeapon3, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheriteSelfDefenceRange, ref TargetType_UnspecifiedSelfDefenceRange);
					TargetType_UnspecifiedSelfDefenceRange = num7;
					int num13;
					if (((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() == -99f)) == true)
					{
						num7 = (int)Math.Round(num12);
						num13 = 0;
					}
					else
					{
						num13 = 0;
					}
					flag12 = (byte)num13 != 0;
					bool generateFiringProposal = true;
					TargetType_UnspecifiedSelfDefenceRange = num7;
					if (((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() == 0f)) == true)
					{
						goto IL_1607;
					}
					TargetType_UnspecifiedSelfDefenceRange = num7;
					flag6 = ((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() > 0f));
					if (flag6 ?? true)
					{
						TargetType_UnspecifiedSelfDefenceRange = num7;
						if (((!TargetType_UnspecifiedSelfDefenceRange.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedSelfDefenceRange.GetValueOrDefault() <= num12)) == true)
						{
							if (flag6.HasValue)
							{
								goto IL_1607;
							}
							num8 = 0;
							goto IL_167e;
						}
					}
					num8 = 0;
					goto IL_167e;
					IL_167e:
					bool flag14 = (byte)num8 != 0;
					if (!flag12)
					{
						Doctrine doctrine3 = myUnit.Doctrine;
						Scenario parentScen2 = myUnit.ParentScen;
						Weapon theWeapon4 = CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE;
						int? TargetType_InheritedShooterQty = null;
						int? TargetType_UnspecifiedShooterQty = null;
						int? num14 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine3, parentScen2, theWeapon4, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedShooterQty, ref TargetType_UnspecifiedShooterQty);
						Doctrine doctrine4 = myUnit.Doctrine;
						Scenario parentScen3 = myUnit.ParentScen;
						Weapon theWeapon5 = CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE;
						TargetType_UnspecifiedShooterQty = null;
						TargetType_InheritedShooterQty = null;
						int? num15 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine4, parentScen3, theWeapon5, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedShooterQty, ref TargetType_InheritedShooterQty);
						TargetType_InheritedShooterQty = num15;
						if ((TargetType_InheritedShooterQty.HasValue ? new bool?(TargetType_InheritedShooterQty == -99) : ((bool?)null)) == true)
						{
							num15 = myUnit.Weaponry.HowManyOfThisWeapon(CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID) * Doctrine.GetShooterNumber(CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE, myUnit, theTarget, wRA_WeaponTargetType);
						}
						else
						{
							TargetType_InheritedShooterQty = num15;
							if (((!TargetType_InheritedShooterQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedShooterQty.GetValueOrDefault() < 0)) == true)
							{
								num15 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num15, ref myUnit, ref theTarget, ref CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE);
							}
						}
						int num16;
						if (((num15.HasValue & num11.HasValue) ? new bool?(num15.GetValueOrDefault() > num11.GetValueOrDefault()) : ((bool?)null)) != true)
						{
							num16 = 0;
						}
						else
						{
							Side side = myUnit.get_UnitSide(SetSideOnly: false);
							int? theWeaponQty_ToFire = num15;
							ActiveUnit activeUnit = myUnit;
							num11 = side.ConvertSalvoWeaponQty_To_ActualQuantity(theWeaponQty_ToFire, ref activeUnit, ref theTarget, ref CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE);
							num16 = 0;
						}
						int num17 = num16;
						Weapon[] incomingGuidedWeapons = theTarget.IncomingGuidedWeapons;
						for (int num18 = 0; num18 < incomingGuidedWeapons.Length; num18 = checked(num18 + 1))
						{
							if (incomingGuidedWeapons[num18].DBID == CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID)
							{
								num17++;
							}
						}
						if (num17 > 0 && ((!num15.HasValue) ? ((bool?)null) : new bool?(num17 >= num15.GetValueOrDefault())) == true)
						{
							continue;
						}
						int num19 = 0;
						ObservableList<WeaponSalvo> weaponSalvos = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos;
						int count = weaponSalvos.Count;
						try
						{
							if (count > 0)
							{
								int num20 = count - 1;
								for (int num21 = 0; num21 <= num20; num21++)
								{
									WeaponSalvo weaponSalvo;
									try
									{
										weaponSalvo = weaponSalvos[num21];
									}
									catch (Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
										continue;
									}
									if (string.CompareOrdinal(weaponSalvo?.Target.ObjectID, theTarget.ObjectID) != 0 || weaponSalvo.int_1 != CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID)
									{
										continue;
									}
									ActiveUnit value2;
									if (weaponSalvo.WpnQuantityAssigned == int.MaxValue)
									{
										if (weaponSalvo.ShootersList.Count() > 0 && myUnit.ParentScen.ActiveUnits.TryGetValue(weaponSalvo.ShootersList[0].ShooterObjectID, out value2))
										{
											num19 += value2.Weaponry.HowManyOfThisWeapon(CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID);
										}
									}
									else if (weaponSalvo.WpnQuantityFired < weaponSalvo.WpnQuantityAssigned)
									{
										int num22 = 0;
										if (weaponSalvo.ShootersList.Count() > 0)
										{
											WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
											for (int num23 = 0; num23 < shootersList.Length; num23 = checked(num23 + 1))
											{
												myUnit.ParentScen.ActiveUnits.TryGetValue(weaponSalvo.ShootersList.FirstOrDefault()?.ShooterObjectID, out value2);
												num22 += value2.Weaponry.AllDistinctWeaponsAboard_Actual().Where((CS$<>8__locals56.$I2 != null) ? CS$<>8__locals56.$I2 : (CS$<>8__locals56.$I2 = [SpecialName] (Weapon weapon) => weapon.DBID == CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID)).Count();
											}
											if (weaponSalvo.WpnQuantityFired + num22 >= weaponSalvo.WpnQuantityAssigned)
											{
												num19 += weaponSalvo.WpnQuantityAssigned;
											}
										}
									}
									else
									{
										num19 += weaponSalvo.WpnQuantityAssigned;
									}
									if (PrimaryTarget != null)
									{
										continue;
									}
									WeaponSalvo.Shooter[] shootersList2 = weaponSalvo.ShootersList;
									for (int num24 = 0; num24 < shootersList2.Length; num24 = checked(num24 + 1))
									{
										if (string.CompareOrdinal(shootersList2[num24].ShooterObjectID, myUnit.ObjectID) == 0)
										{
											PrimaryTarget = weaponSalvo.Target;
											flag7 = true;
										}
									}
								}
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 100054_00006", "");
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if ((num15.HasValue ? new bool?(num19 >= num15.GetValueOrDefault()) : ((bool?)null)) == true)
							{
								continue;
							}
							TargetType_InheritedShooterQty = num14;
							int value3;
							int num25;
							if ((TargetType_InheritedShooterQty.HasValue ? new bool?(TargetType_InheritedShooterQty == -99) : ((bool?)null)) == true)
							{
								value3 = int.MaxValue;
							}
							else
							{
								if (!flag14)
								{
									num25 = 0;
									goto IL_1b9f;
								}
								value3 = int.MaxValue;
							}
							num14 = value3;
							num25 = 0;
							goto IL_1b9f;
							IL_1b9f:
							int num26 = num25;
							bool? flag15 = null;
							TargetType_InheritedShooterQty = num14;
							if (((!TargetType_InheritedShooterQty.HasValue) ? ((bool?)null) : new bool?(TargetType_InheritedShooterQty != int.MaxValue)) == true)
							{
								int num27 = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count - 1;
								for (int num28 = 0; num28 <= num27; num28++)
								{
									WeaponSalvo weaponSalvo2;
									try
									{
										weaponSalvo2 = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos[num28];
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										ProjectData.ClearProjectError();
										continue;
									}
									if (weaponSalvo2 == null || string.CompareOrdinal(weaponSalvo2.Target?.ActualUnit?.ObjectID, theTarget.ActualUnit.ObjectID) != 0 || weaponSalvo2.int_1 != CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID || weaponSalvo2.WpnQuantityAssigned >= weaponSalvo2.MaxNumberOfWeapons)
									{
										continue;
									}
									num26 += weaponSalvo2.ShootersList.Count();
									if (!myUnit.IsGroupMember())
									{
										continue;
									}
									if (!flag15.HasValue)
									{
										flag15 = false;
									}
									WeaponSalvo.Shooter[] shootersList3 = weaponSalvo2.ShootersList;
									foreach (WeaponSalvo.Shooter shooter in shootersList3)
									{
										if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.ContainsKey(shooter.ShooterObjectID))
										{
											flag15 = true;
											break;
										}
									}
								}
							}
							flag6 = ((!num14.HasValue) ? ((bool?)null) : new bool?(num26 >= num14.GetValueOrDefault()));
							if ((((!flag6) ?? false) || flag15.HasValue || !flag6.HasValue) && ((!flag15) ?? flag15) != true)
							{
								goto IL_1e2d;
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 100054_00005", "");
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							goto IL_1e2d;
						}
						continue;
					}
					if (theTarget.ActualUnit != null && theTarget.ActualUnit.IsWeapon && theTarget.ActualUnit.AI.PrimaryTarget != null && theTarget.ActualUnit.AI.PrimaryTarget.ActualUnit == myUnit)
					{
						generateFiringProposal = false;
					}
					goto IL_1e2d;
					IL_1e2d:
					if (!IsClearedToEngageThisTarget(theTarget))
					{
						continue;
					}
					bool flag16 = false;
					if (myUnit.IsAircraft && ((Aircraft)myUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons)
						{
							if (!weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsWeaponPallet)
							{
								continue;
							}
							int num31;
							if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons.Count != 0)
							{
								num31 = 0;
							}
							else
							{
								weaponRec.get_ReferenceWeapon(myUnit.ParentScen).InitializeWeaponWeaponsPallet();
								num31 = 0;
							}
							int value4 = num31;
							Weapon theWeapon6 = new Weapon(myUnit.ParentScen);
							try
							{
								foreach (WeaponRec weaponWeapon in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
								{
									if (weaponWeapon.CurrentLoad > 0)
									{
										_ = weaponWeapon.CurrentLoad;
										theWeapon6 = weaponWeapon.get_ReferenceWeapon(myUnit.ParentScen);
										value4 = weaponWeapon.CurrentLoad * weaponRec.CurrentLoad;
										break;
									}
								}
							}
							catch (Exception ex7)
							{
								ProjectData.SetProjectError(ex7);
								Exception ex8 = ex7;
								ex8?.Data.Add("Error at 100054_00003", "");
								GameGeneral.WriteExceptionsToLog(ex8);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								if (myUnit.Doctrine.WRA_RelevantWeapon(ref theWeapon6))
								{
									Weapon theW3 = theWeapon6;
									EmitterClassificable = null;
									Doctrine._WRA_WeaponTargetType theTargetType2 = Contact.WRA_DetermineTargetType(ref theTarget, theW3, ref EmitterClassificable);
									Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon6, ref theTarget, ref theTargetType2, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
									Doctrine doctrine5 = myUnit.Doctrine;
									Scenario parentScen4 = myUnit.ParentScen;
									Weapon theWeapon7 = theWeapon6;
									int? TargetType_InheritedShooterQty = null;
									int? TargetType_UnspecifiedShooterQty = null;
									num32 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine5, parentScen4, theWeapon7, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedShooterQty, ref TargetType_UnspecifiedShooterQty);
									TargetType_UnspecifiedShooterQty = num32;
									if (((!TargetType_UnspecifiedShooterQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedShooterQty.GetValueOrDefault() == 0)) == true)
									{
										continue;
									}
									TargetType_UnspecifiedShooterQty = num32;
									if ((TargetType_UnspecifiedShooterQty.HasValue ? new bool?(TargetType_UnspecifiedShooterQty == -99) : ((bool?)null)) == true)
									{
										num32 = value4;
									}
									TargetType_UnspecifiedShooterQty = num32;
									if ((TargetType_UnspecifiedShooterQty.HasValue ? new bool?(TargetType_UnspecifiedShooterQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
									{
										num32 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num32, ref myUnit, ref theTarget, ref CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE);
									}
									if (!num32.HasValue)
									{
										continue;
									}
									Doctrine doctrine6 = myUnit.Doctrine;
									Doctrine doctrine7 = myUnit.Doctrine;
									Scenario parentScen5 = myUnit.ParentScen;
									int dBID = theWeapon6.DBID;
									TargetType_UnspecifiedSelfDefenceRange = null;
									TargetType_InheriteSelfDefenceRange = null;
									float? num33 = doctrine6.WRA_FiringRange_AnyTargetType(doctrine7, parentScen5, dBID, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedSelfDefenceRange, ref TargetType_InheriteSelfDefenceRange);
									if (!num33.HasValue)
									{
										num33 = -99f;
									}
									TargetType_InheriteSelfDefenceRange = num33;
									if ((TargetType_InheriteSelfDefenceRange.HasValue ? new bool?(TargetType_InheriteSelfDefenceRange.GetValueOrDefault() == 0f) : ((bool?)null)) == true)
									{
										continue;
									}
									TargetType_InheriteSelfDefenceRange = num33;
									flag6 = (TargetType_InheriteSelfDefenceRange.HasValue ? new bool?(TargetType_InheriteSelfDefenceRange.GetValueOrDefault() == -99f) : ((bool?)null));
									if (((!flag6) ?? flag6) == true)
									{
										float num34 = theWeapon6.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
										if (num6 == -1f)
										{
											num6 = myUnit.RangeToUnit_Horiz_Alt(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
										}
										if (num34 < num6)
										{
											continue;
										}
									}
								}
							}
							catch (Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								Exception ex10 = ex9;
								ex10?.Data.Add("Error at 100054_00002", "");
								GameGeneral.WriteExceptionsToLog(ex10);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								foreach (WeaponRec weaponWeapon2 in weaponRec.get_ReferenceWeapon(myUnit.ParentScen).WeaponWeapons)
								{
									if (weaponWeapon2.get_ReferenceWeapon(theTarget.ActualUnit.ParentScen).DBID == theWeapon6.DBID)
									{
										myUnit.Weaponry.CreateSalvo(theTarget, weaponWeapon2.int_3, num32.Value, IsManual: false, ref GunStrafingSalvo, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: true, RebuildSalvoCache: false);
										flag16 = true;
										break;
									}
								}
							}
							catch (Exception ex11)
							{
								ProjectData.SetProjectError(ex11);
								Exception ex12 = ex11;
								ex12?.Data.Add("Error at 100054_00001", "");
								GameGeneral.WriteExceptionsToLog(ex12);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
					}
					if (flag16)
					{
						continue;
					}
					try
					{
						if (myUnit.Weaponry.CreateSalvo(theTarget, CS$<>8__locals56.$VB$Local_theWeaponCANDIDATE.DBID, 0, IsManual: false, ref GunStrafingSalvo, DateTime.MinValue, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: false, generateFiringProposal, flag14, item.Behavior == TargetingEntry._TargetingBehavior.AutoSelfDefence))
						{
							int num35;
							if (flag13 && GameGeneral.HighIntensityResolution < 2f)
							{
								GameGeneral.HighIntensityResolution = 2f;
								num35 = 1;
							}
							else
							{
								num35 = 1;
							}
							flag7 = (byte)num35 != 0;
							break;
						}
					}
					catch (Exception ex13)
					{
						ProjectData.SetProjectError(ex13);
						Exception ex14 = ex13;
						ex14?.Data.Add("Error at 100054_0000", "");
						GameGeneral.WriteExceptionsToLog(ex14);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				flag7 = true;
			}
		}
		catch (Exception ex15)
		{
			ProjectData.SetProjectError(ex15);
			Exception ex16 = ex15;
			ex16?.Data.Add("Error at 100054", "");
			GameGeneral.WriteExceptionsToLog(ex16);
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
	}

	public bool AllHigherPriorityTargetsAreCoveredByExistingSalvos(List<Contact> PrioritizedTargets, Contact theTarget)
	{
		if (PrioritizedTargets != null && theTarget != null)
		{
			foreach (Contact PrioritizedTarget in PrioritizedTargets)
			{
				if (PrioritizedTarget != theTarget)
				{
					PooledList<WeaponSalvo> pooledList = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref myUnit, PrioritizedTarget);
					if (pooledList == null || pooledList.Count < 1)
					{
						return false;
					}
					foreach (WeaponSalvo item in pooledList)
					{
						if (item.WpnQuantityFired < item.WpnQuantityAssigned)
						{
							pooledList.Dispose();
							return false;
						}
					}
					pooledList?.Dispose();
					continue;
				}
				return true;
			}
		}
		return false;
	}

	public bool HasDuplicates(List<int> numbers)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int number in numbers)
		{
			if (!hashSet.Contains(number))
			{
				hashSet.Add(number);
				continue;
			}
			return true;
		}
		return false;
	}

	private List<TargetingEntry> method_8(ObservableDictionary<string, TargetingEntry> observableDictionary_1)
	{
		if (myUnit != null && observableDictionary_1.Count != 0)
		{
			if (observableDictionary_1.Count == 1)
			{
				List<TargetingEntry> list = new List<TargetingEntry>(1);
				using (IEnumerator<TargetingEntry> enumerator = observableDictionary_1.Values.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						TargetingEntry current = enumerator.Current;
						list.Add(current);
					}
				}
				return list;
			}
			List<TargetingEntry> list2 = new List<TargetingEntry>(observableDictionary_1.Count);
			foreach (TargetingEntry value in observableDictionary_1.Values)
			{
				list2.Add(value);
			}
			ListExtensions.SortByCachedKey(list2, [SpecialName] (TargetingEntry x) => myUnit.RangeToUnit_Horiz_Alt(x.Target, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
			return list2;
		}
		return new List<TargetingEntry>();
	}

	private void method_9(ref List<Contact> list_4)
	{
		int count = list_4.Count;
		LockRandom lockRandom = new LockRandom();
		int num = count;
		do
		{
			double num2 = lockRandom.NextDouble();
			int num3 = (int)Math.Round(Math.Floor((double)num * num2) + 1.0);
			Contact value = list_4[num3 - 1];
			list_4[num3 - 1] = list_4[num - 1];
			list_4[num - 1] = value;
			num--;
		}
		while (num > 1);
	}

	public virtual void ManouverAgainstPrimaryThreat(float elapsedTime)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void ManouverAwayFromWeaponEffects(float elapsedTime, Module_Unit.Unit theThreat)
	{
		double lat = theThreat.get_Latitude((GlobalVariables.BooleanObject)null);
		double lon = theThreat.get_Longitude((GlobalVariables.BooleanObject)null);
		if (theThreat.IsWeapon)
		{
			Weapon weapon = (Weapon)theThreat;
			if (weapon.AI.PrimaryTarget != null && (object)weapon.AI.PrimaryTarget.ActualUnit != this)
			{
				lat = ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				lon = ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
			}
		}
		else if ((object)theThreat.GetType() == typeof(UnguidedWeapon))
		{
			UnguidedWeapon unguidedWeapon = (UnguidedWeapon)theThreat;
			if (unguidedWeapon.Target != null && (object)unguidedWeapon.Target.ActualUnit != this)
			{
				lat = ((Module_Unit.Unit)unguidedWeapon.Target).get_Latitude((GlobalVariables.BooleanObject)null);
				lon = ((Module_Unit.Unit)unguidedWeapon.Target).get_Longitude((GlobalVariables.BooleanObject)null);
			}
		}
		float num = (float)Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), lat, lon), 0);
		if (!float.IsNegativeInfinity(num))
		{
			int ThreatBearing = (int)Math.Round(num);
			OutrunThreat(ref ThreatBearing);
		}
	}

	public float AngleOffContactsBoresight(ref Contact theContact, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		float result;
		try
		{
			float currentHeading = theContact.CurrentHeading;
			float num = Math2.CalcAzimuth(((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating));
			num = Math2.NormalizeBearing(num - currentHeading);
			currentHeading = 0f;
			result = ((!(num <= 180f)) ? (0f - (360f - num)) : num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100056", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float BearingToUnit_True(Module_Unit.Unit theTarget)
	{
		return Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
	}

	internal virtual bool PrimaryTargetLocated(ref Weapon theWeapon)
	{
		bool result;
		try
		{
			int num2;
			if (PrimaryTarget == null)
			{
				result = false;
			}
			else if (PrimaryTarget.get_IsDestroyed(myUnit.ParentScen))
			{
				result = false;
			}
			else
			{
				if ((theWeapon.Is_LOAL_capable && theWeapon.HasGoneAutonomous) || theWeapon.IsFullyAutonomous)
				{
					Contact[] targets_ReadOnly = Targets_ReadOnly;
					int num = 0;
					while (num < targets_ReadOnly.Length)
					{
						Contact contact = targets_ReadOnly[num];
						if (contact == null || contact.ActualUnit == null || PrimaryTarget == null || !ActiveUnit_Sensory.ContactsAreOfSameActualUnit(PrimaryTarget, contact))
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						goto end_IL_0001;
					}
				}
				if (theWeapon.DataLinkParent == null)
				{
					goto IL_01aa;
				}
				if (theWeapon.IsAAWCapable && PrimaryTarget.IsAir_GuidedWeapon_Contact && theWeapon.IsSemiAutonomous)
				{
					result = (theWeapon.DataLinkParent.Sensory.CanTrackThisContact_AAWFireControlGrade(theWeapon.AI.PrimaryTarget) ? true : false);
				}
				else
				{
					if (!theWeapon.IsAAWCapable || !PrimaryTarget.IsAir_Missile_Orbital_Contact)
					{
						goto IL_01aa;
					}
					if (theWeapon.DataLinkParent.Sensory.CanTrackThisContact_AAWFireControlGrade(theWeapon.AI.PrimaryTarget))
					{
						result = true;
					}
					else if (theWeapon.IsABMOptimized() && theWeapon.Navigator.HasPlottedCourse() && PrimaryTarget.IsBallisticTarget() && PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown && PrimaryTarget.AltitudeIsKnown)
					{
						result = true;
					}
					else
					{
						if (theWeapon.DataLinkParent == null)
						{
							num2 = 0;
							goto IL_01a4;
						}
						if (theWeapon.BlindTime != 0f)
						{
							num2 = 0;
							goto IL_01a4;
						}
						result = true;
					}
				}
			}
			goto end_IL_0001;
			IL_01a4:
			result = (byte)num2 != 0;
			goto end_IL_0001;
			IL_01aa:
			int num3;
			switch (theWeapon.Guidance)
			{
			default:
				num3 = 0;
				goto IL_0255;
			case Weapon.WeaponGuidanceType.Datalink_Plus_Active:
				if (!myUnit.IsTorpedo)
				{
					if (!theWeapon.IsAAWCapable)
					{
						result = theWeapon.BlindTime == 0f;
						break;
					}
					goto case Weapon.WeaponGuidanceType.Passive;
				}
				result = theWeapon.BlindTime == 0f;
				break;
			case Weapon.WeaponGuidanceType.CommandGuided_Datalinked:
				if (theWeapon.DataLinkParent == null)
				{
					num3 = 0;
					goto IL_0255;
				}
				if (theWeapon.BlindTime == 0f)
				{
					result = true;
					break;
				}
				goto case Weapon.WeaponGuidanceType.Passive;
			case Weapon.WeaponGuidanceType.Passive:
			case Weapon.WeaponGuidanceType.Inertial_Plus_Passive:
			case Weapon.WeaponGuidanceType.Active:
			case Weapon.WeaponGuidanceType.Inertial_Plus_Active:
			case Weapon.WeaponGuidanceType.BeamRiding:
			case Weapon.WeaponGuidanceType.Inertial:
				num3 = 0;
				goto IL_0255;
			case Weapon.WeaponGuidanceType.SemiActive:
			case Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive:
			case Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive:
			case Weapon.WeaponGuidanceType.DataLink_Plus_Passive:
			case Weapon.WeaponGuidanceType.TVM:
			case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
			case Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				{
					result = theWeapon.BlindTime == 0f;
					break;
				}
				IL_0255:
				result = (byte)num3 != 0;
				break;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100057", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float BearingToUnit_NextSecond(Module_Unit.Unit theTarget)
	{
		float result;
		try
		{
			float distance_NM = theTarget.get_HorizMovementDistanceOnThisTime(1f);
			float distance_NM2 = ((Module_Unit.Unit)myUnit).get_HorizMovementDistanceOnThisTime(1f);
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, theTarget.CurrentHeading);
			float bearing = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
			double out_lon2 = default(double);
			double out_lat2 = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, distance_NM2, bearing);
			result = Math2.CalcAzimuth(out_lat2, out_lon2, out_lat, out_lon);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100058", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float BearingToUnit_Relative(Module_Unit.Unit theTarget)
	{
		float result;
		try
		{
			float currentHeading = myUnit.CurrentHeading;
			float num = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
			num = Math2.NormalizeBearing(num - currentHeading);
			currentHeading = 0f;
			result = ((!(num > 180f)) ? num : (0f - (360f - num)));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100059", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float BearingToPoint_True(double theLat, double theLon)
	{
		return Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theLat, theLon);
	}

	public float BearingToPoint_Relative(double theLat, double theLon)
	{
		float result;
		try
		{
			float currentHeading = myUnit.CurrentHeading;
			float num = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theLat, theLon);
			num = Math2.NormalizeBearing(num - currentHeading);
			currentHeading = 0f;
			result = ((!(num <= 180f)) ? (0f - (360f - num)) : num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100060", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float DistanceFromThreat(Module_Unit.Unit theUnit, ref Contact theThreat)
	{
		return Math2.CalcDist(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theThreat).get_Longitude((GlobalVariables.BooleanObject)null));
	}

	public void OutrunThreat(ref int ThreatBearing)
	{
		try
		{
			float num = Math2.NormalizeBearing(ThreatBearing + 180);
			if (myUnit.IsShip || myUnit.IsSubmarine)
			{
				float distance_NM = 2f;
				bool flag = false;
				int num2 = 0;
				double out_lon = default(double);
				double out_lat = default(double);
				while (!flag && num2 < 72)
				{
					num2++;
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, num);
					ActiveUnit_Navigator navigator = myUnit.Navigator;
					double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double destLat = out_lat;
					double destLon = out_lon;
					float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
					int ReasonForInterrupt = 0;
					GeoPoint InterruptLocation = null;
					if (navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
					{
						num += 5f;
					}
					else
					{
						flag = true;
					}
				}
			}
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100061", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsClearedToEngageThisTarget(Contact theT, bool setStatus = true)
	{
		bool result;
		if (myUnit != null)
		{
			if (theT == null)
			{
				result = false;
			}
			else if (theT.ActualUnit == null)
			{
				result = false;
			}
			else
			{
				foreach (NoNavZone noNavZone in myUnit.get_UnitSide(SetSideOnly: false).NoNavZones)
				{
					try
					{
						if (noNavZone.Area.Count != 0 && noNavZone.IsActive && ((Zone)noNavZone).get_AffectsThisUnit(theT.ActualUnit) && GeoPoint.IsInsideThisArea(theT.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null), theT.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null), noNavZone.Area_AsArray) && noNavZone.Type == Zone.ZoneType.NoNavZone && noNavZone.NoFireZone)
						{
							result = false;
							goto IL_099b;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 987654321000030", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (myUnit.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)myUnit;
					if (aircraft.ActiveMissionOrPackage() != null && aircraft.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)aircraft.ActiveMissionOrPackage();
						bool flag = false;
						if (strike.SpecificTargets != null)
						{
							try
							{
								foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
								{
									Contact contactForThisUnit = GetContactForThisUnit(specificTarget);
									if (contactForThisUnit == null)
									{
										continue;
									}
									int num;
									if (contactForThisUnit != theT)
									{
										if (contactForThisUnit.ActualUnit != theT.ActualUnit)
										{
											continue;
										}
										num = 1;
									}
									else
									{
										num = 1;
									}
									flag = (byte)num != 0;
									break;
								}
								if (!flag && aircraft.Navigator.HasFlightPlan)
								{
									Waypoint[] flightPlan = ((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
									foreach (Waypoint waypoint in flightPlan)
									{
										if (waypoint.Type != Waypoint.WaypointType.WeaponTarget)
										{
											continue;
										}
										foreach (Mission.TargeteeringEntry targeteering in waypoint.TargeteeringList)
										{
											int num2;
											if (Operators.CompareString(theT.ObjectID, targeteering.Target_ContactObjectID, false) != 0)
											{
												if (Operators.CompareString(theT.ActualUnit.ObjectID, targeteering.Target_ActualUnitObjectID, false) != 0)
												{
													continue;
												}
												num2 = 1;
											}
											else
											{
												num2 = 1;
											}
											flag = (byte)num2 != 0;
											break;
										}
										if (flag)
										{
											break;
										}
									}
								}
							}
							catch (Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								Exception ex4 = ex3;
								ex4?.Data.Add("Error at 1144455777", "");
								GameGeneral.WriteExceptionsToLog(ex4);
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
								goto IL_099b;
							}
						}
						if (flag)
						{
							try
							{
								if (aircraft.Navigator.HasFlightPlan)
								{
									if (aircraft.Navigator.CurrentFlightHasStandoffWeaponFiringPoint())
									{
										if (!aircraft.Navigator.HasReachedWeaponReleasePoint(!setStatus) && aircraft.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
										{
											result = false;
											goto IL_099b;
										}
									}
									else if (aircraft.Navigator.PlottedCourse != null && aircraft.Navigator.PlottedCourse.Count() > 0 && aircraft.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Target)
									{
										result = true;
										goto IL_099b;
									}
								}
							}
							catch (Exception ex5)
							{
								ProjectData.SetProjectError(ex5);
								Exception ex6 = ex5;
								ex6?.Data.Add("Error at 78587272299", "");
								GameGeneral.WriteExceptionsToLog(ex6);
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
								goto IL_099b;
							}
						}
					}
				}
				Misc.PostureStance value;
				try
				{
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(theT.ObjectID, out value))
					{
						value = theT.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(theT.ObjectID, value);
					}
					int num5;
					if (theT.Type == Contact_Base.ContactType.Aimpoint)
					{
						num5 = 1;
						goto IL_040e;
					}
					if (theT.Type == Contact_Base.ContactType.ActivationPoint)
					{
						num5 = 1;
						goto IL_040e;
					}
					goto end_IL_03a4;
					IL_040e:
					result = (byte)num5 != 0;
					goto IL_099b;
					end_IL_03a4:;
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 9672577774522", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					int num6;
					if (!Debugger.IsAttached)
					{
						num6 = 0;
					}
					else
					{
						Debugger.Break();
						num6 = 0;
					}
					result = (byte)num6 != 0;
					ProjectData.ClearProjectError();
					goto IL_099b;
				}
				if (TargetingBehaviorForThisTarget(theT, null) == TargetingEntry._TargetingBehavior.ManualTargeted)
				{
					result = true;
				}
				else if (value == Misc.PostureStance.Hostile)
				{
					try
					{
						int num7;
						if (theT.IsAir_Missile_Orbital_Contact)
						{
							byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Air(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								num7 = 1;
								goto IL_06af;
							}
							result = false;
						}
						else if (!theT.IsShipContact)
						{
							if (!theT.IsSubmergedContact)
							{
								byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Land(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
								{
									goto IL_06ae;
								}
								result = false;
							}
							else
							{
								byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Submarine(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
								{
									goto IL_06ae;
								}
								result = false;
							}
						}
						else
						{
							byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Surface(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								goto IL_06ae;
							}
							result = false;
						}
						goto end_IL_0475;
						IL_06ae:
						num7 = 1;
						goto IL_06af;
						IL_06af:
						result = (byte)num7 != 0;
						end_IL_0475:;
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						ex10?.Data.Add("Error at 417417577777", "");
						GameGeneral.WriteExceptionsToLog(ex10);
						int num8;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num8 = 0;
						}
						else
						{
							num8 = 0;
						}
						result = (byte)num8 != 0;
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					if (value == Misc.PostureStance.Unknown || value == Misc.PostureStance.Unfriendly)
					{
						try
						{
							if (!theT.IsAir_Missile_Orbital_Contact)
							{
								if (theT.IsShipContact)
								{
									byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Surface(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										result = true;
										goto IL_099b;
									}
								}
								else if (!theT.IsSubmergedContact)
								{
									byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Land(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										result = true;
										goto IL_099b;
									}
								}
								else
								{
									if (theT.Type == Contact_Base.ContactType.Torpedo)
									{
										result = true;
										goto IL_099b;
									}
									byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Submarine(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										result = true;
										goto IL_099b;
									}
								}
							}
							else
							{
								byte? b = (byte?)myUnit.Doctrine.get_WeaponControlStatus_Air(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
								{
									result = true;
									goto IL_099b;
								}
							}
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 724287888", "");
							GameGeneral.WriteExceptionsToLog(ex12);
							int num9;
							if (!Debugger.IsAttached)
							{
								num9 = 0;
							}
							else
							{
								Debugger.Break();
								num9 = 0;
							}
							result = (byte)num9 != 0;
							ProjectData.ClearProjectError();
							goto IL_099b;
						}
					}
					result = true;
				}
			}
		}
		else
		{
			result = false;
		}
		goto IL_099b;
		IL_099b:
		return result;
	}

	public virtual void OptimizeAltSpeedForNextEngagement(float elapsedTime, Weapon weaponBeingGuided, Weapon mostSuitableWeapon)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		try
		{
			Weapon weapon = default(Weapon);
			if (weaponBeingGuided == null)
			{
				if (mostSuitableWeapon != null)
				{
					weapon = mostSuitableWeapon;
				}
			}
			else
			{
				weapon = weaponBeingGuided;
			}
			if (Information.IsNothing((object)PrimaryTarget))
			{
				return;
			}
			Doctrine doctrine = myUnit.Doctrine;
			if (Information.IsNothing((object)weapon))
			{
				Side side = myUnit.get_UnitSide(SetSideOnly: false);
				ref ActiveUnit theAttacker = ref myUnit;
				Contact theTarget = PrimaryTarget;
				List<Weapon> list = side.WeaponsLeftToFireAtThisTarget(ref theAttacker, ref theTarget);
				PrimaryTarget = theTarget;
				List<Weapon> list2 = list;
				weapon = ((list2.Count <= 0) ? myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, doctrine) : list2.OrderByDescending([SpecialName] (Weapon theWeapon) => theWeapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false)).ElementAtOrDefault(0));
			}
			if (Information.IsNothing((object)weapon))
			{
				return;
			}
			float num = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
			float closureSpeed = ((PrimaryTarget.CurrentSpeed != 0f) ? Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading) : myUnit.CurrentSpeed);
			Weapon._WeaponType type = weapon.Type;
			float num2 = default(float);
			if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
			{
				num2 = weapon.MaxLaunchAlt_AGL;
			}
			else if (Module_Unit.RangeToUnit_Slant(myUnit, PrimaryTarget) > num)
			{
				num2 = (float)(Math.Sqrt(2.0) / 2.0 * (double)num * 1852.0);
			}
			float num3 = default(float);
			if (num2 < myUnit.DesiredAltitude)
			{
				num3 = (myUnit.DesiredAltitude - num2) / myUnit.Kinematics.DiveRate_Nominal();
			}
			if (weapon.MinLaunchAlt_AGL > myUnit.DesiredAltitude)
			{
				num3 = (weapon.MinLaunchAlt_AGL - myUnit.DesiredAltitude) / myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
			}
			float num4 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			float num5;
			if (num4 > num)
			{
				float distance = num4 - num;
				num5 = myUnit.ETA_To_Location(closureSpeed, distance);
			}
			else
			{
				num5 = 0f;
			}
			if (num5 < 0f)
			{
				return;
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				bool flag = false;
				if (num3 >= num5)
				{
					if (num2 < myUnit.DesiredAltitude)
					{
						myUnit.DesiredAltitude = num2 - 100f;
						flag = true;
					}
					if (weapon.MinLaunchAlt_AGL > myUnit.DesiredAltitude)
					{
						myUnit.DesiredAltitude = weapon.MinLaunchAlt_AGL + 100f;
						flag = true;
					}
					if (!flag)
					{
						myUnit.DesiredAltitude = myUnit.DesiredAltitude;
					}
				}
			}
			if ((double)num * 1.2 < (double)num4)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				return;
			}
			if (weapon.MaxLaunchSpeed != 0 && (float)weapon.MaxLaunchSpeed < myUnit.CurrentSpeed)
			{
				myUnit.DesiredSpeed = weapon.MaxLaunchSpeed - 10;
			}
			if (weapon.MinLaunchSpeed != 0 && (float)weapon.MinLaunchSpeed > myUnit.CurrentSpeed)
			{
				myUnit.DesiredSpeed = weapon.MinLaunchSpeed + 10;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100063", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void BeamThreat(int ThreatBearing)
	{
		try
		{
			int num = (int)Math.Round(myUnit.CurrentHeading);
			int num2 = 0;
			int num3 = 0;
			int num4 = num;
			while (!MathFunctions.ArePerpendicular(num4, ThreatBearing))
			{
				num4 = Math2.NormalizeBearing(num4 - 1);
				num2++;
			}
			int num5 = num;
			while (!MathFunctions.ArePerpendicular(num5, ThreatBearing))
			{
				num5 = Math2.NormalizeBearing(num5 + 1);
				num3++;
			}
			if (num2 < num3)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num4);
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100064", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void EvaluateThreats(float elapsedTime)
	{
	}

	protected void ManouverToNeutralizeMine(UnguidedWeapon theMine, float RangeToMine)
	{
		try
		{
			if (myUnit.MineCountermeasures.Count == 0)
			{
				return;
			}
			if ((double)RangeToMine * 1852.0 < 20.0)
			{
				foreach (Sensor mineCountermeasure in myUnit.MineCountermeasures)
				{
					if (!mineCountermeasure.get_CanSweepThisMine(theMine) || !mineCountermeasure.IsActive())
					{
						continue;
					}
					if (theMine.TimeToDetonate > 0f)
					{
						switch (mineCountermeasure.Type)
						{
						case Sensor.Sensor_Type.MineSweep_MechanicalCableCutter:
						case Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter:
							if (theMine.Type != Weapon._WeaponType.MooredMine && theMine.Type == Weapon._WeaponType.DummyMine)
							{
							}
							break;
						}
						continue;
					}
					if (!myUnit.HasMineDisposalCharges || myUnit.MineCountermeasures.Count <= 1 || !((double)RangeToMine * 1852.0 > 10.0))
					{
						if (mineCountermeasure.IsExplosiveMineNeutralizer || mineCountermeasure.Status != PlatformComponent._ComponentStatus.Operational)
						{
							if (!mineCountermeasure.IsExplosiveMineNeutralizer || mineCountermeasure.Status != PlatformComponent._ComponentStatus.Operational)
							{
								continue;
							}
							myUnit.NeutralizeMine(theMine, mineCountermeasure);
							return;
						}
						myUnit.NeutralizeMine(theMine, mineCountermeasure);
						return;
					}
					break;
				}
			}
			GeoPoint geoPoint = new GeoPoint();
			if ((double)RangeToMine > 0.6)
			{
				double lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				GeoPoint geoPoint2;
				double out_lon = (geoPoint2 = geoPoint).Longitude;
				GeoPoint geoPoint3;
				double out_lat = (geoPoint3 = geoPoint).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, RangeToMine / 2f, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null)));
				geoPoint3.Latitude = out_lat;
				geoPoint2.Longitude = out_lon;
				if (!myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.AddWaypoint(new Waypoint(geoPoint.Longitude, geoPoint.Latitude, geoPoint.Altitude, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
				else
				{
					myUnit.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
					myUnit.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
				}
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null)));
			}
			else if (myUnit.Navigator.HasPlottedCourse())
			{
				if ((float)((double)Math2.CalcDist(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) + 0.1) > RangeToMine)
				{
					double lon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double lat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					GeoPoint geoPoint3;
					double out_lat = (geoPoint3 = geoPoint).Longitude;
					GeoPoint geoPoint2;
					double out_lon = (geoPoint2 = geoPoint).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lat, ref out_lon, RangeToMine / 2f, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null)));
					geoPoint2.Latitude = out_lon;
					geoPoint3.Longitude = out_lat;
					myUnit.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
					myUnit.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
				}
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100065", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected internal void ManouverToSweepMine(UnguidedWeapon theMine, float RangeToMine, bool ResetPath = false)
	{
		try
		{
			if (myUnit.MineCountermeasures.Count == 0)
			{
				return;
			}
			if (!ResetPath && (double)RangeToMine < 0.5 && myUnit.Navigator.HasPlottedCourse())
			{
				float num = (float)((double)Math2.CalcDist(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) + 0.1);
				if ((myUnit.IsSubmarine && (((Submarine)myUnit).Type == Submarine._SubmarineType.UUV || ((Submarine)myUnit).Type == Submarine._SubmarineType.ROV)) || myUnit.IsAircraft || !((double)num - 0.3 > (double)RangeToMine))
				{
					return;
				}
			}
			Sensor sensor = null;
			foreach (Sensor mineCountermeasure in myUnit.MineCountermeasures)
			{
				if (mineCountermeasure.IsActive() && (mineCountermeasure.get_CanSweepThisMine(theMine) || mineCountermeasure.get_CanTriggerThisMine(theMine)))
				{
					sensor = mineCountermeasure;
					break;
				}
			}
			if (sensor != null && sensor.MineSweepCoverageArea != null)
			{
				Geopoint_Struct geopoint_Struct = Misc.Center(sensor.MineSweepCoverageArea);
				_ = (float)((double)Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null)) + 0.1);
				float num2;
				if (myUnit.IsAircraft)
				{
					num2 = GameGeneral.GlobalRNG.Next(0, 5);
				}
				else
				{
					num2 = Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, Math2.CalcAzimuth(geopoint_Struct.Latitude, geopoint_Struct.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null))));
					num2 += (float)((sensor.MineSweepCoverageArea.Length - 1) * 5);
				}
				float num3 = (float)((double)Math2.CalcDist(geopoint_Struct.Latitude, geopoint_Struct.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) + 0.15);
				GeoPoint geoPoint = new GeoPoint();
				if (myUnit.IsAircraft)
				{
					num3 *= 4f;
					if (((Aircraft)myUnit).get_CanHover(bool_7: true))
					{
						myUnit.DesiredSpeed = 0f;
					}
				}
				double lon = ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null);
				double lat = ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null);
				GeoPoint geoPoint2;
				double out_lon = (geoPoint2 = geoPoint).Longitude;
				GeoPoint geoPoint3;
				double out_lat = (geoPoint3 = geoPoint).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, num3, Math2.NormalizeBearing(num2 + Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theMine).get_Longitude((GlobalVariables.BooleanObject)null))));
				geoPoint3.Latitude = out_lat;
				geoPoint2.Longitude = out_lon;
				bool CheckNoNavZones = false;
				bool CheckForMines = false;
				if (myUnit.IsShip || myUnit.IsSubmarine)
				{
					ActiveUnit activeUnit = myUnit;
					double longitude = geoPoint.Longitude;
					double latitude = geoPoint.Latitude;
					int MovementCost = 0;
					float? distanceFromUnit = 0f;
					List<ActiveUnit> ProvidedPiers = null;
					string UserFeedback = "";
					bool AllowBounce = false;
					if (activeUnit.CanMoveToThisLocation(longitude, latitude, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, distanceFromUnit, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce) && (CheckForMines || CheckNoNavZones))
					{
						return;
					}
				}
				if (!myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.AddWaypoint(new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
				else if (myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
				{
					myUnit.Navigator.PlottedCourse[0].Longitude = geoPoint.Longitude;
					myUnit.Navigator.PlottedCourse[0].Latitude = geoPoint.Latitude;
					myUnit.Navigator.PlottedCourse[0].Description = "Mine clearing endpoint";
				}
				else
				{
					myUnit.Navigator.AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					myUnit.Navigator.PlottedCourse[0].Description = "Mine clearing endpoint";
				}
			}
			else if (!myUnit.Navigator.HasPlottedCourse() && !Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				if (myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
				{
					myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
				}
				myUnit.Navigator.PlotCourseToStationArea(1f, AddWaypointToExistingPlottedCourse: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100066", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool MustSlowDownToAllowGroupFormUp()
	{
		bool result;
		try
		{
			if (myUnit == null)
			{
				result = false;
			}
			else if (myUnit.IsGroupLead())
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.LeadAllowedToSlowDown)
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.SurfaceGroup && myUnit.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup && myUnit.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.MobileGroup)
					{
						result = false;
					}
					else
					{
						List<ActiveUnit> list = new List<ActiveUnit>();
						foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value != myUnit && value.IsOperating() && (object)value.GetType() == myUnit.GetType())
							{
								list.Add(value);
							}
						}
						int num = list.Count - 1;
						while (true)
						{
							if (num >= 0)
							{
								ActiveUnit current = list[num];
								if (current.Navigator.SprintDrift || current.Navigator.HaveReachedFormationStation())
								{
									num += -1;
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
			ex2?.Data.Add("Error at 200356", ex2.Message);
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

	public void Common_FollowRoadNetwork(float elapsedTime)
	{
		if (!myUnit.IsAggregatedUnit && !Module_ActiveUnit.IsAimpointFacility(myUnit) && !myUnit.IsVehicle)
		{
			return;
		}
		if (!myUnit.Navigator.HasPlottedCourse() && !myUnit.Navigator.HasRoadSystemPlottedCourse() && myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.FullStop && myUnit.DesiredSpeed != 0f)
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
			return;
		}
		if ((myUnit.Navigator.HasPlottedCourse() || myUnit.Navigator.HasRoadSystemPlottedCourse()) && myUnit.DesiredSpeed == 0f)
		{
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
			else
			{
				myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise, (int)Math.Round(myUnit.DesiredSpeed));
			}
		}
		myUnit.Navigator.HeadToRoadSystemDestination(elapsedTime);
	}

	public virtual void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		try
		{
			myUnit.Navigator.IsManouveringToFormationStation = false;
			if (myUnit.IsSatellite)
			{
				return;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(elapsedTime, WeaponThreat);
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive && (myUnit.IsAircraft || myUnit.IsShip || myUnit.IsSubmarine))
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				ManouverAgainstPrimaryThreat(elapsedTime);
				return;
			}
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					return;
				}
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				return;
			}
			if (myUnit.IsRTB)
			{
				if (!((Aircraft)myUnit).Navigator.HasReachedLandingAssemblyPoint(((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: true)))
				{
					Aircraft_Navigator navigator = ((Aircraft)myUnit).Navigator;
					ActiveUnit landingDestination = ((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: true);
					float theSpeed = myUnit.Kinematics.GetMaximumSpeed(((Aircraft)myUnit).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
					Aircraft_Navigator navigator2 = ((Aircraft)myUnit).Navigator;
					ActiveUnit activeUnit;
					ActiveUnit theAU;
					bool theAltitude_TerrainFollowing = (activeUnit = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
					float bingoFuelAltitude = navigator2.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
					activeUnit.set_DesiredAltitude_UseTerrainFollowing(theAU, theAltitude_TerrainFollowing);
					ActiveUnit activeUnit2;
					ActiveUnit theAU2;
					bool useTerrainFollowing = (activeUnit2 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU2 = myUnit);
					navigator.HeadToLandingAssemblyPoint(elapsedTime, landingDestination, theSpeed, bingoFuelAltitude, ref useTerrainFollowing);
					activeUnit2.set_DesiredAltitude_UseTerrainFollowing(theAU2, useTerrainFollowing);
				}
				else
				{
					if (!((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: true).AirOps.LandingQueue_ReadOnly.Contains((Aircraft)myUnit))
					{
						((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: true).AirOps.LandingQueue_AddAircraft((Aircraft)myUnit);
					}
					((Aircraft)myUnit).Kinematics.Loiter(elapsedTime);
				}
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				if (Information.IsNothing((object)PrimaryTarget))
				{
					return;
				}
				Contact_Base.ContactType type = PrimaryTarget.Type;
				if (type <= Contact_Base.ContactType.Missile)
				{
					myUnit.DesiredSpeed = 0f;
					return;
				}
				if ((int)myUnit.ThrottleSetting < 3)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				}
				ManouverTowardsTarget(elapsedTime);
				OptimizeAltSpeedForNextEngagement(elapsedTime, null, null);
				return;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				if (myUnit.IsGroupLead())
				{
					myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
				}
				return;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPatrol)
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (!Information.IsNothing((object)patrol))
				{
					if (!myUnit.IsGroupMember())
					{
						if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							return;
						}
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					}
					else if (!myUnit.IsGroupLead())
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					}
					else
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
					}
					return;
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				if (myUnit.IsSubmarine && !myUnit.Kinematics.DesiredAltitudeOverride)
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2f, IgnoreTimeToNextEvaluation: false))
					{
						if (patrol.TransitDepth_Submarine.Value < 0f)
						{
							myUnit.DesiredAltitude = patrol.TransitDepth_Submarine.Value;
						}
					}
					else if (patrol.StationDepth_Submarine.Value < 0f)
					{
						myUnit.DesiredAltitude = patrol.StationDepth_Submarine.Value;
					}
				}
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnSupportMission)
			{
				if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
				{
					if (!myUnit.IsGroupMember())
					{
						myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
						return;
					}
					if (myUnit.IsGroupLead())
					{
						myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
						return;
					}
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						return;
					}
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
			}
			if (myUnit.IsGroupMember() && myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
			}
			else if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				myUnit.DesiredSpeed = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100068", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float ConvertAltitudePresetToValue(AircraftAltitudePreset DepthPreset, float? AltCustom = null, float presetAltitude = 0f, float presetAltitudeFallback = 0f)
	{
		switch (DepthPreset)
		{
		case AircraftAltitudePreset.MinAltitude:
			return 6.096f;
		case AircraftAltitudePreset.Low1000:
			return 304.8f;
		case AircraftAltitudePreset.Low2000:
			return 609.6f;
		case AircraftAltitudePreset.const_4:
			return 3657.6f;
		case AircraftAltitudePreset.const_5:
			return 7620f;
		case AircraftAltitudePreset.const_6:
			return 10972.8f;
		case AircraftAltitudePreset.MaxAltitude:
			return 200000f;
		case AircraftAltitudePreset.Custom:
			if (AltCustom.HasValue)
			{
				return AltCustom.Value;
			}
			goto default;
		default:
			return 0f;
		case AircraftAltitudePreset.LoadoutAltitude:
			return GetOptimalLoadoutAltitude(presetAltitude, presetAltitudeFallback);
		}
	}

	public static float? ConvertAltitudePresetToValue_AI(AircraftAltitudePreset AltPreset, float? AltCustom = null, float presetAltitude = 0f, float presetAltitudeFallback = 0f)
	{
		AircraftAltitudePreset aircraftAltitudePreset = AltPreset;
		return (aircraftAltitudePreset != AircraftAltitudePreset.LoadoutAltitude) ? new float?(ConvertAltitudePresetToValue(AltPreset, AltCustom, presetAltitude, presetAltitudeFallback)) : ((presetAltitude != 0f || presetAltitudeFallback != 0f) ? new float?(GetOptimalLoadoutAltitude(presetAltitude, presetAltitudeFallback)) : new float?(200000f));
	}

	public static float GetOptimalLoadoutAltitude(float presetAltitude, float presetAltitudeFallback = 0f)
	{
		if (presetAltitude != 0f)
		{
			return presetAltitude;
		}
		if (presetAltitudeFallback != 0f)
		{
			return presetAltitudeFallback;
		}
		return 200000f;
	}

	public virtual void FollowAltitudePreset()
	{
		if (myUnit == null || !myUnit.Kinematics.DesiredAltitudeOverride)
		{
			return;
		}
		switch (((Aircraft)myUnit).AI.AltitudePreset)
		{
		case AircraftAltitudePreset.MinAltitude:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude = myUnit.Kinematics.GetMinimumAltitude();
			}
			else
			{
				myUnit.DesiredAltitude_AGL = 6.096f;
			}
			break;
		case AircraftAltitudePreset.Low1000:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude = 304.8f;
			}
			else
			{
				myUnit.DesiredAltitude_AGL = 304.8f;
			}
			break;
		case AircraftAltitudePreset.Low2000:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude = 609.6f;
			}
			else
			{
				myUnit.DesiredAltitude_AGL = 609.6f;
			}
			break;
		case AircraftAltitudePreset.const_4:
			if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude_AGL = 3657.6f;
			}
			else
			{
				myUnit.DesiredAltitude = 3657.6f;
			}
			break;
		case AircraftAltitudePreset.const_5:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude = 7620f;
			}
			else
			{
				myUnit.DesiredAltitude_AGL = 7620f;
			}
			break;
		case AircraftAltitudePreset.const_6:
			if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude_AGL = 10972.8f;
			}
			else
			{
				myUnit.DesiredAltitude = 10972.8f;
			}
			break;
		case AircraftAltitudePreset.MaxAltitude:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				myUnit.DesiredAltitude = myUnit.Kinematics.GetMaximumAltitude();
			}
			else
			{
				myUnit.DesiredAltitude_AGL = myUnit.Kinematics.GetMaximumAltitude();
			}
			break;
		case AircraftAltitudePreset.None:
			break;
		}
	}

	internal bool HandleWithdrawal(WithdrawReason theReason, string ReasonString)
	{
		bool result;
		try
		{
			int num;
			switch (theReason)
			{
			default:
				num = 0;
				goto IL_0036;
			case WithdrawReason.HighDamage:
				if (!myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
				{
					num = 0;
					goto IL_0036;
				}
				myUnit.AddMessage(myUnit.Name + " is withdrawing (Reason: " + ReasonString + "). ", "Unit withdrawing", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				result = true;
				break;
			case WithdrawReason.LowFuel:
			{
				bool flag2 = false;
				if (myUnit.DockingOps.AttemptToScheduleUNREP(myUnit.AI.IntermediateTargetPointForRefuelCalcs(), null, null, IsManualOrder: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					flag2 = true;
				}
				else if (myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
				{
					flag2 = true;
				}
				if (flag2)
				{
					myUnit.AddMessage(myUnit.Name + " is withdrawing (Reason: " + ReasonString + "). ", "Unit withdrawing", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				result = flag2;
				break;
			}
			case WithdrawReason.LowAttackAmmo:
			case WithdrawReason.LowDefenceAmmo:
				{
					bool flag = false;
					ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
					string UserFeedback = null;
					List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(MustBeAbleToReachItDirectly: true, null, ref UserFeedback, ActiveUnit_DockingOps.ResupplyRequest.Material);
					if (potentialUNREPunits.Count > 0)
					{
						Weapon weapon = ((theReason == WithdrawReason.LowAttackAmmo) ? ((myUnit.Weaponry.PrimaryAttackWeapon_Actual != null) ? myUnit.Weaponry.PrimaryAttackWeapon_Actual : myUnit.Weaponry.PrimaryAttackWeapon_Default) : ((myUnit.Weaponry.PrimaryDefenceWeapon_Actual == null) ? myUnit.Weaponry.PrimaryDefenceWeapon_Default : myUnit.Weaponry.PrimaryDefenceWeapon_Actual));
						if (weapon != null)
						{
							foreach (ActiveUnit item in potentialUNREPunits)
							{
								if (item.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false) > 0 && myUnit.DockingOps.AttemptToScheduleUNREP(myUnit.AI.IntermediateTargetPointForRefuelCalcs(), item, null, IsManualOrder: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
								{
									myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
									flag = true;
									break;
								}
							}
						}
					}
					else if (myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
					{
						flag = true;
					}
					if (flag)
					{
						myUnit.AddMessage(myUnit.Name + " is withdrawing (Reason: " + ReasonString + "). ", "Unit withdrawing", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					result = flag;
					break;
				}
				IL_0036:
				result = (byte)num != 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101358", "");
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

	internal bool CheckForWithdrawalCriteria()
	{
		bool result;
		if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			result = false;
		}
		else
		{
			try
			{
				Doctrine._DamageThreshold? damageThreshold = myUnit.Doctrine.get_WithdrawDamageThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				short? num = (short?)damageThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					goto IL_02b1;
				}
				num = (short?)damageThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
				{
					if (!(myUnit.Damage.DamagePercent >= 5f))
					{
						goto IL_02b1;
					}
					result = HandleWithdrawal(WithdrawReason.HighDamage, "Damage now at more than 5%");
				}
				else
				{
					num = (short?)damageThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (short?)damageThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (short?)damageThreshold;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true || !(myUnit.Damage.DamagePercent >= 75f))
							{
								goto IL_02b1;
							}
							result = HandleWithdrawal(WithdrawReason.HighDamage, "Damage now at more than 75%");
						}
						else
						{
							if (!(myUnit.Damage.DamagePercent >= 50f))
							{
								goto IL_02b1;
							}
							result = HandleWithdrawal(WithdrawReason.HighDamage, "Damage now at more than 50%");
						}
					}
					else
					{
						if (!(myUnit.Damage.DamagePercent >= 25f))
						{
							goto IL_02b1;
						}
						result = HandleWithdrawal(WithdrawReason.HighDamage, "Damage now at more than 25%");
					}
				}
				goto end_IL_0055;
				IL_0540:
				Doctrine._WeaponQuantityThreshold? weaponQuantityThreshold = myUnit.Doctrine.get_WithdrawAttackThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				num = (short?)weaponQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					goto IL_08ff;
				}
				num = (short?)weaponQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
				{
					Weapon primaryAttackWeapon_Default = myUnit.Weaponry.PrimaryAttackWeapon_Default;
					if (Information.IsNothing((object)primaryAttackWeapon_Default) || myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default.DBID, IncludeNonOperationalMountsAndMags: false) != 0)
					{
						goto IL_08ff;
					}
					result = HandleWithdrawal(WithdrawReason.LowAttackAmmo, "Primary attack weapon (" + primaryAttackWeapon_Default.Name + ") now exhausted");
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (short?)weaponQuantityThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (short?)weaponQuantityThreshold;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true)
							{
								goto IL_08ff;
							}
							Weapon primaryAttackWeapon_Default2 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
							if (Information.IsNothing((object)primaryAttackWeapon_Default2))
							{
								goto IL_08ff;
							}
							int num2 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default2.DBID, IncludeNonOperationalMountsAndMags: false);
							int num3 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default2.DBID);
							if (num2 != 0 && !((double)num2 / (double)num3 < 0.75))
							{
								goto IL_08ff;
							}
							result = HandleWithdrawal(WithdrawReason.LowAttackAmmo, "Primary attack weapon (" + primaryAttackWeapon_Default2.Name + ") now at less than 75%");
						}
						else
						{
							Weapon primaryAttackWeapon_Default3 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
							if (Information.IsNothing((object)primaryAttackWeapon_Default3))
							{
								goto IL_08ff;
							}
							int num4 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default3.DBID, IncludeNonOperationalMountsAndMags: false);
							int num5 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default3.DBID);
							if (num4 != 0 && !((double)num4 / (double)num5 < 0.5))
							{
								goto IL_08ff;
							}
							result = HandleWithdrawal(WithdrawReason.LowAttackAmmo, "Primary attack weapon (" + primaryAttackWeapon_Default3.Name + ") now at less than 50%");
						}
					}
					else
					{
						Weapon primaryAttackWeapon_Default4 = myUnit.Weaponry.PrimaryAttackWeapon_Default;
						if (Information.IsNothing((object)primaryAttackWeapon_Default4))
						{
							goto IL_08ff;
						}
						int num6 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryAttackWeapon_Default4.DBID, IncludeNonOperationalMountsAndMags: false);
						int num7 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryAttackWeapon_Default4.DBID);
						if (num6 != 0 && !((double)num6 / (double)num7 < 0.25))
						{
							goto IL_08ff;
						}
						result = HandleWithdrawal(WithdrawReason.LowAttackAmmo, "Primary attack weapon (" + primaryAttackWeapon_Default4.Name + ") now at less than 25%");
					}
				}
				goto end_IL_0055;
				IL_08ff:
				Doctrine._WeaponQuantityThreshold? weaponQuantityThreshold2 = myUnit.Doctrine.get_WithdrawDefenceThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				num = (short?)weaponQuantityThreshold2;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					goto IL_0cc4;
				}
				num = (short?)weaponQuantityThreshold2;
				int num8;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (short?)weaponQuantityThreshold2;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
					{
						Weapon primaryDefenceWeapon_Actual = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
						if (Information.IsNothing((object)primaryDefenceWeapon_Actual))
						{
							num8 = 0;
							goto IL_0cc5;
						}
						int num9 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual.DBID, IncludeNonOperationalMountsAndMags: false);
						int num10 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual.DBID);
						if (num9 != 0 && !((double)num9 / (double)num10 < 0.25))
						{
							goto IL_0cc4;
						}
						result = HandleWithdrawal(WithdrawReason.LowDefenceAmmo, "Primary defence weapon (" + primaryDefenceWeapon_Actual.Name + ") now at less than 25%");
					}
					else
					{
						num = (short?)weaponQuantityThreshold2;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) == true)
						{
							Weapon primaryDefenceWeapon_Actual2 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
							if (Information.IsNothing((object)primaryDefenceWeapon_Actual2))
							{
								goto IL_0cc4;
							}
							int num11 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual2.DBID, IncludeNonOperationalMountsAndMags: false);
							int num12 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual2.DBID);
							if (num11 != 0 && !((double)num11 / (double)num12 < 0.5))
							{
								goto IL_0cc4;
							}
							result = HandleWithdrawal(WithdrawReason.LowDefenceAmmo, "Primary defence weapon (" + primaryDefenceWeapon_Actual2.Name + ") now at less than 50%");
						}
						else
						{
							num = (short?)weaponQuantityThreshold2;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true)
							{
								goto IL_0cc4;
							}
							Weapon primaryDefenceWeapon_Actual3 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
							if (Information.IsNothing((object)primaryDefenceWeapon_Actual3))
							{
								num8 = 0;
								goto IL_0cc5;
							}
							int num13 = myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual3.DBID, IncludeNonOperationalMountsAndMags: false);
							int num14 = myUnit.Weaponry.TotalDefaultCapacityForThisWeapon(primaryDefenceWeapon_Actual3.DBID);
							if (num13 != 0 && !((double)num13 / (double)num14 < 0.75))
							{
								goto IL_0cc4;
							}
							result = HandleWithdrawal(WithdrawReason.LowDefenceAmmo, "Primary defence weapon (" + primaryDefenceWeapon_Actual3.Name + ") now at less than 75%");
						}
					}
				}
				else
				{
					Weapon primaryDefenceWeapon_Actual4 = myUnit.Weaponry.PrimaryDefenceWeapon_Actual;
					if (Information.IsNothing((object)primaryDefenceWeapon_Actual4))
					{
						goto IL_0cc4;
					}
					if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(primaryDefenceWeapon_Actual4.DBID, IncludeNonOperationalMountsAndMags: false) != 0)
					{
						num8 = 0;
						goto IL_0cc5;
					}
					result = HandleWithdrawal(WithdrawReason.LowDefenceAmmo, "Primary defence weapon (" + primaryDefenceWeapon_Actual4.Name + ") now exhausted");
				}
				goto end_IL_0055;
				IL_0cc5:
				result = (byte)num8 != 0;
				goto end_IL_0055;
				IL_02b1:
				Doctrine._FuelQuantityThreshold? fuelQuantityThreshold = myUnit.Doctrine.get_WithdrawFuelThreshold(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				num = (short?)fuelQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					goto IL_0540;
				}
				num = (short?)fuelQuantityThreshold;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
				{
					ActiveUnit._ActiveUnitFuelState isBingoOrJoker = myUnit.IsBingoOrJoker;
					if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						goto IL_0540;
					}
					myUnit.FuelState = isBingoOrJoker;
					result = HandleWithdrawal(WithdrawReason.LowFuel, "Fuel level now at bingo");
				}
				else
				{
					num = (short?)fuelQuantityThreshold;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (short?)fuelQuantityThreshold;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) == true)
						{
							double TotalCurrent = default(double);
							double TotalMax = default(double);
							if ((int)Math.Round(myUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0) >= 50)
							{
								goto IL_0540;
							}
							result = HandleWithdrawal(WithdrawReason.LowFuel, "Fuel level now at less than 50%");
						}
						else
						{
							num = (short?)fuelQuantityThreshold;
							double TotalCurrent2 = default(double);
							double TotalMax2 = default(double);
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true || (int)Math.Round(myUnit.FuelPercent(ref TotalCurrent2, ref TotalMax2, MissionFuel: false) * 100.0) >= 75)
							{
								goto IL_0540;
							}
							result = HandleWithdrawal(WithdrawReason.LowFuel, "Fuel level now at less than 75%");
						}
					}
					else
					{
						double TotalCurrent3 = default(double);
						double TotalMax3 = default(double);
						if ((int)Math.Round(myUnit.FuelPercent(ref TotalCurrent3, ref TotalMax3, MissionFuel: false) * 100.0) >= 25)
						{
							goto IL_0540;
						}
						result = HandleWithdrawal(WithdrawReason.LowFuel, "Fuel level now at less than 25%");
					}
				}
				goto end_IL_0055;
				IL_0cc4:
				num8 = 0;
				goto IL_0cc5;
				end_IL_0055:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101359", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num15;
				if (!Debugger.IsAttached)
				{
					num15 = 0;
				}
				else
				{
					Debugger.Break();
					num15 = 0;
				}
				result = (byte)num15 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	internal bool HasToTMissionAndFiringProposalActive(Contact theTarget)
	{
		Mission mission = myUnit.AssignedMissionOrPackage();
		if (mission == null)
		{
			return false;
		}
		if (!mission.TimeOnTarget.HasValue)
		{
			return false;
		}
		if (myUnit.get_UnitSide(SetSideOnly: false).FiringProposals == null)
		{
			return false;
		}
		List<FiringProposal> list = new List<FiringProposal>(myUnit.get_UnitSide(SetSideOnly: false).FiringProposals.Values);
		foreach (FiringProposal item in list)
		{
			if ((ActiveUnit)item.FiringUnit == myUnit && item.Target == theTarget)
			{
				return true;
			}
		}
		return false;
	}

	internal bool HasActiveFireProposalForTarget(Contact theTarget)
	{
		if (myUnit.get_UnitSide(SetSideOnly: false).FiringProposals != null)
		{
			List<FiringProposal> list = new List<FiringProposal>(myUnit.get_UnitSide(SetSideOnly: false).FiringProposals.Values);
			foreach (FiringProposal item in list)
			{
				if ((ActiveUnit)item.FiringUnit == myUnit && item.Target == theTarget)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	internal bool MyAssignedMissionContainsTarget(Contact theTarget)
	{
		int result2;
		if (myUnit.ActiveMissionOrPackage() != null)
		{
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
				if (strike == null)
				{
					return false;
				}
				if (strike.SpecificTargets != null)
				{
					foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
					{
						Contact contactForThisUnit = GetContactForThisUnit(specificTarget);
						if (contactForThisUnit == null)
						{
							continue;
						}
						int result;
						if (contactForThisUnit != theTarget)
						{
							if (contactForThisUnit.ActualUnit != theTarget.ActualUnit)
							{
								continue;
							}
							result = 1;
						}
						else
						{
							result = 1;
						}
						return (byte)result != 0;
					}
				}
			}
			else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				byte? b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
				{
					if (patrol.ProsecutionArea != null && patrol.ProsecutionArea.Count > 0)
					{
						if (((Module_Unit.Unit)theTarget).get_IsInsideThisArea(patrol.ProsecutionArea, myUnit.ParentScen, UseCache: true))
						{
							return true;
						}
						result2 = 0;
					}
					else
					{
						if (patrol.PatrolArea == null)
						{
							goto IL_01c1;
						}
						if (patrol.PatrolArea.Count <= 0)
						{
							result2 = 0;
						}
						else
						{
							if (((Module_Unit.Unit)theTarget).get_IsInsideThisArea(patrol.ProsecutionArea, myUnit.ParentScen, UseCache: true))
							{
								return true;
							}
							result2 = 0;
						}
					}
					goto IL_01c2;
				}
				return true;
			}
			goto IL_01c1;
		}
		return false;
		IL_01c1:
		result2 = 0;
		goto IL_01c2;
		IL_01c2:
		return (byte)result2 != 0;
	}

	internal float ConvertDepthPresetToValue(bool CheckThreats, SubmarineDepthPreset DepthPreset)
	{
		if (myUnit != null)
		{
			Submarine_AI aI = ((Submarine)myUnit).AI;
			float num = default(float);
			switch (DepthPreset)
			{
			case SubmarineDepthPreset.None:
				return 0f;
			case SubmarineDepthPreset.Periscope:
				num = -20f;
				break;
			case SubmarineDepthPreset.Shallow:
				num = -40f;
				break;
			case SubmarineDepthPreset.OverLayer:
				num = Submarine_AI.OverLayerDepth(myUnit);
				break;
			case SubmarineDepthPreset.UnderLayer:
				num = Submarine_AI.UnderLayerDepth(myUnit);
				break;
			case SubmarineDepthPreset.MaxDepth:
				num = myUnit.Kinematics.GetMinimumAltitude();
				break;
			case SubmarineDepthPreset.Surface:
				num = 0f;
				break;
			}
			if (!CheckThreats)
			{
				return num;
			}
			if (Math.Round(num) >= -20.0 && !aI.CanComeToPeriscopeDepth_CheckThreats(myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive, null, -1.0, -1.0))
			{
				num = -40f;
			}
			return 0f;
		}
		return 0f;
	}

	public virtual void FollowDepthPreset(bool CheckThreats)
	{
		try
		{
			if (myUnit == null || !myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			Submarine_AI aI = ((Submarine)myUnit).AI;
			float num = default(float);
			switch (aI.DepthPreset)
			{
			case SubmarineDepthPreset.None:
				return;
			case SubmarineDepthPreset.Periscope:
				num = -20f;
				break;
			case SubmarineDepthPreset.Shallow:
				num = -40f;
				break;
			case SubmarineDepthPreset.OverLayer:
				num = Submarine_AI.OverLayerDepth(myUnit);
				break;
			case SubmarineDepthPreset.UnderLayer:
				num = Submarine_AI.UnderLayerDepth(myUnit);
				break;
			case SubmarineDepthPreset.MaxDepth:
				num = myUnit.Kinematics.GetMinimumAltitude();
				break;
			case SubmarineDepthPreset.Surface:
				num = 0f;
				break;
			}
			if (CheckThreats)
			{
				if (Math.Round(num) >= -20.0 && !aI.CanComeToPeriscopeDepth_CheckThreats(myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive, null, -1.0, -1.0))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = num;
				}
			}
			else
			{
				myUnit.DesiredAltitude = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101360", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, NotifyDictionaryChangedEventArgs<string, TargetingEntry> e)
	{
		contact_0 = null;
	}

	public static void ExportTargetingChangeEvent(string EventDescription, Contact theContact, ActiveUnit ObserverUnit, Side theSide, Scenario theScen, string MiscInfo)
	{
		try
		{
			if (theScen == null)
			{
				return;
			}
			IEventExporter[] array = theScen?.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in array)
			{
				if (eventExporter.IsOperating && eventExporter.ExportEngagementCycle)
				{
					PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
					if (theScen.MonteCarloIteration > 0)
					{
						pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
						pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
					}
					pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
					if (!eventExporter.UseZeroHour)
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					else
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					if (ObserverUnit == null)
					{
						pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 40));
						pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
						pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(ObserverUnit.ObjectID, typeof(string), 40));
						pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(ObserverUnit.Name, typeof(string), 500));
						pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(ObserverUnit.UnitClass, typeof(string), 500));
					}
					if (theSide != null)
					{
						pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(theSide.Name, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					pooledDictionary.Add("CycleAction", new IEventExporter.EventNotificationParameter(EventDescription, typeof(string), 200));
					pooledDictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(theContact.ObjectID, typeof(string), 40));
					pooledDictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(theContact.Name, typeof(string), 500));
					pooledDictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null).ToString(), typeof(double)));
					pooledDictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null).ToString(), typeof(double)));
					if (ObserverUnit == null)
					{
						pooledDictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
						pooledDictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
					}
					else
					{
						pooledDictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(ObserverUnit.RangeToUnit_Horiz(theContact), typeof(float)));
						pooledDictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(ObserverUnit, theContact), typeof(float)));
					}
					if (theContact.ActualUnit != null)
					{
						pooledDictionary.Add("ContactActualUnitID", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.ObjectID, typeof(string), 40));
						pooledDictionary.Add("ContactActualUnitName", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.Name, typeof(string), 500));
						pooledDictionary.Add("ContactActualUnitClass", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.UnitClass, typeof(string), 500));
						pooledDictionary.Add("ContactActualUnitSide", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					}
					pooledDictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(MiscInfo, typeof(string)));
					eventExporter.ExportEvent(IEventExporter.ExportedEventType.EngagementCycle, pooledDictionary, theScen);
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

	internal float MostRealisticFormUpAltitude(ref double theLatitude, ref double theLongitude)
	{
		float result;
		try
		{
			Aircraft aircraft = (Aircraft)myUnit;
			float num = Terrain.GetElevation(theLatitude, theLongitude, RequestIsFromGUI: false, myUnit.ParentScen);
			num = ((!(num > 0f)) ? 0f : ((float)(Math.Round(num * 3.28084f / 1000f, 0) * 1000.0 / 3.2808399200439453)));
			result = ((Information.IsNothing((object)aircraft.Loadout) || Information.IsNothing((object)aircraft.Loadout.get_MissionProfile(aircraft.ParentScen).FormUpAltitude) || !(aircraft.Loadout.get_MissionProfile(aircraft.ParentScen).FormUpAltitude > 0f)) ? (609.6f + num) : (aircraft.Loadout.get_MissionProfile(aircraft.ParentScen).FormUpAltitude + num));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101361", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 609.6f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void ReturnToBase(float elapsedTime)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			myUnit.IsExhausted();
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().SecondaryNavalBase != null)
			{
				myUnit.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, myUnit.ActiveMissionOrPackage().SecondaryNavalBase);
			}
			ActiveUnit activeUnit = myUnit.DockingOps.ActualDestinationHost;
			if (activeUnit != null && activeUnit.IsGroup && myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
			{
				activeUnit = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			}
			if (!Information.IsNothing((object)activeUnit) && !activeUnit.IsMorituri)
			{
				ActiveUnit_DockingOps dockingOps = activeUnit.DockingOps;
				ActiveUnit theBoat = myUnit;
				DockFacility bestFacility = null;
				if (dockingOps.CanHostThisBoat(theBoat, ref bestFacility))
				{
					goto IL_00e2;
				}
			}
			myUnit.DockingOps.PickNewAssignedHost_RandomWithinRange();
			activeUnit = myUnit.DockingOps.ActualDestinationHost;
			goto IL_00e2;
			IL_00e2:
			if (Information.IsNothing((object)activeUnit))
			{
				if (myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
				return;
			}
			float num = myUnit.RangeToUnit_Horiz(activeUnit);
			if (myUnit.CurrentSpeed == 0f && num < 1f && myUnit.FuelCapacityCurrent == 0)
			{
				myUnit.DockingOps.AttemptToStartDocking(activeUnit);
				return;
			}
			if (num * 1852f < 100f)
			{
				myUnit.DockingOps.AttemptToStartDocking(activeUnit);
				return;
			}
			if (!myUnit.Navigator.HasPathfindingPlottedCourse)
			{
				myUnit.Navigator.ClearPlottedCourse();
				if (myUnit.IsShip)
				{
					myUnit.Navigator.bool_0 = true;
				}
				myUnit.Navigator.AddWaypoint(new Waypoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			else
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100819", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool ManouverForSpace(DateTime? ArrivalTime, ref Waypoint TargetWaypoint, bool LoiterAtWaypoint)
	{
		return false;
	}

	public virtual bool ManouverRaceTrack(ref Scenario theScen, ref Waypoint HoldEndWaypoint)
	{
		return false;
	}

	public bool PerformTerrainFollowingIfNecessary()
	{
		if (myUnit.IsWeapon && ((Weapon)myUnit).IsASCMwithoutTFcapability())
		{
			return false;
		}
		if (myUnit.CurrentAltitude_AGL < 1000f && (myUnit.DesiredAltitude_AGL != 0f || myUnit.DesiredAltitude < 3000f))
		{
			float num = ((IFlier)myUnit).get_MinimumSafeHeight(bool_0: true).Value;
			bool flag = false;
			list_3.Clear();
			if (myUnit.DesiredAltitude_AGL != 0f)
			{
				flag = true;
				if (myUnit.DesiredAltitude_AGL > num)
				{
					num = myUnit.DesiredAltitude_AGL;
				}
			}
			double lat = myUnit.get_Latitude(GlobalVariables.ObjectTrue);
			double lon = myUnit.get_Longitude(GlobalVariables.ObjectTrue);
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, 2f, myUnit.CurrentHeading);
			List<Geopoint_Struct> intervalPointsBetweenTwoCoords_ShortRange = MathFunctions.GetIntervalPointsBetweenTwoCoords_ShortRange(lat, lon, geopoint_Struct.Latitude, geopoint_Struct.Longitude, 8);
			float num2 = 0f;
			(double, double, float, float) item = default((double, double, float, float));
			foreach (Geopoint_Struct item2 in intervalPointsBetweenTwoCoords_ShortRange)
			{
				num2 += 0.2f;
				short elevation = Terrain.GetElevation(item2.Latitude, item2.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
				item.Item1 = item2.Latitude;
				item.Item2 = item2.Longitude;
				item.Item3 = num2;
				item.Item4 = (float)elevation + num;
				if (flag || (float)elevation > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					list_3.Add(item);
				}
			}
			if (list_3.Count > 0)
			{
				(double, double, float, float) tuple = list_3.OrderByDescending<(double, double, float, float), double>([SpecialName] ((double theLat, double theLon, float theDistance, float theElev) theVT) => Math.Atan2(theVT.theElev - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (double)theVT.theDistance * 1852.0) * 57.2957795130823).ElementAtOrDefault(0);
				if (tuple.Item4 > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					Calculate_And_Set_DesiredPitch(tuple.Item1, tuple.Item2, tuple.Item4);
				}
				else if (flag)
				{
					if (myUnit.CurrentAltitude_AGL >= myUnit.DesiredAltitude_AGL && (double)tuple.Item4 + 0.1 * (double)num < (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
					{
						Calculate_And_Set_DesiredPitch(tuple.Item1, tuple.Item2, tuple.Item4);
					}
					else if (myUnit.CurrentAltitude_AGL < myUnit.DesiredAltitude_AGL)
					{
						myUnit.DesiredPitch = Math.Min(30f, (float)(Math.Atan2(myUnit.DesiredAltitude_AGL - myUnit.CurrentAltitude_AGL, 185.20000000000002) * 57.2957795130823));
					}
					else
					{
						myUnit.DesiredPitch = 0f;
					}
				}
				else
				{
					Calculate_And_Set_DesiredPitch(tuple.Item1, tuple.Item2, myUnit.DesiredAltitude);
				}
				CalculatedDesiredPitchThisPulse = true;
				return true;
			}
			return false;
		}
		return false;
	}

	public void Calculate_And_Set_DesiredPitch(double TargetLat, double TargetLon, double targetAlt)
	{
		double double_ = 0.0;
		method_11(TargetLat, TargetLon, targetAlt, ref double_);
		myUnit.DesiredPitch = (float)double_;
	}

	private void method_11(double double_0, double double_1, double double_2, ref double double_3)
	{
		if (!myUnit.SupportsAttitude_Pitch)
		{
			return;
		}
		if (myUnit.IsPalletWeapon)
		{
			double_3 = -85.0;
			return;
		}
		double_3 = Math.Atan2((double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - double_2, (double)Module_Unit.RangeToPoint_Horiz(myUnit, double_0, double_1) * 1852.0) * 57.2957795130823;
		if (double_3 > 0.0 && (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > double_2)
		{
			double_3 = 0.0 - double_3;
		}
		if (double_3 < 0.0 && (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < double_2)
		{
			double_3 = 0.0 - double_3;
		}
	}

	public virtual void RefreshVisibleContactsList()
	{
		theContactsVisibleToMe = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
		PooledList<Contact> pooledList = theContactsVisibleToMe;
		if (pooledList == null || pooledList.Count <= 0)
		{
			theContactsVisibleToMe = new PooledList<Contact>();
			return;
		}
		int count = theContactsVisibleToMe.Count;
		if (ContactStanceCache == null)
		{
			ContactStanceCache = new PooledList<(Contact, Misc.PostureStance)>();
		}
		int num = count - ContactStanceCache.Count;
		if (num > 0)
		{
			int num2 = num;
			for (int i = 1; i <= num2; i++)
			{
				ContactStanceCache.Add(default((Contact, Misc.PostureStance)));
			}
		}
	}

	public Misc.PostureStance GetContactsStance_Cache(Contact theContact, int theIndex)
	{
		Misc.PostureStance value = Misc.PostureStance.Unknown;
		Misc.PostureStance result;
		try
		{
			if (ContactStanceCache == null)
			{
				ContactStanceCache = new PooledList<(Contact, Misc.PostureStance)>();
			}
			if (theIndex >= ContactStanceCache.Count)
			{
				ContactStanceCache.Capacity = theIndex + 1;
				while (ContactStanceCache.Count <= theIndex)
				{
					ContactStanceCache.Add(default((Contact, Misc.PostureStance)));
				}
			}
			(Contact, Misc.PostureStance) tuple = ContactStanceCache[theIndex];
			if (tuple.Item1 != null && tuple.Item1 == theContact)
			{
				value = tuple.Item2;
			}
			else
			{
				if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(theContact.ObjectID, out value))
				{
					value = theContact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(theContact.ObjectID, value);
				}
				ContactStanceCache[theIndex] = (theContact, value);
			}
			result = value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 4;
			}
			else
			{
				num = 4;
			}
			result = (Misc.PostureStance)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void PrePulseHousekeeping(float elapsedTime, Scenario theScen)
	{
		CalculatedNearestTargetsThisPulse = false;
		if (ContactStanceCache != null)
		{
			ContactStanceCache.Clear();
		}
		else
		{
			ContactStanceCache = new PooledList<(Contact, Misc.PostureStance)>();
		}
	}

	public virtual void ManoueverTorpedoEvasion(float elapsedTime, Contact TorpedoThreat)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	protected virtual void ExecuteManeuver(PersistentManeuver theManeuver)
	{
		if (theManeuver == null)
		{
			return;
		}
		myUnit.SetThrottle(theManeuver.DesiredThrottle);
		PersistentManeuver.TurnDirection turnDirection;
		float desiredHeading;
		if (myUnit.CurrentHeading != theManeuver.DesiredHeading)
		{
			myUnit.Kinematics.TurnRate();
			desiredHeading = theManeuver.DesiredHeading;
			turnDirection = theManeuver.Direction;
			if (turnDirection == PersistentManeuver.TurnDirection.Nearest)
			{
				turnDirection = PersistentManeuver.TurnDirection.Right;
				float num = theManeuver.DesiredHeading - myUnit.CurrentHeading;
				int num2;
				if (!(num > 180f))
				{
					if (!(num < 0f) || !(num > -180f))
					{
						goto IL_008e;
					}
					num2 = 1;
				}
				else
				{
					num2 = 1;
				}
				turnDirection = (PersistentManeuver.TurnDirection)num2;
			}
			goto IL_008e;
		}
		goto IL_010c;
		IL_010c:
		if (myUnit.IsSubmarine || myUnit.IsAircraft)
		{
			myUnit.DesiredAltitude = theManeuver.DesiredAltitude;
		}
		return;
		IL_008e:
		float num3 = Misc.RelativeAngleBetweenBearings(myUnit.CurrentHeading, theManeuver.DesiredHeading, PreserveLeftRight: true);
		desiredHeading = ((turnDirection == PersistentManeuver.TurnDirection.Left) ? ((!(num3 < 0f)) ? Math2.NormalizeBearing(myUnit.CurrentHeading - 179f) : theManeuver.DesiredHeading) : ((!(num3 > 0f)) ? Math2.NormalizeBearing(myUnit.CurrentHeading + 179f) : theManeuver.DesiredHeading));
		myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, desiredHeading);
		goto IL_010c;
	}
}
