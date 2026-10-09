namespace System.Runtime.Caching;

public static class ObjectCacheExtensions
{
	public static T Get<T>(ObjectCache cache, string key, T @default = default(T))
	{
		object obj = cache.Get(key, (string)null);
		if (obj is T)
		{
			return (T)obj;
		}
		return @default;
	}

	public static bool TryGetValue<T>(ObjectCache cache, string key, out T value)
	{
		if (cache.Get(key, (string)null) is T val)
		{
			value = val;
			return true;
		}
		value = default(T);
		return false;
	}

	public static T AddOrGetExisting<T>(ObjectCache cache, string key, T item, CacheItemPolicy policy)
	{
		object obj = cache.Get(key, (string)null);
		if (obj is T)
		{
			return (T)obj;
		}
		cache.Add(key, (object)item, policy, (string)null);
		return item;
	}

	public static T AddOrGetExisting<T>(ObjectCache cache, string key, Func<(T item, CacheItemPolicy policy)> addFunc)
	{
		object obj = cache.Get(key, (string)null);
		if (obj is T)
		{
			return (T)obj;
		}
		var (val, val2) = addFunc();
		cache.Add(key, (object)val, val2, (string)null);
		return val;
	}

	public static T AddOrGetExisting<T>(ObjectCache cache, string key, Func<string, (T item, CacheItemPolicy policy)> addFunc)
	{
		object obj = cache.Get(key, (string)null);
		if (obj is T)
		{
			return (T)obj;
		}
		var (val, val2) = addFunc(key);
		cache.Add(key, (object)val, val2, (string)null);
		return val;
	}

	static ObjectCacheExtensions()
	{
		Class72.smethod_20();
	}
}
