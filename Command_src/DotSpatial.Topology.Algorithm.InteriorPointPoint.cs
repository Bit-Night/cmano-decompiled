namespace DotSpatial.Topology.Algorithm;

public class InteriorPointPoint
{
	private readonly Coordinate coordinate_0;

	private Coordinate coordinate_1 = Coordinate.Empty;

	private double double_0 = double.MaxValue;

	public virtual Coordinate InteriorPoint => coordinate_1;

	public InteriorPointPoint(IGeometry g)
	{
		coordinate_0 = new Coordinate(g.Centroid);
		Add(g);
	}

	private void Add(IGeometry geom)
	{
		if (!(geom is Point))
		{
			if (geom is GeometryCollection)
			{
				IGeometry[] geometries = ((GeometryCollection)geom).Geometries;
				for (int i = 0; i < geometries.Length; i++)
				{
					Geometry geom2 = (Geometry)geometries[i];
					Add(geom2);
				}
			}
		}
		else
		{
			Add(geom.Coordinate);
		}
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

	static InteriorPointPoint()
	{
		Class72.smethod_20();
	}
}
