using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

[Serializable]
public class LinearRing : LineString, ILinearRing, ILineString, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicLineString
{
	public override string GeometryType => "LinearRing";

	public override bool IsClosed
	{
		get
		{
			if (IsEmpty)
			{
				return true;
			}
			return base.IsClosed;
		}
	}

	public override FeatureType FeatureType => FeatureType.Line;

	public LinearRing(IEnumerable<Coordinate> coordinates)
		: base(coordinates)
	{
		method_1();
	}

	public LinearRing(IEnumerable<ICoordinate> coordinates)
		: base(coordinates)
	{
		method_1();
	}

	public LinearRing(IBasicLineString linestringbase)
		: base(linestringbase)
	{
	}

	private void method_1()
	{
		if (!IsEmpty && !IsClosed)
		{
			Coordinates.Add(CloneableEM.Copy(Coordinates[0]));
		}
		if (Coordinates.Count >= 1 && Coordinates.Count < 3)
		{
			throw new ArgumentException("Number of points must be 0 or >= 3");
		}
	}

	static LinearRing()
	{
		Class72.smethod_20();
	}
}
