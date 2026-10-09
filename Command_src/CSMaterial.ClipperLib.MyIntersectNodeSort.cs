using System.Collections.Generic;

namespace CSMaterial.ClipperLib;

public sealed class MyIntersectNodeSort : IComparer<IntersectNode>
{
	public int Compare(IntersectNode node1, IntersectNode node2)
	{
		return (int)(node2.Pt.Y - node1.Pt.Y);
	}

	static MyIntersectNodeSort()
	{
		Class72.smethod_20();
	}
}
