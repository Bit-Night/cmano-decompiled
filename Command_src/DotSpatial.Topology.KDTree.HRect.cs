using System;

namespace DotSpatial.Topology.KDTree;

public class HRect : ICloneable
{
	internal HPoint Max;

	internal HPoint Min;

	public double HyperVolume
	{
		get
		{
			double num = 1.0;
			for (int i = 0; i < Min.NumOrdinates; i++)
			{
				num *= Max[i] - Min[i];
			}
			return num;
		}
	}

	public HPoint Minimum
	{
		get
		{
			return Min;
		}
		set
		{
			Min = value;
		}
	}

	public HPoint Maximum
	{
		get
		{
			return Max;
		}
		set
		{
			Max = value;
		}
	}

	public int NumOrdinates => Min.NumOrdinates;

	public HRect(int numDimensions)
	{
		Min = new HPoint(numDimensions);
		Max = new HPoint(numDimensions);
	}

	public HRect(HPoint vmin, HPoint vmax)
	{
		Min = CloneableEM.Copy(vmin);
		Max = CloneableEM.Copy(vmax);
	}

	public object Clone()
	{
		return new HRect(Min, Max);
	}

	public HRect Copy()
	{
		return new HRect(Min, Max);
	}

	public HPoint Closest(HPoint t)
	{
		int numOrdinates = t.NumOrdinates;
		HPoint hPoint = new HPoint(numOrdinates);
		for (int i = 0; i < numOrdinates; i++)
		{
			if (t[i] <= Min[i])
			{
				hPoint[i] = Min[i];
			}
			else if (t[i] >= Max[i])
			{
				hPoint[i] = Max[i];
			}
			else
			{
				hPoint[i] = t[i];
			}
		}
		return hPoint;
	}

	public HPoint Farthest(HPoint t)
	{
		int numOrdinates = t.NumOrdinates;
		HPoint hPoint = new HPoint(numOrdinates);
		for (int i = 0; i < numOrdinates; i++)
		{
			if (t[i] <= Min[i])
			{
				hPoint[i] = Max[i];
			}
			else if (t[i] >= Max[i])
			{
				hPoint[i] = Min[i];
			}
			else if (t[i] - Min[i] > Max[i] - t[i])
			{
				hPoint[i] = Min[i];
			}
			else
			{
				hPoint[i] = Max[i];
			}
		}
		return hPoint;
	}

	public static HRect InfiniteHRect(int d)
	{
		HPoint hPoint = new HPoint(d);
		HPoint hPoint2 = new HPoint(d);
		for (int i = 0; i < d; i++)
		{
			hPoint[i] = double.NegativeInfinity;
			hPoint2[i] = double.PositiveInfinity;
		}
		return new HRect(hPoint, hPoint2);
	}

	public HRect Intersection(HRect region)
	{
		HPoint hPoint = new HPoint(Min.NumOrdinates);
		HPoint hPoint2 = new HPoint(Min.NumOrdinates);
		int num = 0;
		while (true)
		{
			if (num < Min.NumOrdinates)
			{
				hPoint[num] = Math.Max(Min[num], region.Min[num]);
				hPoint2[num] = Math.Min(Max[num], region.Max[num]);
				if (!(hPoint[num] < hPoint2[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return new HRect(hPoint, hPoint2);
		}
		return null;
	}

	public override string ToString()
	{
		return ((object)Min)?.ToString() + "\n" + ((object)Max)?.ToString() + "\n";
	}

	static HRect()
	{
		Class72.smethod_20();
	}
}
