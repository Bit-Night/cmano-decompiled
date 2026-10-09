using System.Collections;
using DotSpatial.Topology.Noding;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeNodingValidator
{
	private readonly NodingValidator nodingValidator_0;

	public EdgeNodingValidator(IEnumerable edges)
	{
		nodingValidator_0 = new NodingValidator(smethod_0(edges));
	}

	private static IList smethod_0(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			list.Add(new SegmentString(edge.Coordinates, edge));
		}
		return list;
	}

	public virtual void CheckValid()
	{
		nodingValidator_0.CheckValid();
	}

	static EdgeNodingValidator()
	{
		Class72.smethod_20();
	}
}
