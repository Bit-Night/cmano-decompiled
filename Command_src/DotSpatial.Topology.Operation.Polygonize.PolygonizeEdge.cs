using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class PolygonizeEdge : Edge
{
	private readonly LineString lineString_0;

	public virtual LineString Line => lineString_0;

	public PolygonizeEdge(LineString line)
	{
		lineString_0 = line;
	}

	static PolygonizeEdge()
	{
		Class72.smethod_20();
	}
}
