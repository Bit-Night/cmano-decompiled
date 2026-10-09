using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class UniqueCoordinateArrayFilter : ICoordinateFilter
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly ISet<Coordinate> iset_0 = new SortedSet<Coordinate>();

	public virtual Coordinate[] Coordinates => (Coordinate[])arrayList_0.ToArray(typeof(Coordinate));

	public virtual void Filter(Coordinate coord)
	{
		if (!iset_0.Contains(coord))
		{
			arrayList_0.Add(coord);
			iset_0.Add(coord);
		}
	}

	static UniqueCoordinateArrayFilter()
	{
		Class72.smethod_20();
	}
}
