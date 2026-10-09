using System;

namespace DotSpatial.Topology.KDTree;

public class KeySizeException : Exception
{
	public KeySizeException()
		: base(TopologyText.KeySizeException)
	{
	}

	static KeySizeException()
	{
		Class72.smethod_20();
	}
}
