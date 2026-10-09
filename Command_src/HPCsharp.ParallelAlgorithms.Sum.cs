using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using CSMaterial;
using HPCsharp.Algorithms;

namespace HPCsharp.ParallelAlgorithms;

public static class Sum
{
	public static long SumToLongSse(this sbyte[] arrayToSum)
	{
		return arrayToSum.smethod_0(0, arrayToSum.Length - 1);
	}

	public static long SumToLongSse(this sbyte[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_0(startIndex, startIndex + length - 1);
	}

	private static long smethod_0(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / (256 * Vector<sbyte>.Count) * (256 * Vector<sbyte>.Count);
		int count = Vector<sbyte>.Count;
		int i = int_0;
		while (i < num)
		{
			Vector<short> source = default(Vector<short>);
			Vector<short> source2 = default(Vector<short>);
			int num2 = 0;
			while (num2 < 256)
			{
				Vector.Widen(new Vector<sbyte>((sbyte[])object_0, i), out var low, out var high);
				source += low;
				source2 += high;
				num2++;
				i += count;
			}
			Vector.Widen(source, out var low2, out var high2);
			low2 += high2;
			Vector.Widen(source2, out var low3, out var high3);
			low2 += low3;
			low2 += high3;
			Vector.Widen(low2, out var low4, out var high4);
			vector += low4;
			vector += high4;
		}
		long num3 = 0L;
		for (; i <= int_1; i++)
		{
			num3 += ((sbyte[])object_0)[i];
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num3 += vector[i];
		}
		return num3;
	}

	public static ulong SumToUlongSse(this byte[] arrayToSum)
	{
		return arrayToSum.smethod_1(0, arrayToSum.Length - 1);
	}

	public static ulong SumToUlongSse(this byte[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_1(startIndex, startIndex + length - 1);
	}

	private static ulong smethod_1(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / (256 * Vector<byte>.Count) * (256 * Vector<byte>.Count);
		int count = Vector<byte>.Count;
		int i = int_0;
		while (i < num)
		{
			Vector<ushort> source = default(Vector<ushort>);
			Vector<ushort> source2 = default(Vector<ushort>);
			int num2 = 0;
			while (num2 < 256)
			{
				Vector.Widen(new Vector<byte>((byte[])object_0, i), out var low, out var high);
				source += low;
				source2 += high;
				num2++;
				i += count;
			}
			Vector.Widen(source, out var low2, out var high2);
			low2 += high2;
			Vector.Widen(source2, out var low3, out var high3);
			low2 += low3;
			low2 += high3;
			Vector.Widen(low2, out var low4, out var high4);
			vector += low4;
			vector += high4;
		}
		ulong num3 = 0uL;
		for (; i <= int_1; i++)
		{
			num3 += ((byte[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num3 += vector[i];
		}
		return num3;
	}

	private static ulong smethod_2(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / (256 * Vector<byte>.Count) * (256 * Vector<byte>.Count);
		int count = Vector<byte>.Count;
		int num2 = 2 * Vector<byte>.Count;
		int i = int_0;
		while (i < num)
		{
			Vector<ushort> source = default(Vector<ushort>);
			Vector<ushort> source2 = default(Vector<ushort>);
			Vector<ushort> source3 = default(Vector<ushort>);
			Vector<ushort> source4 = default(Vector<ushort>);
			int num3 = 0;
			while (num3 < 256)
			{
				Vector<byte> source5 = new Vector<byte>((byte[])object_0, i);
				Vector<byte> source6 = new Vector<byte>((byte[])object_0, i + count);
				Vector.Widen(source5, out var low, out var high);
				Vector.Widen(source6, out var low2, out var high2);
				source += low;
				source2 += high;
				source3 += low2;
				source4 += high2;
				num3 += 2;
				i += num2;
			}
			Vector.Widen(source, out var low3, out var high3);
			low3 += high3;
			Vector.Widen(source2, out var low4, out var high4);
			low3 += low4;
			low3 += high4;
			Vector.Widen(source3, out low4, out high4);
			low3 += low4;
			low3 += high4;
			Vector.Widen(source4, out low4, out high4);
			low3 += low4;
			low3 += high4;
			Vector.Widen(low3, out var low5, out var high5);
			vector += low5;
			vector += high5;
		}
		ulong num4 = 0uL;
		for (; i <= int_1; i++)
		{
			num4 += ((byte[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num4 += vector[i];
		}
		return num4;
	}

	public static long SumToLongSse(this short[] arrayToSum)
	{
		return arrayToSum.smethod_3(0, arrayToSum.Length - 1);
	}

	public static long SumToLongSse(this short[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_3(startIndex, startIndex + length - 1);
	}

	private static long smethod_3(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / (256 * Vector<short>.Count) * (256 * Vector<short>.Count);
		int count = Vector<short>.Count;
		int i = int_0;
		while (i < num)
		{
			Vector<int> source = default(Vector<int>);
			Vector<int> source2 = default(Vector<int>);
			int num2 = 0;
			while (num2 < 256)
			{
				Vector.Widen(new Vector<short>((short[])object_0, i), out var low, out var high);
				source += low;
				source2 += high;
				num2++;
				i += count;
			}
			Vector.Widen(source, out var low2, out var high2);
			vector += low2;
			vector += high2;
			Vector.Widen(source2, out low2, out high2);
			vector += low2;
			vector += high2;
		}
		long num3 = 0L;
		for (; i <= int_1; i++)
		{
			num3 += ((short[])object_0)[i];
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num3 += vector[i];
		}
		return num3;
	}

	public static ulong SumToUlongSse(this ushort[] arrayToSum)
	{
		return arrayToSum.smethod_4(0, arrayToSum.Length - 1);
	}

	public static ulong SumToUlongSse(this ushort[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_4(startIndex, startIndex + length - 1);
	}

	private static ulong smethod_4(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / (256 * Vector<ushort>.Count) * (256 * Vector<ushort>.Count);
		int count = Vector<ushort>.Count;
		int i = int_0;
		while (i < num)
		{
			Vector<uint> source = default(Vector<uint>);
			Vector<uint> source2 = default(Vector<uint>);
			int num2 = 0;
			while (num2 < 256)
			{
				Vector.Widen(new Vector<ushort>((ushort[])object_0, i), out var low, out var high);
				source += low;
				source2 += high;
				num2++;
				i += count;
			}
			Vector.Widen(source, out var low2, out var high2);
			vector += low2;
			vector += high2;
			Vector.Widen(source2, out low2, out high2);
			vector += low2;
			vector += high2;
		}
		ulong num3 = 0uL;
		for (; i <= int_1; i++)
		{
			num3 += ((ushort[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num3 += vector[i];
		}
		return num3;
	}

	public static long SumToLongSse(this int[] arrayToSum)
	{
		return arrayToSum.smethod_5(0, arrayToSum.Length - 1);
	}

	public static long SumToLongSse(this int[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_5(startIndex, startIndex + length - 1);
	}

	private static long smethod_5(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<int>((int[])object_0, i), out var low, out var high);
			vector += low;
			vector2 += high;
		}
		long num2 = 0L;
		for (; i <= int_1; i++)
		{
			num2 += ((int[])object_0)[i];
		}
		vector += vector2;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	private static long smethod_6(this object object_0)
	{
		return object_0.smethod_5(0, ((Array)object_0).Length - 1);
	}

	private static long smethod_7(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		int num = 3;
		long num2 = 0L;
		int i;
		for (i = int_0; i < int_0 + num; i++)
		{
			num2 += ((int[])object_0)[i];
		}
		int_0 += num;
		int num3 = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		for (i = int_0; i < num3; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<int>((int[])object_0, i), out var low, out var high);
			vector += low;
			vector2 += high;
		}
		for (; i <= int_1; i++)
		{
			num2 += ((int[])object_0)[i];
		}
		vector += vector2;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	private static long smethod_8(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> low = default(Vector<long>);
		Vector<long> high = default(Vector<long>);
		int[] array = new int[Vector<int>.Count];
		Vector<int> vector3 = default(Vector<int>);
		vector3 = default(Vector<int>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			vector3.CopyTo(array, 0);
			int num2 = 0;
			int num3 = i;
			while (num2 < array.Length)
			{
				if (((int?[])object_0)[num3].HasValue)
				{
					array[num2] = ((int?[])object_0)[num3].Value;
				}
				num2++;
				num3++;
			}
			Vector.Widen(new Vector<int>(array, 0), out low, out high);
			vector += low;
			vector2 += high;
		}
		long num4 = 0L;
		for (; i <= int_1; i++)
		{
			if (((int?[])object_0)[i].HasValue)
			{
				num4 += ((int?[])object_0)[i].Value;
			}
		}
		vector += vector2;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num4 += vector[i];
		}
		return num4;
	}

	public static long SumToLongSse(this int?[] arrayToSum)
	{
		return arrayToSum.smethod_8(0, arrayToSum.Length - 1);
	}

	public static long SumToLongSse(this int?[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_8(startIndex, startIndex + length - 1);
	}

	public static long SumSseAndScalarSingleStream(this int[] arrayToSum)
	{
		return arrayToSum.smethod_9(0, arrayToSum.Length - 1);
	}

	public static long SumSseAndScalarSingleStream(this int[] arrayToSum, int start, int length)
	{
		return arrayToSum.smethod_9(start, start + length - 1);
	}

	private static long smethod_9(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> vector3 = default(Vector<long>);
		Vector<long> vector4 = default(Vector<long>);
		Vector<long> vector5 = default(Vector<long>);
		Vector<long> vector6 = default(Vector<long>);
		Vector<long> vector7 = default(Vector<long>);
		Vector<long> vector8 = default(Vector<long>);
		Vector<long> low = default(Vector<long>);
		Vector<long> high = default(Vector<long>);
		Vector<long> low2 = default(Vector<long>);
		Vector<long> high2 = default(Vector<long>);
		Vector<long> low3 = default(Vector<long>);
		Vector<long> high3 = default(Vector<long>);
		Vector<long> low4 = default(Vector<long>);
		Vector<long> high4 = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / (5 * Vector<int>.Count) * Vector<int>.Count;
		long num2 = 0L;
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		int i = int_0;
		while (i < num)
		{
			Vector<int> source = new Vector<int>((int[])object_0, i);
			i += Vector<int>.Count;
			Vector.Widen(source, out low, out high);
			Vector<int> source2 = new Vector<int>((int[])object_0, i);
			i += Vector<int>.Count;
			Vector.Widen(source2, out low2, out high2);
			Vector<int> source3 = new Vector<int>((int[])object_0, i);
			i += Vector<int>.Count;
			Vector.Widen(source3, out low3, out high3);
			Vector<int> source4 = new Vector<int>((int[])object_0, i);
			i += Vector<int>.Count;
			Vector.Widen(source4, out low4, out high4);
			num2 += ((int[])object_0)[i++];
			vector += low;
			num3 += ((int[])object_0)[i++];
			vector2 += high;
			num4 += ((int[])object_0)[i++];
			vector3 += low2;
			num5 += ((int[])object_0)[i++];
			vector4 += high2;
			num2 += ((int[])object_0)[i++];
			vector5 += low3;
			num3 += ((int[])object_0)[i++];
			vector6 += high3;
			num4 += ((int[])object_0)[i++];
			vector7 += low4;
			num5 += ((int[])object_0)[i++];
			vector8 += high4;
		}
		for (; i <= int_1; i++)
		{
			num2 += ((int[])object_0)[i];
		}
		num2 += num3;
		num2 += num4;
		num2 += num5;
		vector += vector2;
		vector3 += vector4;
		vector5 += vector6;
		vector7 += vector8;
		vector += vector3;
		vector += vector5;
		vector += vector7;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static long SumSseAndScalar(this int[] arrayToSum)
	{
		return arrayToSum.smethod_10(0, arrayToSum.Length - 1);
	}

	public static long SumSseAndScalar(this int[] arrayToSum, int start, int length)
	{
		return arrayToSum.smethod_10(start, start + length - 1);
	}

	private static long smethod_10(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> low = default(Vector<long>);
		Vector<long> high = default(Vector<long>);
		int num = (int_1 - int_0 + 1) / (Vector<int>.Count + 1) * Vector<int>.Count / Vector<int>.Count;
		long num2 = 0L;
		int i = int_0;
		int num3 = int_0 + num * Vector<int>.Count;
		for (int num4 = num3; i < num4; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<int>((int[])object_0, i), out low, out high);
			num2 += ((int[])object_0)[num3++];
			vector += low;
			vector2 += high;
		}
		for (i = num3; i <= int_1; i++)
		{
			num2 += ((int[])object_0)[i];
		}
		vector += vector2;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static ulong SumSseAndScalarSingleStream(this ulong[] arrayToSum)
	{
		return arrayToSum.smethod_11(0, arrayToSum.Length - 1);
	}

	public static ulong SumSseAndScalarSingleStream(this ulong[] arrayToSum, int start, int length)
	{
		return arrayToSum.smethod_11(start, start + length - 1);
	}

	private static ulong smethod_11(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		ulong num2 = 0uL;
		int i = int_0;
		for (int count = Vector<ulong>.Count; i < num; i += count)
		{
			vector += new Vector<ulong>((ulong[])object_0, i);
		}
		for (; i <= int_1; i++)
		{
			num2 += (ulong)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static ulong SumToUlongSse(this uint[] arrayToSum)
	{
		return arrayToSum.avXeqlUfWjQ(0, arrayToSum.Length - 1);
	}

	public static ulong SumToUlongSse(this uint[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.avXeqlUfWjQ(startIndex, startIndex + length - 1);
	}

	private static ulong avXeqlUfWjQ(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		Vector<ulong> vector2 = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<uint>.Count * Vector<uint>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<int>.Count)
		{
			Vector.Widen(new Vector<uint>((uint[])object_0, i), out var low, out var high);
			vector += low;
			vector2 += high;
		}
		ulong num2 = 0uL;
		for (; i <= int_1; i++)
		{
			num2 += ((uint[])object_0)[i];
		}
		vector += vector2;
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static long SumSse(this long[] arrayToSum)
	{
		return arrayToSum.smethod_12(0, arrayToSum.Length - 1);
	}

	public static long SumSse(this long[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_12(startIndex, startIndex + length - 1);
	}

	private static long smethod_12(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<long>.Count * Vector<long>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<long> vector2 = new Vector<long>((long[])object_0, i);
			vector += vector2;
		}
		long num2 = 0L;
		for (; i <= int_1; i++)
		{
			num2 = checked(num2 + ((long[])object_0)[i]);
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 = checked(num2 + vector[i]);
		}
		return num2;
	}

	private static long smethod_13(this object object_0)
	{
		return object_0.smethod_15(0, ((Array)object_0).Length - 1);
	}

	private static long smethod_14(this object object_0, int int_0, int int_1)
	{
		return object_0.smethod_15(int_0, int_0 + int_1 - 1);
	}

	private static long smethod_15(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<long>.Count * 4) * (Vector<long>.Count * 4);
		int count = Vector<long>.Count;
		int num2 = Vector<long>.Count * 2;
		int num3 = Vector<long>.Count * 3;
		int num4 = Vector<long>.Count * 4;
		int i;
		for (i = int_0; i < num; i += num4)
		{
			vector += new Vector<long>((long[])object_0, i);
			vector += new Vector<long>((long[])object_0, i + count);
			vector += new Vector<long>((long[])object_0, i + num2);
			vector += new Vector<long>((long[])object_0, i + num3);
		}
		long num5 = 0L;
		for (; i <= int_1; i++)
		{
			num5 += ((long[])object_0)[i];
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num5 += vector[i];
		}
		return num5;
	}

	private static long smethod_16(this object object_0)
	{
		return object_0.smethod_18(0, ((Array)object_0).Length - 1);
	}

	private static long smethod_17(this object object_0, int int_0, int int_1)
	{
		return object_0.smethod_18(int_0, int_0 + int_1 - 1);
	}

	private static long smethod_18(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = default(Vector<long>);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> vector3 = default(Vector<long>);
		Vector<long> vector4 = default(Vector<long>);
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<long>.Count * 4) * (Vector<long>.Count * 4);
		int count = Vector<long>.Count;
		int num2 = Vector<long>.Count * 2;
		int num3 = Vector<long>.Count * 3;
		int num4 = Vector<long>.Count * 4;
		int i = int_0;
		int num5 = int_0 + count;
		int num6 = int_0 + num2;
		int num7 = int_0 + num3;
		while (i < num)
		{
			vector += new Vector<long>((long[])object_0, i);
			vector2 += new Vector<long>((long[])object_0, num5);
			vector3 += new Vector<long>((long[])object_0, num6);
			vector4 += new Vector<long>((long[])object_0, num7);
			i += num4;
			num5 += num4;
			num6 += num4;
			num7 += num4;
		}
		long num8 = 0L;
		for (; i <= int_1; i++)
		{
			num8 += ((long[])object_0)[i];
		}
		vector += vector2;
		vector += vector3;
		vector += vector4;
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num8 += vector[i];
		}
		return num8;
	}

	public static long SumCheckedSse(this long[] arrayToSum)
	{
		return arrayToSum.smethod_19(0, arrayToSum.Length - 1);
	}

	public static long SumCheckedSse(this long[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_19(startIndex, startIndex + length - 1);
	}

	private static long smethod_19(this object object_0, int int_0, int int_1)
	{
		Vector<long> vector = new Vector<long>(0L);
		Vector<long> right = new Vector<long>(0L);
		Vector<long> right2 = new Vector<long>(-1L);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<long>.Count * Vector<long>.Count;
		int i = int_0;
		long num2;
		while (true)
		{
			if (i < num)
			{
				Vector<long> vector2 = new Vector<long>((long[])object_0, i);
				Vector<long> vector3 = Vector.GreaterThanOrEqual(vector2, right);
				Vector<long> vector4 = Vector.GreaterThanOrEqual(vector, right);
				Vector<long> left = Vector.OnesComplement(vector3);
				Vector<long> right3 = Vector.OnesComplement(vector4);
				Vector<long> left2 = Vector.BitwiseAnd(vector3, right3);
				Vector<long> right4 = Vector.BitwiseAnd(left, vector4);
				if (Vector.EqualsAll(Vector.BitwiseOr(left2, right4), right2))
				{
					vector += vector2;
				}
				else
				{
					Vector<long> vector5 = vector + vector2;
					Vector<long> left3 = Vector.BitwiseAnd(vector3, vector4);
					Vector<long> left4 = Vector.BitwiseAnd(left, right3);
					Vector<long> right5 = Vector.LessThan(vector5, vector);
					Vector<long> right6 = Vector.GreaterThan(vector5, vector);
					Vector<long> left5 = Vector.BitwiseAnd(left3, right5);
					Vector<long> left6 = Vector.BitwiseAnd(left4, right6);
					if (Vector.EqualsAny(left5, right2) || Vector.EqualsAny(left6, right2))
					{
						throw new OverflowException();
					}
					vector = vector5;
				}
				i += Vector<long>.Count;
				continue;
			}
			num2 = 0L;
			for (; i <= int_1; i++)
			{
				num2 = checked(num2 + ((long[])object_0)[i]);
			}
			for (i = 0; i < Vector<ulong>.Count; i++)
			{
				num2 = checked(num2 + vector[i]);
			}
			break;
		}
		return num2;
	}

	public static decimal SumToDecimalSseFaster(this long[] arrayToSum)
	{
		return arrayToSum.smethod_20(0, arrayToSum.Length - 1);
	}

	public static decimal SumToDecimalSseFaster(this long[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_20(startIndex, startIndex + length - 1);
	}

	private static decimal smethod_20(this object object_0, int int_0, int int_1)
	{
		decimal result = default(decimal);
		Vector<long> vector = new Vector<long>(0L);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> vector3 = new Vector<long>(0L);
		Vector<long> vector4 = default(Vector<long>);
		Vector<long> right = Vector.OnesComplement(new Vector<long>(0L));
		int num = int_0 + (int_1 - int_0 + 1) / Vector<long>.Count * Vector<long>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<long> vector5 = new Vector<long>((long[])object_0, i);
			Vector<long> vector6 = Vector.GreaterThanOrEqual(vector, vector3);
			Vector<long> vector7 = Vector.GreaterThanOrEqual(vector5, vector3);
			Vector<long> vector8 = Vector.OnesComplement(vector6);
			Vector<long> vector9 = Vector.OnesComplement(vector7);
			Vector<long> right2 = Vector.BitwiseAnd(vector6, vector9);
			vector = Vector.ConditionalSelect(Vector.BitwiseOr(Vector.BitwiseAnd(vector8, vector7), right2), vector + vector5, vector);
			vector2 = vector + vector5;
			Vector<long> vector10 = Vector.BitwiseAnd(vector7, vector6);
			Vector<long> vector11 = Vector.BitwiseAnd(vector9, vector8);
			Vector<long> vector12 = Vector.LessThan(vector2, vector);
			Vector<long> vector13 = Vector.GreaterThan(vector2, vector);
			Vector<long> left = Vector.BitwiseAnd(vector10, vector12);
			Vector<long> left2 = Vector.BitwiseAnd(vector11, vector13);
			if (Vector.EqualsAny(left, right))
			{
				for (int j = 0; j < Vector<ulong>.Count; j++)
				{
					if (left[j] == -1L)
					{
						result += (decimal)vector[j];
						result += (decimal)vector5[j];
					}
				}
				vector4 = Vector.ConditionalSelect(vector12, vector3, vector2);
			}
			else
			{
				vector4 = vector2;
			}
			vector = Vector.ConditionalSelect(vector10, vector4, vector);
			if (!Vector.EqualsAny(left2, right))
			{
				vector4 = vector2;
			}
			else
			{
				for (int k = 0; k < Vector<ulong>.Count; k++)
				{
					if (left2[k] == -1L)
					{
						result += (decimal)vector[k];
						result += (decimal)vector5[k];
					}
				}
				vector4 = Vector.ConditionalSelect(vector13, vector3, vector2);
			}
			vector = Vector.ConditionalSelect(vector11, vector4, vector);
		}
		for (; i <= int_1; i++)
		{
			result += (decimal)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			result += (decimal)vector[i];
		}
		return result;
	}

	public static BigInteger SumToBigIntegerSseFaster(this long[] arrayToSum)
	{
		return arrayToSum.smethod_21(0, arrayToSum.Length - 1);
	}

	public static BigInteger SumToBigIntegerSseFaster(this long[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_21(startIndex, startIndex + length - 1);
	}

	private static BigInteger smethod_21(this object object_0, int int_0, int int_1)
	{
		BigInteger result = 0;
		Vector<long> vector = new Vector<long>(0L);
		Vector<long> vector2 = default(Vector<long>);
		Vector<long> vector3 = new Vector<long>(0L);
		Vector<long> vector4 = default(Vector<long>);
		Vector<long> right = Vector.OnesComplement(new Vector<long>(0L));
		int num = int_0 + (int_1 - int_0 + 1) / Vector<long>.Count * Vector<long>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<long> vector5 = new Vector<long>((long[])object_0, i);
			Vector<long> vector6 = Vector.GreaterThanOrEqual(vector, vector3);
			Vector<long> vector7 = Vector.GreaterThanOrEqual(vector5, vector3);
			Vector<long> vector8 = Vector.OnesComplement(vector6);
			Vector<long> vector9 = Vector.OnesComplement(vector7);
			Vector<long> right2 = Vector.BitwiseAnd(vector6, vector9);
			vector = Vector.ConditionalSelect(Vector.BitwiseOr(Vector.BitwiseAnd(vector8, vector7), right2), vector + vector5, vector);
			vector2 = vector + vector5;
			Vector<long> vector10 = Vector.BitwiseAnd(vector7, vector6);
			Vector<long> vector11 = Vector.BitwiseAnd(vector9, vector8);
			Vector<long> vector12 = Vector.LessThan(vector2, vector);
			Vector<long> vector13 = Vector.GreaterThan(vector2, vector);
			Vector<long> left = Vector.BitwiseAnd(vector10, vector12);
			Vector<long> left2 = Vector.BitwiseAnd(vector11, vector13);
			if (Vector.EqualsAny(left, right))
			{
				for (int j = 0; j < Vector<long>.Count; j++)
				{
					if (left[j] == -1L)
					{
						result += (BigInteger)vector[j];
						result += (BigInteger)vector5[j];
					}
				}
				vector4 = Vector.ConditionalSelect(vector12, vector3, vector2);
			}
			else
			{
				vector4 = vector2;
			}
			vector = Vector.ConditionalSelect(vector10, vector4, vector);
			if (!Vector.EqualsAny(left2, right))
			{
				vector4 = vector2;
			}
			else
			{
				for (int k = 0; k < Vector<long>.Count; k++)
				{
					if (left2[k] == -1L)
					{
						result += (BigInteger)vector[k];
						result += (BigInteger)vector5[k];
					}
				}
				vector4 = Vector.ConditionalSelect(vector13, vector3, vector2);
			}
			vector = Vector.ConditionalSelect(vector11, vector4, vector);
		}
		for (; i <= int_1; i++)
		{
			result += (BigInteger)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			result += (BigInteger)vector[i];
		}
		return result;
	}

	public static ulong SumSse(this ulong[] arrayToSum)
	{
		return arrayToSum.smethod_22(0, arrayToSum.Length - 1);
	}

	public static ulong SumSse(this ulong[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_22(startIndex, startIndex + length - 1);
	}

	private static ulong smethod_22(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<ulong> vector2 = new Vector<ulong>((ulong[])object_0, i);
			vector += vector2;
		}
		ulong num2 = 0uL;
		for (; i <= int_1; i++)
		{
			checked
			{
				num2 += unchecked((ulong)((long[])object_0)[i]);
			}
		}
		for (i = 0; i < Vector<long>.Count; i++)
		{
			num2 = checked(num2 + vector[i]);
		}
		return num2;
	}

	public static ulong SumCheckedSse(this ulong[] arrayToSum)
	{
		return arrayToSum.smethod_23(0, arrayToSum.Length - 1);
	}

	public static ulong SumCheckedSse(this ulong[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_23(startIndex, startIndex + length - 1);
	}

	private static ulong smethod_23(this object object_0, int int_0, int int_1)
	{
		Vector<ulong> vector = default(Vector<ulong>);
		Vector<ulong> vector2 = default(Vector<ulong>);
		Vector<ulong> right = new Vector<ulong>(ulong.MaxValue);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<long>.Count)
		{
			Vector<ulong> vector3 = new Vector<ulong>((ulong[])object_0, i);
			vector2 = vector + vector3;
			if (Vector.EqualsAll(Vector.GreaterThanOrEqual(vector2, vector), right))
			{
				vector = vector2;
				continue;
			}
			throw new OverflowException();
		}
		ulong num2 = 0uL;
		for (; i <= int_1; i++)
		{
			checked
			{
				num2 += unchecked((ulong)((long[])object_0)[i]);
			}
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			num2 = checked(num2 + vector[i]);
		}
		return num2;
	}

	public static decimal SumToDecimalSseFaster(this ulong[] arrayToSum)
	{
		return arrayToSum.smethod_24(0, arrayToSum.Length - 1);
	}

	public static decimal SumToDecimalSseFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_24(startIndex, startIndex + length - 1);
	}

	private static decimal smethod_24(this object object_0, int int_0, int int_1)
	{
		decimal result = default(decimal);
		Vector<ulong> vector = default(Vector<ulong>);
		Vector<ulong> vector2 = default(Vector<ulong>);
		Vector<ulong> right = new Vector<ulong>(0uL);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<ulong>.Count)
		{
			Vector<ulong> vector3 = new Vector<ulong>((ulong[])object_0, i);
			vector2 = vector + vector3;
			Vector<ulong> vector4 = Vector.GreaterThanOrEqual(vector2, vector);
			if (Vector.EqualsAny(vector4, right))
			{
				for (int j = 0; j < Vector<ulong>.Count; j++)
				{
					if (vector4[j] == 0L)
					{
						result += (decimal)vector[j];
						result += (decimal)vector3[j];
					}
				}
			}
			vector = Vector.ConditionalSelect(vector4, vector2, right);
		}
		for (; i <= int_1; i++)
		{
			result += (decimal)(ulong)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			result += (decimal)vector[i];
		}
		return result;
	}

	public static decimal SumToDecimalSseEvenFaster(this ulong[] arrayToSum)
	{
		return arrayToSum.yebeqWoAbhk(0, arrayToSum.Length - 1);
	}

	public static decimal SumToDecimalSseEvenFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.yebeqWoAbhk(startIndex, startIndex + length - 1);
	}

	private static decimal yebeqWoAbhk(this object object_0, int int_0, int int_1)
	{
		decimal result = default(decimal);
		Vector<ulong> vector = default(Vector<ulong>);
		Vector<ulong> vector2 = default(Vector<ulong>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<ulong>.Count)
		{
			Vector<ulong> vector3 = new Vector<ulong>((ulong[])object_0, i);
			Vector<ulong> vector4 = vector + vector3;
			Vector<ulong> vector5 = Vector.LessThan(vector4, vector);
			vector2 -= vector5;
			vector = vector4;
		}
		for (; i <= int_1; i++)
		{
			result += (decimal)(ulong)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			result += (decimal)vector[i];
			decimal num2 = 9223372036854775808m;
			result += num2 * 2m * (decimal)vector2[i];
		}
		return result;
	}

	private static BigInteger smethod_25(this object object_0, int int_0, int int_1)
	{
		return (BigInteger)object_0.yebeqWoAbhk(int_0, int_1);
	}

	public static BigInteger SumToBigIntegerSseEvenFaster(this ulong[] arrayToSum)
	{
		return (BigInteger)arrayToSum.yebeqWoAbhk(0, arrayToSum.Length - 1);
	}

	public static BigInteger SumToBigIntegerSseEvenFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		return (BigInteger)arrayToSum.yebeqWoAbhk(startIndex, startIndex + length - 1);
	}

	public static BigInteger SumToBigIntegerSseFaster(this ulong[] arrayToSum)
	{
		return arrayToSum.smethod_26(0, arrayToSum.Length - 1);
	}

	public static BigInteger SumToBigIntegerSseFaster(this ulong[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_26(startIndex, startIndex + length - 1);
	}

	private static BigInteger smethod_26(this object object_0, int int_0, int int_1)
	{
		BigInteger result = 0;
		Vector<ulong> vector = default(Vector<ulong>);
		Vector<ulong> vector2 = default(Vector<ulong>);
		Vector<ulong> right = new Vector<ulong>(0uL);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<ulong>.Count * Vector<ulong>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<ulong>.Count)
		{
			Vector<ulong> vector3 = new Vector<ulong>((ulong[])object_0, i);
			vector2 = vector + vector3;
			Vector<ulong> vector4 = Vector.GreaterThanOrEqual(vector2, vector);
			if (Vector.EqualsAny(vector4, right))
			{
				for (int j = 0; j < Vector<ulong>.Count; j++)
				{
					if (vector4[j] == 0L)
					{
						result += (BigInteger)vector[j];
						result += (BigInteger)vector3[j];
					}
				}
			}
			vector = Vector.ConditionalSelect(vector4, vector2, right);
		}
		for (; i <= int_1; i++)
		{
			result += (BigInteger)(ulong)((long[])object_0)[i];
		}
		for (i = 0; i < Vector<ulong>.Count; i++)
		{
			result += (BigInteger)vector[i];
		}
		return result;
	}

	public static float SumSse(this float[] arrayToSum)
	{
		return arrayToSum.smethod_27(0, arrayToSum.Length - 1);
	}

	public static float SumSse(this float[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_27(startIndex, startIndex + length - 1);
	}

	private static float smethod_27(this object object_0, int int_0, int int_1)
	{
		Vector<float> vector = default(Vector<float>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector<float> vector2 = new Vector<float>((float[])object_0, i);
			vector += vector2;
		}
		float num2 = 0f;
		for (; i <= int_1; i++)
		{
			num2 += ((float[])object_0)[i];
		}
		for (i = 0; i < Vector<float>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static double SumToDoubleSse(this float[] arrayToSum)
	{
		return arrayToSum.smethod_28(0, arrayToSum.Length - 1);
	}

	public static double SumToDoubleSse(this float[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_28(startIndex, startIndex + length - 1);
	}

	private static double smethod_28(this object object_0, int int_0, int int_1)
	{
		Vector<double> vector = default(Vector<double>);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> low = default(Vector<double>);
		Vector<double> high = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector.Widen(new Vector<float>((float[])object_0, i), out low, out high);
			vector += low;
			vector2 += high;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += (double)((float[])object_0)[i];
		}
		vector += vector2;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static double SumSse(this double[] arrayToSum)
	{
		return arrayToSum.smethod_29(0, arrayToSum.Length - 1);
	}

	public static double SumSse(this double[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_29(startIndex, startIndex + length - 1);
	}

	private static double smethod_29(this object object_0, int int_0, int int_1)
	{
		Vector<double> vector = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<double>.Count * Vector<double>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<double>.Count)
		{
			Vector<double> vector2 = new Vector<double>((double[])object_0, i);
			vector += vector2;
		}
		double num2 = 0.0;
		for (; i <= int_1; i++)
		{
			num2 += ((double[])object_0)[i];
		}
		for (i = 0; i < Vector<double>.Count; i++)
		{
			num2 += vector[i];
		}
		return num2;
	}

	public static float SumSseMostAccurate(this float[] arrayToSum)
	{
		return arrayToSum.smethod_30(0, arrayToSum.Length - 1);
	}

	public static float SumSseMostAccurate(this float[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_30(startIndex, startIndex + length - 1);
	}

	private static float smethod_30(this object object_0, int int_0, int int_1)
	{
		Vector<float> vector = default(Vector<float>);
		Vector<float> vector2 = default(Vector<float>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector<float> vector3 = new Vector<float>((float[])object_0, i);
			Vector<float> vector4 = vector + vector3;
			Vector<int> condition = Vector.GreaterThanOrEqual(Vector.Abs(vector), Vector.Abs(vector3));
			vector2 += Vector.ConditionalSelect(condition, vector, vector3) - vector4 + Vector.ConditionalSelect(condition, vector3, vector);
			vector = vector4;
		}
		int num2 = i;
		float num3 = 0f;
		float num4 = 0f;
		for (i = 0; i < Vector<float>.Count; i++)
		{
			float num5 = num3 + vector[i];
			num4 = ((!(Math.Abs(num3) >= Math.Abs(vector[i]))) ? (num4 + (vector[i] - num5 + num3)) : (num4 + (num3 - num5 + vector[i])));
			num3 = num5;
			num4 += vector2[i];
		}
		for (i = num2; i <= int_1; i++)
		{
			float num6 = num3 + ((float[])object_0)[i];
			num4 = ((!(Math.Abs(num3) >= Math.Abs(((float[])object_0)[i]))) ? (num4 + (((float[])object_0)[i] - num6 + num3)) : (num4 + (num3 - num6 + ((float[])object_0)[i])));
			num3 = num6;
		}
		return num3 + num4;
	}

	public static double SumToDoubleSseMostAccurate(this float[] arrayToSum)
	{
		return arrayToSum.smethod_31(0, arrayToSum.Length - 1);
	}

	public static double SumToDoubleSseMostAccurate(this float[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_31(startIndex, startIndex + length - 1);
	}

	private static double smethod_31(this object object_0, int int_0, int int_1)
	{
		Vector<double> vector = default(Vector<double>);
		Vector<double> vector2 = default(Vector<double>);
		Vector<double> low = default(Vector<double>);
		Vector<double> high = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<float>.Count * Vector<float>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<float>.Count)
		{
			Vector.Widen(new Vector<float>((float[])object_0, i), out low, out high);
			Vector<double> vector3 = vector + low;
			Vector<long> condition = Vector.GreaterThanOrEqual(Vector.Abs(vector), Vector.Abs(low));
			vector2 += Vector.ConditionalSelect(condition, vector, low) - vector3 + Vector.ConditionalSelect(condition, low, vector);
			vector = vector3;
			vector3 = vector + high;
			condition = Vector.GreaterThanOrEqual(Vector.Abs(vector), Vector.Abs(high));
			vector2 += Vector.ConditionalSelect(condition, vector, high) - vector3 + Vector.ConditionalSelect(condition, high, vector);
			vector = vector3;
		}
		int num2 = i;
		double num3 = 0.0;
		double num4 = 0.0;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			double num5 = num3 + vector[i];
			num4 = ((!(Math.Abs(num3) < Math.Abs(vector[i]))) ? (num4 + (num3 - num5 + vector[i])) : (num4 + (vector[i] - num5 + num3)));
			num3 = num5;
			num4 += vector2[i];
		}
		for (i = num2; i <= int_1; i++)
		{
			double num6 = num3 + (double)((float[])object_0)[i];
			num4 = ((!(Math.Abs(num3) >= (double)Math.Abs(((float[])object_0)[i]))) ? (num4 + ((double)((float[])object_0)[i] - num6 + num3)) : (num4 + (num3 - num6 + (double)((float[])object_0)[i])));
			num3 = num6;
		}
		return num3 + num4;
	}

	public static double SumSseMostAccurate(this double[] arrayToSum)
	{
		return arrayToSum.smethod_32(0, arrayToSum.Length - 1);
	}

	public static double SumSseMostAccurate(this double[] arrayToSum, int startIndex, int length)
	{
		return arrayToSum.smethod_32(startIndex, startIndex + length - 1);
	}

	private static double smethod_32(this object object_0, int int_0, int int_1)
	{
		Vector<double> vector = default(Vector<double>);
		Vector<double> vector2 = default(Vector<double>);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<double>.Count * Vector<double>.Count;
		int i;
		for (i = int_0; i < num; i += Vector<double>.Count)
		{
			Vector<double> vector3 = new Vector<double>((double[])object_0, i);
			Vector<double> vector4 = vector + vector3;
			Vector<long> condition = Vector.GreaterThanOrEqual(Vector.Abs(vector), Vector.Abs(vector3));
			vector2 += Vector.ConditionalSelect(condition, vector, vector3) - vector4 + Vector.ConditionalSelect(condition, vector3, vector);
			vector = vector4;
		}
		int num2 = i;
		double num3 = 0.0;
		double num4 = 0.0;
		for (i = 0; i < Vector<double>.Count; i++)
		{
			double num5 = num3 + vector[i];
			num4 = ((!(Math.Abs(num3) >= Math.Abs(vector[i]))) ? (num4 + (vector[i] - num5 + num3)) : (num4 + (num3 - num5 + vector[i])));
			num3 = num5;
			num4 += vector2[i];
		}
		for (i = num2; i <= int_1; i++)
		{
			double num6 = num3 + ((double[])object_0)[i];
			num4 = ((!(Math.Abs(num3) >= Math.Abs(((double[])object_0)[i]))) ? (num4 + (((double[])object_0)[i] - num6 + num3)) : (num4 + (num3 - num6 + ((double[])object_0)[i])));
			num3 = num6;
		}
		return num3 + num4;
	}

	private unsafe static ulong smethod_33(object object_0)
	{
		long result;
		fixed (float* ptr = &((float[])object_0)[0])
		{
			result = (long)ptr & 0x3FL;
		}
		return (ulong)result;
	}

	public static long SumToLongSseParDac(this sbyte[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToLongSse, (long x, long y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static long SumToLongSseParDac(this sbyte[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, SumToLongSse, (long x, long y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static ulong SumToUlongSsePar(this byte[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToUlongSse, (ulong x, ulong y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static ulong SumToUlongSseParInvoke(this byte[] arrayToSum, int degreeOfParallelism = 0)
	{
		int num = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = num
		};
		int num2 = arrayToSum.Length / num;
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		List<Action> list = new List<Action>();
		int num3 = 0;
		int num4 = 0;
		num4 = 0;
		while (num4 < num - 1)
		{
			int int_0 = num3;
			int int_1 = num2;
			list.Add(delegate
			{
				ulong item = SumToUlongSse(arrayToSum, int_0, int_1);
				concurrentBag_0.Add(item);
			});
			num4++;
			num3 += num2;
		}
		int int_2 = num3;
		int int_3 = arrayToSum.Length - num3;
		list.Add(delegate
		{
			ulong item = SumToUlongSse(arrayToSum, int_2, int_3);
			concurrentBag_0.Add(item);
		});
		Parallel.Invoke(parallelOptions, list.ToArray());
		ulong num5 = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num6 = 0; num6 < array.Length; num6++)
		{
			num5 += array[num6];
		}
		return num5;
	}

	public static ulong SumToUlongPar(this byte[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongPar(this byte[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong num3 = 0uL;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumToUlongPar(this ushort[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongPar(this ushort[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong num3 = 0uL;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumToUlongPar(this uint[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongPar(this uint[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism > 0) ? degreeOfParallelism : Misc.Environment_ProcessorCount);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong num3 = 0uL;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumToLongPar(this sbyte[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongPar(this sbyte[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism > 0) ? degreeOfParallelism : Misc.Environment_ProcessorCount);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long num3 = 0L;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumToLongPar(this short[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongPar(this short[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism > 0) ? degreeOfParallelism : Misc.Environment_ProcessorCount);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long num3 = 0L;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumToLongPar(this int[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongPar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongPar(this int[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long num3 = 0L;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num3 += arrayToSum[i];
			}
			concurrentBag_0.Add(num3);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	private static long smethod_34(this int[] int_0, int int_1 = 0)
	{
		long long_0 = 0L;
		int maxDegreeOfParallelism = ((int_1 <= 0) ? Misc.Environment_ProcessorCount : int_1);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(0, int_0.Length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long num = 0L;
			for (int i = range.Item1; i < range.Item2; i++)
			{
				num += int_0[i];
			}
			Interlocked.Add(ref long_0, num);
		});
		return long_0;
	}

	public static long SumToLongSsePar(this sbyte[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongSsePar(this sbyte[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long item = arrayToSum.smethod_0(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumToLongSsePar(this short[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongSsePar(this short[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long item = arrayToSum.smethod_3(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumToLongSsePar(this int[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToLongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumToLongSsePar(this int[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long item = arrayToSum.smethod_5(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static long SumSsePar(this long[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static long SumSsePar(this long[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<long> concurrentBag_0 = new ConcurrentBag<long>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			long item = arrayToSum.smethod_12(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		long num = 0L;
		long[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumToUlongSsePar(this byte[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongSsePar(this byte[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism > 0) ? degreeOfParallelism : Misc.Environment_ProcessorCount);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong item = arrayToSum.smethod_1(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumToUlongSsePar(this ushort[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongSsePar(this ushort[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong item = arrayToSum.smethod_4(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumToUlongSsePar(this uint[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumToUlongSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumToUlongSsePar(this uint[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong item = arrayToSum.avXeqlUfWjQ(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	public static ulong SumSsePar(this ulong[] arrayToSum, int degreeOfParallelism = 0)
	{
		return SumSsePar(arrayToSum, 0, arrayToSum.Length, degreeOfParallelism);
	}

	public static ulong SumSsePar(this ulong[] arrayToSum, int startIndex, int length, int degreeOfParallelism = 0)
	{
		ConcurrentBag<ulong> concurrentBag_0 = new ConcurrentBag<ulong>();
		int maxDegreeOfParallelism = ((degreeOfParallelism <= 0) ? Misc.Environment_ProcessorCount : degreeOfParallelism);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.ForEach(Partitioner.Create(startIndex, startIndex + length), parallelOptions, delegate(Tuple<int, int> range)
		{
			ulong item = arrayToSum.smethod_22(range.Item1, range.Item2 - 1);
			concurrentBag_0.Add(item);
		});
		ulong num = 0uL;
		ulong[] array = concurrentBag_0.ToArray();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			num += array[num2];
		}
		return num;
	}

	private static BigInteger fFpeqnnJovE(this ulong[] ulong_0, int int_0, int int_1, int int_2 = 16384)
	{
		BigInteger bigInteger_0 = 0;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 <= int_2)
			{
				return HPCsharp.Algorithms.Sum.SumToBigIntegerFaster(ulong_0, int_0, int_1 - int_0 + 1);
			}
			int int_3 = (int_1 + int_0) / 2;
			BigInteger bigInteger_1 = 0;
			Parallel.Invoke(delegate
			{
				bigInteger_0 = ulong_0.fFpeqnnJovE(int_0, int_3, int_2);
			}, delegate
			{
				bigInteger_1 = ulong_0.fFpeqnnJovE(int_3 + 1, int_1, int_2);
			});
			return bigInteger_0 + bigInteger_1;
		}
		return bigInteger_0;
	}

	private static BigInteger smethod_35(this long[] long_0, int int_0, int int_1, int int_2 = 16384)
	{
		BigInteger bigInteger_0 = 0;
		if (int_0 > int_1)
		{
			return bigInteger_0;
		}
		if (int_1 - int_0 + 1 > int_2)
		{
			int int_3 = (int_1 + int_0) / 2;
			BigInteger bigInteger_1 = 0;
			Parallel.Invoke(delegate
			{
				bigInteger_0 = long_0.smethod_35(int_0, int_3, int_2);
			}, delegate
			{
				bigInteger_1 = long_0.smethod_35(int_3 + 1, int_1, int_2);
			});
			return bigInteger_0 + bigInteger_1;
		}
		return HPCsharp.Algorithms.Sum.SumToBigIntegerFaster(long_0, int_0, int_1 - int_0 + 1);
	}

	private static BigInteger smethod_36(this long[] long_0, int int_0, int int_1, int int_2 = 16384)
	{
		BigInteger bigInteger_0 = 0;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 > int_2)
			{
				int int_3 = (int_1 + int_0) / 2;
				BigInteger bigInteger_1 = 0;
				Parallel.Invoke(delegate
				{
					bigInteger_0 = long_0.smethod_36(int_0, int_3, int_2);
				}, delegate
				{
					bigInteger_1 = long_0.smethod_36(int_3 + 1, int_1, int_2);
				});
				return bigInteger_0 + bigInteger_1;
			}
			return long_0.smethod_21(int_0, int_1);
		}
		return bigInteger_0;
	}

	private static BigInteger smethod_37(this ulong[] ulong_0, int int_0, int int_1, int int_2 = 16384)
	{
		BigInteger bigInteger_0 = 0;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 > int_2)
			{
				int int_3 = (int_1 + int_0) / 2;
				BigInteger bigInteger_1 = 0;
				Parallel.Invoke(delegate
				{
					bigInteger_0 = ulong_0.smethod_37(int_0, int_3, int_2);
				}, delegate
				{
					bigInteger_1 = ulong_0.smethod_37(int_3 + 1, int_1, int_2);
				});
				return bigInteger_0 + bigInteger_1;
			}
			return ulong_0.smethod_26(int_0, int_1);
		}
		return bigInteger_0;
	}

	private static ulong smethod_38(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((byte[])object_0, int_0, int_1, SumToUlongSse, (ulong x, ulong y) => x + y, int_2, int_3);
	}

	private static long smethod_39(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((short[])object_0, 0, ((Array)object_0).Length, SumToLongSse, (long x, long y) => x + y, int_0, int_1);
	}

	private static long smethod_40(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((short[])object_0, int_0, int_1, SumToLongSse, (long x, long y) => x + y, int_2, int_3);
	}

	private static ulong smethod_41(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((ushort[])object_0, 0, ((Array)object_0).Length, SumToUlongSse, (ulong x, ulong y) => x + y, int_0, int_1);
	}

	private static ulong smethod_42(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((ushort[])object_0, int_0, int_1, SumToUlongSse, (ulong x, ulong y) => x + y, int_2, int_3);
	}

	private static long smethod_43(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((int[])object_0, 0, ((Array)object_0).Length, SumToLongSse, (long x, long y) => x + y, int_0, int_1);
	}

	private static long smethod_44(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((int[])object_0, int_0, int_1, SumToLongSse, (long x, long y) => x + y, int_2, int_3);
	}

	private static ulong smethod_45(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((uint[])object_0, 0, ((Array)object_0).Length, SumToUlongSse, (ulong x, ulong y) => x + y, int_0, int_1);
	}

	private static ulong smethod_46(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar((uint[])object_0, int_0, int_1, SumToUlongSse, (ulong x, ulong y) => x + y, int_2, int_3);
	}

	private static long smethod_47(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar((long[])object_0, 0, ((Array)object_0).Length, SumSse, (long x, long y) => x + y, int_0, int_1);
	}

	private static long smethod_48(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar((long[])object_0, int_0, int_1, SumSse, (long x, long y) => x + y, int_2, int_3);
	}

	public static decimal SumToDecimalPar(this long[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDecimal, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalPar(this long[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDecimal, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalFasterPar(this long[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDecimalFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalFasterPar(this long[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDecimalFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseFasterPar(this long[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToDecimalSseFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseFasterPar(this long[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, SumToDecimalSseFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumToBigIntegerFasterPar(this long[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_35(0, arrayToSum.Length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerFasterPar(this long[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_35(startIndex, startIndex + length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerSseFasterPar(this long[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_36(0, arrayToSum.Length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerSseFasterPar(this long[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_36(startIndex, startIndex + length - 1, thresholdParallel);
	}

	public static decimal SumToDecimalPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDecimal, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDecimal, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDecimalFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDecimalFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToDecimalSseFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, SumToDecimalSseFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseEvenFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToDecimalSseEvenFaster, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumToDecimalSseEvenFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, yebeqWoAbhk, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumToBigIntegerPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToBigInteger, (BigInteger x, BigInteger y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumToBigIntegerPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToBigInteger, (BigInteger x, BigInteger y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumToBigIntegerFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.fFpeqnnJovE(0, arrayToSum.Length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.fFpeqnnJovE(startIndex, startIndex + length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerSseFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_37(0, arrayToSum.Length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerSseFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return arrayToSum.smethod_37(startIndex, startIndex + length - 1, thresholdParallel);
	}

	public static BigInteger SumToBigIntegerSseEvenFasterPar(this ulong[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return (BigInteger)SumToDecimalSseEvenFasterPar(arrayToSum, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumToBigIntegerSseEvenFasterPar(this ulong[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return (BigInteger)SumToDecimalSseEvenFasterPar(arrayToSum, startIndex, length, thresholdParallel, degreeOfParallelism);
	}

	private static ulong smethod_49(this object object_0, int int_0 = 16384, int int_1 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar((ulong[])object_0, 0, ((Array)object_0).Length, SumSse, (ulong x, ulong y) => x + y, int_0, int_1);
	}

	private static ulong smethod_50(this object object_0, int int_0, int int_1, int int_2 = 16384, int int_3 = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar((ulong[])object_0, int_0, int_1, SumSse, (ulong x, ulong y) => x + y, int_2, int_3);
	}

	public static float SumPar(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumHpc, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static float SumPar(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumHpc, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoublePar(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDouble, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoublePar(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDouble, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static float SumSsePar(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, SumSse, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static float SumSsePar(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, SumSse, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleSsePar(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumSse, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleSsePar(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, SumSse, (float x, float y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumPar(this double[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumHpc, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumPar(this double[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumHpc, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumSsePar(this double[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, SumSse, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static double SumSsePar(this double[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, SumSse, (double x, double y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static float SumParMostAccurate(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static float SumParMostAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleParMostAccurate(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumToDoubleMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleParMostAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumToDoubleMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static float SumSseParMostAccurate(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, SumSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static float SumSseParMostAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, SumSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleSseParMostAccurate(this float[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, 0, arrayToSum.Length, SumToDoubleSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumToDoubleSseParMostAccurate(this float[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerTwoTypesPar(arrayToSum, startIndex, length, SumToDoubleSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumParMostAccurate(this double[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumParMostAccurate(this double[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumSseParMostAccurate(this double[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, SumSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static double SumSseParMostAccurate(this double[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, SumSseMostAccurate, HPCsharp.Algorithms.Sum.SumMostAccurate, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumPar(this decimal[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumHpc, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static decimal SumPar(this decimal[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumHpc, (decimal x, decimal y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumPar(this BigInteger[] arrayToSum, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, 0, arrayToSum.Length, HPCsharp.Algorithms.Sum.SumHpc, (BigInteger x, BigInteger y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	public static BigInteger SumPar(this BigInteger[] arrayToSum, int startIndex, int length, int thresholdParallel = 16384, int degreeOfParallelism = 0)
	{
		return AlgorithmPatterns.DivideAndConquerPar(arrayToSum, startIndex, length, HPCsharp.Algorithms.Sum.SumHpc, (BigInteger x, BigInteger y) => x + y, thresholdParallel, degreeOfParallelism);
	}

	static Sum()
	{
		Class72.smethod_20();
	}
}
