using System;
using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeIntersection : IComparable
{
	private Coordinate coordinate_0;

	private double double_0;

	private int int_0;

	public virtual Coordinate Coordinate
	{
		get
		{
			return coordinate_0;
		}
		set
		{
			coordinate_0 = value;
		}
	}

	public virtual int SegmentIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public virtual double Distance
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

	public EdgeIntersection(Coordinate coord, int segmentIndex, double dist)
	{
		coordinate_0 = new Coordinate(coord);
		int_0 = segmentIndex;
		double_0 = dist;
	}

	public virtual int CompareTo(object obj)
	{
		EdgeIntersection edgeIntersection = (EdgeIntersection)obj;
		return Compare(edgeIntersection.SegmentIndex, edgeIntersection.Distance);
	}

	public virtual int Compare(int segmentIndex, double dist)
	{
		if (SegmentIndex >= segmentIndex)
		{
			if (SegmentIndex > segmentIndex)
			{
				return 1;
			}
			if (Distance < dist)
			{
				return -1;
			}
			return (Distance > dist) ? 1 : 0;
		}
		return -1;
	}

	public virtual bool IsEndPoint(int maxSegmentIndex)
	{
		if (SegmentIndex == 0 && Distance == 0.0)
		{
			return true;
		}
		if (SegmentIndex == maxSegmentIndex)
		{
			return true;
		}
		return false;
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.Write(Coordinate);
		outstream.Write(" seg # = " + SegmentIndex);
		outstream.WriteLine(" dist = " + Distance);
	}

	static EdgeIntersection()
	{
		Class72.smethod_20();
	}
}
