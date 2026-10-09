using System;

namespace DotSpatial.Topology;

public interface ILineString : IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicLineString
{
	IPoint StartPoint { get; }

	IPoint EndPoint { get; }

	bool IsClosed { get; }

	bool IsRing { get; }

	double Angle { get; }

	IPoint GetPointN(int n);

	ILineString Reverse();

	bool IsCoordinate(Coordinate pt);
}
