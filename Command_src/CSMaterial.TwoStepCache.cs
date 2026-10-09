using System;
using Microsoft.Extensions.Caching.Memory;

namespace CSMaterial;

public class TwoStepCache
{
	private readonly MemoryCache[] memoryCache_0 = new MemoryCache[180];

	private readonly object[] object_0 = new object[360];

	public TwoStepCache()
	{
		for (int i = 0; i < object_0.Length; i++)
		{
			object_0[i] = new object();
		}
	}

	public MemoryCache GetOrCreateCache(int key)
	{
		int num = key % memoryCache_0.Length;
		if (memoryCache_0[num] == null)
		{
			lock (object_0[num])
			{
				if (memoryCache_0[num] == null)
				{
					memoryCache_0[num] = new MemoryCache(new MemoryCacheOptions
					{
						ExpirationScanFrequency = TimeSpan.FromSeconds(60.0),
						Clock = new UTCProviderClock()
					});
				}
			}
		}
		return memoryCache_0[num];
	}

	public void ClearCache()
	{
		for (int i = 0; i < memoryCache_0.Length; i++)
		{
			lock (object_0[i])
			{
				if (memoryCache_0[i] != null)
				{
					memoryCache_0[i].Clear();
				}
			}
		}
	}

	static TwoStepCache()
	{
		Class72.smethod_20();
	}
}
