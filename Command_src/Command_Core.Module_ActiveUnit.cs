using System;
using System.Collections.Generic;
using System.Diagnostics;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_ActiveUnit
{
	private static LockObject lockObject_0;

	static Module_ActiveUnit()
	{
		Class72.smethod_20();
		lockObject_0 = new LockObject();
	}

	public static bool IsVehicleDecoy(this ActiveUnit myUnit)
	{
		if (myUnit.IsWeapon)
		{
			if (((Weapon)myUnit).Type == Weapon._WeaponType.Decoy_Vehicle)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal static bool IsAimpointFacility(this ActiveUnit myUnit)
	{
		int result;
		if (myUnit != null)
		{
			if (myUnit.IsFacility)
			{
				return ((Facility)myUnit).HasAimpoints;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal static bool IsFixedFacility(this ActiveUnit myUnit)
	{
		if (myUnit.IsFacility)
		{
			if (!((Facility)myUnit).RepresentsMobileGroundUnit)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool IsGuidedWeapon(this ActiveUnit myUnit)
	{
		if (!myUnit.IsWeapon)
		{
			return false;
		}
		if (((Weapon)myUnit).Type == Weapon._WeaponType.GuidedWeapon)
		{
			return true;
		}
		return false;
	}

	public static bool HasIncomingGuidedWeapons(this ActiveUnit theUnit, Scenario theScen)
	{
		bool result;
		try
		{
			PooledList<Weapon> guidedWeaponsInAir = theScen.GuidedWeaponsInAir;
			if (guidedWeaponsInAir.Count > 0)
			{
				Weapon[] array = guidedWeaponsInAir.InternalArray();
				int num = guidedWeaponsInAir.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Weapon weapon = array[i];
					if (weapon == null)
					{
						continue;
					}
					Weapon_AI aI = weapon.AI;
					if (aI == null)
					{
						goto IL_0069;
					}
					Contact primaryTarget = aI.PrimaryTarget;
					if (primaryTarget == null || primaryTarget.ActualUnit == null || primaryTarget.ActualUnit != theUnit)
					{
						goto IL_0069;
					}
					result = true;
					goto end_IL_0001;
					IL_0069:
					if (!weapon.IsMIRVedMissile.Value)
					{
						continue;
					}
					Contact[] targets_ReadOnly = aI.Targets_ReadOnly;
					int num2 = 0;
					while (num2 < targets_ReadOnly.Length)
					{
						Contact contact = targets_ReadOnly[num2];
						if (contact.ActualUnit == null || contact.ActualUnit != theUnit)
						{
							num2 = checked(num2 + 1);
							continue;
						}
						result = true;
						goto end_IL_0001;
					}
				}
			}
			if (theScen.NewbornUnits.Count > 0)
			{
				lock (lockObject_0)
				{
					IEnumerator<ActiveUnit> enumerator = theScen.NewbornUnits.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ActiveUnit current = enumerator.Current;
							if (current == null || !current.IsWeapon)
							{
								continue;
							}
							Weapon_AI aI = ((Weapon)current).AI;
							Contact primaryTarget2 = aI.PrimaryTarget;
							if (primaryTarget2 == null || primaryTarget2.ActualUnit == null || primaryTarget2.ActualUnit != theUnit)
							{
								continue;
							}
							result = true;
							goto end_IL_0001;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200273", ex2.Message);
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
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool PlayerIsPlottingCourseForThisUnit(ActiveUnit theAU)
	{
		if (theAU == null)
		{
			goto IL_006a;
		}
		int result;
		if (!theAU.PlayerIsPlottingCourse)
		{
			if (theAU.IsGroup && ((Group)theAU).GroupLead != null && ((Group)theAU).GroupLead.PlayerIsPlottingCourse)
			{
				return true;
			}
			if (theAU.get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				result = 0;
			}
			else
			{
				if (theAU.get_ParentGroup(UsingMissionPlanner: false).PlayerIsPlottingCourse)
				{
					if (theAU.get_ParentGroup(UsingMissionPlanner: false).GroupLead == theAU)
					{
						return true;
					}
					goto IL_006a;
				}
				result = 0;
			}
			goto IL_006b;
		}
		return true;
		IL_006a:
		result = 0;
		goto IL_006b;
		IL_006b:
		return (byte)result != 0;
	}
}
