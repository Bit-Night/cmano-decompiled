using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum FuelSystemRepairCode : ushort
{
	[Description("fuel transfer pump.")]
	FuelTransferPump = 4000,
	[Description("fuel lines.")]
	FuelLines = 4010,
	[Description("gauges.")]
	Gauges = 4020,
	[Description("general fuel system.")]
	GeneralFuelSystem = 4030
}
