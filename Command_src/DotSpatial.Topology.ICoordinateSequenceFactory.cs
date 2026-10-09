using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface ICoordinateSequenceFactory
{
	GInterface5 Create(IEnumerable<Coordinate> coordinates);

	GInterface5 Create(Coordinate coord);

	GInterface5 Create();
}
