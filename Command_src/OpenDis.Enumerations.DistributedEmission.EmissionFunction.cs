using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum EmissionFunction : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Multi-function.")]
	MultiFunction = 1,
	[Description("Early Warning/Surveillance.")]
	EarlyWarningSurveillance = 2,
	[Description("Height Finding.")]
	HeightFinding = 3,
	[Description("Fire Control.")]
	FireControl = 4,
	[Description("Acquisition/Detection.")]
	AcquisitionDetection = 5,
	[Description("Tracking.")]
	Tracking = 6,
	[Description("Guidance/Illumination.")]
	GuidanceIllumination = 7,
	[Description("Firing point/launch point location.")]
	FiringPointLaunchPointLocation = 8,
	[Description("Ranging.")]
	Ranging = 9,
	[Description("Radar Altimeter.")]
	RadarAltimeter = 10,
	[Description("Imaging.")]
	Imaging = 11,
	[Description("Motion Detection.")]
	MotionDetection = 12,
	[Description("Navigation.")]
	Navigation = 13,
	[Description("Weather / Meterological.")]
	WeatherMeterological = 14,
	[Description("Instrumentation.")]
	Instrumentation = 15,
	[Description("Identification/Classification (including IFF).")]
	IdentificationClassificationIncludingIFF = 16,
	[Description("AAA (Anti-Aircraft Artillery) Fire Control.")]
	AAAAntiAircraftArtilleryFireControl = 17,
	[Description("Air Search/Bomb.")]
	AirSearchBomb = 18,
	[Description("Air Intercept.")]
	AirIntercept = 19,
	[Description("Altimeter.")]
	Altimeter = 20,
	[Description("Air Mapping.")]
	AirMapping = 21,
	[Description("Air Traffic Control.")]
	AirTrafficControl = 22,
	[Description("Beacon.")]
	Beacon = 23,
	[Description("Battlefield Surveillance.")]
	BattlefieldSurveillance = 24,
	[Description("Ground Control Approach.")]
	GroundControlApproach = 25,
	[Description("Ground Control Intercept.")]
	GroundControlIntercept = 26,
	[Description("Coastal Surveillance.")]
	CoastalSurveillance = 27,
	[Description("Decoy/Mimic.")]
	DecoyMimic = 28,
	[Description("Data Transmission.")]
	DataTransmission = 29,
	[Description("Earth Surveillance.")]
	EarthSurveillance = 30,
	[Description("Gun Lay Beacon.")]
	GunLayBeacon = 31,
	[Description("Ground Mapping.")]
	GroundMapping = 32,
	[Description("Harbor Surveillance.")]
	HarborSurveillance = 33,
	[Description("ILS (Instrument Landing System).")]
	ILSInstrumentLandingSystem = 35,
	[Description("Ionospheric Sound.")]
	IonosphericSound = 36,
	[Description("Interrogator.")]
	Interrogator = 37,
	[Description("Barrage Jamming.")]
	BarrageJamming = 38,
	[Description("Click Jamming.")]
	ClickJamming = 39,
	[Description("Frequency Swept Jamming.")]
	FrequencySweptJamming = 41,
	[Description("Jamming.")]
	Jamming = 42,
	[Description("Pulsed Jamming.")]
	PulsedJamming = 44,
	[Description("Repeater Jamming.")]
	RepeaterJamming = 45,
	[Description("Spot Noise Jamming.")]
	SpotNoiseJamming = 46,
	[Description("Missile Acquisition.")]
	MissileAcquisition = 47,
	[Description("Missile Downlink.")]
	MissileDownlink = 48,
	[Description("Space.")]
	Space = 50,
	[Description("Surface Search.")]
	SurfaceSearch = 51,
	[Description("Shell Tracking.")]
	ShellTracking = 52,
	[Description("Television.")]
	Television = 56,
	[Description("Unknown.")]
	Unknown = 57,
	[Description("Video Remoting.")]
	VideoRemoting = 58,
	[Description("Experimental or Training.")]
	ExperimentalOrTraining = 59,
	[Description("Missile Guidance.")]
	MissileGuidance = 60,
	[Description("Missile Homing.")]
	MissileHoming = 61,
	[Description("Missile Tracking.")]
	MissileTracking = 62,
	[Description("Jamming, noise.")]
	JammingNoise = 64,
	[Description("Jamming, deception.")]
	JammingDeception = 65,
	[Description("Navigation/Distance Measuring Equipment.")]
	NavigationDistanceMeasuringEquipment = 71,
	[Description("Terrain Following.")]
	TerrainFollowing = 72,
	[Description("Weather Avoidance.")]
	WeatherAvoidance = 73,
	[Description("Proximity Fuse.")]
	ProximityFuse = 74,
	[Description("Radiosonde.")]
	Radiosonde = 76,
	[Description("Sonobuoy.")]
	Sonobuoy = 77,
	[Description("Bathythermal Sensor.")]
	BathythermalSensor = 78,
	[Description("Towed Counter Measure.")]
	TowedCounterMeasure = 79,
	[Description("Weapon, non-lethal.")]
	WeaponNonLethal = 96,
	[Description("Weapon, lethal.")]
	WeaponLethal = 97
}
