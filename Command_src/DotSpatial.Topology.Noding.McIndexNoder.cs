using System.Collections;
using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Chain;
using DotSpatial.Topology.Index.Strtree;

namespace DotSpatial.Topology.Noding;

public class McIndexNoder : SinglePassNoder
{
	public class SegmentOverlapAction : MonotoneChainOverlapAction
	{
		private readonly GInterface8 ginterface8_0;

		public SegmentOverlapAction(GInterface8 si)
		{
			ginterface8_0 = si;
		}

		public override void Overlap(MonotoneChain mc1, int start1, MonotoneChain mc2, int start2)
		{
			SegmentString e = (SegmentString)mc1.Context;
			SegmentString e2 = (SegmentString)mc2.Context;
			ginterface8_0.ProcessIntersections(e, start1, e2, start2);
		}

		static SegmentOverlapAction()
		{
			Class72.smethod_20();
		}
	}

	private readonly ISpatialIndex ispatialIndex_0 = new StRtree();

	private readonly IList ilist_0 = new ArrayList();

	private int int_0;

	private int int_1;

	private IList ilist_1;

	public IList MonotoneChains => ilist_0;

	public ISpatialIndex Index => ispatialIndex_0;

	public McIndexNoder()
	{
	}

	public McIndexNoder(GInterface8 segInt)
		: base(segInt)
	{
	}

	public override IList GetNodedSubstrings()
	{
		return SegmentString.GetNodedSubstrings(ilist_1);
	}

	public override void ComputeNodes(IList inputSegStrings)
	{
		ilist_1 = inputSegStrings;
		foreach (object inputSegString in inputSegStrings)
		{
			Add((SegmentString)inputSegString);
		}
		method_0();
	}

	private void method_0()
	{
		MonotoneChainOverlapAction mco = new SegmentOverlapAction(base.SegmentIntersector);
		foreach (MonotoneChain item in ilist_0)
		{
			foreach (MonotoneChain item2 in ispatialIndex_0.Query(item.Envelope))
			{
				if (item2.Id > item.Id)
				{
					item.ComputeOverlaps(item2, mco);
					int_1++;
				}
			}
		}
	}

	private void Add(SegmentString segStr)
	{
		foreach (MonotoneChain chain in MonotoneChainBuilder.GetChains(segStr.Coordinates, segStr))
		{
			chain.Id = int_0++;
			ispatialIndex_0.Insert(chain.Envelope, chain);
			ilist_0.Add(chain);
		}
	}

	static McIndexNoder()
	{
		Class72.smethod_20();
	}
}
