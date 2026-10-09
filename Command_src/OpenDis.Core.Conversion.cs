namespace OpenDis.Core;

public static class Conversion
{
	public const int ARTICULATION_PARAMETER_TYPE_METRIC_MASK = 31;

	public const byte ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS = 5;

	public static int GetArticulationTypeClass(int parametertype)
	{
		return parametertype >> 5;
	}

	public static int GetArticulationTypeMetric(int parametertype)
	{
		return parametertype & 0x1F;
	}

	public static uint MakeArticulationParameterType(uint typeclass, uint typemetric)
	{
		typemetric &= 0x1F;
		return (typeclass << 5) + typemetric;
	}

	static Conversion()
	{
		Class72.smethod_20();
	}
}
