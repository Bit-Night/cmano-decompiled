using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class FastCache_2DArray
{
	private int int_0;

	private int[,] int_1;

	private LockObject lockObject_0;

	public FastCache_2DArray(int InvalidValue)
	{
		lockObject_0 = new LockObject();
		int_0 = InvalidValue;
		int_1 = method_0(1, 1);
	}

	public void SetValue(int theValue, int key1, int key2)
	{
		try
		{
			method_1(ref int_1, key1, key2);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return;
		}
		int_1[key1, key2] = theValue;
	}

	public int GetValue(int key1, int key2)
	{
		int length = int_1.GetLength(0);
		int length2 = int_1.GetLength(1);
		int result;
		if (length >= key1 && length2 >= key2)
		{
			try
			{
				int num = int_1[key1, key2];
				result = ((num == int_0) ? int_0 : num);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = int_0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = int_0;
		}
		return result;
	}

	private int[,] method_0(int int_2, int int_3)
	{
		int[,] array = new int[int_2 - 1 + 1, int_3 - 1 + 1];
		int num = int_2 - 1;
		for (int i = 0; i <= num; i++)
		{
			int num2 = int_3 - 1;
			for (int j = 0; j <= num2; j++)
			{
				array[i, j] = int_0;
			}
		}
		return array;
	}

	private void method_1(ref int[,] int_2, int int_3, int int_4)
	{
		int length = int_2.GetLength(0);
		int length2 = int_2.GetLength(1);
		if (int_3 < length && int_4 < length2)
		{
			return;
		}
		try
		{
			lock (lockObject_0)
			{
				if (int_3 < length && int_4 < length2)
				{
					return;
				}
				int num = Math.Max(int_3 + 1, length * 2);
				int num2 = Math.Max(int_4 + 1, length2 * 2);
				int[,] array = method_0(num, num2);
				int num3 = num - 1;
				for (int i = 0; i <= num3; i++)
				{
					int num4 = num2 - 1;
					for (int j = 0; j <= num4; j++)
					{
						array[i, j] = int_0;
					}
				}
				int num5 = length - 1;
				for (int i = 0; i <= num5; i++)
				{
					int num6 = length2 - 1;
					for (int j = 0; j <= num6; j++)
					{
						array[i, j] = int_2[i, j];
					}
				}
				int_2 = array;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	static FastCache_2DArray()
	{
		Class72.smethod_20();
	}
}
