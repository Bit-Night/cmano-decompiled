using System;

namespace DotSpatial.Topology.Voronoi;

public abstract class MathTools
{
	public static double Dist(double x1, double y1, double x2, double y2)
	{
		return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
	}

	public static int Ccw(double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, bool plusOneOnZeroDegrees)
	{
		double num = p1X - p0X;
		double num2 = p1Y - p0Y;
		double num3 = p2X - p0X;
		double num4 = p2Y - p0Y;
		if (num * num4 > num2 * num3)
		{
			return 1;
		}
		if (num * num4 < num2 * num3)
		{
			return -1;
		}
		int result;
		if (!(num * num3 < 0.0))
		{
			if (!(num2 * num4 < 0.0))
			{
				if (num * num + num2 * num2 < num3 * num3 + num4 * num4 && plusOneOnZeroDegrees)
				{
					return 1;
				}
				return 0;
			}
			result = -1;
		}
		else
		{
			result = -1;
		}
		return result;
	}

	static MathTools()
	{
		Class72.smethod_20();
	}
}
