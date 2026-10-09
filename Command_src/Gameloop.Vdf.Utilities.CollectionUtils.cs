using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameloop.Vdf.Utilities;

internal static class CollectionUtils
{
	public static void AddRange<T>(this IList<T> initial, IEnumerable<T> collection)
	{
		if (initial == null)
		{
			throw new ArgumentNullException("initial");
		}
		if (collection == null)
		{
			return;
		}
		foreach (T item in collection)
		{
			initial.Add(item);
		}
	}

	public static T[] ArrayEmpty<T>()
	{
		return (Enumerable.Empty<T>() as T[]) ?? new T[0];
	}

	static CollectionUtils()
	{
		Class72.smethod_20();
	}
}
