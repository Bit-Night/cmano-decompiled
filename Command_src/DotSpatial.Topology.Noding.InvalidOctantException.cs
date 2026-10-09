using System;

namespace DotSpatial.Topology.Noding;

public class InvalidOctantException : Exception
{
	public InvalidOctantException(string value)
		: base(TopologyText.InvalidOctantException_S.Replace("%S", value))
	{
	}

	static InvalidOctantException()
	{
		Class72.smethod_20();
	}
}
