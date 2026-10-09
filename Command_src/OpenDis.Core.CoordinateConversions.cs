using System;

namespace OpenDis.Core;

public class CoordinateConversions
{
	public static readonly double RADIANS_TO_DEGREES;

	public static readonly double DEGREES_TO_RADIANS;

	private CoordinateConversions()
	{
	}

	public static double[] xyzToLatLonRadians(double[] xyz)
	{
		double num = xyz[0];
		double num2 = xyz[1];
		double num3 = xyz[2];
		double[] array = new double[3];
		double num4 = 6378137.0;
		double num5 = 6356752.3142;
		double num6 = Math.Sqrt(num * num + num2 * num2);
		double num7 = 0.006694380004260827;
		double num8 = 0.006739496756586903;
		if (num >= 0.0)
		{
			array[1] = Math.Atan(num2 / num);
		}
		else if (num < 0.0 && num2 >= 0.0)
		{
			array[1] = Math.Atan(num2 / num) + Math.PI;
		}
		else
		{
			array[1] = Math.Atan(num2 / num) - Math.PI;
		}
		double num9 = Math.Atan(num4 * num3 / (num5 * num6));
		double num10 = (array[0] = Math.Atan((num3 + num8 * num5 * Math.Pow(Math.Sin(num9), 3.0)) / (num6 - num4 * num7 * Math.Pow(Math.Cos(num9), 3.0))));
		double num11 = num4 * num4 / Math.Sqrt(num4 * num4 * (Math.Cos(num10) * Math.Cos(num10)) + num5 * num5 * (Math.Sin(num10) * Math.Sin(num10)));
		array[2] = num6 / Math.Cos(num10) - num11;
		return array;
	}

	public static double[] xyzToLatLonDegrees(double[] xyz)
	{
		double[] array = xyzToLatLonRadians(xyz);
		array[0] = array[0] * 180.0 / Math.PI;
		array[1] = array[1] * 180.0 / Math.PI;
		return array;
	}

	public static double[] getXYZfromLatLonRadians(double latitude, double longitude, double height)
	{
		double num = Math.Cos(latitude);
		double num2 = Math.Sin(latitude);
		double num3 = 40680631590769.0 / Math.Sqrt(40680631590769.0 * (num * num) + 40408299984087.055 * (num2 * num2));
		double num4 = (num3 + height) * num * Math.Cos(longitude);
		double num5 = (num3 + height) * num * Math.Sin(longitude);
		double num6 = (0.9933056199957392 * num3 + height) * num2;
		return new double[3] { num4, num5, num6 };
	}

	public static double[] getXYZfromLatLonDegrees(double latitude, double longitude, double height)
	{
		return getXYZfromLatLonRadians(latitude * DEGREES_TO_RADIANS, longitude * DEGREES_TO_RADIANS, height);
	}

	static CoordinateConversions()
	{
		Class72.smethod_20();
		RADIANS_TO_DEGREES = 180.0 / Math.PI;
		DEGREES_TO_RADIANS = Math.PI / 180.0;
	}
}
