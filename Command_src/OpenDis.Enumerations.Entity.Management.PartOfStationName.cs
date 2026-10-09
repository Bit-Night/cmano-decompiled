using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum PartOfStationName : ushort
{
	[Description("Other.")]
	Other,
	[Description("Aircraft wingstation.")]
	AircraftWingstation,
	[Description("Ship's forward gunmount (starboard).")]
	ShipSForwardGunmountStarboard,
	[Description("Ship's forward gunmount (port).")]
	ShipSForwardGunmountPort,
	[Description("Ship's forward gunmount (centerline).")]
	ShipSForwardGunmountCenterline,
	[Description("Ship's aft gunmount (starboard).")]
	ShipSAftGunmountStarboard,
	[Description("Ship's aft gunmount (port).")]
	const_6,
	[Description("Ship's aft gunmount (centerline).")]
	ShipSAftGunmountCenterline,
	[Description("Forward torpedo tube.")]
	ForwardTorpedoTube,
	[Description("Aft torpedo tube.")]
	AftTorpedoTube,
	[Description("Bomb bay.")]
	BombBay,
	[Description("Cargo bay.")]
	CargoBay,
	[Description("Truck bed.")]
	TruckBed,
	[Description("Trailer bed.")]
	TrailerBed,
	[Description("Well deck.")]
	WellDeck,
	[Description("On station - (RNG/BRG).")]
	OnStationRNGBRG,
	[Description("On station - (x,y,z).")]
	OnStationXYZ
}
