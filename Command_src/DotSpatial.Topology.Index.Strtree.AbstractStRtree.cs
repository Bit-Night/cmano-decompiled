using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public abstract class AbstractStRtree
{
	protected interface IIntersectsOp
	{
		bool Intersects(object aBounds, object bBounds);
	}

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly int int_0;

	private bool bool_0;

	private AbstractNode abstractNode_0;

	public virtual AbstractNode Root
	{
		get
		{
			return abstractNode_0;
		}
		protected set
		{
			abstractNode_0 = value;
		}
	}

	public virtual int NodeCapacity => int_0;

	public virtual int Count
	{
		get
		{
			if (!bool_0)
			{
				Build();
			}
			if (arrayList_0.Count == 0)
			{
				return 0;
			}
			return GetSize(abstractNode_0);
		}
	}

	public virtual int Depth
	{
		get
		{
			if (!bool_0)
			{
				Build();
			}
			if (arrayList_0.Count == 0)
			{
				return 0;
			}
			return GetDepth(abstractNode_0);
		}
	}

	protected abstract IIntersectsOp IntersectsOp { get; }

	protected AbstractStRtree(int nodeCapacity)
	{
		Assert.IsTrue(nodeCapacity > 1, "Node capacity must be greater than 1");
		int_0 = nodeCapacity;
	}

	public virtual void Build()
	{
		Assert.IsTrue(!bool_0);
		abstractNode_0 = ((arrayList_0.Count == 0) ? CreateNode(0) : method_0(arrayList_0, -1));
		bool_0 = true;
	}

	protected abstract AbstractNode CreateNode(int level);

	protected virtual IList CreateParentBoundables(IList childBoundables, int newLevel)
	{
		Assert.IsTrue(childBoundables.Count != 0);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(CreateNode(newLevel));
		ArrayList arrayList2 = new ArrayList(childBoundables);
		arrayList2.Sort(GetComparer());
		IEnumerator enumerator = arrayList2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable childBoundable = (IBoundable)enumerator.Current;
			if (LastNode(arrayList).ChildBoundables.Count == NodeCapacity)
			{
				arrayList.Add(CreateNode(newLevel));
			}
			LastNode(arrayList).AddChildBoundable(childBoundable);
		}
		return arrayList;
	}

	protected virtual AbstractNode LastNode(IList nodes)
	{
		return (AbstractNode)nodes[nodes.Count - 1];
	}

	protected virtual int CompareDoubles(double a, double b)
	{
		if (!(a > b))
		{
			if (!(a >= b))
			{
				return -1;
			}
			return 0;
		}
		return 1;
	}

	private AbstractNode method_0(IList ilist_0, int int_1)
	{
		Assert.IsTrue(ilist_0.Count != 0);
		IList list = CreateParentBoundables(ilist_0, int_1 + 1);
		if (list.Count == 1)
		{
			return (AbstractNode)list[0];
		}
		return method_0(list, int_1 + 1);
	}

	protected virtual int GetSize(AbstractNode node)
	{
		int num = 0;
		IEnumerator enumerator = node.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (!(boundable is AbstractNode))
			{
				if (boundable is ItemBoundable)
				{
					num++;
				}
			}
			else
			{
				num += GetSize((AbstractNode)boundable);
			}
		}
		return num;
	}

	protected virtual int GetDepth(AbstractNode node)
	{
		int num = 0;
		IEnumerator enumerator = node.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (boundable is AbstractNode)
			{
				int depth = GetDepth((AbstractNode)boundable);
				if (depth > num)
				{
					num = depth;
				}
			}
		}
		return num + 1;
	}

	protected virtual void Insert(object bounds, object item)
	{
		Assert.IsTrue(!bool_0, "Cannot insert items into an STR packed R-tree after it has been built.");
		arrayList_0.Add(new ItemBoundable(bounds, item));
	}

	protected virtual IList Query(object searchBounds)
	{
		if (!bool_0)
		{
			Build();
		}
		ArrayList arrayList = new ArrayList();
		if (arrayList_0.Count != 0)
		{
			if (IntersectsOp.Intersects(abstractNode_0.Bounds, searchBounds))
			{
				method_1(searchBounds, abstractNode_0, arrayList);
			}
			return arrayList;
		}
		Assert.IsTrue(abstractNode_0.Bounds == null);
		return arrayList;
	}

	protected virtual void Query(object searchBounds, IItemVisitor visitor)
	{
		if (!bool_0)
		{
			Build();
		}
		if (arrayList_0.Count == 0)
		{
			Assert.IsTrue(abstractNode_0.Bounds == null);
		}
		if (IntersectsOp.Intersects(abstractNode_0.Bounds, searchBounds))
		{
			method_2(searchBounds, abstractNode_0, visitor);
		}
	}

	private void method_1(object object_0, AbstractNode abstractNode_1, IList ilist_0)
	{
		foreach (IBoundable childBoundable in abstractNode_1.ChildBoundables)
		{
			if (!IntersectsOp.Intersects(childBoundable.Bounds, object_0))
			{
				continue;
			}
			if (childBoundable is AbstractNode)
			{
				method_1(object_0, (AbstractNode)childBoundable, ilist_0);
				continue;
			}
			if (childBoundable is ItemBoundable)
			{
				ilist_0.Add(((ItemBoundable)childBoundable).Item);
				continue;
			}
			throw new ShouldNeverReachHereException();
		}
	}

	private void method_2(object object_0, AbstractNode abstractNode_1, IItemVisitor iitemVisitor_0)
	{
		foreach (IBoundable childBoundable in abstractNode_1.ChildBoundables)
		{
			if (!IntersectsOp.Intersects(childBoundable.Bounds, object_0))
			{
				continue;
			}
			if (childBoundable is AbstractNode)
			{
				method_2(object_0, (AbstractNode)childBoundable, iitemVisitor_0);
				continue;
			}
			if (childBoundable is ItemBoundable)
			{
				iitemVisitor_0.VisitItem(((ItemBoundable)childBoundable).Item);
				continue;
			}
			throw new ShouldNeverReachHereException();
		}
	}

	protected virtual bool Remove(object searchBounds, object item)
	{
		if (!bool_0)
		{
			Build();
		}
		if (arrayList_0.Count == 0)
		{
			Assert.IsTrue(abstractNode_0.Bounds == null);
		}
		if (!IntersectsOp.Intersects(abstractNode_0.Bounds, searchBounds))
		{
			return false;
		}
		return Remove(searchBounds, abstractNode_0, item);
	}

	private static bool smethod_0(AbstractNode abstractNode_1, object object_0)
	{
		IBoundable boundable = null;
		IEnumerator enumerator = abstractNode_1.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable2 = (IBoundable)enumerator.Current;
			if (boundable2 is ItemBoundable && ((ItemBoundable)boundable2).Item == object_0)
			{
				boundable = boundable2;
			}
		}
		if (boundable != null)
		{
			abstractNode_1.ChildBoundables.Remove(boundable);
			return true;
		}
		return false;
	}

	private bool Remove(object searchBounds, AbstractNode node, object item)
	{
		bool result;
		if (!(result = smethod_0(node, item)))
		{
			AbstractNode abstractNode = null;
			IEnumerator enumerator = node.ChildBoundables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IBoundable boundable = (IBoundable)enumerator.Current;
				if (IntersectsOp.Intersects(boundable.Bounds, searchBounds) && boundable is AbstractNode && (result = Remove(searchBounds, (AbstractNode)boundable, item)))
				{
					abstractNode = (AbstractNode)boundable;
					break;
				}
			}
			if (abstractNode != null && abstractNode.ChildBoundables.Count == 0)
			{
				node.ChildBoundables.Remove(abstractNode);
			}
			return result;
		}
		return true;
	}

	protected virtual IList BoundablesAtLevel(int level)
	{
		IList ilist_ = new ArrayList();
		smethod_1(level, abstractNode_0, ref ilist_);
		return ilist_;
	}

	private static void smethod_1(int int_1, AbstractNode abstractNode_1, ref IList ilist_0)
	{
		Assert.IsTrue(int_1 > -2);
		if (abstractNode_1.Level == int_1)
		{
			ilist_0.Add(abstractNode_1);
			return;
		}
		IEnumerator enumerator = abstractNode_1.ChildBoundables.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IBoundable boundable = (IBoundable)enumerator.Current;
			if (boundable is AbstractNode)
			{
				smethod_1(int_1, (AbstractNode)boundable, ref ilist_0);
				continue;
			}
			Assert.IsTrue(boundable is ItemBoundable);
			if (int_1 == -1)
			{
				ilist_0.Add(boundable);
			}
		}
	}

	protected abstract IComparer GetComparer();

	static AbstractStRtree()
	{
		Class72.smethod_20();
	}
}
