using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Aircraft_AirOps : ActiveUnit_AirOps
{
	public delegate void TookOffEventHandler(Aircraft theAircraft);

	public delegate void LandingEventHandler(Aircraft theAircraft);

	public delegate void ReachedBingoFuelEventHandler(Aircraft theAircraft);

	public delegate void HostAirFacilityChangedEventHandler(string UnitObjectID);

	public delegate void AirOpsStatusChangeEventHandler(ActiveUnit theUnit, object oldStatus);

	public enum TakeOffCheck
	{
		OK = 0,
		unsufficient_runway_length = 10,
		runway_is_to_small = 20,
		runway_altitude = 30,
		not_catapult_lauchable = 40,
		other_issue = 1000
	}

	private enum Enum6 : byte
	{

	}

	public enum _AirOpsCondition : byte
	{
		Airborne,
		Parked,
		TaxyingToTakeOff,
		TaxyingToPark,
		TakingOff,
		Landing_PreTouchdown,
		Landing_PostTouchdown,
		Readying,
		HoldingForAvailableTransit,
		HoldingForAvailableRunway,
		HoldingOnLandingQueue,
		RTB,
		PreparingToLaunch,
		ManoeuveringToRefuel,
		Refuelling,
		OffloadingFuel,
		DeployingDippingSonar,
		EmergencyLanding,
		TaxyingToFlightDeck,
		const_19,
		BVRCrank,
		Dogfight,
		TransferringCargo,
		BVRDrag,
		HoldingPattern_CommsLost
	}

	public enum RefuelScheduleReason : byte
	{
		None,
		RescheduleAfterDisconnect,
		WingmanRequestingLeadRefuel,
		FuelStateReachedWhileExhausted,
		FlightPlanMandatedRefuel,
		TopUpRefuelIngress,
		TopUpRefuelEgress,
		OnStrikeFarFromBase,
		AutoPlannerCruiseAndAttackEgressRun,
		EscortedMissionStrikersAreRefueling
	}

	public struct TankerQueueInformation
	{
		public float timeToStartRefueling;

		public int aircraftsInQueueBefore;

		public int aircraftsInQueueAfter;
	}

	public class MissionPlanner_PostponedRefuelling_Info
	{
		public List<string> list_0;

		public bool forcePostponedAll;

		public MissionPlanner_PostponedRefuelling_Info(bool forcePostponedAll = false)
		{
			list_0 = new List<string>();
			this.forcePostponedAll = forcePostponedAll;
		}

		public void Add(string tankerID)
		{
			list_0.Add(tankerID);
		}

		public bool hasPostponedForThisTanker(string tankerID)
		{
			if (forcePostponedAll)
			{
				return true;
			}
			return list_0.Contains(tankerID);
		}

		public bool hasPostponedForAnyTanker()
		{
			if (!forcePostponedAll)
			{
				return list_0.Count > 0;
			}
			return true;
		}

		static MissionPlanner_PostponedRefuelling_Info()
		{
			Class72.smethod_20();
		}
	}

	public enum GEnum0 : byte
	{
		Drogue,
		Boom,
		BuddyDrogue
	}

	[CompilerGenerated]
	internal sealed class _Closure$__108-0
	{
		public Aircraft $VB$Local_ReceiverAC;

		public Aircraft_AirOps $VB$Me;

		public Func<ActiveUnit, bool> $I0;

		public _Closure$__108-0(_Closure$__108-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ReceiverAC = arg0.$VB$Local_ReceiverAC;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theAC)
		{
			return (theAC.RangeToUnit_Horiz($VB$Local_ReceiverAC) < 2f) & (theAC != $VB$Me.method_0());
		}

		static _Closure$__108-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public double $VB$Local_RangeToTarget_Angular;

		public _Closure$__163-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_RangeToTarget_Angular = arg0.$VB$Local_RangeToTarget_Angular;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Aircraft theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular($VB$NonLocal_$VB$Closure_2.$VB$Me.method_0(), theT) >= $VB$Local_RangeToTarget_Angular)
			{
				return false;
			}
			return Module_Unit.RangeToPoint_Horiz_Angular(theT, $VB$NonLocal_$VB$Closure_2.$VB$Local_IntermediateTargetPoint) < $VB$Local_RangeToTarget_Angular;
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-1
	{
		public GeoPoint $VB$Local_IntermediateTargetPoint;

		public Aircraft_AirOps $VB$Me;

		public _Closure$__163-1(_Closure$__163-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_IntermediateTargetPoint = arg0.$VB$Local_IntermediateTargetPoint;
			}
		}

		static _Closure$__163-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-2
	{
		public double $VB$Local_RangeToBase_Angular;

		public _Closure$__163-3 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__163-2(_Closure$__163-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_RangeToBase_Angular = arg0.$VB$Local_RangeToBase_Angular;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Aircraft theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular($VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Me.method_0(), theT) >= $VB$Local_RangeToBase_Angular)
			{
				return false;
			}
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, $VB$NonLocal_$VB$Closure_4.$VB$Local_myHost) < $VB$Local_RangeToBase_Angular;
		}

		static _Closure$__163-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-3
	{
		public ActiveUnit $VB$Local_myHost;

		public _Closure$__163-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__163-3(_Closure$__163-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myHost = arg0.$VB$Local_myHost;
			}
		}

		static _Closure$__163-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__66-0
	{
		public ActiveUnit $VB$Local_theAU;

		public _Closure$__66-0(_Closure$__66-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal double _Lambda$__0(ActiveUnit theCand)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theCand, $VB$Local_theAU);
		}

		static _Closure$__66-0()
		{
			Class72.smethod_20();
		}
	}

	private _AirOpsCondition _AirOpsCondition_0;

	private _AirOpsCondition _AirOpsCondition_1;

	private float float_0;

	private AirFacility airFacility_0;

	private string string_0;

	private ActiveUnit activeUnit_0;

	private string string_1;

	private ActiveUnit activeUnit_1;

	private string string_2;

	private Aircraft aircraft_0;

	private string string_3;

	public TDictionary<string, byte> RefuellingQueue;

	public TDictionary<string, GEnum0> A2AR_Connections;

	public List<ActiveUnit.ActiveUnit_Struct> A2AR_NumberOfReceiverHookups;

	public bool QuickTurnaround_Enabled;

	public int QuickTurnaround_SortiesFlown;

	public int QuickTurnaround_SortiesTotal;

	public int QuickTurnaround_TimePentalty;

	public float QuickTurnaround_AirborneTime_Flown;

	public float QuickTurnaround_AirborneTime_SortieAverage;

	public float TankerHookUpDistance;

	public float TankerHookUpDistance_Wingmen;

	internal bool TestBoolean;

	public Doctrine.EMCONSettings._EMCONSetting? ActiveRadarDoctrineBeforeRefueling;

	public bool? EMCONInheritFromParentBeforeRefueling;

	public bool ManuallySelectedA2AR_Destination;

	[CompilerGenerated]
	private static TookOffEventHandler tookOffEventHandler_0;

	[CompilerGenerated]
	private static LandingEventHandler landingEventHandler_0;

	[CompilerGenerated]
	private static ReachedBingoFuelEventHandler reachedBingoFuelEventHandler_0;

	private Aircraft aircraft_1;

	[CompilerGenerated]
	private static HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler_0;

	public static int HelicopterDippingSonarAltitude;

	internal float OverrideConditionTimer;

	[CompilerGenerated]
	private static AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler_0;

	public bool QueuedTakeOff;

	public bool BadWeatherFlag;

	public string WeatherString;

	private LockObject lockObject_0;

	public ActiveUnit ActualDestinationHost
	{
		get
		{
			ActiveUnit result;
			try
			{
				ActiveUnit activeUnit = null;
				Mission mission = myUnit.ActiveMissionOrPackage();
				if (!Information.IsNothing((object)mission))
				{
					if (mission.MissionClass == Mission._MissionClass.Ferry)
					{
						if (Information.IsNothing((object)((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen)))
						{
							string text = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text = " (" + myUnit.UnitClass + ")";
							}
							myUnit.AddMessage(myUnit.Name + text + " is no longer able to execute ferry mission: " + mission.Name + " (the ferry destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " cannot execute ferry", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							ActiveUnit activeUnit2 = myUnit;
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
							activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: true);
						}
						switch (((FerryMission)mission).Behavior)
						{
						default:
							activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: true);
							break;
						case FerryMission.FerryMissionBehavior.OneWay:
						{
							ActiveUnit activeUnit4 = ((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen);
							activeUnit = ((!myUnit.ParentScen.FifthSecondIsChangingOnThisPulse || ThisUnitCanHostMe(activeUnit4, HumanFeedbackNeeded: false).ResponseBoolean) ? activeUnit4 : null);
							break;
						}
						case FerryMission.FerryMissionBehavior.Cycle:
						{
							if (!myUnit.AI.GetMissionStateFlag(4u))
							{
								activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: true);
								break;
							}
							ActiveUnit activeUnit3 = ((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen);
							activeUnit = ((!myUnit.ParentScen.FifthSecondIsChangingOnThisPulse || ThisUnitCanHostMe(activeUnit3, HumanFeedbackNeeded: false).ResponseBoolean) ? activeUnit3 : null);
							break;
						}
						case FerryMission.FerryMissionBehavior.Random:
							activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: true);
							break;
						}
					}
					else if (mission.MissionClass == Mission._MissionClass.Cargo && ((CargoMission)mission).Type == CargoMission.CargoMissionType.Transfer)
					{
						CargoMission cargoMission = (CargoMission)mission;
						if (cargoMission.DestinationUnit == null || !myUnit.ParentScen.ActiveUnits.Keys.Contains(cargoMission.DestinationUnit.ObjectID))
						{
							string text2 = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text2 = " (" + myUnit.UnitClass + ")";
							}
							myUnit.AddMessage(myUnit.Name + text2 + " is no longer able to execute cargo mission: " + mission.Name + " (the cargo destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " cannot execute cargo mission", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							ActiveUnit activeUnit5 = myUnit;
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							activeUnit5.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
							activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
						}
						activeUnit = ((myUnit.OnboardCargo.Count() <= 0) ? this.get_AssignedHostUnit(PickNewAssignedHost: false) : cargoMission.DestinationUnit);
					}
					else
					{
						activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: true);
					}
					if (activeUnit != null && activeUnit.IsGroupMember() && activeUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation)
					{
						activeUnit = activeUnit.get_ParentGroup(UsingMissionPlanner: false);
					}
					result = activeUnit;
				}
				else
				{
					result = this.get_AssignedHostUnit(PickNewAssignedHost: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100406", "");
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
	}

	public bool IsTakingOff
	{
		get
		{
			int result;
			switch (Condition)
			{
			default:
				result = 0;
				goto IL_0044;
			case _AirOpsCondition.HoldingForAvailableTransit:
				if (HostAirFacility.IsParkingFacility())
				{
					return true;
				}
				return false;
			case _AirOpsCondition.HoldingOnLandingQueue:
			case _AirOpsCondition.RTB:
				result = 0;
				goto IL_0044;
			case _AirOpsCondition.TaxyingToTakeOff:
			case _AirOpsCondition.TakingOff:
			case _AirOpsCondition.HoldingForAvailableRunway:
			case _AirOpsCondition.PreparingToLaunch:
				{
					return true;
				}
				IL_0044:
				return (byte)result != 0;
			}
		}
	}

	public bool IsCompletingLanding
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public int A2AR_Tanker_FuelReservation
	{
		get
		{
			int result;
			try
			{
				PooledList<string> pooledList = new PooledList<string>(RefuellingQueue.Keys);
				foreach (string item in pooledList)
				{
					if (!string.IsNullOrEmpty(item))
					{
						method_0().ParentScen.ActiveUnits.TryGetValue(item, out var value);
						if (value == null || value.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
						{
							RefuellingQueue.Remove(item);
						}
					}
				}
				pooledList = new PooledList<string>(RefuellingQueue.Keys);
				if (ExcludeThisUnit != null && pooledList.Contains(ExcludeThisUnit.ObjectID))
				{
					pooledList.Remove(ExcludeThisUnit.ObjectID);
				}
				if (ExcludeThisGroup != null)
				{
					foreach (ActiveUnit value3 in ExcludeThisGroup.Units.Values)
					{
						if (pooledList.Contains(value3.ObjectID))
						{
							pooledList.Remove(value3.ObjectID);
						}
					}
				}
				int num = default(int);
				foreach (string item2 in pooledList)
				{
					if (!string.IsNullOrEmpty(item2) && method_0().ParentScen.ActiveUnits.TryGetValue(item2, out var value2))
					{
						bool? flag = value2?.IsMorituri;
						if (((!flag) ?? flag) == true)
						{
							num = ((!ThisUnitIsAlreadyClient) ? (num + value2.FuelCapacityMax) : (num + (int)Math.Round((double)value2.FuelCapacityMax * 0.1)));
						}
					}
				}
				pooledList.Dispose();
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100407", "");
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
	}

	public Aircraft A2AR_Destination
	{
		get
		{
			return aircraft_0;
		}
		set
		{
			try
			{
				if (value != aircraft_0 && aircraft_0 != null && aircraft_0.AirOps != null)
				{
					try
					{
						aircraft_0.AirOps.RefuellingQueue.Remove(method_0().ObjectID);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200020", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				aircraft_0 = value;
				if (value != null && !aircraft_0.AirOps.RefuellingQueue.ContainsKey(method_0().ObjectID))
				{
					try
					{
						aircraft_0.AirOps.RefuellingQueue.AddIfNotExistsElseUpdate(method_0().ObjectID, 0);
						return;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						aircraft_0.AirOps.RefuellingQueue.AddIfNotExistsElseUpdate(method_0().ObjectID, 0);
						ProjectData.ClearProjectError();
						return;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100408", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public ActiveUnit CurrentHostUnit
	{
		get
		{
			ActiveUnit result = default(ActiveUnit);
			try
			{
				if (activeUnit_0 != null)
				{
					if (activeUnit_0.IsGroupMember() && activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						Group.GroupType type = activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Type;
						if (type == Group.GroupType.Installation || type - 5 <= Group.GroupType.SurfaceGroup)
						{
							activeUnit_0 = activeUnit_0.get_ParentGroup(UsingMissionPlanner: false);
						}
					}
				}
				else
				{
					if (HostAirFacility == null)
					{
						result = null;
						return result;
					}
					ActiveUnit[] array = method_0().ParentScen.ActiveUnits_List.InternalArray();
					foreach (ActiveUnit activeUnit in array)
					{
						if (activeUnit != null && activeUnit.AirFacilities_ReadOnly.Contains(HostAirFacility))
						{
							activeUnit_0 = activeUnit;
							break;
						}
					}
				}
				result = activeUnit_0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100413", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			activeUnit_0 = value;
		}
	}

	public ActiveUnit AssignedHostUnit
	{
		get
		{
			ActiveUnit result = default(ActiveUnit);
			try
			{
				if (PickNewAssignedHost)
				{
					if (activeUnit_1 != null)
					{
						ActiveUnit activeUnit = activeUnit_1;
						if (activeUnit == null || !activeUnit.IsMorituri)
						{
							goto IL_0025;
						}
					}
					PickNewAssignedHost_Nearest();
				}
				goto IL_0025;
				IL_0025:
				result = activeUnit_1;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100414", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			activeUnit_1 = value;
		}
	}

	public AirFacility HostAirFacility
	{
		get
		{
			return airFacility_0;
		}
		set
		{
			try
			{
				if (airFacility_0 != null)
				{
					airFacility_0.HostedAircraft.Remove(myUnit.ObjectID);
				}
				if (value != null && !value.HostedAircraft.ContainsKey(myUnit.ObjectID))
				{
					value.HostedAircraft.Add(myUnit.ObjectID, method_0());
				}
				bool num = airFacility_0 != value;
				AirFacility airFacility = airFacility_0;
				airFacility_0 = value;
				if (num)
				{
					if (airFacility_0 != null)
					{
						CurrentHostUnit = airFacility_0.ParentPlatform;
					}
					else
					{
						CurrentHostUnit = null;
					}
					if (airFacility != null && airFacility_0 != null && ((airFacility_0.IsOpenAirFacility & !airFacility.IsOpenAirFacility) || (!airFacility_0.IsOpenAirFacility & airFacility.IsOpenAirFacility)))
					{
						method_1(airFacility);
					}
					hostAirFacilityChangedEventHandler_0?.Invoke(method_0().ObjectID);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200569", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _AirOpsCondition OldCondition => _AirOpsCondition_1;

	public _AirOpsCondition Condition
	{
		get
		{
			return _AirOpsCondition_0;
		}
		set
		{
			bool num = _AirOpsCondition_0 != value;
			_AirOpsCondition_1 = _AirOpsCondition_0;
			if (num)
			{
				if (value == _AirOpsCondition.RTB && _AirOpsCondition_0 == _AirOpsCondition.Refuelling)
				{
					DisconnectFromTanker();
				}
				_AirOpsCondition_0 = value;
				_AirOpsCondition airOpsCondition_ = _AirOpsCondition_0;
				if (airOpsCondition_ != _AirOpsCondition.Airborne && airOpsCondition_ != _AirOpsCondition.const_19 && airOpsCondition_ != _AirOpsCondition.BVRCrank && airOpsCondition_ != _AirOpsCondition.BVRDrag && airOpsCondition_ != _AirOpsCondition.Dogfight)
				{
					if ((airOpsCondition_ >= _AirOpsCondition.Parked && airOpsCondition_ <= _AirOpsCondition.TaxyingToFlightDeck) || airOpsCondition_ == _AirOpsCondition.TransferringCargo)
					{
						airOpsStatusChangeEventHandler_0?.Invoke(myUnit, _AirOpsCondition_1);
					}
				}
				else if ((_AirOpsCondition_0 == _AirOpsCondition.Airborne) & (_AirOpsCondition_1 < _AirOpsCondition.const_19))
				{
					airOpsStatusChangeEventHandler_0?.Invoke(myUnit, _AirOpsCondition_1);
				}
				myUnit.Kinematics.ExportLocationEvent("AirOpsConditionChanged");
				if (QueuedTakeOff && OldCondition == _AirOpsCondition.Readying && value == _AirOpsCondition.Parked)
				{
					AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
				}
				QueuedTakeOff = false;
				if (myUnit.AssignedMissionOrPackage() != null && !myUnit.IsOperating())
				{
					myUnit.AI.ClearMissionStateFlags();
				}
			}
			else
			{
				_AirOpsCondition_0 = value;
			}
		}
	}

	public float ConditionTimer
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			if ((value == 0f) & (Condition == _AirOpsCondition.Readying))
			{
				Condition = _AirOpsCondition.Parked;
			}
		}
	}

	public string ConditionString
	{
		get
		{
			switch (Condition)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return Condition.ToString();
			case _AirOpsCondition.Airborne:
				if (myUnit.IsPerformingStandoffAttack)
				{
					return method_2("Stand-off Attack");
				}
				return "Airborne";
			case _AirOpsCondition.Parked:
				if (!Information.IsNothing((object)HostAirFacility) && !Information.IsNothing((object)HostAirFacility.ParentPlatform) && HostAirFacility.ParentPlatform.IsShip)
				{
					if (HostAirFacility.AirFacType == AirFacility._AirFacType.OpenParking)
					{
						return "Parked on flight deck";
					}
					if (HostAirFacility.AirFacType == AirFacility._AirFacType.Hangar)
					{
						return "Parked in hangar";
					}
				}
				return "Parked";
			case _AirOpsCondition.TaxyingToTakeOff:
			{
				AirFacility._AirFacType airFacType2 = HostAirFacility.AirFacType;
				if (airFacType2 == AirFacility._AirFacType.Elevator)
				{
					return method_2("On elevator, enroute to takeoff");
				}
				return method_2("Taxiing to take off");
			}
			case _AirOpsCondition.TaxyingToPark:
			{
				AirFacility._AirFacType airFacType3 = HostAirFacility.AirFacType;
				if (airFacType3 == AirFacility._AirFacType.Elevator)
				{
					return method_2("On elevator, enroute to parking spot");
				}
				return method_2("Taxiing to parking spot");
			}
			case _AirOpsCondition.TakingOff:
				return method_2("Taking off");
			case _AirOpsCondition.Landing_PreTouchdown:
				return method_2("On final approach");
			case _AirOpsCondition.Landing_PostTouchdown:
				return "Completing landing";
			case _AirOpsCondition.Readying:
				if (QueuedTakeOff)
				{
					return method_2("Readying (then take off)");
				}
				return method_2("Readying");
			case _AirOpsCondition.HoldingForAvailableTransit:
				return method_2("Waiting for available taxiway/elevator");
			case _AirOpsCondition.HoldingForAvailableRunway:
				return method_2("Waiting for runway to become available");
			case _AirOpsCondition.HoldingOnLandingQueue:
				return method_2("In landing queue");
			case _AirOpsCondition.RTB:
				return method_2("Returning to base");
			case _AirOpsCondition.PreparingToLaunch:
				return method_2("Preparing to launch");
			case _AirOpsCondition.ManoeuveringToRefuel:
				return method_2("Manoeuvering to refuel");
			case _AirOpsCondition.Refuelling:
				return method_2("Refuelling");
			case _AirOpsCondition.OffloadingFuel:
				return method_2("Offloading fuel");
			case _AirOpsCondition.DeployingDippingSonar:
				return method_2("Deploying Dipping Sonar");
			case _AirOpsCondition.EmergencyLanding:
				return method_2("Chicken, critically low on fuel");
			case _AirOpsCondition.TaxyingToFlightDeck:
			{
				AirFacility._AirFacType airFacType = HostAirFacility.AirFacType;
				if (airFacType == AirFacility._AirFacType.Elevator)
				{
					return method_2("On elevator, enroute to flight deck");
				}
				return method_2("Moving to flight deck");
			}
			case _AirOpsCondition.const_19:
				return method_2("Executing BVR attack");
			case _AirOpsCondition.BVRCrank:
				return method_2("Cranking");
			case _AirOpsCondition.Dogfight:
				return method_2("Dogfight");
			case _AirOpsCondition.TransferringCargo:
				return method_2("Transferring Cargo");
			case _AirOpsCondition.BVRDrag:
				return method_2("Dragging");
			case _AirOpsCondition.HoldingPattern_CommsLost:
				return method_2("Holding Pattern - Comms Lost");
			}
		}
	}

	public bool HasAvailableRefuelSlotForThisAircraft
	{
		get
		{
			bool result;
			try
			{
				if (method_0().IsTanker)
				{
					if (method_0().get_CanPhysicallyReplenishThisUnit((ActiveUnit)theAC))
					{
						RefuelingConnectionValidation();
						if (A2AR_Connections.ContainsKey(theAC.ObjectID))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							A2AR_Connections.Remove(theAC.ObjectID);
						}
						if (WingmenHookingUpWithGroupleadTanker)
						{
							goto IL_0169;
						}
						List<string> list = new List<string>();
						bool flag = true;
						foreach (KeyValuePair<string, GEnum0> a2AR_Connection in A2AR_Connections)
						{
							if (Information.IsNothing((object)a2AR_Connection.Key))
							{
								continue;
							}
							if (!method_0().ParentScen.ActiveUnits.ContainsKey(a2AR_Connection.Key))
							{
								list.Add(a2AR_Connection.Key);
								continue;
							}
							Aircraft aircraft = (Aircraft)method_0().ParentScen.ActiveUnits[a2AR_Connection.Key];
							if (!Information.IsNothing((object)aircraft))
							{
								if (aircraft.Size >= GlobalVariables.AircraftSizeClass.Large)
								{
									flag = false;
									break;
								}
							}
							else
							{
								list.Add(a2AR_Connection.Key);
							}
						}
						foreach (string item in list)
						{
							A2AR_Connections.Remove(item);
						}
						if (flag)
						{
							goto IL_0169;
						}
						result = false;
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
				goto end_IL_0001;
				IL_0169:
				result = method_26(theAC, WingmenHookingUpWithGroupleadTanker) || (method_28(theAC, WingmenHookingUpWithGroupleadTanker) ? true : false);
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100441", "");
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
	}

	public static event TookOffEventHandler TookOff
	{
		[CompilerGenerated]
		add
		{
			TookOffEventHandler tookOffEventHandler = tookOffEventHandler_0;
			TookOffEventHandler tookOffEventHandler2;
			do
			{
				tookOffEventHandler2 = tookOffEventHandler;
				TookOffEventHandler value2 = (TookOffEventHandler)Delegate.Combine(tookOffEventHandler2, value);
				tookOffEventHandler = Interlocked.CompareExchange(ref tookOffEventHandler_0, value2, tookOffEventHandler2);
			}
			while ((object)tookOffEventHandler != tookOffEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TookOffEventHandler tookOffEventHandler = tookOffEventHandler_0;
			TookOffEventHandler tookOffEventHandler2;
			do
			{
				tookOffEventHandler2 = tookOffEventHandler;
				TookOffEventHandler value2 = (TookOffEventHandler)Delegate.Remove(tookOffEventHandler2, value);
				tookOffEventHandler = Interlocked.CompareExchange(ref tookOffEventHandler_0, value2, tookOffEventHandler2);
			}
			while ((object)tookOffEventHandler != tookOffEventHandler2);
		}
	}

	public static event LandingEventHandler Landing
	{
		[CompilerGenerated]
		add
		{
			LandingEventHandler landingEventHandler = landingEventHandler_0;
			LandingEventHandler landingEventHandler2;
			do
			{
				landingEventHandler2 = landingEventHandler;
				LandingEventHandler value2 = (LandingEventHandler)Delegate.Combine(landingEventHandler2, value);
				landingEventHandler = Interlocked.CompareExchange(ref landingEventHandler_0, value2, landingEventHandler2);
			}
			while ((object)landingEventHandler != landingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LandingEventHandler landingEventHandler = landingEventHandler_0;
			LandingEventHandler landingEventHandler2;
			do
			{
				landingEventHandler2 = landingEventHandler;
				LandingEventHandler value2 = (LandingEventHandler)Delegate.Remove(landingEventHandler2, value);
				landingEventHandler = Interlocked.CompareExchange(ref landingEventHandler_0, value2, landingEventHandler2);
			}
			while ((object)landingEventHandler != landingEventHandler2);
		}
	}

	public static event ReachedBingoFuelEventHandler ReachedBingoFuel
	{
		[CompilerGenerated]
		add
		{
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler = reachedBingoFuelEventHandler_0;
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler2;
			do
			{
				reachedBingoFuelEventHandler2 = reachedBingoFuelEventHandler;
				ReachedBingoFuelEventHandler value2 = (ReachedBingoFuelEventHandler)Delegate.Combine(reachedBingoFuelEventHandler2, value);
				reachedBingoFuelEventHandler = Interlocked.CompareExchange(ref reachedBingoFuelEventHandler_0, value2, reachedBingoFuelEventHandler2);
			}
			while ((object)reachedBingoFuelEventHandler != reachedBingoFuelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler = reachedBingoFuelEventHandler_0;
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler2;
			do
			{
				reachedBingoFuelEventHandler2 = reachedBingoFuelEventHandler;
				ReachedBingoFuelEventHandler value2 = (ReachedBingoFuelEventHandler)Delegate.Remove(reachedBingoFuelEventHandler2, value);
				reachedBingoFuelEventHandler = Interlocked.CompareExchange(ref reachedBingoFuelEventHandler_0, value2, reachedBingoFuelEventHandler2);
			}
			while ((object)reachedBingoFuelEventHandler != reachedBingoFuelEventHandler2);
		}
	}

	public static event HostAirFacilityChangedEventHandler HostAirFacilityChanged
	{
		[CompilerGenerated]
		add
		{
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler = hostAirFacilityChangedEventHandler_0;
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler2;
			do
			{
				hostAirFacilityChangedEventHandler2 = hostAirFacilityChangedEventHandler;
				HostAirFacilityChangedEventHandler value2 = (HostAirFacilityChangedEventHandler)Delegate.Combine(hostAirFacilityChangedEventHandler2, value);
				hostAirFacilityChangedEventHandler = Interlocked.CompareExchange(ref hostAirFacilityChangedEventHandler_0, value2, hostAirFacilityChangedEventHandler2);
			}
			while ((object)hostAirFacilityChangedEventHandler != hostAirFacilityChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler = hostAirFacilityChangedEventHandler_0;
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler2;
			do
			{
				hostAirFacilityChangedEventHandler2 = hostAirFacilityChangedEventHandler;
				HostAirFacilityChangedEventHandler value2 = (HostAirFacilityChangedEventHandler)Delegate.Remove(hostAirFacilityChangedEventHandler2, value);
				hostAirFacilityChangedEventHandler = Interlocked.CompareExchange(ref hostAirFacilityChangedEventHandler_0, value2, hostAirFacilityChangedEventHandler2);
			}
			while ((object)hostAirFacilityChangedEventHandler != hostAirFacilityChangedEventHandler2);
		}
	}

	public static event AirOpsStatusChangeEventHandler AirOpsStatusChange
	{
		[CompilerGenerated]
		add
		{
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler = airOpsStatusChangeEventHandler_0;
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler2;
			do
			{
				airOpsStatusChangeEventHandler2 = airOpsStatusChangeEventHandler;
				AirOpsStatusChangeEventHandler value2 = (AirOpsStatusChangeEventHandler)Delegate.Combine(airOpsStatusChangeEventHandler2, value);
				airOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref airOpsStatusChangeEventHandler_0, value2, airOpsStatusChangeEventHandler2);
			}
			while ((object)airOpsStatusChangeEventHandler != airOpsStatusChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler = airOpsStatusChangeEventHandler_0;
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler2;
			do
			{
				airOpsStatusChangeEventHandler2 = airOpsStatusChangeEventHandler;
				AirOpsStatusChangeEventHandler value2 = (AirOpsStatusChangeEventHandler)Delegate.Remove(airOpsStatusChangeEventHandler2, value);
				airOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref airOpsStatusChangeEventHandler_0, value2, airOpsStatusChangeEventHandler2);
			}
			while ((object)airOpsStatusChangeEventHandler != airOpsStatusChangeEventHandler2);
		}
	}

	static Aircraft_AirOps()
	{
		Class72.smethod_20();
		HelicopterDippingSonarAltitude = 46;
	}

	[SpecialName]
	private Aircraft method_0()
	{
		if (aircraft_1 == null)
		{
			aircraft_1 = (Aircraft)myUnit;
		}
		return aircraft_1;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("AirOps");
			theWriter.WriteStartElement("LQ");
			Aircraft[] landingQueue = _LandingQueue;
			for (int i = 0; i < landingQueue.Length; i = checked(i + 1))
			{
				landingQueue[i].ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			}
			theWriter.WriteEndElement();
			XmlWriter obj = theWriter;
			int airOpsCondition_ = (int)_AirOpsCondition_0;
			obj.WriteElementString("Con", airOpsCondition_.ToString());
			if (QueuedTakeOff)
			{
				theWriter.WriteElementString("QTakeoff", QueuedTakeOff.ToString());
			}
			theWriter.WriteElementString("CT", XmlConvert.ToString(ConditionTimer));
			if (!(OverrideConditionTimer < 0f))
			{
				theWriter.WriteElementString("CTOverride", XmlConvert.ToString(OverrideConditionTimer));
			}
			if (!Information.IsNothing((object)HostAirFacility))
			{
				theWriter.WriteElementString("HAF", HostAirFacility.ObjectID);
			}
			if (!Information.IsNothing((object)CurrentHostUnit))
			{
				theWriter.WriteElementString("CHU", CurrentHostUnit.ObjectID);
			}
			if (!Information.IsNothing((object)this.get_AssignedHostUnit(PickNewAssignedHost: false)))
			{
				theWriter.WriteElementString("AHU", activeUnit_1.ObjectID);
			}
			if (!Information.IsNothing((object)A2AR_Destination))
			{
				theWriter.WriteElementString("A2ARD", A2AR_Destination.ObjectID);
			}
			theWriter.WriteElementString("ManA2ARD", ManuallySelectedA2AR_Destination.ToString());
			if (RefuellingQueue.Count > 0)
			{
				theWriter.WriteStartElement("RQ");
				foreach (string key in RefuellingQueue.Keys)
				{
					theWriter.WriteElementString("ID", key);
				}
				theWriter.WriteEndElement();
			}
			if (A2AR_Connections.Count > 0)
			{
				theWriter.WriteStartElement("A2ARC");
				foreach (KeyValuePair<string, GEnum0> a2AR_Connection in A2AR_Connections)
				{
					if (Information.IsNothing((object)a2AR_Connection.Key))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						theWriter.WriteElementString("Conn", a2AR_Connection.Key + "_" + Conversions.ToString((int)a2AR_Connection.Value));
					}
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteStartElement("A2AR_NumberOfReceiverHookups");
			if (A2AR_NumberOfReceiverHookups != null && A2AR_NumberOfReceiverHookups.Count > 0)
			{
				foreach (ActiveUnit.ActiveUnit_Struct a2AR_NumberOfReceiverHookup in A2AR_NumberOfReceiverHookups)
				{
					if (!a2AR_NumberOfReceiverHookup.isDefaultvalue())
					{
						a2AR_NumberOfReceiverHookup.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
					}
				}
			}
			theWriter.WriteEndElement();
			if (QuickTurnaround_Enabled)
			{
				theWriter.WriteElementString("QuickTurnaround_Enabled", QuickTurnaround_Enabled.ToString());
			}
			if (QuickTurnaround_SortiesFlown != 0)
			{
				theWriter.WriteElementString("QuickTurnaround_SortiesFlown", QuickTurnaround_SortiesFlown.ToString());
			}
			if (QuickTurnaround_SortiesTotal != 0)
			{
				theWriter.WriteElementString("QuickTurnaround_SortiesTotal", QuickTurnaround_SortiesTotal.ToString());
			}
			if (QuickTurnaround_TimePentalty != 0)
			{
				theWriter.WriteElementString("QuickTurnaround_TimePentalty", QuickTurnaround_TimePentalty.ToString());
			}
			if (QuickTurnaround_AirborneTime_Flown != 0f)
			{
				theWriter.WriteElementString("QuickTurnaround_AirborneTime_Flown", QuickTurnaround_AirborneTime_Flown.ToString());
			}
			if (QuickTurnaround_AirborneTime_SortieAverage != 0f)
			{
				theWriter.WriteElementString("QuickTurnaround_AirborneTime_SortieAverage", QuickTurnaround_AirborneTime_SortieAverage.ToString());
			}
			if (ActiveRadarDoctrineBeforeRefueling.HasValue)
			{
				theWriter.WriteElementString("ActiveRadarDoctrineBeforeRefueling", ((byte)ActiveRadarDoctrineBeforeRefueling.Value).ToString());
			}
			if (EMCONInheritFromParentBeforeRefueling.HasValue)
			{
				theWriter.WriteElementString("EMCONInheritFromParentBeforeRefueling", EMCONInheritFromParentBeforeRefueling.Value.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100404", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_AirOps FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		Aircraft_AirOps result2;
		try
		{
			Aircraft_AirOps aircraft_AirOps = new Aircraft_AirOps(ref theAU);
			aircraft_AirOps.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "QuickTurnaround_AirborneTime_Flown":
					aircraft_AirOps.QuickTurnaround_AirborneTime_Flown = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "QuickTurnaround_TimePentalty":
					aircraft_AirOps.QuickTurnaround_TimePentalty = Conversions.ToInteger(val.InnerText);
					break;
				case "A2AR_NumberOfReceiverHookups":
				{
					int result = 0;
					if (val.ChildNodes != null && val.ChildNodes.Count > 0 && int.TryParse(val.ChildNodes[0].InnerText, out result))
					{
						break;
					}
					aircraft_AirOps.A2AR_NumberOfReceiverHookups = new List<ActiveUnit.ActiveUnit_Struct>();
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						ActiveUnit.ActiveUnit_Struct item = ActiveUnit.ActiveUnit_Struct.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						aircraft_AirOps.A2AR_NumberOfReceiverHookups.Add(item);
					}
					break;
				}
				case "QuickTurnaround_SortiesTotal":
					aircraft_AirOps.QuickTurnaround_SortiesTotal = Conversions.ToInteger(val.InnerText);
					break;
				case "CurrentHostUnit":
				case "CHU":
				{
					if (!Misc.HasElementChildren(val))
					{
						aircraft_AirOps.string_1 = val.InnerText;
						break;
					}
					XmlNode theNode2 = val.ChildNodes[0];
					ActiveUnit activeUnit = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					if (!theAU.ParentScen.ActiveUnits.ContainsKey(activeUnit.ObjectID))
					{
						theAU.ParentScen.ActiveUnits.TryAdd(activeUnit.ObjectID, activeUnit);
					}
					if (!activeUnit.AirFacilities_ReadOnly.Contains(aircraft_AirOps.HostAirFacility))
					{
						activeUnit.AirOps.AddThisAircraft((Aircraft)theAU, GameIsRunning: false);
					}
					break;
				}
				case "RefuellingQueue":
				case "RQ":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode val2 = childNode3;
						aircraft_AirOps.RefuellingQueue.AddIfNotExists(val2.InnerText, 0);
					}
					break;
				case "ActiveRadarDoctrineBeforeRefueling":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						aircraft_AirOps.ActiveRadarDoctrineBeforeRefueling = (Doctrine.EMCONSettings._EMCONSetting)Enum.Parse(typeof(Doctrine.EMCONSettings._EMCONSetting), val.InnerText, ignoreCase: true);
					}
					else
					{
						aircraft_AirOps.ActiveRadarDoctrineBeforeRefueling = (Doctrine.EMCONSettings._EMCONSetting)Conversions.ToByte(val.InnerText);
					}
					break;
				case "LQ":
				case "LandingQueue":
				{
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						ArrayExtensions.Add(ref aircraft_AirOps._LandingQueue_IDs, val.ChildNodes[i].InnerText);
					}
					break;
				}
				case "CT":
				case "ConditionTimer":
					aircraft_AirOps.ConditionTimer = XmlConvert.ToSingle(val.InnerText);
					break;
				case "QuickTurnaround_Enabled":
					aircraft_AirOps.QuickTurnaround_Enabled = Misc.ParseBool(val.InnerText);
					break;
				case "QuickTurnaround_SortiesFlown":
					aircraft_AirOps.QuickTurnaround_SortiesFlown = Conversions.ToInteger(val.InnerText);
					break;
				case "A2AR_Connections":
				case "A2ARC":
					foreach (XmlNode childNode4 in val.ChildNodes)
					{
						string[] array = childNode4.InnerText.Split(new char[1] { '_' });
						if (!string.IsNullOrEmpty(array[0]))
						{
							aircraft_AirOps.A2AR_Connections.Add(array[0], (GEnum0)Conversions.ToByte(array[1]));
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					break;
				case "CTOverride":
					aircraft_AirOps.OverrideConditionTimer = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Con":
				case "Condition":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						aircraft_AirOps.Condition = (_AirOpsCondition)Enum.Parse(typeof(_AirOpsCondition), val.InnerText, ignoreCase: true);
					}
					else
					{
						aircraft_AirOps.Condition = (_AirOpsCondition)Conversions.ToByte(val.InnerText);
					}
					break;
				case "A2AR_Destination":
				case "A2ARD":
					aircraft_AirOps.string_3 = val.InnerText;
					break;
				case "ManA2ARD":
					aircraft_AirOps.ManuallySelectedA2AR_Destination = bool.Parse(val.InnerText);
					break;
				case "AHU":
				case "AssignedHostUnit":
					if (val.FirstChild.HasChildNodes)
					{
						XmlNode theNode2 = val.ChildNodes[0];
						ActiveUnit value = ActiveUnit.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
						aircraft_AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, value);
					}
					else
					{
						aircraft_AirOps.string_2 = val.InnerText;
					}
					break;
				case "QTakeoff":
					aircraft_AirOps.QueuedTakeOff = Misc.ParseBool(val.InnerText);
					break;
				case "EMCONInheritFromParentBeforeRefueling":
					aircraft_AirOps.EMCONInheritFromParentBeforeRefueling = bool.Parse(val.InnerText);
					break;
				case "QuickTurnaround_AirborneTime_SortieAverage":
					aircraft_AirOps.QuickTurnaround_AirborneTime_SortieAverage = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "HAF":
				case "HostAirFacility":
				{
					if (!Misc.HasElementChildren(val))
					{
						aircraft_AirOps.string_0 = val.InnerText;
						break;
					}
					XmlNode theNode2 = val.ChildNodes[0];
					aircraft_AirOps.HostAirFacility = AirFacility.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					aircraft_AirOps.string_0 = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
					break;
				}
				}
			}
			result2 = aircraft_AirOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100405", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = new Aircraft_AirOps(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	public (bool ResponseBoolean, string ResponseString) ThisUnitCanHostMe(ActiveUnit theUnit, bool HumanFeedbackNeeded)
	{
		(bool, string) result;
		try
		{
			if (theUnit == null)
			{
				return (ResponseBoolean: false, ResponseString: "Error");
			}
			if (theUnit.IsGroup && !theUnit.HasRunwaysOrPads)
			{
				return (ResponseBoolean: false, ResponseString: "Selected group does not have runways or landing pads");
			}
			AirOpsAttemptResult airOpsAttemptResult = theUnit.AirOps.CanHostThisAircraft(method_0());
			string item = string.Empty;
			if (airOpsAttemptResult == AirOpsAttemptResult.Success)
			{
				AirOpsAttemptResult airOpsAttemptResult2 = method_16(theUnit, bool_0: true);
				if (airOpsAttemptResult2 != AirOpsAttemptResult.Success)
				{
					int item2;
					if (!HumanFeedbackNeeded)
					{
						item2 = 0;
					}
					else
					{
						item = "Cannot land here " + airOpsAttemptResult2.ToString().Replace("_", " ");
						item2 = 0;
					}
					return (ResponseBoolean: (byte)item2 != 0, ResponseString: item);
				}
				return (ResponseBoolean: true, ResponseString: "OK");
			}
			int item3;
			if (!HumanFeedbackNeeded)
			{
				item3 = 0;
			}
			else
			{
				item = "The aircraft cannot be hosted on any air facility here (Last reason : " + airOpsAttemptResult.ToString().Replace("_", " ") + ")";
				item3 = 0;
			}
			return (ResponseBoolean: (byte)item3 != 0, ResponseString: item);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100409", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (false, "Error!");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void PickNewAssignedHost_NearestToThisUnit(ActiveUnit theAU)
	{
		_Closure$__66-0 arg = default(_Closure$__66-0);
		_Closure$__66-0 CS$<>8__locals2 = new _Closure$__66-0(arg);
		CS$<>8__locals2.$VB$Local_theAU = theAU;
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			if (Information.IsNothing((object)CurrentHostUnit))
			{
				List<ActiveUnit> list2 = myUnit.get_UnitSide(SetSideOnly: false).Units.ToList();
				foreach (ActiveUnit item in list2)
				{
					if (ThisUnitCanHostMe(item, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					activeUnit_1 = list.OrderBy([SpecialName] (ActiveUnit theCand) => Module_Unit.RangeToUnit_Horiz_Angular(theCand, CS$<>8__locals2.$VB$Local_theAU)).ElementAtOrDefault(0);
					string text = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					method_0().AddMessage(method_0().Name + text + " selects a new base to land: " + activeUnit_1.Name + ".", method_0().Name + " selected new home", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100410", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_Nearest()
	{
		try
		{
			if (CurrentHostUnit != null)
			{
				if (!CurrentHostUnit.IsMorituri)
				{
					this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
					return;
				}
				CurrentHostUnit = null;
			}
			if (myUnit.Navigator.HasFlight && !string.IsNullOrEmpty(myUnit.Navigator.get_Flight(HierarchySearch: true).AlternativeLandingLocation_HostUnitObjectID) && myUnit.ParentScen.ActiveUnits.ContainsKey(myUnit.Navigator.get_Flight(HierarchySearch: true).AlternativeLandingLocation_HostUnitObjectID))
			{
				activeUnit_1 = myUnit.ParentScen.ActiveUnits[myUnit.Navigator.get_Flight(HierarchySearch: true).AlternativeLandingLocation_HostUnitObjectID];
				if (activeUnit_1 != null)
				{
					return;
				}
			}
			List<ActiveUnit> list;
			try
			{
				list = new List<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				list = new List<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
				ProjectData.ClearProjectError();
			}
			for (int i = list.Count - 1; i >= 0; i += -1)
			{
				if (list[i] == null || list[i] == myUnit || !ThisUnitCanHostMe(list[i], HumanFeedbackNeeded: false).ResponseBoolean)
				{
					list.RemoveAt(i);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			IEnumerable<ActiveUnit> enumerable = list.OrderBy([SpecialName] (ActiveUnit theC) => Module_Unit.RangeToUnit_Horiz_Angular(theC, myUnit));
			foreach (ActiveUnit item in enumerable)
			{
				if (myUnit.AttemptToSetNewAssignedHost(item))
				{
					string text = "";
					if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
					{
						text = " (" + method_0().UnitClass + ")";
					}
					method_0().AddMessage(method_0().Name + text + " selects a new base to land: " + activeUnit_1.Name + ".", method_0().Name + " selects new home", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100411", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_RandomWithinRange(ActiveUnit excludeUnit = null)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			double num = Math2.Distance_To_AngularDegrees(myUnit.Kinematics.MaxRange(BingoFuelCheck: true, null, null));
			List<ActiveUnit> list2 = myUnit.get_UnitSide(SetSideOnly: false).Units.ToList();
			foreach (ActiveUnit item in list2)
			{
				if (!item.IsAircraft && !item.IsGroup && item.IsOperating() && item != myUnit && Module_Unit.RangeToUnit_Horiz_Angular(myUnit, item) <= num && ThisUnitCanHostMe(item, HumanFeedbackNeeded: false).ResponseBoolean)
				{
					list.Add(item);
				}
			}
			if (!Information.IsNothing((object)excludeUnit) && list.Contains(excludeUnit))
			{
				list.Remove(excludeUnit);
			}
			if (list.Count > 0)
			{
				int index = GameGeneral.GlobalRNG.Next(list.Count);
				activeUnit_1 = list[index];
				string text = "";
				if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
				{
					text = " (" + method_0().UnitClass + ")";
				}
				method_0().AddMessage(method_0().Name + text + " selects a new base to land: " + activeUnit_1.Name + ".", method_0().Name + " selects new home", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100412", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1(AirFacility airFacility_1)
	{
		bool flag = false;
		Side[] sides_ReadOnly = method_0().ParentScen.Sides_ReadOnly;
		Contact.HostedUnitReconRecord hostedUnitReconRecord = default(Contact.HostedUnitReconRecord);
		Contact.HostedUnitReconRecord hostedUnitReconRecord2 = default(Contact.HostedUnitReconRecord);
		foreach (Side side in sides_ReadOnly)
		{
			if (flag)
			{
				break;
			}
			if (side == ((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(side, ((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false)) || !side.Contacts.ContainsKey(airFacility_0.ParentPlatform.ObjectID))
			{
				continue;
			}
			List<ActiveUnit> list = side.Units_OperativeOnly(IncludeGroups: false);
			for (int j = list.Count - 1; j >= 0; j += -1)
			{
				ActiveUnit activeUnit = list[j];
				if (activeUnit == null)
				{
					continue;
				}
				if (flag)
				{
					break;
				}
				float num = Module_Unit.RangeToUnit_Slant(activeUnit, airFacility_0.ParentPlatform, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectFalse);
				PooledList<Sensor> pooledList = null;
				Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsOperating && sensor.get_CanPerformBDA(AllowRadar: true, AllowSonar: false))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(sensor);
					}
				}
				if (pooledList == null || pooledList.Count == 0)
				{
					continue;
				}
				float num2 = 0f;
				foreach (Sensor item in pooledList)
				{
					if (item.maxRange > num2)
					{
						num2 = item.maxRange;
					}
				}
				if (!(num2 > 0f) || !(num <= num2))
				{
					continue;
				}
				foreach (Sensor item2 in pooledList)
				{
					if (flag)
					{
						break;
					}
					ActiveUnit parentPlatform = airFacility_0.ParentPlatform;
					List<Geopoint_Struct> UncertaintyArea = null;
					Dictionary<int, EmissionContainer> DetectedEmissions = null;
					bool? LOS_Exists_Radar = null;
					bool? LOS_Exists_RadarSW = null;
					Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Sonar = null;
					bool? LOS_Exists_ESM = null;
					bool? LOS_Exists_ESM_SW = null;
					if (!item2.CanDetectTarget(Sensor.DetectionAttemptType.Recon, activeUnit, parentPlatform, ref UncertaintyArea, num, ref DetectedEmissions, null, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW) || !(item2.MaxIDRangeOnThisTarget(item2.ParentPlatform, method_0()) * 3f >= num))
					{
						continue;
					}
					flag = true;
					Contact contact = side.Contacts[airFacility_1.ParentPlatform.ObjectID];
					Contact theHostContact = side.Contacts[airFacility_0.ParentPlatform.ObjectID];
					if (!airFacility_0.IsOpenAirFacility & airFacility_1.IsOpenAirFacility)
					{
						activeUnit.Sensory.AddNewHostedUnitReconRecord(method_0(), theHostContact, item2);
						foreach (Contact.HostedUnitReconRecord item3 in contact.Recon_HostedUnits(activeUnit.get_UnitSide(SetSideOnly: false)))
						{
							if (Operators.CompareString(item3.UnitID, method_0().ObjectID, false) == 0)
							{
								hostedUnitReconRecord = item3;
								break;
							}
						}
						if (hostedUnitReconRecord != null)
						{
							activeUnit.Sensory.RemoveHostedUnitRecord(contact, hostedUnitReconRecord);
						}
					}
					if (!(airFacility_0.IsOpenAirFacility & !airFacility_1.IsOpenAirFacility))
					{
						continue;
					}
					foreach (Contact.HostedUnitReconRecord item4 in contact.Recon_HostedUnits(activeUnit.get_UnitSide(SetSideOnly: false)))
					{
						if (Operators.CompareString(item4.UnitID, method_0().ObjectID, false) == 0)
						{
							hostedUnitReconRecord2 = item4;
							break;
						}
					}
					if (hostedUnitReconRecord2 != null)
					{
						activeUnit.Sensory.RemoveHostedUnitRecord(contact, hostedUnitReconRecord2);
					}
				}
				pooledList?.Dispose();
			}
		}
	}

	internal bool Can_Fly_Current_Visibility(ActiveUnit thePositionToCheck = null)
	{
		double theLat;
		double theLon;
		double a;
		if (thePositionToCheck != null)
		{
			theLat = thePositionToCheck.get_Latitude((GlobalVariables.BooleanObject)null);
			theLon = thePositionToCheck.get_Longitude((GlobalVariables.BooleanObject)null);
			a = thePositionToCheck.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		else
		{
			theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			a = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			return true;
		}
		Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(myUnit.ParentScen, theLat, theLon, (int)Math.Round(a));
		LandCover.LandCoverType landCoverAtThisPoint = LandCover.GetLandCoverAtThisPoint(theLat, theLon, myUnit.ParentScen);
		float? num = method_0().get_MinimumSafeHeight(bool_7: true);
		int num2 = 0;
		num2 = (num.HasValue ? Math.Max(LandCover.GetHeight_LandCoverType(landCoverAtThisPoint), (int)Math.Round(num.Value)) : LandCover.GetHeight_LandCoverType(landCoverAtThisPoint));
		if (weatherProfile.CloudInfo.LowCloudBase_m <= num2)
		{
			if ((float)weatherProfile.CloudInfo.LowCloudCoverThickness <= 3f)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	internal bool Can_Fly_Current_Rain(ActiveUnit thePositionToCheck = null)
	{
		double theLat;
		double theLon;
		if (thePositionToCheck == null)
		{
			theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			theLat = thePositionToCheck.get_Latitude((GlobalVariables.BooleanObject)null);
			theLon = thePositionToCheck.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			int result;
			if (method_0().Loadout != null)
			{
				switch (method_0().Loadout.Weather)
				{
				case Loadout._LoadoutWeather.ClearWeather:
					if (Weather.get_WeatherAtThisTimeAndPlace(myUnit.ParentScen, theLat, theLon, 0).RainfallRate <= 5f)
					{
						return true;
					}
					return false;
				case Loadout._LoadoutWeather.None:
				case Loadout._LoadoutWeather.AllWeather:
				case Loadout._LoadoutWeather.LimitedAllWeather:
					return true;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		return true;
	}

	internal bool Can_Fly_Current_TOD(ActiveUnit thePositionToCheck = null)
	{
		double dLatitude;
		double dLongitude;
		if (thePositionToCheck != null)
		{
			dLatitude = thePositionToCheck.get_Latitude((GlobalVariables.BooleanObject)null);
			dLongitude = thePositionToCheck.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			dLatitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			dLongitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			return true;
		}
		if (method_0().Loadout == null)
		{
			return true;
		}
		int result;
		switch (method_0().Loadout.TimeOfDay)
		{
		case Loadout._LoadoutDayNight.DayNight:
			result = 1;
			break;
		default:
			if (method_0().Loadout.TimeOfDay != 0)
			{
				bool flag = SunModule.GetTimeOfDay(myUnit.ParentScen, myUnit.ParentScen.Time.Year, myUnit.ParentScen.Time.Month, myUnit.ParentScen.Time.Day, myUnit.ParentScen.Time.Hour, myUnit.ParentScen.Time.Minute, myUnit.ParentScen.Time.Second, UseCurrentScenarioTime: true, dLatitude, dLongitude, 0.0) == Weather.TTimeOfDayType.tod_Day;
				if (method_0().Loadout.TimeOfDay == Loadout._LoadoutDayNight.DayOnly && flag)
				{
					return true;
				}
				if (method_0().Loadout.TimeOfDay == Loadout._LoadoutDayNight.NightOnly && !flag)
				{
					return true;
				}
				return false;
			}
			return true;
		case Loadout._LoadoutDayNight.None:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	internal bool Can_Land_Weather_Limitation(ActiveUnit thePositionToCheck = null)
	{
		WeatherString = "";
		BadWeatherFlag = false;
		if (!method_0().AirOps.Can_Fly_Current_Rain(thePositionToCheck))
		{
			WeatherString = "Cannot land (rainfall too heavy)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!method_0().AirOps.Can_Fly_Current_TOD(thePositionToCheck))
		{
			WeatherString += " Cannot land (daylight conditions not met)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!method_0().AirOps.Can_Fly_Current_Visibility(thePositionToCheck))
		{
			WeatherString += " Cannot land (visibility too low)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		return !BadWeatherFlag;
	}

	public Aircraft_AirOps(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		RefuellingQueue = new TDictionary<string, byte>(4, StringComparer.Ordinal, useReadLock: false);
		A2AR_Connections = new TDictionary<string, GEnum0>(StringComparer.Ordinal, useReadLock: false);
		A2AR_NumberOfReceiverHookups = new List<ActiveUnit.ActiveUnit_Struct>();
		TankerHookUpDistance = 0.5f;
		TankerHookUpDistance_Wingmen = 2f;
		ActiveRadarDoctrineBeforeRefueling = null;
		EMCONInheritFromParentBeforeRefueling = null;
		ManuallySelectedA2AR_Destination = false;
		OverrideConditionTimer = -1f;
		BadWeatherFlag = false;
		WeatherString = "";
		lockObject_0 = new LockObject();
	}

	private string method_2(string string_4)
	{
		if (string.IsNullOrEmpty(WeatherString))
		{
			return string_4;
		}
		return WeatherString + " - " + string_4;
	}

	private void method_3()
	{
		if (myUnit.ActiveMissionOrPackage() == null || !myUnit.ActiveMissionOrPackage().IsActive || !(myUnit is Aircraft) || !(myUnit.ActiveMissionOrPackage() is CargoMission))
		{
			return;
		}
		CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
		Aircraft aircraft = (Aircraft)myUnit;
		if (aircraft.Loadout.Cargo_Type == CargoType.NoCargo)
		{
			return;
		}
		if (!aircraft.DockingOps.HasEnoughCargoLoadToLaunch())
		{
			if (!aircraft.DockingOps.IsAtCargoDestination())
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
				if (currentHostUnitCargoSource.IsGroup)
				{
					foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)currentHostUnitCargoSource).Units)
					{
						list.Add(unit.Value);
					}
				}
				else
				{
					list.Add(currentHostUnitCargoSource);
				}
				lock (ActiveUnit_DockingOps.CargoOpsLockObj)
				{
					foreach (ActiveUnit item in list)
					{
						List<CargoManifestItem> transferManifest = null;
						if (!cargoMission.MoveAllCargo)
						{
							transferManifest = cargoMission.CargoToUnload;
						}
						List<Cargo> list2 = ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)item, (ICargoHost)myUnit, transferManifest, item);
						if (list2.Count <= 0)
						{
							continue;
						}
						int num = ActiveUnit_DockingOps.TimeToLoadCargo(myUnit, list2);
						ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item, myUnit, list2);
						Condition = _AirOpsCondition.Readying;
						if (cargoMission.InstantLoadingForNextManifest)
						{
							cargoMission.InstantLoadingForNextManifest = false;
							ConditionTimer = Math.Max(ConditionTimer, 0f);
						}
						else
						{
							ConditionTimer = Math.Max(ConditionTimer, num);
						}
						foreach (Cargo item2 in list2)
						{
							CargoManifestItem.Remove(item2, cargoMission.CargoToUnload);
						}
					}
					return;
				}
			}
			if (Condition == _AirOpsCondition.Parked)
			{
				aircraft.AirOps.Condition = _AirOpsCondition.PreparingToLaunch;
			}
		}
		else
		{
			aircraft.AirOps.Condition = _AirOpsCondition.PreparingToLaunch;
		}
	}

	public void DoAirOps(float elapsedTime)
	{
		if (method_0().IsOperating())
		{
			method_0().AirborneTime += elapsedTime;
		}
		try
		{
			float conditionTimer = ConditionTimer;
			ConditionTimer -= elapsedTime;
			if (ConditionTimer < 0f)
			{
				ConditionTimer = 0f;
			}
			if (!(ConditionTimer <= 0f))
			{
				return;
			}
			switch (Condition)
			{
			case _AirOpsCondition.Parked:
				if (Information.IsNothing((object)HostAirFacility))
				{
					break;
				}
				method_3();
				if (!HostAirFacility.IsTransitFacility() && (method_0().IsHelicopter || !HostAirFacility.IsRunwayOrPad()))
				{
					if (HostAirFacility.IsRunwayOrPad())
					{
						List<AirFacility> list = new List<AirFacility>();
						AirFacility[] airFacilities_ReadOnly = CurrentHostUnit.AirFacilities_ReadOnly;
						foreach (AirFacility airFacility in airFacilities_ReadOnly)
						{
							if (airFacility.IsRunwayOrPad())
							{
								list.Add(airFacility);
							}
						}
						if (list.Count == 1 && HostAirFacility == list[0])
						{
							AttemptToPark(NormalLandingSequence: true, RearmRefuel: false);
							break;
						}
					}
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						AttemptToMoveToFlightDeck();
					}
					if (((conditionTimer > 0f) & (ConditionTimer <= 0f)) && !Information.IsNothing((object)CurrentHostUnit))
					{
						string text = "";
						if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
						{
							text = " (" + method_0().UnitClass + ")";
						}
						method_0().AddMessage(method_0().Name + text + " is ready at " + CurrentHostUnit.Name, method_0().Name + " ready", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else
				{
					AttemptToPark(NormalLandingSequence: true, RearmRefuel: false);
				}
				break;
			case _AirOpsCondition.TaxyingToTakeOff:
				if (!WaitForEscorts())
				{
					AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
				}
				break;
			case _AirOpsCondition.TaxyingToPark:
				if (method_0().Navigator != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true) != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).TaskPool == null)
				{
					method_0().Navigator.ClearFlight();
				}
				AttemptToPark();
				break;
			case _AirOpsCondition.TakingOff:
			{
				Aircraft theAircraft = method_0();
				RefuelAC_Simple(ref theAircraft);
				ActiveUnit currentHostUnit = CurrentHostUnit;
				if ((currentHostUnit != null && currentHostUnit.IsFacility) || (currentHostUnit != null && currentHostUnit.IsGroup) || (currentHostUnit != null && currentHostUnit.IsOperating()))
				{
					TakeOff(elapsedTime);
				}
				break;
			}
			case _AirOpsCondition.Landing_PreTouchdown:
				if (method_0().RangeToUnit_Horiz(ActualDestinationHost) > 20f)
				{
					if (!GlobalVariables.AI_REWORK)
					{
						AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					else
					{
						method_0().AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
					}
				}
				if (method_0().Navigator.AboutToLand(elapsedTime))
				{
					AttemptToFinishLanding(elapsedTime);
				}
				break;
			case _AirOpsCondition.Landing_PostTouchdown:
				if (method_0().Navigator != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true) != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).TaskPool == null)
				{
					method_0().Navigator.ClearFlight();
				}
				AttemptToPark();
				break;
			case _AirOpsCondition.Readying:
				AttemptToMoveToFlightDeck();
				break;
			case _AirOpsCondition.HoldingForAvailableTransit:
				if (!WaitForEscorts())
				{
					AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
				}
				break;
			case _AirOpsCondition.HoldingForAvailableRunway:
				if (!WaitForEscorts())
				{
					AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
				}
				break;
			case _AirOpsCondition.HoldingOnLandingQueue:
				method_8();
				break;
			case _AirOpsCondition.RTB:
				if (!Information.IsNothing((object)HostAirFacility))
				{
					if (method_0().Navigator != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true) != null && ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).TaskPool == null)
					{
						method_0().Navigator.ClearFlight();
					}
					if (HostAirFacility.IsTransitFacility() || (!method_0().IsHelicopter && HostAirFacility.IsRunwayOrPad()))
					{
						AttemptToPark();
					}
				}
				break;
			case _AirOpsCondition.PreparingToLaunch:
				if (!WaitForEscorts())
				{
					AttemptToMoveToRunway(ActualAirlaunchPreparation: false);
				}
				break;
			case _AirOpsCondition.ManoeuveringToRefuel:
				AttemptToConnectToTanker(WingmenHookingUpWithGroupleadTanker: false);
				break;
			case _AirOpsCondition.Refuelling:
			{
				if (!GlobalVariables.AI_REWORK && (A2AR_Destination == null || A2AR_Destination.IsMorituri))
				{
					method_0().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					Condition = _AirOpsCondition.Airborne;
					break;
				}
				Aircraft a2AR_Destination = A2AR_Destination;
				bool? flag = ((a2AR_Destination == null) ? ((bool?)null) : new bool?(a2AR_Destination.AirOps.Condition == _AirOpsCondition.OffloadingFuel));
				if (((!flag) ?? flag) == true)
				{
					DisconnectFromTanker();
				}
				break;
			}
			case _AirOpsCondition.OffloadingFuel:
				if (A2AR_Connections.Skip(0).Count() == 0)
				{
					Condition = _AirOpsCondition.Airborne;
				}
				else
				{
					method_5(elapsedTime);
				}
				if (!GlobalVariables.AI_REWORK && A2AR_Connections.Skip(0).Count() == 0 && !myUnit.IsRTB)
				{
					method_0().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				break;
			case _AirOpsCondition.DeployingDippingSonar:
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned && !myUnit.Navigator.HasPlottedCourse() && myUnit.AI.PrimaryTarget == null)
				{
					byte? b = (byte?)myUnit.Doctrine.get_DippingSonar(method_0().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
					{
						ConditionTimer = 120f;
						break;
					}
				}
				if (myUnit.IsRTB)
				{
					Condition = _AirOpsCondition.RTB;
					break;
				}
				method_0().AI.FollowAltitudePreset();
				if (!myUnit.Kinematics.DesiredAltitudeOverride && (float)Math.Round(myUnit.DesiredAltitude, 1) == Convert.ToSingle(Math.Round(new decimal(HelicopterDippingSonarAltitude), 1)))
				{
					ActiveUnit activeUnit = myUnit;
					Aircraft theAircraft = method_0();
					ActiveUnit activeUnit2;
					ActiveUnit theAU;
					bool Return_theAltitude_TerrainFollowing = (activeUnit2 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
					float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
					activeUnit2.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
					activeUnit.DesiredAltitude = desiredAltitude;
				}
				Condition = _AirOpsCondition.Airborne;
				break;
			case _AirOpsCondition.EmergencyLanding:
			{
				if (!method_0().Navigator.AboutToLand(elapsedTime))
				{
					break;
				}
				AirFacility[] airFacilities_ReadOnly2 = ActualDestinationHost.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in airFacilities_ReadOnly2)
				{
					if (airFacility2.Status == PlatformComponent._ComponentStatus.Operational && airFacility2.IsParkingFacility() && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
					{
						HostAirFacility = airFacility2;
						break;
					}
				}
				if (Information.IsNothing((object)HostAirFacility))
				{
					ActiveUnit actualDestinationHost = ActualDestinationHost;
					IEnumerable<AirFacility> enumerable = method_10(actualDestinationHost);
					if (Information.IsNothing((object)enumerable) || enumerable.Count() <= 0)
					{
						break;
					}
					AirFacility[] airFacilities_ReadOnly3 = ActualDestinationHost.AirFacilities_ReadOnly;
					int num = 0;
					AirFacility airFacility3;
					while (true)
					{
						if (num < airFacilities_ReadOnly3.Length)
						{
							airFacility3 = airFacilities_ReadOnly3[num];
							if (airFacility3.Status == PlatformComponent._ComponentStatus.Operational && airFacility3.IsParkingFacility() && airFacility3.MaxAircraftSize >= method_0().Size)
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						return;
					}
					TouchDown(airFacility3, NormalLandingSequence: false);
				}
				else
				{
					TouchDown(null, NormalLandingSequence: false);
				}
				break;
			}
			case _AirOpsCondition.TaxyingToFlightDeck:
				if (!WaitForEscorts())
				{
					AttemptToMoveToFlightDeck();
				}
				break;
			case _AirOpsCondition.TransferringCargo:
				if (!Information.IsNothing((object)method_0().AI.PrimaryPickupTarget))
				{
					if (!((method_0().Loadout != null) & (method_0().Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || method_0().Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue)))
					{
						PickupCargoFromSource(method_0().AI.PrimaryPickupTarget);
					}
					else
					{
						ActiveUnit primaryPickupTarget = method_0().AI.PrimaryPickupTarget;
						method_0().AI.RemovePickupTarget(primaryPickupTarget.ObjectID);
						primaryPickupTarget.PickUpUnit = method_0();
						primaryPickupTarget.IsBeingPickedUp = true;
						primaryPickupTarget.ParentScen.AddMessage(primaryPickupTarget.Name + " has been rescued!", primaryPickupTarget.Name + " rescued!", LoggedMessage.MessageType.SpecialMessage, 0, primaryPickupTarget.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(primaryPickupTarget.get_Longitude((GlobalVariables.BooleanObject)null), primaryPickupTarget.get_Latitude((GlobalVariables.BooleanObject)null)));
						primaryPickupTarget.Destroy(ScenEditAction: true, IsFacilityAimpoint: false, DestroyUnitNow: true, "Rescued unit removed");
						primaryPickupTarget.ParentScen.CheckForDestroyEvents(primaryPickupTarget, 0f);
					}
				}
				else
				{
					UnloadCargo();
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _AirOpsCondition.Airborne;
				ConditionTimer = 0f;
				break;
			case _AirOpsCondition.const_19:
			case _AirOpsCondition.BVRCrank:
			case _AirOpsCondition.Dogfight:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100416", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private float method_4(Aircraft aircraft_2, GEnum0? nullable_0)
	{
		if (!nullable_0.HasValue)
		{
			nullable_0 = GEnum0.Boom;
		}
		if (method_0().FuelOffLoadRate == 0f && aircraft_2.FuelOnLoadRate == 0f)
		{
			GEnum0? gEnum = nullable_0;
			byte? b = (byte?)gEnum;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				if (aircraft_2.Size >= GlobalVariables.AircraftSizeClass.Medium)
				{
					return 22.6f;
				}
				return 12f;
			}
			b = (byte?)gEnum;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				return 11f;
			}
			b = (byte?)gEnum;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
			{
				throw new NotImplementedException();
			}
			return 8.33f;
		}
		if (method_0().FuelOffLoadRate > 0f && aircraft_2.FuelOnLoadRate > 0f)
		{
			return Math.Min(method_0().FuelOffLoadRate, aircraft_2.FuelOnLoadRate);
		}
		if (method_0().FuelOffLoadRate == 0f && aircraft_2.FuelOnLoadRate > 0f)
		{
			return aircraft_2.FuelOnLoadRate;
		}
		if (method_0().FuelOffLoadRate > 0f)
		{
			return method_0().FuelOffLoadRate;
		}
		throw new NotImplementedException();
	}

	private void method_5(float float_1)
	{
		_Closure$__108-0 arg = default(_Closure$__108-0);
		_Closure$__108-0 CS$<>8__locals16 = new _Closure$__108-0(arg);
		CS$<>8__locals16.$VB$Me = this;
		List<KeyValuePair<string, GEnum0>> list = new List<KeyValuePair<string, GEnum0>>();
		List<string> list2 = new List<string>();
		try
		{
			list.AddRange(A2AR_Connections);
			foreach (KeyValuePair<string, GEnum0> item in list)
			{
				if (Information.IsNothing((object)item.Key))
				{
					continue;
				}
				if (method_0().ParentScen.ActiveUnits.ContainsKey(item.Key))
				{
					CS$<>8__locals16.$VB$Local_ReceiverAC = (Aircraft)method_0().ParentScen.ActiveUnits[item.Key];
				}
				float num = method_27(CS$<>8__locals16.$VB$Local_ReceiverAC);
				if (num < 1f)
				{
					num = 1f;
				}
				if (CS$<>8__locals16.$VB$Local_ReceiverAC == method_0())
				{
					continue;
				}
				if (!Information.IsNothing((object)CS$<>8__locals16.$VB$Local_ReceiverAC))
				{
					if (CS$<>8__locals16.$VB$Local_ReceiverAC.AirOps.Condition != _AirOpsCondition.Refuelling)
					{
						CS$<>8__locals16.$VB$Local_ReceiverAC.AirOps.DisconnectFromTanker();
						continue;
					}
					float val = method_4(CS$<>8__locals16.$VB$Local_ReceiverAC, item.Value) * float_1 / num;
					if (!Information.IsNothing((object)CS$<>8__locals16.$VB$Local_ReceiverAC))
					{
						Aircraft aircraft = CS$<>8__locals16.$VB$Local_ReceiverAC;
						bool flag = false;
						if (CS$<>8__locals16.$VB$Local_ReceiverAC.IsGroupMember())
						{
							List<ActiveUnit> list3 = ((ActiveUnit)CS$<>8__locals16.$VB$Local_ReceiverAC).get_ParentGroup(UsingMissionPlanner: false).Units.Values.Where([SpecialName] (ActiveUnit theAC) => (theAC.RangeToUnit_Horiz(CS$<>8__locals16.$VB$Local_ReceiverAC) < 2f) & (theAC != CS$<>8__locals16.$VB$Me.method_0())).OrderBy([SpecialName] (ActiveUnit theAC) =>
							{
								double TotalCurrent = 0.0;
								double TotalMax = 0.0;
								return theAC.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false);
							}).ToList();
							flag = list3.Count < ((ActiveUnit)CS$<>8__locals16.$VB$Local_ReceiverAC).get_ParentGroup(UsingMissionPlanner: false).Units.Count;
							if (list3.Count > 0)
							{
								aircraft = (Aircraft)list3[0];
							}
						}
						float num2 = Math.Min(aircraft.Fuel_FreeLoad, val);
						if (num2 > 0f)
						{
							aircraft.Fuel_Add(num2, FuelRec._FuelType.AviationFuel);
							method_0().Fuel_Subtract(num2, FuelRec._FuelType.AviationFuel);
						}
						if (aircraft.Fuel_FreeLoad <= 0f && aircraft.Navigator.TankerFollowsMe_NumberOfWaypoints == 0 && !flag)
						{
							aircraft.AirOps.DisconnectFromTanker();
						}
					}
					else
					{
						CS$<>8__locals16.$VB$Local_ReceiverAC.AirOps.DisconnectFromTanker();
					}
				}
				else
				{
					list2.Add(item.Key);
				}
			}
			if (list2.Count <= 0)
			{
				return;
			}
			foreach (string item2 in list2)
			{
				A2AR_Connections.Remove(item2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100417", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisconnectFromTanker(bool recoveringFromDirtystate = false)
	{
		try
		{
			Aircraft aircraft = null;
			lock (lockObject_0)
			{
				if (A2AR_Destination == null)
				{
					foreach (Aircraft item in method_0().ParentScen.ActiveUnits_List.OfType<Aircraft>())
					{
						if (item != null && item.AirOps.A2AR_Connections.ContainsKey(method_0().ObjectID))
						{
							aircraft = item;
							item.AirOps.A2AR_Connections.Remove(method_0().ObjectID);
						}
					}
				}
				else
				{
					aircraft = A2AR_Destination;
					A2AR_Destination.AirOps.A2AR_Connections.Remove(method_0().ObjectID);
					A2AR_Destination.AirOps.RefuellingQueue.Remove(method_0().ObjectID);
					A2AR_Destination = null;
					if (EMCONInheritFromParentBeforeRefueling.HasValue && EMCONInheritFromParentBeforeRefueling.Value)
					{
						method_0().Doctrine.EMCON_Inherits = true;
					}
					else if (ActiveRadarDoctrineBeforeRefueling.HasValue)
					{
						method_0().Doctrine.SetEMCON_Radar(ActiveRadarDoctrineBeforeRefueling.Value, method_0().ParentScen);
					}
					if (!recoveringFromDirtystate)
					{
						EMCONInheritFromParentBeforeRefueling = null;
						ActiveRadarDoctrineBeforeRefueling = null;
					}
				}
			}
			if (aircraft == null)
			{
				return;
			}
			Aircraft_AirOps airOps = aircraft.AirOps;
			Aircraft_AI aI = aircraft.AI;
			int num;
			if (method_0().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				airOps.A2AR_NumberOfReceiverHookups.Add(new ActiveUnit.ActiveUnit_Struct(((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false), myUnit.ObjectID, method_0().Name, method_0().DBID));
				num = 0;
			}
			else
			{
				num = 0;
			}
			ActiveUnit._ActiveUnitStatus activeUnitStatus = (ActiveUnit._ActiveUnitStatus)num;
			if (method_0()._StatusBefore_NeedToRefuel != ActiveUnit._ActiveUnitStatus.RTB)
			{
				goto IL_021f;
			}
			int num2;
			if (method_0()._FuelStateBefore_NeedToRefuel != ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				if (method_0()._FuelStateBefore_NeedToRefuel != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					goto IL_021f;
				}
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			activeUnitStatus = (ActiveUnit._ActiveUnitStatus)num2;
			goto IL_02cb;
			IL_02cb:
			if (GlobalVariables.AI_REWORK)
			{
				method_0().AI.StatusRelatedEvents.desiredStatusAfterTankerDisconnect = activeUnitStatus;
			}
			else
			{
				method_0().Status = activeUnitStatus;
			}
			Condition = _AirOpsCondition.Airborne;
			method_0().FuelState = method_0().IsBingoOrJoker;
			if (aircraft != null && !((ActiveUnit)aircraft).IsRTB && aircraft.ActiveMissionOrPackage() != null && aircraft.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)aircraft.ActiveMissionOrPackage();
				if (supportMission.A2AR_OneTankingCycleOnly && airOps.RefuellingQueue.Skip(0).Count() == 0 && airOps.A2AR_Connections.Skip(0).Count() == 0)
				{
					string text = "";
					if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, false) != 0)
					{
						text = " (" + aircraft.UnitClass + ")";
					}
					aircraft.ParentScen.AddMessage("Aircraft " + aircraft.Name + text + " is returning to base. The mission " + aircraft.ActiveMissionOrPackage().Name + " allows one refuelling cycle only, and the tanker queue is now empty.", "Tanker operations", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, ((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(aircraft.get_Longitude((GlobalVariables.BooleanObject)null), aircraft.get_Latitude((GlobalVariables.BooleanObject)null)));
					if (GlobalVariables.AI_REWORK)
					{
						aI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
					}
					else
					{
						airOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
				}
				if (supportMission.A2AR_MaxNumberOfReceiversPerTanker > 0 && !airOps.method_6(supportMission.A2AR_MaxNumberOfReceiversPerTanker, method_0()) && airOps.RefuellingQueue.Skip(0).Count() == 0 && airOps.A2AR_Connections.Skip(0).Count() == 0)
				{
					if (aircraft.ActiveMissionOrPackage() != null && aircraft.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support && !((SupportMission)aircraft.ActiveMissionOrPackage()).RTBUponCompletion)
					{
						return;
					}
					string text2 = "";
					if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, false) != 0)
					{
						text2 = " (" + aircraft.UnitClass + ")";
					}
					aircraft.ParentScen.AddMessage("Aircraft " + aircraft.Name + text2 + " is returning to base. The mission " + aircraft.ActiveMissionOrPackage().Name + " allows " + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + " receivers to be served (rounded up to nearest flight), and a total of " + Conversions.ToString(airOps.A2AR_NumberOfReceiverHookups.Count) + " refuellings have taken place.", "Tanker operations", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, ((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(aircraft.get_Longitude((GlobalVariables.BooleanObject)null), aircraft.get_Latitude((GlobalVariables.BooleanObject)null)));
					if (!GlobalVariables.AI_REWORK)
					{
						airOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					else
					{
						aI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
					}
				}
			}
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				byte? b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
				if (((!flag) ?? flag) == true && myUnit.ActiveMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0 && !myUnit.IsGroupWingman())
				{
					Aircraft aircraft2 = method_0();
					double TotalCurrent = 0.0;
					double TotalMax = 0.0;
					if (aircraft2.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) < (double)myUnit.ActiveMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0)
					{
						GeoPoint intermediateTargetPoint = method_0().AI.IntermediateTargetPointForRefuelCalcs();
						bool MissionPlanner_PostponedRefuelling = false;
						bool IsManual = false;
						ActiveUnit theSelectedTanker = null;
						List<Mission> theSelectedMissions = null;
						string UserFeedback = "";
						bool IsRTB = false;
						if (AttemptToScheduleRefuel(intermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling))
						{
							return;
						}
					}
				}
			}
			List<Waypoint> WaypointList = myUnit.Navigator.PlottedCourse.ToList();
			SwitchToNearestWaypoint(ref WaypointList, ForceObjectiveWaypointRemoval: false, IsBingoCheck: false);
			return;
			IL_021f:
			if (method_0()._StatusBefore_NeedToRefuel == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
			{
				if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
				{
					activeUnitStatus = method_0()._StatusBefore_NeedToRefuel;
				}
				else
				{
					activeUnitStatus = (myUnit.Navigator.HasFlightPlan ? ActiveUnit._ActiveUnitStatus.OnPlottedCourse : ActiveUnit._ActiveUnitStatus.Tasked);
					if (myUnit.Navigator.HasFlight)
					{
						myUnit.Navigator.get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne);
					}
				}
			}
			else
			{
				activeUnitStatus = method_0()._StatusBefore_NeedToRefuel;
			}
			goto IL_02cb;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100418", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_6(int int_0, Aircraft aircraft_2)
	{
		foreach (ActiveUnit.ActiveUnit_Struct a2AR_NumberOfReceiverHookup in A2AR_NumberOfReceiverHookups)
		{
			if (Operators.CompareString(a2AR_NumberOfReceiverHookup.ObjectId, aircraft_2.ObjectID, false) == 0)
			{
				return true;
			}
		}
		if (!A2AR_NumberOfReceiverHookups.Contains(new ActiveUnit.ActiveUnit_Struct(((ActiveUnit)aircraft_2).get_UnitSide(SetSideOnly: false), aircraft_2.ObjectID, aircraft_2.Name, aircraft_2.DBID)))
		{
			return A2AR_NumberOfReceiverHookups.Count < int_0;
		}
		return true;
	}

	public void SwitchToNearestWaypoint(ref List<Waypoint> WaypointList, bool ForceObjectiveWaypointRemoval, bool IsBingoCheck)
	{
		try
		{
			if (WaypointList.Count <= 0)
			{
				return;
			}
			double num = double.MaxValue;
			double num2 = 0.0;
			int num3 = 0;
			bool flag = myUnit.IsOnActiveStrike && !myUnit.AI.IsEscort && method_0().Navigator.IsAutoPlannerPlottedCourse_CruiseIngressRun(WaypointList);
			bool flag2 = method_0().Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || method_0().Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun;
			Waypoint waypoint = default(Waypoint);
			foreach (Waypoint Waypoint in WaypointList)
			{
				if (flag && !IsBingoCheck && (Waypoint.IsExclusivelyStrikeTargetWaypoint() || Waypoint.IsExclusivelyStrikeEgressWaypoint()))
				{
					break;
				}
				if (Waypoint.IsExclusivelyStrikeTargetWaypoint())
				{
					continue;
				}
				double num4 = Math2.CalcDist_Angular(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), Waypoint.Latitude, Waypoint.Longitude);
				if (num3 != 0)
				{
					num2 = Math2.CalcDist_Angular(Waypoint.Latitude, Waypoint.Longitude, waypoint.Latitude, waypoint.Longitude);
					if (num > num4 || num4 <= num2)
					{
						ActiveUnit_Navigator navigator = myUnit.Navigator;
						double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						double latitude = Waypoint.Latitude;
						double longitude = Waypoint.Longitude;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (!navigator.PathLineIsInterrupted(startLat, startLon, latitude, longitude, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
						{
							waypoint = Waypoint;
							num = num4;
						}
					}
				}
				else
				{
					num2 = num4;
					waypoint = Waypoint;
					num = num4;
				}
				num3++;
				if (!ForceObjectiveWaypointRemoval)
				{
					if (!flag)
					{
						if (flag2)
						{
							if (Waypoint.IsStationWaypoint() || Waypoint.FlightFormation == Waypoint.Formation.Split || Waypoint.Creator == Waypoint.WaypointCreator.Navigator)
							{
								break;
							}
						}
						else if (Waypoint.IsStationWaypoint() || Waypoint.FlightFormation == Waypoint.Formation.Split || Waypoint.Creator == Waypoint.WaypointCreator.Navigator)
						{
							break;
						}
					}
					else if (Waypoint.IsExclusivelyStrikeTargetWaypoint() || Waypoint.IsExclusivelyStrikeEgressWaypoint())
					{
						break;
					}
					if (Waypoint.Time_Zulu.HasValue && Waypoint.Hold_Time > 0f)
					{
						break;
					}
				}
				if (Waypoint.Type == Waypoint.WaypointType.LandingMarshal || Waypoint.Type == Waypoint.WaypointType.Land)
				{
					break;
				}
			}
			if (!IsBingoCheck)
			{
				if (waypoint == null || num3 <= 1)
				{
					if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse || myUnit.Navigator.get_Flight(HierarchySearch: true) == null)
					{
						return;
					}
					int ReasonForInterrupt = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() - 1;
					int num5 = 1;
					while (true)
					{
						if (num5 <= ReasonForInterrupt)
						{
							if (myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num5] == myUnit.Navigator.PlottedCourse.FirstOrDefault())
							{
								break;
							}
							num5++;
							continue;
						}
						return;
					}
					Waypoint waypoint2 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num5 - 1];
					if (waypoint2.Type == Waypoint.WaypointType.TakeOff)
					{
						if (GlobalVariables.AI_REWORK)
						{
							((Aircraft)myUnit).AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB, [SpecialName] (float _elapsedTime) =>
							{
								myUnit.AI.ReturnToBase(_elapsedTime);
							});
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB;
							myUnit.AI.ReturnToBase(myUnit.ParentScen.GameResolution);
						}
					}
					else
					{
						myUnit.Navigator.ApplyWaypointSpeedAltToUnit(waypoint2);
						myUnit.Navigator.ApplyWaypointDoctrineToUnit(waypoint2);
						myUnit.Navigator.ApplyWaypointActionToUnit(waypoint2);
					}
					return;
				}
			}
			else if (waypoint == null || num3 <= 1)
			{
				return;
			}
			List<Waypoint> list = new List<Waypoint>();
			if (IsBingoCheck)
			{
				foreach (Waypoint Waypoint2 in WaypointList)
				{
					if (Waypoint2 != waypoint)
					{
						list.Add(Waypoint2);
						continue;
					}
					break;
				}
			}
			else
			{
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				foreach (Waypoint waypoint3 in plottedCourse)
				{
					if (waypoint3 == waypoint)
					{
						break;
					}
					list.Add(waypoint3);
				}
			}
			if (!IsBingoCheck && !Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true)) && !Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan) && list.Count == 0)
			{
				if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					return;
				}
				int num7 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() - 1;
				int num8 = 1;
				while (true)
				{
					if (num8 <= num7)
					{
						if (myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num8] == myUnit.Navigator.PlottedCourse[0])
						{
							break;
						}
						num8++;
						continue;
					}
					return;
				}
				Waypoint myWaypoint = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num8 - 1];
				myUnit.Navigator.ApplyWaypointSpeedAltToUnit(myWaypoint);
				myUnit.Navigator.ApplyWaypointDoctrineToUnit(myWaypoint);
				myUnit.Navigator.ApplyWaypointActionToUnit(myWaypoint);
				return;
			}
			if (!IsBingoCheck)
			{
				{
					foreach (Waypoint item in list)
					{
						if (item != waypoint)
						{
							Aircraft_Navigator navigator2 = method_0().Navigator;
							bool ForceWaypointSwitch = true;
							bool ForceStationAbort = false;
							navigator2.CheckIfReachedWaypoint_AND_Apply_WP_logic(0f, ref ForceWaypointSwitch, ref ForceStationAbort);
							if (method_0().Navigator.PlottedCourse.Contains(item))
							{
								method_0().Navigator.RemoveWaypoint_Soft(item, RemoveWingmanWaypoints: false);
							}
							continue;
						}
						break;
					}
					return;
				}
			}
			foreach (Waypoint item2 in list)
			{
				if (item2 != waypoint)
				{
					WaypointList.Remove(item2);
					continue;
				}
				break;
			}
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
			ProjectData.ClearProjectError();
		}
	}

	public void EnterLandingQueue(ActiveUnit LandingDestination)
	{
		if (method_16(LandingDestination, bool_0: true) == AirOpsAttemptResult.Success)
		{
			Condition = _AirOpsCondition.HoldingOnLandingQueue;
			if (!LandingDestination.AirOps.LandingQueue_ReadOnly.Contains(method_0()))
			{
				LandingDestination.AirOps.LandingQueue_AddAircraft(method_0());
			}
		}
	}

	public void AttemptToPark(bool NormalLandingSequence = true, bool RearmRefuel = true, bool AbortLaunch = false)
	{
		try
		{
			if (Information.IsNothing((object)CurrentHostUnit))
			{
				return;
			}
			if (Information.IsNothing((object)HostAirFacility) && !Information.IsNothing((object)this.get_AssignedHostUnit(PickNewAssignedHost: false)))
			{
				this.get_AssignedHostUnit(PickNewAssignedHost: false).AirOps.AddThisAircraft(method_0(), GameIsRunning: true);
			}
			if (!NormalLandingSequence)
			{
				int num = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
				AirFacility airFacility;
				while (true)
				{
					if (num >= 0)
					{
						airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num];
						if (airFacility.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility.AirFacType == AirFacility._AirFacType.Hangar && airFacility.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
						{
							break;
						}
						num += -1;
						continue;
					}
					int num2 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					while (true)
					{
						if (num2 >= 0)
						{
							airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num2];
							if (airFacility.AirFacType == AirFacility._AirFacType.OpenParking && airFacility.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num2 += -1;
							continue;
						}
						int num3 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num3 >= 0)
							{
								airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num3];
								if ((airFacility.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility.AirFacType == AirFacility._AirFacType.Hangar) || airFacility.AirFacType == AirFacility._AirFacType.OpenParking)
								{
									break;
								}
								num3 += -1;
								continue;
							}
							if (!GlobalVariables.AI_REWORK && method_0().IsHelicopter && HostAirFacility.IsPad())
							{
								Condition = _AirOpsCondition.Parked;
								method_0().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else
							{
								ConditionTimer = 5f;
							}
							return;
						}
						method_14(airFacility, RearmRefuel, AbortLaunch);
						return;
					}
					method_14(airFacility, RearmRefuel, AbortLaunch);
					return;
				}
				method_14(airFacility, RearmRefuel, AbortLaunch);
				return;
			}
			switch (HostAirFacility.AirFacType)
			{
			case AirFacility._AirFacType.Runway:
			case AirFacility._AirFacType.RunwayWithArrest:
			case AirFacility._AirFacType.Catapult:
			case AirFacility._AirFacType.SkiJump:
			case AirFacility._AirFacType.CarrierArrestingGear:
			case AirFacility._AirFacType.Pad:
			case AirFacility._AirFacType.PadWithHaulDown:
			{
				bool flag = default(bool);
				for (int j = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
				{
					AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[j];
					if (airFacility5.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility5.AirFacType == AirFacility._AirFacType.Hangar && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					int num9 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					AirFacility airFacility5;
					while (true)
					{
						if (num9 >= 0)
						{
							airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num9];
							if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num9 += -1;
							continue;
						}
						int num10 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num10 >= 0)
							{
								airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num10];
								if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility5.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility5.AirFacType == AirFacility._AirFacType.Hangar && method_0().Size <= airFacility5.MaxAircraftSize))
								{
									break;
								}
								num10 += -1;
								continue;
							}
							if (!GlobalVariables.AI_REWORK && method_0().IsHelicopter && HostAirFacility.IsPad())
							{
								Condition = _AirOpsCondition.Parked;
								method_0().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else
							{
								ConditionTimer = 5f;
							}
							return;
						}
						method_14(airFacility5, RearmRefuel, AbortLaunch);
						return;
					}
					method_14(airFacility5, RearmRefuel, AbortLaunch);
					break;
				}
				if (HostAirFacility.ParentPlatform.IsShip)
				{
					Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
					if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
					{
						for (int k = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; k >= 0; k += -1)
						{
							AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[k];
							if (airFacility5.IsParkingFacility() && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								method_14(airFacility5, RearmRefuel, AbortLaunch);
								return;
							}
						}
						for (int l = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; l >= 0; l += -1)
						{
							AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[l];
							if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility5.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility5.AirFacType == AirFacility._AirFacType.Hangar))
							{
								method_14(airFacility5, RearmRefuel, AbortLaunch);
								return;
							}
						}
					}
				}
				IEnumerable<AirFacility> enumerable = from theAF in base.get_RunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
					orderby theAF.MaxAircraftSize
					select theAF;
				if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0)
				{
					IEnumerable<AirFacility> enumerable2 = RunwayAccessPointCapacityAvailableForThisAircraft_myUnitSize(false, method_0(), CurrentHostUnit, enumerable);
					if (!Information.IsNothing((object)enumerable2) && enumerable2.Count() > 0)
					{
						method_18(enumerable2.ElementAtOrDefault(0), (Enum6)1);
						break;
					}
					int num11 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					AirFacility airFacility5;
					while (true)
					{
						if (num11 >= 0)
						{
							airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num11];
							if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num11 += -1;
							continue;
						}
						int num12 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num12 >= 0)
							{
								airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num12];
								if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility5.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility5.AirFacType == AirFacility._AirFacType.Hangar))
								{
									break;
								}
								num12 += -1;
								continue;
							}
							ConditionTimer = 5f;
							CurrentHostUnit.AirOps.MakeWayForLandings();
							return;
						}
						method_14(airFacility5, RearmRefuel, AbortLaunch);
						return;
					}
					method_14(airFacility5, RearmRefuel, AbortLaunch);
				}
				else
				{
					if (!HostAirFacility.ParentPlatform.IsShip)
					{
						break;
					}
					int num13 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					AirFacility airFacility5;
					while (true)
					{
						if (num13 >= 0)
						{
							airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num13];
							if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num13 += -1;
							continue;
						}
						int num14 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num14 >= 0)
							{
								airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num14];
								if (airFacility5.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility5.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility5.AirFacType == AirFacility._AirFacType.Hangar))
								{
									break;
								}
								num14 += -1;
								continue;
							}
							ConditionTimer = 5f;
							return;
						}
						method_14(airFacility5, RearmRefuel, AbortLaunch);
						return;
					}
					method_14(airFacility5, RearmRefuel, AbortLaunch);
				}
				break;
			}
			case AirFacility._AirFacType.const_13:
			{
				if (AbortLaunch)
				{
					if (!RearmRefuel)
					{
						Condition = _AirOpsCondition.Readying;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
					break;
				}
				AirFacility airFacility3 = null;
				int num7 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
				while (true)
				{
					if (num7 >= 0)
					{
						airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[num7];
						if (airFacility3.Status == PlatformComponent._ComponentStatus.Destroyed || airFacility3.AirFacType != AirFacility._AirFacType.Hangar || airFacility3.CanHostThisAircraft_BySize(method_0()) != AirOpsAttemptResult.Success)
						{
							num7 += -1;
							continue;
						}
						method_14(airFacility3, RearmRefuel, AbortLaunch);
						break;
					}
					if (airFacility3 == null)
					{
						AirFacility.AddUAV_Class1_Hanger(CurrentHostUnit);
						for (int i = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
						{
							airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[i];
							if (airFacility3.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility3.AirFacType == AirFacility._AirFacType.Hangar && airFacility3.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								method_14(airFacility3, RearmRefuel, AbortLaunch);
								return;
							}
						}
					}
					if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
						}
					}
					break;
				}
				break;
			}
			case AirFacility._AirFacType.Hangar:
				if (!AbortLaunch)
				{
					if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
						}
					}
				}
				else
				{
					if (!RearmRefuel)
					{
						Condition = _AirOpsCondition.Readying;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
				}
				break;
			case AirFacility._AirFacType.OpenParking:
				if (!AbortLaunch)
				{
					if (Condition == _AirOpsCondition.Landing_PostTouchdown)
					{
						int num8 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						AirFacility airFacility4;
						while (true)
						{
							if (num8 >= 0)
							{
								airFacility4 = CurrentHostUnit.AirFacilities_ReadOnly[num8];
								if (airFacility4.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility4.AirFacType == AirFacility._AirFacType.Hangar && airFacility4.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
								{
									break;
								}
								num8 += -1;
								continue;
							}
							Condition = _AirOpsCondition.Readying;
							Aircraft theAircraft;
							if (Information.IsNothing((object)method_0().Loadout))
							{
								Condition = _AirOpsCondition.Readying;
								ConditionTimer = 1800f;
							}
							else
							{
								ActiveUnit_AirOps airOps = CurrentHostUnit.AirOps;
								theAircraft = method_0();
								airOps.OutfitAC(ref theAircraft, method_0().Loadout.DBID, method_0().Loadout.DBID, ReadyImmediately: false, method_0().Loadout.NoOptionalWeapons, !myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), ManualAction: false, PlayerFeedback: true);
							}
							ActiveUnit_AirOps airOps2 = CurrentHostUnit.AirOps;
							theAircraft = method_0();
							airOps2.RefuelAC_Simple(ref theAircraft);
							ActiveUnit_AirOps airOps3 = CurrentHostUnit.AirOps;
							theAircraft = method_0();
							airOps3.RepairAC(ref theAircraft);
							return;
						}
						method_14(airFacility4, RearmRefuel, AbortLaunch);
					}
					else if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
						}
					}
				}
				else
				{
					if (!RearmRefuel)
					{
						Condition = _AirOpsCondition.Readying;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
				}
				break;
			case AirFacility._AirFacType.RunwayGrade_Taxiway:
			case AirFacility._AirFacType.RunwayAccessPoint:
			case AirFacility._AirFacType.Elevator:
			{
				int num4 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
				AirFacility airFacility2;
				while (true)
				{
					if (num4 >= 0)
					{
						airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num4];
						if (airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility2.AirFacType == AirFacility._AirFacType.Hangar && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
						{
							break;
						}
						num4 += -1;
						continue;
					}
					int num5 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					while (true)
					{
						if (num5 >= 0)
						{
							airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num5];
							if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num5 += -1;
							continue;
						}
						int num6 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num6 >= 0)
							{
								airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num6];
								if ((airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility2.AirFacType == AirFacility._AirFacType.Hangar) || airFacility2.AirFacType == AirFacility._AirFacType.OpenParking)
								{
									break;
								}
								num6 += -1;
								continue;
							}
							ConditionTimer = 5f;
							return;
						}
						method_14(airFacility2, RearmRefuel, AbortLaunch);
						return;
					}
					method_14(airFacility2, RearmRefuel, AbortLaunch);
					return;
				}
				method_14(airFacility2, RearmRefuel, AbortLaunch);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101191", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateQuickTurnaroundSettings_TakeOff(ref Aircraft theAC)
	{
		if (theAC.AirOps.QuickTurnaround_Enabled)
		{
			QuickTurnaround_SortiesFlown++;
		}
		else
		{
			QuickTurnaround_SortiesFlown = 0;
		}
	}

	public void UpdateQuickTurnaroundSettings_Landing(ref Aircraft theAC)
	{
		QuickTurnaround_AirborneTime_Flown += theAC.AirborneTime;
	}

	public void UpdateQuickTurnaroundSettings_StepDown(ref Aircraft_AirOps theAO, ref Aircraft theAC)
	{
		if (!Information.IsNothing((object)theAC.Loadout) && theAO.ConditionTimer < (float)(theAO.QuickTurnaround_TimePentalty * 60))
		{
			theAO.ConditionTimer = theAO.QuickTurnaround_TimePentalty * 60;
		}
		theAO.QuickTurnaround_SortiesFlown = 0;
		theAO.QuickTurnaround_TimePentalty = 0;
		theAO.QuickTurnaround_AirborneTime_Flown = 0f;
		theAO.QuickTurnaround_AirborneTime_SortieAverage = 0f;
	}

	public void UpdateQuickTurnaroundSettings_ContinueFlying(ref Aircraft_AirOps theAO, ref Aircraft theAC)
	{
		if (!Information.IsNothing((object)theAC.Loadout))
		{
			theAO.ConditionTimer = theAC.Loadout.QuickTurnaround_ReadyTime * 60;
		}
		theAO.QuickTurnaround_AirborneTime_SortieAverage = theAO.QuickTurnaround_AirborneTime_Flown / (float)theAO.QuickTurnaround_SortiesFlown;
		if (float.IsNaN(theAO.QuickTurnaround_AirborneTime_SortieAverage))
		{
			theAO.QuickTurnaround_AirborneTime_SortieAverage = 0f;
		}
	}

	public void UpdateQuickTurnaroundSettings_Reset(ref Aircraft_AirOps theAO)
	{
		if (theAO.QuickTurnaround_Enabled)
		{
			theAO.QuickTurnaround_Enabled = false;
			theAO.QuickTurnaround_SortiesFlown = 0;
			theAO.QuickTurnaround_TimePentalty = 0;
			theAO.QuickTurnaround_AirborneTime_Flown = 0f;
			theAO.QuickTurnaround_AirborneTime_SortieAverage = 0f;
		}
	}

	public void AttemptToMoveToFlightDeck()
	{
		try
		{
			if (Information.IsNothing((object)HostAirFacility) || Information.IsNothing((object)HostAirFacility.ParentPlatform))
			{
				return;
			}
			bool flag = default(bool);
			if (!HostAirFacility.ParentPlatform.IsShip)
			{
				flag = true;
			}
			if (!flag)
			{
				Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
				if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
				{
					flag = true;
				}
			}
			if (!flag && HostAirFacility.AirFacType == AirFacility._AirFacType.OpenParking)
			{
				flag = true;
			}
			if (flag)
			{
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing((object)CurrentHostUnit))
				{
					string text = "";
					if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
					{
						text = " (" + method_0().UnitClass + ")";
					}
					method_0().AddMessage(method_0().Name + text + " is ready at " + CurrentHostUnit.Name, method_0().Name + " ready", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else if (Information.IsNothing((object)method_0().Loadout))
			{
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing((object)CurrentHostUnit))
				{
					string text2 = "";
					if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
					{
						text2 = " (" + method_0().UnitClass + ")";
					}
					method_0().AddMessage(method_0().Name + text2 + " is ready at " + CurrentHostUnit.Name, method_0().Name + " ready", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else if (method_0().Loadout.Role != Loadout.LoadoutRole.Reserve && method_0().Loadout.Role != Loadout.LoadoutRole.Unavailable && method_0().Loadout.Role != Loadout.LoadoutRole.PackedForCargo)
			{
				switch (HostAirFacility.AirFacType)
				{
				case AirFacility._AirFacType.Elevator:
				{
					for (int num4 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num4 >= 0; num4 += -1)
					{
						AirFacility airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num4];
						if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success && airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && !((double)airFacility2.ParkingSpace_Free / (double)(int)airFacility2.MaxAircraftSize <= 4.0))
						{
							method_14(airFacility2, bool_0: false, bool_1: false);
							Condition = _AirOpsCondition.Parked;
							return;
						}
					}
					for (int num5 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num5 >= 0; num5 += -1)
					{
						AirFacility airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num5];
						if (airFacility2.AirFacType == AirFacility._AirFacType.Hangar && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
						{
							method_14(airFacility2, bool_0: false, bool_1: false);
							Condition = _AirOpsCondition.Parked;
							return;
						}
					}
					break;
				}
				case AirFacility._AirFacType.Hangar:
				{
					if (!Information.IsNothing((object)CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing((object)CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly()))
					{
						List<AirFacility> list = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsTransitFacility() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
						List<AirFacility> list2 = list.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
						if (((CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count > 0) && list.Count - list2.Count <= 2) || (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list.Count - list2.Count <= 2))
						{
							break;
						}
					}
					int num2 = default(int);
					for (int num = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num >= 0; num += -1)
					{
						AirFacility airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num];
						if (airFacility.AirFacType != AirFacility._AirFacType.Elevator)
						{
							continue;
						}
						foreach (Aircraft value in airFacility.HostedAircraft.Values)
						{
							if (value.AirOps.Condition == _AirOpsCondition.TaxyingToFlightDeck)
							{
								num2 += (int)value.Size;
							}
						}
					}
					bool flag2 = default(bool);
					for (int num3 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num3 >= 0; num3 += -1)
					{
						AirFacility airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num3];
						if (airFacility.AirFacType == AirFacility._AirFacType.OpenParking && airFacility.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success && airFacility.Status != PlatformComponent._ComponentStatus.Destroyed && !((double)airFacility.ParkingSpace_Free / (double)(int)airFacility.MaxAircraftSize <= (double)(4 + num2)))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					IEnumerable<AirFacility> enumerable = from theAF in base.get_RunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
						orderby theAF.MaxAircraftSize
						select theAF;
					if (Information.IsNothing((object)enumerable) || enumerable.Count() <= 0)
					{
						break;
					}
					IEnumerable<AirFacility> enumerable2 = RunwayAccessPointCapacityAvailableForThisAircraft_myUnitSize(null, method_0(), CurrentHostUnit, enumerable);
					if (Information.IsNothing((object)enumerable2) || enumerable2.Count() <= 0)
					{
						break;
					}
					if (Condition != _AirOpsCondition.Parked && !Information.IsNothing((object)CurrentHostUnit))
					{
						string text3 = "";
						if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
						{
							text3 = " (" + method_0().UnitClass + ")";
						}
						method_0().AddMessage(method_0().Name + text3 + " is ready at " + CurrentHostUnit.Name + ", moving to flight deck...", method_0().Name + " ready", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					method_18(enumerable2.ElementAtOrDefault(0), (Enum6)2);
					return;
				}
				}
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing((object)CurrentHostUnit))
				{
					string text4 = "";
					if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
					{
						text4 = " (" + method_0().UnitClass + ")";
					}
					method_0().AddMessage(method_0().Name + text4 + " is ready at " + CurrentHostUnit.Name, method_0().Name + " ready", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else if (Condition != _AirOpsCondition.Parked)
			{
				Condition = _AirOpsCondition.Parked;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100419", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7()
	{
		Condition = _AirOpsCondition.Airborne;
		ConditionTimer = 1f;
	}

	private void method_8()
	{
		try
		{
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			if (!Information.IsNothing((object)actualDestinationHost))
			{
				if (actualDestinationHost.AirOps.LandingQueue_ReadOnly.Count() != 0 && actualDestinationHost.AirOps.LandingQueue_ReadOnly[0] != myUnit)
				{
					return;
				}
				IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(method_0(), TakeOff: false, IgnoreOtherAircraft: true, ActualDestinationHost, method_0().CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac;
				IEnumerable<AirFacility> enumerable2 = null;
				if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0)
				{
					enumerable2 = RunwayCapacityAvailableForThisAircraft_myUnitSize(TakeOff: false, TouchDown: false, method_0(), ActualDestinationHost, method_0().CanLandVertically, enumerable);
				}
				if (enumerable2 != null && enumerable2.Count() != 0)
				{
					using (IEnumerator<AirFacility> enumerator = enumerable.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							AirFacility current = enumerator.Current;
							method_9(current);
							return;
						}
					}
					ConditionTimer = 10f;
				}
				else if (method_16(actualDestinationHost, bool_0: true) == AirOpsAttemptResult.Success)
				{
					ConditionTimer = 5f;
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " is not able to land on " + actualDestinationHost.Name, myUnit.Name + " is not able to land ", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					Condition = _AirOpsCondition.Airborne;
				}
			}
			else
			{
				method_7();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100420", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(AirFacility airFacility_1)
	{
		ActualDestinationHost.AirOps.LandingQueue_RemoveAircraft(method_0());
		Condition = _AirOpsCondition.Landing_PreTouchdown;
		ConditionTimer = 120f;
	}

	public void AttemptToFinishLanding(float elapsedTime)
	{
		try
		{
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			IEnumerable<AirFacility> enumerable = method_10(actualDestinationHost);
			bool flag = actualDestinationHost.AirOps.CanHostThisAircraft(method_0()) == AirOpsAttemptResult.Success;
			if (Information.IsNothing((object)enumerable))
			{
				Aircraft_Navigator navigator = method_0().Navigator;
				float theSpeed = myUnit.Kinematics.GetMaximumSpeed(method_0().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
				Aircraft_Navigator navigator2 = method_0().Navigator;
				bool theAltitude_TerrainFollowing = false;
				float bingoFuelAltitude = navigator2.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
				Aircraft aircraft;
				ActiveUnit theAU;
				bool useTerrainFollowing = (aircraft = method_0()).get_DesiredAltitude_UseTerrainFollowing(theAU = method_0());
				navigator.HeadToLandingAssemblyPoint(elapsedTime, actualDestinationHost, theSpeed, bingoFuelAltitude, ref useTerrainFollowing);
				aircraft.set_DesiredAltitude_UseTerrainFollowing(theAU, useTerrainFollowing);
			}
			else if (flag)
			{
				TouchDown(enumerable.ElementAtOrDefault(0));
			}
			else
			{
				method_0().AI.ReturnToBase(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100421", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private IEnumerable<AirFacility> method_10(ActiveUnit activeUnit_2)
	{
		if (activeUnit_2.AirFacilities_ReadOnly.Length == 0)
		{
			return null;
		}
		IEnumerable<AirFacility> result = default(IEnumerable<AirFacility>);
		try
		{
			IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(method_0(), TakeOff: false, IgnoreOtherAircraft: false, activeUnit_2, method_0().CanLandVertically)
				orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
				select theAirFac;
			IEnumerable<AirFacility> enumerable2 = default(IEnumerable<AirFacility>);
			if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0)
			{
				enumerable2 = RunwayCapacityAvailableForThisAircraft_myUnitSize(TakeOff: false, TouchDown: true, method_0(), activeUnit_2, method_0().CanLandVertically, enumerable);
			}
			if (!Information.IsNothing((object)enumerable2) && enumerable2.Count() > 0)
			{
				result = enumerable2;
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100422", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void TouchDown(AirFacility theRunway, bool NormalLandingSequence = true)
	{
		try
		{
			if (!method_0().AirOps.Can_Land_Weather_Limitation())
			{
				int num = GameGeneral.GlobalRNG.Next(100);
				if (num < 50)
				{
					method_0().set_DamagePts(ScenEditAction: false, (Weapon)null, method_0().get_DamagePts(ScenEditAction: false, (Weapon)null) - 5f);
					if (num < 20)
					{
						if (num < 5)
						{
							if (theRunway.DamageSeverity == PlatformComponent._DamageSeverityFactor.Heavy)
							{
								theRunway.Destroy(theRunway.ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
							}
							else
							{
								theRunway.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
							}
							myUnit.AddMessage("Crashed on " + theRunway.Name + " during landing due to athospheric condition", "Crashed during landing due to athmosperic condition ", LoggedMessage.MessageType.UnitLost, 1, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
							method_0().Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Crashed on " + theRunway.Name + " during landing due to athospheric condition", "Crashed on " + theRunway.Name + " during landing due to athospheric condition");
						}
						else
						{
							myUnit.AddMessage("Crashed on " + theRunway.Name + " during landing due to athospheric condition", "Crashed during landing due to athmosperic condition ", LoggedMessage.MessageType.UnitLost, 1, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
							method_0().Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Crashed during landing due to athospheric condition", "Crashed during landing due to athospheric condition");
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1004265467483", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			Mission mission_ = myUnit.ActiveMissionOrPackage();
			Aircraft theAC = method_0();
			UpdateQuickTurnaroundSettings_Landing(ref theAC);
			method_0().Navigator.SupportMission_NextRefPoint = null;
			myUnit.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
			myUnit.FuelState = ActiveUnit._ActiveUnitFuelState.None;
			myUnit.AI.HasCaughtUpWithGroup = false;
			A2AR_NumberOfReceiverHookups.Add(new ActiveUnit.ActiveUnit_Struct());
			if (NormalLandingSequence)
			{
				HostAirFacility = theRunway;
				Condition = _AirOpsCondition.Landing_PostTouchdown;
				switch (method_0().VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
					ConditionTimer = 20f;
					break;
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					ConditionTimer = 30f;
					break;
				}
				method_11(mission_);
			}
			else
			{
				Condition = _AirOpsCondition.Landing_PostTouchdown;
				if (!Information.IsNothing((object)theRunway) && Information.IsNothing((object)HostAirFacility))
				{
					HostAirFacility = theRunway;
				}
				method_11(mission_);
				AttemptToPark(NormalLandingSequence: false);
			}
			landingEventHandler_0?.Invoke(method_0());
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)myUnit.ActiveMissionOrPackage()).Behavior)
					{
					case FerryMission.FerryMissionBehavior.OneWay:
					{
						ActiveUnit activeUnit = myUnit;
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
						this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
						break;
					}
					case FerryMission.FerryMissionBehavior.Random:
						PickNewAssignedHost_RandomWithinRange(this.get_AssignedHostUnit(PickNewAssignedHost: false));
						break;
					}
				}
				if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support && ((SupportMission)myUnit.ActiveMissionOrPackage()).OneTimeOnly)
				{
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				}
			}
			if (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup)
			{
				myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
			}
			myUnit.Navigator.ClearPlottedCourse();
			myUnit.GoInoperative();
			myUnit.Navigator.RemoveFromFlightAndCleanUpMission();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100423", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void TakeOff(float elapsedTime)
	{
		if (CurrentHostUnit == null)
		{
			return;
		}
		try
		{
			string name = CurrentHostUnit.Name;
			Aircraft theAC = (Aircraft)myUnit;
			UpdateQuickTurnaroundSettings_TakeOff(ref theAC);
			myUnit.CurrentSpeed = (float)(2.0 / 3.0 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false));
			myUnit.CurrentHeading = CurrentHostUnit.CurrentHeading;
			myUnit.Kinematics.DesiredAltitudeOverride = false;
			myUnit.Kinematics.DesiredSpeedOverride = null;
			if (this.get_AssignedHostUnit(PickNewAssignedHost: false) == null)
			{
				this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
			}
			ActiveUnit currentHostUnit = CurrentHostUnit;
			if (method_0().Loadout != null && myUnit.ActiveMissionOrPackage() != null)
			{
				if (myUnit.Navigator.HasFlightPlan && myUnit.Navigator.PlottedCourse != null && myUnit.Navigator.PlottedCourse.Length > 0 && myUnit.Navigator.PlottedCourse[0].Category == Waypoint.WaypointCategory.FlightPlan && myUnit.Navigator.PlottedCourse[0].DesiredAltitude.HasValue)
				{
					myUnit.DesiredAltitude = myUnit.Navigator.PlottedCourse[0].DesiredAltitude.Value;
				}
				ActiveUnit activeUnit = myUnit;
				ActiveUnit_AI aI = myUnit.AI;
				double theLatitude = (theAC = method_0()).get_Latitude((GlobalVariables.BooleanObject)null);
				Aircraft aircraft;
				double theLongitude = (aircraft = method_0()).get_Longitude((GlobalVariables.BooleanObject)null);
				float desiredAltitude = aI.MostRealisticFormUpAltitude(ref theLatitude, ref theLongitude);
				aircraft.set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
				theAC.set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
				activeUnit.DesiredAltitude = desiredAltitude;
			}
			else
			{
				ActiveUnit activeUnit2 = myUnit;
				Aircraft aircraft = method_0();
				ActiveUnit activeUnit3;
				ActiveUnit theAU;
				bool Return_theAltitude_TerrainFollowing = (activeUnit3 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
				float desiredAltitude2 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft, ActiveUnit.Throttle.Loiter, ref Return_theAltitude_TerrainFollowing);
				activeUnit3.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
				activeUnit2.DesiredAltitude = desiredAltitude2;
			}
			if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (!myUnit.Navigator.HasFlightPlan)
				{
					if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Ferry && ((FerryMission)myUnit.ActiveMissionOrPackage()).Behavior == FerryMission.FerryMissionBehavior.Cycle)
					{
						if (ActualDestinationHost != null)
						{
							if (myUnit.AI.GetMissionStateFlag(4u) && Operators.CompareString(ActualDestinationHost.ObjectID, CurrentHostUnit.ObjectID, false) == 0)
							{
								myUnit.AI.ChangeCycleLeg();
							}
							else if (!myUnit.AI.GetMissionStateFlag(4u) && Operators.CompareString(this.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID, CurrentHostUnit.ObjectID, false) == 0)
							{
								myUnit.AI.InitializeCycleFerry();
							}
						}
						else
						{
							((Aircraft_AirOps)myUnit.AirOps).AttemptToPark(NormalLandingSequence: true, RearmRefuel: false, AbortLaunch: true);
							if (myUnit.IsGroupMember())
							{
								myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
					}
				}
				else
				{
					ActiveUnit actualDestinationHost = ActualDestinationHost;
					if (actualDestinationHost != null)
					{
						if (Operators.CompareString(myUnit.Navigator.get_Flight(HierarchySearch: true).LandingLocation_HostUnitObjectID, actualDestinationHost.ObjectID, false) != 0)
						{
							if (!myUnit.ParentScen.ActiveUnits.ContainsKey(myUnit.Navigator.get_Flight(HierarchySearch: true).LandingLocation_HostUnitObjectID))
							{
								string text = "";
								if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
								{
									text = " (" + method_0().UnitClass + ")";
								}
								method_0().AddMessage("The flightpan for aircraft " + method_0().Name + text + " is set to land at a unit that no longer exists. Reverting to using " + name + " as return base.", "Reseting flightplan", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							else
							{
								this.set_AssignedHostUnit(PickNewAssignedHost: false, myUnit.ParentScen.ActiveUnits[myUnit.Navigator.get_Flight(HierarchySearch: true).LandingLocation_HostUnitObjectID]);
							}
						}
					}
					else if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
			}
			HostAirFacility = null;
			myUnit.set_Longitude((GlobalVariables.BooleanObject)null, currentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			myUnit.set_Latitude((GlobalVariables.BooleanObject)null, currentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, currentHostUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 30f);
			Condition = _AirOpsCondition.Airborne;
			tookOffEventHandler_0?.Invoke(method_0());
			if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed || myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Damaged)
			{
				myUnit.Propulsion[0].Repair();
			}
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && !myUnit.IsGroupLead())
			{
				if (method_0().FlightRole == Mission.Flight.FlightElement.LeadElement)
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).DesignateGroupLead_Manual(myUnit);
					foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (value != myUnit && value.Navigator.HasPlottedCourse())
						{
							value.Navigator.ClearPlottedCourse();
						}
					}
				}
				else
				{
					bool flag = true;
					foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (value2 != myUnit && value2.IsOperating())
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).DesignateGroupLead_Manual(myUnit);
					}
				}
			}
			if ((GameGeneral.Beta_PlatformComms & myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && myUnit.get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				HashSet<Module_Unit.Unit> hashSet = new HashSet<Module_Unit.Unit>();
				hashSet.Add(myUnit);
				hashSet.Add(CurrentHostUnit);
				myUnit.get_UnitSide(SetSideOnly: false).CreateNextNetworkUnitsReason(hashSet, CommNetwork.NetworkCreationReason.HomeBaseComm);
			}
			if (!GlobalVariables.AI_REWORK)
			{
				method_0().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			myUnit.AI.HasCaughtUpWithGroup = false;
			myUnit.AI.RefreshVisibleContactsList();
			myUnit.AI.EvaluateTargets(elapsedTime, IgnoreContacStance: true, Immediately: true);
			myUnit.AI.DeterminePrimaryTarget((short)Math.Round(elapsedTime), IgnoreTimeToNextEvaluation: true, CheckCombatRadius: false);
			myUnit.AI.EvaluateThreats(elapsedTime);
			TakeOff_SetFlight_Flightplan_Doctrine(SetFlightplan: true);
			myUnit.AI.EvaluateUnitStatus(elapsedTime, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup && myUnit.Status != ActiveUnit._ActiveUnitStatus.OnPatrol)
			{
				myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
			}
			string text2 = "";
			if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
			{
				text2 = " (" + method_0().UnitClass + ")";
			}
			if (method_0().Status != ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				if (method_0().IsGroupLead() && Information.IsNothing((object)method_0().ActiveMissionOrPackage()))
				{
					method_0().AddMessage(method_0().Name + text2 + " departed " + name + " and is waiting for orders.", method_0().Name + " airborne", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					method_0().AddMessage(method_0().Name + text2 + " departed " + name + ".", method_0().Name + " airborne", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				method_0().AddMessage(method_0().Name + text2 + " departed " + name + " and is waiting for orders.", method_0().Name + " airborne", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			method_0().Sensory.ObeysEMCON = true;
			method_0().Sensory.vmethod_2(method_0().Sensors_Cached);
			method_0().Navigator.PreviousWaypointTime = method_0().ParentScen.Time;
			if (method_0().Navigator.HasPlottedCourse() && method_0().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TakeOff)
			{
				Aircraft_Navigator navigator = method_0().Navigator;
				bool Return_theAltitude_TerrainFollowing = true;
				bool ForceStationAbort = false;
				navigator.CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref Return_theAltitude_TerrainFollowing, ref ForceStationAbort);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100424", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TakeOff_SetFlight_Flightplan_Doctrine(bool SetFlightplan)
	{
		if (myUnit.AssignedMissionOrPackage() == null)
		{
			return;
		}
		myUnit.Doctrine.ApplyInheritanceToAllDoctrineDefinitionsWRAandEMCON();
		if (myUnit.Navigator.get_Flight(HierarchySearch: true) != null && myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan != null)
		{
			myUnit.Navigator.PlottedCourse = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
		}
		if ((!myUnit.Navigator.HasPlottedCourse() || SetFlightplan) && !Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
		{
			if (myUnit.AI.IsEscort)
			{
				method_12(Doctrine._UseIgnorePlottedCourse.Yes, SetFlightplan);
			}
			method_13();
		}
	}

	private void method_11(Mission mission_0)
	{
		try
		{
			IEventExporter[] applicableEventExporters = myUnit.ParentScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportAirOps || Information.IsNothing((object)myUnit.get_UnitSide(SetSideOnly: false)))
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (myUnit.ParentScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string)));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string)));
				if (eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string)));
				pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string)));
				pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string)));
				pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string)));
				pooledDictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("Action", new IEventExporter.EventNotificationParameter("Landing", typeof(string)));
				pooledDictionary.Add("DepartureHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				pooledDictionary.Add("DepartureHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				if (CurrentHostUnit == null)
				{
					if (ActualDestinationHost == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						pooledDictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
						pooledDictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					}
					else
					{
						pooledDictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(ActualDestinationHost.ObjectID, typeof(string)));
						pooledDictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(ActualDestinationHost.Name, typeof(string)));
					}
				}
				else
				{
					pooledDictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(CurrentHostUnit.ObjectID, typeof(string)));
					pooledDictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
				}
				pooledDictionary.Add("MissionID", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.ObjectID, typeof(string)));
				pooledDictionary.Add("MissionName", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.Name, typeof(string)));
				pooledDictionary.Add("TotalFuel", new IEventExporter.EventNotificationParameter(Conversions.ToString(method_0().FuelCapacityCurrent), typeof(int)));
				pooledDictionary.Add("LoadoutID", new IEventExporter.EventNotificationParameter((method_0().Loadout != null) ? method_0().Loadout.DBID.ToString() : string.Empty, typeof(string)));
				pooledDictionary.Add("LoadoutName", new IEventExporter.EventNotificationParameter((method_0().Loadout == null) ? string.Empty : method_0().Loadout.Name, typeof(string)));
				if (Information.IsNothing((object)method_0().Loadout))
				{
					pooledDictionary.Add("LoadoutStores", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
				}
				else
				{
					List<string> list = new List<string>();
					WeaponRec[] weapons = method_0().Loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						list.Add(Conversions.ToString(weaponRec.CurrentLoad) + "x " + Conversions.ToString(weaponRec.int_3));
					}
					pooledDictionary.Add("LoadoutStores", new IEventExporter.EventNotificationParameter(string.Join("|", list), typeof(string)));
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.AirOps, pooledDictionary, myUnit.ParentScen);
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

	private void method_12(Doctrine._UseIgnorePlottedCourse _UseIgnorePlottedCourse_0, bool bool_0)
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				method_0().Doctrine.set_IgnorePlottedCourse(method_0().ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)_UseIgnorePlottedCourse_0);
				if (method_0().Navigator.HasFlightPlan)
				{
					if (!bool_0)
					{
						if (method_0().Navigator.PlottedCourse_PrePlanned.Count() > 0)
						{
							method_0().Navigator.PlottedCourse = method_0().Navigator.PlottedCourse_PrePlanned;
						}
					}
					else
					{
						myUnit.Navigator.ClearPlottedCourse();
						Waypoint[] flightPlan = ((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).FlightPlan;
						foreach (Waypoint theAC in flightPlan)
						{
							Aircraft_Navigator navigator = method_0().Navigator;
							Waypoint[] theArray = navigator.PlottedCourse;
							ArrayExtensions.Add(ref theArray, theAC);
							navigator.PlottedCourse = theArray;
						}
					}
				}
				if (method_0().Navigator.HasFlight)
				{
					((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne);
				}
			}
			else
			{
				Aircraft aircraft = (Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				aircraft.Doctrine.set_IgnorePlottedCourse(aircraft.ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)_UseIgnorePlottedCourse_0);
				foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
				{
					if (!value.IsGroupLead())
					{
						value.Doctrine.set_IgnorePlottedCourse(aircraft.ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)_UseIgnorePlottedCourse_0);
					}
				}
				if (bool_0)
				{
					Waypoint[] theArray2 = new Waypoint[0];
					if (aircraft.Navigator.HasFlightPlan && myUnit.IsGroupLead())
					{
						Waypoint[] flightPlan2 = ((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
						foreach (Waypoint theAC2 in flightPlan2)
						{
							ArrayExtensions.Add(ref theArray2, theAC2);
						}
					}
					if (theArray2.Count() == 0 && (myUnit.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup || !myUnit.get_ParentGroup(UsingMissionPlanner: false).IsFormingUp) && aircraft.Navigator.PlottedCourse_PrePlanned.Count() > 0)
					{
						theArray2 = aircraft.Navigator.PlottedCourse_PrePlanned;
					}
					if (myUnit.Navigator.PlottedCourse.Count() == 0 || theArray2.Count() > 0)
					{
						myUnit.Navigator.PlottedCourse = theArray2;
					}
				}
				if (aircraft.Navigator.HasFlight)
				{
					((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne);
				}
			}
			if (method_0().ThrottleSetting == ActiveUnit.Throttle.FullStop)
			{
				method_0().SetThrottle(ActiveUnit.Throttle.Loiter);
			}
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
			ProjectData.ClearProjectError();
		}
	}

	private void method_13()
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				if (method_0().Navigator.HasFlight)
				{
					((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne);
				}
				return;
			}
			Aircraft aircraft = (Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			if (aircraft.Navigator.HasFlight)
			{
				((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne);
			}
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
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(AirFacility airFacility_1, bool bool_0, bool bool_1)
	{
		try
		{
			HostAirFacility = airFacility_1;
			bool flag = method_0().AirborneTime > 0f;
			if (!bool_0)
			{
				if (bool_1)
				{
					Condition = _AirOpsCondition.Parked;
					ConditionTimer = 0f;
					if (!Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false)))
					{
						myUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
				}
			}
			else
			{
				Aircraft theAircraft;
				if (Information.IsNothing((object)method_0().Loadout))
				{
					Condition = _AirOpsCondition.Readying;
					ConditionTimer = 1800f;
				}
				else
				{
					ActiveUnit_AirOps airOps = CurrentHostUnit.AirOps;
					theAircraft = method_0();
					airOps.OutfitAC(ref theAircraft, method_0().Loadout.DBID, method_0().Loadout.DBID, ReadyImmediately: false, method_0().Loadout.NoOptionalWeapons, !myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), ManualAction: false, PlayerFeedback: true);
				}
				ActiveUnit_AirOps airOps2 = CurrentHostUnit.AirOps;
				theAircraft = method_0();
				airOps2.RefuelAC_Simple(ref theAircraft);
				ActiveUnit_AirOps airOps3 = CurrentHostUnit.AirOps;
				theAircraft = method_0();
				airOps3.RepairAC(ref theAircraft);
			}
			if (!(myUnit.OnboardCargo.Count() > 0 && flag))
			{
				return;
			}
			bool unpackAllContainers = false;
			CargoMission cargoMission = null;
			if (method_0().ActiveMissionOrPackage() != null && method_0().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
			{
				cargoMission = (CargoMission)method_0().ActiveMissionOrPackage();
				unpackAllContainers = cargoMission.UnpackAllContainers;
			}
			ActiveUnit activeUnit = null;
			List<ActiveUnit> list = new List<ActiveUnit>();
			if (!(CurrentHostUnit is Group))
			{
				activeUnit = CurrentHostUnit;
			}
			else
			{
				Group obj = (Group)CurrentHostUnit;
				LockRandom lockRandom_ = GameGeneral.GlobalRNG;
				if (cargoMission != null && cargoMission.DestinationUnit != null && cargoMission.DestinationUnit.IsGroupMember() && cargoMission.DestinationUnit.get_ParentGroup(UsingMissionPlanner: false) == obj)
				{
					list.Add(cargoMission.DestinationUnit);
				}
				if (list.Count == 0)
				{
					foreach (ActiveUnit value in obj.Units.Values)
					{
						if (value.OnboardCargo.Count() > 0)
						{
							list.Add(value);
						}
					}
				}
				if (list.Count == 1)
				{
					activeUnit = list[0];
				}
				else if (list.Count <= 1)
				{
					foreach (ActiveUnit value2 in obj.Units.Values)
					{
						Facility._FacilityCategory category = ((Facility)value2).Category;
						if ((uint)(category - 3001) <= 6u && ((Facility)value2).Area > 400.0)
						{
							list.Add(value2);
						}
					}
					activeUnit = ((list.Count == 1) ? list[0] : ((list.Count <= 1) ? obj.Units.Values.ElementAtOrDefault(lockRandom_.Next(obj.Units.Count)) : list[lockRandom_.Next(list.Count)]));
				}
				else
				{
					activeUnit = list[lockRandom_.Next(list.Count)];
				}
			}
			if (!Information.IsNothing((object)activeUnit))
			{
				int num = ActiveUnit_DockingOps.TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList());
				ConditionTimer = Math.Max(ConditionTimer, num);
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(myUnit, activeUnit, myUnit.OnboardCargo.ToList(), unpackAllContainers);
			}
			method_3();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100425", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UnloadStores()
	{
		bool flag = true;
		try
		{
			if (method_0().Loadout == null)
			{
				return;
			}
			if (!method_0().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				WeaponRec[] weapons = method_0().Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (Weapon.WeaponIsNonRivalrous(weaponRec.int_3, ref myUnit.ParentScen) || weaponRec.CurrentLoad <= 0)
					{
						continue;
					}
					int currentLoad = weaponRec.CurrentLoad;
					for (int j = 1; j <= currentLoad; j++)
					{
						if (Operators.CompareString(CurrentHostUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_3, PriorityToAviationMags: true, AllowAddingNewWeaponRec: true), "OK", false) == 0)
						{
							weaponRec.CurrentLoad--;
							continue;
						}
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				myUnit.AddMessage(myUnit.Name + " is unable to unload weapons due magazine limitations at " + CurrentHostUnit.Name, myUnit.Name + " cannot change loadout", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				method_0().Loadout.Weapons = new WeaponRec[0];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100426", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CanBeRearmedRightNow()
	{
		if (!Information.IsNothing((object)HostAirFacility))
		{
			return HostAirFacility.IsParkingFacility();
		}
		return false;
	}

	public override bool AttemptToRTB(bool ManuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool GroupMembersRTB, ActiveUnit._ActiveUnitStatus GroupMembersRTBStatus, bool DetachFromGroup, bool ClearPlottedCourse)
	{
		bool result;
		try
		{
			if (Condition != _AirOpsCondition.RTB)
			{
				goto IL_0032;
			}
			int num;
			if (!myUnit.IsRTB)
			{
				num = 1;
				goto IL_0033;
			}
			if (ManuallyOrdered || Information.IsNothing((object)ActualDestinationHost))
			{
				goto IL_0032;
			}
			result = true;
			goto end_IL_0001;
			IL_0032:
			num = 1;
			goto IL_0033;
			IL_0033:
			bool flag = (byte)num != 0;
			if (myUnit.IsUsingDippingSonar() && ConditionTimer > 0f)
			{
				flag = false;
			}
			if (!myUnit.IsOperating())
			{
				result = false;
			}
			else
			{
				bool flag2 = myUnit.FollowingPCThatIsRTB || myUnit.FollowingPCThatIsPathfinderGeneratedAndLeadsToAssignedHost;
				int num2;
				if (myUnit.Navigator.PathFindingInProgress)
				{
					num2 = 1;
				}
				else
				{
					ActiveUnit theUnit = myUnit;
					Exception ThrownError = null;
					num2 = (Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError) ? 1 : 0);
				}
				bool flag3 = (byte)num2 != 0;
				bool flag4 = myUnit.IsRTB || Condition == _AirOpsCondition.RTB;
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
				{
					flag4 = flag4 || ActiveUnit.get_IsRTB(myUnit._StatusBefore_WaitForPathfinder);
				}
				bool flag5 = ClearPlottedCourse && !flag2 && !flag3 && !flag4;
				if (!Information.IsNothing((object)ActualDestinationHost))
				{
					if (DetachFromGroup)
					{
						myUnit.DetachUnit(NotifyPlayer: false, flag5, UseFlightplan: false);
					}
					if (flag5 && myUnit.Navigator.HasPlottedCourse())
					{
						myUnit.Navigator.ClearPlottedCourse();
					}
					if (!myUnit.IsRTB)
					{
						myUnit.Status = _ActiveUnitStatus_0;
					}
					if (flag)
					{
						Condition = _AirOpsCondition.RTB;
					}
					myUnit.Navigator.ResetTimeToNextPathfinderCheck();
					myUnit.Kinematics.DesiredSpeedOverride = null;
					myUnit.Kinematics.DesiredAltitudeOverride = false;
					if (GroupMembersRTB && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						List<ActiveUnit> list = new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
						foreach (ActiveUnit item in list)
						{
							if (item == myUnit)
							{
								continue;
							}
							if (DetachFromGroup)
							{
								myUnit.DetachUnit(NotifyPlayer: false, flag5, UseFlightplan: false);
							}
							if (!item.IsRTB)
							{
								item.Status = ActiveUnit._ActiveUnitStatus.RTB;
							}
							if (!item.IsAircraft)
							{
								Condition = _AirOpsCondition.RTB;
							}
							else
							{
								Aircraft aircraft = (Aircraft)item;
								if (!aircraft.IsUsingDippingSonar() || aircraft.AirOps.ConditionTimer == 0f)
								{
									Condition = _AirOpsCondition.RTB;
								}
							}
							item.Navigator.ResetTimeToNextPathfinderCheck();
							item.Kinematics.DesiredSpeedOverride = null;
							item.Kinematics.DesiredAltitudeOverride = false;
						}
					}
					myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
					result = true;
				}
				else
				{
					PickNewAssignedHost_Nearest();
					if (!Information.IsNothing((object)this.get_AssignedHostUnit(PickNewAssignedHost: false)))
					{
						if (DetachFromGroup)
						{
							myUnit.DetachUnit(NotifyPlayer: false, flag5, UseFlightplan: false);
						}
						if (!myUnit.IsRTB)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB;
						}
						if (flag)
						{
							Condition = _AirOpsCondition.RTB;
						}
						myUnit.Navigator.ResetTimeToNextPathfinderCheck();
						myUnit.Kinematics.DesiredSpeedOverride = null;
						myUnit.Kinematics.DesiredAltitudeOverride = false;
						if (GroupMembersRTB && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
							{
								if (value == myUnit)
								{
									continue;
								}
								if (DetachFromGroup)
								{
									myUnit.DetachUnit(NotifyPlayer: false, flag5, UseFlightplan: false);
								}
								if (!value.IsRTB)
								{
									value.Status = ActiveUnit._ActiveUnitStatus.RTB;
								}
								if (!value.IsAircraft)
								{
									Condition = _AirOpsCondition.RTB;
								}
								else
								{
									Aircraft aircraft2 = (Aircraft)value;
									if (!aircraft2.IsUsingDippingSonar() || aircraft2.AirOps.ConditionTimer == 0f)
									{
										Condition = _AirOpsCondition.RTB;
									}
								}
								value.Navigator.ResetTimeToNextPathfinderCheck();
								value.Kinematics.DesiredSpeedOverride = null;
								value.Kinematics.DesiredAltitudeOverride = false;
							}
						}
						myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
						result = true;
					}
					else
					{
						string text = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						if (ManuallyOrdered)
						{
							myUnit.ParentScen.AddMessage(myUnit.Name + text + " has no suitable place to land!", "Landing issue", LoggedMessage.MessageType.AirOps, 15, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
						result = false;
					}
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100427", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool WaitForEscorts()
	{
		ActiveUnit currentHostUnit = CurrentHostUnit;
		if (!Information.IsNothing((object)currentHostUnit))
		{
			bool result = default(bool);
			try
			{
				if (!Information.IsNothing((object)method_0().ActiveMissionOrPackage()))
				{
					if (method_0().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
					{
						result = false;
						return result;
					}
					if (!method_0().AI.IsEscort)
					{
						if (!Information.IsNothing((object)HostAirFacility))
						{
							int num;
							if (HostAirFacility.AirFacType != AirFacility._AirFacType.RunwayAccessPoint && HostAirFacility.AirFacType != AirFacility._AirFacType.Catapult)
							{
								if (HostAirFacility.AirFacType != AirFacility._AirFacType.SkiJump)
								{
									goto IL_00a6;
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
						goto IL_00a6;
					}
					result = false;
					return result;
				}
				result = false;
				return result;
				IL_00a6:
				List<Aircraft> list = new List<Aircraft>();
				foreach (Aircraft item in currentHostUnit.AirOps.EmbarkedAircraft_ReadOnly)
				{
					if (item != myUnit && item.AI.IsEscort && !Information.IsNothing((object)item.ActiveMissionOrPackage()) && item.ActiveMissionOrPackage() == myUnit.ActiveMissionOrPackage())
					{
						string ReasonForNot = null;
						if (item.IsAvailableForOps(ref ReasonForNot) == 0 && !item.IsParkedAndReady() && !item.IsParkedAndReadying() && item.AirOps.Condition != _AirOpsCondition.Readying)
						{
							list.Add(item);
						}
					}
				}
				if (list.Count != 0)
				{
					ConditionTimer = 30f;
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200445", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		return false;
	}

	public void AttemptToMoveToRunway(bool ActualAirlaunchPreparation, bool CalledFromUI = false)
	{
		Can_Take_Off_Weather_Limitation();
		if (myUnit == null)
		{
			return;
		}
		if (ConditionTimer > 0f)
		{
			if (CalledFromUI && Condition == _AirOpsCondition.Readying)
			{
				QueuedTakeOff = true;
			}
		}
		else
		{
			if (Information.IsNothing((object)HostAirFacility))
			{
				return;
			}
			if (ActualAirlaunchPreparation)
			{
				Condition = _AirOpsCondition.PreparingToLaunch;
			}
			if (Information.IsNothing((object)HostAirFacility.ParentPlatform) && !Information.IsNothing((object)CurrentHostUnit))
			{
				CurrentHostUnit.AddAirFacility(HostAirFacility);
				HostAirFacility.ParentPlatform = CurrentHostUnit;
			}
			try
			{
				switch (HostAirFacility.AirFacType)
				{
				case AirFacility._AirFacType.Catapult:
					method_17(HostAirFacility);
					return;
				case AirFacility._AirFacType.Runway:
				case AirFacility._AirFacType.RunwayWithArrest:
				case AirFacility._AirFacType.SkiJump:
				case AirFacility._AirFacType.Pad:
				case AirFacility._AirFacType.PadWithHaulDown:
					if (CanTakeOffFromThisAirFac(HostAirFacility) == TakeOffCheck.OK)
					{
						method_17(HostAirFacility);
						return;
					}
					break;
				case AirFacility._AirFacType.const_13:
					if (Condition == _AirOpsCondition.HoldingForAvailableRunway)
					{
						AttemptToPark();
					}
					if (Condition == _AirOpsCondition.HoldingForAvailableTransit)
					{
						AttemptToPark();
					}
					if (Condition == _AirOpsCondition.PreparingToLaunch && myUnit.Kinematics.GetMaximumAltitude() > HostAirFacility.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 50f)
					{
						method_17(HostAirFacility);
					}
					else
					{
						ConditionTimer = 60f;
					}
					return;
				case AirFacility._AirFacType.Hangar:
				{
					if (!HostAirFacility.ParentPlatform.IsShip)
					{
						if (method_0().Type == Aircraft._AircraftType.UAV || method_0().Type == Aircraft._AircraftType.UCAV)
						{
							for (int num3 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num3 >= 0; num3 += -1)
							{
								AirFacility airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[num3];
								if ((method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.ManualLaunch || airFacility3.AirFacType == AirFacility._AirFacType.const_13) && CanTakeOffFromThisAirFac(airFacility3) == TakeOffCheck.OK && airFacility3.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success && airFacility3.HostedAircraft.Count < airFacility3.Capacity)
								{
									method_17(airFacility3);
									return;
								}
							}
						}
					}
					else
					{
						Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
						if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
						{
							for (int num4 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num4 >= 0; num4 += -1)
							{
								AirFacility airFacility4 = CurrentHostUnit.AirFacilities_ReadOnly[num4];
								if ((airFacility4.IsRunwayOrPad() || airFacility4.AirFacType == AirFacility._AirFacType.const_13) && CanTakeOffFromThisAirFac(airFacility4) == TakeOffCheck.OK && airFacility4.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success && (airFacility4.AirFacType != AirFacility._AirFacType.const_13 || airFacility4.HostedAircraft.Count < airFacility4.Capacity))
								{
									method_17(airFacility4);
									return;
								}
							}
						}
					}
					if (!Information.IsNothing((object)CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing((object)CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly()))
					{
						List<AirFacility> list3 = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsTransitFacility() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
						List<AirFacility> list4 = list3.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
						if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() <= 0 && CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count <= 0)
						{
							if (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list3.Count - list4.Count <= 2)
							{
								Condition = _AirOpsCondition.HoldingForAvailableTransit;
								ConditionTimer = 35f;
								return;
							}
						}
						else if (list3.Count - list4.Count <= 2)
						{
							Condition = _AirOpsCondition.HoldingForAvailableTransit;
							ConditionTimer = 35f;
							return;
						}
					}
					IEnumerable<AirFacility> enumerable3 = from theAirFac in base.get_RunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
						orderby theAirFac.MaxAircraftSize
						select theAirFac;
					if (!Information.IsNothing((object)enumerable3) && enumerable3.Count() > 0)
					{
						IEnumerable<AirFacility> enumerable4 = RunwayAccessPointCapacityAvailableForThisAircraft_myUnitSize(true, method_0(), CurrentHostUnit, enumerable3);
						if (!Information.IsNothing((object)enumerable4) && enumerable4.Count() > 0)
						{
							method_18(enumerable4.ElementAtOrDefault(0), (Enum6)0);
							return;
						}
					}
					TakeOffCheck takeOffCheck = method_15(CurrentHostUnit);
					if (takeOffCheck == TakeOffCheck.OK)
					{
						Condition = _AirOpsCondition.HoldingForAvailableTransit;
						ConditionTimer = 60f;
						break;
					}
					if (CalledFromUI)
					{
						GameGeneral.SendMessageBoxToUI(takeOffCheck.ToString().Replace("_", " "), ((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false), "Unable to take-off", GameGeneral.MessageBoxMessageType.Warning);
					}
					method_0().ParentScen.AddMessage(method_0().Name + " is unable to take-off due to no suitable facility, reason : " + takeOffCheck.ToString().Replace("_", " "), "Unit unable to launch", LoggedMessage.MessageType.AirOps, 5, method_0().ObjectID, ((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					Condition = _AirOpsCondition.Parked;
					ConditionTimer = 35f;
					return;
				}
				case AirFacility._AirFacType.CarrierArrestingGear:
				case AirFacility._AirFacType.OpenParking:
					if (HostAirFacility.ParentPlatform.IsShip)
					{
						Ship._ShipCategory category2 = ((Ship)HostAirFacility.ParentPlatform).Category;
						if (category2 != Ship._ShipCategory.AviationShip && category2 != Ship._ShipCategory.SurfaceCombatantAviation && category2 != Ship._ShipCategory.MobileOffshoreBase)
						{
							for (int num5 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num5 >= 0; num5 += -1)
							{
								AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[num5];
								if (CanTakeOffFromThisAirFac(airFacility5) == TakeOffCheck.OK && airFacility5.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
								{
									method_17(airFacility5);
									return;
								}
							}
						}
						else
						{
							if (!Information.IsNothing((object)CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing((object)CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly()))
							{
								if (category2 != Ship._ShipCategory.MobileOffshoreBase)
								{
									List<AirFacility> list5 = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsCatapult() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
									List<AirFacility> list6 = list5.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Skip(0).Count() > 0).ToList();
									if (list5.Count > 0)
									{
										int count = list5.Count;
										int num6 = default(int);
										if (count <= 0)
										{
											num6 = 0;
										}
										else if (count == 1)
										{
											num6 = 1;
										}
										else if (count == 2)
										{
											num6 = 1;
										}
										else if (count == 3)
										{
											num6 = 2;
										}
										else if (count >= 4)
										{
											num6 = 2;
										}
										if (list5.Count - list6.Count <= num6)
										{
											if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count > 0)
											{
												Condition = _AirOpsCondition.HoldingForAvailableRunway;
												ConditionTimer = 35f;
												return;
											}
											if (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
											{
												Condition = _AirOpsCondition.HoldingForAvailableRunway;
												ConditionTimer = 35f;
												return;
											}
										}
									}
								}
								else
								{
									List<AirFacility> list7 = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsRunwayOrPad() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
									List<AirFacility> list8 = list7.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Skip(0).Count() > 0).ToList();
									if (list7.Count > 0)
									{
										int count2 = list7.Count;
										int num7 = default(int);
										if (count2 <= 0)
										{
											num7 = 0;
										}
										else if (count2 == 1)
										{
											num7 = 1;
										}
										else if (count2 == 2)
										{
											num7 = 1;
										}
										else if (count2 == 3)
										{
											num7 = 2;
										}
										else if (count2 >= 4)
										{
											num7 = 2;
										}
										if (list7.Count - list8.Count <= num7)
										{
											if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count > 0)
											{
												Condition = _AirOpsCondition.HoldingForAvailableRunway;
												ConditionTimer = 35f;
												return;
											}
											if (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
											{
												Condition = _AirOpsCondition.HoldingForAvailableRunway;
												ConditionTimer = 35f;
												return;
											}
										}
									}
								}
							}
							for (int num8 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num8 >= 0; num8 += -1)
							{
								AirFacility airFacility6 = CurrentHostUnit.AirFacilities_ReadOnly[num8];
								if (CanTakeOffFromThisAirFac(airFacility6) == TakeOffCheck.OK && airFacility6.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
								{
									method_17(airFacility6);
									return;
								}
							}
						}
						Condition = _AirOpsCondition.HoldingForAvailableRunway;
						ConditionTimer = 5f;
						break;
					}
					if (!Information.IsNothing((object)CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing((object)CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly()))
					{
						if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count > 0)
						{
							Condition = _AirOpsCondition.HoldingForAvailableTransit;
							ConditionTimer = 35f;
							return;
						}
						if (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
						{
							List<AirFacility> list9 = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsTransitFacility() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
							List<AirFacility> list10 = list9.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
							if (list9.Count - list10.Count <= 2)
							{
								Condition = _AirOpsCondition.HoldingForAvailableTransit;
								ConditionTimer = 35f;
								return;
							}
						}
					}
					if (CanTakeOffFromThisAirFac(HostAirFacility) != TakeOffCheck.OK)
					{
						IEnumerable<AirFacility> enumerable5 = from theAirFac in base.get_RunwayAccessPointsInOperationOnMe_myUnitSize(method_0().AirOps.CurrentHostUnit)
							orderby theAirFac.MaxAircraftSize
							select theAirFac;
						if (!Information.IsNothing((object)enumerable5) && enumerable5.Count() > 0)
						{
							IEnumerable<AirFacility> enumerable6 = RunwayAccessPointCapacityAvailableForThisAircraft_myUnitSize(true, method_0(), CurrentHostUnit, enumerable5);
							if (!Information.IsNothing((object)enumerable6) && enumerable6.Count() > 0)
							{
								method_18(enumerable6.ElementAtOrDefault(0), (Enum6)0);
								return;
							}
						}
						Condition = _AirOpsCondition.HoldingForAvailableTransit;
						ConditionTimer = 35f;
						break;
					}
					method_17(HostAirFacility);
					return;
				case AirFacility._AirFacType.RunwayAccessPoint:
				case AirFacility._AirFacType.Elevator:
				{
					if (!Information.IsNothing((object)CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing((object)CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly()))
					{
						List<AirFacility> list = CurrentHostUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility theAF) => theAF.IsTransitFacility() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
						List<AirFacility> list2 = list.Where([SpecialName] (AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
						if ((CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly().Count > 0) && list.Count - list2.Count <= 2)
						{
							for (int num = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num >= 0; num += -1)
							{
								AirFacility airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num];
								if (airFacility.AirFacType == AirFacility._AirFacType.OpenParking && airFacility.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
								{
									method_14(airFacility, bool_0: false, bool_1: false);
									Condition = _AirOpsCondition.HoldingForAvailableRunway;
									ConditionTimer = 35f;
									return;
								}
							}
						}
						if (!Information.IsNothing((object)CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list.Count - list2.Count <= 2)
						{
							for (int num2 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num2 >= 0; num2 += -1)
							{
								AirFacility airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num2];
								if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(method_0()) == AirOpsAttemptResult.Success)
								{
									method_14(airFacility2, bool_0: false, bool_1: false);
									Condition = _AirOpsCondition.HoldingForAvailableRunway;
									ConditionTimer = 35f;
									return;
								}
							}
						}
					}
					IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(method_0(), TakeOff: true, IgnoreOtherAircraft: false, CurrentHostUnit, method_0().CanLandVertically)
						orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
						select theAirFac;
					if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0)
					{
						IEnumerable<AirFacility> enumerable2 = RunwayCapacityAvailableForThisAircraft_myUnitSize(TakeOff: true, TouchDown: false, method_0(), CurrentHostUnit, method_0().CanLandVertically, enumerable);
						if (!Information.IsNothing((object)enumerable2) && enumerable2.Count() > 0)
						{
							method_17(enumerable2.ElementAtOrDefault(0));
							return;
						}
					}
					break;
				}
				}
				if ((ConditionTimer == 0f) & (Condition != _AirOpsCondition.HoldingForAvailableRunway))
				{
					Condition = _AirOpsCondition.HoldingForAvailableRunway;
					method_0().ParentScen.AddMessage(method_0().Name + " is unable to take-off due to runway/access restrictions", "Unit unable to launch", LoggedMessage.MessageType.UnitAI, 5, method_0().ObjectID, ((ActiveUnit)method_0()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100428", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	internal bool Can_Take_Off_Weather_Limitation()
	{
		BadWeatherFlag = false;
		WeatherString = "";
		if (!method_0().AirOps.Can_Fly_Current_Rain())
		{
			WeatherString = "Cannot takeoff (rainfall too heavy)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!method_0().AirOps.Can_Fly_Current_TOD())
		{
			WeatherString = "Cannot takeoff (daylight conditions not met)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		return !BadWeatherFlag;
	}

	public static List<AirFacility> RunwaysInOperationOnMe_myUnitSize(Aircraft MyAircraft, bool TakeOff, bool IgnoreOtherAircraft, ActiveUnit theHost, bool VerticalTakeOff)
	{
		List<AirFacility> result;
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			List<AirFacility> list2 = new List<AirFacility>();
			AirFacility[] airFacilities_ReadOnly = theHost.AirFacilities_ReadOnly;
			for (int i = airFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				AirFacility airFacility = airFacilities_ReadOnly[i];
				switch (airFacility.AirFacType)
				{
				case AirFacility._AirFacType.Pad:
				case AirFacility._AirFacType.PadWithHaulDown:
					if (TakeOff && VerticalTakeOff && MyAircraft.AirOps.CanTakeOffFromThisAirFac(airFacility) == TakeOffCheck.OK)
					{
						list.Add(airFacility);
					}
					else if (!TakeOff && VerticalTakeOff && MyAircraft.AirOps.CanLandOnThisAirFac(airFacility, IgnoreOtherAircraft) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility);
					}
					else if (VerticalTakeOff && MyAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && theHost.IsShip && (((Ship)theHost).Category == Ship._ShipCategory.AviationShip || ((Ship)theHost).Category == Ship._ShipCategory.SurfaceCombatantAviation))
					{
						list.Add(airFacility);
					}
					else if ((MyAircraft.Type == Aircraft._AircraftType.UAV || MyAircraft.Type == Aircraft._AircraftType.UCAV) && MyAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && MyAircraft.Size <= airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.RunwayGrade_Taxiway:
					if (TakeOff && MyAircraft.AirOps.CanTakeOffFromThisAirFac(airFacility) == TakeOffCheck.OK)
					{
						list2.Add(airFacility);
					}
					else if (!TakeOff && MyAircraft.AirOps.CanLandOnThisAirFac(airFacility, IgnoreOtherAircraft) == AirOpsAttemptResult.Success)
					{
						list2.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.Runway:
				case AirFacility._AirFacType.RunwayWithArrest:
				case AirFacility._AirFacType.Catapult:
				case AirFacility._AirFacType.SkiJump:
				case AirFacility._AirFacType.CarrierArrestingGear:
				case AirFacility._AirFacType.const_13:
					if (TakeOff && !VerticalTakeOff && MyAircraft.AirOps.CanTakeOffFromThisAirFac(airFacility) == TakeOffCheck.OK)
					{
						list.Add(airFacility);
					}
					else if (!TakeOff && !VerticalTakeOff && MyAircraft.AirOps.CanLandOnThisAirFac(airFacility, IgnoreOtherAircraft) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility);
					}
					else if (TakeOff && VerticalTakeOff && MyAircraft.AirOps.CanTakeOffFromThisAirFac(airFacility) == TakeOffCheck.OK)
					{
						list2.Add(airFacility);
					}
					else if (!TakeOff && VerticalTakeOff && MyAircraft.AirOps.CanLandOnThisAirFac(airFacility, IgnoreOtherAircraft) == AirOpsAttemptResult.Success)
					{
						list2.Add(airFacility);
					}
					else if (VerticalTakeOff && MyAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && theHost.IsShip && (((Ship)theHost).Category == Ship._ShipCategory.AviationShip || ((Ship)theHost).Category == Ship._ShipCategory.SurfaceCombatantAviation))
					{
						list.Add(airFacility);
					}
					else if ((MyAircraft.Type == Aircraft._AircraftType.UAV || MyAircraft.Type == Aircraft._AircraftType.UCAV) && MyAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && MyAircraft.Size <= airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.OpenParking:
					if ((MyAircraft.Type == Aircraft._AircraftType.UAV || MyAircraft.Type == Aircraft._AircraftType.UCAV) && MyAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && MyAircraft.Size <= airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				}
			}
			result = ((list2.Count <= 0 || list.Count != 0) ? list : list2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200355", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<AirFacility>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal TakeOffCheck CanTakeOffFromThisAirFac(AirFacility theAirFac)
	{
		TakeOffCheck result;
		if (method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.ManualLaunch)
		{
			result = TakeOffCheck.OK;
		}
		else
		{
			try
			{
				bool flag = default(bool);
				bool flag2 = default(bool);
				int num;
				switch (theAirFac.AirFacType)
				{
				case AirFacility._AirFacType.Runway:
				case AirFacility._AirFacType.RunwayGrade_Taxiway:
				case AirFacility._AirFacType.Pad:
				case AirFacility._AirFacType.PadWithHaulDown:
					flag = method_0().RunwayLengthNeeded <= theAirFac.RunwayLength;
					flag2 = method_0().Size <= theAirFac.EffectiveRunwaySize;
					if ((method_0().Type == Aircraft._AircraftType.UAV || method_0().Type == Aircraft._AircraftType.UCAV) && method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
					{
						flag = true;
					}
					break;
				case AirFacility._AirFacType.Catapult:
				case AirFacility._AirFacType.SkiJump:
					if (!myUnit.ParentScen.FeatureCompatibility.get_CarrierCapableFlag(myUnit.ParentScen.DBConnection))
					{
						num = 1;
						goto IL_0139;
					}
					if (method_0().Category == Aircraft._AircraftCategory.CarrierCapable || method_0().Category == Aircraft._AircraftCategory.Helicopter || method_0().Category == Aircraft._AircraftCategory.Tiltrotor)
					{
						num = 1;
						goto IL_0139;
					}
					result = TakeOffCheck.not_catapult_lauchable;
					goto end_IL_001a;
				case AirFacility._AirFacType.const_13:
					flag = method_0().RunwayLengthNeeded <= theAirFac.RunwayLength;
					flag2 = method_0().Size <= theAirFac.EffectiveRunwaySize;
					if ((method_0().Type == Aircraft._AircraftType.UAV || method_0().Type == Aircraft._AircraftType.UCAV) && method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
					{
						flag = true;
						flag2 = true;
					}
					break;
				case AirFacility._AirFacType.OpenParking:
					{
						flag = method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched;
						flag2 = method_0().Size <= theAirFac.EffectiveRunwaySize;
						break;
					}
					IL_0139:
					flag = (byte)num != 0;
					flag2 = method_0().Size <= theAirFac.EffectiveRunwaySize;
					break;
				}
				result = ((!(myUnit.Kinematics.GetMaximumAltitude() > theAirFac.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 50f)) ? TakeOffCheck.runway_altitude : ((!flag) ? TakeOffCheck.unsufficient_runway_length : ((!flag2) ? TakeOffCheck.runway_is_to_small : TakeOffCheck.OK)));
				end_IL_001a:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100429", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 1000;
				}
				else
				{
					Debugger.Break();
					num2 = 1000;
				}
				result = (TakeOffCheck)num2;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	internal AirOpsAttemptResult CanLandOnThisAirFac(AirFacility theAirFac, bool IgnoreOtherAircraft)
	{
		AirOpsAttemptResult result;
		try
		{
			switch (theAirFac.AirFacType)
			{
			case AirFacility._AirFacType.RunwayWithArrest:
				if (method_0().Size <= theAirFac.EffectiveRunwaySize)
				{
					break;
				}
				result = AirOpsAttemptResult.Unsufficient_effective_runway_size;
				goto end_IL_0001;
			case AirFacility._AirFacType.Catapult:
			case AirFacility._AirFacType.SkiJump:
			case AirFacility._AirFacType.Hangar:
				result = AirOpsAttemptResult.Failure_other;
				goto end_IL_0001;
			case AirFacility._AirFacType.CarrierArrestingGear:
				if (myUnit.ParentScen.FeatureCompatibility.get_CarrierCapableFlag(myUnit.ParentScen.DBConnection) && method_0().Category != Aircraft._AircraftCategory.CarrierCapable && method_0().Category != Aircraft._AircraftCategory.Helicopter && method_0().Category != Aircraft._AircraftCategory.Tiltrotor)
				{
					result = AirOpsAttemptResult.Failure_other;
				}
				else
				{
					if (method_0().Size <= theAirFac.EffectiveRunwaySize)
					{
						break;
					}
					result = AirOpsAttemptResult.Unsufficient_effective_runway_size;
				}
				goto end_IL_0001;
			default:
				if (method_0().RunwayLengthNeeded > theAirFac.RunwayLength)
				{
					result = AirOpsAttemptResult.Unsufficient_runway_length;
				}
				else
				{
					if (method_0().Size <= theAirFac.EffectiveRunwaySize)
					{
						break;
					}
					result = AirOpsAttemptResult.Unsufficient_effective_runway_size;
				}
				goto end_IL_0001;
			case AirFacility._AirFacType.const_13:
				result = AirOpsAttemptResult.Success;
				goto end_IL_0001;
			case AirFacility._AirFacType.OpenParking:
				if (method_0().RunwayLengthNeeded != GlobalVariables.RunwayLengthClass.CatapultLaunched)
				{
					result = AirOpsAttemptResult.Unsufficient_runway_length;
				}
				else
				{
					if (method_0().Size <= theAirFac.EffectiveRunwaySize)
					{
						break;
					}
					result = AirOpsAttemptResult.Unsufficient_effective_runway_size;
				}
				goto end_IL_0001;
			}
			result = ((!IgnoreOtherAircraft) ? theAirFac.CanHostThisAircraft_BySize(method_0()) : AirOpsAttemptResult.Success);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100430", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 6;
			}
			else
			{
				Debugger.Break();
				num = 6;
			}
			result = (AirOpsAttemptResult)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private TakeOffCheck method_15(ActiveUnit activeUnit_2)
	{
		TakeOffCheck result;
		try
		{
			if (Information.IsNothing((object)activeUnit_2.AirFacilities_ReadOnly))
			{
				result = TakeOffCheck.other_issue;
			}
			else
			{
				TakeOffCheck takeOffCheck = TakeOffCheck.other_issue;
				AirFacility[] airFacilities_ReadOnly = activeUnit_2.AirFacilities_ReadOnly;
				int num = 0;
				while (true)
				{
					if (num < airFacilities_ReadOnly.Length)
					{
						AirFacility theAirFac = airFacilities_ReadOnly[num];
						takeOffCheck = CanTakeOffFromThisAirFac(theAirFac);
						if (takeOffCheck != TakeOffCheck.OK)
						{
							num = checked(num + 1);
							continue;
						}
						result = TakeOffCheck.OK;
						break;
					}
					result = takeOffCheck;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100431", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 1000;
			}
			else
			{
				num2 = 1000;
			}
			result = (TakeOffCheck)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private AirOpsAttemptResult method_16(ActiveUnit activeUnit_2, bool bool_0)
	{
		AirOpsAttemptResult result;
		try
		{
			AirOpsAttemptResult airOpsAttemptResult = AirOpsAttemptResult.Failure_other;
			if (Information.IsNothing((object)activeUnit_2.AirFacilities_ReadOnly))
			{
				result = AirOpsAttemptResult.Failure_other;
			}
			else
			{
				AirFacility[] airFacilities_ReadOnly = activeUnit_2.AirFacilities_ReadOnly;
				int num = 0;
				while (true)
				{
					if (num < airFacilities_ReadOnly.Length)
					{
						AirFacility theAirFac = airFacilities_ReadOnly[num];
						AirOpsAttemptResult airOpsAttemptResult2 = CanLandOnThisAirFac(theAirFac, bool_0);
						if (airOpsAttemptResult2 != AirOpsAttemptResult.Success)
						{
							airOpsAttemptResult = airOpsAttemptResult2;
							num = checked(num + 1);
							continue;
						}
						result = AirOpsAttemptResult.Success;
						break;
					}
					result = airOpsAttemptResult;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100431", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 6;
			}
			else
			{
				Debugger.Break();
				num2 = 6;
			}
			result = (AirOpsAttemptResult)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_17(AirFacility airFacility_1)
	{
		HostAirFacility = airFacility_1;
		Condition = _AirOpsCondition.TakingOff;
		Aircraft theAC = method_0();
		RefuelAC_Simple(ref theAC);
		if (HostAirFacility.AirFacType == AirFacility._AirFacType.Catapult)
		{
			if (method_0().Navigator.HasFlightPlan && !Information.IsNothing((object)((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
			{
				double totalSeconds = (((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu.Value - method_0().ParentScen.Time).TotalSeconds;
				if (totalSeconds > 0.0 && totalSeconds <= 180.0)
				{
					ConditionTimer = (float)totalSeconds;
				}
				else
				{
					ConditionTimer = 80f;
				}
			}
			else
			{
				ConditionTimer = 80f;
			}
			return;
		}
		switch (method_0().VisualSizeClass)
		{
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Small:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Large:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			ConditionTimer = 30f;
			break;
		}
		if (method_0().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
		{
			if (HostAirFacility.AirFacType == AirFacility._AirFacType.const_13)
			{
				ConditionTimer = 120f;
			}
			else if (!HostAirFacility.IsOpenAirFacility)
			{
				ConditionTimer = 90f;
			}
			else
			{
				ConditionTimer = 90f;
			}
		}
	}

	private void method_18(AirFacility airFacility_1, Enum6 enum6_0)
	{
		HostAirFacility = airFacility_1;
		switch (enum6_0)
		{
		case (Enum6)0:
			Condition = _AirOpsCondition.TaxyingToTakeOff;
			break;
		case (Enum6)1:
			Condition = _AirOpsCondition.TaxyingToPark;
			break;
		case (Enum6)2:
			Condition = _AirOpsCondition.TaxyingToFlightDeck;
			break;
		}
		if (method_0().Navigator.HasFlightPlan && !Information.IsNothing((object)((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
		{
			double num = (((ActiveUnit_Navigator)method_0().Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu.Value - method_0().ParentScen.Time).TotalSeconds - 30.0;
			if (num > 0.0 && num <= 180.0)
			{
				ConditionTimer = (float)num;
				return;
			}
		}
		switch (method_0().VisualSizeClass)
		{
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Small:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Large:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			ConditionTimer = 120f;
			break;
		}
	}

	public bool SettleForCargoTransfer()
	{
		bool result;
		try
		{
			if (!method_0().IsHelicopter)
			{
				result = false;
			}
			else
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.DesiredSpeed = 0f;
				myUnit.DesiredAltitude = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
				Condition = _AirOpsCondition.TransferringCargo;
				ConditionTimer = Math.Max(240, ActiveUnit_DockingOps.TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
				int num;
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= myUnit.DesiredAltitude)
				{
					num = 1;
				}
				else
				{
					ConditionTimer = 240f;
					num = 1;
				}
				result = (byte)num != 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10342058231234129034582930467587", "");
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

	public bool HoverForDippingSonar()
	{
		bool result;
		try
		{
			if (!Module_Unit.IsOverLand(method_0()))
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.DesiredSpeed = 0f;
				myUnit.DesiredAltitude = HelicopterDippingSonarAltitude;
				Condition = _AirOpsCondition.DeployingDippingSonar;
				ConditionTimer = 240f;
				int num;
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)HelicopterDippingSonarAltitude)
				{
					ConditionTimer = 240f;
					num = 1;
				}
				else
				{
					num = 1;
				}
				result = (byte)num != 0;
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
			ex2?.Data.Add("Error at 100432", "");
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

	public override void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		try
		{
			if (HostAirFacility == null && !string.IsNullOrEmpty(string_0))
			{
				if (!theDictionary.ContainsKey(string_0))
				{
					bool flag = false;
					foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
					{
						if (activeUnits_ == null)
						{
							continue;
						}
						AirFacility[] airFacilities_ReadOnly = activeUnits_.AirFacilities_ReadOnly;
						foreach (AirFacility airFacility in airFacilities_ReadOnly)
						{
							if (string.CompareOrdinal(airFacility.ObjectID, string_0) == 0)
							{
								HostAirFacility = airFacility;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				else
				{
					HostAirFacility = (AirFacility)theDictionary[string_0];
				}
			}
			if (CurrentHostUnit != null && HostAirFacility != null && !CurrentHostUnit.AirFacilities_ReadOnly.Contains(HostAirFacility))
			{
				CurrentHostUnit.AirOps.AddThisAircraft((Aircraft)myUnit, GameIsRunning);
			}
			if (CurrentHostUnit == null && !string.IsNullOrEmpty(string_1))
			{
				foreach (ActiveUnit activeUnits_2 in theScen.ActiveUnits_List)
				{
					if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, string_1, false) == 0)
					{
						activeUnits_2.AirOps.AddThisAircraft((Aircraft)myUnit, GameIsRunning);
					}
				}
			}
			if (!method_0().IsOperating() && Information.IsNothing((object)HostAirFacility))
			{
				foreach (ActiveUnit value3 in theScen.ActiveUnits.Values)
				{
					if (value3.OldIDs_AirFacilities.Contains(string_0))
					{
						break;
					}
				}
			}
			if (activeUnit_1 == null && !string.IsNullOrEmpty(string_2))
			{
				try
				{
					theScen.ActiveUnits.TryGetValue(string_2, out var value);
					if (value != null)
					{
						this.set_AssignedHostUnit(PickNewAssignedHost: false, value);
						if (!method_0().IsOperating() && (HostAirFacility == null || CurrentHostUnit == null) && method_0().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
						{
							this.get_AssignedHostUnit(PickNewAssignedHost: false).AirOps.AddThisAircraft(method_0(), GameIsRunning);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200022", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!string.IsNullOrEmpty(string_3))
			{
				ActiveUnit value2 = null;
				theScen.ActiveUnits.TryGetValue(string_3, out value2);
				if (value2 != null)
				{
					aircraft_0 = (Aircraft)value2;
				}
			}
			base.PostDeserializationHousekeeping(ref theScen, theDictionary, GameIsRunning);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100433", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<Aircraft> GetPotentialTankers(ref bool IsManual, ref ActiveUnit ManuallySelectedUnit, bool MustBeAbleToReachItDirectly, List<Mission> theSelectedMissions, ref string UserFeedback)
	{
		List<Aircraft> list = new List<Aircraft>();
		int num = 0;
		Aircraft aircraft = method_0();
		bool isTanker = aircraft.IsTanker;
		List<Aircraft> result = default(List<Aircraft>);
		if ((ManuallySelectedUnit != null) | ((A2AR_Destination != null) & ManuallySelectedA2AR_Destination))
		{
			bool flag = false;
			if (ManuallySelectedUnit == null && ((A2AR_Destination != null) & ManuallySelectedA2AR_Destination))
			{
				ManuallySelectedUnit = A2AR_Destination;
			}
			if (ManuallySelectedUnit != null && ManuallySelectedUnit.IsAircraft)
			{
				Aircraft aircraft2 = (Aircraft)ManuallySelectedUnit;
				try
				{
					if (!aircraft2.IsTanker)
					{
						flag = true;
						if (num < 1)
						{
							num = 1;
							UserFeedback = "Selected unit is not a tanker.";
						}
					}
					else
					{
						if (((ActiveUnit)aircraft2).IsRTB)
						{
							flag = true;
							if (num < 1)
							{
								num = 1;
								UserFeedback = "Tanker is RTB.";
							}
						}
						int num2;
						if (method_25(aircraft2, aircraft).HasValue)
						{
							num2 = 0;
						}
						else
						{
							flag = true;
							if (num < 2)
							{
								num = 2;
								UserFeedback = "Aircraft lacks compatible air-to-air refuelling (AAR) gear.";
								num2 = 0;
							}
							else
							{
								num2 = 0;
							}
						}
						bool targetUnitIsAlreadyRefuelClient = (byte)num2 != 0;
						Aircraft_AirOps airOps = aircraft2.AirOps;
						if (airOps.RefuellingQueue.ContainsKey(aircraft.ObjectID))
						{
							targetUnitIsAlreadyRefuelClient = true;
						}
						if (!aircraft2.get_HasEnoughFuelToReplenishThisUnit((ActiveUnit)aircraft, airOps, 0.1f, targetUnitIsAlreadyRefuelClient))
						{
							flag = true;
							if (num < 11)
							{
								num = 11;
								if (theSelectedMissions != null && theSelectedMissions.Count == 1)
								{
									UserFeedback = "Tankers on mission " + theSelectedMissions[0].Name + " do not have enough fuel left aboard to serve more receivers.";
								}
								else
								{
									UserFeedback = "Tankers do not have enough fuel left aboard to serve more receivers.";
								}
							}
						}
						if (((ActiveUnit)aircraft2).get_UnitSide(SetSideOnly: false) != ((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false))
						{
							Doctrine._RefuelAlliedUnits? refuelAlliedUnits = aircraft2.Doctrine.get_RefuelAllies(aircraft2.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							byte? b = (byte?)refuelAlliedUnits;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
							{
								goto IL_0226;
							}
							b = (byte?)refuelAlliedUnits;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
							{
								goto IL_0226;
							}
						}
					}
					goto end_IL_0071;
					IL_0226:
					flag = true;
					if (num < 5)
					{
						num = 5;
						UserFeedback = "Aircraft " + aircraft2.Name + " is an ALLIED tanker and is not allowed to refuel allied units.";
					}
					end_IL_0071:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200293_0", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = new List<Aircraft>();
					ProjectData.ClearProjectError();
					goto IL_1114;
				}
				if (!flag)
				{
					ManuallySelectedA2AR_Destination = true;
					list.Add(aircraft2);
					result = list;
				}
				else
				{
					ManuallySelectedA2AR_Destination = false;
					result = new List<Aircraft>();
				}
			}
		}
		else
		{
			try
			{
				ManuallySelectedA2AR_Destination = false;
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				if (!IsManual)
				{
					byte? b = (byte?)useUnderwayRefuelAndReplenishment;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
					{
						b = (byte?)useUnderwayRefuelAndReplenishment;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true && isTanker)
						{
							UserFeedback = "Aircraft " + myUnit.Name + " is a tanker and the Air-to-Air Refuelling doctrine says that tankers are not allowed to refuel tankers. As such, the aircraft will not refuel. Change the doctrine setting and try again.";
							result = list;
							goto IL_1114;
						}
					}
					else
					{
						bool flag2 = false;
						Waypoint[] plottedCourse = default(Waypoint[]);
						if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							if (myUnit.IsGroupWingman())
							{
								Group obj = myUnit.get_ParentGroup(UsingMissionPlanner: false);
								if (obj != null)
								{
									ActiveUnit groupLead = obj.GroupLead;
									if (groupLead != null && groupLead.Navigator.IsOnAutoPlannerPlottedCourse)
									{
										plottedCourse = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
									}
								}
							}
						}
						else
						{
							plottedCourse = myUnit.Navigator.PlottedCourse;
						}
						if (plottedCourse != null)
						{
							Waypoint[] array = plottedCourse;
							for (int i = 0; i < array.Length; i = checked(i + 1))
							{
								b = (byte?)array[i].GetDoctrine(myUnit.ParentScen).get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if (((!flag3) ?? flag3) == true)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (!flag2)
						{
							UserFeedback = "Aircraft " + myUnit.Name + " has a doctrine setting that disallows air-to-air refuelling. As such, the aircraft will not refuel. Change the doctrine setting and try again.";
							result = list;
							goto IL_1114;
						}
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200293_1", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>();
				ProjectData.ClearProjectError();
				goto IL_1114;
			}
			int num3 = 0;
			int num4 = int.MaxValue;
			try
			{
				if (theSelectedMissions == null && myUnit.ActiveMissionOrPackage() != null)
				{
					int? num5 = (int?)myUnit.Navigator.PreviousWaypointType;
					if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 14)) != true)
					{
						Mission mission = myUnit.ActiveMissionOrPackage();
						if (mission != null && mission.TankerUsage == Mission.TankerMethod.Mission)
						{
							if (myUnit.ActiveMissionOrPackage().TankerMissions.Count <= 0)
							{
								result = list;
								goto IL_1114;
							}
							theSelectedMissions = myUnit.ActiveMissionOrPackage().TankerMissions;
						}
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 200293_2", ex6.Message);
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>();
				ProjectData.ClearProjectError();
				goto IL_1114;
			}
			try
			{
				if (myUnit.ActiveMissionOrPackage() != null && !IsManual)
				{
					num3 = myUnit.ActiveMissionOrPackage().MaxReceiversInQueuePerTanker_Airborne;
					num4 = myUnit.ActiveMissionOrPackage().TankerMaxDistance_Airborne;
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 200293_3", ex8.Message);
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>();
				ProjectData.ClearProjectError();
				goto IL_1114;
			}
			bool flag4 = aircraft.IsOperating();
			UserFeedback = "No tankers are available.";
			Side[] sides_ReadOnly = aircraft.ParentScen.Sides_ReadOnly;
			int num6 = 0;
			while (true)
			{
				if (num6 < sides_ReadOnly.Length)
				{
					Side side = sides_ReadOnly[num6];
					try
					{
						if (!Module_Side.IsAlliedWithThisSide(side, ((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false)))
						{
							goto IL_10fc;
						}
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						ex10?.Data.Add("Error at 200293_99", ex10.Message);
						GameGeneral.WriteExceptionsToLog(ex10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						result = new List<Aircraft>();
						ProjectData.ClearProjectError();
						break;
					}
					ActiveUnit[] array2 = side.Units.InternalArray();
					foreach (ActiveUnit activeUnit in array2)
					{
						if (activeUnit == null || activeUnit == aircraft || !activeUnit.IsAircraft)
						{
							continue;
						}
						Aircraft aircraft3 = (Aircraft)activeUnit;
						if (!aircraft3.IsTanker || !activeUnit.IsOperating())
						{
							continue;
						}
						if (activeUnit.IsRTB)
						{
							if (num < 1)
							{
								num = 1;
								UserFeedback = "Tanker is RTB.";
							}
							continue;
						}
						try
						{
							if (!method_25(aircraft3, aircraft).HasValue)
							{
								if (num < 2)
								{
									num = 2;
									UserFeedback = "Aircraft lacks compatible air-to-air refuelling (AAR) gear.";
								}
								continue;
							}
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 200293_5", ex12.Message);
							GameGeneral.WriteExceptionsToLog(ex12);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = new List<Aircraft>();
							ProjectData.ClearProjectError();
							goto end_IL_073d;
						}
						try
						{
							if (isTanker & !IsManual)
							{
								byte? b = (byte?)activeUnit.Doctrine.get_UseReplenishment(activeUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
								{
									if (num < 4)
									{
										num = 4;
										UserFeedback = "Receiving aircraft " + aircraft.Name + " is a tanker and the Air-to-Air Refuelling doctrine for " + activeUnit.Name + " says that tankers are NOT allowed to refuel tankers. As such, the aircraft will not refuel. Change the doctrine setting and try again.";
									}
									continue;
								}
							}
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception ex14 = ex13;
							ex14?.Data.Add("Error at 200293_98", ex14.Message);
							GameGeneral.WriteExceptionsToLog(ex14);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (activeUnit.get_UnitSide(SetSideOnly: false) != ((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false))
							{
								Doctrine._RefuelAlliedUnits? refuelAlliedUnits2 = activeUnit.Doctrine.get_RefuelAllies(activeUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
								byte? b = (byte?)refuelAlliedUnits2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
								{
									goto IL_0a78;
								}
								b = (byte?)refuelAlliedUnits2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
								{
									goto IL_0a78;
								}
							}
							goto end_IL_09a7;
							IL_0a78:
							if (num < 5)
							{
								num = 5;
								UserFeedback = "Aircraft " + activeUnit.Name + " is an ALLIED tanker and is not allowed to refuel allied units.";
							}
							continue;
							end_IL_09a7:;
						}
						catch (Exception ex15)
						{
							ProjectData.SetProjectError(ex15);
							Exception ex16 = ex15;
							ex16?.Data.Add("Error at 200293_97", ex16.Message);
							GameGeneral.WriteExceptionsToLog(ex16);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (activeUnit.get_CanPhysicallyReplenishThisUnit((ActiveUnit)aircraft))
						{
							if (activeUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
							{
								if (num < 7)
								{
									num = 7;
									UserFeedback = "Aircraft " + activeUnit.Name + " has reached Bingo fuel state and will not offload fuel to clients.";
								}
								continue;
							}
							try
							{
								if (!Information.IsNothing((object)theSelectedMissions))
								{
									if (Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()))
									{
										continue;
									}
									bool flag5 = true;
									for (int k = theSelectedMissions.Count - 1; k >= 0; k += -1)
									{
										Mission mission2 = theSelectedMissions[k];
										if (activeUnit.ActiveMissionOrPackage() == mission2)
										{
											flag5 = false;
											break;
										}
									}
									if (flag5)
									{
										if (num < 8)
										{
											num = 8;
											if (theSelectedMissions.Count == 1)
											{
												UserFeedback = "Mission " + activeUnit.ActiveMissionOrPackage().Name + " has no available tankers.";
											}
											else
											{
												UserFeedback = "There are no available tankers on selected missions.";
											}
										}
										continue;
									}
								}
							}
							catch (Exception ex17)
							{
								ProjectData.SetProjectError(ex17);
								Exception ex18 = ex17;
								ex18?.Data.Add("Error at 200293_96", ex18.Message);
								GameGeneral.WriteExceptionsToLog(ex18);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							bool flag6 = false;
							Aircraft_AirOps airOps2 = ((Aircraft)activeUnit).AirOps;
							try
							{
								if (airOps2.RefuellingQueue.ContainsKey(aircraft.ObjectID))
								{
									flag6 = true;
								}
							}
							catch (Exception ex19)
							{
								ProjectData.SetProjectError(ex19);
								Exception ex20 = ex19;
								ex20?.Data.Add("Error at 200293_95", ex20.Message);
								GameGeneral.WriteExceptionsToLog(ex20);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							if (!IsManual && flag4 && !flag6)
							{
								if (num3 > 0 && airOps2.RefuellingQueue.Count >= num3)
								{
									if (num < 9)
									{
										num = 9;
										if (!Information.IsNothing((object)theSelectedMissions) && theSelectedMissions.Count == 1)
										{
											UserFeedback = "Tankers on mission " + theSelectedMissions[0].Name + " have full queues and cannot serve more receivers.";
										}
										else
										{
											UserFeedback = "Tankers have full queues and cannot serve more receivers.";
										}
									}
									continue;
								}
								try
								{
									if (!Information.IsNothing((object)activeUnit.ActiveMissionOrPackage()) && activeUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
									{
										SupportMission supportMission = (SupportMission)activeUnit.ActiveMissionOrPackage();
										if (supportMission.A2AR_MaxNumberOfReceiversPerTanker > 0)
										{
											_ = airOps2.A2AR_NumberOfReceiverHookups.Count;
											_ = airOps2.RefuellingQueue.Count;
											_ = airOps2.A2AR_Connections.Count;
											if (!aircraft3.AirOps.method_6(supportMission.A2AR_MaxNumberOfReceiversPerTanker, aircraft))
											{
												if (num < 10)
												{
													num = 10;
													if (!Information.IsNothing((object)theSelectedMissions) && theSelectedMissions.Count == 1)
													{
														UserFeedback = "Tankers on mission " + theSelectedMissions[0].Name + " are only allowed to serve " + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + " receivers per tanker. None of the tankers can serve more receivers.";
													}
													else
													{
														UserFeedback = "Tankers are only allowed to serve " + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + " receivers per tanker. None of the available tankers can serve more receivers.";
													}
												}
												continue;
											}
										}
									}
								}
								catch (Exception ex21)
								{
									ProjectData.SetProjectError(ex21);
									Exception ex22 = ex21;
									ex22?.Data.Add("Error at 200293_6", ex22.Message);
									GameGeneral.WriteExceptionsToLog(ex22);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									result = new List<Aircraft>();
									ProjectData.ClearProjectError();
									goto end_IL_073d;
								}
							}
							try
							{
								if (!activeUnit.get_HasEnoughFuelToReplenishThisUnit((ActiveUnit)aircraft, airOps2, 0.1f, flag6))
								{
									if (num < 11)
									{
										num = 11;
										if (!Information.IsNothing((object)theSelectedMissions) && theSelectedMissions.Count == 1)
										{
											UserFeedback = "Tankers on mission " + theSelectedMissions[0].Name + " do not have enough fuel left aboard to serve more receivers.";
										}
										else
										{
											UserFeedback = "Tankers do not have enough fuel left aboard to serve more receivers.";
										}
									}
									continue;
								}
							}
							catch (Exception ex23)
							{
								ProjectData.SetProjectError(ex23);
								Exception ex24 = ex23;
								ex24?.Data.Add("Error at 200293_94", ex24.Message);
								GameGeneral.WriteExceptionsToLog(ex24);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							float? num7 = null;
							try
							{
								if (!IsManual && flag4 && !flag6 && num4 != int.MaxValue)
								{
									num7 = aircraft.RangeToUnit_Horiz(activeUnit);
									float num8 = num4;
									if ((num7.HasValue ? new bool?(num8 < num7.GetValueOrDefault()) : ((bool?)null)) == true)
									{
										if (num < 12)
										{
											num = 12;
											UserFeedback = "Aircraft" + aircraft.Name + " must be within " + Conversions.ToString(num4) + " nm of a tanker to refuel, however the nearest tanker is " + Conversions.ToString((int)Math.Round(num7.Value)) + " nm away";
										}
										continue;
									}
								}
							}
							catch (Exception ex25)
							{
								ProjectData.SetProjectError(ex25);
								Exception ex26 = ex25;
								ex26?.Data.Add("Error at 200293_93", ex26.Message);
								GameGeneral.WriteExceptionsToLog(ex26);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								if (MustBeAbleToReachItDirectly)
								{
									if (!num7.HasValue)
									{
										num7 = aircraft.RangeToUnit_Horiz(activeUnit);
									}
									Aircraft_AI aI = aircraft.AI;
									float? theTargetDistance = num7;
									Aircraft_Navigator navigator = aircraft.Navigator;
									bool theAltitude_TerrainFollowing = false;
									float bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
									float currentHeading = myUnit.CurrentHeading;
									float? safetyMargin = 2f;
									bool BingoFuelEndurance = false;
									if (!aI.CanInterceptTarget(activeUnit, theTargetDistance, bingoFuelAltitude, null, currentHeading, ActiveUnit.Throttle.Cruise, safetyMargin, IgnoreMotionVectors: true, TotalRemainingEndurance: true, ref BingoFuelEndurance))
									{
										if (num < 13)
										{
											num = 13;
											UserFeedback = "Aircraft" + aircraft.Name + " does not have enough fuel to reach a tanker. Alternatively, there are too many receivers in queue on tankers within range, and that there might not be enough fuel for more receivers.";
										}
										continue;
									}
								}
							}
							catch (Exception ex27)
							{
								ProjectData.SetProjectError(ex27);
								Exception ex28 = ex27;
								ex28?.Data.Add("Error at 200293_7", ex28.Message);
								GameGeneral.WriteExceptionsToLog(ex28);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = new List<Aircraft>();
								ProjectData.ClearProjectError();
								goto end_IL_073d;
							}
							list.Add((Aircraft)activeUnit);
						}
						else if (num < 6)
						{
							num = 6;
							UserFeedback = "Aircraft " + activeUnit.Name + " is a tanker but has the wrong refuelling gear (boom Vs. probe).";
						}
					}
					goto IL_10fc;
				}
				result = list;
				break;
				IL_10fc:
				num6 = checked(num6 + 1);
				continue;
				end_IL_073d:
				break;
			}
		}
		goto IL_1114;
		IL_1114:
		return result;
	}

	internal bool AttemptToRendezvousWithTanker(Aircraft theTanker, ref bool MissionPlanner_PostponedRefuelling, bool IsManual, bool IsForced)
	{
		bool result;
		try
		{
			if (!IsManual && !IsForced && (method_0().AirOps.Condition == _AirOpsCondition.Refuelling || method_0().AirOps.Condition == _AirOpsCondition.ManoeuveringToRefuel) && A2AR_Destination != null && myUnit.ParentScen.ActiveUnits.ContainsKey(A2AR_Destination.ObjectID))
			{
				result = true;
			}
			else if (!Information.IsNothing((object)theTanker))
			{
				if (theTanker == method_0())
				{
					result = false;
				}
				else if (theTanker.AirOps.A2AR_Destination != null)
				{
					result = false;
				}
				else
				{
					if (IsManual || IsForced || !myUnit.Navigator.IsOnAutoPlannerPlottedCourse || myUnit.Navigator.PlottedCourse[0].IsStationWaypoint())
					{
						goto IL_02c2;
					}
					Waypoint thePoint = method_0().Navigator.PlottedCourse[0];
					double num = Module_Unit.RangeToUnit_Horiz_Angular(method_0(), theTanker);
					double num2 = Module_Unit.RangeToPoint_Horiz_Angular(method_0(), thePoint);
					double num3 = Module_Unit.RangeToPoint_Horiz_Angular(theTanker, thePoint);
					double num4 = num + num3;
					if (num2 + num3 < num4)
					{
						MissionPlanner_PostponedRefuelling = true;
						result = false;
					}
					else
					{
						float num5 = Math2.CalcDist(theTanker, method_0());
						if (MissionPlanner_PostponedRefuelling)
						{
							goto IL_02c2;
						}
						if (!((theTanker.Navigator.PlottedCourse != null) & (theTanker.Navigator.PlottedCourse.Count() > 0)))
						{
							Mission.Flight flight = ((ActiveUnit_Navigator)theTanker.Navigator).get_Flight(HierarchySearch: true);
							bool? flag = ((flight == null) ? ((bool?)null) : new bool?(flight.FlightPlan.Count() > 0));
							if (((((ActiveUnit_Navigator)theTanker.Navigator).get_Flight(HierarchySearch: true)?.FlightPlan != null) ? flag : new bool?(false)) == true)
							{
								if (method_19(((ActiveUnit_Navigator)theTanker.Navigator).get_Flight(HierarchySearch: true).FlightPlan, ref MissionPlanner_PostponedRefuelling, num5))
								{
									goto IL_02c2;
								}
								result = false;
							}
							else
							{
								if (theTanker.ActiveMissionOrPackage() == null)
								{
									goto IL_02c2;
								}
								Mission mission = theTanker.ActiveMissionOrPackage();
								if (mission.MissionClass != Mission._MissionClass.Support)
								{
									goto IL_02c2;
								}
								SupportMission supportMission = (SupportMission)mission;
								if (!((supportMission.NavigationCourse != null) & (supportMission.NavigationCourse.Count > 0)) || method_20(supportMission.NavigationCourse, ref MissionPlanner_PostponedRefuelling, num5))
								{
									goto IL_02c2;
								}
								result = false;
							}
						}
						else
						{
							if (method_19(theTanker.Navigator.PlottedCourse, ref MissionPlanner_PostponedRefuelling, num5))
							{
								goto IL_02c2;
							}
							result = false;
						}
					}
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
			ex2?.Data.Add("Error at 100435", "");
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
		goto IL_0486;
		IL_02c2:
		try
		{
			Aircraft_AI aI = method_0().AI;
			Aircraft_Navigator navigator = method_0().Navigator;
			bool theAltitude_TerrainFollowing = false;
			float bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
			float currentHeading = myUnit.CurrentHeading;
			float? safetyMargin = 0.25f;
			bool BingoFuelEndurance = false;
			int num7;
			if (aI.CanInterceptTarget(theTanker, null, bingoFuelAltitude, null, currentHeading, ActiveUnit.Throttle.Cruise, safetyMargin, IgnoreMotionVectors: true, TotalRemainingEndurance: true, ref BingoFuelEndurance))
			{
				if (!GlobalVariables.AI_REWORK)
				{
					method_0().Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				}
				Condition = _AirOpsCondition.ManoeuveringToRefuel;
				A2AR_Destination = theTanker;
				if (IsManual)
				{
					ManuallySelectedA2AR_Destination = true;
				}
				if (method_0().IsGroupMember())
				{
					if (((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup)
					{
						num7 = 1;
						goto IL_0438;
					}
					ActiveUnit groupLead = ((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					_ = ((Aircraft)((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps;
					if (!Information.IsNothing((object)theTanker))
					{
						foreach (ActiveUnit value in ((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value != groupLead && value.Status != ActiveUnit._ActiveUnitStatus.Refuelling && value.IsOperating() && value != theTanker)
							{
								Aircraft_AirOps airOps = ((Aircraft)value).AirOps;
								if (!GlobalVariables.AI_REWORK)
								{
									value.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
								}
								airOps.Condition = _AirOpsCondition.ManoeuveringToRefuel;
								airOps.A2AR_Destination = theTanker;
							}
						}
					}
				}
				num7 = 1;
				goto IL_0438;
			}
			result = false;
			goto end_IL_02c2;
			IL_0438:
			result = (byte)num7 != 0;
			end_IL_02c2:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100435_1", "");
			GameGeneral.WriteExceptionsToLog(ex4);
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
		goto IL_0486;
		IL_0486:
		return result;
	}

	private bool method_19(Waypoint[] waypoint_0, ref bool bool_0, double double_0)
	{
		int num = 0;
		while (true)
		{
			if (num < waypoint_0.Length)
			{
				if (!((double)Math2.CalcDist(waypoint_0[num], method_0().Navigator.PlottedCourse[0]) >= double_0))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return true;
		}
		bool_0 = true;
		return false;
	}

	private bool method_20(List<ReferencePoint> list_0, ref bool bool_0, double double_0)
	{
		foreach (ReferencePoint item in list_0)
		{
			if (!((double)Math2.CalcDist(item, method_0().Navigator.PlottedCourse[0]) >= double_0))
			{
				bool_0 = true;
				return false;
			}
		}
		return true;
	}

	private List<string> method_21(List<string> list_0)
	{
		List<string> list = list_0.ToList();
		list.Remove(method_0().ObjectID);
		return list;
	}

	internal bool method_22(ref ActiveUnit theSelectedTanker)
	{
		if (!Information.IsNothing((object)theSelectedTanker))
		{
			if (theSelectedTanker == method_0())
			{
				return false;
			}
			if (!Information.IsNothing((object)method_25((Aircraft)theSelectedTanker, method_0())))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal bool AttemptToScheduleRefuel(GeoPoint IntermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection theRefuelLogic, ref bool IsManual, bool IsForced, ref ActiveUnit theSelectedTanker, ref List<Mission> theSelectedMissions, ref string UserFeedback, ref bool IsRTB, ref bool MissionPlanner_PostponedRefuelling, RefuelScheduleReason Reason = RefuelScheduleReason.None)
	{
		bool result;
		try
		{
			bool flag = false;
			string text = "";
			if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_Manual || IsManual || IsForced || Reason == RefuelScheduleReason.WingmanRequestingLeadRefuel || Reason == RefuelScheduleReason.FlightPlanMandatedRefuel || Reason == RefuelScheduleReason.FuelStateReachedWhileExhausted)
			{
				goto IL_0106;
			}
			Aircraft aircraft = method_0();
			double TotalMax = 0.0;
			double TotalCurrent = default(double);
			aircraft.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false);
			ActiveUnit actualDestinationHost = method_0().AirOps.ActualDestinationHost;
			if (actualDestinationHost == null)
			{
				goto IL_0106;
			}
			text = " " + actualDestinationHost.Name;
			float num = method_0().RangeToUnit_Horiz(actualDestinationHost);
			if (!((double)(float)((double)method_0().get_FuelEndurance(method_0().ThrottleSetting, (AltBand)null, (float?)method_0().CurrentSpeed, (float?)method_0().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 3600.0 * (double)method_0().CurrentSpeed) > (double)num * 1.15))
			{
				flag = true;
				goto IL_0106;
			}
			result = false;
			goto end_IL_0001;
			IL_0106:
			bool flag2 = AttemptToScheduleRefuel_Internal(IntermediateTargetPoint, theRefuelLogic, ref IsManual, IsForced, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling);
			if (flag)
			{
				string text2 = "";
				if (Operators.CompareString(method_0().Name, method_0().UnitClass, false) != 0)
				{
					text2 = " (" + method_0().UnitClass + ")";
				}
				method_0().AddMessage(method_0().Name + text2 + " does not have enough fuel to reach assigned base" + text + ", will interrupt manual RTB order to refuel!", method_0().Name + " will interrupt manual RTB order to refuel!", LoggedMessage.MessageType.UnitAIEmergency, 0, new Geopoint_Struct(method_0().get_Longitude((GlobalVariables.BooleanObject)null), method_0().get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			result = flag2;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100434", "");
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

	protected IEnumerable<(Aircraft, TankerQueueInformation)> OrderTankersByTimeToStartRefueling(IEnumerable<Aircraft> CandidateTankers)
	{
		List<(Aircraft, TankerQueueInformation)> list = new List<(Aircraft, TankerQueueInformation)>();
		foreach (Aircraft CandidateTanker in CandidateTankers)
		{
			list.Add((CandidateTanker, method_23(CandidateTanker)));
		}
		return list.OrderBy([SpecialName] ((Aircraft, TankerQueueInformation) tankerAndTime) => tankerAndTime.Item2.timeToStartRefueling);
	}

	public bool AttemptToScheduleRefuel_Internal(GeoPoint IntermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection theRefuelLogic, ref bool IsManual, bool IsForced, ref ActiveUnit theSelectedTanker, ref List<Mission> theSelectedMissions, ref string UserFeedback, ref bool IsRTB, ref bool MissionPlanner_PostponedRefuelling)
	{
		_Closure$__163-1 closure$__163- = new _Closure$__163-1(closure$__163-);
		closure$__163-.$VB$Me = this;
		closure$__163-.$VB$Local_IntermediateTargetPoint = IntermediateTargetPoint;
		bool result;
		try
		{
			if (!method_0().BoomRefuelling && !method_0().ProbeRefuelling)
			{
				UserFeedback = "Aircraft lacks air-to-air refuelling (AAR) capability.";
				result = false;
				goto IL_0bb9;
			}
			if (!Information.IsNothing((object)theSelectedTanker))
			{
				if (theSelectedTanker == method_0())
				{
					UserFeedback = "Aircraft cannot refuel from itself.";
					result = false;
					goto IL_0bb9;
				}
				if (Information.IsNothing((object)method_25((Aircraft)theSelectedTanker, method_0())))
				{
					UserFeedback = "Aircraft lacks compatible air-to-air refuelling (AAR) gear.";
					result = false;
					goto IL_0bb9;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100436_0", "");
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
			goto IL_0bb9;
		}
		try
		{
			try
			{
				if (!IsManual || Information.IsNothing((object)theSelectedTanker))
				{
					goto end_IL_00db;
				}
				if (!theSelectedTanker.IsGroup)
				{
					goto IL_0121;
				}
				if (!Information.IsNothing((object)((Group)theSelectedTanker).GroupLead))
				{
					theSelectedTanker = ((Group)theSelectedTanker).GroupLead;
					goto IL_0121;
				}
				result = false;
				goto end_IL_00db_2;
				IL_0121:
				if (GetPotentialTankers(ref IsManual, ref theSelectedTanker, MustBeAbleToReachItDirectly: true, theSelectedMissions, ref UserFeedback).Count != 0)
				{
					if (!AttemptToRendezvousWithTanker((Aircraft)theSelectedTanker, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
					{
						UserFeedback = "Could not rendezvous with selected tanker.";
						result = false;
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = false;
				}
				goto end_IL_00db_2;
				end_IL_00db:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100436_1", "");
				GameGeneral.WriteExceptionsToLog(ex4);
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
				goto end_IL_00db_2;
			}
			try
			{
				if (Condition != _AirOpsCondition.HoldingOnLandingQueue && Condition != _AirOpsCondition.Landing_PreTouchdown && Condition != _AirOpsCondition.Landing_PostTouchdown)
				{
					if (!myUnit.Navigator.HasPlottedCourse() || !((myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse.First().Type == Waypoint.WaypointType.Land) | (myUnit.Navigator.PlottedCourse.First().Type == Waypoint.WaypointType.LandingMarshal && !IsForced)))
					{
						goto end_IL_01b4;
					}
					float num3 = 0f;
					Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
					foreach (Waypoint waypoint in plottedCourse)
					{
						num3 += waypoint.Leg_FuelRequired;
					}
					if (!((float)myUnit.FuelCapacityCurrent > num3))
					{
						goto end_IL_01b4;
					}
					UserFeedback = "AC can Land with the remaining fuel.";
					result = false;
				}
				else
				{
					UserFeedback = "AC is about to land.";
					result = false;
				}
				goto end_IL_00db_2;
				end_IL_01b4:;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 100436_2", "");
				GameGeneral.WriteExceptionsToLog(ex6);
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
				goto end_IL_00db_2;
			}
			try
			{
				if (!method_0().IsGroupWingman() || ((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup)
				{
					goto end_IL_0308;
				}
				if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					goto IL_037b;
				}
				int num5;
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						goto IL_037b;
					}
					num5 = 1;
				}
				else
				{
					num5 = 1;
				}
				result = (byte)num5 != 0;
				goto end_IL_00db_2;
				IL_037b:
				Aircraft aircraft = (Aircraft)((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				if (aircraft.AirOps.AttemptToScheduleRefuel(closure$__163-.$VB$Local_IntermediateTargetPoint, theRefuelLogic, ref IsManual, IsForced, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, RefuelScheduleReason.WingmanRequestingLeadRefuel))
				{
					Aircraft a2AR_Destination = aircraft.AirOps.A2AR_Destination;
					if (!Information.IsNothing((object)a2AR_Destination))
					{
						foreach (ActiveUnit value in ((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value == aircraft || !value.IsOperating())
							{
								continue;
							}
							Aircraft_AirOps airOps = ((Aircraft)value).AirOps;
							if (value != a2AR_Destination)
							{
								if (!GlobalVariables.AI_REWORK)
								{
									value.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
								}
								airOps.Condition = _AirOpsCondition.ManoeuveringToRefuel;
								airOps.A2AR_Destination = a2AR_Destination;
							}
						}
					}
					result = true;
				}
				else
				{
					result = false;
				}
				goto end_IL_00db_2;
				end_IL_0308:;
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 100436_3", "");
				GameGeneral.WriteExceptionsToLog(ex8);
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
				goto end_IL_00db_2;
			}
			ActiveUnit ManuallySelectedUnit = null;
			List<Aircraft> potentialTankers = GetPotentialTankers(ref IsManual, ref ManuallySelectedUnit, MustBeAbleToReachItDirectly: true, theSelectedMissions, ref UserFeedback);
			if (potentialTankers.Count == 0)
			{
				result = false;
			}
			else
			{
				if (!method_0().IsOnReturnLeg && (theRefuelLogic == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly || theRefuelLogic == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround) && Information.IsNothing((object)closure$__163-.$VB$Local_IntermediateTargetPoint))
				{
					theRefuelLogic = Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest;
				}
				switch (theRefuelLogic)
				{
				case Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest:
					try
					{
						IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(potentialTankers);
						foreach (var item in enumerable)
						{
							if (!AttemptToRendezvousWithTanker(item.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
							{
								continue;
							}
							result = true;
							goto end_IL_00db_2;
						}
					}
					catch (Exception ex15)
					{
						ProjectData.SetProjectError(ex15);
						Exception ex16 = ex15;
						ex16?.Data.Add("Error at 100436_4", "");
						GameGeneral.WriteExceptionsToLog(ex16);
						int num16;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num16 = 0;
						}
						else
						{
							num16 = 0;
						}
						result = (byte)num16 != 0;
						ProjectData.ClearProjectError();
						goto end_IL_00db_2;
					}
					break;
				case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly:
				case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround:
				{
					if (IsRTB || closure$__163-.$VB$Local_IntermediateTargetPoint == null)
					{
						_Closure$__163-3 closure$__163-2 = new _Closure$__163-3(closure$__163-2);
						closure$__163-2.$VB$NonLocal_$VB$Closure_3 = closure$__163-;
						closure$__163-2.$VB$Local_myHost = ActualDestinationHost;
						if (Information.IsNothing((object)closure$__163-2.$VB$Local_myHost))
						{
							try
							{
								IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(potentialTankers);
								foreach (var item2 in enumerable)
								{
									if (!AttemptToRendezvousWithTanker(item2.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
									{
										continue;
									}
									result = true;
									goto end_IL_00db_2;
								}
							}
							catch (Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								Exception ex10 = ex9;
								ex10?.Data.Add("Error at 100436_6", "");
								GameGeneral.WriteExceptionsToLog(ex10);
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
								goto end_IL_00db_2;
							}
							break;
						}
						_Closure$__163-2 arg = default(_Closure$__163-2);
						_Closure$__163-2 CS$<>8__locals18 = new _Closure$__163-2(arg);
						CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4 = closure$__163-2;
						CS$<>8__locals18.$VB$Local_RangeToBase_Angular = Module_Unit.RangeToUnit_Horiz_Angular(method_0(), CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4.$VB$Local_myHost);
						IEnumerable<Aircraft> enumerable2 = from theT in potentialTankers
							where !(Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Me.method_0(), theT) >= CS$<>8__locals18.$VB$Local_RangeToBase_Angular) && Module_Unit.RangeToUnit_Horiz_Angular(theT, CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4.$VB$Local_myHost) < CS$<>8__locals18.$VB$Local_RangeToBase_Angular
							orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, method_0())
							select theT;
						try
						{
							if (enumerable2.Count() > 0)
							{
								IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(enumerable2);
								foreach (var item3 in enumerable)
								{
									if (!AttemptToRendezvousWithTanker(item3.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
									{
										continue;
									}
									result = true;
									goto end_IL_00db_2;
								}
								goto end_IL_0949;
							}
							if (theRefuelLogic != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
							{
								goto end_IL_0949;
							}
							if (method_0().get_IsBingoTowardsThisDestination(CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4.$VB$Local_myHost, (GeoPoint)null, method_0().Doctrine.BingoJoker) == ActiveUnit._ActiveUnitFuelState.IsBingo)
							{
								IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(potentialTankers);
								foreach (var item4 in enumerable)
								{
									double num8 = Module_Unit.RangeToUnit_Horiz_Angular(method_0(), item4.Item1);
									double num9 = Module_Unit.RangeToUnit_Horiz_Angular(item4.Item1, CS$<>8__locals18.$VB$NonLocal_$VB$Closure_4.$VB$Local_myHost);
									if (!(num8 < CS$<>8__locals18.$VB$Local_RangeToBase_Angular) || !(num9 < num8 + CS$<>8__locals18.$VB$Local_RangeToBase_Angular) || !AttemptToRendezvousWithTanker(item4.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
									{
										continue;
									}
									result = true;
									goto end_IL_00db_2;
								}
								result = false;
							}
							else
							{
								result = false;
							}
							goto end_IL_00db_2;
							end_IL_0949:;
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 100436_7", "");
							GameGeneral.WriteExceptionsToLog(ex12);
							int num10;
							if (Debugger.IsAttached)
							{
								Debugger.Break();
								num10 = 0;
							}
							else
							{
								num10 = 0;
							}
							result = (byte)num10 != 0;
							ProjectData.ClearProjectError();
							goto end_IL_00db_2;
						}
						break;
					}
					_Closure$__163-0 arg2 = default(_Closure$__163-0);
					_Closure$__163-0 CS$<>8__locals22 = new _Closure$__163-0(arg2);
					CS$<>8__locals22.$VB$NonLocal_$VB$Closure_2 = closure$__163-;
					CS$<>8__locals22.$VB$Local_RangeToTarget_Angular = Module_Unit.RangeToPoint_Horiz_Angular(method_0(), CS$<>8__locals22.$VB$NonLocal_$VB$Closure_2.$VB$Local_IntermediateTargetPoint);
					IEnumerable<Aircraft> enumerable3 = potentialTankers.Where([SpecialName] (Aircraft theT) => !(Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals22.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_0(), theT) >= CS$<>8__locals22.$VB$Local_RangeToTarget_Angular) && Module_Unit.RangeToPoint_Horiz_Angular(theT, CS$<>8__locals22.$VB$NonLocal_$VB$Closure_2.$VB$Local_IntermediateTargetPoint) < CS$<>8__locals22.$VB$Local_RangeToTarget_Angular);
					try
					{
						if (enumerable3.Count() > 0)
						{
							IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(enumerable3);
							int num11 = 0;
							foreach (var item5 in enumerable)
							{
								if (!AttemptToRendezvousWithTanker(item5.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
								{
									num11++;
									continue;
								}
								result = true;
								goto end_IL_00db_2;
							}
						}
						else if (theRefuelLogic == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
						{
							IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(potentialTankers);
							foreach (var item6 in enumerable)
							{
								double num12 = Module_Unit.RangeToUnit_Horiz_Angular(method_0(), item6.Item1);
								double num13 = Module_Unit.RangeToPoint_Horiz_Angular(item6.Item1, CS$<>8__locals22.$VB$NonLocal_$VB$Closure_2.$VB$Local_IntermediateTargetPoint);
								if (!(num12 < CS$<>8__locals22.$VB$Local_RangeToTarget_Angular) || !(num13 < CS$<>8__locals22.$VB$Local_RangeToTarget_Angular) || !AttemptToRendezvousWithTanker(item6.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
								{
									continue;
								}
								result = true;
								goto end_IL_00db_2;
							}
						}
					}
					catch (Exception ex13)
					{
						ProjectData.SetProjectError(ex13);
						Exception ex14 = ex13;
						ex14?.Data.Add("Error at 100436_5", "");
						GameGeneral.WriteExceptionsToLog(ex14);
						int num14;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num14 = 0;
						}
						else
						{
							num14 = 0;
						}
						result = (byte)num14 != 0;
						ProjectData.ClearProjectError();
						goto end_IL_00db_2;
					}
					if (IsForced || myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation))
					{
						break;
					}
					int num15;
					if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
					{
						num15 = 0;
					}
					else
					{
						if (!myUnit.IsGroupWingman() || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							break;
						}
						num15 = 0;
					}
					result = (byte)num15 != 0;
					goto end_IL_00db_2;
				}
				}
				try
				{
					if (theRefuelLogic != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly)
					{
						IEnumerable<(Aircraft, TankerQueueInformation)> enumerable = OrderTankersByTimeToStartRefueling(potentialTankers);
						foreach (var item7 in enumerable)
						{
							if (!AttemptToRendezvousWithTanker(item7.Item1, ref MissionPlanner_PostponedRefuelling, IsManual, IsForced))
							{
								continue;
							}
							result = true;
							goto end_IL_00db_2;
						}
					}
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ex18?.Data.Add("Error at 100436_8", "");
					GameGeneral.WriteExceptionsToLog(ex18);
					int num17;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num17 = 0;
					}
					else
					{
						num17 = 0;
					}
					result = (byte)num17 != 0;
					ProjectData.ClearProjectError();
					goto end_IL_00db_2;
				}
				UserFeedback = "Could not find suitable tanker.";
				result = false;
			}
			end_IL_00db_2:;
		}
		catch (Exception ex19)
		{
			ProjectData.SetProjectError(ex19);
			Exception ex20 = ex19;
			ex20?.Data.Add("Error at 100436", "");
			GameGeneral.WriteExceptionsToLog(ex20);
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
		goto IL_0bb9;
		IL_0bb9:
		return result;
	}

	private TankerQueueInformation method_23(Aircraft aircraft_2)
	{
		PooledList<(Aircraft, float)> pooledList = default(PooledList<(Aircraft, float)>);
		try
		{
			TankerQueueInformation result = new TankerQueueInformation
			{
				timeToStartRefueling = method_0().ETA_To_Location(method_0().CurrentSpeed, Module_Unit.RangeToPoint_Horiz(method_0(), aircraft_2.get_Latitude((GlobalVariables.BooleanObject)null), aircraft_2.get_Longitude((GlobalVariables.BooleanObject)null)))
			};
			GEnum0? nullable_ = method_25(aircraft_2, method_0());
			float num = method_4(method_0(), nullable_);
			float num2 = (float)method_0().FuelCapacityMax / num;
			Aircraft_AirOps airOps = aircraft_2.AirOps;
			if (airOps.RefuellingQueue.Count > 0)
			{
				pooledList = new PooledList<(Aircraft, float)>(airOps.RefuellingQueue.Count);
				List<string> list;
				try
				{
					list = new List<string>(airOps.RefuellingQueue.Keys);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					list = new List<string>(airOps.RefuellingQueue.Keys);
					ProjectData.ClearProjectError();
				}
				foreach (string item2 in list)
				{
					if (!string.IsNullOrEmpty(item2) && method_0().ParentScen.ActiveUnits.TryGetValue(item2, out var value))
					{
						pooledList.Add(((Aircraft)value, 0f));
					}
					else
					{
						pooledList.Add((null, 0f));
					}
				}
				if (pooledList.Count > 0)
				{
					int num3 = pooledList.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						try
						{
							if (i >= pooledList.Count)
							{
								break;
							}
							Aircraft item = pooledList[i].Item1;
							if (item != null && item.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && !item.IsMorituri)
							{
								pooledList[i] = (item, item.ETA_To_Location(item.CurrentSpeed, Module_Unit.RangeToPoint_Horiz(item, aircraft_2.get_Latitude((GlobalVariables.BooleanObject)null), aircraft_2.get_Longitude((GlobalVariables.BooleanObject)null))));
								continue;
							}
							pooledList.RemoveAt(i);
							i--;
							if (item != null)
							{
								airOps.RefuellingQueue.Remove(item.ObjectID);
							}
							continue;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 54155480", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							continue;
						}
					}
				}
				if (pooledList.Count != 0)
				{
					IOrderedEnumerable<(Aircraft, float)> orderedEnumerable = pooledList.OrderBy([SpecialName] ((Aircraft, float) clientAndTime) => clientAndTime.Item2);
					float num4 = 0f;
					foreach (var (aircraft, num5) in orderedEnumerable)
					{
						if (Math.Max(num4, result.timeToStartRefueling) + num2 >= num5)
						{
							if (num5 > num4)
							{
								num4 = num5;
							}
							nullable_ = method_25(aircraft_2, aircraft);
							num = method_4(aircraft, nullable_);
							float num6 = (float)aircraft.FuelCapacityMax / num;
							num4 += num6;
							result.aircraftsInQueueBefore++;
							continue;
						}
						result.timeToStartRefueling = Math.Max(num4, result.timeToStartRefueling);
						result.aircraftsInQueueAfter = orderedEnumerable.Count() - result.aircraftsInQueueBefore;
						return result;
					}
					try
					{
						result.timeToStartRefueling = (int)Math.Round(Math.Max(num4, result.timeToStartRefueling));
					}
					catch (OverflowException projectError2)
					{
						ProjectData.SetProjectError((Exception)projectError2);
						result.timeToStartRefueling = float.MaxValue;
						ProjectData.ClearProjectError();
					}
					return result;
				}
				return result;
			}
			return result;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 54155521", "");
			GameGeneral.WriteExceptionsToLog(ex4);
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
		return default(TankerQueueInformation);
	}

	public bool AttemptToConnectToTanker(bool WingmenHookingUpWithGroupleadTanker)
	{
		bool result;
		try
		{
			if (!Information.IsNothing((object)A2AR_Destination))
			{
				if (!Information.IsNothing((object)A2AR_Destination.AirOps.A2AR_Destination))
				{
					result = false;
				}
				else if (!WingmenHookingUpWithGroupleadTanker && method_0().RangeToUnit_Horiz(A2AR_Destination) > TankerHookUpDistance)
				{
					result = false;
				}
				else if (!A2AR_Destination.AirOps.get_HasAvailableRefuelSlotForThisAircraft(method_0(), WingmenHookingUpWithGroupleadTanker))
				{
					if (method_0().IsGroupMember())
					{
						foreach (Aircraft value in ((ActiveUnit)method_0()).get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value.AirOps.Condition != _AirOpsCondition.Refuelling || value.AirOps.A2AR_Destination != A2AR_Destination)
							{
								continue;
							}
							method_24(WingmenHookingUpWithGroupleadTanker);
							result = true;
							goto end_IL_0001;
						}
						result = false;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					method_24(WingmenHookingUpWithGroupleadTanker);
					result = true;
				}
			}
			else
			{
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100437", "");
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

	private void method_24(bool bool_0)
	{
		try
		{
			Aircraft_AirOps airOps = A2AR_Destination.AirOps;
			if (Information.IsNothing((object)method_0()))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else if (string.IsNullOrEmpty(method_0().ObjectID) && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (!method_0().BoomRefuelling)
			{
				if (!method_0().ProbeRefuelling)
				{
					return;
				}
				if (airOps.A2AR_Connections.ContainsKey(method_0().ObjectID))
				{
					if (A2AR_Destination.HasBuddyStore)
					{
						airOps.A2AR_Connections[method_0().ObjectID] = GEnum0.BuddyDrogue;
					}
					else
					{
						airOps.A2AR_Connections[method_0().ObjectID] = GEnum0.Drogue;
					}
				}
				else if (!A2AR_Destination.HasBuddyStore)
				{
					airOps.A2AR_Connections.AddIfNotExists(method_0().ObjectID, GEnum0.Drogue);
				}
				else
				{
					airOps.A2AR_Connections.AddIfNotExists(method_0().ObjectID, GEnum0.BuddyDrogue);
				}
				if (!GlobalVariables.AI_REWORK)
				{
					method_0().Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				}
				method_0().AirOps.Condition = _AirOpsCondition.Refuelling;
				airOps.Condition = _AirOpsCondition.OffloadingFuel;
				airOps.RefuellingQueue.Remove(method_0().ObjectID);
			}
			else
			{
				if (airOps.A2AR_Connections.ContainsKey(method_0().ObjectID))
				{
					airOps.A2AR_Connections[method_0().ObjectID] = GEnum0.Boom;
				}
				else
				{
					airOps.A2AR_Connections.AddIfNotExists(method_0().ObjectID, GEnum0.Boom);
				}
				if (!GlobalVariables.AI_REWORK)
				{
					method_0().Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				}
				method_0().AirOps.Condition = _AirOpsCondition.Refuelling;
				airOps.Condition = _AirOpsCondition.OffloadingFuel;
				airOps.RefuellingQueue.Remove(method_0().ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100438", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private GEnum0? method_25(Aircraft aircraft_2, Aircraft aircraft_3)
	{
		return (aircraft_3.BoomRefuelling && aircraft_2.CenterlineBoom) ? new GEnum0?(GEnum0.Boom) : ((aircraft_3.ProbeRefuelling && (aircraft_2.CenterlineDrogue || aircraft_2.WingDrogue)) ? new GEnum0?(GEnum0.Drogue) : ((!aircraft_2.HasBuddyStore || !aircraft_3.ProbeRefuelling) ? ((GEnum0?)null) : new GEnum0?(GEnum0.BuddyDrogue)));
	}

	[SpecialName]
	private bool method_26(Aircraft theAC, bool WingmenHookingUpWithGroupleadTanker)
	{
		bool result = default(bool);
		try
		{
			if (!theAC.BoomRefuelling)
			{
				result = false;
				return result;
			}
			if (WingmenHookingUpWithGroupleadTanker && theAC.IsGroupWingman())
			{
				result = true;
				return result;
			}
			if (!method_0().CenterlineBoom)
			{
				result = false;
				return result;
			}
			foreach (KeyValuePair<string, GEnum0> a2AR_Connection in A2AR_Connections)
			{
				if (a2AR_Connection.Value == GEnum0.Boom)
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100439", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private float method_27(Aircraft aircraft_2)
	{
		if (aircraft_2 == null)
		{
			return 1f;
		}
		if (!aircraft_2.ProbeRefuelling)
		{
			return 1f;
		}
		float num = 0f;
		if (method_0().HasBuddyStore)
		{
			num += 1f;
		}
		if (method_0().CenterlineDrogue)
		{
			num += 1f;
		}
		if (method_0().WingDrogue)
		{
			num += 2f;
		}
		if (num > 0f)
		{
			float num2 = 0f;
			foreach (KeyValuePair<string, GEnum0> a2AR_Connection in A2AR_Connections)
			{
				if (a2AR_Connection.Value != GEnum0.Drogue)
				{
					if (a2AR_Connection.Value == GEnum0.BuddyDrogue)
					{
						num2 += 1f;
					}
					else if (a2AR_Connection.Value == GEnum0.Boom)
					{
						num2 += 1f;
					}
				}
				else
				{
					num2 += 1f;
				}
			}
			if (num2 > 0f)
			{
				return num2 / num;
			}
			return 0f;
		}
		return 1f;
	}

	[SpecialName]
	private bool method_28(Aircraft theAC, bool WingmenHookingUpWithGroupleadTanker)
	{
		bool result = default(bool);
		try
		{
			if (theAC == null)
			{
				result = false;
				return result;
			}
			if (theAC.ProbeRefuelling)
			{
				if (WingmenHookingUpWithGroupleadTanker && theAC.IsGroupWingman())
				{
					result = true;
					return result;
				}
				result = (double)method_27(theAC) < 1.0;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100440", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void RefuelingConnectionValidation()
	{
		if (!method_0().IsTanker)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (string key in method_0().AirOps.A2AR_Connections.Keys)
		{
			if (method_0().ParentScen.ActiveUnits.TryGetValue(key, out var value))
			{
				if (((Aircraft)value).AirOps.Condition != _AirOpsCondition.Refuelling)
				{
					if (list == null)
					{
						list = new List<string>();
					}
					list.Add(key);
				}
			}
			else
			{
				list.Add(key);
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (string item in list)
		{
			method_0().AirOps.A2AR_Connections.Remove(item);
		}
	}

	public void UnloadCargoParadrop()
	{
		Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: true);
		myUnit.CargoTransferList = null;
	}

	public void UnloadCargo()
	{
		Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
		myUnit.CargoTransferList = null;
	}

	public void PickupCargoFromSource(ActiveUnit theSource)
	{
		if (theSource.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
		{
			return;
		}
		List<CargoManifestItem> list = Cargo.GenerateCargoManifest(theSource);
		if (list.Count > 0)
		{
			List<Cargo> list2 = ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)theSource, (ICargoHost)myUnit, list);
			if (list2.Count > 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(theSource, myUnit, list2);
			}
		}
		myUnit.AI.RemovePickupTarget(theSource.ObjectID);
	}

	public int CalculateETIC()
	{
		int num = default(int);
		switch (method_0().Damage.FireIntensity)
		{
		case ActiveUnit_Damage.FireIntensityLevel.Minor:
			num = 900;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Major:
			num = 1800;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Severe:
			num = 2700;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
			num = 3600;
			break;
		}
		int num2 = (int)Math.Round(method_0().Damage.DamagePercent / 100f * 86400f);
		switch (method_0().Size)
		{
		case GlobalVariables.AircraftSizeClass.UAS_Class2:
			num2 = (int)Math.Round((double)num2 * 0.75);
			break;
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
			num2 = (int)Math.Round((double)num2 * 0.5);
			break;
		case GlobalVariables.AircraftSizeClass.VLarge:
			num2 *= 3;
			break;
		case GlobalVariables.AircraftSizeClass.Large:
			num2 *= 2;
			break;
		case GlobalVariables.AircraftSizeClass.Medium:
			num2 = (int)Math.Round((double)num2 * 1.5);
			break;
		}
		int num3 = default(int);
		foreach (PlatformComponent item in method_0().Components())
		{
			if (item.Status == PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			if (!item.IsCargo)
			{
				if (!item.IsCIC)
				{
					if (!item.IsCommDevice && !item.IsSensor && !item.IsMount)
					{
						if (!item.IsEngine)
						{
							continue;
						}
						if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							num3 += 14400;
							continue;
						}
						switch (item.DamageSeverity)
						{
						case PlatformComponent._DamageSeverityFactor.Light:
							num3 += 3600;
							break;
						case PlatformComponent._DamageSeverityFactor.Medium:
							num3 += 7200;
							break;
						case PlatformComponent._DamageSeverityFactor.Heavy:
							num3 += 10800;
							break;
						}
					}
					else if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
					{
						num3 += 14400;
					}
					else
					{
						switch (item.DamageSeverity)
						{
						case PlatformComponent._DamageSeverityFactor.Light:
							num3 += 3600;
							break;
						case PlatformComponent._DamageSeverityFactor.Medium:
							num3 += 7200;
							break;
						case PlatformComponent._DamageSeverityFactor.Heavy:
							num3 += 10800;
							break;
						}
					}
				}
				else if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num3 += 10800;
				}
				else
				{
					switch (item.DamageSeverity)
					{
					case PlatformComponent._DamageSeverityFactor.Light:
						num3 += 2700;
						break;
					case PlatformComponent._DamageSeverityFactor.Medium:
						num3 += 5400;
						break;
					case PlatformComponent._DamageSeverityFactor.Heavy:
						num3 += 8100;
						break;
					}
				}
			}
			else if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				num3 += 3600;
			}
			else
			{
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3 += 900;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3 += 1800;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num3 += 2700;
					break;
				}
			}
		}
		return num + num2 + num3;
	}
}
