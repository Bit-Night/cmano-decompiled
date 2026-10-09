using System;
using System.Buffers;
using System.Numerics;

namespace CSMaterial.ExWorldWind;

public sealed class MathEngine
{
	private MathEngine()
	{
	}

	public static Vector3 SphericalToCartesian(float latitude, float longitude, float radius)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		latitude *= (float)Math.PI / 180f;
		longitude *= (float)Math.PI / 180f;
		float num = MathF.Cos(latitude);
		float num2 = radius * num;
		return new Vector3(num2 * MathF.Cos(longitude), num2 * MathF.Sin(longitude), radius * MathF.Sin(latitude));
	}

	public static (Vector3[] theArray, int UsableArrayLength) SphericalToCartesian((float latitude, float longitude)[] SourceArray, float radius)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)CSMath.PI_dividedBy_180;
		int num2 = SourceArray.Length;
		Vector3[] array = ArrayPool<Vector3>.Shared.Rent(num2);
		for (int i = 0; i < num2; i++)
		{
			(float latitude, float longitude) tuple = SourceArray[i];
			float item = tuple.latitude;
			float item2 = tuple.longitude;
			item *= num;
			float x = item2 * num;
			float num3 = MathF.Cos(item);
			float num4 = MathF.Sin(item);
			float num5 = MathF.Cos(x);
			float num6 = MathF.Sin(x);
			float num7 = radius * num3;
			array[i] = new Vector3(num7 * num5, num7 * num6, radius * num4);
		}
		return (theArray: array, UsableArrayLength: num2);
	}

	public static Vector3 SphericalToCartesian(Angle latitude, Angle longitude, double radius)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		double radians = latitude.Radians;
		double radians2 = longitude.Radians;
		double num = radius * Math.Cos(radians);
		return new Vector3((float)(num * Math.Cos(radians2)), (float)(num * Math.Sin(radians2)), (float)(radius * Math.Sin(radians)));
	}

	public static Vector3 SphericalToCartesianSingle(Angle latitude, Angle longitude, float radius)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		double radians = latitude.Radians;
		double radians2 = longitude.Radians;
		double num = (double)radius * Math.Cos(radians);
		return new Vector3((float)(num * Math.Cos(radians2)), (float)(num * Math.Sin(radians2)), (float)((double)radius * Math.Sin(radians)));
	}

	public static (Vector3[] theArray, int UsableArrayLength) SphericalToCartesianDirect((double Lon, double Lat)[] coords, int count, float radius)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] array = ArrayPool<Vector3>.Shared.Rent(count);
		for (int i = 0; i < count; i++)
		{
			double num = coords[i].Lat * Math.PI / 180.0;
			double num2 = coords[i].Lon * Math.PI / 180.0;
			double num3 = (double)radius * Math.Cos(num);
			array[i] = new Vector3((float)(num3 * Math.Cos(num2)), (float)(num3 * Math.Sin(num2)), (float)((double)radius * Math.Sin(num)));
		}
		return (theArray: array, UsableArrayLength: count);
	}

	public static Point3d CartesianToSphericalD(double x, double y, double z)
	{
		double num = Math.Sqrt(x * x + y * y + z * z);
		double z2 = Math.Atan2(y, x);
		double y2 = Math.Asin(z / num);
		return new Point3d(num, y2, z2);
	}

	public static double DegreesToRadians(double degrees)
	{
		return degrees * CSMath.PI_dividedBy_180;
	}

	public static double RadiansToDegrees(double radians)
	{
		return radians * 180.0 / Math.PI;
	}

	static MathEngine()
	{
		Class72.smethod_20();
	}
}
