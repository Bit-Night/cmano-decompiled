using System;

namespace DotSpatial.Topology.Operation.Valid;

public class ShellHoleIdentityException : Exception
{
	public ShellHoleIdentityException()
		: base(TopologyText.ShellHoleIdentityException)
	{
	}

	static ShellHoleIdentityException()
	{
		Class72.smethod_20();
	}
}
