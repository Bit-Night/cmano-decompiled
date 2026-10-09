using System;
using System.Text;
using CSMaterial;

namespace Microsoft.MapPoint;

internal static class TileSystem
{
	private static double smethod_0(double double_0, double double_1, double double_2)
	{
		return Math.Min(Math.Max(double_0, double_1), double_2);
	}

	public static uint MapSize(int levelOfDetail)
	{
		return (uint)(256 << levelOfDetail);
	}

	public static double GroundResolution(double latitude, int levelOfDetail)
	{
		latitude = smethod_0(latitude, -85.05112878, 85.05112878);
		return Math.Cos(latitude * CSMath.PI_dividedBy_180) * 2.0 * Math.PI * 6378137.0 / (double)MapSize(levelOfDetail);
	}

	public static double MapScale(double latitude, int levelOfDetail, int screenDpi)
	{
		return GroundResolution(latitude, levelOfDetail) * (double)screenDpi / 0.0254;
	}

	public static void LatLongToPixelXY(double latitude, double longitude, int levelOfDetail, out int pixelX, out int pixelY)
	{
		latitude = smethod_0(latitude, -85.05112878, 85.05112878);
		longitude = smethod_0(longitude, -180.0, 180.0);
		double num = (longitude + 180.0) / 360.0;
		double num2 = Math.Sin(latitude * CSMath.PI_dividedBy_180);
		double num3 = 0.5 - Math.Log((1.0 + num2) / (1.0 - num2)) / (Math.PI * 4.0);
		uint num4 = MapSize(levelOfDetail);
		pixelX = (int)smethod_0(num * (double)num4 + 0.5, 0.0, num4 - 1);
		pixelY = (int)smethod_0(num3 * (double)num4 + 0.5, 0.0, num4 - 1);
	}

	public static void PixelXYToLatLong(int pixelX, int pixelY, int levelOfDetail, out double latitude, out double longitude)
	{
		double num = MapSize(levelOfDetail);
		double num2 = smethod_0(pixelX, 0.0, num - 1.0) / num - 0.5;
		double num3 = 0.5 - smethod_0(pixelY, 0.0, num - 1.0) / num;
		latitude = 90.0 - 360.0 * Math.Atan(Math.Exp((0.0 - num3) * 2.0 * Math.PI)) / Math.PI;
		longitude = 360.0 * num2;
	}

	public static void PixelXYToTileXY(int pixelX, int pixelY, out int tileX, out int tileY)
	{
		tileX = pixelX / 256;
		tileY = pixelY / 256;
	}

	public static void TileXYToPixelXY(int tileX, int tileY, out int pixelX, out int pixelY)
	{
		pixelX = tileX * 256;
		pixelY = tileY * 256;
	}

	public static string TileXYToQuadKey(int tileX, int tileY, int levelOfDetail)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = levelOfDetail; num > 0; num--)
		{
			char c = '0';
			int num2 = 1 << num - 1;
			if ((tileX & num2) != 0)
			{
				c = (char)(c + 1);
			}
			if ((tileY & num2) != 0)
			{
				c = (char)(c + 1);
				c = (char)(c + 1);
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	public static void QuadKeyToTileXY(string quadKey, out int tileX, out int tileY, out int levelOfDetail)
	{
		tileY = 0;
		tileX = 0;
		levelOfDetail = quadKey.Length;
		for (int num = levelOfDetail; num > 0; num--)
		{
			int num2 = 1 << num - 1;
			switch (quadKey[levelOfDetail - num])
			{
			case '1':
				tileX |= num2;
				break;
			case '2':
				tileY |= num2;
				break;
			case '3':
				tileX |= num2;
				tileY |= num2;
				break;
			case '0':
				break;
			default:
				throw new ArgumentException("Invalid QuadKey digit sequence.");
			}
		}
	}

	static TileSystem()
	{
		Class72.smethod_20();
	}
}
