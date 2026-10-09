using System;
using System.Numerics;
using System.Threading.Tasks;
using HPCsharp.Algorithms;

namespace HPCsharp.ParallelAlgorithms;

public static class Addition
{
	public static int[] AddSse(this int[] arrayA, int[] arrayB)
	{
		return arrayA.smethod_0(arrayB, 0, arrayA.Length - 1);
	}

	public static int[] AddSse(this int[] arrayA, int[] arrayB, int start, int length)
	{
		return arrayA.smethod_0(arrayB, start, start + length - 1);
	}

	private static int[] smethod_0(this object object_0, object object_1, int int_0, int int_1)
	{
		int[] array = new int[((Array)object_0).Length];
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector<int> vector = new Vector<int>((int[])object_0, i);
			Vector<int> vector2 = new Vector<int>((int[])object_1, i);
			(vector + vector2).CopyTo(array, i);
		}
		for (; i <= int_1; i++)
		{
			array[i] = ((int[])object_0)[i] + ((int[])object_1)[i];
		}
		return array;
	}

	public static void AddToSse(this int[] arrayA, int[] arrayB)
	{
		arrayA.smethod_1(arrayB, 0, arrayA.Length - 1);
	}

	public static void AddToSse(this int[] arrayA, int[] arrayB, int start, int length)
	{
		arrayA.smethod_1(arrayB, start, start + length - 1);
	}

	private static void smethod_1(this object object_0, object object_1, int int_0, int int_1)
	{
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector<int> vector = new Vector<int>((int[])object_0, i);
			Vector<int> vector2 = new Vector<int>((int[])object_1, i);
			(vector + vector2).CopyTo((int[])object_0, i);
		}
		for (; i <= int_1; i++)
		{
			((int[])object_0)[i] += ((int[])object_1)[i];
		}
	}

	public static void AddToSse(this uint[] arrayA, uint[] arrayB)
	{
		arrayA.smethod_2(arrayB, 0, arrayA.Length - 1);
	}

	public static void AddToSse(this uint[] arrayA, uint[] arrayB, int start, int length)
	{
		arrayA.smethod_2(arrayB, start, start + length - 1);
	}

	private static void smethod_2(this object object_0, object object_1, int int_0, int int_1)
	{
		int num = int_0 + (int_1 - int_0 + 1) / Vector<uint>.Count * Vector<uint>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector<uint> vector = new Vector<uint>((uint[])object_0, i);
			Vector<uint> vector2 = new Vector<uint>((uint[])object_1, i);
			(vector + vector2).CopyTo((uint[])object_0, i);
		}
		for (; i <= int_1; i++)
		{
			((uint[])object_0)[i] += ((uint[])object_1)[i];
		}
	}

	private static void smethod_3(this object object_0, object object_1)
	{
		object_0.smethod_5(object_1, 0, ((Array)object_0).Length - 1);
	}

	private static void smethod_4(this object object_0, object object_1, int int_0, int int_1)
	{
		object_0.smethod_5(object_1, int_0, int_0 + int_1 - 1);
	}

	private static void smethod_5(this object object_0, object object_1, int int_0, int int_1)
	{
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<int>.Count * 2) * (Vector<int>.Count * 2);
		int count = Vector<int>.Count;
		int num2 = Vector<int>.Count * 2;
		int i = int_0;
		int num3 = int_0 + count;
		while (i < num)
		{
			Vector<int> vector = new Vector<int>((int[])object_0, i);
			Vector<int> vector2 = new Vector<int>((int[])object_1, i);
			Vector<int> vector3 = new Vector<int>((int[])object_0, num3);
			Vector<int> vector4 = new Vector<int>((int[])object_1, num3);
			vector += vector2;
			vector3 += vector4;
			vector.CopyTo((int[])object_0, i);
			vector3.CopyTo((int[])object_0, num3);
			i += num2;
			num3 += num2;
		}
		for (; i <= int_1; i++)
		{
			((int[])object_0)[i] += ((int[])object_1)[i];
		}
	}

	private static void smethod_6(this int[] int_0, int[] int_1, int int_2, int int_3, int int_4 = 16384)
	{
		if (int_2 > int_3)
		{
			return;
		}
		if (int_3 - int_2 + 1 <= int_4)
		{
			int_0.smethod_1(int_1, int_2, int_3);
			return;
		}
		int int_5 = (int_3 + int_2) / 2;
		Parallel.Invoke(delegate
		{
			int_0.smethod_6(int_1, int_2, int_5, int_4);
		}, delegate
		{
			int_0.smethod_6(int_1, int_5 + 1, int_3, int_4);
		});
	}

	public static void AddToSsePar(this int[] arrayA, int[] arrayB, int thresholdParallel = 16384)
	{
		arrayA.smethod_6(arrayB, 0, arrayA.Length - 1, thresholdParallel);
	}

	public static void AddToSsePar(this int[] arrayA, int[] arrayB, int startIndex, int length, int thresholdParallel = 16384)
	{
		arrayA.smethod_6(arrayB, startIndex, startIndex + length - 1, thresholdParallel);
	}

	private static void smethod_7(this int[] int_0, int[] int_1, int int_2, int int_3, int int_4 = 16384)
	{
		if (int_2 > int_3)
		{
			return;
		}
		if (int_3 - int_2 + 1 > int_4)
		{
			int int_5 = (int_3 + int_2) / 2;
			Parallel.Invoke(delegate
			{
				int_0.smethod_7(int_1, int_2, int_5, int_4);
			}, delegate
			{
				int_0.smethod_7(int_1, int_5 + 1, int_3, int_4);
			});
		}
		else
		{
			HPCsharp.Algorithms.Addition.AddTo(int_0, int_1, int_2, int_3 - int_2 + 1);
		}
	}

	public static void AddToPar(this int[] arrayA, int[] arrayB, int thresholdParallel = 16384)
	{
		arrayA.smethod_7(arrayB, 0, arrayA.Length - 1, thresholdParallel);
	}

	public static void AddToPar(this int[] arrayA, int[] arrayB, int startIndex, int length, int thresholdParallel = 16384)
	{
		arrayA.smethod_7(arrayB, startIndex, startIndex + length - 1, thresholdParallel);
	}

	static Addition()
	{
		Class72.smethod_20();
	}
}
