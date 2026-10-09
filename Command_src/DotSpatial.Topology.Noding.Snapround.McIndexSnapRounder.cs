using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding.Snapround;

public class McIndexSnapRounder : INoder
{
	private readonly LineIntersector lineIntersector_0;

	private readonly double double_0;

	private IList ilist_0;

	private McIndexNoder mcIndexNoder_0;

	private McIndexPointSnapper mcIndexPointSnapper_0;

	public McIndexSnapRounder(PrecisionModel pm)
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
		mcIndexNoder_0 = new McIndexNoder();
		mcIndexPointSnapper_0 = new McIndexPointSnapper(mcIndexNoder_0.Index);
		method_0(inputSegmentStrings, lineIntersector_0);
	}

	private void method_0(IList ilist_1, LineIntersector lineIntersector_1)
	{
		IList ilist_2 = method_1(ilist_1, lineIntersector_1);
		method_2(ilist_2);
		ComputeVertexSnaps(ilist_1);
	}

	private IList method_1(IList ilist_1, LineIntersector lineIntersector_1)
	{
		IntersectionFinderAdder intersectionFinderAdder = new IntersectionFinderAdder(lineIntersector_1);
		mcIndexNoder_0.SegmentIntersector = intersectionFinderAdder;
		mcIndexNoder_0.ComputeNodes(ilist_1);
		return intersectionFinderAdder.InteriorIntersections;
	}

	private void method_2(IList ilist_1)
	{
		foreach (Coordinate item in ilist_1)
		{
			HotPixel hotPixel = new HotPixel(item, double_0, lineIntersector_0);
			mcIndexPointSnapper_0.Snap(hotPixel);
		}
	}

	public void ComputeVertexSnaps(IList edges)
	{
		foreach (SegmentString edge in edges)
		{
			method_3(edge);
		}
	}

	private void method_3(SegmentString segmentString_0)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			HotPixel hotPixel = new HotPixel(coordinates[i], double_0, lineIntersector_0);
			if (mcIndexPointSnapper_0.Snap(hotPixel, segmentString_0, i))
			{
				segmentString_0.AddIntersection(coordinates[i], i);
			}
		}
	}

	static McIndexSnapRounder()
	{
		Class72.smethod_20();
	}
}
