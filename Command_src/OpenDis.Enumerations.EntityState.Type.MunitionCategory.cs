using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum MunitionCategory : byte
{
	[Description("Other.")]
	Other,
	[Description("Guided.")]
	Guided,
	[Description("Ballistic.")]
	Ballistic,
	[Description("Fixed.")]
	Fixed
}
