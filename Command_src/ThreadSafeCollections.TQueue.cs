using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ThreadSafeCollections;

public class TQueue<T> : ICollection, IEnumerable
{
	private readonly Queue<T> queue_0;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	private readonly object object_0 = new object();

	private static object object_1;

	public int Count
	{
		get
		{
			readerWriterLockSlim_0.EnterReadLock();
			try
			{
				return queue_0.Count;
			}
			finally
			{
				readerWriterLockSlim_0.ExitReadLock();
			}
		}
	}

	public bool IsSynchronized => true;

	public object SyncRoot => object_0;

	public TQueue()
	{
		queue_0 = new Queue<T>();
	}

	public TQueue(int capacity)
	{
		queue_0 = new Queue<T>(capacity);
	}

	public TQueue(IEnumerable<T> collection)
	{
		queue_0 = new Queue<T>(collection);
	}

	public IEnumerator<T> GetEnumerator()
	{
		readerWriterLockSlim_0.EnterReadLock();
		Queue<T> queue;
		try
		{
			queue = new Queue<T>(queue_0);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
		foreach (T item in queue)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		readerWriterLockSlim_0.EnterReadLock();
		Queue<T> queue;
		try
		{
			queue = new Queue<T>(queue_0);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
		foreach (T item in queue)
		{
			yield return item;
		}
	}

	public void CopyTo(Array array, int index)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			queue_0.ToArray().CopyTo(array, index);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public void CopyTo(T[] array, int index)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			queue_0.CopyTo(array, index);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public void Enqueue(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			queue_0.Enqueue(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public int EnqueueAndCount(T item)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			queue_0.Enqueue(item);
			return queue_0.Count;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public T Dequeue()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			return queue_0.Dequeue();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void EnqueueAll(IEnumerable<T> ItemsToQueue)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			foreach (T item in ItemsToQueue)
			{
				queue_0.Enqueue(item);
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void EnqueueAll(TList<T> ItemsToQueue)
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			foreach (T item in ItemsToQueue)
			{
				queue_0.Enqueue(item);
			}
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public TList<T> DequeueAll()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			TList<T> tList = new TList<T>();
			while (queue_0.Count > 0)
			{
				tList.Add(queue_0.Dequeue());
			}
			return tList;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public List<T> DequeueAllList()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			List<T> list = new List<T>();
			while (queue_0.Count > 0)
			{
				list.Add(queue_0.Dequeue());
			}
			return list;
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public void Clear()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			queue_0.Clear();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	public bool Contains(T item)
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return queue_0.Contains(item);
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public T Peek()
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return queue_0.Peek();
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public T[] ToArray()
	{
		readerWriterLockSlim_0.EnterReadLock();
		try
		{
			return queue_0.ToArray();
		}
		finally
		{
			readerWriterLockSlim_0.ExitReadLock();
		}
	}

	public void TrimExcess()
	{
		readerWriterLockSlim_0.EnterWriteLock();
		try
		{
			queue_0.TrimExcess();
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	static TQueue()
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
