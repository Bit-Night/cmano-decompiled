using System;

public class Util_GPS
{
	private static double double_0;

	private static double double_1;

	private static double double_2;

	public static void GeocentricToGeodetic(double x, double y, double z, out double lat, out double lon, out double alt)
	{
		double num = double_1;
		double num2 = double_2;
		double num3 = 1.0 - num2 * num2 / (num * num);
		double num4 = num * num / (num2 * num2) - 1.0;
		double num5 = num * num;
		double num6 = num2 * num2;
		double num7 = z * z;
		double num8 = num3 * num3;
		double num9 = x * x + y * y;
		double num10 = Math.Sqrt(num9);
		double num11 = num5 - num6;
		double num12 = 54.0 * num6 * num7;
		double num13 = num9 + (1.0 - num3) * num7 - num3 * num11;
		double num14 = num8 * num12 * num9 / (num13 * num13 * num13);
		double num15 = Math.Pow(1.0 + num14 + Math.Sqrt(num14 * num14 + 2.0 * num14), 1.0 / 3.0);
		double num16 = num15 + 1.0 / num15 + 1.0;
		double num17 = num12 / (3.0 * num16 * num16 * num13 * num13);
		double num18 = Math.Sqrt(1.0 + 2.0 * num8 * num17);
		double num19 = (0.0 - num17 * num3 * num10) / (1.0 + num18) + Math.Sqrt(0.5 * num5 * (1.0 + 1.0 / num18) - num17 * (1.0 - num3) * num7 / (num18 * (1.0 + num18)) - 0.5 * num17 * num9);
		num16 = num10 - num3 * num19;
		double num20 = Math.Sqrt(num16 * num16 + num7);
		double num21 = Math.Sqrt(num16 * num16 + (1.0 - num3) * num7);
		num16 = num6 / (num * num21);
		alt = num20 * (1.0 - num16);
		lat = Math.Atan2(z + num4 * num16 * z, num10);
		lon = Math.Atan2(y, x);
		lat = double_0 * lat;
		lon = double_0 * lon;
	}

	static Util_GPS()
	{
		Class72.smethod_20();
		double_0 = 180.0 / Math.PI;
		double_1 = 6378137.0;
		double_2 = 6356752.314245;
	}
}
