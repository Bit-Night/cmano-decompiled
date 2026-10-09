using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum TDLType : ushort
{
	[Description("Other.")]
	Other = 0,
	[Description("PADIL.")]
	PADIL = 1,
	[Description("NATO Link-1.")]
	const_2 = 2,
	[Description("ATDL-1.")]
	ATDL1 = 3,
	[Description("Link 11B (TADIL B).")]
	Link11BTADILB = 4,
	[Description("Situational Awareness Data Link (SADL).")]
	SituationalAwarenessDataLinkSADL = 5,
	[Description("Link 16 Legacy Format (JTIDS/TADIL-J).")]
	Link16LegacyFormatJTIDSTADILJ = 6,
	[Description("Link 16 Legacy Format (JTIDS/FDL/TADIL-J).")]
	Link16LegacyFormatJTIDSFDLTADILJ = 7,
	[Description("Link 11A (TADIL A).")]
	Link11ATADILA = 8,
	[Description("IJMS.")]
	IJMS = 9,
	[Description("Link 4A (TADIL C).")]
	Link4ATADILC = 10,
	[Description("Link 4C.")]
	Link4C = 11,
	[Description("TIBS.")]
	TIBS = 12,
	[Description("ATL.")]
	ATL = 13,
	[Description("Constant Source.")]
	ConstantSource = 14,
	[Description("Abbreviated Command and Control.")]
	AbbreviatedCommandAndControl = 15,
	[Description("MILSTAR.")]
	MILSTAR = 16,
	[Description("ATHS.")]
	ATHS = 17,
	[Description("OTHGOLD.")]
	OTHGOLD = 18,
	[Description("TACELINT.")]
	TACELINT = 19,
	[Description("Weapons Data Link (AWW-13).")]
	const_20 = 20,
	[Description("Abbreviated Command and Control.")]
	AbbreviatedCommandAndControl_21 = 21,
	[Description("Enhanced Position Location Reporting System (EPLRS).")]
	EnhancedPositionLocationReportingSystemEPLRS = 22,
	[Description("Position Location Reporting System (PLRS).")]
	PositionLocationReportingSystemPLRS = 23,
	[Description("SINCGARS.")]
	SINCGARS = 24,
	[Description("Have Quick I.")]
	HaveQuickI = 25,
	[Description("Have Quick II.")]
	HaveQuickII = 26,
	[Description("Have Quick IIA (Saturn).")]
	const_27 = 27,
	[Description("Intra-Flight Data Link 1.")]
	IntraFlightDataLink1 = 28,
	[Description("Intra-Flight Data Link 2.")]
	IntraFlightDataLink2 = 29,
	[Description("Improved Data Modem (IDM).")]
	const_30 = 30,
	[Description("Air Force Application Program Development (AFAPD).")]
	AirForceApplicationProgramDevelopmentAFAPD = 31,
	[Description("Cooperative Engagement Capability (CEC).")]
	CooperativeEngagementCapabilityCEC = 32,
	[Description("Forward Area Air Defense (FAAD) Data Link (FDL).")]
	ForwardAreaAirDefenseFAADDataLinkFDL = 33,
	[Description("Ground Based Data Link (GBDL).")]
	GroundBasedDataLinkGBDL = 34,
	[Description("Intra Vehicular Info System (IVIS).")]
	IntraVehicularInfoSystemIVIS = 35,
	[Description("Marine Tactical System (MTS).")]
	MarineTacticalSystemMTS = 36,
	[Description("Tactical Fire Direction System (TACFIRE).")]
	TacticalFireDirectionSystemTACFIRE = 37,
	[Description("Integrated Broadcast Service (IBS).")]
	IntegratedBroadcastServiceIBS = 38,
	[Description("Airborne Information Transfer (ABIT).")]
	AirborneInformationTransferABIT = 39,
	[Description("Advanced Tactical Airborne Reconnaissance System (ATARS) Data Link.")]
	AdvancedTacticalAirborneReconnaissanceSystemATARSDataLink = 40,
	[Description("Battle Group Passive Horizon Extension System (BGPHES) Data Link.")]
	BattleGroupPassiveHorizonExtensionSystemBGPHESDataLink = 41,
	[Description("Common High Bandwidth Data Link (CHBDL).")]
	CommonHighBandwidthDataLinkCHBDL = 42,
	[Description("Guardrail Interoperable Data Link (IDL).")]
	GuardrailInteroperableDataLinkIDL = 43,
	[Description("Guardrail Common Sensor System One (CSS1) Data Link.")]
	GuardrailCommonSensorSystemOneCSS1DataLink = 44,
	[Description("Guardrail Common Sensor System Two (CSS2) Data Link.")]
	GuardrailCommonSensorSystemTwoCSS2DataLink = 45,
	[Description("Guardrail CSS2 Multi-Role Data Link (MRDL).")]
	GuardrailCSS2MultiRoleDataLinkMRDL = 46,
	[Description("Guardrail CSS2 Direct Air to Satellite Relay (DASR) Data Link.")]
	GuardrailCSS2DirectAirToSatelliteRelayDASRDataLink = 47,
	[Description("Line of Sight (LOS) Data Link Implementation (LOS tether).")]
	LineOfSightLOSDataLinkImplementationLOSTether = 48,
	[Description("Lightweight CDL (LWCDL).")]
	const_49 = 49,
	[Description("L-52M (SR-71).")]
	L52MSR71 = 50,
	[Description("Rivet Reach/Rivet Owl Data Link.")]
	RivetReachRivetOwlDataLink = 51,
	[Description("Senior Span.")]
	SeniorSpan = 52,
	[Description("Senior Spur.")]
	SeniorSpur = 53,
	[Description("Senior Stretch.")]
	SeniorStretch = 54,
	[Description("Senior Year Interoperable Data Link (IDL).")]
	SeniorYearInteroperableDataLinkIDL = 55,
	[Description("Space CDL.")]
	SpaceCDL = 56,
	[Description("TR-1 mode MIST Airborne Data Link.")]
	TR1ModeMISTAirborneDataLink = 57,
	[Description("Ku-band SATCOM Data Link Implementation (UAV).")]
	KuBandSATCOMDataLinkImplementationUAV = 58,
	[Description("Mission Equipment Control Data link (MECDL).")]
	MissionEquipmentControlDataLinkMECDL = 59,
	[Description("Radar Data Transmitting Set Data Link.")]
	RadarDataTransmittingSetDataLink = 60,
	[Description("Surveillance and Control Data Link (SCDL).")]
	SurveillanceAndControlDataLinkSCDL = 61,
	[Description("Tactical UAV Video.")]
	TacticalUAVVideo = 62,
	[Description("UHF SATCOM Data Link Implementation (UAV).")]
	UHFSATCOMDataLinkImplementationUAV = 63,
	[Description("Tactical Common Data Link (TCDL).")]
	TacticalCommonDataLinkTCDL = 64,
	[Description("Low Level Air Picture Interface (LLAPI).")]
	LowLevelAirPictureInterfaceLLAPI = 65,
	[Description("Weapons Data Link (AGM-130).")]
	WeaponsDataLinkAGM130 = 66,
	[Description("GC3.")]
	GC3 = 99,
	[Description("Link 16 Standardized Format (JTIDS/MIDS/TADIL J).")]
	Link16StandardizedFormatJTIDSMIDSTADILJ = 100,
	[Description("Link 16 Enhanced Data Rate (EDR JTIDS/MIDS/TADIL-J).")]
	Link16EnhancedDataRateEDRJTIDSMIDSTADILJ = 101,
	[Description("JTIDS/MIDS Net Data Load (TIMS/TOMS).")]
	JTIDSMIDSNetDataLoadTIMSTOMS = 102,
	[Description("Link 22.")]
	Link22 = 103,
	[Description("AFIWC IADS Communications Links.")]
	AFIWCIADSCommunicationsLinks = 104
}
