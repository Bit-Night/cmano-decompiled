using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum AntennaPatternType : ushort
{
	[Description("Omni-directional.")]
	OmniDirectional,
	[Description("Beam.")]
	Beam,
	[Description("Spherical harmonic.")]
	SphericalHarmonic
}
