using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Kinematics : ActiveUnit_Kinematics
{
	public new double MaxEndurance
	{
		get
		{
			double result;
			try
			{
				double num2 = default(double);
				foreach (Engine item in myUnit.Propulsion)
				{
					double num = 0.0;
					foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
					{
						if (item.CanUseThisFuelType(item2.FuelType))
						{
							num += (double)(item2.CurrentQuantity / myUnit.FuelConsumption(theThrottleSetting, item.get_OptimumAltBandForThisThrottle(theThrottleSetting), null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
						}
					}
					if (num > num2)
					{
						num2 = num;
					}
				}
				result = num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100789", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = double.MaxValue;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public Ship_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override long RemainingEndurance(float theSpeed, float theAltitude, bool TotalRemainingEndurance, bool MissionFuelEndurance)
	{
		if (!((Ship)myUnit).IsNuke)
		{
			return base.RemainingEndurance(theSpeed, theAltitude, TotalRemainingEndurance, MissionFuelEndurance);
		}
		return long.MaxValue;
	}

	internal float RudderTurningSpeed()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight < 350)
		{
			return 20f;
		}
		if (emptyWeight < 2500)
		{
			return 5f;
		}
		if (emptyWeight < 5000)
		{
			return 0.2f;
		}
		if (emptyWeight < 50000)
		{
			return 0.02f;
		}
		return 0.002f;
	}

	public override float TurnRate()
	{
		int emptyWeight = myUnit.EmptyWeight;
		float num = ((emptyWeight < 350) ? 20f : ((emptyWeight < 5500) ? 5f : ((emptyWeight < 18000) ? 3f : ((emptyWeight >= 50000) ? 0.7f : 1f))));
		if (myUnit.IsMCMPlatform_ThisPulse == -1)
		{
			myUnit.Determine_IsMCMPlatform();
		}
		if (myUnit.IsMCMPlatform_ThisPulse != 0)
		{
			num *= 3f;
		}
		return num;
	}

	public static int GetMaximumSpeedForThisSeaState(Ship theShip, int theSeaState)
	{
		int maximumSpeed = theShip.Kinematics.GetMaximumSpeed();
		float displacement_Standard = theShip.Displacement_Standard;
		if (displacement_Standard > 5500f)
		{
			switch (theSeaState)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				return maximumSpeed;
			case 6:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 8:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		if (displacement_Standard > 1500f)
		{
			switch (theSeaState)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				return maximumSpeed;
			case 5:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 6:
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 8:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		if (displacement_Standard > 350f)
		{
			switch (theSeaState)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
				return maximumSpeed;
			case 4:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 5:
			case 6:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		switch (theSeaState)
		{
		default:
			return 0;
		case 0:
		case 1:
		case 2:
			return maximumSpeed;
		case 3:
			return (int)Math.Round((double)maximumSpeed * 0.75);
		case 4:
			return (int)Math.Round((double)maximumSpeed * 0.5);
		case 5:
			return (int)Math.Round((double)maximumSpeed * 0.25);
		}
	}

	public override float TacticalRadius()
	{
		if (!((Ship)myUnit).IsNuke)
		{
			if (_TacticalRadius > 0f)
			{
				return _TacticalRadius;
			}
			float num = MaxRange(BingoFuelCheck: true, null, null);
			_TacticalRadius = num / 2f;
			return _TacticalRadius;
		}
		return float.PositiveInfinity;
	}

	public override float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		float result;
		try
		{
			if (((Ship)myUnit).IsNuke)
			{
				result = float.MaxValue;
			}
			else if (myUnit.Propulsion.Count != 0)
			{
				if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					result = 0f;
				}
				else
				{
					ActiveUnit.Throttle throttle = (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) ? ActiveUnit.Throttle.Cruise : ((myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike) ? ActiveUnit.Throttle.Cruise : ((((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept) ? ActiveUnit.Throttle.Cruise : ActiveUnit.Throttle.Full)));
					result = (float)(this.get_MaxEndurance(throttle, theSpeed, theAltitude, BingoFuelCheck, 0f) * (double)GetMaximumSpeed(myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(throttle).MaxAlt, throttle, ValidateAndFixAltitude: false) / 3600.0);
				}
			}
			else
			{
				result = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100788", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = float.MaxValue;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? theFuelStateDoctrine)
	{
		float result;
		try
		{
			float num = default(float);
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			AltBand altBand = myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise);
			result = (float)((double)(num / myUnit.FuelConsumption(ActiveUnit.Throttle.Cruise, altBand, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false)) * ((double)GetMaximumSpeed(altBand.MaxAlt, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) / 3600.0));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100790", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = float.MaxValue;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		float num;
		if (myUnit.CurrentSpeed < (float)((double)GetMaximumSpeed(0f, myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false) / 2.0))
		{
			int emptyWeight = myUnit.EmptyWeight;
			num = ((emptyWeight < 350) ? (8f / 9f) : ((emptyWeight < 5500) ? 0.5f : ((emptyWeight < 18000) ? (2f / 9f) : ((emptyWeight >= 50000) ? (4f / 45f) : (2f / 15f)))));
		}
		else
		{
			int emptyWeight2 = myUnit.EmptyWeight;
			num = ((emptyWeight2 < 350) ? (4f / 9f) : ((emptyWeight2 < 5500) ? 0.25f : ((emptyWeight2 < 18000) ? (1f / 9f) : ((emptyWeight2 >= 50000) ? (2f / 45f) : (1f / 15f)))));
		}
		if (((Ship)myUnit).Category == Ship._ShipCategory.Merchant)
		{
			num /= 2f;
		}
		if (((Ship)myUnit).IsNuke)
		{
			num = (float)(1.5 * (double)num);
		}
		return num;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		float num = Acceleration_Nominal(theThrottle, theAltitude);
		float result = num;
		if (myUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop)
		{
			result = num * (float)(int)myUnit.ThrottleSetting / 2f;
		}
		return result;
	}

	public override void CalcTurnDeceleration(double ActualTurnRate, float elapsedTime)
	{
		if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation)
		{
			double num = GetMaximumSpeed(0f, ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
			double num2 = ((!(num > 0.0)) ? (0.5 * ActualTurnRate * (double)elapsedTime) : (0.5 * ActualTurnRate * (double)elapsedTime * (((double)myUnit.CurrentSpeed + 1E-06) / num)));
			int num3 = (int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading));
			if (num3 < 5)
			{
				num2 = 0.0;
			}
			else if (num3 < 15)
			{
				num2 *= 0.25;
			}
			else if (num3 < 30)
			{
				num2 *= 0.5;
			}
			myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - num2);
			if (myUnit.CurrentSpeed < 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
		}
	}

	public override float GetMinimumAltitude()
	{
		return 0f;
	}

	public override float GetMaximumAltitude()
	{
		return 0f;
	}

	static Ship_Kinematics()
	{
		Class72.smethod_20();
	}
}
