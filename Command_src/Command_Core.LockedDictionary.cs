using System.Collections.Generic;
using System.Threading;

namespace Command_Core;

public class LockedDictionary<TKey, TValue>
{
	private readonly Dictionary<TKey, TValue> dictionary_0;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0;

	private static object object_0;

	public LockedDictionary()
	{
		dictionary_0 = new Dictionary<TKey, TValue>();
		readerWriterLockSlim_0 = new ReaderWriterLockSlim();
	}

	public bool TryGetValue(TKey key, ref TValue value)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return dictionary_0.TryGetValue(key, out value);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public void SetValue(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			dictionary_0[key] = value;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void TryAdd(TKey key, TValue value)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			if (!dictionary_0.ContainsKey(key))
			{
				dictionary_0.Add(key, value);
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool Remove(TKey key)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			return dictionary_0.Remove(key);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool ContainsKey(TKey key)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return dictionary_0.ContainsKey(key);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public void Clear()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			dictionary_0.Clear();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	static LockedDictionary()
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
