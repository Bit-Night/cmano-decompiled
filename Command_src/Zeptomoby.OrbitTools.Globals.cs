using System;

namespace Zeptomoby.OrbitTools;

public static class Globals
{
	public const double Pi = Math.PI;

	public const double TwoPi = Math.PI * 2.0;

	public const double RadsPerDegree = Math.PI / 180.0;

	public const double DegreesPerRad = 180.0 / Math.PI;

	public const double Ae = 1.0;

	public const double Au = 149597870.0;

	public const double HoursPerDay = 24.0;

	public const double MinPerDay = 1440.0;

	public const double SecPerDay = 86400.0;

	public const double OmegaE = 1.00273790934;

	public static double Sqr(double x)
	{
		return x * x;
	}

	public static double Fmod2p(double arg)
	{
		double num = arg % (Math.PI * 2.0);
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	public static double AcTan(double sinx, double cosx)
	{
		if (cosx == 0.0)
		{
			if (sinx > 0.0)
			{
				return Math.PI / 2.0;
			}
			return 4.71238898038469;
		}
		if (cosx > 0.0)
		{
			return Math.Atan(sinx / cosx);
		}
		return Math.PI + Math.Atan(sinx / cosx);
	}

	public static double ToDegrees(this double radians)
	{
		return radians * (180.0 / Math.PI);
	}

	public static double ToRadians(this double degrees)
	{
		return degrees * (Math.PI / 180.0);
	}

	static Globals()
	{
		Class72.smethod_20();
	}
}
