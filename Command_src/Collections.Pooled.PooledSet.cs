using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Collections.Pooled;

[Serializable]
[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(Class68<>))]
public class PooledSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ISet<T>, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback, IDisposable
{
	internal struct ElementCount
	{
		internal int uniqueCount;

		internal int unfoundCount;
	}

	internal struct Slot
	{
		internal int hashCode;

		internal int next;

		internal T value;
	}

	public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private readonly PooledSet<T> pooledSet_0;

		private int int_0;

		private readonly int int_1;

		private T gparam_0;

		public T Current => gparam_0;

		object IEnumerator.Current
		{
			get
			{
				if (int_0 == 0 || int_0 == pooledSet_0.int_3 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return Current;
			}
		}

		internal Enumerator(PooledSet<T> set)
		{
			pooledSet_0 = set;
			int_0 = 0;
			int_1 = set.int_5;
			gparam_0 = default(T);
		}

		void IDisposable.Dispose()
		{
		}

		public bool MoveNext()
		{
			if (int_1 != pooledSet_0.int_5)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			while (true)
			{
				if (int_0 < pooledSet_0.int_3)
				{
					if (pooledSet_0.slot_0[int_0].hashCode >= 0)
					{
						break;
					}
					int_0++;
					continue;
				}
				int_0 = pooledSet_0.int_3 + 1;
				gparam_0 = default(T);
				return false;
			}
			gparam_0 = pooledSet_0.slot_0[int_0].value;
			int_0++;
			return true;
		}

		void IEnumerator.Reset()
		{
			if (int_1 != pooledSet_0.int_5)
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

	private static readonly ArrayPool<int> arrayPool_0;

	private static readonly ArrayPool<Slot> arrayPool_1;

	private int[] int_0;

	private Slot[] slot_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private IEqualityComparer<T> iequalityComparer_0;

	private int int_5;

	private readonly bool bool_0;

	private SerializationInfo serializationInfo_0;

	internal static object object_0;

	public int Count => int_2;

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

	bool ICollection<T>.IsReadOnly => false;

	public IEqualityComparer<T> Comparer => iequalityComparer_0;

	public PooledSet()
		: this(ClearMode.Auto, (IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public PooledSet(ClearMode clearMode)
		: this(clearMode, (IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public PooledSet(IEqualityComparer<T> comparer)
		: this(ClearMode.Auto, comparer)
	{
	}

	public PooledSet(ClearMode clearMode, IEqualityComparer<T> comparer)
	{
		iequalityComparer_0 = comparer ?? EqualityComparer<T>.Default;
		int_3 = 0;
		int_2 = 0;
		int_4 = -1;
		int_5 = 0;
		int_1 = 0;
		bool_0 = smethod_0(clearMode);
	}

	public PooledSet(int capacity)
		: this(capacity, ClearMode.Auto, (IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public PooledSet(int capacity, ClearMode clearMode)
		: this(capacity, clearMode, (IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public PooledSet(int capacity, IEqualityComparer<T> comparer)
		: this(capacity, ClearMode.Auto, comparer)
	{
	}

	public PooledSet(int capacity, ClearMode clearMode, IEqualityComparer<T> comparer)
		: this(clearMode, comparer)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (capacity > 0)
		{
			method_1(capacity);
		}
	}

	public PooledSet(IEnumerable<T> collection)
		: this(collection, ClearMode.Auto, (!(collection is PooledSet<T> pooledSet)) ? ((collection is HashSet<T> hashSet) ? hashSet.Comparer : EqualityComparer<T>.Default) : pooledSet.Comparer)
	{
	}

	public PooledSet(IEnumerable<T> collection, ClearMode clearMode)
		: this(collection, clearMode, (!(collection is PooledSet<T> pooledSet)) ? ((collection is HashSet<T> hashSet) ? hashSet.Comparer : EqualityComparer<T>.Default) : pooledSet.Comparer)
	{
	}

	public PooledSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
		: this(collection, ClearMode.Auto, comparer)
	{
	}

	public PooledSet(IEnumerable<T> collection, ClearMode clearMode, IEqualityComparer<T> comparer)
		: this(clearMode, comparer)
	{
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		if (collection is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
		{
			method_0(pooledSet);
			return;
		}
		method_1((collection is ICollection<T> collection2) ? collection2.Count : 0);
		UnionWith(collection);
		if (int_2 > 0 && int_1 / int_2 > 3)
		{
			TrimExcess();
		}
	}

	public PooledSet(T[] array)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, (IEqualityComparer<T>)null)
	{
	}

	public PooledSet(T[] array, ClearMode clearMode)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, (IEqualityComparer<T>)null)
	{
	}

	public PooledSet(T[] array, IEqualityComparer<T> comparer)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), ClearMode.Auto, comparer)
	{
	}

	public PooledSet(T[] array, ClearMode clearMode, IEqualityComparer<T> comparer)
		: this((ReadOnlySpan<T>)MemoryExtensions.AsSpan(array), clearMode, comparer)
	{
	}

	public PooledSet(ReadOnlySpan<T> span)
		: this(span, ClearMode.Auto, (IEqualityComparer<T>)null)
	{
	}

	public PooledSet(ReadOnlySpan<T> span, ClearMode clearMode)
		: this(span, clearMode, (IEqualityComparer<T>)null)
	{
	}

	public PooledSet(ReadOnlySpan<T> span, IEqualityComparer<T> comparer)
		: this(span, ClearMode.Auto, comparer)
	{
	}

	public PooledSet(ReadOnlySpan<T> span, ClearMode clearMode, IEqualityComparer<T> comparer)
		: this(clearMode, comparer)
	{
		method_1(span.Length);
		UnionWith(span);
		if (int_2 > 0 && int_1 / int_2 > 3)
		{
			TrimExcess();
		}
	}

	protected PooledSet(SerializationInfo info, StreamingContext context)
	{
		serializationInfo_0 = info;
	}

	private void method_0(PooledSet<T> pooledSet_0)
	{
		int num = pooledSet_0.int_2;
		if (num == 0)
		{
			return;
		}
		int num2 = (int_1 = pooledSet_0.int_1);
		if (HashHelpers.ExpandPrime(num + 1) >= num2)
		{
			int_0 = arrayPool_0.Rent(num2);
			Array.Clear(int_0, 0, int_0.Length);
			Array.Copy(pooledSet_0.int_0, int_0, num2);
			slot_0 = arrayPool_1.Rent(num2);
			Array.Copy(pooledSet_0.slot_0, slot_0, num2);
			int_3 = pooledSet_0.int_3;
			int_4 = pooledSet_0.int_4;
		}
		else
		{
			int num3 = pooledSet_0.int_3;
			Slot[] array = pooledSet_0.slot_0;
			method_1(num);
			int num4 = 0;
			for (int i = 0; i < num3; i++)
			{
				int hashCode = array[i].hashCode;
				if (hashCode >= 0)
				{
					AqUeEuaXfNA(num4, hashCode, array[i].value);
					num4++;
				}
			}
			int_3 = num4;
		}
		int_2 = num;
	}

	void ICollection<T>.Add(T item)
	{
		method_5(item);
	}

	public void Clear()
	{
		if (int_3 > 0)
		{
			Array.Clear(slot_0, 0, int_3);
			Array.Clear(int_0, 0, int_0.Length);
			int_3 = 0;
			int_2 = 0;
			int_4 = -1;
		}
		int_5++;
	}

	public bool Contains(T item)
	{
		if (int_0 != null)
		{
			int num = 0;
			int num2 = method_21(item);
			Slot[] array = slot_0;
			int num3 = int_0[num2 % int_1] - 1;
			while (num3 >= 0)
			{
				if (array[num3].hashCode != num2 || !iequalityComparer_0.Equals(array[num3].value, item))
				{
					if (num >= int_1)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num++;
					num3 = array[num3].next;
					continue;
				}
				return true;
			}
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		CopyTo(array, arrayIndex, int_2);
	}

	public bool Remove(T item)
	{
		if (int_0 != null)
		{
			int num = method_21(item);
			int num2 = num % int_1;
			int num3 = -1;
			int num4 = 0;
			Slot[] array = slot_0;
			int num5 = int_0[num2] - 1;
			while (num5 >= 0)
			{
				if (array[num5].hashCode != num || !iequalityComparer_0.Equals(array[num5].value, item))
				{
					if (num4 >= int_1)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num4++;
					num3 = num5;
					num5 = array[num5].next;
					continue;
				}
				if (num3 < 0)
				{
					int_0[num2] = array[num5].next + 1;
				}
				else
				{
					array[num3].next = array[num5].next;
				}
				array[num5].hashCode = -1;
				if (bool_0)
				{
					array[num5].value = default(T);
				}
				array[num5].next = int_4;
				int_2--;
				int_5++;
				if (int_2 == 0)
				{
					int_3 = 0;
					int_4 = -1;
				}
				else
				{
					int_4 = num5;
				}
				return true;
			}
		}
		return false;
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

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info);
		}
		info.AddValue("Version", int_5);
		info.AddValue("Comparer", iequalityComparer_0, typeof(IEqualityComparer<T>));
		info.AddValue("Capacity", (int_0 != null) ? int_1 : 0);
		if (int_0 != null)
		{
			T[] array = new T[int_2];
			CopyTo(array);
			info.AddValue("Elements", array, typeof(T[]));
		}
	}

	public virtual void OnDeserialization(object sender)
	{
		if (serializationInfo_0 == null)
		{
			return;
		}
		int @int = serializationInfo_0.GetInt32("Capacity");
		iequalityComparer_0 = (IEqualityComparer<T>)serializationInfo_0.GetValue("Comparer", typeof(IEqualityComparer<T>));
		int_4 = -1;
		if (@int != 0)
		{
			method_1(@int);
			T[] array = (T[])serializationInfo_0.GetValue("Elements", typeof(T[]));
			int num;
			if (array == null)
			{
				ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys);
				num = 0;
			}
			else
			{
				num = 0;
			}
			for (int i = num; i < array.Length; i++)
			{
				method_5(array[i]);
			}
		}
		else
		{
			int_0 = null;
		}
		int_5 = serializationInfo_0.GetInt32("Version");
		serializationInfo_0 = null;
	}

	public bool Add(T item)
	{
		return method_5(item);
	}

	public bool TryGetValue(T equalValue, out T actualValue)
	{
		if (int_0 != null)
		{
			int num = method_13(equalValue);
			if (num >= 0)
			{
				actualValue = slot_0[num].value;
				return true;
			}
		}
		actualValue = default(T);
		return false;
	}

	public void UnionWith(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		foreach (T item in other)
		{
			method_5(item);
		}
	}

	public void UnionWith(T[] other)
	{
		UnionWith((ReadOnlySpan<T>)other);
	}

	public void UnionWith(ReadOnlySpan<T> other)
	{
		int i = 0;
		for (int length = other.Length; i < length; i++)
		{
			method_5(other[i]);
		}
	}

	public void IntersectWith(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0 || other == this)
		{
			return;
		}
		if (other is ICollection<T> collection)
		{
			if (collection.Count == 0)
			{
				Clear();
				return;
			}
			if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
			{
				method_10(pooledSet);
				return;
			}
			if (other is HashSet<T> hashSet_ && smethod_2(this, hashSet_))
			{
				method_11(hashSet_);
				return;
			}
		}
		method_12(other);
	}

	public void IntersectWith(T[] other)
	{
		IntersectWith((ReadOnlySpan<T>)other);
	}

	public void IntersectWith(ReadOnlySpan<T> other)
	{
		if (int_2 != 0)
		{
			if (other.Length != 0)
			{
				yydeExahqIf(other);
			}
			else
			{
				Clear();
			}
		}
	}

	public void ExceptWith(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0)
		{
			return;
		}
		if (other == this)
		{
			Clear();
			return;
		}
		foreach (T item in other)
		{
			Remove(item);
		}
	}

	public void ExceptWith(T[] other)
	{
		ExceptWith((ReadOnlySpan<T>)other);
	}

	public void ExceptWith(ReadOnlySpan<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 != 0)
		{
			int i = 0;
			for (int length = other.Length; i < length; i++)
			{
				Remove(other[i]);
			}
		}
	}

	public void SymmetricExceptWith(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0)
		{
			UnionWith(other);
		}
		else if (other == this)
		{
			Clear();
		}
		else if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
		{
			method_14(pooledSet);
		}
		else if (other is HashSet<T> hashSet_ && smethod_2(this, hashSet_))
		{
			method_15(hashSet_);
		}
		else
		{
			method_16(other);
		}
	}

	public void SymmetricExceptWith(T[] other)
	{
		SymmetricExceptWith((ReadOnlySpan<T>)other);
	}

	public void SymmetricExceptWith(ReadOnlySpan<T> other)
	{
		if (int_2 != 0)
		{
			method_17(other);
		}
		else
		{
			UnionWith(other);
		}
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0)
		{
			return true;
		}
		if (other == this)
		{
			return true;
		}
		if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
		{
			if (int_2 <= pooledSet.Count)
			{
				return method_8(pooledSet);
			}
			return false;
		}
		if (other is HashSet<T> hashSet && smethod_2(this, hashSet))
		{
			if (int_2 > hashSet.Count)
			{
				return false;
			}
			return method_9(hashSet);
		}
		ElementCount elementCount = method_19(other, bool_1: false);
		if (elementCount.uniqueCount == int_2)
		{
			return elementCount.unfoundCount >= 0;
		}
		return false;
	}

	public bool IsSubsetOf(T[] other)
	{
		return IsSubsetOf((ReadOnlySpan<T>)other);
	}

	public bool IsSubsetOf(ReadOnlySpan<T> other)
	{
		if (int_2 != 0)
		{
			ElementCount elementCount = method_20(other, bool_1: false);
			if (elementCount.uniqueCount == int_2)
			{
				return elementCount.unfoundCount >= 0;
			}
			return false;
		}
		return true;
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (other == this)
		{
			return false;
		}
		if (other is ICollection<T> collection)
		{
			if (collection.Count == 0)
			{
				return false;
			}
			if (int_2 == 0)
			{
				return collection.Count > 0;
			}
			if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
			{
				if (int_2 >= pooledSet.Count)
				{
					return false;
				}
				return method_8(pooledSet);
			}
			if (other is HashSet<T> hashSet && smethod_2(this, hashSet))
			{
				if (int_2 > hashSet.Count)
				{
					return false;
				}
				return method_9(hashSet);
			}
		}
		ElementCount elementCount = method_19(other, bool_1: false);
		if (elementCount.uniqueCount == int_2)
		{
			return elementCount.unfoundCount > 0;
		}
		return false;
	}

	public bool IsProperSubsetOf(T[] other)
	{
		return IsProperSubsetOf((ReadOnlySpan<T>)other);
	}

	public bool IsProperSubsetOf(ReadOnlySpan<T> other)
	{
		if (other.Length != 0)
		{
			if (int_2 != 0)
			{
				ElementCount elementCount = method_20(other, bool_1: false);
				if (elementCount.uniqueCount == int_2)
				{
					return elementCount.unfoundCount > 0;
				}
				return false;
			}
			return other.Length > 0;
		}
		return false;
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (other == this)
		{
			return true;
		}
		if (other is ICollection<T> collection)
		{
			if (collection.Count == 0)
			{
				return true;
			}
			if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet) && pooledSet.Count > int_2)
			{
				return false;
			}
			if (other is HashSet<T> hashSet && smethod_2(this, hashSet) && hashSet.Count > int_2)
			{
				return false;
			}
		}
		return method_6(other);
	}

	public bool IsSupersetOf(T[] other)
	{
		return IsSupersetOf((ReadOnlySpan<T>)other);
	}

	public bool IsSupersetOf(ReadOnlySpan<T> other)
	{
		if (other.Length != 0)
		{
			return method_7(other);
		}
		return true;
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0)
		{
			return false;
		}
		if (other == this)
		{
			return false;
		}
		if (other is ICollection<T> collection)
		{
			if (collection.Count == 0)
			{
				return true;
			}
			if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
			{
				if (pooledSet.Count >= int_2)
				{
					return false;
				}
				return method_6(pooledSet);
			}
			if (other is HashSet<T> hashSet && smethod_2(this, hashSet))
			{
				if (hashSet.Count < int_2)
				{
					return method_6(hashSet);
				}
				return false;
			}
		}
		ElementCount elementCount = method_19(other, bool_1: true);
		if (elementCount.uniqueCount < int_2)
		{
			return elementCount.unfoundCount == 0;
		}
		return false;
	}

	public bool IsProperSupersetOf(T[] other)
	{
		return IsProperSupersetOf((ReadOnlySpan<T>)other);
	}

	public bool IsProperSupersetOf(ReadOnlySpan<T> other)
	{
		if (int_2 != 0)
		{
			if (other.Length == 0)
			{
				return true;
			}
			ElementCount elementCount = method_20(other, bool_1: true);
			if (elementCount.uniqueCount >= int_2)
			{
				return false;
			}
			return elementCount.unfoundCount == 0;
		}
		return false;
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (int_2 == 0)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		foreach (T item in other)
		{
			if (Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool Overlaps(T[] other)
	{
		return Overlaps((ReadOnlySpan<T>)other);
	}

	public bool Overlaps(ReadOnlySpan<T> other)
	{
		if (int_2 == 0)
		{
			return false;
		}
		int num = 0;
		int length = other.Length;
		while (true)
		{
			if (num < length)
			{
				if (Contains(other[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		if (other == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.other);
		}
		if (other == this)
		{
			return true;
		}
		if (other is PooledSet<T> pooledSet && smethod_1(this, pooledSet))
		{
			if (int_2 != pooledSet.Count)
			{
				return false;
			}
			return method_6(pooledSet);
		}
		if (other is HashSet<T> hashSet && smethod_2(this, hashSet))
		{
			if (int_2 != hashSet.Count)
			{
				return false;
			}
			return method_6(hashSet);
		}
		if (other is ICollection<T> collection && int_2 == 0 && collection.Count > 0)
		{
			return false;
		}
		ElementCount elementCount = method_19(other, bool_1: true);
		if (elementCount.uniqueCount == int_2)
		{
			return elementCount.unfoundCount == 0;
		}
		return false;
	}

	public bool SetEquals(T[] other)
	{
		return SetEquals((ReadOnlySpan<T>)other);
	}

	public bool SetEquals(ReadOnlySpan<T> other)
	{
		if (int_2 == 0 && other.Length > 0)
		{
			return false;
		}
		ElementCount elementCount = method_20(other, bool_1: true);
		if (elementCount.uniqueCount == int_2)
		{
			return elementCount.unfoundCount == 0;
		}
		return false;
	}

	public void CopyTo(T[] array)
	{
		CopyTo(array, 0, int_2);
	}

	public void CopyTo(T[] array, int arrayIndex, int count)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (arrayIndex < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.arrayIndex, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		if (count < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		int num;
		int resource;
		if (arrayIndex <= array.Length)
		{
			if (count <= array.Length - arrayIndex)
			{
				num = 0;
				goto IL_003c;
			}
			resource = 2;
		}
		else
		{
			resource = 2;
		}
		ThrowHelper.ThrowArgumentException((ExceptionResource)resource);
		num = 0;
		goto IL_003c;
		IL_003c:
		int num2 = num;
		for (int i = 0; i < int_3; i++)
		{
			if (num2 >= count)
			{
				break;
			}
			if (slot_0[i].hashCode >= 0)
			{
				array[arrayIndex + num2] = slot_0[i].value;
				num2++;
			}
		}
	}

	public void CopyTo(Span<T> span)
	{
		CopyTo(span, int_2);
	}

	public void CopyTo(Span<T> span, int count)
	{
		int num;
		if (span.Length >= int_2 && span.Length >= count)
		{
			num = 0;
		}
		else
		{
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
			num = 0;
		}
		int num2 = num;
		for (int i = 0; i < int_3; i++)
		{
			if (num2 >= count)
			{
				break;
			}
			if (slot_0[i].hashCode >= 0)
			{
				span[num2] = slot_0[i].value;
				num2++;
			}
		}
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
		int num2 = num;
		for (int i = 0; i < int_3; i++)
		{
			if (slot_0[i].hashCode >= 0)
			{
				T value = slot_0[i].value;
				if (match(value) && Remove(value))
				{
					num2++;
				}
			}
		}
		return num2;
	}

	public int EnsureCapacity(int capacity)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		int num = ((slot_0 != null) ? int_1 : 0);
		if (num >= capacity)
		{
			return num;
		}
		if (int_0 == null)
		{
			return method_1(capacity);
		}
		int prime = HashHelpers.GetPrime(capacity);
		method_3(prime);
		return prime;
	}

	public void TrimExcess()
	{
		if (int_2 == 0)
		{
			method_4();
			int_5++;
			return;
		}
		int prime = HashHelpers.GetPrime(int_2);
		Slot[] array = arrayPool_1.Rent(prime);
		int[] array2 = arrayPool_0.Rent(prime);
		if (array.Length < slot_0.Length && array2.Length < int_0.Length)
		{
			Array.Clear(array2, 0, array2.Length);
			int num = 0;
			for (int i = 0; i < int_3; i++)
			{
				if (slot_0[i].hashCode >= 0)
				{
					array[num] = slot_0[i];
					int num2 = array[num].hashCode % prime;
					array[num].next = array2[num2] - 1;
					array2[num2] = num + 1;
					num++;
				}
			}
			int_3 = num;
			method_4();
			slot_0 = array;
			int_0 = array2;
			int_1 = prime;
			int_4 = -1;
			int_5++;
		}
		else
		{
			arrayPool_1.Return(array);
			arrayPool_0.Return(array2);
		}
	}

	public static IEqualityComparer<PooledSet<T>> CreateSetComparer()
	{
		return new PooledSetEqualityComparer<T>();
	}

	private int method_1(int int_6)
	{
		int_1 = HashHelpers.GetPrime(int_6);
		int_0 = arrayPool_0.Rent(int_1);
		Array.Clear(int_0, 0, int_0.Length);
		slot_0 = arrayPool_1.Rent(int_1);
		return int_1;
	}

	private void method_2()
	{
		int num = HashHelpers.ExpandPrime(int_2);
		if (num <= int_2)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_HSCapacityOverflow);
		}
		method_3(num);
	}

	private void method_3(int int_6)
	{
		int[] array = int_0;
		int[] array3;
		Slot[] array4;
		bool flag;
		int num;
		if (array != null && array.Length >= int_6)
		{
			Slot[] array2 = slot_0;
			if (array2 != null && array2.Length >= int_6)
			{
				Array.Clear(int_0, 0, int_0.Length);
				Array.Clear(slot_0, int_1, int_6 - int_1);
				array3 = int_0;
				array4 = slot_0;
				flag = false;
				num = 0;
				goto IL_00ae;
			}
		}
		array4 = arrayPool_1.Rent(int_6);
		array3 = arrayPool_0.Rent(int_6);
		Array.Clear(array3, 0, array3.Length);
		int num2;
		if (slot_0 == null)
		{
			num2 = 1;
		}
		else
		{
			Array.Copy(slot_0, 0, array4, 0, int_3);
			num2 = 1;
		}
		flag = (byte)num2 != 0;
		num = 0;
		goto IL_00ae;
		IL_00ae:
		for (int i = num; i < int_3; i++)
		{
			int num3 = array4[i].hashCode % int_6;
			array4[i].next = array3[num3] - 1;
			array3[num3] = i + 1;
		}
		if (flag)
		{
			method_4();
			slot_0 = array4;
			int_0 = array3;
		}
		int_1 = int_6;
	}

	private void method_4()
	{
		Slot[] array = slot_0;
		if (array != null && array.Length != 0)
		{
			try
			{
				arrayPool_1.Return(slot_0, bool_0);
			}
			catch (ArgumentException)
			{
			}
		}
		int[] array2 = int_0;
		if (array2 != null && array2.Length != 0)
		{
			try
			{
				arrayPool_0.Return(int_0);
			}
			catch (ArgumentException)
			{
			}
		}
		slot_0 = null;
		int_0 = null;
	}

	private static bool smethod_0(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	private bool method_5(T gparam_0)
	{
		if (int_0 == null)
		{
			method_1(0);
		}
		int num = method_21(gparam_0);
		int num2 = num % int_1;
		int num3 = 0;
		Slot[] array = slot_0;
		int num4 = int_0[num2] - 1;
		while (true)
		{
			if (num4 >= 0)
			{
				if (array[num4].hashCode == num && iequalityComparer_0.Equals(array[num4].value, gparam_0))
				{
					break;
				}
				if (num3 >= int_1)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num3++;
				num4 = array[num4].next;
				continue;
			}
			int num5;
			if (int_4 >= 0)
			{
				num5 = int_4;
				int_4 = array[num5].next;
			}
			else
			{
				if (int_3 == int_1)
				{
					method_2();
					array = slot_0;
					num2 = num % int_1;
				}
				num5 = int_3;
				int_3++;
			}
			array[num5].hashCode = num;
			array[num5].value = gparam_0;
			array[num5].next = int_0[num2] - 1;
			int_0[num2] = num5 + 1;
			int_2++;
			int_5++;
			return true;
		}
		return false;
	}

	private void AqUeEuaXfNA(int int_6, int int_7, T gparam_0)
	{
		int num = int_7 % int_1;
		slot_0[int_6].hashCode = int_7;
		slot_0[int_6].value = gparam_0;
		slot_0[int_6].next = int_0[num] - 1;
		int_0[num] = int_6 + 1;
	}

	private bool method_6(IEnumerable<T> ienumerable_0)
	{
		foreach (T item in ienumerable_0)
		{
			if (!Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	private bool method_7(ReadOnlySpan<T> readOnlySpan_0)
	{
		ReadOnlySpan<T> readOnlySpan = readOnlySpan_0;
		int num = 0;
		while (true)
		{
			if (num < readOnlySpan.Length)
			{
				T item = readOnlySpan[num];
				if (!Contains(item))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_8(PooledSet<T> pooledSet_0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (!pooledSet_0.Contains(current))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool method_9(HashSet<T> hashSet_0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (!hashSet_0.Contains(current))
				{
					return false;
				}
			}
		}
		return true;
	}

	private void method_10(PooledSet<T> pooledSet_0)
	{
		for (int i = 0; i < int_3; i++)
		{
			if (slot_0[i].hashCode >= 0)
			{
				T value = slot_0[i].value;
				if (!pooledSet_0.Contains(value))
				{
					Remove(value);
				}
			}
		}
	}

	private void method_11(HashSet<T> hashSet_0)
	{
		for (int i = 0; i < int_3; i++)
		{
			if (slot_0[i].hashCode >= 0)
			{
				T value = slot_0[i].value;
				if (!hashSet_0.Contains(value))
				{
					Remove(value);
				}
			}
		}
	}

	private void method_12(IEnumerable<T> ienumerable_0)
	{
		int num = int_3;
		int num2 = BitHelper.ToIntArrayLength(num);
		Span<int> span = stackalloc int[100];
		BitHelper bitHelper = ((num2 > 100) ? new BitHelper(new int[num2], clear: false) : new BitHelper(span.Slice(0, num2), clear: true));
		foreach (T item in ienumerable_0)
		{
			int num3 = method_13(item);
			if (num3 >= 0)
			{
				bitHelper.MarkBit(num3);
			}
		}
		int num4 = bitHelper.FindFirstUnmarked();
		while ((uint)num4 < (uint)num)
		{
			if (slot_0[num4].hashCode >= 0)
			{
				Remove(slot_0[num4].value);
			}
			num4 = bitHelper.FindFirstUnmarked(num4 + 1);
		}
	}

	private void yydeExahqIf(ReadOnlySpan<T> readOnlySpan_0)
	{
		int num = int_3;
		int num2 = BitHelper.ToIntArrayLength(num);
		Span<int> span = stackalloc int[100];
		BitHelper bitHelper = ((num2 <= 100) ? new BitHelper(span.Slice(0, num2), clear: true) : new BitHelper(new int[num2], clear: false));
		int i = 0;
		for (int length = readOnlySpan_0.Length; i < length; i++)
		{
			int num3 = method_13(readOnlySpan_0[i]);
			if (num3 >= 0)
			{
				bitHelper.MarkBit(num3);
			}
		}
		int num4 = bitHelper.FindFirstUnmarked();
		while ((uint)num4 < (uint)num)
		{
			if (slot_0[num4].hashCode >= 0)
			{
				Remove(slot_0[num4].value);
			}
			num4 = bitHelper.FindFirstUnmarked(num4 + 1);
		}
	}

	private int method_13(T gparam_0)
	{
		int num = 0;
		int num2 = method_21(gparam_0);
		Slot[] array = slot_0;
		int num3 = int_0[num2 % int_1] - 1;
		while (true)
		{
			if (num3 >= 0)
			{
				if (array[num3].hashCode == num2 && iequalityComparer_0.Equals(array[num3].value, gparam_0))
				{
					break;
				}
				if (num >= int_1)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num++;
				num3 = array[num3].next;
				continue;
			}
			return -1;
		}
		return num3;
	}

	private void method_14(PooledSet<T> pooledSet_0)
	{
		foreach (T item in pooledSet_0)
		{
			if (!Remove(item))
			{
				method_5(item);
			}
		}
	}

	private void method_15(HashSet<T> hashSet_0)
	{
		foreach (T item in hashSet_0)
		{
			if (!Remove(item))
			{
				method_5(item);
			}
		}
	}

	private void method_16(IEnumerable<T> ienumerable_0)
	{
		int num = int_3;
		int num2 = BitHelper.ToIntArrayLength(num);
		Span<int> span = stackalloc int[50];
		BitHelper bitHelper = ((num2 > 50) ? new BitHelper(new int[num2], clear: false) : new BitHelper(span.Slice(0, num2), clear: true));
		Span<int> span2 = stackalloc int[50];
		BitHelper bitHelper2 = ((num2 > 50) ? new BitHelper(new int[num2], clear: false) : new BitHelper(span2.Slice(0, num2), clear: true));
		foreach (T item in ienumerable_0)
		{
			if (!method_18(item, out var int_))
			{
				if (int_ < num && !bitHelper2.IsMarked(int_))
				{
					bitHelper.MarkBit(int_);
				}
			}
			else
			{
				bitHelper2.MarkBit(int_);
			}
		}
		int num3 = bitHelper.FindFirstMarked();
		while ((uint)num3 < (uint)num)
		{
			if (slot_0[num3].hashCode >= 0)
			{
				Remove(slot_0[num3].value);
			}
			num3 = bitHelper.FindFirstMarked(num3 + 1);
		}
	}

	private void method_17(ReadOnlySpan<T> readOnlySpan_0)
	{
		int num = int_3;
		int num2 = BitHelper.ToIntArrayLength(num);
		Span<int> span = stackalloc int[50];
		BitHelper bitHelper = ((num2 > 50) ? new BitHelper(new int[num2], clear: false) : new BitHelper(span.Slice(0, num2), clear: true));
		Span<int> span2 = stackalloc int[50];
		BitHelper bitHelper2 = ((num2 > 50) ? new BitHelper(new int[num2], clear: false) : new BitHelper(span2.Slice(0, num2), clear: true));
		int i = 0;
		for (int length = readOnlySpan_0.Length; i < length; i++)
		{
			if (method_18(readOnlySpan_0[i], out var int_))
			{
				bitHelper2.MarkBit(int_);
			}
			else if (int_ < num && !bitHelper2.IsMarked(int_))
			{
				bitHelper.MarkBit(int_);
			}
		}
		int num3 = bitHelper.FindFirstMarked();
		while ((uint)num3 < (uint)num)
		{
			if (slot_0[num3].hashCode >= 0)
			{
				Remove(slot_0[num3].value);
			}
			num3 = bitHelper.FindFirstMarked(num3 + 1);
		}
	}

	private bool method_18(T gparam_0, out int int_6)
	{
		int num = method_21(gparam_0);
		int num2 = num % int_1;
		int num3 = 0;
		Slot[] array = slot_0;
		int num4 = int_0[num2] - 1;
		while (true)
		{
			if (num4 >= 0)
			{
				if (array[num4].hashCode == num && iequalityComparer_0.Equals(array[num4].value, gparam_0))
				{
					break;
				}
				if (num3 >= int_1)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num3++;
				num4 = array[num4].next;
				continue;
			}
			int num5;
			if (int_4 >= 0)
			{
				num5 = int_4;
				int_4 = array[num5].next;
			}
			else
			{
				if (int_3 == int_1)
				{
					method_2();
					array = slot_0;
					num2 = num % int_1;
				}
				num5 = int_3;
				int_3++;
			}
			array[num5].hashCode = num;
			array[num5].value = gparam_0;
			array[num5].next = int_0[num2] - 1;
			int_0[num2] = num5 + 1;
			int_2++;
			int_5++;
			int_6 = num5;
			return true;
		}
		int_6 = num4;
		return false;
	}

	private ElementCount method_19(IEnumerable<T> ienumerable_0, bool bool_1)
	{
		ElementCount result = default(ElementCount);
		if (int_2 == 0)
		{
			int num = 0;
			using (IEnumerator<T> enumerator = ienumerable_0.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					num++;
				}
			}
			result.uniqueCount = 0;
			result.unfoundCount = num;
			return result;
		}
		int num2 = BitHelper.ToIntArrayLength(int_3);
		Span<int> span = stackalloc int[100];
		BitHelper bitHelper = ((num2 <= 100) ? new BitHelper(span.Slice(0, num2), clear: true) : new BitHelper(new int[num2], clear: false));
		int num3 = 0;
		int num4 = 0;
		foreach (T item in ienumerable_0)
		{
			int num5 = method_13(item);
			if (num5 >= 0)
			{
				if (!bitHelper.IsMarked(num5))
				{
					bitHelper.MarkBit(num5);
					num4++;
				}
			}
			else
			{
				num3++;
				if (bool_1)
				{
					break;
				}
			}
		}
		result.uniqueCount = num4;
		result.unfoundCount = num3;
		return result;
	}

	private ElementCount method_20(ReadOnlySpan<T> readOnlySpan_0, bool bool_1)
	{
		ElementCount result = default(ElementCount);
		if (int_2 == 0)
		{
			result.uniqueCount = 0;
			result.unfoundCount = readOnlySpan_0.Length;
			return result;
		}
		int num = BitHelper.ToIntArrayLength(int_3);
		Span<int> span = stackalloc int[100];
		BitHelper bitHelper = ((num <= 100) ? new BitHelper(span.Slice(0, num), clear: true) : new BitHelper(new int[num], clear: false));
		int num2 = 0;
		int num3 = 0;
		int i = 0;
		for (int length = readOnlySpan_0.Length; i < length; i++)
		{
			int num4 = method_13(readOnlySpan_0[i]);
			if (num4 < 0)
			{
				num2++;
				if (bool_1)
				{
					break;
				}
			}
			else if (!bitHelper.IsMarked(num4))
			{
				bitHelper.MarkBit(num4);
				num3++;
			}
		}
		result.uniqueCount = num3;
		result.unfoundCount = num2;
		return result;
	}

	internal static bool PooledSetEquals(PooledSet<T> set1, PooledSet<T> set2, IEqualityComparer<T> comparer)
	{
		if (set1 == null)
		{
			return set2 == null;
		}
		if (set2 != null)
		{
			if (!smethod_1(set1, set2))
			{
				foreach (T item in set2)
				{
					bool flag = false;
					foreach (T item2 in set1)
					{
						if (comparer.Equals(item, item2))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return false;
					}
				}
				return true;
			}
			if (set1.Count != set2.Count)
			{
				return false;
			}
			foreach (T item3 in set2)
			{
				if (!set1.Contains(item3))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private static bool smethod_1(PooledSet<T> pooledSet_0, PooledSet<T> pooledSet_1)
	{
		return pooledSet_0.Comparer.Equals(pooledSet_1.Comparer);
	}

	private static bool smethod_2(PooledSet<T> pooledSet_0, HashSet<T> hashSet_0)
	{
		return pooledSet_0.Comparer.Equals(hashSet_0.Comparer);
	}

	private int method_21(T gparam_0)
	{
		if (gparam_0 == null)
		{
			return 0;
		}
		return iequalityComparer_0.GetHashCode(gparam_0) & 0x7FFFFFFF;
	}

	public void Dispose()
	{
		method_4();
		int_1 = 0;
		int_3 = 0;
		int_2 = 0;
		int_4 = -1;
		int_5++;
	}

	static PooledSet()
	{
		Class72.smethod_20();
		arrayPool_0 = Pools<int>.Local;
		arrayPool_1 = Pools<Slot>.Local;
	}

	internal static bool smethod_3()
	{
		return object_0 == null;
	}

	internal static object smethod_4()
	{
		return object_0;
	}
}
