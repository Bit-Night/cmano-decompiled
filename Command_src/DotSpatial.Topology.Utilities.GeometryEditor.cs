using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Utilities;

public class GeometryEditor
{
	public abstract class CoordinateOperation : IGeometryEditorOperation
	{
		public virtual IGeometry Edit(IGeometry geometry, IGeometryFactory factory)
		{
			if (geometry is LinearRing)
			{
				return factory.CreateLinearRing(Edit(geometry.Coordinates, geometry));
			}
			if (!(geometry is LineString))
			{
				if (geometry is Point)
				{
					IList<Coordinate> list = Edit(geometry.Coordinates, geometry);
					return factory.CreatePoint((list.Count <= 0) ? null : list[0]);
				}
				return geometry;
			}
			return factory.CreateLineString(Edit(geometry.Coordinates, geometry));
		}

		public abstract IList<Coordinate> Edit(IList<Coordinate> coordinates, IGeometry geometry);

		static CoordinateOperation()
		{
			Class72.smethod_20();
		}
	}

	public interface IGeometryEditorOperation
	{
		IGeometry Edit(IGeometry geometry, IGeometryFactory factory);
	}

	private IGeometryFactory igeometryFactory_0;

	public GeometryEditor()
	{
	}

	public GeometryEditor(IGeometryFactory factory)
	{
		igeometryFactory_0 = factory;
	}

	public virtual IGeometry Edit(IGeometry geometry, IGeometryEditorOperation operation)
	{
		if (igeometryFactory_0 == null)
		{
			igeometryFactory_0 = geometry.Factory;
		}
		if (geometry is GeometryCollection)
		{
			return method_1(geometry, operation);
		}
		if (!(geometry is Polygon))
		{
			if (geometry is Point)
			{
				return operation.Edit(geometry, igeometryFactory_0);
			}
			if (!(geometry is LineString))
			{
				throw new UnsupportedGeometryException();
			}
			return operation.Edit(geometry, igeometryFactory_0);
		}
		return method_0(geometry, operation);
	}

	private IPolygon method_0(IGeometry igeometry_0, IGeometryEditorOperation igeometryEditorOperation_0)
	{
		Polygon polygon = (Polygon)igeometryEditorOperation_0.Edit(igeometry_0, igeometryFactory_0);
		if (!polygon.IsEmpty)
		{
			LinearRing linearRing = (LinearRing)Edit(polygon.Shell, igeometryEditorOperation_0);
			if (linearRing.IsEmpty)
			{
				return igeometryFactory_0.CreatePolygon(null, null);
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < polygon.NumHoles; i++)
			{
				LinearRing linearRing2 = (LinearRing)Edit(polygon.GetInteriorRingN(i), igeometryEditorOperation_0);
				if (!linearRing2.IsEmpty)
				{
					arrayList.Add(linearRing2);
				}
			}
			IGeometryFactory geometryFactory = igeometryFactory_0;
			ILinearRing[] holes = (LinearRing[])arrayList.ToArray(typeof(LinearRing));
			return geometryFactory.CreatePolygon(linearRing, holes);
		}
		return polygon;
	}

	private GInterface6 method_1(IGeometry igeometry_0, IGeometryEditorOperation igeometryEditorOperation_0)
	{
		GeometryCollection geometryCollection = (GeometryCollection)igeometryEditorOperation_0.Edit(igeometry_0, igeometryFactory_0);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < geometryCollection.NumGeometries; i++)
		{
			IGeometry geometry = Edit(geometryCollection.GetGeometryN(i), igeometryEditorOperation_0);
			if (!geometry.IsEmpty)
			{
				arrayList.Add(geometry);
			}
		}
		if (!(geometryCollection is MultiPoint))
		{
			if (!(geometryCollection is MultiLineString))
			{
				if (!(geometryCollection is MultiPolygon))
				{
					IGeometryFactory geometryFactory = igeometryFactory_0;
					IGeometry[] geometries = (Geometry[])arrayList.ToArray(typeof(Geometry));
					return geometryFactory.CreateGeometryCollection(geometries);
				}
				IGeometryFactory geometryFactory2 = igeometryFactory_0;
				IPolygon[] polygons = (Polygon[])arrayList.ToArray(typeof(Polygon));
				return geometryFactory2.CreateMultiPolygon(polygons);
			}
			IGeometryFactory geometryFactory3 = igeometryFactory_0;
			IBasicLineString[] lineStrings = (LineString[])arrayList.ToArray(typeof(LineString));
			return geometryFactory3.CreateMultiLineString(lineStrings);
		}
		return igeometryFactory_0.CreateMultiPoint((Point[])arrayList.ToArray(typeof(Point)));
	}

	static GeometryEditor()
	{
		Class72.smethod_20();
	}
}
