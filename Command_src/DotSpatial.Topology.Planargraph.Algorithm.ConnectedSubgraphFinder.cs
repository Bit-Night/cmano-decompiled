using System.Collections;
using DotSpatial.Topology.Operation.Polygonize;

namespace DotSpatial.Topology.Planargraph.Algorithm;

public class ConnectedSubgraphFinder
{
	private readonly PlanarGraph planarGraph_0;

	public ConnectedSubgraphFinder(PlanarGraph graph)
	{
		planarGraph_0 = graph;
	}

	public virtual IList GetConnectedSubgraphs()
	{
		IList list = new ArrayList();
		GraphComponent.SetVisited(planarGraph_0.GetNodeEnumerator(), visited: false);
		IEnumerator edgeEnumerator = planarGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Node fromNode = ((edgeEnumerator.Current as Edge) ?? throw new NullEdgeException()).GetDirEdge(0).FromNode;
			if (!fromNode.IsVisited)
			{
				list.Add(method_0(fromNode));
			}
		}
		return list;
	}

	private Subgraph method_0(Node node_0)
	{
		Subgraph subgraph = new Subgraph(planarGraph_0);
		smethod_0(node_0, subgraph);
		return subgraph;
	}

	private static void smethod_0(object object_0, Subgraph subgraph_0)
	{
		Stack stack = new Stack();
		stack.Push(object_0);
		while (stack.Count != 0)
		{
			smethod_1((Node)stack.Pop(), stack, subgraph_0);
		}
	}

	private static void smethod_1(object object_0, Stack stack_0, Subgraph subgraph_0)
	{
		((GraphComponent)object_0).IsVisited = true;
		IEnumerator enumerator = ((Node)object_0).OutEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			subgraph_0.Add(directedEdge.Edge);
			Node toNode = directedEdge.ToNode;
			if (!toNode.IsVisited)
			{
				stack_0.Push(toNode);
			}
		}
	}

	static ConnectedSubgraphFinder()
	{
		Class72.smethod_20();
	}
}
