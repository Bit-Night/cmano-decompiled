using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile_Kinematics : Weapon_Kinematics
{
	private BallisticMissile ballisticMissile_0;

	public BallisticMissile_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	private BallisticMissile method_11()
	{
		if (ballisticMissile_0 == null)
		{
			ballisticMissile_0 = (BallisticMissile)myUnit;
		}
		return ballisticMissile_0;
	}

	internal bool HasReachedRVReleasePoint()
	{
		if (BallisticTrajectory != null)
		{
			if (!method_11().HasRVs.Value)
			{
				Weapon weapon = method_11().Warheads[0].get_CarriedWeapon(method_11().ParentScen);
				if (weapon != null)
				{
					ActiveUnit_Weaponry weaponry = method_11().Weaponry;
					Contact primaryTarget = method_11().AI.PrimaryTarget;
					int? ASL_atFiringUnit = (int)Math.Round(method_11().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					Sensor SuitableDirectorSensor = null;
					if (weaponry.CanThisWeaponEngageThisTarget(weapon, primaryTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
					{
						return true;
					}
				}
			}
			float num;
			if (method_11().AI.PrimaryTarget != null)
			{
				num = method_11().RangeToUnit_Horiz(method_11().AI.PrimaryTarget);
			}
			else
			{
				if (method_11().Navigator.PlottedCourse.Length <= 0)
				{
					return false;
				}
				Waypoint waypoint = method_11().Navigator.PlottedCourse[0];
				num = Module_Unit.RangeToPoint_Horiz(method_11(), waypoint.Latitude, waypoint.Longitude);
			}
			Weapon weapon2 = method_11().Warheads.FirstOrDefault()?.get_CarriedWeapon(method_11().ParentScen);
			float num2 = num;
			float? num3 = weapon2?.MaxRange_NoTargetType;
			if (((!num3.HasValue) ? ((bool?)null) : new bool?(num2 > num3.GetValueOrDefault())) != true)
			{
				float num4 = Module_Unit.RangeToPoint_Horiz(method_11(), method_11().LaunchPoint);
				if (num < num4)
				{
					int result;
					if (weapon2 == null)
					{
						result = 1;
					}
					else
					{
						if (!(myUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) <= weapon2.Kinematics.GetMaximumAltitude()))
						{
							goto IL_01cc;
						}
						result = 1;
					}
					return (byte)result != 0;
				}
				goto IL_01cc;
			}
			return false;
		}
		return false;
		IL_01cc:
		return false;
	}

	public static TrajectoryPoint[] EstimatedFuturePathOfBallisticTarget(Contact theTarget, Scenario theScen)
	{
		if (theTarget.ActualUnit == null)
		{
			return new TrajectoryPoint[0];
		}
		return EstimatedFutureBallisticPath(theTarget.ActualUnit, ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), theTarget.ActualUnit.AI.PrimaryTarget, theScen);
	}

	public static TrajectoryPoint[] EstimatedFutureBallisticPath(ActiveUnit theUnit, double StartLatitude, double StartLongitude, Contact theTarget, Scenario theScen)
	{
		if (theUnit is BallisticMissile)
		{
			BallisticMissile ballisticMissile = (BallisticMissile)theUnit;
			if (ballisticMissile.Kinematics.BallisticTrajectory != null)
			{
				theTarget = new AimpointContact(ballisticMissile.Kinematics.BallisticTrajectory.Target.lat * 180.0 / Math.PI, ballisticMissile.Kinematics.BallisticTrajectory.Target.lon * 180.0 / Math.PI);
			}
		}
		Weapon newWeapon = Weapon.GetNewWeapon(ref theUnit.ParentScen, theUnit.DBID, bool_5: true);
		newWeapon.IsDLZconstruct = true;
		newWeapon.AI.PrimaryTarget = theTarget;
		newWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		newWeapon.CurrentSpeed = theUnit.CurrentSpeed;
		newWeapon.CurrentHeading = theUnit.CurrentHeading;
		newWeapon.set_Longitude((GlobalVariables.BooleanObject)null, StartLongitude);
		newWeapon.set_Latitude((GlobalVariables.BooleanObject)null, StartLatitude);
		newWeapon.Attitude_Pitch = theUnit.Attitude_Pitch;
		bool flag = false;
		if (theUnit.IsWeapon & ((Weapon)theUnit).IsHGV)
		{
			flag = true;
		}
		if (theUnit.IsBallisticMissile && !flag)
		{
			newWeapon.TimeSinceBurnout = ((Weapon)theUnit).TimeSinceBurnout;
			newWeapon.TimeSinceLaunch = ((Weapon)theUnit).TimeSinceLaunch;
			if (newWeapon.TimeSinceLaunch == 0f)
			{
				newWeapon.Attitude_Pitch = 90f;
			}
		}
		Weapon weapon = (Weapon)theUnit;
		newWeapon.LaunchPoint = new GeoPoint();
		if (weapon.LaunchPoint != null)
		{
			newWeapon.LaunchPoint.Longitude = weapon.LaunchPoint.Longitude;
			newWeapon.LaunchPoint.Latitude = weapon.LaunchPoint.Latitude;
			newWeapon.LaunchPoint.Altitude = weapon.LaunchPoint.Altitude;
		}
		else
		{
			newWeapon.LaunchPoint.Longitude = StartLongitude;
			newWeapon.LaunchPoint.Latitude = StartLatitude;
			newWeapon.LaunchPoint.Altitude = theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		newWeapon.FiringParent = weapon.FiringParent;
		if (newWeapon.FiringParent != null)
		{
			newWeapon.LaunchSpeed = newWeapon.FiringParent.CurrentSpeed;
		}
		newWeapon.Navigator.ClearPlottedCourse();
		Waypoint[] plottedCourse = weapon.Navigator.PlottedCourse;
		foreach (Waypoint theWP in plottedCourse)
		{
			newWeapon.Navigator.AddWaypoint(theWP);
		}
		float num = 1f;
		newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
		_ = theScen.Time;
		DateTime theTime = theScen.Time;
		long num2 = (long)Math.Round((86400.0 + theScen.Duration.TotalSeconds) / 1.0);
		int num3 = 0;
		if (newWeapon is BallisticMissile)
		{
			BallisticMissile_Kinematics ballisticMissile_Kinematics = (BallisticMissile_Kinematics)newWeapon.Kinematics;
			if (ballisticMissile_Kinematics.BallisticTrajectory == null)
			{
				ballisticMissile_Kinematics.method_12();
				if (ballisticMissile_Kinematics.BallisticTrajectory == null)
				{
					return new TrajectoryPoint[0];
				}
			}
		}
		List<TrajectoryPoint> list = ((newWeapon.Fuel_ReadOnly.Count <= 0) ? new List<TrajectoryPoint>() : new List<TrajectoryPoint>((int)Math.Round(newWeapon.Fuel_ReadOnly[0].CurrentQuantity)));
		bool flag2 = newWeapon.IsWeapon && newWeapon.IsHGV;
		do
		{
			theTime = theTime.AddSeconds(num);
			newWeapon.AI.DetermineDesiredAttitudeAndThrottle(num);
			newWeapon.Kinematics.Move(num, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: true, DateTime.MinValue);
			list.Add(new TrajectoryPoint(newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theTime));
			if ((flag2 && Module_Unit.IsWithinAtmosphere(newWeapon)) || newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f || (newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation && newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GetElevation(newWeapon.get_Latitude((GlobalVariables.BooleanObject)null), newWeapon.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen)) || (newWeapon.Attitude_Pitch < 0f && newWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= newWeapon.ImpactAltitude + 10f) || (newWeapon.IsNuke.Value && newWeapon.Navigator.HasPlottedCourse() && newWeapon.Navigator.PlottedCourse.First().Altitude > 9000f && Module_Unit.RangeToPoint_Horiz(newWeapon, newWeapon.Navigator.PlottedCourse.First().Latitude, newWeapon.Navigator.PlottedCourse.First().Longitude) <= Module_Unit.CurrentSpeed_Horizontal(newWeapon) / 3600f))
			{
				break;
			}
			num3++;
		}
		while (num3 <= num2);
		return list.ToArray();
	}

	private void method_12()
	{
		int num = 60;
		Contact contact = base.myWeapon.AI.PrimaryTarget;
		if (contact == null)
		{
			if (base.myWeapon.FiringParent != null && ((ActiveUnit)base.myWeapon).get_UnitSide(SetSideOnly: false) != null)
			{
				ReadOnlyCollection<WeaponSalvo> weaponSalvos = ((ActiveUnit)base.myWeapon).get_UnitSide(SetSideOnly: false).GetWeaponSalvos();
				foreach (WeaponSalvo item in weaponSalvos)
				{
					if (item.ShootersList.Where([SpecialName] (WeaponSalvo.Shooter theSh) => Operators.CompareString(theSh.ShooterObjectID, base.myWeapon.FiringParent.ObjectID, false) == 0).FirstOrDefault() != null)
					{
						contact = item.Target;
					}
				}
			}
			if (contact == null)
			{
				if (!base.myWeapon.Navigator.HasPlottedCourse())
				{
					Weapon weapon = base.myWeapon;
					double theLat = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt = base.myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG = GameGeneral.GlobalRNG;
					weapon.Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
					return;
				}
				Waypoint waypoint = method_11().Navigator.PlottedCourse[0];
				contact = new AimpointContact(waypoint.Latitude, waypoint.Longitude);
			}
		}
		double num2 = Math.Max(base.myWeapon.MaxSurfaceRange, base.myWeapon.MaxLandRange);
		if (base.myWeapon.Navigator.PlottedCourse.Count() > 0 && contact.SpeedIsKnown && contact.CurrentSpeed > 0f)
		{
			float num3 = Module_Unit.BearingToPoint_True(base.myWeapon, base.myWeapon.Navigator.PlottedCourse[0].Latitude, base.myWeapon.Navigator.PlottedCourse[0].Longitude);
			Geopoint_Struct thePoint = MathFunctions.Intersection(base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null), base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null), num3, ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), contact.CurrentHeading);
			if (!thePoint.HasZeroCoords && Module_Unit.RangeToPoint_Horiz(myUnit, thePoint) <= base.myWeapon.get_MaxRangeForThisTarget((ActiveUnit)null, contact, CheckWRA: false, (Doctrine)null, ManualFire: false))
			{
				contact = new AimpointContact(thePoint.Latitude, thePoint.Longitude);
			}
		}
		if (base.myWeapon.method_16())
		{
			double val = Math.Max(base.myWeapon.MinSurfaceRange, base.myWeapon.MinLandRange);
			double num4 = Math.Max(num2 / 6.0, val);
			double num5 = Math.Max(base.myWeapon.RangeToUnit_Horiz(contact) / 10f, val);
			float bearing = Module_Unit.BearingToUnit_True(base.myWeapon, contact);
			if (num5 > num4)
			{
				num5 = num4;
			}
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(base.myWeapon.LaunchPoint.Longitude, base.myWeapon.LaunchPoint.Latitude, ref out_lon, ref out_lat, num5, bearing);
			contact = new AimpointContact(out_lat, out_lon);
			num2 = num4;
		}
		bool high = !base.myWeapon.Flags.DepressedBallisticTrajectory;
		BallisticTrajectory = BallisticTrajectory.Factory(base.myWeapon.LaunchPoint, contact, num2, high, num);
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			base.myWeapon.TimeSinceLaunch = base.myWeapon.TimeSinceLaunch + elapsedTime;
			if (method_11().IsPerformingTerminalManeuvers || method_11().WeaponSensors().Count <= 0)
			{
				goto IL_00bb;
			}
			int num;
			if (!Module_Unit.IsWithinAtmosphere(myUnit))
			{
				num = 1;
			}
			else
			{
				if (!(method_11().RangeToUnit_Horiz(base.myWeapon.AI.PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < Module_Unit.RangeToPoint_Horiz(method_11(), method_11().LaunchPoint)) || !(myUnit.Attitude_Pitch < 0f))
				{
					goto IL_00bb;
				}
				method_11().IsPerformingTerminalManeuvers = true;
				base.myWeapon.Type = Weapon._WeaponType.RV;
				num = 1;
			}
			goto IL_00bc;
			IL_00bc:
			bool flag = (byte)num != 0;
			if (method_11().IsPerformingTerminalManeuvers)
			{
				Move_BoostCoast(elapsedTime, CheckForMinimumSafeHeight, SimplifiedCalcs_DLZ);
				if (!SimplifiedCalcs_DLZ)
				{
					if (base.myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f && flag)
					{
						if (!base.myWeapon.ImpactsOnThisPulse_ActualUnit && !base.myWeapon.ImpactsOnThisPulse_Contact)
						{
							base.myWeapon.EndgameReport.AddEndGameMessage(hit: false, "Has splashed into water");
							Weapon weapon = base.myWeapon;
							double theLat = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
							double theLon = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
							float theAlt = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
							LockRandom theRNG = GameGeneral.GlobalRNG;
							weapon.Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
						}
					}
					else if (base.myWeapon.CurrentAltitude_AGL <= 0f && base.myWeapon.Attitude_Pitch <= 0f && !base.myWeapon.ImpactsOnThisPulse_ActualUnit && !base.myWeapon.ImpactsOnThisPulse_Contact)
					{
						base.myWeapon.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground");
						Weapon weapon2 = base.myWeapon;
						double theLat2 = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
						double theLon2 = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
						float theAlt2 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
						LockRandom theRNG = GameGeneral.GlobalRNG;
						weapon2.Detonate(theLat2, theLon2, theAlt2, ref theRNG, Detonation_AddMessage: true);
					}
					return;
				}
			}
			if (BallisticTrajectory == null)
			{
				method_12();
			}
			BallisticTrajectory.BallisticResult result = BallisticTrajectory.Calculate(base.myWeapon.TimeSinceLaunch);
			myUnit.BallisticMovement(result, elapsedTime, SimplifiedCalcs_DLZ);
			myUnit.updateLastReportedInfo();
			if (!SimplifiedCalcs_DLZ)
			{
				myUnit.Kinematics.ExportLocationEvent();
				if (base.myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && flag)
				{
					if (!base.myWeapon.ImpactsOnThisPulse_ActualUnit && !base.myWeapon.ImpactsOnThisPulse_Contact)
					{
						base.myWeapon.EndgameReport.AddEndGameMessage(hit: false, "Has splashed into water");
						Weapon weapon3 = base.myWeapon;
						double theLat3 = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
						double theLon3 = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
						float theAlt3 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
						LockRandom theRNG = GameGeneral.GlobalRNG;
						weapon3.Detonate(theLat3, theLon3, theAlt3, ref theRNG, Detonation_AddMessage: true);
					}
				}
				else if (base.myWeapon.CurrentAltitude_AGL < 0f && base.myWeapon.Attitude_Pitch <= 0f && !base.myWeapon.ImpactsOnThisPulse_ActualUnit && !base.myWeapon.ImpactsOnThisPulse_Contact)
				{
					base.myWeapon.EndgameReport.AddEndGameMessage(hit: false, "Has smashed into the ground");
					Weapon weapon4 = base.myWeapon;
					double theLat4 = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon4 = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt4 = Math.Max(0, (int)Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
					LockRandom theRNG = GameGeneral.GlobalRNG;
					weapon4.Detonate(theLat4, theLon4, theAlt4, ref theRNG, Detonation_AddMessage: true);
				}
			}
			Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
			return;
			IL_00bb:
			num = 1;
			goto IL_00bc;
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

	static BallisticMissile_Kinematics()
	{
		Class72.smethod_20();
	}
}
