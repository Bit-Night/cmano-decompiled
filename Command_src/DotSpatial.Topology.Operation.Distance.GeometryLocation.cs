namespace DotSpatial.Topology.Operation.Distance;

public class GeometryLocation
{
	public const int INSIDE_AREA = -1;

	private readonly IGeometry igeometry_0;

	private readonly Coordinate coordinate_0;

	private readonly int int_0;

	public virtual IGeometry GeometryComponent => igeometry_0;

	public virtual int SegmentIndex => int_0;

	public virtual Coordinate Coordinate => coordinate_0;

	public virtual bool IsInsideArea => int_0 == -1;

	public GeometryLocation(IGeometry component, int segIndex, Coordinate pt)
	{
		igeometry_0 = component;
		int_0 = segIndex;
		coordinate_0 = new Coordinate(pt);
	}

	public GeometryLocation(IGeometry component, Coordinate pt)
		: this(component, -1, pt)
	{
	}

	static GeometryLocation()
	{
		Class72.smethod_20();
	}
}
