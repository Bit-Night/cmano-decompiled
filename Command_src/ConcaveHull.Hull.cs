using System.Collections.Generic;
using System.Linq;

namespace ConcaveHull;

public static class Hull
{
	public static List<Node> unused_nodes;

	public static List<Line> hull_edges;

	public static List<Line> hull_concave_edges;

	public static List<Line> getHull(List<Node> nodes)
	{
		List<Node> list = new List<Node>();
		List<Line> list2 = new List<Line>();
		list = new List<Node>();
		list.AddRange(GrahamScan.convexHull(nodes));
		for (int i = 0; i < list.Count - 1; i++)
		{
			list2.Add(new Line(list[i], list[i + 1]));
		}
		list2.Add(new Line(list[0], list[list.Count - 1]));
		return list2;
	}

	public static void setConvexHull(List<Node> nodes)
	{
		unused_nodes.AddRange(nodes);
		hull_edges.AddRange(getHull(nodes));
		foreach (Line hull_edge in hull_edges)
		{
			Node[] nodes2 = hull_edge.nodes;
			foreach (Node node_0 in nodes2)
			{
				unused_nodes.RemoveAll((Node a) => a.id == node_0.id);
			}
		}
	}

	public static List<Line> setConcaveHull(double concavity, int scaleFactor)
	{
		hull_concave_edges.AddRange(hull_edges);
		int num = 0;
		while (true)
		{
			bool flag = (byte)num != 0;
			for (int i = 0; i < hull_concave_edges.Count; i++)
			{
				if (flag)
				{
					break;
				}
				Line line = hull_concave_edges[i];
				List<Node> nearbyPoints = HullFunctions.getNearbyPoints(line, unused_nodes, scaleFactor);
				List<Line> list_0 = HullFunctions.getDividedLine(line, nearbyPoints, hull_concave_edges, concavity);
				if (list_0.Count > 0)
				{
					flag = true;
					unused_nodes.Remove(unused_nodes.Where((Node n) => n.id == list_0[0].nodes[1].id).FirstOrDefault());
					hull_concave_edges.AddRange(list_0);
					hull_concave_edges.RemoveAt(i);
				}
			}
			hull_concave_edges = hull_concave_edges.OrderByDescending((Line a) => Line.getLength(a.nodes[0], a.nodes[1])).ToList();
			if (!flag)
			{
				break;
			}
			num = 0;
		}
		return hull_concave_edges;
	}

	static Hull()
	{
		Class72.smethod_20();
		unused_nodes = new List<Node>();
		hull_edges = new List<Line>();
		hull_concave_edges = new List<Line>();
	}
}
