using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public abstract class AbstractNode : IBoundable
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly int int_0;

	private object object_0;

	public virtual IList ChildBoundables => arrayList_0;

	public virtual int Level => int_0;

	public virtual object Bounds
	{
		get
		{
			if (object_0 == null)
			{
				object_0 = ComputeBounds();
			}
			return object_0;
		}
	}

	protected AbstractNode(int level)
	{
		int_0 = level;
	}

	protected abstract object ComputeBounds();

	public virtual void AddChildBoundable(IBoundable childBoundable)
	{
		Assert.IsTrue(object_0 == null);
		arrayList_0.Add(childBoundable);
	}

	static AbstractNode()
	{
		Class72.smethod_20();
	}
}
