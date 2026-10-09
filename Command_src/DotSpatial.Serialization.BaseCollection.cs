using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Serialization;

public class BaseCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : class
{
	public class BaseCollectionEnumerator<TE> : IEnumerator<TE>, IDisposable, IEnumerator where TE : class
	{
		private readonly IEnumerator ienumerator_0;

		private static object object_0;

		public TE Current => ienumerator_0.Current as TE;

		object IEnumerator.Current => ienumerator_0.Current as TE;

		public BaseCollectionEnumerator(IEnumerator innerEnumerator)
		{
			ienumerator_0 = innerEnumerator;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return ienumerator_0.MoveNext();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}

		static BaseCollectionEnumerator()
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

	private List<T> list_0;

	private static object object_0;

	[Serialize("InnerList")]
	protected List<T> InnerList
	{
		get
		{
			return list_0;
		}
		set
		{
			if (list_0 != null && list_0.Count > 0)
			{
				foreach (T item in list_0)
				{
					OnExclude(item);
				}
			}
			list_0 = value;
			foreach (T item2 in list_0)
			{
				OnInclude(item2);
			}
			OnInnerListSet();
		}
	}

	public bool IsReadOnly => false;

	public int Count => InnerList.Count;

	public void Add(T item)
	{
		Include(item);
		InnerList.Add(item);
		OnIncludeComplete(item);
		OnInsert(InnerList.IndexOf(item), item);
	}

	public bool Contains(T item)
	{
		return InnerList.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		InnerList.CopyTo(array, arrayIndex);
	}

	public void Move(T item, int newPosition)
	{
		if (!InnerList.Contains(item))
		{
			return;
		}
		int num = InnerList.IndexOf(item);
		if (num != newPosition)
		{
			InnerList.RemoveAt(num);
			if (InnerList.Count <= newPosition)
			{
				InnerList.Add(item);
			}
			else if (newPosition < 0)
			{
				InnerList.Insert(0, item);
			}
			else
			{
				InnerList.Insert(newPosition, item);
			}
			OnMoved(item, InnerList.IndexOf(item));
		}
	}

	public bool Remove(T item)
	{
		if (InnerList.Contains(item))
		{
			int index = InnerList.IndexOf(item);
			InnerList.Remove(item);
			OnRemoveComplete(index, item);
			return true;
		}
		return false;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	public void Clear()
	{
		OnClear();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	protected virtual void OnInnerListSet()
	{
	}

	protected virtual void OnClear()
	{
		List<T> list = new List<T>();
		foreach (T inner in InnerList)
		{
			list.Add(inner);
		}
		foreach (T item in list)
		{
			Remove(item);
		}
	}

	protected virtual void OnInsert(int index, object value)
	{
		T item = value as T;
		Include(item);
	}

	protected virtual void OnInsertComplete(int index, object value)
	{
		T item = value as T;
		OnIncludeComplete(item);
	}

	protected virtual void OnRemoveComplete(int index, object value)
	{
		T item = value as T;
		Exclude(item);
	}

	protected virtual void OnSet(int index, object oldValue, object newValue)
	{
		T item = newValue as T;
		Include(item);
	}

	protected virtual void OnSetComplete(int index, object oldValue, object newValue)
	{
		T item = oldValue as T;
		Exclude(item);
		item = newValue as T;
		OnIncludeComplete(item);
	}

	protected virtual void OnInclude(T item)
	{
	}

	protected virtual void OnMoved(T item, int newPosition)
	{
	}

	protected virtual void OnIncludeComplete(T item)
	{
	}

	protected virtual void OnExclude(T item)
	{
	}

	protected void Include(T item)
	{
		if (!InnerList.Contains(item))
		{
			OnInclude(item);
		}
	}

	protected void Exclude(T item)
	{
		if (!InnerList.Contains(item))
		{
			OnExclude(item);
		}
	}

	public BaseCollection()
	{
		list_0 = new List<T>();
	}

	static BaseCollection()
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
