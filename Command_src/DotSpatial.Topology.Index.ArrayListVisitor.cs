using System.Collections;

namespace DotSpatial.Topology.Index;

public class ArrayListVisitor : IItemVisitor
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	public virtual ArrayList Items => arrayList_0;

	public virtual void VisitItem(object item)
	{
		arrayList_0.Add(item);
	}

	static ArrayListVisitor()
	{
		Class72.smethod_20();
	}
}
