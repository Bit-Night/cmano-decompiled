using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using DarkUI.Forms;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;
using ThreadSafeCollections;

namespace Command_Core;

public abstract class Mission : ScenarioObject
{
	public class TriggerOperationWrapper
	{
		public bool Value;

		public bool ConditionalOperator;

		public TriggerOperationWrapper(bool _Value, bool _ConditionalOperator)
		{
			Value = _Value;
			ConditionalOperator = _ConditionalOperator;
		}

		static TriggerOperationWrapper()
		{
			Class72.smethod_20();
		}
	}

	public enum TankerMethod : byte
	{
		Automatic,
		Mission
	}

	public enum MissionCategory
	{
		Mission,
		Package,
		TaskPool
	}

	public delegate void StartTimeChangedEventHandler(Mission theM);

	public delegate void EndTimeChangedEventHandler(Mission theM);

	public delegate void TakeOffTimeChangedEventHandler(Mission theM);

	public delegate void TimeOnTargetChangedEventHandler(Mission theM);

	public enum MissionMovementStyle
	{
		RandomWithinArea,
		RepeatableLoop
	}

	public enum OneThirdGroupingType
	{
		ByLoadout,
		ByUnitClass,
		NoGrouping
	}

	public enum _FlightQty
	{
		NoPreferences = 0,
		All = -99,
		None = -100,
		Flight_x1 = -97,
		Flight_x2 = -96,
		Flight_x3 = -95,
		Flight_x4 = -94,
		Flight_x6 = -93,
		Flight_x8 = -92,
		Flight_x12 = -91,
		Aircraft_x1 = -87,
		Aircraft_x2 = -86,
		Aircraft_x3 = -85,
		Aircraft_x4 = -84,
		Aircraft_x6 = -83,
		Aircraft_x8 = -82,
		Aircraft_x12 = -81
	}

	public enum MissionAssignmentAttemptResult
	{
		None,
		Success,
		Fail_OutOfComms,
		Fail_Other
	}

	public enum _MissionClass : byte
	{
		None,
		Strike,
		Patrol,
		Support,
		Ferry,
		Mining,
		MineClearing,
		Escort,
		Cargo,
		ArtyFireMission
	}

	public enum MissionStatus : byte
	{
		Active,
		Inactive
	}

	public enum _BingoFuelSetting : byte
	{
		UseLoadoutSetting,
		ExpendJettison,
		BringBack
	}

	public struct _FlightSize
	{
		public int value;

		public const int None = 0;

		public const int SingleAircraft = 1;

		public const int TwoAircraft = 2;

		public const int ThreeAircraft = 3;

		public const int FourAircraft = 4;

		public const int SixAircraft = 6;

		public _FlightSize(int theNewValue)
		{
			this = default(_FlightSize);
			value = theNewValue;
		}

		public static implicit operator int(_FlightSize theFlightSize)
		{
			return theFlightSize.value;
		}

		public static implicit operator _FlightSize(int theNewValue)
		{
			_FlightSize flightSize = default(_FlightSize);
			flightSize = new _FlightSize(theNewValue);
			flightSize.value = theNewValue;
			return flightSize;
		}

		public static bool operator ==(_FlightSize S1, int S2)
		{
			if (S1.value == S2)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(_FlightSize S1, int S2)
		{
			if (S1.value != S2)
			{
				return true;
			}
			return false;
		}

		public static int operator -(_FlightSize S1, int S2)
		{
			return S1.value - S2;
		}

		public static bool operator <(_FlightSize S1, _FlightSize S2)
		{
			return S1.value < S2.value;
		}

		public static bool operator >(_FlightSize S1, _FlightSize S2)
		{
			return S1.value > S2.value;
		}

		public static bool operator <=(_FlightSize S1, _FlightSize S2)
		{
			return S1.value <= S2.value;
		}

		public static bool operator >=(_FlightSize S1, _FlightSize S2)
		{
			return S1.value >= S2.value;
		}

		static _FlightSize()
		{
			Class72.smethod_20();
		}
	}

	public struct _GroupSize
	{
		public int value;

		public const int None = 0;

		public const int SingleVessel = 1;

		public const int TwoVessels = 2;

		public const int ThreeVessels = 3;

		public const int FourVessels = 4;

		public const int SixVessels = 6;

		public _GroupSize(int theNewValue)
		{
			this = default(_GroupSize);
			value = theNewValue;
		}

		public static implicit operator int(_GroupSize theFlightSize)
		{
			return theFlightSize.value;
		}

		public static implicit operator _GroupSize(int theNewValue)
		{
			_GroupSize groupSize = default(_GroupSize);
			groupSize = new _GroupSize(theNewValue);
			groupSize.value = theNewValue;
			return groupSize;
		}

		public static bool operator ==(_GroupSize S1, int S2)
		{
			if (S1.value == S2)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(_GroupSize S1, int S2)
		{
			if (S1.value != S2)
			{
				return true;
			}
			return false;
		}

		public static int operator -(_GroupSize S1, int S2)
		{
			return S1.value - S2;
		}

		public static bool operator <(_GroupSize S1, _GroupSize S2)
		{
			return S1.value < S2.value;
		}

		public static bool operator >(_GroupSize S1, _GroupSize S2)
		{
			return S1.value > S2.value;
		}

		public static bool operator <=(_GroupSize S1, _GroupSize S2)
		{
			return S1.value <= S2.value;
		}

		public static bool operator >=(_GroupSize S1, _GroupSize S2)
		{
			return S1.value >= S2.value;
		}

		static _GroupSize()
		{
			Class72.smethod_20();
		}
	}

	public enum _AircraftFormationType
	{
		NoFormation = 1
	}

	public enum _RadarBehaviour
	{
		None,
		UseMissionEMCON,
		ActiveOnIP,
		ActiveOnAttackIngressAndIP
	}

	public enum _FlightTask
	{
		None = 0,
		Strike_Land = 1,
		Strike_Naval = 2,
		Strike_OCA = 3,
		Strike_SEAD = 4,
		Sweep_Fighter = 5,
		Sweep_SEAD = 6,
		BAI = 7,
		CAS = 8,
		CAP = 9,
		TARCAP = 10,
		BARCAP = 11,
		GLI = 12,
		DLI = 13,
		Escort_FighterSweep = 14,
		Escort_TARCAP = 15,
		Escort_SEAD = 16,
		ASAT = 17,
		AirborneLaser = 18,
		Buddy_Illumination = 19,
		OECM = 20,
		AEW = 21,
		CommandPost = 22,
		ChaffLaying = 23,
		SearchAndRescue = 24,
		CombatSearchAndRescue = 25,
		MineSweeping = 26,
		MineRecon = 27,
		NavalMineLaying = 28,
		ASW = 29,
		Forward_Observer = 30,
		Area_Surveillance = 31,
		Armed_Recon = 32,
		Unarmed_Recon = 33,
		Maritime_Surveillance = 34,
		Paratroopers = 35,
		Troop_Transport = 36,
		Cargo = 37,
		AirRefueling = 38,
		Training = 39,
		TargetTow = 40,
		TargetDrone = 41,
		Ferry = 42,
		HAVCAP = 44,
		RESCAP = 45,
		Strike_Interdiction = 46,
		Support = 47,
		Escort_Support = 48,
		QRA = 49
	}

	public enum _FlightType
	{
		Flightplan,
		FlightplanTemplate
	}

	public enum _AttackMethod
	{
		None = -1,
		Formation_SingleAim,
		Formation_IndependentAim,
		SplitAtActionPoint,
		EchelonAtActionPoint,
		MultiAxisSimultaneousToT,
		MultiAxisStackedToT_Echelon_20Sec,
		MultiAxisStackedToT_Echelon_30Sec,
		MultiAxisStackedToT_Echelon_40Sec,
		MultiAxisStackedToT_Split_20Sec,
		MultiAxisStackedToT_Split_30Sec,
		MultiAxisStackedToT_Split_40Sec,
		SingleAxisStackedToT_20Sec,
		SingleAxisStackedToT_30Sec,
		SingleAxisStackedToT_40Sec,
		BananaSplit
	}

	public enum _SplitDistance
	{
		Close_10nm,
		Typical_20nm,
		Long_50nm
	}

	public enum _ContinousCoverageMethod
	{
		Dynamic,
		FlightplanTemplates
	}

	public enum _ContinousCoverageStationTime
	{
		min_15,
		min_20,
		min_30,
		min_40,
		min_45,
		min_50,
		hr_1,
		hr_1_min_15,
		hr_1_min_30,
		hr_1_min_45,
		hr_2,
		hr_2_min_15,
		hr_2_min_30,
		hr_2_min_45,
		hr_3,
		hr_3_min_30,
		hr_4,
		hr_5,
		hr_6,
		hr_8,
		hr_10,
		hr_12
	}

	public enum _ContinousCoverageOverlap
	{
		None,
		Min_2,
		Min_5
	}

	public enum _ContinousCoverageDuration
	{
		hr_2,
		hr_4,
		hr_6,
		hr_12,
		hr_24
	}

	public enum _GroupQty
	{
		NoPreferences = 0,
		All = -99,
		None = -100,
		Group_x1 = -97,
		Group_x2 = -96,
		Group_x3 = -95,
		Group_x4 = -94,
		Group_x6 = -93,
		Group_x8 = -92,
		Group_x12 = -91,
		Boat_x1 = -87,
		Boat_x2 = -86,
		Boat_x3 = -85,
		Boat_x4 = -84,
		Boat_x6 = -83,
		Boat_x8 = -82,
		Boat_x12 = -81
	}

	public enum _FlightPriority
	{
		None,
		Mandatory
	}

	public enum _FlightStatus
	{
		None,
		LookingForAvailableAircraft,
		WaitingForPackageActivation,
		WaitingForAircraftToBecomeReady,
		TakingOff,
		Airborne,
		Completed,
		PackageEnded,
		Airborne_EgressLeg
	}

	public enum _FlightCreatedBy
	{
		None,
		MissionAI,
		Player
	}

	public enum _TankerFollowsReceiver
	{
		UntilFull = 0,
		Waypoint1 = 1,
		Waypoint2 = 2,
		Weaypoin3 = 3,
		UntilHoldWaypoint = -97,
		UntilStationWaypoint = -98,
		UntilLandingMarshalWaypoint = -99
	}

	public enum _TargeteeringMethod
	{
		Mission,
		Flight,
		Individual
	}

	public sealed class Flight : ScenarioObject
	{
		public enum FlightElement : byte
		{
			None = 0,
			LeadElement = 1,
			LeadElementWingman = 2,
			SecondElement = 3,
			SecondElementWingman = 4,
			ThirdElement = 5,
			ThirdElementWingman = 6,
			Other = 99
		}

		public string ParentMissionOrPackageObjectID;

		public string ParentMissionOrPackageName;

		public string Callsign;

		public _FlightTask Task;

		public _FlightType Type;

		public string TakeOffLocation_HostUnitObjectID;

		public string TakeOffLocation_HostUnitObjectName;

		public string LandingLocation_HostUnitObjectID;

		public string LandingLocation_HostUnitObjectName;

		public string AlternativeLandingLocation_HostUnitObjectID;

		public string AlternativeLandingLocation_HostUnitObjectName;

		public List<MDSP_Error> ErrorList;

		public List<string> NotificationList;

		private bool bool_0;

		internal TDictionary<Module_Unit.Unit, bool> Cache_ContactRelevantToFlight;

		internal HashSet<Module_Unit.Unit> Cache_FP_Targets;

		public DateTime? EarliestTaskingTime;

		public DateTime? LatestTaskingTime;

		public float MaxReadyTime;

		public DateTime? EarliestLaunchTime;

		public DateTime? LatestLaunchTime;

		public bool IsEscort;

		public _FlightPriority Priority;

		private _FlightStatus _FlightStatus_0;

		public _FlightCreatedBy CreatedBy;

		public _FlightCreatedBy EditedBy;

		public _FlightSize DesiredAircraftQty;

		public _FlightSize MinimumAircraftQty;

		public int ReadyAircraftQty;

		public int UsedByFlightCount;

		private ActiveUnit activeUnit_0;

		public int ReferenceUnit_DBID;

		public string ReferenceUnit_ObjectID;

		public string ReferenceUnit_Name;

		public int int_1;

		private string string_1;

		protected Waypoint[] _FlightPlan;

		protected Waypoint[] _FlightPlan_Pathfinder_Ingress_1;

		protected Waypoint[] _FlightPlan_Pathfinder_Ingress_2;

		protected Waypoint[] _FlightPlan_Pathfinder_Egress_1;

		protected Waypoint[] _FlightPlan_Pathfinder_Egress_2;

		public Mission TaskPool;

		public string TaskPool_ID;

		public string TaskPool_Name;

		public string TakeOffTimeZuluString;

		public string TakeOffTimeLocalString;

		public string ObjectiveTimeZuluString;

		public string ObjectiveTimeLocalString;

		public Waypoint.FixedFree TakeOffWaypointFixedTime;

		public Waypoint.FixedFree ObjectiveWaypointFixedTime;

		public int Age;

		public Contact PrimaryTarget;

		public string PrimaryTarget_ID;

		public bool Pathfinder_Ingress_RequestBeingProcessed;

		public bool Pathfinder_Egress_RequestBeingProcessed;

		public bool PathfinderRequestBeingProcessed_OnThisPulse;

		public bool PathfinderRequestCompleteAndAwaitingUse;

		public bool FlightCannotLaunch;

		public string FlightCannotLaunch_Feedback;

		public bool Departed;

		public bool Landed;

		public List<SecondaryFlightPlan> SecondaryFlightPlans;

		public bool HasCriticalError
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

		public PooledList<ActiveUnit> AUCurrentlyAssigned
		{
			get
			{
				PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
				List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(SelectedMission, CurrentScenario);
				if (list != null && list.Count > 0)
				{
					foreach (ActiveUnit item in list)
					{
						if (string.CompareOrdinal(item.Navigator?.get_Flight(HierarchySearch: true)?.Callsign, Callsign) == 0)
						{
							pooledList.Add(item);
						}
					}
				}
				return pooledList;
			}
		}

		public _FlightStatus Status
		{
			get
			{
				return _FlightStatus_0;
			}
			set
			{
				bool num = value != _FlightStatus_0;
				_FlightStatus_0 = value;
				if (!num)
				{
					return;
				}
				List<MDSP_Error> list = new List<MDSP_Error>();
				MDSP_Error[] array = theScen.MissionPlannerErrorList.ToArray();
				foreach (MDSP_Error mDSP_Error in array)
				{
					if (mDSP_Error != null && Operators.CompareString(mDSP_Error.Flight, Callsign, false) == 0)
					{
						list.Add(mDSP_Error);
					}
				}
				foreach (MDSP_Error item in list)
				{
					theScen.MissionPlannerErrorList.Remove(item);
				}
			}
		}

		public bool IsActive
		{
			get
			{
				_FlightStatus flightStatus_ = _FlightStatus_0;
				if ((uint)(flightStatus_ - 4) <= 4u)
				{
					if (ilist_0 == null)
					{
						return true;
					}
					foreach (ActiveUnit item in ilist_0)
					{
						if (item.IsAircraft)
						{
							Aircraft aircraft = (Aircraft)item;
							if (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked)
							{
								return true;
							}
						}
					}
					_FlightStatus_0 = _FlightStatus.None;
					return false;
				}
				return false;
			}
		}

		public string LoadoutName
		{
			get
			{
				if (string.IsNullOrEmpty(string_1))
				{
					try
					{
						if (int_1 == 0)
						{
							return "Not set";
						}
						if (!Information.IsNothing((object)this.get_ReferenceUnit(theScen)) && !Information.IsNothing((object)((Aircraft)this.get_ReferenceUnit(theScen)).Loadout))
						{
							string_1 = ((Aircraft)this.get_ReferenceUnit(theScen)).Loadout.Name;
						}
						else
						{
							Loadout loadout = DBFunctions.GetLoadout(ref theScen, int_1, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
							if (!Information.IsNothing((object)loadout))
							{
								string_1 = loadout.Name;
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2.Data.Add("Error at 999999", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		public Waypoint[] FlightPlan
		{
			get
			{
				return _FlightPlan;
			}
			set
			{
				_FlightPlan = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Ingress_1
		{
			get
			{
				return _FlightPlan_Pathfinder_Ingress_1;
			}
			set
			{
				_FlightPlan_Pathfinder_Ingress_1 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Ingress_2
		{
			get
			{
				return _FlightPlan_Pathfinder_Ingress_2;
			}
			set
			{
				_FlightPlan_Pathfinder_Ingress_2 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Egress_1
		{
			get
			{
				return _FlightPlan_Pathfinder_Egress_1;
			}
			set
			{
				_FlightPlan_Pathfinder_Egress_1 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Egress_2
		{
			get
			{
				return _FlightPlan_Pathfinder_Egress_2;
			}
			set
			{
				_FlightPlan_Pathfinder_Egress_2 = value;
			}
		}

		public ActiveUnit ReferenceUnit
		{
			get
			{
				ActiveUnit result;
				try
				{
					if (activeUnit_0 == null && theScen != null)
					{
						if (!string.IsNullOrEmpty(ReferenceUnit_ObjectID) && theScen.ActiveUnits.ContainsKey(ReferenceUnit_ObjectID))
						{
							activeUnit_0 = theScen.ActiveUnits[ReferenceUnit_ObjectID];
						}
						Misc.GetClone(theScen.ActiveUnits.Values.ToList());
						if (activeUnit_0 == null)
						{
							foreach (ActiveUnit item in theScen.ActiveUnits.Values.ToList())
							{
								if (item != null && item.Navigator.HasFlightPlan && item.Navigator.get_Flight(HierarchySearch: true) == this)
								{
									this.set_ReferenceUnit(theScen, item);
									break;
								}
							}
						}
						if (activeUnit_0 == null && ReferenceUnit_DBID > 0)
						{
							bool flag = false;
							Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
							for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
							{
								Side theSide = sides_ReadOnly[i];
								foreach (Mission mission in theSide.Missions)
								{
									if (mission.HasFlights())
									{
										foreach (Flight flight in mission.FlightList)
										{
											Flight theFlight = flight;
											if (theFlight == this && theScen.ActiveUnits.TryGetValue(TakeOffLocation_HostUnitObjectID, out var value))
											{
												activeUnit_0 = mission.CreateEmptySlotReferenceUnit(ref theScen, ref theSide, ReferenceUnit_DBID, int_1, ref value, ref theFlight, theUnitIsEscort: false, 1);
												flag = true;
												break;
											}
										}
									}
									if (flag)
									{
										break;
									}
								}
								if (flag)
								{
									break;
								}
							}
						}
					}
					result = activeUnit_0;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2.Data.Add("Error at 101385", "");
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
			set
			{
				activeUnit_0 = value;
				if (value == null)
				{
					ReferenceUnit_ObjectID = "";
					return;
				}
				ReferenceUnit_DBID = activeUnit_0.DBID;
				ReferenceUnit_ObjectID = activeUnit_0.ObjectID;
				ReferenceUnit_Name = activeUnit_0.UnitClass;
			}
		}

		public static string FlightElementString => theElement switch
		{
			FlightElement.Other => "Other Element Wingman", 
			FlightElement.LeadElement => "Lead Element", 
			FlightElement.LeadElementWingman => "Lead Element Wingman", 
			FlightElement.SecondElement => "Second Element", 
			FlightElement.SecondElementWingman => "Second Element Wingman", 
			FlightElement.ThirdElement => "Third Element", 
			FlightElement.ThirdElementWingman => "Third Element Wingman", 
			_ => "None", 
		};

		public static string FlightTypeString => theFlightType switch
		{
			_FlightType.FlightplanTemplate => "Flightplan Template", 
			_FlightType.Flightplan => "FLightplan", 
			_ => "Not Configured", 
		};

		public SecondaryFlightPlan RetrieveSecondaryFP(int DBID, int LoadOutID)
		{
			foreach (SecondaryFlightPlan secondaryFlightPlan in SecondaryFlightPlans)
			{
				if ((LoadOutID == secondaryFlightPlan.Loadout_DBID) & (DBID == secondaryFlightPlan.DBID))
				{
					return secondaryFlightPlan;
				}
			}
			return null;
		}

		public Flight()
		{
			bool_0 = false;
			Cache_ContactRelevantToFlight = new TDictionary<Module_Unit.Unit, bool>();
			UsedByFlightCount = 0;
			_FlightPlan = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_2 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_2 = new Waypoint[0];
			TakeOffTimeZuluString = "-";
			TakeOffTimeLocalString = "-";
			ObjectiveTimeZuluString = "-";
			ObjectiveTimeLocalString = "-";
			TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
			ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
			Pathfinder_Ingress_RequestBeingProcessed = false;
			Pathfinder_Egress_RequestBeingProcessed = false;
			PathfinderRequestBeingProcessed_OnThisPulse = false;
			PathfinderRequestCompleteAndAwaitingUse = false;
			FlightCannotLaunch = false;
			FlightCannotLaunch_Feedback = "";
			Departed = false;
			Landed = false;
			SecondaryFlightPlans = new List<SecondaryFlightPlan>();
		}

		public Flight(ref Scenario theScen, ref Mission theMission, ref Flight theFlightPlan, string theCallsign, Contact thePrimaryTarget, Aircraft theReferenceUnit, _FlightSize theDesiredAircraftQty, bool theIsEscort)
		{
			bool_0 = false;
			Cache_ContactRelevantToFlight = new TDictionary<Module_Unit.Unit, bool>();
			UsedByFlightCount = 0;
			_FlightPlan = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_2 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_2 = new Waypoint[0];
			TakeOffTimeZuluString = "-";
			TakeOffTimeLocalString = "-";
			ObjectiveTimeZuluString = "-";
			ObjectiveTimeLocalString = "-";
			TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
			ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
			Pathfinder_Ingress_RequestBeingProcessed = false;
			Pathfinder_Egress_RequestBeingProcessed = false;
			PathfinderRequestBeingProcessed_OnThisPulse = false;
			PathfinderRequestCompleteAndAwaitingUse = false;
			FlightCannotLaunch = false;
			FlightCannotLaunch_Feedback = "";
			Departed = false;
			Landed = false;
			SecondaryFlightPlans = new List<SecondaryFlightPlan>();
			try
			{
				string landingLocation_HostUnitObjectID = "";
				string landingLocation_HostUnitObjectName = "";
				string takeOffLocation_HostUnitObjectID = "";
				string takeOffLocation_HostUnitObjectName = "";
				int num = 0;
				if (theReferenceUnit != null)
				{
					_ = theReferenceUnit.AirOps;
					if (theMission.SecondaryAirBase != null && theMission.SecondaryAirBase.AirOps.CanHostThisAircraft(theReferenceUnit) == AirOpsAttemptResult.Success && theMission.SecondaryAirBase.AirOps.CanThisAircraftLandHere(theReferenceUnit))
					{
						landingLocation_HostUnitObjectID = theMission.SecondaryAirBase.ObjectID;
						landingLocation_HostUnitObjectName = theMission.SecondaryAirBase.Name;
					}
					if (theReferenceUnit.AirOps.CurrentHostUnit != null)
					{
						takeOffLocation_HostUnitObjectID = theReferenceUnit.AirOps.CurrentHostUnit.ObjectID;
						takeOffLocation_HostUnitObjectName = theReferenceUnit.AirOps.CurrentHostUnit.Name;
					}
					num = theReferenceUnit.Loadout.DBID;
				}
				ParentMissionOrPackageObjectID = theMission.ObjectID;
				ParentMissionOrPackageName = theMission.Name;
				Callsign = theCallsign;
				TakeOffLocation_HostUnitObjectID = takeOffLocation_HostUnitObjectID;
				TakeOffLocation_HostUnitObjectName = takeOffLocation_HostUnitObjectName;
				LandingLocation_HostUnitObjectID = landingLocation_HostUnitObjectID;
				LandingLocation_HostUnitObjectName = landingLocation_HostUnitObjectName;
				int_1 = num;
				PrimaryTarget = thePrimaryTarget;
				if (!Information.IsNothing((object)thePrimaryTarget))
				{
					PrimaryTarget_ID = thePrimaryTarget.ObjectID;
				}
				this.set_ReferenceUnit(theScen, (ActiveUnit)theReferenceUnit);
				DesiredAircraftQty = theDesiredAircraftQty;
				Priority = _FlightPriority.Mandatory;
				IsEscort = theIsEscort;
				Name = "Mission: " + theMission.Name;
				if (theMission.UseFlightSizeHardLimit)
				{
					MinimumAircraftQty = theDesiredAircraftQty;
				}
				else
				{
					MinimumAircraftQty = 0;
				}
				if (!Information.IsNothing((object)theFlightPlan))
				{
					Waypoint[] flightPlan = theFlightPlan.FlightPlan;
					for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
					{
						Waypoint theOriginalWaypoint = flightPlan[i];
						Waypoint[] theArray = FlightPlan;
						Doctrine FlightLeadDoctrine = null;
						ArrayExtensions.Add(ref theArray, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
						FlightPlan = theArray;
					}
				}
				switch (theMission.MissionClass)
				{
				case _MissionClass.Strike:
					if (!IsEscort)
					{
						switch (((Strike)theMission).Type)
						{
						case Strike.StrikeType.Air_Intercept:
							Task = _FlightTask.GLI;
							break;
						case Strike.StrikeType.Land_Strike:
							Task = _FlightTask.Strike_Land;
							break;
						case Strike.StrikeType.Maritime_Strike:
							Task = _FlightTask.Strike_Naval;
							break;
						case Strike.StrikeType.Sub_Strike:
							Task = _FlightTask.ASW;
							break;
						}
					}
					else if (!Information.IsNothing((object)this.get_ReferenceUnit(theScen)) && this.get_ReferenceUnit(theScen).AI.IsEscort)
					{
						Aircraft aircraft = (Aircraft)this.get_ReferenceUnit(theScen);
						if (Information.IsNothing((object)aircraft.Loadout))
						{
							Task = _FlightTask.Escort_Support;
						}
						else if (!aircraft.Loadout.IsSupportOrPatrol)
						{
							if (!aircraft.Loadout.IsAAW)
							{
								if (aircraft.Loadout.IsStrike)
								{
									Task = _FlightTask.Escort_SEAD;
								}
								else
								{
									Task = _FlightTask.Escort_Support;
								}
							}
							else
							{
								Task = _FlightTask.Escort_FighterSweep;
							}
						}
						else
						{
							Task = _FlightTask.Escort_Support;
						}
					}
					else
					{
						Task = _FlightTask.Escort_Support;
					}
					break;
				case _MissionClass.Patrol:
					switch (((Patrol)theMission).Type)
					{
					case GlobalVariables.PatrolType.ASW:
						Task = _FlightTask.ASW;
						break;
					case GlobalVariables.PatrolType.ASuW_Naval:
						Task = _FlightTask.Maritime_Surveillance;
						break;
					case GlobalVariables.PatrolType.AAW:
						Task = _FlightTask.CAP;
						break;
					case GlobalVariables.PatrolType.ASuW_Land:
						Task = _FlightTask.Area_Surveillance;
						break;
					case GlobalVariables.PatrolType.ASuW_Mixed:
						Task = _FlightTask.Area_Surveillance;
						break;
					case GlobalVariables.PatrolType.SEAD:
						Task = _FlightTask.Strike_SEAD;
						break;
					case GlobalVariables.PatrolType.SeaControl:
						Task = _FlightTask.Maritime_Surveillance;
						break;
					}
					break;
				case _MissionClass.Support:
					Task = _FlightTask.Support;
					break;
				case _MissionClass.Ferry:
					Task = _FlightTask.Ferry;
					break;
				case _MissionClass.Mining:
					Task = _FlightTask.NavalMineLaying;
					break;
				case _MissionClass.MineClearing:
					Task = _FlightTask.MineSweeping;
					break;
				case _MissionClass.Escort:
					Task = _FlightTask.Escort_Support;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		internal bool IsEscortTask()
		{
			int result;
			switch (Task)
			{
			case _FlightTask.Escort_Support:
				result = 1;
				break;
			default:
				return false;
			case _FlightTask.Escort_FighterSweep:
			case _FlightTask.Escort_TARCAP:
			case _FlightTask.Escort_SEAD:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}

		public void SetTakeOffAndObjectiveTimeString(ref Scenario theScen)
		{
			try
			{
				DateTime time = theScen.Time;
				bool use_DST = theScen.Use_DST;
				string dST_Start = theScen.DST_Start;
				string dST_End = theScen.DST_End;
				DateTime? dateTime = null;
				DateTime? dateTime2 = null;
				DateTime? dateTime3 = null;
				DateTime? dateTime4 = null;
				string text = "";
				string text2 = "";
				bool? flag = null;
				if (FlightPlan.Count() > 0)
				{
					int num = FlightPlan.Count() - 1;
					for (int i = 0; i <= num; i++)
					{
						Waypoint waypoint = FlightPlan[i];
						if (!Information.IsNothing((object)waypoint.Time_Zulu))
						{
							flag = false;
							if (waypoint.Type == Waypoint.WaypointType.TakeOff)
							{
								dateTime = waypoint.Time_Zulu;
								TakeOffWaypointFixedTime = waypoint.TimeFixed;
								waypoint.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, UseCurrentScenarioTime: false, waypoint.Latitude, waypoint.Longitude, 0.0);
								waypoint.Time_Local = Misc.LocalTime(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								dateTime2 = waypoint.Time_Local;
								text = " (" + SunModule.GetTimeOfDay_String(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
							}
							else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.IsStationStartWaypoint())
							{
								flag = true;
								ObjectiveWaypointFixedTime = waypoint.TimeFixed;
								dateTime3 = (Information.IsNothing((object)waypoint.Time_Zulu_Weapon) ? waypoint.Time_Zulu : waypoint.Time_Zulu_Weapon);
								waypoint.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime3.Value.Year, dateTime3.Value.Month, dateTime3.Value.Day, dateTime3.Value.Hour, dateTime3.Value.Minute, dateTime3.Value.Second, UseCurrentScenarioTime: false, waypoint.Latitude, waypoint.Longitude, 0.0);
								if (!Information.IsNothing((object)waypoint.Time_Zulu_Weapon))
								{
									waypoint.Time_Local = Misc.LocalTime(waypoint.Time_Zulu_Weapon.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								}
								else
								{
									waypoint.Time_Local = Misc.LocalTime(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								}
								dateTime4 = waypoint.Time_Local;
								text2 = " (" + SunModule.GetTimeOfDay_String(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
								break;
							}
							continue;
						}
						TakeOffTimeZuluString = "";
						TakeOffTimeLocalString = "";
						ObjectiveTimeZuluString = "";
						ObjectiveTimeLocalString = "";
						TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
						ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
						break;
					}
				}
				if (Information.IsNothing((object)dateTime))
				{
					TakeOffTimeZuluString = "-";
				}
				else
				{
					DateTime theDate = dateTime.Value;
					GameGeneral.PaddedTimeAndDateString(ref theDate, ref TakeOffTimeZuluString);
				}
				if (Information.IsNothing((object)dateTime2))
				{
					TakeOffTimeLocalString = "-";
				}
				else
				{
					TakeOffTimeLocalString = "";
					DateTime theDate = dateTime2.Value;
					GameGeneral.PaddedTimeString(ref theDate, ref TakeOffTimeLocalString);
					TakeOffTimeLocalString += text;
				}
				if (Information.IsNothing((object)dateTime3))
				{
					if (!Information.IsNothing((object)flag) && ((!flag) ?? flag) == true)
					{
						ObjectiveTimeZuluString = "No waypoint found";
					}
					else
					{
						ObjectiveTimeZuluString = "-";
					}
				}
				else
				{
					DateTime theDate = dateTime3.Value;
					GameGeneral.PaddedTimeAndDateString(ref theDate, ref ObjectiveTimeZuluString);
				}
				if (!Information.IsNothing((object)dateTime4))
				{
					ObjectiveTimeLocalString = "";
					DateTime theDate = dateTime4.Value;
					GameGeneral.PaddedTimeString(ref theDate, ref ObjectiveTimeLocalString);
					ObjectiveTimeLocalString += text2;
				}
				else if (!Information.IsNothing((object)flag) && ((!flag) ?? flag) == true)
				{
					ObjectiveTimeLocalString = "No waypoint found";
				}
				else
				{
					ObjectiveTimeLocalString = "-";
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void ClearFlightPlan()
		{
			ArrayExtensions.Clear(ref _FlightPlan);
		}

		public void ChangeDesiredFlightSize(ref Scenario theScen, ref Mission theMission, Side theSide, _FlightSize theDesiredFlightSize)
		{
			try
			{
				if (this.get_Status(theScen) != _FlightStatus.None)
				{
					GameGeneral.SendMessageBoxToUI("Cannot change flight size for airborne flights.", theSide);
				}
				else
				{
					if (theDesiredFlightSize == DesiredAircraftQty)
					{
						return;
					}
					bool flag = ((theDesiredFlightSize > DesiredAircraftQty) ? true : false);
					if (HasWingmanWaypoints())
					{
						if (!flag)
						{
							int num = FlightPlan.Count() - 1;
							for (int i = 0; i <= num; i++)
							{
								Waypoint waypoint = FlightPlan[i];
								if (!Information.IsNothing((object)waypoint))
								{
									if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) && theDesiredFlightSize < 2)
									{
										waypoint.Waypoint_LeadElementWingman = null;
									}
									if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement) && theDesiredFlightSize < 3)
									{
										waypoint.Waypoint_SecondElement = null;
									}
									if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) && theDesiredFlightSize < 4)
									{
										waypoint.Waypoint_SecondElementWingman = null;
									}
									if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement) && theDesiredFlightSize < 6)
									{
										waypoint.Waypoint_ThirdElement = null;
									}
									if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) && theDesiredFlightSize < 6)
									{
										waypoint.Waypoint_ThirdElementWingman = null;
									}
								}
							}
						}
						else
						{
							int num2 = FlightPlan.Count() - 2;
							for (int j = 1; j <= num2; j++)
							{
								Waypoint waypoint2 = FlightPlan[j];
								Waypoint thePrevWaypoint = FlightPlan[j - 1];
								Waypoint theNextWaypoint = FlightPlan[j + 1];
								if (!Information.IsNothing((object)waypoint2) && waypoint2.FlightFormation == Waypoint.Formation.Split)
								{
									waypoint2.SplitWaypoint(ref theScen, ref theDesiredFlightSize, ref thePrevWaypoint, ref theNextWaypoint, OverwriteExistingWingmanWaypoints: false);
								}
							}
						}
					}
					DesiredAircraftQty = theDesiredFlightSize;
					if (MinimumAircraftQty > DesiredAircraftQty)
					{
						MinimumAircraftQty = DesiredAircraftQty;
					}
					Scenario theScen2 = theScen;
					Mission theMission2 = theMission;
					ActiveUnit theAU = this.get_ReferenceUnit(theScen);
					Waypoint[] theFlightplan = FlightPlan;
					float NecessaryFuel = 0f;
					float MissionFuel = 0f;
					MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission2, theAU, this, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
					FlightPlan = theFlightplan;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void ChangeMinimumFlightSize(ref Scenario theScen, ref Mission theMission, Side theSide, _FlightSize theMinimumFlightSize)
		{
			if (this.get_Status(theScen) == _FlightStatus.None)
			{
				MinimumAircraftQty = theMinimumFlightSize;
			}
			else
			{
				GameGeneral.SendMessageBoxToUI("Cannot change flight size for airborne flights.", theSide);
			}
		}

		internal bool HasWingmanWaypoints()
		{
			int num = FlightPlan.Count() - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Waypoint waypoint = FlightPlan[num2];
					if (!Information.IsNothing((object)waypoint) && waypoint.HasWingmanWaypoints())
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

		public void RenameFlightplanInFlightplanErrorList(ref Scenario theScen, ref Flight OriginalFlightPlan, string theOriginalCallsign, string theNewCallsign)
		{
			try
			{
				if (Information.IsNothing((object)theScen) || Information.IsNothing((object)theScen.MissionPlannerErrorList) || theScen.MissionPlannerErrorList.Count <= 0 || string.IsNullOrEmpty(OriginalFlightPlan.Callsign))
				{
					return;
				}
				for (int i = theScen.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
				{
					MDSP_Error mDSP_Error = theScen.MissionPlannerErrorList[i];
					if (string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						theScen.MissionPlannerErrorList.Remove(theScen.MissionPlannerErrorList[i]);
					}
					else if (Operators.CompareString(mDSP_Error.Flight, theOriginalCallsign, false) == 0)
					{
						theScen.MissionPlannerErrorList[i].Flight = theNewCallsign;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101383", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void AddMasterFlightPlanErrorsToFlightplanErrorList(ref Scenario theScen, ref Flight theMFP)
		{
			try
			{
				if (Information.IsNothing((object)theMFP.ErrorList) || theMFP.ErrorList.Count <= 0 || string.IsNullOrEmpty(theMFP.Callsign))
				{
					return;
				}
				string text = "Master Flightplan AircraftDBID: " + Conversions.ToString(theMFP.ReferenceUnit_DBID) + " LoadoutDBID: " + Conversions.ToString(theMFP.int_1);
				for (int i = theMFP.ErrorList.Count - 1; i >= 0; i += -1)
				{
					MDSP_Error mDSP_Error = theMFP.ErrorList[i];
					if (string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						theMFP.ErrorList.Remove(theMFP.ErrorList[i]);
						continue;
					}
					MDSP_Error mDSP_Error2 = mDSP_Error;
					if (Operators.CompareString(mDSP_Error2.Flight, text, false) == 0)
					{
						mDSP_Error2.Flight = Callsign;
					}
					theScen.MissionPlannerErrorList.Add(mDSP_Error2);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void Copy(ref Scenario theScen, ref Flight OriginalFlight, ref Flight NewFlight, bool UseMissionSettings, ref Mission theMission, ref int CreatedBy, ref int EditedBy, bool AddEmptySlotsToMission, bool CopyErrors)
		{
			try
			{
				if (Information.IsNothing((object)OriginalFlight) || Information.IsNothing((object)NewFlight))
				{
					return;
				}
				string text = (Information.IsNothing((object)theMission) ? "Temporary flightplan" : Callsigns.FetchCallsignBasedOnMissionType(ref theMission));
				NewFlight.ParentMissionOrPackageObjectID = OriginalFlight.ParentMissionOrPackageObjectID;
				NewFlight.ParentMissionOrPackageName = OriginalFlight.ParentMissionOrPackageName;
				NewFlight.Callsign = text;
				NewFlight.Task = OriginalFlight.Task;
				NewFlight.Type = OriginalFlight.Type;
				NewFlight.Priority = OriginalFlight.Priority;
				NewFlight.TakeOffLocation_HostUnitObjectID = OriginalFlight.TakeOffLocation_HostUnitObjectID;
				NewFlight.TakeOffLocation_HostUnitObjectName = OriginalFlight.TakeOffLocation_HostUnitObjectName;
				NewFlight.LandingLocation_HostUnitObjectID = OriginalFlight.LandingLocation_HostUnitObjectID;
				NewFlight.LandingLocation_HostUnitObjectName = OriginalFlight.LandingLocation_HostUnitObjectName;
				NewFlight.AlternativeLandingLocation_HostUnitObjectID = OriginalFlight.AlternativeLandingLocation_HostUnitObjectID;
				NewFlight.AlternativeLandingLocation_HostUnitObjectName = OriginalFlight.AlternativeLandingLocation_HostUnitObjectName;
				if (UseMissionSettings)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					NewFlight.DesiredAircraftQty = OriginalFlight.DesiredAircraftQty;
				}
				NewFlight.IsEscort = OriginalFlight.IsEscort;
				NewFlight.EarliestTaskingTime = OriginalFlight.EarliestTaskingTime;
				NewFlight.LatestTaskingTime = OriginalFlight.LatestTaskingTime;
				NewFlight.MaxReadyTime = OriginalFlight.MaxReadyTime;
				NewFlight.EarliestLaunchTime = OriginalFlight.EarliestLaunchTime;
				NewFlight.LatestLaunchTime = OriginalFlight.LatestLaunchTime;
				NewFlight.Priority = OriginalFlight.Priority;
				NewFlight.set_Status(theScen, _FlightStatus.None);
				NewFlight.CreatedBy = OriginalFlight.CreatedBy;
				NewFlight.EditedBy = OriginalFlight.EditedBy;
				NewFlight.MinimumAircraftQty = OriginalFlight.MinimumAircraftQty;
				NewFlight.ReadyAircraftQty = OriginalFlight.ReadyAircraftQty;
				NewFlight.UsedByFlightCount = 0;
				NewFlight.set_ReferenceUnit((Scenario)null, (ActiveUnit)null);
				NewFlight.ReferenceUnit_DBID = OriginalFlight.ReferenceUnit_DBID;
				NewFlight.ReferenceUnit_ObjectID = "";
				NewFlight.ReferenceUnit_Name = OriginalFlight.ReferenceUnit_Name;
				NewFlight.int_1 = OriginalFlight.int_1;
				NewFlight.set_LoadoutName(theScen, OriginalFlight.get_LoadoutName(theScen));
				checked
				{
					if (!Information.IsNothing((object)OriginalFlight.FlightPlan) && OriginalFlight.FlightPlan.Count() > 0)
					{
						Waypoint[] flightPlan = OriginalFlight.FlightPlan;
						for (int i = 0; i < flightPlan.Length; i++)
						{
							Waypoint theOriginalWaypoint = flightPlan[i];
							Flight obj = NewFlight;
							Waypoint[] theArray = obj.FlightPlan;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							obj.FlightPlan = theArray;
						}
					}
					if (!Information.IsNothing((object)OriginalFlight.FlightPlan_Pathfinder_Ingress_1) && OriginalFlight.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						Waypoint[] theArray = OriginalFlight.FlightPlan_Pathfinder_Ingress_1;
						for (int j = 0; j < theArray.Length; j++)
						{
							Waypoint theOriginalWaypoint2 = theArray[j];
							Flight obj2 = NewFlight;
							Waypoint[] theArray2 = obj2.FlightPlan_Pathfinder_Ingress_1;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray2, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint2, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							obj2.FlightPlan_Pathfinder_Ingress_1 = theArray2;
						}
					}
					if (!Information.IsNothing((object)OriginalFlight.FlightPlan_Pathfinder_Ingress_2) && OriginalFlight.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
					{
						Waypoint[] theArray2 = OriginalFlight.FlightPlan_Pathfinder_Ingress_2;
						for (int k = 0; k < theArray2.Length; k++)
						{
							Waypoint theOriginalWaypoint3 = theArray2[k];
							Flight obj3 = NewFlight;
							Waypoint[] theArray3 = obj3.FlightPlan_Pathfinder_Ingress_2;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray3, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint3, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							obj3.FlightPlan_Pathfinder_Ingress_2 = theArray3;
						}
					}
					if (!Information.IsNothing((object)OriginalFlight.FlightPlan_Pathfinder_Egress_1) && OriginalFlight.FlightPlan_Pathfinder_Egress_1.Count() > 0)
					{
						Waypoint[] theArray3 = OriginalFlight.FlightPlan_Pathfinder_Egress_1;
						for (int l = 0; l < theArray3.Length; l++)
						{
							Waypoint theOriginalWaypoint4 = theArray3[l];
							Flight obj4 = NewFlight;
							Waypoint[] theArray4 = obj4.FlightPlan_Pathfinder_Egress_1;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray4, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint4, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							obj4.FlightPlan_Pathfinder_Egress_1 = theArray4;
						}
					}
					if (!Information.IsNothing((object)OriginalFlight.FlightPlan_Pathfinder_Egress_2) && OriginalFlight.FlightPlan_Pathfinder_Egress_2.Count() > 0)
					{
						Waypoint[] theArray4 = OriginalFlight.FlightPlan_Pathfinder_Egress_2;
						for (int m = 0; m < theArray4.Length; m++)
						{
							Waypoint theOriginalWaypoint5 = theArray4[m];
							Flight obj5 = NewFlight;
							Waypoint[] theArray5 = obj5.FlightPlan_Pathfinder_Egress_2;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray5, Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint5, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							obj5.FlightPlan_Pathfinder_Egress_2 = theArray5;
						}
					}
					NewFlight.TaskPool = OriginalFlight.TaskPool;
					NewFlight.Age = 0;
					NewFlight.PrimaryTarget = OriginalFlight.PrimaryTarget;
					NewFlight.PrimaryTarget_ID = OriginalFlight.PrimaryTarget_ID;
					NewFlight.Pathfinder_Ingress_RequestBeingProcessed = false;
					NewFlight.Pathfinder_Egress_RequestBeingProcessed = false;
					NewFlight.PathfinderRequestBeingProcessed_OnThisPulse = false;
					NewFlight.FlightCannotLaunch = false;
					NewFlight.FlightCannotLaunch_Feedback = "";
					if (!Information.IsNothing((object)theMission))
					{
						theMission.AddFlight(ref NewFlight);
					}
				}
				if (!Information.IsNothing((object)theMission) && AddEmptySlotsToMission)
				{
					if (Information.IsNothing((object)theMission.EmptySlotsList))
					{
						theMission.EmptySlotsList = new List<EmptyAircraftSlot>();
					}
					ActiveUnit theCurrentHostUnit = default(ActiveUnit);
					if (theScen.ActiveUnits.ContainsKey(NewFlight.TakeOffLocation_HostUnitObjectID))
					{
						theCurrentHostUnit = theScen.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
					}
					int num = NewFlight.DesiredAircraftQty;
					for (int n = 1; n <= num; n++)
					{
						EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot(null, NewFlight.ReferenceUnit_DBID, NewFlight.ReferenceUnit_Name, NewFlight.int_1, NewFlight.get_LoadoutName(theScen), ref theCurrentHostUnit, NewFlight.TakeOffLocation_HostUnitObjectID, NewFlight.LandingLocation_HostUnitObjectName, NewFlight.IsEscort);
						theMission.EmptySlotsList.Add(emptyAircraftSlot);
						emptyAircraftSlot.SetFlight(theScen, NewFlight, n);
					}
				}
				if (!CopyErrors)
				{
					return;
				}
				MDSP_Error mDSP_Error = new MDSP_Error();
				for (int num2 = theScen.MissionPlannerErrorList.Count - 1; num2 >= 0; num2 += -1)
				{
					mDSP_Error.Mission = theMission.Name;
					mDSP_Error.Flight = OriginalFlight.Callsign;
					mDSP_Error = theScen.MissionPlannerErrorList[num2];
					if (!string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						if (Operators.CompareString(mDSP_Error.Flight, OriginalFlight.Callsign, false) == 0)
						{
							MDSP_Error item = new MDSP_Error(theMission.Name, text, mDSP_Error.Message);
							theScen.MissionPlannerErrorList.Add(item);
						}
					}
					else
					{
						theScen.MissionPlannerErrorList.Remove(theScen.MissionPlannerErrorList[num2]);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101384", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static List<Flight> FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0afc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b03: Expected O, but got Unknown
			//IL_09ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_09d1: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_057e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Expected O, but got Unknown
			List<Flight> result = default(List<Flight>);
			try
			{
				List<Flight> list = new List<Flight>();
				int dBID = default(int);
				int loadout_DBID = default(int);
				string innerText2 = default(string);
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					string name = val.Name;
					if (Operators.CompareString(name, "Flight", false) != 0)
					{
						continue;
					}
					Flight flight = new Flight();
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						switch (val2.Name)
						{
						case "Landed":
							flight.Landed = Conversions.ToBoolean(val2.InnerText);
							break;
						case "Status":
							flight.set_Status(theScen, (_FlightStatus)Conversions.ToByte(val2.InnerText));
							break;
						case "TaskPool_Name":
							flight.TaskPool_Name = val2.InnerText;
							break;
						case "SecondaryFPs":
							foreach (XmlNode childNode3 in val2.ChildNodes)
							{
								XmlNode val3 = childNode3;
								if (Operators.CompareString(val3.Name, "SecondaryFP", false) != 0)
								{
									continue;
								}
								List<Waypoint> list2 = new List<Waypoint>();
								foreach (XmlNode childNode4 in val3.ChildNodes)
								{
									XmlNode val4 = childNode4;
									switch (val4.Name)
									{
									case "DBID":
										dBID = int.Parse(val4.InnerText);
										break;
									case "Loadout":
										loadout_DBID = int.Parse(val4.InnerText);
										break;
									case "FPCallsign":
										innerText2 = val4.InnerText;
										break;
									case "FlightPlan":
										foreach (XmlNode childNode5 in val4.ChildNodes)
										{
											XmlNode theNode4 = childNode5;
											Waypoint item2 = Waypoint.FromXML(ref theNode4, ref theDictionary, theScen);
											list2.Add(item2);
										}
										break;
									}
								}
								if (flight.SecondaryFlightPlans == null)
								{
									flight.SecondaryFlightPlans = new List<SecondaryFlightPlan>();
								}
								SecondaryFlightPlan item3 = new SecondaryFlightPlan(dBID, loadout_DBID, list2.ToArray(), innerText2);
								flight.SecondaryFlightPlans.Add(item3);
							}
							break;
						case "MinimumAircraftQty":
							flight.MinimumAircraftQty = Conversions.ToByte(val2.InnerText);
							break;
						case "LandingLocation_HostUnitObjectID":
							flight.LandingLocation_HostUnitObjectID = val2.InnerText;
							break;
						case "TakeOffLocation_HostUnitObjectName":
							flight.TakeOffLocation_HostUnitObjectName = val2.InnerText;
							break;
						case "LoadoutDBID":
							flight.int_1 = Conversions.ToInteger(val2.InnerText);
							break;
						case "LoadoutName":
							flight.set_LoadoutName(theScen, val2.InnerText);
							break;
						case "UsedByFlight":
							if (Conversions.ToBoolean(val2.InnerText))
							{
								flight.UsedByFlightCount = 0;
							}
							else
							{
								flight.UsedByFlightCount = 1;
							}
							break;
						case "ReferenceUnit_Name":
							flight.ReferenceUnit_Name = val2.InnerText;
							break;
						case "EditedBy":
							flight.EditedBy = (_FlightCreatedBy)Conversions.ToByte(val2.InnerText);
							break;
						case "LatestTaskingTime":
						{
							DateTime value4 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							flight.LatestTaskingTime = value4;
							break;
						}
						case "NotificationList":
							if (Information.IsNothing((object)flight.NotificationList))
							{
								flight.NotificationList = new List<string>();
							}
							foreach (XmlNode childNode6 in val2.ChildNodes)
							{
								string innerText = childNode6.InnerText;
								flight.NotificationList.Add(innerText);
							}
							break;
						case "ParentMissionOrPackageObjectID":
							flight.ParentMissionOrPackageObjectID = val2.InnerText;
							break;
						case "PrimaryTarget_ID":
							flight.PrimaryTarget_ID = val2.InnerText;
							break;
						case "ID":
							flight.ObjectID_Set(val2.InnerText);
							break;
						case "Departed":
							flight.Departed = Conversions.ToBoolean(val2.InnerText);
							break;
						case "UsedByFlightCount":
							flight.UsedByFlightCount = Conversions.ToInteger(val2.InnerText);
							break;
						case "EarliestTaskingTime":
						{
							DateTime value3 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							flight.EarliestTaskingTime = value3;
							break;
						}
						case "AlternativeLandingLocation_HostUnitObjectID":
							flight.AlternativeLandingLocation_HostUnitObjectID = val2.InnerText;
							break;
						case "Task":
							flight.Task = (_FlightTask)Conversions.ToByte(val2.InnerText);
							break;
						case "EarliestLaunchTime":
						{
							DateTime value2 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							flight.EarliestLaunchTime = value2;
							break;
						}
						case "AlternativeLandingLocation_HostUnitObjectName":
							flight.AlternativeLandingLocation_HostUnitObjectName = val2.InnerText;
							break;
						case "CreatedBy":
							flight.CreatedBy = (_FlightCreatedBy)Conversions.ToByte(val2.InnerText);
							break;
						case "IsEscort":
							flight.IsEscort = Conversions.ToBoolean(val2.InnerText);
							break;
						case "ReferenceUnit_ObjectID":
							flight.ReferenceUnit_ObjectID = val2.InnerText;
							break;
						case "LatestLaunchTime":
						{
							DateTime value = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							flight.LatestLaunchTime = value;
							break;
						}
						case "Age":
							flight.Age = Conversions.ToInteger(val2.InnerText);
							break;
						case "ReferenceUnit_DBID":
							flight.ReferenceUnit_DBID = Conversions.ToInteger(val2.InnerText);
							break;
						case "ParentMissionOrPackageName":
							flight.ParentMissionOrPackageName = val2.InnerText;
							break;
						case "ErrorList":
							if (Information.IsNothing((object)flight.ErrorList))
							{
								flight.ErrorList = new List<MDSP_Error>();
							}
							foreach (XmlNode childNode7 in val2.ChildNodes)
							{
								XmlNode theNode3 = childNode7;
								MDSP_Error item = MDSP_Error.FromXML(ref theNode3, ref theDictionary);
								flight.ErrorList.Add(item);
							}
							break;
						case "TakeOffLocation_HostUnitObjectID":
							flight.TakeOffLocation_HostUnitObjectID = val2.InnerText;
							break;
						case "Callsign":
							flight.Callsign = val2.InnerText;
							break;
						case "Type":
							flight.Type = (_FlightType)Conversions.ToByte(val2.InnerText);
							break;
						case "FlightPlan":
							foreach (XmlNode childNode8 in val2.ChildNodes)
							{
								XmlNode theNode2 = childNode8;
								Waypoint theAC = Waypoint.FromXML(ref theNode2, ref theDictionary, theScen);
								Waypoint[] theArray = flight.FlightPlan;
								ArrayExtensions.Add(ref theArray, theAC);
								flight.FlightPlan = theArray;
							}
							break;
						case "ReadyAircraftQty":
							flight.ReadyAircraftQty = Conversions.ToByte(val2.InnerText);
							break;
						case "TaskPool_ID":
							flight.TaskPool_ID = val2.InnerText;
							break;
						case "MaxReadyTime":
							flight.MaxReadyTime = Conversions.ToShort(val2.InnerText);
							break;
						case "DesiredAircraftQty":
							flight.DesiredAircraftQty = Conversions.ToByte(val2.InnerText);
							break;
						case "LandingLocation_HostUnitObjectName":
							flight.LandingLocation_HostUnitObjectName = val2.InnerText;
							break;
						case "HasCriticalError":
							flight.HasCriticalError = Conversions.ToBoolean(val2.InnerText);
							break;
						case "Priority":
							flight.Priority = (_FlightPriority)Conversions.ToByte(val2.InnerText);
							break;
						}
					}
					list.Add(flight);
				}
				result = list;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen, ref List<Flight> FlightList)
		{
			theWriter.WriteStartElement("FlightList");
			foreach (Flight Flight in FlightList)
			{
				theWriter.WriteStartElement("Flight");
				theWriter.WriteElementString("ID", Flight.ObjectID);
				theWriter.WriteElementString("ParentMissionOrPackageObjectID", Flight.ParentMissionOrPackageObjectID);
				theWriter.WriteElementString("ParentMissionOrPackageName", Flight.ParentMissionOrPackageName);
				theWriter.WriteElementString("Callsign", Flight.Callsign);
				theWriter.WriteElementString("Task", ((byte)Flight.Task).ToString());
				theWriter.WriteElementString("Type", ((byte)Flight.Type).ToString());
				theWriter.WriteElementString("TakeOffLocation_HostUnitObjectID", Flight.TakeOffLocation_HostUnitObjectID);
				theWriter.WriteElementString("TakeOffLocation_HostUnitObjectName", Flight.TakeOffLocation_HostUnitObjectName);
				theWriter.WriteElementString("LandingLocation_HostUnitObjectID", Flight.LandingLocation_HostUnitObjectID);
				theWriter.WriteElementString("LandingLocation_HostUnitObjectName", Flight.LandingLocation_HostUnitObjectName);
				theWriter.WriteElementString("AlternativeLandingLocation_HostUnitObjectID", Flight.AlternativeLandingLocation_HostUnitObjectID);
				theWriter.WriteElementString("AlternativeLandingLocation_HostUnitObjectName", Flight.AlternativeLandingLocation_HostUnitObjectName);
				if (Flight.EarliestTaskingTime.HasValue)
				{
					theWriter.WriteElementString("EarliestTaskingTime", Flight.EarliestTaskingTime.Value.ToBinary().ToString());
				}
				if (Flight.LatestTaskingTime.HasValue)
				{
					theWriter.WriteElementString("LatestTaskingTime", Flight.LatestTaskingTime.Value.ToBinary().ToString());
				}
				if (Flight.EarliestLaunchTime.HasValue)
				{
					theWriter.WriteElementString("EarliestLaunchTime", Flight.EarliestLaunchTime.Value.ToBinary().ToString());
				}
				if (Flight.LatestLaunchTime.HasValue)
				{
					theWriter.WriteElementString("LatestLaunchTime", Flight.LatestLaunchTime.Value.ToBinary().ToString());
				}
				theWriter.WriteElementString("MaxReadyTime", Flight.MaxReadyTime.ToString());
				XmlWriter obj = theWriter;
				int priority = (int)Flight.Priority;
				obj.WriteElementString("Priority", priority.ToString());
				theWriter.WriteElementString("Status", ((int)Flight.get_Status(theScen)).ToString());
				XmlWriter obj2 = theWriter;
				priority = (int)Flight.CreatedBy;
				obj2.WriteElementString("CreatedBy", priority.ToString());
				XmlWriter obj3 = theWriter;
				priority = (int)Flight.EditedBy;
				obj3.WriteElementString("EditedBy", priority.ToString());
				theWriter.WriteElementString("DesiredAircraftQty", ((int)Flight.DesiredAircraftQty).ToString());
				theWriter.WriteElementString("MinimumAircraftQty", ((int)Flight.MinimumAircraftQty).ToString());
				theWriter.WriteElementString("ReadyAircraftQty", Flight.ReadyAircraftQty.ToString());
				theWriter.WriteElementString("ReferenceUnit_DBID", Flight.ReferenceUnit_DBID.ToString());
				theWriter.WriteElementString("ReferenceUnit_ObjectID", Flight.ReferenceUnit_ObjectID);
				theWriter.WriteElementString("ReferenceUnit_Name", Flight.ReferenceUnit_Name);
				theWriter.WriteElementString("LoadoutDBID", Flight.int_1.ToString());
				theWriter.WriteElementString("LoadoutName", Flight.get_LoadoutName(theScen));
				theWriter.WriteElementString("UsedByFlightCount", Flight.UsedByFlightCount.ToString());
				theWriter.WriteElementString("IsEscort", Flight.IsEscort.ToString());
				theWriter.WriteElementString("Departed", Flight.Departed.ToString());
				theWriter.WriteElementString("Landed", Flight.Landed.ToString());
				if (Information.IsNothing((object)Flight.TaskPool))
				{
					theWriter.WriteElementString("TaskPool_ID", Flight.TaskPool_ID);
				}
				else
				{
					theWriter.WriteElementString("TaskPool_ID", Flight.TaskPool.ObjectID);
				}
				if (Information.IsNothing((object)Flight.PrimaryTarget))
				{
					theWriter.WriteElementString("PrimaryTarget_ID", Flight.PrimaryTarget_ID);
				}
				else
				{
					theWriter.WriteElementString("PrimaryTarget_ID", Flight.PrimaryTarget.ObjectID);
				}
				theWriter.WriteElementString("TaskPool_Name", Flight.TaskPool_Name);
				theWriter.WriteElementString("Age", Flight.Age.ToString());
				if (!Information.IsNothing((object)Flight.FlightPlan) && Flight.FlightPlan.Count() > 0)
				{
					theWriter.WriteStartElement("FlightPlan");
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(Flight.FlightPlan);
					foreach (Waypoint item in list)
					{
						if (!Information.IsNothing((object)item))
						{
							item.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
						}
					}
					theWriter.WriteEndElement();
				}
				if (!Information.IsNothing((object)Flight.SecondaryFlightPlans) && Flight.SecondaryFlightPlans.Count > 0)
				{
					theWriter.WriteStartElement("SecondaryFPs");
					List<SecondaryFlightPlan> list2 = new List<SecondaryFlightPlan>();
					list2.AddRange(Flight.SecondaryFlightPlans);
					foreach (SecondaryFlightPlan item2 in list2)
					{
						if (Information.IsNothing((object)item2))
						{
							continue;
						}
						theWriter.WriteStartElement("SecondaryFP");
						theWriter.WriteElementString("DBID", item2.DBID.ToString());
						theWriter.WriteElementString("Loadout", item2.Loadout_DBID.ToString());
						theWriter.WriteElementString("FPCallsign", item2.string_0);
						theWriter.WriteStartElement("FlightPlan");
						List<Waypoint> list3 = new List<Waypoint>();
						list3.AddRange(item2.FlightPlan);
						foreach (Waypoint item3 in list3)
						{
							if (!Information.IsNothing((object)item3))
							{
								item3.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
							}
						}
						theWriter.WriteEndElement();
						theWriter.WriteEndElement();
					}
					theWriter.WriteEndElement();
				}
				if (!Information.IsNothing((object)Flight.ErrorList) && Flight.ErrorList.Count > 0)
				{
					theWriter.WriteStartElement("ErrorList");
					foreach (MDSP_Error error in Flight.ErrorList)
					{
						error.ToXML(ObjectsAlreadySerialized);
					}
					theWriter.WriteEndElement();
				}
				if (!Information.IsNothing((object)Flight.NotificationList) && Flight.NotificationList.Count > 0)
				{
					theWriter.WriteStartElement("NotificationList");
					foreach (string notification in Flight.NotificationList)
					{
						theWriter.WriteElementString("Message", notification);
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteElementString("HasCriticalError", Flight.HasCriticalError.ToString());
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}

		public static void DetermineInitialFlightPlanTimes(ref Scenario theScen, ref Mission theMission, ref DateTime? theTakeOffTime, ref DateTime? theObjectiveTime)
		{
			try
			{
				theTakeOffTime = null;
				theObjectiveTime = null;
				if (Information.IsNothing((object)theMission.TakeOffTime))
				{
					if (!Information.IsNothing((object)theMission.TimeOnTarget))
					{
						theObjectiveTime = theMission.TimeOnTarget.Value;
					}
				}
				else
				{
					theTakeOffTime = theMission.TakeOffTime.Value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static string SetInitialFlightPlanTimes(ref Scenario theScen, ref Mission theMission, Waypoint[] theFlightPlan, bool BananaSplitRedSection, DateTime? theTakeOffTime, DateTime? theObjectiveTime)
		{
			string result;
			try
			{
				if (theFlightPlan.Count() == 0)
				{
					result = null;
				}
				else if (Information.IsNothing((object)theTakeOffTime) && Information.IsNothing((object)theObjectiveTime))
				{
					result = "OK";
				}
				else
				{
					bool flag = false;
					DateTime value = default(DateTime);
					if (Information.IsNothing((object)theTakeOffTime))
					{
						if (!Information.IsNothing((object)theObjectiveTime))
						{
							value = theObjectiveTime.Value;
							flag = false;
						}
					}
					else
					{
						value = theTakeOffTime.Value;
						flag = true;
					}
					if (theMission.MissionClass == _MissionClass.Strike && ((Strike)theMission).AttackMethod == _AttackMethod.BananaSplit && !BananaSplitRedSection)
					{
						value = value.AddSeconds((float)(((Strike)theMission).FlightSize - 1) * 10f);
					}
					Waypoint waypoint2 = default(Waypoint);
					foreach (Waypoint waypoint in theFlightPlan)
					{
						if (!flag || waypoint.Type != Waypoint.WaypointType.TakeOff)
						{
							if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget && !((waypoint.Type == Waypoint.WaypointType.Land) & (theMission.MissionClass == _MissionClass.Ferry)))
							{
								if (waypoint.IsStationStartWaypoint())
								{
									waypoint2 = waypoint;
									break;
								}
								continue;
							}
							waypoint2 = waypoint;
							break;
						}
						waypoint2 = waypoint;
						break;
					}
					if (Information.IsNothing((object)waypoint2))
					{
						result = (flag ? "Could not find the take-off waypoint, so could not set flightplan waypoint times." : "Could not find the target or station waypoint, so could not set flightplan waypoint times.");
					}
					else
					{
						waypoint2.TimeFixed = Waypoint.FixedFree.Fixed;
						if (!float.IsNaN(waypoint2.Leg_Time_Weapon) && !float.IsInfinity(waypoint2.Leg_Time_Weapon) && waypoint2.Leg_Time_Weapon > 0f)
						{
							waypoint2.Time_Zulu = value.AddSeconds(0f - waypoint2.Leg_Time_Weapon);
							waypoint2.Time_Zulu_Weapon = value;
						}
						else
						{
							waypoint2.Time_Zulu = value;
							waypoint2.Time_Zulu_Weapon = null;
						}
						result = "OK";
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 200645", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = "Something went wrong.";
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static void ComboBoxDataSource_Task(ref DataTable theComboBoxDataSource_Task)
		{
			if (!theComboBoxDataSource_Task.Columns.Contains("ID"))
			{
				theComboBoxDataSource_Task.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource_Task.Columns.Contains("Description"))
			{
				theComboBoxDataSource_Task.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource_Task.Rows.Add(0, Mission.get_FlightTaskString(_FlightTask.Strike_Land));
			theComboBoxDataSource_Task.Rows.Add(1, Mission.get_FlightTaskString(_FlightTask.Strike_OCA));
			theComboBoxDataSource_Task.Rows.Add(2, Mission.get_FlightTaskString(_FlightTask.Strike_Interdiction));
			theComboBoxDataSource_Task.Rows.Add(3, Mission.get_FlightTaskString(_FlightTask.Strike_SEAD));
			theComboBoxDataSource_Task.Rows.Add(4, Mission.get_FlightTaskString(_FlightTask.Strike_Naval));
			theComboBoxDataSource_Task.Rows.Add(5, Mission.get_FlightTaskString(_FlightTask.BAI));
			theComboBoxDataSource_Task.Rows.Add(6, Mission.get_FlightTaskString(_FlightTask.CAS));
			theComboBoxDataSource_Task.Rows.Add(7, Mission.get_FlightTaskString(_FlightTask.Buddy_Illumination));
			theComboBoxDataSource_Task.Rows.Add(8, Mission.get_FlightTaskString(_FlightTask.CAP));
			theComboBoxDataSource_Task.Rows.Add(9, Mission.get_FlightTaskString(_FlightTask.BARCAP));
			theComboBoxDataSource_Task.Rows.Add(10, Mission.get_FlightTaskString(_FlightTask.TARCAP));
			theComboBoxDataSource_Task.Rows.Add(11, Mission.get_FlightTaskString(_FlightTask.HAVCAP));
			theComboBoxDataSource_Task.Rows.Add(12, Mission.get_FlightTaskString(_FlightTask.RESCAP));
			theComboBoxDataSource_Task.Rows.Add(13, Mission.get_FlightTaskString(_FlightTask.GLI));
			theComboBoxDataSource_Task.Rows.Add(14, Mission.get_FlightTaskString(_FlightTask.DLI));
			theComboBoxDataSource_Task.Rows.Add(15, Mission.get_FlightTaskString(_FlightTask.Sweep_Fighter));
			theComboBoxDataSource_Task.Rows.Add(16, Mission.get_FlightTaskString(_FlightTask.Sweep_SEAD));
			theComboBoxDataSource_Task.Rows.Add(17, Mission.get_FlightTaskString(_FlightTask.QRA));
			theComboBoxDataSource_Task.Rows.Add(18, Mission.get_FlightTaskString(_FlightTask.Escort_TARCAP));
			theComboBoxDataSource_Task.Rows.Add(19, Mission.get_FlightTaskString(_FlightTask.Escort_FighterSweep));
			theComboBoxDataSource_Task.Rows.Add(20, Mission.get_FlightTaskString(_FlightTask.Escort_SEAD));
			theComboBoxDataSource_Task.Rows.Add(21, Mission.get_FlightTaskString(_FlightTask.Escort_Support));
			theComboBoxDataSource_Task.Rows.Add(22, Mission.get_FlightTaskString(_FlightTask.ASAT));
			theComboBoxDataSource_Task.Rows.Add(23, Mission.get_FlightTaskString(_FlightTask.AirborneLaser));
			theComboBoxDataSource_Task.Rows.Add(24, Mission.get_FlightTaskString(_FlightTask.OECM));
			theComboBoxDataSource_Task.Rows.Add(25, Mission.get_FlightTaskString(_FlightTask.AEW));
			theComboBoxDataSource_Task.Rows.Add(26, Mission.get_FlightTaskString(_FlightTask.CommandPost));
			theComboBoxDataSource_Task.Rows.Add(27, Mission.get_FlightTaskString(_FlightTask.ChaffLaying));
			theComboBoxDataSource_Task.Rows.Add(28, Mission.get_FlightTaskString(_FlightTask.SearchAndRescue));
			theComboBoxDataSource_Task.Rows.Add(29, Mission.get_FlightTaskString(_FlightTask.CombatSearchAndRescue));
			theComboBoxDataSource_Task.Rows.Add(30, Mission.get_FlightTaskString(_FlightTask.MineSweeping));
			theComboBoxDataSource_Task.Rows.Add(31, Mission.get_FlightTaskString(_FlightTask.MineRecon));
			theComboBoxDataSource_Task.Rows.Add(32, Mission.get_FlightTaskString(_FlightTask.NavalMineLaying));
			theComboBoxDataSource_Task.Rows.Add(33, Mission.get_FlightTaskString(_FlightTask.ASW));
			theComboBoxDataSource_Task.Rows.Add(34, Mission.get_FlightTaskString(_FlightTask.Forward_Observer));
			theComboBoxDataSource_Task.Rows.Add(35, Mission.get_FlightTaskString(_FlightTask.Area_Surveillance));
			theComboBoxDataSource_Task.Rows.Add(36, Mission.get_FlightTaskString(_FlightTask.Armed_Recon));
			theComboBoxDataSource_Task.Rows.Add(37, Mission.get_FlightTaskString(_FlightTask.Unarmed_Recon));
			theComboBoxDataSource_Task.Rows.Add(38, Mission.get_FlightTaskString(_FlightTask.Maritime_Surveillance));
			theComboBoxDataSource_Task.Rows.Add(39, Mission.get_FlightTaskString(_FlightTask.Paratroopers));
			theComboBoxDataSource_Task.Rows.Add(40, Mission.get_FlightTaskString(_FlightTask.Troop_Transport));
			theComboBoxDataSource_Task.Rows.Add(41, Mission.get_FlightTaskString(_FlightTask.Cargo));
			theComboBoxDataSource_Task.Rows.Add(42, Mission.get_FlightTaskString(_FlightTask.AirRefueling));
			theComboBoxDataSource_Task.Rows.Add(43, Mission.get_FlightTaskString(_FlightTask.Support));
			theComboBoxDataSource_Task.Rows.Add(44, Mission.get_FlightTaskString(_FlightTask.Training));
			theComboBoxDataSource_Task.Rows.Add(45, Mission.get_FlightTaskString(_FlightTask.TargetTow));
			theComboBoxDataSource_Task.Rows.Add(46, Mission.get_FlightTaskString(_FlightTask.TargetDrone));
			theComboBoxDataSource_Task.Rows.Add(47, Mission.get_FlightTaskString(_FlightTask.Ferry));
		}

		public static _FlightTask TaskSelection_To_Task(int TaskValue)
		{
			_FlightTask result = default(_FlightTask);
			try
			{
				switch (TaskValue)
				{
				default:
					result = _FlightTask.None;
					return result;
				case 0:
					result = _FlightTask.Strike_Land;
					return result;
				case 1:
					result = _FlightTask.Strike_OCA;
					return result;
				case 2:
					result = _FlightTask.Strike_Interdiction;
					return result;
				case 3:
					result = _FlightTask.Strike_SEAD;
					return result;
				case 4:
					result = _FlightTask.Strike_Naval;
					return result;
				case 5:
					result = _FlightTask.BAI;
					return result;
				case 6:
					result = _FlightTask.CAS;
					return result;
				case 7:
					result = _FlightTask.Buddy_Illumination;
					return result;
				case 8:
					result = _FlightTask.CAP;
					return result;
				case 9:
					result = _FlightTask.BARCAP;
					return result;
				case 10:
					result = _FlightTask.TARCAP;
					return result;
				case 11:
					result = _FlightTask.HAVCAP;
					return result;
				case 12:
					result = _FlightTask.RESCAP;
					return result;
				case 13:
					result = _FlightTask.GLI;
					return result;
				case 14:
					result = _FlightTask.DLI;
					return result;
				case 15:
					result = _FlightTask.Sweep_Fighter;
					return result;
				case 16:
					result = _FlightTask.Sweep_SEAD;
					return result;
				case 17:
					result = _FlightTask.QRA;
					return result;
				case 18:
					result = _FlightTask.Escort_TARCAP;
					return result;
				case 19:
					result = _FlightTask.Escort_FighterSweep;
					return result;
				case 20:
					result = _FlightTask.Escort_SEAD;
					return result;
				case 21:
					result = _FlightTask.Escort_Support;
					return result;
				case 22:
					result = _FlightTask.ASAT;
					return result;
				case 23:
					result = _FlightTask.AirborneLaser;
					return result;
				case 24:
					result = _FlightTask.OECM;
					return result;
				case 25:
					result = _FlightTask.AEW;
					return result;
				case 26:
					result = _FlightTask.CommandPost;
					return result;
				case 27:
					result = _FlightTask.ChaffLaying;
					return result;
				case 28:
					result = _FlightTask.SearchAndRescue;
					return result;
				case 29:
					result = _FlightTask.CombatSearchAndRescue;
					return result;
				case 30:
					result = _FlightTask.MineSweeping;
					return result;
				case 31:
					result = _FlightTask.MineRecon;
					return result;
				case 32:
					result = _FlightTask.NavalMineLaying;
					return result;
				case 33:
					result = _FlightTask.ASW;
					return result;
				case 34:
					result = _FlightTask.Forward_Observer;
					return result;
				case 35:
					result = _FlightTask.Area_Surveillance;
					return result;
				case 36:
					result = _FlightTask.Armed_Recon;
					return result;
				case 37:
					result = _FlightTask.Unarmed_Recon;
					return result;
				case 38:
					result = _FlightTask.Maritime_Surveillance;
					return result;
				case 39:
					result = _FlightTask.Paratroopers;
					return result;
				case 40:
					result = _FlightTask.Troop_Transport;
					return result;
				case 41:
					result = _FlightTask.Cargo;
					return result;
				case 42:
					result = _FlightTask.AirRefueling;
					return result;
				case 43:
					result = _FlightTask.Support;
					return result;
				case 44:
					result = _FlightTask.Training;
					return result;
				case 45:
					result = _FlightTask.TargetTow;
					return result;
				case 46:
					result = _FlightTask.TargetDrone;
					return result;
				case 47:
					result = _FlightTask.Ferry;
					return result;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101297", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static int Task_To_TaskSelection(int TaskValue)
		{
			int result = default(int);
			try
			{
				int num;
				switch (TaskValue)
				{
				default:
					num = 0;
					goto IL_0206;
				case 1:
					result = 0;
					return result;
				case 2:
					result = 4;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 3;
					return result;
				case 5:
					result = 15;
					return result;
				case 6:
					result = 16;
					return result;
				case 7:
					result = 5;
					return result;
				case 8:
					result = 6;
					return result;
				case 9:
					result = 8;
					return result;
				case 10:
					result = 10;
					return result;
				case 11:
					result = 9;
					return result;
				case 12:
					result = 13;
					return result;
				case 13:
					result = 14;
					return result;
				case 14:
					result = 19;
					return result;
				case 15:
					result = 18;
					return result;
				case 16:
					result = 20;
					return result;
				case 17:
					result = 22;
					return result;
				case 18:
					result = 23;
					return result;
				case 19:
					result = 7;
					return result;
				case 20:
					result = 24;
					return result;
				case 21:
					result = 25;
					return result;
				case 22:
					result = 26;
					return result;
				case 23:
					result = 27;
					return result;
				case 24:
					result = 28;
					return result;
				case 25:
					result = 29;
					return result;
				case 26:
					result = 30;
					return result;
				case 27:
					result = 31;
					return result;
				case 28:
					result = 32;
					return result;
				case 29:
					result = 33;
					return result;
				case 30:
					result = 34;
					return result;
				case 31:
					result = 35;
					return result;
				case 32:
					result = 36;
					return result;
				case 33:
					result = 37;
					return result;
				case 34:
					result = 38;
					return result;
				case 35:
					result = 39;
					return result;
				case 36:
					result = 40;
					return result;
				case 37:
					result = 41;
					return result;
				case 38:
					result = 42;
					return result;
				case 39:
					result = 44;
					return result;
				case 40:
					result = 45;
					return result;
				case 41:
					result = 46;
					return result;
				case 42:
					result = 47;
					return result;
				case 43:
					num = 0;
					goto IL_0206;
				case 44:
					result = 11;
					return result;
				case 45:
					result = 12;
					return result;
				case 46:
					result = 2;
					return result;
				case 47:
					result = 43;
					return result;
				case 48:
					result = 21;
					return result;
				case 49:
					{
						result = 17;
						return result;
					}
					IL_0206:
					result = num;
					return result;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101307", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static void ComboBoxDataSource_Priority(ref DataTable theComboBoxDataSource_Priority)
		{
			if (!theComboBoxDataSource_Priority.Columns.Contains("ID"))
			{
				theComboBoxDataSource_Priority.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource_Priority.Columns.Contains("Description"))
			{
				theComboBoxDataSource_Priority.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource_Priority.Rows.Add(0, Mission.get_FlightPriorityString(_FlightPriority.Mandatory));
			theComboBoxDataSource_Priority.Rows.Add(1, Mission.get_FlightPriorityString(_FlightPriority.None));
		}

		public static _FlightPriority PrioritySelection_To_Priority(int Priority)
		{
			_FlightPriority result;
			try
			{
				result = Priority switch
				{
					0 => _FlightPriority.Mandatory, 
					1 => _FlightPriority.None, 
					_ => _FlightPriority.None, 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101298", "");
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
				result = (_FlightPriority)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static int Priority_To_PrioritySelection(int Priority)
		{
			int result;
			try
			{
				result = Priority switch
				{
					1 => 0, 
					0 => 1, 
					_ => 1, 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101308", "");
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
				result = num;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static void Combobox_AttackMethod(ref ComboBox combobox, ref DataTable theComboBoxDataSource, _AttackMethod theAttackMethod)
		{
			if (!theComboBoxDataSource.Columns.Contains("ID"))
			{
				theComboBoxDataSource.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource.Columns.Contains("Description"))
			{
				theComboBoxDataSource.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource.Rows.Add(0, "Formation, single-aim");
			theComboBoxDataSource.Rows.Add(1, "Formation, independent aim");
			theComboBoxDataSource.Rows.Add(2, "Split at Action Point using time deconfliction, independent aim");
			theComboBoxDataSource.Rows.Add(3, "Echelon at Action Point using time deconfliction, independent aim");
			ComboBox val = combobox;
			((ListControl)val).DisplayMember = "Description";
			((ListControl)val).ValueMember = "ID";
			val.DataSource = theComboBoxDataSource;
			switch (theAttackMethod)
			{
			case _AttackMethod.Formation_IndependentAim:
				val.SelectedIndex = 1;
				break;
			case _AttackMethod.SplitAtActionPoint:
				val.SelectedIndex = 2;
				break;
			case _AttackMethod.EchelonAtActionPoint:
				val.SelectedIndex = 3;
				break;
			default:
				val.SelectedIndex = 0;
				break;
			case _AttackMethod.Formation_SingleAim:
				val.SelectedIndex = 0;
				break;
			}
			val = null;
		}

		public static void Combobox_AttackMethod(ref int theSelectedIndex, ref _AttackMethod theAttackMethod)
		{
			switch (theSelectedIndex)
			{
			default:
				theAttackMethod = _AttackMethod.Formation_SingleAim;
				break;
			case 0:
				theAttackMethod = _AttackMethod.Formation_SingleAim;
				break;
			case 1:
				theAttackMethod = _AttackMethod.Formation_IndependentAim;
				break;
			case 2:
				theAttackMethod = _AttackMethod.SplitAtActionPoint;
				break;
			case 3:
				theAttackMethod = _AttackMethod.EchelonAtActionPoint;
				break;
			}
		}

		public static void Combobox_FlightSize(ref ComboBox combobox, ref DataTable theComboBoxDataSource, _FlightSize theFlightSizeSetting)
		{
			if (!theComboBoxDataSource.Columns.Contains("ID"))
			{
				theComboBoxDataSource.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource.Columns.Contains("Description"))
			{
				theComboBoxDataSource.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource.Rows.Add(0, Mission.get_FlightSizeString((_FlightSize)1));
			theComboBoxDataSource.Rows.Add(1, Mission.get_FlightSizeString((_FlightSize)2));
			theComboBoxDataSource.Rows.Add(2, Mission.get_FlightSizeString((_FlightSize)3));
			theComboBoxDataSource.Rows.Add(3, Mission.get_FlightSizeString((_FlightSize)4));
			theComboBoxDataSource.Rows.Add(4, Mission.get_FlightSizeString((_FlightSize)6));
			ComboBox val = combobox;
			((ListControl)val).DisplayMember = "Description";
			((ListControl)val).ValueMember = "ID";
			val.DataSource = theComboBoxDataSource;
			if (theFlightSizeSetting == 1)
			{
				val.SelectedIndex = 0;
			}
			else if (theFlightSizeSetting == 2)
			{
				val.SelectedIndex = 1;
			}
			else if (!(theFlightSizeSetting == 3))
			{
				if (!(theFlightSizeSetting == 4))
				{
					if (theFlightSizeSetting == 6)
					{
						val.SelectedIndex = 4;
					}
				}
				else
				{
					val.SelectedIndex = 3;
				}
			}
			else
			{
				val.SelectedIndex = 2;
			}
			val = null;
		}

		public static void Combobox_GroupSize(ref ComboBox combobox, ref DataTable theComboBoxDataSource, _GroupSize theGroupSizeSetting)
		{
			if (!theComboBoxDataSource.Columns.Contains("ID"))
			{
				theComboBoxDataSource.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource.Columns.Contains("Description"))
			{
				theComboBoxDataSource.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource.Rows.Add(0, Mission.get_GroupSizeString((_GroupSize)1));
			theComboBoxDataSource.Rows.Add(1, Mission.get_GroupSizeString((_GroupSize)2));
			theComboBoxDataSource.Rows.Add(2, Mission.get_GroupSizeString((_GroupSize)3));
			theComboBoxDataSource.Rows.Add(3, Mission.get_GroupSizeString((_GroupSize)4));
			theComboBoxDataSource.Rows.Add(4, Mission.get_GroupSizeString((_GroupSize)6));
			ComboBox val = combobox;
			((ListControl)val).DisplayMember = "Description";
			((ListControl)val).ValueMember = "ID";
			val.DataSource = theComboBoxDataSource;
			if (theGroupSizeSetting == 1)
			{
				val.SelectedIndex = 0;
			}
			else if (theGroupSizeSetting == 2)
			{
				val.SelectedIndex = 1;
			}
			else if (theGroupSizeSetting == 3)
			{
				val.SelectedIndex = 2;
			}
			else if (theGroupSizeSetting == 4)
			{
				val.SelectedIndex = 3;
			}
			else if (theGroupSizeSetting == 6)
			{
				val.SelectedIndex = 4;
			}
			val = null;
		}

		public static void Combobox_FlightSize_NonShooter(ref ComboBox combobox, ref DataTable theComboBoxDataSource, _FlightSize theFlightSizeSetting)
		{
			if (!theComboBoxDataSource.Columns.Contains("ID"))
			{
				theComboBoxDataSource.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource.Columns.Contains("Description"))
			{
				theComboBoxDataSource.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource.Rows.Add(0, "Use same settings as fighters and SEAD");
			theComboBoxDataSource.Rows.Add(1, "Single aircraft, typical for EW, AEW and recon");
			ComboBox val = combobox;
			((ListControl)val).DisplayMember = "Description";
			((ListControl)val).ValueMember = "ID";
			val.DataSource = theComboBoxDataSource;
			if (theFlightSizeSetting == 0)
			{
				val.SelectedIndex = 0;
			}
			else if (theFlightSizeSetting == 1)
			{
				val.SelectedIndex = 1;
			}
			val = null;
		}

		public static void ComboBox_FlightSize_DataSource(ref DataTable theComboBoxDataSource_AircraftQty)
		{
			if (!theComboBoxDataSource_AircraftQty.Columns.Contains("ID"))
			{
				theComboBoxDataSource_AircraftQty.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource_AircraftQty.Columns.Contains("Description"))
			{
				theComboBoxDataSource_AircraftQty.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource_AircraftQty.Rows.Add(0, Mission.get_FlightSizeString((_FlightSize)1));
			theComboBoxDataSource_AircraftQty.Rows.Add(1, Mission.get_FlightSizeString((_FlightSize)2));
			theComboBoxDataSource_AircraftQty.Rows.Add(2, Mission.get_FlightSizeString((_FlightSize)3));
			theComboBoxDataSource_AircraftQty.Rows.Add(3, Mission.get_FlightSizeString((_FlightSize)4));
			theComboBoxDataSource_AircraftQty.Rows.Add(4, Mission.get_FlightSizeString((_FlightSize)6));
		}

		public static _FlightSize AircraftQtySelection_To_AircraftQty(int AircraftQty)
		{
			_FlightSize result;
			try
			{
				result = AircraftQty switch
				{
					0 => 1, 
					1 => 2, 
					2 => 3, 
					3 => 4, 
					4 => 6, 
					_ => 1, 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101299", "");
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
				result = num;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static int AircraftQty_To_AircraftQtySelection(int AircraftQty)
		{
			int result;
			try
			{
				int num;
				switch (AircraftQty)
				{
				default:
					num = 0;
					goto IL_0037;
				case 1:
					result = 0;
					break;
				case 2:
					result = 1;
					break;
				case 3:
					result = 2;
					break;
				case 4:
					result = 3;
					break;
				case 5:
					num = 0;
					goto IL_0037;
				case 6:
					{
						result = 4;
						break;
					}
					IL_0037:
					result = num;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101310", "");
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
				result = num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static void ComboBoxDataSource_Type(ref DataTable theComboBoxDataSource_Type)
		{
			if (!theComboBoxDataSource_Type.Columns.Contains("ID"))
			{
				theComboBoxDataSource_Type.Columns.Add("ID", typeof(int));
			}
			if (!theComboBoxDataSource_Type.Columns.Contains("Description"))
			{
				theComboBoxDataSource_Type.Columns.Add("Description", typeof(string));
			}
			theComboBoxDataSource_Type.Rows.Add(0, Mission.get_FlightTypeString(_FlightType.Flightplan));
			theComboBoxDataSource_Type.Rows.Add(1, Mission.get_FlightTypeString(_FlightType.FlightplanTemplate));
		}

		public static _FlightType TypeSelection_To_Type(int TypeValue)
		{
			_FlightType result;
			try
			{
				result = TypeValue switch
				{
					0 => _FlightType.Flightplan, 
					1 => _FlightType.FlightplanTemplate, 
					_ => _FlightType.Flightplan, 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 101297", "");
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
				result = (_FlightType)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static int Type_To_TypeSelection(int TypeValue)
		{
			int result;
			try
			{
				result = TypeValue switch
				{
					0 => 0, 
					1 => 1, 
					_ => 0, 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
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
				result = num;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		internal Waypoint RetrieveWaypointBasedOnACRole(FlightElement ACRole, Waypoint.WaypointType WPType)
		{
			Waypoint waypoint = FlightPlan.Where([SpecialName] (Waypoint theWP) => theWP.Type == WPType).FirstOrDefault();
			if (waypoint == null)
			{
				return null;
			}
			Waypoint waypoint2 = default(Waypoint);
			switch (ACRole)
			{
			case FlightElement.LeadElement:
				return waypoint;
			case FlightElement.LeadElementWingman:
				waypoint2 = waypoint.Waypoint_LeadElementWingman;
				break;
			case FlightElement.SecondElement:
				waypoint2 = waypoint.Waypoint_SecondElement;
				break;
			case FlightElement.SecondElementWingman:
				waypoint2 = waypoint.Waypoint_SecondElementWingman;
				break;
			case FlightElement.ThirdElement:
				waypoint2 = waypoint.Waypoint_ThirdElement;
				break;
			case FlightElement.ThirdElementWingman:
				waypoint2 = waypoint.Waypoint_ThirdElementWingman;
				break;
			}
			if (waypoint2 == null)
			{
				return waypoint;
			}
			return waypoint2;
		}

		static Flight()
		{
			Class72.smethod_20();
		}
	}

	public sealed class MissionAircraftEntry
	{
		public string HostUnitObjectID;

		public string HostUnitObjectName;

		public int AircraftDBID;

		public string AircraftName;

		public int int_0;

		public string LoadoutName;

		public bool IsMultiMission;

		public MissionAircraftEntry(string theHostUnitObjectID, string theHostUnitObjectName, int theAircraftDBID, string theAircraftName, int theLoadoutDBID, string theLoadoutName, bool _IsMultiMission = false)
		{
			HostUnitObjectID = theHostUnitObjectID;
			HostUnitObjectName = theHostUnitObjectName;
			AircraftDBID = theAircraftDBID;
			AircraftName = theAircraftName;
			int_0 = theLoadoutDBID;
			LoadoutName = theLoadoutName;
			IsMultiMission = _IsMultiMission;
		}

		static MissionAircraftEntry()
		{
			Class72.smethod_20();
		}
	}

	public sealed class ContinousCoverageStation
	{
		public string FlightObjectID;

		public int AircraftDBID;

		public int int_0;

		public string HostUnitObjectID;

		public DateTime? StationStartTime;

		public DateTime? StationEndTime;

		public string FlightplanTemplateObjectID;

		public ContinousCoverageStation(string theFlightObjectID, int theAircraftDBID, int theLoadoutDBID, string theHostUnitObjectID, DateTime? theStationStartTime, DateTime? theStationEndTime, string theFlightplanTemplateObjectID)
		{
			FlightObjectID = theFlightObjectID;
			AircraftDBID = theAircraftDBID;
			int_0 = theLoadoutDBID;
			HostUnitObjectID = theHostUnitObjectID;
			StationStartTime = theStationStartTime;
			StationEndTime = theStationEndTime;
			FlightplanTemplateObjectID = theFlightplanTemplateObjectID;
		}

		public ContinousCoverageStation()
		{
		}

		public static void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen, ref List<ContinousCoverageStation> ContinousCoverageStationsList)
		{
			try
			{
				foreach (ContinousCoverageStation ContinousCoverageStations in ContinousCoverageStationsList)
				{
					theWriter.WriteStartElement("CCS");
					theWriter.WriteElementString("FlightObjectID", ContinousCoverageStations.FlightObjectID);
					theWriter.WriteElementString("AircraftDBID", ContinousCoverageStations.AircraftDBID.ToString());
					theWriter.WriteElementString("LoadoutDBID", ContinousCoverageStations.int_0.ToString());
					theWriter.WriteElementString("HostUnitObjectID", ContinousCoverageStations.HostUnitObjectID);
					if (ContinousCoverageStations.StationStartTime.HasValue)
					{
						theWriter.WriteElementString("StationStartTime", ContinousCoverageStations.StationStartTime.Value.ToBinary().ToString());
					}
					if (ContinousCoverageStations.StationEndTime.HasValue)
					{
						theWriter.WriteElementString("StationEndTime", ContinousCoverageStations.StationEndTime.Value.ToBinary().ToString());
					}
					theWriter.WriteElementString("FlightplanTemplateObjectID", ContinousCoverageStations.FlightplanTemplateObjectID);
					theWriter.WriteEndElement();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static List<ContinousCoverageStation> FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			List<ContinousCoverageStation> result;
			try
			{
				List<ContinousCoverageStation> list = new List<ContinousCoverageStation>();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					string name = val.Name;
					if (Operators.CompareString(name, "CCS", false) != 0)
					{
						continue;
					}
					ContinousCoverageStation continousCoverageStation = new ContinousCoverageStation();
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						switch (val2.Name)
						{
						case "LoadoutDBID":
							continousCoverageStation.int_0 = Conversions.ToInteger(val2.InnerText);
							break;
						case "FlightObjectID":
							continousCoverageStation.FlightObjectID = val2.InnerText;
							break;
						case "StationEndTime":
						{
							DateTime value2 = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							continousCoverageStation.StationEndTime = value2;
							break;
						}
						case "FlightplanTemplateObjectID":
							continousCoverageStation.FlightplanTemplateObjectID = val2.InnerText;
							break;
						case "StationStartTime":
						{
							DateTime value = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
							continousCoverageStation.StationStartTime = value;
							break;
						}
						case "HostUnitObjectID":
							continousCoverageStation.HostUnitObjectID = val2.InnerText;
							break;
						case "AircraftDBID":
							continousCoverageStation.AircraftDBID = Conversions.ToInteger(val2.InnerText);
							break;
						}
					}
					list.Add(continousCoverageStation);
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<ContinousCoverageStation>();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		static ContinousCoverageStation()
		{
			Class72.smethod_20();
		}
	}

	public sealed class EmptyAircraftSlot
	{
		private ActiveUnit activeUnit_0;

		public int ReferenceUnit_DBID;

		public string ReferenceUnit_UnitClass;

		public int int_0;

		public string LoadoutName;

		public bool Loadout_ExcludeOptionalWeapons;

		public bool Loadout_QuickTurnaround;

		public int Loadout_QuickTurnaround_NumberOfSorties;

		public int Loadout_QuickTurnaround_MaxSorties;

		private Flight flight_0;

		public string MissionFlight_ObjectID;

		private ActiveUnit activeUnit_1;

		public string CurrentHostUnit_ObjectID;

		public string CurrentHostUnit_Name;

		public int NumberOfUnits;

		public bool IsEscort;

		public ActiveUnit ReferenceUnit
		{
			get
			{
				if (Information.IsNothing((object)activeUnit_0) && ReferenceUnit_DBID > 0)
				{
					foreach (ActiveUnit value in theScen.ActiveUnits.Values)
					{
						if (value.IsAircraft && value.DBID == ReferenceUnit_DBID)
						{
							Aircraft aircraft = (Aircraft)value;
							if (!Information.IsNothing((object)aircraft.Loadout) && aircraft.Loadout.DBID == int_0 && !Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit) && (Information.IsNothing((object)activeUnit_1) || aircraft.AirOps.CurrentHostUnit == activeUnit_1) && !Information.IsNothing((object)value.AssignedTaskPool) && value.AssignedTaskPool == theTaskPool)
							{
								activeUnit_0 = value;
								break;
							}
						}
					}
				}
				return activeUnit_0;
			}
			set
			{
				activeUnit_0 = value;
				if (value != null)
				{
					ReferenceUnit_DBID = activeUnit_0.DBID;
					ReferenceUnit_UnitClass = activeUnit_0.UnitClass;
				}
			}
		}

		public ActiveUnit CurrentHostUnit
		{
			get
			{
				if (Information.IsNothing((object)activeUnit_1) && !string.IsNullOrEmpty(CurrentHostUnit_ObjectID))
				{
					foreach (ActiveUnit value in theScen.ActiveUnits.Values)
					{
						if (Operators.CompareString(value.ObjectID, CurrentHostUnit_ObjectID, false) == 0)
						{
							activeUnit_1 = value;
							break;
						}
					}
				}
				return activeUnit_1;
			}
			set
			{
				activeUnit_1 = value;
			}
		}

		public Flight MissionFlight
		{
			get
			{
				if (Information.IsNothing((object)flight_0) && !string.IsNullOrEmpty(MissionFlight_ObjectID))
				{
					bool flag = false;
					Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						foreach (Mission mission in side.Missions)
						{
							if (mission.HasFlights())
							{
								foreach (Flight flight in mission.FlightList)
								{
									if (Operators.CompareString(flight.ObjectID, MissionFlight_ObjectID, false) == 0)
									{
										flight_0 = flight;
										flag = true;
										break;
									}
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				return flight_0;
			}
			set
			{
				flight_0 = value;
				if (value != null)
				{
					MissionFlight_ObjectID = flight_0.ObjectID;
				}
			}
		}

		public EmptyAircraftSlot()
		{
			Loadout_ExcludeOptionalWeapons = false;
		}

		public EmptyAircraftSlot(ActiveUnit theReferenceUnit, int theDBID, string theUnitClass, int theLoadoutDBID, string theLoadoutName, ref ActiveUnit theCurrentHostUnit, string theCurrentHostUnit_ObjectID, string theCurrentHostUnit_Name, bool theIsEscort)
		{
			Loadout_ExcludeOptionalWeapons = false;
			activeUnit_0 = theReferenceUnit;
			ReferenceUnit_DBID = theDBID;
			ReferenceUnit_UnitClass = theUnitClass;
			int_0 = theLoadoutDBID;
			LoadoutName = theLoadoutName;
			IsEscort = theIsEscort;
			activeUnit_1 = theCurrentHostUnit;
			CurrentHostUnit_ObjectID = theCurrentHostUnit_ObjectID;
			CurrentHostUnit_Name = theCurrentHostUnit_Name;
		}

		public void Clear()
		{
			activeUnit_0 = null;
			flight_0 = null;
			activeUnit_1 = null;
		}

		public static void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen, ref List<EmptyAircraftSlot> EmptyAircraftSlotsList)
		{
			try
			{
				theWriter.WriteStartElement("EmptySlotsList");
				foreach (EmptyAircraftSlot EmptyAircraftSlots in EmptyAircraftSlotsList)
				{
					theWriter.WriteStartElement("EmptySlot");
					theWriter.WriteElementString("DBID", EmptyAircraftSlots.ReferenceUnit_DBID.ToString());
					if (!Information.IsNothing((object)EmptyAircraftSlots.ReferenceUnit_UnitClass))
					{
						theWriter.WriteElementString("UnitClass", EmptyAircraftSlots.ReferenceUnit_UnitClass.ToString());
					}
					else
					{
						theWriter.WriteElementString("UnitClass", "Any type");
					}
					theWriter.WriteElementString("LoadoutDBID", EmptyAircraftSlots.int_0.ToString());
					theWriter.WriteElementString("LoadoutName", EmptyAircraftSlots.LoadoutName.ToString());
					theWriter.WriteElementString("Loadout_ExcludeOptionalWeapons", EmptyAircraftSlots.Loadout_ExcludeOptionalWeapons.ToString());
					theWriter.WriteElementString("Loadout_QuickTurnaround", EmptyAircraftSlots.Loadout_QuickTurnaround.ToString());
					theWriter.WriteElementString("Loadout_QuickTurnaround_NumberOfSorties", EmptyAircraftSlots.Loadout_QuickTurnaround_NumberOfSorties.ToString());
					theWriter.WriteElementString("Loadout_QuickTurnaround_MaxSorties", EmptyAircraftSlots.Loadout_QuickTurnaround_MaxSorties.ToString());
					theWriter.WriteElementString("CurrentHostUnit_ObjectID", EmptyAircraftSlots.CurrentHostUnit_ObjectID.ToString());
					theWriter.WriteElementString("CurrentHostUnit_Name", EmptyAircraftSlots.CurrentHostUnit_Name.ToString());
					theWriter.WriteElementString("IsEscort", EmptyAircraftSlots.IsEscort.ToString());
					if (!string.IsNullOrEmpty(EmptyAircraftSlots.MissionFlight_ObjectID))
					{
						theWriter.WriteElementString("MissionFlight_ObjectID", EmptyAircraftSlots.MissionFlight_ObjectID.ToString());
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 200646", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static List<EmptyAircraftSlot> FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			List<EmptyAircraftSlot> result;
			try
			{
				List<EmptyAircraftSlot> list = new List<EmptyAircraftSlot>();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					string name = val.Name;
					if (Operators.CompareString(name, "EmptySlot", false) != 0)
					{
						continue;
					}
					EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot();
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						switch (val2.Name)
						{
						case "UnitClass":
							emptyAircraftSlot.ReferenceUnit_UnitClass = val2.InnerText;
							break;
						case "Loadout_QuickTurnaround_NumberOfSorties":
							emptyAircraftSlot.Loadout_QuickTurnaround_NumberOfSorties = Conversions.ToInteger(val2.InnerText);
							break;
						case "CurrentHostUnit_Name":
							emptyAircraftSlot.CurrentHostUnit_Name = val2.InnerText;
							break;
						case "CurrentHostUnit_ObjectID":
							emptyAircraftSlot.CurrentHostUnit_ObjectID = val2.InnerText;
							break;
						case "LoadoutDBID":
							emptyAircraftSlot.int_0 = Conversions.ToInteger(val2.InnerText);
							break;
						case "LoadoutName":
							emptyAircraftSlot.LoadoutName = val2.InnerText;
							break;
						case "MissionFlight_ObjectID":
							emptyAircraftSlot.MissionFlight_ObjectID = val2.InnerText;
							break;
						case "Loadout_ExcludeOptionalWeapons":
							emptyAircraftSlot.Loadout_ExcludeOptionalWeapons = Conversions.ToBoolean(val2.InnerText);
							break;
						case "Loadout_QuickTurnaround_MaxSorties":
							emptyAircraftSlot.Loadout_QuickTurnaround_MaxSorties = Conversions.ToInteger(val2.InnerText);
							break;
						case "Loadout_QuickTurnaround":
							emptyAircraftSlot.Loadout_QuickTurnaround = Conversions.ToBoolean(val2.InnerText);
							break;
						case "DBID":
							emptyAircraftSlot.ReferenceUnit_DBID = Conversions.ToInteger(val2.InnerText);
							break;
						case "IsEscort":
							emptyAircraftSlot.IsEscort = Conversions.ToBoolean(val2.InnerText);
							break;
						}
					}
					list.Add(emptyAircraftSlot);
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 200647", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<EmptyAircraftSlot>();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public void SetFlight(Scenario theScen, Flight theFlight, int theFlightMemberNumber)
		{
			this.set_MissionFlight(theScen, theFlight);
		}

		static EmptyAircraftSlot()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TargeteeringEntry
	{
		public string ObjectID;

		public int Target_Type;

		public string Target_Description;

		public string Target_ContactObjectID;

		public string Target_ActualUnitObjectID;

		public int Target_ActualUnitDBID;

		public double Target_Latitude;

		public double Target_Longitude;

		public GeoPoint Target_PreliminaryPoint;

		public List<GeoPoint> Target_Area;

		public TargeteeringEntry()
		{
		}

		public TargeteeringEntry(string theObjectID, int theTarget_Type, string theTarget_Description, string theTarget_ContactObjectID, string theTarget_ActualUnitObjecttID, int theTarget_ActualUnitDBID, double theTarget_Latitude, double theTarget_Longitude, GeoPoint theTarget_PreliminaryPoint, GeoPoint theTarget_Point, List<GeoPoint> theTarget_Area)
		{
			ObjectID = theObjectID;
			Target_Type = theTarget_Type;
			Target_Description = theTarget_Description;
			Target_ContactObjectID = theTarget_ContactObjectID;
			Target_ActualUnitObjectID = theTarget_ActualUnitObjecttID;
			Target_ActualUnitDBID = theTarget_ActualUnitDBID;
			Target_Latitude = theTarget_Latitude;
			Target_Longitude = theTarget_Longitude;
			Target_PreliminaryPoint = theTarget_PreliminaryPoint;
			Target_Area = theTarget_Area;
		}

		public static void ToXML(ref XmlWriter theWriter, ref TargeteeringEntry theEntry)
		{
			try
			{
				theWriter.WriteStartElement("TargeteeringEntry");
				theWriter.WriteElementString("ID", theEntry.ObjectID.ToString());
				theWriter.WriteElementString("Target_Type", theEntry.Target_Type.ToString());
				if (theEntry.Target_Description == null)
				{
					theEntry.Target_Description = "";
				}
				theWriter.WriteElementString("Target_Description", theEntry.Target_Description.ToString());
				theWriter.WriteElementString("Target_ContactObjectID", theEntry.Target_ContactObjectID.ToString());
				theWriter.WriteElementString("Target_ActualUnitObjectID", theEntry.Target_ActualUnitObjectID.ToString());
				theWriter.WriteElementString("Target_ActualUnitDBID", theEntry.Target_ActualUnitDBID.ToString());
				theWriter.WriteElementString("Target_Latitude", XmlConvert.ToString(theEntry.Target_Latitude));
				theWriter.WriteElementString("Target_Longitude", XmlConvert.ToString(theEntry.Target_Longitude));
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static TargeteeringEntry FromXML(ref XmlNode theNode)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			TargeteeringEntry result;
			try
			{
				TargeteeringEntry targeteeringEntry = new TargeteeringEntry();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "Target_Type":
						targeteeringEntry.Target_Type = Conversions.ToInteger(val.InnerText);
						break;
					case "Target_ContactObjectID":
						targeteeringEntry.Target_ContactObjectID = val.InnerText;
						break;
					case "ID":
						targeteeringEntry.ObjectID = val.InnerText;
						break;
					case "Target_Latitude":
						targeteeringEntry.Target_Latitude = XmlConvert.ToDouble(val.InnerText);
						break;
					case "Target_ActualUnitObjectID":
						targeteeringEntry.Target_ActualUnitObjectID = val.InnerText;
						break;
					case "Target_ActualUnitDBID":
						targeteeringEntry.Target_ActualUnitDBID = Conversions.ToInteger(val.InnerText);
						break;
					case "Target_Description":
						targeteeringEntry.Target_Description = val.InnerText;
						break;
					case "Target_Longitude":
						targeteeringEntry.Target_Longitude = XmlConvert.ToDouble(val.InnerText);
						break;
					}
				}
				result = targeteeringEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
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

		static TargeteeringEntry()
		{
			Class72.smethod_20();
		}
	}

	public sealed class WeaponeeringEntry
	{
		public int int_0;

		public Weapon._WeaponType WeaponType;

		public string WeaponName;

		public float WeaponMaxRange;

		public float WeaponMinRange;

		public bool bool_0;

		public string TargeteeringEntryObjectID;

		public int LostTarget;

		public int WeaponQty;

		public int WeaponMaxQty;

		public int FiringRange;

		public Waypoint[] Route;

		public bool IsRouteReference;

		public WeaponeeringEntry()
		{
			IsRouteReference = false;
		}

		public WeaponeeringEntry(int theWeaponDBID, Weapon._WeaponType theWeaponType, string theWeaponName, float theWeaponMaxRange, float theWeaponMinRange, bool theWeaponIsBOLCapable, string theTargeteeringEntryObjectID, int theLostTarget, int theWeaponQty, int theWeaponMaxQty, int theFiringRange, ref Waypoint[] theRoute)
		{
			IsRouteReference = false;
			int_0 = theWeaponDBID;
			WeaponType = theWeaponType;
			WeaponName = theWeaponName;
			WeaponMaxRange = theWeaponMaxRange;
			WeaponMinRange = theWeaponMinRange;
			bool_0 = theWeaponIsBOLCapable;
			TargeteeringEntryObjectID = theTargeteeringEntryObjectID;
			LostTarget = theLostTarget;
			WeaponQty = theWeaponQty;
			WeaponMaxQty = theWeaponMaxQty;
			FiringRange = theFiringRange;
			Route = theRoute;
		}

		public static void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref WeaponeeringEntry theEntry)
		{
			try
			{
				theWriter.WriteStartElement("WeaponeeringEntry");
				theWriter.WriteElementString("WeaponDBID", theEntry.int_0.ToString());
				XmlWriter obj = theWriter;
				int weaponType = (int)theEntry.WeaponType;
				obj.WriteElementString("WeaponType", weaponType.ToString());
				theWriter.WriteElementString("WeaponName", theEntry.WeaponName.ToString());
				theWriter.WriteElementString("WeaponMaxRange", theEntry.WeaponMaxRange.ToString());
				theWriter.WriteElementString("WeaponMinRange", theEntry.WeaponMinRange.ToString());
				theWriter.WriteElementString("WeaponIsBOLCapable", theEntry.bool_0.ToString());
				theWriter.WriteElementString("TargeteeringEntryObjectID", theEntry.TargeteeringEntryObjectID.ToString());
				theWriter.WriteElementString("LostTarget", theEntry.LostTarget.ToString());
				theWriter.WriteElementString("WeaponQty", theEntry.WeaponQty.ToString());
				theWriter.WriteElementString("WeaponMaxQty", theEntry.WeaponMaxQty.ToString());
				theWriter.WriteElementString("FiringRange", theEntry.FiringRange.ToString());
				theWriter.WriteElementString("IsRouteReference", theEntry.IsRouteReference.ToString());
				if (!Information.IsNothing((object)theEntry.Route) && theEntry.Route.Count() > 0)
				{
					theWriter.WriteStartElement("Route");
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(theEntry.Route);
					foreach (Waypoint item in list)
					{
						if (!Information.IsNothing((object)item))
						{
							item.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
						}
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static WeaponeeringEntry FromXML(ref XmlNode theNode, ref Scenario theScen, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Expected O, but got Unknown
			WeaponeeringEntry result;
			try
			{
				WeaponeeringEntry weaponeeringEntry = new WeaponeeringEntry();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "FiringRange":
						weaponeeringEntry.FiringRange = Conversions.ToInteger(val.InnerText);
						break;
					case "WeaponMinRange":
						weaponeeringEntry.WeaponMinRange = Conversions.ToInteger(val.InnerText);
						break;
					case "WeaponMaxQty":
						weaponeeringEntry.WeaponMaxQty = Conversions.ToInteger(val.InnerText);
						break;
					case "IsRouteReference":
						weaponeeringEntry.IsRouteReference = Misc.ParseBool(val.InnerText);
						break;
					case "WeaponType":
						weaponeeringEntry.WeaponType = (Weapon._WeaponType)Conversions.ToShort(val.InnerText);
						break;
					case "WeaponQty":
						weaponeeringEntry.WeaponQty = Conversions.ToInteger(val.InnerText);
						break;
					case "WeaponName":
						weaponeeringEntry.WeaponName = val.InnerText;
						break;
					case "TargeteeringEntryObjectID":
						weaponeeringEntry.TargeteeringEntryObjectID = val.InnerText;
						break;
					case "WeaponMaxRange":
						weaponeeringEntry.WeaponMaxRange = Conversions.ToInteger(val.InnerText);
						break;
					case "Route":
						weaponeeringEntry.Route = new Waypoint[0];
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode theNode2 = childNode2;
							Waypoint theAC = Waypoint.FromXML(ref theNode2, ref theDictionary, theScen);
							ArrayExtensions.Add(ref weaponeeringEntry.Route, theAC);
						}
						break;
					case "WeaponDBID":
						weaponeeringEntry.int_0 = Conversions.ToInteger(val.InnerText);
						break;
					case "WeaponIsBOLCapable":
						weaponeeringEntry.bool_0 = Misc.ParseBool(val.InnerText);
						break;
					case "LostTarget":
						weaponeeringEntry.LostTarget = Conversions.ToInteger(val.InnerText);
						break;
					}
				}
				result = weaponeeringEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 999999", "");
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

		static WeaponeeringEntry()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__162-0
	{
		public Scenario $VB$Local_theScen;

		public _Closure$__162-0(_Closure$__162-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(EmptyAircraftSlot theES)
		{
			int result;
			if (theES.IsEscort && !Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen)))
			{
				if (!Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen).FlightPlan))
				{
					return theES.get_MissionFlight($VB$Local_theScen).FlightPlan.Count() == 0;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		[SpecialName]
		internal string _Lambda$__3(EmptyAircraftSlot theES)
		{
			return theES.get_MissionFlight($VB$Local_theScen).Callsign;
		}

		[SpecialName]
		internal bool _Lambda$__4(EmptyAircraftSlot theES)
		{
			int result;
			if (Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen)))
			{
				result = 0;
			}
			else
			{
				if (!Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen).FlightPlan))
				{
					return theES.get_MissionFlight($VB$Local_theScen).FlightPlan.Count() > 0;
				}
				result = 0;
			}
			return (byte)result != 0;
		}

		[SpecialName]
		internal DateTime? _Lambda$__6(EmptyAircraftSlot theES)
		{
			return theES.get_MissionFlight($VB$Local_theScen).FlightPlan[0].Time_Zulu;
		}

		[SpecialName]
		internal string _Lambda$__7(EmptyAircraftSlot theES)
		{
			return theES.get_MissionFlight($VB$Local_theScen).Callsign;
		}

		[SpecialName]
		internal bool _Lambda$__8(EmptyAircraftSlot theES)
		{
			int result;
			if (!theES.IsEscort)
			{
				if (Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen)))
				{
					result = 0;
					goto IL_0051;
				}
				if (!Information.IsNothing((object)theES.get_MissionFlight($VB$Local_theScen).FlightPlan))
				{
					return theES.get_MissionFlight($VB$Local_theScen).FlightPlan.Count() == 0;
				}
			}
			result = 0;
			goto IL_0051;
			IL_0051:
			return (byte)result != 0;
		}

		static _Closure$__162-0()
		{
			Class72.smethod_20();
		}
	}

	public Doctrine Doctrine;

	public MissionCategory Category;

	public _MissionClass MissionClass;

	protected DateTime? _StartTime;

	protected DateTime? _EndTime;

	protected DateTime? _TakeOffTime;

	protected DateTime? _TimeOnTarget;

	public bool ScrubIfSideIsHuman;

	private MissionStatus missionStatus_0;

	public bool UseFlightSizeHardLimit;

	public bool UseGroupSizeHardLimit;

	public int TimeSincePlayerNotification;

	public HashSet<Flight> MasterFlightList;

	public List<Flight> FlightList;

	public bool MultiplayerUpdateNeeded;

	private _FlightSize _FlightSize_0;

	internal bool IsPrivateSnapshot;

	public _GroupSize GroupSize;

	private string string_1;

	public List<EmptyAircraftSlot> EmptySlotsList;

	public bool UseFlightplans;

	public bool UsePreGeneratedFlightplansOnly;

	public bool IncludeInATO;

	public bool FlightPlanPreventShotgunRTB;

	public TankerMethod TankerUsage;

	public List<string> TankerMissions_IDs;

	public List<Mission> TankerMissions;

	public int TankerMinNumber_Total;

	public int TankerMinNumber_Airborne;

	public int TankerMinNumber_Station;

	public bool LaunchMissionWithoutTankersInPlace;

	public bool KeepOnMissionWithoutTankersInPlace;

	public int MaxReceiversInQueuePerTanker_Airborne;

	public int FuelQtyToStartLookingForTanker_Airborne;

	public int TankerMaxDistance_Airborne;

	public bool TankerFollowsReceivers;

	public bool Deactivation_UnassignUnits;

	public bool Deactivation_OrderRTB;

	public bool Deactivation_DeleteMission;

	public OneThirdGroupingType OneThirdGrouping;

	public string _SecondaryAirBaseID;

	public string _SecondaryNavalBaseID;

	public ActiveUnit SecondaryAirBase;

	public ActiveUnit SecondaryNavalBase;

	public List<ActiveUnit> UnitsEngagingInChainsaw;

	public Dictionary<ActiveUnit, ActiveUnit> UnitsQueuedToMission;

	public ConcurrentDictionary<ActiveUnit, ActiveUnit> UnitsAssignedToMission;

	public List<string> UnitsAssignedToMissionIDs;

	public int PriorityWeight;

	public string _OperationName;

	public float Completion;

	public MissionPhase _Phase;

	public MissionCreationType CreationMode;

	public int MissionStartTrigger_Time;

	public bool MissionStartTrigger_Time_Enabled;

	public bool MissionStartTrigger_Time_LastResult;

	public bool MissionStartTrigger_Time_Operator;

	public Dictionary<Mission, Mission> MissionStartTrigger_MissionCompleted;

	public List<string> _MissionStartTrigger_MissionCompletedID;

	public bool MissionStartTrigger_MissionCompleted_Enabled;

	public bool MissionStartTrigger_MissionCompleted_LastResult;

	public bool MissionStartTrigger_MissionCompleted_Operator;

	public string MissionStartTrigger_LUADescription;

	public string MissionStartTrigger_LUA;

	public bool MissionStartTrigger_LUA_Enabled;

	public bool MissionStartTrigger_LUA_LastResult;

	public bool MissionStartTrigger_LUA_Operator;

	public float MissionCompletedTrigger_ElapsedTime;

	public float MissionCompletedTrigger_ElapsedTime_Current;

	public bool MissionCompletedTrigger_ElapsedTime_Enabled;

	public bool MissionCompletedTrigger_ElapsedTime_LastResult;

	public bool MissionCompletedTrigger_ElapsedTime_Operator;

	public string MissionCompletedTrigger_LUADescription;

	public string MissionCompletedTrigger_LUA;

	public bool MissionCompletedTrigger_LUA_Enabled;

	public bool MissionCompletedTrigger_LUA_LastResult;

	public bool MissionCompletedTrigger_LUA_Operator;

	public int EstimatedExecutionTime;

	public LandingPlan LandingPlan;

	public bool MarkedForBulkEdition;

	[CompilerGenerated]
	private static StartTimeChangedEventHandler startTimeChangedEventHandler_0;

	[CompilerGenerated]
	private static EndTimeChangedEventHandler endTimeChangedEventHandler_0;

	[CompilerGenerated]
	private static TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler_0;

	[CompilerGenerated]
	private static TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler_0;

	public _FlightSize FlightSize
	{
		get
		{
			return _FlightSize_0;
		}
		set
		{
			_FlightSize_0 = value;
		}
	}

	public virtual List<ReferencePoint> MainArea => null;

	public string OperationName
	{
		get
		{
			if (!string.IsNullOrEmpty(_OperationName))
			{
				return _OperationName;
			}
			if (LandingPlan != null)
			{
				return LandingPlan.Name;
			}
			return _OperationName;
		}
		set
		{
			_OperationName = value;
		}
	}

	public string TargetCountString
	{
		get
		{
			string text = "";
			if (MissionClass == _MissionClass.Strike)
			{
				text = ((Strike)this).TargetCount.ToString();
			}
			else if (MissionClass == _MissionClass.Escort)
			{
				string escortTargetMissionID = ((EscortMission)this).EscortTargetMissionID;
				IEnumerable<Mission> enumerable = TheSide.Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, escortTargetMissionID, false) == 0);
				if (enumerable != null)
				{
					text = ((Strike)(object)enumerable).TargetCount.ToString();
				}
			}
			switch (text)
			{
			case null:
			case "":
				return "";
			case "1":
				return "[1 Target]";
			default:
				return "[" + text + " Targets]";
			case "0":
				return "[No Targets]";
			}
		}
	}

	public bool AdequateMissionWithNoTargets
	{
		get
		{
			if (!this.get_TargetCountString(TheSide).ToLower().Contains("no target"))
			{
				return false;
			}
			return true;
		}
	}

	public float AverageDistanceToMissionArea
	{
		get
		{
			float result = float.MaxValue;
			switch (MissionClass)
			{
			case _MissionClass.Strike:
			{
				Strike strike = (Strike)this;
				if (strike.TargetCount > 0)
				{
					result = strike.SpecificTargets.First().RangeToUnit_Horiz(HostUnit);
				}
				else if (!strike.RTB_When_Target_Destroyed && theUnit.AI.PrimaryTarget != null)
				{
					result = theUnit.AI.PrimaryTarget.RangeToUnit_Horiz(HostUnit);
				}
				break;
			}
			case _MissionClass.Patrol:
				result = ((Patrol)this).PatrolArea.Select([SpecialName] (ReferencePoint s) => s.RangeToPoint_Horiz(HostUnit.get_Longitude((GlobalVariables.BooleanObject)null), HostUnit.get_Latitude((GlobalVariables.BooleanObject)null))).Average();
				break;
			case _MissionClass.Support:
				result = ((SupportMission)this).NavigationCourse.Select([SpecialName] (ReferencePoint s) => s.RangeToPoint_Horiz(HostUnit.get_Longitude((GlobalVariables.BooleanObject)null), HostUnit.get_Latitude((GlobalVariables.BooleanObject)null))).Average();
				break;
			case _MissionClass.Ferry:
				result = ((FerryMission)this).get_NominalDestinationHost(theUnit.ParentScen).RangeToUnit_Horiz(HostUnit);
				break;
			case _MissionClass.Mining:
				result = ((MiningMission)this).Area.Select([SpecialName] (ReferencePoint s) => s.RangeToPoint_Horiz(HostUnit.get_Longitude((GlobalVariables.BooleanObject)null), HostUnit.get_Latitude((GlobalVariables.BooleanObject)null))).Average();
				break;
			case _MissionClass.MineClearing:
				result = ((MineClearingMission)this).Area.Select([SpecialName] (ReferencePoint s) => s.RangeToPoint_Horiz(HostUnit.get_Longitude((GlobalVariables.BooleanObject)null), HostUnit.get_Latitude((GlobalVariables.BooleanObject)null))).Average();
				break;
			case _MissionClass.Cargo:
			{
				CargoMission cargoMission = (CargoMission)this;
				result = ((cargoMission.DestinationUnit == null) ? cargoMission.Area.Select([SpecialName] (ReferencePoint s) => s.RangeToPoint_Horiz(HostUnit.get_Longitude((GlobalVariables.BooleanObject)null), HostUnit.get_Latitude((GlobalVariables.BooleanObject)null))).Average() : cargoMission.DestinationUnit.RangeToUnit_Horiz(HostUnit));
				break;
			}
			}
			return result;
		}
	}

	public Geopoint_Struct AveragePointToMissionArea
	{
		get
		{
			switch (MissionClass)
			{
			case _MissionClass.Strike:
			{
				Strike strike = (Strike)this;
				if (strike.TargetCount > 0)
				{
					return strike.SpecificTargets.First().Location;
				}
				if (!strike.RTB_When_Target_Destroyed && theUnit.AI.PrimaryTarget != null)
				{
					return theUnit.AI.PrimaryTarget.Location;
				}
				break;
			}
			case _MissionClass.Patrol:
				return Misc.Center(((Patrol)this).PatrolArea);
			case _MissionClass.Support:
				return ((SupportMission)this).NavigationCourse.Select([SpecialName] (ReferencePoint s) => s).First().ToGeopoint_Struct();
			case _MissionClass.Ferry:
				return ((FerryMission)this).get_NominalDestinationHost(theUnit.ParentScen).Location;
			case _MissionClass.Mining:
				return Misc.Center(((MiningMission)this).Area);
			case _MissionClass.MineClearing:
				return Misc.Center(((MineClearingMission)this).Area);
			case _MissionClass.Cargo:
			{
				CargoMission cargoMission = (CargoMission)this;
				if (cargoMission.DestinationUnit != null)
				{
					return cargoMission.DestinationUnit.Location;
				}
				return Misc.Center(cargoMission.Area);
			}
			}
			Geopoint_Struct result = default(Geopoint_Struct);
			return result;
		}
	}

	public MissionPhase Phase
	{
		get
		{
			if (_Phase == MissionPhase.Auto)
			{
				if (Completion == 1f)
				{
					return MissionPhase.Completed;
				}
				if (this.get_Status(theScen) == MissionStatus.Active)
				{
					return MissionPhase.Active;
				}
				if (this.get_Status(theScen) == MissionStatus.Inactive)
				{
					return MissionPhase.OnHold;
				}
				return MissionPhase.None;
			}
			return _Phase;
		}
		set
		{
			if (_Phase == value)
			{
				return;
			}
			_Phase = value;
			TheSide.Operation.PhasesValidation = false;
			if (value != MissionPhase.Active && value != MissionPhase.Completed)
			{
				return;
			}
			if (TheSide.Operation.LHourMission != null && Operators.CompareString(ObjectID, TheSide.Operation.LHourMission.ObjectID, false) == 0)
			{
				if (DateTime.Compare(TheSide.Operation.LHourEffectiveStartTime, DateTime.MinValue) == 0)
				{
					TheSide.Operation.LHourEffectiveStartTime = theScen.Time;
				}
			}
			else if (TheSide.Operation.HHourMission != null && Operators.CompareString(ObjectID, TheSide.Operation.HHourMission.ObjectID, false) == 0 && DateTime.Compare(TheSide.Operation.HHourEffectiveStartTime, DateTime.MinValue) == 0)
			{
				TheSide.Operation.HHourEffectiveStartTime = theScen.Time;
			}
		}
	}

	public MissionStatus Status
	{
		get
		{
			return missionStatus_0;
		}
		set
		{
			try
			{
				bool num = value != missionStatus_0;
				missionStatus_0 = value;
				if (!num)
				{
					return;
				}
				if (value == MissionStatus.Inactive && StartTime.HasValue)
				{
					DateTime? startTime = StartTime;
					DateTime time = theScen.Time;
					if (((!startTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) < 0)) == true)
					{
						if (EndTime.HasValue)
						{
							startTime = EndTime;
							time = theScen.Time;
							if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) >= 0) : ((bool?)null)) == true)
							{
								EndTime_Set(theScen.Time, theScen);
							}
						}
						else
						{
							EndTime_Set(theScen.Time, theScen);
						}
					}
				}
				bool flag = missionStatus_0 == MissionStatus.Inactive && (MissionClass == _MissionClass.Strike || MissionClass == _MissionClass.Patrol);
				ActiveUnit[] array = theScen.ActiveUnits_List.InternalArray();
				foreach (ActiveUnit activeUnit in array)
				{
					if (activeUnit == null || activeUnit.ActiveMissionOrPackage() == null || activeUnit.ActiveMissionOrPackage() != this)
					{
						continue;
					}
					activeUnit.Doctrine.ClearCachedParentDoctrine();
					if (activeUnit.IsOperating())
					{
						if (flag)
						{
							activeUnit.AI.ClearMissionTargets(this);
						}
						activeUnit.AI.EvaluateTargets(0f, IgnoreContacStance: false, Immediately: true);
						activeUnit.AI.EvaluateThreats(theScen.GameResolution);
						activeUnit.AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 100641", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool IsActive => missionStatus_0 == MissionStatus.Active;

	public string ParentTaskPoolID
	{
		get
		{
			if (Category == MissionCategory.Package && string.IsNullOrEmpty(string_1))
			{
				foreach (Mission mission in theSide.Missions)
				{
					if (mission.Category == MissionCategory.TaskPool && ((TaskPool)mission).PackageList.Contains(this))
					{
						string_1 = mission.ObjectID;
						break;
					}
				}
			}
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public bool HasEscortsAssigned
	{
		get
		{
			foreach (ActiveUnit item in Module_Mission.UnitsAssignedToMissionOrPackage(this, theScen))
			{
				if (item.AI.IsEscort)
				{
					return true;
				}
			}
			return false;
		}
	}

	public List<ActiveUnit> UnitsAssignedToTaskPool
	{
		get
		{
			List<ActiveUnit> result;
			try
			{
				int count = theScen.ActiveUnits_List.Count;
				List<ActiveUnit> list = new List<ActiveUnit>();
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit activeUnit = theScen.ActiveUnits_List[i];
					if (activeUnit != null && activeUnit.AssignedTaskPool == this)
					{
						list.Add(activeUnit);
					}
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 200643", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<ActiveUnit>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public DateTime? StartTime => _StartTime;

	public DateTime? EndTime => _EndTime;

	public DateTime? TakeOffTime
	{
		get
		{
			return _TakeOffTime;
		}
		set
		{
			bool flag = false;
			if (Information.IsNothing((object)_TakeOffTime) && value.HasValue)
			{
				flag = true;
			}
			else if (!value.HasValue && !Information.IsNothing((object)_TakeOffTime))
			{
				flag = true;
			}
			else
			{
				DateTime? takeOffTime = _TakeOffTime;
				bool? flag2 = ((takeOffTime.HasValue & value.HasValue) ? new bool?(DateTime.Compare(takeOffTime.GetValueOrDefault(), value.GetValueOrDefault()) == 0) : ((bool?)null));
				if (((!flag2) ?? flag2) == true)
				{
					flag = true;
				}
			}
			if (value.HasValue && MissionClass == _MissionClass.Patrol && ((Patrol)this).MovementStyle == Patrol.PatrolMovementStyle.ChainsawLoop)
			{
				TemporaryChainsawFPCompatibilityHandler(setChainsaw: false);
			}
			_TakeOffTime = value;
			if (flag)
			{
				takeOffTimeChangedEventHandler_0?.Invoke(this);
			}
		}
	}

	public DateTime? TimeOnTarget
	{
		get
		{
			return _TimeOnTarget;
		}
		set
		{
			bool flag = false;
			if (Information.IsNothing((object)_TimeOnTarget) && value.HasValue)
			{
				flag = true;
			}
			else if (!value.HasValue && !Information.IsNothing((object)_TimeOnTarget))
			{
				flag = true;
			}
			else
			{
				DateTime? timeOnTarget = _TimeOnTarget;
				bool? flag2 = ((timeOnTarget.HasValue & value.HasValue) ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), value.GetValueOrDefault()) == 0) : ((bool?)null));
				if (((!flag2) ?? flag2) == true)
				{
					flag = true;
				}
			}
			if (value.HasValue && MissionClass == _MissionClass.Patrol && ((Patrol)this).MovementStyle == Patrol.PatrolMovementStyle.ChainsawLoop)
			{
				TemporaryChainsawFPCompatibilityHandler(setChainsaw: false);
			}
			_TimeOnTarget = value;
			if (flag)
			{
				timeOnTargetChangedEventHandler_0?.Invoke(this);
			}
		}
	}

	public virtual string DescriptionString => "";

	public static string FlightSizeString
	{
		get
		{
			_FlightSize flightSize = theFlightSize;
			if (!(flightSize == 0))
			{
				if (!(flightSize == 1))
				{
					if (flightSize == 2)
					{
						return "Section (2x aircraft), typical for fighters";
					}
					if (!(flightSize == 3))
					{
						if (flightSize == 4)
						{
							return "Two Sections (4x aircraft), typical for attack aircraft";
						}
						if (flightSize == 6)
						{
							return "Three Sections (6x aircraft), for medium/heavy attack aircraft";
						}
						return theFlightSize.value + "x aircraft";
					}
					return "Cell (3x aircraft), typical for bombers";
				}
				return "Single aircraft";
			}
			return "None";
		}
	}

	public static string GroupSizeString
	{
		get
		{
			_GroupSize groupSize = theGroupSize;
			if (!(groupSize == 0))
			{
				if (!(groupSize == 1))
				{
					if (!(groupSize == 2))
					{
						if (!(groupSize == 3))
						{
							if (!(groupSize == 4))
							{
								if (groupSize == 6)
								{
									return "6x vessels";
								}
								return theGroupSize.value + "x vessels";
							}
							return "4x vessels";
						}
						return "3x vessels";
					}
					return "2x vessels";
				}
				return "Single vessel";
			}
			return "None";
		}
	}

	public static string FlightTaskString => theFlightTask switch
	{
		_FlightTask.Strike_Land => "Strike (Land)", 
		_FlightTask.Strike_Naval => "Strike, Maritime (Anti-Ship)", 
		_FlightTask.Strike_OCA => "Strike, OCA (Offensive Counter-Air)", 
		_FlightTask.Strike_SEAD => "Strike, SEAD (Suppression of Enemy Air Defences)", 
		_FlightTask.Sweep_Fighter => "Fighter Sweep (Counter-Air)", 
		_FlightTask.Sweep_SEAD => "SEAD (Suppression of Enemy Air Defences) Sweep", 
		_FlightTask.BAI => "BAI (Battlefield Air Interdiction)", 
		_FlightTask.CAS => "CAS (Close Air Support)", 
		_FlightTask.CAP => "CAP (Combat Air Patrol)", 
		_FlightTask.TARCAP => "TARCAP (Target Combat Air Patrol)", 
		_FlightTask.BARCAP => "BARCAP (Barrier Combat Air Patrol)", 
		_FlightTask.GLI => "GLI (Ground-Launched Intercept)", 
		_FlightTask.DLI => "DLI (Deck-Launched Intercept)", 
		_FlightTask.Escort_FighterSweep => "Escort, Fighter Sweep", 
		_FlightTask.Escort_TARCAP => "Escort, TARCAP", 
		_FlightTask.Escort_SEAD => "Escort, SEAD (Suppression of Enemy Air Defences) Sweep", 
		_FlightTask.ASAT => "ASAT (Anti-Satellite)", 
		_FlightTask.AirborneLaser => "Airborne Laser", 
		_FlightTask.Buddy_Illumination => "Buddy Illumination", 
		_FlightTask.OECM => "OECM (Offensive ECM)", 
		_FlightTask.AEW => "AEW (Airborne Early Warning)", 
		_FlightTask.CommandPost => "Airborne Command Post", 
		_FlightTask.ChaffLaying => "Chaff Laying", 
		_FlightTask.SearchAndRescue => "SAR (Search And Rescue)", 
		_FlightTask.CombatSearchAndRescue => "CSAR (Combat Search And Rescue)", 
		_FlightTask.MineSweeping => "Mine Sweeping", 
		_FlightTask.MineRecon => "Mine Recon", 
		_FlightTask.NavalMineLaying => "Naval Mine Laying", 
		_FlightTask.ASW => "ASW (Anti-Submarine Warfare)", 
		_FlightTask.Forward_Observer => "FAC (Forward Air Controller)", 
		_FlightTask.Area_Surveillance => "Surveillance", 
		_FlightTask.Armed_Recon => "Armed Recon", 
		_FlightTask.Unarmed_Recon => "Unarmed Recon", 
		_FlightTask.Maritime_Surveillance => "Maritime Surveillance", 
		_FlightTask.Paratroopers => "Para Drop", 
		_FlightTask.Troop_Transport => "Troop Transport", 
		_FlightTask.Cargo => "Cargo", 
		_FlightTask.AirRefueling => "Air Refuelling", 
		_FlightTask.Training => "Training", 
		_FlightTask.TargetTow => "Target Tow", 
		_FlightTask.TargetDrone => "Target Drone", 
		_FlightTask.Ferry => "Ferry", 
		_FlightTask.HAVCAP => "HAVCAP (High Value Asset Combat Air Patrol)", 
		_FlightTask.RESCAP => "RESCAP (Rescue Combat Air Patrol)", 
		_FlightTask.Strike_Interdiction => "Strike, Interdiction (attack on logistics and reinforcements)", 
		_FlightTask.Support => "Support", 
		_FlightTask.Escort_Support => "Escort, Support", 
		_FlightTask.QRA => "QRA (Quick Reaction Alert)", 
		_ => "Not Configured", 
	};

	public static string FlightPriorityString
	{
		get
		{
			if (theFlightPriority == _FlightPriority.Mandatory)
			{
				return "Mandatory";
			}
			return "None";
		}
	}

	public static string FlightStatusString => theFlightStatus switch
	{
		_FlightStatus.LookingForAvailableAircraft => "Looking for available aircraft", 
		_FlightStatus.WaitingForPackageActivation => "Waiting for package activation", 
		_FlightStatus.WaitingForAircraftToBecomeReady => "Waiting for package to become ready", 
		_FlightStatus.TakingOff => "Taking off", 
		_FlightStatus.Airborne => "Airborne", 
		_FlightStatus.Completed => "Completed", 
		_FlightStatus.PackageEnded => "Package cancelled", 
		_FlightStatus.Airborne_EgressLeg => "Airborne", 
		_ => "Planning", 
	};

	public static string FlightEditedByString => theFlightEditedBy switch
	{
		_FlightCreatedBy.Player => "Player", 
		_FlightCreatedBy.MissionAI => "Mission AI", 
		_ => "None", 
	};

	public static string TankerFollowsReceiverString => theFlightSize switch
	{
		_TankerFollowsReceiver.UntilFull => "...until receiver is full or reaches waypoint where refuelling is not allowed, whatever comes first.", 
		_TankerFollowsReceiver.Waypoint1 => "...to next waypoint (1x)", 
		_TankerFollowsReceiver.Waypoint2 => "...to waypoint after next (2x)", 
		_TankerFollowsReceiver.Weaypoin3 => "...for three waypoints (3x)", 
		_TankerFollowsReceiver.UntilLandingMarshalWaypoint => "...until the next Landing Marshal waypoint", 
		_TankerFollowsReceiver.UntilStationWaypoint => "...until the next Station waypoint", 
		_TankerFollowsReceiver.UntilHoldWaypoint => "...until the next Hold End waypoint", 
		_ => "None", 
	};

	public static string FlightTypeString => theFlightType switch
	{
		_FlightType.FlightplanTemplate => "Flightplan Template", 
		_FlightType.Flightplan => "Flightplan", 
		_ => "Not Configured", 
	};

	public static event StartTimeChangedEventHandler StartTimeChanged
	{
		[CompilerGenerated]
		add
		{
			StartTimeChangedEventHandler startTimeChangedEventHandler = startTimeChangedEventHandler_0;
			StartTimeChangedEventHandler startTimeChangedEventHandler2;
			do
			{
				startTimeChangedEventHandler2 = startTimeChangedEventHandler;
				StartTimeChangedEventHandler value2 = (StartTimeChangedEventHandler)Delegate.Combine(startTimeChangedEventHandler2, value);
				startTimeChangedEventHandler = Interlocked.CompareExchange(ref startTimeChangedEventHandler_0, value2, startTimeChangedEventHandler2);
			}
			while ((object)startTimeChangedEventHandler != startTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StartTimeChangedEventHandler startTimeChangedEventHandler = startTimeChangedEventHandler_0;
			StartTimeChangedEventHandler startTimeChangedEventHandler2;
			do
			{
				startTimeChangedEventHandler2 = startTimeChangedEventHandler;
				StartTimeChangedEventHandler value2 = (StartTimeChangedEventHandler)Delegate.Remove(startTimeChangedEventHandler2, value);
				startTimeChangedEventHandler = Interlocked.CompareExchange(ref startTimeChangedEventHandler_0, value2, startTimeChangedEventHandler2);
			}
			while ((object)startTimeChangedEventHandler != startTimeChangedEventHandler2);
		}
	}

	public static event EndTimeChangedEventHandler EndTimeChanged
	{
		[CompilerGenerated]
		add
		{
			EndTimeChangedEventHandler endTimeChangedEventHandler = endTimeChangedEventHandler_0;
			EndTimeChangedEventHandler endTimeChangedEventHandler2;
			do
			{
				endTimeChangedEventHandler2 = endTimeChangedEventHandler;
				EndTimeChangedEventHandler value2 = (EndTimeChangedEventHandler)Delegate.Combine(endTimeChangedEventHandler2, value);
				endTimeChangedEventHandler = Interlocked.CompareExchange(ref endTimeChangedEventHandler_0, value2, endTimeChangedEventHandler2);
			}
			while ((object)endTimeChangedEventHandler != endTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EndTimeChangedEventHandler endTimeChangedEventHandler = endTimeChangedEventHandler_0;
			EndTimeChangedEventHandler endTimeChangedEventHandler2;
			do
			{
				endTimeChangedEventHandler2 = endTimeChangedEventHandler;
				EndTimeChangedEventHandler value2 = (EndTimeChangedEventHandler)Delegate.Remove(endTimeChangedEventHandler2, value);
				endTimeChangedEventHandler = Interlocked.CompareExchange(ref endTimeChangedEventHandler_0, value2, endTimeChangedEventHandler2);
			}
			while ((object)endTimeChangedEventHandler != endTimeChangedEventHandler2);
		}
	}

	public static event TakeOffTimeChangedEventHandler TakeOffTimeChanged
	{
		[CompilerGenerated]
		add
		{
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler = takeOffTimeChangedEventHandler_0;
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler2;
			do
			{
				takeOffTimeChangedEventHandler2 = takeOffTimeChangedEventHandler;
				TakeOffTimeChangedEventHandler value2 = (TakeOffTimeChangedEventHandler)Delegate.Combine(takeOffTimeChangedEventHandler2, value);
				takeOffTimeChangedEventHandler = Interlocked.CompareExchange(ref takeOffTimeChangedEventHandler_0, value2, takeOffTimeChangedEventHandler2);
			}
			while ((object)takeOffTimeChangedEventHandler != takeOffTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler = takeOffTimeChangedEventHandler_0;
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler2;
			do
			{
				takeOffTimeChangedEventHandler2 = takeOffTimeChangedEventHandler;
				TakeOffTimeChangedEventHandler value2 = (TakeOffTimeChangedEventHandler)Delegate.Remove(takeOffTimeChangedEventHandler2, value);
				takeOffTimeChangedEventHandler = Interlocked.CompareExchange(ref takeOffTimeChangedEventHandler_0, value2, takeOffTimeChangedEventHandler2);
			}
			while ((object)takeOffTimeChangedEventHandler != takeOffTimeChangedEventHandler2);
		}
	}

	public static event TimeOnTargetChangedEventHandler TimeOnTargetChanged
	{
		[CompilerGenerated]
		add
		{
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler = timeOnTargetChangedEventHandler_0;
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler2;
			do
			{
				timeOnTargetChangedEventHandler2 = timeOnTargetChangedEventHandler;
				TimeOnTargetChangedEventHandler value2 = (TimeOnTargetChangedEventHandler)Delegate.Combine(timeOnTargetChangedEventHandler2, value);
				timeOnTargetChangedEventHandler = Interlocked.CompareExchange(ref timeOnTargetChangedEventHandler_0, value2, timeOnTargetChangedEventHandler2);
			}
			while ((object)timeOnTargetChangedEventHandler != timeOnTargetChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler = timeOnTargetChangedEventHandler_0;
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler2;
			do
			{
				timeOnTargetChangedEventHandler2 = timeOnTargetChangedEventHandler;
				TimeOnTargetChangedEventHandler value2 = (TimeOnTargetChangedEventHandler)Delegate.Remove(timeOnTargetChangedEventHandler2, value);
				timeOnTargetChangedEventHandler = Interlocked.CompareExchange(ref timeOnTargetChangedEventHandler_0, value2, timeOnTargetChangedEventHandler2);
			}
			while ((object)timeOnTargetChangedEventHandler != timeOnTargetChangedEventHandler2);
		}
	}

	public virtual void ReleaseReferences()
	{
		try
		{
			MasterFlightList.Clear();
			UnitsAssignedToMission.Clear();
			UnitsQueuedToMission.Clear();
			TankerMissions = null;
			SecondaryAirBase = null;
			SecondaryNavalBase = null;
			MissionStartTrigger_MissionCompleted.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public bool UsesOneThirdRule()
	{
		int result;
		switch (MissionClass)
		{
		default:
			result = 0;
			goto IL_0043;
		case _MissionClass.Patrol:
			return ((Patrol)this).OneThirdRule;
		case _MissionClass.Support:
			return ((SupportMission)this).OneThirdRule;
		case _MissionClass.Ferry:
			result = 0;
			goto IL_0043;
		case _MissionClass.Mining:
			return ((MiningMission)this).OneThirdRule;
		case _MissionClass.MineClearing:
			{
				return ((MineClearingMission)this).OneThirdRule;
			}
			IL_0043:
			return (byte)result != 0;
		}
	}

	public virtual bool IsFulfilled()
	{
		return false;
	}

	public bool FlightNameAlreadyExists(string FlightName)
	{
		foreach (Flight flight in FlightList)
		{
			if (Operators.CompareString(flight.Callsign, FlightName, false) == 0)
			{
				return true;
			}
		}
		return false;
	}

	public string GetNextAvailableNewFlightName()
	{
		string text = "New Flight";
		int num = 1;
		while (FlightNameAlreadyExists(text))
		{
			text = "New Flight " + num;
			num++;
		}
		return text;
	}

	internal bool EvaluatePhaseCompletedTriggers(Scenario TheScen, Side TheSide)
	{
		if (this.get_Phase(TheScen, TheSide) != MissionPhase.Active)
		{
			return false;
		}
		List<TriggerOperationWrapper> list = new List<TriggerOperationWrapper>();
		if (MissionCompletedTrigger_ElapsedTime_Enabled)
		{
			list.Add(new TriggerOperationWrapper(MissionCompletedTrigger_ElapsedTime_Current > MissionCompletedTrigger_ElapsedTime, MissionCompletedTrigger_ElapsedTime_Operator));
			MissionCompletedTrigger_ElapsedTime_LastResult = list[list.Count - 1].Value;
		}
		int num;
		if (!MissionCompletedTrigger_LUA_Enabled)
		{
			num = 0;
		}
		else if (string.IsNullOrWhiteSpace(MissionCompletedTrigger_LUA))
		{
			num = 0;
		}
		else
		{
			object[] array = TheScen.Scenario_LuaSandbox.RunScript(MissionCompletedTrigger_LUA, RunInteractively: false);
			if (array == null)
			{
				num = 0;
			}
			else if (array[0] == null)
			{
				num = 0;
			}
			else if ((object)array[0].GetType() == typeof(LuaScriptException))
			{
				GameGeneral.SendMessageBoxToUI("ERROR: " + ((LuaScriptException)array[0]).InnerException.Message, TheSide, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
				num = 0;
			}
			else if ((object)array[0].GetType() != typeof(bool))
			{
				GameGeneral.SendMessageBoxToUI("ERROR: the script in mission end trigger MUST return a boolean", TheSide, "Error in the mission end trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
				num = 0;
			}
			else
			{
				list.Add(new TriggerOperationWrapper(Conversions.ToBoolean(array[0]), _ConditionalOperator: true));
				MissionCompletedTrigger_LUA_LastResult = list[list.Count - 1].Value;
				num = 0;
			}
		}
		bool result = (byte)num != 0;
		foreach (TriggerOperationWrapper item in list)
		{
			if (!item.Value)
			{
				if (item.ConditionalOperator)
				{
					return false;
				}
				continue;
			}
			if (item.ConditionalOperator)
			{
				result = true;
				continue;
			}
			return true;
		}
		return result;
	}

	internal int GetChainsawStartingPoint(ActiveUnit myAU)
	{
		int num = 0;
		if (myAU.IsGroup)
		{
			foreach (Flight flight in FlightList)
			{
				if (flight.Departed)
				{
					num = FlightList.IndexOf(myAU.Navigator.get_Flight(HierarchySearch: true));
					if (!UnitsEngagingInChainsaw.Contains(myAU))
					{
						UnitsEngagingInChainsaw.Add(myAU);
					}
				}
			}
		}
		else
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			list = Misc.Values_ToList(UnitsAssignedToMission);
			foreach (ActiveUnit value in UnitsAssignedToMission.Values)
			{
				_ = value;
				num = list.IndexOf(myAU);
				if (!UnitsEngagingInChainsaw.Contains(myAU))
				{
					UnitsEngagingInChainsaw.Add(myAU);
				}
			}
		}
		return Math.Max(0, num % 2);
	}

	internal float GetChainsawSpeedOverwirte(ActiveUnit myUnit)
	{
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit item in UnitsEngagingInChainsaw)
		{
			if (item != myUnit)
			{
				activeUnit = item;
				break;
			}
		}
		float num = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ((Patrol)this).TransitThrottle_Aircraft.Value, ValidateAndFixAltitude: false);
		if (activeUnit != null)
		{
			float val = activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ((Patrol)this).TransitThrottle_Aircraft.Value, ValidateAndFixAltitude: false);
			Math.Min(num, val);
			float num2 = Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.PatrolLoop_NextRefPoint);
			if (activeUnit.Navigator.PatrolLoop_NextRefPoint == null)
			{
				Mission mission = activeUnit.AssignedMissionOrPackage();
				if (mission != null && mission.MissionClass == _MissionClass.Patrol)
				{
					activeUnit.Navigator.PatrolLoop_NextRefPoint = ((Patrol)activeUnit.AssignedMissionOrPackage()).PatrolArea[GetChainsawStartingPoint(activeUnit)];
				}
			}
			if (activeUnit.Navigator.PatrolLoop_NextRefPoint != null)
			{
				float num3 = Module_Unit.RangeToPoint_Horiz(activeUnit, activeUnit.Navigator.PatrolLoop_NextRefPoint);
				float val2 = num2 / num;
				float val3 = num3 / num;
				float num4 = Math.Max(val2, val3);
				return num2 / num4;
			}
			return num;
		}
		return num;
	}

	internal bool CheckIfStillInSync(ActiveUnit myUnit)
	{
		bool result = true;
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit item in UnitsEngagingInChainsaw)
		{
			if (item != myUnit)
			{
				activeUnit = item;
				break;
			}
		}
		if (activeUnit != null && activeUnit.Navigator.PatrolLoop_NextRefPoint == myUnit.Navigator.PatrolLoop_NextRefPoint)
		{
			result = false;
		}
		return result;
	}

	internal bool EvaluatePhaseStartTriggers(Scenario TheScen, Side TheSide)
	{
		if (this.get_Phase(TheScen, TheSide) != MissionPhase.OnHold)
		{
			return false;
		}
		List<TriggerOperationWrapper> list = new List<TriggerOperationWrapper>();
		if (MissionStartTrigger_Time_Enabled && DateTime.Compare(TheSide.Operation.HHourEffectiveStartTime, DateTime.MinValue) != 0)
		{
			list.Add(new TriggerOperationWrapper(DateTime.Compare(TheScen.Time, TheSide.Operation.HHourEffectiveStartTime.AddSeconds(MissionStartTrigger_Time)) > 0, MissionStartTrigger_Time_Operator));
			MissionStartTrigger_Time_LastResult = list[list.Count - 1].Value;
		}
		if (MissionStartTrigger_MissionCompleted_Enabled)
		{
			bool value = true;
			foreach (Mission key in MissionStartTrigger_MissionCompleted.Keys)
			{
				if (key.get_Phase(TheScen, TheSide) != MissionPhase.Completed)
				{
					value = false;
					break;
				}
			}
			list.Add(new TriggerOperationWrapper(value, MissionStartTrigger_MissionCompleted_Operator));
			MissionStartTrigger_MissionCompleted_LastResult = list[list.Count - 1].Value;
		}
		int num;
		if (!MissionStartTrigger_LUA_Enabled)
		{
			num = 0;
		}
		else if (string.IsNullOrWhiteSpace(MissionStartTrigger_LUA))
		{
			num = 0;
		}
		else
		{
			object[] array = TheScen.Scenario_LuaSandbox.RunScript(MissionStartTrigger_LUA, RunInteractively: false);
			if (array != null && array[0] != null)
			{
				if ((object)array[0].GetType() == typeof(LuaScriptException))
				{
					GameGeneral.SendMessageBoxToUI("ERROR: " + ((LuaScriptException)array[0]).InnerException.Message, TheSide, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					num = 0;
				}
				else if ((object)array[0].GetType() != typeof(bool))
				{
					GameGeneral.SendMessageBoxToUI("ERROR: the script in mission start trigger MUST return a boolean", TheSide, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					num = 0;
				}
				else
				{
					list.Add(new TriggerOperationWrapper(Conversions.ToBoolean(array[0]), MissionStartTrigger_LUA_Operator));
					MissionStartTrigger_LUA_LastResult = list[list.Count - 1].Value;
					num = 0;
				}
			}
			else
			{
				num = 0;
			}
		}
		bool result = (byte)num != 0;
		foreach (TriggerOperationWrapper item in list)
		{
			if (!item.Value)
			{
				if (item.ConditionalOperator)
				{
					return false;
				}
				continue;
			}
			if (item.ConditionalOperator)
			{
				result = true;
				continue;
			}
			return true;
		}
		return result;
	}

	public virtual void PrePulseHousekeeping(Scenario theScen)
	{
	}

	public virtual void PostPulseHousekeeping(Scenario theScen)
	{
	}

	internal new virtual void Reinitialize()
	{
		_StartTime = null;
		_EndTime = null;
		_TakeOffTime = null;
		_TimeOnTarget = null;
		missionStatus_0 = MissionStatus.Active;
		LaunchMissionWithoutTankersInPlace = false;
		KeepOnMissionWithoutTankersInPlace = true;
		Deactivation_UnassignUnits = false;
		Deactivation_OrderRTB = false;
		Deactivation_DeleteMission = false;
		ScrubIfSideIsHuman = false;
		UseFlightplans = false;
		UsePreGeneratedFlightplansOnly = false;
		IncludeInATO = false;
		FlightSize = 0;
		GroupSize = 0;
		TankerMissions.Clear();
		TankerMissions_IDs.Clear();
		SecondaryAirBase = null;
		SecondaryNavalBase = null;
		FlightList.Clear();
		if (EmptySlotsList != null)
		{
			EmptySlotsList.Clear();
		}
		MissionStartTrigger_MissionCompleted.Clear();
		_MissionStartTrigger_MissionCompletedID.Clear();
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Mission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			Doctrine.ToXML(ref theWriter, ref theScen);
			if (_StartTime.HasValue)
			{
				theWriter.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				theWriter.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_StartTime.HasValue)
			{
				theWriter.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				theWriter.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			theWriter.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			theWriter.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			theWriter.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			theWriter.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			theWriter.WriteElementString("FlightPlanPreventShotgunRTB", FlightPlanPreventShotgunRTB.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			byte b;
			if (missionStatus_0 != MissionStatus.Active)
			{
				XmlWriter obj = theWriter;
				b = (byte)missionStatus_0;
				obj.WriteElementString("Status", b.ToString());
			}
			XmlWriter obj2 = theWriter;
			b = (byte)TankerUsage;
			obj2.WriteElementString("TankerUsage", b.ToString());
			theWriter.WriteStartElement("TankerMissionList");
			foreach (Mission tankerMission in TankerMissions)
			{
				if (!Information.IsNothing((object)tankerMission))
				{
					theWriter.WriteElementString("ID", tankerMission.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			if (LaunchMissionWithoutTankersInPlace)
			{
				theWriter.WriteElementString("LaunchMissionWithoutTankersInPlace", LaunchMissionWithoutTankersInPlace.ToString());
			}
			theWriter.WriteElementString("KeepOnMissionWithoutTankersInPlace", KeepOnMissionWithoutTankersInPlace.ToString());
			theWriter.WriteElementString("TankerMinNumber_Total", TankerMinNumber_Total.ToString());
			theWriter.WriteElementString("TankerMinNumber_Airborne", TankerMinNumber_Airborne.ToString());
			theWriter.WriteElementString("TankerMinNumber_Station", TankerMinNumber_Station.ToString());
			theWriter.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			theWriter.WriteElementString("FuelQtyToStartLookingForTanker_Airborne", FuelQtyToStartLookingForTanker_Airborne.ToString());
			theWriter.WriteElementString("TankerMaxDistance_Airborne", TankerMaxDistance_Airborne.ToString());
			theWriter.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			theWriter.WriteElementString("FlightSize", ((int)FlightSize).ToString());
			theWriter.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			if (HasFlights())
			{
				Flight.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref FlightList);
			}
			if (!Information.IsNothing((object)EmptySlotsList) && EmptySlotsList.Count > 0)
			{
				EmptyAircraftSlot.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref theScen, ref EmptySlotsList);
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 100639", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void method_0(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		theWriter.WriteElementString("PriorityWeight", PriorityWeight.ToString());
		theWriter.WriteElementString("Completion", Completion.ToString());
		theWriter.WriteElementString("_Phase", ((byte)_Phase).ToString());
		theWriter.WriteElementString("OperationName", OperationName);
		theWriter.WriteElementString("MissionStartTrigger_Time", MissionStartTrigger_Time.ToString());
		theWriter.WriteElementString("MissionStartTrigger_Time_Enabled", MissionStartTrigger_Time_Enabled.ToString());
		theWriter.WriteElementString("MissionStartTrigger_Time_Operator", MissionStartTrigger_Time_Operator.ToString());
		theWriter.WriteStartElement("MissionStartTrigger_MissionCompleted");
		foreach (Mission key in MissionStartTrigger_MissionCompleted.Keys)
		{
			if (!Information.IsNothing((object)key))
			{
				theWriter.WriteElementString("ID", key.ObjectID);
			}
		}
		theWriter.WriteEndElement();
		theWriter.WriteElementString("MissionStartTrigger_MissionCompleted_Enabled", MissionStartTrigger_MissionCompleted_Enabled.ToString());
		theWriter.WriteElementString("MissionStartTrigger_MissionCompleted_Operator", MissionStartTrigger_MissionCompleted_Operator.ToString());
		theWriter.WriteElementString("MissionStartTrigger_LUA", MissionStartTrigger_LUA);
		theWriter.WriteElementString("MissionStartTrigger_LUADescription", MissionStartTrigger_LUADescription);
		theWriter.WriteElementString("MissionStartTrigger_LUA_Enabled", MissionStartTrigger_LUA_Enabled.ToString());
		theWriter.WriteElementString("MissionStartTrigger_LUA_Operator", MissionStartTrigger_LUA_Operator.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_ElapsedTime", MissionCompletedTrigger_ElapsedTime.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_ElapsedTime_Current", MissionCompletedTrigger_ElapsedTime_Current.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_ElapsedTime_Enabled", MissionCompletedTrigger_ElapsedTime_Enabled.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_ElapsedTime_Operator", MissionCompletedTrigger_ElapsedTime_Operator.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_LUA", MissionCompletedTrigger_LUA);
		theWriter.WriteElementString("MissionCompletedTrigger_LUADescription", MissionCompletedTrigger_LUADescription);
		theWriter.WriteElementString("MissionCompletedTrigger_LUA_Enabled", MissionCompletedTrigger_LUA_Enabled.ToString());
		theWriter.WriteElementString("MissionCompletedTrigger_LUA_Operator", MissionCompletedTrigger_LUA_Operator.ToString());
		theWriter.WriteElementString("EstimatedExecutionTime", EstimatedExecutionTime.ToString());
		XmlWriter obj = theWriter;
		int creationMode = (int)CreationMode;
		obj.WriteElementString("CreationMode", creationMode.ToString());
	}

	public static void FromXMLCommon(Mission TheM, XmlNode theChild)
	{
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		switch (theChild.Name)
		{
		case "MissionCompletedTrigger_LUA":
			TheM.MissionCompletedTrigger_LUA = theChild.InnerText;
			break;
		case "MissionStartTrigger_LUA":
			TheM.MissionStartTrigger_LUA = theChild.InnerText;
			break;
		case "MissionCompletedTrigger_ElapsedTime_Current":
			TheM.MissionCompletedTrigger_ElapsedTime_Current = Conversions.ToInteger(theChild.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted_Operator":
			TheM.MissionStartTrigger_MissionCompleted_Operator = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionStartTrigger_Time":
			TheM.MissionStartTrigger_Time = Conversions.ToInteger(theChild.InnerText);
			break;
		case "MissionCompletedTrigger_ElapsedTime_Enabled":
			TheM.MissionCompletedTrigger_ElapsedTime_Enabled = Misc.ParseBool(theChild.InnerText);
			break;
		case "EstimatedExecutionTime":
			TheM.EstimatedExecutionTime = Conversions.ToInteger(theChild.InnerText);
			break;
		case "Deactivation_UnassignUnits":
			TheM.Deactivation_UnassignUnits = Misc.ParseBool(theChild.InnerText);
			break;
		case "CheckBox_OrderRTB":
			TheM.Deactivation_OrderRTB = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionStartTrigger_LUA_Enabled":
			TheM.MissionStartTrigger_LUA_Enabled = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionCompletedTrigger_LUA_Operator":
			TheM.MissionCompletedTrigger_LUA_Operator = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionCompletedTrigger_LUA_Enabled":
			TheM.MissionCompletedTrigger_LUA_Enabled = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionStartTrigger_LUA_Operator":
			TheM.MissionStartTrigger_LUA_Operator = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionCompletedTrigger_ElapsedTime_Operator":
			TheM.MissionCompletedTrigger_ElapsedTime_Operator = Misc.ParseBool(theChild.InnerText);
			break;
		case "_Phase":
			TheM._Phase = (MissionPhase)Conversions.ToInteger(theChild.InnerText);
			break;
		case "PriorityWeight":
			TheM.PriorityWeight = Conversions.ToInteger(theChild.InnerText);
			break;
		case "OperationName":
			TheM.OperationName = theChild.InnerText;
			break;
		case "CreationMode":
			TheM.CreationMode = (MissionCreationType)Conversions.ToInteger(theChild.InnerText);
			break;
		case "CheckBox_DeleteMission":
			TheM.Deactivation_DeleteMission = Misc.ParseBool(theChild.InnerText);
			break;
		case "AssignedUnitsList":
		{
			foreach (XmlNode childNode in theChild.ChildNodes)
			{
				XmlNode val2 = childNode;
				TheM.UnitsAssignedToMissionIDs.Add(val2.InnerText);
			}
			break;
		}
		case "MissionStartTrigger_LUADescription":
			TheM.MissionStartTrigger_LUADescription = theChild.InnerText;
			break;
		case "MissionCompletedTrigger_LUADescription":
			TheM.MissionCompletedTrigger_LUADescription = theChild.InnerText;
			break;
		case "MissionCompletedTrigger_ElapsedTime":
			TheM.MissionCompletedTrigger_ElapsedTime = Conversions.ToInteger(theChild.InnerText);
			break;
		case "MissionStartTrigger_Time_Operator":
			TheM.MissionStartTrigger_Time_Operator = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionStartTrigger_Time_Enabled":
			TheM.MissionStartTrigger_Time_Enabled = Misc.ParseBool(theChild.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted_Enabled":
			TheM.MissionStartTrigger_MissionCompleted_Enabled = Misc.ParseBool(theChild.InnerText);
			break;
		case "Completion":
			TheM.Completion = Conversions.ToSingle(theChild.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted":
		{
			foreach (XmlNode childNode2 in theChild.ChildNodes)
			{
				XmlNode val = childNode2;
				TheM._MissionStartTrigger_MissionCompletedID.Add(val.InnerText);
			}
			break;
		}
		}
	}

	public static Mission FromXML(string theObjectID, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		return (Mission)theDictionary[theObjectID];
	}

	public static Mission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		Mission result;
		try
		{
			result = theNode.Name switch
			{
				"SupportMission" => SupportMission.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"MineClearingMission" => MineClearingMission.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"FireMission" => FireMission.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"MiningMission" => MiningMission.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"Patrol" => Patrol.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"CargoMission" => CargoMission.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"TaskPool" => TaskPool.FromXML(ref theNode, ref theDictionary, ref theScen, existingObject), 
				"FerryMission" => FerryMission.FromXML(ref theNode, ref theDictionary, theScen, existingObject), 
				"Strike" => Strike.FromXML(ref theNode, ref theDictionary, theScen, existingObject), 
				_ => new Patrol(null, theScen, "ERROR", MissionCategory.Mission, null, GlobalVariables.PatrolType.AAW, ValidateArea: false), 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 100640", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Patrol(null, theScen, "ERROR", MissionCategory.Mission, null, GlobalVariables.PatrolType.AAW, ValidateArea: false);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float? DetermineMissionEgressAltitude(ref Aircraft theAircraft, ref bool UseTerrainFollowing)
	{
		float? result;
		switch (MissionClass)
		{
		default:
			result = null;
			break;
		case _MissionClass.Strike:
			if (theAircraft.AI.IsEscort)
			{
				Strike strike = (Strike)this;
				UseTerrainFollowing = strike.Escort_TransitTerrainFollowing;
				return strike.Escort_TransitAltitude;
			}
			if (theAircraft.Loadout == null)
			{
				UseTerrainFollowing = false;
				result = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref UseTerrainFollowing);
			}
			else if (!theAircraft.Loadout.get_MissionProfile(theAircraft.ParentScen).CruiseAtOptimumAltitude)
			{
				UseTerrainFollowing = theAircraft.Loadout.get_MissionProfile(theAircraft.ParentScen).CruiseAltitudeEgressTerrainFollowing;
				result = theAircraft.Loadout.get_MissionProfile(theAircraft.ParentScen).CruiseAltitudeEgress;
			}
			else
			{
				UseTerrainFollowing = false;
				result = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref UseTerrainFollowing);
			}
			break;
		case _MissionClass.Patrol:
		{
			Patrol patrol = (Patrol)this;
			UseTerrainFollowing = patrol.TransitTerrainFollowing_Aircraft;
			return patrol.TransitAltitude_Aircraft;
		}
		case _MissionClass.Support:
		{
			SupportMission supportMission = (SupportMission)this;
			UseTerrainFollowing = supportMission.TransitTerrainFollowing_Aircraft;
			return supportMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.Ferry:
		{
			FerryMission obj = (FerryMission)this;
			UseTerrainFollowing = false;
			return obj.FerryAltitude_Aircraft;
		}
		case _MissionClass.Mining:
		{
			MiningMission miningMission = (MiningMission)this;
			UseTerrainFollowing = miningMission.TransitTerrainFollowing_Aircraft;
			return miningMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.MineClearing:
		{
			MineClearingMission mineClearingMission = (MineClearingMission)this;
			UseTerrainFollowing = mineClearingMission.TransitTerrainFollowing_Aircraft;
			return mineClearingMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.Escort:
		{
			EscortMission escortMission = (EscortMission)this;
			UseTerrainFollowing = escortMission.TransitTerrainFollowing_Aircraft;
			return escortMission.TransitAltitude_Aircraft;
		}
		}
		return result;
	}

	internal ActiveUnit.Throttle? DetermineMissionEgressThrottle(ref Aircraft theAircraft)
	{
		ActiveUnit.Throttle? result;
		switch (MissionClass)
		{
		default:
			result = ActiveUnit.Throttle.FullStop;
			break;
		case _MissionClass.Strike:
			if (theAircraft.AI.IsEscort)
			{
				return ((Strike)this).Escort_TransitThrottle;
			}
			result = ((!Information.IsNothing((object)theAircraft.Loadout)) ? new ActiveUnit.Throttle?(theAircraft.Loadout.get_MissionProfile(theAircraft.ParentScen).CruiseThrottleSettingEgress) : new ActiveUnit.Throttle?(ActiveUnit.Throttle.Cruise));
			break;
		case _MissionClass.Patrol:
			return ((Patrol)this).TransitThrottle_Aircraft;
		case _MissionClass.Support:
			return ((SupportMission)this).TransitThrottle_Aircraft;
		case _MissionClass.Ferry:
			return ((FerryMission)this).FerryThrottle_Aircraft;
		case _MissionClass.Mining:
			return ((MiningMission)this).TransitThrottle_Aircraft;
		case _MissionClass.MineClearing:
			return ((MineClearingMission)this).TransitThrottle_Aircraft;
		case _MissionClass.Escort:
			return ((EscortMission)this).TransitThrottle;
		case _MissionClass.Cargo:
			result = ((CargoMission)this).TransitThrottle_Aircraft;
			break;
		}
		return result;
	}

	public abstract void Printout(StringBuilder PrintoutStringBuilder);

	public void ResetFlightReadyAicraftCount(Scenario theScen, Flight theSpecificFlight)
	{
		try
		{
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(this, theScen).ToList();
			int num = default(int);
			int num2 = default(int);
			if (Information.IsNothing((object)theSpecificFlight))
			{
				for (int i = FlightList.Count - 1; i >= 0; i += -1)
				{
					Flight flight = FlightList[i];
					if (Information.IsNothing((object)flight))
					{
						continue;
					}
					num = 0;
					num2 = 0;
					for (int j = list.Count - 1; j >= 0; j += -1)
					{
						ActiveUnit activeUnit = list[j];
						if (activeUnit == null)
						{
							list.Remove(activeUnit);
							continue;
						}
						if (activeUnit.IsAircraft)
						{
							if (!activeUnit.Navigator.HasFlight || activeUnit.Navigator.get_Flight(HierarchySearch: true) != flight)
							{
								continue;
							}
							num++;
							Aircraft aircraft = (Aircraft)activeUnit;
							if (!activeUnit.IsOperating())
							{
								string ReasonForNot = null;
								if (aircraft.IsAvailableForOps(ref ReasonForNot) != 0 || !aircraft.IsParkedAndReady())
								{
									goto IL_00cc;
								}
							}
							num2++;
							goto IL_00cc;
						}
						list.Remove(activeUnit);
						continue;
						IL_00cc:
						list.Remove(activeUnit);
					}
					flight.ReadyAircraftQty = num2;
				}
				return;
			}
			int num3 = list.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				ActiveUnit activeUnit = list[k];
				if (activeUnit == null || !activeUnit.IsAircraft || !activeUnit.Navigator.HasFlight || activeUnit.Navigator.get_Flight(HierarchySearch: true) != theSpecificFlight)
				{
					continue;
				}
				num++;
				Aircraft aircraft2 = (Aircraft)activeUnit;
				if (!activeUnit.IsOperating())
				{
					string ReasonForNot = null;
					if (aircraft2.IsAvailableForOps(ref ReasonForNot) != 0 || !aircraft2.IsParkedAndReady())
					{
						continue;
					}
				}
				num2++;
			}
			theSpecificFlight.ReadyAircraftQty = num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UnitsAssignedToMission_SeparatedByType(Scenario theScen, ref List<int> theLoadoutsList, ref List<int> theAircraftDBIDs, ref List<Aircraft> theAircraftList, ref List<Aircraft> theAircraftList_AvailableForFlightPlanGenerator, ref List<Aircraft> theAircraftList_AssignedToFlight, ref List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady, ref List<ActiveUnit> theAircraftHostsList, ref int NumberOfAircraft_AirborneOrTakingOff, ref int NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref int NumberOfAircraft_Ready, ref int NumberOfAircraft_Ready_Escorts_Shooter, ref int NumberOfAircraft_Ready_Escorts_NonShooter, ref List<int> theShipSubDBIDs, ref List<ActiveUnit> theShipSubList, ref List<ActiveUnit> theShipSubList_DockedReady, List<ActiveUnit> theShipSubHostsList, ref List<ActiveUnit> TheGroundUnitList, ref List<Aircraft> EmptySlotsReferenceAircraftList, ref List<Aircraft> EmptySlotsReferenceAircraftList_Ready, ref List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight, ref int NumberOfEmptySlots_Ready, ref int NumberOfEmptySlots_Ready_Escorts_Shooter, ref int NumberOfEmptySlots_Ready_Escorts_NonShooter, ref List<Flight> theFlightList_Ready, ref List<Flight> theFlightList_NotReady, ref List<Flight> theFlightList_HasEmptySlots, bool OrderTakeOff, bool IncludeEmptySlots, bool IsContinousCoverage)
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>(theScen.ActiveUnits.Values);
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (activeUnit == null || activeUnit.IsGroup || activeUnit.ActiveMissionOrPackage() != this)
				{
					continue;
				}
				if (!activeUnit.IsAircraft)
				{
					if (!activeUnit.IsShip && !activeUnit.IsSubmarine && (!activeUnit.IsVehicle || !((Vehicle)activeUnit).IsAmphibiousSeaworthy))
					{
						if ((activeUnit.IsFacility || activeUnit.IsVehicle) && TheGroundUnitList != null)
						{
							TheGroundUnitList.Add(activeUnit);
						}
						continue;
					}
					theShipSubList.Add(activeUnit);
					if (!theShipSubDBIDs.Contains(activeUnit.DBID))
					{
						theShipSubDBIDs.Add(activeUnit.DBID);
					}
					if (activeUnit.DockingOps.CurrentHostUnit != null)
					{
						if (!theShipSubHostsList.Contains(activeUnit.DockingOps.CurrentHostUnit))
						{
							theShipSubHostsList.Add(activeUnit.DockingOps.CurrentHostUnit);
						}
						if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
						{
							theShipSubList_DockedReady.Add(activeUnit);
						}
					}
					continue;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				theAircraftList.Add(aircraft);
				if (((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true) != null && !IsContinousCoverage)
				{
					theAircraftList_AssignedToFlight.Add(aircraft);
					string ReasonForNot = null;
					if (aircraft.IsAvailableForOps(ref ReasonForNot) == 0 && aircraft.IsParkedAndReady() && aircraft.Loadout != null)
					{
						theAircraftList_AssignedToFlight_OnGroundReady.Add(aircraft);
						theFlightList_Ready.Add(((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true));
					}
					else
					{
						theFlightList_NotReady.Add(((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true));
					}
					if (aircraft.AI.IsEscort)
					{
						if (aircraft.Loadout.IsSupportOrPatrol)
						{
							NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter++;
						}
						else
						{
							NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter++;
						}
					}
					else
					{
						NumberOfAircraft_AirborneOrTakingOff++;
					}
					continue;
				}
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (!theAircraftDBIDs.Contains(aircraft.DBID))
				{
					theAircraftDBIDs.Add(aircraft.DBID);
				}
				if (IsContinousCoverage)
				{
					string ReasonForNot = null;
					if (aircraft.IsAvailableForOps(ref ReasonForNot) != 0)
					{
						continue;
					}
					if (airOps.CurrentHostUnit != null)
					{
						if (!theAircraftHostsList.Contains(airOps.CurrentHostUnit))
						{
							theAircraftHostsList.Add(airOps.CurrentHostUnit);
						}
					}
					else if (airOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !theAircraftHostsList.Contains(airOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
					{
						theAircraftHostsList.Add(airOps.get_AssignedHostUnit(PickNewAssignedHost: false));
					}
					if (aircraft.Loadout != null)
					{
						theAircraftList_AvailableForFlightPlanGenerator.Add(aircraft);
						if (!theLoadoutsList.Contains(aircraft.Loadout.DBID))
						{
							theLoadoutsList.Add(aircraft.Loadout.DBID);
						}
					}
				}
				else if (airOps.CurrentHostUnit != null)
				{
					if (!theAircraftHostsList.Contains(airOps.CurrentHostUnit))
					{
						theAircraftHostsList.Add(airOps.CurrentHostUnit);
					}
					string ReasonForNot = null;
					if (aircraft.IsAvailableForOps(ref ReasonForNot) == 0 && (aircraft.IsParkedAndReady() || (!OrderTakeOff && aircraft.IsParkedAndReadying())))
					{
						if (aircraft.Loadout == null)
						{
							continue;
						}
						theAircraftList_AvailableForFlightPlanGenerator.Add(aircraft);
						if (!theLoadoutsList.Contains(aircraft.Loadout.DBID))
						{
							theLoadoutsList.Add(aircraft.Loadout.DBID);
						}
						if (aircraft.AI.IsEscort)
						{
							if (aircraft.Loadout.IsSupportOrPatrol)
							{
								NumberOfAircraft_Ready_Escorts_NonShooter++;
							}
							else
							{
								NumberOfAircraft_Ready_Escorts_Shooter++;
							}
						}
						else
						{
							NumberOfAircraft_Ready++;
						}
					}
					else if (airOps.IsTakingOff)
					{
						if (!aircraft.AI.IsEscort)
						{
							NumberOfAircraft_AirborneOrTakingOff++;
						}
						else if (aircraft.Loadout.IsSupportOrPatrol)
						{
							NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter++;
						}
						else
						{
							NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter++;
						}
					}
				}
				else if (aircraft.AI.IsEscort)
				{
					if (aircraft.Loadout.IsSupportOrPatrol)
					{
						NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter++;
					}
					else
					{
						NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter++;
					}
				}
				else
				{
					NumberOfAircraft_AirborneOrTakingOff++;
				}
			}
			if (!IsContinousCoverage && IncludeEmptySlots && EmptySlotsReferenceAircraftList.Count > 0)
			{
				int num2 = EmptySlotsReferenceAircraftList.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					ActiveUnit activeUnit = EmptySlotsReferenceAircraftList[j];
					Aircraft aircraft2 = (Aircraft)activeUnit;
					theAircraftList.Add(aircraft2);
					if (!Information.IsNothing((object)((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true)))
					{
						EmptySlotsReferenceAircraftList_AssignedToFlight.Add(aircraft2);
						theFlightList_HasEmptySlots.Add(((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true));
						continue;
					}
					theAircraftList_AvailableForFlightPlanGenerator.Add(aircraft2);
					Aircraft_AirOps airOps2 = aircraft2.AirOps;
					if (!theAircraftDBIDs.Contains(aircraft2.DBID))
					{
						theAircraftDBIDs.Add(aircraft2.DBID);
					}
					if (Information.IsNothing((object)airOps2.CurrentHostUnit))
					{
						continue;
					}
					if (!theAircraftHostsList.Contains(airOps2.CurrentHostUnit))
					{
						theAircraftHostsList.Add(airOps2.CurrentHostUnit);
					}
					if (!Information.IsNothing((object)aircraft2.Loadout))
					{
						EmptySlotsReferenceAircraftList_Ready.Add(aircraft2);
						if (!theLoadoutsList.Contains(aircraft2.Loadout.DBID))
						{
							theLoadoutsList.Add(aircraft2.Loadout.DBID);
						}
						if (!aircraft2.AI.IsEscort)
						{
							NumberOfEmptySlots_Ready++;
						}
						else if (aircraft2.Loadout.IsSupportOrPatrol)
						{
							NumberOfEmptySlots_Ready_Escorts_NonShooter++;
						}
						else
						{
							NumberOfEmptySlots_Ready_Escorts_Shooter++;
						}
					}
				}
			}
			if (IsContinousCoverage)
			{
				return;
			}
			foreach (Flight item in theFlightList_NotReady)
			{
				if (theFlightList_Ready.Contains(item))
				{
					theFlightList_Ready.Remove(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101241", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReconfigureMissionForPrePlannedFlights(ref Scenario theScen, ref Side theSide, bool? HasPrePlannedFlights)
	{
	}

	public void ClearAllAircraft_ReplaceWithEmptySlots(ref Scenario theScen, ref Side theSide, ref Flight theFlight)
	{
		try
		{
			if (Information.IsNothing((object)theFlight))
			{
				return;
			}
			foreach (ActiveUnit unit in theSide.Units)
			{
				ActiveUnit theAU = unit;
				if (theAU.Navigator.HasFlight && Operators.CompareString(theAU.Navigator.get_Flight(HierarchySearch: true).ObjectID, theFlight.ObjectID, false) == 0)
				{
					ClearAircraft_ReplaceWithEmptySlot(ref theScen, ref theFlight, ref theAU);
				}
			}
			theFlight.set_ReferenceUnit(theScen, (ActiveUnit)null);
			theFlight.ReferenceUnit_ObjectID = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAircraft_ReplaceWithEmptySlot(ref Scenario theScen, ref Flight theFlight, ref ActiveUnit theAU)
	{
		try
		{
			if (Information.IsNothing((object)theFlight))
			{
				return;
			}
			theAU.Navigator.ClearFlight();
			if (Information.IsNothing((object)EmptySlotsList))
			{
				EmptySlotsList = new List<EmptyAircraftSlot>();
			}
			if (theAU.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)theAU;
				int dBID = default(int);
				string name = default(string);
				if (!Information.IsNothing((object)aircraft.Loadout))
				{
					dBID = aircraft.Loadout.DBID;
					name = aircraft.Loadout.Name;
				}
				string objectID = default(string);
				string name2 = default(string);
				if (!Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit))
				{
					objectID = aircraft.AirOps.CurrentHostUnit.ObjectID;
					name2 = aircraft.AirOps.CurrentHostUnit.Name;
				}
				int dBID2 = theAU.DBID;
				string unitClass = theAU.UnitClass;
				int theLoadoutDBID = dBID;
				string theLoadoutName = name;
				ActiveUnit theCurrentHostUnit = null;
				EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot(null, dBID2, unitClass, theLoadoutDBID, theLoadoutName, ref theCurrentHostUnit, objectID, name2, theAU.AI.IsEscort);
				int flightRole = (int)theAU.FlightRole;
				EmptySlotsList.Add(emptyAircraftSlot);
				emptyAircraftSlot.SetFlight(theScen, theFlight, flightRole);
				emptyAircraftSlot.set_CurrentHostUnit(theScen, aircraft.AirOps.CurrentHostUnit);
				emptyAircraftSlot.CurrentHostUnit_Name = name2;
				emptyAircraftSlot.CurrentHostUnit_ObjectID = objectID;
				ResetFlightReadyAicraftCount(theScen, theFlight);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FillEmptySlots(Scenario theScen, ref Side theSide, ref bool IsManual, Flight theSpecificFlight, bool FillFlightsWithNoAircraftSpecified)
	{
		_Closure$__162-0 arg = default(_Closure$__162-0);
		_Closure$__162-0 CS$<>8__locals97 = new _Closure$__162-0(arg);
		CS$<>8__locals97.$VB$Local_theScen = theScen;
		try
		{
			if (Category == MissionCategory.TaskPool)
			{
				return;
			}
			if (!Information.IsNothing((object)EmptySlotsList) && EmptySlotsList.Count != 0)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				new List<ActiveUnit>();
				new List<ActiveUnit>();
				new List<ActiveUnit>();
				List<ActiveUnit> list2 = Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen).ToList();
				list.AddRange(list2.Where([SpecialName] (ActiveUnit activeUnit) =>
				{
					int result;
					if (activeUnit.Navigator.HasFlight)
					{
						result = 0;
					}
					else
					{
						if (activeUnit.IsAircraft)
						{
							return !activeUnit.IsOperating();
						}
						result = 0;
					}
					return (byte)result != 0;
				}).ToList());
				bool flag = true;
				if (MissionClass == _MissionClass.Patrol)
				{
					int count = list2.Count;
					_FlightSize theFlightSize = FlightSize;
					int num = FlightSize_To_ActualAircraftQty(ref theFlightSize, ref ((Patrol)this).ContinousCoverage_NumberOfFlightsNeededToAllowQRA);
					FlightSize = theFlightSize;
					int num2 = num;
					if (count < num2)
					{
						flag = false;
					}
				}
				else if (MissionClass == _MissionClass.Support)
				{
					int count2 = list2.Count;
					_FlightSize theFlightSize = FlightSize;
					int num3 = FlightSize_To_ActualAircraftQty(ref theFlightSize, ref ((SupportMission)this).ContinousCoverage_NumberOfFlightsNeededToAllowQRA);
					FlightSize = theFlightSize;
					int num4 = num3;
					if (count2 < num4)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					foreach (Flight flight2 in FlightList)
					{
						Flight theFlight = flight2;
						if (theFlight.Task == _FlightTask.QRA)
						{
							ClearAllAircraft_ReplaceWithEmptySlots(ref CS$<>8__locals97.$VB$Local_theScen, ref theSide, ref theFlight);
						}
					}
				}
				Mission mission = default(Mission);
				if (Category == MissionCategory.Package)
				{
					foreach (Mission mission2 in theSide.Missions)
					{
						if (Operators.CompareString(mission2.ObjectID, this.get_ParentTaskPoolID(theSide), false) == 0)
						{
							mission = mission2;
							break;
						}
					}
					if (Information.IsNothing((object)mission))
					{
						GameGeneral.SendMessageBoxToUI("Could not find the mission's Task Pool!", theSide);
						return;
					}
					list.AddRange(mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
					{
						int result;
						if (Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
						{
							if (activeUnit.IsAircraft)
							{
								return !activeUnit.IsOperating();
							}
							result = 0;
						}
						else
						{
							result = 0;
						}
						return (byte)result != 0;
					}).ToList());
				}
				if (list.Count != 0)
				{
					List<EmptyAircraftSlot> list3 = new List<EmptyAircraftSlot>();
					list3.AddRange((from theES in EmptySlotsList.Where([SpecialName] (EmptyAircraftSlot theES) =>
						{
							int result;
							if (theES.IsEscort && !Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)))
							{
								if (!Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan))
								{
									return theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() == 0;
								}
								result = 0;
							}
							else
							{
								result = 0;
							}
							return (byte)result != 0;
						})
						orderby theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Callsign descending
						select theES).ToList());
					list3.AddRange((from theES in EmptySlotsList.Where([SpecialName] (EmptyAircraftSlot theES) =>
						{
							int result;
							if (Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)))
							{
								result = 0;
							}
							else
							{
								if (!Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan))
								{
									return theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() > 0;
								}
								result = 0;
							}
							return (byte)result != 0;
						})
						orderby theES.IsEscort descending, theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu descending, theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Callsign descending
						select theES).ToList());
					if (IsManual && EmptySlotsList.Where([SpecialName] (EmptyAircraftSlot theES) =>
					{
						int result;
						if (!theES.IsEscort)
						{
							if (Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)))
							{
								result = 0;
								goto IL_0051;
							}
							if (!Information.IsNothing((object)theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan))
							{
								return theES.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() == 0;
							}
						}
						result = 0;
						goto IL_0051;
						IL_0051:
						return (byte)result != 0;
					}).Count() > 0)
					{
						GameGeneral.SendMessageBoxToUI("At least one pre-planned flight is lacking a flightplan. Only flights with flightplans can be filled with aircraft.", theSide);
					}
					if (!Information.IsNothing((object)list3) && list3.Count != 0)
					{
						if (!Information.IsNothing((object)list3))
						{
							for (int num5 = list3.Count - 1; num5 >= 0; num5 += -1)
							{
								EmptyAircraftSlot emptyAircraftSlot = list3[num5];
								if (Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)) || (!Information.IsNothing((object)theSpecificFlight) && Operators.CompareString(theSpecificFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) != 0) || emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Task == _FlightTask.QRA))
								{
									continue;
								}
								foreach (ActiveUnit item in list)
								{
									if (item.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
									{
										continue;
									}
									Aircraft aircraft = (Aircraft)item;
									if (aircraft.LoadoutDBID == emptyAircraftSlot.int_0 && !Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit) && !(aircraft.AirOps.ConditionTimer > 0f) && (aircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked || aircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
									{
										((ActiveUnit_Navigator)aircraft.Navigator).set_Flight(HierarchySearch: true, emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen));
										((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (ActiveUnit)aircraft);
										((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_DBID = aircraft.DBID;
										((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_ObjectID = aircraft.ObjectID;
										((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_Name = aircraft.UnitClass;
										if (!Information.IsNothing((object)aircraft.Loadout))
										{
											((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).int_1 = aircraft.Loadout.DBID;
											((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_LoadoutName(CS$<>8__locals97.$VB$Local_theScen, aircraft.Loadout.Name);
										}
										EmptySlotsList.Remove(emptyAircraftSlot);
										list3.Remove(emptyAircraftSlot);
										MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
										aircraft.Set_AssignedMissionOrPackage(this, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
										aircraft.AI.IsEscort = emptyAircraftSlot.IsEscort;
										aircraft.Doctrine.ClearCachedParentDoctrine();
										list.Remove(aircraft);
										break;
									}
								}
								if (list.Count == 0)
								{
									ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
									return;
								}
							}
						}
						list.Clear();
						list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
						{
							int result;
							if (!activeUnit.Navigator.HasFlight)
							{
								if (activeUnit.IsAircraft)
								{
									return !activeUnit.IsOperating();
								}
								result = 0;
							}
							else
							{
								result = 0;
							}
							return (byte)result != 0;
						}).ToList());
						if (Category == MissionCategory.Package)
						{
							list.AddRange(mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
							{
								int result;
								if (Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
								{
									if (activeUnit.IsAircraft)
									{
										return !activeUnit.IsOperating();
									}
									result = 0;
								}
								else
								{
									result = 0;
								}
								return (byte)result != 0;
							}).ToList());
						}
						if (list.Count != 0)
						{
							if (list3.Count != 0)
							{
								if (!Information.IsNothing((object)list3))
								{
									for (int num6 = list3.Count - 1; num6 >= 0; num6 += -1)
									{
										EmptyAircraftSlot emptyAircraftSlot = list3[num6];
										if (Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)) || (!Information.IsNothing((object)theSpecificFlight) && Operators.CompareString(theSpecificFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) != 0) || emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Task == _FlightTask.QRA))
										{
											continue;
										}
										foreach (ActiveUnit item2 in list)
										{
											if (item2.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
											{
												continue;
											}
											Aircraft aircraft2 = (Aircraft)item2;
											if (aircraft2.LoadoutDBID != emptyAircraftSlot.int_0 || Information.IsNothing((object)aircraft2.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft2.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot.CurrentHostUnit_ObjectID, false) != 0 || (aircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || aircraft2.AirOps.ConditionTimer >= (float)(aircraft2.Loadout.ReadyTime * 60))
											{
												continue;
											}
											if (emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() > 0 && !Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu))
											{
												DateTime t = CS$<>8__locals97.$VB$Local_theScen.Time.AddSeconds(aircraft2.AirOps.ConditionTimer);
												DateTime? time_Zulu = emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu;
												if (((!time_Zulu.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0)) == true)
												{
													continue;
												}
											}
											((ActiveUnit_Navigator)aircraft2.Navigator).set_Flight(HierarchySearch: true, emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen));
											((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (ActiveUnit)aircraft2);
											((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_DBID = aircraft2.DBID;
											((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_ObjectID = aircraft2.ObjectID;
											((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_Name = aircraft2.UnitClass;
											if (!Information.IsNothing((object)aircraft2.Loadout))
											{
												((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).int_1 = aircraft2.Loadout.DBID;
												((ActiveUnit_Navigator)aircraft2.Navigator).get_Flight(HierarchySearch: true).set_LoadoutName(CS$<>8__locals97.$VB$Local_theScen, aircraft2.Loadout.Name);
											}
											EmptySlotsList.Remove(emptyAircraftSlot);
											list3.Remove(emptyAircraftSlot);
											MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
											aircraft2.Set_AssignedMissionOrPackage(this, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
											aircraft2.AI.IsEscort = emptyAircraftSlot.IsEscort;
											aircraft2.Doctrine.ClearCachedParentDoctrine();
											list.Remove(aircraft2);
											break;
										}
										if (list.Count == 0)
										{
											ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
											return;
										}
									}
								}
								list.Clear();
								list.AddRange((from activeUnit in Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen)
									where !activeUnit.Navigator.HasFlight && activeUnit.IsAircraft && !activeUnit.IsOperating()
									select activeUnit).ToList());
								if (Category == MissionCategory.Package)
								{
									list.AddRange(mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
									{
										int result;
										if (Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
										{
											if (activeUnit.IsAircraft)
											{
												return !activeUnit.IsOperating();
											}
											result = 0;
										}
										else
										{
											result = 0;
										}
										return (byte)result != 0;
									}).ToList());
								}
								if (list.Count != 0)
								{
									if (list3.Count == 0)
									{
										ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
										return;
									}
									if (!Information.IsNothing((object)list3))
									{
										for (int num7 = list3.Count - 1; num7 >= 0; num7 += -1)
										{
											EmptyAircraftSlot emptyAircraftSlot = list3[num7];
											if (Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)) || (!Information.IsNothing((object)theSpecificFlight) && Operators.CompareString(theSpecificFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) != 0) || emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Task == _FlightTask.QRA))
											{
												continue;
											}
											foreach (ActiveUnit item3 in list)
											{
												if (item3.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
												{
													continue;
												}
												Aircraft theAircraft = (Aircraft)item3;
												if (Information.IsNothing((object)theAircraft.AirOps.CurrentHostUnit) || Operators.CompareString(theAircraft.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot.CurrentHostUnit_ObjectID, false) != 0 || theAircraft.Loadout.Role == Loadout.LoadoutRole.Unavailable || (theAircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && theAircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || emptyAircraftSlot.int_0 == 0)
												{
													continue;
												}
												Loadout loadout = DBFunctions.GetLoadout(ref theAircraft.ParentScen, emptyAircraftSlot.int_0, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
												if (theAircraft.AirOps.ConditionTimer > (float)(loadout.ReadyTime * 60))
												{
													continue;
												}
												if (emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() > 0 && !Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu))
												{
													DateTime t = CS$<>8__locals97.$VB$Local_theScen.Time.AddMinutes(loadout.ReadyTime);
													DateTime? time_Zulu = emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu;
													if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0) : ((bool?)null)) == true)
													{
														continue;
													}
												}
												if ((theAircraft.AirOps.EnoughOrdnanceInMagazines(ref theAircraft, loadout, emptyAircraftSlot.int_0, emptyAircraftSlot.Loadout_ExcludeOptionalWeapons) || theAircraft.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)) && Operators.CompareString(theAircraft.AirOps.OutfitAC(ref theAircraft, emptyAircraftSlot.int_0, theAircraft.LoadoutDBID, ReadyImmediately: false, emptyAircraftSlot.Loadout_ExcludeOptionalWeapons, !theAircraft.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), ManualAction: false, PlayerFeedback: false), "OK", false) == 0)
												{
													((ActiveUnit_Navigator)theAircraft.Navigator).set_Flight(HierarchySearch: true, emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen));
													((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (ActiveUnit)theAircraft);
													((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_DBID = theAircraft.DBID;
													((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_ObjectID = theAircraft.ObjectID;
													((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_Name = theAircraft.UnitClass;
													if (!Information.IsNothing((object)theAircraft.Loadout))
													{
														((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).int_1 = theAircraft.Loadout.DBID;
														((ActiveUnit_Navigator)theAircraft.Navigator).get_Flight(HierarchySearch: true).set_LoadoutName(CS$<>8__locals97.$VB$Local_theScen, theAircraft.Loadout.Name);
													}
													EmptySlotsList.Remove(emptyAircraftSlot);
													list3.Remove(emptyAircraftSlot);
													Aircraft aircraft3 = theAircraft;
													MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
													aircraft3.Set_AssignedMissionOrPackage(this, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
													theAircraft.AI.IsEscort = emptyAircraftSlot.IsEscort;
													theAircraft.Doctrine.ClearCachedParentDoctrine();
													list.Remove(theAircraft);
													break;
												}
											}
											if (list.Count == 0)
											{
												ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
												return;
											}
										}
									}
									list.Clear();
									list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
									{
										int result;
										if (!activeUnit.Navigator.HasFlight)
										{
											if (activeUnit.IsAircraft)
											{
												return !activeUnit.IsOperating();
											}
											result = 0;
										}
										else
										{
											result = 0;
										}
										return (byte)result != 0;
									}).ToList());
									if (Category == MissionCategory.Package)
									{
										list.AddRange(mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
										{
											int result;
											if (!Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
											{
												result = 0;
											}
											else
											{
												if (activeUnit.IsAircraft)
												{
													return !activeUnit.IsOperating();
												}
												result = 0;
											}
											return (byte)result != 0;
										}).ToList());
									}
									if (list.Count == 0)
									{
										ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
									}
									else if (list3.Count != 0)
									{
										if (!Information.IsNothing((object)list3))
										{
											for (int num8 = list3.Count - 1; num8 >= 0; num8 += -1)
											{
												EmptyAircraftSlot emptyAircraftSlot = list3[num8];
												if (Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)) || (!Information.IsNothing((object)theSpecificFlight) && Operators.CompareString(theSpecificFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) != 0) || emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Task == _FlightTask.QRA))
												{
													continue;
												}
												foreach (ActiveUnit item4 in list)
												{
													if (item4.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
													{
														continue;
													}
													Aircraft theAircraft2 = (Aircraft)item4;
													if (Information.IsNothing((object)theAircraft2.AirOps.CurrentHostUnit) || Operators.CompareString(theAircraft2.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot.CurrentHostUnit_ObjectID, false) != 0 || theAircraft2.Loadout.Role == Loadout.LoadoutRole.Unavailable || (theAircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && theAircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || emptyAircraftSlot.int_0 == 0)
													{
														continue;
													}
													Loadout loadout2 = DBFunctions.GetLoadout(ref theAircraft2.ParentScen, emptyAircraftSlot.int_0, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
													if (emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() > 0 && !Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu))
													{
														if (theAircraft2.AirOps.ConditionTimer > (float)(loadout2.ReadyTime * 60))
														{
															DateTime t = CS$<>8__locals97.$VB$Local_theScen.Time.AddSeconds(theAircraft2.AirOps.ConditionTimer);
															DateTime? time_Zulu = emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu;
															if (((!time_Zulu.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0)) == true)
															{
																continue;
															}
														}
														else
														{
															DateTime t = CS$<>8__locals97.$VB$Local_theScen.Time.AddMinutes(loadout2.ReadyTime);
															DateTime? time_Zulu = emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu;
															if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0) : ((bool?)null)) == true)
															{
																continue;
															}
														}
													}
													if ((theAircraft2.AirOps.EnoughOrdnanceInMagazines(ref theAircraft2, loadout2, emptyAircraftSlot.int_0, emptyAircraftSlot.Loadout_ExcludeOptionalWeapons) || theAircraft2.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)) && Operators.CompareString(theAircraft2.AirOps.OutfitAC(ref theAircraft2, emptyAircraftSlot.int_0, theAircraft2.LoadoutDBID, ReadyImmediately: false, emptyAircraftSlot.Loadout_ExcludeOptionalWeapons, !theAircraft2.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), ManualAction: false, PlayerFeedback: false), "OK", false) == 0)
													{
														((ActiveUnit_Navigator)theAircraft2.Navigator).set_Flight(HierarchySearch: true, emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen));
														((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (ActiveUnit)theAircraft2);
														((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_DBID = theAircraft2.DBID;
														((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_ObjectID = theAircraft2.ObjectID;
														((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_Name = theAircraft2.UnitClass;
														if (!Information.IsNothing((object)theAircraft2.Loadout))
														{
															((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).int_1 = theAircraft2.Loadout.DBID;
															((ActiveUnit_Navigator)theAircraft2.Navigator).get_Flight(HierarchySearch: true).set_LoadoutName(CS$<>8__locals97.$VB$Local_theScen, theAircraft2.Loadout.Name);
														}
														EmptySlotsList.Remove(emptyAircraftSlot);
														list3.Remove(emptyAircraftSlot);
														Aircraft aircraft4 = theAircraft2;
														MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
														aircraft4.Set_AssignedMissionOrPackage(this, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
														theAircraft2.AI.IsEscort = emptyAircraftSlot.IsEscort;
														theAircraft2.Doctrine.ClearCachedParentDoctrine();
														list.Remove(theAircraft2);
														break;
													}
												}
												if (list.Count == 0)
												{
													ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
													return;
												}
											}
										}
										if (FillFlightsWithNoAircraftSpecified)
										{
											list.Clear();
											list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
											{
												int result;
												if (!activeUnit.Navigator.HasFlight)
												{
													if (activeUnit.IsAircraft)
													{
														return !activeUnit.IsOperating();
													}
													result = 0;
												}
												else
												{
													result = 0;
												}
												return (byte)result != 0;
											}).ToList());
											if (Category == MissionCategory.Package)
											{
												list.AddRange(mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
												{
													int result;
													if (!Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
													{
														result = 0;
													}
													else
													{
														if (activeUnit.IsAircraft)
														{
															return !activeUnit.IsOperating();
														}
														result = 0;
													}
													return (byte)result != 0;
												}).ToList());
											}
											if (list.Count == 0)
											{
												ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
												return;
											}
											if (list3.Count == 0)
											{
												ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
												return;
											}
											if (!Information.IsNothing((object)list3))
											{
												for (int num9 = list3.Count - 1; num9 >= 0; num9 += -1)
												{
													EmptyAircraftSlot emptyAircraftSlot = list3[num9];
													if (Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen)) || (!Information.IsNothing((object)theSpecificFlight) && Operators.CompareString(theSpecificFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) != 0) || emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).Task == _FlightTask.QRA) || (emptyAircraftSlot.ReferenceUnit_DBID > 0 && emptyAircraftSlot.int_0 > 0))
													{
														continue;
													}
													foreach (ActiveUnit item5 in list)
													{
														if (emptyAircraftSlot.ReferenceUnit_DBID > 0 && item5.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
														{
															continue;
														}
														Aircraft aircraft5 = (Aircraft)item5;
														if (Information.IsNothing((object)aircraft5.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft5.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot.CurrentHostUnit_ObjectID, false) != 0 || aircraft5.Loadout.Role == Loadout.LoadoutRole.Unavailable || aircraft5.Loadout.Role == Loadout.LoadoutRole.Reserve || aircraft5.Loadout.Role == Loadout.LoadoutRole.PackedForCargo || (aircraft5.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft5.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying))
														{
															continue;
														}
														if (emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan.Count() > 0 && !Information.IsNothing((object)emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu) && aircraft5.AirOps.ConditionTimer > 0f)
														{
															DateTime t = CS$<>8__locals97.$VB$Local_theScen.Time.AddSeconds(aircraft5.AirOps.ConditionTimer);
															DateTime? time_Zulu = emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen).FlightPlan[0].Time_Zulu;
															if (((!time_Zulu.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0)) == true)
															{
																continue;
															}
														}
														((ActiveUnit_Navigator)aircraft5.Navigator).set_Flight(HierarchySearch: true, emptyAircraftSlot.get_MissionFlight(CS$<>8__locals97.$VB$Local_theScen));
														((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (ActiveUnit)aircraft5);
														((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_DBID = aircraft5.DBID;
														((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_ObjectID = aircraft5.ObjectID;
														((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).ReferenceUnit_Name = aircraft5.UnitClass;
														if (!Information.IsNothing((object)aircraft5.Loadout))
														{
															((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).int_1 = aircraft5.Loadout.DBID;
															((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).set_LoadoutName(CS$<>8__locals97.$VB$Local_theScen, aircraft5.Loadout.Name);
														}
														aircraft5.AI.IsEscort = emptyAircraftSlot.IsEscort;
														EmptySlotsList.Remove(emptyAircraftSlot);
														list3.Remove(emptyAircraftSlot);
														MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
														aircraft5.Set_AssignedMissionOrPackage(this, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
														aircraft5.Doctrine.ClearCachedParentDoctrine();
														list.Remove(aircraft5);
														if (!Information.IsNothing((object)EmptySlotsList))
														{
															for (int num10 = EmptySlotsList.Count - 1; num10 >= 0; num10 += -1)
															{
																EmptyAircraftSlot emptyAircraftSlot2 = EmptySlotsList[num10];
																if (Operators.CompareString(emptyAircraftSlot2.MissionFlight_ObjectID, ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).ObjectID, false) == 0)
																{
																	emptyAircraftSlot2.set_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen, (Mission)null, (ActiveUnit)aircraft5);
																	emptyAircraftSlot2.ReferenceUnit_DBID = aircraft5.DBID;
																	emptyAircraftSlot2.ReferenceUnit_UnitClass = aircraft5.UnitClass;
																	if (!Information.IsNothing((object)aircraft5.Loadout))
																	{
																		emptyAircraftSlot2.int_0 = aircraft5.Loadout.DBID;
																		emptyAircraftSlot2.LoadoutName = aircraft5.Loadout.Name;
																	}
																}
															}
														}
														FillEmptySlots(CS$<>8__locals97.$VB$Local_theScen, ref theSide, ref IsManual, ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true), FillFlightsWithNoAircraftSpecified: false);
														Scenario theScen2 = CS$<>8__locals97.$VB$Local_theScen;
														ActiveUnit theAU = ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).get_ReferenceUnit(CS$<>8__locals97.$VB$Local_theScen);
														Flight theFlight2 = ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true);
														Flight flight;
														Waypoint[] theFlightplan = (flight = ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true)).FlightPlan;
														float NecessaryFuel = 0f;
														float MissionFuel = 0f;
														MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, this, theAU, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, TakeOffTime, TimeOnTarget, IsMFP: false);
														flight.FlightPlan = theFlightplan;
														list.Clear();
														list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(this, CS$<>8__locals97.$VB$Local_theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
														{
															int result;
															if (!activeUnit.Navigator.HasFlight)
															{
																if (activeUnit.IsAircraft)
																{
																	return !activeUnit.IsOperating();
																}
																result = 0;
															}
															else
															{
																result = 0;
															}
															return (byte)result != 0;
														}).ToList());
														if (Category == MissionCategory.Package)
														{
															list.AddRange((from activeUnit in mission.get_UnitsAssignedToTaskPool(CS$<>8__locals97.$VB$Local_theScen)
																where Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()) && activeUnit.IsAircraft && !activeUnit.IsOperating()
																select activeUnit).ToList());
														}
														break;
													}
													if (list.Count == 0)
													{
														ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
														return;
													}
												}
											}
										}
										ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
									}
									else
									{
										ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
									}
								}
								else
								{
									ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
								}
							}
							else
							{
								ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
							}
						}
						else
						{
							ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
						}
					}
					else
					{
						ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
					}
					return;
				}
				if (IsManual)
				{
					if (Category == MissionCategory.Package)
					{
						GameGeneral.SendMessageBoxToUI("Could not find any available aircraft in the Package or Task Pool!", theSide);
					}
					else
					{
						GameGeneral.SendMessageBoxToUI("Could not find any available aircraft on the Mission!", theSide);
					}
				}
				else if (TimeSincePlayerNotification == 0)
				{
					if (Category == MissionCategory.Package)
					{
						CS$<>8__locals97.$VB$Local_theScen.AddMessage("Package " + Name + " could not find any available aircraft in the Package or Task Pool!", Name + " cannot find AC", LoggedMessage.MessageType.AirOps, 0, null, theSide);
					}
					else
					{
						CS$<>8__locals97.$VB$Local_theScen.AddMessage("Mission " + Name + " could not find any available aircraft!", Name + " cannot find AC", LoggedMessage.MessageType.AirOps, 0, null, theSide);
					}
				}
				ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
			}
			else
			{
				ResetFlightReadyAicraftCount(CS$<>8__locals97.$VB$Local_theScen, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200644", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Dictionary<string, Dictionary<string, Dictionary<string, int>>> UnitsAssignedToMission_SeparatedByHostTypeLoadout(ref Scenario theScen, bool GetEscortShooters, bool GetEscortNonShooters)
	{
		Dictionary<string, Dictionary<string, Dictionary<string, int>>> result;
		try
		{
			Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
			Dictionary<string, Dictionary<string, string>> dictionary2 = new Dictionary<string, Dictionary<string, string>>();
			ActiveUnit[] array = theScen.ActiveUnits_List.InternalArray();
			int num = theScen.ActiveUnits_List.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = array[i];
				if (activeUnit == null || activeUnit.IsGroup || activeUnit.ActiveMissionOrPackage() != this || !activeUnit.IsAircraft || (GetEscortShooters && !activeUnit.AI.IsEscort) || (GetEscortNonShooters && !activeUnit.AI.IsEscort) || (!GetEscortShooters && !GetEscortNonShooters && activeUnit.AI.IsEscort) || (GetEscortShooters && !GetEscortNonShooters && MissionClass == _MissionClass.Strike && !(((Strike)this).Escort_FlightSize_NonShooter == 0)))
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (aircraft.Loadout == null)
				{
					continue;
				}
				if (airOps.CurrentHostUnit != null)
				{
					Dictionary<string, int> value = null;
					Dictionary<string, Dictionary<string, int>> value2 = null;
					if (!dictionary.ContainsKey(airOps.CurrentHostUnit.Name))
					{
						dictionary.Add(airOps.CurrentHostUnit.Name, null);
					}
					dictionary.TryGetValue(airOps.CurrentHostUnit.Name, out value2);
					if (value2 == null)
					{
						value2 = new Dictionary<string, Dictionary<string, int>>();
						value2.Add(aircraft.UnitClass, null);
						dictionary[airOps.CurrentHostUnit.Name] = value2;
					}
					value2.TryGetValue(aircraft.UnitClass, out value);
					if (value == null)
					{
						value = new Dictionary<string, int>();
						value.Add(aircraft.Loadout.Name, 1);
						value2[aircraft.UnitClass] = value;
						continue;
					}
					value.TryGetValue(aircraft.Loadout.Name, out var value3);
					if ((value3 == 0) & (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Equipment))
					{
						value.Add(aircraft.Loadout.Name, 1);
					}
					else if (value3 <= 0)
					{
						value.Add(aircraft.Loadout.Name, 1);
					}
					else
					{
						value[aircraft.Loadout.Name]++;
					}
				}
				else
				{
					if (airOps.get_AssignedHostUnit(PickNewAssignedHost: false) == null)
					{
						continue;
					}
					Dictionary<string, string> value4 = null;
					if (!dictionary2.ContainsKey(airOps.get_AssignedHostUnit(PickNewAssignedHost: false).Name))
					{
						dictionary2.Add(airOps.get_AssignedHostUnit(PickNewAssignedHost: false).Name, null);
					}
					dictionary2.TryGetValue(airOps.get_AssignedHostUnit(PickNewAssignedHost: false).Name, out value4);
					if (value4 == null)
					{
						value4 = new Dictionary<string, string>();
						value4.Add(aircraft.UnitClass, aircraft.Loadout.Name);
						dictionary2[airOps.get_AssignedHostUnit(PickNewAssignedHost: false).Name] = value4;
						continue;
					}
					value4.TryGetValue(aircraft.UnitClass, out var value5);
					if (value5 == null && !value4.ContainsKey(aircraft.UnitClass))
					{
						value4.Add(aircraft.UnitClass, aircraft.Loadout.Name);
					}
				}
			}
			if (EmptySlotsList != null)
			{
				int num2 = EmptySlotsList.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					EmptyAircraftSlot emptyAircraftSlot = EmptySlotsList[j];
					if ((GetEscortShooters && !emptyAircraftSlot.IsEscort) || (GetEscortNonShooters && !emptyAircraftSlot.IsEscort) || (!GetEscortShooters && !GetEscortNonShooters && emptyAircraftSlot.IsEscort) || (GetEscortShooters && !GetEscortNonShooters && MissionClass == _MissionClass.Strike && !(((Strike)this).Escort_FlightSize_NonShooter == 0)))
					{
						continue;
					}
					Dictionary<string, int> value6 = null;
					Dictionary<string, Dictionary<string, int>> value7 = null;
					if (!dictionary.ContainsKey(emptyAircraftSlot.CurrentHostUnit_Name))
					{
						dictionary.Add(emptyAircraftSlot.CurrentHostUnit_Name, null);
					}
					dictionary.TryGetValue(emptyAircraftSlot.CurrentHostUnit_Name, out value7);
					if (value7 == null)
					{
						value7 = new Dictionary<string, Dictionary<string, int>>();
						value7.Add(emptyAircraftSlot.ReferenceUnit_UnitClass, null);
						dictionary[emptyAircraftSlot.CurrentHostUnit_Name] = value7;
					}
					value7.TryGetValue(emptyAircraftSlot.ReferenceUnit_UnitClass, out value6);
					if (value6 == null)
					{
						value6 = new Dictionary<string, int>();
						value6.Add(emptyAircraftSlot.LoadoutName, 1);
						value7[emptyAircraftSlot.ReferenceUnit_UnitClass] = value6;
						continue;
					}
					value6.TryGetValue(emptyAircraftSlot.LoadoutName, out var value8);
					if (value8 == 0)
					{
						value6.Add(emptyAircraftSlot.LoadoutName, 1);
					}
					else
					{
						value6[emptyAircraftSlot.LoadoutName]++;
					}
				}
			}
			foreach (KeyValuePair<string, Dictionary<string, string>> item in dictionary2)
			{
				Dictionary<string, string> value9 = item.Value;
				foreach (KeyValuePair<string, string> item2 in value9)
				{
					string value10 = item2.Value;
					List<string> list = new List<string>();
					foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item3 in dictionary)
					{
						List<string> list2 = new List<string>();
						Dictionary<string, Dictionary<string, int>> value11 = item3.Value;
						foreach (KeyValuePair<string, Dictionary<string, int>> item4 in value11)
						{
							List<string> list3 = new List<string>();
							Dictionary<string, int> value12 = item4.Value;
							foreach (KeyValuePair<string, int> item5 in value12)
							{
								if (Operators.CompareString(item5.Key, value10, false) == 0)
								{
									list3.Add(value10);
								}
							}
							foreach (string item6 in list3)
							{
								value12.Remove(item6);
							}
							if (item4.Value.Count == 0)
							{
								list2.Add(item4.Key);
							}
						}
						foreach (string item7 in list2)
						{
							value11.Remove(item7);
						}
						if (item3.Value.Count == 0)
						{
							list.Add(item3.Key);
						}
					}
					foreach (string item8 in list)
					{
						dictionary.Remove(item8);
					}
				}
			}
			result = dictionary;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101251", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void StartTime_Set(DateTime? value, Scenario theScen)
	{
		bool flag = false;
		if (!_StartTime.HasValue && value.HasValue)
		{
			flag = true;
		}
		else if (!value.HasValue && _StartTime.HasValue)
		{
			flag = true;
		}
		else
		{
			DateTime? startTime = _StartTime;
			bool? flag2 = ((!(startTime.HasValue & value.HasValue)) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), value.GetValueOrDefault()) == 0));
			if (((!flag2) ?? flag2) == true)
			{
				flag = true;
			}
		}
		_StartTime = value;
		if (flag)
		{
			startTimeChangedEventHandler_0?.Invoke(this);
		}
		method_1(theScen);
	}

	private void method_1(Scenario scenario_0)
	{
		bool? obj;
		if (StartTime.HasValue)
		{
			DateTime? startTime = StartTime;
			DateTime time = scenario_0.Time;
			obj = ((!startTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) < 0));
		}
		else
		{
			obj = true;
		}
		bool? flag = obj;
		if (flag ?? true)
		{
			if (EndTime.HasValue)
			{
				DateTime? startTime = EndTime;
				DateTime time = scenario_0.Time;
				if (((!startTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) > 0)) != true)
				{
					goto IL_00c5;
				}
			}
			if (flag.HasValue)
			{
				this.set_Status(scenario_0, MissionStatus.Active);
				return;
			}
		}
		goto IL_00c5;
		IL_00c5:
		this.set_Status(scenario_0, MissionStatus.Inactive);
	}

	public void EndTime_Set(DateTime? value, Scenario theScen)
	{
		bool flag = false;
		if (!_EndTime.HasValue && value.HasValue)
		{
			flag = true;
		}
		else if (!value.HasValue && _EndTime.HasValue)
		{
			flag = true;
		}
		else
		{
			DateTime? endTime = _EndTime;
			bool? flag2 = ((!(endTime.HasValue & value.HasValue)) ? ((bool?)null) : new bool?(DateTime.Compare(endTime.GetValueOrDefault(), value.GetValueOrDefault()) == 0));
			if (((!flag2) ?? flag2) == true)
			{
				flag = true;
			}
		}
		_EndTime = value;
		if (flag)
		{
			endTimeChangedEventHandler_0?.Invoke(this);
		}
		method_1(theScen);
	}

	public void UpdateFlightPlanUseForTakeOffAndTargetTimes()
	{
		if (!TimeOnTarget.HasValue && !TakeOffTime.HasValue)
		{
			if (MissionClass != _MissionClass.Strike)
			{
				UseFlightplans = false;
			}
			else
			{
				UseFlightplans = true;
			}
		}
		else
		{
			UseFlightplans = true;
		}
	}

	public static int FlightQty_To_ActualFlightQty(ref _FlightQty theFlightQty)
	{
		int result;
		switch (theFlightQty)
		{
		default:
			result = 0;
			goto IL_0044;
		case _FlightQty.None:
			return 0;
		case _FlightQty.All:
			return int.MaxValue;
		case (_FlightQty)(-98):
			result = 0;
			goto IL_0044;
		case _FlightQty.Flight_x1:
			return 1;
		case _FlightQty.Flight_x2:
			return 2;
		case _FlightQty.Flight_x3:
			return 3;
		case _FlightQty.Flight_x4:
			return 4;
		case _FlightQty.Flight_x6:
			return 6;
		case _FlightQty.Flight_x8:
			return 8;
		case _FlightQty.Flight_x12:
			{
				return 12;
			}
			IL_0044:
			return result;
		}
	}

	internal int FlightSize_To_ActualAircraftQty(ref _FlightSize theFlightSize, ref _FlightQty theFlightQty)
	{
		int result;
		switch (theFlightQty)
		{
		default:
			result = 0;
			goto IL_0044;
		case _FlightQty.None:
			return 0;
		case _FlightQty.All:
			return int.MaxValue;
		case (_FlightQty)(-98):
			result = 0;
			goto IL_0044;
		case _FlightQty.Flight_x1:
			return theFlightSize;
		case _FlightQty.Flight_x2:
			return (int)theFlightSize * 2;
		case _FlightQty.Flight_x3:
			return (int)theFlightSize * 3;
		case _FlightQty.Flight_x4:
			return (int)theFlightSize * 4;
		case _FlightQty.Flight_x6:
			return (int)theFlightSize * 6;
		case _FlightQty.Flight_x8:
			return (int)theFlightSize * 8;
		case _FlightQty.Flight_x12:
			{
				return (int)theFlightSize * 12;
			}
			IL_0044:
			return result;
		}
	}

	internal _FlightQty FlightInvestigateEngageSelection_To_FlightQty(ref int MinAircraftQty)
	{
		_FlightQty result;
		try
		{
			result = MinAircraftQty switch
			{
				0 => _FlightQty.All, 
				1 => _FlightQty.None, 
				2 => _FlightQty.Flight_x1, 
				3 => _FlightQty.Flight_x2, 
				4 => _FlightQty.Flight_x3, 
				5 => _FlightQty.Flight_x4, 
				6 => _FlightQty.Flight_x6, 
				7 => _FlightQty.Flight_x8, 
				8 => _FlightQty.Flight_x12, 
				_ => _FlightQty.All, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = -99;
			}
			else
			{
				Debugger.Break();
				num = -99;
			}
			result = (_FlightQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int FlightInvestigateEngageQty_To_FlightSelection(_FlightQty MinAircraftQty)
	{
		int result;
		try
		{
			int num;
			switch (MinAircraftQty)
			{
			default:
				num = 0;
				goto IL_0042;
			case _FlightQty.None:
				result = 1;
				break;
			case _FlightQty.All:
				result = 0;
				break;
			case (_FlightQty)(-98):
				num = 0;
				goto IL_0042;
			case _FlightQty.Flight_x1:
				result = 2;
				break;
			case _FlightQty.Flight_x2:
				result = 3;
				break;
			case _FlightQty.Flight_x3:
				result = 4;
				break;
			case _FlightQty.Flight_x4:
				result = 5;
				break;
			case _FlightQty.Flight_x6:
				result = 6;
				break;
			case _FlightQty.Flight_x8:
				result = 7;
				break;
			case _FlightQty.Flight_x12:
				{
					result = 8;
					break;
				}
				IL_0042:
				result = num;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _FlightQty MinimumAircraftQtySelection_To_MinimumAircraftQty(ref int MinAircraftQty, bool isNonShooter)
	{
		_FlightQty result;
		try
		{
			result = (isNonShooter ? (MinAircraftQty switch
			{
				1 => _FlightQty.NoPreferences, 
				0 => _FlightQty.All, 
				_ => _FlightQty.NoPreferences, 
			}) : (MinAircraftQty switch
			{
				0 => _FlightQty.All, 
				1 => _FlightQty.NoPreferences, 
				2 => _FlightQty.Flight_x1, 
				3 => _FlightQty.Flight_x2, 
				4 => _FlightQty.Flight_x3, 
				5 => _FlightQty.Flight_x4, 
				6 => _FlightQty.Flight_x6, 
				7 => _FlightQty.Flight_x8, 
				8 => _FlightQty.Flight_x12, 
				_ => _FlightQty.NoPreferences, 
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101242", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = -99;
			}
			else
			{
				num = -99;
			}
			result = (_FlightQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int MinimumAircraftQty_To_MinimumAircraftQtySelection(int MinAircraftQty, bool isNonShooter)
	{
		int result;
		try
		{
			result = (isNonShooter ? (MinAircraftQty switch
			{
				0 => 1, 
				-99 => 0, 
				_ => 1, 
			}) : (MinAircraftQty switch
			{
				0 => 1, 
				-99 => 0, 
				-97 => 2, 
				-96 => 3, 
				-95 => 4, 
				-94 => 5, 
				-93 => 6, 
				-92 => 7, 
				-91 => 8, 
				_ => 1, 
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101243", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _FlightQty MaximumAircraftQtySelection_To_MaximumAircraftQty(ref int MaxAircraftQty, bool isNonShooter)
	{
		_FlightQty result;
		try
		{
			result = (isNonShooter ? (MaxAircraftQty switch
			{
				0 => _FlightQty.NoPreferences, 
				1 => _FlightQty.Aircraft_x1, 
				2 => _FlightQty.Aircraft_x2, 
				3 => _FlightQty.Aircraft_x3, 
				4 => _FlightQty.Aircraft_x4, 
				5 => _FlightQty.Aircraft_x6, 
				6 => _FlightQty.Aircraft_x8, 
				7 => _FlightQty.Aircraft_x12, 
				_ => _FlightQty.NoPreferences, 
			}) : (MaxAircraftQty switch
			{
				0 => _FlightQty.NoPreferences, 
				1 => _FlightQty.Flight_x1, 
				2 => _FlightQty.Flight_x2, 
				3 => _FlightQty.Flight_x3, 
				4 => _FlightQty.Flight_x4, 
				5 => _FlightQty.Flight_x6, 
				6 => _FlightQty.Flight_x8, 
				7 => _FlightQty.Flight_x12, 
				_ => _FlightQty.NoPreferences, 
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101245", "");
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
			result = (_FlightQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int MaximumFlighstQty_To_MaximumFlightsQtySelection(int MaxFlightsQuantity, bool isNonShooter)
	{
		int result;
		try
		{
			result = ((!isNonShooter) ? (MaxFlightsQuantity switch
			{
				-97 => 1, 
				-96 => 2, 
				-95 => 3, 
				-94 => 4, 
				-93 => 5, 
				-92 => 6, 
				-91 => 7, 
				_ => 0, 
			}) : (MaxFlightsQuantity switch
			{
				-87 => 1, 
				-86 => 2, 
				-85 => 3, 
				-84 => 4, 
				-83 => 5, 
				-82 => 6, 
				-81 => 7, 
				_ => 0, 
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 101244", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int QRAFlightQty_To_FlightSelection(_FlightQty AircraftQty)
	{
		int result;
		try
		{
			result = AircraftQty switch
			{
				_FlightQty.Flight_x1 => 0, 
				_FlightQty.Flight_x2 => 1, 
				_FlightQty.Flight_x3 => 2, 
				_FlightQty.Flight_x4 => 3, 
				_FlightQty.Flight_x6 => 4, 
				_FlightQty.Flight_x8 => 5, 
				_FlightQty.Flight_x12 => 6, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _FlightQty QRAFlightQtySelection_To_QRAFlightQty(ref int AircraftQty)
	{
		_FlightQty result;
		try
		{
			result = AircraftQty switch
			{
				0 => _FlightQty.Flight_x1, 
				1 => _FlightQty.Flight_x2, 
				2 => _FlightQty.Flight_x3, 
				3 => _FlightQty.Flight_x4, 
				4 => _FlightQty.Flight_x6, 
				5 => _FlightQty.Flight_x8, 
				6 => _FlightQty.Flight_x12, 
				_ => _FlightQty.All, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = -99;
			}
			else
			{
				num = -99;
			}
			result = (_FlightQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int QRAMinimumFlightQtyToEnableSelection_To_FlightSelection(_FlightQty AircraftQty)
	{
		int result;
		try
		{
			result = AircraftQty switch
			{
				_FlightQty.Flight_x2 => 0, 
				_FlightQty.Flight_x3 => 1, 
				_FlightQty.Flight_x4 => 2, 
				_FlightQty.Flight_x6 => 3, 
				_FlightQty.Flight_x8 => 4, 
				_FlightQty.Flight_x12 => 5, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _FlightQty QRAMinimumFlightQtyToEnableSelection_To_QRAFlightQty(ref int AircraftQty)
	{
		_FlightQty result = default(_FlightQty);
		try
		{
			switch (AircraftQty)
			{
			case 0:
				result = _FlightQty.Flight_x2;
				break;
			case 1:
				result = _FlightQty.Flight_x3;
				break;
			case 2:
				result = _FlightQty.Flight_x4;
				break;
			case 3:
				result = _FlightQty.Flight_x6;
				break;
			case 4:
				result = _FlightQty.Flight_x8;
				break;
			case 5:
				result = _FlightQty.Flight_x12;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = -99;
			}
			else
			{
				Debugger.Break();
				num = -99;
			}
			result = (_FlightQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void OrderAircraftToTakeOff(ref Scenario theScen, List<Group> AirGroupsOrderedToTakeOff, List<Aircraft> AircraftOrderedToTakeOff, List<Aircraft> AircraftOrderedToTakeOff_Escort_Shooter, List<Aircraft> AircraftOrderedToTakeOff_Escort_NonShooter)
	{
		bool flag = MissionClass == _MissionClass.Patrol && ((Patrol)this).MovementStyle == Patrol.PatrolMovementStyle.ChainsawLoop;
		if ((TakeOffTime.HasValue || TimeOnTarget.HasValue) && !flag)
		{
			bool flag2 = false;
			try
			{
				foreach (Flight flight4 in FlightList)
				{
					if (flight4 != null && flight4.FlightPlan.Count() == 0 && !flight4.IsEscort)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					foreach (Group item in AirGroupsOrderedToTakeOff)
					{
						ActiveUnit groupLead = item.GroupLead;
						if (!groupLead.Navigator.HasFlightPlan && !groupLead.AI.IsEscort)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					foreach (Aircraft item2 in AircraftOrderedToTakeOff)
					{
						if (!((ActiveUnit)item2).Navigator.HasFlightPlan && !((ActiveUnit)item2).AI.IsEscort)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					List<string> list = new List<string>();
					foreach (Flight flight5 in FlightList)
					{
						list.Add(flight5.Callsign);
					}
					CoreClientCode.GenerateMissionFlightPlans_Core(theScen, UnitsAssignedToMission.First().Value.get_UnitSide(SetSideOnly: false), this, FlightSize);
					int num = 0;
					{
						foreach (Flight flight6 in FlightList)
						{
							try
							{
								flight6.Callsign = list[num];
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								ProjectData.ClearProjectError();
							}
							num++;
						}
						return;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 45678363637384", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		try
		{
			if (!Information.IsNothing((object)AirGroupsOrderedToTakeOff))
			{
				foreach (Group item3 in AirGroupsOrderedToTakeOff)
				{
					if (item3 != null && item3.Units.Values.Count == 1)
					{
						ActiveUnit? activeUnit = item3.Units.Values.ElementAtOrDefault(0);
						Flight value = activeUnit.Navigator.get_Flight(HierarchySearch: true);
						item3.Units.Values.ElementAtOrDefault(0).set_ParentGroup(UsingMissionPlanner: true, (Group)null);
						item3.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: false, "Group destroyed by mission logic");
						activeUnit.Navigator.set_Flight(HierarchySearch: true, value);
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4.Data.Add("Error at 4567836343343384", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (!Information.IsNothing((object)AircraftOrderedToTakeOff_Escort_Shooter))
			{
				Flight flight = default(Flight);
				foreach (Aircraft item4 in AircraftOrderedToTakeOff_Escort_Shooter)
				{
					Aircraft_AirOps airOps = item4.AirOps;
					if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
					{
						airOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
					}
					if (item4.Navigator.HasFlight)
					{
						((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true).set_Status(theScen, _FlightStatus.TakingOff);
						flight = ((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true);
						if (MissionClass == _MissionClass.Strike && item4.Doctrine != null)
						{
							item4.Doctrine = item4.Doctrine.CopyDoctrine(ref item4.Doctrine, item4, ref theScen);
						}
					}
				}
				if (flight != null)
				{
					flight.Departed = true;
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6.Data.Add("Error at 794438575658", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (!Information.IsNothing((object)AircraftOrderedToTakeOff_Escort_NonShooter))
			{
				Flight flight2 = default(Flight);
				foreach (Aircraft item5 in AircraftOrderedToTakeOff_Escort_NonShooter)
				{
					Aircraft_AirOps airOps2 = item5.AirOps;
					if (airOps2.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
					{
						airOps2.AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
					}
					if (item5.Navigator.HasFlight)
					{
						((ActiveUnit_Navigator)item5.Navigator).get_Flight(HierarchySearch: true).set_Status(theScen, _FlightStatus.TakingOff);
						flight2 = ((ActiveUnit_Navigator)item5.Navigator).get_Flight(HierarchySearch: true);
						if (MissionClass == _MissionClass.Strike && item5.Doctrine != null)
						{
							item5.Doctrine = item5.Doctrine.CopyDoctrine(ref item5.Doctrine, item5, ref theScen);
						}
					}
				}
				if (flight2 != null)
				{
					flight2.Departed = true;
				}
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8.Data.Add("Error at 456783632323243343384", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (!Information.IsNothing((object)AircraftOrderedToTakeOff))
			{
				Flight flight3 = default(Flight);
				foreach (Aircraft item6 in AircraftOrderedToTakeOff)
				{
					Aircraft_AirOps airOps3 = item6.AirOps;
					if (airOps3.Condition == Aircraft_AirOps._AirOpsCondition.Parked && !airOps3.WaitForEscorts())
					{
						airOps3.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
					}
					if (item6.Navigator.HasFlight)
					{
						((ActiveUnit_Navigator)item6.Navigator).get_Flight(HierarchySearch: true).set_Status(theScen, _FlightStatus.TakingOff);
						flight3 = ((ActiveUnit_Navigator)item6.Navigator).get_Flight(HierarchySearch: true);
						item6.Doctrine = Doctrine.CopyDoctrine(ref Doctrine, item6, ref theScen);
					}
				}
				if (flight3 != null)
				{
					flight3.Departed = true;
				}
				if (AircraftOrderedToTakeOff.Count > 0 && MissionClass == _MissionClass.Strike)
				{
					((Strike)this).OneTimeOnlyFlown = true;
				}
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10.Data.Add("Error at 456723444243384", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			AirGroupsOrderedToTakeOff.Clear();
			AircraftOrderedToTakeOff.Clear();
			AircraftOrderedToTakeOff_Escort_Shooter?.Clear();
			AircraftOrderedToTakeOff_Escort_NonShooter?.Clear();
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			ex12.Data.Add("Error at 99494393535366", "");
			GameGeneral.WriteExceptionsToLog(ex12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Mission(Side theSide, Scenario theScen, string theName)
	{
		Category = MissionCategory.Mission;
		TimeSincePlayerNotification = 0;
		MasterFlightList = new HashSet<Flight>();
		FlightList = new List<Flight>();
		MultiplayerUpdateNeeded = false;
		IsPrivateSnapshot = false;
		FlightPlanPreventShotgunRTB = true;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		KeepOnMissionWithoutTankersInPlace = true;
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		Deactivation_UnassignUnits = false;
		Deactivation_OrderRTB = false;
		Deactivation_DeleteMission = false;
		OneThirdGrouping = OneThirdGroupingType.NoGrouping;
		UnitsEngagingInChainsaw = new List<ActiveUnit>();
		UnitsQueuedToMission = new Dictionary<ActiveUnit, ActiveUnit>();
		UnitsAssignedToMission = new ConcurrentDictionary<ActiveUnit, ActiveUnit>();
		UnitsAssignedToMissionIDs = new List<string>();
		_Phase = MissionPhase.OnHold;
		CreationMode = MissionCreationType.Unspecified;
		MissionStartTrigger_MissionCompleted = new Dictionary<Mission, Mission>();
		_MissionStartTrigger_MissionCompletedID = new List<string>();
		MarkedForBulkEdition = false;
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
		IsMission = true;
		Name = theName;
		theSide?.Missions_Add(this);
		DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
		SetDefaultFuelQtyToStartLookingForTanker_Airborne();
	}

	public void SetDefaultFuelQtyToStartLookingForTanker_Airborne()
	{
		if (MissionClass == _MissionClass.Strike)
		{
			FuelQtyToStartLookingForTanker_Airborne = 85;
		}
		else if (MissionClass == _MissionClass.Ferry)
		{
			FuelQtyToStartLookingForTanker_Airborne = 80;
		}
		else if (MissionClass == _MissionClass.Support)
		{
			FuelQtyToStartLookingForTanker_Airborne = 0;
		}
		else
		{
			FuelQtyToStartLookingForTanker_Airborne = 30;
		}
	}

	internal _ContinousCoverageMethod CCFlightGenerationMethodSelection_To_CCFlightGenerationMethodQty(ref int CCMethod)
	{
		_ContinousCoverageMethod result;
		try
		{
			result = CCMethod switch
			{
				1 => _ContinousCoverageMethod.FlightplanTemplates, 
				0 => _ContinousCoverageMethod.Dynamic, 
				_ => _ContinousCoverageMethod.Dynamic, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = (_ContinousCoverageMethod)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCFlightGenerationMethodQty_To_CCFlightGenerationMethodSelection(_ContinousCoverageMethod CCMethod)
	{
		int result;
		try
		{
			result = CCMethod switch
			{
				_ContinousCoverageMethod.Dynamic => 0, 
				_ContinousCoverageMethod.FlightplanTemplates => 1, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _ContinousCoverageStationTime CCStationTimeSelection_To_CCStationTimeQty(ref int CCStationTime)
	{
		_ContinousCoverageStationTime result;
		try
		{
			result = CCStationTime switch
			{
				0 => _ContinousCoverageStationTime.min_15, 
				1 => _ContinousCoverageStationTime.min_20, 
				2 => _ContinousCoverageStationTime.min_30, 
				3 => _ContinousCoverageStationTime.min_40, 
				4 => _ContinousCoverageStationTime.min_45, 
				5 => _ContinousCoverageStationTime.min_50, 
				6 => _ContinousCoverageStationTime.hr_1, 
				7 => _ContinousCoverageStationTime.hr_1_min_15, 
				8 => _ContinousCoverageStationTime.hr_1_min_30, 
				9 => _ContinousCoverageStationTime.hr_1_min_45, 
				10 => _ContinousCoverageStationTime.hr_2, 
				11 => _ContinousCoverageStationTime.hr_2_min_15, 
				12 => _ContinousCoverageStationTime.hr_2_min_30, 
				13 => _ContinousCoverageStationTime.hr_2_min_45, 
				14 => _ContinousCoverageStationTime.hr_3, 
				15 => _ContinousCoverageStationTime.hr_3_min_30, 
				16 => _ContinousCoverageStationTime.hr_4, 
				17 => _ContinousCoverageStationTime.hr_5, 
				18 => _ContinousCoverageStationTime.hr_6, 
				19 => _ContinousCoverageStationTime.hr_8, 
				20 => _ContinousCoverageStationTime.hr_10, 
				21 => _ContinousCoverageStationTime.hr_12, 
				_ => _ContinousCoverageStationTime.min_15, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = (_ContinousCoverageStationTime)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCStationTimeQty_To_CCStationTimeSelection(_ContinousCoverageStationTime CCStationTime)
	{
		int result;
		try
		{
			result = CCStationTime switch
			{
				_ContinousCoverageStationTime.min_15 => 0, 
				_ContinousCoverageStationTime.min_20 => 1, 
				_ContinousCoverageStationTime.min_30 => 2, 
				_ContinousCoverageStationTime.min_40 => 3, 
				_ContinousCoverageStationTime.min_45 => 4, 
				_ContinousCoverageStationTime.min_50 => 5, 
				_ContinousCoverageStationTime.hr_1 => 6, 
				_ContinousCoverageStationTime.hr_1_min_15 => 7, 
				_ContinousCoverageStationTime.hr_1_min_30 => 8, 
				_ContinousCoverageStationTime.hr_1_min_45 => 9, 
				_ContinousCoverageStationTime.hr_2 => 10, 
				_ContinousCoverageStationTime.hr_2_min_15 => 11, 
				_ContinousCoverageStationTime.hr_2_min_30 => 12, 
				_ContinousCoverageStationTime.hr_2_min_45 => 13, 
				_ContinousCoverageStationTime.hr_3 => 14, 
				_ContinousCoverageStationTime.hr_3_min_30 => 15, 
				_ContinousCoverageStationTime.hr_4 => 16, 
				_ContinousCoverageStationTime.hr_5 => 17, 
				_ContinousCoverageStationTime.hr_6 => 18, 
				_ContinousCoverageStationTime.hr_8 => 19, 
				_ContinousCoverageStationTime.hr_10 => 20, 
				_ContinousCoverageStationTime.hr_12 => 21, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCStationTimeQty_To_Minutes(_ContinousCoverageStationTime CCStationTime)
	{
		return CCStationTime switch
		{
			_ContinousCoverageStationTime.min_15 => 15, 
			_ContinousCoverageStationTime.min_20 => 20, 
			_ContinousCoverageStationTime.min_30 => 30, 
			_ContinousCoverageStationTime.min_40 => 40, 
			_ContinousCoverageStationTime.min_45 => 45, 
			_ContinousCoverageStationTime.min_50 => 50, 
			_ContinousCoverageStationTime.hr_1 => 60, 
			_ContinousCoverageStationTime.hr_1_min_15 => 75, 
			_ContinousCoverageStationTime.hr_1_min_30 => 90, 
			_ContinousCoverageStationTime.hr_1_min_45 => 105, 
			_ContinousCoverageStationTime.hr_2 => 120, 
			_ContinousCoverageStationTime.hr_2_min_15 => 135, 
			_ContinousCoverageStationTime.hr_2_min_30 => 150, 
			_ContinousCoverageStationTime.hr_2_min_45 => 165, 
			_ContinousCoverageStationTime.hr_3 => 180, 
			_ContinousCoverageStationTime.hr_3_min_30 => 210, 
			_ContinousCoverageStationTime.hr_4 => 240, 
			_ContinousCoverageStationTime.hr_5 => 300, 
			_ContinousCoverageStationTime.hr_6 => 360, 
			_ContinousCoverageStationTime.hr_8 => 480, 
			_ContinousCoverageStationTime.hr_10 => 600, 
			_ContinousCoverageStationTime.hr_12 => 720, 
			_ => 15, 
		};
	}

	internal _ContinousCoverageOverlap CCOverlapSelection_To_CCOverlapQty(ref int int_1)
	{
		_ContinousCoverageOverlap result;
		try
		{
			result = int_1 switch
			{
				0 => _ContinousCoverageOverlap.None, 
				1 => _ContinousCoverageOverlap.Min_2, 
				2 => _ContinousCoverageOverlap.Min_5, 
				_ => _ContinousCoverageOverlap.Min_2, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = (_ContinousCoverageOverlap)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCOverlapQty_To_CCOverlapSelection(_ContinousCoverageOverlap _ContinousCoverageOverlap_0)
	{
		int result;
		try
		{
			result = _ContinousCoverageOverlap_0 switch
			{
				_ContinousCoverageOverlap.None => 0, 
				_ContinousCoverageOverlap.Min_2 => 1, 
				_ContinousCoverageOverlap.Min_5 => 2, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCOverlapQty_To_Minutes(_ContinousCoverageOverlap _ContinousCoverageOverlap_0)
	{
		int result;
		try
		{
			result = _ContinousCoverageOverlap_0 switch
			{
				_ContinousCoverageOverlap.None => 0, 
				_ContinousCoverageOverlap.Min_2 => 2, 
				_ContinousCoverageOverlap.Min_5 => 5, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal _ContinousCoverageDuration CCDurationSelection_To_CCDurationQty(ref int int_1)
	{
		_ContinousCoverageDuration result;
		try
		{
			result = int_1 switch
			{
				0 => _ContinousCoverageDuration.hr_2, 
				1 => _ContinousCoverageDuration.hr_4, 
				2 => _ContinousCoverageDuration.hr_6, 
				3 => _ContinousCoverageDuration.hr_12, 
				4 => _ContinousCoverageDuration.hr_24, 
				_ => _ContinousCoverageDuration.hr_6, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 2;
			}
			else
			{
				Debugger.Break();
				num = 2;
			}
			result = (_ContinousCoverageDuration)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCDurationQty_To_CCDurationSelection(_ContinousCoverageDuration _ContinousCoverageDuration_0)
	{
		int result;
		try
		{
			result = _ContinousCoverageDuration_0 switch
			{
				_ContinousCoverageDuration.hr_2 => 0, 
				_ContinousCoverageDuration.hr_4 => 1, 
				_ContinousCoverageDuration.hr_6 => 2, 
				_ContinousCoverageDuration.hr_12 => 3, 
				_ContinousCoverageDuration.hr_24 => 4, 
				_ => 2, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 2;
			}
			else
			{
				num = 2;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CCDurationQty_To_Hours(_ContinousCoverageDuration _ContinousCoverageDuration_0)
	{
		int result;
		try
		{
			result = _ContinousCoverageDuration_0 switch
			{
				_ContinousCoverageDuration.hr_2 => 2, 
				_ContinousCoverageDuration.hr_4 => 4, 
				_ContinousCoverageDuration.hr_6 => 6, 
				_ContinousCoverageDuration.hr_12 => 12, 
				_ContinousCoverageDuration.hr_24 => 24, 
				_ => 2, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 2;
			}
			else
			{
				num = 2;
			}
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int GroupSize_To_ActualGroupQty(ref _GroupSize theGroupSize, ref _GroupQty theGroupQty)
	{
		int result;
		switch (theGroupQty)
		{
		default:
			result = 0;
			goto IL_0044;
		case _GroupQty.None:
			return 0;
		case _GroupQty.All:
			return int.MaxValue;
		case (_GroupQty)(-98):
			result = 0;
			goto IL_0044;
		case _GroupQty.Group_x1:
			return theGroupSize;
		case _GroupQty.Group_x2:
			return (int)theGroupSize * 2;
		case _GroupQty.Group_x3:
			return (int)theGroupSize * 3;
		case _GroupQty.Group_x4:
			return (int)theGroupSize * 4;
		case _GroupQty.Group_x6:
			return (int)theGroupSize * 6;
		case _GroupQty.Group_x8:
			return (int)theGroupSize * 8;
		case _GroupQty.Group_x12:
			{
				return (int)theGroupSize * 12;
			}
			IL_0044:
			return result;
		}
	}

	internal _GroupQty GroupInvestigateEngageSelection_To_GroupQty(ref int GroupQty)
	{
		_GroupQty result;
		try
		{
			result = GroupQty switch
			{
				0 => _GroupQty.All, 
				1 => _GroupQty.None, 
				2 => _GroupQty.Group_x1, 
				3 => _GroupQty.Group_x2, 
				4 => _GroupQty.Group_x3, 
				5 => _GroupQty.Group_x4, 
				6 => _GroupQty.Group_x6, 
				7 => _GroupQty.Group_x8, 
				8 => _GroupQty.Group_x12, 
				_ => _GroupQty.All, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = -99;
			}
			else
			{
				Debugger.Break();
				num = -99;
			}
			result = (_GroupQty)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int GroupInvestigateEngageQty_To_GroupSelection(_GroupQty GroupQty)
	{
		int result;
		try
		{
			int num;
			switch (GroupQty)
			{
			default:
				num = 0;
				goto IL_0042;
			case _GroupQty.None:
				result = 1;
				break;
			case _GroupQty.All:
				result = 0;
				break;
			case (_GroupQty)(-98):
				num = 0;
				goto IL_0042;
			case _GroupQty.Group_x1:
				result = 2;
				break;
			case _GroupQty.Group_x2:
				result = 3;
				break;
			case _GroupQty.Group_x3:
				result = 4;
				break;
			case _GroupQty.Group_x4:
				result = 5;
				break;
			case _GroupQty.Group_x6:
				result = 6;
				break;
			case _GroupQty.Group_x8:
				result = 7;
				break;
			case _GroupQty.Group_x12:
				{
					result = 8;
					break;
				}
				IL_0042:
				result = num;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal void TemporaryChainsawFPCompatibilityHandler(bool setChainsaw)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("WARNING!\r\n\r\nChainsaw movement style is not currently supported with custom time to take off or time to station.\r\n\r\n");
		if (!setChainsaw)
		{
			stringBuilder.Append("Resetting movement style back To Random within the area...");
			((Patrol)this).MovementStyle = Patrol.PatrolMovementStyle.RandomWithinArea;
		}
		else
		{
			stringBuilder.Append("Resetting Time Stamps...");
			TakeOffTime = null;
			TimeOnTarget = null;
		}
		DarkMessageBox.ShowWarning(stringBuilder.ToString(), "Mission: " + Name);
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		try
		{
			if (TankerMissions_IDs.Count > 0)
			{
				Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					foreach (Mission mission in side.Missions)
					{
						if (TankerMissions_IDs.Contains(mission.ObjectID))
						{
							TankerMissions.Add(mission);
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(_SecondaryAirBaseID) && ObjectsDictionary.ContainsKey(_SecondaryAirBaseID))
			{
				SecondaryAirBase = (ActiveUnit)ObjectsDictionary[_SecondaryAirBaseID];
			}
			if (!string.IsNullOrEmpty(_SecondaryNavalBaseID) && ObjectsDictionary.ContainsKey(_SecondaryNavalBaseID))
			{
				SecondaryNavalBase = (ActiveUnit)ObjectsDictionary[_SecondaryNavalBaseID];
			}
			if (!HasFlights())
			{
				return;
			}
			foreach (Flight flight in FlightList)
			{
				if (!string.IsNullOrEmpty(flight.ReferenceUnit_ObjectID) && theScen.ActiveUnits.ContainsKey(flight.ReferenceUnit_ObjectID))
				{
					flight.set_ReferenceUnit((Scenario)null, theScen.ActiveUnits[flight.ReferenceUnit_ObjectID]);
				}
				if (!string.IsNullOrEmpty(flight.TaskPool_ID))
				{
					Side[] sides_ReadOnly2 = theScen.Sides_ReadOnly;
					foreach (Side side2 in sides_ReadOnly2)
					{
						foreach (Mission mission2 in side2.Missions)
						{
							if (flight.TaskPool_ID.Contains(mission2.ObjectID))
							{
								flight.TaskPool = mission2;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(flight.PrimaryTarget_ID))
				{
					continue;
				}
				Side[] sides_ReadOnly3 = theScen.Sides_ReadOnly;
				foreach (Side side3 in sides_ReadOnly3)
				{
					if (side3.Contacts.ContainsKey(flight.PrimaryTarget_ID))
					{
						flight.PrimaryTarget = side3.Contacts[flight.PrimaryTarget_ID];
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool HasInactiveFlights()
	{
		if (FlightList != null)
		{
			foreach (Flight flight in FlightList)
			{
				if (!flight.get_IsActive((IList<ActiveUnit>)null))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool HasFlights()
	{
		int result;
		if (FlightList != null)
		{
			if (FlightList.Count != 0)
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal bool HasFlightPlans()
	{
		if (!HasFlights())
		{
			return false;
		}
		foreach (Flight flight in FlightList)
		{
			if (!Information.IsNothing((object)flight.FlightPlan) && flight.FlightPlan.Count() > 0)
			{
				return true;
			}
		}
		return false;
	}

	public void RemoveFlightsWithoutAircraft(Scenario theScen, Side theSide)
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit unit in theSide.Units)
			{
				if (!unit.IsGroupMember() && (!unit.IsWeapon || ((Weapon)unit).Type != Weapon._WeaponType.Sonobuoy) && unit.ActiveMissionOrPackage() == this && unit.IsAircraft && !Information.IsNothing((object)unit.Navigator.get_Flight(HierarchySearch: true)))
				{
					list.Add(unit);
				}
			}
			bool flag = false;
			List<Flight> list2 = new List<Flight>();
			foreach (Flight flight in FlightList)
			{
				flag = false;
				foreach (ActiveUnit item in list)
				{
					if (item.Navigator.get_Flight(HierarchySearch: true) == flight)
					{
						flag = true;
						list.Remove(item);
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				if (!Information.IsNothing((object)EmptySlotsList))
				{
					foreach (EmptyAircraftSlot emptySlots in EmptySlotsList)
					{
						if (!Information.IsNothing((object)emptySlots.get_MissionFlight(theScen)) && emptySlots.get_MissionFlight(theScen) == flight)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					list2.Add(flight);
				}
			}
			foreach (Flight item2 in list2)
			{
				Flight theSelectedFlight = item2;
				DeleteFlight(ref theScen, ref theSide, ref theSelectedFlight, theSelectedFlight.ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlight(ref Scenario theScen, ref Side theSide, ref Flight theSelectedFlight, string theSelectedFlight_ObjectID)
	{
		try
		{
			if (Information.IsNothing((object)theSelectedFlight))
			{
				return;
			}
			foreach (ActiveUnit unit in theSide.Units)
			{
				if (unit != null && unit.Navigator.HasFlight && Operators.CompareString(unit.Navigator.get_Flight(HierarchySearch: true).ObjectID, theSelectedFlight_ObjectID, false) == 0)
				{
					unit.Navigator.ClearFlight();
				}
			}
			if (!Information.IsNothing((object)EmptySlotsList))
			{
				for (int i = EmptySlotsList.Count - 1; i >= 0; i += -1)
				{
					EmptyAircraftSlot emptyAircraftSlot = EmptySlotsList[i];
					if ((emptyAircraftSlot.get_MissionFlight(theScen) == theSelectedFlight) | (emptyAircraftSlot.get_MissionFlight(theScen) == null))
					{
						EmptySlotsList.Remove(emptyAircraftSlot);
						emptyAircraftSlot = null;
					}
				}
			}
			if (theScen.MissionPlannerErrorList != null)
			{
				for (int j = theScen.MissionPlannerErrorList.Count - 1; j >= 0; j += -1)
				{
					MDSP_Error mDSP_Error = theScen.MissionPlannerErrorList[j];
					if (mDSP_Error != null && Operators.CompareString(mDSP_Error.Flight, theSelectedFlight.Callsign, false) == 0)
					{
						theScen.MissionPlannerErrorList.Remove(mDSP_Error);
					}
				}
			}
			RemoveFlight(theSelectedFlight);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlightplan(ref Scenario theScen, ref Side theSide, ref Flight theSelectedFlight)
	{
		try
		{
			theSelectedFlight.ClearFlightPlan();
			for (int i = theScen.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
			{
				MDSP_Error mDSP_Error = theScen.MissionPlannerErrorList[i];
				if (Operators.CompareString(mDSP_Error.Flight, theSelectedFlight.Callsign, false) == 0)
				{
					theScen.MissionPlannerErrorList.Remove(mDSP_Error);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveFlight(Flight theF)
	{
		try
		{
			if (!Information.IsNothing((object)theF) && FlightList.Contains(theF))
			{
				FlightList.Remove(theF);
				theF = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddFlight(ref Flight theF)
	{
		try
		{
			if (!Information.IsNothing((object)theF) && !FlightList.Contains(theF))
			{
				FlightList.Add(theF);
				MultiplayerUpdateNeeded = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddMasterFlight(ref Flight theMF)
	{
		try
		{
			if (theMF != null)
			{
				MasterFlightList.Add(theMF);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteMission(ref Scenario theScen, ref Side theSide, bool BypassWarning = false)
	{
		try
		{
			foreach (ActiveUnit unit in theSide.Units)
			{
				if (unit != null && unit.ActiveMissionOrPackage() == this)
				{
					MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
					unit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				}
			}
			if (Category == MissionCategory.TaskPool)
			{
				TaskPool taskPool = (TaskPool)this;
				foreach (ActiveUnit unit2 in theSide.Units)
				{
					if (unit2.AssignedTaskPool == this)
					{
						unit2.AssignedTaskPool = null;
					}
				}
				for (int i = taskPool.PackageList.Count - 1; i >= 0; i += -1)
				{
					Mission mission = taskPool.PackageList[i];
					foreach (ActiveUnit unit3 in theSide.Units)
					{
						if (unit3.ActiveMissionOrPackage() == mission)
						{
							unit3.AssignedTaskPool = null;
						}
					}
					mission.DeleteMission(ref theScen, ref theSide);
				}
			}
			foreach (Mission item in theSide.get_MissionsTotal(theScen))
			{
				if (item == null)
				{
					continue;
				}
				if (item.TankerMissions.Contains(this))
				{
					item.TankerMissions.Remove(this);
				}
				if (item.TankerMissions_IDs.Contains(ObjectID))
				{
					item.TankerMissions_IDs.Remove(ObjectID);
				}
				foreach (Flight flight in item.FlightList)
				{
					if (Information.IsNothing((object)flight) || flight.FlightPlan.Count() == 0)
					{
						continue;
					}
					Waypoint[] flightPlan = flight.FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						if (waypoint.TankerMissions.Contains(this))
						{
							waypoint.TankerMissions.Remove(this);
						}
						if (waypoint.TankerMissions_IDs.Contains(ObjectID))
						{
							waypoint.TankerMissions_IDs.Remove(ObjectID);
						}
					}
				}
			}
			DeleteFlights(ref theScen, ref theSide);
			theSide.Missions_Remove(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlights(ref Scenario theScen, ref Side theSide)
	{
		for (int i = FlightList.Count - 1; i >= 0; i += -1)
		{
			Flight theSelectedFlight = FlightList[i];
			DeleteFlight(ref theScen, ref theSide, ref theSelectedFlight, theSelectedFlight.ObjectID);
		}
	}

	internal Mission CloneMission(ref Scenario theScen, ref Side theSide)
	{
		Mission result = default(Mission);
		try
		{
			List<Flight> flightList = FlightList.ToList();
			UnitsAssignedToMission.ToList();
			Mission mission = Clone(DeepCloneRPs: false);
			mission.FlightList.Clear();
			mission.UnitsAssignedToMission.Clear();
			ObjectID_Set(IDGenerator.Instance.Next);
			mission.Doctrine = Doctrine.CopyDoctrine(ref Doctrine, mission, ref theScen);
			FlightList = flightList;
			mission.TankerMissions = new List<Mission>();
			theSide.Missions_Add(mission);
			result = mission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "CloneMission");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal Aircraft CreateEmptySlotReferenceUnit(ref Scenario theScen, ref Side theSide, int theDBID, int theLoadoutDBID, ref ActiveUnit theHost, ref Flight theFlight, bool theUnitIsEscort, int theSlotNo)
	{
		Aircraft result;
		try
		{
			Aircraft theAircraft = new Aircraft(ref theScen);
			if (theDBID > 0)
			{
				DBFunctions.GetAircraft(ref theScen, ref theAircraft, theDBID);
			}
			theAircraft.Name = "Empty Slot " + Conversions.ToString(theSlotNo) + " (" + theAircraft.UnitClass + ")";
			((ActiveUnit)theAircraft).set_UnitSide(SetSideOnly: false, theSide);
			theAircraft.AI.IsEscort = theUnitIsEscort;
			if (!Information.IsNothing((object)theHost))
			{
				theAircraft.AirOps.CurrentHostUnit = theHost;
				if (!Information.IsNothing((object)theAircraft.AirOps.CurrentHostUnit))
				{
					theAircraft.set_Latitude((GlobalVariables.BooleanObject)null, theAircraft.AirOps.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null));
					theAircraft.set_Longitude((GlobalVariables.BooleanObject)null, theAircraft.AirOps.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				}
			}
			if (theLoadoutDBID > 0)
			{
				Loadout loadout = DBFunctions.GetLoadout(ref theScen, theLoadoutDBID, ExcludeOptionalWeapons: false, GetPayloadWeight: true);
				theAircraft.Loadout = loadout;
			}
			else
			{
				Loadout loadout2 = new Loadout(0, "No loadout", 0, 0, 0, 0, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.None, Loadout._LoadoutWeather.None, 0f, int.MaxValue, 0, theReBuddyIllum: false, ExcludeOptionalWeapons: false, theQuickTurnaround: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.None, Doctrine._WeaponState.NotConfigured);
				theAircraft.Loadout = loadout2;
			}
			Aircraft aircraft = theAircraft;
			MissionAssignmentAttemptResult Result = MissionAssignmentAttemptResult.None;
			aircraft.Set_AssignedMissionOrPackage(this, SetMissionOnly: true, IgnoreCommsState: false, ref Result);
			((ActiveUnit_Navigator)theAircraft.Navigator).set_Flight(HierarchySearch: true, theFlight);
			result = theAircraft;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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

	public static _TankerFollowsReceiver FollowReceiversSelection_To_FollowReceiversNumber(int WaypointNumber)
	{
		_TankerFollowsReceiver result;
		try
		{
			result = WaypointNumber switch
			{
				0 => _TankerFollowsReceiver.UntilFull, 
				1 => _TankerFollowsReceiver.Waypoint1, 
				2 => _TankerFollowsReceiver.Waypoint2, 
				3 => _TankerFollowsReceiver.Weaypoin3, 
				4 => _TankerFollowsReceiver.UntilHoldWaypoint, 
				5 => _TankerFollowsReceiver.UntilStationWaypoint, 
				6 => _TankerFollowsReceiver.UntilLandingMarshalWaypoint, 
				_ => _TankerFollowsReceiver.UntilFull, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = (_TankerFollowsReceiver)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int FollowReceiversNumber_To_FollowReceiversSelection(int WaypointNumber)
	{
		int result;
		try
		{
			result = WaypointNumber switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				-99 => 6, 
				-98 => 5, 
				-97 => 4, 
				_ => 0, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 999999", "");
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
			result = num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual Mission Clone(bool DeepCloneRPs)
	{
		throw new NotImplementedException();
	}

	internal static float SplitDistanceToNumber(_SplitDistance splitDistance)
	{
		float num = default(float);
		return splitDistance switch
		{
			_SplitDistance.Close_10nm => 10f, 
			_SplitDistance.Typical_20nm => 20f, 
			_SplitDistance.Long_50nm => 50f, 
			_ => num, 
		};
	}

	static Mission()
	{
		Class72.smethod_20();
	}
}
