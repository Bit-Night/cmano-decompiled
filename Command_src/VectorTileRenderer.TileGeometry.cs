using System.Collections.Generic;

namespace VectorTileRenderer;

public class TileGeometry
{
	public GeometryType Type;

	public List<List<TilePoint>> Parts = new List<List<TilePoint>>();

	static TileGeometry()
	{
		Class72.smethod_20();
	}
}
