using System;

namespace DotSpatial.Topology.Index.Quadtree;

public static class IntervalSize
{
	public const int MIN_BINARY_EXPONENT = -50;

	public static bool IsZeroWidth(double min, double max)
	{
		double num = max - min;
		if (num == 0.0)
		{
			return true;
		}
		double num2 = Math.Max(Math.Abs(min), Math.Abs(max));
		return DoubleBits.GetExponent(num / num2) <= -50;
	}

	static IntervalSize()
	{
		Class72.smethod_20();
	}
}
