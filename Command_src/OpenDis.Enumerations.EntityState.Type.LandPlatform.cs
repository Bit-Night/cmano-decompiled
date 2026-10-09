using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum LandPlatform : byte
{
	[Description("Other.")]
	Other,
	[Description("Tank.")]
	Tank,
	[Description("Armored Fighting Vehicle - (IFV, APC, SP mortars, armored cars, chemical reconnaissance, anti-tank guided missile launchers, etc.).")]
	ArmoredFightingVehicle,
	[Description("Armored Utility Vehicle - (Engineering vehicle, tracked load carriers, towing vehicles, recovery vehicles, AVLB, etc.).")]
	ArmoredUtilityVehicle,
	[Description("Self-propelled Artillery - (guns and howitzers).")]
	SelfPropelledArtillery,
	[Description("Towed Artillery - (anti-tank guns, guns and howitzers).")]
	TowedArtillery,
	[Description("Small Wheeled Utility Vehicle - (0-1.25 tons).")]
	SmallWheeledUtilityVehicle,
	[Description("Large Wheeled Utility Vehicle - (greater than 1.25 tons).")]
	LargeWheeledUtilityVehicle,
	[Description("Small Tracked Utility Vehicle - (0-4999 kg weight load).")]
	SmallTrackedUtilityVehicle,
	[Description("Large Tracked Utility Vehicle - (greater than 4999 kg weight load).")]
	LargeTrackedUtilityVehicle,
	[Description("Mortar.")]
	Mortar,
	[Description("Mine plow.")]
	MinePlow,
	[Description("Mine rake.")]
	MineRake,
	[Description("Mine roller.")]
	MineRoller,
	[Description("Cargo trailer.")]
	CargoTrailer,
	[Description("Fuel trailer.")]
	FuelTrailer,
	[Description("Generator trailer.")]
	GeneratorTrailer,
	[Description("Water trailer.")]
	WaterTrailer,
	[Description("Engineer equipment.")]
	EngineerEquipment,
	[Description("Heavy equipment transport trailer.")]
	HeavyEquipmentTransportTrailer,
	[Description("Maintenance equipment trailer.")]
	MaintenanceEquipmentTrailer,
	[Description("Limber.")]
	Limber,
	[Description("Chemical decontamination trailer.")]
	ChemicalDecontaminationTrailer,
	[Description("Warning System.")]
	WarningSystem,
	[Description("Train - Engine.")]
	TrainEngine,
	[Description("Train - Car.")]
	TrainCar,
	[Description("Train - Caboose.")]
	TrainCaboose,
	[Description("Civilian Vehicle.")]
	CivilianVehicle,
	[Description("Air Defense / Missile Defense Unit Equipment.")]
	AirDefenseMissileDefenseUnitEquipment,
	[Description("Command, Control, Communications, and Intelligence (C3I) System.")]
	CommandControlCommunicationsAndIntelligenceC3ISystem,
	[Description("Operations Facility.")]
	OperationsFacility,
	[Description("Intelligence Facility.")]
	IntelligenceFacility,
	[Description("Surveillance Facility.")]
	SurveillanceFacility,
	[Description("Communications Facility.")]
	CommunicationsFacility,
	[Description("Command Facility.")]
	CommandFacility,
	[Description("C4I Facility.")]
	const_35,
	[Description("Control Facility.")]
	ControlFacility,
	[Description("Fire Control Facility.")]
	FireControlFacility,
	[Description("Missile Defense Facility.")]
	MissileDefenseFacility,
	[Description("Field Command Post.")]
	FieldCommandPost,
	[Description("Observation Post.")]
	ObservationPost
}
