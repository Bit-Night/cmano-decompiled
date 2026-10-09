using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ConcurrentPagedArray<T> : IEnumerable<KeyValuePair<int, T>>, IEnumerable
{
	private readonly T[][] gparam_0;

	private readonly bool[][] bool_0;

	private volatile int int_0;

	internal static object object_0;

	public int Count => int_0;

	public T this[int key]
	{
		get
		{
			T[] array = Volatile.Read(in gparam_0[key >> 10]);
			if (array != null)
			{
				return array[key & 0x3FF];
			}
			return default(T);
		}
		set
		{
			int num = key >> 10;
			T[] array = Volatile.Read(in gparam_0[num]);
			if (array == null)
			{
				array = method_0(num);
			}
			int num2 = key & 0x3FF;
			bool num3 = !bool_0[num][num2];
			array[num2] = value;
			bool_0[num][num2] = true;
			Thread.MemoryBarrier();
			if (num3)
			{
				Interlocked.Increment(ref int_0);
			}
		}
	}

	public IEnumerable<T> Values
	{
		get
		{
			using IEnumerator<KeyValuePair<int, T>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current.Value;
			}
		}
	}

	public ConcurrentPagedArray(int maxKey = 1048576)
	{
		int num = (maxKey >> 10) + 1;
		gparam_0 = new T[num][];
		bool_0 = new bool[num][];
	}

	public bool ContainsKey(int key)
	{
		int num = key >> 10;
		bool[] array = Volatile.Read(in bool_0[num]);
		if (array != null)
		{
			return array[key & 0x3FF];
		}
		return false;
	}

	public bool TryGetValue(int key, out T value)
	{
		int num = key >> 10;
		T[] array = Volatile.Read(in gparam_0[num]);
		bool[] array2 = Volatile.Read(in bool_0[num]);
		if (array2 != null && array2[key & 0x3FF])
		{
			value = array[key & 0x3FF];
			return true;
		}
		value = default(T);
		return false;
	}

	public bool Remove(int key)
	{
		int num = key >> 10;
		T[] array = Volatile.Read(in gparam_0[num]);
		bool[] array2 = Volatile.Read(in bool_0[num]);
		int result;
		if (array2 != null)
		{
			if (array2[key & 0x3FF])
			{
				int num2 = key & 0x3FF;
				array[num2] = default(T);
				array2[num2] = false;
				Thread.MemoryBarrier();
				Interlocked.Decrement(ref int_0);
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public IEnumerator<KeyValuePair<int, T>> GetEnumerator()
	{
		T[][] pages = gparam_0;
		bool[][] presence = bool_0;
		for (int pageIdx = 0; pageIdx < pages.Length; pageIdx++)
		{
			T[] page = Volatile.Read(in pages[pageIdx]);
			bool[] presPage = Volatile.Read(in presence[pageIdx]);
			if (page == null)
			{
				continue;
			}
			for (int slot = 0; slot < 1024; slot++)
			{
				if (presPage[slot])
				{
					int key = (pageIdx << 10) | slot;
					yield return new KeyValuePair<int, T>(key, page[slot]);
				}
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private T[] method_0(int int_1)
	{
		T[] array = new T[1024];
		bool[] value = new bool[1024];
		Interlocked.CompareExchange(ref bool_0[int_1], value, null);
		return Interlocked.CompareExchange(ref gparam_0[int_1], array, null) ?? array;
	}

	static ConcurrentPagedArray()
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
