namespace Catfood.Shapefile;

public struct RectangleD
{
	public double Left;

	public double Top;

	public double Right;

	public double Bottom;

	public RectangleD(double left, double top, double right, double bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	static RectangleD()
	{
		Class72.smethod_20();
	}
}
