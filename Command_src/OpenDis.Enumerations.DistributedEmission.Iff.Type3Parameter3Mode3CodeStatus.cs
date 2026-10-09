using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum Type3Parameter3Mode3CodeStatus : ushort
{
	[Description("Set bit means 'On', reset bit means 'Off'.")]
	Status = 0x2000,
	[Description("Set bit means 'Damage', reset bit means 'No damage'.")]
	Damage = 0x4000,
	[Description("Set bit means 'Malfunction', reset bit means 'No malfunction'.")]
	Malfunction = 0x8000
}
