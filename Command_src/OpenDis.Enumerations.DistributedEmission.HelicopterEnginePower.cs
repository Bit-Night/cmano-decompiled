using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum HelicopterEnginePower
{
	[Description("Engine Off.")]
	EngineOff = -100,
	[Description("Idle Power.")]
	IdlePower = 0,
	[Description("Max. Power.")]
	MaxPower = 100
}
