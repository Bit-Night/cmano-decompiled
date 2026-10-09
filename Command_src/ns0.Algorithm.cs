using System;
using System.Collections.Generic;
using HPCsharp;

namespace ns0;

public static class Algorithm
{
	public static void MergeDivideAndConquerExperimental<T>(T[] src, int aStart, int aEnd, int bStart, int bEnd, T[] dst, int p3, IComparer<T> comparer = null)
	{
		int a = aEnd - aStart + 1;
		int b = bEnd - bStart + 1;
		if (a < b)
		{
			HPCsharp.Algorithm.Swap(ref aStart, ref bStart);
			HPCsharp.Algorithm.Swap(ref aEnd, ref bEnd);
			HPCsharp.Algorithm.Swap(ref a, ref b);
		}
		if (a == 0)
		{
			return;
		}
		if (a + b <= HPCsharp.Algorithm.MergeArrayThreshold)
		{
			Console.WriteLine("Merge: aStart = {0} length1 = {1} bStart = {2} length2 = {3} p3 = {2}", aStart, a, bStart, b, p3);
			HPCsharp.Algorithm.Merge(src, aStart, a, src, bStart, b, dst, p3, comparer);
			return;
		}
		int num = aStart / 2 + aEnd / 2 + (aStart % 2 + aEnd % 2) / 2;
		int num2 = HPCsharp.Algorithm.BinarySearch(src[num], src, bStart, bEnd, comparer);
		int num3 = p3 + (num - aStart) + (num2 - bStart);
		Console.WriteLine("aStart = {0} aEnd = {1} bStart = {2} bEnd = {3} q1 = {4} q2 = {5} q3 = {6} p3 = {7}", aStart, aEnd, bStart, bEnd, num, num2, num3, p3);
		if (num2 > bStart)
		{
			dst[num3] = src[num];
			Console.Write("Before Merge: ");
			T[] array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerExperimental(src, aStart, num - 1, bStart, num2 - 1, dst, p3, comparer);
			Console.Write("Between Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerExperimental(src, num + 1, aEnd, num2, bEnd, dst, num3 + 1, comparer);
			Console.Write("After Both Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
		}
		else
		{
			Console.Write("Before Merge: ");
			T[] array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerExperimental(src, aStart, num - 1, bStart, num2 - 1, dst, p3, comparer);
			Console.Write("Between Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerExperimental(src, num + 1, aEnd, num2, bEnd, dst, num3 + 1, comparer);
			Console.Write("After Both Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
		}
	}

	public static void MergeDivideAndConquerUnrolled<T>(T[] src, int aStart, int aEnd, int bStart, int bEnd, T[] dst, int p3, IComparer<T> comparer = null)
	{
		int num = aEnd - aStart + 1;
		int num2 = bEnd - bStart + 1;
		T[] array;
		if (num >= num2)
		{
			Console.WriteLine("length1 >= length2");
			if (num == 0)
			{
				return;
			}
			if (num + num2 <= HPCsharp.Algorithm.MergeArrayThreshold)
			{
				Console.WriteLine("Merge: aStart = {0} length1 = {1} bStart = {2} length2 = {3} p3 = {2}", aStart, num, bStart, num2, p3);
				HPCsharp.Algorithm.Merge(src, aStart, num, src, bStart, num2, dst, p3, comparer);
				return;
			}
			int num3 = aStart / 2 + aEnd / 2 + (aStart % 2 + aEnd % 2) / 2;
			int num4 = HPCsharp.Algorithm.BinarySearch(src[num3], src, bStart, bEnd, comparer);
			int num5 = p3 + (num3 - aStart) + (num4 - bStart);
			Console.WriteLine("aStart = {0} aEnd = {1} bStart = {2} bEnd = {3} q1 = {4} q2 = {5} q3 = {6} p3 = {7}", aStart, aEnd, bStart, bEnd, num3, num4, num5, p3);
			dst[num5] = src[num3];
			Console.Write("Before Merge: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerUnrolled(src, aStart, num3 - 1, bStart, num4 - 1, dst, p3, comparer);
			Console.Write("Between Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			MergeDivideAndConquerUnrolled(src, num3 + 1, aEnd, num4, bEnd, dst, num5 + 1, comparer);
			Console.Write("After Both Merges: ");
			array = dst;
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i]);
			}
			Console.WriteLine();
			return;
		}
		Console.WriteLine("length2 > length1");
		if (num2 == 0)
		{
			return;
		}
		if (num + num2 <= HPCsharp.Algorithm.MergeArrayThreshold)
		{
			Console.WriteLine("Merge: aStart = {0} length1 = {1} bStart = {2} length2 = {3} p3 = {2}", aStart, num, bStart, num2, p3);
			HPCsharp.Algorithm.Merge(src, aStart, num, src, bStart, num2, dst, p3, comparer);
			return;
		}
		int num6 = bStart / 2 + bEnd / 2 + (bStart % 2 + bEnd % 2) / 2;
		int num7 = HPCsharp.Algorithm.BinarySearch(src[num6], src, aStart, aEnd, comparer);
		int num8 = p3 + (num6 - bStart) + (num7 - aStart);
		Console.WriteLine("aStart = {0} aEnd = {1} bStart = {2} bEnd = {3} q1 = {4} q2 = {5} q3 = {6} p3 = {7}", aStart, aEnd, bStart, bEnd, num6, num7, num8, p3);
		dst[num8] = src[num6];
		Console.Write("Before Merge: ");
		array = dst;
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i]);
		}
		Console.WriteLine();
		MergeDivideAndConquerUnrolled(src, bStart, num6 - 1, aStart, num7 - 1, dst, p3, comparer);
		Console.Write("Between Merges: ");
		array = dst;
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i]);
		}
		Console.WriteLine();
		MergeDivideAndConquerUnrolled(src, num6 + 1, bEnd, num7, aEnd, dst, num8 + 1, comparer);
		Console.Write("After Both Merges: ");
		array = dst;
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i]);
		}
		Console.WriteLine();
	}

	static Algorithm()
	{
		Class72.smethod_20();
	}
}
