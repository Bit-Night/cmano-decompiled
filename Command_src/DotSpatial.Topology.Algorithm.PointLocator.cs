using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Algorithm;

public class PointLocator
{
	private bool bool_0;

	private int int_0;

	public virtual bool Intersects(Coordinate p, IGeometry geom)
	{
		return Locate(p, geom) != LocationType.Exterior;
	}

	public virtual LocationType Locate(Coordinate p, IGeometry geom)
	{
		if (!geom.IsEmpty)
		{
			if (geom is ILineString)
			{
				return smethod_0(p, (ILineString)geom);
			}
			if (!(geom is IPolygon))
			{
				bool_0 = false;
				int_0 = 0;
				method_0(p, geom);
				if (!GeometryGraph.IsInBoundary(int_0))
				{
					int result;
					if (int_0 > 0)
					{
						result = 0;
					}
					else
					{
						if (!bool_0)
						{
							return LocationType.Exterior;
						}
						result = 0;
					}
					return (LocationType)result;
				}
				return LocationType.Boundary;
			}
			return smethod_2(p, (IPolygon)geom);
		}
		return LocationType.Exterior;
	}

	private void method_0(Coordinate coordinate_0, IGeometry igeometry_0)
	{
		if (igeometry_0 is ILineString)
		{
			method_1(Locate(coordinate_0, igeometry_0));
		}
		else if (igeometry_0 is IPolygon)
		{
			method_1(Locate(coordinate_0, igeometry_0));
		}
		else if (igeometry_0 is IMultiLineString)
		{
			IGeometry[] geometries = ((IMultiLineString)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				ILineString geom = (ILineString)geometries[i];
				method_1(Locate(coordinate_0, geom));
			}
		}
		else if (igeometry_0 is IMultiPolygon)
		{
			IGeometry[] geometries = ((IMultiPolygon)igeometry_0).Geometries;
			for (int i = 0; i < geometries.Length; i++)
			{
				IPolygon geom2 = (IPolygon)geometries[i];
				method_1(Locate(coordinate_0, geom2));
			}
		}
		else
		{
			if (!(igeometry_0 is GInterface6))
			{
				return;
			}
			IEnumerator enumerator = new GeometryCollection.Enumerator((GInterface6)igeometry_0);
			while (enumerator.MoveNext())
			{
				IGeometry geometry = (IGeometry)enumerator.Current;
				if (geometry != igeometry_0)
				{
					method_0(coordinate_0, geometry);
				}
			}
		}
	}

	private void method_1(LocationType locationType_0)
	{
		if (locationType_0 == LocationType.Interior)
		{
			bool_0 = true;
		}
		if (locationType_0 == LocationType.Boundary)
		{
			int_0++;
		}
	}

	private static LocationType smethod_0(Coordinate coordinate_0, object object_0)
	{
		IList<Coordinate> coordinates = ((IBasicGeometry)object_0).Coordinates;
		if (!((ILineString)object_0).IsClosed && (coordinate_0.Equals(coordinates[0]) || coordinate_0.Equals(coordinates[coordinates.Count - 1])))
		{
			return LocationType.Boundary;
		}
		if (!CgAlgorithms.IsOnLine(coordinate_0, coordinates))
		{
			return LocationType.Exterior;
		}
		return LocationType.Interior;
	}

	private static LocationType smethod_1(Coordinate coordinate_0, IBasicGeometry ibasicGeometry_0)
	{
		if (!CgAlgorithms.IsOnLine(coordinate_0, ibasicGeometry_0.Coordinates))
		{
			if (CgAlgorithms.IsPointInRing(coordinate_0, ibasicGeometry_0.Coordinates))
			{
				return LocationType.Interior;
			}
			return LocationType.Exterior;
		}
		return LocationType.Boundary;
	}

	private static LocationType smethod_2(Coordinate coordinate_0, object object_0)
	{
		if (((IGeometry)object_0).IsEmpty)
		{
			return LocationType.Exterior;
		}
		LinearRing ibasicGeometry_ = (LinearRing)((IPolygon)object_0).Shell;
		switch (smethod_1(coordinate_0, ibasicGeometry_))
		{
		case LocationType.Exterior:
			return LocationType.Exterior;
		case LocationType.Boundary:
			return LocationType.Boundary;
		default:
		{
			ILinearRing[] holes = ((IPolygon)object_0).Holes;
			for (int i = 0; i < holes.Length; i++)
			{
				LinearRing ibasicGeometry_2 = (LinearRing)holes[i];
				switch (smethod_1(coordinate_0, ibasicGeometry_2))
				{
				case LocationType.Boundary:
					return LocationType.Boundary;
				case LocationType.Interior:
					return LocationType.Exterior;
				}
			}
			return LocationType.Interior;
		}
		}
	}

	static PointLocator()
	{
		Class72.smethod_20();
	}
}
