using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Operation.Overlay;
using DotSpatial.Topology.Operation.Polygonize;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Valid;

public class ConnectedInteriorTester
{
	private readonly GeometryGraph geometryGraph_0;

	private readonly GeometryFactory geometryFactory_0 = new GeometryFactory();

	private Coordinate coordinate_0;

	public Coordinate Coordinate => coordinate_0;

	public ConnectedInteriorTester(GeometryGraph geomGraph)
	{
		geometryGraph_0 = geomGraph;
	}

	private static Coordinate smethod_0(IEnumerable<Coordinate> ienumerable_0, object object_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			if (!item.Equals(object_0))
			{
				return item;
			}
		}
		return null;
	}

	public bool IsInteriorsConnected()
	{
		IList list = new ArrayList();
		geometryGraph_0.ComputeSplitEdges(list);
		PlanarGraph planarGraph = new PlanarGraph(new OverlayNodeFactory());
		planarGraph.AddEdges(list);
		smethod_1(planarGraph);
		planarGraph.LinkResultDirectedEdges();
		IList ilist_ = method_0(planarGraph.EdgeEnds);
		smethod_2(geometryGraph_0.Geometry, planarGraph);
		return !method_1(ilist_);
	}

	private static void smethod_1(PlanarGraph planarGraph_0)
	{
		foreach (DirectedEdge edgeEnd in planarGraph_0.EdgeEnds)
		{
			if (edgeEnd.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
			{
				edgeEnd.IsInResult = true;
			}
		}
	}

	private IList method_0(IList ilist_0)
	{
		IList list = new ArrayList();
		foreach (DirectedEdge item in ilist_0)
		{
			if (!item.IsInResult || item.EdgeRing != null)
			{
				continue;
			}
			MaximalEdgeRing maximalEdgeRing = new MaximalEdgeRing(item, geometryFactory_0);
			maximalEdgeRing.LinkDirectedEdgesForMinimalEdgeRings();
			foreach (object item2 in maximalEdgeRing.BuildMinimalRings())
			{
				list.Add(item2);
			}
		}
		return list;
	}

	private static void smethod_2(object object_0, PlanarGraph planarGraph_0)
	{
		if (object_0 is Polygon)
		{
			smethod_3(((Polygon)object_0).Shell, planarGraph_0);
		}
		if (object_0 is MultiPolygon)
		{
			IGeometry[] geometries = ((MultiPolygon)object_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				smethod_3(((Polygon)geometries[i]).Shell, planarGraph_0);
			}
		}
	}

	private static void smethod_3(IBasicGeometry ibasicGeometry_0, PlanarGraph planarGraph_0)
	{
		IList<Coordinate> coordinates = ibasicGeometry_0.Coordinates;
		Coordinate coordinate = coordinates[0];
		Coordinate p = smethod_0(coordinates, coordinate);
		Edge e = planarGraph_0.FindEdgeInSameDirection(coordinate, p);
		DirectedEdge directedEdge = (DirectedEdge)planarGraph_0.FindEdgeEnd(e);
		DirectedEdge directedEdge2 = null;
		if (directedEdge.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
		{
			directedEdge2 = directedEdge;
		}
		else if (directedEdge.Sym.Label.GetLocation(0, PositionType.Right) == LocationType.Interior)
		{
			directedEdge2 = directedEdge.Sym;
		}
		Assert.IsTrue(directedEdge2 != null, "unable to find dirEdge with Interior on RHS");
		smethod_4(directedEdge2);
	}

	private static void smethod_4(DirectedEdge directedEdge_0)
	{
		DirectedEdge directedEdge = directedEdge_0;
		while (directedEdge != null)
		{
			directedEdge.IsVisited = true;
			directedEdge = directedEdge.Next;
			if (directedEdge == directedEdge_0)
			{
				return;
			}
		}
		throw new NullEdgeException();
	}

	private bool method_1(IList ilist_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			DotSpatial.Topology.GeometriesGraph.EdgeRing edgeRing = (DotSpatial.Topology.GeometriesGraph.EdgeRing)ilist_0[i];
			if (edgeRing.IsHole)
			{
				continue;
			}
			IList edges = edgeRing.Edges;
			DirectedEdge directedEdge = (DirectedEdge)edges[0];
			if (directedEdge.Label.GetLocation(0, PositionType.Right) != LocationType.Interior)
			{
				continue;
			}
			for (int j = 0; j < edges.Count; j++)
			{
				directedEdge = (DirectedEdge)edges[j];
				if (!directedEdge.IsVisited)
				{
					coordinate_0 = directedEdge.Coordinate;
					return true;
				}
			}
		}
		return false;
	}

	static ConnectedInteriorTester()
	{
		Class72.smethod_20();
	}
}
