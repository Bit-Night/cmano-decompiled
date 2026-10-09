using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Operation.Buffer;
using DotSpatial.Topology.Operation.Distance;
using DotSpatial.Topology.Operation.Overlay;
using DotSpatial.Topology.Operation.Predicate;
using DotSpatial.Topology.Operation.Relate;
using DotSpatial.Topology.Operation.Valid;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology;

[Serializable]
public abstract class Geometry : IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable
{
	private class Class46 : IGeometryComponentFilter
	{
		public void Filter(IGeometry geom)
		{
			geom.GeometryChangedAction();
		}

		static Class46()
		{
			Class72.smethod_20();
		}
	}

	private readonly IGeometryFactory igeometryFactory_0;

	private IEnvelope ienvelope_0;

	private int int_0;

	private object object_0;

	private static readonly Type[] type_0;

	public static GeometryFactory DefaultFactory;

	private IGeometry igeometry_0;

	private DimensionType dimensionType_0;

	private DimensionType dimensionType_1;

	public virtual IGeometry EnvelopeAsGeometry => new GeometryFactory(Factory).ToGeometry(new Envelope(EnvelopeInternal));

	public IGeometryFactory Factory => igeometryFactory_0;

	public virtual object UserData
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	[Obsolete("deprecated use {getUserData} instead")]
	public virtual int Srid
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

	public abstract string GeometryType { get; }

	public virtual PrecisionModelType PrecisionModel => Factory.PrecisionModel;

	public abstract Coordinate Coordinate { get; }

	public abstract IList<Coordinate> Coordinates { get; set; }

	public abstract int NumPoints { get; }

	public virtual int NumGeometries => 1;

	public abstract bool IsSimple { get; }

	public virtual bool IsValid => new IsValidOp(this).IsValid;

	public abstract bool IsEmpty { get; }

	public virtual double Area => 0.0;

	public virtual double Length => 0.0;

	public virtual IGeometry InteriorPoint => smethod_0(Dimension switch
	{
		DimensionType.Point => new InteriorPointPoint(this).InteriorPoint, 
		DimensionType.Curve => new InteriorPointLine(this).InteriorPoint, 
		_ => new InteriorPointArea(this).InteriorPoint, 
	}, this);

	public virtual DimensionType Dimension
	{
		get
		{
			return dimensionType_1;
		}
		set
		{
			dimensionType_1 = value;
		}
	}

	public virtual DimensionType BoundaryDimension
	{
		get
		{
			return dimensionType_0;
		}
		set
		{
			dimensionType_0 = value;
		}
	}

	public virtual IEnvelope EnvelopeInternal
	{
		get
		{
			if (ienvelope_0 == null)
			{
				ienvelope_0 = ComputeEnvelopeInternal();
			}
			return ienvelope_0;
		}
	}

	public IEnvelope Envelope
	{
		get
		{
			if (ienvelope_0 == null)
			{
				ienvelope_0 = ComputeEnvelopeInternal();
				return ienvelope_0;
			}
			return ienvelope_0;
		}
	}

	public virtual bool IsRectangle => false;

	public virtual IGeometry Boundary
	{
		get
		{
			return igeometry_0;
		}
		set
		{
			igeometry_0 = value;
		}
	}

	public virtual IPoint Centroid
	{
		get
		{
			if (!IsEmpty)
			{
				Coordinate centroid;
				switch (Dimension)
				{
				default:
				{
					CentroidArea centroidArea = new CentroidArea();
					centroidArea.Add(this);
					centroid = centroidArea.Centroid;
					break;
				}
				case DimensionType.Curve:
				{
					CentroidLine centroidLine = new CentroidLine();
					centroidLine.Add(this);
					centroid = centroidLine.Centroid;
					break;
				}
				case DimensionType.Point:
				{
					CentroidPoint centroidPoint = new CentroidPoint();
					centroidPoint.Add(this);
					centroid = centroidPoint.Centroid;
					break;
				}
				}
				return new Point(centroid);
			}
			return null;
		}
	}

	public virtual FeatureType FeatureType => FeatureType.Unspecified;

	protected Geometry()
	{
		if (DefaultFactory == null)
		{
			DefaultFactory = new GeometryFactory(new PrecisionModel(PrecisionModelType.Floating));
		}
		igeometryFactory_0 = DefaultFactory;
		int_0 = igeometryFactory_0.Srid;
	}

	protected Geometry(IGeometryFactory factory)
	{
		igeometryFactory_0 = factory;
		int_0 = factory.Srid;
	}

	[SpecialName]
	private int method_0()
	{
		int num = 0;
		while (true)
		{
			if (num < type_0.Length)
			{
				if (GetType().Equals(type_0[num]))
				{
					break;
				}
				num++;
				continue;
			}
			throw new ClassNotSupportedException(GetType().FullName);
		}
		return num;
	}

	public virtual IGeometry GetGeometryN(int n)
	{
		return this;
	}

	public virtual IBasicGeometry GetBasicGeometryN(int index)
	{
		return this;
	}

	public virtual double Distance(IGeometry g)
	{
		return DistanceOp.Distance(this, g);
	}

	public virtual bool IsWithinDistance(IGeometry geom, double distance)
	{
		if (EnvelopeInternal.Distance(geom.EnvelopeInternal) <= distance)
		{
			return DistanceOp.IsWithinDistance(this, geom, distance);
		}
		return false;
	}

	public virtual Coordinate ClosestPoint(Coordinate testPoint)
	{
		return Coordinate;
	}

	public virtual void GeometryChanged()
	{
		Apply(new Class46());
	}

	public virtual void GeometryChangedAction()
	{
		ienvelope_0 = null;
	}

	public virtual bool Disjoint(IGeometry g)
	{
		if (!EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			return true;
		}
		return Relate(g).IsDisjoint();
	}

	public virtual bool Touches(IGeometry g)
	{
		if (EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			return Relate(g).IsTouches(Dimension, g.Dimension);
		}
		return false;
	}

	public virtual bool Intersects(IGeometry g)
	{
		if (EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			if (!IsRectangle)
			{
				if (g.IsRectangle)
				{
					return RectangleIntersects.Intersects((Polygon)g, this);
				}
				return Relate(g).IsIntersects();
			}
			return RectangleIntersects.Intersects((Polygon)this, g);
		}
		return false;
	}

	public virtual bool Crosses(IGeometry g)
	{
		if (!EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			return false;
		}
		return Relate(g).IsCrosses(Dimension, g.Dimension);
	}

	public virtual bool Within(IGeometry g)
	{
		return g.Contains(this);
	}

	public virtual bool Overlaps(IGeometry g)
	{
		if (!EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			return false;
		}
		return Relate(g).IsOverlaps(Dimension, g.Dimension);
	}

	public virtual bool Covers(IGeometry g)
	{
		if (!EnvelopeInternal.Contains(g.EnvelopeInternal))
		{
			return false;
		}
		if (IsRectangle)
		{
			return EnvelopeInternal.Contains(g.EnvelopeInternal);
		}
		return Relate(g).IsCovers();
	}

	public virtual bool CoveredBy(IGeometry g)
	{
		return g.Covers(this);
	}

	public virtual bool Relate(IGeometry g, string intersectionPattern)
	{
		return Relate(g).Matches(intersectionPattern);
	}

	public virtual GInterface7 Relate(IGeometry g)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(g);
		return RelateOp.Relate(this, g);
	}

	public virtual bool Equals(IGeometry g)
	{
		if (!EnvelopeInternal.Intersects(g.EnvelopeInternal))
		{
			return false;
		}
		return Relate(g).IsEquals(Dimension, g.Dimension);
	}

	public override string ToString()
	{
		return ToText();
	}

	public virtual byte[] ToBinary()
	{
		return new WkbWriter().Write(this);
	}

	public virtual XmlReader ToGmlFeature()
	{
		return new GmlWriter().Write(this);
	}

	public string ExportToGml()
	{
		return ((object)ToGmlFeature()).ToString();
	}

	public virtual IGeometry ConvexHull()
	{
		return new ConvexHull(this).GetConvexHull();
	}

	public virtual IGeometry Intersection(IGeometry other)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(other);
		return OverlayOp.Overlay(this, other, SpatialFunction.Intersection);
	}

	public virtual void UpdateEnvelope()
	{
		if (NumGeometries > 1)
		{
			for (int i = 0; i < NumGeometries; i++)
			{
				GetGeometryN(i).UpdateEnvelope();
			}
		}
		else
		{
			ClearEnvelope();
			ienvelope_0 = ComputeEnvelopeInternal();
		}
	}

	public virtual void ClearEnvelope()
	{
		ienvelope_0 = null;
	}

	public virtual IGeometry Union(IGeometry other)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(other);
		return OverlayOp.Overlay(this, other, SpatialFunction.Union);
	}

	public virtual IGeometry Difference(IGeometry other)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(other);
		return OverlayOp.Overlay(this, other, SpatialFunction.Difference);
	}

	public virtual IGeometry SymmetricDifference(IGeometry other)
	{
		CheckNotGeometryCollection(this);
		CheckNotGeometryCollection(other);
		return OverlayOp.Overlay(this, other, SpatialFunction.SymDifference);
	}

	public abstract bool EqualsExact(IGeometry other, double tolerance);

	public virtual bool EqualsExact(IGeometry other)
	{
		return EqualsExact(other, 0.0);
	}

	public abstract void Apply(ICoordinateFilter filter);

	public abstract void Apply(IGeometryFilter filter);

	public abstract void Apply(IGeometryComponentFilter filter);

	object ICloneable.Clone()
	{
		Geometry geometry = (Geometry)MemberwiseClone();
		OnCopy(geometry);
		return geometry;
	}

	public abstract void Normalize();

	public virtual int CompareTo(object o)
	{
		Geometry geometry = o as Geometry;
		if (geometry == null)
		{
			Coordinate coordinate = o as Coordinate;
			geometry = ((!(coordinate == null)) ? new Point(coordinate) : (((o as IEnvelope) ?? throw new ApplicationException("the specified object could not be treated like a geometry.")).ToLinearRing() as Geometry));
		}
		if (geometry != null)
		{
			if (method_0() != geometry.method_0())
			{
				return method_0() - geometry.method_0();
			}
			if (IsEmpty && geometry.IsEmpty)
			{
				return 0;
			}
		}
		if (!IsEmpty)
		{
			if (geometry == null)
			{
				return 1;
			}
			if (geometry.IsEmpty)
			{
				return 1;
			}
			return CompareToSameClass(geometry);
		}
		return -1;
	}

	public abstract int CompareToSameClass(object o);

	public virtual IGeometry Buffer(double distance, int quadrantSegments, BufferStyle endCapStyle)
	{
		return BufferOp.Buffer(this, distance, quadrantSegments, endCapStyle);
	}

	public virtual IGeometry Buffer(double distance, int quadrantSegments)
	{
		return BufferOp.Buffer(this, distance, quadrantSegments);
	}

	public virtual IGeometry Buffer(double distance, BufferStyle endCapStyle)
	{
		return BufferOp.Buffer(this, distance, endCapStyle);
	}

	public virtual IGeometry Buffer(double distance)
	{
		return BufferOp.Buffer(this, distance);
	}

	public virtual bool Contains(IGeometry geom)
	{
		if (!EnvelopeInternal.Contains(new Envelope(geom.EnvelopeInternal)))
		{
			return false;
		}
		if (!IsRectangle)
		{
			return Relate(geom).IsContains();
		}
		return RectangleContains.Contains((Polygon)this, geom);
	}

	public abstract void Rotate(Coordinate Origin, double radAngle);

	public static IGeometry FromBasicGeometry(IBasicGeometry geom)
	{
		if (!(geom is IBasicPolygon polygonBase))
		{
			if (!(geom is IBasicLineString lineStringBase))
			{
				if (geom is IBasicPoint coordinate)
				{
					return new Point(coordinate);
				}
				if (geom.NumGeometries > 0)
				{
					IBasicGeometry basicGeometryN = geom.GetBasicGeometryN(0);
					if (basicGeometryN is IBasicPolygon)
					{
						return new MultiPolygon(geom);
					}
					if (basicGeometryN is IBasicLineString)
					{
						return new MultiLineString(geom);
					}
					if (basicGeometryN is IBasicPoint)
					{
						return new MultiPoint(geom);
					}
				}
				else if (geom is IGeometry { IsEmpty: not false } geometry)
				{
					return geometry;
				}
				return null;
			}
			return new LineString(lineStringBase);
		}
		return new Polygon(polygonBase);
	}

	protected static bool HasNonEmptyElements(IGeometry[] geometries)
	{
		int num = 0;
		while (true)
		{
			if (num < geometries.Length)
			{
				if (!geometries[num].IsEmpty)
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

	protected static bool HasNullElements(IEnumerable<IBasicGeometry> array)
	{
		foreach (IBasicGeometry item in array)
		{
			if (item == null)
			{
				return true;
			}
		}
		return false;
	}

	public virtual string ToText()
	{
		return new WktWriter().Write(this);
	}

	protected virtual void OnCopy(Geometry copy)
	{
	}

	protected virtual bool IsEquivalentClass(IGeometry other)
	{
		return GetType().FullName == other.GetType().FullName;
	}

	protected virtual void CheckNotGeometryCollection(IGeometry g)
	{
		if (g.GetType().Name == "GeometryCollection" && g.GetType().Namespace == GetType().Namespace)
		{
			throw new GeometryCollectionNotSupportedException();
		}
	}

	protected abstract IEnvelope ComputeEnvelopeInternal();

	protected virtual int Compare(ArrayList a, ArrayList b)
	{
		IEnumerator enumerator = a.GetEnumerator();
		IEnumerator enumerator2 = b.GetEnumerator();
		while (enumerator.MoveNext() && enumerator2.MoveNext())
		{
			IComparable obj = (IComparable)enumerator.Current;
			IComparable obj2 = (IComparable)enumerator2.Current;
			int num = obj.CompareTo(obj2);
			if (num != 0)
			{
				return num;
			}
		}
		if (!enumerator.MoveNext())
		{
			if (!enumerator2.MoveNext())
			{
				return 0;
			}
			return -1;
		}
		return 1;
	}

	protected virtual bool Equal(Coordinate a, Coordinate b, double tolerance)
	{
		if (tolerance == 0.0)
		{
			return a.Equals(b);
		}
		return a.Distance(b) <= tolerance;
	}

	protected void RotateCoordinateRad(Coordinate Origin, ref double CoordX, ref double CoordY, double RadAngle)
	{
		double num = Origin.X + (Math.Cos(RadAngle) * (CoordX - Origin.X) - Math.Sin(RadAngle) * (CoordY - Origin.Y));
		double num2 = Origin.Y + (Math.Sin(RadAngle) * (CoordX - Origin.X) + Math.Cos(RadAngle) * (CoordY - Origin.Y));
		CoordX = num;
		CoordY = num2;
	}

	private static IPoint smethod_0(Coordinate coordinate_0, IGeometry igeometry_1)
	{
		Coordinate coord = new Coordinate(coordinate_0);
		new PrecisionModel(igeometry_1.PrecisionModel).MakePrecise(coord);
		return igeometry_1.Factory.CreatePoint(coord);
	}

	public bool Intersects(IEnvelope env)
	{
		return Intersects(new Envelope(env).ToPolygon());
	}

	public bool Intersects(double x, double y)
	{
		return Intersects(new Point(x, y));
	}

	static Geometry()
	{
		Class72.smethod_20();
		type_0 = new Type[8]
		{
			typeof(Point),
			typeof(MultiPoint),
			typeof(LineString),
			typeof(LinearRing),
			typeof(MultiLineString),
			typeof(Polygon),
			typeof(MultiPolygon),
			typeof(GeometryCollection)
		};
		DefaultFactory = new GeometryFactory();
	}
}
