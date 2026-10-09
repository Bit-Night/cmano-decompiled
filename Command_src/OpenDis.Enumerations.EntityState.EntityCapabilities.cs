using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState;

[Serializable]
[Flags]
public enum EntityCapabilities : uint
{
	[Description("The Entity is able to supply some type of ammunition in response to an appropriate Service Request PDU.")]
	AmmunitionSupply = 1u,
	[Description("The Entity is able to supply some type of fuel in response to an appropriate Service Request PDU.")]
	FuelSupply = 2u,
	[Description("The Entity is able to provide recovery (e.g. towing) services in response to an appropriate Service Request PDU.")]
	Recovery = 4u,
	[Description("The Entity is able to supply certain repair services in response to an appropriate Service Request PDU.")]
	Repair = 8u,
	[Description("The Entity is Automatic Dependent Surveillance - Broadcast (ADS-B) Capable")]
	ADSB = 0x10u
}
