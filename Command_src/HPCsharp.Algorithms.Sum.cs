using System;
using System.Numerics;

namespace HPCsharp.Algorithms;

public static class Sum
{
	public static BigInteger SumHpc(this BigInteger[] arrayToSum)
	{
		BigInteger result = 0;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			result += arrayToSum[i];
		}
		return result;
	}

	public static BigInteger SumHpc(this BigInteger[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger result = 0;
		for (int i = startIndex; i < num; i++)
		{
			result += arrayToSum[i];
		}
		return result;
	}

	public static BigInteger SumToBigIntegerFast(this long[] arrayToSum)
	{
		BigInteger bigInteger = 0;
		long num = 0L;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				num = checked(num + arrayToSum[i]);
			}
			catch (OverflowException)
			{
				bigInteger += (BigInteger)num;
				bigInteger += (BigInteger)arrayToSum[i];
				num = 0L;
			}
		}
		return bigInteger + num;
	}

	public static BigInteger SumToBigIntegerFast(this long?[] arrayToSum)
	{
		BigInteger bigInteger = 0;
		long num = 0L;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				if (arrayToSum[i].HasValue)
				{
					num = checked(num + arrayToSum[i].Value);
				}
			}
			catch (OverflowException)
			{
				bigInteger += (BigInteger)num;
				bigInteger += (BigInteger)arrayToSum[i].Value;
				num = 0L;
			}
		}
		return bigInteger + num;
	}

	public static BigInteger SumToBigIntegerFast(this ulong[] arrayToSum)
	{
		BigInteger bigInteger = 0;
		ulong num = 0uL;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				num = checked(num + arrayToSum[i]);
			}
			catch (OverflowException)
			{
				bigInteger += (BigInteger)num;
				bigInteger += (BigInteger)arrayToSum[i];
				num = 0uL;
			}
		}
		return bigInteger + num;
	}

	public static decimal SumToDecimalEvenFaster(this ulong[] arrayToSum)
	{
		ulong num = 0uL;
		uint num2 = 0u;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			ulong num3 = num + arrayToSum[i];
			if (num3 < num)
			{
				num2++;
			}
			num = num3;
		}
		return 9223372036854775808m * 2m * (decimal)num2 + (decimal)num;
	}

	public static decimal SumToDecimalFaster(this ulong[] arrayToSum)
	{
		decimal num = default(decimal);
		ulong num2 = 0uL;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			ulong num3 = num2 + arrayToSum[i];
			if (num3 < num2)
			{
				num += (decimal)num2;
				num += (decimal)arrayToSum[i];
				num2 = 0uL;
			}
			else
			{
				num2 = num3;
			}
		}
		return num + (decimal)num2;
	}

	public static decimal SumToDecimalFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal num2 = default(decimal);
		ulong num3 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			ulong num4 = num3 + arrayToSum[i];
			if (num4 >= num3)
			{
				num3 = num4;
				continue;
			}
			num2 += (decimal)num3;
			num2 += (decimal)arrayToSum[i];
			num3 = 0uL;
		}
		return num2 + (decimal)num3;
	}

	public static BigInteger SumToBigIntegerFaster(this ulong[] arrayToSum)
	{
		BigInteger bigInteger = 0;
		ulong num = 0uL;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			ulong num2 = num + arrayToSum[i];
			if (num2 < num)
			{
				bigInteger += (BigInteger)num;
				bigInteger += (BigInteger)arrayToSum[i];
				num = 0uL;
			}
			else
			{
				num = num2;
			}
		}
		return bigInteger + num;
	}

	public static BigInteger SumToBigIntegerFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger bigInteger = 0;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			ulong num3 = num2 + arrayToSum[i];
			if (num3 >= num2)
			{
				num2 = num3;
				continue;
			}
			bigInteger += (BigInteger)num2;
			bigInteger += (BigInteger)arrayToSum[i];
			num2 = 0uL;
		}
		return bigInteger + num2;
	}

	public static BigInteger SumToBigIntegerFast(this ulong?[] arrayToSum)
	{
		BigInteger bigInteger = 0;
		ulong num = 0uL;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				if (arrayToSum[i].HasValue)
				{
					num = checked(num + arrayToSum[i].Value);
				}
			}
			catch (OverflowException)
			{
				bigInteger += (BigInteger)num;
				bigInteger += (BigInteger)arrayToSum[i].Value;
				num = 0uL;
			}
		}
		return bigInteger + num;
	}

	public static BigInteger SumToBigIntegerFaster(this long[] arrayToSum)
	{
		return SumToBigIntegerFaster(arrayToSum, 0, arrayToSum.Length);
	}

	public static BigInteger SumToBigIntegerFaster(this long[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger bigInteger = 0;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (num2 < 0L)
			{
				if (arrayToSum[i] >= 0L)
				{
					num2 += arrayToSum[i];
					continue;
				}
				long num3 = num2 + arrayToSum[i];
				if (num3 > num2)
				{
					bigInteger += (BigInteger)num2;
					bigInteger += (BigInteger)arrayToSum[i];
					num2 = 0L;
				}
				else
				{
					num2 = num3;
				}
			}
			else if (arrayToSum[i] >= 0L)
			{
				long num4 = num2 + arrayToSum[i];
				if (num4 < num2)
				{
					bigInteger += (BigInteger)num2;
					bigInteger += (BigInteger)arrayToSum[i];
					num2 = 0L;
				}
				else
				{
					num2 = num4;
				}
			}
			else
			{
				num2 += arrayToSum[i];
			}
		}
		return bigInteger + num2;
	}

	public static BigInteger SumToBigInteger(this long[] arrayToSum)
	{
		return SumToBigInteger(arrayToSum, 0, arrayToSum.Length);
	}

	public static BigInteger SumToBigInteger(this long[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger result = 0;
		for (int i = startIndex; i < num; i++)
		{
			result += (BigInteger)arrayToSum[i];
		}
		return result;
	}

	public static decimal SumToDecimalFast(this long[] arrayToSum)
	{
		decimal num = default(decimal);
		long num2 = 0L;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				num2 = checked(num2 + arrayToSum[i]);
			}
			catch (OverflowException)
			{
				num += (decimal)num2;
				num += (decimal)arrayToSum[i];
				num2 = 0L;
			}
		}
		return num + (decimal)num2;
	}

	public static decimal SumToDecimalFaster(this long[] arrayToSum)
	{
		return SumToDecimalFaster(arrayToSum, 0, arrayToSum.Length);
	}

	public static decimal SumToDecimalFaster(this long[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal num2 = default(decimal);
		long num3 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (num3 >= 0L)
			{
				if (arrayToSum[i] < 0L)
				{
					num3 += arrayToSum[i];
					continue;
				}
				long num4 = num3 + arrayToSum[i];
				if (num4 < num3)
				{
					num2 += (decimal)num3;
					num2 += (decimal)arrayToSum[i];
					num3 = 0L;
				}
				else
				{
					num3 = num4;
				}
			}
			else if (arrayToSum[i] < 0L)
			{
				long num5 = num3 + arrayToSum[i];
				if (num5 > num3)
				{
					num2 += (decimal)num3;
					num2 += (decimal)arrayToSum[i];
					num3 = 0L;
				}
				else
				{
					num3 = num5;
				}
			}
			else
			{
				num3 += arrayToSum[i];
			}
		}
		return num2 + (decimal)num3;
	}

	public static decimal SumToDecimalFast(this ulong[] arrayToSum)
	{
		decimal num = default(decimal);
		ulong num2 = 0uL;
		for (int i = 0; i < arrayToSum.Length; i++)
		{
			try
			{
				num2 = checked(num2 + arrayToSum[i]);
			}
			catch (OverflowException)
			{
				num += (decimal)num2;
				num += (decimal)arrayToSum[i];
				num2 = 0uL;
			}
		}
		return num + (decimal)num2;
	}

	public static decimal SumToDecimal(this long[] arrayToSum)
	{
		return SumToDecimal(arrayToSum, 0, arrayToSum.Length);
	}

	public static decimal SumToDecimal(this long[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			result += (decimal)arrayToSum[i];
		}
		return result;
	}

	public static decimal SumToDecimal(this long?[] arrayToSum)
	{
		return SumToDecimal(arrayToSum, 0, arrayToSum.Length);
	}

	public static decimal SumToDecimal(this long?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				result += (decimal)arrayToSum[i].Value;
			}
		}
		return result;
	}

	public static long SumHpc(this long[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumHpc(this long[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			num2 = checked(num2 + arrayToSum[i]);
		}
		return num2;
	}

	public static long SumHpc(this long?[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumHpc(this long?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 = checked(num2 + arrayToSum[i].Value);
			}
		}
		return num2;
	}

	public static long SumToLong(this int[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this int[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static long SumToLong(this int?[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this int?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static long SumToLong(this short[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this short[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static long SumToLong(this short?[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this short?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static long SumToLong(this sbyte[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this sbyte[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static long SumToLong(this sbyte?[] arrayToSum)
	{
		return SumToLong(arrayToSum, 0, arrayToSum.Length);
	}

	public static long SumToLong(this sbyte?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		long num2 = 0L;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static decimal SumToDecimal(this ulong[] arrayToSum)
	{
		return SumToDecimal(arrayToSum, 0, arrayToSum.Length);
	}

	public static decimal SumToDecimal(this ulong[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			result += (decimal)arrayToSum[i];
		}
		return result;
	}

	public static decimal SumToDecimal(this ulong?[] arrayToSum)
	{
		return SumToDecimal(arrayToSum, 0, arrayToSum.Length);
	}

	public static decimal SumToDecimal(this ulong?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				result += (decimal)arrayToSum[i].Value;
			}
		}
		return result;
	}

	public static BigInteger SumToBigInteger(this ulong[] arrayToSum)
	{
		return SumToBigInteger(arrayToSum, 0, arrayToSum.Length);
	}

	public static BigInteger SumToBigInteger(this ulong[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger result = 0;
		for (int i = startIndex; i < num; i++)
		{
			result += (BigInteger)arrayToSum[i];
		}
		return result;
	}

	public static BigInteger SumToBigInteger(this ulong?[] arrayToSum)
	{
		return SumToBigInteger(arrayToSum, 0, arrayToSum.Length);
	}

	public static BigInteger SumToBigInteger(this ulong?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		BigInteger result = 0;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				result += (BigInteger)arrayToSum[i].Value;
			}
		}
		return result;
	}

	public static ulong SumHpc(this ulong[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumHpc(this ulong[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			num2 = checked(num2 + arrayToSum[i]);
		}
		return num2;
	}

	public static ulong SumHpc(this ulong?[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumHpc(this ulong?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 = checked(num2 + arrayToSum[i].Value);
			}
		}
		return num2;
	}

	public static ulong SumToUlong(this uint[] arrayToSum)
	{
		return SumUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumUlong(this uint[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static ulong SumUlong(this uint?[] arrayToSum)
	{
		return SumToUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumToUlong(this uint?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static ulong SumToUlong(this ushort[] arrayToSum)
	{
		return SumToUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumToUlong(this ushort[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static ulong SumToUlong(this ushort?[] arrayToSum)
	{
		return SumToUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumToUlong(this ushort?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static ulong SumToUlong(this byte[] arrayToSum)
	{
		return SumToUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumToUlong(this byte[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static ulong SumToUlong(this byte?[] arrayToSum)
	{
		return SumToUlong(arrayToSum, 0, arrayToSum.Length);
	}

	public static ulong SumToUlong(this byte?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		ulong num2 = 0uL;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static float SumHpc(this float[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static float SumHpc(this float[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		float num2 = 0f;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static float SumHpc(this float?[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static float SumHpc(this float?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		float num2 = 0f;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	public static double SumToDouble(this float[] arrayToSum)
	{
		return SumToDouble(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumToDouble(this float[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		double num2 = 0.0;
		for (int i = startIndex; i < num; i++)
		{
			num2 += (double)arrayToSum[i];
		}
		return num2;
	}

	public static double SumToDouble(this float?[] arrayToSum)
	{
		return SumToDouble(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumToDouble(this float?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		double num2 = 0.0;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += (double)arrayToSum[i].Value;
			}
		}
		return num2;
	}

	internal static float SumLR(this float[] arrayToSum, int l, int r)
	{
		float num = 0f;
		for (int i = l; i <= r; i++)
		{
			num += arrayToSum[i];
		}
		return num;
	}

	internal static double SumToDoubleLR(this float[] arrayToSum, int l, int r)
	{
		double num = 0.0;
		for (int i = l; i <= r; i++)
		{
			num += (double)arrayToSum[i];
		}
		return num;
	}

	public static double SumHpc(this double[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumHpc(this double[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		double num2 = 0.0;
		for (int i = startIndex; i < num; i++)
		{
			num2 += arrayToSum[i];
		}
		return num2;
	}

	public static double SumHpc(this double?[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumHpc(this double?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		double num2 = 0.0;
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				num2 += arrayToSum[i].Value;
			}
		}
		return num2;
	}

	internal static double SumLR(this double[] arrayToSum, int l, int r)
	{
		double num = 0.0;
		for (int i = l; i <= r; i++)
		{
			num += arrayToSum[i];
		}
		return num;
	}

	public static decimal SumHpc(this decimal[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	internal static decimal SumHpc(this decimal[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			result += arrayToSum[i];
		}
		return result;
	}

	public static decimal SumHpc(this decimal?[] arrayToSum)
	{
		return SumHpc(arrayToSum, 0, arrayToSum.Length);
	}

	internal static decimal SumHpc(this decimal?[] arrayToSum, int startIndex, int length)
	{
		int num = startIndex + length;
		decimal result = default(decimal);
		for (int i = startIndex; i < num; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				result += arrayToSum[i].Value;
			}
		}
		return result;
	}

	private static double smethod_0(this object object_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < ((Array)object_0).Length; i++)
		{
			double num3 = (double)((float[])object_0)[i] - num2;
			double num4 = num + num3;
			num2 = num4 - num - num3;
			num = num4;
		}
		return num;
	}

	private static double smethod_1(this object object_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < ((Array)object_0).Length; i++)
		{
			double num3 = ((double[])object_0)[i] - num2;
			double num4 = num + num3;
			num2 = num4 - num - num3;
			num = num4;
		}
		return num;
	}

	public static float SumMostAccurate(float firstValue, float secondValue)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = num + firstValue;
		num2 = ((!(Math.Abs(num) >= Math.Abs(firstValue))) ? (num2 + (firstValue - num3 + num)) : (num2 + (num - num3 + firstValue)));
		num = num3;
		num3 = num + secondValue;
		num2 = ((!(Math.Abs(num) >= Math.Abs(secondValue))) ? (num2 + (secondValue - num3 + num)) : (num2 + (num - num3 + secondValue)));
		num = num3;
		return num + num2;
	}

	public static double SumToDoubleMostAccurate(float firstValue, float secondValue)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = num + (double)firstValue;
		num2 = ((!(Math.Abs(num) >= (double)Math.Abs(firstValue))) ? (num2 + ((double)firstValue - num3 + num)) : (num2 + (num - num3 + (double)firstValue)));
		num = num3;
		num3 = num + (double)secondValue;
		num2 = ((!(Math.Abs(num) >= (double)Math.Abs(secondValue))) ? (num2 + ((double)secondValue - num3 + num)) : (num2 + (num - num3 + (double)secondValue)));
		num = num3;
		return num + num2;
	}

	public static float SumMostAccurate(this float[] arrayToSum)
	{
		return SumMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static float SumMostAccurate(this float[] arrayToSum, int startIndex, int length)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			float num4 = num + arrayToSum[i];
			num2 = ((!(Math.Abs(num) >= Math.Abs(arrayToSum[i]))) ? (num2 + (arrayToSum[i] - num4 + num)) : (num2 + (num - num4 + arrayToSum[i])));
			num = num4;
		}
		return num + num2;
	}

	public static float SumMostAccurate(this float?[] arrayToSum)
	{
		return SumMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static float SumMostAccurate(this float?[] arrayToSum, int startIndex, int length)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				float num4 = arrayToSum[i].Value;
				float num5 = num + num4;
				num2 = ((!(Math.Abs(num) >= Math.Abs(num4))) ? (num2 + (num4 - num5 + num)) : (num2 + (num - num5 + num4)));
				num = num5;
			}
		}
		return num + num2;
	}

	public static double SumToDoubleMostAccurate(this float[] arrayToSum)
	{
		return SumToDoubleMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumToDoubleMostAccurate(this float[] arrayToSum, int startIndex, int length)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			double num4 = num + (double)arrayToSum[i];
			num2 = ((!(Math.Abs(num) >= (double)Math.Abs(arrayToSum[i]))) ? (num2 + ((double)arrayToSum[i] - num4 + num)) : (num2 + (num - num4 + (double)arrayToSum[i])));
			num = num4;
		}
		return num + num2;
	}

	public static double SumToDoubleMostAccurate(this float?[] arrayToSum)
	{
		return SumMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumToDoubleMostAccurate(this float?[] arrayToSum, int startIndex, int length)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				double num4 = arrayToSum[i].Value;
				double num5 = num + num4;
				num2 = ((!(Math.Abs(num) < Math.Abs(num4))) ? (num2 + (num - num5 + num4)) : (num2 + (num4 - num5 + num)));
				num = num5;
			}
		}
		return num + num2;
	}

	public static double SumMostAccurate(double firstValue, double secondValue)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = num + firstValue;
		num2 = ((!(Math.Abs(num) >= Math.Abs(firstValue))) ? (num2 + (firstValue - num3 + num)) : (num2 + (num - num3 + firstValue)));
		num = num3;
		num3 = num + secondValue;
		num2 = ((!(Math.Abs(num) < Math.Abs(secondValue))) ? (num2 + (num - num3 + secondValue)) : (num2 + (secondValue - num3 + num)));
		num = num3;
		return num + num2;
	}

	public static double SumMostAccurate(this double[] arrayToSum)
	{
		return SumMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumMostAccurate(this double[] arrayToSum, int startIndex, int length)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			double num4 = num + arrayToSum[i];
			num2 = ((!(Math.Abs(num) >= Math.Abs(arrayToSum[i]))) ? (num2 + (arrayToSum[i] - num4 + num)) : (num2 + (num - num4 + arrayToSum[i])));
			num = num4;
		}
		return num + num2;
	}

	public static double SumMostAccurate(this double?[] arrayToSum)
	{
		return SumMostAccurate(arrayToSum, 0, arrayToSum.Length);
	}

	public static double SumMostAccurate(this double?[] arrayToSum, int startIndex, int length)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = startIndex + length;
		for (int i = startIndex; i < num3; i++)
		{
			if (arrayToSum[i].HasValue)
			{
				double num4 = arrayToSum[i].Value;
				double num5 = num + num4;
				num2 = ((!(Math.Abs(num) >= Math.Abs(num4))) ? (num2 + (num4 - num5 + num)) : (num2 + (num - num5 + num4)));
				num = num5;
			}
		}
		return num + num2;
	}

	private static float smethod_2(this object object_0, int int_0, int int_1, Func<float[], int, int, float> func_0, Func<float, float, float> func_1, int int_2 = 16384)
	{
		float result = 0f;
		if (int_0 > int_1)
		{
			return result;
		}
		if (int_1 - int_0 + 1 <= int_2)
		{
			return func_0((float[])object_0, int_0, int_1);
		}
		int num = (int_1 + int_0) / 2;
		float num2 = 0f;
		result = object_0.smethod_2(int_0, num, func_0, func_1);
		num2 = object_0.smethod_2(num + 1, int_1, func_0, func_1);
		return func_1(result, num2);
	}

	private static double smethod_3(this object object_0, int int_0, int int_1, Func<float[], int, int, double> func_0, Func<double, double, double> func_1, int int_2 = 16384)
	{
		double result = 0.0;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 <= int_2)
			{
				return func_0((float[])object_0, int_0, int_1);
			}
			int num = (int_1 + int_0) / 2;
			double num2 = 0.0;
			result = object_0.smethod_3(int_0, num, func_0, func_1);
			num2 = object_0.smethod_3(num + 1, int_1, func_0, func_1);
			return func_1(result, num2);
		}
		return result;
	}

	private static double smethod_4(this object object_0, int int_0, int int_1, Func<double[], int, int, double> func_0, Func<double, double, double> func_1, int int_2 = 16384)
	{
		double result = 0.0;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 <= int_2)
			{
				return func_0((double[])object_0, int_0, int_1);
			}
			int num = (int_1 + int_0) / 2;
			double num2 = 0.0;
			result = object_0.smethod_4(int_0, num, func_0, func_1);
			num2 = object_0.smethod_4(num + 1, int_1, func_0, func_1);
			return func_1(result, num2);
		}
		return result;
	}

	public static float SumMoreAccurate(this float[] arrayToSum, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_2(0, arrayToSum.Length - 1, SumLR, (float x, float y) => x + y);
	}

	public static float SumMoreAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_2(startIndex, startIndex + length - 1, SumLR, (float x, float y) => x + y);
	}

	public static double SumToDoubleMoreAccurate(this float[] arrayToSum, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_3(0, arrayToSum.Length - 1, SumToDoubleLR, (double x, double y) => x + y);
	}

	public static double SumToDoubleMoreAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_3(startIndex, startIndex + length - 1, SumToDoubleLR, (double x, double y) => x + y);
	}

	public static double SumMoreAccurate(this double[] arrayToSum, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_4(0, arrayToSum.Length - 1, SumLR, (double x, double y) => x + y);
	}

	public static double SumMoreAccurate(this double[] arrayToSum, int startIndex, int length, int thresholdDivideAndConquerSum = 16384)
	{
		return arrayToSum.smethod_4(startIndex, startIndex + length - 1, SumLR, (double x, double y) => x + y);
	}

	static Sum()
	{
		Class72.smethod_20();
	}
}
