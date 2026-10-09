namespace CSMaterial;

internal class LRUCacheItem<K, V>
{
	public K key;

	public V value;

	public LRUCacheItem(K k, V v)
	{
		key = k;
		value = v;
	}

	static LRUCacheItem()
	{
		Class72.smethod_20();
	}
}
