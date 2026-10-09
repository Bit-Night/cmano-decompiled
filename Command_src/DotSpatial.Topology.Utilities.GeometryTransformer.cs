using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class GeometryTransformer
{
	private readonly GeometryFactory geometryFactory_0 = Geometry.DefaultFactory;

	private IGeometry igeometry_0;

	public virtual IGeometry InputGeometry => igeometry_0;

	public virtual IGeometry Transform(IGeometry anInputGeom)
	{
		igeometry_0 = anInputGeom;
		if (anInputGeom is IPoint)
		{
			return TransformPoint((Point)anInputGeom);
		}
		if (!(anInputGeom is IMultiPoint))
		{
			if (!(anInputGeom is ILinearRing))
			{
				if (anInputGeom is ILineString)
				{
					return TransformLineString((LineString)anInputGeom);
				}
				if (anInputGeom is IMultiLineString)
				{
					return TransformMultiLineString((IMultiLineString)anInputGeom);
				}
				if (!(anInputGeom is IPolygon))
				{
					if (anInputGeom is IMultiPolygon)
					{
						return TransformMultiPolygon((IMultiPolygon)anInputGeom);
					}
					if (!(anInputGeom is GInterface6))
					{
						throw new ArgumentException("Unknown Geometry subtype: " + anInputGeom.GeometryType);
					}
					return TransformGeometryCollection((GInterface6)anInputGeom, null);
				}
				return TransformPolygon((Polygon)anInputGeom, null);
			}
			return TransformLineString((LinearRing)anInputGeom);
		}
		return TransformMultiPoint((IMultiPoint)anInputGeom);
	}

	protected virtual GInterface5 CreateCoordinateSequence(Coordinate[] coords)
	{
		return geometryFactory_0.CoordinateSequenceFactory.Create(coords);
	}

	protected virtual IList<Coordinate> Copy(IList<Coordinate> seq)
	{
		return EnumerableExt.CloneList(seq);
	}

	protected virtual IList<Coordinate> TransformCoordinates(IList<Coordinate> coords, IGeometry parent)
	{
		return Copy(coords);
	}

	protected virtual IGeometry TransformPoint(IPoint geom)
	{
		return geometryFactory_0.CreatePoint(TransformCoordinates(geom.Coordinates, geom)[0]);
	}

	protected virtual IGeometry TransformMultiPoint(IMultiPoint geom)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geom.NumGeometries; i++)
		{
			IGeometry geometry = TransformPoint((Point)geom.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return geometryFactory_0.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformLinearRing(ILinearRing geom)
	{
		IList<Coordinate> list = TransformCoordinates(geom.Coordinates, geom);
		int count = list.Count;
		if (count > 0 && count < 4)
		{
			return geometryFactory_0.CreateLineString(list);
		}
		return geometryFactory_0.CreateLinearRing(list);
	}

	protected virtual IGeometry TransformLineString(ILineString geom)
	{
		return geometryFactory_0.CreateLineString(TransformCoordinates(geom.Coordinates, geom));
	}

	protected virtual IGeometry TransformMultiLineString(IMultiLineString geom)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geom.NumGeometries; i++)
		{
			IGeometry geometry = TransformLineString((ILineString)geom.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return geometryFactory_0.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformPolygon(IPolygon geom, IGeometry parent)
	{
		bool flag = true;
		IGeometry geometry = TransformLinearRing(geom.Shell);
		int num;
		if (geometry == null)
		{
			num = 0;
		}
		else if (!(geometry is LinearRing))
		{
			num = 0;
		}
		else
		{
			if (!geometry.IsEmpty)
			{
				goto IL_002c;
			}
			num = 0;
		}
		flag = (byte)num != 0;
		goto IL_002c;
		IL_002c:
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geom.NumHoles; i++)
		{
			IGeometry geometry2 = TransformLinearRing((ILinearRing)geom.GetInteriorRingN(i));
			if (geometry2 != null && !geometry2.IsEmpty)
			{
				if (!(geometry2 is LinearRing))
				{
					flag = false;
				}
				arrayList.Add(geometry2);
			}
		}
		if (!flag)
		{
			ArrayList arrayList2 = new ArrayList();
			if (geometry != null)
			{
				arrayList2.Add(geometry);
			}
			foreach (object item in arrayList)
			{
				arrayList2.Add(item);
			}
			return geometryFactory_0.BuildGeometry(arrayList2);
		}
		return geometryFactory_0.CreatePolygon((ILinearRing)geometry, (ILinearRing[])arrayList.ToArray(typeof(ILinearRing)));
	}

	protected virtual IGeometry TransformMultiPolygon(IMultiPolygon geom)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geom.NumGeometries; i++)
		{
			IGeometry geometry = TransformPolygon((Polygon)geom.GetGeometryN(i), geom);
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return geometryFactory_0.BuildGeometry(arrayList);
	}

	protected virtual IGeometry TransformGeometryCollection(GInterface6 geom, IGeometry parent)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geom.NumGeometries; i++)
		{
			IGeometry geometry = Transform(geom.GetGeometryN(i));
			if (geometry != null && !geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		return geometryFactory_0.CreateGeometryCollection(GeometryFactory.ToGeometryArray(arrayList));
	}

	static GeometryTransformer()
	{
		Class72.smethod_20();
	}
}
