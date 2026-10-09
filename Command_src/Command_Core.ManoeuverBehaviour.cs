using System;

namespace Command_Core;

[Serializable]
public enum ManoeuverBehaviour
{
	HoldPosition,
	Careful,
	Normal,
	Aggressive,
	Routing
}
