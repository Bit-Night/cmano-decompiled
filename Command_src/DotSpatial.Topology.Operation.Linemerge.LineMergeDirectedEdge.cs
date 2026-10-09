using DotSpatial.Topology.Planargraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeDirectedEdge : DirectedEdge
{
	public virtual LineMergeDirectedEdge Next
	{
		get
		{
			if (ToNode.Degree != 2)
			{
				return null;
			}
			if (ToNode.OutEdges.Edges[0] == Sym)
			{
				return (LineMergeDirectedEdge)ToNode.OutEdges.Edges[1];
			}
			Assert.IsTrue(ToNode.OutEdges.Edges[1] == Sym);
			return (LineMergeDirectedEdge)ToNode.OutEdges.Edges[0];
		}
	}

	public LineMergeDirectedEdge(Node from, Node to, Coordinate directionPt, bool edgeDirection)
		: base(from, to, directionPt, edgeDirection)
	{
	}

	static LineMergeDirectedEdge()
	{
		Class72.smethod_20();
	}
}
