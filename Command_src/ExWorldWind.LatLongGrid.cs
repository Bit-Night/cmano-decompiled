using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using CSMaterial.ExWorldWind;
using DirectN;
using DXRenderer;

namespace ExWorldWind;

public class LatLongGrid
{
	public double WorldRadius;

	protected double radius;

	public int MinVisibleLongitude;

	public int MaxVisibleLongitude;

	public int MinVisibleLatitude;

	public int MaxVisibleLatitude;

	public int LongitudeInterval;

	public int LatitudeInterval;

	public float LatitudeInterval_curved => (float)LatitudeInterval / 10f;

	public float LongitudeInterval_curved => (float)LongitudeInterval / 10f;

	public LatLongGrid()
	{
		WorldRadius = 6378137.0;
		method_1(1);
		method_1(2);
		method_1(5);
		method_1(10);
	}

	private double method_0(int int_0)
	{
		return WorldRadius + (double)(int_0 * (int_0 + int_0 / 4) * 100);
	}

	private void method_1(int int_0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)int_0 / 10f;
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Vector4 val = Main.IntToVector4(-928997216);
		Vector4 val2 = Main.IntToVector4(-1606360880);
		MinVisibleLatitude = -90;
		MinVisibleLongitude = -180;
		MaxVisibleLatitude = 90;
		MaxVisibleLongitude = 180;
		radius = method_0(int_0);
		int num2 = 0;
		for (float num3 = MinVisibleLongitude; num3 < (float)MaxVisibleLongitude; num3 += (float)int_0)
		{
			for (float num4 = MinVisibleLatitude; num4 <= (float)MaxVisibleLatitude; num4 += num)
			{
				Vector3 val3 = MathEngine.SphericalToCartesian(num4, num3, (float)radius);
				Vertex item = new Vertex(new Vector3(val3.Y, val3.Z, val3.X), val);
				list.Add(item);
				list2.Add((uint)num2++);
			}
			list2.Add(uint.MaxValue);
		}
		for (float num5 = MinVisibleLatitude; num5 <= (float)MaxVisibleLatitude; num5 += (float)int_0)
		{
			for (float num6 = MinVisibleLongitude; num6 <= (float)MaxVisibleLongitude; num6 += num)
			{
				Vector3 val4 = MathEngine.SphericalToCartesian(num5, num6, (float)radius);
				Vector4 c = val;
				if (num5 == 0f)
				{
					c = val2;
				}
				Vertex item2 = new Vertex(new Vector3(val4.Y, val4.Z, val4.X), c);
				list.Add(item2);
				list2.Add((uint)num2++);
			}
			list2.Add(uint.MaxValue);
		}
		Main.Instance.CreateLineDrawParemeters("Longitudes" + int_0, list.ToArray(), list2.ToArray(), D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP, blendable: false);
	}

	internal void Render(DrawArgs drawArgs)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		Main instance = Main.Instance;
		ComputeGridValues(drawArgs);
		float num = (float)drawArgs.WorldCamera.TrueViewRange.Degrees / 6f;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(drawArgs.WorldCamera.ReferenceCenter.X, drawArgs.WorldCamera.ReferenceCenter.Y, drawArgs.WorldCamera.ReferenceCenter.Z);
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Main.IntToVector4(-928997216);
		Main.IntToVector4(-1606360880);
		for (float num2 = MinVisibleLongitude; num2 < (float)MaxVisibleLongitude; num2 += (float)LongitudeInterval)
		{
			float num3 = (float)drawArgs.WorldCamera.Latitude.Degrees;
			if (num3 > 70f)
			{
				num3 = 70f;
			}
			if (num3 < -70f)
			{
				num3 = -70f;
			}
			Vector3 val2 = MathEngine.SphericalToCartesian(num3, num2, (float)radius);
			if (drawArgs.WorldCamera.ViewFrustum.ContainsPoint(val2))
			{
				int num4 = (int)num2;
				if (num4 <= -180)
				{
					num4 += 360;
				}
				else if (num4 > 180)
				{
					num4 -= 360;
				}
				string text = Math.Abs(num4).ToString();
				if (num4 < 0)
				{
					text += "W";
				}
				else if (num4 > 0 && num4 < 180)
				{
					text += "E";
				}
				val2 = drawArgs.WorldCamera.Project(val2 - val);
				Rectangle rectangle = new Rectangle((int)val2.X + 2, (int)val2.Y, 10, 10);
				instance?.DrawText(text, rectangle.Left, rectangle.Top);
			}
		}
		for (float num5 = MinVisibleLatitude; num5 <= (float)MaxVisibleLatitude; num5 += (float)LatitudeInterval)
		{
			float longitude = (float)drawArgs.WorldCamera.Longitude.Degrees + num;
			Vector3 val3 = MathEngine.SphericalToCartesian(num5, longitude, (float)radius);
			if (drawArgs.WorldCamera.ViewFrustum.ContainsPoint(val3))
			{
				val3 = drawArgs.WorldCamera.Project(val3 - val);
				float num6 = num5;
				if (num6 > 90f)
				{
					num6 = 180f - num6;
				}
				else if (num6 < -90f)
				{
					num6 = -180f - num6;
				}
				string text2 = ((int)Math.Abs(num6)).ToString();
				if (num6 > 0f)
				{
					text2 += "N";
				}
				else if (num6 < 0f)
				{
					text2 += "S";
				}
				Rectangle rectangle2 = new Rectangle((int)val3.X, (int)val3.Y, 10, 10);
				instance?.DrawText(text2, rectangle2.Left, rectangle2.Top);
			}
		}
		instance.DrawLineStrip("Longitudes" + LongitudeInterval, list.ToArray(), list2.ToArray());
		method_2(drawArgs);
	}

	private void method_2(DrawArgs drawArgs_0)
	{
		method_3(drawArgs_0, 23.439444f, "Tropic Of Cancer");
		method_3(drawArgs_0, -23.439444f, "Tropic Of Capricorn");
		method_3(drawArgs_0, 66.560555f, "Arctic Circle");
		method_3(drawArgs_0, -66.560555f, "Antarctic Circle");
	}

	private void method_3(DrawArgs drawArgs_0, float float_0, string string_0)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		Main instance = Main.Instance;
		int num = 0;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(drawArgs_0.WorldCamera.ReferenceCenter.X, drawArgs_0.WorldCamera.ReferenceCenter.Y, drawArgs_0.WorldCamera.ReferenceCenter.Z);
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Vector4 c = Main.IntToVector4(-1599020826);
		for (float num2 = MinVisibleLongitude; num2 <= (float)MaxVisibleLongitude; num2 += LongitudeInterval_curved)
		{
			Vector3 val2 = MathEngine.SphericalToCartesian(float_0, num2, (float)radius);
			Vertex item = new Vertex(new Vector3(val2.Y, val2.Z, val2.X), c);
			list.Add(item);
			list2.Add((uint)num++);
		}
		Vector3 val3 = MathEngine.SphericalToCartesian(Angle.FromDegrees(float_0), drawArgs_0.WorldCamera.Longitude - drawArgs_0.WorldCamera.TrueViewRange * 0.30000001192092896 * 0.5, radius);
		if (drawArgs_0.WorldCamera.ViewFrustum.ContainsPoint(val3))
		{
			val3 = drawArgs_0.WorldCamera.Project(val3 - val);
		}
		if (instance != null)
		{
			instance.DrawLineStrip(list.ToArray(), list2.ToArray());
			instance.DrawText(string_0, (int)val3.X, (int)val3.Y);
		}
	}

	internal void ComputeGridValues(DrawArgs drawArgs)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		double radians = drawArgs.WorldCamera.TrueViewRange.Radians;
		radians *= 1.0 + Math.Abs(Math.Sin(drawArgs.WorldCamera.Latitude.Radians));
		if (radians < 0.17)
		{
			LatitudeInterval = 1;
		}
		else if (radians < 0.6)
		{
			LatitudeInterval = 2;
		}
		else if (radians < 1.0)
		{
			LatitudeInterval = 5;
		}
		else
		{
			LatitudeInterval = 10;
		}
		LongitudeInterval = LatitudeInterval;
		if (drawArgs.WorldCamera.ViewFrustum.ContainsPoint(MathEngine.SphericalToCartesian(90f, 0f, (float)radius)) || drawArgs.WorldCamera.ViewFrustum.ContainsPoint(MathEngine.SphericalToCartesian(-90f, 0f, (float)radius)))
		{
			LongitudeInterval = 10;
		}
		MinVisibleLongitude = ((LongitudeInterval >= 10) ? (-180) : ((int)drawArgs.WorldCamera.Longitude.Degrees / LongitudeInterval * LongitudeInterval - 18 * LongitudeInterval));
		MaxVisibleLongitude = ((LongitudeInterval >= 10) ? 180 : ((int)drawArgs.WorldCamera.Longitude.Degrees / LongitudeInterval * LongitudeInterval + 18 * LongitudeInterval));
		MinVisibleLatitude = (int)drawArgs.WorldCamera.Latitude.Degrees / LatitudeInterval * LatitudeInterval - 9 * LatitudeInterval;
		MaxVisibleLatitude = (int)drawArgs.WorldCamera.Latitude.Degrees / LatitudeInterval * LatitudeInterval + 9 * LatitudeInterval;
		if (MaxVisibleLatitude - MinVisibleLatitude >= 180 || LongitudeInterval == 10)
		{
			MinVisibleLatitude = -90;
			MaxVisibleLatitude = 90;
		}
		radius = method_0(LongitudeInterval);
	}

	static LatLongGrid()
	{
		Class72.smethod_20();
	}
}
