using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace Collections.Pooled;

[Serializable]
[DebuggerTypeProxy(typeof(StackDebugView<>))]
[DebuggerDisplay("Count = {Count}")]
public class PooledStack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, IDisposable, IDeserializationCallback
{
	public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private readonly PooledStack<T> pooledStack_0;

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

		internal Enumerator(PooledStack<T> stack)
		{
			pooledStack_0 = stack;
			int_0 = stack.int_1;
			int_1 = -2;
			gparam_0 = default(T);
		}

		public void Dispose()
		{
			int_1 = -1;
		}

		public bool MoveNext()
		{
			if (int_0 != pooledStack_0.int_1)
			{
				throw new InvalidOperationException("Collection was modified during enumeration.");
			}
			if (int_1 == -2)
			{
				int_1 = pooledStack_0.int_0 - 1;
				bool num = int_1 >= 0;
				if (num)
				{
					gparam_0 = pooledStack_0.gparam_0[int_1];
				}
				return num;
			}
			if (int_1 == -1)
			{
				return false;
			}
			bool num2 = --int_1 >= 0;
			if (!num2)
			{
				gparam_0 = default(T);
				return num2;
			}
			gparam_0 = pooledStack_0.gparam_0[int_1];
			return num2;
		}

		private void method_0()
		{
			throw new InvalidOperationException((int_1 == -2) ? "Enumeration was not started." : "Enumeration has ended.");
		}

		void IEnumerator.Reset()
		{
			if (int_0 != pooledStack_0.int_1)
			{
				throw new InvalidOperationException("Collection was modified during enumeration.");
			}
			int_1 = -2;
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

	private readonly bool bool_0;

	private static object object_1;

	public int Count => int_0;

	public ClearMode ClearMode
	{
		get
		{
			if (!bool_0)
			{
				return ClearMode.Never;
			}
			return ClearMode.Always;
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

	public PooledStack()
		: this(ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(ClearMode clearMode)
		: this(clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(ArrayPool<T> customPool)
		: this(ClearMode.Auto, customPool)
	{
	}

	public PooledStack(ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		gparam_0 = Array.Empty<T>();
		bool_0 = smethod_0(clearMode);
	}

	public PooledStack(int capacity)
		: this(capacity, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(int capacity, ClearMode clearMode)
		: this(capacity, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(int capacity, ArrayPool<T> customPool)
		: this(capacity, ClearMode.Auto, customPool)
	{
	}

	public PooledStack(int capacity, ClearMode clearMode, ArrayPool<T> customPool)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		gparam_0 = arrayPool_0.Rent(capacity);
		bool_0 = smethod_0(clearMode);
	}

	public PooledStack(IEnumerable<T> enumerable)
		: this(enumerable, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(IEnumerable<T> enumerable, ClearMode clearMode)
		: this(enumerable, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(IEnumerable<T> enumerable, ArrayPool<T> customPool)
		: this(enumerable, ClearMode.Auto, customPool)
	{
	}

	public PooledStack(IEnumerable<T> enumerable, ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_0(clearMode);
		if (enumerable != null)
		{
			if (!(enumerable is ICollection<T> collection))
			{
				using (PooledList<T> pooledList = new PooledList<T>(enumerable))
				{
					gparam_0 = arrayPool_0.Rent(pooledList.Count);
					pooledList.Span.CopyTo(gparam_0);
					int_0 = pooledList.Count;
					return;
				}
			}
			if (collection.Count != 0)
			{
				gparam_0 = arrayPool_0.Rent(collection.Count);
				collection.CopyTo(gparam_0, 0);
				int_0 = collection.Count;
			}
			else
			{
				gparam_0 = Array.Empty<T>();
			}
		}
		else
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.enumerable);
		}
	}

	public PooledStack(T[] array)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(T[] array, ClearMode clearMode)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(T[] array, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, customPool)
	{
	}

	public PooledStack(T[] array, ClearMode clearMode, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, customPool)
	{
	}

	public PooledStack(ReadOnlySpan<T> span)
		: this(span, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(ReadOnlySpan<T> span, ClearMode clearMode)
		: this(span, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledStack(ReadOnlySpan<T> span, ArrayPool<T> customPool)
		: this(span, ClearMode.Auto, customPool)
	{
	}

	public PooledStack(ReadOnlySpan<T> span, ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_0(clearMode);
		gparam_0 = arrayPool_0.Rent(span.Length);
		span.CopyTo(gparam_0);
		int_0 = span.Length;
	}

	public void Clear()
	{
		if (bool_0)
		{
			Array.Clear(gparam_0, 0, int_0);
		}
		int_0 = 0;
		int_1++;
	}

	public bool Contains(T item)
	{
		if (int_0 != 0)
		{
			return Array.LastIndexOf(gparam_0, item, int_0 - 1) != -1;
		}
		return false;
	}

	public int RemoveWhere(Func<T, bool> match)
	{
		int num;
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
			num = 0;
		}
		else
		{
			num = 0;
		}
		int i;
		for (i = num; i < int_0 && !match(gparam_0[i]); i++)
		{
		}
		if (i < int_0)
		{
			int j = i + 1;
			while (j < int_0)
			{
				for (; j < int_0 && match(gparam_0[j]); j++)
				{
				}
				if (j < int_0)
				{
					gparam_0[i++] = gparam_0[j++];
				}
			}
			if (bool_0)
			{
				Array.Clear(gparam_0, i, int_0 - i);
			}
			int result = int_0 - i;
			int_0 = i;
			int_1++;
			return result;
		}
		return 0;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		int argument;
		if (arrayIndex < 0)
		{
			argument = 58;
		}
		else
		{
			if (arrayIndex <= array.Length)
			{
				goto IL_001e;
			}
			argument = 58;
		}
		ThrowHelper.ThrowArgumentOutOfRangeException((ExceptionArgument)argument);
		goto IL_001e;
		IL_001e:
		int num;
		if (array.Length - arrayIndex < int_0)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			num = 0;
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		int num3 = arrayIndex + int_0;
		while (num2 < int_0)
		{
			array[--num3] = gparam_0[num2++];
		}
	}

	public void CopyTo(Span<T> span)
	{
		int num;
		if (span.Length >= int_0)
		{
			num = 0;
		}
		else
		{
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
			num = 0;
		}
		int num2 = num;
		int num3 = int_0;
		while (num2 < int_0)
		{
			span[--num3] = gparam_0[num2++];
		}
	}

	void ICollection.CopyTo(Array array, int arrayIndex)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (array.Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
		}
		if (array.GetLowerBound(0) != 0)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound, ExceptionArgument.array);
		}
		int argument;
		if (arrayIndex < 0)
		{
			argument = 58;
		}
		else
		{
			if (arrayIndex <= array.Length)
			{
				goto IL_0040;
			}
			argument = 58;
		}
		ThrowHelper.ThrowArgumentOutOfRangeException((ExceptionArgument)argument);
		goto IL_0040;
		IL_0040:
		if (array.Length - arrayIndex < int_0)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		try
		{
			Array.Copy(gparam_0, 0, array, arrayIndex, int_0);
			Array.Reverse(array, arrayIndex, int_0);
		}
		catch (ArrayTypeMismatchException)
		{
			ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
		}
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

	public void TrimExcess()
	{
		if (int_0 == 0)
		{
			method_2(Array.Empty<T>());
			int_1++;
			return;
		}
		int num = (int)((double)gparam_0.Length * 0.9);
		if (int_0 < num)
		{
			T[] array = arrayPool_0.Rent(int_0);
			if (array.Length < gparam_0.Length)
			{
				Array.Copy(gparam_0, array, int_0);
				method_2(array);
				int_1++;
			}
			else
			{
				arrayPool_0.Return(array);
			}
		}
	}

	public T Peek()
	{
		int num = int_0 - 1;
		T[] array = gparam_0;
		if ((uint)num >= (uint)array.Length)
		{
			method_1();
		}
		return array[num];
	}

	public bool TryPeek(out T result)
	{
		int num = int_0 - 1;
		T[] array = gparam_0;
		if ((uint)num >= (uint)array.Length)
		{
			result = default(T);
			return false;
		}
		result = array[num];
		return true;
	}

	public T Pop()
	{
		int num = int_0 - 1;
		T[] array = gparam_0;
		if ((uint)num >= (uint)array.Length)
		{
			method_1();
		}
		int_1++;
		int_0 = num;
		T result = array[num];
		if (bool_0)
		{
			array[num] = default(T);
		}
		return result;
	}

	public bool TryPop(out T result)
	{
		int num = int_0 - 1;
		T[] array = gparam_0;
		if ((uint)num >= (uint)array.Length)
		{
			result = default(T);
			return false;
		}
		int_1++;
		int_0 = num;
		result = array[num];
		int result2;
		if (!bool_0)
		{
			result2 = 1;
		}
		else
		{
			array[num] = default(T);
			result2 = 1;
		}
		return (byte)result2 != 0;
	}

	public void Push(T item)
	{
		int num = int_0;
		T[] array = gparam_0;
		if ((uint)num < (uint)array.Length)
		{
			array[num] = item;
			int_1++;
			int_0 = num + 1;
		}
		else
		{
			method_0(item);
		}
	}

	private void method_0(T gparam_1)
	{
		T[] array = arrayPool_0.Rent((gparam_0.Length == 0) ? 4 : (2 * gparam_0.Length));
		Array.Copy(gparam_0, array, int_0);
		method_2(array);
		gparam_0[int_0] = gparam_1;
		int_1++;
		int_0++;
	}

	public T[] ToArray()
	{
		if (int_0 != 0)
		{
			T[] array = new T[int_0];
			for (int i = 0; i < int_0; i++)
			{
				array[i] = gparam_0[int_0 - i - 1];
			}
			return array;
		}
		return Array.Empty<T>();
	}

	private void method_1()
	{
		throw new InvalidOperationException("Stack was empty.");
	}

	private void method_2(T[] gparam_1 = null)
	{
		T[] array = gparam_0;
		if (array != null && array.Length != 0)
		{
			try
			{
				arrayPool_0.Return(gparam_0, bool_0);
			}
			catch (ArgumentException)
			{
			}
		}
		if (gparam_1 != null)
		{
			gparam_0 = gparam_1;
		}
	}

	private static bool smethod_0(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	public void Dispose()
	{
		method_2(Array.Empty<T>());
		int_0 = 0;
		int_1++;
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		arrayPool_0 = ArrayPool<T>.Shared;
	}

	static PooledStack()
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
