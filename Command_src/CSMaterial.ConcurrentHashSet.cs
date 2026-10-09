using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace CSMaterial;

public sealed class ConcurrentHashSet<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IDisposable
{
	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

	private readonly HashSet<T> hashSet_0 = new HashSet<T>();

	private bool bool_0 = true;

	private static object object_0;

	public int Count
	{
		get
		{
			try
			{
				if (bool_0)
				{
					readerWriterLockSlim_0.EnterReadLock();
				}
				return hashSet_0.Count;
			}
			finally
			{
				if (bool_0 && readerWriterLockSlim_0.IsReadLockHeld)
				{
					readerWriterLockSlim_0.ExitReadLock();
				}
			}
		}
	}

	public ConcurrentHashSet(bool useReadLock = true)
	{
		bool_0 = useReadLock;
	}

	public bool Add(T item)
	{
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			return hashSet_0.Add(item);
		}
		finally
		{
			if (readerWriterLockSlim_0.IsWriteLockHeld)
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public void Clear()
	{
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			hashSet_0.Clear();
		}
		finally
		{
			if (readerWriterLockSlim_0.IsWriteLockHeld)
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public bool Contains(T item)
	{
		try
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			return hashSet_0.Contains(item);
		}
		finally
		{
			if (bool_0 && readerWriterLockSlim_0.IsReadLockHeld)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public bool Remove(T item)
	{
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			return hashSet_0.Remove(item);
		}
		finally
		{
			if (readerWriterLockSlim_0.IsWriteLockHeld)
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public List<T> ToList()
	{
		try
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			return new List<T>(hashSet_0);
		}
		finally
		{
			if (bool_0 && readerWriterLockSlim_0.IsReadLockHeld)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public T[] ToArray()
	{
		try
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			T[] array = new T[hashSet_0.Count];
			hashSet_0.CopyTo(array);
			return array;
		}
		finally
		{
			if (bool_0 && readerWriterLockSlim_0.IsReadLockHeld)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		try
		{
			if (bool_0)
			{
				readerWriterLockSlim_0.EnterReadLock();
			}
			hashSet_0.CopyTo(array, arrayIndex);
		}
		finally
		{
			if (bool_0 && readerWriterLockSlim_0.IsReadLockHeld)
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ToList().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Dispose()
	{
		if (readerWriterLockSlim_0 != null)
		{
			readerWriterLockSlim_0.Dispose();
		}
	}

	static ConcurrentHashSet()
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
