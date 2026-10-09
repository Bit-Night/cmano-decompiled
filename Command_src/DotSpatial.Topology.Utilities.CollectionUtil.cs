using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class CollectionUtil
{
	public delegate T GenericMethod<T>(T obj);

	public static IList Transform(ICollection coll, GenericMethod<object> func)
	{
		IList list = new ArrayList();
		foreach (object item in coll)
		{
			list.Add(func(item));
		}
		return list;
	}

	public static void Apply(ICollection coll, GenericMethod<object> func)
	{
		foreach (object item in coll)
		{
			func(item);
		}
	}

	public static IList Select(ICollection coll, GenericMethod<object> func)
	{
		IList list = new ArrayList();
		foreach (object item in coll)
		{
			if (true.Equals(func(item)))
			{
				list.Add(item);
			}
		}
		return list;
	}

	static CollectionUtil()
	{
		Class72.smethod_20();
	}
}
