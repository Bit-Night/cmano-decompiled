using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Chain;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Noding.Snapround;

public class McIndexPointSnapper
{
	public class HotPixelSnapAction : MonotoneChainSelectAction
	{
		private readonly HotPixel hotPixel_0;

		private readonly SegmentString segmentString_0;

		private readonly int int_0;

		private bool bool_0;

		public bool IsNodeAdded => bool_0;

		public HotPixelSnapAction(HotPixel hotPixel, SegmentString parentEdge, int vertexIndex)
		{
			hotPixel_0 = hotPixel;
			segmentString_0 = parentEdge;
			int_0 = vertexIndex;
		}

		public override void Select(MonotoneChain mc, int startIndex)
		{
			SegmentString segmentString = (SegmentString)mc.Context;
			if (segmentString_0 == null || segmentString != segmentString_0 || startIndex != int_0)
			{
				bool_0 = SimpleSnapRounder.AddSnappedNode(hotPixel_0, segmentString, startIndex);
			}
		}

		static HotPixelSnapAction()
		{
			Class72.smethod_20();
		}
	}

	private class Class55 : IItemVisitor
	{
		private readonly object object_0;

		private readonly object object_1;

		public Class55(Envelope envelope_0, HotPixelSnapAction hotPixelSnapAction_0)
		{
			object_1 = envelope_0;
			object_0 = hotPixelSnapAction_0;
		}

		public void VisitItem(object item)
		{
			((MonotoneChain)item).Select((IEnvelope)object_1, (MonotoneChainSelectAction)object_0);
		}

		static Class55()
		{
			Class72.smethod_20();
		}
	}

	private readonly StRtree stRtree_0;

	public McIndexPointSnapper(ISpatialIndex index)
	{
		stRtree_0 = (StRtree)index;
	}

	public bool Snap(HotPixel hotPixel, SegmentString parentEdge, int vertexIndex)
	{
		Envelope safeEnvelope = hotPixel.GetSafeEnvelope();
		HotPixelSnapAction hotPixelSnapAction = new HotPixelSnapAction(hotPixel, parentEdge, vertexIndex);
		stRtree_0.Query(safeEnvelope, new Class55(safeEnvelope, hotPixelSnapAction));
		return hotPixelSnapAction.IsNodeAdded;
	}

	public bool Snap(HotPixel hotPixel)
	{
		return Snap(hotPixel, null, -1);
	}

	static McIndexPointSnapper()
	{
		Class72.smethod_20();
	}
}
