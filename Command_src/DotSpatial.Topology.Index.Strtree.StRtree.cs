using System;
using System.Collections;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Strtree;

public class StRtree : AbstractStRtree, ISpatialIndex
{
	private class Class57 : AbstractNode
	{
		public Class57(int int_1)
			: base(int_1)
		{
		}

		protected override object ComputeBounds()
		{
			Envelope envelope = null;
			IEnumerator enumerator = ChildBoundables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IBoundable boundable = (IBoundable)enumerator.Current;
				if (envelope == null)
				{
					envelope = new Envelope((Envelope)boundable.Bounds);
				}
				else
				{
					envelope.ExpandToInclude((Envelope)boundable.Bounds);
				}
			}
			return envelope;
		}

		static Class57()
		{
			Class72.smethod_20();
		}
	}

	private class Class60 : IIntersectsOp
	{
		public bool Intersects(object aBounds, object bBounds)
		{
			return ((Envelope)aBounds).Intersects((Envelope)bBounds);
		}

		static Class60()
		{
			Class72.smethod_20();
		}
	}

	private class Class61 : IComparer
	{
		private readonly object object_0;

		public Class61(StRtree stRtree_0)
		{
			object_0 = stRtree_0;
		}

		public int Compare(object x, object y)
		{
			return ((AbstractStRtree)object_0).CompareDoubles(smethod_3((Envelope)((IBoundable)x).Bounds), smethod_3((Envelope)((IBoundable)y).Bounds));
		}

		static Class61()
		{
			Class72.smethod_20();
		}
	}

	private class Class62 : IComparer
	{
		private readonly object object_0;

		public Class62(StRtree stRtree_0)
		{
			object_0 = stRtree_0;
		}

		public int Compare(object x, object y)
		{
			return ((AbstractStRtree)object_0).CompareDoubles(smethod_4((Envelope)((IBoundable)x).Bounds), smethod_4((Envelope)((IBoundable)y).Bounds));
		}

		static Class62()
		{
			Class72.smethod_20();
		}
	}

	protected override IIntersectsOp IntersectsOp => new Class60();

	public StRtree()
		: this(10)
	{
	}

	public StRtree(int nodeCapacity)
		: base(nodeCapacity)
	{
	}

	public virtual void Insert(IEnvelope itemEnv, object item)
	{
		if (!itemEnv.IsNull)
		{
			base.Insert(itemEnv, item);
		}
	}

	public virtual IList Query(IEnvelope searchEnv)
	{
		return base.Query(searchEnv);
	}

	public virtual void Query(IEnvelope searchEnv, IItemVisitor visitor)
	{
		base.Query(searchEnv, visitor);
	}

	public virtual bool Remove(IEnvelope itemEnv, object item)
	{
		return base.Remove(itemEnv, item);
	}

	private static double smethod_2(double double_0, double double_1)
	{
		return (double_0 + double_1) / 2.0;
	}

	private static double smethod_3(IEnvelope ienvelope_0)
	{
		return smethod_2(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X);
	}

	private static double smethod_4(IEnvelope ienvelope_0)
	{
		return smethod_2(ienvelope_0.Minimum.Y, ienvelope_0.Maximum.Y);
	}

	protected override IList CreateParentBoundables(IList childBoundables, int newLevel)
	{
		Assert.IsTrue(childBoundables.Count != 0);
		int num = (int)Math.Ceiling((double)childBoundables.Count / (double)NodeCapacity);
		ArrayList arrayList = new ArrayList(childBoundables);
		arrayList.Sort(new Class61(this));
		IList[] ilist_ = VerticalSlices(arrayList, (int)Math.Ceiling(Math.Sqrt(num)));
		return method_3(ilist_, newLevel);
	}

	private IList method_3(IList[] ilist_0, int int_1)
	{
		Assert.IsTrue(ilist_0.Length != 0);
		IList list = new ArrayList();
		for (int i = 0; i < ilist_0.Length; i++)
		{
			foreach (object item in CreateParentBoundablesFromVerticalSlice(ilist_0[i], int_1))
			{
				list.Add(item);
			}
		}
		return list;
	}

	protected virtual IList CreateParentBoundablesFromVerticalSlice(IList childBoundables, int newLevel)
	{
		return base.CreateParentBoundables(childBoundables, newLevel);
	}

	protected virtual IList[] VerticalSlices(IList childBoundables, int sliceCount)
	{
		int num = (int)Math.Ceiling((double)childBoundables.Count / (double)sliceCount);
		IList[] array = new IList[sliceCount];
		IEnumerator enumerator = childBoundables.GetEnumerator();
		for (int i = 0; i < sliceCount; i++)
		{
			array[i] = new ArrayList();
			for (int j = 0; j < num; j++)
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
				IBoundable value = (IBoundable)enumerator.Current;
				array[i].Add(value);
			}
		}
		return array;
	}

	protected override AbstractNode CreateNode(int level)
	{
		return new Class57(level);
	}

	protected override IComparer GetComparer()
	{
		return new Class62(this);
	}

	static StRtree()
	{
		Class72.smethod_20();
	}
}
