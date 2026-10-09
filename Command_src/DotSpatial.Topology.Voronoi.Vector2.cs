using System;

namespace DotSpatial.Topology.Voronoi;

public struct Vector2
{
	public static double Tolerance;

	public readonly double X;

	public readonly double Y;

	public double SquaredLength => this * this;

	public Vector2(double[] xyvertices, int offset)
	{
		X = xyvertices[offset];
		Y = xyvertices[offset + 1];
	}

	public Vector2(params double[] x)
	{
		X = x[0];
		Y = x[1];
	}

	public Coordinate ToCoordinate()
	{
		return new Coordinate(X, Y);
	}

	public bool ContainsNan()
	{
		if (!double.IsNaN(X))
		{
			if (double.IsNaN(Y))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		string[] obj = new string[5] { "(", null, null, null, null };
		double x = X;
		obj[1] = x.ToString();
		obj[2] = ",";
		x = Y;
		obj[3] = x.ToString();
		obj[4] = ")";
		return string.Concat(obj);
	}

	public override bool Equals(object obj)
	{
		Vector2 vector = (Vector2)obj;
		if (!smethod_0(X, vector.X))
		{
			return false;
		}
		return smethod_0(Y, vector.Y);
	}

	public double Distance(Vector2 other)
	{
		double num = X - other.X;
		double num2 = Y - other.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	private static bool smethod_0(double double_0, double double_1)
	{
		if (double.IsNaN(double_0) && double.IsNaN(double_1))
		{
			return true;
		}
		int result;
		if (!double.IsNaN(double_0))
		{
			if (!double.IsNaN(double_1))
			{
				if (Tolerance == 0.0)
				{
					return double_0 == double_1;
				}
				return Math.Abs(double_0 - double_1) <= Tolerance;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		double x = X;
		int hashCode = x.GetHashCode();
		x = Y;
		return hashCode * x.GetHashCode();
	}

	public static double operator *(Vector2 a, Vector2 b)
	{
		return a.X * b.X + a.Y * b.Y;
	}

	public static bool operator ==(Vector2 a, Vector2 b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Vector2 a, Vector2 b)
	{
		return !a.Equals(b);
	}

	public static Vector2 operator +(Vector2 a, Vector2 b)
	{
		return new Vector2(a.X + b.X, a.Y + b.Y);
	}

	public static Vector2 operator -(Vector2 a, Vector2 b)
	{
		return new Vector2(a.X - b.X, a.Y - b.Y);
	}

	public static Vector2 operator *(Vector2 a, double scale)
	{
		return new Vector2(a.X * scale, a.Y * scale);
	}

	public static Vector2 operator *(double scale, Vector2 a)
	{
		return new Vector2(a.X * scale, a.Y * scale);
	}

	static Vector2()
	{
		Class72.smethod_20();
	}
}
