using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum SpacePlatform : byte
{
	[Description("Other.")]
	Other,
	[Description("Manned.")]
	Manned,
	[Description("Unmanned.")]
	Unmanned,
	[Description("Booster.")]
	Booster
}
