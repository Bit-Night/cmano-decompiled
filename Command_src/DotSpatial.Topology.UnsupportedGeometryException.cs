using System;

namespace DotSpatial.Topology;

public class UnsupportedGeometryException : Exception
{
	public UnsupportedGeometryException()
		: base(TopologyText.UnsupportedGeometryException)
	{
	}

	static UnsupportedGeometryException()
	{
		Class72.smethod_20();
	}
}
