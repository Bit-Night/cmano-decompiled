using System.Collections.Generic;

namespace Collections.Pooled;

internal sealed class PooledSetEqualityComparer<T> : IEqualityComparer<PooledSet<T>>
{
	private readonly IEqualityComparer<T> iequalityComparer_0;

	private static object object_0;

	public PooledSetEqualityComparer()
	{
		iequalityComparer_0 = EqualityComparer<T>.Default;
	}

	public bool Equals(PooledSet<T> x, PooledSet<T> y)
	{
		return PooledSet<T>.PooledSetEquals(x, y, iequalityComparer_0);
	}

	public int GetHashCode(PooledSet<T> obj)
	{
		int num = 0;
		if (obj != null)
		{
			foreach (T item in obj)
			{
				num ^= iequalityComparer_0.GetHashCode(item) & 0x7FFFFFFF;
			}
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PooledSetEqualityComparer<T> pooledSetEqualityComparer))
		{
			if (obj is IEqualityComparer<T> equalityComparer)
			{
				return iequalityComparer_0 == equalityComparer;
			}
			return false;
		}
		return iequalityComparer_0 == pooledSetEqualityComparer.iequalityComparer_0;
	}

	public override int GetHashCode()
	{
		return iequalityComparer_0.GetHashCode();
	}

	static PooledSetEqualityComparer()
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
