using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
[Flags]
public enum SpreadSpectrum : ushort
{
	[Description("Frequency Hopping")]
	FrequencyHopping = 1,
	[Description("Pseudo-noise")]
	PseudoNoise = 2,
	[Description("Time Hopping")]
	TimeHopping = 4
}
