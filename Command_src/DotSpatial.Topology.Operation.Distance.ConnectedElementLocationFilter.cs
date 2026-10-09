using System.Collections;

namespace DotSpatial.Topology.Operation.Distance;

public class ConnectedElementLocationFilter : IGeometryFilter
{
	private readonly IList ilist_0;

	private ConnectedElementLocationFilter(IList locations)
	{
		ilist_0 = locations;
	}

	public virtual void Filter(IGeometry geom)
	{
		if (geom is Point || geom is LineString || geom is Polygon)
		{
			ilist_0.Add(new GeometryLocation(geom, 0, geom.Coordinate));
		}
	}

	public static IList GetLocations(IGeometry geom)
	{
		IList list = new ArrayList();
		geom.Apply(new ConnectedElementLocationFilter(list));
		return list;
	}

	static ConnectedElementLocationFilter()
	{
		Class72.smethod_20();
	}
}
