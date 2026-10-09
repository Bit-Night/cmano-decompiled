using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Command_Core;

public class NavPathNodePool
{
	private readonly ConcurrentBag<CostBasedPathfinder.NavPathNode> concurrentBag_0;

	private readonly int int_0;

	private int int_1;

	public int CurrentPoolSize => int_1;

	public NavPathNodePool(int initialCapacity = 1000, int maxPoolSize = 100000)
	{
		concurrentBag_0 = new ConcurrentBag<CostBasedPathfinder.NavPathNode>();
		int_0 = maxPoolSize;
		int num = initialCapacity - 1;
		for (int i = 0; i <= num; i++)
		{
			concurrentBag_0.Add(new CostBasedPathfinder.NavPathNode());
		}
		int_1 = initialCapacity;
	}

	public CostBasedPathfinder.NavPathNode Rent()
	{
		CostBasedPathfinder.NavPathNode result = null;
		if (!concurrentBag_0.TryTake(out result))
		{
			return new CostBasedPathfinder.NavPathNode();
		}
		Interlocked.Decrement(ref int_1);
		return result;
	}

	public void ReturnNode(CostBasedPathfinder.NavPathNode node)
	{
		if (node != null)
		{
			node.Reset();
			if (int_1 < int_0)
			{
				concurrentBag_0.Add(node);
				Interlocked.Increment(ref int_1);
			}
		}
	}

	public void ReturnRange(IEnumerable<CostBasedPathfinder.NavPathNode> nodes)
	{
		foreach (CostBasedPathfinder.NavPathNode node in nodes)
		{
			ReturnNode(node);
		}
	}

	static NavPathNodePool()
	{
		Class72.smethod_20();
	}
}
