using System;
using System.Text;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology;

[Serializable]
public class LineSegment : ILineSegment, IComparable, ILineSegmentBase
{
	private Coordinate coordinate_0;

	private Coordinate coordinate_1;

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

	public virtual double Length => new Coordinate(coordinate_0).Distance(P1);

	public virtual bool IsHorizontal => P0.Y == P1.Y;

	public virtual bool IsVertical => P0.X == P1.X;

	public virtual double Angle => Math.Atan2(P1.Y - P0.Y, P1.X - P0.X);

	public LineSegment(Coordinate p0, Coordinate p1)
	{
		coordinate_0 = p0;
		coordinate_1 = p1;
	}

	public LineSegment(ILineSegmentBase ls)
		: this(ls.P0, ls.P1)
	{
	}

	public LineSegment()
		: this(new Coordinate(), new Coordinate())
	{
	}

	public virtual Coordinate GetCoordinate(int i)
	{
		if (i != 0)
		{
			return new Coordinate(coordinate_1);
		}
		return new Coordinate(coordinate_0);
	}

	public virtual void SetCoordinates(ILineSegmentBase ls)
	{
		SetCoordinates(ls.P0, ls.P1);
	}

	public virtual void SetCoordinates(Coordinate p0, Coordinate p1)
	{
		P0.X = p0.X;
		P0.Y = p0.Y;
		P1.X = p1.X;
		P1.Y = p1.Y;
	}

	public virtual int OrientationIndex(ILineSegmentBase seg)
	{
		int num = CgAlgorithms.OrientationIndex(P0, P1, seg.P0);
		int num2 = CgAlgorithms.OrientationIndex(P0, P1, seg.P1);
		if (num >= 0 && num2 >= 0)
		{
			return Math.Max(num, num2);
		}
		if (num <= 0 && num2 <= 0)
		{
			return Math.Max(num, num2);
		}
		return 0;
	}

	public virtual void Reverse()
	{
		Coordinate p = P0;
		P0 = P1;
		P1 = p;
	}

	public virtual void Normalize()
	{
		if (new Coordinate(P1).CompareTo(P0) < 0)
		{
			Reverse();
		}
	}

	public virtual double Distance(ILineSegmentBase ls)
	{
		return CgAlgorithms.DistanceLineLine(P0, P1, new Coordinate(ls.P0), new Coordinate(ls.P1));
	}

	public virtual double Distance(Coordinate p)
	{
		return CgAlgorithms.DistancePointLine(new Coordinate(p), P0, P1);
	}

	public virtual double DistancePerpendicular(Coordinate p)
	{
		return CgAlgorithms.DistancePointLinePerpendicular(new Coordinate(p), P0, P1);
	}

	public virtual double ProjectionFactor(Coordinate p)
	{
		if (!p.Equals(P0))
		{
			if (p.Equals(P1))
			{
				return 1.0;
			}
			double num = P1.X - P0.X;
			double num2 = P1.Y - P0.Y;
			double num3 = num * num + num2 * num2;
			return ((p.X - P0.X) * num + (p.Y - P0.Y) * num2) / num3;
		}
		return 0.0;
	}

	public virtual Coordinate Project(Coordinate p)
	{
		if (!p.Equals(P0) && !p.Equals(P1))
		{
			double num = ProjectionFactor(p);
			return new Coordinate
			{
				X = P0.X + num * (P1.X - P0.X),
				Y = P0.Y + num * (P1.Y - P0.Y)
			};
		}
		return new Coordinate(p);
	}

	public virtual ILineSegment Project(ILineSegmentBase seg)
	{
		double num = ProjectionFactor(seg.P0);
		double num2 = ProjectionFactor(seg.P1);
		if (num >= 1.0 && num2 >= 1.0)
		{
			return null;
		}
		if (num <= 0.0 && num2 <= 0.0)
		{
			return null;
		}
		Coordinate p = Project(seg.P0);
		if (num < 0.0)
		{
			p = P0;
		}
		if (num > 1.0)
		{
			p = P1;
		}
		Coordinate p2 = Project(seg.P1);
		if (num2 < 0.0)
		{
			p2 = P0;
		}
		if (num2 > 1.0)
		{
			p2 = P1;
		}
		return new LineSegment(p, p2);
	}

	public virtual Coordinate ClosestPoint(Coordinate p)
	{
		double num = ProjectionFactor(p);
		if (num > 0.0 && num < 1.0)
		{
			return Project(p);
		}
		double num2 = new Coordinate(coordinate_0).Distance(p);
		double num3 = new Coordinate(P1).Distance(p);
		if (num2 < num3)
		{
			return new Coordinate(coordinate_0);
		}
		return new Coordinate(coordinate_1);
	}

	public virtual Coordinate[] ClosestPoints(ILineSegmentBase line)
	{
		LineSegment lineSegment = new LineSegment(line);
		Coordinate coordinate = Intersection(line);
		if (coordinate != null)
		{
			return new Coordinate[2] { coordinate, coordinate };
		}
		Coordinate[] array = new Coordinate[2];
		Coordinate coordinate2 = new Coordinate(ClosestPoint(line.P0));
		double num = coordinate2.Distance(line.P0);
		array[0] = coordinate2;
		array[1] = new Coordinate(line.P0);
		Coordinate coordinate3 = new Coordinate(ClosestPoint(line.P1));
		double num2 = coordinate3.Distance(line.P1);
		if (num2 < num)
		{
			num = num2;
			array[0] = coordinate3;
			array[1] = new Coordinate(line.P1);
		}
		Coordinate coordinate4 = new Coordinate(lineSegment.ClosestPoint(P0));
		num2 = coordinate4.Distance(P0);
		if (num2 < num)
		{
			num = num2;
			array[0] = new Coordinate(P0);
			array[1] = coordinate4;
		}
		Coordinate coordinate5 = new Coordinate(lineSegment.ClosestPoint(P1));
		num2 = coordinate5.Distance(P1);
		if (num2 < num)
		{
			array[0] = new Coordinate(P1);
			array[1] = coordinate5;
		}
		return array;
	}

	public virtual Coordinate Intersection(ILineSegmentBase line)
	{
		LineIntersector lineIntersector = new RobustLineIntersector();
		lineIntersector.ComputeIntersection(P0, P1, new Coordinate(line.P0), new Coordinate(line.P1));
		if (!lineIntersector.HasIntersection)
		{
			return null;
		}
		return lineIntersector.GetIntersection(0);
	}

	public ILineSegment Intersection(Envelope inEnvelope)
	{
		return inEnvelope.Intersection(this);
	}

	public bool Intersects(Envelope inEnvelope)
	{
		return inEnvelope.Intersects(this);
	}

	public virtual int CompareTo(object o)
	{
		ILineSegmentBase lineSegmentBase = (ILineSegmentBase)o;
		int num = new Coordinate(coordinate_0).CompareTo(lineSegmentBase.P0);
		if (num != 0)
		{
			return num;
		}
		return new Coordinate(coordinate_1).CompareTo(lineSegmentBase.P1);
	}

	public virtual bool EqualsTopologically(ILineSegmentBase other)
	{
		if (new Coordinate(coordinate_0).Equals(other.P0) && new Coordinate(coordinate_1).Equals(other.P1))
		{
			return true;
		}
		if (!new Coordinate(coordinate_0).Equals(other.P1))
		{
			return false;
		}
		return new Coordinate(coordinate_1).Equals(other.P0);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("LINESTRING( ");
		stringBuilder.Append(P0.X).Append(" ");
		stringBuilder.Append(P0.Y).Append(", ");
		stringBuilder.Append(P1.X).Append(" ");
		stringBuilder.Append(P1.Y).Append(")");
		return stringBuilder.ToString();
	}

	public override bool Equals(object o)
	{
		if (o != null)
		{
			if (!(o is ILineSegmentBase))
			{
				return false;
			}
			ILineSegmentBase lineSegmentBase = (ILineSegmentBase)o;
			if (coordinate_0.X == lineSegmentBase.P0.X && coordinate_0.Y == lineSegmentBase.P0.Y && coordinate_1.X == lineSegmentBase.P1.X)
			{
				return coordinate_1.Y == lineSegmentBase.P1.Y;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(LineSegment obj1, ILineSegmentBase obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(LineSegment obj1, ILineSegmentBase obj2)
	{
		return !(obj1 == obj2);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	static LineSegment()
	{
		Class72.smethod_20();
	}
}
