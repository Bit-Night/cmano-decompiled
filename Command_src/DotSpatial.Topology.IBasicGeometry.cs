using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface IBasicGeometry : ICloneable
{
	IList<Coordinate> Coordinates { get; set; }

	IEnvelope Envelope { get; }

	int NumGeometries { get; }

	int NumPoints { get; }

	string GeometryType { get; }

	FeatureType FeatureType { get; }

	IBasicGeometry GetBasicGeometryN(int index);

	string ExportToGml();

	byte[] ToBinary();

	new string ToString();

	void UpdateEnvelope();
}
