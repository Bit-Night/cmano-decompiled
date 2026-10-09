using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum HydraulicSystemsAndActuators : ushort
{
	[Description("water supply.")]
	WaterSupply = 9000,
	[Description("cooling system.")]
	CoolingSystem = 9010,
	[Description("winches.")]
	Winches = 9020,
	[Description("catapults.")]
	Catapults = 9030,
	[Description("cranes.")]
	Cranes = 9040,
	[Description("launchers.")]
	Launchers = 9050
}
