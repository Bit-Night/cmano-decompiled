namespace VectorTileRenderer;

public static class MapStyles
{
	public static IMapStyle Get(MapStyleName name)
	{
		if (name == MapStyleName.DarkMatter)
		{
			return new DarkMatterStyle();
		}
		return new BrightStyle();
	}

	static MapStyles()
	{
		Class72.smethod_20();
	}
}
