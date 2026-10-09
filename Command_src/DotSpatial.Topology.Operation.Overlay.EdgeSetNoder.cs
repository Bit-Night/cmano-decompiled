using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.Operation.Overlay;

public class EdgeSetNoder
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly LineIntersector NlwemAkvThR;

	public virtual IList NodedEdges
	{
		get
		{
			new SimpleMcSweepLineIntersector().ComputeIntersections(si: new SegmentIntersector(NlwemAkvThR, includeProper: true, recordIsolated: false), edges: ilist_0, testAllSegments: true);
			IList list = new ArrayList();
			IEnumerator enumerator = ilist_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((Edge)enumerator.Current).EdgeIntersectionList.AddSplitEdges(list);
			}
			return list;
		}
	}

	public EdgeSetNoder(LineIntersector li)
	{
		NlwemAkvThR = li;
	}

	public virtual void AddEdges(IList edges)
	{
		foreach (object edge in edges)
		{
			ilist_0.Add(edge);
		}
	}

	static EdgeSetNoder()
	{
		Class72.smethod_20();
	}
}
