using System;

namespace DotSpatial.Topology;

public interface ILineSegment : IComparable, ILineSegmentBase
{
	double Length { get; }

	bool IsHorizontal { get; }

	bool IsVertical { get; }

	double Angle { get; }

	Coordinate GetCoordinate(int i);

	void SetCoordinates(ILineSegmentBase ls);

	void SetCoordinates(Coordinate p0, Coordinate p1);

	int OrientationIndex(ILineSegmentBase seg);

	void Reverse();

	void Normalize();

	double Distance(ILineSegmentBase ls);

	double Distance(Coordinate p);

	double DistancePerpendicular(Coordinate p);

	double ProjectionFactor(Coordinate p);

	Coordinate Project(Coordinate p);

	ILineSegment Project(ILineSegmentBase seg);

	Coordinate ClosestPoint(Coordinate p);

	Coordinate[] ClosestPoints(ILineSegmentBase line);

	Coordinate Intersection(ILineSegmentBase line);

	ILineSegment Intersection(Envelope inEnvelope);

	bool Intersects(Envelope inEnvelope);

	bool EqualsTopologically(ILineSegmentBase other);

	new string ToString();
}
