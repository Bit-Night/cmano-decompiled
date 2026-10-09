using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SimpleEdgeSetIntersector : EdgeSetIntersector
{
	public override void ComputeIntersections(IList edges, SegmentIntersector si, bool testAllSegments)
	{
		IEnumerator enumerator = edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			IEnumerator enumerator2 = edges.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Edge edge2 = (Edge)enumerator2.Current;
				if (testAllSegments || edge != edge2)
				{
					smethod_0(edge, edge2, si);
				}
			}
		}
	}

	public override void ComputeIntersections(IList edges0, IList edges1, SegmentIntersector si)
	{
		IEnumerator enumerator = edges0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge_ = (Edge)enumerator.Current;
			IEnumerator enumerator2 = edges1.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Edge edge_2 = (Edge)enumerator2.Current;
				smethod_0(edge_, edge_2, si);
			}
		}
	}

	private static void smethod_0(Edge edge_0, Edge edge_1, SegmentIntersector segmentIntersector_0)
	{
		IList<Coordinate> coordinates = edge_0.Coordinates;
		IList<Coordinate> coordinates2 = edge_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				segmentIntersector_0.AddIntersections(edge_0, i, edge_1, j);
			}
		}
	}

	static SimpleEdgeSetIntersector()
	{
		Class72.smethod_20();
	}
}
