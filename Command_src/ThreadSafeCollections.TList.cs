using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly List<T> list_0;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	private bool bool_0;

	private int int_0;

	internal static object object_0;

	public int Capacity
	{
		get
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			try
			{
				return list_0.Capacity;
			}
			finally
			{
				if (bool_0)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
		set
		{
			readerWriterLockSlim_0.EnterWriteLock();
			try
			{
				list_0.Capacity = value;
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public int Count
	{
		get
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			try
			{
				return list_0.Count;
			}
			finally
			{
				if (bool_0)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
	}

	public bool IsReadOnly => false;

	public T this[int index]
	{
		get
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			try
			{
				return list_0[index];
			}
			finally
			{
				if (bool_0)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
		set
		{
			readerWriterLockSlim_0.EnterWriteLock();
			try
			{
				list_0[index] = value;
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	[SpecialName]
	private bool method_0()
	{
		return Thread.VolatileRead(ref int_0) == 1;
	}

	[SpecialName]
	private void method_1(bool bool_1)
	{
		Thread.VolatileWrite(ref int_0, bool_1 ? 1 : 0);
	}

	public TList(bool useReadLock = false)
	{
		list_0 = new List<T>();
		bool_0 = useReadLock;
	}

	public TList(int capacity, bool useReadLock = false)
	{
		list_0 = new List<T>(capacity);
		bool_0 = useReadLock;
	}

	public TList(IEnumerable<T> collection, bool useReadLock = true)
	{
		list_0 = new List<T>(collection);
		bool_0 = useReadLock;
	}

	public static implicit operator TList<T>(List<T> value)
	{
		return new TList<T>(value);
	}

	public IEnumerator GetEnumerator()
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		List<T> list;
		try
		{
			list = new List<T>(list_0);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
		foreach (T item in list)
		{
			yield return item;
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		List<T> list;
		try
		{
			list = new List<T>(list_0);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
		foreach (T item in list)
		{
			yield return item;
		}
	}

	public void Dispose()
	{
		method_2(bool_1: true);
		GC.SuppressFinalize(this);
	}

	private void method_2(bool bool_1)
	{
		if (!method_0())
		{
			method_1(bool_1: true);
		}
	}

	~TList()
	{
		method_2(bool_1: false);
	}

	public void Add(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Add(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void AddRange(IEnumerable<T> collection)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.AddRange(collection);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool AddIfNotExist(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (list_0.Contains(item))
			{
				return false;
			}
			list_0.Add(item);
			return true;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public ReadOnlyCollection<T> AsReadOnly()
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.AsReadOnly();
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int BinarySearch(T item)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.BinarySearch(item);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int BinarySearch(T item, IComparer<T> comparer)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.BinarySearch(item, comparer);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.BinarySearch(index, count, item, comparer);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void Clear()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Clear();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool Contains(T item)
	{
		return list_0.Contains(item);
	}

	public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.ConvertAll(converter);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			list_0.CopyTo(array, arrayIndex);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public bool Exists(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.Exists(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public T Find(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.Find(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public List<T> FindAll(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindAll(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindIndex(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindIndex(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindIndex(int startIndex, Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindIndex(startIndex, match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindIndex(int startIndex, int count, Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindIndex(startIndex, count, match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public T FindLast(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindLast(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindLastIndex(Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindLastIndex(match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindLastIndex(int startIndex, Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindLastIndex(startIndex, match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int FindLastIndex(int startIndex, int count, Predicate<T> match)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.FindLastIndex(startIndex, count, match);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void ForEach(Action<T> action)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			list_0.ForEach(action);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public List<T> GetRange(int index, int count)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.GetRange(index, count);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int IndexOf(T item)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.IndexOf(item);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int IndexOf(T item, int index)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.IndexOf(item, index);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int IndexOf(T item, int index, int count)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.IndexOf(item, index, count);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void Insert(int index, T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Insert(index, item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void InsertRange(int index, IEnumerable<T> range)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.InsertRange(index, range);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public int LastIndexOf(T item)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.LastIndexOf(item);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int LastIndexOf(T item, int index)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.LastIndexOf(item, index);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public int LastIndexOf(T item, int index, int count)
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.LastIndexOf(item, index, count);
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public bool Remove(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			return list_0.Remove(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public int RemoveAll(Predicate<T> match)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			return list_0.RemoveAll(match);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void RemoveAt(int index)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.RemoveAt(index);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void RemoveRange(int index, int count)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.RemoveRange(index, count);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Reverse()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Reverse();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Reverse(int index, int count)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Reverse(index, count);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Sort()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Sort();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Sort(Comparison<T> comparison)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Sort(comparison);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Sort(IComparer<T> comparer)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Sort(comparer);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Sort(int index, int count, IComparer<T> comparer)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.Sort(index, count, comparer);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public T[] ToArray()
	{
		if (bool_0)
		{
			readerWriterLockSlim_0.EnterReadLock();
		}
		try
		{
			return list_0.ToArray();
		}
		finally
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void TrimExcess()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			list_0.TrimExcess();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool TrueForAll(Predicate<T> match)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return list_0.TrueForAll(match);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	static TList()
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
