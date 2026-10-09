using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface IGeometryFactory
{
	IGeometryFactory Floating { get; set; }

	IGeometryFactory FloatingSingle { get; set; }

	int Srid { get; }

	PrecisionModelType PrecisionModel { get; }

	ICoordinateSequenceFactory CoordinateSequenceFactory { get; }

	IGeometry BuildGeometry(IList geomList);

	IPoint CreatePoint(Coordinate coord);

	IMultiLineString CreateMultiLineString(IBasicLineString[] lineStrings);

	GInterface6 CreateGeometryCollection(IGeometry[] geometries);

	IMultiPolygon CreateMultiPolygon(IPolygon[] polygons);

	ILinearRing CreateLinearRing(IList<Coordinate> coordinates);

	IMultiPoint CreateMultiPoint(IEnumerable<ICoordinate> coordinates);

	IMultiPoint CreateMultiPoint(IEnumerable<Coordinate> coordinates);

	ILineString CreateLineString(IList<Coordinate> coordinates);

	IGeometry CreateGeometry(IGeometry g);

	IPolygon CreatePolygon(ILinearRing shell, ILinearRing[] holes);
}
