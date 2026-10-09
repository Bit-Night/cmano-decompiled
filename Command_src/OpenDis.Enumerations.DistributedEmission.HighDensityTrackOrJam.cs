using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum HighDensityTrackOrJam : byte
{
	[Description("Not Selected.")]
	NotSelected,
	[Description("Selected.")]
	Selected
}
