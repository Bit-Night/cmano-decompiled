using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Noding;

namespace DotSpatial.Topology.Operation.Buffer;

public class OffsetCurveSetBuilder
{
	private readonly OffsetCurveBuilder offsetCurveBuilder_0;

	private readonly IList ilist_0 = new ArrayList();

	private readonly double double_0;

	private readonly IGeometry igeometry_0;

	public OffsetCurveSetBuilder(IGeometry inputGeom, double distance, OffsetCurveBuilder curveBuilder)
	{
		igeometry_0 = inputGeom;
		double_0 = distance;
		offsetCurveBuilder_0 = curveBuilder;
	}

	public virtual IList GetCurves()
	{
		Add(igeometry_0);
		return ilist_0;
	}

	private void method_0(IEnumerable ienumerable_0, LocationType locationType_0, LocationType locationType_1)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			method_1(enumerator.Current as IList<Coordinate>, locationType_0, locationType_1);
		}
	}

	private void method_1(IList<Coordinate> ilist_1, LocationType locationType_0, LocationType locationType_1)
	{
		if (ilist_1.Count >= 2)
		{
			SegmentString value = new SegmentString(ilist_1, new Label(0, LocationType.Boundary, locationType_0, locationType_1));
			ilist_0.Add(value);
		}
	}

	private void Add(IGeometry g)
	{
		if (g.IsEmpty)
		{
			return;
		}
		if (!(g is Polygon))
		{
			if (g is LineString)
			{
				method_4((LineString)g);
			}
			else if (g is Point)
			{
				method_3((Point)g);
			}
			else if (g is MultiPoint)
			{
				method_2((MultiPoint)g);
			}
			else if (!(g is MultiLineString))
			{
				if (!(g is MultiPolygon))
				{
					if (!(g is GeometryCollection))
					{
						throw new NotSupportedException(g.GetType().FullName);
					}
					method_2((GeometryCollection)g);
				}
				else
				{
					method_2((MultiPolygon)g);
				}
			}
			else
			{
				method_2((MultiLineString)g);
			}
		}
		else
		{
			method_5((Polygon)g);
		}
	}

	private void method_2(GInterface6 ginterface6_0)
	{
		for (int i = 0; i < ginterface6_0.NumGeometries; i++)
		{
			IGeometry geometryN = ginterface6_0.GetGeometryN(i);
			Add(geometryN);
		}
	}

	private void method_3(IPoint ipoint_0)
	{
		if (double_0 > 0.0)
		{
			IList<Coordinate> coordinates = ipoint_0.Coordinates;
			IList lineCurve = offsetCurveBuilder_0.GetLineCurve(coordinates, double_0);
			method_0(lineCurve, LocationType.Exterior, LocationType.Interior);
		}
	}

	private void method_4(ILineString ilineString_0)
	{
		if (!(double_0 <= 0.0))
		{
			IList<Coordinate> inputPts = CoordinateArrays.RemoveRepeatedPoints(ilineString_0.Coordinates);
			IList lineCurve = offsetCurveBuilder_0.GetLineCurve(inputPts, double_0);
			method_0(lineCurve, LocationType.Exterior, LocationType.Interior);
		}
	}

	private void method_5(IPolygon ipolygon_0)
	{
		double double_ = double_0;
		PositionType positionType = PositionType.Left;
		if (double_0 < 0.0)
		{
			double_ = 0.0 - double_0;
			positionType = PositionType.Right;
		}
		IList<Coordinate> ilist_ = CoordinateArrays.RemoveRepeatedPoints(ipolygon_0.Shell.Coordinates);
		if (double_0 < 0.0 && method_7(ilist_, double_0))
		{
			return;
		}
		method_6(ilist_, double_, positionType, LocationType.Exterior, LocationType.Interior);
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			IList<Coordinate> ilist_2 = CoordinateArrays.RemoveRepeatedPoints(((ILinearRing)ipolygon_0.GetInteriorRingN(i)).Coordinates);
			if (!(double_0 > 0.0) || !method_7(ilist_2, 0.0 - double_0))
			{
				method_6(ilist_2, double_, Position.Opposite(positionType), LocationType.Interior, LocationType.Exterior);
			}
		}
	}

	private void method_6(IList<Coordinate> ilist_1, double double_1, PositionType positionType_0, LocationType locationType_0, LocationType locationType_1)
	{
		LocationType locationType_2 = locationType_0;
		LocationType locationType_3 = locationType_1;
		if (CgAlgorithms.IsCounterClockwise(ilist_1))
		{
			locationType_2 = locationType_1;
			locationType_3 = locationType_0;
			positionType_0 = Position.Opposite(positionType_0);
		}
		IList ringCurve = offsetCurveBuilder_0.GetRingCurve(ilist_1, positionType_0, double_1);
		method_0(ringCurve, locationType_2, locationType_3);
	}

	private bool method_7(IList<Coordinate> ilist_1, double double_1)
	{
		if (ilist_1.Count < 4)
		{
			return double_1 < 0.0;
		}
		if (ilist_1.Count == 4)
		{
			return method_8(ilist_1, double_1);
		}
		return new MinimumDiameter(igeometry_0.Factory.CreateLinearRing(ilist_1)).Length < 2.0 * Math.Abs(double_1);
	}

	private bool method_8(IList<Coordinate> ilist_1, double double_1)
	{
		Triangle triangle = new Triangle(ilist_1[0], ilist_1[1], ilist_1[2]);
		return CgAlgorithms.DistancePointLine(triangle.InCentre, triangle.P0, triangle.P1) < Math.Abs(double_1);
	}

	static OffsetCurveSetBuilder()
	{
		Class72.smethod_20();
	}
}
