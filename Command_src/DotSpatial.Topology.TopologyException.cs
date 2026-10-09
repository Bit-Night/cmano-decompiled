using System;

namespace DotSpatial.Topology;

public class TopologyException : ApplicationException
{
	private readonly Coordinate coordinate_0;

	public virtual Coordinate Coordinate => coordinate_0;

	public TopologyException(string msg)
		: base(msg)
	{
	}

	public TopologyException(string msg, Coordinate pt)
		: base(smethod_0(msg, pt))
	{
		coordinate_0 = new Coordinate(pt);
	}

	private static string smethod_0(string string_0, Coordinate coordinate_1)
	{
		if (!(coordinate_1 != null))
		{
			return string_0;
		}
		return string_0 + " [ " + ((object)coordinate_1)?.ToString() + " ]";
	}

	static TopologyException()
	{
		Class72.smethod_20();
	}
}
