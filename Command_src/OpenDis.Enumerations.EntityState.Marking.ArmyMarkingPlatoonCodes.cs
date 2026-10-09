using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingPlatoonCodes : byte
{
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
