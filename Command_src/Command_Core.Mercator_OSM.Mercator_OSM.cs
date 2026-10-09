using System;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.Mercator_OSM;

[StandardModule]
internal sealed class Mercator_OSM
{
	private static readonly double double_0;

	private static readonly double double_1;

	private static readonly double double_2;

	private static readonly double double_3;

	private static readonly double double_4;

	private static readonly double double_5;

	private static readonly double double_6;

	private static readonly double double_7;

	static Mercator_OSM()
	{
		Class72.smethod_20();
		double_0 = 6378137.0;
		double_1 = 6356752.3142;
		double_2 = double_1 / double_0;
		double_3 = Math.Sqrt(1.0 - double_2 * double_2);
		double_4 = 0.5 * double_3;
		double_5 = CSMath.PI_dividedBy_180;
		double_6 = 180.0 / Math.PI;
		double_7 = Math.PI / 2.0;
	}

	public static double[] toPixel(double lon, double lat)
	{
		return new double[2]
		{
			lonToX(lon),
			latToY(lat)
		};
	}

	public static double[] toGeoCoord(double x, double y)
	{
		return new double[2]
		{
			xToLon(x),
			yToLat(y)
		};
	}

	public static double lonToX(double lon)
	{
		return double_0 * smethod_1(lon);
	}

	public static double latToY(double lat)
	{
		lat = Math.Min(89.5, Math.Max(lat, -89.5));
		double num = smethod_1(lat);
		double num2 = Math.Sin(num);
		double num3 = double_3 * num2;
		num3 = Math.Pow((1.0 - num3) / (1.0 + num3), double_4);
		double d = Math.Tan(0.5 * (Math.PI / 2.0 - num)) / num3;
		return 0.0 - double_0 * Math.Log(d);
	}

	public static double xToLon(double x)
	{
		return smethod_0(x) / double_0;
	}

	public static double yToLat(double y)
	{
		double num = Math.Exp((0.0 - y) / double_0);
		double num2 = double_7 - 2.0 * Math.Atan(num);
		double num3 = 1.0;
		int num4 = 0;
		while (!(Math.Abs(num3) <= 1E-09) && num4 < 15)
		{
			double num5 = double_3 * Math.Sin(num2);
			num3 = double_7 - 2.0 * Math.Atan(num * Math.Pow((1.0 - num5) / (1.0 + num5), double_4)) - num2;
			num2 += num3;
			num4++;
		}
		return smethod_0(num2);
	}

	private static double smethod_0(double double_8)
	{
		return double_8 * double_6;
	}

	private static double smethod_1(double double_8)
	{
		return double_8 * double_5;
	}
}
