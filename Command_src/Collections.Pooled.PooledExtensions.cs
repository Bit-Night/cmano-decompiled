using System;
using System.Collections.Generic;

namespace Collections.Pooled;

public static class PooledExtensions
{
	public static PooledList<T> ToPooledList<T>(this IEnumerable<T> items)
	{
		return new PooledList<T>(items);
	}

	public static PooledList<T> ToPooledList<T>(this IEnumerable<T> items, int suggestCapacity)
	{
		return new PooledList<T>(items, suggestCapacity);
	}

	public static PooledList<T> ToPooledList<T>(this T[] array)
	{
		return new PooledList<T>(MemoryExtensions.AsSpan(array));
	}

	public static PooledList<T> ToPooledList<T>(this ReadOnlySpan<T> span)
	{
		return new PooledList<T>(span);
	}

	public static PooledList<T> ToPooledList<T>(this Span<T> span)
	{
		return new PooledList<T>(span);
	}

	public static PooledList<T> ToPooledList<T>(this ReadOnlyMemory<T> memory)
	{
		return new PooledList<T>(memory.Span);
	}

	public static PooledList<T> ToPooledList<T>(this Memory<T> memory)
	{
		return new PooledList<T>(memory.Span);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey> comparer = null)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		PooledDictionary<TKey, TValue> pooledDictionary = new PooledDictionary<TKey, TValue>((source as ICollection<TSource>)?.Count ?? 0, comparer);
		foreach (TSource item in source)
		{
			pooledDictionary.Add(keySelector(item), valueSelector(item));
		}
		return pooledDictionary;
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TSource, TKey, TValue>(this ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey> comparer = null)
	{
		PooledDictionary<TKey, TValue> pooledDictionary = new PooledDictionary<TKey, TValue>(source.Length, comparer);
		ReadOnlySpan<TSource> readOnlySpan = source;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			TSource arg = readOnlySpan[i];
			pooledDictionary.Add(keySelector(arg), valueSelector(arg));
		}
		return pooledDictionary;
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TSource, TKey, TValue>(this Span<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey> comparer)
	{
		return ToPooledDictionary((ReadOnlySpan<TSource>)source, keySelector, valueSelector, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TSource, TKey, TValue>(this ReadOnlyMemory<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey> comparer)
	{
		return ToPooledDictionary(source.Span, keySelector, valueSelector, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TSource, TKey, TValue>(this Memory<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey> comparer)
	{
		return ToPooledDictionary(source.Span, keySelector, valueSelector, comparer);
	}

	public static PooledDictionary<TKey, TSource> ToPooledDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		PooledDictionary<TKey, TSource> pooledDictionary = new PooledDictionary<TKey, TSource>((source as ICollection<TSource>)?.Count ?? 0, comparer);
		foreach (TSource item in source)
		{
			pooledDictionary.Add(keySelector(item), item);
		}
		return pooledDictionary;
	}

	public static PooledDictionary<TKey, TSource> ToPooledDictionary<TSource, TKey>(this ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
	{
		PooledDictionary<TKey, TSource> pooledDictionary = new PooledDictionary<TKey, TSource>(source.Length, comparer);
		ReadOnlySpan<TSource> readOnlySpan = source;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			TSource val = readOnlySpan[i];
			pooledDictionary.Add(keySelector(val), val);
		}
		return pooledDictionary;
	}

	public static PooledDictionary<TKey, TSource> ToPooledDictionary<TSource, TKey>(this Span<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
	{
		return ToPooledDictionary((ReadOnlySpan<TSource>)source, keySelector, comparer);
	}

	public static PooledDictionary<TKey, TSource> ToPooledDictionary<TSource, TKey>(this ReadOnlyMemory<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
	{
		return ToPooledDictionary(source.Span, keySelector, comparer);
	}

	public static PooledDictionary<TKey, TSource> ToPooledDictionary<TSource, TKey>(this Memory<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
	{
		return ToPooledDictionary(source.Span, keySelector, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> source, IEqualityComparer<TKey> comparer = null)
	{
		return new PooledDictionary<TKey, TValue>(source, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer = null)
	{
		return new PooledDictionary<TKey, TValue>(source, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TKey, TValue>(this IEnumerable<Tuple<TKey, TValue>> source, IEqualityComparer<TKey> comparer = null)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		PooledDictionary<TKey, TValue> pooledDictionary = new PooledDictionary<TKey, TValue>((source as ICollection<Tuple<TKey, TValue>>)?.Count ?? 0, comparer);
		foreach (Tuple<TKey, TValue> item in source)
		{
			pooledDictionary.Add(item.Item1, item.Item2);
		}
		return pooledDictionary;
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TKey, TValue>(this ReadOnlySpan<(TKey, TValue)> source, IEqualityComparer<TKey> comparer = null)
	{
		return new PooledDictionary<TKey, TValue>(source, comparer);
	}

	public static PooledDictionary<TKey, TValue> ToPooledDictionary<TKey, TValue>(this Span<(TKey, TValue)> source, IEqualityComparer<TKey> comparer = null)
	{
		return new PooledDictionary<TKey, TValue>(source, comparer);
	}

	public static PooledSet<T> ToPooledSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
	{
		return new PooledSet<T>(source, comparer);
	}

	public static PooledSet<T> ToPooledSet<T>(this Span<T> source, IEqualityComparer<T> comparer = null)
	{
		return new PooledSet<T>(source, comparer);
	}

	public static PooledSet<T> ToPooledSet<T>(this ReadOnlySpan<T> source, IEqualityComparer<T> comparer = null)
	{
		return new PooledSet<T>(source, comparer);
	}

	public static PooledSet<T> ToPooledSet<T>(this Memory<T> source, IEqualityComparer<T> comparer = null)
	{
		return new PooledSet<T>(source.Span, comparer);
	}

	public static PooledSet<T> ToPooledSet<T>(this ReadOnlyMemory<T> source, IEqualityComparer<T> comparer = null)
	{
		return new PooledSet<T>(source.Span, comparer);
	}

	public static PooledStack<T> ToPooledStack<T>(this IEnumerable<T> items)
	{
		return new PooledStack<T>(items);
	}

	public static PooledStack<T> ToPooledStack<T>(this T[] array)
	{
		return new PooledStack<T>(MemoryExtensions.AsSpan(array));
	}

	public static PooledStack<T> ToPooledStack<T>(this ReadOnlySpan<T> span)
	{
		return new PooledStack<T>(span);
	}

	public static PooledStack<T> ToPooledStack<T>(this Span<T> span)
	{
		return new PooledStack<T>(span);
	}

	public static PooledStack<T> ToPooledStack<T>(this ReadOnlyMemory<T> memory)
	{
		return new PooledStack<T>(memory.Span);
	}

	public static PooledStack<T> ToPooledStack<T>(this Memory<T> memory)
	{
		return new PooledStack<T>(memory.Span);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this IEnumerable<T> items)
	{
		return new PooledQueue<T>(items);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this ReadOnlySpan<T> span)
	{
		return new PooledQueue<T>(span);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this Span<T> span)
	{
		return new PooledQueue<T>(span);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this ReadOnlyMemory<T> memory)
	{
		return new PooledQueue<T>(memory.Span);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this Memory<T> memory)
	{
		return new PooledQueue<T>(memory.Span);
	}

	public static PooledQueue<T> ToPooledQueue<T>(this T[] array)
	{
		return new PooledQueue<T>(MemoryExtensions.AsSpan(array));
	}

	static PooledExtensions()
	{
		Class72.smethod_20();
	}
}
