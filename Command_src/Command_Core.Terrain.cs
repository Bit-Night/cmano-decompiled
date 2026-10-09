using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Terrain
{
	public struct TerrainGridCell
	{
		public double Center_Lat;

		public double Center_Lon;

		public double Width_degrees;

		public double Height_degrees;

		public Geopoint_Struct NorthWesternCorner => new Geopoint_Struct(Center_Lon - Width_degrees * 0.5, Center_Lat + Height_degrees * 0.5);

		public Geopoint_Struct NorthEasternCorner => new Geopoint_Struct(Center_Lon + Width_degrees * 0.5, Center_Lat + Height_degrees * 0.5);

		public Geopoint_Struct SouthWesternCorner => new Geopoint_Struct(Center_Lon - Width_degrees * 0.5, Center_Lat - Height_degrees * 0.5);

		public Geopoint_Struct SouthEasternCorner => new Geopoint_Struct(Center_Lon + Width_degrees * 0.5, Center_Lat - Height_degrees * 0.5);

		public TerrainGridCell(double theCenterLat, double theCenterLon, double theWidthDegrees, double theHeightDegrees)
		{
			this = default(TerrainGridCell);
			Center_Lat = theCenterLat;
			Center_Lon = theCenterLon;
			Width_degrees = theWidthDegrees;
			Height_degrees = theHeightDegrees;
		}

		static TerrainGridCell()
		{
			Class72.smethod_20();
		}
	}

	public struct TerrainRasterCell
	{
		public string UniqueKey;

		public double CenterLatitude;

		public double CenterLongitude;

		public short ElevationValue;

		public double Width_degrees;

		public double Height_degrees;

		public Geopoint_Struct NorthWesternCorner => new Geopoint_Struct(CenterLongitude - Width_degrees * 0.5, CenterLatitude + Height_degrees * 0.5);

		public Geopoint_Struct NorthEasternCorner => new Geopoint_Struct(CenterLongitude + Width_degrees * 0.5, CenterLatitude + Height_degrees * 0.5);

		public Geopoint_Struct SouthWesternCorner => new Geopoint_Struct(CenterLongitude - Width_degrees * 0.5, CenterLatitude - Height_degrees * 0.5);

		public Geopoint_Struct SouthEasternCorner => new Geopoint_Struct(CenterLongitude + Width_degrees * 0.5, CenterLatitude - Height_degrees * 0.5);

		static TerrainRasterCell()
		{
			Class72.smethod_20();
		}
	}

	public struct MaxMinRecord
	{
		public short Max;

		public short Min;

		public MaxMinRecord(short theMax, short theMin)
		{
			this = default(MaxMinRecord);
			Max = theMax;
			Min = theMin;
		}

		static MaxMinRecord()
		{
			Class72.smethod_20();
		}
	}

	public static short GlobalMaxTerrainElevation;

	public static bool TerrainHasLoaded;

	internal static string PreferredTerrain;

	internal static BinaryGridProvider BinGridProvider;

	private static List<ITerrainProvider> list_0;

	internal static ITerrainProvider AuthoritativeProvider;

	[ThreadStatic]
	private static List<TerrainGridCell> list_1;

	static Terrain()
	{
		Class72.smethod_20();
		GlobalMaxTerrainElevation = 8850;
		TerrainHasLoaded = false;
		list_0 = new List<ITerrainProvider>();
	}

	public static void InitializeTerrain()
	{
		BinGridProvider = new BinaryGridProvider();
		BinGridProvider.Initialize();
		list_0.Add(BinGridProvider);
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Loaded terrain grids (BGD).");
		}
		PreferredTerrain = "SRTM30PLUS";
		AuthoritativeProvider = BinGridProvider;
		GameGeneral.WriteLogDebugInfoToFile("SRTM30PLUS (BGD) is the active terrain provider.");
	}

	public static void ClearCache()
	{
		if (BinGridProvider != null)
		{
			BinGridProvider.ClearCache();
		}
		foreach (ITerrainProvider item in list_0)
		{
			item.ClearCache();
		}
	}

	public static void CleanUp()
	{
		BinGridProvider = null;
		foreach (ITerrainProvider item in list_0)
		{
			item.DisposeResources();
		}
	}

	public static short GetElevationForGlobeDeformation(double theLat, double theLon)
	{
		return BinGridProvider.GetElevation(theLat, theLon, RequestIsFromGUI: true, UseCaching: false);
	}

	public static short GetElevation(double theLat, double theLon, bool RequestIsFromGUI, Scenario theScen)
	{
		if (theScen != null && theScen.NatureSideExists())
		{
			CustomEnvironmentZone[] customEnvironmentZones = theScen.GetNatureSide().CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				if (customEnvironmentZone.TerrainType != LandCover.LandCoverType.Use_Underlying_Values && GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray) && customEnvironmentZone.HasCustomTerrainHeight)
				{
					return Convert.ToInt16(customEnvironmentZone.TerrainHeight);
				}
			}
		}
		return AuthoritativeProvider.GetElevation(theLat, theLon, RequestIsFromGUI);
	}

	public static short GetElevation(Geopoint_Struct point, bool RequestIsFromGUI, Scenario theScen)
	{
		return GetElevation(point.Latitude, point.Longitude, RequestIsFromGUI, theScen);
	}

	internal static bool GeopointsAreOnSameOrAdjacentCell(double GP1_Lat, double GP1_Lon, double GP2_Lat, double GP2_Lon)
	{
		ITerrainProvider authoritativeProvider = AuthoritativeProvider;
		ITerrainProvider authoritativeProvider2 = AuthoritativeProvider;
		if (authoritativeProvider != authoritativeProvider2)
		{
			return false;
		}
		return authoritativeProvider.GeopointsAreOnSameOrAdjacentCell(GP1_Lat, GP1_Lon, GP2_Lat, GP2_Lon);
	}

	internal static short GetMaxForThisDegCell(double theLat, double theLon)
	{
		return AuthoritativeProvider.GetMaxForThisDegCell(theLat, theLon);
	}

	internal static ConcurrentQueue<TerrainGridCell> GetCellsWithLOS(double ObserverLat, double ObserverLon, float ObserverAlt, float TargetAlt_AGL, float theRadius_NM, Scenario CurrentScen)
	{
		if (list_1 != null)
		{
			list_1.Clear();
		}
		else
		{
			list_1 = new List<TerrainGridCell>();
		}
		list_1 = smethod_0(ObserverLat, ObserverLon, theRadius_NM, ref list_1);
		ConcurrentQueue<TerrainGridCell> concurrentQueue = new ConcurrentQueue<TerrainGridCell>();
		Parallel.ForEach(list_1, [SpecialName] (TerrainGridCell theCell) =>
		{
			short elevation = GetElevation(theCell.Center_Lat, theCell.Center_Lon, RequestIsFromGUI: false, CurrentScen);
			float alt_Dest = (float)Math.Max(0, (int)elevation) + TargetAlt_AGL;
			if (LOS.DetermineLOS(ObserverLat, ObserverLon, ObserverAlt, theCell.Center_Lat, theCell.Center_Lon, alt_Dest, LandMassCheck: false, CurrentScen))
			{
				concurrentQueue.Enqueue(theCell);
			}
		});
		return concurrentQueue;
	}

	private static List<TerrainGridCell> smethod_0(double double_0, double double_1, float float_0, ref List<TerrainGridCell> list_2)
	{
		double out_lat = default(double);
		double out_lon = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref out_lon, ref out_lat, float_0, 270);
		out_lat = default(double);
		double out_lon2 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref out_lon2, ref out_lat, float_0, 90);
		out_lat = default(double);
		double out_lat2 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref out_lat, ref out_lat2, float_0, 0);
		out_lat = default(double);
		double out_lat3 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref out_lat, ref out_lat3, float_0, 180);
		int num = (int)Math.Round(Math.Pow((int)Math.Round(Math2.Distance_To_AngularDegrees(float_0) * 2.0 / (1.0 / 120.0)), 2.0));
		if (list_2 == null)
		{
			list_2 = new List<TerrainGridCell>(num);
		}
		else
		{
			list_2.Clear();
			if (list_2.Capacity < num)
			{
				list_2.Capacity = num;
			}
		}
		double num2 = out_lon;
		out_lat = out_lon2;
		TerrainGridCell item = default(TerrainGridCell);
		for (double num3 = num2; num3 <= out_lat; num3 += 1.0 / 120.0)
		{
			double num4 = out_lat2;
			double num5 = out_lat3;
			for (double num6 = num4; num6 >= num5; num6 += -1.0 / 120.0)
			{
				item.Center_Lon = num3 + 1.0 / 240.0;
				item.Center_Lat = num6 - 1.0 / 240.0;
				if (Math2.CalcDist(item.Center_Lat, item.Center_Lon, double_0, double_1) <= float_0)
				{
					item.Height_degrees = 0.008611111111111111;
					item.Width_degrees = 0.008611111111111111;
					list_2.Add(item);
				}
			}
		}
		return list_2;
	}

	internal static bool DryLandExistsBetweenThesePoints(double StartLat, double StartLon, double EndLat, double EndLon, int CheckInterval_metres, Scenario ParentScen)
	{
		double num = (double)CheckInterval_metres * 0.000539957;
		double num2 = Math2.CalcDist(StartLat, StartLon, EndLat, EndLon);
		double bearing = Math2.CalcAzimuth(StartLat, StartLon, EndLat, EndLon);
		if (GetElevation(StartLat, StartLon, RequestIsFromGUI: false, ParentScen) >= 0)
		{
			return true;
		}
		double distance_NM = default(double);
		double out_lon = default(double);
		double out_lat = default(double);
		do
		{
			distance_NM += num;
			if (!(distance_NM > num2))
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ref StartLon, ref StartLat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				continue;
			}
			if (GetElevation(EndLat, EndLon, RequestIsFromGUI: false, ParentScen) < 0)
			{
				return false;
			}
			return true;
		}
		while (GetElevation(out_lat, out_lon, RequestIsFromGUI: false, ParentScen) < 0);
		return true;
	}

	internal static float GetMaxSlope(double theLat, double theLon, bool RequestIsFromGUI, Scenario CurrentScen)
	{
		float result;
		try
		{
			if (theLat < -90.0 || theLat > 90.0)
			{
				theLat = Math2.NormalizeLatitude(theLat);
			}
			int num;
			if (!(theLon < -180.0) && theLon <= 180.0)
			{
				num = 450;
			}
			else
			{
				theLon = Math2.NormalizeLongitude(theLon);
				num = 450;
			}
			int num2 = num;
			float num3 = (float)((double)num2 * 0.5);
			Geopoint_Struct newPoint_Struct = GeoPoint.GetNewPoint_Struct(theLat, theLon, 315f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct2 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 0f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct3 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 45f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct4 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 90f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct5 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 135f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct6 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 180f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct7 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 225f, (float)((double)num3 * 0.000539957));
			Geopoint_Struct newPoint_Struct8 = GeoPoint.GetNewPoint_Struct(theLat, theLon, 270f, (float)((double)num3 * 0.000539957));
			float value = (float)((double)(short)(GetElevation(newPoint_Struct2.Latitude, newPoint_Struct2.Longitude, RequestIsFromGUI, CurrentScen) - GetElevation(newPoint_Struct6.Latitude, newPoint_Struct6.Longitude, RequestIsFromGUI, CurrentScen)) / (double)num2);
			float value2 = (float)((double)(short)(GetElevation(newPoint_Struct4.Latitude, newPoint_Struct4.Longitude, RequestIsFromGUI, CurrentScen) - GetElevation(newPoint_Struct8.Latitude, newPoint_Struct8.Longitude, RequestIsFromGUI, CurrentScen)) / (double)num2);
			float value3 = (float)((double)(short)(GetElevation(newPoint_Struct3.Latitude, newPoint_Struct3.Longitude, RequestIsFromGUI, CurrentScen) - GetElevation(newPoint_Struct7.Latitude, newPoint_Struct7.Longitude, RequestIsFromGUI, CurrentScen)) / (double)num2);
			float value4 = (float)((double)(short)(GetElevation(newPoint_Struct.Latitude, newPoint_Struct.Longitude, RequestIsFromGUI, CurrentScen) - GetElevation(newPoint_Struct5.Latitude, newPoint_Struct5.Longitude, RequestIsFromGUI, CurrentScen)) / (double)num2);
			float[] obj = new float[4]
			{
				Math.Abs(value2),
				Math.Abs(value),
				Math.Abs(value3),
				Math.Abs(value4)
			};
			float num4 = 0f;
			float[] array = obj;
			foreach (float num5 in array)
			{
				num4 = ((num5 > num4) ? num5 : num4);
			}
			result = num4;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200094", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static TerrainRasterCell GetSingleRasterCell(double theLat, double theLon)
	{
		return AuthoritativeProvider.GetSingleRasterCell(theLat, theLon);
	}

	internal static (bool IsOverland, short? RetrievedElevation) PointIsOverland(double theLat, double theLon)
	{
		return AuthoritativeProvider.PointIsOverland(theLat, theLon);
	}

	public static bool TerrainBlocksLOS(double ObserverLat, double ObserverLon, float theDist, double Distance_Cartesian, double X_S, double Y_S, double Z_S, double deltaX, double deltaY, double deltaZ, float Alt_Src, float Alt_Dest, bool LandMassCheck, bool IgnoreRadarHorizon, Scenario CurrentScen, Side NatureSide)
	{
		return AuthoritativeProvider.TerrainBlocksLOS(theDist, Distance_Cartesian, X_S, Y_S, Z_S, deltaX, deltaY, deltaZ, Alt_Src, Alt_Dest, LandMassCheck, IgnoreRadarHorizon, CurrentScen, NatureSide);
	}

	internal static float LandPercentageInThisSquare(double theLat, double theLon, float Radius_nm)
	{
		if (list_1 == null)
		{
			list_1 = new List<TerrainGridCell>();
		}
		else
		{
			list_1.Clear();
		}
		list_1 = smethod_0(theLat, theLon, Radius_nm, ref list_1);
		int location = 0;
		ITerrainProvider authoritativeProvider = AuthoritativeProvider;
		Parallel.ForEach(list_1, [SpecialName] (TerrainGridCell theCell) =>
		{
			if (authoritativeProvider.PointIsOverland(theLat, theLon).IsOverland)
			{
				Interlocked.Increment(ref location);
			}
		});
		return (float)((double)location / (double)list_1.Count);
	}

	internal static float LandPercentageInThisArea(List<ReferencePoint> thePointList)
	{
		thePointList = (from thePoint in thePointList
			orderby Math.Atan2(thePoint.Longitude, thePoint.Latitude)
			select (thePoint)).ToList();
		GeoPoint geoPoint = new GeoPoint();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		int num8 = thePointList.Count - 1;
		for (int num9 = 0; num9 <= num8; num9++)
		{
			num2 = thePointList[num9].Longitude;
			num3 = thePointList[num9].Latitude;
			num4 = thePointList[num9 + 1].Longitude;
			num5 = thePointList[num9 + 1].Latitude;
			num6 = num2 * num5 - num4 * num3;
			num += num6;
			geoPoint.Longitude += (num2 + num4) * num6;
			geoPoint.Latitude += (num3 + num5) * num6;
			if (num4 - num2 > num7)
			{
				num7 = num4 - num2;
			}
			if (num5 - num3 > num7)
			{
				num7 = num5 - num3;
			}
		}
		num2 = thePointList[thePointList.Count - 1].Longitude;
		num3 = thePointList[thePointList.Count - 1].Latitude;
		num4 = thePointList[0].Longitude;
		num5 = thePointList[0].Latitude;
		num6 = num2 * num5 - num4 * num3;
		num += num6;
		geoPoint.Longitude += (num2 + num4) * num6;
		geoPoint.Latitude += (num3 + num5) * num6;
		num *= 0.5;
		geoPoint.Longitude /= 6.0 * num;
		geoPoint.Latitude /= 6.0 * num;
		return LandPercentageInThisSquare(geoPoint.Latitude, geoPoint.Longitude, Convert.ToSingle(num7));
	}
}
