using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HPCsharp;

public static class ParallelAlgorithmExperimental
{
	[CompilerGenerated]
	private static uint uint_0;

	public static uint SortRadixParallelWorkQuanta
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public static uint[] SortRadixPar1(this uint[] inputArray)
	{
		uint num = 256u;
		int num2 = 8;
		uint[] uint_1 = new uint[inputArray.Length];
		bool flag = false;
		uint num3 = (uint)inputArray.Length / uint_0 + 1;
		uint[][] array = new uint[num3][];
		for (int i = 0; i < num3; i++)
		{
			array[i] = new uint[num];
		}
		uint[][] uint_2 = new uint[num3][];
		for (int j = 0; j < num3; j++)
		{
			uint_2[j] = new uint[num];
		}
		uint num4 = 255u;
		int num5 = 0;
		while (num4 != 0)
		{
			for (uint num6 = 0u; num6 < num3; num6++)
			{
				for (uint num7 = 0u; num7 < num; num7++)
				{
					array[num6][num7] = 0u;
				}
			}
			for (uint num8 = 0u; num8 < inputArray.Length; num8++)
			{
				uint num9 = num8 / uint_0;
				array[num9][smethod_1(inputArray[num8], num4, num5)]++;
			}
			for (uint num10 = 0u; num10 < num; num10++)
			{
				uint_2[0][num10] = 0u;
				for (uint num11 = 1u; num11 < num3; num11++)
				{
					uint_2[num11][num10] = uint_2[num11 - 1][num10] + array[num11 - 1][num10];
				}
			}
			for (uint num12 = 1u; num12 < num; num12++)
			{
				uint num13 = uint_2[num3 - 1][num12 - 1] + array[num3 - 1][num12 - 1];
				for (uint num14 = 0u; num14 < num3; num14++)
				{
					uint_2[num14][num12] += num13;
				}
			}
			Task[] array2 = new Task[num3 - 1];
			for (uint num15 = 0u; num15 < num3 - 1; num15++)
			{
				uint current = num15 * uint_0;
				array2[num15] = Task.Factory.StartNew(delegate(object obj)
				{
					if (obj is CustomData { current: var num20, q: var q } customData)
					{
						uint[] array4 = uint_2[q];
						for (uint num21 = 0u; num21 < SortRadixParallelWorkQuanta; num21++)
						{
							uint_1[array4[(inputArray[num20] & customData.bitMask) >> customData.shiftRightAmount]++] = inputArray[num20];
							num20++;
						}
					}
				}, new CustomData
				{
					current = current,
					q = num15,
					bitMask = num4,
					shiftRightAmount = num5
				});
			}
			if (array2.Length != 0)
			{
				Task.WaitAll(array2);
			}
			uint num16 = (num3 - 1) * uint_0;
			uint num17 = (uint)inputArray.Length % uint_0;
			for (uint num18 = 0u; num18 < num17; num18++)
			{
				uint_1[uint_2[num3 - 1][smethod_1(inputArray[num16], num4, num5)]++] = inputArray[num16];
				num16++;
			}
			num4 <<= num2;
			num5 += num2;
			flag = !flag;
			uint[] array3 = inputArray;
			inputArray = uint_1;
			uint_1 = array3;
		}
		if (flag)
		{
			for (uint num19 = 0u; num19 < inputArray.Length; num19++)
			{
				inputArray[num19] = uint_1[num19];
			}
		}
		return inputArray;
	}

	public static uint[] SortRadixPar2(this uint[] inputArray)
	{
		uint num = 256u;
		int num2 = 8;
		int num3 = 4;
		uint[] array = new uint[inputArray.Length];
		bool flag = false;
		if (inputArray.Length == 0)
		{
			return array;
		}
		uint num4 = (uint)((inputArray.Length % uint_0 != 0L) ? (inputArray.Length / uint_0 + 1L) : (inputArray.Length / uint_0));
		uint num5 = (uint)(inputArray.Length / uint_0);
		Console.WriteLine("Before Histogram");
		uint[][][] array2 = Algorithm.HistogramByteComponentsAcrossWorkQuantas(inputArray, uint_0);
		Console.WriteLine("After Histogram");
		uint[][][] array3 = new uint[num4][][];
		for (int i = 0; i < num4; i++)
		{
			array3[i] = new uint[num3][];
			for (int j = 0; j < num3; j++)
			{
				array3[i][j] = new uint[num];
			}
		}
		for (int k = 0; k < num3; k++)
		{
			for (uint num6 = 0u; num6 < num; num6++)
			{
				array3[0][k][num6] = 0u;
				for (int l = 1; l < num4; l++)
				{
					array3[l][k][num6] = array3[l - 1][k][num6] + array2[l - 1][k][num6];
				}
			}
		}
		for (int m = 0; m < num3; m++)
		{
			for (uint num7 = 1u; num7 < num; num7++)
			{
				uint num8 = array3[num4 - 1][m][num7 - 1] + array2[num4 - 1][m][num7 - 1];
				for (uint num9 = 0u; num9 < num4; num9++)
				{
					array3[num9][m][num7] += num8;
				}
			}
		}
		uint num10 = 255u;
		int num11 = 0;
		uint num12 = 0u;
		Console.WriteLine("Before main permutation");
		while (num10 != 0)
		{
			for (uint num13 = 0u; num13 < num5; num13++)
			{
				uint[] array4 = array3[num13][num12];
				uint num14 = num13 * uint_0;
				for (uint num15 = 0u; num15 < uint_0; num15++)
				{
					array[array4[smethod_1(inputArray[num14], num10, num11)]++] = inputArray[num14];
					num14++;
				}
			}
			Console.WriteLine("Before last permutation");
			if (num4 > num5)
			{
				uint num16 = num5 * uint_0;
				uint num17 = (uint)inputArray.Length % uint_0;
				for (uint num18 = 0u; num18 < num17; num18++)
				{
					array[array3[num5][num12][smethod_1(inputArray[num16], num10, num11)]++] = inputArray[num16];
					num16++;
				}
			}
			num10 <<= num2;
			num12++;
			num11 += num2;
			flag = !flag;
			uint[] array5 = inputArray;
			inputArray = array;
			array = array5;
		}
		if (flag)
		{
			for (uint num19 = 0u; num19 < inputArray.Length; num19++)
			{
				inputArray[num19] = array[num19];
			}
		}
		return inputArray;
	}

	private static void smethod_0(uint uint_1, object object_0, uint[,] uint_2, uint uint_3, object object_1, uint uint_4, int int_0)
	{
		for (uint num = 0u; num < uint_0; num++)
		{
			((int[])object_0)[uint_2[uint_3, smethod_1(((uint[])object_1)[uint_1], uint_4, int_0)]++] = (int)((uint[])object_1)[uint_1];
			uint_1++;
		}
	}

	private static uint smethod_1(uint uint_1, uint uint_2, int int_0)
	{
		return (uint_1 & uint_2) >> int_0;
	}

	private static uint smethod_2(ulong ulong_0, ulong ulong_1, int int_0)
	{
		return (uint)((ulong_0 & ulong_1) >> int_0);
	}

	static ParallelAlgorithmExperimental()
	{
		Class72.smethod_20();
		uint_0 = 65536u;
	}
}
