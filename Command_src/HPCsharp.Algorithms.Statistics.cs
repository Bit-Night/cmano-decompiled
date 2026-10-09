using System;
using System.Linq;

namespace HPCsharp.Algorithms;

public static class Statistics
{
	public static double StandardDeviation(this int[] values)
	{
		double double_0 = values.Average();
		return Math.Sqrt(values.Average((int v) => Math.Pow((double)v - double_0, 2.0)));
	}

	public static double StandardDeviation(this long[] values)
	{
		double double_0 = values.Average();
		return Math.Sqrt(values.Average((long v) => Math.Pow((double)v - double_0, 2.0)));
	}

	public static double MeanAbsoluteDeviation(this int[] values)
	{
		long num = Sum.SumToLong(values);
		double double_0 = (double)num / (double)values.Length;
		return values.Average((int v) => Math.Abs((double)v - double_0));
	}

	static Statistics()
	{
		Class72.smethod_20();
	}
}
