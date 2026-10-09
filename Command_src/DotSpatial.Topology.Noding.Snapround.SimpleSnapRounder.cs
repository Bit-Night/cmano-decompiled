using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding.Snapround;

public class SimpleSnapRounder : INoder
{
	private readonly LineIntersector lineIntersector_0;

	private readonly double double_0;

	private IList ilist_0;

	public SimpleSnapRounder(PrecisionModel pm)
	{
		lineIntersector_0 = new RobustLineIntersector();
		lineIntersector_0.PrecisionModel = pm;
		double_0 = pm.Scale;
	}

	public IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(ilist_0);
	}

	public void ComputeNodes(IList inputSegmentStrings)
	{
		ilist_0 = inputSegmentStrings;
		method_0(inputSegmentStrings, lineIntersector_0);
	}

	private void method_0(IList ilist_1, LineIntersector lineIntersector_1)
	{
		IList ilist_2 = smethod_0(ilist_1, lineIntersector_1);
		method_1(ilist_1, ilist_2);
		ComputeVertexSnaps(ilist_1);
	}

	private static IList smethod_0(IList ilist_1, LineIntersector lineIntersector_1)
	{
		IntersectionFinderAdder intersectionFinderAdder = new IntersectionFinderAdder(lineIntersector_1);
		new McIndexNoder(intersectionFinderAdder).ComputeNodes(ilist_1);
		return intersectionFinderAdder.InteriorIntersections;
	}

	private void method_1(IList ilist_1, IList ilist_2)
	{
		foreach (SegmentString item in ilist_1)
		{
			method_2(item, ilist_2);
		}
	}

	private void method_2(SegmentString segmentString_0, IList ilist_1)
	{
		foreach (Coordinate item in ilist_1)
		{
			HotPixel hotPix = new HotPixel(item, double_0, lineIntersector_0);
			for (int i = 0; i < segmentString_0.Count - 1; i++)
			{
				AddSnappedNode(hotPix, segmentString_0, i);
			}
		}
	}

	public void ComputeVertexSnaps(IList edges)
	{
		foreach (SegmentString edge in edges)
		{
			foreach (SegmentString edge2 in edges)
			{
				method_3(edge, edge2);
			}
		}
	}

	private void method_3(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			HotPixel hotPix = new HotPixel(coordinates[i], double_0, lineIntersector_0);
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				if ((segmentString_0 != segmentString_1 || i != j) && AddSnappedNode(hotPix, segmentString_1, j))
				{
					segmentString_0.AddIntersection(coordinates[i], i);
				}
			}
		}
	}

	public static bool AddSnappedNode(HotPixel hotPix, SegmentString segStr, int segIndex)
	{
		Coordinate coordinate = segStr.GetCoordinate(segIndex);
		Coordinate coordinate2 = segStr.GetCoordinate(segIndex + 1);
		if (hotPix.Intersects(coordinate, coordinate2))
		{
			segStr.AddIntersection(hotPix.Coordinate, segIndex);
			return true;
		}
		return false;
	}

	static SimpleSnapRounder()
	{
		Class72.smethod_20();
	}
}
