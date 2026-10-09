using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Collections.Pooled;
using CSMaterial;
using CSMaterial.ClipperLib;
using CSMaterial.ExWorldWind;
using DotSpatial.Topology;
using DotSpatial.Topology.Voronoi;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Simplifynet;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Math2
{
	public class GeopointComparer_SortyByLatitudeAscending : IComparer<GeoPoint>
	{
		internal int Compare(GeoPoint x, GeoPoint y)
		{
			return x.Latitude.CompareTo(y.Latitude);
		}

		int IComparer<GeoPoint>.Compare(GeoPoint x, GeoPoint y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(x, y);
		}

		static GeopointComparer_SortyByLatitudeAscending()
		{
			Class72.smethod_20();
		}
	}

	public class GeopointComparer_SortyByLongitudeAscending : IComparer<GeoPoint>
	{
		internal int Compare(GeoPoint x, GeoPoint y)
		{
			return x.Longitude.CompareTo(y.Longitude);
		}

		int IComparer<GeoPoint>.Compare(GeoPoint x, GeoPoint y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(x, y);
		}

		static GeopointComparer_SortyByLongitudeAscending()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__77-0
	{
		public TList<List<Geopoint_Struct[]>> $VB$Local_theBag;

		public _Closure$__77-0(_Closure$__77-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theBag = arg0.$VB$Local_theBag;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(List<Geopoint_Struct[]> theChunk)
		{
			$VB$Local_theBag.Add(smethod_2(theChunk));
		}

		static _Closure$__77-0()
		{
			Class72.smethod_20();
		}
	}

	public const double MAX_DOUBLE = 1.79769313486231E+308;

	public const double Math_PI = Math.PI;

	public const double PI_by_180 = Math.PI / 180.0;

	private static double double_0;

	private static int int_0;

	static Math2()
	{
		Class72.smethod_20();
		double_0 = 1.0 / 60.0;
		int_0 = 1000;
	}

	internal static double Tand(double X)
	{
		return Math.Tan(0.0174532925199433 * X);
	}

	internal static double Tand(float X)
	{
		return Math.Tan(0.0174532925199433 * (double)X);
	}

	internal static double Sind(double X)
	{
		return Math.Sin(0.0174532925199433 * X);
	}

	internal static double Sind(float X)
	{
		return Math.Sin(0.0174532925199433 * (double)X);
	}

	internal static double Cosd(double X)
	{
		return Math.Cos(0.0174532925199433 * X);
	}

	internal static double Cosd(float X)
	{
		return Math.Cos(0.0174532925199433 * (double)X);
	}

	internal static double Arccosd(double X)
	{
		if (X == 1.0)
		{
			return 0.0;
		}
		if (X == -1.0)
		{
			return 180.0;
		}
		return 57.2957795130823 * Math.Atan2(0.0 - X, Math.Sqrt(1.0 - X * X)) + 90.0;
	}

	internal static double Arcsind(double X)
	{
		if (X == 1.0)
		{
			return 90.0;
		}
		if (X == -1.0)
		{
			return 270.0;
		}
		return 57.2957795130823 * Math.Atan2(X, Math.Sqrt((0.0 - X) * X + 1.0));
	}

	internal static double Arctand(double X)
	{
		if (X == 1.0)
		{
			return 45.0;
		}
		if (X == -1.0)
		{
			return -45.0;
		}
		return 57.2957795130823 * Math.Atan(X);
	}

	internal static double FindMiddleBearing(double bearing1, double bearing2)
	{
		bearing1 %= 360.0;
		bearing2 %= 360.0;
		if (Math.Abs(bearing1 - bearing2) > 180.0)
		{
			double num = bearing1;
			bearing1 = bearing2;
			bearing2 = num;
			if (bearing1 >= bearing2)
			{
				bearing2 += 360.0;
			}
			else
			{
				bearing1 += 360.0;
			}
		}
		return (bearing1 + bearing2) / 2.0 % 360.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double NormalizeBearing(double X)
	{
		X %= 360.0;
		if (X < 0.0)
		{
			X += 360.0;
		}
		return X;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static float NormalizeBearing(float X)
	{
		X %= 360f;
		if (X < 0f)
		{
			X += 360f;
		}
		return X;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int NormalizeBearing(int X)
	{
		X %= 360;
		if (X < 0)
		{
			X += 360;
		}
		return X;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static float NormalizeRoll(float x)
	{
		if (x > 90f)
		{
			return 90f - x;
		}
		if (x < -90f)
		{
			return -90f - x;
		}
		return x;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double NormalizeLatitude(double X)
	{
		X = (X + 90.0) % 360.0 - 90.0;
		if (!(X > 90.0))
		{
			if (!(X < -90.0))
			{
				return X;
			}
			return -180.0 - X;
		}
		return 180.0 - X;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double NormalizeLongitude(double X)
	{
		if (X <= 180.0)
		{
			if (X <= -180.0)
			{
				return X + 360.0;
			}
			return X;
		}
		return X - 360.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double NormalizeLongitudePreserveNegative180(double X)
	{
		if (X > 180.0)
		{
			return X - 360.0;
		}
		if (X < -180.0)
		{
			return X + 360.0;
		}
		return X;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static float NormalizeLongitude(float X)
	{
		if (X <= 180f)
		{
			if (X <= -180f)
			{
				return X + 360f;
			}
			return X;
		}
		return X - 360f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Distance_To_AngularDegrees(double theDistance_nm)
	{
		return theDistance_nm * double_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double AngularDegrees_To_Distance(double theDistance_Deg)
	{
		return theDistance_Deg * 60.0;
	}

	internal static double CalcDist_Angular(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		CSMaterial.ExWorldWind.Angle latA = default(CSMaterial.ExWorldWind.Angle);
		CSMaterial.ExWorldWind.Angle lonA = default(CSMaterial.ExWorldWind.Angle);
		CSMaterial.ExWorldWind.Angle latB = default(CSMaterial.ExWorldWind.Angle);
		CSMaterial.ExWorldWind.Angle lonB = default(CSMaterial.ExWorldWind.Angle);
		latA.Degrees = Lat1;
		lonA.Degrees = Lon1;
		latB.Degrees = Lat2;
		lonB.Degrees = Lon2;
		return World.ApproxAngularDistance(latA, lonA, latB, lonB).Degrees;
	}

	internal static float CalcDist(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double num = Lat1 * 0.0174532925199433;
		double num2 = Lat2 * 0.0174532925199433;
		double num3 = Math.Sin(num) * Math.Sin(num2) + Math.Cos(num) * Math.Cos(num2) * Math.Cos((Lon2 - Lon1) * 0.0174532925199433);
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		if (num3 < -1.0)
		{
			num3 = -1.0;
		}
		float num4 = (float)(Math.Acos(num3) * 57.2957795130823 * 60.0);
		if (num4 == 0f && Lat1 != Lat2 && Lon1 != Lon2)
		{
			num4 = (float)MercatorProjection.SlantRangeNM(new MercatorProjection.TCoord(Lat1, Lon1), new MercatorProjection.TCoord(Lat2, Lon2));
		}
		return num4;
	}

	internal static float CalcDist(double double_1, double double_2, double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double num = Lat2 * 0.0174532925199433;
		double num2 = double_1 * Math.Sin(num) + double_2 * Math.Cos(num) * Math.Cos((Lon2 - Lon1) * 0.0174532925199433);
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		if (num2 < -1.0)
		{
			num2 = -1.0;
		}
		float num3 = (float)(Math.Acos(num2) * 57.2957795130823 * 60.0);
		if (num3 == 0f && Lat1 != Lat2 && Lon1 != Lon2)
		{
			num3 = (float)MercatorProjection.SlantRangeNM(new MercatorProjection.TCoord(Lat1, Lon1), new MercatorProjection.TCoord(Lat2, Lon2));
		}
		return num3;
	}

	public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
	{
		double num = lat1 * CSMath.PI_dividedBy_180;
		double num2 = lon1 * CSMath.PI_dividedBy_180;
		double num3 = lat2 * CSMath.PI_dividedBy_180;
		double num4 = lon2 * CSMath.PI_dividedBy_180;
		double num5 = num3 - num;
		double num6 = num4 - num2;
		double num7 = Math.Sin(num5 / 2.0) * Math.Sin(num5 / 2.0) + Math.Cos(num) * Math.Cos(num3) * Math.Sin(num6 / 2.0) * Math.Sin(num6 / 2.0);
		return 2.0 * Math.Atan2(Math.Sqrt(num7), Math.Sqrt(1.0 - num7)) * 3441.6865234375;
	}

	internal static float CalcDist_Vicenty(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		float num = (float)Math.Abs(Arccosd(Sind(Lat1) * Sind(Lat2) + Cosd(Lat1) * Cosd(Lat2) * Cosd(Lon2 - Lon1)) * 60.0);
		if (float.IsNaN(num))
		{
			num = 0f;
		}
		if (num == 0f && Lat1 != Lat2 && Lon1 != Lon2)
		{
			num = (float)Geodesic_Vincenty.SlantRangeNM(new Geodesic_Vincenty.TCoord(Lat1, Lon1), new Geodesic_Vincenty.TCoord(Lat2, Lon2), 0.0, 0.0);
		}
		return num;
	}

	internal static float CalcDist(Module_Unit.Unit A, GeoPoint Point2, bool? nullable_0 = null)
	{
		if (A.IsActiveUnit && !nullable_0.HasValue)
		{
			nullable_0 = ((ActiveUnit)A).IsOperating();
		}
		GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(nullable_0);
		return CalcDist(A.get_Latitude(hintIsOperating), A.get_Longitude(hintIsOperating), Point2.Latitude, Point2.Longitude);
	}

	internal static float CalcDist(Module_Unit.Unit A, Module_Unit.Unit B, bool? nullable_0 = null, bool? nullable_1 = null)
	{
		if (A.IsActiveUnit && !nullable_0.HasValue)
		{
			nullable_0 = ((ActiveUnit)A).IsOperating();
		}
		if (B.IsActiveUnit && !nullable_1.HasValue)
		{
			nullable_1 = ((ActiveUnit)B).IsOperating();
		}
		GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(nullable_0);
		GlobalVariables.BooleanObject hintIsOperating2 = Misc.ToBooleanObject(nullable_1);
		return CalcDist(A.get_Latitude(hintIsOperating), A.get_Longitude(hintIsOperating), B.get_Latitude(hintIsOperating2), B.get_Longitude(hintIsOperating2));
	}

	internal static float CalcDist(GeoPoint Point1, GeoPoint Point2)
	{
		return CalcDist(Point1.Latitude, Point1.Longitude, Point2.Latitude, Point2.Longitude);
	}

	internal static float CalcDist(ref Geopoint_Struct Point1, ref Geopoint_Struct Point2)
	{
		return CalcDist(Point1.Latitude, Point1.Longitude, Point2.Latitude, Point2.Longitude);
	}

	internal static float CalcDist_Slant_Cartesian(Geopoint_Struct Point1, Geopoint_Struct point2)
	{
		return CalcDist_Slant_Cartesian(Point1.Latitude, Point1.Longitude, Point1.Altitude, point2.Latitude, point2.Longitude, point2.Altitude);
	}

	internal static float CalcDist_Slant_Cartesian(double Lat1, double Lon1, double Alt1, double Lat2, double Lon2, double Alt2)
	{
		double X = default(double);
		double Y = default(double);
		double Z = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(Lat1, Lon1, Alt1, ref X, ref Y, ref Z);
		double X2 = default(double);
		double Y2 = default(double);
		double Z2 = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(Lat2, Lon2, Alt2, ref X2, ref Y2, ref Z2);
		double num = X2 - X;
		double num2 = Y2 - Y;
		double num3 = Z2 - Z;
		return (float)(Math.Sqrt(num * num + num2 * num2 + num3 * num3) / 1852.0);
	}

	public static double CalcDist_Slant_Cartesian_Double(Module_Unit.Unit A, Module_Unit.Unit B)
	{
		return CalcDist_Slant_Cartesian_Double(A.get_Latitude((GlobalVariables.BooleanObject)null), A.get_Longitude((GlobalVariables.BooleanObject)null), A.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), B.get_Latitude((GlobalVariables.BooleanObject)null), B.get_Longitude((GlobalVariables.BooleanObject)null), B.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
	}

	public static double CalcDist_Slant_Cartesian_Double(double Lat1, double Lon1, double Alt1, double Lat2, double Lon2, double Alt2)
	{
		double X = default(double);
		double Y = default(double);
		double Z = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(Lat1, Lon1, Alt1, ref X, ref Y, ref Z);
		double X2 = default(double);
		double Y2 = default(double);
		double Z2 = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(Lat2, Lon2, Alt2, ref X2, ref Y2, ref Z2);
		double num = X2 - X;
		double num2 = Y2 - Y;
		double num3 = Z2 - Z;
		return Math.Sqrt(num * num + num2 * num2 + num3 * num3) / 1852.0;
	}

	internal static float CalcAzimuth(Geopoint_Struct Point1, Geopoint_Struct Point2)
	{
		return CalcAzimuth(Point1.Latitude, Point1.Longitude, Point2.Latitude, Point2.Longitude);
	}

	internal static float CalcAzimuth(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		double num = Lat1 * (Math.PI / 180.0);
		double num2 = Lon1 * (Math.PI / 180.0);
		double num3 = Lat2 * (Math.PI / 180.0);
		double num4 = Lon2 * (Math.PI / 180.0) - num2;
		double num5 = Math.Cos(num3);
		double num6 = Math.Sin(num3);
		double num7 = Math.Cos(num);
		double num8 = Math.Sin(num);
		double y = Math.Sin(num4) * num5;
		double x = num7 * num6 - num8 * num5 * Math.Cos(num4);
		double num9 = Math.Atan2(y, x) * 180.0 / Math.PI;
		if (num9 < 0.0)
		{
			num9 += 360.0;
		}
		return (float)num9;
	}

	public static void CalcPoint_Vincenty(double Lon1, double Lat1, ref double Lon2, ref double Lat2, double Distance, double Bearing)
	{
		Geodesic_Vincenty.fw_vincenty_wgs84_2(Lat1, Lon1, ref Lat2, ref Lon2, Bearing, Distance);
	}

	internal static bool ValidateLongitude(double theLon)
	{
		if (theLon < -180.0)
		{
			return false;
		}
		return theLon <= 180.0;
	}

	internal static bool ValidateLatitude(double theLat)
	{
		if (theLat < -90.0)
		{
			return false;
		}
		return theLat <= 90.0;
	}

	public static GeoPoint RandomCornerWithinThisArea(IEnumerable<GeoPoint> theArea, double CurrentLoc_Lat, double CurrentLoc_Lon, bool BiasTowardsFarCorners)
	{
		int num = theArea.Count();
		if (!BiasTowardsFarCorners)
		{
			return theArea.ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num));
		}
		IEnumerable<GeoPoint> source = from theGP in theArea
			select (theGP) into theGP
			orderby theGP.RangeToPoint_Horiz(CurrentLoc_Lon, CurrentLoc_Lat)
			select theGP;
		if (GameGeneral.GlobalRNG.Next(0, 1001) > 250)
		{
			int num2 = (int)Math.Ceiling((double)theArea.Count() / 2.0);
			return source.Skip(num - num2).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num2));
		}
		int num3 = (int)Math.Ceiling((double)theArea.Count() / 2.0);
		return source.Take(num3).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num3));
	}

	public static Geopoint_Struct RandomCornerWithinThisArea(PooledList<Geopoint_Struct> theArea, double CurrentLoc_Lat, double CurrentLoc_Lon, bool BiasTowardsFarCorners)
	{
		int count = theArea.Count;
		if (!BiasTowardsFarCorners)
		{
			return theArea[GameGeneral.GlobalRNG.Next(0, count)];
		}
		IEnumerable<Geopoint_Struct> source = from theGP in theArea
			select (theGP) into theGP
			orderby theGP.RangeToPoint_Horiz(CurrentLoc_Lon, CurrentLoc_Lat)
			select theGP;
		if (GameGeneral.GlobalRNG.Next(0, 1001) > 250)
		{
			int num = (int)Math.Ceiling((double)theArea.Count / 2.0);
			return source.Skip(count - num).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num));
		}
		int num2 = (int)Math.Ceiling((double)theArea.Count / 2.0);
		return source.Take(num2).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num2));
	}

	public static Geopoint_Struct RandomCornerWithinThisArea(List<Geopoint_Struct> theArea, double CurrentLoc_Lat, double CurrentLoc_Lon, bool BiasTowardsFarCorners)
	{
		int count = theArea.Count;
		if (!BiasTowardsFarCorners)
		{
			return theArea[GameGeneral.GlobalRNG.Next(0, count)];
		}
		IEnumerable<Geopoint_Struct> source = from theGP in theArea
			select (theGP) into theGP
			orderby theGP.RangeToPoint_Horiz(CurrentLoc_Lon, CurrentLoc_Lat)
			select theGP;
		if (GameGeneral.GlobalRNG.Next(0, 1001) > 250)
		{
			int num = (int)Math.Ceiling((double)theArea.Count / 2.0);
			return source.Skip(count - num).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num));
		}
		int num2 = (int)Math.Ceiling((double)theArea.Count / 2.0);
		return source.Take(num2).ElementAtOrDefault(GameGeneral.GlobalRNG.Next(0, num2));
	}

	public static PooledList<Geopoint_Struct> SimplifyArea(PooledList<Geopoint_Struct> theArea)
	{
		Geopoint_Struct geopoint_Struct = Misc.Center(theArea);
		new Geodesic_Vincenty.TLocalTM(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
		int count = theArea.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		bool flag = false;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200088", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 1;
				}
				else
				{
					num2 = 1;
				}
				flag = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length != 0)
		{
			if (flag)
			{
				array = array.Where([SpecialName] (Simplifynet.Point p) => p != null).ToArray();
				array = (Simplifynet.Point[])Utils.CopyArray((Array)array, (Array)new Simplifynet.Point[array.Count() + 1]);
			}
			array[array.Count() - 1] = array[0];
			List<Simplifynet.Point> list = SimplifyGeometry(array);
			count = list.Count;
			PooledList<Geopoint_Struct> pooledList = new PooledList<Geopoint_Struct>(count);
			int num3 = count - 1;
			for (int num4 = 0; num4 <= num3; num4++)
			{
				MercatorProjection.TCoord coord = MercatorProjection.toGeoCoord(list[num4].X, list[num4].Y);
				if (MercatorProjection.CheckGeoCoordinate(ref coord))
				{
					pooledList.Add(new Geopoint_Struct(coord.Lon, coord.Lat));
				}
			}
			return pooledList;
		}
		return new PooledList<Geopoint_Struct>();
	}

	public static List<Geopoint_Struct> SimplifyArea(List<Geopoint_Struct> theArea)
	{
		Geopoint_Struct geopoint_Struct = Misc.Center(theArea);
		new Geodesic_Vincenty.TLocalTM(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
		int count = theArea.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		bool flag = false;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200088", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 1;
				}
				else
				{
					num2 = 1;
				}
				flag = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length == 0)
		{
			return new List<Geopoint_Struct>();
		}
		if (flag)
		{
			array = array.Where([SpecialName] (Simplifynet.Point p) => p != null).ToArray();
			array = (Simplifynet.Point[])Utils.CopyArray((Array)array, (Array)new Simplifynet.Point[array.Count() + 1]);
		}
		array[array.Count() - 1] = array[0];
		List<Simplifynet.Point> list = SimplifyGeometry(array);
		count = list.Count;
		List<Geopoint_Struct> list2 = new List<Geopoint_Struct>(count);
		int num3 = count - 1;
		for (int num4 = 0; num4 <= num3; num4++)
		{
			MercatorProjection.TCoord coord = MercatorProjection.toGeoCoord(list[num4].X, list[num4].Y);
			if (MercatorProjection.CheckGeoCoordinate(ref coord))
			{
				list2.Add(new Geopoint_Struct(coord.Lon, coord.Lat));
			}
		}
		return list2;
	}

	public static List<ReferencePoint> SimplifyArea(List<ReferencePoint> theArea)
	{
		Misc.Center(theArea);
		int count = theArea.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200088", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length != 0)
		{
			array[array.Count() - 1] = array[0];
			List<Simplifynet.Point> list = SimplifyGeometry(array);
			count = list.Count;
			List<ReferencePoint> list2 = new List<ReferencePoint>(count);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				MercatorProjection.TCoord coord = MercatorProjection.toGeoCoord(list[j].X, list[j].Y);
				if (MercatorProjection.CheckGeoCoordinate(ref coord))
				{
					list2.Add(new ReferencePoint(coord.Lon, coord.Lat));
				}
			}
			return list2;
		}
		return new List<ReferencePoint>();
	}

	public static List<Simplifynet.Point> SimplifyGeometry(Simplifynet.Point[] thePoly)
	{
		return SimplifyUtility.SimplifyArray(thePoly, 50.0);
	}

	public static Geopoint_Struct RandomPointWithinDistance(double latitude, double longitude, double distanceNm)
	{
		LockRandom lockRandom = GameGeneral.GlobalRNG;
		if (lockRandom == null)
		{
			lockRandom = new LockRandom();
		}
		double num = latitude * (Math.PI / 180.0);
		double num2 = longitude * (Math.PI / 180.0);
		double num3 = distanceNm * Math.Sqrt(lockRandom.NextDouble());
		double num4 = lockRandom.NextDouble() * 2.0 * Math.PI;
		double num5 = Math.Asin(Math.Sin(num) * Math.Cos(num3 / 3440.065) + Math.Cos(num) * Math.Sin(num3 / 3440.065) * Math.Cos(num4));
		double num6 = num2 + Math.Atan2(Math.Sin(num4) * Math.Sin(num3 / 3440.065) * Math.Cos(num), Math.Cos(num3 / 3440.065) - Math.Sin(num) * Math.Sin(num5));
		double theLat = num5 * (180.0 / Math.PI);
		double num7 = num6 * (180.0 / Math.PI);
		if (num7 < -180.0)
		{
			num7 += 360.0;
		}
		else if (num7 > 180.0)
		{
			num7 -= 360.0;
		}
		return new Geopoint_Struct(num7, theLat);
	}

	public static (Geopoint_Struct, Geopoint_Struct) RandomPointsWithinAreaWithMinDistance(List<ReferencePoint> theArea, double minDistance)
	{
		(Geopoint_Struct, Geopoint_Struct) result;
		if (theArea.Count >= 3)
		{
			try
			{
				List<ReferencePoint> clone = Misc.GetClone(theArea);
				clone.Sort(new GeopointComparer_SortyByLatitudeAscending());
				double latitude = clone[clone.Count - 1].Latitude;
				double latitude2 = clone[0].Latitude;
				clone.Sort(new GeopointComparer_SortyByLongitudeAscending());
				double longitude = clone[clone.Count - 1].Longitude;
				double longitude2 = clone[0].Longitude;
				float num = 0f;
				while (true)
				{
					if (num != (float)int_0)
					{
						num += 1f;
						Geopoint_Struct Point;
						do
						{
							Point = GenerateRandomPointWithParameters(latitude2, latitude, longitude2, longitude, theArea);
						}
						while (Point.HasZeroCoords);
						Geopoint_Struct Point2;
						do
						{
							Point2 = GenerateRandomPointWithParameters(latitude2, latitude, longitude2, longitude, theArea);
						}
						while (Point2.HasZeroCoords);
						if (!((double)CalcDist(ref Point, ref Point2) < minDistance))
						{
							result = (Point, Point2);
							break;
						}
						continue;
					}
					result = default((Geopoint_Struct, Geopoint_Struct));
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 2193857394687489", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = RandomPointsWithinAreaWithMinDistance(theArea, minDistance);
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = default((Geopoint_Struct, Geopoint_Struct));
		}
		return result;
	}

	public static Geopoint_Struct GenerateRandomPointWithParameters(double MinLat, double MaxLat, double MinLon, double MaxLon, List<ReferencePoint> theArea)
	{
		float num = 0f;
		Geopoint_Struct result;
		while (true)
		{
			if (num != (float)int_0)
			{
				num += 1f;
				double num2 = GameGeneral.GlobalRNG.NextDouble();
				double num3 = GameGeneral.GlobalRNG.NextDouble();
				double num4 = MinLon + num2 * (MaxLon - MinLon);
				double num5 = MinLat + num3 * (MaxLat - MinLat);
				if (GeoPoint.IsInsideThisArea(num5, num4, theArea))
				{
					result = new Geopoint_Struct(num4, num5);
					break;
				}
				continue;
			}
			result = default(Geopoint_Struct);
			break;
		}
		return result;
	}

	public static (Geopoint_Struct, Geopoint_Struct) MostDistantPointsWithinArea(List<ReferencePoint> theArea)
	{
		(Geopoint_Struct, Geopoint_Struct) result = default((Geopoint_Struct, Geopoint_Struct));
		if (theArea.Count >= 2)
		{
			try
			{
				double num = -1.0;
				Geopoint_Struct item = default(Geopoint_Struct);
				Geopoint_Struct item2 = default(Geopoint_Struct);
				int num2 = theArea.Count - 2;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = i + 1;
					int num4 = theArea.Count - 1;
					for (int j = num3; j <= num4; j++)
					{
						double num5 = CalcDist(theArea[i], theArea[j]);
						if (num5 > num)
						{
							num = num5;
							item = new Geopoint_Struct(theArea[i].Longitude, theArea[i].Latitude);
							item2 = new Geopoint_Struct(theArea[j].Longitude, theArea[j].Latitude);
						}
					}
				}
				result = (item, item2);
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 2193857394687489435", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = default((Geopoint_Struct, Geopoint_Struct));
		}
		return result;
	}

	public static Geopoint_Struct RandomPointWithinThisArea(List<ReferencePoint> theArea)
	{
		Geopoint_Struct result;
		if (theArea.Count < 3)
		{
			result = default(Geopoint_Struct);
		}
		else
		{
			LockRandom lockRandom = GameGeneral.GlobalRNG;
			if (lockRandom == null)
			{
				lockRandom = new LockRandom();
			}
			try
			{
				List<ReferencePoint> clone = Misc.GetClone(theArea);
				clone.Sort(new GeopointComparer_SortyByLatitudeAscending());
				double latitude = clone[clone.Count - 1].Latitude;
				double latitude2 = clone[0].Latitude;
				clone.Sort(new GeopointComparer_SortyByLongitudeAscending());
				bool flag = default(bool);
				double num4 = default(double);
				double num5 = default(double);
				if (!GeoPoint.PolygonCrossesAntimeridian(theArea))
				{
					double longitude = clone[clone.Count - 1].Longitude;
					double longitude2 = clone[0].Longitude;
					short num = 0;
					while (!flag)
					{
						if (num != short.MaxValue)
						{
							num++;
							double num2 = lockRandom.NextDouble();
							double num3 = lockRandom.NextDouble();
							if (num2 != 0.0 && num3 != 0.0)
							{
								num4 = longitude2 + num2 * (longitude - longitude2);
								num5 = latitude2 + num3 * (latitude - latitude2);
								flag = GeoPoint.IsInsideThisArea(num5, num4, theArea);
								continue;
							}
							result = default(Geopoint_Struct);
						}
						else
						{
							result = default(Geopoint_Struct);
						}
						goto end_IL_002b;
					}
				}
				else
				{
					double longitude3 = clone[0].Longitude;
					double longitude4 = clone[clone.Count - 1].Longitude;
					double num6 = 180.0 - Math.Abs(longitude4) + (180.0 - Math.Abs(longitude3));
					short num7 = 0;
					while (!flag)
					{
						if (num7 != short.MaxValue)
						{
							num7++;
							double num2 = GameGeneral.GlobalRNG.NextDouble();
							double num3 = GameGeneral.GlobalRNG.NextDouble();
							if (num2 != 0.0 && num3 != 0.0)
							{
								num4 = NormalizeLongitude(longitude4 + num2 * num6);
								num5 = latitude2 + num3 * (latitude - latitude2);
								flag = GeoPoint.IsInsideThisArea(num5, num4, theArea);
								continue;
							}
							result = default(Geopoint_Struct);
						}
						else
						{
							result = default(Geopoint_Struct);
						}
						goto end_IL_002b;
					}
				}
				result = new Geopoint_Struct(num4, num5);
				end_IL_002b:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 2193857394687489", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = RandomPointWithinThisArea(theArea);
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static double InterpolateAltitude(double lat1, double lon1, float alt1, double lat2, double lon2, double lat3, double lon3, float alt3)
	{
		double num = (double)CalcDist(lat1, lon1, lat3, lon3) * 1852.0;
		double num2 = (double)CalcDist(lat1, lon1, lat2, lon2) * 1852.0;
		return (double)alt1 + (double)(alt3 - alt1) * (num2 / num);
	}

	public static Geopoint_Struct FindClosestPoint(double outsideLatitude, double outsideLongitude, List<ReferencePoint> Area)
	{
		double num = double.MaxValue;
		Geopoint_Struct result = default(Geopoint_Struct);
		double num2 = 0.01;
		double num3 = Area.Min([SpecialName] (ReferencePoint wp) => wp.Latitude);
		double num4 = Area.Min([SpecialName] (ReferencePoint wp) => wp.Longitude);
		double num5 = Area.Max([SpecialName] (ReferencePoint wp) => wp.Latitude);
		double num6 = Area.Max([SpecialName] (ReferencePoint wp) => wp.Longitude);
		num2 = Math.Min(Math.Abs(num5 - num3), Math.Abs(num6 - num4));
		num2 /= 10.0;
		double num7 = num3;
		double num8 = num5;
		double num9 = num2;
		bool flag = num9 >= 0.0;
		for (double num10 = num7; flag ? (num10 <= num8) : (num10 >= num8); num10 += num9)
		{
			double num11 = num6;
			double num12 = num2;
			bool flag2 = num12 >= 0.0;
			for (double num13 = num4; flag2 ? (num13 <= num11) : (num13 >= num11); num13 += num12)
			{
				if (GeoPoint.IsInsideThisArea(num10, num13, Area))
				{
					double num14 = CalcDist(num10, num13, outsideLatitude, outsideLongitude);
					if (num14 < num)
					{
						num = num14;
						result = new Geopoint_Struct(num13, num10);
					}
				}
			}
		}
		return result;
	}

	public static Geopoint_Struct RandomPointWithinThisArea(List<GeoPoint> theArea)
	{
		Geopoint_Struct result;
		if (theArea.Count < 3)
		{
			result = default(Geopoint_Struct);
		}
		else
		{
			LockRandom lockRandom = GameGeneral.GlobalRNG;
			if (lockRandom == null)
			{
				lockRandom = new LockRandom();
			}
			try
			{
				List<GeoPoint> clone = Misc.GetClone(theArea);
				clone.Sort(new GeopointComparer_SortyByLatitudeAscending());
				double latitude = clone[clone.Count - 1].Latitude;
				double latitude2 = clone[0].Latitude;
				clone.Sort(new GeopointComparer_SortyByLongitudeAscending());
				bool flag = default(bool);
				double num4 = default(double);
				double num5 = default(double);
				if (!GeoPoint.PolygonCrossesAntimeridian(theArea))
				{
					double longitude = clone[clone.Count - 1].Longitude;
					double longitude2 = clone[0].Longitude;
					short num = 0;
					while (!flag)
					{
						if (num != short.MaxValue)
						{
							num++;
							double num2 = lockRandom.NextDouble();
							double num3 = lockRandom.NextDouble();
							if (num2 != 0.0 && num3 != 0.0)
							{
								num4 = longitude2 + num2 * (longitude - longitude2);
								num5 = latitude2 + num3 * (latitude - latitude2);
								flag = GeoPoint.IsInsideThisArea(num5, num4, theArea);
								continue;
							}
							result = default(Geopoint_Struct);
						}
						else
						{
							result = default(Geopoint_Struct);
						}
						goto end_IL_002b;
					}
				}
				else
				{
					double longitude3 = clone[0].Longitude;
					double longitude4 = clone[clone.Count - 1].Longitude;
					double num6 = 180.0 - Math.Abs(longitude4) + (180.0 - Math.Abs(longitude3));
					short num7 = 0;
					while (!flag)
					{
						if (num7 != short.MaxValue)
						{
							num7++;
							double num2 = GameGeneral.GlobalRNG.NextDouble();
							double num3 = GameGeneral.GlobalRNG.NextDouble();
							if (num2 != 0.0 && num3 != 0.0)
							{
								num4 = NormalizeLongitude(longitude4 + num2 * num6);
								num5 = latitude2 + num3 * (latitude - latitude2);
								flag = GeoPoint.IsInsideThisArea(num5, num4, theArea);
								continue;
							}
							result = default(Geopoint_Struct);
						}
						else
						{
							result = default(Geopoint_Struct);
						}
						goto end_IL_002b;
					}
				}
				result = new Geopoint_Struct(num4, num5);
				end_IL_002b:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 3429856782", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = RandomPointWithinThisArea(theArea);
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static bool AreaContainsPole(IEnumerable<GeoPoint> theArea)
	{
		if (GeoPoint.PolygonCrossesAntimeridian(theArea.ToList()))
		{
			List<GeoPoint> list = new List<GeoPoint>();
			foreach (GeoPoint item in theArea)
			{
				list.Add(new GeoPoint(NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
			}
			return GeoPoint.PolygonCrossesAntimeridian(list);
		}
		return false;
	}

	public static bool LineIntersectsArea_DotSpatial(double Lat1, double Lon1, double Lat2, double Lon2, IEnumerable<GeoPoint> theArea, bool HaveToCheckAntimeridian = true)
	{
		int num;
		if (HaveToCheckAntimeridian)
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea.ToList()))
			{
				double lon = NormalizeLongitude(Lon1 + 180.0);
				double lon2 = NormalizeLongitude(Lon2 + 180.0);
				List<GeoPoint> list = new List<GeoPoint>();
				foreach (GeoPoint item in theArea)
				{
					list.Add(new GeoPoint(NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				return LineIntersectsArea_DotSpatial(Lat1, lon, Lat2, lon2, list, HaveToCheckAntimeridian: false);
			}
			num = 2;
		}
		else
		{
			num = 2;
		}
		Coordinate[] array = new Coordinate[num];
		array[0] = new Coordinate(Lon1, Lat1);
		array[1] = new Coordinate(Lon2, Lat2);
		LineString g = new LineString(array);
		int num2 = theArea.Count();
		Coordinate[] array2 = new Coordinate[num2 - 1 + 1];
		int num3 = num2 - 1;
		for (int i = 0; i <= num3; i++)
		{
			GeoPoint geoPoint = theArea.ElementAtOrDefault(i);
			array2[i] = new Coordinate(geoPoint.Longitude, geoPoint.Latitude);
		}
		return new Polygon(new LinearRing(array2)).Intersects(g);
	}

	public static Geopoint_Struct[] GetRectangularArea(double CenterLat, double CenterLon, float theLength_m, float theWidth_m, float LengthBearing)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct4 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct5 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct6 = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(CenterLon, CenterLat, ref geopoint_Struct6.Longitude, ref geopoint_Struct6.Latitude, (float)((double)(theLength_m / 2f) * 0.000539957), NormalizeBearing(LengthBearing + 180f));
		Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct6.Longitude, geopoint_Struct6.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (double)theLength_m * 0.000539957, LengthBearing);
		Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct3.Longitude, geopoint_Struct3.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, (double)(theWidth_m / 2f) * 0.000539957, NormalizeBearing(LengthBearing - 90f));
		Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct3.Longitude, geopoint_Struct3.Latitude, ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (double)(theWidth_m / 2f) * 0.000539957, NormalizeBearing(LengthBearing + 90f));
		Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct6.Longitude, geopoint_Struct6.Latitude, ref geopoint_Struct4.Longitude, ref geopoint_Struct4.Latitude, (double)(theWidth_m / 2f) * 0.000539957, NormalizeBearing(LengthBearing - 90f));
		Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct6.Longitude, geopoint_Struct6.Latitude, ref geopoint_Struct5.Longitude, ref geopoint_Struct5.Latitude, (double)(theWidth_m / 2f) * 0.000539957, NormalizeBearing(LengthBearing + 90f));
		return new Geopoint_Struct[4] { geopoint_Struct, geopoint_Struct2, geopoint_Struct5, geopoint_Struct4 };
	}

	public static bool LineIntersectsArea_Clipper(double Lat1, double Lon1, double Lat2, double Lon2, IEnumerable<GeoPoint> theArea, bool HaveToCheckAntimeridian = true)
	{
		if (HaveToCheckAntimeridian && GeoPoint.PolygonCrossesAntimeridian(theArea.ToList()))
		{
			double lon = NormalizeLongitude(Lon1 + 180.0);
			double lon2 = NormalizeLongitude(Lon2 + 180.0);
			List<GeoPoint> list = new List<GeoPoint>();
			foreach (GeoPoint item in theArea)
			{
				list.Add(new GeoPoint(NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
			}
			return LineIntersectsArea_Clipper(Lat1, lon, Lat2, lon2, list, HaveToCheckAntimeridian: false);
		}
		List<IntPoint> list2 = new List<IntPoint>();
		foreach (GeoPoint item2 in theArea)
		{
			list2.Add(new IntPoint(new IntPoint(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0)));
		}
		List<IntPoint> list3 = new List<IntPoint>();
		list3.Add(new IntPoint(Lon1 * 100000000000000.0, Lat1 * 100000000000000.0));
		list3.Add(new IntPoint(Lon2 * 100000000000000.0, Lat2 * 100000000000000.0));
		Clipper clipper = new Clipper();
		clipper.AddPath(list2, PolyType.ptSubject, Closed: true);
		clipper.AddPath(list3, PolyType.ptClip, Closed: true);
		List<List<IntPoint>> list4 = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctIntersection, list4, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
		return list4.Count > 0;
	}

	public static bool LineIntersectsArea_Clipper(double Lat1, double Lon1, double Lat2, double Lon2, List<Geopoint_Struct> theArea, bool HaveToCheckAntimeridian = true)
	{
		if (HaveToCheckAntimeridian && GeoPoint.PolygonCrossesAntimeridian(theArea.ToList()))
		{
			double lon = NormalizeLongitude(Lon1 + 180.0);
			double lon2 = NormalizeLongitude(Lon2 + 180.0);
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(theArea.Count);
			foreach (Geopoint_Struct item in theArea)
			{
				list.Add(new Geopoint_Struct(NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
			}
			return LineIntersectsArea_Clipper(Lat1, lon, Lat2, lon2, list, HaveToCheckAntimeridian: false);
		}
		List<IntPoint> list2 = new List<IntPoint>();
		foreach (Geopoint_Struct item2 in theArea)
		{
			list2.Add(new IntPoint(new IntPoint(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0)));
		}
		List<IntPoint> list3 = new List<IntPoint>();
		list3.Add(new IntPoint(Lon1 * 100000000000000.0, Lat1 * 100000000000000.0));
		list3.Add(new IntPoint(Lon2 * 100000000000000.0, Lat2 * 100000000000000.0));
		Clipper clipper = new Clipper();
		clipper.AddPath(list2, PolyType.ptSubject, Closed: true);
		clipper.AddPath(list3, PolyType.ptClip, Closed: true);
		List<List<IntPoint>> list4 = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctIntersection, list4, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
		return list4.Count > 0;
	}

	public static bool LineCrossesAntimeridian(double Lat1, double Lon1, double Lat2, double Lon2)
	{
		if (Lon1 >= 0.0 && Lon2 >= 0.0)
		{
			return false;
		}
		if (Lon1 < 0.0 && Lon2 < 0.0)
		{
			return false;
		}
		double value = Math.Min(Lon1, Lon2);
		if (Math.Abs(Math.Max(Lon1, Lon2)) + Math.Abs(value) > 180.0)
		{
			return true;
		}
		return false;
	}

	public static List<ReferencePoint> GrowGeopolygon(float ExpansionDistance_metres, List<ReferencePoint> theArea)
	{
		try
		{
			if (ExpansionDistance_metres == 0f)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return theArea;
			}
			if (!Information.IsNothing((object)theArea) && Misc.CrossesAPole(theArea))
			{
				return theArea;
			}
			Misc.Center(theArea);
			List<IntPoint> list = new List<IntPoint>();
			foreach (ReferencePoint item in theArea)
			{
				double num = item.Latitude;
				double num2 = item.Longitude;
				while (num2 > 180.0 || num2 < -180.0)
				{
					num2 = NormalizeLongitude(num2);
				}
				if (num > 90.0)
				{
					num = 90.0;
				}
				if (num < -90.0)
				{
					num = -90.0;
				}
				try
				{
					MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num2, num);
					Coordinate coordinate = new Coordinate(mercatorPixel.x, mercatorPixel.y);
					list.Add(new IntPoint((long)Math.Round(coordinate[0]), (long)Math.Round(coordinate[1])));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 20324532409530495090909", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			list2.Add(list);
			ClipperOffset clipperOffset = new ClipperOffset();
			clipperOffset.AddPaths(list2, JoinType.jtSquare, EndType.etClosedPolygon);
			List<List<IntPoint>> solution = new List<List<IntPoint>>();
			clipperOffset.Execute(ref solution, ExpansionDistance_metres);
			List<List<IntPoint>> list3 = solution;
			List<ReferencePoint> list4 = new List<ReferencePoint>();
			if (list3.Count != 0)
			{
				foreach (IntPoint item2 in list3[0])
				{
					try
					{
						MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(item2.X, item2.Y);
						list4.Add(new ReferencePoint(tCoord.Lon, tCoord.Lat));
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200002", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (list4.Count > 100)
				{
					list4 = SimplifyArea(list4);
				}
				return list4;
			}
			return new List<ReferencePoint>();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 1004935353245325", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static bool PolygonComplex(Vector2[] polygon)
	{
		int num = polygon.Length - 3;
		for (int i = 0; i <= num; i++)
		{
			int num2 = i + polygon.Length - 2;
			if (i >= 2)
			{
				num2 -= i - 1;
			}
			int num3 = i + 2;
			int num4 = num2;
			for (int j = num3; j <= num4; j++)
			{
				if (smethod_0(polygon[i], polygon[i + 1], polygon[j % polygon.Length], polygon[(j + 1) % polygon.Length]))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool smethod_0(Vector2 vector2_0, Vector2 vector2_1, Vector2 vector2_2, Vector2 vector2_3)
	{
		Vector2 vector = vector2_1 - vector2_0;
		Vector2 vector2 = vector2_2 - vector2_3;
		Vector2 vector3 = vector2_0 - vector2_2;
		float num = (float)(vector2.Y * vector3.X - vector2.X * vector3.Y);
		float num2 = (float)(vector.Y * vector2.X - vector.X * vector2.Y);
		float num3 = (float)(vector.X * vector3.Y - vector.Y * vector3.X);
		float num4 = num2;
		bool flag = true;
		int num7;
		if (num2 != 0f)
		{
			if (num4 != 0f)
			{
				if (num2 > 0f)
				{
					int num5;
					if (!(num < 0f))
					{
						if (!(num > num2))
						{
							goto IL_00be;
						}
						num5 = 0;
					}
					else
					{
						num5 = 0;
					}
					flag = (byte)num5 != 0;
				}
				else
				{
					int num6;
					if (!(num > 0f))
					{
						if (!(num < num2))
						{
							goto IL_00be;
						}
						num6 = 0;
					}
					else
					{
						num6 = 0;
					}
					flag = (byte)num6 != 0;
				}
				goto IL_00be;
			}
			num7 = 0;
		}
		else
		{
			num7 = 0;
		}
		flag = (byte)num7 != 0;
		goto IL_00fc;
		IL_00fc:
		return flag;
		IL_00be:
		if (flag && num4 > 0f)
		{
			int num8;
			if (!(num3 < 0f))
			{
				if (!(num3 > num4))
				{
					goto IL_00fc;
				}
				num8 = 0;
			}
			else
			{
				num8 = 0;
			}
			flag = (byte)num8 != 0;
		}
		else
		{
			int num9;
			if (!(num3 > 0f))
			{
				if (!(num3 < num4))
				{
					goto IL_00fc;
				}
				num9 = 0;
			}
			else
			{
				num9 = 0;
			}
			flag = (byte)num9 != 0;
		}
		goto IL_00fc;
	}

	internal static double SlopePercentToDegrees(double SlopePercent)
	{
		double x = 100.0;
		return Math.Atan2(100.0 * SlopePercent, x) * 57.2957795130823;
	}

	public static void SlowFunction()
	{
		smethod_1(1000);
	}

	private static long smethod_1(int int_1)
	{
		int num = 0;
		long num2 = 2L;
		while (num < int_1)
		{
			long num3 = 2L;
			int num4 = 1;
			for (; num3 * num3 <= num2; num3++)
			{
				if (num2 % num3 == 0L)
				{
					num4 = 0;
					break;
				}
			}
			if (num4 > 0)
			{
				num++;
			}
			num2++;
		}
		return num2 - 1L;
	}

	internal static List<Geopoint_Struct> GetAreasIntersections_Clipper(ref Geopoint_Struct[] Area1, ref Geopoint_Struct[] Area2)
	{
		List<Geopoint_Struct> result;
		try
		{
			int num = Area1.Length;
			int num2 = Area2.Length;
			List<IntPoint> list = new List<IntPoint>(num);
			int num3 = num - 1;
			for (int i = 0; i <= num3; i++)
			{
				double longitude = Area1[i].Longitude;
				double latitude = Area1[i].Latitude;
				if (!double.IsNaN(longitude) && !double.IsNaN(latitude) && !(longitude * 100000000000000.0 > 9.223372036854776E+18) && !(latitude * 100000000000000.0 > 9.223372036854776E+18))
				{
					list.Add(new IntPoint((long)Math.Round(longitude * 100000000000000.0), (long)Math.Round(latitude * 100000000000000.0)));
				}
			}
			List<IntPoint> list2 = new List<IntPoint>(num2);
			int num4 = num2 - 1;
			for (int j = 0; j <= num4; j++)
			{
				double longitude2 = Area2[j].Longitude;
				double latitude2 = Area2[j].Latitude;
				if (!double.IsNaN(longitude2) && !double.IsNaN(latitude2) && !(longitude2 * 100000000000000.0 > 9.223372036854776E+18) && !(latitude2 * 100000000000000.0 > 9.223372036854776E+18))
				{
					list2.Add(new IntPoint((long)Math.Round(longitude2 * 100000000000000.0), (long)Math.Round(latitude2 * 100000000000000.0)));
				}
			}
			Clipper clipper = new Clipper();
			clipper.AddPath(list, PolyType.ptSubject, Closed: true);
			clipper.AddPath(list2, PolyType.ptClip, Closed: true);
			List<List<IntPoint>> list3 = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctIntersection, list3, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd) && list3.Count > 0)
			{
				List<IntPoint> list4 = list3[0];
				int count = list4.Count;
				List<Geopoint_Struct> list5 = new List<Geopoint_Struct>(count);
				int num5 = count - 1;
				for (int k = 0; k <= num5; k++)
				{
					IntPoint intPoint = list4[k];
					list5.Add(new Geopoint_Struct
					{
						Latitude = (double)intPoint.Y * 1E-14,
						Longitude = (double)intPoint.X * 1E-14
					});
				}
				result = list5;
			}
			else
			{
				result = new List<Geopoint_Struct>(0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200016", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = Misc.ToList_NoLINQ(Area2);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static List<Geopoint_Struct> GetAreasIntersections_Clipper(ref List<Geopoint_Struct> Area1, ref List<Geopoint_Struct> Area2)
	{
		List<Geopoint_Struct> result;
		try
		{
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(Area1.Count);
			List<Geopoint_Struct> list2 = new List<Geopoint_Struct>(Area2.Count);
			foreach (Geopoint_Struct item2 in Area1)
			{
				Geopoint_Struct item = new Geopoint_Struct(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0);
				list.Add(item);
			}
			foreach (Geopoint_Struct item3 in Area2)
			{
				Geopoint_Struct item = new Geopoint_Struct(item3.Longitude * 100000000000000.0, item3.Latitude * 100000000000000.0);
				list2.Add(item);
			}
			List<IntPoint> list3 = new List<IntPoint>(list.Count);
			foreach (Geopoint_Struct item4 in list)
			{
				if (!double.IsNaN(item4.Latitude) && !double.IsNaN(item4.Longitude) && !(item4.Longitude > 9.223372036854776E+18) && !(item4.Latitude > 9.223372036854776E+18))
				{
					list3.Add(new IntPoint((long)Math.Round(item4.Longitude), (long)Math.Round(item4.Latitude)));
				}
			}
			List<IntPoint> list4 = new List<IntPoint>(list2.Count);
			foreach (Geopoint_Struct item5 in list2)
			{
				if (!double.IsNaN(item5.Latitude) && !double.IsNaN(item5.Longitude) && !(item5.Longitude > 9.223372036854776E+18) && !(item5.Latitude > 9.223372036854776E+18))
				{
					list4.Add(new IntPoint((long)Math.Round(item5.Longitude), (long)Math.Round(item5.Latitude)));
				}
			}
			Clipper clipper = new Clipper();
			clipper.AddPath(list3, PolyType.ptSubject, Closed: true);
			clipper.AddPath(list4, PolyType.ptClip, Closed: true);
			List<List<IntPoint>> list5 = new List<List<IntPoint>>();
			clipper.Execute(ClipType.ctIntersection, list5, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
			if (clipper.Execute(ClipType.ctIntersection, list5, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd))
			{
				List<Geopoint_Struct> list6 = new List<Geopoint_Struct>();
				if (list5.Count > 0)
				{
					foreach (IntPoint item6 in list5[0])
					{
						list6.Add(new Geopoint_Struct
						{
							Latitude = (double)item6.Y / 100000000000000.0,
							Longitude = (double)item6.X / 100000000000000.0
						});
					}
					result = list6;
				}
				else
				{
					result = new List<Geopoint_Struct>();
				}
			}
			else
			{
				result = new List<Geopoint_Struct>();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200016", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = Area2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static List<Geopoint_Struct[]> smethod_2(List<Geopoint_Struct[]> list_0)
	{
		List<Geopoint_Struct[]> result;
		try
		{
			Clipper clipper = new Clipper();
			foreach (Geopoint_Struct[] item in list_0)
			{
				List<IntPoint> list = new List<IntPoint>();
				Geopoint_Struct[] array = item;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					Geopoint_Struct geopoint_Struct = array[i];
					Geopoint_Struct geopoint_Struct2 = new Geopoint_Struct(geopoint_Struct.Longitude * 100000000000000.0, geopoint_Struct.Latitude * 100000000000000.0);
					if (!double.IsNaN(geopoint_Struct2.Latitude) && !double.IsNaN(geopoint_Struct2.Longitude) && !(geopoint_Struct2.Longitude > 9.223372036854776E+18) && !(geopoint_Struct2.Latitude > 9.223372036854776E+18))
					{
						list.Add(new IntPoint((long)Math.Round(geopoint_Struct2.Longitude), (long)Math.Round(geopoint_Struct2.Latitude)));
					}
				}
				clipper.AddPath(list, PolyType.ptSubject, Closed: true);
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			if (!clipper.Execute(ClipType.ctUnion, list2, PolyFillType.pftNonZero, PolyFillType.pftNonZero))
			{
				result = new List<Geopoint_Struct[]>();
			}
			else
			{
				List<Geopoint_Struct[]> list3 = new List<Geopoint_Struct[]>();
				if (list2.Count > 0)
				{
					foreach (List<IntPoint> item2 in list2)
					{
						Geopoint_Struct[] array2 = new Geopoint_Struct[item2.Count - 1 + 1];
						int num = item2.Count - 1;
						for (int j = 0; j <= num; j++)
						{
							array2[j] = new Geopoint_Struct
							{
								Latitude = (double)item2[j].Y / 100000000000000.0,
								Longitude = (double)item2[j].X / 100000000000000.0
							};
						}
						list3.Add(array2);
					}
					result = list3;
				}
				else
				{
					result = new List<Geopoint_Struct[]>();
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<Geopoint_Struct[]>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static List<Geopoint_Struct[]> GetAreasUnions_Clipper(List<Geopoint_Struct[]> AreaList, int HowManyThreads = 0)
	{
		_Closure$__77-0 arg = default(_Closure$__77-0);
		_Closure$__77-0 CS$<>8__locals3 = new _Closure$__77-0(arg);
		List<Geopoint_Struct[]> result;
		if (AreaList.Count != 0)
		{
			if (HowManyThreads == 0)
			{
				HowManyThreads = GameGeneral.NumberOfCoreWorkerThreads - 1;
			}
			List<Geopoint_Struct[]>[] source = Misc.smethod_5(AreaList, Math.Max(1, HowManyThreads));
			CS$<>8__locals3.$VB$Local_theBag = new TList<List<Geopoint_Struct[]>>();
			try
			{
				Parallel.ForEach(source, [SpecialName] (List<Geopoint_Struct[]> theChunk) =>
				{
					CS$<>8__locals3.$VB$Local_theBag.Add(smethod_2(theChunk));
				});
				List<List<Geopoint_Struct[]>> list = CS$<>8__locals3.$VB$Local_theBag.ToList();
				List<Geopoint_Struct[]> list2 = new List<Geopoint_Struct[]>();
				foreach (List<Geopoint_Struct[]> item in list)
				{
					list2.AddRange(item);
				}
				result = smethod_2(list2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 20023452465666621347826346", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Geopoint_Struct[]>();
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = new List<Geopoint_Struct[]>();
		}
		return result;
	}

	internal static List<List<GeoPoint>> GetAreasUnions_Clipper(List<List<GeoPoint>> AreaList)
	{
		List<List<GeoPoint>> result;
		try
		{
			Clipper clipper = new Clipper();
			foreach (List<GeoPoint> Area in AreaList)
			{
				List<IntPoint> list = new List<IntPoint>();
				foreach (GeoPoint item in Area)
				{
					GeoPoint geoPoint = new GeoPoint(item.Longitude * 100000000000000.0, item.Latitude * 100000000000000.0);
					if (!double.IsNaN(geoPoint.Latitude) && !double.IsNaN(geoPoint.Longitude) && !(geoPoint.Longitude > 9.223372036854776E+18) && !(geoPoint.Latitude > 9.223372036854776E+18))
					{
						list.Add(new IntPoint((long)Math.Round(geoPoint.Longitude), (long)Math.Round(geoPoint.Latitude)));
					}
				}
				clipper.AddPath(list, PolyType.ptSubject, Closed: true);
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctUnion, list2, PolyFillType.pftNonZero, PolyFillType.pftNonZero))
			{
				List<List<GeoPoint>> list3 = new List<List<GeoPoint>>();
				if (list2.Count > 0)
				{
					foreach (List<IntPoint> item2 in list2)
					{
						List<GeoPoint> list4 = new List<GeoPoint>();
						foreach (IntPoint item3 in item2)
						{
							GeoPoint current2 = new GeoPoint();
							current2.Latitude = (double)item3.Y / 100000000000000.0;
							current2.Longitude = (double)item3.X / 100000000000000.0;
							list4.Add(current2);
						}
						list3.Add(list4);
					}
					result = list3;
				}
				else
				{
					result = new List<List<GeoPoint>>();
				}
			}
			else
			{
				result = new List<List<GeoPoint>>();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200234524656666", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<List<GeoPoint>>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static double ParseDouble(string value)
	{
		string numberGroupSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
		double result;
		if (value.LastIndexOf(numberGroupSeparator) + 4 == value.Count())
		{
			return (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result)) ? 0.0 : result;
		}
		string text = value.Trim().Replace(" ", string.Empty).Replace(",", ".");
		string[] source = text.Split(new char[1] { '.' });
		if (source.Count() > 1)
		{
			text = string.Join(string.Empty, source.Take(source.Count() - 1).ToArray());
			text = $"{text}.{source.Last()}";
		}
		return double.Parse(text, CultureInfo.InvariantCulture);
	}

	internal static double Geo_Bearing((double, double) Start, (double, double) Dest)
	{
		double item = Start.Item1;
		double item2 = Dest.Item1;
		double num = Dest.Item2 - Start.Item2;
		double y = Math.Sin(num) * Math.Cos(item2);
		double x = Math.Cos(item) * Math.Sin(item2) - Math.Sin(item) * Math.Cos(item2) * Math.Cos(num);
		return Math.Atan2(y, x);
	}

	internal static (double, double) Geo_Intercept((double, double) LatLon1Start, (double, double) valueTuple_0, (double, double) LatLon2Start, (double, double) valueTuple_1)
	{
		double item = LatLon1Start.Item1;
		double item2 = LatLon1Start.Item2;
		double item3 = LatLon2Start.Item1;
		double item4 = LatLon2Start.Item2;
		double num = Geo_Bearing(LatLon1Start, valueTuple_0);
		double num2 = Geo_Bearing(LatLon2Start, valueTuple_1);
		double num3 = item3 - item;
		double num4 = item4 - item2;
		double num5 = 2.0 * Math.Asin(Math.Sqrt(Math.Sin(num3 / 2.0) * Math.Sin(num3 / 2.0) + Math.Cos(item) * Math.Cos(item3) * Math.Sin(num4 / 2.0) * Math.Sin(num4 / 2.0)));
		(double, double) result;
		if (num5 == 0.0)
		{
			result = default((double, double));
		}
		else
		{
			double num6 = Math.Acos((Math.Sin(item3) - Math.Sin(item) * Math.Cos(num5)) / (Math.Sin(num5) * Math.Cos(item)));
			if (double.IsNaN(num6))
			{
				num6 = 0.0;
			}
			double num7 = Math.Acos((Math.Sin(item) - Math.Sin(item3) * Math.Cos(num5)) / (Math.Sin(num5) * Math.Cos(item3)));
			double num8;
			double num9;
			if (Math.Sin(item4 - item2) > 0.0)
			{
				num8 = num6;
				num9 = Math.PI * 2.0 - num7;
			}
			else
			{
				num8 = Math.PI * 2.0 - num6;
				num9 = num7;
			}
			double num10 = (num - num8 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			double num11 = (num9 - num2 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			if (Math.Sin(num10) == 0.0 && Math.Sin(num11) == 0.0)
			{
				result = default((double, double));
			}
			else if (Math.Sin(num10) * Math.Sin(num11) < 0.0)
			{
				result = default((double, double));
			}
			else
			{
				double d = Math.Acos((0.0 - Math.Cos(num10)) * Math.Cos(num11) + Math.Sin(num10) * Math.Sin(num11) * Math.Cos(num5));
				double num12 = Math.Atan2(Math.Sin(num5) * Math.Sin(num10) * Math.Sin(num11), Math.Cos(num11) + Math.Cos(num10) * Math.Cos(d));
				double num13 = Math.Asin(Math.Sin(item) * Math.Cos(num12) + Math.Cos(item) * Math.Sin(num12) * Math.Cos(num));
				double num14 = Math.Atan2(Math.Sin(num) * Math.Sin(num12) * Math.Cos(item), Math.Cos(num12) - Math.Sin(item) * Math.Sin(num13));
				double num15 = item2 + num14;
				num15 = (num15 + Math.PI * 3.0) % (Math.PI * 2.0) - Math.PI;
				result = (num13, num15);
			}
		}
		return result;
	}

	internal static double ApparentSpeedAlongAxisOfObserver(double ObserverAxisBearingDeg, double targetHeadingDeg, double targetSpeed)
	{
		double num = ObserverAxisBearingDeg * 0.0174532925199433;
		double num2 = targetHeadingDeg * 0.0174532925199433;
		double num3 = Math.Cos(num);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num2) * targetSpeed;
		double num6 = Math.Sin(num2) * targetSpeed;
		return num3 * num5 + num4 * num6;
	}

	public static float SpecularReflectionAzimuth(float MirrorBearing, float IncomingAzimuth)
	{
		float num = MathFunctions.AngularDifference(MirrorBearing, IncomingAzimuth);
		float num2 = num;
		if (num2 != 90f && num2 != 270f)
		{
			if (num2 != 0f && num2 != 180f)
			{
				if (num2 > 0f)
				{
					return NormalizeBearing(MirrorBearing + 180f - num);
				}
				if (num2 < 0f)
				{
					return NormalizeBearing(MirrorBearing - 180f + num);
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				float result = default(float);
				return result;
			}
			return NormalizeBearing(IncomingAzimuth + 180f);
		}
		return IncomingAzimuth;
	}

	internal static double AngleOffThisUnitsBoresight_3D(ActiveUnit myUnit, double targetLat, double targetLon, double targetAlt)
	{
		Vector3D b = MathFunctions.GeographicToECEF(myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 6378137.0, 0.00669437999014);
		Vector3D v = MathFunctions.Subtract(MathFunctions.GeographicToECEF(targetLat, targetLon, targetAlt, 6378137.0, 0.00669437999014), b);
		double num = MathFunctions.Magnitude(v);
		if (num >= 1.0)
		{
			Vector3D b2 = MathFunctions.Scale(v, 1.0 / num);
			Vector3D a = MathFunctions.smethod_0(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, myUnit.Attitude_Pitch);
			return Math.Acos(Math.Max(-1.0, Math.Min(1.0, MathFunctions.Dot(a, b2)))) * (180.0 / Math.PI);
		}
		return 0.0;
	}
}
