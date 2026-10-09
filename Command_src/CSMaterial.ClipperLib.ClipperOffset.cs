using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public sealed class ClipperOffset
{
	private List<List<IntPoint>> list_0;

	private List<IntPoint> list_1;

	private List<IntPoint> list_2;

	private List<DoublePoint> list_3 = new List<DoublePoint>();

	private double double_0;

	private double double_1;

	private double HfxehcyuxVJ;

	private double double_2;

	private double double_3;

	private double double_4;

	private IntPoint intPoint_0;

	private PolyNode polyNode_0 = new PolyNode();

	[CompilerGenerated]
	private double double_5;

	[CompilerGenerated]
	private double BfBeWeGcmt9;

	public double ArcTolerance
	{
		[CompilerGenerated]
		get
		{
			return double_5;
		}
		[CompilerGenerated]
		set
		{
			double_5 = value;
		}
	}

	public double MiterLimit
	{
		[CompilerGenerated]
		get
		{
			return BfBeWeGcmt9;
		}
		[CompilerGenerated]
		set
		{
			BfBeWeGcmt9 = value;
		}
	}

	public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
	{
		MiterLimit = miterLimit;
		ArcTolerance = arcTolerance;
		intPoint_0.X = -1L;
	}

	public void Clear()
	{
		polyNode_0.Childs.Clear();
		intPoint_0.X = -1L;
	}

	internal static long Round(double value)
	{
		if (!(value < 0.0))
		{
			return (long)(value + 0.5);
		}
		return (long)(value - 0.5);
	}

	public void AddPath(IntPoint[] path, JoinType joinType, EndType endType)
	{
		int num = path.Length - 1;
		if (num < 0)
		{
			return;
		}
		PolyNode polyNode = new PolyNode();
		polyNode.m_jointype = joinType;
		polyNode.m_endtype = endType;
		if (endType == EndType.etClosedLine || endType == EndType.etClosedPolygon)
		{
			while (num > 0 && path[0] == path[num])
			{
				num--;
			}
		}
		polyNode.m_polygon.Capacity = num + 1;
		polyNode.m_polygon.Add(path[0]);
		int num2 = 0;
		int num3 = 0;
		for (int i = 1; i <= num; i++)
		{
			if (polyNode.m_polygon[num2] != path[i])
			{
				num2++;
				polyNode.m_polygon.Add(path[i]);
				if (path[i].Y > polyNode.m_polygon[num3].Y || (path[i].Y == polyNode.m_polygon[num3].Y && path[i].X < polyNode.m_polygon[num3].X))
				{
					num3 = num2;
				}
			}
		}
		if ((endType == EndType.etClosedPolygon && num2 < 2) || (endType != EndType.etClosedPolygon && num2 < 0))
		{
			return;
		}
		polyNode_0.AddChild(polyNode);
		if (endType != EndType.etClosedPolygon)
		{
			return;
		}
		if (intPoint_0.X < 0L)
		{
			intPoint_0 = new IntPoint(0L, num3);
			return;
		}
		IntPoint intPoint = polyNode_0.Childs[(int)intPoint_0.X].m_polygon[(int)intPoint_0.Y];
		if (polyNode.m_polygon[num3].Y > intPoint.Y || (polyNode.m_polygon[num3].Y == intPoint.Y && polyNode.m_polygon[num3].X < intPoint.X))
		{
			intPoint_0 = new IntPoint(polyNode_0.ChildCount - 1, num3);
		}
	}

	public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
	{
		int num = path.Count - 1;
		if (num < 0)
		{
			return;
		}
		PolyNode polyNode = new PolyNode();
		polyNode.m_jointype = joinType;
		polyNode.m_endtype = endType;
		if (endType == EndType.etClosedLine || endType == EndType.etClosedPolygon)
		{
			while (num > 0 && path[0] == path[num])
			{
				num--;
			}
		}
		polyNode.m_polygon.Capacity = num + 1;
		polyNode.m_polygon.Add(path[0]);
		int num2 = 0;
		int num3 = 0;
		for (int i = 1; i <= num; i++)
		{
			if (polyNode.m_polygon[num2] != path[i])
			{
				num2++;
				polyNode.m_polygon.Add(path[i]);
				if (path[i].Y > polyNode.m_polygon[num3].Y || (path[i].Y == polyNode.m_polygon[num3].Y && path[i].X < polyNode.m_polygon[num3].X))
				{
					num3 = num2;
				}
			}
		}
		if ((endType == EndType.etClosedPolygon && num2 < 2) || (endType != EndType.etClosedPolygon && num2 < 0))
		{
			return;
		}
		polyNode_0.AddChild(polyNode);
		if (endType != EndType.etClosedPolygon)
		{
			return;
		}
		if (intPoint_0.X < 0L)
		{
			intPoint_0 = new IntPoint(0L, num3);
			return;
		}
		IntPoint intPoint = polyNode_0.Childs[(int)intPoint_0.X].m_polygon[(int)intPoint_0.Y];
		if (polyNode.m_polygon[num3].Y > intPoint.Y || (polyNode.m_polygon[num3].Y == intPoint.Y && polyNode.m_polygon[num3].X < intPoint.X))
		{
			intPoint_0 = new IntPoint(polyNode_0.ChildCount - 1, num3);
		}
	}

	public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
	{
		foreach (List<IntPoint> path in paths)
		{
			AddPath(path, joinType, endType);
		}
	}

	private void method_0()
	{
		int num;
		if (intPoint_0.X >= 0L)
		{
			if (!Clipper.Orientation(polyNode_0.Childs[(int)intPoint_0.X].m_polygon))
			{
				for (int i = 0; i < polyNode_0.ChildCount; i++)
				{
					PolyNode polyNode = polyNode_0.Childs[i];
					if (polyNode.m_endtype == EndType.etClosedPolygon || (polyNode.m_endtype == EndType.etClosedLine && Clipper.Orientation(polyNode.m_polygon)))
					{
						polyNode.m_polygon.Reverse();
					}
				}
				return;
			}
			num = 0;
		}
		else
		{
			num = 0;
		}
		for (int j = num; j < polyNode_0.ChildCount; j++)
		{
			PolyNode polyNode2 = polyNode_0.Childs[j];
			if (polyNode2.m_endtype == EndType.etClosedLine && !Clipper.Orientation(polyNode2.m_polygon))
			{
				polyNode2.m_polygon.Reverse();
			}
		}
	}

	internal static DoublePoint GetUnitNormal(IntPoint pt1, IntPoint pt2)
	{
		double num = pt2.X - pt1.X;
		double num2 = pt2.Y - pt1.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			return default(DoublePoint);
		}
		double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
		num *= num3;
		num2 *= num3;
		return new DoublePoint(num2, 0.0 - num);
	}

	private void method_1(double double_6)
	{
		list_0 = new List<List<IntPoint>>();
		double_0 = double_6;
		if (ClipperBase.near_zero(double_6))
		{
			list_0.Capacity = polyNode_0.ChildCount;
			for (int i = 0; i < polyNode_0.ChildCount; i++)
			{
				PolyNode polyNode = polyNode_0.Childs[i];
				if (polyNode.m_endtype == EndType.etClosedPolygon)
				{
					list_0.Add(polyNode.m_polygon);
				}
			}
			return;
		}
		if (MiterLimit > 2.0)
		{
			double_3 = 2.0 / (MiterLimit * MiterLimit);
		}
		else
		{
			double_3 = 0.5;
		}
		double num = ((ArcTolerance <= 0.0) ? 0.25 : ((!(ArcTolerance > Math.Abs(double_6) * 0.25)) ? ArcTolerance : (Math.Abs(double_6) * 0.25)));
		double num2 = Math.PI / Math.Acos(1.0 - num / Math.Abs(double_6));
		HfxehcyuxVJ = Math.Sin(Math.PI * 2.0 / num2);
		double_2 = Math.Cos(Math.PI * 2.0 / num2);
		double_4 = num2 / (Math.PI * 2.0);
		if (double_6 < 0.0)
		{
			HfxehcyuxVJ = 0.0 - HfxehcyuxVJ;
		}
		list_0.Capacity = polyNode_0.ChildCount * 2;
		for (int j = 0; j < polyNode_0.ChildCount; j++)
		{
			PolyNode polyNode2 = polyNode_0.Childs[j];
			list_1 = polyNode2.m_polygon;
			int count = list_1.Count;
			if (count == 0 || (double_6 <= 0.0 && (count < 3 || polyNode2.m_endtype != EndType.etClosedPolygon)))
			{
				continue;
			}
			list_2 = new List<IntPoint>();
			if (count == 1)
			{
				if (polyNode2.m_jointype == JoinType.jtRound)
				{
					double num3 = 1.0;
					double num4 = 0.0;
					for (int k = 1; (double)k <= num2; k++)
					{
						list_2.Add(new IntPoint(Round((double)list_1[0].X + num3 * double_6), Round((double)list_1[0].Y + num4 * double_6)));
						double num5 = num3;
						num3 = num3 * double_2 - HfxehcyuxVJ * num4;
						num4 = num5 * HfxehcyuxVJ + num4 * double_2;
					}
				}
				else
				{
					double num6 = -1.0;
					double num7 = -1.0;
					for (int l = 0; l < 4; l++)
					{
						list_2.Add(new IntPoint(Round((double)list_1[0].X + num6 * double_6), Round((double)list_1[0].Y + num7 * double_6)));
						if (num6 < 0.0)
						{
							num6 = 1.0;
						}
						else if (num7 < 0.0)
						{
							num7 = 1.0;
						}
						else
						{
							num6 = -1.0;
						}
					}
				}
				list_0.Add(list_2);
				continue;
			}
			list_3.Clear();
			list_3.Capacity = count;
			for (int m = 0; m < count - 1; m++)
			{
				list_3.Add(GetUnitNormal(list_1[m], list_1[m + 1]));
			}
			if (polyNode2.m_endtype != EndType.etClosedLine && polyNode2.m_endtype != EndType.etClosedPolygon)
			{
				list_3.Add(new DoublePoint(list_3[count - 2]));
			}
			else
			{
				list_3.Add(GetUnitNormal(list_1[count - 1], list_1[0]));
			}
			if (polyNode2.m_endtype != EndType.etClosedPolygon)
			{
				if (polyNode2.m_endtype == EndType.etClosedLine)
				{
					int int_ = count - 1;
					for (int n = 0; n < count; n++)
					{
						method_2(n, ref int_, polyNode2.m_jointype);
					}
					list_0.Add(list_2);
					list_2 = new List<IntPoint>();
					DoublePoint doublePoint = list_3[count - 1];
					for (int num8 = count - 1; num8 > 0; num8--)
					{
						list_3[num8] = new DoublePoint(0.0 - list_3[num8 - 1].X, 0.0 - list_3[num8 - 1].Y);
					}
					list_3[0] = new DoublePoint(0.0 - doublePoint.X, 0.0 - doublePoint.Y);
					int_ = 0;
					for (int num9 = count - 1; num9 >= 0; num9--)
					{
						method_2(num9, ref int_, polyNode2.m_jointype);
					}
					list_0.Add(list_2);
					continue;
				}
				int int_2 = 0;
				for (int num10 = 1; num10 < count - 1; num10++)
				{
					method_2(num10, ref int_2, polyNode2.m_jointype);
				}
				if (polyNode2.m_endtype == EndType.etOpenButt)
				{
					int index = count - 1;
					IntPoint item = new IntPoint(Round((double)list_1[index].X + list_3[index].X * double_6), Round((double)list_1[index].Y + list_3[index].Y * double_6));
					list_2.Add(item);
					item = new IntPoint(Round((double)list_1[index].X - list_3[index].X * double_6), Round((double)list_1[index].Y - list_3[index].Y * double_6));
					list_2.Add(item);
				}
				else
				{
					int num11 = count - 1;
					int_2 = count - 2;
					double_1 = 0.0;
					list_3[num11] = new DoublePoint(0.0 - list_3[num11].X, 0.0 - list_3[num11].Y);
					if (polyNode2.m_endtype == EndType.etOpenSquare)
					{
						DoSquare(num11, int_2);
					}
					else
					{
						DoRound(num11, int_2);
					}
				}
				for (int num12 = count - 1; num12 > 0; num12--)
				{
					list_3[num12] = new DoublePoint(0.0 - list_3[num12 - 1].X, 0.0 - list_3[num12 - 1].Y);
				}
				list_3[0] = new DoublePoint(0.0 - list_3[1].X, 0.0 - list_3[1].Y);
				int_2 = count - 1;
				for (int num13 = int_2 - 1; num13 > 0; num13--)
				{
					method_2(num13, ref int_2, polyNode2.m_jointype);
				}
				if (polyNode2.m_endtype == EndType.etOpenButt)
				{
					IntPoint item = new IntPoint(Round((double)list_1[0].X - list_3[0].X * double_6), Round((double)list_1[0].Y - list_3[0].Y * double_6));
					list_2.Add(item);
					item = new IntPoint(Round((double)list_1[0].X + list_3[0].X * double_6), Round((double)list_1[0].Y + list_3[0].Y * double_6));
					list_2.Add(item);
				}
				else
				{
					int_2 = 1;
					double_1 = 0.0;
					if (polyNode2.m_endtype == EndType.etOpenSquare)
					{
						DoSquare(0, 1);
					}
					else
					{
						DoRound(0, 1);
					}
				}
				list_0.Add(list_2);
			}
			else
			{
				int int_3 = count - 1;
				for (int num14 = 0; num14 < count; num14++)
				{
					method_2(num14, ref int_3, polyNode2.m_jointype);
				}
				list_0.Add(list_2);
			}
		}
	}

	public void Execute(ref List<List<IntPoint>> solution, double delta)
	{
		solution.Clear();
		method_0();
		method_1(delta);
		Clipper clipper = new Clipper();
		clipper.AddPaths(list_0, PolyType.ptSubject, closed: true);
		if (delta > 0.0)
		{
			clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
			return;
		}
		IntRect bounds = ClipperBase.GetBounds(list_0);
		List<IntPoint> list = new List<IntPoint>(4);
		list.Add(new IntPoint(bounds.left - 10L, bounds.bottom + 10L));
		list.Add(new IntPoint(bounds.right + 10L, bounds.bottom + 10L));
		list.Add(new IntPoint(bounds.right + 10L, bounds.top - 10L));
		list.Add(new IntPoint(bounds.left - 10L, bounds.top - 10L));
		clipper.AddPath(list, PolyType.ptSubject, Closed: true);
		clipper.ReverseSolution = true;
		clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
		if (solution.Count > 0)
		{
			solution.RemoveAt(0);
		}
	}

	public void Execute(ref PolyTree solution, double delta)
	{
		solution.Clear();
		method_0();
		method_1(delta);
		Clipper clipper = new Clipper();
		clipper.AddPaths(list_0, PolyType.ptSubject, closed: true);
		if (delta > 0.0)
		{
			clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
			return;
		}
		IntRect bounds = ClipperBase.GetBounds(list_0);
		List<IntPoint> list = new List<IntPoint>(4);
		list.Add(new IntPoint(bounds.left - 10L, bounds.bottom + 10L));
		list.Add(new IntPoint(bounds.right + 10L, bounds.bottom + 10L));
		list.Add(new IntPoint(bounds.right + 10L, bounds.top - 10L));
		list.Add(new IntPoint(bounds.left - 10L, bounds.top - 10L));
		clipper.AddPath(list, PolyType.ptSubject, Closed: true);
		clipper.ReverseSolution = true;
		clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
		if (solution.ChildCount == 1 && solution.Childs[0].ChildCount > 0)
		{
			PolyNode polyNode = solution.Childs[0];
			solution.Childs.Capacity = polyNode.ChildCount;
			solution.Childs[0] = polyNode.Childs[0];
			for (int i = 1; i < polyNode.ChildCount; i++)
			{
				solution.AddChild(polyNode.Childs[i]);
			}
		}
		else
		{
			solution.Clear();
		}
	}

	private void method_2(int int_0, ref int int_1, JoinType joinType_0)
	{
		double_1 = list_3[int_1].X * list_3[int_0].Y - list_3[int_0].X * list_3[int_1].Y;
		if (double_1 < 5E-05 && double_1 > -5E-05)
		{
			return;
		}
		if (double_1 > 1.0)
		{
			double_1 = 1.0;
		}
		else if (double_1 < -1.0)
		{
			double_1 = -1.0;
		}
		if (double_1 * double_0 < 0.0)
		{
			list_2.Add(new IntPoint(Round((double)list_1[int_0].X + list_3[int_1].X * double_0), Round((double)list_1[int_0].Y + list_3[int_1].Y * double_0)));
			list_2.Add(list_1[int_0]);
			list_2.Add(new IntPoint(Round((double)list_1[int_0].X + list_3[int_0].X * double_0), Round((double)list_1[int_0].Y + list_3[int_0].Y * double_0)));
		}
		else
		{
			switch (joinType_0)
			{
			case JoinType.jtSquare:
				DoSquare(int_0, int_1);
				break;
			case JoinType.jtRound:
				DoRound(int_0, int_1);
				break;
			case JoinType.jtMiter:
			{
				double num = 1.0 + (list_3[int_0].X * list_3[int_1].X + list_3[int_0].Y * list_3[int_1].Y);
				if (num >= double_3)
				{
					DoMiter(int_0, int_1, num);
				}
				else
				{
					DoSquare(int_0, int_1);
				}
				break;
			}
			}
		}
		int_1 = int_0;
	}

	internal void DoSquare(int j, int k)
	{
		DoublePoint doublePoint = list_3[k];
		DoublePoint doublePoint2 = list_3[j];
		double num = Math.Tan(Math.Atan2(double_1, doublePoint.X * doublePoint2.X + doublePoint.Y * doublePoint2.Y) / 4.0);
		list_2.Add(new IntPoint(Round((double)list_1[j].X + double_0 * (doublePoint.X - doublePoint.Y * num)), Round((double)list_1[j].Y + double_0 * (doublePoint.Y + doublePoint.X * num))));
		list_2.Add(new IntPoint(Round((double)list_1[j].X + double_0 * (doublePoint2.X + doublePoint2.Y * num)), Round((double)list_1[j].Y + double_0 * (doublePoint2.Y - doublePoint2.X * num))));
	}

	internal void DoMiter(int j, int k, double r)
	{
		double num = double_0 / r;
		list_2.Add(new IntPoint(Round((double)list_1[j].X + (list_3[k].X + list_3[j].X) * num), Round((double)list_1[j].Y + (list_3[k].Y + list_3[j].Y) * num)));
	}

	internal void DoRound(int j, int k)
	{
		double value = Math.Atan2(double_1, list_3[k].X * list_3[j].X + list_3[k].Y * list_3[j].Y);
		int num = (int)Round(double_4 * Math.Abs(value));
		double num2 = list_3[k].X;
		double num3 = list_3[k].Y;
		for (int i = 0; i < num; i++)
		{
			list_2.Add(new IntPoint(Round((double)list_1[j].X + num2 * double_0), Round((double)list_1[j].Y + num3 * double_0)));
			double num4 = num2;
			num2 = num2 * double_2 - HfxehcyuxVJ * num3;
			num3 = num4 * HfxehcyuxVJ + num3 * double_2;
		}
		list_2.Add(new IntPoint(Round((double)list_1[j].X + list_3[j].X * double_0), Round((double)list_1[j].Y + list_3[j].Y * double_0)));
	}

	static ClipperOffset()
	{
		Class72.smethod_20();
	}
}
