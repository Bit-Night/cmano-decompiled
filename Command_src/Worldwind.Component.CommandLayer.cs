using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Command_Core;
using CSMaterial;
using CSMaterial.ExWorldWind;
using DXRenderer;
using ExWorldWind;

namespace Worldwind.Component;

public class CommandLayer
{
	public enum IconOutlineLevel
	{
		NoOutline,
		Fast,
		HighQuality
	}

	public class SegmentVect
	{
		public Vector3 A;

		public Vector3 B;

		public int int_0;

		public SegmentVect(Vector3 _A, Vector3 _B, int _ARGBColor)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			A = _A;
			B = _B;
			int_0 = _ARGBColor;
		}

		static SegmentVect()
		{
			Class72.smethod_20();
		}
	}

	public delegate void RenderDelegate();

	private Dictionary<string, shape> dictionary_0 = new Dictionary<string, shape>();

	public const bool forceSubstitution = true;

	private StringBuilder stringBuilder_0 = new StringBuilder();

	private Dictionary<string, (string, string, string, int)> dictionary_1 = new Dictionary<string, (string, string, string, int)>();

	private float float_0;

	protected string name;

	public bool isInitialized;

	private bool bool_0;

	private double double_0;

	public RenderDelegate callback;

	private int Height;

	private int int_0;

	public static HashSet<string> AlaCarteDisabledSet;

	public void DrawArea(IEnumerable<Geopoint_Struct> path, int theLineThickness, Color theLineColor, Color theFillColor)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (IsAlaCarteDisabled("DrawArea1"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		int color = theFillColor.ToArgb();
		int num = path.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = path.ElementAt(i);
			Vector3 val2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian((float)geopoint_Struct.Latitude, (float)geopoint_Struct.Longitude, (float)double_0) - val);
			int int_0 = (int)Math.Round(val2.X);
			int int_1 = (int)Math.Round(val2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)int_1))
			{
				list.Add(new PointF(int_0, int_1));
			}
		}
		if (list.Count() < 3)
		{
			return;
		}
		List<List<PointF>> list2 = PolygonTriangulator.Triangulate(list);
		ScreenTransform();
		int count = list2.Count;
		if (count > 0)
		{
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[count * 3];
			int num2 = 0;
			foreach (PointF item in list2.SelectMany((List<PointF> F) => F))
			{
				array[num2] = new CustomVertex.PositionColored(item.X, item.Y, 0f, color);
				num2++;
			}
		}
		RestoreTransform();
		ResetRenderState();
		DrawGeoLine(theLineColor, theLineThickness, path.Concat(new Geopoint_Struct[1] { path.First() }));
	}

	public void DrawAreaAlpha(IEnumerable<Geopoint_Struct> path, int theLineThickness, Color theLineColor, Color theFillColor, int fillAlpha)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		if (IsAlaCarteDisabled("DrawAreaAlpha"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		int color = Color.FromArgb(fillAlpha, theFillColor).ToArgb();
		int num = path.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = path.ElementAt(i);
			Vector3 val2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian((float)geopoint_Struct.Latitude, (float)geopoint_Struct.Longitude, (float)double_0) - val);
			int int_0 = (int)Math.Round(val2.X);
			int int_1 = (int)Math.Round(val2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)int_1))
			{
				list.Add(new PointF(int_0, int_1));
			}
		}
		if (list.Count() < 3)
		{
			return;
		}
		List<List<PointF>> list2 = PolygonTriangulator.Triangulate(list);
		ScreenTransform();
		method_3(fillAlpha);
		int count = list2.Count;
		if (count > 0)
		{
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[count * 3];
			int num2 = 0;
			foreach (PointF item in list2.SelectMany((List<PointF> F) => F))
			{
				array[num2] = new CustomVertex.PositionColored(item.X, item.Y, 0f, color);
				num2++;
			}
		}
		RestoreTransform();
		ResetRenderState();
		DrawGeoLine(theLineColor, theLineThickness, path.Concat(new Geopoint_Struct[1] { path.First() }));
	}

	public static int GetEllipsePointCount(int width, int height, double tolerance = 0.75)
	{
		double num = (double)width / 2.0;
		double num2 = (double)height / 2.0;
		int val = (int)Math.Ceiling(Math.PI * Math.Sqrt((num * num + num2 * num2) / 2.0) / tolerance);
		return Math.Max(12, val);
	}

	public void DrawEllipse(float line_thickness, Color line_color, int x, int y, int height, int width)
	{
		if (!IsAlaCarteDisabled("DrawEllipse1"))
		{
			int ellipsePointCount = GetEllipsePointCount(width, height);
			Main.Segment_Points[] array = new Main.Segment_Points[ellipsePointCount];
			for (int i = 0; i < ellipsePointCount; i++)
			{
				float num = (float)(Math.PI * 2.0 * ((double)i / (double)ellipsePointCount));
				float num2 = (float)Math.Sin(num);
				float num3 = (float)Math.Cos(num);
				float num4 = (float)(Math.PI * 2.0 * ((double)(i - 1) / (double)ellipsePointCount));
				float num5 = (float)Math.Sin(num4);
				float num6 = (float)Math.Cos(num4);
				int x2 = (int)((float)x + num6 * (float)width / 2f);
				int y2 = (int)((float)y + num5 * (float)height / 2f);
				int x3 = (int)((float)x + num3 * (float)width / 2f);
				int y3 = (int)((float)y + num2 * (float)height / 2f);
				Main.Segment_Points segment_Points = new Main.Segment_Points(new Point(x2, y2), new Point(x3, y3));
				array[i] = segment_Points;
			}
			Main.Instance.DrawLines_FAST((int)line_thickness, line_color, array);
		}
	}

	public void FillEllipse(Color fill_color, Color line_color, int x, int y, int height, int width)
	{
		if (IsAlaCarteDisabled("FillEllipse1"))
		{
			return;
		}
		if (line_color.A != 0)
		{
			int color = fill_color.ToArgb();
			int color2 = line_color.ToArgb();
			int num = 45;
			CustomVertex.PositionColored[] array = new CustomVertex.PositionColored[135];
			CustomVertex.PositionColored[] array2 = new CustomVertex.PositionColored[90];
			for (int i = 0; i < num; i++)
			{
				float num2 = (float)(Math.PI * 2.0 * ((double)i / (double)num));
				float num3 = (float)Math.Sin(num2);
				float num4 = (float)Math.Cos(num2);
				float num5 = (float)(Math.PI * 2.0 * ((double)(i - 1) / (double)num));
				float num6 = (float)Math.Sin(num5);
				float num7 = (float)Math.Cos(num5);
				array2[i * 2] = new CustomVertex.PositionColored((float)x + num7 * (float)width / 2f, (float)y + num6 * (float)height / 2f, 0f, color2);
				array2[i * 2 + 1] = new CustomVertex.PositionColored((float)x + num4 * (float)width / 2f, (float)y + num3 * (float)height / 2f, 0f, color2);
				array[i * 3] = new CustomVertex.PositionColored((float)x + num7 * (float)width / 2f, (float)y + num6 * (float)height / 2f, 0f, color);
				array[i * 3 + 1] = new CustomVertex.PositionColored((float)x + num4 * (float)width / 2f, (float)y + num3 * (float)height / 2f, 0f, color);
				array[i * 3 + 2] = new CustomVertex.PositionColored(x, y, 0f, color);
			}
			ScreenTransform();
			method_2(array, fill_color);
			DrawPrimitiveLineList(array2);
			RestoreTransform();
			ResetRenderState();
		}
		else
		{
			int color3 = fill_color.ToArgb();
			int num8 = 45;
			CustomVertex.PositionColored[] array3 = new CustomVertex.PositionColored[135];
			for (int j = 0; j < num8; j++)
			{
				float num9 = (float)(Math.PI * 2.0 * ((double)j / (double)num8));
				float num10 = (float)Math.Sin(num9);
				float num11 = (float)Math.Cos(num9);
				float num12 = (float)(Math.PI * 2.0 * ((double)(j - 1) / (double)num8));
				float num13 = (float)Math.Sin(num12);
				float num14 = (float)Math.Cos(num12);
				array3[j * 3] = new CustomVertex.PositionColored((float)x + num14 * (float)width / 2f, (float)y + num13 * (float)height / 2f, 0f, color3);
				array3[j * 3 + 1] = new CustomVertex.PositionColored((float)x + num11 * (float)width / 2f, (float)y + num10 * (float)height / 2f, 0f, color3);
				array3[j * 3 + 2] = new CustomVertex.PositionColored(x, y, 0f, color3);
			}
			ScreenTransform();
			method_2(array3, fill_color);
			RestoreTransform();
			ResetRenderState();
		}
	}

	public void DrawRectangle(Color color, int x, int y, int height, int width)
	{
		DrawLine(color, x, y, x + width, y);
		DrawLine(color, x + width, y, x + width, y + height);
		DrawLine(color, x + width, y + height, x, y + height);
		DrawLine(color, x, y + height, x, y);
	}

	public void DrawThickRectangle(Color color, int line_thickness, int x, int y, int height, int width)
	{
		DrawLine(color, line_thickness, x, y, x + width, y);
		DrawLine(color, line_thickness, x + width, y, x + width, y + height);
		DrawLine(color, line_thickness, x + width, y + height, x, y + height);
		DrawLine(color, line_thickness, x, y + height, x, y);
	}

	public void SetVertexFormat()
	{
	}

	public void DrawTrianglePrimitives(CustomVertex.PositionColored[] v)
	{
	}

	public void FillRectangle(Color fill_color, Color line_color, int x, int y, int height, int width)
	{
		if (!IsAlaCarteDisabled("FillRectangle1"))
		{
			Main instance = Main.Instance;
			if (instance != null)
			{
				PointF[] points = new PointF[4]
				{
					new PointF
					{
						X = x,
						Y = y
					},
					new PointF
					{
						X = x + width,
						Y = y
					},
					new PointF
					{
						X = x + width,
						Y = y + height
					},
					new PointF
					{
						X = x,
						Y = y + height
					}
				};
				instance.FillGeometry(points, fill_color);
			}
		}
	}

	public void FillPolygon(List<Geopoint_Struct> path, Color theFillColor)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		if (IsAlaCarteDisabled("FillPolygon1"))
		{
			return;
		}
		DrawArgs instance = DrawArgs.Instance;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		theFillColor.ToArgb();
		int num = path.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Geopoint_Struct geopoint_Struct = path[i];
			Vector3 val2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian((float)geopoint_Struct.Latitude, (float)geopoint_Struct.Longitude, (float)double_0) - val);
			int int_0 = (int)Math.Round(val2.X);
			int jBsLwvealn9 = (int)Math.Round(val2.Y);
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)jBsLwvealn9))
			{
				list.Add(new PointF(int_0, jBsLwvealn9));
			}
		}
		if (list.Count() >= 3)
		{
			Main.Instance?.FillGeometry(list.ToArray(), theFillColor);
		}
	}

	public void FillPolygon(List<Point> path, Color theFillColor)
	{
		if (IsAlaCarteDisabled("FillPolygon2"))
		{
			return;
		}
		int num = path.Count();
		if (num < 3)
		{
			return;
		}
		List<PointF> list = new List<PointF>();
		for (int i = 0; i < num; i++)
		{
			Point point = path[i];
			int int_0 = point.X;
			int int_1 = point.Y;
			if (!list.Any((PointF F) => F.X == (float)int_0 && F.Y == (float)int_1))
			{
				list.Add(new PointF(int_0, int_1));
			}
		}
		if (list.Count() >= 3)
		{
			Main.Instance?.FillGeometry(list.ToArray(), theFillColor);
		}
	}

	public void FillPolygon(Color color, Point[] outer, Point[] inner, Point interior)
	{
		Main.Instance?.FillRing(outer, inner, color);
	}

	public Tuple<double, double> LoxodromicInterpolation(double lat1, double lon1, double lat2, double lon2, double f)
	{
		double num = Math.Cos(lon1);
		double num2 = Math.Cos(lon2);
		double x = (num + num2) / 2.0;
		double num3 = Math.Atan2(0.0, x);
		lon1 -= num3;
		lon2 -= num3;
		double num4 = lon2 * (1.0 - f) + lon1 * f;
		double item = lat2 * (1.0 - f) + lat1 * f;
		for (num4 += num3; num4 > Math.PI; num4 -= Math.PI * 2.0)
		{
		}
		for (; num4 < -Math.PI; num4 += Math.PI * 2.0)
		{
		}
		return new Tuple<double, double>(item, num4);
	}

	public void DrawLoxodromicLine(Color color, float line_thickness, double lat1, double lon1, double lat2, double lon2)
	{
		if (IsAlaCarteDisabled("DrawLoxodromicLine"))
		{
			return;
		}
		double num = Math2.CalcDist(lat1, lon1, lat2, lon2);
		lat1 *= CSMath.PI_dividedBy_180;
		lat2 *= CSMath.PI_dividedBy_180;
		lon1 *= CSMath.PI_dividedBy_180;
		lon2 *= CSMath.PI_dividedBy_180;
		int num2 = (int)(num / 100.0);
		if (num2 < 2)
		{
			DrawLine(color, line_thickness, method_4(lat1, lon1), method_4(lat2, lon2));
			return;
		}
		for (int i = 0; i < num2; i++)
		{
			double f = (double)i / (double)num2;
			double f2 = (double)(i + 1) / (double)num2;
			Tuple<double, double> tuple = LoxodromicInterpolation(lat1, lon1, lat2, lon2, f);
			Tuple<double, double> tuple2 = LoxodromicInterpolation(lat1, lon1, lat2, lon2, f2);
			DrawLine(color, line_thickness, method_4(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI), method_4(tuple2.Item1 * 180.0 / Math.PI, tuple2.Item2 * 180.0 / Math.PI));
		}
	}

	public Tuple<double, double> UTIL_OrthodromicInterpolationDegrees(double lat1, double lon1, double lat2, double lon2, double f)
	{
		Tuple<double, double> tuple = UTIL_OrthodromicInterpolation(lat1 * Math.PI / 180.0, lon1 * Math.PI / 180.0, lat2 * Math.PI / 180.0, lon2 * Math.PI / 180.0, f);
		return new Tuple<double, double>(tuple.Item1 / Math.PI * 180.0, tuple.Item2 / Math.PI * 180.0);
	}

	public static Tuple<double, double> UTIL_OrthodromicInterpolation(double lat1, double lon1, double lat2, double lon2, double f)
	{
		lon1 = 0.0 - lon1;
		lon2 = 0.0 - lon2;
		double num = 2.0 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((lat1 - lat2) / 2.0), 2.0) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin((lon1 - lon2) / 2.0), 2.0)));
		double num2 = Math.Sin((1.0 - f) * num) / Math.Sin(num);
		double num3 = Math.Sin(f * num) / Math.Sin(num);
		double x = num2 * Math.Cos(lat1) * Math.Cos(lon1) + num3 * Math.Cos(lat2) * Math.Cos(lon2);
		double num4 = num2 * Math.Cos(lat1) * Math.Sin(lon1) + num3 * Math.Cos(lat2) * Math.Sin(lon2);
		double item = Math.Atan2(num2 * Math.Sin(lat1) + num3 * Math.Sin(lat2), Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(num4, 2.0)));
		double num5 = Math.Atan2(num4, x);
		return new Tuple<double, double>(item, 0.0 - num5);
	}

	public void DrawOrthodromicLine(Color color, float line_thickness, double lat1, double lon1, double lat2, double lon2)
	{
		DrawOrthodromicLine(color, line_thickness, lat1, lon1, 0f, lat2, lon2, 0f);
	}

	public void DrawOrthodromicLine(Color color, float line_thickness, double lat1, double lon1, float alt1, double lat2, double lon2, float alt2)
	{
		if (IsAlaCarteDisabled("DrawOrthodromicLine"))
		{
			return;
		}
		double num = Math2.CalcDist(lat1, lon1, lat2, lon2);
		lat1 *= CSMath.PI_dividedBy_180;
		lat2 *= CSMath.PI_dividedBy_180;
		lon1 *= CSMath.PI_dividedBy_180;
		lon2 *= CSMath.PI_dividedBy_180;
		int num2 = (int)(num / 100.0);
		if (num2 < 2)
		{
			DrawLine(color, line_thickness, method_5(lat1 * 180.0 / Math.PI, lon1 * 180.0 / Math.PI, alt1), method_5(lat2 * 180.0 / Math.PI, lon2 * 180.0 / Math.PI, alt2));
			return;
		}
		float num3 = (alt2 - alt1) / (float)num2;
		for (int i = 0; i < num2; i++)
		{
			double f = (double)i / (double)num2;
			double f2 = (double)(i + 1) / (double)num2;
			Tuple<double, double> tuple = UTIL_OrthodromicInterpolation(lat1, lon1, lat2, lon2, f);
			Tuple<double, double> tuple2 = UTIL_OrthodromicInterpolation(lat1, lon1, lat2, lon2, f2);
			float float_ = alt1 + num3 * (float)i;
			float float_2 = alt1 + num3 * (float)(i + 1);
			DrawLine(color, line_thickness, method_5(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, float_), method_5(tuple2.Item1 * 180.0 / Math.PI, tuple2.Item2 * 180.0 / Math.PI, float_2));
		}
	}

	public void AddOrthodromicLinePoints_skipFirst(List<Geopoint_Struct> list, double lat1, double lon1, float alt1, double lat2, double lon2, float alt2)
	{
		if (IsAlaCarteDisabled("DrawOrthodromicLine"))
		{
			return;
		}
		double num = Math2.CalcDist(lat1, lon1, lat2, lon2);
		lat1 *= CSMath.PI_dividedBy_180;
		lat2 *= CSMath.PI_dividedBy_180;
		lon1 *= CSMath.PI_dividedBy_180;
		lon2 *= CSMath.PI_dividedBy_180;
		int num2 = (int)(num / 100.0);
		if (num2 < 2)
		{
			list.Add(new Geopoint_Struct(lon2, lat2));
			return;
		}
		float num3 = (alt2 - alt1) / (float)num2;
		for (int i = 0; i < num2; i++)
		{
			float float_ = alt1 + num3 * (float)(i + 1);
			double f = (double)(i + 1) / (double)num2;
			Tuple<double, double> tuple = UTIL_OrthodromicInterpolation(lat1, lon1, lat2, lon2, f);
			method_5(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, float_);
			list.Add(new Geopoint_Struct(tuple.Item2 * 180.0 / Math.PI, tuple.Item1 * 180.0 / Math.PI));
		}
	}

	public Rectangle MeasureString(Color color, int x, int y, string text, double asl = 0.0, int Height = 18)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new Exception("Measure String Failure!");
		}
		return Main.Instance.MeasureText(text, (float)Height * 0.75f, x, y);
	}

	public void DrawText(Color color, int x, int y, string text, double asl = 0.0, int Height = 18, FontWeight Weight = FontWeight.Normal, bool IsItalic = false, string FaceName = "Segoe UI", bool RightJustify = false, bool DrawOutline = false)
	{
		Main instance = Main.Instance;
		if (instance != null && !string.IsNullOrEmpty(text))
		{
			instance.DrawText(text, (float)Height * 0.75f, color, x, y, RightJustify, DrawOutline);
		}
	}

	public void DrawTransientBitmap(Bitmap Bitmap, int x, int y, int height, int width)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		if (!IsAlaCarteDisabled("DrawTransientBitmap"))
		{
			CustomVertex.PositionTextured[] array = new CustomVertex.PositionTextured[6];
			x += width / 2;
			y += height / 2;
			array[0] = new CustomVertex.PositionTextured(new Vector3((float)(x - width / 2), (float)(y - height / 2), 0f), 0f, 0f);
			array[1] = new CustomVertex.PositionTextured(new Vector3((float)(x + width / 2), (float)(y + height / 2), 0f), 1f, 1f);
			array[2] = new CustomVertex.PositionTextured(new Vector3((float)(x - width / 2), (float)(y + height / 2), 0f), 0f, 1f);
			array[3] = new CustomVertex.PositionTextured(new Vector3((float)(x + width / 2), (float)(y - height / 2), 0f), 1f, 0f);
			array[4] = new CustomVertex.PositionTextured(new Vector3((float)(x + width / 2), (float)(y + height / 2), 0f), 1f, 1f);
			array[5] = new CustomVertex.PositionTextured(new Vector3((float)(x - width / 2), (float)(y - height / 2), 0f), 0f, 0f);
			ScreenTransform();
			RestoreTransform();
			ResetRenderState();
			Main.Instance?.DrawBitmap(Bitmap);
		}
	}

	public void DrawIcon(string asset, int alpha, int x, int y, int height, int width, bool DrawOutline, int DiamondZoom, int FlowerZoom, int RectangleZoom, int IconZoom, int iconColor = -1, bool isCustomIcon = false)
	{
		if (IsAlaCarteDisabled("DrawIcon1"))
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		string extension = Path.GetExtension(asset);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(asset);
		bool flag = false;
		string directoryName = Path.GetDirectoryName(asset);
		string text;
		string text2;
		string text3;
		if (dictionary_1.TryGetValue(asset, out var value))
		{
			(text, text2, text3, _) = value;
		}
		else
		{
			stringBuilder_0.Clear();
			stringBuilder_0.Append(fileNameWithoutExtension).Append("_diamond_").Append(extension);
			text = Path.Combine(directoryName, stringBuilder_0.ToString());
			stringBuilder_0.Clear();
			stringBuilder_0.Append(fileNameWithoutExtension).Append("_rectangle_").Append(extension);
			text2 = Path.Combine(directoryName, stringBuilder_0.ToString());
			stringBuilder_0.Clear();
			stringBuilder_0.Append(fileNameWithoutExtension).Append("_flower_").Append(extension);
			text3 = Path.Combine(directoryName, stringBuilder_0.ToString());
			dictionary_1.Add(asset, (text, text2, text3, IconZoom));
			stringBuilder_0.Clear();
		}
		if (!dictionary_0.ContainsKey(asset))
		{
			if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(text))
			{
				if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(text3))
				{
					if (FileExistsNative.FileExistsFast_CheckOnlyOnce(text2))
					{
						dictionary_0.Add(asset, shape.Rectangle);
					}
				}
				else
				{
					dictionary_0.Add(asset, shape.Flower);
				}
			}
			else
			{
				dictionary_0.Add(asset, shape.Diamond);
			}
		}
		if (dictionary_0.TryGetValue(asset, out var value2))
		{
			flag = true;
			switch (value2)
			{
			case shape.Diamond:
				asset = text;
				num2 = height - DiamondZoom;
				num = width - DiamondZoom;
				height = DiamondZoom;
				width = DiamondZoom;
				break;
			case shape.Flower:
				asset = text3;
				num2 = height - FlowerZoom;
				num = width - FlowerZoom;
				height = FlowerZoom;
				width = FlowerZoom;
				break;
			case shape.Rectangle:
				asset = text2;
				num2 = height - RectangleZoom;
				num = width - RectangleZoom;
				height = RectangleZoom;
				width = RectangleZoom;
				break;
			}
		}
		if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(asset))
		{
			if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(text))
			{
				if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(text3))
				{
					if (FileExistsNative.FileExistsFast_CheckOnlyOnce(text2))
					{
						asset = text2;
						num2 = height - RectangleZoom;
						num = width - RectangleZoom;
						height = RectangleZoom;
						width = RectangleZoom;
						if (!dictionary_0.ContainsKey(asset))
						{
							dictionary_0.Add(asset, shape.Rectangle);
						}
					}
				}
				else
				{
					asset = text3;
					num2 = height - FlowerZoom;
					num = width - FlowerZoom;
					height = FlowerZoom;
					width = FlowerZoom;
					if (!dictionary_0.ContainsKey(asset))
					{
						dictionary_0.Add(asset, shape.Flower);
					}
				}
			}
			else
			{
				asset = text;
				num2 = height - DiamondZoom;
				num = width - DiamondZoom;
				height = DiamondZoom;
				width = DiamondZoom;
				if (!dictionary_0.ContainsKey(asset))
				{
					dictionary_0.Add(asset, shape.Diamond);
				}
			}
		}
		if (!flag && isCustomIcon)
		{
			num2 = height - RectangleZoom;
			num = width - RectangleZoom;
			height = RectangleZoom;
			width = RectangleZoom;
		}
		int x2 = x + width / 2 + num / 2;
		int num3 = y + height / 2 + num2 / 2;
		height = (int)((double)height * ((double)IconZoom / 20.0));
		width = (int)((double)width * ((double)IconZoom / 20.0));
		Main instance = Main.Instance;
		instance?.DrawIcon(asset, alpha, x2, instance.ScreenHeight - num3, width, height, DrawOutline, iconColor);
	}

	public void DrawIconRotated(string asset, int alpha, int x, int y, int height, int width, double heading, bool DrawOutline, int DiamondZoom, int FlowerZoom, int RectangleZoom, int IconZoom, int iconColor = -1)
	{
		if (IsAlaCarteDisabled("DrawIconRotated"))
		{
			return;
		}
		if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(asset))
		{
			string extension = Path.GetExtension(asset);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(asset);
			if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_diamond_" + extension)))
			{
				if (!FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_flower_" + extension)))
				{
					if (FileExistsNative.FileExistsFast_CheckOnlyOnce(Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_rectangle_" + extension)))
					{
						asset = Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_rectangle_" + extension);
						height = RectangleZoom;
						width = RectangleZoom + 50;
					}
				}
				else
				{
					asset = Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_flower_" + extension);
					height = FlowerZoom;
					width = FlowerZoom;
				}
			}
			else
			{
				asset = Path.Combine(Path.GetDirectoryName(asset), fileNameWithoutExtension + "_diamond_" + extension);
				height = DiamondZoom;
				width = DiamondZoom;
			}
		}
		int x2 = x + width / 2;
		int num = y + height / 2;
		height = (int)((double)height * ((double)IconZoom / 10.0));
		width = (int)((double)width * ((double)IconZoom / 10.0));
		Main instance = Main.Instance;
		instance?.DrawIcon(asset, alpha, x2, instance.ScreenHeight - num, width, height, DrawOutline, iconColor, (float)heading);
	}

	public void DrawLines_FAST_Legacy(int line_thickness, SegmentVect[] segmentVects)
	{
		ScreenTransform();
		foreach (SegmentVect segmentVect in segmentVects)
		{
			Color color = Color.FromArgb(segmentVect.int_0);
			DrawLine(color, line_thickness, segmentVect.A.X, segmentVect.A.Y, segmentVect.B.X, segmentVect.B.Y);
		}
		RestoreTransform();
	}

	public void DrawGeoLine(Color color, IEnumerable<Geopoint_Struct> path, bool closed = false, float additionalAltitude = 0f)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<Geopoint_Struct> obj = ((!closed) ? path : path.Concat(new Geopoint_Struct[1] { path.First() }));
		Geopoint_Struct[] array = new Geopoint_Struct[obj.Count()];
		int num = 0;
		foreach (Geopoint_Struct item in obj)
		{
			array[num] = item;
			num++;
		}
		Vertex[] array2 = new Vertex[array.Length];
		uint[] array3 = new uint[array.Length];
		Main instance = Main.Instance;
		if (instance != null)
		{
			Vector3 p = default(Vector3);
			for (num = 0; num < array.Length; num++)
			{
				Geopoint_Struct geopoint_Struct = array[num];
				Vector3 val = MathEngine.SphericalToCartesian((float)geopoint_Struct.Latitude, (float)(geopoint_Struct.Longitude + 180.0), geopoint_Struct.Altitude + 6378137f + additionalAltitude);
				((Vector3)(ref p))..ctor(0f - val.Y, val.Z, val.X);
				Vector4 c = Main.IntToVector4(color.ToArgb());
				Vertex vertex = new Vertex(p, c);
				array2[num] = vertex;
				array3[num] = (uint)num;
			}
			instance.DrawLineStrip(array2, array3);
		}
	}

	public void DrawGeoLine(Color color, int line_thickness, IEnumerable<Geopoint_Struct> path, bool closed = false)
	{
		try
		{
			if (path != null)
			{
				DrawLine(color, line_thickness, path.Select(method_6).ToArray(), closed);
			}
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void DrawGeoLine(Color color, double lat1, double lon1, double lat2, double lon2, double asl1 = 0.0, double asl2 = 0.0)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		DrawPrimitiveLineStrip(new CustomVertex.PositionColored[2]
		{
			new CustomVertex.PositionColored(MathEngine.SphericalToCartesian((float)lat1, (float)lon1, (float)(double_0 + asl1)), color.ToArgb()),
			new CustomVertex.PositionColored(MathEngine.SphericalToCartesian((float)lat2, (float)lon2, (float)(double_0 + asl2)), color.ToArgb())
		});
	}

	public void DrawLine(Color color, int line_thickness, Point[] path, bool closed = false)
	{
		if (!IsAlaCarteDisabled("DrawLine1") && path.Length >= 2)
		{
			int num;
			if (closed)
			{
				Point[] point_ = new Point[1] { path[0] };
				path = method_0(ref path, ref point_);
				num = 0;
			}
			else
			{
				num = 0;
			}
			for (int i = num; i < path.Length - 1; i++)
			{
				DrawLine(color, line_thickness, path[i], path[i + 1]);
			}
		}
	}

	private Point[] method_0(ref Point[] point_0, ref Point[] point_1)
	{
		Point[] array = new Point[point_0.Length + point_1.Length - 1 + 1];
		point_0.CopyTo(array, 0);
		point_1.CopyTo(array, point_0.Length);
		return array;
	}

	public void DrawLine(Color color, Point p1, Point p2)
	{
		if (!IsAlaCarteDisabled("DrawLine2"))
		{
			DrawLine(color, p1.X, p1.Y, p2.X, p2.Y);
		}
	}

	public void DrawLine(Color color, int x1, int y1, int x2, int y2)
	{
		if (!IsAlaCarteDisabled("DrawLine3"))
		{
			CustomVertex.PositionColored[] a = new CustomVertex.PositionColored[2]
			{
				method_11(new Point(x1, y1), color),
				method_11(new Point(x2, y2), color)
			};
			ScreenTransform();
			DrawPrimitiveLineStrip(a);
			RestoreTransform();
		}
	}

	public void DrawDashedLine(Color color, float line_thickness, bool dashed, Point dp1, Point dp2, float factor = 5f)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		if (IsAlaCarteDisabled("DrawDashedLine1"))
		{
			return;
		}
		if (!dashed)
		{
			DrawLine(color, line_thickness, dp1, dp2);
			return;
		}
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor((float)dp1.X, (float)dp1.Y, 0f);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))..ctor((float)dp2.X, (float)dp2.Y, 0f);
		Vector3 val3 = val2 - val;
		int num = (int)Math.Max(((Vector3)(ref val3)).Length() / factor, 2.0);
		for (int i = 0; i < num; i += 2)
		{
			Vector3 val4 = val + (val2 - val) * ((float)i / (float)num);
			Vector3 val5 = val + (val2 - val) * ((float)(i + 1) / (float)num);
			DrawLine(color, line_thickness, val4.X, val4.Y, val5.X, val5.Y);
		}
	}

	public void DrawDashedLine_FAST(Color color, float line_thickness, bool dashed, Point dp1, Point dp2)
	{
		if (!IsAlaCarteDisabled("DrawDashedLine3"))
		{
			if (dashed)
			{
				Main.Instance?.DrawLine(color, line_thickness, dp1.X, dp1.Y, dp2.X, dp2.Y, dashed: true);
			}
			else
			{
				DrawLine(color, line_thickness, dp1, dp2);
			}
		}
	}

	public void DrawLines_FAST(Main.BatchDrawKey Config, List<Main.Segment_Points> segmentVects, bool dashed = false)
	{
		Main.Instance?.DrawLines_FAST(Config.thickness, Config.color, segmentVects, dashed);
	}

	public void DrawCrenelatedLine(Color color, float thickness, float startX, float startY, float endX, float endY, float step = 12f, float crenelSize = 6f)
	{
		Main.Instance?.DrawCrenelatedLine(color, thickness, startX, startY, endX, endY, step, crenelSize);
	}

	public void DrawDashedLine(Color color, float line_thickness, bool dashed, IEnumerable<Point> path, float factor = 5f)
	{
		if (!IsAlaCarteDisabled("DrawDashedLine2"))
		{
			for (int i = 0; i < path.Count() - 1; i++)
			{
				DrawDashedLine(color, line_thickness, dashed, path.ElementAt(i), path.ElementAt(i + 1), factor);
			}
		}
	}

	public void DrawLine(Color color, float line_thickness, Point p1, Point p2)
	{
		if (!IsAlaCarteDisabled("DrawLine4"))
		{
			DrawLine(color, line_thickness, p1.X, p1.Y, p2.X, p2.Y);
		}
	}

	private void Report(string Checkpoint, Stopwatch Sw)
	{
		Sw.Restart();
	}

	public void DrawLine(Color color, float line_thickness, float x1, float y1, float x2, float y2)
	{
		if (!IsAlaCarteDisabled("DrawLine5"))
		{
			Main.Instance?.DrawLine(color, line_thickness, x1, y1, x2, y2);
		}
	}

	private static double smethod_0(double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		if (double_3 - double_2 == 0.0)
		{
			return (double_4 + double_5) / 2.0;
		}
		return double_4 + (double_1 - double_2) * (double_5 - double_4) / (double_3 - double_2);
	}

	public void DrawDashedClosedPointLine(Pen pen, Point[] theList)
	{
		if (IsAlaCarteDisabled("DrawDashedClosedPointLine"))
		{
			return;
		}
		try
		{
			Color color = pen.Color;
			int num = theList.Length;
			Point[] array = new Point[num + 1];
			for (int i = 0; i < num; i++)
			{
				array[i] = theList[i];
			}
			array[num] = array[0];
			ScreenTransform();
			int num2 = 0;
			bool flag = true;
			List<CustomVertex.PositionColored> list = new List<CustomVertex.PositionColored>(theList.Length * 10);
			list.Add(method_11(array[0], color));
			double num3 = array[0].X;
			double num4 = array[0].Y;
			double num5 = 4.0;
			while (true)
			{
				Point point = array[num2 + 1];
				double num6 = Math.Sqrt((num3 - (double)point.X) * (num3 - (double)point.X) + (num4 - (double)point.Y) * (num4 - (double)point.Y));
				while (num2 != theList.Length - 1 && !(num5 < num6))
				{
					num5 -= num6;
					num2++;
					num3 = array[num2].X;
					num4 = array[num2].Y;
					point = array[num2 + 1];
					num6 = Math.Sqrt((num3 - (double)point.X) * (num3 - (double)point.X) + (num4 - (double)point.Y) * (num4 - (double)point.Y));
					if (flag)
					{
						list.Add(method_11(array[num2], color));
						list.Add(method_11(array[num2], color));
					}
				}
				double num7 = num5 / num6;
				if (num7 > 1.0 || num7 < 0.0)
				{
					break;
				}
				num3 = smethod_0(num7, 0.0, 1.0, num3, point.X);
				num4 = smethod_0(num7, 0.0, 1.0, num4, point.Y);
				list.Add(new CustomVertex.PositionColored((int)Math.Round(num3), (int)Math.Round(num4), 0f, color.ToArgb()));
				flag = !flag;
				num5 = 4.0;
			}
			if (list.Count % 2 == 1)
			{
				list.RemoveAt(list.Count - 1);
			}
			DrawPrimitiveLineList(list.ToArray());
			RestoreTransform();
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void DrawClosedPointLine(Pen pen, Point[] theList, bool withArrow = false, bool withArch = false, float archHeight = 0f, int archSegments = 0, float dotSpeed = 0f, float dotSize = 0f)
	{
		if (IsAlaCarteDisabled("DrawClosedPointLine"))
		{
			return;
		}
		try
		{
			Color color = pen.Color;
			int num = theList.Length;
			Point[] array = new Point[num + 1];
			for (int i = 0; i < num; i++)
			{
				array[i] = theList[i];
			}
			array[num] = array[0];
			ScreenTransform();
			CustomVertex.PositionColored[] array2 = new CustomVertex.PositionColored[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = method_11(array[j], color);
			}
			DrawPrimitiveLineStrip(array2, null, withArrow, withArch);
			RestoreTransform();
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void DrawGraphicsPathLine(Pen pen, GraphicsPath gp, bool withArrow = false, bool withArch = false, float archHeight = 0f, int archSegments = 0, float dotSpeed = 0f, float dotSize = 0f)
	{
		if (IsAlaCarteDisabled("DrawGraphicsPathLine"))
		{
			return;
		}
		gp.Flatten();
		Color color_0 = pen.Color;
		CustomVertex.PositionColored[] array = gp.PathPoints.Select((PointF F) => method_9(F, color_0)).ToArray();
		byte[] pathTypes = gp.PathTypes;
		int num = array.Count();
		int num2 = 0;
		List<CustomVertex.PositionColored> list = new List<CustomVertex.PositionColored>(num);
		ScreenTransform();
		for (int num3 = 0; num3 < num; num3++)
		{
			if (pathTypes[num3] != 0)
			{
				if (pathTypes[num3] == 1)
				{
					list.Add(array[num3]);
				}
				else if (pathTypes[num3] == 129)
				{
					list.Add(array[num3]);
					list.Add(array[num2]);
					CustomVertex.PositionColored[] a = list.ToArray();
					DrawPrimitiveLineStrip(a, pen);
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				list.Clear();
				list.Add(array[num3]);
				num2 = num3;
			}
		}
		if (list.Count() != 0)
		{
			CustomVertex.PositionColored[] a2 = list.ToArray();
			DrawPrimitiveLineStrip(a2, pen, withArrow, withArch, archHeight, archSegments, dotSpeed, dotSize);
		}
		RestoreTransform();
	}

	private void DrawPrimitiveLineStrip(CustomVertex.PositionColored[] a, Pen pen = null, bool withArrow = false, bool drawArch = false, float archHeight = 0f, int archSegments = 0, float dotSpeed = 0f, float dotSize = 0f)
	{
		if (IsAlaCarteDisabled("DrawPrimitiveLineStrip"))
		{
			return;
		}
		int num = a.Length;
		if (num <= 1)
		{
			return;
		}
		float_0 += 0.01f;
		for (int i = 0; i < num - 1; i++)
		{
			Color color = ((pen == null) ? Color.FromArgb(a[i].Color) : pen.Color);
			float num2 = ((pen == null) ? 1.5f : pen.Width);
			Main instance = Main.Instance;
			if (instance == null)
			{
				continue;
			}
			CustomVertex.PositionColored positionColored = a[i];
			CustomVertex.PositionColored positionColored2 = a[i + 1];
			if (drawArch)
			{
				for (int j = 0; j < archSegments; j++)
				{
					float num3 = (float)j / (float)archSegments;
					float num4 = (float)(j + 1) / (float)archSegments;
					float startX = positionColored.X + (positionColored2.X - positionColored.X) * num3;
					float startY = positionColored.Y + (positionColored2.Y - positionColored.Y) * num3 - archHeight * 4f * num3 * (1f - num3);
					float endX = positionColored.X + (positionColored2.X - positionColored.X) * num4;
					float endY = positionColored.Y + (positionColored2.Y - positionColored.Y) * num4 - archHeight * 4f * num4 * (1f - num4);
					instance.DrawLine(color, num2, startX, startY, endX, endY);
				}
				if (withArrow)
				{
					float num5 = 1f - 1f / (float)archSegments;
					float float_ = positionColored.X + (positionColored2.X - positionColored.X) * num5;
					float float_2 = positionColored.Y + (positionColored2.Y - positionColored.Y) * num5 - archHeight * 4f * num5 * (1f - num5);
					float x = positionColored2.X;
					float y = positionColored2.Y;
					method_1(instance, color, num2, float_, float_2, x, y);
				}
				if (dotSize > 0f && dotSpeed > 0f)
				{
					float num6 = float_0 * dotSpeed % 1f;
					float num7 = positionColored.X + (positionColored2.X - positionColored.X) * num6;
					float num8 = positionColored.Y + (positionColored2.Y - positionColored.Y) * num6 - archHeight * 4f * num6 * (1f - num6);
					for (int k = 0; k < 5; k++)
					{
						float num9 = (num6 - (float)k * 0.05f + 1f) % 1f;
						float num10 = positionColored.X + (positionColored2.X - positionColored.X) * num9;
						float num11 = positionColored.Y + (positionColored2.Y - positionColored.Y) * num9 - archHeight * 4f * num9 * (1f - num9);
						Color color2 = Color.FromArgb((int)((1f - (float)k / 5f) * 255f), color);
						instance.DrawLine(color2, num2, num10, num11, num10 + 1f, num11 + 1f);
					}
					instance.DrawLine(color, num2 + 2f, num7 - dotSize, num8, num7 + dotSize, num8);
					instance.DrawLine(color, num2 + 2f, num7, num8 - dotSize, num7, num8 + dotSize);
				}
			}
			else
			{
				instance.DrawLine(color, num2, positionColored.X, positionColored.Y, positionColored2.X, positionColored2.Y);
				if (withArrow)
				{
					method_1(instance, color, num2, positionColored.X, positionColored.Y, positionColored2.X, positionColored2.Y);
				}
			}
		}
	}

	private void method_1(Main main_0, Color color_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		float num = float_4 - float_2;
		float num2 = (float)Math.Atan2(float_5 - float_3, num);
		float num3 = num2 + (float)Math.PI - (float)Math.PI / 9f;
		float num4 = num2 + (float)Math.PI + (float)Math.PI / 9f;
		float endX = float_4 + 10f * (float)Math.Cos(num3);
		float endY = float_5 + 10f * (float)Math.Sin(num3);
		float endX2 = float_4 + 10f * (float)Math.Cos(num4);
		float endY2 = float_5 + 10f * (float)Math.Sin(num4);
		main_0.DrawLine(color_0, float_1, float_4, float_5, endX, endY);
		main_0.DrawLine(color_0, float_1, float_4, float_5, endX2, endY2);
	}

	private void DrawPrimitiveLineList(CustomVertex.PositionColored[] a)
	{
		if (IsAlaCarteDisabled("DrawPrimitiveLineList"))
		{
			return;
		}
		int num = a.Length;
		if (num <= 1)
		{
			return;
		}
		if (num % 2 != 0)
		{
			if (!Debugger.IsAttached)
			{
				return;
			}
			Debugger.Break();
		}
		Main instance = Main.Instance;
		if (instance != null)
		{
			Point[] array = new Point[a.Length];
			for (int i = 0; i < num; i++)
			{
				CustomVertex.PositionColored positionColored = a[i];
				array[i] = new Point((int)positionColored.X, (int)positionColored.Y);
			}
			Color color = Color.FromArgb(a[0].Color);
			instance.DrawDashedLine(color, array);
		}
	}

	private void method_2(CustomVertex.PositionColored[] positionColored_0, Color color_0)
	{
		Main instance = Main.Instance;
		if (instance != null)
		{
			PointF[] array = new PointF[positionColored_0.Length];
			for (int i = 0; i < positionColored_0.Length; i++)
			{
				CustomVertex.PositionColored positionColored = positionColored_0[i];
				array[i] = new PointF((int)positionColored.X, (int)positionColored.Y);
			}
			instance.FillGeometry(array, color_0);
		}
	}

	public void DrawGradientLine(Color color, int line_thickness, bool dashed, float x1, float y1, float x2, float y2)
	{
		if (!IsAlaCarteDisabled("DrawGradientLine"))
		{
			Main.Instance?.DrawGradientLine(color, line_thickness, dashed, x1, y1, x2, y2);
		}
	}

	public static bool IsAlaCarteDisabled(string name)
	{
		if (!AlaCarteDisabledSet.Contains(name))
		{
			return false;
		}
		return true;
	}

	public static void SetAlaCarteDisabled(string name, bool value)
	{
		if (!value)
		{
			if (!AlaCarteDisabledSet.Contains(name))
			{
				AlaCarteDisabledSet.Add(name);
			}
		}
		else if (AlaCarteDisabledSet.Contains(name))
		{
			AlaCarteDisabledSet.Remove(name);
		}
	}

	public CommandLayer(string name, RenderDelegate callback)
	{
		this.name = name;
		this.callback = callback;
	}

	public void Render(DrawArgs drawArgs)
	{
		DrawArgs instance = DrawArgs.Instance;
		if (!isInitialized)
		{
			Initialize(drawArgs);
		}
		Height = (int)instance.WorldCamera.ViewportHeight;
		int_0 = (int)instance.WorldCamera.ViewportWidth;
		ResetRenderState();
		method_3(255);
		RestoreTransform();
		callback();
		ResetRenderState();
		method_3(255);
		instance = null;
	}

	public void ResetRenderState()
	{
		method_3(255);
	}

	public bool Update(DrawArgs drawArgs)
	{
		return true;
	}

	public void Dispose()
	{
	}

	private void method_3(int int_1)
	{
	}

	public void Initialize(DrawArgs drawArgs)
	{
		if (!isInitialized)
		{
			double_0 = 6378137.0;
			isInitialized = true;
		}
	}

	public bool PerformSelectionAction(DrawArgs drawArgs)
	{
		return false;
	}

	private Point method_4(double double_1, double double_2)
	{
		return method_5(double_1, double_2, 0f);
	}

	private Point method_5(double double_1, double double_2, float float_1)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		DrawArgs instance = DrawArgs.Instance;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		Vector3 val2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian((float)double_1, (float)double_2, (float)double_0 + float_1) - val);
		return new Point((int)val2.X, (int)val2.Y);
	}

	private Point method_6(Geopoint_Struct geopoint_Struct_0)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		DrawArgs instance = DrawArgs.Instance;
		Vector3 val = default(Vector3);
		((Vector3)(ref val))..ctor(instance.WorldCamera.ReferenceCenter.X, instance.WorldCamera.ReferenceCenter.Y, instance.WorldCamera.ReferenceCenter.Z);
		Vector3 val2 = instance.WorldCamera.Project(MathEngine.SphericalToCartesian((float)geopoint_Struct_0.Latitude, (float)geopoint_Struct_0.Longitude, (float)double_0 + geopoint_Struct_0.Altitude) - val);
		return new Point((int)val2.X, (int)val2.Y);
	}

	private CustomVertex.PositionColored method_7(GeoPoint geoPoint_0, Color color_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		return new CustomVertex.PositionColored(MathEngine.SphericalToCartesian((float)geoPoint_0.Latitude, (float)geoPoint_0.Longitude, (float)double_0 + geoPoint_0.Altitude), color_0.ToArgb());
	}

	private CustomVertex.PositionColored method_8(Geopoint_Struct geopoint_Struct_0, Color color_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		return new CustomVertex.PositionColored(MathEngine.SphericalToCartesian((float)geopoint_Struct_0.Latitude, (float)geopoint_Struct_0.Longitude, (float)double_0 + geopoint_Struct_0.Altitude), color_0.ToArgb());
	}

	private CustomVertex.PositionColored method_9(PointF pointF_0, Color color_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return new CustomVertex.PositionColored(new Vector3(pointF_0.X, pointF_0.Y, 0f), color_0.ToArgb());
	}

	private Vector3 method_10(Point point_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3((float)point_0.X, (float)point_0.Y, 0f);
	}

	private CustomVertex.PositionColored method_11(Point point_0, Color color_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		return new CustomVertex.PositionColored(new Vector3((float)point_0.X, (float)point_0.Y, 0f), color_0.ToArgb());
	}

	public void ScreenTransform()
	{
	}

	public void RestoreTransform()
	{
	}

	static CommandLayer()
	{
		Class72.smethod_20();
		AlaCarteDisabledSet = new HashSet<string>();
	}
}
