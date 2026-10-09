using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DictionaryExtensions
{
	public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
	{
		if (dict.ContainsKey(key))
		{
			return false;
		}
		dict.Add(key, value);
		return true;
	}

	public static bool AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] = value;
			return true;
		}
		dict.Add(key, value);
		return false;
	}

	static DictionaryExtensions()
	{
		Class72.smethod_20();
	}
}
