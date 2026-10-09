using System.Collections.Generic;
using System.Drawing;

namespace VectorTileRenderer;

public interface IMapStyle
{
	Color BackgroundColor { get; }

	List<KeyValuePair<string, LayerStyle>> GetOrderedLayers(int zoom);

	Color GetRoadColor(TileFeature feature, bool casing);

	float GetRoadWidth(TileFeature feature, bool casing, int zoom);

	Color GetLandCoverColor(TileFeature feature);
}
