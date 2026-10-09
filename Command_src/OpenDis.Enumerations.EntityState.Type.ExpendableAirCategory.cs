using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum ExpendableAirCategory : byte
{
	[Description("Other.")]
	Other,
	[Description("Chaff.")]
	Chaff,
	[Description("Flare.")]
	Flare,
	[Description("Combined chaff and flare.")]
	CombinedChaffAndFlare,
	[Description("Active emitter.")]
	ActiveEmitter,
	[Description("Passive decoy.")]
	PassiveDecoy,
	[Description("Winged decoy.")]
	WingedDecoy
}
