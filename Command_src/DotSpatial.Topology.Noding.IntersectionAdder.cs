using System;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IntersectionAdder : GInterface8
{
	private readonly LineIntersector lineIntersector_0;

	public int NumInteriorIntersections;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private int int_0;

	private int int_1;

	private int int_2;

	public LineIntersector LineIntersector => lineIntersector_0;

	public bool HasIntersection => bool_1;

	public bool HasProperIntersection => bool_2;

	public bool HasProperInteriorIntersection => bool_3;

	public bool HasInteriorIntersection => bool_0;

	public IntersectionAdder(LineIntersector li)
	{
		lineIntersector_0 = li;
	}

	public void ProcessIntersections(SegmentString e0, int segIndex0, SegmentString e1, int segIndex1)
	{
		if (e0 == e1 && segIndex0 == segIndex1)
		{
			return;
		}
		int_2++;
		Coordinate p = e0.Coordinates[segIndex0];
		Coordinate p2 = e0.Coordinates[segIndex0 + 1];
		Coordinate p3 = e1.Coordinates[segIndex1];
		Coordinate p4 = e1.Coordinates[segIndex1 + 1];
		lineIntersector_0.ComputeIntersection(p, p2, p3, p4);
		if (!lineIntersector_0.HasIntersection)
		{
			return;
		}
		int_0++;
		if (lineIntersector_0.IsInteriorIntersection())
		{
			NumInteriorIntersections++;
			bool_0 = true;
		}
		if (!method_0(e0, segIndex0, e1, segIndex1))
		{
			bool_1 = true;
			e0.AddIntersections(lineIntersector_0, segIndex0);
			e1.AddIntersections(lineIntersector_0, segIndex1);
			if (lineIntersector_0.IsProper)
			{
				int_1++;
				bool_2 = true;
				bool_3 = true;
			}
		}
	}

	private static bool smethod_0(int int_3, int int_4)
	{
		return Math.Abs(int_3 - int_4) == 1;
	}

	private bool method_0(SegmentString segmentString_0, int int_3, SegmentString segmentString_1, int int_4)
	{
		if (segmentString_0 == segmentString_1 && lineIntersector_0.IntersectionNum == 1)
		{
			if (smethod_0(int_3, int_4))
			{
				return true;
			}
			if (segmentString_0.IsClosed)
			{
				int num = segmentString_0.Count - 1;
				int result;
				if (int_3 == 0 && int_4 == num)
				{
					result = 1;
				}
				else
				{
					if (int_4 != 0 || int_3 != num)
					{
						goto IL_0047;
					}
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		goto IL_0047;
		IL_0047:
		return false;
	}

	static IntersectionAdder()
	{
		Class72.smethod_20();
	}
}
