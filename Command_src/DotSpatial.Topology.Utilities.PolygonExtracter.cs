using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class PolygonExtracter : IGeometryFilter
{
	private readonly IList ilist_0;

	public PolygonExtracter(IList comps)
	{
		ilist_0 = comps;
	}

	public virtual void Filter(IGeometry geom)
	{
		if (geom is Polygon)
		{
			ilist_0.Add(geom);
		}
	}

	public static IList GetPolygons(IGeometry geom)
	{
		IList list = new ArrayList();
		geom.Apply(new PolygonExtracter(list));
		return list;
	}

	static PolygonExtracter()
	{
		Class72.smethod_20();
	}
}
