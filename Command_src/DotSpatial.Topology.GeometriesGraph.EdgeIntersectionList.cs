using System.Collections;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeIntersectionList
{
	private readonly Edge edge_0;

	private readonly IDictionary idictionary_0 = new SortedList();

	public int Count => idictionary_0.Count;

	public EdgeIntersectionList(Edge edge)
	{
		edge_0 = edge;
	}

	public virtual void Add(Coordinate intPt, int segmentIndex, double dist)
	{
		EdgeIntersection edgeIntersection = new EdgeIntersection(intPt, segmentIndex, dist);
		if ((EdgeIntersection)idictionary_0[edgeIntersection] == null)
		{
			idictionary_0.Add(edgeIntersection, edgeIntersection);
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		return idictionary_0.Values.GetEnumerator();
	}

	public virtual bool IsIntersection(Coordinate pt)
	{
		IEnumerator enumerator = GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!((EdgeIntersection)enumerator.Current).Coordinate.Equals(pt));
		return true;
	}

	public virtual void AddEndpoints()
	{
		int num = edge_0.Points.Count - 1;
		Add(edge_0.Points[0], 0, 0.0);
		Add(edge_0.Points[num], num, 0.0);
	}

	public virtual void AddSplitEdges(IList edgeList)
	{
		AddEndpoints();
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		EdgeIntersection ei = (EdgeIntersection)enumerator.Current;
		while (enumerator.MoveNext())
		{
			EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
			Edge value = CreateSplitEdge(ei, edgeIntersection);
			edgeList.Add(value);
			ei = edgeIntersection;
		}
	}

	public virtual Edge CreateSplitEdge(EdgeIntersection ei0, EdgeIntersection ei1)
	{
		int num = ei1.SegmentIndex - ei0.SegmentIndex + 2;
		Coordinate b = edge_0.Points[ei1.SegmentIndex];
		bool flag;
		if (!(flag = ei1.Distance > 0.0 || !ei1.Coordinate.Equals2D(b)))
		{
			num--;
		}
		Coordinate[] array = new Coordinate[num];
		int num2 = 0;
		num2 = 1;
		array[0] = new Coordinate(ei0.Coordinate);
		for (int i = ei0.SegmentIndex + 1; i <= ei1.SegmentIndex; i++)
		{
			array[num2++] = edge_0.Points[i];
		}
		if (flag)
		{
			array[num2] = ei1.Coordinate;
		}
		return new Edge(array, new Label(edge_0.Label));
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.WriteLine("Intersections:");
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeIntersection)enumerator.Current).Write(outstream);
		}
	}

	static EdgeIntersectionList()
	{
		Class72.smethod_20();
	}
}
