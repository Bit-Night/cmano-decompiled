using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using CSMaterial.ExWorldWind;
using DXRenderer;

namespace ExWorldWind;

public class Scale
{
	private float float_0;

	private float float_1;

	private string[] string_0 = new string[4];

	internal Scale()
	{
	}

	internal void Render(DrawArgs drawArgs)
	{
		float num = 0.0175f;
		int screenWidth = Main.Instance.ScreenWidth;
		int screenHeight = Main.Instance.ScreenHeight;
		Point point = new Point(Convert.ToInt32((float)((double)(float)screenWidth * 0.8499999940395355 / 2.0)), screenHeight / 2);
		Point point2 = new Point(Convert.ToInt32((float)((double)(float)screenWidth * 1.1500000059604645 / 2.0)), screenHeight / 2);
		Point point3 = new Point(Convert.ToInt32((float)((double)(float)screenWidth * 0.8324999939650297)), Convert.ToInt32((float)((double)(float)screenHeight * 0.9824999999254942)));
		Point point4 = new Point(Convert.ToInt32((float)((double)(float)screenWidth * 0.9824999999254942)), Convert.ToInt32((float)((double)(float)screenHeight * 0.9824999999254942)));
		point3.X += -30;
		point4.X += -30;
		int xOffset = DrawArgs.Instance.XOffset;
		point3.X -= xOffset;
		point4.X -= xOffset;
		point3.Y += 10;
		point4.Y += 10;
		Vertex[] array = new Vertex[2];
		float num2 = Main.Instance.MeasureTextHeight("Aj");
		array[0].position.X = point3.X;
		array[0].position.Y = (float)point3.Y - num2 * 1.1f;
		array[1].position.X = point4.X;
		array[1].position.Y = (float)point4.Y - num2 * 1.1f;
		Vertex[,] array2 = new Vertex[10, 2];
		float num3 = (float)(point4.X - point3.X) / (float)(array2.GetLength(0) - 1);
		for (int i = 0; i < array2.GetLength(0); i++)
		{
			array2[i, 0].position.X = (float)point3.X + num3 * (float)i;
			array2[i, 1].position.X = (float)point3.X + num3 * (float)i;
			array2[i, 0].position.Y = point3.Y - Convert.ToInt32((double)num2 * 1.1);
			array2[i, 1].position.Y = (float)(point3.Y - Convert.ToInt32((double)num2 * 1.1)) - num * (float)screenHeight;
		}
		drawArgs.WorldCamera.PickingRayIntersection(point.X, point.Y, out var latitude, out var longitude);
		if (Angle.IsNaN(latitude) || Angle.IsNaN(longitude))
		{
			return;
		}
		drawArgs.WorldCamera.PickingRayIntersection(point2.X, point2.Y, out var latitude2, out var longitude2);
		if (Angle.IsNaN(latitude2) || Angle.IsNaN(longitude2))
		{
			return;
		}
		double num4 = World.ApproxAngularDistance(latitude, longitude, latitude2, longitude2).Radians * 6378137.0;
		int num5 = 1;
		string text = "Meters";
		if (num4 > 5556.0)
		{
			num5 = 1852;
			text = "Nautical miles";
		}
		Main.Instance.DrawLine(Color.White, 1f, array[0].position.X, array[0].position.Y, array[1].position.X, array[1].position.Y);
		for (int j = 0; j < array2.GetLength(0); j++)
		{
			Main.Instance.DrawLine(Color.White, 1f, array2[j, 0].position.X, array2[j, 0].position.Y, array2[j, 1].position.X, array2[j, 1].position.Y);
		}
		float num6 = Main.Instance.MeasureTextWidth(text);
		if (float_0 == 0f)
		{
			float_0 = Main.Instance.MeasureTextHeight(text);
		}
		Main.Instance.DrawText(text, Convert.ToInt32(((float)(point3.X + point4.X) - num6) / 2f), Convert.ToInt32((float)point3.Y - float_0));
		float num7 = (float)(point4.X - point3.X) / (float)(string_0.Length - 1);
		string_0[0] = "0";
		double num8 = 0.0;
		for (int k = 0; k < string_0.Length; k++)
		{
			if (k > 0)
			{
				num8 = num4 / (double)num5 * ((double)k / (double)(string_0.Length - 1));
				if (num8 == 0.0)
				{
					string_0[k] = "n/a";
				}
				else
				{
					string_0[k] = smethod_0(num8, 2).ToString();
				}
			}
			float num9 = Main.Instance.MeasureTextWidth(string_0[k]);
			if (float_1 == 0f)
			{
				float_1 = Main.Instance.MeasureTextHeight(string_0[k]);
			}
			Main.Instance.DrawText(string_0[k], Convert.ToInt32((float)point3.X + num7 * (float)k - num9 / 2f), Convert.ToInt32((double)(array2[k, 1].position.Y - float_1) - (double)(array2[k, 0].position.Y - array2[k, 1].position.Y) * 0.1));
		}
	}

	[CompilerGenerated]
	internal static int smethod_0(double Precise, int Places)
	{
		if (Precise == 0.0)
		{
			throw new ArgumentException("Precise is ZERO!");
		}
		int num = Convert.ToInt32(Math.Log10(Precise) + 1.0);
		if (num <= Places)
		{
			return Convert.ToInt32(Precise);
		}
		int num2 = Convert.ToInt32(Math.Pow(10.0, num - Places));
		return Convert.ToInt32(Math.Round(Precise / (double)num2) * (double)num2);
	}

	static Scale()
	{
		Class72.smethod_20();
	}
}
