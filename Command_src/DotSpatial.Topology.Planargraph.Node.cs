using System.Collections;
using System.Linq;

namespace DotSpatial.Topology.Planargraph;

public class Node : GraphComponent
{
	protected readonly DirectedEdgeStar DeStar;

	private Coordinate coordinate_0;

	public virtual Coordinate Coordinate => coordinate_0;

	public virtual DirectedEdgeStar OutEdges => DeStar;

	public virtual int Degree => DeStar.Degree;

	public override bool IsRemoved => coordinate_0 == null;

	public Node(Coordinate location)
		: this(location, new DirectedEdgeStar())
	{
	}

	public Node(Coordinate location, DirectedEdgeStar deStar)
	{
		coordinate_0 = location;
		DeStar = deStar;
	}

	public static IList GetEdgesBetween(Node node0, Node node1)
	{
		IList list = DirectedEdge.ToEdges(node0.OutEdges.Edges);
		foreach (Edge item in DirectedEdge.ToEdges(node1.OutEdges.Edges).Cast<Edge>().Where(list.Contains)
			.ToList())
		{
			list.Remove(item);
		}
		return list;
	}

	public virtual void AddOutEdge(DirectedEdge de)
	{
		DeStar.Add(de);
	}

	public virtual int GetIndex(Edge edge)
	{
		return DeStar.GetIndex(edge);
	}

	internal void Remove()
	{
		coordinate_0 = null;
	}

	public override string ToString()
	{
		return "NODE: " + coordinate_0.ToString() + ": " + Degree;
	}

	static Node()
	{
		Class72.smethod_20();
	}
}
