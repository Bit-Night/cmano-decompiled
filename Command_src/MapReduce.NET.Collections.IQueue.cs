namespace MapReduce.NET.Collections;

public interface IQueue<K, V>
{
	void Push(K key, V value);
}
