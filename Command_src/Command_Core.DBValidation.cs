using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DBValidation
{
	internal static int CalculateWeaponFuel(int WeaponID, Scenario theScen, bool AssumeAirLaunch)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
		ActiveUnit activeUnit;
		if (AssumeAirLaunch)
		{
			Aircraft aircraft = new Aircraft(ref theScen);
			aircraft.set_Longitude((GlobalVariables.BooleanObject)null, 1.0);
			aircraft.set_Latitude((GlobalVariables.BooleanObject)null, -60.0);
			aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 10972.8f);
			if (newWeapon.MaxLaunchAlt_ASL > 0f && newWeapon.MaxLaunchAlt_ASL < aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, newWeapon.MaxLaunchAlt_ASL);
			}
			else if (newWeapon.MinLaunchAlt_ASL > 0f && newWeapon.MinLaunchAlt_ASL > aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, newWeapon.MinLaunchAlt_ASL);
			}
			aircraft.CurrentSpeed = (float)Weapon_Kinematics.EstimateLaunchSpeedKnots(aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			activeUnit = aircraft;
		}
		else
		{
			activeUnit = new Ship(ref theScen)
			{
				[null] = 1.0,
				[null] = -60.0,
				[false, null] = 0f,
				CurrentSpeed = 0f
			};
		}
		List<int> list = new List<int>();
		if (newWeapon.IsABMOptimized() || newWeapon.ValidTargets.Satellite)
		{
			float distance_NM = (float)((double)newWeapon.MaxAirRange * 0.75);
			float num = ((!AssumeAirLaunch) ? newWeapon.MaxTargetAlt_ASL : (activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + newWeapon.SnapUpDown));
			float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
			int num2;
			if (num > maximumAltitude)
			{
				num = maximumAltitude - 1f;
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			float num4 = 0f;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, 90);
			Aircraft aircraft2 = new Aircraft(ref theScen);
			aircraft2.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			aircraft2.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			aircraft2.CurrentHeading = num4;
			aircraft2.CurrentSpeed = num3;
			aircraft2.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, num);
			int value = smethod_0(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, out_lon, out_lat, num4, bool_0: true, num3, bool_1: true, aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value);
		}
		float num5 = default(float);
		if (newWeapon.ValidTargets.Aircraft)
		{
			num5 = 0.15f;
			float maxAirRange = newWeapon.MaxAirRange;
			float value2;
			int num6;
			if (newWeapon.MaxTargetAlt_ASL < 10972.8f)
			{
				value2 = 36000f * newWeapon.MaxTargetAlt_ASL;
				num6 = 573;
			}
			else
			{
				value2 = 10972.8f;
				num6 = 573;
			}
			int num7 = num6;
			float num8 = 270f;
			double out_lon2 = default(double);
			double out_lat2 = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, maxAirRange, 90);
			Aircraft aircraft3 = new Aircraft(ref theScen);
			aircraft3.set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
			aircraft3.set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
			aircraft3.CurrentHeading = num8;
			aircraft3.CurrentSpeed = num7;
			aircraft3.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value2);
			int value3 = smethod_0(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), aircraft3, out_lon2, out_lat2, num8, bool_0: true, num7, bool_1: true, aircraft3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value3);
		}
		if (newWeapon.IsASuW_Land || newWeapon.IsASuW_Naval || newWeapon.IsAerialASWGuidedWeapon())
		{
			num5 = 0.2f;
			float distance_NM2 = Math.Max(Math.Max(newWeapon.MaxSurfaceRange, newWeapon.MaxLandRange), newWeapon.MaxSubsurfaceRange);
			float num9 = 0f;
			double out_lon3 = default(double);
			double out_lat3 = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon3, ref out_lat3, distance_NM2, 90);
			Ship ship = new Ship(ref theScen);
			((ActiveUnit)ship).set_Longitude((GlobalVariables.BooleanObject)null, out_lon3);
			((ActiveUnit)ship).set_Latitude((GlobalVariables.BooleanObject)null, out_lat3);
			ship.CurrentHeading = num9;
			ship.CurrentSpeed = 0f;
			((ActiveUnit)ship).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Math.Max(0, (int)Terrain.GetElevation(((ActiveUnit)ship).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)ship).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen)));
			int value4 = smethod_0(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), ship, out_lon3, out_lat3, num9, bool_0: true, 0, bool_1: true, ((ActiveUnit)ship).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value4);
		}
		return (int)Math.Round((float)list.Max() * (1f + num5));
	}

	private static int? smethod_0(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, ActiveUnit activeUnit_1, double double_2, double double_3, float float_1, bool bool_0, int int_2, bool bool_1, float float_2, bool bool_2, float float_3 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise, ArrayList arrayList_0 = null, ArrayList arrayList_1 = null)
	{
		int? result = default(int?);
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_5: true);
			newWeapon.IsDLZconstruct = true;
			newWeapon.FiringParent = activeUnit_0;
			if (newWeapon.Flags.SearchPattern)
			{
				newWeapon.Flags.SearchPattern = false;
			}
			newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, double_0);
			newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, double_1);
			newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, float_0);
			newWeapon.CurrentSpeed = int_1;
			if (throttle_0 <= newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(throttle_0);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (float_3 > 0f)
			{
				newWeapon.CurrentHeading = float_3;
			}
			else
			{
				newWeapon.CurrentHeading = Math2.CalcAzimuth(double_1, double_0, double_3, double_2);
			}
			newWeapon.Fuel_ReadOnly[0].CurrentQuantity = 2.1474836E+09f;
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			Contact contact = Contact.Instantiate(activeUnit_1);
			((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, float_2);
			contact.AltitudeIsKnown = bool_2;
			contact.CurrentSpeed = int_2;
			contact.SpeedIsKnown = bool_1;
			contact.CurrentHeading = float_1;
			contact.HeadingIsKnown = bool_0;
			((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, double_2);
			((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, double_3);
			newWeapon.AI.PrimaryTarget = contact;
			if ((!newWeapon.Is_LOAL_capable && newWeapon.Guidance != Weapon.WeaponGuidanceType.Inertial) || newWeapon.Navigator.ComputeTerminalPoint(newWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), throttle_0, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false).HasValue)
			{
				newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
				float num = 0f;
				bool flag2 = default(bool);
				do
				{
					double out_lat;
					Contact contact3;
					double out_lon;
					Contact contact2;
					if (contact.CurrentSpeed != 0f)
					{
						double lon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
						double lat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
						out_lon = ((Module_Unit.Unit)(contact2 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
						out_lat = ((Module_Unit.Unit)(contact3 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
						((Module_Unit.Unit)contact3).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
						((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
						activeUnit_1.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
						activeUnit_1.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
					}
					newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
					if (throttle_0 <= newWeapon.MaxPossibleThrottleSetting)
					{
						newWeapon.SetThrottle(throttle_0);
					}
					else
					{
						newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
					}
					newWeapon.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, scenario_0.Time.AddSeconds(num), GhostMovement: true);
					arrayList_0?.Add(Math2.CalcDist(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null)));
					int num2;
					if (arrayList_1 != null)
					{
						arrayList_1.Add(newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					bool flag = (byte)num2 != 0;
					if (activeUnit_0.RangeToUnit_Horiz(contact) < activeUnit_0.RangeToUnit_Horiz(newWeapon))
					{
						flag = true;
					}
					if (!flag && !newWeapon.AboutToImpact_Contact(1f))
					{
						num += 1f;
						continue;
					}
					double lon2 = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
					double lat2 = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
					out_lat = ((Module_Unit.Unit)(contact3 = contact)).get_Longitude((GlobalVariables.BooleanObject)null);
					out_lon = ((Module_Unit.Unit)(contact2 = contact)).get_Latitude((GlobalVariables.BooleanObject)null);
					Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lat, ref out_lon, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					((Module_Unit.Unit)contact2).set_Latitude((GlobalVariables.BooleanObject)null, out_lon);
					((Module_Unit.Unit)contact3).set_Longitude((GlobalVariables.BooleanObject)null, out_lat);
					newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
					newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
					newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					flag2 = true;
					break;
				}
				while (num <= 2.1474836E+09f);
				contact = null;
				if (flag2)
				{
					result = (int)Math.Round(num + 1f);
					return result;
				}
				result = int.MaxValue;
				return result;
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100324566221", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static (int BurnTime, int FlightEndurance) CalculateWeaponBurnTime(int WeaponID, Scenario theScen, bool AssumeAirLaunch, float customBodyDiameter_m = 0f, float customBodyLength_m = 0f, int customLaunchWeight_kg = 0, int customBurnoutWeight_kg = 0)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, WeaponID, bool_5: true);
		ActiveUnit activeUnit;
		if (!AssumeAirLaunch)
		{
			activeUnit = new Ship(ref theScen)
			{
				[null] = 1.0,
				[null] = -60.0,
				[false, null] = 0f,
				CurrentSpeed = 0f
			};
		}
		else
		{
			Aircraft aircraft = new Aircraft(ref theScen);
			aircraft.set_Longitude((GlobalVariables.BooleanObject)null, 1.0);
			aircraft.set_Latitude((GlobalVariables.BooleanObject)null, -60.0);
			aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 10972.8f);
			if (newWeapon.MaxLaunchAlt_ASL > 0f && newWeapon.MaxLaunchAlt_ASL < aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				aircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, newWeapon.MaxLaunchAlt_ASL);
			}
			aircraft.CurrentSpeed = 660f;
			activeUnit = aircraft;
		}
		double out_lon = default(double);
		double out_lat = default(double);
		(int, int) tuple;
		float maxAirRange;
		float num;
		int num6;
		int num3;
		float num4;
		Aircraft aircraft2;
		if (newWeapon.IsAAWCapable && newWeapon.MaxAirRange > 0f)
		{
			maxAirRange = newWeapon.MaxAirRange;
			aircraft2 = new Aircraft(ref theScen);
			num = 10972.8f;
			float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
			if (num > maximumAltitude)
			{
				num = maximumAltitude - 1f;
			}
			if (newWeapon.MaxTargetAlt_ASL != 0f && newWeapon.MaxTargetAlt_ASL < num)
			{
				num = newWeapon.MaxTargetAlt_ASL - 1f;
			}
			if (newWeapon.SnapUpDown != 0f)
			{
				int num2 = (int)Math.Round(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + newWeapon.SnapUpDown);
				if ((float)num2 < num)
				{
					num = num2 - 1;
				}
			}
			maxAirRange = newWeapon.MaxAirRange;
			num3 = 660;
			num4 = 270f;
			if (newWeapon.Flags.SternChase_AAM)
			{
				num4 = 90f;
			}
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, maxAirRange, 90);
			aircraft2.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			aircraft2.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			aircraft2.CurrentHeading = num4;
			aircraft2.CurrentSpeed = num3;
			aircraft2.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, num);
			tuple = smethod_1(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, out_lon, out_lat, num4, bool_0: true, num3, bool_1: true, aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, 0f, Contact_Base.ContactType.Air, activeUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, null, bool_3: false, customBodyDiameter_m, customBodyLength_m, customLaunchWeight_kg, customBurnoutWeight_kg);
			if (tuple.Item1 == 1 && (double)newWeapon.Kinematics.MinimumDesiredAverageSpeedMultiplier() > 0.6)
			{
				tuple.Item1++;
			}
			maxAirRange = (newWeapon.IsABMOptimized() ? ((float)((double)newWeapon.MaxAirRange * 0.75)) : (newWeapon.MaxAirRange / 10f));
			num = maximumAltitude - 1f;
			if (newWeapon.MaxTargetAlt_ASL != 0f && newWeapon.MaxTargetAlt_ASL < num)
			{
				num = newWeapon.MaxTargetAlt_ASL - 1f;
			}
			if (newWeapon.SnapUpDown != 0f)
			{
				int num5 = (int)Math.Round(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + newWeapon.SnapUpDown);
				if ((float)num5 < num)
				{
					num = num5 - 1;
					num6 = 0;
					goto IL_0316;
				}
			}
			num6 = 0;
			goto IL_0316;
		}
		float num7 = Math.Max(Math.Max(newWeapon.MaxSurfaceRange, newWeapon.MaxLandRange), newWeapon.MaxSubsurfaceRange);
		(int, int) result = default((int, int));
		if (num7 > 0f)
		{
			float num8 = 0f;
			double out_lon2 = default(double);
			double out_lat2 = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, num7, 90);
			Ship ship = new Ship(ref theScen);
			((ActiveUnit)ship).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
			((ActiveUnit)ship).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
			ship.CurrentHeading = num8;
			ship.CurrentSpeed = 0f;
			((ActiveUnit)ship).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Math.Max(0, (int)Terrain.GetElevation(((ActiveUnit)ship).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)ship).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen)));
			result = smethod_1(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), ship, out_lon2, out_lat2, num8, bool_0: true, 0, bool_1: true, ((ActiveUnit)ship).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, 0f, Contact_Base.ContactType.Surface, activeUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, null, bool_3: false, customBodyDiameter_m, customBodyLength_m, customLaunchWeight_kg, customBurnoutWeight_kg);
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return result;
		IL_0316:
		num3 = num6;
		num4 = 270f;
		Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, maxAirRange, 90);
		aircraft2 = new Aircraft(ref theScen);
		aircraft2.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
		aircraft2.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
		aircraft2.CurrentHeading = num4;
		aircraft2.CurrentSpeed = num3;
		aircraft2.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, num);
		(int, int) tuple2 = smethod_1(theScen, WeaponID, activeUnit, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, out_lon, out_lat, num4, bool_0: true, num3, bool_1: true, aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), bool_2: true, 0f, Contact_Base.ContactType.Air, activeUnit.CurrentHeading, ActiveUnit.Throttle.Cruise, null, bool_3: false, customBodyDiameter_m, customBodyLength_m, customLaunchWeight_kg, customBurnoutWeight_kg);
		return (BurnTime: Math.Max(tuple.Item1, tuple2.Item1), FlightEndurance: Math.Max(tuple.Item2, tuple2.Item2));
	}

	private static (int, int) smethod_1(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, object object_0, double double_2, double double_3, float float_1, bool bool_0, int int_2, bool bool_1, float float_2, bool bool_2, float float_3, Contact_Base.ContactType contactType_0, float float_4 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise, int? nullable_0 = null, bool bool_3 = false, float float_5 = 0f, float float_6 = 0f, int int_3 = 0, int int_4 = 0)
	{
		Weapon weapon = scenario_0.Cache_GetWeapon(int_0);
		(int, int) result = default((int, int));
		try
		{
			double num = (float)weapon.Kinematics.GetMaximumSpeed() * weapon.Kinematics.MinimumDesiredAverageSpeedMultiplier();
			int i;
			GeoPoint InterceptPoint = default(GeoPoint);
			string FeedbackText = default(string);
			float item = default(float);
			for (i = Math.Max(1, (int)Math.Round(weapon.MaxRange_NoTargetType / 10f)); !nullable_0.HasValue || (nullable_0.HasValue ? new bool?(i >= nullable_0.GetValueOrDefault()) : ((bool?)null)) != true; i++)
			{
				int customBurnTime = i;
				float FlightTime = 0f;
				(ActiveUnit_Weaponry.DLZResultEnum, float) tuple = ActiveUnit_Weaponry.TargetIsWithinDLZ_BoostCoast(scenario_0, int_0, null, activeUnit_0, AssumeVerticalLaunch: false, double_0, double_1, float_0, int_1, double_2, double_3, float_1, bool_0, int_2, bool_1, float_2, bool_2, float_3, contactType_0, ref InterceptPoint, TargetIsTerminalDiving: false, ref FeedbackText, IsPartOfBurnCalc: true, HumanFeedBackNeeded: false, float_4, throttle_0, customBurnTime, null, ref FlightTime, null, null, ActiveUnit_Weaponry.AssumedDLZTargetBehavior.ContinuesAsCurrent, bool_3, float_5, float_6, int_3, int_4);
				if (tuple.Item1 != ActiveUnit_Weaponry.DLZResultEnum.Success)
				{
					continue;
				}
				if (!weapon.IsAAWCapable)
				{
					float num2 = InterceptPoint.RangeToPoint_Slant(new Geopoint_Struct(double_0, double_1, float_0));
					item = tuple.Item2;
					if ((double)(num2 / (item / 3600f)) < num && (float)i < item)
					{
						continue;
					}
				}
				else
				{
					float num3 = InterceptPoint.RangeToPoint_Slant(new Geopoint_Struct(double_0, double_1, float_0));
					item = tuple.Item2;
					if ((double)(num3 / (item / 3600f)) < num && (float)i < item)
					{
						continue;
					}
				}
				result = ((int)Math.Floor((double)i * 1.2 + 0.5), (int)Math.Round(item));
				return result;
			}
			result = (i, (int)Math.Round(item));
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100324566221", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static DBValidation()
	{
		Class72.smethod_20();
	}
}
