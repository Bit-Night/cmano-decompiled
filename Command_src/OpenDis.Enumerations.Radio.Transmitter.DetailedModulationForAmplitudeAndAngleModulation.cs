using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForAmplitudeAndAngleModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("Amplitude and Angle.")]
	AmplitudeAndAngle
}
