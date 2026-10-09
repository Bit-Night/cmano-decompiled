using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class CentroidLine
{
	private readonly Coordinate coordinate_0 = new Coordinate(0.0, 0.0, 0.0, 0.0);

	private double double_0;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = coordinate_0.X / double_0,
		Y = coordinate_0.Y / double_0
	};

	public virtual void Add(IGeometry geom)
	{
		if (geom is LineString)
		{
			Add(geom.Coordinates);
		}
		else if (geom is GeometryCollection)
		{
			IGeometry[] geometries = ((GeometryCollection)geom).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				Geometry geom2 = (Geometry)geometries[i];
				Add(geom2);
			}
		}
	}

	public virtual void Add(IList<Coordinate> pts)
	{
		for (int i = 0; i < pts.Count - 1; i++)
		{
			double num = pts[i].Distance(pts[i + 1]);
			double_0 += num;
			double num2 = (pts[i].X + pts[i + 1].X) / 2.0;
			coordinate_0.X += num * num2;
			double num3 = (pts[i].Y + pts[i + 1].Y) / 2.0;
			coordinate_0.Y += num * num3;
		}
	}

	static CentroidLine()
	{
		Class72.smethod_20();
	}
}
