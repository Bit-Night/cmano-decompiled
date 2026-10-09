using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnguidedRocket_Kinematics : Weapon_Kinematics
{
	private float? nullable_1;

	private bool? nullable_2;

	public UnguidedRocket_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override float PitchRate_Negative()
	{
		return 1f;
	}

	public override float PitchRate_Positive()
	{
		return 1f;
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

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		return (int)Math.Round(UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_11()) * 1.94384);
	}

	public override float GetMaximumAltitude()
	{
		if (!nullable_1.HasValue)
		{
			float value = (float)(Math.Pow(UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_11()), 2.0) * Math.Pow(Math.Sin(1.570796326794897), 2.0) / 19.62);
			nullable_1 = value;
		}
		return nullable_1.Value;
	}

	public override float GetMinimumAltitude()
	{
		return 0f;
	}

	[SpecialName]
	private bool method_11()
	{
		bool result;
		try
		{
			if (nullable_2.HasValue)
			{
				goto IL_0073;
			}
			if (base.myWeapon.AI.PrimaryTarget != null)
			{
				nullable_2 = !base.myWeapon.WasAirLaunched() && !base.myWeapon.AI.PrimaryTarget.IsAircraftContact && !base.myWeapon.AI.PrimaryTarget.IsWeaponContact;
				goto IL_0073;
			}
			result = false;
			goto end_IL_0001;
			IL_0073:
			result = nullable_2.Value;
			end_IL_0001:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
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

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		double lat = base.myWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
		double lon = base.myWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
		Contact primaryTarget = base.myWeapon.AI.PrimaryTarget;
		double num;
		double num2;
		float num3;
		double num4;
		if (primaryTarget == null)
		{
			num = base.myWeapon.AI.PrimaryTarget_LastKnown_Lat;
			num2 = base.myWeapon.AI.PrimaryTarget_LastKnown_Lon;
			num3 = base.myWeapon.AI.PrimaryTarget_LastKnown_Altitude;
			num4 = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_11());
		}
		else
		{
			num = ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
			num2 = ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
			num3 = ((Module_Unit.Unit)primaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			num4 = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(primaryTarget.Type, base.myWeapon.MaxRange_NoTargetType, method_11());
		}
		double num5 = base.myWeapon.LaunchPoint.RangeToPoint_Horiz(num2, num);
		if (!method_11())
		{
			base.myWeapon.ActualHorizMovement(elapsedTime, SimplifiedCalcs_DLZ: false);
			float num6 = Math.Abs(base.myWeapon.LaunchPoint.Altitude - num3);
			double num7 = (double)Module_Unit.RangeToPoint_Horiz(base.myWeapon, num, num2) / num5;
			if (num7 > 1.0)
			{
				num7 = 0.99999;
			}
			if (num3 > base.myWeapon.LaunchPoint.Altitude)
			{
				base.myWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)num3 - (double)num6 * num7));
			}
			else
			{
				base.myWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)num3 + (double)num6 * num7));
			}
		}
		else
		{
			double num8 = num5 * 1852.0;
			ActiveUnit firingParent = base.myWeapon.FiringParent;
			double num9 = (((firingParent != null && firingParent.IsAerospaceUnit) || base.myWeapon.WasAirLaunched()) ? Math.Atan((Math.Pow(num4, 2.0) - Math.Sqrt(Math.Pow(num4, 4.0) - 9.81 * (9.81 * Math.Pow(num8, 2.0) + (double)(2f * (num3 - base.myWeapon.LaunchPoint.Altitude)) * Math.Pow(num4, 2.0)))) / (9.81 * num8)) : Math.Atan((Math.Pow(num4, 2.0) + Math.Sqrt(Math.Pow(num4, 4.0) - 9.81 * (9.81 * Math.Pow(num8, 2.0) + (double)(2f * (num3 - base.myWeapon.LaunchPoint.Altitude)) * Math.Pow(num4, 2.0)))) / (9.81 * num8)));
			num9 = Math.Abs(num9 * (180.0 / Math.PI));
			if (double.IsNaN(num9))
			{
				_ = Debugger.IsAttached;
				num9 = 45.0;
			}
			double num10 = Math.Pow(num4, 2.0) * Math.Pow(Math2.Sind(num9), 2.0) / 19.62;
			double num11 = num4 * 1.94384 * Math2.Cosd(num9);
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, num11 * (double)elapsedTime / 3600.0, base.myWeapon.CurrentHeading);
			base.myWeapon.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			base.myWeapon.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			double num12 = num5 * 0.5 * 1852.0;
			double num13 = num10 / Math.Pow(num12, 2.0);
			double x = Math.Abs((double)(Module_Unit.RangeToPoint_Horiz(base.myWeapon, base.myWeapon.LaunchPoint) * 1852f) - num12);
			double num14 = 0.0 - num13 * Math.Pow(x, 2.0) + num10;
			base.myWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, Math.Max(1f, (float)(num14 + (double)base.myWeapon.LaunchPoint.Altitude)));
		}
		TurnToDesiredHeading(elapsedTime);
		double num15 = Module_Unit.RangeToPoint_Slant(base.myWeapon, base.myWeapon.LaunchPoint) / base.myWeapon.MaxRange_NoTargetType;
		double num16 = num4 * 1.94384;
		base.myWeapon.CurrentSpeed = (float)(num16 * (0.34 + 0.67 * (1.0 - num15)));
		if (!SimplifiedCalcs_DLZ)
		{
			myUnit.Kinematics.ExportLocationEvent();
		}
		Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
	}

	static UnguidedRocket_Kinematics()
	{
		Class72.smethod_20();
	}
}
