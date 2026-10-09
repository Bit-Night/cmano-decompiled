using System;
using System.Collections.Generic;

namespace CSMaterial;

public class LRUCache<K, V>
{
	private int int_0;

	private bool bool_0;

	private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> dictionary_0 = new Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>>();

	private LinkedList<LRUCacheItem<K, V>> linkedList_0 = new LinkedList<LRUCacheItem<K, V>>();

	private static object object_0;

	public LRUCache(int capacity, bool disposeDiscardedObjects)
	{
		int_0 = capacity;
		bool_0 = disposeDiscardedObjects;
	}

	public V get(K key)
	{
		if (dictionary_0.TryGetValue(key, out var value))
		{
			V value2 = value.Value.value;
			linkedList_0.Remove(value);
			linkedList_0.AddLast(value);
			return value2;
		}
		return default(V);
	}

	public void add(K key, V val)
	{
		if (dictionary_0.TryGetValue(key, out var value))
		{
			linkedList_0.Remove(value);
			if (bool_0 && value.Value.value is IDisposable)
			{
				((IDisposable)(object)value.Value.value).Dispose();
			}
		}
		else if (dictionary_0.Count >= int_0)
		{
			method_0();
		}
		LinkedListNode<LRUCacheItem<K, V>> linkedListNode = new LinkedListNode<LRUCacheItem<K, V>>(new LRUCacheItem<K, V>(key, val));
		linkedList_0.AddLast(linkedListNode);
		dictionary_0[key] = linkedListNode;
	}

	private void method_0()
	{
		LinkedListNode<LRUCacheItem<K, V>> first = linkedList_0.First;
		linkedList_0.RemoveFirst();
		dictionary_0.Remove(first.Value.key);
		if (bool_0 && first.Value.value is IDisposable)
		{
			((IDisposable)(object)first.Value.value).Dispose();
		}
	}

	static LRUCache()
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
