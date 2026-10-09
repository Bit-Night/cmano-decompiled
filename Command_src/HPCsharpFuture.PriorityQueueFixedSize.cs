using System;

namespace HPCsharpFuture;

public class PriorityQueueFixedSize<T> where T : IComparable<T>
{
	private T[] gparam_0;

	private int int_0;

	internal static object object_0;

	public PriorityQueueFixedSize(int maxLength)
	{
		gparam_0 = new T[maxLength];
		int_0 = 0;
	}

	public void Enqueue(T item)
	{
		gparam_0[int_0++] = item;
		int num = int_0 - 1;
		while (num > 0)
		{
			int num2 = (num - 1) / 2;
			if (gparam_0[num].CompareTo(gparam_0[num2]) < 0)
			{
				T val = gparam_0[num];
				gparam_0[num] = gparam_0[num2];
				gparam_0[num2] = val;
				num = num2;
				continue;
			}
			break;
		}
	}

	public T Dequeue()
	{
		int num = int_0 - 1;
		T result = gparam_0[0];
		gparam_0[0] = gparam_0[num];
		int_0--;
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
			T val;
			if (num4 <= num)
			{
				ref readonly T reference = ref gparam_0[num4];
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				T other = gparam_0[num3];
				if (reference.CompareTo(other) < 0)
				{
					num3 = num4;
				}
			}
			ref readonly T reference2 = ref gparam_0[num2];
			val = default(T);
			if (val == null)
			{
				val = reference2;
				reference2 = ref val;
			}
			T other2 = gparam_0[num3];
			if (reference2.CompareTo(other2) <= 0)
			{
				break;
			}
			T val2 = gparam_0[num2];
			gparam_0[num2] = gparam_0[num3];
			gparam_0[num3] = val2;
			num2 = num3;
		}
		return result;
	}

	public T Peek()
	{
		return gparam_0[0];
	}

	public int Length()
	{
		return int_0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < int_0; i++)
		{
			text = text + gparam_0[i].ToString() + " ";
		}
		return text + Class72.smethod_14(1937456) + int_0;
	}

	public bool IsConsistent()
	{
		if (int_0 == 0)
		{
			return true;
		}
		int num = int_0 - 1;
		for (int i = 0; i < int_0; i++)
		{
			int num2 = 2 * i + 1;
			int num3 = 2 * i + 2;
			T val;
			if (num2 <= num)
			{
				ref readonly T reference = ref gparam_0[i];
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				T other = gparam_0[num2];
				if (reference.CompareTo(other) > 0)
				{
					return false;
				}
			}
			if (num3 <= num)
			{
				ref readonly T reference2 = ref gparam_0[i];
				val = default(T);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
				}
				T other2 = gparam_0[num3];
				if (reference2.CompareTo(other2) > 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	static PriorityQueueFixedSize()
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
