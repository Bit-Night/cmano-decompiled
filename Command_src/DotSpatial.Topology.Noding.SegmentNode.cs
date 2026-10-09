using System;
using System.IO;

namespace DotSpatial.Topology.Noding;

public class SegmentNode : IComparable
{
	public readonly Coordinate Coordinate;

	public readonly int SegmentIndex;

	private readonly bool bool_0;

	private readonly OctantDirection octantDirection_0 = OctantDirection.Null;

	public bool IsInterior => bool_0;

	public SegmentNode(SegmentString segString, Coordinate coord, int segmentIndex, OctantDirection segmentOctant)
	{
		Coordinate = new Coordinate(coord);
		SegmentIndex = segmentIndex;
		octantDirection_0 = segmentOctant;
		bool_0 = !coord.Equals2D(segString.GetCoordinate(segmentIndex));
	}

	public int CompareTo(object obj)
	{
		SegmentNode segmentNode = (SegmentNode)obj;
		if (SegmentIndex < segmentNode.SegmentIndex)
		{
			return -1;
		}
		if (SegmentIndex > segmentNode.SegmentIndex)
		{
			return 1;
		}
		if (Coordinate.Equals2D(segmentNode.Coordinate))
		{
			return 0;
		}
		return SegmentPointComparator.Compare(octantDirection_0, Coordinate, segmentNode.Coordinate);
	}

	public bool IsEndPoint(int maxSegmentIndex)
	{
		if (SegmentIndex == 0 && !bool_0)
		{
			return true;
		}
		if (SegmentIndex == maxSegmentIndex)
		{
			return true;
		}
		return false;
	}

	public void Write(StreamWriter outstream)
	{
		outstream.Write(Coordinate);
		int segmentIndex = SegmentIndex;
		outstream.Write(" seg # = " + segmentIndex);
	}

	static SegmentNode()
	{
		Class72.smethod_20();
	}
}
