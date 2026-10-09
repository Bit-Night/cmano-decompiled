using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface GInterface5 : ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable
{
	int Dimension { get; }

	Coordinate this[int index] { get; set; }

	int VersionID { get; }

	double GetOrdinate(int index, Ordinate ordinate);

	void SetOrdinate(int index, Ordinate ordinate, double value);

	Coordinate[] ToCoordinateArray();

	IEnvelope ExpandEnvelope(IEnvelope env);
}
