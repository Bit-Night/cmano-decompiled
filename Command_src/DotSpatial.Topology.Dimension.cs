using System;

namespace DotSpatial.Topology;

public class Dimension
{
	private Dimension()
	{
	}

	public static char ToDimensionSymbol(DimensionType dimensionValue)
	{
		return dimensionValue switch
		{
			DimensionType.Dontcare => '*', 
			DimensionType.True => 'T', 
			DimensionType.False => 'F', 
			DimensionType.Point => '0', 
			DimensionType.Curve => '1', 
			DimensionType.Surface => '2', 
			_ => throw new ArgumentOutOfRangeException("Unknown dimension value: " + dimensionValue), 
		};
	}

	public static DimensionType ToDimensionValue(char dimensionSymbol)
	{
		return char.ToUpper(dimensionSymbol) switch
		{
			'0' => DimensionType.Point, 
			'1' => DimensionType.Curve, 
			'2' => DimensionType.Surface, 
			'*' => DimensionType.Dontcare, 
			'T' => DimensionType.True, 
			'F' => DimensionType.False, 
			_ => throw new ArgumentOutOfRangeException("Unknown dimension symbol: " + dimensionSymbol), 
		};
	}

	static Dimension()
	{
		Class72.smethod_20();
	}
}
