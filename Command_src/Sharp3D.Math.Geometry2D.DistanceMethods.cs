using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public static class DistanceMethods
{
	public static double SquaredDistance(Vector2D p0, Vector2D p1)
	{
		return (p0 - p1).GetLengthSquared();
	}

	public static double Distance(Vector2D p0, Vector2D p1)
	{
		return (p0 - p1).GetLength();
	}

	public static double SquaredDistance(Vector2D point, Segment segment)
	{
		Vector2D vector2D = segment.P1 - segment.P0;
		Vector2D vector2D2 = point - segment.P0;
		double num = Vector2D.DotProduct(vector2D, vector2D2);
		if (num <= 0.0)
		{
			return Vector2D.DotProduct(vector2D2, vector2D2);
		}
		double num2 = Vector2D.DotProduct(vector2D, vector2D);
		if (num >= num2)
		{
			Vector2D vector2D3 = point - segment.P1;
			return Vector2D.DotProduct(vector2D3, vector2D3);
		}
		return Vector2D.DotProduct(vector2D2, vector2D2) - num * num / num2;
	}

	public static double Distance(Vector2D point, Segment segment)
	{
		return System.Math.Sqrt(SquaredDistance(point, segment));
	}

	public static double SquaredDistance(Vector2D point, Ray ray)
	{
		Vector2D left = point - ray.Origin;
		double num = Vector2D.DotProduct(left, ray.Direction);
		if (num <= 0.0)
		{
			return left.GetLengthSquared();
		}
		num = num * num / ray.Direction.GetLengthSquared();
		return left.GetLengthSquared() - num;
	}

	public static float Distance(Vector2D point, Ray ray)
	{
		return (float)System.Math.Sqrt(SquaredDistance(point, ray));
	}

	public static float SquaredDistance(Vector2D point, OrientedBox box)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Vector2D point, OrientedBox box)
	{
		throw new NotImplementedException();
	}

	public static float SquaredDistance(Ray r0, Ray r1)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Ray r0, Ray r1)
	{
		throw new NotImplementedException();
	}

	public static float SquaredDistance(Segment s0, Segment s1)
	{
		throw new NotImplementedException();
	}

	public static float Distance(Segment s0, Segment s1)
	{
		throw new NotImplementedException();
	}

	static DistanceMethods()
	{
		Class72.smethod_20();
	}
}
