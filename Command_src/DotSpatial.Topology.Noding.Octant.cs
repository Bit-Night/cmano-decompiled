using System;

namespace DotSpatial.Topology.Noding;

public static class Octant
{
	public static OctantDirection GetOctant(double dx, double dy)
	{
		if (dx == 0.0 && dy == 0.0)
		{
			throw new ArgumentException("Cannot compute the octant for point ( " + dx + ", " + dy + " )");
		}
		double num = Math.Abs(dx);
		double num2 = Math.Abs(dy);
		if (dx >= 0.0)
		{
			if (dy >= 0.0)
			{
				if (!(num >= num2))
				{
					return OctantDirection.One;
				}
				return OctantDirection.Zero;
			}
			if (!(num >= num2))
			{
				return OctantDirection.Six;
			}
			return OctantDirection.Seven;
		}
		if (dy >= 0.0)
		{
			if (!(num < num2))
			{
				return OctantDirection.Three;
			}
			return OctantDirection.Two;
		}
		if (!(num >= num2))
		{
			return OctantDirection.Five;
		}
		return OctantDirection.Four;
	}

	public static OctantDirection GetOctant(Coordinate p0, Coordinate p1)
	{
		double num = p1.X - p0.X;
		double num2 = p1.Y - p0.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			throw new ArgumentException("Cannot compute the octant for two identical points " + (object)p0);
		}
		return GetOctant(num, num2);
	}

	static Octant()
	{
		Class72.smethod_20();
	}
}
