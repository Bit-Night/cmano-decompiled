using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class RBWQuadTree
{
	public enum TNorthOrSouth
	{
		North,
		South
	}

	public enum TEastOrWest
	{
		East,
		West
	}

	[Serializable]
	public struct TQPoint<T>
	{
		public double X;

		public double Y;

		public List<T> Data;
	}

	[Serializable]
	public struct TQuadPoint<T>
	{
		public double X;

		public double Y;

		public double Distance;

		public List<T> Data;
	}

	[Serializable]
	public struct GStruct1<T>
	{
		public double X;

		public double Y;

		public List<T> Data;
	}

	public enum TExpandDirection
	{
		edNorth,
		edSouth,
		edEast,
		edWest
	}

	[Serializable]
	public struct T2DBlock
	{
		public double XMin;

		public double XMax;

		public double YMin;

		public double YMax;
	}

	[Serializable]
	public sealed class TQTreeNode<T>
	{
		protected internal int FNumPts;

		protected TQTreeNode<T>[] Children;

		protected internal double Xmin;

		protected internal double Xmax;

		protected internal double Ymin;

		protected internal double Ymax;

		protected internal TQPoint<T>[] Pts;

		protected TQTreeNode<T> Parent;

		protected TRbwQuadTree<T> Tree;

		internal static object object_0;

		protected internal int NumPts
		{
			get
			{
				return FNumPts;
			}
			set
			{
				method_1(value);
			}
		}

		public TQPoint<T> Points => method_2(Index);

		private void method_0()
		{
			if (Children[1] == null)
			{
				return;
			}
			int num = 0;
			TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
			int num2 = 0;
			while (true)
			{
				TEastOrWest tEastOrWest = (TEastOrWest)num2;
				do
				{
					num += Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)].NumPts;
					tEastOrWest++;
				}
				while (tEastOrWest <= TEastOrWest.West);
				tNorthOrSouth++;
				if (tNorthOrSouth > TNorthOrSouth.South)
				{
					break;
				}
				num2 = 0;
			}
			NumPts = num;
		}

		private void method_1(int int_0)
		{
			if (FNumPts == int_0)
			{
				return;
			}
			int fNumPts = FNumPts;
			FNumPts = int_0;
			if ((FNumPts <= Tree.MaxPoints) & (fNumPts > Tree.MaxPoints))
			{
				Pts = new TQPoint<T>[Tree.MaxPoints - 1 + 1];
				int num = 0;
				TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
				int num2 = 0;
				while (true)
				{
					TEastOrWest tEastOrWest = (TEastOrWest)num2;
					do
					{
						TQTreeNode<T> tQTreeNode = Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
						int num3 = tQTreeNode.NumPts - 1;
						for (int i = 0; i <= num3; i++)
						{
							Pts[num] = tQTreeNode.Pts[i];
							num++;
						}
						tQTreeNode.FNumPts = 0;
						tQTreeNode.Pts = new TQPoint<T>[0];
						tQTreeNode = null;
						Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
						tEastOrWest++;
					}
					while (tEastOrWest <= TEastOrWest.West);
					tNorthOrSouth++;
					if (tNorthOrSouth > TNorthOrSouth.South)
					{
						break;
					}
					num2 = 0;
				}
			}
			if (Parent != null)
			{
				Parent.method_0();
			}
		}

		private TQPoint<T> method_2(int int_0)
		{
			TQPoint<T> result = default(TQPoint<T>);
			if (Children[0] == null)
			{
				result = Pts[int_0];
			}
			else
			{
				TEastOrWest tEastOrWest = TEastOrWest.West;
				int num = 0;
				while (true)
				{
					TNorthOrSouth tNorthOrSouth = (TNorthOrSouth)num;
					do
					{
						TQTreeNode<T> tQTreeNode = Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
						if (tQTreeNode.NumPts <= int_0)
						{
							int_0 -= tQTreeNode.NumPts;
							tNorthOrSouth++;
							continue;
						}
						return tQTreeNode.method_2(int_0);
					}
					while (tNorthOrSouth <= TNorthOrSouth.South);
					tEastOrWest += -1;
					if (tEastOrWest < TEastOrWest.East)
					{
						break;
					}
					num = 0;
				}
			}
			return result;
		}

		private void method_3(double double_0, double double_1, int int_0, ref double double_2, ref TQTreeNode<T> tqtreeNode_0, ref List<TSelectNode<T>> list_0)
		{
			int num = -1;
			int num2 = tqtreeNode_0.NumPts - 1;
			for (int i = 0; i <= num2; i++)
			{
				TQPoint<T> point = tqtreeNode_0.Pts[i];
				double num3 = point.X - double_0;
				double num4 = point.Y - double_1;
				double num5 = Math.Sqrt(num3 * num3 + num4 * num4);
				if (!((list_0.Count < int_0) | (num5 <= double_2)))
				{
					continue;
				}
				TSelectNode<T> tSelectNode = new TSelectNode<T>();
				tSelectNode.Distance = num5;
				tSelectNode.Point = point;
				list_0.Add(tSelectNode);
				if (list_0.Count % int_0 != 0)
				{
					continue;
				}
				list_0.Sort(tSelectNode);
				if (list_0.Count >= int_0)
				{
					tSelectNode = list_0[int_0 - 1];
					double_2 = tSelectNode.Distance;
				}
				int num6 = list_0.Count - 1;
				for (int j = int_0; j <= num6; j++)
				{
					tSelectNode = list_0[j];
					if (!(tSelectNode.Distance <= double_2))
					{
						num = j;
						break;
					}
				}
				if (num > -1)
				{
					list_0.RemoveRange(num, list_0.Count - num);
				}
			}
		}

		private void method_4(double double_0, double double_1, int int_0, ref double double_2, ref TQTreeNode<T> tqtreeNode_0, ref List<TSelectNode<T>> list_0)
		{
			int num = -1;
			int num2 = tqtreeNode_0.NumPts - 1;
			for (int i = 0; i <= num2; i++)
			{
				TQPoint<T> point = tqtreeNode_0.Pts[i];
				double num3 = Geodesic_Vincenty.GreatCircleDistance(point.Y, point.X, double_1, double_0);
				if (!((list_0.Count < int_0) | (num3 <= double_2)))
				{
					continue;
				}
				TSelectNode<T> tSelectNode = new TSelectNode<T>();
				tSelectNode.Distance = num3;
				tSelectNode.Point = point;
				list_0.Add(tSelectNode);
				if (list_0.Count % int_0 != 0)
				{
					continue;
				}
				list_0.Sort(tSelectNode);
				if (list_0.Count >= int_0)
				{
					tSelectNode = list_0[int_0 - 1];
					double_2 = tSelectNode.Distance;
				}
				int num4 = list_0.Count - 1;
				for (int j = int_0; j <= num4; j++)
				{
					tSelectNode = list_0[j];
					if (!(tSelectNode.Distance <= double_2))
					{
						num = j;
						break;
					}
				}
				if (num > -1)
				{
					list_0.RemoveRange(num, list_0.Count - num);
				}
			}
		}

		public void FindNearestPoints(double CenterX, double CenterY, int Count, ref List<TSelectNode<T>> List)
		{
			Stack<TQTreeNode<T>> Siblings = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(CenterX, CenterY, ref Siblings);
			double double_ = 0.0;
			method_3(CenterX, CenterY, Count, ref double_, ref tqtreeNode_, ref List);
			while (Siblings.Count > 0)
			{
				tqtreeNode_ = Siblings.Pop();
				if ((List.Count < Count) | ((CenterX + double_ >= tqtreeNode_.Xmin) & (CenterX - double_ <= tqtreeNode_.Xmax) & (CenterY + double_ >= tqtreeNode_.Ymin) & (CenterY - double_ <= tqtreeNode_.Ymax)))
				{
					tqtreeNode_ = tqtreeNode_.LocateLeaf(CenterX, CenterY, ref Siblings);
					method_3(CenterX, CenterY, Count, ref double_, ref tqtreeNode_, ref List);
				}
			}
		}

		public void FindNearestPointsGC(double CenterX, double CenterY, int Count, ref List<TSelectNode<T>> List)
		{
			Stack<TQTreeNode<T>> Siblings = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> tqtreeNode_ = LocateLeaf(CenterX, CenterY, ref Siblings);
			double double_ = 0.0;
			method_4(CenterX, CenterY, Count, ref double_, ref tqtreeNode_, ref List);
			double Lat = default(double);
			double Lon = default(double);
			double Lat2 = default(double);
			double Lon2 = default(double);
			double Lat3 = default(double);
			double Lon3 = default(double);
			double Lat4 = default(double);
			double Lon4 = default(double);
			while (Siblings.Count > 0)
			{
				tqtreeNode_ = Siblings.Pop();
				Geodesic_Vincenty.fw_vincenty_wgs84_2(CenterY, CenterX, ref Lat, ref Lon, 0.0, double_);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(CenterY, CenterX, ref Lat2, ref Lon2, 180.0, double_);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(CenterY, CenterX, ref Lat3, ref Lon3, 90.0, double_);
				Geodesic_Vincenty.fw_vincenty_wgs84_2(CenterY, CenterX, ref Lat4, ref Lon4, 270.0, double_);
				if ((List.Count < Count) | ((Lon3 >= tqtreeNode_.Xmin) & (Lon4 <= tqtreeNode_.Xmax) & (Lat >= tqtreeNode_.Ymin) & (Lat2 <= tqtreeNode_.Ymax)))
				{
					tqtreeNode_ = tqtreeNode_.LocateLeaf(CenterX, CenterY, ref Siblings);
					method_4(CenterX, CenterY, Count, ref double_, ref tqtreeNode_, ref List);
				}
			}
		}

		protected internal void AddPoint(double X, double Y, T Data)
		{
			if (X < Xmin)
			{
				ExpandBounds(X, TExpandDirection.edWest);
			}
			if (X > Xmax)
			{
				ExpandBounds(X, TExpandDirection.edEast);
			}
			if (Y < Ymin)
			{
				ExpandBounds(Y, TExpandDirection.edSouth);
			}
			if (Y > Ymax)
			{
				ExpandBounds(Y, TExpandDirection.edNorth);
			}
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.NumPts >= Tree.MaxPoints)
			{
				double num = tQTreeNode.Xmid();
				double num2 = tQTreeNode.Ymid();
				TNorthOrSouth tNorthOrSouth;
				TEastOrWest tEastOrWest;
				if (tQTreeNode.Children[1] == null)
				{
					tQTreeNode.Children[1] = new TQTreeNode<T>(tQTreeNode.Xmin, num, num2, tQTreeNode.Ymax, tQTreeNode, Tree);
					tQTreeNode.Children[0] = new TQTreeNode<T>(num, tQTreeNode.Xmax, num2, tQTreeNode.Ymax, tQTreeNode, Tree);
					tQTreeNode.Children[3] = new TQTreeNode<T>(tQTreeNode.Xmin, num, tQTreeNode.Ymin, num2, tQTreeNode, Tree);
					tQTreeNode.Children[2] = new TQTreeNode<T>(num, tQTreeNode.Xmax, tQTreeNode.Ymin, num2, tQTreeNode, Tree);
					int num3 = tQTreeNode.NumPts - 1;
					for (int i = 0; i <= num3; i++)
					{
						TQPoint<T> tQPoint = tQTreeNode.Pts[i];
						tNorthOrSouth = ((tQPoint.Y <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
						tEastOrWest = ((tQPoint.X <= num) ? TEastOrWest.West : TEastOrWest.East);
						TQTreeNode<T> tQTreeNode2 = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
						tQTreeNode2.Pts[tQTreeNode2.NumPts] = tQPoint;
						tQTreeNode2.FNumPts++;
					}
					tQTreeNode.Pts = new TQPoint<T>[0];
				}
				tNorthOrSouth = ((Y <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
				tEastOrWest = ((X <= num) ? TEastOrWest.West : TEastOrWest.East);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			int num4 = tQTreeNode.NumPts - 1;
			int num5 = 0;
			while (true)
			{
				if (num5 <= num4)
				{
					if ((tQTreeNode.Pts[num5].X == X) & (tQTreeNode.Pts[num5].Y == Y))
					{
						break;
					}
					num5++;
					continue;
				}
				tQTreeNode.Pts[tQTreeNode.NumPts].X = X;
				tQTreeNode.Pts[tQTreeNode.NumPts].Y = Y;
				tQTreeNode.Pts[tQTreeNode.NumPts].Data = new List<T>();
				tQTreeNode.Pts[tQTreeNode.NumPts].Data.Add(Data);
				tQTreeNode.NumPts++;
				return;
			}
			tQTreeNode.Pts[num5].Data.Add(Data);
		}

		protected internal void Clear()
		{
			if (Children[0] == null)
			{
				int num = NumPts - 1;
				for (int i = 0; i <= num; i++)
				{
					Pts[i].Data = null;
				}
				FNumPts = 0;
				return;
			}
			TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
			int num2 = 0;
			while (true)
			{
				TEastOrWest tEastOrWest = (TEastOrWest)num2;
				do
				{
					Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)].Clear();
					Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
					tEastOrWest++;
				}
				while (tEastOrWest <= TEastOrWest.West);
				tNorthOrSouth++;
				if (tNorthOrSouth <= TNorthOrSouth.South)
				{
					num2 = 0;
					continue;
				}
				break;
			}
		}

		protected void CheckNearbyLeaves(TQTreeNode<T> exclude, ref TQTreeNode<T> best_leaf, double X, double Y, ref int best_i, ref double best_dist2, ref double best_dist)
		{
			if (exclude == this)
			{
				return;
			}
			if (Children[1] != null)
			{
				double num = Xmid();
				double num2 = Ymid();
				if (((best_i < 0) | (X - best_dist <= num)) && ((Y - best_dist <= num2) | (best_i < 0)))
				{
					Children[3].CheckNearbyLeaves(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist2, ref best_dist);
				}
				if (((best_i < 0) | (X - best_dist <= num)) && ((Y + best_dist > num2) | (best_i < 0)))
				{
					Children[1].CheckNearbyLeaves(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist2, ref best_dist);
				}
				if (((best_i < 0) | (X + best_dist > num)) && ((Y - best_dist <= num2) | (best_i < 0)))
				{
					Children[2].CheckNearbyLeaves(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist2, ref best_dist);
				}
				if (((best_i < 0) | (X + best_dist > num)) && ((Y + best_dist > num2) | (best_i < 0)))
				{
					Children[0].CheckNearbyLeaves(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist2, ref best_dist);
				}
			}
			else
			{
				int best_i2 = default(int);
				double best_dist3 = default(double);
				NearPointInLeaf(X, Y, ref best_i2, ref best_dist3);
				if ((best_i2 > -1) & ((best_dist2 > best_dist3) | (best_i < 0)))
				{
					best_dist2 = best_dist3;
					best_dist = Math.Sqrt(best_dist2);
					best_leaf = this;
					best_i = best_i2;
				}
			}
		}

		protected void CheckNearbyLeavesGC(TQTreeNode<T> exclude, ref TQTreeNode<T> best_leaf, double X, double Y, ref int best_i, ref double best_dist)
		{
			if (exclude == this)
			{
				return;
			}
			if (Children[1] != null)
			{
				double num = Xmid();
				double num2 = Ymid();
				if (((best_i < 0) | (X - best_dist <= num)) && ((Y - best_dist <= num2) | (best_i < 0)))
				{
					Children[3].CheckNearbyLeavesGC(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist);
				}
				if (((best_i < 0) | (X - best_dist <= num)) && ((Y + best_dist > num2) | (best_i < 0)))
				{
					Children[1].CheckNearbyLeavesGC(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist);
				}
				if (((best_i < 0) | (X + best_dist > num)) && ((Y - best_dist <= num2) | (best_i < 0)))
				{
					Children[2].CheckNearbyLeavesGC(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist);
				}
				if (((best_i < 0) | (X + best_dist > num)) && ((Y + best_dist > num2) | (best_i < 0)))
				{
					Children[0].CheckNearbyLeavesGC(exclude, ref best_leaf, X, Y, ref best_i, ref best_dist);
				}
			}
			else
			{
				int best_i2 = default(int);
				double best_dist2 = default(double);
				NearPointInLeafGC(X, Y, ref best_i2, ref best_dist2);
				if ((best_i2 > -1) & ((best_dist > best_dist2) | (best_i < 0)))
				{
					best_dist = best_dist2;
					best_leaf = this;
					best_i = best_i2;
				}
			}
		}

		public TQTreeNode(TRbwQuadTree<T> ATree)
		{
			Children = new TQTreeNode<T>[4];
			Parent = null;
			Xmin = 0.0;
			Xmax = 0.0;
			Ymin = 0.0;
			Ymax = 0.0;
			Tree = ATree;
			TNorthOrSouth tNorthOrSouth = TNorthOrSouth.North;
			int num = 0;
			while (true)
			{
				TEastOrWest tEastOrWest = (TEastOrWest)num;
				do
				{
					Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)] = null;
					tEastOrWest++;
				}
				while (tEastOrWest <= TEastOrWest.West);
				tNorthOrSouth++;
				if (tNorthOrSouth > TNorthOrSouth.South)
				{
					break;
				}
				num = 0;
			}
			FNumPts = 0;
			Pts = new TQPoint<T>[Tree.MaxPoints - 1 + 1];
		}

		public TQTreeNode(double x_min, double x_max, double y_min, double y_max, TQTreeNode<T> ParentNode, TRbwQuadTree<T> ATree)
			: this(ATree)
		{
			if (!(x_min <= x_max && y_min <= y_max))
			{
				throw new Exception("Error: attempt to create a TQtreeNode with an invalid range.");
			}
			Parent = ParentNode;
			Xmin = x_min;
			Xmax = x_max;
			Ymin = y_min;
			Ymax = y_max;
		}

		public void ExpandBounds(double XY, TExpandDirection ExpandDirection)
		{
			switch (ExpandDirection)
			{
			case TExpandDirection.edNorth:
				Ymax = XY;
				if (Children[0] != null)
				{
					Children[0].ExpandBounds(XY, ExpandDirection);
					Children[1].ExpandBounds(XY, ExpandDirection);
				}
				break;
			case TExpandDirection.edSouth:
				Ymin = XY;
				if (Children[0] != null)
				{
					Children[2].ExpandBounds(XY, ExpandDirection);
					Children[3].ExpandBounds(XY, ExpandDirection);
				}
				break;
			case TExpandDirection.edEast:
				Xmax = XY;
				if (Children[0] != null)
				{
					Children[0].ExpandBounds(XY, ExpandDirection);
					Children[2].ExpandBounds(XY, ExpandDirection);
				}
				break;
			case TExpandDirection.edWest:
				Xmin = XY;
				if (Children[0] != null)
				{
					Children[1].ExpandBounds(XY, ExpandDirection);
					Children[3].ExpandBounds(XY, ExpandDirection);
				}
				break;
			}
		}

		internal TQPoint<T> FindClosestPoint(double X, double Y)
		{
			Stack<TQTreeNode<T>> Siblings = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> best_leaf = LocateLeaf(X, Y, ref Siblings);
			int best_i = default(int);
			double best_dist = default(double);
			best_leaf.NearPointInLeaf(X, Y, ref best_i, ref best_dist);
			if (best_i < 0)
			{
				while (Siblings.Count > 0)
				{
					best_leaf = Siblings.Pop().LocateLeaf(X, Y, ref Siblings);
					best_leaf.NearPointInLeaf(X, Y, ref best_i, ref best_dist);
					if (best_i >= 0)
					{
						break;
					}
				}
			}
			double best_dist2 = Math.Sqrt(best_dist);
			CheckNearbyLeaves(best_leaf, ref best_leaf, X, Y, ref best_i, ref best_dist, ref best_dist2);
			return best_leaf.Pts[best_i];
		}

		internal TQPoint<T> FindClosestPointGC(double X, double Y)
		{
			Stack<TQTreeNode<T>> Siblings = new Stack<TQTreeNode<T>>();
			TQTreeNode<T> best_leaf = LocateLeaf(X, Y, ref Siblings);
			int best_i = default(int);
			double best_dist = default(double);
			best_leaf.NearPointInLeafGC(X, Y, ref best_i, ref best_dist);
			if (best_i < 0)
			{
				while (Siblings.Count > 0)
				{
					best_leaf = Siblings.Pop().LocateLeaf(X, Y, ref Siblings);
					best_leaf.NearPointInLeafGC(X, Y, ref best_i, ref best_dist);
					if (best_i >= 0)
					{
						break;
					}
				}
			}
			CheckNearbyLeavesGC(best_leaf, ref best_leaf, X, Y, ref best_i, ref best_dist);
			return best_leaf.Pts[best_i];
		}

		public void FindPoint(ref double X, ref double Y, ref T Data)
		{
			TQPoint<T> tQPoint = FindClosestPoint(X, Y);
			X = tQPoint.X;
			Y = tQPoint.Y;
			if (tQPoint.Data != null && tQPoint.Data.Count > 0)
			{
				Data = tQPoint.Data[0];
			}
			else
			{
				Data = default(T);
			}
		}

		public void FindClosestPointsData(ref double X, ref double Y, ref T[] Data)
		{
			TQPoint<T> tQPoint = FindClosestPoint(X, Y);
			X = tQPoint.X;
			Y = tQPoint.Y;
			Data = new T[tQPoint.Data.Count - 1 + 1];
			int num = tQPoint.Data.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Data[i] = tQPoint.Data[i];
			}
		}

		internal TQTreeNode<T> LocateLeaf(double X, double Y, ref Stack<TQTreeNode<T>> Siblings)
		{
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				TNorthOrSouth tNorthOrSouth = ((Y <= tQTreeNode.Ymid()) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest;
				int num;
				if (X <= tQTreeNode.Xmid())
				{
					tEastOrWest = TEastOrWest.West;
					num = 0;
				}
				else
				{
					tEastOrWest = TEastOrWest.East;
					num = 0;
				}
				TNorthOrSouth tNorthOrSouth2 = (TNorthOrSouth)num;
				int num2 = 0;
				while (true)
				{
					TEastOrWest tEastOrWest2 = (TEastOrWest)num2;
					do
					{
						if (tNorthOrSouth2 != tNorthOrSouth || tEastOrWest2 != tEastOrWest)
						{
							Siblings.Push(tQTreeNode.Children[(int)((int)tNorthOrSouth2 * 2 + tEastOrWest2)]);
						}
						tEastOrWest2++;
					}
					while (tEastOrWest2 <= TEastOrWest.West);
					tNorthOrSouth2++;
					if (tNorthOrSouth2 > TNorthOrSouth.South)
					{
						break;
					}
					num2 = 0;
				}
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			return tQTreeNode;
		}

		internal TQTreeNode<T> LocateLeafGC(double X, double Y, ref Stack<TQTreeNode<T>> Siblings)
		{
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				TNorthOrSouth tNorthOrSouth = ((Y <= tQTreeNode.Ymid()) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest;
				int num;
				if (X <= tQTreeNode.Xmid())
				{
					tEastOrWest = TEastOrWest.West;
					num = 0;
				}
				else
				{
					tEastOrWest = TEastOrWest.East;
					num = 0;
				}
				TNorthOrSouth tNorthOrSouth2 = (TNorthOrSouth)num;
				int num2 = 0;
				while (true)
				{
					TEastOrWest tEastOrWest2 = (TEastOrWest)num2;
					do
					{
						if (tNorthOrSouth2 != tNorthOrSouth || tEastOrWest2 != tEastOrWest)
						{
							Siblings.Push(tQTreeNode.Children[(int)((int)tNorthOrSouth2 * 2 + tEastOrWest2)]);
						}
						tEastOrWest2++;
					}
					while (tEastOrWest2 <= TEastOrWest.West);
					tNorthOrSouth2++;
					if (tNorthOrSouth2 > TNorthOrSouth.South)
					{
						break;
					}
					num2 = 0;
				}
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			return tQTreeNode;
		}

		public void NearPointInLeaf(double X, double Y, ref int best_i, ref double best_dist2)
		{
			best_dist2 = 0.0;
			best_i = -1;
			if (NumPts <= 0)
			{
				return;
			}
			double num = X - Pts[0].X;
			double num2 = Y - Pts[0].Y;
			best_dist2 = num * num + num2 * num2;
			best_i = 0;
			int num3 = NumPts - 1;
			for (int i = 1; i <= num3; i++)
			{
				num = X - Pts[i].X;
				num2 = Y - Pts[i].Y;
				double num4 = num * num + num2 * num2;
				if (best_dist2 > num4)
				{
					best_i = i;
					best_dist2 = num4;
				}
			}
		}

		public void NearPointInLeafGC(double X, double Y, ref int best_i, ref double best_dist)
		{
			best_dist = 0.0;
			best_i = -1;
			if (NumPts <= 0)
			{
				return;
			}
			best_dist = Geodesic_Vincenty.GreatCircleDistance(Y, X, Pts[0].Y, Pts[0].X);
			best_i = 0;
			int num = NumPts - 1;
			for (int i = 1; i <= num; i++)
			{
				double num2 = Geodesic_Vincenty.GreatCircleDistance(Y, X, Pts[i].Y, Pts[i].X);
				if (best_dist > num2)
				{
					best_i = i;
					best_dist = num2;
				}
			}
		}

		internal double Xmid()
		{
			if (Children[1] != null)
			{
				return Children[1].Xmax;
			}
			return (Xmax + Xmin) / 2.0;
		}

		internal double Ymid()
		{
			if (Children[0] == null)
			{
				return (Ymax + Ymin) / 2.0;
			}
			return Children[0].Ymin;
		}

		public void RemovePoint(double X, double Y, T Data)
		{
			if ((X < Xmin) | (X > Xmax) | (Y < Ymin) | (Y > Ymax))
			{
				return;
			}
			TQTreeNode<T> tQTreeNode = this;
			while (tQTreeNode.Children[1] != null)
			{
				double num = tQTreeNode.Xmid();
				double num2 = tQTreeNode.Ymid();
				TNorthOrSouth tNorthOrSouth = ((Y <= num2) ? TNorthOrSouth.South : TNorthOrSouth.North);
				TEastOrWest tEastOrWest = ((X <= num) ? TEastOrWest.West : TEastOrWest.East);
				tQTreeNode = tQTreeNode.Children[(int)((int)tNorthOrSouth * 2 + tEastOrWest)];
			}
			int num3 = tQTreeNode.NumPts - 1;
			int num4 = 0;
			while (true)
			{
				if (num4 <= num3)
				{
					if ((tQTreeNode.Pts[num4].X == X) & (tQTreeNode.Pts[num4].Y == Y))
					{
						break;
					}
					num4++;
					continue;
				}
				return;
			}
			tQTreeNode.Pts[num4].Data.Remove(Data);
			if (tQTreeNode.Pts[num4].Data.Count == 0)
			{
				int num5 = num4 + 1;
				int num6 = tQTreeNode.NumPts - 1;
				for (int i = num5; i <= num6; i++)
				{
					tQTreeNode.Pts[i - 1] = tQTreeNode.Pts[i];
				}
				tQTreeNode.Pts[num4].Data = null;
				tQTreeNode.NumPts--;
			}
		}

		public void FindPointsInCircle(double CenterX, double CenterY, double Radius, double RadiusSquared, ref List<TQPoint<T>> List)
		{
			if (Children[1] == null)
			{
				bool flag;
				if (flag = NumPts > 4)
				{
					double num = Xmax - CenterX;
					double num2 = Ymax - CenterY;
					if (num * num + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num3 = Xmax - CenterX;
					double num2 = Ymin - CenterY;
					if (num3 * num3 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num4 = Xmin - CenterX;
					double num2 = Ymax - CenterY;
					if (num4 * num4 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num5 = Xmin - CenterX;
					double num2 = Ymin - CenterY;
					if (num5 * num5 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					int num6 = NumPts - 1;
					for (int i = 0; i <= num6; i++)
					{
						TQPoint<T> tQPoint = Pts[i];
						double num7 = tQPoint.X - CenterX;
						double num2 = tQPoint.Y - CenterY;
						if (num7 * num7 + num2 * num2 <= RadiusSquared)
						{
							List.Add(Pts[i]);
						}
					}
				}
				else
				{
					int num8 = NumPts - 1;
					for (int i = 0; i <= num8; i++)
					{
						List.Add(Pts[i]);
					}
				}
				return;
			}
			double num9 = Xmid();
			double num10 = Ymid();
			if (CenterX - Radius <= num9)
			{
				if (CenterY - Radius <= num10)
				{
					Children[3].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
				if (CenterY + Radius >= num10)
				{
					Children[1].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
			}
			if (CenterX + Radius >= num9)
			{
				if (CenterY - Radius <= num10)
				{
					Children[2].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
				if (CenterY + Radius >= num10)
				{
					Children[0].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
			}
		}

		public void FindPointsInCircleGC(double CenterX, double CenterY, double Radius, double RadiusSquared, ref List<TQPoint<T>> List)
		{
			if (Children[1] == null)
			{
				bool flag;
				if (flag = NumPts > 4)
				{
					double num = Xmax - CenterX;
					double num2 = Ymax - CenterY;
					if (num * num + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num3 = Xmax - CenterX;
					double num2 = Ymin - CenterY;
					if (num3 * num3 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num4 = Xmin - CenterX;
					double num2 = Ymax - CenterY;
					if (num4 * num4 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num5 = Xmin - CenterX;
					double num2 = Ymin - CenterY;
					if (num5 * num5 + num2 * num2 > RadiusSquared)
					{
						flag = false;
					}
				}
				if (flag)
				{
					int num6 = NumPts - 1;
					for (int i = 0; i <= num6; i++)
					{
						List.Add(Pts[i]);
					}
					return;
				}
				int num7 = NumPts - 1;
				for (int i = 0; i <= num7; i++)
				{
					TQPoint<T> tQPoint = Pts[i];
					double num8 = tQPoint.X - CenterX;
					double num2 = tQPoint.Y - CenterY;
					if (num8 * num8 + num2 * num2 <= RadiusSquared)
					{
						List.Add(Pts[i]);
					}
				}
				return;
			}
			double num9 = Xmid();
			double num10 = Ymid();
			if (CenterX - Radius <= num9)
			{
				if (CenterY - Radius <= num10)
				{
					Children[3].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
				if (CenterY + Radius >= num10)
				{
					Children[1].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
			}
			if (CenterX + Radius >= num9)
			{
				if (CenterY - Radius <= num10)
				{
					Children[2].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
				if (CenterY + Radius >= num10)
				{
					Children[0].FindPointsInCircle(CenterX, CenterY, Radius, RadiusSquared, ref List);
				}
			}
		}

		public void FindPointsInBlock(T2DBlock Block, ref List<TQPoint<T>> List)
		{
			if (Children[1] == null)
			{
				if (!((Block.XMin <= Xmin) & (Block.XMax >= Xmax) & (Block.YMin <= Ymin) & (Block.YMax >= Ymax)))
				{
					int num = NumPts - 1;
					for (int i = 0; i <= num; i++)
					{
						TQPoint<T> tQPoint = Pts[i];
						if ((Block.XMin <= tQPoint.X) & (Block.XMax >= tQPoint.X) & (Block.YMin <= tQPoint.Y) & (Block.YMax >= tQPoint.Y))
						{
							List.Add(Pts[i]);
						}
					}
				}
				else
				{
					int num2 = NumPts - 1;
					for (int i = 0; i <= num2; i++)
					{
						List.Add(Pts[i]);
					}
				}
				return;
			}
			double num3 = Xmid();
			double num4 = Ymid();
			if (Block.XMin <= num3)
			{
				if (Block.YMin <= num4)
				{
					Children[3].FindPointsInBlock(Block, ref List);
				}
				if (Block.YMax >= num4)
				{
					Children[1].FindPointsInBlock(Block, ref List);
				}
			}
			if (Block.XMax >= num3)
			{
				if (Block.YMin <= num4)
				{
					Children[2].FindPointsInBlock(Block, ref List);
				}
				if (Block.YMax >= num4)
				{
					Children[0].FindPointsInBlock(Block, ref List);
				}
			}
		}

		static TQTreeNode()
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

	[Serializable]
	public sealed class TRbwQuadTree<T>
	{
		private TQTreeNode<T> tqtreeNode_0;

		private int int_0;

		internal static object object_0;

		public int Count => GetCount();

		public TQuadPoint<T> Points => GetPoints(Index);

		public int MaxPoints
		{
			get
			{
				return int_0;
			}
			set
			{
				if (Count != 0)
				{
					throw new Exception("You must set the number of points before adding any points to a Quadtree.");
				}
				if (value <= 0)
				{
					throw new Exception("The maximum number of points in a Quadtree must be greater than zero.");
				}
				int_0 = value;
				tqtreeNode_0.Pts = new TQPoint<T>[int_0 - 1 + 1];
			}
		}

		public double XMax
		{
			get
			{
				return method_0();
			}
			set
			{
				method_4(value);
			}
		}

		public double XMin
		{
			get
			{
				return method_1();
			}
			set
			{
				method_5(value);
			}
		}

		public double YMax
		{
			get
			{
				return method_2();
			}
			set
			{
				method_6(value);
			}
		}

		public double Ymin
		{
			get
			{
				return method_3();
			}
			set
			{
				method_7(value);
			}
		}

		private double method_0()
		{
			return tqtreeNode_0.Xmax;
		}

		private double method_1()
		{
			return tqtreeNode_0.Xmin;
		}

		private double method_2()
		{
			return tqtreeNode_0.Ymax;
		}

		private double method_3()
		{
			return tqtreeNode_0.Ymin;
		}

		private void method_4(double double_0)
		{
			if (Count == 0)
			{
				tqtreeNode_0.Xmax = double_0;
				return;
			}
			if (double_0 < XMax)
			{
				throw new Exception("Error: The maximum X value can not be decreased, only increased.");
			}
			tqtreeNode_0.ExpandBounds(double_0, TExpandDirection.edWest);
		}

		private void method_5(double double_0)
		{
			if (Count == 0)
			{
				tqtreeNode_0.Xmin = double_0;
				return;
			}
			if (double_0 > XMin)
			{
				throw new Exception("Error: The minimum X value can not be increased, only decreased.");
			}
			tqtreeNode_0.ExpandBounds(double_0, TExpandDirection.edEast);
		}

		private void method_6(double double_0)
		{
			if (Count == 0)
			{
				tqtreeNode_0.Ymax = double_0;
				return;
			}
			if (double_0 < YMax)
			{
				throw new Exception("Error: The maximum Y value can not be decreased, only increased.");
			}
			tqtreeNode_0.ExpandBounds(double_0, TExpandDirection.edNorth);
		}

		private void method_7(double double_0)
		{
			if (Count == 0)
			{
				tqtreeNode_0.Ymin = double_0;
				return;
			}
			if (double_0 > Ymin)
			{
				throw new Exception("Error: The minimum Y value can not be increased, only decreased.");
			}
			tqtreeNode_0.ExpandBounds(double_0, TExpandDirection.edSouth);
		}

		internal int GetCount()
		{
			return tqtreeNode_0.NumPts;
		}

		internal TQuadPoint<T> GetPoints(int Index)
		{
			TQuadPoint<T> result = default(TQuadPoint<T>);
			if (Index < 0)
			{
				throw new Exception("Invalid point index < 0.");
			}
			if (Index >= Count)
			{
				throw new Exception("Invalid point index >= Count.");
			}
			TQPoint<T> tQPoint = tqtreeNode_0.get_Points(Index);
			result.X = tQPoint.X;
			result.Y = tQPoint.Y;
			result.Distance = 0.0;
			result.Data = new List<T>(tQPoint.Data.Count);
			int num = tQPoint.Data.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				result.Data.Add(tQPoint.Data[i]);
			}
			return result;
		}

		public void AddPoint(double X, double Y, T Data)
		{
			tqtreeNode_0.AddPoint(X, Y, Data);
		}

		public void Clear()
		{
			tqtreeNode_0.Clear();
			tqtreeNode_0.FNumPts = 0;
			tqtreeNode_0.Pts = new TQPoint<T>[MaxPoints - 1 + 1];
		}

		public TRbwQuadTree()
		{
			int_0 = 100;
			tqtreeNode_0 = new TQTreeNode<T>(this);
		}

		public void FindClosestPointsData(double X, double Y, ref T[] Data)
		{
			if (tqtreeNode_0.NumPts <= 0)
			{
				throw new Exception("Error: No data points in QuadTree.");
			}
			tqtreeNode_0.FindClosestPointsData(ref X, ref Y, ref Data);
		}

		public void FindNearestPoints(double CenterX, double CenterY, int Count, ref TQuadPoint<T>[] Points)
		{
			List<TSelectNode<T>> List = new List<TSelectNode<T>>();
			TSelectNode<T> comparer = new TSelectNode<T>();
			tqtreeNode_0.FindNearestPoints(CenterX, CenterY, Count, ref List);
			List.Sort(comparer);
			if (List.Count > this.Count)
			{
				comparer = List[Count - 1];
				double distance = comparer.Distance;
				int count = this.Count;
				int num = List.Count - 1;
				for (int i = count; i <= num; i++)
				{
					comparer = List[i];
					if (!(comparer.Distance <= distance))
					{
						List.RemoveRange(i, List.Count - i);
						break;
					}
				}
			}
			Points = new TQuadPoint<T>[List.Count - 1 + 1];
			int num2 = List.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				comparer = List[i];
				TQPoint<T> point = comparer.Point;
				Points[i].X = point.X;
				Points[i].Y = point.Y;
				Points[i].Distance = comparer.Distance;
				Points[i].Data = new List<T>(point.Data.Count);
				int num3 = point.Data.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					Points[i].Data.Add(point.Data[j]);
				}
			}
		}

		public void FindNearestPointsGC(double CenterX, double CenterY, int Count, ref TQuadPoint<T>[] Points)
		{
			List<TSelectNode<T>> List = new List<TSelectNode<T>>();
			TSelectNode<T> comparer = new TSelectNode<T>();
			tqtreeNode_0.FindNearestPointsGC(CenterX, CenterY, Count, ref List);
			List.Sort(comparer);
			if (List.Count > this.Count)
			{
				comparer = List[Count - 1];
				double distance = comparer.Distance;
				int count = this.Count;
				int num = List.Count - 1;
				for (int i = count; i <= num; i++)
				{
					comparer = List[i];
					if (!(comparer.Distance <= distance))
					{
						List.RemoveRange(i, List.Count - i);
						break;
					}
				}
			}
			Points = new TQuadPoint<T>[List.Count - 1 + 1];
			int num2 = List.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				comparer = List[i];
				TQPoint<T> point = comparer.Point;
				Points[i].X = point.X;
				Points[i].Y = point.Y;
				Points[i].Distance = comparer.Distance;
				Points[i].Data = new List<T>(point.Data.Count);
				int num3 = point.Data.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					Points[i].Data.Add(point.Data[j]);
				}
			}
		}

		public void FindPointsInBlock(T2DBlock Block, ref GStruct1<T>[] Points)
		{
			List<TQPoint<T>> List = new List<TQPoint<T>>();
			List.Capacity = Count;
			tqtreeNode_0.FindPointsInBlock(Block, ref List);
			Points = new GStruct1<T>[List.Count - 1 + 1];
			int num = List.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				TQPoint<T> tQPoint = List[i];
				Points[i].X = tQPoint.X;
				Points[i].Y = tQPoint.Y;
				Points[i].Data = new List<T>(tQPoint.Data.Count);
				int num2 = tQPoint.Data.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					Points[i].Data.Add(tQPoint.Data[j]);
				}
			}
		}

		public void FindPointsInCircle(double CenterX, double CenterY, double Radius, ref GStruct1<T>[] Points)
		{
			List<TQPoint<T>> List = new List<TQPoint<T>>();
			tqtreeNode_0.FindPointsInCircle(CenterX, CenterY, Radius, Radius * Radius, ref List);
			Points = new GStruct1<T>[List.Count - 1 + 1];
			int num = List.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				TQPoint<T> tQPoint = List[i];
				Points[i].X = tQPoint.X;
				Points[i].Y = tQPoint.Y;
				Points[i].Data = new List<T>(tQPoint.Data.Count);
				int num2 = tQPoint.Data.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					Points[i].Data.Add(tQPoint.Data[j]);
				}
			}
		}

		public void FirstNearestPoint(ref double X, ref double Y, ref T Data)
		{
			if (tqtreeNode_0.NumPts <= 0)
			{
				throw new Exception("Error: No data points in QuadTree.");
			}
			tqtreeNode_0.FindPoint(ref X, ref Y, ref Data);
		}

		internal T NearestPointsFirstData(double X, double Y)
		{
			T Data = default(T);
			if (tqtreeNode_0.NumPts > 0)
			{
				FirstNearestPoint(ref X, ref Y, ref Data);
			}
			return Data;
		}

		public void RemovePoint(double X, double Y, T Data)
		{
			tqtreeNode_0.RemovePoint(X, Y, Data);
		}

		static TRbwQuadTree()
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

	[Serializable]
	public sealed class TSelectNode<T> : IComparer<TSelectNode<T>>
	{
		public double Distance;

		public TQPoint<T> Point;

		internal static object object_0;

		internal int Compare(TSelectNode<T> x, TSelectNode<T> y)
		{
			double num = y.Distance - x.Distance;
			if (num > 0.0)
			{
				return -1;
			}
			if (num < 0.0)
			{
				return 1;
			}
			return 0;
		}

		int IComparer<TSelectNode<T>>.Compare(TSelectNode<T> x, TSelectNode<T> y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(x, y);
		}

		static TSelectNode()
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

	static RBWQuadTree()
	{
		Class72.smethod_20();
	}
}
