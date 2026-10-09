using System.Collections.Generic;

namespace Simplifynet;

public sealed class SimplifyUtility3D : ISimplifyUtility
{
	private double method_0(Point point_0, Point point_1)
	{
		double num = point_0.X - point_1.X;
		double num2 = point_0.Y - point_1.Y;
		double num3 = point_0.Z - point_1.Z;
		return num * num + num2 * num2 + num3 * num3;
	}

	private double GaZyoUhBwBT(Point point_0, Point point_1, Point point_2)
	{
		double num = point_1.X;
		double num2 = point_1.Y;
		double num3 = point_1.Z;
		double num4 = point_2.X - num;
		double num5 = point_2.Y - num2;
		double num6 = point_2.Z - num3;
		if (!num4.Equals(0.0) || !num5.Equals(0.0) || !num6.Equals(0.0))
		{
			double num7 = ((point_0.X - num) * num4 + (point_0.Y - num2) * num5 + (point_0.Z - num3) * num6) / (num4 * num4 + num5 * num5 + num6 * num6);
			if (num7 > 1.0)
			{
				num = point_2.X;
				num2 = point_2.Y;
				num3 = point_2.Z;
			}
			else if (num7 > 0.0)
			{
				num += num4 * num7;
				num2 += num5 * num7;
				num3 += num6 * num7;
			}
		}
		num4 = point_0.X - num;
		num5 = point_0.Y - num2;
		num6 = point_0.Z - num3;
		return num4 * num4 + num5 * num5 + num6 * num6;
	}

	private List<Point> method_1(Point[] point_0, double double_0)
	{
		Point point = point_0[0];
		List<Point> list = new List<Point> { point };
		Point point2 = null;
		for (int i = 1; i < point_0.Length; i++)
		{
			point2 = point_0[i];
			if (method_0(point2, point) > double_0)
			{
				list.Add(point2);
				point = point2;
			}
		}
		if (point2 != null && !point.Equals(point2))
		{
			list.Add(point2);
		}
		return list;
	}

	private List<Point> method_2(Point[] point_0, double double_0)
	{
		int num = point_0.Length;
		int?[] array = new int?[num];
		int? num2 = 0;
		int? num3 = num - 1;
		int? num4 = 0;
		List<int?> list = new List<int?>();
		List<Point> list2 = new List<Point>();
		array[num2.Value] = (array[num3.Value] = 1);
		while (num3.HasValue)
		{
			double num5 = 0.0;
			for (int? num6 = num2 + 1; num6 < num3; num6++)
			{
				double num7 = GaZyoUhBwBT(point_0[num6.Value], point_0[num2.Value], point_0[num3.Value]);
				if (num7 > num5)
				{
					num4 = num6;
					num5 = num7;
				}
			}
			if (num5 > double_0)
			{
				array[num4.Value] = 1;
				list.AddRange(new int?[4] { num2, num4, num4, num3 });
			}
			if (list.Count > 0)
			{
				num3 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
			}
			else
			{
				num3 = null;
			}
			if (list.Count > 0)
			{
				num2 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
			}
			else
			{
				num2 = null;
			}
		}
		for (int i = 0; i < num; i++)
		{
			if (array[i].HasValue)
			{
				list2.Add(point_0[i]);
			}
		}
		return list2;
	}

	public List<Point> Simplify(Point[] points, double tolerance = 0.3, bool highestQuality = false)
	{
		if (points != null && points.Length != 0)
		{
			double double_ = tolerance * tolerance;
			if (!highestQuality)
			{
				List<Point> list = method_1(points, double_);
				return method_2(list.ToArray(), double_);
			}
			return method_2(points, double_);
		}
		return new List<Point>();
	}

	public static List<Point> SimplifyArray(Point[] points, double tolerance = 0.3, bool highestQuality = false)
	{
		return new SimplifyUtility().Simplify(points, tolerance, highestQuality);
	}

	static SimplifyUtility3D()
	{
		Class72.smethod_20();
	}
}
