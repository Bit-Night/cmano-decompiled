using System;
using System.Diagnostics;
using System.Threading;
using BitMiracle.LibTiff.Classic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GeoTIFF_Tile
{
	public string FileName;

	private Tiff tiff_0;

	internal int height;

	internal int width;

	internal double pixelSizeX;

	internal double pixelSizeY;

	internal double originLon;

	internal double originLat;

	internal double BottomEdgeLatitude;

	internal double RightEdgeLongitude;

	private double double_0;

	private double double_1;

	private LockObject lockObject_0;

	private MemoryCache memoryCache_0;

	private JaggedConcurrentMap<int> jaggedConcurrentMap_0;

	private readonly MemoryCacheEntryOptions memoryCacheEntryOptions_0;

	private byte[] method_0(int int_0)
	{
		memoryCache_0.TryGetValue<byte[]>(int_0, out byte[] value);
		return value;
	}

	private void method_1(int int_0, byte[] byte_0)
	{
		memoryCache_0.Set(int_0, byte_0, memoryCacheEntryOptions_0.SetSize(1L));
	}

	public GeoTIFF_Tile(string theFileName)
	{
		lockObject_0 = new LockObject();
		memoryCacheEntryOptions_0 = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60.0));
		FileName = theFileName;
	}

	public void Initialize()
	{
		if (string.IsNullOrEmpty(FileName))
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new Exception();
		}
		tiff_0 = Tiff.Open(FileName, "r");
		height = tiff_0.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
		width = tiff_0.ScanlineSize();
		MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions();
		memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromSeconds(30.0);
		memoryCacheOptions.Clock = new UTCProviderClock();
		jaggedConcurrentMap_0 = new JaggedConcurrentMap<int>(height);
		memoryCache_0 = new MemoryCache(memoryCacheOptions);
		FieldValue[] field = tiff_0.GetField(TiffTag.GEOTIFF_MODELPIXELSCALETAG);
		FieldValue[] field2 = tiff_0.GetField(TiffTag.GEOTIFF_MODELTIEPOINTTAG);
		byte[] bytes = field[1].GetBytes();
		pixelSizeX = BitConverter.ToDouble(bytes, 0);
		pixelSizeY = BitConverter.ToDouble(bytes, 8) * -1.0;
		byte[] bytes2 = field2[1].GetBytes();
		originLon = BitConverter.ToDouble(bytes2, 24);
		originLat = BitConverter.ToDouble(bytes2, 32);
		double_0 = originLat + pixelSizeY / 2.0;
		double_1 = originLon + pixelSizeX / 2.0;
		BottomEdgeLatitude = originLat + (double)height * pixelSizeY;
		RightEdgeLongitude = originLon + (double)width * pixelSizeX;
	}

	public int ReadValue(double theLon, double theLat)
	{
		(int, int) tuple = ProjToCell(theLon, theLat);
		int value = default(int);
		if (!jaggedConcurrentMap_0.TryGetValue(tuple.Item2, tuple.Item1, ref value))
		{
			byte[] array = new byte[width - 1 + 1];
			byte[] array2 = method_0(tuple.Item2);
			if (array2 == null)
			{
				object obj = lockObject_0;
				bool lockTaken = false;
				Monitor.Enter(obj, ref lockTaken);
				tiff_0.ReadScanline(array, tuple.Item2);
				method_1(tuple.Item2, array);
			}
			else
			{
				array = array2;
			}
			value = array[tuple.Item1];
			jaggedConcurrentMap_0[tuple.Item2, tuple.Item1] = value;
			return value;
		}
		return value;
	}

	internal (int column, int row) ProjToCell(double x, double y)
	{
		(int, int) result = default((int, int));
		try
		{
			int num = (int)Math.Round((x - double_1) / pixelSizeX);
			int num2 = (int)Math.Round((y - double_0) / pixelSizeY);
			if (num2 == -1)
			{
				num2 = 0;
			}
			if (num >= width)
			{
				num = width - 1;
			}
			if (num2 >= height)
			{
				num2 = height - 1;
			}
			if ((num < 0 || num2 < 0) && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (num, num2);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2034503295049630", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			int num = num3;
			int num2 = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static GeoTIFF_Tile()
	{
		Class72.smethod_20();
	}
}
