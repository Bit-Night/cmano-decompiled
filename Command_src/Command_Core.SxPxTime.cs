using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SxPxTime
{
	internal static double Julian_Date_of_Year(ref double year)
	{
		year -= 1.0;
		double num = RadarModel.Floor(year / 100.0);
		double num2 = 2.0 - num + (double)RadarModel.Floor(num / 4.0);
		return (double)(RadarModel.Floor(365.25 * year) + RadarModel.Floor(428.4014)) + 1720994.5 + num2;
	}

	internal static double Julian_Date_of_Epoch(ref double epoch)
	{
		double num = RadarModel.Floor(epoch * 0.001);
		num = ((!(num >= 57.0)) ? (num + 2000.0) : (num + 1900.0));
		double num2 = epoch - (double)RadarModel.Floor(epoch * 0.001) * 1000.0;
		return Julian_Date_of_Year(ref num) + num2;
	}

	internal static double ThetaG(ref double epoch, ref double ds50)
	{
		double num = RadarModel.Floor(epoch * 0.001);
		num = ((!(num >= 57.0)) ? (num + 2000.0) : (num + 1900.0));
		double num2 = epoch - (double)RadarModel.Floor(epoch * 0.001) * 1000.0;
		double num3 = num2 - (double)RadarModel.Floor(num2);
		num2 = RadarModel.Floor(num2);
		double num4 = Julian_Date_of_Year(ref num) + num2;
		double num5 = (num4 - 2451545.0) / 36525.0;
		double num6 = 24110.54841 + num5 * (8640184.812866 + num5 * (0.093104 - num5 * 6.2E-06));
		num6 = SxPxMath.modulus(num6 + 86636.555366976 * num3, 86400.0);
		double result = 6.28318530717958 * num6 / 86400.0;
		ds50 = num4 - 2433281.5 + num3;
		return result;
	}

	internal static double Julian_Date(ref DateTime currentdate)
	{
		double year = currentdate.Year;
		return Julian_Date_of_Year(ref year) + (double)DOY(currentdate.Year, currentdate.Month, currentdate.Day) + Fraction_of_Day(currentdate.Hour, currentdate.Minute, currentdate.Second) + 5.787037E-06;
	}

	internal static double Fraction_of_Day(int hr, int mi, double se)
	{
		double num = hr;
		double num2 = mi;
		return (num + (num2 + se / 60.0) / 60.0) / 24.0;
	}

	internal static int DOY(int yr, int mo, int dy)
	{
		int[] array = new int[12]
		{
			31, 28, 31, 30, 31, 30, 31, 31, 30, 31,
			30, 31
		};
		int num = 0;
		for (int i = 0; i < mo - 1; i++)
		{
			num += array[i];
		}
		num += dy;
		if (((yr % 4 == 0) & ((yr % 100 != 0) | (yr % 400 == 0))) && mo > 2)
		{
			num++;
		}
		return num;
	}

	internal static double ThetaG_JD(double jd)
	{
		double num = SxPxMath.Frac(jd + 0.5);
		jd -= num;
		double num2 = (jd - 2451545.0) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = SxPxMath.modulus(num3 + 86636.555366976 * num, 86400.0);
		return 6.28318530717958 * num3 / 86400.0;
	}

	internal static double toGMST(double tsince)
	{
		double num = (tsince + 0.5) % 1.0;
		double num2 = (tsince - 2451545.0 - num) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = (num3 + 86636.555366976 * num) % 86400.0;
		if (num3 < 0.0)
		{
			num3 += 86400.0;
		}
		return 6.28318530717958 * (num3 / 86400.0);
	}

	static SxPxTime()
	{
		Class72.smethod_20();
	}
}
