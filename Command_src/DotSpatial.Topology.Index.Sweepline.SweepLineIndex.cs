using System.Collections;

namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineIndex
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private bool bool_0;

	private int int_0;

	public virtual void Add(SweepLineInterval sweepInt)
	{
		SweepLineEvent sweepLineEvent = new SweepLineEvent(sweepInt.Min, null, sweepInt);
		arrayList_0.Add(sweepLineEvent);
		arrayList_0.Add(new SweepLineEvent(sweepInt.Max, sweepLineEvent, sweepInt));
	}

	private void method_0()
	{
		if (bool_0)
		{
			return;
		}
		arrayList_0.Sort();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsDelete)
			{
				sweepLineEvent.InsertEvent.DeleteEventIndex = i;
			}
		}
		bool_0 = true;
	}

	public virtual void ComputeOverlaps(ISweepLineOverlapAction action)
	{
		int_0 = 0;
		method_0();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsInsert)
			{
				method_1(i, sweepLineEvent.DeleteEventIndex, sweepLineEvent.Interval, action);
			}
		}
	}

	private void method_1(int int_1, int int_2, SweepLineInterval sweepLineInterval_0, ISweepLineOverlapAction isweepLineOverlapAction_0)
	{
		for (int i = int_1; i < int_2; i++)
		{
			SweepLineEvent sweepLineEvent = (SweepLineEvent)arrayList_0[i];
			if (sweepLineEvent.IsInsert)
			{
				SweepLineInterval interval = sweepLineEvent.Interval;
				isweepLineOverlapAction_0.Overlap(sweepLineInterval_0, interval);
				int_0++;
			}
		}
	}

	static SweepLineIndex()
	{
		Class72.smethod_20();
	}
}
