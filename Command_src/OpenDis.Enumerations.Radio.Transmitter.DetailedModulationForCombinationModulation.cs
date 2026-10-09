using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForCombinationModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("Amplitude-Angle-Pulse.")]
	AmplitudeAnglePulse
}
