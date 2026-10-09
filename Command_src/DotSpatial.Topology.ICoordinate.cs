using System;
using System.ComponentModel;

namespace DotSpatial.Topology;

[TypeConverter(typeof(ExpandableObjectConverter))]
public interface ICoordinate : ICloneable, IComparable
{
	double M { get; set; }

	int NumOrdinates { get; }

	double this[int index] { get; set; }

	double[] Values { get; set; }

	double X { get; set; }

	double Y { get; set; }

	double Z { get; set; }

	new int GetHashCode();
}
