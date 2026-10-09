using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum WeaponRepairCode : ushort
{
	[Description("gun elevation drive.")]
	GunElevationDrive = 2000,
	[Description("gun stabilization system.")]
	GunStabilizationSystem = 2010,
	[Description("gunner's primary sight (GPS).")]
	GunnerSPrimarySightGPS = 2020,
	[Description("commander's extension to the GPS.")]
	CommanderSExtensionToTheGPS = 2030,
	[Description("loading mechanism.")]
	LoadingMechanism = 2040,
	[Description("gunner's auxiliary sight.")]
	GunnerSAuxiliarySight = 2050,
	[Description("gunner's control panel.")]
	const_6 = 2060,
	[Description("gunner's control assembly handle(s).")]
	GunnerSControlAssemblyHandleS = 2070,
	[Description("commander's control handles/assembly.")]
	CommanderSControlHandlesAssembly = 2090,
	[Description("commander's weapon station.")]
	CommanderSWeaponStation = 2100,
	[Description("commander's independent thermal viewer (CITV).")]
	CommanderSIndependentThermalViewerCITV = 2110,
	[Description("general weapons.")]
	GeneralWeapons = 2120
}
