using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

[Serializable]
public class MultiPoint : GeometryCollection, IMultiPoint, GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	public new static readonly IMultiPoint Empty;

	public override DimensionType Dimension => DimensionType.Point;

	public override DimensionType BoundaryDimension => DimensionType.False;

	public override string GeometryType => "MultiPoint";

	public override FeatureType FeatureType => FeatureType.MultiPoint;

	public override IGeometry Boundary => base.Factory.CreateGeometryCollection(null);

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override bool IsValid => true;

	public new IPoint this[int index]
	{
		get
		{
			return base[index] as IPoint;
		}
		set
		{
			base[index] = value;
		}
	}

	public MultiPoint(IEnumerable<Coordinate> points, IGeometryFactory factory)
		: base(smethod_1(points), factory)
	{
	}

	public MultiPoint(IBasicGeometry inBasicGeometry)
		: base(inBasicGeometry, Geometry.DefaultFactory)
	{
	}

	public MultiPoint(IEnumerable<Coordinate> points)
		: base(smethod_1(points), Geometry.DefaultFactory)
	{
	}

	public MultiPoint(IEnumerable<ICoordinate> points)
		: base(smethod_2(points), Geometry.DefaultFactory)
	{
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (!IsEquivalentClass(other))
		{
			return false;
		}
		return base.EqualsExact(other, tolerance);
	}

	private static IEnumerable<IBasicGeometry> smethod_1(IEnumerable<Coordinate> ienumerable_0)
	{
		List<IBasicGeometry> list = new List<IBasicGeometry>();
		foreach (Coordinate item in ienumerable_0)
		{
			list.Add(new Point(item));
		}
		return list;
	}

	private static IEnumerable<IBasicGeometry> smethod_2(IEnumerable<ICoordinate> ienumerable_0)
	{
		List<IBasicGeometry> list = new List<IBasicGeometry>();
		foreach (ICoordinate item in ienumerable_0)
		{
			list.Add(new Point(item));
		}
		return list;
	}

	protected virtual Coordinate GetCoordinate(int n)
	{
		return ((Point)Geometries[n]).Coordinate;
	}

	static MultiPoint()
	{
		Class72.smethod_20();
		Empty = new MultiPoint(new Point[0]);
	}
}
