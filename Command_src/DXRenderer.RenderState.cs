using System.Drawing;

namespace DXRenderer;

public class RenderState
{
	public bool BingMap;

	public bool SentinelMap;

	public bool ReliefBathymetryMap;

	public bool BMNGMap;

	public bool bool_0;

	public bool LandCoverOverlay;

	public bool StamenTerrainOverlay;

	public bool StamenLinesOverlay;

	public bool PlacenamesOverlay;

	public bool DayNight;

	public bool LatitudeLongitudeGrid;

	public bool BordersCoasts;

	public bool OpenTopoOverlay;

	public bool bool_1;

	public bool Scale;

	public bool BaseEarth;

	public bool BorderColorChanged;

	public Color BorderColor;

	public bool SeaIceColorChanged;

	public Color SeaIceColor;

	static RenderState()
	{
		Class72.smethod_20();
	}
}
