using System;

namespace DotSpatial.Topology.GeometriesGraph;

public class QuadrantOp
{
	private QuadrantOp()
	{
	}

	public static int Quadrant(double dx, double dy)
	{
		if (dx == 0.0 && dy == 0.0)
		{
			throw new ArgumentException("Cannot compute the quadrant for point ( " + dx + ", " + dy + " )");
		}
		if (dx >= 0.0)
		{
			if (!(dy >= 0.0))
			{
				return 3;
			}
			return 0;
		}
		if (!(dy >= 0.0))
		{
			return 2;
		}
		return 1;
	}

	public static int Quadrant(Coordinate p0, Coordinate p1)
	{
		double num = p1.X - p0.X;
		double num2 = p1.Y - p0.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			throw new ArgumentException("Cannot compute the quadrant for two identical points " + (object)p0);
		}
		return Quadrant(num, num2);
	}

	public static bool IsOpposite(int quad1, int quad2)
	{
		if (quad1 == quad2)
		{
			return false;
		}
		if ((quad1 - quad2 + 4) % 4 == 2)
		{
			return true;
		}
		return false;
	}

	public static int CommonHalfPlane(int quad1, int quad2)
	{
		if (quad1 == quad2)
		{
			return quad1;
		}
		if ((quad1 - quad2 + 4) % 4 == 2)
		{
			return -1;
		}
		int num = ((quad1 >= quad2) ? quad2 : quad1);
		int num2 = ((quad1 <= quad2) ? quad2 : quad1);
		if (num == 0 && num2 == 3)
		{
			return 3;
		}
		return num;
	}

	public static bool IsInHalfPlane(int quad, int halfPlane)
	{
		if (halfPlane == 3)
		{
			if (quad != 3)
			{
				return quad == 0;
			}
			return true;
		}
		if (quad != halfPlane)
		{
			return quad == halfPlane + 1;
		}
		return true;
	}

	public static bool IsNorthern(int quad)
	{
		if (quad != 0)
		{
			return quad == 1;
		}
		return true;
	}

	static QuadrantOp()
	{
		Class72.smethod_20();
	}
}
