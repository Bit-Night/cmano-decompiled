using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Weapon_Kinematics : ActiveUnit_Kinematics
{
	private Dictionary<int, float> dictionary_0;

	private Dictionary<int, float> dictionary_1;

	private Dictionary<int, float> dictionary_2;

	private Dictionary<int, float> dictionary_3;

	internal float SpeedForSimultaneousTOT;

	private Weapon weapon_0;

	public double? cached_ControlSurfaceQRef;

	private double double_0;

	private float float_1;

	private float float_2;

	private List<double> list_1;

	private int int_0;

	protected Weapon myWeapon
	{
		get
		{
			if (weapon_0 == null)
			{
				weapon_0 = (Weapon)myUnit;
			}
			return weapon_0;
		}
	}

	public Weapon_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		dictionary_0 = new Dictionary<int, float>();
		dictionary_1 = new Dictionary<int, float>();
		dictionary_2 = new Dictionary<int, float>();
		dictionary_3 = new Dictionary<int, float>();
		SpeedForSimultaneousTOT = -1f;
		double_0 = -1.0;
		float_1 = -1f;
		float_2 = float.MaxValue;
		int_0 = int.MinValue;
	}

	public int CalculateBoostPhaseDuration()
	{
		switch (myWeapon.Propulsion[0].Type)
		{
		case Engine.EngineType.Turbojet:
		case Engine.EngineType.Turbofan:
			return 5;
		default:
		{
			int result;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				result = 5;
			}
			else
			{
				result = 5;
			}
			return result;
		}
		case Engine.EngineType.Rocket_BoostCoast:
		case Engine.EngineType.Rocket_LongBurn:
		case Engine.EngineType.Ramjet:
		{
			float maxRange_NoTargetType = myWeapon.MaxRange_NoTargetType;
			if (maxRange_NoTargetType < 10f)
			{
				return 3;
			}
			if (maxRange_NoTargetType < 20f)
			{
				return 5;
			}
			if (maxRange_NoTargetType < 50f)
			{
				return 15;
			}
			return 30;
		}
		}
	}

	internal void SetActualLoftAltitude(ActiveUnit theFiringUnit, Contact theTarget)
	{
		if (!myWeapon.IsAAWCapable || myWeapon.CruiseAltitude_ASL == 0f || (!theTarget.IsAircraftContact && theTarget.Type != Contact_Base.ContactType.Missile))
		{
			return;
		}
		float maximumAltitude = GetMaximumAltitude();
		if (theTarget.ActualUnit.IsBallisticMissile && theTarget.FutureBallisticPath.Length > 0)
		{
			float num = 0f;
			TrajectoryPoint[] futureBallisticPath = theTarget.FutureBallisticPath;
			for (int i = 0; i < futureBallisticPath.Length; i = checked(i + 1))
			{
				TrajectoryPoint trajectoryPoint = futureBallisticPath[i];
				num = ((trajectoryPoint.Altitude > num) ? trajectoryPoint.Altitude : num);
			}
			myWeapon.CruiseAltitude_ASL = Math.Min(num, maximumAltitude);
			return;
		}
		float num2 = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theFiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if ((double)num2 > (double)myWeapon.CruiseAltitude_ASL * 0.5)
		{
			return;
		}
		float num3 = (float)((double)GetMaximumSpeed() * 0.5);
		Geopoint_Struct thePoint = myWeapon.Navigator.ComputeInterceptPoint_BruteForce(num3, theTarget);
		float num4 = 0f;
		num4 = (thePoint.HasZeroCoords ? myWeapon.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) : Module_Unit.RangeToPoint_Horiz(myWeapon, thePoint));
		if (num4 / num3 * 3600f < (float)myWeapon.TotalBurnTime)
		{
			myWeapon.CruiseAltitude_ASL = 0f;
			return;
		}
		float num5 = myWeapon.get_MaxRangeForThisTarget(theFiringUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
		if (num4 > num5)
		{
			num4 = num5;
		}
		double num6 = method_2(num4, num5, num2, theFiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		AltBand altBand = myWeapon.Kinematics.HighestAltBand(myWeapon.Propulsion[0]);
		if (altBand != null && (double)altBand.MaxAlt < num6)
		{
			altBand.MaxAlt = (float)(num6 + 1.0);
		}
		myWeapon.CruiseAltitude_ASL = (float)num6;
	}

	private int method_2(float float_3, float float_4, float float_5, float float_6)
	{
		double num = (double)float_3 * 1852.0;
		double num2;
		if (float_3 > float_4)
		{
			num2 = 45.0;
		}
		else
		{
			num2 = method_3(float_3, float_4);
			if (num2 > 45.0)
			{
				num2 = 45.0;
			}
		}
		return (int)Math.Round(num * Math2.Tand(num2) / 4.0 + (double)float_6);
	}

	private double method_3(float float_3, float float_4)
	{
		double num = float_3 / float_4;
		if (!(num < 0.0) && num <= 1.0)
		{
			double num2 = num;
			if (num2 < -1.0 || num2 > 1.0)
			{
				throw new ArgumentException("Invalid range ratio. The value should correspond to a feasible sine value.");
			}
			double num3 = Math.Asin(num2);
			return (Math.PI - num3) / 2.0 * (180.0 / Math.PI);
		}
		throw new ArgumentOutOfRangeException("rangeRatio", "The range ratio must be between 0 and 1.");
	}

	public override void Loiter(float elapsedTime, bool UseFormUpAltitude = false, bool UseLandingQueueAltitude = false)
	{
		if (myWeapon.AI.PrimaryTarget != null && (myWeapon.Navigator.PlottedCourse == null || myWeapon.Navigator.PlottedCourse.Count() == 0))
		{
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(Module_Unit.BearingToUnit_True(myUnit, myUnit.AI.PrimaryTarget) + 3f * elapsedTime));
		}
		else
		{
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(myUnit.CurrentHeading + 3f * elapsedTime));
		}
		if (myWeapon.CanParachuteLoiter)
		{
			myWeapon.DeployLoiterParachute();
		}
		else if (!myWeapon.IsParachuteLoitering)
		{
			if (myUnit.Kinematics.CanApplyLoiterThrottle())
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
		}
		else
		{
			myWeapon.CurrentSpeed = 97.192f;
			myWeapon.DesiredSpeed = myWeapon.CurrentSpeed;
			myWeapon.DesiredAltitude = myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 50f * elapsedTime;
		}
		myUnit.LoiteredThisPulse = true;
	}

	public override float TurnRate()
	{
		switch (((Weapon)myUnit).Type)
		{
		case Weapon._WeaponType.Torpedo:
			return 10f;
		default:
		{
			float num = Physics.ComputeMach(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed);
			if (num < 1f)
			{
				return 60f;
			}
			if (num > 1f)
			{
				return 30f;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		}
		case Weapon._WeaponType.GuidedWeapon:
			if (!((Weapon)myUnit).IsAAWCapable)
			{
				return 30f;
			}
			return 60f;
		}
	}

	public float TurnGForceStructuralLimit()
	{
		if (weapon_0.IsABMOptimized())
		{
			return 100f;
		}
		if (!weapon_0.IsABMCapable())
		{
			if (weapon_0.IsAAWCapable)
			{
				return 30f;
			}
			return 15f;
		}
		return 60f;
	}

	public double method_4()
	{
		if (!cached_ControlSurfaceQRef.HasValue)
		{
			float num = myWeapon.CruiseAltitude_ASL;
			if (num == 0f)
			{
				num = myWeapon.Kinematics.GetMaximumAltitude();
			}
			double num2 = Physics.ConvertMachToMetersPerSecond(1.0, num);
			if ((double)myWeapon.Kinematics.GetMaximumSpeed() * 0.514444 < num2)
			{
				num2 = (double)myWeapon.Kinematics.GetMaximumSpeed() * 0.514444;
			}
			cached_ControlSurfaceQRef = Physics.CalculateDynamicPressure((int)Math.Round(num), num2);
		}
		return cached_ControlSurfaceQRef.Value;
	}

	private float method_5(float float_3)
	{
		Weapon weapon = myWeapon;
		if (weapon.UsesBoostCoastModel.Value && weapon.TotalBurnTime < 5)
		{
			return float_3 / (float)weapon.TotalBurnTime;
		}
		return float_3 / 5f;
	}

	private float method_6(float float_3)
	{
		bool flag = false;
		if (myUnit.IsTorpedo)
		{
			foreach (Engine item in myUnit.Propulsion)
			{
				if (item.Type == Engine.EngineType.Torpedo_Electric)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			return myUnit.DesiredSpeed;
		}
		return (float)(0.065 * (double)myUnit.DesiredSpeed);
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float MaxSpeedAtThisAltitude)
	{
		if (!myWeapon.IsMissile)
		{
			return method_6(MaxSpeedAtThisAltitude);
		}
		return method_5(MaxSpeedAtThisAltitude);
	}

	public void GoToDesiredSpeed(float elapsedTime, float ActualTurnRate, float MaxSpeedAtThisAltitude)
	{
		try
		{
			float num = Acceleration_Actual(myUnit.ThrottleSetting, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), MaxSpeedAtThisAltitude) * elapsedTime;
			if (myUnit.CurrentSpeed < myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed += num;
				if ((int)Math.Round(myUnit.CurrentSpeed) > (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed > myUnit.DesiredSpeed)
			{
				double num2 = 0.0;
				num2 = ((MaxSpeedAtThisAltitude == 0f) ? (-4.905 * Math.Pow(elapsedTime, 2.0)) : ((double)(2f * num * (myUnit.CurrentSpeed / MaxSpeedAtThisAltitude))));
				myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - num2);
				if ((int)Math.Round(myUnit.CurrentSpeed) < (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed < 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100980", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public double ComputeAeroControlSurfaceEffectiveness(double currentSpeed, double currentAltitude)
	{
		float num = Physics.ComputeMach(currentAltitude, currentSpeed);
		double num2 = ((!(num > 1f)) ? 1.0 : ((!(num <= 5f)) ? (0.15 + Math.Exp(-0.4723 * (double)(num - 1f))) : Math.Exp(-0.31 * (double)(num - 1f))));
		double num3 = method_4();
		double num4 = Physics.CalculateDynamicPressure((int)Math.Round(currentAltitude), currentSpeed * 0.514444) / num3;
		double num5 = ((!(num4 < 1.0)) ? 1.0 : num4);
		if (num5 < 0.0)
		{
			num5 = 0.0;
		}
		if (num5 > 1.0)
		{
			num5 = 1.0;
		}
		double num6 = num2 * num5;
		if (num6 < 0.0)
		{
			num6 = 0.0;
		}
		if (num6 > 1.0)
		{
			num6 = 1.0;
		}
		return num6;
	}

	public float ComputeMaxTurnRateForSpeedAndGForce(double speedKnots, double gForce)
	{
		double num = speedKnots * 0.514444;
		if (num < 0.1)
		{
			return 360f;
		}
		return (float)(gForce * 9.81 / num * 57.2957795130823);
	}

	public float GetAdjustedTurnRateBasedOnSpeedAndAltitude()
	{
		float num = TurnRate();
		float currentSpeed = myWeapon.CurrentSpeed;
		double num2 = 1.0;
		if (weapon_0.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic)
		{
			float num3 = weapon_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
			num2 = ComputeAeroControlSurfaceEffectiveness(currentSpeed, num3);
		}
		float num4 = (float)((double)num * num2);
		float num5 = TurnGForceStructuralLimit();
		float num6 = ComputeMaxTurnRateForSpeedAndGForce(currentSpeed, num5);
		if (num4 > num6)
		{
			num4 = num6;
		}
		return num4;
	}

	public override float PitchRate_Negative()
	{
		Weapon weapon = myWeapon;
		if (weapon.Type != Weapon._WeaponType.RV && weapon.Type != Weapon._WeaponType.BallisticMissile)
		{
			float num = ((!((Weapon)myUnit).IsAAWCapable) ? 30f : 60f);
			if (weapon.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic)
			{
				float maximumAltitude = weapon.Kinematics.GetMaximumAltitude();
				float num2 = weapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
				if (!(maximumAltitude > 0f))
				{
					num = ((!(num2 <= 50000f)) ? 0f : ((float)((double)num * (1.0 - Math.Pow(num2 / 50000f, 0.800000011920929)))));
				}
				else
				{
					double num3 = num2 / maximumAltitude;
					num = (float)((double)num * (0.25 + 0.75 * (1.0 - num3)));
				}
			}
			return num;
		}
		return 2f;
	}

	public override float PitchRate_Positive()
	{
		Weapon weapon = myWeapon;
		if (weapon.Type != Weapon._WeaponType.RV && weapon.Type != Weapon._WeaponType.BallisticMissile)
		{
			float num = (((Weapon)myUnit).IsAAWCapable ? 60f : 30f);
			if (weapon.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic)
			{
				double num2 = weapon.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null) / weapon.Kinematics.GetMaximumAltitude();
				num = (float)((double)num * (0.25 + 0.75 * (1.0 - num2)));
			}
			return num;
		}
		return 2f;
	}

	public override float RollRate()
	{
		return 25f;
	}

	private void method_7(float float_3)
	{
		float num = myWeapon.BurnoutWeight();
		float num2 = myWeapon.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
		if (myWeapon.Altitude_old != num2)
		{
			float num3 = (float)((double)(num2 - myWeapon.Altitude_old) * 9.81 * (double)num);
			double num4 = 0.5 * (double)num * Math.Pow((double)myWeapon.CurrentSpeed * 0.514444, 2.0);
			num4 -= (double)num3;
			double num5 = Math.Sqrt(2.0 * Math.Abs(num4) / (double)num) * 1.94384;
			myWeapon.CurrentSpeed = (float)num5;
		}
	}

	protected double CalculateDragForce(float velocity_Kts, float AppliedPitchChange_DegreesPerSecond, float AppliedHeadingChange_DegreesPerSecond, float Altitude, short tempAtSL_C, float ReferenceWeight, bool IncreaseDragCoefficientForPositivePitch = false)
	{
		Weather.TAtmosphere tAtmosphere = Weather.Standard_Atmosphere_AtThisAltitude(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, Altitude / 1000f, tempAtSL_C);
		double num = tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0;
		double num2 = (double)Math.Abs(velocity_Kts) * 0.514444;
		if (double_0 < 0.0)
		{
			double_0 = Math.PI * Math.Pow(weapon_0.Diameter / 2f, 2.0);
			switch (weapon_0.Type)
			{
			default:
				double_0 *= 1.2;
				break;
			case Weapon._WeaponType.RV:
				if (weapon_0.IsMaRV)
				{
					double_0 *= 1.2;
				}
				break;
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.IronBomb:
				double_0 *= 1.1;
				break;
			}
		}
		double num3 = weapon_0.BodyDragCoefficient(Altitude, velocity_Kts);
		if (!(AppliedPitchChange_DegreesPerSecond < 1f))
		{
			num3 = ((AppliedPitchChange_DegreesPerSecond < 5f) ? (num3 * 1.2) : ((AppliedPitchChange_DegreesPerSecond < 10f) ? (num3 * 1.3) : ((!(AppliedPitchChange_DegreesPerSecond < 20f)) ? (num3 * 2.0) : (num3 * 1.5))));
		}
		if (!(AppliedHeadingChange_DegreesPerSecond < 1f))
		{
			num3 = ((AppliedHeadingChange_DegreesPerSecond < 5f) ? (num3 * 1.2) : ((AppliedHeadingChange_DegreesPerSecond < 10f) ? (num3 * 1.3) : ((!(AppliedHeadingChange_DegreesPerSecond < 20f)) ? (num3 * 2.0) : (num3 * 1.5))));
		}
		if (IncreaseDragCoefficientForPositivePitch)
		{
			num3 *= (double)Math.Abs(2f + (myWeapon.Attitude_Pitch - float_2) / 5f);
		}
		double num4 = 0.5 * num * Math.Pow(num2, 2.0) * num3 * double_0;
		double num5 = smethod_1(num2, weapon_0.Attitude_Pitch, weapon_0.Diameter, weapon_0.Span, Altitude);
		return num4 + num5;
	}

	private static double smethod_0(float float_3, float float_4, float float_5, double double_1, float float_6, double double_2 = 1.0)
	{
		double num = Physics.CalculateStandardAirDensity(float_6);
		double num2 = float_5 * float_4;
		double num3 = 0.5 * num * double_1 * double_1;
		double num4 = (double)float_3 * 9.80665 / (num3 * num2);
		double num5 = double_2 * num4 * num4;
		return num3 * num2 * num5;
	}

	private static double smethod_1(double double_1, float float_3, float float_4, float float_5, float float_6)
	{
		if (!(float_3 > 15f) && float_3 >= -1f)
		{
			double num = 0.1 + 0.08 * (double)float_3;
			double num2 = float_5 * float_4;
			double num3 = float_5 / float_4;
			double num4 = Physics.CalculateStandardAirDensity(float_6);
			double num5 = num * num / (2.199114857512853 * num3);
			return 0.5 * num4 * double_1 * double_1 * num2 * num5;
		}
		return 0.0;
	}

	protected void SpeedChangeDueToDrag(float elapsedTime, float AppliedPitchChange_DegreesPerSecond, float AppliedHeadingChange_DegreesPerSecond, float AltitudeOverride = -99999f, Weather.WeatherProfile theWeatherProfile = null, short theTemperatureAtSL_C = -9999)
	{
		if (float_1 == -1f)
		{
			float_1 = myWeapon.BurnoutWeight();
		}
		float currentSpeed = weapon_0.CurrentSpeed;
		if (AltitudeOverride == -99999f)
		{
			AltitudeOverride = weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		if (weapon_0.IsDLZconstruct && !weapon_0.FlightEndurance.HasValue)
		{
			if (theWeatherProfile == null)
			{
				theWeatherProfile = Weather.WeatherProfile.get_StandardWeatherProfile(weapon_0.ParentScen);
			}
			if (theTemperatureAtSL_C == -9999)
			{
				theTemperatureAtSL_C = (short)Math.Round(theWeatherProfile.AverageTemp);
			}
		}
		else
		{
			if (theWeatherProfile == null)
			{
				theWeatherProfile = weapon_0.WeatherAtMyLocation;
			}
			if (theTemperatureAtSL_C == -9999)
			{
				theTemperatureAtSL_C = theWeatherProfile.ActualTempAtAltitude_CurrentScenarioTime(weapon_0.ParentScen, weapon_0.get_Latitude((GlobalVariables.BooleanObject)null), weapon_0.get_Longitude((GlobalVariables.BooleanObject)null), 0f);
			}
		}
		if (float_2 == float.MaxValue)
		{
			float_2 = weapon_0.InfiniteGlideAngle;
		}
		if (elapsedTime > 0.1f && Module_Unit.CurrentSpeed_Vertical(weapon_0, weapon_0.ParentScen) != 0f)
		{
			int num = (int)Math.Round(elapsedTime / 0.1f);
			float num2 = Module_Unit.CurrentSpeed_Vertical(weapon_0, weapon_0.ParentScen);
			int num3 = num;
			for (int i = 1; i <= num3; i++)
			{
				float altitudeOverride = weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num2 * 0.1f * (float)(num - i);
				SpeedChangeDueToDrag(0.1f, AppliedPitchChange_DegreesPerSecond, AppliedHeadingChange_DegreesPerSecond, altitudeOverride, theWeatherProfile, theTemperatureAtSL_C);
			}
		}
		else
		{
			if (AltitudeOverride < 0f)
			{
				AltitudeOverride = 0f;
			}
			double num4 = CalculateDragForce(currentSpeed, AppliedPitchChange_DegreesPerSecond, AppliedHeadingChange_DegreesPerSecond, AltitudeOverride, theTemperatureAtSL_C, float_1) / (double)float_1 * (double)elapsedTime * 1.94384;
			weapon_0.CurrentSpeed = (float)((double)currentSpeed - num4);
		}
	}

	internal int StallSpeed(float theAltitude)
	{
		return (int)Math.Round((double)GetMaximumSpeed(theAltitude) / 5.0);
	}

	protected void Move_BoostCoast(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ)
	{
		if (!SimplifiedCalcs_DLZ)
		{
			_ = myWeapon.CurrentAltitude_AGL;
		}
		float appliedPitchChange_DegreesPerSecond = Math.Abs(myWeapon.Attitude_Pitch - myWeapon.DesiredPitch) / elapsedTime;
		float appliedHeadingChange_DegreesPerSecond = Math.Abs(MathFunctions.AngularDifference_SmallestValue(myWeapon.CurrentHeading, ((ActiveUnit)myWeapon).DesiredHeading)) / elapsedTime;
		float num = Math.Max(GetMaximumSpeed(myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), Module_Weapon.TerminalVelocity(myWeapon));
		if (myWeapon.SupportsAttitude_Pitch)
		{
			AdjustAttitude_Pitch(elapsedTime);
		}
		int num2;
		if (myWeapon.IsReEntryVehicle & !myWeapon.IsHGV)
		{
			num2 = 0;
		}
		else
		{
			if (!(myWeapon.IsBallisticMissile & !myWeapon.IsHGV))
			{
				goto IL_00c9;
			}
			num2 = 0;
		}
		CheckForMinimumSafeHeight = (byte)num2 != 0;
		goto IL_00c9;
		IL_00c9:
		ChangeAltitude(elapsedTime, myUnit.DesiredAltitude, null, !myWeapon.IsBallisticMissile && !myWeapon.IsReEntryVehicle);
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
		method_7(elapsedTime);
		SpeedChangeDueToDrag(elapsedTime, appliedPitchChange_DegreesPerSecond, appliedHeadingChange_DegreesPerSecond, -99999f, null, -9999);
		if (myWeapon.Altitude_old > myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && myWeapon.CurrentSpeed > num)
		{
			myWeapon.CurrentSpeed = num;
		}
		if (CheckForMinimumSafeHeight && (myWeapon.IsMissile || myWeapon.IsDecoy) && myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 9000f && (!myWeapon.IsAAWCapable || !myWeapon.IsASAT))
		{
			if (myWeapon.SupportsAttitude_Pitch && (Information.IsNothing((object)myWeapon.AI.PrimaryTarget) || myWeapon.AI.PrimaryTarget is AimpointContact) && myWeapon.Attitude_Pitch < -10f)
			{
				if (myWeapon.CurrentAltitude_AGL <= 0f)
				{
					Weapon weapon = myWeapon;
					double theLat = myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon = myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt = myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG = GameGeneral.GlobalRNG;
					weapon.Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
				}
			}
			else
			{
				float value = myWeapon.get_MinimumSafeHeight(bool_5: false).Value;
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < value)
				{
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
				}
			}
		}
		myUnit.updateLastReportedInfo();
		if (!SimplifiedCalcs_DLZ)
		{
			myUnit.Kinematics.ExportLocationEvent();
		}
		if (!SimplifiedCalcs_DLZ)
		{
			if (myWeapon.IsTorpedo && myUnit.IsUnderground)
			{
				Weapon weapon2 = myWeapon;
				double latitude_old = myUnit.Latitude_old;
				double longitude_old = myUnit.Longitude_old;
				float theAlt2 = myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				LockRandom theRNG = GameGeneral.GlobalRNG;
				weapon2.Detonate(latitude_old, longitude_old, theAlt2, ref theRNG, Detonation_AddMessage: true);
			}
			if (myWeapon.CurrentAltitude_AGL <= 0f && myWeapon.Attitude_Pitch <= 0f && (myWeapon.IsBallisticMissile || myWeapon.IsReEntryVehicle) && !myWeapon.ImpactsOnThisPulse_ActualUnit && !myWeapon.ImpactsOnThisPulse_Contact)
			{
				Weapon weapon3 = myWeapon;
				double theLat2 = myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
				double theLon2 = myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
				float theAlt3 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
				LockRandom theRNG = GameGeneral.GlobalRNG;
				weapon3.Detonate(theLat2, theLon2, theAlt3, ref theRNG, Detonation_AddMessage: true);
			}
		}
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		if (weapon_0 == null)
		{
			weapon_0 = (Weapon)myUnit;
		}
		weapon_0.TimeSinceLaunch += elapsedTime;
		if (weapon_0.Type == Weapon._WeaponType.Sonobuoy)
		{
			return;
		}
		if (weapon_0.IsReEntryVehicle && !Module_Unit.IsWithinAtmosphere(myUnit))
		{
			SimpleBallisticFlight_Vaccum(elapsedTime, myUnit.Attitude_Pitch, SimplifiedCalcs_DLZ);
			if (!SimplifiedCalcs_DLZ)
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
			return;
		}
		if (weapon_0.UsesBoostCoastModel.Value && weapon_0.TimeSinceLaunch > (float)weapon_0.TotalBurnTime)
		{
			Move_BoostCoast(elapsedTime, CheckForMinimumSafeHeight, SimplifiedCalcs_DLZ);
			return;
		}
		try
		{
			if (weapon_0.IsWeaponPallet & (weapon_0.Attitude_Pitch == weapon_0.DesiredPitch))
			{
				weapon_0.Kinematics.Loiter(elapsedTime);
			}
			if (!SimplifiedCalcs_DLZ)
			{
				_ = weapon_0.CurrentAltitude_AGL;
			}
			if (weapon_0.SupportsAttitude_Pitch)
			{
				if (weapon_0.Flags.LoiterCapability)
				{
					float num = (float)(Math.Atan((double)myUnit.Kinematics.ClimbRate_Max() / ((double)myUnit.Kinematics.GetMaximumSpeed() * 0.514444)) * 57.2957795130823);
					if (myUnit.DesiredPitch > num)
					{
						myUnit.DesiredPitch = num;
					}
				}
				AdjustAttitude_Pitch(elapsedTime);
			}
			int num2;
			if (weapon_0.IsReEntryVehicle & !weapon_0.IsHGV)
			{
				num2 = 0;
			}
			else
			{
				if (!(weapon_0.IsBallisticMissile & !weapon_0.IsHGV))
				{
					goto IL_01cc;
				}
				num2 = 0;
			}
			CheckForMinimumSafeHeight = (byte)num2 != 0;
			goto IL_01cc;
			IL_0724:
			bool flag;
			double num3;
			float num4;
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(elapsedTime, (float)num3, num4);
			}
			if (CheckForMinimumSafeHeight)
			{
				if (weapon_0.IsASCMwithoutTFcapability())
				{
					float value = weapon_0.get_MinimumSafeHeight(bool_5: false).Value;
					if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < value)
					{
						myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
					}
				}
				else if ((weapon_0.IsMissile || weapon_0.IsDecoy) && weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation && (!weapon_0.IsAAWCapable || !weapon_0.IsASAT))
				{
					if (weapon_0.SupportsAttitude_Pitch && ((weapon_0.AI.PrimaryTarget == null && !weapon_0.Flags.LoiterCapability) || weapon_0.AI.PrimaryTarget is AimpointContact) && weapon_0.Attitude_Pitch < -10f)
					{
						if (weapon_0.CurrentAltitude_AGL <= 0f)
						{
							weapon_0.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f - weapon_0.CurrentAltitude_AGL);
							if (!weapon_0.ImpactsOnThisPulse_ActualUnit && !weapon_0.ImpactsOnThisPulse_Contact)
							{
								Weapon weapon = weapon_0;
								double theLat = weapon_0.get_Latitude((GlobalVariables.BooleanObject)null);
								double theLon = weapon_0.get_Longitude((GlobalVariables.BooleanObject)null);
								float theAlt = weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								LockRandom theRNG = GameGeneral.GlobalRNG;
								weapon.Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
							}
						}
					}
					else
					{
						float value2 = weapon_0.get_MinimumSafeHeight(bool_5: false).Value;
						if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < value2 && !weapon_0.ImpactsOnThisPulse_ActualUnit && !weapon_0.ImpactsOnThisPulse_Contact)
						{
							myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value2);
						}
					}
				}
			}
			myUnit.updateLastReportedInfo();
			if (!SimplifiedCalcs_DLZ)
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
			if (!SimplifiedCalcs_DLZ)
			{
				if (weapon_0.IsTorpedo && myUnit.IsUnderground)
				{
					Weapon weapon2 = weapon_0;
					double latitude_old = myUnit.Latitude_old;
					double longitude_old = myUnit.Longitude_old;
					float theAlt2 = weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG = GameGeneral.GlobalRNG;
					weapon2.Detonate(latitude_old, longitude_old, theAlt2, ref theRNG, Detonation_AddMessage: true);
				}
				bool isAerospaceUnit = weapon_0.IsAerospaceUnit;
				if (!(weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f && isAerospaceUnit))
				{
					if (weapon_0.CurrentAltitude_AGL <= 0f && weapon_0.Attitude_Pitch <= 0f && (weapon_0.IsBallisticMissile || weapon_0.IsReEntryVehicle) && !weapon_0.ImpactsOnThisPulse_ActualUnit && !weapon_0.ImpactsOnThisPulse_Contact)
					{
						weapon_0.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground");
						Weapon weapon3 = weapon_0;
						double theLat2 = weapon_0.get_Latitude((GlobalVariables.BooleanObject)null);
						double theLon2 = weapon_0.get_Longitude((GlobalVariables.BooleanObject)null);
						float theAlt3 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
						LockRandom theRNG = GameGeneral.GlobalRNG;
						weapon3.Detonate(theLat2, theLon2, theAlt3, ref theRNG, Detonation_AddMessage: true);
					}
				}
				else if (!weapon_0.ImpactsOnThisPulse_ActualUnit && !weapon_0.ImpactsOnThisPulse_Contact)
				{
					weapon_0.EndgameReport.AddEndGameMessage(hit: false, "Has splashed into water");
					Weapon weapon4 = weapon_0;
					double theLat3 = weapon_0.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon3 = weapon_0.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt4 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
					LockRandom theRNG = GameGeneral.GlobalRNG;
					weapon4.Detonate(theLat3, theLon3, theAlt4, ref theRNG, Detonation_AddMessage: true);
				}
			}
			Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
			return;
			IL_01cc:
			if (myUnit.DesiredSpeed < 0f)
			{
				myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
			}
			if (weapon_0.Type == Weapon._WeaponType.Torpedo)
			{
				if (myUnit.DesiredAltitude > 0f)
				{
					myUnit.DesiredAltitude = 0f;
				}
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f)
				{
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
				}
			}
			ChangeAltitude(elapsedTime, myUnit.DesiredAltitude, null, !weapon_0.IsBallisticMissile && !weapon_0.IsReEntryVehicle);
			if (weapon_0.Type == Weapon._WeaponType.Torpedo && myUnit.CurrentAltitude_AGL != 0f && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen))
			{
				if (((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) < -1)
				{
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) + 1));
				}
				else
				{
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -1f);
				}
			}
			num4 = GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: true);
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
			}
			else
			{
				myUnit.DesiredSpeed = num4;
			}
			if (SpeedForSimultaneousTOT != -1f)
			{
				myUnit.DesiredSpeed = SpeedForSimultaneousTOT;
			}
			if (!myUnit.AI.HoldPosition)
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
				{
					if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None && !myUnit.Navigator.IsManouveringToFormationStation)
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
						{
							myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
						}
					}
					else
					{
						myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), myUnit.Kinematics.DesiredSpeedOverride.Value);
					}
				}
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
			if (myUnit.IsOutOfFuel)
			{
				if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
				{
					if (!(myUnit.Attitude_Pitch <= ((Weapon)myUnit).InfiniteGlideAngle))
					{
						num4 = 0f;
					}
				}
				else
				{
					num4 = 0f;
				}
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
			num3 = (double)Math.Abs(MathFunctions.AngularDifference((float)num5, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
			CalcTurnDeceleration(num3, elapsedTime);
			flag = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
			{
				int num6;
				if (!myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					num6 = 1;
				}
				else
				{
					int? num7 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = ((!num7.HasValue) ? ((bool?)null) : new bool?(num7 == 15));
					if (((!flag2) ?? flag2) != true)
					{
						goto IL_0724;
					}
					num6 = 1;
				}
				flag = (byte)num6 != 0;
			}
			goto IL_0724;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100981", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8()
	{
		myUnit.AI.IsPerformingSpeedAdjustmentToT = false;
		myWeapon.CurrentSpeed = myWeapon.AI.SpeedAdjustmentToT_OriginalSpeed.Value;
		myWeapon.DesiredSpeed = myWeapon.AI.SpeedAdjustmentToT_OriginalSpeed.Value;
		DesiredSpeedOverride = myWeapon.AI.SpeedAdjustmentToT_OriginalSpeed.Value;
	}

	public override float ClimbRate_Actual(float theCurrentPitch)
	{
		if (!myUnit.SupportsAttitude_Pitch)
		{
			return ((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
		}
		if (theCurrentPitch <= 0f)
		{
			return 0f;
		}
		if (myWeapon.IsABMOptimized())
		{
			return (float)(Math.Max((double)myWeapon.CurrentSpeed * 0.514444, ((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true)) * Math2.Sind(theCurrentPitch));
		}
		return (float)((double)myWeapon.CurrentSpeed * 0.514444 * Math2.Sind(theCurrentPitch));
	}

	public override void CalcTurnDeceleration(double ActualTurnRate, float elapsedTime)
	{
		try
		{
			if ((int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) <= 5)
			{
				return;
			}
			double num = default(double);
			switch (((Weapon)myUnit).Type)
			{
			case Weapon._WeaponType.Torpedo:
				if (ActualTurnRate > 25.0)
				{
					num = 1f * elapsedTime;
				}
				if (ActualTurnRate > 45.0)
				{
					num = 2f * elapsedTime;
				}
				break;
			case Weapon._WeaponType.GuidedWeapon:
				if (ActualTurnRate > 25.0)
				{
					num = 5f * elapsedTime;
				}
				if (ActualTurnRate > 45.0)
				{
					num = 10f * elapsedTime;
				}
				break;
			}
			myUnit.CurrentSpeed = (float)Math.Max((double)myUnit.CurrentSpeed - num, 0.0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101330", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float DiveRate_Nominal()
	{
		Weapon._WeaponType type = ((Weapon)myUnit).Type;
		if (type == Weapon._WeaponType.GuidedWeapon)
		{
			return Math.Max(100f, ((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true));
		}
		return ((ActiveUnit_Kinematics)this).get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
	}

	public override float DiveRate_Actual(float theCurrentPitch)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (theCurrentPitch >= 0f)
			{
				return 0f;
			}
			if (!myWeapon.IsABMOptimized())
			{
				return (float)((double)myWeapon.CurrentSpeed * 0.514444 * Math.Abs(Math2.Sind(theCurrentPitch)));
			}
			return (float)(Math.Max((double)myWeapon.CurrentSpeed * 0.514444, DiveRate_Nominal()) * Math.Abs(Math2.Sind(theCurrentPitch)));
		}
		return DiveRate_Nominal();
	}

	internal float MinimumDesiredAverageSpeedMultiplier()
	{
		if (myWeapon.IsAAWCapable)
		{
			if (myWeapon.IsABMOptimized())
			{
				return 0.9f;
			}
			if (myWeapon.MaxAirRange <= 15f)
			{
				return 0.8f;
			}
			if (myWeapon.Propulsion.Count <= 0)
			{
				return 0.55f;
			}
			switch (myWeapon.Propulsion.First().Type)
			{
			case Engine.EngineType.Rocket_BoostCoast:
				return 0.55f;
			case Engine.EngineType.Ramjet:
				return 0.85f;
			case Engine.EngineType.Turbojet:
			case Engine.EngineType.Rocket_LongBurn:
				return 0.75f;
			}
		}
		if (!myWeapon.IsASuW_Land && !myWeapon.IsASuW_Naval)
		{
			return 0.5f;
		}
		return 0.6f;
	}

	internal static double EstimateLaunchSpeedKnots(double altitudeMeters)
	{
		double val = altitudeMeters * 3.28084;
		val = Math.Max(0.0, Math.Min(val, 80000.0));
		double x;
		double num;
		double num2;
		if (val <= 36000.0)
		{
			x = val / 36000.0;
			num = 0.9;
			num2 = 1.5;
		}
		else
		{
			x = (val - 36000.0) / 44000.0;
			num = 1.5;
			num2 = 2.0;
		}
		double num3 = Math.Pow(x, 1.6);
		double num4 = num + (num2 - num) * num3;
		double num5 = smethod_2(val);
		return num4 * num5;
	}

	private static double smethod_2(double double_1)
	{
		double num = ((!(double_1 <= 36089.0)) ? 216.65 : (288.15 - 0.0019812 * double_1));
		return Math.Sqrt(401.87 * num) * 1.94384;
	}

	private List<double> method_9()
	{
		List<double> list = new List<double>();
		if (myWeapon.Propulsion.Count > 0)
		{
			short tempAtSL_C = (short)Math.Round(Weather.DefaultWeather().AverageTemp);
			double num = 339.53304;
			int maxWeight = weapon_0.MaxWeight;
			AltBand[] altBands = weapon_0.Propulsion[0].AltBands;
			double num2 = default(double);
			foreach (AltBand altBand in altBands)
			{
				if (altBand.Speed_Cruise > 0)
				{
					num2 = 0.0;
					float num3 = altBand.Speed_Cruise;
					float minAlt = altBand.MinAlt;
					num = (double)(float)EstimateLaunchSpeedKnots(minAlt) * 0.514444;
					double num4 = CalculateDragForce(num3, 0f, 0f, minAlt, tempAtSL_C, maxWeight);
					num2 = num4;
					if (num2 / (double)maxWeight * (double)weapon_0.TotalBurnTime < (double)num3 * 0.514444)
					{
						double num5 = (double)num3 * 0.514444;
						if (num < num5)
						{
							double num6 = (num5 - num) / (double)weapon_0.TotalBurnTime;
							double num7 = 0.0;
							double num8 = (float)num;
							double num9 = num8;
							double num10 = weapon_0.TotalBurnTime;
							Sgp_Deep.t = 1.0;
							while (Sgp_Deep.t <= num10)
							{
								num9 = num8;
								num8 = num + Sgp_Deep.t * num6;
								num7 += (num8 - num9) * (double)maxWeight;
								float velocity_Kts = (float)(num8 * 1.94384);
								double num11 = CalculateDragForce(velocity_Kts, 0f, 0f, minAlt, tempAtSL_C, maxWeight);
								num8 -= num11 / (double)maxWeight;
								Sgp_Deep.t += 1.0;
							}
							double num12 = (num7 + num4) / (double)weapon_0.TotalBurnTime;
							if (num12 > num2)
							{
								num2 = num12;
							}
						}
					}
				}
				list.Add(num2);
			}
		}
		return list;
	}

	private void method_10(float float_3, double double_1, float float_4)
	{
		if (double_1 <= 0.0 || weapon_0.TimeSinceLaunch > (float)weapon_0.TotalBurnTime)
		{
			return;
		}
		if (float_4 == 0f)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else
		{
			double num = double_1 / (double)float_4 * (double)float_3 * 1.94384;
			weapon_0.CurrentSpeed = (float)((double)weapon_0.CurrentSpeed + num);
		}
	}

	public void AdjustLaunchSpeedDependentBurnoutSpeedPerBand_ALTERNATE(int BurnTime, int ActualLaunchSpeed)
	{
		Engine engine = myWeapon.Propulsion[0];
		AltBand[] altBands = engine.AltBands;
		Weather.WeatherProfile weatherProfile = new Weather.WeatherProfile();
		short theTemperatureAtSL_C = (short)Math.Round(weatherProfile.AverageTemp);
		Weapon newWeapon = Weapon.GetNewWeapon(ref myUnit.ParentScen, myUnit.DBID, bool_5: true);
		newWeapon.IsDLZconstruct = true;
		newWeapon.Kinematics.weapon_0 = newWeapon.Kinematics.myWeapon;
		newWeapon.TotalBurnTime = myWeapon.TotalBurnTime;
		newWeapon.FlightEndurance = myWeapon.FlightEndurance;
		if (list_1 == null)
		{
			list_1 = method_9();
		}
		newWeapon.Kinematics.list_1 = list_1;
		newWeapon.BurnoutWeight();
		int num = altBands.Length - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				AltBand altBand = altBands[num2];
				altBands[num2] = altBands[num2].Clone();
				AltBand altBand2 = altBands[num2];
				double num3 = list_1[num2];
				if (num3 / (double)myWeapon.MaxWeight * (double)myWeapon.TotalBurnTime * 1.94384 > (double)(2 * altBand2.Speed_Cruise))
				{
					break;
				}
				int num4 = ActualLaunchSpeed;
				int num5 = (int)Math.Round(altBand2.MinAlt);
				newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)num5);
				newWeapon.Altitude_old = newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				newWeapon.Attitude_Pitch = 0f;
				newWeapon.CurrentSpeed = ActualLaunchSpeed;
				newWeapon.CurrentVerticalRate_mpersec = 0f;
				newWeapon.Kinematics.float_1 = newWeapon.MaxWeight;
				for (int i = 1; i <= BurnTime; i++)
				{
					newWeapon.TimeSinceLaunch = i;
					newWeapon.Kinematics.method_10(1f, num3, newWeapon.Kinematics.float_1);
					newWeapon.Kinematics.SpeedChangeDueToDrag(1f, 0f, 0f, num5, weatherProfile, theTemperatureAtSL_C);
					if (newWeapon.CurrentSpeed > (float)num4)
					{
						num4 = (int)Math.Round(newWeapon.CurrentSpeed);
					}
				}
				altBand2.Speed_Cruise = (int)Math.Round((double)newWeapon.CurrentSpeed + 0.5);
				if (altBand == engine.HighestAltBand)
				{
					engine.HighestAltBand = altBand2;
				}
				myWeapon.Kinematics.updateCachedHighestAltBand(altBand, altBand2);
				num2++;
				continue;
			}
			myWeapon._LaunchSpeedDependentBurnoutSpeedsSet = true;
			break;
		}
	}

	public void AdjustLaunchSpeedDependentBurnoutSpeedPerBand(int BurnTime, int ActualLaunchSpeed)
	{
		float num = (float)(Math.PI * Math.Pow((double)myWeapon.Diameter * 0.5, 2.0));
		Engine engine = myWeapon.Propulsion[0];
		AltBand[] altBands = engine.AltBands;
		RocketMaxSpeed rocketMaxSpeed = new RocketMaxSpeed(myWeapon, myWeapon.MaxWeight, myWeapon.BurnoutWeight(), num, BurnTime, myWeapon.Length, myWeapon.Diameter, altBands, myWeapon.TechGeneration);
		int num2 = altBands.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			AltBand altBand = altBands[i];
			altBands[i] = altBands[i].Clone();
			AltBand altBand2 = altBands[i];
			_ = "Band #" + Conversions.ToString(i + 1) + ": " + Conversions.ToString(altBand2.MinAlt) + "-" + Conversions.ToString(altBand2.MaxAlt) + "m - " + Conversions.ToString(altBand2.Speed_Cruise) + " >> ";
			int num3 = ((i != altBands.Length - 1) ? ((int)Math.Round(altBand2.MaxAlt)) : 10973);
			rocketMaxSpeed.ComputeBurnoutSpeed(myWeapon, num3, Physics.ComputeMach(num3, ActualLaunchSpeed), out var burnoutSpeedMs, out var _);
			altBand2.Speed_Cruise = (int)Math.Round(burnoutSpeedMs * 1.94384);
			if (altBand == engine.HighestAltBand)
			{
				engine.HighestAltBand = altBand2;
			}
			myWeapon.Kinematics.updateCachedHighestAltBand(altBand, altBand2);
		}
		myWeapon._LaunchSpeedDependentBurnoutSpeedsSet = true;
	}

	private static long smethod_3(int int_1, int int_2)
	{
		return ((long)int_1 << 32) | int_2;
	}

	public int GetMaximumSpeedForThisAltitude(float Altitude)
	{
		int result;
		if (Altitude <= 100000f)
		{
			try
			{
				if (myWeapon.ParentScen.Cache_WeaponMaxSpeedsPerAltitude == null)
				{
					lock (myWeapon)
					{
						if (myWeapon.ParentScen.Cache_WeaponMaxSpeedsPerAltitude == null)
						{
							string theQuery = "SELECT MAX(ID) FROM DataWeapon";
							int maxFirstKey = Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(myWeapon.ParentScen.DBConnection), theQuery));
							myWeapon.ParentScen.Cache_WeaponMaxSpeedsPerAltitude = new JaggedConcurrentMap<int>(maxFirstKey);
						}
					}
				}
				int value = default(int);
				if (myWeapon.ParentScen.Cache_WeaponMaxSpeedsPerAltitude.TryGetValue(myWeapon.DBID, (int)Math.Round(Altitude), ref value))
				{
					result = value;
					goto IL_04a0;
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
		else if (int_0 > int.MinValue)
		{
			result = int_0;
			goto IL_04a0;
		}
		AltBand altBand = null;
		ObservableList<Engine> propulsion = myUnit.Propulsion;
		List<AltBand> result2 = default(List<AltBand>);
		try
		{
			if (propulsion.Count == 0)
			{
				result = 0;
			}
			else
			{
				Engine engine = propulsion[0];
				AltBand[] altBands = engine.AltBands;
				if (engine.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0;
				}
				else if (altBands.Length != 0)
				{
					if (Altitude > 100000f)
					{
						AltBand altBand2 = altBands[^1];
						if (altBand2.Speed_Full.HasValue)
						{
							int_0 = altBand2.Speed_Full.Value;
						}
						else
						{
							int_0 = altBand2.Speed_Cruise;
						}
						result = int_0;
					}
					else
					{
						AltBand altBand3 = ((!myUnit.IsWeapon) ? GetCurrentAltBand_CurrentAltitude(Altitude, null, ValidateAndFixAltitude: false) : GetCurrentAltBand_CurrentAltitude(Altitude, engine, ValidateAndFixAltitude: false));
						if (altBand3 == null)
						{
							result = 0;
						}
						else
						{
							int value2 = altBand3.MaxSpeed.Value;
							int num = value2;
							if (altBand3 != HighestAltBand(propulsion[0]))
							{
								if (ActiveUnit_Kinematics.AltBandListCache.TryDequeue(out result2))
								{
									result2.Clear();
								}
								else
								{
									result2 = new List<AltBand>();
								}
								AltBand[] array = altBands;
								foreach (AltBand altBand4 in array)
								{
									if (altBand4.MinAlt >= altBand3.MaxAlt && altBand4 != null)
									{
										result2.Add(altBand4);
									}
								}
								int count = result2.Count;
								if (count > 1)
								{
									try
									{
										result2.Sort(new AltBandComparer_SortyByMaxAltAscending());
										altBand = result2[0];
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										altBand = result2.OrderBy([SpecialName] (AltBand theAB) => theAB.MaxAlt).ElementAtOrDefault(0);
										ProjectData.ClearProjectError();
									}
								}
								else if (count > 0)
								{
									altBand = result2[0];
								}
								else
								{
									_ = Debugger.IsAttached;
									altBand = HighestAltBand(propulsion[0]);
								}
								float num2 = default(float);
								if (altBand == null)
								{
									if (result2.Count > 0)
									{
										altBand = result2[0];
										num2 = altBand.MaxSpeed.Value;
									}
								}
								else
								{
									num2 = altBand.MaxSpeed.Value;
								}
								try
								{
									num2 = (altBand.MaxSpeed?.Value).Value;
								}
								catch (Exception projectError3)
								{
									ProjectData.SetProjectError(projectError3);
									if (result2.Count > 0)
									{
										altBand = result2[0];
										num2 = (altBand.MaxSpeed?.Value).Value;
									}
									ProjectData.ClearProjectError();
								}
								if (altBand3.MinAlt == altBand.MinAlt)
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									num = value2;
								}
								else
								{
									num = (int)Math.Round(num2 + (Altitude - altBand.MinAlt) * ((float)value2 - num2) / (altBand3.MinAlt - altBand.MinAlt));
								}
							}
							if (result2 != null)
							{
								result2.Clear();
								ActiveUnit_Kinematics.AltBandListCache.Enqueue(result2);
							}
							if (Altitude < 100000f)
							{
								try
								{
									myWeapon.ParentScen.Cache_WeaponMaxSpeedsPerAltitude.TryAdd(myWeapon.DBID, (int)Math.Round(Altitude), num);
								}
								catch (Exception projectError4)
								{
									ProjectData.SetProjectError(projectError4);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							result = num;
						}
					}
				}
				else
				{
					result = 0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100187", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			int num3;
			if (result2 == null)
			{
				num3 = 0;
			}
			else
			{
				result2.Clear();
				ActiveUnit_Kinematics.AltBandListCache.Enqueue(result2);
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		goto IL_04a0;
		IL_04a0:
		return result;
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		AltBand altBand = null;
		AltBand altBand2 = null;
		Engine engine = null;
		int result;
		try
		{
			if (!float.IsNaN(Altitude))
			{
				if (ThrottleSetting != ActiveUnit.Throttle.FullStop)
				{
					if (myUnit.Propulsion.Count != 0)
					{
						altBand = GetCurrentAltBand_CurrentAltitude(Altitude, null, ValidateAndFixAltitude);
						if (altBand != null)
						{
							if (myUnit.Propulsion.Count > 0)
							{
								engine = myUnit.Propulsion[0];
								if (engine != null)
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
											num = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
											break;
										case ActiveUnit.Throttle.Flank:
											num = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value)));
											break;
										}
										float num2 = (int)Math.Round(num);
										if (altBand != HighestAltBand(engine))
										{
											float num3 = float.MaxValue;
											AltBand[] array = altBands;
											foreach (AltBand altBand3 in array)
											{
												if (altBand3.MinAlt >= altBand.MaxAlt && altBand3.MaxAlt < num3)
												{
													altBand2 = altBand3;
												}
											}
											if (altBand2 != null)
											{
												float num4 = default(float);
												switch (ThrottleSetting)
												{
												case ActiveUnit.Throttle.FullStop:
													num4 = 0f;
													break;
												case ActiveUnit.Throttle.Loiter:
													num4 = altBand2.Speed_Loiter;
													break;
												case ActiveUnit.Throttle.Cruise:
													num4 = altBand2.Speed_Cruise;
													break;
												case ActiveUnit.Throttle.Full:
													num4 = (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise));
													break;
												case ActiveUnit.Throttle.Flank:
													num4 = ((!altBand2.Speed_Flank.HasValue) ? ((!altBand2.Speed_Full.HasValue) ? ((float)altBand2.Speed_Cruise) : ((float)altBand2.Speed_Full.Value)) : ((float)altBand2.Speed_Flank.Value));
													break;
												}
												num2 = (int)Math.Round(num4 + (Altitude - altBand2.MinAlt) * (num - num4) / (altBand.MinAlt - altBand2.MinAlt));
											}
										}
										result = (int)Math.Round(num2);
									}
								}
								else
								{
									result = 0;
								}
							}
							else
							{
								result = 0;
							}
						}
						else
						{
							result = 0;
						}
					}
					else
					{
						result = 0;
					}
				}
				else
				{
					result = 0;
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
			ex2?.Data.Add("Error at 100982", "");
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
			result = num5;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void ChangeAltitude(float elapsedTime, float theDesiredAlt, float? MinimumSafeAltitude, bool DoSanityCheck)
	{
		try
		{
			float num = myUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
			if (!Module_Unit.IsRemoteSimEntity(myUnit))
			{
				_ = (double)((num - myUnit.Altitude_old) / elapsedTime);
				myUnit.Altitude_old = num;
				float num2 = num;
				if (myWeapon.IsReEntryVehicle)
				{
					if (myWeapon.AI.PrimaryTarget != null)
					{
						myWeapon.DesiredAltitude = ((Module_Unit.Unit)myWeapon.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						theDesiredAlt = myWeapon.DesiredAltitude;
					}
					if (myUnit.DesiredAltitude > num)
					{
						myUnit.DesiredAltitude = Math.Min(num - 1f, myUnit.DesiredAltitude);
					}
				}
				float attitude_Pitch = myUnit.Attitude_Pitch;
				float num3 = ClimbRate_Actual(attitude_Pitch) * elapsedTime;
				float num4 = DiveRate_Actual(attitude_Pitch) * elapsedTime;
				if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(theDesiredAlt < MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					theDesiredAlt = MinimumSafeAltitude.Value;
				}
				if (num < theDesiredAlt)
				{
					num2 = (myUnit.SupportsAttitude_Pitch ? (num + num3) : ((!(theDesiredAlt - num <= num3)) ? (num + num3) : theDesiredAlt));
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num2);
				}
				else if (num > theDesiredAlt)
				{
					num2 = (myUnit.SupportsAttitude_Pitch ? (num - num4) : ((!(num - theDesiredAlt <= num4)) ? (num - num4) : theDesiredAlt));
					if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(num2 <= MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
					{
						myUnit.Attitude_Pitch = 0f;
					}
					if (num2 > 5000f && Operators.CompareString(myWeapon.Name, "RIM-162B ESSM #4660", false) == 0)
					{
						Debugger.Break();
					}
					if (myWeapon.IsASCMwithoutTFcapability())
					{
						DoSanityCheck = false;
					}
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num2);
				}
				else
				{
					if (num == theDesiredAlt)
					{
						myUnit.DesiredPitch = 0f;
					}
					if (myUnit.Attitude_Pitch < 0f && MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(num <= MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
				num = myUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
				if (((Weapon)myUnit).IsWeaponPallet || myUnit.IsBallisticMissile)
				{
					return;
				}
				float maximumAltitude = GetMaximumAltitude();
				float minimumAltitude = GetMinimumAltitude();
				if (num > maximumAltitude)
				{
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, maximumAltitude);
					if (myUnit.Attitude_Pitch > 0f)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
				else if (num < minimumAltitude)
				{
					myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, minimumAltitude);
					if (myUnit.Attitude_Pitch < 0f)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			else
			{
				myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, num + myUnit.DeadReckoning_VerticalSpeed * elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 103459604287690345896708356790", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Weapon_Kinematics()
	{
		Class72.smethod_20();
	}
}
