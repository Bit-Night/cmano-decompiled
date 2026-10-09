using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Distance;

public class DistanceOp
{
	private readonly IGeometry[] igeometry_0;

	private readonly PointLocator pointLocator_0 = new PointLocator();

	private readonly double double_0;

	private double double_1 = double.MaxValue;

	private GeometryLocation[] geometryLocation_0;

	private DistanceOp(IGeometry g0, IGeometry g1)
		: this(g0, g1, 0.0)
	{
	}

	public DistanceOp(IGeometry g0, IGeometry g1, double terminateDistance)
	{
		IGeometry[] array = new Geometry[2];
		igeometry_0 = array;
		igeometry_0[0] = g0;
		igeometry_0[1] = g1;
		double_0 = terminateDistance;
	}

	public static double Distance(IGeometry g0, IGeometry g1)
	{
		return new DistanceOp(g0, g1).Distance();
	}

	public static bool IsWithinDistance(IGeometry g0, IGeometry g1, double distance)
	{
		return new DistanceOp(g0, g1, distance).Distance() <= distance;
	}

	public static Coordinate[] ClosestPoints(IGeometry g0, IGeometry g1)
	{
		return new DistanceOp(g0, g1).ClosestPoints();
	}

	public virtual double Distance()
	{
		method_1();
		return double_1;
	}

	public virtual Coordinate[] ClosestPoints()
	{
		method_1();
		return new Coordinate[2]
		{
			geometryLocation_0[0].Coordinate,
			geometryLocation_0[1].Coordinate
		};
	}

	public virtual GeometryLocation[] ClosestLocations()
	{
		method_1();
		return geometryLocation_0;
	}

	private void method_0(GeometryLocation[] geometryLocation_1, bool bool_0)
	{
		if (geometryLocation_1[0] != null)
		{
			if (!bool_0)
			{
				geometryLocation_0[0] = geometryLocation_1[0];
				geometryLocation_0[1] = geometryLocation_1[1];
			}
			else
			{
				geometryLocation_0[0] = geometryLocation_1[1];
				geometryLocation_0[1] = geometryLocation_1[0];
			}
		}
	}

	private void method_1()
	{
		if (geometryLocation_0 == null)
		{
			geometryLocation_0 = new GeometryLocation[2];
			method_2();
			if (double_1 > double_0)
			{
				method_5();
			}
		}
	}

	private void method_2()
	{
		IList polygons = PolygonExtracter.GetPolygons(igeometry_0[0]);
		IList polygons2 = PolygonExtracter.GetPolygons(igeometry_0[1]);
		GeometryLocation[] array = new GeometryLocation[2];
		if (polygons2.Count > 0)
		{
			IList locations = ConnectedElementLocationFilter.GetLocations(igeometry_0[0]);
			method_3(locations, polygons2, array);
			if (double_1 <= double_0)
			{
				geometryLocation_0[0] = array[0];
				geometryLocation_0[1] = array[1];
				return;
			}
		}
		if (polygons.Count > 0)
		{
			IList locations2 = ConnectedElementLocationFilter.GetLocations(igeometry_0[1]);
			method_3(locations2, polygons, array);
			if (double_1 <= double_0)
			{
				geometryLocation_0[0] = array[1];
				geometryLocation_0[1] = array[0];
			}
		}
	}

	private void method_3(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_1)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			GeometryLocation geometryLocation_2 = (GeometryLocation)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Polygon igeometry_ = (Polygon)ilist_1[j];
				method_4(geometryLocation_2, igeometry_, geometryLocation_1);
				if (!(double_1 > double_0))
				{
					return;
				}
			}
		}
	}

	private void method_4(GeometryLocation geometryLocation_1, IGeometry igeometry_1, GeometryLocation[] geometryLocation_2)
	{
		Coordinate coordinate = geometryLocation_1.Coordinate;
		if (LocationType.Exterior != pointLocator_0.Locate(coordinate, igeometry_1))
		{
			double_1 = 0.0;
			geometryLocation_2[0] = geometryLocation_1;
			GeometryLocation geometryLocation = new GeometryLocation(igeometry_1, coordinate);
			geometryLocation_2[1] = geometryLocation;
		}
	}

	private void method_5()
	{
		GeometryLocation[] array = new GeometryLocation[2];
		IList lines = LinearComponentExtracter.GetLines(igeometry_0[0]);
		IList lines2 = LinearComponentExtracter.GetLines(igeometry_0[1]);
		IList points = PointExtracter.GetPoints(igeometry_0[0]);
		IList points2 = PointExtracter.GetPoints(igeometry_0[1]);
		method_6(lines, lines2, array);
		method_0(array, bool_0: false);
		if (double_1 <= double_0)
		{
			return;
		}
		array[0] = null;
		array[1] = null;
		method_8(lines, points2, array);
		method_0(array, bool_0: false);
		if (!(double_1 <= double_0))
		{
			array[0] = null;
			array[1] = null;
			method_8(lines2, points, array);
			method_0(array, bool_0: true);
			if (!(double_1 <= double_0))
			{
				array[0] = null;
				array[1] = null;
				method_7(points, points2, array);
				method_0(array, bool_0: false);
			}
		}
	}

	private void method_6(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_1)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LineString ilineString_ = (LineString)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				LineString ilineString_2 = (LineString)ilist_1[j];
				method_9(ilineString_, ilineString_2, geometryLocation_1);
				if (!(double_1 > double_0))
				{
					return;
				}
			}
		}
	}

	private void method_7(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_1)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Point point = (Point)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Point point2 = (Point)ilist_1[j];
				double num = point.Coordinate.Distance(point2.Coordinate);
				if (num < double_1)
				{
					double_1 = num;
					geometryLocation_1[0] = new GeometryLocation(point, 0, point.Coordinate);
					geometryLocation_1[1] = new GeometryLocation(point2, 0, point2.Coordinate);
				}
				if (!(double_1 > double_0))
				{
					return;
				}
			}
		}
	}

	private void method_8(IList ilist_0, IList ilist_1, GeometryLocation[] geometryLocation_1)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LineString ilineString_ = (LineString)ilist_0[i];
			for (int j = 0; j < ilist_1.Count; j++)
			{
				Point point_ = (Point)ilist_1[j];
				method_10(ilineString_, point_, geometryLocation_1);
				if (!(double_1 > double_0))
				{
					return;
				}
			}
		}
	}

	private void method_9(ILineString ilineString_0, ILineString ilineString_1, GeometryLocation[] geometryLocation_1)
	{
		if (!(ilineString_0.EnvelopeInternal.Distance(ilineString_1.EnvelopeInternal) <= double_1))
		{
			return;
		}
		IList<Coordinate> coordinates = ilineString_0.Coordinates;
		IList<Coordinate> coordinates2 = ilineString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				double num = CgAlgorithms.DistanceLineLine(coordinates[i], coordinates[i + 1], coordinates2[j], coordinates2[j + 1]);
				if (num < double_1)
				{
					double_1 = num;
					LineSegment lineSegment = new LineSegment(coordinates[i], coordinates[i + 1]);
					LineSegment line = new LineSegment(coordinates2[j], coordinates2[j + 1]);
					Coordinate[] array = lineSegment.ClosestPoints(line);
					geometryLocation_1[0] = new GeometryLocation(ilineString_0, i, new Coordinate(array[0]));
					geometryLocation_1[1] = new GeometryLocation(ilineString_1, j, new Coordinate(array[1]));
				}
				if (!(double_1 > double_0))
				{
					return;
				}
			}
		}
	}

	private void method_10(ILineString ilineString_0, Point point_0, GeometryLocation[] geometryLocation_1)
	{
		if (!(ilineString_0.EnvelopeInternal.Distance(point_0.EnvelopeInternal) <= double_1))
		{
			return;
		}
		IList<Coordinate> coordinates = ilineString_0.Coordinates;
		Coordinate coordinate = point_0.Coordinate;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			double num = CgAlgorithms.DistancePointLine(coordinate, coordinates[i], coordinates[i + 1]);
			if (num < double_1)
			{
				double_1 = num;
				Coordinate pt = new Coordinate(new LineSegment(coordinates[i], coordinates[i + 1]).ClosestPoint(coordinate));
				geometryLocation_1[0] = new GeometryLocation(ilineString_0, i, pt);
				geometryLocation_1[1] = new GeometryLocation(point_0, 0, coordinate);
			}
			if (!(double_1 > double_0))
			{
				break;
			}
		}
	}

	static DistanceOp()
	{
		Class72.smethod_20();
	}
}
