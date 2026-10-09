using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum SensorEmitterCategory : byte
{
	[Description("Other.")]
	Other,
	[Description("Multi-spectral.")]
	MultiSpectral,
	[Description("RF Active.")]
	RFActive,
	[Description("RF Passive (intercept and DF).")]
	RFPassiveInterceptAndDF,
	[Description("Optical (direct viewing with or without optics).")]
	OpticalDirectViewingWithOrWithoutOptics,
	[Description("Electro-Optical.")]
	ElectroOptical,
	[Description("Seismic.")]
	Seismic,
	[Description("Chemical, point detector.")]
	ChemicalPointDetector,
	[Description("Chemical, standoff.")]
	ChemicalStandoff,
	[Description("Thermal (temperature sensing).")]
	ThermalTemperatureSensing,
	[Description("Acoustic, Active.")]
	AcousticActive,
	[Description("Acoustic, Passive.")]
	AcousticPassive,
	[Description("Contact/Pressure (physical, hydrostatic, barometric).")]
	ContactPressurePhysicalHydrostaticBarometric,
	[Description("Electro-Magnetic Radiation (gamma radiation).")]
	ElectroMagneticRadiationGammaRadiation,
	[Description("Particle Radiation (Neutrons, alpha, beta particles).")]
	ParticleRadiationNeutronsAlphaBetaParticles,
	[Description("Magnetic.")]
	Magnetic,
	[Description("Gravitational.")]
	Gravitational
}
