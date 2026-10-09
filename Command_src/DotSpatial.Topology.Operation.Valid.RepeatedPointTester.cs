using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Operation.Valid;

public class RepeatedPointTester
{
	private Coordinate coordinate_0;

	public virtual Coordinate Coordinate => coordinate_0;

	protected virtual bool HasRepeatedPoint(IGeometry g)
	{
		if (!g.IsEmpty)
		{
			if (g is Point)
			{
				return false;
			}
			if (g is MultiPoint)
			{
				return false;
			}
			if (!(g is LineString))
			{
				if (!(g is Polygon))
				{
					if (g is GeometryCollection)
					{
						return method_1((GInterface6)g);
					}
					throw new NotSupportedException(g.GetType().FullName);
				}
				return method_0((IPolygon)g);
			}
			return HasRepeatedPoint(g.Coordinates);
		}
		return false;
	}

	public virtual bool HasRepeatedPoint(IList<Coordinate> coord)
	{
		for (int i = 1; i < coord.Count; i++)
		{
			if (coord[i - 1].Equals(coord[i]))
			{
				coordinate_0 = coord[i];
				return true;
			}
		}
		return false;
	}

	private bool method_0(IPolygon ipolygon_0)
	{
		if (HasRepeatedPoint(ipolygon_0.Shell.Coordinates))
		{
			return true;
		}
		for (int i = 0; i < ipolygon_0.NumHoles; i++)
		{
			if (HasRepeatedPoint(ipolygon_0.GetInteriorRingN(i).Coordinates))
			{
				return true;
			}
		}
		return false;
	}

	private bool method_1(GInterface6 ginterface6_0)
	{
		for (int i = 0; i < ginterface6_0.NumGeometries; i++)
		{
			IGeometry geometryN = ginterface6_0.GetGeometryN(i);
			if (HasRepeatedPoint(geometryN))
			{
				return true;
			}
		}
		return false;
	}

	static RepeatedPointTester()
	{
		Class72.smethod_20();
	}
}
