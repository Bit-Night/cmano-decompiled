using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Serialization;

[Serializable]
public class BaseList<T> : BaseCollection<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : class
{
	private static object object_1;

	public T this[int index]
	{
		get
		{
			return base.InnerList[index];
		}
		set
		{
			Exclude(base.InnerList[index]);
			Include(value);
			base.InnerList[index] = value;
			OnIncludeComplete(value);
		}
	}

	public int IndexOf(T item)
	{
		return base.InnerList.IndexOf(item);
	}

	public virtual void Insert(int index, T item)
	{
		method_0(index, item);
	}

	protected virtual void OnInsert(int index, T item)
	{
	}

	protected virtual void OnItemSet(int index, T oldItem, T newItem)
	{
	}

	protected virtual void OnRemoveAt(int index, T item)
	{
	}

	private void method_0(int int_0, T gparam_0)
	{
		if (base.IsReadOnly)
		{
			throw new ReadOnlyException();
		}
		Include(gparam_0);
		base.InnerList.Insert(int_0, gparam_0);
		OnInsert(int_0, gparam_0);
		OnIncludeComplete(gparam_0);
	}

	public void RemoveAt(int index)
	{
		T item = base.InnerList[index];
		base.InnerList.RemoveAt(index);
		OnExclude(item);
	}

	static BaseList()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_2()
	{
		return object_1 == null;
	}

	internal static object smethod_3()
	{
		return object_1;
	}
}
