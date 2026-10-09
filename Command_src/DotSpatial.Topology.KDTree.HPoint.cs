using System;

namespace DotSpatial.Topology.KDTree;

public class HPoint : Coordinate
{
	private readonly int int_0;

	public double[] Values
	{
		get
		{
			return ToArray();
		}
		set
		{
			if (value.Length != 0)
			{
				X = value[0];
			}
			if (value.Length > 1)
			{
				Y = value[1];
			}
			if (value.Length > 2)
			{
				Z = value[2];
			}
		}
	}

	public HPoint(int numDimensions)
	{
		int_0 = numDimensions;
	}

	public HPoint(double[] inCoord)
	{
		int_0 = inCoord.Length;
		if (int_0 > 0)
		{
			X = inCoord[0];
		}
		if (int_0 > 1)
		{
			Y = inCoord[1];
		}
		if (int_0 > 2)
		{
			Z = inCoord[2];
		}
	}

	public static double SquareDistance(HPoint x, HPoint y)
	{
		int num = Math.Min(x.NumOrdinates, y.NumOrdinates);
		double num2 = 0.0;
		int num3;
		if (!(x != null))
		{
			num3 = 0;
		}
		else
		{
			if (y != null)
			{
				for (int i = 0; i < num; i++)
				{
					double num4 = x[i] - y[i];
					num2 += num4 * num4;
				}
				goto IL_0091;
			}
			num3 = 0;
		}
		for (int j = num3; j < num; j++)
		{
			double num5 = x[j] - y[j];
			num2 += num5 * num5;
		}
		goto IL_0091;
		IL_0091:
		return num2;
	}

	public static double EuclideanDistance(HPoint x, HPoint y)
	{
		return Math.Sqrt(SquareDistance(x, y));
	}

	public double HyperDistance(HPoint p)
	{
		return Math.Sqrt(SquareHyperDistance(p));
	}

	public double SquareHyperDistance(HPoint p)
	{
		int num = Math.Min(p.NumOrdinates, base.NumOrdinates);
		double num2 = 0.0;
		for (int i = 0; i < num; i++)
		{
			double num3 = p[i] - base[i];
			num2 += num3 * num3;
		}
		return num2;
	}

	static HPoint()
	{
		Class72.smethod_20();
	}
}
