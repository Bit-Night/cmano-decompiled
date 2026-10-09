using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Simplify;

public class DouglasPeuckerSimplifier
{
	private class Class49 : GeometryTransformer
	{
		private readonly DouglasPeuckerSimplifier douglasPeuckerSimplifier_0;

		public Class49(DouglasPeuckerSimplifier douglasPeuckerSimplifier_1)
		{
			douglasPeuckerSimplifier_0 = douglasPeuckerSimplifier_1;
		}

		protected override IList<Coordinate> TransformCoordinates(IList<Coordinate> coords, IGeometry parent)
		{
			return DouglasPeuckerLineSimplifier.Simplify(coords, douglasPeuckerSimplifier_0.DistanceTolerance);
		}

		protected override IGeometry TransformPolygon(IPolygon geom, IGeometry parent)
		{
			IGeometry geometry = base.TransformPolygon(geom, parent);
			if (parent is MultiPolygon)
			{
				return geometry;
			}
			return smethod_0(geometry);
		}

		protected override IGeometry TransformMultiPolygon(IMultiPolygon geom)
		{
			return smethod_0(base.TransformMultiPolygon(geom));
		}

		private static IGeometry smethod_0(IGeometry igeometry_1)
		{
			return igeometry_1.Buffer(0.0);
		}

		static Class49()
		{
			Class72.smethod_20();
		}
	}

	private readonly Geometry geometry_0;

	private double double_0;

	public virtual double DistanceTolerance
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public DouglasPeuckerSimplifier(Geometry inputGeom)
	{
		geometry_0 = inputGeom;
	}

	public static IGeometry Simplify(Geometry geom, double distanceTolerance)
	{
		return new DouglasPeuckerSimplifier(geom)
		{
			DistanceTolerance = distanceTolerance
		}.GetResultGeometry();
	}

	public virtual IGeometry GetResultGeometry()
	{
		return new Class49(this).Transform(geometry_0);
	}

	static DouglasPeuckerSimplifier()
	{
		Class72.smethod_20();
	}
}
