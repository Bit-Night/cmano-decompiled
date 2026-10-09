using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Algorithms;

[Author("Franco, Gustavo")]
public sealed class PathFinder : IPathFinder
{
	[Author("Franco, Gustavo")]
	internal class ComparePFNode : IComparer<PathFinderNode>
	{
		public int Compare(PathFinderNode x, PathFinderNode y)
		{
			if (x.F > y.F)
			{
				return 1;
			}
			if (x.F < y.F)
			{
				return -1;
			}
			return 0;
		}

		static ComparePFNode()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private PathFinderDebugHandler pathFinderDebugHandler_0;

	private int[,] int_0;

	private PriorityQueueB<PathFinderNode> priorityQueueB_0 = new PriorityQueueB<PathFinderNode>(new ComparePFNode());

	private List<PathFinderNode> list_0 = new List<PathFinderNode>();

	private bool bool_0;

	private bool vtSyKxiftLT = true;

	private int int_1;

	private HeuristicFormula heuristicFormula_0 = HeuristicFormula.Manhattan;

	private bool bool_1 = true;

	private int int_2 = 2;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private int int_3 = 2000;

	private double double_0;

	private bool bool_6;

	private bool bool_7;

	public bool Stopped => vtSyKxiftLT;

	public HeuristicFormula Formula
	{
		get
		{
			return heuristicFormula_0;
		}
		set
		{
			heuristicFormula_0 = value;
		}
	}

	public bool Diagonals
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool HeavyDiagonals
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public int HeuristicEstimate
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public bool PunishChangeDirection
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool ReopenCloseNodes
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool TieBreaker
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public int SearchLimit
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public double CompletedTime
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public bool DebugProgress
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool DebugFoundPath
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public event PathFinderDebugHandler PathFinderDebug
	{
		[CompilerGenerated]
		add
		{
			PathFinderDebugHandler pathFinderDebugHandler = pathFinderDebugHandler_0;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Combine(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref pathFinderDebugHandler_0, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathFinderDebugHandler pathFinderDebugHandler = pathFinderDebugHandler_0;
			PathFinderDebugHandler pathFinderDebugHandler2;
			do
			{
				pathFinderDebugHandler2 = pathFinderDebugHandler;
				PathFinderDebugHandler value2 = (PathFinderDebugHandler)Delegate.Remove(pathFinderDebugHandler2, value);
				pathFinderDebugHandler = Interlocked.CompareExchange(ref pathFinderDebugHandler_0, value2, pathFinderDebugHandler2);
			}
			while ((object)pathFinderDebugHandler != pathFinderDebugHandler2);
		}
	}

	[DllImport("kernel32.dll")]
	public unsafe static extern bool RtlZeroMemory(byte* destination, int length);

	public PathFinder(int[,] grid)
	{
		if (grid == null)
		{
			throw new Exception("Grid cannot be null");
		}
		int_0 = grid;
	}

	public void FindPathStop()
	{
		bool_0 = true;
	}

	public List<PathFinderNode> FindPath(Point start, Point end)
	{
		HighResolutionTime.Start();
		bool flag = false;
		int upperBound = int_0.GetUpperBound(0);
		int upperBound2 = int_0.GetUpperBound(1);
		bool_0 = false;
		vtSyKxiftLT = false;
		priorityQueueB_0.Clear();
		list_0.Clear();
		if (bool_6 && pathFinderDebugHandler_0 != null)
		{
			pathFinderDebugHandler_0(0, 0, start.X, start.Y, PathFinderNodeType.Start, -1, -1);
		}
		if (bool_6 && pathFinderDebugHandler_0 != null)
		{
			pathFinderDebugHandler_0(0, 0, end.X, end.Y, PathFinderNodeType.End, -1, -1);
		}
		sbyte[,] array = ((!bool_1) ? new sbyte[4, 2]
		{
			{ 0, -1 },
			{ 1, 0 },
			{ 0, 1 },
			{ -1, 0 }
		} : new sbyte[8, 2]
		{
			{ 0, -1 },
			{ 1, 0 },
			{ 0, 1 },
			{ -1, 0 },
			{ 1, -1 },
			{ 1, 1 },
			{ -1, 1 },
			{ -1, -1 }
		});
		PathFinderNode item = default(PathFinderNode);
		item.G = 0;
		item.H = int_2;
		item.F = item.G + item.H;
		item.X = start.X;
		item.Y = start.Y;
		item.PX = item.X;
		item.PY = item.Y;
		item.E = false;
		item.W = false;
		priorityQueueB_0.Push(item);
		PathFinderNode item2 = default(PathFinderNode);
		while (priorityQueueB_0.Count > 0 && !bool_0)
		{
			item = priorityQueueB_0.Pop();
			if (bool_6 && pathFinderDebugHandler_0 != null)
			{
				pathFinderDebugHandler_0(0, 0, item.X, item.Y, PathFinderNodeType.Current, -1, -1);
			}
			if (item.X != end.X || item.Y != end.Y)
			{
				if (list_0.Count <= int_3)
				{
					int num;
					if (!bool_2)
					{
						num = 0;
					}
					else
					{
						int_1 = item.X - item.PX;
						num = 0;
					}
					for (int i = num; i < ((!bool_1) ? 4 : 8); i++)
					{
						item2.X = item.X + array[i, 0];
						item2.Y = item.Y + array[i, 1];
						item2.E = false;
						item2.W = false;
						if (item2.X < 0 || item2.Y < 0 || item2.X >= upperBound || item2.Y >= upperBound2)
						{
							continue;
						}
						int num2 = ((!bool_5 || i <= 3) ? (item.G + int_0[item2.X, item2.Y]) : (item.G + (int)((double)int_0[item2.X, item2.Y] * 2.41)));
						if (num2 == item.G)
						{
							continue;
						}
						int num3;
						if (!bool_2)
						{
							num3 = -1;
						}
						else
						{
							if (item2.X - item.X != 0 && int_1 == 0)
							{
								num2 += 20;
							}
							if (item2.Y - item.Y == 0)
							{
								num3 = -1;
							}
							else if (int_1 == 0)
							{
								num3 = -1;
							}
							else
							{
								num2 += 20;
								num3 = -1;
							}
						}
						int num4 = num3;
						for (int j = 0; j < priorityQueueB_0.Count; j++)
						{
							if (priorityQueueB_0[j].X == item2.X && priorityQueueB_0[j].Y == item2.Y)
							{
								num4 = j;
								break;
							}
						}
						int num5;
						if (num4 != -1)
						{
							if (priorityQueueB_0[num4].G <= num2)
							{
								continue;
							}
							num5 = -1;
						}
						else
						{
							num5 = -1;
						}
						int num6 = num5;
						for (int k = 0; k < list_0.Count; k++)
						{
							if (list_0[k].X == item2.X && list_0[k].Y == item2.Y)
							{
								num6 = k;
								break;
							}
						}
						if (num6 == -1 || (!bool_3 && list_0[num6].G > num2))
						{
							item2.PX = item.X;
							item2.PY = item.Y;
							item2.G = num2;
							switch (heuristicFormula_0)
							{
							default:
								item2.H = int_2 * (Math.Abs(item2.X - end.X) + Math.Abs(item2.Y - end.Y));
								break;
							case HeuristicFormula.MaxDXDY:
								item2.H = int_2 * Math.Max(Math.Abs(item2.X - end.X), Math.Abs(item2.Y - end.Y));
								break;
							case HeuristicFormula.DiagonalShortCut:
							{
								int num9 = Math.Min(Math.Abs(item2.X - end.X), Math.Abs(item2.Y - end.Y));
								int num10 = Math.Abs(item2.X - end.X) + Math.Abs(item2.Y - end.Y);
								item2.H = int_2 * 2 * num9 + int_2 * (num10 - 2 * num9);
								break;
							}
							case HeuristicFormula.Euclidean:
								item2.H = (int)((double)int_2 * Math.Sqrt(Math.Pow(item2.X - end.X, 2.0) + Math.Pow(item2.Y - end.Y, 2.0)));
								break;
							case HeuristicFormula.EuclideanNoSQR:
								item2.H = (int)((double)int_2 * (Math.Pow(item2.X - end.X, 2.0) + Math.Pow(item2.Y - end.Y, 2.0)));
								break;
							case HeuristicFormula.Custom1:
							{
								Point point = new Point(Math.Abs(end.X - item2.X), Math.Abs(end.Y - item2.Y));
								int num7 = Math.Abs(point.X - point.Y);
								int num8 = Math.Abs((point.X + point.Y - num7) / 2);
								item2.H = int_2 * (num8 + num7 + point.X + point.Y);
								break;
							}
							}
							if (bool_4)
							{
								int num11 = item.X - end.X;
								int num12 = item.Y - end.Y;
								int num13 = start.X - end.X;
								int num14 = start.Y - end.Y;
								int num15 = Math.Abs(num11 * num14 - num13 * num12);
								item2.H = (int)((double)item2.H + (double)num15 * 0.001);
							}
							item2.F = item2.G + item2.H;
							if (bool_6 && pathFinderDebugHandler_0 != null)
							{
								pathFinderDebugHandler_0(item.X, item.Y, item2.X, item2.Y, PathFinderNodeType.Open, item2.F, item2.G);
							}
							priorityQueueB_0.Push(item2);
						}
					}
					list_0.Add(item);
					if (bool_6 && pathFinderDebugHandler_0 != null)
					{
						pathFinderDebugHandler_0(0, 0, item.X, item.Y, PathFinderNodeType.Close, item.F, item.G);
					}
					continue;
				}
				vtSyKxiftLT = true;
				return null;
			}
			list_0.Add(item);
			flag = true;
			break;
		}
		double_0 = HighResolutionTime.GetTime();
		if (flag)
		{
			PathFinderNode pathFinderNode = list_0[list_0.Count - 1];
			for (int num16 = list_0.Count - 1; num16 >= 0; num16--)
			{
				if ((pathFinderNode.PX == list_0[num16].X && pathFinderNode.PY == list_0[num16].Y) || num16 == list_0.Count - 1)
				{
					if (bool_7 && pathFinderDebugHandler_0 != null)
					{
						pathFinderDebugHandler_0(pathFinderNode.X, pathFinderNode.Y, list_0[num16].X, list_0[num16].Y, PathFinderNodeType.Path, list_0[num16].F, list_0[num16].G);
					}
					pathFinderNode = list_0[num16];
				}
				else
				{
					list_0.RemoveAt(num16);
				}
			}
			vtSyKxiftLT = true;
			return list_0;
		}
		vtSyKxiftLT = true;
		return null;
	}

	static PathFinder()
	{
		Class72.smethod_20();
	}
}
