using System;

namespace DotSpatial.Topology;

public class CoordinateMismatchException : ArgumentException
{
	public CoordinateMismatchException()
		: base(TopologyText.CoordinateMismatchException)
	{
	}

	static CoordinateMismatchException()
	{
		Class72.smethod_20();
	}
}
