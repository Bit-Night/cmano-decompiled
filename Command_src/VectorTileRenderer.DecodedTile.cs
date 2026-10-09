using System.Collections.Generic;

namespace VectorTileRenderer;

public class DecodedTile
{
	public List<TileLayer> Layers = new List<TileLayer>();

	public TileLayer GetLayer(string name)
	{
		foreach (TileLayer layer in Layers)
		{
			if (layer.Name == name)
			{
				return layer;
			}
		}
		return null;
	}

	static DecodedTile()
	{
		Class72.smethod_20();
	}
}
