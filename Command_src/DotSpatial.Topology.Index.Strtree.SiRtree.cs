using System;
using System.Collections;

namespace DotSpatial.Topology.Index.Strtree;

public class SiRtree : AbstractStRtree
{
	private class Class58 : IComparer
	{
		public int Compare(object x, object y)
		{
			return new SiRtree().CompareDoubles(((Interval)((IBoundable)x).Bounds).Centre, ((Interval)((IBoundable)y).Bounds).Centre);
		}

		static Class58()
		{
			Class72.smethod_20();
		}
	}

	private class Class56 : AbstractNode
	{
		public Class56(int int_1)
			: base(int_1)
		{
		}

		protected override object ComputeBounds()
		{
			Interval interval = null;
			IEnumerator enumerator = ChildBoundables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IBoundable boundable = (IBoundable)enumerator.Current;
				if (interval != null)
				{
					interval.ExpandToInclude((Interval)boundable.Bounds);
				}
				else
				{
					interval = new Interval((Interval)boundable.Bounds);
				}
			}
			return interval;
		}

		static Class56()
		{
			Class72.smethod_20();
		}
	}

	private class Class59 : IIntersectsOp
	{
		public bool Intersects(object aBounds, object bBounds)
		{
			return ((Interval)aBounds).Intersects((Interval)bBounds);
		}

		static Class59()
		{
			Class72.smethod_20();
		}
	}

	private readonly IComparer icomparer_0 = new Class58();

	private readonly IIntersectsOp iintersectsOp_0 = new Class59();

	protected override IIntersectsOp IntersectsOp => iintersectsOp_0;

	public SiRtree()
		: this(10)
	{
	}

	public SiRtree(int nodeCapacity)
		: base(nodeCapacity)
	{
	}

	protected override AbstractNode CreateNode(int level)
	{
		return new Class56(level);
	}

	public virtual void Insert(double x1, double x2, object item)
	{
		base.Insert(new Interval(Math.Min(x1, x2), Math.Max(x1, x2)), item);
	}

	public virtual IList Query(double x)
	{
		return Query(x, x);
	}

	public virtual IList Query(double x1, double x2)
	{
		return base.Query(new Interval(Math.Min(x1, x2), Math.Max(x1, x2)));
	}

	protected override IComparer GetComparer()
	{
		return icomparer_0;
	}

	static SiRtree()
	{
		Class72.smethod_20();
	}
}
