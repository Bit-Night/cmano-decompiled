using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingMarkingCodes : byte
{
	[Description("Value 0")]
	Value_0 = 0,
	[Description("Value 1")]
	Value_1 = 1,
	[Description("Value 2")]
	Value_2 = 2,
	[Description("Value 3")]
	Value_3 = 3,
	[Description("Value 4")]
	Value_4 = 4,
	[Description("Value 5")]
	Value_5 = 5,
	[Description("Value 6")]
	Value_6 = 6,
	[Description("Value 7")]
	Value_7 = 7,
	[Description("Value 8")]
	Value_8 = 8,
	[Description("Value 9")]
	Value_9 = 9,
	[Description("Value 0")]
	Value_0_ = 10,
	[Description("Value 1")]
	Value_1_ = 11,
	[Description("Value 2")]
	Value_2_ = 12,
	[Description("Value 3")]
	Value_3_ = 13,
	[Description("Value 4")]
	Value_4_ = 14,
	[Description("Value 5")]
	Value_5_ = 15,
	[Description("Value 6")]
	Value_6_ = 16,
	[Description("Value 7")]
	Value_7_ = 17,
	[Description("Value 8")]
	Value_8_ = 18,
	[Description("Value 9")]
	Value_9_ = 19,
	[Description("E.")]
	E = 69,
	[Description("Underscore E.")]
	UnderscoreE = 101,
	[Description("S.")]
	S = 83,
	[Description("Underscore S.")]
	UnderscoreS = 115,
	[Description("X.")]
	X = 88,
	[Description("Underscore X.")]
	UnderscoreX = 120,
	[Description("Blank.")]
	Blank = 32
}
