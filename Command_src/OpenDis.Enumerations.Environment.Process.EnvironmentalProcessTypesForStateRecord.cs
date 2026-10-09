using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Process;

[Serializable]
public enum EnvironmentalProcessTypesForStateRecord : uint
{
	[Description("COMBIC State.")]
	const_0 = 256u,
	[Description("Flare State.")]
	FlareState = 259u
}
