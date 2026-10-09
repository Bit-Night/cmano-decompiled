using System;
using System.Collections;
using System.IO;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding;

public class SegmentNodeList : IEnumerable
{
	private readonly SegmentString segmentString_0;

	private readonly IDictionary idictionary_0 = new SortedList();

	public SegmentString Edge => segmentString_0;

	public SegmentNodeList(SegmentString edge)
	{
		segmentString_0 = edge;
	}

	public IEnumerator GetEnumerator()
	{
		return idictionary_0.Values.GetEnumerator();
	}

	public void Add(Coordinate intPt, int segmentIndex)
	{
		SegmentNode segmentNode = new SegmentNode(segmentString_0, intPt, segmentIndex, segmentString_0.GetSegmentOctant(segmentIndex));
		SegmentNode segmentNode2 = (SegmentNode)idictionary_0[segmentNode];
		if (segmentNode2 != null)
		{
			Assert.IsTrue(segmentNode2.Coordinate.Equals2D(intPt), "Found equal nodes with different coordinates");
		}
		else
		{
			idictionary_0.Add(segmentNode, segmentNode);
		}
	}

	private void method_0()
	{
		int num = segmentString_0.Count - 1;
		Add(segmentString_0.GetCoordinate(0), 0);
		Add(segmentString_0.GetCoordinate(num), num);
	}

	private void method_1()
	{
		IList list = new ArrayList();
		method_3(list);
		method_2(list);
		foreach (int item in list)
		{
			Add(segmentString_0.GetCoordinate(item), item);
		}
	}

	private void method_2(IList ilist_0)
	{
		for (int i = 0; i < segmentString_0.Count - 2; i++)
		{
			Coordinate coordinate = segmentString_0.GetCoordinate(i);
			Coordinate coordinate2 = segmentString_0.GetCoordinate(i + 2);
			if (coordinate.Equals2D(coordinate2))
			{
				ilist_0.Add(i + 1);
			}
		}
	}

	private void method_3(IList ilist_0)
	{
		int[] array = new int[1];
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		SegmentNode coordinate_ = (SegmentNode)enumerator.Current;
		while (enumerator.MoveNext())
		{
			SegmentNode segmentNode = (SegmentNode)enumerator.Current;
			if (smethod_0((Coordinate)(object)coordinate_, segmentNode, array))
			{
				ilist_0.Add(array[0]);
			}
			coordinate_ = segmentNode;
		}
	}

	private static bool smethod_0(Coordinate coordinate_0, object object_0, object object_1)
	{
		if (((SegmentNode)(object)coordinate_0).Coordinate.Equals2D(((SegmentNode)object_0).Coordinate))
		{
			int num = ((SegmentNode)object_0).SegmentIndex - ((SegmentNode)(object)coordinate_0).SegmentIndex;
			if (!((SegmentNode)object_0).IsInterior)
			{
				num--;
			}
			if (num == 1)
			{
				((int[])object_1)[0] = ((SegmentNode)(object)coordinate_0).SegmentIndex + 1;
				return true;
			}
			return false;
		}
		return false;
	}

	public void AddSplitEdges(IList edgeList)
	{
		method_0();
		method_1();
		IEnumerator enumerator = GetEnumerator();
		enumerator.MoveNext();
		SegmentNode segmentNode_ = (SegmentNode)enumerator.Current;
		while (enumerator.MoveNext())
		{
			SegmentNode segmentNode = (SegmentNode)enumerator.Current;
			SegmentString value = method_4(segmentNode_, segmentNode);
			edgeList.Add(value);
			segmentNode_ = segmentNode;
		}
	}

	private SegmentString method_4(SegmentNode segmentNode_0, SegmentNode segmentNode_1)
	{
		int num = segmentNode_1.SegmentIndex - segmentNode_0.SegmentIndex + 2;
		Coordinate coordinate = segmentString_0.GetCoordinate(segmentNode_1.SegmentIndex);
		bool flag;
		if (!(flag = segmentNode_1.IsInterior || !segmentNode_1.Coordinate.Equals2D(coordinate)))
		{
			num--;
		}
		Coordinate[] array = new Coordinate[num];
		int num2 = 0;
		num2 = 1;
		array[0] = new Coordinate(segmentNode_0.Coordinate);
		for (int i = segmentNode_0.SegmentIndex + 1; i <= segmentNode_1.SegmentIndex; i++)
		{
			array[num2++] = segmentString_0.GetCoordinate(i);
		}
		if (flag)
		{
			array[num2] = segmentNode_1.Coordinate;
		}
		return new SegmentString(array, segmentString_0.Data);
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.Write("Intersections:");
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((SegmentNode)enumerator.Current).Write(outstream);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	static SegmentNodeList()
	{
		Class72.smethod_20();
	}
}
