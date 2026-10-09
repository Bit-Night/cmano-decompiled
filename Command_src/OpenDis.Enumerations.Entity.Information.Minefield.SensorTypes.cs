using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum SensorTypes : uint
{
	[Description("Other.")]
	Other,
	[Description("Optical.")]
	Optical,
	[Description("FLIR.")]
	FLIR,
	[Description("RADAR.")]
	RADAR,
	[Description("Magnetic.")]
	Magnetic,
	[Description("Laser.")]
	Laser,
	[Description("SONAR.")]
	SONAR,
	[Description("Physical.")]
	Physical,
	[Description("Multispectral.")]
	Multispectral
}
