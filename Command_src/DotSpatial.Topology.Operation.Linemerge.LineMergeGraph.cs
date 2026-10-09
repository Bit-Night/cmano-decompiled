using System.Collections.Generic;
using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeGraph : PlanarGraph
{
	public virtual void AddEdge(LineString lineString)
	{
		if (!lineString.IsEmpty)
		{
			IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(lineString.Coordinates);
			Coordinate coordinate_ = list[0];
			Coordinate coordinate_2 = list[list.Count - 1];
			Node node = method_0(coordinate_);
			Node node2 = method_0(coordinate_2);
			DirectedEdge de = new LineMergeDirectedEdge(node, node2, list[1], edgeDirection: true);
			DirectedEdge de2 = new LineMergeDirectedEdge(node2, node, list[list.Count - 2], edgeDirection: false);
			Edge edge = new LineMergeEdge(lineString);
			edge.SetDirectedEdges(de, de2);
			Add(edge);
		}
	}

	private Node method_0(Coordinate coordinate_0)
	{
		Node node = FindNode(coordinate_0);
		if (node == null)
		{
			node = new Node(coordinate_0);
			Add(node);
		}
		return node;
	}

	static LineMergeGraph()
	{
		Class72.smethod_20();
	}
}
