using System.Collections.Generic;

namespace DiskQueue.Implementation;

public static class Extensions
{
	public static T GetOrCreateValue<T, K>(this IDictionary<K, T> self, K key) where T : new()
	{
		if (!self.TryGetValue(key, out var value))
		{
			value = new T();
			self.Add(key, value);
		}
		return value;
	}

	public static T GetValueOrDefault<T, K>(this IDictionary<K, T> self, K key)
	{
		if (self.TryGetValue(key, out var value))
		{
			return value;
		}
		return default(T);
	}

	static Extensions()
	{
		Class72.smethod_20();
	}
}
