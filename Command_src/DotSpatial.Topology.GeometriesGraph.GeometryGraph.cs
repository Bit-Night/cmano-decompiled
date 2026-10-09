using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph.Index;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public class GeometryGraph : PlanarGraph
{
	private readonly int int_0;

	private readonly IDictionary idictionary_0 = new Hashtable();

	private readonly IGeometry igeometry_0;

	private ICollection icollection_0;

	private bool IvNepGievwL;

	private Coordinate coordinate_0;

	private bool bool_0;

	public virtual bool HasTooFewPoints => IvNepGievwL;

	public virtual Coordinate InvalidPoint => coordinate_0;

	public virtual IGeometry Geometry => igeometry_0;

	public virtual ICollection BoundaryNodes
	{
		get
		{
			if (icollection_0 == null)
			{
				icollection_0 = Nodes.GetBoundaryNodes(int_0);
			}
			return icollection_0;
		}
	}

	public GeometryGraph(int argIndex, IGeometry parentGeom)
	{
		int_0 = argIndex;
		igeometry_0 = parentGeom;
		if (parentGeom != null)
		{
			Add(parentGeom);
		}
	}

	public static bool IsInBoundary(int boundaryCount)
	{
		return boundaryCount % 2 == 1;
	}

	public static LocationType DetermineBoundary(int boundaryCount)
	{
		if (!IsInBoundary(boundaryCount))
		{
			return LocationType.Interior;
		}
		return LocationType.Boundary;
	}

	public virtual Coordinate[] GetBoundaryPoints()
	{
		ICollection boundaryNodes = BoundaryNodes;
		Coordinate[] array = new Coordinate[boundaryNodes.Count];
		int num = 0;
		IEnumerator enumerator = boundaryNodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			array[num++] = (Coordinate)node.Coordinate.Clone();
		}
		return array;
	}

	public virtual Edge FindEdge(ILineString line)
	{
		return (Edge)idictionary_0[line];
	}

	public virtual void ComputeSplitEdges(IList edgelist)
	{
		IEnumerator enumerator = base.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			((Edge)enumerator.Current).EdgeIntersectionList.AddSplitEdges(edgelist);
		}
	}

	private void Add(IGeometry g)
	{
		if (g.IsEmpty)
		{
			return;
		}
		if (g is GeometryCollection && !(g is MultiPolygon))
		{
			bool_0 = true;
		}
		if (!(g is Polygon))
		{
			if (g is LineString)
			{
				method_3(g);
			}
			else if (g is Point)
			{
				AddPoint(g.Coordinate);
			}
			else
			{
				method_0(g);
			}
		}
		else
		{
			method_2((Polygon)g);
		}
	}

	private void method_0(IGeometry igeometry_1)
	{
		for (int i = 0; i < igeometry_1.NumGeometries; i++)
		{
			IGeometry geometryN = igeometry_1.GetGeometryN(i);
			Add(geometryN);
		}
	}

	private void method_1(IBasicGeometry ibasicGeometry_0, LocationType locationType_0, LocationType locationType_1)
	{
		IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(ibasicGeometry_0.Coordinates);
		if (list.Count < 4)
		{
			IvNepGievwL = true;
			coordinate_0 = list[0];
			return;
		}
		LocationType leftLoc = locationType_0;
		LocationType rightLoc = locationType_1;
		if (CgAlgorithms.IsCounterClockwise(list))
		{
			leftLoc = locationType_1;
			rightLoc = locationType_0;
		}
		Edge edge = new Edge(list, new Label(int_0, LocationType.Boundary, leftLoc, rightLoc));
		idictionary_0.Add(ibasicGeometry_0, edge);
		InsertEdge(edge);
		method_4(int_0, list[0], LocationType.Boundary);
	}

	private void method_2(Polygon polygon_0)
	{
		method_1(polygon_0.ExteriorRing, LocationType.Exterior, LocationType.Interior);
		for (int i = 0; i < polygon_0.NumHoles; i++)
		{
			method_1(polygon_0.GetInteriorRingN(i), LocationType.Interior, LocationType.Exterior);
		}
	}

	private void method_3(IBasicGeometry ibasicGeometry_0)
	{
		IList<Coordinate> list = CoordinateArrays.RemoveRepeatedPoints(ibasicGeometry_0.Coordinates);
		if (list.Count >= 2)
		{
			Edge edge = new Edge(list, new Label(int_0, LocationType.Interior));
			idictionary_0.Add(ibasicGeometry_0, edge);
			InsertEdge(edge);
			Assert.IsTrue(list.Count >= 2, "found LineString with single point");
			method_5(int_0, list[0]);
			method_5(int_0, list[list.Count - 1]);
		}
		else
		{
			IvNepGievwL = true;
			coordinate_0 = list[0];
		}
	}

	public virtual void AddEdge(Edge e)
	{
		InsertEdge(e);
		IList<Coordinate> coordinates = e.Coordinates;
		method_4(int_0, coordinates[0], LocationType.Boundary);
		method_4(int_0, coordinates[coordinates.Count - 1], LocationType.Boundary);
	}

	public virtual void AddPoint(Coordinate pt)
	{
		method_4(int_0, pt, LocationType.Interior);
	}

	public virtual SegmentIntersector ComputeSelfNodes(LineIntersector li, bool computeRingSelfNodes)
	{
		SegmentIntersector segmentIntersector = new SegmentIntersector(li, includeProper: true, recordIsolated: false);
		EdgeSetIntersector edgeSetIntersector = new SimpleMcSweepLineIntersector();
		if (!computeRingSelfNodes && (igeometry_0 is ILinearRing || igeometry_0 is IPolygon || igeometry_0 is IMultiPolygon))
		{
			edgeSetIntersector.ComputeIntersections(base.Edges, segmentIntersector, testAllSegments: false);
		}
		else
		{
			edgeSetIntersector.ComputeIntersections(base.Edges, segmentIntersector, testAllSegments: true);
		}
		method_6(int_0);
		return segmentIntersector;
	}

	public virtual SegmentIntersector ComputeEdgeIntersections(GeometryGraph g, LineIntersector li, bool includeProper)
	{
		SegmentIntersector segmentIntersector = new SegmentIntersector(li, includeProper, recordIsolated: true);
		segmentIntersector.SetBoundaryNodes(BoundaryNodes, g.BoundaryNodes);
		new SimpleMcSweepLineIntersector().ComputeIntersections(base.Edges, g.Edges, segmentIntersector);
		return segmentIntersector;
	}

	private void method_4(int int_1, Coordinate coordinate_1, LocationType locationType_0)
	{
		Node node = Nodes.AddNode(coordinate_1);
		Label label = node.Label;
		if (label != null)
		{
			label.SetLocation(int_1, locationType_0);
		}
		else
		{
			node.Label = new Label(int_1, locationType_0);
		}
	}

	private void method_5(int int_1, Coordinate coordinate_1)
	{
		Label label = Nodes.AddNode(coordinate_1).Label;
		int num = 1;
		LocationType locationType = LocationType.Null;
		if (label != null)
		{
			locationType = label.GetLocation(int_1, PositionType.On);
		}
		if (locationType == LocationType.Boundary)
		{
			num++;
		}
		LocationType location = DetermineBoundary(num);
		label?.SetLocation(int_1, location);
	}

	private void method_6(int int_1)
	{
		IEnumerator enumerator = base.Edges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Edge obj = (Edge)enumerator.Current;
			LocationType location = obj.Label.GetLocation(int_1);
			IEnumerator enumerator2 = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator2.Current;
				method_7(int_1, edgeIntersection.Coordinate, location);
			}
		}
	}

	private void method_7(int int_1, Coordinate coordinate_1, LocationType locationType_0)
	{
		if (!IsBoundaryNode(int_1, coordinate_1))
		{
			if (locationType_0 == LocationType.Boundary && bool_0)
			{
				method_5(int_1, coordinate_1);
			}
			else
			{
				method_4(int_1, coordinate_1, locationType_0);
			}
		}
	}

	static GeometryGraph()
	{
		Class72.smethod_20();
	}
}
