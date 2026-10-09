using System.Collections;

namespace DotSpatial.Topology.Index.Quadtree;

public class Quadtree : ISpatialIndex
{
	protected readonly Root Root;

	private double double_0 = 1.0;

	public virtual int Depth
	{
		get
		{
			if (Root == null)
			{
				return 0;
			}
			return Root.Depth;
		}
	}

	public virtual int Count
	{
		get
		{
			if (Root != null)
			{
				return Root.Count;
			}
			return 0;
		}
	}

	public Quadtree()
	{
		Root = new Root();
	}

	public virtual void Insert(IEnvelope itemEnv, object item)
	{
		method_0(itemEnv);
		IEnvelope itemEnv2 = EnsureExtent(itemEnv, double_0);
		Root.Insert(itemEnv2, item);
	}

	public virtual bool Remove(IEnvelope itemEnv, object item)
	{
		IEnvelope itemEnv2 = EnsureExtent(itemEnv, double_0);
		return Root.Remove(itemEnv2, item);
	}

	public virtual IList Query(IEnvelope searchEnv)
	{
		ArrayListVisitor arrayListVisitor = new ArrayListVisitor();
		Query(searchEnv, arrayListVisitor);
		return arrayListVisitor.Items;
	}

	public virtual void Query(IEnvelope searchEnv, IItemVisitor visitor)
	{
		Root.Visit(searchEnv, visitor);
	}

	public static IEnvelope EnsureExtent(IEnvelope itemEnv, double minExtent)
	{
		double num = itemEnv.Minimum.X;
		double num2 = itemEnv.Maximum.X;
		double num3 = itemEnv.Minimum.Y;
		double num4 = itemEnv.Maximum.Y;
		if (num != num2 && num3 != num4)
		{
			return itemEnv;
		}
		if (num == num2)
		{
			num -= minExtent / 2.0;
			num2 = num + minExtent / 2.0;
		}
		if (num3 == num4)
		{
			num3 -= minExtent / 2.0;
			num4 = num3 + minExtent / 2.0;
		}
		return new Envelope(num, num2, num3, num4);
	}

	public virtual IList QueryAll()
	{
		IList resultItems = new ArrayList();
		Root.AddAllItems(ref resultItems);
		return resultItems;
	}

	private void method_0(IRectangle irectangle_0)
	{
		double width = irectangle_0.Width;
		if (width < double_0 && width > 0.0)
		{
			double_0 = width;
		}
		double width2 = irectangle_0.Width;
		if (width2 < double_0 && width2 > 0.0)
		{
			double_0 = width2;
		}
	}

	static Quadtree()
	{
		Class72.smethod_20();
	}
}
