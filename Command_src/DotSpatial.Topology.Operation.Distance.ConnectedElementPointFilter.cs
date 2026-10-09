using System.Collections;

namespace DotSpatial.Topology.Operation.Distance;

public class ConnectedElementPointFilter : IGeometryFilter
{
	private readonly IList ilist_0;

	private ConnectedElementPointFilter(IList pts)
	{
		ilist_0 = pts;
	}

	public virtual void Filter(IGeometry geom)
	{
		if (geom is Point || geom is LineString || geom is Polygon)
		{
			ilist_0.Add(geom.Coordinate);
		}
	}

	public static IList GetCoordinates(Geometry geom)
	{
		IList list = new ArrayList();
		geom.Apply(new ConnectedElementPointFilter(list));
		return list;
	}

	static ConnectedElementPointFilter()
	{
		Class72.smethod_20();
	}
}
