using System.Collections.Generic;

namespace Command;

public class TimestampComparer_DescendingOrder : IComparer<GClass4>
{
	public int Compare(GClass4 x, GClass4 y)
	{
		return y.Timestamp.CompareTo(x.Timestamp);
	}

	static TimestampComparer_DescendingOrder()
	{
		Class72.smethod_20();
	}
}
