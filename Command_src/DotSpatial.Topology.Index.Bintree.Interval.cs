namespace DotSpatial.Topology.Index.Bintree;

public class Interval
{
	private double double_0;

	private double double_1;

	public virtual double Min
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

	public virtual double Max
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

	public virtual double Width => Max - Min;

	public Interval()
	{
		double_1 = 0.0;
		double_0 = 0.0;
	}

	public Interval(double min, double max)
	{
		Init(min, max);
	}

	public Interval(Interval interval)
	{
		Init(interval.Min, interval.Max);
	}

	public void Init(double min, double max)
	{
		Min = min;
		Max = max;
		if (!(min <= max))
		{
			Min = max;
			Max = min;
		}
	}

	public virtual void ExpandToInclude(Interval interval)
	{
		if (interval.Max > Max)
		{
			Max = interval.Max;
		}
		if (interval.Min < Min)
		{
			Min = interval.Min;
		}
	}

	public virtual bool Overlaps(Interval interval)
	{
		return Overlaps(interval.Min, interval.Max);
	}

	public virtual bool Overlaps(double min, double max)
	{
		if (Min <= max)
		{
			return Max >= min;
		}
		return false;
	}

	public virtual bool Contains(Interval interval)
	{
		return Contains(interval.Min, interval.Max);
	}

	public virtual bool Contains(double min, double max)
	{
		if (min >= Min)
		{
			return max <= Max;
		}
		return false;
	}

	public virtual bool Contains(double p)
	{
		if (p < Min)
		{
			return false;
		}
		return p <= Max;
	}

	static Interval()
	{
		Class72.smethod_20();
	}
}
