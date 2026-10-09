using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public enum SystemName : ushort
{
	[Description("Other.")]
	Other,
	[Description("Mark X.  applies-to: 1,2.")]
	MarkXAppliesTo12,
	[Description("Mark XII.  applies-to: 1,2.")]
	const_2,
	[Description("ATCRBS.  applies-to: 2.")]
	ATCRBSAppliesTo2,
	[Description("Soviet.  applies-to: 3,4.")]
	SovietAppliesTo34,
	[Description("Mode S.  applies-to: 1,2.")]
	ModeSAppliesTo12,
	[Description("Mark X/XII/ATCRBS.  applies-to: 1,2.")]
	MarkXXIIATCRBSAppliesTo12,
	[Description("Mark X/XII/ATCRBS/Mode S.  applies-to: 1,2.")]
	MarkXXIIATCRBSModeSAppliesTo12,
	[Description("ARI 5954.  applies-to: 5.")]
	ARI5954AppliesTo5,
	[Description("ARI 5983.  applies-to: 5.")]
	ARI5983AppliesTo5
}
