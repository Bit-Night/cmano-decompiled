using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum Munition : byte
{
	[Description("Other.")]
	Other,
	[Description("Anti-Air.")]
	AntiAir,
	[Description("Anti-Armor.")]
	AntiArmor,
	[Description("Anti-Guided Weapon.")]
	AntiGuidedWeapon,
	[Description("Antiradar.")]
	Antiradar,
	[Description("Antisatellite.")]
	Antisatellite,
	[Description("Antiship.")]
	Antiship,
	[Description("Antisubmarine.")]
	Antisubmarine,
	[Description("Antipersonnel.")]
	Antipersonnel,
	[Description("Battlefield Support.")]
	BattlefieldSupport,
	[Description("Strategic.")]
	Strategic,
	[Description("Tactical.")]
	Tactical,
	[Description("Directed Energy (DE) Weapon.")]
	DirectedEnergyDEWeapon
}
