using System.Collections;
using System.IO;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class EdgeEndStar
{
	private readonly IDictionary idictionary_0 = new SortedList();

	private readonly LocationType[] locationType_0 = new LocationType[2]
	{
		LocationType.Null,
		LocationType.Null
	};

	private IList ilist_0;

	protected IDictionary EdgeMap => idictionary_0;

	protected IList EdgeList => ilist_0;

	public virtual Coordinate Coordinate
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return Coordinate.Empty;
			}
			return ((EdgeEnd)enumerator.Current).Coordinate;
		}
	}

	public virtual int Degree => idictionary_0.Count;

	public virtual IList Edges
	{
		get
		{
			InitializeEdges();
			return ilist_0;
		}
	}

	public virtual bool IsAreaLabelsConsistent
	{
		get
		{
			method_0();
			return method_1(0);
		}
	}

	public abstract void Insert(EdgeEnd e);

	protected void InsertEdgeEnd(EdgeEnd e, object obj)
	{
		if (!idictionary_0.Contains(e))
		{
			idictionary_0.Add(e, obj);
			ilist_0 = null;
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		return Edges.GetEnumerator();
	}

	protected void InitializeEdges()
	{
		if (ilist_0 == null)
		{
			ilist_0 = new ArrayList(idictionary_0.Values);
		}
	}

	public virtual EdgeEnd GetNextCw(EdgeEnd ee)
	{
		InitializeEdges();
		int num = ilist_0.IndexOf(ee);
		int index = num - 1;
		if (num == 0)
		{
			index = ilist_0.Count - 1;
		}
		return (EdgeEnd)ilist_0[index];
	}

	public virtual void ComputeLabelling(GeometryGraph[] geom)
	{
		method_0();
		PropagateSideLabels(0);
		PropagateSideLabels(1);
		bool[] array = new bool[2];
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((EdgeEnd)enumerator.Current).Label;
			for (int i = 0; i < 2; i++)
			{
				if (label.IsLine(i) && label.GetLocation(i) == LocationType.Boundary)
				{
					array[i] = true;
				}
			}
		}
		IEnumerator enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator2.Current;
			Label label2 = edgeEnd.Label;
			for (int j = 0; j < 2; j++)
			{
				if (label2.IsAnyNull(j))
				{
					LocationType location;
					if (array[j])
					{
						location = LocationType.Exterior;
					}
					else
					{
						Coordinate coordinate = edgeEnd.Coordinate;
						location = GetLocation(j, coordinate, geom);
					}
					label2.SetAllLocationsIfNull(j, location);
				}
			}
		}
	}

	private void method_0()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).ComputeLabel();
		}
	}

	public virtual LocationType GetLocation(int geomIndex, Coordinate p, GeometryGraph[] geom)
	{
		if (locationType_0[geomIndex] == LocationType.Null)
		{
			locationType_0[geomIndex] = SimplePointInAreaLocator.Locate(p, geom[geomIndex].Geometry);
		}
		return locationType_0[geomIndex];
	}

	private bool method_1(int int_0)
	{
		IList edges = Edges;
		if (edges.Count > 0)
		{
			LocationType location = ((EdgeEnd)edges[^1]).Label.GetLocation(int_0, PositionType.Left);
			Assert.IsTrue(location != LocationType.Null, "Found unlabelled area edge");
			LocationType locationType = location;
			IEnumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				Label label = ((EdgeEnd)enumerator.Current).Label;
				Assert.IsTrue(label.IsArea(int_0), "Found non-area edge");
				LocationType location2 = label.GetLocation(int_0, PositionType.Left);
				LocationType location3 = label.GetLocation(int_0, PositionType.Right);
				if (location2 != location3)
				{
					if (location3 == locationType)
					{
						locationType = location2;
						continue;
					}
					return false;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	public virtual void PropagateSideLabels(int geomIndex)
	{
		LocationType locationType = LocationType.Null;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((EdgeEnd)enumerator.Current).Label;
			if (label.IsArea(geomIndex) && label.GetLocation(geomIndex, PositionType.Left) != LocationType.Null)
			{
				locationType = label.GetLocation(geomIndex, PositionType.Left);
			}
		}
		if (locationType == LocationType.Null)
		{
			return;
		}
		LocationType locationType2 = locationType;
		IEnumerator enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator2.Current;
			Label label2 = edgeEnd.Label;
			if (label2.GetLocation(geomIndex, PositionType.On) == LocationType.Null)
			{
				label2.SetLocation(geomIndex, PositionType.On, locationType2);
			}
			if (!label2.IsArea(geomIndex))
			{
				continue;
			}
			LocationType location = label2.GetLocation(geomIndex, PositionType.Left);
			LocationType location2 = label2.GetLocation(geomIndex, PositionType.Right);
			if (location2 != LocationType.Null)
			{
				if (location2 != locationType2)
				{
					throw new TopologyException(TopologyText.SideLocationConflict, edgeEnd.Coordinate);
				}
				if (location == LocationType.Null)
				{
					throw new TopologyException(TopologyText.SingleNullSide, edgeEnd.Coordinate);
				}
				locationType2 = location;
			}
			else
			{
				Assert.IsTrue(label2.GetLocation(geomIndex, PositionType.Left) == LocationType.Null, "found single null side");
				label2.SetLocation(geomIndex, PositionType.Right, locationType2);
				label2.SetLocation(geomIndex, PositionType.Left, locationType2);
			}
		}
	}

	public virtual int FindIndex(EdgeEnd eSearch)
	{
		GetEnumerator();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if ((EdgeEnd)ilist_0[i] == eSearch)
			{
				return i;
			}
		}
		return -1;
	}

	public virtual void Write(StreamWriter outstream)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).Write(outstream);
		}
	}

	static EdgeEndStar()
	{
		Class72.smethod_20();
	}
}
