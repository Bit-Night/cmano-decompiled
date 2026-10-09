using System;
using System.Collections;
using System.Collections.Generic;

public class FixedSizeQueue<T> : IEnumerable<T>, IEnumerable
{
	private readonly Queue<T> queue_0 = new Queue<T>();

	private readonly int int_0;

	private static object object_0;

	public int Count => queue_0.Count;

	public FixedSizeQueue(int maxSize)
	{
		if (maxSize <= 0)
		{
			throw new ArgumentException("Size must be greater than zero.", "maxSize");
		}
		int_0 = maxSize;
	}

	public void Enqueue(T item)
	{
		if (queue_0.Count >= int_0)
		{
			queue_0.Dequeue();
		}
		queue_0.Enqueue(item);
	}

	public T Dequeue()
	{
		return queue_0.Dequeue();
	}

	public bool IsEmpty()
	{
		return queue_0.Count == 0;
	}

	public T Peek()
	{
		return queue_0.Peek();
	}

	public void Clear()
	{
		queue_0.Clear();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return queue_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	static FixedSizeQueue()
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
