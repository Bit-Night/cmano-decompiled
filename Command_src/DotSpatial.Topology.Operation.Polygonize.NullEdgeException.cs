using System;

namespace DotSpatial.Topology.Operation.Polygonize;

public class NullEdgeException : Exception
{
	public NullEdgeException()
		: base(TopologyText.NullEdgeException)
	{
	}

	static NullEdgeException()
	{
		Class72.smethod_20();
	}
}
