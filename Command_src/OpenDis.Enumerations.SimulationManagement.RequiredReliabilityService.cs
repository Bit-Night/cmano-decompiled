using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum RequiredReliabilityService : byte
{
	[Description("Acknowledged.")]
	Acknowledged,
	[Description("Unacknowledged.")]
	Unacknowledged
}
