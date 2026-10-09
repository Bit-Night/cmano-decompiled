using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum ElectronicsRepairCode : ushort
{
	[Description("electronic warfare systems.")]
	ElectronicWarfareSystems = 4500,
	[Description("detection systems.")]
	DetectionSystems = 4600,
	[Description("radio frequency.")]
	RadioFrequency = 4610,
	[Description("microwave.")]
	Microwave = 4620,
	[Description("infrared.")]
	Infrared = 4630,
	[Description("laser.")]
	Laser = 4640,
	[Description("range finders.")]
	RangeFinders = 4700,
	[Description("range-only radar.")]
	RangeOnlyRadar = 4710,
	[Description("laser range finder.")]
	LaserRangeFinder = 4720,
	[Description("electronic systems.")]
	ElectronicSystems = 4800,
	[Description("radio frequency.")]
	RadioFrequency_4810 = 4810,
	[Description("microwave.")]
	Microwave_4820 = 4820,
	[Description("infrared.")]
	Infrared_4830 = 4830,
	[Description("laser.")]
	Laser_4840 = 4840,
	[Description("radios.")]
	Radios = 5000,
	[Description("communication systems.")]
	CommunicationSystems = 5010,
	[Description("intercoms.")]
	Intercoms = 5100,
	[Description("encoders.")]
	Encoders = 5200,
	[Description("encryption devices.")]
	EncryptionDevices = 5250,
	[Description("decoders.")]
	Decoders = 5300,
	[Description("decryption devices.")]
	DecryptionDevices = 5350,
	[Description("computers.")]
	Computers = 5500,
	[Description("navigation and control systems.")]
	NavigationAndControlSystems = 6000,
	[Description("fire control systems.")]
	FireControlSystems = 6500
}
