using System;
using System.Collections;
using System.Collections.Generic;

namespace MapReduce.NET.Collections;

public class CustomDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IDictionary, ICollection
{
	private struct Struct46
	{
		public K gparam_0;

		public int int_0;

		public V gparam_1;

		public uint uint_0;
	}

	private int[] int_0;

	private Struct46[] struct46_0;

	private int int_1;

	private static readonly uint[] uint_0;

	private static object object_0;

	public ICollection<K> Keys
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public ICollection<V> Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public V this[K key]
	{
		get
		{
			return Get(key);
		}
		set
		{
			Add(key, value, overwrite: true);
		}
	}

	public int Count => int_1;

	public bool IsReadOnly => false;

	public bool IsFixedSize
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	ICollection IDictionary.Keys
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	ICollection IDictionary.Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public object this[object key]
	{
		get
		{
			return this[(K)key];
		}
		set
		{
			this[(K)key] = (V)value;
		}
	}

	public bool IsSynchronized
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public object SyncRoot
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public CustomDictionary()
	{
		method_1();
	}

	public int InitOrGetPosition(K key)
	{
		return Add(key, default(V), overwrite: false);
	}

	public V GetAtPosition(int pos)
	{
		return struct46_0[pos].gparam_1;
	}

	public void StoreAtPosition(int pos, V value)
	{
		struct46_0[pos].gparam_1 = value;
	}

	public int Add(K key, V value, bool overwrite)
	{
		if (int_1 >= struct46_0.Length)
		{
			Resize();
		}
		uint hashCode = (uint)key.GetHashCode();
		uint num = hashCode % (uint)int_0.Length;
		int num2 = int_0[num];
		int num3 = int_1;
		if (num2 != -1)
		{
			int num4 = num2;
			do
			{
				Struct46 @struct = struct46_0[num4];
				object obj = @struct.gparam_0;
				if (!key.Equals(obj))
				{
					num4 = @struct.int_0;
					continue;
				}
				if (!overwrite)
				{
					return num4;
				}
				num3 = num4;
				break;
			}
			while (num4 > -1);
			int_1++;
		}
		else
		{
			int_1++;
		}
		int_0[num] = num3;
		struct46_0[num3].int_0 = num2;
		struct46_0[num3].gparam_0 = key;
		struct46_0[num3].gparam_1 = value;
		struct46_0[num3].uint_0 = hashCode;
		return num3;
	}

	private void Resize()
	{
		uint num = method_0();
		int[] array = new int[num];
		Struct46[] array2 = new Struct46[num];
		Array.Copy(struct46_0, array2, int_1 - 1);
		for (int i = 0; i < num; i++)
		{
			array[i] = -1;
		}
		for (int j = 0; j < int_1; j++)
		{
			uint num2 = array2[j].uint_0 % num;
			int num3 = array[num2];
			array[num2] = j;
			if (num3 != -1)
			{
				array2[j].int_0 = num3;
			}
		}
		int_0 = array;
		struct46_0 = array2;
	}

	private uint method_0()
	{
		uint num = (uint)(int_0.Length * 2 + 1);
		int num2 = 0;
		while (true)
		{
			if (num2 < uint_0.Length)
			{
				if (uint_0[num2] >= num)
				{
					break;
				}
				num2++;
				continue;
			}
			throw new NotImplementedException("Too large array");
		}
		return uint_0[num2];
	}

	public V Get(K key)
	{
		int position = GetPosition(key);
		if (position == -1)
		{
			throw new Exception("Key does not exist");
		}
		return struct46_0[position].gparam_1;
	}

	public int GetPosition(K key)
	{
		uint num = (uint)key.GetHashCode() % (uint)int_0.Length;
		int num2 = int_0[num];
		if (num2 == -1)
		{
			return -1;
		}
		int num3 = num2;
		do
		{
			Struct46 @struct = struct46_0[num3];
			object obj = @struct.gparam_0;
			if (!key.Equals(obj))
			{
				num3 = @struct.int_0;
				continue;
			}
			return num3;
		}
		while (num3 != -1);
		return -1;
	}

	public bool ContainsKey(K key)
	{
		return GetPosition(key) != -1;
	}

	public bool Remove(K key)
	{
		throw new NotImplementedException();
	}

	public bool TryGetValue(K key, out V value)
	{
		int position = GetPosition(key);
		if (position == -1)
		{
			value = default(V);
			return false;
		}
		value = struct46_0[position].gparam_1;
		return true;
	}

	public void Add(KeyValuePair<K, V> item)
	{
		if (Add(item.Key, item.Value, overwrite: false) + 1 != int_1)
		{
			throw new Exception("Key already exists");
		}
	}

	void IDictionary<K, V>.Add(K key, V value)
	{
		if (Add(key, value, overwrite: false) + 1 != int_1)
		{
			throw new Exception("Key already exists");
		}
	}

	public void Clear()
	{
		method_1();
	}

	private void method_1()
	{
		int_0 = new int[89];
		struct46_0 = new Struct46[89];
		int_1 = 0;
		for (int i = 0; i < struct46_0.Length; i++)
		{
			int_0[i] = -1;
		}
	}

	public bool Contains(KeyValuePair<K, V> item)
	{
		if (item.Key == null)
		{
			return false;
		}
		if (TryGetValue(item.Key, out var value))
		{
			if (!item.Value.Equals(value))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(KeyValuePair<K, V> item)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		for (int i = 0; i < int_1; i++)
		{
			yield return new KeyValuePair<K, V>(struct46_0[i].gparam_0, struct46_0[i].gparam_1);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		for (int i = 0; i < int_1; i++)
		{
			yield return new KeyValuePair<K, V>(struct46_0[i].gparam_0, struct46_0[i].gparam_1);
		}
	}

	public void Add(object key, object value)
	{
		if (Add((K)key, (V)value, overwrite: false) + 1 != int_1)
		{
			throw new Exception("Key already exists");
		}
	}

	public bool Contains(object key)
	{
		return Contains((K)key);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public void Remove(object key)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(Array array, int index)
	{
		throw new NotImplementedException();
	}

	static CustomDictionary()
	{
		Class72.smethod_20();
		uint_0 = new uint[24]
		{
			89u, 179u, 359u, 719u, 1439u, 2879u, 5779u, 11579u, 23159u, 46327u,
			92657u, 185323u, 370661u, 741337u, 1482707u, 2965421u, 5930887u, 11861791u, 23723599u, 47447201u,
			94894427u, 189788857u, 379577741u, 759155483u
		};
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
