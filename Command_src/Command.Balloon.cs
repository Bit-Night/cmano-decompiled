using System.Drawing;

namespace Command;

public sealed class Balloon
{
	public int CanvasLeft;

	public int CanvasTop;

	public int StemCanvasLeft;

	public int StemCanvasTop;

	public int ObservedHeight;

	public int ObservedWidth;

	public string Text;

	public string Summary;

	public object Tag;

	public double Lat;

	public double Lon;

	public double Opacity;

	public bool Hover;

	public Color Color;

	public double X1;

	public double X2;

	public double Y1;

	public double Y2;

	public double Radius;

	public double Theta;

	static Balloon()
	{
		Class72.smethod_20();
	}
}
