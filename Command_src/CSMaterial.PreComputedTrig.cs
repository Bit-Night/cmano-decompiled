using System;
using System.Diagnostics;

namespace CSMaterial;

public static class PreComputedTrig
{
	private static double[] double_0;

	private static double[] double_1;

	public static void InitializeTrigonometricTables()
	{
		double_0 = new double[131072];
		double_1 = new double[131072];
		for (int i = 0; i < 131072; i++)
		{
			double num = (double)i / 131072.0 * (Math.PI * 2.0);
			double_1[i] = Math.Sin(num);
			double_0[i] = Math.Cos(num);
		}
	}

	public static double Sin(double angle_rad)
	{
		try
		{
			int num = (int)(angle_rad * (65536.0 / Math.PI));
			num %= 131072;
			num = ((num >= 0) ? num : (131072 - num));
			return double_1[num];
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return Math.Sin(angle_rad);
		}
	}

	public static double Cos(double angle_rad)
	{
		try
		{
			int num = (int)(angle_rad * (65536.0 / Math.PI));
			num %= 131072;
			num = ((num >= 0) ? num : (131072 - num));
			return double_0[num];
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return Math.Cos(angle_rad);
		}
	}

	public static void SinCos(double angle_rad, out double sineValue, out double cosineValue)
	{
		try
		{
			int num = (int)(angle_rad * (65536.0 / Math.PI));
			num %= 131072;
			num = ((num >= 0) ? num : (131072 - num));
			sineValue = double_1[num];
			cosineValue = double_0[num];
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			sineValue = Math.Sin(angle_rad);
			cosineValue = Math.Cos(angle_rad);
		}
	}

	static PreComputedTrig()
	{
		Class72.smethod_20();
	}
}
