using System;
using System.Xml;

namespace DotSpatial.Topology;

public interface IGeometry : IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable
{
	double Area { get; }

	IGeometry Boundary { get; set; }

	DimensionType BoundaryDimension { get; set; }

	IPoint Centroid { get; }

	Coordinate Coordinate { get; }

	DimensionType Dimension { get; set; }

	IEnvelope EnvelopeInternal { get; }

	IGeometryFactory Factory { get; }

	IGeometry InteriorPoint { get; }

	bool IsEmpty { get; }

	bool IsRectangle { get; }

	bool IsSimple { get; }

	bool IsValid { get; }

	double Length { get; }

	PrecisionModelType PrecisionModel { get; }

	int Srid { get; set; }

	object UserData { get; set; }

	void Apply(ICoordinateFilter filter);

	void Apply(IGeometryFilter filter);

	void Apply(IGeometryComponentFilter filter);

	IGeometry Buffer(double distance);

	IGeometry Buffer(double distance, BufferStyle endCapStyle);

	IGeometry Buffer(double distance, int quadrantSegments);

	IGeometry Buffer(double distance, int quadrantSegments, BufferStyle endCapStyle);

	void ClearEnvelope();

	Coordinate ClosestPoint(Coordinate testPoint);

	IGeometry ConvexHull();

	int CompareToSameClass(object o);

	double Distance(IGeometry geom);

	bool Equals(IGeometry geom);

	bool EqualsExact(IGeometry geom, double tolerance);

	bool EqualsExact(IGeometry geom);

	void GeometryChangedAction();

	void GeometryChanged();

	IGeometry GetGeometryN(int n);

	bool IsWithinDistance(IGeometry geom, double distance);

	void Normalize();

	XmlReader ToGmlFeature();

	void Rotate(Coordinate Origin, double radAngle);
}
