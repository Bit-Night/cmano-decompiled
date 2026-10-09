using System;
using System.Threading.Tasks;

namespace HPCsharp;

public static class AlgorithmPatterns
{
	public static T DivideAndConquer<T>(this T[] arrayToProcess, int start, int length, Func<T[], int, int, T> baseCase, Func<T, T, T> reduce, int threshold = 16384)
	{
		return DivideAndConquerLR(arrayToProcess, start, start + length - 1, baseCase, reduce, threshold);
	}

	internal static T DivideAndConquerLR<T>(this T[] arrayToProcess, int left, int right, Func<T[], int, int, T> baseCase, Func<T, T, T> reduce, int threshold = 16384)
	{
		T result = default(T);
		if (left > right)
		{
			return result;
		}
		if (right - left + 1 <= threshold)
		{
			return baseCase(arrayToProcess, left, right - left + 1);
		}
		int num = (right + left) / 2;
		T val = default(T);
		result = DivideAndConquerLR(arrayToProcess, left, num, baseCase, reduce, threshold);
		val = DivideAndConquerLR(arrayToProcess, num + 1, right, baseCase, reduce, threshold);
		return reduce(result, val);
	}

	public static T2 DivideAndConquerTwoTypes<T, T2>(this T[] arrayToProcess, int start, int length, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int threshold = 16384)
	{
		return DivideAndConquerTwoTypesLR(arrayToProcess, start, start + length - 1, baseCase, reduce, threshold);
	}

	internal static T2 DivideAndConquerTwoTypesLR<T, T2>(this T[] arrayToProcess, int left, int right, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int threshold = 16384)
	{
		T2 result = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (left > right)
		{
			return result;
		}
		if (right - left + 1 <= threshold)
		{
			return baseCase(arrayToProcess, left, right - left + 1);
		}
		int num = (right + left) / 2;
		T2 val = (T2)Convert.ChangeType(default(T), typeof(T2));
		result = DivideAndConquerTwoTypesLR(arrayToProcess, left, num, baseCase, reduce, threshold);
		val = DivideAndConquerTwoTypesLR(arrayToProcess, num + 1, right, baseCase, reduce, threshold);
		return reduce(result, val);
	}

	public static T DivideAndConquerPar<T>(this T[] arrayToProcess, int start, int length, Func<T[], int, int, T> baseCase, Func<T, T, T> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		return DivideAndConquerParLR(arrayToProcess, start, start + length - 1, baseCase, reduce, thresholdPar, degreeOfParallelism);
	}

	internal static T DivideAndConquerParLR<T>(this T[] arrayToProcess, int left, int right, Func<T[], int, int, T> baseCase, Func<T, T, T> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		T gparam_0 = default(T);
		if (left > right)
		{
			return gparam_0;
		}
		if (right - left + 1 <= thresholdPar)
		{
			return baseCase(arrayToProcess, left, right - left + 1);
		}
		int int_1 = (right + left) / 2;
		T gparam_2 = default(T);
		if (degreeOfParallelism == 1)
		{
			gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
		}
		else if (degreeOfParallelism > 1)
		{
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = degreeOfParallelism
			}, delegate
			{
				gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
			});
		}
		else
		{
			Parallel.Invoke(delegate
			{
				gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
			});
		}
		return reduce(gparam_0, gparam_2);
	}

	public static T2 DivideAndConquerTwoTypesPar<T, T2>(this T[] arrayToProcess, int start, int length, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		return DivideAndConquerTwoTypesParLR(arrayToProcess, start, start + length - 1, baseCase, reduce, thresholdPar, degreeOfParallelism);
	}

	public static T2 DivideAndConquerTwoTypesPar2<T, T2>(this T[] arrayToProcess, int start, int length, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		return DivideAndConquerTwoTypesParLR2(arrayToProcess, start, start + length - 1, baseCase, reduce, thresholdPar, degreeOfParallelism);
	}

	internal static T2 DivideAndConquerTwoTypesParLR<T, T2>(this T[] arrayToProcess, int left, int right, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		T2 gparam_0 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (left > right)
		{
			return gparam_0;
		}
		if (right - left + 1 <= thresholdPar)
		{
			return baseCase(arrayToProcess, left, right - left + 1);
		}
		int int_1 = (right + left) / 2;
		T2 gparam_2 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (degreeOfParallelism == 1)
		{
			gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar, degreeOfParallelism);
			gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar, degreeOfParallelism);
		}
		else if (degreeOfParallelism > 1)
		{
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = degreeOfParallelism
			}, delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar, degreeOfParallelism);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar, degreeOfParallelism);
			});
		}
		else
		{
			Parallel.Invoke(delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar, degreeOfParallelism);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar, degreeOfParallelism);
			});
		}
		return reduce(gparam_0, gparam_2);
	}

	internal static T2 DivideAndConquerTwoTypesParLR2<T, T2>(this T[] arrayToProcess, int left, int right, Func<T[], int, int, T2> baseCase, Func<T2, T2, T2> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		T2 gparam_0 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (left > right)
		{
			return gparam_0;
		}
		if (right - left + 1 <= thresholdPar)
		{
			return baseCase(arrayToProcess, left, right - left + 1);
		}
		int int_1 = ((right + left) / 2) & 0x7FFFFFF0;
		T2 gparam_2 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (degreeOfParallelism == 1)
		{
			gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
		}
		else if (degreeOfParallelism > 1)
		{
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = degreeOfParallelism
			}, delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
			});
		}
		else
		{
			Parallel.Invoke(delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, baseCase, reduce, thresholdPar);
			});
		}
		return reduce(gparam_0, gparam_2);
	}

	static AlgorithmPatterns()
	{
		Class72.smethod_20();
	}
}
