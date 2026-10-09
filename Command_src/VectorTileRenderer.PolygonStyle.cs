using System.Drawing;

namespace VectorTileRenderer;

public class PolygonStyle
{
	public Color FillColor = Color.LightGray;

	public bool DrawOutline;

	public Color OutlineColor = Color.Gray;

	public float OutlineWidth = 0.5f;

	static PolygonStyle()
	{
		Class72.smethod_20();
	}
}
