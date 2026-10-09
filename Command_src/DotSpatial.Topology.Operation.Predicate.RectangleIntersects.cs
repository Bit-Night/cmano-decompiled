namespace DotSpatial.Topology.Operation.Predicate;

public class RectangleIntersects
{
	public const int MAXIMUM_SCAN_SEGMENT_COUNT = 200;

	private readonly IEnvelope ienvelope_0;

	private readonly IPolygon ipolygon_0;

	public RectangleIntersects(IPolygon rectangle)
	{
		ipolygon_0 = rectangle;
		ienvelope_0 = rectangle.EnvelopeInternal;
	}

	public static bool Intersects(Polygon rectangle, IGeometry b)
	{
		return new RectangleIntersects(rectangle).Intersects(b);
	}

	public bool Intersects(IGeometry geom)
	{
		if (ienvelope_0.Intersects(geom.EnvelopeInternal))
		{
			EnvelopeIntersectsVisitor envelopeIntersectsVisitor = new EnvelopeIntersectsVisitor(ienvelope_0);
			envelopeIntersectsVisitor.ApplyTo(geom);
			if (!envelopeIntersectsVisitor.Intersects())
			{
				ContainsPointVisitor containsPointVisitor = new ContainsPointVisitor(ipolygon_0);
				containsPointVisitor.ApplyTo(geom);
				if (!containsPointVisitor.ContainsPoint())
				{
					LineIntersectsVisitor lineIntersectsVisitor = new LineIntersectsVisitor(ipolygon_0);
					lineIntersectsVisitor.ApplyTo(geom);
					if (!lineIntersectsVisitor.Intersects())
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return false;
	}

	static RectangleIntersects()
	{
		Class72.smethod_20();
	}
}
