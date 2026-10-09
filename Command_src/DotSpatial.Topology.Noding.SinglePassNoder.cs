using System.Collections;

namespace DotSpatial.Topology.Noding;

public abstract class SinglePassNoder : INoder
{
	private GInterface8 ginterface8_0;

	public GInterface8 SegmentIntersector
	{
		get
		{
			return ginterface8_0;
		}
		set
		{
			ginterface8_0 = value;
		}
	}

	protected SinglePassNoder()
	{
	}

	protected SinglePassNoder(GInterface8 segInt)
	{
		ginterface8_0 = segInt;
	}

	public abstract void ComputeNodes(IList segStrings);

	public abstract IList GetNodedSubstrings();

	static SinglePassNoder()
	{
		Class72.smethod_20();
	}
}
