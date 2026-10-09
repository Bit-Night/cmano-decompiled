namespace DotSpatial.Topology.Voronoi;

internal class VEdgeNode : VNode
{
	public readonly VoronoiEdge Edge;

	public readonly bool Flipped;

	public VEdgeNode(VoronoiEdge e, bool flipped)
	{
		Edge = e;
		Flipped = flipped;
	}

	public double Cut(double ys, double x)
	{
		if (!Flipped)
		{
			return x - Fortune.ParabolicCut(Edge.LeftData.X, Edge.LeftData.Y, Edge.RightData.X, Edge.RightData.Y, ys);
		}
		return x - Fortune.ParabolicCut(Edge.RightData.X, Edge.RightData.Y, Edge.LeftData.X, Edge.LeftData.Y, ys);
	}

	static VEdgeNode()
	{
		Class72.smethod_20();
	}
}
