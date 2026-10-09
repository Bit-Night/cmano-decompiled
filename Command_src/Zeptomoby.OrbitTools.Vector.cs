using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Vector
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private double double_3;

	public double X
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public double Y
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		set
		{
			double_1 = value;
		}
	}

	public double Z
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public double W
	{
		[CompilerGenerated]
		get
		{
			return double_3;
		}
		[CompilerGenerated]
		set
		{
			double_3 = value;
		}
	}

	public Vector()
	{
	}

	public Vector(Vector v)
		: this(v.X, v.Y, v.Z, v.W)
	{
	}

	public Vector(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector(double x, double y, double z, double w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	public void Scale(double factor)
	{
		X *= factor;
		Y *= factor;
		Z *= factor;
		W *= Math.Abs(factor);
	}

	public void Sub(Vector vec)
	{
		X -= vec.X;
		Y -= vec.Y;
		Z -= vec.Z;
		W -= vec.W;
	}

	public double Angle(Vector vec)
	{
		double num = Dot(vec) / (Magnitude() * vec.Magnitude());
		if (num > 0.0)
		{
			num = Math.Min(num, 1.0);
		}
		if (num < 0.0)
		{
			num = Math.Max(num, -1.0);
		}
		return Math.Acos(num);
	}

	public double Magnitude()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z);
	}

	public double Dot(Vector vec)
	{
		return X * vec.X + Y * vec.Y + Z * vec.Z;
	}

	public double Distance(Vector vec)
	{
		return Math.Sqrt(Math.Pow(X - vec.X, 2.0) + Math.Pow(Y - vec.Y, 2.0) + Math.Pow(Z - vec.Z, 2.0));
	}

	public void RotateX(double radians)
	{
		double y = Y;
		Y = Math.Cos(radians) * y - Math.Sin(radians) * Z;
		Z = Math.Sin(radians) * y + Math.Cos(radians) * Z;
	}

	public void RotateY(double radians)
	{
		double x = X;
		X = Math.Cos(radians) * x + Math.Sin(radians) * Z;
		Z = (0.0 - Math.Sin(radians)) * x + Math.Cos(radians) * Z;
	}

	public void RotateZ(double radians)
	{
		double x = X;
		X = Math.Cos(radians) * x - Math.Sin(radians) * Y;
		Y = Math.Sin(radians) * x + Math.Cos(radians) * Y;
	}

	public void Translate(double x, double y, double z)
	{
		X += x;
		Y += y;
		Z += z;
	}

	static Vector()
	{
		Class72.smethod_20();
	}
}
