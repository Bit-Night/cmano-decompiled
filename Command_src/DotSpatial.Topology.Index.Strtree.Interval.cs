using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public class Interval
{
	private double double_0;

	private double double_1;

	public virtual double Centre => (double_1 + double_0) / 2.0;

	public Interval(Interval other)
		: this(other.double_1, other.double_0)
	{
	}

	public Interval(double min, double max)
	{
		Assert.IsTrue(min <= max);
		double_1 = min;
		double_0 = max;
	}

	public virtual Interval ExpandToInclude(Interval other)
	{
		double_0 = Math.Max(double_0, other.double_0);
		double_1 = Math.Min(double_1, other.double_1);
		return this;
	}

	public virtual bool Intersects(Interval other)
	{
		if (!(other.double_1 > double_0))
		{
			return !(other.double_0 < double_1);
		}
		return false;
	}

	public override bool Equals(object o)
	{
		if (!(o is Interval))
		{
			return false;
		}
		Interval interval = (Interval)o;
		if (double_1 == interval.double_1)
		{
			return double_0 == interval.double_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	static Interval()
	{
		Class72.smethod_20();
	}
}
