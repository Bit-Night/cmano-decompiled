using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Gridded;

[Serializable]
public enum DataRepresentationType : ushort
{
	[Description("Type 0.")]
	Type0,
	[Description("Type 1.")]
	Type1,
	[Description("Type 2.")]
	Type2
}
