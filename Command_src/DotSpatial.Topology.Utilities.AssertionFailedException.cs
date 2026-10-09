using System;

namespace DotSpatial.Topology.Utilities;

public class AssertionFailedException : ApplicationException
{
	public AssertionFailedException()
	{
	}

	public AssertionFailedException(string message)
		: base(message)
	{
	}

	static AssertionFailedException()
	{
		Class72.smethod_20();
	}
}
