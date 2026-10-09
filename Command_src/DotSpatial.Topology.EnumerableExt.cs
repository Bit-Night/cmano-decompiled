using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public static class EnumerableExt
{
	public static List<T> CloneList<T>(this IEnumerable<T> original) where T : ICloneable
	{
		List<T> list = new List<T>();
		foreach (T item in original)
		{
			list.Add(smethod_0<T>(item.Clone()));
		}
		return list;
	}

	private static T smethod_0<T>(object object_0)
	{
		if (object_0 == null)
		{
			return default(T);
		}
		if (!(object_0 is T))
		{
			return default(T);
		}
		return (T)object_0;
	}

	static EnumerableExt()
	{
		Class72.smethod_20();
	}
}
