using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum PartOfPosition : ushort
{
	[Description("Other.")]
	Other,
	[Description("On top of.")]
	OnTopOf,
	[Description("Inside of.")]
	InsideOf
}
