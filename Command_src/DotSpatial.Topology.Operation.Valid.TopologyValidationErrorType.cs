using System;

namespace DotSpatial.Topology.Operation.Valid;

public enum TopologyValidationErrorType
{
	[Obsolete("Not used")]
	Error,
	[Obsolete("No longer used: repeated points are considered valid as per the SFS")]
	RepeatedPoint,
	HoleOutsideShell,
	NestedHoles,
	DisconnectedInteriors,
	SelfIntersection,
	RingSelfIntersection,
	NestedShells,
	DuplicateRings,
	TooFewPoints,
	InvalidCoordinate,
	RingNotClosed
}
