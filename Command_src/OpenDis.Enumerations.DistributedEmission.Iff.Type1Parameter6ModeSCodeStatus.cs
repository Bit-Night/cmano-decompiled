using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum Type1Parameter6ModeSCodeStatus : ushort
{
	[Description("Set bit means 'TCAS II', reset bit means 'TCAS I'.")]
	TCAS = 0x1000,
	[Description("Set bit means 'On', reset bit means 'Off'.")]
	Status = 0x2000,
	[Description("Set bit means 'Damage', reset bit means 'No damage'.")]
	Damage = 0x4000,
	[Description("Set bit means 'Malfunction', reset bit means 'No malfunction'.")]
	Malfunction = 0x8000
}
