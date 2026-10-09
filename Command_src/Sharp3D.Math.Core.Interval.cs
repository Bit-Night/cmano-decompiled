using System;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Interval : ICloneable
{
	public enum Type
	{
		Open,
		Closed,
		OpenClosed,
		ClosedOpen
	}

	private Type type_0;

	private double double_0;

	private double double_1;

	public Type IntervalType
	{
		get
		{
			return type_0;
		}
		set
		{
			type_0 = value;
		}
	}

	public double Min
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Max
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Interval()
	{
		type_0 = Type.Open;
		double_0 = 0.0;
		double_1 = 1.0;
	}

	public Interval(Type type, double minValue, double maxValue)
	{
		type_0 = type;
		double_0 = minValue;
		double_1 = maxValue;
	}

	public Interval(Interval interval)
	{
		type_0 = interval.IntervalType;
		double_0 = interval.Min;
		double_1 = interval.Max;
	}

	object ICloneable.Clone()
	{
		return new Interval(this);
	}

	public Interval Clone()
	{
		return new Interval(this);
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode() ^ double_1.GetHashCode() ^ type_0.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Interval)
		{
			Interval interval = (Interval)obj;
			if (double_0 == interval.Min && double_1 == interval.Max)
			{
				return type_0 == interval.IntervalType;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return type_0 switch
		{
			Type.Open => string.Format(CultureInfo.InvariantCulture, "({0}, {1})", double_0, double_1), 
			Type.Closed => string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", double_0, double_1), 
			Type.OpenClosed => string.Format(CultureInfo.InvariantCulture, "({0}, {1}]", double_0, double_1), 
			Type.ClosedOpen => string.Format(CultureInfo.InvariantCulture, "[{0}, {1})", double_0, double_1), 
			_ => "Unknown interval type.", 
		};
	}

	public bool IsInside(double value)
	{
		if (double_0 < value && value < double_1)
		{
			return true;
		}
		if (type_0 != Type.Open)
		{
			if (value == double_0)
			{
				int result;
				if (type_0 != Type.Closed)
				{
					if (type_0 != Type.ClosedOpen)
					{
						return false;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			if (value == double_1)
			{
				int result2;
				if (type_0 != Type.Closed)
				{
					if (type_0 != Type.OpenClosed)
					{
						return false;
					}
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(Interval left, Interval right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Interval left, Interval right)
	{
		return !object.Equals(left, right);
	}

	static Interval()
	{
		Class72.smethod_20();
	}
}
