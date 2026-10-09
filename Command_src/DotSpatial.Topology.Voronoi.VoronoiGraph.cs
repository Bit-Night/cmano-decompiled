namespace DotSpatial.Topology.Voronoi;

public class VoronoiGraph
{
	public readonly HashSet<VoronoiEdge> Edges = new HashSet<VoronoiEdge>();

	public readonly HashSet<Vector2> Vertices = new HashSet<Vector2>();

	static VoronoiGraph()
	{
		Class72.smethod_20();
	}
}
