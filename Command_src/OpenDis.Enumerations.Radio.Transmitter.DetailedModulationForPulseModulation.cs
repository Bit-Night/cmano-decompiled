using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForPulseModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("Pulse.")]
	Pulse,
	[Description("X Band TACAN Pulse.")]
	XBandTACANPulse,
	[Description("Y Band TACAN Pulse.")]
	YBandTACANPulse
}
