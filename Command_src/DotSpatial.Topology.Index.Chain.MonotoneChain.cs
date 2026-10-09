using System.Collections.Generic;

namespace DotSpatial.Topology.Index.Chain;

public class MonotoneChain
{
	private readonly object object_0;

	private readonly int int_0;

	private readonly IList<Coordinate> ilist_0;

	private readonly int int_1;

	private Envelope envelope_0;

	private int int_2;

	public virtual int Id
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public virtual object Context => object_0;

	public virtual Envelope Envelope
	{
		get
		{
			if (envelope_0 == null)
			{
				Coordinate p = ilist_0[int_1];
				Coordinate p2 = ilist_0[int_0];
				envelope_0 = new Envelope(p, p2);
			}
			return envelope_0;
		}
	}

	public virtual int StartIndex => int_1;

	public virtual int EndIndex => int_0;

	public virtual Coordinate[] Coordinates
	{
		get
		{
			Coordinate[] array = new Coordinate[int_0 - int_1 + 1];
			int num = 0;
			for (int i = int_1; i <= int_0; i++)
			{
				array[num++] = ilist_0[i];
			}
			return array;
		}
	}

	public MonotoneChain(IList<Coordinate> pts, int start, int end, object context)
	{
		ilist_0 = pts;
		int_1 = start;
		int_0 = end;
		object_0 = context;
	}

	public virtual LineSegment GetLineSegment(int index)
	{
		return new LineSegment(ilist_0[index], ilist_0[index + 1]);
	}

	public virtual void Select(IEnvelope searchEnv, MonotoneChainSelectAction mcs)
	{
		method_0(searchEnv, int_1, int_0, mcs);
	}

	private void method_0(IEnvelope ienvelope_0, int int_3, int int_4, MonotoneChainSelectAction monotoneChainSelectAction_0)
	{
		Coordinate p = ilist_0[int_3];
		Coordinate p2 = ilist_0[int_4];
		monotoneChainSelectAction_0.TempEnv1.Init(p, p2);
		if (int_4 - int_3 == 1)
		{
			monotoneChainSelectAction_0.Select(this, int_3);
		}
		else if (ienvelope_0.Intersects(monotoneChainSelectAction_0.TempEnv1))
		{
			int num = (int_3 + int_4) / 2;
			if (int_3 < num)
			{
				method_0(ienvelope_0, int_3, num, monotoneChainSelectAction_0);
			}
			if (num < int_4)
			{
				method_0(ienvelope_0, num, int_4, monotoneChainSelectAction_0);
			}
		}
	}

	public virtual void ComputeOverlaps(MonotoneChain mc, MonotoneChainOverlapAction mco)
	{
		method_1(int_1, int_0, mc, mc.int_1, mc.int_0, mco);
	}

	private void method_1(int int_3, int int_4, MonotoneChain monotoneChain_0, int int_5, int int_6, MonotoneChainOverlapAction monotoneChainOverlapAction_0)
	{
		Coordinate p = ilist_0[int_3];
		Coordinate p2 = ilist_0[int_4];
		Coordinate p3 = monotoneChain_0.ilist_0[int_5];
		Coordinate p4 = monotoneChain_0.ilist_0[int_6];
		if (int_4 - int_3 == 1 && int_6 - int_5 == 1)
		{
			monotoneChainOverlapAction_0.Overlap(this, int_3, monotoneChain_0, int_5);
			return;
		}
		monotoneChainOverlapAction_0.TempEnv1.Init(p, p2);
		monotoneChainOverlapAction_0.TempEnv2.Init(p3, p4);
		if (!monotoneChainOverlapAction_0.TempEnv1.Intersects(monotoneChainOverlapAction_0.TempEnv2))
		{
			return;
		}
		int num = (int_3 + int_4) / 2;
		int num2 = (int_5 + int_6) / 2;
		if (int_3 < num)
		{
			if (int_5 < num2)
			{
				method_1(int_3, num, monotoneChain_0, int_5, num2, monotoneChainOverlapAction_0);
			}
			if (num2 < int_6)
			{
				method_1(int_3, num, monotoneChain_0, num2, int_6, monotoneChainOverlapAction_0);
			}
		}
		if (num < int_4)
		{
			if (int_5 < num2)
			{
				method_1(num, int_4, monotoneChain_0, int_5, num2, monotoneChainOverlapAction_0);
			}
			if (num2 < int_6)
			{
				method_1(num, int_4, monotoneChain_0, num2, int_6, monotoneChainOverlapAction_0);
			}
		}
	}

	static MonotoneChain()
	{
		Class72.smethod_20();
	}
}
