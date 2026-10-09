using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum SystemStatus : byte
{
	[Description("Set bit means 'On', reset bit means 'Off'.")]
	SystemOnOff = 1,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter1 = 2,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter2 = 4,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter3 = 8,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter4 = 0x10,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter5 = 0x20,
	[Description("Set bit means 'Not capable', reset bit means 'Capable'.")]
	Parameter6 = 0x40,
	[Description("Set bit means 'System failed', reset bit means 'Operational'.")]
	OperationalStatus = 0x80
}
