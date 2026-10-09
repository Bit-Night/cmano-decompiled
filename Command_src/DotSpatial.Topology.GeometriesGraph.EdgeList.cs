using System.Collections;
using System.Collections.Generic;
using System.IO;
using DotSpatial.Topology.Index;
using DotSpatial.Topology.Index.Quadtree;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeList
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly ISpatialIndex ispatialIndex_0 = new Quadtree();

	public virtual IList Edges => ilist_0;

	public virtual Edge this[int index] => Get(index);

	public virtual void Remove(Edge e)
	{
		ilist_0.Remove(e);
	}

	public virtual void Add(Edge e)
	{
		ilist_0.Add(e);
		ispatialIndex_0.Insert(e.Envelope, e);
	}

	public virtual void AddAll(ICollection edgeColl)
	{
		IEnumerator enumerator = edgeColl.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Add((Edge)enumerator.Current);
		}
	}

	public virtual Edge FindEqualEdge(Edge e)
	{
		IEnumerator enumerator = ispatialIndex_0.Query(e.Envelope).GetEnumerator();
		Edge edge;
		do
		{
			if (enumerator.MoveNext())
			{
				edge = (Edge)enumerator.Current;
				continue;
			}
			return null;
		}
		while (!edge.Equals(e));
		return edge;
	}

	public virtual IEnumerator GetEnumerator()
	{
		return ilist_0.GetEnumerator();
	}

	public virtual Edge Get(int i)
	{
		return (Edge)ilist_0[i];
	}

	public virtual int FindEdgeIndex(Edge e)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (ilist_0[i].Equals(e))
			{
				return i;
			}
		}
		return -1;
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.Write("MULTILINESTRING ( ");
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Edge obj = (Edge)ilist_0[i];
			if (i > 0)
			{
				outstream.Write(",");
			}
			outstream.Write("(");
			IList<Coordinate> coordinates = obj.Coordinates;
			for (int j = 0; j < coordinates.Count; j++)
			{
				if (j > 0)
				{
					outstream.Write(",");
				}
				outstream.Write(coordinates[j].X + " " + coordinates[j].Y);
			}
			outstream.WriteLine(")");
		}
		outstream.Write(")  ");
	}

	static EdgeList()
	{
		Class72.smethod_20();
	}
}
