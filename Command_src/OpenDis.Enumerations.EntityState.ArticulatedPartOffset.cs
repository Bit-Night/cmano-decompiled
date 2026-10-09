using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState;

[Serializable]
public enum ArticulatedPartOffset : uint
{
	[Description("Position.")]
	Position = 1u,
	[Description("Position Rate.")]
	PositionRate,
	[Description("Extension.")]
	Extension,
	[Description("Extension Rate.")]
	ExtensionRate,
	[Description("X.")]
	X,
	[Description("X Rate.")]
	XRate,
	[Description("Y.")]
	Y,
	[Description("Y Rate.")]
	YRate,
	[Description("Z.")]
	Z,
	[Description("Z Rate.")]
	ZRate,
	[Description("Azimuth.")]
	Azimuth,
	[Description("Azimuth Rate.")]
	AzimuthRate,
	[Description("Elevation.")]
	Elevation,
	[Description("Elevation Rate.")]
	ElevationRate,
	[Description("Rotation.")]
	Rotation,
	[Description("Rotation Rate.")]
	RotationRate
}
