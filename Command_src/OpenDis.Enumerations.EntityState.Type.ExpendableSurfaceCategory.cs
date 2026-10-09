using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum ExpendableSurfaceCategory : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Flare.")]
	Flare = 2,
	[Description("Active emitter.")]
	ActiveEmitter = 4,
	[Description("Passive decoy.")]
	PassiveDecoy = 5
}
