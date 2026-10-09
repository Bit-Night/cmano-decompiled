using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding;

public class ScaledNoder : INoder
{
	private readonly bool bool_0;

	private readonly INoder inoder_0;

	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	public ScaledNoder(INoder noder, double scaleFactor)
		: this(noder, scaleFactor, 0.0, 0.0)
	{
	}

	public ScaledNoder(INoder noder, double scaleFactor, double offsetX, double offsetY)
	{
		double_0 = offsetX;
		double_1 = offsetY;
		inoder_0 = noder;
		double_2 = scaleFactor;
		bool_0 = !method_0();
	}

	[SpecialName]
	private bool method_0()
	{
		return double_2 == 1.0;
	}

	public IList GetNodedSubstrings()
	{
		IList nodedSubstrings = inoder_0.GetNodedSubstrings();
		if (bool_0)
		{
			method_3(nodedSubstrings);
		}
		return nodedSubstrings;
	}

	public void ComputeNodes(IList inputSegStrings)
	{
		IList segStrings = inputSegStrings;
		if (bool_0)
		{
			segStrings = method_1(inputSegStrings);
		}
		inoder_0.ComputeNodes(segStrings);
	}

	private IList method_1(ICollection icollection_0)
	{
		return CollectionUtil.Transform(icollection_0, delegate(object object_0)
		{
			SegmentString segmentString = (SegmentString)object_0;
			return new SegmentString(method_2(segmentString.Coordinates), segmentString.Data);
		});
	}

	private Coordinate[] method_2(IList<Coordinate> ilist_0)
	{
		Coordinate[] array = new Coordinate[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			array[i] = new Coordinate(Math.Round((ilist_0[i].X - double_0) * double_2), Math.Round((ilist_0[i].Y - double_1) * double_2));
		}
		return array;
	}

	private void method_3(ICollection icollection_0)
	{
		CollectionUtil.Apply(icollection_0, delegate(object object_0)
		{
			SegmentString segmentString = (SegmentString)object_0;
			method_4(segmentString.Coordinates);
			return (object)null;
		});
	}

	private void method_4(IList<Coordinate> ilist_0)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			ilist_0[i].X = ilist_0[i].X / double_2 + double_0;
			ilist_0[i].Y = ilist_0[i].Y / double_2 + double_1;
		}
	}

	[CompilerGenerated]
	private object method_5(object object_0)
	{
		SegmentString segmentString = (SegmentString)object_0;
		return new SegmentString(method_2(segmentString.Coordinates), segmentString.Data);
	}

	[CompilerGenerated]
	private object method_6(object object_0)
	{
		SegmentString segmentString = (SegmentString)object_0;
		method_4(segmentString.Coordinates);
		return null;
	}

	static ScaledNoder()
	{
		Class72.smethod_20();
	}
}
