using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum SurfacePlatform : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Carrier.")]
	Carrier = 1,
	[Description("Command Ship/Cruiser.")]
	CommandShipCruiser = 2,
	[Description("Guided Missile Cruiser.")]
	GuidedMissileCruiser = 3,
	[Description("Guided Missile Destroyer (DDG).")]
	GuidedMissileDestroyerDDG = 4,
	[Description("Destroyer (DD).")]
	DestroyerDD = 5,
	[Description("Guided Missile Frigate (FFG).")]
	GuidedMissileFrigateFFG = 6,
	[Description("Light/Patrol Craft.")]
	LightPatrolCraft = 7,
	[Description("Mine Countermeasure Ship/Craft.")]
	MineCountermeasureShipCraft = 8,
	[Description("Dock Landing Ship.")]
	DockLandingShip = 9,
	[Description("Tank Landing Ship.")]
	TankLandingShip = 10,
	[Description("Landing Craft.")]
	LandingCraft = 11,
	[Description("Light Carrier.")]
	LightCarrier = 12,
	[Description("Cruiser/Helicopter Carrier.")]
	CruiserHelicopterCarrier = 13,
	[Description("Hydrofoil.")]
	Hydrofoil = 14,
	[Description("Air Cushion/Surface Effect.")]
	AirCushionSurfaceEffect = 15,
	[Description("Auxiliary.")]
	Auxiliary = 16,
	[Description("Auxiliary, Merchant Marine.")]
	AuxiliaryMerchantMarine = 17,
	[Description("Utility.")]
	Utility = 18,
	[Description("Frigate (including Corvette).")]
	FrigateIncludingCorvette = 50,
	[Description("Battleship.")]
	Battleship = 51,
	[Description("Heavy Cruiser.")]
	HeavyCruiser = 52,
	[Description("Destroyer Tender.")]
	DestroyerTender = 53,
	[Description("Amphibious Assault Ship.")]
	AmphibiousAssaultShip = 54,
	[Description("Amphibious Cargo Ship.")]
	AmphibiousCargoShip = 55,
	[Description("Amphibious Transport Dock.")]
	AmphibiousTransportDock = 56,
	[Description("Ammunition Ship.")]
	AmmunitionShip = 57,
	[Description("Combat Stores Ship.")]
	CombatStoresShip = 58,
	[Description("Surveillance Towed Array Sonar System (SURTASS).")]
	SurveillanceTowedArraySonarSystemSURTASS = 59,
	[Description("Fast Combat Support Ship.")]
	FastCombatSupportShip = 60,
	[Description("Non-Combatant Ship.")]
	NonCombatantShip = 61,
	[Description("Coast Guard Cutters.")]
	CoastGuardCutters = 62,
	[Description("Coast Guard Boats.")]
	CoastGuardBoats = 63
}
