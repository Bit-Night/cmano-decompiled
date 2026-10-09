using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingVehicle : byte
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
	[Description("Blank.")]
	Blank = 32
}
