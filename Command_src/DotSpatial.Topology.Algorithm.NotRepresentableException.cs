using System;

namespace DotSpatial.Topology.Algorithm;

public class NotRepresentableException : ApplicationException
{
	public NotRepresentableException()
		: base("Projective point not representable on the Cartesian plane.")
	{
	}

	static NotRepresentableException()
	{
		Class72.smethod_20();
	}
}
