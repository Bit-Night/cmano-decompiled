using System;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.Index.Bintree;

public class Key
{
	private Interval interval_0;

	private int int_0;

	private double double_0;

	public virtual double Point => double_0;

	public virtual int Level => int_0;

	public virtual Interval Interval => interval_0;

	public Key(Interval interval)
	{
		ComputeKey(interval);
	}

	public static int ComputeLevel(Interval interval)
	{
		return DoubleBits.GetExponent(interval.Width) + 1;
	}

	public void ComputeKey(Interval itemInterval)
	{
		int_0 = ComputeLevel(itemInterval);
		interval_0 = new Interval();
		method_0(int_0, itemInterval);
		while (!interval_0.Contains(itemInterval))
		{
			int_0++;
			method_0(int_0, itemInterval);
		}
	}

	private void method_0(int int_1, Interval interval_1)
	{
		double num = DoubleBits.PowerOf2(int_1);
		double_0 = Math.Floor(interval_1.Min / num) * num;
		interval_0.Init(double_0, double_0 + num);
	}

	static Key()
	{
		Class72.smethod_20();
	}
}
