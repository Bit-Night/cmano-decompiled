using System;

namespace DotSpatial.Topology.KDTree;

public class KeyMissingException : Exception
{
	public KeyMissingException()
		: base(TopologyText.KeyMissingException)
	{
	}

	static KeyMissingException()
	{
		Class72.smethod_20();
	}
}
