namespace DotSpatial.Topology.KDTree;

public class NearestNeighborList
{
	public const int REMOVE_HIGHEST = 1;

	public const int REMOVE_LOWEST = 2;

	private readonly int int_0;

	private readonly PriorityQueue priorityQueue_0;

	public double MaxPriority
	{
		get
		{
			if (priorityQueue_0.Length() != 0)
			{
				return priorityQueue_0.GetMaxPriority();
			}
			return double.PositiveInfinity;
		}
	}

	public bool IsCapacityReached => priorityQueue_0.Length() >= int_0;

	public object Highest => priorityQueue_0.Front();

	public bool IsEmpty => priorityQueue_0.Length() == 0;

	public int Size => priorityQueue_0.Length();

	public NearestNeighborList(int capacity)
	{
		int_0 = capacity;
		priorityQueue_0 = new PriorityQueue(int_0, double.PositiveInfinity);
	}

	public bool Insert(object item, double priority)
	{
		if (priorityQueue_0.Length() >= int_0)
		{
			if (priority > priorityQueue_0.GetMaxPriority())
			{
				return false;
			}
			priorityQueue_0.Remove();
			priorityQueue_0.Add(item, priority);
			return true;
		}
		priorityQueue_0.Add(item, priority);
		return true;
	}

	public object RemoveHighest()
	{
		return priorityQueue_0.Remove();
	}

	static NearestNeighborList()
	{
		Class72.smethod_20();
	}
}
