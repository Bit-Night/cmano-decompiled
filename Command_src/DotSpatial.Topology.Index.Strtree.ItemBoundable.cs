namespace DotSpatial.Topology.Index.Strtree;

public class ItemBoundable : IBoundable
{
	private readonly object object_0;

	private readonly object object_1;

	public virtual object Item => object_1;

	public virtual object Bounds => object_0;

	public ItemBoundable(object bounds, object item)
	{
		object_0 = bounds;
		object_1 = item;
	}

	static ItemBoundable()
	{
		Class72.smethod_20();
	}
}
