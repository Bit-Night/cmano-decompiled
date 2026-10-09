using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Kinematics : ActiveUnit_Kinematics
{
	public enum G_Straining_Mode : byte
	{
		StrainingToLimit,
		Recovering
	}

	private Aircraft aircraft_0;

	private float float_1;

	internal const int MaxNegativePitchAngle = -80;

	internal float? ActualAgility_ThisPulse;

	internal G_Straining_Mode Current_G_StrainingMode;

	private float float_2;

	private float float_3;

	public int MaxPositivePitchAngle
	{
		get
		{
			float agility_Nominal = method_2().Agility_Nominal;
			if (agility_Nominal > 1f)
			{
				if (agility_Nominal <= 2f)
				{
					return 30;
				}
				if (agility_Nominal <= 3f)
				{
					return 45;
				}
				if (agility_Nominal <= 4f)
				{
					return 60;
				}
				if (agility_Nominal < 5f)
				{
					return 70;
				}
				return 80;
			}
			return 20;
		}
	}

	public float ActualAgility
	{
		get
		{
			if (ActualAgility_ThisPulse.HasValue && theSB == null)
			{
				return ActualAgility_ThisPulse.Value;
			}
			theSB?.Append(method_2().Name).Append(" has nominal agility: ").Append(method_2().Agility_Nominal)
				.Append(", ");
			float num = (float)Math.Round(method_2().Kinematics.method_3(method_2().Agility_Nominal), 1);
			theSB?.Append("adjusted for altitude: ").Append(num).Append(". ");
			GlobalVariables.ProficiencyLevel? proficiency = method_2().Proficiency;
			int? num2 = (int?)proficiency;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0)) == true)
			{
				num = (float)((double)num * 0.3);
			}
			else
			{
				num2 = (int?)proficiency;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) == true)
				{
					num = (float)((double)num * 0.5);
				}
				else
				{
					num2 = (int?)proficiency;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 2)) == true)
					{
						num = (float)((double)num * 0.8);
					}
					else
					{
						num2 = (int?)proficiency;
						if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 3)) != true)
						{
							num2 = (int?)proficiency;
							if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 4)) == true)
							{
								num = (float)((double)num * 1.2);
							}
						}
					}
				}
			}
			theSB?.Append("Agility adjusted for proficiency (" + Misc.ToEnglishString(method_2().Proficiency.Value) + "): " + Conversions.ToString(num) + ". ");
			float weightFraction = method_2().WeightFraction;
			num = (float)(0.4 * (double)num + 0.6 * (double)num * (double)(1f - weightFraction));
			theSB?.Append("Aircraft has a weight fraction of " + Conversions.ToString(Math.Round(weightFraction, 2)) + " - Agility adjusted to " + Conversions.ToString(Math.Round(num, 2)) + ". ");
			if (method_2().Damage.DamagePercent > 0f)
			{
				num = num * (100f - method_2().Damage.DamagePercent) / 100f;
				theSB?.Append("Aircraft has " + Conversions.ToString(method_2().Damage.DamagePercent) + "% fuselage/structural damage - Agility adjusted to " + Conversions.ToString(Math.Round(num, 2)) + ". ");
			}
			if (num == 0f)
			{
				num = 0.01f;
			}
			ActualAgility_ThisPulse = num;
			return num;
		}
	}

	public bool IsInCombatManouvers
	{
		get
		{
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				return false;
			}
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				return false;
			}
			return true;
		}
	}

	public int CornerVelocity => (int)Math.Round(1.5 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false));

	public override float ClimbRate_Nominal
	{
		get
		{
			float_1 = (float)(0.4 * (double)_ClimbRate + 0.6 * (double)_ClimbRate * (double)(1f - method_2().WeightFraction));
			double num = (double)method_2().Propulsion.Where([SpecialName] (Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() / (double)method_2().Propulsion.Count;
			float_1 = (float)((double)float_1 * num);
			if (LimitByTrueAirspeed && !method_2().get_CanHover(bool_7: true) && (double)float_1 > (double)method_2().CurrentSpeed * 0.514444)
			{
				float_1 = (float)((double)method_2().CurrentSpeed * 0.514444);
			}
			if (!float.IsNaN(float_1))
			{
				return float_1;
			}
			return 0f;
		}
		set
		{
			base.set_ClimbRate_Nominal(LimitByTrueAirspeed: true, value);
		}
	}

	[SpecialName]
	private Aircraft method_2()
	{
		if (aircraft_0 == null)
		{
			aircraft_0 = (Aircraft)myUnit;
		}
		return aircraft_0;
	}

	public Aircraft_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void DetermineReserveFuelQty(bool Deserializing = false)
	{
		try
		{
			PooledList<FuelRec> fuel_ReadOnly = myUnit.Fuel_ReadOnly;
			float num = default(float);
			foreach (FuelRec item in fuel_ReadOnly)
			{
				num += (float)item.MaxQuantity;
			}
			fuel_ReadOnly.Dispose();
			int reservePercentage = default(int);
			int reserveLoiterTime = default(int);
			float reserveLoiterAltitude = default(float);
			if (method_2().Loadout != null && method_2().Loadout.get_MissionProfile(method_2().ParentScen) != null)
			{
				reservePercentage = method_2().Loadout.get_MissionProfile(myUnit.ParentScen).ReservePercentage;
				reserveLoiterTime = method_2().Loadout.get_MissionProfile(myUnit.ParentScen).ReserveLoiterTime;
				reserveLoiterAltitude = method_2().Loadout.get_MissionProfile(myUnit.ParentScen).ReserveLoiterAltitude;
			}
			float num2 = default(float);
			if (reservePercentage > 0)
			{
				num2 = (float)((double)num * ((double)reservePercentage / 100.0));
			}
			if (reserveLoiterTime > 0 && reserveLoiterAltitude > 0f)
			{
				num2 += myUnit.FuelConsumption(ActiveUnit.Throttle.Loiter, null, GetMaximumSpeed(reserveLoiterAltitude, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false), reserveLoiterAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: true, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) * 60f * (float)reserveLoiterTime;
			}
			myUnit.Kinematics.ReserveFuel = num2;
			if (Deserializing)
			{
				myUnit.Kinematics.JokerFuel = 0f;
				return;
			}
			float num3 = num - num2;
			Doctrine._FuelState? bingoJoker = myUnit.Doctrine.BingoJoker;
			byte? b = (byte?)bingoJoker;
			float jokerFuel;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				jokerFuel = 0f;
			}
			else
			{
				b = (byte?)bingoJoker;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
				{
					b = (byte?)bingoJoker;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
					{
						jokerFuel = (float)((double)num3 * 0.2);
					}
					else
					{
						b = (byte?)bingoJoker;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
						{
							b = (byte?)bingoJoker;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) != true)
							{
								b = (byte?)bingoJoker;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
								{
									b = (byte?)bingoJoker;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 6)) == true)
									{
										jokerFuel = (float)((double)num3 * 0.5);
									}
									else
									{
										b = (byte?)bingoJoker;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 7)) == true)
										{
											jokerFuel = (float)((double)num3 * 0.6);
										}
										else
										{
											b = (byte?)bingoJoker;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 8)) == true)
											{
												jokerFuel = (float)((double)num3 * 0.7);
											}
											else
											{
												b = (byte?)bingoJoker;
												if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 9)) != true)
												{
													b = (byte?)bingoJoker;
													if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 10)) != true)
													{
														b = (byte?)bingoJoker;
														jokerFuel = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 11)) == true) ? ((float)((double)num3 * 0.9)) : 0f);
													}
													else
													{
														jokerFuel = (float)((double)num3 * 0.8);
													}
												}
												else
												{
													jokerFuel = (float)((double)num3 * 0.75);
												}
											}
										}
									}
								}
								else
								{
									jokerFuel = (float)((double)num3 * 0.4);
								}
							}
							else
							{
								jokerFuel = (float)((double)num3 * 0.3);
							}
						}
						else
						{
							jokerFuel = (float)((double)num3 * 0.25);
						}
					}
				}
				else
				{
					jokerFuel = (float)((double)num3 * 0.1);
				}
			}
			myUnit.Kinematics.JokerFuel = jokerFuel;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200446", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (method_2().Loadout != null)
			{
				GameGeneral.SendMessageBoxToUI("Loadout " + method_2().Loadout.Name + " for aircraft " + method_2().Name + " (" + method_2().UnitClass + ") does not exist in the selected database. Please select a new loadout for this aircraft.", ((ActiveUnit)method_2()).get_UnitSide(SetSideOnly: false));
			}
			else
			{
				GameGeneral.SendMessageBoxToUI("The loadout for aircraft " + method_2().Name + " (" + method_2().UnitClass + ") is nothing.", ((ActiveUnit)method_2()).get_UnitSide(SetSideOnly: false));
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float TacticalRadius()
	{
		if (_TacticalRadius > 0f)
		{
			return _TacticalRadius;
		}
		_TacticalRadius = MaxRadius();
		return _TacticalRadius;
	}

	public override float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		float result;
		try
		{
			ActiveUnit.Throttle throttle = default(ActiveUnit.Throttle);
			if (Information.IsNothing((object)theSpeed))
			{
				throttle = (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) ? ActiveUnit.Throttle.Cruise : ((myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike) ? ActiveUnit.Throttle.Cruise : ((((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept) ? ActiveUnit.Throttle.Cruise : ActiveUnit.Throttle.Full)));
			}
			if (Information.IsNothing((object)theAltitude))
			{
				theAltitude = myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(throttle).MaxAlt;
			}
			if (Information.IsNothing((object)theSpeed))
			{
				theSpeed = GetMaximumSpeed(theAltitude.Value, throttle, ValidateAndFixAltitude: false);
			}
			double num = MaxEndurance(throttle, theSpeed, theAltitude, BingoFuelCheck, 0f);
			float? num2 = theSpeed;
			bool? flag = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f));
			result = ((((!flag) ?? false) || !double.IsInfinity(num) || !flag.HasValue) ? ((float)(num * (double?)theSpeed / 3600.0).Value) : 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100451", "");
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

	public override float MaxRadius()
	{
		float result;
		try
		{
			ActiveUnit.Throttle throttle;
			ActiveUnit.Throttle throttle2;
			if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				throttle = ActiveUnit.Throttle.Cruise;
				throttle2 = ActiveUnit.Throttle.Cruise;
			}
			else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				if (((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept)
				{
					throttle = ActiveUnit.Throttle.Cruise;
					throttle2 = ActiveUnit.Throttle.Cruise;
				}
				else
				{
					throttle = ActiveUnit.Throttle.Full;
					throttle2 = ActiveUnit.Throttle.Cruise;
				}
			}
			else
			{
				throttle = ActiveUnit.Throttle.Cruise;
				throttle2 = ActiveUnit.Throttle.Cruise;
			}
			ref Scenario parentScen = ref myUnit.ParentScen;
			Aircraft theAC = method_2();
			float theFormUpFuel = MissionPlanner.FormUpFuelQty(ref parentScen, ref theAC);
			double num = MaxEndurance(throttle, null, null, BingoFuelCheck: false, theFormUpFuel);
			double num2 = MaxEndurance(throttle2, null, null, BingoFuelCheck: true, theFormUpFuel);
			double num3 = (num + num2) / 2.0;
			result = ((throttle != throttle2) ? ((float)(num3 / 2.0 * ((double)GetMaximumSpeed(myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(throttle).MaxAlt, throttle, ValidateAndFixAltitude: false) / 3600.0 + (double)GetMaximumSpeed(myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(throttle2).MaxAlt, throttle2, ValidateAndFixAltitude: false) / 3600.0)) / 2f) : ((float)(num3 / 2.0 * (double)GetMaximumSpeed(myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(throttle).MaxAlt, throttle, ValidateAndFixAltitude: false) / 3600.0)));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100451", "");
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

	public new double MaxEndurance(ActiveUnit.Throttle theThrottleSetting, float? theSpeed, float? theAltitude, bool BingoFuelCheck, float theFormUpFuel)
	{
		double result;
		try
		{
			PooledList<FuelRec> fuel_ReadOnly = myUnit.Fuel_ReadOnly;
			float num = default(float);
			foreach (FuelRec item in fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			fuel_ReadOnly.Dispose();
			num -= myUnit.Kinematics.ReserveFuel;
			num -= theFormUpFuel;
			if (num < 0f)
			{
				result = 0.0;
			}
			else
			{
				AltBand theAltBand = null;
				if (!theAltitude.HasValue)
				{
					theAltBand = myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(theThrottleSetting);
				}
				result = num / myUnit.FuelConsumption(theThrottleSetting, theAltBand, theSpeed, theAltitude, BingoFuelCheck, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100452", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? theFuelStateDoctrine)
	{
		PooledList<FuelRec> pooledList = null;
		float result;
		try
		{
			pooledList = myUnit.Fuel_ReadOnly;
			float num = default(float);
			foreach (FuelRec item in pooledList)
			{
				num += item.CurrentQuantity;
			}
			num -= myUnit.Kinematics.ReserveFuel;
			float num2 = num - myUnit.Kinematics.JokerFuel;
			if (!(num < 0f))
			{
				goto IL_00f6;
			}
			byte? b = (byte?)theFuelStateDoctrine;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
			{
				goto IL_00f6;
			}
			method_2().FuelState_RemainingFuelToBingo = 0f;
			method_2().FuelState_RemainingFuelToJoker = 0f;
			result = 0f;
			goto end_IL_0002;
			IL_00f6:
			Aircraft_Navigator navigator = method_2().Navigator;
			ActiveUnit.Throttle throttle = navigator.GetBingoFuelThrottle();
			ActiveUnit.Throttle maxPossibleThrottleSetting = myUnit.MaxPossibleThrottleSetting;
			if (throttle > maxPossibleThrottleSetting)
			{
				throttle = maxPossibleThrottleSetting;
			}
			bool theAltitude_TerrainFollowing = false;
			float num3 = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
			float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
			if (num3 > maximumAltitude)
			{
				num3 = maximumAltitude;
			}
			int maximumSpeed = GetMaximumSpeed(num3, throttle, ValidateAndFixAltitude: false);
			float num4 = myUnit.FuelConsumption(throttle, null, maximumSpeed, num3, BingoFuelCheck: true, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			float num5 = num / num4;
			float num6 = num2 / num4;
			float num7 = num5 * (float)maximumSpeed / 3600f;
			float num8 = num6 * (float)maximumSpeed / 3600f;
			double num9 = num7 - method_2().FuelState_DistanceToBase;
			double num10 = num8 - method_2().FuelState_DistanceToBase;
			method_2().FuelState_RemainingFuelToBingo = Math.Max((float)(num9 / (double)num7) * num, 0f);
			method_2().FuelState_RemainingFuelToJoker = Math.Max((float)(num10 / (double)num8) * num2, 0f);
			b = (byte?)theFuelStateDoctrine;
			result = ((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true) ? num8 : num7);
			end_IL_0002:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100453", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
		}
		return result;
	}

	public override void Loiter(float elapsedTime, bool UseFormUpAltitude = false, bool UseLandingQueueAltitude = false)
	{
		try
		{
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(myUnit.CurrentHeading + 3f * elapsedTime));
			myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
			myUnit.LoiteredThisPulse = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100454", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MatchTankerSpeedAndAltitude()
	{
		Aircraft a2AR_Destination = method_2().AirOps.A2AR_Destination;
		if (!Information.IsNothing((object)a2AR_Destination))
		{
			method_2().set_Latitude((GlobalVariables.BooleanObject)null, a2AR_Destination.get_Latitude((GlobalVariables.BooleanObject)null));
			method_2().set_Longitude((GlobalVariables.BooleanObject)null, a2AR_Destination.get_Longitude((GlobalVariables.BooleanObject)null));
			method_2().set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, a2AR_Destination.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 4.572f);
			method_2().CurrentHeading = a2AR_Destination.CurrentHeading;
			method_2().CurrentSpeed = a2AR_Destination.CurrentSpeed;
		}
	}

	public void CheckForSinkingCondition(float elapsedTime)
	{
		if (!method_2().IsHelicopter && method_2().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
		{
			double num = (double)GetMaximumSpeed(method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false) * Math.Cos((double)method_2().Attitude_Roll * 0.0174532925199433);
			if ((double)method_2().CurrentSpeed < num)
			{
				method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) -= (float)(9.81 * (double)elapsedTime * (1.0 - (double)method_2().CurrentSpeed / num));
			}
		}
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		if (!myUnit.IsOperating())
		{
			return;
		}
		if (((myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) | (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)) && myUnit.Navigator.HasFlightPlan)
		{
			Waypoint waypoint = myUnit.Navigator.PlottedCourse.FirstOrDefault();
			if (waypoint != null && waypoint.Category == Waypoint.WaypointCategory.FlightPlan && myUnit.Navigator.HaveReachedPoint(waypoint, elapsedTime, Overshoot: false, simplify_calc_for_ACs: false, 5f))
			{
				myUnit.Navigator.RemoveWaypoint_Soft(waypoint, RemoveWingmanWaypoints: true);
			}
		}
		try
		{
			Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
			Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
			AdjustAttitude_Roll(elapsedTime);
			if (float.IsNaN(myUnit.CurrentHeading))
			{
				myUnit.CurrentHeading = 0f;
			}
			if (float.IsNaN(myUnit.DesiredHeading))
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
			}
			if (method_2().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				MatchTankerSpeedAndAltitude();
				ThrottlePreset = UnitThrottlePreset.None;
				method_2().SetThrottle(ActiveUnit.Throttle.FullStop, method_2().CurrentSpeed);
			}
			else if (method_2().Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || !myUnit.IsGroupWingman() || method_2().AirOps.A2AR_Destination == null || myUnit.get_Latitude((GlobalVariables.BooleanObject)null) != method_2().AirOps.A2AR_Destination.get_Latitude((GlobalVariables.BooleanObject)null) || myUnit.get_Longitude((GlobalVariables.BooleanObject)null) != method_2().AirOps.A2AR_Destination.get_Longitude((GlobalVariables.BooleanObject)null))
			{
				if (myUnit.IsMCMPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMCMPlatform();
				}
				if (method_2().IsMCMPlatform_ThisPulse != 0)
				{
					bool flag = false;
					if (!((ActiveUnit)method_2()).IsRTB || method_2().Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						Sensor[] sensors_Cached = myUnit.Sensors_Cached;
						foreach (Sensor sensor in sensors_Cached)
						{
							if ((sensor.IsMineCountermeasure || sensor.IsMineHuntingSensor) && sensor.IsActive())
							{
								flag = true;
								break;
							}
						}
					}
					if (flag && myUnit.DesiredAltitude > 76.200005f)
					{
						myUnit.DesiredAltitude = 76.200005f;
						myUnit.DesiredSpeed = 30f;
					}
				}
			}
			if (myUnit.DesiredSpeed < 0f)
			{
				myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
			}
			(bool, short?) tuple = Terrain.PointIsOverland(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			var (flag2, _) = tuple;
			int? num = default(int?);
			if (tuple.Item2.HasValue)
			{
				num = tuple.Item2.Value;
			}
			bool flag3 = false;
			int? num2 = default(int?);
			if (!flag2)
			{
				num2 = ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, elapsedTime);
				if (num2.Value > 0)
				{
					flag3 = true;
				}
				else
				{
					num2 = ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, elapsedTime);
					if (num2.Value > 0)
					{
						flag3 = true;
					}
				}
			}
			else
			{
				flag3 = true;
			}
			myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			bool flag4 = false;
			if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				goto IL_03a7;
			}
			int num3;
			if (flag3)
			{
				num3 = 1;
			}
			else
			{
				if (myUnit.DesiredAltitude == myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					goto IL_03a7;
				}
				num3 = 1;
			}
			flag4 = (byte)num3 != 0;
			goto IL_046c;
			IL_03e3:
			if (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				goto IL_0447;
			}
			int num4;
			if (flag3)
			{
				num4 = 1;
			}
			else
			{
				if (myUnit.DesiredAltitude_AGL == myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					goto IL_0447;
				}
				num4 = 1;
			}
			flag4 = (byte)num4 != 0;
			goto IL_046c;
			IL_06c6:
			bool flag5;
			if (flag5)
			{
				if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None)
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
				else
				{
					myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
			}
			goto IL_077a;
			IL_046c:
			if (method_2().SupportsAttitude_Pitch && myUnit.DesiredPitch != myUnit.Attitude_Pitch)
			{
				flag4 = true;
			}
			if (flag4)
			{
				bool flag6;
				float desiredAltitude_AGL;
				if (myUnit.IsGroupWingman() && !myUnit.Navigator.IsManouveringToFormationStation && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && !myUnit.Kinematics.DesiredAltitudeOverride)
				{
					flag6 = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
					desiredAltitude_AGL = myUnit.DesiredAltitude_AGL;
				}
				else
				{
					flag6 = myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit);
					desiredAltitude_AGL = myUnit.DesiredAltitude_AGL;
				}
				float theDesiredAlt;
				if (flag6)
				{
					if (!num2.HasValue)
					{
						num2 = ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, elapsedTime);
					}
					if (!num.HasValue)
					{
						num = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
					}
					float num5 = Math.Max(num.Value, num2.Value);
					theDesiredAlt = desiredAltitude_AGL + num5;
				}
				else
				{
					theDesiredAlt = myUnit.DesiredAltitude;
				}
				if (method_2().IsUsingDippingSonar())
				{
					theDesiredAlt = 16f;
				}
				float? minimumSafeAltitude = default(float?);
				if (CheckForMinimumSafeHeight && method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation)
				{
					minimumSafeAltitude = method_2().get_MinimumSafeHeight(bool_7: false);
				}
				if (method_2().SupportsAttitude_Pitch)
				{
					AdjustAttitude_Pitch(elapsedTime);
				}
				ChangeAltitude(elapsedTime, theDesiredAlt, minimumSafeAltitude, DoSanityCheck: true);
			}
			if (myUnit.AI.HoldPosition)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
			else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				flag5 = true;
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)myUnit.AirOps;
				int num6;
				if (myUnit.Navigator.IsManouveringToFormationStation)
				{
					num6 = 0;
				}
				else if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					if (aircraft_AirOps.RefuellingQueue.Count + aircraft_AirOps.A2AR_Connections.Count <= 0)
					{
						goto IL_06c6;
					}
					num6 = 0;
				}
				else
				{
					num6 = 0;
				}
				flag5 = (byte)num6 != 0;
				goto IL_06c6;
			}
			goto IL_077a;
			IL_0447:
			if (method_2().IsUsingDippingSonar() && method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)Aircraft_AirOps.HelicopterDippingSonarAltitude)
			{
				flag4 = true;
			}
			goto IL_046c;
			IL_03a7:
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				goto IL_03e3;
			}
			int num7;
			if (!flag3)
			{
				if (myUnit.DesiredAltitude_AGL == myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					goto IL_03e3;
				}
				num7 = 1;
			}
			else
			{
				num7 = 1;
			}
			flag4 = (byte)num7 != 0;
			goto IL_046c;
			IL_0974:
			bool flag7;
			double num8;
			if (!flag7 && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(elapsedTime, (float)num8);
			}
			myUnit.updateLastReportedInfo();
			if (!SimplifiedCalcs_DLZ || GhostMovement)
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
			goto end_IL_00ae;
			IL_077a:
			float num9 = GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: true);
			if (myUnit.DesiredSpeed > num9)
			{
				myUnit.DesiredSpeed = num9;
			}
			double num10 = myUnit.CurrentHeading;
			if (myUnit.CurrentHeading != myUnit.DesiredHeading)
			{
				TurnToDesiredHeading(elapsedTime);
			}
			else
			{
				ActualMovementVector = myUnit.CurrentHeading;
			}
			if (myUnit.CurrentSpeed != 0f)
			{
				myUnit.ActualHorizMovement(elapsedTime, SimplifiedCalcs_DLZ);
			}
			num8 = (double)Math.Abs(MathFunctions.AngularDifference((float)num10, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
			CalcTurnDeceleration(num8, elapsedTime);
			flag7 = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num10) != (int)Math.Round(myUnit.CurrentHeading))
			{
				int num11;
				if (!myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					num11 = 1;
				}
				else
				{
					int? num12 = (int?)myUnit.Navigator.PreviousWaypointType;
					if (((!num12.HasValue) ? ((bool?)null) : new bool?(num12 != 15)) != true)
					{
						goto IL_0974;
					}
					num11 = 1;
				}
				flag7 = (byte)num11 != 0;
			}
			goto IL_0974;
			end_IL_00ae:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100455", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (method_2().Loadout != null)
		{
			WeaponRec[] weapons = method_2().Loadout.Weapons;
			for (int j = 0; j < weapons.Length; j = checked(j + 1))
			{
				Weapon weapon = weapons[j].get_ReferenceWeapon(method_2().ParentScen);
				weapon.set_Longitude((GlobalVariables.BooleanObject)null, method_2().get_Longitude((GlobalVariables.BooleanObject)null));
				weapon.set_Latitude((GlobalVariables.BooleanObject)null, method_2().get_Latitude((GlobalVariables.BooleanObject)null));
				weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				weapon.CurrentHeading = method_2().CurrentHeading;
				weapon.CurrentSpeed = method_2().CurrentSpeed;
			}
		}
		myUnit.updateLastReportedInfo();
	}

	public override float HorizMovementDistanceOnThisTime(float elapsedTime)
	{
		if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
		{
			return myUnit.CurrentSpeed / 3600f * elapsedTime;
		}
		return Module_Unit.CurrentSpeed_Horizontal(myUnit) / 3600f * elapsedTime;
	}

	public override void ChangeAltitude(float elapsedTime, float theDesiredAlt, float? MinimumSafeAltitude, bool DoSanityCheck)
	{
		try
		{
			myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			bool flag;
			if (!(flag = myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit)) && myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				flag = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
			}
			((Aircraft)myUnit).Kinematics.CheckForSinkingCondition(elapsedTime);
			if (!method_2().AI.CalculatedDesiredPitchThisPulse)
			{
				((Aircraft)myUnit).AI.CalculateDesiredPitch(null, elapsedTime, theDesiredAlt);
			}
			float attitude_Pitch = method_2().Attitude_Pitch;
			float num2 = ClimbRate_Actual(attitude_Pitch) * elapsedTime;
			float num3 = DiveRate_Actual(attitude_Pitch) * elapsedTime;
			if ((num2 > 0f) & (theDesiredAlt > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
			{
				if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(theDesiredAlt < MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					theDesiredAlt = MinimumSafeAltitude.Value;
				}
				if (!myUnit.SupportsAttitude_Pitch)
				{
					num = ((!(theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= num2)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num2) : theDesiredAlt);
				}
				else if (theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= num2 && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt <= num3 && myUnit.Attitude_Pitch < 3f && myUnit.Attitude_Pitch > 0f)
				{
					num = theDesiredAlt;
					myUnit.Attitude_Pitch = 0f;
				}
				else
				{
					num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num2;
				}
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
			}
			else if ((num3 > 0f) & (theDesiredAlt < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
			{
				if (!method_2().HasLostControlPulse_CACHED && MinimumSafeAltitude.HasValue && ((!MinimumSafeAltitude.HasValue) ? ((bool?)null) : new bool?(theDesiredAlt < MinimumSafeAltitude.GetValueOrDefault())) == true)
				{
					theDesiredAlt = MinimumSafeAltitude.Value;
				}
				if (!myUnit.SupportsAttitude_Pitch)
				{
					num = ((!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt <= num3)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3) : theDesiredAlt);
				}
				else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt <= num3 && theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= num2 && myUnit.Attitude_Pitch > -3f && myUnit.Attitude_Pitch < 0f)
				{
					num = theDesiredAlt;
					myUnit.Attitude_Pitch = 0f;
				}
				else
				{
					num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3;
				}
				if (!method_2().HasLostControlPulse_CACHED && MinimumSafeAltitude.HasValue && ((!MinimumSafeAltitude.HasValue) ? ((bool?)null) : new bool?(num <= MinimumSafeAltitude.GetValueOrDefault())) == true)
				{
					myUnit.Attitude_Pitch = 0f;
				}
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
			}
			else if (myUnit.SupportsAttitude_Pitch)
			{
				if (!flag)
				{
					if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.DesiredAltitude == 0f)
					{
						myUnit.DesiredPitch = 0f;
					}
				}
				else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.DesiredAltitude_AGL + (float)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen) == 0f)
				{
					myUnit.DesiredPitch = 0f;
				}
				if (!method_2().HasLostControlPulse_CACHED && MinimumSafeAltitude.HasValue)
				{
					float num4 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if ((MinimumSafeAltitude.HasValue ? new bool?(num4 <= MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
					{
						myUnit.Attitude_Pitch = 0f;
						myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, MinimumSafeAltitude.Value);
						goto IL_050d;
					}
				}
				if (myUnit.Attitude_Pitch > 0f)
				{
					num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num2;
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
				}
				else if (myUnit.Attitude_Pitch < 0f)
				{
					num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3;
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
				}
			}
			goto IL_050d;
			IL_050d:
			float maximumAltitude = GetMaximumAltitude();
			if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
			{
				myUnit.DesiredPitch = -45f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100196", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		float num = (float)((double)method_2().Agility_Nominal * 0.05 * (double)GetMaximumSpeed(theAltitude, theThrottle, ValidateAndFixAltitude: false));
		switch (myUnit.Propulsion[0].Type)
		{
		case Engine.EngineType.Turbojet:
		case Engine.EngineType.Turbofan:
			num = (float)(1.2 * (double)num);
			break;
		case Engine.EngineType.Turboprop:
		case Engine.EngineType.Turboshaft:
			num = (float)(0.8 * (double)num);
			break;
		}
		return num;
	}

	public override float PitchRate_Negative()
	{
		return this.get_ActualAgility((StringBuilder)null) * 2f;
	}

	public override float PitchRate_Positive()
	{
		return this.get_ActualAgility((StringBuilder)null) * 4f;
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		int result;
		if (!float.IsNaN(Altitude))
		{
			AltBand altBand = null;
			AltBand altBand2 = null;
			Engine engine = null;
			try
			{
				if (ThrottleSetting != ActiveUnit.Throttle.FullStop)
				{
					if (myUnit.Propulsion.Count == 0)
					{
						result = 0;
					}
					else
					{
						altBand = GetCurrentAltBand_CurrentAltitude(Altitude, null, ValidateAndFixAltitude: false);
						if (altBand == null)
						{
							result = 0;
						}
						else
						{
							foreach (Engine item in myUnit.Propulsion)
							{
								if (item.Status == PlatformComponent._ComponentStatus.Operational)
								{
									engine = item;
									break;
								}
							}
							if (engine == null)
							{
								result = 0;
							}
							else
							{
								AltBand[] altBands = engine.AltBands;
								if (altBands.Length == 0)
								{
									result = 0;
								}
								else
								{
									float num = default(float);
									switch (ThrottleSetting)
									{
									case ActiveUnit.Throttle.FullStop:
										num = 0f;
										break;
									case ActiveUnit.Throttle.Loiter:
										num = altBand.Speed_Loiter;
										break;
									case ActiveUnit.Throttle.Cruise:
										num = ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise));
										break;
									case ActiveUnit.Throttle.Full:
										num = ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value));
										break;
									case ActiveUnit.Throttle.Flank:
										num = ((!altBand.Speed_Flank.HasValue) ? (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)) : ((float)altBand.Speed_Flank.Value));
										break;
									}
									if (num == 0f)
									{
										num = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise))));
									}
									int num2 = (int)Math.Round(num);
									if (altBand != HighestAltBand(engine))
									{
										PooledList<AltBand> pooledList = new PooledList<AltBand>(Pools<AltBand>.Local);
										AltBand[] array = altBands;
										foreach (AltBand altBand3 in array)
										{
											if (altBand3 != null && altBand3.MinAlt >= altBand.MaxAlt)
											{
												pooledList.Add(altBand3);
											}
										}
										if (pooledList.Count > 1)
										{
											pooledList.Sort(new AltBandComparer_SortyByMaxAltAscending());
										}
										if (pooledList.Count > 0)
										{
											altBand2 = pooledList[0];
										}
										pooledList.Dispose();
										if (altBand2 != null)
										{
											float num3 = default(float);
											switch (ThrottleSetting)
											{
											case ActiveUnit.Throttle.FullStop:
												num3 = 0f;
												break;
											case ActiveUnit.Throttle.Loiter:
												num3 = altBand2.Speed_Loiter;
												break;
											case ActiveUnit.Throttle.Cruise:
												num3 = altBand2.Speed_Cruise;
												break;
											case ActiveUnit.Throttle.Full:
												num3 = (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise));
												break;
											case ActiveUnit.Throttle.Flank:
												num3 = (altBand2.Speed_Flank.HasValue ? ((float)altBand2.Speed_Flank.Value) : (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise)));
												break;
											}
											num2 = (int)Math.Round(num3 + (Altitude - altBand2.MinAlt) * (num - num3) / (altBand.MinAlt - altBand2.MinAlt));
										}
									}
									if (ConsiderDamage)
									{
										int num4 = 0;
										foreach (Engine item2 in method_2().Propulsion)
										{
											if (item2.Status == PlatformComponent._ComponentStatus.Operational)
											{
												num4++;
											}
										}
										double num5 = (double)num4 / (double)method_2().Propulsion.Count;
										if (num5 < 1.0)
										{
											num2 = (int)Math.Round((double)num2 * Math.Sqrt(num5));
										}
									}
									num2 = (int)Math.Round(ActiveUnit_Kinematics.RoundAircraftSpeed(num2));
									result = num2;
								}
							}
						}
					}
				}
				else
				{
					result = 0;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101340", "");
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
				result = num6;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public override float RollRate()
	{
		float num = this.get_ActualAgility((StringBuilder)null);
		if (num > 4f)
		{
			return 270f;
		}
		if (num > 3f)
		{
			return 180f;
		}
		if (num > 2f)
		{
			return 90f;
		}
		if (num > 1f)
		{
			return 45f;
		}
		return 20f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		float result;
		try
		{
			float num = Acceleration_Nominal(theThrottle, theAltitude);
			float num2 = Math.Min(1f, theSpeed / (float)GetMaximumSpeed(theAltitude, theThrottle, ValidateAndFixAltitude: false));
			float num3 = (float)((double)num * Math.Pow(1f - num2, 2.0));
			float num4 = theAltitude / myUnit.Kinematics.GetMaximumAltitude();
			switch (myUnit.Propulsion[0].Type)
			{
			case Engine.EngineType.Turbofan:
				num3 = (float)((double)num3 * (1.5 - (double)(num4 / 2f)));
				break;
			case Engine.EngineType.Turbojet:
				num3 *= 1f + num4 / 2f;
				break;
			}
			double num5 = (double)method_2().Propulsion.Where([SpecialName] (Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() / (double)method_2().Propulsion.Count;
			num3 = (float)((double)num3 * num5 * num5);
			num3 = (float)(0.75 * (double)num3 + 0.25 * (double)num3 * (double)(1f - method_2().WeightFraction));
			result = num3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100456", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = Acceleration_Nominal(theThrottle, theAltitude);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void CalcTurnDeceleration(double ActualTurnRate, float elapsedTime)
	{
		try
		{
			if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation && (long)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) > 5L)
			{
				float num = (float)(0.6 * ActualTurnRate * Math.Pow(Physics.ComputeMach(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed), 3.0) * (double)elapsedTime);
				myUnit.CurrentSpeed -= num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100457", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override double GetDecelerationCapacity(float _Altitude, float _Speed, float elapsedTime)
	{
		double num = 2.0;
		double num2 = 125.0 / 308.0;
		float num3 = Physics.CalculateStandardAirDensity((int)Math.Round(_Altitude));
		double num4 = 0.04 * (double)Acceleration_Nominal(ActiveUnit.Throttle.Full, 0f) * (double)(_Speed / (float)myUnit.Kinematics.GetMaximumSpeed()) * (double)elapsedTime;
		num4 *= 1.0 + Math.Min(num * (num2 * (double)num3), num);
		if (method_2().get_CanHover(bool_7: true))
		{
			num4 = Math.Max(num4, 10f * elapsedTime);
		}
		return num4;
	}

	public float Estimate_Gs()
	{
		if (method_2().Attitude_Roll > 0f && MathFunctions.AngularDifference(method_2().CurrentHeading, ((ActiveUnit)method_2()).DesiredHeading) < 0f)
		{
			return 0f;
		}
		if (method_2().Attitude_Roll < 0f && MathFunctions.AngularDifference(method_2().CurrentHeading, ((ActiveUnit)method_2()).DesiredHeading) > 0f)
		{
			return 0f;
		}
		float attitude_Roll = method_2().Attitude_Roll;
		if (attitude_Roll >= 83.6f)
		{
			return 9f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 82.8f)
		{
			return 8f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 81.8f)
		{
			return 7f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 80.4f)
		{
			return 6f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 78.5f)
		{
			return 5f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 75.5f)
		{
			return 4f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 70.6f)
		{
			return 3f * (method_2().Agility_Nominal / 5f);
		}
		if (attitude_Roll >= 60f)
		{
			return 2f * (method_2().Agility_Nominal / 5f);
		}
		return method_2().Agility_Nominal / 5f;
	}

	public override void TurnToDesiredHeading(float elapsedTime)
	{
		try
		{
			double num;
			if (!IsInCombatManouvers)
			{
				num = ((myUnit.Navigator.get_Flight(HierarchySearch: true) == null) ? ((double)(TurnRate() * elapsedTime)) : ((double)(ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed) * elapsedTime)));
				method_2().G_StrainAccumulated = Math.Max(0f, method_2().G_StrainAccumulated - 3f * elapsedTime);
			}
			else
			{
				method_2().G_StrainAccumulated = Math.Max(0f, method_2().G_StrainAccumulated - 3f * elapsedTime);
				switch (Current_G_StrainingMode)
				{
				case G_Straining_Mode.Recovering:
					if ((double)method_2().G_StrainAccumulated < (double)method_2().G_Tolerance * 0.25)
					{
						Current_G_StrainingMode = G_Straining_Mode.StrainingToLimit;
					}
					break;
				case G_Straining_Mode.StrainingToLimit:
				{
					float num2 = Estimate_Gs();
					method_2().G_StrainAccumulated += num2 * elapsedTime;
					if (method_2().G_StrainAccumulated >= method_2().G_Tolerance)
					{
						Current_G_StrainingMode = G_Straining_Mode.Recovering;
					}
					break;
				}
				}
				if ((method_2().Attitude_Roll > 0f && MathFunctions.AngularDifference(method_2().CurrentHeading, ((ActiveUnit)method_2()).DesiredHeading) < 0f) || (method_2().Attitude_Roll < 0f && MathFunctions.AngularDifference(method_2().CurrentHeading, ((ActiveUnit)method_2()).DesiredHeading) > 0f))
				{
					return;
				}
				num = Math.Abs(method_2().Attitude_Roll) / 89f * TurnRate() * elapsedTime;
			}
			ActiveUnit groupLead2;
			if (!myUnit.Navigator.HasPlottedCourse())
			{
				if (myUnit.IsGroupWingman())
				{
					ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					if (groupLead != null && groupLead.Navigator.HasPlottedCourse())
					{
						groupLead2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
						goto IL_020f;
					}
				}
				groupLead2 = myUnit;
			}
			else
			{
				groupLead2 = myUnit;
			}
			goto IL_020f;
			IL_020f:
			Waypoint[] plottedCourse = groupLead2.Navigator.PlottedCourse;
			Waypoint waypoint;
			bool? flag;
			if (plottedCourse.Length > 0 && ((groupLead2.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse) | (groupLead2.Status == ActiveUnit._ActiveUnitStatus.OnSupportMission)))
			{
				waypoint = plottedCourse.FirstOrDefault();
				flag = ((waypoint != null) ? new bool?(waypoint.Type == Waypoint.WaypointType.StationEnd) : ((bool?)null));
				int? num3;
				if (flag ?? true)
				{
					num3 = (int?)groupLead2.Navigator.PreviousWaypointType;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 21)) == true && flag.HasValue)
					{
						myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading + num);
						if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.DesiredHeading)) < 90f && IsRightOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
						{
							myUnit.CurrentHeading = myUnit.DesiredHeading;
						}
						return;
					}
				}
				num3 = (int?)groupLead2.Navigator.PreviousWaypointType;
				flag = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 24));
				if ((flag ?? true) && waypoint != null && waypoint.Type == Waypoint.WaypointType.StationStart_FigureEight && flag.HasValue)
				{
					myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading - num);
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.DesiredHeading)) < 90f && IsLeftOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
					{
						myUnit.CurrentHeading = myUnit.DesiredHeading;
					}
					return;
				}
				flag = ((waypoint != null) ? new bool?(waypoint.Type == Waypoint.WaypointType.StationEnd) : ((bool?)null));
				if (flag ?? true)
				{
					num3 = (int?)groupLead2.Navigator.PreviousWaypointType;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 20)) != true)
					{
						num3 = (int?)groupLead2.Navigator.PreviousWaypointType;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 23)) != true)
						{
							goto IL_057c;
						}
					}
					if (flag.HasValue)
					{
						goto IL_06e8;
					}
				}
				goto IL_057c;
			}
			goto IL_0733;
			IL_0733:
			if (num > 179.0)
			{
				num = 179.0;
			}
			switch (Misc.DetermineTurnDirection(myUnit.CurrentHeading, myUnit.DesiredHeading))
			{
			case Misc.TurnDirection.TurnRight:
				myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading + num);
				if (IsRightOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
				{
					myUnit.CurrentHeading = myUnit.DesiredHeading;
				}
				break;
			case Misc.TurnDirection.TurnLeft:
				myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading - num);
				if (IsLeftOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
				{
					myUnit.CurrentHeading = myUnit.DesiredHeading;
				}
				break;
			}
			return;
			IL_06e8:
			if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.DesiredHeading)) > 90f)
			{
				myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading + num);
				return;
			}
			goto IL_0733;
			IL_057c:
			bool? flag3;
			bool? flag2 = (flag3 = ((waypoint != null) ? new bool?(waypoint.Type == Waypoint.WaypointType.StationStart_Racetrack) : ((bool?)null)));
			bool? obj;
			if (flag2.HasValue && flag3 == true)
			{
				obj = true;
			}
			else
			{
				bool? flag4;
				flag2 = (flag4 = ((waypoint != null) ? new bool?(waypoint.Type == Waypoint.WaypointType.StationStart_Racetrack) : ((bool?)null)));
				obj = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3));
			}
			flag = obj;
			if (flag ?? true)
			{
				int? num3 = (int?)groupLead2.Navigator.PreviousWaypointType;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 24)) == true && flag.HasValue)
				{
					goto IL_06e8;
				}
			}
			if (waypoint != null && waypoint.Type == Waypoint.WaypointType.HoldEnd && Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.DesiredHeading)) > 90f)
			{
				myUnit.CurrentHeading = (float)Math2.NormalizeBearing((double)myUnit.CurrentHeading + num);
				return;
			}
			goto IL_0733;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100456464561", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ActiveUnit.Throttle ThrottleForCornerVelocity()
	{
		return GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), CornerVelocity);
	}

	private float method_3(float float_4)
	{
		if (method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 3000f)
		{
			float num = 0.5f;
			if (method_2().SuperManouverable)
			{
				num = 0.25f;
			}
			float num2 = GetMaximumAltitude() - method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num3 = method_2().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 3000f;
			float num4 = float_4 * num * (num3 / num2);
			return (float)(double)Math.Max(float_4 * (1f - num), float_4 - num4);
		}
		return float_4;
	}

	public override float TurnRate()
	{
		float result;
		try
		{
			switch (method_2().Category)
			{
			default:
				if (Math.Abs(float_3 - myUnit.CurrentSpeed) > 30f)
				{
					float num = method_2().Agility_Nominal * 4f;
					float num2 = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false);
					float num3 = ((myUnit.CurrentSpeed <= (float)CornerVelocity) ? (num * (myUnit.CurrentSpeed / (float)CornerVelocity)) : (((double)Physics.ComputeMach(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed) <= 1.0) ? Math.Max(num * (1f - (myUnit.CurrentSpeed - (float)CornerVelocity) / (num2 - (float)CornerVelocity)), 3f) : ((!method_2().SuperManouverable) ? ((float)((double)num - 0.5 * (double)num * (double)(myUnit.CurrentSpeed - (float)CornerVelocity) / (double)(num2 - (float)CornerVelocity))) : ((float)((double)num - 0.25 * (double)num * (double)(myUnit.CurrentSpeed - (float)CornerVelocity) / (double)(num2 - (float)CornerVelocity))))));
					GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
					int? num4 = (int?)proficiency;
					if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == 0)) == true)
					{
						num3 = (float)((double)num3 * 0.4);
					}
					else
					{
						num4 = (int?)proficiency;
						if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 1)) != true)
						{
							num4 = (int?)proficiency;
							if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2)) != true)
							{
								num4 = (int?)proficiency;
								if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 3)) != true)
								{
									num4 = (int?)proficiency;
									if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 4)) == true)
									{
										num3 = (float)((double)num3 * 1.2);
									}
								}
							}
							else
							{
								num3 = (float)((double)num3 * 0.8);
							}
						}
						else
						{
							num3 = (float)((double)num3 * 0.6);
						}
					}
					num3 = Math.Max(num3, 3f);
					float_3 = myUnit.CurrentSpeed;
					float_2 = num3;
				}
				else if (float_2 < 3f)
				{
					float_2 = 3f;
				}
				break;
			case Aircraft._AircraftCategory.AirShip:
				float_2 = 1f;
				break;
			case Aircraft._AircraftCategory.Helicopter:
			case Aircraft._AircraftCategory.Tiltrotor:
				float_2 = 45f;
				break;
			}
			result = float_2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100458", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 3f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override float ClimbRate_Actual(float theCurrentPitch)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (theCurrentPitch <= 0f)
			{
				return 0f;
			}
			return (float)Math.Min(this.get_ClimbRate_Nominal(LimitByTrueAirspeed: true), (double)myUnit.CurrentSpeed * 0.514444 * (double)(theCurrentPitch / (float)MaxPositivePitchAngle));
		}
		return this.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
	}

	public override float DiveRate_Nominal()
	{
		float num = (float)(0.4 * (double)base.DiveRate_Nominal() + 0.6 * (double)base.DiveRate_Nominal() * (double)(1f + method_2().WeightFraction));
		if (!method_2().get_CanHover(bool_7: true) && (double)num > (double)method_2().CurrentSpeed * 0.514444)
		{
			num = (float)((double)method_2().CurrentSpeed * 0.514444);
		}
		return num;
	}

	static Aircraft_Kinematics()
	{
		Class72.smethod_20();
	}
}
