using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum AggregateFormation : uint
{
	[Description("Other.")]
	Other,
	[Description("Assembly.")]
	Assembly,
	[Description("Vee.")]
	Vee,
	[Description("Wedge.")]
	Wedge,
	[Description("Line.")]
	Line,
	[Description("Column.")]
	Column
}
