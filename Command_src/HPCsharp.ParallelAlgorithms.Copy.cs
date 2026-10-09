using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using CSMaterial;

namespace HPCsharp.ParallelAlgorithms;

public static class Copy
{
	public static int theProcessorCount;

	private static void smethod_0<T>(this object object_0, int int_0, object object_1, int int_1, int int_2, (int, int)? nullable_0 = null)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_2 <= 0)
		{
			return;
		}
		var (int_3, int_4) = nullable_0 ?? (65536, Misc.Environment_ProcessorCount);
		if (int_2 > int_3 && int_4 != 1)
		{
			int int_5 = int_2 / 2;
			int int_6 = int_2 - int_5;
			Parallel.Invoke(delegate
			{
				gparam_0.smethod_0<T>(int_0, gparam_1, int_1, int_5, (int_3, int_4));
			}, delegate
			{
				gparam_0.smethod_0<T>(int_0 + int_5, gparam_1, int_1 + int_5, int_6, (int_3, int_4));
			});
		}
		else
		{
			Array.Copy(gparam_0, int_0, gparam_1, int_1, int_2);
		}
	}

	private static void smethod_1<T>(this object object_0, int int_0, object object_1, int int_1, int int_2, (int, int)? nullable_0 = null)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_2 <= 0)
		{
			return;
		}
		if (int_2 > gparam_0.Length - int_0 || int_2 > gparam_1.Length - int_1)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = nullable_0 ?? (65536, 0);
		if (int_2 >= num && num2 != 1)
		{
			int maxDegreeOfParallelism = ((num2 <= 0) ? Misc.Environment_ProcessorCount : num2);
			ParallelOptions parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = maxDegreeOfParallelism
			};
			Parallel.ForEach(Partitioner.Create(int_0, int_0 + int_2), parallelOptions, delegate(Tuple<int, int> range)
			{
				Array.Copy(gparam_0, range.Item1, gparam_1, int_1 + (range.Item1 - int_0), range.Item2 - range.Item1);
			});
		}
		else
		{
			Array.Copy(gparam_0, int_0, gparam_1, int_1, int_2);
		}
	}

	public static void CopyPar<T>(this T[] src, int srcStart, T[] dst, int dstStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (length > 0)
		{
			if (srcStart + length > src.Length || dstStart + length > dst.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
			if (num * num2 < src.Length)
			{
				num = src.Length / num2;
			}
			src.smethod_0<T>(srcStart, dst, dstStart, length, (num, num2));
		}
	}

	public static void CopyPar<T>(this T[] src, T[] dst, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (length > 0)
		{
			if (length > src.Length || length > dst.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
			if (num * num2 < src.Length)
			{
				num = src.Length / num2;
			}
			src.smethod_0<T>(0, dst, 0, length, (num, num2));
		}
	}

	public static void CopyPar<T>(this T[] src, T[] dst, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (src.Length > dst.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Length)
		{
			num = src.Length / num2;
		}
		src.smethod_0<T>(0, dst, 0, src.Length, (num, num2));
	}

	public static void CopyToPar<T>(this T[] src, T[] dst, int dstStart, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (src.Length > dst.Length - dstStart)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Length)
		{
			num = src.Length / num2;
		}
		src.smethod_0<T>(0, dst, dstStart, src.Length, (num, num2));
	}

	public static void CopySse(this int[] src, int srcStart, int[] dst, int dstStart, int length)
	{
		if (length > 0)
		{
			if (length > src.Length - srcStart || length > dst.Length - dstStart)
			{
				throw new ArgumentOutOfRangeException();
			}
			int num = srcStart + length / Vector<int>.Count * Vector<int>.Count;
			int num2 = srcStart;
			int num3 = dstStart;
			while (num2 < num)
			{
				new Vector<int>(src, num2).CopyTo(dst, num3);
				num2 += Vector<int>.Count;
				num3 += Vector<int>.Count;
			}
			int num4 = srcStart + length - 1;
			while (num2 <= num4)
			{
				dst[num3] = src[num2];
				num2++;
				num3++;
			}
		}
	}

	public static void CopySsePar(this int[] src, int srcStart, int[] dst, int dstStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (length <= 0)
		{
			return;
		}
		if (length > src.Length - srcStart || length > dst.Length - dstStart)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = parSettings ?? (65536, 0);
		if (length >= num && num2 != 1)
		{
			int maxDegreeOfParallelism = ((num2 > 0) ? num2 : Misc.Environment_ProcessorCount);
			ParallelOptions parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = maxDegreeOfParallelism
			};
			Parallel.ForEach(Partitioner.Create(srcStart, srcStart + length), parallelOptions, delegate(Tuple<int, int> range)
			{
				CopySse(src, range.Item1, dst, dstStart + (range.Item1 - srcStart), range.Item2 - range.Item1);
			});
		}
		else
		{
			CopySse(src, srcStart, dst, dstStart, length);
		}
	}

	public static T[] ToArrayPar<T>(this T[] src, int srcStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (length <= 0)
		{
			return new T[0];
		}
		if (length > src.Length - srcStart)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Length)
		{
			num = src.Length / num2;
		}
		T[] array = new T[length];
		src.smethod_0<T>(srcStart, array, 0, length, (num, num2));
		return array;
	}

	public static T[] ToArrayPar<T>(this T[] src, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		if (length <= 0)
		{
			return new T[0];
		}
		if (length > src.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Length)
		{
			num = src.Length / num2;
		}
		T[] array = new T[src.Length];
		src.smethod_0<T>(0, array, 0, length, (num, num2));
		return array;
	}

	public static T[] ToArrayPar<T>(this T[] src, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		var (num, num2) = parSettings ?? (65536, Misc.Environment_ProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Length)
		{
			num = src.Length / num2;
		}
		T[] array = new T[src.Length];
		src.smethod_0<T>(0, array, 0, src.Length, (num, num2));
		return array;
	}

	public static void CopyTo<T>(this List<T> src, int srcStart, List<T> dst, int dstStart, int length)
	{
		for (int i = 0; i < length; i++)
		{
			dst[dstStart++] = src[srcStart++];
		}
	}

	private static void smethod_2<T>(this List<T> list_0, int int_0, object object_0, int int_1, int int_2, (int, int)? nullable_0 = null)
	{
		T[] gparam_0 = (T[])object_0;
		if (int_2 <= 0)
		{
			return;
		}
		var (int_3, int_4) = nullable_0 ?? (65536, theProcessorCount);
		if (int_2 > int_3 && int_4 != 1)
		{
			int int_5 = int_2 / 2;
			int int_6 = int_2 - int_5;
			Parallel.Invoke(delegate
			{
				list_0.smethod_2(int_0, gparam_0, int_1, int_5, (int_3, int_4));
			}, delegate
			{
				list_0.smethod_2(int_0 + int_5, gparam_0, int_1 + int_5, int_6, (int_3, int_4));
			});
		}
		else
		{
			list_0.CopyTo(int_0, gparam_0, int_1, int_2);
		}
	}

	public static int ComputeMaxDegreeOfParallelism(int length, int minWorkQuanta, int degreeOfParallelism)
	{
		int num = Math.Min((length + minWorkQuanta - 1) / minWorkQuanta, theProcessorCount);
		if (degreeOfParallelism <= 0)
		{
			return num;
		}
		return Math.Min(num, degreeOfParallelism);
	}

	private static void smethod_3<T>(this List<T> list_0, int int_0, object object_0, int int_1, int int_2, (int, int)? nullable_0 = null)
	{
		T[] gparam_0 = (T[])object_0;
		if (int_2 <= 0)
		{
			return;
		}
		if (int_2 > list_0.Count - int_0 || int_2 > gparam_0.Length - int_1)
		{
			throw new ArgumentOutOfRangeException();
		}
		var (num, num2) = nullable_0 ?? (65536, 0);
		if (int_2 > num && num2 != 1)
		{
			ParallelOptions parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = ComputeMaxDegreeOfParallelism(int_2, num, num2)
			};
			Parallel.ForEach(Partitioner.Create(int_0, int_0 + int_2), parallelOptions, delegate(Tuple<int, int> range)
			{
				list_0.CopyTo(range.Item1, gparam_0, int_1 + (range.Item1 - int_0), range.Item2 - range.Item1);
			});
		}
		else
		{
			list_0.CopyTo(int_0, gparam_0, int_1, int_2);
		}
	}

	public static T[] ToArrayPar<T>(this List<T> src, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		(int minWorkQuanta, int degreeOfParallelism) obj = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		int num = obj.minWorkQuanta;
		int item = obj.degreeOfParallelism;
		T[] array = new T[src.Count];
		if (num * item < src.Count)
		{
			num = src.Count / item;
		}
		src.smethod_2(0, array, 0, src.Count, (num, item));
		return array;
	}

	public static T[] ToArrayPar<T>(this List<T> src, int srcStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		(int minWorkQuanta, int degreeOfParallelism) obj = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		int num = obj.minWorkQuanta;
		int item = obj.degreeOfParallelism;
		T[] array = new T[length];
		if (num * item < src.Count)
		{
			num = src.Count / item;
		}
		src.smethod_2(srcStart, array, 0, length, (num, item));
		return array;
	}

	public static T[] ToArrayPar<T>(this List<T> src, int srcStart, int dstStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		(int minWorkQuanta, int degreeOfParallelism) obj = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		int num = obj.minWorkQuanta;
		int item = obj.degreeOfParallelism;
		T[] array = new T[src.Count];
		if (num * item < src.Count)
		{
			num = src.Count / item;
		}
		src.smethod_2(srcStart, array, dstStart, length, (num, item));
		return array;
	}

	public static void CopyToPar<T>(this List<T> src, T[] dst, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		var (num, num2) = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Count)
		{
			num = src.Count / num2;
		}
		src.smethod_2(0, dst, 0, src.Count, (num, num2));
	}

	public static void CopyToPar<T>(this List<T> src, T[] dst, int dstStart, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		var (num, num2) = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Count)
		{
			num = src.Count / num2;
		}
		src.smethod_2(0, dst, dstStart, src.Count, (num, num2));
	}

	public static void CopyToPar<T>(this List<T> src, int srcStart, T[] dst, int dstStart, int length, (int minWorkQuanta, int degreeOfParallelism)? parSettings = null)
	{
		var (num, num2) = parSettings ?? (65536, theProcessorCount / SystemAttributes.HyperthreadingNumberOfWays);
		if (num * num2 < src.Count)
		{
			num = src.Count / num2;
		}
		src.smethod_2(srcStart, dst, dstStart, length, (num, num2));
	}

	static Copy()
	{
		Class72.smethod_20();
		theProcessorCount = Misc.Environment_ProcessorCount;
	}
}
