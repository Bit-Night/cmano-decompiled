using System;

namespace CSMaterial.ExWorldWind;

public struct Angle
{
	public static readonly Angle NaN;

	[NonSerialized]
	public double Radians;

	public double Degrees
	{
		get
		{
			return MathEngine.RadiansToDegrees(Radians);
		}
		set
		{
			Radians = MathEngine.DegreesToRadians(value);
		}
	}

	public static Angle FromRadians(double radians)
	{
		return new Angle
		{
			Radians = radians
		};
	}

	public static Angle FromDegrees(double degrees)
	{
		return new Angle
		{
			Radians = Math.PI * degrees / 180.0
		};
	}

	public static bool IsNaN(Angle a)
	{
		return double.IsNaN(a.Radians);
	}

	public static Angle operator +(Angle a, Angle b)
	{
		return FromRadians(a.Radians + b.Radians);
	}

	public static Angle operator -(Angle a, Angle b)
	{
		return FromRadians(a.Radians - b.Radians);
	}

	public static Angle operator *(Angle a, double times)
	{
		return FromRadians(a.Radians * times);
	}

	static Angle()
	{
		Class72.smethod_20();
		NaN = FromRadians(double.NaN);
	}
}
