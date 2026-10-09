using System;

namespace DotSpatial.Topology;

public class GeometryCollectionNotSupportedException : ApplicationException
{
	public GeometryCollectionNotSupportedException()
		: base(TopologyText.GeometryCollectionNotSupportedException)
	{
	}

	static GeometryCollectionNotSupportedException()
	{
		Class72.smethod_20();
	}
}
