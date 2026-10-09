using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Satellite_Damage : ActiveUnit_Damage
{
	private Satellite satellite_0;

	[SpecialName]
	private Satellite method_6()
	{
		if (Information.IsNothing((object)satellite_0))
		{
			satellite_0 = (Satellite)myUnit;
		}
		return satellite_0;
	}

	public Satellite_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	protected override void ResolveDamageFromDirectImpact(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ref ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, UnguidedWeapon theUnguidedWeapon)
	{
		if (theWeapon.Type == Weapon._WeaponType.LaserDazzler)
		{
			double num = Module_Unit.RangeToPoint_Slant(myUnit, LaunchPoint) / theWeapon.MaxRange_NoTargetType;
			double num2 = 1.0 - num;
			ResolveDamageFromDazzler((float)num2);
		}
		else
		{
			myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, -1f);
			myUnit.ParentScen.DestroyThisUnit(myUnit, "Direct impact. Satellite destroyed.", "Weapon Interaction");
		}
	}

	static Satellite_Damage()
	{
		Class72.smethod_20();
	}
}
