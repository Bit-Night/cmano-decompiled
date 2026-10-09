using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForAmplitudeModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("AFSK (Audio Frequency Shift Keying).")]
	AFSK,
	[Description("AM (Amplitude Modulation).")]
	AM,
	[Description("CW (Continuous Wave Modulation).")]
	CW,
	[Description("DSB (Double Sideband).")]
	DSB,
	[Description("ISB (Independent Sideband).")]
	ISB,
	[Description("LSB (Single Band Suppressed Carrier, Lower Sideband Mode).")]
	LSB,
	[Description("SSB-Full (Single Sideband Full Carrier).")]
	SSBFull,
	[Description("SSB-Reduc (Single Band Reduced Carrier).")]
	const_8,
	[Description("USB (Single Band Suppressed Carrier, Upper Sideband Mode).")]
	USB,
	[Description("VSB (Vestigial Sideband).")]
	VSB
}
