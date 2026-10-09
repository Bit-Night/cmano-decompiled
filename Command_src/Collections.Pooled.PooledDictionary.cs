using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace Collections.Pooled;

[Serializable]
[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(Class69<, >))]
public class PooledDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, ISerializable, IDeserializationCallback, IDisposable
{
	private struct Struct52
	{
		public int int_0;

		public int int_1;

		public TKey gparam_0;

		public TValue gparam_1;
	}

	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator, IDictionaryEnumerator
	{
		private readonly PooledDictionary<TKey, TValue> pooledDictionary_0;

		private readonly int int_0;

		private int int_1;

		private KeyValuePair<TKey, TValue> keyValuePair_0;

		private readonly int int_2;

		internal const int DictEntry = 1;

		internal const int KeyValuePair = 2;

		public KeyValuePair<TKey, TValue> Current => keyValuePair_0;

		object IEnumerator.Current
		{
			get
			{
				if (int_1 == 0 || int_1 == pooledDictionary_0.int_2 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				if (int_2 == 1)
				{
					return new DictionaryEntry(keyValuePair_0.Key, keyValuePair_0.Value);
				}
				return new KeyValuePair<TKey, TValue>(keyValuePair_0.Key, keyValuePair_0.Value);
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (int_1 == 0 || int_1 == pooledDictionary_0.int_2 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return new DictionaryEntry(keyValuePair_0.Key, keyValuePair_0.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (int_1 == 0 || int_1 == pooledDictionary_0.int_2 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return keyValuePair_0.Key;
			}
		}

		object IDictionaryEnumerator.Value
		{
			get
			{
				if (int_1 == 0 || int_1 == pooledDictionary_0.int_2 + 1)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
				}
				return keyValuePair_0.Value;
			}
		}

		internal Enumerator(PooledDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
		{
			pooledDictionary_0 = dictionary;
			int_0 = dictionary.int_5;
			int_1 = 0;
			int_2 = getEnumeratorRetType;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
		}

		public bool MoveNext()
		{
			if (int_0 != pooledDictionary_0.int_5)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			while ((uint)int_1 < (uint)pooledDictionary_0.int_2)
			{
				ref Struct52 reference = ref pooledDictionary_0.struct52_0[int_1++];
				if (reference.int_0 >= 0)
				{
					keyValuePair_0 = new KeyValuePair<TKey, TValue>(reference.gparam_0, reference.gparam_1);
					return true;
				}
			}
			int_1 = pooledDictionary_0.int_2 + 1;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			if (int_0 != pooledDictionary_0.int_5)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			}
			int_1 = 0;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
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

	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(DictionaryKeyCollectionDebugView<, >))]
	public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection, IReadOnlyCollection<TKey>
	{
		public struct Enumerator : IEnumerator<TKey>, IDisposable, IEnumerator
		{
			private readonly PooledDictionary<TKey, TValue> pooledDictionary_0;

			private int int_0;

			private readonly int int_1;

			private TKey gparam_0;

			public TKey Current => gparam_0;

			object IEnumerator.Current
			{
				get
				{
					if (int_0 == 0 || int_0 == pooledDictionary_0.int_2 + 1)
					{
						ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
					}
					return gparam_0;
				}
			}

			internal Enumerator(PooledDictionary<TKey, TValue> dictionary)
			{
				pooledDictionary_0 = dictionary;
				int_1 = dictionary.int_5;
				int_0 = 0;
				gparam_0 = default(TKey);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (int_1 != pooledDictionary_0.int_5)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				}
				while ((uint)int_0 < (uint)pooledDictionary_0.int_2)
				{
					ref Struct52 reference = ref pooledDictionary_0.struct52_0[int_0++];
					if (reference.int_0 >= 0)
					{
						gparam_0 = reference.gparam_0;
						return true;
					}
				}
				int_0 = pooledDictionary_0.int_2 + 1;
				gparam_0 = default(TKey);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (int_1 != pooledDictionary_0.int_5)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				}
				int_0 = 0;
				gparam_0 = default(TKey);
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

		private readonly PooledDictionary<TKey, TValue> pooledDictionary_0;

		internal static object object_0;

		public int Count => pooledDictionary_0.Count;

		bool ICollection<TKey>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)pooledDictionary_0).SyncRoot;

		public KeyCollection(PooledDictionary<TKey, TValue> dictionary)
		{
			pooledDictionary_0 = dictionary ?? throw new ArgumentNullException("dictionary");
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		public void CopyTo(TKey[] array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (index < 0 || index > array.Length)
			{
				ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
			}
			if (array.Length - index < pooledDictionary_0.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			int int_ = pooledDictionary_0.int_2;
			Struct52[] struct52_ = pooledDictionary_0.struct52_0;
			for (int i = 0; i < int_; i++)
			{
				if (struct52_[i].int_0 >= 0)
				{
					array[index++] = struct52_[i].gparam_0;
				}
			}
		}

		void ICollection<TKey>.Add(TKey item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
		}

		void ICollection<TKey>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
		}

		bool ICollection<TKey>.Contains(TKey item)
		{
			return pooledDictionary_0.ContainsKey(item);
		}

		bool ICollection<TKey>.Remove(TKey item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
			return false;
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		void ICollection.CopyTo(Array array, int index)
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
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
			}
			if ((uint)index > (uint)array.Length)
			{
				ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
			}
			if (array.Length - index < pooledDictionary_0.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			if (array is TKey[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			object[] array3 = array as object[];
			if (array3 == null)
			{
				ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
			}
			int int_ = pooledDictionary_0.int_2;
			Struct52[] struct52_ = pooledDictionary_0.struct52_0;
			try
			{
				for (int i = 0; i < int_; i++)
				{
					if (struct52_[i].int_0 >= 0)
					{
						array3[index++] = struct52_[i].gparam_0;
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
			}
		}

		static KeyCollection()
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

	[DebuggerTypeProxy(typeof(DictionaryValueCollectionDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue>
	{
		public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private readonly PooledDictionary<TKey, TValue> pooledDictionary_0;

			private int int_0;

			private readonly int int_1;

			private TValue gparam_0;

			public TValue Current => gparam_0;

			object IEnumerator.Current
			{
				get
				{
					if (int_0 == 0 || int_0 == pooledDictionary_0.int_2 + 1)
					{
						ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen();
					}
					return gparam_0;
				}
			}

			internal Enumerator(PooledDictionary<TKey, TValue> dictionary)
			{
				pooledDictionary_0 = dictionary;
				int_1 = dictionary.int_5;
				int_0 = 0;
				gparam_0 = default(TValue);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (int_1 != pooledDictionary_0.int_5)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				}
				while ((uint)int_0 < (uint)pooledDictionary_0.int_2)
				{
					ref Struct52 reference = ref pooledDictionary_0.struct52_0[int_0++];
					if (reference.int_0 >= 0)
					{
						gparam_0 = reference.gparam_1;
						return true;
					}
				}
				int_0 = pooledDictionary_0.int_2 + 1;
				gparam_0 = default(TValue);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (int_1 != pooledDictionary_0.int_5)
				{
					ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				}
				int_0 = 0;
				gparam_0 = default(TValue);
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

		private readonly PooledDictionary<TKey, TValue> pooledDictionary_0;

		private static object object_0;

		public int Count => pooledDictionary_0.Count;

		bool ICollection<TValue>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)pooledDictionary_0).SyncRoot;

		public ValueCollection(PooledDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
			}
			pooledDictionary_0 = dictionary;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		public void CopyTo(TValue[] array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (index < 0 || index > array.Length)
			{
				ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
			}
			if (array.Length - index < pooledDictionary_0.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			int int_ = pooledDictionary_0.int_2;
			Struct52[] struct52_ = pooledDictionary_0.struct52_0;
			for (int i = 0; i < int_; i++)
			{
				if (struct52_[i].int_0 >= 0)
				{
					array[index++] = struct52_[i].gparam_1;
				}
			}
		}

		void ICollection<TValue>.Add(TValue item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
		}

		bool ICollection<TValue>.Remove(TValue item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
			return false;
		}

		void ICollection<TValue>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
		}

		bool ICollection<TValue>.Contains(TValue item)
		{
			return pooledDictionary_0.ContainsValue(item);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(pooledDictionary_0);
		}

		void ICollection.CopyTo(Array array, int index)
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
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
			}
			if ((uint)index > (uint)array.Length)
			{
				ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
			}
			if (array.Length - index < pooledDictionary_0.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			if (!(array is TValue[] array2))
			{
				if (array is object[] array3)
				{
					int int_ = pooledDictionary_0.int_2;
					Struct52[] struct52_ = pooledDictionary_0.struct52_0;
					try
					{
						for (int i = 0; i < int_; i++)
						{
							if (struct52_[i].int_0 >= 0)
							{
								array3[index++] = struct52_[i].gparam_1;
							}
						}
						return;
					}
					catch (ArrayTypeMismatchException)
					{
						ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
						return;
					}
				}
				ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
			}
			else
			{
				CopyTo(array2, index);
			}
		}

		static ValueCollection()
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

	private static readonly ArrayPool<int> arrayPool_0;

	private static readonly ArrayPool<Struct52> arrayPool_1;

	private int[] int_0;

	private Struct52[] struct52_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private IEqualityComparer<TKey> iequalityComparer_0;

	private KeyCollection keyCollection_0;

	private ValueCollection valueCollection_0;

	private object object_0;

	private readonly bool bool_0;

	private readonly bool bool_1;

	private static object object_1;

	public IEqualityComparer<TKey> Comparer
	{
		get
		{
			if (iequalityComparer_0 != null && !(iequalityComparer_0 is NonRandomizedStringEqualityComparer))
			{
				return iequalityComparer_0;
			}
			return EqualityComparer<TKey>.Default;
		}
	}

	public int Count => int_2 - int_4;

	public ClearMode KeyClearMode
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

	public ClearMode ValueClearMode
	{
		get
		{
			if (!bool_1)
			{
				return ClearMode.Never;
			}
			return ClearMode.Always;
		}
	}

	public KeyCollection Keys
	{
		get
		{
			if (keyCollection_0 == null)
			{
				keyCollection_0 = new KeyCollection(this);
			}
			return keyCollection_0;
		}
	}

	ICollection<TKey> IDictionary<TKey, TValue>.Keys
	{
		get
		{
			if (keyCollection_0 == null)
			{
				keyCollection_0 = new KeyCollection(this);
			}
			return keyCollection_0;
		}
	}

	IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
	{
		get
		{
			if (keyCollection_0 == null)
			{
				keyCollection_0 = new KeyCollection(this);
			}
			return keyCollection_0;
		}
	}

	public ValueCollection Values
	{
		get
		{
			if (valueCollection_0 == null)
			{
				valueCollection_0 = new ValueCollection(this);
			}
			return valueCollection_0;
		}
	}

	ICollection<TValue> IDictionary<TKey, TValue>.Values
	{
		get
		{
			if (valueCollection_0 == null)
			{
				valueCollection_0 = new ValueCollection(this);
			}
			return valueCollection_0;
		}
	}

	IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
	{
		get
		{
			if (valueCollection_0 == null)
			{
				valueCollection_0 = new ValueCollection(this);
			}
			return valueCollection_0;
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			int num = method_1(key);
			if (num >= 0)
			{
				return struct52_0[num].gparam_1;
			}
			ThrowHelper.ThrowKeyNotFoundException(key);
			return default(TValue);
		}
		set
		{
			method_3(key, value, InsertionBehavior.OverwriteExisting);
		}
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

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

	bool IDictionary.IsFixedSize => false;

	bool IDictionary.IsReadOnly => false;

	ICollection IDictionary.Keys => Keys;

	ICollection IDictionary.Values => Values;

	object IDictionary.this[object key]
	{
		get
		{
			if (smethod_2(key))
			{
				int num = method_1((TKey)key);
				if (num >= 0)
				{
					return struct52_0[num].gparam_1;
				}
			}
			return null;
		}
		set
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
			try
			{
				TKey key2 = (TKey)key;
				try
				{
					this[key2] = (TValue)value;
				}
				catch (InvalidCastException)
				{
					ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
				}
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
			}
		}
	}

	public PooledDictionary()
		: this(0, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(ClearMode clearMode)
		: this(0, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(int capacity)
		: this(capacity, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(int capacity, ClearMode clearMode)
		: this(capacity, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IEqualityComparer<TKey> comparer)
		: this(0, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(int capacity, IEqualityComparer<TKey> comparer)
		: this(capacity, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this(0, clearMode, comparer)
	{
	}

	public PooledDictionary(int capacity, ClearMode clearMode, IEqualityComparer<TKey> comparer)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
		}
		if (capacity > 0)
		{
			method_2(capacity);
		}
		if (comparer != EqualityComparer<TKey>.Default)
		{
			iequalityComparer_0 = comparer;
		}
		bool_0 = smethod_0(clearMode);
		bool_1 = smethod_1(clearMode);
		if (typeof(TKey) == typeof(string) && iequalityComparer_0 == null)
		{
			iequalityComparer_0 = (IEqualityComparer<TKey>)NonRandomizedStringEqualityComparer.Default;
		}
	}

	public PooledDictionary(IDictionary<TKey, TValue> dictionary)
		: this(dictionary, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IDictionary<TKey, TValue> dictionary, ClearMode clearMode)
		: this(dictionary, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		: this(dictionary, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(IDictionary<TKey, TValue> dictionary, ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this(dictionary?.Count ?? 0, clearMode, comparer)
	{
		if (dictionary == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
		}
		if (dictionary is PooledDictionary<TKey, TValue> { int_2: var num, struct52_0: var array })
		{
			for (int i = 0; i < num; i++)
			{
				if (array[i].int_0 >= 0)
				{
					method_3(array[i].gparam_0, array[i].gparam_1, InsertionBehavior.ThrowOnExisting);
				}
			}
			return;
		}
		foreach (KeyValuePair<TKey, TValue> item in dictionary)
		{
			method_3(item.Key, item.Value, InsertionBehavior.ThrowOnExisting);
		}
	}

	public PooledDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		: this(collection, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, ClearMode clearMode)
		: this(collection, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
		: this(collection, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this((collection as ICollection<KeyValuePair<TKey, TValue>>)?.Count ?? 0, clearMode, comparer)
	{
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			method_3(item.Key, item.Value, InsertionBehavior.ThrowOnExisting);
		}
	}

	public PooledDictionary(IEnumerable<(TKey key, TValue value)> collection)
		: this(collection, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IEnumerable<(TKey key, TValue value)> collection, ClearMode clearMode)
		: this(collection, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(IEnumerable<(TKey key, TValue value)> collection, IEqualityComparer<TKey> comparer)
		: this(collection, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(IEnumerable<(TKey key, TValue value)> collection, ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this((collection as ICollection<(TKey, TValue)>)?.Count ?? 0, clearMode, comparer)
	{
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		foreach (var (gparam_, gparam_2) in collection)
		{
			method_3(gparam_, gparam_2, InsertionBehavior.ThrowOnExisting);
		}
	}

	public PooledDictionary((TKey key, TValue value)[] array)
		: this((ReadOnlySpan<(TKey, TValue)>)MemoryExtensions.AsSpan(array), ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary((TKey key, TValue value)[] array, ClearMode clearMode)
		: this((ReadOnlySpan<(TKey, TValue)>)MemoryExtensions.AsSpan(array), clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary((TKey key, TValue value)[] array, IEqualityComparer<TKey> comparer)
		: this((ReadOnlySpan<(TKey, TValue)>)MemoryExtensions.AsSpan(array), ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary((TKey key, TValue value)[] array, ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this((ReadOnlySpan<(TKey, TValue)>)MemoryExtensions.AsSpan(array), clearMode, comparer)
	{
	}

	public PooledDictionary(ReadOnlySpan<(TKey key, TValue value)> span)
		: this(span, ClearMode.Auto, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(ReadOnlySpan<(TKey key, TValue value)> span, ClearMode clearMode)
		: this(span, clearMode, (IEqualityComparer<TKey>)null)
	{
	}

	public PooledDictionary(ReadOnlySpan<(TKey key, TValue value)> span, IEqualityComparer<TKey> comparer)
		: this(span, ClearMode.Auto, comparer)
	{
	}

	public PooledDictionary(ReadOnlySpan<(TKey key, TValue value)> span, ClearMode clearMode, IEqualityComparer<TKey> comparer)
		: this(span.Length, clearMode, comparer)
	{
		ReadOnlySpan<(TKey, TValue)> readOnlySpan = span;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			var (gparam_, gparam_2) = readOnlySpan[i];
			method_3(gparam_, gparam_2, InsertionBehavior.ThrowOnExisting);
		}
	}

	protected PooledDictionary(SerializationInfo info, StreamingContext context)
	{
		bool_0 = ((bool?)info.GetValue("CK", typeof(bool))) ?? smethod_0(ClearMode.Auto);
		bool_1 = ((bool?)info.GetValue("CV", typeof(bool))) ?? smethod_1(ClearMode.Auto);
		HashHelpers.SerializationInfoTable.Add(this, info);
	}

	public void Add(TKey key, TValue value)
	{
		method_3(key, value, InsertionBehavior.ThrowOnExisting);
	}

	public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
	{
		if (enumerable == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.enumerable);
		}
		if (enumerable is ICollection<KeyValuePair<TKey, TValue>> collection)
		{
			EnsureCapacity(int_2 + collection.Count);
		}
		foreach (KeyValuePair<TKey, TValue> item in enumerable)
		{
			method_3(item.Key, item.Value, InsertionBehavior.ThrowOnExisting);
		}
	}

	public void AddRange(IEnumerable<(TKey key, TValue value)> enumerable)
	{
		if (enumerable == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.enumerable);
		}
		if (enumerable is ICollection<KeyValuePair<TKey, TValue>> collection)
		{
			EnsureCapacity(int_2 + collection.Count);
		}
		foreach (var (gparam_, gparam_2) in enumerable)
		{
			method_3(gparam_, gparam_2, InsertionBehavior.ThrowOnExisting);
		}
	}

	public void AddRange(ReadOnlySpan<(TKey key, TValue value)> span)
	{
		EnsureCapacity(int_2 + span.Length);
		ReadOnlySpan<(TKey, TValue)> readOnlySpan = span;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			var (gparam_, gparam_2) = readOnlySpan[i];
			method_3(gparam_, gparam_2, InsertionBehavior.ThrowOnExisting);
		}
	}

	public void AddRange((TKey key, TValue value)[] array)
	{
		AddRange(MemoryExtensions.AsSpan(array));
	}

	public void AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updater)
	{
		if (TryGetValue(key, out var value))
		{
			TValue gparam_ = updater(key, value);
			method_3(key, gparam_, InsertionBehavior.OverwriteExisting);
		}
		else
		{
			method_3(key, addValue, InsertionBehavior.ThrowOnExisting);
		}
	}

	public void AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updater)
	{
		if (TryGetValue(key, out var value))
		{
			TValue gparam_ = updater(key, value);
			method_3(key, gparam_, InsertionBehavior.OverwriteExisting);
		}
		else
		{
			TValue gparam_2 = addValueFactory(key);
			method_3(key, gparam_2, InsertionBehavior.ThrowOnExisting);
		}
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
	{
		Add(keyValuePair.Key, keyValuePair.Value);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
	{
		int num = method_1(keyValuePair.Key);
		int result;
		if (num >= 0)
		{
			if (EqualityComparer<TValue>.Default.Equals(struct52_0[num].gparam_1, keyValuePair.Value))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
	{
		int num = method_1(keyValuePair.Key);
		if (num >= 0 && EqualityComparer<TValue>.Default.Equals(struct52_0[num].gparam_1, keyValuePair.Value))
		{
			Remove(keyValuePair.Key);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		int num = int_2;
		if (num > 0)
		{
			Array.Clear(int_0, 0, int_1);
			int_2 = 0;
			int_3 = -1;
			int_4 = 0;
			int_1 = 0;
			Array.Clear(struct52_0, 0, num);
			int_5++;
		}
	}

	public bool ContainsKey(TKey key)
	{
		return method_1(key) >= 0;
	}

	public bool ContainsValue(TValue value)
	{
		Struct52[] array = struct52_0;
		if (value == null)
		{
			for (int i = 0; i < int_2; i++)
			{
				if (array[i].int_0 >= 0 && array[i].gparam_1 == null)
				{
					return true;
				}
			}
		}
		else if (default(TValue) != null)
		{
			for (int j = 0; j < int_2; j++)
			{
				if (array[j].int_0 >= 0 && EqualityComparer<TValue>.Default.Equals(array[j].gparam_1, value))
				{
					return true;
				}
			}
		}
		else
		{
			EqualityComparer<TValue> equalityComparer = EqualityComparer<TValue>.Default;
			for (int k = 0; k < int_2; k++)
			{
				if (array[k].int_0 >= 0 && equalityComparer.Equals(array[k].gparam_1, value))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void method_0(KeyValuePair<TKey, TValue>[] keyValuePair_0, int int_6)
	{
		if (keyValuePair_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if ((uint)int_6 > (uint)keyValuePair_0.Length)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (keyValuePair_0.Length - int_6 < Count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
		}
		int num = int_2;
		Struct52[] array = struct52_0;
		for (int i = 0; i < num; i++)
		{
			if (array[i].int_0 >= 0)
			{
				keyValuePair_0[int_6++] = new KeyValuePair<TKey, TValue>(array[i].gparam_0, array[i].gparam_1);
			}
		}
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		GetObjectData(info, context);
	}

	protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info);
		}
		info.AddValue("Version", int_5);
		info.AddValue("Comparer", iequalityComparer_0 ?? EqualityComparer<TKey>.Default, typeof(IEqualityComparer<TKey>));
		info.AddValue("HashSize", int_1);
		info.AddValue("CK", bool_0);
		info.AddValue("CV", bool_1);
		if (int_0 != null)
		{
			KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[Count];
			method_0(array, 0);
			info.AddValue("KeyValuePairs", array, typeof(KeyValuePair<TKey, TValue>[]));
		}
	}

	private int method_1(TKey gparam_0)
	{
		if (gparam_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		int result = -1;
		int num = int_1;
		if (num <= 0)
		{
			return result;
		}
		int[] array = int_0;
		Struct52[] array2 = struct52_0;
		int num2 = 0;
		IEqualityComparer<TKey> equalityComparer = iequalityComparer_0;
		if (equalityComparer == null)
		{
			int num3 = gparam_0.GetHashCode() & 0x7FFFFFFF;
			result = array[num3 % num] - 1;
			if (default(TKey) != null)
			{
				while ((uint)result < (uint)num && (array2[result].int_0 != num3 || !EqualityComparer<TKey>.Default.Equals(array2[result].gparam_0, gparam_0)))
				{
					result = array2[result].int_1;
					if (num2 >= num)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num2++;
				}
			}
			else
			{
				EqualityComparer<TKey> equalityComparer2 = EqualityComparer<TKey>.Default;
				while ((uint)result < (uint)num && (array2[result].int_0 != num3 || !equalityComparer2.Equals(array2[result].gparam_0, gparam_0)))
				{
					result = array2[result].int_1;
					if (num2 >= num)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num2++;
				}
			}
		}
		else
		{
			int num4 = equalityComparer.GetHashCode(gparam_0) & 0x7FFFFFFF;
			result = array[num4 % num] - 1;
			while ((uint)result < (uint)num && (array2[result].int_0 != num4 || !equalityComparer.Equals(array2[result].gparam_0, gparam_0)))
			{
				result = array2[result].int_1;
				if (num2 >= num)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num2++;
			}
		}
		return result;
	}

	private int method_2(int int_6)
	{
		int_1 = HashHelpers.GetPrime(int_6);
		int_3 = -1;
		int_0 = arrayPool_0.Rent(int_1);
		Array.Clear(int_0, 0, int_0.Length);
		struct52_0 = arrayPool_1.Rent(int_1);
		return int_1;
	}

	private bool method_3(TKey gparam_0, TValue gparam_1, InsertionBehavior insertionBehavior_0)
	{
		if (gparam_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		if (int_0 == null || int_1 == 0)
		{
			method_2(0);
		}
		Struct52[] array = struct52_0;
		IEqualityComparer<TKey> equalityComparer = iequalityComparer_0;
		int num = int_1;
		int num2 = (equalityComparer?.GetHashCode(gparam_0) ?? gparam_0.GetHashCode()) & 0x7FFFFFFF;
		int num3 = 0;
		ref int reference = ref int_0[num2 % num];
		int num4 = reference - 1;
		if (equalityComparer == null)
		{
			if (default(TKey) != null)
			{
				while ((uint)num4 < (uint)num)
				{
					if (array[num4].int_0 != num2 || !EqualityComparer<TKey>.Default.Equals(array[num4].gparam_0, gparam_0))
					{
						num4 = array[num4].int_1;
						if (num3 >= num)
						{
							ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
						}
						num3++;
						continue;
					}
					switch (insertionBehavior_0)
					{
					case InsertionBehavior.OverwriteExisting:
						array[num4].gparam_1 = gparam_1;
						int_5++;
						return true;
					case InsertionBehavior.ThrowOnExisting:
						ThrowHelper.ThrowAddingDuplicateWithKeyArgumentException(gparam_0);
						break;
					}
					return false;
				}
			}
			else
			{
				EqualityComparer<TKey> equalityComparer2 = EqualityComparer<TKey>.Default;
				while ((uint)num4 < (uint)num)
				{
					if (array[num4].int_0 != num2 || !equalityComparer2.Equals(array[num4].gparam_0, gparam_0))
					{
						num4 = array[num4].int_1;
						if (num3 >= num)
						{
							ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
						}
						num3++;
						continue;
					}
					switch (insertionBehavior_0)
					{
					case InsertionBehavior.OverwriteExisting:
						array[num4].gparam_1 = gparam_1;
						int_5++;
						return true;
					case InsertionBehavior.ThrowOnExisting:
						ThrowHelper.ThrowAddingDuplicateWithKeyArgumentException(gparam_0);
						break;
					}
					return false;
				}
			}
		}
		else
		{
			while ((uint)num4 < (uint)num)
			{
				if (array[num4].int_0 != num2 || !equalityComparer.Equals(array[num4].gparam_0, gparam_0))
				{
					num4 = array[num4].int_1;
					if (num3 >= num)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num3++;
					continue;
				}
				switch (insertionBehavior_0)
				{
				case InsertionBehavior.OverwriteExisting:
					array[num4].gparam_1 = gparam_1;
					int_5++;
					return true;
				case InsertionBehavior.ThrowOnExisting:
					ThrowHelper.ThrowAddingDuplicateWithKeyArgumentException(gparam_0);
					break;
				}
				return false;
			}
		}
		bool flag = false;
		int num5;
		if (int_4 > 0)
		{
			num5 = int_3;
			flag = true;
			int_4--;
		}
		else
		{
			int num6 = int_2;
			if (num6 == num)
			{
				Resize();
				num = int_1;
				reference = ref int_0[num2 % num];
			}
			num5 = num6;
			int_2 = num6 + 1;
			array = struct52_0;
		}
		ref Struct52 reference2 = ref array[num5];
		if (flag)
		{
			int_3 = reference2.int_1;
		}
		reference2.int_0 = num2;
		reference2.int_1 = reference - 1;
		reference2.gparam_0 = gparam_0;
		reference2.gparam_1 = gparam_1;
		reference = num5 + 1;
		int_5++;
		if (default(TKey) == null && num3 > 100 && equalityComparer is NonRandomizedStringEqualityComparer)
		{
			iequalityComparer_0 = null;
			Resize(num, forceNewHashCodes: true);
		}
		return true;
	}

	public virtual void OnDeserialization(object sender)
	{
		HashHelpers.SerializationInfoTable.TryGetValue(this, out var value);
		if (value == null)
		{
			return;
		}
		int @int = value.GetInt32("Version");
		int int2 = value.GetInt32("HashSize");
		iequalityComparer_0 = (IEqualityComparer<TKey>)value.GetValue("Comparer", typeof(IEqualityComparer<TKey>));
		if (int2 != 0)
		{
			method_2(int2);
			KeyValuePair<TKey, TValue>[] array = (KeyValuePair<TKey, TValue>[])value.GetValue("KeyValuePairs", typeof(KeyValuePair<TKey, TValue>[]));
			if (array == null)
			{
				throw new SerializationException("Serialized PooledDictionary missing data.");
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Key != null)
				{
					Add(array[i].Key, array[i].Value);
					continue;
				}
				throw new SerializationException("Serialized PooledDictionary had null key.");
			}
		}
		else
		{
			int_0 = null;
		}
		int_5 = @int;
		HashHelpers.SerializationInfoTable.Remove(this);
	}

	private void Resize()
	{
		Resize(HashHelpers.ExpandPrime(int_2), forceNewHashCodes: false);
	}

	private void Resize(int newSize, bool forceNewHashCodes)
	{
		int num = int_2;
		int[] array;
		Struct52[] array2;
		bool flag;
		if (int_0.Length >= newSize && struct52_0.Length >= newSize)
		{
			Array.Clear(int_0, 0, int_0.Length);
			Array.Clear(struct52_0, int_1, newSize - int_1);
			array = int_0;
			array2 = struct52_0;
			flag = false;
		}
		else
		{
			array = arrayPool_0.Rent(newSize);
			array2 = arrayPool_1.Rent(newSize);
			Array.Clear(array, 0, array.Length);
			Array.Copy(struct52_0, 0, array2, 0, num);
			flag = true;
		}
		int num2;
		if (default(TKey) == null && forceNewHashCodes)
		{
			for (int i = 0; i < num; i++)
			{
				if (array2[i].int_0 >= 0)
				{
					array2[i].int_0 = array2[i].gparam_0.GetHashCode() & 0x7FFFFFFF;
				}
			}
			num2 = 0;
		}
		else
		{
			num2 = 0;
		}
		for (int j = num2; j < num; j++)
		{
			if (array2[j].int_0 >= 0)
			{
				int num3 = array2[j].int_0 % newSize;
				array2[j].int_1 = array[num3] - 1;
				array[num3] = j + 1;
			}
		}
		if (flag)
		{
			method_4();
			int_0 = array;
			struct52_0 = array2;
		}
		int_1 = newSize;
	}

	public bool Remove(TKey key)
	{
		if (key == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		int[] array = int_0;
		Struct52[] array2 = struct52_0;
		int num = 0;
		if (int_1 > 0)
		{
			int num2 = (iequalityComparer_0?.GetHashCode(key) ?? key.GetHashCode()) & 0x7FFFFFFF;
			int num3 = num2 % int_1;
			int num4 = -1;
			int num5 = array[num3] - 1;
			while (num5 >= 0)
			{
				ref Struct52 reference = ref array2[num5];
				if (reference.int_0 != num2 || !(iequalityComparer_0?.Equals(reference.gparam_0, key) ?? EqualityComparer<TKey>.Default.Equals(reference.gparam_0, key)))
				{
					num4 = num5;
					num5 = reference.int_1;
					if (num >= int_1)
					{
						ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
					}
					num++;
					continue;
				}
				if (num4 < 0)
				{
					array[num3] = reference.int_1 + 1;
				}
				else
				{
					array2[num4].int_1 = reference.int_1;
				}
				reference.int_0 = -1;
				reference.int_1 = int_3;
				if (bool_0)
				{
					reference.gparam_0 = default(TKey);
				}
				if (bool_1)
				{
					reference.gparam_1 = default(TValue);
				}
				int_3 = num5;
				int_4++;
				int_5++;
				return true;
			}
		}
		return false;
	}

	public bool Remove(TKey key, out TValue value)
	{
		if (key == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		int[] array = int_0;
		Struct52[] array2 = struct52_0;
		int num = 0;
		int num2 = (iequalityComparer_0?.GetHashCode(key) ?? key.GetHashCode()) & 0x7FFFFFFF;
		int num3 = num2 % int_1;
		int num4 = -1;
		int num5 = array[num3] - 1;
		ref Struct52 reference;
		while (true)
		{
			if (num5 >= 0)
			{
				reference = ref array2[num5];
				if (reference.int_0 == num2 && (iequalityComparer_0?.Equals(reference.gparam_0, key) ?? EqualityComparer<TKey>.Default.Equals(reference.gparam_0, key)))
				{
					break;
				}
				num4 = num5;
				num5 = reference.int_1;
				if (num >= int_1)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num++;
				continue;
			}
			value = default(TValue);
			return false;
		}
		if (num4 < 0)
		{
			array[num3] = reference.int_1 + 1;
		}
		else
		{
			array2[num4].int_1 = reference.int_1;
		}
		value = reference.gparam_1;
		reference.int_0 = -1;
		reference.int_1 = int_3;
		if (bool_0)
		{
			reference.gparam_0 = default(TKey);
		}
		if (bool_1)
		{
			reference.gparam_1 = default(TValue);
		}
		int_3 = num5;
		int_4++;
		return true;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		int num = method_1(key);
		if (num >= 0)
		{
			value = struct52_0[num].gparam_1;
			return true;
		}
		value = default(TValue);
		return false;
	}

	public bool TryAdd(TKey key, TValue value)
	{
		return method_3(key, value, InsertionBehavior.None);
	}

	public TValue GetOrAdd(TKey key, TValue addValue)
	{
		if (TryGetValue(key, out var value))
		{
			return value;
		}
		Add(key, addValue);
		return addValue;
	}

	public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
	{
		if (TryGetValue(key, out var value))
		{
			return value;
		}
		TValue val = valueFactory(key);
		Add(key, val);
		return val;
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
	{
		method_0(array, index);
	}

	void ICollection.CopyTo(Array array, int index)
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
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
		}
		if ((uint)index > (uint)array.Length)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (array.Length - index < Count)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
		}
		if (!(array is KeyValuePair<TKey, TValue>[] keyValuePair_))
		{
			if (array is DictionaryEntry[] array2)
			{
				Struct52[] array3 = struct52_0;
				for (int i = 0; i < int_2; i++)
				{
					if (array3[i].int_0 >= 0)
					{
						array2[index++] = new DictionaryEntry(array3[i].gparam_0, array3[i].gparam_1);
					}
				}
				return;
			}
			if (array is object[] array4)
			{
				try
				{
					int num = int_2;
					Struct52[] array5 = struct52_0;
					for (int j = 0; j < num; j++)
					{
						if (array5[j].int_0 >= 0)
						{
							array4[index++] = new KeyValuePair<TKey, TValue>(array5[j].gparam_0, array5[j].gparam_1);
						}
					}
					return;
				}
				catch (ArrayTypeMismatchException)
				{
					ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
					return;
				}
			}
			ThrowHelper.ThrowArgumentException_Argument_InvalidArrayType();
		}
		else
		{
			method_0(keyValuePair_, index);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	public int EnsureCapacity(int capacity)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
		}
		int num = int_1;
		if (num < capacity)
		{
			int_5++;
			if (int_0 != null && int_1 != 0)
			{
				int prime = HashHelpers.GetPrime(capacity);
				Resize(prime, forceNewHashCodes: false);
				return prime;
			}
			return method_2(capacity);
		}
		return num;
	}

	public void TrimExcess()
	{
		TrimExcess(Count);
	}

	public void TrimExcess(int capacity)
	{
		if (capacity >= Count)
		{
			int prime = HashHelpers.GetPrime(capacity);
			Struct52[] array = struct52_0;
			int[] array2 = int_0;
			int num = ((array != null) ? array.Length : 0);
			if (prime >= num)
			{
				return;
			}
			int num2 = int_2;
			int_5++;
			method_2(prime);
			Struct52[] array3 = struct52_0;
			int[] array4 = int_0;
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				int num4 = array[i].int_0;
				if (num4 >= 0)
				{
					ref Struct52 reference = ref array3[num3];
					reference = array[i];
					int num5 = num4 % prime;
					reference.int_1 = array4[num5] - 1;
					array4[num5] = num3 + 1;
					num3++;
				}
			}
			int_2 = num3;
			int_1 = prime;
			int_4 = 0;
			arrayPool_0.Return(array2);
			arrayPool_1.Return(array3, bool_0 || bool_1);
			return;
		}
		throw new ArgumentOutOfRangeException("capacity");
	}

	private void method_4()
	{
		Struct52[] array = struct52_0;
		if (array != null && array.Length != 0)
		{
			try
			{
				arrayPool_1.Return(struct52_0, bool_0 || bool_1);
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
		struct52_0 = null;
		int_0 = null;
	}

	private static bool smethod_0(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	private static bool smethod_1(ClearMode clearMode_0)
	{
		return clearMode_0 != ClearMode.Never;
	}

	private static bool smethod_2(object object_2)
	{
		if (object_2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		return object_2 is TKey;
	}

	void IDictionary.Add(object key, object value)
	{
		if (key == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
		}
		ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
		try
		{
			TKey key2 = (TKey)key;
			try
			{
				Add(key2, (TValue)value);
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
			}
		}
		catch (InvalidCastException)
		{
			ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
		}
	}

	bool IDictionary.Contains(object key)
	{
		if (!smethod_2(key))
		{
			return false;
		}
		return ContainsKey((TKey)key);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	void IDictionary.Remove(object key)
	{
		if (smethod_2(key))
		{
			Remove((TKey)key);
		}
	}

	public void Dispose()
	{
		method_4();
		int_2 = 0;
		int_1 = 0;
		int_3 = -1;
		int_4 = 0;
	}

	static PooledDictionary()
	{
		Class72.smethod_20();
		arrayPool_0 = Pools<int>.Local;
		arrayPool_1 = Pools<Struct52>.Local;
	}

	internal static bool smethod_3()
	{
		return object_1 == null;
	}

	internal static object smethod_4()
	{
		return object_1;
	}
}
