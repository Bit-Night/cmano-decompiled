using System;
using System.Collections;

namespace Nini.Util;

public class OrderedList : ICollection, IEnumerable, IDictionary
{
	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	public int Count => arrayList_0.Count;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object this[int index]
	{
		get
		{
			return ((DictionaryEntry)arrayList_0[index]).Value;
		}
		set
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			object key = ((DictionaryEntry)arrayList_0[index]).Key;
			arrayList_0[index] = new DictionaryEntry(key, value);
			hashtable_0[key] = value;
		}
	}

	public object this[object key]
	{
		get
		{
			return hashtable_0[key];
		}
		set
		{
			if (!hashtable_0.Contains(key))
			{
				Add(key, value);
				return;
			}
			hashtable_0[key] = value;
			hashtable_0[method_0(key)] = new DictionaryEntry(key, value);
		}
	}

	public ICollection Keys
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				arrayList.Add(((DictionaryEntry)arrayList_0[i]).Key);
			}
			return arrayList;
		}
	}

	public ICollection Values
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				arrayList.Add(((DictionaryEntry)arrayList_0[i]).Value);
			}
			return arrayList;
		}
	}

	public object SyncRoot => this;

	public void Add(object key, object value)
	{
		hashtable_0.Add(key, value);
		arrayList_0.Add(new DictionaryEntry(key, value));
	}

	public void Clear()
	{
		hashtable_0.Clear();
		arrayList_0.Clear();
	}

	public bool Contains(object key)
	{
		return hashtable_0.Contains(key);
	}

	public void CopyTo(Array array, int index)
	{
		hashtable_0.CopyTo(array, index);
	}

	public void CopyTo(DictionaryEntry[] array, int index)
	{
		hashtable_0.CopyTo(array, index);
	}

	public void Insert(int index, object key, object value)
	{
		if (index > Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		hashtable_0.Add(key, value);
		arrayList_0.Insert(index, new DictionaryEntry(key, value));
	}

	public void Remove(object key)
	{
		hashtable_0.Remove(key);
		arrayList_0.RemoveAt(method_0(key));
	}

	public void RemoveAt(int index)
	{
		if (index >= Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		hashtable_0.Remove(((DictionaryEntry)arrayList_0[index]).Key);
		arrayList_0.RemoveAt(index);
	}

	public IEnumerator GetEnumerator()
	{
		return new OrderedListEnumerator(arrayList_0);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new OrderedListEnumerator(arrayList_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OrderedListEnumerator(arrayList_0);
	}

	private int method_0(object object_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				if (((DictionaryEntry)arrayList_0[num]).Key.Equals(object_0))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	static OrderedList()
	{
		Class72.smethod_20();
	}
}
