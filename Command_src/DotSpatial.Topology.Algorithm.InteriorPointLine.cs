using System.Collections.Generic;
using System.Linq;

namespace DotSpatial.Topology.Algorithm;

public class InteriorPointLine
{
	private readonly Coordinate coordinate_0;

	private Coordinate coordinate_1;

	private double double_0 = double.MaxValue;

	public virtual Coordinate InteriorPoint => coordinate_1;

	public InteriorPointLine(IGeometry g)
	{
		coordinate_0 = new Coordinate(g.Centroid);
		method_0(g);
		if (coordinate_1 == null)
		{
			method_2(g);
		}
	}

	private void method_0(IGeometry igeometry_0)
	{
		if (!(igeometry_0 is ILineString))
		{
			if (igeometry_0 is GeometryCollection)
			{
				IGeometry[] geometries = ((GeometryCollection)igeometry_0).Geometries;
				for (int i = 0; i < geometries.Length; i++)
				{
					Geometry igeometry_1 = (Geometry)geometries[i];
					method_0(igeometry_1);
				}
			}
		}
		else
		{
			method_1(igeometry_0.Coordinates);
		}
	}

	private void method_1(IEnumerable<Coordinate> ienumerable_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			Add(item);
		}
	}

	private void method_2(IGeometry igeometry_0)
	{
		if (!(igeometry_0 is LineString))
		{
			if (igeometry_0 is GeometryCollection)
			{
				IGeometry[] geometries = ((GeometryCollection)igeometry_0).Geometries;
				for (int i = 0; i < geometries.Length; i++)
				{
					Geometry igeometry_1 = (Geometry)geometries[i];
					method_2(igeometry_1);
				}
			}
		}
		else
		{
			method_3(igeometry_0.Coordinates);
		}
	}

	private void method_3(IEnumerable<Coordinate> ienumerable_0)
	{
		Add(ienumerable_0.First());
		Add(ienumerable_0.Last());
	}

	private void Add(Coordinate point)
	{
		double num = point.Distance(coordinate_0);
		if (num < double_0)
		{
			coordinate_1 = new Coordinate(point);
			double_0 = num;
		}
	}

	static InteriorPointLine()
	{
		Class72.smethod_20();
	}
}
