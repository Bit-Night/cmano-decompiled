using System.Collections.Generic;
using System.Linq;

namespace DarkUI.Extensions;

internal static class IEnumerableExtensions
{
	internal static bool IsLast<T>(this IEnumerable<T> items, T item)
	{
		T val = items.LastOrDefault();
		if (val == null)
		{
			return false;
		}
		return item.Equals(val);
	}

	internal static bool IsFirst<T>(this IEnumerable<T> items, T item)
	{
		T val = items.FirstOrDefault();
		if (val == null)
		{
			return false;
		}
		return item.Equals(val);
	}

	internal static bool IsFirstOrLast<T>(this IEnumerable<T> items, T item)
	{
		if (!IsFirst(items, item))
		{
			return IsLast(items, item);
		}
		return true;
	}

	static IEnumerableExtensions()
	{
		Class72.smethod_20();
	}
}
