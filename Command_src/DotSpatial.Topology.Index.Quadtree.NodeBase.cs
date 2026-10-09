using System.Collections;

namespace DotSpatial.Topology.Index.Quadtree;

public abstract class NodeBase
{
	private IList ilist_0 = new ArrayList();

	private Node[] node_0 = new Node[4];

	public virtual int Count
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
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
			for (int i = 0; i < 4; i++)
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

	public Node[] Nodes
	{
		get
		{
			return node_0;
		}
		set
		{
			node_0 = value;
		}
	}

	public virtual bool HasChildren
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < 4)
				{
					if (node_0[num] != null)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public virtual bool HasItems
	{
		get
		{
			if (ilist_0.Count == 0)
			{
				return false;
			}
			return true;
		}
	}

	public virtual bool IsPrunable
	{
		get
		{
			if (!HasChildren)
			{
				return !HasItems;
			}
			return false;
		}
	}

	public virtual bool IsEmpty
	{
		get
		{
			bool result = true;
			int num;
			if (ilist_0.Count == 0)
			{
				num = 0;
			}
			else
			{
				result = false;
				num = 0;
			}
			for (int i = num; i < 4; i++)
			{
				if (node_0[i] != null && !node_0[i].IsEmpty)
				{
					result = false;
				}
			}
			return result;
		}
	}

	public virtual IList Items
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

	public virtual int NodeCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (node_0[i] != null)
				{
					num += node_0[i].NodeCount;
				}
			}
			return num + 1;
		}
	}

	public virtual void Add(object item)
	{
		ilist_0.Add(item);
	}

	public virtual IList AddAllItems(ref IList resultItems)
	{
		foreach (object item in ilist_0)
		{
			resultItems.Add(item);
		}
		for (int i = 0; i < 4; i++)
		{
			if (node_0[i] != null)
			{
				node_0[i].AddAllItems(ref resultItems);
			}
		}
		return resultItems;
	}

	public virtual void AddAllItemsFromOverlapping(IEnvelope searchEnv, ref IList resultItems)
	{
		if (!IsSearchMatch(searchEnv))
		{
			return;
		}
		foreach (object item in ilist_0)
		{
			resultItems.Add(item);
		}
		for (int i = 0; i < 4; i++)
		{
			if (node_0[i] != null)
			{
				node_0[i].AddAllItemsFromOverlapping(searchEnv, ref resultItems);
			}
		}
	}

	public virtual bool Remove(IEnvelope itemEnv, object item)
	{
		if (IsSearchMatch(itemEnv))
		{
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				if (node_0[i] != null && (flag = node_0[i].Remove(itemEnv, item)))
				{
					if (node_0[i].IsPrunable)
					{
						node_0[i] = null;
					}
					break;
				}
			}
			if (!flag)
			{
				if (ilist_0.Contains(item))
				{
					ilist_0.Remove(item);
					flag = true;
				}
				return flag;
			}
			return true;
		}
		return false;
	}

	public virtual void Visit(IEnvelope searchEnv, IItemVisitor visitor)
	{
		if (!IsSearchMatch(searchEnv))
		{
			return;
		}
		method_0(visitor);
		for (int i = 0; i < 4; i++)
		{
			if (node_0[i] != null)
			{
				node_0[i].Visit(searchEnv, visitor);
			}
		}
	}

	protected abstract bool IsSearchMatch(IEnvelope searchEnv);

	private void method_0(IItemVisitor iitemVisitor_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			iitemVisitor_0.VisitItem(enumerator.Current);
		}
	}

	public static int GetSubnodeIndex(IEnvelope env, Coordinate centre)
	{
		int result = -1;
		if (env.Minimum.X >= centre.X)
		{
			if (env.Minimum.Y >= centre.Y)
			{
				result = 3;
			}
			if (env.Maximum.Y <= centre.Y)
			{
				result = 1;
			}
		}
		if (env.Maximum.X <= centre.X)
		{
			if (env.Minimum.Y >= centre.Y)
			{
				result = 2;
			}
			if (env.Maximum.Y <= centre.Y)
			{
				result = 0;
			}
		}
		return result;
	}

	static NodeBase()
	{
		Class72.smethod_20();
	}
}
