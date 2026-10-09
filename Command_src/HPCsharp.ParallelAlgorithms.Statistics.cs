using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace HPCsharp.ParallelAlgorithms;

public static class Statistics
{
	public static double StandardDeviationSse(this int[] values)
	{
		double double_ = (double)Sum.SumToLongSse(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_0(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationSsePar(this int[] values)
	{
		double double_ = (double)Sum.SumToLongSsePar(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_1(double_) / (double)(values.Length - 1));
	}

	private static double smethod_0(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_2(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_1(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<int, double>(0, ((Array)object_0).Length, double_0, smethod_0, (double x, double y) => x + y, int_0);
	}

	private static double smethod_2(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> vector3 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<int>((int[])object_0, i), out var low, out var high);
			Vector<double> vector4 = Vector.ConvertToDouble(low) - vector;
			Vector<double> vector5 = Vector.ConvertToDouble(high) - vector;
			vector2 += vector4 * vector4;
			vector3 += vector5 * vector5;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += ((double)((int[])object_0)[i] - double_0) * ((double)((int[])object_0)[i] - double_0);
		}
		vector2 += vector3;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double StandardDeviationSse(this long[] values)
	{
		double double_ = (double)Sum.SumToDecimalSseFaster(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_3(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationSsePar(this long[] values)
	{
		double double_ = (double)Sum.SumToDecimalSseFasterPar(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_4(double_) / (double)(values.Length - 1));
	}

	private static double smethod_3(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_5(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_4(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<long, double>(0, ((Array)object_0).Length, double_0, smethod_3, (double x, double y) => x + y, int_0);
	}

	private static double smethod_5(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<long>.Count * Vector<long>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<double> vector3 = Vector.ConvertToDouble(new Vector<long>((long[])object_0, i)) - vector;
			vector2 += vector3 * vector3;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += ((double)((long[])object_0)[i] - double_0) * ((double)((long[])object_0)[i] - double_0);
		}
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double StandardDeviationSse(this ulong[] values)
	{
		double double_ = (double)Sum.SumToDecimalSseEvenFaster(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_6(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationSsePar(this ulong[] values)
	{
		double double_ = (double)Sum.SumToDecimalSseEvenFasterPar(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_7(double_) / (double)(values.Length - 1));
	}

	private static double smethod_6(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_8(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_7(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<ulong, double>(0, ((Array)object_0).Length, double_0, smethod_6, (double x, double y) => x + y, int_0);
	}

	private static double smethod_8(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<double> vector3 = Vector.ConvertToDouble(new Vector<ulong>((ulong[])object_0, i)) - vector;
			vector2 += vector3 * vector3;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += ((double)(ulong)((long[])object_0)[i] - double_0) * ((double)(ulong)((long[])object_0)[i] - double_0);
		}
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static float StandardDeviationSse(this float[] values)
	{
		float num = Sum.SumSse(values) / (float)values.Length;
		return (float)Math.Sqrt(values.smethod_9(0, values.Length, num) / (float)(values.Length - 1));
	}

	public static float StandardDeviationSsePar(this float[] values)
	{
		float float_ = Sum.SumSsePar(values) / (float)values.Length;
		return (float)Math.Sqrt(values.smethod_10(float_) / (float)(values.Length - 1));
	}

	private static float smethod_9(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_11(int_0, int_0 + int_1 - 1, (float)double_0);
	}

	private static float smethod_10(this object object_0, float float_0, int int_0 = 16384)
	{
		return object_0.smethod_33<float, float>(0, ((Array)object_0).Length, float_0, smethod_9, (float x, float y) => x + y, int_0);
	}

	private static float smethod_11(this object object_0, int int_0, int int_1, float float_0)
	{
		Vector<float> vector = new Vector<float>(float_0);
		Vector<float> vector2 = default(Vector<float>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector<float> vector3 = new Vector<float>((float[])object_0, i) - vector;
			vector2 += vector3 * vector3;
		}
		float num2 = 0f;
		for (; i <= int_1; i++)
		{
			num2 += (((float[])object_0)[i] - float_0) * (((float[])object_0)[i] - float_0);
		}
		for (i = 0; i < Vector<float>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double StandardDeviationToDoubleSse(this float[] values)
	{
		double double_ = Sum.SumToDoubleSse(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_12(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationToDoubleSsePar(this float[] values)
	{
		double double_ = Sum.SumToDoubleSsePar(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_13(double_) / (double)(values.Length - 1));
	}

	private static double smethod_12(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_14(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_13(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<float, double>(0, ((Array)object_0).Length, double_0, smethod_12, (double x, double y) => x + y, int_0);
	}

	private static double smethod_14(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> vector3 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector.Widen(new Vector<float>((float[])object_0, i), out var low, out var high);
			Vector<double> vector4 = low - vector;
			Vector<double> vector5 = high - vector;
			vector2 += vector4 * vector4;
			vector3 += vector5 * vector5;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += ((double)((float[])object_0)[i] - double_0) * ((double)((float[])object_0)[i] - double_0);
		}
		vector2 += vector3;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double StandardDeviationSse(this double[] values)
	{
		double double_ = Sum.SumSse(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_15(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationSsePar(this double[] values)
	{
		double double_ = Sum.SumSsePar(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_16(double_) / (double)(values.Length - 1));
	}

	private static double smethod_15(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_17(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_16(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<double, double>(0, ((Array)object_0).Length, double_0, smethod_15, (double x, double y) => x + y, int_0);
	}

	private static double smethod_17(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<double>.Count * Vector<double>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<double>.Count)
		{
			Vector<double> vector3 = new Vector<double>((double[])object_0, i) - vector;
			vector2 += vector3 * vector3;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += (((double[])object_0)[i] - double_0) * (((double[])object_0)[i] - double_0);
		}
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double StandardDeviationMostAccurateSse(this double[] values)
	{
		double double_ = Sum.SumSseMostAccurate(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_18(0, values.Length, double_) / (double)(values.Length - 1));
	}

	public static double StandardDeviationMostAccurateSsePar(this double[] values)
	{
		double double_ = Sum.SumSseParMostAccurate(values) / (double)values.Length;
		return Math.Sqrt(values.smethod_19(double_) / (double)(values.Length - 1));
	}

	private static double smethod_18(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_20(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_19(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<double, double>(0, ((Array)object_0).Length, double_0, smethod_18, (double x, double y) => x + y, int_0);
	}

	private static double smethod_20(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> vector3 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<double>.Count * Vector<double>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<double>.Count)
		{
			Vector<double> vector4 = new Vector<double>((double[])object_0, i) - vector;
			Vector<double> vector5 = vector4 * vector4;
			Vector<double> vector6 = vector2 + vector5;
			Vector<long> condition = Vector.GreaterThanOrEqual(Vector.Abs(vector2), Vector.Abs(vector5));
			vector3 += Vector.ConditionalSelect(condition, vector2, vector5) - vector6 + Vector.ConditionalSelect(condition, vector5, vector2);
			vector2 = vector6;
		}
		int num2 = i;
		double num3 = 0.0;
		double num4 = 0.0;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			double num5 = num3 + vector2[i];
			num4 = ((!(Math.Abs(num3) >= Math.Abs(vector2[i]))) ? (num4 + (vector2[i] - num5 + num3)) : (num4 + (num3 - num5 + vector2[i])));
			num3 = num5;
			num4 += vector3[i];
		}
		for (i = num2; i <= int_1; i++)
		{
			double num6 = (((double[])object_0)[i] - double_0) * (((double[])object_0)[i] - double_0);
			double num7 = num3 + num6;
			num4 = ((!(Math.Abs(num3) >= Math.Abs(num6))) ? (num4 + (num6 - num7 + num3)) : (num4 + (num3 - num7 + num6)));
			num3 = num7;
		}
		return num3 + num4;
	}

	public static double MeanAbsoluteDeviationSse(this int[] values)
	{
		double double_ = (double)Sum.SumToLongSse(values) / (double)values.Length;
		return values.smethod_21(0, values.Length, double_) / (double)values.Length;
	}

	public static double MeanAbsoluteDeviationSsePar(this int[] values)
	{
		double double_ = (double)Sum.SumToLongSsePar(values) / (double)values.Length;
		return values.smethod_22(double_) / (double)values.Length;
	}

	private static double smethod_21(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_23(int_0, int_0 + int_1 - 1, (float)double_0);
	}

	private static double smethod_22(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<int, double>(0, ((Array)object_0).Length, double_0, smethod_21, (double x, double y) => x + y, int_0);
	}

	private static double smethod_23(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<int>((int[])object_0, i), out var low, out var high);
			Vector<double> vector3 = Vector.ConvertToDouble(low);
			Vector<double> vector4 = Vector.ConvertToDouble(high);
			vector2 += Vector.Abs(vector3 - vector);
			vector2 += Vector.Abs(vector4 - vector);
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += Math.Abs((double)((int[])object_0)[i] - double_0);
		}
		for (i = 0; i < Vector<int>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static float MeanAbsoluteDeviationSse(this float[] values)
	{
		float num = Sum.SumSse(values) / (float)values.Length;
		return values.smethod_24(0, values.Length, num) / (float)values.Length;
	}

	public static float MeanAbsoluteDeviationSsePar(this float[] values)
	{
		float float_ = Sum.SumSsePar(values) / (float)values.Length;
		return values.smethod_25(float_) / (float)values.Length;
	}

	private static float smethod_24(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_26(int_0, int_0 + int_1 - 1, (float)double_0);
	}

	private static float smethod_25(this object object_0, float float_0, int int_0 = 16384)
	{
		return object_0.smethod_33<float, float>(0, ((Array)object_0).Length, float_0, smethod_24, (float x, float y) => x + y, int_0);
	}

	private static float smethod_26(this object object_0, int int_0, int int_1, float float_0)
	{
		Vector<float> vector = new Vector<float>(float_0);
		Vector<float> vector2 = default(Vector<float>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector<float> vector3 = new Vector<float>((float[])object_0, i);
			vector2 += Vector.Abs(vector3 - vector);
		}
		float num2 = 0f;
		for (; i <= int_1; i++)
		{
			num2 += Math.Abs(((float[])object_0)[i] - float_0);
		}
		for (i = 0; i < Vector<float>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double MeanAbsoluteDeviationToDoubleSse(this float[] values)
	{
		double double_ = Sum.SumToDoubleSse(values) / (double)values.Length;
		return values.smethod_27(0, values.Length, double_) / (double)values.Length;
	}

	public static double MeanAbsoluteDeviationToDoubleSsePar(this float[] values)
	{
		double double_ = Sum.SumToDoubleSsePar(values) / (double)values.Length;
		return values.smethod_28(double_) / (double)values.Length;
	}

	private static double smethod_27(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_29(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_28(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<float, double>(0, ((Array)object_0).Length, double_0, smethod_27, (double x, double y) => x + y, int_0);
	}

	private static double smethod_29(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> vector3 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector.Widen(new Vector<float>((float[])object_0, i), out var low, out var _);
			vector2 += Vector.Abs(low - vector);
			vector3 += Vector.Abs(low - vector);
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += Math.Abs((double)((float[])object_0)[i] - double_0);
		}
		vector2 += vector3;
		for (i = 0; i < Vector<float>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	public static double MeanAbsoluteDeviationSse(this double[] values)
	{
		double double_ = Sum.SumSse(values) / (double)values.Length;
		return values.smethod_30(0, values.Length, double_) / (double)values.Length;
	}

	public static double MeanAbsoluteDeviationSsePar(this double[] values)
	{
		double double_ = Sum.SumSsePar(values) / (double)values.Length;
		return values.smethod_31(double_) / (double)values.Length;
	}

	private static double smethod_30(this object object_0, int int_0, int int_1, double double_0)
	{
		return object_0.smethod_32(int_0, int_0 + int_1 - 1, double_0);
	}

	private static double smethod_31(this object object_0, double double_0, int int_0 = 16384)
	{
		return object_0.smethod_33<double, double>(0, ((Array)object_0).Length, double_0, smethod_30, (double x, double y) => x + y, int_0);
	}

	private static double smethod_32(this object object_0, int int_0, int int_1, double double_0)
	{
		Vector<double> vector = new Vector<double>(double_0);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<double>.Count * Vector<double>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<double>.Count)
		{
			Vector<double> vector3 = new Vector<double>((double[])object_0, i);
			vector2 += Vector.Abs(vector3 - vector);
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += Math.Abs(((double[])object_0)[i] - double_0);
		}
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector2[i];
		}
		return num2;
	}

	private static double QvkeqtjdMix(this object object_0)
	{
		double double_0 = (double)((IEnumerable<int>)object_0).Sum() / (double)((Array)object_0).Length;
		return ((IEnumerable<int>)object_0).AsParallel().Sum((int v) => Math.Abs((double)v - double_0)) / (double)((Array)object_0).Length;
	}

	private static U smethod_33<T, U>(this object object_0, int int_0, int int_1, double double_0, Func<T[], int, int, double, U> func_0, Func<U, U, U> func_1, int int_2 = 16384, int int_3 = 0)
	{
		return DivideAndConquerTwoTypesParLR((T[])object_0, int_0, int_0 + int_1 - 1, double_0, func_0, func_1, int_2, int_3);
	}

	private static U smethod_34<T, U>(this object object_0, int int_0, int int_1, double double_0, Func<T[], int, int, double, U> func_0, Func<U, U, U> func_1, int int_2 = 16384, int int_3 = 0)
	{
		return DivideAndConquerTwoTypesParLR((T[])object_0, int_0, int_0 + int_1 - 1, double_0, func_0, func_1, int_2, int_3);
	}

	internal static T2 DivideAndConquerTwoTypesParLR<T, T2>(this T[] arrayToProcess, int left, int right, double average, Func<T[], int, int, double, T2> baseCase, Func<T2, T2, T2> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		T2 gparam_0 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (left > right)
		{
			return gparam_0;
		}
		if (right - left + 1 <= thresholdPar)
		{
			return baseCase(arrayToProcess, left, right - left + 1, average);
		}
		int int_1 = (right + left) / 2;
		T2 gparam_2 = (T2)Convert.ChangeType(default(T), typeof(T2));
		if (degreeOfParallelism == 1)
		{
			gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
		}
		else if (degreeOfParallelism > 1)
		{
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = degreeOfParallelism
			}, delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
			});
		}
		else
		{
			Parallel.Invoke(delegate
			{
				gparam_0 = DivideAndConquerTwoTypesParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerTwoTypesParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
			});
		}
		return reduce(gparam_0, gparam_2);
	}

	private static T smethod_35<T>(this object object_0, int int_0, int int_1, double double_0, Func<T[], int, int, double, T> func_0, Func<T, T, T> func_1, int int_2 = 16384, int int_3 = 0)
	{
		return DivideAndConquerParLR((T[])object_0, int_0, int_0 + int_1 - 1, double_0, func_0, func_1, int_2, int_3);
	}

	internal static T DivideAndConquerParLR<T>(this T[] arrayToProcess, int left, int right, double average, Func<T[], int, int, double, T> baseCase, Func<T, T, T> reduce, int thresholdPar = 16384, int degreeOfParallelism = 0)
	{
		T gparam_0 = default(T);
		if (left > right)
		{
			return gparam_0;
		}
		if (right - left + 1 <= thresholdPar)
		{
			return baseCase(arrayToProcess, left, right - left + 1, average);
		}
		int int_1 = (right + left) / 2;
		T gparam_2 = default(T);
		if (degreeOfParallelism == 1)
		{
			gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
		}
		else if (degreeOfParallelism > 1)
		{
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = degreeOfParallelism
			}, delegate
			{
				gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
			});
		}
		else
		{
			Parallel.Invoke(delegate
			{
				gparam_0 = DivideAndConquerParLR(arrayToProcess, left, int_1, average, baseCase, reduce, thresholdPar);
			}, delegate
			{
				gparam_2 = DivideAndConquerParLR(arrayToProcess, int_1 + 1, right, average, baseCase, reduce, thresholdPar);
			});
		}
		return reduce(gparam_0, gparam_2);
	}

	static Statistics()
	{
		Class72.smethod_20();
	}
}
