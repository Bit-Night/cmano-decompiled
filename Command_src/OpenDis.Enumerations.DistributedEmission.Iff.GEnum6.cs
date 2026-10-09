using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum GEnum6 : byte
{
	[Description("Set bit means 'Initial report or change since last report', reset bit means 'No change since last report'.")]
	ChangeIndicator = 1
}
