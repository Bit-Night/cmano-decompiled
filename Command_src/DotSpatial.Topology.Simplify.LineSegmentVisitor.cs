using System.Collections;
using DotSpatial.Topology.Index;

namespace DotSpatial.Topology.Simplify;

public class LineSegmentVisitor : IItemVisitor
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly LineSegment lineSegment_0;

	public virtual ArrayList Items => arrayList_0;

	public LineSegmentVisitor(LineSegment querySeg)
	{
		lineSegment_0 = querySeg;
	}

	public virtual void VisitItem(object item)
	{
		LineSegment lineSegment = (LineSegment)item;
		if (Envelope.Intersects(lineSegment.P0, lineSegment.P1, lineSegment_0.P0, lineSegment_0.P1))
		{
			arrayList_0.Add(item);
		}
	}

	static LineSegmentVisitor()
	{
		Class72.smethod_20();
	}
}
