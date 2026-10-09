using System;
using System.Buffers;
using System.Diagnostics;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_Haversine
{
	public static double Distance_Horiz_Angular_Approx_Rad(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double d = Lat1 * 0.0174532925199433;
		double d2 = Lat2 * 0.0174532925199433;
		double num = (Lat2 - Lat1) * 0.0174532925199433;
		double num2 = (Lon2 - Lon1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		return 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5));
	}

	public static double Distance_Horiz_Angular_Approx_Deg(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double d = Lat1 * 0.0174532925199433;
		double d2 = Lat2 * 0.0174532925199433;
		double num = (Lat2 - Lat1) * 0.0174532925199433;
		double num2 = (Lon2 - Lon1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		return 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)) * 57.2957795130823;
	}

	public static double Distance_Horiz_Angular_Approx_Deg(double double_0, double double_1, double Lon1RAD, double Lat2, double Lon2)
	{
		double num = Lat2 * 0.0174532925199433;
		double num2 = Math.Sin((num - double_0) / 2.0);
		double num3 = Math.Sin((Lon2 * 0.0174532925199433 - Lon1RAD) / 2.0);
		double d = num2 * num2 + double_1 * Math.Cos(num) * num3 * num3;
		return 2.0 * Math.Asin(Math.Sqrt(d)) * 57.2957795130823;
	}

	public static double Distance_Horiz_Approx_nm(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double d = Lat1 * 0.0174532925199433;
		double d2 = Lat2 * 0.0174532925199433;
		double num = (Lat2 - Lat1) * 0.0174532925199433;
		double num2 = (Lon2 - Lon1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		double num6 = 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5));
		return 3441.6865234375 * num6;
	}

	public static bool PointIsWithinDistanceFromPoint(double StartLat, double StartLon, double TargetLat, double TargetLon, float distance_nm)
	{
		double num = Math2.Distance_To_AngularDegrees(distance_nm);
		bool flag = true;
		double num2 = StartLat + num;
		double num3 = StartLat - num;
		int num4;
		if (!(num2 > 90.0))
		{
			if (!(num3 < -90.0))
			{
				goto IL_0034;
			}
			num4 = 0;
		}
		else
		{
			num4 = 0;
		}
		flag = (byte)num4 != 0;
		goto IL_0034;
		IL_0034:
		if (flag)
		{
			int result;
			if (!(num2 < TargetLat))
			{
				if (!(num3 > TargetLat))
				{
					goto IL_0048;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		goto IL_0048;
		IL_0048:
		if (Distance_Horiz_Angular_Approx_Deg(StartLat, StartLon, TargetLat, TargetLon) <= num)
		{
			return true;
		}
		return false;
	}

	public static ActiveUnit[] UnitsWithinDistanceFromPoint(PooledList<ActiveUnit> Units, bool AssumeAllUnitsAreOperating, double PointLat, double PointLon, double DistanceNM)
	{
		int count = Units.Count;
		if (count == 0)
		{
			return null;
		}
		double num = Math2.Distance_To_AngularDegrees(DistanceNM);
		bool flag = true;
		double num2 = PointLat + num;
		double num3 = PointLat - num;
		int num4;
		if (!(num2 > 90.0))
		{
			if (!(num3 < -90.0))
			{
				goto IL_0045;
			}
			num4 = 0;
		}
		else
		{
			num4 = 0;
		}
		flag = (byte)num4 != 0;
		goto IL_0045;
		IL_0045:
		bool? theBool = null;
		if (AssumeAllUnitsAreOperating)
		{
			theBool = true;
		}
		GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(theBool);
		ActiveUnit[] array = ArrayPool<ActiveUnit>.Shared.Rent(Units.Count);
		int num5 = -1;
		ActiveUnit[] array2 = Units.InternalArray();
		double num6 = PointLat * 0.0174532925199433;
		double double_ = Math.Cos(num6);
		double lon1RAD = PointLon * 0.0174532925199433;
		int num7 = count - 1;
		for (int i = 0; i <= num7; i++)
		{
			double num8 = 0.0;
			double num9 = 0.0;
			try
			{
				ActiveUnit activeUnit = array2[i];
				if (activeUnit == null)
				{
					continue;
				}
				num8 = activeUnit.Latitude_AtStartOfPulse;
				num9 = activeUnit.Longitude_AtStartOfPulse;
				if (num8 == 0.0)
				{
					num8 = activeUnit.get_Latitude(hintIsOperating);
				}
				if (!flag || (!(num2 < num8) && !(num3 > num8)))
				{
					if (num9 == 0.0)
					{
						num9 = activeUnit.get_Longitude(hintIsOperating);
					}
					if (Distance_Horiz_Angular_Approx_Deg(num6, double_, lon1RAD, num8, num9) <= num)
					{
						num5++;
						array[num5] = activeUnit;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return array;
	}

	static Geodesic_Haversine()
	{
		Class72.smethod_20();
	}
}
