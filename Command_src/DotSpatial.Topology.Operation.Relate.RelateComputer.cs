using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateComputer
{
	private readonly GeometryGraph[] geometryGraph_0;

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly LineIntersector lineIntersector_0 = new RobustLineIntersector();

	private readonly NodeMap nodeMap_0 = new NodeMap(new RelateNodeFactory());

	private readonly PointLocator pointLocator_0 = new PointLocator();

	public RelateComputer(GeometryGraph[] arg)
	{
		geometryGraph_0 = arg;
	}

	public virtual IntersectionMatrix ComputeIm()
	{
		IntersectionMatrix intersectionMatrix = new IntersectionMatrix();
		intersectionMatrix.Set(LocationType.Exterior, LocationType.Exterior, DimensionType.Surface);
		if (geometryGraph_0[0].Geometry.EnvelopeInternal.Intersects(geometryGraph_0[1].Geometry.EnvelopeInternal))
		{
			geometryGraph_0[0].ComputeSelfNodes(lineIntersector_0, computeRingSelfNodes: false);
			geometryGraph_0[1].ComputeSelfNodes(lineIntersector_0, computeRingSelfNodes: false);
			SegmentIntersector segmentIntersector_ = geometryGraph_0[0].ComputeEdgeIntersections(geometryGraph_0[1], lineIntersector_0, includeProper: false);
			method_3(0);
			method_3(1);
			method_2(0);
			method_2(1);
			YcqejrObUhX();
			method_1(segmentIntersector_, intersectionMatrix);
			EdgeEndBuilder edgeEndBuilder = new EdgeEndBuilder();
			IList ienumerable_ = edgeEndBuilder.ComputeEdgeEnds(geometryGraph_0[0].GetEdgeEnumerator());
			method_0(ienumerable_);
			IList ienumerable_2 = edgeEndBuilder.ComputeEdgeEnds(geometryGraph_0[1].GetEdgeEnumerator());
			method_0(ienumerable_2);
			method_5();
			method_7(0, 1);
			method_7(1, 0);
			method_6(intersectionMatrix);
			return intersectionMatrix;
		}
		method_4(intersectionMatrix);
		return intersectionMatrix;
	}

	private void method_0(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd e = (EdgeEnd)enumerator.Current;
			nodeMap_0.Add(e);
		}
	}

	private void method_1(SegmentIntersector segmentIntersector_0, GInterface7 ginterface7_0)
	{
		DimensionType dimension = geometryGraph_0[0].Geometry.Dimension;
		DimensionType dimension2 = geometryGraph_0[1].Geometry.Dimension;
		bool hasProperIntersection = segmentIntersector_0.HasProperIntersection;
		bool hasProperInteriorIntersection = segmentIntersector_0.HasProperInteriorIntersection;
		if (dimension == DimensionType.Surface && dimension2 == DimensionType.Surface)
		{
			if (hasProperIntersection)
			{
				ginterface7_0.SetAtLeast("212101212");
			}
		}
		else if (dimension == DimensionType.Surface && dimension2 == DimensionType.Curve)
		{
			if (hasProperIntersection)
			{
				ginterface7_0.SetAtLeast("FFF0FFFF2");
			}
			if (hasProperInteriorIntersection)
			{
				ginterface7_0.SetAtLeast("1FFFFF1FF");
			}
		}
		else if (dimension == DimensionType.Curve && dimension2 == DimensionType.Surface)
		{
			if (hasProperIntersection)
			{
				ginterface7_0.SetAtLeast("F0FFFFFF2");
			}
			if (hasProperInteriorIntersection)
			{
				ginterface7_0.SetAtLeast("1F1FFFFFF");
			}
		}
		else if (dimension == DimensionType.Curve && dimension2 == DimensionType.Curve && hasProperInteriorIntersection)
		{
			ginterface7_0.SetAtLeast("0FFFFFFFF");
		}
	}

	private void method_2(int int_0)
	{
		IEnumerator nodeEnumerator = geometryGraph_0[int_0].GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			nodeMap_0.AddNode(node.Coordinate).SetLabel(int_0, node.Label.GetLocation(int_0));
		}
	}

	private void method_3(int int_0)
	{
		IEnumerator edgeEnumerator = geometryGraph_0[int_0].GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			LocationType location = obj.Label.GetLocation(int_0);
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
				RelateNode relateNode = (RelateNode)nodeMap_0.AddNode(edgeIntersection.Coordinate);
				if (location == LocationType.Boundary)
				{
					relateNode.SetLabelBoundary(int_0);
				}
				else if (relateNode.Label.IsNull(int_0))
				{
					relateNode.SetLabel(int_0, LocationType.Interior);
				}
			}
		}
	}

	private void method_4(GInterface7 ginterface7_0)
	{
		IGeometry geometry = geometryGraph_0[0].Geometry;
		if (!geometry.IsEmpty)
		{
			ginterface7_0.Set(LocationType.Interior, LocationType.Exterior, geometry.Dimension);
			ginterface7_0.Set(LocationType.Boundary, LocationType.Exterior, geometry.BoundaryDimension);
		}
		IGeometry geometry2 = geometryGraph_0[1].Geometry;
		if (!geometry2.IsEmpty)
		{
			ginterface7_0.Set(LocationType.Exterior, LocationType.Interior, geometry2.Dimension);
			ginterface7_0.Set(LocationType.Exterior, LocationType.Boundary, geometry2.BoundaryDimension);
		}
	}

	private void method_5()
	{
		IEnumerator enumerator = nodeMap_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((RelateNode)enumerator.Current).Edges.ComputeLabelling(geometryGraph_0);
		}
	}

	private void method_6(IntersectionMatrix intersectionMatrix_0)
	{
		IEnumerator enumerator = arrayList_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Edge)enumerator.Current).UpdateIm(intersectionMatrix_0);
		}
		IEnumerator enumerator2 = nodeMap_0.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			RelateNode obj = (RelateNode)enumerator2.Current;
			obj.UpdateIm(intersectionMatrix_0);
			obj.UpdateImFromEdges(intersectionMatrix_0);
		}
	}

	private void method_7(int int_0, int int_1)
	{
		IEnumerator edgeEnumerator = geometryGraph_0[int_0].GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge edge = (Edge)edgeEnumerator.Current;
			if (edge.IsIsolated)
			{
				method_8(edge, int_1, geometryGraph_0[int_1].Geometry);
				arrayList_0.Add(edge);
			}
		}
	}

	private void method_8(GraphComponent graphComponent_0, int int_0, IGeometry igeometry_0)
	{
		if (igeometry_0.Dimension > DimensionType.Point)
		{
			LocationType location = pointLocator_0.Locate(graphComponent_0.Coordinate, igeometry_0);
			graphComponent_0.Label.SetAllLocations(int_0, location);
		}
		else
		{
			graphComponent_0.Label.SetAllLocations(int_0, LocationType.Exterior);
		}
	}

	private void YcqejrObUhX()
	{
		foreach (Node item in nodeMap_0)
		{
			Label label = item.Label;
			Assert.IsTrue(label.GeometryCount > 0, "node with empty label found");
			if (item.IsIsolated)
			{
				method_9(item, (!label.IsNull(0)) ? 1 : 0);
			}
		}
	}

	private void method_9(GraphComponent graphComponent_0, int int_0)
	{
		LocationType location = pointLocator_0.Locate(graphComponent_0.Coordinate, geometryGraph_0[int_0].Geometry);
		graphComponent_0.Label.SetAllLocations(int_0, location);
	}

	static RelateComputer()
	{
		Class72.smethod_20();
	}
}
