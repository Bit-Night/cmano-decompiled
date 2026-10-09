using System.Collections.Generic;

namespace DotSpatial.Topology.Operation.Predicate;

public class RectangleContains
{
	private readonly IEnvelope ienvelope_0;

	public RectangleContains(Polygon rectangle)
	{
		ienvelope_0 = rectangle.EnvelopeInternal;
	}

	public static bool Contains(Polygon rectangle, IGeometry b)
	{
		return new RectangleContains(rectangle).Contains(b);
	}

	public bool Contains(IGeometry geom)
	{
		if (!ienvelope_0.Contains(geom.EnvelopeInternal))
		{
			return false;
		}
		if (method_0(geom))
		{
			return false;
		}
		return true;
	}

	private bool method_0(IGeometry igeometry_0)
	{
		if (!(igeometry_0 is IPolygon) && !(igeometry_0 is IMultiPolygon))
		{
			if (!(igeometry_0 is IPoint))
			{
				if (igeometry_0 is ILineString)
				{
					return method_2(igeometry_0);
				}
				int num = 0;
				while (true)
				{
					if (num < igeometry_0.NumGeometries)
					{
						IGeometry geometryN = ((Geometry)igeometry_0).GetGeometryN(num);
						if (!method_0(geometryN))
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
			return method_1(igeometry_0.Coordinate);
		}
		return false;
	}

	private bool method_1(Coordinate coordinate_0)
	{
		if (coordinate_0.X != ienvelope_0.Minimum.X && coordinate_0.X != ienvelope_0.Maximum.X)
		{
			return false;
		}
		if (coordinate_0.Y != ienvelope_0.Minimum.Y && coordinate_0.Y != ienvelope_0.Maximum.Y)
		{
			return false;
		}
		return true;
	}

	private bool method_2(IBasicGeometry ibasicGeometry_0)
	{
		IList<Coordinate> coordinates = ibasicGeometry_0.Coordinates;
		int num = 0;
		while (true)
		{
			if (num < coordinates.Count - 1)
			{
				if (!method_3(coordinates[num], coordinates[num + 1]))
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

	private bool method_3(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (!coordinate_0.Equals(coordinate_1))
		{
			if (coordinate_0.X == coordinate_1.X)
			{
				int result;
				if (coordinate_0.X != ienvelope_0.Minimum.X)
				{
					if (coordinate_0.X != ienvelope_0.Maximum.X)
					{
						goto IL_0092;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			if (coordinate_0.Y == coordinate_1.Y)
			{
				int result2;
				if (coordinate_0.Y != ienvelope_0.Minimum.Y)
				{
					if (coordinate_0.Y != ienvelope_0.Maximum.Y)
					{
						goto IL_0092;
					}
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			goto IL_0092;
		}
		return method_1(coordinate_0);
		IL_0092:
		return false;
	}

	static RectangleContains()
	{
		Class72.smethod_20();
	}
}
