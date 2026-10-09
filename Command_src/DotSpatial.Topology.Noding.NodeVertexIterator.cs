using System;
using System.Collections;

namespace DotSpatial.Topology.Noding;

internal class NodeVertexIterator : IEnumerator
{
	private readonly SegmentString segmentString_0;

	private readonly IEnumerator ienumerator_0;

	private readonly SegmentNodeList segmentNodeList_0;

	private SegmentNode segmentNode_0;

	private int int_0;

	private SegmentNode segmentNode_1;

	public int CurrSegIndex => int_0;

	public SegmentString Edge => segmentString_0;

	public SegmentNodeList NodeList => segmentNodeList_0;

	public object Current => segmentNode_0;

	private NodeVertexIterator(SegmentNodeList nodeList)
	{
		segmentNodeList_0 = nodeList;
		segmentString_0 = nodeList.Edge;
		ienumerator_0 = nodeList.GetEnumerator();
	}

	public bool MoveNext()
	{
		if (segmentNode_0 == null)
		{
			segmentNode_0 = segmentNode_1;
			int_0 = segmentNode_0.SegmentIndex;
			method_0();
			return true;
		}
		if (segmentNode_1 != null)
		{
			if (segmentNode_1.SegmentIndex == segmentNode_0.SegmentIndex)
			{
				segmentNode_0 = segmentNode_1;
				int_0 = segmentNode_0.SegmentIndex;
				method_0();
				return true;
			}
			return false;
		}
		return false;
	}

	public void Reset()
	{
		ienumerator_0.Reset();
	}

	private void method_0()
	{
		if (ienumerator_0.MoveNext())
		{
			segmentNode_1 = (SegmentNode)ienumerator_0.Current;
		}
		else
		{
			segmentNode_1 = null;
		}
	}

	[Obsolete("Not implemented!")]
	public void Remove()
	{
		throw new NotSupportedException(GetType().Name);
	}

	static NodeVertexIterator()
	{
		Class72.smethod_20();
	}
}
