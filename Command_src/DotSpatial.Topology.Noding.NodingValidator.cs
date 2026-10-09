using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class NodingValidator
{
	private readonly LineIntersector lineIntersector_0 = new RobustLineIntersector();

	private readonly IList ilist_0;

	public NodingValidator(IList segStrings)
	{
		ilist_0 = segStrings;
	}

	public void CheckValid()
	{
		method_4();
		method_1();
		method_0();
	}

	private void method_0()
	{
		foreach (SegmentString item in ilist_0)
		{
			smethod_0(item);
		}
	}

	private static void smethod_0(SegmentString segmentString_0)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		for (int i = 0; i < coordinates.Count - 2; i++)
		{
			smethod_1(coordinates[i], coordinates[i + 1], coordinates[i + 2]);
		}
	}

	private static void smethod_1(object object_0, object object_1, object object_2)
	{
		if (object_0.Equals(object_2))
		{
			throw new Exception("found non-noded collapse at: " + object_0?.ToString() + ", " + object_1?.ToString() + " " + object_2);
		}
	}

	private void method_1()
	{
		foreach (SegmentString item in ilist_0)
		{
			foreach (SegmentString item2 in ilist_0)
			{
				method_2(item, item2);
			}
		}
	}

	private void method_2(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				method_3(segmentString_0, i, segmentString_1, j);
			}
		}
	}

	private void method_3(SegmentString segmentString_0, int int_0, SegmentString segmentString_1, int int_1)
	{
		if (segmentString_0 == segmentString_1 && int_0 == int_1)
		{
			return;
		}
		Coordinate coordinate = segmentString_0.Coordinates[int_0];
		Coordinate coordinate2 = segmentString_0.Coordinates[int_0 + 1];
		Coordinate coordinate3 = segmentString_1.Coordinates[int_1];
		Coordinate coordinate4 = segmentString_1.Coordinates[int_1 + 1];
		lineIntersector_0.ComputeIntersection(coordinate, coordinate2, coordinate3, coordinate4);
		if (!lineIntersector_0.HasIntersection)
		{
			return;
		}
		int num;
		if (lineIntersector_0.IsProper)
		{
			num = 8;
		}
		else if (!smethod_2(lineIntersector_0, coordinate, coordinate2))
		{
			if (!smethod_2(lineIntersector_0, coordinate3, coordinate4))
			{
				return;
			}
			num = 8;
		}
		else
		{
			num = 8;
		}
		string[] array = new string[num];
		array[0] = "found non-noded intersection at ";
		array[1] = ((object)coordinate)?.ToString();
		array[2] = "-";
		array[3] = ((object)coordinate2)?.ToString();
		array[4] = " and ";
		array[5] = ((object)coordinate3)?.ToString();
		array[6] = "-";
		array[7] = ((object)coordinate4)?.ToString();
		throw new Exception(string.Concat(array));
	}

	private static bool smethod_2(LineIntersector lineIntersector_1, object object_0, object object_1)
	{
		int num = 0;
		while (true)
		{
			if (num < lineIntersector_1.IntersectionNum)
			{
				Coordinate intersection = lineIntersector_1.GetIntersection(num);
				if (!intersection.Equals(object_0) && !intersection.Equals(object_1))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_4()
	{
		foreach (SegmentString item in ilist_0)
		{
			IList<Coordinate> coordinates = item.Coordinates;
			smethod_3(coordinates[0], ilist_0);
			smethod_3(coordinates[coordinates.Count - 1], ilist_0);
		}
	}

	private static void smethod_3(object object_0, IEnumerable ienumerable_0)
	{
		foreach (SegmentString item in ienumerable_0)
		{
			IList<Coordinate> coordinates = item.Coordinates;
			for (int i = 1; i < coordinates.Count - 1; i++)
			{
				if (coordinates[i].Equals(object_0))
				{
					throw new Exception("found endpt/interior pt intersection at index " + i + " :pt " + object_0);
				}
			}
		}
	}

	static NodingValidator()
	{
		Class72.smethod_20();
	}
}
