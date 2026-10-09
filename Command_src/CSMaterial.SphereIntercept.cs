using System;

namespace CSMaterial;

public static class SphereIntercept
{
	private static void smethod_0(double double_0, double double_1, out double double_2, out double double_3, double double_4, double double_5)
	{
		double num = double_4 / 3441.686541;
		double num2 = Math.Sin(double_1);
		double num3 = Math.Cos(double_1);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num);
		double_3 = Math.Asin(num2 * num5 + num3 * num4 * Math.Cos(double_5));
		double num6 = Math.Atan2(Math.Sin(double_5) * num4 * num3, num5 - num2 * Math.Sin(double_3));
		double num7 = double_0 + num6 + Math.PI;
		double num8 = Math.PI * 2.0;
		double_2 = (num7 - num8 * Math.Floor(num7 / num8) - Math.PI) % (Math.PI * 2.0);
		if (double_2 < -Math.PI)
		{
			double_2 += Math.PI * 2.0;
		}
	}

	private static double smethod_1(double double_0, double double_1, double double_2, double double_3)
	{
		double y = Math.Sin(double_2 - double_0) * Math.Cos(double_3);
		double x = Math.Cos(double_1) * Math.Sin(double_3) - Math.Sin(double_1) * Math.Cos(double_3) * Math.Cos(double_2 - double_0);
		return Math.Atan2(y, x);
	}

	private static double smethod_2(double double_0, double double_1, double double_2, double double_3)
	{
		return 3441.686541 * Math.Acos(Math.Sin(double_1) * Math.Sin(double_3) + Math.Cos(double_1) * Math.Cos(double_3) * Math.Cos(Math.Abs(double_1 - double_3)));
	}

	public static double? InterceptHeading_deg(double TargetLat_deg, double TargetLon_deg, double TargetDestinationDistance_nm, double TargetHeading_deg, double TargetVelocity_kts, double InterceptLat_deg, double InterceptLon_deg, double InterceptVelocity_kts)
	{
		double double_ = TargetLat_deg * CSMath.PI_dividedBy_180;
		double double_2 = TargetLon_deg * CSMath.PI_dividedBy_180;
		double double_3 = TargetHeading_deg * CSMath.PI_dividedBy_180;
		double num = InterceptLat_deg * CSMath.PI_dividedBy_180;
		double num2 = InterceptLon_deg * CSMath.PI_dividedBy_180;
		TargetDestinationDistance_nm *= 1.5;
		double num3 = TargetDestinationDistance_nm / 100.0;
		double num4 = 3.4028234663852886E+38;
		double num5 = 1.7014117331926443E+38;
		int num6 = 1;
		double double_4;
		double double_5;
		while (true)
		{
			if (num5 < num4)
			{
				num4 = num5;
				double num7 = num3 * (double)num6;
				smethod_0(double_2, double_, out double_4, out double_5, num7, double_3);
				double num8 = num7 / TargetVelocity_kts;
				double num9 = smethod_2(double_4, double_5, num2, num);
				double num10 = num8 * InterceptVelocity_kts;
				num5 = num9 - num10;
				if (!(num5 >= 0.0))
				{
					break;
				}
				num6++;
				if (num6 > 1000)
				{
					return double.MaxValue;
				}
				continue;
			}
			return null;
		}
		return smethod_1(num2, num, double_4, double_5) * 180.0 / Math.PI;
	}

	static SphereIntercept()
	{
		Class72.smethod_20();
	}
}
