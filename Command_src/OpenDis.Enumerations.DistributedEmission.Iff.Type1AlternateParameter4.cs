using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public enum Type1AlternateParameter4 : byte
{
	[Description("Other.")]
	Other,
	[Description("Valid.")]
	Valid,
	[Description("Invalid.")]
	Invalid,
	[Description("No response.")]
	NoResponse
}
