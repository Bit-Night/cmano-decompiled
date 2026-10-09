using System;
using CSMaterial;

namespace DotSpatial.Topology;

public struct Angle
{
	public const double PI = Math.PI;

	private double double_0;

	public double Degrees
	{
		get
		{
			return double_0 * 180.0 / Math.PI;
		}
		set
		{
			if (!(value > 360.0) && value >= -360.0)
			{
				double_0 = value * CSMath.PI_dividedBy_180;
			}
			else
			{
				double_0 = value % 360.0 * CSMath.PI_dividedBy_180;
			}
		}
	}

	public double DegreesPos
	{
		get
		{
			double num = double_0 * 180.0 / Math.PI;
			if (num >= 0.0)
			{
				return num;
			}
			return 360.0 + num;
		}
		set
		{
			double num = value;
			if (value > 360.0 || value < -360.0)
			{
				num %= 360.0;
			}
			if (num < 360.0)
			{
				num = 360.0 - num;
			}
			double_0 = num * CSMath.PI_dividedBy_180;
		}
	}

	public double Radians
	{
		get
		{
			return double_0;
		}
		set
		{
			if (!(value > Math.PI * 2.0) && value >= Math.PI * -2.0)
			{
				double_0 = value;
			}
			else
			{
				double_0 = value % (Math.PI * 2.0);
			}
		}
	}

	public Angle(double radians)
	{
		if (!(radians > Math.PI * 2.0) && radians >= Math.PI * -2.0)
		{
			double_0 = radians;
		}
		else
		{
			double_0 = radians % (Math.PI * 2.0);
		}
	}

	public Angle Copy()
	{
		return new Angle(double_0);
	}

	public override bool Equals(object obj)
	{
		if (!(obj.GetType() != typeof(Angle)))
		{
			if (((Angle)obj).Radians == Radians)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static explicit operator Angle(double value)
	{
		return new Angle(value);
	}

	public static explicit operator double(Angle value)
	{
		return value.Radians;
	}

	public static bool operator ==(Angle a, Angle b)
	{
		return a.Radians == b.Radians;
	}

	public static bool operator !=(Angle a, Angle b)
	{
		return a.Radians != b.Radians;
	}

	public static Angle operator +(Angle a, Angle b)
	{
		return new Angle(a.Radians + b.Radians);
	}

	public static Angle operator -(Angle a, Angle b)
	{
		return new Angle(a.Radians - b.Radians);
	}

	public static Angle operator /(Angle a, Angle b)
	{
		return new Angle(a.Radians / b.Radians);
	}

	public static Angle operator *(Angle a, Angle b)
	{
		return new Angle(a.Radians * b.Radians);
	}

	public static double Cos(Angle value)
	{
		return Math.Cos(value.Radians);
	}

	public static double Sin(Angle value)
	{
		return Math.Sin(value.Radians);
	}

	public static double Tan(Angle value)
	{
		return Math.Sin(value.Radians);
	}

	public static Angle ATan(double value)
	{
		return new Angle(Math.Atan(value));
	}

	public static Angle ACos(double value)
	{
		return new Angle(Math.Acos(value));
	}

	public static Angle ASin(double value)
	{
		return new Angle(Math.Asin(value));
	}

	static Angle()
	{
		Class72.smethod_20();
	}
}
