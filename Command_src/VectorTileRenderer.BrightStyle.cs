using System.Collections.Generic;
using System.Drawing;

namespace VectorTileRenderer;

public class BrightStyle : IMapStyle
{
	public Color BackgroundColor => Color.FromArgb(242, 239, 233);

	public List<KeyValuePair<string, LayerStyle>> GetOrderedLayers(int zoom)
	{
		return new List<KeyValuePair<string, LayerStyle>>
		{
			new KeyValuePair<string, LayerStyle>("water", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(170, 211, 223),
					DrawOutline = true,
					OutlineColor = Color.FromArgb(140, 185, 200),
					OutlineWidth = 0.5f
				},
				Label = new LabelStyle
				{
					Draw = (zoom >= 12),
					TagKey = "name",
					TextColor = Color.FromArgb(50, 100, 140),
					HaloColor = Color.FromArgb(200, 170, 211, 223),
					FontSize = 8f,
					MinZoom = 12
				}
			}),
			new KeyValuePair<string, LayerStyle>("waterway", new LayerStyle
			{
				Line = new LineStyle
				{
					Color = Color.FromArgb(170, 211, 223),
					Width = ((zoom >= 12) ? 1.5f : 0.8f)
				}
			}),
			new KeyValuePair<string, LayerStyle>("landcover", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(200, 230, 190)
				}
			}),
			new KeyValuePair<string, LayerStyle>("landuse", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(220, 215, 200)
				}
			}),
			new KeyValuePair<string, LayerStyle>("park", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(200, 230, 190)
				}
			}),
			new KeyValuePair<string, LayerStyle>("building", new LayerStyle
			{
				Polygon = ((zoom >= 13) ? new PolygonStyle
				{
					FillColor = Color.FromArgb(215, 210, 200),
					DrawOutline = true,
					OutlineColor = Color.FromArgb(190, 185, 175),
					OutlineWidth = 0.5f
				} : null)
			}),
			new KeyValuePair<string, LayerStyle>("transportation", smethod_0(zoom)),
			new KeyValuePair<string, LayerStyle>("transportation#fill", smethod_1(zoom)),
			new KeyValuePair<string, LayerStyle>("railway", new LayerStyle
			{
				Line = ((zoom >= 10) ? new LineStyle
				{
					Color = Color.FromArgb(160, 150, 170),
					Width = 1.2f,
					Dashed = true
				} : null)
			}),
			new KeyValuePair<string, LayerStyle>("boundary", new LayerStyle
			{
				Line = new LineStyle
				{
					Color = Color.FromArgb(180, 120, 120),
					Width = ((zoom >= 8) ? 1.5f : 0.8f),
					Dashed = true
				}
			}),
			new KeyValuePair<string, LayerStyle>("place", new LayerStyle
			{
				Label = new LabelStyle
				{
					Draw = (zoom >= 6),
					TagKey = "name",
					TextColor = Color.FromArgb(50, 50, 50),
					HaloColor = Color.FromArgb(220, 242, 239, 233),
					FontSize = smethod_2(zoom),
					Bold = (zoom >= 8),
					MinZoom = 6
				}
			}),
			new KeyValuePair<string, LayerStyle>("poi", new LayerStyle
			{
				Label = new LabelStyle
				{
					Draw = (zoom >= 15),
					TagKey = "name",
					TextColor = Color.FromArgb(80, 60, 40),
					HaloColor = Color.FromArgb(200, 242, 239, 233),
					FontSize = 7f,
					MinZoom = 15
				}
			}),
			new KeyValuePair<string, LayerStyle>("transportation_name", new LayerStyle
			{
				Label = new LabelStyle
				{
					Draw = (zoom >= 13),
					TagKey = "name",
					TextColor = Color.FromArgb(60, 60, 60),
					HaloColor = Color.FromArgb(210, 255, 255, 255),
					FontSize = 7f,
					MinZoom = 13
				}
			})
		};
	}

	public Color GetRoadColor(TileFeature feature, bool casing)
	{
		string text = feature.GetString("class") ?? feature.GetString("highway") ?? "";
		if (casing)
		{
			return text switch
			{
				"motorway" => Color.FromArgb(190, 140, 100), 
				"trunk" => Color.FromArgb(195, 160, 110), 
				"secondary" => Color.FromArgb(195, 185, 140), 
				"primary" => Color.FromArgb(200, 175, 120), 
				_ => Color.FromArgb(180, 170, 155), 
			};
		}
		int red;
		int green;
		int blue;
		if (text == null)
		{
			red = 255;
			green = 252;
			blue = 245;
		}
		else
		{
			int red2;
			int green2;
			int blue2;
			switch (text.Length)
			{
			default:
				red = 255;
				green = 252;
				blue = 245;
				break;
			case 4:
				if (text == "path")
				{
					red2 = 200;
					green2 = 190;
					blue2 = 175;
					goto IL_02a0;
				}
				goto case 6;
			case 5:
			{
				char c = text[2];
				if (c != 'a')
				{
					if (c != 'u')
					{
						red = 255;
						green = 252;
						blue = 245;
						break;
					}
					if (!(text == "trunk"))
					{
						red = 255;
						green = 252;
						blue = 245;
						break;
					}
					return Color.FromArgb(240, 185, 120);
				}
				if (text == "track")
				{
					red2 = 200;
					green2 = 190;
					blue2 = 175;
					goto IL_02a0;
				}
				goto case 6;
			}
			case 7:
			{
				char c = text[0];
				if (c != 'f')
				{
					if (c != 'p')
					{
						red = 255;
						green = 252;
						blue = 245;
						break;
					}
					if (text == "primary")
					{
						return Color.FromArgb(255, 215, 140);
					}
					goto case 6;
				}
				if (!(text == "footway"))
				{
					red = 255;
					green = 252;
					blue = 245;
					break;
				}
				red2 = 200;
				green2 = 190;
				blue2 = 175;
				goto IL_02a0;
			}
			case 8:
			{
				char c = text[0];
				if (c != 'c')
				{
					if (c != 'm')
					{
						red = 255;
						green = 252;
						blue = 245;
						break;
					}
					if (!(text == "motorway"))
					{
						red = 255;
						green = 252;
						blue = 245;
						break;
					}
					return Color.FromArgb(230, 160, 100);
				}
				if (text == "cycleway")
				{
					red2 = 200;
					green2 = 190;
					blue2 = 175;
					goto IL_02a0;
				}
				goto case 6;
			}
			case 9:
				if (text == "secondary")
				{
					return Color.FromArgb(250, 240, 180);
				}
				goto case 6;
			case 6:
				{
					red = 255;
					green = 252;
					blue = 245;
					break;
				}
				IL_02a0:
				return Color.FromArgb(red2, green2, blue2);
			}
		}
		return Color.FromArgb(red, green, blue);
	}

	public float GetRoadWidth(TileFeature feature, bool casing, int zoom)
	{
		float num;
		switch (feature.GetString("class") ?? feature.GetString("highway") ?? "")
		{
		case "trunk":
			num = 3.5f;
			break;
		case "primary":
			num = 3f;
			break;
		case "tertiary":
			num = 2f;
			break;
		case "motorway":
			num = 4f;
			break;
		case "path":
		case "footway":
		case "cycleway":
			num = 0.8f;
			break;
		case "secondary":
			num = 2.5f;
			break;
		default:
			num = 1.5f;
			break;
		}
		float num2 = ((zoom >= 14) ? 1f : ((zoom >= 12) ? 0.7f : 0.4f));
		num *= num2;
		if (!casing)
		{
			return num;
		}
		return num + 1.4f;
	}

	public Color GetLandCoverColor(TileFeature feature)
	{
		string text = feature.GetString("class") ?? feature.GetString("landuse") ?? feature.GetString("natural") ?? "";
		if (text == null)
		{
			goto IL_0531;
		}
		switch (text.Length)
		{
		case 4:
			goto IL_0094;
		case 5:
			goto IL_016a;
		case 6:
			goto IL_01ea;
		case 7:
			goto IL_02d5;
		case 8:
			goto IL_0343;
		case 10:
			goto IL_0413;
		case 11:
			if (text == "residential")
			{
				return Color.FromArgb(232, 228, 218);
			}
			goto IL_0531;
		case 13:
			goto IL_04e0;
		case 17:
			goto IL_04fe;
		case 9:
		case 12:
		case 14:
		case 15:
		case 16:
			goto IL_0531;
		}
		int red = 220;
		int green = 215;
		int blue = 200;
		goto IL_0540;
		IL_0413:
		char c = text[0];
		int red2;
		int green2;
		int blue2;
		if (c != 'c')
		{
			if (c != 'i')
			{
				if (c != 'u')
				{
					red = 220;
					green = 215;
					blue = 200;
					goto IL_0540;
				}
				if (text == "university")
				{
					red2 = 230;
					green2 = 220;
					blue2 = 195;
					goto IL_045d;
				}
			}
			else if (text == "industrial")
			{
				return Color.FromArgb(220, 210, 220);
			}
			goto IL_0531;
		}
		if (!(text == "commercial"))
		{
			red = 220;
			green = 215;
			blue = 200;
			goto IL_0540;
		}
		int red3 = 230;
		int green3 = 218;
		int blue3 = 210;
		goto IL_04b8;
		IL_01ea:
		c = text[0];
		if ((uint)c > 109u)
		{
			if (c != 'r')
			{
				if (c != 's')
				{
					red = 220;
					green = 215;
					blue = 200;
					goto IL_0540;
				}
				if (text == "school")
				{
					red2 = 230;
					green2 = 220;
					blue2 = 195;
					goto IL_045d;
				}
			}
			else if (text == "retail")
			{
				red3 = 230;
				green3 = 218;
				blue3 = 210;
				goto IL_04b8;
			}
			goto IL_0531;
		}
		int red4;
		int green4;
		int blue4;
		if (c != 'f')
		{
			if (c != 'm')
			{
				red = 220;
				green = 215;
				blue = 200;
			}
			else
			{
				if (text == "meadow")
				{
					goto IL_051c;
				}
				red = 220;
				green = 215;
				blue = 200;
			}
		}
		else
		{
			if (text == "forest")
			{
				red4 = 175;
				green4 = 210;
				blue4 = 155;
				goto IL_02cf;
			}
			red = 220;
			green = 215;
			blue = 200;
		}
		goto IL_0540;
		IL_016a:
		c = text[0];
		int red5;
		int green5;
		int blue5;
		int red6;
		int green6;
		int blue6;
		if (c != 'b')
		{
			if (c == 'g')
			{
				if (text == "grass")
				{
					red5 = 205;
					green5 = 235;
					blue5 = 176;
					goto IL_052b;
				}
				goto IL_0531;
			}
			red = 220;
			green = 215;
			blue = 200;
		}
		else
		{
			if (text == "beach")
			{
				red6 = 240;
				green6 = 228;
				blue6 = 184;
				goto IL_01e4;
			}
			red = 220;
			green = 215;
			blue = 200;
		}
		goto IL_0540;
		IL_0540:
		return Color.FromArgb(red, green, blue);
		IL_02d5:
		c = text[0];
		if (c != 'c')
		{
			if (c != 'o')
			{
				red = 220;
				green = 215;
				blue = 200;
			}
			else
			{
				if (text == "orchard")
				{
					goto IL_03c8;
				}
				red = 220;
				green = 215;
				blue = 200;
			}
			goto IL_0540;
		}
		if (text == "college")
		{
			red2 = 230;
			green2 = 220;
			blue2 = 195;
			goto IL_045d;
		}
		goto IL_0531;
		IL_0094:
		c = text[0];
		if ((uint)c <= 112u)
		{
			if (c != 'f')
			{
				if (c != 'p')
				{
					red = 220;
					green = 215;
					blue = 200;
				}
				else
				{
					if (text == "park")
					{
						goto IL_051c;
					}
					red = 220;
					green = 215;
					blue = 200;
				}
			}
			else
			{
				if (text == "farm")
				{
					goto IL_03c8;
				}
				red = 220;
				green = 215;
				blue = 200;
			}
			goto IL_0540;
		}
		if (c != 's')
		{
			if (c != 'w')
			{
				red = 220;
				green = 215;
				blue = 200;
				goto IL_0540;
			}
			if (text == "wood")
			{
				red4 = 175;
				green4 = 210;
				blue4 = 155;
				goto IL_02cf;
			}
		}
		else if (text == "sand")
		{
			red6 = 240;
			green6 = 228;
			blue6 = 184;
			goto IL_01e4;
		}
		goto IL_0531;
		IL_0343:
		c = text[0];
		if (c != 'c')
		{
			if (c != 'f')
			{
				if (c != 'h')
				{
					red = 220;
					green = 215;
					blue = 200;
				}
				else
				{
					if (text == "hospital")
					{
						return Color.FromArgb(235, 210, 210);
					}
					red = 220;
					green = 215;
					blue = 200;
				}
			}
			else
			{
				if (text == "farmland")
				{
					goto IL_03c8;
				}
				red = 220;
				green = 215;
				blue = 200;
			}
		}
		else
		{
			if (text == "cemetery")
			{
				return Color.FromArgb(200, 220, 195);
			}
			red = 220;
			green = 215;
			blue = 200;
		}
		goto IL_0540;
		IL_0531:
		red = 220;
		green = 215;
		blue = 200;
		goto IL_0540;
		IL_01e4:
		return Color.FromArgb(red6, green6, blue6);
		IL_04b8:
		return Color.FromArgb(red3, green3, blue3);
		IL_051c:
		red5 = 205;
		green5 = 235;
		blue5 = 176;
		goto IL_052b;
		IL_052b:
		return Color.FromArgb(red5, green5, blue5);
		IL_04fe:
		if (text == "recreation_ground")
		{
			goto IL_051c;
		}
		red = 220;
		green = 215;
		blue = 200;
		goto IL_0540;
		IL_02cf:
		return Color.FromArgb(red4, green4, blue4);
		IL_045d:
		return Color.FromArgb(red2, green2, blue2);
		IL_04e0:
		if (text == "village_green")
		{
			goto IL_051c;
		}
		red = 220;
		green = 215;
		blue = 200;
		goto IL_0540;
		IL_03c8:
		return Color.FromArgb(238, 240, 213);
	}

	private static LayerStyle smethod_0(int int_0)
	{
		return new LayerStyle
		{
			Line = new LineStyle
			{
				Color = Color.FromArgb(180, 170, 155),
				Width = ((int_0 >= 14) ? 4f : ((int_0 >= 12) ? 2.5f : 1.5f))
			}
		};
	}

	private static LayerStyle smethod_1(int int_0)
	{
		return new LayerStyle
		{
			Line = new LineStyle
			{
				Color = Color.FromArgb(255, 250, 240),
				Width = ((int_0 >= 14) ? 2.5f : ((int_0 >= 12) ? 1.5f : 0.8f))
			}
		};
	}

	private static float smethod_2(int int_0)
	{
		if (int_0 >= 14)
		{
			return 11f;
		}
		if (int_0 >= 12)
		{
			return 9f;
		}
		if (int_0 >= 10)
		{
			return 8f;
		}
		return 7f;
	}

	static BrightStyle()
	{
		Class72.smethod_20();
	}
}
