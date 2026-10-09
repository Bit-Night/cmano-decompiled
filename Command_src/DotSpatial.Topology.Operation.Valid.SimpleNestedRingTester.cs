using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class SimpleNestedRingTester
{
	private readonly GeometryGraph geometryGraph_0;

	private readonly IList ilist_0 = new ArrayList();

	private Coordinate coordinate_0;

	public virtual Coordinate NestedPoint => coordinate_0;

	public SimpleNestedRingTester(GeometryGraph graph)
	{
		geometryGraph_0 = graph;
	}

	public virtual void Add(LinearRing ring)
	{
		ilist_0.Add(ring);
	}

	public virtual bool IsNonNested()
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LinearRing linearRing = (LinearRing)ilist_0[i];
			IList<Coordinate> coordinates = linearRing.Coordinates;
			for (int j = 0; j < ilist_0.Count; j++)
			{
				LinearRing linearRing2 = (LinearRing)ilist_0[j];
				IList<Coordinate> coordinates2 = linearRing2.Coordinates;
				if (linearRing != linearRing2 && linearRing.EnvelopeInternal.Intersects(linearRing2.EnvelopeInternal))
				{
					Coordinate coordinate = IsValidOp.FindPointNotNode(coordinates, linearRing2, geometryGraph_0);
					Assert.IsTrue(coordinate != null, "Unable to find a ring point not a node of the search ring");
					if (CgAlgorithms.IsPointInRing(coordinate, coordinates2))
					{
						coordinate_0 = coordinate;
						return false;
					}
				}
			}
		}
		return true;
	}

	static SimpleNestedRingTester()
	{
		Class72.smethod_20();
	}
}
