using System.Collections.Generic;

namespace Command;

public class DetailTimestampComparer_DescendingOrder : IComparer<MLDetailViewModel>
{
	public int Compare(MLDetailViewModel x, MLDetailViewModel y)
	{
		return y.Timestamp.CompareTo(x.Timestamp);
	}

	static DetailTimestampComparer_DescendingOrder()
	{
		Class72.smethod_20();
	}
}
