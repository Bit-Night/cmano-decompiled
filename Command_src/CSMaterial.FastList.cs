using System;
using System.Collections;
using System.Collections.Generic;

namespace CSMaterial;

public sealed class FastList<T> : IEnumerable<T>, IEnumerable
{
	public static readonly FastList<T> Empty;

	private T[] gparam_0;

	private int int_0;

	private int int_1;

	private static object object_0;

	public int Count => int_0;

	public T this[int index]
	{
		get
		{
			return gparam_0[index];
		}
		internal set
		{
			gparam_0[index] = value;
		}
	}

	public FastList()
		: this(4)
	{
	}

	public FastList(int size)
	{
		int_1 = size;
		gparam_0 = new T[size];
	}

	public FastList(FastList<T> list)
	{
		int_1 = list.int_1;
		gparam_0 = (T[])list.gparam_0.Clone();
		int_0 = list.int_0;
	}

	public void Normalize()
	{
		int_0 = gparam_0.Length;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < int_0; i++)
		{
			yield return gparam_0[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public FastList<T> Clone()
	{
		return new FastList<T>
		{
			gparam_0 = (T[])gparam_0.Clone(),
			int_0 = int_0,
			int_1 = int_1
		};
	}

	public bool Contains(T val)
	{
		int num = 0;
		while (true)
		{
			if (num < int_0)
			{
				ref readonly T reference = ref gparam_0[num];
				object obj = val;
				if (reference.Equals(obj))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public T[] ToArray()
	{
		T[] array = new T[int_0];
		Array.Copy(gparam_0, array, int_0);
		return array;
	}

	private T[] method_0()
	{
		return gparam_0;
	}

	public void Clear()
	{
		int_0 = 0;
		gparam_0 = new T[int_1];
	}

	public void AddRange(IEnumerable<T> seq)
	{
		foreach (T item in seq)
		{
			Add(item);
		}
	}

	public void AddRange(FastList<T> arr, int start, int end)
	{
		for (int i = start; i < end; i++)
		{
			Add(arr[i]);
		}
	}

	public void AddRange(T[] arr, int start, int end)
	{
		for (int i = start; i < end; i++)
		{
			Add(arr[i]);
		}
	}

	public void Add(T val)
	{
		if (int_0 == gparam_0.Length)
		{
			T[] destinationArray = new T[(gparam_0.Length == 0) ? 4 : (gparam_0.Length * 2)];
			Array.Copy(gparam_0, 0, destinationArray, 0, int_0);
			gparam_0 = destinationArray;
		}
		gparam_0[int_0++] = val;
	}

	public bool Remove(T val)
	{
		int num = Array.IndexOf(gparam_0, val);
		if (num >= 0)
		{
			int_0--;
			if (num < int_0)
			{
				Array.Copy(gparam_0, num + 1, gparam_0, num, int_0 - num);
			}
			gparam_0[int_0] = default(T);
			return true;
		}
		return false;
	}

	public void Trim()
	{
		if (gparam_0.Length > int_0)
		{
			T[] destinationArray = new T[int_0];
			Array.Copy(gparam_0, destinationArray, int_0);
			gparam_0 = destinationArray;
		}
	}

	static FastList()
	{
		Class72.smethod_20();
		Empty = new FastList<T>();
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
