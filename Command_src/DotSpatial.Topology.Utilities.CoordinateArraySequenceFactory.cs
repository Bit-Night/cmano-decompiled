using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

[Serializable]
public sealed class CoordinateArraySequenceFactory : ICoordinateSequenceFactory
{
	public static readonly CoordinateArraySequenceFactory Instance;

	private CoordinateArraySequenceFactory()
	{
	}

	public GInterface5 Create(IEnumerable<Coordinate> coordinates)
	{
		return new CoordinateArraySequence(coordinates);
	}

	public GInterface5 Create(Coordinate coord)
	{
		return new CoordinateArraySequence(coord);
	}

	public GInterface5 Create()
	{
		return new CoordinateArraySequence();
	}

	public GInterface5 Create(GInterface5 coordSeq)
	{
		return new CoordinateArraySequence(coordSeq);
	}

	static CoordinateArraySequenceFactory()
	{
		Class72.smethod_20();
		Instance = new CoordinateArraySequenceFactory();
	}
}
