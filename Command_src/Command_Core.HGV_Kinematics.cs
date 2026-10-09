using System;

namespace Command_Core;

public sealed class HGV_Kinematics : Weapon_Kinematics
{
	private Geopoint_Struct? nullable_1;

	private double double_1;

	private float float_3;

	public HGV_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		nullable_1 = null;
		double_1 = 0.0;
		float_3 = 0f;
	}

	public override float PitchRate_Negative()
	{
		return 4f;
	}

	public override float PitchRate_Positive()
	{
		return 2f;
	}

	public override float RollRate()
	{
		return 25f;
	}

	public override float TurnRate()
	{
		float num = Physics.ComputeMach(base.myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), base.myWeapon.CurrentSpeed);
		if (num > 8f)
		{
			return 2f;
		}
		if (num > 7f)
		{
			return 3f;
		}
		if (num > 6f)
		{
			return 4f;
		}
		if (num > 5f)
		{
			return 5f;
		}
		if (num > 4f)
		{
			return 6f;
		}
		if (num > 3f)
		{
			return 7f;
		}
		if (num > 2f)
		{
			return 8f;
		}
		if (num > 1f)
		{
			return 9f;
		}
		return 10f;
	}

	public override void ChangeAltitude(float elapsedTime, float theDesiredAlt, float? MinimumSafeAltitude, bool DoSanityCheck)
	{
		myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if (myUnit.Attitude_Pitch != 0f)
		{
			double num = Math2.Sind(myUnit.Attitude_Pitch) * (double)myUnit.CurrentSpeed * 0.514444 * (double)elapsedTime;
			myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) += (float)num;
		}
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		base.myWeapon.TimeSinceLaunch = base.myWeapon.TimeSinceLaunch + elapsedTime;
		float num4;
		double num6;
		bool flag;
		if (Module_Unit.IsWithinAtmosphere(myUnit))
		{
			if (!nullable_1.HasValue)
			{
				nullable_1 = myUnit.Location;
				double_1 = Module_Unit.RangeToPoint_Slant_OnSphericalEarth(myUnit, base.myWeapon.LaunchPoint.Latitude, base.myWeapon.LaunchPoint.Longitude, base.myWeapon.LaunchPoint.Altitude);
				float_3 = base.myWeapon.TimeSinceLaunch;
			}
			if (base.myWeapon.IsWeaponPallet & (base.myWeapon.Attitude_Pitch == base.myWeapon.DesiredPitch))
			{
				base.myWeapon.Kinematics.Loiter(elapsedTime);
			}
			if (!SimplifiedCalcs_DLZ)
			{
				_ = base.myWeapon.CurrentAltitude_AGL;
			}
			if (base.myWeapon.SupportsAttitude_Pitch)
			{
				AdjustAttitude_Pitch(elapsedTime);
			}
			if (myUnit.DesiredSpeed < 0f)
			{
				myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
			}
			ChangeAltitude(elapsedTime, myUnit.DesiredAltitude, null, DoSanityCheck: false);
			float num = GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false, ConsiderDamage: false);
			int maximumSpeed_Total = base.myWeapon.Kinematics.GetMaximumSpeed_Total();
			double num2 = (double)base.myWeapon.MaxRange_NoTargetType - double_1;
			float num3 = Module_Unit.RangeToPoint_Slant_OnSphericalEarth(myUnit, nullable_1.Value.Latitude, nullable_1.Value.Longitude, nullable_1.Value.Altitude);
			num4 = (float)(661.0 + (double)(maximumSpeed_Total - 661) * (1.0 - (double)num3 / num2));
			if (num < myUnit.CurrentSpeed)
			{
				num4 = num;
			}
			myUnit.DesiredSpeed = num4;
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
						myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
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
			num6 = (double)Math.Abs(MathFunctions.AngularDifference((float)num5, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
			CalcTurnDeceleration(num6, elapsedTime);
			flag = false;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
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
						goto IL_0575;
					}
					num7 = 1;
				}
				flag = (byte)num7 != 0;
			}
			goto IL_0575;
		}
		SimpleBallisticFlight_Vaccum(elapsedTime, myUnit.Attitude_Pitch, SimplifiedCalcs_DLZ);
		myUnit.updateLastReportedInfo();
		if (!SimplifiedCalcs_DLZ)
		{
			myUnit.Kinematics.ExportLocationEvent();
		}
		nullable_1 = null;
		goto IL_05fd;
		IL_0575:
		if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
		{
			GoToDesiredSpeed(elapsedTime, (float)num6, num4);
		}
		myUnit.updateLastReportedInfo();
		if (!SimplifiedCalcs_DLZ)
		{
			myUnit.Kinematics.ExportLocationEvent();
		}
		goto IL_05fd;
		IL_05fd:
		Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
	}

	static HGV_Kinematics()
	{
		Class72.smethod_20();
	}
}
