using System.Drawing;

namespace CSMaterial;

public struct UnsafeColor
{
	public byte A;

	public byte R;

	public byte G;

	public byte B;

	public UnsafeColor(Color color)
	{
		A = color.A;
		R = color.R;
		G = color.G;
		B = color.B;
	}

	public UnsafeColor(byte a, byte r, byte g, byte b)
	{
		A = a;
		R = r;
		G = g;
		B = b;
	}

	public UnsafeColor(byte r, byte g, byte b)
	{
		A = byte.MaxValue;
		R = r;
		G = g;
		B = b;
	}

	static UnsafeColor()
	{
		Class72.smethod_20();
	}
}
