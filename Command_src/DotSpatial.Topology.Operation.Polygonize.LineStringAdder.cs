namespace DotSpatial.Topology.Operation.Polygonize;

public class LineStringAdder : IGeometryComponentFilter
{
	private readonly Polygonizer polygonizer_0;

	public LineStringAdder(Polygonizer container)
	{
		polygonizer_0 = container;
	}

	public virtual void Filter(IGeometry g)
	{
		if (g is ILineString g2)
		{
			polygonizer_0.Add(g2);
		}
	}

	static LineStringAdder()
	{
		Class72.smethod_20();
	}
}
