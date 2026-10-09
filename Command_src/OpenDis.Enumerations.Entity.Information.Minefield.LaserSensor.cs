using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum LaserSensor : uint
{
	[Description("Generic.")]
	Generic,
	[Description("ASTAMIDS.")]
	ASTAMIDS
}
