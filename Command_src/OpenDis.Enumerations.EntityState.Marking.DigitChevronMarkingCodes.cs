using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum DigitChevronMarkingCodes : byte
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
	[Description("Underscore 0")]
	Underscore_0 = 10,
	[Description("Underscore 1")]
	Underscore_1 = 11,
	[Description("Underscore 2")]
	Underscore_2 = 12,
	[Description("Underscore 3")]
	Underscore_3 = 13,
	[Description("Underscore 4")]
	Underscore_4 = 14,
	[Description("Underscore 5")]
	Underscore_5 = 15,
	[Description("Underscore 6")]
	Underscore_6 = 16,
	[Description("Underscore 7")]
	Underscore_7 = 17,
	[Description("Underscore 8")]
	Underscore_8 = 18,
	[Description("Underscore 9")]
	Underscore_9 = 19,
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
	Blank = 32,
	[Description("Caret.")]
	Caret = 94,
	[Description("Greater than.")]
	GreaterThan = 62,
	[Description("inverted carrot.")]
	InvertedCarrot = 86,
	[Description("Lower than.")]
	LowerThan = 60,
	[Description("Caret and inverted carrot.")]
	CaretAndInvertedCarrot = 126,
	[Description("Lower or greater than.")]
	LowerThanGreaterThan = 61
}
