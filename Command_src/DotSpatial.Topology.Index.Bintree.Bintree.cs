using System.Collections;

namespace DotSpatial.Topology.Index.Bintree;

public class Bintree
{
	private readonly Root root_0;

	private double double_0 = 1.0;

	public virtual int Depth
	{
		get
		{
			if (root_0 == null)
			{
				return 0;
			}
			return root_0.Depth;
		}
	}

	public virtual int Count
	{
		get
		{
			if (root_0 != null)
			{
				return root_0.Count;
			}
			return 0;
		}
	}

	public virtual int NodeSize
	{
		get
		{
			if (root_0 == null)
			{
				return 0;
			}
			return root_0.NodeCount;
		}
	}

	public Bintree()
	{
		root_0 = new Root();
	}

	public static Interval EnsureExtent(Interval itemInterval, double minExtent)
	{
		double num = itemInterval.Min;
		double num2 = itemInterval.Max;
		if (num != num2)
		{
			return itemInterval;
		}
		if (num == num2)
		{
			num -= minExtent / 2.0;
			num2 = num + minExtent / 2.0;
		}
		return new Interval(num, num2);
	}

	public virtual void Insert(Interval itemInterval, object item)
	{
		method_0(itemInterval);
		Interval itemInterval2 = EnsureExtent(itemInterval, double_0);
		root_0.Insert(itemInterval2, item);
	}

	public virtual IEnumerator GetEnumerator()
	{
		IList list = new ArrayList();
		root_0.AddAllItems(list);
		return list.GetEnumerator();
	}

	public virtual IList Query(double x)
	{
		return Query(new Interval(x, x));
	}

	public virtual IList Query(Interval interval)
	{
		IList list = new ArrayList();
		Query(interval, list);
		return list;
	}

	public virtual void Query(Interval interval, IList foundItems)
	{
		root_0.AddAllItemsFromOverlapping(interval, foundItems);
	}

	private void method_0(Interval interval_0)
	{
		double width = interval_0.Width;
		if (width < double_0 && width > 0.0)
		{
			double_0 = width;
		}
	}

	static Bintree()
	{
		Class72.smethod_20();
	}
}
