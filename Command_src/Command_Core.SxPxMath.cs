using System;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SxPxMath
{
	internal static double cube(double x)
	{
		x = Math.Pow(x, 3.0);
		return x;
	}

	internal static double sqr(double x)
	{
		x *= x;
		return x;
	}

	internal static double modulus(double arg1, double arg2)
	{
		double num = arg1 - Math.Floor(arg1 / arg2) * arg2;
		if (num >= 0.0)
		{
			return num;
		}
		return num + arg2;
	}

	internal static double fmod2p(ref double x)
	{
		double num = x % 6.28318530717958;
		if (num < 0.0)
		{
			num += 6.28318530717958;
		}
		return num;
	}

	internal static double radians(ref double x)
	{
		x *= CSMath.PI_dividedBy_180;
		return x;
	}

	public static void Magnitude(ref SxPxConstants.vector vector)
	{
		vector.v[3] = Math.Sqrt(sqr(vector.v[0]) + sqr(vector.v[1]) + sqr(vector.v[2]));
	}

	internal static double actan(ref double sinx, ref double cosx)
	{
		double num = 0.0;
		if (cosx == 0.0)
		{
			if (sinx <= 0.0)
			{
				return 4.712388980384685;
			}
			return 1.570796326794895;
		}
		if (cosx > 0.0)
		{
			return Math.Atan(sinx / cosx);
		}
		return 3.14159265358979 + Math.Atan(sinx / cosx);
	}

	public static void Calculate_LatLonAlt(double tsince, ref SxPxConstants.vector pos, ref SxPxConstants.geodetic_t geodetic)
	{
		geodetic.theta = actan(ref pos.v[1], ref pos.v[0]);
		double x = geodetic.theta - SxPxTime.ThetaG_JD(tsince);
		geodetic.lon = fmod2p(ref x);
		double cosx = Math.Sqrt(sqr(pos.v[0]) + sqr(pos.v[1]));
		double num = 0.006694317778266723;
		geodetic.lat = actan(ref pos.v[2], ref cosx);
		double lat;
		double num2;
		do
		{
			lat = geodetic.lat;
			num2 = 1.0 / Math.Sqrt(1.0 - num * sqr(Math.Sin(lat)));
			x = pos.v[2] + 6378.135 * num2 * num * Math.Sin(lat);
			geodetic.lat = actan(ref x, ref cosx);
		}
		while (Math.Abs(geodetic.lat - lat) >= 1E-10);
		geodetic.alt = cosx / Math.Cos(geodetic.lat) - 6378.135 * num2;
		if (geodetic.lat > 1.570796326794895)
		{
			geodetic.lat -= 6.28318530717958;
		}
	}

	internal static double Frac(double arg)
	{
		return arg - (double)RadarModel.Floor(arg);
	}

	internal static double Degrees(double arg)
	{
		return arg / 0.0174532925199433;
	}

	static SxPxMath()
	{
		Class72.smethod_20();
	}
}
