using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum DriveTrainRepairCode : ushort
{
	[Description("motor / engine.")]
	MotorEngine = 10,
	[Description("starter.")]
	Starter = 20,
	[Description("alternator.")]
	Alternator = 30,
	[Description("generator.")]
	Generator = 40,
	[Description("battery.")]
	Battery = 50,
	[Description("engine-coolant leak.")]
	EngineCoolantLeak = 60,
	[Description("fuel filter.")]
	FuelFilter = 70,
	[Description("transmission-oil leak.")]
	TransmissionOilLeak = 80,
	[Description("engine-oil leak.")]
	EngineOilLeak = 90,
	[Description("pumps.")]
	Pumps = 100,
	[Description("filters.")]
	Filters = 110,
	[Description("transmission.")]
	Transmission = 120,
	[Description("brakes.")]
	Brakes = 130,
	[Description("suspension system.")]
	SuspensionSystem = 140,
	[Description("oil filter.")]
	OilFilter = 150
}
