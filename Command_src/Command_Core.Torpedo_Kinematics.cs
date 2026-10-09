namespace Command_Core;

public sealed class Torpedo_Kinematics : Weapon_Kinematics
{
	public Torpedo_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Torpedo_Kinematics()
	{
		Class72.smethod_20();
	}
}
