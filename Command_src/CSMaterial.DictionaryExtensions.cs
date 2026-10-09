using System.Collections.Generic;

namespace CSMaterial;

public static class DictionaryExtensions
{
	public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue newVal)
	{
		if (dictionary.TryGetValue(key, out var _))
		{
			dictionary[key] = newVal;
		}
		else
		{
			dictionary.Add(key, newVal);
		}
	}

	static DictionaryExtensions()
	{
		Class72.smethod_20();
	}
}
