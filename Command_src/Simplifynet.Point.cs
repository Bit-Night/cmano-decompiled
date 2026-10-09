using System;

namespace Simplifynet;

public sealed class Point : IEquatable<Point>
{
	public double X;

	public double Y;

	public double Z;

	public bool IsValid
	{
		get
		{
			if (X <= 90.0 && Y >= -90.0 && Y <= 180.0)
			{
				return X >= -180.0;
			}
			return false;
		}
	}

	public Point(double x, double y, double z = 0.0)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != typeof(Point) && obj.GetType() != typeof(Point))
			{
				return false;
			}
			return Equals(obj as Point);
		}
		return false;
	}

	public bool Equals(Point other)
	{
		if (other != null)
		{
			if (this == other)
			{
				return true;
			}
			int result;
			if (!other.X.Equals(X))
			{
				result = 0;
			}
			else
			{
				if (other.Y.Equals(Y))
				{
					return other.Z.Equals(Z);
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (X.GetHashCode() * 397) ^ Y.GetHashCode() ^ Z.GetHashCode();
	}

	public override string ToString()
	{
		return $"{X} {Y} {Z}";
	}

	static Point()
	{
		Class72.smethod_20();
	}
}
