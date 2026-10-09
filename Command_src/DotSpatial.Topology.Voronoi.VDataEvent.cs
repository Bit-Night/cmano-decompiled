namespace DotSpatial.Topology.Voronoi;

internal class VDataEvent : VEvent
{
	public readonly Vector2 DataPoint;

	public override double Y => DataPoint.Y;

	protected override double X => DataPoint.X;

	public VDataEvent(Vector2 dp)
	{
		DataPoint = dp;
	}

	static VDataEvent()
	{
		Class72.smethod_20();
	}
}
