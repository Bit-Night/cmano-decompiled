using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Operation;

namespace DotSpatial.Topology;

public class MultiLineString : GeometryCollection, IMultiLineString, GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	public new static readonly IMultiLineString Empty;

	public virtual bool IsClosed
	{
		get
		{
			if (!IsEmpty)
			{
				for (int i = 0; i < Geometries.Length; i++)
				{
					if (!((LineString)Geometries[i]).IsClosed)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	public override DimensionType Dimension => DimensionType.Curve;

	public override DimensionType BoundaryDimension
	{
		get
		{
			if (IsClosed)
			{
				return DimensionType.False;
			}
			return DimensionType.Point;
		}
	}

	public override string GeometryType => "MultiLineString";

	public override bool IsSimple => new IsSimpleOp().IsSimple(this);

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			Coordinate[] boundaryPoints = new GeometryGraph(0, this).GetBoundaryPoints();
			return base.Factory.CreateMultiPoint(boundaryPoints);
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public new ILineString this[int index]
	{
		get
		{
			return base[index] as ILineString;
		}
		set
		{
			base[index] = value;
		}
	}

	public MultiLineString(IEnumerable<IBasicLineString> lineStrings)
	{
		IGeometry[] array = new IGeometry[lineStrings.Count()];
		int num = 0;
		foreach (IBasicLineString lineString in lineStrings)
		{
			array[num] = Geometry.FromBasicGeometry(lineString);
			num++;
		}
		base.Geometries = array;
	}

	public MultiLineString(IBasicLineString[] lineStrings, IGeometryFactory factory)
		: base(lineStrings, factory)
	{
	}

	public MultiLineString(IBasicGeometry inBasicGeometry)
		: base(inBasicGeometry, Geometry.DefaultFactory)
	{
	}

	public MultiLineString(IBasicGeometry inBasicGeometry, IGeometryFactory inFactory)
		: base(inBasicGeometry, inFactory)
	{
	}

	public MultiLineString(IBasicLineString[] lineStrings)
		: this(lineStrings, Geometry.DefaultFactory)
	{
	}

	public MultiLineString()
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

	public virtual IMultiLineString Reverse()
	{
		int num = Geometries.Length;
		ILineString[] array = new LineString[num];
		ILineString[] array2 = array;
		for (int i = 0; i < Geometries.Length; i++)
		{
			array2[num - 1 - i] = new LineString(((ILineString)Geometries[i]).Reverse());
		}
		IGeometryFactory factory = base.Factory;
		IBasicLineString[] lineStrings = array2;
		return factory.CreateMultiLineString(lineStrings);
	}

	static MultiLineString()
	{
		Class72.smethod_20();
		Empty = new MultiLineString();
	}
}
