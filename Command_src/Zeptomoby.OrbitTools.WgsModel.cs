using System;

namespace Zeptomoby.OrbitTools;

public abstract class WgsModel
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double ilOeiYrrUa3;

	public virtual double Ck2 => J2 / 2.0;

	public virtual double Ck4 => -3.0 * J4 / 8.0;

	public virtual double Ge => double_0;

	public virtual double Xkmper => double_1;

	public virtual double Xke => ilOeiYrrUa3;

	public abstract double J2 { get; }

	public abstract double J3 { get; }

	public abstract double J4 { get; }

	public abstract double F { get; }

	public WgsModel(double ge, double xkmper)
	{
		double_0 = ge;
		double_1 = xkmper;
		ilOeiYrrUa3 = Math.Sqrt(3600.0 * ge / (xkmper * xkmper * xkmper));
	}

	static WgsModel()
	{
		Class72.smethod_20();
	}
}
