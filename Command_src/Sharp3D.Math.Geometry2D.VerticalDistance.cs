using System;
using System.Collections.Generic;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class VerticalDistance
{
	public static bool PointToAboveSegment(Vector2D p, Segment seg, ref double distance)
	{
		double num = System.Math.Min(seg.P0.X, seg.P1.X);
		double num2 = System.Math.Max(seg.P0.X, seg.P1.X);
		int result2;
		if (!(p.X < num - 4.76837158203125E-07))
		{
			if (!(p.X > num2 + 4.76837158203125E-07))
			{
				double num3 = System.Math.Min(seg.P0.Y, seg.P1.Y);
				double num4 = System.Math.Max(seg.P0.Y, seg.P1.Y);
				int result;
				if (System.Math.Abs(seg.P1.X - seg.P0.X) < 4.76837158203125E-07)
				{
					if (p.Y < num3)
					{
						distance = num3 - p.Y;
						result = 1;
					}
					else if (p.Y > num4)
					{
						distance = num4 - p.Y;
						result = 1;
					}
					else
					{
						distance = 0.0;
						result = 1;
					}
				}
				else
				{
					distance = seg.P0.Y + (p.X - seg.P0.X) * (seg.P1.Y - seg.P0.Y) / (seg.P1.X - seg.P0.X) - p.Y;
					result = 1;
				}
				return (byte)result != 0;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	public static bool PointToAboveArc(Vector2D p, Arc arc, ref double distance)
	{
		bool result = false;
		distance = double.MaxValue;
		foreach (Segment item in (IEnumerable<Segment>)arc.Explode(20))
		{
			double distance2 = 0.0;
			if (PointToAboveSegment(p, item, ref distance2) && distance2 > 0.0)
			{
				distance = System.Math.Min(distance2, distance);
				result = true;
			}
		}
		return result;
	}

	public static bool SegmentToAboveSegment(Segment seg, Segment segAbove, ref double distance)
	{
		bool result = false;
		distance = double.MaxValue;
		double distance2 = 0.0;
		if (PointToAboveSegment(seg.P0, segAbove, ref distance2) && distance2 >= 0.0)
		{
			distance = System.Math.Min(distance, distance2);
			result = true;
		}
		if (PointToAboveSegment(seg.P1, segAbove, ref distance2) && distance2 >= 0.0)
		{
			distance = System.Math.Min(distance, distance2);
			result = true;
		}
		if (PointToAboveSegment(segAbove.P0, seg, ref distance2) && distance2 <= 0.0)
		{
			distance = System.Math.Min(distance, 0.0 - distance2);
			result = true;
		}
		if (PointToAboveSegment(segAbove.P1, seg, ref distance2) && distance2 <= 0.0)
		{
			distance = System.Math.Min(distance, 0.0 - distance2);
			result = true;
		}
		return result;
	}

	public static bool SegmentToAboveArc(Segment seg, Arc arcAbove, ref double distance)
	{
		bool result = false;
		distance = double.MaxValue;
		foreach (Segment item in arcAbove.Explode(20))
		{
			double distance2 = 0.0;
			if (PointToAboveSegment(seg.P0, item, ref distance2) && distance2 > 0.0)
			{
				distance = System.Math.Min(distance, distance2);
				result = true;
			}
			if (PointToAboveSegment(seg.P1, item, ref distance2) && distance2 > 0.0)
			{
				distance = System.Math.Min(distance, distance2);
				result = true;
			}
			if (PointToAboveSegment(item.P0, seg, ref distance2) && distance2 < 0.0)
			{
				distance = System.Math.Min(distance, 0.0 - distance2);
				result = true;
			}
			if (PointToAboveSegment(item.P1, seg, ref distance2) && distance2 < 0.0)
			{
				distance = System.Math.Min(distance, 0.0 - distance2);
				result = true;
			}
		}
		return result;
	}

	public static bool ArcToAboveSegment(Arc arc, Segment segAbove, ref double distance)
	{
		bool result = false;
		distance = double.MaxValue;
		foreach (Segment item in arc.Explode(20))
		{
			double distance2 = double.MaxValue;
			if (PointToAboveSegment(item.P0, segAbove, ref distance2) && distance2 > 0.0)
			{
				distance = System.Math.Min(distance, distance2);
				result = true;
			}
			if (PointToAboveSegment(item.P1, segAbove, ref distance2) && distance2 > 0.0)
			{
				distance = System.Math.Min(distance, distance2);
				result = true;
			}
			if (PointToAboveSegment(segAbove.P0, item, ref distance2) && distance2 < 0.0)
			{
				distance = System.Math.Min(distance, 0.0 - distance2);
				result = true;
			}
			if (PointToAboveSegment(segAbove.P1, item, ref distance2) && distance2 < 0.0)
			{
				distance = System.Math.Min(distance, 0.0 - distance2);
				result = true;
			}
		}
		return result;
	}

	public static bool ArcToAboveArc(Arc arc1, Arc arc2, ref double distance)
	{
		bool result = false;
		distance = double.MaxValue;
		List<Segment> list = arc1.Explode(20);
		List<Segment> list2 = arc2.Explode(20);
		foreach (Segment item in list)
		{
			foreach (Segment item2 in list2)
			{
				double distance2 = double.MaxValue;
				if (SegmentToAboveSegment(item, item2, ref distance2) && distance2 > 0.0)
				{
					distance = System.Math.Min(distance, distance2);
					result = true;
				}
			}
		}
		return result;
	}

	static VerticalDistance()
	{
		Class72.smethod_20();
	}
}
