using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Predicate;

internal class LineIntersectsVisitor : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope ienvelope_0;

	private readonly IList<Coordinate> ilist_0;

	private readonly IPolygon ipolygon_0;

	private bool bool_1;

	public LineIntersectsVisitor(IPolygon rectangle)
	{
		ipolygon_0 = rectangle;
		ilist_0 = rectangle.Shell.Coordinates;
		ienvelope_0 = rectangle.EnvelopeInternal;
	}

	public bool Intersects()
	{
		return bool_1;
	}

	protected override void Visit(IGeometry geom)
	{
		IEnvelope envelopeInternal = geom.EnvelopeInternal;
		if (ienvelope_0.Intersects(envelopeInternal))
		{
			if (geom.NumPoints <= 200)
			{
				method_0(geom);
			}
			else
			{
				bool_1 = ipolygon_0.Relate(geom).IsIntersects();
			}
		}
	}

	private void method_0(IGeometry igeometry_0)
	{
		IList lines = LinearComponentExtracter.GetLines(igeometry_0);
		if (new SegmentIntersectionTester().HasIntersectionWithLineStrings(ilist_0, lines))
		{
			bool_1 = true;
		}
	}

	protected override bool IsDone()
	{
		return bool_1;
	}

	static LineIntersectsVisitor()
	{
		Class72.smethod_20();
	}
}
