using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Voronoi;

public class HashSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly Dictionary<T, T> dictionary_0 = new Dictionary<T, T>();

	internal static object object_0;

	public int Count => dictionary_0.Count;

	public bool IsReadOnly => false;

	public void Add(T item)
	{
		dictionary_0.Add(item, item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return dictionary_0.Keys.GetEnumerator();
	}

	public void CopyTo(T[] array, int index)
	{
		dictionary_0.Keys.CopyTo(array, index);
	}

	public void Clear()
	{
		dictionary_0.Clear();
	}

	public bool Contains(T item)
	{
		return dictionary_0.ContainsKey(item);
	}

	public bool Remove(T item)
	{
		return dictionary_0.Remove(item);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return dictionary_0.Keys.GetEnumerator();
	}

	static HashSet()
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
