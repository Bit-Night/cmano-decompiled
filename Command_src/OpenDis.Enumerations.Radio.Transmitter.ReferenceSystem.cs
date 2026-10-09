using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum ReferenceSystem : byte
{
	[Description("World Coordinates.")]
	WorldCoordinates = 1,
	[Description("Entity Coordinates.")]
	EntityCoordinates
}
