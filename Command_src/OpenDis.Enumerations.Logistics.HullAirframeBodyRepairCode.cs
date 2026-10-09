using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum HullAirframeBodyRepairCode : ushort
{
	[Description("hull.")]
	Hull = 1000,
	[Description("airframe.")]
	Airframe = 1010,
	[Description("truck body.")]
	TruckBody = 1020,
	[Description("tank body.")]
	TankBody = 1030,
	[Description("trailer body.")]
	TrailerBody = 1040,
	[Description("turret.")]
	Turret = 1050
}
