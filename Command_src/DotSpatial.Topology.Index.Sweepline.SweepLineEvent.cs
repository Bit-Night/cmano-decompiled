using System;

namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineEvent : IComparable
{
	public enum SweepLineEventType
	{
		Insert = 1,
		Delete
	}

	private readonly SweepLineEventType sweepLineEventType_0;

	private readonly SweepLineEvent sweepLineEvent_0;

	private readonly SweepLineInterval sweepLineInterval_0;

	private readonly double double_0;

	private int int_0;

	public virtual bool IsInsert => sweepLineEvent_0 == null;

	public virtual bool IsDelete => sweepLineEvent_0 != null;

	public virtual SweepLineEvent InsertEvent => sweepLineEvent_0;

	public virtual int DeleteEventIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public virtual SweepLineInterval Interval => sweepLineInterval_0;

	public SweepLineEvent(double x, SweepLineEvent insertEvent, SweepLineInterval sweepInt)
	{
		double_0 = x;
		sweepLineEvent_0 = insertEvent;
		sweepLineEventType_0 = ((insertEvent == null) ? SweepLineEventType.Insert : SweepLineEventType.Delete);
		sweepLineInterval_0 = sweepInt;
	}

	public virtual int CompareTo(object o)
	{
		SweepLineEvent sweepLineEvent = (SweepLineEvent)o;
		if (double_0 < sweepLineEvent.double_0)
		{
			return -1;
		}
		if (double_0 > sweepLineEvent.double_0)
		{
			return 1;
		}
		if (sweepLineEventType_0 < sweepLineEvent.sweepLineEventType_0)
		{
			return -1;
		}
		if (sweepLineEventType_0 > sweepLineEvent.sweepLineEventType_0)
		{
			return 1;
		}
		return 0;
	}

	static SweepLineEvent()
	{
		Class72.smethod_20();
	}
}
