using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChainEdge
{
	private readonly Edge edge_0;

	private readonly Envelope envelope_0 = new Envelope();

	private readonly Envelope envelope_1 = new Envelope();

	private readonly IList<Coordinate> ilist_0;

	private readonly int[] int_0;

	public virtual IList<Coordinate> Coordinates => ilist_0;

	public virtual int[] StartIndexes => int_0;

	public MonotoneChainEdge(Edge e)
	{
		edge_0 = e;
		ilist_0 = e.Coordinates;
		MonotoneChainIndexer monotoneChainIndexer = new MonotoneChainIndexer();
		int_0 = monotoneChainIndexer.GetChainStartIndices(ilist_0);
	}

	public virtual double GetMinX(int chainIndex)
	{
		double x = ilist_0[int_0[chainIndex]].X;
		double x2 = ilist_0[int_0[chainIndex + 1]].X;
		if (!(x < x2))
		{
			return x2;
		}
		return x;
	}

	public virtual double GetMaxX(int chainIndex)
	{
		double x = ilist_0[int_0[chainIndex]].X;
		double x2 = ilist_0[int_0[chainIndex + 1]].X;
		if (!(x <= x2))
		{
			return x;
		}
		return x2;
	}

	public virtual void ComputeIntersects(MonotoneChainEdge mce, SegmentIntersector si)
	{
		for (int i = 0; i < int_0.Length - 1; i++)
		{
			for (int j = 0; j < mce.int_0.Length - 1; j++)
			{
				ComputeIntersectsForChain(i, mce, j, si);
			}
		}
	}

	public virtual void ComputeIntersectsForChain(int chainIndex0, MonotoneChainEdge mce, int chainIndex1, SegmentIntersector si)
	{
		method_0(int_0[chainIndex0], int_0[chainIndex0 + 1], mce, mce.int_0[chainIndex1], mce.int_0[chainIndex1 + 1], si);
	}

	private void method_0(int int_1, int int_2, MonotoneChainEdge monotoneChainEdge_0, int int_3, int int_4, SegmentIntersector segmentIntersector_0)
	{
		Coordinate p = ilist_0[int_1];
		Coordinate p2 = ilist_0[int_2];
		Coordinate p3 = monotoneChainEdge_0.ilist_0[int_3];
		Coordinate p4 = monotoneChainEdge_0.ilist_0[int_4];
		if (int_2 - int_1 == 1 && int_4 - int_3 == 1)
		{
			segmentIntersector_0.AddIntersections(edge_0, int_1, monotoneChainEdge_0.edge_0, int_3);
			return;
		}
		envelope_0.Init(p, p2);
		envelope_1.Init(p3, p4);
		if (!envelope_0.Intersects(envelope_1))
		{
			return;
		}
		int num = (int_1 + int_2) / 2;
		int num2 = (int_3 + int_4) / 2;
		if (int_1 < num)
		{
			if (int_3 < num2)
			{
				method_0(int_1, num, monotoneChainEdge_0, int_3, num2, segmentIntersector_0);
			}
			if (num2 < int_4)
			{
				method_0(int_1, num, monotoneChainEdge_0, num2, int_4, segmentIntersector_0);
			}
		}
		if (num < int_2)
		{
			if (int_3 < num2)
			{
				method_0(num, int_2, monotoneChainEdge_0, int_3, num2, segmentIntersector_0);
			}
			if (num2 < int_4)
			{
				method_0(num, int_2, monotoneChainEdge_0, num2, int_4, segmentIntersector_0);
			}
		}
	}

	static MonotoneChainEdge()
	{
		Class72.smethod_20();
	}
}
