using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class MonotoneChainIndexer
{
	public static int[] ToIntArray(IList list)
	{
		int[] array = new int[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToInt32(list[i]);
		}
		return array;
	}

	public virtual int[] GetChainStartIndices(IList<Coordinate> pts)
	{
		int num = 0;
		IList list = new ArrayList();
		list.Add(0);
		do
		{
			int num2 = smethod_0(pts, num);
			list.Add(num2);
			num = num2;
		}
		while (num < pts.Count - 1);
		return ToIntArray(list);
	}

	private static int smethod_0(IList<Coordinate> ilist_0, int int_0)
	{
		int num = QuadrantOp.Quadrant(ilist_0[int_0], ilist_0[int_0 + 1]);
		int i;
		for (i = int_0 + 1; i < ilist_0.Count && QuadrantOp.Quadrant(ilist_0[i - 1], ilist_0[i]) == num; i++)
		{
		}
		return i - 1;
	}

	static MonotoneChainIndexer()
	{
		Class72.smethod_20();
	}
}
