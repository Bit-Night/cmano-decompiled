using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSMaterial;

namespace ns0;

public class MergeSortHelper<T>
{
	private readonly IComparer<T> icomparer_0;

	private static object object_0;

	public MergeSortHelper()
		: this((IComparer<T>)Comparer<T>.Default)
	{
	}

	public MergeSortHelper(IComparer<T> comparer)
	{
		icomparer_0 = comparer;
	}

	public void MergeSort(T[] array, int low, int high, bool parallel)
	{
		T[] gparam_ = (T[])array.Clone();
		if (parallel)
		{
			method_3(array, gparam_, low, high, smethod_0());
		}
		else
		{
			method_0(array, gparam_, low, high);
		}
	}

	private void method_0(T[] gparam_0, T[] gparam_1, int int_0, int int_1)
	{
		if (int_0 < int_1)
		{
			int num = (int_0 + int_1) / 2;
			method_0(gparam_1, gparam_0, int_0, num);
			method_0(gparam_1, gparam_0, num + 1, int_1);
			method_1(gparam_0, gparam_1, int_0, num, num + 1, int_1, int_0);
		}
	}

	private void method_1(T[] gparam_0, T[] gparam_1, int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		int num = int_4 + int_1 - int_0 + int_3 - int_2 + 1;
		while (int_4 <= num)
		{
			if (int_0 <= int_1)
			{
				if (int_2 <= int_3)
				{
					gparam_0[int_4] = (method_2(gparam_1[int_0], gparam_1[int_2]) ? gparam_1[int_0++] : gparam_1[int_2++]);
				}
				else
				{
					gparam_0[int_4] = gparam_1[int_0++];
				}
			}
			else
			{
				gparam_0[int_4] = gparam_1[int_2++];
			}
			int_4++;
		}
	}

	private bool method_2(T gparam_0, T gparam_1)
	{
		return icomparer_0.Compare(gparam_0, gparam_1) < 0;
	}

	private void method_3(T[] gparam_0, T[] gparam_1, int int_0, int int_1, int int_2)
	{
		if (int_1 - int_0 + 1 > 2048 && int_2 > 0)
		{
			int int_3 = (int_0 + int_1) / 2;
			int_2--;
			Parallel.Invoke(delegate
			{
				method_3(gparam_1, gparam_0, int_0, int_3, int_2);
			}, delegate
			{
				method_3(gparam_1, gparam_0, int_3 + 1, int_1, int_2);
			});
			method_4(gparam_0, gparam_1, int_0, int_3, int_3 + 1, int_1, int_0, int_2);
		}
		else
		{
			method_0(gparam_0, gparam_1, int_0, int_1);
		}
	}

	private void method_4(T[] gparam_0, T[] gparam_1, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		int num = int_1 - int_0 + 1;
		int num2 = int_3 - int_2 + 1;
		if (num + num2 > 2048 && int_5 > 0)
		{
			if (num >= num2)
			{
				int int_6 = (int_0 + int_1) / 2;
				int int_7 = method_5(gparam_1, int_2, int_3, gparam_1[int_6]);
				int int_8 = int_4 + int_6 - int_0 + int_7 - int_2;
				gparam_0[int_8] = gparam_1[int_6];
				int_5--;
				Parallel.Invoke(delegate
				{
					method_4(gparam_0, gparam_1, int_0, int_6 - 1, int_2, int_7 - 1, int_4, int_5);
				}, delegate
				{
					method_4(gparam_0, gparam_1, int_6 + 1, int_1, int_7, int_3, int_8 + 1, int_5);
				});
			}
			else
			{
				method_4(gparam_0, gparam_1, int_2, int_3, int_0, int_1, int_4, int_5);
			}
		}
		else
		{
			method_1(gparam_0, gparam_1, int_0, int_1, int_2, int_3, int_4);
		}
	}

	private int method_5(T[] gparam_0, int int_0, int int_1, T gparam_1)
	{
		int_1 = Math.Max(int_0, int_1 + 1);
		while (int_0 < int_1)
		{
			int num = (int_0 + int_1) / 2;
			if (method_2(gparam_0[num], gparam_1))
			{
				int_0 = num + 1;
			}
			else
			{
				int_1 = num;
			}
		}
		return int_0;
	}

	private static int smethod_0()
	{
		return (int)Math.Log(Misc.Environment_ProcessorCount, 2.0) + 4;
	}

	static MergeSortHelper()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_1()
	{
		return object_0 == null;
	}

	internal static object smethod_2()
	{
		return object_0;
	}
}
