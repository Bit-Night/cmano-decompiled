using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum GroupOfGroupedEntityCategory : byte
{
	[Description("Undefined.")]
	Undefined,
	[Description("Basic Ground Combat Vehicle.")]
	BasicGroundCombatVehicle,
	[Description("Enhanced Ground Combat Vehicle.")]
	EnhancedGroundCombatVehicle,
	[Description("Basic Ground Combat Soldier.")]
	BasicGroundCombatSoldier,
	[Description("Enhanced Ground Combat Soldier.")]
	EnhancedGroundCombatSoldier,
	[Description("Basic Rotor Wing Aircraft.")]
	BasicRotorWingAircraft,
	[Description("Enhanced Rotor Wing Aircraft.")]
	EnhancedRotorWingAircraft,
	[Description("Basic Fixed Wing Aircraft.")]
	BasicFixedWingAircraft,
	[Description("Enhanced Fixed Wing Aircraft.")]
	EnhancedFixedWingAircraft,
	[Description("Ground Logistics Vehicle.")]
	GroundLogisticsVehicle
}
