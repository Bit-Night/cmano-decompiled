using System;

namespace DotSpatial.Topology.Voronoi;

internal abstract class VEvent : IComparable
{
	public abstract double Y { get; }

	protected abstract double X { get; }

	public int CompareTo(object obj)
	{
		if (obj is VEvent)
		{
			int num = Y.CompareTo(((VEvent)obj).Y);
			if (num != 0)
			{
				return num;
			}
			return X.CompareTo(((VEvent)obj).X);
		}
		throw new ArgumentException("obj not VEvent!");
	}

	static VEvent()
	{
		Class72.smethod_20();
	}
}
