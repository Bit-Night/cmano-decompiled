using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNodeFactory : NodeFactory
{
	public override Node CreateNode(Coordinate coord)
	{
		return new RelateNode(coord, new EdgeEndBundleStar());
	}

	static RelateNodeFactory()
	{
		Class72.smethod_20();
	}
}
