using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class SegmentString
{
	private readonly SegmentNodeList segmentNodeList_0;

	private readonly IList<Coordinate> OaaeNsahioQ;

	private object object_0;

	public object Data
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public SegmentNodeList NodeList => segmentNodeList_0;

	public int Count => OaaeNsahioQ.Count;

	public IList<Coordinate> Coordinates => OaaeNsahioQ;

	public bool IsClosed => OaaeNsahioQ[0].Equals(OaaeNsahioQ[OaaeNsahioQ.Count - 1]);

	public static IList GetNodedSubstrings(IList segStrings)
	{
		IList list = new ArrayList();
		GetNodedSubstrings(segStrings, list);
		return list;
	}

	public static void GetNodedSubstrings(IList segStrings, IList resultEdgelist)
	{
		foreach (SegmentString segString in segStrings)
		{
			segString.NodeList.AddSplitEdges(resultEdgelist);
		}
	}

	public SegmentString(IList<Coordinate> pts, object data)
	{
		segmentNodeList_0 = new SegmentNodeList(this);
		OaaeNsahioQ = pts;
		object_0 = data;
	}

	public Coordinate GetCoordinate(int i)
	{
		return OaaeNsahioQ[i];
	}

	public OctantDirection GetSegmentOctant(int index)
	{
		if (index == OaaeNsahioQ.Count - 1)
		{
			return OctantDirection.Null;
		}
		return Octant.GetOctant(GetCoordinate(index), GetCoordinate(index + 1));
	}

	public void AddIntersections(LineIntersector li, int segmentIndex)
	{
		for (int i = 0; i < li.IntersectionNum; i++)
		{
			AddIntersection(li, segmentIndex, i);
		}
	}

	public void AddIntersection(LineIntersector li, int segmentIndex, int intIndex)
	{
		Coordinate intPt = new Coordinate(li.GetIntersection(intIndex));
		AddIntersection(intPt, segmentIndex);
	}

	public void AddIntersection(Coordinate intPt, int segmentIndex)
	{
		int num = segmentIndex;
		int num2 = num + 1;
		if (num2 < OaaeNsahioQ.Count)
		{
			Coordinate b = OaaeNsahioQ[num2];
			if (intPt.Equals2D(b))
			{
				num = num2;
			}
		}
		segmentNodeList_0.Add(intPt, num);
	}

	static SegmentString()
	{
		Class72.smethod_20();
	}
}
