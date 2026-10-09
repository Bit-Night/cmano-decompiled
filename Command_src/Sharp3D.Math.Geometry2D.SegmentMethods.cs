using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class SegmentMethods
{
	public static bool AreSegmentsColinear(Segment s0, Segment s1, double epsilon)
	{
		if (!IsPointCollinear(s0, s1.P0, epsilon))
		{
			return false;
		}
		return IsPointCollinear(s0, s1.P1, epsilon);
	}

	public static bool IsPointCollinear(Segment s, Vector2D p, double epsilon)
	{
		return System.Math.Abs(GetSignedTriangleArea2(s, p, epsilon)) <= epsilon;
	}

	public static double GetSignedTriangleArea2(Segment s, Vector2D p, double epsilon)
	{
		Vector2D vector2D = p - s.P0;
		double length = vector2D.GetLength();
		if (length < epsilon)
		{
			return 0.0;
		}
		vector2D *= 1.0 / length;
		Vector2D vector2D2 = s.P1 - s.P0;
		double length2 = vector2D2.GetLength();
		if (length2 < epsilon)
		{
			return 0.0;
		}
		vector2D2 *= 1.0 / length2;
		return vector2D.X * vector2D2.Y - vector2D.Y * vector2D2.X;
	}

	static SegmentMethods()
	{
		Class72.smethod_20();
	}
}
