using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class ThreadLocalArrayPool<T> : ArrayPool<T>
{
	private readonly ThreadLocal<Stack<T[]>> threadLocal_0;

	internal static object object_0;

	public ThreadLocalArrayPool()
	{
		threadLocal_0 = new ThreadLocal<Stack<T[]>>(() => new Stack<T[]>());
	}

	public override T[] Rent(int minimumLength)
	{
		Stack<T[]> value = threadLocal_0.Value;
		while (value.Count > 0)
		{
			T[] array = value.Pop();
			if (array.Length >= minimumLength)
			{
				return array;
			}
		}
		return new T[minimumLength];
	}

	public override void Return(T[] theArray, bool clearArray = false)
	{
		if (clearArray)
		{
			Array.Clear(theArray, 0, theArray.Length);
		}
		if (theArray.Length <= 65536)
		{
			threadLocal_0.Value.Push(theArray);
		}
	}

	static ThreadLocalArrayPool()
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
