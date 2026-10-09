using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Valid;

public class IsValidOp
{
	private readonly Geometry geometry_0;

	private bool bool_0;

	private TopologyValidationError RarejeHjjAt;

	public bool IsSelfTouchingRingFormingHoleValid
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public virtual bool IsValid
	{
		get
		{
			method_0(geometry_0);
			return RarejeHjjAt == null;
		}
	}

	public virtual TopologyValidationError ValidationError
	{
		get
		{
			method_0(geometry_0);
			return RarejeHjjAt;
		}
	}

	public IsValidOp(Geometry parentGeometry)
	{
		geometry_0 = parentGeometry;
	}

	public static bool IsValidCoordinate(Coordinate coord)
	{
		if (double.IsNaN(coord.X))
		{
			return false;
		}
		if (double.IsInfinity(coord.X))
		{
			return false;
		}
		if (double.IsNaN(coord.Y))
		{
			return false;
		}
		if (double.IsInfinity(coord.Y))
		{
			return false;
		}
		return true;
	}

	public static Coordinate FindPointNotNode(IList<Coordinate> testCoords, ILinearRing searchRing, GeometryGraph graph)
	{
		EdgeIntersectionList edgeIntersectionList = graph.FindEdge(searchRing).EdgeIntersectionList;
		foreach (Coordinate testCoord in testCoords)
		{
			if (!edgeIntersectionList.IsIntersection(testCoord))
			{
				return testCoord;
			}
		}
		return null;
	}

	private void method_0(IGeometry igeometry_0)
	{
		RarejeHjjAt = null;
		if (igeometry_0.IsEmpty)
		{
			return;
		}
		method_1(igeometry_0);
		if (igeometry_0 is ILineString)
		{
			method_2(igeometry_0);
		}
		if (igeometry_0 is ILinearRing ilinearRing_)
		{
			method_3(ilinearRing_);
		}
		if (igeometry_0 is IPolygon ipolygon_)
		{
			method_4(ipolygon_);
		}
		if (!(igeometry_0 is IMultiPolygon imultiPolygon_))
		{
			if (igeometry_0 is GInterface6 ginterface6_)
			{
				method_6(ginterface6_);
			}
		}
		else
		{
			method_5(imultiPolygon_);
		}
	}

	private void method_1(IBasicGeometry ibasicGeometry_0)
	{
		method_7(ibasicGeometry_0.Coordinates);
	}

	private void method_2(IGeometry igeometry_0)
	{
		GeometryGraph geometryGraph_ = new GeometryGraph(0, igeometry_0);
		method_11(geometryGraph_);
	}

	private void method_3(ILinearRing ilinearRing_0)
	{
		method_10(ilinearRing_0);
		if (RarejeHjjAt == null)
		{
			GeometryGraph geometryGraph = new GeometryGraph(0, ilinearRing_0);
			LineIntersector li = new RobustLineIntersector();
			geometryGraph.ComputeSelfNodes(li, computeRingSelfNodes: true);
			method_13(geometryGraph);
		}
	}

	private void method_4(IPolygon ipolygon_0)
	{
		method_9(ipolygon_0);
		if (RarejeHjjAt != null)
		{
			return;
		}
		if (CoordinateArrays.RemoveRepeatedPoints(ipolygon_0.Coordinates).Count >= 3)
		{
			GeometryGraph geometryGraph_ = new GeometryGraph(0, ipolygon_0);
			method_12(geometryGraph_);
			if (RarejeHjjAt != null)
			{
				return;
			}
			if (!IsSelfTouchingRingFormingHoleValid)
			{
				method_13(geometryGraph_);
				if (RarejeHjjAt != null)
				{
					return;
				}
			}
			method_15(ipolygon_0, geometryGraph_);
			if (RarejeHjjAt == null)
			{
				method_16(ipolygon_0, geometryGraph_);
				if (RarejeHjjAt == null)
				{
					method_19(geometryGraph_);
				}
			}
		}
		else
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.TooFewPoints);
		}
	}

	private void method_5(IMultiPolygon imultiPolygon_0)
	{
		IGeometry[] geometries = imultiPolygon_0.Geometries;
		int num = 0;
		while (true)
		{
			if (num < geometries.Length)
			{
				Polygon ipolygon_ = (Polygon)geometries[num];
				method_8(ipolygon_);
				if (RarejeHjjAt == null)
				{
					method_9(ipolygon_);
					if (RarejeHjjAt == null)
					{
						num++;
						continue;
					}
					break;
				}
				break;
			}
			GeometryGraph geometryGraph_ = new GeometryGraph(0, imultiPolygon_0);
			method_11(geometryGraph_);
			if (RarejeHjjAt != null)
			{
				break;
			}
			method_12(geometryGraph_);
			if (RarejeHjjAt != null)
			{
				break;
			}
			if (!IsSelfTouchingRingFormingHoleValid)
			{
				method_13(geometryGraph_);
				if (RarejeHjjAt != null)
				{
					break;
				}
			}
			geometries = imultiPolygon_0.Geometries;
			num = 0;
			while (true)
			{
				if (num < geometries.Length)
				{
					Polygon ipolygon_2 = (Polygon)geometries[num];
					method_15(ipolygon_2, geometryGraph_);
					if (RarejeHjjAt == null)
					{
						num++;
						continue;
					}
					break;
				}
				geometries = imultiPolygon_0.Geometries;
				num = 0;
				while (true)
				{
					if (num < geometries.Length)
					{
						Polygon ipolygon_3 = (Polygon)geometries[num];
						method_16(ipolygon_3, geometryGraph_);
						if (RarejeHjjAt == null)
						{
							num++;
							continue;
						}
						break;
					}
					method_17(imultiPolygon_0, geometryGraph_);
					if (RarejeHjjAt == null)
					{
						method_19(geometryGraph_);
					}
					break;
				}
				break;
			}
			break;
		}
	}

	private void method_6(GInterface6 ginterface6_0)
	{
		IGeometry[] geometries = ginterface6_0.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry igeometry_ = (Geometry)geometries[i];
			method_0(igeometry_);
			if (RarejeHjjAt != null)
			{
				break;
			}
		}
	}

	private void method_7(IEnumerable<Coordinate> ienumerable_0)
	{
		foreach (Coordinate item in ienumerable_0)
		{
			if (!IsValidCoordinate(item))
			{
				RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.InvalidCoordinate, item);
				break;
			}
		}
	}

	private void method_8(IPolygon ipolygon_0)
	{
		method_7(ipolygon_0.Shell.Coordinates);
		if (RarejeHjjAt != null)
		{
			return;
		}
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			method_7(lineString.Coordinates);
			if (RarejeHjjAt != null)
			{
				break;
			}
		}
	}

	private void method_9(IPolygon ipolygon_0)
	{
		method_10(ipolygon_0.Shell);
		if (RarejeHjjAt != null)
		{
			return;
		}
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LineString lineString = (LineString)holes[i];
			method_10((LinearRing)lineString);
			if (RarejeHjjAt != null)
			{
				break;
			}
		}
	}

	private void method_10(ILinearRing ilinearRing_0)
	{
		if (!ilinearRing_0.IsClosed)
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.RingNotClosed, ilinearRing_0.Coordinates[0]);
		}
	}

	private void method_11(GeometryGraph geometryGraph_0)
	{
		if (geometryGraph_0.HasTooFewPoints)
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.TooFewPoints, geometryGraph_0.InvalidPoint);
		}
	}

	private void method_12(GeometryGraph geometryGraph_0)
	{
		ConsistentAreaTester consistentAreaTester = new ConsistentAreaTester(geometryGraph_0);
		if (consistentAreaTester.IsNodeConsistentArea)
		{
			if (consistentAreaTester.HasDuplicateRings)
			{
				RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.DuplicateRings, consistentAreaTester.InvalidPoint);
			}
		}
		else
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.SelfIntersection, consistentAreaTester.InvalidPoint);
		}
	}

	private void method_13(GeometryGraph geometryGraph_0)
	{
		IEnumerator edgeEnumerator = geometryGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge edge = (Edge)edgeEnumerator.Current;
			method_14(edge.EdgeIntersectionList);
			if (RarejeHjjAt != null)
			{
				break;
			}
		}
	}

	private void method_14(EdgeIntersectionList edgeIntersectionList_0)
	{
		HashSet<Coordinate> hashSet = new HashSet<Coordinate>();
		bool flag = true;
		foreach (EdgeIntersection item in edgeIntersectionList_0)
		{
			if (flag)
			{
				flag = false;
				continue;
			}
			if (!hashSet.Contains(item.Coordinate))
			{
				hashSet.Add(item.Coordinate);
				continue;
			}
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.RingSelfIntersection, item.Coordinate);
			break;
		}
	}

	private void method_15(IPolygon ipolygon_0, GeometryGraph geometryGraph_0)
	{
		ILinearRing shell = ipolygon_0.Shell;
		IPointInRing pointInRing = new McPointInRing(shell);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			Coordinate coordinate = FindPointNotNode(((LinearRing)ipolygon_0.GetInteriorRingN(i)).Coordinates, shell, geometryGraph_0);
			if (!(coordinate == null))
			{
				if (!pointInRing.IsInside(coordinate))
				{
					RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.HoleOutsideShell, coordinate);
					break;
				}
				continue;
			}
			break;
		}
	}

	private void method_16(IPolygon ipolygon_0, GeometryGraph geometryGraph_0)
	{
		QuadtreeNestedRingTester quadtreeNestedRingTester = new QuadtreeNestedRingTester(geometryGraph_0);
		ILinearRing[] holes = ipolygon_0.Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			LinearRing ring = (LinearRing)holes[i];
			quadtreeNestedRingTester.Add(ring);
		}
		if (!quadtreeNestedRingTester.IsNonNested())
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.NestedHoles, quadtreeNestedRingTester.NestedPoint);
		}
	}

	private void method_17(IGeometry igeometry_0, GeometryGraph geometryGraph_0)
	{
		for (int i = 0; i < igeometry_0.NumGeometries; i++)
		{
			LinearRing linearRing_ = (LinearRing)((Polygon)igeometry_0.GetGeometryN(i)).ExteriorRing;
			for (int j = 0; j < igeometry_0.NumGeometries; j++)
			{
				if (i != j)
				{
					Polygon polygon_ = (Polygon)igeometry_0.GetGeometryN(j);
					method_18(linearRing_, polygon_, geometryGraph_0);
					if (RarejeHjjAt != null)
					{
						return;
					}
				}
			}
		}
	}

	private void method_18(LinearRing linearRing_0, Polygon polygon_0, GeometryGraph geometryGraph_0)
	{
		IList<Coordinate> coordinates = linearRing_0.Coordinates;
		LinearRing linearRing = (LinearRing)polygon_0.ExteriorRing;
		IList<Coordinate> coordinates2 = linearRing.Coordinates;
		Coordinate coordinate = FindPointNotNode(coordinates, linearRing, geometryGraph_0);
		if (coordinate == null || !CgAlgorithms.IsPointInRing(coordinate, coordinates2))
		{
			return;
		}
		if (polygon_0.NumHoles <= 0)
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.NestedShells, coordinate);
			return;
		}
		Coordinate coordinate2 = null;
		int num = 0;
		while (true)
		{
			if (num < polygon_0.NumHoles)
			{
				LinearRing object_ = (LinearRing)polygon_0.GetInteriorRingN(num);
				coordinate2 = smethod_0(linearRing_0, object_, geometryGraph_0);
				if (!(coordinate2 == null))
				{
					num++;
					continue;
				}
				break;
			}
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.NestedShells, coordinate2);
			break;
		}
	}

	private static Coordinate smethod_0(object object_0, object object_1, GeometryGraph geometryGraph_0)
	{
		IList<Coordinate> coordinates = ((Geometry)object_0).Coordinates;
		IList<Coordinate> coordinates2 = ((Geometry)object_1).Coordinates;
		Coordinate coordinate = FindPointNotNode(coordinates, (ILinearRing)object_1, geometryGraph_0);
		if (coordinate != null && !CgAlgorithms.IsPointInRing(coordinate, coordinates2))
		{
			return coordinate;
		}
		Coordinate coordinate2 = FindPointNotNode(coordinates2, (ILinearRing)object_0, geometryGraph_0);
		if (coordinate2 != null)
		{
			if (CgAlgorithms.IsPointInRing(coordinate2, coordinates))
			{
				return coordinate2;
			}
			return null;
		}
		throw new ShellHoleIdentityException();
	}

	private void method_19(GeometryGraph geometryGraph_0)
	{
		ConnectedInteriorTester connectedInteriorTester = new ConnectedInteriorTester(geometryGraph_0);
		if (!connectedInteriorTester.IsInteriorsConnected())
		{
			RarejeHjjAt = new TopologyValidationError(TopologyValidationErrorType.DisconnectedInteriors, connectedInteriorTester.Coordinate);
		}
	}

	static IsValidOp()
	{
		Class72.smethod_20();
	}
}
