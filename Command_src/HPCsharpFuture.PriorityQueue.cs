using System;
using System.Collections.Generic;

namespace HPCsharpFuture;

public class PriorityQueue<T> where T : IComparable<T>
{
	private List<T> list_0;

	internal static object object_0;

	public PriorityQueue()
	{
		list_0 = new List<T>();
	}

	public void Enqueue(T item)
	{
		list_0.Add(item);
		int num = list_0.Count - 1;
		while (num > 0)
		{
			int num2 = (num - 1) / 2;
			if (list_0[num].CompareTo(list_0[num2]) < 0)
			{
				T value = list_0[num];
				list_0[num] = list_0[num2];
				list_0[num2] = value;
				num = num2;
				continue;
			}
			break;
		}
	}

	public T Dequeue()
	{
		int num = list_0.Count - 1;
		T result = list_0[0];
		list_0[0] = list_0[num];
		list_0.RemoveAt(num);
		num--;
		int num2 = 0;
		while (true)
		{
			int num3 = num2 * 2 + 1;
			if (num3 > num)
			{
				break;
			}
			int num4 = num3 + 1;
			if (num4 <= num && list_0[num4].CompareTo(list_0[num3]) < 0)
			{
				num3 = num4;
			}
			if (list_0[num2].CompareTo(list_0[num3]) <= 0)
			{
				break;
			}
			T value = list_0[num2];
			list_0[num2] = list_0[num3];
			list_0[num3] = value;
			num2 = num3;
		}
		return result;
	}

	public T Peek()
	{
		return list_0[0];
	}

	public int Count()
	{
		return list_0.Count;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < list_0.Count; i++)
		{
			text = text + list_0[i].ToString() + " ";
		}
		return text + Class72.smethod_14(1937436) + list_0.Count;
	}

	public bool IsConsistent()
	{
		if (list_0.Count != 0)
		{
			int num = list_0.Count - 1;
			for (int i = 0; i < list_0.Count; i++)
			{
				int num2 = 2 * i + 1;
				int num3 = 2 * i + 2;
				if (num2 > num || list_0[i].CompareTo(list_0[num2]) <= 0)
				{
					if (num3 <= num && list_0[i].CompareTo(list_0[num3]) > 0)
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return true;
		}
		return true;
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
