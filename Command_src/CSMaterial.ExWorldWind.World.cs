using System;

namespace CSMaterial.ExWorldWind;

public class World
{
	private static double double_0;

	private static double double_1;

	public static Angle ApproxAngularDistance(Angle latA, Angle lonA, Angle latB, Angle lonB)
	{
		Angle angle = lonB - lonA;
		double num = Math.Sin((latB - latA).Radians * 0.5);
		double num2 = Math.Sin(angle.Radians * 0.5);
		double d = num * num + Math.Cos(latA.Radians) * Math.Cos(latB.Radians) * num2 * num2;
		return Angle.FromRadians(2.0 * Math.Asin(Math.Min(1.0, Math.Sqrt(d))));
	}

	public static double ApproxAngularDistance(double latA, double lonA, double latB, double lonB)
	{
		double num = lonB - lonA;
		double num2 = Math.Sin((latB - latA) * double_1 * 0.5);
		double num3 = Math.Sin(num * double_1 * 0.5);
		double num4 = Math.Sqrt(num2 * num2 + Math.Cos(latA * double_1) * Math.Cos(latB * double_1) * num3 * num3);
		double num5 = ((!(1.0 >= num4)) ? (2.0 * Math.Asin(1.0)) : (2.0 * Math.Asin(num4)));
		return num5 * double_0;
	}

	public static void smethod_0(float f, Angle lat1, Angle lon1, Angle lat2, Angle lon2, Angle d, out Angle lat, out Angle lon)
	{
		double num = Math.Sin(d.Radians);
		double num2 = Math.Cos(lat1.Radians);
		double num3 = Math.Cos(lat2.Radians);
		double num4 = Math.Sin((double)(1f - f) * d.Radians) / num;
		double num5 = Math.Sin((double)f * d.Radians) / num;
		double num6 = num4 * num2 * Math.Cos(lon1.Radians) + num5 * num3 * Math.Cos(lon2.Radians);
		double num7 = num4 * num2 * Math.Sin(lon1.Radians) + num5 * num3 * Math.Sin(lon2.Radians);
		double y = num4 * Math.Sin(lat1.Radians) + num5 * Math.Sin(lat2.Radians);
		lat = Angle.FromRadians(Math.Atan2(y, Math.Sqrt(num6 * num6 + num7 * num7)));
		lon = Angle.FromRadians(Math.Atan2(num7, num6));
	}

	static World()
	{
		Class72.smethod_20();
		double_0 = 57.2957795130823;
		double_1 = 0.0174532925199433;
	}
}
