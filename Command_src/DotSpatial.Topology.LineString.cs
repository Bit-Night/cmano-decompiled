using System;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

[Serializable]
public class LineString : Geometry, ILineString, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicLineString
{
	public static readonly ILineString Empty;

	private IList<Coordinate> ilist_0;

	public virtual int Count => ilist_0.Count;

	public virtual Coordinate this[int n]
	{
		get
		{
			return ilist_0[n];
		}
		set
		{
			ilist_0[n] = value;
		}
	}

	public virtual double Angle
	{
		get
		{
			double num = EndPoint.X - StartPoint.X;
			double num2 = EndPoint.Y - StartPoint.Y;
			double num3 = Math.Sqrt(num * num + num2 * num2);
			double num4 = Math.Asin(Math.Abs(EndPoint.Y - StartPoint.Y) / num3) * 180.0 / Math.PI;
			if ((StartPoint.X < EndPoint.X && StartPoint.Y > EndPoint.Y) || (StartPoint.X > EndPoint.X && StartPoint.Y < EndPoint.Y))
			{
				num4 = 360.0 - num4;
			}
			return num4;
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			if (!IsClosed)
			{
				return base.Factory.CreateMultiPoint(new Coordinate[2] { StartPoint.Coordinate, EndPoint.Coordinate });
			}
			return MultiPoint.Empty;
		}
	}

	public override DimensionType BoundaryDimension
	{
		get
		{
			if (!IsClosed)
			{
				return DimensionType.Point;
			}
			return DimensionType.False;
		}
	}

	public override Coordinate Coordinate
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return ilist_0.First();
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
			if (!value.GetType().IsArray)
			{
				ilist_0 = value;
			}
			else
			{
				ilist_0 = value.ToList();
			}
		}
	}

	public override DimensionType Dimension => DimensionType.Curve;

	public virtual IPoint EndPoint
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return GetPointN(NumPoints - 1);
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public override string GeometryType => "LineString";

	public virtual bool IsClosed
	{
		get
		{
			if (IsEmpty)
			{
				return false;
			}
			return new Coordinate(GetCoordinateN(0)).Equals2D(GetCoordinateN(NumPoints - 1));
		}
	}

	public override bool IsEmpty => ilist_0.Count == 0;

	public virtual bool IsRing
	{
		get
		{
			if (!IsClosed)
			{
				return false;
			}
			return IsSimple;
		}
	}

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override double Length => CgAlgorithms.Length(ilist_0);

	public override int NumPoints => ilist_0.Count;

	public virtual IPoint StartPoint
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return GetPointN(0);
		}
	}

	public LineString(IList<Coordinate> points, IGeometryFactory factory)
		: base(factory)
	{
		if (points == null)
		{
			points = new List<Coordinate>();
		}
		if (points.Count == 1)
		{
			throw new ArgumentException("point array must contain 0 or > 1 elements");
		}
		if (points.GetType().IsArray)
		{
			ilist_0 = points.ToList();
		}
		else
		{
			ilist_0 = points;
		}
	}

	public LineString(IList<Coordinate> points)
		: this(points, Geometry.DefaultFactory)
	{
	}

	public LineString(IBasicLineString lineStringBase)
		: this(lineStringBase.Coordinates, Geometry.DefaultFactory)
	{
	}

	public LineString(IBasicLineString lineString, IGeometryFactory factory)
		: this(lineString.Coordinates, factory)
	{
	}

	public LineString(IGeometryFactory factory)
		: base(factory)
	{
		ilist_0 = new List<Coordinate>();
	}

	public LineString(IEnumerable<Coordinate> coordinates)
		: base(Geometry.DefaultFactory)
	{
		if (coordinates != null)
		{
			if (!coordinates.GetType().IsArray)
			{
				ilist_0 = coordinates as IList<Coordinate>;
				if (ilist_0 != null)
				{
					return;
				}
			}
			ilist_0 = new List<Coordinate>();
			{
				foreach (Coordinate coordinate in coordinates)
				{
					ilist_0.Add(coordinate);
				}
				return;
			}
		}
		ilist_0 = new List<Coordinate>();
	}

	public LineString(IEnumerable<ICoordinate> coordinates)
		: base(Geometry.DefaultFactory)
	{
		if (coordinates == null)
		{
			ilist_0 = new List<Coordinate>();
			return;
		}
		if (!coordinates.GetType().IsArray)
		{
			ilist_0 = coordinates as IList<Coordinate>;
			if (ilist_0 != null)
			{
				return;
			}
		}
		ilist_0 = new List<Coordinate>();
		foreach (ICoordinate coordinate in coordinates)
		{
			ilist_0.Add(new Coordinate(coordinate));
		}
	}

	public override void Apply(ICoordinateFilter filter)
	{
		foreach (Coordinate item in ilist_0)
		{
			filter.Filter(item);
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

	public override int CompareToSameClass(object o)
	{
		LineString lineString = o as LineString;
		int num = 0;
		int num2 = 0;
		if (lineString != null)
		{
			while (num < ilist_0.Count && num2 < lineString.ilist_0.Count)
			{
				int num3 = ilist_0[num].CompareTo(lineString.ilist_0[num2]);
				if (num3 == 0)
				{
					num++;
					num2++;
					continue;
				}
				return num3;
			}
		}
		if (num < ilist_0.Count)
		{
			return 1;
		}
		int result;
		if (lineString == null)
		{
			result = 0;
		}
		else
		{
			if (num2 < lineString.ilist_0.Count)
			{
				return -1;
			}
			result = 0;
		}
		return result;
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (IsEquivalentClass(other))
		{
			LineString lineString = (LineString)other;
			if (ilist_0.Count != lineString.ilist_0.Count)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < ilist_0.Count)
				{
					if (!Equal(new Coordinate(ilist_0[num]), lineString.ilist_0[num], tolerance))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public override Coordinate ClosestPoint(Coordinate testPoint)
	{
		Coordinate result = Coordinate;
		double num = double.MaxValue;
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			Coordinate coordinate = new LineSegment(ilist_0[i], ilist_0[i + 1]).ClosestPoint(testPoint);
			double num2 = testPoint.Distance(coordinate);
			if (num2 < num)
			{
				num = num2;
				result = coordinate;
			}
		}
		return result;
	}

	public virtual IPoint GetPointN(int n)
	{
		return new Point(ilist_0[n]);
	}

	public virtual bool IsCoordinate(Coordinate pt)
	{
		Coordinate coordinate = new Coordinate(pt);
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (coordinate == ilist_0[i])
			{
				return true;
			}
		}
		return false;
	}

	public override void Normalize()
	{
		for (int i = 0; i < ilist_0.Count / 2; i++)
		{
			int index = ilist_0.Count - 1 - i;
			if (!ilist_0[i].Equals(ilist_0[index]))
			{
				if (ilist_0[i].CompareTo(ilist_0[index]) > 0)
				{
					ilist_0 = ilist_0.Reverse().ToList();
				}
				break;
			}
		}
	}

	public virtual ILineString Reverse()
	{
		List<Coordinate> list = EnumerableExt.CloneList(Coordinates);
		list.Reverse();
		return new LineString(list);
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		if (!IsEmpty)
		{
			double num = ilist_0[0].X;
			double num2 = ilist_0[0].Y;
			double num3 = ilist_0[0].X;
			double num4 = ilist_0[0].Y;
			for (int i = 1; i < ilist_0.Count; i++)
			{
				num = ((num < ilist_0[i].X) ? num : ilist_0[i].X);
				num3 = ((num3 <= ilist_0[i].X) ? ilist_0[i].X : num3);
				num2 = ((num2 >= ilist_0[i].Y) ? ilist_0[i].Y : num2);
				num4 = ((num4 <= ilist_0[i].Y) ? ilist_0[i].Y : num4);
			}
			return new Envelope(num, num3, num2, num4);
		}
		return new Envelope();
	}

	protected override void OnCopy(Geometry copy)
	{
		base.OnCopy(copy);
		if (!(copy is LineString lineString))
		{
			return;
		}
		lineString.Coordinates = new List<Coordinate>();
		foreach (Coordinate item in ilist_0)
		{
			lineString.Coordinates.Add(item);
		}
	}

	public virtual Coordinate GetCoordinateN(int n)
	{
		return ilist_0[n];
	}

	protected override bool IsEquivalentClass(IGeometry other)
	{
		return other is LineString;
	}

	public ILineString Offset(double distance)
	{
		if (distance != 0.0)
		{
			throw new NotImplementedException("This is not yet implemented");
		}
		return CloneableEM.Copy(this);
	}

	public override void Rotate(Coordinate Origin, double radAngle)
	{
		for (int i = 0; i < ilist_0.Count; i++)
		{
			RotateCoordinateRad(Origin, ref ilist_0[i].X, ref ilist_0[i].Y, radAngle);
		}
	}

	static LineString()
	{
		Class72.smethod_20();
		Empty = new GeometryFactory().CreateLineString(new List<Coordinate>());
	}
}
