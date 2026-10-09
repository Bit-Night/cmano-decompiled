using System.Collections.Generic;

namespace DotSpatial.Topology.Simplify;

public class DouglasPeuckerLineSimplifier
{
	private readonly IList<Coordinate> ilist_0;

	private readonly LineSegment lineSegment_0 = new LineSegment();

	private double double_0;

	private bool[] bool_0;

	private DouglasPeuckerLineSimplifier(IList<Coordinate> pts)
	{
		ilist_0 = pts;
	}

	public static IList<Coordinate> Simplify(IList<Coordinate> pts, double distanceTolerance)
	{
		return new DouglasPeuckerLineSimplifier(pts)
		{
			double_0 = distanceTolerance
		}.method_0();
	}

	private Coordinate[] method_0()
	{
		bool_0 = new bool[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			bool_0[i] = true;
		}
		method_1(0, ilist_0.Count - 1);
		CoordinateList coordinateList = new CoordinateList();
		for (int j = 0; j < ilist_0.Count; j++)
		{
			if (bool_0[j])
			{
				coordinateList.Add(new Coordinate(ilist_0[j]));
			}
		}
		return coordinateList.ToCoordinateArray();
	}

	private void method_1(int int_0, int int_1)
	{
		if (int_0 + 1 == int_1)
		{
			return;
		}
		lineSegment_0.P0 = ilist_0[int_0];
		lineSegment_0.P1 = ilist_0[int_1];
		double num = -1.0;
		int num2 = int_0;
		for (int i = int_0 + 1; i < int_1; i++)
		{
			double num3 = lineSegment_0.Distance(ilist_0[i]);
			if (num3 > num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num <= double_0)
		{
			for (int j = int_0 + 1; j < int_1; j++)
			{
				bool_0[j] = false;
			}
		}
		else
		{
			method_1(int_0, num2);
			method_1(num2, int_1);
		}
	}

	static DouglasPeuckerLineSimplifier()
	{
		Class72.smethod_20();
	}
}
