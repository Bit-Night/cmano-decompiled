using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using CSMaterial;
using Cysharp.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using Sharp3D.Math.Core;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Sensor : PlatformComponent
{
	public struct _Capabilities
	{
		public bool AirSearch;

		public bool SurfaceSearch;

		public bool SubSearch;

		public bool LandSearch_Mobile;

		public bool LandSearch_Fixed;

		public bool PeriscopeSearch;

		public bool C_RAM;

		public bool SpaceSearch_ABM;

		public bool Mine_Obstacle_Search;

		public bool RangeInfo;

		public bool HeadingInfo;

		public bool AltitudeInfo;

		public bool SpeedInfo;

		public bool NavigationOnly;

		public bool GroundMappingOnly;

		public bool TerrainAvoidanceFollowingOnly;

		public bool WeatherOnly;

		public bool WeatherAndNavigationOnly;

		public bool OTH_Backscatter;

		public bool OTH_SurfaceWave;

		public bool TorpedoWarning;

		public bool MissileApproachWarning;
	}

	public struct _Codes
	{
		public bool IFF_Capable;

		public bool Classification;

		public bool NCTR_JEM;

		public bool NCTR_NBILST;

		public bool ContinuousTrackingCapable;

		public bool ContinousTrackingCapable_RadarTracker;

		public bool ContinousTrackingCapable_Visual;

		public bool TWS;

		public bool MTI;

		public bool LPI;

		public bool VisualNightCapable;

		public bool Pulse_only;

		public bool Doppler_LDSD_Limited;

		public bool Doppler_LDSD_Full;

		public bool CWI;

		public bool ICWI;

		public bool bool_0;

		public bool GeneratesAAWFireControl;

		public bool ShallowWaterCapable_Partial;

		public bool ShallowWaterCapable_Full;

		public bool PESA;

		public bool AESA;

		public bool SyntheticApertureRadar;

		public bool PeriscopeSearch_Basic;

		public bool PeriscopeAndSurfaceSearch_FineRangeResolution;

		public bool PeriscopeAndSurfaceSearch_AdvancedProcessing;

		public bool FrequencyAgile;
	}

	public enum FrequencyBand : long
	{
		A_Band = 1001L,
		B_Band = 1002L,
		C_Band = 1003L,
		D_Band = 1004L,
		E_Band = 1005L,
		F_Band = 1006L,
		G_Band = 1007L,
		H_Band = 1008L,
		I_Band = 1009L,
		J_Band = 1010L,
		K_Band = 1011L,
		L_Band = 1012L,
		M_Band = 1013L,
		Visual_Light = 2001L,
		Near_IR = 2002L,
		Far_IR = 2003L,
		Laser = 2004L,
		ELF_Radio = 3001L,
		SLF_Radio = 3002L,
		ULF_Radio = 3003L,
		VLF_Radio = 3004L,
		LF_Radio = 3005L,
		MF_Radio = 3006L,
		HF_Radio = 3007L,
		VHF_Radio = 3008L,
		UHF_Radio = 3009L,
		SHF_Radio = 3010L,
		EHF_Radio = 3011L,
		LF_Sonar = 4001L,
		MF_Sonar = 4002L,
		HF_Sonar = 4003L,
		VLF_Sonar = 4004L,
		GNSS_GPS = 5001L,
		GNSS_GLONASS = 5002L,
		GNSS_BeiDou = 5003L,
		GNSS_NavIC = 5004L
	}

	public enum Sensor_Type : short
	{
		None = 1001,
		Radar = 2001,
		SemiActive = 2002,
		Visual = 2003,
		Infrared = 2004,
		TVM = 2005,
		Terminal_SemiActive = 2006,
		ESM = 3001,
		ECM = 3002,
		EMP_Projector = 3003,
		PCLS = 3004,
		LaserDesignator = 4001,
		LaserSpotTracker = 4002,
		LaserRangefinder = 4003,
		LIDAR = 4101,
		HullSonar_PassiveOnly = 5001,
		HullSonar_ActivePassive = 5002,
		HullSonar_ActiveOnly = 5003,
		Bow_Sonar_ActivePassive = 5004,
		TowedArray_PassiveOnly = 5011,
		TowedArray_ActivePassive = 5012,
		TowedArray_ActiveOnly = 5013,
		VDS_PassiveOnly = 5021,
		VDS_ActivePassive = 5022,
		VDS_ActiveOnly = 5023,
		DippingSonar_PassiveOnly = 5031,
		DippingSonar_ActivePassive = 5032,
		DippingSonar_ActiveOnly = 5033,
		BottomFixedSonar_PassiveOnly = 5041,
		MAD = 5101,
		Wake_Detector = 5601,
		PingIntercept = 5901,
		MineSweep_MechanicalCableCutter = 6001,
		MineSweep_MagneticInfluence = 6002,
		MineSweep_AcousticInfluence = 6003,
		MineSweep_MultiInfluence = 6004,
		MineSweep_TwoShipMagneticInfluence = 6011,
		MineNeutralization_MooredMineCableCutter = 6021,
		MineNeutralization_ExplosiveChargeMineDisposal = 6022,
		MineNeutralization_DiverExplosiveCharge = 6031,
		Microwave_Emitter = 7001,
		NonDetectingEmitter = 8001,
		SensorGroup = 9001
	}

	public enum Sensor_Role : long
	{
		None = 1001L,
		AirSearch_2D_LR = 2001L,
		AirSeach_3D_LR = 2002L,
		AirSeach_2D_MR = 2003L,
		AirSeach_3D_MR = 2004L,
		AirSeach_2D_SR = 2005L,
		AirSeach_3D_SR = 2006L,
		AirSurfaceSearch_2D_LR = 2011L,
		AirSurfaceSearch_3D_LR = 2012L,
		AirSurfaceSearch_2D_MR = 2013L,
		AirSurfaceSearch_3D_MR = 2014L,
		AirSurfaceSearch_2D_SR = 2015L,
		AirSurfaceSearch_3D_SR = 2016L,
		HeightFinder_LR = 2017L,
		HeightFinder_MR = 2018L,
		HeightFinder_SR = 2019L,
		SurfaceSearch_LR = 2021L,
		SurfaceSearch_MR = 2022L,
		SurfaceSearch_SR = 2023L,
		SurfaceSearch_OTH = 2027L,
		SurfaceSearch_Navigation = 2028L,
		NavigationOnly = 2031L,
		GroundMappingOnly = 2032L,
		TerrainAvoidanceFollowingOnly = 2033L,
		WeatherOnly = 2034L,
		WeatherNavigationOnly = 2035L,
		TargetIndicator_SurfToAir_2D = 2101L,
		TargetIndicator_SurfToAir_3D = 2102L,
		TargetIndicator_SurfToAirSurfToSurf_2D = 2103L,
		TargetIndicator_SurfToAirSurfToSurf_3D = 2104L,
		TargetIndicator_SurfToSurf = 2105L,
		CounterBattery = 2109L,
		FCR_AirToAir_LR = 2111L,
		FCR_AirToAir_MR = 2112L,
		FCR_AirToAir_SR = 2113L,
		FCR_AirToAir_AirToSurf_LR = 2121L,
		FCR_AirToAir_AirToSurf_MR = 2122L,
		FCR_AirToAir_AirToSurf_SR = 2123L,
		FCR_AirToSurf_LR = 2124L,
		FCR_AirToSurf_MR = 2125L,
		FCR_AirToSurf_SR = 2126L,
		FCR_SurfToAir_LR = 2131L,
		FCR_SurfToAir_MR = 2132L,
		FCR_SurfToAir_SR = 2133L,
		FCR_SurfToAir_SurfToSurf_LR = 2141L,
		FCR_SurfToAir_SurfToSurf_MR = 2142L,
		FCR_SurfToAir_SurfToSurf_SR = 2143L,
		FCR_SurfToSurf = 2151L,
		FCR_SurfToSurf_OTH = 2152L,
		FCR_SurfToSurf_Torpedo = 2161L,
		FCR_GunOnly = 2191L,
		Illuminator_SAM_LR = 2201L,
		Illuminator_SAM_MR = 2202L,
		Illuminator_SAM_SR = 2203L,
		ActiveMissileSeeker = 2211L,
		RangeOnly = 2301L,
		Land_ATC = 2311L,
		Shipboard_ATC = 2312L,
		Radar_BMEWS = 2401L,
		Radar_BallisticMissileBattleManagement = 2402L,
		Radar_BallisticMissileTracker = 2403L,
		Radar_BallisticMissileEngagement = 2404L,
		LLTV_MineRecon = 2791L,
		IR_MAWS = 2891L,
		ESM_RWR = 3001L,
		ESM_LWR = 3002L,
		ESM_ELINT = 3011L,
		ESM_ELINT_OTHT = 3012L,
		ESM_COMINT = 3021L,
		ESM_SIGINT = 3031L,
		ESM_SIGINT_OTHT = 3032L,
		ESM_MASINT = 3041L,
		ESM_HFDF = 3101L,
		ESM_HFDF_OTHT = 3102L,
		ESM_ELS = 3201L,
		ESM_PassiveMissileSeeker = 3211L,
		ECM_OECM = 4001L,
		ECM_DECM = 4011L,
		ECM_OECM_DECM = 4021L,
		ECM_Repeater = 4031L,
		IRCM = 4041L,
		ECM_COMINT_Jammer = 4091L,
		GNSS_Jammer = 4101L,
		ECM_AcousticJammer = 4901L,
		ECM_AcousticRepeater = 4902L,
		HullSonarPassiveOnlySearch = 5001L,
		HullSonarPassiveOnlySearchTrack = 5002L,
		HullSonarPassiveOnlyRangingFlankArraySearchTrack = 5011L,
		HullSonarPassiveOnlyTorpedoWarning = 5021L,
		HullSonarActivePassiveSearch = 5031L,
		HullSonarActivePassiveSearchTrack = 5032L,
		HullSonarActivePassiveSearchAttack = 5033L,
		HullSonarActivePassiveSearchMortarFireControl = 5034L,
		HullSonarActivePassiveAttack = 5041L,
		HullSonarActiveOnlySearch = 5061L,
		HullSonarActiveOnlySearchTrack = 5062L,
		HullSonarActiveOnlySearchAttack = 5063L,
		HullSonarActiveOnlySearchMortarFireControl = 5064L,
		HullSonarActiveOnlyAttack = 5071L,
		HullSonarActiveOnlyMortarFireControl = 5072L,
		HullSonarActiveOnlyBottomProfiler = 5081L,
		HullSonarActiveOnlyShortRangeSidescanMapping = 5082L,
		HullSonarActiveOnlyShortRangeSidescanMappingHighDefinitionLPI = 5083L,
		HullSonarActiveOnlyMineAvoidance = 5091L,
		HullSonarActiveOnlyMineObstacleAvoidance = 5092L,
		HullSonarActiveOnlyShallowWaterMineObstacleAvoidance = 5093L,
		HullSonarActiveOnlyShallowWaterHighDefinitionMineObstacleAvoidance = 5094L,
		HullSonarActiveOnlyUnderIceNavigationandMineObstacleAvoidance = 5095L,
		HullSonarActiveOnlyAntiCollisionNavigation = 5096L,
		HullSonarActiveOnlyMineReconnaissance = 5097L,
		HullSonarActiveOnlyMineHunting = 5098L,
		HullSonarActiveOnlyMineHuntingASWMortarFireControl = 5099L,
		HullSonarPassiveOnlyVerticalRangingArray = 5012L,
		LLTV_Surveillance_Camera = 2701L,
		LLTV_SurveillanceAndNavigation_Camera = 2702L,
		LLTV_NightVisionGoggles_NVG = 2703L,
		LLTV_DayNight_SphericalSituationalAwarenessAndFireControl = 2709L,
		LLTV_DayNight_SphericalSituationalAwareness = 2710L,
		LLTV_Reconnaissance_FrameCamera = 2711L,
		LLTV_Reconnaissance_LongRange_FrameCamera = 2712L,
		LLTV_Reconnaissance_VeryLongRange_FrameCamera = 2713L,
		LLTV_Reconnaissance_Satellite_FrameCamera = 2719L,
		LLTV_WideAngleAerialSurveillance_WAAS = 2720L,
		LLTV_Navigation = 2721L,
		LLTV_NavigationAndAttack = 2730L,
		LLTV_Attack = 2731L,
		LLTV_TargetTrackingAndIdentification = 2771L,
		LLTV_TargetSearchTrackingAndIdentification = 2772L,
		LLTV_TargetSearchSlavedTrackingAndIdentification = 2773L,
		LLTV_WeaponDirector = 2781L,
		LLTV_WeaponDirectorAndTargetTrackingAndIdentification = 2782L,
		LLTV_WeaponDirectorAndTargetSearchTrackingAndIdentification = 2783L,
		LLTV_WeaponDirectorAndTargetSearchSlavedTrackingAndIdentification = 2784L,
		LLTV_MineReconnaissance = 2791L,
		TASSPassiveOnlyTowedArraySonarSystem = 5101L,
		TASSPassiveOnlyFatLineTowedArraySonarSystem = 5102L,
		TASSPassiveOnlyThinLineTowedArraySonarSystem = 5103L,
		TASSPassiveOnlyAreaSurveillanceTowedArraySonarSystem = 5104L,
		TASSPassiveTorpedoWarningTowedArraySonarSystem = 5111L,
		TASSActivePassiveTowedArraySonarSystem = 5131L,
		TASSActivePassiveAreaSurveillanceTowedArraySonarSystem = 5132L,
		TASSActiveOnlyTowedArraySonarSystem = 5161L,
		SURTASSPassiveOnlySurveillanceTowedArraySonarSystem = 5191L,
		SURTASSActivePassiveSurveillanceTowedArraySonarSystem = 5192L,
		SURTASSActiveOnlySurveillanceTowedArraySonarSystem = 5193L,
		VDSPassiveOnlyVariableDepthSonar = 5201L,
		VDSActivePassiveVariableDepthSonar = 5231L,
		VDSActiveOnlyVariableDepthSonar = 5261L,
		VDSActiveOnlyMineReconnaissanceVariableDepthSonar = 5271L,
		VDSActiveOnlyMineHuntingVariableDepthSonar = 5272L,
		VDSActiveOnlySidescanMineHuntingVariableDepthSonar = 5273L,
		VDSPropelledActiveOnlyMineHuntingVariableDepthSonar = 5274L,
		DippingSonarPassiveOnlySearchTrack = 5301L,
		DippingSonarActivePassiveSearchTrack = 5331L,
		DippingSonarActivePassiveShallowWaterSearchTrack = 5332L,
		DippingSonarActiveOnlySearchTrack = 5361L,
		HelicopterTowedActiveOnlyMineReconnaissanceSonar = 5391L,
		SOSUSPassiveSoundSurveillanceSystems = 5401L,
		MooredSonobuoyPassiveSearch = 5402L,
		SonobuoyPassiveOnlyNonDirectional = 5501L,
		SonobuoyPassiveOnlyDirectional = 5502L,
		SonobuoyPassiveOnlyDirectionalFrequencyAnalysisandRecording_DIFAR = 5507L,
		SonobuoyPassiveOnlyDirectionalLowFrequencyAnalysisandRanging_LOFAR = 5508L,
		SonobuoyPassiveOnlyDirectionalVerticalLineArrayDIFAR_VLAD = 5509L,
		SonobuoyActivePassiveRangeOnlyOmniDirectional = 5511L,
		SonobuoyActivePassiveRangeDirectional = 5512L,
		SonobuoyActiveOnlyRangeOnlyNonDirectional = 5521L,
		SonobuoyActiveOnlyRangeOnlyNonDirectionalContinousPing = 5522L,
		SonobuoyActiveOnlyRangeOnlyNonDirectionalCommandActivatedSonobuoySystem_CASS = 5523L,
		SonobuoyActiveOnlyRangeDirectional = 5527L,
		SonobuoyActiveOnlyRangeDirectionalCommandActivatedSonobuoySystem_DICASS = 5528L,
		SonobuoyActiveOnlyRangeDirectionalExtendedEchoRanging_EER = 5529L,
		TorpedoSeekerPassiveOnly = 5701L,
		TorpedoSeekerPassiveOnlyShallowWater = 5702L,
		TorpedoSeekerActivePassive = 5711L,
		TorpedoSeekerActivePassiveShallowWater = 5712L,
		TorpedoSeekerActivePassiveWakeHomer_WH = 5713L,
		TorpedoSeekerActivePassiveShallowWaterWakeHomer_WH = 5714L,
		TorpedoSeekerActiveOnly = 5721L,
		TorpedoSeekerActiveOnlyShallowWater = 5722L,
		TorpedoSeekerWakeHomer = 5791L,
		Visual_Binoculars = 2501L,
		Visual_Optical_Sight = 2511L,
		Visual_Bomb_Sight = 2512L,
		Visual_Surveillance_Periscope = 2515L,
		Visual_Fire_Control_Periscope = 2516L,
		Visual_Searchlight = 2521L,
		Visual_Surveillance_TVCamera = 2601L,
		Visual_SurveillanceNavigation_TVCamera = 2602L,
		Visual_SpaceObject_Surveillance = 2605L,
		Visual_SpaceObject_Tracker = 2606L,
		Visual_DayOnlySphericalSituationalAwarenessAndFireControl = 2609L,
		Visual_DayOnlySphericalSituationalAwareness = 2610L,
		Visual_Reconnaissance_FrameCamera = 2611L,
		Visual_Reconnaissance_LongRange_FrameCamera = 2612L,
		Visual_Reconnaissance_VeryLongRange_FrameCamera = 2613L,
		Visual_Reconnaissance_SatelliteFrameCamera = 2619L,
		Visual_WideAngle_AerialSurveillance_WAAS = 2620L,
		Visual_Navigation_TVCamera = 2621L,
		Visual_NavigationAndAttack_TVCamera = 2630L,
		Visual_Attack_TVCamera = 2631L,
		Visual_Strike_Camera = 2641L,
		Visual_TargetTrackingAndIdentification_TVCamera = 2671L,
		Visual_TargetSearchTrackingAndIdentification_TVCamera = 2672L,
		Visual_TargetSearch_SlavedTrackingAndIdentification_TVCamera = 2673L,
		Visual_WeaponDirector_TVCamera = 2681L,
		Visual_WeaponDirector_TargetTrackingAndIdentification_TVCamera = 2682L,
		Visual_WeaponDirector_TargetSearchTrackingAndIdentification_TVCamera = 2683L,
		Visual_WeaponDirector_TargetSearchSlavedTrackingAndIdentification_TVCamera = 2684L,
		Infrared_BMEWS = 2899L,
		MAD = 5801L,
		AcousticIntercept = 5901L,
		AcousticInterceptPassiveRanging = 5902L,
		AcousticInterceptSurveillance = 5903L,
		AcousticInterceptTorpedoWarning = 5911L,
		RADAR_PERISCOPE_SEARCH = 2029L,
		RADAR_TERRAIN_AVOIDANCE = 2036L,
		RADAR_BOMB_SCORING_RADAR = 2039L,
		TWR_TAIL_WARNING_RADAR_TAIL_GUN_DIRECTOR = 2041L,
		TWR_TAIL_WARNING_RADAR = 2042L,
		RADAR_MISSILE_APPROACH_WARNING_SYSTEM_MAWS = 2049L,
		SLAR_SIDE_LOOKING_AIRBORNE_RADAR = 2051L,
		TTR_TARGET_TRACKING_RADAR = 2207L,
		TRR_TARGET_RANGING_RADAR = 2208L,
		MTR_MISSILE_TRACKING_RADAR = 2209L,
		WEAPON_SEEKER_SEMI_ACTIVE_RADAR_HOMING_SARH = 2212L,
		WEAPON_SEEKER_TERMINAL_SEMI_ACTIVE_RADAR_HOMING_TSARH = 2213L,
		WEAPON_SEEKER_TV = 2691L,
		INFRARED_SURVEILLANCE_CAMERA = 2801L,
		INFRARED_SURVEILLANCE_FLIR_DEPRECATED = 2802L,
		INFRARED_SURVEILLANCE_NAVIGATION_CAMERA = 2803L,
		INFRARED_SURVEILLANCE_NAVIGATION_FLIR_DEPRECATED = 2804L,
		INFRARED_SPACE_OBJECT_TRACKER = 2806L,
		INFRARED_SPACE_OBJECT_SURVEILLANCE = 2807L,
		INFRARED_DAYNIGHT_SPHERICAL_SITUATIONAL_AWARENESS_FIRE_CONTROL = 2809L,
		INFRARED_DAYNIGHT_SPHERICAL_SITUATIONAL_AWARENESS = 2810L,
		INFRARED_RECONNAISSANCE_FRAME_CAMERA = 2811L,
		INFRARED_RECONNAISSANCE_LONG_RANGE_FRAME_CAMERA = 2812L,
		INFRARED_RECONNAISSANCE_VERY_LONG_RANGE_FRAME_CAMERA = 2813L,
		IRLS_NON_IMAGING_INFRARED_LINE_SCANNER = 2814L,
		INFRARED_RECONNAISSANCE_SATELLITE_FRAME_CAMERA = 2819L,
		INFRARED_WIDE_ANGLE_AERIAL_SURVEILLANCE_WAAS = 2820L,
		INFRARED_NAVIGATION_CAMERA = 2821L,
		INFRARED_NAVIGATION_FLIR_DEPRECATED = 2822L,
		INFRARED_NAVIGATION_ATTACK_CAMERA = 2831L,
		INFRARED_NAVIGATION_ATTACK_FLIR_DEPRECATED = 2832L,
		INFRARED_ATTACK_CAMERA = 2833L,
		INFRARED_ATTACK_FLIR_DEPRECATED = 2834L,
		INFRARED_NAVIGATION_ATTACK_CAMERA_AIR_TO_AIR_TRACKING = 2841L,
		INFRARED_ATTACK_CAMERA_AIR_TO_AIR_TRACKING = 2842L,
		IRST_NON_IMAGING_INFRARED_SEARCH_AND_TRACK = 2851L,
		IRST_IMAGING_INFRARED_SEARCH_AND_TRACK = 2852L,
		INFRARED_TARGET_TRACKING_AND_IDENTIFICATION_CAMERA = 2871L,
		INFRARED_TARGET_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2872L,
		INFRARED_TARGET_SEARCH_TRACKING_AND_IDENTIFICATION_CAMERA = 2873L,
		INFRARED_TARGET_SEARCH_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2874L,
		INFRARED_TARGET_SEARCH_SLAVED_TRACKING_AND_IDENTIFICATION_CAMERA = 2875L,
		INFRARED_TARGET_SEARCH_SLAVED_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2876L,
		INFRARED_TARGET_INDICATOR_CAMERA = 2879L,
		INFRARED_WEAPON_DIRECTOR_CAMERA = 2881L,
		INFRARED_WEAPON_DIRECTOR_FLIR_DEPRECATED = 2882L,
		INFRARED_WEAPON_DIRECTOR_TARGET_TRACKING_AND_IDENTIFICATION_CAMERA = 2883L,
		INFRARED_WEAPON_DIRECTOR_TARGET_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2884L,
		INFRARED_WEAPON_DIRECTOR_TARGET_SEARCH_TRACKING_AND_IDENTIFICATION_CAMERA = 2885L,
		INFRARED_WEAPON_DIRECTOR_TARGET_SEARCH_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2886L,
		INFRARED_WEAPON_DIRECTOR_TARGET_SEARCH_SLAVED_TRACKING_AND_IDENTIFICATION_CAMERA = 2887L,
		INFRARED_WEAPON_DIRECTOR_TARGET_SEARCH_SLAVED_TRACKING_AND_IDENTIFICATION_FLIR_DEPRECATED = 2888L,
		MAWS_MISSILE_APPROACH_WARNING_SYSTEM_INFRARED_SPHERICAL_SITUATIONAL_AWARENESS = 2890L,
		WEAPON_SEEKER_SINGLE_SPECTRAL_IR = 2892L,
		WEAPON_SEEKER_INFRARED_DUAL_SPECTRAL_IR = 2893L,
		WEAPON_SEEKER_IMAGING_IR = 2894L,
		COMINTDF = 3022L,
		EMITTER_LOCATOR_SYSTEM_ELS = 3202L,
		IFF_DECEPTION_SYSTEM = 3901L,
		EMP_PROJECTOR = 4051L,
		MICROWAVE_EMITTER = 4061L,
		COMMUNICATIONS_JAMMER_DIRECTIONAL = 4092L,
		BOW_SONAR_ACTIVEPASSIVE_SEARCH = 5042L,
		WAKE_DETECTOR = 5601L,
		GUIDED_DEPTH_CHARGE_SEEKER_ACTIVE_ONLY = 5795L,
		GUIDED_DEPTH_CHARGE_SEEKER_ACTIVE_ONLY_SHALLOW_WATER = 5796L,
		MINE_SWEEP_MECHANICAL_CABLE_CUTTER = 6001L,
		MINE_SWEEP_MAGNETIC_INFLUENCE = 6002L,
		MINE_SWEEP_ACOUSTIC_INFLUENCE = 6003L,
		MINE_SWEEP_MAGNETIC_ACOUSTIC_MULTI_INFLUENCE = 6004L,
		MINE_SWEEP_TWO_SHIP_MAGNETIC_INFLUENCE = 6009L,
		MINE_SWEEP_HELICOPTER_TOWED_MECHANICAL_CABLE_CUTTER = 6011L,
		MINE_SWEEP_HELICOPTER_TOWED_MAGNETIC_INFLUENCE = 6012L,
		MINE_SWEEP_HELICOPTER_TOWED_ACOUSTIC_INFLUENCE = 6013L,
		MINE_SWEEP_HELICOPTER_TOWED_MAGNETIC_ACOUSTIC_MULTI_INFLUENCE = 6014L,
		MINE_NEUTRALIZATION_MOORED_MINE_CABLE_CUTTER = 6021L,
		MINE_NEUTRALIZATION_EXPLOSIVE_CHARGE_MINE_DISPOSAL = 6022L,
		MINE_NEUTRALIZATION_DIVER_DEPLOYED_EXPLOSIVE_CHARGE = 6031L,
		LIDAR_AIRBORNE_MINE_DETECTION = 6051L,
		LST_LASER_SPOT_TRACKER = 6061L,
		LASER_RANGEFINDER = 6071L,
		LASER_RANGEFINDER_FOR_WEAPON_DIRECTOR = 6081L,
		LASER_RANGEFINDER_FOR_WEAPON_DIRECTOR_TARGET_TRACKING_AND_IDENTIFICATION = 6082L,
		LASER_TARGET_DESIGNATOR = 6091L,
		LASER_TARGET_DESIGNATOR_RANGER_LTDR = 6092L,
		LASER_RANGER_AND_MARKED_TARGET_SEEKER_LRMTS = 6093L,
		WEAPON_SEEKER_SEMI_ACTIVE_LASER_HOMING_SALH = 6099L,
		SENSOR_GROUP = 9001L,
		SENSOR_TURRET = 9002L
	}

	public enum DetectionAttemptType
	{
		VolumeSearch,
		SpecificTargetTracking,
		WeaponGuidance,
		Recon
	}

	public enum SensorDetectionFeedback
	{
		DB_Invisible = -10000,
		PROGRAM_Exception = 99999,
		GENERAL_Range = 1,
		GENERAL_TargetSuitability = 3,
		GENERAL_CoveringArc = 5,
		GENERAL_SensorElevationAngleLimits = 6,
		GENERAL_MaxAltitude_AGL = 7,
		GENERAL_MinAltitude_AGL = 9,
		GENERAL_MaxAltitude_ASL = 11,
		GENERAL_MinAltitude_ASL = 13,
		GENERAL_Other = 15,
		GENERAL_WeaponESM_UnsuitableTarget_Satellite = 17,
		GENERAL_WeaponESM_UnsuitableTarget_AircraftOrWeapon = 19,
		GENERAL_WeaponESM_UnsuitableTarget_ShipOrFacility = 21,
		GENERAL_SuccessfullDetection_FromOneOfThePCLS = 22,
		GENERAL_FailedDetection_FromAllThePCLS = 23,
		GENERAL_SuccessfullDetection_IR = 24,
		GENERAL_FailedDetection_IR = 25,
		GENERAL_SuccessfullDetection_PingIntercept = 26,
		GENERAL_FailedDetection_PingIntercept = 27,
		GENERAL_SuccessfullDetection_Visual = 28,
		GENERAL_FailedDetection_Visual = 29,
		GENERAL_SuccessfullDetection_Radar = 30,
		GENERAL_FailedDetection_Radar = 31,
		GENERAL_SuccessfullDetection_ESM = 32,
		GENERAL_FailedDetection_ESM = 33,
		GENERAL_SuccessfullDetection_HullandBottomFixed_PassiveSonar = 34,
		GENERAL_FailedDetection_HullandBottomFixed_PassiveSonar = 35,
		GENERAL_SuccessfullDetection_HullandBottomFixed_ActiveSonar = 36,
		GENERAL_FailedDetection_HullandBottomFixed_ActiveSonar = 37,
		GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar = 38,
		GENERAL_FailedDetection_DippingAndVDS_PassiveSonar = 39,
		GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar = 40,
		GENERAL_FailedDetection_DippingAndVDS_ActiveSonar = 41,
		GENERAL_SuccessfullDetection_MAD = 42,
		GENERAL_FailedDetection_MAD = 43,
		RADAR_RadarLOS_SurfaceWave = 101,
		RADAR_RadarLOS = 103,
		RADAR_RadarLOS_Terrain = 105,
		RADAR_PureIlluminatorFailedDetection = 107,
		RADAR_PureIlluminatorSuccessfulDetection = 109,
		RADAR_SubUnitAbovePeriscopeDepthNotDetectable_BiologicsOrFalseContact = 111,
		RADAR_SubUnitAbovePeriscopeDepthNotDetectable_NoPeriscopeOrSnorkel = 113,
		RADAR_CantDetectPeriscope = 115,
		RADAR_BlindCone = 117,
		RADAR_LDSD_Limited_LookDown15deg = 119,
		RADAR_LDSD_Limited_LookDown5deg = 121,
		RADAR_Other = 123,
		RADAR_ECM_Equation = 125,
		RADAR_Successful_OTHBackscatter = 126,
		RADAR_ABM_HorizonFailed = 127,
		RADAR_ABM_HorizonSuccessful = 129,
		VISUAL_VerticalViewAngle45deg = 201,
		VISUAL_AverageCockpitVisibility_VerticalViewAngle25deg = 203,
		VISUAL_RNG_ExcellentCockpitVisibility = 205,
		VISUAL_RNG_AverageCockpitVisibility = 207,
		VISUAL_RNG_PoorCockpitVisibility = 209,
		VISUAL_LOS = 211,
		VISUAL_MaxNominalRange = 213,
		VISUAL_MaxSpecificRange = 215,
		VISUAL_ABM_Horizon_Failed = 217,
		VISUAL_ABM_Horizon_Successful = 218,
		IR_LOSVisual = 401,
		IR_MaxRange = 403,
		IR_MaxRange_SpecificToTarget = 405,
		IR_NoPeriscopeSearchCapability = 407,
		IR_ABM_BeyondHorizon = 409,
		PING_LOSSonar = 501,
		PING_MaxRange = 503,
		PING_NoInterceptionFromAnyEmitter = 505,
		ACTIVESONAR_NotOperating = 601,
		ACTIVESONAR_LOSSonar = 603,
		ACTIVESONAR_AboveDeafSpeed = 605,
		ACTIVESONAR_MaxRangeSpecificTarget = 607,
		ACTIVESONAR_SuccessfulDirectDetection = 608,
		ACTIVESONAR_SuccessfulIndirectDetection = 610,
		ACTIVESONAR_SuccessfulBottomBounceDetection = 612,
		ACTIVESONAR_SuccessfulDetectionThroughCZ = 614,
		ACTIVESONAR_Other = 615,
		PASSIVESONAR_NotOperating = 701,
		PASSIVESONAR_SuccessfulPingIntercept = 702,
		PASSIVESONAR_FailedPingIntercept = 703,
		PASSIVESONAR_AboveDeafSpeed = 705,
		PASSIVESONAR_LOSSonar = 707,
		PASSIVESONAR_MaxNominalRange = 709,
		PASSIVESONAR_SignalMaskedByAnother = 711,
		PASSIVESONAR_MaxActualRange = 713,
		PASSIVESONAR_LandmassInBetween = 715,
		PASSIVESONAR_SuccessfulDetectionThroughCZ = 716,
		PASSIVESONAR_CZBlockingAndNoDirectPath = 717,
		MAD_UnitIsSubBiologics = 801,
		MAD_UnitIsTorpedo = 803,
		MAD_MaxEffectiveRange = 805,
		MAD_IsNotBoatType = 807,
		RADARILLUMINATION_RadarHorizonLOS_SurfaceWave = 901,
		RADARILLUMINATION_RadarHorizonLOS = 903,
		RADARILLUMINATION_RadarHorizonLOS_Failed = 905,
		RADARILLUMINATION_CoveringArc = 907,
		RADARILLUMINATION_Other = 909,
		RADARILLUMINATION_ECMEquation = 911,
		RADARILLUMINATION_ABM_Horizon_Failure = 913,
		RADARILLUMINATION_ABM_Horizon_Success = 914,
		RADARILLUMINATION_OTH_Success = 916,
		RADARILLUMINATION_OTH_Failure = 917,
		ESM_RadarHorizonLOS_SurfaceWave = 1001,
		ESM_RadarHorizonLOS = 1003,
		ESM_RadarHorizonLOS_Terrain = 1005,
		ESM_RWRvsJamming = 1007,
		ESM_Equation = 1009,
		ESM_OTHSW_Emitter_MaxRange = 1011,
		ESM_OTHSW_Emitter_LOS = 1013,
		ESM_EmitterNotActive = 1015,
		ESM_IncompatibleFrequency = 1017,
		ESM_EmitterNotOperating = 1019,
		ESM_MaxRange = 1021,
		ESM_Success = 1022,
		ESM_Failure = 1023
	}

	private enum Enum8
	{

	}

	public enum SensorDetectionCheckResult
	{
		Undefined = 0,
		Success = 1,
		Fail_OutOfRange = 2,
		Fail_NoLOS_Terrain = 3,
		Fail_NoLOS_Cloud = 4,
		Fail_NoLOS_Fog = 5,
		Fail_NoLOS_Horizon = 6,
		Fail_OutsideCoverageArc = 7,
		Fail_NotSuitableForThisTarget = 8,
		Fail_SensorParentInoperative = 9,
		Fail_NotEnoughReturn = 10,
		Fail_Other = 9999
	}

	public enum ActiveEmissionMode : byte
	{
		Search_Track,
		Illuminate
	}

	public class RadioElectronicFrequency
	{
		public FrequencyBand Band;

		public string ToString_Short
		{
			get
			{
				FrequencyBand band = Band;
				if (band <= FrequencyBand.Laser)
				{
					FrequencyBand num = band - 1001L;
					if ((ulong)num <= 12uL)
					{
						switch (num)
						{
						case (FrequencyBand)0L:
							return "A";
						case (FrequencyBand)1L:
							return "B";
						case (FrequencyBand)2L:
							return "C";
						case (FrequencyBand)3L:
							return "D";
						case (FrequencyBand)4L:
							return "E";
						case (FrequencyBand)5L:
							return "F";
						case (FrequencyBand)6L:
							return "G";
						case (FrequencyBand)7L:
							return "H";
						case (FrequencyBand)8L:
							return "I";
						case (FrequencyBand)9L:
							return "J";
						case (FrequencyBand)10L:
							return "K";
						case (FrequencyBand)11L:
							return "L";
						case (FrequencyBand)12L:
							return "M";
						}
					}
					FrequencyBand num2 = band - 2002L;
					if ((ulong)num2 <= 2uL)
					{
						switch (num2)
						{
						case (FrequencyBand)0L:
							return "Near IR";
						case (FrequencyBand)1L:
							return "Far IR";
						case (FrequencyBand)2L:
							return "Laser";
						}
					}
					goto IL_0295;
				}
				FrequencyBand num3 = band - 3001L;
				if ((ulong)num3 <= 10uL)
				{
					switch (num3)
					{
					case (FrequencyBand)0L:
						return "ELF";
					case (FrequencyBand)1L:
						return "SLF";
					case (FrequencyBand)2L:
						return "ULF";
					case (FrequencyBand)7L:
						return "VHF";
					case (FrequencyBand)8L:
						return "UHF";
					case (FrequencyBand)9L:
						return "SHF";
					case (FrequencyBand)10L:
						return "EHF";
					case (FrequencyBand)4L:
						goto IL_0223;
					case (FrequencyBand)5L:
						goto IL_022b;
					case (FrequencyBand)6L:
						goto IL_0233;
					case (FrequencyBand)3L:
						goto IL_023b;
					}
				}
				FrequencyBand num4 = band - 4001L;
				if ((ulong)num4 <= 3uL)
				{
					switch (num4)
					{
					case (FrequencyBand)0L:
						break;
					case (FrequencyBand)1L:
						goto IL_022b;
					case (FrequencyBand)2L:
						goto IL_0233;
					case (FrequencyBand)3L:
						goto IL_023b;
					default:
						goto IL_0244;
					}
					goto IL_0223;
				}
				goto IL_0244;
				IL_0295:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return string.Empty;
				IL_022b:
				return "MF";
				IL_0233:
				return "HF";
				IL_0223:
				return "LF";
				IL_0244:
				FrequencyBand num5 = band - 5001L;
				if ((ulong)num5 <= 3uL)
				{
					switch (num5)
					{
					case (FrequencyBand)0L:
						return "GPS";
					case (FrequencyBand)1L:
						return "GLONASS";
					case (FrequencyBand)2L:
						return "BeiDou/COMPASS";
					case (FrequencyBand)3L:
						return "NavIC/IRNSS";
					}
				}
				goto IL_0295;
				IL_023b:
				return "VLF";
			}
		}

		public RadioElectronicFrequency(FrequencyBand theBand)
		{
			Band = theBand;
		}

		public long BandCeiling()
		{
			FrequencyBand band = Band;
			FrequencyBand num = band - 1001L;
			int num2;
			if ((ulong)num > 12uL)
			{
				num2 = 0;
			}
			else
			{
				switch (num)
				{
				case (FrequencyBand)0L:
					return 250000000L;
				case (FrequencyBand)1L:
					return 500000000L;
				case (FrequencyBand)2L:
					return 1000000000L;
				case (FrequencyBand)3L:
					return 2000000000L;
				case (FrequencyBand)4L:
					return 3000000000L;
				case (FrequencyBand)5L:
					return 4000000000L;
				case (FrequencyBand)6L:
					return 6000000000L;
				case (FrequencyBand)7L:
					return 8000000000L;
				case (FrequencyBand)8L:
					return 10000000000L;
				case (FrequencyBand)9L:
					return 20000000000L;
				case (FrequencyBand)10L:
					return 40000000000L;
				case (FrequencyBand)11L:
					return 60000000000L;
				case (FrequencyBand)12L:
					return 100000000000L;
				}
				num2 = 0;
			}
			return num2;
		}

		public long BandBottom()
		{
			FrequencyBand band = Band;
			FrequencyBand num = band - 1001L;
			int num2;
			if ((ulong)num > 12uL)
			{
				num2 = 0;
			}
			else
			{
				switch (num)
				{
				case (FrequencyBand)0L:
					return 1000000L;
				case (FrequencyBand)1L:
					return 250000000L;
				case (FrequencyBand)2L:
					return 500000000L;
				case (FrequencyBand)3L:
					return 1000000000L;
				case (FrequencyBand)4L:
					return 2000000000L;
				case (FrequencyBand)5L:
					return 3000000000L;
				case (FrequencyBand)6L:
					return 4000000000L;
				case (FrequencyBand)7L:
					return 6000000000L;
				case (FrequencyBand)8L:
					return 8000000000L;
				case (FrequencyBand)9L:
					return 10000000000L;
				case (FrequencyBand)10L:
					return 20000000000L;
				case (FrequencyBand)11L:
					return 40000000000L;
				case (FrequencyBand)12L:
					return 60000000000L;
				}
				num2 = 0;
			}
			return num2;
		}

		static RadioElectronicFrequency()
		{
			Class72.smethod_20();
		}
	}

	public float maxRange;

	public float minRange;

	public Sensor_Type Type;

	private Sensor_Role sensor_Role_0;

	public string RoleDescription;

	public int MaxIlluminate;

	public float MaxAltitude_AGL;

	public float MinAltitude_AGL;

	public float MaxAltitude_ASL;

	public float MinAltitude_ASL;

	public float RangeResolution_Nominal;

	public float HeightResolution;

	public float AngleResolution;

	private int int_1;

	public int TimeToNextScan;

	public int TimeToNextScan_Full;

	public _Capabilities Capabilities;

	public _Codes Codes;

	public RadioElectronicFrequency[] SearchFreqs;

	public RadioElectronicFrequency[] IlluminationFreqs;

	private readonly ConcurrentHashSet<Contact> concurrentHashSet_0;

	public ConcurrentHashSet<Weapon> SemiActiveWeaponsGuided;

	private List<string> list_0;

	public Dictionary<string, bool> DetectionChecksThisPulse;

	private bool bool_0;

	private bool? nullable_0;

	public _Coverage Coverage_Illuminate;

	public GlobalVariables.TechGenerationClass TechGeneration;

	[ThreadStatic]
	private RadarModel.TRadar tradar_0;

	[ThreadStatic]
	private RadarModel.TReceiver treceiver_0;

	public bool Hypothetical;

	public float? Boresight;

	public bool IsSensorInLoadout;

	public bool IsSensorInMount;

	public int IsSensorInGroup;

	public bool IsSatelliteSensor;

	public int MastHeight;

	internal short MasqueradeAs;

	private short short_0;

	private short short_1;

	private short short_2;

	private float float_0;

	private long long_0;

	private long long_1;

	private long long_2;

	private long long_3;

	public float RadarHorBeamwidth;

	internal float RadarVertBeamwidth;

	internal float RadarSystemNoiseLevel;

	internal float RadarProcessingGainLoss;

	internal float RadarPeakPower;

	internal float RadarPulseWidth;

	internal float RadarBlindTime;

	internal float RadarPRF;

	internal float RadarHorBeamwidthIlluminate;

	internal float RadarVertBeamwidthIlluminate;

	internal float RadarSystemNoiseIlluminate;

	internal float RadarProcessingGainLossIlluminate;

	internal float RadarPeakPowerIlluminate;

	internal float RadarPulseWidthIlluminate;

	internal float RadarBlindTimeIlluminate;

	internal float float_1;

	internal float ESMSensitivity;

	internal float ESMSystemLoss;

	internal short short_3;

	internal float ECM_Gain;

	internal float ECM_PeakPower;

	internal float ECM_Bandwidth;

	internal float ECM_NumberOfTargets;

	internal float ECM_PokReduction;

	public bool ESM_PreciseEmitterID;

	internal short SonarSourceLevel;

	internal short SonarRecognitionDifferentialActive;

	internal short SonarRecognitionDifferentialPassive;

	public short MineSweepWidth;

	internal short MineSweepMaxSpeed;

	internal float VisualDetectionZoomLevel;

	internal float VisualClassZoomLevel;

	internal float float_2;

	internal float IRClassZoomLevel;

	internal bool IsGNSSJammer;

	internal bool IsOECM;

	public static float SatelliteDefaultMaxElevation;

	public static float SatelliteDefaultMinElevation;

	public float MaxElevationAngle;

	public float MinElevationAngle;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private float float_8;

	private bool bool_1;

	private ConcurrentDictionary<float, float> concurrentDictionary_0;

	internal Lazy<bool> CanPerformVolumeSearch;

	private bool? nullable_1;

	private bool? nullable_2;

	private List<SensorDetectionFeedback> list_1;

	private bool bool_2;

	private HashSet<FrequencyBand> hashSet_0;

	private ThreadLocal<List<Sensor>> threadLocal_0;

	public override ActiveUnit ParentPlatform
	{
		get
		{
			return _ParentPlatform;
		}
		set
		{
			_ParentPlatform = value;
			if (_ParentPlatform != null && _ParentPlatform.IsSatellite)
			{
				CalculateSatelliteSensorElevationAngles();
				IsSatelliteSensor = true;
			}
		}
	}

	public Sensor_Role Role
	{
		get
		{
			return sensor_Role_0;
		}
		set
		{
			sensor_Role_0 = value;
			IsGNSSJammer = sensor_Role_0 == Sensor_Role.GNSS_Jammer;
			IsOECM = sensor_Role_0 == Sensor_Role.ECM_OECM || sensor_Role_0 == Sensor_Role.ECM_OECM_DECM || sensor_Role_0 == Sensor_Role.ECM_COMINT_Jammer;
		}
	}

	public bool VariableMaxRange
	{
		get
		{
			if (Type == Sensor_Type.Radar)
			{
				return (Codes.AESA || Codes.PESA) && !Coverage.Has360Coverage.Value;
			}
			return false;
		}
	}

	public float maxRangeAtAngle
	{
		get
		{
			if (!VariableMaxRange)
			{
				return maxRange;
			}
			if (concurrentDictionary_0 == null)
			{
				concurrentDictionary_0 = new ConcurrentDictionary<float, float>();
			}
			float key = (float)Math.Round(angleOffBoresight, 1);
			if (concurrentDictionary_0.TryGetValue(key, out var value))
			{
				return value;
			}
			value = GetRadarOffBoresightMaxRange(angleOffBoresight);
			concurrentDictionary_0.TryAdd(key, value);
			return value;
		}
	}

	public float GetRadarOffBoresightGainModifier
	{
		get
		{
			if (VariableMaxRange)
			{
				float num = Math.Abs(GetRadarOffBoresightAngleForSensorCoverage(angleOffBoresight));
				if (num > 0f)
				{
					return (float)Math.Pow(Math2.Cosd(num), 1.3);
				}
			}
			return 1f;
		}
	}

	public bool IsScanningOnThisPulse
	{
		get
		{
			if (TimeToNextScan <= 0)
			{
				return true;
			}
			if (concurrentHashSet_0.Count <= 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsScanningOnThisPulse_Full
	{
		get
		{
			if (TimeToNextScan_Full > 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool CanPerformBDA
	{
		get
		{
			switch (Type)
			{
			case Sensor_Type.Visual:
			case Sensor_Type.Infrared:
				return true;
			case Sensor_Type.Radar:
				if (AllowRadar && Codes.Classification)
				{
					return true;
				}
				break;
			}
			int result;
			if (!AllowSonar)
			{
				result = 0;
			}
			else if (!IsSonar)
			{
				result = 0;
			}
			else
			{
				if (!IsActive())
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool CanDetectEmissions
	{
		get
		{
			int result;
			switch (Type)
			{
			case Sensor_Type.PingIntercept:
				result = 1;
				break;
			default:
				return false;
			case Sensor_Type.ESM:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool SearchesInThisFrequency
	{
		get
		{
			RadioElectronicFrequency[] searchFreqs = SearchFreqs;
			int num = 0;
			while (true)
			{
				if (num < searchFreqs.Length)
				{
					if (searchFreqs[num].Band == theBand)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public bool IlluminatesInThisFrequency
	{
		get
		{
			RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
			for (int i = 0; i < illuminationFreqs.Length; i = checked(i + 1))
			{
				if (illuminationFreqs[i].Band == theBand)
				{
					return true;
				}
			}
			return false;
		}
	}

	public float Swath_Total => Swath_Port + Swath_Starboard;

	public float Swath_Port
	{
		get
		{
			float result;
			try
			{
				float num = default(float);
				if (Coverage.PB2 || Coverage.PS1)
				{
					num = (float)((double)maxRange * Math2.Sind(22.5));
				}
				if (Coverage.PB1 || Coverage.PS2)
				{
					num = (float)((double)maxRange * Math2.Sind(45f));
				}
				if (Coverage.PMF2 || Coverage.PMA1)
				{
					num = (float)((double)maxRange * Math2.Sind(67.5));
				}
				if (Coverage.PMF1 || Coverage.PMA2)
				{
					num = maxRange;
				}
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100695", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float Swath_Starboard
	{
		get
		{
			float result;
			try
			{
				float num = default(float);
				if (Coverage.SB2 || Coverage.SS1)
				{
					num = (float)((double)maxRange * Math2.Sind(22.5));
				}
				if (Coverage.SB1 || Coverage.SS2)
				{
					num = (float)((double)maxRange * Math2.Sind(45f));
				}
				if (Coverage.SMF2 || Coverage.SMA1)
				{
					num = (float)((double)maxRange * Math2.Sind(67.5));
				}
				if (Coverage.SMF1 || Coverage.SMA2)
				{
					num = maxRange;
				}
				result = num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100696", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool CanJamThisSensor
	{
		get
		{
			if (TargetSensor.DBID == 0)
			{
				return false;
			}
			switch (TargetSensor.Type)
			{
			case Sensor_Type.Radar:
			case Sensor_Type.SemiActive:
				if (Role != Sensor_Role.ECM_OECM && Role != Sensor_Role.ECM_OECM_DECM)
				{
					return false;
				}
				break;
			case Sensor_Type.HullSonar_ActivePassive:
			case Sensor_Type.HullSonar_ActiveOnly:
			case Sensor_Type.TowedArray_ActiveOnly:
			case Sensor_Type.VDS_ActiveOnly:
			case Sensor_Type.DippingSonar_ActivePassive:
			case Sensor_Type.DippingSonar_ActiveOnly:
				if (Role != Sensor_Role.ECM_AcousticJammer)
				{
					return false;
				}
				break;
			case Sensor_Type.Infrared:
				if (Role != Sensor_Role.IRCM)
				{
					return false;
				}
				break;
			}
			if (!IsOperating)
			{
				return false;
			}
			if (!method_37(TargetSensor))
			{
				return false;
			}
			return true;
		}
	}

	public bool CanJamThisCommDevice
	{
		get
		{
			if (IsOperating)
			{
				int result;
				switch (TargetCommDevice.Type)
				{
				case CommDevice.CommLinkType.Laser_Comm:
				case CommDevice.CommLinkType.Land_Line:
					result = 0;
					break;
				case CommDevice.CommLinkType.OneWay_WireGuidance:
				case CommDevice.CommLinkType.TwoWay_WireGuidance:
					result = 0;
					break;
				case CommDevice.CommLinkType.Swingfire_WeaponLink:
					result = 0;
					break;
				default:
					if (!method_36(TargetCommDevice))
					{
						return false;
					}
					return true;
				case CommDevice.CommLinkType.HOT_WeaponLink:
				case CommDevice.CommLinkType.EFOGM_WeaponLink:
				case CommDevice.CommLinkType.TOW_WeaponLink:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool CanSpoofThisSensor
	{
		get
		{
			int result;
			if (!Information.IsNothing((object)ParentPlatform))
			{
				if (base.Status == _ComponentStatus.Operational)
				{
					if (!method_37(TargetSensor))
					{
						return false;
					}
					Sensor_Type type = TargetSensor.Type;
					if (type > Sensor_Type.HullSonar_ActiveOnly)
					{
						if (type != Sensor_Type.TowedArray_ActiveOnly && type != Sensor_Type.VDS_ActiveOnly && (uint)(type - 5032) > 1u)
						{
							result = 0;
							goto IL_0074;
						}
					}
					else
					{
						if ((uint)(type - 2001) <= 1u)
						{
							return IsDECM || IsOECM;
						}
						if (type == Sensor_Type.Infrared)
						{
							return Role == Sensor_Role.IRCM;
						}
						if ((uint)(type - 5002) > 1u)
						{
							result = 0;
							goto IL_0074;
						}
					}
					return Role == Sensor_Role.ECM_AcousticJammer;
				}
				return false;
			}
			return false;
			IL_0074:
			return (byte)result != 0;
		}
	}

	public long UpperFreq
	{
		get
		{
			if (long_0 > 0L)
			{
				return long_0;
			}
			if (SearchFreqs.Length != 0)
			{
				long num = 0L;
				RadioElectronicFrequency[] searchFreqs = SearchFreqs;
				foreach (RadioElectronicFrequency radioElectronicFrequency in searchFreqs)
				{
					if (radioElectronicFrequency.BandCeiling() > num)
					{
						num = radioElectronicFrequency.BandCeiling();
					}
				}
				return num;
			}
			return 0L;
		}
	}

	public long LowerFreq
	{
		get
		{
			if (long_1 <= 0L)
			{
				if (SearchFreqs.Length == 0)
				{
					return 0L;
				}
				long num = long.MaxValue;
				RadioElectronicFrequency[] searchFreqs = SearchFreqs;
				foreach (RadioElectronicFrequency radioElectronicFrequency in searchFreqs)
				{
					if (radioElectronicFrequency.BandBottom() < num)
					{
						num = radioElectronicFrequency.BandBottom();
					}
				}
				return num;
			}
			return long_1;
		}
	}

	public long UpperFreqIlluminate
	{
		get
		{
			long result;
			try
			{
				if (long_2 <= 0L)
				{
					if (IlluminationFreqs.Length != 0)
					{
						long num = 0L;
						RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
						foreach (RadioElectronicFrequency radioElectronicFrequency in illuminationFreqs)
						{
							if (radioElectronicFrequency.BandCeiling() > num)
							{
								num = radioElectronicFrequency.BandCeiling();
							}
						}
						result = num;
					}
					else
					{
						result = 0L;
					}
				}
				else
				{
					result = long_2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100698", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public long LowerFreqIlluminate
	{
		get
		{
			long result;
			try
			{
				if (long_3 <= 0L)
				{
					if (IlluminationFreqs.Length == 0)
					{
						result = 0L;
					}
					else
					{
						long num = long.MaxValue;
						RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
						foreach (RadioElectronicFrequency radioElectronicFrequency in illuminationFreqs)
						{
							if (radioElectronicFrequency.BandBottom() < num)
							{
								num = radioElectronicFrequency.BandBottom();
							}
						}
						result = num;
					}
				}
				else
				{
					result = long_3;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100699", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = num2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public ConcurrentHashSet<Contact> TargetsTrackedForFireControl_Readonly => concurrentHashSet_0;

	public bool IsPrecise
	{
		get
		{
			bool result;
			try
			{
				if (IsSonar)
				{
					result = (IsActive() ? true : false);
				}
				else
				{
					RadioElectronicFrequency[] searchFreqs;
					int num2;
					switch (Type)
					{
					case Sensor_Type.Radar:
						if (!IsOTH)
						{
							if (!CanPerformIllumination)
							{
								if (Capabilities.SpaceSearch_ABM)
								{
									int num;
									if (Role != Sensor_Role.Radar_BallisticMissileBattleManagement && Role != Sensor_Role.Radar_BallisticMissileEngagement)
									{
										if (Role != Sensor_Role.Radar_BallisticMissileTracker)
										{
											goto IL_00ab;
										}
										num = 1;
									}
									else
									{
										num = 1;
									}
									result = (byte)num != 0;
									break;
								}
								goto IL_00ab;
							}
							result = true;
							break;
						}
						result = false;
						break;
					case Sensor_Type.Visual:
						result = ((DetectionRange < 2f * VisualClassZoomLevel) ? true : false);
						break;
					case Sensor_Type.Infrared:
						result = (Role == Sensor_Role.Infrared_BMEWS && ParentPlatform.IsSatellite) || ((!Codes.Classification) ? (DetectionRange < 1f * IRClassZoomLevel) : (DetectionRange < 2f * IRClassZoomLevel));
						break;
					default:
						result = RangeResolution_Nominal == 0f || AngleResolution == 0f;
						break;
					case Sensor_Type.PingIntercept:
						result = false;
						break;
					case Sensor_Type.MAD:
						result = false;
						break;
					case Sensor_Type.ESM:
					case Sensor_Type.PCLS:
						{
							result = false;
							break;
						}
						IL_00ab:
						searchFreqs = SearchFreqs;
						num2 = 0;
						while (true)
						{
							if (num2 < searchFreqs.Length)
							{
								FrequencyBand band = searchFreqs[num2].Band;
								if ((ulong)(band - 1003L) > 10uL)
								{
									num2 = checked(num2 + 1);
									continue;
								}
								result = true;
								break;
							}
							result = false;
							break;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100701", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				result = (byte)num3 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool? IsNeutralized
	{
		get
		{
			return nullable_0;
		}
		set
		{
			nullable_0 = value;
		}
	}

	public bool HasActiveModeOnly
	{
		get
		{
			Sensor_Type type = Type;
			int result;
			int result2;
			if (type <= Sensor_Type.LaserRangefinder)
			{
				if (type <= Sensor_Type.ECM)
				{
					if (type != Sensor_Type.Radar && type != Sensor_Type.ECM)
					{
						result = 0;
						goto IL_006c;
					}
				}
				else if (type != Sensor_Type.LaserDesignator && type != Sensor_Type.LaserRangefinder)
				{
					result = 0;
					goto IL_006c;
				}
			}
			else if (type > Sensor_Type.TowedArray_ActiveOnly)
			{
				if (type != Sensor_Type.VDS_ActiveOnly)
				{
					if (type == Sensor_Type.DippingSonar_ActiveOnly)
					{
						result2 = 1;
						goto IL_0070;
					}
					result = 0;
					goto IL_006c;
				}
			}
			else if (type != Sensor_Type.HullSonar_ActiveOnly && type != Sensor_Type.TowedArray_ActiveOnly)
			{
				result = 0;
				goto IL_006c;
			}
			result2 = 1;
			goto IL_0070;
			IL_0070:
			return (byte)result2 != 0;
			IL_006c:
			return (byte)result != 0;
		}
	}

	public int ScanInterval
	{
		get
		{
			if (int_1 < 1)
			{
				int_1 = 1;
			}
			return int_1;
		}
		set
		{
			int_1 = Math.Max(value, 1);
		}
	}

	public bool IsPureIlluminator
	{
		get
		{
			if (!IsMineCountermeasure)
			{
				if (Type == Sensor_Type.MAD)
				{
					return false;
				}
				return SearchFreqs.Count() == 0;
			}
			return false;
		}
	}

	public bool IsContinousTrackingCapable
	{
		get
		{
			if (Codes.ContinuousTrackingCapable || Codes.ContinousTrackingCapable_RadarTracker)
			{
				goto IL_004b;
			}
			int result;
			if (Codes.ContinousTrackingCapable_Visual)
			{
				result = 1;
			}
			else
			{
				if (!Codes.AESA)
				{
					if (!Codes.PESA)
					{
						return false;
					}
					goto IL_004b;
				}
				result = 1;
			}
			goto IL_004c;
			IL_004c:
			return (byte)result != 0;
			IL_004b:
			result = 1;
			goto IL_004c;
		}
	}

	public bool CanTrackThisContact_AAWFireControlGrade
	{
		get
		{
			if (base.Status == _ComponentStatus.Operational)
			{
				if (theContact == null)
				{
					return false;
				}
				if (Type != Sensor_Type.Radar && !Codes.GeneratesAAWFireControl)
				{
					return false;
				}
				if (TargetSlantRange > maxRange)
				{
					return false;
				}
				if (!IsOperating && !ignoreOperatingState)
				{
					return false;
				}
				Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
				bool? LOS_Exists_Radar = null;
				bool? LOS_Exists_RadarSW = null;
				bool? LOS_Exists_Sonar = null;
				bool? LOS_Exists_ESM = null;
				bool? LOS_Exists_ESM_SW = null;
				if (!this.get_IsSuitableForThisTarget(theContact.ActualUnit))
				{
					return false;
				}
				float num = 5f;
				if (IsContinousTrackingCapable)
				{
					num = Math.Max(num, ScanInterval);
				}
				Sensor_Type type = Type;
				int result;
				if (type == Sensor_Type.Radar)
				{
					bool num2 = this.get_IsPrecise(TargetSlantRange) && ParentPlatform.Sensory.HasLocalTrackOnThisContact(theContact, num, Sensor_Type.Radar);
					bool flag = ignoreTrackingState && this.get_IsPrecise(TargetSlantRange) && TargetIsWithinCoverageArc(theContact);
					if (num2 || flag)
					{
						return true;
					}
					result = 0;
				}
				else
				{
					if (!ignoreTrackingState && !ParentPlatform.Sensory.HasLocalTrackOnThisContact(theContact, num, Type))
					{
						return false;
					}
					ActiveUnit parentPlatform = ParentPlatform;
					ActiveUnit actualUnit = theContact.ActualUnit;
					List<Geopoint_Struct> UncertaintyArea = null;
					Dictionary<int, EmissionContainer> DetectedEmissions = null;
					if (CanDetectTarget(DetectionAttemptType.WeaponGuidance, parentPlatform, actualUnit, ref UncertaintyArea, TargetSlantRange, ref DetectedEmissions, null, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
					{
						return true;
					}
					result = 0;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool IsFireControlRadar
	{
		get
		{
			if (Type != Sensor_Type.Radar)
			{
				return false;
			}
			Sensor_Role sensor_Role = sensor_Role_0;
			if (sensor_Role <= Sensor_Role.FCR_SurfToAir_SurfToSurf_SR)
			{
				Sensor_Role num = sensor_Role - 2111L;
				if ((ulong)num <= 22uL)
				{
					switch (num)
					{
					case (Sensor_Role)0L:
					case (Sensor_Role)1L:
					case (Sensor_Role)2L:
						return true;
					case (Sensor_Role)10L:
					case (Sensor_Role)11L:
					case (Sensor_Role)12L:
						return true;
					case (Sensor_Role)13L:
					case (Sensor_Role)14L:
					case (Sensor_Role)15L:
						return true;
					case (Sensor_Role)3L:
					case (Sensor_Role)4L:
					case (Sensor_Role)5L:
					case (Sensor_Role)6L:
					case (Sensor_Role)7L:
					case (Sensor_Role)8L:
					case (Sensor_Role)9L:
					case (Sensor_Role)16L:
					case (Sensor_Role)17L:
					case (Sensor_Role)18L:
					case (Sensor_Role)19L:
						goto IL_00cc;
					case (Sensor_Role)20L:
					case (Sensor_Role)21L:
					case (Sensor_Role)22L:
						return true;
					}
				}
				if ((ulong)(sensor_Role - 2141L) <= 2uL)
				{
					return true;
				}
				goto IL_00cc;
			}
			int result;
			int result2;
			if ((ulong)(sensor_Role - 2151L) > 1uL)
			{
				if (sensor_Role != Sensor_Role.FCR_SurfToSurf_Torpedo)
				{
					if (sensor_Role != Sensor_Role.FCR_GunOnly)
					{
						result = 0;
						goto IL_0102;
					}
					return true;
				}
				result2 = 1;
			}
			else
			{
				result2 = 1;
			}
			return (byte)result2 != 0;
			IL_0102:
			return (byte)result != 0;
			IL_00cc:
			result = 0;
			goto IL_0102;
		}
	}

	public bool IsGroundBasedFireControlRadar
	{
		get
		{
			Sensor_Type type = Type;
			int result;
			if (type == Sensor_Type.Radar)
			{
				if (IsPureIlluminator)
				{
					return false;
				}
				Sensor_Role sensor_Role = sensor_Role_0;
				if ((ulong)(sensor_Role - 2101L) <= 3uL)
				{
					goto IL_00d1;
				}
				Sensor_Role num = sensor_Role - 2121L;
				if ((ulong)num <= 22uL)
				{
					switch (num)
					{
					case (Sensor_Role)6L:
					case (Sensor_Role)7L:
					case (Sensor_Role)8L:
					case (Sensor_Role)9L:
					case (Sensor_Role)13L:
					case (Sensor_Role)14L:
					case (Sensor_Role)15L:
					case (Sensor_Role)16L:
					case (Sensor_Role)17L:
					case (Sensor_Role)18L:
					case (Sensor_Role)19L:
						goto IL_00cd;
					case (Sensor_Role)0L:
					case (Sensor_Role)1L:
					case (Sensor_Role)2L:
					case (Sensor_Role)3L:
					case (Sensor_Role)4L:
					case (Sensor_Role)5L:
					case (Sensor_Role)10L:
					case (Sensor_Role)11L:
					case (Sensor_Role)12L:
					case (Sensor_Role)20L:
					case (Sensor_Role)21L:
					case (Sensor_Role)22L:
						goto IL_00d1;
					}
				}
				if (sensor_Role != Sensor_Role.FCR_GunOnly)
				{
					goto IL_00cd;
				}
				result = 1;
				goto IL_00d2;
			}
			return false;
			IL_00d2:
			return (byte)result != 0;
			IL_00cd:
			return false;
			IL_00d1:
			result = 1;
			goto IL_00d2;
		}
	}

	public bool IsGroundBasedAirSearchRadar
	{
		get
		{
			Sensor_Type type = Type;
			if (type == Sensor_Type.Radar)
			{
				if (!IsPureIlluminator)
				{
					Sensor_Role sensor_Role = sensor_Role_0;
					if ((ulong)(sensor_Role - 2001L) > 5uL && (ulong)(sensor_Role - 2011L) > 8uL)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsGroundBasedOECM
	{
		get
		{
			Sensor_Type type = Type;
			if (type == Sensor_Type.ECM)
			{
				int result;
				switch (Role)
				{
				case Sensor_Role.ECM_OECM_DECM:
					result = 1;
					break;
				default:
					return false;
				case Sensor_Role.ECM_OECM:
					result = 1;
					break;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool IsHeightFinder
	{
		get
		{
			Sensor_Role role = Role;
			if ((ulong)(role - 2017L) <= 2uL)
			{
				return true;
			}
			return false;
		}
	}

	public bool CanPerformIllumination
	{
		get
		{
			if (MaxIlluminate != 0)
			{
				int result;
				if (IlluminationFreqs.Count() != 0)
				{
					result = 1;
				}
				else if (long_2 == 0L)
				{
					if (long_3 == 0L)
					{
						return false;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public bool CanBeActive
	{
		get
		{
			if (!IsMineCountermeasure)
			{
				if (Role == Sensor_Role.ECM_DECM)
				{
					return false;
				}
				if (Role == Sensor_Role.IRCM)
				{
					return false;
				}
				if (Role == Sensor_Role.LIDAR_AIRBORNE_MINE_DETECTION)
				{
					return true;
				}
				return Misc.HasActiveMode(Type);
			}
			return true;
		}
	}

	public bool CanSweepThisMine
	{
		get
		{
			bool result = false;
			if (!IsMineCountermeasure)
			{
				return false;
			}
			switch (Type)
			{
			case Sensor_Type.MineNeutralization_DiverExplosiveCharge:
				result = true;
				break;
			case Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal:
				result = true;
				break;
			case Sensor_Type.MineNeutralization_MooredMineCableCutter:
				result = theMine.Type == Weapon._WeaponType.MooredMine || theMine.Type == Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_TwoShipMagneticInfluence:
				result = theMine.Type != Weapon._WeaponType.MooredMine && theMine.Type != Weapon._WeaponType.FloatingMine && theMine.Type != Weapon._WeaponType.DriftingMine && theMine.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MechanicalCableCutter:
				result = theMine.Type == Weapon._WeaponType.MooredMine || theMine.Type == Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MagneticInfluence:
				result = theMine.Type != Weapon._WeaponType.MooredMine && theMine.Type != Weapon._WeaponType.FloatingMine && theMine.Type != Weapon._WeaponType.DriftingMine && theMine.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_AcousticInfluence:
				result = theMine.Type != Weapon._WeaponType.MooredMine && theMine.Type != Weapon._WeaponType.FloatingMine && theMine.Type != Weapon._WeaponType.DriftingMine && theMine.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MultiInfluence:
				result = theMine.Type != Weapon._WeaponType.MooredMine && theMine.Type != Weapon._WeaponType.FloatingMine && theMine.Type != Weapon._WeaponType.DriftingMine && theMine.Type != Weapon._WeaponType.DummyMine;
				break;
			}
			if (ParentPlatform.IsWeapon & (ParentPlatform.SubType == 4101) & (theMine.Type == Weapon._WeaponType.FloatingMine || theMine.Type == Weapon._WeaponType.DriftingMine))
			{
				result = true;
			}
			return result;
		}
	}

	public bool CanTriggerThisMine
	{
		get
		{
			bool result = false;
			if (IsMineCountermeasure)
			{
				switch (Type)
				{
				case Sensor_Type.MineNeutralization_DiverExplosiveCharge:
					result = true;
					break;
				case Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal:
					result = true;
					break;
				case Sensor_Type.MineSweep_AcousticInfluence:
				case Sensor_Type.MineSweep_MultiInfluence:
					result = theMine.Flags.Mine_PassiveBroadBandAcousticFuze || theMine.Flags.Mine_PassiveNarrowBandAcousticFuze;
					break;
				case Sensor_Type.MineSweep_MagneticInfluence:
				case Sensor_Type.MineSweep_TwoShipMagneticInfluence:
					result = theMine.Flags.Mine_SimpleMagneticFuze || theMine.Flags.Mine_TotalFieldMagnetometerFuze;
					break;
				}
				if (ParentPlatform.IsWeapon & (ParentPlatform.SubType == 4101) & (theMine.Type == Weapon._WeaponType.FloatingMine || theMine.Type == Weapon._WeaponType.DriftingMine))
				{
					result = true;
				}
				return result;
			}
			return false;
		}
	}

	public float ProbabilityToSweepThisMine => Type switch
	{
		Sensor_Type.MineNeutralization_DiverExplosiveCharge => 0.8f, 
		Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal => 0.6f, 
		Sensor_Type.MineNeutralization_MooredMineCableCutter => 0.4f, 
		Sensor_Type.MineSweep_TwoShipMagneticInfluence => 0.3f, 
		Sensor_Type.MineSweep_MechanicalCableCutter => 0.4f, 
		Sensor_Type.MineSweep_MagneticInfluence => 0.3f, 
		Sensor_Type.MineSweep_AcousticInfluence => 0.3f, 
		Sensor_Type.MineSweep_MultiInfluence => 0.6f, 
		_ => 0f, 
	};

	public Geopoint_Struct[] MineSweepCoverageArea
	{
		get
		{
			Geopoint_Struct[] result;
			try
			{
				if (IsMineCountermeasure)
				{
					if (IsActive())
					{
						if (TimeToNextScan > 0)
						{
							result = null;
						}
						else
						{
							double num = (double)MineSweepWidth / 1852.0;
							float num2 = Math2.NormalizeBearing(ParentPlatform.CurrentHeading + 180f);
							Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct4 = default(Geopoint_Struct);
							float distance_NM = 0.08099355f;
							Geopoint_Struct[] array2;
							if (!ParentPlatform.IsShip && !ParentPlatform.IsSubmarine)
							{
								Geopoint_Struct[] array = new Geopoint_Struct[4];
								Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
								Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)(num / 2.0), Math2.NormalizeBearing(num2 - 90f));
								Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, (float)(num / 2.0), Math2.NormalizeBearing(num2 + 90f));
								array[0] = new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null));
								array[1] = geopoint_Struct3;
								array[2] = geopoint_Struct2;
								array[3] = geopoint_Struct;
								array2 = array;
							}
							else
							{
								Sensor_Type type = Type;
								if (type == Sensor_Type.MineSweep_MechanicalCableCutter)
								{
									Geopoint_Struct[] array3 = new Geopoint_Struct[3];
									Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
									Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)num, Math2.NormalizeBearing(num2 + 90f));
									Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct4.Longitude, ref geopoint_Struct4.Latitude, distance_NM, num2);
									array3[0] = geopoint_Struct4;
									array3[1] = geopoint_Struct2;
									array3[2] = geopoint_Struct3;
									array2 = array3;
								}
								else
								{
									Geopoint_Struct[] array4 = new Geopoint_Struct[4];
									Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
									Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)(num / 2.0), Math2.NormalizeBearing(num2 - 90f));
									Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, (float)(num / 2.0), Math2.NormalizeBearing(num2 + 90f));
									Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct4.Longitude, ref geopoint_Struct4.Latitude, distance_NM, num2);
									array4[0] = geopoint_Struct4;
									array4[1] = geopoint_Struct3;
									array4[2] = geopoint_Struct2;
									array4[3] = geopoint_Struct;
									array2 = array4;
								}
							}
							result = array2;
						}
					}
					else
					{
						result = null;
					}
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100702", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsSuitableForThisTargetType
	{
		get
		{
			if (Type == Sensor_Type.ESM)
			{
				return true;
			}
			if (Type == Sensor_Type.PingIntercept)
			{
				return true;
			}
			int result2;
			switch (theTargetType)
			{
			default:
				result2 = 0;
				goto IL_00d1;
			case GlobalVariables.ActiveUnitType.Aircraft:
				return Capabilities.AirSearch;
			case GlobalVariables.ActiveUnitType.Ship:
				return Capabilities.SurfaceSearch;
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				int result;
				if (Role != Sensor_Role.TASSActiveOnlyTowedArraySonarSystem)
				{
					if (Role != Sensor_Role.TASSPassiveTorpedoWarningTowedArraySonarSystem)
					{
						return Capabilities.SubSearch;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			case GlobalVariables.ActiveUnitType.Facility:
				return Capabilities.LandSearch_Fixed || Capabilities.LandSearch_Mobile;
			case GlobalVariables.ActiveUnitType.Aimpoint:
				result2 = 0;
				goto IL_00d1;
			case GlobalVariables.ActiveUnitType.Weapon:
				return Capabilities.AirSearch || Capabilities.SpaceSearch_ABM || Capabilities.C_RAM;
			case GlobalVariables.ActiveUnitType.Satellite:
				return Capabilities.SpaceSearch_ABM;
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
				{
					return Capabilities.LandSearch_Mobile;
				}
				IL_00d1:
				return (byte)result2 != 0;
			}
		}
	}

	public bool IsSuitableForThisTargetType_WeaponSensor
	{
		get
		{
			bool result;
			try
			{
				if (Type != Sensor_Type.ESM)
				{
					goto IL_0052;
				}
				if (!theParentWeapon.ValidTargets.Radar)
				{
					goto IL_0043;
				}
				if (theParentWeapon.MaxAirRange > 0f)
				{
					result = true;
				}
				else
				{
					if (!(theParentWeapon.MaxSurfaceRange > 0f))
					{
						goto IL_0043;
					}
					result = true;
				}
				goto end_IL_0001;
				IL_0052:
				if (Type == Sensor_Type.PingIntercept)
				{
					result = true;
				}
				else
				{
					int num;
					switch (theTargetType)
					{
					default:
						num = 0;
						goto IL_018f;
					case GlobalVariables.ActiveUnitType.Ship:
					{
						int num2;
						if (IsSonar)
						{
							num2 = 1;
						}
						else
						{
							if (!IsPingIntercept)
							{
								if (theParentWeapon.ValidTargets.SurfaceVessel)
								{
									result = Capabilities.SurfaceSearch;
									break;
								}
								goto case GlobalVariables.ActiveUnitType.Aimpoint;
							}
							num2 = 1;
						}
						result = (byte)num2 != 0;
						break;
					}
					case GlobalVariables.ActiveUnitType.Submarine:
						if (!theParentWeapon.ValidTargets.Submarine)
						{
							num = 0;
							goto IL_018f;
						}
						result = Capabilities.SubSearch;
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						if (!theParentWeapon.ValidTargets.LandStructure_Hard && !theParentWeapon.ValidTargets.LandStructure_Soft && !theParentWeapon.ValidTargets.MobileTarget_Hard && !theParentWeapon.ValidTargets.MobileTarget_Soft)
						{
							num = 0;
							goto IL_018f;
						}
						result = Capabilities.LandSearch_Fixed || Capabilities.LandSearch_Mobile;
						break;
					case GlobalVariables.ActiveUnitType.Aircraft:
					case GlobalVariables.ActiveUnitType.Weapon:
						if (theParentWeapon.ValidTargets.Aircraft || theParentWeapon.ValidTargets.Helicopter || theParentWeapon.ValidTargets.Missile)
						{
							result = Capabilities.AirSearch;
							break;
						}
						goto case GlobalVariables.ActiveUnitType.Aimpoint;
					case GlobalVariables.ActiveUnitType.Aimpoint:
						num = 0;
						goto IL_018f;
					case GlobalVariables.ActiveUnitType.Satellite:
						{
							if (!theParentWeapon.ValidTargets.Satellite)
							{
								num = 0;
								goto IL_018f;
							}
							result = Capabilities.SpaceSearch_ABM;
							break;
						}
						IL_018f:
						result = (byte)num != 0;
						break;
					}
				}
				goto end_IL_0001;
				IL_0043:
				if (!theParentWeapon.IsDecoy)
				{
					goto IL_0052;
				}
				result = true;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100703", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (!Debugger.IsAttached)
				{
					num3 = 0;
				}
				else
				{
					Debugger.Break();
					num3 = 0;
				}
				result = (byte)num3 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsSuitableForThisTarget
	{
		get
		{
			bool result;
			if (theTarget != null)
			{
				try
				{
					int num;
					int num2;
					if (Type == Sensor_Type.ESM)
					{
						if (theTarget.IsSubmarine)
						{
							num = 1;
							goto IL_0056;
						}
						if (theTarget.IsFacility)
						{
							num = 1;
							goto IL_0056;
						}
						if (!theTarget.HasEmittingSensors)
						{
							num2 = 0;
							goto IL_004e;
						}
						if (theTarget.IsUnderground)
						{
							num2 = 0;
							goto IL_004e;
						}
						if (theTarget.IsUnderwater)
						{
							num2 = 0;
							goto IL_004e;
						}
						result = true;
					}
					else if (Role == Sensor_Role.IR_MAWS && theTarget.IsWeapon)
					{
						result = true;
					}
					else
					{
						if (Type != Sensor_Type.PingIntercept)
						{
							goto IL_00e5;
						}
						if (!theTarget.IsSubmarine && !theTarget.IsShip)
						{
							if (!theTarget.IsWeapon)
							{
								goto IL_00cd;
							}
							if (!theTarget.IsTorpedo)
							{
								if (((Weapon)theTarget).Type != Weapon._WeaponType.Sonobuoy)
								{
									goto IL_00cd;
								}
								result = true;
							}
							else
							{
								result = true;
							}
						}
						else
						{
							result = true;
						}
					}
					goto end_IL_0007;
					IL_033e:
					int num3;
					result = (byte)num3 != 0;
					goto end_IL_0007;
					IL_00e5:
					if (theTarget.IsAerospaceUnit && Type == Sensor_Type.Radar && !TargetIsWithinRadarVelocityFilter(theTarget))
					{
						result = false;
					}
					else if (theTarget.IsAircraft)
					{
						result = (((Aircraft)theTarget).IsLighterThanAir ? (this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship) || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility)) : this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft));
					}
					else if (theTarget.IsShip)
					{
						result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship);
					}
					else if (theTarget.IsSubmarine)
					{
						result = ((((Submarine)theTarget).IsSurfaced || (Capabilities.PeriscopeSearch && ((Submarine)theTarget).IsAtPeriscopeDepth)) && this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship)) || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine);
					}
					else if (theTarget.IsFacility)
					{
						result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility) && (((Facility)theTarget).RepresentsMobileGroundUnit ? Capabilities.LandSearch_Mobile : Capabilities.LandSearch_Fixed);
					}
					else if (theTarget.IsMobileGroundUnit)
					{
						result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Vehicle) || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Personnel);
					}
					else
					{
						if (!theTarget.IsWeapon)
						{
							num3 = 0;
							goto IL_033e;
						}
						Weapon._WeaponType type = ((Weapon)theTarget).Type;
						if (type <= Weapon._WeaponType.UAV_Expendable)
						{
							if (type <= Weapon._WeaponType.Rocket)
							{
								switch (type)
								{
								default:
									num3 = 0;
									break;
								case Weapon._WeaponType.Rocket:
									result = ((!((double)((Weapon)theTarget).Diameter >= 0.1)) ? Capabilities.C_RAM : Capabilities.AirSearch);
									goto end_IL_0007;
								case Weapon._WeaponType.GuidedWeapon:
									result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon);
									goto end_IL_0007;
								}
							}
							else
							{
								switch (type)
								{
								default:
									num3 = 0;
									break;
								case Weapon._WeaponType.UAV_Expendable:
									result = Capabilities.AirSearch;
									goto end_IL_0007;
								case Weapon._WeaponType.Decoy_Vehicle:
									if (((Weapon)theTarget).IsMobileDecoy_Air)
									{
										result = Capabilities.AirSearch;
									}
									else if (((Weapon)theTarget).IsMobileDecoy_Surface)
									{
										result = Capabilities.SurfaceSearch;
									}
									else
									{
										if (!((Weapon)theTarget).IsMobileDecoy_Sub)
										{
											num3 = 0;
											break;
										}
										result = Capabilities.SubSearch;
									}
									goto end_IL_0007;
								}
							}
							goto IL_033e;
						}
						if (type <= Weapon._WeaponType.BallisticMissile)
						{
							switch (type)
							{
							default:
								num3 = 0;
								break;
							case Weapon._WeaponType.BallisticMissile:
								result = Capabilities.SpaceSearch_ABM || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft);
								goto end_IL_0007;
							case Weapon._WeaponType.DepthCharge:
							case Weapon._WeaponType.Sonobuoy:
							case Weapon._WeaponType.RisingMine:
								num3 = 0;
								break;
							case Weapon._WeaponType.Torpedo:
							case Weapon._WeaponType.BottomMine:
							case Weapon._WeaponType.MooredMine:
							case Weapon._WeaponType.FloatingMine:
							case Weapon._WeaponType.MovingMine:
							case Weapon._WeaponType.DriftingMine:
								result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine);
								goto end_IL_0007;
							}
							goto IL_033e;
						}
						if (type != Weapon._WeaponType.RV && type != Weapon._WeaponType.HGV)
						{
							num3 = 0;
							goto IL_033e;
						}
						result = this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite) || this.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon);
					}
					goto end_IL_0007;
					IL_0056:
					result = (byte)num != 0;
					goto end_IL_0007;
					IL_00cd:
					if (!theTarget.IsUsingDippingSonar())
					{
						goto IL_00e5;
					}
					result = true;
					goto end_IL_0007;
					IL_004e:
					result = (byte)num2 != 0;
					end_IL_0007:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100704", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num4;
					if (!Debugger.IsAttached)
					{
						num4 = 0;
					}
					else
					{
						Debugger.Break();
						num4 = 0;
					}
					result = (byte)num4 != 0;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	public bool IsOperating
	{
		get
		{
			bool result;
			try
			{
				result = ParentPlatform != null && _Status == _ComponentStatus.Operational && ReasonForInoperative.Response == BooleanResponse.ResponseTrue;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100705", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 0;
				}
				else
				{
					Debugger.Break();
					num = 0;
				}
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override (BooleanResponse Response, string ResponseString) ReasonForInoperative
	{
		get
		{
			ActiveUnit parentPlatform = ParentPlatform;
			GlobalVariables.ActiveUnitType unitType = parentPlatform.UnitType;
			(BooleanResponse, string) result;
			if (parentPlatform != null)
			{
				if (!parentPlatform.IsSubmarine)
				{
					goto IL_02b7;
				}
				bool flag = parentPlatform.ParentScen.FeatureCompatibility.get_RevisedSubOptics(parentPlatform.ParentScen.DBConnection);
				if (Operators.CompareString(Name, "Mk1 Eyeball", false) == 0 && flag)
				{
					bool? flag3;
					bool? flag2 = (flag3 = method_3());
					bool? flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : (parentPlatform.ParentScen.IsDBUsedCWDB & flag3));
					if (((!flag4) ?? flag4) == true && !((Submarine)parentPlatform).IsSurfaced)
					{
						result = (BooleanResponse.ResponseFalse, "Submarine must be surfaced for lookouts to be on watch");
						goto IL_0407;
					}
				}
				if (Type != Sensor_Type.ESM)
				{
					goto IL_0140;
				}
				if (!((Submarine)parentPlatform).IsAtPeriscopeDepth && !((Submarine)parentPlatform).IsSurfaced)
				{
					result = (BooleanResponse.ResponseFalse, "Submarine must be at periscope depth or shallower");
				}
				else
				{
					if (!(parentPlatform.CurrentSpeed > 10f) || ((Submarine)parentPlatform).IsSurfaced)
					{
						goto IL_0140;
					}
					result = (BooleanResponse.ResponseFalse, "ESM mast can be used only at 10 knots or slower");
				}
			}
			else
			{
				result = (BooleanResponse.Undefined, "None");
			}
			goto IL_0407;
			IL_0355:
			if ((unitType != GlobalVariables.ActiveUnitType.Ship && unitType != GlobalVariables.ActiveUnitType.Aircraft) || !IsDippingSonar)
			{
				goto IL_03cc;
			}
			if (!parentPlatform.IsAircraft)
			{
				if (!parentPlatform.IsShip || (parentPlatform.IsUsingDippingSonar() && parentPlatform.CurrentSpeed == 0f))
				{
					goto IL_03cc;
				}
				result = (BooleanResponse.ResponseFalse, "Platform is not deploying sensor");
			}
			else
			{
				if (parentPlatform.IsUsingDippingSonar() && parentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 50f && parentPlatform.CurrentSpeed == 0f)
				{
					goto IL_03cc;
				}
				result = (BooleanResponse.ResponseFalse, "Platform is not hovering & deploying sensor");
			}
			goto IL_0407;
			IL_03cc:
			result = ((!HasActiveModeOnly || IsActive()) ? (BooleanResponse.ResponseTrue, "None") : (BooleanResponse.ResponseFalse, "Sensor has only active mode and is not active"));
			goto IL_0407;
			IL_0252:
			if (Type != Sensor_Type.Radar)
			{
				goto IL_02b7;
			}
			if (!((Submarine)parentPlatform).IsAtPeriscopeDepth && !((Submarine)parentPlatform).IsSurfaced)
			{
				result = (BooleanResponse.ResponseFalse, "Submarine must be at periscope depth or shallower");
			}
			else
			{
				if (!(parentPlatform.CurrentSpeed > 10f) || ((Submarine)parentPlatform).IsSurfaced)
				{
					goto IL_02b7;
				}
				result = (BooleanResponse.ResponseFalse, "Radar mast can be used only at 10 knots or slower");
			}
			goto IL_0407;
			IL_01c9:
			if (Type != Sensor_Type.Visual || ((Submarine)parentPlatform).Type == Submarine._SubmarineType.ROV || ((Submarine)parentPlatform).Type == Submarine._SubmarineType.UUV)
			{
				goto IL_0252;
			}
			if (!((Submarine)parentPlatform).IsAtPeriscopeDepth && !((Submarine)parentPlatform).IsSurfaced)
			{
				result = (BooleanResponse.ResponseFalse, "Submarine must be at periscope depth or shallower");
			}
			else
			{
				if (!(parentPlatform.CurrentSpeed > 10f) || ((Submarine)parentPlatform).IsSurfaced)
				{
					goto IL_0252;
				}
				result = (BooleanResponse.ResponseFalse, "Periscope can be used only at 10 knots or slower");
			}
			goto IL_0407;
			IL_0140:
			if (Type != Sensor_Type.Infrared || ((Submarine)parentPlatform).Type == Submarine._SubmarineType.ROV || ((Submarine)parentPlatform).Type == Submarine._SubmarineType.UUV)
			{
				goto IL_01c9;
			}
			if (!((Submarine)parentPlatform).IsAtPeriscopeDepth && !((Submarine)parentPlatform).IsSurfaced)
			{
				result = (BooleanResponse.ResponseFalse, "Submarine must be at periscope depth or shallower");
			}
			else
			{
				if (!(parentPlatform.CurrentSpeed > 10f) || ((Submarine)parentPlatform).IsSurfaced)
				{
					goto IL_01c9;
				}
				result = (BooleanResponse.ResponseFalse, "Periscope can be used only at 10 knots or slower");
			}
			goto IL_0407;
			IL_0407:
			return result;
			IL_02b7:
			if ((unitType != GlobalVariables.ActiveUnitType.Ship && unitType != GlobalVariables.ActiveUnitType.Submarine) || !IsTowedArray)
			{
				goto IL_0355;
			}
			if (parentPlatform.CurrentSpeed > 15f)
			{
				result = (BooleanResponse.ResponseFalse, "Towed array can be used only at 15 knots or slower");
			}
			else
			{
				int num = ((Module_Unit.Unit)parentPlatform).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, parentPlatform.ParentScen);
				if (Role != Sensor_Role.TASSActiveOnlyTowedArraySonarSystem && Role != Sensor_Role.TASSPassiveTorpedoWarningTowedArraySonarSystem)
				{
					if (num <= -150)
					{
						goto IL_0355;
					}
					result = (BooleanResponse.ResponseFalse, "Towed arrays cannot function at shallow depth (<150m)");
				}
				else
				{
					if (num <= -20)
					{
						goto IL_0355;
					}
					result = (BooleanResponse.ResponseFalse, "Torpedo-warning towed arrays cannot function at very shallow depth (<20m)");
				}
			}
			goto IL_0407;
		}
	}

	public bool IsMineCountermeasure
	{
		get
		{
			if (Type > (Sensor_Type)6000)
			{
				return Type < (Sensor_Type)7000;
			}
			return false;
		}
	}

	public bool IsExplosiveMineNeutralizer
	{
		get
		{
			if (Type != Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal)
			{
				return Type == Sensor_Type.MineNeutralization_DiverExplosiveCharge;
			}
			return true;
		}
	}

	public bool IsOTH
	{
		get
		{
			if (!Capabilities.OTH_Backscatter)
			{
				return Capabilities.OTH_SurfaceWave;
			}
			return true;
		}
	}

	public bool IsDippingSonar
	{
		get
		{
			if (Type != Sensor_Type.DippingSonar_ActiveOnly && Type != Sensor_Type.DippingSonar_ActivePassive)
			{
				return Type == Sensor_Type.DippingSonar_PassiveOnly;
			}
			return true;
		}
	}

	public bool IsDECM
	{
		get
		{
			switch (Role)
			{
			default:
				return false;
			case Sensor_Role.IRCM:
				return true;
			case Sensor_Role.ECM_DECM:
			case Sensor_Role.ECM_OECM_DECM:
				return true;
			}
		}
	}

	public bool IsMineHuntingSensor
	{
		get
		{
			if (Capabilities.Mine_Obstacle_Search)
			{
				return true;
			}
			Sensor_Role role = Role;
			int result;
			int result2;
			if (role <= Sensor_Role.HullSonarActiveOnlyMineHuntingASWMortarFireControl)
			{
				if (role == Sensor_Role.LLTV_MineRecon)
				{
					return true;
				}
				if ((ulong)(role - 5097L) > 2uL)
				{
					result = 0;
					goto IL_007f;
				}
			}
			else
			{
				if ((ulong)(role - 5271L) <= 3uL)
				{
					result2 = 1;
					goto IL_0087;
				}
				if (role != Sensor_Role.HelicopterTowedActiveOnlyMineReconnaissanceSonar)
				{
					if (role != Sensor_Role.LIDAR_AIRBORNE_MINE_DETECTION)
					{
						result = 0;
						goto IL_007f;
					}
					return true;
				}
			}
			result2 = 1;
			goto IL_0087;
			IL_007f:
			return (byte)result != 0;
			IL_0087:
			return (byte)result2 != 0;
		}
	}

	public bool IsCommsJammer
	{
		get
		{
			Sensor_Role role = Role;
			if (role == Sensor_Role.ECM_COMINT_Jammer)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsTowedArray
	{
		get
		{
			Sensor_Type type = Type;
			if ((uint)(type - 5011) > 2u)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsSonar
	{
		get
		{
			Sensor_Type type = Type;
			int result;
			int result2;
			if (type > Sensor_Type.TowedArray_ActiveOnly)
			{
				if ((uint)(type - 5021) <= 2u || (uint)(type - 5031) <= 2u)
				{
					goto IL_004c;
				}
				if (type != Sensor_Type.BottomFixedSonar_PassiveOnly)
				{
					result = 0;
					goto IL_0049;
				}
				result2 = 1;
			}
			else
			{
				if ((uint)(type - 5001) > 2u)
				{
					if ((uint)(type - 5011) > 2u)
					{
						result = 0;
						goto IL_0049;
					}
					goto IL_004c;
				}
				result2 = 1;
			}
			goto IL_004d;
			IL_0049:
			return (byte)result != 0;
			IL_004c:
			result2 = 1;
			goto IL_004d;
			IL_004d:
			return (byte)result2 != 0;
		}
	}

	public bool IsPingIntercept
	{
		get
		{
			Sensor_Type type = Type;
			if (type == Sensor_Type.PingIntercept)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsMk1Eyeball => bool_2;

	public HashSet<FrequencyBand> UsedFrequencies
	{
		get
		{
			HashSet<FrequencyBand> hashSet = default(HashSet<FrequencyBand>);
			try
			{
				if (hashSet_0 == null)
				{
					List<FrequencyBand> list = new List<FrequencyBand>();
					list.AddRange(SearchFreqs.Select([SpecialName] (RadioElectronicFrequency theF) => theF.Band));
					list.AddRange(IlluminationFreqs.Select([SpecialName] (RadioElectronicFrequency theF) => theF.Band));
					hashSet_0 = new HashSet<FrequencyBand>(list);
				}
				hashSet = hashSet_0;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				hashSet = hashSet;
				ProjectData.ClearProjectError();
			}
			return hashSet;
		}
	}

	static Sensor()
	{
		Class72.smethod_20();
		SatelliteDefaultMaxElevation = 0f;
		SatelliteDefaultMinElevation = -90f;
	}

	internal int FOVWidth_Tracking()
	{
		if (Codes.AESA)
		{
			return 90;
		}
		if (!Codes.PESA)
		{
			return 15;
		}
		return 60;
	}

	internal bool HasTrackingFOVRestriction()
	{
		return Type switch
		{
			Sensor_Type.Microwave_Emitter => MaxIlluminate > 1, 
			Sensor_Type.Radar => MaxIlluminate > 1 && TargetsTrackedForFireControl_Readonly.Count > 0, 
			_ => false, 
		};
	}

	private float method_1(float float_9)
	{
		return (float)Math.Pow(Math.Abs(Math2.Cosd(float_9)), 0.65);
	}

	internal float GetRadarOffBoresightMaxRange(float angleOffBoresight)
	{
		float result = maxRange;
		float num = Math.Abs(GetRadarOffBoresightAngleForSensorCoverage(angleOffBoresight));
		if (num > 0f)
		{
			result = maxRange * method_1(num);
		}
		return result;
	}

	internal float GetRadarOffBoresightAngleForSensorCoverage(float parentAngleOffBoresight)
	{
		float num = parentAngleOffBoresight;
		num = Math2.NormalizeBearing(parentAngleOffBoresight);
		float num2 = 0f;
		float startAngle = 0f;
		float endAngle = 0f;
		float num3 = 0f;
		if (GetCoverageArc(num, ref startAngle, ref endAngle))
		{
			if (endAngle > startAngle)
			{
				num3 = (startAngle + endAngle) / 2f;
				num -= num3;
				num2 = (endAngle - startAngle - 120f) / 2f;
			}
			else
			{
				num3 = (startAngle + (360f + endAngle)) / 2f;
				num2 = (360f + endAngle - startAngle - 120f) / 2f;
				num = ((!(num < startAngle)) ? (num - num3) : (360f + num - num3));
			}
			if (num == 0f)
			{
				return 0f;
			}
			if (num > 180f)
			{
				num -= 360f;
			}
			if (num2 > 0f)
			{
				float num4 = Math.Abs(num) - num2;
				num = ((num4 <= 0f) ? 0f : ((!(num4 > 180f)) ? num4 : (num4 - 360f)));
			}
			else if (num > 180f)
			{
				num -= 360f;
			}
			return num;
		}
		return 0f;
	}

	internal float GetRadarOffBoresightEffectiveRange(float actualRange, float angleOffBoresight)
	{
		if ((Codes.AESA || Codes.PESA) && !Coverage.Has360Coverage.Value && GetRadarOffBoresightAngleForSensorCoverage(angleOffBoresight) != 0f)
		{
			float radarOffBoresightMaxRange = GetRadarOffBoresightMaxRange(angleOffBoresight);
			return actualRange / (radarOffBoresightMaxRange / maxRange);
		}
		return actualRange;
	}

	public bool IsWithinOffZenithAngleLimits(float OffZenithAngle)
	{
		if (!IsSatelliteSensor)
		{
			return true;
		}
		return OffZenithAngle <= 90f + MaxElevationAngle && OffZenithAngle >= 90f + MinElevationAngle;
	}

	public void CalculateSatelliteSensorElevationAngles()
	{
		MaxElevationAngle = SatelliteDefaultMaxElevation;
		MinElevationAngle = SatelliteDefaultMinElevation;
	}

	public static bool CanTrackAllTargetsAtThisBoresightBearing(Sensor theSensor, int theBearing, List<Module_Unit.Unit> theTargets)
	{
		foreach (Module_Unit.Unit theTarget in theTargets)
		{
			float newBearing = Module_Unit.BearingToUnit_True(theSensor.ParentPlatform, theTarget);
			if (!((double)Math.Abs(MathFunctions.AngularDifference(theBearing, newBearing)) <= (double)theSensor.FOVWidth_Tracking() / 2.0))
			{
				return false;
			}
		}
		return true;
	}

	public void CalculateAntennaEmissionLimitAngles(float HalfBeamVerticalWidth)
	{
		float num = MaxElevationAngle;
		float num2 = MinElevationAngle;
		if (Codes.PESA || Codes.AESA)
		{
			num = 60f;
			num2 = -60f;
		}
		if (Capabilities.SpaceSearch_ABM)
		{
			num = 90f;
		}
		num += HalfBeamVerticalWidth;
		num2 -= HalfBeamVerticalWidth;
		if (num >= 90f)
		{
			float_3 = 1f;
		}
		else
		{
			float_3 = (float)Math.Sin((double)num * 0.0174532925199433);
		}
		if (num2 < -90f)
		{
			float_4 = -1f;
		}
		else
		{
			float_4 = (float)Math.Sin((double)num2 * 0.0174532925199433);
		}
	}

	public void CalculateRadarResolutionCell()
	{
		float halfBeamVerticalWidth;
		if (!IsPureIlluminator)
		{
			float_5 = 0.081f * RadarPulseWidth;
			float_6 = RadarVertBeamwidth / 57f / 2f;
			float_7 = RadarHorBeamwidth / 2f;
			halfBeamVerticalWidth = RadarVertBeamwidth / 2f;
		}
		else
		{
			float_5 = 0.081f * RadarPulseWidthIlluminate;
			float_6 = RadarVertBeamwidthIlluminate / 57f / 2f;
			float_7 = RadarHorBeamwidthIlluminate / 2f;
			halfBeamVerticalWidth = RadarVertBeamwidthIlluminate / 2f;
		}
		float_8 = float_7 / 57f;
		CalculateAntennaEmissionLimitAngles(halfBeamVerticalWidth);
	}

	public void ReCalculateResolutionCell()
	{
		Sensor_Type type = Type;
		if (type == Sensor_Type.Radar && !IsPureIlluminator && CanPerformIllumination)
		{
			float halfBeamVerticalWidth;
			if (TargetsTrackedForFireControl_Readonly.Count > 0)
			{
				float_5 = 0.081f * RadarPulseWidthIlluminate;
				float_6 = RadarVertBeamwidthIlluminate / 57f / 2f;
				float_7 = RadarHorBeamwidthIlluminate / 2f;
				halfBeamVerticalWidth = RadarVertBeamwidthIlluminate / 2f;
			}
			else
			{
				float_5 = 0.081f * RadarPulseWidth;
				float_6 = RadarVertBeamwidth / 57f / 2f;
				float_7 = RadarHorBeamwidth / 2f;
				halfBeamVerticalWidth = RadarVertBeamwidth / 2f;
			}
			float_8 = float_7 / 57f;
			CalculateAntennaEmissionLimitAngles(halfBeamVerticalWidth);
		}
	}

	internal bool HasResolutionCell()
	{
		return float_5 > 0f;
	}

	internal bool InSameResolutionCell(ActiveUnit detectingUnit, ActiveUnit target, float targetRange, ActiveUnit possibleMaskingTarget, float possibleMaskingTargetRange)
	{
		if (!HasResolutionCell())
		{
			return false;
		}
		if (Math.Abs(targetRange - possibleMaskingTargetRange) > float_5)
		{
			return false;
		}
		if ((double)Math.Abs(possibleMaskingTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) > (double)(float_6 * targetRange) * 1852.0)
		{
			return false;
		}
		if (possibleMaskingTarget.RangeToUnit_Horiz(target, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) > float_8 * targetRange)
		{
			return false;
		}
		float originalBearing = Module_Unit.BearingToUnit_True(detectingUnit, target);
		float newBearing = Module_Unit.BearingToUnit_True(detectingUnit, possibleMaskingTarget);
		if (Math.Abs(MathFunctions.AngularDifference(originalBearing, newBearing)) > float_7)
		{
			return false;
		}
		return true;
	}

	internal bool MaskedByCloserTargetInResolutionCell(ActiveUnit theTarget, ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>)> detectionlist)
	{
		if (HasResolutionCell())
		{
			float num = ParentPlatform.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			foreach (var item2 in detectionlist)
			{
				if (item2.Item2 != theTarget && item2.Item3.Contains(this))
				{
					float item = item2.Item4;
					if (item <= num && InSameResolutionCell(ParentPlatform, theTarget, num, item2.Item2, item))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<Sensor>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</Sensor>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			if (_Status != _ComponentStatus.Operational)
			{
				utf16ValueStringBuilder.Append("<St>");
				byte status = (byte)_Status;
				utf16ValueStringBuilder.Append(status.ToString());
				utf16ValueStringBuilder.Append("</St>");
			}
			utf16ValueStringBuilder.Append("<DamageSeverity>");
			utf16ValueStringBuilder.Append(((byte)base.DamageSeverity).ToString());
			utf16ValueStringBuilder.Append("</DamageSeverity>");
			utf16ValueStringBuilder.Append("<Name>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
			utf16ValueStringBuilder.Append("</Name>");
			if (Coverage.HasDefinedArcs)
			{
				utf16ValueStringBuilder.Append(Coverage.ToXML(IsIlluminate: false));
			}
			if (Coverage_Illuminate.HasDefinedArcs)
			{
				utf16ValueStringBuilder.Append(Coverage_Illuminate.ToXML(IsIlluminate: true));
			}
			if (concurrentHashSet_0.Count > 0)
			{
				utf16ValueStringBuilder.Append("<TTFFC>");
				foreach (Contact item in concurrentHashSet_0)
				{
					if (item != null)
					{
						utf16ValueStringBuilder.Append("<ID>");
						utf16ValueStringBuilder.Append(item.ObjectID);
						utf16ValueStringBuilder.Append("</ID>");
					}
				}
				utf16ValueStringBuilder.Append("</TTFFC>");
			}
			if (SemiActiveWeaponsGuided.Count > 0)
			{
				utf16ValueStringBuilder.Append("<SAWG>");
				List<Weapon> list = SemiActiveWeaponsGuided.ToList();
				foreach (Weapon item2 in list)
				{
					if (item2 != null)
					{
						utf16ValueStringBuilder.Append("<ID>");
						utf16ValueStringBuilder.Append(item2.ObjectID);
						utf16ValueStringBuilder.Append("</ID>");
					}
				}
				utf16ValueStringBuilder.Append("</SAWG>");
			}
			if (TimeToNextScan != 0)
			{
				utf16ValueStringBuilder.Append("<TTNS>");
				utf16ValueStringBuilder.Append(TimeToNextScan);
				utf16ValueStringBuilder.Append("</TTNS>");
			}
			if (IsActive())
			{
				utf16ValueStringBuilder.Append("<IsA>True</IsA>");
			}
			if (Boresight.HasValue)
			{
				utf16ValueStringBuilder.Append("<Boresight>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(Boresight.Value));
				utf16ValueStringBuilder.Append("</Boresight>");
			}
			if (IsSensorInGroup > 0)
			{
				utf16ValueStringBuilder.Append("<SensorGroup>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(IsSensorInGroup));
				utf16ValueStringBuilder.Append("</SensorGroup>");
			}
			if (IsSatelliteSensor)
			{
				if (MaxElevationAngle != SatelliteDefaultMaxElevation)
				{
					utf16ValueStringBuilder.Append("<MaxElevationAngle>");
					utf16ValueStringBuilder.Append(MaxElevationAngle);
					utf16ValueStringBuilder.Append("</MaxElevationAngle>");
				}
				if (MinElevationAngle != SatelliteDefaultMinElevation)
				{
					utf16ValueStringBuilder.Append("<MinElevationAngle>");
					utf16ValueStringBuilder.Append(MinElevationAngle);
					utf16ValueStringBuilder.Append("</MinElevationAngle>");
				}
			}
			utf16ValueStringBuilder.Append("</Sensor>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100693", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Sensor()
		: base(null)
	{
		Capabilities = default(_Capabilities);
		Codes = default(_Codes);
		SearchFreqs = new RadioElectronicFrequency[0];
		IlluminationFreqs = new RadioElectronicFrequency[0];
		concurrentHashSet_0 = new ConcurrentHashSet<Contact>();
		SemiActiveWeaponsGuided = new ConcurrentHashSet<Weapon>();
		list_0 = new List<string>();
		Coverage_Illuminate = new _Coverage();
		IsSensorInLoadout = false;
		IsSensorInMount = false;
		IsSensorInGroup = -1;
		IsSatelliteSensor = false;
		MastHeight = 0;
		IsGNSSJammer = false;
		IsOECM = false;
		MaxElevationAngle = 30f;
		MinElevationAngle = -30f;
		float_3 = 0.5f;
		float_4 = 0.5f;
		bool_1 = true;
		CanPerformVolumeSearch = new Lazy<bool>(method_2);
		nullable_1 = null;
		nullable_2 = null;
		threadLocal_0 = new ThreadLocal<List<Sensor>>();
		Coverage = new _Coverage();
	}

	public override bool TargetIsWithinCoverageArc(Module_Unit.Unit theTarget, float? CustomParentHeading = null)
	{
		bool result = default(bool);
		try
		{
			if (HasTrackingFOVRestriction() && Boresight.HasValue)
			{
				float newBearing = Module_Unit.BearingToUnit_True(ParentPlatform, theTarget);
				if ((double)Math.Abs(MathFunctions.AngularDifference(Boresight.Value, newBearing)) > (double)FOVWidth_Tracking() / 2.0)
				{
					result = false;
					return result;
				}
				result = true;
				return result;
			}
			result = base.TargetIsWithinCoverageArc(theTarget, CustomParentHeading);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10234590832469", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Sensor FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theParentPlatform)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		Sensor result;
		try
		{
			Sensor sensor = new Sensor();
			sensor.ParentPlatform = theParentPlatform;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "SensorGroup":
					sensor.IsSensorInGroup = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Name":
					sensor.Name = theNode2.InnerText;
					break;
				case "Status":
				case "St":
					switch (theNode2.InnerText)
					{
					case "Operational":
						sensor._Status = _ComponentStatus.Operational;
						break;
					case "Damaged":
						sensor._Status = _ComponentStatus.Damaged;
						break;
					case "Destroyed":
						sensor._Status = _ComponentStatus.Destroyed;
						break;
					default:
						sensor._Status = (_ComponentStatus)Conversions.ToByte(theNode2.InnerText);
						break;
					}
					break;
				case "MinElevationAngle":
					sensor.MinElevationAngle = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "TargetsIlluminated":
				case "TTFFC":
				case "TargetsTrackedForFireControl":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						Contact item = Contact.FromXML(childNode2.InnerText, ref theDictionary);
						sensor.concurrentHashSet_0.Add(item);
					}
					break;
				case "ID":
					if (Information.IsNothing((object)theDictionary))
					{
						break;
					}
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						sensor.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(sensor.ObjectID, sensor);
						break;
					}
					result = (Sensor)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "DBID":
				{
					int num = Conversions.ToInteger(theNode2.InnerText);
					SQLiteConnection sqliteConnection_ = theParentPlatform.ParentScen.DBConnection;
					Sensor sensor2 = DBFunctions.GetSensor(num, ref sqliteConnection_);
					sensor2.ObjectID_Set(sensor.ObjectID);
					sensor2._Status = sensor.Status;
					sensor2.Name = sensor.Name;
					sensor2.DBID = Conversions.ToInteger(theNode2.InnerText);
					sensor2.Coverage = sensor.Coverage;
					foreach (Contact item2 in sensor.TargetsTrackedForFireControl_Readonly)
					{
						sensor2.concurrentHashSet_0.Add(item2);
					}
					sensor2.SemiActiveWeaponsGuided = sensor.SemiActiveWeaponsGuided;
					if (sensor.IsActive())
					{
						sensor2.GoActive();
					}
					sensor = sensor2;
					break;
				}
				case "IsA":
				case "IsActive":
					sensor.bool_0 = Misc.ParseBool(theNode2.InnerText);
					break;
				case "DamageSeverity":
					sensor.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(theNode2.InnerText);
					break;
				case "MaxElevationAngle":
					sensor.MaxElevationAngle = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "Cov_Ill":
				case "Coverage_Illuminate":
					sensor.Coverage_Illuminate = _Coverage.FromXML(ref theNode2);
					break;
				case "SemiActiveWeaponsGuided":
				case "SAWG":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val = childNode3;
						sensor.list_0.Add(val.ChildNodes[0].InnerText);
					}
					break;
				case "TTNS":
					sensor.TimeToNextScan = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Cov":
				case "Coverage":
					sensor.Coverage = _Coverage.FromXML(ref theNode2);
					break;
				case "Boresight":
					sensor.Boresight = Convert.ToSingle(theNode2.InnerText, CultureInfo.InvariantCulture);
					break;
				}
			}
			if (string.IsNullOrEmpty(sensor.Name))
			{
				if (sensor.DBID == 0)
				{
					sensor.Name = "Mk1 Eyeball";
				}
				else
				{
					Sensor sensor3 = sensor;
					int dBID = sensor.DBID;
					SQLiteConnection sqliteConnection_ = theParentPlatform.ParentScen.DBConnection;
					sensor3.Name = DBFunctions.GetSensorName(dBID, ref sqliteConnection_);
				}
			}
			result = sensor;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100694", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Sensor();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void PostDeserializationHousekeeping(ref Scenario theScen)
	{
		try
		{
			if (list_0.Count <= 0)
			{
				return;
			}
			foreach (string item in list_0)
			{
				Weapon weapon = (Weapon)theScen.ActiveUnits[item];
				if (!Information.IsNothing((object)weapon))
				{
					SemiActiveWeaponsGuided.Add(weapon);
					weapon.SensorProvidingFireControlForMe = this;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100700", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleTargetLoss(Contact theC)
	{
		List<Contact> list = concurrentHashSet_0.ToList();
		int count = list.Count;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Contact contact;
			try
			{
				if (count <= i)
				{
					break;
				}
				contact = list[i];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				continue;
			}
			if (contact == theC)
			{
				StopTrackingTarget(theC);
			}
		}
	}

	public bool IsActive()
	{
		if (bool_0)
		{
			return _Status == _ComponentStatus.Operational;
		}
		return false;
	}

	private bool method_2()
	{
		int result;
		switch (Type)
		{
		case Sensor_Type.SensorGroup:
			result = 0;
			break;
		default:
		{
			if (IsPureIlluminator)
			{
				return false;
			}
			Sensor_Role role = Role;
			if ((ulong)(role - 2031L) > 4uL && role != Sensor_Role.FCR_GunOnly && (ulong)(role - 2201L) > 2uL)
			{
				return true;
			}
			return false;
		}
		case Sensor_Type.None:
		case Sensor_Type.SemiActive:
		case Sensor_Type.TVM:
		case Sensor_Type.ECM:
		case Sensor_Type.LaserDesignator:
		case Sensor_Type.LaserSpotTracker:
		case Sensor_Type.LaserRangefinder:
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public bool TargetIsWithinRadarVelocityFilter(ActiveUnit theTarget)
	{
		int num = default(int);
		int num2 = default(int);
		if (Capabilities.AirSearch)
		{
			num = 0;
			num2 = 3300;
		}
		if (Capabilities.SpaceSearch_ABM)
		{
			num = 1980;
			num2 = 19800;
		}
		if (Capabilities.AirSearch && Capabilities.SpaceSearch_ABM)
		{
			num = 0;
			num2 = 19800;
		}
		if (theTarget.CurrentSpeed > (float)num && theTarget.CurrentSpeed < (float)num2)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	private bool? method_3()
	{
		if (!nullable_1.HasValue)
		{
			nullable_1 = true;
			Sensor[] sensors_Cached = ParentPlatform.Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if (DBID != sensor.DBID && sensor.Type == Sensor_Type.Visual)
				{
					nullable_1 = false;
					break;
				}
			}
		}
		return nullable_1;
	}

	public Sensor(ref SQLiteConnection theConn, int int_2, string theName, Sensor_Type theSensorType, Sensor_Role theSensorRole, GlobalVariables.TechGenerationClass theGeneration, float theMaxRange, float theMinRange, byte theArcLeft, byte theArcRight, int thePassiveInput, int theMaxIntercept, float theMaxAltitude, float theMinAltitude, float theMaxAltitude_ASL, float theMinAltitude_ASL, int theScanInterval, float theRangeResolution, float theAngleResolution, float theHeightResolution, bool IsEyeball, short theMasqueradeAs = 0, short theMaxContactsAir = 0, short theMaxContactsSurface = 0, short theMaxContactsSub = 0, float theAvailability = 0f, long theUpperFreq = 0L, long theLowerFreq = 0L, long theUpperFreqIlluminate = 0L, long theLowerFreqIlluminate = 0L, float float_9 = 0f, float theECMPeakPower = 0f, float theECMBandwidth = 0f, float theECMNumberofTargets = 0f, float float_10 = 0f, float float_11 = 0f, short theMineSweepWidth = 0, short theMineMaxSpeed = 0, float theVisualDetectZoom = 0f, float theVisualClassZoom = 0f, float theIRDetectZoom = 0f, float theIRClassZoom = 0f, bool IsHypothetical = false)
	{
		Capabilities = default(_Capabilities);
		Codes = default(_Codes);
		SearchFreqs = new RadioElectronicFrequency[0];
		IlluminationFreqs = new RadioElectronicFrequency[0];
		concurrentHashSet_0 = new ConcurrentHashSet<Contact>();
		SemiActiveWeaponsGuided = new ConcurrentHashSet<Weapon>();
		list_0 = new List<string>();
		Coverage_Illuminate = new _Coverage();
		IsSensorInLoadout = false;
		IsSensorInMount = false;
		IsSensorInGroup = -1;
		IsSatelliteSensor = false;
		MastHeight = 0;
		IsGNSSJammer = false;
		IsOECM = false;
		MaxElevationAngle = 30f;
		MinElevationAngle = -30f;
		float_3 = 0.5f;
		float_4 = 0.5f;
		bool_1 = true;
		CanPerformVolumeSearch = new Lazy<bool>(method_2);
		nullable_1 = null;
		nullable_2 = null;
		threadLocal_0 = new ThreadLocal<List<Sensor>>();
		Coverage = new _Coverage();
		try
		{
			DBID = int_2;
			maxRange = theMaxRange;
			minRange = theMinRange;
			Name = theName;
			MaxIlluminate = theMaxIntercept;
			MaxAltitude_AGL = theMaxAltitude;
			MinAltitude_AGL = theMinAltitude;
			MaxAltitude_ASL = theMaxAltitude_ASL;
			MinAltitude_ASL = theMinAltitude_ASL;
			Type = theSensorType;
			Role = theSensorRole;
			TechGeneration = theGeneration;
			ScanInterval = theScanInterval;
			HeightResolution = theHeightResolution;
			MasqueradeAs = theMasqueradeAs;
			short_0 = theMaxContactsAir;
			short_1 = theMaxContactsSurface;
			short_2 = theMaxContactsSub;
			float_0 = theAvailability;
			long_0 = theUpperFreq;
			long_1 = theLowerFreq;
			long_2 = theUpperFreqIlluminate;
			long_3 = theLowerFreqIlluminate;
			MineSweepWidth = theMineSweepWidth;
			MineSweepMaxSpeed = theMineMaxSpeed;
			VisualDetectionZoomLevel = Math.Max(1f, theVisualDetectZoom);
			VisualClassZoomLevel = Math.Max(1f, theVisualClassZoom);
			float_2 = Math.Max(1f, theIRDetectZoom);
			IRClassZoomLevel = Math.Max(1f, theIRClassZoom);
			if (Type == Sensor_Type.ESM)
			{
				Sensor theS = this;
				DBFunctions.GetESMSpecificParameters(ref theS, theConn);
			}
			if (Type == Sensor_Type.Radar || Type == Sensor_Type.Microwave_Emitter)
			{
				Sensor theS = this;
				DBFunctions.GetRadarSpecificParameters(ref theS, theConn);
			}
			ECM_Gain = float_9;
			ECM_PeakPower = theECMPeakPower;
			ECM_Bandwidth = theECMBandwidth;
			ECM_NumberOfTargets = theECMNumberofTargets;
			ECM_PokReduction = float_10;
			if (IsSonar || IsPingIntercept)
			{
				RangeResolution_Nominal = (float)(0.2 * (double)maxRange);
				switch (TechGeneration)
				{
				default:
					AngleResolution = 2f;
					break;
				case GlobalVariables.TechGenerationClass.const_2:
				case GlobalVariables.TechGenerationClass.const_3:
					AngleResolution = 30f;
					break;
				case GlobalVariables.TechGenerationClass.const_4:
				case GlobalVariables.TechGenerationClass.const_5:
					AngleResolution = 25f;
					break;
				case GlobalVariables.TechGenerationClass.const_6:
				case GlobalVariables.TechGenerationClass.const_7:
					AngleResolution = 20f;
					break;
				case GlobalVariables.TechGenerationClass.const_8:
				case GlobalVariables.TechGenerationClass.const_9:
					AngleResolution = 15f;
					break;
				case GlobalVariables.TechGenerationClass.const_10:
				case GlobalVariables.TechGenerationClass.const_11:
					AngleResolution = 10f;
					break;
				case GlobalVariables.TechGenerationClass.const_12:
				case GlobalVariables.TechGenerationClass.const_13:
					AngleResolution = 5f;
					break;
				}
			}
			AngleResolution = theAngleResolution;
			if (AngleResolution == 0f)
			{
				AngleResolution = float_11;
			}
			if (AngleResolution == 0f)
			{
				AngleResolution = 5f;
			}
			if (!IsEyeball)
			{
				Sensor theS = this;
				DBFunctions.GetSensorCapabilities(ref theS, int_2, theConn);
				theS = this;
				DBFunctions.GetSensorCodes(ref theS, int_2, theConn);
				theS = this;
				DBFunctions.GetSensorSearchFreqs(ref theS, int_2, theConn);
				theS = this;
				DBFunctions.GetSensorIlluminationFreqs(ref theS, int_2, theConn);
			}
			if (IsPureIlluminator)
			{
				Codes.ContinousTrackingCapable_RadarTracker = true;
			}
			if ((IsSonar || IsPingIntercept) && !HasActiveModeOnly)
			{
				Codes.ContinuousTrackingCapable = true;
			}
			if (Type == Sensor_Type.MAD && AngleResolution == 0f)
			{
				AngleResolution = 2f;
			}
			LockRandom lockRandom_ = GameGeneral.GlobalRNG;
			TimeToNextScan = lockRandom_.Next(0, ScanInterval);
			TimeToNextScan_Full = 0;
			Hypothetical = IsHypothetical;
			if (Type == Sensor_Type.Radar)
			{
				CalculateRadarResolutionCell();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100706", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PointDefenceJam(ref Sensor TargetSensor, ref ActiveUnit theUnit, List<string> PointDefenceMessages)
	{
		bool result;
		try
		{
			float eCM_PokReduction = ECM_PokReduction;
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			float num = default(float);
			if (TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
			{
				num = eCM_PokReduction;
			}
			else if (Role == Sensor_Role.IRCM)
			{
				num = eCM_PokReduction;
			}
			else
			{
				int num2 = TechGeneration - TargetSensor.TechGeneration;
				if (num2 < -3)
				{
					num = eCM_PokReduction - 15f;
				}
				else if (num2 == -3)
				{
					num = eCM_PokReduction - 10f;
				}
				else if (num2 == -2)
				{
					num = eCM_PokReduction - 5f;
				}
				else if (num2 == -1)
				{
					num = eCM_PokReduction;
				}
				else if (num2 == 0)
				{
					num = eCM_PokReduction;
				}
				else if (num2 == 1)
				{
					num = eCM_PokReduction;
				}
				else if (num2 == 2)
				{
					num = eCM_PokReduction + 5f;
				}
				else if (num2 == 3)
				{
					num = eCM_PokReduction + 10f;
				}
				else if (num2 > 3)
				{
					num = eCM_PokReduction + 15f;
				}
			}
			if (TargetSensor.Type == Sensor_Type.Radar && TargetSensor.Codes.AESA)
			{
				num -= 30f;
			}
			num = Math.Max(num, 5f);
			stringBuilder.Append("Defensive jammer (" + Misc.RemoveHiddenString(Name) + "; Tech: " + Misc.ToEnglishString(TechGeneration) + ") on " + theUnit.Name + " is attempting to spoof sensor: " + Misc.RemoveHiddenString(TargetSensor.Name) + " (Tech: " + Misc.ToEnglishString(TargetSensor.TechGeneration) + ")(Of: " + TargetSensor.ParentPlatform.Name + "). Final probability: " + Conversions.ToString(Math.Round(num, 2)) + "%. ");
			int num3 = GameGeneral.GlobalRNG.Next(1, 101);
			bool flag = false;
			string messageSummary;
			if ((float)num3 <= num)
			{
				stringBuilder.Append("Result: " + Conversions.ToString(num3) + " - SUCCESS");
				messageSummary = Misc.RemoveHiddenString(Name) + " jammed " + Misc.RemoveHiddenString(TargetSensor.Name) + " successfully";
				flag = true;
			}
			else
			{
				stringBuilder.Append("Result: " + Conversions.ToString(num3) + " - FAILURE");
				messageSummary = Misc.RemoveHiddenString(Name) + " tried to jam " + Misc.RemoveHiddenString(TargetSensor.Name) + " but failed";
			}
			ParentPlatform.ParentScen.AddMessage(stringBuilder.ToString(), messageSummary, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			PointDefenceMessages?.Add(stringBuilder.ToString());
			StringBuilderCache.Free(stringBuilder);
			result = flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100707", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void GoActive(bool RaiseEvents = true)
	{
		if (!bool_0 && base.Status == _ComponentStatus.Operational)
		{
			bool_0 = true;
			if (RaiseEvents)
			{
				RaiseEventStatusChanged();
			}
			TimeToNextScan = GameGeneral.GlobalRNG.Next(0, ScanInterval);
			TimeToNextScan_Full = 0;
		}
	}

	public void GoPassive(bool RaiseEvents = true)
	{
		if (bool_0)
		{
			bool_0 = false;
			if (concurrentHashSet_0.Count > 0)
			{
				concurrentHashSet_0.Clear();
			}
			if (RaiseEvents)
			{
				RaiseEventStatusChanged();
			}
		}
	}

	public override void Damage(_DamageSeverityFactor DamageSeverity)
	{
		try
		{
			List<Contact> list = new List<Contact>();
			foreach (Contact item in concurrentHashSet_0)
			{
				list.Add(item);
			}
			foreach (Contact item2 in list)
			{
				StopTrackingTarget(item2);
			}
			if (CanBeActive && IsActive())
			{
				GoPassive();
			}
			base.Damage(DamageSeverity);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100708", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		try
		{
			if (!IsAimpointFacility)
			{
				base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, RegisterAsLosses);
			}
			List<Contact> list = new List<Contact>();
			foreach (Contact item in concurrentHashSet_0)
			{
				list.Add(item);
			}
			foreach (Contact item2 in list)
			{
				StopTrackingTarget(item2);
			}
			GoPassive();
			_Status = _ComponentStatus.Destroyed;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100709", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CanIlluminateForThisWeapon(ref Weapon theWeapon)
	{
		if (Type == Sensor_Type.Radar)
		{
			int result;
			if (RadarHorBeamwidthIlluminate != 0f)
			{
				if (RadarVertBeamwidthIlluminate != 0f)
				{
					goto IL_0031;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		goto IL_0031;
		IL_0031:
		if (Type == Sensor_Type.LaserDesignator && theWeapon.Directors.Count == 0 && theWeapon.WeaponSensors().Count > 0 && theWeapon.WeaponSensors()[0].Type == Sensor_Type.LaserSpotTracker)
		{
			return true;
		}
		if (Type == Sensor_Type.Radar)
		{
			int result2;
			if (RadarHorBeamwidthIlluminate != 0f)
			{
				if (RadarVertBeamwidthIlluminate != 0f)
				{
					goto IL_00a6;
				}
				result2 = 0;
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		}
		goto IL_00a6;
		IL_00a6:
		return theWeapon.Directors.Contains(DBID);
	}

	public bool CanDirectThisMount(ref Mount theMount)
	{
		bool result;
		try
		{
			foreach (int compatibleDirector in theMount.CompatibleDirectors)
			{
				if (compatibleDirector != DBID)
				{
					continue;
				}
				result = true;
				goto end_IL_0001;
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100710", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void TrackTargetForFireControl(ref Contact theTarget)
	{
		try
		{
			if (!concurrentHashSet_0.Contains(theTarget))
			{
				concurrentHashSet_0.Add(theTarget);
			}
			if (CanBeActive)
			{
				if (!IsActive())
				{
					GoActive();
				}
				method_4(theTarget);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100711", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(Contact contact_0)
	{
		try
		{
			ActiveUnit[] array = ParentPlatform.ParentScen.ActiveUnits_List.InternalArray();
			foreach (ActiveUnit activeUnit in array)
			{
				if (activeUnit != null && activeUnit.IsWeapon && !Information.IsNothing((object)activeUnit.AI.PrimaryTarget) && activeUnit.AI.PrimaryTarget == contact_0)
				{
					((Weapon)activeUnit).BlindTime = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100712", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsTrackingThisTargetForFireControl(ref Contact theTarget)
	{
		if (!IsActive())
		{
			return false;
		}
		return concurrentHashSet_0.Contains(theTarget);
	}

	public bool IsTrackingThisUnitForFireControl(ref ActiveUnit theUnit)
	{
		bool result;
		try
		{
			if (IsActive())
			{
				if (concurrentHashSet_0.Count < 1)
				{
					result = false;
				}
				else
				{
					List<Contact> list = new List<Contact>();
					list.AddRange(concurrentHashSet_0.ToList());
					int num = list.Count - 1;
					int num2 = 0;
					while (true)
					{
						if (num2 <= num)
						{
							Contact contact = list[num2];
							if (contact == null || contact.ActualUnit != theUnit)
							{
								num2++;
								continue;
							}
							result = true;
							break;
						}
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200034", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void StopTrackingTarget(Contact theTarget, bool WillRetryToPaint = false)
	{
		try
		{
			if (!concurrentHashSet_0.Contains(theTarget))
			{
				return;
			}
			try
			{
				concurrentHashSet_0.Remove(theTarget);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200035", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				ProjectData.ClearProjectError();
			}
			if (!WillRetryToPaint)
			{
				foreach (ActiveUnit value in ParentPlatform.ParentScen.ActiveUnits.Values)
				{
					if (value != null && value.IsWeapon && value.get_UnitSide(SetSideOnly: false) == ParentPlatform.get_UnitSide(SetSideOnly: false) && SemiActiveWeaponsGuided.Contains((Weapon)value) && value.AI.PrimaryTarget == theTarget)
					{
						try
						{
							SemiActiveWeaponsGuided.Remove((Weapon)value);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200036", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			if (concurrentHashSet_0.Count == 0 && IsPureIlluminator)
			{
				GoPassive();
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100713", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HasFireControlChannelAvailable()
	{
		return concurrentHashSet_0.Count < MaxIlluminate;
	}

	public bool CanDetectTarget_NonAU(ActiveUnit SensorParent, Module_Unit.Unit theUnit, float TargetRange)
	{
		bool result;
		try
		{
			int num;
			if (!(maxRange >= TargetRange))
			{
				result = false;
			}
			else if (TargetIsWithinCoverageArc(theUnit))
			{
				if (theUnit.GetType() == typeof(UnguidedWeapon) && ((UnguidedWeapon)theUnit).IsMine)
				{
					if (Type == Sensor_Type.Visual)
					{
						Weapon._WeaponType type = ((UnguidedWeapon)theUnit).Type;
						if (type != Weapon._WeaponType.FloatingMine && type != Weapon._WeaponType.DriftingMine)
						{
							result = false;
						}
						else
						{
							float float_ = 0.16198704f;
							method_14(SensorParent, theUnit, ref float_);
							result = ((float_ > TargetRange) ? true : false);
						}
					}
					else
					{
						if (!IsSonar && !IsPingIntercept && !IsMineHuntingSensor)
						{
							num = 0;
							goto IL_0178;
						}
						if (!IsActive() || (!this.get_SearchesInThisFrequency(FrequencyBand.HF_Sonar) && !Capabilities.Mine_Obstacle_Search))
						{
							num = 0;
							goto IL_0178;
						}
						float num2;
						switch (((UnguidedWeapon)theUnit).Type)
						{
						case Weapon._WeaponType.FloatingMine:
							num2 = 0.7f;
							break;
						case Weapon._WeaponType.BottomMine:
						case Weapon._WeaponType.MovingMine:
							num2 = 0.5f;
							break;
						case Weapon._WeaponType.MooredMine:
						case Weapon._WeaponType.RisingMine:
							num2 = 1f;
							break;
						case Weapon._WeaponType.DriftingMine:
							num2 = 0.7f;
							break;
						default:
							throw new NotImplementedException();
						case Weapon._WeaponType.DummyMine:
							num2 = 1f;
							break;
						}
						result = ((maxRange * num2 >= TargetRange) ? true : false);
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0178:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100714", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ResetSensorFailureReport()
	{
		if (GameGeneral.PE_CompleteSensorFailureReport || GameGeneral.ReportCompleteSensorDetectionAttempt)
		{
			list_1 = new List<SensorDetectionFeedback>();
		}
	}

	public bool? FeedSensorFailureItem(bool Result, SensorDetectionFeedback Type, ref GlobalVariables.BooleanObject LocalResult, bool UsePerformanceShortcut = false)
	{
		return Result;
	}

	public bool CanDetectTarget(DetectionAttemptType theAttemptType, ActiveUnit SensorParent, ActiveUnit theUnit, ref List<Geopoint_Struct> UncertaintyArea, float TargetSlantRange, ref Dictionary<int, EmissionContainer> DetectedEmissions, List<ActiveUnit> AffectingJammers, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar, ref bool? LOS_Exists_ESM, ref bool? LOS_Exists_ESM_SW, bool considerOverlappingCoordinatesAsValid = true)
	{
		bool result;
		int num;
		if (SensorParent.IsWeapon)
		{
			if (((Weapon)SensorParent).IsDLZconstruct)
			{
				result = true;
				goto IL_0a0a;
			}
			num = 0;
		}
		else
		{
			num = 0;
		}
		bool bool_ = (byte)num != 0;
		GlobalVariables.BooleanObject LocalResult = null;
		if (IsSatelliteSensor)
		{
			Satellite satellite = (Satellite)ParentPlatform;
			if (((ActiveUnit)satellite).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2000000f)
			{
				float offZenithAngle = (float)Module_Unit.OffZenithAngleToPoint(satellite, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (!IsWithinOffZenithAngleLimits(offZenithAngle) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_SensorElevationAngleLimits, ref LocalResult).HasValue)
				{
					result = false;
					goto IL_0a0a;
				}
			}
		}
		if (!(maxRange >= TargetSlantRange) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_Range, ref LocalResult).HasValue)
		{
			result = false;
		}
		else if (!this.get_IsSuitableForThisTarget(theUnit) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_TargetSuitability, ref LocalResult).HasValue)
		{
			result = false;
		}
		else if (!TargetIsWithinCoverageArc(theUnit) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_CoveringArc, ref LocalResult).HasValue)
		{
			result = false;
		}
		else if (theUnit == null)
		{
			result = false;
		}
		else
		{
			if (!theUnit.IsAerospaceUnit || Capabilities.SpaceSearch_ABM)
			{
				goto IL_0242;
			}
			if (MaxAltitude_AGL > 0f && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > MaxAltitude_AGL + SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_MaxAltitude_AGL, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (MinAltitude_AGL > 0f && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < MinAltitude_AGL + SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_MinAltitude_AGL, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (MaxAltitude_ASL > 0f && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > MaxAltitude_ASL && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_MaxAltitude_ASL, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if (!(MinAltitude_ASL > 0f) || !(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < MinAltitude_ASL) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_MinAltitude_ASL, ref LocalResult).HasValue)
				{
					goto IL_0242;
				}
				result = false;
			}
		}
		goto IL_0a0a;
		IL_0242:
		try
		{
			bool flag2 = default(bool);
			switch (Type)
			{
			case Sensor_Type.ESM:
				if (!SensorParent.IsWeapon || ((Weapon)SensorParent).IsDecoy)
				{
					goto IL_0354;
				}
				if (!theUnit.IsSatellite)
				{
					if (((Weapon)SensorParent).MaxAirRange == 0f)
					{
						if (!(theUnit.IsAircraft | theUnit.IsWeapon) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_AircraftOrWeapon, ref LocalResult).HasValue)
						{
							goto IL_0354;
						}
						result = false;
					}
					else
					{
						if (((Weapon)SensorParent).MaxSurfaceRange != 0f || (!theUnit.IsShip && !theUnit.IsFacility) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_ShipOrFacility, ref LocalResult).HasValue)
						{
							goto IL_0354;
						}
						result = false;
					}
				}
				else
				{
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_Satellite, ref LocalResult).HasValue)
					{
						goto IL_0354;
					}
					result = false;
				}
				goto end_IL_0242;
			case Sensor_Type.Radar:
				if (flag2 = method_6(SensorParent, theUnit, TargetSlantRange, AffectingJammers, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, bool_, considerOverlappingCoordinatesAsValid))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_Radar, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_Radar, ref LocalResult);
				}
				break;
			case Sensor_Type.Visual:
				if (flag2 = method_15(SensorParent, theUnit, TargetSlantRange, ref LOS_Exists_Visual, bool_, theUnit.IsAggregatedUnit))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_Visual, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_Visual, ref LocalResult);
				}
				break;
			case Sensor_Type.Infrared:
				if (!(flag2 = method_31(SensorParent, theUnit, TargetSlantRange, ref LOS_Exists_Visual, bool_)))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_IR, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_IR, ref LocalResult);
				}
				break;
			case Sensor_Type.TowedArray_PassiveOnly:
			case Sensor_Type.TowedArray_ActivePassive:
			case Sensor_Type.TowedArray_ActiveOnly:
			{
				int bottomDepth = ((Module_Unit.Unit)SensorParent).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, SensorParent.ParentScen);
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(SensorParent.get_Latitude((GlobalVariables.BooleanObject)null), SensorParent.get_Longitude((GlobalVariables.BooleanObject)null), bottomDepth, SensorParent.ParentScen);
				float value = default(float);
				int num2;
				if (SensorParent.IsShip)
				{
					value = thermalLayerAtThisLocation.Floor - 20;
					num2 = 1;
				}
				else if (!SensorParent.IsSubmarine)
				{
					num2 = 1;
				}
				else if (SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)thermalLayerAtThisLocation.Floor && (float)(thermalLayerAtThisLocation.Ceiling + 30) > SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					value = thermalLayerAtThisLocation.Floor - 20;
					num2 = 1;
				}
				else
				{
					value = (int)Math.Round(SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					num2 = 1;
				}
				bool flag3 = (byte)num2 != 0;
				if (HasActiveModeOnly)
				{
					flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar, value);
				}
				else if (IsActive())
				{
					flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar, value);
				}
				else
				{
					flag3 = false;
					flag2 = method_25(SensorParent, theUnit, TargetSlantRange, DetectedEmissions, bool_3: false, LOS_Exists_Sonar, value);
				}
				if (!flag3)
				{
					if (!flag2)
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_PassiveSonar, ref LocalResult);
					}
					else
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar, ref LocalResult);
					}
				}
				else if (flag2)
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_ActiveSonar, ref LocalResult);
				}
				break;
			}
			case Sensor_Type.PCLS:
			{
				new List<ActiveUnit>();
				ActiveUnit[] array = SensorParent.ParentScen.ActiveUnits_List.InternalArray();
				int num3 = 0;
				checked
				{
					while (true)
					{
						if (num3 < array.Length)
						{
							ActiveUnit activeUnit = array[num3];
							if (activeUnit != null)
							{
								Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
								int num4 = 0;
								while (num4 < sensors_Cached.Length)
								{
									Sensor sensor = sensors_Cached[num4];
									if (sensor.Type != Sensor_Type.NonDetectingEmitter || !method_7(SensorParent, activeUnit, sensor, theUnit, TargetSlantRange, AffectingJammers, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, bool_) || !FeedSensorFailureItem(Result: true, SensorDetectionFeedback.GENERAL_SuccessfullDetection_FromOneOfThePCLS, ref LocalResult).HasValue)
									{
										num4++;
										continue;
									}
									result = true;
									goto end_IL_0242;
								}
							}
							num3++;
							continue;
						}
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_FailedDetection_FromAllThePCLS, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0242;
					}
					break;
				}
			}
			case Sensor_Type.VDS_PassiveOnly:
			case Sensor_Type.VDS_ActivePassive:
			case Sensor_Type.VDS_ActiveOnly:
			case Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor_Type.DippingSonar_ActivePassive:
			case Sensor_Type.DippingSonar_ActiveOnly:
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(SensorParent.get_Latitude((GlobalVariables.BooleanObject)null), SensorParent.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)SensorParent).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), SensorParent.ParentScen);
				float value2;
				int num5;
				if (GameGeneral.GlobalRNG.Next(0, 101) > 50)
				{
					value2 = (int)Math.Round((double)thermalLayerAtThisLocation2.Ceiling / 2.0);
					num5 = 1;
				}
				else
				{
					value2 = thermalLayerAtThisLocation2.Floor - 30;
					num5 = 1;
				}
				bool flag4 = (byte)num5 != 0;
				if (HasActiveModeOnly)
				{
					flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar, value2);
				}
				else if (IsActive())
				{
					flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar, value2);
				}
				else
				{
					flag2 = method_25(SensorParent, theUnit, TargetSlantRange, DetectedEmissions, bool_3: false, LOS_Exists_Sonar, value2);
					flag4 = false;
				}
				if (flag4)
				{
					if (!flag2)
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_ActiveSonar, ref LocalResult);
					}
					else
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar, ref LocalResult);
					}
				}
				else if (!flag2)
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_PassiveSonar, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar, ref LocalResult);
				}
				break;
			}
			default:
				FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_Other, ref LocalResult);
				result = false;
				goto end_IL_0242;
			case Sensor_Type.PingIntercept:
				if (flag2 = method_23(SensorParent, theUnit, TargetSlantRange, DetectedEmissions, LOS_Exists_Sonar))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_PingIntercept, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_PingIntercept, ref LocalResult);
				}
				break;
			case Sensor_Type.MAD:
				if (flag2 = method_17(SensorParent, theUnit, TargetSlantRange))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_MAD, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_MAD, ref LocalResult);
				}
				break;
			case Sensor_Type.HullSonar_PassiveOnly:
			case Sensor_Type.HullSonar_ActivePassive:
			case Sensor_Type.HullSonar_ActiveOnly:
			case Sensor_Type.BottomFixedSonar_PassiveOnly:
				{
					bool flag = true;
					if (HasActiveModeOnly)
					{
						flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar);
					}
					else if (IsActive())
					{
						flag2 = method_22(SensorParent, theUnit, TargetSlantRange, LOS_Exists_Sonar);
					}
					else
					{
						flag2 = method_25(SensorParent, theUnit, TargetSlantRange, DetectedEmissions, bool_3: false, LOS_Exists_Sonar);
						flag = false;
					}
					if (flag)
					{
						if (flag2)
						{
							FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_HullandBottomFixed_ActiveSonar, ref LocalResult);
						}
						else
						{
							FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_HullandBottomFixed_ActiveSonar, ref LocalResult);
						}
					}
					else if (!flag2)
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_HullandBottomFixed_PassiveSonar, ref LocalResult);
					}
					else
					{
						FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_HullandBottomFixed_PassiveSonar, ref LocalResult);
					}
					break;
				}
				IL_0354:
				if (!(flag2 = method_16(SensorParent, theUnit, TargetSlantRange, ref DetectedEmissions, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW, bool_)))
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_FailedDetection_ESM, ref LocalResult);
				}
				else
				{
					FeedSensorFailureItem(flag2, SensorDetectionFeedback.GENERAL_SuccessfullDetection_ESM, ref LocalResult);
				}
				break;
			}
			if (flag2 && !ActiveUnit_Sensory.DetectionIsPrecise(this, Module_Unit.RangeToUnit_Slant(SensorParent, theUnit, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) && (!theUnit.IsFixedFacility || Type == Sensor_Type.ESM))
			{
				List<Geopoint_Struct> list = ((DetectedEmissions != null) ? SensorParent.Sensory.GetUncertaintyArea(this, theUnit, SensorParent.RangeToUnit_Horiz(theUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue), DetectedEmissions) : SensorParent.Sensory.GetUncertaintyArea(this, theUnit, SensorParent.RangeToUnit_Horiz(theUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue), null));
				UncertaintyArea = list;
			}
			result = LocalResult?.ToBoolean() ?? flag2;
			end_IL_0242:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100715", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num6 = 0;
			}
			else
			{
				num6 = 0;
			}
			result = (byte)num6 != 0;
			ProjectData.ClearProjectError();
		}
		goto IL_0a0a;
		IL_0a0a:
		return result;
	}

	private bool method_5(float float_9, float float_10, float float_11)
	{
		float num = float_9 - float_10;
		if (num > 0f)
		{
			if ((double)(num / float_3) > (double)float_11 * 1852.0)
			{
				return true;
			}
		}
		else if ((double)(num / float_4) > (double)float_11 * 1852.0)
		{
			return true;
		}
		return false;
	}

	private bool method_6(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, List<ActiveUnit> list_2, ref bool? nullable_3, ref bool? nullable_4, bool bool_3 = false, bool bool_4 = false)
	{
		bool result;
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			if (Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_4.HasValue)
				{
					goto IL_00c8;
				}
				bool? flag = nullable_4;
				if (((!flag) ?? flag) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_RadarLOS_SurfaceWave, ref LocalResult).HasValue)
				{
					goto IL_00c8;
				}
				result = false;
			}
			else
			{
				if (!nullable_3.HasValue)
				{
					goto IL_00c8;
				}
				bool? flag = nullable_3;
				if (((!flag) ?? flag) != true || GameGeneral.PE_CompleteSensorFailureReport || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_RadarLOS, ref LocalResult).HasValue)
				{
					goto IL_00c8;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_01b4:
			if (!IsPureIlluminator)
			{
				goto IL_020e;
			}
			if (method_32(activeUnit_0, activeUnit_1, float_9, list_2, bool_3: true, bool_4: false, ref nullable_3, ref nullable_4) != SensorDetectionCheckResult.Success)
			{
				if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_PureIlluminatorFailedDetection, ref LocalResult).HasValue)
				{
					goto IL_020e;
				}
				result = false;
			}
			else
			{
				if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADAR_PureIlluminatorSuccessfulDetection, ref LocalResult).HasValue)
				{
					goto IL_020e;
				}
				result = true;
			}
			goto end_IL_0001;
			IL_04b7:
			int num;
			XSection._SignatureType desiredSignatureType = (XSection._SignatureType)num;
			goto IL_04b9;
			IL_020e:
			if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0)
			{
				switch (((Submarine)activeUnit_1).Type)
				{
				case Submarine._SubmarineType.None:
				case Submarine._SubmarineType.Biologics:
				case Submarine._SubmarineType.FalseTarget:
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_SubUnitAbovePeriscopeDepthNotDetectable_BiologicsOrFalseContact, ref LocalResult).HasValue)
					{
						break;
					}
					result = false;
					goto end_IL_0001;
				case Submarine._SubmarineType.SDV:
				case Submarine._SubmarineType.ROV:
				case Submarine._SubmarineType.UUV:
					if (!(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_SubUnitAbovePeriscopeDepthNotDetectable_NoPeriscopeOrSnorkel, ref LocalResult).HasValue)
					{
						break;
					}
					result = false;
					goto end_IL_0001;
				}
			}
			if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0 && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f && !Capabilities.PeriscopeSearch && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_CantDetectPeriscope, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (!activeUnit_0.IsSatellite && !activeUnit_0.IsWeapon && method_5(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), float_9) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_BlindCone, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if ((!activeUnit_1.IsAircraft && !activeUnit_1.IsMissile) || !(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) || Codes.Doppler_LDSD_Full)
				{
					goto IL_0431;
				}
				float value = (float)Geodesic_Vincenty.ApproxGrazingAngle(activeUnit_0.RangeToUnit_Horiz(activeUnit_1), activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (Codes.Doppler_LDSD_Limited && Math.Abs(value) > 15f)
				{
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_LDSD_Limited_LookDown15deg, ref LocalResult).HasValue)
					{
						goto IL_0431;
					}
					result = false;
				}
				else
				{
					if (Codes.Doppler_LDSD_Limited || !(Math.Abs(value) > 5f) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_LDSD_Limited_LookDown5deg, ref LocalResult).HasValue)
					{
						goto IL_0431;
					}
					result = false;
				}
			}
			goto end_IL_0001;
			IL_04b9:
			XSection xSection = smethod_0(activeUnit_1, desiredSignatureType);
			if (xSection == null)
			{
				xSection = smethod_0(activeUnit_1, desiredSignatureType);
			}
			float targetAspect;
			if (xSection == null && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_Other, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (xSection.isDBInvisible(activeUnit_1) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.DB_Invisible, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				float num2 = RadarModel.GetDesiredXSectionValue(xSection, activeUnit_1, targetAspect);
				if (activeUnit_1.IsPlatform && ((Platform)activeUnit_1).RepresentsMobileGroundUnit)
				{
					num2 = RadarModel.ModifiedSignature_MobileUnits_db(this, num2, activeUnit_1);
				}
				if (!IsPureIlluminator && !method_39(activeUnit_0, activeUnit_1, num2, float_9, ActiveEmissionMode.Search_Track, list_2, activeUnit_0.WeatherAtMyLocation, bool_3) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_ECM_Equation, ref LocalResult).HasValue)
				{
					result = false;
				}
				else if (Capabilities.OTH_Backscatter && FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADAR_Successful_OTHBackscatter, ref LocalResult).HasValue)
				{
					result = true;
				}
				else
				{
					if (!Capabilities.SpaceSearch_ABM || !activeUnit_1.IsWeapon || (((Weapon)activeUnit_1).Type != Weapon._WeaponType.RV && ((Weapon)activeUnit_1).Type != Weapon._WeaponType.HGV))
					{
						goto IL_0659;
					}
					if (Horizon.RadarHorizonNM(activeUnit_0, activeUnit_1, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADAR_ABM_HorizonSuccessful, ref LocalResult).HasValue)
						{
							goto IL_0659;
						}
						result = true;
					}
					else
					{
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_ABM_HorizonFailed, ref LocalResult).HasValue)
						{
							goto IL_0659;
						}
						result = false;
					}
				}
			}
			goto end_IL_0001;
			IL_00c8:
			if (!VariableMaxRange || Coverage.Has360Coverage.Value)
			{
				goto IL_01b4;
			}
			PooledList<RangeSymbol> pooledList = PlatformComponent.RangeWedges_GetArcs(new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)), this, maxRange);
			float newBearing = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1);
			float num4 = default(float);
			foreach (RangeSymbol item in pooledList)
			{
				double num3 = Math.Abs(MathFunctions.AngularDifference((float)Math2.FindMiddleBearing(item.LeftArc, item.RightArc), newBearing));
				if (num3 > (double)num4)
				{
					num4 = (float)num3;
				}
			}
			pooledList.Dispose();
			if (num4 > 90f)
			{
				num4 -= 90f;
			}
			if (this.get_maxRangeAtAngle(num4) >= float_9 || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.GENERAL_Range, ref LocalResult).HasValue)
			{
				goto IL_01b4;
			}
			result = false;
			goto end_IL_0001;
			IL_0659:
			if (!Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: false, null, null, bool_4);
				}
				result = (nullable_3.Value || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_RadarLOS, ref LocalResult).HasValue) && (LocalResult?.ToBoolean() ?? nullable_3.Value);
			}
			else
			{
				if (!nullable_4.HasValue)
				{
					nullable_4 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: true);
				}
				result = (nullable_4.Value || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADAR_RadarLOS_SurfaceWave, ref LocalResult).HasValue) && (LocalResult?.ToBoolean() ?? nullable_4.Value);
			}
			goto end_IL_0001;
			IL_0431:
			ActiveUnit parentPlatform = ParentPlatform;
			string feedbackMessage = "";
			targetAspect = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
			if (this.get_SearchesInThisFrequency(FrequencyBand.A_Band))
			{
				num = 5001;
			}
			else
			{
				if (!this.get_SearchesInThisFrequency(FrequencyBand.B_Band))
				{
					if (this.get_SearchesInThisFrequency(FrequencyBand.C_Band))
					{
						num = 5001;
						goto IL_04b7;
					}
					if (!this.get_SearchesInThisFrequency(FrequencyBand.D_Band))
					{
						desiredSignatureType = XSection._SignatureType.Radar_E_M;
						goto IL_04b9;
					}
				}
				num = 5001;
			}
			goto IL_04b7;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100716", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (!Debugger.IsAttached)
			{
				num5 = 0;
			}
			else
			{
				Debugger.Break();
				num5 = 0;
			}
			result = (byte)num5 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_7(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Sensor sensor_0, ActiveUnit activeUnit_2, float float_9, List<ActiveUnit> list_2, ref bool? nullable_3, ref bool? nullable_4, bool bool_3 = false)
	{
		bool result;
		try
		{
			if (activeUnit_1.Sensory.GetIntermittentEmission().IsAllowedToEmit())
			{
				if (!Capabilities.OTH_SurfaceWave)
				{
					if (!nullable_3.HasValue)
					{
						goto IL_009d;
					}
					bool? flag = nullable_3;
					if (((!flag) ?? flag) != true)
					{
						goto IL_009d;
					}
					result = false;
				}
				else
				{
					if (!nullable_4.HasValue)
					{
						goto IL_009d;
					}
					bool? flag = nullable_4;
					if (((!flag) ?? flag) != true)
					{
						goto IL_009d;
					}
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0123:
			XSection._SignatureType desiredSignatureType;
			if (!activeUnit_2.IsSubmarine || !(Math.Round(activeUnit_2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0) || !(activeUnit_2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f) || Capabilities.PeriscopeSearch)
			{
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_2, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
				int num;
				if (!this.get_SearchesInThisFrequency(FrequencyBand.A_Band))
				{
					if (this.get_SearchesInThisFrequency(FrequencyBand.B_Band))
					{
						num = 5001;
					}
					else if (this.get_SearchesInThisFrequency(FrequencyBand.C_Band))
					{
						num = 5001;
					}
					else
					{
						if (!this.get_SearchesInThisFrequency(FrequencyBand.D_Band))
						{
							desiredSignatureType = XSection._SignatureType.Radar_E_M;
							goto IL_01fa;
						}
						num = 5001;
					}
				}
				else
				{
					num = 5001;
				}
				desiredSignatureType = (XSection._SignatureType)num;
				goto IL_01fa;
			}
			result = false;
			goto end_IL_0001;
			IL_010c:
			if (!(activeUnit_2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f))
			{
				goto IL_0123;
			}
			result = false;
			goto end_IL_0001;
			IL_009d:
			int num2;
			if (activeUnit_2.IsSubmarine && Math.Round(activeUnit_2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0)
			{
				Submarine._SubmarineType type = ((Submarine)activeUnit_2).Type;
				if (type <= Submarine._SubmarineType.SDV)
				{
					if (type == Submarine._SubmarineType.None)
					{
						num2 = 0;
						goto IL_0106;
					}
					if (type == Submarine._SubmarineType.SDV)
					{
						goto IL_010c;
					}
				}
				else
				{
					if ((uint)(type - 4001) <= 1u)
					{
						goto IL_010c;
					}
					if ((uint)(type - 9001) <= 1u)
					{
						num2 = 0;
						goto IL_0106;
					}
				}
			}
			goto IL_0123;
			IL_0106:
			result = (byte)num2 != 0;
			goto end_IL_0001;
			IL_03eb:
			result = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_1, sensor_0, activeUnit_2, ref activeUnit_0.ParentScen) && (Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_1, sensor_0, activeUnit_0, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: false, Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_1, sensor_0), Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_0, this)) ? true : false);
			goto end_IL_0001;
			IL_01fa:
			Module_Unit.BearingToUnit_Relative(activeUnit_2, activeUnit_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			Module_Unit.BearingToUnit_Relative(activeUnit_2, activeUnit_0, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			float num3 = RadarModel.CalculateBistaticRCS_db(activeUnit_2, desiredSignatureType, activeUnit_1, activeUnit_0);
			if (activeUnit_2.IsPlatform && ((Platform)activeUnit_2).RepresentsMobileGroundUnit)
			{
				num3 = RadarModel.ModifiedSignature_MobileUnits_db(this, num3, activeUnit_2);
			}
			if (!method_8(activeUnit_0, activeUnit_2, activeUnit_1, sensor_0, num3, float_9, ActiveEmissionMode.Search_Track, list_2, activeUnit_0.WeatherAtMyLocation))
			{
				result = false;
			}
			else if (Capabilities.OTH_Backscatter)
			{
				result = true;
			}
			else if (Capabilities.SpaceSearch_ABM && activeUnit_2.IsWeapon && (((Weapon)activeUnit_2).Type == Weapon._WeaponType.RV || ((Weapon)activeUnit_2).Type == Weapon._WeaponType.HGV))
			{
				result = Horizon.RadarHorizonNM(activeUnit_0, activeUnit_2, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_2.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_2.get_Longitude((GlobalVariables.BooleanObject)null));
			}
			else if (!Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_2, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: false, Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_1, sensor_0));
				}
				if (!nullable_3 != true)
				{
					goto IL_03eb;
				}
				result = false;
			}
			else
			{
				if (!nullable_4.HasValue)
				{
					nullable_4 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_2, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: true);
				}
				if (!nullable_4 != true)
				{
					goto IL_03eb;
				}
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100716", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (!Debugger.IsAttached)
			{
				num4 = 0;
			}
			else
			{
				Debugger.Break();
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_8(Module_Unit.Unit unit_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Sensor sensor_0, float float_9, float float_10, ActiveEmissionMode activeEmissionMode_0, List<ActiveUnit> list_2, Weather.WeatherProfile weatherProfile_0)
	{
		bool result;
		try
		{
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			RadarModel.TRadar RadarReceiver = new RadarModel.TRadar();
			double num = RadarModel.SurfaceGrazingAngle_deg(ParentPlatform.RangeToUnit_Horiz(activeUnit_0), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)ParentPlatform).get_MastHeight_Radar(this), activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref weatherProfile_0);
			float num2 = Module_Unit.RangeToUnit_Slant(unit_0, activeUnit_0);
			if (tradar_0 == null)
			{
				tradar_0 = new RadarModel.TRadar();
			}
			tradar_0.Altitude = Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(unit_0, this);
			tradar_0.ElevationAngle = 0.0 - num;
			if (sensor_0.Type == Sensor_Type.NonDetectingEmitter)
			{
				if (sensor_0.RadarHorBeamwidth == 0f)
				{
					sensor_0.RadarHorBeamwidth = 3f;
				}
				if (sensor_0.RadarVertBeamwidth == 0f)
				{
					sensor_0.RadarVertBeamwidth = 3f;
				}
				if (sensor_0.RadarPulseWidth == 0f)
				{
					sensor_0.RadarPulseWidth = 2f;
				}
				if (sensor_0.RadarPeakPower == 0f)
				{
					sensor_0.RadarPeakPower = 17000000f;
				}
				if (sensor_0.RadarPRF == 0f)
				{
					sensor_0.RadarPRF = 1000f;
				}
			}
			if (Type == Sensor_Type.PCLS)
			{
				if (RadarHorBeamwidth == 0f)
				{
					RadarHorBeamwidth = 7.5f;
				}
				if (RadarVertBeamwidth == 0f)
				{
					RadarVertBeamwidth = 7.5f;
				}
				if (RadarSystemNoiseLevel == 0f)
				{
					RadarSystemNoiseLevel = 2f;
				}
				if (RadarProcessingGainLoss == 0f)
				{
					RadarProcessingGainLoss = -2.2f;
				}
			}
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				tradar_0.SetGainFromBeamwidth(sensor_0.RadarHorBeamwidthIlluminate, sensor_0.RadarVertBeamwidthIlluminate);
				tradar_0.PowerOutputW = sensor_0.RadarPeakPowerIlluminate;
				tradar_0.PulseWidth = sensor_0.RadarPulseWidthIlluminate;
				tradar_0.ProcessingGain = sensor_0.RadarProcessingGainLossIlluminate;
				tradar_0.SystemNoiseLevel = sensor_0.RadarSystemNoiseIlluminate;
				tradar_0.Frequency = (double)(sensor_0.UpperFreqIlluminate + sensor_0.LowerFreqIlluminate) * 0.5;
				tradar_0.PRF = sensor_0.float_1;
				break;
			case ActiveEmissionMode.Search_Track:
				tradar_0.SetGainFromBeamwidth(sensor_0.RadarHorBeamwidth, sensor_0.RadarVertBeamwidth);
				tradar_0.PowerOutputW = sensor_0.RadarPeakPower;
				tradar_0.PulseWidth = sensor_0.RadarPulseWidth;
				tradar_0.ProcessingGain = sensor_0.RadarProcessingGainLoss;
				tradar_0.SystemNoiseLevel = sensor_0.RadarSystemNoiseLevel;
				tradar_0.Frequency = (double)(sensor_0.UpperFreq + sensor_0.LowerFreq) * 0.5;
				tradar_0.PRF = sensor_0.RadarPRF;
				break;
			}
			RadarReceiver.SetGainFromBeamwidth(RadarHorBeamwidth, RadarVertBeamwidth);
			RadarReceiver.PowerOutputW = RadarPeakPower;
			RadarReceiver.PulseWidth = RadarPulseWidth;
			RadarReceiver.ProcessingGain = RadarProcessingGainLoss;
			RadarReceiver.SystemNoiseLevel = RadarSystemNoiseLevel;
			RadarReceiver.Frequency = (double)(UpperFreq + LowerFreq) * 0.5;
			RadarReceiver.PRF = RadarPRF;
			if (!activeUnit_0.IsShip && !activeUnit_0.IsFacility && !activeUnit_0.IsSubmarine)
			{
				tTarget.Altitude = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_0);
			}
			else
			{
				tTarget.Height = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_0);
				tTarget.ObjectType = RadarModel.TTargetType.tgt_SurfaceShip;
				if (!Codes.PeriscopeSearch_Basic)
				{
					if (Codes.PeriscopeAndSurfaceSearch_FineRangeResolution)
					{
						tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.FineRangeResolution;
					}
					else if (Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing)
					{
						tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing;
					}
				}
				else
				{
					tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.Basic;
				}
			}
			tTarget.RCS = float_9;
			int useReadLock;
			if (list_2 == null)
			{
				list_2 = ParentPlatform.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
				useReadLock = 0;
			}
			else
			{
				useReadLock = 0;
			}
			TList<Sensor> tList = new TList<Sensor>((byte)useReadLock != 0);
			foreach (ActiveUnit item in list_2)
			{
				Sensor[] sensors_Cached = item.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsOECM && sensor.IsActive() && sensor.get_CanJamThisSensor(this))
					{
						tList.Add(sensor);
					}
				}
			}
			float originalBearing = Math2.CalcAzimuth(ParentPlatform.get_Latitude(GlobalVariables.ObjectTrue), ParentPlatform.get_Longitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue));
			int count = tList.Count;
			RadarModel.TJammer[] array = new RadarModel.TJammer[count - 1 + 1];
			double[] array2 = new double[count - 1 + 1];
			double[] array3 = new double[count - 1 + 1];
			int num3 = count - 1;
			for (int j = 0; j <= num3; j++)
			{
				Sensor sensor2 = tList[j];
				RadarModel.TJammer tJammer = new RadarModel.TJammer();
				tJammer.Bandwidth = sensor2.ECM_Bandwidth;
				tJammer.Altitude = sensor2.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				tJammer.Frequency = tradar_0.Frequency;
				tJammer.Gain = sensor2.ECM_Gain;
				tJammer.OutputW = sensor2.ECM_PeakPower;
				if (!Codes.AESA)
				{
					if (Codes.PESA)
					{
						tJammer.OutputW *= 0.5;
					}
				}
				else
				{
					tJammer.OutputW *= 0.1;
				}
				int num4 = TechGeneration - sensor2.TechGeneration;
				if (num4 < -3)
				{
					tJammer.OutputW *= 20.0;
				}
				else if (num4 == -3)
				{
					tJammer.OutputW *= 10.0;
				}
				else if (num4 == -2)
				{
					tJammer.OutputW *= 5.0;
				}
				else if (num4 == -1)
				{
					tJammer.OutputW *= 2.0;
				}
				else if (num4 != 0)
				{
					if (num4 == 1)
					{
						tJammer.OutputW *= 0.5;
					}
					else if (num4 == 2)
					{
						tJammer.OutputW *= 0.2;
					}
					else if (num4 == 3)
					{
						tJammer.OutputW *= 0.1;
					}
					else if (num4 > 3)
					{
						tJammer.OutputW *= 0.05;
					}
				}
				array[j] = tJammer;
				float num5 = Module_Unit.RangeToUnit_Slant(ParentPlatform, sensor2.ParentPlatform);
				array2[j] = num5;
				float num6 = MathFunctions.AngularDifference(originalBearing, Math2.CalcAzimuth(ParentPlatform.get_Latitude(GlobalVariables.ObjectTrue), ParentPlatform.get_Longitude(GlobalVariables.ObjectTrue), sensor2.ParentPlatform.get_Latitude(GlobalVariables.ObjectTrue), sensor2.ParentPlatform.get_Longitude(GlobalVariables.ObjectTrue)));
				array3[j] = num6;
			}
			int num7;
			if (Codes.AESA)
			{
				num7 = 0;
			}
			else
			{
				bool flag = false;
				double num8 = 1.0;
				foreach (ChaffCorridorCloud chaffCloud in ParentPlatform.ParentScen.ChaffClouds)
				{
					if (!Capabilities.AltitudeInfo || (!(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)chaffCloud.CurtainCeiling) && !(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)chaffCloud.CurtainFloor)))
					{
						Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(((Module_Unit.Unit)chaffCloud).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)chaffCloud).get_Longitude((GlobalVariables.BooleanObject)null), chaffCloud.CoverageLength, chaffCloud.CoverageWidth, chaffCloud.CurrentHeading);
						if (((Module_Unit.Unit)activeUnit_0).get_IsInsideThisArea(rectangularArea, ParentPlatform.ParentScen, UseCache: false))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					num7 = 0;
				}
				else
				{
					RadioElectronicFrequency[] array4 = null;
					switch (activeEmissionMode_0)
					{
					case ActiveEmissionMode.Illuminate:
						array4 = IlluminationFreqs;
						break;
					case ActiveEmissionMode.Search_Track:
						array4 = SearchFreqs;
						break;
					}
					RadioElectronicFrequency[] array5 = array4;
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						FrequencyBand band = array5[k].Band;
						FrequencyBand num9 = band - 1001L;
						if ((ulong)num9 <= 11uL)
						{
							switch (num9)
							{
							case (FrequencyBand)0L:
							case (FrequencyBand)1L:
							case (FrequencyBand)2L:
								num8 = Math.Min(0.05, num8);
								continue;
							case (FrequencyBand)3L:
							case (FrequencyBand)4L:
							case (FrequencyBand)5L:
								num8 = Math.Min(0.1, num8);
								continue;
							case (FrequencyBand)6L:
							case (FrequencyBand)7L:
							case (FrequencyBand)8L:
								num8 = Math.Min(0.15, num8);
								continue;
							case (FrequencyBand)9L:
							case (FrequencyBand)10L:
							case (FrequencyBand)11L:
								num8 = Math.Min(0.2, num8);
								continue;
							}
						}
						num8 = Math.Min(0.25, num8);
					}
					GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
					if (techGeneration < GlobalVariables.TechGenerationClass.const_3)
					{
						num8 *= 0.1;
					}
					else if (techGeneration == GlobalVariables.TechGenerationClass.const_4)
					{
						num8 *= 0.15;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_5)
					{
						num8 *= 0.2;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_6)
					{
						num8 *= 0.3;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_7)
					{
						num8 *= 0.4;
					}
					else
					{
						switch (techGeneration)
						{
						case GlobalVariables.TechGenerationClass.const_8:
							num8 *= 0.5;
							break;
						case GlobalVariables.TechGenerationClass.const_9:
							num8 *= 0.6;
							break;
						case GlobalVariables.TechGenerationClass.const_10:
							num8 *= 0.7;
							break;
						default:
							switch (techGeneration)
							{
							case GlobalVariables.TechGenerationClass.const_10:
								num8 *= 0.8;
								break;
							case GlobalVariables.TechGenerationClass.const_11:
								num8 *= 0.9;
								break;
							}
							break;
						}
					}
					num8 = Math.Min(1.0, num8);
					tTarget.RCS_m2 *= num8;
					num7 = 0;
				}
			}
			RadarModel.TSurfaceType terrainType = (RadarModel.TSurfaceType)num7;
			float num10 = 0f;
			RadarModel.RadarClutterType clutterTypeToUse = default(RadarModel.RadarClutterType);
			if (tradar_0.ElevationAngle > 0.0)
			{
				clutterTypeToUse = RadarModel.RadarClutterType.None;
			}
			else
			{
				int num11;
				if (Codes.AESA && activeEmissionMode_0 == ActiveEmissionMode.Illuminate)
				{
					num11 = 0;
				}
				else
				{
					if (!ParentPlatform.Sensory.UnitIsPreviouslyDetected(activeUnit_0))
					{
						if (activeUnit_0.IsShip || activeUnit_0.IsSubmarine || (activeUnit_0.IsAircraft && !Module_Unit.IsOverLand(activeUnit_0)))
						{
							Terrain.LandPercentageInThisSquare(activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), 2f);
							terrainType = RadarModel.TSurfaceType.st_Mountains;
						}
						num10 = Terrain.GetMaxSlope(activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, ParentPlatform.ParentScen);
						if (Terrain.GetElevation(activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, ParentPlatform.ParentScen) <= 0)
						{
							terrainType = RadarModel.TSurfaceType.st_Wetland;
						}
						else
						{
							float num12 = num10;
							terrainType = ((num12 < 0.1f) ? RadarModel.TSurfaceType.st_Wetland : ((num12 < 0.2f) ? RadarModel.TSurfaceType.st_Forest : ((num12 < 0.3f) ? RadarModel.TSurfaceType.st_Shrubland : ((!(num12 < 0.4f)) ? RadarModel.TSurfaceType.st_Mountains : RadarModel.TSurfaceType.st_Cropland))));
						}
						goto IL_0b9d;
					}
					num11 = 0;
				}
				clutterTypeToUse = (RadarModel.RadarClutterType)num11;
			}
			goto IL_0b9d;
			IL_0b9d:
			result = RadarModel.RadarECMEquation(tradar_0, tTarget, count, array, float_10, array2, array3, weatherProfile_0, clutterTypeToUse, TechGeneration, 0.0, 0.0, ref RadarReceiver, num2, terrainType, num10);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100743", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num13;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num13 = 0;
			}
			else
			{
				num13 = 0;
			}
			result = (byte)num13 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static XSection smethod_0(ActiveUnit theUnit, XSection._SignatureType DesiredSignatureType)
	{
		XSection result;
		try
		{
			XSection[] xSections_ReadOnly = theUnit.XSections_ReadOnly;
			int num = xSections_ReadOnly.Length - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					XSection xSection = xSections_ReadOnly[num2];
					if (xSection == null || xSection.SignatureType != DesiredSignatureType)
					{
						num2++;
						continue;
					}
					result = xSection;
					break;
				}
				result = null;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200034", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float GetLandCoverMaxDetectionRangeModifier_Visual(LandCover.LandCoverType theLandCover)
	{
		float result = 1f;
		switch (theLandCover)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.5f;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.75f;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.9f;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.85f;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	internal float MaxDetectionRangeOnThisTarget_Visual(ActiveUnit myParent, ActiveUnit theUnit, bool ConsiderTerrainEffects_DetectorAndTarget, bool ConsiderTerrainEffects_BlockageOnLOSPath, bool ConsiderWeather, float TargetAspect = -1f)
	{
		float result;
		try
		{
			int num;
			if (TargetAspect == -1f)
			{
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				TargetAspect = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, theUnit, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
				num = 3001;
			}
			else
			{
				num = 3001;
			}
			XSection._SignatureType desiredSignatureType = (XSection._SignatureType)num;
			XSection xSection = smethod_0(theUnit, desiredSignatureType);
			if (xSection == null)
			{
				xSection = smethod_0(theUnit, desiredSignatureType);
			}
			if (xSection != null)
			{
				if (!xSection.isDBInvisible(theUnit))
				{
					float num2 = default(float);
					if (!(TargetAspect >= 315f) && TargetAspect > 45f)
					{
						if ((TargetAspect >= 45f && TargetAspect <= 135f) || (TargetAspect >= 225f && TargetAspect <= 315f))
						{
							num2 = xSection.get_Side(theUnit);
						}
						else if (TargetAspect >= 135f && TargetAspect <= 225f)
						{
							num2 = xSection.get_Rear(theUnit);
						}
					}
					else
					{
						num2 = xSection.get_Front(theUnit);
					}
					num2 += theUnit.GetTemporarySignature(XSection._SignatureType.Visual_Detect, ActiveUnit.Str_TemporaryEmission.SignatureOperator.Absolute);
					bool flag = default(bool);
					if (myParent != null && myParent.get_UnitSide(SetSideOnly: false) != null && myParent.get_UnitSide(SetSideOnly: false).Contacts != null && theUnit != null)
					{
						flag = myParent.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(theUnit.ObjectID);
					}
					float num3 = ((!flag || !(VisualClassZoomLevel > VisualDetectionZoomLevel)) ? (num2 * VisualDetectionZoomLevel) : (num2 * VisualClassZoomLevel));
					Side natureSide = theUnit.ParentScen.GetNatureSide();
					if (ConsiderTerrainEffects_DetectorAndTarget && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
					{
						if ((theUnit.IsFacility || theUnit.IsMobileGroundUnit || theUnit.IsAircraft) && ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen) > 0)
						{
							(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.ParentScen, natureSide);
							if (!theUnit.IsAircraft || theUnit.CurrentAltitude_AGL < (float)landCoverAndHeightAtThisPoint.Item2)
							{
								float landCoverMaxDetectionRangeModifier_Visual = GetLandCoverMaxDetectionRangeModifier_Visual(landCoverAndHeightAtThisPoint.Item1);
								num3 *= landCoverMaxDetectionRangeModifier_Visual;
							}
						}
						if (myParent != null && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced))
						{
							float num4 = myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)myParent).get_MastHeight_Visual(this);
							if ((myParent.IsFacility || myParent.IsMobileGroundUnit || myParent.IsAircraft) && myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation)
							{
								int elevation = Terrain.GetElevation(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen);
								if (elevation > 0)
								{
									(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), myParent.ParentScen, natureSide);
									if (num4 - (float)elevation < (float)landCoverAndHeightAtThisPoint.Item2)
									{
										float landCoverMaxDetectionRangeModifier_Visual2 = GetLandCoverMaxDetectionRangeModifier_Visual(landCoverAndHeightAtThisPoint.Item1);
										num3 *= landCoverMaxDetectionRangeModifier_Visual2;
									}
								}
							}
						}
					}
					if (ConsiderTerrainEffects_BlockageOnLOSPath && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && myParent != null && !myParent.IsSatellite && !theUnit.IsSatellite)
					{
						float startAlt = myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)myParent).get_MastHeight_Visual(this);
						if (bool_1)
						{
							List<(LandCover.LandCoverType, int)> list = LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), startAlt, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myParent.ParentScen, natureSide).ToList();
							foreach (var item in list)
							{
								float landCoverMaxDetectionRangeModifier_Visual3 = GetLandCoverMaxDetectionRangeModifier_Visual(item.Item1);
								num3 *= landCoverMaxDetectionRangeModifier_Visual3;
							}
						}
					}
					num3 *= theUnit.GetTemporarySignature(XSection._SignatureType.Visual_Detect, ActiveUnit.Str_TemporaryEmission.SignatureOperator.Factor);
					if (ConsiderWeather)
					{
						method_14(myParent, theUnit, ref num3);
					}
					result = Math.Min(maxRange, num3);
				}
				else
				{
					result = 0f;
				}
			}
			else
			{
				result = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100719", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float GetLandCoverMaxDetectionRangeModifier_IR(LandCover.LandCoverType theLandCover)
	{
		float result = 1f;
		switch (theLandCover)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.5f;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.75f;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.9f;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.85f;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	internal float MaxDetectionRangeOnThisTarget_IR(ActiveUnit myParent, ActiveUnit theUnit, bool IgnoreTerrainEffects = false, bool ConsiderLandCoverBetweenPoints = true)
	{
		float result;
		try
		{
			ActiveUnit parentPlatform = ParentPlatform;
			string feedbackMessage = "";
			float num = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, theUnit, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
			XSection xSection = smethod_0(theUnit, XSection._SignatureType.IR_Detect);
			bool flag;
			Side natureSide;
			float num3;
			if (xSection != null)
			{
				if (!xSection.isDBInvisible(theUnit))
				{
					float num2 = default(float);
					if (!(num >= 315f) && num > 45f)
					{
						if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
						{
							num2 = xSection.get_Side(theUnit);
						}
						else if (num >= 135f && num <= 225f)
						{
							num2 = xSection.get_Rear(theUnit);
						}
					}
					else
					{
						num2 = xSection.get_Front(theUnit);
					}
					num2 += theUnit.GetTemporarySignature(XSection._SignatureType.IR_Detect, ActiveUnit.Str_TemporaryEmission.SignatureOperator.Absolute);
					num3 = ((myParent.get_UnitSide(SetSideOnly: false) == null) ? (num2 * float_2) : ((!myParent.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(theUnit.ObjectID) || !(IRClassZoomLevel > float_2)) ? (num2 * float_2) : (num2 * IRClassZoomLevel)));
					switch (TechGeneration)
					{
					case GlobalVariables.TechGenerationClass.IR_DualSpectral:
						num3 = (float)((double)num3 * 1.8);
						break;
					case GlobalVariables.TechGenerationClass.IR_Imaging_FPA:
						num3 = (float)((double)num3 * 2.5);
						break;
					}
					flag = IgnoreTerrainEffects;
					if (!IgnoreTerrainEffects && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
					{
						float num4 = 1f;
						natureSide = theUnit.ParentScen.GetNatureSide();
						if ((theUnit.IsFacility || theUnit.IsMobileGroundUnit || theUnit.IsAircraft) && ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen) > 0)
						{
							(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.ParentScen, natureSide);
							int num5;
							if (!theUnit.IsAircraft)
							{
								num5 = 1;
							}
							else
							{
								if (!(theUnit.CurrentAltitude_AGL < (float)landCoverAndHeightAtThisPoint.Item2))
								{
									goto IL_0229;
								}
								num5 = 1;
							}
							flag = (byte)num5 != 0;
							num4 = GetLandCoverMaxDetectionRangeModifier_IR(landCoverAndHeightAtThisPoint.Item1);
							num3 *= num4;
						}
						goto IL_0229;
					}
					goto IL_0399;
				}
				result = 0f;
			}
			else
			{
				result = 0f;
			}
			goto end_IL_0001;
			IL_0229:
			if (myParent != null && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced))
			{
				float num6 = myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)myParent).get_MastHeight_Visual(this);
				if ((myParent.IsFacility || myParent.IsMobileGroundUnit || myParent.IsAircraft) && myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation)
				{
					int elevation = Terrain.GetElevation(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen);
					if (elevation > 0)
					{
						(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), myParent.ParentScen, natureSide);
						if (num6 - (float)elevation < (float)landCoverAndHeightAtThisPoint.Item2)
						{
							float num4 = GetLandCoverMaxDetectionRangeModifier_IR(landCoverAndHeightAtThisPoint.Item1);
							num3 *= num4;
						}
					}
				}
				if (bool_1 && ConsiderLandCoverBetweenPoints && myParent.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && !myParent.IsSatellite && !theUnit.IsSatellite)
				{
					IEnumerable<(LandCover.LandCoverType, int)> allLandCoverAndCoverElevationBetweenPoints = LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(myParent.get_Latitude((GlobalVariables.BooleanObject)null), myParent.get_Longitude((GlobalVariables.BooleanObject)null), num6, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myParent.ParentScen, natureSide);
					foreach (var item in allLandCoverAndCoverElevationBetweenPoints)
					{
						float num4 = GetLandCoverMaxDetectionRangeModifier_Visual(item.Item1);
						num3 *= num4;
					}
				}
			}
			goto IL_0399;
			IL_0399:
			if (!flag && myParent.IsAerospaceUnit)
			{
				double num7 = myParent.RangeToUnit_Horiz(theUnit) * 1852f;
				double num8 = Math.Atan2(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), num7);
				double num9 = (double)Module_Unit.BearingToUnit_Relative(myParent, theUnit, GlobalVariables.ObjectTrue) * 0.0174532925199433;
				new Vector3D(num7 * Math.Sin(num8) * Math.Cos(num9), num7 * Math.Sin(num8) * Math.Sin(num9), num7 * Math.Cos(num8));
				Horizon.HorizonResult horizonResult = Horizon.OverUnderHorizonCheck(myParent.get_Latitude(GlobalVariables.ObjectTrue), myParent.get_Longitude(GlobalVariables.ObjectTrue), myParent.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), theUnit.get_Latitude(GlobalVariables.ObjectTrue), theUnit.get_Longitude(GlobalVariables.ObjectTrue), theUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue));
				if (!horizonResult.IsAboveHorizon)
				{
					switch (LandCover.GetLandCoverAtThisPoint(horizonResult.IntersectionLat, horizonResult.IntersectionLon, myParent.ParentScen))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case LandCover.LandCoverType.Urban_CloseInnerCity:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedHighRise:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_AttachedHouses:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_CloseIndustrial:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedApartments:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_DetachedHouses:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_ShantyTown:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Water:
					{
						int seaState = Weather.get_WeatherAtThisTimeAndPlace(myParent.ParentScen, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), 0).SeaState;
						num3 = (float)((double)num3 * (1.0 - (0.2 + (double)seaState * 0.05)));
						break;
					}
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num3 = (float)((double)num3 * 0.4);
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num3 = (float)((double)num3 * 0.65);
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						num3 = (float)((double)num3 * 0.75);
						break;
					case LandCover.LandCoverType.Permanent_wetlands:
						num3 = (float)((double)num3 * 0.9);
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num3 = (float)((double)num3 * 0.75);
						break;
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						num3 = (float)((double)num3 * 0.9);
						break;
					case LandCover.LandCoverType.SnowAndIce:
						break;
					}
				}
			}
			num3 *= theUnit.GetTemporarySignature(XSection._SignatureType.IR_Detect, ActiveUnit.Str_TemporaryEmission.SignatureOperator.Factor);
			method_13(myParent, theUnit, ref num3);
			if (theUnit.IsAircraft)
			{
				if (((Aircraft)theUnit).IRSS_ShieldedExhaustAntiStrela && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					num3 = (float)((double)num3 * 0.9);
				}
				else if (((Aircraft)theUnit).IRSS_MaskedExhaust_Slit && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > myParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					num3 = (float)(1.3 * (double)num3);
				}
			}
			result = Math.Min(maxRange, num3);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100720", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float MaxIDRangeOnThisTarget(ActiveUnit myParent, ActiveUnit theUnit)
	{
		return Type switch
		{
			Sensor_Type.Radar => method_10(theUnit), 
			Sensor_Type.Visual => method_9(myParent, theUnit), 
			Sensor_Type.Infrared => method_11(myParent, theUnit), 
			_ => 0f, 
		};
	}

	private float method_9(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		float result;
		if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0)
		{
			result = 0f;
		}
		else
		{
			try
			{
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				float num = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
				XSection._SignatureType desiredSignatureType = XSection._SignatureType.Visual_ID;
				XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.Visual_ID);
				if (Information.IsNothing((object)xSection))
				{
					xSection = smethod_0(activeUnit_1, desiredSignatureType);
				}
				if (Information.IsNothing((object)xSection))
				{
					result = 0f;
				}
				else if (!xSection.isDBInvisible(activeUnit_1))
				{
					float num2 = default(float);
					if (!(num >= 315f) && num > 45f)
					{
						if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
						{
							num2 = xSection.get_Side(activeUnit_1);
						}
						else if (num >= 135f && num <= 225f)
						{
							num2 = xSection.get_Rear(activeUnit_1);
						}
					}
					else
					{
						num2 = xSection.get_Front(activeUnit_1);
					}
					float float_ = num2 * VisualClassZoomLevel;
					method_14(activeUnit_0, activeUnit_1, ref float_);
					result = float_;
				}
				else
				{
					result = 0f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100721", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	private float method_10(ActiveUnit activeUnit_0)
	{
		if (Codes.Classification)
		{
			return maxRange / 4f;
		}
		return 0f;
	}

	private float method_11(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		float result;
		if (!activeUnit_1.IsSubmarine || ((Submarine)activeUnit_1).IsSurfaced)
		{
			try
			{
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				float num = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
				XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.IR_ID);
				if (xSection != null)
				{
					if (!xSection.isDBInvisible(activeUnit_1))
					{
						float num2 = default(float);
						if (!(num >= 315f) && num > 45f)
						{
							if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
							{
								num2 = xSection.get_Side(activeUnit_1);
							}
							else if (num >= 135f && num <= 225f)
							{
								num2 = xSection.get_Rear(activeUnit_1);
							}
						}
						else
						{
							num2 = xSection.get_Front(activeUnit_1);
						}
						float float_ = num2 * IRClassZoomLevel;
						method_13(activeUnit_0, activeUnit_1, ref float_);
						result = float_;
					}
					else
					{
						result = 0f;
					}
				}
				else
				{
					result = 0f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100722", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = 0f;
		}
		return result;
	}

	private void method_12(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_9)
	{
		if (float_9 != 0f)
		{
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(activeUnit_1.ParentScen, activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), 0);
			float rainfallRate = weatherProfile.RainfallRate;
			if (rainfallRate > 40f)
			{
				float_9 = (float)((double)float_9 * 0.05);
			}
			else if (rainfallRate > 30f)
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
			else if (rainfallRate > 20f)
			{
				float_9 = (float)((double)float_9 * 0.25);
			}
			else if (rainfallRate > 10f)
			{
				float_9 = (float)((double)float_9 * 0.5);
			}
			else if (rainfallRate > 0f)
			{
				float_9 = (float)((double)float_9 * 0.75);
			}
			smethod_1(weatherProfile, activeUnit_0, activeUnit_1, ref float_9);
		}
	}

	private void method_13(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_9)
	{
		if (float_9 != 0f)
		{
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(activeUnit_1.ParentScen, activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), 0);
			float rainfallRate = weatherProfile.RainfallRate;
			if (rainfallRate > 40f)
			{
				float_9 = (float)((double)float_9 * 0.05);
			}
			else if (rainfallRate > 30f)
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
			else if (rainfallRate > 20f)
			{
				float_9 = (float)((double)float_9 * 0.25);
			}
			else if (rainfallRate > 10f)
			{
				float_9 = (float)((double)float_9 * 0.5);
			}
			else if (rainfallRate > 0f)
			{
				float_9 = (float)((double)float_9 * 0.75);
			}
			smethod_1(weatherProfile, activeUnit_0, activeUnit_1, ref float_9);
		}
	}

	private void method_14(ActiveUnit activeUnit_0, Module_Unit.Unit unit_0, ref float float_9)
	{
		if (float_9 == 0f)
		{
			return;
		}
		double num;
		double num2;
		if (unit_0.IsActiveUnit)
		{
			GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(((ActiveUnit)unit_0).IsOperating());
			num = unit_0.get_Longitude(hintIsOperating);
			num2 = unit_0.get_Latitude(hintIsOperating);
		}
		else
		{
			num = unit_0.get_Longitude((GlobalVariables.BooleanObject)null);
			num2 = unit_0.get_Latitude((GlobalVariables.BooleanObject)null);
		}
		try
		{
			if (!Codes.VisualNightCapable)
			{
				DateTime time = activeUnit_0.ParentScen.Time;
				Weather.TTimeOfDayType tTimeOfDayType;
				try
				{
					tTimeOfDayType = SunModule.GetTimeOfDay(activeUnit_0.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, num2, num, 0.0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					tTimeOfDayType = SunModule.GetTimeOfDayTypeFromLocalTime(Misc.LocalTime(activeUnit_0.ParentScen.Time, num, activeUnit_0.ParentScen.Use_DST, activeUnit_0.ParentScen.DST_Start, activeUnit_0.ParentScen.DST_End));
					ProjectData.ClearProjectError();
				}
				float num3 = default(float);
				float num4 = default(float);
				switch (tTimeOfDayType)
				{
				case Weather.TTimeOfDayType.tod_Day:
					num3 = 1f;
					num4 = 1f;
					break;
				case Weather.TTimeOfDayType.tod_Twilight:
					num3 = 0.75f;
					num4 = 0.8f;
					break;
				case Weather.TTimeOfDayType.tod_Night:
					num3 = 0.35f;
					num4 = 0.45f;
					break;
				}
				if (!unit_0.IsAircraft && !unit_0.IsMissile)
				{
					float_9 *= num4;
				}
				else
				{
					float_9 *= num3;
				}
			}
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(activeUnit_0.ParentScen, num2, num, 0);
			float rainfallRate = weatherProfile.RainfallRate;
			if (rainfallRate > 40f)
			{
				float_9 = (float)((double)float_9 * 0.2);
			}
			else if (rainfallRate > 30f)
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
			else if (rainfallRate > 20f)
			{
				float_9 = (float)((double)float_9 * 0.5);
			}
			else if (rainfallRate > 10f)
			{
				float_9 = (float)((double)float_9 * 0.7);
			}
			else if (rainfallRate > 0f)
			{
				float_9 = (float)((double)float_9 * 0.9);
			}
			smethod_1(weatherProfile, activeUnit_0, unit_0, ref float_9);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100723", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_1(Weather.WeatherProfile weatherProfile_0, Module_Unit.Unit unit_0, Module_Unit.Unit unit_1, ref float float_9)
	{
		float fractionUnderRain = weatherProfile_0.FractionUnderRain;
		if (fractionUnderRain > 0.9f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((10972.8f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (10972.8f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
			else if (609.60004f > currentAltitude_AGL || 609.60004f > currentAltitude_AGL2)
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
		}
		else if (fractionUnderRain > 0.8f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((10972.8f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (10972.8f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
			else if (609.60004f > currentAltitude_AGL || 609.60004f > currentAltitude_AGL2)
			{
				float_9 = (float)((double)float_9 * 0.2);
			}
		}
		else if (fractionUnderRain > 0.7f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
			{
				float_9 = (float)((double)float_9 * 0.1);
			}
			else if ((10972.8f > currentAltitude_AGL && currentAltitude_AGL > 9144f) || (10972.8f > currentAltitude_AGL2 && currentAltitude_AGL2 > 9144f))
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
		}
		else if (fractionUnderRain > 0.6f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
			else if ((9144f > currentAltitude_AGL && currentAltitude_AGL > 8229.601f) || (9144f > currentAltitude_AGL2 && currentAltitude_AGL2 > 8229.601f))
			{
				float_9 = (float)((double)float_9 * 0.7);
			}
		}
		else if (fractionUnderRain > 0.5f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((8534.4f > currentAltitude_AGL && currentAltitude_AGL > 7620f) || (8534.4f > currentAltitude_AGL2 && currentAltitude_AGL2 > 7620f))
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
		}
		else if (fractionUnderRain > 0.4f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
		}
		else if (fractionUnderRain > 0.3f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((2133.6f > currentAltitude_AGL && currentAltitude_AGL > 609.60004f) || (2133.6f > currentAltitude_AGL2 && currentAltitude_AGL2 > 609.60004f))
			{
				float_9 = (float)((double)float_9 * 0.3);
			}
		}
		else if (fractionUnderRain > 0.2f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((7010.4f > currentAltitude_AGL && currentAltitude_AGL > 6096f) || (7010.4f > currentAltitude_AGL2 && currentAltitude_AGL2 > 6096f))
			{
				float_9 = (float)((double)float_9 * 0.7);
			}
		}
		else if (fractionUnderRain > 0.1f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 3048f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 3048f))
			{
				float_9 = (float)((double)float_9 * 0.7);
			}
		}
		else if (fractionUnderRain > 0f)
		{
			float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
			float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
			if ((2133.6f > currentAltitude_AGL && currentAltitude_AGL > 1524f) || (2133.6f > currentAltitude_AGL2 && currentAltitude_AGL2 > 1524f))
			{
				float_9 = (float)((double)float_9 * 0.7);
			}
		}
	}

	private bool method_15(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref Module_Unit.Unit.LOSCheckResult? nullable_3, bool bool_3 = false, bool bool_4 = false)
	{
		GlobalVariables.BooleanObject LocalResult = null;
		bool result;
		if (smethod_0(activeUnit_1, XSection._SignatureType.Visual_Detect).isDBInvisible(activeUnit_1) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.DB_Invisible, ref LocalResult).HasValue)
		{
			result = false;
		}
		else
		{
			try
			{
				if (!activeUnit_0.IsAircraft || !IsMk1Eyeball)
				{
					goto IL_0339;
				}
				double num = (double)float_9 * 1852.0;
				double num2 = Math.Atan2(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), num);
				double num3 = (double)Module_Unit.BearingToUnit_Relative(activeUnit_0, activeUnit_1, GlobalVariables.ObjectTrue) * 0.0174532925199433;
				Vector3D vector3D = new Vector3D(num * Math.Sin(num2) * Math.Cos(num3), num * Math.Sin(num2) * Math.Sin(num3), num * Math.Cos(num2));
				Matrix3D identity = Matrix3D.Identity;
				double num4 = (double)(0f - activeUnit_0.Attitude_Roll) * 0.0174532925199433;
				double num5 = Math.Sin(num4);
				double m = (identity.M22 = Math.Cos(num4));
				identity.M23 = num5;
				identity.M32 = 0.0 - num5;
				identity.M33 = m;
				Matrix3D identity2 = Matrix3D.Identity;
				double num7 = (double)(0f - activeUnit_0.Attitude_Pitch) * 0.0174532925199433;
				double num8 = Math.Sin(num7);
				double m2 = (identity2.M11 = Math.Cos(num7));
				identity2.M13 = 0.0 - num8;
				identity2.M31 = num8;
				identity2.M33 = m2;
				_ = identity2 * identity * vector3D;
				double num10 = Math.Atan2(vector3D.Y, vector3D.GetLength()) * 57.2957795130823;
				double num11 = Module_Unit.BearingToUnit_Relative(activeUnit_0, activeUnit_1, GlobalVariables.ObjectTrue);
				if (!(num10 < -45.0) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_VerticalViewAngle45deg, ref LocalResult).HasValue)
				{
					switch ((num11 >= 315.0 || !(num11 > 45.0)) ? ((Aircraft)activeUnit_0).VisibilityForward : ((num11 > 45.0 && num11 < 135.0) ? ((Aircraft)activeUnit_0).VisibilitySideways : ((!(num11 >= 135.0) || !(num11 <= 225.0)) ? ((Aircraft)activeUnit_0).VisibilitySideways : ((Aircraft)activeUnit_0).VisibilityAft)))
					{
					case Aircraft.CockpitVisibility.Excellent:
						if (GameGeneral.GlobalRNG.Next(1, 101) <= 95 || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_RNG_ExcellentCockpitVisibility, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0037;
					case Aircraft.CockpitVisibility.Average:
						if (num10 < -25.0 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_AverageCockpitVisibility_VerticalViewAngle25deg, ref LocalResult).HasValue)
						{
							result = false;
						}
						else
						{
							if (GameGeneral.GlobalRNG.Next(1, 101) <= 50 || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_RNG_AverageCockpitVisibility, ref LocalResult).HasValue)
							{
								break;
							}
							result = false;
						}
						goto end_IL_0037;
					case Aircraft.CockpitVisibility.Poor:
						if (GameGeneral.GlobalRNG.Next(1, 101) <= 2 || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_RNG_PoorCockpitVisibility, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0037;
					}
					goto IL_0339;
				}
				result = false;
				goto end_IL_0037;
				IL_03c8:
				if (activeUnit_1.IsSubmarine && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= -20f)
				{
					switch (((Submarine)activeUnit_1).Type)
					{
					case Submarine._SubmarineType.None:
					case Submarine._SubmarineType.Biologics:
					case Submarine._SubmarineType.FalseTarget:
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_LOS, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0037;
					case Submarine._SubmarineType.SDV:
					case Submarine._SubmarineType.ROV:
					case Submarine._SubmarineType.UUV:
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_LOS, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0037;
					}
				}
				bool num12 = activeUnit_1.IsShip || activeUnit_1.IsSubmarine;
				bool flag = activeUnit_1.IsMobileGroundUnit && !Module_Unit.IsOverLand(activeUnit_1);
				bool num13 = num12 || flag;
				bool flag2 = activeUnit_0.IsAircraft || activeUnit_0.IsMissile || activeUnit_0.IsSatellite;
				bool flag3 = default(bool);
				if (num13 && flag2)
				{
					float float_10 = 0f;
					Ship.ShipWakeSize wakeSize = default(Ship.ShipWakeSize);
					if (activeUnit_1.IsShip)
					{
						wakeSize = ((Ship)activeUnit_1).WakeSize;
					}
					if (activeUnit_1.IsSubmarine)
					{
						wakeSize = ((Submarine)activeUnit_1).WakeSize;
					}
					if (activeUnit_1.IsVehicle)
					{
						wakeSize = ((Vehicle)activeUnit_1).WakeSize;
					}
					switch (wakeSize)
					{
					case Ship.ShipWakeSize.NoWake:
						float_10 = 0f;
						break;
					case Ship.ShipWakeSize.VSmall:
						float_10 = 3f;
						break;
					case Ship.ShipWakeSize.Small:
						float_10 = 10f;
						break;
					case Ship.ShipWakeSize.Medium:
						float_10 = 19f;
						break;
					case Ship.ShipWakeSize.Large:
						float_10 = 25f;
						break;
					case Ship.ShipWakeSize.VLarge:
						float_10 = 32f;
						break;
					}
					method_14(activeUnit_0, activeUnit_1, ref float_10);
					flag3 = float_10 > float_9;
				}
				bool flag4 = default(bool);
				if (activeUnit_1.IsAircraft)
				{
					float float_11 = 0f;
					switch (activeUnit_1.ContrailSize())
					{
					case ActiveUnit.AirContrailSize.NoContrail:
						float_11 = 0f;
						break;
					case ActiveUnit.AirContrailSize.VSmall:
						float_11 = 2f;
						break;
					case ActiveUnit.AirContrailSize.Small:
						float_11 = 10f;
						break;
					case ActiveUnit.AirContrailSize.Medium:
						float_11 = 20f;
						break;
					case ActiveUnit.AirContrailSize.Large:
						float_11 = 30f;
						break;
					case ActiveUnit.AirContrailSize.VLarge:
						float_11 = 50f;
						break;
					}
					if (activeUnit_0.IsAircraft && flag3)
					{
						float num14 = 1f;
						num14 = ((!(num10 < 0.0)) ? 0.9f : (LandCover.GetLandCoverAtThisPoint(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.ParentScen) switch
						{
							LandCover.LandCoverType.SnowAndIce => 1f, 
							LandCover.LandCoverType.Water => 0.8f, 
							_ => 0.7f, 
						}));
						flag3 = float_9 * num14 > float_9;
					}
					method_14(activeUnit_0, activeUnit_1, ref float_11);
					flag4 = float_11 > float_9;
				}
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				float targetAspect = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
				if (activeUnit_1.IsPlatform && ((Platform)activeUnit_1).RepresentsMobileGroundUnit && Module_Unit.IsOverLand(activeUnit_1))
				{
					bool num15 = activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit;
					bool flag5 = activeUnit_1.CurrentSpeed > 0f;
					if (num15 && flag5)
					{
						flag3 = (float)(int)Math.Round(MaxDetectionRangeOnThisTarget_Visual(activeUnit_0, activeUnit_1, ConsiderTerrainEffects_DetectorAndTarget: true, ConsiderTerrainEffects_BlockageOnLOSPath: true, ConsiderWeather: true, targetAspect) * (1f + activeUnit_1.CurrentSpeed / 10f)) > float_9;
					}
				}
				bool flag6;
				bool flag7;
				if (!(flag6 = float_9 <= maxRange) && !flag3 && !flag4 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_MaxNominalRange, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (!(flag7 = flag6 && !flag3 && !flag4) || activeUnit_0.IsSatellite || activeUnit_0.IsWeapon)
					{
						goto IL_084b;
					}
					bool flag8 = false;
					if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
					{
						flag8 = activeUnit_0.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(activeUnit_1.ObjectID);
					}
					else
					{
						PooledList<Contact> pooledList = Module_ActiveUnit_Sensory.ContactsVisibleToMe(activeUnit_0.Sensory);
						Contact[] array = pooledList.InternalArray();
						int count = pooledList.Count;
						int num16 = count - 1;
						for (int i = 0; i <= num16; i++)
						{
							if (array[i]?.ActualUnit == activeUnit_1)
							{
								flag8 = true;
								break;
							}
						}
						if (!flag8)
						{
							int num17 = count - 1;
							for (int j = 0; j <= num17; j++)
							{
								if (Operators.CompareString(array[j]?.ActualUnit?.ObjectID, activeUnit_1.ObjectID, false) == 0)
								{
									flag8 = true;
									break;
								}
							}
						}
					}
					if (flag8)
					{
						goto IL_084b;
					}
					int num18 = VolumeSearchRange_Visual(this);
					if (!(float_9 > (float)num18))
					{
						goto IL_084b;
					}
					result = false;
				}
				goto end_IL_0037;
				IL_084b:
				if (!flag7)
				{
					goto IL_09a8;
				}
				if (MaxDetectionRangeOnThisTarget_Visual(activeUnit_0, activeUnit_1, ConsiderTerrainEffects_DetectorAndTarget: false, ConsiderTerrainEffects_BlockageOnLOSPath: false, ConsiderWeather: true, targetAspect) < float_9 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (bool_3)
					{
						goto IL_09a8;
					}
					float num19 = MaxDetectionRangeOnThisTarget_Visual(activeUnit_0, activeUnit_1, ConsiderTerrainEffects_DetectorAndTarget: true, ConsiderTerrainEffects_BlockageOnLOSPath: false, ConsiderWeather: true, targetAspect);
					if (!(num19 < float_9) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref LocalResult).HasValue)
					{
						if (activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && !activeUnit_0.IsSatellite && !activeUnit_1.IsSatellite)
						{
							Side natureSide = activeUnit_1.ParentScen.GetNatureSide();
							float startAlt = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)activeUnit_0).get_MastHeight_Visual(this);
							IEnumerable<(LandCover.LandCoverType, int)> allLandCoverAndCoverElevationBetweenPoints = LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), startAlt, activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit_0.ParentScen, natureSide);
							foreach (var item in allLandCoverAndCoverElevationBetweenPoints)
							{
								float landCoverMaxDetectionRangeModifier_Visual = GetLandCoverMaxDetectionRangeModifier_Visual(item.Item1);
								num19 *= landCoverMaxDetectionRangeModifier_Visual;
								if (!(num19 < float_9) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref LocalResult).HasValue)
								{
									continue;
								}
								result = false;
								goto end_IL_0037;
							}
						}
						goto IL_09a8;
					}
					result = false;
				}
				goto end_IL_0037;
				IL_0a6d:
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, ConsiderClouds: true);
				}
				bool flag9;
				result = ((flag9 = nullable_3.Value == Module_Unit.Unit.LOSCheckResult.Success || bool_4) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_LOS, ref LocalResult).HasValue) && (LocalResult?.ToBoolean() ?? flag9);
				goto end_IL_0037;
				IL_0339:
				if (bool_4 || !nullable_3.HasValue)
				{
					goto IL_03c8;
				}
				int? num20 = (int?)nullable_3;
				if (((!num20.HasValue) ? ((bool?)null) : new bool?(num20 != 1)) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_LOS, ref LocalResult).HasValue)
				{
					goto IL_03c8;
				}
				result = false;
				goto end_IL_0037;
				IL_09a8:
				if (!Capabilities.SpaceSearch_ABM || !activeUnit_1.IsWeapon)
				{
					goto IL_0a6d;
				}
				Weapon._WeaponType type = ((Weapon)activeUnit_1).Type;
				if ((uint)(type - 5000) > 1u && type != Weapon._WeaponType.HGV)
				{
					goto IL_0a6d;
				}
				float TargetAltitude = (int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (Horizon.VisualHorizonNM(activeUnit_0, ref TargetAltitude, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null)) && flag6)
				{
					if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.VISUAL_ABM_Horizon_Successful, ref LocalResult).HasValue)
					{
						goto IL_0a6d;
					}
					result = true;
				}
				else
				{
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.VISUAL_ABM_Horizon_Failed, ref LocalResult).HasValue)
					{
						goto IL_0a6d;
					}
					result = false;
				}
				end_IL_0037:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100724", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num21;
				if (!Debugger.IsAttached)
				{
					num21 = 0;
				}
				else
				{
					Debugger.Break();
					num21 = 0;
				}
				result = (byte)num21 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	private bool method_16(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref Dictionary<int, EmissionContainer> dictionary_0, ref bool? nullable_3, ref bool? nullable_4, bool bool_3 = false)
	{
		bool result;
		if (activeUnit_1.Sensory.GetIntermittentEmission().IsAllowedToEmit())
		{
			GlobalVariables.BooleanObject LocalResult = default(GlobalVariables.BooleanObject);
			if (!(maxRange >= float_9) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_MaxRange, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				try
				{
					Sensor[] sensors_Cached = activeUnit_1.Sensors_Cached;
					bool flag3 = default(bool);
					foreach (Sensor sensor in sensors_Cached)
					{
						if (!sensor.Capabilities.OTH_SurfaceWave)
						{
							if (nullable_3.HasValue)
							{
								bool? flag = nullable_3;
								if (((!flag) ?? flag) == true)
								{
									FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_RadarHorizonLOS, ref LocalResult);
									continue;
								}
							}
						}
						else if (nullable_4.HasValue)
						{
							bool? flag = nullable_4;
							if (((!flag) ?? flag) == true)
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_LOS, ref LocalResult);
								continue;
							}
						}
						if (sensor.Type != Sensor_Type.Radar && !sensor.IsOECM && !sensor.IsGNSSJammer && sensor.Type != Sensor_Type.NonDetectingEmitter)
						{
							continue;
						}
						if (sensor.IsActive())
						{
							if (!sensor.IsOperating)
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_EmitterNotActive, ref LocalResult);
								continue;
							}
							if (sensor.IsOECM && Role == Sensor_Role.ESM_RWR)
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_RWRvsJamming, ref LocalResult);
								continue;
							}
							if (!sensor.TargetIsWithinCoverageArc(activeUnit_0))
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_RWRvsJamming, ref LocalResult);
								continue;
							}
							if (!method_37(sensor))
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_IncompatibleFrequency, ref LocalResult);
								continue;
							}
							bool flag2;
							ActiveEmissionMode activeEmissionMode_ = ((flag2 = sensor.SemiActiveWeaponsGuided.Count > 0 || sensor.IsPureIlluminator) ? ActiveEmissionMode.Illuminate : ActiveEmissionMode.Search_Track);
							if (!method_38(sensor, float_9, activeEmissionMode_, activeUnit_0.WeatherAtMyLocation))
							{
								FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_Equation, ref LocalResult);
								continue;
							}
							int num;
							if (Capabilities.OTH_Backscatter)
							{
								num = 1;
							}
							else
							{
								if (sensor.Capabilities.OTH_SurfaceWave)
								{
									if (!(sensor.maxRange >= float_9))
									{
										FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_MaxRange, ref LocalResult);
										continue;
									}
									if (!nullable_4.HasValue)
									{
										nullable_4 = Module_Unit.Has_ESM_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: true);
									}
									if (!nullable_4.Value)
									{
										FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_LOS, ref LocalResult);
										continue;
									}
								}
								else
								{
									if (!nullable_3.HasValue)
									{
										nullable_3 = Module_Unit.Has_ESM_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen);
									}
									if (!nullable_3.Value)
									{
										FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_RadarHorizonLOS, ref LocalResult);
										continue;
									}
								}
								num = 1;
							}
							flag3 = (byte)num != 0;
							int key = ((sensor.MasqueradeAs == 1001) ? sensor.DBID : sensor.MasqueradeAs);
							if (dictionary_0 == null)
							{
								dictionary_0 = new Dictionary<int, EmissionContainer>();
							}
							if (!dictionary_0.ContainsKey(key))
							{
								dictionary_0.Add(key, new EmissionContainer(0.0, flag2, ESM_PreciseEmitterID));
							}
							if (!dictionary_0[key].IsIllumination && flag2)
							{
								dictionary_0[key].IsIllumination = true;
							}
							if (!dictionary_0[key].PreciseID && ESM_PreciseEmitterID)
							{
								dictionary_0[key].PreciseID = true;
							}
							if (activeUnit_0.IsSubmarine)
							{
								if (!sensor.Capabilities.PeriscopeSearch)
								{
									if (sensor.Capabilities.SurfaceSearch && activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= -5f)
									{
										activeUnit_0.TimeSinceLastThreatDetection_ESM = 0f;
									}
								}
								else
								{
									activeUnit_0.TimeSinceLastThreatDetection_ESM = 0f;
								}
							}
							if (!activeUnit_0.IsAircraft && !activeUnit_0.IsShip && !activeUnit_0.IsSubmarine && !activeUnit_0.IsFacility)
							{
								continue;
							}
							Contact value;
							if (activeUnit_0.IncomingGuidedWeaponsList.Length > 0)
							{
								Contact contact = activeUnit_0.get_UnitSide(SetSideOnly: false).Contacts[activeUnit_1.ObjectID];
								if (contact == null)
								{
									continue;
								}
								if (contact.get_Stance(activeUnit_0.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Hostile)
								{
									Contact contact2 = activeUnit_1.get_UnitSide(SetSideOnly: false).Contacts[activeUnit_0.ObjectID];
									if (contact2 != null && sensor.TargetsTrackedForFireControl_Readonly.Contains(contact2))
									{
										contact.set_Stance(activeUnit_0.get_UnitSide(SetSideOnly: false), MarkManually: false, Misc.PostureStance.Hostile);
										string text = "";
										if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, false) != 0)
										{
											text = " (" + activeUnit_0.UnitClass + ")";
										}
										activeUnit_0.ParentScen.AddMessage("Contact: " + contact.Name + " is illuminating " + activeUnit_0.Name + text + " and is now considered as hostile!", contact.Name + " is now HOSTILE!", LoggedMessage.MessageType.ContactChange, 0, null, activeUnit_0.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
									}
								}
								if (flag2)
								{
									activeUnit_0.Sensory.HandleAssumedWeaponContactFromGuidanceDetection(contact, this, sensor, float_9, dictionary_0);
								}
							}
							else if (flag2 && activeUnit_0.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(activeUnit_1.ObjectID, out value))
							{
								activeUnit_0.Sensory.HandleAssumedWeaponContactFromGuidanceDetection(value, this, sensor, float_9, dictionary_0);
							}
						}
						else
						{
							FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ESM_EmitterNotActive, ref LocalResult);
						}
					}
					result = flag3;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100725", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num2;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					result = (byte)num2 != 0;
					ProjectData.ClearProjectError();
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool method_17(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9)
	{
		bool result = default(bool);
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			if (activeUnit_1.IsBoat)
			{
				if (!activeUnit_1.IsSubmarine)
				{
					goto IL_0056;
				}
				Submarine._SubmarineType type = ((Submarine)activeUnit_1).Type;
				if ((type != Submarine._SubmarineType.None && type != Submarine._SubmarineType.Biologics) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.MAD_UnitIsSubBiologics, ref LocalResult).HasValue)
				{
					goto IL_0056;
				}
				result = false;
			}
			else
			{
				FeedSensorFailureItem(Result: false, SensorDetectionFeedback.MAD_IsNotBoatType, ref LocalResult);
				result = false;
			}
			goto end_IL_0001;
			IL_008b:
			int num2;
			int num = num2;
			double num3 = (double)(int)Math.Round(((IBoat)activeUnit_1).Displacement_Standard) / (double)num;
			double num4 = (double)maxRange * num3;
			if (activeUnit_1.IsSubmarine && ((Submarine)activeUnit_1).Flags.NonmagneticHull)
			{
				num4 /= 2.0;
			}
			int num5 = (int)Math.Round((float)Math.Abs(Terrain.GetElevation(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen)) - Math.Abs(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			if (num5 < 50)
			{
				num4 /= 2.0;
			}
			else if (num5 < 100)
			{
				num4 *= 0.75;
			}
			bool flag = num4 >= (double)float_9;
			if (FeedSensorFailureItem(flag, SensorDetectionFeedback.MAD_MaxEffectiveRange, ref LocalResult).HasValue)
			{
				result = flag;
			}
			goto end_IL_0001;
			IL_0056:
			if (!activeUnit_1.IsTorpedo)
			{
				num2 = 24500;
				goto IL_008b;
			}
			if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.MAD_UnitIsTorpedo, ref LocalResult).HasValue)
			{
				num2 = 24500;
				goto IL_008b;
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100726", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num6 = 0;
			}
			else
			{
				num6 = 0;
			}
			result = (byte)num6 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private float method_18(int int_2, ActiveUnit activeUnit_0)
	{
		return 0f;
	}

	private float method_19(ActiveUnit activeUnit_0)
	{
		float num = 1f;
		float result;
		try
		{
			float currentAltitude_AGL = activeUnit_0.CurrentAltitude_AGL;
			if (currentAltitude_AGL < 10f)
			{
				num = 0.2f;
			}
			else if (currentAltitude_AGL < 20f)
			{
				num = 0.4f;
			}
			else if (currentAltitude_AGL < 30f)
			{
				num = 0.7f;
			}
			if (num != 1f)
			{
				switch (TechGeneration)
				{
				default:
					throw new NotImplementedException();
				case GlobalVariables.TechGenerationClass.const_2:
				case GlobalVariables.TechGenerationClass.const_3:
					num = num;
					break;
				case GlobalVariables.TechGenerationClass.const_4:
				case GlobalVariables.TechGenerationClass.const_5:
					num = (float)((double)num + 0.1);
					break;
				case GlobalVariables.TechGenerationClass.const_6:
				case GlobalVariables.TechGenerationClass.const_7:
					num = (float)((double)num + 0.2);
					break;
				case GlobalVariables.TechGenerationClass.const_8:
				case GlobalVariables.TechGenerationClass.const_9:
					num = (float)((double)num + 0.3);
					break;
				case GlobalVariables.TechGenerationClass.const_10:
				case GlobalVariables.TechGenerationClass.const_11:
					num = (float)((double)num + 0.4);
					break;
				case GlobalVariables.TechGenerationClass.const_12:
				case GlobalVariables.TechGenerationClass.const_13:
					num = (float)((double)num + 0.5);
					break;
				case GlobalVariables.TechGenerationClass.const_14:
				case GlobalVariables.TechGenerationClass.const_15:
					num = (float)((double)num + 0.6);
					break;
				case GlobalVariables.TechGenerationClass.const_16:
				case GlobalVariables.TechGenerationClass.const_17:
					num = (float)((double)num + 0.7);
					break;
				}
				FrequencyBand band = SearchFreqs[0].Band;
				FrequencyBand num2 = band - 4001L;
				if ((ulong)num2 <= 3uL)
				{
					switch (num2)
					{
					case (FrequencyBand)0L:
						num = (float)((double)num - 0.3);
						goto IL_0196;
					case (FrequencyBand)1L:
						num = (float)((double)num - 0.1);
						goto IL_0196;
					case (FrequencyBand)2L:
						num = num;
						goto IL_0196;
					case (FrequencyBand)3L:
						{
							num = (float)((double)num - 0.5);
							goto IL_0196;
						}
						IL_0196:
						num = (float)Math.Min(0.9, num);
						result = num;
						goto end_IL_0006;
					}
				}
				throw new NotImplementedException();
			}
			result = num;
			end_IL_0006:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101327", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 1f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private float method_20(double double_0, double double_1, int int_2)
	{
		float result;
		try
		{
			float num = ((int_2 <= -300) ? 1f : ((int_2 < -50) ? ((float)(0.5 + 0.5 * ((double)(Math.Abs(int_2) - 50) / 250.0))) : 0.5f));
			bool flag = SeaIceProvider.PointIsUnderIce(double_1, double_0);
			if (num < 1f || flag)
			{
				float num2 = ((!flag) ? num : 0.5f);
				switch (TechGeneration)
				{
				default:
					throw new NotImplementedException();
				case GlobalVariables.TechGenerationClass.const_2:
				case GlobalVariables.TechGenerationClass.const_3:
					num2 = num2;
					break;
				case GlobalVariables.TechGenerationClass.const_4:
				case GlobalVariables.TechGenerationClass.const_5:
					num2 = (float)((double)num2 + 0.1);
					break;
				case GlobalVariables.TechGenerationClass.const_6:
				case GlobalVariables.TechGenerationClass.const_7:
					num2 = (float)((double)num2 + 0.2);
					break;
				case GlobalVariables.TechGenerationClass.const_8:
				case GlobalVariables.TechGenerationClass.const_9:
					num2 = (float)((double)num2 + 0.3);
					break;
				case GlobalVariables.TechGenerationClass.const_10:
				case GlobalVariables.TechGenerationClass.const_11:
					num2 = (float)((double)num2 + 0.4);
					break;
				case GlobalVariables.TechGenerationClass.const_12:
				case GlobalVariables.TechGenerationClass.const_13:
					num2 = (float)((double)num2 + 0.5);
					break;
				case GlobalVariables.TechGenerationClass.const_14:
				case GlobalVariables.TechGenerationClass.const_15:
					num2 = (float)((double)num2 + 0.6);
					break;
				case GlobalVariables.TechGenerationClass.const_16:
				case GlobalVariables.TechGenerationClass.const_17:
					num2 = (float)((double)num2 + 0.7);
					break;
				}
				FrequencyBand band = SearchFreqs[0].Band;
				FrequencyBand num3 = band - 4001L;
				if ((ulong)num3 <= 3uL)
				{
					switch (num3)
					{
					case (FrequencyBand)0L:
						num2 = (float)((double)num2 - 0.3);
						goto IL_01bc;
					case (FrequencyBand)1L:
						num2 = (float)((double)num2 - 0.1);
						goto IL_01bc;
					case (FrequencyBand)2L:
						num2 = num2;
						goto IL_01bc;
					case (FrequencyBand)3L:
						{
							num2 = (float)((double)num2 - 0.5);
							goto IL_01bc;
						}
						IL_01bc:
						num2 = (float)Math.Min(0.9, num2);
						result = num2;
						goto end_IL_0001;
					}
				}
				throw new NotImplementedException();
			}
			result = 1f;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100727", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 1f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private float method_21(ActiveUnit activeUnit_0, float float_9, float? nullable_3)
	{
		float result;
		try
		{
			float_9 = Math.Min(1f, float_9 * 2f);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_0).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			float theAlt = (nullable_3.HasValue ? nullable_3.Value : ((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(theAlt, thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), thermalLayerAtThisLocation);
			float strength = thermalLayerAtThisLocation.Strength;
			if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Above || positionRelativeToThermocline2 != SonarModel.PositionRelativeToThermocline.Above)
			{
				if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Inside)
				{
					float_9 = (float)((double)float_9 * Math.Max(0.1, 1f - strength * 2f));
				}
				else if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != SonarModel.PositionRelativeToThermocline.Inside)
				{
					if (positionRelativeToThermocline != positionRelativeToThermocline2)
					{
						float_9 *= 1f - strength;
					}
					else if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Below)
					{
						if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) && thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
						{
							float_9 *= 2f;
						}
						else if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) || thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
						{
							float_9 = (float)((double)float_9 * 1.5);
						}
					}
				}
				else
				{
					float_9 *= 1f - strength / 2f;
				}
			}
			result = float_9;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100728", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = float_9 / 2f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool UsesDeepSoundChannel()
	{
		if (Type == Sensor_Type.BottomFixedSonar_PassiveOnly)
		{
			return true;
		}
		Sensor_Role role = Role;
		int result;
		if ((ulong)(role - 5191L) <= 2uL)
		{
			result = 1;
		}
		else
		{
			if (role != Sensor_Role.SOSUSPassiveSoundSurveillanceSystems)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private bool method_22(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, bool? nullable_3, float? nullable_4 = null)
	{
		bool result = default(bool);
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			float num14;
			float num15;
			if (!activeUnit_1.IsOperating() && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_NotOperating, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (nullable_3.HasValue && ((!nullable_3) ?? nullable_3) == true && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				short num = (short)(IsTowedArray ? 25 : (activeUnit_0.IsTorpedo ? 200 : 30));
				if (activeUnit_0.CurrentSpeed >= (float)num && !activeUnit_0.IsWeapon && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_AboveDeafSpeed, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (activeUnit_0.IsTorpedo)
					{
						float_9 = activeUnit_0.RangeToUnit_Horiz(activeUnit_1);
					}
					float num2 = maxRange;
					float num6;
					if (!activeUnit_0.IsTorpedo)
					{
						float num3 = activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
						float num4;
						float num5;
						if (activeUnit_0.CurrentSpeed <= 5f)
						{
							num4 = 0f;
							num5 = 0f;
						}
						else
						{
							num4 = (float)((double)(activeUnit_0.DesiredSpeed - 5f) / ((double)num3 + 1E-06 - 5.0));
							num5 = (float)((double)(activeUnit_0.CurrentSpeed - 5f) / ((double)num3 + 1E-06 - 5.0));
						}
						num6 = (float)(1.0 - (0.75 * (double)num4 + 0.25 * (double)num5));
						Sensor_Type type = Type;
						if ((uint)(type - 5012) <= 1u || (uint)(type - 5022) <= 1u)
						{
							num6 = method_21(activeUnit_0, num6, nullable_4);
						}
					}
					else
					{
						num6 = 1f;
					}
					ActiveUnit parentPlatform = ParentPlatform;
					string feedbackMessage = "";
					float num7 = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue));
					XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.ActiveSonar);
					if (xSection == null)
					{
						FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_Other, ref LocalResult);
						result = false;
					}
					else if (xSection.isDBInvisible(activeUnit_1))
					{
						FeedSensorFailureItem(Result: false, SensorDetectionFeedback.DB_Invisible, ref LocalResult);
						result = false;
					}
					else
					{
						float num8 = default(float);
						float num9 = default(float);
						if (!(num7 >= 315f) && num7 > 45f)
						{
							if ((num7 >= 45f && num7 <= 135f) || (num7 >= 225f && num7 <= 315f))
							{
								num8 = xSection.get_Side(activeUnit_1);
								num9 = (activeUnit_0.IsTorpedo ? 100f : 250f);
							}
							else if (num7 >= 135f && num7 <= 225f)
							{
								num8 = xSection.get_Rear(activeUnit_1);
								num9 = ((!activeUnit_0.IsTorpedo) ? 60f : 15f);
							}
						}
						else
						{
							num8 = xSection.get_Front(activeUnit_1);
							num9 = ((!activeUnit_0.IsTorpedo) ? 60f : 15f);
						}
						float num10 = num8 / num9;
						float num11 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_4);
						float num12 = method_20(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_1).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen));
						float num13 = method_19(activeUnit_1);
						num14 = (float)(9.87473 * (double)num11 * (double)num12 * (double)num13);
						num15 = num2 * num6 * num11 * num12 * num13 * num10;
						bool flag = true;
						bool LandmassCheckIsNeeded = true;
						if (ParentPlatform.IsShip && activeUnit_1.IsShip)
						{
							flag = false;
						}
						if (UsesDeepSoundChannel())
						{
							flag = false;
						}
						if (IsDippingSonar)
						{
							flag = false;
						}
						if (LandmassCheckIsNeeded && Terrain.DryLandExistsBetweenThesePoints(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), 300, ParentPlatform.ParentScen) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref LocalResult).HasValue)
						{
							result = false;
						}
						else
						{
							if (!flag)
							{
								goto IL_047a;
							}
							if (!nullable_3.HasValue)
							{
								nullable_3 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref activeUnit_0.ParentScen, ref LandmassCheckIsNeeded);
							}
							if (((!nullable_3) ?? nullable_3) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref LocalResult).HasValue)
							{
								goto IL_047a;
							}
							result = false;
						}
					}
				}
			}
			goto end_IL_0001;
			IL_047a:
			if (float_9 > num15 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.ACTIVESONAR_MaxRangeSpecificTarget, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (!(float_9 < num14))
			{
				result = ((double)float_9 < (double)num14 * 1.2 && method_27(activeUnit_0, activeUnit_1, num15, float_9, num15, nullable_4) && FeedSensorFailureItem(Result: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulBottomBounceDetection, ref LocalResult).HasValue) || (method_28(activeUnit_0, activeUnit_1, num15, ref float_9, nullable_4) && FeedSensorFailureItem(Result: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulDetectionThroughCZ, ref LocalResult).HasValue) || (LocalResult?.ToBoolean() ?? false);
			}
			else if (FeedSensorFailureItem(Result: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulDirectDetection, ref LocalResult).HasValue)
			{
				result = true;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100729", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num16;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num16 = 0;
			}
			else
			{
				num16 = 0;
			}
			result = (byte)num16 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_23(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, Dictionary<int, EmissionContainer> dictionary_0, bool? nullable_3)
	{
		bool result;
		try
		{
			GlobalVariables.BooleanObject LocalResult;
			if (activeUnit_1.Sensory.GetIntermittentEmission().IsAllowedToEmit())
			{
				LocalResult = null;
				if (nullable_3.HasValue && ((!nullable_3) ?? nullable_3) == true && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PING_LOSSonar, ref LocalResult).HasValue)
				{
					result = false;
				}
				else if (!(maxRange >= float_9) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PING_MaxRange, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (nullable_3.HasValue)
					{
						goto IL_0141;
					}
					bool flag = true;
					if (ParentPlatform.IsShip && activeUnit_1.IsShip)
					{
						flag = false;
					}
					if (Type == Sensor_Type.PingIntercept && activeUnit_1.IsUsingDippingSonar())
					{
						flag = false;
					}
					if (!flag)
					{
						goto IL_0141;
					}
					ref Scenario parentScen = ref activeUnit_0.ParentScen;
					bool LandmassCheckIsNeeded = false;
					nullable_3 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref parentScen, ref LandmassCheckIsNeeded);
					if (((!nullable_3) ?? nullable_3) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PING_LOSSonar, ref LocalResult).HasValue)
					{
						goto IL_0141;
					}
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0141:
			float num = activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
			float num2 = (float)((double)ParentPlatform.DesiredSpeed / ((double)num + 1E-06));
			float num3 = (float)((double)activeUnit_0.CurrentSpeed / ((double)num + 1E-06));
			float num4 = (float)(1.0 - (0.75 * (double)num2 + 0.25 * (double)num3));
			float num5 = maxRange * num4;
			float num6 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1);
			float num7 = (float)(9.87473 * (double)num6);
			bool czActive = method_28(activeUnit_0, activeUnit_1, maxRange, ref float_9);
			float num8 = SonarModel.smethod_0(activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), activeUnit_0.get_UnitSide(SetSideOnly: false), activeUnit_0.ParentScen);
			int num9 = 0;
			double num12 = default(double);
			int num13 = default(int);
			double num14 = default(double);
			if (GameGeneral.Beta_RevisedSonarModel)
			{
				FrequencyBand band = SearchFreqs[0].Band;
				FrequencyBand num10 = band - 4001L;
				float num11 = default(float);
				if ((ulong)num10 <= 3uL)
				{
					switch (num10)
					{
					case (FrequencyBand)0L:
						num11 = 3f;
						break;
					case (FrequencyBand)1L:
						num11 = 5f;
						break;
					case (FrequencyBand)2L:
						num11 = 50f;
						break;
					case (FrequencyBand)3L:
						num11 = 0.5f;
						break;
					}
				}
				num12 = SonarModel.SonarArrayGainEstimator.EstimateArrayGain(200.0, maxRange, 60.0, num11 * 1000f);
				num13 = 10;
				num14 = ComputeANL_Wrapper(new Geopoint_Struct(activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue)), SearchFreqs[0].Band, activeUnit_0.ParentScen, activeUnit_0);
			}
			Sensor[] sensors_Cached = activeUnit_1.Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if ((!sensor.IsSonar && !sensor.IsPingIntercept) || !sensor.IsActive() || !sensor.IsOperating || !sensor.TargetIsWithinCoverageArc(activeUnit_0) || !method_37(sensor))
				{
					continue;
				}
				float num15;
				int num16;
				if (!GameGeneral.Beta_RevisedSonarModel)
				{
					num15 = num5 * num6;
					num16 = 0;
				}
				else
				{
					float num17 = sensor.SonarSourceLevel;
					float num18 = (float)SonarModel.Compute_ApparentSL_at_Range(num17, float_9, num7, num8, 5.0, 2.0, czActive);
					if ((double)num18 < num14 - num12 + (double)num13)
					{
						continue;
					}
					num15 = num5 * num6 * (num18 / num17);
					num16 = 0;
				}
				bool flag2 = (byte)num16 != 0;
				if (num15 > float_9)
				{
					flag2 = true;
				}
				else if ((double)float_9 < (double)num7 * 1.2 && method_27(activeUnit_0, activeUnit_1, num15, float_9, num15))
				{
					flag2 = true;
				}
				if (flag2)
				{
					num9++;
					int key = ((sensor.MasqueradeAs == 1001) ? sensor.DBID : sensor.MasqueradeAs);
					if (dictionary_0 == null)
					{
						dictionary_0 = new Dictionary<int, EmissionContainer>();
					}
					if (!dictionary_0.ContainsKey(key))
					{
						dictionary_0.Add(key, new EmissionContainer(0.0, IsPainting: false, ESM_PreciseEmitterID));
					}
					if (!dictionary_0[key].PreciseID && ESM_PreciseEmitterID)
					{
						dictionary_0[key].PreciseID = true;
					}
				}
			}
			result = ((num9 > 0) ? (LocalResult?.ToBoolean() ?? true) : (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PING_NoInterceptionFromAnyEmitter, ref LocalResult).HasValue && (LocalResult?.ToBoolean() ?? false)));
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100730", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num19;
			if (!Debugger.IsAttached)
			{
				num19 = 0;
			}
			else
			{
				Debugger.Break();
				num19 = 0;
			}
			result = (byte)num19 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static float smethod_2(object object_0)
	{
		float num = ((ActiveUnit)object_0).Kinematics.GetMaximumSpeed(((ActiveUnit)object_0).Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false, ConsiderDamage: false);
		if (num == 0f)
		{
			return 0f;
		}
		return (float)((double)((Module_Unit.Unit)object_0).CurrentSpeed / ((double)num + 1E-06));
	}

	private static float smethod_3(object object_0)
	{
		float num = ((ActiveUnit)object_0).Kinematics.GetMaximumSpeed(((ActiveUnit)object_0).Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
		if (num == 0f)
		{
			return 0f;
		}
		bool flag = false;
		if (((ActiveUnit)object_0).SubType == 9001)
		{
			flag = true;
		}
		float num2 = ((ActiveUnit)object_0).DesiredSpeed;
		if (((Module_Unit.Unit)object_0).CurrentSpeed == 0f)
		{
			num2 = 0f;
		}
		double num3 = (((((ScenarioObject)object_0).IsShip && ((Ship)object_0).IsNuke) || (((ScenarioObject)object_0).IsSubmarine && ((Submarine)object_0).IsNuke)) ? ((!((ScenarioObject)object_0).IsSubmarine || !((Submarine)object_0).Flags.AdvancedPropulsor) ? Math.Min(1.0, (double)Math.Max(num2, 5f) / ((double)num + 1E-06)) : ((double)num2 / ((double)num + 1E-06))) : (flag ? Math.Min(1.0, (double)Math.Max(num2, 5f) / ((double)num + 0.0001)) : ((double)num2 / ((double)num + 1E-06))));
		return (float)num3;
	}

	public static (float FrontalAspectValue, float SideAspectValue, float RearAspectValue) NavalUnitNoiseInDecibels(ActiveUnit theUnit, FrequencyBand theBand)
	{
		(float, float, float) result;
		if (!theUnit.IsBoat && !theUnit.IsTorpedo)
		{
			result = (0f, 0f, 0f);
		}
		else
		{
			XSection xSection = null;
			FrequencyBand num = theBand - 4001L;
			if ((ulong)num <= 3uL)
			{
				switch (num)
				{
				case (FrequencyBand)0L:
					xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_LF);
					if (xSection == null)
					{
						xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_LF);
					}
					break;
				case (FrequencyBand)1L:
					xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_MF);
					if (xSection == null)
					{
						xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_MF);
					}
					break;
				case (FrequencyBand)2L:
					xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_HF);
					if (xSection == null)
					{
						xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_HF);
					}
					break;
				case (FrequencyBand)3L:
					xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
					if (xSection == null)
					{
						xSection = smethod_0(theUnit, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
					}
					break;
				}
			}
			if (xSection != null)
			{
				bool flag = false;
				if (theUnit.IsSubmarine)
				{
					Submarine submarine = (Submarine)theUnit;
					if (submarine.PrimaryEngine != null && submarine.AI.SelectFuelTypeToConsume(submarine.PrimaryEngine) == FuelRec._FuelType.DieselFuel)
					{
						flag = true;
					}
					else if (submarine.PrimaryEngine == null)
					{
						_ = Debugger.IsAttached;
					}
				}
				bool flag2 = theUnit.IsBoat && ((IBoat)theUnit).IsCavitating();
				List<float> list = new List<float>
				{
					xSection.get_Front(theUnit),
					xSection.get_Side(theUnit),
					xSection.get_Rear(theUnit)
				};
				float num4 = default(float);
				if (!theUnit.IsSubmarine || (!((Submarine)theUnit).IsBiological && !((Submarine)theUnit).IsFalseTarget))
				{
					double num2 = smethod_3(theUnit);
					float num3 = smethod_2(theUnit);
					num4 = (float)(0.75 * num2 + 0.25 * (double)num3);
				}
				int num5 = list.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					float num6 = list[i];
					if (!theUnit.IsSubmarine || (!((Submarine)theUnit).IsBiological && !((Submarine)theUnit).IsFalseTarget))
					{
						num6 *= num4;
					}
					if (flag2)
					{
						float num7 = theUnit.Kinematics.CavitationSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						float num8 = (float)theUnit.Kinematics.GetMaximumSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) - num7;
						if (num8 == 0f)
						{
							num6 += 15f;
						}
						else
						{
							float num9 = (theUnit.DesiredSpeed - num7) / num8;
							num6 += 15f * num9;
						}
					}
					if (flag)
					{
						float num10 = (float)(15.0 * Math.Pow(((double)theUnit.DesiredSpeed + 0.0001) / (double)theUnit.Kinematics.GetMaximumSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2.0));
						if (float.IsNaN(num10) || num10 > 15f)
						{
							num10 = 15f;
						}
						num6 += num10;
					}
					if (theUnit.IsSubmarine && ((Submarine)theUnit).IsNuke && ((Submarine)theUnit).Flags.AdvancedPropulsor && theUnit.DesiredSpeed <= 10f)
					{
						if (theUnit.DesiredSpeed <= 10f)
						{
							num6 -= 8f;
						}
						else if (theUnit.DesiredSpeed <= 15f)
						{
							num6 -= 4f;
						}
					}
					if (num6 < 0f)
					{
						num6 = 0f;
					}
					list[i] = num6;
				}
				result = (list[0], list[1], list[2]);
			}
			else
			{
				result = (0f, 0f, 0f);
			}
		}
		return result;
	}

	private float method_24(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float? nullable_3 = null)
	{
		if (!nullable_3.HasValue)
		{
			nullable_3 = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
		}
		float num;
		if (IsDippingSonar)
		{
			num = 1f;
		}
		else
		{
			float num2;
			float num3;
			if (activeUnit_0.CurrentSpeed <= 5f)
			{
				num2 = 0f;
				num3 = 0f;
			}
			else
			{
				num2 = smethod_3(activeUnit_0);
				num3 = smethod_2(activeUnit_0);
			}
			num = (float)(1.0 - (0.75 * (double)num2 + 0.25 * (double)num3));
			Sensor_Type type = Type;
			if ((uint)(type - 5012) <= 1u || (uint)(type - 5022) <= 1u)
			{
				num = method_21(activeUnit_0, num, nullable_3);
			}
		}
		if (activeUnit_0.IsTorpedo)
		{
			num = (float)Math.Max(0.9, num);
		}
		(float, float, float) tuple = NavalUnitNoiseInDecibels(activeUnit_1, SearchFreqs[0].Band);
		string feedbackMessage = "";
		float num4 = Module_Unit.AngleOffThisUnitsBoresight(activeUnit_0, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		float num5 = default(float);
		if (num4 >= 315f || !(num4 > 45f))
		{
			(num5, _, _) = tuple;
		}
		else if ((num4 >= 45f && num4 <= 135f) || (num4 >= 225f && num4 <= 315f))
		{
			num5 = tuple.Item2;
		}
		else if (num4 >= 135f && num4 <= 225f)
		{
			num5 = tuple.Item3;
		}
		if (num5 == 0f)
		{
			_ = Debugger.IsAttached;
			return 0f;
		}
		FrequencyBand band = SearchFreqs[0].Band;
		FrequencyBand num6 = band - 4001L;
		int num7 = default(int);
		float num8 = default(float);
		if ((ulong)num6 <= 3uL)
		{
			switch (num6)
			{
			case (FrequencyBand)0L:
				num7 = 152;
				num8 = 3f;
				break;
			case (FrequencyBand)1L:
				num7 = 144;
				num8 = 5f;
				break;
			case (FrequencyBand)2L:
				num7 = 136;
				num8 = 50f;
				break;
			case (FrequencyBand)3L:
				num7 = 182;
				num8 = 0.5f;
				break;
			}
		}
		float num9 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_3);
		float num10 = method_20(activeUnit_1.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_1.get_Longitude(GlobalVariables.ObjectTrue), Terrain.GetElevation(activeUnit_1.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_1.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, ParentPlatform.ParentScen));
		float num11;
		if (!GameGeneral.Beta_RevisedSonarModel)
		{
			num11 = num5 / (float)num7;
		}
		else
		{
			float num12 = (float)(9.87473 * (double)num9 * (double)num10);
			float num13 = SonarModel.smethod_0(activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), activeUnit_0.get_UnitSide(SetSideOnly: false), activeUnit_0.ParentScen);
			float float_ = activeUnit_0.RangeToUnit_Horiz(activeUnit_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			bool czActive = method_28(activeUnit_0, activeUnit_1, maxRange, ref float_, nullable_3);
			float num14 = (float)SonarModel.Compute_ApparentSL_at_Range(num5, float_, num12, num13, 5.0, 2.0, czActive);
			double num15 = ComputeANL_Wrapper(new Geopoint_Struct(activeUnit_0.get_Longitude(GlobalVariables.ObjectTrue), activeUnit_0.get_Latitude(GlobalVariables.ObjectTrue), nullable_3.Value), SearchFreqs[0].Band, activeUnit_0.ParentScen, activeUnit_0);
			double num16 = SonarModel.SonarArrayGainEstimator.EstimateArrayGain(num7, maxRange, 60.0, num8 * 1000f);
			if ((double)num14 < num15 - num16 + 10.0)
			{
				return 0f;
			}
			float num17 = (float)SonarModel.Compute_ApparentSL_at_Range(num7, float_, num12, num13, 5.0, 2.0, czActive);
			num11 = Math.Min(1f, num14 / num17);
		}
		return maxRange * num * num11 * num9 * num10;
	}

	public static double ComputeANL_Wrapper(Geopoint_Struct thePoint, FrequencyBand theSonarBand, Scenario theScen, ActiveUnit ExcludeUnit)
	{
		PooledList<ActiveUnit> activeUnits_List = default(PooledList<ActiveUnit>);
		while (activeUnits_List == null)
		{
			activeUnits_List = theScen.ActiveUnits_List;
		}
		ActiveUnit[] array = activeUnits_List.InternalArray();
		int count = activeUnits_List.Count;
		FrequencyBand num = theSonarBand - 4001L;
		float num2 = default(float);
		float num3 = default(float);
		if ((ulong)num <= 3uL)
		{
			switch (num)
			{
			case (FrequencyBand)0L:
				num2 = 250f;
				num3 = 3f;
				break;
			case (FrequencyBand)1L:
				num2 = 100f;
				num3 = 5f;
				break;
			case (FrequencyBand)2L:
				num2 = 25f;
				num3 = 50f;
				break;
			case (FrequencyBand)3L:
				num2 = 500f;
				num3 = 0.5f;
				break;
			}
		}
		PooledList<double> pooledList = new PooledList<double>();
		PooledList<double> pooledList2 = new PooledList<double>();
		int num4 = count - 1;
		float num7 = default(float);
		for (int i = 0; i <= num4; i++)
		{
			ActiveUnit activeUnit;
			try
			{
				activeUnit = array[i];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				continue;
			}
			if (activeUnit == null || activeUnit == ExcludeUnit || (!activeUnit.IsShip && !activeUnit.IsSubmarine && !activeUnit.IsTorpedo) || (activeUnit.IsSubmarine && (((Submarine)activeUnit).IsBiological || ((Submarine)activeUnit).IsFalseTarget)) || !activeUnit.IsOperating())
			{
				continue;
			}
			float num5 = Module_Unit.RangeToPoint_Slant(activeUnit, thePoint, GlobalVariables.ObjectTrue);
			if (!(num5 > num2))
			{
				(float, float, float) tuple = NavalUnitNoiseInDecibels(activeUnit, theSonarBand);
				float num6 = thePoint.AngleOffThisUnitsBoresight(activeUnit);
				if (num6 >= 315f || !(num6 > 45f))
				{
					(num7, _, _) = tuple;
				}
				else if ((num6 >= 45f && num6 <= 135f) || (num6 >= 225f && num6 <= 315f))
				{
					num7 = tuple.Item2;
				}
				else if (num6 >= 135f && num6 <= 225f)
				{
					num7 = tuple.Item3;
				}
				if (num7 != 0f)
				{
					pooledList.Add(num5);
					pooledList2.Add(num7);
				}
			}
		}
		(double, double, double) tuple3 = SonarModel.EstimateShippingLevelFromShips(pooledList.ToArray(), pooledList2.ToArray(), num3);
		int seaState = Weather.get_WeatherAtThisTimeAndPlace(theScen, thePoint.Latitude, thePoint.Longitude, 0).SeaState;
		short elevation = Terrain.GetElevation(thePoint, RequestIsFromGUI: false, theScen);
		double result = SonarModel.ComputeNarrowbandAmbientNoise(num3, seaState, Math.Abs(elevation), (int)Math.Round(thePoint.Altitude), (int)Math.Round(tuple3.Item2));
		pooledList.Dispose();
		pooledList2.Dispose();
		return result;
	}

	private bool method_25(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, Dictionary<int, EmissionContainer> dictionary_0, bool bool_3, bool? nullable_3, float? nullable_4 = null)
	{
		bool result;
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			int num2;
			if (!activeUnit_1.IsOperating() && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_NotOperating, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if (DetectionChecksThisPulse == null)
				{
					DetectionChecksThisPulse = new Dictionary<string, bool>();
				}
				if (!DetectionChecksThisPulse.ContainsKey(activeUnit_1.ObjectID))
				{
					DetectionChecksThisPulse.Add(activeUnit_1.ObjectID, value: false);
				}
				else
				{
					DetectionChecksThisPulse[activeUnit_1.ObjectID] = false;
				}
				if (nullable_3.HasValue && ((!nullable_3) ?? nullable_3) == true && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_LOSSonar, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (Type == Sensor_Type.BottomFixedSonar_PassiveOnly)
					{
						nullable_4 = ((Module_Unit.Unit)activeUnit_0).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen) + 1;
					}
					if (activeUnit_0.IsTorpedo)
					{
						float_9 = activeUnit_0.RangeToUnit_Horiz(activeUnit_1);
					}
					short num = (short)(IsTowedArray ? 25 : ((!activeUnit_0.IsTorpedo) ? 30 : 200));
					if (activeUnit_0.CurrentSpeed >= (float)num && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_AboveDeafSpeed, ref LocalResult).HasValue)
					{
						result = false;
					}
					else
					{
						if (float_9 <= maxRange)
						{
							num2 = 1;
							goto IL_0185;
						}
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_MaxNominalRange, ref LocalResult).HasValue)
						{
							num2 = 1;
							goto IL_0185;
						}
						result = false;
					}
				}
			}
			goto end_IL_0001;
			IL_0653:
			DetectionChecksThisPulse[activeUnit_1.ObjectID] = true;
			result = LocalResult?.ToBoolean() ?? true;
			goto end_IL_0001;
			IL_0185:
			bool flag = (byte)num2 != 0;
			bool LandmassCheckIsNeeded = true;
			if (ParentPlatform.IsShip && activeUnit_1.IsShip)
			{
				flag = false;
			}
			if (UsesDeepSoundChannel())
			{
				flag = false;
			}
			if (IsDippingSonar)
			{
				flag = false;
			}
			float num3 = method_24(activeUnit_0, activeUnit_1, nullable_4);
			if (float_9 > num3 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_MaxActualRange, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if (!bool_3)
				{
					float originalBearing = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					float num4;
					switch (TechGeneration)
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						num4 = 10f;
						break;
					case GlobalVariables.TechGenerationClass.const_2:
						num4 = 20f;
						break;
					case GlobalVariables.TechGenerationClass.const_3:
						num4 = 17.5f;
						break;
					case GlobalVariables.TechGenerationClass.const_4:
						num4 = 15f;
						break;
					case GlobalVariables.TechGenerationClass.const_5:
						num4 = 14f;
						break;
					case GlobalVariables.TechGenerationClass.const_6:
						num4 = 13f;
						break;
					case GlobalVariables.TechGenerationClass.const_7:
						num4 = 12f;
						break;
					case GlobalVariables.TechGenerationClass.const_8:
						num4 = 11f;
						break;
					case GlobalVariables.TechGenerationClass.const_9:
						num4 = 10f;
						break;
					case GlobalVariables.TechGenerationClass.const_10:
						num4 = 9f;
						break;
					case GlobalVariables.TechGenerationClass.const_11:
						num4 = 8f;
						break;
					case GlobalVariables.TechGenerationClass.const_12:
						num4 = 7f;
						break;
					case GlobalVariables.TechGenerationClass.const_13:
						num4 = 6f;
						break;
					case GlobalVariables.TechGenerationClass.const_14:
						num4 = 5f;
						break;
					case GlobalVariables.TechGenerationClass.const_15:
						num4 = 4f;
						break;
					case GlobalVariables.TechGenerationClass.const_16:
						num4 = 3f;
						break;
					case GlobalVariables.TechGenerationClass.const_17:
						num4 = 2f;
						break;
					}
					ActiveUnit[] array = activeUnit_0.ParentScen.ActiveUnits_List.InternalArray();
					int num5 = activeUnit_0.ParentScen.ActiveUnits_List.Count - 1;
					Dictionary<int, EmissionContainer> dictionary_1 = default(Dictionary<int, EmissionContainer>);
					for (int i = 0; i <= num5; i++)
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = array[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							continue;
						}
						if (activeUnit == null || activeUnit == activeUnit_1 || activeUnit == activeUnit_0 || (!activeUnit.IsShip && !activeUnit.IsSubmarine && !activeUnit.IsTorpedo) || !activeUnit.IsOperating())
						{
							continue;
						}
						float newBearing = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
						if (!(Math.Abs(MathFunctions.AngularDifference(originalBearing, newBearing)) < num4) || !TargetIsWithinCoverageArc(activeUnit))
						{
							continue;
						}
						switch (method_26(activeUnit))
						{
						case (Enum8)0:
							if (!method_25(activeUnit_0, activeUnit, activeUnit_0.RangeToUnit_Horiz(activeUnit, GlobalVariables.ObjectTrue), dictionary_1, bool_3: true, null, nullable_4) || !(method_24(activeUnit_0, activeUnit, nullable_4) > num3))
							{
								continue;
							}
							if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_SignalMaskedByAnother, ref LocalResult).HasValue)
							{
								break;
							}
							result = false;
							goto end_IL_0001;
						case (Enum8)2:
							if (method_24(activeUnit_0, activeUnit, nullable_4) <= num3)
							{
								continue;
							}
							if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_SignalMaskedByAnother, ref LocalResult).HasValue)
							{
								break;
							}
							result = false;
							goto end_IL_0001;
						default:
							continue;
						}
						break;
					}
				}
				if (!GameGeneral.Beta_RevisedSonarModel && float_9 > num3 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_MaxActualRange, ref LocalResult).HasValue)
				{
					result = false;
				}
				else if (LandmassCheckIsNeeded && Terrain.DryLandExistsBetweenThesePoints(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), 300, ParentPlatform.ParentScen) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_LandmassInBetween, ref LocalResult).HasValue)
				{
					result = false;
				}
				else
				{
					if (!flag)
					{
						goto IL_0578;
					}
					if (!nullable_3.HasValue)
					{
						nullable_3 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref activeUnit_0.ParentScen, ref LandmassCheckIsNeeded);
					}
					if (((!nullable_3) ?? nullable_3) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_LOSSonar, ref LocalResult).HasValue)
					{
						goto IL_0578;
					}
					result = false;
				}
			}
			goto end_IL_0001;
			IL_0578:
			if (GameGeneral.Beta_RevisedSonarModel || UsesDeepSoundChannel())
			{
				goto IL_0653;
			}
			float num6 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_4);
			float num7 = method_20(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), Terrain.GetElevation(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen));
			float num8 = (float)(9.87473 * (double)num6 * (double)num7);
			if (method_28(activeUnit_0, activeUnit_1, num3, ref float_9, nullable_4) && float_9 < num3)
			{
				DetectionChecksThisPulse[activeUnit_1.ObjectID] = true;
				if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.PASSIVESONAR_SuccessfulDetectionThroughCZ, ref LocalResult).HasValue)
				{
					goto IL_0653;
				}
				result = true;
			}
			else
			{
				if (!(float_9 > num8) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.PASSIVESONAR_CZBlockingAndNoDirectPath, ref LocalResult).HasValue)
				{
					goto IL_0653;
				}
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100731", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num9;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num9 = 0;
			}
			else
			{
				num9 = 0;
			}
			result = (byte)num9 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Enum8 method_26(ActiveUnit activeUnit_0)
	{
		if (DetectionChecksThisPulse == null)
		{
			return (Enum8)0;
		}
		bool value = false;
		if (!DetectionChecksThisPulse.TryGetValue(activeUnit_0.ObjectID, out value))
		{
			return (Enum8)0;
		}
		if (value)
		{
			return (Enum8)2;
		}
		return (Enum8)1;
	}

	public float SonarPropagationModifier(bool UsesDSC, ActiveUnit SensorParent, ActiveUnit Target, float? ExplicitSensorDepth = null)
	{
		float float_ = 1f;
		method_30(SensorParent, Target, ref float_, ExplicitSensorDepth);
		if (UsesDSC)
		{
			method_29(SensorParent, Target, ref float_, ExplicitSensorDepth);
		}
		return float_;
	}

	private bool method_27(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, float float_10, float float_11, float? nullable_3 = null)
	{
		float num = (nullable_3.HasValue ? nullable_3.Value : ((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
		float num2 = float_11;
		bool result;
		try
		{
			GeoPoint geoPoint = new GeoPoint();
			float num3 = num - (float)Terrain.GetElevation(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen);
			float num4 = activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentPlatform.ParentScen);
			float distance_NM = num3 * float_10 / (num3 + num4);
			double lon = activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null);
			double lat = activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null);
			GeoPoint geoPoint2;
			double out_lon = (geoPoint2 = geoPoint).Longitude;
			GeoPoint geoPoint3;
			double out_lat = (geoPoint3 = geoPoint).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, distance_NM, Math2.CalcAzimuth(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null)));
			geoPoint3.Latitude = out_lat;
			geoPoint2.Longitude = out_lon;
			float float_12 = 1f;
			method_30(activeUnit_0, activeUnit_1, ref float_12, nullable_3);
			if (float_12 < 1f)
			{
				num2 = float_11 * (1f + float_12 / 2f);
			}
			GeoPoint geoPoint4 = new GeoPoint(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), num);
			GeoPoint thePoint = new GeoPoint(activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			if (!(geoPoint4.RangeToPoint_Slant(geoPoint) + geoPoint.RangeToPoint_Slant(thePoint) >= num2))
			{
				float maxSlope = Terrain.GetMaxSlope(geoPoint.Latitude, geoPoint.Longitude, RequestIsFromGUI: false, ParentPlatform.ParentScen);
				float num5 = 1f - maxSlope;
				switch (TechGeneration)
				{
				default:
					throw new NotImplementedException();
				case GlobalVariables.TechGenerationClass.const_4:
				case GlobalVariables.TechGenerationClass.const_5:
					num5 = (float)((double)num5 + 0.1);
					break;
				case GlobalVariables.TechGenerationClass.const_6:
				case GlobalVariables.TechGenerationClass.const_7:
					num5 = (float)((double)num5 + 0.2);
					break;
				case GlobalVariables.TechGenerationClass.const_8:
				case GlobalVariables.TechGenerationClass.const_9:
					num5 = (float)((double)num5 + 0.3);
					break;
				case GlobalVariables.TechGenerationClass.const_10:
				case GlobalVariables.TechGenerationClass.const_11:
					num5 = (float)((double)num5 + 0.4);
					break;
				case GlobalVariables.TechGenerationClass.const_12:
				case GlobalVariables.TechGenerationClass.const_13:
					num5 = (float)((double)num5 + 0.5);
					break;
				case GlobalVariables.TechGenerationClass.const_14:
				case GlobalVariables.TechGenerationClass.const_15:
					num5 = (float)((double)num5 + 0.6);
					break;
				case GlobalVariables.TechGenerationClass.const_16:
				case GlobalVariables.TechGenerationClass.const_17:
					num5 = (float)((double)num5 + 0.7);
					break;
				case GlobalVariables.TechGenerationClass.const_2:
				case GlobalVariables.TechGenerationClass.const_3:
					break;
				}
				FrequencyBand band = SearchFreqs[0].Band;
				FrequencyBand num6 = band - 4001L;
				if ((ulong)num6 <= 3uL)
				{
					switch (num6)
					{
					case (FrequencyBand)0L:
						num5 = (float)((double)num5 - 0.3);
						goto IL_02f0;
					case (FrequencyBand)1L:
						num5 = (float)((double)num5 - 0.1);
						goto IL_02f0;
					case (FrequencyBand)2L:
						num5 = num5;
						goto IL_02f0;
					case (FrequencyBand)3L:
						{
							num5 = (float)((double)num5 - 0.5);
							goto IL_02f0;
						}
						IL_02f0:
						num2 *= num5;
						result = ((num2 <= float_11) ? true : false);
						goto end_IL_0028;
					}
				}
				throw new NotImplementedException();
			}
			result = false;
			end_IL_0028:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100733", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num7 = 0;
			}
			else
			{
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_28(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref float float_10, float? nullable_3 = null)
	{
		bool result;
		try
		{
			float num = SonarModel.smethod_0(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_UnitSide(SetSideOnly: false), activeUnit_0.ParentScen);
			if (num == 0f)
			{
				result = false;
			}
			else
			{
				float num2 = 5f;
				float num3 = num + num2;
				int num4 = 1;
				while (true)
				{
					float num5 = (float)((double)((float)num4 * num) - (double)num2 * 0.5);
					float num6 = (float)((double)((float)num4 * num) + (double)num2 * 0.5);
					if (!(num5 > float_9))
					{
						if (!(float_10 > num5) || num6 <= float_10)
						{
							num4++;
							continue;
						}
						Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
						float bearing = Math2.CalcAzimuth(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null));
						int num7 = 0;
						while (true)
						{
							float num8 = num3 * (float)num7 + num / 2f;
							if (!(num8 > float_10))
							{
								Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, num8, bearing);
								if (Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, RequestIsFromGUI: false, ParentPlatform.ParentScen) <= SonarModel.MinimumDepthForCZ_m(geopoint_Struct.Latitude))
								{
									num7++;
									continue;
								}
								result = false;
								break;
							}
							result = true;
							break;
						}
						break;
					}
					result = false;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100733", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num9;
			if (!Debugger.IsAttached)
			{
				num9 = 0;
			}
			else
			{
				Debugger.Break();
				num9 = 0;
			}
			result = (byte)num9 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_29(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_9, float? nullable_3 = null)
	{
		try
		{
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_0).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_1).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			float theAlt = (nullable_3.HasValue ? nullable_3.Value : ((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(theAlt, thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), thermalLayerAtThisLocation2);
			if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Below)
			{
				if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) && thermalLayerAtThisLocation2.get_IsInsideDeepSoundChannel((float)(int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
				{
					float_9 *= 2f;
				}
				else if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) || thermalLayerAtThisLocation2.get_IsInsideDeepSoundChannel((float)(int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
				{
					float_9 = (float)((double)float_9 * 1.5);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 102134656566777", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_30(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_9, float? nullable_3 = null)
	{
		try
		{
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_0).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)activeUnit_1).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			float theAlt = (nullable_3.HasValue ? nullable_3.Value : ((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(theAlt, thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), thermalLayerAtThisLocation2);
			float num = (thermalLayerAtThisLocation.Strength + thermalLayerAtThisLocation2.Strength) / 2f;
			if (num == 0f)
			{
				return;
			}
			if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Above && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Above)
			{
				float_9 = (float)SonarModel.EffectOfSurfaceDuct(float_9, activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), nullable_3);
			}
			else if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Inside)
			{
				float_9 = (float)((double)float_9 * Math.Max(0.1, 1f - num * 2f));
			}
			else if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != SonarModel.PositionRelativeToThermocline.Inside)
			{
				if (positionRelativeToThermocline != positionRelativeToThermocline2)
				{
					float_9 = (float)((double)float_9 * Math.Max(0.1, 1f - num));
				}
				else if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Below)
				{
				}
			}
			else
			{
				float_9 = (float)((double)float_9 * Math.Max(0.1, 1f - num / 2f));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100734", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_31(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref Module_Unit.Unit.LOSCheckResult? nullable_3, bool bool_3 = false)
	{
		bool result;
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			if (!nullable_3.HasValue)
			{
				goto IL_008b;
			}
			int? num = (int?)nullable_3;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num != 1)) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_LOSVisual, ref LocalResult).HasValue)
			{
				goto IL_008b;
			}
			result = false;
			goto end_IL_0001;
			IL_0283:
			if (!bool_3 && MaxDetectionRangeOnThisTarget_IR(activeUnit_0, activeUnit_1, bool_3, ConsiderLandCoverBetweenPoints: false) < float_9 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_MaxRange_SpecificToTarget, ref LocalResult).HasValue)
			{
				result = false;
			}
			else if (MaxDetectionRangeOnThisTarget_IR(activeUnit_0, activeUnit_1, bool_3) < float_9 && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_MaxRange_SpecificToTarget, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if (!Capabilities.SpaceSearch_ABM || !activeUnit_1.IsWeapon)
				{
					goto IL_039a;
				}
				Weapon._WeaponType type = ((Weapon)activeUnit_1).Type;
				if ((uint)(type - 5000) > 1u && type != Weapon._WeaponType.HGV)
				{
					goto IL_039a;
				}
				float TargetAltitude = (int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				bool flag;
				result = ((flag = Horizon.VisualHorizonNM(activeUnit_0, ref TargetAltitude, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null))) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_ABM_BeyondHorizon, ref LocalResult).HasValue) && (LocalResult?.ToBoolean() ?? flag);
			}
			goto end_IL_0001;
			IL_039a:
			if (!nullable_3.HasValue)
			{
				nullable_3 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, ConsiderClouds: true);
			}
			if (nullable_3.Value == Module_Unit.Unit.LOSCheckResult.Success)
			{
				result = LocalResult?.ToBoolean() ?? true;
			}
			else
			{
				FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_LOSVisual, ref LocalResult);
				result = LocalResult?.ToBoolean() ?? false;
			}
			goto end_IL_0001;
			IL_008b:
			if (!(float_9 <= maxRange) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_MaxRange, ref LocalResult).HasValue)
			{
				result = false;
			}
			else
			{
				if (!activeUnit_1.IsSubmarine || !(Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0) || !(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f))
				{
					goto IL_01a7;
				}
				if (Capabilities.PeriscopeSearch)
				{
					switch (((Submarine)activeUnit_1).Type)
					{
					case Submarine._SubmarineType.None:
					case Submarine._SubmarineType.Biologics:
					case Submarine._SubmarineType.FalseTarget:
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_LOSVisual, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0001;
					case Submarine._SubmarineType.SDV:
					case Submarine._SubmarineType.ROV:
					case Submarine._SubmarineType.UUV:
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_LOSVisual, ref LocalResult).HasValue)
						{
							break;
						}
						result = false;
						goto end_IL_0001;
					}
					goto IL_01a7;
				}
				if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_NoPeriscopeSearchCapability, ref LocalResult).HasValue)
				{
					goto IL_01a7;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_01a7:
			if (activeUnit_0.IsSatellite || activeUnit_0.IsWeapon)
			{
				goto IL_0283;
			}
			bool flag2 = false;
			if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
			{
				flag2 = activeUnit_0.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(activeUnit_1.ObjectID);
			}
			else
			{
				PooledList<Contact> pooledList = Module_ActiveUnit_Sensory.ContactsVisibleToMe(activeUnit_0.Sensory);
				foreach (Contact item in pooledList)
				{
					if (Operators.CompareString(item?.ActualUnit?.ObjectID, activeUnit_1.ObjectID, false) == 0)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (flag2)
			{
				goto IL_0283;
			}
			int num2 = VolumeSearchRange_IR(this);
			if (!(float_9 > (float)num2) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.IR_MaxRange, ref LocalResult).HasValue)
			{
				goto IL_0283;
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100735", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SensorDetectionCheckResult CanIlluminateTarget(ActiveUnit SensorCarrier, ref Contact theTarget, ref Scenario theScen, float TargetSlantRange, List<ActiveUnit> AffectingJammers, bool IgnoreArcAtLongRange, bool WeaponIsAirborne, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar)
	{
		ActiveUnit actualUnit = theTarget.ActualUnit;
		return CanIlluminateTarget(SensorCarrier, actualUnit, TargetSlantRange, AffectingJammers, IgnoreArcAtLongRange, WeaponIsAirborne, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar);
	}

	private SensorDetectionCheckResult method_32(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, List<ActiveUnit> list_2, bool bool_3, bool bool_4, ref bool? nullable_3, ref bool? nullable_4)
	{
		SensorDetectionCheckResult result = default(SensorDetectionCheckResult);
		try
		{
			GlobalVariables.BooleanObject LocalResult = null;
			if (Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_4.HasValue)
				{
					goto IL_00c8;
				}
				bool? flag = nullable_4;
				if (((!flag) ?? flag) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS_SurfaceWave, ref LocalResult).HasValue)
				{
					goto IL_00c8;
				}
				result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
			}
			else
			{
				if (!nullable_3.HasValue)
				{
					goto IL_00c8;
				}
				bool? flag = nullable_3;
				if (((!flag) ?? flag) != true || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS, ref LocalResult).HasValue)
				{
					goto IL_00c8;
				}
				result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
			}
			goto end_IL_0001;
			IL_0188:
			XSection._SignatureType desiredSignatureType;
			XSection xSection = smethod_0(activeUnit_1, desiredSignatureType);
			float num;
			if (xSection == null && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_Other, ref LocalResult).HasValue)
			{
				result = SensorDetectionCheckResult.Fail_Other;
			}
			else if (xSection.isDBInvisible(activeUnit_1) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.DB_Invisible, ref LocalResult).HasValue)
			{
				result = SensorDetectionCheckResult.Fail_Other;
			}
			else
			{
				float float_10 = default(float);
				if (!(num >= 315f) && num > 45f)
				{
					if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
					{
						float_10 = xSection.get_Side(activeUnit_1);
					}
					else if (num >= 135f && num <= 225f)
					{
						float_10 = xSection.get_Rear(activeUnit_1);
					}
				}
				else
				{
					float_10 = xSection.get_Front(activeUnit_1);
				}
				if (!method_39(activeUnit_0, activeUnit_1, float_10, float_9, ActiveEmissionMode.Illuminate, list_2, activeUnit_0.WeatherAtMyLocation) && FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_ECMEquation, ref LocalResult).HasValue)
				{
					result = SensorDetectionCheckResult.Fail_NotEnoughReturn;
				}
				else
				{
					if (!Capabilities.SpaceSearch_ABM || !activeUnit_1.IsWeapon || (((Weapon)activeUnit_1).Type != Weapon._WeaponType.RV && ((Weapon)activeUnit_1).Type != Weapon._WeaponType.HGV))
					{
						goto IL_032f;
					}
					if (Horizon.RadarHorizonNM(activeUnit_0, activeUnit_1, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADARILLUMINATION_ABM_Horizon_Success, ref LocalResult).HasValue)
						{
							goto IL_032f;
						}
						result = SensorDetectionCheckResult.Success;
					}
					else
					{
						if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_ABM_Horizon_Failure, ref LocalResult).HasValue)
						{
							goto IL_032f;
						}
						result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
					}
				}
			}
			goto end_IL_0001;
			IL_00c8:
			if ((bool_3 && float_9 > 5f) || bool_4 || TargetIsWithinIlluminateCoverageArc(activeUnit_1) || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_CoveringArc, ref LocalResult).HasValue)
			{
				ActiveUnit parentPlatform = ParentPlatform;
				string feedbackMessage = "";
				num = Module_Unit.AngleOffThisUnitsBoresight(parentPlatform, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				int num2;
				if (this.get_IlluminatesInThisFrequency(FrequencyBand.A_Band))
				{
					num2 = 5001;
				}
				else
				{
					if (!this.get_IlluminatesInThisFrequency(FrequencyBand.B_Band) && !this.get_IlluminatesInThisFrequency(FrequencyBand.C_Band) && !this.get_IlluminatesInThisFrequency(FrequencyBand.D_Band))
					{
						desiredSignatureType = XSection._SignatureType.Radar_E_M;
						goto IL_0188;
					}
					num2 = 5001;
				}
				desiredSignatureType = (XSection._SignatureType)num2;
				goto IL_0188;
			}
			result = SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			goto end_IL_0001;
			IL_04da:
			if (FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_Other, ref LocalResult).HasValue)
			{
				result = SensorDetectionCheckResult.Fail_Other;
			}
			goto end_IL_0001;
			IL_03c3:
			if (Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_4.HasValue)
				{
					nullable_4 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, IgnoreRadarHorizon: true);
				}
				if (nullable_4.Value)
				{
					if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADARILLUMINATION_OTH_Success, ref LocalResult).HasValue)
					{
						goto IL_04da;
					}
					result = SensorDetectionCheckResult.Success;
				}
				else
				{
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_OTH_Failure, ref LocalResult).HasValue)
					{
						goto IL_04da;
					}
					result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				}
			}
			else
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen);
				}
				if (nullable_3.Value)
				{
					if (!FeedSensorFailureItem(Result: true, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS, ref LocalResult).HasValue)
					{
						goto IL_04da;
					}
					result = SensorDetectionCheckResult.Success;
				}
				else
				{
					if (!FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS_Failed, ref LocalResult).HasValue)
					{
						goto IL_04da;
					}
					result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				}
			}
			goto end_IL_0001;
			IL_032f:
			if (TargetsTrackedForFireControl_Readonly.Count <= 0)
			{
				goto IL_03c3;
			}
			bool flag2 = false;
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>(TargetsTrackedForFireControl_Readonly);
			list.Add(activeUnit_1);
			float num3 = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			int num4 = 0;
			do
			{
				if (!CanTrackAllTargetsAtThisBoresightBearing(this, (int)Math.Round(Math2.NormalizeBearing(num3 + (float)num4)), list))
				{
					num4++;
					continue;
				}
				flag2 = true;
				break;
			}
			while (num4 <= 359);
			if (flag2 || !FeedSensorFailureItem(Result: false, SensorDetectionFeedback.RADARILLUMINATION_CoveringArc, ref LocalResult).HasValue)
			{
				goto IL_03c3;
			}
			result = SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100736", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			result = (SensorDetectionCheckResult)num5;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private SensorDetectionCheckResult method_33(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, bool bool_3, bool bool_4, ref Module_Unit.Unit.LOSCheckResult? nullable_3)
	{
		SensorDetectionCheckResult result;
		try
		{
			if (nullable_3.HasValue && nullable_3.Value != Module_Unit.Unit.LOSCheckResult.Success)
			{
				switch (nullable_3.Value)
				{
				default:
				{
					int num;
					if (!Debugger.IsAttached)
					{
						num = 9999;
					}
					else
					{
						Debugger.Break();
						num = 9999;
					}
					result = (SensorDetectionCheckResult)num;
					break;
				}
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					result = SensorDetectionCheckResult.Fail_Other;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
					break;
				}
			}
			else if ((!bool_3 || !(float_9 > 5f)) && !bool_4 && !TargetIsWithinIlluminateCoverageArc(activeUnit_1))
			{
				result = SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			}
			else
			{
				float num2 = default(float);
				switch (activeUnit_1.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
					num2 = (float)((double)maxRange * 0.1);
					break;
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					num2 = (float)((double)maxRange * 0.18);
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					num2 = (float)((double)maxRange * 0.4);
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num2 = (float)((double)maxRange * 0.62);
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					num2 = (float)((double)maxRange * 0.8);
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					num2 = maxRange;
					break;
				}
				if (!(float_9 <= num2))
				{
					result = SensorDetectionCheckResult.Fail_OutOfRange;
				}
				else if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon && ((Weapon)activeUnit_1).IsReEntryVehicle)
				{
					float TargetAltitude = (int)Math.Round(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					result = ((Horizon.VisualHorizonNM(activeUnit_0, ref TargetAltitude, this) > Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null))) ? SensorDetectionCheckResult.Success : SensorDetectionCheckResult.Fail_NoLOS_Horizon);
				}
				else
				{
					if (!nullable_3.HasValue)
					{
						nullable_3 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, ConsiderClouds: true);
					}
					if (nullable_3.Value == Module_Unit.Unit.LOSCheckResult.Success)
					{
						result = SensorDetectionCheckResult.Success;
					}
					else
					{
						switch (nullable_3.Value)
						{
						default:
						{
							int num3;
							if (Debugger.IsAttached)
							{
								Debugger.Break();
								num3 = 9999;
							}
							else
							{
								num3 = 9999;
							}
							result = (SensorDetectionCheckResult)num3;
							break;
						}
						case Module_Unit.Unit.LOSCheckResult.Fail_Other:
							result = SensorDetectionCheckResult.Fail_Other;
							break;
						case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
							result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
							break;
						case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
							result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
							break;
						case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
							result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100737", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (SensorDetectionCheckResult)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private SensorDetectionCheckResult method_34(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref Module_Unit.Unit.LOSCheckResult? nullable_3)
	{
		SensorDetectionCheckResult result;
		try
		{
			if (!nullable_3.HasValue)
			{
				goto IL_00ac;
			}
			int? num = (int?)nullable_3;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num != 1)) != true)
			{
				goto IL_00ac;
			}
			switch (nullable_3.Value)
			{
			case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
				result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				break;
			default:
			{
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 9999;
				}
				else
				{
					Debugger.Break();
					num2 = 9999;
				}
				result = (SensorDetectionCheckResult)num2;
				break;
			}
			case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
				result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				break;
			}
			goto end_IL_0001;
			IL_00ac:
			float float_10 = maxRange;
			method_12(activeUnit_0, activeUnit_1, ref float_10);
			if (float_9 <= float_10)
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, ConsiderClouds: true);
				}
				if (nullable_3.Value == Module_Unit.Unit.LOSCheckResult.Success)
				{
					result = SensorDetectionCheckResult.Success;
				}
				else
				{
					switch (nullable_3.Value)
					{
					default:
					{
						int num3;
						if (!Debugger.IsAttached)
						{
							num3 = 9999;
						}
						else
						{
							Debugger.Break();
							num3 = 9999;
						}
						result = (SensorDetectionCheckResult)num3;
						break;
					}
					case Module_Unit.Unit.LOSCheckResult.Fail_Other:
						result = SensorDetectionCheckResult.Fail_Other;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
						result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
						result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
						result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
						break;
					}
				}
			}
			else
			{
				result = SensorDetectionCheckResult.Fail_OutOfRange;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100738", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 9999;
			}
			else
			{
				num4 = 9999;
			}
			result = (SensorDetectionCheckResult)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private SensorDetectionCheckResult method_35(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, ref Module_Unit.Unit.LOSCheckResult? nullable_3)
	{
		SensorDetectionCheckResult result;
		try
		{
			if (nullable_3.HasValue && nullable_3.Value != Module_Unit.Unit.LOSCheckResult.Success)
			{
				switch (nullable_3.Value)
				{
				default:
				{
					int num;
					if (!Debugger.IsAttached)
					{
						num = 9999;
					}
					else
					{
						Debugger.Break();
						num = 9999;
					}
					result = (SensorDetectionCheckResult)num;
					break;
				}
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					result = SensorDetectionCheckResult.Fail_Other;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
					break;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
					break;
				}
			}
			else if (!(float_9 <= maxRange))
			{
				result = SensorDetectionCheckResult.Fail_OutOfRange;
			}
			else
			{
				if (!nullable_3.HasValue)
				{
					nullable_3 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, ConsiderClouds: true);
				}
				if (nullable_3.Value == Module_Unit.Unit.LOSCheckResult.Success)
				{
					result = SensorDetectionCheckResult.Success;
				}
				else
				{
					switch (nullable_3.Value)
					{
					default:
					{
						int num2;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num2 = 9999;
						}
						else
						{
							num2 = 9999;
						}
						result = (SensorDetectionCheckResult)num2;
						break;
					}
					case Module_Unit.Unit.LOSCheckResult.Fail_Other:
						result = SensorDetectionCheckResult.Fail_Other;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
						result = SensorDetectionCheckResult.Fail_NoLOS_Horizon;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
						result = SensorDetectionCheckResult.Fail_NoLOS_Terrain;
						break;
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
						result = SensorDetectionCheckResult.Fail_NoLOS_Cloud;
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100739", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (SensorDetectionCheckResult)num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SensorDetectionCheckResult CanIlluminateTarget(ActiveUnit myParent, ActiveUnit theUnit, float TargetSlantRange, List<ActiveUnit> AffectingJammers, bool IgnoreArcAtLongRange, bool WeaponIsAirborne, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar)
	{
		SensorDetectionCheckResult result;
		if (myParent.IsWeapon && ((Weapon)myParent).IsDLZconstruct)
		{
			result = SensorDetectionCheckResult.Success;
		}
		else if (theUnit.IsMorituri)
		{
			result = SensorDetectionCheckResult.Fail_Other;
		}
		else
		{
			try
			{
				if ((!IgnoreArcAtLongRange || !(TargetSlantRange > 5f)) && !WeaponIsAirborne && !TargetIsWithinIlluminateCoverageArc(theUnit))
				{
					result = SensorDetectionCheckResult.Fail_OutsideCoverageArc;
				}
				else if (!(maxRange >= TargetSlantRange))
				{
					result = SensorDetectionCheckResult.Fail_OutOfRange;
				}
				else if (!this.get_IsSuitableForThisTarget(theUnit))
				{
					result = SensorDetectionCheckResult.Fail_NotSuitableForThisTarget;
				}
				else
				{
					int num;
					SensorDetectionCheckResult sensorDetectionCheckResult;
					switch (Type)
					{
					default:
						num = 0;
						goto IL_00d5;
					case Sensor_Type.LaserDesignator:
						sensorDetectionCheckResult = method_34(myParent, theUnit, TargetSlantRange, ref LOS_Exists_Visual);
						break;
					case Sensor_Type.Radar:
						sensorDetectionCheckResult = method_32(myParent, theUnit, TargetSlantRange, AffectingJammers, IgnoreArcAtLongRange, WeaponIsAirborne, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW);
						break;
					case Sensor_Type.SemiActive:
						num = 0;
						goto IL_00d5;
					case Sensor_Type.Visual:
						sensorDetectionCheckResult = method_33(myParent, theUnit, TargetSlantRange, IgnoreArcAtLongRange, WeaponIsAirborne, ref LOS_Exists_Visual);
						break;
					case Sensor_Type.Infrared:
						{
							sensorDetectionCheckResult = method_35(myParent, theUnit, TargetSlantRange, ref LOS_Exists_Visual);
							break;
						}
						IL_00d5:
						result = (SensorDetectionCheckResult)num;
						goto end_IL_0032;
					}
					result = sensorDetectionCheckResult;
				}
				end_IL_0032:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100740", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = (SensorDetectionCheckResult)num2;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public bool TargetIsWithinIlluminateCoverageArc(Module_Unit.Unit theTarget, float? CustomParentHeading = null)
	{
		bool result;
		try
		{
			if (theTarget != null)
			{
				if (Coverage_Illuminate.Has360Coverage.Value)
				{
					result = true;
				}
				else
				{
					ActiveUnit parentPlatform = ParentPlatform;
					float num = Math2.CalcAzimuth(parentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), parentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
					float num2 = (CustomParentHeading.HasValue ? CustomParentHeading.Value : parentPlatform.CurrentHeading);
					float num3 = Math2.NormalizeBearing(num - num2);
					num2 = 0f;
					float num4 = num3;
					result = ((num4 <= 22.5f) ? Coverage_Illuminate.SB1 : ((num4 <= 45f) ? Coverage_Illuminate.SB2 : ((num4 <= 67.5f) ? Coverage_Illuminate.SMF1 : ((num4 <= 90f) ? Coverage_Illuminate.SMF2 : ((num4 <= 112.5f) ? Coverage_Illuminate.SMA1 : ((num4 <= 135f) ? Coverage_Illuminate.SMA2 : ((num4 <= 157.5f) ? Coverage_Illuminate.SS1 : ((num4 <= 180f) ? Coverage_Illuminate.SS2 : ((num4 <= 202.5f) ? Coverage_Illuminate.PS1 : ((num4 <= 225f) ? Coverage_Illuminate.PS2 : ((num4 <= 247.5f) ? Coverage_Illuminate.PMA1 : ((num4 <= 270f) ? Coverage_Illuminate.PMA2 : ((num4 <= 292.5f) ? Coverage_Illuminate.PMF1 : ((num4 <= 315f) ? Coverage_Illuminate.PMF2 : ((!(num4 <= 337.5f)) ? Coverage_Illuminate.PB2 : Coverage_Illuminate.PB1)))))))))))))));
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100741", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			result = (byte)num5 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_36(CommDevice commDevice_0)
	{
		return UsedFrequencies.Intersect(commDevice_0.UsedFrequencies).Any();
	}

	private bool method_37(Sensor sensor_0)
	{
		int dBID;
		int dBID2;
		if (DBID <= sensor_0.DBID)
		{
			dBID = DBID;
			dBID2 = sensor_0.DBID;
		}
		else
		{
			dBID2 = DBID;
			dBID = sensor_0.DBID;
		}
		if (!sensor_0.IsGNSSJammer)
		{
			long key = MathFunctions.CombineIntegers(dBID2, dBID);
			ConcurrentDictionary<long, bool> cache_SensorCompatibleFrequencies = ParentPlatform.ParentScen.Cache_SensorCompatibleFrequencies;
			if (!cache_SensorCompatibleFrequencies.TryGetValue(key, out var value))
			{
				GlobalSingleton instance = GlobalSingleton.GetInstance();
				HashSet<FrequencyBand> usedFrequencies = sensor_0.UsedFrequencies;
				foreach (FrequencyBand usedFrequency in UsedFrequencies)
				{
					foreach (FrequencyBand item in usedFrequencies)
					{
						if (usedFrequency == item)
						{
							value = true;
							break;
						}
					}
					if (value)
					{
						break;
					}
				}
				if (!value)
				{
					foreach (FrequencyBand usedFrequency2 in sensor_0.UsedFrequencies)
					{
						if (!instance.NormalizedNatoFrequencyBand.ContainsKey(usedFrequency2))
						{
							continue;
						}
						foreach (FrequencyBand usedFrequency3 in UsedFrequencies)
						{
							if (instance.NormalizedNatoFrequencyBand[usedFrequency2].NonNatoFrequencies.Contains(usedFrequency3))
							{
								return true;
							}
						}
					}
				}
				cache_SensorCompatibleFrequencies.TryAdd(key, value);
				return value;
			}
			return value;
		}
		return UsedFrequencies.Contains(FrequencyBand.D_Band);
	}

	private bool method_38(Sensor sensor_0, float float_9, ActiveEmissionMode activeEmissionMode_0, Weather.WeatherProfile weatherProfile_0, bool bool_3 = false)
	{
		bool result;
		try
		{
			if (tradar_0 == null)
			{
				tradar_0 = new RadarModel.TRadar();
			}
			treceiver_0 = default(RadarModel.TReceiver);
			tradar_0.Altitude = (int)Math.Round(sensor_0.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			tradar_0.ElevationAngle = 0.0 - RadarModel.SurfaceGrazingAngle_deg(float_9, sensor_0.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref weatherProfile_0);
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				tradar_0.SetGainFromBeamwidth(sensor_0.RadarHorBeamwidthIlluminate, sensor_0.RadarVertBeamwidthIlluminate);
				tradar_0.PowerOutputW = sensor_0.RadarPeakPowerIlluminate;
				tradar_0.PulseWidth = sensor_0.RadarPulseWidthIlluminate;
				tradar_0.ProcessingGain = sensor_0.RadarProcessingGainLossIlluminate;
				tradar_0.SystemNoiseLevel = sensor_0.RadarSystemNoiseIlluminate;
				tradar_0.Frequency = (double)(sensor_0.UpperFreqIlluminate + sensor_0.LowerFreqIlluminate) / 2.0;
				tradar_0.PRF = sensor_0.float_1;
				break;
			case ActiveEmissionMode.Search_Track:
				tradar_0.SetGainFromBeamwidth(sensor_0.RadarHorBeamwidth, sensor_0.RadarVertBeamwidth);
				tradar_0.PowerOutputW = sensor_0.RadarPeakPower;
				tradar_0.PulseWidth = sensor_0.RadarPulseWidth;
				tradar_0.ProcessingGain = sensor_0.RadarProcessingGainLoss;
				tradar_0.SystemNoiseLevel = sensor_0.RadarSystemNoiseLevel;
				tradar_0.Frequency = (double)(sensor_0.UpperFreq + sensor_0.LowerFreq) / 2.0;
				tradar_0.PRF = sensor_0.RadarPRF;
				break;
			}
			if (sensor_0.Codes.AESA)
			{
				tradar_0.PowerOutputW *= 0.025;
			}
			treceiver_0.Altitude = (int)Math.Round(ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			treceiver_0.Sensitivity = ESMSensitivity;
			treceiver_0.SystemLoss = ESMSystemLoss;
			RadarModel.TRadar emitter = tradar_0;
			RadarModel.TReceiver receiver = treceiver_0;
			double distanceToEmitter = float_9;
			Weather.WeatherProfile env = weatherProfile_0;
			RadarModel.IDoubleMatrix PropLossMatrix = null;
			result = RadarModel.smethod_0(emitter, receiver, distanceToEmitter, 0.0, env, ref PropLossMatrix);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100742", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public double GetLandCoverRCSModifier(LandCover.LandCoverType theLandCover)
	{
		double result = 1.0;
		switch (theLandCover)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.06;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.32;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.66;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.5;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	private bool method_39(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_9, float float_10, ActiveEmissionMode activeEmissionMode_0, List<ActiveUnit> list_2, Weather.WeatherProfile weatherProfile_0, bool bool_3 = false)
	{
		bool result;
		try
		{
			if (tradar_0 == null)
			{
				tradar_0 = new RadarModel.TRadar();
			}
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			ActiveUnit parentPlatform = ParentPlatform;
			double num = parentPlatform.get_Latitude(GlobalVariables.ObjectTrue);
			double num2 = parentPlatform.get_Longitude(GlobalVariables.ObjectTrue);
			double num3 = activeUnit_1.get_Latitude(GlobalVariables.ObjectTrue);
			double num4 = activeUnit_1.get_Longitude(GlobalVariables.ObjectTrue);
			float num5 = activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
			double num6 = RadarModel.SurfaceGrazingAngle_deg(parentPlatform.RangeToUnit_Horiz(activeUnit_1, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue), parentPlatform.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) + (float)((Module_Unit.Unit)parentPlatform).get_MastHeight_Radar(this), num5, ref weatherProfile_0);
			tradar_0.Altitude = Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_0, this);
			tradar_0.ElevationAngle = 0.0 - num6;
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Search_Track:
				tradar_0.SetGainFromBeamwidth(RadarHorBeamwidth, RadarVertBeamwidth);
				tradar_0.PowerOutputW = RadarPeakPower;
				tradar_0.PulseWidth = RadarPulseWidth;
				tradar_0.ProcessingGain = RadarProcessingGainLoss;
				tradar_0.SystemNoiseLevel = RadarSystemNoiseLevel;
				tradar_0.Frequency = (double)(UpperFreq + LowerFreq) * 0.5;
				tradar_0.PRF = RadarPRF;
				break;
			case ActiveEmissionMode.Illuminate:
				tradar_0.SetGainFromBeamwidth(RadarHorBeamwidthIlluminate, RadarVertBeamwidthIlluminate);
				tradar_0.PowerOutputW = RadarPeakPowerIlluminate;
				tradar_0.PulseWidth = RadarPulseWidthIlluminate;
				tradar_0.ProcessingGain = RadarProcessingGainLossIlluminate;
				tradar_0.SystemNoiseLevel = RadarSystemNoiseIlluminate;
				tradar_0.Frequency = (double)(UpperFreqIlluminate + LowerFreqIlluminate) * 0.5;
				tradar_0.PRF = float_1;
				break;
			}
			if (!activeUnit_1.IsShip && !activeUnit_1.IsFacility && !activeUnit_1.IsSubmarine)
			{
				tTarget.Altitude = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_1);
			}
			else
			{
				tTarget.Height = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_1);
				tTarget.ObjectType = RadarModel.TTargetType.tgt_SurfaceShip;
				if (!Codes.PeriscopeSearch_Basic)
				{
					if (!Codes.PeriscopeAndSurfaceSearch_FineRangeResolution)
					{
						if (Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing)
						{
							tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing;
						}
					}
					else
					{
						tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.FineRangeResolution;
					}
				}
				else
				{
					tradar_0.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.Basic;
				}
			}
			tTarget.RCS = float_9;
			if ((activeUnit_1.IsAircraft || activeUnit_1.IsMissile) && (Codes.Doppler_LDSD_Full || Codes.Doppler_LDSD_Limited) && !Codes.AESA && !Codes.PESA && !Codes.FrequencyAgile)
			{
				float num7 = (parentPlatform.IsAircraft ? parentPlatform.CurrentHeading : Module_Unit.BearingToUnit_True(parentPlatform, activeUnit_1));
				if (Math.Abs(Math2.ApparentSpeedAlongAxisOfObserver(num7, activeUnit_1.CurrentHeading, Module_Unit.CurrentSpeed_Horizontal(activeUnit_1))) < 60.0)
				{
					if (activeUnit_1.IsMissile)
					{
						tTarget.RCS_m2 *= 0.06;
					}
					else if (activeUnit_1.IsAircraft)
					{
						GlobalVariables.ProficiencyLevel? proficiency = ((Aircraft)activeUnit_1).Proficiency;
						int? num8 = (int?)proficiency;
						if (((!num8.HasValue) ? ((bool?)null) : new bool?(num8.GetValueOrDefault() == 0)) != true)
						{
							num8 = (int?)proficiency;
							if (((!num8.HasValue) ? ((bool?)null) : new bool?(num8 == 1)) == true)
							{
								tTarget.RCS_m2 *= 0.32;
							}
							else
							{
								num8 = (int?)proficiency;
								if (((!num8.HasValue) ? ((bool?)null) : new bool?(num8 == 2)) != true)
								{
									num8 = (int?)proficiency;
									if (((!num8.HasValue) ? ((bool?)null) : new bool?(num8 == 3)) == true)
									{
										tTarget.RCS_m2 *= 0.004;
									}
									else
									{
										num8 = (int?)proficiency;
										if (((!num8.HasValue) ? ((bool?)null) : new bool?(num8 == 4)) == true)
										{
											tTarget.RCS_m2 *= 0.001;
										}
									}
								}
								else
								{
									tTarget.RCS_m2 *= 0.06;
								}
							}
						}
						else
						{
							tTarget.RCS_m2 *= 0.66;
						}
					}
				}
			}
			if (!bool_3 && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				double num9 = 1.0;
				Side natureSide = activeUnit_0.ParentScen.GetNatureSide();
				if ((activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit || activeUnit_1.IsAircraft) && parentPlatform.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(num3, num4, RequestIsFromGUI: false, parentPlatform.ParentScen) > 0)
				{
					(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(num3, num4, activeUnit_1.ParentScen, natureSide);
					if (!activeUnit_1.IsAircraft || activeUnit_1.CurrentAltitude_AGL < (float)landCoverAndHeightAtThisPoint.Item2)
					{
						num9 = GetLandCoverRCSModifier(landCoverAndHeightAtThisPoint.Item1);
						tTarget.RCS_m2 *= num9;
					}
				}
				if (activeUnit_0 != null && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced))
				{
					float num10 = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) + (float)((Module_Unit.Unit)activeUnit_0).get_MastHeight_Radar(this);
					if ((activeUnit_0.IsFacility || activeUnit_0.IsMobileGroundUnit || activeUnit_0.IsAircraft) && activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) < (float)Terrain.GlobalMaxTerrainElevation)
					{
						int elevation = Terrain.GetElevation(num, num2, RequestIsFromGUI: false, parentPlatform.ParentScen);
						if (elevation > 0)
						{
							(LandCover.LandCoverType, int) landCoverAndHeightAtThisPoint = LandCover.GetLandCoverAndHeightAtThisPoint(num, num2, activeUnit_0.ParentScen, natureSide);
							if (num10 - (float)elevation < (float)landCoverAndHeightAtThisPoint.Item2)
							{
								num9 = GetLandCoverRCSModifier(landCoverAndHeightAtThisPoint.Item1);
								tTarget.RCS_m2 *= num9;
							}
						}
					}
				}
			}
			if (list_2 == null)
			{
				list_2 = parentPlatform.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
			}
			if (threadLocal_0.IsValueCreated)
			{
				threadLocal_0.Value.Clear();
			}
			else
			{
				threadLocal_0.Value = new List<Sensor>();
			}
			foreach (ActiveUnit item in list_2)
			{
				Sensor[] sensors_Cached = item.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsOECM && sensor.IsActive() && sensor.get_CanJamThisSensor(this))
					{
						threadLocal_0.Value.Add(sensor);
					}
				}
			}
			float originalBearing = Math2.CalcAzimuth(num, num2, num3, num4);
			int count = threadLocal_0.Value.Count;
			RadarModel.TJammer[] array = new RadarModel.TJammer[count - 1 + 1];
			double[] array2 = new double[count - 1 + 1];
			double[] array3 = new double[count - 1 + 1];
			int num11 = count - 1;
			for (int j = 0; j <= num11; j++)
			{
				Sensor sensor2 = threadLocal_0.Value[j];
				RadarModel.TJammer tJammer = new RadarModel.TJammer();
				tJammer.Bandwidth = sensor2.ECM_Bandwidth;
				tJammer.Altitude = sensor2.ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
				tJammer.Frequency = tradar_0.Frequency;
				tJammer.Gain = sensor2.ECM_Gain;
				tJammer.OutputW = sensor2.ECM_PeakPower;
				if (!Codes.AESA)
				{
					if (!Codes.PESA)
					{
						if (Codes.FrequencyAgile)
						{
							tJammer.OutputW *= 0.75;
						}
					}
					else
					{
						tJammer.OutputW *= 0.5;
					}
				}
				else
				{
					tJammer.OutputW *= 0.1;
				}
				int num12 = TechGeneration - sensor2.TechGeneration;
				if (num12 < -3)
				{
					tJammer.OutputW *= 20.0;
				}
				else if (num12 == -3)
				{
					tJammer.OutputW *= 10.0;
				}
				else if (num12 == -2)
				{
					tJammer.OutputW *= 5.0;
				}
				else if (num12 == -1)
				{
					tJammer.OutputW *= 2.0;
				}
				else if (num12 != 0)
				{
					if (num12 == 1)
					{
						tJammer.OutputW *= 0.5;
					}
					else if (num12 == 2)
					{
						tJammer.OutputW *= 0.2;
					}
					else if (num12 == 3)
					{
						tJammer.OutputW *= 0.1;
					}
					else if (num12 > 3)
					{
						tJammer.OutputW *= 0.05;
					}
				}
				array[j] = tJammer;
				float num13 = Module_Unit.RangeToUnit_Slant(parentPlatform, sensor2.ParentPlatform, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				array2[j] = num13;
				float num14 = MathFunctions.AngularDifference(originalBearing, Math2.CalcAzimuth(num, num2, sensor2.ParentPlatform.get_Latitude(GlobalVariables.ObjectTrue), sensor2.ParentPlatform.get_Longitude(GlobalVariables.ObjectTrue)));
				array3[j] = num14;
			}
			int num15;
			if (Codes.AESA)
			{
				num15 = 0;
			}
			else
			{
				bool flag = false;
				double num16 = 1.0;
				foreach (ChaffCorridorCloud chaffCloud in parentPlatform.ParentScen.ChaffClouds)
				{
					if (!Capabilities.AltitudeInfo || (!(num5 > (float)chaffCloud.CurtainCeiling) && !(num5 < (float)chaffCloud.CurtainFloor)))
					{
						Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(((Module_Unit.Unit)chaffCloud).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)chaffCloud).get_Longitude((GlobalVariables.BooleanObject)null), chaffCloud.CoverageLength, chaffCloud.CoverageWidth, chaffCloud.CurrentHeading);
						if (((Module_Unit.Unit)activeUnit_1).get_IsInsideThisArea(rectangularArea, parentPlatform.ParentScen, UseCache: false))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					RadioElectronicFrequency[] array4 = null;
					switch (activeEmissionMode_0)
					{
					case ActiveEmissionMode.Illuminate:
						array4 = IlluminationFreqs;
						break;
					case ActiveEmissionMode.Search_Track:
						array4 = SearchFreqs;
						break;
					}
					RadioElectronicFrequency[] array5 = array4;
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						FrequencyBand band = array5[k].Band;
						FrequencyBand num17 = band - 1001L;
						if ((ulong)num17 <= 11uL)
						{
							switch (num17)
							{
							case (FrequencyBand)0L:
							case (FrequencyBand)1L:
							case (FrequencyBand)2L:
								num16 = Math.Min(0.05, num16);
								continue;
							case (FrequencyBand)3L:
							case (FrequencyBand)4L:
							case (FrequencyBand)5L:
								num16 = Math.Min(0.1, num16);
								continue;
							case (FrequencyBand)6L:
							case (FrequencyBand)7L:
							case (FrequencyBand)8L:
								num16 = Math.Min(0.15, num16);
								continue;
							case (FrequencyBand)9L:
							case (FrequencyBand)10L:
							case (FrequencyBand)11L:
								num16 = Math.Min(0.2, num16);
								continue;
							}
						}
						num16 = Math.Min(0.25, num16);
					}
					GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
					if (techGeneration < GlobalVariables.TechGenerationClass.const_3)
					{
						num16 *= 0.1;
					}
					else if (techGeneration == GlobalVariables.TechGenerationClass.const_4)
					{
						num16 *= 0.15;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_5)
					{
						num16 *= 0.2;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_6)
					{
						num16 *= 0.3;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.const_7)
					{
						num16 *= 0.4;
					}
					else
					{
						switch (techGeneration)
						{
						case GlobalVariables.TechGenerationClass.const_8:
							num16 *= 0.5;
							break;
						case GlobalVariables.TechGenerationClass.const_9:
							num16 *= 0.6;
							break;
						case GlobalVariables.TechGenerationClass.const_10:
							num16 *= 0.7;
							break;
						default:
							switch (techGeneration)
							{
							case GlobalVariables.TechGenerationClass.const_10:
								num16 *= 0.8;
								break;
							case GlobalVariables.TechGenerationClass.const_11:
								num16 *= 0.9;
								break;
							}
							break;
						}
					}
					num16 = Math.Min(1.0, num16);
					tTarget.RCS_m2 *= num16;
					num15 = 0;
				}
				else
				{
					num15 = 0;
				}
			}
			RadarModel.TSurfaceType terrainType = (RadarModel.TSurfaceType)num15;
			float num18 = 0f;
			RadarModel.RadarClutterType radarClutterType = default(RadarModel.RadarClutterType);
			if (tradar_0.ElevationAngle > 0.0)
			{
				radarClutterType = RadarModel.RadarClutterType.None;
			}
			else
			{
				int num19;
				if (Codes.AESA && activeEmissionMode_0 == ActiveEmissionMode.Illuminate)
				{
					num19 = 0;
				}
				else
				{
					if (!parentPlatform.Sensory.UnitIsPreviouslyDetected(activeUnit_1))
					{
						if (activeUnit_1.IsShip || activeUnit_1.IsSubmarine || (activeUnit_1.IsAircraft && !Module_Unit.IsOverLand(activeUnit_1)))
						{
							Terrain.LandPercentageInThisSquare(num3, num4, 2f);
							terrainType = RadarModel.TSurfaceType.st_Mountains;
						}
						num18 = Terrain.GetMaxSlope(num3, num4, RequestIsFromGUI: false, parentPlatform.ParentScen);
						if (Terrain.GetElevation(num3, num4, RequestIsFromGUI: false, parentPlatform.ParentScen) <= 0)
						{
							terrainType = RadarModel.TSurfaceType.st_Wetland;
						}
						else
						{
							float num20 = num18;
							terrainType = ((num20 < 0.1f) ? RadarModel.TSurfaceType.st_Wetland : ((num20 < 0.2f) ? RadarModel.TSurfaceType.st_Forest : ((num20 < 0.3f) ? RadarModel.TSurfaceType.st_Shrubland : ((!(num20 < 0.4f)) ? RadarModel.TSurfaceType.st_Mountains : RadarModel.TSurfaceType.st_Cropland))));
						}
						goto IL_0e6f;
					}
					num19 = 0;
				}
				radarClutterType = (RadarModel.RadarClutterType)num19;
			}
			goto IL_0e6f;
			IL_0fff:
			int num21;
			result = (byte)num21 != 0;
			goto end_IL_0001;
			IL_0e6f:
			RadarModel.TRadar radar = tradar_0;
			double slantDistanceToTarget = float_10;
			Weather.WeatherProfile env = weatherProfile_0;
			RadarModel.RadarClutterType clutterTypeToUse = radarClutterType;
			GlobalVariables.TechGenerationClass techGeneration2 = TechGeneration;
			RadarModel.TRadar RadarReceiver = null;
			bool flag2;
			if (flag2 = RadarModel.RadarECMEquation(radar, tTarget, count, array, slantDistanceToTarget, array2, array3, env, clutterTypeToUse, techGeneration2, 0.0, 0.0, ref RadarReceiver, 0.0, terrainType, num18))
			{
				if (bool_3)
				{
					goto IL_0ffe;
				}
				if (!bool_1)
				{
					num21 = 1;
				}
				else if (!activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced))
				{
					num21 = 1;
				}
				else
				{
					if (!activeUnit_0.IsSatellite)
					{
						if (!activeUnit_1.IsSatellite)
						{
							double num22 = 1.0;
							Side natureSide2 = activeUnit_0.ParentScen.GetNatureSide();
							if (activeUnit_0 == null)
							{
								num21 = 1;
								goto IL_0fff;
							}
							float startAlt = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) + (float)((Module_Unit.Unit)activeUnit_0).get_MastHeight_Radar(this);
							IEnumerable<(LandCover.LandCoverType, int)> allLandCoverAndCoverElevationBetweenPoints = LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(num, num2, startAlt, num3, num4, activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue), activeUnit_0.ParentScen, natureSide2);
							foreach (var item2 in allLandCoverAndCoverElevationBetweenPoints)
							{
								num22 = GetLandCoverRCSModifier(item2.Item1);
								tTarget.RCS_m2 *= num22;
								RadarModel.TRadar radar2 = tradar_0;
								double slantDistanceToTarget2 = float_10;
								Weather.WeatherProfile env2 = weatherProfile_0;
								RadarModel.RadarClutterType clutterTypeToUse2 = radarClutterType;
								GlobalVariables.TechGenerationClass techGeneration3 = TechGeneration;
								RadarReceiver = null;
								if (flag2 = RadarModel.RadarECMEquation(radar2, tTarget, count, array, slantDistanceToTarget2, array2, array3, env2, clutterTypeToUse2, techGeneration3, 0.0, 0.0, ref RadarReceiver, 0.0, terrainType, num18))
								{
									continue;
								}
								result = flag2;
								goto end_IL_0001;
							}
						}
						goto IL_0ffe;
					}
					num21 = 1;
				}
				goto IL_0fff;
			}
			result = false;
			goto end_IL_0001;
			IL_0ffe:
			num21 = 1;
			goto IL_0fff;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100743", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num23;
			if (!Debugger.IsAttached)
			{
				num23 = 0;
			}
			else
			{
				Debugger.Break();
				num23 = 0;
			}
			result = (byte)num23 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_40(Module_Unit.Unit unit_0, float float_9, float float_10, ActiveEmissionMode activeEmissionMode_0)
	{
		bool result;
		try
		{
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			RadarModel.TRadar Radar = new RadarModel.TRadar();
			new Weather.WeatherProfile();
			Radar.Altitude = (int)Math.Round(ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				Radar.SetGainFromBeamwidth(RadarHorBeamwidthIlluminate, RadarVertBeamwidthIlluminate);
				Radar.PowerOutputW = RadarPeakPowerIlluminate;
				Radar.PulseWidth = RadarPulseWidthIlluminate;
				Radar.ProcessingGain = RadarProcessingGainLossIlluminate;
				Radar.SystemNoiseLevel = RadarSystemNoiseIlluminate;
				Radar.Frequency = (double)(UpperFreqIlluminate + LowerFreqIlluminate) / 2.0;
				Radar.PRF = float_1;
				break;
			case ActiveEmissionMode.Search_Track:
				Radar.SetGainFromBeamwidth(RadarHorBeamwidth, RadarVertBeamwidth);
				Radar.PowerOutputW = RadarPeakPower;
				Radar.PulseWidth = RadarPulseWidth;
				Radar.ProcessingGain = RadarProcessingGainLoss;
				Radar.SystemNoiseLevel = RadarSystemNoiseLevel;
				Radar.Frequency = (double)(UpperFreq + LowerFreq) / 2.0;
				Radar.PRF = RadarPRF;
				break;
			}
			Radar.ElevationAngle = 0.0;
			tTarget.Altitude = (int)Math.Round(unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			tTarget.RCS = float_9;
			result = RadarModel.SimpleRadarEquation(ref Radar, tTarget.RCS_m2, float_10);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100744", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Sensor GetEyeball(SQLiteConnection sqliteConnection_0)
	{
		Sensor result;
		try
		{
			Sensor obj = new Sensor(ref sqliteConnection_0, 0, "Mk1 Eyeball", Sensor_Type.Visual, Sensor_Role.AirSurfaceSearch_3D_SR, GlobalVariables.TechGenerationClass.NotApplicable, 50f, 0f, 180, 180, 10, 0, 0f, 0f, 0f, 0f, 0, 0f, 0f, 0f, IsEyeball: true, 0, 0, 0, 0, 0f, 0L, 0L, 0L, 0L, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0)
			{
				bool_2 = true,
				Capabilities = 
				{
					AirSearch = true,
					SurfaceSearch = true,
					LandSearch_Mobile = true,
					LandSearch_Fixed = true,
					PeriscopeSearch = true,
					AltitudeInfo = true,
					HeadingInfo = true,
					RangeInfo = true
				},
				Codes = 
				{
					ContinousTrackingCapable_Visual = true,
					IFF_Capable = true,
					Classification = true
				},
				SearchFreqs = new RadioElectronicFrequency[1]
			};
			obj.SearchFreqs[0] = new RadioElectronicFrequency(FrequencyBand.Visual_Light);
			obj.ScanInterval = 1;
			obj.AngleResolution = 0f;
			obj.RangeResolution_Nominal = 0f;
			obj.VisualDetectionZoomLevel = 1f;
			obj.VisualClassZoomLevel = 1f;
			result = obj;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100745", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Sensor();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsMechanicalVisual()
	{
		if (IsMk1Eyeball)
		{
			return true;
		}
		if (Type != Sensor_Type.Visual)
		{
			return false;
		}
		int result;
		switch (Role)
		{
		case Sensor_Role.LLTV_NightVisionGoggles_NVG:
			result = 1;
			break;
		case Sensor_Role.Visual_Optical_Sight:
		case Sensor_Role.Visual_Bomb_Sight:
			result = 1;
			break;
		default:
			return false;
		case Sensor_Role.Visual_Binoculars:
		case Sensor_Role.Visual_Surveillance_Periscope:
		case Sensor_Role.Visual_Fire_Control_Periscope:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public override void vmethod_0(float PulseStrengthRatio)
	{
		if (IsMechanicalVisual() || base.Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((PulseStrengthRatio < 0.1f) ? 0.05f : ((PulseStrengthRatio < 0.25f) ? 0.15f : ((PulseStrengthRatio < 0.5f) ? 0.3f : ((!(PulseStrengthRatio < 0.75f)) ? 0.75f : 0.5f))));
		GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
		num = ((techGeneration < GlobalVariables.TechGenerationClass.const_4) ? ((float)((double)num - 0.3)) : ((techGeneration < GlobalVariables.TechGenerationClass.const_7) ? ((float)((double)num + 0.1)) : ((techGeneration < GlobalVariables.TechGenerationClass.const_9) ? ((float)((double)num + 0.3)) : ((techGeneration >= GlobalVariables.TechGenerationClass.const_9) ? ((float)((double)num + 0.5)) : ((float)((double)num + 0.4))))));
		if (!IsOperating)
		{
			num /= 3f;
		}
		if ((double)num < 0.05)
		{
			num = 0.05f;
		}
		if ((double)num > 0.95)
		{
			num = 0.95f;
		}
		float num2 = num;
		float num3 = (float)((double)num - 0.1);
		float num4 = (float)((double)num - 0.2);
		float num5 = (float)((double)num - 0.3);
		double num6 = GameGeneral.GlobalRNG.NextDouble();
		if (num6 < (double)num5)
		{
			Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered heavy damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered moderate damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered light damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}

	public static int VolumeSearchRange_IR(Sensor theS)
	{
		if (theS.Role == Sensor_Role.Infrared_BMEWS)
		{
			return (int)Math.Round(theS.maxRange);
		}
		switch (theS.TechGeneration)
		{
		case GlobalVariables.TechGenerationClass.LLTV_Gen1:
			return 1;
		case GlobalVariables.TechGenerationClass.LLTV_Gen2:
			return 3;
		case GlobalVariables.TechGenerationClass.LLTV_Gen3:
			return 6;
		case GlobalVariables.TechGenerationClass.const_2:
			return 3;
		case GlobalVariables.TechGenerationClass.const_3:
			return 3;
		case GlobalVariables.TechGenerationClass.const_4:
			return 4;
		case GlobalVariables.TechGenerationClass.const_5:
			return 4;
		case GlobalVariables.TechGenerationClass.const_6:
			return 5;
		case GlobalVariables.TechGenerationClass.const_7:
			return 5;
		case GlobalVariables.TechGenerationClass.const_8:
			return 10;
		case GlobalVariables.TechGenerationClass.const_9:
			return 10;
		case GlobalVariables.TechGenerationClass.const_10:
			return 20;
		case GlobalVariables.TechGenerationClass.const_11:
			return 20;
		case GlobalVariables.TechGenerationClass.const_12:
			return 25;
		case GlobalVariables.TechGenerationClass.const_13:
			return 25;
		case GlobalVariables.TechGenerationClass.const_14:
			return 30;
		case GlobalVariables.TechGenerationClass.const_15:
			return 30;
		case GlobalVariables.TechGenerationClass.const_16:
			return 35;
		default:
		{
			int result;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				result = 25;
			}
			else
			{
				result = 25;
			}
			return result;
		}
		case GlobalVariables.TechGenerationClass.IR_Imaging_FPA:
			return 25;
		case GlobalVariables.TechGenerationClass.IR_DualSpectral:
			return 20;
		case GlobalVariables.TechGenerationClass.IR_NonImaging:
			return 5;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen1:
			return 10;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen2:
			return 15;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen3:
			return 20;
		}
	}

	public static int VolumeSearchRange_Visual(Sensor theS)
	{
		if (theS.bool_2)
		{
			return 15;
		}
		switch (theS.TechGeneration)
		{
		case GlobalVariables.TechGenerationClass.LLTV_Gen1:
			return 6;
		case GlobalVariables.TechGenerationClass.LLTV_Gen2:
			return 8;
		case GlobalVariables.TechGenerationClass.LLTV_Gen3:
			return 10;
		case GlobalVariables.TechGenerationClass.Visual_Gen1:
			return 12;
		case GlobalVariables.TechGenerationClass.Visual_Gen2:
			return 15;
		case GlobalVariables.TechGenerationClass.Visual_Gen3:
			return 20;
		default:
		{
			int result;
			if (!Debugger.IsAttached)
			{
				result = 20;
			}
			else
			{
				Debugger.Break();
				result = 20;
			}
			return result;
		}
		case GlobalVariables.TechGenerationClass.Visual:
			return 10;
		case GlobalVariables.TechGenerationClass.const_2:
			return 6;
		case GlobalVariables.TechGenerationClass.const_3:
			return 6;
		case GlobalVariables.TechGenerationClass.const_4:
			return 8;
		case GlobalVariables.TechGenerationClass.const_5:
			return 8;
		case GlobalVariables.TechGenerationClass.const_6:
			return 10;
		case GlobalVariables.TechGenerationClass.const_7:
			return 10;
		case GlobalVariables.TechGenerationClass.const_8:
			return 20;
		case GlobalVariables.TechGenerationClass.const_9:
			return 20;
		case GlobalVariables.TechGenerationClass.const_10:
			return 40;
		case GlobalVariables.TechGenerationClass.const_11:
			return 40;
		case GlobalVariables.TechGenerationClass.const_12:
			return 50;
		case GlobalVariables.TechGenerationClass.const_13:
			return 50;
		case GlobalVariables.TechGenerationClass.const_14:
			return 60;
		case GlobalVariables.TechGenerationClass.const_15:
			return 60;
		case GlobalVariables.TechGenerationClass.const_16:
			return 70;
		}
	}

	public void VisualIRZoom(ref float myDetectionV, ref float myClasssificationV, ref float myDetectionIR, ref float myClasssificationIR)
	{
		myDetectionV = VisualDetectionZoomLevel;
		myClasssificationV = VisualClassZoomLevel;
		myDetectionIR = float_2;
		myClasssificationIR = IRClassZoomLevel;
	}

	public override void ResolveDamageFromDazzler(float DazzleStrengthRatio)
	{
		Sensor_Type type = Type;
		if ((uint)(type - 2003) > 1u || base.Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		double num = ((DazzleStrengthRatio < 0.1f) ? 0.05 : ((DazzleStrengthRatio < 0.25f) ? 0.15 : ((DazzleStrengthRatio < 0.5f) ? 0.3 : ((!(DazzleStrengthRatio < 0.75f)) ? 0.75 : 0.5))));
		if (!IsOperating)
		{
			num = (float)(num / 3.0);
		}
		if (IsMk1Eyeball)
		{
			num += 0.2;
		}
		if (num < 0.05)
		{
			num = 0.05;
		}
		if (num > 0.95)
		{
			num = 0.95;
		}
		double num2 = num;
		double num3 = (float)(num - 0.1);
		double num4 = (float)(num - 0.2);
		double num5 = (float)(num - 0.3);
		double num6 = GameGeneral.GlobalRNG.NextDouble();
		if (num6 < num5)
		{
			Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else if (num6 < num4)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered heavy damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < num3)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered moderate damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < num2)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered light damage.", ParentPlatform.Name + " had a sensor damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}
}
