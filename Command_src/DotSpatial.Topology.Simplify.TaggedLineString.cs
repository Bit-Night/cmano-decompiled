using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Simplify;

public class TaggedLineString
{
	private readonly int int_0;

	private readonly LineString lineString_0;

	private readonly IList ilist_0 = new ArrayList();

	private TaggedLineSegment[] taggedLineSegment_0;

	public virtual int MinimumSize => int_0;

	public virtual LineString Parent => lineString_0;

	public virtual IList<Coordinate> ParentCoordinates => lineString_0.Coordinates;

	public virtual Coordinate[] ResultCoordinates => smethod_0(ilist_0);

	public virtual int ResultSize
	{
		get
		{
			int count = ilist_0.Count;
			if (count != 0)
			{
				return count + 1;
			}
			return 0;
		}
	}

	public virtual TaggedLineSegment[] Segments => taggedLineSegment_0;

	public TaggedLineString(LineString parentLine)
		: this(parentLine, 2)
	{
	}

	public TaggedLineString(LineString parentLine, int minimumSize)
	{
		lineString_0 = parentLine;
		int_0 = minimumSize;
		TrQeGaPyGoj();
	}

	public virtual TaggedLineSegment GetSegment(int i)
	{
		return taggedLineSegment_0[i];
	}

	private void TrQeGaPyGoj()
	{
		IList<Coordinate> coordinates = lineString_0.Coordinates;
		taggedLineSegment_0 = new TaggedLineSegment[coordinates.Count - 1];
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			TaggedLineSegment taggedLineSegment = new TaggedLineSegment(coordinates[i], coordinates[i + 1], lineString_0, i);
			taggedLineSegment_0[i] = taggedLineSegment;
		}
	}

	public virtual void AddToResult(LineSegment seg)
	{
		ilist_0.Add(seg);
	}

	public virtual ILineString AsLineString()
	{
		return lineString_0.Factory.CreateLineString(smethod_0(ilist_0));
	}

	public virtual ILinearRing AsLinearRing()
	{
		return lineString_0.Factory.CreateLinearRing(smethod_0(ilist_0));
	}

	private static Coordinate[] smethod_0(object object_0)
	{
		Coordinate[] array = new Coordinate[((ICollection)object_0).Count + 1];
		LineSegment lineSegment = null;
		for (int i = 0; i < ((ICollection)object_0).Count; i++)
		{
			lineSegment = (LineSegment)((IList)object_0)[i];
			array[i] = lineSegment.P0;
		}
		if (lineSegment != null)
		{
			array[^1] = lineSegment.P1;
		}
		return array;
	}

	static TaggedLineString()
	{
		Class72.smethod_20();
	}
}
