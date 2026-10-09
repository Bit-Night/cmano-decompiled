using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class MaximalEdgeRing : EdgeRing
{
	public MaximalEdgeRing(DirectedEdge start, IGeometryFactory geometryFactory)
		: base(start, geometryFactory)
	{
	}

	public override DirectedEdge GetNext(DirectedEdge de)
	{
		return de.Next;
	}

	public override void SetEdgeRing(DirectedEdge de, EdgeRing er)
	{
		de.EdgeRing = er;
	}

	public virtual void LinkDirectedEdgesForMinimalEdgeRings()
	{
		DirectedEdge directedEdge = base.StartDe;
		do
		{
			((DirectedEdgeStar)directedEdge.Node.Edges).LinkMinimalDirectedEdges(this);
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != base.StartDe);
	}

	public virtual IList BuildMinimalRings()
	{
		IList list = new ArrayList();
		DirectedEdge directedEdge = base.StartDe;
		do
		{
			if (directedEdge.MinEdgeRing == null)
			{
				EdgeRing value = new MinimalEdgeRing(directedEdge, base.InnerGeometryFactory);
				list.Add(value);
			}
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != base.StartDe);
		return list;
	}

	static MaximalEdgeRing()
	{
		Class72.smethod_20();
	}
}
