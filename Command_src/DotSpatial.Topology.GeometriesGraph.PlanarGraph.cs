using System.Collections;
using System.Collections.Generic;
using System.IO;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.GeometriesGraph;

public class PlanarGraph
{
	private readonly IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private NodeMap nodeMap_0;

	public virtual IList EdgeEnds => ilist_0;

	public IList Edges
	{
		get
		{
			return ilist_1;
		}
		set
		{
			ilist_1 = value;
		}
	}

	public virtual NodeMap Nodes
	{
		get
		{
			return nodeMap_0;
		}
		set
		{
			nodeMap_0 = value;
		}
	}

	public virtual IList NodeValues => new ArrayList(nodeMap_0.Values);

	public PlanarGraph(NodeFactory nodeFact)
	{
		nodeMap_0 = new NodeMap(nodeFact);
	}

	public PlanarGraph()
	{
		nodeMap_0 = new NodeMap(new NodeFactory());
	}

	public virtual void Add(EdgeEnd e)
	{
		nodeMap_0.Add(e);
		ilist_0.Add(e);
	}

	public virtual void AddEdges(IList edgesToAdd)
	{
		IEnumerator enumerator = edgesToAdd.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			ilist_1.Add(edge);
			DirectedEdge directedEdge = new DirectedEdge(edge, inIsForward: true);
			DirectedEdge directedEdge2 = (directedEdge.Sym = new DirectedEdge(edge, inIsForward: false));
			directedEdge2.Sym = directedEdge;
			Add(directedEdge);
			Add(directedEdge2);
		}
	}

	public virtual Node AddNode(Node node)
	{
		return nodeMap_0.AddNode(node);
	}

	public virtual Node AddNode(Coordinate coord)
	{
		return nodeMap_0.AddNode(coord);
	}

	public virtual Node Find(Coordinate coord)
	{
		return nodeMap_0.Find(coord);
	}

	public virtual EdgeEnd FindEdgeEnd(Edge e)
	{
		IEnumerator enumerator = EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator.Current;
			if (edgeEnd.Edge == e)
			{
				return edgeEnd;
			}
		}
		return null;
	}

	public virtual Edge FindEdge(Coordinate p0, Coordinate p1)
	{
		for (int i = 0; i < ilist_1.Count; i++)
		{
			Edge edge = (Edge)ilist_1[i];
			IList<Coordinate> coordinates = edge.Coordinates;
			if (p0.Equals(coordinates[0]) && p1.Equals(coordinates[1]))
			{
				return edge;
			}
		}
		return null;
	}

	public virtual Edge FindEdgeInSameDirection(Coordinate p0, Coordinate p1)
	{
		int num = 0;
		Edge edge;
		while (true)
		{
			if (num < ilist_1.Count)
			{
				edge = (Edge)ilist_1[num];
				IList<Coordinate> coordinates = edge.Coordinates;
				if (smethod_0(p0, p1, coordinates[0], coordinates[1]))
				{
					break;
				}
				if (!smethod_0(p0, p1, coordinates[coordinates.Count - 1], coordinates[coordinates.Count - 2]))
				{
					num++;
					continue;
				}
				return edge;
			}
			return null;
		}
		return edge;
	}

	public virtual IEnumerator GetNodeEnumerator()
	{
		return nodeMap_0.GetEnumerator();
	}

	public virtual IEnumerator GetEdgeEnumerator()
	{
		return ilist_1.GetEnumerator();
	}

	protected virtual void InsertEdge(Edge e)
	{
		ilist_1.Add(e);
	}

	public virtual void LinkResultDirectedEdges()
	{
		IEnumerator enumerator = nodeMap_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkResultDirectedEdges();
		}
	}

	public virtual void LinkAllDirectedEdges()
	{
		IEnumerator enumerator = nodeMap_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkAllDirectedEdges();
		}
	}

	private static bool smethod_0(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		if (!coordinate_0.Equals(coordinate_2))
		{
			return false;
		}
		if (CgAlgorithms.ComputeOrientation(coordinate_0, coordinate_1, coordinate_3) == 0)
		{
			return QuadrantOp.Quadrant(coordinate_0, coordinate_1) == QuadrantOp.Quadrant(coordinate_2, coordinate_3);
		}
		return false;
	}

	public virtual void WriteEdges(StreamWriter outstream)
	{
		outstream.WriteLine("Edges:");
		for (int i = 0; i < ilist_1.Count; i++)
		{
			outstream.WriteLine("edge " + i + ":");
			Edge obj = (Edge)ilist_1[i];
			obj.Write(outstream);
			obj.EdgeIntersectionList.Write(outstream);
		}
	}

	public virtual bool IsBoundaryNode(int geomIndex, Coordinate coord)
	{
		Node node = nodeMap_0.Find(coord);
		if (node != null)
		{
			Label label = node.Label;
			int result;
			if (label == null)
			{
				result = 0;
			}
			else
			{
				if (label.GetLocation(geomIndex) == LocationType.Boundary)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static void LinkResultDirectedEdges(IList nodes)
	{
		IEnumerator enumerator = nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).LinkResultDirectedEdges();
		}
	}

	static PlanarGraph()
	{
		Class72.smethod_20();
	}
}
