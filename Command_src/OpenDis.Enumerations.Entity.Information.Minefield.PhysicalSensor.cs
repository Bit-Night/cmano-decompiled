using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum PhysicalSensor : uint
{
	[Description("Generic Probe.")]
	GenericProbe,
	[Description("Probe, metal content.")]
	ProbeMetalContent,
	[Description("Probe, no metal content.")]
	ProbeNoMetalContent
}
