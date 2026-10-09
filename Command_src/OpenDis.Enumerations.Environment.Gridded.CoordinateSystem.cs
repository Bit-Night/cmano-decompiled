using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Gridded;

[Serializable]
public enum CoordinateSystem : ushort
{
	[Description("Right handed Cartesian (local topographic projection: east, north, up).")]
	RightHandedCartesianLocalTopographicProjectionEastNorthUp,
	[Description("Left handed Cartesian (local topographic projection: east, north, down).")]
	LeftHandedCartesianLocalTopographicProjectionEastNorthDown,
	[Description("Latitude, Longitude, Height.")]
	LatitudeLongitudeHeight,
	[Description("Latitude, Longitude, Depth.")]
	LatitudeLongitudeDepth
}
