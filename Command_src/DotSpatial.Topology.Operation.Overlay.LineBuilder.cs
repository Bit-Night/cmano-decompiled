using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class LineBuilder
{
	private readonly IGeometryFactory igeometryFactory_0;

	private readonly IList ilist_0 = new ArrayList();

	private readonly OverlayOp overlayOp_0;

	private readonly PointLocator pointLocator_0;

	private readonly IList ilist_1 = new ArrayList();

	public LineBuilder(OverlayOp op, IGeometryFactory geometryFactory, PointLocator ptLocator)
	{
		overlayOp_0 = op;
		igeometryFactory_0 = geometryFactory;
		pointLocator_0 = ptLocator;
	}

	public virtual IList Build(SpatialFunction opCode)
	{
		method_0();
		method_1(opCode);
		method_2(opCode);
		return ilist_1;
	}

	private void method_0()
	{
		IEnumerator enumerator = overlayOp_0.Graph.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((DirectedEdgeStar)((Node)enumerator.Current).Edges).FindCoveredLineEdges();
		}
		IEnumerator enumerator2 = overlayOp_0.Graph.EdgeEnds.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator2.Current;
			Edge edge = directedEdge.Edge;
			if (directedEdge.IsLineEdge && !edge.IsCoveredSet)
			{
				bool isCovered = overlayOp_0.IsCoveredByA(directedEdge.Coordinate);
				edge.IsCovered = isCovered;
			}
		}
	}

	private void method_1(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = overlayOp_0.Graph.EdgeEnds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge de = (DirectedEdge)enumerator.Current;
			CollectLineEdge(de, spatialFunction_0, ilist_0);
			CollectBoundaryTouchEdge(de, spatialFunction_0, ilist_0);
		}
	}

	public void CollectLineEdge(DirectedEdge de, SpatialFunction opCode, IList edges)
	{
		Label label = de.Label;
		Edge edge = de.Edge;
		if (de.IsLineEdge && !de.IsVisited && OverlayOp.IsResultOfOp(label, opCode) && !edge.IsCovered)
		{
			edges.Add(edge);
			de.VisitedEdge = true;
		}
	}

	public virtual void CollectBoundaryTouchEdge(DirectedEdge de, SpatialFunction opCode, IList edges)
	{
		Label label = de.Label;
		if (!de.IsLineEdge && !de.IsVisited && !de.IsInteriorAreaEdge && !de.Edge.IsInResult)
		{
			Assert.IsTrue((!de.IsInResult && !de.Sym.IsInResult) || !de.Edge.IsInResult);
			if (OverlayOp.IsResultOfOp(label, opCode) && opCode == SpatialFunction.Intersection)
			{
				edges.Add(de.Edge);
				de.VisitedEdge = true;
			}
		}
	}

	private void method_2(SpatialFunction spatialFunction_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			ILineString value = igeometryFactory_0.CreateLineString(edge.Coordinates);
			ilist_1.Add(value);
			edge.IsInResult = true;
		}
	}

	private void method_3(IList ilist_2)
	{
		IEnumerator enumerator = ilist_2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge edge = (Edge)enumerator.Current;
			Label label = edge.Label;
			if (edge.IsIsolated)
			{
				if (label.IsNull(0))
				{
					method_4(edge, 0);
				}
				else
				{
					method_4(edge, 1);
				}
			}
		}
	}

	private void method_4(Edge edge_0, int int_0)
	{
		LocationType location = pointLocator_0.Locate(edge_0.Coordinate, overlayOp_0.GetArgGeometry(int_0));
		edge_0.Label.SetLocation(int_0, location);
	}

	static LineBuilder()
	{
		Class72.smethod_20();
	}
}
