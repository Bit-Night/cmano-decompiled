using System;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SweepLineEvent : IComparable
{
	public const int INSERT = 1;

	public const int DELETE = 2;

	private readonly int int_0;

	private readonly SweepLineEvent sweepLineEvent_0;

	private readonly object object_0;

	private readonly double double_0;

	private int int_1;

	private object object_1;

	public virtual object EdgeSet
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public virtual bool IsInsert => sweepLineEvent_0 == null;

	public virtual bool IsDelete => sweepLineEvent_0 != null;

	public SweepLineEvent InsertEvent => sweepLineEvent_0;

	public virtual int DeleteEventIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public virtual object Object => object_0;

	public SweepLineEvent(object edgeSet, double x, SweepLineEvent insertEvent, object obj)
	{
		object_1 = edgeSet;
		double_0 = x;
		sweepLineEvent_0 = insertEvent;
		int_0 = 1;
		if (insertEvent != null)
		{
			int_0 = 2;
		}
		object_0 = obj;
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
		if (int_0 < sweepLineEvent.int_0)
		{
			return -1;
		}
		if (int_0 > sweepLineEvent.int_0)
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
