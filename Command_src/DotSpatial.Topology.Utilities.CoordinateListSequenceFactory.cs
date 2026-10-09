using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

[Serializable]
public sealed class CoordinateListSequenceFactory : ICoordinateSequenceFactory
{
	public static readonly CoordinateListSequenceFactory Instance;

	public GInterface5 Create(IEnumerable<Coordinate> coordinates)
	{
		return new CoordinateListSequence(coordinates);
	}

	public GInterface5 Create()
	{
		return new CoordinateListSequence();
	}

	public GInterface5 Create(Coordinate coordinate)
	{
		return new CoordinateListSequence(coordinate);
	}

	public GInterface5 Create(GInterface5 coordSeq)
	{
		return new CoordinateListSequence(coordSeq);
	}

	static CoordinateListSequenceFactory()
	{
		Class72.smethod_20();
		Instance = new CoordinateListSequenceFactory();
	}
}
