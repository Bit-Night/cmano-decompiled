using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSMaterial;
using HPCsharp.Algorithms;
using HPCsharp.ParallelAlgorithms;

namespace HPCsharp;

public static class ParallelAlgorithm
{
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

	public static int MergeParallelArrayThreshold
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

	public static int SortMergeParallelInsertionThreshold
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

	public static int ThresholdParallelMin
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

	public static int SortRadixMsdLongThreshold
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

	public static int SortRadixMsdLongParallelThreshold
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

	public static void BlockSwapReversalPar<T>(T[] array, int l, int m, int r, int threshold = 16384)
	{
		if (r - l + 1 < threshold)
		{
			Algorithm.Reversal(array, l, m);
			Algorithm.Reversal(array, m + 1, r);
			Algorithm.Reversal(array, l, r);
			return;
		}
		Parallel.Invoke(delegate
		{
			Algorithm.Reversal(array, l, m);
		}, delegate
		{
			Algorithm.Reversal(array, m + 1, r);
		});
		Algorithm.Reversal(array, l, r);
	}

	public static void BlockSwapReversalPar2<T>(T[] array, int l, int m, int r, int threshold = 16384)
	{
		int num = r - l + 1;
		if (num < threshold)
		{
			Algorithm.Reversal(array, l, m);
			Algorithm.Reversal(array, m + 1, r);
			Algorithm.Reversal(array, l, r);
			return;
		}
		int num2 = (m - l + 1 + 2) / 4 * 2;
		int int_3 = num2 / 2;
		int num3 = (r - (m + 1) + 1 + 2) / 4 * 2;
		int int_4 = num3 / 2;
		Parallel.Invoke(delegate
		{
			Algorithm.Swap(array, l, m - int_3 + 1, int_3, reverse: true);
		}, delegate
		{
			Algorithm.Reversal(array, l + int_3, m - int_3);
		}, delegate
		{
			Algorithm.Swap(array, m + 1, r - int_4 + 1, int_4, reverse: true);
		}, delegate
		{
			Algorithm.Reversal(array, m + 1 + int_4, r - int_4);
		});
		num2 = (num + 2) / 4 * 2;
		int_3 = num2 / 2;
		Parallel.Invoke(delegate
		{
			Algorithm.Swap(array, l, r - int_3 + 1, int_3, reverse: true);
		}, delegate
		{
			Algorithm.Reversal(array, l + int_3, r - int_3);
		});
	}

	public static byte[] SortCountingPar(this byte[] inputArray)
	{
		byte[] array = new byte[inputArray.Length];
		int[] array2 = HistogramPar(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			FillSse(array, (byte)num2, num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	private static void smethod_0(this byte[] byte_0)
	{
		int[] array = HistogramPar(byte_0);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			FillSse(byte_0, (byte)num2, num, array[num2]);
			num += array[num2];
		}
	}

	private static byte[] smethod_1(this byte[] byte_0)
	{
		byte_0.smethod_0();
		return byte_0;
	}

	public static ushort[] SortCountingPar(this ushort[] inputArray)
	{
		ushort[] array = new ushort[inputArray.Length];
		int[] array2 = HistogramPar(inputArray);
		int num = 0;
		for (uint num2 = 0u; num2 < array2.Length; num2++)
		{
			Algorithm.FillUsingBlockCopy(array, (ushort)num2, num, array2[num2]);
			num += array2[num2];
		}
		return array;
	}

	private static void smethod_2(this ushort[] ushort_0)
	{
		int[] array = HistogramPar(ushort_0);
		int num = 0;
		for (uint num2 = 0u; num2 < array.Length; num2++)
		{
			Algorithm.FillUsingBlockCopy(ushort_0, (ushort)num2, num, array[num2]);
			num += array[num2];
		}
	}

	private static ushort[] smethod_3(this ushort[] ushort_0)
	{
		ushort_0.smethod_2();
		return ushort_0;
	}

	public static void FillPar<T>(this T[] arrayToFill, T value) where T : struct
	{
		int int_0 = arrayToFill.Length / 2;
		int int_1 = arrayToFill.Length - int_0;
		Parallel.Invoke(delegate
		{
			Algorithm.Fill(arrayToFill, value, 0, int_0);
		}, delegate
		{
			Algorithm.Fill(arrayToFill, value, int_0, int_1);
		});
	}

	public static void FillPar<T>(this T[] arrayToFill, T value, int startIndex, int length) where T : struct
	{
		int int_1 = length / 2;
		int int_2 = length - int_1;
		Parallel.Invoke(delegate
		{
			Algorithm.Fill(arrayToFill, value, startIndex, int_1);
		}, delegate
		{
			Algorithm.Fill(arrayToFill, value, startIndex + int_1, int_2);
		});
	}

	private static void smethod_4(this byte[] byte_0, byte byte_1)
	{
		int int_0 = byte_0.Length / 2;
		int int_1 = byte_0.Length - int_0;
		Parallel.Invoke(delegate
		{
			Algorithm.Fill(byte_0, byte_1, 0, int_0);
		}, delegate
		{
			Algorithm.Fill(byte_0, byte_1, int_0, int_1);
		});
	}

	private static void smethod_5(this byte[] byte_0, byte byte_1, int int_7, int int_8)
	{
		int int_9 = int_8 / 2;
		int int_10 = int_8 - int_9;
		Parallel.Invoke(delegate
		{
			Algorithm.Fill(byte_0, byte_1, int_7, int_9);
		}, delegate
		{
			Algorithm.Fill(byte_0, byte_1, int_7 + int_9, int_10);
		});
	}

	public static void FillGenericSse<T>(this T[] arrayToFill, T value) where T : struct
	{
		Vector<T> vector = new Vector<T>(value);
		int num = arrayToFill.Length / Vector<T>.Count * Vector<T>.Count;
		int i;
		for (i = 0; i < num; i += Vector<T>.Count)
		{
			vector.CopyTo(arrayToFill, i);
		}
		for (; i < arrayToFill.Length; i++)
		{
			arrayToFill[i] = value;
		}
	}

	public static void FillGenericSse<T>(this T[] arrayToFill, T value, int startIndex, int length) where T : struct
	{
		Vector<T> vector = new Vector<T>(value);
		int num = length / Vector<T>.Count * Vector<T>.Count;
		int i;
		for (i = startIndex; i < num; i += Vector<T>.Count)
		{
			vector.CopyTo(arrayToFill, i);
		}
		for (; i < arrayToFill.Length; i++)
		{
			arrayToFill[i] = value;
		}
	}

	public static void FillSse(this byte[] arrayToFill, byte value)
	{
		Vector<byte> vector = new Vector<byte>(value);
		int num = arrayToFill.Length / Vector<byte>.Count * Vector<byte>.Count;
		int i;
		for (i = 0; i < num; i += Vector<byte>.Count)
		{
			vector.CopyTo(arrayToFill, i);
		}
		for (; i < arrayToFill.Length; i++)
		{
			arrayToFill[i] = value;
		}
	}

	public unsafe static void FillSse(this byte[] arrayToFill, byte value, int startIndex, int length)
	{
		Vector<byte> vector = new Vector<byte>(value);
		int i = startIndex;
		fixed (byte* ptr = &arrayToFill[startIndex])
		{
			int num = (int)((long)ptr & (long)(Vector<byte>.Count - 1));
			int num2 = ((num != 0) ? Vector<byte>.Count : 0);
			int num3 = 0;
			int num4 = num;
			while (num4 < num2 && num3 < length)
			{
				arrayToFill[i] = value;
				num4++;
				i++;
				num3++;
			}
			for (int num5 = i + (length - num3) / Vector<byte>.Count * Vector<byte>.Count; i < num5; i += Vector<byte>.Count)
			{
				vector.CopyTo(arrayToFill, i);
			}
		}
		for (; i < startIndex + length; i++)
		{
			arrayToFill[i] = value;
		}
	}

	private static int[] smethod_6(this object object_0)
	{
		int[] array = new int[256];
		int count = Vector<byte>.Count;
		int i;
		for (i = 0; i <= ((Array)object_0).Length - count; i += count)
		{
			Vector<byte> vector = new Vector<byte>((byte[])object_0, i);
			for (int j = 0; j < count; j++)
			{
				array[vector[j]]++;
			}
		}
		for (; i < ((Array)object_0).Length; i++)
		{
			array[((byte[])object_0)[i]]++;
		}
		return array;
	}

	public static int[] HistogramOneByteComponentSse(long[] inArray, int l, int r, int shiftRightAmount)
	{
		int[] array = new int[256];
		int[] array2 = new int[Vector<long>.Count];
		int num = l + (r - l + 1) / Vector<long>.Count * Vector<long>.Count;
		int num2 = shiftRightAmount / 8;
		for (int i = 0; i < Vector<long>.Count; i++)
		{
			array2[i] = i * 8 + num2;
		}
		if (shiftRightAmount != 56)
		{
			int j;
			for (j = l; j < num; j += Vector<long>.Count)
			{
				Vector<byte> vector = Vector.AsVectorByte(new Vector<long>(inArray, j));
				for (int k = 0; k < Vector<long>.Count; k++)
				{
					array[vector[array2[k]]]++;
				}
			}
			for (; j <= r; j++)
			{
				array[(byte)(inArray[j] >> shiftRightAmount)]++;
			}
		}
		else
		{
			int j;
			for (j = l; j < num; j += Vector<long>.Count)
			{
				Vector<byte> vector2 = Vector.AsVectorByte(new Vector<long>(inArray, j));
				for (int m = 0; m < Vector<long>.Count; m++)
				{
					array[vector2[array2[m]] ^ 0x80]++;
				}
			}
			for (; j <= r; j++)
			{
				array[(byte)(inArray[j] >> shiftRightAmount) ^ 0x80]++;
			}
		}
		return array;
	}

	public static int[] HistogramInnerPar(byte[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = 256;
		int[] int_0 = null;
		int[] int_4 = null;
		if (l <= r)
		{
			if (r - l + 1 > parallelThreshold)
			{
				int int_5 = (r + l) / 2;
				Parallel.Invoke(delegate
				{
					int_0 = HistogramInnerPar(inArray, l, int_5, parallelThreshold);
				}, delegate
				{
					int_4 = HistogramInnerPar(inArray, int_5 + 1, r, parallelThreshold);
				});
				for (int num2 = 0; num2 < num; num2++)
				{
					int_0[num2] += int_4[num2];
				}
				return int_0;
			}
			int_0 = new int[num];
			for (int num3 = l; num3 <= r; num3++)
			{
				int_0[inArray[num3]]++;
			}
			return int_0;
		}
		int_0 = new int[num];
		return int_0;
	}

	public static int[] HistogramPar(this byte[] inArray, int parallelThreshold = 16384)
	{
		return HistogramInnerPar(inArray, 0, inArray.Length - 1, parallelThreshold);
	}

	public static int[] HistogramInnerPar(ushort[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = 65536;
		int[] WgsexeFroSc = null;
		int[] int_3 = null;
		if (l <= r)
		{
			if (r - l + 1 > parallelThreshold)
			{
				int int_4 = (r + l) / 2;
				Parallel.Invoke(delegate
				{
					WgsexeFroSc = HistogramInnerPar(inArray, l, int_4, parallelThreshold);
				}, delegate
				{
					int_3 = HistogramInnerPar(inArray, int_4 + 1, r, parallelThreshold);
				});
				for (int num2 = 0; num2 < num; num2++)
				{
					WgsexeFroSc[num2] += int_3[num2];
				}
				return WgsexeFroSc;
			}
			WgsexeFroSc = new int[num];
			for (int num3 = l; num3 <= r; num3++)
			{
				WgsexeFroSc[inArray[num3]]++;
			}
			return WgsexeFroSc;
		}
		WgsexeFroSc = new int[num];
		return WgsexeFroSc;
	}

	public static int[] HistogramPar(this ushort[] inArray)
	{
		return HistogramInnerPar(inArray, 0, inArray.Length - 1);
	}

	private static uint[][] smethod_7(uint[] uint_0, int int_7, int int_8, int int_9 = 16384)
	{
		uint[][] uint_1 = null;
		uint[][] uint_2 = null;
		if (int_7 <= int_8)
		{
			if (int_8 - int_7 + 1 <= int_9)
			{
				uint_1 = new uint[4][];
				for (int i = 0; i < 4; i++)
				{
					uint_1[i] = new uint[256];
				}
				uint[] array = uint_1[0];
				uint[] array2 = uint_1[1];
				uint[] array3 = uint_1[2];
				uint[] array4 = uint_1[3];
				Algorithm.UInt32ByteUnion uInt32ByteUnion = default(Algorithm.UInt32ByteUnion);
				for (int j = int_7; j <= int_8; j++)
				{
					uInt32ByteUnion.integer = uint_0[j];
					array[uInt32ByteUnion.byte0]++;
					array2[uInt32ByteUnion.byte1]++;
					array3[uInt32ByteUnion.byte2]++;
					array4[uInt32ByteUnion.byte3]++;
				}
				return uint_1;
			}
			int int_10 = (int_8 + int_7) / 2;
			Parallel.Invoke(delegate
			{
				uint_1 = smethod_7(uint_0, int_7, int_10, int_9);
			}, delegate
			{
				uint_2 = smethod_7(uint_0, int_10 + 1, int_8, int_9);
			});
			for (int num = 0; num < 4; num++)
			{
				for (int num2 = 0; num2 < 256; num2++)
				{
					uint_1[num][num2] += uint_2[num][num2];
				}
			}
			return uint_1;
		}
		uint_1 = new uint[4][];
		for (int num3 = 0; num3 < 4; num3++)
		{
			uint_1[num3] = new uint[256];
		}
		return uint_1;
	}

	public static uint[][] HistogramByteComponentsPar(uint[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_7(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_8(uint[] uint_0, int int_7, int int_8, int int_9 = 16384)
	{
		uint[][] uint_1 = null;
		uint[][] uint_2 = null;
		if (int_7 > int_8)
		{
			uint_1 = new uint[4][];
			for (int i = 0; i < 4; i++)
			{
				uint_1[i] = new uint[256];
			}
			return uint_1;
		}
		if (int_8 - int_7 + 1 <= int_9)
		{
			uint_1 = new uint[4][];
			for (int j = 0; j < 4; j++)
			{
				uint_1[j] = new uint[256];
			}
			uint[] array = uint_1[0];
			uint[] array2 = uint_1[1];
			uint[] array3 = uint_1[2];
			uint[] array4 = uint_1[3];
			Algorithm.UInt32ByteUnion uInt32ByteUnion = default(Algorithm.UInt32ByteUnion);
			for (int k = int_7; k <= int_8; k++)
			{
				uInt32ByteUnion.integer = uint_0[k];
				array[uInt32ByteUnion.byte0]++;
				array2[uInt32ByteUnion.byte1]++;
				array3[uInt32ByteUnion.byte2]++;
				array4[uInt32ByteUnion.byte3]++;
			}
			return uint_1;
		}
		int int_10 = (int_8 + int_7) / 2;
		Parallel.Invoke(delegate
		{
			uint_1 = smethod_8(uint_0, int_7, int_10, int_9);
		}, delegate
		{
			uint_2 = smethod_8(uint_0, int_10 + 1, int_8, int_9);
		});
		for (int num = 0; num < 4; num++)
		{
			HPCsharp.ParallelAlgorithms.Addition.AddToSse(uint_1[num], uint_2[num]);
		}
		return uint_1;
	}

	public static uint[][] HistogramByteComponentsSsePar(uint[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_8(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_9(uint[] uint_0, int int_7, int int_8, int int_9, uint uint_1, uint uint_2, int int_10 = 16384)
	{
		uint[][] uint_3 = null;
		uint[][] uint_4 = null;
		if (int_8 - int_7 + 1 <= int_10)
		{
			return Algorithm.HistogramByteComponentsAcrossWorkQuantasQC(uint_0, int_7, int_8, int_9, uint_1, uint_2);
		}
		int wFbexWpCegG = (int_8 + int_7) / 2;
		Parallel.Invoke(delegate
		{
			uint_3 = smethod_9(uint_0, int_7, wFbexWpCegG, int_9, uint_1, uint_2, int_10);
		}, delegate
		{
			uint_4 = smethod_9(uint_0, wFbexWpCegG + 1, int_8, int_9, uint_1, uint_2, int_10);
		});
		long num = int_7 / int_9;
		long num2 = int_8 / int_9;
		for (int num3 = (int)num; num3 <= num2; num3++)
		{
			for (int num4 = 0; num4 < 256; num4++)
			{
				uint_3[num3][num4] += uint_4[num3][num4];
			}
		}
		return uint_3;
	}

	public static uint[][] HistogramByteComponentsQCPar(uint[] inArray, int l, int r, int workQuanta, uint numberOfQuantas, uint whichByte, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_9(inArray, l, r, workQuanta, numberOfQuantas, whichByte, parallelThreshold);
	}

	private static uint[][] smethod_10(int[] int_7, int int_8, int int_9, int int_10 = 16384)
	{
		uint[][] uint_0 = null;
		uint[][] uint_1 = null;
		if (int_8 > int_9)
		{
			uint_0 = new uint[4][];
			for (int i = 0; i < 4; i++)
			{
				uint_0[i] = new uint[256];
			}
			return uint_0;
		}
		if (int_9 - int_8 + 1 > int_10)
		{
			int int_11 = (int_9 + int_8) / 2;
			Parallel.Invoke(delegate
			{
				uint_0 = smethod_10(int_7, int_8, int_11, int_10);
			}, delegate
			{
				uint_1 = smethod_10(int_7, int_11 + 1, int_9, int_10);
			});
			for (int num = 0; num < 4; num++)
			{
				for (int num2 = 0; num2 < 256; num2++)
				{
					uint_0[num][num2] += uint_1[num][num2];
				}
			}
			return uint_0;
		}
		uint_0 = new uint[4][];
		for (int num3 = 0; num3 < 4; num3++)
		{
			uint_0[num3] = new uint[256];
		}
		uint[] array = uint_0[0];
		uint[] array2 = uint_0[1];
		uint[] array3 = uint_0[2];
		uint[] array4 = uint_0[3];
		Algorithm.Int32ByteUnion int32ByteUnion = default(Algorithm.Int32ByteUnion);
		for (int num4 = int_8; num4 <= int_9; num4++)
		{
			int32ByteUnion.integer = int_7[num4];
			array[int32ByteUnion.byte0]++;
			array2[int32ByteUnion.byte1]++;
			array3[int32ByteUnion.byte2]++;
			array4[(int_7[num4] >>> 24) ^ 0x80]++;
		}
		return uint_0;
	}

	public static uint[][] HistogramByteComponentsPar(int[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_10(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_11(int[] int_7, int int_8, int int_9, int int_10 = 16384)
	{
		uint[][] uint_0 = null;
		uint[][] uint_1 = null;
		if (int_8 <= int_9)
		{
			if (int_9 - int_8 + 1 <= int_10)
			{
				uint_0 = new uint[4][];
				for (int i = 0; i < 4; i++)
				{
					uint_0[i] = new uint[256];
				}
				uint[] array = uint_0[0];
				uint[] array2 = uint_0[1];
				uint[] array3 = uint_0[2];
				uint[] array4 = uint_0[3];
				Algorithm.Int32ByteUnion int32ByteUnion = default(Algorithm.Int32ByteUnion);
				for (int j = int_8; j <= int_9; j++)
				{
					int32ByteUnion.integer = int_7[j];
					array[int32ByteUnion.byte0]++;
					array2[int32ByteUnion.byte1]++;
					array3[int32ByteUnion.byte2]++;
					array4[(int_7[j] >>> 24) ^ 0x80]++;
				}
				return uint_0;
			}
			int int_11 = (int_9 + int_8) / 2;
			Parallel.Invoke(delegate
			{
				uint_0 = smethod_11(int_7, int_8, int_11, int_10);
			}, delegate
			{
				uint_1 = smethod_11(int_7, int_11 + 1, int_9, int_10);
			});
			for (int num = 0; num < 4; num++)
			{
				HPCsharp.ParallelAlgorithms.Addition.AddToSse(uint_0[num], uint_1[num]);
			}
			return uint_0;
		}
		uint_0 = new uint[4][];
		for (int num2 = 0; num2 < 4; num2++)
		{
			uint_0[num2] = new uint[256];
		}
		return uint_0;
	}

	public static uint[][] HistogramByteComponentsSsePar(int[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_11(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_12(ulong[] ulong_0, int int_7, int int_8, int int_9 = 16384)
	{
		uint[][] uint_0 = null;
		uint[][] uint_1 = null;
		if (int_7 > int_8)
		{
			uint_0 = new uint[8][];
			for (int i = 0; i < 8; i++)
			{
				uint_0[i] = new uint[256];
			}
			return uint_0;
		}
		if (int_8 - int_7 + 1 > int_9)
		{
			int int_10 = (int_8 + int_7) / 2;
			Parallel.Invoke(delegate
			{
				uint_0 = smethod_12(ulong_0, int_7, int_10, int_9);
			}, delegate
			{
				uint_1 = smethod_12(ulong_0, int_10 + 1, int_8, int_9);
			});
			for (int num = 0; num < 8; num++)
			{
				for (int num2 = 0; num2 < 256; num2++)
				{
					uint_0[num][num2] += uint_1[num][num2];
				}
			}
			return uint_0;
		}
		uint_0 = new uint[8][];
		for (int num3 = 0; num3 < 8; num3++)
		{
			uint_0[num3] = new uint[256];
		}
		uint[] array = uint_0[0];
		uint[] array2 = uint_0[1];
		uint[] array3 = uint_0[2];
		uint[] array4 = uint_0[3];
		uint[] array5 = uint_0[4];
		uint[] array6 = uint_0[5];
		uint[] array7 = uint_0[6];
		uint[] array8 = uint_0[7];
		Algorithm.UInt64ByteUnion uInt64ByteUnion = default(Algorithm.UInt64ByteUnion);
		for (int num4 = int_7; num4 <= int_8; num4++)
		{
			uInt64ByteUnion.integer = ulong_0[num4];
			array[uInt64ByteUnion.byte0]++;
			array2[uInt64ByteUnion.byte1]++;
			array3[uInt64ByteUnion.byte2]++;
			array4[uInt64ByteUnion.byte3]++;
			array5[uInt64ByteUnion.byte4]++;
			array6[uInt64ByteUnion.byte5]++;
			array7[uInt64ByteUnion.byte6]++;
			array8[uInt64ByteUnion.byte7]++;
		}
		return uint_0;
	}

	public static uint[][] HistogramByteComponentsPar(ulong[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_12(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_13(long[] long_0, int int_7, int int_8, int int_9 = 16384)
	{
		uint[][] uint_0 = null;
		uint[][] uint_1 = null;
		if (int_7 > int_8)
		{
			uint_0 = new uint[8][];
			for (int i = 0; i < 8; i++)
			{
				uint_0[i] = new uint[256];
			}
			return uint_0;
		}
		if (int_8 - int_7 + 1 > int_9)
		{
			int int_10 = (int_8 + int_7) / 2;
			Parallel.Invoke(delegate
			{
				uint_0 = smethod_13(long_0, int_7, int_10, int_9);
			}, delegate
			{
				uint_1 = smethod_13(long_0, int_10 + 1, int_8, int_9);
			});
			for (int num = 0; num < 8; num++)
			{
				for (int num2 = 0; num2 < 256; num2++)
				{
					uint_0[num][num2] += uint_1[num][num2];
				}
			}
			return uint_0;
		}
		uint_0 = new uint[8][];
		for (int num3 = 0; num3 < 8; num3++)
		{
			uint_0[num3] = new uint[256];
		}
		uint[] array = uint_0[0];
		uint[] array2 = uint_0[1];
		uint[] array3 = uint_0[2];
		uint[] array4 = uint_0[3];
		uint[] array5 = uint_0[4];
		uint[] array6 = uint_0[5];
		uint[] array7 = uint_0[6];
		uint[] array8 = uint_0[7];
		Algorithm.Int64ByteUnion int64ByteUnion = default(Algorithm.Int64ByteUnion);
		for (int num4 = int_7; num4 <= int_8; num4++)
		{
			int64ByteUnion.integer = long_0[num4];
			array[int64ByteUnion.byte0]++;
			array2[int64ByteUnion.byte1]++;
			array3[int64ByteUnion.byte2]++;
			array4[int64ByteUnion.byte3]++;
			array5[int64ByteUnion.byte4]++;
			array6[int64ByteUnion.byte5]++;
			array7[int64ByteUnion.byte6]++;
			array8[(long_0[num4] >>> 56) ^ 0x80L]++;
		}
		return uint_0;
	}

	public static uint[][] HistogramByteComponentsPar(long[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_13(inArray, l, r, parallelThreshold);
	}

	private static uint[][] smethod_14(long[] long_0, int int_7, int int_8, int int_9 = 16384)
	{
		uint[][] uint_0 = null;
		uint[][] uint_1 = null;
		if (int_7 > int_8)
		{
			uint_0 = new uint[8][];
			for (int i = 0; i < 8; i++)
			{
				uint_0[i] = new uint[256];
			}
			return uint_0;
		}
		if (int_8 - int_7 + 1 <= int_9)
		{
			uint_0 = new uint[8][];
			for (int j = 0; j < 8; j++)
			{
				uint_0[j] = new uint[256];
			}
			uint[] array = uint_0[0];
			uint[] array2 = uint_0[1];
			uint[] array3 = uint_0[2];
			uint[] array4 = uint_0[3];
			uint[] array5 = uint_0[4];
			uint[] array6 = uint_0[5];
			uint[] array7 = uint_0[6];
			uint[] array8 = uint_0[7];
			Algorithm.Int64ByteUnion int64ByteUnion = default(Algorithm.Int64ByteUnion);
			for (int k = int_7; k <= int_8; k++)
			{
				int64ByteUnion.integer = long_0[k];
				array[int64ByteUnion.byte0]++;
				array2[int64ByteUnion.byte1]++;
				array3[int64ByteUnion.byte2]++;
				array4[int64ByteUnion.byte3]++;
				array5[int64ByteUnion.byte4]++;
				array6[int64ByteUnion.byte5]++;
				array7[int64ByteUnion.byte6]++;
				array8[(long_0[k] >>> 56) ^ 0x80L]++;
			}
			return uint_0;
		}
		int int_10 = (int_8 + int_7) / 2;
		Parallel.Invoke(delegate
		{
			uint_0 = smethod_14(long_0, int_7, int_10, int_9);
		}, delegate
		{
			uint_1 = smethod_14(long_0, int_10 + 1, int_8, int_9);
		});
		for (int num = 0; num < 8; num++)
		{
			HPCsharp.ParallelAlgorithms.Addition.AddToSse(uint_0[num], uint_1[num]);
		}
		return uint_0;
	}

	public static uint[][] HistogramByteComponentsSsePar(long[] inArray, int l, int r, int parallelThreshold = 16384)
	{
		int num = r - l + 1;
		if (parallelThreshold * Misc.Environment_ProcessorCount < num)
		{
			parallelThreshold = num / Misc.Environment_ProcessorCount;
		}
		return smethod_14(inArray, l, r, parallelThreshold);
	}

	private static int[] smethod_15(long[] long_0, int int_7, int int_8, int int_9, int int_10 = 16384)
	{
		int[] int_11 = null;
		int[] int_12 = null;
		if (int_7 <= int_8)
		{
			if (int_8 - int_7 + 1 <= int_10)
			{
				return Algorithm.HistogramOneByteComponent(long_0, int_7, int_8, int_9);
			}
			int int_13 = (int_8 + int_7) / 2;
			Parallel.Invoke(delegate
			{
				int_11 = smethod_15(long_0, int_7, int_13, int_9, int_10);
			}, delegate
			{
				int_12 = smethod_15(long_0, int_13 + 1, int_8, int_9, int_10);
			});
			int_11 = HPCsharp.Algorithms.Addition.Add(int_11, int_12);
			return int_11;
		}
		int_11 = new int[256];
		return int_11;
	}

	private static int[] smethod_16(uint[] uint_0, int int_7, int int_8, int int_9, int int_10 = 16384)
	{
		int[] int_11 = null;
		int[] int_12 = null;
		if (int_7 <= int_8)
		{
			if (int_8 - int_7 + 1 <= int_10)
			{
				return Algorithm.HistogramOneByteComponent(uint_0, int_7, int_8, int_9);
			}
			int int_13 = (int_8 + int_7) / 2;
			Parallel.Invoke(delegate
			{
				int_11 = smethod_16(uint_0, int_7, int_13, int_9, int_10);
			}, delegate
			{
				int_12 = smethod_16(uint_0, int_13 + 1, int_8, int_9, int_10);
			});
			int_11 = HPCsharp.Algorithms.Addition.Add(int_11, int_12);
			return int_11;
		}
		int_11 = new int[256];
		return int_11;
	}

	private static void smethod_17(uint[] uint_0, int int_7, int int_8, int int_9)
	{
		if (int_8 - int_7 <= 4096)
		{
			Algorithm.IntroSortInner(uint_0, int_7, int_8, int_9);
		}
		else if (int_8 - int_7 > 16)
		{
			if (int_9 != 0)
			{
				int_9--;
				int i = Algorithm.findPivot(uint_0, int_7, int_7 + (int_8 - int_7) / 2 + 1, int_8);
				Algorithm.swap(uint_0, i, int_8);
				int int_10 = Algorithm.partition(uint_0, int_7, int_8);
				Parallel.Invoke(delegate
				{
					smethod_17(uint_0, int_7, int_10 - 1, int_9);
				}, delegate
				{
					smethod_17(uint_0, int_10 + 1, int_8, int_9);
				});
			}
			else
			{
				Algorithm.heapSort(uint_0, int_7, int_8);
			}
		}
		else
		{
			Algorithm.insertionSort(uint_0, int_7, int_8);
		}
	}

	public static void IntroSortPar(uint[] src)
	{
		int int_ = (int)(2.0 * Math.Floor(Math.Log(src.Length) / Math.Log(2.0)));
		smethod_17(src, 0, src.Length - 1, int_);
	}

	internal static void MergeInnerPar<T>(T[] src, int p1, int r1, int p2, int r2, T[] dst, int p3, IComparer<T> comparer = null)
	{
		int a = r1 - p1 + 1;
		int b = r2 - p2 + 1;
		if (a < b)
		{
			Algorithm.Swap(ref p1, ref p2);
			Algorithm.Swap(ref r1, ref r2);
			Algorithm.Swap(ref a, ref b);
		}
		if (a == 0)
		{
			return;
		}
		if (a + b <= int_0)
		{
			Algorithm.Merge(src, p1, a, src, p2, b, dst, p3, comparer);
			return;
		}
		int int_5 = p1 / 2 + r1 / 2 + (p1 % 2 + r1 % 2) / 2;
		int int_6 = Algorithm.BinarySearch(src[int_5], src, p2, r2, comparer);
		int int_7 = p3 + (int_5 - p1) + (int_6 - p2);
		dst[int_7] = src[int_5];
		Parallel.Invoke(delegate
		{
			MergeInnerPar(src, p1, int_5 - 1, p2, int_6 - 1, dst, p3, comparer);
		}, delegate
		{
			MergeInnerPar(src, int_5 + 1, r1, int_6, r2, dst, int_7 + 1, comparer);
		});
	}

	internal static void MergeInnerParNew<T>(T[] src, int p1, int r1, int p2, int r2, T[] dst, int p3, IComparer<T> comparer = null)
	{
		int a = r1 - p1 + 1;
		int b = r2 - p2 + 1;
		if (a < b)
		{
			Algorithm.Swap(ref p1, ref p2);
			Algorithm.Swap(ref r1, ref r2);
			Algorithm.Swap(ref a, ref b);
		}
		if (a == 0)
		{
			return;
		}
		if (a + b <= int_0)
		{
			Algorithm.MergeWithCopy(src, p1, a, src, p2, b, dst, p3, comparer);
			return;
		}
		int int_4 = p1 / 2 + r1 / 2 + (p1 % 2 + r1 % 2) / 2;
		int int_5 = Algorithm.BinarySearch(src[int_4], src, p2, r2, comparer);
		int int_6 = p3 + (int_4 - p1) + (int_5 - p2);
		dst[int_6] = src[int_4];
		Parallel.Invoke(delegate
		{
			MergeInnerPar(src, p1, int_4 - 1, p2, int_5 - 1, dst, p3, comparer);
		}, delegate
		{
			MergeInnerPar(src, int_4 + 1, r1, int_5, r2, dst, int_6 + 1, comparer);
		});
	}

	internal static void MergeInnerFasterPar<T>(T[] src, int p1, int r1, int p2, int r2, T[] dst, int p3, IComparer<T> comparer = null, int mergeParallelThreshold = 131072)
	{
		int a = r1 - p1 + 1;
		int b = r2 - p2 + 1;
		if (a < b)
		{
			Algorithm.Swap(ref p1, ref p2);
			Algorithm.Swap(ref r1, ref r2);
			Algorithm.Swap(ref a, ref b);
		}
		if (a == 0)
		{
			return;
		}
		if (a + b <= mergeParallelThreshold)
		{
			Algorithm.MergeFaster(src, p1, a, src, p2, b, dst, p3, comparer);
			return;
		}
		int int_5 = p1 / 2 + r1 / 2 + (p1 % 2 + r1 % 2) / 2;
		int int_6 = Algorithm.BinarySearch(src[int_5], src, p2, r2, comparer);
		int int_7 = p3 + (int_5 - p1) + (int_6 - p2);
		dst[int_7] = src[int_5];
		Parallel.Invoke(delegate
		{
			MergeInnerFasterPar(src, p1, int_5 - 1, p2, int_6 - 1, dst, p3, comparer, mergeParallelThreshold);
		}, delegate
		{
			MergeInnerFasterPar(src, int_5 + 1, r1, int_6, r2, dst, int_7 + 1, comparer, mergeParallelThreshold);
		});
	}

	public static void MergePar<T>(T[] src, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		MergeInnerPar(src, aStart, aStart + aLength - 1, bStart, bStart + bLength - 1, dst, dstStart, comparer);
	}

	public static void MergeParNew<T>(T[] src, int aStart, int aLength, int bStart, int bLength, T[] dst, int dstStart, IComparer<T> comparer = null)
	{
		MergeInnerParNew(src, aStart, aStart + aLength - 1, bStart, bStart + bLength - 1, dst, dstStart, comparer);
	}

	internal static void MergeInnerPar<T1, T2>(T1[] srcKeys, T2[] srcItems, int p1, int r1, int p2, int r2, T1[] dstKeys, T2[] dstItems, int p3, IComparer<T1> comparer = null)
	{
		int a = r1 - p1 + 1;
		int b = r2 - p2 + 1;
		if (a < b)
		{
			Algorithm.Swap(ref p1, ref p2);
			Algorithm.Swap(ref r1, ref r2);
			Algorithm.Swap(ref a, ref b);
		}
		if (a == 0)
		{
			return;
		}
		if (a + b <= int_0)
		{
			Algorithm.Merge(srcKeys, srcItems, p1, a, srcKeys, srcItems, p2, b, dstKeys, dstItems, p3, comparer);
			return;
		}
		int int_5 = p1 / 2 + r1 / 2 + (p1 % 2 + r1 % 2) / 2;
		int int_6 = Algorithm.BinarySearch(srcKeys[int_5], srcKeys, p2, r2, comparer);
		int int_7 = p3 + (int_5 - p1) + (int_6 - p2);
		dstKeys[int_7] = srcKeys[int_5];
		dstItems[int_7] = srcItems[int_5];
		Parallel.Invoke(delegate
		{
			MergeInnerPar(srcKeys, srcItems, p1, int_5 - 1, p2, int_6 - 1, dstKeys, dstItems, p3, comparer);
		}, delegate
		{
			MergeInnerPar(srcKeys, srcItems, int_5 + 1, r1, int_6, r2, dstKeys, dstItems, int_7 + 1, comparer);
		});
	}

	public static void MergeDivideAndConquerInPlacePar<T>(T[] arr, int startIndex, int midIndex, int endIndex, IComparer<T> comparer = null, int threshold0 = 16384, int threshold1 = 16384)
	{
		int num = midIndex - startIndex + 1;
		int num2 = endIndex - midIndex;
		if (num >= num2)
		{
			if (num2 <= 0)
			{
				return;
			}
			int int_0 = startIndex / 2 + midIndex / 2 + (startIndex % 2 + midIndex % 2) / 2;
			int int_2 = Algorithm.BinarySearch(arr[int_0], arr, midIndex + 1, endIndex, comparer);
			int int_3 = int_0 + (int_2 - midIndex - 1);
			Algorithm.BlockSwapGriesMills(arr, int_0, midIndex, int_2 - 1);
			if (num < threshold1)
			{
				MergeDivideAndConquerInPlacePar(arr, startIndex, int_0 - 1, int_3 - 1, comparer);
				MergeDivideAndConquerInPlacePar(arr, int_3 + 1, int_2 - 1, endIndex, comparer);
				return;
			}
			Parallel.Invoke(delegate
			{
				MergeDivideAndConquerInPlacePar(arr, startIndex, int_0 - 1, int_3 - 1, comparer);
			}, delegate
			{
				MergeDivideAndConquerInPlacePar(arr, int_3 + 1, int_2 - 1, endIndex, comparer);
			});
		}
		else
		{
			if (num <= 0)
			{
				return;
			}
			int int_4 = (midIndex + 1) / 2 + endIndex / 2 + ((midIndex + 1) % 2 + endIndex % 2) / 2;
			int int_5 = Algorithm.BinarySearch(arr[int_4], arr, startIndex, midIndex, comparer);
			int int_6 = int_5 + (int_4 - midIndex - 1);
			Algorithm.BlockSwapGriesMills(arr, int_5, midIndex, int_4);
			if (num < threshold1)
			{
				MergeDivideAndConquerInPlacePar(arr, startIndex, int_5 - 1, int_6 - 1, comparer);
				MergeDivideAndConquerInPlacePar(arr, int_6 + 1, int_4, endIndex, comparer);
				return;
			}
			Parallel.Invoke(delegate
			{
				MergeDivideAndConquerInPlacePar(arr, startIndex, int_5 - 1, int_6 - 1, comparer);
			}, delegate
			{
				MergeDivideAndConquerInPlacePar(arr, int_6 + 1, int_4, endIndex, comparer);
			});
		}
	}

	public static void MergeInPlaceAdaptivePar<T>(T[] arr, int startIndex, int midIndex, int endIndex, IComparer<T> comparer = null, int threshold = 16384)
	{
		if (endIndex - startIndex < threshold)
		{
			Algorithm.MergeInPlaceDivideAndConquer(arr, startIndex, midIndex, endIndex, comparer);
			return;
		}
		try
		{
			T[] array = new T[arr.Length];
			MergeInnerPar(arr, startIndex, midIndex, midIndex + 1, endIndex, array, startIndex, comparer);
			Array.Copy(array, startIndex, arr, startIndex, endIndex - startIndex + 1);
		}
		catch (OutOfMemoryException)
		{
			Algorithm.MergeInPlaceDivideAndConquer(arr, startIndex, midIndex, endIndex, comparer);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private static int smethod_18()
	{
		return int_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_19(int int_7)
	{
		int_1 = int_7;
	}

	public static List<T> MergePar<T>(List<T> src, int aStart, int aLength, int bStart, int bLength, int dstStart, Comparer<T> comparer = null)
	{
		T[] src2 = Copy.ToArrayPar(src);
		T[] array = new T[src.Count];
		MergePar(src2, aStart, aLength, bStart, bLength, array, dstStart, comparer);
		return new List<T>(array);
	}

	public static void MergePar<T>(T[] sourceArray, List<SortedSpan> sourceSpans, T[] destinationArray, Comparer<T> comparer = null)
	{
		if (destinationArray.Length != sourceArray.Length)
		{
			throw new ArgumentException("Destination array must be the same size as the source array");
		}
		if (sourceSpans == null || sourceSpans.Count == 0)
		{
			return;
		}
		bool flag = true;
		while (true)
		{
			if (sourceSpans.Count >= 1)
			{
				if (sourceSpans.Count == 1)
				{
					break;
				}
				List<SortedSpan> list = new List<SortedSpan>();
				int num = 0;
				int num2 = sourceSpans.Count / 2;
				for (int i = 0; i < num2; i++)
				{
					MergePar(sourceArray, sourceSpans[num].Start, sourceSpans[num].Length, sourceSpans[num + 1].Start, sourceSpans[num + 1].Length, destinationArray, sourceSpans[num].Start, comparer);
					list.Add(new SortedSpan
					{
						Start = sourceSpans[num].Start,
						Length = sourceSpans[num].Length + sourceSpans[num + 1].Length
					});
					num += 2;
				}
				if (num == sourceSpans.Count - 1)
				{
					Array.Copy(sourceArray, sourceSpans[num].Start, destinationArray, sourceSpans[num].Start, sourceSpans[num].Length);
					list.Add(new SortedSpan
					{
						Start = sourceSpans[num].Start,
						Length = sourceSpans[num].Length
					});
				}
				sourceSpans = list;
				T[] array = sourceArray;
				sourceArray = destinationArray;
				destinationArray = array;
				flag = !flag;
				continue;
			}
			return;
		}
		if (flag)
		{
			Array.Copy(sourceArray, sourceSpans[0].Start, destinationArray, sourceSpans[0].Start, sourceSpans[0].Length);
		}
	}

	private static void smethod_20<T>(this object object_0, int int_7, int int_8, object object_1, bool bool_0 = true, IComparer<T> icomparer_0 = null, int int_9 = 24576, int int_10 = 131072)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_8 < int_7)
		{
			return;
		}
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				gparam_1[int_7] = gparam_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				Array.Copy(gparam_0, int_7, gparam_1, int_7, int_8 - int_7 + 1);
			}
			return;
		}
		if (int_8 - int_7 <= int_9)
		{
			Array.Sort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				Array.Copy(gparam_0, int_7, gparam_1, int_7, int_8 - int_7 + 1);
			}
			return;
		}
		int int_11 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_20(int_7, int_11, gparam_1, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_20(int_11 + 1, int_8, gparam_1, !bool_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			MergeInnerFasterPar(gparam_0, int_7, int_11, int_11 + 1, int_8, gparam_1, int_7, icomparer_0, int_10);
		}
		else
		{
			MergeInnerFasterPar(gparam_1, int_7, int_11, int_11 + 1, int_8, gparam_0, int_7, icomparer_0, int_10);
		}
	}

	private static void smethod_21<T>(this object object_0, int int_7, int int_8, object object_1, bool bool_0 = true, IComparer<T> icomparer_0 = null, int int_9 = 24576, int int_10 = 131072)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				gparam_1[int_7] = gparam_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				Array.Copy(gparam_0, int_7, gparam_1, int_7, int_8 - int_7 + 1);
			}
			return;
		}
		if (int_8 - int_7 <= int_9)
		{
			Array.Sort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				Array.Copy(gparam_0, int_7, gparam_1, int_7, int_8 - int_7 + 1);
			}
			return;
		}
		int int_11 = (int_7 + int_8) / 2;
		int int_12 = (int_7 + int_11) / 2;
		int int_13 = (int_11 + int_8) / 2;
		int aLength = int_12 - int_7 + 1;
		int bLength = int_11 - (int_12 + 1) + 1;
		int cLength = int_13 - (int_11 + 1) + 1;
		int dLength = int_8 - (int_13 + 1) + 1;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_21(int_7, int_12, gparam_1, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_21(int_12 + 1, int_11, gparam_1, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_21(int_11 + 1, int_13, gparam_1, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_21(int_13 + 1, int_8, gparam_1, !bool_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			Algorithm.MergeFourWay2(gparam_0, int_7, aLength, int_12 + 1, bLength, int_11 + 1, cLength, int_13 + 1, dLength, gparam_1, int_7, icomparer_0);
		}
		else
		{
			Algorithm.MergeFourWay2(gparam_1, int_7, aLength, int_12 + 1, bLength, int_11 + 1, cLength, int_13 + 1, dLength, gparam_0, int_7, icomparer_0);
		}
	}

	private static void smethod_22<T>(this object object_0, int int_7, object object_1, int int_8, int int_9, IComparer<T> icomparer_0 = null, int int_10 = 0)
	{
		T[] gparam_0 = (T[])object_0;
		if (int_9 <= 0)
		{
			return;
		}
		if (int_9 <= gparam_0.Length - int_7 && int_9 <= ((Array)object_1).Length - int_8)
		{
			int num = ((int_10 <= 0) ? Misc.Environment_ProcessorCount : int_10);
			int int_11 = int_9 / num;
			List<Action> list = new List<Action>();
			int i;
			for (i = 0; i < num - 1; i++)
			{
				list.Add(delegate
				{
					Array.Sort(gparam_0, int_11 * i, int_11, icomparer_0);
				});
			}
			list.Add(delegate
			{
				Array.Sort(gparam_0, int_11 * i, int_9 - int_11 * i, icomparer_0);
			});
			Parallel.Invoke(list.ToArray());
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	private static void smethod_23<T, U>(this object object_0, object object_1, int int_7, int int_8, object object_2, object object_3, bool bool_0 = true, IComparer<T> icomparer_0 = null, int int_9 = 24576)
	{
		T[] gparam_0 = (T[])object_0;
		U[] gparam_1 = (U[])object_1;
		T[] gparam_2 = (T[])object_2;
		U[] gparam_3 = (U[])object_3;
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				gparam_2[int_7] = gparam_0[int_7];
				gparam_3[int_7] = gparam_1[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, gparam_1, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				for (int i = int_7; i <= int_8; i++)
				{
					gparam_2[i] = gparam_0[i];
					gparam_3[i] = gparam_1[i];
				}
			}
			return;
		}
		if (int_8 - int_7 <= int_9)
		{
			Array.Sort(gparam_0, gparam_1, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				for (int j = int_7; j <= int_8; j++)
				{
					gparam_2[j] = gparam_0[j];
					gparam_3[j] = gparam_1[j];
				}
			}
			return;
		}
		int int_10 = (int_8 + int_7) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_23<T, U>(gparam_1, int_7, int_10, gparam_2, gparam_3, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_23<T, U>(gparam_1, int_10 + 1, int_8, gparam_2, gparam_3, !bool_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			MergeInnerPar(gparam_0, gparam_1, int_7, int_10, int_10 + 1, int_8, gparam_2, gparam_3, int_7, icomparer_0);
		}
		else
		{
			MergeInnerPar(gparam_2, gparam_3, int_7, int_10, int_10 + 1, int_8, gparam_0, gparam_1, int_7, icomparer_0);
		}
	}

	private static void smethod_24<T>(this object object_0, int int_7, int int_8, object object_1, bool bool_0 = true, IComparer<T> icomparer_0 = null, int int_9 = 8192)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				gparam_1[int_7] = gparam_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				for (int i = int_7; i <= int_8; i++)
				{
					gparam_1[i] = gparam_0[i];
				}
			}
			return;
		}
		if (int_8 - int_7 <= int_9)
		{
			Algorithm.SortMergeInner(gparam_0, int_7, int_8, gparam_1, bool_0, icomparer_0);
			return;
		}
		int int_10 = (int_8 + int_7) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_24(int_7, int_10, gparam_1, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_24(int_10 + 1, int_8, gparam_1, !bool_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			Algorithm.Merge(gparam_0, int_7, int_10 - int_7 + 1, int_10 + 1, int_8 - int_10, gparam_1, int_7, icomparer_0);
		}
		else
		{
			Algorithm.Merge(gparam_1, int_7, int_10 - int_7 + 1, int_10 + 1, int_8 - int_10, gparam_0, int_7, icomparer_0);
		}
	}

	public static T[] SortMergePar<T>(this T[] src, IComparer<T> comparer = null, int parallelThreshold = 24576, int parallelMergeThreshold = 131072)
	{
		T[] array = new T[src.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		if (parallelMergeThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelMergeThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_20(0, src.Length - 1, array, bool_0: true, comparer, parallelThreshold, parallelMergeThreshold);
		return array;
	}

	public static T[] SortMergePar<T>(this T[] src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 24576, int parallelMergeThreshold = 131072)
	{
		T[] array = new T[length];
		T[] array2 = new T[length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		if (parallelMergeThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelMergeThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		Array.Copy(src, startIndex, array, 0, length);
		array.smethod_20(0, length - 1, array2, bool_0: true, comparer, parallelThreshold, parallelMergeThreshold);
		return array2;
	}

	public static T[] SortMergeFourWayPar<T>(this T[] src, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = new T[src.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_21(0, src.Length - 1, array, bool_0: true, comparer, parallelThreshold);
		return array;
	}

	public static T[] SortMergeStablePar<T>(this T[] src, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = new T[src.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_24(0, src.Length - 1, array, bool_0: true, comparer, parallelThreshold);
		return array;
	}

	public static T[] SortMergeStablePar<T>(this T[] src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] array = new T[length];
		T[] array2 = new T[length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		Array.Copy(src, startIndex, array, 0, length);
		array.smethod_24(0, length - 1, array2, bool_0: true, comparer, parallelThreshold);
		return array2;
	}

	public static void SortMergeInPlaceAdaptivePar<T>(this T[] src, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		try
		{
			T[] object_ = new T[src.Length];
			if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
			{
				parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
			}
			src.smethod_20(0, src.Length - 1, object_, bool_0: false, comparer, parallelThreshold);
		}
		catch (OutOfMemoryException)
		{
			src.smethod_25(0, src.Length - 1, comparer, parallelThreshold);
		}
	}

	public static void SortMergeInPlaceAdaptivePar<T>(this T[] src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		try
		{
			T[] object_ = new T[src.Length];
			if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
			{
				parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
			}
			src.smethod_20(startIndex, startIndex + length - 1, object_, bool_0: false, comparer, parallelThreshold);
		}
		catch (OutOfMemoryException)
		{
			src.smethod_25(startIndex, startIndex + length - 1, comparer, parallelThreshold);
		}
	}

	public static void SortMergeInPlacePar<T>(this T[] src, IComparer<T> comparer = null, int parallelThreshold = 16384)
	{
		src.smethod_25(0, src.Length - 1, comparer, parallelThreshold);
	}

	public static void SortMergeInPlacePar<T>(this T[] src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 16384)
	{
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_25(startIndex, startIndex + length - 1, comparer, parallelThreshold);
	}

	private static void smethod_25<T>(this object object_0, int int_7, int int_8, IComparer<T> icomparer_0 = null, int int_9 = 16384, int int_10 = 262144, int int_11 = 262144)
	{
		T[] gparam_0 = (T[])object_0;
		int num = int_8 - int_7 + 1;
		if (num <= 1)
		{
			return;
		}
		if (num <= int_9)
		{
			Array.Sort(gparam_0, int_7, num, icomparer_0);
			return;
		}
		int int_12 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_25(int_7, int_12, icomparer_0, int_9, int_10, int_11);
		}, delegate
		{
			gparam_0.smethod_25(int_12 + 1, int_8, icomparer_0, int_9, int_10, int_11);
		});
		MergeDivideAndConquerInPlacePar(gparam_0, int_7, int_12, int_8, icomparer_0, int_10, int_11);
	}

	public static void SortMergePseudoInPlacePar<T1, T2>(this T1[] keys, T2[] items, IComparer<T1> comparer = null, int parallelThreshold = 24576)
	{
		T1[] object_ = new T1[keys.Length];
		T2[] object_2 = new T2[items.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < items.Length)
		{
			parallelThreshold = items.Length / Misc.Environment_ProcessorCount;
		}
		keys.smethod_23<T1, T2>(items, 0, keys.Length - 1, object_, object_2, bool_0: false, comparer, parallelThreshold);
	}

	public static void SortMergePseudoInPlacePar<T1, T2>(this T1[] keys, T2[] items, int startIndex, int length, IComparer<T1> comparer = null, int parallelThreshold = 24576)
	{
		T1[] object_ = new T1[keys.Length];
		T2[] object_2 = new T2[items.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < items.Length)
		{
			parallelThreshold = items.Length / Misc.Environment_ProcessorCount;
		}
		keys.smethod_23<T1, T2>(items, startIndex, startIndex + length - 1, object_, object_2, bool_0: false, comparer, parallelThreshold);
	}

	public static void SortMergePseudoInPlaceStablePar<T>(this T[] array, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] object_ = new T[array.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < array.Length)
		{
			parallelThreshold = array.Length / Misc.Environment_ProcessorCount;
		}
		array.smethod_24(0, array.Length - 1, object_, bool_0: false, comparer, parallelThreshold);
	}

	public static void SortMergePseudoInPlaceStablePar<T>(this T[] array, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] object_ = new T[array.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < array.Length)
		{
			parallelThreshold = array.Length / Misc.Environment_ProcessorCount;
		}
		array.smethod_24(startIndex, startIndex + length - 1, object_, bool_0: false, comparer, parallelThreshold);
	}

	public static List<T> SortMergePseudoInPlacePar<T>(this List<T> src, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = Copy.ToArrayPar(src);
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Count)
		{
			parallelThreshold = src.Count / Misc.Environment_ProcessorCount;
		}
		SortMergePar(array, comparer, parallelThreshold);
		return new List<T>(array);
	}

	public static List<T> SortMergePseudoInPlaceStablePar<T>(this List<T> src, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] array = Copy.ToArrayPar(src);
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Count)
		{
			parallelThreshold = src.Count / Misc.Environment_ProcessorCount;
		}
		SortMergeStablePar(array, comparer, parallelThreshold);
		return new List<T>(array);
	}

	public static List<T> SortMergePseudoInPlacePar<T>(this List<T> src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = Copy.ToArrayPar(src, startIndex, length);
		T[] array2 = new T[array.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Count)
		{
			parallelThreshold = src.Count / Misc.Environment_ProcessorCount;
		}
		array.smethod_20(0, length - 1, array2, bool_0: true, comparer, parallelThreshold);
		return new List<T>(array2);
	}

	public static List<T> SortMergePseudoInPlaceStablePar<T>(this List<T> src, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] array = Copy.ToArrayPar(src, startIndex, length);
		T[] array2 = new T[array.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Count)
		{
			parallelThreshold = src.Count / Misc.Environment_ProcessorCount;
		}
		array.smethod_24(0, length - 1, array2, bool_0: true, comparer, parallelThreshold);
		return new List<T>(array2);
	}

	public static void SortMergePseudoInPlaceAdaptivePar<T>(ref List<T> list, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = Copy.ToArrayPar(list);
		if (parallelThreshold * Misc.Environment_ProcessorCount < list.Count)
		{
			parallelThreshold = list.Count / Misc.Environment_ProcessorCount;
		}
		SortMergeInPlaceAdaptivePar(array, startIndex, length, comparer, parallelThreshold);
		list = new List<T>(array);
	}

	public static void SortMergePseudoInPlaceStablePar<T>(ref List<T> list, int startIndex, int length, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] array = Copy.ToArrayPar(list);
		if (parallelThreshold * Misc.Environment_ProcessorCount < list.Count)
		{
			parallelThreshold = list.Count / Misc.Environment_ProcessorCount;
		}
		SortMergePseudoInPlaceStablePar(array, startIndex, length, comparer, parallelThreshold);
		list = new List<T>(array);
	}

	public static void SortMergePseudoInPlacePar<T>(ref List<T> list, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = Copy.ToArrayPar(list);
		if (parallelThreshold * Misc.Environment_ProcessorCount < list.Count)
		{
			parallelThreshold = list.Count / Misc.Environment_ProcessorCount;
		}
		SortMergeInPlaceAdaptivePar(array, comparer, parallelThreshold);
		list = new List<T>(array);
	}

	public static void SortMergePseudoInPlaceStablePar<T>(ref List<T> list, IComparer<T> comparer = null, int parallelThreshold = 8192)
	{
		T[] array = Copy.ToArrayPar(list);
		if (parallelThreshold * Misc.Environment_ProcessorCount < list.Count)
		{
			parallelThreshold = list.Count / Misc.Environment_ProcessorCount;
		}
		SortMergePseudoInPlaceStablePar(array, comparer);
		list = new List<T>(array);
	}

	private static void smethod_26<T>(this object object_0, int int_7, int int_8, object object_1, bool bool_0, Func<T, uint> func_0, IComparer<T> icomparer_0 = null, int int_9 = 24576)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				gparam_1[int_7] = gparam_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				for (int i = int_7; i <= int_8; i++)
				{
					gparam_1[i] = gparam_0[i];
				}
			}
			return;
		}
		if (int_8 - int_7 <= int_9 && bool_0)
		{
			Algorithm.SortRadix(gparam_0, int_7, int_8 - int_7 + 1, gparam_1, func_0);
			return;
		}
		int int_10 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_26(int_7, int_10, gparam_1, !bool_0, func_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_26(int_10 + 1, int_8, gparam_1, !bool_0, func_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			MergeInnerPar(gparam_1, int_7, int_10, int_10 + 1, int_8, gparam_0, int_7, icomparer_0);
		}
		else
		{
			MergeInnerPar(gparam_0, int_7, int_10, int_10 + 1, int_8, gparam_1, int_7, icomparer_0);
		}
	}

	private static void smethod_27(this uint[] uint_0, int int_7, int int_8, uint[] uint_1, bool bool_0, int int_9 = 24576)
	{
		if (int_8 < int_7)
		{
			return;
		}
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				uint_1[int_7] = uint_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 > int_2)
		{
			if (int_8 - int_7 > int_9)
			{
				int int_10 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
				Parallel.Invoke(delegate
				{
					uint_0.smethod_27(int_7, int_10, uint_1, !bool_0, int_9);
				}, delegate
				{
					uint_0.smethod_27(int_10 + 1, int_8, uint_1, !bool_0, int_9);
				});
				if (!bool_0)
				{
					MergeInnerPar(uint_1, int_7, int_10, int_10 + 1, int_8, uint_0, int_7);
				}
				else
				{
					MergeInnerPar(uint_0, int_7, int_10, int_10 + 1, int_8, uint_1, int_7);
				}
				return;
			}
			Algorithm.SortRadixDerandomizeWrites(uint_0, int_7, int_8 - int_7 + 1);
			if (bool_0)
			{
				for (int num = int_7; num <= int_8; num++)
				{
					uint_1[num] = uint_0[num];
				}
			}
			return;
		}
		Algorithm.InsertionSort(uint_0, int_7, int_8 - int_7 + 1);
		if (bool_0)
		{
			for (int num2 = int_7; num2 <= int_8; num2++)
			{
				uint_1[num2] = uint_0[num2];
			}
		}
	}

	private static void smethod_28<T>(this object object_0, int int_7, int int_8, object object_1, bool bool_0, IComparer<T> icomparer_0 = null, int int_9 = 24576)
	{
		T[] gparam_0 = (T[])object_0;
		T[] KiLeUwhixjx = (T[])object_1;
		if (int_8 == int_7)
		{
			if (bool_0)
			{
				KiLeUwhixjx[int_7] = gparam_0[int_7];
			}
			return;
		}
		if (int_8 - int_7 <= int_2)
		{
			Algorithm.InsertionSort(gparam_0, int_7, int_8 - int_7 + 1, icomparer_0);
			if (bool_0)
			{
				for (int i = int_7; i <= int_8; i++)
				{
					KiLeUwhixjx[i] = gparam_0[i];
				}
			}
			return;
		}
		int int_10 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_28(int_7, int_10, KiLeUwhixjx, !bool_0, icomparer_0, int_9);
		}, delegate
		{
			gparam_0.smethod_28(int_10 + 1, int_8, KiLeUwhixjx, !bool_0, icomparer_0, int_9);
		});
		if (bool_0)
		{
			MergeInnerPar(gparam_0, int_7, int_10, int_10 + 1, int_8, KiLeUwhixjx, int_7, icomparer_0);
		}
		else
		{
			MergeInnerPar(KiLeUwhixjx, int_7, int_10, int_10 + 1, int_8, gparam_0, int_7, icomparer_0);
		}
	}

	public static void SortMergePseudoInPlaceHybridWithRadixPar<T>(this T[] src, Func<T, uint> getKey, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] object_ = new T[src.Length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_26(0, src.Length - 1, object_, bool_0: true, getKey, comparer, parallelThreshold);
	}

	public static T[] SortMergePseudoInPlaceHybridWithRadixPar<T>(this T[] src, int startIndex, int length, Func<T, uint> getKey, IComparer<T> comparer = null, int parallelThreshold = 24576)
	{
		T[] array = new T[length];
		T[] object_ = new T[length];
		if (parallelThreshold * Misc.Environment_ProcessorCount < src.Length)
		{
			parallelThreshold = src.Length / Misc.Environment_ProcessorCount;
		}
		Array.Copy(src, startIndex, array, 0, length);
		array.smethod_26(0, length - 1, object_, bool_0: true, getKey, comparer, parallelThreshold);
		return array;
	}

	public static void SortMergePseudoInPlaceHybridWithRadixPar(this uint[] src, int parallelThreshold = 24576)
	{
		uint[] uint_ = new uint[src.Length];
		src.smethod_27(0, src.Length - 1, uint_, bool_0: false, parallelThreshold);
	}

	private static void smethod_29(this ulong[] ulong_0, int int_7, int int_8, int int_9 = 24576, int int_10 = 16384, int int_11 = 16384)
	{
		if (int_8 == int_7)
		{
			return;
		}
		if (int_8 - int_7 > int_9)
		{
			int int_12 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
			Parallel.Invoke(delegate
			{
				ulong_0.smethod_29(int_7, int_12, int_9, int_10, int_11);
			}, delegate
			{
				ulong_0.smethod_29(int_12 + 1, int_8, int_9, int_10, int_11);
			});
			MergeDivideAndConquerInPlacePar(ulong_0, int_7, int_12, int_8, null, int_10, int_11);
		}
		else
		{
			Algorithm.SortRadixMsd(ulong_0, int_7, int_8 - int_7 + 1);
		}
	}

	public static void SortMergeInPlaceHybridWithRadixPar(this ulong[] src, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		src.smethod_29(0, src.Length - 1, threshold0, threshold1, threshold2);
	}

	public static void SortMergeInPlaceHybridWithRadixPar(this ulong[] src, int startIndex, int length, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		src.smethod_29(startIndex, startIndex + length - 1, threshold0, threshold1, threshold2);
	}

	private static void smethod_30(this uint[] uint_0, int int_7, int int_8, int int_9 = 24576, int int_10 = 16384, int int_11 = 16384)
	{
		if (int_8 == int_7)
		{
			return;
		}
		if (int_8 - int_7 > int_9)
		{
			int int_12 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
			Parallel.Invoke(delegate
			{
				uint_0.smethod_30(int_7, int_12, int_9, int_10, int_11);
			}, delegate
			{
				uint_0.smethod_30(int_12 + 1, int_8, int_9, int_10, int_11);
			});
			MergeInPlaceAdaptivePar(uint_0, int_7, int_12, int_8, null, int_10);
		}
		else
		{
			Algorithm.SortRadixMsd(uint_0, int_7, int_8 - int_7 + 1);
		}
	}

	public static void SortMergeInPlaceHybridWithRadixPar(this uint[] src, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		if (threshold0 * Misc.Environment_ProcessorCount < src.Length)
		{
			threshold0 = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_30(0, src.Length - 1, threshold0, threshold1, threshold2);
	}

	public static void SortMergeInPlaceHybridWithRadixPar(this uint[] src, int startIndex, int length, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		if (threshold0 * Misc.Environment_ProcessorCount < src.Length)
		{
			threshold0 = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_30(startIndex, startIndex + length - 1, threshold0, threshold1, threshold2);
	}

	private static void smethod_31(this uint[] uint_0, int int_7, int int_8, int int_9 = 24576, int int_10 = 16384, int int_11 = 16384)
	{
		if (int_8 == int_7)
		{
			return;
		}
		if (int_8 - int_7 <= int_9)
		{
			Algorithm.SortRadixInPlaceAdaptive(uint_0, int_7, int_8 - int_7 + 1);
			return;
		}
		int int_12 = int_8 / 2 + int_7 / 2 + (int_8 % 2 + int_7 % 2) / 2;
		Parallel.Invoke(delegate
		{
			uint_0.smethod_31(int_7, int_12, int_9, int_10, int_11);
		}, delegate
		{
			uint_0.smethod_31(int_12 + 1, int_8, int_9, int_10, int_11);
		});
		MergeInPlaceAdaptivePar(uint_0, int_7, int_12, int_8, null, int_10);
	}

	public static void SortMergeInPlaceAdaptiveHybridWithRadixPar(this uint[] src, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		if (threshold0 * Misc.Environment_ProcessorCount < src.Length)
		{
			threshold0 = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_31(0, src.Length - 1, threshold0, threshold1, threshold2);
	}

	public static void SortMergeInPlaceAdaptiveHybridWithRadixPar(this uint[] src, int startIndex, int length, int threshold0 = 24576, int threshold1 = 16384, int threshold2 = 16384)
	{
		if (threshold0 * Misc.Environment_ProcessorCount < src.Length)
		{
			threshold0 = src.Length / Misc.Environment_ProcessorCount;
		}
		src.smethod_31(startIndex, startIndex + length - 1, threshold0, threshold1, threshold2);
	}

	public static int MinSse(this int[] arrayToMin)
	{
		if (arrayToMin == null)
		{
			throw new ArgumentNullException("Min cannot be determined for a null array");
		}
		if (arrayToMin.Length == 0)
		{
			throw new ArgumentException("Min cannot be determined for an empty array");
		}
		return arrayToMin.smethod_32(0, arrayToMin.Length - 1);
	}

	public static int MinSse(this int[] arrayToMin, int start, int length)
	{
		if (arrayToMin != null)
		{
			if (arrayToMin.Length == 0 || length == 0)
			{
				throw new ArgumentException("Min cannot be determined for an empty array or length argument of zero");
			}
			return arrayToMin.smethod_32(start, start + length - 1);
		}
		throw new ArgumentNullException("Min cannot be determined for a null array");
	}

	private static int smethod_32(this object object_0, int int_7, int int_8)
	{
		Vector<int> left = default(Vector<int>);
		int num = int_7 + (int_8 - int_7 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i = int_7;
		if (i < num)
		{
			left = new Vector<int>((int[])object_0, i);
			i += Vector<int>.Count;
		}
		for (; i < num; i += Vector<int>.Count)
		{
			left = Vector.Min(right: new Vector<int>((int[])object_0, i), left: left);
		}
		int num2 = left[0];
		for (int j = 1; j < Vector<int>.Count; j++)
		{
			num2 = Math.Min(num2, left[j]);
		}
		for (; i <= int_8; i++)
		{
			num2 = Math.Min(num2, ((int[])object_0)[i]);
		}
		return num2;
	}

	private static int smethod_33(this int[] int_7, int int_8, int int_9)
	{
		if (int_9 - int_8 + 1 > int_3 && int_9 - int_8 + 1 > 2)
		{
			int int_10 = (int_9 + int_8) / 2;
			int int_11 = 0;
			int int_12 = 0;
			Parallel.Invoke(delegate
			{
				int_11 = int_7.smethod_33(int_8, int_10);
			}, delegate
			{
				int_12 = int_7.smethod_33(int_10 + 1, int_9);
			});
			return Math.Min(int_11, int_12);
		}
		return int_7.smethod_32(int_8, int_9 - int_8 + 1);
	}

	public static int MinSsePar(this int[] arrayToMin)
	{
		if (arrayToMin != null)
		{
			if (arrayToMin.Length == 0)
			{
				throw new ArgumentException("Min cannot be determined for an empty array");
			}
			return arrayToMin.smethod_33(0, arrayToMin.Length - 1);
		}
		throw new ArgumentNullException("Min cannot be determined for a null array");
	}

	public static int MinSsePar(this int[] arrayToMin, int start, int length)
	{
		if (arrayToMin != null)
		{
			if (arrayToMin.Length == 0 || length == 0)
			{
				throw new ArgumentException("Min cannot be determined for an empty array or length argument of zero");
			}
			return arrayToMin.smethod_33(start, start + length - 1);
		}
		throw new ArgumentNullException("Min cannot be determined for a null array");
	}

	private static void smethod_34<T>(this object object_0, int int_7, int int_8, IComparer<T> icomparer_0 = null)
	{
		T[] gparam_0 = (T[])object_0;
		if (int_8 - int_7 <= 4096)
		{
			Algorithm.QuicksortHoare(gparam_0, int_7, int_8, icomparer_0);
			return;
		}
		IComparer<T> comparer = icomparer_0 ?? Comparer<T>.Default;
		int num = int_7;
		int int_9 = int_8 - 1;
		T y = gparam_0[num + (int_9 - num) / 2];
		if (comparer.Compare(gparam_0[num], y) < 0)
		{
			while (comparer.Compare(gparam_0[++num], y) < 0)
			{
			}
		}
		if (comparer.Compare(gparam_0[int_9], y) > 0)
		{
			while (comparer.Compare(gparam_0[--int_9], y) > 0)
			{
			}
		}
		while (num < int_9)
		{
			T val = gparam_0[num];
			gparam_0[num] = gparam_0[int_9];
			gparam_0[int_9] = val;
			while (comparer.Compare(gparam_0[++num], y) < 0)
			{
			}
			while (comparer.Compare(gparam_0[--int_9], y) > 0)
			{
			}
		}
		int_9++;
		Parallel.Invoke(delegate
		{
			gparam_0.smethod_34(int_7, int_9, icomparer_0);
		}, delegate
		{
			gparam_0.smethod_34(int_9, int_8, icomparer_0);
		});
	}

	public static void QuicksortPar<T>(this T[] src, int aStart, int aLength, Comparer<T> comparer = null)
	{
		src.smethod_34(aStart, aStart + aLength, comparer);
	}

	public static void QuicksortPar<T>(this T[] src, Comparer<T> comparer = null)
	{
		src.smethod_34(0, src.Length, comparer);
	}

	private static void smethod_35(this uint[] uint_0, int int_7, int int_8)
	{
		if (int_8 - int_7 <= 4096)
		{
			Algorithm.QuicksortHoare(uint_0, int_7, int_8);
			return;
		}
		int num = int_7;
		int int_9 = int_8 - 1;
		uint num2 = uint_0[num + (int_9 - num) / 2];
		if (uint_0[num] < num2)
		{
			while (uint_0[++num] < num2)
			{
			}
		}
		if (uint_0[int_9] > num2)
		{
			while (uint_0[--int_9] > num2)
			{
			}
		}
		while (num < int_9)
		{
			uint num3 = uint_0[num];
			uint_0[num] = uint_0[int_9];
			uint_0[int_9] = num3;
			while (uint_0[++num] < num2)
			{
			}
			while (uint_0[--int_9] > num2)
			{
			}
		}
		int_9++;
		Parallel.Invoke(delegate
		{
			uint_0.smethod_35(int_7, int_9);
		}, delegate
		{
			uint_0.smethod_35(int_9, int_8);
		});
	}

	public static void QuicksortPar(this uint[] src, int aStart, int aLength)
	{
		src.smethod_35(aStart, aStart + aLength);
	}

	public static void QuicksortPar(this uint[] src)
	{
		src.smethod_35(0, src.Length);
	}

	public static byte[] SortRadixPar(this byte[] arrayToBeSorted)
	{
		return arrayToBeSorted.smethod_1();
	}

	public static ushort[] SortRadixPar(this ushort[] arrayToBeSorted)
	{
		return arrayToBeSorted.smethod_3();
	}

	public static uint[][] ComputeStartOfBinsPar(this uint[] inputArray, int workQuanta, uint numberOfQuantas, uint digit)
	{
		uint num = 256u;
		uint[][] array = HistogramByteComponentsQCPar(inputArray, 0, inputArray.Length - 1, workQuanta, numberOfQuantas, digit);
		uint[][] array2 = new uint[numberOfQuantas][];
		for (int i = 0; i < numberOfQuantas; i++)
		{
			array2[i] = new uint[num];
		}
		uint[] array3 = new uint[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			array3[num2] = 0u;
			for (int j = 0; j < numberOfQuantas; j++)
			{
				array3[num2] += array[j][num2];
			}
		}
		array2[0][0] = 0u;
		for (uint num3 = 1u; num3 < num; num3++)
		{
			array2[0][num3] = array2[0][num3 - 1] + array3[num3 - 1];
		}
		for (uint num4 = 1u; num4 < numberOfQuantas; num4++)
		{
			for (uint num5 = 0u; num5 < num; num5++)
			{
				array2[num4][num5] = array2[num4 - 1][num5] + array[num4 - 1][num5];
			}
		}
		return array2;
	}

	private static void smethod_36(object object_0, Array array_0, object object_1, object object_2, object object_3, object object_4, object object_5, uint uint_0, uint uint_1, int int_7)
	{
		if (object_5 == null)
		{
			return;
		}
		uint q = ((CustomData)object_5).q;
		uint[] array = (uint[])((object[])object_1)[q];
		uint[] array2 = (uint[])((object[])object_2)[q];
		uint[] array3 = (uint[])((object[])object_3)[q];
		for (uint num = ((CustomData)object_5).current; num < uint_0; num++)
		{
			uint num2 = (((uint[])object_0)[num] & ((CustomData)object_5).bitMask) >> ((CustomData)object_5).shiftRightAmount;
			if (array2[num2] < ((uint[])object_4)[num2])
			{
				array3[array2[num2]++] = ((uint[])object_0)[num];
				continue;
			}
			uint num3 = array[num2];
			uint num4 = num2 * uint_1;
			Array.Copy(array3, num4, array_0, num3, uint_1);
			array[num2] += uint_1;
			array3[num2 * uint_1] = ((uint[])object_0)[num];
			array2[num2] = num2 * uint_1 + 1;
		}
		for (uint num5 = 0u; num5 < int_7; num5++)
		{
			uint num6 = num5 * uint_1;
			uint num7 = array2[num5];
			while (num6 < num7)
			{
				((int[])array_0)[array[num5]++] = (int)array3[num6++];
			}
			array2[num5] = num5 * uint_1;
		}
	}

	public static uint[] SortRadixPar(this uint[] inputArray, int SortRadixParallelWorkQuanta = 65536)
	{
		int num = 8;
		uint[] uint_1 = new uint[inputArray.Length];
		bool flag = false;
		uint num2 = (uint)((inputArray.Length % SortRadixParallelWorkQuanta == 0) ? (inputArray.Length / SortRadixParallelWorkQuanta) : (inputArray.Length / SortRadixParallelWorkQuanta + 1));
		uint[][] uint_3 = new uint[num2][];
		for (int i = 0; i < num2; i++)
		{
			uint_3[i] = new uint[16384];
		}
		uint[][] uint_4 = new uint[num2][];
		for (int j = 0; j < num2; j++)
		{
			uint_4[j] = new uint[256];
			uint_4[j][0] = 0u;
			for (int k = 1; k < 256; k++)
			{
				uint_4[j][k] = uint_4[j][k - 1] + 64;
			}
		}
		uint[] uint_5 = new uint[256];
		uint_5[0] = 64u;
		for (int l = 1; l < 256; l++)
		{
			uint_5[l] = uint_5[l - 1] + 64;
		}
		if (inputArray.Length != 0)
		{
			uint num3 = 255u;
			int num4 = 0;
			uint num5 = 0u;
			while (num3 != 0)
			{
				uint[][] uint_6 = ComputeStartOfBinsPar(inputArray, SortRadixParallelWorkQuanta, num2, num5);
				uint num6 = (uint)(inputArray.Length / SortRadixParallelWorkQuanta);
				Task[] array = new Task[num2];
				uint num7;
				for (num7 = 0u; num7 < num6; num7++)
				{
					uint current = (uint)(num7 * SortRadixParallelWorkQuanta);
					array[num7] = Task.Factory.StartNew(delegate(object obj)
					{
						CustomData customData = obj as CustomData;
						uint uint_7 = (uint)(customData.current + SortRadixParallelWorkQuanta);
						smethod_36(inputArray, uint_1, uint_6, uint_4, uint_3, uint_5, customData, uint_7, 64u, 256);
					}, new CustomData
					{
						current = current,
						q = num7,
						bitMask = num3,
						shiftRightAmount = num4
					});
				}
				if (num2 > num6)
				{
					uint current2 = (uint)(num7 * SortRadixParallelWorkQuanta);
					array[num7] = Task.Factory.StartNew(delegate(object obj)
					{
						CustomData object_ = obj as CustomData;
						uint uint_7 = (uint)inputArray.Length;
						smethod_36(inputArray, uint_1, uint_6, uint_4, uint_3, uint_5, object_, uint_7, 64u, 256);
					}, new CustomData
					{
						current = current2,
						q = num7,
						bitMask = num3,
						shiftRightAmount = num4
					});
				}
				if (array.Length != 0)
				{
					Task.WaitAll(array);
				}
				num3 <<= num;
				num5++;
				num4 += num;
				flag = !flag;
				uint[] array2 = inputArray;
				inputArray = uint_1;
				uint_1 = array2;
			}
			if (flag)
			{
				for (uint num8 = 0u; num8 < inputArray.Length; num8++)
				{
					inputArray[num8] = uint_1[num8];
				}
			}
			return inputArray;
		}
		return uint_1;
	}

	public static void SortRadixInPlaceInterfacePar(this uint[] inputArray)
	{
		Array.Copy(SortRadixPar(inputArray), inputArray, inputArray.Length);
	}

	public static uint[] SortRadixPartialPar(this uint[] inputArray, int parallelThresholdHistogram = 16384)
	{
		int num = 256;
		int num2 = 4;
		int num3 = 8;
		int num4 = 0;
		uint[] array = new uint[inputArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		bool flag = false;
		uint num5 = 255u;
		int num6 = 0;
		if (parallelThresholdHistogram * Misc.Environment_ProcessorCount <= inputArray.Length)
		{
			parallelThresholdHistogram = inputArray.Length / Misc.Environment_ProcessorCount;
		}
		uint[][] array3 = HistogramByteComponentsPar(inputArray, 0, inputArray.Length - 1, parallelThresholdHistogram);
		for (num4 = 0; num4 < num2; num4++)
		{
			array2[num4][0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array2[num4][num7] = array2[num4][num7 - 1] + array3[num4][num7 - 1];
			}
		}
		num4 = 0;
		while (num5 != 0)
		{
			uint[] array4 = array2[num4];
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array4[(inputArray[num8] & num5) >> num6]++] = inputArray[num8];
			}
			num5 <<= num3;
			num6 += num3;
			flag = !flag;
			num4++;
			uint[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (flag)
		{
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				inputArray[num9] = array[num9];
			}
		}
		return inputArray;
	}

	public static uint[] SortRadixSsePar(this uint[] inputArray)
	{
		int num = 256;
		int num2 = 4;
		int num3 = 8;
		int num4 = 0;
		uint[] array = new uint[inputArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < num2; i++)
		{
			array2[i] = new uint[num];
		}
		bool flag = false;
		uint num5 = 255u;
		int num6 = 0;
		uint[][] array3 = HistogramByteComponentsSsePar(inputArray, 0, inputArray.Length - 1);
		for (num4 = 0; num4 < num2; num4++)
		{
			array2[num4][0] = 0u;
			for (uint num7 = 1u; num7 < num; num7++)
			{
				array2[num4][num7] = array2[num4][num7 - 1] + array3[num4][num7 - 1];
			}
		}
		num4 = 0;
		while (num5 != 0)
		{
			uint[] array4 = array2[num4];
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				array[array4[(inputArray[num8] & num5) >> num6]++] = inputArray[num8];
			}
			num5 <<= num3;
			num6 += num3;
			flag = !flag;
			num4++;
			uint[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (flag)
		{
			for (uint num9 = 0u; num9 < inputArray.Length; num9++)
			{
				inputArray[num9] = array[num9];
			}
		}
		return inputArray;
	}

	public static int[] SortRadixPar(this int[] inputArray)
	{
		int num = 0;
		int[] array = new int[inputArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponentsPar(inputArray, 0, inputArray.Length - 1);
		for (num = 0; num < 4L; num++)
		{
			array2[num][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[num][num3] = array2[num][num3 - 1] + array3[num][num3 - 1];
			}
		}
		num = 0;
		while (num < 4L)
		{
			uint[] array4 = array2[num];
			if (num != 3)
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
			num++;
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

	public static int[] SortRadixSsePar(this int[] inputArray)
	{
		int num = 0;
		int[] array = new int[inputArray.Length];
		uint[][] array2 = new uint[4][];
		for (int i = 0; i < 4L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponentsSsePar(inputArray, 0, inputArray.Length - 1);
		for (num = 0; num < 4L; num++)
		{
			array2[num][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[num][num3] = array2[num][num3 - 1] + array3[num][num3 - 1];
			}
		}
		num = 0;
		while (num < 4L)
		{
			uint[] array4 = array2[num];
			if (num != 3)
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
			num++;
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

	public static long[] SortRadixPar(this long[] inputArray)
	{
		int num = 0;
		long[] array = new long[inputArray.Length];
		uint[][] array2 = new uint[8][];
		for (int i = 0; i < 8L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponentsPar(inputArray, 0, inputArray.Length - 1);
		for (num = 0; num < 8L; num++)
		{
			array2[num][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[num][num3] = array2[num][num3 - 1] + array3[num][num3 - 1];
			}
		}
		num = 0;
		while (num < 8L)
		{
			uint[] array4 = array2[num];
			if (num != 7)
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
			num++;
			long[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (!flag)
		{
			return inputArray;
		}
		return array;
	}

	public static long[] SortRadixSsePar(this long[] inputArray)
	{
		int num = 0;
		long[] array = new long[inputArray.Length];
		uint[][] array2 = new uint[8][];
		for (int i = 0; i < 8L; i++)
		{
			array2[i] = new uint[256];
		}
		bool flag = false;
		int num2 = 0;
		uint[][] array3 = HistogramByteComponentsSsePar(inputArray, 0, inputArray.Length - 1);
		for (num = 0; num < 8L; num++)
		{
			array2[num][0] = 0u;
			for (uint num3 = 1u; num3 < 256; num3++)
			{
				array2[num][num3] = array2[num][num3 - 1] + array3[num][num3 - 1];
			}
		}
		num = 0;
		while (num < 8L)
		{
			uint[] array4 = array2[num];
			if (num != 7)
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
			num++;
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

	public static void SortRadixInPlaceInterfacePar(this long[] inputArray)
	{
		Array.Copy(SortRadixPar(inputArray), inputArray, inputArray.Length);
	}

	public static ulong[] SortRadixPar(this ulong[] inputArray)
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
		uint[][] array3 = HistogramByteComponentsPar(inputArray, 0, inputArray.Length - 1);
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

	public static void SortRadixInPlaceInterfacePar(this ulong[] inputArray)
	{
		Array.Copy(SortRadixPar(inputArray), inputArray, inputArray.Length);
	}

	public static void SortRadixMsdPar(this byte[] arrayToBeSorted)
	{
		arrayToBeSorted.smethod_0();
	}

	public static void SortRadixMsdPar(this ushort[] arrayToBeSorted)
	{
		arrayToBeSorted.smethod_2();
	}

	private static void smethod_37(long[] long_0, int int_7, int int_8, int int_9, Action<long[], int, int> action_0)
	{
		int num = int_7 + int_8 - 1;
		int[] array = smethod_15(long_0, int_7, num, int_9);
		int[] array2 = new int[257];
		int[] array3 = new int[256];
		int i = 1;
		array2[0] = (array3[0] = int_7);
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
			if (int_9 <= 0)
			{
				return;
			}
			int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
			if (int_8 < int_4)
			{
				if (int_8 >= 2)
				{
					action_0(long_0, int_7, int_8);
				}
			}
			else
			{
				smethod_37(long_0, int_7, int_8, int_9, action_0);
			}
			return;
		}
		if (int_9 == 56)
		{
			for (int num3 = int_7; num3 <= num; num3 = array3[i - 1])
			{
				byte b = 128;
				byte b2;
				while (array3[b2 = (byte)((byte)(long_0[num3] >> int_9) ^ b)] != num3)
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
			for (int num5 = int_7; num5 <= num; num5 = array3[i - 1])
			{
				byte b3;
				while (array3[b3 = (byte)(long_0[num5] >> int_9)] != num5)
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
		if (int_9 <= 0)
		{
			return;
		}
		int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
		for (int l = 0; l < 256; l++)
		{
			int num7 = array3[l] - array2[l];
			if (num7 >= int_4)
			{
				smethod_37(long_0, array2[l], num7, int_9, action_0);
			}
			else if (num7 >= 2)
			{
				action_0(long_0, array2[l], num7);
			}
		}
	}

	private static void smethod_38(long[] long_0, int int_7, int int_8, int int_9, Action<long[], int, int> action_0)
	{
		if (int_8 >= int_4)
		{
			int num = int_7 + int_8 - 1;
			int[] array = smethod_15(long_0, int_7, num, int_9);
			int[] int_10 = new int[257];
			int[] int_11 = new int[256];
			int i = 1;
			int_10[0] = (int_11[0] = int_7);
			int_10[256] = -1;
			for (int j = 1; j < 256; j++)
			{
				int_10[j] = (int_11[j] = int_10[j - 1] + array[j - 1]);
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
				if (int_9 > 0)
				{
					int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
					smethod_38(long_0, int_7, int_8, int_9, action_0);
				}
				return;
			}
			if (int_9 == 56)
			{
				for (int num3 = int_7; num3 <= num; num3 = int_11[i - 1])
				{
					byte b = 128;
					byte b2;
					while (int_11[b2 = (byte)((byte)(long_0[num3] >> int_9) ^ b)] != num3)
					{
						long num4 = long_0[num3];
						long_0[num3] = long_0[int_11[b2]];
						long_0[int_11[b2]++] = num4;
					}
					int_11[b2]++;
					for (; int_11[i - 1] == int_10[i]; i++)
					{
					}
				}
			}
			else
			{
				for (int num5 = int_7; num5 <= num; num5 = int_11[i - 1])
				{
					byte b3;
					while (int_11[b3 = (byte)(long_0[num5] >> int_9)] != num5)
					{
						long num6 = long_0[num5];
						long_0[num5] = long_0[int_11[b3]];
						long_0[int_11[b3]++] = num6;
					}
					int_11[b3]++;
					for (; int_11[i - 1] == int_10[i]; i++)
					{
					}
				}
			}
			if (int_9 <= 0)
			{
				return;
			}
			int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
			List<Action> list = new List<Action>();
			int l;
			for (l = 0; l < 256; l++)
			{
				if (int_11[l] - int_10[l] > int_5)
				{
					list.Add(delegate
					{
						smethod_38(long_0, int_10[l], int_11[l] - int_10[l], int_9, action_0);
					});
				}
				else
				{
					smethod_38(long_0, int_10[l], int_11[l] - int_10[l], int_9, action_0);
				}
			}
			Parallel.Invoke(list.ToArray());
		}
		else
		{
			action_0(long_0, int_7, int_8);
		}
	}

	public static void SortRadixMsdPar(this long[] arrayToBeSorted)
	{
		smethod_38(arrayToBeSorted, 0, arrayToBeSorted.Length, 56, Array.Sort);
	}

	public static long[] SortRadixMsdInPlaceFuncPar(this long[] arrayToBeSorted)
	{
		SortRadixMsdPar(arrayToBeSorted);
		return arrayToBeSorted;
	}

	private static void smethod_39(uint[] uint_0, int int_7, int int_8, int int_9, Action<uint[], int, int> action_0)
	{
		int num = int_7 + int_8 - 1;
		int[] array = smethod_16(uint_0, int_7, num, int_9);
		int[] int_10 = new int[257];
		int[] array2 = new int[256];
		int i = 1;
		int_10[0] = (array2[0] = int_7);
		int_10[256] = -1;
		for (int j = 1; j < 256; j++)
		{
			int_10[j] = (array2[j] = int_10[j - 1] + array[j - 1]);
		}
		for (int num2 = int_7; num2 <= num; num2 = array2[i - 1])
		{
			uint num3 = uint_0[num2];
			uint num4;
			while (array2[num4 = (num3 >> int_9) & 0xFF] != num2)
			{
				uint num5 = uint_0[array2[num4]];
				uint_0[array2[num4]++] = num3;
				num3 = num5;
			}
			uint_0[num2] = num3;
			array2[num4]++;
			for (; array2[i - 1] == int_10[i]; i++)
			{
			}
		}
		if (int_9 <= 0)
		{
			return;
		}
		int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
		List<Action> list = new List<Action>();
		for (int k = 0; k < 256; k++)
		{
			int int_11 = k;
			int int_12 = array2[int_11] - int_10[int_11];
			if (int_12 >= int_4)
			{
				list.Add(delegate
				{
					smethod_40(uint_0, int_10[int_11], int_12, int_9, action_0);
				});
			}
			else if (int_12 >= 2)
			{
				action_0(uint_0, int_10[int_11], int_12);
			}
		}
		Parallel.Invoke(list.ToArray());
	}

	private static void smethod_40(uint[] uint_0, int int_7, int int_8, int int_9, Action<uint[], int, int> action_0)
	{
		if (int_8 >= int_4)
		{
			int num = int_7 + int_8 - 1;
			int[] array = Algorithm.HistogramOneByteComponent(uint_0, int_7, num, int_9);
			int[] int_10 = new int[257];
			int[] int_11 = new int[256];
			int i = 1;
			int_10[0] = (int_11[0] = int_7);
			int_10[256] = -1;
			for (int j = 1; j < 256; j++)
			{
				int_10[j] = (int_11[j] = int_10[j - 1] + array[j - 1]);
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
				if (int_9 > 0)
				{
					int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
					smethod_40(uint_0, int_7, int_8, int_9, action_0);
				}
				return;
			}
			for (int num3 = int_7; num3 <= num; num3 = int_11[i - 1])
			{
				byte b;
				while (int_11[b = (byte)(uint_0[num3] >> int_9)] != num3)
				{
					uint num4 = uint_0[num3];
					uint_0[num3] = uint_0[int_11[b]];
					uint_0[int_11[b]++] = num4;
				}
				int_11[b]++;
				for (; int_11[i - 1] == int_10[i]; i++)
				{
				}
			}
			if (int_9 <= 0)
			{
				return;
			}
			int_9 = ((int_9 >= 8) ? (int_9 -= 8) : 0);
			List<Action> list = new List<Action>();
			int l;
			for (l = 0; l < 256; l++)
			{
				list.Add(delegate
				{
					smethod_40(uint_0, int_10[l], int_11[l] - int_10[l], int_9, action_0);
				});
			}
			Parallel.Invoke(list.ToArray());
		}
		else
		{
			action_0(uint_0, int_7, int_8);
		}
	}

	public static void SortRadixMsdPar(this uint[] arrayToBeSorted)
	{
		smethod_39(arrayToBeSorted, 0, arrayToBeSorted.Length, 24, Array.Sort);
	}

	public static uint[] SortRadixMsdInPlaceFuncPar(this uint[] arrayToBeSorted)
	{
		SortRadixMsdPar(arrayToBeSorted);
		return arrayToBeSorted;
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_41(int int_7)
	{
		int_6 = int_7;
	}

	private static bool smethod_42<T>(object object_0, object object_1, int int_7, int int_8)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_7 > int_8)
		{
			return true;
		}
		Comparer<T> comparer = Comparer<T>.Default;
		if (int_8 - int_7 + 1 <= int_6)
		{
			int num = int_7;
			while (true)
			{
				if (num <= int_8)
				{
					if (comparer.Compare(gparam_0[num], gparam_1[num]) != 0)
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
		int int_9 = (int_8 + int_7) / 2;
		bool bool_0 = false;
		bool bool_1 = false;
		Parallel.Invoke(delegate
		{
			bool_0 = smethod_42<T>(gparam_0, gparam_1, int_7, int_9);
		}, delegate
		{
			bool_1 = smethod_42<T>(gparam_0, gparam_1, int_9 + 1, int_8);
		});
		return bool_0 && bool_1;
	}

	private static bool smethod_43<T>(object object_0, object object_1, int int_7, int int_8, IEqualityComparer<T> iequalityComparer_0)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_7 > int_8)
		{
			return true;
		}
		if (int_8 - int_7 + 1 <= int_6)
		{
			int num = int_7;
			while (true)
			{
				if (num <= int_8)
				{
					if (!iequalityComparer_0.Equals(gparam_0[num], gparam_1[num]))
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
		int int_9 = (int_8 + int_7) / 2;
		bool bool_0 = false;
		bool bool_1 = false;
		Parallel.Invoke(delegate
		{
			bool_0 = smethod_43(gparam_0, gparam_1, int_7, int_9, iequalityComparer_0);
		}, delegate
		{
			bool_1 = smethod_43(gparam_0, gparam_1, int_9 + 1, int_8, iequalityComparer_0);
		});
		return bool_0 && bool_1;
	}

	private static bool smethod_44<T>(object object_0, object object_1, int int_7, int int_8, Func<T, T, bool> func_0)
	{
		T[] gparam_0 = (T[])object_0;
		T[] gparam_1 = (T[])object_1;
		if (int_7 > int_8)
		{
			return true;
		}
		if (int_8 - int_7 + 1 <= int_6)
		{
			int num = int_7;
			while (true)
			{
				if (num <= int_8)
				{
					if (!func_0(gparam_0[num], gparam_1[num]))
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
		int int_9 = (int_8 + int_7) / 2;
		bool bool_0 = false;
		bool bool_1 = false;
		Parallel.Invoke(delegate
		{
			bool_0 = smethod_44(gparam_0, gparam_1, int_7, int_9, func_0);
		}, delegate
		{
			bool_1 = smethod_44(gparam_0, gparam_1, int_9 + 1, int_8, func_0);
		});
		return bool_0 && bool_1;
	}

	public static bool SequenceEqualHpcPar<T>(this T[] first, T[] second, int l, int r)
	{
		if (first != null && second != null)
		{
			if (l < 0 || r >= first.Length || r < 0 || r >= second.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			return smethod_42<T>(first, second, l, r);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this T[] first, T[] second, int l, int r, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (l < 0 || r >= first.Length || r < 0 || r >= second.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			return smethod_43(first, second, l, r, equalityComparer);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this T[] first, T[] second, int l, int r, Func<T, T, bool> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (l < 0 || r >= first.Length || r < 0 || r >= second.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			return smethod_44(first, second, l, r, equalityComparer);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this T[] first, T[] second)
	{
		if (first != null && second != null)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			return smethod_42<T>(first, second, 0, first.Length - 1);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this T[] first, T[] second, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			return smethod_43(first, second, 0, first.Length - 1, equalityComparer);
		}
		throw new ArgumentNullException();
	}

	private static bool smethod_45<T>(List<T> list_0, List<T> list_1, int int_7, int int_8)
	{
		if (int_7 > int_8)
		{
			return true;
		}
		Comparer<T> comparer = Comparer<T>.Default;
		if (int_8 - int_7 + 1 <= int_6)
		{
			int num = int_7;
			while (true)
			{
				if (num <= int_8)
				{
					if (comparer.Compare(list_0[num], list_1[num]) != 0)
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
		int int_9 = (int_8 + int_7) / 2;
		bool bool_0 = false;
		bool bool_1 = false;
		Parallel.Invoke(delegate
		{
			bool_0 = smethod_45(list_0, list_1, int_7, int_9);
		}, delegate
		{
			bool_1 = smethod_45(list_0, list_1, int_9 + 1, int_8);
		});
		return bool_0 && bool_1;
	}

	private static bool smethod_46<T>(List<T> list_0, List<T> list_1, int int_7, int int_8, IEqualityComparer<T> iequalityComparer_0)
	{
		if (int_7 > int_8)
		{
			return true;
		}
		if (int_8 - int_7 + 1 <= int_6)
		{
			int num = int_7;
			while (true)
			{
				if (num <= int_8)
				{
					if (!iequalityComparer_0.Equals(list_0[num], list_1[num]))
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
		int int_9 = (int_8 + int_7) / 2;
		bool bool_0 = false;
		bool vmneJfXpaUc = false;
		Parallel.Invoke(delegate
		{
			bool_0 = smethod_46(list_0, list_1, int_7, int_9, iequalityComparer_0);
		}, delegate
		{
			vmneJfXpaUc = smethod_46(list_0, list_1, int_9 + 1, int_8, iequalityComparer_0);
		});
		return bool_0 && vmneJfXpaUc;
	}

	public static bool SequenceEqualHpcPar<T>(this List<T> first, List<T> second, int l, int r)
	{
		if (first != null && second != null)
		{
			if (l < 0 || r >= first.Count || r < 0 || r >= second.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return smethod_45(first, second, l, r);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this List<T> first, List<T> second, int l, int r, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (l < 0 || r >= first.Count || r < 0 || r >= second.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return smethod_46(first, second, l, r, equalityComparer);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this List<T> first, List<T> second)
	{
		if (first != null && second != null)
		{
			if (first.Count != second.Count)
			{
				return false;
			}
			return smethod_45(first, second, 0, first.Count - 1);
		}
		throw new ArgumentNullException();
	}

	public static bool SequenceEqualHpcPar<T>(this List<T> first, List<T> second, IEqualityComparer<T> equalityComparer)
	{
		if (first != null && second != null)
		{
			if (first.Count != second.Count)
			{
				return false;
			}
			return smethod_46(first, second, 0, first.Count - 1, equalityComparer);
		}
		throw new ArgumentNullException();
	}

	public static bool EqualSse(this int[] first, int[] second)
	{
		if (first != null && second != null)
		{
			if (first.Length == 0 || second.Length == 0)
			{
				throw new ArgumentException("Equality cannot be determined when one or both arrays are empty");
			}
			return first.smethod_47(second, 0, first.Length - 1);
		}
		throw new ArgumentNullException("Equality cannot be determined when one or both arrays are null");
	}

	public static bool EqualSse(this int[] first, int[] second, int start, int length)
	{
		if (first != null && second != null)
		{
			if (first.Length == 0 || second.Length == 0 || length == 0)
			{
				throw new ArgumentException("Equality cannot be determined when one or both arrays are empty, or length is zero");
			}
			return first.smethod_47(second, start, start + length - 1);
		}
		throw new ArgumentNullException("Equality cannot be determined when one or both arrays are null");
	}

	private static bool smethod_47(this object object_0, object object_1, int int_7, int int_8)
	{
		int num = int_7 + (int_8 - int_7 + 1) / Vector<int>.Count * Vector<int>.Count;
		int i;
		for (i = int_7; i < num; i += Vector<int>.Count)
		{
			Vector<int> left = new Vector<int>((int[])object_0, i);
			Vector<int> right = new Vector<int>((int[])object_1, i);
			if (!Vector.EqualsAll(left, right))
			{
				return false;
			}
		}
		while (true)
		{
			if (i <= int_8)
			{
				if (((int[])object_0)[i] != ((int[])object_1)[i])
				{
					break;
				}
				i++;
				continue;
			}
			return true;
		}
		return false;
	}

	static ParallelAlgorithm()
	{
		Class72.smethod_20();
		int_0 = 131072;
		int_1 = 64000;
		int_2 = 16;
		int_3 = 16384;
		int_4 = 16384;
		int_5 = 1024;
		int_6 = 1024;
	}
}
