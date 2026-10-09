using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum Type1Modifier : byte
{
	[Description("Value of 0")]
	Other = 1,
	[Description("Set bit means 'On', reset bit means 'Off'.")]
	Emergency = 2,
	[Description("Set bit means 'On', reset bit means 'Off'.")]
	IdentSquawkFlash = 4,
	[Description("Set bit means 'Damage', reset bit means 'No damage'.")]
	STI = 8
}
