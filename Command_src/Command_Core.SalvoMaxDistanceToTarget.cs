namespace Command_Core;

internal class SalvoMaxDistanceToTarget
{
	public Weapon Weapon;

	public Contact primaryTarget;

	public double maxDist;

	public SalvoMaxDistanceToTarget(Weapon theWeapon, Contact primaryTarget, double maxDist)
	{
		Weapon = theWeapon;
		this.primaryTarget = primaryTarget;
		this.maxDist = maxDist;
	}

	static SalvoMaxDistanceToTarget()
	{
		Class72.smethod_20();
	}
}
