using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public enum ObjectKind : byte
{
	[Description("Other.")]
	Other,
	[Description("Obstacle.")]
	Obstacle,
	[Description("Prepared position.")]
	PreparedPosition,
	[Description("Cultural feature.")]
	CulturalFeature,
	[Description("Passageway.")]
	Passageway,
	[Description("Tactical smoke.")]
	TacticalSmoke,
	[Description("Obstacle marker.")]
	ObstacleMarker,
	[Description("Obstacle breach.")]
	ObstacleBreach
}
