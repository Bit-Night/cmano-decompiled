using System.Globalization;

namespace DotSpatial.Topology.Utilities;

public sealed class Global
{
	private static readonly Global global_0;

	private readonly NumberFormatInfo numberFormatInfo_0;

	private Global()
	{
		numberFormatInfo_0 = new NumberFormatInfo
		{
			NumberDecimalSeparator = "."
		};
	}

	public static NumberFormatInfo GetNfi()
	{
		return global_0.numberFormatInfo_0;
	}

	static Global()
	{
		Class72.smethod_20();
		global_0 = new Global();
	}
}
