using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Warfare;

[Serializable]
public enum DetonationResult : byte
{
	[Description("Other.")]
	Other,
	[Description("Entity Impact.")]
	EntityImpact,
	[Description("Entity Proximate Detonation.")]
	EntityProximateDetonation,
	[Description("Ground Impact.")]
	GroundImpact,
	[Description("Ground Proximate Detonation.")]
	GroundProximateDetonation,
	[Description("Detonation.")]
	Detonation,
	[Description("None or No Detonation (Dud).")]
	NoneOrNoDetonationDud,
	[Description("HE hit, small.")]
	const_7,
	[Description("HE hit, medium.")]
	const_8,
	[Description("HE hit, large.")]
	const_9,
	[Description("Armor-piercing hit.")]
	ArmorPiercingHit,
	[Description("Dirt blast, small.")]
	DirtBlastSmall,
	[Description("Dirt blast, medium.")]
	DirtBlastMedium,
	[Description("Dirt blast, large.")]
	DirtBlastLarge,
	[Description("Water blast, small.")]
	WaterBlastSmall,
	[Description("Water blast, medium.")]
	WaterBlastMedium,
	[Description("Water blast, large.")]
	WaterBlastLarge,
	[Description("Air hit.")]
	AirHit,
	[Description("Building hit, small.")]
	BuildingHitSmall,
	[Description("Building hit, medium.")]
	BuildingHitMedium,
	[Description("Building hit, large.")]
	BuildingHitLarge,
	[Description("Mine-clearing line charge.")]
	MineClearingLineCharge,
	[Description("Environment object impact.")]
	EnvironmentObjectImpact,
	[Description("Environment object proximate detonation.")]
	EnvironmentObjectProximateDetonation,
	[Description("Water Impact.")]
	WaterImpact,
	[Description("Air Burst.")]
	AirBurst,
	[Description("Kill with fragment type 1.")]
	KillWithFragmentType1,
	[Description("Kill with fragment type 2.")]
	KillWithFragmentType2,
	[Description("Kill with fragment type 3.")]
	KillWithFragmentType3,
	[Description("Kill with fragment type 1 after fly-out failure.")]
	KillWithFragmentType1AfterFlyOutFailure,
	[Description("Kill with fragment type 2 after fly-out failure.")]
	KillWithFragmentType2AfterFlyOutFailure,
	[Description("Miss due to fly-out failure.")]
	MissDueToFlyOutFailure,
	[Description("Miss due to end-game failure.")]
	MissDueToEndGameFailure,
	[Description("Miss due to fly-out and end-game failure.")]
	MissDueToFlyOutAndEndGameFailure
}
