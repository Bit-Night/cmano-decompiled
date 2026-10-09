using System;
using System.Drawing;
using System.Text;

namespace Command_Core;

public sealed class RangeSymbol
{
	public enum SymbolType : byte
	{
		Circle = 1,
		Wedge
	}

	public string Description;

	public double RangeNM;

	public float LeftArc;

	public float RightArc;

	public SymbolType Type;

	public Color Color;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public RangeSymbol(SymbolType theType, string theDescription, double theRangeNM, float theLeftArc, float theRightArc, Color theColor)
	{
		Type = theType;
		Description = theDescription;
		RangeNM = theRangeNM;
		LeftArc = theLeftArc;
		RightArc = theRightArc;
		Color = theColor;
	}

	public RangeSymbol(SymbolType theType, string theDescription, double theRangeNM, Color theColor)
	{
		Type = theType;
		Description = theDescription;
		RangeNM = theRangeNM;
		Color = theColor;
	}

	static RangeSymbol()
	{
		Class72.smethod_20();
	}
}
