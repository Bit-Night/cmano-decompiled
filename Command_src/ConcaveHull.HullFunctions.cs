using System;
using System.Collections.Generic;
using System.Linq;

namespace ConcaveHull;

public static class HullFunctions
{
	public static List<Line> getDividedLine(Line line, List<Node> nearbyPoints, List<Line> concave_hull, double concavity)
	{
		List<Line> list = new List<Line>();
		List<Node> list2 = new List<Node>();
		foreach (Node nearbyPoint in nearbyPoints)
		{
			double num = smethod_0(line.nodes[0], line.nodes[1], nearbyPoint);
			if (num < concavity)
			{
				Line line2 = new Line(line.nodes[0], nearbyPoint);
				Line line3 = new Line(nearbyPoint, line.nodes[1]);
				if (!lineCollidesWithHull(line2, concave_hull) && !lineCollidesWithHull(line3, concave_hull))
				{
					nearbyPoint.cos = num;
					list2.Add(nearbyPoint);
				}
			}
		}
		if (list2.Count > 0)
		{
			list2 = list2.OrderBy((Node p) => p.cos).ToList();
			list.Add(new Line(line.nodes[0], list2[0]));
			list.Add(new Line(list2[0], line.nodes[1]));
		}
		return list;
	}

	public static bool lineCollidesWithHull(Line line, List<Line> concave_hull)
	{
		foreach (Line item in concave_hull)
		{
			if (line.nodes[0].id != item.nodes[0].id && line.nodes[0].id != item.nodes[1].id && line.nodes[1].id != item.nodes[0].id && line.nodes[1].id != item.nodes[1].id && LineIntersectionFunctions.doIntersect(line.nodes[0], line.nodes[1], item.nodes[0], item.nodes[1]))
			{
				return true;
			}
		}
		return false;
	}

	private static double smethod_0(object object_0, object object_1, object object_2)
	{
		double num = Math.Pow(((Node)object_0).x - ((Node)object_2).x, 2.0) + Math.Pow(((Node)object_0).y - ((Node)object_2).y, 2.0);
		double num2 = Math.Pow(((Node)object_1).x - ((Node)object_2).x, 2.0) + Math.Pow(((Node)object_1).y - ((Node)object_2).y, 2.0);
		double num3 = Math.Pow(((Node)object_0).x - ((Node)object_1).x, 2.0) + Math.Pow(((Node)object_0).y - ((Node)object_1).y, 2.0);
		return Math.Round((num + num2 - num3) / (2.0 * Math.Sqrt(num * num2)), 4);
	}

	public static List<Node> getNearbyPoints(Line line, List<Node> nodeList, int scaleFactor)
	{
		List<Node> list = new List<Node>();
		for (int i = 0; i < 2; i++)
		{
			if (list.Count != 0)
			{
				break;
			}
			double[] array = smethod_1((Node[])(object)line, scaleFactor);
			foreach (Node node in nodeList)
			{
				if ((node.x != line.nodes[0].x || node.y != line.nodes[0].y) && (node.x != line.nodes[1].x || node.y != line.nodes[1].y))
				{
					double num = Math.Floor(node.x / (double)scaleFactor);
					double num2 = Math.Floor(node.y / (double)scaleFactor);
					if (num >= array[0] && num <= array[2] && num2 >= array[1] && num2 <= array[3])
					{
						list.Add(node);
					}
				}
			}
			scaleFactor = scaleFactor * 4 / 3;
		}
		return list;
	}

	private static double[] smethod_1(Node[] node_0, int int_0)
	{
		double[] array = new double[4];
		Node obj = ((Line)(object)node_0).nodes[0];
		Node node = ((Line)(object)node_0).nodes[1];
		double num = Math.Floor(Math.Min(obj.x, node.x) / (double)int_0);
		double num2 = Math.Floor(Math.Min(obj.y, node.y) / (double)int_0);
		double num3 = Math.Floor(Math.Max(obj.x, node.x) / (double)int_0);
		double num4 = Math.Floor(Math.Max(obj.y, node.y) / (double)int_0);
		array[0] = num;
		array[1] = num2;
		array[2] = num3;
		array[3] = num4;
		return array;
	}

	static HullFunctions()
	{
		Class72.smethod_20();
	}
}
