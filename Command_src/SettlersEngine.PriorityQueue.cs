using System.Collections.Generic;

namespace SettlersEngine;

internal class PriorityQueue<T> where T : IIndexedObject
{
	protected List<T> InnerList = new List<T>();

	protected IComparer<T> mComparer;

	private static object object_0;

	public int Count => InnerList.Count;

	public PriorityQueue()
	{
		mComparer = Comparer<T>.Default;
	}

	public PriorityQueue(IComparer<T> comparer)
	{
		mComparer = comparer;
	}

	public PriorityQueue(IComparer<T> comparer, int capacity)
	{
		mComparer = comparer;
		InnerList.Capacity = capacity;
	}

	protected void SwitchElements(int i, int j)
	{
		T value = InnerList[i];
		InnerList[i] = InnerList[j];
		InnerList[j] = value;
		T val = InnerList[i];
		val.Index = i;
		val = InnerList[j];
		val.Index = j;
	}

	protected virtual int OnCompare(int i, int j)
	{
		return mComparer.Compare(InnerList[i], InnerList[j]);
	}

	public int Push(T item)
	{
		int num = InnerList.Count;
		item.Index = InnerList.Count;
		InnerList.Add(item);
		while (num != 0)
		{
			int num2 = (num - 1) / 2;
			if (OnCompare(num, num2) >= 0)
			{
				break;
			}
			SwitchElements(num, num2);
			num = num2;
		}
		return num;
	}

	public T Pop()
	{
		T result = InnerList[0];
		int num = 0;
		InnerList[0] = InnerList[InnerList.Count - 1];
		T val = InnerList[0];
		val.Index = 0;
		InnerList.RemoveAt(InnerList.Count - 1);
		result.Index = -1;
		while (true)
		{
			int num2 = num;
			int num3 = 2 * num + 1;
			int num4 = 2 * num + 2;
			if (InnerList.Count > num3 && OnCompare(num, num3) > 0)
			{
				num = num3;
			}
			if (InnerList.Count > num4 && OnCompare(num, num4) > 0)
			{
				num = num4;
			}
			if (num == num2)
			{
				break;
			}
			SwitchElements(num, num2);
		}
		return result;
	}

	public void Update(T item)
	{
		int count = InnerList.Count;
		while (item.Index - 1 >= 0 && OnCompare(item.Index - 1, item.Index) > 0)
		{
			SwitchElements(item.Index - 1, item.Index);
		}
		while (item.Index + 1 < count && OnCompare(item.Index + 1, item.Index) < 0)
		{
			SwitchElements(item.Index + 1, item.Index);
		}
	}

	public T Peek()
	{
		if (InnerList.Count > 0)
		{
			return InnerList[0];
		}
		return default(T);
	}

	public void Clear()
	{
		InnerList.Clear();
	}

	static PriorityQueue()
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
