using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class KdNode
{
	internal readonly HPoint K;

	internal KdNode Left;

	internal KdNode Right;

	internal object V;

	private bool bool_0;

	public bool IsDeleted
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

	private KdNode(HPoint key, object value)
	{
		K = key;
		V = value;
		Left = null;
		Right = null;
		bool_0 = false;
	}

	public string ToString(int depth)
	{
		string text = ((object)K)?.ToString() + "  " + V?.ToString() + ((!bool_0) ? string.Empty : "*");
		if (Left != null)
		{
			text = text + "\n" + smethod_0(depth) + "L " + Left.ToString(depth + 1);
		}
		if (Right != null)
		{
			text = text + "\n" + smethod_0(depth) + "R " + Right.ToString(depth + 1);
		}
		return text;
	}

	public static KdNode Insert(HPoint key, object value, KdNode t, int lev, int k)
	{
		if (t == null)
		{
			t = new KdNode(key, value);
		}
		else if (key.Equals(t.K))
		{
			if (!t.IsDeleted)
			{
				throw new KeyDuplicateException();
			}
			t.IsDeleted = false;
			t.V = value;
		}
		else if (key[lev] > t.K[lev])
		{
			t.Right = Insert(key, value, t.Right, (lev + 1) % k, k);
		}
		else
		{
			t.Left = Insert(key, value, t.Left, (lev + 1) % k, k);
		}
		return t;
	}

	public static KdNode Search(HPoint key, KdNode t, int k)
	{
		int num = 0;
		while (true)
		{
			if (t != null)
			{
				if (!t.IsDeleted && key.Equals(t.K))
				{
					break;
				}
				t = ((key[num] > t.K[num]) ? t.Right : t.Left);
				num = (num + 1) % k;
				continue;
			}
			return null;
		}
		return t;
	}

	public static void SearchRange(HPoint lowk, HPoint uppk, KdNode t, int lev, int k, List<KdNode> v)
	{
		if (t != null)
		{
			int num;
			if (lowk[lev] <= t.K[lev])
			{
				SearchRange(lowk, uppk, t.Left, (lev + 1) % k, k, v);
				num = 0;
			}
			else
			{
				num = 0;
			}
			int i;
			for (i = num; i < k && lowk[i] <= t.K[i] && !(uppk[i] < t.K[i]); i++)
			{
			}
			if (i == k)
			{
				v.Add(t);
			}
			if (uppk[lev] > t.K[lev])
			{
				SearchRange(lowk, uppk, t.Right, (lev + 1) % k, k, v);
			}
		}
	}

	public static void Nnbr(KdNode kd, HPoint target, HRect hr, double maxDistSqd, int lev, int k, NearestNeighborList nnl)
	{
		if (kd == null)
		{
			return;
		}
		int index = lev % k;
		HPoint k2 = kd.K;
		double num = HPoint.SquareDistance(k2, target);
		HRect hRect = hr.Copy();
		hr.Max[index] = k2[index];
		hRect.Min[index] = k2[index];
		KdNode kd2;
		HRect hr2;
		KdNode kd3;
		HRect hRect2;
		if (!(target[index] < k2[index]))
		{
			kd2 = kd.Right;
			hr2 = hRect;
			kd3 = kd.Left;
			hRect2 = hr;
		}
		else
		{
			kd2 = kd.Left;
			hr2 = hr;
			kd3 = kd.Right;
			hRect2 = hRect;
		}
		Nnbr(kd2, target, hr2, maxDistSqd, lev + 1, k, nnl);
		double num2 = (nnl.IsCapacityReached ? nnl.MaxPriority : 1.79769E+30);
		maxDistSqd = Math.Min(maxDistSqd, num2);
		if (HPoint.EuclideanDistance(hRect2.Closest(target), target) >= Math.Sqrt(maxDistSqd))
		{
			if (num < maxDistSqd)
			{
				num2 = num;
			}
			return;
		}
		if (num < num2)
		{
			num2 = num;
			if (!kd.IsDeleted)
			{
				nnl.Insert(kd, num2);
			}
			maxDistSqd = (nnl.IsCapacityReached ? nnl.MaxPriority : 1.79769E+30);
		}
		Nnbr(kd3, target, hRect2, maxDistSqd, lev + 1, k, nnl);
		double maxPriority = nnl.MaxPriority;
		if (maxPriority < num2)
		{
			num2 = maxPriority;
		}
	}

	public static void FarthestNeighbor(KdNode kd, HPoint target, HRect hr, double maxDistSqd, int lev, int k, FarthestNeighborList fnl)
	{
		if (kd == null)
		{
			return;
		}
		int index = lev % k;
		HPoint k2 = kd.K;
		double num = HPoint.SquareDistance(k2, target);
		HRect hRect = hr.Copy();
		hr.Max[index] = k2[index];
		hRect.Min[index] = k2[index];
		KdNode kd2;
		HRect hRect2;
		KdNode kd3;
		HRect hr2;
		if (!(target[index] < k2[index]))
		{
			kd2 = kd.Right;
			hRect2 = hRect;
			kd3 = kd.Left;
			hr2 = hr;
		}
		else
		{
			kd2 = kd.Left;
			hRect2 = hr;
			kd3 = kd.Right;
			hr2 = hRect;
		}
		FarthestNeighbor(kd3, target, hr2, maxDistSqd, lev + 1, k, fnl);
		double num2 = (fnl.IsCapacityReached ? fnl.MinimumPriority : 0.0);
		maxDistSqd = Math.Max(maxDistSqd, num2);
		if (HPoint.EuclideanDistance(hRect2.Farthest(target), target) <= Math.Sqrt(maxDistSqd))
		{
			if (num < maxDistSqd)
			{
				num2 = num;
			}
			return;
		}
		if (num > num2)
		{
			num2 = num;
			if (!kd.IsDeleted)
			{
				fnl.Insert(kd, num2);
			}
			maxDistSqd = (fnl.IsCapacityReached ? fnl.MinimumPriority : 0.0);
		}
		FarthestNeighbor(kd2, target, hRect2, maxDistSqd, lev + 1, k, fnl);
		double minimumPriority = fnl.MinimumPriority;
		if (minimumPriority > num2)
		{
			num2 = minimumPriority;
		}
	}

	private static string smethod_0(int int_0)
	{
		string text = string.Empty;
		for (int i = 0; i < int_0; i++)
		{
			text += " ";
		}
		return text;
	}

	static KdNode()
	{
		Class72.smethod_20();
	}
}
