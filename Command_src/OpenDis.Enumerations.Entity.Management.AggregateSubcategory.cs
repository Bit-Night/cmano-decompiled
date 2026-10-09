using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum AggregateSubcategory : byte
{
	[Description("Other.")]
	Other,
	[Description("Cavalry Troop.")]
	CavalryTroop,
	[Description("Armor.")]
	Armor,
	[Description("Infantry.")]
	Infantry,
	[Description("Mechanized Infantry.")]
	MechanizedInfantry,
	[Description("Cavalry.")]
	Cavalry,
	[Description("Armored Cavalry.")]
	ArmoredCavalry,
	[Description("Artillery.")]
	Artillery,
	[Description("Self-propelled Artillery.")]
	SelfPropelledArtillery,
	[Description("Close Air Support.")]
	CloseAirSupport,
	[Description("Engineer.")]
	Engineer,
	[Description("Air Defense Artillery.")]
	AirDefenseArtillery,
	[Description("Anti-tank.")]
	AntiTank,
	[Description("Army Aviation Fixed-wing.")]
	ArmyAviationFixedWing,
	[Description("Army Aviation Rotary-wing.")]
	ArmyAviationRotaryWing,
	[Description("Army Attack Helicopter.")]
	ArmyAttackHelicopter,
	[Description("Air Cavalry.")]
	AirCavalry,
	[Description("Armor Heavy Task Force.")]
	ArmorHeavyTaskForce,
	[Description("Motorized Rifle.")]
	MotorizedRifle,
	[Description("Mechanized Heavy Task Force.")]
	MechanizedHeavyTaskForce,
	[Description("Command Post.")]
	CommandPost,
	[Description("CEWI.")]
	CEWI,
	[Description("Tank only.")]
	TankOnly
}
