using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class OverlayOp : GeometryGraphOperation
{
	private readonly EdgeList edgeList_0 = new EdgeList();

	private readonly IGeometryFactory igeometryFactory_0;

	private readonly PlanarGraph planarGraph_0;

	private readonly PointLocator pointLocator_0 = new PointLocator();

	private IGeometry igeometry_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private IList ilist_2 = new ArrayList();

	public virtual PlanarGraph Graph => planarGraph_0;

	public OverlayOp(IGeometry g0, IGeometry g1)
		: base(g0, g1)
	{
		planarGraph_0 = new PlanarGraph(new OverlayNodeFactory());
		igeometryFactory_0 = g0.Factory;
	}

	public static IGeometry Overlay(IGeometry geom0, IGeometry geom1, SpatialFunction opCode)
	{
		return new OverlayOp(geom0, geom1).GetResultGeometry(opCode);
	}

	public static bool IsResultOfOp(Label label, SpatialFunction opCode)
	{
		LocationType location = label.GetLocation(0);
		LocationType location2 = label.GetLocation(1);
		return IsResultOfOp(location, location2, opCode);
	}

	public static bool IsResultOfOp(LocationType loc0, LocationType loc1, SpatialFunction opCode)
	{
		if (loc0 == LocationType.Boundary)
		{
			loc0 = LocationType.Interior;
		}
		if (loc1 == LocationType.Boundary)
		{
			loc1 = LocationType.Interior;
		}
		switch (opCode)
		{
		default:
			return false;
		case SpatialFunction.Intersection:
			if (loc0 != LocationType.Interior)
			{
				return false;
			}
			return loc1 == LocationType.Interior;
		case SpatialFunction.Union:
			if (loc0 != LocationType.Interior)
			{
				return loc1 == LocationType.Interior;
			}
			return true;
		case SpatialFunction.Difference:
			if (loc0 != LocationType.Interior)
			{
				return false;
			}
			return loc1 != LocationType.Interior;
		case SpatialFunction.SymDifference:
			if (loc0 == LocationType.Interior && loc1 != LocationType.Interior)
			{
				return true;
			}
			if (loc0 != LocationType.Interior)
			{
				return loc1 == LocationType.Interior;
			}
			return false;
		}
	}

	public IGeometry GetResultGeometry(SpatialFunction funcCode)
	{
		method_0(funcCode);
		return igeometry_0;
	}

	private void method_0(SpatialFunction spatialFunction_0)
	{
		method_4(0);
		method_4(1);
		Arg[0].ComputeSelfNodes(base.LineIntersector, computeRingSelfNodes: false);
		Arg[1].ComputeSelfNodes(base.LineIntersector, computeRingSelfNodes: false);
		Arg[0].ComputeEdgeIntersections(Arg[1], base.LineIntersector, includeProper: true);
		IList list = new ArrayList();
		Arg[0].ComputeSplitEdges(list);
		Arg[1].ComputeSplitEdges(list);
		method_1(list);
		method_2();
		method_3();
		planarGraph_0.AddEdges(edgeList_0.Edges);
		aoYePejKryQ();
		method_7();
		method_9(spatialFunction_0);
		method_10();
		PolygonBuilder polygonBuilder = new PolygonBuilder(igeometryFactory_0);
		polygonBuilder.Add(planarGraph_0);
		ilist_2 = polygonBuilder.Polygons;
		LineBuilder lineBuilder = new LineBuilder(this, igeometryFactory_0, pointLocator_0);
		ilist_0 = lineBuilder.Build(spatialFunction_0);
		PointBuilder pointBuilder = new PointBuilder(this, igeometryFactory_0);
		ilist_1 = pointBuilder.Build(spatialFunction_0);
		igeometry_0 = method_12(ilist_1, ilist_0, ilist_2);
	}

	private void method_1(IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge e = (Edge)enumerator.Current;
			InsertUniqueEdge(e);
		}
	}

	protected virtual void InsertUniqueEdge(Edge e)
	{
		int num = edgeList_0.FindEdgeIndex(e);
		if (num < 0)
		{
			edgeList_0.Add(e);
			return;
		}
		Edge edge = edgeList_0[num];
		Label label = edge.Label;
		Label label2 = e.Label;
		if (!edge.IsPointwiseEqual(e))
		{
			label2 = new Label(e.Label);
			label2.Flip();
		}
		Depth depth = edge.Depth;
		if (depth.IsNull())
		{
			depth.Add(label);
		}
		depth.Add(label2);
		label.Merge(label2);
	}

	private void method_2()
	{
		IEnumerator enumerator = edgeList_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge obj = (Edge)enumerator.Current;
			Label label = obj.Label;
			Depth depth = obj.Depth;
			if (depth.IsNull())
			{
				continue;
			}
			depth.Normalize();
			for (int i = 0; i < 2; i++)
			{
				if (!label.IsNull(i) && label.IsArea() && !depth.IsNull(i))
				{
					if (depth.GetDelta(i) == 0)
					{
						label.ToLine(i);
						continue;
					}
					Assert.IsTrue(!depth.IsNull(i, PositionType.Left), "depth of Left side has not been initialized");
					label.SetLocation(i, PositionType.Left, depth.GetLocation(i, PositionType.Left));
					Assert.IsTrue(!depth.IsNull(i, PositionType.Right), "depth of Right side has not been initialized");
					label.SetLocation(i, PositionType.Right, depth.GetLocation(i, PositionType.Right));
				}
			}
		}
	}

	private void method_3()
	{
		IList list = new ArrayList();
		IList list2 = new ArrayList();
		IEnumerator enumerator = edgeList_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			if (edge.IsCollapsed)
			{
				list2.Add(enumerator.Current);
				list.Add(edge.CollapsedEdge);
			}
		}
		foreach (Edge item in list2)
		{
			edgeList_0.Remove(item);
		}
		foreach (object item2 in list)
		{
			edgeList_0.Add((Edge)item2);
		}
	}

	private void method_4(int int_0)
	{
		IEnumerator nodeEnumerator = Arg[int_0].GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			planarGraph_0.AddNode(node.Coordinate).SetLabel(int_0, node.Label.GetLocation(int_0));
		}
	}

	private void aoYePejKryQ()
	{
		IEnumerator enumerator = planarGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Node)enumerator.Current).Edges.ComputeLabelling(Arg);
		}
		method_5();
		method_6();
	}

	private void method_5()
	{
		IEnumerator enumerator = planarGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).MergeSymLabels();
		}
	}

	private void method_6()
	{
		IEnumerator enumerator = planarGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node obj = (Node)enumerator.Current;
			Label label = ((DirectedEdgeStar)obj.Edges).Label;
			obj.Label.Merge(label);
		}
	}

	private void method_7()
	{
		IEnumerator enumerator = planarGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			Label label = node.Label;
			if (node.IsIsolated)
			{
				if (label.IsNull(0))
				{
					method_8(node, 0);
				}
				else
				{
					method_8(node, 1);
				}
			}
			((DirectedEdgeStar)node.Edges).UpdateLabelling(label);
		}
	}

	private void method_8(Node node_0, int int_0)
	{
		LocationType location = pointLocator_0.Locate(node_0.Coordinate, Arg[int_0].Geometry);
		node_0.Label.SetLocation(int_0, location);
	}

	private void method_9(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = planarGraph_0.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			Label label = directedEdge.Label;
			if (label.IsArea() && !directedEdge.IsInteriorAreaEdge && IsResultOfOp(label.GetLocation(0, PositionType.Right), label.GetLocation(1, PositionType.Right), spatialFunction_0))
			{
				directedEdge.IsInResult = true;
			}
		}
	}

	private void method_10()
	{
		IEnumerator enumerator = planarGraph_0.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			DirectedEdge sym = directedEdge.Sym;
			if (directedEdge.IsInResult && sym.IsInResult)
			{
				directedEdge.IsInResult = false;
				sym.IsInResult = false;
			}
		}
	}

	public virtual bool IsCoveredByLa(Coordinate coord)
	{
		if (method_11(coord, ilist_0))
		{
			return true;
		}
		if (method_11(coord, ilist_2))
		{
			return true;
		}
		return false;
	}

	public virtual bool IsCoveredByA(Coordinate coord)
	{
		if (!method_11(coord, ilist_2))
		{
			return false;
		}
		return true;
	}

	private bool method_11(Coordinate coordinate_0, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IGeometry geom = (IGeometry)enumerator.Current;
			if (pointLocator_0.Locate(coordinate_0, geom) != LocationType.Exterior)
			{
				return true;
			}
		}
		return false;
	}

	private IGeometry method_12(IList ilist_3, IList ilist_4, IList ilist_5)
	{
		ArrayList arrayList = new ArrayList();
		foreach (object item in ilist_3)
		{
			arrayList.Add(item);
		}
		foreach (object item2 in ilist_4)
		{
			arrayList.Add(item2);
		}
		foreach (object item3 in ilist_5)
		{
			arrayList.Add(item3);
		}
		return igeometryFactory_0.BuildGeometry(arrayList);
	}

	static OverlayOp()
	{
		Class72.smethod_20();
	}
}
