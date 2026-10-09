using System;

namespace DotSpatial.Topology;

public class ShouldNeverReachHereException : Exception
{
	public ShouldNeverReachHereException()
		: base(TopologyText.ShouldNeverReachHereException)
	{
	}

	static ShouldNeverReachHereException()
	{
		Class72.smethod_20();
	}
}
