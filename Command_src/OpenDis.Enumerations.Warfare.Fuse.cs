using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Warfare;

[Serializable]
public enum Fuse : ushort
{
	[Description("Other.")]
	Other = 0,
	[Description("Intelligent Influence.")]
	IntelligentInfluence = 10,
	[Description("Sensor.")]
	Sensor = 20,
	[Description("Self-destruct.")]
	SelfDestruct = 30,
	[Description("Ultra Quick.")]
	UltraQuick = 40,
	[Description("Body.")]
	Body = 50,
	[Description("Deep Intrusion.")]
	DeepIntrusion = 60,
	[Description("Multifunction.")]
	Multifunction = 100,
	[Description("Point Detonation (PD).")]
	PointDetonationPD = 200,
	[Description("Base Detonation (BD).")]
	BaseDetonationBD = 300,
	[Description("Contact.")]
	Contact = 1000,
	[Description("Contact, Instant (Impact).")]
	ContactInstantImpact = 1100,
	[Description("Contact, Delayed.")]
	ContactDelayed = 1200,
	[Description("10 ms delay.")]
	_10MsDelay = 1201,
	[Description("20 ms delay.")]
	_20MsDelay = 1202,
	[Description("50 ms delay.")]
	_50MsDelay = 1205,
	[Description("60 ms delay.")]
	_60MsDelay = 1206,
	[Description("100 ms delay.")]
	_100MsDelay = 1210,
	[Description("125 ms delay.")]
	_125MsDelay = 1212,
	[Description("250 ms delay.")]
	_250MsDelay = 1225,
	[Description("Contact, Electronic (Oblique Contact).")]
	ContactElectronicObliqueContact = 1300,
	[Description("Contact, Graze.")]
	ContactGraze = 1400,
	[Description("Contact, Crush.")]
	ContactCrush = 1500,
	[Description("Contact, Hydrostatic.")]
	ContactHydrostatic = 1600,
	[Description("Contact, Mechanical.")]
	ContactMechanical = 1700,
	[Description("Contact, Chemical.")]
	ContactChemical = 1800,
	[Description("Contact, Piezoelectric.")]
	ContactPiezoelectric = 1900,
	[Description("Contact, Point Initiating.")]
	ContactPointInitiating = 1910,
	[Description("Contact, Point Initiating, Base Detonating.")]
	ContactPointInitiatingBaseDetonating = 1920,
	[Description("Contact, Base Detonating.")]
	ContactBaseDetonating = 1930,
	[Description("Contact, Ballistic Cap and Base.")]
	ContactBallisticCapAndBase = 1940,
	[Description("Contact, Base.")]
	ContactBase = 1950,
	[Description("Contact, Nose.")]
	ContactNose = 1960,
	[Description("Contact, Fitted in Standoff Probe.")]
	ContactFittedInStandoffProbe = 1970,
	[Description("Contact, Non-aligned.")]
	ContactNonAligned = 1980,
	[Description("Timed.")]
	Timed = 2000,
	[Description("Timed, Programmable.")]
	TimedProgrammable = 2100,
	[Description("Timed, Burnout.")]
	TimedBurnout = 2200,
	[Description("Timed, Pyrotechnic.")]
	TimedPyrotechnic = 2300,
	[Description("Timed, Electronic.")]
	TimedElectronic = 2400,
	[Description("Timed, Base Delay.")]
	TimedBaseDelay = 2500,
	[Description("Timed, Reinforced Nose Impact Delay.")]
	TimedReinforcedNoseImpactDelay = 2600,
	[Description("Timed, Short Delay Impact.")]
	TimedShortDelayImpact = 2700,
	[Description("10 ms delay.")]
	_10MsDelay_2701 = 2701,
	[Description("20 ms delay.")]
	_20MsDelay_2702 = 2702,
	[Description("50 ms delay.")]
	_50MsDelay_2705 = 2705,
	[Description("60 ms delay.")]
	_60MsDelay_2706 = 2706,
	[Description("100 ms delay.")]
	_100MsDelay_2710 = 2710,
	[Description("125 ms delay.")]
	_125MsDelay_2712 = 2712,
	[Description("250 ms delay.")]
	_250MsDelay_2725 = 2725,
	[Description("Timed, Nose Mounted Variable Delay.")]
	TimedNoseMountedVariableDelay = 2800,
	[Description("Timed, Long Delay Side.")]
	TimedLongDelaySide = 2900,
	[Description("Timed, Selectable Delay.")]
	TimedSelectableDelay = 2910,
	[Description("Timed, Impact.")]
	TimedImpact = 2920,
	[Description("Timed, Sequence.")]
	TimedSequence = 2930,
	[Description("Proximity.")]
	Proximity = 3000,
	[Description("Proximity, Active Laser.")]
	ProximityActiveLaser = 3100,
	[Description("Proximity, Magnetic (Magpolarity).")]
	ProximityMagneticMagpolarity = 3200,
	[Description("Proximity, Active Radar (Doppler Radar).")]
	ProximityActiveRadarDopplerRadar = 3300,
	[Description("Proximity, Radio Frequency (RF).")]
	ProximityRadioFrequencyRF = 3400,
	[Description("Proximity, Programmable.")]
	ProximityProgrammable = 3500,
	[Description("Proximity, Programmable, Prefragmented.")]
	ProximityProgrammablePrefragmented = 3600,
	[Description("Proximity, Infrared.")]
	ProximityInfrared = 3700,
	[Description("Command.")]
	Command = 4000,
	[Description("Command, Electronic, Remotely Set.")]
	CommandElectronicRemotelySet = 4100,
	[Description("Altitude.")]
	Altitude = 5000,
	[Description("Altitude, Radio Altimeter.")]
	AltitudeRadioAltimeter = 5100,
	[Description("Altitude, Air Burst.")]
	AltitudeAirBurst = 5200,
	[Description("Depth.")]
	Depth = 6000,
	[Description("Acoustic.")]
	Acoustic = 7000,
	[Description("Pressure.")]
	Pressure = 8000,
	[Description("Pressure, Delay.")]
	PressureDelay = 8010,
	[Description("Inert.")]
	Inert = 8100,
	[Description("Dummy.")]
	Dummy = 8110,
	[Description("Practice.")]
	Practice = 8120,
	[Description("Plug Representing.")]
	PlugRepresenting = 8130,
	[Description("Training.")]
	Training = 8150,
	[Description("Pyrotechnic.")]
	Pyrotechnic = 9000,
	[Description("Pyrotechnic, Delay.")]
	PyrotechnicDelay = 9010,
	[Description("Electro-optical.")]
	ElectroOptical = 9100,
	[Description("Electromechanical.")]
	Electromechanical = 9110,
	[Description("Electromechanical, Nose.")]
	ElectromechanicalNose = 9120,
	[Description("Strikerless.")]
	Strikerless = 9200,
	[Description("Strikerless, Nose Impact.")]
	StrikerlessNoseImpact = 9210,
	[Description("Strikerless, Compression-Ignition.")]
	StrikerlessCompressionIgnition = 9220,
	[Description("Compression-Ignition.")]
	CompressionIgnition = 9300,
	[Description("Compression-Ignition, Strikerless, Nose Impact.")]
	CompressionIgnitionStrikerlessNoseImpact = 9310,
	[Description("Percussion.")]
	Percussion = 9400,
	[Description("Percussion, Instantaneous.")]
	PercussionInstantaneous = 9410,
	[Description("Electronic.")]
	Electronic = 9500,
	[Description("Electronic, Internally Mounted.")]
	ElectronicInternallyMounted = 9510,
	[Description("Electronic, Range Setting.")]
	ElectronicRangeSetting = 9520,
	[Description("Electronic, Programmed.")]
	ElectronicProgrammed = 9530,
	[Description("Mechanical.")]
	Mechanical = 9600,
	[Description("Mechanical, Nose.")]
	MechanicalNose = 9610,
	[Description("Mechanical, Tail.")]
	MechanicalTail = 9620
}
