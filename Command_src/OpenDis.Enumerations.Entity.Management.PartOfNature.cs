using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum PartOfNature : ushort
{
	[Description("Other.")]
	Other,
	[Description("Host-fireable munition.")]
	HostFireableMunition,
	[Description("Munition carried as cargo.")]
	MunitionCarriedAsCargo,
	[Description("Fuel carried as cargo.")]
	FuelCarriedAsCargo,
	[Description("Gunmount attached to host.")]
	GunmountAttachedToHost,
	[Description("Computer generated forces carried as cargo.")]
	ComputerGeneratedForcesCarriedAsCargo,
	[Description("Vehicle carried as cargo.")]
	VehicleCarriedAsCargo,
	[Description("Emitter mounted on host.")]
	EmitterMountedOnHost,
	[Description("Mobile command and control entity carried aboard host.")]
	MobileCommandAndControlEntityCarriedAboardHost,
	[Description("Entity stationed at position with respect to host.")]
	EntityStationedAtPositionWithRespectToHost,
	[Description("Team member in formation with.")]
	TeamMemberInFormationWith
}
