using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum EventType : uint
{
	[Description("Other.")]
	Other = 0u,
	[Description("Ran out of ammunition.")]
	RanOutOfAmmunition = 2u,
	[Description("Killed in action.")]
	KilledInAction = 3u,
	[Description("Damage.")]
	Damage = 4u,
	[Description("Mobility disabled.")]
	MobilityDisabled = 5u,
	[Description("Fire disabled.")]
	FireDisabled = 6u,
	[Description("Ran out of fuel.")]
	RanOutOfFuel = 7u,
	[Description("Entity initialization.")]
	EntityInitialization = 8u,
	[Description("Request for indirect fire or CAS mission.")]
	RequestForIndirectFireOrCASMission = 9u,
	[Description("Indirect fire or CAS fire.")]
	IndirectFireOrCASFire = 10u,
	[Description("Minefield entry.")]
	MinefieldEntry = 11u,
	[Description("Minefield detonation.")]
	MinefieldDetonation = 12u,
	[Description("Vehicle master power on.")]
	VehicleMasterPowerOn = 13u,
	[Description("Vehicle master power off.")]
	VehicleMasterPowerOff = 14u,
	[Description("Aggregate state change requested.")]
	AggregateStateChangeRequested = 15u,
	[Description("Prevent Collision / Detonation.")]
	PreventCollisionDetonation = 16u
}
