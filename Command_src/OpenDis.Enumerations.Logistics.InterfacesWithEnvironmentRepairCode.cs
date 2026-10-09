using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum InterfacesWithEnvironmentRepairCode : ushort
{
	[Description("propeller.")]
	Propeller = 1500,
	[Description("filters.")]
	Filters = 1520,
	[Description("wheels.")]
	Wheels = 1540,
	[Description("tire.")]
	Tire = 1550,
	[Description("track.")]
	Track = 1560
}
