using System;
using System.ComponentModel;

namespace DotSpatial.Topology;

[TypeConverter(typeof(ExpandableObjectConverter))]
public interface IEnvelope : ICloneable, IRectangle
{
	Coordinate Minimum { get; }

	Coordinate Maximum { get; }

	int NumOrdinates { get; }

	bool IsNull { get; }

	event EventHandler EnvelopeChanged;

	IEnvelope Copy();

	void SetToNull();

	bool HasM();

	bool HasZ();

	void Init(Coordinate p1, Coordinate p2);
}
