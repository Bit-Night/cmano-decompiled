using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Process;

[Serializable]
public enum EnvironmentalProcessTypesForGeometryRecord : uint
{
	[Description("Point Record 1.")]
	PointRecord1 = 655360u,
	[Description("Point Record 2.")]
	PointRecord2 = 167772160u,
	[Description("Line Record 1.")]
	LineRecord1 = 786432u,
	[Description("Line Record 2.")]
	LineRecord2 = 201326592u,
	[Description("Bounding Sphere Record.")]
	BoundingSphereRecord = 65536u,
	[Description("Sphere Record 1.")]
	SphereRecord1 = 851968u,
	[Description("Sphere Record 2.")]
	SphereRecord2 = 218103808u,
	[Description("Ellipsoid Record 1.")]
	EllipsoidRecord1 = 1048576u,
	[Description("Ellipsoid Record 2.")]
	EllipsoidRecord2 = 268435456u,
	[Description("Cone Record 1.")]
	ConeRecord1 = 3145728u,
	[Description("Cone Record 2.")]
	ConeRecord2 = 805306368u,
	[Description("Uniform Geometry Record.")]
	UniformGeometryRecord = 327680u,
	[Description("Rectangular Volume Record 1.")]
	RectangularVolumeRecord1 = 5242880u,
	[Description("Rectangular Volume Record 2.")]
	RectangularVolumeRecord2 = 1342177280u,
	[Description("Gaussian Plume Record.")]
	GaussianPlumeRecord = 1610612736u,
	[Description("Gaussian Puff Record.")]
	GaussianPuffRecord = 1879048192u,
	[Description("Rectangular Volume Record 3.")]
	RectangularVolumeRecord3 = 83886080u
}
