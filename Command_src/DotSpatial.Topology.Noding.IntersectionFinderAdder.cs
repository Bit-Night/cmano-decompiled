using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IntersectionFinderAdder : GInterface8
{
	private readonly IList ilist_0;

	private readonly LineIntersector lineIntersector_0;

	public IList InteriorIntersections => ilist_0;

	public IntersectionFinderAdder(LineIntersector li)
	{
		lineIntersector_0 = li;
		ilist_0 = new ArrayList();
	}

	public void ProcessIntersections(SegmentString e0, int segIndex0, SegmentString e1, int segIndex1)
	{
		if (e0 == e1 && segIndex0 == segIndex1)
		{
			return;
		}
		Coordinate p = e0.Coordinates[segIndex0];
		Coordinate p2 = e0.Coordinates[segIndex0 + 1];
		Coordinate p3 = e1.Coordinates[segIndex1];
		Coordinate p4 = e1.Coordinates[segIndex1 + 1];
		lineIntersector_0.ComputeIntersection(p, p2, p3, p4);
		if (lineIntersector_0.HasIntersection && lineIntersector_0.IsInteriorIntersection())
		{
			for (int i = 0; i < lineIntersector_0.IntersectionNum; i++)
			{
				ilist_0.Add(lineIntersector_0.GetIntersection(i));
			}
			e0.AddIntersections(lineIntersector_0, segIndex0);
			e1.AddIntersections(lineIntersector_0, segIndex1);
		}
	}

	static IntersectionFinderAdder()
	{
		Class72.smethod_20();
	}
}
