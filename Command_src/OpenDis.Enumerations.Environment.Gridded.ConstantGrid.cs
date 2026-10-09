using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Gridded;

[Serializable]
public enum ConstantGrid : byte
{
	[Description("Constant grid.")]
	ConstantGrid,
	[Description("Updated grid.")]
	UpdatedGrid
}
