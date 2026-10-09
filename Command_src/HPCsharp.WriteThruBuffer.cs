using System;

namespace HPCsharp;

public class WriteThruBuffer<T>
{
	private int int_0;

	private T[] gparam_0;

	private int int_1;

	private T[] gparam_1;

	private int int_2;

	internal static object object_0;

	public WriteThruBuffer(int bufferSize, T[] destinationArray)
	{
		gparam_0 = new T[bufferSize];
		int_0 = bufferSize;
		int_1 = 0;
		gparam_1 = destinationArray;
		int_2 = 0;
	}

	public void WriteThru(T element)
	{
		if (int_1 < gparam_0.Length)
		{
			gparam_0[int_1++] = element;
			return;
		}
		int num = Math.Min(gparam_0.Length, gparam_1.Length - int_2);
		for (int i = 0; i < num; i++)
		{
			gparam_1[int_2++] = gparam_0[i++];
		}
		int_1 = 0;
	}

	public void Flush()
	{
		int num = Math.Min(int_1, gparam_1.Length - int_2);
		for (int i = 0; i < num; i++)
		{
			gparam_1[int_2++] = gparam_0[i++];
		}
		int_1 = 0;
	}

	static WriteThruBuffer()
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
