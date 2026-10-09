using System;

namespace HPCsharp;

public class WriteThruExternalBuffer<T>
{
	private int int_0;

	private T[] gparam_0;

	private int int_1;

	private int int_2;

	private T[] gparam_1;

	private int int_3;

	internal static object object_0;

	public WriteThruExternalBuffer(T[] buffer, int startIndex, int bufferSize, T[] destinationArray)
	{
		gparam_0 = buffer;
		int_0 = bufferSize;
		int_1 = startIndex;
		int_2 = startIndex;
		gparam_1 = destinationArray;
		int_3 = 0;
	}

	public void WriteThru(T element)
	{
		if (int_2 < gparam_0.Length)
		{
			gparam_0[int_2++] = element;
			return;
		}
		int num = Math.Min(gparam_0.Length, gparam_1.Length - int_3);
		for (int i = 0; i < num; i++)
		{
			gparam_1[int_3++] = gparam_0[i++];
		}
		int_2 = int_1;
	}

	public void Flush()
	{
		int num = Math.Min(int_2, gparam_1.Length - int_3);
		for (int i = 0; i < num; i++)
		{
			gparam_1[int_3++] = gparam_0[i++];
		}
		int_2 = int_1;
	}

	static WriteThruExternalBuffer()
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
