using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Algorithm;

public class CentroidArea
{
	private readonly Coordinate coordinate_0 = new Coordinate(0.0, 0.0, 0.0, 0.0);

	private double double_0;

	private Coordinate coordinate_1;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = coordinate_0.X / 3.0 / double_0,
		Y = coordinate_0.Y / 3.0 / double_0
	};

	[SpecialName]
	private void method_0(Coordinate coordinate_2)
	{
		coordinate_1 = coordinate_2;
	}

	public virtual void Add(IGeometry geom)
	{
		if (geom is Polygon)
		{
			Polygon polygon = geom as Polygon;
			method_0(polygon.Shell.Coordinates[0]);
			Add(polygon);
		}
		else if (geom is GeometryCollection)
		{
			IGeometry[] geometries = (geom as GeometryCollection).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry geom2 = (Geometry)geometries[i];
				Add(geom2);
			}
		}
	}

	public virtual void Add(Coordinate[] ring)
	{
		method_0(ring[0]);
		method_1(ring);
	}

	private void Add(IPolygon poly)
	{
		method_1(poly.Shell.Coordinates);
		ILinearRing[] holes = poly.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			method_2(lineString.Coordinates);
		}
	}

	private void method_1(IList<Coordinate> ilist_0)
	{
		bool bool_ = !CgAlgorithms.IsCounterClockwise(ilist_0);
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			method_3(coordinate_1, ilist_0[i], ilist_0[i + 1], bool_);
		}
	}

	private void method_2(IList<Coordinate> ilist_0)
	{
		bool bool_ = CgAlgorithms.IsCounterClockwise(ilist_0);
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			method_3(coordinate_1, ilist_0[i], ilist_0[i + 1], bool_);
		}
	}

	private void method_3(Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4, bool bool_0)
	{
		double num = ((!bool_0) ? (-1.0) : 1.0);
		smethod_0(coordinate_2, coordinate_3, coordinate_4, out var coordinate_5);
		double num2 = smethod_1(coordinate_2, coordinate_3, coordinate_4);
		coordinate_0.X += num * num2 * coordinate_5.X;
		coordinate_0.Y += num * num2 * coordinate_5.Y;
		double_0 += num * num2;
	}

	private static void smethod_0(object object_0, object object_1, object object_2, out Coordinate coordinate_2)
	{
		coordinate_2 = new Coordinate();
		coordinate_2.X = ((Coordinate)object_0).X + ((Coordinate)object_1).X + ((Coordinate)object_2).X;
		coordinate_2.Y = ((Coordinate)object_0).Y + ((Coordinate)object_1).Y + ((Coordinate)object_2).Y;
	}

	private static double smethod_1(object object_0, object object_1, object object_2)
	{
		return (((Coordinate)object_1).X - ((Coordinate)object_0).X) * (((Coordinate)object_2).Y - ((Coordinate)object_0).Y) - (((Coordinate)object_2).X - ((Coordinate)object_0).X) * (((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
	}

	static CentroidArea()
	{
		Class72.smethod_20();
	}
}
