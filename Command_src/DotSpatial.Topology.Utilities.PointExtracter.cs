using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class PointExtracter : IGeometryFilter
{
	private readonly IList ilist_0;

	public PointExtracter(IList pts)
	{
		ilist_0 = pts;
	}

	public virtual void Filter(IGeometry geom)
	{
		if (geom is Point)
		{
			ilist_0.Add(geom);
		}
	}

	public static IList GetPoints(IGeometry geom)
	{
		IList list = new ArrayList();
		geom.Apply(new PointExtracter(list));
		return list;
	}

	static PointExtracter()
	{
		Class72.smethod_20();
	}
}
