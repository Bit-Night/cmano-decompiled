using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.My;
using CSMaterial.ExWorldWind;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace Command_Core;

public sealed class BinaryGridProvider : ITerrainProvider
{
	[CompilerGenerated]
	internal sealed class _Closure$__26-0
	{
		public int $VB$Local_NumCols;

		public BinGridModule.TBinGrid $VB$Local_theGrid;

		public Scenario $VB$Local_theScen;

		public BinaryGridProvider $VB$Me;

		public _Closure$__26-0(_Closure$__26-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NumCols = arg0.$VB$Local_NumCols;
				$VB$Local_theGrid = arg0.$VB$Local_theGrid;
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(int i)
		{
			int num = $VB$Local_NumCols - 1;
			double x = default(double);
			double y = default(double);
			for (int j = 0; j <= num; j++)
			{
				$VB$Local_theGrid.CellToProj(j, i, ref x, ref y);
				float value = ActiveUnit_Navigator.NearestDistanceToLand(y, x, $VB$Local_theScen);
				if (!$VB$Me.dictionary_0.ContainsKey(i))
				{
					$VB$Me.dictionary_0.Add(i, new Dictionary<int, float>());
				}
				Dictionary<int, float> dictionary = $VB$Me.dictionary_0[i];
				if (!dictionary.ContainsKey(j))
				{
					dictionary.Add(j, value);
				}
			}
		}

		static _Closure$__26-0()
		{
			Class72.smethod_20();
		}
	}

	private int int_0;

	private float float_0;

	private float float_1;

	internal static string _TerrainFilesPath;

	public BinGridModule.TBinGrid[][] TerrainGrids;

	private static TwoTierArrayCache<byte[]> twoTierArrayCache_0;

	private static readonly MemoryCacheEntryOptions memoryCacheEntryOptions_0;

	private Terrain.MaxMinRecord[][] maxMinRecord_0;

	private Dictionary<int, Dictionary<int, float>> dictionary_0;

	private bool bool_0;

	public string TerrainFilesPath
	{
		get
		{
			return _TerrainFilesPath;
		}
		set
		{
			_TerrainFilesPath = value;
		}
	}

	public string Description => "SRTM30PLUS (BGD)";

	static BinaryGridProvider()
	{
		Class72.smethod_20();
		memoryCacheEntryOptions_0 = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60.0));
	}

	public BinaryGridProvider()
	{
		int_0 = 100;
		float_0 = 0.5f;
		float_1 = 1f / 120f;
		TerrainGrids = new BinGridModule.TBinGrid[34][];
		maxMinRecord_0 = new Terrain.MaxMinRecord[360][];
		bool_0 = false;
	}

	public static byte[] GetGridFromCache(short theIndex)
	{
		byte[] value = default(byte[]);
		twoTierArrayCache_0.TryGet(theIndex, ref value);
		return value;
	}

	public static void AddGridToCache(short theIndex, byte[] theBuffer)
	{
		twoTierArrayCache_0.SetItem(theIndex, theBuffer, new TimeSpan(0, 0, 60));
	}

	public void ClearCache()
	{
		twoTierArrayCache_0.Clear();
	}

	internal bool Initialize()
	{
		bool result;
		try
		{
			_TerrainFilesPath = GameGeneral.GISFolderPath + "\\Terrain\\SRTM30Plus\\";
			method_0();
			method_6();
			new MemoryCacheOptions
			{
				ExpirationScanFrequency = TimeSpan.FromSeconds(30.0),
				Clock = new UTCProviderClock()
			};
			twoTierArrayCache_0 = new TwoTierArrayCache<byte[]>(33);
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 1;
			}
			else
			{
				Debugger.Break();
				num = 1;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	bool ITerrainProvider.Initialize()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		return this.Initialize();
	}

	private void method_0()
	{
		try
		{
			string[] directories = Directory.GetDirectories(TerrainFilesPath);
			foreach (string text in directories)
			{
				((ServerComputer)MyProject.Computer).FileSystem.DeleteDirectory(text, (DeleteDirectoryOption)5);
			}
			int num = 0;
			string[] files = Directory.GetFiles(TerrainFilesPath, "*.bgd");
			foreach (string text2 in files)
			{
				if (text2.EndsWith(".bgd"))
				{
					num++;
					BinGridModule.TBinGrid tBinGrid = new BinGridModule.TBinGrid(Path.GetFileName(text2));
					tBinGrid.ReadTileHeader(text2);
					BinGridModule.TBinGrid[] array = new BinGridModule.TBinGrid[1] { tBinGrid };
					TerrainGrids[num] = array;
				}
			}
			Terrain.TerrainHasLoaded = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101105", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisposeResources()
	{
		method_1();
	}

	private void method_1()
	{
		try
		{
			BinGridModule.TBinGrid[][] terrainGrids = TerrainGrids;
			foreach (BinGridModule.TBinGrid[] array in terrainGrids)
			{
				if (array != null)
				{
					BinGridModule.TBinGrid[] array2 = array;
					for (int j = 0; j < array2.Length; j = checked(j + 1))
					{
						array2[j]?.CloseTile();
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200271", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static short GetTerrainTileIndex(ref double theLat, ref double theLon, bool CoordsAlreadyNormalized)
	{
		if (!CoordsAlreadyNormalized)
		{
			theLat = Math2.NormalizeLatitude(theLat);
			theLon = Math2.NormalizeLongitude(theLon);
		}
		double num = theLat;
		if (num > 40.0)
		{
			double num2 = theLon;
			if (num2 > 140.0)
			{
				return 6;
			}
			if (num2 > 100.0)
			{
				return 2;
			}
			if (num2 > 60.0)
			{
				return 12;
			}
			if (num2 > 20.0)
			{
				return 9;
			}
			if (num2 > -20.0)
			{
				return 28;
			}
			if (num2 > -60.0)
			{
				return 31;
			}
			if (num2 > -100.0)
			{
				return 17;
			}
			if (num2 > -140.0)
			{
				return 21;
			}
			return 24;
		}
		if (num > -10.0)
		{
			double num3 = theLon;
			if (num3 > 140.0)
			{
				return 5;
			}
			if (num3 > 100.0)
			{
				return 1;
			}
			if (num3 > 60.0)
			{
				return 11;
			}
			if (num3 > 20.0)
			{
				return 8;
			}
			if (num3 > -20.0)
			{
				return 27;
			}
			if (num3 > -60.0)
			{
				return 30;
			}
			if (num3 > -100.0)
			{
				return 16;
			}
			if (num3 > -140.0)
			{
				return 20;
			}
			return 23;
		}
		if (num > -60.0)
		{
			double num4 = theLon;
			if (num4 > 140.0)
			{
				return 7;
			}
			if (num4 > 100.0)
			{
				return 3;
			}
			if (num4 > 60.0)
			{
				return 13;
			}
			if (num4 > 20.0)
			{
				return 10;
			}
			if (num4 > -20.0)
			{
				return 29;
			}
			if (num4 > -60.0)
			{
				return 32;
			}
			if (num4 > -100.0)
			{
				return 18;
			}
			if (num4 > -140.0)
			{
				return 22;
			}
			return 25;
		}
		double num5 = theLon;
		if (num5 > 120.0)
		{
			return 4;
		}
		if (num5 > 60.0)
		{
			return 14;
		}
		if (num5 > 0.0)
		{
			return 15;
		}
		if (num5 > -60.0)
		{
			return 33;
		}
		if (num5 > -120.0)
		{
			return 19;
		}
		return 26;
	}

	private BinGridModule.TBinGrid method_2(double double_0, double double_1)
	{
		if (double_0 > 90.0 || double_0 < -90.0)
		{
			double_0 = Math2.NormalizeLatitude(double_0);
		}
		if (double_1 > 180.0 || double_1 < -180.0)
		{
			double_1 = Math2.NormalizeLongitude(double_1);
		}
		int terrainTileIndex = GetTerrainTileIndex(ref double_0, ref double_1, CoordsAlreadyNormalized: true);
		BinGridModule.TBinGrid[] theArray = TerrainGrids[terrainTileIndex];
		int num = theArray.Length;
		if (num != 0)
		{
			BinGridModule.TBinGrid tBinGrid2 = default(BinGridModule.TBinGrid);
			if (num > 0)
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					BinGridModule.TBinGrid tBinGrid = theArray[i];
					if (tBinGrid != null && !tBinGrid.ReadingInProgress)
					{
						tBinGrid2 = tBinGrid;
						break;
					}
				}
			}
			if (tBinGrid2 == null)
			{
				BinGridModule.TBinGrid tBinGrid3 = new BinGridModule.TBinGrid(TerrainFilesPath + theArray[0].Filename);
				tBinGrid3.ReadTileHeader(TerrainFilesPath + theArray[0].Filename);
				tBinGrid3.Cache_RAM = theArray[0].Cache_RAM;
				if (theArray.Length < int_0)
				{
					ArrayExtensions.Add(ref theArray, tBinGrid3);
					TerrainGrids[terrainTileIndex] = theArray;
				}
				tBinGrid2 = tBinGrid3;
			}
			return tBinGrid2;
		}
		return null;
	}

	internal short GetElevation(double theLat, double theLon, bool RequestIsFromGUI, bool UseCaching = true)
	{
		short result;
		try
		{
			result = method_2(theLat, theLon)?.ReadValue_CacheFirst(theLon, theLat, RequestIsFromGUI, UseCaching) ?? 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200092", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (short)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	short ITerrainProvider.GetElevation(double theLat, double theLon, bool RequestIsFromGUI, bool UseCaching = true)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetElevation
		return this.GetElevation(theLat, theLon, RequestIsFromGUI, UseCaching);
	}

	private bool GeopointsAreOnSameOrAdjacentCell(double GP1_Lat, double GP1_Lon, double GP2_Lat, double GP2_Lon)
	{
		bool result = default(bool);
		try
		{
			GP1_Lat = Math2.NormalizeLatitude(GP1_Lat);
			GP1_Lon = Math2.NormalizeLongitude(GP1_Lon);
			GP2_Lat = Math2.NormalizeLatitude(GP2_Lat);
			GP2_Lon = Math2.NormalizeLongitude(GP2_Lon);
			int terrainTileIndex = GetTerrainTileIndex(ref GP1_Lat, ref GP1_Lon, CoordsAlreadyNormalized: true);
			int terrainTileIndex2 = GetTerrainTileIndex(ref GP2_Lat, ref GP2_Lon, CoordsAlreadyNormalized: true);
			if (terrainTileIndex != terrainTileIndex2)
			{
				result = false;
				return result;
			}
			int row = default(int);
			int column = default(int);
			TerrainGrids[terrainTileIndex][0].ProjToCell(GP1_Lon, GP1_Lat, ref row, ref column);
			int row2 = default(int);
			int column2 = default(int);
			TerrainGrids[terrainTileIndex2][0].ProjToCell(GP2_Lon, GP2_Lat, ref row2, ref column2);
			if (row == row2 && column == column2)
			{
				result = true;
				return result;
			}
			if (Math.Abs(row - row2) < 2 && Math.Abs(column - column2) < 2)
			{
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100227", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	bool ITerrainProvider.GeopointsAreOnSameOrAdjacentCell(double GP1_Lat, double GP1_Lon, double GP2_Lat, double GP2_Lon)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GeopointsAreOnSameOrAdjacentCell
		return this.GeopointsAreOnSameOrAdjacentCell(GP1_Lat, GP1_Lon, GP2_Lat, GP2_Lon);
	}

	internal Terrain.TerrainRasterCell[] GetAllCellsInThisRadius(double theLat, double theLon, float Radius_nm, bool IncludeElevations)
	{
		Dictionary<string, Terrain.TerrainRasterCell> dictionary = new Dictionary<string, Terrain.TerrainRasterCell>();
		theLat = Math2.NormalizeLatitude(theLat);
		theLon = Math2.NormalizeLongitude(theLon);
		double out_lon = default(double);
		double out_lat = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon, ref out_lat, (float)((double)Radius_nm * 1.414), 225);
		double out_lon2 = default(double);
		double out_lat2 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon2, ref out_lat2, (float)((double)Radius_nm * 1.414), 315);
		double out_lon3 = default(double);
		double out_lat3 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon3, ref out_lat3, (float)((double)Radius_nm * 1.414), 45);
		double out_lon4 = default(double);
		double out_lat4 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon4, ref out_lat4, (float)((double)Radius_nm * 1.414), 135);
		Angle angle = new Angle
		{
			Degrees = out_lon
		};
		Angle angle2 = new Angle
		{
			Degrees = out_lat
		};
		Angle angle3 = new Angle
		{
			Degrees = out_lon2
		};
		Angle angle4 = new Angle
		{
			Degrees = out_lat2
		};
		Angle lat = new Angle
		{
			Degrees = out_lat3
		};
		Angle lon = new Angle
		{
			Degrees = out_lon3
		};
		Angle lon2 = new Angle
		{
			Degrees = out_lon4
		};
		Angle lat2 = new Angle
		{
			Degrees = out_lat4
		};
		Angle d = World.ApproxAngularDistance(angle2, angle, angle4, angle3);
		float num = 0f;
		float num2 = 0f;
		StringBuilder stringBuilder = new StringBuilder();
		int row = default(int);
		int column = default(int);
		for (; !((double)num >= d.Degrees); num += float_1)
		{
			Angle lat3 = default(Angle);
			Angle lon3 = default(Angle);
			Angle lat4 = default(Angle);
			Angle lon4 = default(Angle);
			World.smethod_0((float)((double)num / d.Degrees), angle2, angle, angle4, angle3, d, out lat3, out lon3);
			World.smethod_0((float)((double)num / d.Degrees), lat2, lon2, lat, lon, d, out lat4, out lon4);
			for (Angle angle5 = World.ApproxAngularDistance(lat3, lon3, lat4, lon4); !((double)num2 >= angle5.Degrees); num2 += float_1)
			{
				double theLat2 = Math2.NormalizeLatitude(out_lat + (double)num);
				double theLon2 = Math2.NormalizeLongitude(out_lon + (double)num2);
				int terrainTileIndex = GetTerrainTileIndex(ref theLat2, ref theLon2, CoordsAlreadyNormalized: true);
				BinGridModule.TBinGrid tBinGrid = TerrainGrids[terrainTileIndex][0];
				try
				{
					tBinGrid.ProjToCell(theLon2, theLat2, ref row, ref column);
					stringBuilder.Clear();
					stringBuilder.Append(terrainTileIndex);
					stringBuilder.Append("_");
					stringBuilder.Append(row);
					stringBuilder.Append("_");
					stringBuilder.Append(column);
					string key = stringBuilder.ToString();
					if (!dictionary.ContainsKey(key))
					{
						Terrain.TerrainRasterCell value = default(Terrain.TerrainRasterCell);
						if (IncludeElevations)
						{
							value.ElevationValue = tBinGrid.ReadValue_CacheFirst(theLon2, theLat2, IsGUIRequest: false);
						}
						value.Height_degrees = float_1;
						value.Width_degrees = float_1;
						dictionary.Add(key, value);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101107", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		return dictionary.Values.ToArray();
	}

	Terrain.TerrainRasterCell[] ITerrainProvider.GetAllCellsInThisRadius(double theLat, double theLon, float Radius_nm, bool IncludeElevations)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAllCellsInThisRadius
		return this.GetAllCellsInThisRadius(theLat, theLon, Radius_nm, IncludeElevations);
	}

	private void method_3(Scenario scenario_0)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		_Closure$__26-0 arg = default(_Closure$__26-0);
		_Closure$__26-0 CS$<>8__locals13 = new _Closure$__26-0(arg);
		CS$<>8__locals13.$VB$Me = this;
		CS$<>8__locals13.$VB$Local_theScen = scenario_0;
		Queue<BinGridModule.TBinGrid> queue = new Queue<BinGridModule.TBinGrid>();
		BinGridModule.TBinGrid[][] terrainGrids = TerrainGrids;
		foreach (BinGridModule.TBinGrid[] array in terrainGrids)
		{
			if (array != null)
			{
				queue.Enqueue(array[0]);
			}
		}
		dictionary_0 = new Dictionary<int, Dictionary<int, float>>();
		CS$<>8__locals13.$VB$Local_theGrid = queue.Dequeue();
		int nrows = CS$<>8__locals13.$VB$Local_theGrid.nrows;
		CS$<>8__locals13.$VB$Local_NumCols = CS$<>8__locals13.$VB$Local_theGrid.ncols;
		Parallel.For(0, nrows, [SpecialName] (int num2) =>
		{
			int num = CS$<>8__locals13.$VB$Local_NumCols - 1;
			double x = default(double);
			double y = default(double);
			for (int j = 0; j <= num; j++)
			{
				CS$<>8__locals13.$VB$Local_theGrid.CellToProj(j, num2, ref x, ref y);
				float value = ActiveUnit_Navigator.NearestDistanceToLand(y, x, CS$<>8__locals13.$VB$Local_theScen);
				if (!CS$<>8__locals13.$VB$Me.dictionary_0.ContainsKey(num2))
				{
					CS$<>8__locals13.$VB$Me.dictionary_0.Add(num2, new Dictionary<int, float>());
				}
				Dictionary<int, float> dictionary2 = CS$<>8__locals13.$VB$Me.dictionary_0[num2];
				if (!dictionary2.ContainsKey(j))
				{
					dictionary2.Add(j, value);
				}
			}
		});
		StringBuilder stringBuilder = new StringBuilder();
		FileStream fileStream = new FileStream(GameGeneral.GISFolderPath + "\\" + CS$<>8__locals13.$VB$Local_theGrid.Filename + "_DFL", FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			XmlWriterSettings val = new XmlWriterSettings();
			val.Indent = true;
			val.IndentChars = "    ";
			XmlWriter val2 = XmlWriter.Create((Stream)fileStream, val);
			val2.WriteStartElement("DFLRecs");
			foreach (int key in dictionary_0.Keys)
			{
				Dictionary<int, float> dictionary = dictionary_0[key];
				foreach (int key2 in dictionary.Keys)
				{
					stringBuilder.Clear();
					stringBuilder.Append(key).Append("_").Append(key2);
					val2.WriteStartElement("Rec");
					val2.WriteElementString("R_C", stringBuilder.ToString());
					val2.WriteElementString("D", Conversions.ToString(dictionary[key2]));
					val2.WriteEndElement();
				}
				val2.Flush();
			}
			val2.WriteEndElement();
			val2.Flush();
			fileStream.Flush();
		}
		GameGeneral.SendMessageBoxToUI("Done", null);
	}

	internal Terrain.TerrainRasterCell GetSingleRasterCell(double theLat, double theLon)
	{
		return method_2(theLat, theLon).GetSingleRasterCell(theLat, theLon);
	}

	Terrain.TerrainRasterCell ITerrainProvider.GetSingleRasterCell(double theLat, double theLon)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetSingleRasterCell
		return this.GetSingleRasterCell(theLat, theLon);
	}

	private float LandPercentageInThisSquare(double theLat, double theLon, float Radius_nm)
	{
		HashSet<string> hashSet = new HashSet<string>();
		theLat = Math2.NormalizeLatitude(theLat);
		theLon = Math2.NormalizeLongitude(theLon);
		double out_lon = default(double);
		double out_lat = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon, ref out_lat, (float)((double)Radius_nm * 1.414), 225);
		double out_lon2 = default(double);
		double out_lat2 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon2, ref out_lat2, (float)((double)Radius_nm * 1.414), 315);
		double out_lon3 = default(double);
		double out_lat3 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon3, ref out_lat3, (float)((double)Radius_nm * 1.414), 45);
		double out_lon4 = default(double);
		double out_lat4 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon4, ref out_lat4, (float)((double)Radius_nm * 1.414), 135);
		Angle angle = new Angle
		{
			Degrees = out_lon
		};
		Angle angle2 = new Angle
		{
			Degrees = out_lat
		};
		Angle angle3 = new Angle
		{
			Degrees = out_lon2
		};
		Angle angle4 = new Angle
		{
			Degrees = out_lat2
		};
		Angle lat = new Angle
		{
			Degrees = out_lat3
		};
		Angle lon = new Angle
		{
			Degrees = out_lon3
		};
		Angle lon2 = new Angle
		{
			Degrees = out_lon4
		};
		Angle lat2 = new Angle
		{
			Degrees = out_lat4
		};
		Angle d = World.ApproxAngularDistance(angle2, angle, angle4, angle3);
		float num = 0f;
		float num2 = 0f;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		int row = default(int);
		int column = default(int);
		int num3 = default(int);
		int num4 = default(int);
		for (; !((double)num >= d.Degrees); num += float_1)
		{
			Angle lat3 = default(Angle);
			Angle lon3 = default(Angle);
			Angle lat4 = default(Angle);
			Angle lon4 = default(Angle);
			World.smethod_0((float)((double)num / d.Degrees), angle2, angle, angle4, angle3, d, out lat3, out lon3);
			World.smethod_0((float)((double)num / d.Degrees), lat2, lon2, lat, lon, d, out lat4, out lon4);
			for (Angle angle5 = World.ApproxAngularDistance(lat3, lon3, lat4, lon4); !((double)num2 >= angle5.Degrees); num2 += float_1)
			{
				double theLat2 = Math2.NormalizeLatitude(out_lat + (double)num);
				double theLon2 = Math2.NormalizeLongitude(out_lon + (double)num2);
				int terrainTileIndex = GetTerrainTileIndex(ref theLat2, ref theLon2, CoordsAlreadyNormalized: true);
				BinGridModule.TBinGrid tBinGrid = TerrainGrids[terrainTileIndex][0];
				try
				{
					tBinGrid.ProjToCell(theLon, theLat, ref row, ref column);
					stringBuilder.Clear();
					stringBuilder.Append(terrainTileIndex);
					stringBuilder.Append("_");
					stringBuilder.Append(row);
					stringBuilder.Append("_");
					stringBuilder.Append(column);
					string item = stringBuilder.ToString();
					if (!hashSet.Contains(item))
					{
						hashSet.Add(item);
						num3++;
						if (PointIsOverland(theLat2, theLon2).IsOverland)
						{
							num4++;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101107", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		return (float)((double)num4 / (double)num3);
	}

	float ITerrainProvider.LandPercentageInThisSquare(double theLat, double theLon, float Radius_nm)
	{
		//ILSpy generated this explicit interface implementation from .override directive in LandPercentageInThisSquare
		return this.LandPercentageInThisSquare(theLat, theLon, Radius_nm);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Terrain.MaxMinRecord method_4(Terrain.MaxMinRecord[][] maxMinRecord_1, int int_1, int int_2)
	{
		return maxMinRecord_1[int_1][int_2];
	}

	private void method_5(Terrain.MaxMinRecord[][] maxMinRecord_1, int int_1, int int_2, Terrain.MaxMinRecord maxMinRecord_2)
	{
		try
		{
			if (maxMinRecord_1[int_1] != null)
			{
				maxMinRecord_1[int_1][int_2] = maxMinRecord_2;
				return;
			}
			Terrain.MaxMinRecord[] array = new Terrain.MaxMinRecord[180];
			array[int_2] = maxMinRecord_2;
			maxMinRecord_1[int_1] = array;
		}
		catch (OutOfMemoryException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 20324958729856749764398764397", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		Terrain.MaxMinRecord maxMinRecord = default(Terrain.MaxMinRecord);
		BinGridModule.TBinGrid[][] terrainGrids = TerrainGrids;
		int num = default(int);
		int num2 = default(int);
		foreach (BinGridModule.TBinGrid[] array in terrainGrids)
		{
			if (array == null)
			{
				continue;
			}
			BinGridModule.TBinGrid tBinGrid = array[0];
			FileStream fileStream = new FileStream(Path.Combine(GameGeneral.GISFolderPath, "Terrain\\SRTM30Plus\\" + tBinGrid.Filename + "_MaxMin"), FileMode.Open, FileAccess.Read);
			XmlDocument val = new XmlDocument();
			using (fileStream)
			{
				val.Load((Stream)fileStream);
			}
			XmlNode val2 = ((XmlNode)val).ChildNodes[1];
			foreach (XmlNode childNode in val2.ChildNodes)
			{
				XmlNode val3 = childNode;
				maxMinRecord = default(Terrain.MaxMinRecord);
				foreach (XmlNode childNode2 in val3.ChildNodes)
				{
					XmlNode val4 = childNode2;
					switch (val4.Name)
					{
					case "Lon_Lat":
						num = Conversions.ToInteger(val4.InnerText.Split(new char[1] { '_' })[0]);
						num2 = Conversions.ToInteger(val4.InnerText.Split(new char[1] { '_' })[1]);
						num2 += 90;
						num += 180;
						break;
					case "Max":
						maxMinRecord.Max = Conversions.ToShort(val4.InnerText);
						break;
					case "Min":
						maxMinRecord.Min = Conversions.ToShort(val4.InnerText);
						break;
					}
				}
				method_5(maxMinRecord_0, num, num2, maxMinRecord);
			}
		}
		bool_0 = true;
	}

	private short GetMaxForThisDegCell(double theLat, double theLon)
	{
		if (!bool_0)
		{
			while (!bool_0)
			{
				Thread.Sleep(50);
			}
		}
		if (theLat > 90.0 || theLat < -90.0)
		{
			theLat = Math2.NormalizeLatitude(theLat);
		}
		if (theLon > 180.0 || theLon < -180.0)
		{
			theLon = Math2.NormalizeLongitude(theLon);
		}
		theLat += 90.0;
		theLon += 180.0;
		int int_ = (int)theLon;
		int int_2 = (int)theLat;
		short result;
		try
		{
			result = method_4(maxMinRecord_0, int_, int_2).Max;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	short ITerrainProvider.GetMaxForThisDegCell(double theLat, double theLon)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetMaxForThisDegCell
		return this.GetMaxForThisDegCell(theLat, theLon);
	}

	private short GetMinForThisDegCell(double theLat, double theLon)
	{
		if (!bool_0)
		{
			while (!bool_0)
			{
				Thread.Sleep(50);
			}
		}
		if (theLat > 90.0 || theLat < -90.0)
		{
			theLat = Math2.NormalizeLatitude(theLat);
		}
		if (theLon > 180.0 || theLon < -180.0)
		{
			theLon = Math2.NormalizeLongitude(theLon);
		}
		theLat += 90.0;
		theLon += 180.0;
		int int_ = (int)theLon;
		int int_2 = (int)theLat;
		short result;
		try
		{
			result = method_4(maxMinRecord_0, int_, int_2).Min;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	short ITerrainProvider.GetMinForThisDegCell(double theLat, double theLon)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetMinForThisDegCell
		return this.GetMinForThisDegCell(theLat, theLon);
	}

	internal (bool IsOverland, short? RetrievedElevation) PointIsOverland(double theLat, double theLon)
	{
		if (theLat > 90.0 || theLat < -90.0)
		{
			theLat = Math2.NormalizeLatitude(theLat);
		}
		if (theLon > 180.0 || theLon < -180.0)
		{
			theLon = Math2.NormalizeLongitude(theLon);
		}
		(bool, short?) result;
		if (GetMaxForThisDegCell(theLat, theLon) < 0)
		{
			result = (false, null);
		}
		else if (GetMinForThisDegCell(theLat, theLon) >= 0)
		{
			result = (true, null);
		}
		else
		{
			short elevation = GetElevation(theLat, theLon, RequestIsFromGUI: false);
			result = (elevation >= 0, elevation);
		}
		return result;
	}

	(bool IsOverland, short? RetrievedElevation) ITerrainProvider.PointIsOverland(double theLat, double theLon)
	{
		//ILSpy generated this explicit interface implementation from .override directive in PointIsOverland
		return this.PointIsOverland(theLat, theLon);
	}

	private bool TerrainBlocksLOS(float theDist, double Distance_Cartesian, double X_S, double Y_S, double Z_S, double deltaX, double deltaY, double deltaZ, float Alt_Src, float Alt_Dest, bool LandMassCheck, bool IgnoreRadarHorizon, Scenario CurrentScen, Side NatureSide)
	{
		float num = (float)((double)theDist / Distance_Cartesian);
		if (num > 1f)
		{
			return false;
		}
		double x = X_S + deltaX * (double)num;
		double y = Y_S + deltaY * (double)num;
		double z = Z_S + deltaZ * (double)num;
		double Lat = default(double);
		double Lon = default(double);
		double Alt = default(double);
		Geodesic_Vincenty.ApproxCartesianToSpherical(x, y, z, ref Lat, ref Lon, ref Alt);
		if (NatureSide != null)
		{
			CustomEnvironmentZone[] customEnvironmentZones = NatureSide.CustomEnvironmentZones;
			int num2 = customEnvironmentZones.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				CustomEnvironmentZone customEnvironmentZone = customEnvironmentZones[i];
				if (customEnvironmentZone.HasCustomTerrainHeight && (double)customEnvironmentZone.TerrainHeight > Alt && GeoPoint.IsInsideThisArea(Lat, Lon, customEnvironmentZone.Area_AsArray))
				{
					return true;
				}
			}
		}
		if (Alt > (double)Terrain.GlobalMaxTerrainElevation)
		{
			return false;
		}
		short maxForThisDegCell = GetMaxForThisDegCell(Lat, Lon);
		if (Alt > (double)maxForThisDegCell)
		{
			return false;
		}
		int num3 = int.MinValue;
		if (Alt > (double)Alt_Src && Alt > (double)Alt_Dest)
		{
			return false;
		}
		if (Alt < (double)Alt_Src && Alt < (double)Alt_Dest)
		{
			num3 = Terrain.GetElevation(Lat, Lon, RequestIsFromGUI: false, CurrentScen);
			if (Alt < (double)num3)
			{
				int result;
				if (IgnoreRadarHorizon)
				{
					if (num3 <= 0)
					{
						goto IL_0111;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		goto IL_0111;
		IL_0111:
		if (num3 == int.MinValue)
		{
			num3 = Terrain.GetElevation(Lat, Lon, RequestIsFromGUI: false, CurrentScen);
		}
		if (LandMassCheck)
		{
			if (num3 > 0)
			{
				return true;
			}
		}
		else if ((!IgnoreRadarHorizon || num3 > 0) && Alt <= (double)num3)
		{
			return true;
		}
		return false;
	}

	bool ITerrainProvider.TerrainBlocksLOS(float theDist, double Distance_Cartesian, double X_S, double Y_S, double Z_S, double deltaX, double deltaY, double deltaZ, float Alt_Src, float Alt_Dest, bool LandMassCheck, bool IgnoreRadarHorizon, Scenario CurrentScen, Side NatureSide)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TerrainBlocksLOS
		return this.TerrainBlocksLOS(theDist, Distance_Cartesian, X_S, Y_S, Z_S, deltaX, deltaY, deltaZ, Alt_Src, Alt_Dest, LandMassCheck, IgnoreRadarHorizon, CurrentScen, NatureSide);
	}
}
