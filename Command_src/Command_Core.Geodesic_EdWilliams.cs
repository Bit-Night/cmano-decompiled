using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_EdWilliams
{
	public static void CircleFromPoint(double Lat, double Lon, double RadiusNM, int NumPoints, ref Geodesic_Vincenty.Point3D[] CirclePoints)
	{
		if (NumPoints < 3)
		{
			throw new Exception("insufficient numpoints");
		}
		double Lon2 = Geodesic_Vincenty.AdjustAngle(Lon);
		Array.Resize(ref CirclePoints, NumPoints);
		double bearing = 0.0;
		double num = 360.0 / (double)NumPoints;
		int num2 = NumPoints - 1;
		for (int i = 0; i <= num2; i++)
		{
			CirclePoints[i].Z = 0.0;
			CalcPoint_Williams(ref Lon2, ref Lat, ref CirclePoints[i].X, ref CirclePoints[i].Y, ref RadiusNM, ref bearing);
			bearing += num;
		}
	}

	public static void CalcPoint_Williams(ref double Lon1, ref double Lat1, ref double out_lon2, ref double out_lat2, ref double distance_NM, ref double bearing)
	{
		double num = distance_NM / 3441.6865234375;
		double num2 = bearing * 0.0174532925199433;
		double num3 = Lat1 * 0.0174532925199433;
		double num4 = Lon1 * 0.0174532925199433;
		double num5 = Math.Sin(num3);
		double num6 = Math.Cos(num3);
		double num7 = Math.Sin(num);
		double num8 = Math.Cos(num);
		try
		{
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void CalcPoint_Williams(ref double Lon1, ref double Lat1, ref double out_lon2, ref double out_lat2, ref float distance_NM, ref double bearing)
	{
		try
		{
			double num = distance_NM / 3441.6865f;
			double num2 = bearing * 0.0174532925199433;
			double num3 = Lat1 * 0.0174532925199433;
			double num4 = Lon1 * 0.0174532925199433;
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3);
			double num7 = Math.Sin(num);
			double num8 = Math.Cos(num);
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(ref double Lon1, ref double Lat1, ref double out_lon2, ref double out_lat2, ref int distance_NM, ref int bearing)
	{
		try
		{
			double num = (float)distance_NM / 3441.6865f;
			double num2 = (double)bearing * 0.0174532925199433;
			double num3 = Lat1 * 0.0174532925199433;
			double num4 = Lon1 * 0.0174532925199433;
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3);
			double num7 = Math.Sin(num);
			double num8 = Math.Cos(num);
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(double Lon1, double Lat1, ref double out_lon2, ref double out_lat2, double distance_NM, float bearing)
	{
		try
		{
			double num = distance_NM / 3441.6865234375;
			double num2 = (double)bearing * 0.0174532925199433;
			double num3 = Lat1 * 0.0174532925199433;
			double num4 = Lon1 * 0.0174532925199433;
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3);
			double num7 = Math.Sin(num);
			double num8 = Math.Cos(num);
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams_NoRef(double Lon1, double Lat1, ref double out_lon2, ref double out_lat2, ref double distance_NM, ref float bearing)
	{
		try
		{
			double num = distance_NM / 3441.6865234375;
			double num2 = (double)bearing * 0.0174532925199433;
			double num3 = Lat1 * 0.0174532925199433;
			double num4 = Lon1 * 0.0174532925199433;
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3);
			double num7 = Math.Sin(num);
			double num8 = Math.Cos(num);
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(double Lon1, double Lat1, ref double out_lon2, ref double out_lat2, float distance_NM, float bearing)
	{
		try
		{
			double num = distance_NM / 3441.6865f;
			double num2 = (double)bearing * 0.0174532925199433;
			double num3 = Lat1 * 0.0174532925199433;
			double num4 = Lon1 * 0.0174532925199433;
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3);
			double num7 = Math.Sin(num);
			double num8 = Math.Cos(num);
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			if ((0u | ((num10 != num10) ? 1u : 0u)) != 0)
			{
				Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
				return;
			}
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(double Lon1, double Lat1, ref double out_lon2, ref double out_lat2, float distance_NM, int bearing)
	{
		double num = distance_NM / 3441.6865f;
		double num2 = (double)bearing * 0.0174532925199433;
		double num3 = Lat1 * 0.0174532925199433;
		double num4 = Lon1 * 0.0174532925199433;
		double num5 = Math.Sin(num3);
		double num6 = Math.Cos(num3);
		double num7 = Math.Sin(num);
		double num8 = Math.Cos(num);
		try
		{
			double num9 = Math.Asin(num5 * num8 + num6 * num7 * Math.Cos(num2));
			double num10 = Math.Atan2(Math.Sin(num2) * num7 * num6, num8 - num5 * Math.Sin(num9));
			double num11 = num4 + num10 + Math.PI;
			double num12 = 6.28318530717959;
			double num13 = num11 - num12 * (double)(int)Math.Round(num11 / num12);
			if (num13 < 0.0)
			{
				num13 += num12;
			}
			num13 -= Math.PI;
			out_lon2 = num13 * 57.2957795130823;
			out_lat2 = num9 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(Lon1, Lat1, ref out_lon2, ref out_lat2, distance_NM, bearing);
			ProjectData.ClearProjectError();
		}
	}

	static Geodesic_EdWilliams()
	{
		Class72.smethod_20();
	}
}
