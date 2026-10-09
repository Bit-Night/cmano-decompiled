using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum GermanWeaponsForLifeForms : byte
{
	[Description("G3 rifle.")]
	G3Rifle = 1,
	[Description("G11 rifle.")]
	G11Rifle,
	[Description("P1 pistol.")]
	P1Pistol,
	[Description("MG3 machine gun.")]
	MG3MachineGun,
	[Description("Milan missile.")]
	MilanMissile,
	[Description("MP1 Uzi submachine gun.")]
	const_5,
	[Description("Panzerfaust 3 Light Anti-Tank Weapon.")]
	Panzerfaust3LightAntiTankWeapon,
	[Description("DM19 hand grenade.")]
	DM19HandGrenade,
	[Description("DM29 hand grenade.")]
	DM29HandGrenade
}
