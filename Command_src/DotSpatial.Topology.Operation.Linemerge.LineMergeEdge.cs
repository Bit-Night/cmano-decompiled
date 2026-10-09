using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMergeEdge : Edge
{
	private readonly LineString lineString_0;

	public virtual LineString Line => lineString_0;

	public LineMergeEdge(LineString line)
	{
		lineString_0 = line;
	}

	static LineMergeEdge()
	{
		Class72.smethod_20();
	}
}
