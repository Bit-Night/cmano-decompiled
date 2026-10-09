using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Command_Core;
using CSMaterial;
using Cysharp.Text;
using DirectN;
using Efundies;
using ExWorldWind;
using Imazen.WebP;
using Imazen.WebP.Extern;
using Microsoft.MapPoint;
using ThreadSafeCollections;
using VectorTileRenderer;

namespace DXRenderer;

public class TileCache
{
	private class Class26
	{
		public SQLiteCommand sqliteCommand_0;

		public object object_0;

		public object Row;

		public object object_1;

		public object object_2;

		public Class26(SQLiteCommand sqliteCommand_1, SQLiteParameter sqliteParameter_0, SQLiteParameter sqliteParameter_1, SQLiteParameter sqliteParameter_2, SQLiteDataReader sqliteDataReader_0)
		{
			sqliteCommand_0 = sqliteCommand_1;
			object_0 = sqliteParameter_0;
			Row = sqliteParameter_1;
			object_1 = sqliteParameter_2;
			object_2 = sqliteDataReader_0;
		}

		static Class26()
		{
			Class72.smethod_20();
		}
	}

	private uint uint_0;

	private ThreadLocal<byte[]> threadLocal_0 = new ThreadLocal<byte[]>(() => new byte[524288]);

	private ThreadLocal<Dictionary<OSM_MBTiles_Layer, Class26>> threadLocal_1 = new ThreadLocal<Dictionary<OSM_MBTiles_Layer, Class26>>(() => new Dictionary<OSM_MBTiles_Layer, Class26>());

	public static VectorTileSource theVectorTileSource;

	private TDictionary<string, SQLiteConnection> tdictionary_0 = new TDictionary<string, SQLiteConnection>();

	private Font font_0 = new Font(FontFamily.GenericMonospace, 10f);

	internal StamenLayer StamenLayer = StamenLayer.None;

	public float FileSystemLevel;

	public float BMNGOSMLevel;

	public float OSMLevel;

	public ConcurrentQueue<TextureParameters> TileTextures;

	public ConcurrentDictionary<string, DrawParameters> Tiles;

	internal readonly List<CancellableTask> TileTasks;

	public Queue<string> TileHistory;

	public readonly int KeepTiles;

	public int TilesLoaded;

	public int TilesDrawn;

	internal readonly SQLiteConnection sqliteConnection_0;

	internal readonly SQLiteConnection Relief90SQLiteConnection;

	internal readonly SQLiteConnection ReliefBathymetrySRTM3SQLiteConnection;

	internal readonly SQLiteConnection LandCover300SQLiteConnection;

	internal readonly SQLiteConnection S2CloudlessSQLiteConnection;

	private readonly SQLiteConnection sqliteConnection_1;

	private readonly bool bool_0;

	private readonly SimpleDecoder simpleDecoder_0;

	public PolygonLayer BordersCoastOlder;

	public PolygonLayer BordersCoastNewer;

	public PolygonLayer ArcticIce;

	public float BordersCoastsAlpha;

	private RenderState eqxyMyNqOgY;

	private DXDevice YshyMeXwYbc;

	private readonly float float_0 = (float)Math.PI / 4f;

	internal const float PI = (float)Math.PI;

	public const float EARTH_MEAN_RADIUS = 6378137f;

	private readonly Color color_0 = Color.FromArgb(0, 255, 255, 255);

	private readonly UnsafeColor unsafeColor_0 = new UnsafeColor(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private readonly Color color_1 = Color.FromArgb(127, 0, 0, 0);

	public readonly int[] Levels = new int[5] { 8, 16, 32, 64, 128 };

	public readonly int[] SlippyLevels = new int[18]
	{
		1, 2, 4, 8, 16, 32, 64, 128, 256, 512,
		1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072
	};

	public RenderState RenderState => eqxyMyNqOgY;

	public TileCache(DXDevice device, RenderState renderState)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		YshyMeXwYbc = device;
		eqxyMyNqOgY = renderState;
		simpleDecoder_0 = new SimpleDecoder();
		TileTextures = new ConcurrentQueue<TextureParameters>();
		Tiles = new ConcurrentDictionary<string, DrawParameters>();
		if (!Main.AggressiveTileManagement)
		{
			KeepTiles = 300;
		}
		else
		{
			KeepTiles = 900;
		}
		TileHistory = new Queue<string>();
		TileTasks = new List<CancellableTask>();
		sqliteConnection_0 = method_9(Main.TopLevelWritableRoot + "\\WW\\Cache\\BMNGv2_webp.mbtiles");
		Relief90SQLiteConnection = method_9(Main.TopLevelWritableRoot + "\\WW\\Cache\\Relief_90_webp.mbtiles");
		ReliefBathymetrySRTM3SQLiteConnection = method_9(Main.TopLevelWritableRoot + "\\WW\\Cache\\ReliefBathymetry2603.mbtiles");
		LandCover300SQLiteConnection = method_9(Main.TopLevelWritableRoot + "\\WW\\Cache\\LandCover_300_webp.mbtiles");
		if (File.Exists(Main.TopLevelWritableRoot + "\\WW\\Cache\\S2Cloudless_webp.mbtiles"))
		{
			bool_0 = false;
			S2CloudlessSQLiteConnection = method_9(Main.TopLevelWritableRoot + "\\WW\\Cache\\S2Cloudless_webp.mbtiles");
		}
		else
		{
			bool_0 = true;
			string text = Main.TopLevelWritableRoot + "\\WW\\Cache\\S2Cloudless_webp\\TileManifest.db3";
			if (File.Exists(text))
			{
				sqliteConnection_1 = method_9(text);
			}
		}
		BordersCoastOlder = new PolygonLayer(Main.TopLevelWritableRoot + "\\GIS\\MappingHacks\\world_borders_1976-1989.shp");
		BordersCoastNewer = new PolygonLayer(Main.TopLevelWritableRoot + "\\GIS\\MappingHacks\\world_borders.shp");
		ArcticIce = new PolygonLayer(Main.TopLevelWritableRoot + "\\GIS\\SeaIce\\Arctic\\nic_autoc2012270n_pl_a.shp");
	}

	private int method_0(float float_1)
	{
		if (float_1 > 2000000f)
		{
			return 0;
		}
		if (float_1 > 1200000f)
		{
			return 1;
		}
		if (float_1 > 900000f)
		{
			return 2;
		}
		if (float_1 > 600000f)
		{
			return 3;
		}
		return 4;
	}

	private int method_1(float float_1)
	{
		return method_2(float_1, 1.0);
	}

	private int method_2(float float_1, double double_0)
	{
		double d = Math.Min(1.0, float_1 / 6378137f);
		double num = 2.0 * Math.Asin(d) * 180.0 / Math.PI * double_0;
		if (num > 0.0)
		{
			int val = 3 + (int)Math.Ceiling(Math.Log(180.0 / num, 2.0));
			return Math.Max(3, Math.Min(19, val));
		}
		return 19;
	}

	internal int GetLevel(Layer layer, FileSystemLayer fileSystemLayer, float altitude)
	{
		int result;
		switch (layer)
		{
		default:
			result = 0;
			goto IL_0084;
		case Layer.FileSystem:
			switch (fileSystemLayer)
			{
			default:
				return 0;
			case FileSystemLayer.BMNG:
				return method_0(altitude);
			case FileSystemLayer.Stamen:
				if (StamenLayer == StamenLayer.Labels)
				{
					return method_2(altitude, 1.1);
				}
				return method_1(altitude);
			case FileSystemLayer.Sentinel:
			case FileSystemLayer.OpenTopo:
			case FileSystemLayer.const_4:
				return method_1(altitude);
			}
		case Layer.OSM:
			return method_1(altitude);
		case Layer.BMNGOSM:
			return method_1(altitude);
		case Layer.OSMOSM:
		case Layer.const_4:
		case Layer.Line:
			result = 0;
			goto IL_0084;
		case Layer.Bing:
			{
				return method_1(altitude);
			}
			IL_0084:
			return result;
		}
	}

	private float method_3(int int_0)
	{
		return int_0 switch
		{
			0 => 2000000f, 
			1 => 1200000f, 
			2 => 900000f, 
			3 => 600000f, 
			_ => 0f, 
		};
	}

	private float method_4(int int_0)
	{
		return int_0 switch
		{
			3 => 6000000f, 
			4 => 4000000f, 
			5 => 2500000f, 
			6 => 1250000f, 
			7 => 650000f, 
			8 => 350000f, 
			9 => 200000f, 
			10 => 80000f, 
			11 => 40000f, 
			12 => 20000f, 
			_ => 0f, 
		};
	}

	internal float GetAltitude(Layer layer, FileSystemLayer fileSystemLayer, int level)
	{
		switch (layer)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer)
			{
			case FileSystemLayer.BMNG:
				return method_3(level);
			default:
				return 0f;
			case FileSystemLayer.Stamen:
			case FileSystemLayer.Sentinel:
			case FileSystemLayer.OpenTopo:
			case FileSystemLayer.const_4:
				return method_4(level);
			}
		case Layer.OSM:
			return method_4(level);
		case Layer.BMNGOSM:
			return method_4(level);
		default:
			return 0f;
		case Layer.Bing:
			return method_4(level);
		}
	}

	private void method_5(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, float float_1, float float_2, float float_3, int int_0, bool bool_1)
	{
		int level = GetLevel(layer_0, fileSystemLayer_0, float_3);
		int num;
		switch (layer_0)
		{
		default:
			num = 0;
			break;
		case Layer.FileSystem:
			FileSystemLevel = level;
			num = 0;
			break;
		case Layer.OSM:
			OSMLevel = level;
			num = 0;
			break;
		case Layer.BMNGOSM:
			BMNGOSMLevel = level;
			num = 0;
			break;
		case Layer.OSMOSM:
		case Layer.const_4:
		case Layer.Line:
			num = 0;
			break;
		case Layer.Bing:
			OSMLevel = level;
			num = 0;
			break;
		}
		int num2 = num;
		int num3 = 0;
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			case FileSystemLayer.BMNG:
				num2 = 0;
				num3 = 4;
				break;
			case FileSystemLayer.Stamen:
				num2 = 3;
				switch (StamenLayer)
				{
				case StamenLayer.Terrain:
					num3 = 18;
					break;
				case StamenLayer.Labels:
					num3 = 10;
					if (float_3 < 100000f)
					{
						return;
					}
					break;
				case StamenLayer.Lines:
					num3 = 12;
					break;
				}
				break;
			case FileSystemLayer.Sentinel:
				num2 = 4;
				num3 = 13;
				break;
			case FileSystemLayer.OpenTopo:
			case FileSystemLayer.const_4:
				num2 = 3;
				num3 = 18;
				break;
			}
			break;
		case Layer.OSM:
			num2 = 4;
			switch (osm_MBTiles_Layer_0)
			{
			case OSM_MBTiles_Layer.Relief90:
				num3 = 11;
				break;
			case OSM_MBTiles_Layer.ReliefBathymetrySRTM3:
				num3 = 11;
				break;
			case OSM_MBTiles_Layer.LandCover300:
				num3 = 9;
				break;
			case OSM_MBTiles_Layer.Sentinel:
				num3 = 13;
				break;
			}
			break;
		case Layer.BMNGOSM:
			num2 = 4;
			num3 = 8;
			break;
		case Layer.Bing:
			num2 = 4;
			num3 = 25;
			break;
		}
		int num4 = Convert.ToInt32(3.0 * Math.Pow(Math.Abs(float_2) / 90f, 2.1));
		level -= num4;
		level = Math.Min(level, num3);
		level = Math.Max(num2, level);
		rLryivRoPsl(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, level, float_1, float_2, float_3, int_0, bool_1: false);
		if (Main.AggressiveTileManagement)
		{
			if (level != num3 - num4)
			{
				rLryivRoPsl(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, level + 1, float_1, float_2, float_3, int_0, bool_1: true);
			}
			if (level != num2)
			{
				rLryivRoPsl(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, level - 1, float_1, float_2, float_3, int_0, bool_1: true);
			}
		}
	}

	private void rLryivRoPsl(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, int int_0, float float_1, float float_2, float float_3, int int_1, bool bool_1)
	{
		if (float_3 == 0f)
		{
			float_3 = GetAltitude(layer_0, fileSystemLayer_0, int_0);
		}
		float num = 90f + float_2;
		float float_4 = 180f + float_1;
		int num2 = 0;
		int num3 = 0;
		int int_2 = 0;
		float num4 = 0f;
		switch (layer_0)
		{
		case Layer.FileSystem:
			switch (fileSystemLayer_0)
			{
			case FileSystemLayer.BMNG:
				num2 = Levels[int_0];
				num3 = num2 * 2;
				num4 = 180f / (float)num2;
				int_2 = (int)(num / num4);
				break;
			case FileSystemLayer.Stamen:
				num2 = SlippyLevels[int_0];
				int_2 = num2 - (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				int_2 = Math.Min(num2, int_2);
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			case FileSystemLayer.Sentinel:
				num2 = SlippyLevels[int_0];
				int_2 = num2 - (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				int_2 = Math.Min(num2, int_2);
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			case FileSystemLayer.OpenTopo:
			case FileSystemLayer.const_4:
				num2 = SlippyLevels[int_0];
				int_2 = num2 - (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
				int_2 = Math.Min(num2, int_2);
				num3 = num2;
				num4 = 180f / (float)num3;
				break;
			}
			break;
		case Layer.OSM:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = SlippyLevels[int_0];
			int_2 = Math.Min(num2, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		case Layer.BMNGOSM:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = SlippyLevels[int_0];
			int_2 = Math.Max(0, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		case Layer.Bing:
			int_2 = (int)((1.0 - Math.Log(Math.Tan((double)float_2 * Math.PI / 180.0) + 1.0 / Math.Cos((double)float_2 * Math.PI / 180.0)) / Math.PI) / 2.0 * (double)(1 << int_0));
			num2 = SlippyLevels[int_0];
			int_2 = Math.Min(num2, int_2);
			num4 = 180f / (float)num2;
			num3 = num2;
			break;
		}
		float float_5 = 360f / (float)num3;
		int num5 = 0;
		float num6 = float_2;
		float num7;
		do
		{
			num7 = method_8(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_2, float_3, int_0, num2, num3, float_4, num4, float_5, int_2, num5, num6, int_1, bool_1);
			num6 += num4;
			num5++;
		}
		while (!(num6 >= 90f) && !(num7 <= 0f));
		int num8;
		if (20f < float_2 && float_2 < 83f)
		{
			method_8(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_2, float_3, int_0, num2, num3, float_4, num4, float_5, int_2, num5, num6, int_1, bool_1);
			num8 = -1;
		}
		else
		{
			num8 = -1;
		}
		num5 = num8;
		num6 = float_2 - num4;
		if (num6 > -90f)
		{
			do
			{
				num7 = method_8(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_2, float_3, int_0, num2, num3, float_4, num4, float_5, int_2, num5, num6, int_1, bool_1);
				num6 -= num4;
				num5--;
			}
			while (!(num6 <= -90f) && !(num7 <= 0f));
			if (-83f < float_2 && float_2 < -20f)
			{
				method_8(layer_0, fileSystemLayer_0, osm_MBTiles_Layer_0, float_2, float_3, int_0, num2, num3, float_4, num4, float_5, int_2, num5, num6, int_1, bool_1);
			}
		}
	}

	public void ManageTiles(float longitude, float latitude, float altitude)
	{
		TilesLoaded = 0;
		if (Main.AggressiveTileManagement)
		{
			foreach (KeyValuePair<string, DrawParameters> tile in Tiles)
			{
				DrawParameters value = tile.Value;
				value.Hold = false;
				Tiles[tile.Key] = value;
			}
		}
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		if (RenderState.SentinelMap)
		{
			flag2 = false;
			flag3 = false;
			if (bool_0)
			{
				method_5(Layer.FileSystem, FileSystemLayer.Sentinel, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 1, bool_1: true);
			}
			else
			{
				method_5(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Sentinel, longitude, latitude, altitude, 1, bool_1: true);
			}
		}
		else if (RenderState.OpenTopoOverlay)
		{
			flag2 = false;
			flag3 = false;
			flag = false;
			method_5(Layer.FileSystem, FileSystemLayer.OpenTopo, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 1, bool_1: false);
		}
		else if (RenderState.LandCoverOverlay)
		{
			flag2 = false;
			method_5(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.LandCover300, longitude, latitude, altitude, 1, bool_1: false);
		}
		if (flag && RenderState.PlacenamesOverlay)
		{
			StamenLayer = StamenLayer.Labels;
			method_5(Layer.FileSystem, FileSystemLayer.Stamen, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 0, bool_1: false);
		}
		if (RenderState.bool_1)
		{
			flag2 = false;
			flag3 = false;
			flag = false;
			method_5(Layer.FileSystem, FileSystemLayer.const_4, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 1, bool_1: false);
		}
		int num;
		if (!RenderState.BingMap)
		{
			if (RenderState.ReliefBathymetryMap)
			{
				if (!flag2)
				{
					num = 0;
				}
				else
				{
					method_5(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.ReliefBathymetrySRTM3, longitude, latitude, altitude, 2, bool_1: true);
					num = 0;
				}
			}
			else if (RenderState.BMNGMap)
			{
				if (flag2)
				{
					method_5(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Relief90, longitude, latitude, altitude, 2, bool_1: false);
				}
				if (!flag3)
				{
					goto IL_01c9;
				}
				method_5(Layer.FileSystem, FileSystemLayer.BMNG, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 3, bool_1: true);
				num = 0;
			}
			else
			{
				if (!RenderState.bool_0)
				{
					goto IL_01c9;
				}
				if (flag2)
				{
					method_5(Layer.OSM, FileSystemLayer.None, OSM_MBTiles_Layer.Relief90, longitude, latitude, altitude, 2, bool_1: false);
				}
				if (!flag3)
				{
					num = 0;
				}
				else
				{
					method_5(Layer.BMNGOSM, FileSystemLayer.None, OSM_MBTiles_Layer.BMNG, longitude, latitude, altitude, 3, bool_1: true);
					num = 0;
				}
			}
		}
		else if (!(flag2 || flag3))
		{
			num = 0;
		}
		else
		{
			method_5(Layer.Bing, FileSystemLayer.None, OSM_MBTiles_Layer.None, longitude, latitude, altitude, 2, bool_1: false);
			num = 0;
		}
		goto IL_01e3;
		IL_01e3:
		for (int i = num; i < TileTasks.Count; i++)
		{
			CancellableTask cancellableTask = TileTasks[i];
			switch (cancellableTask.Task.Status)
			{
			case TaskStatus.RanToCompletion:
				TileTasks.RemoveAt(i);
				continue;
			case TaskStatus.Canceled:
				TileTasks.RemoveAt(i);
				TryRemoveTile(cancellableTask.ID);
				continue;
			case TaskStatus.Faulted:
				TileTasks.RemoveAt(i);
				continue;
			}
			if (Tiles.TryGetValue(cancellableTask.ID, out var value2) && !value2.Draw)
			{
				cancellableTask.TokenSource.Cancel();
			}
			i++;
		}
		TextureParameters result;
		while (TileTextures.TryDequeue(out result))
		{
			string path = result.Path;
			if (!Tiles.TryGetValue(path, out var value3))
			{
				continue;
			}
			if (!YshyMeXwYbc.TextureCache.ShaderResourceViews.TryGetValue(path, out var value4))
			{
				IComObject<ID3D11Texture2D> resource = YshyMeXwYbc.Device.CreateTexture2D<ID3D11Texture2D>(result.Description, result.Data);
				result.Collector.Free();
				if (result.RentedBuffer != null)
				{
					ArrayPool<uint>.Shared.Return(result.RentedBuffer);
				}
				value4 = YshyMeXwYbc.Device.CreateShaderResourceView(resource);
				YshyMeXwYbc.TextureCache.ShaderResourceViews.Add(path, value4);
			}
			value3.ShaderResourceView = value4;
			Tiles[path] = value3;
		}
		int num2 = TileHistory.Count - KeepTiles;
		int num3 = TileHistory.Count;
		while (num3 > 0 && num2 > 0)
		{
			string text = TileHistory.Dequeue();
			if (Tiles.TryGetValue(text, out var value5))
			{
				if (!value5.Draw && !value5.Hold)
				{
					TryRemoveTile(text);
					num2--;
				}
				else
				{
					TileHistory.Enqueue(text);
				}
			}
			num3--;
		}
		return;
		IL_01c9:
		num = 0;
		goto IL_01e3;
	}

	internal void TryRemoveTile(string path)
	{
		Tiles.TryRemove(path, out var value);
		YshyMeXwYbc.TextureCache.ShaderResourceViews.Remove(path);
		if (value.ShaderResourceView != null)
		{
			value.ShaderResourceView.Object.GetResource(out var ppResource);
			((IDisposable)new ComObject<ID3D11Resource>(ppResource)).Dispose();
			value.ShaderResourceView.Dispose();
		}
	}

	private double method_6(int int_0, int int_1)
	{
		double d = Math.Sinh(Math.PI - Math.PI * 2.0 * (double)int_1 / (double)(1 << int_0));
		return 180.0 / Math.PI * Math.Atan(d);
	}

	private string method_7(string string_0, int int_0, int int_1, int int_2)
	{
		return Main.TopLevelWritableRoot + $"/WW/Cache/{string_0}/{int_0}/{int_1}/{int_2}.png";
	}

	private float method_8(Layer layer_0, FileSystemLayer fileSystemLayer_0, OSM_MBTiles_Layer osm_MBTiles_Layer_0, float float_1, float float_2, int int_0, int int_1, int int_2, float float_3, float float_4, float float_5, int int_3, int int_4, float float_6, int int_5, bool bool_1)
	{
		switch (layer_0)
		{
		case Layer.FileSystem:
		{
			FileSystemLayer fileSystemLayer = fileSystemLayer_0;
			if (fileSystemLayer <= FileSystemLayer.const_4)
			{
				int_3 += int_4;
			}
			break;
		}
		case Layer.OSM:
			int_3 -= int_4;
			break;
		case Layer.BMNGOSM:
			int_3 -= int_4;
			break;
		default:
			throw new ArgumentException("Unsupported layer for tile loading: " + layer_0);
		case Layer.Bing:
			int_3 -= int_4;
			break;
		}
		if (int_1 - int_3 < 0)
		{
			return 0f;
		}
		float num = Math.Abs(float_6 - float_1);
		float num2 = float_0 / 2f;
		double num3 = 1.0 - Math.Pow(num, 2.0) / Math.Pow(90.0, 2.0);
		double num4 = Math.Tan(num2 * (float)num3) * (double)float_2 * 2.0;
		float num5 = (float_2 + 12756274f) / 12756274f;
		double num6 = num4 * (double)num5;
		float num7 = 1f;
		num7 = ((!(Math.Abs(float_1) < 60f)) ? ((float)Math.Max(0.5, 1f - (90f - Math.Abs(float_1) / 30f))) : ((float)(1.0 + 27.0 / (double)Math.Max(Math.Abs(float_1), 10f))));
		if ((double)(num7 * (num - float_4)) > num6 / 111319.4921875)
		{
			return 0f;
		}
		double num8 = Math.Cos(Math.Abs(float_6) * ((float)Math.PI / 180f)) * 40075016.0;
		num6 = Math.Min(num8, num6);
		double num9 = num6 / num8;
		if (num9 == 0.0)
		{
			return (float)num9;
		}
		double num10 = num9 * 360.0 / 2.0;
		int num11 = Main.Instance.ScreenWidth / Main.Instance.ScreenHeight;
		num10 *= (double)num11 * 1.5;
		if (Math.Abs(float_1) > 80f)
		{
			num10 *= 2.0;
		}
		double num12 = (double)float_3 - num10 - (double)(float_5 * 3f);
		double num13 = (double)float_3 + num10 + (double)(float_5 * 2f);
		for (int i = 0; i < int_2; i++)
		{
			int int_6 = i;
			float num14 = (float)int_6 * float_5;
			if ((!(num12 < (double)num14) || !((double)num14 < num13)) && (!(0f <= num14) || !((double)num14 < num13 - 360.0)) && (!(num12 < 0.0) || !(360.0 + num12 < (double)num14) || !(num14 < 360f)))
			{
				continue;
			}
			string string_0 = "";
			Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
			switch (layer_0)
			{
			case Layer.FileSystem:
				switch (fileSystemLayer_0)
				{
				case FileSystemLayer.BMNG:
					string_0 = Main.TopLevelWritableRoot + string.Format("/WW/Cache/BMNGv2/{0}/{1,0:0000}/{1,0:0000}_{2,0:0000}.png", int_0, int_3, int_6);
					break;
				case FileSystemLayer.Stamen:
					switch (StamenLayer)
					{
					case StamenLayer.Terrain:
						utf16ValueStringBuilder.Append("Stamen Terrain ");
						utf16ValueStringBuilder.Append(int_0);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_6);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_1 - int_3);
						utf16ValueStringBuilder.Append(".png");
						string_0 = utf16ValueStringBuilder.ToString();
						break;
					case StamenLayer.Labels:
						utf16ValueStringBuilder.Append("Stamen Terrain - Labels ");
						utf16ValueStringBuilder.Append(int_0);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_6);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_1 - int_3);
						utf16ValueStringBuilder.Append(".png");
						string_0 = utf16ValueStringBuilder.ToString();
						break;
					case StamenLayer.Lines:
						utf16ValueStringBuilder.Append("Stamen Terrain - Lines ");
						utf16ValueStringBuilder.Append(int_0);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_6);
						utf16ValueStringBuilder.Append("/");
						utf16ValueStringBuilder.Append(int_1 - int_3);
						utf16ValueStringBuilder.Append(".png");
						string_0 = utf16ValueStringBuilder.ToString();
						break;
					}
					break;
				case FileSystemLayer.Sentinel:
					utf16ValueStringBuilder.Append(int_0);
					utf16ValueStringBuilder.Append("/");
					utf16ValueStringBuilder.Append(int_6);
					utf16ValueStringBuilder.Append("/");
					utf16ValueStringBuilder.Append(int_1 - int_3);
					utf16ValueStringBuilder.Append(".webp");
					string_0 = utf16ValueStringBuilder.ToString();
					break;
				case FileSystemLayer.OpenTopo:
				case FileSystemLayer.const_4:
					utf16ValueStringBuilder.Append(int_0);
					utf16ValueStringBuilder.Append("/");
					utf16ValueStringBuilder.Append(int_6);
					utf16ValueStringBuilder.Append("/");
					utf16ValueStringBuilder.Append(int_1 - int_3);
					utf16ValueStringBuilder.Append(".png");
					string_0 = utf16ValueStringBuilder.ToString();
					break;
				}
				break;
			case Layer.OSM:
				string_0 = osm_MBTiles_Layer_0.ToString() + "#" + int_0 + ":" + int_3 + "-" + int_6;
				break;
			case Layer.BMNGOSM:
				string_0 = layer_0.ToString() + "#" + int_0 + ":" + int_3 + "-" + int_6;
				break;
			case Layer.Bing:
				string_0 = TileSystem.TileXYToQuadKey(int_6, int_3, int_0);
				break;
			}
			utf16ValueStringBuilder.Dispose();
			if (!Tiles.TryGetValue(string_0, out var value))
			{
				value = ((layer_0 == Layer.StamenLabels) ? Main.ForegroundWorldDrawParameters_Stamen : Main.WorldDrawParameters);
				value.u = 1f / (float)int_2 * (float)int_6;
				value.Hint = 0.9f;
				double num15 = 0.0;
				double num16 = 0.0;
				switch (layer_0)
				{
				case Layer.FileSystem:
					switch (fileSystemLayer_0)
					{
					case FileSystemLayer.BMNG:
						value.v = 1f / (float)int_1 * (float)(int_1 - 1 - int_3);
						value.vWidth = 1f / (float)int_1;
						break;
					case FileSystemLayer.Stamen:
						num15 = method_6(int_0, int_1 - int_3);
						num16 = method_6(int_0, int_1 - int_3 + 1);
						value.v = (float)(90.0 - num15) / 180f;
						value.vWidth = (float)((90.0 - num16) / 180.0 - (double)value.v);
						if (StamenLayer.Labels == StamenLayer)
						{
							value.Layer = Layer.StamenLabels;
						}
						else
						{
							value.Layer = Layer.OSM;
						}
						value.Row = (uint)(int_1 - int_3);
						value.Level = (uint)int_0;
						value.Hint = 0.35f;
						break;
					case FileSystemLayer.Sentinel:
					case FileSystemLayer.OpenTopo:
					case FileSystemLayer.const_4:
						num15 = method_6(int_0, int_1 - int_3);
						num16 = method_6(int_0, int_1 - int_3 + 1);
						value.v = (float)(90.0 - num15) / 180f;
						value.vWidth = (float)((90.0 - num16) / 180.0 - (double)value.v);
						value.Layer = Layer.OSM;
						value.Row = (uint)(int_1 - int_3);
						value.Level = (uint)int_0;
						break;
					}
					break;
				case Layer.OSM:
					num15 = method_6(int_0, int_3);
					num16 = method_6(int_0, int_3 + 1);
					value.v = (float)(90.0 - num15) / 180f;
					value.vWidth = (float)((90.0 - num16) / 180.0 - (double)value.v);
					value.Layer = layer_0;
					value.Row = (uint)int_3;
					value.Level = (uint)int_0;
					break;
				case Layer.BMNGOSM:
					num15 = method_6(int_0, int_3);
					num16 = method_6(int_0, int_3 + 1);
					value.v = (float)(90.0 - num15) / 180f;
					value.vWidth = (float)((90.0 - num16) / 180.0 - (double)value.v);
					value.Layer = layer_0;
					value.Row = (uint)int_3;
					value.Level = (uint)int_0;
					break;
				case Layer.Bing:
					num15 = method_6(int_0, int_3);
					num16 = method_6(int_0, int_3 + 1);
					value.v = (float)(90.0 - num15) / 180f;
					value.vWidth = (float)((90.0 - num16) / 180.0 - (double)value.v);
					value.Layer = Layer.Bing;
					value.Row = (uint)int_3;
					value.Level = (uint)int_0;
					break;
				}
				value.uWidth = 1f / (float)int_2;
				value.Level = (uint)int_0;
				value.Priority = int_5;
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				CancellationToken token = cancellationTokenSource.Token;
				Task task = new Task(delegate
				{
					//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
					//IL_03cd: Expected O, but got Unknown
					switch (layer_0)
					{
					case Layer.FileSystem:
						switch (fileSystemLayer_0)
						{
						case FileSystemLayer.BMNG:
							BuildTexture(string_0, synchronous: false);
							break;
						case FileSystemLayer.Stamen:
							switch (StamenLayer)
							{
							case StamenLayer.Terrain:
							{
								string pathId = string_0.Substring(15);
								LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, pathId, "Stamen Terrain", "/WW/Cache/Stamen Terrain/", "http://tile.stamen.com/terrain/", ImageFormat.png);
								break;
							}
							case StamenLayer.Labels:
							{
								string pathId = string_0.Substring(24);
								LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, pathId, "Stamen Labels", "/WW/Cache/Stamen Terrain - Labels/", "http://warfaresims.slitherine.com/MapTiles/Labels/", ImageFormat.png);
								break;
							}
							case StamenLayer.Lines:
							{
								string pathId = string_0.Substring(23);
								LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, pathId, "Stamen Lines", "/WW/Cache/Stamen Terrain - Lines/", "http://tile.stamen.com/terrain-lines/", ImageFormat.png);
								break;
							}
							}
							break;
						case FileSystemLayer.Sentinel:
							LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, string_0, "Sentinel", "\\WW\\Cache\\S2Cloudless_webp\\", "http://warfaresims.slitherine.com/MapTiles/S2Cloudless_webp/", ImageFormat.webp);
							break;
						case FileSystemLayer.OpenTopo:
						{
							string remoteRootURL = "https://tile.opentopomap.org/";
							switch (new Random().Next(1, 4))
							{
							case 1:
								remoteRootURL = "https://a.tile.opentopomap.org/";
								break;
							case 2:
								remoteRootURL = "https://b.tile.opentopomap.org/";
								break;
							case 3:
								remoteRootURL = "https://c.tile.opentopomap.org/";
								break;
							}
							LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, string_0, "OpenTopo", "/WW/Cache/OpenTopoMap/", remoteRootURL, ImageFormat.png);
							break;
						}
						case FileSystemLayer.const_4:
							LoadCacheableTile(string_0, int_0, int_6, int_1 - int_3, string_0, "OSM_Vector", "/GIS/OSM_Vector/", "", ImageFormat.png);
							break;
						}
						break;
					case Layer.OSM:
					{
						byte[] array2 = method_11(osm_MBTiles_Layer_0, int_0, int_3, int_6);
						if (array2 != null)
						{
							BuildTexture(string_0, array2, ImageFormat.webp);
						}
						break;
					}
					case Layer.BMNGOSM:
					{
						byte[] array3 = method_11(osm_MBTiles_Layer_0, int_0, int_3, int_6);
						if (array3 != null)
						{
							BuildTexture(string_0, array3, ImageFormat.webp);
						}
						break;
					}
					case Layer.Bing:
					{
						byte[] array = LoadBingTile(string_0);
						if (array != null)
						{
							Bitmap bitmap = new Bitmap((Stream)new MemoryStream(array));
							BuildTexture(string_0, bitmap, synchronous: false);
						}
						break;
					}
					case Layer.OSMOSM:
					case Layer.const_4:
					case Layer.Line:
						break;
					}
				}, token);
				TileTasks.Add(new CancellableTask
				{
					ID = string_0,
					Task = task,
					TokenSource = cancellationTokenSource
				});
				task.Start();
				TileHistory.Enqueue(string_0);
			}
			TilesLoaded++;
			if (!bool_1)
			{
				value.Draw = true;
			}
			else
			{
				value.Hold = true;
			}
			Tiles[string_0] = value;
		}
		return (float)num9;
	}

	private SQLiteConnection method_9(string string_0)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection($"Data Source={string_0};Version=3;Read Only=True;");
			sQLiteConnection.Open();
			return sQLiteConnection;
		}
		catch (Exception innerException)
		{
			throw new Exception("Exception while opening SQLiteConnection for " + string_0, innerException);
		}
	}

	internal SQLiteConnection method_10(OSM_MBTiles_Layer layer)
	{
		return layer switch
		{
			OSM_MBTiles_Layer.BMNG => sqliteConnection_0, 
			OSM_MBTiles_Layer.Relief90 => Relief90SQLiteConnection, 
			OSM_MBTiles_Layer.ReliefBathymetrySRTM3 => ReliefBathymetrySRTM3SQLiteConnection, 
			OSM_MBTiles_Layer.LandCover300 => LandCover300SQLiteConnection, 
			OSM_MBTiles_Layer.Sentinel => S2CloudlessSQLiteConnection, 
			_ => throw new ArgumentException("No SQLLite connection for: " + layer), 
		};
	}

	internal byte[] method_11(OSM_MBTiles_Layer layer, int level, int row, int column)
	{
		Dictionary<OSM_MBTiles_Layer, Class26> value = threadLocal_1.Value;
		if (!value.TryGetValue(layer, out var value2))
		{
			SQLiteCommand sQLiteCommand = method_10(layer).CreateCommand();
			sQLiteCommand.CommandText = "SELECT tile_data FROM tiles WHERE tile_column = @col AND tile_row = @row AND zoom_level = @zoom;";
			SQLiteParameter sQLiteParameter = new SQLiteParameter("@col", DbType.Int32)
			{
				Value = column
			};
			SQLiteParameter sQLiteParameter2 = new SQLiteParameter("@row", DbType.Int32)
			{
				Value = row
			};
			SQLiteParameter sQLiteParameter3 = new SQLiteParameter("@zoom", DbType.Int32)
			{
				Value = level
			};
			sQLiteCommand.Parameters.Add(sQLiteParameter);
			sQLiteCommand.Parameters.Add(sQLiteParameter2);
			sQLiteCommand.Parameters.Add(sQLiteParameter3);
			SQLiteDataReader sqliteDataReader_ = sQLiteCommand.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.SequentialAccess);
			value2 = (value[layer] = new Class26(sQLiteCommand, sQLiteParameter, sQLiteParameter2, sQLiteParameter3, sqliteDataReader_));
		}
		else
		{
			((DbParameter)value2.object_0).Value = column;
			((DbParameter)value2.Row).Value = row;
			((DbParameter)value2.object_1).Value = level;
			((DbDataReader)value2.object_2).Close();
			value2.object_2 = value2.sqliteCommand_0.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.SequentialAccess);
			value[layer] = value2;
		}
		if (((DbDataReader)value2.object_2).Read())
		{
			byte[] value3 = threadLocal_0.Value;
			try
			{
				long bytes = ((DbDataReader)value2.object_2).GetBytes(0, 0L, value3, 0, value3.Length);
				byte[] array = new byte[bytes];
				Buffer.BlockCopy(value3, 0, array, 0, (int)bytes);
				return array;
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(value3);
			}
		}
		return null;
	}

	internal void LoadCacheableTile(string id, int ZoomValue, int ColumnValue, int RowValue, string pathId, string set, string localCache, string remoteRootURL, ImageFormat format)
	{
		string text = Main.TopLevelWritableRoot + localCache;
		byte[] array = null;
		Bitmap val = null;
		bool TileFoundOnLocalZip = false;
		switch (set)
		{
		case "OpenTopo":
			array = LoadLocalOrRemoteRasterTile(pathId, text, remoteRootURL);
			break;
		default:
			array = LoadLocalOrRemoteRasterTile(pathId, text, remoteRootURL);
			break;
		case "OSM_Vector":
			val = LoadLocalOrRemoteVectorTile(pathId, ZoomValue, ColumnValue, RowValue, text, remoteRootURL);
			break;
		case "Sentinel":
			if (sqliteConnection_1 != null && sqliteConnection_1.State == ConnectionState.Open)
			{
				if (new SQLiteHelper(sqliteConnection_1).ExecuteScalar("Select Count(*) from Tiles where zoom=" + ZoomValue + " and column=" + ColumnValue + " and row=" + RowValue, closeConnection: false) == "1")
				{
					array = LoadLocalTileFromPerZoomLevelPack(pathId, ZoomValue, ColumnValue, RowValue, text, remoteRootURL, out TileFoundOnLocalZip);
				}
			}
			else
			{
				array = LoadLocalOrRemoteRasterTile(pathId, text, remoteRootURL);
			}
			break;
		}
		if (array == null && val == null)
		{
			return;
		}
		if (val != null)
		{
			try
			{
				BuildTexture(id, val, synchronous: false);
				return;
			}
			catch (Exception)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
		}
		if (!TileFoundOnLocalZip)
		{
			string path = Path.Combine(text, pathId);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (!File.Exists(path))
			{
				File.WriteAllBytes(path, array);
			}
		}
		try
		{
			BuildTexture(id, array, format);
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal Bitmap LoadLocalOrRemoteVectorTile(string id, int ZoomValue, int ColumnValue, int RowValue, string localCacheRoot, string remoteRootURL)
	{
		if (theVectorTileSource == null)
		{
			InstantiateVectorTileSource();
		}
		return theVectorTileSource.GetTile(ColumnValue, RowValue, ZoomValue);
	}

	public static void InstantiateVectorTileSource()
	{
		theVectorTileSource = new VectorTileSource(new RemoteTileProvider("https://tiles.openfreemap.org/planet/latest/{z}/{x}/{y}.pbf", Path.Combine(GameGeneral.GISFolderPath, "OSM_Vector")));
	}

	internal byte[] LoadLocalOrRemoteRasterTile(string id, string localCacheRoot, string remoteRootURL)
	{
		string text = Path.Combine(localCacheRoot, id);
		if (FileExistsNative.FileExistsFast(text))
		{
			try
			{
				return File.ReadAllBytes(text);
			}
			catch
			{
			}
		}
		return HTTPHelper.DownloadTile(remoteRootURL + id);
	}

	internal byte[] LoadLocalTileFromPerZoomLevelPack(string filepath, int ZoomLevel, int ColumnValue, int RowValue, string localCacheRoot, string remoteRootURL, out bool TileFoundOnLocalZip)
	{
		string text = Path.Combine(localCacheRoot, ZoomLevel + ".mbtiles");
		if (FileExistsNative.FileExistsFast_CheckOnlyOnce(text))
		{
			try
			{
				if (!tdictionary_0.TryGetValue(text, out var value))
				{
					value = method_9(text);
					try
					{
						tdictionary_0.AddIfNotExists(text, value);
					}
					catch
					{
					}
				}
				byte[] result = null;
				using (DbCommand dbCommand = value.CreateCommand())
				{
					dbCommand.CommandText = $"SELECT tile_data FROM tiles WHERE tile_column = {ColumnValue} and tile_row = {RowValue} and zoom_level = {ZoomLevel};";
					result = dbCommand.ExecuteScalar() as byte[];
				}
				TileFoundOnLocalZip = true;
				return result;
			}
			catch (Exception)
			{
				TileFoundOnLocalZip = false;
				return LoadLocalOrRemoteRasterTile(filepath, localCacheRoot, remoteRootURL);
			}
		}
		TileFoundOnLocalZip = false;
		return LoadLocalOrRemoteRasterTile(filepath, localCacheRoot, remoteRootURL);
	}

	internal byte[] LoadBingTile(string id)
	{
		return HTTPHelper.DownloadTile("http://a" + id[id.Length - 1] + ".ortho.tiles.virtualearth.net/tiles/a" + id + ".jpeg?g=15");
	}

	internal Bitmap DecodeMBTile(byte[] data)
	{
		return simpleDecoder_0.DecodeFromBytes(data, data.Length);
	}

	private void method_12(byte[] byte_0, out int int_0, out int int_1)
	{
		int_0 = 0;
		int_1 = 0;
		GCHandle gCHandle = GCHandle.Alloc(byte_0, GCHandleType.Pinned);
		try
		{
			Imazen.WebP.Extern.NativeMethods.WebPGetInfo(gCHandle.AddrOfPinnedObject(), (UIntPtr)(ulong)byte_0.Length, ref int_0, ref int_1);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	private static void smethod_0(object object_0, int int_0)
	{
		uint num = (uint)((Main3D.TRANSPARENT_UNSAFE.A << 24) | (Main3D.TRANSPARENT_UNSAFE.R << 16) | (Main3D.TRANSPARENT_UNSAFE.G << 8) | Main3D.TRANSPARENT_UNSAFE.B);
		Color sHADOW = Main3D.SHADOW;
		int num2 = sHADOW.A << 24;
		sHADOW = Main3D.SHADOW;
		int num3 = num2 | (sHADOW.R << 16);
		sHADOW = Main3D.SHADOW;
		int num4 = num3 | (sHADOW.G << 8);
		sHADOW = Main3D.SHADOW;
		uint num5 = (uint)(num4 | sHADOW.B);
		for (int i = 0; i < int_0; i++)
		{
			if (((uint[])object_0)[i] == num)
			{
				((int[])object_0)[i] = (int)num5;
			}
		}
	}

	private IComObject<ID3D11ShaderResourceView> method_13(string string_0, byte[] byte_0, bool bool_1)
	{
		uint[] array = ArrayPool<uint>.Shared.Rent(65536);
		GCHandle gCHandle = GCHandle.Alloc(byte_0, GCHandleType.Pinned);
		GCHandle collector = GCHandle.Alloc(array, GCHandleType.Pinned);
		try
		{
			if (Imazen.WebP.Extern.NativeMethods.WebPDecodeBGRAInto(gCHandle.AddrOfPinnedObject(), (UIntPtr)(ulong)byte_0.Length, collector.AddrOfPinnedObject(), (UIntPtr)262144uL, 1024) == IntPtr.Zero)
			{
				collector.Free();
				ArrayPool<uint>.Shared.Return(array);
				return null;
			}
			if (bool_1)
			{
				smethod_0(array, 65536);
			}
			D3D11_TEXTURE2D_DESC description = new D3D11_TEXTURE2D_DESC
			{
				Width = 256u,
				Height = 256u,
				MipLevels = 1u,
				ArraySize = 1u,
				Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
				Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
				BindFlags = 8u
			};
			description.SampleDesc.Count = 1u;
			D3D11_SUBRESOURCE_DATA data = new D3D11_SUBRESOURCE_DATA
			{
				pSysMem = collector.AddrOfPinnedObject(),
				SysMemPitch = 1024u
			};
			TileTextures.Enqueue(new TextureParameters
			{
				Path = string_0,
				Description = description,
				Data = data,
				Collector = collector,
				RentedBuffer = array
			});
			return null;
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public IComObject<ID3D11ShaderResourceView> BuildTexture(string id, byte[] data, ImageFormat theImageFormat)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		if (YshyMeXwYbc.TextureCache.ShaderResourceViews.ContainsKey(id))
		{
			return YshyMeXwYbc.TextureCache.ShaderResourceViews[id];
		}
		switch (theImageFormat)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception();
		case ImageFormat.webp:
			return method_13(id, data, bool_1: false);
		case ImageFormat.png:
		{
			Bitmap bitmap;
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				try
				{
					bitmap = new Bitmap(Image.FromStream((Stream)memoryStream));
				}
				catch (Exception)
				{
					return null;
				}
			}
			return BuildTexture(id, bitmap, synchronous: false);
		}
		}
	}

	public IComObject<ID3D11ShaderResourceView> BuildTexture(string path, bool synchronous)
	{
		return BuildTexture(path, synchronous, shadow: false);
	}

	public IComObject<ID3D11ShaderResourceView> BuildTexture(string path, bool synchronous, bool shadow)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		if (!YshyMeXwYbc.TextureCache.ShaderResourceViews.ContainsKey(path))
		{
			if (File.Exists(path))
			{
				try
				{
					Bitmap bitmap = new Bitmap(path);
					return BuildTexture(path, bitmap, synchronous, shadow);
				}
				catch
				{
					if (Tiles.TryGetValue(path, out var value))
					{
						value.Undrawable = true;
						Tiles[path] = value;
					}
					return null;
				}
			}
			return null;
		}
		return YshyMeXwYbc.TextureCache.ShaderResourceViews[path];
	}

	public IComObject<ID3D11ShaderResourceView> BuildTexture(string id, Bitmap bitmap, bool synchronous)
	{
		return BuildTexture(id, bitmap, synchronous, shadow: false);
	}

	private void method_14(uint[] uint_1, LockBitmap lockBitmap_0, bool bool_1)
	{
		int height = lockBitmap_0.Height;
		int depth = lockBitmap_0.Depth;
		int width = lockBitmap_0.Width;
		_ = lockBitmap_0.Depth;
		byte[] pixels = lockBitmap_0.Pixels;
		int num = depth / 8;
		byte b = byte.MaxValue;
		byte b2 = 0;
		byte b3 = 0;
		byte b4 = 0;
		int num2 = 0;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				int num3 = (i * width + j) * num;
				if (num3 <= pixels.Length - num)
				{
					switch (depth)
					{
					case 32:
						b4 = pixels[num3];
						b3 = pixels[num3 + 1];
						b2 = pixels[num3 + 2];
						b = pixels[num3 + 3];
						break;
					case 24:
						b4 = pixels[num3];
						b3 = pixels[num3 + 1];
						b2 = pixels[num3 + 2];
						b = byte.MaxValue;
						break;
					case 8:
						b2 = (b3 = (b4 = pixels[num3]));
						b = byte.MaxValue;
						break;
					}
					if (bool_1 && b == unsafeColor_0.A && b2 == unsafeColor_0.R && b3 == unsafeColor_0.G && b4 == unsafeColor_0.B)
					{
						Color color = color_1;
						b = color.A;
						color = color_1;
						b2 = color.R;
						color = color_1;
						b3 = color.G;
						color = color_1;
						b4 = color.B;
					}
					uint_1[num2++] = (uint)((b << 24) | (b2 << 16) | (b3 << 8) | b4);
					continue;
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new IndexOutOfRangeException();
			}
		}
	}

	private void method_15(uint[] uint_1, LockBitmap lockBitmap_0, bool bool_1)
	{
		int height = lockBitmap_0.Height;
		int int_1 = lockBitmap_0.Depth;
		int int_2 = lockBitmap_0.Width;
		byte[] byte_0 = lockBitmap_0.Pixels;
		Parallel.For(0, height, delegate(int h)
		{
			int num = int_2 * h;
			for (int i = 0; i < int_2; i++)
			{
				UnsafeColor unsafeColor = lockBitmap_0.GetPixel_UnsafeColor(i, h, int_1, int_2, byte_0);
				if (bool_1 && unsafeColor.Equals(unsafeColor_0))
				{
					unsafeColor = new UnsafeColor(color_1);
				}
				uint_1[num++] = (uint)((unsafeColor.A << 24) | (unsafeColor.R << 16) | (unsafeColor.G << 8) | unsafeColor.B);
			}
		});
	}

	public IComObject<ID3D11ShaderResourceView> BuildTexture(string id, Bitmap bitmap, bool synchronous, bool shadow)
	{
		if (YshyMeXwYbc.TextureCache.ShaderResourceViews.ContainsKey(id))
		{
			return YshyMeXwYbc.TextureCache.ShaderResourceViews[id];
		}
		int height = ((Image)bitmap).Height;
		int width = ((Image)bitmap).Width;
		uint[] array = new uint[height * width];
		LockBitmap lockBitmap = new LockBitmap(bitmap);
		lockBitmap.LockBits();
		if (height <= 256 && width <= 256)
		{
			method_14(array, lockBitmap, shadow);
		}
		else
		{
			method_15(array, lockBitmap, shadow);
		}
		lockBitmap.UnlockBits();
		D3D11_TEXTURE2D_DESC d3D11_TEXTURE2D_DESC = new D3D11_TEXTURE2D_DESC
		{
			Width = (uint)width,
			Height = (uint)height,
			MipLevels = 1u,
			ArraySize = 1u,
			Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
			Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
			BindFlags = 8u
		};
		d3D11_TEXTURE2D_DESC.SampleDesc.Count = 1u;
		GCHandle collector = GCHandle.Alloc(array, GCHandleType.Pinned);
		D3D11_SUBRESOURCE_DATA d3D11_SUBRESOURCE_DATA = new D3D11_SUBRESOURCE_DATA
		{
			pSysMem = collector.AddrOfPinnedObject(),
			SysMemPitch = (uint)(width * 4)
		};
		if (!synchronous)
		{
			TextureParameters item = new TextureParameters
			{
				Path = id,
				Description = d3D11_TEXTURE2D_DESC,
				Data = d3D11_SUBRESOURCE_DATA,
				Collector = collector
			};
			TileTextures.Enqueue(item);
			return null;
		}
		IComObject<ID3D11Texture2D> resource = YshyMeXwYbc.Device.CreateTexture2D<ID3D11Texture2D>(d3D11_TEXTURE2D_DESC, d3D11_SUBRESOURCE_DATA);
		collector.Free();
		YshyMeXwYbc.TextureCache.ShaderResourceViews.Add(id, YshyMeXwYbc.Device.CreateShaderResourceView(resource));
		return YshyMeXwYbc.TextureCache.ShaderResourceViews[id];
	}

	public int GetAssignedLevel(float altitude)
	{
		return GetLevel(Layer.FileSystem, FileSystemLayer.OpenTopo, altitude);
	}

	public float GetAssignedAltitude(int level)
	{
		return GetAltitude(Layer.FileSystem, FileSystemLayer.OpenTopo, level);
	}

	static TileCache()
	{
		Class72.smethod_20();
	}
}
