namespace DotSpatial.Topology.Algorithm;

public class InteriorPointArea
{
	private readonly IGeometryFactory igeometryFactory_0;

	private Coordinate coordinate_0 = Coordinate.Empty;

	private double double_0;

	public virtual Coordinate InteriorPoint => coordinate_0;

	public InteriorPointArea(IGeometry g)
	{
		igeometryFactory_0 = g.Factory;
		Add(g);
	}

	private static double smethod_0(double double_1, double double_2)
	{
		return (double_1 + double_2) / 2.0;
	}

	private void Add(IGeometry geom)
	{
		if (geom is IPolygon)
		{
			AddPolygon(geom);
		}
		else if (geom is GInterface6)
		{
			IGeometry[] geometries = ((GInterface6)geom).Geometries;
			foreach (IGeometry geom2 in geometries)
			{
				Add(geom2);
			}
		}
	}

	public virtual void AddPolygon(IGeometry geometry)
	{
		IGeometry geometry2 = HorizontalBisector(geometry).Intersection(geometry);
		IGeometry geometry3 = WidestGeometry(geometry2);
		double width = geometry3.EnvelopeInternal.Width;
		if (coordinate_0.IsEmpty() || width > double_0)
		{
			coordinate_0 = Centre(geometry3.EnvelopeInternal);
			double_0 = width;
		}
	}

	protected virtual IGeometry WidestGeometry(IGeometry geometry)
	{
		if (!(geometry is GeometryCollection))
		{
			return geometry;
		}
		return smethod_1((GeometryCollection)geometry);
	}

	private static IGeometry smethod_1(object object_0)
	{
		if (!((IGeometry)object_0).IsEmpty)
		{
			IGeometry geometryN = ((IGeometry)object_0).GetGeometryN(0);
			for (int i = 1; i < ((IBasicGeometry)object_0).NumGeometries; i++)
			{
				if (((IGeometry)object_0).GetGeometryN(i).EnvelopeInternal.Width > geometryN.EnvelopeInternal.Width)
				{
					geometryN = ((IGeometry)object_0).GetGeometryN(i);
				}
			}
			return geometryN;
		}
		return (IGeometry)object_0;
	}

	protected virtual ILineString HorizontalBisector(IGeometry geometry)
	{
		IEnvelope envelopeInternal = geometry.EnvelopeInternal;
		double y = smethod_0(envelopeInternal.Minimum.Y, envelopeInternal.Maximum.Y);
		return igeometryFactory_0.CreateLineString(new Coordinate[2]
		{
			new Coordinate(envelopeInternal.Minimum.X, y),
			new Coordinate(envelopeInternal.Maximum.X, y)
		});
	}

	public virtual Coordinate Centre(IEnvelope envelope)
	{
		return new Coordinate(smethod_0(envelope.Minimum.X, envelope.Maximum.X), smethod_0(envelope.Minimum.Y, envelope.Maximum.Y));
	}

	static InteriorPointArea()
	{
		Class72.smethod_20();
	}
}
