namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChain
{
	private readonly int int_0;

	private readonly MonotoneChainEdge monotoneChainEdge_0;

	public MonotoneChain(MonotoneChainEdge mce, int chainIndex)
	{
		monotoneChainEdge_0 = mce;
		int_0 = chainIndex;
	}

	public virtual void ComputeIntersections(MonotoneChain mc, SegmentIntersector si)
	{
		monotoneChainEdge_0.ComputeIntersectsForChain(int_0, mc.monotoneChainEdge_0, mc.int_0, si);
	}

	static MonotoneChain()
	{
		Class72.smethod_20();
	}
}
