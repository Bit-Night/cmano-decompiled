using System;

namespace DotSpatial.Topology.GeometriesGraph;

public class TwoHorizontalEdgesException : Exception
{
	public TwoHorizontalEdgesException()
		: base(TopologyText.TwoHorizontalEdgesException)
	{
	}

	static TwoHorizontalEdgesException()
	{
		Class72.smethod_20();
	}
}
