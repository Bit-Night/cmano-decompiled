using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SweepLineSegment
{
	private readonly Edge edge_0;

	private readonly int int_0;

	private readonly IList<Coordinate> ilist_0;

	public virtual double MinX
	{
		get
		{
			double x = ilist_0[int_0].X;
			double x2 = ilist_0[int_0 + 1].X;
			if (!(x >= x2))
			{
				return x;
			}
			return x2;
		}
	}

	public virtual double MaxX
	{
		get
		{
			double x = ilist_0[int_0].X;
			double x2 = ilist_0[int_0 + 1].X;
			if (!(x <= x2))
			{
				return x;
			}
			return x2;
		}
	}

	public SweepLineSegment(Edge edge, int ptIndex)
	{
		edge_0 = edge;
		int_0 = ptIndex;
		ilist_0 = edge.Coordinates;
	}

	public virtual void ComputeIntersections(SweepLineSegment ss, SegmentIntersector si)
	{
		si.AddIntersections(edge_0, int_0, ss.edge_0, ss.int_0);
	}

	static SweepLineSegment()
	{
		Class72.smethod_20();
	}
}
