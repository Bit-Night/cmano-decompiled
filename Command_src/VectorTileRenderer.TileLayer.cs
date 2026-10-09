using System.Collections.Generic;

namespace VectorTileRenderer;

public class TileLayer
{
	public string Name;

	public uint Extent;

	public List<TileFeature> Features = new List<TileFeature>();

	static TileLayer()
	{
		Class72.smethod_20();
	}
}
