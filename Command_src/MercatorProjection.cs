using System;
using CSMaterial;

public static class MercatorProjection
{
	public struct MercatorPixel
	{
		public double x;

		public double y;

		public MercatorPixel(double coord_lon, double coord_lat)
		{
			x = lonToX(coord_lon);
			y = latToY(coord_lat);
		}

		static MercatorPixel()
		{
			Class72.smethod_20();
		}
	}

	public struct TCoord
	{
		public double Lat;

		public double Lon;

		public TCoord(double theLat, double theLon)
		{
			Lat = theLat;
			Lon = theLon;
		}

		static TCoord()
		{
			Class72.smethod_20();
		}
	}

	public struct Point3D
	{
		public double X;

		public double Y;

		public double Z;

		public static Point3D operator -(Point3D lhs, Point3D rhs)
		{
			Point3D result = default(Point3D);
			result.X = lhs.X - rhs.X;
			result.Y = lhs.Y - rhs.Y;
			result.Z = lhs.Z - rhs.Z;
			return result;
		}

		public static Point3D operator +(Point3D lhs, Point3D rhs)
		{
			Point3D result = default(Point3D);
			result.X = lhs.X + rhs.X;
			result.Y = lhs.Y + rhs.Y;
			result.Z = lhs.Z + rhs.Z;
			return result;
		}

		public static double operator *(Point3D lhs, Point3D rhs)
		{
			return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
		}

		public static Point3D operator *(double lhs, Point3D rhs)
		{
			Point3D result = default(Point3D);
			result.X = lhs * rhs.X;
			result.Y = lhs * rhs.Y;
			result.Z = lhs * rhs.Z;
			return result;
		}

		public static double Dot(Point3D lhs, Point3D rhs)
		{
			return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
		}

		public double Length()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}

		static Point3D()
		{
			Class72.smethod_20();
		}
	}

	private static readonly double double_0;

	private static readonly double double_1;

	private static readonly double double_2;

	private static readonly double double_3;

	private static readonly double double_4;

	private static readonly double double_5;

	private static readonly double double_6;

	private static readonly double double_7;

	private static readonly double double_8;

	public static MercatorPixel toPixel(TCoord coord)
	{
		return new MercatorPixel
		{
			x = lonToX(coord.Lon),
			y = latToY(coord.Lat)
		};
	}

	public static TCoord toGeoCoord(double x, double y)
	{
		return new TCoord
		{
			Lon = smethod_0(x),
			Lat = yToLat(y)
		};
	}

	public static double lonToX(double lon)
	{
		return double_0 * double_5 * lon;
	}

	public static double latToY(double lat)
	{
		if (lat > 89.9999999999)
		{
			lat = 89.9999999999;
		}
		if (lat < -89.9999999999)
		{
			lat = -89.9999999999;
		}
		double num = double_5 * lat;
		double num2 = Math.Sin(num);
		double num3 = double_3 * num2;
		num3 = Math.Pow((1.0 - num3) / (1.0 + num3), double_4);
		double d = Math.Tan(0.5 * (Math.PI / 2.0 - num)) / num3;
		return 0.0 - double_0 * Math.Log(d);
	}

	private static double smethod_0(double double_9)
	{
		return double_6 * double_9 / double_0;
	}

	public static bool CheckGeoCoordinate(ref TCoord coord)
	{
		if (coord.Lat <= 90.0 && coord.Lat >= -90.0 && coord.Lon <= 180.0)
		{
			return coord.Lon >= -180.0;
		}
		return false;
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
		return double_6 * num2;
	}

	public static double SlantRangeNM(TCoord C1, TCoord C2)
	{
		MercatorPixel mercatorPixel = toPixel(C1);
		MercatorPixel mercatorPixel2 = toPixel(C2);
		return Math.Sqrt(Math.Pow(mercatorPixel.x - mercatorPixel2.x, 2.0) + Math.Pow(mercatorPixel.y - mercatorPixel2.y, 2.0)) / double_8;
	}

	public static double ClosureRate_Geocentric(double _Lat1, double _Lon1, double _Velocity1, double _Course1, double _Lat2, double _Lon2, double _Velocity2, double _Course2)
	{
		MercatorPixel mercatorPixel = new MercatorPixel(_Lon1, _Lat1);
		MercatorPixel mercatorPixel2 = new MercatorPixel(_Lon2, _Lat2);
		VelToVector(_Velocity1, _Course1, out var vx, out var vy);
		VelToVector(_Velocity2, _Course2, out var vx2, out var vy2);
		double num = vx2 - vx;
		double num2 = vy2 - vy;
		double num3 = mercatorPixel2.x - mercatorPixel.x;
		double num4 = mercatorPixel2.y - mercatorPixel.y;
		double num5 = num3 * num + num4 * num2;
		double num6 = Math.Sqrt(num3 * num3 + num4 * num4);
		return 0.0 - num5 / num6;
	}

	public static double ClosureRate_EarthSurface(double _Lat1, double _Lon1, double _Velocity1, double _Course1, double _Lat2, double _Lon2, double _Velocity2, double _Course2)
	{
		VelToVector(_Velocity1, _Course1, out var vx, out var vy);
		VelToVector(_Velocity2, _Course2, out var vx2, out var vy2);
		double x = vx2 - vx;
		double x2 = vy2 - vy;
		return Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(x2, 2.0)) * 3600.0 / double_8;
	}

	public static double BearingTo(TCoord coord1, TCoord coord2)
	{
		MercatorPixel mercatorPixel = new MercatorPixel(coord1.Lon, coord1.Lat);
		MercatorPixel mercatorPixel2 = new MercatorPixel(coord2.Lon, coord2.Lat);
		double y = mercatorPixel2.x - mercatorPixel.x;
		double x = mercatorPixel2.y - mercatorPixel.y;
		double num = Math.Atan2(y, x) * double_6;
		if (num < 0.0)
		{
			num += 360.0;
		}
		return num;
	}

	public static float BearingToUnit_True(double Lat1, double Long1, double Lat2, double Long2)
	{
		return (float)BearingTo(new TCoord(Lat1, Long1), new TCoord(Lat2, Long2));
	}

	public static double ClosureRate(double _Lat1, double _Lon1, double _Velocity1, double _Course1, double _Lat2, double _Lon2, double _Velocity2, double _Course2)
	{
		MercatorPixel mercatorPixel = new MercatorPixel(_Lon1, _Lat1);
		MercatorPixel mercatorPixel2 = new MercatorPixel(_Lon2, _Lat2);
		VelToVector(_Velocity1, _Course1, out var vx, out var vy);
		VelToVector(_Velocity2, _Course2, out var vx2, out var vy2);
		double num = vx2 - vx;
		double num2 = vy2 - vy;
		double num3 = mercatorPixel2.x - mercatorPixel.x;
		double num4 = mercatorPixel2.y - mercatorPixel.y;
		double num5 = num3 * num + num4 * num2;
		double num6 = Math.Sqrt(num3 * num3 + num4 * num4);
		return 0.0 - num5 / num6;
	}

	public static void VelToVector(double velocity, double course, out double vx, out double vy)
	{
		double num = course * Math.PI / 180.0;
		vx = velocity * Math.Sin(num);
		vy = velocity * Math.Cos(num);
	}

	static MercatorProjection()
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
		double_8 = 1852.0;
	}
}
