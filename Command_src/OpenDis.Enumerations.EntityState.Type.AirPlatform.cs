using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum AirPlatform : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Fighter/Air Defense.")]
	FighterAirDefense = 1,
	[Description("Attack/Strike.")]
	AttackStrike = 2,
	[Description("Bomber.")]
	Bomber = 3,
	[Description("Cargo/Tanker.")]
	CargoTanker = 4,
	[Description("ASW/Patrol/Observation.")]
	const_5 = 5,
	[Description("Electronic Warfare (EW).")]
	ElectronicWarfare = 6,
	[Description("Reconnaissance.")]
	Reconnaissance = 7,
	[Description("Surveillance/C2 (Airborne Early Warning).")]
	SurveillanceC2AirborneEarlyWarning = 8,
	[Description("Attack Helicopter.")]
	AttackHelicopter = 20,
	[Description("Utility Helicopter.")]
	UtilityHelicopter = 21,
	[Description("Antisubmarine Warfare/Patrol Helicopter.")]
	AntisubmarineWarfarePatrolHelicopter = 22,
	[Description("Cargo Helicopter.")]
	CargoHelicopter = 23,
	[Description("Observation Helicopter.")]
	ObservationHelicopter = 24,
	[Description("Special Operations Helicopter.")]
	SpecialOperationsHelicopter = 25,
	[Description("Trainer.")]
	Trainer = 40,
	[Description("Unmanned.")]
	Unmanned = 50,
	[Description("Non-Combatant Commercial Aircraft.")]
	NonCombatantCommercialAircraft = 57
}
