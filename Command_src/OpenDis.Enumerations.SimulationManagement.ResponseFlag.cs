using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum ResponseFlag : ushort
{
	[Description("Other.")]
	Other,
	[Description("Able to comply.")]
	AbleToComply,
	[Description("Unable to comply.")]
	UnableToComply
}
