using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Index.Quadtree;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class QuadtreeNestedRingTester
{
	private readonly GeometryGraph geometryGraph_0;

	private readonly IList ilist_0 = new ArrayList();

	private readonly Envelope envelope_0 = new Envelope();

	private Coordinate coordinate_0;

	private Quadtree quadtree_0;

	public virtual Coordinate NestedPoint => coordinate_0;

	public QuadtreeNestedRingTester(GeometryGraph graph)
	{
		geometryGraph_0 = graph;
	}

	public virtual void Add(LinearRing ring)
	{
		ilist_0.Add(ring);
		envelope_0.ExpandToInclude(ring.EnvelopeInternal);
	}

	public virtual bool IsNonNested()
	{
		method_0();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LinearRing linearRing = (LinearRing)ilist_0[i];
			IList<Coordinate> coordinates = linearRing.Coordinates;
			IList list = quadtree_0.Query(linearRing.EnvelopeInternal);
			for (int j = 0; j < list.Count; j++)
			{
				LinearRing linearRing2 = (LinearRing)list[j];
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

	private void method_0()
	{
		quadtree_0 = new Quadtree();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LinearRing linearRing = (LinearRing)ilist_0[i];
			IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
			quadtree_0.Insert(envelopeInternal, linearRing);
		}
	}

	static QuadtreeNestedRingTester()
	{
		Class72.smethod_20();
	}
}
