using System.Collections;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Operation.Relate;

namespace DotSpatial.Topology.Operation.Valid;

public class ConsistentAreaTester
{
	private readonly GeometryGraph geometryGraph_0;

	private readonly LineIntersector lineIntersector_0 = new RobustLineIntersector();

	private readonly RelateNodeGraph relateNodeGraph_0 = new RelateNodeGraph();

	private Coordinate coordinate_0;

	public virtual Coordinate InvalidPoint => coordinate_0;

	public virtual bool IsNodeConsistentArea
	{
		get
		{
			SegmentIntersector segmentIntersector = geometryGraph_0.ComputeSelfNodes(lineIntersector_0, computeRingSelfNodes: true);
			if (segmentIntersector.HasProperIntersection)
			{
				coordinate_0 = segmentIntersector.ProperIntersectionPoint;
				return false;
			}
			relateNodeGraph_0.Build(geometryGraph_0);
			return method_0();
		}
	}

	public virtual bool HasDuplicateRings
	{
		get
		{
			IEnumerator nodeEnumerator = relateNodeGraph_0.GetNodeEnumerator();
			while (nodeEnumerator.MoveNext())
			{
				IEnumerator enumerator = ((RelateNode)nodeEnumerator.Current).Edges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					EdgeEndBundle edgeEndBundle = (EdgeEndBundle)enumerator.Current;
					if (edgeEndBundle.EdgeEnds.Count > 1)
					{
						coordinate_0 = edgeEndBundle.Edge.GetCoordinate(0);
						return true;
					}
				}
			}
			return false;
		}
	}

	public ConsistentAreaTester(GeometryGraph geomGraph)
	{
		geometryGraph_0 = geomGraph;
	}

	[SpecialName]
	private bool method_0()
	{
		IEnumerator nodeEnumerator = relateNodeGraph_0.GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			RelateNode relateNode = (RelateNode)nodeEnumerator.Current;
			if (!relateNode.Edges.IsAreaLabelsConsistent)
			{
				coordinate_0 = (Coordinate)relateNode.Coordinate.Clone();
				return false;
			}
		}
		return true;
	}

	static ConsistentAreaTester()
	{
		Class72.smethod_20();
	}
}
