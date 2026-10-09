using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

namespace Collections.Pooled;

[Serializable]
[DebuggerTypeProxy(typeof(Class68<>))]
[DebuggerDisplay("Count = {Count}")]
public class PooledList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, GInterface11<T>, IReadOnlyList<T>, IReadOnlyCollection<T>, IList, ICollection, IDisposable, IDeserializationCallback
{
	public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private readonly PooledList<T> pooledList_0;

		private int int_0;

		private readonly int int_1;

		private T gparam_0;

		public T Current => gparam_0;

		object IEnumerator.Current
		{
			get
			{
				if (int_0 == 0 || int_0 == pooledList_0.int_0 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return Current;
			}
		}

		internal Enumerator(PooledList<T> list)
		{
			pooledList_0 = list;
			int_0 = 0;
			int_1 = list.int_1;
			gparam_0 = default(T);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			PooledList<T> pooledList = pooledList_0;
			if (int_1 == pooledList.int_1 && (uint)int_0 < (uint)pooledList.int_0)
			{
				gparam_0 = pooledList.gparam_1[int_0];
				int_0++;
				return true;
			}
			return method_0();
		}

		private bool method_0()
		{
			if (int_1 != pooledList_0.int_1)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			int_0 = pooledList_0.int_0 + 1;
			gparam_0 = default(T);
			return false;
		}

		void IEnumerator.Reset()
		{
			if (int_1 != pooledList_0.int_1)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			int_0 = 0;
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

	private readonly struct Struct53 : IComparer<T>
	{
		private readonly Func<T, T, int> func_0;

		public Struct53(Func<T, T, int> func_1)
		{
			func_0 = func_1;
		}

		public int Compare(T x, T y)
		{
			return func_0(x, y);
		}

		static Struct53()
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

	private static readonly T[] gparam_0;

	[NonSerialized]
	private ArrayPool<T> arrayPool_0;

	[NonSerialized]
	private object object_0;

	private T[] gparam_1;

	private int int_0;

	private int int_1;

	private readonly bool bool_0;

	internal static object object_1;

	public Span<T> Span => MemoryExtensions.AsSpan(gparam_1, 0, int_0);

	ReadOnlySpan<T> GInterface11<T>.Span => Span;

	public int Capacity
	{
		get
		{
			return gparam_1.Length;
		}
		set
		{
			if (value < int_0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
			}
			if (value == gparam_1.Length)
			{
				return;
			}
			if (value > 0)
			{
				T[] destinationArray = arrayPool_0.Rent(value);
				if (int_0 > 0)
				{
					Array.Copy(gparam_1, destinationArray, int_0);
				}
				method_3();
				gparam_1 = destinationArray;
			}
			else
			{
				method_3();
				int_0 = 0;
			}
		}
	}

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

	bool IList.IsFixedSize => false;

	bool ICollection<T>.IsReadOnly => false;

	bool IList.IsReadOnly => false;

	int ICollection.Count => int_0;

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

	public T this[int index]
	{
		get
		{
			if ((uint)index >= (uint)int_0)
			{
				ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			return gparam_1[index];
		}
		set
		{
			if ((uint)index >= (uint)int_0)
			{
				ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			gparam_1[index] = value;
			int_1++;
		}
	}

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(value, ExceptionArgument.value);
			try
			{
				this[index] = (T)value;
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(T));
			}
		}
	}

	public PooledList()
		: this(ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledList(ClearMode clearMode)
		: this(clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledList(ArrayPool<T> customPool)
		: this(ClearMode.Auto, customPool)
	{
	}

	public PooledList(ClearMode clearMode, ArrayPool<T> customPool)
	{
		gparam_1 = gparam_0;
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_1(clearMode);
	}

	public PooledList(int capacity)
		: this(capacity, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledList(int capacity, bool sizeToCapacity)
		: this(capacity, ClearMode.Auto, ArrayPool<T>.Shared, sizeToCapacity)
	{
	}

	public PooledList(int capacity, ClearMode clearMode)
		: this(capacity, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledList(int capacity, ClearMode clearMode, bool sizeToCapacity)
		: this(capacity, clearMode, ArrayPool<T>.Shared, sizeToCapacity)
	{
	}

	public PooledList(int capacity, ArrayPool<T> customPool)
		: this(capacity, ClearMode.Auto, customPool)
	{
	}

	public PooledList(int capacity, ArrayPool<T> customPool, bool sizeToCapacity)
		: this(capacity, ClearMode.Auto, customPool, sizeToCapacity)
	{
	}

	public PooledList(int capacity, ClearMode clearMode, ArrayPool<T> customPool)
		: this(capacity, clearMode, customPool, sizeToCapacity: false)
	{
	}

	public PooledList(int capacity, ClearMode clearMode, ArrayPool<T> customPool, bool sizeToCapacity)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_1(clearMode);
		if (capacity == 0)
		{
			gparam_1 = gparam_0;
		}
		else
		{
			gparam_1 = arrayPool_0.Rent(capacity);
		}
		if (sizeToCapacity)
		{
			int_0 = capacity;
			if (clearMode != ClearMode.Never)
			{
				Array.Clear(gparam_1, 0, int_0);
			}
		}
	}

	public PooledList(T[] array)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledList(T[] array, ClearMode clearMode)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledList(T[] array, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, customPool)
	{
	}

	public PooledList(T[] array, ClearMode clearMode, ArrayPool<T> customPool)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, customPool)
	{
	}

	public PooledList(ReadOnlySpan<T> span)
		: this(span, ClearMode.Auto, ArrayPool<T>.Shared)
	{
	}

	public PooledList(ReadOnlySpan<T> span, ClearMode clearMode)
		: this(span, clearMode, ArrayPool<T>.Shared)
	{
	}

	public PooledList(ReadOnlySpan<T> span, ArrayPool<T> customPool)
		: this(span, ClearMode.Auto, customPool)
	{
	}

	public PooledList(ReadOnlySpan<T> span, ClearMode clearMode, ArrayPool<T> customPool)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_1(clearMode);
		int length = span.Length;
		if (length != 0)
		{
			gparam_1 = arrayPool_0.Rent(length);
			span.CopyTo(gparam_1);
			int_0 = length;
		}
		else
		{
			gparam_1 = gparam_0;
		}
	}

	public PooledList(IEnumerable<T> collection)
		: this(collection, ClearMode.Auto, ArrayPool<T>.Shared, 0)
	{
	}

	public PooledList(IEnumerable<T> collection, int suggestCapacity)
		: this(collection, ClearMode.Auto, ArrayPool<T>.Shared, suggestCapacity)
	{
	}

	public PooledList(IEnumerable<T> collection, ClearMode clearMode)
		: this(collection, clearMode, ArrayPool<T>.Shared, 0)
	{
	}

	public PooledList(IEnumerable<T> collection, ArrayPool<T> customPool)
		: this(collection, ClearMode.Auto, customPool, 0)
	{
	}

	public PooledList(IEnumerable<T> collection, ClearMode clearMode, ArrayPool<T> customPool, int suggestCapacity = 0)
	{
		arrayPool_0 = customPool ?? ArrayPool<T>.Shared;
		bool_0 = smethod_1(clearMode);
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		else if (!(collection is ICollection<T> { Count: var count } collection2))
		{
			if (!(collection is ICollection { Count: var count2 } collection3))
			{
				if (!(collection is IReadOnlyCollection<T> { Count: var count3 } readOnlyCollection))
				{
					if (suggestCapacity < 0)
					{
						ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
					}
					if (suggestCapacity != 0)
					{
						gparam_1 = arrayPool_0.Rent(suggestCapacity);
					}
					else
					{
						gparam_1 = gparam_0;
					}
					{
						foreach (T item in collection)
						{
							Add(item);
						}
						return;
					}
				}
				if (count3 != 0)
				{
					gparam_1 = arrayPool_0.Rent(count3);
					int_0 = 0;
					{
						foreach (T item2 in readOnlyCollection)
						{
							Add(item2);
						}
						return;
					}
				}
				gparam_1 = gparam_0;
			}
			else if (count2 != 0)
			{
				gparam_1 = arrayPool_0.Rent(count2);
				collection3.CopyTo(gparam_1, 0);
				int_0 = count2;
			}
			else
			{
				gparam_1 = gparam_0;
			}
		}
		else if (count == 0)
		{
			gparam_1 = gparam_0;
		}
		else
		{
			gparam_1 = arrayPool_0.Rent(count);
			collection2.CopyTo(gparam_1, 0);
			int_0 = count;
		}
	}

	private static bool smethod_0(object object_2)
	{
		if (!(object_2 is T))
		{
			if (object_2 != null)
			{
				return false;
			}
			return default(T) == null;
		}
		return true;
	}

	public T[] InternalArray()
	{
		return gparam_1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Add(T item)
	{
		int_1++;
		int num = int_0;
		if ((uint)num < (uint)gparam_1.Length)
		{
			int_0 = num + 1;
			gparam_1[num] = item;
		}
		else
		{
			method_0(item);
		}
	}

	private void method_0(T gparam_2)
	{
		int num = int_0;
		method_1(num + 1);
		int_0 = num + 1;
		gparam_1[num] = gparam_2;
	}

	int IList.Add(object item)
	{
		ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item);
		try
		{
			Add((T)item);
		}
		catch (InvalidCastException)
		{
			ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
		}
		return Count - 1;
	}

	public void AddRange(IEnumerable<T> collection)
	{
		InsertRange(int_0, collection);
	}

	public void AddRange(T[] array)
	{
		AddRange(MemoryExtensions.AsSpan(array));
	}

	public void AddRange(ReadOnlySpan<T> span)
	{
		Span<T> destination = method_2(int_0, span.Length, bool_1: false);
		span.CopyTo(destination);
	}

	public Span<T> AddSpan(int count)
	{
		return InsertSpan(int_0, count);
	}

	public ReadOnlyCollection<T> AsReadOnly()
	{
		return new ReadOnlyCollection<T>(this);
	}

	public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
	{
		if (index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 - index < count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		return Array.BinarySearch(gparam_1, index, count, item, comparer);
	}

	public int BinarySearch(T item)
	{
		return BinarySearch(0, Count, item, null);
	}

	public int BinarySearch(T item, IComparer<T> comparer)
	{
		return BinarySearch(0, Count, item, comparer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear()
	{
		int_1++;
		int num = int_0;
		int_0 = 0;
		if (num > 0 && bool_0)
		{
			Array.Clear(gparam_1, 0, num);
		}
	}

	public bool Contains(T item)
	{
		if (int_0 != 0)
		{
			return IndexOf(item) != -1;
		}
		return false;
	}

	bool IList.Contains(object item)
	{
		if (smethod_0(item))
		{
			return Contains((T)item);
		}
		return false;
	}

	public PooledList<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter)
	{
		if (converter == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.converter);
		}
		PooledList<TOutput> pooledList = new PooledList<TOutput>(int_0);
		for (int i = 0; i < int_0; i++)
		{
			pooledList.gparam_1[i] = converter(gparam_1[i]);
		}
		pooledList.int_0 = int_0;
		return pooledList;
	}

	public void CopyTo(Span<T> span)
	{
		if (span.Length < Count)
		{
			throw new ArgumentException("Destination span is shorter than the list to be copied.");
		}
		Span.CopyTo(span);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		Array.Copy(gparam_1, 0, array, arrayIndex, int_0);
	}

	void ICollection.CopyTo(Array array, int arrayIndex)
	{
		if (array != null && array.Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
		}
		try
		{
			Array.Copy(gparam_1, 0, array, arrayIndex, int_0);
		}
		catch (ArrayTypeMismatchException)
		{
			ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
		}
	}

	private void method_1(int int_2)
	{
		if (gparam_1.Length < int_2)
		{
			int num = ((gparam_1.Length == 0) ? 4 : (gparam_1.Length * 2));
			if ((uint)num > 2146435071u)
			{
				num = 2146435071;
			}
			if (num < int_2)
			{
				num = int_2;
			}
			Capacity = num;
		}
	}

	public bool Exists(Func<T, bool> match)
	{
		return FindIndex(match) != -1;
	}

	public bool TryFind(Func<T, bool> match, out T result)
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
		for (int i = num; i < int_0; i++)
		{
			if (match(gparam_1[i]))
			{
				result = gparam_1[i];
				return true;
			}
		}
		result = default(T);
		return false;
	}

	public PooledList<T> FindAll(Func<T, bool> match)
	{
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
		}
		PooledList<T> pooledList = new PooledList<T>();
		for (int i = 0; i < int_0; i++)
		{
			if (match(gparam_1[i]))
			{
				pooledList.Add(gparam_1[i]);
			}
		}
		return pooledList;
	}

	public int FindIndex(Func<T, bool> match)
	{
		return FindIndex(0, int_0, match);
	}

	public int FindIndex(int startIndex, Func<T, bool> match)
	{
		return FindIndex(startIndex, int_0 - startIndex, match);
	}

	public int FindIndex(int startIndex, int count, Func<T, bool> match)
	{
		if ((uint)startIndex > (uint)int_0)
		{
			ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
		}
		if (count < 0 || startIndex > int_0 - count)
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
		}
		int num = startIndex + count;
		int num2 = startIndex;
		while (true)
		{
			if (num2 < num)
			{
				if (match(gparam_1[num2]))
				{
					break;
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num2;
	}

	public bool TryFindLast(Func<T, bool> match, out T result)
	{
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
		}
		int num = int_0 - 1;
		while (num >= 0)
		{
			if (!match(gparam_1[num]))
			{
				num--;
				continue;
			}
			result = gparam_1[num];
			return true;
		}
		result = default(T);
		return false;
	}

	public int FindLastIndex(Func<T, bool> match)
	{
		return FindLastIndex(int_0 - 1, int_0, match);
	}

	public int FindLastIndex(int startIndex, Func<T, bool> match)
	{
		return FindLastIndex(startIndex, startIndex + 1, match);
	}

	public int FindLastIndex(int startIndex, int count, Func<T, bool> match)
	{
		if (match == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
		}
		if (int_0 == 0)
		{
			if (startIndex != -1)
			{
				ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
			}
		}
		else if ((uint)startIndex >= (uint)int_0)
		{
			ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
		}
		if (count < 0 || startIndex - count + 1 < 0)
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		int num = startIndex - count;
		int num2 = startIndex;
		while (num2 > num)
		{
			if (!match(gparam_1[num2]))
			{
				num2--;
				continue;
			}
			return num2;
		}
		return -1;
	}

	public void ForEach(Action<T> action)
	{
		if (action == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.action);
		}
		int num = int_1;
		for (int i = 0; i < int_0; i++)
		{
			if (num != int_1)
			{
				break;
			}
			action(gparam_1[i]);
		}
		if (num != int_1)
		{
			ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
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

	public Span<T> GetRange(int index, int count)
	{
		if (index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 - index < count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		return Span.Slice(index, count);
	}

	public int IndexOf(T item)
	{
		return Array.IndexOf(gparam_1, item, 0, int_0);
	}

	int IList.IndexOf(object item)
	{
		if (!smethod_0(item))
		{
			return -1;
		}
		return IndexOf((T)item);
	}

	public int IndexOf(T item, int index)
	{
		if (index > int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		return Array.IndexOf(gparam_1, item, index, int_0 - index);
	}

	public int IndexOf(T item, int index, int count)
	{
		if (index > int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		if (count < 0 || index > int_0 - count)
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		return Array.IndexOf(gparam_1, item, index, count);
	}

	public void Insert(int index, T item)
	{
		if ((uint)index > (uint)int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_ListInsert);
		}
		if (int_0 == gparam_1.Length)
		{
			method_1(int_0 + 1);
		}
		if (index < int_0)
		{
			Array.Copy(gparam_1, index, gparam_1, index + 1, int_0 - index);
		}
		gparam_1[index] = item;
		int_0++;
		int_1++;
	}

	void IList.Insert(int index, object item)
	{
		ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item);
		try
		{
			Insert(index, (T)item);
		}
		catch (InvalidCastException)
		{
			ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
		}
	}

	public void InsertRange(int index, IEnumerable<T> collection)
	{
		if ((uint)index > (uint)int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		else if (collection is ICollection<T> { Count: var count } collection2)
		{
			if (count > 0)
			{
				method_1(int_0 + count);
				if (index < int_0)
				{
					Array.Copy(gparam_1, index, gparam_1, index + count, int_0 - index);
				}
				if (this == collection2)
				{
					Array.Copy(gparam_1, 0, gparam_1, index, index);
					Array.Copy(gparam_1, index + count, gparam_1, index * 2, int_0 - index);
				}
				else
				{
					collection2.CopyTo(gparam_1, index);
				}
				int_0 += count;
			}
		}
		else
		{
			using IEnumerator<T> enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Insert(index++, enumerator.Current);
			}
		}
		int_1++;
	}

	public void InsertRange(int index, ReadOnlySpan<T> span)
	{
		Span<T> destination = method_2(index, span.Length, bool_1: false);
		span.CopyTo(destination);
	}

	public void InsertRange(int index, T[] array)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		InsertRange(index, MemoryExtensions.AsSpan(array));
	}

	public Span<T> InsertSpan(int index, int count)
	{
		return method_2(index, count, bool_1: true);
	}

	private Span<T> method_2(int int_2, int int_3, bool bool_1)
	{
		method_1(int_0 + int_3);
		if (int_2 < int_0)
		{
			Array.Copy(gparam_1, int_2, gparam_1, int_2 + int_3, int_0 - int_2);
		}
		int_0 += int_3;
		int_1++;
		Span<T> result = MemoryExtensions.AsSpan(gparam_1, int_2, int_3);
		if (bool_1 && bool_0)
		{
			result.Clear();
		}
		return result;
	}

	public int LastIndexOf(T item)
	{
		if (int_0 == 0)
		{
			return -1;
		}
		return LastIndexOf(item, int_0 - 1, int_0);
	}

	public int LastIndexOf(T item, int index)
	{
		if (index >= int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		return LastIndexOf(item, index, index + 1);
	}

	public int LastIndexOf(T item, int index, int count)
	{
		if (Count != 0 && index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (Count != 0 && count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 == 0)
		{
			return -1;
		}
		if (index >= int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
		}
		if (count > index + 1)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
		}
		return Array.LastIndexOf(gparam_1, item, index, count);
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			RemoveAt(num);
			return true;
		}
		return false;
	}

	void IList.Remove(object item)
	{
		if (smethod_0(item))
		{
			Remove((T)item);
		}
	}

	public int RemoveAll(Func<T, bool> match)
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
		for (i = num; i < int_0 && !match(gparam_1[i]); i++)
		{
		}
		if (i >= int_0)
		{
			return 0;
		}
		int j = i + 1;
		while (j < int_0)
		{
			for (; j < int_0 && match(gparam_1[j]); j++)
			{
			}
			if (j < int_0)
			{
				gparam_1[i++] = gparam_1[j++];
			}
		}
		if (bool_0)
		{
			Array.Clear(gparam_1, i, int_0 - i);
		}
		int result = int_0 - i;
		int_0 = i;
		int_1++;
		return result;
	}

	public void RemoveAt(int index)
	{
		if ((uint)index >= (uint)int_0)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		int_0--;
		if (index < int_0)
		{
			Array.Copy(gparam_1, index + 1, gparam_1, index, int_0 - index);
		}
		int_1++;
		if (bool_0)
		{
			gparam_1[int_0] = default(T);
		}
	}

	public void RemoveRange(int index, int count)
	{
		if (index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 - index < count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (count > 0)
		{
			int_0 -= count;
			if (index < int_0)
			{
				Array.Copy(gparam_1, index + count, gparam_1, index, int_0 - index);
			}
			int_1++;
			if (bool_0)
			{
				Array.Clear(gparam_1, int_0, count);
			}
		}
	}

	public void Reverse()
	{
		Reverse(0, int_0);
	}

	public void Reverse(int index, int count)
	{
		if (index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 - index < count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (count > 1)
		{
			Array.Reverse((Array)gparam_1, index, count);
		}
		int_1++;
	}

	public void Sort()
	{
		Sort(0, Count, null);
	}

	public void Sort(IComparer<T> comparer)
	{
		Sort(0, Count, comparer);
	}

	public void Sort(int index, int count, IComparer<T> comparer)
	{
		if (index < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (int_0 - index < count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (count > 1)
		{
			Array.Sort(gparam_1, index, count, comparer);
		}
		int_1++;
	}

	public void Sort(Func<T, T, int> comparison)
	{
		if (comparison == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.comparison);
		}
		if (int_0 > 1)
		{
			Array.Sort(gparam_1, 0, int_0, new Struct53(comparison));
		}
		int_1++;
	}

	public T[] ToArray()
	{
		if (int_0 == 0)
		{
			return gparam_0;
		}
		return Span.ToArray();
	}

	public void TrimExcess()
	{
		int num = (int)((double)gparam_1.Length * 0.9);
		if (int_0 < num)
		{
			Capacity = int_0;
		}
	}

	public bool TrueForAll(Func<T, bool> match)
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
		for (int i = num; i < int_0; i++)
		{
			if (!match(gparam_1[i]))
			{
				return false;
			}
		}
		return true;
	}

	private void method_3()
	{
		if (gparam_1.Length != 0)
		{
			try
			{
				arrayPool_0.Return(gparam_1, bool_0);
			}
			catch (ArgumentException)
			{
			}
			gparam_1 = gparam_0;
		}
	}

	private static bool smethod_1(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	public void Dispose()
	{
		method_3();
		int_0 = 0;
		int_1++;
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		arrayPool_0 = ArrayPool<T>.Shared;
	}

	public T? Find(Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		int num = 0;
		while (true)
		{
			if (num < int_0)
			{
				if (match(gparam_1[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return default(T);
		}
		return gparam_1[num];
	}

	static PooledList()
	{
		Class72.smethod_20();
		gparam_0 = Array.Empty<T>();
	}

	internal static bool smethod_2()
	{
		return object_1 == null;
	}

	internal static object smethod_3()
	{
		return object_1;
	}
}
