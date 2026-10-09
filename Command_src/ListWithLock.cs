using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListWithLock<T> : IEnumerable<T>, IEnumerable
{
	private List<T> list_0 = new List<T>();

	private static object object_0;

	internal static object object_1;

	public List<T> Raw
	{
		get
		{
			lock (object_0)
			{
				return list_0;
			}
		}
	}

	public ListWithLock()
	{
	}

	public ListWithLock(IEnumerable<T> source)
	{
		lock (object_0)
		{
			list_0 = new List<T>(source);
		}
	}

	public void Clear()
	{
		lock (object_0)
		{
			list_0.Clear();
		}
	}

	public void Add(T value)
	{
		lock (object_0)
		{
			list_0.Add(value);
		}
	}

	public void Add(List<T> values)
	{
		lock (object_0)
		{
			list_0.AddRange(values);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		lock (object_0)
		{
			return Raw.GetEnumerator();
		}
	}

	public bool Remove(T item)
	{
		lock (object_0)
		{
			return list_0.Remove(item);
		}
	}

	public int Remove(Predicate<T> predicate)
	{
		lock (object_0)
		{
			return list_0.RemoveAll(predicate);
		}
	}

	public T Yank(Func<T, bool> predicate)
	{
		lock (object_0)
		{
			T val = list_0.Where(predicate).First();
			if (val != null)
			{
				list_0.Remove(val);
			}
			return val;
		}
	}

	public T Yank(Func<T, int, bool> predicate)
	{
		lock (object_0)
		{
			T val = list_0.Where(predicate).First();
			if (val != null)
			{
				list_0.Remove(val);
			}
			return val;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		lock (object_0)
		{
			return ((IEnumerable)list_0).GetEnumerator();
		}
	}

	static ListWithLock()
	{
		Class72.smethod_20();
		object_0 = new object();
	}

	internal static bool smethod_0()
	{
		return object_1 == null;
	}

	internal static object smethod_1()
	{
		return object_1;
	}
}
