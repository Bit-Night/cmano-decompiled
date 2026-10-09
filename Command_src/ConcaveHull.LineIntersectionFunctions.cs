using System;

namespace ConcaveHull;

public static class LineIntersectionFunctions
{
	public static bool doIntersect(Node p1, Node q1, Node p2, Node q2)
	{
		int num = smethod_1(p1, q1, p2);
		int num2 = smethod_1(p1, q1, q2);
		int num3 = smethod_1(p2, q2, p1);
		int num4 = smethod_1(p2, q2, q1);
		if (num != num2 && num3 != num4)
		{
			return true;
		}
		if (num == 0 && smethod_0(p1, p2, q1))
		{
			return true;
		}
		if (num2 == 0 && smethod_0(p1, q2, q1))
		{
			return true;
		}
		if (num3 == 0 && smethod_0(p2, p1, q2))
		{
			return true;
		}
		int result;
		if (num4 != 0)
		{
			result = 0;
		}
		else
		{
			if (smethod_0(p2, q1, q2))
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private static bool smethod_0(object object_0, object object_1, object object_2)
	{
		if (((Node)object_1).x <= Math.Max(((Node)object_0).x, ((Node)object_2).x) && ((Node)object_1).x >= Math.Min(((Node)object_0).x, ((Node)object_2).x) && ((Node)object_1).y <= Math.Max(((Node)object_0).y, ((Node)object_2).y) && ((Node)object_1).y >= Math.Min(((Node)object_0).y, ((Node)object_2).y))
		{
			return true;
		}
		return false;
	}

	private static int smethod_1(object object_0, object object_1, object object_2)
	{
		double num = (((Node)object_1).y - ((Node)object_0).y) * (((Node)object_2).x - ((Node)object_1).x) - (((Node)object_1).x - ((Node)object_0).x) * (((Node)object_2).y - ((Node)object_1).y);
		if (num == 0.0)
		{
			return 0;
		}
		if (!(num > 0.0))
		{
			return 2;
		}
		return 1;
	}

	static LineIntersectionFunctions()
	{
		Class72.smethod_20();
	}
}
