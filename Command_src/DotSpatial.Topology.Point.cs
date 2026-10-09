using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

[Serializable]
public class Point : Geometry, IPoint, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicPoint, ICoordinate
{
	private IList<Coordinate> ilist_0 = new List<Coordinate>();

	private int int_1;

	public static readonly IPoint Empty;

	public double this[int index]
	{
		get
		{
			return Coordinate[index];
		}
		set
		{
			Coordinate[index] = value;
		}
	}

	public int RecordNumber
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public override IGeometry Boundary => base.Factory.CreateGeometryCollection(null);

	public override DimensionType BoundaryDimension => DimensionType.False;

	public override Coordinate Coordinate
	{
		get
		{
			if (ilist_0 == null)
			{
				ilist_0 = new List<Coordinate>();
			}
			if (ilist_0.Count == 0)
			{
				ilist_0.Add(new Coordinate());
			}
			return ilist_0[0];
		}
	}

	public override IList<Coordinate> Coordinates
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public override DimensionType Dimension => DimensionType.Point;

	public int NumOrdinates => Coordinate.NumOrdinates;

	public new IEnvelope Envelope => new Envelope(X, X, Y, Y);

	public override FeatureType FeatureType => FeatureType.Point;

	public override string GeometryType => "Point";

	public override bool IsEmpty => Coordinate == null;

	public override bool IsSimple => true;

	public override bool IsValid => true;

	public virtual double M
	{
		get
		{
			if (Coordinate == null)
			{
				throw new ArgumentOutOfRangeException();
			}
			return Coordinate.M;
		}
		set
		{
			Coordinate.M = value;
		}
	}

	public override int NumPoints => (!IsEmpty) ? 1 : 0;

	public double[] Values
	{
		get
		{
			return Coordinate.ToArray();
		}
		set
		{
			SetCoordinate(new Coordinate(value));
		}
	}

	public virtual double X
	{
		get
		{
			return Coordinate.X;
		}
		set
		{
			Coordinate.X = value;
		}
	}

	public virtual double Y
	{
		get
		{
			return Coordinate.Y;
		}
		set
		{
			Coordinate.Y = value;
		}
	}

	public virtual double Z
	{
		get
		{
			return Coordinate.Z;
		}
		set
		{
			Coordinate.Z = value;
		}
	}

	public Point()
	{
		ilist_0.Add(new Coordinate());
	}

	public Point(IGeometryFactory factory)
		: base(factory)
	{
		ilist_0.Add(new Coordinate());
	}

	public Point(Coordinate coordinate)
		: this(coordinate, new GeometryFactory())
	{
	}

	public Point(ICoordinate coordinate)
		: this(new Coordinate(coordinate), new GeometryFactory())
	{
	}

	public Point(Coordinate coordinate, IGeometryFactory factory)
		: base(factory)
	{
		ilist_0.Add(coordinate);
	}

	public Point(double x, double y, double z)
		: this(new Coordinate(x, y, z), Geometry.DefaultFactory)
	{
	}

	public Point(double x, double y)
		: this(new Coordinate(x, y), Geometry.DefaultFactory)
	{
	}

	public override void Apply(ICoordinateFilter filter)
	{
		if (!IsEmpty)
		{
			filter.Filter(Coordinate);
		}
	}

	public override void Apply(IGeometryFilter filter)
	{
		filter.Filter(this);
	}

	public override void Apply(IGeometryComponentFilter filter)
	{
		filter.Filter(this);
	}

	public override int CompareToSameClass(object other)
	{
		Point point = (Point)other;
		return Coordinate.CompareTo(point.Coordinate);
	}

	public override Coordinate ClosestPoint(Coordinate testPoint)
	{
		return Coordinate;
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (!IsEquivalentClass(other))
		{
			return false;
		}
		if (IsEmpty && other.IsEmpty)
		{
			return true;
		}
		return Equal(new Coordinate(other.Coordinate), Coordinate, tolerance);
	}

	public override void Normalize()
	{
	}

	protected override void OnCopy(Geometry copy)
	{
		base.OnCopy(copy);
		if (copy is Point point)
		{
			point.SetCoordinate(CloneableEM.Copy(Coordinate));
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		if (!IsEmpty)
		{
			return new Envelope(Coordinate.X, Coordinate.X, Coordinate.Y, Coordinate.Y);
		}
		return new Envelope();
	}

	public double Distance(Coordinate coord)
	{
		double num = X - coord.X;
		double num2 = Y - coord.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public double HyperDistance(Coordinate coordinate)
	{
		if (coordinate.NumOrdinates != NumOrdinates)
		{
			throw new CoordinateMismatchException();
		}
		double num = 0.0;
		double[] array = coordinate.ToArray();
		for (int i = 0; i < NumOrdinates; i++)
		{
			double num2 = array[i] - Coordinate[i];
			num += num2 * num2;
		}
		return Math.Sqrt(num);
	}

	public bool Equals2D(Coordinate coord)
	{
		if (X == coord.X && Y == coord.Y)
		{
			return true;
		}
		return false;
	}

	public bool Equals3D(Coordinate coord)
	{
		if (X == coord.X && Y == coord.Y && Z == coord.Z)
		{
			return true;
		}
		return false;
	}

	public override void Rotate(Coordinate Origin, double radAngle)
	{
		RotateCoordinateRad(Origin, ref Coordinate.X, ref Coordinate.Y, radAngle);
	}

	public void SetCoordinate(Coordinate value)
	{
		if (ilist_0 == null)
		{
			ilist_0 = new List<Coordinate>();
		}
		if (ilist_0.Count == 0)
		{
			ilist_0.Add(value);
		}
		else
		{
			ilist_0[0] = value;
		}
	}

	public double[] ToArray()
	{
		return Coordinate.ToArray();
	}

	static Point()
	{
		Class72.smethod_20();
		Empty = new GeometryFactory().CreatePoint(null);
	}
}
