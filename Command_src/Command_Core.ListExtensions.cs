using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class ListExtensions
{
	private struct Struct27<T>
	{
		public float Key;

		public T Value;
	}

	public static void SortByKey<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable
	{
		list.Sort([SpecialName] (T a, T b) => keySelector(a).CompareTo(keySelector(b)));
	}

	public static void SortByCachedKey<T>(this List<T> list, Func<T, float> keySelector)
	{
		int count = list.Count;
		if (count > 1)
		{
			Struct27<T>[] array = new Struct27<T>[count - 1 + 1];
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i].Value = list[i];
				array[i].Key = keySelector(list[i]);
			}
			Array.Sort(array, [SpecialName] (Struct27<T> a, Struct27<T> b) => a.Key.CompareTo(b.Key));
			int num2 = count - 1;
			for (int num3 = 0; num3 <= num2; num3++)
			{
				list[num3] = array[num3].Value;
			}
		}
	}

	static ListExtensions()
	{
		Class72.smethod_20();
	}
}
