using System.Collections.Generic;
using System.Drawing;

namespace VectorTileRenderer;

public class DarkMatterStyle : IMapStyle
{
	public Color BackgroundColor => Color.FromArgb(12, 12, 12);

	public List<KeyValuePair<string, LayerStyle>> GetOrderedLayers(int zoom)
	{
		return new List<KeyValuePair<string, LayerStyle>>
		{
			new KeyValuePair<string, LayerStyle>("water", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(27, 27, 29)
				},
				Label = new LabelStyle
				{
					Draw = (zoom >= 12),
					TagKey = "name",
					TextColor = Color.FromArgb(0, 0, 0, 178),
					HaloColor = Color.FromArgb(69, 69, 69),
					FontSize = 8f,
					MinZoom = 12
				}
			}),
			new KeyValuePair<string, LayerStyle>("waterway", new LayerStyle
			{
				Line = new LineStyle
				{
					Color = Color.FromArgb(27, 27, 29),
					Width = ((zoom >= 12) ? 1.5f : 0.8f)
				}
			}),
			new KeyValuePair<string, LayerStyle>("landcover", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(32, 32, 32)
				}
			}),
			new KeyValuePair<string, LayerStyle>("landuse", new LayerStyle
			{
				Polygon = new PolygonStyle
				{
					FillColor = Color.FromArgb(20, 19, 19)
				}
			}),
			new KeyValuePair<string, LayerStyle>("building", new LayerStyle
			{
				Polygon = ((zoom >= 12) ? new PolygonStyle
				{
					FillColor = Color.FromArgb(10, 10, 10),
					DrawOutline = true,
					OutlineColor = Color.FromArgb(27, 27, 29),
					OutlineWidth = 0.5f
				} : null)
			}),
			new KeyValuePair<string, LayerStyle>("aeroway", new LayerStyle
			{
				Polygon = ((zoom >= 11) ? new PolygonStyle
				{
					FillColor = Color.FromArgb(0, 0, 0)
				} : null),
				Line = ((zoom >= 11) ? new LineStyle
				{
					Color = Color.FromArgb(24, 24, 24),
					Width = ((zoom >= 14) ? 2f : 1f)
				} : null)
			}),
			new KeyValuePair<string, LayerStyle>("transportation", smethod_0(zoom)),
			new KeyValuePair<string, LayerStyle>("transportation#fill", smethod_1(zoom)),
			new KeyValuePair<string, LayerStyle>("railway", new LayerStyle
			{
				Line = ((zoom >= 13) ? new LineStyle
				{
					Color = Color.FromArgb(35, 35, 35),
					Width = 1.5f
				} : null)
			}),
			new KeyValuePair<string, LayerStyle>("boundary", new LayerStyle
			{
				Line = new LineStyle
				{
					Color = Color.FromArgb(59, 59, 59),
					Width = ((zoom < 5) ? 0.6f : ((zoom >= 8) ? 1.5f : 1f)),
					Dashed = true
				}
			}),
			new KeyValuePair<string, LayerStyle>("place", new LayerStyle
			{
				Label = new LabelStyle
				{
					Draw = (zoom >= 4),
					TagKey = "name",
					TextColor = Color.FromArgb(101, 101, 101),
					HaloColor = Color.FromArgb(178, 0, 0, 0),
					FontSize = smethod_2(zoom),
					Bold = false,
					MinZoom = 4
				}
			}),
			new KeyValuePair<string, LayerStyle>("transportation_name", new LayerStyle
			{
				Label = new LabelStyle
				{
					Draw = (zoom >= 13),
					TagKey = "name",
					TextColor = Color.FromArgb(80, 78, 78),
					HaloColor = Color.FromArgb(220, 0, 0, 0),
					FontSize = 7f,
					MinZoom = 13
				}
			})
		};
	}

	public Color GetRoadColor(TileFeature feature, bool casing)
	{
		string text = feature.GetString("class") ?? "";
		if (casing)
		{
			int alpha;
			int red;
			int green;
			int blue;
			switch (text)
			{
			case "motorway":
				return Color.FromArgb(204, 60, 60, 60);
			case "tertiary":
				alpha = 204;
				red = 60;
				green = 60;
				blue = 60;
				break;
			default:
				return Color.FromArgb(180, 40, 40, 40);
			case "trunk":
			case "primary":
			case "secondary":
				alpha = 204;
				red = 60;
				green = 60;
				blue = 60;
				break;
			}
			return Color.FromArgb(alpha, red, green, blue);
		}
		int red2;
		int green2;
		int blue2;
		if (text == null)
		{
			red2 = 24;
			green2 = 24;
			blue2 = 24;
		}
		else
		{
			int red5;
			int green5;
			int blue5;
			int red4;
			int green4;
			int blue4;
			int red3;
			int green3;
			int blue3;
			switch (text.Length)
			{
			default:
				red2 = 24;
				green2 = 24;
				blue2 = 24;
				break;
			case 4:
				if (text == "path")
				{
					red5 = 27;
					green5 = 27;
					blue5 = 29;
					goto IL_0242;
				}
				goto case 6;
			case 5:
			{
				char c = text[2];
				if (c != 'a')
				{
					if (c != 'n')
					{
						if (c != 'u')
						{
							red2 = 24;
							green2 = 24;
							blue2 = 24;
							break;
						}
						if (!(text == "trunk"))
						{
							red2 = 24;
							green2 = 24;
							blue2 = 24;
							break;
						}
						goto IL_020e;
					}
					if (!(text == "minor"))
					{
						red2 = 24;
						green2 = 24;
						blue2 = 24;
						break;
					}
					red4 = 24;
					green4 = 24;
					blue4 = 24;
				}
				else
				{
					if (!(text == "track"))
					{
						goto case 6;
					}
					red4 = 24;
					green4 = 24;
					blue4 = 24;
				}
				goto IL_01a4;
			}
			case 7:
			{
				char c = text[0];
				if (c != 'f')
				{
					if (c == 'p')
					{
						if (!(text == "primary"))
						{
							red2 = 24;
							green2 = 24;
							blue2 = 24;
							break;
						}
						goto IL_020e;
					}
					if (c != 's')
					{
						red2 = 24;
						green2 = 24;
						blue2 = 24;
						break;
					}
					if (text == "service")
					{
						red4 = 24;
						green4 = 24;
						blue4 = 24;
						goto IL_01a4;
					}
				}
				else if (text == "footway")
				{
					red5 = 27;
					green5 = 27;
					blue5 = 29;
					goto IL_0242;
				}
				goto case 6;
			}
			case 8:
			{
				char c = text[0];
				if (c != 'c')
				{
					if (c != 'm')
					{
						if (c != 't')
						{
							red2 = 24;
							green2 = 24;
							blue2 = 24;
							break;
						}
						if (!(text == "tertiary"))
						{
							red2 = 24;
							green2 = 24;
							blue2 = 24;
							break;
						}
						goto IL_020e;
					}
					if (text == "motorway")
					{
						return Color.FromArgb(18, 18, 18);
					}
				}
				else if (text == "cycleway")
				{
					red5 = 27;
					green5 = 27;
					blue5 = 29;
					goto IL_0242;
				}
				goto case 6;
			}
			case 9:
				if (text == "secondary")
				{
					red3 = 18;
					green3 = 18;
					blue3 = 18;
					goto IL_025b;
				}
				goto case 6;
			case 6:
				{
					red2 = 24;
					green2 = 24;
					blue2 = 24;
					break;
				}
				IL_01a4:
				return Color.FromArgb(red4, green4, blue4);
				IL_0242:
				return Color.FromArgb(red5, green5, blue5);
				IL_020e:
				red3 = 18;
				green3 = 18;
				blue3 = 18;
				goto IL_025b;
				IL_025b:
				return Color.FromArgb(red3, green3, blue3);
			}
		}
		return Color.FromArgb(red2, green2, blue2);
	}

	public float GetRoadWidth(TileFeature feature, bool casing, int zoom)
	{
		float num;
		switch (feature.GetString("class") ?? "")
		{
		case "track":
		case "minor":
		case "service":
			num = 1.2f;
			break;
		case "trunk":
		case "primary":
			num = 3f;
			break;
		case "motorway":
			num = 4f;
			break;
		case "path":
		case "footway":
		case "cycleway":
			num = 0.7f;
			break;
		case "tertiary":
		case "secondary":
			num = 2f;
			break;
		default:
			num = 1.2f;
			break;
		}
		float num2 = ((zoom >= 14) ? 1f : ((zoom >= 11) ? 0.7f : ((zoom >= 8) ? 0.4f : 0.2f)));
		num *= num2;
		if (!casing)
		{
			return num;
		}
		return num + 1.2f;
	}

	public Color GetLandCoverColor(TileFeature feature)
	{
		int red;
		int green;
		int blue;
		int red2;
		int green2;
		int blue2;
		switch (feature.GetString("class") ?? feature.GetString("subclass") ?? feature.GetString("natural") ?? "")
		{
		case "forest":
			red = 32;
			green = 32;
			blue = 32;
			break;
		case "glacier":
			red2 = 12;
			green2 = 12;
			blue2 = 12;
			goto IL_00be;
		case "park":
			return Color.FromArgb(32, 32, 32);
		case "residential":
			return Color.FromArgb(13, 12, 12);
		default:
			return Color.FromArgb(22, 22, 22);
		case "ice_shelf":
			red2 = 12;
			green2 = 12;
			blue2 = 12;
			goto IL_00be;
		case "wood":
			{
				red = 32;
				green = 32;
				blue = 32;
				break;
			}
			IL_00be:
			return Color.FromArgb(red2, green2, blue2);
		}
		return Color.FromArgb(red, green, blue);
	}

	private static LayerStyle smethod_0(int int_0)
	{
		return new LayerStyle
		{
			Line = new LineStyle
			{
				Color = Color.FromArgb(204, 60, 60, 60),
				Width = ((int_0 >= 14) ? 4.5f : ((int_0 >= 11) ? 3f : ((int_0 >= 8) ? 1.5f : 0.8f)))
			}
		};
	}

	private static LayerStyle smethod_1(int int_0)
	{
		return new LayerStyle
		{
			Line = new LineStyle
			{
				Color = Color.FromArgb(18, 18, 18),
				Width = ((int_0 >= 14) ? 3f : ((int_0 >= 11) ? 2f : ((int_0 >= 8) ? 1f : 0.5f)))
			}
		};
	}

	private static float smethod_2(int int_0)
	{
		if (int_0 >= 10)
		{
			return 10f;
		}
		if (int_0 >= 7)
		{
			return 9f;
		}
		if (int_0 >= 4)
		{
			return 8f;
		}
		return 7f;
	}

	static DarkMatterStyle()
	{
		Class72.smethod_20();
	}
}
