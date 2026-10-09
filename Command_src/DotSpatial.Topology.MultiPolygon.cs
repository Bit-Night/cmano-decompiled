using System;
using System.Collections;

namespace DotSpatial.Topology;

[Serializable]
public class MultiPolygon : GeometryCollection, IMultiPolygon, GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	public new static readonly IMultiPolygon Empty;

	public override DimensionType Dimension => DimensionType.Surface;

	public override DimensionType BoundaryDimension => DimensionType.Curve;

	public override string GeometryType => "MultiPolygon";

	public override FeatureType FeatureType => FeatureType.Polygon;

	public override bool IsSimple => true;

	public override IGeometry Boundary
	{
		get
		{
			if (IsEmpty)
			{
				return base.Factory.CreateGeometryCollection(null);
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Geometries.Length; i++)
			{
				Geometry geometry = (Geometry)((Polygon)Geometries[i]).Boundary;
				for (int j = 0; j < geometry.NumGeometries; j++)
				{
					arrayList.Add(geometry.GetGeometryN(j));
				}
			}
			IGeometryFactory factory = base.Factory;
			IBasicLineString[] lineStrings = (LineString[])arrayList.ToArray(typeof(LineString));
			return factory.CreateMultiLineString(lineStrings);
		}
	}

	public MultiPolygon(Polygon[] polygons)
		: this(polygons, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicPolygon[] polygons)
		: base(polygons, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicGeometry inBasicGeometry)
		: base(inBasicGeometry, Geometry.DefaultFactory)
	{
	}

	public MultiPolygon(IBasicGeometry inBasicGeometry, IGeometryFactory inFactory)
		: base(inBasicGeometry, inFactory)
	{
	}

	public MultiPolygon(IPolygon[] polygons, IGeometryFactory factory)
		: base(polygons, factory)
	{
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (IsEquivalentClass(other))
		{
			return base.EqualsExact(other, tolerance);
		}
		return false;
	}

	public new static IMultiPolygon FromBasicGeometry(IBasicGeometry inGeometry)
	{
		if (inGeometry is IMultiPolygon result)
		{
			return result;
		}
		IPolygon polygon = (IPolygon)inGeometry;
		if (polygon != null)
		{
			IBasicPolygon[] polygons = new IPolygon[1] { polygon };
			return new MultiPolygon(polygons);
		}
		IBasicPolygon basicPolygon = (IBasicPolygon)inGeometry;
		if (basicPolygon == null)
		{
			IPolygon[] array = new IPolygon[inGeometry.NumGeometries];
			for (int i = 0; i < inGeometry.NumGeometries; i++)
			{
				IBasicPolygon polygonBase = (IBasicPolygon)inGeometry.GetBasicGeometryN(i);
				array[i] = new Polygon(polygonBase);
			}
			IBasicPolygon[] polygons = array;
			return new MultiPolygon(polygons);
		}
		return new MultiPolygon(new IBasicPolygon[1] { basicPolygon });
	}

	static MultiPolygon()
	{
		Class72.smethod_20();
		Empty = new GeometryFactory().CreateMultiPolygon(null);
	}
}
