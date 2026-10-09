using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForAngleModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("FM (Frequency Modulation).")]
	AFSK,
	[Description("FSK (Frequency Shift Keying).")]
	AM,
	[Description("PM (Phase Modulation).")]
	CW
}
