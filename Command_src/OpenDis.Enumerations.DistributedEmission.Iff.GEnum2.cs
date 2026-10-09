using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum GEnum2 : byte
{
	[Description("Set bit means 'Initial report or change since last report', reset bit means 'No change since last report'.")]
	ChangeIndicator = 1,
	[Description("Set bit means 'Yes', reset bit means 'No'.")]
	AlternateMode4 = 2,
	[Description("Set bit means 'Yes', reset bit means 'No'.")]
	AlternateModeC = 4
}
