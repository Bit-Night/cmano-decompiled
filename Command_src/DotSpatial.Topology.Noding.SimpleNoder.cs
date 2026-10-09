using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Noding;

public class SimpleNoder : SinglePassNoder
{
	private IList ilist_0;

	public SimpleNoder()
	{
	}

	public SimpleNoder(GInterface8 segInt)
		: base(segInt)
	{
	}

	public override IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(ilist_0);
	}

	public override void ComputeNodes(IList inputSegStrings)
	{
		ilist_0 = inputSegStrings;
		foreach (SegmentString inputSegString in inputSegStrings)
		{
			foreach (SegmentString inputSegString2 in inputSegStrings)
			{
				mVfeNnhJneO(inputSegString, inputSegString2);
			}
		}
	}

	private void mVfeNnhJneO(SegmentString segmentString_0, SegmentString segmentString_1)
	{
		IList<Coordinate> coordinates = segmentString_0.Coordinates;
		IList<Coordinate> coordinates2 = segmentString_1.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			for (int j = 0; j < coordinates2.Count - 1; j++)
			{
				base.SegmentIntersector.ProcessIntersections(segmentString_0, i, segmentString_1, j);
			}
		}
	}

	static SimpleNoder()
	{
		Class72.smethod_20();
	}
}
