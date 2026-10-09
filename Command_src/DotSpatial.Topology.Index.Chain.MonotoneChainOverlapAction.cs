using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChainOverlapAction
{
	private Envelope envelope_0 = new Envelope();

	private Envelope envelope_1 = new Envelope();

	[CompilerGenerated]
	private LineSegment lineSegment_0;

	[CompilerGenerated]
	private LineSegment lineSegment_1;

	public Envelope TempEnv1
	{
		get
		{
			return envelope_0;
		}
		set
		{
			envelope_0 = value;
		}
	}

	public Envelope TempEnv2
	{
		get
		{
			return envelope_1;
		}
		set
		{
			envelope_1 = value;
		}
	}

	protected LineSegment OverlapSeg1
	{
		[CompilerGenerated]
		get
		{
			return lineSegment_0;
		}
		[CompilerGenerated]
		set
		{
			lineSegment_0 = value;
		}
	}

	protected LineSegment OverlapSeg2
	{
		[CompilerGenerated]
		get
		{
			return lineSegment_1;
		}
		[CompilerGenerated]
		set
		{
			lineSegment_1 = value;
		}
	}

	public virtual void Overlap(MonotoneChain mc1, int start1, MonotoneChain mc2, int start2)
	{
		OverlapSeg1 = mc1.GetLineSegment(start1);
		OverlapSeg2 = mc2.GetLineSegment(start2);
		Overlap(OverlapSeg1, OverlapSeg2);
	}

	public virtual void Overlap(LineSegment seg1, LineSegment seg2)
	{
	}

	static MonotoneChainOverlapAction()
	{
		Class72.smethod_20();
	}
}
