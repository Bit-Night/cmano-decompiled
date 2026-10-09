using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public static class CgAlgorithms
{
	public const int CLOCKWISE = -1;

	public const int RIGHT = -1;

	public const int COUNTER_CLOCKWISE = 1;

	public const int LEFT = 1;

	public const int COLLINEAR = 0;

	public const int STRAIGHT = 0;

	public static int OrientationIndex(Coordinate p1, Coordinate p2, Coordinate q)
	{
		double x = p2.X - p1.X;
		double y = p2.Y - p1.Y;
		double x2 = q.X - p2.X;
		double y2 = q.Y - p2.Y;
		return RobustDeterminant.SignOfDet2X2(x, y, x2, y2);
	}

	public static bool IsPointInRing(Coordinate p, IList<Coordinate> ring)
	{
		int num = 0;
		int count = ring.Count;
		for (int i = 1; i < count; i++)
		{
			int index = i - 1;
			Coordinate coordinate = ring[i];
			Coordinate coordinate2 = ring[index];
			double x = coordinate.X - p.X;
			double num2 = coordinate.Y - p.Y;
			double x2 = coordinate2.X - p.X;
			double num3 = coordinate2.Y - p.Y;
			if ((num2 > 0.0 && num3 <= 0.0) || (num3 > 0.0 && num2 <= 0.0))
			{
				double num4 = (double)RobustDeterminant.SignOfDet2X2(x, num2, x2, num3) / (num3 - num2);
				if (0.0 < num4)
				{
					num++;
				}
			}
		}
		if (num % 2 == 1)
		{
			return true;
		}
		return false;
	}

	public static bool IsOnLine(Coordinate p, IList<Coordinate> pt)
	{
		LineIntersector lineIntersector = new RobustLineIntersector();
		int num = 1;
		while (true)
		{
			if (num < pt.Count)
			{
				Coordinate p2 = pt[num - 1];
				Coordinate p3 = pt[num];
				lineIntersector.ComputeIntersection(p, p2, p3);
				if (lineIntersector.HasIntersection)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool IsCounterClockwise(IList<Coordinate> ring)
	{
		int num = ring.Count - 1;
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
			num3--;
			if (num3 < 0)
			{
				num3 = num;
			}
		}
		while (ring[num3].Equals2D(coordinate) && num3 != num2);
		int num4 = num2;
		do
		{
			num4 = (num4 + 1) % num;
		}
		while (ring[num4].Equals2D(coordinate) && num4 != num2);
		Coordinate coordinate3 = new Coordinate(ring[num3]);
		Coordinate coordinate4 = new Coordinate(ring[num4]);
		int result;
		if (coordinate3.Equals2D(coordinate))
		{
			result = 0;
		}
		else if (!coordinate4.Equals2D(coordinate))
		{
			if (!coordinate3.Equals2D(coordinate4))
			{
				int num5 = OrientationIndex(coordinate3, new Coordinate(coordinate), coordinate4);
				if (num5 != 0)
				{
					return num5 > 0;
				}
				return coordinate3.X > coordinate4.X;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static int ComputeOrientation(Coordinate p1, Coordinate p2, Coordinate q)
	{
		return OrientationIndex(p1, p2, q);
	}

	public static double DistancePointLine(Coordinate p, Coordinate a, Coordinate b)
	{
		if (!a.Equals(b))
		{
			double num = ((p.X - a.X) * (b.X - a.X) + (p.Y - a.Y) * (b.Y - a.Y)) / ((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
			if (num <= 0.0)
			{
				return p.Distance(a);
			}
			if (num >= 1.0)
			{
				return p.Distance(b);
			}
			return Math.Abs(((a.Y - p.Y) * (b.X - a.X) - (a.X - p.X) * (b.Y - a.Y)) / ((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y))) * Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
		}
		return p.Distance(a);
	}

	public static double DistancePointLinePerpendicular(Coordinate p, Coordinate a, Coordinate b)
	{
		return Math.Abs(((a.Y - p.Y) * (b.X - a.X) - (a.X - p.X) * (b.Y - a.Y)) / ((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y))) * Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
	}

	public static double DistanceLineLine(Coordinate a, Coordinate b, Coordinate c, Coordinate d)
	{
		if (!a.Equals(b))
		{
			if (c.Equals(d))
			{
				return DistancePointLine(d, a, b);
			}
			double num = (a.Y - c.Y) * (d.X - c.X) - (a.X - c.X) * (d.Y - c.Y);
			double num2 = (b.X - a.X) * (d.Y - c.Y) - (b.Y - a.Y) * (d.X - c.X);
			double num3 = (a.Y - c.Y) * (b.X - a.X) - (a.X - c.X) * (b.Y - a.Y);
			double num4 = (b.X - a.X) * (d.Y - c.Y) - (b.Y - a.Y) * (d.X - c.X);
			if (num2 != 0.0 && num4 != 0.0)
			{
				double num5 = num3 / num4;
				double num6 = num / num2;
				if (!(num6 < 0.0) && !(num6 > 1.0) && !(num5 < 0.0) && num5 <= 1.0)
				{
					return 0.0;
				}
				return Math.Min(DistancePointLine(a, c, d), Math.Min(DistancePointLine(b, c, d), Math.Min(DistancePointLine(c, a, b), DistancePointLine(d, a, b))));
			}
			return Math.Min(DistancePointLine(a, c, d), Math.Min(DistancePointLine(b, c, d), Math.Min(DistancePointLine(c, a, b), DistancePointLine(d, a, b))));
		}
		return DistancePointLine(a, c, d);
	}

	public static double SignedArea(IList<Coordinate> ring)
	{
		if (ring.Count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < ring.Count - 1; i++)
		{
			double x = ring[i].X;
			double y = ring[i].Y;
			double x2 = ring[i + 1].X;
			double y2 = ring[i + 1].Y;
			num += (x + x2) * (y2 - y);
		}
		Coordinate coordinate = ring[ring.Count - 1];
		Coordinate coordinate2 = ring[0];
		if (coordinate2.X != coordinate.X && coordinate2.Y != coordinate.Y)
		{
			num += (coordinate.X + coordinate2.X) * (coordinate2.Y - coordinate.Y);
		}
		return (0.0 - num) / 2.0;
	}

	public static double Length(IList<Coordinate> pts)
	{
		if (pts.Count >= 1)
		{
			double num = 0.0;
			for (int i = 1; i < pts.Count; i++)
			{
				num += pts[i].Distance(pts[i - 1]);
			}
			return num;
		}
		return 0.0;
	}

	static CgAlgorithms()
	{
		Class72.smethod_20();
	}
}
