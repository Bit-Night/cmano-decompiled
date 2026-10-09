using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace SettlersEngine;

public class SpatialAStar<T, TUserContext> where T : IPathNode<TUserContext>
{
	protected class PathNode : IPathNode<TUserContext>, IComparer<PathNode>, IIndexedObject
	{
		public static readonly PathNode Comparer;

		[CompilerGenerated]
		private T gparam_0;

		[CompilerGenerated]
		private float float_0;

		[CompilerGenerated]
		private float float_1;

		[CompilerGenerated]
		private float float_2;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		internal static object object_0;

		public T UserContext
		{
			[CompilerGenerated]
			get
			{
				return gparam_0;
			}
			[CompilerGenerated]
			internal set
			{
				gparam_0 = value;
			}
		}

		public float G
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			internal set
			{
				float_0 = value;
			}
		}

		public float H
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			internal set
			{
				float_1 = value;
			}
		}

		public float F
		{
			[CompilerGenerated]
			get
			{
				return float_2;
			}
			[CompilerGenerated]
			internal set
			{
				float_2 = value;
			}
		}

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public int X
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			internal set
			{
				int_1 = value;
			}
		}

		public int Y
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			internal set
			{
				int_2 = value;
			}
		}

		public bool IsWalkable(TUserContext inContext)
		{
			return UserContext.IsWalkable(inContext);
		}

		public int Compare(PathNode x, PathNode y)
		{
			if (x.F < y.F)
			{
				return -1;
			}
			if (x.F > y.F)
			{
				return 1;
			}
			return 0;
		}

		public PathNode(short inX, short inY, T inUserContext)
		{
			X = inX;
			Y = inY;
			UserContext = inUserContext;
		}

		static PathNode()
		{
			Class72.smethod_20();
			Comparer = new PathNode(0, 0, default(T));
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private class Class42
	{
		private PathNode[,] pathNode_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		internal static object object_0;

		public int Width
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			private set
			{
				int_0 = value;
			}
		}

		public int Height
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			private set
			{
				int_1 = value;
			}
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			private set
			{
				int_2 = value;
			}
		}

		public PathNode this[int int_3, int int_4] => pathNode_0[int_3, int_4];

		public PathNode this[PathNode pathNode_1] => pathNode_0[pathNode_1.X, pathNode_1.Y];

		[SpecialName]
		public bool method_0()
		{
			return Count == 0;
		}

		public Class42(int int_3, int int_4)
		{
			pathNode_0 = new PathNode[int_3, int_4];
			Width = int_3;
			Height = int_4;
		}

		public void Add(PathNode inValue)
		{
			_ = pathNode_0[inValue.X, inValue.Y];
			Count++;
			pathNode_0[inValue.X, inValue.Y] = inValue;
		}

		public bool method_1(PathNode pathNode_1)
		{
			if (pathNode_0[pathNode_1.X, pathNode_1.Y] == null)
			{
				return false;
			}
			return true;
		}

		public void Remove(PathNode inValue)
		{
			_ = pathNode_0[inValue.X, inValue.Y];
			Count--;
			pathNode_0[inValue.X, inValue.Y] = null;
		}

		public void Clear()
		{
			Count = 0;
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					pathNode_0[i, j] = null;
				}
			}
		}

		static Class42()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private Class42 class42_0;

	private Class42 class42_1;

	private PriorityQueue<PathNode> priorityQueue_0;

	private PathNode[,] pathNode_0;

	private Class42 class42_2;

	private PathNode[,] pathNode_1;

	[CompilerGenerated]
	private T[,] gparam_0;

	[CompilerGenerated]
	private short DcayKfdiXac;

	[CompilerGenerated]
	private short short_0;

	private static readonly double double_0;

	private static object object_0;

	public T[,] SearchSpace
	{
		[CompilerGenerated]
		get
		{
			return gparam_0;
		}
		[CompilerGenerated]
		private set
		{
			gparam_0 = value;
		}
	}

	public short Width
	{
		[CompilerGenerated]
		get
		{
			return DcayKfdiXac;
		}
		[CompilerGenerated]
		private set
		{
			DcayKfdiXac = value;
		}
	}

	public short Height
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		private set
		{
			short_0 = value;
		}
	}

	public SpatialAStar(T[,] inGrid)
	{
		SearchSpace = inGrid;
		Width = (short)inGrid.GetLength(0);
		Height = (short)inGrid.GetLength(1);
		pathNode_1 = new PathNode[Width, Height];
		class42_0 = new Class42(Width, Height);
		class42_1 = new Class42(Width, Height);
		pathNode_0 = new PathNode[Width, Height];
		class42_2 = new Class42(Width, Height);
		priorityQueue_0 = new PriorityQueue<PathNode>(PathNode.Comparer);
		for (short num = 0; num < Width; num++)
		{
			short num2 = 0;
			while (num2 < Height)
			{
				if (inGrid[num, num2] != null)
				{
					pathNode_1[num, num2] = new PathNode(num, num2, inGrid[num, num2]);
					num2++;
					continue;
				}
				throw new ArgumentNullException(Class72.smethod_14(1907528) + num + Class72.smethod_14(1907582) + num2);
			}
		}
	}

	protected virtual double Heuristic(PathNode inStart, PathNode inEnd)
	{
		return Math.Sqrt((inStart.X - inEnd.X) * (inStart.X - inEnd.X) + (inStart.Y - inEnd.Y) * (inStart.Y - inEnd.Y));
	}

	protected virtual double NeighborDistance(PathNode inStart, PathNode inEnd)
	{
		int num = Math.Abs(inStart.X - inEnd.X);
		int num2 = Math.Abs(inStart.Y - inEnd.Y);
		return (num + num2) switch
		{
			0 => 0.0, 
			1 => 1.0, 
			2 => double_0, 
			_ => throw new ApplicationException(), 
		};
	}

	public LinkedList<T> Search(Point inStartNode, Point inEndNode, TUserContext inUserContext)
	{
		PathNode pathNode = pathNode_1[inStartNode.X, inStartNode.Y];
		PathNode pathNode2 = pathNode_1[inEndNode.X, inEndNode.Y];
		if (pathNode == pathNode2)
		{
			return new LinkedList<T>(new T[1] { pathNode.UserContext });
		}
		PathNode[] array = new PathNode[8];
		class42_0.Clear();
		class42_1.Clear();
		class42_2.Clear();
		priorityQueue_0.Clear();
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				pathNode_0[i, j] = null;
			}
		}
		pathNode.G = 0f;
		pathNode.H = (float)Heuristic(pathNode, pathNode2);
		pathNode.F = pathNode.H;
		class42_1.Add(pathNode);
		priorityQueue_0.Push(pathNode);
		class42_2.Add(pathNode);
		int num = 0;
		while (true)
		{
			if (!class42_1.method_0())
			{
				PathNode pathNode3 = priorityQueue_0.Pop();
				if (pathNode3 == pathNode2)
				{
					break;
				}
				class42_1.Remove(pathNode3);
				class42_0.Add(pathNode3);
				method_2(pathNode3, array);
				foreach (PathNode pathNode4 in array)
				{
					if (pathNode4 == null || !pathNode4.UserContext.IsWalkable(inUserContext) || class42_0.method_1(pathNode4))
					{
						continue;
					}
					num++;
					double num2 = (double)class42_2[pathNode3].G + NeighborDistance(pathNode3, pathNode4);
					bool flag = false;
					bool flag2;
					if (class42_1.method_1(pathNode4))
					{
						flag2 = ((num2 < (double)class42_2[pathNode4].G) ? true : false);
					}
					else
					{
						class42_1.Add(pathNode4);
						flag2 = true;
						flag = true;
					}
					if (flag2)
					{
						pathNode_0[pathNode4.X, pathNode4.Y] = pathNode3;
						if (!class42_2.method_1(pathNode4))
						{
							class42_2.Add(pathNode4);
						}
						class42_2[pathNode4].G = (float)num2;
						class42_2[pathNode4].H = (float)Heuristic(pathNode4, pathNode2);
						class42_2[pathNode4].F = class42_2[pathNode4].G + class42_2[pathNode4].H;
						if (flag)
						{
							priorityQueue_0.Push(pathNode4);
						}
						else
						{
							priorityQueue_0.Update(pathNode4);
						}
					}
				}
				continue;
			}
			return null;
		}
		LinkedList<T> linkedList = method_0(pathNode_0, pathNode_0[pathNode2.X, pathNode2.Y]);
		linkedList.AddLast(pathNode2.UserContext);
		return linkedList;
	}

	private LinkedList<T> method_0(PathNode[,] pathNode_2, PathNode pathNode_3)
	{
		LinkedList<T> linkedList = new LinkedList<T>();
		method_1(pathNode_2, pathNode_3, linkedList);
		return linkedList;
	}

	private void method_1(PathNode[,] pathNode_2, PathNode pathNode_3, LinkedList<T> linkedList_0)
	{
		PathNode pathNode = pathNode_2[pathNode_3.X, pathNode_3.Y];
		if (pathNode == null)
		{
			linkedList_0.AddLast(pathNode_3.UserContext);
			return;
		}
		method_1(pathNode_2, pathNode, linkedList_0);
		linkedList_0.AddLast(pathNode_3.UserContext);
	}

	private void method_2(PathNode pathNode_2, PathNode[] pathNode_3)
	{
		int x = pathNode_2.X;
		int y = pathNode_2.Y;
		if (x > 0 && y > 0)
		{
			pathNode_3[0] = pathNode_1[x - 1, y - 1];
		}
		else
		{
			pathNode_3[0] = null;
		}
		if (y <= 0)
		{
			pathNode_3[1] = null;
		}
		else
		{
			pathNode_3[1] = pathNode_1[x, y - 1];
		}
		if (x < Width - 1 && y > 0)
		{
			pathNode_3[2] = pathNode_1[x + 1, y - 1];
		}
		else
		{
			pathNode_3[2] = null;
		}
		if (x <= 0)
		{
			pathNode_3[3] = null;
		}
		else
		{
			pathNode_3[3] = pathNode_1[x - 1, y];
		}
		if (x < Width - 1)
		{
			pathNode_3[4] = pathNode_1[x + 1, y];
		}
		else
		{
			pathNode_3[4] = null;
		}
		if (x > 0 && y < Height - 1)
		{
			pathNode_3[5] = pathNode_1[x - 1, y + 1];
		}
		else
		{
			pathNode_3[5] = null;
		}
		if (y < Height - 1)
		{
			pathNode_3[6] = pathNode_1[x, y + 1];
		}
		else
		{
			pathNode_3[6] = null;
		}
		if (x < Width - 1 && y < Height - 1)
		{
			pathNode_3[7] = pathNode_1[x + 1, y + 1];
		}
		else
		{
			pathNode_3[7] = null;
		}
	}

	static SpatialAStar()
	{
		Class72.smethod_20();
		double_0 = Math.Sqrt(2.0);
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
