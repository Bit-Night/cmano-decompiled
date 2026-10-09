using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum RadarSensor : uint
{
	[Description("Generic.")]
	Generic,
	[Description("Generic GPR.")]
	const_1,
	[Description("GSTAMIDS I.")]
	GSTAMIDSI,
	[Description("GSTAMIDS II.")]
	GSTAMIDSII,
	[Description("HSTAMIDS I.")]
	HSTAMIDSI,
	[Description("HSTAMIDS II.")]
	HSTAMIDSII
}
