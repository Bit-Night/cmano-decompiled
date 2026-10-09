namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChainSelectAction
{
	public Envelope TempEnv1 = new Envelope();

	private LineSegment lineSegment_0;

	public virtual void Select(MonotoneChain mc, int start)
	{
		lineSegment_0 = mc.GetLineSegment(start);
		Select(lineSegment_0);
	}

	public virtual void Select(LineSegment seg)
	{
	}

	static MonotoneChainSelectAction()
	{
		Class72.smethod_20();
	}
}
