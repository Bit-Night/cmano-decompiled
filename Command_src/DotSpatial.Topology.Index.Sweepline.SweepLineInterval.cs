namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineInterval
{
	private readonly object object_0;

	private readonly double double_0;

	private readonly double double_1;

	public virtual double Min => double_1;

	public virtual double Max => double_0;

	public virtual object Item => object_0;

	public SweepLineInterval(double min, double max)
		: this(min, max, null)
	{
	}

	public SweepLineInterval(double min, double max, object item)
	{
		double_1 = ((min < max) ? min : max);
		double_0 = ((max > min) ? max : min);
		object_0 = item;
	}

	static SweepLineInterval()
	{
		Class72.smethod_20();
	}
}
