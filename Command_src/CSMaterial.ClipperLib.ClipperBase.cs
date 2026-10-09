using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public class ClipperBase
{
	protected const double horizontal = -3.4E+38;

	protected const int Skip = -2;

	protected const int Unassigned = -1;

	protected const double tolerance = 1E-20;

	internal const long loRange = 1073741823L;

	internal const long hiRange = 4611686018427387903L;

	internal LocalMinima m_MinimaList;

	internal LocalMinima m_CurrentLM;

	internal List<List<TEdge>> m_edges = new List<List<TEdge>>();

	internal bool m_UseFullRange;

	internal bool m_HasOpenPaths;

	[CompilerGenerated]
	private bool bool_0;

	public bool PreserveCollinear
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	internal static bool near_zero(double val)
	{
		if (val > -1E-20)
		{
			return val < 1E-20;
		}
		return false;
	}

	internal static bool IsHorizontal(TEdge e)
	{
		return e.Delta.Y == 0L;
	}

	internal bool PointIsVertex(IntPoint pt, OutPt pp)
	{
		OutPt outPt = pp;
		do
		{
			if (!(outPt.Pt == pt))
			{
				outPt = outPt.Next;
				continue;
			}
			return true;
		}
		while (outPt != pp);
		return false;
	}

	internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			if ((pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y))
			{
				return true;
			}
			if (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y)
			{
				return Int128.smethod_0(pt.X - linePt1.X, linePt2.Y - linePt1.Y) == Int128.smethod_0(linePt2.X - linePt1.X, pt.Y - linePt1.Y);
			}
			return false;
		}
		if ((pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y))
		{
			return true;
		}
		if (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y)
		{
			return (pt.X - linePt1.X) * (linePt2.Y - linePt1.Y) == (linePt2.X - linePt1.X) * (pt.Y - linePt1.Y);
		}
		return false;
	}

	internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
	{
		OutPt outPt = pp;
		while (!PointOnLineSegment(pt, outPt.Pt, outPt.Next.Pt, UseFullRange))
		{
			outPt = outPt.Next;
			if (outPt == pp)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.smethod_0(e1.Delta.Y, e2.Delta.X) == Int128.smethod_0(e1.Delta.X, e2.Delta.Y);
		}
		return e1.Delta.Y * e2.Delta.X == e1.Delta.X * e2.Delta.Y;
	}

	protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.smethod_0(pt1.Y - pt2.Y, pt2.X - pt3.X) == Int128.smethod_0(pt1.X - pt2.X, pt2.Y - pt3.Y);
		}
		return (pt1.Y - pt2.Y) * (pt2.X - pt3.X) - (pt1.X - pt2.X) * (pt2.Y - pt3.Y) == 0L;
	}

	protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.smethod_0(pt1.Y - pt2.Y, pt3.X - pt4.X) == Int128.smethod_0(pt1.X - pt2.X, pt3.Y - pt4.Y);
		}
		return (pt1.Y - pt2.Y) * (pt3.X - pt4.X) - (pt1.X - pt2.X) * (pt3.Y - pt4.Y) == 0L;
	}

	internal ClipperBase()
	{
		m_MinimaList = null;
		m_CurrentLM = null;
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	public virtual void Clear()
	{
		method_0();
		for (int i = 0; i < m_edges.Count; i++)
		{
			for (int j = 0; j < m_edges[i].Count; j++)
			{
				m_edges[i][j] = null;
			}
			m_edges[i].Clear();
		}
		m_edges.Clear();
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	private void method_0()
	{
		while (m_MinimaList != null)
		{
			LocalMinima next = m_MinimaList.Next;
			m_MinimaList = null;
			m_MinimaList = next;
		}
		m_CurrentLM = null;
	}

	private void method_1(IntPoint intPoint_0, ref bool bool_1)
	{
		if (!bool_1)
		{
			if (intPoint_0.X > 1073741823L || intPoint_0.Y > 1073741823L || -intPoint_0.X > 1073741823L || -intPoint_0.Y > 1073741823L)
			{
				bool_1 = true;
				method_1(intPoint_0, ref bool_1);
			}
		}
		else if (intPoint_0.X > 4611686018427387903L || intPoint_0.Y > 4611686018427387903L || -intPoint_0.X > 4611686018427387903L || -intPoint_0.Y > 4611686018427387903L)
		{
			throw new ClipperException("Coordinate outside allowed range");
		}
	}

	private void method_2(TEdge tedge_0, TEdge tedge_1, TEdge tedge_2, IntPoint intPoint_0)
	{
		tedge_0.Next = tedge_1;
		tedge_0.Prev = tedge_2;
		tedge_0.Curr = intPoint_0;
		tedge_0.OutIdx = -1;
	}

	private void method_3(TEdge tedge_0, PolyType polyType_0)
	{
		if (tedge_0.Curr.Y >= tedge_0.Next.Curr.Y)
		{
			tedge_0.Bot = tedge_0.Curr;
			tedge_0.Top = tedge_0.Next.Curr;
		}
		else
		{
			tedge_0.Top = tedge_0.Curr;
			tedge_0.Bot = tedge_0.Next.Curr;
		}
		method_7(tedge_0);
		tedge_0.PolyTyp = polyType_0;
	}

	private TEdge method_4(TEdge tedge_0)
	{
		while (true)
		{
			if (tedge_0.Bot != tedge_0.Prev.Bot || tedge_0.Curr == tedge_0.Top)
			{
				tedge_0 = tedge_0.Next;
				continue;
			}
			if (tedge_0.Dx != -3.4E+38 && tedge_0.Prev.Dx != -3.4E+38)
			{
				break;
			}
			while (tedge_0.Prev.Dx == -3.4E+38)
			{
				tedge_0 = tedge_0.Prev;
			}
			TEdge tEdge = tedge_0;
			while (tedge_0.Dx == -3.4E+38)
			{
				tedge_0 = tedge_0.Next;
			}
			if (tedge_0.Top.Y == tedge_0.Prev.Bot.Y)
			{
				continue;
			}
			if (tEdge.Prev.Bot.X < tedge_0.Bot.X)
			{
				tedge_0 = tEdge;
			}
			break;
		}
		return tedge_0;
	}

	private TEdge method_5(TEdge tedge_0, bool bool_1)
	{
		TEdge tEdge = tedge_0;
		TEdge tEdge2 = tedge_0;
		if (tedge_0.Dx == -3.4E+38)
		{
			long num = ((!bool_1) ? tedge_0.Next.Bot.X : tedge_0.Prev.Bot.X);
			if (tedge_0.Bot.X != num)
			{
				method_9(tedge_0);
			}
		}
		if (tEdge2.OutIdx != -2)
		{
			if (bool_1)
			{
				while (tEdge2.Top.Y == tEdge2.Next.Bot.Y && tEdge2.Next.OutIdx != -2)
				{
					tEdge2 = tEdge2.Next;
				}
				if (tEdge2.Dx == -3.4E+38 && tEdge2.Next.OutIdx != -2)
				{
					TEdge tEdge3 = tEdge2;
					while (tEdge3.Prev.Dx == -3.4E+38)
					{
						tEdge3 = tEdge3.Prev;
					}
					if (tEdge3.Prev.Top.X == tEdge2.Next.Top.X)
					{
						if (!bool_1)
						{
							tEdge2 = tEdge3.Prev;
						}
					}
					else if (tEdge3.Prev.Top.X > tEdge2.Next.Top.X)
					{
						tEdge2 = tEdge3.Prev;
					}
				}
				while (tedge_0 != tEdge2)
				{
					tedge_0.tedge_0 = tedge_0.Next;
					if (tedge_0.Dx == -3.4E+38 && tedge_0 != tEdge && tedge_0.Bot.X != tedge_0.Prev.Top.X)
					{
						method_9(tedge_0);
					}
					tedge_0 = tedge_0.Next;
				}
				if (tedge_0.Dx == -3.4E+38 && tedge_0 != tEdge && tedge_0.Bot.X != tedge_0.Prev.Top.X)
				{
					method_9(tedge_0);
				}
				tEdge2 = tEdge2.Next;
			}
			else
			{
				while (tEdge2.Top.Y == tEdge2.Prev.Bot.Y && tEdge2.Prev.OutIdx != -2)
				{
					tEdge2 = tEdge2.Prev;
				}
				if (tEdge2.Dx == -3.4E+38 && tEdge2.Prev.OutIdx != -2)
				{
					TEdge tEdge3 = tEdge2;
					while (tEdge3.Next.Dx == -3.4E+38)
					{
						tEdge3 = tEdge3.Next;
					}
					if (tEdge3.Next.Top.X == tEdge2.Prev.Top.X)
					{
						if (!bool_1)
						{
							tEdge2 = tEdge3.Next;
						}
					}
					else if (tEdge3.Next.Top.X > tEdge2.Prev.Top.X)
					{
						tEdge2 = tEdge3.Next;
					}
				}
				while (tedge_0 != tEdge2)
				{
					tedge_0.tedge_0 = tedge_0.Prev;
					if (tedge_0.Dx == -3.4E+38 && tedge_0 != tEdge && tedge_0.Bot.X != tedge_0.Next.Top.X)
					{
						method_9(tedge_0);
					}
					tedge_0 = tedge_0.Prev;
				}
				if (tedge_0.Dx == -3.4E+38 && tedge_0 != tEdge && tedge_0.Bot.X != tedge_0.Next.Top.X)
				{
					method_9(tedge_0);
				}
				tEdge2 = tEdge2.Prev;
			}
		}
		if (tEdge2.OutIdx == -2)
		{
			tedge_0 = tEdge2;
			if (!bool_1)
			{
				while (tedge_0.Top.Y == tedge_0.Prev.Bot.Y)
				{
					tedge_0 = tedge_0.Prev;
				}
				while (tedge_0 != tEdge2 && tedge_0.Dx == -3.4E+38)
				{
					tedge_0 = tedge_0.Next;
				}
			}
			else
			{
				while (tedge_0.Top.Y == tedge_0.Next.Bot.Y)
				{
					tedge_0 = tedge_0.Next;
				}
				while (tedge_0 != tEdge2 && tedge_0.Dx == -3.4E+38)
				{
					tedge_0 = tedge_0.Prev;
				}
			}
			if (tedge_0 == tEdge2)
			{
				tEdge2 = (bool_1 ? tedge_0.Next : tedge_0.Prev);
			}
			else
			{
				tedge_0 = (bool_1 ? tEdge2.Next : tEdge2.Prev);
				LocalMinima localMinima = new LocalMinima();
				localMinima.Next = null;
				localMinima.Y = tedge_0.Bot.Y;
				localMinima.LeftBound = null;
				localMinima.RightBound = tedge_0;
				localMinima.RightBound.WindDelta = 0;
				tEdge2 = method_5(localMinima.RightBound, bool_1);
				method_8(localMinima);
			}
		}
		return tEdge2;
	}

	public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
	{
		if (!Closed)
		{
			throw new ClipperException("AddPath: Open paths have been disabled.");
		}
		int num = pg.Count - 1;
		if (Closed)
		{
			while (num > 0 && pg[num] == pg[0])
			{
				num--;
			}
		}
		while (num > 0 && pg[num] == pg[num - 1])
		{
			num--;
		}
		int result;
		if (Closed && num < 2)
		{
			result = 0;
		}
		else
		{
			if (Closed || num >= 1)
			{
				List<TEdge> list = new List<TEdge>(num + 1);
				for (int i = 0; i <= num; i++)
				{
					list.Add(new TEdge());
				}
				bool flag = true;
				list[1].Curr = pg[1];
				method_1(pg[0], ref m_UseFullRange);
				method_1(pg[num], ref m_UseFullRange);
				method_2(list[0], list[1], list[num], pg[0]);
				method_2(list[num], list[0], list[num - 1], pg[num]);
				for (int num2 = num - 1; num2 >= 1; num2--)
				{
					method_1(pg[num2], ref m_UseFullRange);
					method_2(list[num2], list[num2 + 1], list[num2 - 1], pg[num2]);
				}
				TEdge tEdge = list[0];
				TEdge tEdge2 = tEdge;
				TEdge tEdge3 = tEdge;
				while (true)
				{
					if (!(tEdge2.Curr == tEdge2.Next.Curr))
					{
						if (tEdge2.Prev == tEdge2.Next)
						{
							break;
						}
						if (Closed && SlopesEqual(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr, m_UseFullRange) && (!PreserveCollinear || !Pt2IsBetweenPt1AndPt3(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr)))
						{
							if (tEdge2 == tEdge)
							{
								tEdge = tEdge2.Next;
							}
							tEdge2 = method_6(tEdge2);
							tEdge2 = tEdge2.Prev;
							tEdge3 = tEdge2;
						}
						else
						{
							tEdge2 = tEdge2.Next;
							if (tEdge2 == tEdge3)
							{
								break;
							}
						}
					}
					else
					{
						if (tEdge2 == tEdge2.Next)
						{
							break;
						}
						if (tEdge2 == tEdge)
						{
							tEdge = tEdge2.Next;
						}
						tEdge2 = method_6(tEdge2);
						tEdge3 = tEdge2;
					}
				}
				int result2;
				if (!Closed && tEdge2 == tEdge2.Next)
				{
					result2 = 0;
				}
				else
				{
					if (!Closed || tEdge2.Prev != tEdge2.Next)
					{
						if (!Closed)
						{
							m_HasOpenPaths = true;
							tEdge.Prev.OutIdx = -2;
						}
						tEdge2 = tEdge;
						do
						{
							method_3(tEdge2, polyType);
							tEdge2 = tEdge2.Next;
							if (flag && tEdge2.Curr.Y != tEdge.Curr.Y)
							{
								flag = false;
							}
						}
						while (tEdge2 != tEdge);
						if (flag)
						{
							if (Closed)
							{
								return false;
							}
							tEdge2.Prev.OutIdx = -2;
							if (tEdge2.Prev.Bot.X < tEdge2.Prev.Top.X)
							{
								method_9(tEdge2.Prev);
							}
							LocalMinima localMinima = new LocalMinima();
							localMinima.Next = null;
							localMinima.Y = tEdge2.Bot.Y;
							localMinima.LeftBound = null;
							localMinima.RightBound = tEdge2;
							localMinima.RightBound.Side = EdgeSide.esRight;
							localMinima.RightBound.WindDelta = 0;
							while (tEdge2.Next.OutIdx != -2)
							{
								tEdge2.tedge_0 = tEdge2.Next;
								if (tEdge2.Bot.X != tEdge2.Prev.Top.X)
								{
									method_9(tEdge2);
								}
								tEdge2 = tEdge2.Next;
							}
							method_8(localMinima);
							m_edges.Add(list);
							return true;
						}
						m_edges.Add(list);
						TEdge tEdge4 = null;
						while (true)
						{
							tEdge2 = method_4(tEdge2);
							if (tEdge2 == tEdge4)
							{
								break;
							}
							if (tEdge4 == null)
							{
								tEdge4 = tEdge2;
							}
							LocalMinima localMinima2 = new LocalMinima();
							localMinima2.Next = null;
							localMinima2.Y = tEdge2.Bot.Y;
							bool flag2;
							if (tEdge2.Dx < tEdge2.Prev.Dx)
							{
								localMinima2.LeftBound = tEdge2.Prev;
								localMinima2.RightBound = tEdge2;
								flag2 = false;
							}
							else
							{
								localMinima2.LeftBound = tEdge2;
								localMinima2.RightBound = tEdge2.Prev;
								flag2 = true;
							}
							localMinima2.LeftBound.Side = EdgeSide.esLeft;
							localMinima2.RightBound.Side = EdgeSide.esRight;
							if (Closed)
							{
								if (localMinima2.LeftBound.Next == localMinima2.RightBound)
								{
									localMinima2.LeftBound.WindDelta = -1;
								}
								else
								{
									localMinima2.LeftBound.WindDelta = 1;
								}
							}
							else
							{
								localMinima2.LeftBound.WindDelta = 0;
							}
							localMinima2.RightBound.WindDelta = -localMinima2.LeftBound.WindDelta;
							tEdge2 = method_5(localMinima2.LeftBound, flag2);
							TEdge tEdge5 = method_5(localMinima2.RightBound, !flag2);
							if (localMinima2.LeftBound.OutIdx == -2)
							{
								localMinima2.LeftBound = null;
							}
							else if (localMinima2.RightBound.OutIdx == -2)
							{
								localMinima2.RightBound = null;
							}
							method_8(localMinima2);
							if (!flag2)
							{
								tEdge2 = tEdge5;
							}
						}
						return true;
					}
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
	{
		bool result = false;
		for (int i = 0; i < ppg.Count; i++)
		{
			if (AddPath(ppg[i], polyType, closed))
			{
				result = true;
			}
		}
		return result;
	}

	internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3)
	{
		int result;
		if (pt1 == pt3)
		{
			result = 0;
		}
		else if (pt1 == pt2)
		{
			result = 0;
		}
		else
		{
			if (!(pt3 == pt2))
			{
				if (pt1.X != pt3.X)
				{
					return pt2.X > pt1.X == pt2.X < pt3.X;
				}
				return pt2.Y > pt1.Y == pt2.Y < pt3.Y;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private TEdge method_6(TEdge tedge_0)
	{
		tedge_0.Prev.Next = tedge_0.Next;
		tedge_0.Next.Prev = tedge_0.Prev;
		TEdge next = tedge_0.Next;
		tedge_0.Prev = null;
		return next;
	}

	private void method_7(TEdge tedge_0)
	{
		tedge_0.Delta.X = tedge_0.Top.X - tedge_0.Bot.X;
		tedge_0.Delta.Y = tedge_0.Top.Y - tedge_0.Bot.Y;
		if (tedge_0.Delta.Y == 0L)
		{
			tedge_0.Dx = -3.4E+38;
		}
		else
		{
			tedge_0.Dx = (double)tedge_0.Delta.X / (double)tedge_0.Delta.Y;
		}
	}

	private void method_8(LocalMinima localMinima_0)
	{
		if (m_MinimaList == null)
		{
			m_MinimaList = localMinima_0;
		}
		else if (localMinima_0.Y < m_MinimaList.Y)
		{
			LocalMinima localMinima = m_MinimaList;
			while (localMinima.Next != null && localMinima_0.Y < localMinima.Next.Y)
			{
				localMinima = localMinima.Next;
			}
			localMinima_0.Next = localMinima.Next;
			localMinima.Next = localMinima_0;
		}
		else
		{
			localMinima_0.Next = m_MinimaList;
			m_MinimaList = localMinima_0;
		}
	}

	protected void PopLocalMinima()
	{
		if (m_CurrentLM != null)
		{
			m_CurrentLM = m_CurrentLM.Next;
		}
	}

	private void method_9(TEdge tedge_0)
	{
		long x = tedge_0.Top.X;
		tedge_0.Top.X = tedge_0.Bot.X;
		tedge_0.Bot.X = x;
	}

	protected virtual void Reset()
	{
		m_CurrentLM = m_MinimaList;
		if (m_CurrentLM == null)
		{
			return;
		}
		for (LocalMinima localMinima = m_MinimaList; localMinima != null; localMinima = localMinima.Next)
		{
			TEdge leftBound = localMinima.LeftBound;
			if (leftBound != null)
			{
				leftBound.Curr = leftBound.Bot;
				leftBound.Side = EdgeSide.esLeft;
				leftBound.OutIdx = -1;
			}
			leftBound = localMinima.RightBound;
			if (leftBound != null)
			{
				leftBound.Curr = leftBound.Bot;
				leftBound.Side = EdgeSide.esRight;
				leftBound.OutIdx = -1;
			}
		}
	}

	public static IntRect GetBounds(List<List<IntPoint>> paths)
	{
		int i = 0;
		int count;
		for (count = paths.Count; i < count && paths[i].Count == 0; i++)
		{
		}
		if (i == count)
		{
			return new IntRect(0L, 0L, 0L, 0L);
		}
		IntRect result = default(IntRect);
		result.left = paths[i][0].X;
		result.right = result.left;
		result.top = paths[i][0].Y;
		result.bottom = result.top;
		for (; i < count; i++)
		{
			for (int j = 0; j < paths[i].Count; j++)
			{
				if (paths[i][j].X < result.left)
				{
					result.left = paths[i][j].X;
				}
				else if (paths[i][j].X > result.right)
				{
					result.right = paths[i][j].X;
				}
				if (paths[i][j].Y < result.top)
				{
					result.top = paths[i][j].Y;
				}
				else if (paths[i][j].Y > result.bottom)
				{
					result.bottom = paths[i][j].Y;
				}
			}
		}
		return result;
	}

	static ClipperBase()
	{
		Class72.smethod_20();
	}
}
