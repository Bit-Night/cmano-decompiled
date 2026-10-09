using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum RadioCategory : byte
{
	[Description("Other.")]
	Other,
	[Description("Voice Transmission/Reception.")]
	VoiceTransmissionReception,
	[Description("Data Link Transmission/Reception.")]
	DataLinkTransmissionReception,
	[Description("Voice and Data Link Transmission/Reception.")]
	VoiceAndDataLinkTransmissionReception,
	[Description("Instrumented Landing System (ILS) Glideslope Transmitter.")]
	InstrumentedLandingSystemILSGlideslopeTransmitter,
	[Description("Instrumented Landing System (ILS) Localizer Transmitter.")]
	InstrumentedLandingSystemILSLocalizerTransmitter,
	[Description("Instrumented Landing System (ILS) Outer Marker Beacon.")]
	InstrumentedLandingSystemILSOuterMarkerBeacon,
	[Description("Instrumented Landing System (ILS) Middle Marker Beacon.")]
	InstrumentedLandingSystemILSMiddleMarkerBeacon,
	[Description("Instrumented Landing System (ILS) Inner Marker Beacon.")]
	InstrumentedLandingSystemILSInnerMarkerBeacon,
	[Description("Instrumented Landing System (ILS) Receiver (Platform Radio).")]
	InstrumentedLandingSystemILSReceiverPlatformRadio,
	[Description("Tactical Air Navigation (TACAN) Transmitter (Ground Fixed Equipment).")]
	TacticalAirNavigationTACANTransmitterGroundFixedEquipment,
	[Description("Tactical Air Navigation (TACAN) Receiver (Moving Platform Equipment).")]
	TacticalAirNavigationTACANReceiverMovingPlatformEquipment,
	[Description("Tactical Air Navigation (TACAN) Transmitter/Receiver (Moving Platform Equipment).")]
	TacticalAirNavigationTACANTransmitterReceiverMovingPlatformEquipment,
	[Description("Variable Omni-Ranging (VOR) Transmitter (Ground Fixed Equipment).")]
	VariableOmniRangingVORTransmitterGroundFixedEquipment,
	[Description("Variable Omni-Ranging (VOR) with Distance Measuring Equipment (DME) Transmitter (Ground Fixed Equipment).")]
	VariableOmniRangingVORWithDistanceMeasuringEquipmentDMETransmitterGroundFixedEquipment,
	[Description("Combined VOR/ILS Receiver (Moving Platform Equipment).")]
	CombinedVORILSReceiverMovingPlatformEquipment,
	[Description("Combined VOR &amp; TACAN (VORTAC) Transmitter.")]
	CombinedVORTACANVORTACTransmitter,
	[Description("Non-Directional Beacon (NDB) Transmitter.")]
	NonDirectionalBeaconNDBTransmitter,
	[Description("Non-Directional Beacon (NDB) Receiver.")]
	NonDirectionalBeaconNDBReceiver,
	[Description("Non-Directional Beacon (NDB) with Distance Measuring Equipment (DME) Transmitter.")]
	NonDirectionalBeaconNDBWithDistanceMeasuringEquipmentDMETransmitter,
	[Description("Distance Measuring Equipment (DME).")]
	DistanceMeasuringEquipmentDME
}
