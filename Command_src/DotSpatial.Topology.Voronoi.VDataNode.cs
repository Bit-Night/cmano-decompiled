namespace DotSpatial.Topology.Voronoi;

internal class VDataNode : VNode
{
	public readonly Vector2 DataPoint;

	public VDataNode(Vector2 dp)
	{
		DataPoint = dp;
	}

	static VDataNode()
	{
		Class72.smethod_20();
	}
}
