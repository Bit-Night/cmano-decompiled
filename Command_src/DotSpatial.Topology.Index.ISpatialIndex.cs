using System.Collections;

namespace DotSpatial.Topology.Index;

public interface ISpatialIndex
{
	void Insert(IEnvelope itemEnv, object item);

	IList Query(IEnvelope searchEnv);

	void Query(IEnvelope searchEnv, IItemVisitor visitor);

	bool Remove(IEnvelope itemEnv, object item);
}
