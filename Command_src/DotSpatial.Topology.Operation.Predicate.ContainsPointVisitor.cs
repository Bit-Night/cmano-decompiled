using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Predicate;

internal class ContainsPointVisitor : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope ienvelope_0;

	private readonly IList<Coordinate> ilist_0;

	private bool bool_1;

	public ContainsPointVisitor(IPolygon rectangle)
	{
		ilist_0 = rectangle.Shell.Coordinates;
		ienvelope_0 = rectangle.EnvelopeInternal;
	}

	public bool ContainsPoint()
	{
		return bool_1;
	}

	protected override void Visit(IGeometry geom)
	{
		if (!(geom is Polygon))
		{
			return;
		}
		IEnvelope envelopeInternal = geom.EnvelopeInternal;
		if (!ienvelope_0.Intersects(envelopeInternal))
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			Coordinate p = ilist_0[i];
			if (envelopeInternal.Contains(p) && SimplePointInAreaLocator.ContainsPointInPolygon(p, (Polygon)geom))
			{
				bool_1 = true;
				break;
			}
		}
	}

	protected override bool IsDone()
	{
		return bool_1;
	}

	static ContainsPointVisitor()
	{
		Class72.smethod_20();
	}
}
