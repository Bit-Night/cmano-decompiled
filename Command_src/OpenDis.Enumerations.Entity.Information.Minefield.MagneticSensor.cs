using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum MagneticSensor : uint
{
	[Description("Generic.")]
	Generic,
	[Description("AN-PSS-11.")]
	ANPSS11,
	[Description("AN-PSS-12.")]
	ANPSS12,
	[Description("GSTAMIDS.")]
	GSTAMIDS
}
