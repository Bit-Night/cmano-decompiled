using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class TwoTierArrayCache<TValue>
{
	private readonly TValue[] gparam_0;

	private readonly bool[] bool_0;

	private readonly MemoryCache memoryCache_0;

	private readonly object object_0;

	internal static object object_1;

	public TwoTierArrayCache(int maxKey)
	{
		object_0 = RuntimeHelpers.GetObjectValue(new object());
		gparam_0 = new TValue[maxKey + 1];
		bool_0 = new bool[maxKey + 1];
		memoryCache_0 = new MemoryCache(new MemoryCacheOptions
		{
			ExpirationScanFrequency = TimeSpan.FromSeconds(30.0),
			Clock = new UTCProviderClock()
		});
	}

	public bool TryGet(int key, ref TValue value)
	{
		if (key >= 0 && key < gparam_0.Length && bool_0[key])
		{
			value = gparam_0[key];
			return true;
		}
		if (memoryCache_0.TryGetValue<TValue>(key, out value))
		{
			int result;
			if (key < 0)
			{
				result = 1;
			}
			else
			{
				if (key < gparam_0.Length)
				{
					object obj = object_0;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					bool lockTaken = false;
					Monitor.Enter(obj, ref lockTaken);
					gparam_0[key] = value;
					bool_0[key] = true;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public void SetItem(int key, TValue value, TimeSpan slidingExpiration)
	{
		MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
		{
			SlidingExpiration = slidingExpiration
		};
		options.RegisterPostEvictionCallback([SpecialName] (object evictedKey, object evictedValue, EvictionReason reason, object state) =>
		{
			int num = Conversions.ToInteger(evictedKey);
			if (num >= 0 && num < gparam_0.Length)
			{
				object obj2 = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
				bool lockTaken2 = false;
				try
				{
					Monitor.Enter(obj2, ref lockTaken2);
					bool_0[num] = false;
				}
				finally
				{
					if (lockTaken2)
					{
						Monitor.Exit(obj2);
					}
				}
			}
		});
		memoryCache_0.Set(key, value, options);
		if (key < 0 || key >= gparam_0.Length)
		{
			return;
		}
		object obj = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			gparam_0[key] = value;
			bool_0[key] = true;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public void Remove(int key)
	{
		if (key >= 0 && key < gparam_0.Length)
		{
			object obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				bool_0[key] = false;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		memoryCache_0.Remove(key);
	}

	public void Clear()
	{
		memoryCache_0.Clear();
		TValue[] theArray = gparam_0;
		ArrayExtensions.Clear(ref theArray);
		bool[] theArray2 = bool_0;
		ArrayExtensions.Clear(ref theArray2);
	}

	static TwoTierArrayCache()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_1 == null;
	}

	internal static object smethod_1()
	{
		return object_1;
	}
}
