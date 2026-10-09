using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Planargraph;

public class Subgraph
{
	protected readonly IList<DirectedEdge> DirEdges = new List<DirectedEdge>();

	protected readonly ISet<Edge> Edges = new HashSet<Edge>();

	protected readonly NodeMap NodeMap = new NodeMap();

	protected readonly PlanarGraph ParentGraph;

	public Subgraph(PlanarGraph parentGraph)
	{
		ParentGraph = parentGraph;
	}

	public virtual PlanarGraph GetParent()
	{
		return ParentGraph;
	}

	public virtual void Add(Edge e)
	{
		if (!Edges.Contains(e))
		{
			Edges.Add(e);
			DirEdges.Add(e.GetDirEdge(0));
			DirEdges.Add(e.GetDirEdge(1));
			NodeMap.Add(e.GetDirEdge(0).FromNode);
			NodeMap.Add(e.GetDirEdge(1).FromNode);
		}
	}

	public virtual IEnumerator GetDirEdgeEnumerator()
	{
		return DirEdges.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return Edges.GetEnumerator();
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return NodeMap.GetEnumerator();
	}

	public virtual bool Contains(Edge e)
	{
		return Edges.Contains(e);
	}

	static Subgraph()
	{
		Class72.smethod_20();
	}
}
