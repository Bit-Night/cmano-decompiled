using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public enum SystemType : ushort
{
	[Description("Other.")]
	Other,
	[Description("Mark X/XII/ATCRBS/Mode S Transponder.")]
	MarkXXIIATCRBSModeSTransponder,
	[Description("Mark X/XII/ATCRBS/Mode S Interrogator.")]
	MarkXXIIATCRBSModeSInterrogator,
	[Description("Soviet Transponder.")]
	SovietTransponder,
	[Description("Soviet Interrogator.")]
	SovietInterrogator,
	[Description("RRB Transponder.")]
	RRBTransponder
}
