using System.Collections.Generic;
using ConcaveHull;

namespace Command_Core;

public class AggregateGroundUnit_Frontline
{
	public List<AggregateGroundUnit_Engagment> Engagements;

	public List<Line> Convex;

	public List<Line> ConvexOp;

	public AggregateGroundUnit_Frontline()
	{
		Engagements = new List<AggregateGroundUnit_Engagment>();
		Convex = new List<Line>();
		ConvexOp = new List<Line>();
	}

	public void Reorder()
	{
		Convex = null;
		ConvexOp = null;
		if (Engagements.Count >= 3)
		{
			new List<Node>();
			List<Node> list = new List<Node>();
			new List<Node>();
			int num = Engagements.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Engagements[i].ComputeIntermediatePoints();
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(Engagements[i].BlueforPoint.Longitude, Engagements[i].BlueforPoint.Latitude);
				list.Add(new Node(mercatorPixel.x, mercatorPixel.y, i));
			}
			Hull.unused_nodes.Clear();
			Hull.hull_edges.Clear();
			Hull.hull_concave_edges.Clear();
			Hull.setConvexHull(list);
			Hull.setConcaveHull(0.5, 100000);
			Convex = new List<Line>();
			ConvexOp = new List<Line>();
			Convex.AddRange(Hull.hull_concave_edges);
		}
	}

	static AggregateGroundUnit_Frontline()
	{
		Class72.smethod_20();
	}
}
