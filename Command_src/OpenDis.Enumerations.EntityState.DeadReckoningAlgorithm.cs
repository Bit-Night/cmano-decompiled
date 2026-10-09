using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState;

[Serializable]
public enum DeadReckoningAlgorithm : byte
{
	[Description("Other.")]
	Other,
	[Description("Static (Entity does not move.).")]
	Static,
	[Description("DRM(F, P, W).")]
	DRA_F_P_W,
	[Description("DRM(R, P, W).")]
	DRA_R_P_W,
	[Description("DRM(R, V, W).")]
	DRA_R_V_W,
	[Description("DRM(F, V, W).")]
	DRA_F_W_V,
	[Description("DRM(F, P, B).")]
	DRA_F_P_B,
	[Description("DRM(R, P, B).")]
	DRA_R_P_B,
	[Description("DRM(R, V, B).")]
	DRA_R_V_B,
	[Description("DRM(F, V, B).")]
	DRA_F_V_B
}
