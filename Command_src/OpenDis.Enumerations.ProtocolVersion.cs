using System;
using System.ComponentModel;

namespace OpenDis.Enumerations;

[Serializable]
public enum ProtocolVersion : byte
{
	[Description("Other.")]
	Other,
	[Description("DIS PDU version 1.0 (May 92).")]
	Version1,
	[Description("IEEE 1278-1993.")]
	Ieee1278_1993,
	[Description("DIS PDU version 2.0 - third draft (May 93).")]
	const_3,
	[Description("DIS PDU version 2.0 - fourth draft (revised) March 16, 1994.")]
	Version2FourthDraftRevised,
	[Description("IEEE 1278.1-1995.")]
	Ieee1278_1_1995,
	[Description("IEEE 1278.1A-1998.")]
	Ieee1278_1A_1998
}
