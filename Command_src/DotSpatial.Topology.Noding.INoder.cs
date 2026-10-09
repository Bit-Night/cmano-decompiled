using System.Collections;

namespace DotSpatial.Topology.Noding;

public interface INoder
{
	void ComputeNodes(IList segStrings);

	IList GetNodedSubstrings();
}
