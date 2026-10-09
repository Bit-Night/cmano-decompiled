using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Aircraft_DecisionChecklist : ActiveUnit_DecisionChecklist<Aircraft>
{
	private static Aircraft_Untasked_DecisionChecklist aircraft_Untasked_DecisionChecklist_0;

	private static Aircraft_ExampleMission_DecisionChecklist aircraft_ExampleMission_DecisionChecklist_0;

	private static DecisionItem[] decisionItem_0;

	static Aircraft_DecisionChecklist()
	{
		Class72.smethod_20();
		aircraft_Untasked_DecisionChecklist_0 = new Aircraft_Untasked_DecisionChecklist();
		aircraft_ExampleMission_DecisionChecklist_0 = new Aircraft_ExampleMission_DecisionChecklist();
		decisionItem_0 = new DecisionItem[7]
		{
			new DecisionItem("Is Operating", isOperating),
			new DecisionItem("Continue landing", continueLanding),
			new DecisionItem("Continue RTB", smethod_2),
			new DecisionItem("Evaluate exhaustion RTB", smethod_3),
			new DecisionItem("Evaluate emergency landing", evaluateEmergencyLanding),
			new DecisionItem("Evaluate damage RTB", evaluateDamageRTB),
			new DecisionItem("Execute mission", evaluateMission)
		};
	}

	public override DecisionItem[] getItems()
	{
		return decisionItem_0;
	}

	public override string getListName()
	{
		return "Aircraft AI";
	}

	protected static Result evaluateMission(Aircraft myAircraft, DecisionChecklist rootList)
	{
		if (myAircraft.AssignedMissionOrPackage() != null)
		{
			return aircraft_ExampleMission_DecisionChecklist_0.evaluate(myAircraft, rootList);
		}
		return aircraft_Untasked_DecisionChecklist_0.evaluate(myAircraft, rootList);
	}

	public static Result AttemptToRTB(string reason, Aircraft myAircraft, bool ManuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool DetachFromGroup, bool ClearPlottedCourse, Aircraft_AirOps._AirOpsCondition forcedAirOpsCondition = Aircraft_AirOps._AirOpsCondition.RTB)
	{
		string text = AttemptToRTB_ReturnConditionBlocking(myAircraft, ManuallyOrdered, _ActiveUnitStatus_0, DetachFromGroup, ClearPlottedCourse);
		Result result;
		if (text == null)
		{
			if (forcedAirOpsCondition != Aircraft_AirOps._AirOpsCondition.RTB)
			{
				myAircraft.AirOps.Condition = forcedAirOpsCondition;
			}
			result = new Result(_ActiveUnitStatus_0, "triggered RTB, " + reason);
		}
		else
		{
			result = new Result(null, "failed to trigger RTB, " + text);
		}
		return result;
	}

	protected static Result isOperating(Aircraft myAircraft)
	{
		Result result = (myAircraft.IsOperating() ? new Result(null, "operating") : new Result(ActiveUnit._ActiveUnitStatus.Unassigned, "not operating"));
		return result;
	}

	protected static Result smethod_2(Aircraft myAircraft)
	{
		Result result = (ActiveUnit.get_IsRTB(myAircraft.Status) ? new Result(myAircraft.Status, "continuing RTB") : new Result(null, "no RTB in progress"));
		return result;
	}

	protected static Result continueLanding(Aircraft myAircraft)
	{
		Result result = (((myAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown) | (myAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)) ? new Result(myAircraft.Status, "Landing in progress") : new Result(null, "no landing in progress"));
		return result;
	}

	protected static Result evaluateEmergencyLanding(Aircraft myAircraft)
	{
		(ActiveUnit._ActiveUnitFuelState, bool) tuple = myAircraft.IsBingoOrJoker_IsUsingTankerAsReference();
		var (activeUnitFuelState, _) = tuple;
		Result result;
		if (!tuple.Item2 && (activeUnitFuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || activeUnitFuelState == ActiveUnit._ActiveUnitFuelState.IsJoker))
		{
			Aircraft_AirOps airOps = myAircraft.AirOps;
			if (airOps.A2AR_Destination != null)
			{
				airOps.DisconnectFromTanker();
			}
			if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding && myAircraft.FuelState_DistanceToBase <= Aircraft.EMERGENCY_LANDING_DISTANCE_NM)
			{
				float num = (float)myAircraft.get_FuelEndurance(myAircraft.ThrottleSetting, (AltBand)null, (float?)myAircraft.CurrentSpeed, (float?)myAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * myAircraft.CurrentSpeed / 3600f;
				if ((double)myAircraft.FuelState_DistanceToBase >= (double)num * 1.5)
				{
					if (myAircraft.Navigator.HasPlottedCourse())
					{
						if (myAircraft.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.LandingMarshal && myAircraft.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.Land)
						{
							result = new Result(null, "no emergency landing required");
							goto IL_0136;
						}
						return AttemptToRTB("", myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, DetachFromGroup: true, ClearPlottedCourse: true, Aircraft_AirOps._AirOpsCondition.EmergencyLanding);
					}
					return AttemptToRTB("", myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, DetachFromGroup: true, ClearPlottedCourse: true, Aircraft_AirOps._AirOpsCondition.EmergencyLanding);
				}
			}
		}
		result = new Result(null, "no emergency landing required");
		goto IL_0136;
		IL_0136:
		return result;
	}

	protected static Result evaluateDamageRTB(Aircraft myAircraft)
	{
		float num = myAircraft.DamageThresholdForAbort();
		if (myAircraft.Damage.DamagePercent >= num * 100f && !myAircraft.IsBeingDestroyed && !myAircraft.IsMorituri)
		{
			Result result = AttemptToRTB("critical damage", myAircraft, ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Exhaustion, DetachFromGroup: true, ClearPlottedCourse: true);
			if (result.finalStatus.HasValue)
			{
				myAircraft.Weaponry.JettisonOrdnance(ExecuteImmediately: false, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
				return result;
			}
		}
		Result result2 = new Result(null, "critical damage threshold not reached");
		return result2;
	}

	protected static Result smethod_3(Aircraft myAircraft)
	{
		if (myAircraft.IsExhausted())
		{
			return AttemptToRTB("exausted", myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Exhaustion, DetachFromGroup: true, ClearPlottedCourse: true);
		}
		Result result = new Result(null, "not exausted");
		return result;
	}

	protected static Result smethod_4(Aircraft myAircraft)
	{
		myAircraft.FuelState = myAircraft.IsBingoOrJoker;
		Doctrine._FuelStateRTB? bingoJokerRTB = myAircraft.Doctrine.BingoJokerRTB;
		Result result = default(Result);
		if (myAircraft.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myAircraft.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
		{
			result = new Result(null, "fuel state not reached");
		}
		else
		{
			byte? b = (byte?)bingoJokerRTB;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)) == true)
			{
				return AttemptToRTB("fuel state reached", myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, bingoJokerRTB.Value == Doctrine._FuelStateRTB.YesLeaveGroup, ClearPlottedCourse: false);
			}
		}
		return result;
	}

	protected static Result evaluateWeaponStateRTB(Aircraft myAircraft)
	{
		myAircraft.WeaponState = myAircraft.Weaponry.IsWinchesterOrShotgun();
		Doctrine._WeaponStateRTB? nullable_ = myAircraft.Doctrine.WinchesterShotgunRTB;
		Result result = default(Result);
		if (myAircraft.WeaponState != ActiveUnit._ActiveUnitWeaponState.None && myAircraft.WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
		{
			byte? b = (byte?)nullable_;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)) == true)
			{
				return AttemptToRTB("weapon state reached", myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, nullable_.Value == Doctrine._WeaponStateRTB.YesLeaveGroup, ClearPlottedCourse: false);
			}
		}
		else
		{
			result = new Result(null, "weapon state not reached");
		}
		return result;
	}

	protected static Result evaluateGroupRTB(Aircraft myAircraft)
	{
		string text = AnyDoctrineRequiringRTBForGroupedUnitCondition(myAircraft);
		if (text != null)
		{
			return AttemptToRTB(text, myAircraft, ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: false);
		}
		Result result = new Result(null, "group RTB conditions not met");
		return result;
	}

	public static string AnyPhysicalConditionPreventingRTB(Aircraft myAircraft, bool ManuallyOrdered)
	{
		if (Information.IsNothing((object)myAircraft.AirOps.ActualDestinationHost))
		{
			myAircraft.AirOps.PickNewAssignedHost_Nearest();
		}
		if (Information.IsNothing((object)myAircraft.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
		{
			string text = "";
			if (Operators.CompareString(myAircraft.Name, myAircraft.UnitClass, false) != 0)
			{
				text = " (" + myAircraft.UnitClass + ")";
			}
			myAircraft.ParentScen.AddMessage(myAircraft.Name + text + " has no suitable place to land!", "Landing issue", LoggedMessage.MessageType.AirOps, 15, myAircraft.ObjectID, ((ActiveUnit)myAircraft).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myAircraft.get_Longitude((GlobalVariables.BooleanObject)null), myAircraft.get_Latitude((GlobalVariables.BooleanObject)null)));
			return "No assigned host unit found for RTB";
		}
		if (myAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.RTB && ((ActiveUnit)myAircraft).IsRTB && !ManuallyOrdered && !Information.IsNothing((object)myAircraft.AirOps.ActualDestinationHost))
		{
			return "Already in RTB";
		}
		if (((myAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue) | (myAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)) && !ManuallyOrdered && !Information.IsNothing((object)myAircraft.AirOps.ActualDestinationHost))
		{
			return "Cannot RTB, Aircraft is already landing";
		}
		if (myAircraft.IsUsingDippingSonar() && myAircraft.AirOps.ConditionTimer > 0f)
		{
			return "Cannot RTB, Unit is deploying dipping sonar";
		}
		return null;
	}

	public static string AnyOperationalConditionPreventingRTB(Aircraft myAircraft)
	{
		if (!myAircraft.Weaponry.IsGuidingWeaponsInAir() && !myAircraft.IsPaintingATarget && !myAircraft.WillNeedToPaintATarget && !myAircraft.AI.NeedToCrank())
		{
			if (myAircraft.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myAircraft.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				ActiveUnit._ActiveUnitFuelState isBingoOrJoker = myAircraft.IsBingoOrJoker;
				if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					if (myAircraft.Navigator.NextWaypointIsManual)
					{
						return "Cannot RTB, manual defined plotted course takes precedence over Winchester RTB";
					}
				}
				else if (myAircraft.Navigator.IsOnAutoPlannerPlottedCourse || (myAircraft.IsGroupWingman() && !Information.IsNothing((object)((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead) && ((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))
				{
					return "Cannot RTB, AutoPlanner plotted course takes precedence over Bingo RTB";
				}
				return null;
			}
			return "Cannot RTB, Heading to Refuel / Refueling";
		}
		return "Cannot RTB, currently guiding weapons";
	}

	public static string AnyDoctrinePreventingRTB(Aircraft myAircraft, bool ManuallyOrdered, bool rootCall = true)
	{
		try
		{
			if (((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				return null;
			}
			Doctrine._FuelStateRTB? bingoJokerRTB;
			Doctrine._WeaponStateRTB? nullable_;
			bool flag;
			bool flag2;
			int num;
			if (rootCall)
			{
				bingoJokerRTB = myAircraft.Doctrine.BingoJokerRTB;
				nullable_ = myAircraft.Doctrine.WinchesterShotgunRTB;
				ActiveUnit._ActiveUnitFuelState isBingoOrJoker = myAircraft.IsBingoOrJoker;
				flag = isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsJoker;
				ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = myAircraft.Weaponry.IsWinchesterOrShotgun();
				flag2 = activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				byte? b = (byte?)nullable_;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					num = 0;
					goto IL_0109;
				}
				b = (byte?)nullable_;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					num = 0;
					goto IL_0109;
				}
			}
			goto end_IL_0001;
			IL_0109:
			int num2 = num;
			int num3 = 0;
			foreach (ActiveUnit value in ((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).Units.Values)
			{
				if (value != null)
				{
					Aircraft aircraft = (Aircraft)value;
					if (AnyConditionsPreventingRTB(aircraft, ManuallyOrdered, rootCall: false) != null)
					{
						break;
					}
					ActiveUnit._ActiveUnitFuelState isBingoOrJoker2 = aircraft.IsBingoOrJoker;
					if (isBingoOrJoker2 == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoOrJoker2 == ActiveUnit._ActiveUnitFuelState.IsJoker)
					{
						num3++;
					}
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState2 = aircraft.Weaponry.IsWinchesterOrShotgun();
					if (activeUnitWeaponState2 == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState2 == ActiveUnit._ActiveUnitWeaponState.IsShotgun)
					{
						num2++;
					}
				}
			}
			bool? obj;
			if (flag)
			{
				byte? b = (byte?)bingoJokerRTB;
				obj = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			}
			else
			{
				obj = false;
			}
			bool? flag3 = obj;
			if ((flag3 ?? true) && ((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).Units.Count != num3 && flag3.HasValue)
			{
				return "Cannot RTB, must wait for other units in group to reach fuel state";
			}
			bool? obj2;
			if (flag2)
			{
				byte? b = (byte?)nullable_;
				obj2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			}
			else
			{
				obj2 = false;
			}
			flag3 = obj2;
			if ((flag3 ?? true) && ((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).Units.Count != num2 && flag3.HasValue)
			{
				return "Cannot RTB, must wait for other units in group to reach weapon state";
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10042321564", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public static string AnyDoctrineRequiringRTBForGroupedUnitCondition(Aircraft myAircraft)
	{
		string result = default(string);
		try
		{
			if (((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				result = null;
			}
			else
			{
				Doctrine._FuelStateRTB? bingoJokerRTB = myAircraft.Doctrine.BingoJokerRTB;
				Doctrine._WeaponStateRTB? nullable_ = myAircraft.Doctrine.WinchesterShotgunRTB;
				foreach (ActiveUnit value in ((ActiveUnit)myAircraft).get_ParentGroup(UsingMissionPlanner: false).Units.Values)
				{
					if (value != null)
					{
						Aircraft aircraft = (Aircraft)value;
						ActiveUnit._ActiveUnitFuelState isBingoOrJoker = aircraft.IsBingoOrJoker;
						byte? b = (byte?)bingoJokerRTB;
						bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2));
						if ((flag ?? true) && (isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo || isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsJoker) && flag.HasValue)
						{
							result = "first unit in group has reached fuel state";
							break;
						}
						ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = aircraft.Weaponry.IsWinchesterOrShotgun();
						b = (byte?)nullable_;
						flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2));
						if ((flag ?? true) && (activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun) && flag.HasValue)
						{
							result = "first unit in group has reached weapon state";
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
			ex2?.Data.Add("Error at 10042321567", "");
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

	public static string AnyConditionsPreventingRTB(Aircraft myAircraft, bool ManuallyOrdered, bool rootCall = true)
	{
		string result;
		try
		{
			string text = AnyPhysicalConditionPreventingRTB(myAircraft, ManuallyOrdered);
			if (text != null)
			{
				result = text;
			}
			else if (ManuallyOrdered | myAircraft.IsExhausted())
			{
				result = null;
			}
			else
			{
				string text2 = AnyOperationalConditionPreventingRTB(myAircraft);
				if (text2 != null)
				{
					result = text2;
				}
				else
				{
					string text3 = AnyDoctrinePreventingRTB(myAircraft, ManuallyOrdered, rootCall);
					result = ((text3 != null) ? text3 : null);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10042321568", "");
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

	public static string AttemptToRTB_ReturnConditionBlocking(Aircraft myAircraft, bool ManuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool DetachFromGroup, bool ClearPlottedCourse)
	{
		string text = AnyConditionsPreventingRTB(myAircraft, ManuallyOrdered);
		if (text == null)
		{
			if (smethod_5(myAircraft, _ActiveUnitStatus_0, DetachFromGroup, ClearPlottedCourse))
			{
				return null;
			}
			return "Error Encountered while issuing RTB order";
		}
		return text;
	}

	private static bool smethod_5(object object_1, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool bool_1, bool bool_2)
	{
		bool result;
		try
		{
			if (bool_1)
			{
				((ActiveUnit)object_1).DetachUnit(NotifyPlayer: false, bool_2, UseFlightplan: false);
			}
			if (((Aircraft)object_1).Navigator.HasPlottedCourse())
			{
				((Aircraft)object_1).Navigator.ClearPlottedCourse();
			}
			((Aircraft)object_1).Status = _ActiveUnitStatus_0;
			((Aircraft)object_1).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
			((Aircraft)object_1).Kinematics.DesiredSpeedOverride = null;
			((Aircraft)object_1).Kinematics.DesiredAltitudeOverride = false;
			((ActiveUnit)object_1).DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10042321569", "");
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
