using System;

namespace OpenDIS.Utilities;

public class EulerConversions
{
	private static double double_0;

	private static double double_1;

	public static double getOrientationFromEuler(double lat, double lon, double psi, double theta)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Sin(lon);
		double num3 = Math.Cos(lon);
		double num4 = Math.Cos(lat);
		double num5 = num * num2;
		double num6 = Math.Cos(theta);
		double num7 = Math.Cos(psi);
		double num8 = Math.Sin(psi);
		double num9 = Math.Sin(theta);
		double num10 = num6 * num7;
		double num11 = num6 * num8;
		double num12 = num * num3;
		double y = (0.0 - num2) * num10 + num3 * num11;
		double x = (0.0 - num12) * num10 - num5 * num11 - num4 * num9;
		return Math.Atan2(y, x) * double_0;
	}

	public static double getPitchFromEuler(double lat, double lon, double psi, double theta)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Sin(lon);
		double num3 = Math.Cos(lon);
		double num4 = Math.Cos(lat);
		double num5 = num4 * num3;
		double num6 = num4 * num2;
		double num7 = Math.Cos(theta);
		double num8 = Math.Cos(psi);
		double num9 = Math.Sin(psi);
		double num10 = Math.Sin(theta);
		return Math.Asin(num5 * num7 * num8 + num6 * num7 * num9 - num * num10) * double_0;
	}

	public static double getRollFromEuler(double lat, double lon, double psi, double theta, double phi)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Sin(lon);
		double num3 = Math.Cos(lon);
		double num4 = Math.Cos(lat);
		double num5 = num4 * num3;
		double num6 = num4 * num2;
		double num7 = Math.Cos(theta);
		double num8 = Math.Sin(theta);
		double num9 = Math.Cos(psi);
		double num10 = Math.Sin(psi);
		double num11 = Math.Sin(phi);
		double num12 = Math.Cos(phi);
		double num13 = num11 * num8;
		double num14 = num12 * num8;
		double num15 = num5 * ((0.0 - num12) * num10 + num13 * num9) + num6 * (num12 * num9 + num13 * num10) + num * (num11 * num7);
		double num16 = num5 * (num11 * num10 + num14 * num9) + num6 * ((0.0 - num11) * num9 + num14 * num10) + num * (num12 * num7);
		return Math.Atan2(0.0 - num15, 0.0 - num16) * double_0;
	}

	public static double getThetaFromTaitBryanAngles(double lat, double lon, double yaw, double pitch)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Cos(lat);
		double num3 = Math.Cos(pitch * double_1);
		double num4 = Math.Sin(pitch * double_1);
		double num5 = Math.Cos(yaw * double_1);
		return Math.Asin((0.0 - num2) * num5 * num3 - num * num4);
	}

	public static double getPsiFromTaitBryanAngles(double lat, double lon, double yaw, double pitch)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Sin(lon);
		double num3 = Math.Cos(lon);
		double num4 = Math.Cos(lat);
		double num5 = num4 * num3;
		double num6 = num4 * num2;
		double num7 = num * num3;
		double num8 = num * num2;
		double num9 = Math.Cos(pitch * double_1);
		double num10 = Math.Sin(pitch * double_1);
		double num11 = Math.Sin(yaw * double_1);
		double num12 = Math.Cos(yaw * double_1);
		double x = (0.0 - num2) * num11 * num9 - num7 * num12 * num9 + num5 * num10;
		return Math.Atan2(num3 * num11 * num9 - num8 * num12 * num9 + num6 * num10, x);
	}

	public static double getPhiFromTaitBryanAngles(double lat, double lon, double yaw, double pitch, double roll)
	{
		double num = Math.Sin(lat);
		double num2 = Math.Cos(lat);
		double num3 = Math.Cos(roll * double_1);
		double num4 = Math.Sin(roll * double_1);
		double num5 = Math.Cos(pitch * double_1);
		double num6 = Math.Sin(pitch * double_1);
		double num7 = Math.Sin(yaw * double_1);
		double num8 = Math.Cos(yaw * double_1);
		double y = num2 * ((0.0 - num7) * num3 + num8 * num6 * num4) - num * num5 * num4;
		double x = num2 * (num7 * num4 + num8 * num6 * num3) - num * num5 * num3;
		return Math.Atan2(y, x);
	}

	static EulerConversions()
	{
		Class72.smethod_20();
		double_0 = 57.2957795131;
		double_1 = 0.01745329252;
	}
}
