using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VectorTileRenderer;

public class GlMapStyle : IMapStyle
{
	private enum Enum10
	{
		Background,
		Fill
	}

	private class Class20
	{
		public string string_0;

		public Enum10 Type;

		public string string_1;

		public int int_0;

		public int int_1 = 24;

		public Class21 class21_0;

		public Class21 PtDyMpohgbF;

		public Class22 class22_0;

		public Class21 class21_1;

		public Class22 class22_1;

		public Class22 class22_2;

		public bool bool_0;

		public Class21 TextColor;

		public Class21 class21_2;

		public Class22 class22_3;

		public Class22 class22_4;

		public string string_2;

		static Class20()
		{
			Class72.smethod_20();
		}
	}

	private class Class21
	{
		private readonly Color color_0;

		private readonly List<(float, Color)> list_0;

		private readonly bool bool_0;

		public Class21(Color color_1)
		{
			color_0 = color_1;
			bool_0 = false;
		}

		public Class21(List<(float, Color)> list_1)
		{
			list_0 = list_1;
			bool_0 = true;
		}

		public Color method_0(int int_0)
		{
			if (!bool_0)
			{
				return color_0;
			}
			if ((float)int_0 <= list_0[0].Item1)
			{
				return list_0[0].Item2;
			}
			if ((float)int_0 >= list_0[list_0.Count - 1].Item1)
			{
				return list_0[list_0.Count - 1].Item2;
			}
			int num = 0;
			while (true)
			{
				if (num < list_0.Count - 1)
				{
					if ((float)int_0 >= list_0[num].Item1 && !((float)int_0 > list_0[num + 1].Item1))
					{
						break;
					}
					num++;
					continue;
				}
				return list_0[list_0.Count - 1].Item2;
			}
			float float_ = ((list_0[num + 1].Item1 - list_0[num].Item1 < 0.001f) ? 0f : (((float)int_0 - list_0[num].Item1) / (list_0[num + 1].Item1 - list_0[num].Item1)));
			return smethod_0(list_0[num].Item2, list_0[num + 1].Item2, float_);
		}

		private static Color smethod_0(Color color_1, Color color_2, float float_0)
		{
			return Color.FromArgb(smethod_1(color_1.A, color_2.A, float_0), smethod_1(color_1.R, color_2.R, float_0), smethod_1(color_1.G, color_2.G, float_0), smethod_1(color_1.B, color_2.B, float_0));
		}

		private static int smethod_1(int int_0, int int_1, float float_0)
		{
			return Math.Max(0, Math.Min(255, (int)((float)int_0 + (float)(int_1 - int_0) * float_0)));
		}

		static Class21()
		{
			Class72.smethod_20();
		}
	}

	private class Class22
	{
		private readonly float float_0;

		private readonly List<(float, float)> list_0;

		private readonly bool bool_0;

		public Class22(float float_1)
		{
			float_0 = float_1;
			bool_0 = false;
		}

		public Class22(List<(float, float)> list_1)
		{
			list_0 = list_1;
			bool_0 = true;
		}

		public float method_0(int int_0)
		{
			if (!bool_0)
			{
				return float_0;
			}
			if ((float)int_0 <= list_0[0].Item1)
			{
				return list_0[0].Item2;
			}
			if ((float)int_0 >= list_0[list_0.Count - 1].Item1)
			{
				return list_0[list_0.Count - 1].Item2;
			}
			int num = 0;
			while (true)
			{
				if (num < list_0.Count - 1)
				{
					if ((float)int_0 >= list_0[num].Item1 && !((float)int_0 > list_0[num + 1].Item1))
					{
						break;
					}
					num++;
					continue;
				}
				return list_0[list_0.Count - 1].Item2;
			}
			float num2 = ((list_0[num + 1].Item1 - list_0[num].Item1 < 0.001f) ? 0f : (((float)int_0 - list_0[num].Item1) / (list_0[num + 1].Item1 - list_0[num].Item1)));
			return list_0[num].Item2 + (list_0[num + 1].Item2 - list_0[num].Item2) * num2;
		}

		static Class22()
		{
			Class72.smethod_20();
		}
	}

	public string Name;

	private readonly List<Class20> list_0 = new List<Class20>();

	private Color color_0 = Color.FromArgb(242, 239, 233);

	private static readonly CultureInfo cultureInfo_0;

	public Color BackgroundColor => color_0;

	private GlMapStyle()
	{
	}

	public static GlMapStyle FromFile(string path)
	{
		if (!File.Exists(path))
		{
			throw new FileNotFoundException("GL style file not found: " + path);
		}
		return FromJson(File.ReadAllText(path, Encoding.UTF8));
	}

	public static GlMapStyle FromJson(string json)
	{
		GlMapStyle glMapStyle = new GlMapStyle();
		glMapStyle.method_0(json);
		return glMapStyle;
	}

	public List<KeyValuePair<string, LayerStyle>> GetOrderedLayers(int zoom)
	{
		List<KeyValuePair<string, LayerStyle>> list = new List<KeyValuePair<string, LayerStyle>>();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (Class20 item in list_0)
		{
			if (zoom < item.int_0 || zoom > item.int_1)
			{
				continue;
			}
			string text = item.string_1 ?? item.string_0;
			switch (item.Type)
			{
			case Enum10.Fill:
			{
				float float_ = item.class22_0?.method_0(zoom) ?? 1f;
				Color fillColor = ((item.class21_0 == null) ? Color.Transparent : smethod_7(item.class21_0.method_0(zoom), float_));
				bool drawOutline;
				Color outlineColor = ((!(drawOutline = item.PtDyMpohgbF != null)) ? Color.Transparent : item.PtDyMpohgbF.method_0(zoom));
				list.Add(new KeyValuePair<string, LayerStyle>(text, new LayerStyle
				{
					Polygon = new PolygonStyle
					{
						FillColor = fillColor,
						DrawOutline = drawOutline,
						OutlineColor = outlineColor,
						OutlineWidth = 0.5f
					}
				}));
				break;
			}
			case (Enum10)2:
			{
				dictionary.TryGetValue(text, out var value);
				dictionary[text] = value + 1;
				string key = ((value > 0) ? (text + "#fill") : text);
				float float_2 = item.class22_2?.method_0(zoom) ?? 1f;
				Color color = ((item.class21_1 == null) ? Color.Gray : smethod_7(item.class21_1.method_0(zoom), float_2));
				float width = item.class22_1?.method_0(zoom) ?? 1f;
				list.Add(new KeyValuePair<string, LayerStyle>(key, new LayerStyle
				{
					Line = new LineStyle
					{
						Color = color,
						Width = width,
						Dashed = item.bool_0
					}
				}));
				break;
			}
			case (Enum10)3:
				if (!string.IsNullOrEmpty(item.string_2) && item.class22_4 != null)
				{
					float num = item.class22_4.method_0(zoom);
					if (!(num < 1f))
					{
						Color textColor = ((item.TextColor == null) ? Color.Black : item.TextColor.method_0(zoom));
						Color haloColor = ((item.class21_2 == null) ? Color.White : item.class21_2.method_0(zoom));
						list.Add(new KeyValuePair<string, LayerStyle>(text, new LayerStyle
						{
							Label = new LabelStyle
							{
								Draw = true,
								TagKey = smethod_6(item.string_2),
								TextColor = textColor,
								HaloColor = haloColor,
								FontSize = num,
								MinZoom = item.int_0
							}
						}));
					}
				}
				break;
			}
		}
		return list;
	}

	public Color GetRoadColor(TileFeature feature, bool casing)
	{
		if (casing)
		{
			return Color.FromArgb(60, 60, 60);
		}
		return Color.FromArgb(30, 30, 30);
	}

	public float GetRoadWidth(TileFeature feature, bool casing, int zoom)
	{
		if (!casing)
		{
			return 1.2f;
		}
		return 2f;
	}

	public Color GetLandCoverColor(TileFeature feature)
	{
		return color_0;
	}

	private void method_0(string string_0)
	{
		Dictionary<string, object> dictionary = MiniJson.AsObject(MiniJson.Parse(string_0));
		if (dictionary == null)
		{
			throw new FormatException("GL style JSON root must be an object");
		}
		Name = (string)dictionary["name"];
		List<object> list = MiniJson.AsArray(MiniJson.Get(dictionary, "layers"));
		if (list != null)
		{
			foreach (object item in list)
			{
				Dictionary<string, object> dictionary2 = MiniJson.AsObject(item);
				if (dictionary2 != null)
				{
					string text = MiniJson.AsString(MiniJson.Get(dictionary2, "type")) ?? "";
					if (!(text == "background"))
					{
						Class20 @class = new Class20();
						@class.string_0 = MiniJson.AsString(MiniJson.Get(dictionary2, "id")) ?? "";
						@class.string_1 = MiniJson.AsString(MiniJson.Get(dictionary2, "source-layer"));
						@class.Type = smethod_0(text);
						@class.int_0 = (int)MiniJson.AsDouble(MiniJson.Get(dictionary2, "minzoom")).GetValueOrDefault();
						@class.int_1 = (int)(MiniJson.AsDouble(MiniJson.Get(dictionary2, "maxzoom")) ?? 24.0);
						Dictionary<string, object> dictionary3 = MiniJson.AsObject(MiniJson.Get(dictionary2, "paint"));
						Dictionary<string, object> dictionary4 = MiniJson.AsObject(MiniJson.Get(dictionary2, "layout"));
						if (dictionary3 != null)
						{
							@class.class21_0 = smethod_1(MiniJson.Get(dictionary3, "fill-color"));
							@class.PtDyMpohgbF = smethod_1(MiniJson.Get(dictionary3, "fill-outline-color"));
							@class.class22_0 = smethod_2(MiniJson.Get(dictionary3, "fill-opacity"));
							@class.class21_1 = smethod_1(MiniJson.Get(dictionary3, "line-color"));
							@class.class22_1 = smethod_2(MiniJson.Get(dictionary3, "line-width"));
							@class.class22_2 = smethod_2(MiniJson.Get(dictionary3, "line-opacity"));
							@class.TextColor = smethod_1(MiniJson.Get(dictionary3, "text-color"));
							@class.class21_2 = smethod_1(MiniJson.Get(dictionary3, "text-halo-color"));
							@class.class22_3 = smethod_2(MiniJson.Get(dictionary3, "text-halo-width"));
							@class.class22_4 = smethod_2(MiniJson.Get(dictionary3, "text-size"));
							List<object> list2 = MiniJson.AsArray(MiniJson.Get(dictionary3, "line-dasharray"));
							@class.bool_0 = list2 != null && list2.Count > 0;
						}
						if (dictionary4 != null)
						{
							if (@class.class22_4 == null)
							{
								@class.class22_4 = smethod_2(MiniJson.Get(dictionary4, "text-size"));
							}
							@class.string_2 = MiniJson.AsString(MiniJson.Get(dictionary4, "text-field"));
						}
						if (@class.Type != (Enum10)4 && @class.string_1 != null)
						{
							list_0.Add(@class);
						}
					}
					else
					{
						Dictionary<string, object> dictionary5 = MiniJson.AsObject(MiniJson.Get(dictionary2, "paint"));
						if (dictionary5 != null)
						{
							Color? color = smethod_3(MiniJson.Get(dictionary5, "background-color"));
							if (color.HasValue)
							{
								color_0 = color.Value;
							}
						}
					}
				}
			}
			return;
		}
		throw new FormatException("GL style JSON has no 'layers' array");
	}

	private static Enum10 smethod_0(string string_0)
	{
		return string_0 switch
		{
			"line" => (Enum10)2, 
			"symbol" => (Enum10)3, 
			"fill" => Enum10.Fill, 
			_ => (Enum10)4, 
		};
	}

	private static Class21 smethod_1(object object_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		string text = MiniJson.AsString(object_0);
		if (text == null)
		{
			Dictionary<string, object> dictionary = MiniJson.AsObject(object_0);
			if (dictionary != null)
			{
				List<object> list = MiniJson.AsArray(MiniJson.Get(dictionary, "stops"));
				if (list != null)
				{
					List<(float, Color)> list2 = new List<(float, Color)>();
					foreach (object item2 in list)
					{
						List<object> list3 = MiniJson.AsArray(item2);
						if (list3 == null || list3.Count < 2)
						{
							continue;
						}
						float item = (float)MiniJson.AsDouble(list3[0]).GetValueOrDefault();
						string text2 = MiniJson.AsString(list3[1]);
						if (text2 != null)
						{
							Color? color = ParseColorString(text2);
							if (color.HasValue)
							{
								list2.Add((item, color.Value));
							}
						}
					}
					if (list2.Count > 0)
					{
						return new Class21(list2);
					}
				}
			}
			return null;
		}
		Color? color2 = ParseColorString(text);
		if (!color2.HasValue)
		{
			return null;
		}
		return new Class21(color2.Value);
	}

	private static Class22 smethod_2(object object_0)
	{
		if (object_0 != null)
		{
			double? num = MiniJson.AsDouble(object_0);
			if (num.HasValue)
			{
				return new Class22((float)num.Value);
			}
			Dictionary<string, object> dictionary = MiniJson.AsObject(object_0);
			if (dictionary != null)
			{
				List<object> list = MiniJson.AsArray(MiniJson.Get(dictionary, "stops"));
				if (list != null)
				{
					List<(float, float)> list2 = new List<(float, float)>();
					foreach (object item3 in list)
					{
						List<object> list3 = MiniJson.AsArray(item3);
						if (list3 != null && list3.Count >= 2)
						{
							float item = (float)MiniJson.AsDouble(list3[0]).GetValueOrDefault();
							float item2 = (float)MiniJson.AsDouble(list3[1]).GetValueOrDefault();
							list2.Add((item, item2));
						}
					}
					if (list2.Count > 0)
					{
						return new Class22(list2);
					}
				}
			}
			return null;
		}
		return null;
	}

	private static Color? smethod_3(object object_0)
	{
		string text = MiniJson.AsString(object_0);
		if (text == null)
		{
			return null;
		}
		return ParseColorString(text);
	}

	internal static Color? ParseColorString(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			s = s.Trim();
			if (!s.StartsWith("#"))
			{
				Match match = Regex.Match(s, "rgba?\\(\\s*([\\d.]+)\\s*,\\s*([\\d.]+)\\s*,\\s*([\\d.]+)(?:\\s*,\\s*([\\d.]+))?\\s*\\)");
				if (!match.Success)
				{
					Match match2 = Regex.Match(s, "hsla?\\(\\s*([\\d.]+)\\s*,\\s*([\\d.]+)%?\\s*,\\s*([\\d.]+)%?(?:\\s*,\\s*([\\d.]+))?\\s*\\)");
					if (!match2.Success)
					{
						return s.ToLower() switch
						{
							"white" => Color.White, 
							"transparent" => Color.Transparent, 
							"red" => Color.Red, 
							"green" => Color.Green, 
							"blue" => Color.Blue, 
							"black" => Color.Black, 
							_ => null, 
						};
					}
					float float_ = float.Parse(match2.Groups[1].Value, cultureInfo_0) / 360f;
					float float_2 = float.Parse(match2.Groups[2].Value, cultureInfo_0) / 100f;
					float float_3 = float.Parse(match2.Groups[3].Value, cultureInfo_0) / 100f;
					float num = (match2.Groups[4].Success ? float.Parse(match2.Groups[4].Value, cultureInfo_0) : 1f);
					(int, int, int) tuple = smethod_4(float_, float_2, float_3);
					return Color.FromArgb((int)(num * 255f), tuple.Item1, tuple.Item2, tuple.Item3);
				}
				int red = (int)float.Parse(match.Groups[1].Value, cultureInfo_0);
				int green = (int)float.Parse(match.Groups[2].Value, cultureInfo_0);
				int blue = (int)float.Parse(match.Groups[3].Value, cultureInfo_0);
				return Color.FromArgb((int)(((!match.Groups[4].Success) ? 1f : float.Parse(match.Groups[4].Value, cultureInfo_0)) * 255f), red, green, blue);
			}
			string text = s.Substring(1);
			if (text.Length == 3)
			{
				text = text[0].ToString() + text[0] + text[1] + text[1] + text[2] + text[2];
			}
			if (text.Length == 6)
			{
				try
				{
					int red2 = Convert.ToInt32(text.Substring(0, 2), 16);
					int green2 = Convert.ToInt32(text.Substring(2, 2), 16);
					int blue2 = Convert.ToInt32(text.Substring(4, 2), 16);
					return Color.FromArgb(255, red2, green2, blue2);
				}
				catch
				{
					return null;
				}
			}
			return null;
		}
		return null;
	}

	private static (int, int, int) smethod_4(float float_0, float float_1, float float_2)
	{
		float num;
		float num2;
		float num3;
		if (float_1 < 0.001f)
		{
			num = (num2 = (num3 = float_2));
		}
		else
		{
			float num4 = ((float_2 < 0.5f) ? (float_2 * (1f + float_1)) : (float_2 + float_1 - float_2 * float_1));
			float float_3 = 2f * float_2 - num4;
			num = smethod_5(float_3, num4, float_0 + 1f / 3f);
			num2 = smethod_5(float_3, num4, float_0);
			num3 = smethod_5(float_3, num4, float_0 - 1f / 3f);
		}
		return ((int)(num * 255f), (int)(num2 * 255f), (int)(num3 * 255f));
	}

	private static float smethod_5(float float_0, float float_1, float float_2)
	{
		if (float_2 < 0f)
		{
			float_2 += 1f;
		}
		if (float_2 > 1f)
		{
			float_2 -= 1f;
		}
		if (float_2 < 1f / 6f)
		{
			return float_0 + (float_1 - float_0) * 6f * float_2;
		}
		if (float_2 < 0.5f)
		{
			return float_1;
		}
		if (float_2 < 2f / 3f)
		{
			return float_0 + (float_1 - float_0) * (2f / 3f - float_2) * 6f;
		}
		return float_0;
	}

	private static string smethod_6(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			Match match = Regex.Match(string_0, "\\{([^:}]+)");
			if (match.Success)
			{
				return match.Groups[1].Value;
			}
			return "name";
		}
		return "name";
	}

	private static Color smethod_7(Color color_1, float float_0)
	{
		if (float_0 >= 1f)
		{
			return color_1;
		}
		return Color.FromArgb((int)((float)(int)color_1.A * float_0), color_1.R, color_1.G, color_1.B);
	}

	static GlMapStyle()
	{
		Class72.smethod_20();
		cultureInfo_0 = CultureInfo.InvariantCulture;
	}
}
