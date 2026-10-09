using System;

namespace DotSpatial.Topology;

public class ClassNotSupportedException : Exception
{
	public ClassNotSupportedException(string name)
		: base(TopologyText.ClassNotSupportedException_S.Replace("%S", name))
	{
	}

	static ClassNotSupportedException()
	{
		Class72.smethod_20();
	}
}
