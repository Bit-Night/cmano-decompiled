using System.Collections;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public abstract class EdgeSetIntersector
{
	public abstract void ComputeIntersections(IList edges, SegmentIntersector si, bool testAllSegments);

	public abstract void ComputeIntersections(IList edges0, IList edges1, SegmentIntersector si);

	static EdgeSetIntersector()
	{
		Class72.smethod_20();
	}
}
