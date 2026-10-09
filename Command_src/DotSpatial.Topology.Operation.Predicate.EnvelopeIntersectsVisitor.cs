using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Predicate;

internal class EnvelopeIntersectsVisitor : ShortCircuitedGeometryVisitor
{
	private readonly IEnvelope ienvelope_0;

	private bool bool_1;

	public EnvelopeIntersectsVisitor(IEnvelope rectEnv)
	{
		ienvelope_0 = rectEnv;
	}

	public bool Intersects()
	{
		return bool_1;
	}

	protected override void Visit(IGeometry element)
	{
		IEnvelope envelopeInternal = element.EnvelopeInternal;
		if (ienvelope_0.Intersects(envelopeInternal))
		{
			if (ienvelope_0.Contains(envelopeInternal))
			{
				bool_1 = true;
			}
			else if (envelopeInternal.Minimum.X >= ienvelope_0.Minimum.X && envelopeInternal.Maximum.X <= ienvelope_0.Maximum.X)
			{
				bool_1 = true;
			}
			else if (envelopeInternal.Minimum.Y >= ienvelope_0.Minimum.Y && envelopeInternal.Maximum.Y <= ienvelope_0.Maximum.Y)
			{
				bool_1 = true;
			}
		}
	}

	protected override bool IsDone()
	{
		return bool_1;
	}

	static EnvelopeIntersectsVisitor()
	{
		Class72.smethod_20();
	}
}
