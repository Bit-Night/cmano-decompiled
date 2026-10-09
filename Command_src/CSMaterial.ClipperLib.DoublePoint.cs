namespace CSMaterial.ClipperLib;

public struct DoublePoint
{
	public double X;

	public double Y;

	public DoublePoint(double x = 0.0, double y = 0.0)
	{
		X = x;
		Y = y;
	}

	public DoublePoint(DoublePoint dp)
	{
		X = dp.X;
		Y = dp.Y;
	}

	public DoublePoint(IntPoint ip)
	{
		X = ip.X;
		Y = ip.Y;
	}

	static DoublePoint()
	{
		Class72.smethod_20();
	}
}
