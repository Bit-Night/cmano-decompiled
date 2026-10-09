using System;

namespace DotSpatial.Topology.Algorithm;

public class HCoordinate
{
	private double double_0;

	private double double_1;

	private double double_2;

	[Obsolete("This is a simple access to x private field: use GetX() instead.")]
	protected virtual double X
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[Obsolete("This is a simple access to y private field: use GetY() instead.")]
	protected virtual double Y
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	[Obsolete("This is a simple access to w private field: how do you use this field for?...")]
	protected virtual double W
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

	public virtual Coordinate Coordinate => new Coordinate(GetX(), GetY());

	public HCoordinate()
	{
		double_1 = 0.0;
		double_2 = 0.0;
		double_0 = 1.0;
	}

	public HCoordinate(double x, double y, double w)
	{
		double_1 = x;
		double_2 = y;
		double_0 = w;
	}

	public HCoordinate(Coordinate p)
	{
		double_1 = p.X;
		double_2 = p.Y;
		double_0 = 1.0;
	}

	public HCoordinate(HCoordinate p1, HCoordinate p2)
	{
		double_1 = p1.double_2 * p2.double_0 - p2.double_2 * p1.double_0;
		double_2 = p2.double_1 * p1.double_0 - p1.double_1 * p2.double_0;
		double_0 = p1.double_1 * p2.double_2 - p2.double_1 * p1.double_2;
	}

	public static Coordinate Intersection(Coordinate p1, Coordinate p2, Coordinate q1, Coordinate q2)
	{
		HCoordinate p3 = new HCoordinate(new HCoordinate(p1), new HCoordinate(p2));
		HCoordinate p4 = new HCoordinate(new HCoordinate(q1), new HCoordinate(q2));
		return new HCoordinate(p3, p4).Coordinate;
	}

	public virtual double GetX()
	{
		double num = double_1 / double_0;
		if (double.IsNaN(num) || double.IsInfinity(num))
		{
			throw new NotRepresentableException();
		}
		return num;
	}

	public virtual double GetY()
	{
		double num = double_2 / double_0;
		if (double.IsNaN(num) || double.IsInfinity(num))
		{
			throw new NotRepresentableException();
		}
		return num;
	}

	static HCoordinate()
	{
		Class72.smethod_20();
	}
}
