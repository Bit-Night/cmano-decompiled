namespace DotSpatial.Topology.Simplify;

public class TaggedLineSegment : LineSegment
{
	private readonly int int_0;

	private readonly IGeometry igeometry_0;

	public virtual IGeometry Parent => igeometry_0;

	public virtual int Index => int_0;

	public TaggedLineSegment(Coordinate p0, Coordinate p1, IGeometry parent, int index)
		: base(p0, p1)
	{
		igeometry_0 = parent;
		int_0 = index;
	}

	public TaggedLineSegment(Coordinate p0, Coordinate p1)
		: this(p0, p1, null, -1)
	{
	}

	static TaggedLineSegment()
	{
		Class72.smethod_20();
	}
}
