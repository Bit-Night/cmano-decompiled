using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public class DirectedEdgeStar
{
	private IList ilist_0 = new ArrayList();

	private bool bool_0;

	protected IList OutEdges
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public virtual int Degree => ilist_0.Count;

	public virtual Coordinate Coordinate
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			if (enumerator.MoveNext())
			{
				return ((DirectedEdge)enumerator.Current).Coordinate;
			}
			return null;
		}
	}

	public virtual IList Edges
	{
		get
		{
			method_0();
			return ilist_0;
		}
	}

	public virtual void Add(DirectedEdge de)
	{
		ilist_0.Add(de);
		bool_0 = false;
	}

	public virtual void Remove(DirectedEdge de)
	{
		ilist_0.Remove(de);
	}

	public virtual IEnumerator GetEnumerator()
	{
		method_0();
		return ilist_0.GetEnumerator();
	}

	private void method_0()
	{
		if (!bool_0)
		{
			((ArrayList)ilist_0).Sort();
			bool_0 = true;
		}
	}

	public virtual int GetIndex(Edge edge)
	{
		method_0();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (((DirectedEdge)ilist_0[i]).Edge == edge)
			{
				return i;
			}
		}
		return -1;
	}

	public virtual int GetIndex(DirectedEdge dirEdge)
	{
		method_0();
		int num = 0;
		while (true)
		{
			if (num < ilist_0.Count)
			{
				if ((DirectedEdge)ilist_0[num] == dirEdge)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public virtual int GetIndex(int i)
	{
		int num = i % ilist_0.Count;
		if (num < 0)
		{
			num += ilist_0.Count;
		}
		return num;
	}

	public virtual DirectedEdge GetNextEdge(DirectedEdge dirEdge)
	{
		int index = GetIndex(dirEdge);
		return (DirectedEdge)ilist_0[GetIndex(index + 1)];
	}

	static DirectedEdgeStar()
	{
		Class72.smethod_20();
	}
}
