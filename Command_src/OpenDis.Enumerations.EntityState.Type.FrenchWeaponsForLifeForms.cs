using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum FrenchWeaponsForLifeForms : byte
{
	[Description("ACL-STRIM.")]
	ACLSTRIM = 1,
	[Description("Mistral missile.")]
	MistralMissile,
	[Description("Milan AT missile.")]
	MilanATMissile,
	[Description("LRAC F1 89-mm AT rocket launcher.")]
	LRACF189MmATRocketLauncher,
	[Description("FA-MAS rifle.")]
	const_4,
	[Description("AA-52 machine gun.")]
	AA52MachineGun,
	[Description("58-mm rifle grenade.")]
	_58MmRifleGrenade,
	[Description("FR-F1 sniper rifle.")]
	FRF1SniperRifle
}
