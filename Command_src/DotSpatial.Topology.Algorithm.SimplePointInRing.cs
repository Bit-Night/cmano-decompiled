using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class SimplePointInRing : IPointInRing
{
	private readonly IList<Coordinate> ilist_0;

	public SimplePointInRing(IBasicGeometry ring)
	{
		ilist_0 = ring.Coordinates;
	}

	public virtual bool IsInside(Coordinate pt)
	{
		return CgAlgorithms.IsPointInRing(pt, ilist_0);
	}

	static SimplePointInRing()
	{
		Class72.smethod_20();
	}
}
