using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public abstract class PlanarGraph
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly NodeMap nodeMap_0 = new NodeMap();

	private IList ilist_1 = new ArrayList();

	public virtual IList DirectedEdges
	{
		get
		{
			return ilist_1;
		}
		protected set
		{
			ilist_1 = value;
		}
	}

	public virtual ICollection Nodes => nodeMap_0.Values;

	public virtual IList Edges => ilist_0;

	public virtual Node FindNode(Coordinate pt)
	{
		return nodeMap_0.Find(pt);
	}

	protected virtual void Add(Node node)
	{
		nodeMap_0.Add(node);
	}

	protected virtual void Add(Edge edge)
	{
		ilist_0.Add(edge);
		Add(edge.GetDirEdge(0));
		Add(edge.GetDirEdge(1));
	}

	protected virtual void Add(DirectedEdge dirEdge)
	{
		ilist_1.Add(dirEdge);
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return nodeMap_0.GetEnumerator();
	}

	public virtual IEnumerator GetDirEdgeEnumerator()
	{
		return ilist_1.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return ilist_0.GetEnumerator();
	}

	public virtual void Remove(Edge edge)
	{
		Remove(edge.GetDirEdge(0));
		Remove(edge.GetDirEdge(1));
		ilist_0.Remove(edge);
		edge.Remove();
	}

	public virtual void Remove(DirectedEdge de)
	{
		DirectedEdge sym = de.Sym;
		if (sym != null)
		{
			sym.Sym = null;
		}
		de.FromNode.OutEdges.Remove(de);
		de.Remove();
		ilist_1.Remove(de);
	}

	public virtual void Remove(Node node)
	{
		IEnumerator enumerator = node.OutEdges.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			DirectedEdge sym = directedEdge.Sym;
			if (sym != null)
			{
				Remove(sym);
			}
			ilist_1.Remove(directedEdge);
			Edge edge = directedEdge.Edge;
			if (edge != null)
			{
				ilist_0.Remove(edge);
			}
		}
		nodeMap_0.Remove(node.Coordinate);
		node.Remove();
	}

	public virtual IList FindNodesOfDegree(int degree)
	{
		IList list = new ArrayList();
		IEnumerator nodeEnumerator = GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			if (node.Degree == degree)
			{
				list.Add(node);
			}
		}
		return list;
	}

	static PlanarGraph()
	{
		Class72.smethod_20();
	}
}
