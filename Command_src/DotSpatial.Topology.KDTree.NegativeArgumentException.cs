using System;

namespace DotSpatial.Topology.KDTree;

public class NegativeArgumentException : ArgumentException
{
	public NegativeArgumentException(string parameterName)
		: base(TopologyText.ArgumentCannotBeNegative_S.Replace("%S", parameterName))
	{
	}

	static NegativeArgumentException()
	{
		Class72.smethod_20();
	}
}
