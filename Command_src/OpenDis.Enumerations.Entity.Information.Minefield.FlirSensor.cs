using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum FlirSensor : uint
{
	[Description("Generic 3-5.")]
	const_0,
	[Description("Generic 8-12.")]
	const_1,
	[Description("ASTAMIDS I.")]
	ASTAMIDSI,
	[Description("ASTAMIDS II.")]
	ASTAMIDSII,
	[Description("GSTAMIDS 3-5.")]
	const_4,
	[Description("GSTAMIDS 8-12.")]
	const_5,
	[Description("HSTAMIDS 3-5.")]
	const_6,
	[Description("HSTAMIDS 8-12.")]
	const_7,
	[Description("COBRA 3-5.")]
	COBRA35,
	[Description("COBRA 8-12.")]
	COBRA812
}
