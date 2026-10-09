using System;
using System.Numerics;
using DirectN;

namespace DXRenderer;

public class DXMiscUtils
{
	public const uint TRANSFORM_CONSTANT_BUFFER_ID = 2147483649u;

	public const float EARTH_MEAN_RADIUS = 6378137f;

	public static Vector4 MakeVectorColour(int colour)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4((float)((colour >> 16) & 0xFF) / 255f, (float)((colour >> 8) & 0xFF) / 255f, (float)(colour & 0xFF) / 255f, (float)((colour >> 24) & 0xFF) / 255f);
	}

	public static Vector4 MakeVectorColour(uint colour)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4((float)((colour >> 16) & 0xFF) / 255f, (float)((colour >> 8) & 0xFF) / 255f, (float)(colour & 0xFF) / 255f, (float)((colour >> 24) & 0xFF) / 255f);
	}

	public static float LatitudeToPhi(float lat)
	{
		lat += 90f;
		lat.Clamp(2.938736E-39f, 180f);
		return (1f - lat / 180f) * (float)Math.PI;
	}

	public static float LongitudeToTheta(float lon)
	{
		lon += 180f;
		lon.Clamp(2.938736E-39f, 180f);
		return (0.5f + lon / 360f * 2f) * (float)Math.PI;
	}

	static DXMiscUtils()
	{
		Class72.smethod_20();
	}
}
