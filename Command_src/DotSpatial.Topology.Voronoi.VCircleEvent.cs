namespace DotSpatial.Topology.Voronoi;

internal class VCircleEvent : VEvent
{
	public Vector2 Center;

	public VDataNode NodeL;

	public VDataNode NodeN;

	public VDataNode NodeR;

	public bool Valid = true;

	public override double Y => Center.Y + MathTools.Dist(NodeN.DataPoint.X, NodeN.DataPoint.Y, Center.X, Center.Y);

	protected override double X => Center.X;

	static VCircleEvent()
	{
		Class72.smethod_20();
	}
}
