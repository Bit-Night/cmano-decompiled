using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBuilder
{
	public virtual IList ComputeEdgeEnds(IEnumerator edges)
	{
		IList list = new ArrayList();
		while (edges.MoveNext())
		{
			Edge edge = (Edge)edges.Current;
			ComputeEdgeEnds(edge, list);
		}
		return list;
	}

	public virtual void ComputeEdgeEnds(Edge edge, IList l)
	{
		EdgeIntersectionList edgeIntersectionList = edge.EdgeIntersectionList;
		edgeIntersectionList.AddEndpoints();
		IEnumerator enumerator = edgeIntersectionList.GetEnumerator();
		EdgeIntersection edgeIntersection = null;
		if (!enumerator.MoveNext())
		{
			return;
		}
		EdgeIntersection edgeIntersection2 = (EdgeIntersection)enumerator.Current;
		do
		{
			EdgeIntersection eiPrev = edgeIntersection;
			edgeIntersection = edgeIntersection2;
			edgeIntersection2 = null;
			if (enumerator.MoveNext())
			{
				edgeIntersection2 = (EdgeIntersection)enumerator.Current;
			}
			if (edgeIntersection != null)
			{
				CreateEdgeEndForPrev(edge, l, edgeIntersection, eiPrev);
				CreateEdgeEndForNext(edge, l, edgeIntersection, edgeIntersection2);
			}
		}
		while (edgeIntersection != null);
	}

	public virtual void CreateEdgeEndForPrev(Edge edge, IList l, EdgeIntersection eiCurr, EdgeIntersection eiPrev)
	{
		int num = eiCurr.SegmentIndex;
		if (eiCurr.Distance == 0.0)
		{
			if (num == 0)
			{
				return;
			}
			num--;
		}
		Coordinate coordinate = edge.GetCoordinate(num);
		if (eiPrev != null && eiPrev.SegmentIndex >= num)
		{
			coordinate = eiPrev.Coordinate;
		}
		Label label = new Label(edge.Label);
		label.Flip();
		EdgeEnd value = new EdgeEnd(edge, eiCurr.Coordinate, coordinate, label);
		l.Add(value);
	}

	public virtual void CreateEdgeEndForNext(Edge edge, IList l, EdgeIntersection eiCurr, EdgeIntersection eiNext)
	{
		int num = eiCurr.SegmentIndex + 1;
		if (num < edge.NumPoints || eiNext != null)
		{
			Coordinate coordinate = edge.GetCoordinate(num);
			if (eiNext != null && eiNext.SegmentIndex == eiCurr.SegmentIndex)
			{
				coordinate = eiNext.Coordinate;
			}
			EdgeEnd value = new EdgeEnd(edge, eiCurr.Coordinate, coordinate, new Label(edge.Label));
			l.Add(value);
		}
	}

	static EdgeEndBuilder()
	{
		Class72.smethod_20();
	}
}
