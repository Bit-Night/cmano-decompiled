using System.Collections;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SimpleMcSweepLineIntersector : EdgeSetIntersector
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private int int_0;

	public override void ComputeIntersections(IList edges, SegmentIntersector si, bool testAllSegments)
	{
		if (testAllSegments)
		{
			Add(edges, null);
		}
		else
		{
			Add(edges);
		}
		method_1(si);
	}

	public override void ComputeIntersections(IList edges0, IList edges1, SegmentIntersector si)
	{
		Add(edges0, edges0);
		Add(edges1, edges1);
		method_1(si);
	}

	private void Add(IEnumerable edges)
	{
		IEnumerator enumerator = edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			Add(edge, edge);
		}
	}

	private void Add(IEnumerable edges, object edgeSet)
	{
		IEnumerator enumerator = edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			Add(edge, edgeSet);
		}
	}

	private void Add(Edge edge, object edgeSet)
	{
		MonotoneChainEdge monotoneChainEdge = edge.MonotoneChainEdge;
		int[] startIndexes = monotoneChainEdge.StartIndexes;
		for (int i = 0; i < startIndexes.Length - 1; i++)
		{
			MonotoneChain obj = new MonotoneChain(monotoneChainEdge, i);
			SweepLineEvent sweepLineEvent = new SweepLineEvent(edgeSet, monotoneChainEdge.GetMinX(i), null, obj);
			arrayList_0.Add(sweepLineEvent);
			arrayList_0.Add(new SweepLineEvent(edgeSet, monotoneChainEdge.GetMaxX(i), sweepLineEvent, obj));
		}
	}

	private void method_0()
	{
		arrayList_0.Sort();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsDelete)
			{
				sweepLineEvent.InsertEvent.DeleteEventIndex = i;
			}
		}
	}

	private void method_1(SegmentIntersector segmentIntersector_0)
	{
		int_0 = 0;
		method_0();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsInsert)
			{
				method_2(i, sweepLineEvent.DeleteEventIndex, sweepLineEvent, segmentIntersector_0);
			}
		}
	}

	private void method_2(int int_1, int int_2, SweepLineEvent sweepLineEvent_0, SegmentIntersector segmentIntersector_0)
	{
		MonotoneChain monotoneChain = (MonotoneChain)sweepLineEvent_0.Object;
		for (int i = int_1; i < int_2; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsInsert)
			{
				MonotoneChain mc = (MonotoneChain)sweepLineEvent.Object;
				_ = sweepLineEvent_0.EdgeSet;
				if (sweepLineEvent_0.EdgeSet == null || sweepLineEvent_0.EdgeSet != sweepLineEvent.EdgeSet)
				{
					monotoneChain.ComputeIntersections(mc, segmentIntersector_0);
					int_0++;
				}
			}
		}
	}

	static SimpleMcSweepLineIntersector()
	{
		Class72.smethod_20();
	}
}
