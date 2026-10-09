using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState;

[Serializable]
public enum ParameterTypeDesignator : byte
{
	[Description("Articulated Part.")]
	ArticulatedPart,
	[Description("Attached Part.")]
	AttachedPart
}
