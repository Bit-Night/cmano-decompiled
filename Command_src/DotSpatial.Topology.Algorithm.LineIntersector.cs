using System;
using System.Text;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Algorithm;

public abstract class LineIntersector
{
	private Coordinate[,] coordinate_0 = new Coordinate[2, 2];

	private int[,] int_0;

	private Coordinate[] coordinate_1 = new Coordinate[2];

	private bool bool_0;

	private PrecisionModel precisionModel_0;

	private IntersectionType intersectionType_0;

	protected Coordinate PointA
	{
		get
		{
			return coordinate_1[0];
		}
		set
		{
			coordinate_1[0] = value;
		}
	}

	protected Coordinate PointB
	{
		get
		{
			return coordinate_1[0];
		}
		set
		{
			coordinate_1[0] = value;
		}
	}

	[Obsolete("Use PrecisionModel instead")]
	public virtual PrecisionModel MakePrecise
	{
		set
		{
			precisionModel_0 = value;
		}
	}

	public virtual PrecisionModel PrecisionModel
	{
		get
		{
			return precisionModel_0;
		}
		set
		{
			precisionModel_0 = value;
		}
	}

	public virtual bool HasIntersection => intersectionType_0 != IntersectionType.NoIntersection;

	public virtual int IntersectionNum => (int)intersectionType_0;

	public Coordinate[] IntersectionPoints
	{
		get
		{
			return coordinate_1;
		}
		protected set
		{
			coordinate_1 = value;
		}
	}

	protected Coordinate[,] InputLines
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

	protected virtual bool IsCollinear => intersectionType_0 == IntersectionType.Collinear;

	protected virtual bool IsEndPoint
	{
		get
		{
			if (!HasIntersection)
			{
				return false;
			}
			return !bool_0;
		}
	}

	public virtual bool IsProper
	{
		get
		{
			if (!HasIntersection)
			{
				return false;
			}
			return bool_0;
		}
		protected set
		{
			bool_0 = value;
		}
	}

	protected IntersectionType Result
	{
		get
		{
			return intersectionType_0;
		}
		set
		{
			intersectionType_0 = value;
		}
	}

	protected LineIntersector()
	{
		coordinate_1[0] = new Coordinate();
		coordinate_1[1] = new Coordinate();
		intersectionType_0 = IntersectionType.NoIntersection;
	}

	public static double ComputeEdgeDistance(Coordinate p, Coordinate p0, Coordinate p1)
	{
		double num = Math.Abs(p1.X - p0.X);
		double num2 = Math.Abs(p1.Y - p0.Y);
		double num5;
		if (!p.Equals(p0))
		{
			if (!p.Equals(p1))
			{
				double num3 = Math.Abs(p.X - p0.X);
				double num4 = Math.Abs(p.Y - p0.Y);
				num5 = ((!(num > num2)) ? num4 : num3);
				if (num5 == 0.0 && !p.Equals(p0))
				{
					num5 = Math.Max(num3, num4);
				}
			}
			else
			{
				num5 = ((num > num2) ? num : num2);
			}
		}
		else
		{
			num5 = 0.0;
		}
		Assert.IsTrue(num5 != 0.0 || p.Equals(p0), "Bad distance calculation");
		return num5;
	}

	public static double NonRobustComputeEdgeDistance(Coordinate p, Coordinate p1, Coordinate p2)
	{
		double num = p.X - p1.X;
		double num2 = p.Y - p1.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		Assert.IsTrue(num3 != 0.0 || p.Equals(p1), "Invalid distance calculation");
		return num3;
	}

	public abstract void ComputeIntersection(Coordinate p, Coordinate p1, Coordinate p2);

	public virtual void ComputeIntersection(Coordinate p1, Coordinate p2, Coordinate p3, Coordinate p4)
	{
		coordinate_0[0, 0] = new Coordinate(p1);
		coordinate_0[0, 1] = new Coordinate(p2);
		coordinate_0[1, 0] = new Coordinate(p3);
		coordinate_0[1, 1] = new Coordinate(p4);
		intersectionType_0 = ComputeIntersect(p1, p2, p3, p4);
	}

	public abstract IntersectionType ComputeIntersect(Coordinate p1, Coordinate p2, Coordinate q1, Coordinate q2);

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(coordinate_0[0, 0]).Append("-");
		stringBuilder.Append(coordinate_0[0, 1]).Append(" ");
		stringBuilder.Append(coordinate_0[1, 0]).Append("-");
		stringBuilder.Append(coordinate_0[1, 1]).Append(" : ");
		if (IsEndPoint)
		{
			stringBuilder.Append(" endpoint");
		}
		if (bool_0)
		{
			stringBuilder.Append(" proper");
		}
		if (IsCollinear)
		{
			stringBuilder.Append(" collinear");
		}
		return stringBuilder.ToString();
	}

	public virtual Coordinate GetIntersection(int intIndex)
	{
		return new Coordinate(coordinate_1[intIndex]);
	}

	protected virtual void ComputeIntLineIndex()
	{
		if (int_0 == null)
		{
			int_0 = new int[2, 2];
			ComputeIntLineIndex(0);
			ComputeIntLineIndex(1);
		}
	}

	public virtual bool IsIntersection(Coordinate pt)
	{
		int num = 0;
		while (true)
		{
			if (num < (int)intersectionType_0)
			{
				if (new Coordinate(coordinate_1[num]).Equals2D(pt))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public virtual bool IsInteriorIntersection()
	{
		if (!IsInteriorIntersection(0))
		{
			if (!IsInteriorIntersection(1))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public virtual bool IsInteriorIntersection(int inputLineIndex)
	{
		for (int i = 0; i < (int)intersectionType_0; i++)
		{
			Coordinate coordinate = new Coordinate(coordinate_1[i]);
			if (!coordinate.Equals2D(coordinate_0[inputLineIndex, 0]) && !coordinate.Equals2D(coordinate_0[inputLineIndex, 1]))
			{
				return true;
			}
		}
		return false;
	}

	public virtual Coordinate GetIntersectionAlongSegment(int segmentIndex, int intIndex)
	{
		ComputeIntLineIndex();
		return new Coordinate(coordinate_1[int_0[segmentIndex, intIndex]]);
	}

	public virtual int GetIndexAlongSegment(int segmentIndex, int intIndex)
	{
		ComputeIntLineIndex();
		return int_0[segmentIndex, intIndex];
	}

	protected virtual void ComputeIntLineIndex(int segmentIndex)
	{
		double edgeDistance = GetEdgeDistance(segmentIndex, 0);
		double edgeDistance2 = GetEdgeDistance(segmentIndex, 1);
		if (edgeDistance <= edgeDistance2)
		{
			int_0[segmentIndex, 0] = 1;
			int_0[segmentIndex, 1] = 0;
		}
		else
		{
			int_0[segmentIndex, 0] = 0;
			int_0[segmentIndex, 1] = 1;
		}
	}

	public virtual double GetEdgeDistance(int segmentIndex, int intIndex)
	{
		return ComputeEdgeDistance(coordinate_1[intIndex], coordinate_0[segmentIndex, 0], coordinate_0[segmentIndex, 1]);
	}

	static LineIntersector()
	{
		Class72.smethod_20();
	}
}
