using System.Drawing;

namespace VectorTileRenderer;

public class LineStyle
{
	public Color Color = Color.Gray;

	public float Width = 1f;

	public bool Dashed;

	static LineStyle()
	{
		Class72.smethod_20();
	}
}
