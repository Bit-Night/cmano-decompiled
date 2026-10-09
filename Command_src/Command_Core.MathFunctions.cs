using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using CSMaterial;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class MathFunctions
{
	public struct Vector
	{
		public readonly double X;

		public readonly double Y;

		public readonly double Z;

		public double Mag => Math.Sqrt(X * X + Y * Y + Z * Z);

		public Vector(double x__1, double y__2, double z__3)
		{
			this = default(Vector);
			X = x__1;
			Y = y__2;
			Z = z__3;
		}

		public static Vector FromSpherical(double r, double th, double ph)
		{
			double x__ = r * Math.Cos(ph) * Math.Cos(th);
			double y__ = r * Math.Cos(ph) * Math.Sin(th);
			double z__ = r * Math.Sin(ph);
			return new Vector(x__, y__, z__);
		}

		internal double Dot(Vector right)
		{
			return Dot(this, right);
		}

		public static double Dot(Vector left, Vector right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		internal Vector Cross(Vector right)
		{
			return Cross(this, right);
		}

		public static Vector Cross(Vector left, Vector right)
		{
			return new Vector(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
		}

		internal Vector Normalize()
		{
			double mag = Mag;
			return this * (1.0 / mag);
		}

		public static Vector operator +(Vector left, Vector right)
		{
			return new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		public static Vector operator -(Vector left, Vector right)
		{
			return new Vector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		public static Vector operator -(Vector unary)
		{
			return new Vector(0.0 - unary.X, 0.0 - unary.Y, 0.0 - unary.Z);
		}

		public static Vector operator *(double left, Vector right)
		{
			return new Vector(right.X * left, right.Y * left, right.Z * left);
		}

		public static Vector operator *(Vector left, double right)
		{
			return right * left;
		}

		static Vector()
		{
			Class72.smethod_20();
		}
	}

	internal static double FindDistanceToSegment(PointF pt, PointF p1, PointF p2, ref PointF ThePerpendicularPoint)
	{
		float num = p2.X - p1.X;
		float num2 = p2.Y - p1.Y;
		if (num == 0f && num2 == 0f)
		{
			ThePerpendicularPoint = p1;
			num = pt.X - p1.X;
			num2 = pt.Y - p1.Y;
			return Math.Sqrt(num * num + num2 * num2);
		}
		float num3 = ((pt.X - p1.X) * num + (pt.Y - p1.Y) * num2) / (num * num + num2 * num2);
		if (num3 < 0f)
		{
			ThePerpendicularPoint = new PointF(p1.X, p1.Y);
			num = pt.X - p1.X;
			num2 = pt.Y - p1.Y;
		}
		else if (num3 > 1f)
		{
			ThePerpendicularPoint = new PointF(p2.X, p2.Y);
			num = pt.X - p2.X;
			num2 = pt.Y - p2.Y;
		}
		else
		{
			ThePerpendicularPoint = new PointF(p1.X + num3 * num, p1.Y + num3 * num2);
			num = pt.X - ThePerpendicularPoint.X;
			num2 = pt.Y - ThePerpendicularPoint.Y;
		}
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static Vector3D GeographicToECEF(double latDeg, double lonDeg, double altMetres, double a, double e2)
	{
		double num = latDeg * Math.PI / 180.0;
		double num2 = lonDeg * Math.PI / 180.0;
		double num3 = Math.Sin(num);
		double num4 = Math.Cos(num);
		double num5 = Math.Sin(num2);
		double num6 = Math.Cos(num2);
		double num7 = a / Math.Sqrt(1.0 - e2 * num3 * num3);
		return new Vector3D((num7 + altMetres) * num4 * num6, (num7 + altMetres) * num4 * num5, (num7 * (1.0 - e2) + altMetres) * num3);
	}

	public static Vector3D smethod_0(double latDeg, double lonDeg, double headingDeg, double pitchDeg)
	{
		double num = latDeg * Math.PI / 180.0;
		double num2 = lonDeg * Math.PI / 180.0;
		double num3 = headingDeg * Math.PI / 180.0;
		double num4 = pitchDeg * Math.PI / 180.0;
		double num5 = Math.Cos(num4) * Math.Sin(num3);
		double num6 = Math.Cos(num4) * Math.Cos(num3);
		double num7 = Math.Sin(num4);
		double num8 = Math.Sin(num);
		double num9 = Math.Cos(num);
		double num10 = Math.Sin(num2);
		double num11 = Math.Cos(num2);
		double num12 = 0.0 - num10;
		double num13 = num11;
		double num14 = 0.0;
		double num15 = (0.0 - num8) * num11;
		double num16 = (0.0 - num8) * num10;
		double num17 = num9;
		double num18 = num9 * num11;
		double num19 = num9 * num10;
		double num20 = num8;
		return new Vector3D(num5 * num12 + num6 * num15 + num7 * num18, num5 * num13 + num6 * num16 + num7 * num19, num5 * num14 + num6 * num17 + num7 * num20);
	}

	public static Vector3D Subtract(Vector3D a, Vector3D b)
	{
		return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	public static Vector3D Scale(Vector3D v, double s)
	{
		return new Vector3D(v.X * s, v.Y * s, v.Z * s);
	}

	public static double Dot(Vector3D a, Vector3D b)
	{
		return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
	}

	public static double Magnitude(Vector3D v)
	{
		return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
	}

	internal static Geopoint_Struct GetMidwayPoint(GeoPoint Point1, GeoPoint Point2)
	{
		return GetMidwayPoint(Point1.Latitude, Point1.Longitude, Point2.Latitude, Point2.Longitude);
	}

	internal static Geopoint_Struct GetMidwayPoint(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		float bearing = Math2.CalcAzimuth(Lat1, Lon1, Lat2, Lon2);
		float num = Math2.CalcDist(Lat1, Lon1, Lat2, Lon2);
		Geopoint_Struct result = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(Lat1, Lon1, ref result.Latitude, ref result.Longitude, num / 2f, bearing);
		return result;
	}

	internal static Geopoint_Struct GetIntermediate3DPoint(GeoPoint StartPoint, GeoPoint EndPoint, double DistanceFromStartPoint)
	{
		return GetIntermediate3DPoint(StartPoint.Latitude, StartPoint.Longitude, StartPoint.Altitude, EndPoint.Latitude, EndPoint.Longitude, EndPoint.Altitude, DistanceFromStartPoint);
	}

	internal static Geopoint_Struct GetIntermediate3DPoint(double StartLat, double StartLon, float StartAlt, double EndLat, double EndLon, float EndAlt, double DistanceFromStartPoint)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		GetIntermediate3DPoint(StartLat, StartLon, StartAlt, EndLat, EndLon, EndAlt, ref result.Latitude, ref result.Longitude, ref result.Altitude, DistanceFromStartPoint);
		return result;
	}

	public static void GetIntermediate3DPoint(double StartLat, double StartLon, float StartAlt, double EndLat, double EndLon, float EndAlt, ref double IntermediateLat, ref double IntermediateLon, ref float IntermediateAlt, double DistanceFromStartPoint)
	{
		double num = Math2.CalcDist(StartLat, StartLon, EndLat, EndLon);
		Geodesic_Vincenty.fw_vincenty_wgs84_2(StartLat, StartLon, ref IntermediateLat, ref IntermediateLon, Math2.CalcAzimuth(StartLat, StartLon, EndLat, EndLon), num);
		IntermediateAlt = (float)((double)StartAlt + DistanceFromStartPoint * (double)(EndAlt - StartAlt) / num);
	}

	public static List<Geopoint_Struct> GetIntervalPointsBetweenTwoCoords_ShortRange(double Lat1, double Lon1, double Lat2, double Lon2, int NumOfIntervals)
	{
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (NumOfIntervals < 1)
		{
			return list;
		}
		double num = (Lat2 - Lat1) / (double)(NumOfIntervals + 1);
		double num2 = (Lon2 - Lon1) / (double)(NumOfIntervals + 1);
		for (int i = 1; i <= NumOfIntervals; i++)
		{
			double theLat = Lat1 + num * (double)i;
			double theLon = Lon1 + num2 * (double)i;
			list.Add(new Geopoint_Struct(theLon, theLat));
		}
		return list;
	}

	public static Geopoint_Struct GetIntermediatePoint_Progress(double Lat1, double Lon1, double Lat2, double Lon2, float ProgressToDestination)
	{
		float bearing = Math2.CalcAzimuth(Lat1, Lon1, Lat2, Lon2);
		float num = Math2.CalcDist(Lat1, Lon1, Lat2, Lon2);
		Geopoint_Struct result = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(Lon1, Lat1, ref result.Longitude, ref result.Latitude, num * ProgressToDestination, bearing);
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float AngularDifference(float OriginalBearing, float NewBearing)
	{
		float num = (NewBearing - OriginalBearing) % 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		if (num > 180f)
		{
			num -= 360f;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float AngularDifference_SmallestValue(float OriginalBearing, float NewBearing)
	{
		return (NewBearing - OriginalBearing + 180f) % 360f - 180f;
	}

	public static float SlantRange_NM_SR(float HorizDistance_NM, float altitudeDiff_m)
	{
		float num = altitudeDiff_m / 1852f;
		return (float)Math.Sqrt(HorizDistance_NM * HorizDistance_NM + num * num);
	}

	internal static bool ArePerpendicular(int Bearing1, int Bearing2)
	{
		Bearing2 = Math2.NormalizeBearing(Bearing2 - Bearing1);
		Bearing1 = 0;
		int result;
		switch (Bearing2)
		{
		case 270:
			result = 1;
			break;
		default:
			return false;
		case 90:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static double Arccos(double x)
	{
		if (x == 1.0)
		{
			return 0.0;
		}
		return Math.Atan((0.0 - x) / Math.Sqrt((0.0 - x) * x + 1.0)) + 2.0 * Math.Atan(1.0);
	}

	internal static double DegreesToRadians(double degrees)
	{
		return degrees * CSMath.PI_dividedBy_180;
	}

	internal static double RadiansToDegrees(double radians)
	{
		return radians * CSMath.Const_180_dividedBy_PI;
	}

	internal static double RadiansToMeters(double radians)
	{
		return 1852.0 * (radians * 10800.0 / 3.14159265358979);
	}

	internal static double RadiansToNM(double radians)
	{
		return radians * 60.0 * CSMath.Const_180_dividedBy_PI;
	}

	internal static double NM_to_Radians(double NauticalMiles)
	{
		return NauticalMiles * 3.14159265358979 / 10800.0;
	}

	internal static double GetBearing(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		if (Lat1 == Lat2 && Lon1 == Lon2)
		{
			return 0.0;
		}
		Lon1 = ((Lon1 + 180.0) % 360.0 + 360.0) % 360.0 - 180.0;
		Lon2 = ((Lon2 + 180.0) % 360.0 + 360.0) % 360.0 - 180.0;
		if (Lon1 == Lon2)
		{
			if (Lat1 < Lat2)
			{
				return 0.0;
			}
			return 180.0;
		}
		double num = PosDist(Lat1, 0.0 - Lon1, Lat2, 0.0 - Lon2);
		double num2 = (Math.Sin(Lat2 * 0.0174532925199433) - Math.Sin(Lat1 * 0.0174532925199433) * Math.Cos(0.0174532925199433 * (num / 60.0))) / (Math.Sin(0.0174532925199433 * (num / 60.0)) * Math.Cos(0.0174532925199433 * Lat1));
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		if (num2 < -1.0)
		{
			num2 = -1.0;
		}
		double num3 = Math.Acos(num2) * 180.0 / Math.PI;
		if (Math.Sin(DegreesToRadians(Lon2 - Lon1)) < 0.0)
		{
			return (360.0 - num3) % 360.0;
		}
		return num3;
	}

	public static double PosDist(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		if (Lat1 == Lat2 && Lon1 == Lon2)
		{
			return 0.0;
		}
		double num = 0.0174532925199433 * Lat1;
		double num2 = 0.0174532925199433 * Lat2;
		double d = 0.0174532925199433 * (Lon2 - Lon1);
		return 60.0 * CSMath.Const_180_dividedBy_PI * Arccos(Math.Sin(num) * Math.Sin(num2) + Math.Cos(num) * Math.Cos(num2) * Math.Cos(d));
	}

	internal static double NewPosLon(double Lat1, double Lon1, double Bearing, double DistanceNM)
	{
		if (Bearing == 0.0)
		{
			Bearing = 360.0;
		}
		double num = DegreesToRadians(90.0 - Lat1);
		DegreesToRadians(Lon1);
		double num2 = 3.14159265358979 * DistanceNM / 10800.0;
		double num3 = DegreesToRadians(Bearing);
		double num4 = 2.0 * Math.Atan(Math.Cos((num - num2) / 2.0) / (Math.Cos((num + num2) / 2.0) * Math.Tan(num3 / 2.0)));
		double num5 = 2.0 * Math.Atan(Math.Sin((num - num2) / 2.0) / (Math.Sin((num + num2) / 2.0) * Math.Tan(num3 / 2.0)));
		double num6 = (num4 - num5) / 2.0;
		double num7 = Lon1 + num6 * CSMath.Const_180_dividedBy_PI;
		if (num7 > 180.0)
		{
			num7 -= 360.0;
		}
		else if (num7 < -180.0)
		{
			num7 += 360.0;
		}
		return num7;
	}

	internal static double MinSecToDeg(double MinSec)
	{
		double num = Math.Abs(MinSec);
		return (double)Sign(MinSec) * (Conversion.Int(num) + Conversion.Int((num - Conversion.Int(num)) * 100.0 + 1E-05) / 60.0 + 100.0 * (num * 100.0 - Conversion.Int(num * 100.0 + 1E-05)) / 3600.0);
	}

	internal static double DegToMinSec(double DecDeg)
	{
		double num = Math.Abs(DecDeg);
		double num2 = Conversion.Int(num);
		double num3 = num - num2;
		double num4 = Conversion.Int(num3 * 60.0);
		double num5 = Conversion.Int((num3 * 60.0 - num4) * 60.0 + 0.5);
		if (num5 == 60.0)
		{
			num4 += 1.0;
			num5 = 0.0;
		}
		return (double)Sign(DecDeg) * (num2 + num4 / 100.0 + num5 / 10000.0);
	}

	internal static string MinSecToString(double MinSec)
	{
		string text = "";
		if (Strings.InStr(Conversions.ToString(MinSec), ",", (CompareMethod)0) > 0)
		{
			text = ",";
		}
		if (Strings.InStr(Conversions.ToString(MinSec), ".", (CompareMethod)0) > 0)
		{
			text = ".";
		}
		if (Operators.CompareString(text, "", false) != 0 && Strings.InStr(Conversions.ToString(MinSec), text, (CompareMethod)0) != 0)
		{
			string text2 = Strings.Left(Conversions.ToString(MinSec), Strings.InStr(Conversions.ToString(MinSec), text, (CompareMethod)0) - 1);
			string text3 = Conversions.ToString(MinSec).Substring(Strings.InStr(Conversions.ToString(MinSec), text, (CompareMethod)0)) + "0000";
			string text4 = text3.Substring(0, 2);
			string text5 = text3.Substring(2, 2);
			return text2 + "°" + text4 + "'" + text5 + "\"";
		}
		return Conversions.ToString(MinSec) + "°";
	}

	internal static double DegToMinTen(double DecDeg)
	{
		double num = Math.Abs(DecDeg);
		double num2 = Conversion.Int(num);
		double num3 = (num - num2) * 0.6;
		return (double)Sign(DecDeg) * (num2 + num3);
	}

	internal static double MinTenToDeg(double MinTen)
	{
		double num = Math.Abs(MinTen);
		return (double)Sign(MinTen) * (Conversion.Int(num) + Conversion.Int((num - Conversion.Int(num)) * 100.0) / 60.0 + 100.0 * (num * 100.0 - Conversion.Int(num * 100.0)) / 6000.0);
	}

	public static double ClosestDistance(double x1, double y1, double x2, double y2, double xp, double yp)
	{
		double num = (y2 - y1) / (x2 - x1);
		double num2 = y1 - x1 * num;
		double num3 = yp + xp / num;
		double num4 = (num3 - num2) * num / (Math.Pow(num, 2.0) + 1.0);
		double num5 = num3 - num4 / num;
		if (y1 != y2)
		{
			if ((num5 - y1) * (double)Sign(y2 - y1) < 0.0)
			{
				return Math.Pow(Math.Pow(yp - y1, 2.0) + Math.Pow(xp - x1, 2.0), 0.5);
			}
			if ((num5 - y2) * (double)Sign(y2 - y1) > 0.0)
			{
				return Math.Pow(Math.Pow(yp - y2, 2.0) + Math.Pow(xp - x2, 2.0), 0.5);
			}
			return Math.Pow(Math.Pow(yp - num5, 2.0) + Math.Pow(xp - num4, 2.0), 0.5);
		}
		if ((num4 - x1) * (double)Sign(x2 - x1) < 0.0)
		{
			return Math.Pow(Math.Pow(yp - y1, 2.0) + Math.Pow(xp - x1, 2.0), 0.5);
		}
		if ((num4 - x2) * (double)Sign(x2 - x1) > 0.0)
		{
			return Math.Pow(Math.Pow(yp - y2, 2.0) + Math.Pow(xp - x2, 2.0), 0.5);
		}
		return Math.Pow(Math.Pow(yp - num5, 2.0) + Math.Pow(xp - num4, 2.0), 0.5);
	}

	public static int Sign(double x)
	{
		if (x < 0.0)
		{
			return -1;
		}
		return 1;
	}

	public static float GetRelativeBearing(float Heading, float AbsoluteBearing)
	{
		float num = Heading;
		float result = Math2.NormalizeBearing(AbsoluteBearing - num);
		num = 0f;
		return result;
	}

	public static Geopoint_Struct Intersection(Geopoint_Struct Point1, double brng1, Geopoint_Struct Point2, double brng2)
	{
		return Intersection(Point1.Latitude, Point1.Longitude, brng1, Point2.Latitude, Point2.Longitude, brng2);
	}

	public static Geopoint_Struct Intersection(double double_0, double double_1, double brng1, double double_2, double double_3, double brng2)
	{
		double num = double_0 * 0.0174532925199433;
		double num2 = double_1 * 0.0174532925199433;
		double num3 = double_2 * 0.0174532925199433;
		double num4 = double_3 * 0.0174532925199433;
		double num5 = brng1 * 0.0174532925199433;
		double num6 = brng2 * 0.0174532925199433;
		double num7 = num3 - num;
		double num8 = num4 - num2;
		double num9 = 2.0 * Math.Asin(Math.Sqrt(Math.Sin(num7 / 2.0) * Math.Sin(num7 / 2.0) + Math.Cos(num) * Math.Cos(num3) * Math.Sin(num8 / 2.0) * Math.Sin(num8 / 2.0)));
		Geopoint_Struct result;
		if (num9 == 0.0)
		{
			result = default(Geopoint_Struct);
		}
		else
		{
			double num10 = Math.Acos((Math.Sin(num3) - Math.Sin(num) * Math.Cos(num9)) / (Math.Sin(num9) * Math.Cos(num)));
			double num11 = Math.Acos((Math.Sin(num) - Math.Sin(num3) * Math.Cos(num9)) / (Math.Sin(num9) * Math.Cos(num3)));
			double num12;
			double num13;
			if (Math.Sin(num4 - num2) > 0.0)
			{
				num12 = num10;
				num13 = Math.PI * 2.0 - num11;
			}
			else
			{
				num12 = Math.PI * 2.0 - num10;
				num13 = num11;
			}
			double num14 = (num5 - num12 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			double num15 = (num13 - num6 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			if ((Math.Sin(num14) == 0.0) & (Math.Sin(num15) == 0.0))
			{
				result = default(Geopoint_Struct);
			}
			else
			{
				if (!(Math.Sin(num14) * Math.Sin(num15) < 0.0))
				{
					double d = Math.Acos((0.0 - Math.Cos(num14)) * Math.Cos(num15) + Math.Sin(num14) * Math.Sin(num15) * Math.Cos(num9));
					double num16 = Math.Atan2(Math.Sin(num9) * Math.Sin(num14) * Math.Sin(num15), Math.Cos(num15) + Math.Cos(num14) * Math.Cos(d));
					double num17 = Math.Asin(Math.Sin(num) * Math.Cos(num16) + Math.Cos(num) * Math.Sin(num16) * Math.Cos(num5));
					double num18 = Math.Atan2(Math.Sin(num5) * Math.Sin(num16) * Math.Cos(num), Math.Cos(num16) - Math.Sin(num) * Math.Sin(num17));
					double num19 = num2 + num18;
					num19 = (num19 + Math.PI) % (Math.PI * 2.0) - Math.PI;
					if (double.IsNaN(num19) || double.IsNaN(num17))
					{
						num19 = 0.0;
						num17 = 0.0;
					}
					return new Geopoint_Struct(num19 * 57.2957795130823, num17 * 57.2957795130823);
				}
				result = default(Geopoint_Struct);
			}
		}
		return result;
	}

	public static float ClosestDistance_Geographic(Geopoint_Struct Point1, Geopoint_Struct Point2, Geopoint_Struct Point3)
	{
		double ph = Point3.Latitude * CSMath.PI_dividedBy_180;
		double th = Point3.Longitude * CSMath.PI_dividedBy_180;
		double ph2 = Point1.Latitude * CSMath.PI_dividedBy_180;
		double th2 = Point1.Longitude * CSMath.PI_dividedBy_180;
		double ph3 = Point2.Latitude * CSMath.PI_dividedBy_180;
		double th3 = Point2.Longitude * CSMath.PI_dividedBy_180;
		Vector vector = Vector.FromSpherical(1.0, th, ph);
		Vector vector2 = Vector.FromSpherical(1.0, th2, ph2);
		Vector right = Vector.FromSpherical(1.0, th3, ph3);
		Vector right2 = vector2.Cross(right);
		Vector right3 = right2.Cross(vector.Cross(right2)).Normalize();
		double num = Math.Acos(vector.Dot(right3));
		return (float)(3441.6865234375 * num);
	}

	public static bool NumberIsOdd(int theNum)
	{
		return theNum % 2 != 0;
	}

	public static GeoPoint Vector_To_GeoPoint(Vector3D vec)
	{
		double Lat = default(double);
		double Lon = default(double);
		double Alt = default(double);
		Geodesic_Vincenty.ApproxCartesianToSpherical(vec.X, vec.Y, vec.Z, ref Lat, ref Lon, ref Alt);
		return new GeoPoint(Lon, Lat, (float)Alt);
	}

	public static Geopoint_Struct Vector_To_Geopoint_Struct(Vector3D vec)
	{
		double Lat = default(double);
		double Lon = default(double);
		double Alt = default(double);
		Geodesic_Vincenty.ApproxCartesianToSpherical(vec.X, vec.Y, vec.Z, ref Lat, ref Lon, ref Alt);
		return new Geopoint_Struct(Lon, Lat, (float)Alt);
	}

	public static Vector3D GeoPoint_To_UnitVector(GeoPoint g)
	{
		Geodesic_Vincenty.Point3D point3D = Geodesic_Vincenty.ApproxSphericalToCartesian(g.Latitude, g.Longitude, 1.0);
		return new Vector3D(point3D.X, point3D.Y, point3D.Z);
	}

	public static Vector3D Geopoint_Struct_To_UnitVector(Geopoint_Struct g)
	{
		Geodesic_Vincenty.Point3D point3D = Geodesic_Vincenty.ApproxSphericalToCartesian(g.Latitude, g.Longitude, 1.0);
		return new Vector3D(point3D.X, point3D.Y, point3D.Z);
	}

	public static double Plus(double A, double B)
	{
		return A + B;
	}

	public static double Times(double A, double B)
	{
		return A * B;
	}

	public static double Times(double A, double B, double C)
	{
		return A * B * C;
	}

	public static double Times(double A, double B, double C, double D)
	{
		return A * B * C * D;
	}

	public static long CombineIntegers(int a, int b)
	{
		return (a << 8) + b;
	}

	static MathFunctions()
	{
		Class72.smethod_20();
	}
}
