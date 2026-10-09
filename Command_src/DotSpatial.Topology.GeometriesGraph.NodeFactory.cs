namespace DotSpatial.Topology.GeometriesGraph;

public class NodeFactory
{
	public virtual Node CreateNode(Coordinate coord)
	{
		return new Node(coord, null);
	}

	static NodeFactory()
	{
		Class72.smethod_20();
	}
}
