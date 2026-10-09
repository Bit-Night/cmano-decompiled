namespace DotSpatial.Topology;

public class Triangle
{
	private Coordinate coordinate_0;

	private Coordinate coordinate_1;

	private Coordinate coordinate_2;

	public virtual Coordinate P2
	{
		get
		{
			return coordinate_2;
		}
		set
		{
			coordinate_2 = value;
		}
	}

	public virtual Coordinate P1
	{
		get
		{
			return coordinate_1;
		}
		set
		{
			coordinate_1 = value;
		}
	}

	public virtual Coordinate P0
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

	public virtual Coordinate InCentre
	{
		get
		{
			double num = P1.Distance(P2);
			double num2 = P0.Distance(P2);
			double num3 = P0.Distance(P1);
			double num4 = num + num2 + num3;
			double x = (num * P0.X + num2 * P1.X + num3 * P2.X) / num4;
			double y = (num * P0.Y + num2 * P1.Y + num3 * P2.Y) / num4;
			return new Coordinate(x, y);
		}
	}

	public Triangle(Coordinate p0, Coordinate p1, Coordinate p2)
	{
		coordinate_0 = p0;
		coordinate_1 = p1;
		coordinate_2 = p2;
	}

	static Triangle()
	{
		Class72.smethod_20();
	}
}
