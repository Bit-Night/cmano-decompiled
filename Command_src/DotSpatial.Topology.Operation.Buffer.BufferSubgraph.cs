using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferSubgraph : IComparable
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly RightmostEdgeFinder rightmostEdgeFinder_0;

	private readonly IList ilist_1 = new ArrayList();

	private Coordinate coordinate_0;

	public virtual IList DirectedEdges => ilist_0;

	public virtual IList Nodes => ilist_1;

	public virtual Coordinate RightMostCoordinate => coordinate_0;

	public BufferSubgraph()
	{
		rightmostEdgeFinder_0 = new RightmostEdgeFinder();
	}

	public virtual int CompareTo(object o)
	{
		BufferSubgraph bufferSubgraph = (BufferSubgraph)o;
		if (RightMostCoordinate.X < bufferSubgraph.RightMostCoordinate.X)
		{
			return -1;
		}
		if (RightMostCoordinate.X > bufferSubgraph.RightMostCoordinate.X)
		{
			return 1;
		}
		return 0;
	}

	public virtual void Create(Node node)
	{
		method_0(node);
		rightmostEdgeFinder_0.FindEdge(ilist_0);
		coordinate_0 = rightmostEdgeFinder_0.Coordinate;
	}

	private void method_0(Node node_0)
	{
		Stack stack = new Stack();
		stack.Push(node_0);
		while (stack.Count != 0)
		{
			Node node = (Node)stack.Pop();
			Add(node, stack);
		}
	}

	private void Add(Node node, Stack nodeStack)
	{
		node.IsVisited = true;
		ilist_1.Add(node);
		IEnumerator enumerator = node.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			ilist_0.Add(directedEdge);
			Node node2 = directedEdge.Sym.Node;
			if (!node2.IsVisited)
			{
				nodeStack.Push(node2);
			}
		}
	}

	private void method_1()
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdge)enumerator.Current).IsVisited = false;
		}
	}

	public virtual void ComputeDepth(int outsideDepth)
	{
		method_1();
		DirectedEdge edge = rightmostEdgeFinder_0.Edge;
		edge.SetEdgeDepths(PositionType.Right, outsideDepth);
		smethod_2(edge);
		smethod_0(edge);
	}

	private static void smethod_0(object object_0)
	{
		HashSet<Node> hashSet = new HashSet<Node>();
		Queue queue = new Queue();
		Node node = ((EdgeEnd)object_0).Node;
		queue.Enqueue(node);
		hashSet.Add(node);
		((DirectedEdge)object_0).IsVisited = true;
		while (queue.Count != 0)
		{
			Node node2 = (Node)queue.Dequeue();
			hashSet.Add(node2);
			smethod_1(node2);
			IEnumerator enumerator = node2.Edges.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DirectedEdge sym = ((DirectedEdge)enumerator.Current).Sym;
				if (!sym.IsVisited)
				{
					Node node3 = sym.Node;
					if (!hashSet.Contains(node3))
					{
						queue.Enqueue(node3);
						hashSet.Add(node3);
					}
				}
			}
		}
	}

	private static void smethod_1(object object_0)
	{
		DirectedEdge directedEdge = null;
		IEnumerator enumerator = ((Node)object_0).Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge2 = (DirectedEdge)enumerator.Current;
			if (directedEdge2.IsVisited || directedEdge2.Sym.IsVisited)
			{
				directedEdge = directedEdge2;
				break;
			}
		}
		Assert.IsTrue(directedEdge != null, "unable to find edge to compute depths at " + (object)((GraphComponent)object_0).Coordinate);
		((DirectedEdgeStar)((Node)object_0).Edges).ComputeDepths(directedEdge);
		IEnumerator enumerator2 = ((Node)object_0).Edges.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			DirectedEdge obj = (DirectedEdge)enumerator2.Current;
			obj.IsVisited = true;
			smethod_2(obj);
		}
	}

	private static void smethod_2(DirectedEdge directedEdge_0)
	{
		DirectedEdge sym = directedEdge_0.Sym;
		sym.SetDepth(PositionType.Left, directedEdge_0.GetDepth(PositionType.Right));
		sym.SetDepth(PositionType.Right, directedEdge_0.GetDepth(PositionType.Left));
	}

	public virtual void FindResultEdges()
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.GetDepth(PositionType.Right) >= 1 && directedEdge.GetDepth(PositionType.Left) <= 0 && !directedEdge.IsInteriorAreaEdge)
			{
				directedEdge.IsInResult = true;
			}
		}
	}

	static BufferSubgraph()
	{
		Class72.smethod_20();
	}
}
