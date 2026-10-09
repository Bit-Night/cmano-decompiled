using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Noding;

public class OrientedCoordinateArray : IComparable
{
	private readonly bool bool_0;

	private readonly IList<Coordinate> ilist_0;

	public OrientedCoordinateArray(IList<Coordinate> pts)
	{
		ilist_0 = pts;
		bool_0 = Orientation(pts);
	}

	public int CompareTo(object o1)
	{
		OrientedCoordinateArray orientedCoordinateArray = (OrientedCoordinateArray)o1;
		return smethod_0(ilist_0, bool_0, orientedCoordinateArray.ilist_0, orientedCoordinateArray.bool_0);
	}

	private static bool Orientation(IList<Coordinate> pts)
	{
		return CoordinateArrays.IncreasingDirection(pts) == 1;
	}

	private static int smethod_0(IList<Coordinate> ilist_1, bool bool_1, IList<Coordinate> ilist_2, bool bool_2)
	{
		int num = (bool_1 ? 1 : (-1));
		int num2 = (bool_2 ? 1 : (-1));
		int num3 = ((!bool_1) ? (-1) : ilist_1.Count);
		int num4 = ((!bool_2) ? (-1) : ilist_2.Count);
		int num5 = ((!bool_1) ? (ilist_1.Count - 1) : 0);
		int num6 = ((!bool_2) ? (ilist_2.Count - 1) : 0);
		int num7;
		while (true)
		{
			num7 = ilist_1[num5].CompareTo(ilist_2[num6]);
			if (num7 != 0)
			{
				break;
			}
			num5 += num;
			num6 += num2;
			bool flag = num5 == num3;
			bool flag2 = num6 == num4;
			if (!flag || flag2)
			{
				if (!(!flag && flag2))
				{
					if (flag)
					{
						return 0;
					}
					continue;
				}
				return 1;
			}
			return -1;
		}
		return num7;
	}

	static OrientedCoordinateArray()
	{
		Class72.smethod_20();
	}
}
