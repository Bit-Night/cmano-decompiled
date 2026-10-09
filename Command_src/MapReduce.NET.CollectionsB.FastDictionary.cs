using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace MapReduce.NET.CollectionsB;

[Serializable]
[ComVisible(false)]
public class FastDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, ISerializable, IDeserializationCallback
{
	private struct Struct45
	{
		public int int_0;

		public int int_1;

		public TKey gparam_0;

		public TValue gparam_1;
	}

	[Serializable]
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator, IDictionaryEnumerator
	{
		private FastDictionary<TKey, TValue> fastDictionary_0;

		private int mbkeObRewsN;

		private int int_0;

		private KeyValuePair<TKey, TValue> keyValuePair_0;

		private int int_1;

		internal const int DictEntry = 1;

		internal const int KeyValuePair = 2;

		public KeyValuePair<TKey, TValue> Current => keyValuePair_0;

		object IEnumerator.Current
		{
			get
			{
				if (int_0 != 0 && int_0 != fastDictionary_0.int_1 + 1)
				{
					if (int_1 == 1)
					{
						return new DictionaryEntry(keyValuePair_0.Key, keyValuePair_0.Value);
					}
					return new KeyValuePair<TKey, TValue>(keyValuePair_0.Key, keyValuePair_0.Value);
				}
				throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (int_0 == 0 || int_0 == fastDictionary_0.int_1 + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return new DictionaryEntry(keyValuePair_0.Key, keyValuePair_0.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (int_0 == 0 || int_0 == fastDictionary_0.int_1 + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return keyValuePair_0.Key;
			}
		}

		object IDictionaryEnumerator.Value
		{
			get
			{
				if (int_0 == 0 || int_0 == fastDictionary_0.int_1 + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return keyValuePair_0.Value;
			}
		}

		internal Enumerator(FastDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
		{
			fastDictionary_0 = dictionary;
			mbkeObRewsN = dictionary.int_2;
			int_0 = 0;
			int_1 = getEnumeratorRetType;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
		}

		public bool MoveNext()
		{
			if (mbkeObRewsN != fastDictionary_0.int_2)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			while ((uint)int_0 < (uint)fastDictionary_0.int_1)
			{
				if (fastDictionary_0.struct45_0[int_0].int_0 < 0)
				{
					int_0++;
					continue;
				}
				keyValuePair_0 = new KeyValuePair<TKey, TValue>(fastDictionary_0.struct45_0[int_0].gparam_0, fastDictionary_0.struct45_0[int_0].gparam_1);
				int_0++;
				return true;
			}
			int_0 = fastDictionary_0.int_1 + 1;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			if (mbkeObRewsN != fastDictionary_0.int_2)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			int_0 = 0;
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

	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
	{
		[Serializable]
		public struct Enumerator : IEnumerator<TKey>, IDisposable, IEnumerator
		{
			private FastDictionary<TKey, TValue> fastDictionary_0;

			private int int_0;

			private int int_1;

			private TKey gparam_0;

			public TKey Current => gparam_0;

			object IEnumerator.Current
			{
				get
				{
					if (int_0 == 0 || int_0 == fastDictionary_0.int_1 + 1)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
					}
					return gparam_0;
				}
			}

			internal Enumerator(FastDictionary<TKey, TValue> dictionary)
			{
				fastDictionary_0 = dictionary;
				int_1 = dictionary.int_2;
				int_0 = 0;
				gparam_0 = default(TKey);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (int_1 != fastDictionary_0.int_2)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
				}
				while (true)
				{
					if ((uint)int_0 < (uint)fastDictionary_0.int_1)
					{
						if (fastDictionary_0.struct45_0[int_0].int_0 >= 0)
						{
							break;
						}
						int_0++;
						continue;
					}
					int_0 = fastDictionary_0.int_1 + 1;
					gparam_0 = default(TKey);
					return false;
				}
				gparam_0 = fastDictionary_0.struct45_0[int_0].gparam_0;
				int_0++;
				return true;
			}

			void IEnumerator.Reset()
			{
				if (int_1 != fastDictionary_0.int_2)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
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

		private FastDictionary<TKey, TValue> fastDictionary_0;

		internal static object object_0;

		public int Count => fastDictionary_0.Count;

		bool ICollection<TKey>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)fastDictionary_0).SyncRoot;

		public KeyCollection(FastDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			fastDictionary_0 = dictionary;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		public void CopyTo(TKey[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index >= 0 && index <= array.Length)
			{
				if (array.Length - index >= fastDictionary_0.Count)
				{
					int int_ = fastDictionary_0.int_1;
					Struct45[] struct45_ = fastDictionary_0.struct45_0;
					for (int i = 0; i < int_; i++)
					{
						if (struct45_[i].int_0 >= 0)
						{
							array[index++] = struct45_[i].gparam_0;
						}
					}
					return;
				}
				throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
			}
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
		}

		void ICollection<TKey>.Add(TKey item)
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}

		void ICollection<TKey>.Clear()
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}

		bool ICollection<TKey>.Contains(TKey item)
		{
			return fastDictionary_0.ContainsKey(item);
		}

		bool ICollection<TKey>.Remove(TKey item)
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array != null)
			{
				if (array.Rank != 1)
				{
					throw new ArgumentException("Arg_RankMultiDimNotSupported");
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new ArgumentException("Arg_NonZeroLowerBound");
				}
				if (index >= 0 && index <= array.Length)
				{
					if (array.Length - index >= fastDictionary_0.Count)
					{
						if (array is TKey[] array2)
						{
							CopyTo(array2, index);
							return;
						}
						if (!(array is object[] array3))
						{
							throw new ArgumentException("Argument_InvalidArrayType");
						}
						int int_ = fastDictionary_0.int_1;
						Struct45[] struct45_ = fastDictionary_0.struct45_0;
						try
						{
							for (int i = 0; i < int_; i++)
							{
								if (struct45_[i].int_0 >= 0)
								{
									array3[index++] = struct45_[i].gparam_0;
								}
							}
							return;
						}
						catch (ArrayTypeMismatchException)
						{
							throw new ArgumentException("Argument_InvalidArrayType");
						}
					}
					throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
				}
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
			}
			throw new ArgumentNullException("array");
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

	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
	{
		[Serializable]
		public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator
		{
			private FastDictionary<TKey, TValue> fastDictionary_0;

			private int int_0;

			private int int_1;

			private TValue gparam_0;

			public TValue Current => gparam_0;

			object IEnumerator.Current
			{
				get
				{
					if (int_0 == 0 || int_0 == fastDictionary_0.int_1 + 1)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
					}
					return gparam_0;
				}
			}

			internal Enumerator(FastDictionary<TKey, TValue> dictionary)
			{
				fastDictionary_0 = dictionary;
				int_1 = dictionary.int_2;
				int_0 = 0;
				gparam_0 = default(TValue);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (int_1 != fastDictionary_0.int_2)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
				}
				while (true)
				{
					if ((uint)int_0 < (uint)fastDictionary_0.int_1)
					{
						if (fastDictionary_0.struct45_0[int_0].int_0 >= 0)
						{
							break;
						}
						int_0++;
						continue;
					}
					int_0 = fastDictionary_0.int_1 + 1;
					gparam_0 = default(TValue);
					return false;
				}
				gparam_0 = fastDictionary_0.struct45_0[int_0].gparam_1;
				int_0++;
				return true;
			}

			void IEnumerator.Reset()
			{
				if (int_1 != fastDictionary_0.int_2)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
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

		private FastDictionary<TKey, TValue> fastDictionary_0;

		internal static object object_0;

		public int Count => fastDictionary_0.Count;

		bool ICollection<TValue>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)fastDictionary_0).SyncRoot;

		public ValueCollection(FastDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			fastDictionary_0 = dictionary;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		public void CopyTo(TValue[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index >= 0 && index <= array.Length)
			{
				if (array.Length - index < fastDictionary_0.Count)
				{
					throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
				}
				int int_ = fastDictionary_0.int_1;
				Struct45[] struct45_ = fastDictionary_0.struct45_0;
				for (int i = 0; i < int_; i++)
				{
					if (struct45_[i].int_0 >= 0)
					{
						array[index++] = struct45_[i].gparam_1;
					}
				}
				return;
			}
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
		}

		void ICollection<TValue>.Add(TValue item)
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}

		bool ICollection<TValue>.Remove(TValue item)
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}

		void ICollection<TValue>.Clear()
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}

		bool ICollection<TValue>.Contains(TValue item)
		{
			return fastDictionary_0.ContainsValue(item);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(fastDictionary_0);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException("Arg_RankMultiDimNotSupported");
			}
			if (array.GetLowerBound(0) == 0)
			{
				if (index >= 0 && index <= array.Length)
				{
					if (array.Length - index >= fastDictionary_0.Count)
					{
						if (!(array is TValue[] array2))
						{
							if (array is object[] array3)
							{
								int int_ = fastDictionary_0.int_1;
								Struct45[] struct45_ = fastDictionary_0.struct45_0;
								try
								{
									for (int i = 0; i < int_; i++)
									{
										if (struct45_[i].int_0 >= 0)
										{
											array3[index++] = struct45_[i].gparam_1;
										}
									}
									return;
								}
								catch (ArrayTypeMismatchException)
								{
									throw new ArgumentException("Argument_InvalidArrayType");
								}
							}
							throw new ArgumentException("Argument_InvalidArrayType");
						}
						CopyTo(array2, index);
						return;
					}
					throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
				}
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
			}
			throw new ArgumentException("Arg_NonZeroLowerBound");
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

	private int[] int_0;

	private Struct45[] struct45_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private IEqualityComparer<TKey> iequalityComparer_0;

	private KeyCollection keyCollection_0;

	private ValueCollection valueCollection_0;

	private object object_0;

	private SerializationInfo serializationInfo_0;

	internal static object object_1;

	public IEqualityComparer<TKey> Comparer => iequalityComparer_0;

	public int Count => int_1 - int_4;

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

	public TValue this[TKey key]
	{
		get
		{
			int num = method_1(key);
			if (num < 0)
			{
				throw new KeyNotFoundException();
			}
			return struct45_0[num].gparam_1;
		}
		set
		{
			Insert(key, value, add: false);
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
				Interlocked.CompareExchange(ref object_0, new object(), null);
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
			if (smethod_1(key))
			{
				int num = method_1((TKey)key);
				if (num >= 0)
				{
					return struct45_0[num].gparam_1;
				}
			}
			return null;
		}
		set
		{
			smethod_0(key);
			smethod_2(value);
			this[(TKey)key] = (TValue)value;
		}
	}

	public FastDictionary()
		: this(1000, (IEqualityComparer<TKey>)null)
	{
	}

	public FastDictionary(int capacity)
		: this(capacity, (IEqualityComparer<TKey>)null)
	{
	}

	public FastDictionary(IEqualityComparer<TKey> comparer)
		: this(0, comparer)
	{
	}

	public FastDictionary(int capacity, IEqualityComparer<TKey> comparer)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("Capacity");
		}
		if (capacity > 0)
		{
			method_2(capacity);
		}
		if (comparer == null)
		{
			comparer = EqualityComparer<TKey>.Default;
		}
		iequalityComparer_0 = comparer;
	}

	public FastDictionary(IDictionary<TKey, TValue> dictionary)
		: this(dictionary, (IEqualityComparer<TKey>)null)
	{
	}

	public FastDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		: this(dictionary?.Count ?? 0, comparer)
	{
		if (dictionary != null)
		{
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
			return;
		}
		throw new ArgumentNullException("Dictionary");
	}

	protected FastDictionary(SerializationInfo info, StreamingContext context)
	{
		serializationInfo_0 = info;
	}

	public void Add(TKey key, TValue value)
	{
		Insert(key, value, add: true);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
	{
		Add(keyValuePair.Key, keyValuePair.Value);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
	{
		int num = method_1(keyValuePair.Key);
		if (num >= 0 && EqualityComparer<TValue>.Default.Equals(struct45_0[num].gparam_1, keyValuePair.Value))
		{
			return true;
		}
		return false;
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
	{
		int num = method_1(keyValuePair.Key);
		if (num >= 0 && EqualityComparer<TValue>.Default.Equals(struct45_0[num].gparam_1, keyValuePair.Value))
		{
			Remove(keyValuePair.Key);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		if (int_1 > 0)
		{
			for (int i = 0; i < int_0.Length; i++)
			{
				int_0[i] = -1;
			}
			Array.Clear(struct45_0, 0, int_1);
			int_3 = -1;
			int_1 = 0;
			int_4 = 0;
			int_2++;
		}
	}

	public bool ContainsKey(TKey key)
	{
		return method_1(key) >= 0;
	}

	public bool ContainsValue(TValue value)
	{
		if (value == null)
		{
			for (int i = 0; i < int_1; i++)
			{
				if (struct45_0[i].int_0 >= 0 && struct45_0[i].gparam_1 == null)
				{
					return true;
				}
			}
		}
		else
		{
			EqualityComparer<TValue> equalityComparer = EqualityComparer<TValue>.Default;
			for (int j = 0; j < int_1; j++)
			{
				if (struct45_0[j].int_0 >= 0 && equalityComparer.Equals(struct45_0[j].gparam_1, value))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void method_0(KeyValuePair<TKey, TValue>[] keyValuePair_0, int int_5)
	{
		if (keyValuePair_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_5 >= 0 && int_5 <= keyValuePair_0.Length)
		{
			if (keyValuePair_0.Length - int_5 >= Count)
			{
				int num = int_1;
				Struct45[] array = struct45_0;
				for (int i = 0; i < num; i++)
				{
					if (array[i].int_0 >= 0)
					{
						keyValuePair_0[int_5++] = new KeyValuePair<TKey, TValue>(array[i].gparam_0, array[i].gparam_1);
					}
				}
				return;
			}
			throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
		}
		throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			info.AddValue("Version", int_2);
			info.AddValue("Comparer", iequalityComparer_0, typeof(IEqualityComparer<TKey>));
			info.AddValue("HashSize", (int_0 != null) ? int_0.Length : 0);
			if (int_0 != null)
			{
				KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[Count];
				method_0(array, 0);
				info.AddValue("KeyValuePairs", array, typeof(KeyValuePair<TKey, TValue>[]));
			}
			return;
		}
		throw new ArgumentNullException("info");
	}

	private int method_1(TKey gparam_0)
	{
		if (gparam_0 == null)
		{
			throw new ArgumentNullException("key");
		}
		if (int_0 != null)
		{
			int num = iequalityComparer_0.GetHashCode(gparam_0) & 0x7FFFFFFF;
			int num2 = int_0[num % int_0.Length];
			while (num2 >= 0)
			{
				if (struct45_0[num2].int_0 != num || !iequalityComparer_0.Equals(struct45_0[num2].gparam_0, gparam_0))
				{
					num2 = struct45_0[num2].int_1;
					continue;
				}
				return num2;
			}
		}
		return -1;
	}

	private void method_2(int int_5)
	{
		int prime = HashHelpers.GetPrime(int_5);
		int_0 = new int[prime];
		for (int i = 0; i < int_0.Length; i++)
		{
			int_0[i] = -1;
		}
		struct45_0 = new Struct45[prime];
		int_3 = -1;
	}

	public int InitOrGetPosition(TKey key)
	{
		return Insert(key, default(TValue), add: true);
	}

	public void StoreAtPosition(int pos, TValue value)
	{
		struct45_0[pos].gparam_1 = value;
		int_2++;
	}

	public TValue GetAtPosition(int pos)
	{
		return struct45_0[pos].gparam_1;
	}

	private int Insert(TKey key, TValue value, bool add)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (int_0 == null)
		{
			method_2(1000);
		}
		int num = iequalityComparer_0.GetHashCode(key) & 0x7FFFFFFF;
		int num2 = int_0[num % int_0.Length];
		while (true)
		{
			if (num2 >= 0)
			{
				if (struct45_0[num2].int_0 == num && iequalityComparer_0.Equals(struct45_0[num2].gparam_0, key))
				{
					break;
				}
				num2 = struct45_0[num2].int_1;
				continue;
			}
			int num3;
			if (int_4 > 0)
			{
				num3 = int_3;
				int_3 = struct45_0[num3].int_1;
				int_4--;
			}
			else
			{
				if (int_1 == struct45_0.Length)
				{
					Resize();
				}
				num3 = int_1;
				int_1++;
			}
			int num4 = num % int_0.Length;
			struct45_0[num3].int_0 = num;
			struct45_0[num3].int_1 = int_0[num4];
			struct45_0[num3].gparam_0 = key;
			struct45_0[num3].gparam_1 = value;
			int_0[num4] = num3;
			int_2++;
			return num3;
		}
		if (add)
		{
			return num2;
		}
		struct45_0[num2].gparam_1 = value;
		int_2++;
		return num2;
	}

	public virtual void OnDeserialization(object sender)
	{
		if (serializationInfo_0 == null)
		{
			return;
		}
		int @int = serializationInfo_0.GetInt32("Version");
		int int2 = serializationInfo_0.GetInt32("HashSize");
		iequalityComparer_0 = (IEqualityComparer<TKey>)serializationInfo_0.GetValue("Comparer", typeof(IEqualityComparer<TKey>));
		if (int2 != 0)
		{
			int_0 = new int[int2];
			for (int i = 0; i < int_0.Length; i++)
			{
				int_0[i] = -1;
			}
			struct45_0 = new Struct45[int2];
			int_3 = -1;
			KeyValuePair<TKey, TValue>[] array = (KeyValuePair<TKey, TValue>[])serializationInfo_0.GetValue("KeyValuePairs", typeof(KeyValuePair<TKey, TValue>[]));
			if (array == null)
			{
				throw new SerializationException("Serialization_MissingKeyValuePairs");
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].Key != null)
				{
					Insert(array[j].Key, array[j].Value, add: true);
					continue;
				}
				throw new SerializationException("Serialization_NullKey");
			}
		}
		else
		{
			int_0 = null;
		}
		int_2 = @int;
		serializationInfo_0 = null;
	}

	private void Resize()
	{
		int prime = HashHelpers.GetPrime(int_1 * 2);
		int[] array = new int[prime];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = -1;
		}
		Struct45[] array2 = new Struct45[prime];
		Array.Copy(struct45_0, 0, array2, 0, int_1);
		for (int j = 0; j < int_1; j++)
		{
			int num = array2[j].int_0 % prime;
			array2[j].int_1 = array[num];
			array[num] = j;
		}
		int_0 = array;
		struct45_0 = array2;
	}

	public bool Remove(TKey key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (int_0 != null)
		{
			int num = iequalityComparer_0.GetHashCode(key) & 0x7FFFFFFF;
			int num2 = num % int_0.Length;
			int num3 = -1;
			int num4 = int_0[num2];
			while (num4 >= 0)
			{
				if (struct45_0[num4].int_0 != num || !iequalityComparer_0.Equals(struct45_0[num4].gparam_0, key))
				{
					num3 = num4;
					num4 = struct45_0[num4].int_1;
					continue;
				}
				if (num3 < 0)
				{
					int_0[num2] = struct45_0[num4].int_1;
				}
				else
				{
					struct45_0[num3].int_1 = struct45_0[num4].int_1;
				}
				struct45_0[num4].int_0 = -1;
				struct45_0[num4].int_1 = int_3;
				struct45_0[num4].gparam_0 = default(TKey);
				struct45_0[num4].gparam_1 = default(TValue);
				int_3 = num4;
				int_4++;
				int_2++;
				return true;
			}
		}
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		int num = method_1(key);
		if (num >= 0)
		{
			value = struct45_0[num].gparam_1;
			return true;
		}
		value = default(TValue);
		return false;
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
	{
		method_0(array, index);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (array != null)
		{
			if (array.Rank != 1)
			{
				throw new ArgumentException("Arg_RankMultiDimNotSupported");
			}
			if (array.GetLowerBound(0) == 0)
			{
				if (index >= 0 && index <= array.Length)
				{
					if (array.Length - index >= Count)
					{
						if (array is KeyValuePair<TKey, TValue>[] keyValuePair_)
						{
							method_0(keyValuePair_, index);
							return;
						}
						if (!(array is DictionaryEntry[]))
						{
							if (!(array is object[] array2))
							{
								throw new ArgumentException("Argument_InvalidArrayType");
							}
							try
							{
								int num = int_1;
								Struct45[] array3 = struct45_0;
								for (int i = 0; i < num; i++)
								{
									if (array3[i].int_0 >= 0)
									{
										array2[index++] = new KeyValuePair<TKey, TValue>(array3[i].gparam_0, array3[i].gparam_1);
									}
								}
								return;
							}
							catch (ArrayTypeMismatchException)
							{
								throw new ArgumentException("Argument_InvalidArrayType");
							}
						}
						DictionaryEntry[] array4 = array as DictionaryEntry[];
						Struct45[] array5 = struct45_0;
						for (int j = 0; j < int_1; j++)
						{
							if (array5[j].int_0 >= 0)
							{
								array4[index++] = new DictionaryEntry(array5[j].gparam_0, array5[j].gparam_1);
							}
						}
						return;
					}
					throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
				}
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
			}
			throw new ArgumentException("Arg_NonZeroLowerBound");
		}
		throw new ArgumentNullException("array");
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	private static void smethod_0(object object_2)
	{
		if (object_2 == null)
		{
			throw new ArgumentNullException("key");
		}
		if (!(object_2 is TKey))
		{
			throw new ArgumentException("Invalid type", "key");
		}
	}

	private static bool smethod_1(object object_2)
	{
		if (object_2 == null)
		{
			throw new ArgumentNullException("key");
		}
		return object_2 is TKey;
	}

	private static void smethod_2(object object_2)
	{
		if (!(object_2 is TValue) && (object_2 != null || typeof(TValue).IsValueType))
		{
			throw new ArgumentException("Invalid type", "value");
		}
	}

	void IDictionary.Add(object key, object value)
	{
		smethod_0(key);
		smethod_2(value);
		Add((TKey)key, (TValue)value);
	}

	bool IDictionary.Contains(object key)
	{
		if (smethod_1(key))
		{
			return ContainsKey((TKey)key);
		}
		return false;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	void IDictionary.Remove(object key)
	{
		if (smethod_1(key))
		{
			Remove((TKey)key);
		}
	}

	static FastDictionary()
	{
		Class72.smethod_20();
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
