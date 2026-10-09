using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Kinematics
{
	public enum UnitThrottlePreset : byte
	{
		FullStop,
		Loiter,
		Cruise,
		Full,
		Flank,
		None
	}

	public enum _SprintAndDriftCadence : short
	{
		Sprint,
		Drift
	}

	protected ActiveUnit myUnit;

	protected float _ClimbRate;

	internal const float DiveRate_HelicopterMax = 16.256f;

	protected float ActualMovementVector;

	protected float? _DesiredSpeedOverride;

	private bool bool_0;

	protected float _TacticalRadius;

	private AltBand altBand_0;

	protected int? _MaxSpeedTotal;

	private AltBand altBand_1;

	private string string_0;

	protected float _ReserveFuel;

	protected float _JokerFuel;

	public _SprintAndDriftCadence SprintAndDriftCadence;

	public bool HasAdjustedSpeedForCavitation;

	internal const int _MaxPositivePitchAngle = 89;

	internal const int _MaxNegativePitchAngle = -89;

	internal const int MaxRollAngle = 89;

	public const int DefaultSpeedLoiter = 3;

	public const int DefaultSpeedCruise = 10;

	public const int DefaultSpeedFull = 20;

	public const int DefaultSpeedFlank = 30;

	protected UnitThrottlePreset _ThrottlePreset;

	public BallisticTrajectory BallisticTrajectory;

	private float float_0;

	private float? nullable_0;

	protected static ConcurrentQueue<List<AltBand>> AltBandListCache;

	protected ObservableList<Engine> _MyPropulsion;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private List<AltBand> list_0;

	public virtual UnitThrottlePreset ThrottlePreset
	{
		get
		{
			return _ThrottlePreset;
		}
		set
		{
			_ThrottlePreset = value;
			if (value != UnitThrottlePreset.FullStop && value != UnitThrottlePreset.None)
			{
				myUnit.AI.HoldPosition = false;
			}
			try
			{
				if (myUnit.IsAircraft && myUnit.Kinematics.ThrottlePreset == UnitThrottlePreset.FullStop && !((Aircraft)myUnit).get_CanHover(bool_7: false))
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
				if (value != UnitThrottlePreset.None)
				{
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100169", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual float ReserveFuel
	{
		get
		{
			return _ReserveFuel;
		}
		set
		{
			_ReserveFuel = value;
		}
	}

	public virtual float JokerFuel
	{
		get
		{
			return _JokerFuel;
		}
		set
		{
			_JokerFuel = value;
		}
	}

	public virtual float? DesiredSpeedOverride
	{
		get
		{
			if (myUnit.IsGroupLead() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.LeadAllowedToSlowDown)
			{
				return null;
			}
			return _DesiredSpeedOverride;
		}
		set
		{
			try
			{
				_DesiredSpeedOverride = value;
				if (!value.HasValue)
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
				else if (myUnit.IsGroupLead())
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.LeadAllowedToSlowDown = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100170", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual bool DesiredAltitudeOverride
	{
		get
		{
			return bool_0;
		}
		set
		{
			try
			{
				bool_0 = value;
				if (!value)
				{
					if (myUnit.IsSubmarine)
					{
						((Submarine)myUnit).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					}
					if (myUnit.IsAircraft)
					{
						((Aircraft)myUnit).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100171", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual float ClimbRate_Nominal
	{
		get
		{
			return _ClimbRate;
		}
		set
		{
			_ClimbRate = value;
		}
	}

	static ActiveUnit_Kinematics()
	{
		Class72.smethod_20();
		AltBandListCache = new ConcurrentQueue<List<AltBand>>();
	}

	public bool Reinitialize()
	{
		altBand_1 = null;
		return false;
	}

	public virtual void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			if (ActualMovementVector != 0f)
			{
				theWriter.WriteElementString("AMV", XmlConvert.ToString(ActualMovementVector));
			}
			if (_DesiredSpeedOverride.HasValue)
			{
				theWriter.WriteElementString("DSO", _DesiredSpeedOverride.ToString());
			}
			if (bool_0)
			{
				theWriter.WriteElementString("DAO", bool_0.ToString());
			}
			if (_ReserveFuel != 0f)
			{
				theWriter.WriteElementString("ReserveFuel", _ReserveFuel.ToString());
			}
			if (ThrottlePreset != UnitThrottlePreset.FullStop)
			{
				theWriter.WriteElementString("SP", ((byte)ThrottlePreset).ToString());
			}
			if (SprintAndDriftCadence != _SprintAndDriftCadence.Sprint)
			{
				XmlWriter obj = theWriter;
				short sprintAndDriftCadence = (short)SprintAndDriftCadence;
				obj.WriteElementString("SADC", sprintAndDriftCadence.ToString());
			}
			if (BallisticTrajectory != null)
			{
				theWriter.WriteStartElement("BallisticTrajectory");
				BallisticTrajectory.ToXML(ref theWriter);
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100166", "");
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
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode val = childNode;
			try
			{
				switch (val.Name)
				{
				case "DSO":
				case "DesiredSpeedOverride":
					if (Operators.CompareString(val.InnerText, true.ToString(), false) != 0)
					{
						if (Operators.CompareString(val.InnerText, false.ToString(), false) != 0)
						{
							theAU.Kinematics._DesiredSpeedOverride = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						}
						else
						{
							theAU.Kinematics._DesiredSpeedOverride = null;
						}
					}
					else
					{
						theAU.Kinematics._DesiredSpeedOverride = theAU.DesiredSpeed;
					}
					break;
				case "SP":
					theAU.Kinematics.ThrottlePreset = (UnitThrottlePreset)Conversions.ToByte(val.InnerText);
					break;
				case "ReserveFuel":
					theAU.Kinematics._ReserveFuel = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "BallisticTrajectory":
				{
					ActiveUnit_Kinematics kinematics = theAU.Kinematics;
					XmlNode theNode2 = val.FirstChild;
					kinematics.BallisticTrajectory = BallisticTrajectory.FromXML(ref theNode2);
					break;
				}
				case "SADC":
					theAU.Kinematics.SprintAndDriftCadence = (_SprintAndDriftCadence)Conversions.ToShort(val.InnerText);
					break;
				case "DAO":
				case "DesiredAltitudeOverride":
					theAU.Kinematics.bool_0 = Misc.ParseBool(val.InnerText);
					break;
				case "AMV":
				case "ActualMovementVector":
					theAU.Kinematics.ActualMovementVector = XmlConvert.ToSingle(val.InnerText);
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100167", "");
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
			if (theAU.Kinematics.ReserveFuel == 0f && theAU.IsAircraft)
			{
				theAU.Kinematics.DetermineReserveFuelQty(Deserializing: true);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100168", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SimpleBallisticFlight_Vaccum(float elapsedTime, float StartingAngle, bool SimplifiedCalcs_DLZ)
	{
		double num = (double)myUnit.CurrentSpeed * 0.514444;
		double num2 = num * Math2.Sind(StartingAngle) - (double)elapsedTime * PhysicalConstants.FreeFallG_AtAltitude((int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		double x = num * Math2.Cosd(StartingAngle);
		double num3 = (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (double)elapsedTime * num2;
		myUnit.DesiredAltitude = (float)num3;
		ChangeAltitude(elapsedTime, myUnit.DesiredAltitude, null, DoSanityCheck: false);
		if (myUnit.CurrentHeading != myUnit.DesiredHeading)
		{
			TurnToDesiredHeading(elapsedTime);
		}
		myUnit.ActualHorizMovement(elapsedTime, SimplifiedCalcs_DLZ);
		double num4 = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num2, 2.0)) * 1.94384;
		myUnit.CurrentSpeed = (float)num4;
		myUnit.Attitude_Pitch = (float)(Math.Atan2(num2, x) * 57.2957795130823);
	}

	public HashSet<ActiveUnit.Throttle> GetThrottleRange((float, float) SpeedRange, float altitude = 0f)
	{
		HashSet<ActiveUnit.Throttle> hashSet = new HashSet<ActiveUnit.Throttle>();
		ActiveUnit.Throttle throttleSuitableForThisSpeed = GetThrottleSuitableForThisSpeed(altitude, SpeedRange.Item1);
		int throttleSuitableForThisSpeed2 = (int)GetThrottleSuitableForThisSpeed(altitude, SpeedRange.Item2);
		for (int i = (int)throttleSuitableForThisSpeed; i <= throttleSuitableForThisSpeed2; i++)
		{
			hashSet.Add((ActiveUnit.Throttle)i);
		}
		return hashSet;
	}

	public void FollowSpeedPreset()
	{
		if (myUnit != null && myUnit.Kinematics.DesiredSpeedOverride.HasValue)
		{
			switch (ThrottlePreset)
			{
			case UnitThrottlePreset.FullStop:
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				break;
			case UnitThrottlePreset.Loiter:
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				break;
			case UnitThrottlePreset.Cruise:
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				break;
			case UnitThrottlePreset.Full:
				myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				break;
			case UnitThrottlePreset.Flank:
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				break;
			}
			myUnit.Kinematics.DesiredSpeedOverride = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)ThrottlePreset, ValidateAndFixAltitude: false);
		}
	}

	public virtual void DetermineReserveFuelQty(bool Deserializing = false)
	{
		ReserveFuel = 0f;
	}

	public virtual float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return myUnit.UnitType switch
		{
			GlobalVariables.ActiveUnitType.Aircraft => ((Aircraft)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Ship => ((Ship)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Submarine => ((Submarine)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Facility => ((Facility)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Weapon => ((Weapon)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Satellite => ((Satellite)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			GlobalVariables.ActiveUnitType.Vehicle => ((Vehicle)myUnit).Kinematics.Acceleration_Actual(theThrottle, theAltitude, theSpeed), 
			_ => throw new NotImplementedException(), 
		};
	}

	public virtual float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return myUnit.UnitType switch
		{
			GlobalVariables.ActiveUnitType.Aircraft => ((Aircraft)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Ship => ((Ship)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Submarine => ((Submarine)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Facility => ((Facility)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Weapon => ((Weapon)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Satellite => ((Satellite)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			GlobalVariables.ActiveUnitType.Vehicle => ((Vehicle)myUnit).Kinematics.Acceleration_Nominal(theThrottle, theAltitude), 
			_ => throw new NotImplementedException(), 
		};
	}

	public virtual float ClimbRate_Actual(float theCurrentPitch)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (theCurrentPitch > 0f)
			{
				return (float)Math.Min(this.get_ClimbRate_Nominal(LimitByTrueAirspeed: true), (double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(theCurrentPitch));
			}
			return 0f;
		}
		return this.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
	}

	public virtual float ClimbRate_Max()
	{
		return _ClimbRate;
	}

	public virtual float RollRate()
	{
		return 0f;
	}

	public virtual float PitchRate_Positive()
	{
		return 0f;
	}

	public virtual float PitchRate_Negative()
	{
		return 0f;
	}

	public virtual float DiveRate_Nominal()
	{
		if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
		{
			if (_ClimbRate * 5f < 16.256f)
			{
				return _ClimbRate * 5f;
			}
			if (!((Aircraft)myUnit).IsTiltrotor)
			{
				return 16.256f;
			}
			return _ClimbRate * 3f;
		}
		return _ClimbRate * 3f;
	}

	public virtual float DiveRate_Max()
	{
		if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
		{
			return _ClimbRate * 5f;
		}
		return _ClimbRate * 3f;
	}

	public virtual float DiveRate_Actual(float theCurrentPitch)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (theCurrentPitch >= 0f)
			{
				return 0f;
			}
			return (float)Math.Min(DiveRate_Nominal(), (double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(Math.Abs(theCurrentPitch)));
		}
		return DiveRate_Nominal();
	}

	public virtual float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		return float.MaxValue;
	}

	public virtual float MaxRadius()
	{
		return float.MaxValue;
	}

	public virtual float TacticalRadius()
	{
		return float.MaxValue;
	}

	public virtual double MaxEndurance(ActiveUnit.Throttle theThrottleSetting, float? theSpeed, float? theAltitude, bool BingoFuelCheck, float theFormUpFuel)
	{
		return double.MaxValue;
	}

	internal bool HasPropulsion()
	{
		return myUnit.Propulsion.Count > 0;
	}

	public ActiveUnit_Kinematics(ref ActiveUnit theUnit)
	{
		_ReserveFuel = 0f;
		_JokerFuel = 0f;
		_ThrottlePreset = UnitThrottlePreset.None;
		BallisticTrajectory = null;
		float_0 = -99999f;
		list_0 = new List<AltBand>();
		myUnit = theUnit;
	}

	public void ResetMaxSpeed()
	{
		_MaxSpeedTotal = null;
	}

	internal bool isRotorized()
	{
		return GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false) == 0;
	}

	public virtual void Loiter(float elapsedTime, bool UseFormUpAltitude = false, bool UseLandingQueueAltitude = false)
	{
		myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(myUnit.CurrentHeading + 3f * elapsedTime));
		myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
		myUnit.LoiteredThisPulse = true;
	}

	public virtual void TurnToDesiredHeading(float elapsedTime)
	{
		if (myUnit.IsPalletWeapon)
		{
			return;
		}
		float currentHeading = myUnit.CurrentHeading;
		float desiredHeading = myUnit.DesiredHeading;
		try
		{
			float currentHeading2 = default(float);
			if (myUnit.IsBoat)
			{
				float num = adjustBoatHeadingChangeBasedOnRudderCurrentDeflection(currentHeading, desiredHeading, elapsedTime);
				currentHeading2 = Math2.NormalizeBearing(currentHeading + num);
			}
			else
			{
				float num2 = myUnit.Kinematics.TurnRate();
				if (myUnit.IsWeapon)
				{
					Weapon weapon = (Weapon)myUnit;
					if (weapon.Type == Weapon._WeaponType.GuidedWeapon)
					{
						num2 = weapon.Kinematics.GetAdjustedTurnRateBasedOnSpeedAndAltitude();
					}
				}
				num2 *= elapsedTime;
				if (num2 > 179f)
				{
					num2 = 179f;
				}
				switch (Misc.DetermineTurnDirection(currentHeading, desiredHeading))
				{
				case Misc.TurnDirection.TurnRight:
					currentHeading2 = Math2.NormalizeBearing(currentHeading + num2);
					if (IsRightOfDesired(currentHeading2, desiredHeading))
					{
						currentHeading2 = desiredHeading;
					}
					break;
				case Misc.TurnDirection.TurnLeft:
					currentHeading2 = Math2.NormalizeBearing(currentHeading - num2);
					if (IsLeftOfDesired(currentHeading2, desiredHeading))
					{
						currentHeading2 = desiredHeading;
					}
					break;
				}
			}
			myUnit.CurrentHeading = currentHeading2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100172", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected Rudder fetchRudder(Module_Unit.Unit unit)
	{
		if (!myUnit.IsShip)
		{
			if (myUnit.IsSubmarine)
			{
				return ((Submarine)myUnit).Rudder;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return null;
		}
		return ((Ship)myUnit).Rudder;
	}

	protected float adjustBoatHeadingChangeBasedOnRudderCurrentDeflection(float currentHeading, float desiredHeading, float elapsedTime)
	{
		Rudder rudder = fetchRudder(myUnit);
		float num = rudder.TurningSpeed();
		float maxRudderDeflection = rudder.MaxDeflection();
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.IsGroupLead())
		{
			Rudder rudder2 = rudder;
			bool flag = false;
			foreach (ActiveUnit item in myUnit.get_ParentGroup(UsingMissionPlanner: false).ToList())
			{
				if (item.IsBoat)
				{
					Rudder rudder3 = fetchRudder(item);
					if (rudder3.TurningSpeed() >= rudder2.TurningSpeed())
					{
						rudder2 = rudder3;
						flag = true;
					}
				}
			}
			if (flag)
			{
				num = rudder2.TurningSpeed() * 0.8f;
				maxRudderDeflection = rudder2.MaxDeflection() * 0.8f;
			}
		}
		float num2 = Math2.NormalizeBearing(desiredHeading - currentHeading);
		if (num2 > 180f)
		{
			num2 -= 360f;
		}
		float lastHeadingChangePerSecond = rudder.lastHeadingChangePerSecond;
		double num3 = Math.Sign(num2);
		double num4 = Math.Abs(num2);
		double num5 = num;
		double num6 = Math.Abs(lastHeadingChangePerSecond);
		double num7 = Math.Sqrt(num5 * num4 + (num6 * num6 + 0.0) / 2.0);
		double num8 = num7 * num3;
		if (num3 == (double)Math.Sign(num2) && num7 > (double)Math.Abs(num2))
		{
			num8 = num2;
		}
		if ((double)Math.Abs(lastHeadingChangePerSecond) < num7)
		{
			return rudder.adjustBoatHeadingChangeBasedOnRudderStatus((float)num8, num, maxRudderDeflection, elapsedTime);
		}
		return rudder.adjustBoatHeadingChangeBasedOnRudderStatus(0f, num, maxRudderDeflection, elapsedTime);
	}

	protected bool IsLeftOfDesired(float CurrentHeading, float DesiredHeading)
	{
		float num = DesiredHeading;
		float num2 = Math2.NormalizeBearing(CurrentHeading - num);
		num = 0f;
		if (num2 > 180f)
		{
			return true;
		}
		return false;
	}

	protected bool IsRightOfDesired(float CurrentHeading, float DesiredHeading)
	{
		float num = DesiredHeading;
		float num2 = Math2.NormalizeBearing(CurrentHeading - num);
		num = 0f;
		if (num2 <= 180f)
		{
			return true;
		}
		return false;
	}

	private void method_0()
	{
	}

	public virtual float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? theFuelStateDoctrine)
	{
		float result = default(float);
		try
		{
			float num = default(float);
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			AltBand altBand = myUnit.Propulsion[0].get_OptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise);
			result = (float)((double)(num / myUnit.FuelConsumption(ActiveUnit.Throttle.Cruise, altBand, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false)) * ((double)GetMaximumSpeed(altBand.MaxAlt, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) / 3600.0));
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100175", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float FuelNecessaryForThisDistance(float theDistance, ActiveUnit.Throttle theThrottle, float theAltitude, float? theSpeed, bool CombatRadiusCalc, bool ValidateThrottleSelection, bool FlightplanFuelEstimate)
	{
		float result;
		try
		{
			float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
			if (theAltitude > maximumAltitude)
			{
				theAltitude = maximumAltitude;
			}
			if (theDistance == 0f)
			{
				result = 0f;
			}
			else
			{
				float? num = theSpeed;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0f)) != true)
				{
					if (myUnit.Propulsion.Count == 0)
					{
						result = 0f;
					}
					else
					{
						float num2 = myUnit.FuelConsumption(theThrottle, null, theSpeed, theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
						result = (float)(long)Math.Round((theDistance / theSpeed * 3600f).Value) * num2;
					}
				}
				else
				{
					result = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100176", "");
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

	internal float FuelNecessaryForThisClimb(float theStartAltitude, float theEndAltitude, float theClimbRate, float theDiveRate, UnitThrottlePreset theThrottlePreset, float? theSpeed, bool CombatRadiusCalc, bool ValidateThrottleSelection, bool FlightplanFuelEstimate, ref float DistanceCovered, ref float TimeSpent)
	{
		float result;
		try
		{
			if (myUnit.Propulsion.Count != 0)
			{
				AltBand altBand = null;
				AltBand altBand2 = null;
				if (theEndAltitude > myUnit.Kinematics.GetMaximumAltitude())
				{
					theEndAltitude = myUnit.Kinematics.GetMaximumAltitude();
				}
				float num;
				float num2;
				float num3;
				if (theEndAltitude > theStartAltitude)
				{
					altBand = GetCurrentAltBand_CurrentAltitude(theStartAltitude, null, ValidateAndFixAltitude: false);
					altBand2 = GetCurrentAltBand_CurrentAltitude(theEndAltitude, null, ValidateAndFixAltitude: false);
					num = theClimbRate;
					num2 = theStartAltitude;
					num3 = theEndAltitude;
				}
				else
				{
					altBand = GetCurrentAltBand_CurrentAltitude(theEndAltitude, null, ValidateAndFixAltitude: false);
					altBand2 = GetCurrentAltBand_CurrentAltitude(theStartAltitude, null, ValidateAndFixAltitude: false);
					num = theDiveRate;
					num2 = theEndAltitude;
					num3 = theStartAltitude;
				}
				float num6 = default(float);
				if (altBand == altBand2)
				{
					float num4 = num3 - num2;
					ActiveUnit.Throttle throttle;
					ActiveUnit.Throttle throttle2;
					if (theThrottlePreset == UnitThrottlePreset.None && !Information.IsNothing((object)theSpeed))
					{
						throttle = GetThrottleSuitableForThisSpeed(num2, theSpeed.Value);
						throttle2 = GetThrottleSuitableForThisSpeed(num3, theSpeed.Value);
					}
					else
					{
						throttle = (ActiveUnit.Throttle)theThrottlePreset;
						throttle2 = throttle;
					}
					if (altBand == myUnit.Kinematics.HighestAltBand(myUnit.Propulsion[0]))
					{
						float num5 = myUnit.FuelConsumption(throttle, null, theSpeed, num2, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
						TimeSpent = num4 / num;
						num6 = TimeSpent * num5;
						float num7 = ((!Information.IsNothing((object)throttle)) ? ((float)myUnit.Kinematics.GetMaximumSpeed(num2, throttle, ValidateAndFixAltitude: false)) : theSpeed.Value);
						DistanceCovered = TimeSpent * num7 * 3600f;
					}
					else
					{
						float num8 = myUnit.FuelConsumption(throttle, null, theSpeed, num2, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
						float num9 = myUnit.FuelConsumption(throttle2, null, theSpeed, num3, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
						float num5 = (num8 + num9) / 2f;
						TimeSpent = num4 / num;
						num6 = TimeSpent * num5;
						float num10 = myUnit.Kinematics.GetMaximumSpeed(num2, throttle, ValidateAndFixAltitude: false);
						float num11 = myUnit.Kinematics.GetMaximumSpeed(num3, throttle2, ValidateAndFixAltitude: false);
						float num12 = (num10 + num11) / 2f;
						DistanceCovered = TimeSpent * num12 / 3600f;
					}
				}
				else
				{
					bool flag = false;
					ActiveUnit.Throttle throttle3 = default(ActiveUnit.Throttle);
					ActiveUnit.Throttle throttle4 = default(ActiveUnit.Throttle);
					if (theThrottlePreset != UnitThrottlePreset.None || Information.IsNothing((object)theSpeed))
					{
						throttle3 = (ActiveUnit.Throttle)theThrottlePreset;
						throttle4 = throttle3;
					}
					AltBand[] altBands = myUnit.Propulsion[0].AltBands;
					float num15 = default(float);
					float num17 = default(float);
					foreach (AltBand altBand3 in altBands)
					{
						if (altBand3 == altBand)
						{
							flag = true;
							float num13 = altBand3.MaxAlt - num2;
							if (num13 != 0f)
							{
								if (theThrottlePreset == UnitThrottlePreset.None && !Information.IsNothing((object)theSpeed))
								{
									throttle3 = GetThrottleSuitableForThisSpeed(num2, theSpeed.Value);
									throttle4 = GetThrottleSuitableForThisSpeed(altBand3.MaxAlt, theSpeed.Value);
								}
								float num14 = myUnit.FuelConsumption(throttle3, null, theSpeed, num2, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
								num15 = myUnit.FuelConsumption(throttle4, null, theSpeed, altBand3.MaxAlt, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
								float num5 = (num14 + num15) / 2f;
								TimeSpent = num13 / num;
								num6 = TimeSpent * num5;
								float num16 = myUnit.Kinematics.GetMaximumSpeed(num2, throttle3, ValidateAndFixAltitude: false);
								num17 = myUnit.Kinematics.GetMaximumSpeed(altBand3.MaxAlt, throttle4, ValidateAndFixAltitude: false);
								float num18 = (num16 + num17) / 2f;
								DistanceCovered = TimeSpent * num18 / 3600f;
							}
						}
						else if (altBand3 == altBand2)
						{
							float num19 = num3 - altBand3.MinAlt;
							if (num19 != 0f)
							{
								if (theThrottlePreset == UnitThrottlePreset.None && !Information.IsNothing((object)theSpeed))
								{
									throttle3 = throttle4;
									throttle4 = GetThrottleSuitableForThisSpeed(num3, theSpeed.Value);
								}
								float num20 = num15;
								num15 = myUnit.FuelConsumption(throttle3, null, theSpeed, num3, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
								float num5 = (num20 + num15) / 2f;
								float num21 = num19 / num;
								TimeSpent += num21;
								num6 += num21 * num5;
								float num22 = num17;
								num17 = myUnit.Kinematics.GetMaximumSpeed(num3, throttle3, ValidateAndFixAltitude: false);
								float num23 = (num22 + num17) / 2f;
								DistanceCovered += num21 * num23 / 3600f;
								break;
							}
						}
						else
						{
							if (!flag)
							{
								continue;
							}
							float num24 = altBand3.MaxAlt - altBand3.MinAlt;
							if (num24 != 0f)
							{
								if (theThrottlePreset == UnitThrottlePreset.None && !Information.IsNothing((object)theSpeed))
								{
									throttle3 = throttle4;
									throttle4 = GetThrottleSuitableForThisSpeed(altBand3.MaxAlt, theSpeed.Value);
								}
								float num25 = num15;
								num15 = myUnit.FuelConsumption(throttle3, null, theSpeed, altBand3.MaxAlt, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection, FlightplanFuelEstimate);
								float num5 = (num25 + num15) / 2f;
								float num21 = num24 / num;
								TimeSpent += num21;
								num6 += num21 * num5;
								float num26 = num17;
								num17 = myUnit.Kinematics.GetMaximumSpeed(altBand3.MaxAlt, throttle3, ValidateAndFixAltitude: false);
								float num27 = (num26 + num17) / 2f;
								DistanceCovered += num21 * num27 / 3600f;
							}
						}
					}
				}
				result = num6;
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
			ex2?.Data.Add("Error at 100176", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DistanceCovered = 0f;
			TimeSpent = 0f;
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float FuelNecessaryToReachWaypoint(float speed, UnitThrottlePreset throttlePreset, Waypoint targetWaypoint)
	{
		float num = 0f;
		float DistanceCovered = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		float? desiredAltitude = targetWaypoint.DesiredAltitude;
		if ((desiredAltitude.HasValue ? new bool?(num4 != desiredAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
		{
			float theClimbRate;
			float theDiveRate;
			if (!Information.IsNothing((object)myUnit))
			{
				theClimbRate = (float)((double)myUnit.Kinematics.ClimbRate_Max() * 0.4);
				theDiveRate = myUnit.Kinematics.DiveRate_Max();
			}
			else
			{
				theClimbRate = 0f;
				theDiveRate = 0f;
			}
			float TimeSpent = 0f;
			num = myUnit.Kinematics.FuelNecessaryForThisClimb(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), targetWaypoint.Altitude, theClimbRate, theDiveRate, throttlePreset, speed, CombatRadiusCalc: false, ValidateThrottleSelection: true, FlightplanFuelEstimate: true, ref DistanceCovered, ref TimeSpent);
		}
		float num5 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), targetWaypoint.Latitude, targetWaypoint.Longitude);
		if (!(DistanceCovered > num5))
		{
			num3 = num5 - DistanceCovered;
			num2 = myUnit.Kinematics.FuelNecessaryForThisDistance(num3, (ActiveUnit.Throttle)throttlePreset, targetWaypoint.Altitude, speed, CombatRadiusCalc: false, ValidateThrottleSelection: true, FlightplanFuelEstimate: false);
		}
		return num + num2;
	}

	internal float FuelNecessaryForThisTime(int theSeconds, ActiveUnit.Throttle theThrottle, float theAltitude, float? theSpeed, bool CombatRadiusCalc)
	{
		float result;
		try
		{
			if (theSeconds != 0)
			{
				if (myUnit.Propulsion.Count == 0)
				{
					result = 0f;
				}
				else
				{
					float num = myUnit.FuelConsumption(theThrottle, null, theSpeed, theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCalc, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
					result = (float)theSeconds * num;
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
			ex2?.Data.Add("Error at 101248", "");
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

	public int CavitationSpeed(float theDepth)
	{
		if (theDepth < -500f)
		{
			return int.MaxValue;
		}
		float num = default(float);
		switch (myUnit.NoiseLevelClass)
		{
		case GlobalVariables.UnitNoiseLevelClass.Loud:
			if (theDepth > -200f)
			{
				num = 8f;
			}
			else if (theDepth > -300f)
			{
				num = 13f;
			}
			else
			{
				if (!(theDepth > -400f))
				{
					return int.MaxValue;
				}
				num = 25f;
			}
			goto default;
		case GlobalVariables.UnitNoiseLevelClass.Noisy:
			if (theDepth > -100f)
			{
				num = 8f;
			}
			else if (theDepth > -200f)
			{
				num = 13f;
			}
			else
			{
				if (!(theDepth > -300f))
				{
					return int.MaxValue;
				}
				num = 25f;
			}
			goto default;
		case GlobalVariables.UnitNoiseLevelClass.Quiet:
			if (theDepth > -50f)
			{
				num = 8f;
			}
			else if (theDepth > -100f)
			{
				num = 13f;
			}
			else
			{
				if (!(theDepth > -200f))
				{
					return int.MaxValue;
				}
				num = 25f;
			}
			goto default;
		case GlobalVariables.UnitNoiseLevelClass.VQuiet:
			if (theDepth > -50f)
			{
				num = 13f;
			}
			else
			{
				if (!(theDepth > -100f))
				{
					return int.MaxValue;
				}
				num = 25f;
			}
			goto default;
		case GlobalVariables.UnitNoiseLevelClass.ExQuiet:
			if (theDepth > -50f)
			{
				num = 25f;
				goto default;
			}
			return int.MaxValue;
		default:
			if (myUnit.IsSubmarine && ((Submarine)myUnit).Flags.ShroudedPropulsor)
			{
				num = (float)((double)num * 1.1);
			}
			return (int)Math.Round(num);
		}
	}

	public void ResetCachedMaxMinAlt()
	{
		float_0 = -99999f;
	}

	public virtual float GetMaximumAltitude()
	{
		float result;
		try
		{
			if (float_0 > -99999f)
			{
				result = float_0;
			}
			else
			{
				float num = 0f;
				foreach (Engine item in myUnit.Propulsion)
				{
					AltBand[] altBands = item.AltBands;
					int num2 = altBands.Length - 1;
					for (int i = 0; i <= num2; i++)
					{
						AltBand altBand = altBands[i];
						if (altBand.MaxAlt > num)
						{
							num = altBand.MaxAlt;
						}
					}
				}
				float_0 = num;
				result = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100177", "");
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

	public virtual float GetMinimumAltitude()
	{
		float result;
		try
		{
			if (nullable_0.HasValue)
			{
				result = nullable_0.Value;
			}
			else
			{
				float num = 9999999f;
				foreach (Engine item in myUnit.Propulsion)
				{
					if (item.AltBands.Length != 0)
					{
						AltBand[] altBands = item.AltBands;
						int num2 = altBands.Length - 1;
						for (int i = 0; i <= num2; i++)
						{
							AltBand altBand = altBands[i];
							if (altBand.MinAlt <= num)
							{
								num = altBand.MinAlt;
							}
						}
						continue;
					}
					result = 0f;
					goto end_IL_0001;
				}
				nullable_0 = num;
				result = num;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100178", "");
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

	public virtual float GetMinimumSpeed_Total(float Altitude, bool ValidateAndFixAltitude)
	{
		float result = default(float);
		try
		{
			if (!myUnit.IsFacility && !myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsMobileGroundUnit)
			{
				if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
				{
					result = 0f;
					return result;
				}
				if (myUnit.Propulsion.Count != 0)
				{
					if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
					{
						result = 0f;
						return result;
					}
					if (myUnit.Propulsion[0].AltBands.Length != 0)
					{
						AltBand altBand = GetCurrentAltBand(Altitude, ValidateAndFixAltitude);
						if (Information.IsNothing((object)altBand))
						{
							if (!myUnit.IsAircraft)
							{
								altBand = myUnit.Propulsion[0].AltBands.OrderBy([SpecialName] (AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
								if (ValidateAndFixAltitude)
								{
									myUnit.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, altBand.MinAlt);
								}
							}
							else
							{
								altBand = myUnit.Propulsion[0].AltBands.OrderByDescending([SpecialName] (AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
								if (ValidateAndFixAltitude)
								{
									myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, altBand.MaxAlt);
								}
							}
						}
						result = altBand.Speed_Loiter;
						return result;
					}
					result = 0f;
					return result;
				}
				result = 0f;
				return result;
			}
			result = 0f;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100179", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual int GetMinimumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude)
	{
		int result;
		try
		{
			AltBand altBand = null;
			AltBand altBand2 = null;
			if (myUnit.IsFacility)
			{
				goto IL_03a4;
			}
			int num;
			if (myUnit.IsShip)
			{
				num = 0;
				goto IL_03a5;
			}
			if (myUnit.IsSubmarine)
			{
				goto IL_03a4;
			}
			if (myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter)
			{
				result = 0;
			}
			else if (ThrottleSetting != ActiveUnit.Throttle.FullStop)
			{
				ActiveUnit.Throttle throttle = ThrottleSetting - 1;
				if (myUnit.IsAircraft && throttle == ActiveUnit.Throttle.FullStop)
				{
					throttle = ActiveUnit.Throttle.Loiter;
				}
				if (myUnit.Propulsion.Count == 0)
				{
					result = 0;
				}
				else if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					result = 0;
				}
				else if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					result = 0;
				}
				else
				{
					AltBand[] altBands = myUnit.Propulsion[0].AltBands;
					if (altBands.Length != 0)
					{
						altBand = GetCurrentAltBand(Altitude, ValidateAndFixAltitude);
						if (Information.IsNothing((object)altBand))
						{
							result = 0;
						}
						else
						{
							float num2 = default(float);
							switch (throttle)
							{
							case ActiveUnit.Throttle.FullStop:
								num2 = 0f;
								break;
							case ActiveUnit.Throttle.Loiter:
								num2 = altBand.Speed_Loiter;
								break;
							case ActiveUnit.Throttle.Cruise:
								num2 = ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise));
								break;
							case ActiveUnit.Throttle.Full:
								num2 = ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value));
								break;
							case ActiveUnit.Throttle.Flank:
								num2 = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value)));
								break;
							}
							int num3 = (int)Math.Round(num2);
							if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && altBand != HighestAltBand(myUnit.Propulsion[0]))
							{
								List<AltBand> list = new List<AltBand>();
								AltBand[] array = altBands;
								foreach (AltBand altBand3 in array)
								{
									if (altBand3.MinAlt >= altBand.MaxAlt)
									{
										list.Add(altBand3);
									}
								}
								if (list.Count > 1)
								{
									list.Sort(new AltBandComparer_SortyByMaxAltAscending());
								}
								if (list.Count > 0)
								{
									altBand2 = list[0];
								}
								float num4 = default(float);
								switch (throttle)
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
									num4 = ((!altBand2.Speed_Flank.HasValue) ? (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise)) : ((float)altBand2.Speed_Flank.Value));
									break;
								}
								num3 = (int)Math.Round(num4 + (Altitude - altBand2.MinAlt) * (num2 - num4) / (altBand.MinAlt - altBand2.MinAlt));
							}
							if (!myUnit.IsAircraft)
							{
								result = num3 + 1;
							}
							else
							{
								num3 = (int)Math.Round(RoundAircraftSpeed(num3));
								result = num3;
							}
						}
					}
					else
					{
						result = 0;
					}
				}
			}
			else
			{
				result = 0;
			}
			goto end_IL_0001;
			IL_03a4:
			num = 0;
			goto IL_03a5;
			IL_03a5:
			result = num;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100180", "");
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

	public bool CanApplyLoiterThrottle()
	{
		AltBand currentAltBand = GetCurrentAltBand(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: true);
		if (!Information.IsNothing((object)currentAltBand))
		{
			if (currentAltBand.Consumption_Loiter > 0f && currentAltBand.Speed_Loiter > 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public bool CanApplyFullThrottle()
	{
		bool result = default(bool);
		try
		{
			AltBand currentAltBand = GetCurrentAltBand(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false);
			if (Information.IsNothing((object)currentAltBand))
			{
				result = false;
				return result;
			}
			int num;
			if (!currentAltBand.Consumption_Full.HasValue)
			{
				num = 0;
			}
			else
			{
				if (currentAltBand.Speed_Full.HasValue)
				{
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
			ex2?.Data.Add("Error at 100181", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual bool CanApplyFlankThrottle()
	{
		bool result = default(bool);
		try
		{
			AltBand currentAltBand = GetCurrentAltBand(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false);
			if (Information.IsNothing((object)currentAltBand))
			{
				result = false;
				return result;
			}
			int num;
			if (currentAltBand.Consumption_Flank.HasValue)
			{
				if (currentAltBand.Speed_Flank.HasValue)
				{
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100182", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public AltBand LowestAltBand()
	{
		AltBand result = default(AltBand);
		try
		{
			if (myUnit.Propulsion.Count != 0)
			{
				if (myUnit.Propulsion[0].AltBands.Length == 0)
				{
					result = null;
					return result;
				}
				if (Information.IsNothing((object)altBand_0))
				{
					altBand_0 = myUnit.Propulsion[0].AltBands.OrderBy([SpecialName] (AltBand theBand) => theBand.MinAlt).ElementAtOrDefault(0);
				}
				result = altBand_0;
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100183", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual long RemainingEndurance(bool TotalRemainingEndurance = false)
	{
		long result = default(long);
		try
		{
			float num = default(float);
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			if (!TotalRemainingEndurance)
			{
				num -= myUnit.Kinematics.ReserveFuel;
			}
			float num2 = myUnit.FuelConsumption(myUnit.ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			if (num2 == 0f)
			{
				result = long.MaxValue;
				return result;
			}
			result = (long)Math.Round(num / num2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100184", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual long RemainingEndurance(float theSpeed, float theAltitude, bool TotalRemainingEndurance, bool BingoFuelEndurance)
	{
		long result;
		try
		{
			if (theSpeed == 0f)
			{
				result = long.MaxValue;
			}
			else
			{
				float num = default(float);
				if (BingoFuelEndurance && myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
				{
					num = ((Aircraft)myUnit).FuelState_RemainingFuelToBingo;
				}
				else
				{
					PooledList<FuelRec> fuel_ReadOnly = myUnit.Fuel_ReadOnly;
					foreach (FuelRec item in fuel_ReadOnly)
					{
						num += item.CurrentQuantity;
					}
					if (myUnit.IsAircraft)
					{
						fuel_ReadOnly.Dispose();
					}
					if (!TotalRemainingEndurance)
					{
						num -= myUnit.Kinematics.ReserveFuel;
					}
				}
				if (!float.IsNaN(num))
				{
					float num2 = myUnit.FuelConsumption(GetThrottleSuitableForThisSpeed(theAltitude, (int)Math.Round(theSpeed)), null, (int)Math.Round(theSpeed), theAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
					result = ((num2 != 0f) ? ((long)Math.Round(num / num2)) : long.MaxValue);
				}
				else
				{
					result = 0L;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100185", "");
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
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual long RemainingEndurance(ActiveUnit.Throttle theThrottleSetting, float theAltitude, bool TotalRemainingEndurance)
	{
		long result = default(long);
		try
		{
			float num = default(float);
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			if (!TotalRemainingEndurance)
			{
				num -= myUnit.Kinematics.ReserveFuel;
			}
			result = (long)Math.Round(num / myUnit.FuelConsumption(theThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
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

	public virtual int GetMaximumSpeed()
	{
		int result;
		try
		{
			if (_MaxSpeedTotal.HasValue)
			{
				goto IL_00bd;
			}
			if (myUnit.Propulsion.Count != 0)
			{
				HashSet<int> hashSet = new HashSet<int>();
				foreach (Engine item in myUnit.Propulsion)
				{
					AltBand[] altBands = item.AltBands;
					foreach (AltBand altBand in altBands)
					{
						hashSet.Add(altBand.MaxSpeed.Value);
					}
				}
				if (hashSet.Count == 0)
				{
					_MaxSpeedTotal = 0;
				}
				else
				{
					_MaxSpeedTotal = hashSet.Max();
				}
				goto IL_00bd;
			}
			result = 0;
			goto end_IL_0001;
			IL_00bd:
			result = _MaxSpeedTotal.Value;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100186", "");
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

	public virtual int GetMaximumSpeed_Total()
	{
		int result;
		try
		{
			if (_MaxSpeedTotal.HasValue)
			{
				goto IL_00bf;
			}
			if (myUnit.Propulsion.Count != 0)
			{
				HashSet<int> hashSet = new HashSet<int>();
				foreach (Engine item in myUnit.Propulsion)
				{
					AltBand[] altBands = item.AltBands;
					foreach (AltBand altBand in altBands)
					{
						hashSet.Add(altBand.MaxSpeed.Value);
					}
				}
				if (hashSet.Count != 0)
				{
					_MaxSpeedTotal = hashSet.Max();
				}
				else
				{
					_MaxSpeedTotal = 0;
				}
				goto IL_00bf;
			}
			result = 0;
			goto end_IL_0001;
			IL_00bf:
			result = _MaxSpeedTotal.Value;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100186", "");
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

	public int GetMaximumSpeed(float Altitude)
	{
		int result;
		if (!myUnit.IsWeapon)
		{
			if (myUnit.IsGroup)
			{
				result = ((((Group)myUnit).GroupLead != null) ? ((Group)myUnit).GroupLead.Kinematics.GetMaximumSpeed(Altitude) : 0);
			}
			else if (!myUnit.IsFacility)
			{
				if (!myUnit.IsVehicle)
				{
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
							AltBand[] altBands = propulsion[0].AltBands;
							if (propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
							{
								result = 0;
							}
							else if (altBands.Length == 0)
							{
								result = 0;
							}
							else
							{
								AltBand altBand2 = (myUnit.IsWeapon ? GetCurrentAltBand_CurrentAltitude(Altitude, propulsion[0], ValidateAndFixAltitude: false) : GetCurrentAltBand_CurrentAltitude(Altitude, null, ValidateAndFixAltitude: false));
								if (altBand2 != null)
								{
									int value = altBand2.MaxSpeed.Value;
									int num = value;
									if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && altBand2 != HighestAltBand(propulsion[0]))
									{
										if (AltBandListCache.TryDequeue(out result2))
										{
											result2.Clear();
										}
										else
										{
											result2 = new List<AltBand>();
										}
										AltBand[] array = altBands;
										foreach (AltBand altBand3 in array)
										{
											if (altBand3.MinAlt >= altBand2.MaxAlt && altBand3 != null)
											{
												result2.Add(altBand3);
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
											catch (Exception projectError)
											{
												ProjectData.SetProjectError(projectError);
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
										if (altBand != null)
										{
											num2 = altBand.MaxSpeed.Value;
										}
										else if (result2.Count > 0)
										{
											altBand = result2[0];
											num2 = altBand.MaxSpeed.Value;
										}
										try
										{
											num2 = (altBand.MaxSpeed?.Value).Value;
										}
										catch (Exception projectError2)
										{
											ProjectData.SetProjectError(projectError2);
											if (result2.Count > 0)
											{
												altBand = result2[0];
												num2 = (altBand.MaxSpeed?.Value).Value;
											}
											ProjectData.ClearProjectError();
										}
										float num3 = altBand2.MinAlt - altBand.MinAlt;
										if (num3 == 0f)
										{
											num3 = 1f;
										}
										num = (int)Math.Round(num2 + (Altitude - altBand.MinAlt) * ((float)value - num2) / num3);
									}
									if (myUnit.IsAircraft)
									{
										num = (int)Math.Round(RoundAircraftSpeed(num));
									}
									if (result2 != null)
									{
										result2.Clear();
										AltBandListCache.Enqueue(result2);
									}
									result = num;
								}
								else
								{
									result = 0;
								}
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
						int num4;
						if (result2 == null)
						{
							num4 = 0;
						}
						else
						{
							result2.Clear();
							AltBandListCache.Enqueue(result2);
							num4 = 0;
						}
						result = num4;
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					result = GetMaximumSpeed_Total();
				}
			}
			else
			{
				result = GetMaximumSpeed_Total();
			}
		}
		else
		{
			result = ((Weapon)myUnit).Kinematics.GetMaximumSpeedForThisAltitude(Altitude);
		}
		return result;
	}

	public AltBand GetCurrentAltBand_CurrentAltitude(float Altitude, Engine theEngine, bool ValidateAndFixAltitude)
	{
		AltBand result;
		if (!myUnit.IsVehicle)
		{
			AltBand altBand = null;
			if (_MyPropulsion == null)
			{
				_MyPropulsion = myUnit.Propulsion;
			}
			try
			{
				if (!myUnit.IsTorpedo)
				{
					if (myUnit.IsShip)
					{
						result = ((_MyPropulsion[0].AltBands.Length != 0) ? _MyPropulsion[0].AltBands[0] : null);
					}
					else
					{
						if (myUnit.IsSubmarine && theEngine == null && _MyPropulsion.Count > 1 && Altitude == myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							Submarine submarine = (Submarine)myUnit;
							if (submarine.PrimaryEngine == null)
							{
								submarine.AI.SelectEngines();
							}
							if (submarine.PrimaryEngine != null)
							{
								theEngine = submarine.PrimaryEngine;
							}
						}
						AltBand[] altBands = default(AltBand[]);
						if (theEngine == null)
						{
							int num = _MyPropulsion.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								altBands = _MyPropulsion[i].AltBands;
								int num2 = altBands.Length;
								for (int j = num2 - 1; j >= 0; j += -1)
								{
									AltBand altBand2 = altBands[j];
									if (num2 >= 2 && ((j >= 1 && altBands[j].MinAlt - altBands[j - 1].MaxAlt != 0f) || (j == 0 && altBands[j].MaxAlt - altBands[j + 1].MinAlt != 0f)))
									{
										if (altBand2.MaxAlt >= Altitude && Altitude + 1f >= altBand2.MinAlt)
										{
											altBand = altBand2;
											break;
										}
									}
									else if (altBand2.MaxAlt >= Altitude && !(Altitude < altBand2.MinAlt))
									{
										altBand = altBand2;
										break;
									}
								}
								if (altBand != null)
								{
									break;
								}
							}
						}
						else
						{
							altBands = theEngine.AltBands;
							int num3 = altBands.Length;
							for (int k = num3 - 1; k >= 0; k += -1)
							{
								AltBand altBand2 = altBands[k];
								if (num3 >= 2 && ((k >= 1 && altBands[k].MinAlt - altBands[k - 1].MaxAlt != 0f) || (k == 0 && altBands[k].MaxAlt - altBands[k + 1].MinAlt != 0f)))
								{
									if (altBand2.MaxAlt >= Altitude && Altitude + 1f >= altBand2.MinAlt)
									{
										altBand = altBand2;
										break;
									}
								}
								else if (altBand2.MaxAlt >= Altitude && !(Altitude < altBand2.MinAlt))
								{
									altBand = altBand2;
									break;
								}
							}
						}
						if (altBand != null)
						{
							goto IL_031f;
						}
						if (!bool_2)
						{
							bool_1 = myUnit.IsGuidedWeapon();
							bool_2 = true;
						}
						if (myUnit.IsAircraft || bool_1)
						{
							float num4 = float.MaxValue;
							AltBand[] array = altBands;
							foreach (AltBand altBand2 in array)
							{
								if (Altitude - altBand2.MaxAlt < num4)
								{
									altBand = altBand2;
									num4 = Altitude - altBand2.MaxAlt;
								}
							}
							if (ValidateAndFixAltitude)
							{
								myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, altBand.MaxAlt);
							}
							goto IL_031f;
						}
						if (altBands != null && altBands.Length != 0)
						{
							altBand = altBands.OrderBy([SpecialName] (AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
							if (ValidateAndFixAltitude)
							{
								myUnit.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, altBand.MinAlt);
							}
							goto IL_031f;
						}
						result = null;
					}
				}
				else
				{
					result = _MyPropulsion[0].AltBands[0];
				}
				goto end_IL_002e;
				IL_031f:
				result = altBand;
				end_IL_002e:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100188", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = ((Vehicle)myUnit).Kinematics.GetCurrentAltBand_CurrentAltitude_Vehicle(theEngine);
		}
		return result;
	}

	public virtual int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		if (float.IsNaN(Altitude))
		{
			return 0;
		}
		AltBand altBand = null;
		Engine engine = null;
		int result = default(int);
		try
		{
			if (ThrottleSetting == ActiveUnit.Throttle.FullStop)
			{
				result = 0;
				return result;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				if (myUnit.IsFixedFacility)
				{
					result = 0;
					return result;
				}
				switch (ThrottleSetting)
				{
				case ActiveUnit.Throttle.Loiter:
					result = 3;
					return result;
				case ActiveUnit.Throttle.Cruise:
					result = 10;
					return result;
				case ActiveUnit.Throttle.Full:
					result = 20;
					return result;
				case ActiveUnit.Throttle.Flank:
					result = 30;
					return result;
				case ActiveUnit.Throttle.External:
					result = (DesiredSpeedOverride.HasValue ? ((int)Math.Round(DesiredSpeedOverride.Value)) : 0);
					return result;
				case ActiveUnit.Throttle.MaxPossibleThrottle:
					result = 30;
					return result;
				case ActiveUnit.Throttle.MinPossibleThrottle:
					result = 0;
					return result;
				}
			}
			altBand = GetCurrentAltBand_CurrentAltitude(Altitude, null, ValidateAndFixAltitude);
			if (altBand == null)
			{
				result = 0;
				return result;
			}
			engine = (myUnit.IsSubmarine ? method_1(altBand) : myUnit.Propulsion[0]);
			AltBand[] altBands = engine.AltBands;
			if (ConsiderDamage && engine.Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				result = 0;
				return result;
			}
			if (altBands.Length == 0)
			{
				result = 0;
				return result;
			}
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
			int num2 = (int)Math.Round(num);
			if (ConsiderDamage)
			{
				float val = Math.Max((float)num2 * (100f - myUnit.Damage.DamagePercent) / 100f, 0f);
				float val2 = default(float);
				switch (engine.Status)
				{
				case PlatformComponent._ComponentStatus.Operational:
					val2 = num2;
					break;
				case PlatformComponent._ComponentStatus.Damaged:
					val2 = (float)((double)num2 / 2.0);
					break;
				case PlatformComponent._ComponentStatus.Destroyed:
					val2 = 0f;
					break;
				}
				num2 = (int)Math.Round(Math.Min(val, val2));
				if (IsOvercraft() && Module_Unit.IsOverLand(myUnit))
				{
					float maxSlope = Terrain.GetMaxSlope(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen);
					num2 = ((!((double)maxSlope > 0.5)) ? ((int)Math.Round(Math.Max((double)num2 / 10.0, (float)num2 * (1f - maxSlope)))) : ((int)Math.Round(Math.Max(1.0, (double)num2 / 10.0))));
					LandCover.LandCoverType landCoverAtThisPoint = LandCover.GetLandCoverAtThisPoint(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen);
					if (landCoverAtThisPoint - 1 <= LandCover.LandCoverType.Deciduous_Broadleaf_forest)
					{
						num2 = (int)Math.Round((float)num2 * 0.01f);
						num2 = Math.Max(num2, 1);
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
			ex2?.Data.Add("Error at 100189", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsOvercraft()
	{
		if (!myUnit.IsShip)
		{
			return false;
		}
		return ((Ship)myUnit).Type == Ship._ShipType.LCAC;
	}

	public static float RoundAircraftSpeed(float OriginalSpeed)
	{
		if (OriginalSpeed <= 415f)
		{
			return (float)(Math.Round(OriginalSpeed / 5f) * 5.0);
		}
		return (float)(Math.Round(OriginalSpeed / 10f) * 10.0);
	}

	public void updateCachedHighestAltBand(AltBand oldRef, AltBand newRef)
	{
		if (altBand_1 == oldRef)
		{
			altBand_1 = newRef;
		}
	}

	public AltBand HighestAltBand(Engine theEngine)
	{
		AltBand result;
		try
		{
			if (theEngine != null)
			{
				if (theEngine.HighestAltBand != null)
				{
					result = theEngine.HighestAltBand;
				}
				else if (theEngine.AltBands.Length != 0)
				{
					if (myUnit.IsWeapon && theEngine != myUnit.Propulsion[0])
					{
						AltBand altBand = null;
						float num = float.MinValue;
						AltBand[] altBands = theEngine.AltBands;
						foreach (AltBand altBand2 in altBands)
						{
							if (altBand2.MinAlt > num)
							{
								altBand = altBand2;
								num = altBand2.MinAlt;
							}
						}
						theEngine.HighestAltBand = altBand;
						result = altBand;
					}
					else
					{
						if (altBand_1 == null || string.CompareOrdinal(string_0, theEngine.ObjectID) != 0)
						{
							AltBand altBand3 = null;
							float num2 = float.MinValue;
							AltBand[] altBands2 = theEngine.AltBands;
							foreach (AltBand altBand4 in altBands2)
							{
								if (altBand4.MinAlt > num2)
								{
									altBand3 = altBand4;
									num2 = altBand4.MinAlt;
								}
							}
							altBand_1 = altBand3;
							string_0 = theEngine.ObjectID;
						}
						theEngine.HighestAltBand = altBand_1;
						result = altBand_1;
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
			ex2?.Data.Add("Error at 100190", "");
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

	private Engine method_1(AltBand altBand_2)
	{
		Engine result;
		try
		{
			foreach (Engine item in myUnit.Propulsion)
			{
				if (!item.AltBands.Contains(altBand_2))
				{
					continue;
				}
				result = item;
				goto end_IL_0001;
			}
			result = null;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100191", "");
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

	public void AdjustSpeedForCavitation()
	{
		try
		{
			int num = myUnit.Kinematics.CavitationSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			if (myUnit.DesiredSpeed >= (float)num)
			{
				if (num == 1)
				{
					myUnit.DesiredSpeed = 1f;
				}
				else
				{
					myUnit.DesiredSpeed = num - 1;
				}
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				myUnit.Kinematics.HasAdjustedSpeedForCavitation = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100192", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float Altitude, float theSpeed)
	{
		ActiveUnit.Throttle result;
		try
		{
			if (myUnit.Propulsion.Count != 0)
			{
				AltBand currentAltBand = GetCurrentAltBand(Altitude, ValidateAndFixAltitude: false);
				if (currentAltBand != null)
				{
					AltBand[] altBands = myUnit.Propulsion[0].AltBands;
					AltBand altBand = null;
					int num = currentAltBand.Speed_Loiter;
					int num2 = currentAltBand.Speed_Cruise;
					int num3 = default(int);
					if (currentAltBand.Consumption_Full.HasValue)
					{
						num3 = currentAltBand.Speed_Full.Value;
					}
					if (currentAltBand.Consumption_Flank.HasValue)
					{
						int value = currentAltBand.Speed_Flank.Value;
					}
					if (!myUnit.IsShip && !myUnit.IsSubmarine && !myUnit.IsFacility && currentAltBand != HighestAltBand(myUnit.Propulsion[0]))
					{
						List<AltBand> list = new List<AltBand>();
						AltBand[] array = altBands;
						foreach (AltBand altBand2 in array)
						{
							if (altBand2.MinAlt >= currentAltBand.MaxAlt)
							{
								list.Add(altBand2);
							}
						}
						if (list.Count > 1)
						{
							list.Sort(new AltBandComparer_SortyByMaxAltAscending());
						}
						altBand = ((list.Count <= 0) ? currentAltBand : list[0]);
						if (currentAltBand.Speed_Loiter != altBand.Speed_Loiter)
						{
							num = (int)Math.Round((float)altBand.Speed_Loiter + (Altitude - altBand.MinAlt) * (float)(currentAltBand.Speed_Loiter - altBand.Speed_Loiter) / (currentAltBand.MinAlt - altBand.MinAlt));
							if (myUnit.IsAircraft)
							{
								num = (int)Math.Round(RoundAircraftSpeed(num));
							}
						}
						if (currentAltBand.Speed_Cruise != altBand.Speed_Cruise)
						{
							num2 = (int)Math.Round((float)altBand.Speed_Cruise + (Altitude - altBand.MinAlt) * (float)(currentAltBand.Speed_Cruise - altBand.Speed_Cruise) / (currentAltBand.MinAlt - altBand.MinAlt));
							if (myUnit.IsAircraft)
							{
								num2 = (int)Math.Round(RoundAircraftSpeed(num2));
							}
						}
						if (currentAltBand.Consumption_Full.HasValue)
						{
							int? speed_Full = currentAltBand.Speed_Full;
							int? speed_Full2 = altBand.Speed_Full;
							if (((!(speed_Full.HasValue & speed_Full2.HasValue)) ? ((bool?)null) : new bool?(speed_Full.GetValueOrDefault() != speed_Full2.GetValueOrDefault())) == true)
							{
								num3 = (int)Math.Round(((float?)altBand.Speed_Full + (Altitude - altBand.MinAlt) * (float?)(currentAltBand.Speed_Full - altBand.Speed_Full) / (currentAltBand.MinAlt - altBand.MinAlt)).Value);
								if (myUnit.IsAircraft)
								{
									num3 = (int)Math.Round(RoundAircraftSpeed(num3));
								}
							}
						}
						if (currentAltBand.Consumption_Full.HasValue)
						{
							int? speed_Full2 = currentAltBand.Speed_Flank;
							int? speed_Flank = altBand.Speed_Flank;
							if (((!(speed_Full2.HasValue & speed_Flank.HasValue)) ? ((bool?)null) : new bool?(speed_Full2.GetValueOrDefault() != speed_Flank.GetValueOrDefault())) == true)
							{
								int value = (int)Math.Round(((float?)altBand.Speed_Flank + (Altitude - altBand.MinAlt) * (float?)(currentAltBand.Speed_Flank - altBand.Speed_Flank) / (currentAltBand.MinAlt - altBand.MinAlt)).Value);
								if (myUnit.IsAircraft)
								{
									value = (int)Math.Round(RoundAircraftSpeed(value));
								}
							}
						}
					}
					result = ((theSpeed != 0f) ? ((theSpeed <= (float)num) ? ActiveUnit.Throttle.Loiter : ((theSpeed <= (float)num2) ? ActiveUnit.Throttle.Cruise : ((theSpeed <= (float)num3) ? ((!currentAltBand.Consumption_Full.HasValue) ? ActiveUnit.Throttle.Cruise : ActiveUnit.Throttle.Full) : ((!currentAltBand.Consumption_Flank.HasValue) ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Flank)))) : ActiveUnit.Throttle.FullStop);
				}
				else
				{
					result = ActiveUnit.Throttle.FullStop;
				}
			}
			else
			{
				result = ActiveUnit.Throttle.FullStop;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100193", "");
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
			result = (ActiveUnit.Throttle)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual AltBand GetCurrentAltBand(float Altitude, bool ValidateAndFixAltitude)
	{
		AltBand result;
		try
		{
			if (myUnit.Propulsion.Count < 1)
			{
				result = null;
			}
			else
			{
				AltBand altBand = null;
				if (!myUnit.IsTorpedo)
				{
					if (myUnit.IsShip)
					{
						result = ((myUnit.Propulsion[0].AltBands.Length != 0) ? myUnit.Propulsion[0].AltBands[0] : null);
					}
					else
					{
						AltBand[] altBands = myUnit.Propulsion[0].AltBands;
						int num = altBands.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							AltBand altBand2 = altBands[i];
							if (altBand2.MaxAlt >= Altitude && (Altitude + 1f > altBand2.MinAlt || Altitude + 1f == altBand2.MinAlt))
							{
								altBand = altBand2;
							}
						}
						if (!myUnit.IsBallisticMissile && Module_Unit.IsWithinAtmosphere(myUnit) && altBand == null)
						{
							if (myUnit.IsAircraft)
							{
								altBand = altBands.OrderByDescending([SpecialName] (AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
								if (ValidateAndFixAltitude)
								{
									myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, altBand.MaxAlt);
								}
							}
							else
							{
								altBand = altBands.OrderBy([SpecialName] (AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
								if (ValidateAndFixAltitude)
								{
									myUnit.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, altBand.MinAlt);
								}
							}
						}
						if (altBand == null && myUnit.IsAerospaceUnit)
						{
							altBand = altBands.OrderByDescending([SpecialName] (AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
						}
						result = altBand;
					}
				}
				else
				{
					result = myUnit.Propulsion[0].AltBands[0];
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100194", "");
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

	public void AdjustAttitude_Pitch(float elapsedTime)
	{
		float attitude_Pitch = myUnit.Attitude_Pitch;
		float desiredPitch = myUnit.DesiredPitch;
		float num = ((desiredPitch == attitude_Pitch) ? attitude_Pitch : ((desiredPitch > attitude_Pitch) ? ((!(Math.Abs(desiredPitch - attitude_Pitch) > PitchRate_Positive() * elapsedTime)) ? desiredPitch : (attitude_Pitch + PitchRate_Positive() * elapsedTime)) : ((!(Math.Abs(attitude_Pitch - desiredPitch) > PitchRate_Negative() * elapsedTime)) ? desiredPitch : (attitude_Pitch - PitchRate_Negative() * elapsedTime))));
		if (num > 90f)
		{
			_ = Debugger.IsAttached;
			num %= 90f;
			myUnit.CurrentHeading = Math2.NormalizeBearing(myUnit.CurrentHeading + 180f);
			myUnit.Attitude_Roll = Math2.NormalizeRoll(myUnit.Attitude_Roll + 180f);
		}
		if (num < -90f)
		{
			_ = Debugger.IsAttached;
			num %= 90f;
			myUnit.CurrentHeading = Math2.NormalizeBearing(myUnit.CurrentHeading + 180f);
			myUnit.Attitude_Roll = Math2.NormalizeRoll(myUnit.Attitude_Roll + 180f);
		}
		myUnit.Attitude_Pitch = num;
	}

	public void AdjustAttitude_Roll(float elapsedTime)
	{
		if (myUnit.DesiredRoll == myUnit.Attitude_Roll)
		{
			return;
		}
		if (myUnit.DesiredRoll > myUnit.Attitude_Roll)
		{
			if (myUnit.DesiredRoll - myUnit.Attitude_Roll > RollRate() * elapsedTime)
			{
				myUnit.Attitude_Roll += RollRate() * elapsedTime;
			}
			else
			{
				myUnit.Attitude_Roll = myUnit.DesiredRoll;
			}
		}
		else if (myUnit.Attitude_Roll - myUnit.DesiredRoll <= RollRate() * elapsedTime)
		{
			myUnit.Attitude_Roll = myUnit.DesiredRoll;
		}
		else
		{
			myUnit.Attitude_Roll -= RollRate() * elapsedTime;
		}
	}

	public virtual double GetDecelerationCapacity(float _Altitude, float _Speed, float elapsedTime)
	{
		double num = 1.5 * (double)Acceleration_Nominal(ActiveUnit.Throttle.Full, _Altitude) * (double)(_Speed / (float)myUnit.Kinematics.GetMaximumSpeed()) * (double)elapsedTime;
		if (!myUnit.IsMobileGroundUnit)
		{
			if (myUnit.IsAircraft && ((Aircraft)myUnit).get_CanHover(bool_7: true))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				num = Math.Max(num, 10f * elapsedTime);
			}
		}
		else
		{
			num *= 5.0;
		}
		return num;
	}

	public virtual void GoToDesiredSpeed(float elapsedTime, float ActualTurnRate)
	{
		try
		{
			if (myUnit.CurrentSpeed < 1f && myUnit.DesiredSpeed == 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
			if ((double)Math.Abs(myUnit.DesiredSpeed - myUnit.CurrentSpeed) < 0.5)
			{
				myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				return;
			}
			if (myUnit.DesiredSpeed == 0f && myUnit.CurrentSpeed > 0f && myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed == 0f && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredSpeed == 0f)
			{
				myUnit.CurrentSpeed = 0f;
				return;
			}
			float num = (float)((double)(Acceleration_Actual(myUnit.ThrottleSetting, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed) * elapsedTime) * (1.0 - 0.8 * (double)(ActualTurnRate / TurnRate())));
			if (num > 0f && myUnit.CurrentSpeed < myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed += num;
				if ((int)Math.Round(myUnit.CurrentSpeed) > (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed > myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - GetDecelerationCapacity(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed, elapsedTime));
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
			ex2?.Data.Add("Error at 100195", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void CalcTurnDeceleration(double TrueTurnRate, float elapsedTime)
	{
	}

	public virtual void ChangeAltitude(float elapsedTime, float theDesiredAlt, float? MinimumSafeAltitude, bool DoSanityCheck)
	{
		try
		{
			if (Module_Unit.IsRemoteSimEntity(myUnit))
			{
				myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + myUnit.DeadReckoning_VerticalSpeed * elapsedTime);
				return;
			}
			double num = (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.Altitude_old) / elapsedTime;
			myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			if (myUnit.IsWeapon && ((Weapon)myUnit).IsReEntryVehicle && myUnit.DesiredAltitude > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				myUnit.DesiredAltitude = Math.Min(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 1f, myUnit.DesiredAltitude);
			}
			float attitude_Pitch = myUnit.Attitude_Pitch;
			float num3 = ClimbRate_Actual(attitude_Pitch) * elapsedTime;
			float num4 = DiveRate_Actual(attitude_Pitch) * elapsedTime;
			if (num < 0.0)
			{
				num3 = (float)((double)num3 - num);
			}
			if (num > 0.0)
			{
				num4 = (float)((double)num4 - Math.Abs(num));
			}
			if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(theDesiredAlt < MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
			{
				theDesiredAlt = MinimumSafeAltitude.Value;
			}
			if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < theDesiredAlt)
			{
				num2 = (myUnit.SupportsAttitude_Pitch ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num3) : ((!(theDesiredAlt - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= num3)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num3) : theDesiredAlt));
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num2);
			}
			else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > theDesiredAlt)
			{
				num2 = (myUnit.SupportsAttitude_Pitch ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num4) : ((!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt <= num4)) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num4) : theDesiredAlt));
				if (MinimumSafeAltitude.HasValue && (MinimumSafeAltitude.HasValue ? new bool?(num2 <= MinimumSafeAltitude.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					myUnit.Attitude_Pitch = 0f;
				}
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, num2);
			}
			else
			{
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theDesiredAlt == 0f)
				{
					myUnit.DesiredPitch = 0f;
				}
				if (myUnit.Attitude_Pitch < 0f && MinimumSafeAltitude.HasValue)
				{
					float num5 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (((!MinimumSafeAltitude.HasValue) ? ((bool?)null) : new bool?(num5 <= MinimumSafeAltitude.GetValueOrDefault())) == true)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			float maximumAltitude = GetMaximumAltitude();
			float minimumAltitude = GetMinimumAltitude();
			if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, maximumAltitude);
				if (myUnit.Attitude_Pitch > 0f)
				{
					myUnit.Attitude_Pitch = 0f;
				}
			}
			else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude)
			{
				myUnit.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, minimumAltitude);
				if (myUnit.Attitude_Pitch < 0f)
				{
					myUnit.Attitude_Pitch = 0f;
				}
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

	public void ExportLocationEvent(string ForceUpdateReason = null, IEventExporter.ExportedEventType EventType = IEventExporter.ExportedEventType.UnitPositions)
	{
		try
		{
			bool flag = ForceUpdateReason != null;
			IEventExporter[] applicableEventExporters = myUnit.ParentScen.ApplicableEventExporters;
			int num = default(int);
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportUnitPositions || (!flag && !eventExporter.Common.LocationExportPossibleThisTick(myUnit.ParentScen, myUnit)) || myUnit.get_UnitSide(SetSideOnly: false) == null)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (myUnit.ParentScen.MonteCarloIteration > 0)
				{
					pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(17, ClearMode.Always);
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				if (!flag)
				{
					pooledDictionary.Add("OutOfSequenceReason", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					pooledDictionary.Add("OutOfSequenceReason", new IEventExporter.EventNotificationParameter(ForceUpdateReason, typeof(string)));
				}
				pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string), 40));
				pooledDictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(myUnit.DBID, typeof(string), 10));
				pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string), 500));
				pooledDictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(myUnit.UnitType_String, typeof(string), 20));
				pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string), 500));
				pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				pooledDictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(myUnit.CurrentHeading, typeof(float)));
				pooledDictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(myUnit.CurrentSpeed, typeof(float)));
				pooledDictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
				if (!myUnit.IsAircraft && !myUnit.IsMissile && !myUnit.IsTorpedo)
				{
					pooledDictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Pitch, typeof(float)));
				}
				else
				{
					pooledDictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Pitch_Derived(), typeof(float)));
				}
				pooledDictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(myUnit.Attitude_Roll, typeof(float)));
				if (eventExporter.UsesUnitMissionAndStatus)
				{
					pooledDictionary.Add("Status", new IEventExporter.EventNotificationParameter(Misc.ToEnglishString(myUnit.Status, myUnit), typeof(string), 100));
					pooledDictionary.Add("Condition_AirOps", new IEventExporter.EventNotificationParameter((!myUnit.IsAircraft) ? string.Empty : ((Aircraft)myUnit).AirOps.ConditionString, typeof(string), 100));
					pooledDictionary.Add("Condition_DockingOps", new IEventExporter.EventNotificationParameter(myUnit.DockingOps.ConditionString, typeof(string), 100));
					string theValue = string.Empty;
					if (myUnit.ActiveMissionOrPackage() != null)
					{
						theValue = myUnit.ActiveMissionOrPackage().Name;
					}
					pooledDictionary.Add("AssignedMission", new IEventExporter.EventNotificationParameter(theValue, typeof(string), 100));
				}
				if (eventExporter.UsesUnitDamage)
				{
					pooledDictionary.Add("DamagePercent", new IEventExporter.EventNotificationParameter(myUnit.Damage.DamagePercent, typeof(float)));
					pooledDictionary.Add("Fire", new IEventExporter.EventNotificationParameter((myUnit.Damage.FireIntensity != ActiveUnit_Damage.FireIntensityLevel.NoFire) ? myUnit.Damage.FireIntensity.ToString() : "None", typeof(string)));
					pooledDictionary.Add("Flood", new IEventExporter.EventNotificationParameter((myUnit.Damage.FloodIntensity != ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding) ? myUnit.Damage.FloodIntensity.ToString() : "None", typeof(string)));
					string text = string.Empty;
					ReadOnlyCollection<PlatformComponent> readOnlyCollection = myUnit.Components();
					foreach (PlatformComponent item in readOnlyCollection)
					{
						if (item.Status != PlatformComponent._ComponentStatus.Operational)
						{
							text = text + item.ObjectID + "_" + item.DBID + "_" + item.DamageSeverity.ToString() + "|";
							num++;
						}
					}
					if (num > 1)
					{
						text = text.Substring(0, text.Length - 1);
					}
					pooledDictionary.Add("ComponentStatus", new IEventExporter.EventNotificationParameter(text, typeof(string), 4000));
				}
				eventExporter.ExportEvent(EventType, pooledDictionary, myUnit.ParentScen);
				eventExporter.Common.ApplyLastExportLocation(myUnit);
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

	public virtual void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			if (myUnit.AI.HoldPosition)
			{
				if (!myUnit.IsAircraft)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
			}
			else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None && !myUnit.Navigator.IsManouveringToFormationStation)
				{
					if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						if (!myUnit.IsAircraft)
						{
							if (myUnit.IsShip)
							{
								ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
								if (dockingOps.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
								{
									myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
								}
							}
							else if (myUnit.IsSubmarine)
							{
								ActiveUnit_DockingOps dockingOps2 = myUnit.DockingOps;
								if (dockingOps2.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps2.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps2.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps2.UNREP_Astern_ReceiverUnitID))
								{
									myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
								}
							}
							else
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
						else
						{
							Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)myUnit.AirOps;
							if (aircraft_AirOps.RefuellingQueue.Count + aircraft_AirOps.A2AR_Connections.Count == 0)
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
					}
				}
				else
				{
					myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
			}
			float num = GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: true);
			if (myUnit.IsShip && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed))
			{
				int maximumSpeedForThisSeaState = Ship_Kinematics.GetMaximumSpeedForThisSeaState((Ship)myUnit, Weather.get_WeatherAtThisTimeAndPlace(myUnit.ParentScen, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), 0).SeaState);
				if (num > (float)maximumSpeedForThisSeaState)
				{
					num = maximumSpeedForThisSeaState;
				}
			}
			if ((myUnit.IsShip || myUnit.IsSubmarine) && GeoPoint.get_IsInCanal(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				num = 8f;
			}
			if (myUnit.IsOutOfFuel)
			{
				if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
				{
					if (!(myUnit.Attitude_Pitch <= ((Weapon)myUnit).InfiniteGlideAngle))
					{
						num = 0f;
					}
				}
				else
				{
					num = 0f;
				}
			}
			if (myUnit.DesiredSpeed > num)
			{
				myUnit.DesiredSpeed = num;
			}
			double num2 = myUnit.CurrentHeading;
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
			double num3 = (double)Math.Abs(MathFunctions.AngularDifference((float)num2, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
			CalcTurnDeceleration(num3, elapsedTime);
			bool flag = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
			{
				int num4;
				if (!myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					num4 = 1;
				}
				else
				{
					int? num5 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = ((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 15));
					if (((!flag2) ?? flag2) != true)
					{
						goto IL_0637;
					}
					num4 = 1;
				}
				flag = (byte)num4 != 0;
			}
			goto IL_0637;
			IL_0637:
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(elapsedTime, (float)num3);
			}
			if (myUnit.IsShip && myUnit.ParentScen.UnguidedWeapons.HasElements())
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
			ex2?.Data.Add("Error at 100197", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual float HorizMovementDistanceOnThisTime(float elapsedTime)
	{
		return Module_Unit.CurrentSpeed_Horizontal(myUnit) / 3600f * elapsedTime;
	}

	public virtual float HorizDistranceRequiredToReachDesiredAltitude(ActiveUnit myUnit, float DesiredAltitude, float ClosureSpeed = 0f)
	{
		float result = default(float);
		lock (myUnit)
		{
			try
			{
				if (!myUnit.IsAircraft && !myUnit.IsSatellite && !myUnit.IsWeapon)
				{
					result = 0f;
					return result;
				}
				if (myUnit.Propulsion.Count == 0)
				{
					result = 0f;
					return result;
				}
				if (myUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop)
				{
					if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == DesiredAltitude)
					{
						result = 0f;
						return result;
					}
					AltBand altBand = null;
					Engine engine = myUnit.Propulsion[0];
					float num = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					list_0.Clear();
					AltBand[] altBands = engine.AltBands;
					if (altBands.Length == 0)
					{
						result = 0f;
						return result;
					}
					if (engine.Status == PlatformComponent._ComponentStatus.Destroyed)
					{
						result = 0f;
						return result;
					}
					float num2;
					float num3;
					float num4;
					if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > DesiredAltitude)
					{
						AltBand[] array = altBands;
						foreach (AltBand altBand2 in array)
						{
							if (altBand2.MinAlt <= num && altBand2.MaxAlt >= DesiredAltitude)
							{
								list_0.Add(altBand2);
							}
						}
						if (list_0.Count > 1)
						{
							list_0.Sort(new AltBandComparer_SortyByMaxAltAscending());
						}
						num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						num3 = DesiredAltitude;
						num4 = myUnit.Kinematics.DiveRate_Nominal();
					}
					else
					{
						if (!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < DesiredAltitude))
						{
							result = 0f;
							return result;
						}
						AltBand[] array2 = altBands;
						foreach (AltBand altBand3 in array2)
						{
							if (altBand3.MaxAlt >= num && altBand3.MinAlt <= DesiredAltitude)
							{
								list_0.Add(altBand3);
							}
						}
						if (list_0.Count > 1)
						{
							list_0.Sort(new AltBandComparer_SortyByMaxAltAscending());
						}
						num2 = DesiredAltitude;
						num3 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						num4 = myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
					}
					if (list_0.Count == 0)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						result = 0f;
						return result;
					}
					float num5 = default(float);
					float num9 = default(float);
					float num13 = default(float);
					foreach (AltBand item in list_0)
					{
						try
						{
							switch (myUnit.ThrottleSetting)
							{
							case ActiveUnit.Throttle.FullStop:
								result = 0f;
								return result;
							case ActiveUnit.Throttle.Loiter:
								num5 = item.Speed_Loiter;
								break;
							case ActiveUnit.Throttle.Cruise:
								num5 = ((item.Speed_Cruise <= 0) ? ((float)item.Speed_Loiter) : ((float)item.Speed_Cruise));
								break;
							case ActiveUnit.Throttle.Full:
								num5 = (item.Speed_Full.HasValue ? ((float)item.Speed_Full.Value) : ((float)item.Speed_Cruise));
								break;
							case ActiveUnit.Throttle.Flank:
								num5 = ((!item.Speed_Flank.HasValue) ? (item.Speed_Full.HasValue ? ((float)item.Speed_Full.Value) : ((float)item.Speed_Cruise)) : ((float)item.Speed_Flank.Value));
								break;
							}
							float num6;
							float num7;
							int num8;
							if (item == HighestAltBand(engine))
							{
								num6 = item.MinAlt;
								num7 = item.MaxAlt;
								num8 = (int)Math.Round(num5);
							}
							else
							{
								altBand = altBands[Array.IndexOf(altBands, item) + 1];
								switch (myUnit.ThrottleSetting)
								{
								case ActiveUnit.Throttle.FullStop:
									num9 = 0f;
									break;
								case ActiveUnit.Throttle.Loiter:
									num9 = altBand.Speed_Loiter;
									break;
								case ActiveUnit.Throttle.Cruise:
									num9 = altBand.Speed_Cruise;
									break;
								case ActiveUnit.Throttle.Full:
									num9 = ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value));
									break;
								case ActiveUnit.Throttle.Flank:
									num9 = ((!altBand.Speed_Flank.HasValue) ? ((!altBand.Speed_Full.HasValue) ? ((float)altBand.Speed_Cruise) : ((float)altBand.Speed_Full.Value)) : ((float)altBand.Speed_Flank.Value));
									break;
								}
								int num10;
								if (num3 > item.MinAlt)
								{
									num6 = num3;
									num10 = GetMaximumSpeed(num3, myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
								}
								else
								{
									num6 = item.MinAlt;
									num10 = (int)Math.Round(num5);
								}
								int num11;
								if (num2 < item.MaxAlt)
								{
									num7 = num2;
									num11 = GetMaximumSpeed(num2, myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
								}
								else
								{
									num7 = altBand.MinAlt;
									num11 = (int)Math.Round(num9);
								}
								num8 = (int)Math.Round((double)(num11 + num10) / 2.0 + (double)ClosureSpeed);
							}
							float num12 = (num7 - num6) / num4;
							num13 += num12 / 3600f * (float)num8;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101165", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					result = Math.Abs(num13);
					return result;
				}
				result = 0f;
				return result;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100198", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public virtual float TurnRate()
	{
		if (!myUnit.IsSatellite)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		}
		return 0f;
	}

	public static float TurnRateCategoryToActualTurnRate(Waypoint.TurnRateCategory theCategory, float theCurrentSpeed)
	{
		return theCategory switch
		{
			Waypoint.TurnRateCategory.StandardRateTurn => 3f, 
			Waypoint.TurnRateCategory.HalfStandardRateTurn => 1.5f, 
			Waypoint.TurnRateCategory.DoubleStandardRateTurn => 6f, 
			Waypoint.TurnRateCategory.FlatTurn => 0.6f, 
			Waypoint.TurnRateCategory.TwoGTurn => G_To_DegreesPerSecond(theCurrentSpeed, 60f), 
			Waypoint.TurnRateCategory.const_5 => G_To_DegreesPerSecond(theCurrentSpeed, 70f), 
			Waypoint.TurnRateCategory.const_6 => G_To_DegreesPerSecond(theCurrentSpeed, 75f), 
			_ => 3f, 
		};
	}

	public static float G_To_DegreesPerSecond(float theSpeed, float theBankAngle)
	{
		return (float)(1091.0 * Math.Tan((double)theBankAngle * 0.0174532925199433) / (double)theSpeed);
	}
}
