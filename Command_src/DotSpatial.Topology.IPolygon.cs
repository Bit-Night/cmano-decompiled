using System;

namespace DotSpatial.Topology;

public interface IPolygon : IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicPolygon
{
	new ILinearRing Shell { get; }

	new ILinearRing[] Holes { get; }

	ILineString GetInteriorRingN(int n);
}
