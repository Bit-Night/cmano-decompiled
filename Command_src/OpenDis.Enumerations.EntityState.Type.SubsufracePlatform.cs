using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum SubsufracePlatform : byte
{
	[Description("Other.")]
	Other,
	[Description("SSBN (Nuclear Ballistic Missile).")]
	NuclearBallisticMissile,
	[Description("SSGN (Nuclear Guided Missile).")]
	NuclearGuidedMissile,
	[Description("SSN (Nuclear Attack - Torpedo).")]
	NuclearAttackTorpedo,
	[Description("SSG (Conventional Guided Missile).")]
	ConventionalGuidedMissile,
	[Description("SS (Conventional Attack - Torpedo, Patrol).")]
	ConventionalAttackTorpedoPatrol,
	[Description("SSAN (Nuclear Auxiliary).")]
	NuclearAuxiliary,
	[Description("SSA (Conventional Auxiliary).")]
	ConventionalAuxiliary
}
