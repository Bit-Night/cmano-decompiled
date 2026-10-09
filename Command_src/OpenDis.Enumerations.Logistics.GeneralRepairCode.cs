using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum GeneralRepairCode : ushort
{
	[Description("no repairs performed.")]
	NoRepairsPerformed,
	[Description("all requested repairs performed.")]
	AllRequestedRepairsPerformed
}
