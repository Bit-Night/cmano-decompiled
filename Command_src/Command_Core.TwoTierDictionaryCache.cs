using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;
using ThreadSafeCollections;

namespace Command_Core;

public class TwoTierDictionaryCache<TKey, TValue>
{
	private readonly TDictionary<TKey, TValue> tdictionary_0;

	private readonly MemoryCache memoryCache_0;

	internal static object object_0;

	public TwoTierDictionaryCache()
	{
		tdictionary_0 = new TDictionary<TKey, TValue>();
		memoryCache_0 = new MemoryCache(new MemoryCacheOptions
		{
			ExpirationScanFrequency = TimeSpan.FromSeconds(30.0),
			Clock = new UTCProviderClock()
		});
	}

	public bool TryGet(TKey key, ref TValue value)
	{
		if (tdictionary_0.TryGetValue(key, out value))
		{
			return true;
		}
		if (memoryCache_0.TryGetValue<TValue>(key, out value))
		{
			tdictionary_0[key] = value;
			return true;
		}
		return false;
	}

	public void SetItem(TKey key, TValue value, TimeSpan slidingExpiration)
	{
		MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
		{
			SlidingExpiration = slidingExpiration
		};
		options.RegisterPostEvictionCallback([SpecialName] (object evictedKey, object evictedValue, EvictionReason reason, object state) =>
		{
			tdictionary_0.Remove((TKey)evictedKey);
		});
		memoryCache_0.Set(key, value, options);
		tdictionary_0[key] = value;
	}

	public void Remove(TKey key)
	{
		tdictionary_0.Remove(key);
		memoryCache_0.Remove(key);
	}

	public void Clear()
	{
		memoryCache_0.Clear();
		tdictionary_0.Clear();
	}

	static TwoTierDictionaryCache()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
