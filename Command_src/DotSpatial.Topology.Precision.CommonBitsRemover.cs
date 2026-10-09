namespace DotSpatial.Topology.Precision;

public class CommonBitsRemover
{
	public class CommonCoordinateFilter : ICoordinateFilter
	{
		private readonly CommonBits commonBits_0 = new CommonBits();

		private readonly CommonBits commonBits_1 = new CommonBits();

		public virtual Coordinate CommonCoordinate => new Coordinate(commonBits_0.Common, commonBits_1.Common);

		public virtual void Filter(Coordinate coord)
		{
			commonBits_0.Add(coord.X);
			commonBits_1.Add(coord.Y);
		}

		static CommonCoordinateFilter()
		{
			Class72.smethod_20();
		}
	}

	private class Class52 : ICoordinateFilter
	{
		private readonly Coordinate coordinate_0;

		public Class52(Coordinate coordinate_1)
		{
			coordinate_0 = coordinate_1;
		}

		public void Filter(Coordinate coord)
		{
			coord.X += coordinate_0.X;
			coord.Y += coordinate_0.Y;
		}

		static Class52()
		{
			Class72.smethod_20();
		}
	}

	private readonly CommonCoordinateFilter commonCoordinateFilter_0 = new CommonCoordinateFilter();

	private Coordinate coordinate_0;

	public virtual Coordinate CommonCoordinate => coordinate_0;

	public virtual void Add(IGeometry geom)
	{
		geom.Apply(commonCoordinateFilter_0);
		coordinate_0 = commonCoordinateFilter_0.CommonCoordinate;
	}

	public virtual Geometry RemoveCommonBits(Geometry geom)
	{
		if (coordinate_0.X == 0.0 && coordinate_0.Y == 0.0)
		{
			return geom;
		}
		Coordinate coordinate = new Coordinate(coordinate_0);
		coordinate.X = 0.0 - coordinate.X;
		coordinate.Y = 0.0 - coordinate.Y;
		Class52 filter = new Class52(coordinate);
		geom.Apply(filter);
		geom.GeometryChanged();
		return geom;
	}

	public virtual void AddCommonBits(IGeometry geom)
	{
		Class52 filter = new Class52(coordinate_0);
		geom.Apply(filter);
		geom.GeometryChanged();
	}

	static CommonBitsRemover()
	{
		Class72.smethod_20();
	}
}
