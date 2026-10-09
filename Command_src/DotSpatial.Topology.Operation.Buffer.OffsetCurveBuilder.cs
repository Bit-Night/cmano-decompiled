using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Buffer;

public class OffsetCurveBuilder
{
	public const int DEFAULT_QUADRANT_SEGMENTS = 8;

	private readonly double double_0;

	private readonly LineIntersector lineIntersector_0;

	private readonly LineSegment lineSegment_0 = new LineSegment();

	private readonly LineSegment lineSegment_1 = new LineSegment();

	private readonly PrecisionModel precisionModel_0;

	private readonly LineSegment lineSegment_2 = new LineSegment();

	private readonly LineSegment lineSegment_3 = new LineSegment();

	private double double_1;

	private BufferStyle bufferStyle_0 = BufferStyle.CapRound;

	private IList<Coordinate> ilist_0;

	private Coordinate coordinate_0;

	private Coordinate coordinate_1;

	private Coordinate coordinate_2;

	private PositionType positionType_0;

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return bufferStyle_0;
		}
		set
		{
			bufferStyle_0 = value;
		}
	}

	private IList<Coordinate> Coordinates
	{
		get
		{
			if (ilist_0.Count > 1)
			{
				Coordinate coordinate = ilist_0.First();
				Coordinate obj = ilist_0.Last();
				if (!coordinate.Equals(obj))
				{
					method_3(coordinate);
				}
			}
			return ilist_0;
		}
	}

	public OffsetCurveBuilder(PrecisionModel precisionModel)
		: this(precisionModel, 8)
	{
	}

	public OffsetCurveBuilder(PrecisionModel precisionModel, int quadrantSegments)
	{
		precisionModel_0 = precisionModel;
		lineIntersector_0 = new RobustLineIntersector();
		double_0 = Math.PI / 2.0 / (double)((quadrantSegments < 1) ? 1 : quadrantSegments);
	}

	public virtual IList GetLineCurve(IList<Coordinate> inputPts, double distance)
	{
		IList list = new ArrayList();
		if (distance <= 0.0)
		{
			return list;
		}
		method_0(distance);
		if (inputPts.Count <= 1)
		{
			switch (bufferStyle_0)
			{
			case BufferStyle.CapSquare:
				method_12(inputPts[0], distance);
				break;
			case BufferStyle.CapRound:
				method_11(inputPts[0], distance);
				break;
			}
		}
		else
		{
			method_1(inputPts);
		}
		IList<Coordinate> coordinates = Coordinates;
		list.Add(coordinates);
		return list;
	}

	public virtual IList GetRingCurve(IList<Coordinate> inputPts, PositionType side, double distance)
	{
		IList list = new ArrayList();
		method_0(distance);
		if (inputPts.Count <= 2)
		{
			return GetLineCurve(inputPts, distance);
		}
		if (distance == 0.0)
		{
			list.Add(EnumerableExt.CloneList(inputPts));
			return list;
		}
		method_2(inputPts, side);
		list.Add(Coordinates);
		return list;
	}

	private void method_0(double double_2)
	{
		double_1 = double_2;
		ilist_0 = new List<Coordinate>();
	}

	private void method_1(IList<Coordinate> ilist_1)
	{
		int num = ilist_1.Count - 1;
		method_5(ilist_1[0], ilist_1[1], PositionType.Left);
		for (int i = 2; i <= num; i++)
		{
			method_6(ilist_1[i], bool_0: true);
		}
		method_7();
		method_8(ilist_1[num - 1], ilist_1[num]);
		method_5(ilist_1[num], ilist_1[num - 1], PositionType.Left);
		for (int num2 = num - 2; num2 >= 0; num2--)
		{
			method_6(ilist_1[num2], bool_0: true);
		}
		method_7();
		method_8(ilist_1[1], ilist_1[0]);
		method_4();
	}

	private void method_2(IList<Coordinate> ilist_1, PositionType positionType_1)
	{
		int num = ilist_1.Count - 1;
		method_5(ilist_1[num - 1], ilist_1[0], positionType_1);
		for (int i = 1; i <= num; i++)
		{
			bool bool_ = i != 1;
			method_6(ilist_1[i], bool_);
		}
		method_4();
	}

	private void method_3(Coordinate coordinate_3)
	{
		Coordinate coordinate = new Coordinate(coordinate_3);
		precisionModel_0.MakePrecise(coordinate);
		Coordinate coordinate2 = null;
		if (ilist_0.Count >= 1)
		{
			coordinate2 = ilist_0.Last();
		}
		if (!(coordinate2 != null) || !coordinate.Equals(coordinate2))
		{
			ilist_0.Add(coordinate);
		}
	}

	private void method_4()
	{
		if (ilist_0.Count >= 1)
		{
			Coordinate coordinate = new Coordinate(ilist_0[0]);
			Coordinate obj = ilist_0[ilist_0.Count - 1];
			if (!coordinate.Equals(obj))
			{
				ilist_0.Add(coordinate);
			}
		}
	}

	private void method_5(Coordinate coordinate_3, Coordinate coordinate_4, PositionType positionType_1)
	{
		coordinate_1 = coordinate_3;
		coordinate_2 = coordinate_4;
		positionType_0 = positionType_1;
		lineSegment_3.SetCoordinates(coordinate_3, coordinate_4);
		smethod_0(lineSegment_3, positionType_1, double_1, lineSegment_1);
	}

	private void method_6(Coordinate coordinate_3, bool bool_0)
	{
		coordinate_0 = coordinate_1;
		coordinate_1 = coordinate_2;
		coordinate_2 = coordinate_3;
		lineSegment_2.SetCoordinates(coordinate_0, coordinate_1);
		smethod_0(lineSegment_2, positionType_0, double_1, lineSegment_0);
		lineSegment_3.SetCoordinates(coordinate_1, coordinate_2);
		smethod_0(lineSegment_3, positionType_0, double_1, lineSegment_1);
		if (coordinate_1.Equals(coordinate_2))
		{
			return;
		}
		int num = CgAlgorithms.ComputeOrientation(coordinate_0, coordinate_1, coordinate_2);
		bool flag = (num == -1 && positionType_0 == PositionType.Left) || (num == 1 && positionType_0 == PositionType.Right);
		if (num == 0)
		{
			lineIntersector_0.ComputeIntersection(coordinate_0, coordinate_1, coordinate_1, coordinate_2);
			if (lineIntersector_0.IntersectionNum >= 2)
			{
				method_9(coordinate_1, lineSegment_0.P1, lineSegment_1.P0, -1, double_1);
			}
			return;
		}
		if (flag)
		{
			if (bool_0)
			{
				method_3(lineSegment_0.P1);
			}
			method_9(coordinate_1, lineSegment_0.P1, lineSegment_1.P0, num, double_1);
			method_3(lineSegment_1.P0);
			return;
		}
		lineIntersector_0.ComputeIntersection(lineSegment_0.P0, lineSegment_0.P1, lineSegment_1.P0, lineSegment_1.P1);
		if (!lineIntersector_0.HasIntersection)
		{
			if (new Coordinate(lineSegment_0.P1).Distance(lineSegment_1.P0) >= double_1 / 1000.0)
			{
				method_3(lineSegment_0.P1);
				method_3(coordinate_1);
				method_3(lineSegment_1.P0);
			}
			else
			{
				method_3(lineSegment_0.P1);
			}
		}
		else
		{
			method_3(lineIntersector_0.GetIntersection(0));
		}
	}

	private void method_7()
	{
		method_3(lineSegment_1.P1);
	}

	private static void smethod_0(ILineSegmentBase ilineSegmentBase_0, PositionType positionType_1, double double_2, ILineSegmentBase ilineSegmentBase_1)
	{
		int num = ((positionType_1 == PositionType.Left) ? 1 : (-1));
		double num2 = ilineSegmentBase_0.P1.X - ilineSegmentBase_0.P0.X;
		double num3 = ilineSegmentBase_0.P1.Y - ilineSegmentBase_0.P0.Y;
		double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
		double num5 = (double)num * double_2 * num2 / num4;
		double num6 = (double)num * double_2 * num3 / num4;
		ilineSegmentBase_1.P0.X = ilineSegmentBase_0.P0.X - num6;
		ilineSegmentBase_1.P0.Y = ilineSegmentBase_0.P0.Y + num5;
		ilineSegmentBase_1.P1.X = ilineSegmentBase_0.P1.X - num6;
		ilineSegmentBase_1.P1.Y = ilineSegmentBase_0.P1.Y + num5;
	}

	private void method_8(Coordinate coordinate_3, Coordinate coordinate_4)
	{
		LineSegment ilineSegmentBase_ = new LineSegment(coordinate_3, coordinate_4);
		LineSegment lineSegment = new LineSegment();
		smethod_0(ilineSegmentBase_, PositionType.Left, double_1, lineSegment);
		LineSegment lineSegment2 = new LineSegment();
		smethod_0(ilineSegmentBase_, PositionType.Right, double_1, lineSegment2);
		double x = coordinate_4.X - coordinate_3.X;
		double num = Math.Atan2(coordinate_4.Y - coordinate_3.Y, x);
		switch (bufferStyle_0)
		{
		case BufferStyle.CapRound:
			method_3(lineSegment.P1);
			method_10(coordinate_4, num + Math.PI / 2.0, num - Math.PI / 2.0, -1, double_1);
			method_3(lineSegment2.P1);
			break;
		case BufferStyle.CapButt:
			method_3(lineSegment.P1);
			method_3(lineSegment2.P1);
			break;
		case BufferStyle.CapSquare:
		{
			Coordinate coordinate = new Coordinate();
			coordinate.X = Math.Abs(double_1) * Math.Cos(num);
			coordinate.Y = Math.Abs(double_1) * Math.Sin(num);
			Coordinate coordinate_5 = new Coordinate(lineSegment.P1.X + coordinate.X, lineSegment.P1.Y + coordinate.Y);
			Coordinate coordinate_6 = new Coordinate(lineSegment2.P1.X + coordinate.X, lineSegment2.P1.Y + coordinate.Y);
			method_3(coordinate_5);
			method_3(coordinate_6);
			break;
		}
		}
	}

	private void method_9(Coordinate coordinate_3, Coordinate coordinate_4, Coordinate coordinate_5, int int_0, double double_2)
	{
		double x = coordinate_4.X - coordinate_3.X;
		double num = Math.Atan2(coordinate_4.Y - coordinate_3.Y, x);
		double x2 = coordinate_5.X - coordinate_3.X;
		double num2 = Math.Atan2(coordinate_5.Y - coordinate_3.Y, x2);
		if (int_0 == -1)
		{
			if (num <= num2)
			{
				num += Math.PI * 2.0;
			}
		}
		else if (num >= num2)
		{
			num -= Math.PI * 2.0;
		}
		method_3(coordinate_4);
		method_10(coordinate_3, num, num2, int_0, double_2);
		method_3(coordinate_5);
	}

	private void method_10(Coordinate coordinate_3, double double_2, double double_3, int int_0, double double_4)
	{
		int num = ((int_0 != -1) ? 1 : (-1));
		double num2 = Math.Abs(double_2 - double_3);
		int num3 = (int)(num2 / double_0 + 0.5);
		if (num3 >= 1)
		{
			double num4 = num2 / (double)num3;
			double num5 = 0.0;
			Coordinate coordinate = new Coordinate();
			for (; num5 < num2; num5 += num4)
			{
				double num6 = double_2 + (double)num * num5;
				coordinate.X = coordinate_3.X + double_4 * Math.Cos(num6);
				coordinate.Y = coordinate_3.Y + double_4 * Math.Sin(num6);
				method_3(coordinate);
			}
		}
	}

	private void method_11(Coordinate coordinate_3, double double_2)
	{
		Coordinate coordinate_4 = new Coordinate(coordinate_3.X + double_2, coordinate_3.Y);
		method_3(coordinate_4);
		method_10(coordinate_3, 0.0, Math.PI * 2.0, -1, double_2);
	}

	private void method_12(Coordinate coordinate_3, double double_2)
	{
		method_3(new Coordinate(coordinate_3.X + double_2, coordinate_3.Y + double_2));
		method_3(new Coordinate(coordinate_3.X + double_2, coordinate_3.Y - double_2));
		method_3(new Coordinate(coordinate_3.X - double_2, coordinate_3.Y - double_2));
		method_3(new Coordinate(coordinate_3.X - double_2, coordinate_3.Y + double_2));
		method_3(new Coordinate(coordinate_3.X + double_2, coordinate_3.Y + double_2));
	}

	static OffsetCurveBuilder()
	{
		Class72.smethod_20();
	}
}
