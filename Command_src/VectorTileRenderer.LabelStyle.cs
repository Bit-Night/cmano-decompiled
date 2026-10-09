using System.Drawing;

namespace VectorTileRenderer;

public class LabelStyle
{
	public bool Draw;

	public string TagKey = "name";

	public Color TextColor = Color.Black;

	public Color HaloColor = Color.White;

	public float FontSize = 8f;

	public bool Bold;

	public int MinZoom = 12;

	public int MinTextLength;

	static LabelStyle()
	{
		Class72.smethod_20();
	}
}
