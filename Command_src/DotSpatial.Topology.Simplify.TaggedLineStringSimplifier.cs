using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Simplify;

public class TaggedLineStringSimplifier
{
	private static readonly LineIntersector lineIntersector_0;

	private readonly LineSegmentIndex lineSegmentIndex_0 = new LineSegmentIndex();

	private readonly LineSegmentIndex lineSegmentIndex_1 = new LineSegmentIndex();

	private double double_0;

	private TaggedLineString taggedLineString_0;

	private IList<Coordinate> WareGfuBoPq;

	public virtual double DistanceTolerance
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

	public TaggedLineStringSimplifier(LineSegmentIndex inputIndex, LineSegmentIndex outputIndex)
	{
		lineSegmentIndex_0 = inputIndex;
		lineSegmentIndex_1 = outputIndex;
	}

	public virtual void Simplify(TaggedLineString line)
	{
		taggedLineString_0 = line;
		WareGfuBoPq = line.ParentCoordinates;
		method_0(0, WareGfuBoPq.Count - 1, 0);
	}

	private void method_0(int int_0, int int_1, int int_2)
	{
		int_2++;
		int[] array = new int[2];
		if (int_0 + 1 == int_1)
		{
			LineSegment segment = taggedLineString_0.GetSegment(int_0);
			taggedLineString_0.AddToResult(segment);
			return;
		}
		double[] array2 = new double[1];
		int num = smethod_0(WareGfuBoPq, int_0, int_1, array2);
		bool flag = true;
		if (taggedLineString_0.ResultSize < taggedLineString_0.MinimumSize && int_2 < 2)
		{
			flag = false;
		}
		if (array2[0] > DistanceTolerance)
		{
			flag = false;
		}
		LineSegment lineSegment = new LineSegment();
		lineSegment.P0 = WareGfuBoPq[int_0];
		lineSegment.P1 = WareGfuBoPq[int_1];
		array[0] = int_0;
		array[1] = int_1;
		if (method_2(taggedLineString_0, array, lineSegment))
		{
			flag = false;
		}
		if (flag)
		{
			LineSegment seg = method_1(int_0, int_1);
			taggedLineString_0.AddToResult(seg);
		}
		else
		{
			method_0(int_0, num, int_2);
			method_0(num, int_1, int_2);
		}
	}

	private static int smethod_0(IList<Coordinate> ilist_0, int int_0, int int_1, object object_0)
	{
		LineSegment lineSegment = new LineSegment();
		lineSegment.P0 = ilist_0[int_0];
		lineSegment.P1 = ilist_0[int_1];
		double num = -1.0;
		int result = int_0;
		for (int i = int_0 + 1; i < int_1; i++)
		{
			Coordinate p = ilist_0[i];
			double num2 = lineSegment.Distance(p);
			if (num2 > num)
			{
				num = num2;
				result = i;
			}
		}
		((double[])object_0)[0] = num;
		return result;
	}

	private LineSegment method_1(int int_0, int int_1)
	{
		Coordinate p = WareGfuBoPq[int_0];
		Coordinate p2 = WareGfuBoPq[int_1];
		LineSegment lineSegment = new LineSegment(p, p2);
		Remove(taggedLineString_0, int_0, int_1);
		lineSegmentIndex_1.Add(lineSegment);
		return lineSegment;
	}

	private bool method_2(TaggedLineString taggedLineString_1, int[] int_0, LineSegment lineSegment_0)
	{
		if (!method_3(lineSegment_0))
		{
			if (!method_4(taggedLineString_1, int_0, lineSegment_0))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private bool method_3(LineSegment lineSegment_0)
	{
		IEnumerator enumerator = lineSegmentIndex_1.Query(lineSegment_0).GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!smethod_2((LineSegment)enumerator.Current, lineSegment_0));
		return true;
	}

	private bool method_4(TaggedLineString taggedLineString_1, int[] int_0, LineSegment lineSegment_0)
	{
		IEnumerator enumerator = lineSegmentIndex_0.Query(lineSegment_0).GetEnumerator();
		TaggedLineSegment taggedLineSegment;
		do
		{
			if (enumerator.MoveNext())
			{
				taggedLineSegment = (TaggedLineSegment)enumerator.Current;
				continue;
			}
			return false;
		}
		while (!smethod_2(taggedLineSegment, lineSegment_0) || smethod_1(taggedLineString_1, int_0, taggedLineSegment));
		return true;
	}

	private static bool smethod_1(TaggedLineString taggedLineString_1, object object_0, TaggedLineSegment taggedLineSegment_0)
	{
		if (taggedLineSegment_0.Parent != taggedLineString_1.Parent)
		{
			return false;
		}
		int index = taggedLineSegment_0.Index;
		int result;
		if (index >= ((int[])object_0)[0])
		{
			if (index < ((int[])object_0)[1])
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private static bool smethod_2(ILineSegmentBase ilineSegmentBase_0, ILineSegmentBase ilineSegmentBase_1)
	{
		lineIntersector_0.ComputeIntersection(ilineSegmentBase_0.P0, ilineSegmentBase_0.P1, ilineSegmentBase_1.P0, ilineSegmentBase_1.P1);
		return lineIntersector_0.IsInteriorIntersection();
	}

	private void Remove(TaggedLineString line, int start, int end)
	{
		for (int i = start; i < end; i++)
		{
			TaggedLineSegment segment = line.GetSegment(i);
			lineSegmentIndex_0.Remove(segment);
		}
	}

	static TaggedLineStringSimplifier()
	{
		Class72.smethod_20();
		lineIntersector_0 = new RobustLineIntersector();
	}
}
