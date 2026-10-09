using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum AggregateSpecific : byte
{
	[Description("No headquarters.")]
	NoHeadquarters,
	[Description("Yes aggregate unit contains a headquarters.")]
	YesAggregateUnitContainsAHeadquarters
}
