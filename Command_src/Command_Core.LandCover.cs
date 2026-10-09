using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using BitMiracle.LibTiff.Classic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class LandCover
{
	public enum LandCoverType : byte
	{
		Water = 0,
		Evergreen_Needleleaf_forest = 1,
		Evergreen_Broadleaf_forest = 2,
		Deciduous_Needleleaf_forest = 3,
		Deciduous_Broadleaf_forest = 4,
		Mixed_forest = 5,
		Closed_shrublands = 6,
		Open_shrublands = 7,
		Woody_savannas = 8,
		Savannas = 9,
		Grasslands = 10,
		Permanent_wetlands = 11,
		Croplands = 12,
		UrbanAndBuiltUp = 13,
		CroplandNaturalVegetationMosaic = 14,
		SnowAndIce = 15,
		BarrenOrSparselyVegetated = 16,
		Unclassified = 254,
		Use_Underlying_Values = byte.MaxValue,
		Urban_CloseInnerCity = 201,
		Urban_SpacedHighRise = 202,
		Urban_AttachedHouses = 203,
		Urban_CloseIndustrial = 204,
		Urban_SpacedApartments = 205,
		Urban_DetachedHouses = 206,
		Urban_SpacedIndustrial = 207,
		Urban_ShantyTown = 208
	}

	public static string LandCoverFilesPath;

	private static GeoTIFF_Tile[] geoTIFF_Tile_0;

	public static int MaxCultureHeight_BuiltIn;

	static LandCover()
	{
		Class72.smethod_20();
		MaxCultureHeight_BuiltIn = 45;
	}

	public static void TestLandCover(string theFileName)
	{
		using Tiff tiff = Tiff.Open(theFileName, "r");
		int num = tiff.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
		FieldValue[] field = tiff.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
		FieldValue[] field2 = tiff.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
		byte[] bytes = field[1].GetBytes();
		double num2 = BitConverter.ToDouble(bytes, 0);
		double num3 = BitConverter.ToDouble(bytes, 8) * -1.0;
		byte[] bytes2 = field2[1].GetBytes();
		double num4 = BitConverter.ToDouble(bytes2, 24);
		double num5 = BitConverter.ToDouble(bytes2, 32) + num3 / 2.0;
		double num6 = num4 + num2 / 2.0;
		byte[] array = new byte[tiff.ScanlineSize() - 1 + 1];
		double num7 = num5;
		double num8 = num6;
		int num9 = num - 1;
		for (int i = 0; i <= num9; i++)
		{
			tiff.ReadScanline(array, i);
			double num10 = num7 + num3 * (double)i;
			int num11 = array.Length - 1;
			for (int j = 0; j <= num11; j++)
			{
				double num12 = num8 + num2 * (double)j;
				int num13 = array[j];
				Console.WriteLine("Lat: " + Conversions.ToString(num10) + " - Lon: " + Conversions.ToString(num12) + " - Value: " + Conversions.ToString(num13));
			}
		}
	}

	public static void LoadGrids()
	{
		try
		{
			LandCoverFilesPath = Path.Combine(GameGeneral.GISFolderPath, "LandCover");
			string[] files = Directory.GetFiles(LandCoverFilesPath);
			geoTIFF_Tile_0 = new GeoTIFF_Tile[files.Length - 1 + 1];
			Tiff.SetErrorHandler(new CustomTIFFErrorHandler());
			int num = files.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				GeoTIFF_Tile geoTIFF_Tile = new GeoTIFF_Tile(files[i]);
				geoTIFF_Tile.Initialize();
				geoTIFF_Tile_0[i] = geoTIFF_Tile;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10121342130593240909120902", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static (LandCoverType theTerrainType, int theLandCoverHeight) GetLandCoverAndHeightAtThisPoint(double theLat, double theLon, Scenario theScen, Side NatureSide)
	{
		LandCoverType landCoverType = LandCoverType.Use_Underlying_Values;
		int num = int.MinValue;
		bool flag = false;
		if (NatureSide != null)
		{
			CustomEnvironmentZone[] customEnvironmentZones = NatureSide.CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				if (customEnvironmentZone.TerrainType != LandCoverType.Use_Underlying_Values && GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
				{
					landCoverType = customEnvironmentZone.TerrainType;
					flag = true;
				}
				if (customEnvironmentZone.HasCustomTerrainHeight && flag)
				{
					num = customEnvironmentZone.TerrainHeight;
				}
			}
		}
		(LandCoverType, int) result;
		if (landCoverType != LandCoverType.Use_Underlying_Values && num > int.MinValue)
		{
			result = (landCoverType, num);
		}
		else
		{
			LandCoverType landCoverType2 = GetLandCoverAtThisPoint(theLat, theLon, theScen);
			if (landCoverType != LandCoverType.Use_Underlying_Values)
			{
				landCoverType2 = landCoverType;
			}
			if (num == int.MinValue)
			{
				num = GetHeight_LandCoverType(landCoverType2);
			}
			result = (landCoverType2, num);
		}
		return result;
	}

	internal static LandCoverType GetLandCoverAtThisPoint(double theLat, double theLon, Scenario TheScen)
	{
		if (TheScen.NatureSideExists())
		{
			CustomEnvironmentZone[] customEnvironmentZones = TheScen.GetNatureSide().CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
				{
					return customEnvironmentZone.TerrainType;
				}
			}
		}
		GeoTIFF_Tile geoTIFF_Tile = smethod_0(theLat, theLon);
		if (geoTIFF_Tile != null)
		{
			return (LandCoverType)geoTIFF_Tile.ReadValue(theLon, theLat);
		}
		return LandCoverType.Water;
	}

	private static GeoTIFF_Tile smethod_0(double double_0, double double_1)
	{
		GeoTIFF_Tile[] array = geoTIFF_Tile_0;
		int num = 0;
		GeoTIFF_Tile geoTIFF_Tile;
		while (true)
		{
			if (num < array.Length)
			{
				geoTIFF_Tile = array[num];
				if (!(geoTIFF_Tile.originLat < double_0) && !(geoTIFF_Tile.originLon > double_1) && double_1 <= geoTIFF_Tile.RightEdgeLongitude && !(double_0 < geoTIFF_Tile.BottomEdgeLatitude))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return null;
		}
		return geoTIFF_Tile;
	}

	public static IEnumerable<(LandCoverType, int)> GetAllLandCoverAndCoverElevationBetweenPoints(double StartLat, double StartLon, float startAlt, double EndLat, double EndLon, float endAlt, Scenario Scen, Side theNatureSide)
	{
		if (geoTIFF_Tile_0.Count() <= 0)
		{
			yield break;
		}
		double num = Math.Abs(geoTIFF_Tile_0[0].pixelSizeY);
		bool flag = false;
		double num2 = StartLat;
		double num3 = StartLon;
		double num4 = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(StartLat, StartLon, EndLat, EndLon);
		double num5 = endAlt - startAlt;
		int maxCultureHeight = GetMaxCultureHeight(Scen);
		(LandCoverType, int) tuple = default((LandCoverType, int));
		while (!flag)
		{
			double num6 = MathFunctions.GetBearing(num2, num3, EndLat, EndLon);
			if (double.IsNaN(num6))
			{
				num6 = Math2.CalcAzimuth(num2, num3, EndLat, EndLon);
			}
			double num7 = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(StartLat, StartLon, num2, num3);
			if (num7 + num >= num4)
			{
				flag = true;
				continue;
			}
			double num8 = num3 + Math2.Sind(num6) * num;
			double num9 = num2 + Math2.Cosd(num6) * num;
			double num10 = (double)startAlt + (1.0 - num7 / num4) * num5;
			if (!(num10 > (double)Terrain.GlobalMaxTerrainElevation))
			{
				int elevation = Terrain.GetElevation(num9, num8, RequestIsFromGUI: false, Scen);
				if (!(num10 > (double)(elevation + maxCultureHeight)) && elevation >= 0)
				{
					tuple.Item1 = GetLandCoverAtThisPoint(num9, num8, Scen);
					Geodesic_Haversine.Distance_Horiz_Angular_Approx_Deg(num9, num8, EndLat, EndLon);
					if (!((double)(elevation + tuple.Item2) <= num10))
					{
						yield return tuple;
					}
				}
			}
			num3 = num8;
			num2 = num9;
		}
	}

	internal static Color GetColor_LandCoverType(LandCoverType Type)
	{
		return Type switch
		{
			LandCoverType.Urban_CloseInnerCity => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedHighRise => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_AttachedHouses => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_CloseIndustrial => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedApartments => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_DetachedHouses => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_SpacedIndustrial => Color.FromArgb(204, 2, 2), 
			LandCoverType.Urban_ShantyTown => Color.FromArgb(204, 2, 2), 
			LandCoverType.Water => Color.FromArgb(174, 195, 214), 
			LandCoverType.Evergreen_Needleleaf_forest => Color.FromArgb(22, 33, 3), 
			LandCoverType.Evergreen_Broadleaf_forest => Color.FromArgb(35, 81, 35), 
			LandCoverType.Deciduous_Needleleaf_forest => Color.FromArgb(57, 155, 56), 
			LandCoverType.Deciduous_Broadleaf_forest => Color.FromArgb(56, 235, 56), 
			LandCoverType.Mixed_forest => Color.FromArgb(57, 114, 59), 
			LandCoverType.Closed_shrublands => Color.FromArgb(106, 36, 36), 
			LandCoverType.Open_shrublands => Color.FromArgb(195, 165, 95), 
			LandCoverType.Woody_savannas => Color.FromArgb(183, 97, 36), 
			LandCoverType.Savannas => Color.FromArgb(217, 145, 37), 
			LandCoverType.Grasslands => Color.FromArgb(146, 175, 31), 
			LandCoverType.Permanent_wetlands => Color.FromArgb(16, 16, 76), 
			LandCoverType.Croplands => Color.FromArgb(205, 180, 0), 
			LandCoverType.UrbanAndBuiltUp => Color.FromArgb(204, 2, 2), 
			LandCoverType.CroplandNaturalVegetationMosaic => Color.FromArgb(51, 40, 8), 
			LandCoverType.SnowAndIce => Color.FromArgb(215, 205, 204), 
			LandCoverType.BarrenOrSparselyVegetated => Color.FromArgb(247, 225, 116), 
			_ => Color.FromArgb(255, 0, 255), 
		};
	}

	internal static int GetMaxCultureHeight(Scenario theScen)
	{
		int num = MaxCultureHeight_BuiltIn;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			CustomEnvironmentZone[] customEnvironmentZones = sides_ReadOnly[i].CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				num = Math.Max(num, customEnvironmentZone.TerrainHeight);
			}
		}
		return num;
	}

	internal static int GetHeight_LandCoverType(LandCoverType Type)
	{
		return Type switch
		{
			LandCoverType.Urban_CloseInnerCity => 30, 
			LandCoverType.Urban_SpacedHighRise => 45, 
			LandCoverType.Urban_AttachedHouses => 6, 
			LandCoverType.Urban_CloseIndustrial => 9, 
			LandCoverType.Urban_SpacedApartments => 20, 
			LandCoverType.Urban_DetachedHouses => 6, 
			LandCoverType.Urban_SpacedIndustrial => 9, 
			LandCoverType.Urban_ShantyTown => 4, 
			LandCoverType.Water => 0, 
			LandCoverType.Evergreen_Needleleaf_forest => 5, 
			LandCoverType.Evergreen_Broadleaf_forest => 5, 
			LandCoverType.Deciduous_Needleleaf_forest => 5, 
			LandCoverType.Deciduous_Broadleaf_forest => 5, 
			LandCoverType.Mixed_forest => 5, 
			LandCoverType.Closed_shrublands => 1, 
			LandCoverType.Open_shrublands => 1, 
			LandCoverType.Woody_savannas => 5, 
			LandCoverType.Savannas => 1, 
			LandCoverType.Grasslands => 1, 
			LandCoverType.Permanent_wetlands => 1, 
			LandCoverType.Croplands => 1, 
			LandCoverType.UrbanAndBuiltUp => 9, 
			LandCoverType.CroplandNaturalVegetationMosaic => 1, 
			LandCoverType.SnowAndIce => 1, 
			LandCoverType.BarrenOrSparselyVegetated => 1, 
			_ => 0, 
		};
	}

	internal static string GetUILabelText_LandCover(LandCoverType Type)
	{
		string text = GetTextDescription_LandCoverType(Type);
		if (text.Length > 0)
		{
			text = "Land: " + text;
		}
		return text + " ";
	}

	internal static string GetTextDescription_LandCoverType(LandCoverType Type)
	{
		string result = "";
		switch (Type)
		{
		case LandCoverType.Urban_CloseInnerCity:
			result = "Attached and Closely Spaced Inner City Buildings";
			break;
		case LandCoverType.Urban_SpacedHighRise:
			result = "Widely Spaced High-rise Office Buildings";
			break;
		case LandCoverType.Urban_AttachedHouses:
			result = "Attached Houses";
			break;
		case LandCoverType.Urban_CloseIndustrial:
			result = "Closely Spaced Industrial / Storage Buildings";
			break;
		case LandCoverType.Urban_SpacedApartments:
			result = "Widely Spaced Apartment Buildings";
			break;
		case LandCoverType.Urban_DetachedHouses:
			result = "Detached Houses";
			break;
		case LandCoverType.Urban_SpacedIndustrial:
			result = "Widely Spaced Industrial / Storage Buildings";
			break;
		case LandCoverType.Urban_ShantyTown:
			result = "Shanty Town";
			break;
		case LandCoverType.Water:
			result = "Water";
			break;
		case LandCoverType.Evergreen_Needleleaf_forest:
			result = "Evergreen Needleleaf Forest";
			break;
		case LandCoverType.Evergreen_Broadleaf_forest:
			result = "Evergreen Broadleaf Forest";
			break;
		case LandCoverType.Deciduous_Needleleaf_forest:
			result = "Deciduous Needleleaf Forest";
			break;
		case LandCoverType.Deciduous_Broadleaf_forest:
			result = "Deciduous Broadleaf Forest";
			break;
		case LandCoverType.Mixed_forest:
			result = "Mixed Forest";
			break;
		case LandCoverType.Closed_shrublands:
			result = "Closed Shrublands";
			break;
		case LandCoverType.Open_shrublands:
			result = "Open Shrublands";
			break;
		case LandCoverType.Woody_savannas:
			result = "Woody Savannas";
			break;
		case LandCoverType.Savannas:
			result = "Savannas";
			break;
		case LandCoverType.Grasslands:
			result = "Grasslands";
			break;
		case LandCoverType.Permanent_wetlands:
			result = "Permanent Wetlands";
			break;
		case LandCoverType.Croplands:
			result = "Croplands";
			break;
		case LandCoverType.UrbanAndBuiltUp:
			result = "Urban / Built Up";
			break;
		case LandCoverType.CroplandNaturalVegetationMosaic:
			result = "Cropland / Natural Vegetation Mosaic";
			break;
		case LandCoverType.SnowAndIce:
			result = "Snow / Ice";
			break;
		case LandCoverType.BarrenOrSparselyVegetated:
			result = "Barren / Sparsely Vegetated";
			break;
		}
		return result;
	}
}
