using System;
using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology;

[Serializable]
public class GeometryFactory : IGeometryFactory
{
	private class Class47 : GeometryEditor.CoordinateOperation
	{
		public override IList<Coordinate> Edit(IList<Coordinate> coordinates, IGeometry geometry)
		{
			return coordinates;
		}

		static Class47()
		{
			Class72.smethod_20();
		}
	}

	private static GeometryFactory geometryFactory_0;

	private static GeometryFactory geometryFactory_1;

	private static GeometryFactory geometryFactory_2;

	private static GeometryFactory geometryFactory_3;

	private readonly ICoordinateSequenceFactory icoordinateSequenceFactory_0;

	private readonly PrecisionModel precisionModel_0;

	private readonly int int_0;

	public static IGeometryFactory Default
	{
		get
		{
			return geometryFactory_0;
		}
		set
		{
			geometryFactory_0 = new GeometryFactory(value);
		}
	}

	public IGeometryFactory Fixed
	{
		get
		{
			return geometryFactory_3;
		}
		set
		{
			geometryFactory_3 = new GeometryFactory(value);
		}
	}

	public IGeometryFactory Floating
	{
		get
		{
			return geometryFactory_1;
		}
		set
		{
			geometryFactory_1 = new GeometryFactory(value);
		}
	}

	public IGeometryFactory FloatingSingle
	{
		get
		{
			return geometryFactory_2;
		}
		set
		{
			geometryFactory_2 = new GeometryFactory(value);
		}
	}

	public virtual PrecisionModelType PrecisionModel => precisionModel_0.GetPrecisionModelType();

	public virtual ICoordinateSequenceFactory CoordinateSequenceFactory => icoordinateSequenceFactory_0;

	public virtual int Srid => int_0;

	public GeometryFactory(PrecisionModel precisionModel, int srid, ICoordinateSequenceFactory coordinateSequenceFactory)
	{
		precisionModel_0 = precisionModel;
		icoordinateSequenceFactory_0 = coordinateSequenceFactory;
		int_0 = srid;
	}

	public GeometryFactory(IGeometryFactory gf)
	{
		precisionModel_0 = new PrecisionModel(gf.PrecisionModel);
		icoordinateSequenceFactory_0 = CoordinateArraySequenceFactory.Instance;
		int_0 = gf.Srid;
	}

	public GeometryFactory(IGeometryFactory gf, ICoordinateSequenceFactory coordinateSequenceFactory)
	{
		precisionModel_0 = new PrecisionModel(gf.PrecisionModel);
		icoordinateSequenceFactory_0 = coordinateSequenceFactory;
		int_0 = gf.Srid;
	}

	public GeometryFactory(ICoordinateSequenceFactory coordinateSequenceFactory)
		: this(new PrecisionModel(), 0, coordinateSequenceFactory)
	{
	}

	public GeometryFactory(PrecisionModel precisionModel)
		: this(precisionModel, 0, CoordinateArraySequenceFactory.Instance)
	{
	}

	public GeometryFactory(PrecisionModel precisionModel, int srid)
		: this(precisionModel, srid, CoordinateArraySequenceFactory.Instance)
	{
	}

	public GeometryFactory()
		: this(new PrecisionModel(), 0)
	{
	}

	public virtual IPoint CreatePoint(Coordinate coordinate)
	{
		return new Point(coordinate, this);
	}

	public virtual IMultiLineString CreateMultiLineString(IBasicLineString[] lineStrings)
	{
		if (lineStrings != null)
		{
			int num = lineStrings.Length;
			LineString[] array = new LineString[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new LineString(lineStrings[i]);
			}
			IBasicLineString[] lineStrings2 = array;
			return new MultiLineString(lineStrings2);
		}
		return new MultiLineString();
	}

	public virtual GInterface6 CreateGeometryCollection(IGeometry[] geometries)
	{
		return new GeometryCollection(geometries, this);
	}

	public virtual IMultiPolygon CreateMultiPolygon(IPolygon[] polygons)
	{
		return new MultiPolygon(polygons, this);
	}

	public virtual ILinearRing CreateLinearRing(IList<Coordinate> coordinates)
	{
		return new LinearRing(coordinates);
	}

	public virtual IMultiPoint CreateMultiPoint(IEnumerable<Coordinate> point)
	{
		return new MultiPoint(point, this);
	}

	public IMultiPoint CreateMultiPoint(IEnumerable<ICoordinate> coordinates)
	{
		return new MultiPoint(coordinates);
	}

	public virtual IPolygon CreatePolygon(ILinearRing shell, ILinearRing[] holes)
	{
		return new Polygon(shell, holes, this);
	}

	public virtual IGeometry BuildGeometry(IList geomList)
	{
		Type type = null;
		bool flag = false;
		IEnumerator enumerator = geomList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Type type2 = ((Geometry)enumerator.Current).GetType();
			if (type == null)
			{
				type = type2;
			}
			if (type2 != type)
			{
				flag = true;
			}
		}
		if (type == null)
		{
			return CreateGeometryCollection(null);
		}
		if (flag)
		{
			return CreateGeometryCollection(ToGeometryArray(geomList));
		}
		IEnumerator enumerator2 = geomList.GetEnumerator();
		enumerator2.MoveNext();
		Geometry geometry = (Geometry)enumerator2.Current;
		if (geomList.Count > 1)
		{
			if (geometry is Polygon)
			{
				return CreateMultiPolygon(ToPolygonArray(geomList));
			}
			if (!(geometry is LineString))
			{
				if (!(geometry is Point))
				{
					throw new ShouldNeverReachHereException();
				}
				return new MultiPoint(ToPointArray(geomList));
			}
			IBasicLineString[] lineStrings = ToLineStringArray(geomList);
			return CreateMultiLineString(lineStrings);
		}
		return geometry;
	}

	public virtual ILineString CreateLineString(IList<Coordinate> coordinates)
	{
		return new LineString(coordinates, this);
	}

	public virtual IGeometry CreateGeometry(IGeometry g)
	{
		return new GeometryEditor(this).Edit(g, new Class47());
	}

	public static IPoint CreatePointFromInternalCoord(Coordinate coord, IGeometry exemplar)
	{
		new PrecisionModel(exemplar.PrecisionModel).MakePrecise(coord);
		return exemplar.Factory.CreatePoint(coord);
	}

	public static IPoint[] ToPointArray(IList points)
	{
		return (Point[])new ArrayList(points).ToArray(typeof(Point));
	}

	public static IGeometry[] ToGeometryArray(IList geometries)
	{
		if (geometries == null)
		{
			return null;
		}
		return (Geometry[])new ArrayList(geometries).ToArray(typeof(Geometry));
	}

	public static ILinearRing[] ToLinearRingArray(IList linearRings)
	{
		return (ILinearRing[])new ArrayList(linearRings).ToArray(typeof(LinearRing));
	}

	public static ILineString[] ToLineStringArray(IList lineStrings)
	{
		return (LineString[])new ArrayList(lineStrings).ToArray(typeof(LineString));
	}

	public static IPolygon[] ToPolygonArray(IList polygons)
	{
		return (Polygon[])new ArrayList(polygons).ToArray(typeof(Polygon));
	}

	public static IMultiPolygon[] ToMultiPolygonArray(IList multiPolygons)
	{
		return (IMultiPolygon[])new ArrayList(multiPolygons).ToArray(typeof(MultiPolygon));
	}

	public static IMultiLineString[] ToMultiLineStringArray(IList multiLineStrings)
	{
		return (IMultiLineString[])new ArrayList(multiLineStrings).ToArray(typeof(MultiLineString));
	}

	public static IMultiPoint[] ToMultiPointArray(IList multiPoints)
	{
		return (IMultiPoint[])new ArrayList(multiPoints).ToArray(typeof(MultiPoint));
	}

	public virtual IGeometry ToGeometry(IEnvelope envelope)
	{
		if (envelope.IsNull)
		{
			return CreatePoint(null);
		}
		if (envelope.Minimum.X == envelope.Maximum.X && envelope.Minimum.Y == envelope.Maximum.Y)
		{
			return CreatePoint(new Coordinate(envelope.Minimum.X, envelope.Minimum.Y));
		}
		return CreatePolygon(CreateLinearRing(new Coordinate[5]
		{
			new Coordinate(envelope.Minimum.X, envelope.Minimum.Y),
			new Coordinate(envelope.Maximum.X, envelope.Minimum.Y),
			new Coordinate(envelope.Maximum.X, envelope.Maximum.Y),
			new Coordinate(envelope.Minimum.X, envelope.Maximum.Y),
			new Coordinate(envelope.Minimum.X, envelope.Minimum.Y)
		}), null);
	}

	public virtual IMultiPoint CreateMultiPoint(GInterface5 coordinates)
	{
		if (coordinates == null)
		{
			coordinates = CoordinateSequenceFactory.Create(new Coordinate[0]);
		}
		List<IPoint> list = new List<IPoint>();
		for (int i = 0; i < coordinates.Count; i++)
		{
			list.Add(CreatePoint(coordinates[i]));
		}
		return new MultiPoint(list.ToArray());
	}

	static GeometryFactory()
	{
		Class72.smethod_20();
		geometryFactory_0 = new GeometryFactory();
		geometryFactory_1 = new GeometryFactory();
		geometryFactory_2 = new GeometryFactory(new PrecisionModel(PrecisionModelType.FloatingSingle));
		geometryFactory_3 = new GeometryFactory(new PrecisionModel(PrecisionModelType.Fixed));
	}
}
