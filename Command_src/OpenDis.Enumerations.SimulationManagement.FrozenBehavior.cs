using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
[Flags]
public enum FrozenBehavior : byte
{
	[Description("Run internal simulation clock.")]
	SimulationClock = 1,
	[Description("Transmit PDUs.")]
	TransmitPDUs = 2,
	[Description("Update simulation models of other entities via received PDUs.")]
	flag_2 = 4
}
