using System.Collections;

namespace DotSpatial.Topology.Simplify;

public class TaggedLinesSimplifier
{
	private readonly LineSegmentIndex lineSegmentIndex_0 = new LineSegmentIndex();

	private readonly LineSegmentIndex lineSegmentIndex_1 = new LineSegmentIndex();

	private double double_0;

	public virtual double DistanceTolerance
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public virtual void Simplify(IList taggedLines)
	{
		IEnumerator enumerator = taggedLines.GetEnumerator();
		while (enumerator.MoveNext())
		{
			lineSegmentIndex_0.Add((TaggedLineString)enumerator.Current);
		}
		IEnumerator enumerator2 = taggedLines.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			TaggedLineStringSimplifier taggedLineStringSimplifier = new TaggedLineStringSimplifier(lineSegmentIndex_0, lineSegmentIndex_1);
			taggedLineStringSimplifier.DistanceTolerance = double_0;
			taggedLineStringSimplifier.Simplify((TaggedLineString)enumerator2.Current);
		}
	}

	static TaggedLinesSimplifier()
	{
		Class72.smethod_20();
	}
}
