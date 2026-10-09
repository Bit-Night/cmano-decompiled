namespace DotSpatial.Topology.Algorithm;

public class CentroidPoint
{
	private readonly Coordinate coordinate_0 = new Coordinate();

	private int int_0;

	public virtual Coordinate Centroid => new Coordinate
	{
		X = coordinate_0.X / (double)int_0,
		Y = coordinate_0.Y / (double)int_0
	};

	public virtual void Add(IGeometry geom)
	{
		if (geom is IPoint)
		{
			Add(geom.Coordinate);
		}
		else if (geom is GInterface6)
		{
			IGeometry[] geometries = ((GInterface6)geom).Geometries;
			foreach (IGeometry geom2 in geometries)
			{
				Add(geom2);
			}
		}
	}

	public virtual void Add(Coordinate pt)
	{
		int_0++;
		coordinate_0.X += pt.X;
		coordinate_0.Y += pt.Y;
	}

	static CentroidPoint()
	{
		Class72.smethod_20();
	}
}
