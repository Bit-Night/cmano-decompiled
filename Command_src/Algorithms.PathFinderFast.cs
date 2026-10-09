using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Algorithms;

[Author("Franco, Gustavo")]
public sealed class PathFinderFast : IPathFinder
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[Author("Franco, Gustavo")]
	internal struct PathFinderNodeFast
	{
		public int F;

		public int G;

		public ushort PX;

		public ushort PY;

		public byte Status;

		public bool E;

		public bool W;
	}

	[Author("Franco, Gustavo")]
	internal class Class43 : IComparer<int>
	{
		private PathFinderNodeFast[] pathFinderNodeFast_0;

		public Class43(PathFinderNodeFast[] matrix)
		{
			pathFinderNodeFast_0 = matrix;
		}

		public int Compare(int a, int b)
		{
			if (pathFinderNodeFast_0[a].F > pathFinderNodeFast_0[b].F)
			{
				return 1;
			}
			if (pathFinderNodeFast_0[a].F >= pathFinderNodeFast_0[b].F)
			{
				return 0;
			}
			return -1;
		}

		static Class43()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private PathFinderDebugHandler pathFinderDebugHandler_0;

	private int[,] int_0;

	private PriorityQueueB<int> priorityQueueB_0;

	private List<PathFinderNode> list_0 = new List<PathFinderNode>();

	private bool RdJyvdfXeLg;

	private bool bool_0 = true;

	private int int_1;

	private HeuristicFormula heuristicFormula_0 = HeuristicFormula.Manhattan;

	private bool bool_1 = true;

	private int int_2 = 2;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private bool dspyvpVywSW;

	private bool bool_6;

	private int ymkyvlsJnyD = 2000;

	private double double_0;

	private bool bool_7;

	private bool vhgyviLtgdy;

	private PathFinderNodeFast[] pathFinderNodeFast_0;

	private byte byte_0 = 1;

	private byte byte_1 = 2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort cxtyvhqdUdi;

	private ushort ushort_2;

	private int int_7;

	private ushort ushort_3;

	private ushort ushort_4;

	private int int_8;

	private ushort ushort_5;

	private ushort ushort_6;

	private ushort ushort_7;

	private ushort ushort_8;

	private bool qPlyvXygZyk;

	private sbyte[,] sbyte_0 = new sbyte[8, 2]
	{
		{ 0, -1 },
		{ 1, 0 },
		{ 0, 1 },
		{ -1, 0 },
		{ 1, -1 },
		{ 1, 1 },
		{ -1, 1 },
		{ -1, -1 }
	};

	private int int_9;

	private int int_10;

	private static readonly double double_1;

	public bool Stopped => bool_0;

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
			if (bool_1)
			{
				sbyte_0 = new sbyte[8, 2]
				{
					{ 0, -1 },
					{ 1, 0 },
					{ 0, 1 },
					{ -1, 0 },
					{ 1, -1 },
					{ 1, 1 },
					{ -1, 1 },
					{ -1, -1 }
				};
			}
			else
			{
				sbyte_0 = new sbyte[4, 2]
				{
					{ 0, -1 },
					{ 1, 0 },
					{ 0, 1 },
					{ -1, 0 }
				};
			}
		}
	}

	public bool HeavyDiagonals
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

	public bool PunishWalkingOnEdge
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

	public bool TrimAutoNavPoints
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

	public bool ReopenCloseNodes
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

	public bool TieBreaker
	{
		get
		{
			return dspyvpVywSW;
		}
		set
		{
			dspyvpVywSW = value;
		}
	}

	public int SearchLimit
	{
		get
		{
			return ymkyvlsJnyD;
		}
		set
		{
			ymkyvlsJnyD = value;
		}
	}

	public int EdgeCost
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
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public bool DebugFoundPath
	{
		get
		{
			return vhgyviLtgdy;
		}
		set
		{
			vhgyviLtgdy = value;
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

	public PathFinderFast(int[,] grid)
	{
		if (grid != null)
		{
			int_0 = grid;
			ushort_5 = (ushort)(int_0.GetUpperBound(0) + 1);
			ushort_6 = (ushort)(int_0.GetUpperBound(1) + 1);
			ushort_7 = (ushort)(ushort_5 - 1);
			ushort_8 = (ushort)Math.Log((int)ushort_6, 2.0);
			if (Math.Log((int)ushort_5, 2.0) == (double)(int)Math.Log((int)ushort_5, 2.0) && Math.Log((int)ushort_6, 2.0) == (double)(int)Math.Log((int)ushort_6, 2.0))
			{
				if (pathFinderNodeFast_0 == null || pathFinderNodeFast_0.Length != ushort_5 * ushort_6)
				{
					pathFinderNodeFast_0 = new PathFinderNodeFast[ushort_5 * ushort_6];
				}
				priorityQueueB_0 = new PriorityQueueB<int>(new Class43(pathFinderNodeFast_0));
				return;
			}
			throw new Exception("Invalid Grid, size in X and Y must be power of 2");
		}
		throw new Exception("Grid cannot be null");
	}

	public void FindPathStop()
	{
		RdJyvdfXeLg = true;
	}

	public List<PathFinderNode> FindPath(Point start, Point end)
	{
		lock (this)
		{
			HighResolutionTime.Start();
			qPlyvXygZyk = false;
			RdJyvdfXeLg = false;
			bool_0 = false;
			int_8 = 0;
			byte_0 += 2;
			byte_1 += 2;
			priorityQueueB_0.Clear();
			list_0.Clear();
			if (bool_7 && pathFinderDebugHandler_0 != null)
			{
				pathFinderDebugHandler_0(0, 0, start.X, start.Y, PathFinderNodeType.Start, -1, -1);
			}
			if (bool_7 && pathFinderDebugHandler_0 != null)
			{
				pathFinderDebugHandler_0(0, 0, end.X, end.Y, PathFinderNodeType.End, -1, -1);
			}
			int_5 = (start.Y << (int)ushort_8) + start.X;
			int_9 = (end.Y << (int)ushort_8) + end.X;
			pathFinderNodeFast_0[int_5].G = 0;
			pathFinderNodeFast_0[int_5].F = int_2;
			pathFinderNodeFast_0[int_5].PX = (ushort)start.X;
			pathFinderNodeFast_0[int_5].PY = (ushort)start.Y;
			pathFinderNodeFast_0[int_5].Status = byte_0;
			priorityQueueB_0.Push(int_5);
			while (priorityQueueB_0.Count > 0 && !RdJyvdfXeLg)
			{
				int_5 = priorityQueueB_0.Pop();
				if (pathFinderNodeFast_0[int_5].Status == byte_1)
				{
					continue;
				}
				ushort_0 = (ushort)(int_5 & ushort_7);
				ushort_1 = (ushort)(int_5 >> (int)ushort_8);
				if (bool_7 && pathFinderDebugHandler_0 != null)
				{
					pathFinderDebugHandler_0(0, 0, int_5 & ushort_7, int_5 >> (int)ushort_8, PathFinderNodeType.Current, -1, -1);
				}
				if (int_5 != int_9)
				{
					if (int_8 <= ymkyvlsJnyD)
					{
						int num;
						if (bool_2)
						{
							int_1 = ushort_0 - pathFinderNodeFast_0[int_5].PX;
							num = 0;
						}
						else
						{
							num = 0;
						}
						for (int i = num; i < (bool_1 ? 8 : 4); i++)
						{
							cxtyvhqdUdi = (ushort)(ushort_0 + sbyte_0[i, 0]);
							ushort_2 = (ushort)(ushort_1 + sbyte_0[i, 1]);
							int_6 = (ushort_2 << (int)ushort_8) + cxtyvhqdUdi;
							if (cxtyvhqdUdi >= ushort_5 || ushort_2 >= ushort_6 || (pathFinderNodeFast_0[int_6].Status == byte_1 && !bool_5) || int_0[cxtyvhqdUdi, ushort_2] == 0)
							{
								continue;
							}
							if (int_0[cxtyvhqdUdi, ushort_2] == int_3)
							{
								pathFinderNodeFast_0[int_6].E = true;
							}
							if (bool_6 && i > 3)
							{
								int_10 = pathFinderNodeFast_0[int_5].G + (int)((double)int_0[cxtyvhqdUdi, ushort_2] * 2.41);
							}
							else if (i > 3)
							{
								int_10 = pathFinderNodeFast_0[int_5].G + (int)((double)int_0[cxtyvhqdUdi, ushort_2] * double_1);
							}
							else
							{
								int_10 = pathFinderNodeFast_0[int_5].G + int_0[cxtyvhqdUdi, ushort_2];
							}
							if (bool_2)
							{
								if (cxtyvhqdUdi - ushort_0 != 0 && int_1 == 0)
								{
									int_10 += Math.Abs(cxtyvhqdUdi - end.X) + Math.Abs(ushort_2 - end.Y);
								}
								if (ushort_2 - ushort_1 != 0 && int_1 != 0)
								{
									int_10 += Math.Abs(cxtyvhqdUdi - end.X) + Math.Abs(ushort_2 - end.Y);
								}
							}
							if ((pathFinderNodeFast_0[int_6].Status != byte_0 && pathFinderNodeFast_0[int_6].Status != byte_1) || pathFinderNodeFast_0[int_6].G > int_10)
							{
								pathFinderNodeFast_0[int_6].PX = ushort_0;
								pathFinderNodeFast_0[int_6].PY = ushort_1;
								pathFinderNodeFast_0[int_6].G = int_10;
								switch (heuristicFormula_0)
								{
								default:
									int_4 = int_2 * (Math.Abs(cxtyvhqdUdi - end.X) + Math.Abs(ushort_2 - end.Y));
									break;
								case HeuristicFormula.MaxDXDY:
									int_4 = int_2 * Math.Max(Math.Abs(cxtyvhqdUdi - end.X), Math.Abs(ushort_2 - end.Y));
									break;
								case HeuristicFormula.DiagonalShortCut:
								{
									int num4 = Math.Min(Math.Abs(cxtyvhqdUdi - end.X), Math.Abs(ushort_2 - end.Y));
									int num5 = Math.Abs(cxtyvhqdUdi - end.X) + Math.Abs(ushort_2 - end.Y);
									int_4 = int_2 * 2 * num4 + int_2 * (num5 - 2 * num4);
									break;
								}
								case HeuristicFormula.Euclidean:
									int_4 = (int)((double)int_2 * Math.Sqrt(Math.Pow(cxtyvhqdUdi - end.X, 2.0) + Math.Pow(ushort_2 - end.Y, 2.0)));
									break;
								case HeuristicFormula.EuclideanNoSQR:
									int_4 = (int)((double)int_2 * (Math.Pow(cxtyvhqdUdi - end.X, 2.0) + Math.Pow(ushort_2 - end.Y, 2.0)));
									break;
								case HeuristicFormula.Custom1:
								{
									Point point = new Point(Math.Abs(end.X - cxtyvhqdUdi), Math.Abs(end.Y - ushort_2));
									int num2 = Math.Abs(point.X - point.Y);
									int num3 = Math.Abs((point.X + point.Y - num2) / 2);
									int_4 = int_2 * (num3 + num2 + point.X + point.Y);
									break;
								}
								}
								if (dspyvpVywSW)
								{
									int num6 = ushort_0 - end.X;
									int num7 = ushort_1 - end.Y;
									int num8 = start.X - end.X;
									int num9 = start.Y - end.Y;
									int num10 = Math.Abs(num6 * num9 - num8 * num7);
									int_4 = (int)((double)int_4 + (double)num10 * 0.001);
								}
								pathFinderNodeFast_0[int_6].F = int_10 + int_4;
								if (bool_7 && pathFinderDebugHandler_0 != null)
								{
									pathFinderDebugHandler_0(ushort_0, ushort_1, cxtyvhqdUdi, ushort_2, PathFinderNodeType.Open, pathFinderNodeFast_0[int_6].F, pathFinderNodeFast_0[int_6].G);
								}
								priorityQueueB_0.Push(int_6);
								pathFinderNodeFast_0[int_6].Status = byte_0;
							}
						}
						int_8++;
						pathFinderNodeFast_0[int_5].Status = byte_1;
						if (bool_7 && pathFinderDebugHandler_0 != null)
						{
							pathFinderDebugHandler_0(0, 0, ushort_0, ushort_1, PathFinderNodeType.Close, pathFinderNodeFast_0[int_5].F, pathFinderNodeFast_0[int_5].G);
						}
						continue;
					}
					bool_0 = true;
					double_0 = HighResolutionTime.GetTime();
					return null;
				}
				pathFinderNodeFast_0[int_5].Status = byte_1;
				qPlyvXygZyk = true;
				break;
			}
			if (bool_3)
			{
				int num11 = 0;
				int num14;
				while (true)
				{
					if (num11 < (bool_1 ? 8 : 4))
					{
						ushort num12 = (ushort)(start.X + sbyte_0[num11, 0]);
						ushort num13 = (ushort)(start.Y + sbyte_0[num11, 1]);
						if (num12 >= ushort_5 || num13 >= ushort_6 || int_0[num12, num13] != 0)
						{
							num11++;
							continue;
						}
						pathFinderNodeFast_0[int_5].E = true;
						num14 = 0;
						break;
					}
					num14 = 0;
					break;
				}
				for (int j = num14; j < (bool_1 ? 8 : 4); j++)
				{
					ushort num15 = (ushort)(end.X + sbyte_0[j, 0]);
					ushort num16 = (ushort)(end.Y + sbyte_0[j, 1]);
					if (num15 < ushort_5 && num16 < ushort_6 && int_0[num15, num16] == 0)
					{
						pathFinderNodeFast_0[int_9].E = true;
						break;
					}
				}
			}
			double_0 = HighResolutionTime.GetTime();
			if (!qPlyvXygZyk)
			{
				bool_0 = true;
				return null;
			}
			list_0.Clear();
			int x = end.X;
			int y = end.Y;
			PathFinderNodeFast pathFinderNodeFast = pathFinderNodeFast_0[(end.Y << (int)ushort_8) + end.X];
			PathFinderNode item = default(PathFinderNode);
			item.F = pathFinderNodeFast.F;
			item.G = pathFinderNodeFast.G;
			item.H = 0;
			item.PX = pathFinderNodeFast.PX;
			item.PY = pathFinderNodeFast.PY;
			item.X = end.X;
			item.Y = end.Y;
			item.E = pathFinderNodeFast.E;
			item.W = pathFinderNodeFast.W;
			while (item.X != item.PX || item.Y != item.PY)
			{
				list_0.Add(item);
				if (vhgyviLtgdy && pathFinderDebugHandler_0 != null)
				{
					pathFinderDebugHandler_0(item.PX, item.PY, item.X, item.Y, PathFinderNodeType.Path, item.F, item.G);
				}
				x = item.PX;
				y = item.PY;
				pathFinderNodeFast = pathFinderNodeFast_0[(y << (int)ushort_8) + x];
				item.F = pathFinderNodeFast.F;
				item.G = pathFinderNodeFast.G;
				item.H = 0;
				item.PX = pathFinderNodeFast.PX;
				item.PY = pathFinderNodeFast.PY;
				item.X = x;
				item.Y = y;
				item.E = pathFinderNodeFast.E;
				item.W = pathFinderNodeFast.W;
			}
			list_0.Add(item);
			if (vhgyviLtgdy && pathFinderDebugHandler_0 != null)
			{
				pathFinderDebugHandler_0(item.PX, item.PY, item.X, item.Y, PathFinderNodeType.Path, item.F, item.G);
			}
			int Count = list_0.Count;
			if (bool_4 && Count > 0)
			{
				List<PathFinderNode> list = new List<PathFinderNode>();
				for (int i2 = Count - 1; i2 > -1; i2--)
				{
					PathFinderNode theNode = list_0[i2];
					if (FindWaypoint(ref i2, ref Count, ref theNode, ForwardDirection: false))
					{
						theNode = list_0[i2];
						theNode.W = true;
						list_0[i2] = theNode;
					}
				}
				for (int k = 0; k < Count; k++)
				{
					PathFinderNode theNode = list_0[k];
					if (!theNode.W && (k >= Count - 1 || !list_0[k + 1].W) && (k <= 1 || !list_0[k - 1].W) && FindWaypoint(ref k, ref Count, ref theNode, ForwardDirection: true))
					{
						theNode = list_0[k];
						theNode.W = true;
						list_0[k] = theNode;
					}
				}
				for (int l = 0; l < Count; l++)
				{
					PathFinderNode theNode = list_0[l];
					if (theNode.W)
					{
						list.Add(theNode);
					}
				}
				if (list.Count > 0)
				{
					list_0 = null;
					list_0 = list;
				}
			}
			bool_0 = true;
			return list_0;
		}
	}

	public bool FindWaypoint(ref int i, ref int Count, ref PathFinderNode theNode, bool ForwardDirection)
	{
		int num = -1;
		if (i == Count - 1)
		{
			if (theNode.E)
			{
				return true;
			}
			return false;
		}
		if (i == 0)
		{
			if (!theNode.E)
			{
				return false;
			}
			return true;
		}
		if (!theNode.E)
		{
			int x = theNode.X;
			int y = theNode.Y;
			int num2;
			int num3;
			if (!ForwardDirection)
			{
				int x2 = list_0[i + 1].X;
				int y2 = list_0[i + 1].Y;
				num2 = x - x2;
				num3 = y - y2;
			}
			else
			{
				int x2 = list_0[i - 1].X;
				int y2 = list_0[i - 1].Y;
				num2 = x2 - x;
				num3 = y2 - y;
			}
			if (num2 > 0)
			{
				num = ((num3 > 0) ? 1 : ((num3 < 0) ? 3 : 2));
			}
			else if (num2 < 0)
			{
				num = ((num3 > 0) ? 7 : ((num3 < 0) ? 5 : 6));
			}
			else if (num3 <= 0)
			{
				if (num3 >= 0)
				{
					return false;
				}
				num = 4;
			}
			else
			{
				num = 0;
			}
			int x3 = theNode.X;
			int x4 = theNode.X;
			int y3 = theNode.Y;
			int y4 = theNode.Y;
			int num4 = i;
			while (true)
			{
				if (num4 >= 1)
				{
					if (num4 > Count - 2)
					{
						break;
					}
					PathFinderNode pathFinderNode = list_0[num4];
					PathFinderNode pathFinderNode2;
					if (!ForwardDirection)
					{
						pathFinderNode2 = list_0[num4 - 1];
						num2 = pathFinderNode2.X - pathFinderNode.X;
						num3 = pathFinderNode2.Y - pathFinderNode.Y;
					}
					else
					{
						pathFinderNode2 = list_0[num4 + 1];
						num2 = pathFinderNode.X - pathFinderNode2.X;
						num3 = pathFinderNode.Y - pathFinderNode2.Y;
					}
					switch (num)
					{
					case 1:
						if (num3 < 0 || num2 < 0)
						{
							i = num4;
							return true;
						}
						goto default;
					case 2:
						if (num3 <= Math.Abs(num2))
						{
							goto default;
						}
						i = num4;
						return true;
					case 3:
						if (num3 > 0 || num2 < 0)
						{
							i = num4;
							return true;
						}
						goto default;
					case 4:
						if (Math.Abs(num2) > Math.Abs(num3))
						{
							i = num4;
							return true;
						}
						goto default;
					case 5:
						if (num3 <= 0 && num2 <= 0)
						{
							goto default;
						}
						i = num4;
						return true;
					case 6:
						if (Math.Abs(num3) > Math.Abs(num2))
						{
							i = num4;
							return true;
						}
						goto default;
					case 7:
						if (num3 < 0 || num2 > 0)
						{
							i = num4;
							return true;
						}
						goto default;
					case 0:
						if (num2 > Math.Abs(num3))
						{
							i = num4;
							return true;
						}
						goto default;
					default:
						if (pathFinderNode2.X <= x3)
						{
							if (pathFinderNode2.X < x4)
							{
								x4 = pathFinderNode2.X;
								for (int j = y4; j <= y3; j++)
								{
									if (int_0[pathFinderNode2.X, j] == 0 || pathFinderNode2.E)
									{
										i = num4;
										return true;
									}
								}
							}
						}
						else
						{
							x3 = pathFinderNode2.X;
							for (int k = y4; k <= y3; k++)
							{
								if (int_0[pathFinderNode2.X, k] == 0 || pathFinderNode2.E)
								{
									i = num4;
									return true;
								}
							}
						}
						if (pathFinderNode2.Y <= y3)
						{
							if (pathFinderNode2.Y < y4)
							{
								y4 = pathFinderNode2.Y;
								for (int l = x4; l <= x3; l++)
								{
									if (int_0[l, pathFinderNode2.Y] == 0 || pathFinderNode2.E)
									{
										i = num4;
										return true;
									}
								}
							}
						}
						else
						{
							y3 = pathFinderNode2.Y;
							for (int m = x4; m <= x3; m++)
							{
								if (int_0[m, pathFinderNode2.Y] == 0 || pathFinderNode2.E)
								{
									i = num4;
									return true;
								}
							}
						}
						num4 = ((!ForwardDirection) ? (num4 - 1) : (num4 + 1));
						break;
					}
					continue;
				}
				i = num4 + 1;
				return false;
			}
			i = num4 - 1;
			return false;
		}
		return true;
	}

	static PathFinderFast()
	{
		Class72.smethod_20();
		double_1 = Math.Sqrt(2.0);
	}
}
