using System;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding.Snapround;

public class HotPixel
{
	private readonly Coordinate[] coordinate_0 = new Coordinate[4];

	private readonly LineIntersector lineIntersector_0;

	private readonly Coordinate coordinate_1;

	private readonly Coordinate coordinate_2;

	private readonly Coordinate coordinate_3;

	private readonly Coordinate coordinate_4;

	private readonly double double_0;

	private double double_1;

	private double dAleNzixwkc;

	private double double_2;

	private double double_3;

	private Envelope envelope_0;

	public Coordinate Coordinate => coordinate_1;

	public HotPixel(Coordinate pt, double scaleFactor, LineIntersector li)
	{
		coordinate_1 = pt;
		coordinate_4 = pt;
		double_0 = scaleFactor;
		lineIntersector_0 = li;
		if (scaleFactor != 1.0)
		{
			coordinate_4 = new Coordinate(method_1(pt.X), method_1(pt.Y));
			coordinate_2 = new Coordinate();
			coordinate_3 = new Coordinate();
		}
		method_0(coordinate_4);
	}

	public Envelope GetSafeEnvelope()
	{
		if (envelope_0 == null)
		{
			double num = 0.75 / double_0;
			envelope_0 = new Envelope(coordinate_1.X - num, coordinate_1.X + num, coordinate_1.Y - num, coordinate_1.Y + num);
		}
		return envelope_0;
	}

	private void method_0(Coordinate coordinate_5)
	{
		double_2 = coordinate_5.X - 0.5;
		double_1 = coordinate_5.X + 0.5;
		double_3 = coordinate_5.Y - 0.5;
		dAleNzixwkc = coordinate_5.Y + 0.5;
		coordinate_0[0] = new Coordinate(double_1, dAleNzixwkc);
		coordinate_0[1] = new Coordinate(double_2, dAleNzixwkc);
		coordinate_0[2] = new Coordinate(double_2, double_3);
		coordinate_0[3] = new Coordinate(double_1, double_3);
	}

	private double method_1(double double_4)
	{
		return Math.Round(double_4 * double_0);
	}

	public bool Intersects(Coordinate p0, Coordinate p1)
	{
		if (double_0 == 1.0)
		{
			return IntersectsScaled(p0, p1);
		}
		method_2(p0, coordinate_2);
		method_2(p1, coordinate_3);
		return IntersectsScaled(coordinate_2, coordinate_3);
	}

	private void method_2(Coordinate coordinate_5, Coordinate coordinate_6)
	{
		coordinate_6.X = method_1(coordinate_5.X);
		coordinate_6.Y = method_1(coordinate_5.Y);
	}

	public bool IntersectsScaled(Coordinate p0, Coordinate p1)
	{
		double num = Math.Min(p0.X, p1.X);
		double num2 = Math.Max(p0.X, p1.X);
		double num3 = Math.Min(p0.Y, p1.Y);
		double num4 = Math.Max(p0.Y, p1.Y);
		int result;
		if (!(double_1 < num) && !(double_2 > num2) && !(dAleNzixwkc < num3))
		{
			if (!(double_3 > num4))
			{
				bool num5 = method_3(p0, p1);
				Assert.IsTrue(!num5, "Found bad envelope test");
				return num5;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_3(Coordinate coordinate_5, Coordinate coordinate_6)
	{
		bool flag = false;
		bool flag2 = false;
		lineIntersector_0.ComputeIntersection(coordinate_5, coordinate_6, coordinate_0[0], coordinate_0[1]);
		if (lineIntersector_0.IsProper)
		{
			return true;
		}
		lineIntersector_0.ComputeIntersection(coordinate_5, coordinate_6, coordinate_0[1], coordinate_0[2]);
		if (lineIntersector_0.IsProper)
		{
			return true;
		}
		if (lineIntersector_0.HasIntersection)
		{
			flag = true;
		}
		lineIntersector_0.ComputeIntersection(coordinate_5, coordinate_6, coordinate_0[2], coordinate_0[3]);
		if (!lineIntersector_0.IsProper)
		{
			if (lineIntersector_0.HasIntersection)
			{
				flag2 = true;
			}
			lineIntersector_0.ComputeIntersection(coordinate_5, coordinate_6, coordinate_0[3], coordinate_0[0]);
			if (lineIntersector_0.IsProper)
			{
				return true;
			}
			if (!(flag && flag2))
			{
				if (!coordinate_5.Equals(coordinate_4))
				{
					if (coordinate_6.Equals(coordinate_4))
					{
						return true;
					}
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	static HotPixel()
	{
		Class72.smethod_20();
	}
}
