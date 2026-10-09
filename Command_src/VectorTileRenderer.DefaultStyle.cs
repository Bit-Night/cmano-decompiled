using System.Collections.Generic;
using System.Drawing;

namespace VectorTileRenderer;

public static class DefaultStyle
{
	private static readonly BrightStyle brightStyle_0;

	public static Color BackgroundColor => brightStyle_0.BackgroundColor;

	public static List<KeyValuePair<string, LayerStyle>> GetOrderedLayers(int zoom)
	{
		return brightStyle_0.GetOrderedLayers(zoom);
	}

	public static Color GetRoadColor(TileFeature f, bool c)
	{
		return brightStyle_0.GetRoadColor(f, c);
	}

	public static float GetRoadWidth(TileFeature f, bool c, int z)
	{
		return brightStyle_0.GetRoadWidth(f, c, z);
	}

	public static Color GetLandCoverColor(TileFeature f)
	{
		return brightStyle_0.GetLandCoverColor(f);
	}

	static DefaultStyle()
	{
		Class72.smethod_20();
		brightStyle_0 = new BrightStyle();
	}
}
