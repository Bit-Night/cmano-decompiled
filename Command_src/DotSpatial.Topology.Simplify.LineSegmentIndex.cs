using System.Collections;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.Simplify;

public class LineSegmentIndex
{
	private readonly Quadtree quadtree_0 = new Quadtree();

	public virtual void Add(TaggedLineString line)
	{
		TaggedLineSegment[] segments = line.Segments;
		for (int i = 0; i < segments.Length - 1; i++)
		{
			TaggedLineSegment seg = segments[i];
			Add(seg);
		}
	}

	public virtual void Add(LineSegment seg)
	{
		quadtree_0.Insert(new Envelope(seg.P0, seg.P1), seg);
	}

	public virtual void Remove(LineSegment seg)
	{
		quadtree_0.Remove(new Envelope(seg.P0, seg.P1), seg);
	}

	public virtual IList Query(LineSegment querySeg)
	{
		Envelope searchEnv = new Envelope(querySeg.P0, querySeg.P1);
		LineSegmentVisitor lineSegmentVisitor = new LineSegmentVisitor(querySeg);
		quadtree_0.Query(searchEnv, lineSegmentVisitor);
		return lineSegmentVisitor.Items;
	}

	static LineSegmentIndex()
	{
		Class72.smethod_20();
	}
}
