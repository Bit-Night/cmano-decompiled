using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Command_Core;

public class AggregateGroundUnit_Damage : ActiveUnit_Damage
{
	private AggregateGroundUnit aggregateGroundUnit_0;

	public AggregateGroundUnit_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	[SpecialName]
	private AggregateGroundUnit method_6()
	{
		if (Information.IsNothing((object)aggregateGroundUnit_0))
		{
			aggregateGroundUnit_0 = (AggregateGroundUnit)myUnit;
		}
		return aggregateGroundUnit_0;
	}

	protected override void ResolveDamageFromDirectImpact(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ref ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, UnguidedWeapon theUnguidedWeapon)
	{
		method_6().ResolveAGUDamages(theWeapon.GetCombatPowerMatrix(), 1f, 1f);
	}

	static AggregateGroundUnit_Damage()
	{
		Class72.smethod_20();
	}
}
