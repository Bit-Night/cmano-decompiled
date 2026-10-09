using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum EnvironmentalSubcategory : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Very Small.")]
	VerySmall = 20,
	[Description("Small.")]
	Small = 40,
	[Description("Medium.")]
	Medium = 60,
	[Description("Large.")]
	Large = 80,
	[Description("Very Large.")]
	VeryLarge = 100
}
