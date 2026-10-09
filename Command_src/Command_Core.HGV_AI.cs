using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class HGV_AI : Weapon_AI
{
	private bool bool_1;

	public bool NearOrInTerminalDive
	{
		get
		{
			if (bool_1)
			{
				return true;
			}
			return base.TerminalDive;
		}
	}

	public HGV_AI(Weapon theUnit)
		: base(theUnit)
	{
		bool_1 = false;
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			_ = myUnit.CurrentHeading;
			float num = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			if (myUnit.CurrentHeading != num)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
				if (315f > relativeBearing && relativeBearing > 45f && myUnit.CurrentSpeed > PrimaryTarget.CurrentSpeed)
				{
					Manouver_PurePursuit(elapsedTime, 0f, 0f);
					return;
				}
				if (PrimaryTarget.CurrentSpeed == 0f)
				{
					Manouver_PurePursuit(elapsedTime, 0f, 0f);
					return;
				}
				float? estimatedAverageSpeed = myUnit.CurrentSpeed;
				bool AllowAfterburner = false;
				Manouver_InterceptCourse(elapsedTime, estimatedAverageSpeed, ref AllowAfterburner);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100969", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(float float_2)
	{
		Weapon weapon = (Weapon)myUnit;
		if (weapon.Navigator.HasPlottedCourse())
		{
			Waypoint? waypoint = weapon.Navigator.PlottedCourse.FirstOrDefault();
			if (waypoint != null && waypoint.Type == Waypoint.WaypointType.TerminalPoint)
			{
				float num;
				float num2;
				if (weapon.AI.PrimaryTarget == null)
				{
					Waypoint waypoint2 = weapon.Navigator.PlottedCourse[0];
					num = Module_Unit.RangeToPoint_Horiz(weapon, waypoint2);
					num2 = Module_Unit.ClosureSpeed(myUnit, waypoint2.Latitude, waypoint2.Longitude, 0f, 0f, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
				}
				else
				{
					num = weapon.RangeToUnit_Horiz(myUnit.AI.PrimaryTarget);
					num2 = Module_Unit.ClosureSpeed(myUnit, myUnit.AI.PrimaryTarget, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
				}
				float num3 = num2 / 3600f * float_2;
				float num4 = (float)((double)weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 0.000539957);
				if (weapon.HasTerminalGuidance)
				{
					float terminalSensorMaxRange = weapon.Sensory.TerminalSensorMaxRange;
					if (terminalSensorMaxRange == -1f)
					{
						weapon.Sensory.TerminalSensorMaxRange = weapon.Sensory.GetTerminalSensorMaxRange();
						terminalSensorMaxRange = weapon.Sensory.TerminalSensorMaxRange;
					}
					if (terminalSensorMaxRange > num4)
					{
						num4 = terminalSensorMaxRange;
					}
				}
				if (num - num3 < num4 * 2f)
				{
					bool_1 = true;
				}
				if (!base.TerminalDive && num > num4 * 2f)
				{
					weapon.DesiredAltitude = (float)((double)weapon.CruiseAltitude_ASL * 0.8);
					double num5 = (0.0 - Math.Atan2(weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - weapon.DesiredAltitude, (double)num * 1852.0)) * 57.2957795130823;
					weapon.DesiredPitch = (float)num5;
					if (weapon.DesiredPitch > 10f)
					{
						weapon.DesiredPitch = 10f;
					}
				}
				else if (PrimaryTarget == null)
				{
					weapon.DesiredPitch = -2f;
				}
				else
				{
					weapon.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					num2 = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
					bool_1 = false;
					weapon.AI.PerformTerminalDive(weapon.DesiredAltitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), float_2, num2);
				}
				return;
			}
		}
		if (PrimaryTarget != null)
		{
			float num6 = (float)((double)weapon.RangeToUnit_Horiz(PrimaryTarget) * 1852.0);
			if ((base.TerminalDive || !(num6 > weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) && PrimaryTarget != null)
			{
				weapon.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				base.TerminalDive = true;
			}
			else
			{
				weapon.DesiredAltitude = (float)((double)weapon.CruiseAltitude_ASL * 0.8);
			}
			double num7 = (0.0 - Math.Atan2(weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - weapon.DesiredAltitude, num6)) * 57.2957795130823;
			weapon.DesiredPitch = (float)num7;
		}
		else
		{
			weapon.DesiredPitch = -2f;
		}
	}

	private void method_19(float float_2)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		double num = (double)myUnit.RangeToUnit_Horiz(PrimaryTarget) * 1852.0;
		Weapon weapon = (Weapon)myUnit;
		if (num > (double)(2f * weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
		{
			weapon.DesiredAltitude = weapon.CruiseAltitude_ASL;
			if (weapon.DesiredPitch > -30f)
			{
				weapon.DesiredPitch = -30f;
			}
		}
	}

	private void method_20(float float_2)
	{
		try
		{
			DetermineDesiredImpactAltitude();
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				bool ForceWaypointSwitch = false;
				bool ForceStationAbort = false;
				navigator.CheckIfReachedWaypoint_AND_Apply_WP_logic(float_2, ref ForceWaypointSwitch, ref ForceStationAbort);
			}
			Weapon weapon = (Weapon)myUnit;
			if (Module_Unit.IsWithinAtmosphere(weapon))
			{
				if (weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > weapon.CruiseAltitude_ASL)
				{
					method_19(float_2);
				}
				else
				{
					method_18(float_2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100319757711", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(float float_2, float float_3)
	{
		if (!base.TerminalDive)
		{
			base.TerminalDive = true;
		}
		if (float_2 < 0f)
		{
			if (Math.Abs(float_2) > myUnit.Kinematics.DiveRate_Nominal())
			{
				myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - float_3 * myUnit.Kinematics.DiveRate_Nominal();
			}
			else
			{
				myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
		}
		else if (Math.Abs(float_2) > myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true))
		{
			myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + float_3 * myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
		}
		else
		{
			myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		Weapon theWeapon = (Weapon)myUnit;
		try
		{
			if (!theWeapon.IsDLZconstruct && !PrimaryTargetLocated(ref theWeapon))
			{
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
			}
			else
			{
				ManouverTowardsTarget(elapsedTime);
			}
			method_20(elapsedTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100970", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static HGV_AI()
	{
		Class72.smethod_20();
	}
}
