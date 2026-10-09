using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum DetailedModulationForUnmodulatedModulation : ushort
{
	[Description("Other.")]
	Other,
	[Description("Continuous Wave emission of an unmodulated carrier.")]
	ContinuousWaveEmissionOfAnUnmodulatedCarrier
}
