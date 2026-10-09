using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HPCsharp.ParallelAlgorithms;

namespace HPCsharp;

public static class Algorithm
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct Int32ByteUnion
	{
		[FieldOffset(0)]
		public byte byte0;

		[FieldOffset(1)]
		public byte byte1;

		[FieldOffset(2)]
		public byte byte2;

		[FieldOffset(3)]
		public byte byte3;

		[FieldOffset(0)]
		public int integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct UInt32ByteUnion
	{
		[FieldOffset(0)]
		public byte byte0;

		[FieldOffset(1)]
		public byte byte1;

		[FieldOffset(2)]
		public byte byte2;

		[FieldOffset(3)]
		public byte byte3;

		[FieldOffset(0)]
		public uint integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct UInt64ByteUnion
	{
		[FieldOffset(0)]
		public byte byte0;

		[FieldOffset(1)]
		public byte byte1;

		[FieldOffset(2)]
		public byte byte2;

		[FieldOffset(3)]
		public byte byte3;

		[FieldOffset(4)]
		public byte byte4;

		[FieldOffset(5)]
		public byte byte5;

		[FieldOffset(6)]
		public byte byte6;

		[FieldOffset(7)]
		public byte byte7;

		[FieldOffset(0)]
		public ulong integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct Int64ByteUnion
	{
		[FieldOffset(0)]
		public byte byte0;

		[FieldOffset(1)]
		public byte byte1;

		[FieldOffset(2)]
		public byte byte2;

		[FieldOffset(3)]
		public byte byte3;

		[FieldOffset(4)]
		public byte byte4;

		[FieldOffset(5)]
		public byte byte5;

		[FieldOffset(6)]
		public byte byte6;

		[FieldOffset(7)]
		public byte byte7;

		[FieldOffset(0)]
		public long integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct UInt32UShortUnion
	{
		[FieldOffset(0)]
		public ushort ushort0;

		[FieldOffset(1)]
		public ushort ushort1;

		[FieldOffset(0)]
		public uint integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct UInt64UShortUnion
	{
		[FieldOffset(0)]
		public ushort ushort0;

		[FieldOffset(1)]
		public ushort ushort1;

		[FieldOffset(2)]
		public ushort ushort2;

		[FieldOffset(3)]
		public ushort ushort3;

		[FieldOffset(0)]
		public ulong integer;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct FloatUInt32Union
	{
		[FieldOffset(0)]
		public uint uinteger;

		[FieldOffset(0)]
		public float floatValue;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct DoubleUInt64Union
	{
		[FieldOffset(0)]
		public ulong ulongInteger;

		[FieldOffset(0)]
		public double doubleValue;
	}

	public enum SortOrder
	{
		Ascending,
		Descending
	}

	[CompilerGenerated]
	private static int int_0;

	[CompilerGenerated]
	private static int int_1;

	[CompilerGenerated]
	private static int int_2;

	[CompilerGenerated]
	private static int int_3;

	[CompilerGenerated]
	private static int int_4;

	[CompilerGenerated]
	private static int int_5;

	[CompilerGenerated]
	private static int int_6;

	[CompilerGenerated]
	private static int int_7;

	[CompilerGenerated]
	private static int int_8;

	public static int MergeArrayThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public static int SortMergeInsertionThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public static int SortRadixMsdShortThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public static int SortRadixMsdUShortThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public static int SortRadixMsdIntThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public static int SortRadixMsdULongThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public static int SortRadixMsdLongThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public static int SortRadixMsdFloatThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public static int SortRadixMsdDoubleThreshold
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public static int BinarySearch<T>(T value, List<T> a, int left, int right, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = left;
		int num2 = Math.Max(left, right + 1);
		while (num < num2)
		{
			int num3 = num + (num2 - num) / 2;
			if (comparer2.Compare(value, a[num3]) <= 0)
			{
				num2 = num3;
			}
			else
			{
				num = num3 + 1;
			}
		}
		return num2;
	}

	public static int BinarySearch<T>(T value, T[] a, int left, int right, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = left;
		int num2 = Math.Max(left, right + 1);
		while (num < num2)
		{
			int num3 = num + (num2 - num) / 2;
			if (comparer2.Compare(value, a[num3]) <= 0)
			{
				num2 = num3;
			}
			else
			{
				num = num3 + 1;
			}
		}
		return num2;
	}

	public static void Swap<T>(this T[] array, int indexA, int indexB)
	{
		T val = array[indexA];
		array[indexA] = array[indexB];
		array[indexB] = val;
	}

	public static void Swap<T>(this T[] array, int indexA, int indexB, int length, bool reverse = false)
	{
		if (!reverse)
		{
			while (length-- > 0)
			{
				T val = array[indexA];
				array[indexA++] = array[indexB];
				array[indexB++] = val;
			}
			return;
		}
		int num = indexB + length - 1;
		while (length-- > 0)
		{
			T val2 = array[indexA];
			array[indexA++] = array[num];
			array[num--] = val2;
		}
	}

	public static void SwapArray<T>(this T[] array, int indexA, int indexB, int length, bool reverse = false, int tempBufferSize = 1024)
	{
		T[] array2 = new T[tempBufferSize];
		if (!reverse)
		{
			while (length - tempBufferSize > 0)
			{
				Array.Copy(array, indexA, array2, 0, tempBufferSize);
				Array.Copy(array, indexB, array, indexA, tempBufferSize);
				Array.Copy(array2, 0, array, indexB, tempBufferSize);
				length -= tempBufferSize;
			}
			while (length-- > 0)
			{
				T val = array[indexA];
				array[indexA++] = array[indexB];
				array[indexB++] = val;
			}
		}
		else
		{
			int num = indexB + length - 1;
			while (length-- > 0)
			{
				T val2 = array[indexA];
				array[indexA++] = array[num];
				array[num--] = val2;
			}
		}
	}

	public static void Swap<T>(ref T B, T[] array, int indexA)
	{
		T val = array[indexA];
		array[indexA] = B;
		B = val;
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}

	public static void Reversal<T>(this T[] array, int l, int r)
	{
		while (l < r)
		{
			T val = array[l];
			array[l] = array[r];
			array[r] = val;
			l++;
			r--;
		}
	}

	public static void BlockSwapReversal<T>(T[] array, int l, int m, int r, int threshold = 1024)
	{
		if (r - l < threshold)
		{
			Reversal(array, l, m);
			Reversal(array, m + 1, r);
			Reversal(array, l, r);
		}
		else
		{
			Array.Reverse((Array)array, l, m - l + 1);
			Array.Reverse((Array)array, m + 1, r - m);
			Array.Reverse((Array)array, l, r - l + 1);
		}
	}

	public static void BlockSwapReversalReverseOrder<T>(T[] array, int l, int m, int r)
	{
		Reversal(array, l, r);
		int num = r - (m - l + 1);
		Reversal(array, l, num);
		Reversal(array, num + 1, r);
	}

	public static void BlockSwapGriesMills<T>(T[] array, int l, int m, int r)
	{
		int num = m - l + 1;
		int num2 = r - l + 1;
		if (num == 0 || num == num2)
		{
			return;
		}
		int num4;
		int num3 = (num4 = num);
		int num5 = num2 - num4;
		num4 += l;
		while (num3 != num5)
		{
			if (num3 > num5)
			{
				Swap(array, num4 - num3, num4, num5);
				num3 -= num5;
			}
			else
			{
				Swap(array, num4 - num3, num4 + num5 - num3, num3);
				num5 -= num3;
			}
		}
		Swap(array, num4 - num3, num4, num3);
	}

	public static int GreatestCommonDivisor(int i, int j)
	{
		if (i == 0)
		{
			return j;
		}
		if (j == 0)
		{
			return i;
		}
		while (i != j)
		{
			if (i > j)
			{
				i -= j;
			}
			else
			{
				j -= i;
			}
		}
		return i;
	}

	public static void BlockSwapJugglingBentley<T>(T[] array, int l, int m, int r)
	{
		int num = m - l + 1;
		int num2 = r - m;
		if (num <= 0 || num2 <= 0)
		{
			return;
		}
		int num3 = m - l + 1;
		int num4 = r - l + 1;
		int num5 = GreatestCommonDivisor(num3, num4);
		for (int i = 0; i < num5; i++)
		{
			T val = array[i];
			int num6 = i;
			while (true)
			{
				int num7 = num6 + num3;
				if (num7 >= num4)
				{
					num7 -= num4;
				}
				if (num7 == i)
				{
					break;
				}
				array[num6] = array[num7];
				num6 = num7;
			}
			array[num6] = val;
		}
	}

	public static void Copy<T>(T[] sourceArray, int sourceIndex, T[] destinationArray, int destinationIndex, int length, int threshold = 128)
	{
		if (length >= threshold)
		{
			Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			return;
		}
		for (int i = 0; i < length; i++)
		{
			destinationArray[destinationIndex++] = sourceArray[sourceIndex++];
		}
	}

	public static byte[] SortCounting(this byte[] inputArray)
	{
		byte[] array = new byte[inputArray.Length];
		int[] array2 = Histogram(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			Fill(array, (byte)num2, num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	public static void SortCountingInPlace(this byte[] arrayToSort)
	{
		int[] array = Histogram(arrayToSort);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			Fill(arrayToSort, (byte)num2, num, array[num2]);
			num += array[num2];
		}
	}

	public static byte[] SortCountingInPlaceFunc(this byte[] arrayToSort)
	{
		SortCountingInPlace(arrayToSort);
		return arrayToSort;
	}

	public static sbyte[] SortCounting(this sbyte[] inputArray)
	{
		sbyte[] array = new sbyte[inputArray.Length];
		int[] array2 = Histogram(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			Fill(array, (sbyte)num2, num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	public static void SortCountingInPlace(this sbyte[] arrayToSort)
	{
		int[] array = Histogram(arrayToSort);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			FillUsingBlockCopy(arrayToSort, (sbyte)(num2 - 128), num, array[num2]);
			num += array[num2];
		}
	}

	public static sbyte[] SortCountingInPlaceFunc(this sbyte[] arrayToSort)
	{
		SortCountingInPlace(arrayToSort);
		return arrayToSort;
	}

	public static ushort[] SortCounting(this ushort[] inputArray)
	{
		ushort[] array = new ushort[inputArray.Length];
		int[] array2 = Histogram(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			FillUsingBlockCopy(array, (ushort)num2, num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	public static void SortCountingInPlace(this ushort[] arrayToSort)
	{
		int[] array = Histogram(arrayToSort);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			FillUsingBlockCopy(arrayToSort, (ushort)num2, num, array[num2]);
			num += array[num2];
		}
	}

	public static ushort[] SortCountingInPlaceFunc(this ushort[] arrayToSort)
	{
		SortCountingInPlace(arrayToSort);
		return arrayToSort;
	}

	public static short[] SortCounting(this short[] inputArray)
	{
		short[] array = new short[inputArray.Length];
		int[] array2 = Histogram(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			FillUsingBlockCopy(array, (short)(num2 - 32768), num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	public static void SortCountingInPlace(this short[] arrayToSort)
	{
		int[] array = Histogram(arrayToSort);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			FillUsingBlockCopy(arrayToSort, (short)(num2 - 32768), num, array[num2]);
			num += array[num2];
		}
	}

	public static short[] SortCountingInPlaceFunc(this short[] arrayToSort)
	{
		SortCountingInPlace(arrayToSort);
		return arrayToSort;
	}

	public static void Fill<T>(this T[] arrayToFill, T value)
	{
		for (int i = 0; i < arrayToFill.Length; i++)
		{
			arrayToFill[i] = value;
		}
	}

	public static void Fill<T>(this T[] arrayToFill, T value, int startIndex, int length)
	{
		int num = startIndex + length;
		for (int i = startIndex; i < num; i++)
		{
			arrayToFill[i] = value;
		}
	}

	public static void FillUsingBlockCopy<T>(this T[] array, T value) where T : struct
	{
		int num = smethod_0<T>();
		int num2 = 32;
		int num3 = 0;
		int num4 = Math.Min(32, array.Length);
		while (num3 < num4)
		{
			array[num3++] = value;
		}
		num4 = array.Length;
		while (num3 < num4)
		{
			int num5 = Math.Min(num2, num4 - num3);
			Buffer.BlockCopy(array, 0, array, num3 * num, num5 * num);
			num3 += num2;
			num2 *= 2;
		}
	}

	public static void FillUsingBlockCopy<T>(this T[] array, T value, int startIndex, int count) where T : struct
	{
		int num = smethod_0<T>();
		int num2 = 32;
		int num3 = startIndex;
		int num4 = startIndex + Math.Min(32, count);
		while (num3 < num4)
		{
			array[num3++] = value;
		}
		num4 = startIndex + count;
		while (num3 < num4)
		{
			int num5 = Math.Min(num2, num4 - num3);
			Buffer.BlockCopy(array, startIndex * num, array, num3 * num, num5 * num);
			num3 += num2;
			num2 *= 2;
		}
	}

	private static int smethod_0<T>()
	{
		if (!(typeof(T) == typeof(byte)) && !(typeof(T) == typeof(sbyte)))
		{
			if (!(typeof(T) == typeof(ushort)) && !(typeof(T) == typeof(short)))
			{
				if (!(typeof(T) == typeof(uint)) && !(typeof(T) == typeof(int)))
				{
					if (!(typeof(T) == typeof(ulong)) && !(typeof(T) == typeof(long)))
					{
						throw new ArgumentException($"Type '{typeof(T)}' is unsupported.");
					}
					return 8;
				}
				return 4;
			}
			return 2;
		}
		return 1;
	}

	public static int[] Histogram(this byte[] inArray)
	{
		int[] array = new int[256];
		for (uint num = 0u; num < inArray.Length; num++)
		{
			array[inArray[num]]++;
		}
		return array;
	}

	public static int[] Histogram(this sbyte[] inArray)
	{
		int[] array = new int[256];
		for (uint num = 0u; num < inArray.Length; num++)
		{
			array[inArray[num] + 128]++;
		}
		return array;
	}

	public static int[] Histogram(this ushort[] inArray)
	{
		int[] array = new int[65536];
		for (uint num = 0u; num < inArray.Length; num++)
		{
			array[inArray[num]]++;
		}
		return array;
	}

	public static int[] Histogram(this short[] inArray)
	{
		int[] array = new int[65536];
		for (uint num = 0u; num < inArray.Length; num++)
		{
			array[inArray[num] + 32768]++;
		}
		return array;
	}

	public static int[] Histogram(this uint[] inArray, int numberOfBits)
	{
		if (numberOfBits <= 31)
		{
			int num = 1 << numberOfBits;
			int[] array = new int[num];
			uint num2 = (uint)(num - 1);
			for (uint num3 = 0u; num3 < inArray.Length; num3++)
			{
				array[num2 & inArray[num3]]++;
			}
			return array;
		}
		throw new ArgumentOutOfRangeException("numberOfBits must be <= 31");
	}

	public static uint[][] HistogramByteComponents(uint[] inArray, int l, int r)
	{
		uint[][] array = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		for (int j = l; j <= r; j++)
		{
			uint num = inArray[j];
			array2[num & 0xFF]++;
			array3[(num >> 8) & 0xFF]++;
			array4[(num >> 16) & 0xFF]++;
			array5[(num >> 24) & 0xFF]++;
		}
		return array;
	}

	public static uint[][][] HistogramByteComponentsAcrossWorkQuantas(uint[] inArray, uint workQuanta)
	{
		uint num = (uint)((inArray.Length % workQuanta == 0L) ? (inArray.Length / workQuanta) : (inArray.Length / workQuanta + 1L));
		uint[][][] array = new uint[num][][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new uint[4][];
			for (int j = 0; j < 4; j++)
			{
				array[i][j] = new uint[256];
			}
		}
		uint num2 = (uint)(inArray.Length / workQuanta);
		int num3 = 0;
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		uint num4;
		for (num4 = 0u; num4 < num2; num4++)
		{
			for (uint num5 = 0u; num5 < workQuanta; num5++)
			{
				uInt32ByteUnion.integer = inArray[num3++];
				array[num4][0][uInt32ByteUnion.byte0]++;
				array[num4][1][uInt32ByteUnion.byte1]++;
				array[num4][2][uInt32ByteUnion.byte2]++;
				array[num4][3][uInt32ByteUnion.byte3]++;
			}
		}
		while (num3 < inArray.Length)
		{
			uInt32ByteUnion.integer = inArray[num3++];
			array[num4][0][uInt32ByteUnion.byte0]++;
			array[num4][1][uInt32ByteUnion.byte1]++;
			array[num4][2][uInt32ByteUnion.byte2]++;
			array[num4][3][uInt32ByteUnion.byte3]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponentsAcrossWorkQuantasQC(uint[] inArray, int workQuanta, uint numberOfQuantas, uint whichByte)
	{
		uint[][] array = new uint[numberOfQuantas][];
		for (int i = 0; i < numberOfQuantas; i++)
		{
			array[i] = new uint[256];
		}
		int num = inArray.Length / workQuanta;
		int num2 = 0;
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		uint num3 = 0u;
		if (whichByte == 0)
		{
			for (; num3 < num; num3++)
			{
				for (uint num4 = 0u; num4 < workQuanta; num4++)
				{
					uInt32ByteUnion.integer = inArray[num2++];
					array[num3][uInt32ByteUnion.byte0]++;
				}
			}
			while (num2 < inArray.Length)
			{
				uInt32ByteUnion.integer = inArray[num2++];
				array[num3][uInt32ByteUnion.byte0]++;
			}
		}
		else if (whichByte == 1)
		{
			for (; num3 < num; num3++)
			{
				for (uint num5 = 0u; num5 < workQuanta; num5++)
				{
					uInt32ByteUnion.integer = inArray[num2++];
					array[num3][uInt32ByteUnion.byte1]++;
				}
			}
			while (num2 < inArray.Length)
			{
				uInt32ByteUnion.integer = inArray[num2++];
				array[num3][uInt32ByteUnion.byte1]++;
			}
		}
		else if (whichByte == 2)
		{
			for (; num3 < num; num3++)
			{
				for (uint num6 = 0u; num6 < workQuanta; num6++)
				{
					uInt32ByteUnion.integer = inArray[num2++];
					array[num3][uInt32ByteUnion.byte2]++;
				}
			}
			while (num2 < inArray.Length)
			{
				uInt32ByteUnion.integer = inArray[num2++];
				array[num3][uInt32ByteUnion.byte2]++;
			}
		}
		else
		{
			for (; num3 < num; num3++)
			{
				for (uint num7 = 0u; num7 < workQuanta; num7++)
				{
					uInt32ByteUnion.integer = inArray[num2++];
					array[num3][uInt32ByteUnion.byte3]++;
				}
			}
			while (num2 < inArray.Length)
			{
				uInt32ByteUnion.integer = inArray[num2++];
				array[num3][uInt32ByteUnion.byte3]++;
			}
		}
		return array;
	}

	public static uint[][] HistogramByteComponentsAcrossWorkQuantasQC(uint[] inArray, int l, int r, int workQuanta, uint numberOfQuantas, uint whichByte)
	{
		int num = (int)(8 * whichByte);
		uint[][] array = new uint[numberOfQuantas][];
		for (int i = 0; i < numberOfQuantas; i++)
		{
			array[i] = new uint[256];
		}
		if (l <= r)
		{
			long num2 = l / workQuanta;
			long num3 = r / workQuanta;
			if (num2 == num3)
			{
				int num4 = (int)num2;
				for (int j = l; j <= r; j++)
				{
					uint num5 = (inArray[j] >> num) & 0xFF;
					array[num4][num5]++;
				}
			}
			else
			{
				int num6 = (int)num2;
				int num7 = (int)(num2 * workQuanta + (workQuanta - 1));
				int k;
				for (k = l; k <= num7; k++)
				{
					uint num8 = (inArray[k] >> num) & 0xFF;
					array[num6][num8]++;
				}
				num6 = (int)num3;
				for (k = (int)(num3 * workQuanta); k <= r; k++)
				{
					uint num9 = (inArray[k] >> num) & 0xFF;
					array[num6][num9]++;
				}
				k = (int)((num2 + 1L) * workQuanta);
				num3--;
				for (num6 = (int)(num2 + 1L); num6 <= num3; num6++)
				{
					for (uint num10 = 0u; num10 < workQuanta; num10++)
					{
						uint num11 = (inArray[k++] >> num) & 0xFF;
						array[num6][num11]++;
					}
				}
			}
			return array;
		}
		return array;
	}

	public static uint[][][] HistogramByteComponentsAcrossWorkQuantasDQC(uint[] inArray, uint workQuanta)
	{
		uint num = (uint)((inArray.Length % workQuanta == 0L) ? (inArray.Length / workQuanta) : (inArray.Length / workQuanta + 1L));
		uint[][][] array = new uint[4][][];
		uint num2;
		for (int i = 0; i < 4; i++)
		{
			array[i] = new uint[num][];
			for (num2 = 0u; num2 < num; num2++)
			{
				array[i][num2] = new uint[256];
			}
		}
		uint num3 = (uint)(inArray.Length / workQuanta);
		int num4 = 0;
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		for (num2 = 0u; num2 < num3; num2++)
		{
			for (uint num5 = 0u; num5 < workQuanta; num5++)
			{
				uInt32ByteUnion.integer = inArray[num4++];
				array[0][num2][uInt32ByteUnion.byte0]++;
				array[1][num2][uInt32ByteUnion.byte1]++;
				array[2][num2][uInt32ByteUnion.byte2]++;
				array[3][num2][uInt32ByteUnion.byte3]++;
			}
		}
		while (num4 < inArray.Length)
		{
			uInt32ByteUnion.integer = inArray[num4++];
			array[0][num2][uInt32ByteUnion.byte0]++;
			array[1][num2][uInt32ByteUnion.byte1]++;
			array[2][num2][uInt32ByteUnion.byte2]++;
			array[3][num2][uInt32ByteUnion.byte3]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponents<T>(T[] inArray, int l, int r, Func<T, uint> getKey)
	{
		uint[][] array = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		for (int j = l; j <= r; j++)
		{
			uInt32ByteUnion.integer = getKey(inArray[j]);
			array2[uInt32ByteUnion.byte0]++;
			array3[uInt32ByteUnion.byte1]++;
			array4[uInt32ByteUnion.byte2]++;
			array5[uInt32ByteUnion.byte3]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponents<T>(T[] inArray, int l, int r, Func<T, ulong> getKey)
	{
		uint[][] array = new uint[8][];
		for (int i = 0; i < 8; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		uint[] array6 = array[4];
		uint[] array7 = array[5];
		uint[] array8 = array[6];
		uint[] array9 = array[7];
		UInt64ByteUnion uInt64ByteUnion = default(UInt64ByteUnion);
		for (int j = l; j <= r; j++)
		{
			uInt64ByteUnion.integer = getKey(inArray[j]);
			array2[uInt64ByteUnion.byte0]++;
			array3[uInt64ByteUnion.byte1]++;
			array4[uInt64ByteUnion.byte2]++;
			array5[uInt64ByteUnion.byte3]++;
			array6[uInt64ByteUnion.byte4]++;
			array7[uInt64ByteUnion.byte5]++;
			array8[uInt64ByteUnion.byte6]++;
			array9[uInt64ByteUnion.byte7]++;
		}
		return array;
	}

	public static Tuple<uint[][], uint[]> HistogramByteComponentsAndKeyArray<T>(T[] inArray, int l, int r, Func<T, uint> getKey)
	{
		uint[] array = new uint[inArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array2[i] = new uint[256];
		}
		uint[] array3 = array2[0];
		uint[] array4 = array2[1];
		uint[] array5 = array2[2];
		uint[] array6 = array2[3];
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		for (int j = l; j <= r; j++)
		{
			uInt32ByteUnion.integer = getKey(inArray[j]);
			array[j] = uInt32ByteUnion.integer;
			array3[uInt32ByteUnion.byte0]++;
			array4[uInt32ByteUnion.byte1]++;
			array5[uInt32ByteUnion.byte2]++;
			array6[uInt32ByteUnion.byte3]++;
		}
		return new Tuple<uint[][], uint[]>(array2, array);
	}

	public static Tuple<uint[][], ulong[]> HistogramByteComponentsAndKeyArray<T>(T[] inArray, int l, int r, Func<T, ulong> getKey)
	{
		ulong[] array = new ulong[inArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array2[i] = new uint[256];
		}
		uint[] array3 = array2[0];
		uint[] array4 = array2[1];
		uint[] array5 = array2[2];
		uint[] array6 = array2[3];
		uint[] array7 = array2[4];
		uint[] array8 = array2[5];
		uint[] array9 = array2[6];
		uint[] array10 = array2[7];
		UInt64ByteUnion uInt64ByteUnion = default(UInt64ByteUnion);
		for (int j = l; j <= r; j++)
		{
			uInt64ByteUnion.integer = getKey(inArray[j]);
			array[j] = uInt64ByteUnion.integer;
			array3[uInt64ByteUnion.byte0]++;
			array4[uInt64ByteUnion.byte1]++;
			array5[uInt64ByteUnion.byte2]++;
			array6[uInt64ByteUnion.byte3]++;
			array7[uInt64ByteUnion.byte4]++;
			array8[uInt64ByteUnion.byte5]++;
			array9[uInt64ByteUnion.byte6]++;
			array10[uInt64ByteUnion.byte7]++;
		}
		return new Tuple<uint[][], ulong[]>(array2, array);
	}

	public static uint[] HistogramByteComponents1D(uint[] inArray, int l, int r)
	{
		uint[] array = new uint[1024];
		UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
		for (int i = l; i <= r; i++)
		{
			uInt32ByteUnion.integer = inArray[i];
			array[uInt32ByteUnion.byte0]++;
			array[256 + uInt32ByteUnion.byte1]++;
			array[512 + uInt32ByteUnion.byte2]++;
			array[768 + uInt32ByteUnion.byte3]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponents(ulong[] inArray, int l, int r)
	{
		uint[][] array = new uint[8][];
		for (int i = 0; i < 8; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		uint[] array6 = array[4];
		uint[] array7 = array[5];
		uint[] array8 = array[6];
		uint[] array9 = array[7];
		UInt64ByteUnion uInt64ByteUnion = default(UInt64ByteUnion);
		for (int j = l; j <= r; j++)
		{
			uInt64ByteUnion.integer = inArray[j];
			array2[uInt64ByteUnion.byte0]++;
			array3[uInt64ByteUnion.byte1]++;
			array4[uInt64ByteUnion.byte2]++;
			array5[uInt64ByteUnion.byte3]++;
			array6[uInt64ByteUnion.byte4]++;
			array7[uInt64ByteUnion.byte5]++;
			array8[uInt64ByteUnion.byte6]++;
			array9[uInt64ByteUnion.byte7]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponents(int[] inArray, int l, int r)
	{
		uint[][] array = new uint[8][];
		for (int i = 0; i < 8; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		Int32ByteUnion int32ByteUnion = default(Int32ByteUnion);
		for (int j = l; j <= r; j++)
		{
			int32ByteUnion.integer = inArray[j];
			array2[int32ByteUnion.byte0]++;
			array3[int32ByteUnion.byte1]++;
			array4[int32ByteUnion.byte2]++;
			array5[(inArray[j] >>> 24) ^ 0x80]++;
		}
		return array;
	}

	public static uint[][] HistogramByteComponents(long[] inArray, int l, int r)
	{
		uint[][] array = new uint[8][];
		for (int i = 0; i < 8; i++)
		{
			array[i] = new uint[256];
		}
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		uint[] array6 = array[4];
		uint[] array7 = array[5];
		uint[] array8 = array[6];
		uint[] array9 = array[7];
		Int64ByteUnion int64ByteUnion = default(Int64ByteUnion);
		for (int j = l; j <= r; j++)
		{
			int64ByteUnion.integer = inArray[j];
			array2[int64ByteUnion.byte0]++;
			array3[int64ByteUnion.byte1]++;
			array4[int64ByteUnion.byte2]++;
			array5[int64ByteUnion.byte3]++;
			array6[int64ByteUnion.byte4]++;
			array7[int64ByteUnion.byte5]++;
			array8[int64ByteUnion.byte6]++;
			array9[(inArray[j] >>> 56) ^ 0x80L]++;
		}
		return array;
	}

	public static Tuple<uint[][], int> HistogramByteComponentsAndStatistics(long[] inArray, int l, int r)
	{
		uint[][] array = new uint[8][];
		for (int i = 0; i < 8; i++)
		{
			array[i] = new uint[256];
		}
		int num = 0;
		uint[] array2 = array[0];
		uint[] array3 = array[1];
		uint[] array4 = array[2];
		uint[] array5 = array[3];
		uint[] array6 = array[4];
		uint[] array7 = array[5];
		uint[] array8 = array[6];
		uint[] array9 = array[7];
		Int64ByteUnion int64ByteUnion = default(Int64ByteUnion);
		int j = l;
		if (j <= r)
		{
			int64ByteUnion.integer = inArray[j];
			array2[int64ByteUnion.byte0]++;
			array3[int64ByteUnion.byte1]++;
			array4[int64ByteUnion.byte2]++;
			array5[int64ByteUnion.byte3]++;
			array6[int64ByteUnion.byte4]++;
			array7[int64ByteUnion.byte5]++;
			array8[int64ByteUnion.byte6]++;
			array9[(inArray[j] >>> 56) ^ 0x80L]++;
			j++;
			num++;
		}
		for (; j <= r; j++)
		{
			int64ByteUnion.integer = inArray[j];
			array2[int64ByteUnion.byte0]++;
			array3[int64ByteUnion.byte1]++;
			array4[int64ByteUnion.byte2]++;
			array5[int64ByteUnion.byte3]++;
			array6[int64ByteUnion.byte4]++;
			array7[int64ByteUnion.byte5]++;
			array8[int64ByteUnion.byte6]++;
			array9[(inArray[j] >>> 56) ^ 0x80L]++;
			if (inArray[j] >= inArray[j - 1])
			{
				num++;
			}
		}
		return new Tuple<uint[][], int>(array, num);
	}

	public static int[] HistogramOneByteComponent(uint[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		for (int i = l; i <= r; i++)
		{
			array[(byte)(inArray[i] >> shiftRightAmount)]++;
		}
		return array;
	}

	public static int[] HistogramOneByteComponent(ulong[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		for (int i = l; i <= r; i++)
		{
			array[(byte)(inArray[i] >> shiftRightAmount)]++;
		}
		return array;
	}

	public static int[] HistogramOneByteComponent(long[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		if (shiftRightAmount != 56)
		{
			for (int i = l; i <= r; i++)
			{
				array[(byte)(inArray[i] >> shiftRightAmount)]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				array[(byte)(inArray[j] >> shiftRightAmount) ^ 0x80]++;
			}
		}
		return array;
	}

	public static int[] HistogramOneByteComponent(int[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		if (shiftRightAmount != 24)
		{
			for (int i = l; i <= r; i++)
			{
				array[(byte)(inArray[i] >> shiftRightAmount)]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				array[(byte)(inArray[j] >> shiftRightAmount) ^ 0x80]++;
			}
		}
		return array;
	}

	public static int[] HistogramOneByteComponent(float[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		FloatUInt32Union floatUInt32Union = default(FloatUInt32Union);
		if (shiftRightAmount != 24)
		{
			for (int i = l; i <= r; i++)
			{
				floatUInt32Union.floatValue = inArray[i];
				uint num = (((floatUInt32Union.uinteger & 0x80000000u) == 0) ? (floatUInt32Union.uinteger >> shiftRightAmount) : ((floatUInt32Union.uinteger ^ 0xFFFFFFFFu) >> shiftRightAmount));
				array[(byte)num]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				floatUInt32Union.floatValue = inArray[j];
				uint num2 = (((floatUInt32Union.uinteger & 0x80000000u) != 0) ? ((floatUInt32Union.uinteger ^ 0xFFFFFFFFu) >> shiftRightAmount) : ((floatUInt32Union.uinteger >> shiftRightAmount) ^ 0x80));
				array[(byte)num2]++;
			}
		}
		return array;
	}

	public static int[] HistogramOneByteComponent(double[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		DoubleUInt64Union doubleUInt64Union = default(DoubleUInt64Union);
		if (shiftRightAmount != 56)
		{
			for (int i = l; i <= r; i++)
			{
				doubleUInt64Union.doubleValue = inArray[i];
				ulong num = (((doubleUInt64Union.ulongInteger & 0x8000000000000000uL) != 0L) ? ((doubleUInt64Union.ulongInteger ^ 0xFFFFFFFFFFFFFFFFuL) >> shiftRightAmount) : (doubleUInt64Union.ulongInteger >> shiftRightAmount));
				array[(byte)num]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				doubleUInt64Union.doubleValue = inArray[j];
				ulong num2 = (((doubleUInt64Union.ulongInteger & 0x8000000000000000uL) != 0L) ? ((doubleUInt64Union.ulongInteger ^ 0xFFFFFFFFFFFFFFFFuL) >> shiftRightAmount) : ((doubleUInt64Union.ulongInteger >> shiftRightAmount) ^ 0x80L));
				array[(byte)num2]++;
			}
		}
		return array;
	}

	public static int[] HistogramNbitComponents(long[] inArray, int l, int r, int shiftRightAmount, int numberOfBitPerComponent)
	{
		long num = 1L << numberOfBitPerComponent;
		ulong num2 = (ulong)num / 2uL;
		ulong num3 = (ulong)(num - 1L);
		int[] array = new int[num];
		if (shiftRightAmount != 64 - numberOfBitPerComponent)
		{
			for (int i = l; i <= r; i++)
			{
				array[(ulong)(inArray[i] >>> shiftRightAmount) & num3]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				array[(ulong)(inArray[j] >>> shiftRightAmount) ^ num2]++;
			}
		}
		return array;
	}

	public static int[] HistogramByteComponentsUsingUnion(ulong[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		int num = shiftRightAmount / 8;
		UInt64ByteUnion uInt64ByteUnion = default(UInt64ByteUnion);
		switch (num)
		{
		case 0:
		{
			for (int num4 = l; num4 <= r; num4++)
			{
				uInt64ByteUnion.integer = inArray[num4];
				array[uInt64ByteUnion.byte0]++;
			}
			break;
		}
		case 1:
		{
			for (int m = l; m <= r; m++)
			{
				uInt64ByteUnion.integer = inArray[m];
				array[uInt64ByteUnion.byte1]++;
			}
			break;
		}
		case 2:
		{
			for (int num2 = l; num2 <= r; num2++)
			{
				uInt64ByteUnion.integer = inArray[num2];
				array[uInt64ByteUnion.byte2]++;
			}
			break;
		}
		case 3:
		{
			for (int j = l; j <= r; j++)
			{
				uInt64ByteUnion.integer = inArray[j];
				array[uInt64ByteUnion.byte3]++;
			}
			break;
		}
		case 4:
		{
			for (int num3 = l; num3 <= r; num3++)
			{
				uInt64ByteUnion.integer = inArray[num3];
				array[uInt64ByteUnion.byte4]++;
			}
			break;
		}
		case 5:
		{
			for (int n = l; n <= r; n++)
			{
				uInt64ByteUnion.integer = inArray[n];
				array[uInt64ByteUnion.byte5]++;
			}
			break;
		}
		case 6:
		{
			for (int k = l; k <= r; k++)
			{
				uInt64ByteUnion.integer = inArray[k];
				array[uInt64ByteUnion.byte6]++;
			}
			break;
		}
		case 7:
		{
			for (int i = l; i <= r; i++)
			{
				uInt64ByteUnion.integer = inArray[i];
				array[uInt64ByteUnion.byte7]++;
			}
			break;
		}
		}
		return array;
	}

	public static int[] HistogramByteComponentsUsingUnion(long[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		int num = shiftRightAmount / 8;
		Int64ByteUnion int64ByteUnion = default(Int64ByteUnion);
		switch (num)
		{
		case 0:
		{
			for (int num4 = l; num4 <= r; num4++)
			{
				int64ByteUnion.integer = inArray[num4];
				array[int64ByteUnion.byte0]++;
			}
			break;
		}
		case 1:
		{
			for (int m = l; m <= r; m++)
			{
				int64ByteUnion.integer = inArray[m];
				array[int64ByteUnion.byte1]++;
			}
			break;
		}
		case 2:
		{
			for (int num2 = l; num2 <= r; num2++)
			{
				int64ByteUnion.integer = inArray[num2];
				array[int64ByteUnion.byte2]++;
			}
			break;
		}
		case 3:
		{
			for (int j = l; j <= r; j++)
			{
				int64ByteUnion.integer = inArray[j];
				array[int64ByteUnion.byte3]++;
			}
			break;
		}
		case 4:
		{
			for (int num3 = l; num3 <= r; num3++)
			{
				int64ByteUnion.integer = inArray[num3];
				array[int64ByteUnion.byte4]++;
			}
			break;
		}
		case 5:
		{
			for (int n = l; n <= r; n++)
			{
				int64ByteUnion.integer = inArray[n];
				array[int64ByteUnion.byte5]++;
			}
			break;
		}
		case 6:
		{
			for (int k = l; k <= r; k++)
			{
				int64ByteUnion.integer = inArray[k];
				array[int64ByteUnion.byte6]++;
			}
			break;
		}
		case 7:
		{
			for (int i = l; i <= r; i++)
			{
				array[(inArray[i] >>> shiftRightAmount) ^ 0x80L]++;
			}
			break;
		}
		}
		return array;
	}

	public static int[] Histogram9bitComponents(float[] inArray, int l, int r, uint bitMask, int shiftRightAmount)
	{
		int[] array = new int[512];
		if (shiftRightAmount != 23)
		{
			for (int i = l; i <= r; i++)
			{
				array[((uint)inArray[i] & bitMask) >> shiftRightAmount]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				array[((uint)inArray[j] >> shiftRightAmount) ^ 0x100]++;
			}
		}
		return array;
	}

	public static int[] Histogram12bitComponents(double[] inArray, int l, int r, ulong bitMask, int shiftRightAmount)
	{
		int[] array = new int[4096];
		if (shiftRightAmount != 52)
		{
			for (int i = l; i <= r; i++)
			{
				ulong num = BitConverter.ToUInt64(BitConverter.GetBytes(inArray[i]), 0);
				array[(num & bitMask) >> shiftRightAmount]++;
			}
		}
		else
		{
			for (int j = l; j <= r; j++)
			{
				ulong num2 = BitConverter.ToUInt64(BitConverter.GetBytes(inArray[j]), 0);
				array[(num2 >> shiftRightAmount) ^ 0x800L]++;
			}
		}
		return array;
	}

	public static uint[][] HistogramNBitsPerComponents(uint[] inArray, int l, int r, int bitsPerComponent)
	{
		int num = 1 << bitsPerComponent;
		int num2 = (32 + bitsPerComponent - 1) / bitsPerComponent;
		uint[][] array = new uint[num2][];
		for (int i = 0; i < num2; i++)
		{
			array[i] = new uint[num];
		}
		switch (bitsPerComponent)
		{
		case 8:
		{
			uint[] array21 = array[0];
			uint[] array22 = array[1];
			uint[] array23 = array[2];
			uint[] array24 = array[3];
			UInt32ByteUnion uInt32ByteUnion = default(UInt32ByteUnion);
			for (int num14 = l; num14 <= r; num14++)
			{
				uInt32ByteUnion.integer = inArray[num14];
				array21[uInt32ByteUnion.byte0]++;
				array22[uInt32ByteUnion.byte1]++;
				array23[uInt32ByteUnion.byte2]++;
				array24[uInt32ByteUnion.byte3]++;
			}
			break;
		}
		case 9:
		{
			uint[] array7 = array[0];
			uint[] array8 = array[1];
			uint[] array9 = array[2];
			uint[] array10 = array[3];
			for (int num6 = l; num6 <= r; num6++)
			{
				uint num7 = inArray[num6];
				array7[num7 & 0x1FF]++;
				array8[(num7 & 0x3FE00) >> 9]++;
				array9[(num7 & 0x7FC0000) >> 18]++;
				array10[(num7 & 0xF8000000u) >> 27]++;
			}
			break;
		}
		case 10:
		{
			uint[] array14 = array[0];
			uint[] array15 = array[1];
			uint[] array16 = array[2];
			uint[] array17 = array[3];
			for (int num10 = l; num10 <= r; num10++)
			{
				uint num11 = inArray[num10];
				array14[num11 & 0x3FF]++;
				array15[(num11 & 0xFFC00) >> 10]++;
				array16[(num11 & 0x3FF00000) >> 20]++;
				array17[(num11 & 0xC0000000u) >> 30]++;
			}
			break;
		}
		case 11:
		{
			uint[] array2 = array[0];
			uint[] array3 = array[1];
			uint[] array4 = array[2];
			for (int m = l; m <= r; m++)
			{
				uint num5 = inArray[m];
				array2[num5 & 0x7FF]++;
				array3[(num5 & 0x3FF800) >> 11]++;
				array4[(num5 & 0xFFC00000u) >> 22]++;
			}
			break;
		}
		case 12:
		{
			uint[] array18 = array[0];
			uint[] array19 = array[1];
			uint[] array20 = array[2];
			for (int num12 = l; num12 <= r; num12++)
			{
				uint num13 = inArray[num12];
				array18[num13 & 0xFFF]++;
				array19[(num13 & 0xFFF000) >> 12]++;
				array20[(num13 & 0xFF000000u) >> 24]++;
			}
			break;
		}
		case 13:
		{
			uint[] array11 = array[0];
			uint[] array12 = array[1];
			uint[] array13 = array[2];
			for (int num8 = l; num8 <= r; num8++)
			{
				uint num9 = inArray[num8];
				array11[num9 & 0x1FFF]++;
				array12[(num9 & 0x3FFE000) >> 13]++;
				array13[(num9 & 0xFC000000u) >> 26]++;
			}
			break;
		}
		case 16:
		{
			uint[] array5 = array[0];
			uint[] array6 = array[1];
			UInt32UShortUnion uInt32UShortUnion = default(UInt32UShortUnion);
			for (int n = l; n <= r; n++)
			{
				uInt32UShortUnion.integer = inArray[n];
				array5[uInt32UShortUnion.ushort0]++;
				array6[uInt32UShortUnion.ushort1]++;
			}
			break;
		}
		default:
		{
			uint num3 = (uint)(num - 1);
			for (int j = l; j <= r; j++)
			{
				uint num4 = inArray[j];
				for (int k = 0; k < num2; k++)
				{
					array[k][num4 & num3]++;
					num3 <<= bitsPerComponent;
				}
			}
			break;
		}
		}
		return array;
	}

	public static uint[][] HistogramNBitsPerComponents(ulong[] inArray, int l, int r, int bitsPerComponent)
	{
		int num = 1 << bitsPerComponent;
		int num2 = (32 + bitsPerComponent - 1) / bitsPerComponent;
		uint[][] array = new uint[num2][];
		for (int i = 0; i < num2; i++)
		{
			array[i] = new uint[num];
		}
		switch (bitsPerComponent)
		{
		case 8:
		{
			uint[] array37 = array[0];
			uint[] array38 = array[1];
			uint[] array39 = array[2];
			uint[] array40 = array[3];
			uint[] array41 = array[4];
			uint[] array42 = array[5];
			uint[] array43 = array[6];
			uint[] array44 = array[7];
			UInt64ByteUnion uInt64ByteUnion = default(UInt64ByteUnion);
			for (int num14 = l; num14 <= r; num14++)
			{
				uInt64ByteUnion.integer = inArray[num14];
				array37[uInt64ByteUnion.byte0]++;
				array38[uInt64ByteUnion.byte1]++;
				array39[uInt64ByteUnion.byte2]++;
				array40[uInt64ByteUnion.byte3]++;
				array41[uInt64ByteUnion.byte4]++;
				array42[uInt64ByteUnion.byte5]++;
				array43[uInt64ByteUnion.byte6]++;
				array44[uInt64ByteUnion.byte7]++;
			}
			break;
		}
		case 9:
		{
			uint[] array12 = array[0];
			uint[] array13 = array[1];
			uint[] array14 = array[2];
			uint[] array15 = array[3];
			uint[] array16 = array[4];
			uint[] array17 = array[5];
			uint[] array18 = array[6];
			uint[] array19 = array[7];
			for (int num6 = l; num6 <= r; num6++)
			{
				ulong num7 = inArray[num6];
				array12[num7 & 0x1FFL]++;
				array13[(num7 & 0x3FE00L) >> 9]++;
				array14[(num7 & 0x7FC0000L) >> 18]++;
				array15[(num7 & 0xFF8000000L) >> 27]++;
				array16[(num7 & 0x1FF000000000L) >> 36]++;
				array17[(num7 & 0x3FE00000000000L) >> 45]++;
				array18[(num7 & 0x7FC0000000000000L) >> 54]++;
				array19[(num7 & 0x8000000000000000uL) >> 63]++;
			}
			break;
		}
		case 10:
		{
			uint[] array25 = array[0];
			uint[] array26 = array[1];
			uint[] array27 = array[2];
			uint[] array28 = array[3];
			uint[] array29 = array[4];
			uint[] array30 = array[5];
			uint[] array31 = array[6];
			for (int num10 = l; num10 <= r; num10++)
			{
				ulong num11 = inArray[num10];
				array25[num11 & 0x3FFL]++;
				array26[(num11 & 0xFFC00L) >> 10]++;
				array27[(num11 & 0x3FF00000L) >> 20]++;
				array28[(num11 & 0xFFC0000000L) >> 30]++;
				array29[(num11 & 0x3FF0000000000L) >> 40]++;
				array30[(num11 & 0xFFC000000000000L) >> 50]++;
				array31[(num11 & 0xF000000000000000uL) >> 60]++;
			}
			break;
		}
		case 11:
		{
			uint[] array2 = array[0];
			uint[] array3 = array[1];
			uint[] array4 = array[2];
			uint[] array5 = array[3];
			uint[] array6 = array[4];
			uint[] array7 = array[5];
			for (int m = l; m <= r; m++)
			{
				ulong num5 = inArray[m];
				array2[num5 & 0x7FFL]++;
				array3[(num5 & 0x3FF800L) >> 11]++;
				array4[(num5 & 0x1FFC00000L) >> 22]++;
				array5[(num5 & 0xFFE00000000L) >> 33]++;
				array6[(num5 & 0x7FF00000000000L) >> 44]++;
				array7[(num5 & 0xFF80000000000000uL) >> 55]++;
			}
			break;
		}
		case 12:
		{
			for (int num12 = l; num12 <= r; num12++)
			{
				uint[] array32 = array[0];
				uint[] array33 = array[1];
				uint[] array34 = array[2];
				uint[] array35 = array[3];
				uint[] array36 = array[4];
				uint[] obj = array[5];
				ulong num13 = inArray[num12];
				array32[num13 & 0xFFFL]++;
				array33[(num13 & 0xFFF000L) >> 12]++;
				array34[(num13 & 0xFFF000000L) >> 24]++;
				array35[(num13 & 0xFFF000000000L) >> 36]++;
				array36[(num13 & 0xFFF000000000000L) >> 48]++;
				obj[(num13 & 0xF000000000000000uL) >> 60]++;
			}
			break;
		}
		case 13:
		{
			uint[] array20 = array[0];
			uint[] array21 = array[1];
			uint[] array22 = array[2];
			uint[] array23 = array[3];
			uint[] array24 = array[4];
			for (int num8 = l; num8 <= r; num8++)
			{
				ulong num9 = inArray[num8];
				array20[num9 & 0x1FFFL]++;
				array21[(num9 & 0x3FFE000L) >> 13]++;
				array22[(num9 & 0x7FFC000000L) >> 26]++;
				array23[(num9 & 0xFFF8000000000L) >> 39]++;
				array24[(num9 & 0xFFF0000000000000uL) >> 52]++;
			}
			break;
		}
		case 16:
		{
			uint[] array8 = array[0];
			uint[] array9 = array[1];
			uint[] array10 = array[2];
			uint[] array11 = array[3];
			UInt64UShortUnion uInt64UShortUnion = default(UInt64UShortUnion);
			for (int n = l; n <= r; n++)
			{
				uInt64UShortUnion.integer = inArray[n];
				array8[uInt64UShortUnion.ushort0]++;
				array9[uInt64UShortUnion.ushort1]++;
				array10[uInt64UShortUnion.ushort0]++;
				array11[uInt64UShortUnion.ushort1]++;
			}
			break;
		}
		default:
		{
			uint num3 = (uint)(num - 1);
			for (int j = l; j <= r; j++)
			{
				ulong num4 = inArray[j];
				for (int k = 0; k < num2; k++)
				{
					array[k][num4 & num3]++;
					num3 <<= bitsPerComponent;
				}
			}
			break;
		}
		}
		return array;
	}

	public static void InsertionSort<T>(List<T> a, int l, int size, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = l + size;
		for (int i = l + 1; i < num; i++)
		{
			if (comparer2.Compare(a[i], a[i - 1]) < 0)
			{
				T val = a[i];
				a[i] = a[i - 1];
				int num2 = i - 1;
				while (num2 > l && comparer2.Compare(val, a[num2 - 1]) < 0)
				{
					a[num2] = a[num2 - 1];
					num2--;
				}
				a[num2] = val;
			}
		}
	}

	public static void InsertionSort<T>(T[] a, int l, int size, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = l + size;
		for (int i = l + 1; i < num; i++)
		{
			if (comparer2.Compare(a[i], a[i - 1]) < 0)
			{
				T val = a[i];
				a[i] = a[i - 1];
				int num2 = i - 1;
				while (num2 > l && comparer2.Compare(val, a[num2 - 1]) < 0)
				{
					a[num2] = a[num2 - 1];
					num2--;
				}
				a[num2] = val;
			}
		}
	}

	public static void InsertionSort<T1, T2>(T1[] a, T2[] b, int l, int size, IComparer<T1> comparer = null)
	{
		IComparer<T1> comparer2 = comparer ?? Comparer<T1>.Default;
		int num = l + size;
		for (int i = l + 1; i < num; i++)
		{
			if (comparer2.Compare(a[i], a[i - 1]) < 0)
			{
				T1 val = a[i];
				T2 val2 = b[i];
				a[i] = a[i - 1];
				b[i] = b[i - 1];
				int num2 = i - 1;
				while (num2 > l && comparer2.Compare(val, a[num2 - 1]) < 0)
				{
					a[num2] = a[num2 - 1];
					b[num2] = b[num2 - 1];
					num2--;
				}
				a[num2] = val;
				b[num2] = val2;
			}
		}
	}

	internal static void swap(int[] src, int i, int j)
	{
		int num = src[i];
		src[i] = src[j];
		src[j] = num;
	}

	private static void smethod_1(object object_0, int int_9, int int_10, int int_11)
	{
		int num = ((int[])object_0)[int_11 + int_9 - 1];
		while (int_9 <= int_10 / 2)
		{
			int num2 = 2 * int_9;
			if (num2 < int_10 && ((int[])object_0)[int_11 + num2 - 1] < ((int[])object_0)[int_11 + num2])
			{
				num2++;
			}
			if (num >= ((int[])object_0)[int_11 + num2 - 1])
			{
				break;
			}
			((int[])object_0)[int_11 + int_9 - 1] = ((int[])object_0)[int_11 + num2 - 1];
			int_9 = num2;
		}
		((int[])object_0)[int_11 + int_9 - 1] = num;
	}

	private static void smethod_2(object object_0, int int_9, int int_10, int int_11)
	{
		for (int num = int_11 / 2; num >= 1; num--)
		{
			smethod_1(object_0, num, int_11, int_9);
		}
	}

	public static void heapSort(int[] src, int begin, int end)
	{
		int num = end - begin;
		smethod_2(src, begin, end, num);
		for (int num2 = num; num2 >= 1; num2--)
		{
			swap(src, begin, begin + num2);
			smethod_1(src, 1, num2, begin);
		}
	}

	internal static void insertionSort(int[] src, int left, int right)
	{
		for (int i = left; i <= right; i++)
		{
			int num = src[i];
			int num2 = i;
			while (num2 > left && src[num2 - 1] > num)
			{
				src[num2] = src[num2 - 1];
				num2--;
			}
			src[num2] = num;
		}
	}

	internal static int findPivot(int[] src, int a1, int b1, int c1)
	{
		int num = Math.Max(Math.Max(src[a1], src[b1]), src[c1]);
		int num2 = Math.Min(Math.Min(src[a1], src[b1]), src[c1]);
		int num3 = num ^ num2 ^ src[a1] ^ src[b1] ^ src[c1];
		if (num3 == src[a1])
		{
			return a1;
		}
		if (num3 == src[b1])
		{
			return b1;
		}
		return c1;
	}

	internal static int partition(int[] src, int low, int high)
	{
		int num = src[high];
		int num2 = low - 1;
		for (int i = low; i <= high - 1; i++)
		{
			if (src[i] <= num)
			{
				num2++;
				swap(src, num2, i);
			}
		}
		swap(src, num2 + 1, high);
		return num2 + 1;
	}

	private static void smethod_3(int[] int_9, int int_10, int int_11, int int_12)
	{
		if (int_11 - int_10 > 16)
		{
			if (int_12 == 0)
			{
				heapSort(int_9, int_10, int_11);
				return;
			}
			int_12--;
			int i = findPivot(int_9, int_10, int_10 + (int_11 - int_10) / 2 + 1, int_11);
			swap(int_9, i, int_11);
			int num = partition(int_9, int_10, int_11);
			smethod_3(int_9, int_10, num - 1, int_12);
			smethod_3(int_9, num + 1, int_11, int_12);
		}
		else
		{
			insertionSort(int_9, int_10, int_11);
		}
	}

	public static void IntroSort(int[] src)
	{
		int int_ = (int)(2.0 * Math.Floor(Math.Log(src.Length) / Math.Log(2.0)));
		smethod_3(src, 0, src.Length - 1, int_);
	}

	internal static void swap(uint[] src, int i, int j)
	{
		uint num = src[i];
		src[i] = src[j];
		src[j] = num;
	}

	private static void smethod_4(object object_0, int int_9, int int_10, int int_11)
	{
		uint num = ((uint[])object_0)[int_11 + int_9 - 1];
		while (int_9 <= int_10 / 2)
		{
			int num2 = 2 * int_9;
			if (num2 < int_10 && ((uint[])object_0)[int_11 + num2 - 1] < ((uint[])object_0)[int_11 + num2])
			{
				num2++;
			}
			if (num >= ((uint[])object_0)[int_11 + num2 - 1])
			{
				break;
			}
			((int[])object_0)[int_11 + int_9 - 1] = (int)((uint[])object_0)[int_11 + num2 - 1];
			int_9 = num2;
		}
		((int[])object_0)[int_11 + int_9 - 1] = (int)num;
	}

	private static void smethod_5(object object_0, int int_9, int int_10, int int_11)
	{
		for (int num = int_11 / 2; num >= 1; num--)
		{
			smethod_4(object_0, num, int_11, int_9);
		}
	}

	public static void heapSort(uint[] src, int begin, int end)
	{
		int num = end - begin;
		smethod_5(src, begin, end, num);
		for (int num2 = num; num2 >= 1; num2--)
		{
			swap(src, begin, begin + num2);
			smethod_4(src, 1, num2, begin);
		}
	}

	internal static void insertionSort(uint[] src, int left, int right)
	{
		for (int i = left; i <= right; i++)
		{
			uint num = src[i];
			int num2 = i;
			while (num2 > left && src[num2 - 1] > num)
			{
				src[num2] = src[num2 - 1];
				num2--;
			}
			src[num2] = num;
		}
	}

	internal static int findPivot(uint[] src, int a1, int b1, int c1)
	{
		uint num = Math.Max(Math.Max(src[a1], src[b1]), src[c1]);
		uint num2 = Math.Min(Math.Min(src[a1], src[b1]), src[c1]);
		uint num3 = num ^ num2 ^ src[a1] ^ src[b1] ^ src[c1];
		if (num3 == src[a1])
		{
			return a1;
		}
		if (num3 == src[b1])
		{
			return b1;
		}
		return c1;
	}

	internal static int partition(uint[] src, int low, int high)
	{
		uint num = src[high];
		int num2 = low - 1;
		for (int i = low; i <= high - 1; i++)
		{
			if (src[i] <= num)
			{
				num2++;
				swap(src, num2, i);
			}
		}
		swap(src, num2 + 1, high);
		return num2 + 1;
	}

	internal static void IntroSortInner(uint[] src, int begin, int end, int depthLimit)
	{
		if (end - begin > 16)
		{
			if (depthLimit == 0)
			{
				heapSort(src, begin, end);
				return;
			}
			depthLimit--;
			int i = findPivot(src, begin, begin + (end - begin) / 2 + 1, end);
			swap(src, i, end);
			int num = partition(src, begin, end);
			IntroSortInner(src, begin, num - 1, depthLimit);
			IntroSortInner(src, num + 1, end, depthLimit);
		}
		else
		{
			insertionSort(src, begin, end);
		}
	}

	public static void IntroSort(uint[] src)
	{
		int depthLimit = (int)(2.0 * Math.Floor(Math.Log(src.Length) / Math.Log(2.0)));
		IntroSortInner(src, 0, src.Length - 1, depthLimit);
	}

	public static TSource MaxHpc<TSource>(this TSource[] a, int l, int r)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		if (l > r)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (l >= 0 && r < a.Length)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			TSource val = a[l];
			for (int i = l + 1; i <= r; i++)
			{
				if (comparer.Compare(val, a[i]) < 0)
				{
					val = a[i];
				}
			}
			return val;
		}
		throw new ArgumentOutOfRangeException();
	}

	public static TSource MaxHpc<TSource>(this TSource[] a)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		Comparer<TSource> comparer = Comparer<TSource>.Default;
		TSource val = a[0];
		for (int i = 1; i < a.Length; i++)
		{
			if (comparer.Compare(val, a[i]) < 0)
			{
				val = a[i];
			}
		}
		return val;
	}

	public static TSource MaxHpc<TSource>(this List<TSource> a, int l, int r)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		if (l >= 0 && r < a.Count)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			TSource val = a[l];
			for (int i = l + 1; i <= r; i++)
			{
				if (comparer.Compare(val, a[i]) < 0)
				{
					val = a[i];
				}
			}
			return val;
		}
		throw new ArgumentOutOfRangeException();
	}

	public static TSource MaxHpc<TSource>(this List<TSource> a)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		Comparer<TSource> comparer = Comparer<TSource>.Default;
		TSource val = a[0];
		for (int i = 1; i < a.Count; i++)
		{
			if (comparer.Compare(val, a[i]) < 0)
			{
				val = a[i];
			}
		}
		return val;
	}

	public static void Merge<T>(List<T> a, int aStart, int aLength, List<T> b, int bStart, int bLength, List<T> dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (comparer2.Compare(a[aStart], b[bStart]) > 0)
				{
					dst[dstStart++] = b[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = a[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = a[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = b[bStart++];
		}
	}

	public static void Merge<T>(List<T> src, int aStart, int aLength, int bStart, int bLength, List<T> dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) > 0)
				{
					dst[dstStart++] = src[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void Merge(int[] a, int aStart, int aLength, int[] b, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (a[aStart] <= b[bStart])
			{
				dst[dstStart++] = a[aStart++];
			}
			else
			{
				dst[dstStart++] = b[bStart++];
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = a[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = b[bStart++];
		}
	}

	public static void Merge(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (src[aStart] <= src[bStart])
			{
				dst[dstStart++] = src[aStart++];
			}
			else
			{
				dst[dstStart++] = src[bStart++];
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void MergeWithCopy(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (src[aStart] <= src[bStart])
			{
				dst[dstStart++] = src[aStart++];
			}
			else
			{
				dst[dstStart++] = src[bStart++];
			}
		}
		Copy(src, aStart, dst, dstStart, num - aStart + 1);
		Copy(src, bStart, dst, dstStart, num2 - bStart + 1);
	}

	public static void MergeFaster(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		if (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (src[aStart] <= src[bStart])
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void MergeFasterWithCopy(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		if (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (src[aStart] <= src[bStart])
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
			}
		}
		Copy(src, aStart, dst, dstStart, num - aStart + 1);
		Copy(src, bStart, dst, dstStart, num2 - bStart + 1);
	}

	public static void MergeBySpans(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aLength > 0 && bLength > 0)
		{
			int num3 = Math.Min(aLength, bLength);
			for (int i = 0; i < num3; i++)
			{
				if (src[aStart] > src[bStart])
				{
					dst[dstStart++] = src[bStart++];
				}
				else
				{
					dst[dstStart++] = src[aStart++];
				}
			}
			aLength = num - aStart + 1;
			bLength = num2 - bStart + 1;
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void Merge5(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart, int threshold = 1024)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (true)
		{
			int num3;
			int num4;
			if (aLength <= bLength)
			{
				if (aLength < threshold)
				{
					break;
				}
				num3 = aLength;
				num4 = 0;
			}
			else
			{
				if (bLength < threshold)
				{
					MergeFaster(src, aStart, aLength, bStart, bLength, dst, dstStart);
					return;
				}
				num3 = bLength;
				num4 = 0;
			}
			for (int i = num4; i < num3; i++)
			{
				if (src[aStart] > src[bStart])
				{
					dst[dstStart++] = src[bStart++];
				}
				else
				{
					dst[dstStart++] = src[aStart++];
				}
			}
			aLength = num - aStart + 1;
			bLength = num2 - bStart + 1;
		}
		MergeFaster(src, aStart, aLength, bStart, bLength, dst, dstStart);
	}

	public static void Merge6(int[] src, int aStart, int aLength, int bStart, int bLength, int[] dst, int dstStart, int threshold = 1024)
	{
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (true)
		{
			int num3;
			if (aLength > bLength)
			{
				if (bLength < threshold)
				{
					break;
				}
				num3 = bLength;
			}
			else
			{
				if (aLength < threshold)
				{
					MergeFaster(src, aStart, aLength, bStart, bLength, dst, dstStart);
					return;
				}
				num3 = aLength;
			}
			int num4 = dstStart + num3 - 1;
			while (dstStart <= num4)
			{
				if (src[aStart] > src[bStart])
				{
					dst[dstStart++] = src[bStart++];
				}
				else
				{
					dst[dstStart++] = src[aStart++];
				}
			}
			aLength = num - aStart + 1;
			bLength = num2 - bStart + 1;
		}
		MergeFaster(src, aStart, aLength, bStart, bLength, dst, dstStart);
	}

	public static void Merge<T>(T[] a, int aStart, int aLength, T[] b, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			dst[dstStart++] = ((comparer2.Compare(a[aStart], b[bStart]) <= 0) ? a[aStart++] : b[bStart++]);
		}
		if (aStart <= num)
		{
			Array.Copy(a, aStart, dst, dstStart, num - aStart + 1);
		}
		if (bStart <= num2)
		{
			Array.Copy(b, bStart, dst, dstStart, num2 - bStart + 1);
		}
	}

	public static void MergeWithCopy<T>(T[] a, int aStart, int aLength, T[] b, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (comparer2.Compare(a[aStart], b[bStart]) <= 0)
			{
				dst[dstStart++] = a[aStart++];
			}
			else
			{
				dst[dstStart++] = b[bStart++];
			}
		}
		if (aStart <= num)
		{
			Copy(a, aStart, dst, dstStart, num - aStart + 1);
		}
		if (bStart <= num2)
		{
			Copy(b, bStart, dst, dstStart, num2 - bStart + 1);
		}
	}

	public static void MergeFaster<T>(T[] a, int aStart, int aLength, T[] b, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (comparer2.Compare(a[aStart], b[bStart]) > 0)
				{
					dst[dstStart++] = b[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = a[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
			}
		}
		if (aStart <= num)
		{
			Array.Copy(a, aStart, dst, dstStart, num - aStart + 1);
		}
		if (bStart <= num2)
		{
			Array.Copy(b, bStart, dst, dstStart, num2 - bStart + 1);
		}
	}

	public static void Merge<T>(T[] a, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (comparer2.Compare(a[aStart], a[bStart]) <= 0)
			{
				dst[dstStart++] = a[aStart++];
			}
			else
			{
				dst[dstStart++] = a[bStart++];
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = a[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = a[bStart++];
		}
	}

	public static void MergeFaster<T>(T[] src, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			while (true)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) > 0)
				{
					dst[dstStart++] = src[bStart++];
					if (bStart > num2)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
			}
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void Merge<T1, T2>(T1[] aKeys, T2[] aItems, int aStart, int aLength, T1[] bKeys, T2[] bItems, int bStart, int bLength, T1[] dstKeys, T2[] dstItems, int dstStart, IComparer<T1> comparer = null)
	{
		IComparer<T1> comparer2 = comparer ?? Comparer<T1>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aStart <= num && bStart <= num2)
		{
			if (comparer2.Compare(aKeys[aStart], bKeys[bStart]) <= 0)
			{
				dstKeys[dstStart] = aKeys[aStart];
				dstItems[dstStart++] = aItems[aStart++];
			}
			else
			{
				dstKeys[dstStart] = bKeys[bStart];
				dstItems[dstStart++] = bItems[bStart++];
			}
		}
		while (aStart <= num)
		{
			dstKeys[dstStart] = aKeys[aStart];
			dstItems[dstStart++] = aItems[aStart++];
		}
		while (bStart <= num2)
		{
			dstKeys[dstStart] = bKeys[bStart];
			dstItems[dstStart++] = bItems[bStart++];
		}
	}

	public static void MergeBySpans<T>(T[] src, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aLength > 0 && bLength > 0)
		{
			int num3 = Math.Min(aLength, bLength);
			for (int i = 0; i < num3; i++)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) <= 0)
				{
					dst[dstStart++] = src[aStart++];
				}
				else
				{
					dst[dstStart++] = src[bStart++];
				}
			}
			aLength = num - aStart + 1;
			bLength = num2 - bStart + 1;
		}
		MergeFaster(src, aStart, aLength, bStart, bLength, dst, dstStart, comparer);
	}

	public static void MergeBySpans<T>(T[] src, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null, int threshold = 100)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		while (aLength > 0 && bLength > 0)
		{
			int num3 = Math.Min(aLength, bLength);
			if (num3 > threshold)
			{
				break;
			}
			for (int i = 0; i < num3; i++)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) <= 0)
				{
					dst[dstStart++] = src[aStart++];
				}
				else
				{
					dst[dstStart++] = src[bStart++];
				}
			}
			aLength = num - aStart + 1;
			bLength = num2 - bStart + 1;
		}
		while (aStart <= num)
		{
			dst[dstStart++] = src[aStart++];
		}
		while (bStart <= num2)
		{
			dst[dstStart++] = src[bStart++];
		}
	}

	public static void Merge<T>(T[] src, List<SortedSpan> srcSpans, T[] dst, IComparer<T> comparer = null)
	{
		if (dst.Length != src.Length)
		{
			throw new ArgumentException("Destination array must be the same size as the source array");
		}
		if (srcSpans == null || srcSpans.Count == 0)
		{
			return;
		}
		bool flag = true;
		while (true)
		{
			if (srcSpans.Count >= 1)
			{
				if (srcSpans.Count == 1)
				{
					break;
				}
				List<SortedSpan> list = new List<SortedSpan>();
				int num = 0;
				int num2 = srcSpans.Count / 2;
				for (int i = 0; i < num2; i++)
				{
					Merge(src, srcSpans[num].Start, srcSpans[num].Length, src, srcSpans[num + 1].Start, srcSpans[num + 1].Length, dst, srcSpans[num].Start, comparer);
					list.Add(new SortedSpan
					{
						Start = srcSpans[num].Start,
						Length = srcSpans[num].Length + srcSpans[num + 1].Length
					});
					num += 2;
				}
				if (num == srcSpans.Count - 1)
				{
					Array.Copy(src, srcSpans[num].Start, dst, srcSpans[num].Start, srcSpans[num].Length);
					list.Add(new SortedSpan
					{
						Start = srcSpans[num].Start,
						Length = srcSpans[num].Length
					});
				}
				srcSpans = list;
				T[] array = src;
				src = dst;
				dst = array;
				flag = !flag;
				continue;
			}
			return;
		}
		if (flag)
		{
			Array.Copy(src, srcSpans[0].Start, dst, srcSpans[0].Start, srcSpans[0].Length);
		}
	}

	public static void MergeMulti<T>(T[] src, List<SortedSpan> srcSpans, T[] dst, IComparer<T> comparer = null)
	{
		if (dst.Length != src.Length)
		{
			throw new ArgumentException("Destination array must be the same size as the source array");
		}
		if (srcSpans == null || srcSpans.Count == 0)
		{
			return;
		}
		bool flag = true;
		while (srcSpans.Count > 2)
		{
			List<SortedSpan> list = new List<SortedSpan>();
			int num = 0;
			int num2 = srcSpans.Count / 2;
			for (int i = 0; i < num2; i++)
			{
				Merge(src, srcSpans[num].Start, srcSpans[num].Length, src, srcSpans[num + 1].Start, srcSpans[num + 1].Length, dst, srcSpans[num].Start, comparer);
				list.Add(new SortedSpan
				{
					Start = srcSpans[num].Start,
					Length = srcSpans[num].Length + srcSpans[num + 1].Length
				});
				num += 2;
			}
			if (num == srcSpans.Count - 1)
			{
				Array.Copy(src, srcSpans[num].Start, dst, srcSpans[num].Start, srcSpans[num].Length);
				list.Add(new SortedSpan
				{
					Start = srcSpans[num].Start,
					Length = srcSpans[num].Length
				});
			}
			srcSpans = list;
			T[] array = src;
			src = dst;
			dst = array;
			flag = !flag;
		}
		if (srcSpans.Count != 2 && srcSpans.Count == 1)
		{
			Array.Copy(src, srcSpans[0].Start, dst, srcSpans[0].Start, srcSpans[0].Length);
		}
	}

	public static void MergeThreeWay<T>(T[] src, int aStart, int aLength, int bStart, int bLength, int cStart, int cLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		int num3 = cStart + cLength - 1;
		while (aStart <= num && bStart <= num2 && cStart <= num3)
		{
			if (comparer2.Compare(src[aStart], src[bStart]) <= 0)
			{
				dst[dstStart++] = ((comparer2.Compare(src[aStart], src[cStart]) <= 0) ? src[aStart++] : src[cStart++]);
			}
			else
			{
				dst[dstStart++] = ((comparer2.Compare(src[bStart], src[cStart]) <= 0) ? src[bStart++] : src[cStart++]);
			}
		}
		aLength = num - aStart + 1;
		bLength = num2 - bStart + 1;
		cLength = num3 - cStart + 1;
		if (aStart > num)
		{
			Merge(src, bStart, bLength, cStart, cLength, dst, dstStart, comparer2);
		}
		else if (bStart > num2)
		{
			Merge(src, aStart, aLength, cStart, cLength, dst, dstStart, comparer2);
		}
		else
		{
			Merge(src, aStart, aLength, bStart, bLength, dst, dstStart, comparer2);
		}
	}

	public static void MergeThreeWay2<T>(T[] src, int aStart, int aLength, int bStart, int bLength, int cStart, int cLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		int num3 = cStart + cLength - 1;
		while (aStart <= num && bStart <= num2 && cStart <= num3)
		{
			while (true)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) > 0)
				{
					if (comparer2.Compare(src[bStart], src[cStart]) <= 0)
					{
						dst[dstStart++] = src[bStart++];
						if (bStart > num2)
						{
							break;
						}
					}
					else
					{
						dst[dstStart++] = src[cStart++];
						if (cStart > num3)
						{
							break;
						}
					}
				}
				else if (comparer2.Compare(src[aStart], src[cStart]) <= 0)
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[cStart++];
					if (cStart > num3)
					{
						break;
					}
				}
			}
		}
		aLength = num - aStart + 1;
		bLength = num2 - bStart + 1;
		cLength = num3 - cStart + 1;
		if (aStart > num)
		{
			Merge(src, bStart, bLength, cStart, cLength, dst, dstStart, comparer2);
		}
		else if (bStart > num2)
		{
			Merge(src, aStart, aLength, cStart, cLength, dst, dstStart, comparer2);
		}
		else
		{
			Merge(src, aStart, aLength, bStart, bLength, dst, dstStart, comparer2);
		}
	}

	public static void MergeFourWay<T>(T[] src, int aStart, int aLength, int bStart, int bLength, int cStart, int cLength, int dStart, int dLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		int num3 = cStart + cLength - 1;
		int num4 = dStart + dLength - 1;
		while (aStart <= num && bStart <= num2 && cStart <= num3 && dStart <= num4)
		{
			if (comparer2.Compare(src[aStart], src[bStart]) <= 0)
			{
				if (comparer2.Compare(src[cStart], src[dStart]) <= 0)
				{
					dst[dstStart++] = ((comparer2.Compare(src[aStart], src[cStart]) <= 0) ? src[aStart++] : src[cStart++]);
				}
				else
				{
					dst[dstStart++] = ((comparer2.Compare(src[aStart], src[dStart]) <= 0) ? src[aStart++] : src[dStart++]);
				}
			}
			else if (comparer2.Compare(src[cStart], src[dStart]) <= 0)
			{
				dst[dstStart++] = ((comparer2.Compare(src[bStart], src[cStart]) <= 0) ? src[bStart++] : src[cStart++]);
			}
			else
			{
				dst[dstStart++] = ((comparer2.Compare(src[bStart], src[dStart]) <= 0) ? src[bStart++] : src[dStart++]);
			}
		}
		aLength = num - aStart + 1;
		bLength = num2 - bStart + 1;
		cLength = num3 - cStart + 1;
		dLength = num4 - dStart + 1;
		if (aStart > num)
		{
			MergeThreeWay(src, bStart, bLength, cStart, cLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else if (bStart > num2)
		{
			MergeThreeWay(src, aStart, aLength, cStart, cLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else if (cStart > num3)
		{
			MergeThreeWay(src, aStart, aLength, bStart, bLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else
		{
			MergeThreeWay(src, aStart, aLength, bStart, bLength, cStart, cLength, dst, dstStart, comparer2);
		}
	}

	public static void MergeFourWay2<T>(T[] src, int aStart, int aLength, int bStart, int bLength, int cStart, int cLength, int dStart, int dLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = aStart + aLength - 1;
		int num2 = bStart + bLength - 1;
		int num3 = cStart + cLength - 1;
		int num4 = dStart + dLength - 1;
		while (aStart <= num && bStart <= num2 && cStart <= num3 && dStart <= num4)
		{
			while (true)
			{
				if (comparer2.Compare(src[aStart], src[bStart]) > 0)
				{
					if (comparer2.Compare(src[cStart], src[dStart]) <= 0)
					{
						if (comparer2.Compare(src[bStart], src[cStart]) <= 0)
						{
							dst[dstStart++] = src[bStart++];
							if (bStart > num2)
							{
								break;
							}
						}
						else
						{
							dst[dstStart++] = src[cStart++];
							if (cStart > num3)
							{
								break;
							}
						}
					}
					else if (comparer2.Compare(src[bStart], src[dStart]) <= 0)
					{
						dst[dstStart++] = src[bStart++];
						if (bStart > num2)
						{
							break;
						}
					}
					else
					{
						dst[dstStart++] = src[dStart++];
						if (dStart > num4)
						{
							break;
						}
					}
				}
				else if (comparer2.Compare(src[cStart], src[dStart]) <= 0)
				{
					if (comparer2.Compare(src[aStart], src[cStart]) <= 0)
					{
						dst[dstStart++] = src[aStart++];
						if (aStart > num)
						{
							break;
						}
					}
					else
					{
						dst[dstStart++] = src[cStart++];
						if (cStart > num3)
						{
							break;
						}
					}
				}
				else if (comparer2.Compare(src[aStart], src[dStart]) <= 0)
				{
					dst[dstStart++] = src[aStart++];
					if (aStart > num)
					{
						break;
					}
				}
				else
				{
					dst[dstStart++] = src[dStart++];
					if (dStart > num4)
					{
						break;
					}
				}
			}
		}
		aLength = num - aStart + 1;
		bLength = num2 - bStart + 1;
		cLength = num3 - cStart + 1;
		dLength = num4 - dStart + 1;
		if (aStart > num)
		{
			MergeThreeWay2(src, bStart, bLength, cStart, cLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else if (bStart > num2)
		{
			MergeThreeWay2(src, aStart, aLength, cStart, cLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else if (cStart > num3)
		{
			MergeThreeWay2(src, aStart, aLength, bStart, bLength, dStart, dLength, dst, dstStart, comparer2);
		}
		else
		{
			MergeThreeWay2(src, aStart, aLength, bStart, bLength, cStart, cLength, dst, dstStart, comparer2);
		}
	}

	public static void MergeDivideAndConquer<T>(T[] src, int aStart, int aEnd, int bStart, int bEnd, T[] dst, int p3, IComparer<T> comparer = null)
	{
		int a = aEnd - aStart + 1;
		int b = bEnd - bStart + 1;
		if (a < b)
		{
			Swap(ref aStart, ref bStart);
			Swap(ref aEnd, ref bEnd);
			Swap(ref a, ref b);
		}
		if (a != 0)
		{
			if (a + b <= int_0)
			{
				Merge(src, aStart, a, src, bStart, b, dst, p3, comparer);
				return;
			}
			int num = aStart / 2 + aEnd / 2 + (aStart % 2 + aEnd % 2) / 2;
			int num2 = BinarySearch(src[num], src, bStart, bEnd, comparer);
			int num3 = p3 + (num - aStart) + (num2 - bStart);
			dst[num3] = src[num];
			MergeDivideAndConquer(src, aStart, num - 1, bStart, num2 - 1, dst, p3, comparer);
			MergeDivideAndConquer(src, num + 1, aEnd, num2, bEnd, dst, num3 + 1, comparer);
		}
	}

	public static void MergeInPlaceDivideAndConquer<T>(T[] arr, int startIndex, int midIndex, int endIndex, IComparer<T> comparer = null)
	{
		int num = midIndex - startIndex + 1;
		int num2 = endIndex - midIndex;
		if (num >= num2)
		{
			if (num2 > 0)
			{
				int num3 = startIndex / 2 + midIndex / 2 + (startIndex % 2 + midIndex % 2) / 2;
				int num4 = BinarySearch(arr[num3], arr, midIndex + 1, endIndex, comparer);
				int num5 = num3 + (num4 - midIndex - 1);
				if (num4 - num3 < 1024)
				{
					BlockSwapReversal(arr, num3, midIndex, num4 - 1);
				}
				else
				{
					BlockSwapGriesMills(arr, num3, midIndex, num4 - 1);
				}
				MergeInPlaceDivideAndConquer(arr, startIndex, num3 - 1, num5 - 1, comparer);
				MergeInPlaceDivideAndConquer(arr, num5 + 1, num4 - 1, endIndex, comparer);
			}
		}
		else if (num > 0)
		{
			int num6 = (midIndex + 1) / 2 + endIndex / 2 + ((midIndex + 1) % 2 + endIndex % 2) / 2;
			int num7 = BinarySearch(arr[num6], arr, startIndex, midIndex, comparer);
			int num8 = num7 + (num6 - midIndex - 1);
			if (num6 - num7 < 1024)
			{
				BlockSwapReversal(arr, num7, midIndex, num6);
			}
			else
			{
				BlockSwapGriesMills(arr, num7, midIndex, num6);
			}
			MergeInPlaceDivideAndConquer(arr, startIndex, num7 - 1, num8 - 1, comparer);
			MergeInPlaceDivideAndConquer(arr, num8 + 1, num6, endIndex, comparer);
		}
	}

	private static void dcJeQcEmOdm<T>(Array array_0, int int_9, int int_10, int int_11, Array array_1, IComparer<T> icomparer_0 = null)
	{
		int num = int_10 - int_9 + 1;
		int num2 = int_11 - int_10;
		if (num > 0 && num2 > 0)
		{
			if (num + num2 <= array_1.Length)
			{
				Merge((T[])array_0, int_9, num, (T[])array_0, int_10 + 1, num2, (T[])array_1, 0, icomparer_0);
				Array.Copy(array_1, array_0, num + num2);
			}
			else if (num >= num2)
			{
				int num3 = int_9 / 2 + int_10 / 2 + (int_9 % 2 + int_10 % 2) / 2;
				int num4 = BinarySearch(((T[])array_0)[num3], (T[])array_0, int_10 + 1, int_11, icomparer_0);
				int num5 = num3 + (num4 - int_10 - 1);
				BlockSwapReversal((T[])array_0, num3, int_10, num4 - 1);
				dcJeQcEmOdm(array_0, int_9, num3 - 1, num5 - 1, array_1, icomparer_0);
				dcJeQcEmOdm(array_0, num5 + 1, num4 - 1, int_11, array_1, icomparer_0);
			}
			else
			{
				int num6 = (int_10 + 1) / 2 + int_11 / 2 + ((int_10 + 1) % 2 + int_11 % 2) / 2;
				int num7 = BinarySearch(((T[])array_0)[num6], (T[])array_0, int_9, int_10, icomparer_0);
				int num8 = num7 + (num6 - int_10 - 1);
				BlockSwapReversal((T[])array_0, num7, int_10, num6);
				dcJeQcEmOdm(array_0, int_9, num7 - 1, num8 - 1, array_1, icomparer_0);
				dcJeQcEmOdm(array_0, num8 + 1, num6, int_11, array_1, icomparer_0);
			}
		}
	}

	public static void MergeInPlaceAdaptiveDivideAndConquer<T>(T[] arr, int startIndex, int midIndex, int endIndex, IComparer<T> comparer = null, int threshold = 16384)
	{
		if (endIndex - startIndex < threshold)
		{
			MergeInPlaceDivideAndConquer(arr, startIndex, midIndex, endIndex, comparer);
			return;
		}
		try
		{
			T[] array = new T[arr.Length];
			MergeDivideAndConquer(arr, startIndex, midIndex, midIndex + 1, endIndex, array, startIndex, comparer);
			Array.Copy(array, startIndex, arr, startIndex, endIndex - startIndex + 1);
		}
		catch (OutOfMemoryException)
		{
			MergeInPlaceDivideAndConquer(arr, startIndex, midIndex, endIndex, comparer);
		}
	}

	internal static void SortMergeInner<T>(this T[] src, int l, int r, T[] dst, bool srcToDst = true, IComparer<T> comparer = null, int threshold = 1024)
	{
		if (r < l)
		{
			return;
		}
		if (r == l)
		{
			if (srcToDst)
			{
				dst[l] = src[l];
			}
			return;
		}
		if (r - l < threshold)
		{
			Array.Sort(src, l, r - l + 1, comparer);
			if (srcToDst)
			{
				for (int i = l; i <= r; i++)
				{
					dst[i] = src[i];
				}
			}
			return;
		}
		int num = r / 2 + l / 2 + (r % 2 + l % 2) / 2;
		int aLength = num - l + 1;
		int bLength = r - (num + 1) + 1;
		SortMergeInner(src, l, num, dst, !srcToDst, comparer, threshold);
		SortMergeInner(src, num + 1, r, dst, !srcToDst, comparer, threshold);
		if (srcToDst)
		{
			Merge(src, l, aLength, num + 1, bLength, dst, l, comparer);
		}
		else
		{
			Merge(dst, l, aLength, num + 1, bLength, src, l, comparer);
		}
	}

	public static T[] SortMerge<T>(this T[] source, int startIndex, int length, IComparer<T> comparer = null, int threshold = 1024)
	{
		T[] array = new T[length];
		T[] array2 = new T[length];
		Array.Copy(source, startIndex, array, 0, length);
		SortMergeInner(array, 0, length - 1, array2, srcToDst: true, comparer, threshold);
		return array2;
	}

	public static T[] SortMerge<T>(this T[] source, IComparer<T> comparer = null, int threshold = 1024)
	{
		T[] array = new T[source.Length];
		SortMergeInner(source, 0, source.Length - 1, array, srcToDst: true, comparer, threshold);
		return array;
	}

	internal static void SortMergeFourWayInner<T>(this T[] src, int l, int r, T[] dst, bool srcToDst = true, IComparer<T> comparer = null)
	{
		if (r == l)
		{
			if (srcToDst)
			{
				dst[l] = src[l];
			}
			return;
		}
		if (r - l < int_1)
		{
			InsertionSort(src, l, r - l + 1, comparer);
			if (srcToDst)
			{
				for (int i = l; i <= r; i++)
				{
					dst[i] = src[i];
				}
			}
			return;
		}
		int num = l / 2 + r / 2 + (l % 2 + r % 2) / 2;
		int num2 = l / 2 + num / 2 + (l % 2 + num % 2) / 2;
		int num3 = num / 2 + r / 2 + (num % 2 + r % 2) / 2;
		int aLength = num2 - l + 1;
		int bLength = num - (num2 + 1) + 1;
		int cLength = num3 - (num + 1) + 1;
		int dLength = r - (num3 + 1) + 1;
		SortMergeFourWayInner(src, l, num2, dst, !srcToDst, comparer);
		SortMergeFourWayInner(src, num2 + 1, num, dst, !srcToDst, comparer);
		SortMergeFourWayInner(src, num + 1, num3, dst, !srcToDst, comparer);
		SortMergeFourWayInner(src, num3 + 1, r, dst, !srcToDst, comparer);
		if (srcToDst)
		{
			MergeFourWay2(src, l, aLength, num2 + 1, bLength, num + 1, cLength, num3 + 1, dLength, dst, l, comparer);
		}
		else
		{
			MergeFourWay2(dst, l, aLength, num2 + 1, bLength, num + 1, cLength, num3 + 1, dLength, src, l, comparer);
		}
	}

	public static T[] SortMergeFourWay<T>(this T[] source, IComparer<T> comparer = null)
	{
		T[] array = new T[source.Length];
		SortMergeFourWayInner(source, 0, source.Length - 1, array, srcToDst: true, comparer);
		return array;
	}

	private static void smethod_6<T>(object object_0, int int_9, int int_10, IComparer<T> icomparer_0 = null, int int_11 = 16384)
	{
		int num = int_10 - int_9 + 1;
		if (num > 1)
		{
			if (num <= int_11)
			{
				Array.Sort((T[])object_0, int_9, num, icomparer_0);
				return;
			}
			int num2 = int_10 / 2 + int_9 / 2 + (int_10 % 2 + int_9 % 2) / 2;
			smethod_6(object_0, int_9, num2, icomparer_0, int_11);
			smethod_6(object_0, num2 + 1, int_10, icomparer_0, int_11);
			MergeInPlaceDivideAndConquer((T[])object_0, int_9, num2, int_10, icomparer_0);
		}
	}

	private static void smethod_7<T>(this object object_0, int int_9, int int_10, IComparer<T> icomparer_0 = null, int int_11 = 16384)
	{
		if (int_10 <= int_9)
		{
			return;
		}
		int num = int_10 - int_9 + 1;
		if (num > 1)
		{
			if (num <= int_11)
			{
				Array.Sort((T[])object_0, int_9, num, icomparer_0);
				return;
			}
			int num2 = int_10 / 2 + int_9 / 2 + (int_10 % 2 + int_9 % 2) / 2;
			object_0.smethod_7(int_9, num2, icomparer_0);
			object_0.smethod_7(num2 + 1, int_10, icomparer_0);
			MergeInPlaceAdaptiveDivideAndConquer((T[])object_0, int_9, num2, int_10, icomparer_0);
		}
	}

	public static void SortMergeInPlaceUsingAdaptiveMerge<T>(this T[] arr, IComparer<T> comparer = null)
	{
		arr.smethod_7(0, arr.Length - 1, comparer);
	}

	public static void SortMergeInPlaceAdaptive<T>(this T[] arr, IComparer<T> comparer = null, int thresholdInPlacePure = 16384)
	{
		try
		{
			T[] dst = new T[arr.Length];
			SortMergeInner(arr, 0, arr.Length - 1, dst, srcToDst: false, comparer);
		}
		catch (OutOfMemoryException)
		{
			smethod_6(arr, 0, arr.Length - 1, comparer, thresholdInPlacePure);
		}
	}

	public static void SortMergeInPlaceAdaptive<T>(this T[] array, int startIndex, int length, IComparer<T> comparer = null, int thresholdInPlacePure = 16384)
	{
		try
		{
			T[] dst = new T[array.Length];
			SortMergeInner(array, startIndex, startIndex + length - 1, dst, srcToDst: false, comparer);
		}
		catch (OutOfMemoryException)
		{
			smethod_6(array, startIndex, startIndex + length - 1, comparer, thresholdInPlacePure);
		}
	}

	public static void SortMergeInPlace<T>(this T[] array, IComparer<T> comparer = null, int threshold = 16384)
	{
		smethod_6(array, 0, array.Length - 1, comparer, threshold);
	}

	public static void SortMergeInPlace<T>(this T[] array, int startIndex, int length, IComparer<T> comparer = null, int threshold = 16384)
	{
		smethod_6(array, startIndex, startIndex + length - 1, comparer, threshold);
	}

	public static List<T> SortMerge<T>(this List<T> src, int startIndex, int length, IComparer<T> comparer = null)
	{
		T[] array = HPCsharp.ParallelAlgorithms.Copy.ToArrayPar(src, startIndex, length);
		T[] array2 = new T[array.Length];
		SortMergeInner(array, 0, length - 1, array2, srcToDst: true, comparer);
		return new List<T>(array2);
	}

	public static List<T> SortMerge<T>(this List<T> src, IComparer<T> comparer = null)
	{
		T[] array = HPCsharp.ParallelAlgorithms.Copy.ToArrayPar(src);
		SortMerge(array, comparer);
		return new List<T>(array);
	}

	private static void smethod_8<T>(ref List<T> list_0, int int_9, int int_10, IComparer<T> icomparer_0 = null)
	{
	}

	private static void smethod_9<T>(ref List<T> list_0, IComparer<T> icomparer_0 = null)
	{
		T[] array = HPCsharp.ParallelAlgorithms.Copy.ToArrayPar(list_0);
		SortMergeInPlace(array, icomparer_0);
		list_0 = new List<T>(array);
	}

	private static void smethod_10<T>(object object_0, IComparer<T> icomparer_0 = null)
	{
		smethod_11(object_0, 0, ((Array)object_0).Length, icomparer_0);
	}

	private static void smethod_11<T>(object object_0, int int_9, int int_10, IComparer<T> icomparer_0 = null)
	{
		if (int_10 > 1)
		{
			int num = int_9 + int_10;
			int num2 = num / 2 + int_9 / 2 + (num % 2 + int_9 % 2) / 2;
			smethod_11(object_0, int_9, num2, icomparer_0);
			smethod_11(object_0, num2 + 1, num, icomparer_0);
			MergeInPlaceDivideAndConquer((T[])object_0, int_9, num2, num, icomparer_0);
		}
	}

	private static void smethod_12<T>(Array array_0, IComparer<T> icomparer_0 = null, int int_9 = 1024, int int_10 = 32)
	{
		T[] array_1 = new T[int_9];
		smethod_14(array_0, 0, array_0.Length - 1, array_1, icomparer_0, int_10);
	}

	private static void smethod_13<T>(Array array_0, int int_9, int int_10, IComparer<T> icomparer_0 = null, int int_11 = 1024, int int_12 = 32)
	{
		T[] array_1 = new T[int_11];
		smethod_14(array_0, int_9, int_10 - 1, array_1, icomparer_0, int_12);
	}

	private static void smethod_14<T>(Array array_0, int int_9, int int_10, Array array_1, IComparer<T> icomparer_0 = null, int int_11 = 32)
	{
		int num = int_10 - int_9 + 1;
		if (num > 1)
		{
			if (num <= int_11)
			{
				InsertionSort((T[])array_0, int_9, num, icomparer_0);
				return;
			}
			int num2 = int_10 / 2 + int_9 / 2 + (int_10 % 2 + int_9 % 2) / 2;
			smethod_14(array_0, int_9, num2, array_1, icomparer_0, int_11);
			smethod_14(array_0, num2 + 1, int_10, array_1, icomparer_0, int_11);
			dcJeQcEmOdm(array_0, int_9, num2, int_10, array_1, icomparer_0);
		}
	}

	public static TSource MinHpc<TSource>(this TSource[] a, int l, int r)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		if (l > r)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (l >= 0 && r < a.Length)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			TSource val = a[l];
			for (int i = l + 1; i <= r; i++)
			{
				if (comparer.Compare(val, a[i]) > 0)
				{
					val = a[i];
				}
			}
			return val;
		}
		throw new ArgumentOutOfRangeException();
	}

	public static TSource MinHpc<TSource>(this TSource[] a)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		Comparer<TSource> comparer = Comparer<TSource>.Default;
		TSource val = a[0];
		for (int i = 1; i < a.Length; i++)
		{
			if (comparer.Compare(val, a[i]) > 0)
			{
				val = a[i];
			}
		}
		return val;
	}

	public static TSource MinHpc<TSource>(this List<TSource> a, int l, int r)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		if (l >= 0 && r < a.Count)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			TSource val = a[l];
			for (int i = l + 1; i <= r; i++)
			{
				if (comparer.Compare(val, a[i]) > 0)
				{
					val = a[i];
				}
			}
			return val;
		}
		throw new ArgumentOutOfRangeException();
	}

	public static TSource MinHpc<TSource>(this List<TSource> a)
	{
		if (a == null)
		{
			throw new ArgumentNullException();
		}
		Comparer<TSource> comparer = Comparer<TSource>.Default;
		TSource val = a[0];
		for (int i = 1; i < a.Count; i++)
		{
			if (comparer.Compare(val, a[i]) > 0)
			{
				val = a[i];
			}
		}
		return val;
	}

	public static void Quicksort<T>(this T[] src, int b, int e, IComparer<T> comparer = null)
	{
		if (b >= e)
		{
			return;
		}
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		T val = src[b];
		int i = b;
		int num = e - 1;
		T val2;
		while (i != num)
		{
			while (i != num && comparer2.Compare(val, src[num]) < 0)
			{
				num--;
			}
			for (; i != num && comparer2.Compare(src[i], val) <= 0; i++)
			{
			}
			val2 = src[i];
			src[i] = src[num];
			src[num] = val2;
		}
		val2 = src[i];
		src[i] = src[b];
		src[b] = val2;
		Quicksort(src, b, i, comparer);
		Quicksort(src, i + 1, e, comparer);
	}

	public static void Quicksort(this uint[] src, int b, int e)
	{
		if (b >= e)
		{
			return;
		}
		uint num = src[b];
		int i = b;
		int num2 = e - 1;
		uint num3;
		while (i != num2)
		{
			while (i != num2 && num < src[num2])
			{
				num2--;
			}
			for (; i != num2 && src[i] <= num; i++)
			{
			}
			num3 = src[i];
			src[i] = src[num2];
			src[num2] = num3;
		}
		num3 = src[i];
		src[i] = src[b];
		src[b] = num3;
		Quicksort(src, b, i);
		Quicksort(src, i + 1, e);
	}

	public static void QuicksortHoare(this uint[] src, int b, int e)
	{
		if (e - b < 2)
		{
			return;
		}
		int num = b;
		int num2 = e - 1;
		uint num3 = src[num + (num2 - num) / 2];
		if (src[num] < num3)
		{
			while (src[++num] < num3)
			{
			}
		}
		if (src[num2] > num3)
		{
			while (src[--num2] > num3)
			{
			}
		}
		while (num < num2)
		{
			uint num4 = src[num];
			src[num] = src[num2];
			src[num2] = num4;
			while (src[++num] < num3)
			{
			}
			while (src[--num2] > num3)
			{
			}
		}
		num2++;
		QuicksortHoare(src, b, num2);
		QuicksortHoare(src, num2, e);
	}

	public static void QuicksortHoare<T>(this T[] src, int b, int e, IComparer<T> comparer = null)
	{
		if (e - b < 2)
		{
			return;
		}
		IComparer<T> comparer2 = comparer ?? Comparer<T>.Default;
		int num = b;
		int num2 = e - 1;
		T y = src[num + (num2 - num) / 2];
		if (comparer2.Compare(src[num], y) < 0)
		{
			while (comparer2.Compare(src[++num], y) < 0)
			{
			}
		}
		if (comparer2.Compare(src[num2], y) > 0)
		{
			while (comparer2.Compare(src[--num2], y) > 0)
			{
			}
		}
		while (num < num2)
		{
			T val = src[num];
			src[num] = src[num2];
			src[num2] = val;
			while (comparer2.Compare(src[++num], y) < 0)
			{
			}
			while (comparer2.Compare(src[--num2], y) > 0)
			{
			}
		}
		num2++;
		QuicksortHoare(src, b, num2, comparer);
		QuicksortHoare(src, num2, e, comparer);
	}

	public static void QuicksortThreeWayPartition(this uint[] src, int l, int r)
	{
		uint num = src[r];
		if (r <= l)
		{
			return;
		}
		int num2 = l - 1;
		int num3 = r;
		int num4 = l - 1;
		int num5 = r;
		uint num6;
		while (true)
		{
			if (src[++num2] >= num)
			{
				while (num < src[--num3] && num3 != l)
				{
				}
				if (num2 >= num3)
				{
					break;
				}
				num6 = src[num2];
				src[num2] = src[num3];
				src[num3] = num6;
				if (src[num2] == num)
				{
					num4++;
					num6 = src[num2];
					src[num2] = src[num4];
					src[num4] = num6;
				}
				if (num == src[num3])
				{
					num5--;
					num6 = src[num5];
					src[num5] = src[num3];
					src[num3] = num6;
				}
			}
		}
		num6 = src[r];
		src[r] = src[num2];
		src[num2] = num6;
		num3 = num2 - 1;
		num2++;
		int num7 = l;
		while (num7 <= num4)
		{
			num6 = src[num7];
			src[num7] = src[num3];
			src[num3] = num6;
			num7++;
			num3--;
		}
		num7 = r - 1;
		while (num7 >= num5)
		{
			num6 = src[num7];
			src[num7] = src[num2];
			src[num2] = num6;
			num7--;
			num2++;
		}
		QuicksortThreeWayPartition(src, l, num3);
		QuicksortThreeWayPartition(src, num2, r);
	}

	private static uint[] smethod_15(this uint[] uint_0)
	{
		int num = 256;
		int num2 = 8;
		uint[] array = new uint[uint_0.Length];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array2[num5] = 0u;
			}
			for (uint num6 = 0u; num6 < uint_0.Length; num6++)
			{
				array2[smethod_21(uint_0[num6], num3, num4)]++;
			}
			array3[0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array3[num7] = array3[num7 - 1] + array2[num7 - 1];
			}
			for (uint num8 = 0u; num8 < uint_0.Length; num8++)
			{
				array[array3[smethod_21(uint_0[num8], num3, num4)]++] = uint_0[num8];
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			uint[] array4 = uint_0;
			uint_0 = array;
			array = array4;
		}
		if (flag)
		{
			for (uint num9 = 0u; num9 < uint_0.Length; num9++)
			{
				uint_0[num9] = array[num9];
			}
		}
		return uint_0;
	}

	private static void smethod_16(uint uint_0, object object_0)
	{
		((int[])object_0)[0] = (int)(uint_0 & 0xFF);
		((int[])object_0)[1] = (int)((uint_0 & 0xFF00) >> 8);
		((int[])object_0)[2] = (int)((uint_0 & 0xFF0000) >> 16);
		((int[])object_0)[3] = (int)((uint_0 & 0xFF000000u) >> 24);
	}

	private static uint[] smethod_17(this uint[] uint_0)
	{
		int num = 256;
		int num2 = 4;
		int num3 = 8;
		int num4 = 0;
		uint[] array = new uint[uint_0.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		uint[][] array3 = new uint[num2][];
		for (int j = 0; j < num2; j++)
		{
			array3[j] = new uint[num];
		}
		bool flag = false;
		uint num5 = 255u;
		int num6 = 0;
		byte[] array4 = new byte[4];
		for (uint num7 = 0u; num7 < uint_0.Length; num7++)
		{
			uint num8 = uint_0[num7];
			array4[0] = (byte)(num8 & 0xFF);
			array4[1] = (byte)((num8 & 0xFF00) >> 8);
			array4[2] = (byte)((num8 & 0xFF0000) >> 16);
			array4[3] = (byte)((num8 & 0xFF000000u) >> 24);
			int num9 = 0;
			byte[] array5 = array4;
			foreach (byte b in array5)
			{
				array2[num9][b]++;
				num9++;
			}
		}
		for (num4 = 0; num4 < num2; num4++)
		{
			array3[num4][0] = 0u;
			for (uint num10 = 1u; num10 < num; num10++)
			{
				array3[num4][num10] = array3[num4][num10 - 1] + array2[num4][num10 - 1];
			}
		}
		num4 = 0;
		while (num5 != 0)
		{
			uint[] array6 = array3[num4];
			for (uint num11 = 0u; num11 < uint_0.Length; num11++)
			{
				array[array6[(uint_0[num11] & num5) >> num6]++] = uint_0[num11];
			}
			num5 <<= num3;
			num6 += num3;
			flag = !flag;
			num4++;
			uint[] array7 = uint_0;
			uint_0 = array;
			array = array7;
		}
		if (flag)
		{
			for (uint num12 = 0u; num12 < uint_0.Length; num12++)
			{
				uint_0[num12] = array[num12];
			}
		}
		return uint_0;
	}

	public static byte[] SortRadix(this byte[] arrayToBeSorted)
	{
		return SortCountingInPlaceFunc(arrayToBeSorted);
	}

	public static sbyte[] SortRadix(this sbyte[] arrayToBeSorted)
	{
		return SortCountingInPlaceFunc(arrayToBeSorted);
	}

	public static ushort[] SortRadix(this ushort[] arrayToBeSorted)
	{
		return SortCountingInPlaceFunc(arrayToBeSorted);
	}

	public static short[] SortRadix(this short[] arrayToBeSorted)
	{
		return SortCountingInPlaceFunc(arrayToBeSorted);
	}

	public static uint[] SortRadix(this uint[] inputArray)
	{
		uint num = 256u;
		uint num2 = 4u;
		int num3 = 0;
		uint[] array = new uint[inputArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		bool flag = false;
		uint num4 = num - 1;
		int num5 = 0;
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		for (num3 = 0; num3 < num2; num3++)
		{
			array2[num3][0] = 0u;
			for (uint num6 = 1u; num6 < num; num6++)
			{
				array2[num3][num6] = array2[num3][num6 - 1] + array3[num3][num6 - 1];
			}
		}
		num3 = 0;
		while (num4 != 0)
		{
			uint[] array4 = array2[num3];
			for (uint num7 = 0u; num7 < inputArray.Length; num7++)
			{
				array[array4[(inputArray[num7] & num4) >> num5]++] = inputArray[num7];
			}
			num4 <<= 8;
			num5 += 8;
			flag = !flag;
			num3++;
			uint[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static void SortRadix(this uint[] inOutArray, int startIndex, int length)
	{
		uint num = 256u;
		uint num2 = 4u;
		uint[] array = new uint[inOutArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		bool flag = false;
		uint num3 = num - 1;
		int num4 = 0;
		uint[][] array3 = HistogramByteComponents(inOutArray, startIndex, startIndex + length - 1);
		int j;
		for (j = 0; j < num2; j++)
		{
			array2[j][0] = (uint)startIndex;
			for (uint num5 = 1u; num5 < num; num5++)
			{
				array2[j][num5] = array2[j][num5 - 1] + array3[j][num5 - 1];
			}
		}
		j = 0;
		while (num3 != 0)
		{
			uint[] array4 = array2[j];
			for (int k = startIndex; k < startIndex + length; k++)
			{
				array[array4[(inOutArray[k] & num3) >> num4]++] = inOutArray[k];
			}
			num3 <<= 8;
			num4 += 8;
			flag = !flag;
			j++;
			uint[] array5 = inOutArray;
			inOutArray = array;
			array = array5;
		}
	}

	public static void SortRadixInPlaceInterface(this uint[] inputArray)
	{
		SortRadix(inputArray, 0, inputArray.Length);
	}

	public static ulong[] SortRadix(this ulong[] inputArray)
	{
		uint num = 256u;
		uint num2 = 8u;
		int num3 = 0;
		ulong[] array = new ulong[inputArray.Length];
		uint[][] array2 = new uint[8][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		bool flag = false;
		ulong num4 = num - 1;
		int num5 = 0;
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		for (num3 = 0; num3 < num2; num3++)
		{
			array2[num3][0] = 0u;
			for (uint num6 = 1u; num6 < num; num6++)
			{
				array2[num3][num6] = array2[num3][num6 - 1] + array3[num3][num6 - 1];
			}
		}
		num3 = 0;
		while (num4 != 0L)
		{
			uint[] array4 = array2[num3];
			for (uint num7 = 0u; num7 < inputArray.Length; num7++)
			{
				array[array4[(inputArray[num7] & num4) >> num5]++] = inputArray[num7];
			}
			num4 <<= 8;
			num5 += 8;
			flag = !flag;
			num3++;
			ulong[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static void SortRadixInPlaceInterface(this ulong[] inputArray)
	{
		Array.Copy(SortRadix(inputArray), inputArray, inputArray.Length);
	}

	private static void smethod_18(object object_0, object object_1, object object_2, int int_9)
	{
		int num = int_9 / 8;
		Int64ByteUnion int64ByteUnion = default(Int64ByteUnion);
		switch (num)
		{
		case 0:
		{
			for (uint num9 = 0u; num9 < ((Array)object_0).Length; num9++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num9];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte0]++] = ((long[])object_0)[num9];
			}
			break;
		}
		case 1:
		{
			for (uint num5 = 0u; num5 < ((Array)object_0).Length; num5++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num5];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte1]++] = ((long[])object_0)[num5];
			}
			break;
		}
		case 2:
		{
			for (uint num7 = 0u; num7 < ((Array)object_0).Length; num7++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num7];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte2]++] = ((long[])object_0)[num7];
			}
			break;
		}
		case 3:
		{
			for (uint num3 = 0u; num3 < ((Array)object_0).Length; num3++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num3];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte3]++] = ((long[])object_0)[num3];
			}
			break;
		}
		case 4:
		{
			for (uint num8 = 0u; num8 < ((Array)object_0).Length; num8++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num8];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte4]++] = ((long[])object_0)[num8];
			}
			break;
		}
		case 5:
		{
			for (uint num6 = 0u; num6 < ((Array)object_0).Length; num6++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num6];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte5]++] = ((long[])object_0)[num6];
			}
			break;
		}
		case 6:
		{
			for (uint num4 = 0u; num4 < ((Array)object_0).Length; num4++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num4];
				((long[])object_1)[((uint[])object_2)[int64ByteUnion.byte6]++] = ((long[])object_0)[num4];
			}
			break;
		}
		case 7:
		{
			for (uint num2 = 0u; num2 < ((Array)object_0).Length; num2++)
			{
				int64ByteUnion.integer = ((long[])object_0)[num2];
				((long[])object_1)[((uint[])object_2)[(((long[])object_0)[num2] >>> int_9) ^ 0x80L]++] = ((long[])object_0)[num2];
			}
			break;
		}
		}
	}

	public static int[] SortRadix2(this int[] inputArray, bool ascending = true)
	{
		int[] array = SortRadix(inputArray);
		Reversal(array, 0, array.Length - 1);
		return array;
	}

	public static int[] SortRadix(this int[] inputArray)
	{
		uint num = 4u;
		int[] array = new int[inputArray.Length];
		int[][] array2 = new int[4][];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new int[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		int j;
		for (j = 0; j < num; j++)
		{
			array2[j][0] = 0;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[j][num3] = array2[j][num3 - 1] + (int)array3[j][num3 - 1];
			}
		}
		j = 0;
		while (j < num)
		{
			int[] array4 = array2[j];
			if (j != 3)
			{
				for (uint num4 = 0u; num4 < inputArray.Length; num4++)
				{
					array[array4[(inputArray[num4] >>> num2) & 0xFF]++] = inputArray[num4];
				}
			}
			else
			{
				for (uint num5 = 0u; num5 < inputArray.Length; num5++)
				{
					array[array4[(inputArray[num5] >>> num2) ^ 0x80]++] = inputArray[num5];
				}
			}
			num2 += 8;
			flag = !flag;
			j++;
			int[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (flag)
		{
			return array;
		}
		return inputArray;
	}

	public static long[] SortRadix(this long[] inputArray)
	{
		uint num = 8u;
		long[] array = new long[inputArray.Length];
		int[][] array2 = new int[8][];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new int[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		int j;
		for (j = 0; j < num; j++)
		{
			array2[j][0] = 0;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[j][num3] = array2[j][num3 - 1] + (int)array3[j][num3 - 1];
			}
		}
		j = 0;
		while (j < num)
		{
			int[] array4 = array2[j];
			if (j != 7)
			{
				for (uint num4 = 0u; num4 < inputArray.Length; num4++)
				{
					array[array4[(inputArray[num4] >>> num2) & 0xFFL]++] = inputArray[num4];
				}
			}
			else
			{
				for (uint num5 = 0u; num5 < inputArray.Length; num5++)
				{
					array[array4[(inputArray[num5] >>> num2) ^ 0x80L]++] = inputArray[num5];
				}
			}
			num2 += 8;
			flag = !flag;
			j++;
			long[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (flag)
		{
			return array;
		}
		return inputArray;
	}

	public static long[] SortRadixWithPresortedDetection(this long[] inputArray, double fractionPresorted)
	{
		uint num = 8u;
		int num2 = 0;
		long[] array = new long[inputArray.Length];
		int[][] array2 = new int[8][];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new int[256];
		}
		bool flag = false;
		int num3 = 0;
		Tuple<uint[][], int> tuple = HistogramByteComponentsAndStatistics(inputArray, 0, inputArray.Length - 1);
		uint[][] item = tuple.Item1;
		if (tuple.Item2 == inputArray.Length)
		{
			return inputArray;
		}
		if (!((double)tuple.Item2 / (double)inputArray.Length >= fractionPresorted) && fractionPresorted != 1.0)
		{
			for (num2 = 0; num2 < num; num2++)
			{
				array2[num2][0] = 0;
				for (uint num4 = 1u; num4 < 256; num4++)
				{
					array2[num2][num4] = array2[num2][num4 - 1] + (int)item[num2][num4 - 1];
				}
			}
			int[] array3 = new int[num];
			for (num2 = 0; num2 < num; num2++)
			{
				for (int j = 0; j < 256L; j++)
				{
					if (item[num2][j] != 0)
					{
						array3[num2]++;
					}
				}
			}
			for (num2 = 0; num2 < num; num2++)
			{
				if (array3[num2] > 1 || num2 == 7)
				{
					int[] array4 = array2[num2];
					if (num2 != 7)
					{
						for (uint num5 = 0u; num5 < inputArray.Length; num5++)
						{
							array[array4[(inputArray[num5] >>> num3) & 0xFFL]++] = inputArray[num5];
						}
					}
					else
					{
						for (uint num6 = 0u; num6 < inputArray.Length; num6++)
						{
							array[array4[(inputArray[num6] >>> num3) ^ 0x80L]++] = inputArray[num6];
						}
					}
					flag = !flag;
					long[] array5 = inputArray;
					inputArray = array;
					array = array5;
				}
				num3 += 8;
			}
			if (flag)
			{
				return array;
			}
			return inputArray;
		}
		Array.Sort(inputArray);
		return inputArray;
	}

	public static long[] SortRadix3(this long[] inputArray)
	{
		uint num = 8u;
		int num2 = 0;
		long[] array = new long[inputArray.Length];
		int[][] array2 = new int[8][];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new int[256];
		}
		bool flag = false;
		int num3 = 0;
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		for (num2 = 0; num2 < num; num2++)
		{
			array2[num2][0] = 0;
			for (uint num4 = 1u; num4 < 256; num4++)
			{
				array2[num2][num4] = array2[num2][num4 - 1] + (int)array3[num2][num4 - 1];
			}
		}
		long[] array4 = new long[16384];
		int[] array5 = new int[256];
		for (int j = 0; j < 256; j++)
		{
			array5[j] = j * 64;
		}
		num2 = 0;
		while (num2 < num)
		{
			int[] array6 = array2[num2];
			if (num2 != 7)
			{
				for (uint num5 = 0u; num5 < inputArray.Length; num5++)
				{
					byte b = (byte)(inputArray[num5] >> num3);
					if (array5[b] >= (b + 1) * 64)
					{
						int num6 = array6[b];
						int num7 = b * 64;
						int num8 = num7 + 64;
						while (num7 < num8)
						{
							array[num6++] = array4[num7++];
						}
						array6[b] += 64;
						array5[b] = b * 64;
						array4[array5[b]++] = inputArray[num5];
					}
					else
					{
						array4[array5[b]++] = inputArray[num5];
					}
				}
				for (int k = 0; k < 256; k++)
				{
					byte b2 = (byte)k;
					int num9 = array6[b2];
					int num10 = b2 * 64;
					int num11 = array5[b2];
					while (num10 < num11)
					{
						array[num9++] = array4[num10++];
						array6[b2]++;
					}
					array5[b2] = b2 * 64;
				}
			}
			else
			{
				for (uint num12 = 0u; num12 < inputArray.Length; num12++)
				{
					array[array6[(inputArray[num12] >>> num3) ^ 0x80L]++] = inputArray[num12];
				}
			}
			num3 += 8;
			flag = !flag;
			num2++;
			long[] array7 = inputArray;
			inputArray = array;
			array = array7;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static void SortRadixInPlaceInterface(this long[] inputArray)
	{
		long[] array = SortRadix(inputArray);
		if (array != inputArray)
		{
			Array.Copy(array, inputArray, inputArray.Length);
		}
	}

	private static uint[] smethod_19(this uint[] uint_0)
	{
		int num = 0;
		uint[] array = new uint[uint_0.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponents(uint_0, 0, uint_0.Length - 1);
		for (num = 0; num < 4L; num++)
		{
			array2[num][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[num][num3] = array2[num][num3 - 1] + array3[num][num3 - 1];
			}
		}
		for (num = 0; num < 4L; num++)
		{
			uint[] array4 = array2[num];
			for (uint num4 = 0u; num4 < uint_0.Length; num4++)
			{
				array[array4[(byte)(uint_0[num4] >> num2)]++] = uint_0[num4];
			}
			num2 += 8;
			flag = !flag;
			uint[] array5 = uint_0;
			uint_0 = array;
			array = array5;
		}
		if (!flag)
		{
			return uint_0;
		}
		return array;
	}

	private static uint[] smethod_20(this uint[] uint_0)
	{
		int num = 0;
		uint[] array = new uint[uint_0.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		uint num2 = 255u;
		int num3 = 0;
		uint[][] array3 = HistogramByteComponents(uint_0, 0, uint_0.Length - 1);
		for (num = 0; num < 4L; num++)
		{
			array2[num][0] = 0u;
			for (uint num4 = 1u; num4 < 256; num4++)
			{
				array2[num][num4] = array2[num][num4 - 1] + array3[num][num4 - 1];
			}
		}
		num = 0;
		while (num2 != 0)
		{
			uint[] array4 = array2[num];
			for (uint num5 = 0u; num5 < uint_0.Length; num5++)
			{
				array[array4[(uint_0[num5] & num2) >> num3]++] = uint_0[num5];
			}
			num2 <<= 8;
			num3 += 8;
			flag = !flag;
			num++;
			uint[] array5 = uint_0;
			uint_0 = array;
			array = array5;
		}
		if (!flag)
		{
			return uint_0;
		}
		return array;
	}

	public static List<uint> SortRadix(this List<uint> inputArray)
	{
		return new List<uint>(SortRadix(inputArray.ToArray()));
	}

	public static uint[] SortRadixDerandomizedWrites(this uint[] inputArray)
	{
		int num = 256;
		int num2 = 8;
		uint num3 = 64u;
		uint[] array = new uint[16384L];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[inputArray.Length];
		uint[] array4 = new uint[256];
		bool flag = false;
		uint num4 = 255u;
		int num5 = 0;
		uint[] array5 = new uint[256];
		while (num4 != 0)
		{
			for (uint num6 = 0u; num6 < num; num6++)
			{
				array4[num6] = 0u;
				array2[num6] = 0u;
			}
			for (uint num7 = 0u; num7 < inputArray.Length; num7++)
			{
				array4[smethod_21(inputArray[num7], num4, num5)]++;
			}
			array5[0] = 0u;
			for (uint num8 = 1u; num8 < num; num8++)
			{
				array5[num8] = array5[num8 - 1] + array4[num8 - 1];
			}
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				uint num10 = smethod_21(inputArray[num9], num4, num5);
				uint num11 = num10 * num3;
				if (array2[num10] >= num3)
				{
					uint num12 = num11;
					for (int i = 0; i < num3; i++)
					{
						array3[array5[num10]++] = array[num12++];
					}
					array[num11] = inputArray[num9];
					array2[num10] = 1u;
				}
				else
				{
					array[num11 + array2[num10]] = inputArray[num9];
					array2[num10]++;
				}
			}
			for (uint num13 = 0u; num13 < num; num13++)
			{
				uint num14 = num13 * num3;
				uint num15 = array2[num13];
				for (int j = 0; j < num15; j++)
				{
					array3[array5[num13]++] = array[num14++];
				}
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			uint[] array6 = inputArray;
			inputArray = array3;
			array3 = array6;
		}
		if (flag)
		{
			for (uint num16 = 0u; num16 < inputArray.Length; num16++)
			{
				inputArray[num16] = array3[num16];
			}
		}
		return inputArray;
	}

	public static uint[] SortRadixDerandomizedWrites3(this uint[] inputArray)
	{
		uint[] array = new uint[16384];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[256];
		uint[] array4 = new uint[256];
		uint[] array5 = new uint[inputArray.Length];
		bool flag = false;
		int num = 0;
		uint[][] array6 = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array6[i] = new uint[256];
		}
		uint[][] array7 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		for (num = 0; num < 4; num++)
		{
			array6[num][0] = 0u;
			for (uint num2 = 1u; num2 < 256; num2++)
			{
				array6[num][num2] = array6[num][num2 - 1] + array7[num][num2 - 1];
			}
		}
		uint num3 = 255u;
		int num4 = 0;
		num = 0;
		while (num3 != 0)
		{
			uint[] array8 = array6[num];
			for (uint num5 = 0u; num5 < 256; num5++)
			{
				array3[num5] = num5 * 64;
				array2[num5] = num5 * 64;
				array4[num5] = num5 * 64 + 64 - 1;
			}
			for (uint num6 = 0u; num6 < inputArray.Length; num6++)
			{
				uint num7 = (inputArray[num6] & num3) >> num4;
				if (array2[num7] > array4[num7])
				{
					uint num8 = num7 * 64;
					uint num9 = array8[num7];
					for (int j = 0; j < 64L; j++)
					{
						array5[num9++] = array[num8++];
					}
					array8[num7] += 64u;
					array2[num7] = array3[num7];
					array[array2[num7]++] = inputArray[num6];
				}
				else
				{
					array[array2[num7]++] = inputArray[num6];
				}
			}
			for (uint num10 = 0u; num10 < 256; num10++)
			{
				uint num11 = num10 * 64;
				uint num12 = array8[num10];
				uint num13 = array2[num10] - array3[num10];
				for (int k = 0; k < num13; k++)
				{
					array5[num12++] = array[num11++];
				}
			}
			num3 <<= 8;
			num4 += 8;
			flag = !flag;
			num++;
			uint[] array9 = inputArray;
			inputArray = array5;
			array5 = array9;
		}
		if (flag)
		{
			for (uint num14 = 0u; num14 < inputArray.Length; num14++)
			{
				inputArray[num14] = array5[num14];
			}
		}
		return inputArray;
	}

	public static uint[] SortRadixDerandomizedWrites2(this uint[] inputArray)
	{
		uint num = 256u;
		uint[] array = new uint[65536];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[inputArray.Length];
		uint[][] array4 = new uint[4][];
		for (int i = 0; i < 4; i++)
		{
			array4[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint num3 = 255u;
		int num4 = 0;
		uint[][] array5 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1);
		for (num2 = 0; num2 < 4; num2++)
		{
			array4[num2][0] = 0u;
			for (uint num5 = 1u; num5 < 256; num5++)
			{
				array4[num2][num5] = array4[num2][num5 - 1] + array5[num2][num5 - 1];
			}
		}
		num2 = 0;
		while (num3 != 0)
		{
			for (uint num6 = 0u; num6 < 256; num6++)
			{
				array2[num6] = num6 * num;
			}
			uint[] array6 = array4[num2];
			for (uint num7 = 0u; num7 < inputArray.Length; num7++)
			{
				uint num8 = smethod_21(inputArray[num7], num3, num4);
				uint num9 = num8 * num;
				if (array2[num8] >= num)
				{
					uint num10 = num9;
					uint num11 = array6[num8];
					Array.Copy(array, num10, array3, num11, num);
					array6[num8] += num;
					array[num9] = inputArray[num7];
					array2[num8] = num8 * num + 1;
				}
				else
				{
					array[array2[num8]++] = inputArray[num7];
				}
			}
			for (uint num12 = 0u; num12 < 256; num12++)
			{
				uint num13 = num12 * num;
				uint num14 = array2[num12];
				for (int j = 0; j < num14; j++)
				{
					array3[array6[num12]++] = array[num13++];
				}
			}
			num3 <<= 8;
			num4 += 8;
			flag = !flag;
			num2++;
			uint[] array7 = inputArray;
			inputArray = array3;
			array3 = array7;
		}
		if (flag)
		{
			for (uint num15 = 0u; num15 < inputArray.Length; num15++)
			{
				inputArray[num15] = array3[num15];
			}
		}
		return inputArray;
	}

	public static uint[] SortRadixDerandomizeWrites(this uint[] inputArray, int start, int length)
	{
		int num = 256;
		int num2 = 8;
		uint num3 = 64u;
		uint[] array = new uint[16384L];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[inputArray.Length];
		uint[] array4 = new uint[256];
		bool flag = false;
		uint num4 = 255u;
		int num5 = 0;
		uint[] array5 = new uint[256];
		while (num4 != 0)
		{
			for (uint num6 = 0u; num6 < num; num6++)
			{
				array4[num6] = 0u;
				array2[num6] = 0u;
			}
			for (int i = start; i < start + length; i++)
			{
				array4[smethod_21(inputArray[i], num4, num5)]++;
			}
			array5[0] = (uint)start;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array5[num7] = array5[num7 - 1] + array4[num7 - 1];
			}
			for (int j = start; j < start + length; j++)
			{
				uint num8 = smethod_21(inputArray[j], num4, num5);
				uint num9 = num8 * num3;
				if (array2[num8] < num3)
				{
					array[num9 + array2[num8]] = inputArray[j];
					array2[num8]++;
					continue;
				}
				uint num10 = num9;
				for (int k = 0; k < num3; k++)
				{
					array3[array5[num8]++] = array[num10++];
				}
				array[num9] = inputArray[j];
				array2[num8] = 1u;
			}
			for (uint num11 = 0u; num11 < num; num11++)
			{
				uint num12 = num11 * num3;
				uint num13 = array2[num11];
				for (int l = 0; l < num13; l++)
				{
					array3[array5[num11]++] = array[num12++];
				}
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			uint[] array6 = inputArray;
			inputArray = array3;
			array3 = array6;
		}
		if (flag)
		{
			for (int m = start; m < start + length; m++)
			{
				inputArray[m] = array3[m];
			}
		}
		return inputArray;
	}

	public static void SortRadixDerandomizedWrites<T>(this T[] inputArray, int start, int length, T[] dst, Func<T, uint> getKey)
	{
		int num = 256;
		int num2 = 8;
		uint num3 = 64u;
		T[] array = new T[16384L];
		uint[] array2 = new uint[256];
		uint[] array3 = new uint[256];
		bool flag = false;
		uint num4 = 255u;
		int num5 = 0;
		uint[] array4 = new uint[256];
		while (num4 != 0)
		{
			for (uint num6 = 0u; num6 < num; num6++)
			{
				array3[num6] = 0u;
				array2[num6] = 0u;
			}
			for (int i = start; i < start + length; i++)
			{
				array3[smethod_21(getKey(inputArray[i]), num4, num5)]++;
			}
			array4[0] = (uint)start;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array4[num7] = array4[num7 - 1] + array3[num7 - 1];
			}
			for (int j = start; j < start + length; j++)
			{
				uint num8 = smethod_21(getKey(inputArray[j]), num4, num5);
				uint num9 = num8 * num3;
				if (array2[num8] < num3)
				{
					array[num9 + array2[num8]] = inputArray[j];
					array2[num8]++;
					continue;
				}
				uint num10 = num9;
				for (int k = 0; k < num3; k++)
				{
					dst[array4[num8]++] = array[num10++];
				}
				array[num9] = inputArray[j];
				array2[num8] = 1u;
			}
			for (uint num11 = 0u; num11 < num; num11++)
			{
				uint num12 = num11 * num3;
				uint num13 = array2[num11];
				for (int l = 0; l < num13; l++)
				{
					dst[array4[num11]++] = array[num12++];
				}
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			T[] array5 = inputArray;
			inputArray = dst;
			dst = array5;
		}
		if (flag)
		{
			for (int m = start; m < start + length; m++)
			{
				inputArray[m] = dst[m];
			}
		}
	}

	public static T[] SortRadix<T>(this T[] inputArray, Func<T, uint> getKey)
	{
		int num = 256;
		int num2 = 8;
		T[] array = new T[inputArray.Length];
		uint[] array2 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array3 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array2[num5] = 0u;
			}
			for (uint num6 = 0u; num6 < inputArray.Length; num6++)
			{
				array2[smethod_21(getKey(inputArray[num6]), num3, num4)]++;
			}
			array3[0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array3[num7] = array3[num7 - 1] + array2[num7 - 1];
			}
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array3[smethod_21(getKey(inputArray[num8]), num3, num4)]++] = inputArray[num8];
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array4 = inputArray;
			inputArray = array;
			array = array4;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixNew<T>(this T[] inputArray, Func<T, uint> getKey)
	{
		uint num = 256u;
		int num2 = 8;
		int num3 = 4;
		T[] array = new T[inputArray.Length];
		bool flag = false;
		uint num4 = 255u;
		int num5 = 0;
		int num6 = 0;
		uint[][] array2 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1, getKey);
		uint[][] array3 = new uint[4][];
		for (num6 = 0; num6 < num3; num6++)
		{
			array3[num6] = new uint[num];
			array3[num6][0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array3[num6][num7] = array3[num6][num7 - 1] + array2[num6][num7 - 1];
			}
		}
		num6 = 0;
		while (num4 != 0)
		{
			uint[] array4 = array3[num6];
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array4[(byte)(getKey(inputArray[num8]) >> num5)]++] = inputArray[num8];
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			num6++;
			T[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadix<T>(this T[] inputArray, Func<T, ulong> getKey)
	{
		int num = 256;
		int num2 = 8;
		T[] array = new T[inputArray.Length];
		uint[] array2 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array3 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array2[num5] = 0u;
			}
			for (uint num6 = 0u; num6 < inputArray.Length; num6++)
			{
				array2[smethod_22(getKey(inputArray[num6]), num3, num4)]++;
			}
			array3[0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array3[num7] = array3[num7 - 1] + array2[num7 - 1];
			}
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array3[smethod_22(getKey(inputArray[num8]), num3, num4)]++] = inputArray[num8];
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array4 = inputArray;
			inputArray = array;
			array = array4;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixNew<T>(this T[] inputArray, Func<T, ulong> getKey)
	{
		int num = 256;
		int num2 = 8;
		int num3 = 8;
		T[] array = new T[inputArray.Length];
		bool flag = false;
		ulong num4 = 255uL;
		int num5 = 0;
		int num6 = 0;
		uint[][] array2 = new uint[8][];
		for (int i = 0; i < num3; i++)
		{
			array2[i] = new uint[num];
		}
		uint[][] array3 = HistogramByteComponents(inputArray, 0, inputArray.Length - 1, getKey);
		for (num6 = 0; num6 < num3; num6++)
		{
			array2[num6][0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array2[num6][num7] = array2[num6][num7 - 1] + array3[num6][num7 - 1];
			}
		}
		num6 = 0;
		while (num4 != 0L)
		{
			uint[] array4 = array2[num6];
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array4[(byte)(getKey(inputArray[num8]) >> num5)]++] = inputArray[num8];
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			num6++;
			T[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixFaster<T>(this T[] inputArray, Func<T, uint> getKey)
	{
		int num = 256;
		int num2 = 8;
		T[] array = new T[inputArray.Length];
		uint[] array2 = new uint[inputArray.Length];
		uint[] array3 = new uint[inputArray.Length];
		uint[] array4 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array5 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array4[num5] = 0u;
			}
			if (num3 == 255)
			{
				for (uint num6 = 0u; num6 < inputArray.Length; num6++)
				{
					array2[num6] = getKey(inputArray[num6]);
					array4[smethod_21(array2[num6], num3, num4)]++;
				}
			}
			else
			{
				for (uint num7 = 0u; num7 < inputArray.Length; num7++)
				{
					array4[smethod_21(array2[num7], num3, num4)]++;
				}
			}
			array5[0] = 0u;
			for (uint num8 = 1u; num8 < num; num8++)
			{
				array5[num8] = array5[num8 - 1] + array4[num8 - 1];
			}
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				uint num10 = smethod_21(array2[num9], num3, num4);
				uint num11 = array5[num10];
				array[num11] = inputArray[num9];
				array3[num11] = array2[num9];
				array5[num10]++;
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array6 = inputArray;
			inputArray = array;
			array = array6;
			uint[] array7 = array2;
			array2 = array3;
			array3 = array7;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixFasterNew<T>(this T[] inputArray, Func<T, uint> getKey)
	{
		T[] array = new T[inputArray.Length];
		uint[] array2 = new uint[inputArray.Length];
		bool flag = false;
		uint num = 255u;
		int num2 = 0;
		Tuple<uint[][], uint[]> tuple = HistogramByteComponentsAndKeyArray(inputArray, 0, inputArray.Length - 1, getKey);
		uint[][] item = tuple.Item1;
		uint[] array3 = tuple.Item2;
		uint[][] array4 = new uint[4][];
		int i;
		for (i = 0; i < 4; i++)
		{
			array4[i] = new uint[256];
			array4[i][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array4[i][num3] = array4[i][num3 - 1] + item[i][num3 - 1];
			}
		}
		i = 0;
		while (num != 0)
		{
			uint[] array5 = array4[i];
			for (uint num4 = 0u; num4 < inputArray.Length; num4++)
			{
				byte b = (byte)(array3[num4] >> num2);
				uint num5 = array5[b];
				array[num5] = inputArray[num4];
				array2[num5] = array3[num4];
				array5[b]++;
			}
			num <<= 8;
			num2 += 8;
			flag = !flag;
			i++;
			T[] array6 = inputArray;
			inputArray = array;
			array = array6;
			uint[] array7 = array3;
			array3 = array2;
			array2 = array7;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixFaster<T>(this T[] inputArray, Func<T, ulong> getKey)
	{
		int num = 256;
		int num2 = 8;
		T[] array = new T[inputArray.Length];
		ulong[] array2 = new ulong[inputArray.Length];
		ulong[] array3 = new ulong[inputArray.Length];
		uint[] array4 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array5 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array4[num5] = 0u;
			}
			if (num3 == 255)
			{
				for (uint num6 = 0u; num6 < inputArray.Length; num6++)
				{
					array2[num6] = getKey(inputArray[num6]);
					array4[smethod_22(array2[num6], num3, num4)]++;
				}
			}
			else
			{
				for (uint num7 = 0u; num7 < inputArray.Length; num7++)
				{
					array4[smethod_22(array2[num7], num3, num4)]++;
				}
			}
			array5[0] = 0u;
			for (uint num8 = 1u; num8 < num; num8++)
			{
				array5[num8] = array5[num8 - 1] + array4[num8 - 1];
			}
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				uint num10 = smethod_22(array2[num9], num3, num4);
				uint num11 = array5[num10];
				array[num11] = inputArray[num9];
				array3[num11] = array2[num9];
				array5[num10]++;
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array6 = inputArray;
			inputArray = array;
			array = array6;
			ulong[] array7 = array2;
			array2 = array3;
			array3 = array7;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static T[] SortRadixFasterNew<T>(this T[] inputArray, Func<T, ulong> getKey)
	{
		int num = 256;
		int num2 = 8;
		int num3 = 4;
		T[] array = new T[inputArray.Length];
		ulong[] array2 = new ulong[inputArray.Length];
		bool flag = false;
		uint num4 = 255u;
		int num5 = 0;
		uint[][] array3 = new uint[4][];
		for (int i = 0; i < num3; i++)
		{
			array3[i] = new uint[num];
		}
		Tuple<uint[][], ulong[]> tuple = HistogramByteComponentsAndKeyArray(inputArray, 0, inputArray.Length - 1, getKey);
		uint[][] item = tuple.Item1;
		ulong[] array4 = tuple.Item2;
		int j;
		for (j = 0; j < num3; j++)
		{
			array3[j][0] = 0u;
			for (uint num6 = 1u; num6 < num; num6++)
			{
				array3[j][num6] = array3[j][num6 - 1] + item[j][num6 - 1];
			}
		}
		j = 0;
		while (num4 != 0)
		{
			uint[] array5 = array3[j];
			for (uint num7 = 0u; num7 < inputArray.Length; num7++)
			{
				uint num8 = (byte)(array4[num7] >> num5);
				uint num9 = array5[num8];
				array[num9] = inputArray[num7];
				array2[num9] = array4[num7];
				array5[num8]++;
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			j++;
			T[] array6 = inputArray;
			inputArray = array;
			array = array6;
			ulong[] array7 = array4;
			array4 = array2;
			array2 = array7;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static List<T> SortRadixFaster<T>(this List<T> inputList, Func<T, uint> getKey)
	{
		return new List<T>(SortRadixFaster(inputList.ToArray(), getKey));
	}

	public static List<T> SortRadixFaster<T>(this List<T> inputList, Func<T, ulong> getKey)
	{
		return new List<T>(SortRadixFaster(inputList.ToArray(), getKey));
	}

	public static void SortRadix<T>(this T[] inputArray, int start, int length, T[] outputArray, Func<T, uint> getKey)
	{
		int num = 256;
		int num2 = 8;
		uint[] array = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array2 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array[num5] = 0u;
			}
			for (int i = start; i < start + length; i++)
			{
				array[smethod_21(getKey(inputArray[i]), num3, num4)]++;
			}
			array2[0] = (uint)start;
			for (uint num6 = 1u; num6 < num; num6++)
			{
				array2[num6] = array2[num6 - 1] + array[num6 - 1];
			}
			for (int j = start; j < start + length; j++)
			{
				outputArray[array2[smethod_21(getKey(inputArray[j]), num3, num4)]++] = inputArray[j];
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array3 = inputArray;
			inputArray = outputArray;
			outputArray = array3;
		}
		if (!flag)
		{
			for (int k = start; k < start + length; k++)
			{
				outputArray[k] = inputArray[k];
			}
		}
	}

	private static uint smethod_21(uint uint_0, uint uint_1, int int_9)
	{
		return (uint_0 & uint_1) >> int_9;
	}

	private static uint smethod_22(ulong ulong_0, ulong ulong_1, int int_9)
	{
		return (uint)((ulong_0 & ulong_1) >> int_9);
	}

	public static List<T> SortRadix<T>(this List<T> inputList, Func<T, uint> getKey)
	{
		return new List<T>(SortRadix(inputList.ToArray(), getKey));
	}

	public static List<T> SortRadix<T>(this List<T> inputList, Func<T, ulong> getKey)
	{
		return new List<T>(SortRadix(inputList.ToArray(), getKey));
	}

	public static Tuple<T[], uint[]> SortRadix<T>(this T[] inputArray, uint[] inKeys)
	{
		int num = 256;
		int num2 = 8;
		uint[] array = new uint[inputArray.Length];
		T[] array2 = new T[inputArray.Length];
		uint[] array3 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array4 = new uint[256];
		uint[] array5 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array3[num5] = 0u;
			}
			for (uint num6 = 0u; num6 < inputArray.Length; num6++)
			{
				array3[smethod_21(inKeys[num6], num3, num4)]++;
			}
			uint num7 = 0u;
			array5[0] = 0u;
			array4[0] = 0u;
			for (uint num8 = 1u; num8 < num; num8++)
			{
				array4[num8] = (array5[num8] = array4[num8 - 1] + array3[num8 - 1]);
			}
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				uint num10 = smethod_21(inKeys[num9], num3, num4);
				uint num11 = array5[num10];
				array2[num11] = inputArray[num9];
				array[num11] = inKeys[num9];
				array5[num10]++;
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array6 = inputArray;
			inputArray = array2;
			array2 = array6;
			uint[] array7 = inKeys;
			inKeys = array;
			array = array7;
		}
		if (flag)
		{
			for (uint num12 = 0u; num12 < inputArray.Length; num12++)
			{
				inputArray[num12] = array2[num12];
				inKeys[num12] = array[num12];
			}
		}
		return new Tuple<T[], uint[]>(inputArray, array);
	}

	public static Tuple<T[], ulong[]> SortRadix<T>(this T[] inputArray, ulong[] inKeys)
	{
		int num = 256;
		int num2 = 8;
		ulong[] array = new ulong[inputArray.Length];
		T[] array2 = new T[inputArray.Length];
		uint[] array3 = new uint[256];
		bool flag = false;
		uint num3 = 255u;
		int num4 = 0;
		uint[] array4 = new uint[256];
		uint[] array5 = new uint[256];
		while (num3 != 0)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array3[num5] = 0u;
			}
			for (uint num6 = 0u; num6 < inputArray.Length; num6++)
			{
				array3[smethod_22(inKeys[num6], num3, num4)]++;
			}
			uint num7 = 0u;
			array5[0] = 0u;
			array4[0] = 0u;
			for (uint num8 = 1u; num8 < num; num8++)
			{
				array4[num8] = (array5[num8] = array4[num8 - 1] + array3[num8 - 1]);
			}
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				uint num10 = smethod_22(inKeys[num9], num3, num4);
				uint num11 = array5[num10];
				array2[num11] = inputArray[num9];
				array[num11] = inKeys[num9];
				array5[num10]++;
			}
			num3 <<= num2;
			num4 += num2;
			flag = !flag;
			T[] array6 = inputArray;
			inputArray = array2;
			array2 = array6;
			ulong[] array7 = inKeys;
			inKeys = array;
			array = array7;
		}
		if (flag)
		{
			for (uint num12 = 0u; num12 < inputArray.Length; num12++)
			{
				inputArray[num12] = array2[num12];
				inKeys[num12] = array[num12];
			}
		}
		return new Tuple<T[], ulong[]>(inputArray, array);
	}

	public static Tuple<List<T>, uint[]> SortRadix<T>(this List<T> inputList, uint[] inKeys)
	{
		Tuple<T[], uint[]> tuple = SortRadix(inputList.ToArray(), inKeys);
		return new Tuple<List<T>, uint[]>(new List<T>(tuple.Item1), tuple.Item2);
	}

	public static Tuple<List<T>, ulong[]> SortRadix<T>(this List<T> inputList, ulong[] inKeys)
	{
		Tuple<T[], ulong[]> tuple = SortRadix(inputList.ToArray(), inKeys);
		return new Tuple<List<T>, ulong[]>(new List<T>(tuple.Item1), tuple.Item2);
	}

	public static int[] SortRadixReturnIndexes(this byte[] inputArray, SortOrder sortOrder = SortOrder.Ascending)
	{
		int num = 256;
		int[] array = new int[inputArray.Length];
		int[] array2 = new int[256];
		int[] array3 = new int[256];
		for (int i = 0; i < num; i++)
		{
			array2[i] = 0;
		}
		for (int j = 0; j < inputArray.Length; j++)
		{
			array2[inputArray[j]]++;
		}
		int num3;
		if (sortOrder != SortOrder.Ascending)
		{
			array3[num - 1] = 0;
			for (int num2 = num - 2; num2 >= 0; num2--)
			{
				array3[num2] = array3[num2 + 1] + array2[num2 + 1];
			}
			num3 = 0;
		}
		else
		{
			array3[0] = 0;
			for (int k = 1; k < num; k++)
			{
				array3[k] = array3[k - 1] + array2[k - 1];
			}
			num3 = 0;
		}
		for (int l = num3; l < inputArray.Length; l++)
		{
			byte b = inputArray[l];
			array[array3[b]++] = l;
		}
		return array;
	}

	public static void SortRadixMsd(this byte[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
	}

	public static byte[] SortRadixMsdInPlaceFunc(this byte[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this sbyte[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
	}

	public static sbyte[] SortRadixMsdInPlaceFunc(this sbyte[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this ushort[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
	}

	public static ushort[] SortRadixMsdInPlaceFunc(this ushort[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this short[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
	}

	public static short[] SortRadixMsdInPlaceFunc(this short[] arrayToBeSorted)
	{
		SortCountingInPlace(arrayToBeSorted);
		return arrayToBeSorted;
	}

	private static void smethod_23(uint[] uint_0, int int_9, int int_10, int int_11, Action<uint[], int, int> action_0, int int_12 = 1024)
	{
		if (int_10 < int_12)
		{
			action_0(uint_0, int_9, int_10);
			return;
		}
		int num = int_9 + int_10 - 1;
		int[] array = HistogramOneByteComponent(uint_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		for (int num2 = int_9; num2 <= num; num2 = array3[i - 1])
		{
			uint num3 = uint_0[num2];
			uint num4;
			while (array3[num4 = (num3 >> int_11) & 0xFF] != num2)
			{
				uint num5 = uint_0[array3[num4]];
				uint_0[array3[num4]++] = num3;
				num3 = num5;
			}
			uint_0[num2] = num3;
			array3[num4]++;
			for (; array3[i - 1] == array2[i]; i++)
			{
			}
		}
		if (int_11 > 0)
		{
			int num6;
			if (int_11 < 8)
			{
				int_11 = 0;
				num6 = 0;
			}
			else
			{
				int_11 -= 8;
				num6 = 0;
			}
			for (int k = num6; k < 256; k++)
			{
				smethod_23(uint_0, array2[k], array3[k] - array2[k], int_11, action_0);
			}
		}
	}

	private static void smethod_24(ulong[] ulong_0, int int_9, int int_10, int int_11, Action<ulong[], int, int> action_0)
	{
		if (int_10 >= int_5)
		{
			int num = int_9 + int_10 - 1;
			int[] array = HistogramOneByteComponent(ulong_0, int_9, num, int_11);
			int[] array2 = new int[257];
			int[] array3 = new int[256];
			int i = 1;
			array2[0] = (array3[0] = int_9);
			array2[256] = -1;
			for (int j = 1; j < 256; j++)
			{
				array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
			}
			for (int num2 = int_9; num2 <= num; num2 = array3[i - 1])
			{
				ulong num3 = ulong_0[num2];
				ulong num4;
				while (array3[num4 = (num3 >> int_11) & 0xFFL] != num2)
				{
					ulong num5 = ulong_0[array3[num4]];
					ulong_0[array3[num4]++] = num3;
					num3 = num5;
				}
				ulong_0[num2] = num3;
				array3[num4]++;
				for (; array3[i - 1] == array2[i]; i++)
				{
				}
			}
			if (int_11 > 0)
			{
				int num6;
				if (int_11 < 8)
				{
					int_11 = 0;
					num6 = 0;
				}
				else
				{
					int_11 -= 8;
					num6 = 0;
				}
				for (int k = num6; k < 256; k++)
				{
					smethod_24(ulong_0, array2[k], array3[k] - array2[k], int_11, action_0);
				}
			}
		}
		else
		{
			action_0(ulong_0, int_9, int_10);
		}
	}

	private static void smethod_25(ulong[] ulong_0, int int_9, int int_10, int int_11, Action<ulong[], int, int> action_0)
	{
		if (int_10 < int_5)
		{
			action_0(ulong_0, int_9, int_10);
			return;
		}
		int num = int_9 + int_10 - 1;
		int[] array = HistogramOneByteComponent(ulong_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		for (int num2 = int_9; num2 <= num; num2 = array3[i - 1])
		{
			if (num2 + 1 > num)
			{
				ulong num3;
				while (array3[num3 = (ulong_0[num2] >> int_11) & 0xFFL] != num2)
				{
					Swap(ulong_0, num2, array3[num3]++);
				}
				array3[num3]++;
			}
			else
			{
				bool flag = false;
				while (true)
				{
					ulong num4 = (ulong_0[num2] >> int_11) & 0xFFL;
					if (array3[num4] != num2)
					{
						Swap(ulong_0, num2, array3[num4]++);
						if (!flag)
						{
							ulong num5 = (ulong_0[num2 + 1] >> int_11) & 0xFFL;
							if (array3[num5] == num2)
							{
								Swap(ulong_0, num2 + 1, array3[num5]++);
								break;
							}
							if (array3[num5] != num2 + 1)
							{
								Swap(ulong_0, num2 + 1, array3[num5]++);
								continue;
							}
							array3[num5]++;
							flag = true;
						}
						continue;
					}
					array3[num4]++;
					break;
				}
			}
			for (; array3[i - 1] == array2[i]; i++)
			{
			}
		}
		if (int_11 > 0)
		{
			int num6;
			if (int_11 < 8)
			{
				int_11 = 0;
				num6 = 0;
			}
			else
			{
				int_11 -= 8;
				num6 = 0;
			}
			for (int k = num6; k < 256; k++)
			{
				smethod_25(ulong_0, array2[k], array3[k] - array2[k], int_11, action_0);
			}
		}
	}

	private static void smethod_26(object object_0, int int_9, int int_10, int int_11)
	{
		int[] array = new int[256];
		int num = int_9 + int_10 - 1;
		while (int_9 <= num)
		{
			ulong B = (ulong)((long[])object_0)[int_9];
			while (true)
			{
				ulong num2 = (B >> int_11) & 0xFFL;
				if (array[num2] == int_9)
				{
					break;
				}
				Swap(ref B, (ulong[])object_0, array[num2]++);
			}
			((long[])object_0)[int_9] = (long)B;
		}
	}

	private static void smethod_27(object object_0, int int_9, int int_10, int int_11)
	{
		int[] array = new int[256];
		int num = int_9 + int_10 - 1;
		while (int_9 <= num)
		{
			ulong[] array2 = new ulong[4];
			int num2 = 0;
			array2[0] = (ulong)((long[])object_0)[int_9];
			while (true)
			{
				ulong num3 = (array2[num2] >> int_11) & 0xFFL;
				if (array[num3] == int_9)
				{
					break;
				}
				array2[++num2] = (ulong)((long[])object_0)[array[num3]];
				num3 = (array2[num2] >> int_11) & 0xFFL;
				if (array[num3] != int_9)
				{
					array2[++num2] = (ulong)((long[])object_0)[array[num3]++];
					continue;
				}
				((long[])object_0)[array[num3]++] = (long)array2[num2];
				break;
			}
			((long[])object_0)[int_9] = (long)array2[num2];
		}
	}

	public static void SortRadixMsd(this uint[] arrayToBeSorted, int start, int length, int threshold = 1024)
	{
		smethod_23(arrayToBeSorted, start, length, 24, Array.Sort, threshold);
	}

	public static void SortRadixMsd(this uint[] arrayToBeSorted, int threshold = 1024)
	{
		smethod_23(arrayToBeSorted, 0, arrayToBeSorted.Length, 24, Array.Sort, threshold);
	}

	public static uint[] SortRadixMsdInPlaceFunc(this uint[] arrayToBeSorted, int threshold = 1024)
	{
		SortRadixMsd(arrayToBeSorted, threshold);
		return arrayToBeSorted;
	}

	public static void SortRadixInPlaceAdaptive(this uint[] arrayToBeSorted, int start, int length, int threshold = 1024)
	{
		try
		{
			SortRadix(arrayToBeSorted, start, length);
		}
		catch (OutOfMemoryException)
		{
			SortRadixMsd(arrayToBeSorted, start, length, threshold);
		}
	}

	public static void SortRadixInPlaceAdaptive(this uint[] arrayToBeSorted, int threshold = 1024)
	{
		try
		{
			SortRadix(arrayToBeSorted);
		}
		catch (OutOfMemoryException)
		{
			SortRadixMsd(arrayToBeSorted, threshold);
		}
	}

	public static uint[] SortRadixInPlaceAdaptiveFunc(this uint[] arrayToBeSorted, int threshold = 1024)
	{
		try
		{
			SortRadix(arrayToBeSorted);
		}
		catch (OutOfMemoryException)
		{
			SortRadixMsd(arrayToBeSorted, threshold);
		}
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this ulong[] arrayToBeSorted, int start, int length)
	{
		smethod_24(arrayToBeSorted, start, length, 56, Array.Sort);
	}

	public static void SortRadixMsd(this ulong[] arrayToBeSorted)
	{
		smethod_24(arrayToBeSorted, 0, arrayToBeSorted.Length, 56, Array.Sort);
	}

	public static ulong[] SortRadixMsdInPlaceFunc(this ulong[] arrayToBeSorted)
	{
		SortRadixMsd(arrayToBeSorted);
		return arrayToBeSorted;
	}

	private static void smethod_28(int[] int_9, int int_10, int int_11, int int_12, Action<int[], int, int> action_0)
	{
		int num = int_10 + int_11 - 1;
		int[] array = HistogramOneByteComponent(int_9, int_10, num, int_12);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_10);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num2 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num2++;
			}
		}
		if (num2 > 1)
		{
			if (int_12 == 24)
			{
				for (int num3 = int_10; num3 <= num; num3 = array3[i - 1])
				{
					byte b = 128;
					byte b2;
					while (array3[b2 = (byte)((byte)(int_9[num3] >> int_12) ^ b)] != num3)
					{
						int num4 = int_9[num3];
						int_9[num3] = int_9[array3[b2]];
						int_9[array3[b2]++] = num4;
					}
					array3[b2]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			else
			{
				for (int num5 = int_10; num5 <= num; num5 = array3[i - 1])
				{
					byte b3;
					while (array3[b3 = (byte)(int_9[num5] >> int_12)] != num5)
					{
						int num6 = int_9[num5];
						int_9[num5] = int_9[array3[b3]];
						int_9[array3[b3]++] = num6;
					}
					array3[b3]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			if (int_12 <= 0)
			{
				return;
			}
			int_12 = ((int_12 >= 8) ? (int_12 -= 8) : 0);
			for (int l = 0; l < 256; l++)
			{
				int num7 = array3[l] - array2[l];
				if (num7 < int_4)
				{
					if (num7 >= 2)
					{
						action_0(int_9, array2[l], num7);
					}
				}
				else
				{
					smethod_28(int_9, array2[l], num7, int_12, action_0);
				}
			}
		}
		else
		{
			if (int_12 <= 0)
			{
				return;
			}
			int_12 = ((int_12 >= 8) ? (int_12 -= 8) : 0);
			if (int_11 < int_4)
			{
				if (int_11 >= 2)
				{
					action_0(int_9, int_10, int_11);
				}
			}
			else
			{
				smethod_28(int_9, int_10, int_11, int_12, action_0);
			}
		}
	}

	private static void smethod_29(long[] long_0, int int_9, int int_10, int int_11, Action<long[], int, int> action_0)
	{
		int num = int_9 + int_10 - 1;
		int[] array = HistogramOneByteComponent(long_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num2 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num2++;
			}
		}
		if (num2 <= 1)
		{
			if (int_11 <= 0)
			{
				return;
			}
			int_11 = ((int_11 >= 8) ? (int_11 -= 8) : 0);
			if (int_10 < int_6)
			{
				if (int_10 >= 2)
				{
					action_0(long_0, int_9, int_10);
				}
			}
			else
			{
				smethod_29(long_0, int_9, int_10, int_11, action_0);
			}
			return;
		}
		if (int_11 == 56)
		{
			for (int num3 = int_9; num3 <= num; num3 = array3[i - 1])
			{
				byte b = 128;
				byte b2;
				while (array3[b2 = (byte)((byte)(long_0[num3] >> int_11) ^ b)] != num3)
				{
					long num4 = long_0[num3];
					long_0[num3] = long_0[array3[b2]];
					long_0[array3[b2]++] = num4;
				}
				array3[b2]++;
				for (; array3[i - 1] == array2[i]; i++)
				{
				}
			}
		}
		else
		{
			for (int num5 = int_9; num5 <= num; num5 = array3[i - 1])
			{
				byte b3;
				while (array3[b3 = (byte)(long_0[num5] >> int_11)] != num5)
				{
					long num6 = long_0[num5];
					long_0[num5] = long_0[array3[b3]];
					long_0[array3[b3]++] = num6;
				}
				array3[b3]++;
				for (; array3[i - 1] == array2[i]; i++)
				{
				}
			}
		}
		if (int_11 <= 0)
		{
			return;
		}
		int_11 = ((int_11 >= 8) ? (int_11 -= 8) : 0);
		for (int l = 0; l < 256; l++)
		{
			int num7 = array3[l] - array2[l];
			if (num7 >= int_6)
			{
				smethod_29(long_0, array2[l], num7, int_11, action_0);
			}
			else if (num7 >= 2)
			{
				action_0(long_0, array2[l], num7);
			}
		}
	}

	private static void smethod_30(long[] long_0, int int_9, int int_10, int int_11, Action<long[], int, int> action_0)
	{
		int num = int_9 + int_10 - 1;
		int[] array = HistogramByteComponentsUsingUnion(long_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num2 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num2++;
			}
		}
		if (num2 > 1)
		{
			if (int_11 == 56)
			{
				for (int num3 = int_9; num3 <= num; num3 = array3[i - 1])
				{
					long num4 = long_0[num3];
					ulong num5;
					while (array3[num5 = (ulong)((num4 >>> int_11) ^ 0x80L)] != num3)
					{
						long num6 = long_0[array3[num5]];
						long_0[array3[num5]++] = num4;
						num4 = num6;
					}
					long_0[num3] = num4;
					array3[num5]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			else
			{
				for (int num7 = int_9; num7 <= num; num7 = array3[i - 1])
				{
					long num8 = long_0[num7];
					while (true)
					{
						ulong num9 = (ulong)((num8 >>> int_11) & 0xFFL);
						if (array3[num9] != num7)
						{
							long num10 = long_0[array3[num9]];
							ulong num11 = (ulong)((num10 >>> int_11) & 0xFFL);
							if (array3[num11] != num7)
							{
								long_0[array3[num9]++] = num8;
								num8 = num10;
								continue;
							}
							long_0[array3[num9]++] = num8;
							long_0[num7] = num10;
							array3[num11]++;
							break;
						}
						long_0[num7] = num8;
						array3[num9]++;
						break;
					}
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			if (int_11 <= 0)
			{
				return;
			}
			int_11 = ((int_11 >= 8) ? (int_11 -= 8) : 0);
			for (int l = 0; l < 256; l++)
			{
				int num12 = array3[l] - array2[l];
				if (num12 >= int_6)
				{
					smethod_30(long_0, array2[l], num12, int_11, action_0);
				}
				else if (num12 >= 2)
				{
					action_0(long_0, array2[l], num12);
				}
			}
		}
		else if (int_11 > 0)
		{
			int_11 = ((int_11 >= 8) ? (int_11 -= 8) : 0);
			if (int_10 >= int_6)
			{
				smethod_30(long_0, int_9, int_10, int_11, action_0);
			}
			else if (int_10 >= 2)
			{
				action_0(long_0, int_9, int_10);
			}
		}
	}

	private static void smethod_31(long[] long_0, int int_9, int int_10, int int_11, int int_12, Action<long[], int, int> action_0)
	{
		int num = int_9 + int_10 - 1;
		ulong num2 = (ulong)(1L << int_12);
		ulong num3 = num2 - 1L;
		ulong num4 = num2 / 2L;
		int[] array = HistogramNbitComponents(long_0, int_9, num, int_11, int_12);
		int[] array2 = new int[num2 + 1L];
		int[] array3 = new int[num2];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[num2] = -1;
		for (int j = 1; j < (int)num2; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num5 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num5++;
			}
		}
		if (num5 <= 1)
		{
			if (int_11 > 0)
			{
				int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
				if (int_10 >= int_6)
				{
					smethod_31(long_0, int_9, int_10, int_11, int_12, action_0);
				}
				else if (int_10 >= 2)
				{
					action_0(long_0, int_9, int_10);
				}
			}
			return;
		}
		if (int_11 == 64 - int_12)
		{
			for (int num6 = int_9; num6 <= num; num6 = array3[i - 1])
			{
				long num7 = long_0[num6];
				ulong num8;
				while (array3[num8 = (ulong)(num7 >>> int_11) ^ num4] != num6)
				{
					long num9 = long_0[array3[num8]];
					long_0[array3[num8]++] = num7;
					num7 = num9;
				}
				long_0[num6] = num7;
				array3[num8]++;
				for (; array3[i - 1] == array2[i]; i++)
				{
				}
			}
		}
		else
		{
			for (int num10 = int_9; num10 <= num; num10 = array3[i - 1])
			{
				long num11 = long_0[num10];
				ulong num12;
				while (array3[num12 = (ulong)(num11 >>> int_11) & num3] != num10)
				{
					long num13 = long_0[array3[num12]];
					long_0[array3[num12]++] = num11;
					num11 = num13;
				}
				long_0[num10] = num11;
				array3[num12]++;
				for (; array3[i - 1] == array2[i]; i++)
				{
				}
			}
		}
		if (int_11 <= 0)
		{
			return;
		}
		int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
		for (int l = 0; l < (int)num2; l++)
		{
			int num14 = array3[l] - array2[l];
			if (num14 < int_6)
			{
				if (num14 >= 2)
				{
					action_0(long_0, array2[l], num14);
				}
			}
			else
			{
				smethod_31(long_0, array2[l], num14, int_11, int_12, action_0);
			}
		}
	}

	public static void SortRadixMsd(this int[] arrayToBeSorted)
	{
		smethod_28(arrayToBeSorted, 0, arrayToBeSorted.Length, 24, Array.Sort);
	}

	public static int[] SortRadixMsdInPlaceFunc(this int[] arrayToBeSorted)
	{
		SortRadixMsd(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this long[] arrayToBeSorted)
	{
		smethod_29(arrayToBeSorted, 0, arrayToBeSorted.Length, 56, Array.Sort);
	}

	public static long[] SortRadixMsdInPlaceFunc(this long[] arrayToBeSorted)
	{
		SortRadixMsd(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixNbitMsd(this long[] arrayToBeSorted, int numberOfBitsPerDigit = 10)
	{
		int int_ = 64 - numberOfBitsPerDigit;
		smethod_31(arrayToBeSorted, 0, arrayToBeSorted.Length, int_, numberOfBitsPerDigit, Array.Sort);
	}

	public static long[] SortRadixMsdNbitInPlaceFunc(this long[] arrayToBeSorted, int numberOfBitsPerDigit = 10)
	{
		SortRadixNbitMsd(arrayToBeSorted, numberOfBitsPerDigit);
		return arrayToBeSorted;
	}

	private static void smethod_32(float[] float_0, int int_9, int int_10, uint uint_0, int int_11, int int_12, Action<float[], int, int> action_0)
	{
		int num = int_9 + int_10 - 1;
		uint num2 = (uint)(1 << int_12);
		uint num3 = num2 / 2;
		int[] array = HistogramOneByteComponent(float_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num4 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num4++;
			}
		}
		FloatUInt32Union floatUInt32Union = default(FloatUInt32Union);
		if (num4 > 1)
		{
			if (int_11 == 24)
			{
				for (int num5 = int_9; num5 <= num; num5 = array3[i - 1])
				{
					uint num6;
					while (true)
					{
						floatUInt32Union.floatValue = float_0[num5];
						num6 = (((floatUInt32Union.uinteger & 0x80000000u) == 0) ? ((floatUInt32Union.uinteger >> int_11) ^ num3) : ((floatUInt32Union.uinteger ^ 0xFFFFFFFFu) >> int_11));
						if (array3[num6] == num5)
						{
							break;
						}
						float num7 = float_0[num5];
						float_0[num5] = float_0[array3[num6]];
						float_0[array3[num6]++] = num7;
					}
					array3[num6]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			else
			{
				for (int num8 = int_9; num8 <= num; num8 = array3[i - 1])
				{
					uint num9;
					while (true)
					{
						floatUInt32Union.floatValue = float_0[num8];
						num9 = (((floatUInt32Union.uinteger & 0x80000000u) != 0) ? (((floatUInt32Union.uinteger ^ 0xFFFFFFFFu) & uint_0) >> int_11) : ((floatUInt32Union.uinteger & uint_0) >> int_11));
						if (array3[num9] == num8)
						{
							break;
						}
						float num10 = float_0[num8];
						float_0[num8] = float_0[array3[num9]];
						float_0[array3[num9]++] = num10;
					}
					array3[num9]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			if (int_11 <= 0)
			{
				return;
			}
			int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
			uint_0 >>= 8;
			for (int l = 0; l < (int)num2; l++)
			{
				int num11 = array3[l] - array2[l];
				if (num11 >= int_7)
				{
					smethod_32(float_0, array2[l], array3[l] - array2[l], uint_0, int_11, int_12, action_0);
				}
				else if (num11 >= 2)
				{
					action_0(float_0, array2[l], num11);
				}
			}
		}
		else if (int_11 > 0)
		{
			int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
			uint_0 >>= 8;
			if (int_10 >= int_7)
			{
				smethod_32(float_0, int_9, int_10, uint_0, int_11, int_12, action_0);
			}
			else if (int_10 >= 2)
			{
				action_0(float_0, int_9, int_10);
			}
		}
	}

	private static void smethod_33(double[] double_0, int int_9, int int_10, ulong ulong_0, int int_11, int int_12, Action<double[], int, int> action_0)
	{
		int num = int_9 + int_10 - 1;
		ulong num2 = (ulong)(1L << int_12);
		ulong num3 = num2 / 2L;
		int[] array = HistogramOneByteComponent(double_0, int_9, num, int_11);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			array2[j] = (array3[j] = array2[j - 1] + array[j - 1]);
		}
		int num4 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] > 0)
			{
				num4++;
			}
		}
		DoubleUInt64Union doubleUInt64Union = default(DoubleUInt64Union);
		if (num4 > 1)
		{
			if (int_11 == 56)
			{
				for (int num5 = int_9; num5 <= num; num5 = array3[i - 1])
				{
					byte b;
					while (true)
					{
						doubleUInt64Union.doubleValue = double_0[num5];
						b = (((doubleUInt64Union.ulongInteger & 0x8000000000000000uL) == 0L) ? ((byte)((doubleUInt64Union.ulongInteger >> int_11) ^ num3)) : ((byte)((doubleUInt64Union.ulongInteger ^ 0xFFFFFFFFFFFFFFFFuL) >> int_11)));
						if (array3[b] == num5)
						{
							break;
						}
						double num6 = double_0[num5];
						double_0[num5] = double_0[array3[b]];
						double_0[array3[b]++] = num6;
					}
					array3[b]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			else
			{
				for (int num7 = int_9; num7 <= num; num7 = array3[i - 1])
				{
					byte b2;
					while (true)
					{
						doubleUInt64Union.doubleValue = double_0[num7];
						b2 = (((doubleUInt64Union.ulongInteger & 0x8000000000000000uL) != 0L) ? ((byte)(((doubleUInt64Union.ulongInteger ^ 0xFFFFFFFFFFFFFFFFuL) & ulong_0) >> int_11)) : ((byte)((doubleUInt64Union.ulongInteger & ulong_0) >> int_11)));
						if (array3[b2] == num7)
						{
							break;
						}
						double num8 = double_0[num7];
						double_0[num7] = double_0[array3[b2]];
						double_0[array3[b2]++] = num8;
					}
					array3[b2]++;
					for (; array3[i - 1] == array2[i]; i++)
					{
					}
				}
			}
			if (int_11 <= 0)
			{
				return;
			}
			int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
			ulong_0 >>= 8;
			for (int l = 0; l < (int)num2; l++)
			{
				int num9 = array3[l] - array2[l];
				if (num9 >= int_8)
				{
					smethod_33(double_0, array2[l], array3[l] - array2[l], ulong_0, int_11, int_12, action_0);
				}
				else if (num9 >= 2)
				{
					action_0(double_0, array2[l], num9);
				}
			}
		}
		else if (int_11 > 0)
		{
			int_11 = ((int_11 >= int_12) ? (int_11 -= int_12) : 0);
			ulong_0 >>= 8;
			if (int_10 >= int_8)
			{
				smethod_33(double_0, int_9, int_10, ulong_0, int_11, int_12, action_0);
			}
			else if (int_10 >= 2)
			{
				action_0(double_0, int_9, int_10);
			}
		}
	}

	public static void SortRadixMsd(this float[] arrayToBeSorted)
	{
		smethod_32(arrayToBeSorted, 0, arrayToBeSorted.Length, 4278190080u, 24, 8, Array.Sort);
	}

	public static float[] SortRadixMsdInPlaceFunc(this float[] arrayToBeSorted)
	{
		SortRadixMsd(arrayToBeSorted);
		return arrayToBeSorted;
	}

	public static void SortRadixMsd(this double[] arrayToBeSorted)
	{
		smethod_33(arrayToBeSorted, 0, arrayToBeSorted.Length, 18374686479671623680uL, 56, 8, Array.Sort);
	}

	public static double[] SortRadixMsdInPlaceFunc(this double[] arrayToBeSorted)
	{
		SortRadixMsd(arrayToBeSorted);
		return arrayToBeSorted;
	}

	private static void smethod_34(object object_0, int int_9, int int_10, ushort ushort_0, int int_11, Action<ushort[], int, int> action_0)
	{
		if (int_10 < int_3)
		{
			action_0((ushort[])object_0, int_9, int_10);
			return;
		}
		int num = int_9 + int_10 - 1;
		int[] array = new int[256];
		for (int i = 0; i < 256; i++)
		{
			array[i] = 0;
		}
		for (int j = int_9; j <= num; j++)
		{
			array[(((ushort[])object_0)[j] & ushort_0) >> int_11]++;
		}
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int k = 1;
		array2[0] = (array3[0] = int_9);
		array2[256] = -1;
		for (int l = 1; l < 256; l++)
		{
			array2[l] = (array3[l] = array2[l - 1] + array[l - 1]);
		}
		for (int num2 = int_9; num2 <= num; num2 = array3[k - 1])
		{
			ushort num3 = ((ushort[])object_0)[num2];
			ushort num4;
			while (array3[num4 = (ushort)((num3 & ushort_0) >> int_11)] != num2)
			{
				ushort num5 = ((ushort[])object_0)[array3[num4]];
				((short[])object_0)[array3[num4]++] = (short)num3;
				num3 = num5;
			}
			((short[])object_0)[num2] = (short)num3;
			array3[num4]++;
			for (; array3[k - 1] == array2[k]; k++)
			{
			}
		}
		ushort_0 >>= 8;
		if (ushort_0 == 0)
		{
			return;
		}
		int num6;
		if (int_11 < 8)
		{
			int_11 = 0;
			num6 = 0;
		}
		else
		{
			int_11 -= 8;
			num6 = 0;
		}
		for (int m = num6; m < 256; m++)
		{
			if (array3[m] - array2[m] > 0)
			{
				smethod_34(object_0, array2[m], array3[m] - array2[m], ushort_0, int_11, action_0);
			}
		}
	}

	private static ushort[] smethod_35(this object object_0)
	{
		smethod_34(object_0, 0, ((Array)object_0).Length, 65280, 8, Array.Sort);
		return (ushort[])object_0;
	}

	public static bool SequenceEqualHpc<T>(this T[] first, T[] second, int l, int r)
	{
		if (first != null && second != null)
		{
			if (l > r)
			{
				return true;
			}
			if (l >= 0 && r < first.Length && r >= 0 && r < second.Length)
			{
				Comparer<T> comparer = Comparer<T>.Default;
				int num = l;
				while (true)
				{
					if (num <= r)
					{
						if (comparer.Compare(first[num], second[num]) != 0)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			throw new ArgumentOutOfRangeException();
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this T[] first, T[] second, int l, int r, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (l > r)
			{
				return true;
			}
			if (l >= 0 && r < first.Length && r >= 0 && r < second.Length)
			{
				int num = l;
				while (true)
				{
					if (num <= r)
					{
						if (!equalityComparer.Equals(first[num], second[num]))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			throw new ArgumentOutOfRangeException();
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this T[] first, T[] second)
	{
		if (first != null && second != null)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			Comparer<T> comparer = Comparer<T>.Default;
			int num = 0;
			while (true)
			{
				if (num < first.Length)
				{
					if (comparer.Compare(first[num], second[num]) != 0)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this T[] first, T[] second, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < first.Length)
				{
					if (!equalityComparer.Equals(first[num], second[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this List<T> first, List<T> second, int l, int r)
	{
		if (first != null && second != null)
		{
			if (l >= 0 && r < first.Count && r >= 0 && r < second.Count)
			{
				Comparer<T> comparer = Comparer<T>.Default;
				int num = l;
				while (true)
				{
					if (num <= r)
					{
						if (comparer.Compare(first[num], second[num]) != 0)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			throw new ArgumentOutOfRangeException();
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this List<T> first, List<T> second, int l, int r, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (l >= 0 && r < first.Count && r >= 0 && r < second.Count)
			{
				int num = l;
				while (true)
				{
					if (num <= r)
					{
						if (!equalityComparer.Equals(first[num], second[num]))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			throw new ArgumentOutOfRangeException();
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this List<T> first, List<T> second)
	{
		if (first != null && second != null)
		{
			if (first.Count != second.Count)
			{
				return false;
			}
			Comparer<T> comparer = Comparer<T>.Default;
			int num = 0;
			while (true)
			{
				if (num < first.Count)
				{
					if (comparer.Compare(first[num], second[num]) != 0)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpc<T>(this List<T> first, List<T> second, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (first.Count != second.Count)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < first.Count)
				{
					if (!equalityComparer.Equals(first[num], second[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		throw new ArgumentNullException();
	}

	static Algorithm()
	{
		Class72.smethod_20();
		int_0 = 4096;
		int_1 = 16;
		int_2 = 1024;
		int_3 = 1024;
		int_4 = 64;
		int_5 = 1024;
		int_6 = 64;
		int_7 = 1024;
		int_8 = 1024;
	}
}
