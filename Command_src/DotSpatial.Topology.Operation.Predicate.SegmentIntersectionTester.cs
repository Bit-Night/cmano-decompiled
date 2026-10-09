using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Operation.Predicate;

public class SegmentIntersectionTester
{
	private readonly LineIntersector lineIntersector_0 = new RobustLineIntersector();

	private bool bool_0;

	private Coordinate coordinate_0;

	private Coordinate coordinate_1;

	private Coordinate coordinate_2;

	private Coordinate coordinate_3;

	public bool HasIntersectionWithLineStrings(IList<Coordinate> seq, IList lines)
	{
		IEnumerator enumerator = lines.GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineString lineString = (LineString)enumerator.Current;
			method_0(seq, lineString.Coordinates);
			if (bool_0)
			{
				break;
			}
		}
		return bool_0;
	}

	private void method_0(IList<Coordinate> ilist_0, IList<Coordinate> ilist_1)
	{
		for (int i = 1; i < ilist_0.Count; i++)
		{
			if (bool_0)
			{
				break;
			}
			coordinate_0 = ilist_0[i - 1];
			coordinate_1 = ilist_0[i];
			for (int j = 1; j < ilist_1.Count; j++)
			{
				if (bool_0)
				{
					break;
				}
				coordinate_2 = ilist_1[j - 1];
				coordinate_3 = ilist_1[j];
				lineIntersector_0.ComputeIntersection(coordinate_0, coordinate_1, coordinate_2, coordinate_3);
				if (lineIntersector_0.HasIntersection)
				{
					bool_0 = true;
				}
			}
		}
	}

	static SegmentIntersectionTester()
	{
		Class72.smethod_20();
	}
}
