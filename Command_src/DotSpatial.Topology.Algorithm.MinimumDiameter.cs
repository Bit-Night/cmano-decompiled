using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public class MinimumDiameter
{
	private readonly IGeometry igeometry_0;

	private readonly bool bool_0;

	private LineSegment lineSegment_0 = new LineSegment();

	private int int_0;

	private double double_0;

	private Coordinate coordinate_0 = new Coordinate(0.0, 0.0, 0.0, 0.0);

	public virtual double Length
	{
		get
		{
			method_0();
			return double_0;
		}
	}

	public virtual Coordinate WidthCoordinate
	{
		get
		{
			method_0();
			return coordinate_0;
		}
	}

	public virtual ILineString SupportingSegment
	{
		get
		{
			method_0();
			return igeometry_0.Factory.CreateLineString(new Coordinate[2] { lineSegment_0.P0, lineSegment_0.P1 });
		}
	}

	public virtual ILineString Diameter
	{
		get
		{
			method_0();
			if (!coordinate_0.IsEmpty())
			{
				Coordinate coordinate = new Coordinate(lineSegment_0.Project(coordinate_0));
				return igeometry_0.Factory.CreateLineString(new Coordinate[2] { coordinate, coordinate_0 });
			}
			return igeometry_0.Factory.CreateLineString(null);
		}
	}

	public MinimumDiameter(IGeometry inputGeom)
		: this(inputGeom, isConvex: false)
	{
	}

	public MinimumDiameter(IGeometry inputGeom, bool isConvex)
	{
		igeometry_0 = inputGeom;
		bool_0 = isConvex;
	}

	private void method_0()
	{
		if (!coordinate_0.IsEmpty())
		{
			if (!bool_0)
			{
				IGeometry convexHull = new ConvexHull(igeometry_0).GetConvexHull();
				method_1(convexHull);
			}
			else
			{
				method_1(igeometry_0);
			}
		}
	}

	private void method_1(IGeometry igeometry_1)
	{
		IList<Coordinate> list = ((igeometry_1 is Polygon) ? ((Polygon)igeometry_1).Shell.Coordinates : igeometry_1.Coordinates);
		if (list.Count == 0)
		{
			double_0 = 0.0;
			coordinate_0 = Coordinate.Empty;
			lineSegment_0 = null;
		}
		else if (list.Count == 1)
		{
			double_0 = 0.0;
			coordinate_0 = list[0];
			lineSegment_0.P0 = list[0];
			lineSegment_0.P1 = list[0];
		}
		else if (list.Count != 2 && list.Count != 3)
		{
			method_2(list);
		}
		else
		{
			double_0 = 0.0;
			coordinate_0 = list[0];
			lineSegment_0.P0 = list[0];
			lineSegment_0.P1 = list[1];
		}
	}

	private void method_2(IList<Coordinate> ilist_0)
	{
		double_0 = double.MaxValue;
		int int_ = 1;
		LineSegment lineSegment = new LineSegment();
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			lineSegment.P0 = ilist_0[i];
			lineSegment.P1 = ilist_0[i + 1];
			int_ = method_3(ilist_0, lineSegment, int_);
		}
	}

	private int method_3(IList<Coordinate> ilist_0, ILineSegment ilineSegment_0, int int_1)
	{
		double num = ilineSegment_0.DistancePerpendicular(ilist_0[int_1]);
		double num2 = num;
		int num3 = int_1;
		int num4 = num3;
		while (num2 >= num)
		{
			num = num2;
			num3 = num4;
			num4 = smethod_0(ilist_0, num3);
			num2 = ilineSegment_0.DistancePerpendicular(ilist_0[num4]);
		}
		if (num < double_0)
		{
			int_0 = num3;
			double_0 = num;
			coordinate_0 = ilist_0[int_0];
			lineSegment_0 = new LineSegment(ilineSegment_0);
		}
		return num3;
	}

	private static int smethod_0(ICollection<Coordinate> icollection_0, int int_1)
	{
		int_1++;
		if (int_1 >= icollection_0.Count)
		{
			int_1 = 0;
		}
		return int_1;
	}

	static MinimumDiameter()
	{
		Class72.smethod_20();
	}
}
