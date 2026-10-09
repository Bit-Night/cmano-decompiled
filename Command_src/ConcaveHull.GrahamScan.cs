using System;
using System.Collections.Generic;

namespace ConcaveHull;

public static class GrahamScan
{
	public static int turn(Node p, Node q, Node r)
	{
		return ((q.x - p.x) * (r.y - p.y) - (r.x - p.x) * (q.y - p.y)).CompareTo(0.0);
	}

	public static void keepLeft(List<Node> hull, Node r)
	{
		while (hull.Count > 1 && turn(hull[hull.Count - 2], hull[hull.Count - 1], r) != 1)
		{
			hull.RemoveAt(hull.Count - 1);
		}
		if (hull.Count == 0 || hull[hull.Count - 1] != r)
		{
			hull.Add(r);
		}
	}

	public static double getAngle(Node p1, Node p2)
	{
		double x = p2.x - p1.x;
		return Math.Atan2(p2.y - p1.y, x) * 180.0 / Math.PI;
	}

	public static List<Node> MergeSort(Node p0, List<Node> arrPoint)
	{
		if (arrPoint.Count == 1)
		{
			return arrPoint;
		}
		List<Node> list = new List<Node>();
		int num = arrPoint.Count / 2;
		List<Node> range = arrPoint.GetRange(0, num);
		List<Node> range2 = arrPoint.GetRange(num, arrPoint.Count - num);
		range = MergeSort(p0, range);
		range2 = MergeSort(p0, range2);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < range.Count + range2.Count; i++)
		{
			if (num2 == range.Count)
			{
				list.Add(range2[num3]);
				num3++;
			}
			else if (num3 == range2.Count)
			{
				list.Add(range[num2]);
				num2++;
			}
			else if (getAngle(p0, range[num2]) < getAngle(p0, range2[num3]))
			{
				list.Add(range[num2]);
				num2++;
			}
			else
			{
				list.Add(range2[num3]);
				num3++;
			}
		}
		return list;
	}

	public static List<Node> convexHull(List<Node> points)
	{
		Node node = null;
		foreach (Node point in points)
		{
			if (node != null)
			{
				if (node.y > point.y)
				{
					node = point;
				}
			}
			else
			{
				node = point;
			}
		}
		List<Node> list = new List<Node>();
		foreach (Node point2 in points)
		{
			if (node != point2)
			{
				list.Add(point2);
			}
		}
		list = MergeSort(node, list);
		List<Node> list2 = new List<Node>();
		list2.Add(node);
		list2.Add(list[0]);
		list2.Add(list[1]);
		list.RemoveAt(0);
		list.RemoveAt(0);
		foreach (Node item in list)
		{
			keepLeft(list2, item);
		}
		return list2;
	}

	static GrahamScan()
	{
		Class72.smethod_20();
	}
}
