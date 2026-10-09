using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace VectorTileRenderer;

public class TileRenderer
{
	private struct Struct37
	{
		public string Text;

		public PointF pointF_0;

		public LabelStyle labelStyle_0;

		public float float_0;
	}

	[CompilerGenerated]
	private int int_0 = 256;

	[CompilerGenerated]
	private IMapStyle imapStyle_0 = new BrightStyle();

	[CompilerGenerated]
	private int int_1 = 2;

	public int TileSize
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public IMapStyle Style
	{
		[CompilerGenerated]
		get
		{
			return imapStyle_0;
		}
		[CompilerGenerated]
		set
		{
			imapStyle_0 = value;
		}
	}

	public int SupersampleFactor
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public Bitmap Render(DecodedTile tile, int zoom)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected O, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		int num = Math.Max(1, SupersampleFactor);
		int num2 = TileSize * num;
		Bitmap val = new Bitmap(num2, num2);
		Graphics val2 = Graphics.FromImage((Image)(object)val);
		try
		{
			val2.SmoothingMode = (SmoothingMode)4;
			val2.TextRenderingHint = (TextRenderingHint)4;
			val2.PixelOffsetMode = (PixelOffsetMode)2;
			val2.CompositingMode = (CompositingMode)0;
			val2.CompositingQuality = (CompositingQuality)2;
			val2.InterpolationMode = (InterpolationMode)7;
			val2.Clear(Style.BackgroundColor);
			List<Struct37> list = new List<Struct37>();
			foreach (KeyValuePair<string, LayerStyle> orderedLayer in Style.GetOrderedLayers(zoom))
			{
				string key = orderedLayer.Key;
				LayerStyle value = orderedLayer.Value;
				bool flag;
				string text = ((!(flag = key.EndsWith("#fill"))) ? key : key.Substring(0, key.Length - 5));
				TileLayer layer = tile.GetLayer(text);
				if (layer == null)
				{
					continue;
				}
				float float_ = (float)num2 / (float)layer.Extent;
				foreach (TileFeature feature in layer.Features)
				{
					if (feature.Geometry == null)
					{
						continue;
					}
					if (value.Polygon != null && feature.Type == GeometryType.Polygon)
					{
						Color color_ = method_7(text, feature, value.Polygon.FillColor);
						method_0(val2, feature.Geometry, float_, color_, value.Polygon.DrawOutline, value.Polygon.OutlineColor, value.Polygon.OutlineWidth * (float)num);
					}
					if (value.Line != null && (feature.Type == GeometryType.LineString || feature.Type == GeometryType.Polygon))
					{
						Color color_2;
						float float_2;
						if (!(text == "transportation"))
						{
							color_2 = value.Line.Color;
							float_2 = value.Line.Width * (float)num;
						}
						else
						{
							color_2 = Style.GetRoadColor(feature, !flag);
							float_2 = Style.GetRoadWidth(feature, !flag, zoom) * (float)num;
						}
						method_1(val2, feature.Geometry, float_, color_2, float_2, value.Line.Dashed);
					}
					if (value.Label == null || !value.Label.Draw || zoom < value.Label.MinZoom)
					{
						continue;
					}
					string text2 = feature.GetString(value.Label.TagKey);
					if (!string.IsNullOrEmpty(text2) && text2.Length > value.Label.MinTextLength)
					{
						PointF? pointF = method_4(feature, float_);
						if (pointF.HasValue)
						{
							list.Add(new Struct37
							{
								Text = text2,
								pointF_0 = pointF.Value,
								labelStyle_0 = value.Label,
								float_0 = method_8(text, feature)
							});
						}
					}
				}
			}
			list.Sort((Struct37 a, Struct37 b) => a.float_0.CompareTo(b.float_0));
			List<RectangleF> list_ = new List<RectangleF>();
			foreach (Struct37 item in list)
			{
				method_2(val2, item.Text, item.pointF_0, item.labelStyle_0, list_, num2, num);
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (num == 1)
		{
			return val;
		}
		Bitmap val3 = new Bitmap(TileSize, TileSize);
		ImageAttributes val4 = new ImageAttributes();
		try
		{
			Graphics val5 = Graphics.FromImage((Image)(object)val3);
			try
			{
				val4.SetWrapMode((WrapMode)3);
				val5.InterpolationMode = (InterpolationMode)7;
				val5.SmoothingMode = (SmoothingMode)4;
				val5.PixelOffsetMode = (PixelOffsetMode)2;
				val5.CompositingQuality = (CompositingQuality)2;
				val5.DrawImage((Image)(object)val, new Rectangle(0, 0, TileSize, TileSize), 0, 0, num2, num2, (GraphicsUnit)2, val4);
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		((Image)val).Dispose();
		return val3;
	}

	private void method_0(Graphics graphics_0, TileGeometry tileGeometry_0, float float_0, Color color_0, bool bool_0, Color color_1, float float_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		GraphicsPath val = new GraphicsPath((FillMode)0);
		try
		{
			foreach (List<TilePoint> part in tileGeometry_0.Parts)
			{
				if (part.Count >= 3)
				{
					PointF[] array = method_3(part, float_0);
					val.AddPolygon(array);
				}
			}
			if (val.PointCount == 0)
			{
				return;
			}
			SolidBrush val2 = new SolidBrush(color_0);
			try
			{
				graphics_0.FillPath((Brush)(object)val2, val);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			if (bool_0 && float_1 > 0f)
			{
				Pen val3 = new Pen(color_1, float_1);
				try
				{
					graphics_0.DrawPath(val3, val);
					return;
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void method_1(Graphics graphics_0, TileGeometry tileGeometry_0, float float_0, Color color_0, float float_1, bool bool_0)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		Pen val = new Pen(color_0, Math.Max(0.5f, float_1));
		try
		{
			val.StartCap = (LineCap)2;
			val.EndCap = (LineCap)2;
			val.LineJoin = (LineJoin)2;
			if (bool_0)
			{
				val.DashPattern = new float[2] { 4f, 2f };
			}
			foreach (List<TilePoint> part in tileGeometry_0.Parts)
			{
				if (part.Count >= 2)
				{
					PointF[] array = method_3(part, float_0);
					graphics_0.DrawLines(val, array);
				}
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void method_2(Graphics graphics_0, string string_0, PointF pointF_0, LabelStyle labelStyle_0, List<RectangleF> list_0, int int_2, float float_0)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		if (pointF_0.X < -20f || pointF_0.X > (float)(int_2 + 20) || pointF_0.Y < -20f || !(pointF_0.Y <= (float)(int_2 + 20)))
		{
			return;
		}
		FontStyle val = (FontStyle)(labelStyle_0.Bold ? 1 : 0);
		float num = labelStyle_0.FontSize * float_0;
		Font val2 = new Font("Arial", num, val, (GraphicsUnit)2);
		try
		{
			SizeF sizeF = graphics_0.MeasureString(string_0, val2);
			RectangleF rect = new RectangleF(pointF_0.X - sizeF.Width / 2f, pointF_0.Y - sizeF.Height / 2f, sizeF.Width, sizeF.Height);
			foreach (RectangleF item in list_0)
			{
				if (rect.IntersectsWith(item))
				{
					return;
				}
			}
			list_0.Add(RectangleF.Inflate(rect, 2f * float_0, 2f * float_0));
			SolidBrush val3 = new SolidBrush(labelStyle_0.HaloColor);
			try
			{
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i != 0 || j != 0)
						{
							graphics_0.DrawString(string_0, val2, (Brush)(object)val3, pointF_0.X - sizeF.Width / 2f + (float)i * float_0, pointF_0.Y - sizeF.Height / 2f + (float)j * float_0);
						}
					}
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			SolidBrush val4 = new SolidBrush(labelStyle_0.TextColor);
			try
			{
				graphics_0.DrawString(string_0, val2, (Brush)(object)val4, pointF_0.X - sizeF.Width / 2f, pointF_0.Y - sizeF.Height / 2f);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private PointF[] method_3(List<TilePoint> list_0, float float_0)
	{
		PointF[] array = new PointF[list_0.Count];
		for (int i = 0; i < list_0.Count; i++)
		{
			array[i] = new PointF((float)list_0[i].X * float_0, (float)list_0[i].Y * float_0);
		}
		return array;
	}

	private PointF? method_4(TileFeature tileFeature_0, float float_0)
	{
		if (tileFeature_0.Geometry != null && tileFeature_0.Geometry.Parts.Count != 0)
		{
			switch (tileFeature_0.Type)
			{
			default:
				return null;
			case GeometryType.Point:
			{
				TilePoint tilePoint = tileFeature_0.Geometry.Parts[0][0];
				return new PointF((float)tilePoint.X * float_0, (float)tilePoint.Y * float_0);
			}
			case GeometryType.LineString:
				return method_6(tileFeature_0.Geometry.Parts[0], float_0);
			case GeometryType.Polygon:
				return method_5(tileFeature_0.Geometry.Parts[0], float_0);
			}
		}
		return null;
	}

	private PointF method_5(List<TilePoint> list_0, float float_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int count = list_0.Count;
		int num4 = 0;
		int index = count - 1;
		while (num4 < count)
		{
			double num5 = (double)list_0[index].X * (double)list_0[num4].Y - (double)list_0[num4].X * (double)list_0[index].Y;
			num3 += num5;
			num += (double)(list_0[index].X + list_0[num4].X) * num5;
			num2 += (double)(list_0[index].Y + list_0[num4].Y) * num5;
			index = num4++;
		}
		num3 /= 2.0;
		if (Math.Abs(num3) < 1E-06)
		{
			double num6 = 0.0;
			double num7 = 0.0;
			foreach (TilePoint item in list_0)
			{
				num6 += (double)item.X;
				num7 += (double)item.Y;
			}
			return new PointF((float)(num6 / (double)count * (double)float_0), (float)(num7 / (double)count * (double)float_0));
		}
		double num8 = 1.0 / (6.0 * num3);
		return new PointF((float)(num * num8 * (double)float_0), (float)(num2 * num8 * (double)float_0));
	}

	private PointF method_6(List<TilePoint> list_0, float float_0)
	{
		if (list_0.Count == 0)
		{
			return PointF.Empty;
		}
		int index = list_0.Count / 2;
		return new PointF((float)list_0[index].X * float_0, (float)list_0[index].Y * float_0);
	}

	private Color method_7(string string_0, TileFeature tileFeature_0, Color color_0)
	{
		if (!(string_0 == "landcover") && !(string_0 == "landuse"))
		{
			return color_0;
		}
		return Style.GetLandCoverColor(tileFeature_0);
	}

	private float method_8(string string_0, TileFeature tileFeature_0)
	{
		return string_0 switch
		{
			"place" => (tileFeature_0.GetString("class") ?? "") switch
			{
				"suburb" => 4f, 
				"village" => 3f, 
				"town" => 2f, 
				"city" => 1f, 
				_ => 5f, 
			}, 
			"transportation_name" => 7f, 
			"poi" => 8f, 
			"water" => 6f, 
			_ => 9f, 
		};
	}

	static TileRenderer()
	{
		Class72.smethod_20();
	}
}
