using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Index.Sweepline;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class SweeplineNestedRingTester
{
	public class OverlapAction : ISweepLineOverlapAction
	{
		private readonly SweeplineNestedRingTester sweeplineNestedRingTester_0;

		private bool bool_0 = true;

		public virtual bool IsNonNested => bool_0;

		public OverlapAction(SweeplineNestedRingTester container)
		{
			sweeplineNestedRingTester_0 = container;
		}

		public virtual void Overlap(SweepLineInterval s0, SweepLineInterval s1)
		{
			LinearRing linearRing = (LinearRing)s0.Item;
			LinearRing linearRing2 = (LinearRing)s1.Item;
			if (linearRing != linearRing2 && sweeplineNestedRingTester_0.method_1(linearRing, linearRing2))
			{
				bool_0 = false;
			}
		}

		static OverlapAction()
		{
			Class72.smethod_20();
		}
	}

	private readonly GeometryGraph geometryGraph_0;

	private readonly IList ilist_0 = new ArrayList();

	private Coordinate coordinate_0;

	private SweepLineIndex sweepLineIndex_0;

	public virtual Coordinate NestedPoint => coordinate_0;

	public SweeplineNestedRingTester(GeometryGraph graph)
	{
		geometryGraph_0 = graph;
	}

	public virtual void Add(LinearRing ring)
	{
		ilist_0.Add(ring);
	}

	public virtual bool IsNonNested()
	{
		method_0();
		OverlapAction overlapAction = new OverlapAction(this);
		sweepLineIndex_0.ComputeOverlaps(overlapAction);
		return overlapAction.IsNonNested;
	}

	private void method_0()
	{
		sweepLineIndex_0 = new SweepLineIndex();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			LinearRing linearRing = (LinearRing)ilist_0[i];
			IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
			SweepLineInterval sweepInt = new SweepLineInterval(envelopeInternal.Minimum.X, envelopeInternal.Maximum.X, linearRing);
			sweepLineIndex_0.Add(sweepInt);
		}
	}

	private bool method_1(ILinearRing ilinearRing_0, ILinearRing ilinearRing_1)
	{
		IList<Coordinate> coordinates = ilinearRing_0.Coordinates;
		IList<Coordinate> coordinates2 = ilinearRing_1.Coordinates;
		if (!ilinearRing_0.EnvelopeInternal.Intersects(ilinearRing_1.EnvelopeInternal))
		{
			return false;
		}
		Coordinate coordinate = IsValidOp.FindPointNotNode(coordinates, ilinearRing_1, geometryGraph_0);
		Assert.IsTrue(coordinate != null, "Unable to find a ring point not a node of the search ring");
		if (CgAlgorithms.IsPointInRing(coordinate, coordinates2))
		{
			coordinate_0 = new Coordinate(coordinate);
			return true;
		}
		return false;
	}

	static SweeplineNestedRingTester()
	{
		Class72.smethod_20();
	}
}
