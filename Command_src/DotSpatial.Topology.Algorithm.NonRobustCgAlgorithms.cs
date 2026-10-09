using System;

namespace DotSpatial.Topology.Algorithm;

public static class NonRobustCgAlgorithms
{
	public static bool IsPointInRing(Coordinate p, Coordinate[] ring)
	{
		int num = 0;
		int num2 = ring.Length;
		for (int i = 1; i < num2; i++)
		{
			int num3 = i - 1;
			Coordinate obj = ring[i];
			Coordinate coordinate = ring[num3];
			double num4 = obj.X - p.X;
			double num5 = obj.Y - p.Y;
			double num6 = coordinate.X - p.X;
			double num7 = coordinate.Y - p.Y;
			if ((num5 > 0.0 && num7 <= 0.0) || (num7 > 0.0 && num5 <= 0.0))
			{
				double num8 = (num4 * num7 - num6 * num5) / (num7 - num5);
				if (0.0 < num8)
				{
					num++;
				}
			}
		}
		return num % 2 == 1;
	}

	public static bool IsCcw(Coordinate[] ring)
	{
		int num = ring.Length - 1;
		if (num < 4)
		{
			return false;
		}
		Coordinate coordinate = ring[0];
		int num2 = 0;
		for (int i = 1; i <= num; i++)
		{
			Coordinate coordinate2 = ring[i];
			if (coordinate2.Y > coordinate.Y)
			{
				coordinate = coordinate2;
				num2 = i;
			}
		}
		int num3 = num2;
		do
		{
			num3 = (num3 - 1) % num;
		}
		while (ring[num3].Equals(coordinate) && num3 != num2);
		int num4 = num2;
		do
		{
			num4 = (num4 + 1) % num;
		}
		while (ring[num4].Equals(coordinate) && num4 != num2);
		Coordinate coordinate3 = ring[num3];
		Coordinate coordinate4 = ring[num4];
		if (!coordinate3.Equals(coordinate) && !coordinate4.Equals(coordinate) && !coordinate3.Equals(coordinate4))
		{
			double num5 = coordinate3.X - coordinate.X;
			double num6 = coordinate3.Y - coordinate.Y;
			double num7 = coordinate4.X - coordinate.X;
			double num8 = coordinate4.Y - coordinate.Y;
			double num9 = num7 * num6 - num8 * num5;
			if (num9 == 0.0)
			{
				return coordinate3.X > coordinate4.X;
			}
			return num9 > 0.0;
		}
		throw new ArgumentException("degenerate ring (does not contain 3 different points)");
	}

	public static int ComputeOrientation(Coordinate p1, Coordinate p2, Coordinate q)
	{
		double num = p2.X - p1.X;
		double num2 = p2.Y - p1.Y;
		double num3 = q.X - p2.X;
		double num4 = q.Y - p2.Y;
		double num5 = num * num4 - num3 * num2;
		if (num5 > 0.0)
		{
			return 1;
		}
		if (num5 < 0.0)
		{
			return -1;
		}
		return 0;
	}

	static NonRobustCgAlgorithms()
	{
		Class72.smethod_20();
	}
}
