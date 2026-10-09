using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface IMultiPoint : GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	new IPoint this[int index] { get; set; }
}
