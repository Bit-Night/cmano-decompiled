using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public sealed class Clipper : ClipperBase
{
	internal enum NodeType
	{
		ntAny,
		ntOpen,
		ntClosed
	}

	public const int ioReverseSolution = 1;

	public const int ioStrictlySimple = 2;

	public const int ioPreserveCollinear = 4;

	private List<OutRec> wmvehEjyXoO;

	private ClipType clipType_0;

	private Scanbeam scanbeam_0;

	private TEdge tedge_0;

	private TEdge tedge_1;

	private List<IntersectNode> list_0;

	private IComparer<IntersectNode> icomparer_0;

	private bool bool_1;

	private PolyFillType PrqehXfFyLO;

	private PolyFillType polyFillType_0;

	private List<Join> list_1;

	private List<Join> CrmehKfDgAb;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	public bool ReverseSolution
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool StrictlySimple
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public Clipper(int InitOptions = 0)
	{
		scanbeam_0 = null;
		tedge_0 = null;
		tedge_1 = null;
		list_0 = new List<IntersectNode>();
		icomparer_0 = new MyIntersectNodeSort();
		bool_1 = false;
		bool_2 = false;
		wmvehEjyXoO = new List<OutRec>();
		list_1 = new List<Join>();
		CrmehKfDgAb = new List<Join>();
		ReverseSolution = (1 & InitOptions) != 0;
		StrictlySimple = (2 & InitOptions) != 0;
		base.PreserveCollinear = (4 & InitOptions) != 0;
	}

	private void method_10()
	{
		while (scanbeam_0 != null)
		{
			Scanbeam next = scanbeam_0.Next;
			scanbeam_0 = null;
			scanbeam_0 = next;
		}
	}

	protected override void Reset()
	{
		base.Reset();
		scanbeam_0 = null;
		tedge_0 = null;
		tedge_1 = null;
		for (LocalMinima localMinima = m_MinimaList; localMinima != null; localMinima = localMinima.Next)
		{
			method_11(localMinima.Y);
		}
	}

	private void method_11(long long_0)
	{
		if (scanbeam_0 != null)
		{
			if (long_0 > scanbeam_0.Y)
			{
				Scanbeam scanbeam = new Scanbeam();
				scanbeam.Y = long_0;
				scanbeam.Next = scanbeam_0;
				scanbeam_0 = scanbeam;
				return;
			}
			Scanbeam next = scanbeam_0;
			while (next.Next != null && long_0 <= next.Next.Y)
			{
				next = next.Next;
			}
			if (long_0 != next.Y)
			{
				Scanbeam scanbeam2 = new Scanbeam();
				scanbeam2.Y = long_0;
				scanbeam2.Next = next.Next;
				next.Next = scanbeam2;
			}
		}
		else
		{
			scanbeam_0 = new Scanbeam();
			scanbeam_0.Next = null;
			scanbeam_0.Y = long_0;
		}
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (bool_1)
		{
			return false;
		}
		if (m_HasOpenPaths)
		{
			throw new ClipperException("Error: PolyTree struct is need for open path clipping.");
		}
		bool_1 = true;
		solution.Clear();
		polyFillType_0 = subjFillType;
		PrqehXfFyLO = clipFillType;
		clipType_0 = clipType;
		bool_2 = false;
		bool result;
		try
		{
			if (result = method_12())
			{
				method_64(solution);
			}
		}
		finally
		{
			method_14();
			bool_1 = false;
		}
		return result;
	}

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (!bool_1)
		{
			bool_1 = true;
			polyFillType_0 = subjFillType;
			PrqehXfFyLO = clipFillType;
			clipType_0 = clipType;
			bool_2 = true;
			bool result;
			try
			{
				if (result = method_12())
				{
					method_65(polytree);
				}
			}
			finally
			{
				method_14();
				bool_1 = false;
			}
			return result;
		}
		return false;
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution)
	{
		return Execute(clipType, solution, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	public bool Execute(ClipType clipType, PolyTree polytree)
	{
		return Execute(clipType, polytree, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	internal void FixHoleLinkage(OutRec outRec)
	{
		if (outRec.FirstLeft != null && (outRec.IsHole == outRec.FirstLeft.IsHole || outRec.FirstLeft.Pts == null))
		{
			OutRec firstLeft = outRec.FirstLeft;
			while (firstLeft != null && (firstLeft.IsHole == outRec.IsHole || firstLeft.Pts == null))
			{
				firstLeft = firstLeft.FirstLeft;
			}
			outRec.FirstLeft = firstLeft;
		}
	}

	private bool method_12()
	{
		try
		{
			Reset();
			if (m_CurrentLM != null)
			{
				long long_ = method_13();
				int num2;
				while (true)
				{
					method_19(long_);
					CrmehKfDgAb.Clear();
					method_49(bool_5: false);
					if (scanbeam_0 != null)
					{
						long num = method_13();
						if (method_57(long_, num))
						{
							method_62(num);
							long_ = num;
							if (scanbeam_0 == null && m_CurrentLM == null)
							{
								num2 = 0;
								break;
							}
							continue;
						}
						return false;
					}
					num2 = 0;
					break;
				}
				for (int i = num2; i < wmvehEjyXoO.Count; i++)
				{
					OutRec outRec = wmvehEjyXoO[i];
					if (outRec.Pts != null && !outRec.IsOpen && (outRec.IsHole ^ ReverseSolution) == Area(outRec) > 0.0)
					{
						method_44(outRec.Pts);
					}
				}
				method_75();
				for (int j = 0; j < wmvehEjyXoO.Count; j++)
				{
					OutRec outRec2 = wmvehEjyXoO[j];
					if (outRec2.Pts != null && !outRec2.IsOpen)
					{
						method_66(outRec2);
					}
				}
				int result;
				if (!StrictlySimple)
				{
					result = 1;
				}
				else
				{
					RvoehqcEnJb();
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
		finally
		{
			list_1.Clear();
			CrmehKfDgAb.Clear();
		}
	}

	private long method_13()
	{
		long y = scanbeam_0.Y;
		scanbeam_0 = scanbeam_0.Next;
		return y;
	}

	private void method_14()
	{
		for (int i = 0; i < wmvehEjyXoO.Count; i++)
		{
			method_15(i);
		}
		wmvehEjyXoO.Clear();
	}

	private void method_15(int int_0)
	{
		OutRec outRec = wmvehEjyXoO[int_0];
		if (outRec.Pts != null)
		{
			method_16(outRec.Pts);
		}
		outRec = null;
		wmvehEjyXoO[int_0] = null;
	}

	private void method_16(OutPt outPt_0)
	{
		if (outPt_0 != null)
		{
			outPt_0.Prev.Next = null;
			while (outPt_0 != null)
			{
				outPt_0 = outPt_0.Next;
			}
		}
	}

	private void method_17(OutPt outPt_0, OutPt outPt_1, IntPoint intPoint_0)
	{
		Join obj = new Join();
		obj.OutPt1 = outPt_0;
		obj.OutPt2 = outPt_1;
		obj.OffPt = intPoint_0;
		list_1.Add(obj);
	}

	private void method_18(OutPt outPt_0, IntPoint intPoint_0)
	{
		Join obj = new Join();
		obj.OutPt1 = outPt_0;
		obj.OffPt = intPoint_0;
		CrmehKfDgAb.Add(obj);
	}

	private void method_19(long long_0)
	{
		while (m_CurrentLM != null && m_CurrentLM.Y == long_0)
		{
			TEdge leftBound = m_CurrentLM.LeftBound;
			TEdge rightBound = m_CurrentLM.RightBound;
			PopLocalMinima();
			OutPt outPt = null;
			if (leftBound != null)
			{
				if (rightBound == null)
				{
					method_20(leftBound, null);
					method_25(leftBound);
					if (method_24(leftBound))
					{
						outPt = method_33(leftBound, leftBound.Bot);
					}
					method_11(leftBound.Top.Y);
				}
				else
				{
					method_20(leftBound, null);
					method_20(rightBound, leftBound);
					method_25(leftBound);
					rightBound.WindCnt = leftBound.WindCnt;
					rightBound.WindCnt2 = leftBound.WindCnt2;
					if (method_24(leftBound))
					{
						outPt = method_31(leftBound, rightBound, leftBound.Bot);
					}
					method_11(leftBound.Top.Y);
				}
			}
			else
			{
				method_20(rightBound, null);
				method_25(rightBound);
				if (method_24(rightBound))
				{
					outPt = method_33(rightBound, rightBound.Bot);
				}
			}
			if (rightBound != null)
			{
				if (!ClipperBase.IsHorizontal(rightBound))
				{
					method_11(rightBound.Top.Y);
				}
				else
				{
					method_26(rightBound);
				}
			}
			if (leftBound == null || rightBound == null)
			{
				continue;
			}
			if (outPt != null && ClipperBase.IsHorizontal(rightBound) && CrmehKfDgAb.Count > 0 && rightBound.WindDelta != 0)
			{
				for (int i = 0; i < CrmehKfDgAb.Count; i++)
				{
					Join obj = CrmehKfDgAb[i];
					if (method_34(obj.OutPt1.Pt, obj.OffPt, rightBound.Bot, rightBound.Top))
					{
						method_17(obj.OutPt1, outPt, obj.OffPt);
					}
				}
			}
			if (leftBound.OutIdx >= 0 && leftBound.tedge_2 != null && leftBound.tedge_2.Curr.X == leftBound.Bot.X && leftBound.tedge_2.OutIdx >= 0 && ClipperBase.SlopesEqual(leftBound.tedge_2, leftBound, m_UseFullRange) && leftBound.WindDelta != 0 && leftBound.tedge_2.WindDelta != 0)
			{
				OutPt outPt_ = method_33(leftBound.tedge_2, leftBound.Bot);
				method_17(outPt, outPt_, leftBound.Top);
			}
			if (leftBound.tedge_1 == rightBound)
			{
				continue;
			}
			if (rightBound.OutIdx >= 0 && rightBound.tedge_2.OutIdx >= 0 && ClipperBase.SlopesEqual(rightBound.tedge_2, rightBound, m_UseFullRange) && rightBound.WindDelta != 0 && rightBound.tedge_2.WindDelta != 0)
			{
				OutPt outPt_2 = method_33(rightBound.tedge_2, rightBound.Bot);
				method_17(outPt, outPt_2, rightBound.Top);
			}
			TEdge tEdge = leftBound.tedge_1;
			if (tEdge != null)
			{
				while (tEdge != rightBound)
				{
					method_45(rightBound, tEdge, leftBound.Curr);
					tEdge = tEdge.tedge_1;
				}
			}
		}
	}

	private void method_20(TEdge tedge_2, TEdge tedge_3)
	{
		if (tedge_0 != null)
		{
			if (tedge_3 == null && method_21(tedge_0, tedge_2))
			{
				tedge_2.tedge_2 = null;
				tedge_2.tedge_1 = tedge_0;
				tedge_0.tedge_2 = tedge_2;
				tedge_0 = tedge_2;
				return;
			}
			if (tedge_3 == null)
			{
				tedge_3 = tedge_0;
			}
			while (tedge_3.tedge_1 != null && !method_21(tedge_3.tedge_1, tedge_2))
			{
				tedge_3 = tedge_3.tedge_1;
			}
			tedge_2.tedge_1 = tedge_3.tedge_1;
			if (tedge_3.tedge_1 != null)
			{
				tedge_3.tedge_1.tedge_2 = tedge_2;
			}
			tedge_2.tedge_2 = tedge_3;
			tedge_3.tedge_1 = tedge_2;
		}
		else
		{
			tedge_2.tedge_2 = null;
			tedge_2.tedge_1 = null;
			tedge_0 = tedge_2;
		}
	}

	private bool method_21(TEdge tedge_2, TEdge tedge_3)
	{
		if (tedge_3.Curr.X == tedge_2.Curr.X)
		{
			if (tedge_3.Top.Y > tedge_2.Top.Y)
			{
				return tedge_3.Top.X < smethod_3(tedge_2, tedge_3.Top.Y);
			}
			return tedge_2.Top.X > smethod_3(tedge_3, tedge_2.Top.Y);
		}
		return tedge_3.Curr.X < tedge_2.Curr.X;
	}

	private bool method_22(TEdge tedge_2)
	{
		if (tedge_2.PolyTyp != PolyType.ptSubject)
		{
			return PrqehXfFyLO == PolyFillType.pftEvenOdd;
		}
		return polyFillType_0 == PolyFillType.pftEvenOdd;
	}

	private bool method_23(TEdge tedge_2)
	{
		if (tedge_2.PolyTyp != PolyType.ptSubject)
		{
			return polyFillType_0 == PolyFillType.pftEvenOdd;
		}
		return PrqehXfFyLO == PolyFillType.pftEvenOdd;
	}

	private bool method_24(TEdge tedge_2)
	{
		PolyFillType prqehXfFyLO;
		PolyFillType prqehXfFyLO2;
		if (tedge_2.PolyTyp != PolyType.ptSubject)
		{
			prqehXfFyLO = PrqehXfFyLO;
			prqehXfFyLO2 = polyFillType_0;
		}
		else
		{
			prqehXfFyLO = polyFillType_0;
			prqehXfFyLO2 = PrqehXfFyLO;
		}
		switch (prqehXfFyLO)
		{
		default:
			if (tedge_2.WindCnt != -1)
			{
				return false;
			}
			break;
		case PolyFillType.pftEvenOdd:
			if (tedge_2.WindDelta == 0 && tedge_2.WindCnt != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftNonZero:
			if (Math.Abs(tedge_2.WindCnt) != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftPositive:
			if (tedge_2.WindCnt != 1)
			{
				return false;
			}
			break;
		}
		switch (clipType_0)
		{
		default:
			return true;
		case ClipType.ctIntersection:
			switch (prqehXfFyLO2)
			{
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return tedge_2.WindCnt2 != 0;
			default:
				return tedge_2.WindCnt2 < 0;
			case PolyFillType.pftPositive:
				return tedge_2.WindCnt2 > 0;
			}
		case ClipType.ctUnion:
			switch (prqehXfFyLO2)
			{
			default:
				return tedge_2.WindCnt2 >= 0;
			case PolyFillType.pftPositive:
				return tedge_2.WindCnt2 <= 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return tedge_2.WindCnt2 == 0;
			}
		case ClipType.ctDifference:
			if (tedge_2.PolyTyp == PolyType.ptSubject)
			{
				switch (prqehXfFyLO2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return tedge_2.WindCnt2 == 0;
				default:
					return tedge_2.WindCnt2 >= 0;
				case PolyFillType.pftPositive:
					return tedge_2.WindCnt2 <= 0;
				}
			}
			switch (prqehXfFyLO2)
			{
			default:
				return tedge_2.WindCnt2 < 0;
			case PolyFillType.pftPositive:
				return tedge_2.WindCnt2 > 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return tedge_2.WindCnt2 != 0;
			}
		case ClipType.ctXor:
			if (tedge_2.WindDelta != 0)
			{
				return true;
			}
			switch (prqehXfFyLO2)
			{
			default:
				return tedge_2.WindCnt2 >= 0;
			case PolyFillType.pftPositive:
				return tedge_2.WindCnt2 <= 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return tedge_2.WindCnt2 == 0;
			}
		}
	}

	private void method_25(TEdge tedge_2)
	{
		TEdge tedge_3 = tedge_2.tedge_2;
		while (tedge_3 != null && (tedge_3.PolyTyp != tedge_2.PolyTyp || tedge_3.WindDelta == 0))
		{
			tedge_3 = tedge_3.tedge_2;
		}
		if (tedge_3 != null)
		{
			if (tedge_2.WindDelta == 0 && clipType_0 != ClipType.ctUnion)
			{
				tedge_2.WindCnt = 1;
				tedge_2.WindCnt2 = tedge_3.WindCnt2;
				tedge_3 = tedge_3.tedge_1;
			}
			else if (method_22(tedge_2))
			{
				if (tedge_2.WindDelta == 0)
				{
					bool flag = true;
					for (TEdge tedge_4 = tedge_3.tedge_2; tedge_4 != null; tedge_4 = tedge_4.tedge_2)
					{
						if (tedge_4.PolyTyp == tedge_3.PolyTyp && tedge_4.WindDelta != 0)
						{
							flag = !flag;
						}
					}
					tedge_2.WindCnt = ((!flag) ? 1 : 0);
				}
				else
				{
					tedge_2.WindCnt = tedge_2.WindDelta;
				}
				tedge_2.WindCnt2 = tedge_3.WindCnt2;
				tedge_3 = tedge_3.tedge_1;
			}
			else
			{
				if (tedge_3.WindCnt * tedge_3.WindDelta >= 0)
				{
					if (tedge_2.WindDelta != 0)
					{
						if (tedge_3.WindDelta * tedge_2.WindDelta < 0)
						{
							tedge_2.WindCnt = tedge_3.WindCnt;
						}
						else
						{
							tedge_2.WindCnt = tedge_3.WindCnt + tedge_2.WindDelta;
						}
					}
					else
					{
						tedge_2.WindCnt = ((tedge_3.WindCnt < 0) ? (tedge_3.WindCnt - 1) : (tedge_3.WindCnt + 1));
					}
				}
				else if (Math.Abs(tedge_3.WindCnt) <= 1)
				{
					tedge_2.WindCnt = ((tedge_2.WindDelta == 0) ? 1 : tedge_2.WindDelta);
				}
				else if (tedge_3.WindDelta * tedge_2.WindDelta < 0)
				{
					tedge_2.WindCnt = tedge_3.WindCnt;
				}
				else
				{
					tedge_2.WindCnt = tedge_3.WindCnt + tedge_2.WindDelta;
				}
				tedge_2.WindCnt2 = tedge_3.WindCnt2;
				tedge_3 = tedge_3.tedge_1;
			}
		}
		else
		{
			tedge_2.WindCnt = ((tedge_2.WindDelta == 0) ? 1 : tedge_2.WindDelta);
			tedge_2.WindCnt2 = 0;
			tedge_3 = tedge_0;
		}
		if (!method_23(tedge_2))
		{
			while (tedge_3 != tedge_2)
			{
				tedge_2.WindCnt2 += tedge_3.WindDelta;
				tedge_3 = tedge_3.tedge_1;
			}
			return;
		}
		while (tedge_3 != tedge_2)
		{
			if (tedge_3.WindDelta != 0)
			{
				tedge_2.WindCnt2 = ((tedge_2.WindCnt2 == 0) ? 1 : 0);
			}
			tedge_3 = tedge_3.tedge_1;
		}
	}

	private void method_26(TEdge tedge_2)
	{
		if (tedge_1 == null)
		{
			tedge_1 = tedge_2;
			tedge_2.tedge_4 = null;
			tedge_2.tedge_3 = null;
		}
		else
		{
			tedge_2.tedge_3 = tedge_1;
			tedge_2.tedge_4 = null;
			tedge_1.tedge_4 = tedge_2;
			tedge_1 = tedge_2;
		}
	}

	private void method_27()
	{
		for (TEdge tEdge = (tedge_1 = tedge_0); tEdge != null; tEdge = tEdge.tedge_1)
		{
			tEdge.tedge_4 = tEdge.tedge_2;
			tEdge.tedge_3 = tEdge.tedge_1;
		}
	}

	private void method_28(TEdge tedge_2, TEdge tedge_3)
	{
		if (tedge_2.tedge_1 == tedge_2.tedge_2 || tedge_3.tedge_1 == tedge_3.tedge_2)
		{
			return;
		}
		if (tedge_2.tedge_1 == tedge_3)
		{
			TEdge tEdge = tedge_3.tedge_1;
			if (tEdge != null)
			{
				tEdge.tedge_2 = tedge_2;
			}
			TEdge tedge_4 = tedge_2.tedge_2;
			if (tedge_4 != null)
			{
				tedge_4.tedge_1 = tedge_3;
			}
			tedge_3.tedge_2 = tedge_4;
			tedge_3.tedge_1 = tedge_2;
			tedge_2.tedge_2 = tedge_3;
			tedge_2.tedge_1 = tEdge;
		}
		else if (tedge_3.tedge_1 == tedge_2)
		{
			TEdge tEdge2 = tedge_2.tedge_1;
			if (tEdge2 != null)
			{
				tEdge2.tedge_2 = tedge_3;
			}
			TEdge tedge_5 = tedge_3.tedge_2;
			if (tedge_5 != null)
			{
				tedge_5.tedge_1 = tedge_2;
			}
			tedge_2.tedge_2 = tedge_5;
			tedge_2.tedge_1 = tedge_3;
			tedge_3.tedge_2 = tedge_2;
			tedge_3.tedge_1 = tEdge2;
		}
		else
		{
			TEdge tEdge3 = tedge_2.tedge_1;
			TEdge tedge_6 = tedge_2.tedge_2;
			tedge_2.tedge_1 = tedge_3.tedge_1;
			if (tedge_2.tedge_1 != null)
			{
				tedge_2.tedge_1.tedge_2 = tedge_2;
			}
			tedge_2.tedge_2 = tedge_3.tedge_2;
			if (tedge_2.tedge_2 != null)
			{
				tedge_2.tedge_2.tedge_1 = tedge_2;
			}
			tedge_3.tedge_1 = tEdge3;
			if (tedge_3.tedge_1 != null)
			{
				tedge_3.tedge_1.tedge_2 = tedge_3;
			}
			tedge_3.tedge_2 = tedge_6;
			if (tedge_3.tedge_2 != null)
			{
				tedge_3.tedge_2.tedge_1 = tedge_3;
			}
		}
		if (tedge_2.tedge_2 == null)
		{
			tedge_0 = tedge_2;
		}
		else if (tedge_3.tedge_2 == null)
		{
			tedge_0 = tedge_3;
		}
	}

	private void method_29(TEdge tedge_2, TEdge tedge_3)
	{
		if ((tedge_2.tedge_3 == null && tedge_2.tedge_4 == null) || (tedge_3.tedge_3 == null && tedge_3.tedge_4 == null))
		{
			return;
		}
		if (tedge_2.tedge_3 == tedge_3)
		{
			TEdge tedge_4 = tedge_3.tedge_3;
			if (tedge_4 != null)
			{
				tedge_4.tedge_4 = tedge_2;
			}
			TEdge tedge_5 = tedge_2.tedge_4;
			if (tedge_5 != null)
			{
				tedge_5.tedge_3 = tedge_3;
			}
			tedge_3.tedge_4 = tedge_5;
			tedge_3.tedge_3 = tedge_2;
			tedge_2.tedge_4 = tedge_3;
			tedge_2.tedge_3 = tedge_4;
		}
		else if (tedge_3.tedge_3 == tedge_2)
		{
			TEdge tedge_6 = tedge_2.tedge_3;
			if (tedge_6 != null)
			{
				tedge_6.tedge_4 = tedge_3;
			}
			TEdge tedge_7 = tedge_3.tedge_4;
			if (tedge_7 != null)
			{
				tedge_7.tedge_3 = tedge_2;
			}
			tedge_2.tedge_4 = tedge_7;
			tedge_2.tedge_3 = tedge_3;
			tedge_3.tedge_4 = tedge_2;
			tedge_3.tedge_3 = tedge_6;
		}
		else
		{
			TEdge tedge_8 = tedge_2.tedge_3;
			TEdge tedge_9 = tedge_2.tedge_4;
			tedge_2.tedge_3 = tedge_3.tedge_3;
			if (tedge_2.tedge_3 != null)
			{
				tedge_2.tedge_3.tedge_4 = tedge_2;
			}
			tedge_2.tedge_4 = tedge_3.tedge_4;
			if (tedge_2.tedge_4 != null)
			{
				tedge_2.tedge_4.tedge_3 = tedge_2;
			}
			tedge_3.tedge_3 = tedge_8;
			if (tedge_3.tedge_3 != null)
			{
				tedge_3.tedge_3.tedge_4 = tedge_3;
			}
			tedge_3.tedge_4 = tedge_9;
			if (tedge_3.tedge_4 != null)
			{
				tedge_3.tedge_4.tedge_3 = tedge_3;
			}
		}
		if (tedge_2.tedge_4 == null)
		{
			tedge_1 = tedge_2;
		}
		else if (tedge_3.tedge_4 == null)
		{
			tedge_1 = tedge_3;
		}
	}

	private void method_30(TEdge tedge_2, TEdge tedge_3, IntPoint intPoint_0)
	{
		method_33(tedge_2, intPoint_0);
		if (tedge_3.WindDelta == 0)
		{
			method_33(tedge_3, intPoint_0);
		}
		if (tedge_2.OutIdx == tedge_3.OutIdx)
		{
			tedge_2.OutIdx = -1;
			tedge_3.OutIdx = -1;
		}
		else if (tedge_2.OutIdx >= tedge_3.OutIdx)
		{
			method_43(tedge_3, tedge_2);
		}
		else
		{
			method_43(tedge_2, tedge_3);
		}
	}

	private OutPt method_31(TEdge tedge_2, TEdge tedge_3, IntPoint intPoint_0)
	{
		OutPt outPt;
		TEdge tEdge;
		TEdge tEdge2;
		if (!ClipperBase.IsHorizontal(tedge_3) && tedge_2.Dx <= tedge_3.Dx)
		{
			outPt = method_33(tedge_3, intPoint_0);
			tedge_2.OutIdx = tedge_3.OutIdx;
			tedge_2.Side = EdgeSide.esRight;
			tedge_3.Side = EdgeSide.esLeft;
			tEdge = tedge_3;
			tEdge2 = ((tEdge.tedge_2 != tedge_2) ? tEdge.tedge_2 : tedge_2.tedge_2);
		}
		else
		{
			outPt = method_33(tedge_2, intPoint_0);
			tedge_3.OutIdx = tedge_2.OutIdx;
			tedge_2.Side = EdgeSide.esLeft;
			tedge_3.Side = EdgeSide.esRight;
			tEdge = tedge_2;
			tEdge2 = ((tEdge.tedge_2 != tedge_3) ? tEdge.tedge_2 : tedge_3.tedge_2);
		}
		if (tEdge2 != null && tEdge2.OutIdx >= 0 && smethod_3(tEdge2, intPoint_0.Y) == smethod_3(tEdge, intPoint_0.Y) && ClipperBase.SlopesEqual(tEdge, tEdge2, m_UseFullRange) && tEdge.WindDelta != 0 && tEdge2.WindDelta != 0)
		{
			OutPt outPt_ = method_33(tEdge2, intPoint_0);
			method_17(outPt, outPt_, tEdge.Top);
		}
		return outPt;
	}

	private OutRec method_32()
	{
		OutRec outRec = new OutRec();
		outRec.Idx = -1;
		outRec.IsHole = false;
		outRec.IsOpen = false;
		outRec.FirstLeft = null;
		outRec.Pts = null;
		outRec.BottomPt = null;
		outRec.PolyNode = null;
		wmvehEjyXoO.Add(outRec);
		outRec.Idx = wmvehEjyXoO.Count - 1;
		return outRec;
	}

	private OutPt method_33(TEdge tedge_2, IntPoint intPoint_0)
	{
		bool flag = tedge_2.Side == EdgeSide.esLeft;
		if (tedge_2.OutIdx >= 0)
		{
			OutRec outRec = wmvehEjyXoO[tedge_2.OutIdx];
			OutPt pts = outRec.Pts;
			if (flag && intPoint_0 == pts.Pt)
			{
				return pts;
			}
			if (!flag && intPoint_0 == pts.Prev.Pt)
			{
				return pts.Prev;
			}
			OutPt outPt = new OutPt();
			outPt.Idx = outRec.Idx;
			outPt.Pt = intPoint_0;
			outPt.Next = pts;
			outPt.Prev = pts.Prev;
			outPt.Prev.Next = outPt;
			pts.Prev = outPt;
			if (flag)
			{
				outRec.Pts = outPt;
			}
			return outPt;
		}
		OutRec outRec2 = method_32();
		outRec2.IsOpen = tedge_2.WindDelta == 0;
		OutPt outPt2 = (outRec2.Pts = new OutPt());
		outPt2.Idx = outRec2.Idx;
		outPt2.Pt = intPoint_0;
		outPt2.Next = outPt2;
		outPt2.Prev = outPt2;
		if (!outRec2.IsOpen)
		{
			method_36(tedge_2, outRec2);
		}
		tedge_2.OutIdx = outRec2.Idx;
		return outPt2;
	}

	internal void SwapPoints(ref IntPoint pt1, ref IntPoint pt2)
	{
		IntPoint intPoint = new IntPoint(pt1);
		pt1 = pt2;
		pt2 = intPoint;
	}

	private bool method_34(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, IntPoint intPoint_3)
	{
		if (intPoint_0.X > intPoint_2.X == intPoint_0.X < intPoint_3.X)
		{
			return true;
		}
		if (intPoint_1.X > intPoint_2.X == intPoint_1.X < intPoint_3.X)
		{
			return true;
		}
		if (intPoint_2.X > intPoint_0.X == intPoint_2.X < intPoint_1.X)
		{
			return true;
		}
		if (intPoint_3.X > intPoint_0.X == intPoint_3.X < intPoint_1.X)
		{
			return true;
		}
		if (intPoint_0.X == intPoint_2.X && intPoint_1.X == intPoint_3.X)
		{
			return true;
		}
		if (intPoint_0.X == intPoint_3.X && intPoint_1.X == intPoint_2.X)
		{
			return true;
		}
		return false;
	}

	private OutPt method_35(OutPt outPt_0, OutPt outPt_1, IntPoint intPoint_0)
	{
		OutPt outPt = new OutPt();
		outPt.Pt = intPoint_0;
		if (outPt_1 == outPt_0.Next)
		{
			outPt_0.Next = outPt;
			outPt_1.Prev = outPt;
			outPt.Next = outPt_1;
			outPt.Prev = outPt_0;
		}
		else
		{
			outPt_1.Next = outPt;
			outPt_0.Prev = outPt;
			outPt.Next = outPt_0;
			outPt.Prev = outPt_1;
		}
		return outPt;
	}

	private void method_36(TEdge tedge_2, OutRec outRec_0)
	{
		bool flag = false;
		for (TEdge tedge_3 = tedge_2.tedge_2; tedge_3 != null; tedge_3 = tedge_3.tedge_2)
		{
			if (tedge_3.OutIdx >= 0 && tedge_3.WindDelta != 0)
			{
				flag = !flag;
				if (outRec_0.FirstLeft == null)
				{
					outRec_0.FirstLeft = wmvehEjyXoO[tedge_3.OutIdx];
				}
			}
		}
		if (flag)
		{
			outRec_0.IsHole = true;
		}
	}

	private double method_37(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		if (intPoint_0.Y == intPoint_1.Y)
		{
			return -3.4E+38;
		}
		return (double)(intPoint_1.X - intPoint_0.X) / (double)(intPoint_1.Y - intPoint_0.Y);
	}

	private bool method_38(OutPt outPt_0, OutPt outPt_1)
	{
		OutPt prev = outPt_0.Prev;
		while (prev.Pt == outPt_0.Pt && prev != outPt_0)
		{
			prev = prev.Prev;
		}
		double num = Math.Abs(method_37(outPt_0.Pt, prev.Pt));
		prev = outPt_0.Next;
		while (prev.Pt == outPt_0.Pt && prev != outPt_0)
		{
			prev = prev.Next;
		}
		double num2 = Math.Abs(method_37(outPt_0.Pt, prev.Pt));
		prev = outPt_1.Prev;
		while (prev.Pt == outPt_1.Pt && prev != outPt_1)
		{
			prev = prev.Prev;
		}
		double num3 = Math.Abs(method_37(outPt_1.Pt, prev.Pt));
		prev = outPt_1.Next;
		while (prev.Pt == outPt_1.Pt && prev != outPt_1)
		{
			prev = prev.Next;
		}
		double num4 = Math.Abs(method_37(outPt_1.Pt, prev.Pt));
		if (num >= num3 && !(num < num4))
		{
			return true;
		}
		if (num2 >= num3)
		{
			return num2 >= num4;
		}
		return false;
	}

	private OutPt method_39(OutPt outPt_0)
	{
		OutPt outPt = null;
		OutPt next;
		for (next = outPt_0.Next; next != outPt_0; next = next.Next)
		{
			if (next.Pt.Y <= outPt_0.Pt.Y)
			{
				if (next.Pt.Y == outPt_0.Pt.Y && next.Pt.X <= outPt_0.Pt.X)
				{
					if (next.Pt.X >= outPt_0.Pt.X)
					{
						if (next.Next != outPt_0 && next.Prev != outPt_0)
						{
							outPt = next;
						}
					}
					else
					{
						outPt = null;
						outPt_0 = next;
					}
				}
			}
			else
			{
				outPt_0 = next;
				outPt = null;
			}
		}
		if (outPt != null)
		{
			while (outPt != next)
			{
				if (!method_38(next, outPt))
				{
					outPt_0 = outPt;
				}
				outPt = outPt.Next;
				while (outPt.Pt != outPt_0.Pt)
				{
					outPt = outPt.Next;
				}
			}
		}
		return outPt_0;
	}

	private OutRec method_40(OutRec outRec_0, OutRec outRec_1)
	{
		if (outRec_0.BottomPt == null)
		{
			outRec_0.BottomPt = method_39(outRec_0.Pts);
		}
		if (outRec_1.BottomPt == null)
		{
			outRec_1.BottomPt = method_39(outRec_1.Pts);
		}
		OutPt bottomPt = outRec_0.BottomPt;
		OutPt bottomPt2 = outRec_1.BottomPt;
		if (bottomPt.Pt.Y > bottomPt2.Pt.Y)
		{
			return outRec_0;
		}
		if (bottomPt.Pt.Y < bottomPt2.Pt.Y)
		{
			return outRec_1;
		}
		if (bottomPt.Pt.X < bottomPt2.Pt.X)
		{
			return outRec_0;
		}
		if (bottomPt.Pt.X <= bottomPt2.Pt.X)
		{
			if (bottomPt.Next == bottomPt)
			{
				return outRec_1;
			}
			if (bottomPt2.Next == bottomPt2)
			{
				return outRec_0;
			}
			if (method_38(bottomPt, bottomPt2))
			{
				return outRec_0;
			}
			return outRec_1;
		}
		return outRec_1;
	}

	private bool method_41(OutRec outRec_0, OutRec outRec_1)
	{
		do
		{
			outRec_0 = outRec_0.FirstLeft;
			if (outRec_0 == outRec_1)
			{
				return true;
			}
		}
		while (outRec_0 != null);
		return false;
	}

	private OutRec method_42(int int_0)
	{
		OutRec outRec;
		for (outRec = wmvehEjyXoO[int_0]; outRec != wmvehEjyXoO[outRec.Idx]; outRec = wmvehEjyXoO[outRec.Idx])
		{
		}
		return outRec;
	}

	private void method_43(TEdge tedge_2, TEdge tedge_3)
	{
		OutRec outRec = wmvehEjyXoO[tedge_2.OutIdx];
		OutRec outRec2 = wmvehEjyXoO[tedge_3.OutIdx];
		OutRec outRec3 = (method_41(outRec, outRec2) ? outRec2 : ((!method_41(outRec2, outRec)) ? method_40(outRec, outRec2) : outRec));
		OutPt pts = outRec.Pts;
		OutPt prev = pts.Prev;
		OutPt pts2 = outRec2.Pts;
		OutPt prev2 = pts2.Prev;
		EdgeSide side;
		if (tedge_2.Side != EdgeSide.esLeft)
		{
			int num;
			if (tedge_3.Side == EdgeSide.esRight)
			{
				method_44(pts2);
				prev.Next = prev2;
				prev2.Prev = prev;
				pts2.Next = pts;
				pts.Prev = pts2;
				num = 1;
			}
			else
			{
				prev.Next = pts2;
				pts2.Prev = prev;
				pts.Prev = prev2;
				prev2.Next = pts;
				num = 1;
			}
			side = (EdgeSide)num;
		}
		else
		{
			int num2;
			if (tedge_3.Side == EdgeSide.esLeft)
			{
				method_44(pts2);
				pts2.Next = pts;
				pts.Prev = pts2;
				prev.Next = prev2;
				prev2.Prev = prev;
				outRec.Pts = prev2;
				num2 = 0;
			}
			else
			{
				prev2.Next = pts;
				pts.Prev = prev2;
				pts2.Prev = prev;
				prev.Next = pts2;
				outRec.Pts = pts2;
				num2 = 0;
			}
			side = (EdgeSide)num2;
		}
		outRec.BottomPt = null;
		if (outRec3 == outRec2)
		{
			if (outRec2.FirstLeft != outRec)
			{
				outRec.FirstLeft = outRec2.FirstLeft;
			}
			outRec.IsHole = outRec2.IsHole;
		}
		outRec2.Pts = null;
		outRec2.BottomPt = null;
		outRec2.FirstLeft = outRec;
		int outIdx = tedge_2.OutIdx;
		int outIdx2 = tedge_3.OutIdx;
		tedge_2.OutIdx = -1;
		tedge_3.OutIdx = -1;
		TEdge tEdge = tedge_0;
		while (tEdge != null)
		{
			if (tEdge.OutIdx != outIdx2)
			{
				tEdge = tEdge.tedge_1;
				continue;
			}
			tEdge.OutIdx = outIdx;
			tEdge.Side = side;
			break;
		}
		outRec2.Idx = outRec.Idx;
	}

	private void method_44(OutPt outPt_0)
	{
		if (outPt_0 != null)
		{
			OutPt outPt = outPt_0;
			do
			{
				OutPt next = outPt.Next;
				outPt.Next = outPt.Prev;
				outPt.Prev = next;
				outPt = next;
			}
			while (outPt != outPt_0);
		}
	}

	private static void smethod_0(TEdge tedge_2, TEdge tedge_3)
	{
		EdgeSide side = tedge_2.Side;
		tedge_2.Side = tedge_3.Side;
		tedge_3.Side = side;
	}

	private static void smethod_1(TEdge tedge_2, TEdge tedge_3)
	{
		int outIdx = tedge_2.OutIdx;
		tedge_2.OutIdx = tedge_3.OutIdx;
		tedge_3.OutIdx = outIdx;
	}

	private void method_45(TEdge tedge_2, TEdge tedge_3, IntPoint intPoint_0, bool bool_5 = false)
	{
		if (bool_5)
		{
			goto IL_0037;
		}
		int num;
		if (tedge_2.tedge_0 != null)
		{
			num = 0;
		}
		else
		{
			if (tedge_2.Top.X != intPoint_0.X)
			{
				goto IL_0037;
			}
			num = ((tedge_2.Top.Y == intPoint_0.Y) ? 1 : 0);
		}
		goto IL_0038;
		IL_0037:
		num = 0;
		goto IL_0038;
		IL_0038:
		bool flag = (byte)num != 0;
		bool flag2 = !bool_5 && tedge_3.tedge_0 == null && tedge_3.Top.X == intPoint_0.X && tedge_3.Top.Y == intPoint_0.Y;
		bool flag3 = tedge_2.OutIdx >= 0;
		bool flag4 = tedge_3.OutIdx >= 0;
		if (tedge_2.PolyTyp == tedge_3.PolyTyp)
		{
			if (!method_22(tedge_2))
			{
				if (tedge_2.WindCnt + tedge_3.WindDelta == 0)
				{
					tedge_2.WindCnt = -tedge_2.WindCnt;
				}
				else
				{
					tedge_2.WindCnt += tedge_3.WindDelta;
				}
				if (tedge_3.WindCnt - tedge_2.WindDelta == 0)
				{
					tedge_3.WindCnt = -tedge_3.WindCnt;
				}
				else
				{
					tedge_3.WindCnt -= tedge_2.WindDelta;
				}
			}
			else
			{
				int windCnt = tedge_2.WindCnt;
				tedge_2.WindCnt = tedge_3.WindCnt;
				tedge_3.WindCnt = windCnt;
			}
		}
		else
		{
			if (!method_22(tedge_3))
			{
				tedge_2.WindCnt2 += tedge_3.WindDelta;
			}
			else
			{
				tedge_2.WindCnt2 = ((tedge_2.WindCnt2 == 0) ? 1 : 0);
			}
			if (method_22(tedge_2))
			{
				tedge_3.WindCnt2 = ((tedge_3.WindCnt2 == 0) ? 1 : 0);
			}
			else
			{
				tedge_3.WindCnt2 -= tedge_2.WindDelta;
			}
		}
		PolyFillType prqehXfFyLO;
		PolyFillType prqehXfFyLO2;
		if (tedge_2.PolyTyp != PolyType.ptSubject)
		{
			prqehXfFyLO = PrqehXfFyLO;
			prqehXfFyLO2 = polyFillType_0;
		}
		else
		{
			prqehXfFyLO = polyFillType_0;
			prqehXfFyLO2 = PrqehXfFyLO;
		}
		PolyFillType prqehXfFyLO3;
		PolyFillType prqehXfFyLO4;
		if (tedge_3.PolyTyp == PolyType.ptSubject)
		{
			prqehXfFyLO3 = polyFillType_0;
			prqehXfFyLO4 = PrqehXfFyLO;
		}
		else
		{
			prqehXfFyLO3 = PrqehXfFyLO;
			prqehXfFyLO4 = polyFillType_0;
		}
		int num2 = prqehXfFyLO switch
		{
			PolyFillType.pftNegative => -tedge_2.WindCnt, 
			PolyFillType.pftPositive => tedge_2.WindCnt, 
			_ => Math.Abs(tedge_2.WindCnt), 
		};
		int num3 = prqehXfFyLO3 switch
		{
			PolyFillType.pftNegative => -tedge_3.WindCnt, 
			PolyFillType.pftPositive => tedge_3.WindCnt, 
			_ => Math.Abs(tedge_3.WindCnt), 
		};
		if (!(flag3 && flag4))
		{
			if (flag3)
			{
				if (num3 == 0 || num3 == 1)
				{
					method_33(tedge_2, intPoint_0);
					smethod_0(tedge_2, tedge_3);
					smethod_1(tedge_2, tedge_3);
				}
			}
			else if (flag4)
			{
				if (num2 == 0 || num2 == 1)
				{
					method_33(tedge_3, intPoint_0);
					smethod_0(tedge_2, tedge_3);
					smethod_1(tedge_2, tedge_3);
				}
			}
			else if ((num2 == 0 || num2 == 1) && (num3 == 0 || num3 == 1) && !flag && !flag2)
			{
				long num4 = prqehXfFyLO2 switch
				{
					PolyFillType.pftNegative => -tedge_2.WindCnt2, 
					PolyFillType.pftPositive => tedge_2.WindCnt2, 
					_ => Math.Abs(tedge_2.WindCnt2), 
				};
				long num5 = prqehXfFyLO4 switch
				{
					PolyFillType.pftNegative => -tedge_3.WindCnt2, 
					PolyFillType.pftPositive => tedge_3.WindCnt2, 
					_ => Math.Abs(tedge_3.WindCnt2), 
				};
				if (tedge_2.PolyTyp != tedge_3.PolyTyp)
				{
					method_31(tedge_2, tedge_3, intPoint_0);
				}
				else if (num2 == 1 && num3 == 1)
				{
					switch (clipType_0)
					{
					case ClipType.ctIntersection:
						if (num4 > 0L && num5 > 0L)
						{
							method_31(tedge_2, tedge_3, intPoint_0);
						}
						break;
					case ClipType.ctUnion:
						if (num4 <= 0L && num5 <= 0L)
						{
							method_31(tedge_2, tedge_3, intPoint_0);
						}
						break;
					case ClipType.ctDifference:
						if ((tedge_2.PolyTyp == PolyType.ptClip && num4 > 0L && num5 > 0L) || (tedge_2.PolyTyp == PolyType.ptSubject && num4 <= 0L && num5 <= 0L))
						{
							method_31(tedge_2, tedge_3, intPoint_0);
						}
						break;
					case ClipType.ctXor:
						method_31(tedge_2, tedge_3, intPoint_0);
						break;
					}
				}
				else
				{
					smethod_0(tedge_2, tedge_3);
				}
			}
		}
		else if (!(flag || flag2) && (num2 == 0 || num2 == 1) && (num3 == 0 || num3 == 1) && (tedge_2.PolyTyp == tedge_3.PolyTyp || clipType_0 == ClipType.ctXor))
		{
			method_33(tedge_2, intPoint_0);
			method_33(tedge_3, intPoint_0);
			smethod_0(tedge_2, tedge_3);
			smethod_1(tedge_2, tedge_3);
		}
		else
		{
			method_30(tedge_2, tedge_3, intPoint_0);
		}
		if (flag != flag2 && ((flag && tedge_2.OutIdx >= 0) || (flag2 && tedge_3.OutIdx >= 0)))
		{
			smethod_0(tedge_2, tedge_3);
			smethod_1(tedge_2, tedge_3);
		}
		if (flag)
		{
			method_46(tedge_2);
		}
		if (flag2)
		{
			method_46(tedge_3);
		}
	}

	private void method_46(TEdge tedge_2)
	{
		TEdge tedge_3 = tedge_2.tedge_2;
		TEdge tEdge = tedge_2.tedge_1;
		if (tedge_3 != null || tEdge != null || tedge_2 == tedge_0)
		{
			if (tedge_3 == null)
			{
				tedge_0 = tEdge;
			}
			else
			{
				tedge_3.tedge_1 = tEdge;
			}
			if (tEdge != null)
			{
				tEdge.tedge_2 = tedge_3;
			}
			tedge_2.tedge_1 = null;
			tedge_2.tedge_2 = null;
		}
	}

	private void method_47(TEdge tedge_2)
	{
		TEdge tedge_3 = tedge_2.tedge_4;
		TEdge tedge_4 = tedge_2.tedge_3;
		if (tedge_3 != null || tedge_4 != null || tedge_2 == tedge_1)
		{
			if (tedge_3 != null)
			{
				tedge_3.tedge_3 = tedge_4;
			}
			else
			{
				tedge_1 = tedge_4;
			}
			if (tedge_4 != null)
			{
				tedge_4.tedge_4 = tedge_3;
			}
			tedge_2.tedge_3 = null;
			tedge_2.tedge_4 = null;
		}
	}

	private void method_48(ref TEdge tedge_2)
	{
		if (tedge_2.tedge_0 == null)
		{
			throw new ClipperException("UpdateEdgeIntoAEL: invalid call");
		}
		TEdge tedge_3 = tedge_2.tedge_2;
		TEdge tEdge = tedge_2.tedge_1;
		tedge_2.tedge_0.OutIdx = tedge_2.OutIdx;
		if (tedge_3 != null)
		{
			tedge_3.tedge_1 = tedge_2.tedge_0;
		}
		else
		{
			tedge_0 = tedge_2.tedge_0;
		}
		if (tEdge != null)
		{
			tEdge.tedge_2 = tedge_2.tedge_0;
		}
		tedge_2.tedge_0.Side = tedge_2.Side;
		tedge_2.tedge_0.WindDelta = tedge_2.WindDelta;
		tedge_2.tedge_0.WindCnt = tedge_2.WindCnt;
		tedge_2.tedge_0.WindCnt2 = tedge_2.WindCnt2;
		tedge_2 = tedge_2.tedge_0;
		tedge_2.Curr = tedge_2.Bot;
		tedge_2.tedge_2 = tedge_3;
		tedge_2.tedge_1 = tEdge;
		if (!ClipperBase.IsHorizontal(tedge_2))
		{
			method_11(tedge_2.Top.Y);
		}
	}

	private void method_49(bool bool_5)
	{
		for (TEdge tEdge = tedge_1; tEdge != null; tEdge = tedge_1)
		{
			method_47(tEdge);
			method_52(tEdge, bool_5);
		}
	}

	private void method_50(TEdge tedge_2, out Direction direction_0, out long long_0, out long long_1)
	{
		if (tedge_2.Bot.X < tedge_2.Top.X)
		{
			long_0 = tedge_2.Bot.X;
			long_1 = tedge_2.Top.X;
			direction_0 = Direction.dLeftToRight;
		}
		else
		{
			long_0 = tedge_2.Top.X;
			long_1 = tedge_2.Bot.X;
			direction_0 = Direction.dRightToLeft;
		}
	}

	private void method_51(TEdge tedge_2, bool bool_5)
	{
		OutPt outPt = wmvehEjyXoO[tedge_2.OutIdx].Pts;
		if (tedge_2.Side != EdgeSide.esLeft)
		{
			outPt = outPt.Prev;
		}
		if (bool_5)
		{
			if (!(outPt.Pt == tedge_2.Top))
			{
				method_18(outPt, tedge_2.Top);
			}
			else
			{
				method_18(outPt, tedge_2.Bot);
			}
		}
	}

	private void method_52(TEdge tedge_2, bool bool_5)
	{
		method_50(tedge_2, out var direction_, out var long_, out var long_2);
		TEdge tEdge = tedge_2;
		TEdge tEdge2 = null;
		while (tEdge.tedge_0 != null && ClipperBase.IsHorizontal(tEdge.tedge_0))
		{
			tEdge = tEdge.tedge_0;
		}
		if (tEdge.tedge_0 == null)
		{
			tEdge2 = ycKehypkLnY(tEdge);
		}
		while (true)
		{
			bool flag = tedge_2 == tEdge;
			TEdge tEdge3 = method_53(tedge_2, direction_);
			while (tEdge3 != null && (tEdge3.Curr.X != tedge_2.Top.X || tedge_2.tedge_0 == null || !(tEdge3.Dx < tedge_2.tedge_0.Dx)))
			{
				TEdge tEdge4 = method_53(tEdge3, direction_);
				if ((direction_ == Direction.dLeftToRight && tEdge3.Curr.X <= long_2) || (direction_ == Direction.dRightToLeft && tEdge3.Curr.X >= long_))
				{
					if (tedge_2.OutIdx >= 0 && tedge_2.WindDelta != 0)
					{
						method_51(tedge_2, bool_5);
					}
					if (tEdge3 == tEdge2 && flag)
					{
						if (direction_ == Direction.dLeftToRight)
						{
							method_45(tedge_2, tEdge3, tEdge3.Top);
						}
						else
						{
							method_45(tEdge3, tedge_2, tEdge3.Top);
						}
						if (tEdge2.OutIdx >= 0)
						{
							throw new ClipperException("ProcessHorizontal error");
						}
						return;
					}
					if (direction_ != Direction.dLeftToRight)
					{
						method_45(intPoint_0: new IntPoint(tEdge3.Curr.X, tedge_2.Curr.Y), tedge_2: tEdge3, tedge_3: tedge_2, bool_5: true);
					}
					else
					{
						method_45(intPoint_0: new IntPoint(tEdge3.Curr.X, tedge_2.Curr.Y), tedge_2: tedge_2, tedge_3: tEdge3, bool_5: true);
					}
					method_28(tedge_2, tEdge3);
				}
				else if ((direction_ == Direction.dLeftToRight && tEdge3.Curr.X >= long_2) || (direction_ == Direction.dRightToLeft && tEdge3.Curr.X <= long_))
				{
					break;
				}
				tEdge3 = tEdge4;
			}
			if (tedge_2.OutIdx >= 0 && tedge_2.WindDelta != 0)
			{
				method_51(tedge_2, bool_5);
			}
			if (tedge_2.tedge_0 == null || !ClipperBase.IsHorizontal(tedge_2.tedge_0))
			{
				break;
			}
			method_48(ref tedge_2);
			if (tedge_2.OutIdx >= 0)
			{
				method_33(tedge_2, tedge_2.Bot);
			}
			method_50(tedge_2, out direction_, out long_, out long_2);
		}
		if (tedge_2.tedge_0 != null)
		{
			if (tedge_2.OutIdx >= 0)
			{
				OutPt outPt_ = method_33(tedge_2, tedge_2.Top);
				method_48(ref tedge_2);
				if (tedge_2.WindDelta != 0)
				{
					TEdge tedge_3 = tedge_2.tedge_2;
					TEdge tEdge5 = tedge_2.tedge_1;
					if (tedge_3 != null && tedge_3.Curr.X == tedge_2.Bot.X && tedge_3.Curr.Y == tedge_2.Bot.Y && tedge_3.WindDelta != 0 && tedge_3.OutIdx >= 0 && tedge_3.Curr.Y > tedge_3.Top.Y && ClipperBase.SlopesEqual(tedge_2, tedge_3, m_UseFullRange))
					{
						OutPt outPt_2 = method_33(tedge_3, tedge_2.Bot);
						method_17(outPt_, outPt_2, tedge_2.Top);
					}
					else if (tEdge5 != null && tEdge5.Curr.X == tedge_2.Bot.X && tEdge5.Curr.Y == tedge_2.Bot.Y && tEdge5.WindDelta != 0 && tEdge5.OutIdx >= 0 && tEdge5.Curr.Y > tEdge5.Top.Y && ClipperBase.SlopesEqual(tedge_2, tEdge5, m_UseFullRange))
					{
						OutPt outPt_3 = method_33(tEdge5, tedge_2.Bot);
						method_17(outPt_, outPt_3, tedge_2.Top);
					}
				}
			}
			else
			{
				method_48(ref tedge_2);
			}
		}
		else if (tEdge2 == null)
		{
			if (tedge_2.OutIdx >= 0)
			{
				method_33(tedge_2, tedge_2.Top);
			}
			method_46(tedge_2);
		}
		else if (tEdge2.OutIdx >= 0)
		{
			if (direction_ == Direction.dLeftToRight)
			{
				method_45(tedge_2, tEdge2, tedge_2.Top);
			}
			else
			{
				method_45(tEdge2, tedge_2, tedge_2.Top);
			}
			if (tEdge2.OutIdx >= 0)
			{
				throw new ClipperException("ProcessHorizontal error");
			}
		}
		else
		{
			method_46(tedge_2);
			method_46(tEdge2);
		}
	}

	private TEdge method_53(TEdge tedge_2, Direction direction_0)
	{
		if (direction_0 != Direction.dLeftToRight)
		{
			return tedge_2.tedge_2;
		}
		return tedge_2.tedge_1;
	}

	private bool method_54(TEdge tedge_2)
	{
		int result;
		if (tedge_2 == null)
		{
			result = 0;
		}
		else
		{
			if (tedge_2.Prev.tedge_0 != tedge_2)
			{
				return tedge_2.Next.tedge_0 != tedge_2;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_55(TEdge tedge_2, double double_0)
	{
		int result;
		if (tedge_2 != null)
		{
			if ((double)tedge_2.Top.Y == double_0)
			{
				return tedge_2.tedge_0 == null;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_56(TEdge tedge_2, double double_0)
	{
		if ((double)tedge_2.Top.Y == double_0)
		{
			return tedge_2.tedge_0 != null;
		}
		return false;
	}

	private TEdge ycKehypkLnY(TEdge tedge_2)
	{
		TEdge tEdge = null;
		if (tedge_2.Next.Top == tedge_2.Top && tedge_2.Next.tedge_0 == null)
		{
			tEdge = tedge_2.Next;
		}
		else if (tedge_2.Prev.Top == tedge_2.Top && tedge_2.Prev.tedge_0 == null)
		{
			tEdge = tedge_2.Prev;
		}
		if (tEdge != null && (tEdge.OutIdx == -2 || (tEdge.tedge_1 == tEdge.tedge_2 && !ClipperBase.IsHorizontal(tEdge))))
		{
			return null;
		}
		return tEdge;
	}

	private bool method_57(long long_0, long long_1)
	{
		if (tedge_0 != null)
		{
			try
			{
				method_58(long_0, long_1);
				if (list_0.Count == 0)
				{
					return true;
				}
				if (list_0.Count != 1 && !method_60())
				{
					return false;
				}
				DeXehjIgep1();
			}
			catch
			{
				tedge_1 = null;
				list_0.Clear();
				throw new ClipperException("ProcessIntersections error");
			}
			tedge_1 = null;
			return true;
		}
		return true;
	}

	private void method_58(long long_0, long long_1)
	{
		if (tedge_0 == null)
		{
			return;
		}
		for (TEdge tEdge = (tedge_1 = tedge_0); tEdge != null; tEdge = tEdge.tedge_1)
		{
			tEdge.tedge_4 = tEdge.tedge_2;
			tEdge.tedge_3 = tEdge.tedge_1;
			tEdge.Curr.X = smethod_3(tEdge, long_1);
		}
		bool flag = true;
		while (flag && tedge_1 != null)
		{
			flag = false;
			TEdge tEdge = tedge_1;
			while (tEdge.tedge_3 != null)
			{
				TEdge tedge_ = tEdge.tedge_3;
				if (tEdge.Curr.X > tedge_.Curr.X)
				{
					if (!method_61(tEdge, tedge_, out var intPoint_) && tEdge.Curr.X > tedge_.Curr.X + 1L)
					{
						throw new ClipperException("Intersection error");
					}
					if (intPoint_.Y > long_0)
					{
						intPoint_.Y = long_0;
						if (Math.Abs(tEdge.Dx) > Math.Abs(tedge_.Dx))
						{
							intPoint_.X = smethod_3(tedge_, long_0);
						}
						else
						{
							intPoint_.X = smethod_3(tEdge, long_0);
						}
					}
					IntersectNode intersectNode = new IntersectNode();
					intersectNode.Edge1 = tEdge;
					intersectNode.Edge2 = tedge_;
					intersectNode.Pt = intPoint_;
					list_0.Add(intersectNode);
					method_29(tEdge, tedge_);
					flag = true;
				}
				else
				{
					tEdge = tedge_;
				}
			}
			if (tEdge.tedge_4 == null)
			{
				break;
			}
			tEdge.tedge_4.tedge_3 = null;
		}
		tedge_1 = null;
	}

	private bool method_59(IntersectNode intersectNode_0)
	{
		if (intersectNode_0.Edge1.tedge_3 != intersectNode_0.Edge2)
		{
			return intersectNode_0.Edge1.tedge_4 == intersectNode_0.Edge2;
		}
		return true;
	}

	private static int smethod_2(object object_0, object object_1)
	{
		return (int)(((IntersectNode)object_1).Pt.Y - ((IntersectNode)object_0).Pt.Y);
	}

	private bool method_60()
	{
		list_0.Sort(icomparer_0);
		method_27();
		int count = list_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (!method_59(list_0[i]))
			{
				int j;
				for (j = i + 1; j < count && !method_59(list_0[j]); j++)
				{
				}
				if (j == count)
				{
					return false;
				}
				IntersectNode value = list_0[i];
				list_0[i] = list_0[j];
				list_0[j] = value;
			}
			method_29(list_0[i].Edge1, list_0[i].Edge2);
		}
		return true;
	}

	private void DeXehjIgep1()
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			IntersectNode intersectNode = list_0[i];
			method_45(intersectNode.Edge1, intersectNode.Edge2, intersectNode.Pt, bool_5: true);
			method_28(intersectNode.Edge1, intersectNode.Edge2);
		}
		list_0.Clear();
	}

	internal static long Round(double value)
	{
		if (!(value >= 0.0))
		{
			return (long)(value - 0.5);
		}
		return (long)(value + 0.5);
	}

	private static long smethod_3(object object_0, long long_0)
	{
		if (long_0 == ((TEdge)object_0).Top.Y)
		{
			return ((TEdge)object_0).Top.X;
		}
		return ((TEdge)object_0).Bot.X + Round(((TEdge)object_0).Dx * (double)(long_0 - ((TEdge)object_0).Bot.Y));
	}

	private bool method_61(TEdge tedge_2, TEdge tedge_3, out IntPoint intPoint_0)
	{
		intPoint_0 = default(IntPoint);
		if (!ClipperBase.SlopesEqual(tedge_2, tedge_3, m_UseFullRange) && tedge_2.Dx != tedge_3.Dx)
		{
			if (tedge_2.Delta.X != 0L)
			{
				if (tedge_3.Delta.X == 0L)
				{
					intPoint_0.X = tedge_3.Bot.X;
					if (!ClipperBase.IsHorizontal(tedge_2))
					{
						double num = (double)tedge_2.Bot.Y - (double)tedge_2.Bot.X / tedge_2.Dx;
						intPoint_0.Y = Round((double)intPoint_0.X / tedge_2.Dx + num);
					}
					else
					{
						intPoint_0.Y = tedge_2.Bot.Y;
					}
				}
				else
				{
					double num = (double)tedge_2.Bot.X - (double)tedge_2.Bot.Y * tedge_2.Dx;
					double num2 = (double)tedge_3.Bot.X - (double)tedge_3.Bot.Y * tedge_3.Dx;
					double num3 = (num2 - num) / (tedge_2.Dx - tedge_3.Dx);
					intPoint_0.Y = Round(num3);
					if (Math.Abs(tedge_2.Dx) < Math.Abs(tedge_3.Dx))
					{
						intPoint_0.X = Round(tedge_2.Dx * num3 + num);
					}
					else
					{
						intPoint_0.X = Round(tedge_3.Dx * num3 + num2);
					}
				}
			}
			else
			{
				intPoint_0.X = tedge_2.Bot.X;
				if (ClipperBase.IsHorizontal(tedge_3))
				{
					intPoint_0.Y = tedge_3.Bot.Y;
				}
				else
				{
					double num2 = (double)tedge_3.Bot.Y - (double)tedge_3.Bot.X / tedge_3.Dx;
					intPoint_0.Y = Round((double)intPoint_0.X / tedge_3.Dx + num2);
				}
			}
			int result;
			if (intPoint_0.Y >= tedge_2.Top.Y && intPoint_0.Y >= tedge_3.Top.Y)
			{
				result = 1;
			}
			else
			{
				if (tedge_2.Top.Y > tedge_3.Top.Y)
				{
					intPoint_0.Y = tedge_2.Top.Y;
				}
				else
				{
					intPoint_0.Y = tedge_3.Top.Y;
				}
				if (Math.Abs(tedge_2.Dx) < Math.Abs(tedge_3.Dx))
				{
					intPoint_0.X = smethod_3(tedge_2, intPoint_0.Y);
					result = 1;
				}
				else
				{
					intPoint_0.X = smethod_3(tedge_3, intPoint_0.Y);
					result = 1;
				}
			}
			return (byte)result != 0;
		}
		int result2;
		if (tedge_3.Bot.Y > tedge_2.Bot.Y)
		{
			intPoint_0 = tedge_3.Bot;
			result2 = 0;
		}
		else
		{
			intPoint_0 = tedge_2.Bot;
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	private void method_62(long long_0)
	{
		TEdge tedge_ = tedge_0;
		while (tedge_ != null)
		{
			bool flag;
			if (flag = method_55(tedge_, long_0))
			{
				TEdge tEdge = ycKehypkLnY(tedge_);
				flag = tEdge == null || !ClipperBase.IsHorizontal(tEdge);
			}
			if (flag)
			{
				TEdge tedge_2 = tedge_.tedge_2;
				method_63(tedge_);
				tedge_ = ((tedge_2 == null) ? tedge_0 : tedge_2.tedge_1);
				continue;
			}
			if (method_56(tedge_, long_0) && ClipperBase.IsHorizontal(tedge_.tedge_0))
			{
				method_48(ref tedge_);
				if (tedge_.OutIdx >= 0)
				{
					method_33(tedge_, tedge_.Bot);
				}
				method_26(tedge_);
			}
			else
			{
				tedge_.Curr.X = smethod_3(tedge_, long_0);
				tedge_.Curr.Y = long_0;
			}
			if (StrictlySimple)
			{
				TEdge tedge_3 = tedge_.tedge_2;
				if (tedge_.OutIdx >= 0 && tedge_.WindDelta != 0 && tedge_3 != null && tedge_3.OutIdx >= 0 && tedge_3.Curr.X == tedge_.Curr.X && tedge_3.WindDelta != 0)
				{
					OutPt outPt_ = method_33(tedge_3, tedge_.Curr);
					OutPt outPt_2 = method_33(tedge_, tedge_.Curr);
					method_17(outPt_, outPt_2, tedge_.Curr);
				}
			}
			tedge_ = tedge_.tedge_1;
		}
		method_49(bool_5: true);
		for (tedge_ = tedge_0; tedge_ != null; tedge_ = tedge_.tedge_1)
		{
			if (method_56(tedge_, long_0))
			{
				OutPt outPt = null;
				if (tedge_.OutIdx >= 0)
				{
					outPt = method_33(tedge_, tedge_.Top);
				}
				method_48(ref tedge_);
				TEdge tedge_4 = tedge_.tedge_2;
				TEdge tEdge2 = tedge_.tedge_1;
				if (tedge_4 != null && tedge_4.Curr.X == tedge_.Bot.X && tedge_4.Curr.Y == tedge_.Bot.Y && outPt != null && tedge_4.OutIdx >= 0 && tedge_4.Curr.Y > tedge_4.Top.Y && ClipperBase.SlopesEqual(tedge_, tedge_4, m_UseFullRange) && tedge_.WindDelta != 0 && tedge_4.WindDelta != 0)
				{
					OutPt outPt_3 = method_33(tedge_4, tedge_.Bot);
					method_17(outPt, outPt_3, tedge_.Top);
				}
				else if (tEdge2 != null && tEdge2.Curr.X == tedge_.Bot.X && tEdge2.Curr.Y == tedge_.Bot.Y && outPt != null && tEdge2.OutIdx >= 0 && tEdge2.Curr.Y > tEdge2.Top.Y && ClipperBase.SlopesEqual(tedge_, tEdge2, m_UseFullRange) && tedge_.WindDelta != 0 && tEdge2.WindDelta != 0)
				{
					OutPt outPt_4 = method_33(tEdge2, tedge_.Bot);
					method_17(outPt, outPt_4, tedge_.Top);
				}
			}
		}
	}

	private void method_63(TEdge tedge_2)
	{
		TEdge tEdge = ycKehypkLnY(tedge_2);
		if (tEdge == null)
		{
			if (tedge_2.OutIdx >= 0)
			{
				method_33(tedge_2, tedge_2.Top);
			}
			method_46(tedge_2);
			return;
		}
		TEdge tEdge2 = tedge_2.tedge_1;
		while (tEdge2 != null && tEdge2 != tEdge)
		{
			method_45(tedge_2, tEdge2, tedge_2.Top, bool_5: true);
			method_28(tedge_2, tEdge2);
			tEdge2 = tedge_2.tedge_1;
		}
		if (tedge_2.OutIdx == -1 && tEdge.OutIdx == -1)
		{
			method_46(tedge_2);
			method_46(tEdge);
			return;
		}
		if (tedge_2.OutIdx < 0 || tEdge.OutIdx < 0)
		{
			throw new ClipperException("DoMaxima error");
		}
		method_45(tedge_2, tEdge, tedge_2.Top);
	}

	public static void ReversePaths(List<List<IntPoint>> polys)
	{
		foreach (List<IntPoint> poly in polys)
		{
			poly.Reverse();
		}
	}

	public static bool Orientation(List<IntPoint> poly)
	{
		return Area(poly) >= 0.0;
	}

	private int jmoehNxelba(OutPt outPt_0)
	{
		if (outPt_0 != null)
		{
			int num = 0;
			OutPt outPt = outPt_0;
			do
			{
				num++;
				outPt = outPt.Next;
			}
			while (outPt != outPt_0);
			return num;
		}
		return 0;
	}

	private void method_64(List<List<IntPoint>> list_2)
	{
		list_2.Clear();
		list_2.Capacity = wmvehEjyXoO.Count;
		for (int i = 0; i < wmvehEjyXoO.Count; i++)
		{
			OutRec outRec = wmvehEjyXoO[i];
			if (outRec.Pts == null)
			{
				continue;
			}
			OutPt prev = outRec.Pts.Prev;
			int num = jmoehNxelba(prev);
			if (num >= 2)
			{
				List<IntPoint> list = new List<IntPoint>(num);
				for (int j = 0; j < num; j++)
				{
					list.Add(prev.Pt);
					prev = prev.Prev;
				}
				list_2.Add(list);
			}
		}
	}

	private void method_65(PolyTree polyTree_0)
	{
		polyTree_0.Clear();
		polyTree_0.m_AllPolys.Capacity = wmvehEjyXoO.Count;
		for (int i = 0; i < wmvehEjyXoO.Count; i++)
		{
			OutRec outRec = wmvehEjyXoO[i];
			int num = jmoehNxelba(outRec.Pts);
			if ((!outRec.IsOpen || num >= 2) && (outRec.IsOpen || num >= 3))
			{
				FixHoleLinkage(outRec);
				PolyNode polyNode = new PolyNode();
				polyTree_0.m_AllPolys.Add(polyNode);
				outRec.PolyNode = polyNode;
				polyNode.m_polygon.Capacity = num;
				OutPt prev = outRec.Pts.Prev;
				for (int j = 0; j < num; j++)
				{
					polyNode.m_polygon.Add(prev.Pt);
					prev = prev.Prev;
				}
			}
		}
		polyTree_0.m_Childs.Capacity = wmvehEjyXoO.Count;
		for (int k = 0; k < wmvehEjyXoO.Count; k++)
		{
			OutRec outRec2 = wmvehEjyXoO[k];
			if (outRec2.PolyNode != null)
			{
				if (outRec2.IsOpen)
				{
					outRec2.PolyNode.IsOpen = true;
					polyTree_0.AddChild(outRec2.PolyNode);
				}
				else if (outRec2.FirstLeft != null && outRec2.FirstLeft.PolyNode != null)
				{
					outRec2.FirstLeft.PolyNode.AddChild(outRec2.PolyNode);
				}
				else
				{
					polyTree_0.AddChild(outRec2.PolyNode);
				}
			}
		}
	}

	private void method_66(OutRec outRec_0)
	{
		OutPt outPt = null;
		outRec_0.BottomPt = null;
		OutPt outPt2 = outRec_0.Pts;
		while (outPt2.Prev != outPt2 && outPt2.Prev != outPt2.Next)
		{
			if (!(outPt2.Pt == outPt2.Next.Pt) && !(outPt2.Pt == outPt2.Prev.Pt) && (!ClipperBase.SlopesEqual(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt, m_UseFullRange) || (base.PreserveCollinear && Pt2IsBetweenPt1AndPt3(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt))))
			{
				if (outPt2 == outPt)
				{
					outRec_0.Pts = outPt2;
					return;
				}
				if (outPt == null)
				{
					outPt = outPt2;
				}
				outPt2 = outPt2.Next;
			}
			else
			{
				outPt = null;
				outPt2.Prev.Next = outPt2.Next;
				outPt2.Next.Prev = outPt2.Prev;
				outPt2 = outPt2.Prev;
			}
		}
		method_16(outPt2);
		outRec_0.Pts = null;
	}

	private OutPt method_67(OutPt outPt_0, bool bool_5)
	{
		OutPt outPt = new OutPt();
		outPt.Pt = outPt_0.Pt;
		outPt.Idx = outPt_0.Idx;
		if (!bool_5)
		{
			outPt.Prev = outPt_0.Prev;
			outPt.Next = outPt_0;
			outPt_0.Prev.Next = outPt;
			outPt_0.Prev = outPt;
		}
		else
		{
			outPt.Next = outPt_0.Next;
			outPt.Prev = outPt_0;
			outPt_0.Next.Prev = outPt;
			outPt_0.Next = outPt;
		}
		return outPt;
	}

	private bool method_68(long long_0, long long_1, long long_2, long long_3, out long long_4, out long long_5)
	{
		if (long_0 < long_1)
		{
			if (long_2 >= long_3)
			{
				long_4 = Math.Max(long_0, long_3);
				long_5 = Math.Min(long_1, long_2);
			}
			else
			{
				long_4 = Math.Max(long_0, long_2);
				long_5 = Math.Min(long_1, long_3);
			}
		}
		else if (long_2 < long_3)
		{
			long_4 = Math.Max(long_1, long_2);
			long_5 = Math.Min(long_0, long_3);
		}
		else
		{
			long_4 = Math.Max(long_1, long_3);
			long_5 = Math.Min(long_0, long_2);
		}
		return long_4 < long_5;
	}

	private bool method_69(OutPt outPt_0, OutPt outPt_1, OutPt outPt_2, OutPt outPt_3, IntPoint intPoint_0, bool bool_5)
	{
		Direction direction = ((outPt_0.Pt.X <= outPt_1.Pt.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		Direction direction2 = ((outPt_2.Pt.X <= outPt_3.Pt.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		if (direction == direction2)
		{
			return false;
		}
		if (direction == Direction.dLeftToRight)
		{
			while (outPt_0.Next.Pt.X <= intPoint_0.X && outPt_0.Next.Pt.X >= outPt_0.Pt.X && outPt_0.Next.Pt.Y == intPoint_0.Y)
			{
				outPt_0 = outPt_0.Next;
			}
			if (bool_5 && outPt_0.Pt.X != intPoint_0.X)
			{
				outPt_0 = outPt_0.Next;
			}
			outPt_1 = method_67(outPt_0, !bool_5);
			if (outPt_1.Pt != intPoint_0)
			{
				outPt_0 = outPt_1;
				outPt_0.Pt = intPoint_0;
				outPt_1 = method_67(outPt_0, !bool_5);
			}
		}
		else
		{
			while (outPt_0.Next.Pt.X >= intPoint_0.X && outPt_0.Next.Pt.X <= outPt_0.Pt.X && outPt_0.Next.Pt.Y == intPoint_0.Y)
			{
				outPt_0 = outPt_0.Next;
			}
			if (!bool_5 && outPt_0.Pt.X != intPoint_0.X)
			{
				outPt_0 = outPt_0.Next;
			}
			outPt_1 = method_67(outPt_0, bool_5);
			if (outPt_1.Pt != intPoint_0)
			{
				outPt_0 = outPt_1;
				outPt_0.Pt = intPoint_0;
				outPt_1 = method_67(outPt_0, bool_5);
			}
		}
		if (direction2 == Direction.dLeftToRight)
		{
			while (outPt_2.Next.Pt.X <= intPoint_0.X && outPt_2.Next.Pt.X >= outPt_2.Pt.X && outPt_2.Next.Pt.Y == intPoint_0.Y)
			{
				outPt_2 = outPt_2.Next;
			}
			if (bool_5 && outPt_2.Pt.X != intPoint_0.X)
			{
				outPt_2 = outPt_2.Next;
			}
			outPt_3 = method_67(outPt_2, !bool_5);
			if (outPt_3.Pt != intPoint_0)
			{
				outPt_2 = outPt_3;
				outPt_2.Pt = intPoint_0;
				outPt_3 = method_67(outPt_2, !bool_5);
			}
		}
		else
		{
			while (outPt_2.Next.Pt.X >= intPoint_0.X && outPt_2.Next.Pt.X <= outPt_2.Pt.X && outPt_2.Next.Pt.Y == intPoint_0.Y)
			{
				outPt_2 = outPt_2.Next;
			}
			if (!bool_5 && outPt_2.Pt.X != intPoint_0.X)
			{
				outPt_2 = outPt_2.Next;
			}
			outPt_3 = method_67(outPt_2, bool_5);
			if (outPt_3.Pt != intPoint_0)
			{
				outPt_2 = outPt_3;
				outPt_2.Pt = intPoint_0;
				outPt_3 = method_67(outPt_2, bool_5);
			}
		}
		int result;
		if (direction == Direction.dLeftToRight == bool_5)
		{
			outPt_0.Prev = outPt_2;
			outPt_2.Next = outPt_0;
			outPt_1.Next = outPt_3;
			outPt_3.Prev = outPt_1;
			result = 1;
		}
		else
		{
			outPt_0.Next = outPt_2;
			outPt_2.Prev = outPt_0;
			outPt_1.Prev = outPt_3;
			outPt_3.Next = outPt_1;
			result = 1;
		}
		return (byte)result != 0;
	}

	private bool method_70(Join join_0, OutRec outRec_0, OutRec outRec_1)
	{
		OutPt outPt = join_0.OutPt1;
		OutPt outPt2 = join_0.OutPt2;
		bool flag;
		OutPt next;
		OutPt next2;
		if ((flag = join_0.OutPt1.Pt.Y == join_0.OffPt.Y) && join_0.OffPt == join_0.OutPt1.Pt && join_0.OffPt == join_0.OutPt2.Pt)
		{
			next = join_0.OutPt1.Next;
			while (next != outPt && next.Pt == join_0.OffPt)
			{
				next = next.Next;
			}
			bool flag2 = next.Pt.Y > join_0.OffPt.Y;
			next2 = join_0.OutPt2.Next;
			while (next2 != outPt2 && next2.Pt == join_0.OffPt)
			{
				next2 = next2.Next;
			}
			bool flag3 = next2.Pt.Y > join_0.OffPt.Y;
			if (flag2 == flag3)
			{
				return false;
			}
			if (!flag2)
			{
				next = method_67(outPt, bool_5: true);
				next2 = method_67(outPt2, bool_5: false);
				outPt.Next = outPt2;
				outPt2.Prev = outPt;
				next.Prev = next2;
				next2.Next = next;
				join_0.OutPt1 = outPt;
				join_0.OutPt2 = next;
				return true;
			}
			next = method_67(outPt, bool_5: false);
			next2 = method_67(outPt2, bool_5: true);
			outPt.Prev = outPt2;
			outPt2.Next = outPt;
			next.Next = next2;
			next2.Prev = next;
			join_0.OutPt1 = outPt;
			join_0.OutPt2 = next;
			return true;
		}
		bool flag4;
		if (!flag)
		{
			next = outPt.Next;
			while (next.Pt == outPt.Pt && next != outPt)
			{
				next = next.Next;
			}
			if (flag4 = next.Pt.Y > outPt.Pt.Y || !ClipperBase.SlopesEqual(outPt.Pt, next.Pt, join_0.OffPt, m_UseFullRange))
			{
				next = outPt.Prev;
				while (next.Pt == outPt.Pt && next != outPt)
				{
					next = next.Prev;
				}
				int result;
				if (next.Pt.Y <= outPt.Pt.Y)
				{
					if (ClipperBase.SlopesEqual(outPt.Pt, next.Pt, join_0.OffPt, m_UseFullRange))
					{
						goto IL_026e;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}
			goto IL_026e;
		}
		next = outPt;
		while (outPt.Prev.Pt.Y == outPt.Pt.Y && outPt.Prev != next && outPt.Prev != outPt2)
		{
			outPt = outPt.Prev;
		}
		while (next.Next.Pt.Y == next.Pt.Y && next.Next != outPt && next.Next != outPt2)
		{
			next = next.Next;
		}
		int result3;
		if (next.Next != outPt)
		{
			if (next.Next != outPt2)
			{
				next2 = outPt2;
				while (outPt2.Prev.Pt.Y == outPt2.Pt.Y && outPt2.Prev != next2 && outPt2.Prev != next)
				{
					outPt2 = outPt2.Prev;
				}
				while (next2.Next.Pt.Y == next2.Pt.Y && next2.Next != outPt2 && next2.Next != outPt)
				{
					next2 = next2.Next;
				}
				int result2;
				if (next2.Next != outPt2)
				{
					if (next2.Next != outPt)
					{
						if (method_68(outPt.Pt.X, next.Pt.X, outPt2.Pt.X, next2.Pt.X, out var long_, out var long_2))
						{
							IntPoint pt;
							bool bool_;
							if (outPt.Pt.X >= long_ && outPt.Pt.X <= long_2)
							{
								pt = outPt.Pt;
								bool_ = outPt.Pt.X > next.Pt.X;
							}
							else if (outPt2.Pt.X >= long_ && outPt2.Pt.X <= long_2)
							{
								pt = outPt2.Pt;
								bool_ = outPt2.Pt.X > next2.Pt.X;
							}
							else if (next.Pt.X >= long_ && next.Pt.X <= long_2)
							{
								pt = next.Pt;
								bool_ = next.Pt.X > outPt.Pt.X;
							}
							else
							{
								pt = next2.Pt;
								bool_ = next2.Pt.X > outPt2.Pt.X;
							}
							join_0.OutPt1 = outPt;
							join_0.OutPt2 = outPt2;
							return method_69(outPt, next, outPt2, next2, pt, bool_);
						}
						return false;
					}
					result2 = 0;
				}
				else
				{
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			result3 = 0;
		}
		else
		{
			result3 = 0;
		}
		return (byte)result3 != 0;
		IL_033e:
		bool flag5;
		int result4;
		if (next != outPt && next2 != outPt2 && next != next2)
		{
			if (outRec_0 != outRec_1 || flag4 != flag5)
			{
				if (!flag4)
				{
					next = method_67(outPt, bool_5: true);
					next2 = method_67(outPt2, bool_5: false);
					outPt.Next = outPt2;
					outPt2.Prev = outPt;
					next.Prev = next2;
					next2.Next = next;
					join_0.OutPt1 = outPt;
					join_0.OutPt2 = next;
					return true;
				}
				next = method_67(outPt, bool_5: false);
				next2 = method_67(outPt2, bool_5: true);
				outPt.Prev = outPt2;
				outPt2.Next = outPt;
				next.Next = next2;
				next2.Prev = next;
				join_0.OutPt1 = outPt;
				join_0.OutPt2 = next;
				return true;
			}
			result4 = 0;
		}
		else
		{
			result4 = 0;
		}
		return (byte)result4 != 0;
		IL_026e:
		next2 = outPt2.Next;
		while (next2.Pt == outPt2.Pt && next2 != outPt2)
		{
			next2 = next2.Next;
		}
		if (flag5 = next2.Pt.Y > outPt2.Pt.Y || !ClipperBase.SlopesEqual(outPt2.Pt, next2.Pt, join_0.OffPt, m_UseFullRange))
		{
			next2 = outPt2.Prev;
			while (next2.Pt == outPt2.Pt && next2 != outPt2)
			{
				next2 = next2.Prev;
			}
			int result5;
			if (next2.Pt.Y > outPt2.Pt.Y)
			{
				result5 = 0;
			}
			else
			{
				if (ClipperBase.SlopesEqual(outPt2.Pt, next2.Pt, join_0.OffPt, m_UseFullRange))
				{
					goto IL_033e;
				}
				result5 = 0;
			}
			return (byte)result5 != 0;
		}
		goto IL_033e;
	}

	public static int PointInPolygon(IntPoint pt, List<IntPoint> path)
	{
		long x = pt.X;
		long y = pt.Y;
		int num = 0;
		int count = path.Count;
		if (count < 3)
		{
			return 0;
		}
		IntPoint intPoint = path[0];
		long x2 = intPoint.X;
		long y2 = intPoint.Y;
		for (int num2 = 1; num2 <= count; num2++)
		{
			IntPoint intPoint2 = ((num2 == count) ? path[0] : path[num2]);
			long x3 = intPoint2.X;
			long y3 = intPoint2.Y;
			if (y3 == y)
			{
				int result;
				if (x3 != x)
				{
					if (y2 != y || x3 > x != x2 < x)
					{
						goto IL_008a;
					}
					result = -1;
				}
				else
				{
					result = -1;
				}
				return result;
			}
			goto IL_008a;
			IL_008a:
			if (y2 < y != y3 < y)
			{
				if (x2 >= x)
				{
					if (x3 > x)
					{
						num = 1 - num;
					}
					else
					{
						double num3 = (double)(x2 - x) * (double)(y3 - y) - (double)(x3 - x) * (double)(y2 - y);
						if (num3 == 0.0)
						{
							return -1;
						}
						if (num3 > 0.0 == y3 > y2)
						{
							num = 1 - num;
						}
					}
				}
				else if (x3 > x)
				{
					double num4 = (double)(x2 - x) * (double)(y3 - y) - (double)(x3 - x) * (double)(y2 - y);
					if (num4 == 0.0)
					{
						return -1;
					}
					if (num4 > 0.0 == y3 > y2)
					{
						num = 1 - num;
					}
				}
			}
		}
		return num;
	}

	private int method_71(IntPoint intPoint_0, OutPt outPt_0)
	{
		int num = 0;
		OutPt outPt = outPt_0;
		do
		{
			double num2 = outPt_0.Pt.X;
			double num3 = outPt_0.Pt.Y;
			double num4 = outPt_0.Next.Pt.X;
			double num5 = outPt_0.Next.Pt.Y;
			if (num5 == (double)intPoint_0.Y)
			{
				int result;
				if (num4 != (double)intPoint_0.X)
				{
					if (num3 != (double)intPoint_0.Y || num4 > (double)intPoint_0.X != num2 < (double)intPoint_0.X)
					{
						goto IL_000a;
					}
					result = -1;
				}
				else
				{
					result = -1;
				}
				return result;
			}
			goto IL_000a;
			IL_000a:
			if (num3 < (double)intPoint_0.Y != num5 < (double)intPoint_0.Y)
			{
				if (num2 >= (double)intPoint_0.X)
				{
					if (num4 > (double)intPoint_0.X)
					{
						num = 1 - num;
					}
					else
					{
						double num6 = (num2 - (double)intPoint_0.X) * (num5 - (double)intPoint_0.Y) - (num4 - (double)intPoint_0.X) * (num3 - (double)intPoint_0.Y);
						if (num6 == 0.0)
						{
							return -1;
						}
						if (num6 > 0.0 == num5 > num3)
						{
							num = 1 - num;
						}
					}
				}
				else if (num4 > (double)intPoint_0.X)
				{
					double num7 = (num2 - (double)intPoint_0.X) * (num5 - (double)intPoint_0.Y) - (num4 - (double)intPoint_0.X) * (num3 - (double)intPoint_0.Y);
					if (num7 == 0.0)
					{
						return -1;
					}
					if (num7 > 0.0 == num5 > num3)
					{
						num = 1 - num;
					}
				}
			}
			outPt_0 = outPt_0.Next;
		}
		while (outPt != outPt_0);
		return num;
	}

	private bool method_72(OutPt outPt_0, OutPt outPt_1)
	{
		OutPt outPt = outPt_0;
		do
		{
			int num = method_71(outPt.Pt, outPt_1);
			if (num < 0)
			{
				outPt = outPt.Next;
				continue;
			}
			return num != 0;
		}
		while (outPt != outPt_0);
		return true;
	}

	private void method_73(OutRec outRec_0, OutRec outRec_1)
	{
		for (int i = 0; i < wmvehEjyXoO.Count; i++)
		{
			OutRec outRec = wmvehEjyXoO[i];
			if (outRec.Pts != null && outRec.FirstLeft == outRec_0 && method_72(outRec.Pts, outRec_1.Pts))
			{
				outRec.FirstLeft = outRec_1;
			}
		}
	}

	private void method_74(OutRec outRec_0, OutRec outRec_1)
	{
		foreach (OutRec item in wmvehEjyXoO)
		{
			if (item.FirstLeft == outRec_0)
			{
				item.FirstLeft = outRec_1;
			}
		}
	}

	private static OutRec smethod_4(object object_0)
	{
		while (object_0 != null && ((OutRec)object_0).Pts == null)
		{
			object_0 = ((OutRec)object_0).FirstLeft;
		}
		return (OutRec)object_0;
	}

	private void method_75()
	{
		for (int i = 0; i < list_1.Count; i++)
		{
			Join obj = list_1[i];
			OutRec outRec = method_42(obj.OutPt1.Idx);
			OutRec outRec2 = method_42(obj.OutPt2.Idx);
			if (outRec.Pts == null || outRec2.Pts == null)
			{
				continue;
			}
			OutRec outRec3 = ((outRec == outRec2) ? outRec : (method_41(outRec, outRec2) ? outRec2 : ((!method_41(outRec2, outRec)) ? method_40(outRec, outRec2) : outRec)));
			if (!method_70(obj, outRec, outRec2))
			{
				continue;
			}
			if (outRec == outRec2)
			{
				outRec.Pts = obj.OutPt1;
				outRec.BottomPt = null;
				outRec2 = method_32();
				outRec2.Pts = obj.OutPt2;
				method_76(outRec2);
				if (bool_2)
				{
					for (int j = 0; j < wmvehEjyXoO.Count - 1; j++)
					{
						OutRec outRec4 = wmvehEjyXoO[j];
						if (outRec4.Pts != null && smethod_4(outRec4.FirstLeft) == outRec && outRec4.IsHole != outRec.IsHole && method_72(outRec4.Pts, obj.OutPt2))
						{
							outRec4.FirstLeft = outRec2;
						}
					}
				}
				if (!method_72(outRec2.Pts, outRec.Pts))
				{
					if (method_72(outRec.Pts, outRec2.Pts))
					{
						outRec2.IsHole = outRec.IsHole;
						outRec.IsHole = !outRec2.IsHole;
						outRec2.FirstLeft = outRec.FirstLeft;
						outRec.FirstLeft = outRec2;
						if (bool_2)
						{
							method_74(outRec, outRec2);
						}
						if ((outRec.IsHole ^ ReverseSolution) == Area(outRec) > 0.0)
						{
							method_44(outRec.Pts);
						}
					}
					else
					{
						outRec2.IsHole = outRec.IsHole;
						outRec2.FirstLeft = outRec.FirstLeft;
						if (bool_2)
						{
							method_73(outRec, outRec2);
						}
					}
				}
				else
				{
					outRec2.IsHole = !outRec.IsHole;
					outRec2.FirstLeft = outRec;
					if (bool_2)
					{
						method_74(outRec2, outRec);
					}
					if ((outRec2.IsHole ^ ReverseSolution) == Area(outRec2) > 0.0)
					{
						method_44(outRec2.Pts);
					}
				}
			}
			else
			{
				outRec2.Pts = null;
				outRec2.BottomPt = null;
				outRec2.Idx = outRec.Idx;
				outRec.IsHole = outRec3.IsHole;
				if (outRec3 == outRec2)
				{
					outRec.FirstLeft = outRec2.FirstLeft;
				}
				outRec2.FirstLeft = outRec;
				if (bool_2)
				{
					method_74(outRec2, outRec);
				}
			}
		}
	}

	private void method_76(OutRec outRec_0)
	{
		OutPt outPt = outRec_0.Pts;
		do
		{
			outPt.Idx = outRec_0.Idx;
			outPt = outPt.Prev;
		}
		while (outPt != outRec_0.Pts);
	}

	private void RvoehqcEnJb()
	{
		int num = 0;
		while (num < wmvehEjyXoO.Count)
		{
			OutRec outRec = wmvehEjyXoO[num++];
			OutPt outPt = outRec.Pts;
			if (outPt == null)
			{
				continue;
			}
			do
			{
				for (OutPt outPt2 = outPt.Next; outPt2 != outRec.Pts; outPt2 = outPt2.Next)
				{
					if (outPt.Pt == outPt2.Pt && outPt2.Next != outPt && outPt2.Prev != outPt)
					{
						OutPt prev = outPt.Prev;
						(outPt.Prev = outPt2.Prev).Next = outPt;
						outPt2.Prev = prev;
						prev.Next = outPt2;
						outRec.Pts = outPt;
						OutRec outRec2 = method_32();
						outRec2.Pts = outPt2;
						method_76(outRec2);
						if (!method_72(outRec2.Pts, outRec.Pts))
						{
							if (method_72(outRec.Pts, outRec2.Pts))
							{
								outRec2.IsHole = outRec.IsHole;
								outRec.IsHole = !outRec2.IsHole;
								outRec2.FirstLeft = outRec.FirstLeft;
								outRec.FirstLeft = outRec2;
							}
							else
							{
								outRec2.IsHole = outRec.IsHole;
								outRec2.FirstLeft = outRec.FirstLeft;
							}
						}
						else
						{
							outRec2.IsHole = !outRec.IsHole;
							outRec2.FirstLeft = outRec;
						}
						outPt2 = outPt;
					}
				}
				outPt = outPt.Next;
			}
			while (outPt != outRec.Pts);
		}
	}

	public static double Area(List<IntPoint> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		int i = 0;
		int index = count - 1;
		for (; i < count; i++)
		{
			num += ((double)poly[index].X + (double)poly[i].X) * ((double)poly[index].Y - (double)poly[i].Y);
			index = i;
		}
		return (0.0 - num) * 0.5;
	}

	private double Area(OutRec outRec)
	{
		OutPt outPt = outRec.Pts;
		if (outPt != null)
		{
			double num = 0.0;
			do
			{
				num += (double)(outPt.Prev.Pt.X + outPt.Pt.X) * (double)(outPt.Prev.Pt.Y - outPt.Pt.Y);
				outPt = outPt.Next;
			}
			while (outPt != outRec.Pts);
			return num * 0.5;
		}
		return 0.0;
	}

	public static List<List<IntPoint>> OffsetPaths(List<List<IntPoint>> polys, double delta, JoinType jointype, EndType_ endtype, double MiterLimit)
	{
		List<List<IntPoint>> solution = new List<List<IntPoint>>();
		ClipperOffset clipperOffset = new ClipperOffset(MiterLimit, MiterLimit);
		clipperOffset.AddPaths(polys, jointype, (EndType)endtype);
		clipperOffset.Execute(ref solution, delta);
		return solution;
	}

	public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPath(poly, PolyType.ptSubject, Closed: true);
		clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	public static List<List<IntPoint>> SimplifyPolygons(List<List<IntPoint>> polys, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPaths(polys, PolyType.ptSubject, closed: true);
		clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	private static double smethod_5(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		double num = (double)intPoint_0.X - (double)intPoint_1.X;
		double num2 = (double)intPoint_0.Y - (double)intPoint_1.Y;
		return num * num + num2 * num2;
	}

	private static double smethod_6(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
	{
		double num = intPoint_1.Y - intPoint_2.Y;
		double num2 = intPoint_2.X - intPoint_1.X;
		double num3 = num * (double)intPoint_1.X + num2 * (double)intPoint_1.Y;
		num3 = num * (double)intPoint_0.X + num2 * (double)intPoint_0.Y - num3;
		return num3 * num3 / (num * num + num2 * num2);
	}

	private static bool smethod_7(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, double double_0)
	{
		return smethod_6(intPoint_1, intPoint_0, intPoint_2) < double_0;
	}

	private static bool smethod_8(IntPoint intPoint_0, IntPoint intPoint_1, double double_0)
	{
		double num = (double)intPoint_0.X - (double)intPoint_1.X;
		double num2 = (double)intPoint_0.Y - (double)intPoint_1.Y;
		return num * num + num2 * num2 <= double_0;
	}

	private static OutPt smethod_9(OutPt outPt_0)
	{
		OutPt prev = outPt_0.Prev;
		prev.Next = outPt_0.Next;
		outPt_0.Next.Prev = prev;
		prev.Idx = 0;
		return prev;
	}

	public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
	{
		int num = path.Count;
		if (num == 0)
		{
			return new List<IntPoint>();
		}
		OutPt[] array = new OutPt[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new OutPt();
		}
		for (int j = 0; j < num; j++)
		{
			array[j].Pt = path[j];
			array[j].Next = array[(j + 1) % num];
			array[j].Next.Prev = array[j];
			array[j].Idx = 0;
		}
		double double_ = distance * distance;
		OutPt outPt = array[0];
		while (outPt.Idx == 0 && outPt.Next != outPt.Prev)
		{
			if (!smethod_8(outPt.Pt, outPt.Prev.Pt, double_))
			{
				if (smethod_8(outPt.Prev.Pt, outPt.Next.Pt, double_))
				{
					smethod_9(outPt.Next);
					outPt = smethod_9(outPt);
					num -= 2;
				}
				else if (!smethod_7(outPt.Prev.Pt, outPt.Pt, outPt.Next.Pt, double_))
				{
					outPt.Idx = 1;
					outPt = outPt.Next;
				}
				else
				{
					outPt = smethod_9(outPt);
					num--;
				}
			}
			else
			{
				outPt = smethod_9(outPt);
				num--;
			}
		}
		if (num < 3)
		{
			num = 0;
		}
		List<IntPoint> list = new List<IntPoint>(num);
		for (int k = 0; k < num; k++)
		{
			list.Add(outPt.Pt);
			outPt = outPt.Next;
		}
		array = null;
		return list;
	}

	public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>(polys.Count);
		for (int i = 0; i < polys.Count; i++)
		{
			list.Add(CleanPolygon(polys[i], distance));
		}
		return list;
	}

	internal static List<List<IntPoint>> Minkowski(List<IntPoint> pattern, List<IntPoint> path, bool IsSum, bool IsClosed)
	{
		int num = (IsClosed ? 1 : 0);
		int count = pattern.Count;
		int count2 = path.Count;
		List<List<IntPoint>> list = new List<List<IntPoint>>(count2);
		if (IsSum)
		{
			for (int i = 0; i < count2; i++)
			{
				List<IntPoint> list2 = new List<IntPoint>(count);
				foreach (IntPoint item in pattern)
				{
					list2.Add(new IntPoint(path[i].X + item.X, path[i].Y + item.Y));
				}
				list.Add(list2);
			}
		}
		else
		{
			for (int j = 0; j < count2; j++)
			{
				List<IntPoint> list3 = new List<IntPoint>(count);
				foreach (IntPoint item2 in pattern)
				{
					list3.Add(new IntPoint(path[j].X - item2.X, path[j].Y - item2.Y));
				}
				list.Add(list3);
			}
		}
		List<List<IntPoint>> list4 = new List<List<IntPoint>>((count2 + num) * (count + 1));
		for (int k = 0; k < count2 - 1 + num; k++)
		{
			for (int l = 0; l < count; l++)
			{
				List<IntPoint> list5 = new List<IntPoint>(4);
				list5.Add(list[k % count2][l % count]);
				list5.Add(list[(k + 1) % count2][l % count]);
				list5.Add(list[(k + 1) % count2][(l + 1) % count]);
				list5.Add(list[k % count2][(l + 1) % count]);
				if (!Orientation(list5))
				{
					list5.Reverse();
				}
				list4.Add(list5);
			}
		}
		Clipper clipper = new Clipper();
		clipper.AddPaths(list4, PolyType.ptSubject, closed: true);
		clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<IntPoint> path, bool pathIsClosed)
	{
		return Minkowski(pattern, path, IsSum: true, pathIsClosed);
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<List<IntPoint>> paths, PolyFillType pathFillType, bool pathIsClosed)
	{
		Clipper clipper = new Clipper();
		for (int i = 0; i < paths.Count; i++)
		{
			List<List<IntPoint>> ppg = Minkowski(pattern, paths[i], IsSum: true, pathIsClosed);
			clipper.AddPaths(ppg, PolyType.ptSubject, closed: true);
		}
		if (pathIsClosed)
		{
			clipper.AddPaths(paths, PolyType.ptClip, closed: true);
		}
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctUnion, list, pathFillType, pathFillType);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2)
	{
		return Minkowski(poly1, poly2, IsSum: false, IsClosed: true);
	}

	public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		AddPolyNodeToPaths(polytree, NodeType.ntAny, list);
		return list;
	}

	internal static void AddPolyNodeToPaths(PolyNode polynode, NodeType nt, List<List<IntPoint>> paths)
	{
		bool flag = true;
		switch (nt)
		{
		case NodeType.ntClosed:
			flag = !polynode.IsOpen;
			break;
		case NodeType.ntOpen:
			return;
		}
		if (polynode.m_polygon.Count > 0 && flag)
		{
			paths.Add(polynode.m_polygon);
		}
		foreach (PolyNode child in polynode.Childs)
		{
			AddPolyNodeToPaths(child, nt, paths);
		}
	}

	public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.ChildCount;
		for (int i = 0; i < polytree.ChildCount; i++)
		{
			if (polytree.Childs[i].IsOpen)
			{
				list.Add(polytree.Childs[i].m_polygon);
			}
		}
		return list;
	}

	public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		AddPolyNodeToPaths(polytree, NodeType.ntClosed, list);
		return list;
	}

	static Clipper()
	{
		Class72.smethod_20();
	}
}
