using System;

namespace DotSpatial.Topology.Algorithm;

public class NonRobustLineIntersector : LineIntersector
{
	public static bool IsSameSignAndNonZero(double a, double b)
	{
		int result;
		if (a != 0.0)
		{
			if (b != 0.0)
			{
				if (a < 0.0 && !(b >= 0.0))
				{
					return true;
				}
				if (a > 0.0)
				{
					return b > 0.0;
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void ComputeIntersection(Coordinate p, Coordinate p1, Coordinate p2)
	{
		IsProper = false;
		double num = p2.Y - p1.Y;
		double num2 = p1.X - p2.X;
		double num3 = p2.X * p1.Y - p1.X * p2.Y;
		if (num * p.X + num2 * p.Y + num3 != 0.0)
		{
			base.Result = IntersectionType.NoIntersection;
			return;
		}
		double num4 = smethod_0(p1, p2, p);
		if (!(num4 < 0.0) && num4 <= 1.0)
		{
			IsProper = true;
			if (p.Equals(p1) || p.Equals(p2))
			{
				IsProper = false;
			}
			base.Result = IntersectionType.PointIntersection;
		}
		else
		{
			base.Result = IntersectionType.NoIntersection;
		}
	}

	public override IntersectionType ComputeIntersect(Coordinate p1, Coordinate p2, Coordinate p3, Coordinate p4)
	{
		IsProper = false;
		double num = p2.Y - p1.Y;
		double num2 = p1.X - p2.X;
		double num3 = p2.X * p1.Y - p1.X * p2.Y;
		double num4 = num * p3.X + num2 * p3.Y + num3;
		double num5 = num * p4.X + num2 * p4.Y + num3;
		if (num4 != 0.0 && num5 != 0.0 && IsSameSignAndNonZero(num4, num5))
		{
			return IntersectionType.NoIntersection;
		}
		double num6 = p4.Y - p3.Y;
		double num7 = p3.X - p4.X;
		double num8 = p4.X * p3.Y - p3.X * p4.Y;
		double num9 = num6 * p1.X + num7 * p1.Y + num8;
		double num10 = num6 * p2.X + num7 * p2.Y + num8;
		if (num9 != 0.0 && num10 != 0.0 && IsSameSignAndNonZero(num9, num10))
		{
			return IntersectionType.NoIntersection;
		}
		double num11 = num * num7 - num6 * num2;
		if (num11 == 0.0)
		{
			return method_0(p1, p2, p3, p4);
		}
		double x = (num2 * num8 - num7 * num3) / num11;
		double y = (num6 * num3 - num * num8) / num11;
		base.PointA = new Coordinate(x, y);
		IsProper = true;
		if (base.PointA.Equals(p1) || base.PointA.Equals(p2) || base.PointA.Equals(p3) || base.PointA.Equals(p4))
		{
			IsProper = false;
		}
		int result;
		if (!(PrecisionModel != null))
		{
			result = 1;
		}
		else
		{
			PrecisionModel.MakePrecise(base.PointA);
			result = 1;
		}
		return (IntersectionType)result;
	}

	private IntersectionType method_0(Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4, Coordinate coordinate_5)
	{
		double num = smethod_0(coordinate_2, coordinate_3, coordinate_4);
		double num2 = smethod_0(coordinate_2, coordinate_3, coordinate_5);
		Coordinate coordinate;
		double num3;
		Coordinate coordinate2;
		double num4;
		if (num < num2)
		{
			coordinate = new Coordinate(coordinate_4);
			num3 = num;
			coordinate2 = new Coordinate(coordinate_5);
			num4 = num2;
		}
		else
		{
			coordinate = new Coordinate(coordinate_5);
			num3 = num2;
			coordinate2 = new Coordinate(coordinate_4);
			num4 = num;
		}
		int result2;
		if (!(num3 > 1.0))
		{
			if (!(num4 < 0.0))
			{
				if (coordinate2 == coordinate_2)
				{
					base.PointA = coordinate_2;
					return IntersectionType.PointIntersection;
				}
				if (coordinate == coordinate_3)
				{
					base.PointA = coordinate_3;
					return IntersectionType.PointIntersection;
				}
				base.PointA = coordinate_2;
				if (num3 > 0.0)
				{
					base.PointA = coordinate;
				}
				base.PointB = coordinate_3;
				int result;
				if (num4 < 1.0)
				{
					base.PointB = coordinate2;
					result = 2;
				}
				else
				{
					result = 2;
				}
				return (IntersectionType)result;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (IntersectionType)result2;
	}

	private static double smethod_0(object object_0, object object_1, object object_2)
	{
		double num = Math.Abs(((Coordinate)object_1).X - ((Coordinate)object_0).X);
		double num2 = Math.Abs(((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
		if (num <= num2)
		{
			return (((Coordinate)object_2).Y - ((Coordinate)object_0).Y) / (((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
		}
		return (((Coordinate)object_2).X - ((Coordinate)object_0).X) / (((Coordinate)object_1).X - ((Coordinate)object_0).X);
	}

	static NonRobustLineIntersector()
	{
		Class72.smethod_20();
	}
}
