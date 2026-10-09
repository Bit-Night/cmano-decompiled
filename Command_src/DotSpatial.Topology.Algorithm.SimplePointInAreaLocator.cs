using System.Collections;

namespace DotSpatial.Topology.Algorithm;

public class SimplePointInAreaLocator
{
	private SimplePointInAreaLocator()
	{
	}

	public static LocationType Locate(Coordinate p, IGeometry geom)
	{
		if (!geom.IsEmpty)
		{
			if (smethod_0(p, geom))
			{
				return LocationType.Interior;
			}
			return LocationType.Exterior;
		}
		return LocationType.Exterior;
	}

	private static bool smethod_0(Coordinate coordinate_0, object object_0)
	{
		if (object_0 is Polygon)
		{
			return ContainsPointInPolygon(coordinate_0, (Polygon)object_0);
		}
		int result;
		if (!(object_0 is GeometryCollection))
		{
			result = 0;
		}
		else
		{
			IEnumerator enumerator = new GeometryCollection.Enumerator((GeometryCollection)object_0);
			while (enumerator.MoveNext())
			{
				Geometry geometry = (Geometry)enumerator.Current;
				if (geometry != object_0 && smethod_0(coordinate_0, geometry))
				{
					return true;
				}
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool ContainsPointInPolygon(Coordinate p, IPolygon poly)
	{
		if (poly.IsEmpty)
		{
			return false;
		}
		LinearRing linearRing = (LinearRing)poly.Shell;
		if (CgAlgorithms.IsPointInRing(p, linearRing.Coordinates))
		{
			int num = 0;
			while (true)
			{
				if (num < poly.NumHoles)
				{
					LinearRing linearRing2 = (LinearRing)poly.GetInteriorRingN(num);
					if (CgAlgorithms.IsPointInRing(p, linearRing2.Coordinates))
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

	static SimplePointInAreaLocator()
	{
		Class72.smethod_20();
	}
}
