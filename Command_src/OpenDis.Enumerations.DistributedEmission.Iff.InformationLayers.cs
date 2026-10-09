using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
[Flags]
public enum InformationLayers : byte
{
	[Description("Set bit means 'Present', reset bit means 'Not Present'.")]
	Layer1 = 2,
	[Description("Set bit means 'Present', reset bit means 'Not Present'.")]
	Layer2 = 4
}
