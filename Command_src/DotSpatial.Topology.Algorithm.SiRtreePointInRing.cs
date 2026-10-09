using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Algorithm;

public class SiRtreePointInRing : IPointInRing
{
	private readonly LinearRing linearRing_0;

	private int int_0;

	private SiRtree siRtree_0;

	public SiRtreePointInRing(LinearRing ring)
	{
		linearRing_0 = ring;
		method_0();
	}

	public bool IsInside(Coordinate pt)
	{
		int_0 = 0;
		IEnumerator enumerator = siRtree_0.Query(pt.Y).GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineSegment ilineSegmentBase_ = (LineSegment)enumerator.Current;
			method_1(pt, ilineSegmentBase_);
		}
		if (int_0 % 2 == 1)
		{
			return true;
		}
		return false;
	}

	private void method_0()
	{
		siRtree_0 = new SiRtree();
		IList<Coordinate> coordinates = linearRing_0.Coordinates;
		for (int i = 1; i < coordinates.Count; i++)
		{
			if (!coordinates[i - 1].Equals(coordinates[i]))
			{
				LineSegment lineSegment = new LineSegment(coordinates[i - 1], coordinates[i]);
				siRtree_0.Insert(lineSegment.P0.Y, lineSegment.P1.Y, lineSegment);
			}
		}
	}

	private void method_1(Coordinate coordinate_0, ILineSegmentBase ilineSegmentBase_0)
	{
		Coordinate p = ilineSegmentBase_0.P0;
		Coordinate p2 = ilineSegmentBase_0.P1;
		double x = p.X - coordinate_0.X;
		double num = p.Y - coordinate_0.Y;
		double x2 = p2.X - coordinate_0.X;
		double num2 = p2.Y - coordinate_0.Y;
		if ((num > 0.0 && num2 <= 0.0) || (num2 > 0.0 && num <= 0.0))
		{
			double num3 = (double)RobustDeterminant.SignOfDet2X2(x, num, x2, num2) / (num2 - num);
			if (0.0 < num3)
			{
				int_0++;
			}
		}
	}

	static SiRtreePointInRing()
	{
		Class72.smethod_20();
	}
}
