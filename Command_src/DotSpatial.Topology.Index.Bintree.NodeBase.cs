using System.Collections;

namespace DotSpatial.Topology.Index.Bintree;

public abstract class NodeBase
{
	private readonly IList ilist_0 = new ArrayList();

	private Node[] node_0 = new Node[2];

	public virtual int Count
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (node_0[i] != null)
				{
					num += node_0[i].Count;
				}
			}
			return num + ilist_0.Count;
		}
	}

	public virtual int Depth
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (node_0[i] != null)
				{
					int depth = node_0[i].Depth;
					if (depth > num)
					{
						num = depth;
					}
				}
			}
			return num + 1;
		}
	}

	public virtual IList Items => ilist_0;

	public virtual int NodeCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (node_0[i] != null)
				{
					num += node_0[i].NodeCount;
				}
			}
			return num + 1;
		}
	}

	public virtual Node[] Nodes
	{
		get
		{
			return node_0;
		}
		protected set
		{
			node_0 = value;
		}
	}

	public virtual void Add(object item)
	{
		ilist_0.Add(item);
	}

	public virtual IList AddAllItems(IList items)
	{
		foreach (object item in ilist_0)
		{
			items.Add(item);
		}
		for (int i = 0; i < 2; i++)
		{
			if (node_0[i] != null)
			{
				node_0[i].AddAllItems(items);
			}
		}
		return items;
	}

	public virtual IList AddAllItemsFromOverlapping(Interval interval, IList resultItems)
	{
		if (IsSearchMatch(interval))
		{
			foreach (object item in ilist_0)
			{
				resultItems.Add(item);
			}
			for (int i = 0; i < 2; i++)
			{
				if (node_0[i] != null)
				{
					node_0[i].AddAllItemsFromOverlapping(interval, resultItems);
				}
			}
			return ilist_0;
		}
		return ilist_0;
	}

	protected abstract bool IsSearchMatch(Interval interval);

	public static int GetSubnodeIndex(Interval interval, double centre)
	{
		int result = -1;
		if (interval.Min >= centre)
		{
			result = 1;
		}
		if (interval.Max <= centre)
		{
			result = 0;
		}
		return result;
	}

	static NodeBase()
	{
		Class72.smethod_20();
	}
}
