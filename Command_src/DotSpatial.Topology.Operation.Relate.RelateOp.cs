namespace DotSpatial.Topology.Operation.Relate;

public class RelateOp : GeometryGraphOperation
{
	private readonly RelateComputer relateComputer_0;

	public virtual IntersectionMatrix IntersectionMatrix => relateComputer_0.ComputeIm();

	public RelateOp(IGeometry g0, IGeometry g1)
		: base(g0, g1)
	{
		relateComputer_0 = new RelateComputer(Arg);
	}

	public static IntersectionMatrix Relate(IGeometry a, IGeometry b)
	{
		return new RelateOp(a, b).IntersectionMatrix;
	}

	static RelateOp()
	{
		Class72.smethod_20();
	}
}
