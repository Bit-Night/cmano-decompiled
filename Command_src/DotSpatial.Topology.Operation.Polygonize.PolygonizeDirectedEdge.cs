using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class PolygonizeDirectedEdge : DirectedEdge
{
	private EdgeRing edgeRing_0;

	private long long_0 = -1L;

	private PolygonizeDirectedEdge polygonizeDirectedEdge_0;

	public virtual long Label
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public virtual PolygonizeDirectedEdge Next
	{
		get
		{
			return polygonizeDirectedEdge_0;
		}
		set
		{
			polygonizeDirectedEdge_0 = value;
		}
	}

	public virtual bool IsInRing => Ring != null;

	public virtual EdgeRing Ring
	{
		get
		{
			return edgeRing_0;
		}
		set
		{
			edgeRing_0 = value;
		}
	}

	public PolygonizeDirectedEdge(Node from, Node to, Coordinate directionPt, bool edgeDirection)
		: base(from, to, directionPt, edgeDirection)
	{
	}

	static PolygonizeDirectedEdge()
	{
		Class72.smethod_20();
	}
}
