using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum EntityMarkingText : byte
{
	[Description("ASCII.")]
	ASCII = 1,
	[Description("Army Marking (CCTT).")]
	ArmyMarkingCCTT,
	[Description("Digit Chevron.")]
	DigitChevron
}
