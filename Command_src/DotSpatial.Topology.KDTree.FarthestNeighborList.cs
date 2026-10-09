using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class FarthestNeighborList
{
	private readonly SortedList<double, object> sortedList_0;

	public double MinimumPriority
	{
		get
		{
			if (sortedList_0.Count == 0)
			{
				return 0.0;
			}
			return sortedList_0.Keys[0];
		}
	}

	public bool IsCapacityReached => sortedList_0.Count == sortedList_0.Capacity;

	public object Farthest
	{
		get
		{
			if (sortedList_0.Count != 0)
			{
				return sortedList_0.Values[sortedList_0.Count - 1];
			}
			return null;
		}
	}

	public bool IsEmpty => sortedList_0.Count == 0;

	public int Size => sortedList_0.Count;

	public FarthestNeighborList(int capacity)
	{
		sortedList_0 = new SortedList<double, object>(capacity);
	}

	public bool Insert(object obj, double priority)
	{
		if (sortedList_0.Count >= sortedList_0.Capacity)
		{
			if (priority < sortedList_0.Keys[0])
			{
				return false;
			}
			sortedList_0.RemoveAt(0);
			sortedList_0.Add(priority, obj);
			return true;
		}
		sortedList_0.Add(priority, obj);
		return true;
	}

	public object RemoveFarthest()
	{
		if (sortedList_0.Count > 0)
		{
			int index = sortedList_0.Count - 1;
			object result = sortedList_0.Values[index];
			sortedList_0.RemoveAt(index);
			return result;
		}
		return null;
	}

	static FarthestNeighborList()
	{
		Class72.smethod_20();
	}
}
