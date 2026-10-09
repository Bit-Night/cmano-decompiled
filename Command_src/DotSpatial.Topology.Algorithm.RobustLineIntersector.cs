#define TRACE
using System.Diagnostics;

namespace DotSpatial.Topology.Algorithm;

public class RobustLineIntersector : LineIntersector
{
	public override void ComputeIntersection(Coordinate p, Coordinate p1, Coordinate p2)
	{
		IsProper = false;
		if (Envelope.Intersects(p1, p2, p) && CgAlgorithms.OrientationIndex(p1, p2, p) == 0 && CgAlgorithms.OrientationIndex(p2, p1, p) == 0)
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

	public override IntersectionType ComputeIntersect(Coordinate p1, Coordinate p2, Coordinate q1, Coordinate q2)
	{
		IsProper = false;
		if (!Envelope.Intersects(p1, p2, q1, q2))
		{
			return IntersectionType.NoIntersection;
		}
		int num = CgAlgorithms.OrientationIndex(p1, p2, q1);
		int num2 = CgAlgorithms.OrientationIndex(p1, p2, q2);
		int result;
		if (num > 0 && num2 > 0)
		{
			result = 0;
		}
		else
		{
			if (num >= 0 || num2 >= 0)
			{
				int num3 = CgAlgorithms.OrientationIndex(q1, q2, p1);
				int num4 = CgAlgorithms.OrientationIndex(q1, q2, p2);
				int result2;
				if (num3 > 0 && num4 > 0)
				{
					result2 = 0;
				}
				else
				{
					if (num3 >= 0 || num4 >= 0)
					{
						if (num == 0 && num2 == 0 && num3 == 0 && num4 == 0)
						{
							return method_0(p1, p2, q1, q2);
						}
						int result3;
						if (num != 0 && num2 != 0 && num3 != 0 && num4 != 0)
						{
							IsProper = true;
							base.IntersectionPoints[0] = method_1(p1, p2, q1, q2);
							result3 = 1;
						}
						else
						{
							IsProper = false;
							if (num == 0)
							{
								base.IntersectionPoints[0] = new Coordinate(q1);
							}
							if (num2 == 0)
							{
								base.IntersectionPoints[0] = new Coordinate(q2);
							}
							if (num3 == 0)
							{
								base.IntersectionPoints[0] = new Coordinate(p1);
							}
							if (num4 == 0)
							{
								base.IntersectionPoints[0] = new Coordinate(p2);
								result3 = 1;
							}
							else
							{
								result3 = 1;
							}
						}
						return (IntersectionType)result3;
					}
					result2 = 0;
				}
				return (IntersectionType)result2;
			}
			result = 0;
		}
		return (IntersectionType)result;
	}

	private IntersectionType method_0(Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4, Coordinate coordinate_5)
	{
		bool flag = Envelope.Intersects(coordinate_2, coordinate_3, coordinate_4);
		bool flag2 = Envelope.Intersects(coordinate_2, coordinate_3, coordinate_5);
		bool flag3 = Envelope.Intersects(coordinate_4, coordinate_5, coordinate_2);
		bool flag4 = Envelope.Intersects(coordinate_4, coordinate_5, coordinate_3);
		if (flag && flag2)
		{
			base.IntersectionPoints[0] = coordinate_4;
			base.IntersectionPoints[1] = coordinate_5;
			return IntersectionType.Collinear;
		}
		if (flag3 && flag4)
		{
			base.IntersectionPoints[0] = coordinate_2;
			base.IntersectionPoints[1] = coordinate_3;
			return IntersectionType.Collinear;
		}
		if (!(flag && flag3))
		{
			if (flag && flag4)
			{
				base.IntersectionPoints[0] = coordinate_4;
				base.IntersectionPoints[1] = coordinate_3;
				if (coordinate_4.Equals(coordinate_3))
				{
					return IntersectionType.PointIntersection;
				}
				return IntersectionType.Collinear;
			}
			if (flag2 && flag3)
			{
				base.IntersectionPoints[0] = coordinate_5;
				base.IntersectionPoints[1] = coordinate_2;
				if (coordinate_5.Equals(coordinate_2))
				{
					return IntersectionType.PointIntersection;
				}
				return IntersectionType.Collinear;
			}
			if (!(flag2 && flag4))
			{
				return IntersectionType.NoIntersection;
			}
			base.IntersectionPoints[0] = coordinate_5;
			base.IntersectionPoints[1] = coordinate_3;
			if (coordinate_5.Equals(coordinate_3))
			{
				return IntersectionType.PointIntersection;
			}
			return IntersectionType.Collinear;
		}
		base.IntersectionPoints[0] = coordinate_4;
		base.IntersectionPoints[1] = coordinate_2;
		if (!coordinate_4.Equals(coordinate_2))
		{
			return IntersectionType.Collinear;
		}
		return IntersectionType.PointIntersection;
	}

	private Coordinate method_1(Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4, Coordinate coordinate_5)
	{
		Coordinate coordinate = new Coordinate(coordinate_2);
		Coordinate coordinate2 = new Coordinate(coordinate_3);
		Coordinate coordinate3 = new Coordinate(coordinate_4);
		Coordinate coordinate4 = new Coordinate(coordinate_5);
		Coordinate coordinate5 = new Coordinate();
		smethod_0(coordinate, coordinate2, coordinate3, coordinate4, coordinate5);
		Coordinate coordinate6 = HCoordinate.Intersection(coordinate, coordinate2, coordinate3, coordinate4);
		coordinate6.X += coordinate5.X;
		coordinate6.Y += coordinate5.Y;
		if (!method_2(coordinate6))
		{
			Trace.WriteLine("Intersection outside segment envelopes: " + (object)coordinate6);
		}
		if (PrecisionModel != null)
		{
			PrecisionModel.MakePrecise(coordinate6);
		}
		return coordinate6;
	}

	private static void smethod_0(Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4, Coordinate coordinate_5, Coordinate coordinate_6)
	{
		double num = ((coordinate_2.X < coordinate_3.X) ? coordinate_2.X : coordinate_3.X);
		double num2 = ((coordinate_2.Y >= coordinate_3.Y) ? coordinate_3.Y : coordinate_2.Y);
		double num3 = ((coordinate_2.X <= coordinate_3.X) ? coordinate_3.X : coordinate_2.X);
		double num4 = ((coordinate_2.Y <= coordinate_3.Y) ? coordinate_3.Y : coordinate_2.Y);
		double num5 = ((coordinate_4.X >= coordinate_5.X) ? coordinate_5.X : coordinate_4.X);
		double num6 = ((coordinate_4.Y >= coordinate_5.Y) ? coordinate_5.Y : coordinate_4.Y);
		double num7 = ((coordinate_4.X <= coordinate_5.X) ? coordinate_5.X : coordinate_4.X);
		double num8 = ((coordinate_4.Y <= coordinate_5.Y) ? coordinate_5.Y : coordinate_4.Y);
		double num9 = ((num <= num5) ? num5 : num);
		double num10 = ((num3 >= num7) ? num7 : num3);
		double num11 = ((num2 <= num6) ? num6 : num2);
		double num12 = ((num4 < num8) ? num4 : num8);
		double x = (num9 + num10) / 2.0;
		double y = (num11 + num12) / 2.0;
		coordinate_6.X = x;
		coordinate_6.Y = y;
		coordinate_2.X -= coordinate_6.X;
		coordinate_2.Y -= coordinate_6.Y;
		coordinate_3.X -= coordinate_6.X;
		coordinate_3.Y -= coordinate_6.Y;
		coordinate_4.X -= coordinate_6.X;
		coordinate_4.Y -= coordinate_6.Y;
		coordinate_5.X -= coordinate_6.X;
		coordinate_5.Y -= coordinate_6.Y;
	}

	private bool method_2(Coordinate coordinate_2)
	{
		Envelope self = new Envelope(base.InputLines[0, 0], base.InputLines[0, 1]);
		Envelope self2 = new Envelope(base.InputLines[1, 0], base.InputLines[1, 1]);
		if (!self.Contains(coordinate_2))
		{
			return false;
		}
		return self2.Contains(coordinate_2);
	}

	static RobustLineIntersector()
	{
		Class72.smethod_20();
	}
}
