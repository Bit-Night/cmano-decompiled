using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class IntersectMethods
{
	public static bool IntersectLines(Segment s0, Segment s1, out Intersection2D interObj)
	{
		double num = (s0.P1.X - s0.P0.X) * (s1.P1.Y - s1.P0.Y) - (s0.P1.Y - s0.P0.Y) * (s1.P1.X - s1.P0.X);
		double num2 = (s0.P0.Y - s1.P0.Y) * (s1.P1.X - s1.P0.X) - (s0.P0.X - s1.P0.X) * (s1.P1.Y - s1.P0.Y);
		double num3 = (s0.P0.Y - s1.P0.Y) * (s0.P1.X - s0.P0.X) - (s0.P0.X - s1.P0.X) * (s0.P1.Y - s0.P0.Y);
		if (System.Math.Abs(num) <= 4.76837158203125E-07)
		{
			System.Math.Abs(num2);
			interObj = new Intersection2D();
			return false;
		}
		num2 /= num;
		num3 /= num;
		interObj = new Intersection2D(new Vector2D(s0.P0 + num2 * (s0.P1 - s0.P0)));
		return true;
	}

	public static bool Intersect(Segment s0, Segment s1, out Intersection2D interObj)
	{
		double num = (s0.P1.X - s0.P0.X) * (s1.P1.Y - s1.P0.Y) - (s0.P1.Y - s0.P0.Y) * (s1.P1.X - s1.P0.X);
		double num2 = (s0.P0.Y - s1.P0.Y) * (s1.P1.X - s1.P0.X) - (s0.P0.X - s1.P0.X) * (s1.P1.Y - s1.P0.Y);
		double num3 = (s0.P0.Y - s1.P0.Y) * (s0.P1.X - s0.P0.X) - (s0.P0.X - s1.P0.X) * (s0.P1.Y - s0.P0.Y);
		if (System.Math.Abs(num) < 4.76837158203125E-07)
		{
			if (System.Math.Abs(num2) < 4.76837158203125E-07)
			{
				Interval interval = new Interval(Interval.Type.Closed, System.Math.Min(s0.P0.X, s0.P1.X), System.Math.Max(s0.P0.X, s0.P1.X));
				Interval interval2 = new Interval(Interval.Type.Closed, System.Math.Min(s1.P0.X, s1.P1.X), System.Math.Max(s1.P0.X, s1.P1.X));
				if (!(interval.Max < interval2.Min) && interval2.Max >= interval.Min)
				{
					new Interval(Interval.Type.Closed, System.Math.Max(interval.Min, interval2.Min), System.Math.Min(interval.Max, interval2.Max));
					interObj = new Intersection2D(default(Segment));
					return true;
				}
				interObj = new Intersection2D();
				return false;
			}
			interObj = new Intersection2D();
			return false;
		}
		num2 /= num;
		num3 /= num;
		if (0.0 <= num2 && num2 <= 1.0 && 0.0 <= num3 && num3 <= 1.0)
		{
			interObj = new Intersection2D(new Vector2D(s0.P0 + num2 * (s0.P1 - s0.P0)));
			return true;
		}
		interObj = new Intersection2D();
		return false;
	}

	public static bool Intersect(Segment seg, Ray ray, out Intersection2D interObj)
	{
		double num = (seg.P1.X - seg.P0.X) * ray.Direction.Y - (seg.P1.Y - seg.P0.Y) * ray.Direction.X;
		double num2 = (seg.P0.Y - ray.Origin.Y) * ((ray.Origin + ray.Direction).X - ray.Origin.X) - (seg.P0.X - ray.Origin.X) * ((ray.Origin + ray.Direction).Y - ray.Origin.Y);
		if (System.Math.Abs(num) < 4.76837158203125E-07)
		{
			if (System.Math.Abs(num2) < 4.76837158203125E-07)
			{
				interObj = new Intersection2D(new Segment(seg));
				return true;
			}
			interObj = new Intersection2D();
			return false;
		}
		num2 /= num;
		if (0.0 <= num2 && num2 <= 1.0)
		{
			interObj = new Intersection2D(new Vector2D(seg.P0 + num2 * (seg.P1 - seg.P0)));
			return true;
		}
		interObj = new Intersection2D();
		return false;
	}

	static IntersectMethods()
	{
		Class72.smethod_20();
	}
}
