using System;

namespace HPCsharp.Algorithms;

public static class Addition
{
	public static int[] Add(this int[] arrayA, int[] arrayB)
	{
		return arrayA.smethod_0(arrayB, 0, arrayA.Length - 1);
	}

	public static int[] Add(this int[] arrayA, int[] arrayB, int start, int length)
	{
		return arrayA.smethod_0(arrayB, start, start + length - 1);
	}

	private static int[] smethod_0(this object object_0, object object_1, int int_0, int int_1)
	{
		int[] array = new int[((Array)object_0).Length];
		for (int i = int_0; i <= int_1; i++)
		{
			array[i] = ((int[])object_0)[i] + ((int[])object_1)[i];
		}
		return array;
	}

	public static void AddTo(this int[] arrayA, int[] arrayB)
	{
		arrayA.smethod_1(arrayB, 0, arrayA.Length - 1);
	}

	public static void AddTo(this int[] arrayA, int[] arrayB, int start, int length)
	{
		arrayA.smethod_1(arrayB, start, start + length - 1);
	}

	private static void smethod_1(this object object_0, object object_1, int int_0, int int_1)
	{
		for (int i = int_0; i <= int_1; i++)
		{
			((int[])object_0)[i] += ((int[])object_1)[i];
		}
	}

	static Addition()
	{
		Class72.smethod_20();
	}
}
