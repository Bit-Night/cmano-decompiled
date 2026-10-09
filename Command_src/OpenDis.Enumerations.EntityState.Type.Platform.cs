using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum Platform : byte
{
	[Description("Other.")]
	Other,
	[Description("Land.")]
	Land,
	[Description("Air.")]
	Air,
	[Description("Surface.")]
	Surface,
	[Description("Subsurface.")]
	Subsurface,
	[Description("Space.")]
	Space
}
