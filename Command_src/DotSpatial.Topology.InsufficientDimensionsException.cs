using System;

namespace DotSpatial.Topology;

public class InsufficientDimensionsException : ArgumentException
{
	public InsufficientDimensionsException()
		: base(TopologyText.InsufficientDimensions)
	{
	}

	public InsufficientDimensionsException(string argumentName)
		: base(TopologyText.InsufficientDimensions_S.Replace("%S", argumentName))
	{
	}

	static InsufficientDimensionsException()
	{
		Class72.smethod_20();
	}
}
