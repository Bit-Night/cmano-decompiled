using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveUnit_DockingOps
{
	public delegate void DeployedToSeaEventHandler(ActiveUnit theBoat);

	public delegate void DockingEventHandler(ActiveUnit theBoat);

	public delegate void HostDockFacilityChangedEventHandler(string UnitObjectID);

	public delegate void DockingOpsStatusChangeEventHandler(ActiveUnit theUnit, object oldStatus);

	public enum _DockingOpsCondition : byte
	{
		Underway,
		Docked,
		DeployingUnderway,
		Docking,
		RTB,
		Readying,
		ManoeuveringToRefuel,
		Replenishing,
		ProvidingUNREP,
		RechargingBatteries,
		SettlingForCargoTransfer,
		LoadedAsCargo,
		TransferringCargo,
		TransferringMissionCargo,
		HoldingPattern_CommsLost,
		DeployingDippingSonar
	}

	public enum ResultOfAttemptToScheduleUNREP
	{
		None,
		Success,
		Fail_Other,
		Fail_NoCandidatesWithinSpecifiedDistance
	}

	public enum ResultOfAttemptToRendezvousWithTanker
	{
		None,
		Success,
		Fail_Unknown,
		Fail_NoSuitableFuelOrStoresToTransfer,
		Fail_CannotIntercept,
		Fail_ProviderSmallerThanReceiver
	}

	public enum ResupplyRequest
	{
		Fuel,
		Material,
		FuelAndMaterial,
		FuelOrMaterial
	}

	public enum ResupplyCapacity
	{
		None,
		Fuel,
		Material,
		FuelAndMaterial
	}

	[CompilerGenerated]
	internal sealed class _Closure$__100-0
	{
		public Module_Unit.Unit $VB$Local_PickupUnit;

		public _Closure$__100-0(_Closure$__100-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PickupUnit = arg0.$VB$Local_PickupUnit;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(GeoPoint thepoint)
		{
			return Math2.CalcDist(thepoint.Latitude, thepoint.Longitude, $VB$Local_PickupUnit.get_Latitude((GlobalVariables.BooleanObject)null), $VB$Local_PickupUnit.get_Longitude((GlobalVariables.BooleanObject)null));
		}

		static _Closure$__100-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__113-0
	{
		public Dictionary<string, int> $VB$Local_GroupDictionary;

		public Func<Cargo, int> $I0;

		public _Closure$__113-0(_Closure$__113-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_GroupDictionary = arg0.$VB$Local_GroupDictionary;
			}
		}

		[SpecialName]
		internal int _Lambda$__0(Cargo s)
		{
			ActiveUnit cargoObjectActiveUnit = s.CargoObjectActiveUnit;
			int result;
			if (cargoObjectActiveUnit != null)
			{
				if (cargoObjectActiveUnit.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					result = int.MaxValue;
					goto IL_004c;
				}
				if ($VB$Local_GroupDictionary.TryGetValue(cargoObjectActiveUnit.get_ParentGroup(UsingMissionPlanner: false).ObjectID, out var value))
				{
					if (!cargoObjectActiveUnit.IsGroupLead())
					{
						return value + 1;
					}
					return value;
				}
			}
			result = int.MaxValue;
			goto IL_004c;
			IL_004c:
			return result;
		}

		static _Closure$__113-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__121-0
	{
		public FuelRec $VB$Local_theFR;

		public _Closure$__121-0(_Closure$__121-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFR = arg0.$VB$Local_theFR;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(FuelRec theF)
		{
			return (theF.FuelType == $VB$Local_theFR.FuelType) & (theF.CurrentQuantity > 0f);
		}

		static _Closure$__121-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__122-0
	{
		public FuelRec $VB$Local_theFR;

		public _Closure$__122-0(_Closure$__122-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFR = arg0.$VB$Local_theFR;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(FuelRec theF)
		{
			if (theF.FuelType == $VB$Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}

		static _Closure$__122-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__123-0
	{
		public FuelRec $VB$Local_theFR;

		public _Closure$__123-0(_Closure$__123-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFR = arg0.$VB$Local_theFR;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(FuelRec theF)
		{
			if (theF.FuelType == $VB$Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}

		static _Closure$__123-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__123-1
	{
		public FuelRec $VB$Local_theFR;

		public _Closure$__123-1(_Closure$__123-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFR = arg0.$VB$Local_theFR;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(FuelRec theF)
		{
			if (theF.FuelType == $VB$Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}

		static _Closure$__123-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__123-2
	{
		public FuelRec $VB$Local_theFR;

		public _Closure$__123-2(_Closure$__123-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFR = arg0.$VB$Local_theFR;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(FuelRec theF)
		{
			if (theF.FuelType == $VB$Local_theFR.FuelType)
			{
				return theF.CurrentQuantity > 0f;
			}
			return false;
		}

		static _Closure$__123-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__157-0
	{
		public int? $VB$Local_DistanceLimit;

		public GeoPoint $VB$Local_IntermediateTargetPoint;

		public ActiveUnit_DockingOps $VB$Me;

		public _Closure$__157-0(_Closure$__157-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_DistanceLimit = arg0.$VB$Local_DistanceLimit;
				$VB$Local_IntermediateTargetPoint = arg0.$VB$Local_IntermediateTargetPoint;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theT)
		{
			return $VB$Me.myUnit.RangeToUnit_Horiz(theT) <= (float)$VB$Local_DistanceLimit.Value;
		}

		[SpecialName]
		internal double _Lambda$__7(ActiveUnit theT)
		{
			return Module_Unit.RangeToPoint_Horiz_Angular(theT, $VB$Local_IntermediateTargetPoint);
		}

		static _Closure$__157-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__157-1
	{
		public double $VB$Local_RangeToBase_Angular;

		public _Closure$__157-2 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__157-1(_Closure$__157-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_RangeToBase_Angular = arg0.$VB$Local_RangeToBase_Angular;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(ActiveUnit theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular($VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, theT) >= $VB$Local_RangeToBase_Angular)
			{
				return false;
			}
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, $VB$NonLocal_$VB$Closure_3.$VB$Local_myHost) < $VB$Local_RangeToBase_Angular;
		}

		static _Closure$__157-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__157-2
	{
		public ActiveUnit $VB$Local_myHost;

		public _Closure$__157-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__157-2(_Closure$__157-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myHost = arg0.$VB$Local_myHost;
			}
		}

		static _Closure$__157-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__157-3
	{
		public double $VB$Local_RangeToTarget_Angular;

		public _Closure$__157-0 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__157-3(_Closure$__157-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_RangeToTarget_Angular = arg0.$VB$Local_RangeToTarget_Angular;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(ActiveUnit theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular($VB$NonLocal_$VB$Closure_4.$VB$Me.myUnit, theT) >= $VB$Local_RangeToTarget_Angular)
			{
				return false;
			}
			return Module_Unit.RangeToPoint_Horiz_Angular(theT, $VB$NonLocal_$VB$Closure_4.$VB$Local_IntermediateTargetPoint) < $VB$Local_RangeToTarget_Angular;
		}

		static _Closure$__157-3()
		{
			Class72.smethod_20();
		}
	}

	protected ActiveUnit myUnit;

	public float PierLaneLength;

	private DockFacility dockFacility_0;

	private string string_0;

	private ActiveUnit activeUnit_0;

	private ActiveUnit activeUnit_1;

	private string string_1;

	private string string_2;

	private string string_3;

	private ActiveUnit activeUnit_2;

	private string string_4;

	public string UNREP_Port_ReceiverUnitID;

	public float UNREP_Port_TimeToNextTransfer;

	public string UNREP_Starboard_ReceiverUnitID;

	public float UNREP_Starboard_TimeToNextTransfer;

	public string UNREP_Astern_ReceiverUnitID;

	public float UNREP_Astern_TimeToNextTransfer;

	[AccessedThroughProperty("UNREP_Queue")]
	[CompilerGenerated]
	private List<string> list_0;

	private _DockingOpsCondition _DockingOpsCondition_0;

	private float float_0;

	private _DockingOpsCondition _DockingOpsCondition_1;

	internal _DockingOpsCondition _ConditionBeforeNeedToRechargeBattery;

	internal float _DepthBeforeBatteryRecharge;

	internal ActiveUnit.Throttle _ThrottleBeforeBatteryRecharge;

	[CompilerGenerated]
	private static DeployedToSeaEventHandler deployedToSeaEventHandler_0;

	[CompilerGenerated]
	private static DockingEventHandler dockingEventHandler_0;

	public float UNREP_Connect_ThresholdRange;

	public static int DEFAULT_CARGO_LOAD_TIME;

	public static int DEFAULT_CARGO_UNLOAD_TIME;

	[CompilerGenerated]
	private static HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler_0;

	private Geopoint_Struct[] geopoint_Struct_0;

	[CompilerGenerated]
	private static DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler_0;

	public static LockObject CargoOpsLockObj;

	public static Lazy<LockRandom> CargoOpsRandom;

	public virtual List<string> UNREP_Queue
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
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
		}
	}

	public ActiveUnit ActualDestinationHost
	{
		get
		{
			ActiveUnit result;
			try
			{
				ActiveUnit activeUnit = null;
				Mission mission = myUnit.ActiveMissionOrPackage();
				if (mission == null)
				{
					activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
					goto IL_02f0;
				}
				if (mission.MissionClass == Mission._MissionClass.Ferry)
				{
					if (((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen) == null)
					{
						myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is no longer able to execute ferry mission: " + mission.Name + " (the ferry destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " unable to ferry; removed from mission", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						ActiveUnit activeUnit2 = myUnit;
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
						activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
					}
					activeUnit = ((FerryMission)mission).Behavior switch
					{
						FerryMission.FerryMissionBehavior.OneWay => ((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen), 
						FerryMission.FerryMissionBehavior.Cycle => myUnit.AI.GetMissionStateFlag(4u) ? ((FerryMission)mission).get_NominalDestinationHost(myUnit.ParentScen) : this.get_AssignedHostUnit(PickNewAssignedHost: false), 
						FerryMission.FerryMissionBehavior.Random => this.get_AssignedHostUnit(PickNewAssignedHost: false), 
						_ => this.get_AssignedHostUnit(PickNewAssignedHost: false), 
					};
					goto IL_02f0;
				}
				if (mission.MissionClass != Mission._MissionClass.Cargo || ((CargoMission)mission).Type != CargoMission.CargoMissionType.Transfer)
				{
					activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
					if (this.get_AssignedHostUnit(PickNewAssignedHost: false) == null && OriginalCargoHostUnit != null && myUnit.OnboardCargo.Count() == 0)
					{
						activeUnit = OriginalCargoHostUnit;
					}
					goto IL_02f0;
				}
				CargoMission cargoMission = (CargoMission)mission;
				if (cargoMission.DestinationUnit == null || !myUnit.ParentScen.ActiveUnits.Keys.Contains(cargoMission.DestinationUnit.ObjectID))
				{
					myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is no longer able to execute cargo mission: " + mission.Name + " (the destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " unable to execute cargo mission; removed from mission", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ActiveUnit activeUnit3 = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
				}
				if (myUnit.OnboardCargo.Count() > 0)
				{
					activeUnit = cargoMission.DestinationUnit;
					goto IL_02f0;
				}
				if (this.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
				{
					activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
					goto IL_02f0;
				}
				if (OriginalCargoHostUnit == null)
				{
					goto IL_02f0;
				}
				activeUnit = OriginalCargoHostUnit;
				result = activeUnit;
				goto end_IL_0001;
				IL_02f0:
				if (!Information.IsNothing((object)activeUnit) && activeUnit.IsGroupMember() && activeUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation)
				{
					activeUnit = activeUnit.get_ParentGroup(UsingMissionPlanner: false);
				}
				result = activeUnit;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100133", "");
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

	public Geopoint_Struct[] PierEntranceLane
	{
		get
		{
			Geopoint_Struct[] result;
			try
			{
				if (HasPiers(myUnit))
				{
					if (Information.IsNothing((object)geopoint_Struct_0))
					{
						Geopoint_Struct[] array = new Geopoint_Struct[10];
						float num = Math2.NormalizeBearing(myUnit.CurrentHeading - 60f);
						float bearing = Math2.NormalizeBearing(myUnit.CurrentHeading + 60f);
						float currentHeading = myUnit.CurrentHeading;
						Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength / 3f, Math2.NormalizeBearing(currentHeading + 180f));
						array[0] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, num);
						array[1] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(num + 15f));
						array[2] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(num + 30f));
						array[3] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(num + 45f));
						array[4] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, currentHeading);
						array[5] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(currentHeading + 15f));
						array[6] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(currentHeading + 30f));
						array[7] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, Math2.NormalizeBearing(currentHeading + 45f));
						array[8] = geopoint_Struct;
						geopoint_Struct = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, PierLaneLength, bearing);
						array[9] = geopoint_Struct;
						geopoint_Struct_0 = array;
					}
					result = geopoint_Struct_0;
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
				ex2?.Data.Add("Error at 101363", "");
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

	public ActiveUnit UNREP_Destination
	{
		get
		{
			return activeUnit_2;
		}
		set
		{
			try
			{
				if (value != activeUnit_2 && !Information.IsNothing((object)activeUnit_2) && !Information.IsNothing((object)activeUnit_2.DockingOps))
				{
					activeUnit_2.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
				}
				activeUnit_2 = value;
				if (value != null)
				{
					List<string> uNREP_Queue = activeUnit_2.DockingOps.UNREP_Queue;
					if (!uNREP_Queue.Contains(myUnit.ObjectID))
					{
						uNREP_Queue.Add(myUnit.ObjectID);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100135", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _DockingOpsCondition OldCondition => _DockingOpsCondition_1;

	public _DockingOpsCondition Condition
	{
		get
		{
			return _DockingOpsCondition_0;
		}
		set
		{
			try
			{
				bool num = _DockingOpsCondition_0 != value;
				_DockingOpsCondition_1 = _DockingOpsCondition_0;
				_DockingOpsCondition_0 = value;
				if (!num)
				{
					return;
				}
				switch (value)
				{
				case _DockingOpsCondition.DeployingUnderway:
					ConditionTimer += (float)((double)TimeNeededToDock * (2.0 / 3.0));
					break;
				case _DockingOpsCondition.Docking:
					ConditionTimer = TimeNeededToDock;
					dockingEventHandler_0?.Invoke(myUnit);
					break;
				case _DockingOpsCondition.RechargingBatteries:
					_DepthBeforeBatteryRecharge = myUnit.DesiredAltitude;
					_ThrottleBeforeBatteryRecharge = myUnit.ThrottleSetting;
					break;
				default:
					if (_DockingOpsCondition_1 == _DockingOpsCondition.RechargingBatteries)
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							myUnit.DesiredAltitude = _DepthBeforeBatteryRecharge;
							myUnit.SetThrottle(_ThrottleBeforeBatteryRecharge);
							if (myUnit.Navigator.SprintDrift)
							{
								myUnit.Navigator.SetSprintDriftMarker(ResetAverageSpeed: false);
							}
						}
					}
					else if (value == _DockingOpsCondition.Underway)
					{
						deployedToSeaEventHandler_0?.Invoke(myUnit);
					}
					break;
				}
				dockingOpsStatusChangeEventHandler_0?.Invoke(myUnit, _DockingOpsCondition_1);
				myUnit.Kinematics.ExportLocationEvent("DockingOpsConditionChanged");
				if (myUnit.AssignedMissionOrPackage() != null && !myUnit.IsOperating())
				{
					myUnit.AI.ClearMissionStateFlags();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100136", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
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
				return Condition.ToString();
			case _DockingOpsCondition.Underway:
				return "Underway";
			case _DockingOpsCondition.Docked:
				return "Docked";
			case _DockingOpsCondition.DeployingUnderway:
				return "Deployment Underway";
			case _DockingOpsCondition.Docking:
				return "Docking";
			case _DockingOpsCondition.RTB:
				return "Returning to base";
			case _DockingOpsCondition.Readying:
				return "Readying";
			case _DockingOpsCondition.ManoeuveringToRefuel:
				return "Manoeuvering To Refuel";
			case _DockingOpsCondition.Replenishing:
				return "Replenishing";
			case _DockingOpsCondition.ProvidingUNREP:
				return "Providing UNREP";
			case _DockingOpsCondition.RechargingBatteries:
				return "Recharging Batteries";
			case _DockingOpsCondition.LoadedAsCargo:
				return "Loaded as Cargo";
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.TransferringCargo:
			case _DockingOpsCondition.TransferringMissionCargo:
				return "Transferring Cargo";
			case _DockingOpsCondition.HoldingPattern_CommsLost:
				return "Holding Pattern - Comms Lost";
			case _DockingOpsCondition.DeployingDippingSonar:
				return "Deploying Dipping Sonar";
			}
		}
	}

	public ActiveUnit AssignedHostUnit
	{
		get
		{
			ActiveUnit result;
			try
			{
				if (PickNewAssignedHost && (Information.IsNothing((object)activeUnit_0) || activeUnit_0.IsMorituri))
				{
					PickNewAssignedHost_Nearest();
				}
				result = activeUnit_0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100137", "");
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
			try
			{
				bool num = value != activeUnit_0;
				activeUnit_0 = value;
				if (num && myUnit.IsSubmarine && ((Submarine)myUnit).IsTetheredROV && value != null)
				{
					ActiveUnit activeUnit = myUnit;
					Mission value2 = value.ActiveMissionOrPackage();
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit.Set_AssignedMissionOrPackage(value2, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100138", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public ActiveUnit OriginalCargoHostUnit => activeUnit_1;

	public ReadOnlyCollection<ActiveUnit> AssignedBoats
	{
		get
		{
			ReadOnlyCollection<ActiveUnit> result;
			try
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
				{
					if (Information.IsNothing((object)activeUnits_))
					{
						continue;
					}
					if (!activeUnits_.IsShip)
					{
						if (activeUnits_.IsSubmarine && ((Submarine)activeUnits_).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) == myUnit)
						{
							list.Add(activeUnits_);
						}
					}
					else if (((Ship)activeUnits_).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) == myUnit)
					{
						list.Add(activeUnits_);
					}
				}
				result = list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100139b", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<ActiveUnit>().AsReadOnly();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public PooledList<ActiveUnit> EmbarkedBoats_ReadOnly
	{
		get
		{
			PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
			PooledList<ActiveUnit> result;
			try
			{
				DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
				foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
				{
					pooledList.AddRange(dockFacility.HostedBoats.Values);
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100139", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new PooledList<ActiveUnit>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public DockFacility HostDockFacility
	{
		get
		{
			return dockFacility_0;
		}
		set
		{
			try
			{
				bool num = value != dockFacility_0;
				if (dockFacility_0 != null)
				{
					dockFacility_0.HostedBoats.TryRemove(myUnit.ObjectID, out myUnit);
				}
				if (value != null && !value.HostedBoats.ContainsKey(myUnit.ObjectID))
				{
					value.HostedBoats.TryAdd(myUnit.ObjectID, myUnit);
				}
				dockFacility_0 = value;
				if (num)
				{
					hostDockFacilityChangedEventHandler_0?.Invoke(myUnit.ObjectID);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100140", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
			ActiveUnit result;
			try
			{
				if (_DockingOpsCondition_0 == _DockingOpsCondition.LoadedAsCargo)
				{
					result = activeUnit_0;
				}
				else
				{
					DockFacility hostDockFacility = HostDockFacility;
					if (hostDockFacility != null)
					{
						if (hostDockFacility.ParentPlatform != null)
						{
							ActiveUnit parentPlatform = hostDockFacility.ParentPlatform;
							result = ((!parentPlatform.IsGroupMember() || parentPlatform.get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.Installation) ? parentPlatform : parentPlatform.get_ParentGroup(UsingMissionPlanner: false));
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100141", "");
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

	public bool IsCurrentlyProvidingUNREP
	{
		get
		{
			int result;
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					return true;
				}
				result = 0;
			}
			else
			{
				PooledList<ActiveUnit> activeUnits_List = myUnit.ParentScen.ActiveUnits_List;
				if (activeUnits_List == null)
				{
					return false;
				}
				int num = activeUnits_List.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						ActiveUnit activeUnit = activeUnits_List[i];
						if (activeUnit != null && activeUnit.DockingOps.UNREP_Destination == myUnit && activeUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							return true;
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
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public short TimeNeededToDock
	{
		get
		{
			short result;
			try
			{
				DockFacility.DockingPhysicalSize dockingPhysicalSize = default(DockFacility.DockingPhysicalSize);
				if (myUnit.IsShip)
				{
					dockingPhysicalSize = ((Ship)myUnit).DockingPhysicalSize;
				}
				if (myUnit.IsSubmarine)
				{
					dockingPhysicalSize = ((Submarine)myUnit).DockingPhysicalSize;
				}
				if (myUnit.IsVehicle)
				{
					dockingPhysicalSize = ((Vehicle)myUnit).DockingPhysicalSize;
				}
				switch (dockingPhysicalSize)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case DockFacility.DockingPhysicalSize.const_1:
				case DockFacility.DockingPhysicalSize.VSmallDockDavit:
				case DockFacility.DockingPhysicalSize.ROV_UUV:
					result = 60;
					break;
				case DockFacility.DockingPhysicalSize.SmallPier:
				case DockFacility.DockingPhysicalSize.SmallDockDavit:
				case DockFacility.DockingPhysicalSize.DryDockShelter:
					result = 180;
					break;
				case DockFacility.DockingPhysicalSize.MediumPier:
				case DockFacility.DockingPhysicalSize.MediumDock:
					result = 360;
					break;
				case DockFacility.DockingPhysicalSize.LargePier:
				case DockFacility.DockingPhysicalSize.LargeDock:
					result = 600;
					break;
				case DockFacility.DockingPhysicalSize.const_5:
					result = 900;
					break;
				case DockFacility.DockingPhysicalSize.const_6:
					result = 1200;
					break;
				case DockFacility.DockingPhysicalSize.None:
					result = 360;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100142", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 360;
				}
				else
				{
					Debugger.Break();
					num = 360;
				}
				result = (short)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public int FuelWeCanSupplyToThisUnit
	{
		get
		{
			int result;
			try
			{
				int num4 = default(int);
				foreach (FuelRec item in theReceiver.Fuel_ReadOnly)
				{
					if (!(item.CurrentQuantity < (float)item.MaxQuantity))
					{
						continue;
					}
					int num = (int)Math.Round((float)item.MaxQuantity - item.CurrentQuantity);
					int num2 = 0;
					int num3 = 0;
					foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
					{
						if (item2.FuelType == item.FuelType)
						{
							num2 = (int)Math.Round((float)num2 + item2.CurrentQuantity);
							num3 += item2.MaxQuantity;
						}
					}
					if (!(ElgibleProviderMaxFuel > 0f) || !((float)num3 < ElgibleProviderMaxFuel))
					{
						num4 = ((num < num2) ? (num4 + num) : (num4 + num2));
					}
				}
				result = num4;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100148", "");
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
				result = num5;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public int MaterialWeCanSupplyToThisUnit
	{
		get
		{
			int result;
			try
			{
				PooledDictionary<int, Weapon> pooledDictionary = theReceiver.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
				int num3 = default(int);
				foreach (int key in pooledDictionary.Keys)
				{
					if (WeaponsToSupply != null && !WeaponsToSupply.ContainsKey(key))
					{
						continue;
					}
					int num = ((!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)) ? myUnit.Weaponry.HowManyOfThisWeaponOnMagazines(key) : int.MaxValue);
					if (num != 0)
					{
						(int CurrentInventory, int TotalCapacity) tuple = theReceiver.Weaponry.CurrentInventoryAndTotalCapacityForThisWeapon(key, IncludeNonOperationalMountsAndMags: false);
						int item = tuple.TotalCapacity;
						int item2 = tuple.CurrentInventory;
						int num2 = item - item2;
						if (num2 > 0 && Operators.CompareString(theReceiver.Weaponry.CanReplenishWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) == 0)
						{
							num3 = ((num2 < num) ? (num3 + num2) : (num3 + num));
						}
					}
				}
				pooledDictionary.Dispose();
				result = num3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100149", "");
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
				result = num4;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsDeploying
	{
		get
		{
			_DockingOpsCondition condition = Condition;
			if (condition == _DockingOpsCondition.DeployingUnderway)
			{
				return true;
			}
			return false;
		}
	}

	public static event DeployedToSeaEventHandler DeployedToSea
	{
		[CompilerGenerated]
		add
		{
			DeployedToSeaEventHandler deployedToSeaEventHandler = deployedToSeaEventHandler_0;
			DeployedToSeaEventHandler deployedToSeaEventHandler2;
			do
			{
				deployedToSeaEventHandler2 = deployedToSeaEventHandler;
				DeployedToSeaEventHandler value2 = (DeployedToSeaEventHandler)Delegate.Combine(deployedToSeaEventHandler2, value);
				deployedToSeaEventHandler = Interlocked.CompareExchange(ref deployedToSeaEventHandler_0, value2, deployedToSeaEventHandler2);
			}
			while ((object)deployedToSeaEventHandler != deployedToSeaEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DeployedToSeaEventHandler deployedToSeaEventHandler = deployedToSeaEventHandler_0;
			DeployedToSeaEventHandler deployedToSeaEventHandler2;
			do
			{
				deployedToSeaEventHandler2 = deployedToSeaEventHandler;
				DeployedToSeaEventHandler value2 = (DeployedToSeaEventHandler)Delegate.Remove(deployedToSeaEventHandler2, value);
				deployedToSeaEventHandler = Interlocked.CompareExchange(ref deployedToSeaEventHandler_0, value2, deployedToSeaEventHandler2);
			}
			while ((object)deployedToSeaEventHandler != deployedToSeaEventHandler2);
		}
	}

	public static event DockingEventHandler Docking
	{
		[CompilerGenerated]
		add
		{
			DockingEventHandler dockingEventHandler = dockingEventHandler_0;
			DockingEventHandler dockingEventHandler2;
			do
			{
				dockingEventHandler2 = dockingEventHandler;
				DockingEventHandler value2 = (DockingEventHandler)Delegate.Combine(dockingEventHandler2, value);
				dockingEventHandler = Interlocked.CompareExchange(ref dockingEventHandler_0, value2, dockingEventHandler2);
			}
			while ((object)dockingEventHandler != dockingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DockingEventHandler dockingEventHandler = dockingEventHandler_0;
			DockingEventHandler dockingEventHandler2;
			do
			{
				dockingEventHandler2 = dockingEventHandler;
				DockingEventHandler value2 = (DockingEventHandler)Delegate.Remove(dockingEventHandler2, value);
				dockingEventHandler = Interlocked.CompareExchange(ref dockingEventHandler_0, value2, dockingEventHandler2);
			}
			while ((object)dockingEventHandler != dockingEventHandler2);
		}
	}

	public static event HostDockFacilityChangedEventHandler HostDockFacilityChanged
	{
		[CompilerGenerated]
		add
		{
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler = hostDockFacilityChangedEventHandler_0;
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler2;
			do
			{
				hostDockFacilityChangedEventHandler2 = hostDockFacilityChangedEventHandler;
				HostDockFacilityChangedEventHandler value2 = (HostDockFacilityChangedEventHandler)Delegate.Combine(hostDockFacilityChangedEventHandler2, value);
				hostDockFacilityChangedEventHandler = Interlocked.CompareExchange(ref hostDockFacilityChangedEventHandler_0, value2, hostDockFacilityChangedEventHandler2);
			}
			while ((object)hostDockFacilityChangedEventHandler != hostDockFacilityChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler = hostDockFacilityChangedEventHandler_0;
			HostDockFacilityChangedEventHandler hostDockFacilityChangedEventHandler2;
			do
			{
				hostDockFacilityChangedEventHandler2 = hostDockFacilityChangedEventHandler;
				HostDockFacilityChangedEventHandler value2 = (HostDockFacilityChangedEventHandler)Delegate.Remove(hostDockFacilityChangedEventHandler2, value);
				hostDockFacilityChangedEventHandler = Interlocked.CompareExchange(ref hostDockFacilityChangedEventHandler_0, value2, hostDockFacilityChangedEventHandler2);
			}
			while ((object)hostDockFacilityChangedEventHandler != hostDockFacilityChangedEventHandler2);
		}
	}

	public static event DockingOpsStatusChangeEventHandler DockingOpsStatusChange
	{
		[CompilerGenerated]
		add
		{
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler = dockingOpsStatusChangeEventHandler_0;
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler2;
			do
			{
				dockingOpsStatusChangeEventHandler2 = dockingOpsStatusChangeEventHandler;
				DockingOpsStatusChangeEventHandler value2 = (DockingOpsStatusChangeEventHandler)Delegate.Combine(dockingOpsStatusChangeEventHandler2, value);
				dockingOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref dockingOpsStatusChangeEventHandler_0, value2, dockingOpsStatusChangeEventHandler2);
			}
			while ((object)dockingOpsStatusChangeEventHandler != dockingOpsStatusChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler = dockingOpsStatusChangeEventHandler_0;
			DockingOpsStatusChangeEventHandler dockingOpsStatusChangeEventHandler2;
			do
			{
				dockingOpsStatusChangeEventHandler2 = dockingOpsStatusChangeEventHandler;
				DockingOpsStatusChangeEventHandler value2 = (DockingOpsStatusChangeEventHandler)Delegate.Remove(dockingOpsStatusChangeEventHandler2, value);
				dockingOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref dockingOpsStatusChangeEventHandler_0, value2, dockingOpsStatusChangeEventHandler2);
			}
			while ((object)dockingOpsStatusChangeEventHandler != dockingOpsStatusChangeEventHandler2);
		}
	}

	static ActiveUnit_DockingOps()
	{
		Class72.smethod_20();
		DEFAULT_CARGO_LOAD_TIME = 1800;
		DEFAULT_CARGO_UNLOAD_TIME = 240;
		CargoOpsLockObj = new LockObject();
		CargoOpsRandom = new Lazy<LockRandom>();
	}

	public static void ToXML(ActiveUnit_DockingOps theDockOps, ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit_DockingOps");
			XmlWriter obj = theWriter;
			int dockingOpsCondition_ = (int)theDockOps._DockingOpsCondition_0;
			obj.WriteElementString("Con", dockingOpsCondition_.ToString());
			if (theDockOps.ConditionTimer != 0f)
			{
				theWriter.WriteElementString("CT", XmlConvert.ToString(theDockOps.ConditionTimer));
			}
			if (theDockOps.myUnit.IsSubmarine && !((Submarine)theDockOps.myUnit).IsNuke)
			{
				XmlWriter obj2 = theWriter;
				dockingOpsCondition_ = (int)theDockOps._ConditionBeforeNeedToRechargeBattery;
				obj2.WriteElementString("CBRB", dockingOpsCondition_.ToString());
			}
			if (theDockOps.myUnit.IsSubmarine && !((Submarine)theDockOps.myUnit).IsNuke)
			{
				theWriter.WriteElementString("CBRB_Depth", XmlConvert.ToString(theDockOps._DepthBeforeBatteryRecharge));
			}
			if (theDockOps.myUnit.IsSubmarine && !((Submarine)theDockOps.myUnit).IsNuke)
			{
				XmlWriter obj3 = theWriter;
				byte throttleBeforeBatteryRecharge = (byte)theDockOps._ThrottleBeforeBatteryRecharge;
				obj3.WriteElementString("CBRB_ThrottleSetting", throttleBeforeBatteryRecharge.ToString());
			}
			if (theDockOps.dockFacility_0 != null)
			{
				theWriter.WriteElementString("HDF", theDockOps.HostDockFacility.ObjectID);
			}
			if (theDockOps.CurrentHostUnit != null)
			{
				theWriter.WriteElementString("CHU", theDockOps.CurrentHostUnit.ObjectID);
			}
			if (theDockOps.activeUnit_0 != null)
			{
				theWriter.WriteElementString("AHU", theDockOps.activeUnit_0.ObjectID);
			}
			if (theDockOps.activeUnit_1 != null)
			{
				theWriter.WriteElementString("OHU", theDockOps.activeUnit_1.ObjectID);
			}
			if (theDockOps.UNREP_Destination != null)
			{
				theWriter.WriteElementString("UNREP_D", theDockOps.UNREP_Destination.ObjectID);
			}
			if (!string.IsNullOrEmpty(theDockOps.UNREP_Port_ReceiverUnitID))
			{
				theWriter.WriteElementString("UNREP_P", theDockOps.UNREP_Port_ReceiverUnitID);
			}
			if (!string.IsNullOrEmpty(theDockOps.UNREP_Starboard_ReceiverUnitID))
			{
				theWriter.WriteElementString("UNREP_S", theDockOps.UNREP_Starboard_ReceiverUnitID);
			}
			if (!string.IsNullOrEmpty(theDockOps.UNREP_Astern_ReceiverUnitID))
			{
				theWriter.WriteElementString("UNREP_A", theDockOps.UNREP_Astern_ReceiverUnitID);
			}
			theWriter.WriteElementString("PierLL", ((int)Math.Round(theDockOps.PierLaneLength)).ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100129", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_DockingOps FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		ActiveUnit_DockingOps result;
		try
		{
			ActiveUnit_DockingOps activeUnit_DockingOps = new ActiveUnit_DockingOps(ref theAU);
			activeUnit_DockingOps.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "UNREP_D":
					activeUnit_DockingOps.string_4 = val.InnerText;
					break;
				case "UNREP_P":
					if (!string.IsNullOrEmpty(val.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID, val.InnerText, false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID, val.InnerText, false) != 0)
					{
						activeUnit_DockingOps.UNREP_Port_ReceiverUnitID = val.InnerText;
					}
					break;
				case "UNREP_S":
					if (!string.IsNullOrEmpty(val.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Port_ReceiverUnitID, val.InnerText, false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID, val.InnerText, false) != 0)
					{
						activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID = val.InnerText;
					}
					break;
				case "HDF":
					activeUnit_DockingOps.string_0 = val.InnerText;
					break;
				case "UNREP_A":
					if (!string.IsNullOrEmpty(val.InnerText) && Operators.CompareString(activeUnit_DockingOps.UNREP_Port_ReceiverUnitID, val.InnerText, false) != 0 && Operators.CompareString(activeUnit_DockingOps.UNREP_Starboard_ReceiverUnitID, val.InnerText, false) != 0)
					{
						activeUnit_DockingOps.UNREP_Astern_ReceiverUnitID = val.InnerText;
					}
					break;
				case "CHU":
					activeUnit_DockingOps.string_2 = val.InnerText;
					break;
				case "CT":
					activeUnit_DockingOps.ConditionTimer = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CBRB_Depth":
					activeUnit_DockingOps._DepthBeforeBatteryRecharge = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CBRB_ThrottleSetting":
					switch (val.InnerText)
					{
					case "FullStop":
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = ActiveUnit.Throttle.FullStop;
						break;
					case "Cruise":
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = ActiveUnit.Throttle.Cruise;
						break;
					case "Full":
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = ActiveUnit.Throttle.Full;
						break;
					default:
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = (ActiveUnit.Throttle)Conversions.ToByte(val.InnerText);
						break;
					case "Flank":
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = ActiveUnit.Throttle.Flank;
						break;
					case "Loiter":
						activeUnit_DockingOps._ThrottleBeforeBatteryRecharge = ActiveUnit.Throttle.Loiter;
						break;
					}
					break;
				case "AHU":
					activeUnit_DockingOps.string_1 = val.InnerText;
					break;
				case "Con":
				case "Condition":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						activeUnit_DockingOps.Condition = (_DockingOpsCondition)Enum.Parse(typeof(_DockingOpsCondition), val.InnerText, ignoreCase: true);
					}
					else
					{
						activeUnit_DockingOps.Condition = (_DockingOpsCondition)Conversions.ToByte(val.InnerText);
					}
					break;
				case "CBRB":
					activeUnit_DockingOps._ConditionBeforeNeedToRechargeBattery = (_DockingOpsCondition)Conversions.ToByte(val.InnerText);
					break;
				case "OHU":
					activeUnit_DockingOps.string_3 = val.InnerText;
					break;
				case "PierLL":
					activeUnit_DockingOps.PierLaneLength = XmlConvert.ToSingle(val.InnerText);
					break;
				}
			}
			result = activeUnit_DockingOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100130", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_DockingOps(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void PostDeserializationHousekeeping(ActiveUnit_DockingOps theDockOps, ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		try
		{
			if (!string.IsNullOrEmpty(theDockOps.string_3))
			{
				theDockOps.activeUnit_1 = theScen.ActiveUnits[theDockOps.string_3];
			}
			if (theDockOps.Condition == _DockingOpsCondition.LoadedAsCargo)
			{
				if (theDockOps.activeUnit_0 == null && theDockOps.string_1 != null)
				{
					theScen.ActiveUnits.TryGetValue(theDockOps.string_1, out var value);
					if (value != null)
					{
						theDockOps.myUnit.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, value);
					}
					else
					{
						theDockOps.myUnit.DockingOps.Condition = _DockingOpsCondition.Underway;
					}
				}
				return;
			}
			if (theDockOps.HostDockFacility == null && !string.IsNullOrEmpty(theDockOps.string_0))
			{
				if (theDictionary.ContainsKey(theDockOps.string_0))
				{
					theDockOps.HostDockFacility = (DockFacility)theDictionary[theDockOps.string_0];
					if (theDockOps.activeUnit_0 != null && Operators.CompareString(theDockOps.activeUnit_0.ObjectID, theDockOps.HostDockFacility.ParentPlatform.ObjectID, false) != 0)
					{
						theDockOps.activeUnit_0 = theDockOps.HostDockFacility.ParentPlatform;
						switch (theDockOps.Condition)
						{
						case _DockingOpsCondition.Docked:
							if (theDockOps.ConditionTimer > 0f)
							{
								theDockOps.Condition = _DockingOpsCondition.Readying;
							}
							break;
						case _DockingOpsCondition.Underway:
						case _DockingOpsCondition.RTB:
						case _DockingOpsCondition.ManoeuveringToRefuel:
						case _DockingOpsCondition.Replenishing:
						case _DockingOpsCondition.ProvidingUNREP:
						case _DockingOpsCondition.RechargingBatteries:
						case _DockingOpsCondition.SettlingForCargoTransfer:
						case _DockingOpsCondition.TransferringCargo:
						case _DockingOpsCondition.TransferringMissionCargo:
							if (theDockOps.ConditionTimer == 0f)
							{
								theDockOps.Condition = _DockingOpsCondition.Docked;
							}
							else
							{
								theDockOps.Condition = _DockingOpsCondition.Docking;
							}
							break;
						}
					}
				}
				else
				{
					bool flag = false;
					foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
					{
						if (activeUnits_ == null)
						{
							continue;
						}
						DockFacility[] dockFacilities_ReadOnly = activeUnits_.DockFacilities_ReadOnly;
						foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
						{
							if (string.CompareOrdinal(dockFacility.ObjectID, theDockOps.string_0) == 0)
							{
								theDockOps.HostDockFacility = dockFacility;
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
			}
			if (theDockOps.CurrentHostUnit != null && theDockOps.HostDockFacility != null && !theDockOps.CurrentHostUnit.DockFacilities_ReadOnly.Contains(theDockOps.HostDockFacility))
			{
				theDockOps.CurrentHostUnit.DockingOps.AddThisBoat(theDockOps.myUnit);
			}
			if (theDockOps.activeUnit_0 == null && theDockOps.string_1 != null)
			{
				try
				{
					if (!theScen.ActiveUnits.TryGetValue(theDockOps.string_1, out var value2))
					{
						if (!theDockOps.myUnit.IsOperating())
						{
							theDockOps.myUnit.DockingOps.Condition = _DockingOpsCondition.Underway;
						}
					}
					else if (!theDockOps.myUnit.IsOperating())
					{
						if (theDockOps.CurrentHostUnit != null && Operators.CompareString(theDockOps.CurrentHostUnit.ObjectID, value2.ObjectID, false) != 0)
						{
							if (theDockOps.myUnit.IsSubmarine && ((Submarine)theDockOps.myUnit).IsTetheredROV)
							{
								theDockOps.CurrentHostUnit.DockingOps.AddThisBoat(theDockOps.myUnit);
							}
							else
							{
								theDockOps.myUnit.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, value2);
							}
						}
						else
						{
							value2.DockingOps.AddThisBoat(theDockOps.myUnit);
						}
					}
					else
					{
						theDockOps.myUnit.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, value2);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200007", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (theDockOps.CurrentHostUnit == null && !theDockOps.myUnit.IsOperating() && theDockOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
			{
				theDockOps.get_AssignedHostUnit(PickNewAssignedHost: false).DockingOps.AddThisBoat(theDockOps.myUnit);
			}
			if (!string.IsNullOrEmpty(theDockOps.string_4))
			{
				theDockOps.activeUnit_2 = theScen.ActiveUnits[theDockOps.string_4];
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100131", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal List<ActiveUnit> GetDestinationPierList()
	{
		List<ActiveUnit> list = null;
		if (myUnit.IsShip || myUnit.IsSubmarine)
		{
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			if (actualDestinationHost != null && HasPiers(actualDestinationHost))
			{
				list = new List<ActiveUnit>();
				list.Add(actualDestinationHost);
			}
		}
		return list;
	}

	public static IEnumerable<ActiveUnit> ReadyBoats(ActiveUnit_DockingOps theDockOps)
	{
		IEnumerable<ActiveUnit> result;
		try
		{
			result = theDockOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit AC) => AC.DockingOps.Condition == _DockingOpsCondition.Docked && AC.DockingOps.ConditionTimer == 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100132", "");
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

	public void ResetPierEntranceLaneCache()
	{
		geopoint_Struct_0 = null;
	}

	public static bool HasPiers(ActiveUnit theUnit)
	{
		DockFacility[] dockFacilities_ReadOnly = theUnit.DockFacilities_ReadOnly;
		for (int i = 0; i < dockFacilities_ReadOnly.Length; i = checked(i + 1))
		{
			if (dockFacilities_ReadOnly[i].Type == DockFacility.DockFacilityType.Pier)
			{
				return true;
			}
		}
		return false;
	}

	public bool AttemptToRTB(bool ManuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool GroupMembersRTB, ActiveUnit._ActiveUnitStatus GroupMembersRTBStatus, bool DetachFromGroup, bool ClearPlottedCourse)
	{
		bool result;
		try
		{
			if (Condition == _DockingOpsCondition.DeployingDippingSonar && ConditionTimer > 0f)
			{
				result = false;
			}
			else if (!Information.IsNothing((object)ActualDestinationHost))
			{
				if (!Information.IsNothing((object)_ActiveUnitStatus_0))
				{
					myUnit.Status = _ActiveUnitStatus_0;
				}
				Condition = _DockingOpsCondition.RTB;
				myUnit.Navigator.ClearPlottedCourse();
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.DesiredAltitudeOverride = false;
				int num;
				if (!GroupMembersRTB)
				{
					num = 1;
				}
				else
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value != myUnit)
							{
								if (!value.IsUsingDippingSonar() || value.DockingOps.ConditionTimer == 0f)
								{
									value.Status = GroupMembersRTBStatus;
									value.DockingOps.Condition = _DockingOpsCondition.RTB;
									value.Navigator.ClearPlottedCourse();
								}
								value.Kinematics.DesiredSpeedOverride = null;
								value.Kinematics.DesiredAltitudeOverride = false;
							}
						}
					}
					num = 1;
				}
				result = (byte)num != 0;
			}
			else
			{
				PickNewAssignedHost_Nearest();
				if (!Information.IsNothing((object)this.get_AssignedHostUnit(PickNewAssignedHost: false)))
				{
					if (!Information.IsNothing((object)_ActiveUnitStatus_0))
					{
						myUnit.Status = _ActiveUnitStatus_0;
					}
					Condition = _DockingOpsCondition.RTB;
					myUnit.Navigator.ClearPlottedCourse();
					myUnit.Kinematics.DesiredSpeedOverride = null;
					myUnit.Kinematics.DesiredAltitudeOverride = false;
					int num2;
					if (!GroupMembersRTB)
					{
						num2 = 1;
					}
					else
					{
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
							{
								if (value2 != myUnit)
								{
									if (!value2.IsUsingDippingSonar() || value2.DockingOps.ConditionTimer == 0f)
									{
										value2.Status = GroupMembersRTBStatus;
										value2.DockingOps.Condition = _DockingOpsCondition.RTB;
										value2.Navigator.ClearPlottedCourse();
									}
									value2.Kinematics.DesiredSpeedOverride = null;
									value2.Kinematics.DesiredAltitudeOverride = false;
								}
							}
						}
						num2 = 1;
					}
					result = (byte)num2 != 0;
				}
				else
				{
					int num3;
					if (ManuallyOrdered)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + " has no suitable place to dock!", myUnit.Name + " cannot dock", LoggedMessage.MessageType.DockingOps, 15, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						num3 = 0;
					}
					else
					{
						num3 = 0;
					}
					result = (byte)num3 != 0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100134", "");
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

	public ActiveUnit_DockingOps(ref ActiveUnit theUnit)
	{
		PierLaneLength = 7f;
		UNREP_Queue = new List<string>();
		UNREP_Connect_ThresholdRange = 0.3f;
		myUnit = theUnit;
	}

	public void LoadIntoCargo(ActiveUnit containerUnit)
	{
		if (!myUnit.IsAircraft)
		{
			HostDockFacility = null;
		}
		else
		{
			Aircraft aircraft = (Aircraft)myUnit;
			aircraft.AirOps.QueuedTakeOff = false;
			aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
			aircraft.AirOps.HostAirFacility = null;
			if (aircraft.Loadout != null && aircraft.Loadout.Role != Loadout.LoadoutRole.PackedForCargo && aircraft.Loadout.Role != Loadout.LoadoutRole.Reserve)
			{
				aircraft.Loadout = DBFunctions.GetReserveLoadoutForThisAircraft(ref aircraft.ParentScen, aircraft.DBID);
			}
		}
		if (myUnit.AssignedMissionOrPackage() != null)
		{
			myUnit.AI.ClearMissionStateFlags();
		}
		myUnit.Latitude_old = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
		myUnit.Longitude_old = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		_DockingOpsCondition_0 = _DockingOpsCondition.LoadedAsCargo;
		this.set_AssignedHostUnit(PickNewAssignedHost: false, containerUnit);
	}

	public void UnloadFromCargo()
	{
		if (myUnit.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)myUnit;
			float conditionTimer = 14400f;
			if (aircraft.Loadout != null && aircraft.Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
			{
				conditionTimer = aircraft.Loadout.ReadyTime;
			}
			aircraft.Loadout = DBFunctions.GetReserveLoadoutForThisAircraft(ref aircraft.ParentScen, aircraft.DBID);
			aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
			aircraft.AirOps.ConditionTimer = conditionTimer;
			activeUnit_1 = null;
		}
		else if (activeUnit_0 != null)
		{
			if (!activeUnit_0.IsFixedFacility)
			{
				if (myUnit.IsBoat || myUnit.IsVehicle)
				{
					ActiveUnit_DockingOps dockingOps = activeUnit_0.DockingOps;
					ActiveUnit theBoat = myUnit;
					DockFacility bestFacility = null;
					if (dockingOps.CanHostThisBoat(theBoat, ref bestFacility))
					{
						activeUnit_1 = activeUnit_0;
					}
				}
			}
			else
			{
				activeUnit_1 = activeUnit_0;
			}
		}
		activeUnit_0 = null;
		_DockingOpsCondition_0 = _DockingOpsCondition.Underway;
		myUnit.ClearElevationAndAltitudeAGL();
	}

	public void PickupCargoFromSource(ActiveUnit theSource)
	{
		if (theSource.DockingOps.Condition == _DockingOpsCondition.LoadedAsCargo)
		{
			return;
		}
		List<CargoManifestItem> list = Cargo.GenerateCargoManifest(theSource);
		if (list.Count > 0)
		{
			List<Cargo> list2 = DetermineFeasibleCargoTransferManifest((ICargoHost)theSource, (ICargoHost)myUnit, list);
			if (list2.Count > 0)
			{
				PerformCargoTransferBetweenHostAndTarget(theSource, myUnit, list2);
			}
		}
		myUnit.AI.RemovePickupTarget(theSource.ObjectID);
	}

	internal bool CanUnloadCargoOverBeach()
	{
		if (!myUnit.IsSubmarine)
		{
			if (!myUnit.IsShip)
			{
				return true;
			}
			int result;
			switch (myUnit.SubType)
			{
			case 4004:
			case 4005:
			case 4006:
			case 4007:
			case 4008:
				result = 1;
				break;
			case 4020:
			case 4021:
			case 4022:
				result = 1;
				break;
			default:
				return ((Ship)myUnit).IsSmallCraft();
			case 4002:
			case 4018:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
		return ((ICargoHost)myUnit).GetCargo_Type() == CargoType.Personnel;
	}

	internal List<GeoPoint> FindPossiblePickupLocations(ActiveUnit TransportUnit, Module_Unit.Unit PickupUnit, float MaxDistance_nm = 2f)
	{
		_Closure$__100-0 arg = default(_Closure$__100-0);
		_Closure$__100-0 CS$<>8__locals7 = new _Closure$__100-0(arg);
		CS$<>8__locals7.$VB$Local_PickupUnit = PickupUnit;
		List<GeoPoint> list = new List<GeoPoint>();
		short num = 0;
		short num2 = short.MaxValue;
		if (TransportUnit != null && CS$<>8__locals7.$VB$Local_PickupUnit != null)
		{
			if (TransportUnit.IsShip)
			{
				num = short.MinValue;
				num2 = -3;
				if (TransportUnit.SubType == 4002)
				{
					num2 = 50;
				}
			}
			else if (TransportUnit.IsSubmarine)
			{
				num = (short)Math.Round(TransportUnit.Kinematics.GetMinimumAltitude());
				num2 = (short)Math.Round(((Submarine)TransportUnit).Draft);
			}
			int num4;
			int num3 = (num4 = (int)Math.Round(Module_Unit.BearingToUnit_True(CS$<>8__locals7.$VB$Local_PickupUnit, TransportUnit))) + 359;
			double out_lon = default(double);
			double out_lat = default(double);
			for (int i = num4; i <= num3; i++)
			{
				for (float num5 = MaxDistance_nm; num5 >= 0f; num5 += -0.1f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(CS$<>8__locals7.$VB$Local_PickupUnit.get_Longitude((GlobalVariables.BooleanObject)null), CS$<>8__locals7.$VB$Local_PickupUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num5, i % 360);
					short elevation = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, myUnit.ParentScen);
					if (elevation < num || elevation > num2)
					{
						break;
					}
					GeoPoint item = new GeoPoint(out_lon, out_lat, elevation);
					list.Add(item);
				}
			}
			if (list.Any())
			{
				list = list.OrderBy([SpecialName] (GeoPoint thepoint) => Math2.CalcDist(thepoint.Latitude, thepoint.Longitude, CS$<>8__locals7.$VB$Local_PickupUnit.get_Latitude((GlobalVariables.BooleanObject)null), CS$<>8__locals7.$VB$Local_PickupUnit.get_Longitude((GlobalVariables.BooleanObject)null))).ToList();
			}
		}
		return list;
	}

	internal List<GeoPoint> FindPossibleUnloadLocations(float MaxDistance_nm = 2f)
	{
		List<GeoPoint> list = new List<GeoPoint>();
		double out_lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
		double out_lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		short num = 1;
		short num2 = short.MaxValue;
		if (myUnit.IsShip || myUnit.IsSubmarine)
		{
			num = 0;
			num2 = 50;
		}
		short elevation = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, myUnit.ParentScen);
		if (elevation > num && elevation < num2)
		{
			GeoPoint item = new GeoPoint(out_lon, out_lat, elevation);
			list.Add(item);
			return list;
		}
		int num4;
		int num3 = (num4 = (int)Math.Round(myUnit.CurrentHeading)) + 359;
		for (int i = num4; i <= num3; i++)
		{
			for (float num5 = 0.1f; num5 <= MaxDistance_nm; num5 += 0.1f)
			{
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num5, i % 360);
				elevation = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, myUnit.ParentScen);
				if (elevation > num && elevation < num2)
				{
					GeoPoint item2 = new GeoPoint(out_lon, out_lat, elevation);
					list.Add(item2);
				}
			}
		}
		return list;
	}

	public void UnloadCargoOverBeach()
	{
		try
		{
			if (myUnit.OnboardCargo.Count() == 0 || myUnit is Group)
			{
				return;
			}
			float maxDistance_nm = 2f;
			if (myUnit.IsSubmarine)
			{
				maxDistance_nm = 5f;
			}
			List<GeoPoint> source = FindPossibleUnloadLocations(maxDistance_nm);
			if (source.Any())
			{
				GeoPoint geoPoint = source.OrderBy([SpecialName] (GeoPoint thepoint) => Math2.CalcDist(thepoint.Latitude, thepoint.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null))).ElementAtOrDefault(0);
				Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, geoPoint.Latitude, geoPoint.Longitude, myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
				myUnit.CargoTransferList = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101364", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<Geopoint_Struct> CargoUnloadLocationPointQuery(Geopoint_Struct OffshorePoint, CargoMission myMission)
	{
		bool flag = false;
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (myMission.DestinationUnit != null)
		{
			Geopoint_Struct item = new Geopoint_Struct(myMission.DestinationUnit.get_Longitude((GlobalVariables.BooleanObject)null), myMission.DestinationUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			list.Add(item);
			return list;
		}
		if ((myMission.Area_1nm_Buffered == null) ? GeoPoint.IsInsideThisArea(OffshorePoint.Latitude, OffshorePoint.Longitude, myMission.Area) : GeoPoint.IsInsideThisArea(OffshorePoint.Latitude, OffshorePoint.Longitude, myMission.Area_1nm_Buffered))
		{
			short num = 0;
			short num2 = -20;
			float num3 = 2f;
			if (myUnit.IsShip && myUnit.SubType == 4002)
			{
				num = 50;
				num2 = 0;
			}
			else if (myUnit.IsSubmarine)
			{
				num = (short)Math.Round(0f - ((Submarine)myUnit).Draft);
				num2 = -999;
				num3 = 5f;
			}
			short elevation = Terrain.GetElevation(OffshorePoint.Latitude, OffshorePoint.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
			if (elevation <= num && elevation > num2)
			{
				int num5;
				int num4 = (num5 = (int)Math.Round(myUnit.CurrentHeading)) + 359;
				for (int i = num5; i <= num4; i++)
				{
					float num6 = num3;
					for (float num7 = 0.1f; num7 <= num6; num7 += 0.1f)
					{
						Geopoint_Struct item2 = default(Geopoint_Struct);
						Geodesic_EdWilliams.CalcPoint_Williams(OffshorePoint.Longitude, OffshorePoint.Latitude, ref item2.Longitude, ref item2.Latitude, num7, i % 360);
						if (GeoPoint.IsInsideThisArea(item2.Latitude, item2.Longitude, myMission.Area))
						{
							short elevation2 = Terrain.GetElevation(item2.Latitude, item2.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
							if (elevation2 > 0 && elevation2 < 50)
							{
								list.Add(item2);
							}
						}
					}
				}
				return list;
			}
			return null;
		}
		return null;
	}

	public Geopoint_Struct FindCoastalUnloadPointForSeaVesselCargoDelivery(CargoMission theMission)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		if (theMission != null && theMission.MissionClass == Mission._MissionClass.Cargo && theMission.Area != null)
		{
			int num = 0;
			List<Geopoint_Struct> list = null;
			List<Geopoint_Struct> list2 = new List<Geopoint_Struct>();
			short num2 = 0;
			short num3 = -30;
			if (myUnit.IsShip && myUnit.SubType == 4002)
			{
				num2 = 50;
				num3 = 0;
			}
			else if (myUnit.IsSubmarine)
			{
				num2 = (short)Math.Round(0f - ((Submarine)myUnit).Draft);
				num3 = -999;
			}
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			int ReasonForInterrupt = default(int);
			Geopoint_Struct geopoint_Struct4 = default(Geopoint_Struct);
			while (true)
			{
				num++;
				if (num <= 1000)
				{
					geopoint_Struct = Math2.RandomPointWithinThisArea(theMission.Area);
					short elevation = Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
					if (elevation < 0)
					{
						continue;
					}
					GeoPoint InterruptLocation = new GeoPoint();
					if (myUnit.Navigator.PathLineIsInterrupted(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained, ref ReasonForInterrupt, ref InterruptLocation))
					{
						if ((ReasonForInterrupt & 3) == 0)
						{
							Geopoint_Struct geopoint_Struct2 = InterruptLocation.ToGeopoint_Struct();
							if (myUnit.IsSubmarine)
							{
								elevation = Terrain.GetElevation(geopoint_Struct2.Latitude, geopoint_Struct2.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
								if (elevation > num2)
								{
									Geopoint_Struct geopoint_Struct3 = geopoint_Struct;
									float num4 = 0.1f;
									double bearing = MathFunctions.GetBearing(geopoint_Struct2.Latitude, geopoint_Struct2.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
									int num5 = 1;
									do
									{
										ref double longitude = ref geopoint_Struct2.Longitude;
										ref double latitude = ref geopoint_Struct2.Latitude;
										ref double longitude2 = ref geopoint_Struct3.Longitude;
										ref double latitude2 = ref geopoint_Struct3.Latitude;
										float distance_NM = num4 * (float)num5;
										Geodesic_EdWilliams.CalcPoint_Williams(ref longitude, ref latitude, ref longitude2, ref latitude2, ref distance_NM, ref bearing);
										elevation = Terrain.GetElevation(geopoint_Struct3.Latitude, geopoint_Struct3.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
										if (elevation > num2)
										{
											num5++;
											continue;
										}
										geopoint_Struct2.Latitude = geopoint_Struct3.Latitude;
										geopoint_Struct2.Longitude = geopoint_Struct3.Longitude;
										break;
									}
									while (num5 <= 20);
								}
							}
							geopoint_Struct4 = geopoint_Struct2;
							list = CargoUnloadLocationPointQuery(geopoint_Struct4, theMission);
						}
					}
					else if (elevation >= num3 && elevation < num2)
					{
						geopoint_Struct4 = geopoint_Struct;
						list = CargoUnloadLocationPointQuery(geopoint_Struct4, theMission);
					}
					if (list != null && list.Any())
					{
						if (num <= 100)
						{
							ActiveUnit_Navigator navigator = myUnit.Navigator;
							double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							double latitude3 = geopoint_Struct4.Latitude;
							double longitude3 = geopoint_Struct4.Longitude;
							float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
							int ReasonForInterrupt2 = 0;
							GeoPoint InterruptLocation2 = null;
							if (navigator.PathLineIsInterrupted(startLat, startLon, latitude3, longitude3, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg, ref ReasonForInterrupt2, ref InterruptLocation2))
							{
								continue;
							}
						}
						list2.Add(geopoint_Struct4);
						if (list2.Count > 5)
						{
							break;
						}
					}
					else
					{
						list = null;
					}
					continue;
				}
				myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable unloading point inside cargo delivery area defined by Ref. Points", myUnit.Name + " unable to pick point", LoggedMessage.MessageType.DockingOps, 1, geopoint_Struct, ActiveUnit.NotificationType.Bark);
				return result;
			}
			return list2.OrderBy([SpecialName] (Geopoint_Struct thepoint) => Math2.CalcDist_Angular(thepoint.Latitude, thepoint.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null))).ThenBy([SpecialName] (Geopoint_Struct thePoint) => Terrain.GetElevation(thePoint.Latitude, thePoint.Longitude, RequestIsFromGUI: false, myUnit.ParentScen)).First();
		}
		return result;
	}

	internal float GetSafeMissionRange()
	{
		return myUnit.Kinematics.TacticalRadius() / 2f * 0.75f;
	}

	internal bool IsWithinRangeOfMission()
	{
		bool result = false;
		if (myUnit.ActiveMissionOrPackage() != null)
		{
			float safeMissionRange = GetSafeMissionRange();
			ActiveUnit activeUnit = this.get_AssignedHostUnit(PickNewAssignedHost: false);
			if (myUnit.IsAircraft)
			{
				activeUnit = ((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			}
			if (activeUnit == null)
			{
				activeUnit = myUnit;
			}
			if (myUnit.ActiveMissionOrPackage().get_AverageDistanceToMissionArea(myUnit, activeUnit) < safeMissionRange)
			{
				result = true;
			}
		}
		return result;
	}

	internal bool IsExpectingMoreCargo()
	{
		int result;
		if (myUnit.ActiveMissionOrPackage() != null)
		{
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
			{
				bool flag = false;
				List<ActiveUnit> list = new List<ActiveUnit>();
				ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
				if (currentHostUnitCargoSource != null)
				{
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
				}
				if (list.Count != 0)
				{
					CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
					foreach (ActiveUnit item in list)
					{
						List<CargoManifestItem> transferManifest = null;
						if (!cargoMission.MoveAllCargo)
						{
							transferManifest = cargoMission.CargoToUnload;
						}
						ICargoHost cargoHost = (ICargoHost)item;
						ICargoHost cargoHost2 = (ICargoHost)myUnit;
						if (cargoHost != null && cargoHost2 != null && DetermineFeasibleCargoTransferManifest(cargoHost, cargoHost2, transferManifest).Count > 0)
						{
							return true;
						}
					}
					foreach (Mission mission in myUnit.get_UnitSide(SetSideOnly: false).Missions)
					{
						if (mission == myUnit.ActiveMissionOrPackage())
						{
							continue;
						}
						if (mission.MissionClass == Mission._MissionClass.Cargo)
						{
							CargoMission cargoMission2 = (CargoMission)mission;
							if (cargoMission2.Type == CargoMission.CargoMissionType.Transfer)
							{
								int num;
								if (cargoMission2.MoveAllCargo)
								{
									num = 0;
								}
								else
								{
									if (cargoMission2.CargoToUnload.Count <= 0)
									{
										goto IL_0365;
									}
									num = 0;
								}
								bool flag2 = (byte)num != 0;
								if (cargoMission2.DestinationUnit == currentHostUnitCargoSource)
								{
									flag2 = true;
								}
								else if (currentHostUnitCargoSource.IsGroup)
								{
									foreach (ActiveUnit item2 in list)
									{
										if (cargoMission2.DestinationUnit == item2)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (flag2)
								{
									list.Clear();
									List<ActiveUnit> list2 = Module_Mission.UnitsAssignedToMissionOrPackage(cargoMission2, myUnit.ParentScen);
									foreach (ActiveUnit item3 in list2)
									{
										if (item3.HasCargo)
										{
											list.Add(item3);
										}
										ActiveUnit assignedHostUnitCargoSource = item3.AssignedHostUnitCargoSource;
										if (assignedHostUnitCargoSource == null)
										{
											continue;
										}
										if (!assignedHostUnitCargoSource.IsGroup)
										{
											if (!list.Contains(assignedHostUnitCargoSource))
											{
												list.Add(assignedHostUnitCargoSource);
											}
											continue;
										}
										foreach (ActiveUnit value in ((Group)assignedHostUnitCargoSource).Units.Values)
										{
											if (!list.Contains(value))
											{
												list.Add(value);
											}
										}
									}
									foreach (ActiveUnit item4 in list)
									{
										if (item4.HasCargo)
										{
											List<CargoManifestItem> transferManifest2 = null;
											if (!cargoMission2.MoveAllCargo)
											{
												transferManifest2 = cargoMission2.CargoToUnload;
											}
											ICargoHost cargoHost3 = (ICargoHost)item4;
											ICargoHost cargoHost4 = (ICargoHost)myUnit;
											if (cargoHost3 != null && cargoHost4 != null && DetermineFeasibleCargoTransferManifest(cargoHost3, cargoHost4, transferManifest2).Count > 0)
											{
												flag = true;
												break;
											}
										}
									}
								}
							}
						}
						goto IL_0365;
						IL_0365:
						if (!flag)
						{
							continue;
						}
						break;
					}
					return flag;
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal bool IsAtCargoDestination()
	{
		int result;
		if (myUnit.ActiveMissionOrPackage() == null)
		{
			result = 0;
			goto IL_00f0;
		}
		if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
		{
			CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
			if (cargoMission.DestinationUnit != null)
			{
				ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
				if (currentHostUnitCargoSource == null)
				{
					return false;
				}
				if (cargoMission.DestinationUnit == currentHostUnitCargoSource)
				{
					return true;
				}
				if (!cargoMission.DestinationUnit.IsGroup && !currentHostUnitCargoSource.IsGroup)
				{
					if (!cargoMission.DestinationUnit.IsGroupMember())
					{
						result = 0;
					}
					else
					{
						if (currentHostUnitCargoSource.IsGroupMember())
						{
							if (cargoMission.DestinationUnit.get_ParentGroup(UsingMissionPlanner: false) == currentHostUnitCargoSource.get_ParentGroup(UsingMissionPlanner: false))
							{
								return true;
							}
							goto IL_00ef;
						}
						result = 0;
					}
					goto IL_00f0;
				}
				if (cargoMission.DestinationUnit.IsGroup && currentHostUnitCargoSource.get_ParentGroup(UsingMissionPlanner: false) == cargoMission.DestinationUnit)
				{
					return true;
				}
				if (currentHostUnitCargoSource.IsGroup && cargoMission.DestinationUnit.get_ParentGroup(UsingMissionPlanner: false) == currentHostUnitCargoSource)
				{
					return true;
				}
			}
		}
		goto IL_00ef;
		IL_00ef:
		result = 0;
		goto IL_00f0;
		IL_00f0:
		return (byte)result != 0;
	}

	internal bool HasEnoughCargoLoadToLaunch()
	{
		if (myUnit.IsVehicle && ((Vehicle)myUnit).AI.IsPerformingCargoSelfTransport())
		{
			return true;
		}
		int result;
		if (myUnit.OnboardCargo.Count() <= 0)
		{
			result = 0;
		}
		else
		{
			if (CargoHostHelper.GetPercentFull((ICargoHost)myUnit) >= 80)
			{
				return true;
			}
			if (!IsExpectingMoreCargo())
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_0()
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null || !myUnit.ActiveMissionOrPackage().IsActive)
			{
				return;
			}
			bool flag = true;
			if (!(myUnit.ActiveMissionOrPackage() is CargoMission))
			{
				if (!myUnit.IsVehicle)
				{
					return;
				}
			}
			else
			{
				if (((ICargoHost)myUnit).GetCargo_Type() == CargoType.NoCargo)
				{
					return;
				}
				flag = false;
				if (!HasEnoughCargoLoadToLaunch())
				{
					if (IsAtCargoDestination())
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (IsWithinRangeOfMission())
				{
					myUnit.DockingOps.Condition = _DockingOpsCondition.DeployingUnderway;
				}
			}
			else
			{
				if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Cargo)
				{
					return;
				}
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
				lock (CargoOpsLockObj)
				{
					CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
					foreach (ActiveUnit item in list)
					{
						List<Cargo> list2 = DetermineFeasibleCargoTransferManifest(TransferManifest: cargoMission.MoveAllCargo ? null : cargoMission.CargoToUnload, TransferSource: (ICargoHost)item, TransferDestination: (ICargoHost)myUnit, DoNotLoadUnit: item);
						if (list2.Count <= 0)
						{
							continue;
						}
						PerformCargoTransferBetweenHostAndTarget(item, myUnit, list2);
						Condition = _DockingOpsCondition.Readying;
						if (!cargoMission.InstantLoadingForNextManifest)
						{
							ConditionTimer = Math.Max(ConditionTimer, TimeToLoadCargo(myUnit, list2));
						}
						else
						{
							cargoMission.InstantLoadingForNextManifest = false;
							ConditionTimer = Math.Max(ConditionTimer, 0f);
						}
						foreach (Cargo item2 in list2)
						{
							CargoManifestItem.Remove(item2, cargoMission.CargoToUnload);
						}
					}
					return;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101365", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<Cargo> DetermineFeasibleCargoTransferManifest(ICargoHost TransferSource, ICargoHost TransferDestination, List<CargoManifestItem> TransferManifest, ActiveUnit DoNotLoadUnit = null)
	{
		_Closure$__113-0 arg = default(_Closure$__113-0);
		_Closure$__113-0 CS$<>8__locals4 = new _Closure$__113-0(arg);
		List<Cargo> list = new List<Cargo>();
		List<CargoManifestItem> list2 = null;
		if (TransferManifest != null)
		{
			list2 = new List<CargoManifestItem>();
			foreach (CargoManifestItem item3 in TransferManifest)
			{
				CargoManifestItem item = new CargoManifestItem(item3);
				list2.Add(item);
			}
		}
		double num = TransferDestination.GetCargo_Mass();
		double num2 = TransferDestination.GetCargo_Area();
		double num3 = TransferDestination.GetCargo_Crew();
		Cargo[] onboardCargo = ((ActiveUnit)TransferDestination).OnboardCargo;
		foreach (Cargo cargo in onboardCargo)
		{
			num -= (double)cargo.RequiredMass;
			num2 -= (double)cargo.RequiredArea;
			num3 -= (double)cargo.RequiredCrewSpace;
		}
		if (TransferSource != DoNotLoadUnit && TransferSource is ICargoClient)
		{
			ICargoClient cargoClient = (ICargoClient)TransferSource;
			if (cargoClient != null && cargoClient.GetRequiredCargoType() != CargoType.NoCargo)
			{
				if (TransferSource is Vehicle)
				{
					Cargo cargo2 = null;
					if (!TransferDestination.CanLoad(cargoClient))
					{
						if (TransferDestination.CanTow(cargoClient))
						{
							cargo2 = new Cargo(null, (Vehicle)TransferSource);
							cargo2.StorageType = Cargo.CargoStorageType.TowedExternal;
						}
					}
					else
					{
						cargo2 = new Cargo(null, (Vehicle)TransferSource);
					}
					if (cargo2 != null)
					{
						list.Add(cargo2);
						return list;
					}
				}
				else if (TransferSource is Facility && TransferDestination.CanLoad(cargoClient))
				{
					Cargo item2 = new Cargo(null, (Facility)TransferSource);
					list.Add(item2);
					return list;
				}
			}
		}
		CS$<>8__locals4.$VB$Local_GroupDictionary = new Dictionary<string, int>();
		int num4 = 0;
		Cargo[] onboardCargo2 = ((ActiveUnit)TransferSource).OnboardCargo;
		for (int j = 0; j < onboardCargo2.Length; j = checked(j + 1))
		{
			ActiveUnit cargoObjectActiveUnit = onboardCargo2[j].CargoObjectActiveUnit;
			if (cargoObjectActiveUnit != null && cargoObjectActiveUnit.get_ParentGroup(UsingMissionPlanner: false) != null && !Enumerable.Contains(CS$<>8__locals4.$VB$Local_GroupDictionary.Keys, cargoObjectActiveUnit.get_ParentGroup(UsingMissionPlanner: false).ObjectID))
			{
				CS$<>8__locals4.$VB$Local_GroupDictionary.Add(cargoObjectActiveUnit.get_ParentGroup(UsingMissionPlanner: false).ObjectID, 2 * num4);
				num4++;
			}
		}
		bool flag = true;
		foreach (Cargo item4 in ((ActiveUnit)TransferSource).OnboardCargo.OrderBy([SpecialName] (Cargo s) =>
		{
			ActiveUnit cargoObjectActiveUnit2 = s.CargoObjectActiveUnit;
			int result;
			if (cargoObjectActiveUnit2 != null)
			{
				if (cargoObjectActiveUnit2.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					result = int.MaxValue;
					goto IL_004c;
				}
				if (CS$<>8__locals4.$VB$Local_GroupDictionary.TryGetValue(cargoObjectActiveUnit2.get_ParentGroup(UsingMissionPlanner: false).ObjectID, out var value))
				{
					if (!cargoObjectActiveUnit2.IsGroupLead())
					{
						return value + 1;
					}
					return value;
				}
			}
			result = int.MaxValue;
			goto IL_004c;
			IL_004c:
			return result;
		}))
		{
			if (item4.RequiredCargoType > TransferDestination.GetCargo_Type())
			{
				continue;
			}
			int num5;
			if (item4.CargoObjectActiveUnit != null && item4.CargoObjectActiveUnit.IsVehicle)
			{
				if (((Vehicle)item4.CargoObjectActiveUnit).AI.IsPerformingCargoSelfTransport())
				{
					continue;
				}
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			bool flag2 = (byte)num5 != 0;
			int num6 = 0;
			if (list2 != null)
			{
				CargoManifestItem cargoManifestItem = CargoManifestItem.FindMatch(item4, list2);
				if (cargoManifestItem != null)
				{
					flag2 = true;
					num6 = cargoManifestItem.quantity;
				}
			}
			else
			{
				flag2 = true;
				num6 = 1;
			}
			if (flag2 && num6 >= 1)
			{
				if (num >= (double)item4.RequiredMass && num2 >= (double)item4.RequiredArea && num3 >= (double)item4.RequiredCrewSpace)
				{
					list.Add(item4);
					CargoManifestItem.Remove(item4, list2);
					num -= (double)item4.RequiredMass;
					num2 -= (double)item4.RequiredArea;
					num3 -= (double)item4.RequiredCrewSpace;
				}
				else if (flag && TransferDestination.CanTow(item4.GetCargoClient))
				{
					flag = false;
					list.Add(item4);
					CargoManifestItem.Remove(item4, list2);
					Cargo.CargoStorageType storageType = item4.StorageType;
					item4.StorageType = Cargo.CargoStorageType.TowedExternal;
					num -= (double)item4.RequiredMass;
					num2 -= (double)item4.RequiredArea;
					num3 -= (double)item4.RequiredCrewSpace;
					item4.StorageType = storageType;
				}
			}
		}
		ActiveUnit activeUnit = (ActiveUnit)TransferSource;
		if (activeUnit.IsMobileGroundUnit && Module_ActiveUnit.IsAimpointFacility(activeUnit))
		{
			foreach (Mount mount in activeUnit.Mounts)
			{
				if (mount.Cargo_Type != CargoType.NoCargo && mount.Cargo_Type <= TransferDestination.GetCargo_Type())
				{
					Cargo cargo3 = new Cargo(activeUnit, mount);
					CargoManifestItem cargoManifestItem2 = CargoManifestItem.FindMatch(cargo3, list2);
					if (cargoManifestItem2 != null && cargoManifestItem2.quantity >= 1 && num >= (double)cargo3.RequiredMass && num2 >= (double)cargo3.RequiredArea && num3 >= (double)cargo3.RequiredCrewSpace)
					{
						list.Add(cargo3);
						CargoManifestItem.Remove(cargo3, list2);
						num -= (double)cargo3.RequiredMass;
						num2 -= (double)cargo3.RequiredArea;
						num3 -= (double)cargo3.RequiredCrewSpace;
					}
				}
			}
		}
		return list;
	}

	public bool SettleForCargoMissionTransfer(ActiveUnit OtherUnit)
	{
		bool result;
		try
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			Condition = _DockingOpsCondition.TransferringMissionCargo;
			ConditionTimer = 0f;
			if (!myUnit.IsVehicle)
			{
				goto IL_01d6;
			}
			int num;
			if (myUnit.OnboardCargo.Count() != 0)
			{
				if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
					ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
					PerformCargoTransferBetweenHostAndTarget(myUnit, OtherUnit, myUnit.OnboardCargo.ToList(), cargoMission.UnpackAllContainers);
					num = 1;
				}
				else
				{
					ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
					PerformCargoTransferBetweenHostAndTarget(myUnit, OtherUnit, myUnit.OnboardCargo.ToList());
					num = 1;
				}
			}
			else
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					goto IL_01d6;
				}
				CargoMission cargoMission2 = (CargoMission)myUnit.ActiveMissionOrPackage();
				List<CargoManifestItem> transferManifest = null;
				if (!cargoMission2.MoveAllCargo)
				{
					transferManifest = cargoMission2.CargoToUnload;
				}
				List<Cargo> list = DetermineFeasibleCargoTransferManifest((ICargoHost)OtherUnit, (ICargoHost)myUnit, transferManifest, OtherUnit);
				if (list.Count <= 0)
				{
					Condition = _DockingOpsCondition.Underway;
					ConditionTimer = 300f;
					num = 1;
				}
				else
				{
					ConditionTimer = Math.Max(240, TimeToLoadCargo(myUnit, list));
					PerformCargoTransferBetweenHostAndTarget(OtherUnit, myUnit, list);
					num = 1;
				}
			}
			goto IL_01d7;
			IL_01d6:
			num = 1;
			goto IL_01d7;
			IL_01d7:
			result = (byte)num != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1034205823409586290485912038412A", "");
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

	public bool SettleForCargoTransfer()
	{
		bool result;
		try
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			Condition = _DockingOpsCondition.TransferringCargo;
			int num;
			if (!myUnit.IsShip && !myUnit.IsVehicle && !myUnit.IsSubmarine)
			{
				ConditionTimer = 0f;
				num = 1;
			}
			else
			{
				ConditionTimer = Math.Max(240, TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
				num = 1;
			}
			result = (byte)num != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1034205823409586290485912038412", "");
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

	public void DoDockingOps(float elapsedTime)
	{
		try
		{
			method_3(elapsedTime);
			method_11(elapsedTime);
			method_6();
			ConditionTimer -= elapsedTime;
			if (ConditionTimer < 0f)
			{
				ConditionTimer = 0f;
			}
			if (ConditionTimer != 0f)
			{
				return;
			}
			switch (Condition)
			{
			case _DockingOpsCondition.Docked:
				method_0();
				break;
			case _DockingOpsCondition.DeployingUnderway:
				method_16(elapsedTime);
				break;
			case _DockingOpsCondition.Docking:
				method_17();
				break;
			case _DockingOpsCondition.Readying:
				Condition = _DockingOpsCondition.Docked;
				break;
			case _DockingOpsCondition.ManoeuveringToRefuel:
				AttemptToConnectToTanker();
				break;
			case _DockingOpsCondition.ProvidingUNREP:
				method_5(elapsedTime);
				method_13(elapsedTime);
				method_2();
				if (!IsCurrentlyProvidingUNREP)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					Condition = _DockingOpsCondition.Underway;
					if (myUnit.IsMobileGroundUnit)
					{
						myUnit.Kinematics.DesiredSpeedOverride = null;
						myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					}
				}
				break;
			case _DockingOpsCondition.TransferringCargo:
				if (!myUnit.IsShip)
				{
					if (!myUnit.IsVehicle)
					{
						if (myUnit.IsFixedFacility)
						{
							if (myUnit.AI.PrimaryPickupTarget != null)
							{
								if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
								{
									if (myUnit.RangeToUnit_Horiz(myUnit.AI.PrimaryPickupTarget) < 2f)
									{
										PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
									}
									else
									{
										myUnit.AddMessage(myUnit.Name + " is too far (> 2nm) from cargo pick up target " + myUnit.AI.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
										myUnit.AI.RemovePickupTarget(myUnit.AI.PrimaryPickupTarget.ObjectID);
									}
								}
							}
							else
							{
								Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
							}
						}
						else if (myUnit.IsSubmarine)
						{
							if (myUnit.AI.PrimaryPickupTarget == null)
							{
								UnloadCargoOverBeach();
							}
							else if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
							{
								PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
							}
						}
					}
					else if (myUnit.AI.PrimaryPickupTarget == null)
					{
						UnloadCargoOverBeach();
					}
					else if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
					{
						PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
					}
				}
				else if (myUnit.AI.PrimaryPickupTarget != null)
				{
					if (myUnit.AI.PrimaryPickupTarget.IsActiveUnit)
					{
						PickupCargoFromSource(myUnit.AI.PrimaryPickupTarget);
					}
				}
				else if (CanUnloadCargoOverBeach())
				{
					UnloadCargoOverBeach();
				}
				myUnit.CargoTransferList = null;
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _DockingOpsCondition.Underway;
				ConditionTimer = 0f;
				break;
			case _DockingOpsCondition.TransferringMissionCargo:
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _DockingOpsCondition.Underway;
				ConditionTimer = 0f;
				break;
			case _DockingOpsCondition.DeployingDippingSonar:
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned && !myUnit.Navigator.HasPlottedCourse() && myUnit.AI.PrimaryTarget == null)
				{
					byte? b = (byte?)myUnit.Doctrine.get_DippingSonar(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
					{
						ConditionTimer = 120f;
						break;
					}
				}
				if (myUnit.IsRTB)
				{
					Condition = _DockingOpsCondition.RTB;
				}
				else
				{
					Condition = _DockingOpsCondition.Underway;
				}
				break;
			case _DockingOpsCondition.RTB:
			case _DockingOpsCondition.Replenishing:
			case _DockingOpsCondition.RechargingBatteries:
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.LoadedAsCargo:
			case _DockingOpsCondition.HoldingPattern_CommsLost:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100143", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				list.Add(activeUnits_);
			}
		}
		foreach (ActiveUnit item in list)
		{
			if (myUnit.RangeToUnit_Horiz(item) > UNREP_Connect_ThresholdRange * 2f)
			{
				item.DockingOps.DisconnectFromSupplier();
			}
			else if (this.get_FuelWeCanSupplyToThisUnit(item, 0f) <= 0 && !CanWeSupplyMaterialToThisUnit(item))
			{
				item.DockingOps.DisconnectFromSupplier();
			}
		}
	}

	private void method_2()
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			try
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					ActiveUnit activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID];
					if (myUnit.RangeToUnit_Horiz(activeUnit) > UNREP_Connect_ThresholdRange * 2f)
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
					else if (this.get_FuelWeCanSupplyToThisUnit(activeUnit, 0f) <= 0 && !CanWeSupplyMaterialToThisUnit(activeUnit))
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					ActiveUnit activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID];
					if (myUnit.RangeToUnit_Horiz(activeUnit) > UNREP_Connect_ThresholdRange * 2f)
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
					else if (this.get_FuelWeCanSupplyToThisUnit(activeUnit, 0f) <= 0 && !CanWeSupplyMaterialToThisUnit(activeUnit))
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					ActiveUnit activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID];
					if (myUnit.RangeToUnit_Horiz(activeUnit) > UNREP_Connect_ThresholdRange * 2f)
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
					else if (this.get_FuelWeCanSupplyToThisUnit(activeUnit, 0f) <= 0 && !CanWeSupplyMaterialToThisUnit(activeUnit))
					{
						activeUnit.DockingOps.DisconnectFromSupplier();
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100144", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		method_1();
	}

	public void DisconnectFromSupplier_Facility()
	{
		if (UNREP_Destination != null && UNREP_Destination.DockingOps.UNREP_Queue.Contains(myUnit.ObjectID))
		{
			UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
		}
		UNREP_Destination = null;
		myUnit.Kinematics.DesiredSpeedOverride = null;
		myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
		Condition = _DockingOpsCondition.Underway;
	}

	public void DisconnectFromSupplier()
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			try
			{
				if (UNREP_Destination != null)
				{
					ActiveUnit uNREP_Destination = UNREP_Destination;
					if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID, myUnit.ObjectID, false) != 0)
					{
						if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID, myUnit.ObjectID, false) == 0)
						{
							UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID = null;
							UNREP_Destination = null;
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							Condition = _DockingOpsCondition.Underway;
						}
						else if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID, myUnit.ObjectID, false) == 0)
						{
							UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID = null;
							UNREP_Destination = null;
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							Condition = _DockingOpsCondition.Underway;
						}
						else if (uNREP_Destination != null && uNREP_Destination.DockingOps.UNREP_Queue.Contains(myUnit.ObjectID))
						{
							uNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						}
					}
					else
					{
						UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID = null;
						UNREP_Destination = null;
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						Condition = _DockingOpsCondition.Underway;
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100145", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		DisconnectFromSupplier_Facility();
	}

	private void method_3(float float_1)
	{
		try
		{
			float num = 63.33f;
			PooledList<ActiveUnit> embarkedBoats_ReadOnly = EmbarkedBoats_ReadOnly;
			if (embarkedBoats_ReadOnly == null)
			{
				return;
			}
			int num2 = default(int);
			_Closure$__121-0 closure$__121- = default(_Closure$__121-0);
			foreach (ActiveUnit item in embarkedBoats_ReadOnly)
			{
				_DockingOpsCondition condition = item.DockingOps.Condition;
				if (condition != _DockingOpsCondition.Docked && condition != _DockingOpsCondition.Readying)
				{
					continue;
				}
				switch (item.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					num2 = 1;
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					num2 = 2;
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num2 = 3;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					num2 = 4;
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					num2 = 5;
					break;
				}
				float val = num * (float)num2 * float_1;
				using IEnumerator<FuelRec> enumerator2 = item.Fuel_ReadOnly.Where([SpecialName] (FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					closure$__121- = new _Closure$__121-0(closure$__121-);
					closure$__121-.$VB$Local_theFR = enumerator2.Current;
					if (closure$__121-.$VB$Local_theFR.FuelType == FuelRec._FuelType.Battery)
					{
						closure$__121-.$VB$Local_theFR.CurrentQuantity = closure$__121-.$VB$Local_theFR.MaxQuantity;
						continue;
					}
					FuelRec fuelRec = (myUnit.IsFixedFacility ? new FuelRec(int.MaxValue, (short)closure$__121-.$VB$Local_theFR.FuelType) : myUnit.Fuel_ReadOnly.Where(closure$__121-._Lambda$__1).DefaultIfEmpty(null).FirstOrDefault());
					if (fuelRec != null)
					{
						float num3 = (float)closure$__121-.$VB$Local_theFR.MaxQuantity - closure$__121-.$VB$Local_theFR.CurrentQuantity;
						float num4 = Math.Min(val, fuelRec.CurrentQuantity);
						if (num3 < num4)
						{
							item.Fuel_Add(num3, fuelRec.FuelType);
							fuelRec.CurrentQuantity -= num3;
						}
						else
						{
							item.Fuel_Add(num4, fuelRec.FuelType);
							fuelRec.CurrentQuantity -= num4;
						}
					}
				}
			}
			embarkedBoats_ReadOnly.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101366", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(float float_1)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				list.Add(activeUnits_);
			}
		}
		float num = 0.5f / (float)list.Count;
		_Closure$__122-0 closure$__122- = default(_Closure$__122-0);
		foreach (ActiveUnit item in list)
		{
			float val = num * float_1;
			using IEnumerator<FuelRec> enumerator3 = item.Fuel_ReadOnly.Where([SpecialName] (FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity).GetEnumerator();
			while (enumerator3.MoveNext())
			{
				closure$__122- = new _Closure$__122-0(closure$__122-);
				closure$__122-.$VB$Local_theFR = enumerator3.Current;
				FuelRec fuelRec = myUnit.Fuel_ReadOnly.Where(closure$__122-._Lambda$__1).DefaultIfEmpty(null).FirstOrDefault();
				if (!Information.IsNothing((object)fuelRec))
				{
					float num2 = (float)closure$__122-.$VB$Local_theFR.MaxQuantity - closure$__122-.$VB$Local_theFR.CurrentQuantity;
					float num3 = Math.Min(val, fuelRec.CurrentQuantity);
					if (num2 < num3)
					{
						item.Fuel_Add(num2, fuelRec.FuelType);
						fuelRec.CurrentQuantity -= num2;
					}
					else
					{
						item.Fuel_Add(num3, fuelRec.FuelType);
						fuelRec.CurrentQuantity -= num3;
					}
				}
			}
		}
	}

	private void method_5(float float_1)
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			float num = 63.33f;
			try
			{
				ActiveUnit activeUnit;
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID];
					byte refuel_Port_Out = myUnit.UNREP_Capabilities.Refuel_Port_Out;
					float val = num * (float)(int)refuel_Port_Out * float_1;
					using IEnumerator<FuelRec> enumerator = activeUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity).GetEnumerator();
					_Closure$__123-0 closure$__123- = default(_Closure$__123-0);
					while (enumerator.MoveNext())
					{
						closure$__123- = new _Closure$__123-0(closure$__123-);
						closure$__123-.$VB$Local_theFR = enumerator.Current;
						FuelRec fuelRec = myUnit.Fuel_ReadOnly.Where(closure$__123-._Lambda$__1).DefaultIfEmpty(null).FirstOrDefault();
						if (!Information.IsNothing((object)fuelRec))
						{
							float num2 = (float)closure$__123-.$VB$Local_theFR.MaxQuantity - closure$__123-.$VB$Local_theFR.CurrentQuantity;
							float num3 = Math.Min(val, fuelRec.CurrentQuantity);
							if (num2 >= num3)
							{
								activeUnit.Fuel_Add(num3, fuelRec.FuelType);
								fuelRec.CurrentQuantity -= num3;
							}
							else
							{
								activeUnit.Fuel_Add(num2, fuelRec.FuelType);
								fuelRec.CurrentQuantity -= num2;
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID];
					byte refuel_Starboard_Out = myUnit.UNREP_Capabilities.Refuel_Starboard_Out;
					float val2 = num * (float)(int)refuel_Starboard_Out * float_1;
					using IEnumerator<FuelRec> enumerator2 = activeUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity).GetEnumerator();
					_Closure$__123-1 closure$__123-2 = default(_Closure$__123-1);
					while (enumerator2.MoveNext())
					{
						closure$__123-2 = new _Closure$__123-1(closure$__123-2);
						closure$__123-2.$VB$Local_theFR = enumerator2.Current;
						FuelRec fuelRec2 = myUnit.Fuel_ReadOnly.Where(closure$__123-2._Lambda$__3).DefaultIfEmpty(null).FirstOrDefault();
						if (!Information.IsNothing((object)fuelRec2))
						{
							float num4 = (float)closure$__123-2.$VB$Local_theFR.MaxQuantity - closure$__123-2.$VB$Local_theFR.CurrentQuantity;
							float num5 = Math.Min(val2, fuelRec2.CurrentQuantity);
							if (num4 >= num5)
							{
								activeUnit.Fuel_Add(num5, fuelRec2.FuelType);
								fuelRec2.CurrentQuantity -= num5;
							}
							else
							{
								activeUnit.Fuel_Add(num4, fuelRec2.FuelType);
								fuelRec2.CurrentQuantity -= num4;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					return;
				}
				activeUnit = myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID];
				byte refuel_Astern_Out = myUnit.UNREP_Capabilities.Refuel_Astern_Out;
				float val3 = num * (float)(int)refuel_Astern_Out * float_1;
				using IEnumerator<FuelRec> enumerator3 = activeUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theF) => theF.CurrentQuantity < (float)theF.MaxQuantity).GetEnumerator();
				_Closure$__123-2 closure$__123-3 = default(_Closure$__123-2);
				while (enumerator3.MoveNext())
				{
					closure$__123-3 = new _Closure$__123-2(closure$__123-3);
					closure$__123-3.$VB$Local_theFR = enumerator3.Current;
					FuelRec fuelRec3 = myUnit.Fuel_ReadOnly.Where(closure$__123-3._Lambda$__5).DefaultIfEmpty(null).FirstOrDefault();
					if (!Information.IsNothing((object)fuelRec3))
					{
						float num6 = (float)closure$__123-3.$VB$Local_theFR.MaxQuantity - closure$__123-3.$VB$Local_theFR.CurrentQuantity;
						float num7 = Math.Min(val3, fuelRec3.CurrentQuantity);
						if (num6 >= num7)
						{
							activeUnit.Fuel_Add(num7, fuelRec3.FuelType);
							fuelRec3.CurrentQuantity -= num7;
						}
						else
						{
							activeUnit.Fuel_Add(num6, fuelRec3.FuelType);
							fuelRec3.CurrentQuantity -= num6;
						}
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100146", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		method_4(float_1);
	}

	private void method_6()
	{
		if (!myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
		{
			return;
		}
		foreach (ActiveUnit item in EmbarkedBoats_ReadOnly)
		{
			item.Damage.PerformComponentRepairs(myUnit.Proficiency.Value);
			item.Damage.PerformStructuralRepairs(myUnit.Proficiency.Value);
		}
	}

	private bool method_7(float float_1)
	{
		int result;
		if (float_1 <= 10f)
		{
			if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				return true;
			}
			result = 0;
		}
		else if (float_1 <= 50f)
		{
			if (myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
			{
				return true;
			}
			result = 0;
		}
		else
		{
			if (float_1 <= 100f)
			{
				if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
				{
					return true;
				}
			}
			else if (float_1 <= 150f)
			{
				if (myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
				{
					return true;
				}
			}
			else if (float_1 <= 250f)
			{
				if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
				{
					return true;
				}
			}
			else if (float_1 <= 500f)
			{
				if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
				{
					return true;
				}
			}
			else if (float_1 <= 1000f)
			{
				if (myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
				{
					return true;
				}
			}
			else
			{
				if (float_1 <= 2500f)
				{
					if (!myUnit.ParentScen.ThirtiethMinuteIsChangingOnThisPulse)
					{
						result = 0;
						goto IL_012a;
					}
					return true;
				}
				if (myUnit.ParentScen.HourIsChangingOnThisPulse)
				{
					return true;
				}
			}
			result = 0;
		}
		goto IL_012a;
		IL_012a:
		return (byte)result != 0;
	}

	private bool method_8(Weapon weapon_0)
	{
		bool result;
		try
		{
			int num;
			if (weapon_0.MaxWeight <= 0)
			{
				switch (weapon_0.Type)
				{
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.Gun:
					switch (weapon_0.Warheads[0].Caliber)
					{
					case Warhead.WarheadCaliber.Gun_6_15mm:
					case Warhead.WarheadCaliber.Rocket_6_15mm:
						goto IL_0113;
					case Warhead.WarheadCaliber.Gun_16_24mm:
					case Warhead.WarheadCaliber.Rocket_16_24mm:
						goto IL_0132;
					case Warhead.WarheadCaliber.Gun_25_60mm:
					case Warhead.WarheadCaliber.Rocket_25_60mm:
						goto IL_0151;
					case Warhead.WarheadCaliber.Gun_61_80mm:
					case Warhead.WarheadCaliber.Rocket_61_80mm:
						goto IL_0170;
					case Warhead.WarheadCaliber.Gun_81_150mm:
					case Warhead.WarheadCaliber.Rocket_81_150mm:
						goto IL_018c;
					case Warhead.WarheadCaliber.Gun_151_200mm:
					case Warhead.WarheadCaliber.Rocket_151_200mm:
						goto IL_01a8;
					case Warhead.WarheadCaliber.Gun_201_350mm:
					case Warhead.WarheadCaliber.Rocket_201_350mm:
						goto IL_01c7;
					case Warhead.WarheadCaliber.Gun_351_450mm:
					case Warhead.WarheadCaliber.Rocket_351_450mm:
						goto IL_01e6;
					}
					if (method_7(weapon_0.MaxWeight))
					{
						result = true;
					}
					else
					{
						if (!myUnit.ParentScen.HourIsChangingOnThisPulse)
						{
							num = 0;
							break;
						}
						result = true;
					}
					goto end_IL_0001;
				case Weapon._WeaponType.Decoy_Expendable:
				case Weapon._WeaponType.Decoy_Vehicle:
				case Weapon._WeaponType.UAV_Expendable:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
				case Weapon._WeaponType.Dispenser:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.Microwave:
				case Weapon._WeaponType.LaserDazzler:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
				case Weapon._WeaponType.DepthCharge:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
				default:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.MooredMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
				case Weapon._WeaponType.DropTank:
					{
						if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
						{
							goto IL_0300;
						}
						result = true;
						goto end_IL_0001;
					}
					IL_01e6:
					if (!myUnit.ParentScen.ThirtiethMinuteIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_0151:
					if (!myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_0300:
					num = 0;
					break;
					IL_01c7:
					if (!myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_018c:
					if (!myUnit.ParentScen.MinuteIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
					IL_0132:
					if (!myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_01a8:
					if (!myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_0113:
					if (!myUnit.ParentScen.SecondIsChangingOnThisPulse)
					{
						num = 0;
						break;
					}
					result = true;
					goto end_IL_0001;
					IL_0170:
					if (!myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
					{
						goto IL_0300;
					}
					result = true;
					goto end_IL_0001;
				}
				goto IL_0301;
			}
			if (!method_7(weapon_0.MaxWeight))
			{
				num = 0;
				goto IL_0301;
			}
			result = true;
			goto end_IL_0001;
			IL_0301:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101367", "");
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

	private void method_9(ActiveUnit activeUnit_3)
	{
		if (!CanWeSupplyMaterialToThisUnit(activeUnit_3))
		{
			return;
		}
		PooledDictionary<int, Weapon> pooledDictionary = activeUnit_3.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
		int num = 1;
		foreach (int key in pooledDictionary.Keys)
		{
			if (num == 0)
			{
				break;
			}
			Weapon weapon_ = myUnit.ParentScen.Cache_GetWeapon(key);
			if (activeUnit_3.Weaponry.TotalDefaultCapacityForThisWeapon(key) - activeUnit_3.Weaponry.TotalAvailableInventoryForThisWeapon(key, IncludeNonOperationalMountsAndMags: false) == 0 || !method_8(weapon_) || Operators.CompareString(activeUnit_3.Weaponry.CanAddWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) != 0)
			{
				continue;
			}
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation) ? myUnit.SharedMagazines : myUnit.get_ParentGroup(UsingMissionPlanner: false).SharedMagazines);
				Magazine[] array2 = array;
				foreach (Magazine magazine in array2)
				{
					foreach (WeaponRec weapon in magazine.Weapons)
					{
						if (weapon.CurrentLoad > 0 && weapon.int_3 == key && Operators.CompareString(activeUnit_3.Weaponry.AddWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) == 0)
						{
							weapon.CurrentLoad--;
							weapon.ResetTimeToFire();
							num--;
							if (num == 0)
							{
								break;
							}
						}
					}
				}
			}
			else if (Operators.CompareString(activeUnit_3.Weaponry.AddWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) == 0)
			{
				num--;
			}
		}
		pooledDictionary.Dispose();
	}

	private void method_10(ActiveUnit activeUnit_3)
	{
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (!CanWeSupplyMaterialToThisUnit(activeUnit_3))
				{
					return;
				}
				PooledDictionary<int, Weapon> pooledDictionary = activeUnit_3.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
				int num = 1;
				if ((myUnit.UNREP_Capabilities.Refuel_Port_In == 4) | (myUnit.UNREP_Capabilities.Refuel_Starboard_In == 4))
				{
					num *= 4;
				}
				else if ((myUnit.UNREP_Capabilities.Refuel_Port_In == 3) | (myUnit.UNREP_Capabilities.Refuel_Starboard_In == 3))
				{
					num *= 3;
				}
				else if ((myUnit.UNREP_Capabilities.Refuel_Port_In == 2) | (myUnit.UNREP_Capabilities.Refuel_Starboard_In == 2))
				{
					num *= 2;
				}
				if (myUnit.IsFacility)
				{
					num *= 2;
				}
				if (activeUnit_3.IsSubmarine)
				{
					num = Math.Max(1, (int)Math.Round((double)num / 2.0));
				}
				foreach (int key in pooledDictionary.Keys)
				{
					if (num == 0)
					{
						break;
					}
					Weapon weapon_ = myUnit.ParentScen.Cache_GetWeapon(key);
					if (activeUnit_3.Weaponry.TotalDefaultCapacityForThisWeapon(key) - activeUnit_3.Weaponry.TotalAvailableInventoryForThisWeapon(key, IncludeNonOperationalMountsAndMags: false) == 0 || !method_8(weapon_) || Operators.CompareString(activeUnit_3.Weaponry.CanReplenishWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) != 0)
					{
						continue;
					}
					if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
					{
						Magazine[] array = ((!myUnit.IsGroupMember() || !myUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation) ? myUnit.SharedMagazines : myUnit.get_ParentGroup(UsingMissionPlanner: false).SharedMagazines);
						Magazine[] array2 = array;
						foreach (Magazine magazine in array2)
						{
							foreach (WeaponRec weapon in magazine.Weapons)
							{
								if (weapon.CurrentLoad > 0 && weapon.int_3 == key && Operators.CompareString(activeUnit_3.Weaponry.AddWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) == 0)
								{
									weapon.CurrentLoad--;
									weapon.ResetTimeToFire();
									num--;
								}
							}
						}
					}
					else if (Operators.CompareString(activeUnit_3.Weaponry.AddWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) == 0)
					{
						num--;
					}
				}
				pooledDictionary.Dispose();
			}
			else
			{
				method_9(activeUnit_3);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101368", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(float float_1)
	{
		try
		{
			PooledList<ActiveUnit> embarkedBoats_ReadOnly = EmbarkedBoats_ReadOnly;
			if (embarkedBoats_ReadOnly == null)
			{
				return;
			}
			foreach (ActiveUnit item in EmbarkedBoats_ReadOnly)
			{
				_DockingOpsCondition condition = item.DockingOps.Condition;
				if (condition == _DockingOpsCondition.Docked || condition == _DockingOpsCondition.Readying)
				{
					method_10(item);
				}
			}
			embarkedBoats_ReadOnly.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101369", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(float float_1)
	{
		foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_.DockingOps.UNREP_Destination == myUnit && activeUnits_.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				method_10(activeUnits_);
			}
		}
	}

	private void method_13(float float_1)
	{
		if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			try
			{
				if (!string.IsNullOrEmpty(UNREP_Port_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Port_ReceiverUnitID]);
				}
				if (!string.IsNullOrEmpty(UNREP_Starboard_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Starboard_ReceiverUnitID]);
				}
				if (!string.IsNullOrEmpty(UNREP_Astern_ReceiverUnitID))
				{
					list.Add(myUnit.ParentScen.ActiveUnits[UNREP_Astern_ReceiverUnitID]);
				}
				foreach (ActiveUnit item in list)
				{
					string objectID = item.ObjectID;
					if (Operators.CompareString(objectID, UNREP_Port_ReceiverUnitID, false) == 0)
					{
						method_10(item);
					}
					else if (Operators.CompareString(objectID, UNREP_Starboard_ReceiverUnitID, false) != 0)
					{
						if (Operators.CompareString(objectID, UNREP_Astern_ReceiverUnitID, false) == 0)
						{
							method_10(item);
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						method_10(item);
					}
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100147", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		method_12(float_1);
	}

	public bool CanWeSupplyMaterialToThisUnit(ActiveUnit theReceiver, Dictionary<int, Weapon> WeaponsToSupply = null)
	{
		bool result;
		try
		{
			PooledDictionary<int, Weapon> pooledDictionary = theReceiver.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: true);
			int num3 = default(int);
			foreach (int key in pooledDictionary.Keys)
			{
				if (WeaponsToSupply != null && !WeaponsToSupply.ContainsKey(key))
				{
					continue;
				}
				int num = (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines) ? int.MaxValue : myUnit.Weaponry.HowManyOfThisWeaponOnMagazines(key));
				if (num == 0)
				{
					continue;
				}
				(int CurrentInventory, int TotalCapacity) tuple = theReceiver.Weaponry.CurrentInventoryAndTotalCapacityForThisWeapon(key, IncludeNonOperationalMountsAndMags: false);
				int item = tuple.TotalCapacity;
				int item2 = tuple.CurrentInventory;
				int num2 = item - item2;
				if (num2 <= 0 || Operators.CompareString(theReceiver.Weaponry.CanReplenishWeaponToUnit(key, IsAircraftWeapon: false, AllowCreatingNewWeaponRecOnMagazines: false), "OK", false) != 0)
				{
					continue;
				}
				num3 = ((num2 >= num) ? (num3 + num) : (num3 + num2));
				if (num3 <= 0)
				{
					continue;
				}
				result = true;
				goto end_IL_0001;
			}
			pooledDictionary.Dispose();
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1230941832408", "");
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

	public bool AttemptToConnectToTanker()
	{
		bool result;
		try
		{
			int num;
			if (UNREP_Destination.DockingOps.Condition == _DockingOpsCondition.ManoeuveringToRefuel)
			{
				num = 0;
				goto IL_0211;
			}
			if (UNREP_Destination.DockingOps.Condition == _DockingOpsCondition.Replenishing)
			{
				num = 0;
				goto IL_0211;
			}
			if (myUnit.IsOutOfFuel && (myUnit.IsFacility || myUnit.IsMobileGroundUnit) && UNREP_Destination.Navigator.PlottedCourse.Length == 0)
			{
				ActiveUnit uNREP_Destination = UNREP_Destination;
				double theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				double theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				List<ActiveUnit> ProvidedPiers = null;
				string UserFeedback = null;
				bool AllowBounce = false;
				if (uNREP_Destination.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce) && UNREP_Destination.CanPlotCourseToThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
				{
					UNREP_Destination.Navigator.AddWaypoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.Refuel, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
			}
			int num2;
			if (myUnit.RangeToUnit_Horiz(UNREP_Destination) > UNREP_Connect_ThresholdRange)
			{
				result = false;
			}
			else if (UNREP_Destination.CurrentSpeed > 0f && myUnit.CurrentSpeed > 0f && Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, UNREP_Destination.CurrentHeading)) > 20f)
			{
				result = false;
			}
			else
			{
				if (!UNREP_Destination.get_CanPhysicallyReplenishThisUnit(myUnit))
				{
					num2 = 0;
					goto IL_020d;
				}
				if (!string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID) && !string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID) && !string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID))
				{
					num2 = 0;
					goto IL_020d;
				}
				method_14();
				result = true;
			}
			goto end_IL_0001;
			IL_0211:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_020d:
			result = (byte)num2 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100150", "");
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

	private void method_14()
	{
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID, myUnit.ObjectID, false) != 0 && Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID, myUnit.ObjectID, false) != 0 && Operators.CompareString(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID, myUnit.ObjectID, false) != 0)
				{
					if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.Refuel_Port_Out > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Port_ReceiverUnitID = myUnit.ObjectID;
					}
					else if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.Refuel_Starboard_Out > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Starboard_ReceiverUnitID = myUnit.ObjectID;
					}
					else if (string.IsNullOrEmpty(UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID) && UNREP_Destination.UNREP_Capabilities.Refuel_Astern_Out > 0)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
						Condition = _DockingOpsCondition.Replenishing;
						UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
						UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
						UNREP_Destination.DockingOps.UNREP_Astern_ReceiverUnitID = myUnit.ObjectID;
					}
				}
			}
			else
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				Condition = _DockingOpsCondition.Replenishing;
				UNREP_Destination.DockingOps.Condition = _DockingOpsCondition.ProvidingUNREP;
				UNREP_Destination.DockingOps.UNREP_Queue.Remove(myUnit.ObjectID);
				UNREP_Destination.Navigator.ClearPlottedCourse();
				UNREP_Destination.Kinematics.DesiredSpeedOverride = 0f;
				UNREP_Destination.DesiredSpeed = 0f;
				UNREP_Destination.SetThrottle(ActiveUnit.Throttle.FullStop);
				UNREP_Destination.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
				myUnit.Navigator.ClearPlottedCourse();
				myUnit.Kinematics.DesiredSpeedOverride = 0f;
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100151", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CanParkOnDock(DockFacility.DockingPhysicalSize theDockClass)
	{
		int result;
		switch (theDockClass)
		{
		case DockFacility.DockingPhysicalSize.VSmallDockDavit:
		case DockFacility.DockingPhysicalSize.SmallDockDavit:
		case DockFacility.DockingPhysicalSize.MediumDock:
		case DockFacility.DockingPhysicalSize.LargeDock:
			result = 1;
			break;
		case DockFacility.DockingPhysicalSize.ROV_UUV:
			result = 1;
			break;
		default:
			return false;
		case DockFacility.DockingPhysicalSize.DryDockShelter:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public bool CanHostThisBoat(ActiveUnit theBoat, [Optional][DefaultParameterValue(null)] ref DockFacility bestFacility)
	{
		List<DockFacility> list = new List<DockFacility>();
		bool result;
		try
		{
			bool flag = true;
			int num;
			DockFacility.DockingPhysicalSize dockingPhysicalSize;
			if (theBoat.IsShip)
			{
				num = (int)Math.Round(((Ship)theBoat).Length);
				dockingPhysicalSize = ((Ship)theBoat).DockingPhysicalSize;
				goto IL_009e;
			}
			if (theBoat.IsSubmarine)
			{
				num = (int)Math.Round(((Submarine)theBoat).Length);
				dockingPhysicalSize = ((Submarine)theBoat).DockingPhysicalSize;
				goto IL_009e;
			}
			if (!theBoat.IsVehicle)
			{
				throw new NotImplementedException();
			}
			if (((Vehicle)theBoat).IsAmphibiousSeaworthy)
			{
				num = (int)Math.Round(((Vehicle)theBoat).Length);
				dockingPhysicalSize = ((Vehicle)theBoat).DockingPhysicalSize;
				flag = false;
				goto IL_009e;
			}
			result = false;
			goto end_IL_0006;
			IL_009e:
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			int num2 = 0;
			while (true)
			{
				if (num2 < dockFacilities_ReadOnly.Length)
				{
					DockFacility dockFacility = dockFacilities_ReadOnly[num2];
					if ((flag || dockFacility.Type != DockFacility.DockFacilityType.Davit) && dockFacility.CanHostThisBoat((short)num, dockingPhysicalSize) == DockingOpsAttemptResult.Success && dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (myUnit.DockFacilities_ReadOnly.Count() == 1)
						{
							bestFacility = dockFacility;
							result = true;
							break;
						}
						list.Add(dockFacility);
					}
					num2 = checked(num2 + 1);
					continue;
				}
				DockFacility dockFacility2 = null;
				if (list.Count > 0)
				{
					foreach (DockFacility item in list)
					{
						if (item.Size == dockingPhysicalSize && (Information.IsNothing((object)dockFacility2) || item.TotalCapacity_Free < dockFacility2.TotalCapacity_Free))
						{
							dockFacility2 = item;
						}
					}
					if (dockFacility2 != null)
					{
						bestFacility = dockFacility2;
						result = true;
						break;
					}
					IEnumerable<DockFacility> source = list.OrderBy([SpecialName] (DockFacility theAF) => theAF.TotalCapacity_Free);
					bestFacility = source.ElementAtOrDefault(0);
					result = true;
				}
				else
				{
					result = false;
				}
				break;
			}
			end_IL_0006:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100152", "");
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

	public DockingOpsAttemptResult CanHostThisBoat(short BoatLength, DockFacility.DockingPhysicalSize BoatDockingClass)
	{
		DockingOpsAttemptResult result;
		try
		{
			DockingOpsAttemptResult dockingOpsAttemptResult = DockingOpsAttemptResult.Failure_other;
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < dockFacilities_ReadOnly.Length)
				{
					DockFacility dockFacility = dockFacilities_ReadOnly[num];
					DockingOpsAttemptResult dockingOpsAttemptResult2 = dockFacility.CanHostThisBoat(BoatLength, BoatDockingClass);
					if (dockingOpsAttemptResult2 != DockingOpsAttemptResult.Success)
					{
						dockingOpsAttemptResult = dockingOpsAttemptResult2;
					}
					else
					{
						if (dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
						{
							result = DockingOpsAttemptResult.Success;
							break;
						}
						dockingOpsAttemptResult = DockingOpsAttemptResult.Damaged_facility;
					}
					num = checked(num + 1);
					continue;
				}
				result = dockingOpsAttemptResult;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100153", "");
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
			result = (DockingOpsAttemptResult)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AddThisBoat(ActiveUnit theBoat)
	{
		try
		{
			if (!Information.IsNothing((object)theBoat.DockingOps.HostDockFacility))
			{
				theBoat.DockingOps.HostDockFacility = null;
			}
			DockFacility hostDockFacility = method_15(theBoat);
			theBoat.DockingOps.HostDockFacility = hostDockFacility;
			switch (theBoat.DockingOps.Condition)
			{
			case _DockingOpsCondition.Docked:
				if (theBoat.DockingOps.ConditionTimer > 0f)
				{
					theBoat.DockingOps.Condition = _DockingOpsCondition.Readying;
				}
				break;
			case _DockingOpsCondition.Underway:
			case _DockingOpsCondition.RTB:
			case _DockingOpsCondition.ManoeuveringToRefuel:
			case _DockingOpsCondition.Replenishing:
			case _DockingOpsCondition.ProvidingUNREP:
			case _DockingOpsCondition.RechargingBatteries:
			case _DockingOpsCondition.SettlingForCargoTransfer:
			case _DockingOpsCondition.TransferringCargo:
			case _DockingOpsCondition.TransferringMissionCargo:
				if (theBoat.DockingOps.ConditionTimer == 0f)
				{
					theBoat.DockingOps.Condition = _DockingOpsCondition.Docked;
				}
				else
				{
					theBoat.DockingOps.Condition = _DockingOpsCondition.Docking;
				}
				break;
			}
			theBoat.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, myUnit);
			theBoat.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100154", "");
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
		try
		{
			if (!myUnit.IsShip && !myUnit.IsSubmarine)
			{
				return;
			}
			float num = myUnit.Kinematics.MaxRange(BingoFuelCheck: true, null, null);
			PooledList<ActiveUnit> units = myUnit.get_UnitSide(SetSideOnly: false).Units;
			int num2 = units.Count - 1;
			PooledList<ActiveUnit> pooledList = default(PooledList<ActiveUnit>);
			for (int i = 0; i <= num2; i++)
			{
				ActiveUnit activeUnit;
				try
				{
					activeUnit = units[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (activeUnit != myUnit && myUnit.RangeToUnit_Horiz(activeUnit) <= num && ThisUnitCanHostMe(activeUnit, HumanFeedBackNeeded: false).ResponseBoolean)
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<ActiveUnit>();
					}
					pooledList.Add(activeUnit);
				}
			}
			if (pooledList != null)
			{
				if (excludeUnit != null && pooledList.Contains(excludeUnit))
				{
					pooledList.Remove(excludeUnit);
				}
				if (pooledList.Count > 0)
				{
					int index = GameGeneral.GlobalRNG.Next(0, pooledList.Count);
					this.set_AssignedHostUnit(PickNewAssignedHost: false, pooledList[index]);
				}
				pooledList.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100155", "");
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
			List<ActiveUnit> list = new List<ActiveUnit>();
			ActiveUnit value = null;
			if (CurrentHostUnit != null)
			{
				if (!CurrentHostUnit.IsMorituri)
				{
					this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
					return;
				}
				this.set_AssignedHostUnit(PickNewAssignedHost: false, (ActiveUnit)null);
			}
			List<ActiveUnit> list2;
			lock (myUnit.get_UnitSide(SetSideOnly: false).Units)
			{
				list2 = new List<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
			}
			foreach (ActiveUnit item in list2)
			{
				if (ThisUnitCanHostMe(item, HumanFeedBackNeeded: false).ResponseBoolean)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			double num = 99999999999.0;
			foreach (ActiveUnit item2 in list)
			{
				double num2 = Math2.CalcDist(item2.get_Latitude((GlobalVariables.BooleanObject)null), item2.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				if (num2 < num)
				{
					num = num2;
					value = item2;
				}
			}
			this.set_AssignedHostUnit(PickNewAssignedHost: false, value);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100156", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public (bool ResponseBoolean, string ResponseString) ThisUnitCanHostMe(ActiveUnit theUnit, bool HumanFeedBackNeeded)
	{
		(bool, string) result;
		try
		{
			if (theUnit != null)
			{
				int num;
				DockFacility.DockingPhysicalSize dockingPhysicalSize;
				if (!myUnit.IsShip)
				{
					if (!myUnit.IsSubmarine)
					{
						if (!myUnit.IsVehicle || !((Vehicle)myUnit).IsAmphibiousSeaworthy)
						{
							if (!HumanFeedBackNeeded)
							{
								return (ResponseBoolean: false, ResponseString: string.Empty);
							}
							return (ResponseBoolean: false, ResponseString: "Not possible (wrong type of unit)");
						}
						num = (int)Math.Round(((Vehicle)myUnit).Length);
						dockingPhysicalSize = ((Vehicle)myUnit).DockingPhysicalSize;
					}
					else
					{
						num = (int)Math.Round(((Submarine)myUnit).Length);
						dockingPhysicalSize = ((Submarine)myUnit).DockingPhysicalSize;
					}
				}
				else
				{
					num = (int)Math.Round(((Ship)myUnit).Length);
					dockingPhysicalSize = ((Ship)myUnit).DockingPhysicalSize;
				}
				DockingOpsAttemptResult dockingOpsAttemptResult = theUnit.DockingOps.CanHostThisBoat((short)num, dockingPhysicalSize);
				if (dockingOpsAttemptResult == DockingOpsAttemptResult.Success)
				{
					if (!HumanFeedBackNeeded)
					{
						return (ResponseBoolean: true, ResponseString: string.Empty);
					}
					return (ResponseBoolean: true, ResponseString: "OK");
				}
				if (HumanFeedBackNeeded)
				{
					return (ResponseBoolean: false, ResponseString: "The boat cannot be hosted on any docking facility here (" + dockingOpsAttemptResult.ToString().Replace("_", " ") + ")");
				}
				return (ResponseBoolean: false, ResponseString: string.Empty);
			}
			if (!HumanFeedBackNeeded)
			{
				return (ResponseBoolean: false, ResponseString: string.Empty);
			}
			return (ResponseBoolean: false, ResponseString: "Not possible (Error!)");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100157", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (false, "Not possible (Error!)");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private DockFacility method_15(ActiveUnit activeUnit_3)
	{
		List<DockFacility> list = new List<DockFacility>();
		DockFacility result;
		try
		{
			DockFacility bestFacility = null;
			bool flag = true;
			int num;
			DockFacility.DockingPhysicalSize dockingPhysicalSize;
			if (activeUnit_3.IsShip)
			{
				num = (int)Math.Round(((Ship)activeUnit_3).Length);
				dockingPhysicalSize = ((Ship)activeUnit_3).DockingPhysicalSize;
				goto IL_009b;
			}
			if (activeUnit_3.IsSubmarine)
			{
				num = (int)Math.Round(((Submarine)activeUnit_3).Length);
				dockingPhysicalSize = ((Submarine)activeUnit_3).DockingPhysicalSize;
				goto IL_009b;
			}
			if (!activeUnit_3.IsVehicle)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			flag = false;
			Vehicle vehicle = (Vehicle)activeUnit_3;
			if (vehicle.IsAmphibiousSeaworthy)
			{
				num = (int)Math.Round(vehicle.Length);
				dockingPhysicalSize = vehicle.DockingPhysicalSize;
				goto IL_009b;
			}
			result = null;
			goto end_IL_0007;
			IL_009b:
			DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
			{
				if ((flag || dockFacility.Type != DockFacility.DockFacilityType.Davit) && dockFacility.CanHostThisBoat((short)num, dockingPhysicalSize) == DockingOpsAttemptResult.Success && dockFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					list.Add(dockFacility);
				}
			}
			if (list.Count == 0 && CanHostThisBoat(activeUnit_3, ref bestFacility) && bestFacility != null)
			{
				result = bestFacility;
			}
			else
			{
				DockFacility dockFacility2 = null;
				if (list.Count > 0)
				{
					foreach (DockFacility item in list)
					{
						if (item.Size == dockingPhysicalSize && (Information.IsNothing((object)dockFacility2) || item.TotalCapacity_Free < dockFacility2.TotalCapacity_Free))
						{
							dockFacility2 = item;
						}
					}
					if (dockFacility2 == null)
					{
						bestFacility = list.OrderBy([SpecialName] (DockFacility theAF) => theAF.TotalCapacity_Free).ElementAtOrDefault(0);
						result = bestFacility;
					}
					else
					{
						bestFacility = dockFacility2;
						result = bestFacility;
					}
				}
				else
				{
					result = null;
				}
			}
			end_IL_0007:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100158", "");
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

	private void method_16(float float_1)
	{
		try
		{
			if (!Information.IsNothing((object)CurrentHostUnit))
			{
				string name = CurrentHostUnit.Name;
				ActiveUnit currentHostUnit = CurrentHostUnit;
				_ = CurrentHostUnit;
				myUnit.set_Longitude((GlobalVariables.BooleanObject)null, CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				myUnit.set_Latitude((GlobalVariables.BooleanObject)null, CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null));
				myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
				myUnit.CurrentSpeed = (float)(2.0 / 3.0 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false));
				myUnit.DesiredSpeed = myUnit.CurrentSpeed;
				myUnit.CurrentHeading = CurrentHostUnit.CurrentHeading;
				HostDockFacility = null;
				Condition = _DockingOpsCondition.Underway;
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				myUnit.AI.RefreshVisibleContactsList();
				myUnit.AI.EvaluateTargets(float_1, IgnoreContacStance: true, Immediately: true);
				myUnit.AI.EvaluateThreats(float_1);
				myUnit.AI.EvaluateUnitStatus(float_1, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					myUnit.AddMessage(myUnit.Name + " departed " + name + " and is waiting for orders.", "Docking operations", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (myUnit.IsGroupLead() && Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
				{
					myUnit.AddMessage(myUnit.Name + " departed " + name + " and is waiting for orders.", "Docking operations", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " departed " + name + ".", "Docking operations", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				if (!Information.IsNothing((object)currentHostUnit) && HasPiers(currentHostUnit))
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(currentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), currentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, (double)PierLaneLength * 0.95, currentHostUnit.CurrentHeading);
					myUnit.Navigator.AddWaypoint(0, new Waypoint(out_lon, out_lat, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
				myUnit.Sensory.ObeysEMCON = true;
				myUnit.Sensory.vmethod_2(myUnit.Sensors_Cached);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100159", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptToStartDocking(ActiveUnit theHost, bool CancelDeployment = false)
	{
		DockFacility dockFacility;
		if (CancelDeployment && !Information.IsNothing((object)CurrentHostUnit))
		{
			dockFacility = HostDockFacility;
		}
		else
		{
			dockFacility = theHost.DockingOps.method_15(myUnit);
			if (Information.IsNothing((object)dockFacility))
			{
				return;
			}
		}
		try
		{
			HostDockFacility = dockFacility;
			if (CancelDeployment)
			{
				Condition = _DockingOpsCondition.Docked;
				ConditionTimer = 0f;
			}
			else
			{
				Condition = _DockingOpsCondition.Docking;
			}
			Mission mission = myUnit.ActiveMissionOrPackage();
			if (!Information.IsNothing((object)mission))
			{
				if (mission.MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)mission).Behavior)
					{
					case FerryMission.FerryMissionBehavior.OneWay:
					{
						ActiveUnit activeUnit = myUnit;
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
						this.set_AssignedHostUnit(PickNewAssignedHost: false, CurrentHostUnit);
						break;
					}
					case FerryMission.FerryMissionBehavior.Cycle:
						myUnit.AI.ChangeCycleLeg();
						break;
					case FerryMission.FerryMissionBehavior.Random:
						PickNewAssignedHost_RandomWithinRange(this.get_AssignedHostUnit(PickNewAssignedHost: false));
						break;
					}
				}
				if (mission.MissionClass == Mission._MissionClass.Support && ((SupportMission)mission).OneTimeOnly)
				{
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				}
			}
			if (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) != CurrentHostUnit.get_ParentGroup(UsingMissionPlanner: false))
			{
				myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
			}
			myUnit.GoInoperative();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100160", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_17()
	{
		Condition = _DockingOpsCondition.Docked;
		method_18(myUnit.ActiveMissionOrPackage());
		List<Cargo> list = myUnit.OnboardCargo.ToList();
		int val = 0;
		ActiveUnit target = CurrentHostUnit;
		ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
		if (list.Count > 0)
		{
			bool unpackAllContainers = false;
			val = TimeToUnloadCargo(myUnit, list);
			if (currentHostUnitCargoSource.IsGroup)
			{
				ActiveUnit activeUnit = null;
				bool flag = false;
				if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission obj = (CargoMission)myUnit.ActiveMissionOrPackage();
					activeUnit = obj.DestinationUnit;
					unpackAllContainers = obj.UnpackAllContainers;
				}
				foreach (ActiveUnit value in ((Group)currentHostUnitCargoSource).Units.Values)
				{
					if (value != activeUnit)
					{
						if (value.OnboardCargo.Count() > 0 && !flag)
						{
							target = value;
							flag = true;
						}
						continue;
					}
					target = value;
					break;
				}
			}
			PerformCargoTransferBetweenHostAndTarget(myUnit, target, myUnit.OnboardCargo.ToList(), unpackAllContainers);
		}
		Condition = _DockingOpsCondition.Readying;
		ConditionTimer = Math.Max(1800, val);
		if (myUnit.Navigator.HasPlottedCourse())
		{
			myUnit.Navigator.ClearPlottedCourse();
		}
		CommenceRepairs();
	}

	public void BeginReadying()
	{
		Condition = _DockingOpsCondition.Readying;
		ConditionTimer = 1800f;
		CommenceRepairs();
	}

	public void CommenceRepairs()
	{
		try
		{
			foreach (Sensor mineCountermeasure in myUnit.MineCountermeasures)
			{
				if (mineCountermeasure.IsExplosiveMineNeutralizer)
				{
					mineCountermeasure.MakeOperational(GiveUserFeedback: true);
					myUnit.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100161", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<ActiveUnit> GetPotentialUNREPunits(bool MustBeAbleToReachItDirectly, List<Mission> theSelectedMissions, ref string UserFeedback, ResupplyRequest UnrepType)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> result;
		try
		{
			byte? b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				UserFeedback = "Unit " + myUnit.Name + " has a doctrine setting that disallows UNREP. As such, the unit will not refuel. Change the doctrine setting and try again.";
				result = list;
			}
			else
			{
				int num = 0;
				UserFeedback = "No UNREP units are available.";
				foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ == null || activeUnits_ == myUnit || (activeUnits_.get_UnitSide(SetSideOnly: false) != myUnit.get_UnitSide(SetSideOnly: false) && !Module_Side.IsAlliedWithThisSide(activeUnits_.get_UnitSide(SetSideOnly: false), myUnit.get_UnitSide(SetSideOnly: false))) || !activeUnits_.IsOperating() || (activeUnits_.get_ParentGroup(UsingMissionPlanner: false) != null && activeUnits_.get_ParentGroup(UsingMissionPlanner: false).ReservedSupply && (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || Operators.CompareString(myUnit.get_ParentGroup(UsingMissionPlanner: false).ObjectID, activeUnits_.get_ParentGroup(UsingMissionPlanner: false).ObjectID, false) != 0)))
					{
						continue;
					}
					ResupplyCapacity designatedSupplier = activeUnits_.DesignatedSupplier;
					if (designatedSupplier == ResupplyCapacity.None)
					{
						continue;
					}
					switch (UnrepType)
					{
					case ResupplyRequest.Fuel:
						if (designatedSupplier != ResupplyCapacity.Fuel && designatedSupplier != ResupplyCapacity.FuelAndMaterial)
						{
							continue;
						}
						break;
					case ResupplyRequest.Material:
						if (designatedSupplier != ResupplyCapacity.Material && designatedSupplier != ResupplyCapacity.FuelAndMaterial)
						{
							continue;
						}
						break;
					case ResupplyRequest.FuelAndMaterial:
						if (designatedSupplier != ResupplyCapacity.FuelAndMaterial && (designatedSupplier != ResupplyCapacity.Fuel || designatedSupplier != ResupplyCapacity.Material))
						{
							continue;
						}
						break;
					case ResupplyRequest.FuelOrMaterial:
						if (designatedSupplier != ResupplyCapacity.FuelAndMaterial && designatedSupplier != ResupplyCapacity.Fuel && designatedSupplier != ResupplyCapacity.Material)
						{
							continue;
						}
						break;
					}
					if (activeUnits_.IsRTB)
					{
						if (num < 1)
						{
							num = 1;
							UserFeedback = "Tanker is RTB.";
						}
					}
					else if (activeUnits_.get_CanPhysicallyReplenishThisUnit(myUnit))
					{
						if (theSelectedMissions != null)
						{
							if (activeUnits_.ActiveMissionOrPackage() == null)
							{
								if (num < 3)
								{
									num = 3;
									UserFeedback = "Mission " + theSelectedMissions[0].Name + " has no available tankers.";
								}
								continue;
							}
							bool flag = true;
							foreach (Mission theSelectedMission in theSelectedMissions)
							{
								if (activeUnits_.ActiveMissionOrPackage() == theSelectedMission)
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								if (num < 4)
								{
									num = 4;
									UserFeedback = "Mission " + activeUnits_.ActiveMissionOrPackage().Name + " has no available tankers.";
								}
								continue;
							}
						}
						if (myUnit.IsBoat)
						{
							if (myUnit.RangeToUnit_Horiz(activeUnits_) < 10f)
							{
								MustBeAbleToReachItDirectly = false;
							}
							if (MustBeAbleToReachItDirectly)
							{
								ActiveUnit_AI aI = myUnit.AI;
								float currentHeading = myUnit.CurrentHeading;
								float? safetyMargin = 0.15f;
								bool BingoFuelEndurance = false;
								if (!aI.CanInterceptTarget(activeUnits_, null, 0f, null, currentHeading, ActiveUnit.Throttle.Full, safetyMargin, IgnoreMotionVectors: true, TotalRemainingEndurance: false, ref BingoFuelEndurance))
								{
									if (num < 5)
									{
										num = 5;
										UserFeedback = "Unit" + myUnit.Name + " cannot reach a replenishment provider. A possible reason could be that there are too many receivers in queue.";
									}
									continue;
								}
							}
						}
						list.Add(activeUnits_);
					}
					else if (num < 2)
					{
						num = 2;
						UserFeedback = "Unit " + activeUnits_.Name + " is an UNREP unit but cannot UNREP " + myUnit.Name + ".";
					}
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100163", "");
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

	internal (ResultOfAttemptToScheduleUNREP Result, string DetailedFeedback) AttemptToScheduleUNREP(GeoPoint IntermediateTargetPoint, ActiveUnit theSelectedTanker, List<Mission> theSelectedMissions, bool IsManualOrder, int? DistanceLimit = null, ResupplyRequest RessuplyType = ResupplyRequest.FuelOrMaterial, Dictionary<int, Weapon> WeaponsToSupply = null)
	{
		_Closure$__157-0 arg = default(_Closure$__157-0);
		_Closure$__157-0 CS$<>8__locals20 = new _Closure$__157-0(arg);
		CS$<>8__locals20.$VB$Me = this;
		CS$<>8__locals20.$VB$Local_IntermediateTargetPoint = IntermediateTargetPoint;
		CS$<>8__locals20.$VB$Local_DistanceLimit = DistanceLimit;
		(ResultOfAttemptToScheduleUNREP, string) result;
		try
		{
			string UserFeedback = "";
			if (theSelectedTanker != null)
			{
				if (theSelectedTanker.IsGroup)
				{
					if (((Group)theSelectedTanker).GroupLead == null)
					{
						return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: "The selected group has Not group lead");
					}
					theSelectedTanker = ((Group)theSelectedTanker).GroupLead;
				}
				ResultOfAttemptToRendezvousWithTanker resultOfAttemptToRendezvousWithTanker = AttemptToRendezvousWithTanker(theSelectedTanker, RessuplyType, WeaponsToSupply);
				if (resultOfAttemptToRendezvousWithTanker == ResultOfAttemptToRendezvousWithTanker.Success)
				{
					return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
				}
				return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: Misc.ToEnglishString(resultOfAttemptToRendezvousWithTanker));
			}
			List<ActiveUnit> list = GetPotentialUNREPunits(MustBeAbleToReachItDirectly: true, theSelectedMissions, ref UserFeedback, RessuplyType);
			if (list.Count == 0)
			{
				int item;
				if (Operators.CompareString(UserFeedback, string.Empty, false) == 0)
				{
					string text = myUnit.Name + " has no suitable UNREP destination.";
					if (IsManualOrder)
					{
						myUnit.AddMessage(text, "No suitable UNREP provider found", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					UserFeedback = text;
					item = 2;
				}
				else
				{
					item = 2;
				}
				return (Result: (ResultOfAttemptToScheduleUNREP)item, DetailedFeedback: UserFeedback);
			}
			if (CS$<>8__locals20.$VB$Local_DistanceLimit.HasValue)
			{
				list = list.Where([SpecialName] (ActiveUnit theT) => CS$<>8__locals20.$VB$Me.myUnit.RangeToUnit_Horiz(theT) <= (float)CS$<>8__locals20.$VB$Local_DistanceLimit.Value).ToList();
				if (list.Count == 0)
				{
					string text2 = myUnit.Name + " has no suitable UNREP destination within " + (CS$<>8__locals20.$VB$Local_DistanceLimit.HasValue ? Conversions.ToString(CS$<>8__locals20.$VB$Local_DistanceLimit.GetValueOrDefault()) : null) + " nm - aborting UNREP attempt.";
					int item2;
					if (IsManualOrder)
					{
						myUnit.AddMessage(text2, "No suitable UNREP provider found", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						item2 = 3;
					}
					else
					{
						item2 = 3;
					}
					return (Result: (ResultOfAttemptToScheduleUNREP)item2, DetailedFeedback: text2);
				}
			}
			if (list.Contains(myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false)) && AttemptToRendezvousWithTanker(myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false), RessuplyType) == ResultOfAttemptToRendezvousWithTanker.Success)
			{
				return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
			}
			if (CS$<>8__locals20.$VB$Local_IntermediateTargetPoint == null)
			{
				_Closure$__157-2 closure$__157- = new _Closure$__157-2(closure$__157-);
				closure$__157-.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals20;
				closure$__157-.$VB$Local_myHost = ActualDestinationHost;
				if (closure$__157-.$VB$Local_myHost != null)
				{
					_Closure$__157-1 arg2 = default(_Closure$__157-1);
					_Closure$__157-1 CS$<>8__locals24 = new _Closure$__157-1(arg2);
					CS$<>8__locals24.$VB$NonLocal_$VB$Closure_3 = closure$__157-;
					CS$<>8__locals24.$VB$Local_RangeToBase_Angular = Module_Unit.RangeToUnit_Horiz_Angular(myUnit, CS$<>8__locals24.$VB$NonLocal_$VB$Closure_3.$VB$Local_myHost);
					IEnumerable<ActiveUnit> enumerable = from theT in list
						where !(Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals24.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit, theT) >= CS$<>8__locals24.$VB$Local_RangeToBase_Angular) && Module_Unit.RangeToUnit_Horiz_Angular(theT, CS$<>8__locals24.$VB$NonLocal_$VB$Closure_3.$VB$Local_myHost) < CS$<>8__locals24.$VB$Local_RangeToBase_Angular
						orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)
						select theT;
					if (enumerable.Count() > 0)
					{
						foreach (ActiveUnit item3 in enumerable)
						{
							if (AttemptToRendezvousWithTanker(item3, RessuplyType, WeaponsToSupply) == ResultOfAttemptToRendezvousWithTanker.Success)
							{
								return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
							}
						}
					}
					else
					{
						ActiveUnit._ActiveUnitFuelState activeUnitFuelState = myUnit.get_IsBingoTowardsThisDestination(CS$<>8__locals24.$VB$NonLocal_$VB$Closure_3.$VB$Local_myHost, (GeoPoint)null, (Doctrine._FuelState?)null);
						if (activeUnitFuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || activeUnitFuelState == ActiveUnit._ActiveUnitFuelState.IsJoker)
						{
							IEnumerable<ActiveUnit> enumerable2 = list.OrderBy([SpecialName] (ActiveUnit theT) => Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit));
							foreach (ActiveUnit item4 in enumerable2)
							{
								if (AttemptToRendezvousWithTanker(item4, RessuplyType, WeaponsToSupply) == ResultOfAttemptToRendezvousWithTanker.Success)
								{
									return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
								}
							}
						}
					}
				}
				else
				{
					IEnumerable<ActiveUnit> enumerable3 = list.OrderBy([SpecialName] (ActiveUnit theT) => Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit));
					foreach (ActiveUnit item5 in enumerable3)
					{
						if (AttemptToRendezvousWithTanker(item5, RessuplyType, WeaponsToSupply) == ResultOfAttemptToRendezvousWithTanker.Success)
						{
							return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
						}
					}
				}
			}
			else
			{
				_Closure$__157-3 arg3 = default(_Closure$__157-3);
				_Closure$__157-3 CS$<>8__locals29 = new _Closure$__157-3(arg3);
				CS$<>8__locals29.$VB$NonLocal_$VB$Closure_4 = CS$<>8__locals20;
				CS$<>8__locals29.$VB$Local_RangeToTarget_Angular = Module_Unit.RangeToPoint_Horiz_Angular(myUnit, CS$<>8__locals29.$VB$NonLocal_$VB$Closure_4.$VB$Local_IntermediateTargetPoint);
				IEnumerable<ActiveUnit> enumerable4 = from theT in list
					where !(Module_Unit.RangeToUnit_Horiz_Angular(CS$<>8__locals29.$VB$NonLocal_$VB$Closure_4.$VB$Me.myUnit, theT) >= CS$<>8__locals29.$VB$Local_RangeToTarget_Angular) && Module_Unit.RangeToPoint_Horiz_Angular(theT, CS$<>8__locals29.$VB$NonLocal_$VB$Closure_4.$VB$Local_IntermediateTargetPoint) < CS$<>8__locals29.$VB$Local_RangeToTarget_Angular
					orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, myUnit)
					select theT;
				if (enumerable4.Count() > 0)
				{
					foreach (ActiveUnit item6 in enumerable4)
					{
						if (AttemptToRendezvousWithTanker(item6, RessuplyType, WeaponsToSupply) == ResultOfAttemptToRendezvousWithTanker.Success)
						{
							return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
						}
					}
				}
				else
				{
					IEnumerable<ActiveUnit> enumerable5 = list.OrderBy([SpecialName] (ActiveUnit theT) => Module_Unit.RangeToPoint_Horiz_Angular(theT, CS$<>8__locals29.$VB$NonLocal_$VB$Closure_4.$VB$Local_IntermediateTargetPoint));
					foreach (ActiveUnit item7 in enumerable5)
					{
						if (AttemptToRendezvousWithTanker(item7, RessuplyType, WeaponsToSupply) == ResultOfAttemptToRendezvousWithTanker.Success)
						{
							return (Result: ResultOfAttemptToScheduleUNREP.Success, DetailedFeedback: string.Empty);
						}
					}
				}
			}
			return (Result: ResultOfAttemptToScheduleUNREP.Fail_Other, DetailedFeedback: "Failed to schedule a replenishment rendezvous");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100164", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (ResultOfAttemptToScheduleUNREP.Fail_Other, "Failed - Unknown error");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AttemptDippingSonar()
	{
		try
		{
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			Condition = _DockingOpsCondition.DeployingDippingSonar;
			ConditionTimer = 240f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100432", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal ResultOfAttemptToRendezvousWithTanker AttemptToRendezvousWithTanker(ActiveUnit theTanker, ResupplyRequest Request = ResupplyRequest.FuelOrMaterial, Dictionary<int, Weapon> WeaponsToSupply = null)
	{
		ResultOfAttemptToRendezvousWithTanker result = default(ResultOfAttemptToRendezvousWithTanker);
		try
		{
			int num;
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				result = ResultOfAttemptToRendezvousWithTanker.Success;
			}
			else
			{
				if (!theTanker.IsBoat)
				{
					num = 0;
					goto IL_0064;
				}
				if (!myUnit.IsBoat)
				{
					num = 0;
					goto IL_0064;
				}
				if (((IBoat)theTanker).IsDedicatedTankerOrUNREP || !(((IBoat)theTanker).Displacement_Standard < ((IBoat)myUnit).Displacement_Standard))
				{
					num = 0;
					goto IL_0064;
				}
				result = ResultOfAttemptToRendezvousWithTanker.Fail_ProviderSmallerThanReceiver;
			}
			goto end_IL_0001;
			IL_0064:
			int num2 = num;
			if (theTanker.IsMobileGroundUnit || (theTanker.IsFacility && !theTanker.IsFixedFacility))
			{
				num2 = 5000;
			}
			bool flag = theTanker.DockingOps.get_FuelWeCanSupplyToThisUnit(myUnit, (float)num2) > 0;
			bool flag2 = theTanker.DockingOps.CanWeSupplyMaterialToThisUnit(myUnit, WeaponsToSupply);
			switch (Request)
			{
			case ResupplyRequest.Fuel:
				if (flag)
				{
					break;
				}
				result = ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				goto end_IL_0001;
			case ResupplyRequest.Material:
				if (flag2)
				{
					break;
				}
				result = ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				goto end_IL_0001;
			case ResupplyRequest.FuelAndMaterial:
			{
				int num3;
				if (!flag)
				{
					num3 = 3;
				}
				else
				{
					if (flag2)
					{
						break;
					}
					num3 = 3;
				}
				result = (ResultOfAttemptToRendezvousWithTanker)num3;
				goto end_IL_0001;
			}
			case ResupplyRequest.FuelOrMaterial:
				if (flag || flag2)
				{
					break;
				}
				result = ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer;
				goto end_IL_0001;
			}
			if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
			{
				if (!(myUnit.IsBoat & myUnit.IsOutOfFuel))
				{
					ActiveUnit_AI aI = myUnit.AI;
					float currentHeading = myUnit.CurrentHeading;
					float? safetyMargin = 0.25f;
					bool BingoFuelEndurance = false;
					if (!aI.CanInterceptTarget(theTanker, null, 0f, null, currentHeading, ActiveUnit.Throttle.Cruise, safetyMargin, IgnoreMotionVectors: true, TotalRemainingEndurance: false, ref BingoFuelEndurance))
					{
						result = ResultOfAttemptToRendezvousWithTanker.Fail_CannotIntercept;
					}
					else
					{
						if (!(myUnit.IsAircraft & GlobalVariables.AI_REWORK))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						}
						Condition = _DockingOpsCondition.ManoeuveringToRefuel;
						UNREP_Destination = theTanker;
						result = ResultOfAttemptToRendezvousWithTanker.Success;
					}
				}
				else if (myUnit.RangeToUnit_Horiz(theTanker) <= 10f)
				{
					if (!(myUnit.IsAircraft & GlobalVariables.AI_REWORK))
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					}
					Condition = _DockingOpsCondition.ManoeuveringToRefuel;
					UNREP_Destination = theTanker;
					result = ResultOfAttemptToRendezvousWithTanker.Success;
				}
			}
			else
			{
				if (!(myUnit.IsAircraft & GlobalVariables.AI_REWORK))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				}
				Condition = _DockingOpsCondition.ManoeuveringToRefuel;
				UNREP_Destination = theTanker;
				result = ResultOfAttemptToRendezvousWithTanker.Success;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100165", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 2;
			}
			else
			{
				num4 = 2;
			}
			result = (ResultOfAttemptToRendezvousWithTanker)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static double GetCargoMoveTime(double MinimumTime, double MaximumTime, double ActualLoad, double MaximumLoad)
	{
		double num = Math.Log(MaximumTime / MinimumTime) / MaximumLoad;
		return MinimumTime * Math.Exp(num * ActualLoad);
	}

	public static int TimeToLoadCargo(ActiveUnit Host, List<Cargo> CargoItemsToMove)
	{
		return ((ICargoHost)Host)?.GetLoadTime(CargoItemsToMove) ?? DEFAULT_CARGO_LOAD_TIME;
	}

	public static int TimeToUnloadCargo(ActiveUnit Host, List<Cargo> CargoItemsToMove)
	{
		return ((ICargoHost)Host)?.GetUnloadTime(CargoItemsToMove) ?? DEFAULT_CARGO_UNLOAD_TIME;
	}

	public static void PerformCargoTransferBetweenHostAndTarget(ActiveUnit Host, ActiveUnit Target, List<Cargo> CargoItemsToMove, bool UnpackAllContainers = false)
	{
		try
		{
			if (CargoItemsToMove.Count == 0)
			{
				return;
			}
			List<CargoContainer> list = new List<CargoContainer>();
			foreach (Cargo item in CargoItemsToMove)
			{
				bool flag = false;
				ActiveUnit activeUnit = (Target.IsGroup ? Cargo.GetGroupCargoDestinationUnit((Group)Target, Host, item) : Target);
				if (UnpackAllContainers && item.CargoObjectContainer != null && (activeUnit.IsFixedFacility || activeUnit.IsShip))
				{
					ArrayExtensions.Remove(ref Host.OnboardCargo, item);
					list.Add(item.CargoObjectContainer);
					Scenario.CargoMovement.Add((Host.ObjectID, new CargoTracker(item, 0, 1)));
					Scenario.CargoMovement.Add((activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
				}
				else if (Operators.CompareString(item.CargoObjectID, Host.ObjectID, false) != 0)
				{
					if (!Host.OnboardCargo.Contains(item))
					{
						foreach (Mount mount in Host.Mounts)
						{
							if (item.InternalObjectType == Cargo.CargoObjectType.Mount && item.CargoObjectDBID == mount.DBID)
							{
								Host.Mounts.Remove(mount);
								ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
								Scenario.CargoMovement.Add((Host.ObjectID, new CargoTracker(item, 0, 1)));
								Scenario.CargoMovement.Add((activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
								break;
							}
						}
					}
					else
					{
						flag = item.CargoObjectActiveUnit != null;
						ArrayExtensions.Remove(ref Host.OnboardCargo, item);
						ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
						if (item.CargoObjectActiveUnit != null)
						{
							item.CargoObjectActiveUnit.DockingOps.LoadIntoCargo(activeUnit);
						}
						Scenario.CargoMovement.Add((Host.ObjectID, new CargoTracker(item, 0, 1)));
						Scenario.CargoMovement.Add((activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
					}
				}
				else
				{
					flag = true;
					Host.DockingOps.LoadIntoCargo(activeUnit);
					ArrayExtensions.Add(ref activeUnit.OnboardCargo, item);
					Scenario.CargoMovement.Add((Host.ObjectID, new CargoTracker(item, 0, 1)));
					Scenario.CargoMovement.Add((activeUnit.ObjectID, new CargoTracker(item, 1, 0)));
				}
				if (!flag)
				{
					continue;
				}
				ICargoClient getCargoClient = item.GetCargoClient;
				if (getCargoClient != null && getCargoClient.IsTowable())
				{
					item.StorageType = Cargo.CargoStorageType.StoredInternal;
					ICargoHost cargoHost = (ICargoHost)activeUnit;
					if (cargoHost != null && !cargoHost.CanLoad(getCargoClient) && cargoHost.CanTow(getCargoClient))
					{
						item.StorageType = Cargo.CargoStorageType.TowedExternal;
					}
				}
			}
			if (list.Count > 0)
			{
				Cargo.UnloadCargoContainersToSupplyDump(Host, list, Target);
			}
			if (Module_ActiveUnit.IsAimpointFacility(Host) && Host.Mounts.Count == 0)
			{
				Host.ParentScen.DeleteUnitImmediately(Host.ObjectID, ScenEditAction: true, "Picked up as cargo");
				foreach (ActiveUnit activeUnits_ in Target.ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ != null && activeUnits_.AI.PrimaryPickupTarget == Host)
					{
						activeUnits_.AI.PrimaryPickupTarget = null;
					}
				}
			}
			if (Target.IsOperating() && Target.IsAircraft && Target.ThrottleSetting == ActiveUnit.Throttle.FullStop)
			{
				Target.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101370", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(Mission mission_0)
	{
		try
		{
			IEventExporter[] applicableEventExporters = myUnit.ParentScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (eventExporter.IsOperating && eventExporter.ExportDockingOps && myUnit.get_UnitSide(SetSideOnly: false) != null)
				{
					PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
					if (myUnit.ParentScen.MonteCarloIteration > 0)
					{
						pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string)));
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
					pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string)));
					pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string)));
					pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string)));
					pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string)));
					pooledDictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("Action", new IEventExporter.EventNotificationParameter("Docking", typeof(string)));
					pooledDictionary.Add("DepartureHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("DepartureHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					if (!Information.IsNothing((object)CurrentHostUnit))
					{
						pooledDictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(CurrentHostUnit.ObjectID, typeof(string)));
						pooledDictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
					}
					pooledDictionary.Add("MissionID", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.ObjectID, typeof(string)));
					pooledDictionary.Add("MissionName", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.Name, typeof(string)));
					pooledDictionary.Add("TotalFuel", new IEventExporter.EventNotificationParameter(Conversions.ToString(myUnit.FuelCapacityCurrent), typeof(int)));
					eventExporter.ExportEvent(IEventExporter.ExportedEventType.DockingOps, pooledDictionary, myUnit.ParentScen);
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
}
