using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface GInterface6 : IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	int Count { get; }

	IGeometry this[int i] { get; }

	bool IsHomogeneous { get; }

	IGeometry[] Geometries { get; set; }
}
