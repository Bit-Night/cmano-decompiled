using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Kinematics : ActiveUnit_Kinematics
{
	[CompilerGenerated]
	internal sealed class _Closure$__21-0
	{
		public float $VB$Local_DesiredSpeed;

		public _Closure$__21-0(_Closure$__21-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_DesiredSpeed = arg0.$VB$Local_DesiredSpeed;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(AltBand theB)
		{
			return (float)theB.Speed_Loiter >= $VB$Local_DesiredSpeed;
		}

		[SpecialName]
		internal bool _Lambda$__2(AltBand theB)
		{
			return (float)theB.Speed_Cruise >= $VB$Local_DesiredSpeed;
		}

		[SpecialName]
		internal bool _Lambda$__4(AltBand theB)
		{
			float? num = theB.Speed_Full;
			return ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= $VB$Local_DesiredSpeed)) == true;
		}

		[SpecialName]
		internal bool _Lambda$__6(AltBand theB)
		{
			float? num = theB.Speed_Flank;
			return ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= $VB$Local_DesiredSpeed)) == true;
		}

		static _Closure$__21-0()
		{
			Class72.smethod_20();
		}
	}

	private Submarine submarine_0;

	public Submarine_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	[SpecialName]
	private Submarine method_2()
	{
		if (submarine_0 == null)
		{
			submarine_0 = (Submarine)myUnit;
		}
		return submarine_0;
	}

	public override float PitchRate_Negative()
	{
		return 1f;
	}

	public override float PitchRate_Positive()
	{
		return 1f;
	}

	public override float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? theFuelStateDoctrine)
	{
		float num = Math.Max(-20f, GetMinimumAltitude());
		return (float)((double)(float)RemainingEndurance(ActiveUnit.Throttle.Cruise, num, TotalRemainingEndurance: true) * ((double)GetMaximumSpeed(num, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) / 3600.0));
	}

	public override long RemainingEndurance(ActiveUnit.Throttle theThrottleSetting, float theAltitude, bool TotalRemainingEndurance)
	{
		long result = default(long);
		try
		{
			if (!((Submarine)myUnit).IsNuke && (!((Submarine)myUnit).IsTetheredROV || myUnit.Fuel_ReadOnly.Count != 0))
			{
				FuelRec fuelRec = ((myUnit.Fuel_ReadOnly.Count == 1) ? myUnit.Fuel_ReadOnly[0] : ((!(Math.Round(theAltitude) >= -20.0)) ? (from theFuelrec in myUnit.Fuel_ReadOnly
					select (theFuelrec) into theFuelrec
					where myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.Battery)
					select theFuelrec).ElementAtOrDefault(0) : (from theFuelrec in myUnit.Fuel_ReadOnly
					select (theFuelrec) into theFuelrec
					where myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.DieselFuel)
					select theFuelrec).ElementAtOrDefault(0)));
				if (!Information.IsNothing((object)fuelRec))
				{
					result = (long)Math.Round((double)fuelRec.CurrentQuantity / (double)myUnit.FuelConsumption(theThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
					return result;
				}
				result = 0L;
				return result;
			}
			result = long.MaxValue;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100833", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override long RemainingEndurance(float theSpeed, float theAltitude, bool TotalRemainingEndurance, bool MissionFuelEndurance)
	{
		if (((Submarine)myUnit).IsBiological)
		{
			return long.MaxValue;
		}
		long result = default(long);
		try
		{
			if (!((Submarine)myUnit).IsNuke && (!((Submarine)myUnit).IsTetheredROV || myUnit.Fuel_ReadOnly.Count != 0))
			{
				if (theSpeed == 0f)
				{
					result = long.MaxValue;
					return result;
				}
				float num = default(float);
				foreach (FuelRec item in myUnit.Fuel_ReadOnly)
				{
					num += item.CurrentQuantity;
				}
				if (!TotalRemainingEndurance)
				{
					num -= myUnit.Kinematics.ReserveFuel;
				}
				float num2 = myUnit.FuelConsumption(GetThrottleSuitableForThisSpeed(theAltitude, (int)Math.Round(theSpeed)), null, (int)Math.Round(theSpeed), theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				if (num2 == 0f)
				{
					result = long.MaxValue;
					return result;
				}
				result = (long)Math.Round(num / num2);
				return result;
			}
			result = long.MaxValue;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100185", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override float RollRate()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight < 350)
		{
			return 4f;
		}
		if (emptyWeight < 3500)
		{
			return 3f;
		}
		if (emptyWeight < 8100)
		{
			return 2f;
		}
		if (emptyWeight < 15000)
		{
			return 1f;
		}
		return 0.5f;
	}

	public override void CalcTurnDeceleration(double ActualTurnRate, float elapsedTime)
	{
		if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation && (int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) > 5)
		{
			float num = default(float);
			if (ActualTurnRate > 25.0)
			{
				num = (float)(0.25 * (double)elapsedTime);
			}
			if (ActualTurnRate > 45.0)
			{
				num = 1f * elapsedTime;
			}
			myUnit.CurrentSpeed -= num;
		}
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		if (((Submarine)myUnit).get_FuelEndurance(ThrottleSetting, (AltBand)null, (float?)null, (float?)null, ((Submarine)myUnit).PrimaryEngine, ((Submarine)myUnit).PrimaryEngineNo) == 0L)
		{
			return 0;
		}
		return base.GetMaximumSpeed(Altitude, ThrottleSetting, ValidateAndFixAltitude);
	}

	public int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, Engine theEngine, int theEngineNo, bool ValidateAndFixAltitude)
	{
		if (((Submarine)myUnit).get_FuelEndurance(ThrottleSetting, (AltBand)null, (float?)null, (float?)null, theEngine, theEngineNo) == 0L)
		{
			return 0;
		}
		return base.GetMaximumSpeed(Altitude, ThrottleSetting, ValidateAndFixAltitude);
	}

	public override float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		return float.MaxValue;
	}

	public override void ChangeAltitude(float elapsedTime, float theDesiredAlt, float? MinimumSafeAltitude, bool DoSanityCheck)
	{
		try
		{
			myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			double num2 = (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.Altitude_old) / elapsedTime;
			float attitude_Pitch = myUnit.Attitude_Pitch;
			float num3 = ClimbRate_Actual(attitude_Pitch) * elapsedTime;
			float num4 = DiveRate_Actual(attitude_Pitch) * elapsedTime;
			if (Math.Abs(theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 1f)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, theDesiredAlt);
				myUnit.DesiredPitch = 0f;
			}
			else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < theDesiredAlt)
			{
				if (num2 < 0.0)
				{
					num3 = (float)((double)num3 - num2);
				}
				num = (myUnit.SupportsAttitude_Pitch ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num3) : ((!(theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= num3)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num3) : theDesiredAlt));
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
			}
			else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > theDesiredAlt)
			{
				if (num2 > 0.0)
				{
					num4 = (float)((double)num4 - Math.Abs(num2));
				}
				num = (myUnit.SupportsAttitude_Pitch ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num4) : ((!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt <= num4)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num4) : theDesiredAlt));
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num);
			}
			else
			{
				myUnit.DesiredPitch = 0f;
			}
			float maximumAltitude = GetMaximumAltitude();
			float minimumAltitude = GetMinimumAltitude();
			if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, maximumAltitude - 10f);
				myUnit.Attitude_Pitch = 0f;
			}
			else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, minimumAltitude);
				myUnit.Attitude_Pitch = 0f;
			}
			else if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(num <= MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, MinimumSafeAltitude.Value);
				myUnit.Attitude_Pitch = 0f;
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

	public override float ClimbRate_Actual(float theCurrentPitch)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			return (float)((double)((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true) + (double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(theCurrentPitch));
		}
		return ((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
	}

	public override float DiveRate_Nominal()
	{
		return (float)((double)((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true) * 1.5);
	}

	public override float DiveRate_Actual(float theCurrentPitch)
	{
		if (!myUnit.SupportsAttitude_Pitch)
		{
			return DiveRate_Nominal();
		}
		if (theCurrentPitch < 0f)
		{
			return (float)((double)DiveRate_Nominal() - (double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(theCurrentPitch));
		}
		return (float)((double)DiveRate_Nominal() + (double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(theCurrentPitch));
	}

	internal float RudderTurningSpeed()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight >= 350)
		{
			if (emptyWeight < 2500)
			{
				return 2f;
			}
			if (emptyWeight < 5000)
			{
				return 0.1f;
			}
			if (emptyWeight < 50000)
			{
				return 0.01f;
			}
			return 0.001f;
		}
		return 7.5f;
	}

	public override float TurnRate()
	{
		int emptyWeight = myUnit.EmptyWeight;
		float num = ((emptyWeight < 350) ? 15f : ((emptyWeight < 2500) ? 5f : ((emptyWeight < 5000) ? 3f : ((emptyWeight >= 50000) ? 0.8f : 1f))));
		switch (myUnit.DesiredTurnRate)
		{
		case ActiveUnit.TurnRate.Max:
			return (float)((double)num * 1.25);
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		case ActiveUnit.TurnRate.Navigation:
			return num;
		}
	}

	public int BestTacticalSpeed(float theDepth)
	{
		return CavitationSpeed(theDepth) - 1;
	}

	public int? MinimumDepthToAchieveThisSpeed(float DesiredSpeed, ActiveUnit.Throttle theThrottle)
	{
		_Closure$__21-0 arg = default(_Closure$__21-0);
		_Closure$__21-0 CS$<>8__locals5 = new _Closure$__21-0(arg);
		CS$<>8__locals5.$VB$Local_DesiredSpeed = DesiredSpeed;
		int? result = default(int?);
		try
		{
			List<AltBand> list = new List<AltBand>();
			foreach (Engine item2 in myUnit.Propulsion)
			{
				AltBand[] altBands = item2.AltBands;
				foreach (AltBand item in altBands)
				{
					list.Add(item);
				}
			}
			IEnumerable<AltBand> source = null;
			switch (theThrottle)
			{
			case ActiveUnit.Throttle.Loiter:
				source = from theB in list
					where (float)theB.Speed_Loiter >= CS$<>8__locals5.$VB$Local_DesiredSpeed
					orderby theB.MaxAlt descending
					select theB;
				break;
			case ActiveUnit.Throttle.Cruise:
				source = from theB in list
					where (float)theB.Speed_Cruise >= CS$<>8__locals5.$VB$Local_DesiredSpeed
					orderby theB.MaxAlt descending
					select theB;
				break;
			case ActiveUnit.Throttle.Full:
				source = from theB in list.Where([SpecialName] (AltBand theB) =>
					{
						float? num = theB.Speed_Full;
						return ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= CS$<>8__locals5.$VB$Local_DesiredSpeed)) == true;
					})
					orderby theB.MaxAlt descending
					select theB;
				break;
			case ActiveUnit.Throttle.Flank:
				source = from theB in list.Where([SpecialName] (AltBand theB) =>
					{
						float? num = theB.Speed_Flank;
						return ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= CS$<>8__locals5.$VB$Local_DesiredSpeed)) == true;
					})
					orderby theB.MaxAlt descending
					select theB;
				break;
			}
			if (source.Count() != 0)
			{
				result = (int)Math.Round(source.ElementAtOrDefault(0).MaxAlt);
				return result;
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100834", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override AltBand GetCurrentAltBand(float Altitude, bool ValidateAndFixAltitude)
	{
		AltBand result;
		try
		{
			AltBand altBand = null;
			AltBand[] altBands = default(AltBand[]);
			foreach (Engine item in myUnit.Propulsion)
			{
				altBands = item.AltBands;
				int num = altBands.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					AltBand altBand2 = altBands[i];
					if (altBand2.MaxAlt >= Altitude && !(Altitude + 1f < altBand2.MinAlt))
					{
						altBand = altBand2;
						break;
					}
				}
			}
			if (Information.IsNothing((object)altBand))
			{
				if (!myUnit.IsAircraft)
				{
					altBand = altBands.OrderBy([SpecialName] (AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
					if (ValidateAndFixAltitude)
					{
						myUnit.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, altBand.MinAlt);
					}
				}
				else
				{
					altBand = altBands.OrderByDescending([SpecialName] (AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
					if (ValidateAndFixAltitude)
					{
						myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, altBand.MaxAlt);
					}
				}
			}
			result = altBand;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100835", "");
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

	public override float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		float currentSpeed = myUnit.CurrentSpeed;
		if (currentSpeed < 7f)
		{
			int emptyWeight = myUnit.EmptyWeight;
			if (emptyWeight < 350)
			{
				return 0.45f;
			}
			if (emptyWeight < 3500)
			{
				return 0.43f;
			}
			if (emptyWeight < 8100)
			{
				return 0.41f;
			}
			if (emptyWeight < 15000)
			{
				return 0.27f;
			}
			return 0.2f;
		}
		if (currentSpeed > 20f)
		{
			int emptyWeight2 = myUnit.EmptyWeight;
			if (emptyWeight2 < 350)
			{
				return 0.25f;
			}
			if (emptyWeight2 < 3500)
			{
				return 0.25f;
			}
			if (emptyWeight2 < 8100)
			{
				return 0.55f;
			}
			if (emptyWeight2 < 15000)
			{
				return 0.4f;
			}
			return 0.2f;
		}
		int emptyWeight3 = myUnit.EmptyWeight;
		if (emptyWeight3 < 350)
		{
			return 0.3f;
		}
		if (emptyWeight3 < 3500)
		{
			return 0.3f;
		}
		if (emptyWeight3 < 8100)
		{
			return 0.65f;
		}
		if (emptyWeight3 < 15000)
		{
			return 0.45f;
		}
		return 0.25f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		float num = Acceleration_Nominal(theThrottle, theAltitude);
		if (method_2().Flags.ShroudedPropulsor)
		{
			num = (float)((double)num * 1.1);
		}
		return num;
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			if (!myUnit.IsOperating() || double.IsNaN(myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) || double.IsNaN(myUnit.get_Latitude((GlobalVariables.BooleanObject)null)))
			{
				return;
			}
			AdjustAttitude_Roll(elapsedTime);
			if (myUnit.DesiredAltitude > 0f)
			{
				myUnit.DesiredAltitude = 0f;
			}
			float num = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
			if (SeaIceProvider.PointIsUnderIce(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)) && myUnit.DesiredAltitude > -25f)
			{
				myUnit.DesiredAltitude = -25f;
			}
			if (((Submarine)myUnit).IsTetheredROV)
			{
				ActiveUnit activeUnit = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				if (activeUnit != null && (double)myUnit.RangeToUnit_Horiz(activeUnit) * 1852.0 > (double)((Submarine)myUnit).ROVControlRadius_m)
				{
					ActiveUnit observerUnit = myUnit;
					string feedbackMessage = "";
					if (Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(activeUnit, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) > 90f || activeUnit.CurrentSpeed > myUnit.CurrentSpeed)
					{
						if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
						{
							_ = ((MineClearingMission)myUnit.ActiveMissionOrPackage()).Area;
							if (!myUnit.Navigator.HasPlottedCourse())
							{
								float num2 = activeUnit.CurrentHeading;
								if (num2 - 45f <= 0f)
								{
									num2 += 360f;
								}
								int bearing = Math2.NormalizeBearing(GameGeneral.GlobalRNG.Next((int)Math.Round(num2 - 45f), (int)Math.Round(num2 + 46f)));
								double out_lon = default(double);
								double out_lat = default(double);
								Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, (float)((double)method_2().ROVControlRadius_m / 1852.0), bearing);
								method_2().set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(((ActiveUnit)method_2()).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_2()).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
								if (myUnit.Navigator.HasPlottedCourse())
								{
									myUnit.Navigator.PlottedCourse[0].Latitude = out_lat;
									myUnit.Navigator.PlottedCourse[0].Longitude = out_lon;
								}
								else
								{
									myUnit.Navigator.AddWaypoint(new Waypoint(out_lon, out_lat, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
								}
							}
						}
						else if (activeUnit.CurrentSpeed > 0f)
						{
							float num3 = Module_Unit.BearingToUnit_True(myUnit, activeUnit);
							myUnit.CurrentHeading = num3;
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, num3);
							myUnit.CurrentSpeed = activeUnit.CurrentSpeed;
						}
					}
				}
			}
			if (!myUnit.AI.HoldPosition)
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
				{
					if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None)
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
						{
							ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
							if (dockingOps.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
					}
					else
					{
						myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
					}
				}
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
			}
			float num4 = GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: true);
			if (GeoPoint.get_IsInCanal(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				num4 = 8f;
			}
			if (myUnit.DesiredSpeed > num4)
			{
				myUnit.DesiredSpeed = num4;
			}
			double num5 = myUnit.CurrentHeading;
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
			double num6 = (double)Math.Abs(MathFunctions.AngularDifference((float)num5, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
			CalcTurnDeceleration(num6, elapsedTime);
			bool flag = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)) || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
			{
				int num7;
				if (!myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					num7 = 1;
				}
				else
				{
					int? num8 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = ((!num8.HasValue) ? ((bool?)null) : new bool?(num8 == 15));
					if (((!flag2) ?? flag2) != true)
					{
						goto IL_06c3;
					}
					num7 = 1;
				}
				flag = (byte)num7 != 0;
			}
			goto IL_06c3;
			IL_06c3:
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(elapsedTime, (float)num6);
			}
			if (myUnit.SupportsAttitude_Pitch)
			{
				AdjustAttitude_Pitch(elapsedTime);
			}
			ChangeAltitude(elapsedTime, myUnit.DesiredAltitude, num + 1f, DoSanityCheck: true);
			if (myUnit.ParentScen.UnguidedWeapons.HasElements())
			{
				IEnumerator<KeyValuePair<string, UnguidedWeapon>> enumerator = myUnit.ParentScen.UnguidedWeapons.GetEnumerator();
				while (enumerator.MoveNext())
				{
					UnguidedWeapon value = enumerator.Current.Value;
					if (value.Type == Weapon._WeaponType.AttachedMine && value?.Target?.ActualUnit == myUnit)
					{
						((Module_Unit.Unit)value).set_Longitude((GlobalVariables.BooleanObject)null, myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
						((Module_Unit.Unit)value).set_Latitude((GlobalVariables.BooleanObject)null, myUnit.get_Latitude((GlobalVariables.BooleanObject)null));
					}
				}
			}
			myUnit.updateLastReportedInfo();
			if (!SimplifiedCalcs_DLZ)
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100836", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Submarine_Kinematics()
	{
		Class72.smethod_20();
	}
}
