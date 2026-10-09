using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum LifeSupportRepairCode : ushort
{
	[Description("air supply.")]
	AirSupply = 8000,
	[Description("filters.")]
	Filters = 8010,
	[Description("water supply.")]
	WaterSupply = 8020,
	[Description("refrigeration system.")]
	RefrigerationSystem = 8030,
	[Description("chemical, biological, and radiological protection.")]
	ChemicalBiologicalAndRadiologicalProtection = 8040,
	[Description("water wash down systems.")]
	WaterWashDownSystems = 8050,
	[Description("decontamination systems.")]
	DecontaminationSystems = 8060
}
