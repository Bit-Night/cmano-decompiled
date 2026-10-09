using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface IMultiLineString : GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	new ILineString this[int index] { get; }
}
