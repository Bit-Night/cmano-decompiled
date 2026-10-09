using System.Collections;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class NodeMap
{
	private readonly NodeFactory nodeFactory_0;

	private readonly IDictionary idictionary_0 = new SortedList();

	public virtual IList Values => new ArrayList(idictionary_0.Values);

	public NodeMap(NodeFactory nodeFact)
	{
		nodeFactory_0 = nodeFact;
	}

	public virtual Node AddNode(Coordinate coord)
	{
		Node node = (Node)idictionary_0[coord];
		if (node == null)
		{
			node = nodeFactory_0.CreateNode(coord);
			idictionary_0.Add(coord, node);
		}
		return node;
	}

	public virtual Node AddNode(Node n)
	{
		Node node = (Node)idictionary_0[n.Coordinate];
		if (node == null)
		{
			idictionary_0.Add(n.Coordinate, n);
			return n;
		}
		node.MergeLabel(n);
		return node;
	}

	public virtual void Add(EdgeEnd e)
	{
		Coordinate coordinate = e.Coordinate;
		AddNode(coordinate).Add(e);
	}

	public virtual Node Find(Coordinate coord)
	{
		return (Node)idictionary_0[coord];
	}

	public virtual IEnumerator GetEnumerator()
	{
		return idictionary_0.Values.GetEnumerator();
	}

	public virtual IList GetBoundaryNodes(int geomIndex)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (node.Label.GetLocation(geomIndex) == LocationType.Boundary)
			{
				list.Add(node);
			}
		}
		return list;
	}

	public virtual void Write(StreamWriter outstream)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Node)enumerator.Current).Write(outstream);
		}
	}

	static NodeMap()
	{
		Class72.smethod_20();
	}
}
