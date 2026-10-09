using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum AircraftEnginePower
{
	[Description("Engine Off.")]
	EngineOff = -100,
	[Description("Idle Power.")]
	IdlePower = 0,
	[Description("Mil. Power.")]
	MilPower = 50,
	[Description("Min. A/B.")]
	MinAB = 51,
	[Description("Max. A/B.")]
	MaxAB = 100
}
