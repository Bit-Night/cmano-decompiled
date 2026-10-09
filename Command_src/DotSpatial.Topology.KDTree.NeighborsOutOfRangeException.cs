using System;

namespace DotSpatial.Topology.KDTree;

public class NeighborsOutOfRangeException : ArgumentOutOfRangeException
{
	public NeighborsOutOfRangeException()
		: base(TopologyText.ArgumentOutOfRangeException_S.Replace("%S", "numNeighbors"))
	{
	}

	static NeighborsOutOfRangeException()
	{
		Class72.smethod_20();
	}
}
