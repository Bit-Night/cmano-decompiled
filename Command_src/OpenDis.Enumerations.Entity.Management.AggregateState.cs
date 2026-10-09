using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum AggregateState : byte
{
	[Description("Other.")]
	Other,
	[Description("Aggregated.")]
	Aggregated,
	[Description("Disaggregated.")]
	Disaggregated,
	[Description("Fully disaggregated.")]
	FullyDisaggregated,
	[Description("Pseudo-disaggregated.")]
	PseudoDisaggregated,
	[Description("Partially-disaggregated.")]
	PartiallyDisaggregated
}
