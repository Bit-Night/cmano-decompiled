using System.Collections;

namespace DotSpatial.Topology.Noding;

public class SegmentStringDissolver
{
	public interface GInterface9
	{
		void Merge(SegmentString mergeTarget, SegmentString ssToMerge, bool isSameOrientation);
	}

	private readonly GInterface9 ginterface9_0;

	private readonly IDictionary idictionary_0 = new SortedList();

	public ICollection Dissolved => idictionary_0.Values;

	public SegmentStringDissolver(GInterface9 merger)
	{
		ginterface9_0 = merger;
	}

	public SegmentStringDissolver()
		: this(null)
	{
	}

	public void Dissolve(ICollection segStrings)
	{
		foreach (object segString in segStrings)
		{
			Dissolve((SegmentString)segString);
		}
	}

	private void Add(OrientedCoordinateArray oca, SegmentString segString)
	{
		idictionary_0.Add(oca, segString);
	}

	public void Dissolve(SegmentString segString)
	{
		OrientedCoordinateArray orientedCoordinateArray = new OrientedCoordinateArray(segString.Coordinates);
		SegmentString segmentString = method_0(orientedCoordinateArray);
		if (segmentString == null)
		{
			Add(orientedCoordinateArray, segString);
		}
		else if (ginterface9_0 != null)
		{
			bool isSameOrientation = object.Equals(segmentString.Coordinates, segString.Coordinates);
			ginterface9_0.Merge(segmentString, segString, isSameOrientation);
		}
	}

	private SegmentString method_0(OrientedCoordinateArray orientedCoordinateArray_0)
	{
		return (SegmentString)idictionary_0[orientedCoordinateArray_0];
	}

	static SegmentStringDissolver()
	{
		Class72.smethod_20();
	}
}
