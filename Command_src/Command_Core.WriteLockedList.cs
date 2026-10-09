using System.Collections.Generic;
using System.Threading;

namespace Command_Core;

public class WriteLockedList<T> : List<T>
{
	private readonly ReaderWriterLockSlim readerWriterLockSlim_0;

	private static object object_0;

	public new T this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			readerWriterLockSlim_0.EnterWriteLock();
			try
			{
				base[index] = value;
			}
			finally
			{
				readerWriterLockSlim_0.ExitWriteLock();
			}
		}
	}

	public WriteLockedList()
	{
		readerWriterLockSlim_0 = new ReaderWriterLockSlim();
	}

	public new void Add(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			base.Add(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public new void AddRange(IEnumerable<T> collection)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			base.AddRange(collection);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public new void Remove(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			base.Remove(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public new void RemoveAt(int index)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			base.RemoveAt(index);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public new void Clear()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			base.Clear();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	static WriteLockedList()
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
