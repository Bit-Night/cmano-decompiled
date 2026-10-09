using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class MinimalEdgeRing : EdgeRing
{
	public MinimalEdgeRing(DirectedEdge start, IGeometryFactory geometryFactory)
		: base(start, geometryFactory)
	{
	}

	public override DirectedEdge GetNext(DirectedEdge de)
	{
		return de.NextMin;
	}

	public override void SetEdgeRing(DirectedEdge de, EdgeRing er)
	{
		de.MinEdgeRing = er;
	}

	static MinimalEdgeRing()
	{
		Class72.smethod_20();
	}
}
