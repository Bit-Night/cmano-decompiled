using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class LongRangeBallisticTables
{
	public static Dictionary<int, int> BurnoutSpeedForTargetRange;

	public static Dictionary<int, float> BurnoutAngleForTargetRange;

	static LongRangeBallisticTables()
	{
		Class72.smethod_20();
		BurnoutSpeedForTargetRange = new Dictionary<int, int>();
		BurnoutAngleForTargetRange = new Dictionary<int, float>();
	}

	public static void PopulateTables()
	{
		BurnoutSpeedForTargetRange.Add(500, 2100);
		BurnoutSpeedForTargetRange.Add(1000, 2800);
		BurnoutSpeedForTargetRange.Add(2000, 4000);
		BurnoutSpeedForTargetRange.Add(3000, 4750);
		BurnoutSpeedForTargetRange.Add(4000, 5300);
		BurnoutSpeedForTargetRange.Add(5000, 5750);
		BurnoutSpeedForTargetRange.Add(6000, 6125);
		BurnoutSpeedForTargetRange.Add(7000, 6400);
		BurnoutSpeedForTargetRange.Add(8000, 6700);
		BurnoutSpeedForTargetRange.Add(9000, 6800);
		BurnoutSpeedForTargetRange.Add(10000, 7020);
		BurnoutSpeedForTargetRange.Add(11000, 7200);
		BurnoutSpeedForTargetRange.Add(12000, 7300);
		BurnoutAngleForTargetRange.Add(500, 42f);
		BurnoutAngleForTargetRange.Add(1000, 41f);
		BurnoutAngleForTargetRange.Add(2000, 39f);
		BurnoutAngleForTargetRange.Add(3000, 37.5f);
		BurnoutAngleForTargetRange.Add(4000, 36f);
		BurnoutAngleForTargetRange.Add(5000, 33f);
		BurnoutAngleForTargetRange.Add(6000, 31.75f);
		BurnoutAngleForTargetRange.Add(7000, 28.25f);
		BurnoutAngleForTargetRange.Add(8000, 26f);
		BurnoutAngleForTargetRange.Add(9000, 24f);
		BurnoutAngleForTargetRange.Add(10000, 22.5f);
		BurnoutAngleForTargetRange.Add(11000, 20f);
		BurnoutAngleForTargetRange.Add(12000, 16f);
		BurnoutAngleForTargetRange.Add(13000, 14f);
		BurnoutAngleForTargetRange.Add(14000, 12f);
		BurnoutAngleForTargetRange.Add(15000, 10f);
	}

	public static float CalculateBurnoutSpeedForGivenRange_kts(float theRange_nm)
	{
		float num = (float)((double)theRange_nm * 1852.0 / 1000.0);
		if (num <= 500f)
		{
			return (float)((double)(float)Math.Sqrt((double)theRange_nm * 1852.0 * 9.81) * 1.94384);
		}
		int num2 = BurnoutSpeedForTargetRange.Count - 1;
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		for (int i = 0; i <= num2; i++)
		{
			int num3 = BurnoutSpeedForTargetRange.Keys.ElementAtOrDefault(i);
			if (!((float)num3 <= num))
			{
				num4 = BurnoutSpeedForTargetRange.Keys.ElementAtOrDefault(i - 1);
				num5 = BurnoutSpeedForTargetRange.Values.ElementAtOrDefault(i - 1);
				num6 = num3;
				num7 = BurnoutSpeedForTargetRange.Values.ElementAtOrDefault(i);
				break;
			}
		}
		float num8 = (num - (float)num4) / (float)(num6 - num4);
		return (float)((double)((float)num5 + (float)(num7 - num5) * num8) * 1.94384);
	}

	public static float CalculateBurnoutAngleForGivenRange(float theRange_nm)
	{
		float num = (float)((double)theRange_nm * 1852.0 / 1000.0);
		if (num <= 500f)
		{
			return 45f;
		}
		int num2 = BurnoutAngleForTargetRange.Count - 1;
		int num4 = default(int);
		float num5 = default(float);
		int num6 = default(int);
		float num7 = default(float);
		for (int i = 0; i <= num2; i++)
		{
			int num3 = BurnoutAngleForTargetRange.Keys.ElementAtOrDefault(i);
			if (!((float)num3 <= num))
			{
				num4 = BurnoutAngleForTargetRange.Keys.ElementAtOrDefault(i - 1);
				num5 = BurnoutAngleForTargetRange.Values.ElementAtOrDefault(i - 1);
				num6 = num3;
				num7 = BurnoutAngleForTargetRange.Values.ElementAtOrDefault(i);
				break;
			}
		}
		float num8 = (num - (float)num4) / (float)(num6 - num4);
		return (float)(double)(num5 + (num7 - num5) * num8);
	}

	public static double CalculateBurnoutAltitude_km(double BallisticRange_km, double BurnOutVel_km__s)
	{
		if (BallisticRange_km <= 500.0)
		{
			return 100000.0 * (BallisticRange_km / 500.0) / 1000.0;
		}
		double num = MathFunctions.DegreesToRadians(45.0);
		double num2 = (6371.0 * Math.Pow(BurnOutVel_km__s, 2.0) * (-2.0 * Math.Sin(num) + Math.Sin(0.0 - BallisticRange_km / 6371.0 + num)) + Math.Sqrt(6371.0 * Math.Pow(BurnOutVel_km__s, 2.0) * (-1594738.67649728 * (-1.0 + Math.Cos(BallisticRange_km / 6371.0)) + 6371.0 * Math.Pow(BurnOutVel_km__s, 2.0) * Math.Pow(Math.Sin(0.0 - BallisticRange_km / 6371.0 + num), 2.0)))) / (2.0 * Math.Pow(BurnOutVel_km__s, 2.0) * Math.Sin(num));
		if (double.IsNaN(num2))
		{
			num2 = ((BallisticRange_km > 12000.0) ? 300.0 : ((BallisticRange_km > 10000.0) ? 250.0 : ((BallisticRange_km > 8000.0) ? 200.0 : ((BallisticRange_km > 6000.0) ? 150.0 : ((BallisticRange_km > 4000.0) ? 120.0 : ((BallisticRange_km > 2000.0) ? 100.0 : ((BallisticRange_km > 1500.0) ? 80.0 : ((!(BallisticRange_km > 1000.0)) ? 40.0 : 60.0))))))));
		}
		return num2;
	}
}
