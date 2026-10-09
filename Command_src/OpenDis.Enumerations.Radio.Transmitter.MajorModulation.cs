using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum MajorModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("Amplitude.")]
	Amplitude,
	[Description("Amplitude and Angle.")]
	AmplitudeAndAngle,
	[Description("Angle.")]
	Angle,
	[Description("Combination.")]
	Combination,
	[Description("Pulse.")]
	Pulse,
	[Description("Unmodulated.")]
	Unmodulated,
	[Description("Carrier Phase Shift Modulation (CPSM).")]
	CarrierPhaseShiftModulationCPSM
}
