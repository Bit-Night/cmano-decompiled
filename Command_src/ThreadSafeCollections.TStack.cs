using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadSafeCollections;

public class TStack<T> : IEnumerable<T>, IEnumerable, ICollection
{
	private readonly Stack<T> stack_0;

	private readonly ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	private readonly object object_0 = new object();

	private static object object_1;

	public int Count => ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => stack_0.Count);

	public bool IsSynchronized => true;

	public object SyncRoot => object_0;

	public TStack()
	{
		stack_0 = new Stack<T>();
	}

	public TStack(IEnumerable<T> col)
	{
		stack_0 = new Stack<T>(col);
	}

	public IEnumerator<T> GetEnumerator()
	{
		Stack<T> stack_0 = null;
		ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, delegate
		{
			stack_0 = new Stack<T>(this.stack_0);
		});
		foreach (T item in stack_0)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Stack<T> stack_0 = null;
		ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, delegate
		{
			stack_0 = new Stack<T>(this.stack_0);
		});
		foreach (T item in stack_0)
		{
			yield return item;
		}
	}

	public void CopyTo(Array array, int index)
	{
		ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, delegate
		{
			stack_0.ToArray().CopyTo(array, index);
		});
	}

	public void Clear()
	{
		ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			stack_0.Clear();
		});
	}

	public bool Contains(T item)
	{
		return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => stack_0.Contains(item));
	}

	public T Peek()
	{
		return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => stack_0.Peek());
	}

	public T Pop()
	{
		return ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, () => stack_0.Pop());
	}

	public void Push(T item)
	{
		ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			stack_0.Push(item);
		});
	}

	public T[] ToArray()
	{
		return ReadWriteLockSlimExtend.PerformUsingReadLock(readerWriterLockSlim_0, () => stack_0.ToArray());
	}

	public void TrimExcess()
	{
		ReadWriteLockSlimExtend.PerformUsingWriteLock(readerWriterLockSlim_0, delegate
		{
			stack_0.TrimExcess();
		});
	}

	[CompilerGenerated]
	private int method_0()
	{
		return stack_0.Count;
	}

	[CompilerGenerated]
	private void method_1()
	{
		stack_0.Clear();
	}

	[CompilerGenerated]
	private T method_2()
	{
		return stack_0.Peek();
	}

	[CompilerGenerated]
	private T method_3()
	{
		return stack_0.Pop();
	}

	[CompilerGenerated]
	private T[] method_4()
	{
		return stack_0.ToArray();
	}

	[CompilerGenerated]
	private void IbAywNuGoAf()
	{
		stack_0.TrimExcess();
	}

	static TStack()
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
