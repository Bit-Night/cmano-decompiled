using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class LinearComponentExtracter : IGeometryComponentFilter
{
	private readonly IList ilist_0;

	public LinearComponentExtracter(IList lines)
	{
		ilist_0 = lines;
	}

	public virtual void Filter(IGeometry geom)
	{
		if (geom is LineString)
		{
			ilist_0.Add(geom);
		}
	}

	public static IList GetLines(IGeometry geom)
	{
		IList list = new ArrayList();
		geom.Apply(new LinearComponentExtracter(list));
		return list;
	}

	static LinearComponentExtracter()
	{
		Class72.smethod_20();
	}
}
