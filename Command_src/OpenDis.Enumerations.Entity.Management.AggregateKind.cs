using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum AggregateKind : byte
{
	[Description("Other.")]
	Other,
	[Description("Military Hierarchy.")]
	MilitaryHierarchy,
	[Description("Common Type.")]
	CommonType,
	[Description("Common Mission.")]
	CommonMission,
	[Description("Similar Capabilities.")]
	SimilarCapabilities,
	[Description("Common Location.")]
	CommonLocation
}
