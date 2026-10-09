using System;

namespace DotSpatial.Topology.Operation.Polygonize;

public class DuplicateEdgeException : Exception
{
	public DuplicateEdgeException()
		: base(TopologyText.DuplicateEdgeException)
	{
	}

	static DuplicateEdgeException()
	{
		Class72.smethod_20();
	}
}
