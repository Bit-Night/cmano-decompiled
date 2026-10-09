namespace DotSpatial.Topology.Noding;

public class SegmentPointComparator
{
	public static int Compare(OctantDirection octant, Coordinate p0, Coordinate p1)
	{
		if (p0.Equals2D(p1))
		{
			return 0;
		}
		int num = RelativeSign(p0.X, p1.X);
		int num2 = RelativeSign(p0.Y, p1.Y);
		return octant switch
		{
			OctantDirection.Zero => smethod_0(num, num2), 
			OctantDirection.One => smethod_0(num2, num), 
			OctantDirection.Two => smethod_0(num2, -num), 
			OctantDirection.Three => smethod_0(-num, num2), 
			OctantDirection.Four => smethod_0(-num, -num2), 
			OctantDirection.Five => smethod_0(-num2, -num), 
			OctantDirection.Six => smethod_0(-num2, num), 
			OctantDirection.Seven => smethod_0(num, -num2), 
			_ => throw new InvalidOctantException(octant.ToString()), 
		};
	}

	public static int RelativeSign(double x0, double x1)
	{
		if (x0 < x1)
		{
			return -1;
		}
		if (x0 > x1)
		{
			return 1;
		}
		return 0;
	}

	private static int smethod_0(int int_0, int int_1)
	{
		if (int_0 >= 0)
		{
			if (int_0 > 0)
			{
				return 1;
			}
			if (int_1 < 0)
			{
				return -1;
			}
			if (int_1 > 0)
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}

	static SegmentPointComparator()
	{
		Class72.smethod_20();
	}
}
