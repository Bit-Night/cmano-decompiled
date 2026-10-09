using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace Collections.Pooled;

[Serializable]
[DebuggerTypeProxy(typeof(QueueDebugView<>))]
[DebuggerDisplay("Count = {Count}")]
public class PooledQueue<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, IDisposable, IDeserializationCallback
{
	public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private readonly PooledQueue<T> pooledQueue_0;

		private readonly int int_0;

		private int int_1;

		private T gparam_0;

		public T Current
		{
			get
			{
				if (int_1 < 0)
				{
					method_0();
				}
				return gparam_0;
			}
		}

		object IEnumerator.Current => Current;

		internal Enumerator(PooledQueue<T> q)
		{
			pooledQueue_0 = q;
			int_0 = q.int_3;
			int_1 = -1;
			gparam_0 = default(T);
		}

		public void Dispose()
		{
			int_1 = -2;
			gparam_0 = default(T);
		}

		public bool MoveNext()
		{
			if (int_0 != pooledQueue_0.int_3)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			if (int_1 == -2)
			{
				return false;
			}
			int_1++;
			if (int_1 == pooledQueue_0.int_2)
			{
				int_1 = -2;
				gparam_0 = default(T);
				return false;
			}
			T[] array = pooledQueue_0.gparam_0;
			int num = array.Length;
			int num2 = pooledQueue_0.int_0 + int_1;
			if (num2 >= num)
			{
				num2 -= num;
			}
			gparam_0 = array[num2];
			return true;
		}

		private void method_0()
		{
			if (int_1 == -1)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumNotStarted();
			}
			else
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumEnded();
			}
		}

		void IEnumerator.Reset()
		{
			if (int_0 != pooledQueue_0.int_3)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			int_1 = -1;
			gparam_0 = default(T);
		}

		static Enumerator()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return true;
		}

		internal static object smethod_1()
		{
			return null;
		}
	}

	[NonSerialized]
	private ArrayPool<T> arrayPool_0;

	[NonSerialized]
	private object object_0;

	private T[] gparam_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private readonly bool bool_0;

	private static object object_1;

	public int Count => int_2;

	public ClearMode ClearMode
	{
		get
		{
			if (bool_0)
			{
				return ClearMode.Always;
			}
			return ClearMode.Never;
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot
	{
		get
		{
			if (object_0 == null)
			{
				Interlocked.CompareExchange<object>(ref object_0, new object(), (object)null);
			}
			return object_0;
		}
	}

	public PooledQueue()
		: this(ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(ClearMode clearMode)
		: this(clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(ArrayPool<T> customPool)
		: this(ClearMode.Auto, customPool)
	{
	}

	public PooledQueue(ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		gparam_0 = Array.Empty<T>();
		bool_0 = smethod_0(clearMode);
	}

	public PooledQueue(int capacity)
		: this(capacity, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(int capacity, ClearMode clearMode)
		: this(capacity, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(int capacity, ArrayPool<T> customPool)
		: this(capacity, ClearMode.Auto, customPool)
	{
	}

	public PooledQueue(int capacity, ClearMode clearMode, ArrayPool<T> customPool)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		gparam_0 = arrayPool_0.Rent(capacity);
		bool_0 = smethod_0(clearMode);
	}

	public PooledQueue(IEnumerable<T> enumerable)
		: this(enumerable, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(IEnumerable<T> enumerable, ClearMode clearMode)
		: this(enumerable, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(IEnumerable<T> enumerable, ArrayPool<T> customPool)
		: this(enumerable, ClearMode.Auto, customPool)
	{
	}

	public PooledQueue(IEnumerable<T> enumerable, ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_0(clearMode);
		if (enumerable == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.enumerable);
			return;
		}
		if (!(enumerable is ICollection<T> collection))
		{
			using (PooledList<T> pooledList = new PooledList<T>(enumerable))
			{
				gparam_0 = arrayPool_0.Rent(pooledList.Count);
				pooledList.Span.CopyTo(gparam_0);
				int_2 = pooledList.Count;
				if (int_2 != gparam_0.Length)
				{
					int_1 = int_2;
				}
				return;
			}
		}
		if (collection.Count == 0)
		{
			gparam_0 = Array.Empty<T>();
			return;
		}
		gparam_0 = arrayPool_0.Rent(collection.Count);
		collection.CopyTo(gparam_0, 0);
		int_2 = collection.Count;
		if (int_2 != gparam_0.Length)
		{
			int_1 = int_2;
		}
	}

	public PooledQueue(T[] array)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(T[] array, ClearMode clearMode)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(T[] array, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, customPool)
	{
	}

	public PooledQueue(T[] array, ClearMode clearMode, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, customPool)
	{
	}

	public PooledQueue(ReadOnlySpan<T> span)
		: this(span, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(ReadOnlySpan<T> span, ClearMode clearMode)
		: this(span, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledQueue(ReadOnlySpan<T> span, ArrayPool<T> customPool)
		: this(span, ClearMode.Auto, customPool)
	{
	}

	public PooledQueue(ReadOnlySpan<T> span, ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_0(clearMode);
		gparam_0 = arrayPool_0.Rent(span.Length);
		span.CopyTo(gparam_0);
		int_2 = span.Length;
		if (int_2 != gparam_0.Length)
		{
			int_1 = int_2;
		}
	}

	public void Clear()
	{
		if (int_2 != 0)
		{
			if (bool_0)
			{
				if (int_0 >= int_1)
				{
					Array.Clear(gparam_0, int_0, gparam_0.Length - int_0);
					Array.Clear(gparam_0, 0, int_1);
				}
				else
				{
					Array.Clear(gparam_0, int_0, int_2);
				}
			}
			int_2 = 0;
		}
		int_0 = 0;
		int_1 = 0;
		int_3++;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if ((uint)arrayIndex > (uint)array.Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.arrayIndex, ExceptionResource.ArgumentOutOfRange_Index);
		}
		if (array.Length - arrayIndex < int_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		int num = int_2;
		if (num != 0)
		{
			int num2 = Math.Min(gparam_0.Length - int_0, num);
			Array.Copy(gparam_0, int_0, array, arrayIndex, num2);
			num -= num2;
			if (num > 0)
			{
				Array.Copy(gparam_0, 0, array, arrayIndex + gparam_0.Length - int_0, num);
			}
		}
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (array.Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Rank_MultiDimNotSupported, ExceptionArgument.array);
		}
		if (array.GetLowerBound(0) != 0)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound, ExceptionArgument.array);
		}
		int length = array.Length;
		if ((uint)index > (uint)length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
		}
		if (length - index < int_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		int num = int_2;
		if (num == 0)
		{
			return;
		}
		try
		{
			int num2 = ((gparam_0.Length - int_0 >= num) ? num : (gparam_0.Length - int_0));
			Array.Copy(gparam_0, int_0, array, index, num2);
			num -= num2;
			if (num > 0)
			{
				Array.Copy(gparam_0, 0, array, index + gparam_0.Length - int_0, num);
			}
		}
		catch (ArrayTypeMismatchException)
		{
			ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
		}
	}

	public void Enqueue(T item)
	{
		if (int_2 == gparam_0.Length)
		{
			int num = (int)(gparam_0.Length * 200L / 100L);
			if (num < gparam_0.Length + 4)
			{
				num = gparam_0.Length + 4;
			}
			method_0(num);
		}
		gparam_0[int_1] = item;
		method_1(ref int_1);
		int_2++;
		int_3++;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}

	public T Dequeue()
	{
		int num = int_0;
		T[] array = gparam_0;
		if (int_2 == 0)
		{
			method_2();
		}
		T result = array[num];
		if (bool_0)
		{
			array[num] = default(T);
		}
		method_1(ref int_0);
		int_2--;
		int_3++;
		return result;
	}

	public bool TryDequeue(out T result)
	{
		int num = int_0;
		T[] array = gparam_0;
		if (int_2 != 0)
		{
			result = array[num];
			if (bool_0)
			{
				array[num] = default(T);
			}
			method_1(ref int_0);
			int_2--;
			int_3++;
			return true;
		}
		result = default(T);
		return false;
	}

	public T Peek()
	{
		if (int_2 == 0)
		{
			method_2();
		}
		return gparam_0[int_0];
	}

	public bool TryPeek(out T result)
	{
		if (int_2 != 0)
		{
			result = gparam_0[int_0];
			return true;
		}
		result = default(T);
		return false;
	}

	public bool Contains(T item)
	{
		if (int_2 == 0)
		{
			return false;
		}
		if (int_0 < int_1)
		{
			return Array.IndexOf(gparam_0, item, int_0, int_2) >= 0;
		}
		if (Array.IndexOf(gparam_0, item, int_0, gparam_0.Length - int_0) < 0)
		{
			return Array.IndexOf(gparam_0, item, 0, int_1) >= 0;
		}
		return true;
	}

	public int RemoveWhere(Func<T, bool> match)
	{
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
		}
		if (int_2 != 0)
		{
			T[] array = arrayPool_0.Rent(int_2);
			int num = 0;
			if (int_0 < int_1)
			{
				int num2 = 0;
				for (int i = int_0; i < int_2; i++)
				{
					if (match(gparam_0[i]))
					{
						num++;
					}
					else
					{
						array[num2++] = gparam_0[i];
					}
				}
			}
			else
			{
				int num3 = 0;
				for (int j = int_0; j < gparam_0.Length - int_0; j++)
				{
					if (!match(gparam_0[j]))
					{
						array[num3++] = gparam_0[j];
					}
					else
					{
						num++;
					}
				}
				for (int k = 0; k < int_1; k++)
				{
					if (match(gparam_0[k]))
					{
						num++;
					}
					else
					{
						array[num3++] = gparam_0[k];
					}
				}
			}
			method_3(array);
			int_2 -= num;
			int_1 = 0;
			int_0 = 0;
			if (int_2 != gparam_0.Length)
			{
				int_1 = int_2;
			}
			int_3++;
			return num;
		}
		return 0;
	}

	public T[] ToArray()
	{
		if (int_2 != 0)
		{
			T[] array = new T[int_2];
			if (int_0 < int_1)
			{
				Array.Copy(gparam_0, int_0, array, 0, int_2);
			}
			else
			{
				Array.Copy(gparam_0, int_0, array, 0, gparam_0.Length - int_0);
				Array.Copy(gparam_0, 0, array, gparam_0.Length - int_0, int_1);
			}
			return array;
		}
		return Array.Empty<T>();
	}

	private void method_0(int int_4)
	{
		T[] array = arrayPool_0.Rent(int_4);
		if (int_2 > 0)
		{
			if (int_0 >= int_1)
			{
				Array.Copy(gparam_0, int_0, array, 0, gparam_0.Length - int_0);
				Array.Copy(gparam_0, 0, array, gparam_0.Length - int_0, int_1);
			}
			else
			{
				Array.Copy(gparam_0, int_0, array, 0, int_2);
			}
		}
		method_3(array);
		int_0 = 0;
		int_1 = ((int_2 != array.Length) ? int_2 : 0);
		int_3++;
	}

	private void method_1(ref int int_4)
	{
		int num = int_4 + 1;
		if (num == gparam_0.Length)
		{
			num = 0;
		}
		int_4 = num;
	}

	private void method_2()
	{
		throw new InvalidOperationException("Queue is empty.");
	}

	public void TrimExcess()
	{
		int num = (int)((double)gparam_0.Length * 0.9);
		if (int_2 < num)
		{
			method_0(int_2);
		}
	}

	private void method_3(T[] gparam_1)
	{
		if (gparam_0.Length != 0)
		{
			try
			{
				arrayPool_0.Return(gparam_0, bool_0);
			}
			catch (ArgumentException)
			{
			}
		}
		gparam_0 = gparam_1;
	}

	private static bool smethod_0(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	public void Dispose()
	{
		method_3(Array.Empty<T>());
		int_2 = 0;
		int_1 = 0;
		int_0 = 0;
		int_3++;
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		arrayPool_0 = ArrayPool<T>.Shared;
	}

	static PooledQueue()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_1()
	{
		return object_1 == null;
	}

	internal static object smethod_2()
	{
		return object_1;
	}
}
