using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class OverlayNodeFactory : NodeFactory
{
	public override Node CreateNode(Coordinate coord)
	{
		return new Node(coord, new DirectedEdgeStar());
	}

	static OverlayNodeFactory()
	{
		Class72.smethod_20();
	}
}
