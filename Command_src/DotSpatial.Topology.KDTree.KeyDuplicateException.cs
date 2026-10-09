using System;

namespace DotSpatial.Topology.KDTree;

public class KeyDuplicateException : Exception
{
	public KeyDuplicateException()
		: base(TopologyText.KeyDuplicateException)
	{
	}

	static KeyDuplicateException()
	{
		Class72.smethod_20();
	}
}
