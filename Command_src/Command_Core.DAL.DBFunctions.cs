using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Cysharp.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core.DAL;

[StandardModule]
public sealed class DBFunctions
{
	private struct Struct15 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string string_0;

		public long Type;

		public long long_0;

		public double double_0;

		public double double_1;

		public double double_2;

		public double double_3;

		public double double_4;

		public double double_5;

		public double double_6;

		public double double_7;

		public long long_1;

		public long long_2;

		public long long_3;

		public long long_4;

		public double double_8;

		public double bkZyCtgdAdF;

		public double double_9;

		public double double_10;

		public double double_11;

		public double double_12;

		public double double_13;

		public double double_14;

		public double double_15;

		public double double_16;

		public double ycGyCdIgNid;

		public double double_17;

		public double double_18;

		public long long_5;

		public long long_6;

		public double double_19;

		public double double_20;

		public double double_21;

		public double double_22;

		public long long_7;

		public long long_8;

		public double double_23;

		public double double_24;

		public double double_25;

		public double double_26;

		public double bWmyCixLoXO;

		public bool bool_0;

		public long long_9;

		public long long_10;

		public long long_11;

		public double double_27;

		public long long_12;

		public double OiqyCwnjbxi;

		public bool bool_1;

		public long long_13;

		public double double_28;

		public double double_29;

		public double double_30;

		public bool bool_2;

		public long long_14;

		public bool bool_3;

		public bool bool_4;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "Generation");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "Length");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_1, "Span");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_2, "Diameter");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_3, "Weight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_4, "BurnoutTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_5, "BurnoutWeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_6, "CruiseAltitude");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_7, "CruiseAltitude_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "WaypointNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "IlluminationTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_3, "CEP");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_4, "CEPSurface");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_8, "AirPoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bkZyCtgdAdF, "SurfacePoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_9, "LandPoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_10, "SubsurfacePoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_11, "ClimbRate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_12, "AirRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_13, "AirRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_14, "SurfaceRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_15, "SurfaceRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_16, "LandRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ycGyCdIgNid, "LandRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_17, "SubsurfaceRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_18, "SubsurfaceRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_5, "LaunchSpeedMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_6, "LaunchSpeedMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_19, "LaunchAltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_20, "LaunchAltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_21, "LaunchAltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_22, "LaunchAltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_7, "TargetSpeedMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_8, "TargetSpeedMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_23, "TargetAltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_24, "TargetAltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_25, "TargetAltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_26, "TargetAltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bWmyCixLoXO, "SnapUpDownAltitude");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "CanActAsSensor");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_9, "MaxFlightTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_10, "DetonationDelay");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_11, "TorpedoSpeedCruise");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_27, "TorpedoRangeCruise");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_12, "TorpedoSpeedFull");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref OiqyCwnjbxi, "TorpedoRangeFull");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "BuddyIlluminationForCEC");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_13, "Cargo_Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_28, "Cargo_Mass");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_29, "Cargo_Volume");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_30, "Cargo_Crew");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_2, "Cargo_ParadropCapable");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_14, "Cost");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_3, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_4, "Deprecated");
		}

		static Struct15()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct16 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public long Type;

		public string string_0;

		public bool bool_0;

		public double? nullable_0;

		public double double_0;

		public double double_1;

		public double double_2;

		public double double_3;

		public bool bool_1;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref nullable_0, "NumberOfEngines");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "ThrustPerEngineMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_1, "ThrustPerEngineAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_2, "SFCMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_3, "SFCAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "Deprecated");
		}

		static Struct16()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct17 : DBCache.I_CacheableRow
	{
		public long long_0;

		public long ID;

		public long long_1;

		public long long_2;

		public bool bool_0;

		public bool bool_1;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "CommID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "ComponentNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "ComponentID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "ParentSpecific");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "IsRelay");
		}

		static Struct17()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct18 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string string_0;

		public long Type;

		public double DamagePoints;

		public long long_0;

		public long long_1;

		public double double_0;

		public long long_2;

		public long long_3;

		public long long_4;

		public bool bool_0;

		public bool bool_1;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref DamagePoints, "DamagePoints");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "ProjectileCaliber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "ExplosivesType");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "ExplosivesWeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "NumberOfWarheads");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_3, "ClusterBombDispersionAreaLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_4, "ClusterBombDispersionAreaWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "Deprecated");
		}

		static Struct18()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct19 : DBCache.I_CacheableRow
	{
		public double double_0;

		public double double_1;

		public double double_2;

		public double double_3;

		public double double_4;

		public double double_5;

		public double double_6;

		public long long_0;

		public double double_7;

		public double double_8;

		public double double_9;

		public double double_10;

		public double double_11;

		public double double_12;

		public double double_13;

		public long long_1;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "RadarHorizontalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_1, "RadarVerticalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_2, "RadarSystemNoiseLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_3, "RadarProcessingGainLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_4, "RadarPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_5, "RadarPulseWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_6, "RadarBlindTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "RadarPRF");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_7, "RadarHorizontalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_8, "RadarVerticalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_9, "RadarSystemNoiseLevelIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_10, "RadarProcessingGainLossIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_11, "RadarPeakPowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_12, "RadarPulseWidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_13, "RadarBlindTimeIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "RadarPRFIlluminate");
		}

		static Struct19()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct20 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public long Type;

		public string string_0;

		public bool bool_0;

		public double double_0;

		public double double_1;

		public double double_2;

		public double double_3;

		public double double_4;

		public bool bool_1;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "NumberOfEngines");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_1, "ThrustPerEngineMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_2, "ThrustPerEngineAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_3, "SFCMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_4, "SFCAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "Deprecated");
		}

		static Struct20()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct21 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string string_0;

		public long Type;

		public long long_0;

		public long long_1;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public bool bool_3;

		public long long_2;

		public long long_3;

		public long long_4;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "Range");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "Channels");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "IsOptional");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "WeaponLinkRequiresSensor");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_2, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_3, "Deprecated");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "QualityGrade");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_3, "LatencyGrade");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_4, "Latency");
		}

		static Struct21()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct22 : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string string_0;

		public long Type;

		public long Role;

		public long long_0;

		public long long_1;

		public double double_0;

		public double double_1;

		public long long_2;

		public long long_3;

		public long long_4;

		public long long_5;

		public long long_6;

		public double double_2;

		public long long_7;

		public double double_3;

		public double double_4;

		public long long_8;

		public long long_9;

		public long long_10;

		public long long_11;

		public long long_12;

		public double double_5;

		public double double_6;

		public double double_7;

		public double double_8;

		public double double_9;

		public double double_10;

		public double double_11;

		public double double_12;

		public double double_13;

		public double double_14;

		public double kZuyNdCasPc;

		public long long_13;

		public double double_15;

		public double double_16;

		public double double_17;

		public double double_18;

		public double double_19;

		public double double_20;

		public double double_21;

		public long long_14;

		public double double_22;

		public double double_23;

		public double double_24;

		public bool bool_0;

		public double double_25;

		public double double_26;

		public double double_27;

		public long long_15;

		public double double_28;

		public double double_29;

		public double double_30;

		public double double_31;

		public double double_32;

		public double double_33;

		public double double_34;

		public double double_35;

		public double double_36;

		public double double_37;

		public long long_16;

		public double double_38;

		public double double_39;

		public double double_40;

		public double double_41;

		public long long_17;

		public long long_18;

		public long long_19;

		public long long_20;

		public bool bool_1;

		public double double_42;

		public double double_43;

		public double double_44;

		public double double_45;

		public double double_46;

		public double double_47;

		public bool bool_2;

		public string Description;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref string_0, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Role, "Role");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "Generation");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "MasqueradeAs");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_0, "RangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_1, "RangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "AltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_3, "AltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_4, "AltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_5, "AltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_6, "ScanInterval");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_2, "ResolutionRange");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_7, "ResolutionHeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_3, "ResolutionAngle");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_4, "DirectionFindingAccuracy");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_8, "MaxContactsAir");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_9, "MaxContactsSurface");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_10, "MaxContactsSubmarine");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_11, "MaxContactsIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_12, "Availability");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_5, "FrequencyUpper");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_6, "FrequencyLower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_7, "FrequencyLowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_8, "FrequencyUpperIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_9, "RadarHorizontalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_10, "RadarVerticalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_11, "RadarSystemNoiseLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_12, "RadarProcessingGainLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_13, "RadarPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_14, "RadarPulseWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref kZuyNdCasPc, "RadarBlindTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_13, "RadarPRF");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_15, "RadarHorizontalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_16, "RadarVerticalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_17, "RadarSystemNoiseLevelIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_18, "RadarProcessingGainLossIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_19, "RadarPeakPowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_20, "RadarPulseWidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_21, "RadarBlindTimeIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_14, "RadarPRFIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_22, "ESMSensitivity");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_23, "ESMSystemLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_24, "ESMNumberOfChannels");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "ESMPreciseEmitterID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_25, "ECMGain");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_26, "ECMPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_27, "ECMBandwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_15, "ECMNumberOfTargets");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_28, "ECMPoKReduction");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_29, "SonarSourceLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_30, "SonarPulseLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_31, "SonarDirectivityIndex");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_32, "SonarRecognitionDifferentialActive");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_33, "SonarRecognitionDifferentialPassive");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_34, "SonarSensorToMachineryDistance");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_35, "SonarTowLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_36, "SonarMinimumDeploymentDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_37, "SonarMaximumDeploymentDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_16, "SonarCZNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_38, "VisualDetectionZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_39, "VisualClassificationZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_40, "IRDetectionZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_41, "IRClassificationZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_17, "MineSweepWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_18, "MineSweepMinimumDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_19, "MineSweepMaximumDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_20, "MineSweepMaximumSpeed");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_42, "MinimumSignature_Radar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_43, "MinimumSignature_Visual");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_44, "MinimumSignature_IR");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_45, "MinimumSignature_ESM");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_46, "MinimumSignature_ActiveSonar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref double_47, "MinimumSignature_PassiveSonar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_2, "Deprecated");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Description, "Description");
		}

		static Struct22()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct23
	{
		public PlatformComponent._Coverage _Coverage_0;

		public PlatformComponent._Coverage _Coverage_1;
	}

	private struct Struct24 : DBCache.I_CacheableRow
	{
		public long ID;

		public long long_0;

		public long long_1;

		public long long_2;

		public long long_3;

		public long long_4;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public bool bool_3;

		public bool bool_4;

		public bool bool_5;

		public bool bool_6;

		public bool bool_7;

		public bool bool_8;

		public bool bool_9;

		public bool bool_10;

		public bool bool_11;

		public bool bool_12;

		public bool bool_13;

		public bool bool_14;

		public bool bool_15;

		public long long_5;

		public bool bool_16;

		public bool bool_17;

		public bool bool_18;

		public bool bool_19;

		public bool bool_20;

		public bool bool_21;

		public bool bool_22;

		public bool bool_23;

		public bool bool_24;

		public bool bool_25;

		public bool bool_26;

		public bool bool_27;

		public bool bool_28;

		public bool WyyyBwHmlo1;

		public bool YvEyBonbfdQ;

		public bool bool_29;

		public long long_6;

		public long long_7;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "SensorID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_1, "SensorType");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_2, "ComponentNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_3, "ComponentID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_4, "DegOverride");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_0, "SB1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_1, "SB2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_2, "SMF1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_3, "SMF2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_4, "SMA1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_5, "SMA2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_6, "SS1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_7, "SS2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_8, "PB1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_9, "PB2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_10, "PMF1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_11, "PMF2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_12, "PMA1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_13, "PMA2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_14, "PS1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_15, "PS2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_5, "DegOverrideMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_16, "SB1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_17, "SB2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_18, "SMF1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_19, "SMF2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_20, "SMA1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_21, "SMA2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_22, "SS1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_23, "SS2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_24, "PB1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_25, "PB2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_26, "PMF1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_27, "PMF2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_28, "PMA1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref WyyyBwHmlo1, "PMA2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref YvEyBonbfdQ, "PS1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref bool_29, "PS2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_6, "VerticalDegMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_7, "MastHeight");
		}

		static Struct24()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct25 : DBCache.I_CacheableRow
	{
		public long ID;

		public long Type;

		public long long_0;

		public void setValuesFromDataTableTyped(DataTableTyped sourceDataTable, DtrRow sourceRow)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref Type, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(sourceDataTable, sourceRow, ref long_0, "Capacity");
		}

		static Struct25()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct26
	{
		public int ID;

		public string Name;

		public GlobalVariables.ArmorRating armorRating_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public float DamagePoints;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public float float_0;

		public bool bool_3;

		public bool bool_4;

		public bool bool_5;

		public bool bool_6;

		public CargoType cargoType_0;

		public float float_1;

		public float float_2;

		public int int_4;

		public bool bool_7;

		public IMobileGroundUnit._MobileUnitCategory _MobileUnitCategory_0;
	}

	private static Dictionary<string, bool> dictionary_0;

	private static Dictionary<string, bool> dictionary_1;

	[ThreadStatic]
	private static string string_0;

	public static DatabaseCache CurrentDatabaseCache;

	private static ConcurrentDictionary<string, bool> concurrentDictionary_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public static bool Comms_State_Cached;

	public static bool Comms_HasLatencyTable;

	public static bool Comms_HasQualityTable;

	public static bool Comms_HasLatencyCol;

	public static bool Comms_HasQualityCol;

	public static string Comms_QualityGradeSource;

	public static string Comms_LatencyGradeSource;

	public static string Comms_QualityCols;

	public static string Comms_LatencyCols;

	public static string Comms_SQLString;

	static DBFunctions()
	{
		Class72.smethod_20();
		dictionary_0 = new Dictionary<string, bool>();
		dictionary_1 = new Dictionary<string, bool>();
		CurrentDatabaseCache = new DatabaseCache();
		concurrentDictionary_0 = new ConcurrentDictionary<string, bool>();
		Comms_State_Cached = false;
		Comms_HasLatencyTable = false;
		Comms_HasQualityTable = false;
		Comms_HasLatencyCol = false;
		Comms_HasQualityCol = false;
		Comms_QualityGradeSource = "";
		Comms_LatencyGradeSource = "";
		Comms_QualityCols = "";
		Comms_LatencyCols = "";
		Comms_SQLString = "";
	}

	public static void GetPlatformLists(ref DataTable DT_Aircraft, ref DataTable DT_Ships, ref DataTable DT_Subs, ref DataTable DT_Facilities, ref DataTable DT_GroundUnits, ref DataTable DT_Satellites, ref DataTable DT_Weapons, ref SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		DT_Aircraft = GetAllAircraft(sqliteConnection_0, IncludeDeprecated);
		DT_Ships = GetAllShips(sqliteConnection_0, IncludeDeprecated);
		DT_Subs = GetAllSubmarines(sqliteConnection_0, IncludeDeprecated);
		DT_Facilities = GetAllFacilities(sqliteConnection_0, IncludeDeprecated);
		DT_GroundUnits = GetAllGroundUnits(sqliteConnection_0, IncludeDeprecated);
		DT_Weapons = GetAllWeapons(sqliteConnection_0);
		try
		{
			DT_Satellites = GetAllSatellites(sqliteConnection_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200066", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CheckObjectIsDeprecated(string theTableName, int theDBID, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		bool result = default(bool);
		try
		{
			if (CheckColumnExists_SQLite(theTableName, "Deprecated", sqliteConnection_0))
			{
				string text = "Select Deprecated from " + theTableName + " WHERE ID=" + Conversions.ToString(theDBID);
				string text2 = sQLiteHelper.ExecuteScalar(text);
				int num;
				if (Operators.CompareString(text2, "0", false) == 0)
				{
					num = 0;
				}
				else
				{
					if (Operators.CompareString(text2, "False", false) != 0)
					{
						result = true;
						return result;
					}
					num = 0;
				}
				result = (byte)num != 0;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool CheckColumnExists_SQLite(string tableName, string columnName, SQLiteConnection connection)
	{
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = StringBuilderCache.Allocate();
		}
		else
		{
			stringBuilder_0.Clear();
		}
		stringBuilder_0.Append(connection.ConnectionString).Append("_").Append(tableName)
			.Append("_")
			.Append(columnName);
		if (concurrentDictionary_0.TryGetValue(stringBuilder_0.ToString(), out var value))
		{
			return value;
		}
		value = false;
		if (connection.State != ConnectionState.Open)
		{
			connection.Open();
		}
		SQLiteDataReader sQLiteDataReader = new SQLiteCommand("PRAGMA table_info('" + tableName + "')", connection).ExecuteReader();
		while (sQLiteDataReader.Read())
		{
			object objectValue = RuntimeHelpers.GetObjectValue(sQLiteDataReader.GetValue(1));
			if (columnName.Equals(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				sQLiteDataReader.Close();
				value = true;
				break;
			}
		}
		sQLiteDataReader.Close();
		concurrentDictionary_0.TryAdd(stringBuilder_0.ToString(), value);
		return value;
	}

	public static DataTable GetAllAircraft(SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable result = default(DataTable);
		try
		{
			string text = "Select DataAircraft.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Type, PhysicalSizeCode as Size, RunwayLengthCode as RunwaySizeNeeded";
			if (CheckColumnExists_SQLite("DataAircraft", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated";
			}
			int featureID;
			if (IncludeDeprecated)
			{
				text += " From DataAircraft, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataAircraft.OperatorCountry And EOS.ID = DataAircraft.OperatorService And Type > 1001 ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
				featureID = 0;
			}
			else
			{
				text += " From DataAircraft, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataAircraft.OperatorCountry And EOS.ID = DataAircraft.OperatorService And Type > 1001 AND DataAircraft.OperatorCountry <> 9999 ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
				featureID = 0;
			}
			if (!CheckFeatureCompatibility(featureID, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			DBOps.DBHasLegacyRunwayLengthEnum = sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumAircraftRunwayLength");
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static DataTable GetAllShips(SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable result = default(DataTable);
		try
		{
			string text = "Select DataShip.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Length, PhysicalSizeCode, Type ";
			if (CheckColumnExists_SQLite("DataShip", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated";
			}
			int featureID;
			if (IncludeDeprecated)
			{
				text += " From DataShip, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataShip.OperatorCountry And EOS.ID = DataShip.OperatorService And Type > 1001 Order By Name, EOC.Description, EOS.Description, YearCommissioned";
				featureID = 0;
			}
			else
			{
				text += " From DataShip, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataShip.OperatorCountry And EOS.ID = DataShip.OperatorService And Type > 1001 AND DataShip.OperatorCountry <> 9999 Order By Name, EOC.Description, EOS.Description, YearCommissioned";
				featureID = 0;
			}
			if (!CheckFeatureCompatibility(featureID, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(theHelper, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static DataTable GetAllSubmarines(SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string text = "Select DataSubmarine.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Length, PhysicalSizeCode, Type ";
		if (CheckColumnExists_SQLite("DataSubmarines", "Deprecated", sqliteConnection_0))
		{
			text += ", Deprecated";
		}
		text = ((!IncludeDeprecated) ? (text + " From DataSubmarine, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataSubmarine.OperatorCountry And EOS.ID = DataSubmarine.OperatorService AND DataSubmarine.OperatorCountry <> 9999 And Type > 1001 Order By Name, EOC.Description, EOS.Description, YearCommissioned") : (text + " From DataSubmarine, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataSubmarine.OperatorCountry And EOS.ID = DataSubmarine.OperatorService And Type > 1001 Order By Name, EOC.Description, EOS.Description, YearCommissioned"));
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			text = text.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(theHelper, text);
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllFacilities(SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataFacility.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END");
		if (!IncludeDeprecated)
		{
			GameGeneral.ThreadStaticSB.Append(" as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category from DataFacility, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataFacility.OperatorCountry and EOS.ID = DataFacility.OperatorService AND DataFacility.OperatorCountry <> 9999 ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned");
			if (CheckColumnExists_SQLite("DataFacility", "Deprecated", sqliteConnection_0))
			{
				GameGeneral.ThreadStaticSB.Append(" AND Deprecated=0 ");
			}
		}
		else
		{
			GameGeneral.ThreadStaticSB.Append(" as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category from DataFacility, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataFacility.OperatorCountry and EOS.ID = DataFacility.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned");
		}
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			GameGeneral.ThreadStaticSB.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(theHelper, GameGeneral.ThreadStaticSB.ToString());
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllGroundUnits(SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			return new DataTable();
		}
		string text = "SELECT DataGroundUnit.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END";
		int featureID;
		if (IncludeDeprecated)
		{
			text += " as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category, Length from DataGroundUnit, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataGroundUnit.OperatorCountry and EOS.ID = DataGroundUnit.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			featureID = 0;
		}
		else
		{
			text += " as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category, Length from DataGroundUnit, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataGroundUnit.OperatorCountry and EOS.ID = DataGroundUnit.OperatorService AND DataGroundUnit.OperatorCountry <> 9999 ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			featureID = 0;
		}
		if (!CheckFeatureCompatibility(featureID, sqliteConnection_0))
		{
			text = text.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(sQLiteHelper, text);
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllSatellites(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable result = default(DataTable);
		try
		{
			string text = "SELECT DataSatellite.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, EnumSatelliteType.Description as TypeString, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Type ";
			if (CheckColumnExists_SQLite("DataSatellite", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated ";
			}
			text += " from DataSatellite, EnumSatelliteType, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EnumSatelliteType.ID = DataSatellite.Type and EOC.ID = DataSatellite.OperatorCountry and EOS.ID = DataSatellite.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			if (!CheckFeatureCompatibility(0, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(theHelper, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static DataTable GetAllWeapons(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string text = "SELECT ID, Name, Name ||  CASE WHEN Comments = '-' THEN '' ELSE ' -- ' || Comments END as LongName, Type, Hypothetical ";
		if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
		{
			text += ", Deprecated ";
		}
		text += "from DataWeapon where Type > 1001";
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			text = text.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(theHelper, text);
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllCommDevices(ref SQLiteConnection sqliteConnection_0, Scenario CurrentScenario)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		if (GameGeneral.Beta_PlatformComms && CurrentScenario != null && CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
		{
			bool flag = Convert.ToInt32(DBCache.GetScalar(theHelper, "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EnumCommQuality'")) > 0;
			bool num = Convert.ToInt32(DBCache.GetScalar(theHelper, "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EnumCommLatency'")) > 0;
			string text = "dc.ID, dc.Name || ' (' || dc.Comments || ')' AS Name, (SELECT description FROM enumcommtype WHERE id = dc.type) AS Type";
			string text2 = "";
			if (flag)
			{
				text += ", eq.ID AS QualityID, eq.Description AS QualityDescription, eq.Capability AS QualityCapability, eq.Example AS QualityExample";
				text2 += " LEFT JOIN EnumCommQuality eq ON eq.ID = dc.QualityGrade";
			}
			else
			{
				text += ", NULL AS QualityID, NULL AS QualityDescription, NULL AS QualityCapability, NULL AS QualityExample";
			}
			if (!num)
			{
				text += ", NULL AS LatencyID, NULL AS LatencyDescription, NULL AS LatencyCapability, NULL AS LatencyExample";
			}
			else
			{
				text += ", el.ID AS LatencyID, el.Description AS LatencyDescription, el.Capability AS LatencyCapability, el.Example AS LatencyExample";
				text2 += " LEFT JOIN EnumCommLatency el ON el.ID = dc.QualityGrade";
			}
			string_0 = "SELECT " + text + " FROM DataComm dc" + text2;
		}
		else
		{
			string_0 = "SELECT ID, Name || ' (' || Comments || ')' AS Name, (SELECT description FROM enumcommtype WHERE id = type) AS Type FROM DataComm";
		}
		DataTable dataTable = DBCache.GetDatatable(theHelper, string_0).Copy();
		if (GameGeneral.Beta_PlatformComms && CurrentScenario != null && CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
		{
			if (!dataTable.Columns.Contains("Bandwidth"))
			{
				dataTable.Columns.Add("Bandwidth", typeof(string));
			}
			if (!dataTable.Columns.Contains("Latency"))
			{
				dataTable.Columns.Add("Latency", typeof(string));
			}
			foreach (DataRow row in dataTable.Rows)
			{
				int theID = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["QualityID"]))) ? Convert.ToInt32(RuntimeHelpers.GetObjectValue(row["QualityID"])) : 0);
				int theID2 = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["LatencyID"]))) ? Convert.ToInt32(RuntimeHelpers.GetObjectValue(row["LatencyID"])) : 0);
				row["Bandwidth"] = CommDevice.QualityGradeDetail.GetDescriptionASSlide(theID);
				row["Latency"] = CommDevice.LatencyGradeDetail.GetDescriptionASSlide(theID2);
			}
		}
		string[] array = new string[8] { "QualityID", "QualityDescription", "QualityCapability", "QualityExample", "LatencyID", "LatencyDescription", "LatencyCapability", "LatencyExample" };
		foreach (string name in array)
		{
			if (dataTable.Columns.Contains(name))
			{
				dataTable.Columns.Remove(name);
			}
		}
		return dataTable;
	}

	public static DataTable GetOrbitsForThisSatellite(int SatID, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = "Select * from DataSatelliteOrbits where ID=" + Conversions.ToString(SatID) + " AND Operational <>0";
		return DBCache.GetDatatable(theHelper, theQuery);
	}

	public static string GetSatelliteName(int SatID, int OrbitIndex, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = "Select MissionName from DataSatelliteOrbits where ID=" + Conversions.ToString(SatID) + " and ComponentNumber=" + Conversions.ToString(OrbitIndex);
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static DataTable GetAllCountries(ref SQLiteConnection sqliteConnection_0, bool IncludeDeprecated = false)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = ((!IncludeDeprecated) ? "SELECT ID, Description from EnumOperatorCountry WHERE ID <> 9999 ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC " : "SELECT ID, Description from EnumOperatorCountry ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ");
		return DBCache.GetDatatable(theHelper, theQuery);
	}

	public static DataTable GetAllAirFacilities(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = "Select * from DataAircraftFacility";
		return DBCache.GetDatatable(theHelper, theQuery);
	}

	public static DataTable GetAllDockFacilities(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = "Select * from DataDockingFacility";
		return DBCache.GetDatatable(theHelper, theQuery);
	}

	public static int EW_GetNumberOfBasicVariants(List<int> ListofMatches, GlobalVariables.ActiveUnitType theTargetType, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		switch (theTargetType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			break;
		}
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string theQuery = "SELECT COUNT(DISTINCT Name) FROM " + text + " where ID in (" + string.Join(",", ListofMatches.ToArray()) + ")";
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery));
	}

	public static List<int> EW_GetAllUnitsMatchingTheseEmissions(List<int> list_0, GlobalVariables.ActiveUnitType theUnitType, Scenario theScen, SQLiteConnection sqliteConnection_0)
	{
		List<int> result;
		try
		{
			List<int> list = new List<int>();
			if (list_0.Count != 0)
			{
				list_0 = list_0.OrderBy([SpecialName] (int theInt) => theInt).ToList();
				SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
				string text = "EmitterIDs_" + theUnitType.ToString() + "_" + string.Join("_", list_0);
				object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(theHelper, text));
				if (objectValue == null)
				{
					new List<int>();
					DataTable dataTable = null;
					int count = list_0.Count;
					switch (theUnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						dataTable = GetAllAircraft(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						dataTable = GetAllShips(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						dataTable = GetAllSubmarines(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						dataTable = GetAllFacilities(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						dataTable = GetAllWeapons(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						dataTable = GetAllSatellites(sqliteConnection_0);
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						dataTable = GetAllGroundUnits(sqliteConnection_0);
						break;
					}
					foreach (DataRow row in dataTable.Rows)
					{
						int num = Conversions.ToInteger(row["ID"]);
						List<int> second = EW_GetAllPossibleEmissionsForThisUnit(theUnitType, num, theScen.DBConnection);
						if (list_0.Intersect(second).Count() == count)
						{
							list.Add(num);
						}
					}
					DBCache.SetCustomObject(theHelper, text, list);
					result = list;
				}
				else
				{
					result = (List<int>)objectValue;
				}
			}
			else
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101082", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<int>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Dictionary<int, List<int>> EW_GetAllPossibleEmissionsForUnits(GlobalVariables.ActiveUnitType UnitType, IReadOnlyList<int> ireadOnlyList_0, SQLiteConnection Connection)
	{
		string text = "";
		string value = "";
		switch (UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftSensors";
			value = "DataAircraftMounts";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipSensors";
			value = "DataShipMounts";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineSensors";
			value = "DataSubmarineMounts";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilitySensors";
			value = "DataFacilityMounts";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeaponSensors";
			value = "";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatelliteSensors";
			value = "DataSatelliteMounts";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
		case GlobalVariables.ActiveUnitType.Personnel:
			text = "DataGroundUnitSensors";
			value = "DataGroundUnitMounts";
			break;
		}
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		List<int> list = new List<int>();
		foreach (int item in ireadOnlyList_0)
		{
			string key = text + "_" + Conversions.ToString(item);
			HashSet<int> value2 = null;
			if (!CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryGetValue(key, out value2))
			{
				list.Add(item);
				dictionary[item] = new List<int>();
			}
			else
			{
				dictionary[item] = new List<int>(value2);
			}
		}
		Dictionary<int, List<int>> result;
		if (list.Count != 0)
		{
			try
			{
				SQLiteHelper theHelper = new SQLiteHelper(Connection);
				int num = 0;
				while (num < list.Count)
				{
					int num2 = Math.Min(999, list.Count - num);
					List<int> range = list.GetRange(num, num2);
					num += num2;
					string value3 = string.Join(",", range);
					Dictionary<int, HashSet<int>> dictionary2 = new Dictionary<int, HashSet<int>>();
					foreach (int item2 in range)
					{
						dictionary2[item2] = new HashSet<int>();
					}
					GameGeneral.InitThreadStaticSB();
					GameGeneral.ThreadStaticSB.Append("SELECT t.ID as UnitID, s.ID as SensorID, s.Type as SensorType, s.MasqueradeAs FROM DataSensor s, ").Append(text).Append(" t WHERE s.ID = t.ComponentID AND t.ID IN (")
						.Append(value3)
						.Append(")");
					if (!string.IsNullOrEmpty(value))
					{
						GameGeneral.ThreadStaticSB.Append(" UNION ALL SELECT m.ID, s.ID, s.Type, s.MasqueradeAs FROM DataSensor s, DataMountSensors dms, ").Append(value).Append(" m WHERE s.ID = dms.ComponentID AND dms.ID = m.ComponentID AND m.ID IN (")
							.Append(value3)
							.Append(")");
					}
					GameGeneral.ThreadStaticSB.Append(" UNION ALL SELECT t.ID, s.ID, s.Type, s.MasqueradeAs FROM DataSensor s, DataSensorSensorGroups g, ").Append(text).Append(" t WHERE t.ID IN (")
						.Append(value3)
						.Append(") AND g.ID = t.ComponentID AND s.ID = g.ComponentID");
					DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, GameGeneral.ThreadStaticSB.ToString());
					GameGeneral.ThreadStaticSB.Clear();
					foreach (DtrRow row in datatableTyped.Rows)
					{
						int key2 = Conversions.ToInteger(row["UnitID"]);
						if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row["SensorType"])))
						{
							object objectValue = RuntimeHelpers.GetObjectValue(row["MasqueradeAs"]);
							if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)) && Conversions.ToInteger(objectValue) != 1001)
							{
								dictionary2[key2].Add(Conversions.ToInteger(objectValue));
							}
							else
							{
								dictionary2[key2].Add(Conversions.ToInteger(row["SensorID"]));
							}
						}
					}
					foreach (KeyValuePair<int, HashSet<int>> item3 in dictionary2)
					{
						string key3 = text + "_" + Conversions.ToString(item3.Key);
						CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryAdd(key3, item3.Value);
						dictionary[item3.Key] = new List<int>(item3.Value);
					}
				}
				result = dictionary;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200067", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = dictionary;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = dictionary;
		}
		return result;
	}

	public static List<int> EW_GetAllPossibleEmissionsForThisUnit(GlobalVariables.ActiveUnitType UnitType, int UnitDBID, SQLiteConnection Connection)
	{
		string text = "";
		string value = "";
		HashSet<int> value2 = new HashSet<int>();
		SQLiteHelper sQLiteHelper = default(SQLiteHelper);
		List<int> result;
		try
		{
			switch (UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				text = "DataAircraftSensors";
				value = "DataAircraftMounts";
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				text = "DataShipSensors";
				value = "DataShipMounts";
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				text = "DataSubmarineSensors";
				value = "DataSubmarineMounts";
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				text = "DataFacilitySensors";
				value = "DataFacilityMounts";
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				text = "DataWeaponSensors";
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				text = "DataSatelliteSensors";
				value = "DataSatelliteMounts";
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
				text = "DataGroundUnitSensors";
				value = "DataGroundUnitMounts";
				break;
			}
			string key = text + "_" + Conversions.ToString(UnitDBID);
			if (!CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryGetValue(key, out value2))
			{
				if (value2 == null)
				{
					value2 = new HashSet<int>();
				}
				sQLiteHelper = new SQLiteHelper(Connection);
				GameGeneral.InitThreadStaticSB();
				GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, ").Append(text).Append(" as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ")
					.Append(UnitDBID);
				DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString());
				foreach (DtrRow row in datatableTyped.Rows)
				{
					if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row["SensorType"])))
					{
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["MasqueradeAs"])) && Conversions.ToInteger(row["MasqueradeAs"]) != 1001)
						{
							value2.Add(Conversions.ToInteger(row["MasqueradeAs"]));
						}
						else
						{
							value2.Add(Conversions.ToInteger(row["SensorID"]));
						}
					}
				}
				GameGeneral.ThreadStaticSB.Clear();
				DataTableTyped datatableTyped2;
				if (!string.IsNullOrEmpty(value))
				{
					GameGeneral.ThreadStaticSB.Append("SELECT DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, DataMountSensors, ").Append(value).Append(" where DataSensor.ID = DataMountSensors.ComponentID and DataMountSensors.ID = ")
						.Append(value)
						.Append(".ComponentID and ")
						.Append(value)
						.Append(".ID = ")
						.Append(UnitDBID);
					datatableTyped2 = DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString());
					foreach (DtrRow row2 in datatableTyped2.Rows)
					{
						if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row2["SensorType"])))
						{
							if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["MasqueradeAs"])) && Conversions.ToInteger(row2["MasqueradeAs"]) != 1001)
							{
								value2.Add(Conversions.ToInteger(row2["MasqueradeAs"]));
							}
							else
							{
								value2.Add(Conversions.ToInteger(row2["SensorID"]));
							}
						}
					}
				}
				GameGeneral.ThreadStaticSB.Clear();
				GameGeneral.ThreadStaticSB.Append("SELECT DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, DataSensorSensorGroups, ").Append(text).Append(" where ")
					.Append(text)
					.Append(".ID = ")
					.Append(UnitDBID)
					.Append(" And DataSensorSensorGroups.ID = ")
					.Append(text)
					.Append(".ComponentID And DataSensor.ID = DataSensorSensorGroups.ComponentID");
				datatableTyped2 = DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString());
				foreach (DtrRow row3 in datatableTyped2.Rows)
				{
					if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row3["SensorType"])))
					{
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["MasqueradeAs"])) && Conversions.ToInteger(row3["MasqueradeAs"]) != 1001)
						{
							value2.Add(Conversions.ToInteger(row3["MasqueradeAs"]));
						}
						else
						{
							value2.Add(Conversions.ToInteger(row3["SensorID"]));
						}
					}
				}
				CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryAdd(key, value2);
				result = new List<int>(value2);
			}
			else
			{
				result = new List<int>(value2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (sQLiteHelper != null && (sQLiteHelper.theConnection == null || sQLiteHelper.theConnection.State != ConnectionState.Open))
			{
				throw;
			}
			ex2?.Data.Add("Error at 200067", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = value2.ToList();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int GetActiveUnitIDByName(string theName, GlobalVariables.ActiveUnitType theType, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "";
		switch (theType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			theQuery = "SELECT ID FROM DataAircraft where Name = '" + theName + "'";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			theQuery = "SELECT ID FROM DataShip where Name = '" + theName + "'";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			theQuery = "SELECT ID FROM DataSubmarine where Name = '" + theName + "'";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			theQuery = "SELECT ID FROM DataFacility where Name = '" + theName + "'";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			theQuery = "SELECT ID FROM DataWeapon where Name = '" + theName + "'";
			break;
		}
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery));
	}

	public static string GetActiveUnitName(GlobalVariables.ActiveUnitType theType, int theDBID, SQLiteConnection theConn)
	{
		string result = "(error)";
		string text;
		switch (theType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		default:
			return result;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			break;
		}
		string theQuery = "Select Name from " + text + " where ID=" + Conversions.ToString(theDBID);
		DataTable datatable = DBCache.GetDatatable(new SQLiteHelper(theConn), theQuery);
		if (datatable.Rows.Count > 0)
		{
			result = datatable.Rows[0]["Name"].ToString();
		}
		return result;
	}

	public static List<float> GetEngineDetails(int EngineID, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		List<float> list = new List<float>();
		try
		{
			string theQuery = "Select NumberOfEngines, ThrustPerEngineMilitary, ThrustPerEngineAfterburner, SFCMilitary, SFCAfterburner from DataPropulsion where ID=" + Conversions.ToString(EngineID);
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			if (datatable.Rows.Count == 0)
			{
				return list;
			}
			foreach (DataRow row in datatable.Rows)
			{
				list.Add(Conversions.ToSingle(row["NumberOfEngines"]));
				list.Add(Conversions.ToSingle(row["ThrustPerEngineMilitary"]));
				list.Add(Conversions.ToSingle(row["ThrustPerEngineAfterburner"]));
				list.Add(Conversions.ToSingle(row["SFCMilitary"]));
				list.Add(Conversions.ToSingle(row["SFCAfterburner"]));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200068", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public static List<float> GetTorpedoKinematicRange(int WeaponID, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		List<float> list = new List<float>();
		try
		{
			string theQuery = "Select TorpedoSpeedCruise, TorpedoRangeCruise, TorpedoSpeedFull, TorpedoRangeFull from DataWeapon where ID=" + Conversions.ToString(WeaponID);
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			if (datatable.Rows.Count == 0)
			{
				return list;
			}
			foreach (DataRow row in datatable.Rows)
			{
				list.Add(Conversions.ToSingle(row["TorpedoSpeedCruise"]));
				list.Add(Conversions.ToSingle(row["TorpedoRangeCruise"]));
				list.Add(Conversions.ToSingle(row["TorpedoSpeedFull"]));
				list.Add(Conversions.ToSingle(row["TorpedoRangeFull"]));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200069", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public static void smethod_0(GlobalVariables.ActiveUnitType UnitType, int UnitDBID, SQLiteConnection sqliteConnection_0, ref int OODA_Detect, ref int OODA_Targeting, ref int OODA_Evasive)
	{
		if (UnitType == GlobalVariables.ActiveUnitType.Weapon)
		{
			return;
		}
		string text = "";
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		switch (UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			break;
		}
		try
		{
			string_0 = "SELECT OODADetectionCycle, OODATargetingCycle, OODAEvasiveCycle FROM " + text + " where ID = " + Conversions.ToString(UnitDBID);
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			foreach (DataRow row in datatable.Rows)
			{
				OODA_Detect = Conversions.ToInteger(row["OODADetectionCycle"]);
				OODA_Targeting = Conversions.ToInteger(row["OODATargetingCycle"]);
				OODA_Evasive = Conversions.ToInteger(row["OODAEvasiveCycle"]);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			string_0 = "SELECT  OODATargetingCycle, OODAEvasiveCycle FROM " + text + " where ID = " + Conversions.ToString(UnitDBID);
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			foreach (DataRow row2 in datatable.Rows)
			{
				OODA_Detect = 15;
				OODA_Targeting = Conversions.ToInteger(row2["OODATargetingCycle"]);
				OODA_Evasive = Conversions.ToInteger(row2["OODAEvasiveCycle"]);
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<string> GetUnitFlagDescriptions(GlobalVariables.ActiveUnitType UnitType, int UnitDBID, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string text2 = "";
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		List<string> list = new List<string>();
		int num;
		switch (UnitType)
		{
		default:
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftCodes";
			text2 = "EnumAircraftCode";
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipCodes";
			text2 = "EnumShipCode";
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineCodes";
			text2 = "EnumSubmarineCode";
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Facility:
		case GlobalVariables.ActiveUnitType.Aimpoint:
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeaponCodes";
			text2 = "EnumWeaponCode";
			num = 6;
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatelliteCodes";
			text2 = "EnumSatelliteCode";
			num = 6;
			break;
		}
		string[] array = new string[num];
		array[0] = "SELECT EC.* from ";
		array[1] = text2;
		array[2] = " as EC, ";
		array[3] = text;
		array[4] = " as DC where EC.ID = DC.CodeID and DC.ID = ";
		array[5] = Conversions.ToString(UnitDBID);
		string_0 = string.Concat(array);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			return list;
		}
		foreach (DataRow row in datatable.Rows)
		{
			list.Add(Conversions.ToString(row["Description"]));
		}
		return list;
	}

	internal static string Description(this CommDevice.CommLinkType theType, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string theQuery = "Select Description from EnumCommType where ID=" + Conversions.ToString((int)theType);
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static string Description(this XSection._SignatureType theType, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string theQuery = "Select Description from EnumSignatureType where ID=" + Conversions.ToString((int)theType);
		return DBCache.GetScalar(theHelper, theQuery);
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) GetAircraftCockpitOODAValues(ref Scenario theScen, int CockpitGenID, bool CheckIfTableExists)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		(string, string, short, short, short) result4;
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumAircraftCockpitGen"))
		{
			string_0 = "Select * from EnumAircraftCockpitGen where ID = " + Conversions.ToString(CockpitGenID);
			DataRow dataRow = DBCache.GetDatatable(sQLiteHelper, string_0).Rows[0];
			string item;
			if (dataRow["Description"] is string)
			{
				item = Conversions.ToString(dataRow["Description"]);
			}
			else
			{
				item = "";
				_ = Debugger.IsAttached;
			}
			string item2;
			if (!(dataRow["Example"] is string))
			{
				item2 = "";
				_ = Debugger.IsAttached;
			}
			else
			{
				item2 = Conversions.ToString(dataRow["Example"]);
			}
			if (short.TryParse(dataRow["OODADetectionCycle"].ToString(), out var result))
			{
				result = Conversions.ToShort(dataRow["OODADetectionCycle"]);
			}
			else
			{
				result = 0;
				_ = Debugger.IsAttached;
			}
			if (short.TryParse(dataRow["OODATargetingCycle"].ToString(), out var result2))
			{
				result2 = Conversions.ToShort(dataRow["OODATargetingCycle"]);
			}
			else
			{
				result2 = 0;
				_ = Debugger.IsAttached;
			}
			if (short.TryParse(dataRow["OODAEvasiveCycle"].ToString(), out var result3))
			{
				result3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"]);
			}
			else
			{
				result3 = 0;
				_ = Debugger.IsAttached;
			}
			result4 = (item, item2, result, result2, result3);
		}
		else
		{
			result4 = (string.Empty, string.Empty, 0, 0, 0);
		}
		return result4;
	}

	public static DataRow GetUnitData_RAW(ref Scenario theScen, GlobalVariables.ActiveUnitType type, int DBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from " + type switch
		{
			GlobalVariables.ActiveUnitType.Aircraft => "DataAircraft", 
			GlobalVariables.ActiveUnitType.Ship => "DataShip", 
			GlobalVariables.ActiveUnitType.Submarine => "DataSubmarine", 
			GlobalVariables.ActiveUnitType.Facility => "DataFacility", 
			GlobalVariables.ActiveUnitType.Weapon => "DataWeapon", 
			GlobalVariables.ActiveUnitType.Satellite => "DataSatellite", 
			GlobalVariables.ActiveUnitType.Vehicle => "DataGroundUnit", 
			_ => throw new NotImplementedException(), 
		} + " where ID = " + Conversions.ToString(DBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No " + type.ToString() + " with ID: " + Conversions.ToString(DBID) + " was found in the current database (GetUnitData_RAW)!");
		}
		return datatable.Rows[0];
	}

	public static void GetAircraft(ref Scenario theScen, ref Aircraft theAircraft, int AircraftDBID, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataAircraft where ID = " + Conversions.ToString(AircraftDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No aircraft with ID: " + Conversions.ToString(AircraftDBID) + " was found in the current database!");
		}
		DataRow dataRow = datatable.Rows[0];
		if (datatable.Columns.Contains("CockpitGen") && Conversions.ToInteger(dataRow["CockpitGen"]) > 0)
		{
			theAircraft.CockpitGen = Conversions.ToInteger(dataRow["CockpitGen"]);
			(string, string, short, short, short) aircraftCockpitOODAValues = GetAircraftCockpitOODAValues(ref theScen, theAircraft.CockpitGen, CheckIfTableExists: false);
			theAircraft.OODA_Detection = aircraftCockpitOODAValues.Item3;
			theAircraft.OODA_Targeting = aircraftCockpitOODAValues.Item4;
			theAircraft.OODA_Evasion = aircraftCockpitOODAValues.Item5;
		}
		else
		{
			if (!datatable.Columns.Contains("OODADetectionCycle"))
			{
				datatable.Columns.Add("OODADetectionCycle", typeof(string));
				dataRow["OODADetectionCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODATargetingCycle"))
			{
				datatable.Columns.Add("OODATargetingCycle", typeof(string));
				dataRow["OODATargetingCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODAEvasiveCycle"))
			{
				datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
				dataRow["OODAEvasiveCycle"] = 0;
			}
		}
		theAircraft.Category = (Aircraft._AircraftCategory)Conversions.ToShort(dataRow["Category"]);
		theAircraft.Type = (Aircraft._AircraftType)Conversions.ToInteger(dataRow["Type"]);
		theAircraft.DBID = AircraftDBID;
		theAircraft.UnitClass = Strings.Trim(Conversions.ToString(dataRow["Name"]));
		theAircraft.Kinematics.set_ClimbRate_Nominal(LimitByTrueAirspeed: true, Conversions.ToSingle(dataRow["ClimbRate"].ToString()));
		theAircraft.Agility_Nominal = Conversions.ToSingle(dataRow["Agility"].ToString());
		theAircraft.Length = Conversions.ToSingle(dataRow["Length"].ToString());
		theAircraft.EmptyWeight = Conversions.ToInteger(dataRow["WeightEmpty"].ToString());
		theAircraft.MaxWeight = Conversions.ToInteger(dataRow["WeightMax"].ToString());
		theAircraft.MaxPayloadWeight = Conversions.ToInteger(dataRow["WeightPayload"].ToString());
		theAircraft.Span = Conversions.ToSingle(dataRow["Span"].ToString());
		theAircraft.Height = Conversions.ToSingle(dataRow["Height"].ToString());
		theAircraft.Crew = Conversions.ToInteger(dataRow["Crew"].ToString());
		theAircraft.TotalEndurance = Conversions.ToInteger(dataRow["TotalEndurance"].ToString());
		theAircraft.Category = (Aircraft._AircraftCategory)Conversions.ToShort(dataRow["Category"]);
		theAircraft.RunwayLengthNeeded = GetRunwayLength(Conversions.ToInteger(dataRow["RunwayLengthCode"]));
		int num = Conversions.ToInteger(dataRow["PhysicalSizeCode"]);
		theAircraft.Size = GetAircraftPhysicalSize(num);
		if (theAircraft.Size == GlobalVariables.AircraftSizeClass.None && num != 1001 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (datatable.Columns.Contains("DamagePoints") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["DamagePoints"])) && Conversions.ToInteger(dataRow["DamagePoints"]) != 0)
		{
			theAircraft.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			theAircraft.set_DamagePts(ScenEditAction: true, (Weapon)null, (float)theAircraft.InitialDP);
		}
		else if (!theAircraft.IsLighterThanAir)
		{
			switch (theAircraft.Size)
			{
			case GlobalVariables.AircraftSizeClass.Small:
				theAircraft.InitialDP = 3;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
				theAircraft.InitialDP = 1;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
				theAircraft.InitialDP = 2;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
			case GlobalVariables.AircraftSizeClass.UAS_Class2:
				theAircraft.InitialDP = 3;
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case GlobalVariables.AircraftSizeClass.VLarge:
				theAircraft.InitialDP = 20;
				break;
			case GlobalVariables.AircraftSizeClass.Large:
				theAircraft.InitialDP = 10;
				break;
			case GlobalVariables.AircraftSizeClass.Medium:
				theAircraft.InitialDP = 5;
				break;
			}
			theAircraft.set_DamagePts(ScenEditAction: true, (Weapon)null, (float)theAircraft.InitialDP);
		}
		else
		{
			theAircraft.InitialDP = Aircraft.smethod_2((int)Math.Round(theAircraft.Length));
			theAircraft.set_DamagePts(ScenEditAction: true, (Weapon)null, (float)theAircraft.InitialDP);
		}
		if (datatable.Columns.Contains("Visibility"))
		{
			theScen.FeatureCompatibility.CockpitVisibility = true;
			try
			{
				string[] array = (dataRow["Visibility"].ToString().Contains(",") ? dataRow["Visibility"].ToString().Split(Conversions.ToCharArrayRankOne(",")) : dataRow["Visibility"].ToString().Split(Conversions.ToCharArrayRankOne(".")));
				switch (array[0])
				{
				case "B":
					theAircraft.VisibilityForward = Aircraft.CockpitVisibility.Average;
					break;
				case "C":
					theAircraft.VisibilityForward = Aircraft.CockpitVisibility.Poor;
					break;
				case "A":
					theAircraft.VisibilityForward = Aircraft.CockpitVisibility.Excellent;
					break;
				}
				switch (array[1])
				{
				case "B":
					theAircraft.VisibilitySideways = Aircraft.CockpitVisibility.Average;
					break;
				case "C":
					theAircraft.VisibilitySideways = Aircraft.CockpitVisibility.Poor;
					break;
				case "A":
					theAircraft.VisibilitySideways = Aircraft.CockpitVisibility.Excellent;
					break;
				}
				switch (array[2])
				{
				case "A":
					theAircraft.VisibilityAft = Aircraft.CockpitVisibility.Excellent;
					break;
				case "C":
					theAircraft.VisibilityAft = Aircraft.CockpitVisibility.Poor;
					break;
				case "B":
					theAircraft.VisibilityAft = Aircraft.CockpitVisibility.Average;
					break;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (datatable.Columns.Contains("FuelOffloadRate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelOffloadRate"])))
		{
			theAircraft.FuelOffLoadRate = Conversions.ToSingle(dataRow["FuelOffloadRate"]);
		}
		if (datatable.Columns.Contains("FuelOnloadRate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelOnloadRate"])))
		{
			theAircraft.FuelOnLoadRate = Conversions.ToSingle(dataRow["FuelOnloadRate"]);
		}
		if (datatable.Columns.Contains("AircraftEngineArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftEngineArmor"])))
		{
			theAircraft.Armor_Powerplant = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftEngineArmor"]);
		}
		else
		{
			theAircraft.Armor_Powerplant = GlobalVariables.ArmorRating.None;
		}
		if (datatable.Columns.Contains("AircraftCockpitArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftCockpitArmor"])))
		{
			theAircraft.Armor_Cockpit = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftCockpitArmor"]);
		}
		else
		{
			theAircraft.Armor_Cockpit = GlobalVariables.ArmorRating.None;
		}
		if (datatable.Columns.Contains("AircraftFuselageArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftFuselageArmor"])))
		{
			theAircraft.Armor_Fuselage = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftFuselageArmor"]);
		}
		else
		{
			theAircraft.Armor_Fuselage = GlobalVariables.ArmorRating.None;
		}
		theAircraft.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
		theAircraft.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
		theAircraft.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
		theAircraft.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
		try
		{
			theAircraft.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		Aircraft theAircraft2 = theAircraft;
		GetAircraftFlags(ref theAircraft2, AircraftDBID);
		if (LoadComponents)
		{
			PopulateSensors(theAircraft, AircraftDBID);
			PopulateComms(theAircraft, AircraftDBID);
			ActiveUnit theUnit = theAircraft;
			PopulateMounts(ref theScen, ref theUnit, AircraftDBID);
			PopulatePropulsion(theAircraft, AircraftDBID);
			PopulateFuel(theAircraft, AircraftDBID);
			if (theAircraft.isUAVSizeClass1AndHasDBProvidedEndurance())
			{
				theAircraft.forceMaxInternalFuelCapacity((float)(theAircraft.TotalEndurance * 60) * Aircraft.UAVSizeClass1FixedFuelConsumption);
			}
			PopulateEyeballSensorIfNeeded(theScen, theAircraft);
		}
		PopulateAircraftMissingCargoData(theAircraft);
		if (theAircraft.Crew == 0 && datatable.Columns.Contains("AutonomousControlLevel"))
		{
			try
			{
				theAircraft.AutonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(dataRow["AutonomousControlLevel"]);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				theAircraft.AutonomyLevel = ActiveUnit.DroneAutonomyLevel.SelfRecovering;
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void PopulateAircraftMissingCargoData(Aircraft theAircraft)
	{
		if (theAircraft.Cargo_Type != CargoType.NoCargo)
		{
			return;
		}
		if (!(theAircraft.Span < 6f) && theAircraft.Type != Aircraft._AircraftType.UAV && theAircraft.Type != Aircraft._AircraftType.UCAV)
		{
			theAircraft.Cargo_Type = CargoType.NoCargo;
			return;
		}
		theAircraft.Cargo_Type = GetCargoTypeCategory(theAircraft.Length, theAircraft.Span, theAircraft.Height);
		theAircraft.Cargo_Area = theAircraft.Length * theAircraft.Span;
		if (theAircraft.Cargo_Area == 0f)
		{
			theAircraft.Cargo_Type = CargoType.NoCargo;
			return;
		}
		theAircraft.Cargo_Mass = (float)theAircraft.EmptyWeight / 1000f;
		if (theAircraft.Cargo_Mass == 0f)
		{
			theAircraft.Cargo_Mass = (float)theAircraft.MaxWeight / 1000f;
		}
		if (theAircraft.Cargo_Mass == 0f)
		{
			switch (theAircraft.Size)
			{
			case GlobalVariables.AircraftSizeClass.Small:
				theAircraft.Cargo_Mass = 2f;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
				theAircraft.Cargo_Mass = 0.002f;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
				theAircraft.Cargo_Mass = 0.015f;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
				theAircraft.Cargo_Mass = 0.15f;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class2:
				theAircraft.Cargo_Mass = 0.6f;
				break;
			default:
				theAircraft.Cargo_Type = CargoType.NoCargo;
				theAircraft.Cargo_Area = 0f;
				return;
			case GlobalVariables.AircraftSizeClass.VLarge:
				theAircraft.Cargo_Mass = 64f;
				break;
			case GlobalVariables.AircraftSizeClass.Large:
				theAircraft.Cargo_Mass = 16f;
				break;
			case GlobalVariables.AircraftSizeClass.Medium:
				theAircraft.Cargo_Mass = 8f;
				break;
			}
		}
		theAircraft.Cargo_Crew = 0;
	}

	public static int GetAircraftType_Int(ref Scenario theScen, int AircraftDBID)
	{
		string_0 = "Select Type from DataAircraft where ID = " + Conversions.ToString(AircraftDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetAircraftName(int theDBID, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Name from DataAircraft where ID='" + Conversions.ToString(theDBID) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static string GetAircraftType_String(ref Scenario theScen, int AircraftDBID)
	{
		string_0 = "Select Description from EnumAircraftType where ID = (Select Type from DataAircraft Where ID = " + Conversions.ToString(AircraftDBID) + ")";
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static int GetShipType_Int(ref Scenario theScen, int ShipDBID)
	{
		string_0 = "Select Type from DataShip where ID = " + Conversions.ToString(ShipDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetShipType_String(ref Scenario theScen, int ShipDBID)
	{
		string_0 = "Select Description from EnumShipType where ID = (Select Type from DataShip Where ID = " + Conversions.ToString(ShipDBID) + ")";
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static int GetSubmarineType_Int(ref Scenario theScen, int SubDBID)
	{
		string_0 = "Select Type from DataSubmarine where ID = " + Conversions.ToString(SubDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetSubmarineType_String(ref Scenario theScen, int SatelliteDBID)
	{
		string_0 = "Select Description from EnumSubmarineType where ID = (Select Type from DataSubmarine Where ID = " + Conversions.ToString(SatelliteDBID) + ")";
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string GetFacilityName(int theDBID, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Name from DataFacility where ID='" + Conversions.ToString(theDBID) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static int GetFacilityCategory_Int(ref Scenario theScen, int FacilityDBID)
	{
		string_0 = "Select Category from DataFacility where ID = " + Conversions.ToString(FacilityDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static int GetFacilityType_Int(ref Scenario theScen, int FacilityDBID)
	{
		string_0 = "Select Type from DataFacility where ID = " + Conversions.ToString(FacilityDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static Facility.FacilityType GetFacilityType(float TypeID)
	{
		return (Facility.FacilityType)Math.Round(TypeID);
	}

	public static Facility.FacilityType GetFacilityType(ActiveUnit theUnit)
	{
		if (!GameGeneral.checkColumnExistence("DataFacility", "Type"))
		{
			return Facility.FacilityType.None;
		}
		return GetFacilityType(GetFacilityType_Int(ref theUnit.ParentScen, theUnit.DBID));
	}

	public static int GetSatelliteType_Int(ref Scenario theScen, int SatelliteDBID)
	{
		string_0 = "Select Type from DataSatellite where ID = " + Conversions.ToString(SatelliteDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetSatelliteType_String(ref Scenario theScen, int SatelliteDBID)
	{
		string_0 = "Select Description from EnumSatelliteType where ID = (Select Type from DataSatellite Where ID = " + Conversions.ToString(SatelliteDBID) + ")";
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static int GetWeaponType_Int(ref Scenario theScen, int int_0)
	{
		string_0 = "Select Type from DataWeapon where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetWeaponType_String(ref Scenario theScen, int int_0)
	{
		string_0 = "Select Description from EnumWeaponType where ID = (Select Type from DataWeapon Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string Get_WRA_WeaponTargetType_WeaponQty_String(ref Scenario theScen, int WeaponQty)
	{
		string_0 = "Select Description from EnumWeaponWRAWeaponQty where ID = " + Conversions.ToString(WeaponQty);
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string Get_WRA_WeaponTargetType_ShooterQty_String(ref Scenario theScen, int ShooterQty)
	{
		string_0 = "Select Description from EnumWeaponWRAShooterQty where ID = " + Conversions.ToString(ShooterQty);
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string Get_WRA_WeaponTargetType_SelfDefenceRange_String(ref Scenario theScen, int SelfDefenceRange)
	{
		string_0 = "Select Description from EnumWeaponWRASelfDefenceRange where ID = " + Conversions.ToString(SelfDefenceRange);
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string Get_Sensor_Generation_String(ref Scenario theScen, int SensorGenID)
	{
		string_0 = "Select Description from EnumSensorGeneration where ID = " + Conversions.ToString(SensorGenID);
		return DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0);
	}

	public static string Get_Sensor_Type_String(ref SQLiteConnection sqliteConnection_0, int SensorTypeID)
	{
		string theQuery = "Select Description from EnumSensorType where ID = " + Conversions.ToString(SensorTypeID);
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), theQuery);
	}

	public static string GetFacilityType_String(ref Scenario theScen, int FacilityDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string value = FacilityDBID.ToString();
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		stringBuilder.Clear();
		stringBuilder.Append("FacilityType_").Append(value);
		string text = stringBuilder.ToString();
		string text2 = DBCache.GetString(theHelper, text);
		if (string.IsNullOrEmpty(text2))
		{
			stringBuilder.Clear();
			stringBuilder.Append("Select Name, Category from Datafacility where ID = ").Append(value);
			DataRow dataRow = DBCache.GetDatatable(theHelper, stringBuilder.ToString()).Rows[0];
			Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(dataRow["Category"]);
			string text3 = (((uint)(facilityCategory - 5001) > 1u) ? facilityCategory.ToString() : Facility.MobileUnitCategory(dataRow["Name"].ToString()).ToString());
			DBCache.SetString(theHelper, text, text3);
			StringBuilderCache.Free(stringBuilder);
			return text3;
		}
		StringBuilderCache.Free(stringBuilder);
		return text2;
	}

	public static string GetGroundUnitType_String(ref Scenario theScen, int GroundUnitDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string text = DBCache.GetString(theHelper, "GroundUnitType_" + Conversions.ToString(GroundUnitDBID));
		if (string.IsNullOrEmpty(text))
		{
			string_0 = "Select Name, Category from DataGroundUnit where ID = " + Conversions.ToString(GroundUnitDBID);
			string text2 = Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(DBCache.GetDatatable(theHelper, string_0).Rows[0]["Category"]));
			DBCache.SetString(theHelper, "GroundUnitType_" + Conversions.ToString(GroundUnitDBID), text2);
			return text2;
		}
		return text;
	}

	public static string GetCargoContainerName(int theDBID, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Name from DataContainer where ID='" + Conversions.ToString(theDBID) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static void GetAircraftFlags(ref Aircraft theAircraft, int AircraftDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theAircraft.ParentScen.DBConnection);
		string_0 = "Select * from DataAircraftCodes where ID = " + Conversions.ToString(AircraftDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			switch (Conversions.ToInteger(dataRow["CodeID"]))
			{
			case 9001:
				theAircraft.CenterlineDrogue = true;
				break;
			case 9002:
				theAircraft.WingDrogue = true;
				break;
			case 9003:
				theAircraft.CenterlineBoom = true;
				break;
			case 8002:
				theAircraft.BoomRefuelling = true;
				break;
			case 8001:
				theAircraft.ProbeRefuelling = true;
				break;
			case 7010:
				theAircraft.HasHelmetMountedSight = true;
				break;
			case 7001:
				theAircraft.BombSightTech = Aircraft._BombsightTech.Basic;
				break;
			case 7002:
				theAircraft.BombSightTech = Aircraft._BombsightTech.Ballistic;
				break;
			case 7003:
				theAircraft.BombSightTech = Aircraft._BombsightTech.Computing;
				break;
			case 7004:
				theAircraft.BombSightTech = Aircraft._BombsightTech.Advanced;
				break;
			case 5002:
				theAircraft.bool_6 = true;
				break;
			case 4001:
				theAircraft.SuperManouverable = true;
				break;
			case 6012:
				theAircraft.NightNavigationAttackCapable = true;
				break;
			case 6011:
				theAircraft.NightNavigationCapable = true;
				break;
			case 5999:
				theAircraft.LandCoverMaskingCapability = true;
				break;
			case 6001:
				theAircraft.TerrainAvoidanceCapability = true;
				break;
			case 6002:
				theAircraft.TerrainFollowingCapability = true;
				break;
			case 6003:
				theAircraft.FlyByWire = true;
				break;
			case 6004:
				theAircraft.HasBlipEnhancer = true;
				break;
			case 9101:
			case 9102:
			case 9103:
			case 9104:
			case 9111:
			case 9112:
			case 9113:
			case 9114:
			case 9121:
			case 9122:
			case 9123:
			case 9124:
			case 9185:
			case 9186:
			case 9191:
			case 9192:
			case 9199:
				theAircraft.FuselageStructure = (Aircraft._AircraftFuselageStructure)Conversions.ToInteger(dataRow["CodeID"]);
				break;
			case 10102:
				theAircraft.RCSS_ExposedFanBlockers = true;
				break;
			case 10101:
				theAircraft.RCSS_SShapedIntakes = true;
				break;
			case 10001:
				theAircraft.RCSS_ActiveCancellation = true;
				break;
			default:
				_ = Debugger.IsAttached;
				break;
			case 11201:
				theAircraft.IRSS_PeakTempReduction = true;
				break;
			case 11101:
				theAircraft.IRSS_ShieldedExhaustAntiStrela = true;
				break;
			case 11102:
				theAircraft.IRSS_MaskedExhaust = true;
				break;
			case 11103:
				theAircraft.IRSS_MaskedExhaust_Slit = true;
				break;
			case 10201:
				theAircraft.RCCS_StealthPylons = true;
				break;
			}
		}
	}

	public static string GetLoadoutWeaponStateDescription(int LoadoutID, int WeaponStateID, ref SQLiteConnection theConn, Scenario theScen, bool DescriptionFromDatabase, Loadout.LoadoutRole LoadoutRole)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		if (!DescriptionFromDatabase)
		{
			return Aircraft.LoadoutWeaponStateDescirption(LoadoutID, WeaponStateID, LoadoutRole, theScen);
		}
		string_0 = "Select EnumLoadoutWinchesterShotgun.Description from EnumLoadoutWinchesterShotgun where EnumLoadoutWinchesterShotgun.ID = " + Conversions.ToString(WeaponStateID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count > 0)
		{
			return datatable.Rows[0]["Description"].ToString();
		}
		return "Winchester: Mission-specific weapons have been expended. Disengage immediately.";
	}

	public static AircraftMissionProfile GetLoadoutMissionProfile(int LoadoutID, ref SQLiteConnection theConn, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string_0 = "SELECT DefaultMissionProfile from DataLoadout where ID=" + Conversions.ToString(LoadoutID);
		return GetAircraftMissionProfile(Conversions.ToInteger(DBCache.GetScalar(theHelper, string_0)), ref theConn, theScen);
	}

	public static AircraftMissionProfile GetAircraftMissionProfile(int theID, ref SQLiteConnection theConn, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		DataTable datatable;
		try
		{
			if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
			{
				string_0 = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeIngressTerrainFollowing, CruiseAltitudeEgress, CruiseAltitudeEgressTerrainFollowing, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeIngressTerrainFollowing, AttackAltitudeEgress, AttackAltitudeEgressTerrainFollowing, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationAltitudeTerrainFollowing, StationThrottleSetting, ReservePercentage, ReserveLoiterTime, ReserveLoiterAltitude from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(theID);
			}
			else
			{
				string_0 = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeEgress, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeEgress, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationThrottleSetting, ReservePercentage, ReserveLoiterTime, ReserveLoiterAltitude from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(theID);
			}
			datatable = DBCache.GetDatatable(theHelper, string_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			string_0 = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeEgress, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeEgress, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationThrottleSetting, ReservePercentage from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(theID);
			datatable = DBCache.GetDatatable(theHelper, string_0);
			ProjectData.ClearProjectError();
		}
		AircraftMissionProfile aircraftMissionProfile = new AircraftMissionProfile();
		if (datatable.Rows.Count == 0)
		{
			return null;
		}
		DataRow dataRow = datatable.Rows[0];
		aircraftMissionProfile.DBID = (short)theID;
		aircraftMissionProfile.Description = Conversions.ToString(dataRow["Description"]);
		aircraftMissionProfile.FormUpTime = Conversions.ToInteger(dataRow["FormUpTime"]);
		aircraftMissionProfile.FormUpAltitude = (float)Conversions.ToInteger(dataRow["FormUpAltitude"]) / 3.28084f;
		aircraftMissionProfile.CruiseAltitudeIngress = (float)Conversions.ToInteger(dataRow["CruiseAltitudeIngress"]) / 3.28084f;
		aircraftMissionProfile.CruiseAltitudeEgress = (float)Conversions.ToInteger(dataRow["CruiseAltitudeEgress"]) / 3.28084f;
		aircraftMissionProfile.CruiseThrottleSettingIngress = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["CruiseThrottleSettingIngress"]);
		aircraftMissionProfile.CruiseThrottleSettingEgress = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["CruiseThrottleSettingEgress"]);
		aircraftMissionProfile.CruiseOneWayOnly = Conversions.ToBoolean(dataRow["CruiseOneWayOnly"]);
		aircraftMissionProfile.CruiseAtOptimumAltitude = Conversions.ToBoolean(dataRow["CruiseAtOptimumAltitude"]);
		aircraftMissionProfile.AttackAltitudeIngress = (float)Conversions.ToInteger(dataRow["AttackAltitudeIngress"]) / 3.28084f;
		aircraftMissionProfile.AttackAltitudeEgress = (float)Conversions.ToInteger(dataRow["AttackAltitudeEgress"]) / 3.28084f;
		aircraftMissionProfile.AttackThrottleSetting = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["AttackThrottleSetting"]);
		aircraftMissionProfile.AttackDistanceIngress = Conversions.ToInteger(dataRow["AttackDistanceIngress"]);
		aircraftMissionProfile.AttackDistanceEgress = Conversions.ToInteger(dataRow["AttackDistanceEgress"]);
		aircraftMissionProfile.DropBombsAtMaxRange = Conversions.ToBoolean(dataRow["DropBombsAtMaxRange"]);
		aircraftMissionProfile.StationAltitude = (float)Conversions.ToInteger(dataRow["StationAltitude"]) / 3.28084f;
		aircraftMissionProfile.StationThrottleSetting = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["StationThrottleSetting"]);
		aircraftMissionProfile.ReservePercentage = Conversions.ToInteger(dataRow["ReservePercentage"]);
		if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
		{
			aircraftMissionProfile.CruiseAltitudeIngressTerrainFollowing = Conversions.ToBoolean(dataRow["CruiseAltitudeIngressTerrainFollowing"]);
			aircraftMissionProfile.CruiseAltitudeEgressTerrainFollowing = Conversions.ToBoolean(dataRow["CruiseAltitudeEgressTerrainFollowing"]);
			aircraftMissionProfile.AttackAltitudeIngressTerrainFollowing = Conversions.ToBoolean(dataRow["AttackAltitudeIngressTerrainFollowing"]);
			aircraftMissionProfile.AttackAltitudeEgressTerrainFollowing = Conversions.ToBoolean(dataRow["AttackAltitudeEgressTerrainFollowing"]);
			aircraftMissionProfile.StationAltitudeTerrainFollowing = Conversions.ToBoolean(dataRow["StationAltitudeTerrainFollowing"]);
		}
		else
		{
			aircraftMissionProfile.CruiseAltitudeIngressTerrainFollowing = false;
			aircraftMissionProfile.CruiseAltitudeEgressTerrainFollowing = false;
			aircraftMissionProfile.AttackAltitudeIngressTerrainFollowing = false;
			aircraftMissionProfile.AttackAltitudeEgressTerrainFollowing = false;
			aircraftMissionProfile.StationAltitudeTerrainFollowing = false;
		}
		if (datatable.Columns.Contains("ReserveLoiterTime"))
		{
			aircraftMissionProfile.ReserveLoiterTime = Conversions.ToInteger(dataRow["ReserveLoiterTime"]);
		}
		if (datatable.Columns.Contains("ReserveLoiterAltitude"))
		{
			aircraftMissionProfile.ReserveLoiterAltitude = (float)Conversions.ToInteger(dataRow["ReserveLoiterAltitude"]) / 3.28084f;
		}
		return aircraftMissionProfile;
	}

	public static Dictionary<int, int> GetSelectedAircraftTotalWeaponQty(List<Aircraft> SelectedAircraft, ref SQLiteConnection sqliteConnection_0, [Optional][DefaultParameterValue(false)] ref bool UnlimitedAirWeapons)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (!UnlimitedAirWeapons && !Information.IsNothing((object)SelectedAircraft))
		{
			foreach (Aircraft item in SelectedAircraft)
			{
				if (Information.IsNothing((object)item.Loadout))
				{
					continue;
				}
				DataTable dataTable = new DataTable();
				dataTable = ItemsForThisLoadout(item.Loadout.DBID, ref sqliteConnection_0, ref item.Loadout.NoOptionalWeapons);
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DataRow dataRow = dataTable.Rows[i];
					int num2 = Conversions.ToInteger(dataRow["ComponentID"]);
					if (!Weapon.WeaponIsNonRivalrous(num2, ref item.ParentScen))
					{
						if (!dictionary.ContainsKey(num2))
						{
							dictionary.Add(num2, Conversions.ToInteger(dataRow["Quantity"]));
						}
						else
						{
							dictionary[num2] += Conversions.ToInteger(dataRow["Quantity"]);
						}
					}
				}
			}
		}
		return dictionary;
	}

	public static List<Loadout> LoadoutsForThisAircraft(int AircraftID, Scenario theScen)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		List<Loadout> list = new List<Loadout>();
		string_0 = "Select ComponentID from DataAircraftLoadouts where ID=" + Conversions.ToString(AircraftID);
		DataTable dataTable = sQLiteHelper.ExecuteDataTable(string_0);
		foreach (DataRow row in dataTable.Rows)
		{
			Loadout loadout = GetLoadout(ref theScen, Conversions.ToInteger(row["ComponentID"]), ExcludeOptionalWeapons: false, GetPayloadWeight: false);
			list.Add(loadout);
		}
		return list;
	}

	public static DataTable LoadoutsForThisAircraft_DT(int AircraftID, Dictionary<int, int> SelectedAircraftTotalWeaponQty, ref SQLiteConnection sqliteConnection_0, Scenario theScen, [Optional][DefaultParameterValue(false)] ref bool UnlimitedAirWeapons, [Optional][DefaultParameterValue(null)] ref Scenario CurrentScenario, [Optional][DefaultParameterValue(null)] ref Aircraft SelectedAircraft, [Optional][DefaultParameterValue(0)] ref int int_0, [Optional][DefaultParameterValue(false)] ref bool ExcludeOptionalWeapons)
	{
		if (!Information.IsNothing((object)SelectedAircraft) && Information.IsNothing((object)SelectedAircraft.AirOps.CurrentHostUnit))
		{
			return null;
		}
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable dataTable;
		if (int_0 <= 0)
		{
			if (CurrentScenario == null)
			{
				if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
				{
					string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime, ReadyTime_Sustained, LoadoutRole, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ExecuteDataTable(string_0);
				}
				else
				{
					try
					{
						string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime, ReadyTime_Sustained, LoadoutRole, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
						dataTable = sQLiteHelper.ExecuteDataTable(string_0);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime AS ReadyTime, LoadoutRole from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
						dataTable = sQLiteHelper.ExecuteDataTable(string_0);
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
			{
				string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
				dataTable = sQLiteHelper.ExecuteDataTable(string_0);
			}
			else
			{
				try
				{
					string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ExecuteDataTable(string_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					string_0 = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ExecuteDataTable(string_0);
					ProjectData.ClearProjectError();
				}
			}
		}
		else if (!theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
		{
			try
			{
				string_0 = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_0);
				dataTable = sQLiteHelper.ExecuteDataTable(string_0);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				string_0 = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_0);
				dataTable = sQLiteHelper.ExecuteDataTable(string_0);
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			string_0 = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_0);
			dataTable = sQLiteHelper.ExecuteDataTable(string_0);
		}
		if (!dataTable.Columns.Contains("QuickTurnaround"))
		{
			dataTable.Columns.Add("QuickTurnaround", typeof(string));
			foreach (DataRow row in dataTable.Rows)
			{
				row["QuickTurnaround"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_ReadyTime"))
		{
			dataTable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
			foreach (DataRow row2 in dataTable.Rows)
			{
				row2["QuickTurnaround_ReadyTime"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_MaxSorties"))
		{
			dataTable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
			foreach (DataRow row3 in dataTable.Rows)
			{
				row3["QuickTurnaround_MaxSorties"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
		{
			dataTable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
			foreach (DataRow row4 in dataTable.Rows)
			{
				row4["QuickTurnaround_AdditionalTimePenalty"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_AirborneTime"))
		{
			dataTable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
			foreach (DataRow row5 in dataTable.Rows)
			{
				row5["QuickTurnaround_AirborneTime"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_TimeofDay"))
		{
			dataTable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
			foreach (DataRow row6 in dataTable.Rows)
			{
				row6["QuickTurnaround_TimeofDay"] = 0;
			}
		}
		if (!dataTable.Columns.Contains("WinchesterShotgun"))
		{
			dataTable.Columns.Add("WinchesterShotgun", typeof(string));
			foreach (DataRow row7 in dataTable.Rows)
			{
				row7["WinchesterShotgun"] = 0;
			}
		}
		if (CurrentScenario != null)
		{
			if (!dataTable.Columns.Contains("NumberOfLoadouts"))
			{
				dataTable.Columns.Add("NumberOfLoadouts", typeof(string));
			}
			if (!dataTable.Columns.Contains("NumberOfLoadoutsIncludingMountedWeapons"))
			{
				dataTable.Columns.Add("NumberOfLoadoutsIncludingMountedWeapons", typeof(string));
			}
			if (!dataTable.Columns.Contains("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"))
			{
				dataTable.Columns.Add("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly", typeof(string));
			}
			if (!dataTable.Columns.Contains("QuickTurnaroundDescription"))
			{
				dataTable.Columns.Add("QuickTurnaroundDescription", typeof(string));
			}
			if (!dataTable.Columns.Contains("WinchesterShotgunDescription"))
			{
				dataTable.Columns.Add("WinchesterShotgunDescription", typeof(string));
			}
			DataTable dataTable2 = new DataTable();
			int num4 = default(int);
			foreach (DataRow row8 in dataTable.Rows)
			{
				int num = int.MaxValue;
				int num2 = int.MaxValue;
				int num3 = int.MaxValue;
				dataTable2 = ItemsForThisLoadout(Conversions.ToInteger(row8["ID"]), ref sqliteConnection_0, ref ExcludeOptionalWeapons);
				if (!UnlimitedAirWeapons)
				{
					foreach (DataRow row9 in dataTable2.Rows)
					{
						num4 = Conversions.ToInteger(row9["ComponentID"]);
						int num5 = Conversions.ToInteger(row9["Quantity"]);
						bool flag = Conversions.ToBoolean(row9["Optional"]);
						if (Weapon.WeaponIsNonRivalrous(num4, ref CurrentScenario))
						{
							continue;
						}
						int num6 = SelectedAircraft.AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(num4);
						int num7 = 0;
						if (!Information.IsNothing((object)SelectedAircraftTotalWeaponQty) && SelectedAircraftTotalWeaponQty.ContainsKey(num4))
						{
							num7 = SelectedAircraftTotalWeaponQty[num4];
						}
						if (num5 <= 0)
						{
							continue;
						}
						int num8 = num6 / num5;
						if (num8 < num)
						{
							num = num8;
						}
						num8 = (num6 + num7) / num5;
						if (num8 < num2)
						{
							num2 = num8;
						}
						if (!flag)
						{
							num8 = (num6 + num7) / num5;
							if (num8 < num3)
							{
								num3 = num8;
							}
						}
					}
				}
				if (num != int.MaxValue && !UnlimitedAirWeapons)
				{
					row8["NumberOfLoadouts"] = num;
				}
				else
				{
					row8["NumberOfLoadouts"] = "Unlimited";
				}
				if (num2 != int.MaxValue && !UnlimitedAirWeapons)
				{
					row8["NumberOfLoadoutsIncludingMountedWeapons"] = num2;
				}
				else
				{
					row8["NumberOfLoadoutsIncludingMountedWeapons"] = "Unlimited";
				}
				if (num3 != int.MaxValue && !UnlimitedAirWeapons)
				{
					row8["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"] = num3;
				}
				else
				{
					row8["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"] = "Unlimited";
				}
				if (!Conversions.ToBoolean(row8["QuickTurnaround"]))
				{
					row8["QuickTurnaroundDescription"] = "-";
				}
				else
				{
					int num9 = Conversions.ToInteger(row8["QuickTurnaround_ReadyTime"]);
					int num10 = Conversions.ToInteger(row8["QuickTurnaround_MaxSorties"]);
					int num11 = Conversions.ToInteger(row8["QuickTurnaround_AirborneTime"]);
					string_0 = "Select EnumLoadoutTimeOfDay.Description from EnumLoadoutTimeOfDay, DataLoadout where EnumLoadoutTimeOfDay.ID = DataLoadout.QuickTurnaround_TimeofDay and DataLoadout.ID = " + row8["ID"].ToString();
					DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
					string text = ((datatable.Rows.Count <= 0) ? "No time-of-day description" : datatable.Rows[0]["Description"].ToString());
					row8["QuickTurnaroundDescription"] = text + ", " + Conversions.ToString(num10) + " sorties @ " + Misc.TimeString(num9 * 60) + ", " + Misc.TimeString(num11 * 60) + " flying time";
				}
				if (Conversions.ToBoolean(row8["WinchesterShotgun"]) && Conversions.ToInteger(row8["WinchesterShotgun"]) != 0)
				{
					row8["WinchesterShotgunDescription"] = GetLoadoutWeaponStateDescription(num4, Conversions.ToInteger(row8["WinchesterShotgun"]), ref sqliteConnection_0, CurrentScenario, DescriptionFromDatabase: false, (Loadout.LoadoutRole)Conversions.ToInteger(row8["LoadoutRole"]));
				}
				else
				{
					row8["WinchesterShotgunDescription"] = "Winchester: Mission-specific weapons have been expended. Disengage immediately.";
				}
			}
		}
		if (CurrentScenario != null)
		{
			foreach (DataRow row10 in dataTable.Rows)
			{
				if (!dataTable.Columns.Contains("RangeProfileDescription"))
				{
					dataTable.Columns.Add("RangeProfileDescription", typeof(string));
				}
				if (!dataTable.Columns.Contains("LoadoutRoleDescription"))
				{
					dataTable.Columns.Add("LoadoutRoleDescription", typeof(string));
				}
				if (!dataTable.Columns.Contains("Weather"))
				{
					dataTable.Columns.Add("Weather", typeof(string));
				}
				if (!dataTable.Columns.Contains("TimeofDay"))
				{
					dataTable.Columns.Add("TimeofDay", typeof(string));
				}
				if (!dataTable.Columns.Contains("ReadyTime"))
				{
					dataTable.Columns.Add("ReadyTime", typeof(string));
				}
				if (!dataTable.Columns.Contains("ReadyTime_Sustained"))
				{
					dataTable.Columns.Add("ReadyTime_Sustained", typeof(string));
				}
				string description = GetLoadoutMissionProfile(Conversions.ToInteger(row10["ID"]), ref sqliteConnection_0, theScen).Description;
				int num12 = Conversions.ToInteger(row10["DefaultCombatRadius"]);
				int num13 = Conversions.ToInteger(row10["DefaultTimeOnStation"]);
				string text2 = ((Conversions.ToInteger(row10["DefaultMissionProfile"]) == 1001) ? "" : ((num13 <= 0) ? (Conversions.ToString(num12) + " nm ") : (Conversions.ToString(num13) + " minutes at " + Conversions.ToString(num12) + " nm ")));
				row10["RangeProfileDescription"] = text2 + description;
				string_0 = "Select EnumLoadoutRole.Description from EnumLoadoutRole, DataLoadout where EnumLoadoutRole.ID =  DataLoadout.LoadoutRole and DataLoadout.ID = " + Conversions.ToString(Conversions.ToInteger(row10["ID"]));
				DataTable datatable2 = DBCache.GetDatatable(sQLiteHelper, string_0);
				if (datatable2.Rows.Count > 0)
				{
					string text3 = Conversions.ToString(datatable2.Rows[0]["Description"]);
					row10["LoadoutRoleDescription"] = "Loadout Role: " + text3;
				}
				else
				{
					row10["LoadoutRoleDescription"] = "Loadout Role: None";
				}
				string_0 = "Select EnumLoadoutWeather.Description from EnumLoadoutWeather, DataLoadout where EnumLoadoutWeather.ID = DataLoadout.Weather and DataLoadout.ID = " + Conversions.ToString(Conversions.ToInteger(row10["ID"]));
				DataTable datatable3 = DBCache.GetDatatable(sQLiteHelper, string_0);
				if (datatable3.Rows.Count > 0)
				{
					string value = Conversions.ToString(datatable3.Rows[0]["Description"]);
					row10["Weather"] = value;
				}
				else
				{
					row10["Weather"] = "";
				}
				string_0 = "Select EnumLoadoutTimeOfDay.Description from EnumLoadoutTimeOfDay, DataLoadout where EnumLoadoutTimeOfDay.ID = DataLoadout.TimeofDay and DataLoadout.ID = " + row10["ID"].ToString();
				DataTable datatable4 = DBCache.GetDatatable(sQLiteHelper, string_0);
				if (datatable4.Rows.Count > 0)
				{
					string value2 = datatable4.Rows[0]["Description"].ToString();
					row10["TimeofDay"] = value2;
				}
				else
				{
					row10["TimeofDay"] = "";
				}
				try
				{
					string_0 = "SELECT ReadyTime, ReadyTime_Sustained from DataLoadout where DataLoadout.ID = " + row10["ID"].ToString();
					DataTable datatable5 = DBCache.GetDatatable(sQLiteHelper, string_0);
					if (datatable5.Rows.Count > 0)
					{
						DataRow dataRow3 = datatable5.Rows[0];
						long num14 = Conversions.ToLong(dataRow3["ReadyTime"]);
						long num15 = Conversions.ToLong(dataRow3["ReadyTime_Sustained"]);
						if (num14 > 0L)
						{
							string value3 = Misc.TimeString(num14 * 60L);
							row10["ReadyTime"] = value3;
						}
						else
						{
							row10["ReadyTime"] = "n/a";
						}
						if (num15 > 0L)
						{
							string value4 = Misc.TimeString(num15 * 60L);
							row10["ReadyTime_Sustained"] = value4;
						}
						else
						{
							row10["ReadyTime_Sustained"] = "n/a";
						}
					}
					else
					{
						row10["ReadyTime"] = "";
						row10["ReadyTime_Sustained"] = "";
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					string_0 = "SELECT ReadyTime as ReadyTime from DataLoadout where DataLoadout.ID = " + row10["ID"].ToString();
					DataTable datatable5 = DBCache.GetDatatable(sQLiteHelper, string_0);
					if (datatable5.Rows.Count <= 0)
					{
						row10["ReadyTime"] = "";
					}
					else
					{
						long num16 = Conversions.ToLong(datatable5.Rows[0]["ReadyTime"]);
						if (num16 <= 0L)
						{
							row10["ReadyTime"] = "n/a";
						}
						else
						{
							string value5 = Misc.TimeString(num16 * 60L);
							row10["ReadyTime"] = value5;
						}
					}
					row10["ReadyTime_Sustained"] = "-";
					ProjectData.ClearProjectError();
				}
			}
		}
		foreach (DataRow row11 in dataTable.Rows)
		{
			_ = row11;
			if (dataTable.Columns.Contains("AttackAltitude"))
			{
				continue;
			}
			dataTable.Columns.Add("AttackAltitude", typeof(string));
			foreach (DataRow row12 in dataTable.Rows)
			{
				if (Information.IsNothing((object)GetLoadoutMissionProfile(Conversions.ToInteger(row12["ID"]), ref sqliteConnection_0, theScen)))
				{
					continue;
				}
				float attackAltitudeIngress = GetLoadoutMissionProfile(Conversions.ToInteger(row12["ID"]), ref sqliteConnection_0, theScen).AttackAltitudeIngress;
				string text4 = "";
				if (attackAltitudeIngress == 0f)
				{
					switch ((Loadout.LoadoutRole)Conversions.ToInteger(row12["LoadoutRole"]))
					{
					default:
						row12["AttackAltitude"] = "-";
						break;
					case Loadout.LoadoutRole.LandNaval_Strike:
					case Loadout.LoadoutRole.LandNaval_Standoff:
					case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
					case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
					case Loadout.LoadoutRole.LandNaval_DEAD:
					case Loadout.LoadoutRole.LandOnly_Strike:
					case Loadout.LoadoutRole.LandOnly_Standoff:
					case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
					case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
					case Loadout.LoadoutRole.LandOnly_DEAD:
					case Loadout.LoadoutRole.NavalOnly_Strike:
					case Loadout.LoadoutRole.NavalOnly_Standoff:
					case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
					case Loadout.LoadoutRole.NavalOnly_SEAD_TALD:
					case Loadout.LoadoutRole.NavalOnly_DEAD:
					case Loadout.LoadoutRole.BAI_CAS:
					case Loadout.LoadoutRole.NavalMineLaying:
					case Loadout.LoadoutRole.ASW_Attack:
						attackAltitudeIngress = GetLoadoutMissionProfile(Conversions.ToInteger(row12["ID"]), ref sqliteConnection_0, theScen).CruiseAltitudeIngress;
						if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
						{
							text4 = ((!GetLoadoutMissionProfile(Conversions.ToInteger(row12["ID"]), ref sqliteConnection_0, theScen).CruiseAltitudeIngressTerrainFollowing) ? " ASL" : " AGL (Terrain Following / Avoidance)");
						}
						if (attackAltitudeIngress == 0f)
						{
							row12["AttackAltitude"] = "-";
						}
						else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							row12["AttackAltitude"] = Conversions.ToString(Math.Round(attackAltitudeIngress * 3.28084f, 0)) + " ft" + text4;
						}
						else
						{
							row12["AttackAltitude"] = "Attack Altitude: " + Conversions.ToString(attackAltitudeIngress) + " m" + text4;
						}
						break;
					}
				}
				else
				{
					if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
					{
						text4 = ((!GetLoadoutMissionProfile(Conversions.ToInteger(row12["ID"]), ref sqliteConnection_0, theScen).AttackAltitudeIngressTerrainFollowing) ? " ASL" : " AGL (Terrain Following / Avoidance)");
					}
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						row12["AttackAltitude"] = "Attack Altitude: " + Conversions.ToString(attackAltitudeIngress) + " m" + text4;
					}
					else
					{
						row12["AttackAltitude"] = Conversions.ToString(Math.Round(attackAltitudeIngress * 3.28084f, 0)) + " ft" + text4;
					}
				}
			}
		}
		return dataTable;
	}

	public static List<int> WeaponsCarriedByThisAircraft(int AircraftID, ref SQLiteConnection sqliteConnection_0)
	{
		List<int> list = new List<int>();
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT DISTINCT DataWeapon.ID from DataWeapon, DataLoadout, DataLoadoutWeapons, DataAircraftLoadouts, DataWeaponRecord where DataWeapon.ID = DataWeaponRecord.ComponentID and DataWeaponRecord.ID = DataLoadoutWeapons.ComponentID and DataLoadoutWeapons.ID = DataLoadout.ID and DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(AircraftID) + " ORDER BY DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			list.Add(Conversions.ToInteger(dataRow["ID"]));
		}
		return list;
	}

	public static DataTable ItemsForThisLoadout(int LoadoutID, ref SQLiteConnection sqliteConnection_0, ref bool ExcludeOptionalWeapons)
	{
		DataTable dataTable = new DataTable();
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT DataLoadoutWeapons.ComponentID, DataLoadoutWeapons.Optional, DataLoadoutWeapons.Internal FROM DataLoadoutWeapons, DataWeaponRecord, DataWeapon WHERE DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID AND DataWeapon.ID = DataWeaponRecord.ComponentID AND DataLoadoutWeapons.ID = " + Conversions.ToString(LoadoutID) + " ORDER BY DataWeapon.Type, DataWeapon.Name, DataWeaponRecord.DefaultLoad ASC";
		DataTable datatable;
		try
		{
			datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			string_0 = "SELECT DataLoadoutWeapons.ComponentID FROM DataLoadoutWeapons, DataWeaponRecord, DataWeapon WHERE DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID AND DataWeapon.ID = DataWeaponRecord.ComponentID AND DataLoadoutWeapons.ID = " + Conversions.ToString(LoadoutID) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
			datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			ProjectData.ClearProjectError();
		}
		dataTable.Columns.Add("ComponentID", typeof(int));
		dataTable.Columns.Add("Quantity", typeof(int));
		dataTable.Columns.Add("Item", typeof(string));
		dataTable.Columns.Add("Optional", typeof(bool));
		dataTable.Columns.Add("Internal", typeof(bool));
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (!datatable.Columns.Contains("Optional") || !Conversions.ToBoolean(dataRow["Optional"]) || !ExcludeOptionalWeapons)
			{
				string_0 = "Select DataWeapon.ID as ID, DataWeapon.NAME, DataWeaponRecord.DefaultLoad from DataWeapon, DataWeaponRecord where DataWeapon.ID = DataWeaponRecord.ComponentID and DataWeaponRecord.ID =" + dataRow["ComponentID"].ToString();
				SQLiteDataReader sQLiteDataReader = sQLiteHelper.ExecuteReader(string_0);
				sQLiteDataReader.Read();
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2["ComponentID"] = RuntimeHelpers.GetObjectValue(sQLiteDataReader["ID"]);
				dataRow2["Quantity"] = RuntimeHelpers.GetObjectValue(sQLiteDataReader["DefaultLoad"]);
				if (datatable.Columns.Contains("Optional"))
				{
					dataRow2["Optional"] = RuntimeHelpers.GetObjectValue(dataRow["Optional"]);
				}
				else
				{
					dataRow2["Optional"] = false;
				}
				if (!datatable.Columns.Contains("Internal"))
				{
					dataRow2["Internal"] = false;
				}
				else
				{
					dataRow2["Internal"] = RuntimeHelpers.GetObjectValue(dataRow["Internal"]);
				}
				if (Conversions.ToBoolean(dataRow2["Optional"]) && Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = sQLiteDataReader["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(sQLiteDataReader["Name"])) + "   (Internal, Optional)";
				}
				else if (Conversions.ToBoolean(dataRow2["Optional"]) && !Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = sQLiteDataReader["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(sQLiteDataReader["Name"])) + "   (Optional)";
				}
				else if (!Conversions.ToBoolean(dataRow2["Optional"]) && Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = sQLiteDataReader["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(sQLiteDataReader["Name"])) + "   (Internal)";
				}
				else
				{
					dataRow2["Item"] = sQLiteDataReader["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(sQLiteDataReader["Name"]));
				}
				dataTable.Rows.Add(dataRow2);
				sQLiteDataReader.Close();
				sQLiteDataReader = null;
			}
		}
		return dataTable;
	}

	public static Loadout GetReserveLoadoutForThisAircraft(ref Scenario theScen, int AircraftID)
	{
		Loadout result;
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
			string_0 = "Select ComponentID from DataAircraftLoadouts where ID = " + Conversions.ToString(AircraftID);
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			foreach (DataRow row in datatable.Rows)
			{
				Loadout loadout = GetLoadout(ref theScen, Conversions.ToInteger(row["ComponentID"]), ExcludeOptionalWeapons: false, GetPayloadWeight: false);
				if (loadout.Role != Loadout.LoadoutRole.Reserve)
				{
					continue;
				}
				result = loadout;
				goto end_IL_0001;
			}
			result = null;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101259", "");
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

	public static Loadout GetMaintenanceLoadoutForThisAircraft(ref Scenario theScen, int AircraftID)
	{
		Loadout result;
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
			string_0 = "Select ComponentID from DataAircraftLoadouts where ID = " + Conversions.ToString(AircraftID);
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			foreach (DataRow row in datatable.Rows)
			{
				Loadout loadout = GetLoadout(ref theScen, Conversions.ToInteger(row["ComponentID"]), ExcludeOptionalWeapons: false, GetPayloadWeight: false);
				if (loadout.Role != Loadout.LoadoutRole.Unavailable)
				{
					continue;
				}
				result = loadout;
				goto end_IL_0001;
			}
			result = null;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101260", "");
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

	public static Loadout GetLoadout(ref Scenario theScen, int LoadoutID, bool ExcludeOptionalWeapons, bool GetPayloadWeight)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataLoadout where ID = " + Conversions.ToString(LoadoutID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count > 0)
		{
			DataRow dataRow = datatable.Rows[0];
			if (!datatable.Columns.Contains("QuickTurnaround"))
			{
				datatable.Columns.Add("QuickTurnaround", typeof(string));
				dataRow["QuickTurnaround"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_ReadyTime"))
			{
				datatable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
				dataRow["QuickTurnaround_ReadyTime"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_MaxSorties"))
			{
				datatable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
				dataRow["QuickTurnaround_MaxSorties"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
			{
				datatable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
				dataRow["QuickTurnaround_AdditionalTimePenalty"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_AirborneTime"))
			{
				datatable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
				dataRow["QuickTurnaround_AirborneTime"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_TimeofDay"))
			{
				datatable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
				dataRow["QuickTurnaround_TimeofDay"] = 0;
			}
			if (!datatable.Columns.Contains("ReadyTime_Sustained"))
			{
				datatable.Columns.Add("ReadyTime_Sustained", typeof(string));
				dataRow["ReadyTime_Sustained"] = 0;
			}
			if (!datatable.Columns.Contains("WinchesterShotgun"))
			{
				datatable.Columns.Add("WinchesterShotgun", typeof(string));
				dataRow["WinchesterShotgun"] = 0;
			}
			Loadout theLoadout = new Loadout(LoadoutID, dataRow["Name"].ToString(), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToInteger(dataRow["ReadyTime"]), Conversions.ToInteger(dataRow["ReadyTime_Sustained"]), (Loadout.LoadoutRole)Conversions.ToInteger(dataRow["LoadoutRole"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["TimeofDay"]), (Loadout._LoadoutWeather)Conversions.ToShort(dataRow["Weather"]), Conversions.ToSingle(dataRow["PayloadWeightDragModifier"]), Conversions.ToInteger(dataRow["DefaultCombatRadius"]), Conversions.ToShort(dataRow["DefaultTimeOnStation"]), Conversions.ToBoolean(dataRow["RequiresBuddyIllumination"]), ExcludeOptionalWeapons, Conversions.ToBoolean(dataRow["QuickTurnaround"]), Conversions.ToInteger(dataRow["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(dataRow["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(dataRow["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(dataRow["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["QuickTurnaround_TimeofDay"]), (Doctrine._WeaponState)Conversions.ToInteger(dataRow["WinchesterShotgun"]));
			try
			{
				theLoadout.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (datatable.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
					{
						theLoadout.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
					{
						theLoadout.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
					{
						theLoadout.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
					{
						theLoadout.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_ParadropCapable"])))
					{
						theLoadout.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			GetLoadoutWeapons(ref theScen, ref theLoadout, LoadoutID, ExcludeOptionalWeapons);
			if (GetPayloadWeight)
			{
				GetLoadoutPayloadWeight(ref theScen, ref theLoadout);
			}
			return theLoadout;
		}
		throw new PlatformComponentNotFoundException("This loadout ID does not exist in the database.");
	}

	public static void GetLoadout(ref Aircraft theAircraft, int LoadoutID, bool ExcludeOptionalWeapons)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theAircraft.ParentScen.DBConnection);
		string_0 = "Select * from DataLoadout where ID = " + Conversions.ToString(LoadoutID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count > 0)
		{
			DataRow dataRow = datatable.Rows[0];
			string text = dataRow["Name"].ToString();
			if (ExcludeOptionalWeapons)
			{
				text += " - Mandatory Weapons Only";
			}
			if (!datatable.Columns.Contains("QuickTurnaround"))
			{
				datatable.Columns.Add("QuickTurnaround", typeof(string));
				dataRow["QuickTurnaround"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_ReadyTime"))
			{
				datatable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
				dataRow["QuickTurnaround_ReadyTime"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_MaxSorties"))
			{
				datatable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
				dataRow["QuickTurnaround_MaxSorties"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
			{
				datatable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
				dataRow["QuickTurnaround_AdditionalTimePenalty"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_AirborneTime"))
			{
				datatable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
				dataRow["QuickTurnaround_AirborneTime"] = 0;
			}
			if (!datatable.Columns.Contains("QuickTurnaround_TimeofDay"))
			{
				datatable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
				dataRow["QuickTurnaround_TimeofDay"] = 0;
			}
			if (!datatable.Columns.Contains("ReadyTime_Sustained"))
			{
				datatable.Columns.Add("ReadyTime_Sustained", typeof(string));
				dataRow["ReadyTime_Sustained"] = 0;
			}
			if (!datatable.Columns.Contains("WinchesterShotgun"))
			{
				datatable.Columns.Add("WinchesterShotgun", typeof(string));
				dataRow["WinchesterShotgun"] = 2001;
			}
			Loadout theLoadout = null;
			try
			{
				theLoadout = new Loadout(LoadoutID, text, Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToInteger(dataRow["ReadyTime"]), Conversions.ToInteger(dataRow["ReadyTime_Sustained"]), (Loadout.LoadoutRole)Conversions.ToInteger(dataRow["LoadoutRole"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["TimeofDay"]), (Loadout._LoadoutWeather)Conversions.ToShort(dataRow["Weather"]), Conversions.ToSingle(dataRow["PayloadWeightDragModifier"]), Conversions.ToInteger(dataRow["DefaultCombatRadius"]), Conversions.ToShort(dataRow["DefaultTimeOnStation"]), Conversions.ToBoolean(dataRow["RequiresBuddyIllumination"]), ExcludeOptionalWeapons, Conversions.ToBoolean(dataRow["QuickTurnaround"]), Conversions.ToInteger(dataRow["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(dataRow["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(dataRow["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(dataRow["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["QuickTurnaround_TimeofDay"]), (Doctrine._WeaponState)Conversions.ToInteger(dataRow["WinchesterShotgun"]));
				theLoadout.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200473", ex2.Message + " [ on loadout id " + Conversions.ToString(LoadoutID) + " for " + theAircraft.AnnexAndDBID + " ]");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (theLoadout == null)
				{
					theAircraft.Loadout = theLoadout;
					ProjectData.ClearProjectError();
					return;
				}
				ProjectData.ClearProjectError();
			}
			if (datatable.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
					{
						theLoadout.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
					{
						theLoadout.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
					{
						theLoadout.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
					{
						theLoadout.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_ParadropCapable"])))
					{
						theLoadout.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			GetLoadoutWeapons(ref theAircraft.ParentScen, ref theLoadout, LoadoutID, ExcludeOptionalWeapons);
			GetLoadoutPayloadWeight(ref theAircraft.ParentScen, ref theLoadout);
			theAircraft.Loadout = theLoadout;
			return;
		}
		throw new PlatformComponentNotFoundException("Unable to equip aircraft: " + theAircraft.Name + " with loadout #ID: " + Conversions.ToString(LoadoutID) + ". This loadout ID does not exist in the database.");
	}

	public static void GetLoadoutWeapons(ref Scenario theScen, ref Loadout theLoadout, int LoadoutID, bool ExcludeOptionalWeapons)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "SELECT DataWeaponRecord.*, DataLoadoutWeapons.ComponentNumber, DataLoadoutWeapons.Optional, DataLoadoutWeapons.Internal from DataLoadoutWeapons, DataWeaponRecord, DataWeapon where DataWeaponRecord.ID =DataLoadoutWeapons.ComponentID And DataWeapon.ID=DataWeaponRecord.ComponentID And DataLoadoutWeapons.ID = " + Conversions.ToString(LoadoutID) + " ORDER BY DataWeapon.Type, DataWeapon.Name";
		DataTable datatable;
		try
		{
			datatable = DBCache.GetDatatable(theHelper, string_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			string_0 = "SELECT DataWeaponRecord.*, DataLoadoutWeapons.ComponentNumber from DataLoadoutWeapons, DataWeaponRecord, DataWeapon where DataWeaponRecord.ID =DataLoadoutWeapons.ComponentID And DataWeapon.ID=DataWeaponRecord.ComponentID And DataLoadoutWeapons.ID = " + Conversions.ToString(LoadoutID) + " ORDER BY DataWeapon.Type, DataWeapon.Name";
			datatable = DBCache.GetDatatable(theHelper, string_0);
			ProjectData.ClearProjectError();
		}
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			bool flag = datatable.Columns.Contains("Optional") && Conversions.ToBoolean(dataRow["Optional"]);
			bool aircraftInternalWeapons = datatable.Columns.Contains("Internal") && Conversions.ToBoolean(dataRow["Internal"]);
			if (!flag || !ExcludeOptionalWeapons)
			{
				WeaponRec theRec = new WeaponRec(ref theScen, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), flag, aircraftInternalWeapons);
				theLoadout.AddWeaponRec(theRec);
			}
		}
	}

	public static void GetLoadoutPayloadWeight(ref Scenario theScen, ref Loadout theLoadout)
	{
		try
		{
			WeaponRec[] weapons = theLoadout.Weapons;
			int num = default(int);
			int num2 = default(int);
			foreach (WeaponRec weaponRec in weapons)
			{
				num += weaponRec.get_ReferenceWeapon(theScen).EmptyWeight * weaponRec.CurrentLoad;
				if (theLoadout.get_MissionProfile(theScen).DropBombsAtMaxRange)
				{
					Weapon weapon = weaponRec.get_ReferenceWeapon(theScen);
					if (weapon.IsASuW_Land || weapon.IsASuW_Naval || weapon.IsAntiradar)
					{
						num2 += weapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			theLoadout.PayloadWeight = num;
			theLoadout.PayloadWeightDroppable = num2;
			theLoadout.PayloadWeight_TakeOff = num;
			theLoadout.PayloadWeightDroppable_TakeOff = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetLoadoutPayloadTakeOffWeight_Current(ref Scenario theScen, ref Loadout theLoadout)
	{
		try
		{
			WeaponRec[] weapons = theLoadout.Weapons;
			int num = default(int);
			int num2 = default(int);
			foreach (WeaponRec weaponRec in weapons)
			{
				num += weaponRec.get_ReferenceWeapon(theScen).EmptyWeight * weaponRec.CurrentLoad;
				if (theLoadout.get_MissionProfile(theScen).DropBombsAtMaxRange)
				{
					Weapon weapon = weaponRec.get_ReferenceWeapon(theScen);
					if (weapon.IsASuW_Land || weapon.IsASuW_Naval || weapon.IsAntiradar)
					{
						num2 += weapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			theLoadout.PayloadWeight = num;
			theLoadout.PayloadWeightDroppable = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetLoadoutPayloadTakeOffWeight_Static(ref Scenario theScen, ref Loadout theLoadout)
	{
		try
		{
			WeaponRec[] weapons = theLoadout.Weapons;
			int num = default(int);
			int num2 = default(int);
			foreach (WeaponRec weaponRec in weapons)
			{
				num += weaponRec.get_ReferenceWeapon(theScen).EmptyWeight * weaponRec.CurrentLoad;
				if (theLoadout.get_MissionProfile(theScen).DropBombsAtMaxRange)
				{
					Weapon weapon = weaponRec.get_ReferenceWeapon(theScen);
					if (weapon.IsASuW_Land || weapon.IsASuW_Naval || weapon.IsAntiradar)
					{
						num2 += weapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			theLoadout.PayloadWeight_TakeOff = num;
			theLoadout.PayloadWeightDroppable_TakeOff = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) GetShipCombatSystemOODAValues(ref Scenario theScen, int CSGenID, bool CheckIfTableExists)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		(string, string, short, short, short) result;
		if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumShipCSGen"))
		{
			result = (string.Empty, string.Empty, 0, 0, 0);
		}
		else
		{
			string_0 = "Select * from EnumShipCSGen where ID = " + Conversions.ToString(CSGenID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			DataRow dataRow = datatable.Rows[0];
			short item = 0;
			short item2 = 0;
			short item3 = 0;
			string item4 = "";
			string item5 = "";
			if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
			{
				item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
			{
				item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
			{
				item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
			{
				item5 = Conversions.ToString(dataRow["Description"]);
			}
			if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
			{
				item4 = Conversions.ToString(dataRow["Example"]);
			}
			result = (item5, item4, item, item2, item3);
		}
		return result;
	}

	public static void GetShip(ref Scenario theScen, ref Ship theShip, int ShipDBID, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataShip where ID = " + Conversions.ToString(ShipDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No ship with ID: " + Conversions.ToString(ShipDBID) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				theShip.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) shipCombatSystemOODAValues = GetShipCombatSystemOODAValues(ref theScen, theShip.CombatSystemGen, CheckIfTableExists: false);
				theShip.OODA_Detection = shipCombatSystemOODAValues.Item3;
				theShip.OODA_Targeting = shipCombatSystemOODAValues.Item4;
				theShip.OODA_Evasion = shipCombatSystemOODAValues.Item5;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
					theShip.OODA_Detection = 0;
				}
				else
				{
					theShip.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
					theShip.OODA_Targeting = 0;
				}
				else
				{
					theShip.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
					theShip.OODA_Evasion = 0;
				}
				else
				{
					theShip.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
			}
			if (theShip.Crew == 0 && datatable.Columns.Contains("AutonomousControlLevel"))
			{
				try
				{
					theShip.AutonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(dataRow["AutonomousControlLevel"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					theShip.AutonomyLevel = ActiveUnit.DroneAutonomyLevel.SelfRecovering;
					ProjectData.ClearProjectError();
				}
			}
			theShip.Category = (Ship._ShipCategory)Conversions.ToInteger(dataRow["Category"].ToString());
			theShip.Type = (Ship._ShipType)Conversions.ToInteger(dataRow["Type"].ToString());
			theShip.DBID = ShipDBID;
			theShip.UnitClass = Strings.Trim(dataRow["Name"].ToString());
			theShip.Length = Conversions.ToSingle(dataRow["Length"].ToString());
			try
			{
				theShip.DockingPhysicalSize = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSizeCode"].ToString());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				theShip.DockingPhysicalSize = GetDockingPhysicalSize(theShip.Length);
				ex2?.Data.Add("Error at 200072", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			theShip.Crew = Conversions.ToInteger(dataRow["Crew"]);
			theShip.Armor_Belt = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBelt"]);
			theShip.Armor_Bridge = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBridge"]);
			theShip.Armor_Bulkhead = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBulkheads"]);
			theShip.Armor_CIC = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorCIC"]);
			theShip.Armor_Deck = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorDeck"]);
			theShip.Armor_Engineering = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorEngineering"]);
			theShip.Armor_Rudder = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorRudder"]);
			theShip.MaxSeaState = Conversions.ToByte(dataRow["MaxSeaState"]);
			theShip.RepairCapacity = (short)Conversions.ToInteger(dataRow["RepairCapacity"]);
			theShip.TroopCapacity = (short)Conversions.ToInteger(dataRow["TroopCapacity"]);
			theShip.CargoCapacity = Conversions.ToInteger(dataRow["CargoCapacity"]);
			theShip.MissileDefense = Conversions.ToShort(dataRow["MissileDefense"]);
			theShip.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			((ActiveUnit)theShip).set_DamagePts(ScenEditAction: false, (Weapon)null, Conversions.ToSingle(dataRow["DamagePoints"]));
			theShip.Displacement_Empty = Conversions.ToSingle(dataRow["DisplacementEmpty"]);
			theShip.Displacement_Standard = Conversions.ToSingle(dataRow["DisplacementStandard"]);
			theShip.Displacement_Full = Conversions.ToSingle(dataRow["DisplacementFull"]);
			theShip.EmptyWeight = (int)Math.Round(theShip.Displacement_Standard);
			theShip.Beam = Conversions.ToSingle(dataRow["Beam"]);
			theShip.Draft = Conversions.ToSingle(dataRow["Draft"]);
			theShip.Height = Conversions.ToSingle(dataRow["Height"]);
			if (datatable.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
					{
						theShip.Cargo_Crew = Conversions.ToSingle(dataRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
					{
						theShip.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
					{
						theShip.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
					{
						theShip.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			theShip.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			try
			{
				theShip.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200475", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		GeDataShipFlags(ref theShip, ShipDBID);
		if (LoadComponents)
		{
			PopulateSensors(theShip, ShipDBID);
			PopulateComms(theShip, ShipDBID);
			ActiveUnit theUnit = theShip;
			PopulateMounts(ref theScen, ref theUnit, ShipDBID);
			PopulatePropulsion(theShip, ShipDBID);
			PopulateFuel(theShip, ShipDBID);
			Platform theUnit2 = theShip;
			PopulateMagazines(ref theUnit2, ShipDBID);
			theUnit2 = theShip;
			PopulateAirFacilities(ref theUnit2, ShipDBID);
			theUnit2 = theShip;
			PopulateDockFacilities(ref theUnit2, ShipDBID);
			PopulateEyeballSensorIfNeeded(theScen, theShip);
		}
	}

	public static void GeDataShipFlags(ref Ship theShip, int ShipDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theShip.ParentScen.DBConnection);
		string_0 = "Select * from DataShipCodes where ID = " + Conversions.ToString(ShipDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i]["CodeID"]))
			{
			case 1011:
				theShip.Flags.PrairieMasker = true;
				continue;
			case 1012:
				theShip.Flags.AdvancedQuieting = true;
				continue;
			case 1013:
				theShip.Flags.WaterjetPropulsion = true;
				continue;
			case 1002:
				theShip.Flags.ShockResistant = true;
				continue;
			case 1001:
				theShip.Flags.AviationVessel = true;
				continue;
			case 2101:
				theShip.Flags.CanLaunchCargoDirectlyToSea = true;
				continue;
			case 2001:
				theShip.Flags.bool_0 = true;
				continue;
			case 4001:
				theShip.Flags.LowConstructionStandards = true;
				continue;
			case 4002:
				theShip.Flags.AllAluminumConstruction = true;
				continue;
			case 4003:
				theShip.Flags.AluminumSuperstructureOnly = true;
				continue;
			case 4006:
				theShip.Flags.WoodenHullConstruction = true;
				continue;
			case 4007:
				theShip.Flags.GRP_Construction = true;
				continue;
			case 4011:
				theShip.Flags.Hovercraft_SES = true;
				continue;
			case 4012:
				theShip.Flags.CatamaranTrimaranMultihull = true;
				continue;
			case 3001:
				theShip.Flags.PassiveOrSingleStabilizers = true;
				continue;
			case 3002:
				theShip.Flags.DualOrTripleStabilizers = true;
				continue;
			case 3003:
				theShip.Flags.AluminumConstruction = true;
				continue;
			case 3004:
				theShip.Flags.CivilianConstruction = true;
				continue;
			case 6001:
				theShip.Flags.MCM_DegaussedSteelHull = true;
				continue;
			case 6002:
				theShip.Flags.MCM_OnboardDegaussingGear = true;
				continue;
			case 6003:
				theShip.Flags.MCM_WoodenHull = true;
				continue;
			case 6004:
				theShip.Flags.MCM_GRPHull = true;
				continue;
			case 4022:
				theShip.Flags.BuiltToMercantileStandards = true;
				continue;
			case 4020:
				theShip.Flags.bool_1 = true;
				continue;
			case 8101:
				theShip.UNREP_Capabilities.Refuel_Port_In = 1;
				continue;
			case 8102:
				theShip.UNREP_Capabilities.Refuel_Port_In = 2;
				continue;
			case 8103:
				theShip.UNREP_Capabilities.Refuel_Port_In = 3;
				continue;
			case 8104:
				theShip.UNREP_Capabilities.Refuel_Port_In = 4;
				continue;
			case 8105:
				theShip.UNREP_Capabilities.Refuel_Port_In = 5;
				continue;
			case 8106:
				theShip.UNREP_Capabilities.Refuel_Starboard_In = 1;
				continue;
			case 8107:
				theShip.UNREP_Capabilities.Refuel_Starboard_In = 2;
				continue;
			case 8108:
				theShip.UNREP_Capabilities.Refuel_Starboard_In = 3;
				continue;
			case 8109:
				theShip.UNREP_Capabilities.Refuel_Starboard_In = 4;
				continue;
			case 8110:
				theShip.UNREP_Capabilities.Refuel_Starboard_In = 5;
				continue;
			case 8111:
				theShip.UNREP_Capabilities.Refuel_Astern_In = 1;
				continue;
			case 8112:
				theShip.UNREP_Capabilities.Refuel_Astern_In = 2;
				continue;
			case 8001:
				theShip.UNREP_Capabilities.Refuel_Port_Out = 1;
				continue;
			case 8002:
				theShip.UNREP_Capabilities.Refuel_Port_Out = 2;
				continue;
			case 8003:
				theShip.UNREP_Capabilities.Refuel_Port_Out = 3;
				continue;
			case 8004:
				theShip.UNREP_Capabilities.Refuel_Port_Out = 4;
				continue;
			case 8005:
				theShip.UNREP_Capabilities.Refuel_Starboard_Out = 1;
				continue;
			case 8006:
				theShip.UNREP_Capabilities.Refuel_Starboard_Out = 2;
				continue;
			case 8007:
				theShip.UNREP_Capabilities.Refuel_Starboard_Out = 3;
				continue;
			case 8008:
				theShip.UNREP_Capabilities.Refuel_Starboard_Out = 4;
				continue;
			case 8011:
				theShip.UNREP_Capabilities.Refuel_Astern_Out = 1;
				continue;
			case 8012:
				theShip.UNREP_Capabilities.Refuel_Astern_Out = 2;
				continue;
			case 9101:
				theShip.UNREP_Capabilities.Replenish_Port_In = 1;
				continue;
			case 9102:
				theShip.UNREP_Capabilities.Replenish_Port_In = 2;
				continue;
			case 9103:
				theShip.UNREP_Capabilities.Replenish_Port_In = 3;
				continue;
			case 9104:
				theShip.UNREP_Capabilities.Replenish_Port_In = 4;
				continue;
			case 9105:
				theShip.UNREP_Capabilities.Replenish_Starboard_In = 1;
				continue;
			case 9106:
				theShip.UNREP_Capabilities.Replenish_Starboard_In = 2;
				continue;
			case 9107:
				theShip.UNREP_Capabilities.Replenish_Starboard_In = 3;
				continue;
			case 9108:
				theShip.UNREP_Capabilities.Replenish_Starboard_In = 4;
				continue;
			case 9001:
				theShip.UNREP_Capabilities.Replenish_Port_Out = 1;
				continue;
			case 9002:
				theShip.UNREP_Capabilities.Replenish_Port_Out = 2;
				continue;
			case 9003:
				theShip.UNREP_Capabilities.Replenish_Port_Out = 3;
				continue;
			case 9004:
				theShip.UNREP_Capabilities.Replenish_Port_Out = 4;
				continue;
			case 9005:
				theShip.UNREP_Capabilities.Replenish_Starboard_Out = 1;
				continue;
			case 9006:
				theShip.UNREP_Capabilities.Replenish_Starboard_Out = 2;
				continue;
			case 9007:
				theShip.UNREP_Capabilities.Replenish_Starboard_Out = 3;
				continue;
			case 9008:
				theShip.UNREP_Capabilities.Replenish_Starboard_Out = 4;
				continue;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal static (string Description, string Example, string Architecture, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) GetSubmarineCombatSystemOODAValues(ref Scenario theScen, int CSGenID, bool CheckIfTableExists)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		(string, string, string, short, short, short) result;
		if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumSubmarineCSGen"))
		{
			result = (string.Empty, string.Empty, string.Empty, 0, 0, 0);
		}
		else
		{
			string_0 = "Select * from EnumSubmarineCSGen where ID = " + Conversions.ToString(CSGenID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			DataRow dataRow = datatable.Rows[0];
			short item = 0;
			short item2 = 0;
			short item3 = 0;
			string item4 = string.Empty;
			string item5 = string.Empty;
			string item6 = string.Empty;
			if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
			{
				item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
			{
				item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
			{
				item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
			{
				item5 = Conversions.ToString(dataRow["Description"]);
			}
			if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
			{
				item4 = Conversions.ToString(dataRow["Example"]);
			}
			if (datatable.Columns.Contains("Architecture") && dataRow["Architecture"].ToString().Length > 0)
			{
				item6 = Conversions.ToString(dataRow["Architecture"]);
			}
			result = (item5, item4, item6, item, item2, item3);
		}
		return result;
	}

	public static void GetSubmarine(ref Scenario theScen, ref Submarine theSub, int SubDBID, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataSubmarine where ID = " + Conversions.ToString(SubDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count != 0)
		{
			DataRow dataRow = datatable.Rows[0];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				theSub.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, string, short, short, short) submarineCombatSystemOODAValues = GetSubmarineCombatSystemOODAValues(ref theScen, theSub.CombatSystemGen, CheckIfTableExists: false);
				theSub.OODA_Detection = submarineCombatSystemOODAValues.Item4;
				theSub.OODA_Targeting = submarineCombatSystemOODAValues.Item5;
				theSub.OODA_Evasion = submarineCombatSystemOODAValues.Item6;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
				}
				theSub.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				theSub.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				theSub.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			theSub.Category = (Submarine._SubmarineCategory)Conversions.ToInteger(dataRow["Category"]);
			theSub.Type = (Submarine._SubmarineType)Conversions.ToInteger(dataRow["Type"]);
			theSub.DBID = SubDBID;
			theSub.UnitClass = Strings.Trim(dataRow["Name"].ToString());
			theSub.Length = Conversions.ToSingle(dataRow["Length"]);
			try
			{
				theSub.DockingPhysicalSize = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSizeCode"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				theSub.DockingPhysicalSize = GetDockingPhysicalSize(theSub.Length);
				ex2?.Data.Add("Error at 200074", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			theSub.EmptyWeight = (int)Math.Round(Conversions.ToDouble(dataRow["DisplacementStandard"].ToString()));
			theSub.Crew = Conversions.ToInteger(dataRow["Crew"]);
			theSub.MaxDepth = Conversions.ToInteger(dataRow["MaxDepth"]);
			theSub.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			((ActiveUnit)theSub).set_DamagePts(ScenEditAction: false, (Weapon)null, Conversions.ToSingle(dataRow["DamagePoints"]));
			((ActiveUnit_Kinematics)theSub.Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, 1f);
			theSub.Beam = Conversions.ToSingle(dataRow["Beam"]);
			theSub.Draft = Conversions.ToSingle(dataRow["Draft"]);
			theSub.Height = Conversions.ToSingle(dataRow["Height"]);
			if (datatable.Columns.Contains("DisplacementEmpty"))
			{
				theSub.Displacement_Empty = Conversions.ToSingle(dataRow["DisplacementEmpty"]);
			}
			if (datatable.Columns.Contains("DisplacementStandard"))
			{
				theSub.Displacement_Standard = Conversions.ToSingle(dataRow["DisplacementStandard"]);
			}
			if (datatable.Columns.Contains("DisplacementFull"))
			{
				theSub.Displacement_Full = Conversions.ToSingle(dataRow["DisplacementFull"]);
			}
			theSub.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			if (datatable.Columns.Contains("ROVRadius"))
			{
				theSub.ROVControlRadius_m = Conversions.ToShort(dataRow["ROVRadius"].ToString());
			}
			try
			{
				theSub.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (theSub.Crew == 0 && datatable.Columns.Contains("AutonomousControlLevel"))
			{
				try
				{
					theSub.AutonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(dataRow["AutonomousControlLevel"]);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					theSub.AutonomyLevel = ActiveUnit.DroneAutonomyLevel.SelfRecovering;
					ProjectData.ClearProjectError();
				}
			}
			if (datatable.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
					{
						theSub.Cargo_Crew = Conversions.ToSingle(dataRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
					{
						theSub.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
					{
						theSub.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
					{
						theSub.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
				}
			}
			GetSubmarineFlags(theSub, SubDBID);
			if (LoadComponents)
			{
				PopulateSensors(theSub, SubDBID);
				PopulateComms(theSub, SubDBID);
				ActiveUnit theUnit = theSub;
				PopulateMounts(ref theScen, ref theUnit, SubDBID);
				PopulatePropulsion(theSub, SubDBID);
				PopulateFuel(theSub, SubDBID);
				Platform theUnit2 = theSub;
				PopulateMagazines(ref theUnit2, SubDBID);
				theUnit2 = theSub;
				PopulateDockFacilities(ref theUnit2, SubDBID);
				PopulateEyeballSensorIfNeeded(theScen, theSub);
			}
			return;
		}
		throw new Exception("No submarine with ID: " + Conversions.ToString(SubDBID) + " was found in the current database!");
	}

	public static void GetSubmarineFlags(Submarine theSub, int SubDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theSub.ParentScen.DBConnection);
		string_0 = "Select * from DataSubmarineCodes where ID = " + Conversions.ToString(SubDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i]["CodeID"]))
			{
			case 2002:
				theSub.Flags.ShockResistant = true;
				continue;
			case 1001:
				theSub.Flags.AnechoicCoating = true;
				continue;
			case 1002:
				theSub.Flags.NonmagneticHull = true;
				continue;
			case 1003:
				theSub.Flags.NoLaunchTransient = true;
				continue;
			case 1004:
				theSub.Flags.ShroudedPropulsor = true;
				continue;
			case 1005:
				theSub.Flags.AdvancedPropulsor = true;
				continue;
			case 4001:
				theSub.Flags.LowConstructionStandards = true;
				continue;
			case 4002:
				theSub.Flags.NonmagneticHull = true;
				continue;
			case 4003:
				theSub.Flags.bool_0 = true;
				continue;
			case 2001:
			case 4004:
				theSub.Flags.DoubleHull = true;
				continue;
			case 3003:
				theSub.Flags.HasLateralThrusters = true;
				continue;
			case 9001:
				theSub.Flags.HasSnorkel = true;
				continue;
			case 5001:
				theSub.Flags.UsesLiOnBattery = true;
				continue;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) GetFacilityCombatSystemOODAValues(ref Scenario theScen, int CSGenID, bool CheckIfTableExists)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		(string, string, short, short, short) result;
		if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumFacilityCSGen"))
		{
			result = (string.Empty, string.Empty, 0, 0, 0);
		}
		else
		{
			string_0 = "Select * from EnumFacilityCSGen where ID = " + Conversions.ToString(CSGenID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			if (datatable.Rows.Count >= 1)
			{
				DataRow dataRow = datatable.Rows[0];
				short item = 0;
				short item2 = 0;
				short item3 = 0;
				string item4 = "";
				string item5 = "";
				if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
				{
					item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
				{
					item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
				{
					item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
				if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
				{
					item5 = Conversions.ToString(dataRow["Description"]);
				}
				if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
				{
					item4 = Conversions.ToString(dataRow["Example"]);
				}
				result = (item5, item4, item, item2, item3);
			}
			else
			{
				result = (CSGenID.ToString(), string.Empty, 0, 0, 0);
			}
		}
		return result;
	}

	public static void GetFacility(ref Scenario theScen, ref Facility theFac, int FacilityDBID, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataFacility where ID = " + Conversions.ToString(FacilityDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No facility with ID: " + Conversions.ToString(FacilityDBID) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				theFac.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) facilityCombatSystemOODAValues = GetFacilityCombatSystemOODAValues(ref theScen, theFac.CombatSystemGen, CheckIfTableExists: false);
				theFac.OODA_Detection = facilityCombatSystemOODAValues.Item3;
				theFac.OODA_Targeting = facilityCombatSystemOODAValues.Item4;
				theFac.OODA_Evasion = facilityCombatSystemOODAValues.Item5;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
				}
				theFac.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				theFac.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				theFac.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			if (theFac.Crew == 0 && datatable.Columns.Contains("AutonomousControlLevel"))
			{
				try
				{
					theFac.AutonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(dataRow["AutonomousControlLevel"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					theFac.AutonomyLevel = ActiveUnit.DroneAutonomyLevel.SelfRecovering;
					ProjectData.ClearProjectError();
				}
			}
			theFac.DBID = FacilityDBID;
			theFac.UnitClass = dataRow["Name"].ToString();
			theFac.Armor_General = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			theFac.MastHeight = Conversions.ToInteger(dataRow["MastHeight"]);
			theFac.MissileDefense = Conversions.ToInteger(dataRow["MissileDefense"]);
			theFac.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			((ActiveUnit)theFac).set_DamagePts(ScenEditAction: false, (Weapon)null, Conversions.ToSingle(dataRow["DamagePoints"]));
			theFac.Category = (Facility._FacilityCategory)Conversions.ToShort(dataRow["Category"]);
			theFac.Length = Conversions.ToSingle(dataRow["Length"]);
			theFac.Width = Conversions.ToSingle(dataRow["Width"]);
			theFac.Area = Conversions.ToDouble(dataRow["Area"]);
			theFac.HasAimpoints = Conversions.ToBoolean(dataRow["MountsAreAimpoints"]);
			theFac.AimpointDispersalRadius = Conversions.ToInteger(dataRow["Radius"]);
			theFac.Crew = Conversions.ToInteger(dataRow["Crew"]);
			theFac.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			try
			{
				theFac.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200476", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		if (LoadComponents)
		{
			PopulateSensors(theFac, FacilityDBID);
			PopulateComms(theFac, FacilityDBID);
			ActiveUnit theUnit = theFac;
			PopulateMounts(ref theScen, ref theUnit, FacilityDBID);
			PopulateFuel(theFac, FacilityDBID);
			Platform theUnit2 = theFac;
			PopulateMagazines(ref theUnit2, FacilityDBID);
			theUnit2 = theFac;
			PopulateAirFacilities(ref theUnit2, FacilityDBID);
			theUnit2 = theFac;
			PopulateDockFacilities(ref theUnit2, FacilityDBID);
			PopulateEyeballSensorIfNeeded(theScen, theFac);
		}
	}

	public static void PopulateEyeballSensorIfNeeded(Scenario theScen, ActiveUnit TheAU)
	{
		if (TheAU.IsEligibleForEyeball() && TheAU.Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.IsMk1Eyeball).Count() == 0)
		{
			Sensor eyeball = Sensor.GetEyeball(theScen.DBConnection);
			eyeball.Coverage.PB1 = true;
			eyeball.Coverage.PMA1 = true;
			eyeball.Coverage.PMF1 = true;
			eyeball.Coverage.PS1 = true;
			eyeball.Coverage.SB1 = true;
			eyeball.Coverage.SMA1 = true;
			eyeball.Coverage.SMF1 = true;
			eyeball.Coverage.SS1 = true;
			eyeball.Coverage.PB2 = true;
			eyeball.Coverage.PMA2 = true;
			eyeball.Coverage.PMF2 = true;
			eyeball.Coverage.PS2 = true;
			eyeball.Coverage.SB2 = true;
			eyeball.Coverage.SMA2 = true;
			eyeball.Coverage.SMF2 = true;
			eyeball.Coverage.SS2 = true;
			eyeball.ParentPlatform = TheAU;
			TheAU.AddSensor(eyeball);
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) GetGroundUnitCombatSystemOODAValues(ref Scenario theScen, int CSGenID, bool CheckIfTableExists)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		(string, string, short, short, short) result;
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "EnumGroundUnitCSGen"))
		{
			string_0 = "Select * from EnumGroundUnitCSGen where ID = " + Conversions.ToString(CSGenID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			if (datatable.Rows.Count >= 1)
			{
				DataRow dataRow = datatable.Rows[0];
				short item = 0;
				short item2 = 0;
				short item3 = 0;
				string item4 = "";
				string item5 = "";
				if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
				{
					item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
				{
					item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
				{
					item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
				if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
				{
					item5 = Conversions.ToString(dataRow["Description"]);
				}
				if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
				{
					item4 = Conversions.ToString(dataRow["Example"]);
				}
				result = (item5, item4, item, item2, item3);
			}
			else
			{
				result = (CSGenID.ToString(), string.Empty, 0, 0, 0);
			}
		}
		else
		{
			result = (string.Empty, string.Empty, 0, 0, 0);
		}
		return result;
	}

	public static void GetVehicle(ref Scenario theScen, ref Vehicle theVehicle, int int_0, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataGroundUnit where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No ground unit with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				theVehicle.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) groundUnitCombatSystemOODAValues = GetGroundUnitCombatSystemOODAValues(ref theScen, theVehicle.CombatSystemGen, CheckIfTableExists: false);
				theVehicle.OODA_Detection = groundUnitCombatSystemOODAValues.Item3;
				theVehicle.OODA_Targeting = groundUnitCombatSystemOODAValues.Item4;
				theVehicle.OODA_Evasion = groundUnitCombatSystemOODAValues.Item5;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
				}
				theVehicle.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				theVehicle.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				theVehicle.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			theVehicle.DBID = int_0;
			theVehicle.UnitClass = dataRow["Name"].ToString();
			theVehicle.Crew = Conversions.ToInteger(dataRow["Crew"].ToString());
			theVehicle.Mass = Conversions.ToSingle(dataRow["Mass"]);
			theVehicle.Armor_General = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			theVehicle.MastHeight = Conversions.ToInteger(dataRow["MastHeight"]);
			theVehicle.MissileDefense = Conversions.ToInteger(dataRow["MissileDefense"]);
			theVehicle.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			((ActiveUnit)theVehicle).set_DamagePts(ScenEditAction: false, (Weapon)null, Conversions.ToSingle(dataRow["DamagePoints"]));
			theVehicle.MobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(dataRow["Category"]);
			theVehicle.Length = Conversions.ToSingle(dataRow["Length"]);
			theVehicle.Width = Conversions.ToSingle(dataRow["Width"]);
			theVehicle.Area = Conversions.ToDouble(dataRow["Area"]);
			theVehicle.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			theVehicle.MaxSeaState = Conversions.ToInteger(dataRow["MaxSeaState"].ToString());
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Type"])))
			{
				theVehicle.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Self_Cargo_Type"]);
			}
			else
			{
				theVehicle.Cargo_Type = GetCargoTypeCategory(theVehicle.Width);
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Area"])))
			{
				theVehicle.Cargo_Area = (float)theVehicle.Area;
			}
			else
			{
				theVehicle.Cargo_Area = Conversions.ToSingle(dataRow["Self_Cargo_Area"]);
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Crew"])))
			{
				theVehicle.Cargo_Crew = theVehicle.Crew;
			}
			else
			{
				theVehicle.Cargo_Crew = Conversions.ToInteger(dataRow["Self_Cargo_Crew"]);
				if (theVehicle.Cargo_Crew == 0 && theVehicle.Cargo_Type == CargoType.Personnel && theVehicle.Crew > 0)
				{
					theVehicle.Cargo_Crew = theVehicle.Crew;
				}
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Mass"])))
			{
				theVehicle.Cargo_Mass = Conversions.ToSingle(dataRow["Self_Cargo_Mass"]);
			}
			else
			{
				theVehicle.Cargo_Mass = theVehicle.Mass;
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_ParadropCapable"])))
			{
				theVehicle.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Self_Cargo_ParadropCapable"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Type"])))
			{
				theVehicle.Cargo_Capacity_Type = (CargoType)Conversions.ToInteger(dataRow["Carry_Cargo_Type"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Area"])))
			{
				theVehicle.Cargo_Capacity_Area = Conversions.ToSingle(dataRow["Carry_Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Crew"])))
			{
				theVehicle.Cargo_Capacity_Crew = Conversions.ToInteger(dataRow["Carry_Cargo_Crew"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Mass"])))
			{
				theVehicle.Cargo_Capacity_Mass = Conversions.ToSingle(dataRow["Carry_Cargo_Mass"]);
			}
			if (datatable.Columns.Contains("Tow_Mass") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Tow_Mass"])))
			{
				theVehicle.Cargo_Capacity_Towing = Conversions.ToSingle(dataRow["Tow_Mass"]);
			}
			if (theVehicle.Crew == 0 && datatable.Columns.Contains("AutonomousControlLevel"))
			{
				try
				{
					theVehicle.AutonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(dataRow["AutonomousControlLevel"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					theVehicle.AutonomyLevel = ActiveUnit.DroneAutonomyLevel.SelfRecovering;
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				theVehicle.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200476", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		GetVehicleFlags(ref theVehicle, int_0);
		if (LoadComponents)
		{
			PopulateSensors(theVehicle, int_0);
			PopulateComms(theVehicle, int_0);
			ActiveUnit theUnit = theVehicle;
			PopulateMounts(ref theScen, ref theUnit, int_0);
			PopulatePropulsion(theVehicle, int_0);
			PopulateFuel(theVehicle, int_0);
			Platform theUnit2 = theVehicle;
			PopulateMagazines(ref theUnit2, int_0);
			theUnit2 = theVehicle;
			PopulateAirFacilities(ref theUnit2, int_0);
			theUnit2 = theVehicle;
			PopulateDockFacilities(ref theUnit2, int_0);
			PopulateEyeballSensorIfNeeded(theScen, theVehicle);
		}
	}

	public static bool IsSeaworthyAmphibiousVehicle(Scenario theScen, int int_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataGroundUnitCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (Conversions.ToInteger(datatable.Rows[i]["CodeID"]) == 2001)
			{
				string_0 = "Select distinct DataPropulsionPerformance.AltitudeBand from DataPropulsionPerformance left join DataGroundUnitPropulsion on DataPropulsionPerformance.ID = DataGroundUnitPropulsion.ComponentID left join DataGroundUnit on DataGroundUnitPropulsion.ID = DataGroundUnit.ID where DataGroundUnit.ID = " + Conversions.ToString(int_0);
				if (DBCache.GetDatatable(theHelper, string_0).Rows.Count > 1)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void GetVehicleFlags(ref Vehicle theVehicle, int int_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theVehicle.ParentScen.DBConnection);
		string_0 = "Select * from DataGroundUnitCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int num2 = Conversions.ToInteger(datatable.Rows[i]["CodeID"]);
			switch (num2)
			{
			case 4001:
				theVehicle.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4002:
				theVehicle.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4003:
				theVehicle.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4004:
				theVehicle.TractionMode = (Vehicle.TractionType)num2;
				break;
			default:
				_ = Debugger.IsAttached;
				break;
			case 2001:
				theVehicle.IsAmphibious = true;
				break;
			case 1001:
			case 1002:
			case 3002:
			case 3003:
				break;
			}
		}
	}

	public static int GetVehicleType_Int(ref Scenario theScen, int theDBID)
	{
		string_0 = "Select Category from DataGroundUnit where ID = " + Conversions.ToString(theDBID);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(theScen.DBConnection), string_0));
	}

	public static string GetVehicleName(int theDBID, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Name from DataGroundUnit where ID='" + Conversions.ToString(theDBID) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static CargoType GetVehicleCargoType(int theDBID, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		int result2;
		if (!CheckColumnExists_SQLite("DataGroundUnit", "Self_Cargo_Type", theConn))
		{
			if (float.TryParse(DBCache.GetScalar(theHelper, "SELECT Width from DataGroundUnit where ID='" + Conversions.ToString(theDBID) + "'"), out var result))
			{
				if (result < 1f)
				{
					return CargoType.Personnel;
				}
				if (result < 5f)
				{
					return CargoType.SmallCargo;
				}
				if (result < 7f)
				{
					return CargoType.MediumCargo;
				}
				if (result < 9f)
				{
					return CargoType.LargeCargo;
				}
				return CargoType.const_5;
			}
			result2 = 0;
		}
		else
		{
			if (int.TryParse(DBCache.GetScalar(theHelper, "SELECT Self_Cargo_Type from DataGroundUnit where ID='" + Conversions.ToString(theDBID) + "'"), out var result3))
			{
				return (CargoType)result3;
			}
			result2 = 0;
		}
		return (CargoType)result2;
	}

	public static void GetPersonnelCargoValues(Scenario theScen, ref float mass, ref float area)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		mass = 0.1f;
		area = 0.16f;
		if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			return;
		}
		string_0 = "Select * from DataGroundUnit where Category = 1000";
		DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
		if (datatable.Rows.Count != 0)
		{
			DataRow dataRow = datatable.Rows[0];
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Area"])))
			{
				area = Conversions.ToSingle(dataRow["Self_Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Mass"])))
			{
				mass = Conversions.ToSingle(dataRow["Self_Cargo_Mass"]);
			}
		}
	}

	public static Weapon._WeaponType GetWeaponType(int weaponID, Scenario theScen)
	{
		SQLiteHelper sQLiteHelper = default(SQLiteHelper);
		if (theScen.Cache_WeaponTypes == null)
		{
			string_0 = "SELECT MAX(ID) FROM DataWeapon";
			sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
			int maxKey = Conversions.ToInteger(DBCache.GetScalar(sQLiteHelper, string_0));
			theScen.Cache_WeaponTypes = new ConcurrentPagedArray<Weapon._WeaponType>(maxKey);
		}
		short num = (short)theScen.Cache_WeaponTypes[weaponID];
		if (num != 0)
		{
			return (Weapon._WeaponType)num;
		}
		if (sQLiteHelper == null)
		{
			sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		}
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		utf16ValueStringBuilder.Append("SELECT Type from DataWeapon where ID = ");
		utf16ValueStringBuilder.Append(weaponID);
		string_0 = utf16ValueStringBuilder.ToString();
		Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToInteger(DBCache.GetScalar(sQLiteHelper, string_0));
		if (weaponType == Weapon._WeaponType.GuidedWeapon)
		{
			utf16ValueStringBuilder.Clear();
			utf16ValueStringBuilder.Append("SELECT COUNT(*) from DataWeaponCodes where ID = ");
			utf16ValueStringBuilder.Append(weaponID);
			utf16ValueStringBuilder.Append(" AND (CodeID = 4010 OR CodeID = 4008)");
			string_0 = utf16ValueStringBuilder.ToString();
			if (Conversions.ToInteger(DBCache.GetScalar(sQLiteHelper, string_0)) > 0)
			{
				weaponType = Weapon._WeaponType.BallisticMissile;
			}
		}
		theScen.Cache_WeaponTypes[weaponID] = weaponType;
		return weaponType;
	}

	public static WeaponRec GetWeaponRec(int WeaponRecID, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(WeaponRecID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count != 0)
		{
			DataRow dataRow = datatable.Rows[0];
			return new WeaponRec(ExcludeOptionalWeapons: datatable.Columns.Contains("Optional") && Conversions.ToBoolean(dataRow["Optional"]), AircraftInternalWeapons: datatable.Columns.Contains("Internal") && Conversions.ToBoolean(dataRow["Internal"]), theScen: ref theScen, theWeaponDBID: Conversions.ToInteger(dataRow["ComponentID"]), theDefaultLoad: Conversions.ToInteger(dataRow["DefaultLoad"]), theMaxLoad: Conversions.ToInteger(dataRow["MaxLoad"]), theROF: Conversions.ToInteger(dataRow["ROF"]), theMultiple: Conversions.ToInteger(dataRow["Multiple"]));
		}
		throw new PlatformComponentNotFoundException();
	}

	public static bool CheckWeaponIsInAircraftLoadouts(SQLiteConnection theConn, int WeaponID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string_0 = "SELECT Count(*) from DataLoadout, DataLoadoutWeapons, DataWeaponRecord where DataLoadoutWeapons.ID = DataLoadout.ID AND DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID and DataWeaponRecord.ComponentID = " + Conversions.ToString(WeaponID);
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, string_0)) > 0;
	}

	public static void GetWeapon(SQLiteConnection theConn, Weapon theWeapon, int int_0, Scenario theScen, bool LoadComponents = true)
	{
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(theConn);
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("SELECT * from DataWeapon where ID = ").Append(int_0);
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			List<Struct15> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct15>(theHelper, string_0);
			if (orBuildCachedQueryResult.Count == 0)
			{
				theWeapon.DBID = -1;
				return;
			}
			Struct15 @struct = orBuildCachedQueryResult.First();
			theWeapon.SnapUpDown = (float)@struct.bWmyCixLoXO;
			string text = Strings.Trim(@struct.Name);
			theWeapon.DBID = int_0;
			theWeapon.UnitClass = text;
			theWeapon.Name = text;
			if ((object)theWeapon.GetType() == typeof(Weapon))
			{
				theWeapon.Type = (Weapon._WeaponType)@struct.Type;
			}
			theWeapon.TechGeneration = (GlobalVariables.TechGenerationClass)@struct.long_0;
			theWeapon.Length = (float)@struct.double_0;
			theWeapon.Span = (float)@struct.double_1;
			theWeapon.Diameter = (float)@struct.double_2;
			theWeapon.EmptyWeight = (int)Math.Round(@struct.double_3);
			theWeapon.MaxWeight = (int)Math.Round(@struct.double_3);
			theWeapon._BurnoutWeight_DB = (int)Math.Round(@struct.double_5);
			theWeapon.CEP_Surface_Nominal = (int)@struct.long_4;
			if (theWeapon.CEP_Surface_Nominal == 0)
			{
				theWeapon.CEP_Surface_Nominal = (int)@struct.long_3;
			}
			theWeapon.CEP_Surface = theWeapon.CEP_Surface_Nominal;
			theWeapon.CEP_Land_Nominal = (int)@struct.long_3;
			theWeapon.CEP_Land = theWeapon.CEP_Land_Nominal;
			theWeapon._TimeToDetonate = @struct.long_10;
			theWeapon.CanActAsSensor = @struct.bool_0;
			if (!theScen.FeatureCompatibility.get_WeaponAGL_ASL(theConn))
			{
				theWeapon.CruiseAltitude_ASL = (float)@struct.double_6;
			}
			else
			{
				theWeapon.CruiseAltitude_ASL = (float)@struct.double_7;
			}
			theWeapon.CruiseAltitude_AGL = (float)@struct.double_6;
			theWeapon.Waypoints = (int)@struct.long_1;
			theWeapon.IlluminationTime = (int)@struct.long_2;
			theWeapon.SurfPOK = (int)Math.Round(@struct.bkZyCtgdAdF);
			try
			{
				theWeapon.LandPOK = (int)Math.Round(@struct.double_9);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				theWeapon.LandPOK = 0;
				ProjectData.ClearProjectError();
			}
			theWeapon.SubPOK = (int)Math.Round(@struct.double_10);
			theWeapon.AirPOK = (int)Math.Round(@struct.double_8);
			((ActiveUnit_Kinematics)theWeapon.Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, (float)@struct.double_11);
			theWeapon.MaxLaunchSpeed = (int)@struct.long_5;
			theWeapon.MinLaunchSpeed = (int)@struct.long_6;
			theWeapon.MaxAirRange = (float)@struct.double_12;
			theWeapon.MinAirRange = (float)@struct.double_13;
			theWeapon.MaxSurfaceRange = (float)@struct.double_14;
			theWeapon.MinSurfaceRange = (float)@struct.double_15;
			theWeapon.MaxLandRange = (float)@struct.double_16;
			theWeapon.MinLandRange = (float)@struct.ycGyCdIgNid;
			theWeapon.MaxSubsurfaceRange = (float)@struct.double_17;
			theWeapon.MinSubsurfaceRange = (float)@struct.double_18;
			if (theWeapon.IsTorpedo)
			{
				((Torpedo)theWeapon).MaxKinematicRange_Full = (float)@struct.OiqyCwnjbxi;
				((Torpedo)theWeapon).MaxKinematicRange_Cruise = (float)@struct.double_27;
			}
			if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theConn))
			{
				theWeapon.MaxLaunchAlt_ASL = (float)Math.Round((float)@struct.double_21, 1);
				theWeapon.MinLaunchAlt_ASL = (float)Math.Round((float)@struct.double_22, 1);
				theWeapon.MaxTargetAlt_ASL = (float)Math.Round((float)@struct.double_25, 1);
				theWeapon.MinTargetAlt_ASL = (float)Math.Round((float)@struct.double_26, 1);
			}
			theWeapon.MaxLaunchAlt_AGL = (float)Math.Round((float)@struct.double_19, 1);
			theWeapon.MinLaunchAlt_AGL = (float)Math.Round((float)@struct.double_20, 1);
			theWeapon.MaxTargetAlt_AGL = (float)Math.Round((float)@struct.double_23, 1);
			theWeapon.MinTargetAlt_AGL = (float)Math.Round((float)@struct.double_24, 1);
			theWeapon.MaxTargetSpeed = (int)@struct.long_7;
			theWeapon.MinTargetSpeed = (int)@struct.long_8;
			theWeapon.InitialDP = 1;
			try
			{
				theWeapon.Hypothetical = @struct.bool_3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200477", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
			{
				theWeapon.CruiseAltitude_ASL = (float)@struct.double_7;
				theWeapon.MaxLaunchAlt_ASL = (float)Math.Round((float)@struct.double_21, 1);
				theWeapon.MinLaunchAlt_ASL = (float)Math.Round((float)@struct.double_22, 1);
				theWeapon.MaxTargetAlt_ASL = (float)Math.Round((float)@struct.double_25, 1);
				theWeapon.MinTargetAlt_ASL = (float)Math.Round((float)@struct.double_26, 1);
			}
			if (theWeapon.IsTorpedo && theWeapon.MaxSurfaceRange == 6f && theWeapon.MaxSubsurfaceRange == 6f)
			{
				theWeapon.MaxSurfaceRange = 8f;
				theWeapon.MaxSubsurfaceRange = 8f;
			}
			theWeapon.ValidTargets = new WeaponTargets(int_0, ref theConn);
			smethod_2(ref theWeapon, int_0);
			PopulateWeaponWeapons(ref theScen, ref theWeapon, int_0);
			PopulateWeaponFlags(ref theWeapon, ref theWeapon.Flags);
			if (!theWeapon.IsDLZconstruct)
			{
				Doctrine doctrine;
				ConcurrentPagedArray<Doctrine.WRA_Weapon> theWRA = (doctrine = theWeapon.Doctrine).WRA;
				PopulateWeaponWRA(ref theWeapon, ref theWRA);
				doctrine.WRA = theWRA;
			}
			if (LoadComponents)
			{
				smethod_1(ref theWeapon);
			}
			if ((LoadComponents || !theWeapon.IsWeaponPallet) && theWeapon.MaxSurfaceRange > 0f && theWeapon.MaxLandRange == 0f && (theWeapon.ValidTargets.AerostatMooring || theWeapon.ValidTargets.AirBaseSingleUnit || theWeapon.ValidTargets.LandStructure_Hard || theWeapon.ValidTargets.LandStructure_Soft || theWeapon.ValidTargets.Runway || theWeapon.ValidTargets.Radar || theWeapon.ValidTargets.MobileTarget_Hard || theWeapon.ValidTargets.MobileTarget_Soft || theWeapon.ValidTargets.UnderwaterStructure))
			{
				theWeapon.MaxLandRange = theWeapon.MaxSurfaceRange;
				theWeapon.MinLandRange = theWeapon.MinSurfaceRange;
				theWeapon.LandPOK = theWeapon.SurfPOK;
			}
			if (theWeapon.IsASuW_Naval && !theWeapon.IsTorpedo && !theWeapon.IsDecoy && !theWeapon.IsMine && theWeapon.Type != Weapon._WeaponType.Laser && theWeapon.Type != Weapon._WeaponType.Microwave && theWeapon.Type != Weapon._WeaponType.UAV_Expendable && theWeapon.Type != Weapon._WeaponType.LaserDazzler && theWeapon.CEP_Surface_Nominal == 0)
			{
				_ = Debugger.IsAttached;
			}
			if (theWeapon.IsBallisticMissile || theWeapon.IsReEntryVehicle)
			{
				theWeapon.Flags.BearingOnlyLaunch = true;
			}
			if (theWeapon.IsTorpedo && theWeapon.Sensors_Cached.Count() > 0)
			{
				theWeapon.Flags.ReAttack_Capability = true;
			}
			if (theWeapon.IsLongFlightCruiseMissile && theWeapon.CruiseAltitude_AGL > 0f && theWeapon.Fuel_ReadOnly.Count > 0)
			{
				theWeapon.Fuel_ReadOnly[0].MaxQuantity = (int)Math.Round((float)theWeapon.Fuel_ReadOnly[0].MaxQuantity * 1.2f);
				theWeapon.Fuel_ReadOnly[0].CurrentQuantity = theWeapon.Fuel_ReadOnly[0].MaxQuantity;
			}
			if (theScen.IsDBUsedDB3K && theWeapon.CruiseAltitude_ASL > 0f && theWeapon.CruiseAltitude_ASL < 200f && theWeapon.CruiseAltitude_AGL == 0f && @struct.string_0.Contains("Loitering Munition"))
			{
				theWeapon.CruiseAltitude_AGL = theWeapon.CruiseAltitude_ASL;
				theWeapon.CruiseAltitude_ASL = 0f;
				if (theWeapon.Propulsion.Count > 0)
				{
					theWeapon.Propulsion[0].AltBands.Last().MaxAlt = theWeapon.CruiseAltitude_AGL * 15f;
				}
			}
			Warhead[] warheads = theWeapon.Warheads;
			foreach (Warhead warhead in warheads)
			{
				if (warhead.DP == (float)theWeapon.DBID)
				{
					GameGeneral.WriteExceptionsToLog(new Exception("DB error for weapon #" + theWeapon.DBID + " , circular reference with carried weapon"));
					warhead.DP = -1f;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 200274", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_1(ref Weapon weapon_0)
	{
		int dBID = weapon_0.DBID;
		PopulatePropulsion(weapon_0, dBID);
		PopulateComms(weapon_0, dBID);
		PopulateSensors(weapon_0, dBID);
		PopulateFuel(weapon_0, dBID);
		PopulateWarheads(ref weapon_0.Warheads, ref weapon_0);
	}

	private static void smethod_2(ref Weapon weapon_0, int int_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID from DataSensor, DataWeaponDirectors as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ").Append(int_0);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "ID");
		int count = orBuildCachedSingleFieldQueryResult.Count;
		if (count > 0)
		{
			weapon_0.Directors = new List<int>(count);
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				weapon_0.Directors.Add((int)orBuildCachedSingleFieldQueryResult[i]);
			}
		}
	}

	public static void PopulateWeaponWeapons(ref Scenario theScen, ref Weapon theWeapon, int int_0)
	{
		if (theWeapon.ParentScen.FeatureCompatibility.get_LPI_Radars(theWeapon.ParentScen.DBConnection))
		{
			SQLiteHelper theHelper = new SQLiteHelper(theWeapon.ParentScen.DBConnection);
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("SELECT DataWeaponRecord.* FROM DataWeaponWeapons, DataWeaponRecord, DataWeapon WHERE DataWeaponWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataWeaponWeapons.ID = ").Append(int_0).Append(" ORDER BY DataWeapon.Type, DataWeapon.Name ASC");
			DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, GameGeneral.ThreadStaticSB.ToString());
			int num = datatableTyped.Rows.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				DtrRow dtrRow = datatableTyped.Rows[i];
				WeaponRec weaponRec = new WeaponRec(ref theScen, Conversions.ToInteger(dtrRow["ComponentID"]), Conversions.ToInteger(dtrRow["DefaultLoad"]), Conversions.ToInteger(dtrRow["MaxLoad"]), Conversions.ToInteger(dtrRow["ROF"]), Conversions.ToInteger(dtrRow["Multiple"]), ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
				weaponRec.WRecDBID = Conversions.ToInteger(dtrRow["ID"]);
				theWeapon.WeaponWeapons.Add(weaponRec);
			}
		}
	}

	private static void smethod_3(Scenario scenario_0, ref Mount mount_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(scenario_0.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID from DataSensor, DataMountDirectors as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ").Append(mount_0.DBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, string_0);
		int num = datatableTyped.Rows.Count();
		mount_0.CompatibleDirectors.Clear();
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			mount_0.CompatibleDirectors.Add(Conversions.ToInteger(dtrRow["ID"]));
		}
	}

	public static void PopulateWeaponFlags(ref Weapon theWeapon, ref Weapon.WeaponFlags theFlags)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theWeapon.ParentScen.DBConnection);
		string_0 = "SELECT CodeID from DataWeaponCodes where ID = " + Conversions.ToString(theWeapon.DBID);
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "CodeID");
		theFlags.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic;
		int num = orBuildCachedSingleFieldQueryResult.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = orBuildCachedSingleFieldQueryResult[i];
			if (num2 <= 6301L)
			{
				if (num2 <= 6001L)
				{
					if (num2 <= 2025L)
					{
						if (num2 > 1101L)
						{
							long num3 = num2 - 2001L;
							if ((ulong)num3 <= 11uL)
							{
								switch (num3)
								{
								case 0L:
									theFlags.SternChase_AAM = true;
									continue;
								case 1L:
									theFlags.RearAspect_AAM = true;
									continue;
								case 2L:
									theFlags.AllAspect_AAM = true;
									continue;
								case 3L:
									theFlags.HOB_AAM = true;
									continue;
								case 4L:
									theFlags.NoDivingTargetMod = true;
									continue;
								case 5L:
									theFlags.CapableVsSeaskimmer = true;
									continue;
								case 8L:
									theFlags.C_RAM = true;
									continue;
								case 9L:
									theFlags.LOAL_CEC = true;
									continue;
								case 10L:
									theFlags.TerrainFollowing = true;
									continue;
								case 11L:
									theFlags.LOAL = true;
									continue;
								case 6L:
								case 7L:
									continue;
								}
							}
							if (num2 == 2025L)
							{
								theFlags.LauncherOccupiedDuringGuidance = true;
							}
							continue;
						}
						long num4 = num2 - 1001L;
						if ((ulong)num4 <= 2uL)
						{
							switch (num4)
							{
							case 0L:
								theFlags.IlluminateAtLaunch = true;
								continue;
							case 1L:
								theFlags.TerminalIllumination = true;
								continue;
							case 2L:
								theFlags.SupportsBuddyIllumination = true;
								continue;
							}
						}
						if (num2 == 1101L)
						{
							theFlags.HomeOnJam = true;
						}
						continue;
					}
					if (num2 > 4003L)
					{
						long num5 = num2 - 4008L;
						if ((ulong)num5 <= 4uL)
						{
							switch (num5)
							{
							case 0L:
								theFlags.DepressedBallisticTrajectory = true;
								continue;
							case 2L:
								theFlags.IsBallisticMissile = true;
								continue;
							case 4L:
								theFlags.IsMultiStageMissile = true;
								continue;
							case 1L:
							case 3L:
								continue;
							}
						}
						if (num2 == 6001L)
						{
							theFlags.Pod_TerrainAvoidance = true;
						}
						continue;
					}
					long num6 = num2 - 3001L;
					if ((ulong)num6 <= 3uL)
					{
						switch (num6)
						{
						case 0L:
							theFlags.ARMTargetMemory = true;
							continue;
						case 2L:
							theFlags.LoiterCapability = true;
							continue;
						case 3L:
							theFlags.ParachuteLoiter = true;
							continue;
						case 1L:
							continue;
						}
					}
					long num7 = num2 - 4001L;
					if ((ulong)num7 <= 2uL)
					{
						switch (num7)
						{
						case 0L:
							theFlags.SearchPattern = true;
							break;
						case 1L:
							theFlags.DriveThroughLogic = true;
							break;
						case 2L:
							theFlags.BearingOnlyLaunch = true;
							break;
						}
					}
				}
				else if (num2 > 6022L)
				{
					if (num2 <= 6111L)
					{
						long num8 = num2 - 6101L;
						if ((ulong)num8 <= 2uL)
						{
							switch (num8)
							{
							case 0L:
								theFlags.Navigation_INS = true;
								continue;
							case 1L:
								theFlags.Navigation_INS_GPS = true;
								continue;
							case 2L:
								theFlags.Navigation_TERCOM = true;
								continue;
							}
						}
						if (num2 == 6111L)
						{
							theFlags.PreBriefedTargetOnly = true;
						}
						continue;
					}
					long num9 = num2 - 6121L;
					if ((ulong)num9 <= 22uL)
					{
						switch (num9)
						{
						case 0L:
							theFlags.TerminalManeuver_PopUp = true;
							continue;
						case 1L:
							theFlags.TerminalManeuver_ZigZag = true;
							continue;
						case 2L:
							theFlags.TerminalManeuver_Random = true;
							continue;
						case 8L:
							theFlags.ReAttack_Capability = true;
							continue;
						case 9L:
							theFlags.Navigation_AltitudeControl = true;
							continue;
						case 10L:
							theFlags.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic;
							continue;
						case 11L:
							theFlags.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.NonAerodynamic;
							continue;
						case 12L:
							theFlags.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Combined;
							continue;
						case 19L:
							theFlags.Navigation_GPS = true;
							continue;
						case 20L:
							theFlags.Navigation_GLONASS = true;
							continue;
						case 21L:
							theFlags.Navigation_Beidou = true;
							continue;
						case 22L:
							theFlags.Navigation_NavIC = true;
							continue;
						case 3L:
						case 4L:
						case 5L:
						case 6L:
						case 7L:
						case 13L:
						case 14L:
						case 15L:
						case 16L:
						case 17L:
						case 18L:
							continue;
						}
					}
					switch (num2)
					{
					case 6301L:
						theFlags.Mine_ContactFuze = true;
						break;
					case 6201L:
						theFlags.UsesImagingSeeker = true;
						break;
					}
				}
				else if (num2 <= 6012L)
				{
					if (num2 != 6002L)
					{
						long num10 = num2 - 6009L;
						if ((ulong)num10 <= 3uL)
						{
							switch (num10)
							{
							case 0L:
								theFlags.Pod_DayOnlyNavigation = true;
								break;
							case 1L:
								theFlags.Pod_DayOnlyNavigationAttack = true;
								break;
							case 2L:
								theFlags.Pod_NightNavigation = true;
								break;
							case 3L:
								theFlags.Pod_NightNavigationAttack = true;
								break;
							}
						}
					}
					else
					{
						theFlags.Pod_TerrainFollowing = true;
					}
				}
				else
				{
					switch (num2)
					{
					case 6022L:
						theFlags.Pod_ReconNight = true;
						break;
					case 6021L:
						theFlags.Pod_ReconDayOnly = true;
						break;
					}
				}
			}
			else if (num2 > 6501L)
			{
				if (num2 > 7110L)
				{
					if (num2 <= 8001L)
					{
						switch (num2)
						{
						case 8001L:
							theFlags.CapableVsMobileTarget = true;
							break;
						case 7111L:
							theFlags.Fuze_ShockFactor_Under_Keel_Optimized = true;
							break;
						}
					}
					else if (num2 != 8002L)
					{
						long num11 = num2 - 9001L;
						if ((ulong)num11 <= 3uL)
						{
							switch (num11)
							{
							case 0L:
								theFlags.Torpedo_StraightRunning = true;
								continue;
							case 1L:
								theFlags.Torpedo_WakeHoming = true;
								continue;
							case 2L:
								theFlags.Torpedo_StraightRunningTimeDetonation = true;
								continue;
							case 3L:
								theFlags.Torpedo_PatternRunning = true;
								continue;
							}
						}
						if (num2 == 9999L)
						{
							theFlags.LevelCruiseFlight = true;
						}
					}
					else
					{
						theFlags.IsRetardedWeapon = true;
					}
				}
				else if (num2 > 7003L)
				{
					long num12 = num2 - 7101L;
					if ((ulong)num12 <= 2uL)
					{
						switch (num12)
						{
						case 0L:
							theFlags.Fuze_Impact = true;
							continue;
						case 1L:
							theFlags.Fuze_Barometric_Altimeter = true;
							continue;
						case 2L:
							theFlags.Fuze_Proximity = true;
							continue;
						}
					}
					if (num2 == 7110L)
					{
						theFlags.Fuze_Combination = true;
					}
				}
				else if (num2 != 6511L)
				{
					long num13 = num2 - 7001L;
					if ((ulong)num13 <= 2uL)
					{
						switch (num13)
						{
						case 0L:
							theFlags.Warhead_SingleRV = true;
							break;
						case 1L:
							theFlags.Warhead_MRV = true;
							break;
						case 2L:
							theFlags.Warhead_MIRV = true;
							break;
						}
					}
				}
				else
				{
					theFlags.Mine_RemoteControlled = true;
				}
			}
			else
			{
				switch (num2)
				{
				case 6341L:
					theFlags.Mine_SeismicFuze = true;
					break;
				case 6331L:
					theFlags.Mine_PressureFuze = true;
					break;
				case 6501L:
					theFlags.Mine_TargetDiscriminationAndIdentification = true;
					break;
				case 6402L:
					theFlags.Mine_ArmingDelay = true;
					break;
				case 6401L:
					theFlags.Mine_DelayCounter = true;
					break;
				case 6322L:
					theFlags.Mine_PassiveNarrowBandAcousticFuze = true;
					break;
				case 6321L:
					theFlags.Mine_PassiveBroadBandAcousticFuze = true;
					break;
				case 6312L:
					theFlags.Mine_TotalFieldMagnetometerFuze = true;
					break;
				case 6311L:
					theFlags.Mine_SimpleMagneticFuze = true;
					break;
				}
			}
		}
	}

	public static void PopulateWeaponWRA(ref Weapon theWeapon, ref ConcurrentPagedArray<Doctrine.WRA_Weapon> theWRA)
	{
		try
		{
			if (!theWeapon.Doctrine.WRA_RelevantWeapon(ref theWeapon))
			{
				return;
			}
			if (theWRA == null)
			{
				theWRA = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
			}
			if (!theWRA.ContainsKey(theWeapon.DBID))
			{
				theWRA[theWeapon.DBID] = new Doctrine.WRA_Weapon();
			}
			if (theWeapon.ParentScen.FeatureCompatibility.get_WRA(theWeapon.ParentScen.DBConnection))
			{
				GameGeneral.InitThreadStaticSB();
				GameGeneral.ThreadStaticSB.Append("SELECT * from DataWeaponWRA where ID = ").Append(theWeapon.DBID);
				SQLiteHelper theHelper = new SQLiteHelper(theWeapon.ParentScen.DBConnection);
				object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(theHelper, GameGeneral.ThreadStaticSB.ToString()));
				List<(int, int, int, int, int)> list;
				if (objectValue != null)
				{
					list = (List<(int, int, int, int, int)>)objectValue;
				}
				else
				{
					DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, GameGeneral.ThreadStaticSB.ToString(), StoreToCache: false);
					int num = datatableTyped.Rows.Count();
					list = new List<(int, int, int, int, int)>(datatableTyped.Rows.Count());
					if (num > 0)
					{
						int num2 = num - 1;
						(int, int, int, int, int) item = default((int, int, int, int, int));
						for (int i = 0; i <= num2; i++)
						{
							DtrRow dtrRow = datatableTyped.Rows[i];
							item.Item1 = theWeapon.DBID;
							item.Item2 = Conversions.ToInteger(dtrRow["CodeID"]);
							item.Item3 = Conversions.ToInteger(dtrRow["WeaponQty"]);
							item.Item4 = Conversions.ToInteger(dtrRow["ShooterQty"]);
							item.Item5 = Conversions.ToInteger(dtrRow["SelfDefenceRange"]);
							list.Add(item);
						}
						DBCache.SetCustomObject(theHelper, GameGeneral.ThreadStaticSB.ToString(), list);
					}
				}
				List<Doctrine._WRA_WeaponTargetType> topNodeWeaponTargetTypes = Doctrine.TopNodeWeaponTargetTypes;
				foreach (var item3 in list)
				{
					Doctrine._WRA_WeaponTargetType item2 = (Doctrine._WRA_WeaponTargetType)item3.Item2;
					Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new Doctrine.WRA_FiringDoctrineEntry(item2);
					wRA_FiringDoctrineEntry.WeaponQty = item3.Item3;
					wRA_FiringDoctrineEntry.ShooterQty = item3.Item4;
					wRA_FiringDoctrineEntry.SelfDefenceRange = item3.Item5;
					theWRA[theWeapon.DBID].AddTo_WRAWeaponTargets(wRA_FiringDoctrineEntry);
					if (topNodeWeaponTargetTypes.Contains(item2))
					{
						topNodeWeaponTargetTypes.Remove(item2);
					}
				}
				{
					foreach (Doctrine._WRA_WeaponTargetType item4 in topNodeWeaponTargetTypes)
					{
						Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 = new Doctrine.WRA_FiringDoctrineEntry(item4);
						wRA_FiringDoctrineEntry2.WeaponQty = 0;
						wRA_FiringDoctrineEntry2.ShooterQty = -99;
						wRA_FiringDoctrineEntry2.SelfDefenceRange = 0f;
						theWRA[theWeapon.DBID].AddTo_WRAWeaponTargets(wRA_FiringDoctrineEntry2);
					}
					return;
				}
			}
			theWRA[theWeapon.DBID].WRA_Skeleton(ref theWeapon);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 3290485734259874359", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool smethod_4(ref SQLiteConnection sqliteConnection_0, int dbid, ref CargoAmmunition CargoData)
	{
		if (CheckColumnExists_SQLite("DataWeapon", "Cargo_Area", sqliteConnection_0))
		{
			SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
			string theQuery = "SELECT Name, Cargo_Type, Cargo_Mass, Cargo_Area, Cargo_Volume, Cargo_Crew, Cargo_ParadropCapable FROM DataWeapon WHERE id=" + dbid;
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			if (datatable.Rows.Count > 0)
			{
				DataRow dataRow = datatable.Rows[0];
				CargoData.Name = Conversions.ToString(dataRow["Name"]);
				CargoData.Size = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"]);
				CargoData.Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
				object objectValue = RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"]);
				if (objectValue is DBNull)
				{
					CargoData.Area = 0f;
				}
				else
				{
					CargoData.Area = Conversions.ToSingle(objectValue);
				}
				CargoData.Volume = Conversions.ToSingle(dataRow["Cargo_Volume"]);
				CargoData.Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool GetWeaponCargoData(ref SQLiteConnection sqliteConnection_0, int dbid, ref CargoAmmunition CargoData)
	{
		int result;
		if (sqliteConnection_0 == null)
		{
			result = 0;
		}
		else
		{
			if (CargoData != null)
			{
				if (!smethod_4(ref sqliteConnection_0, dbid, ref CargoData))
				{
					SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
					string theQuery = "SELECT Name, Length, Span, Diameter, Weight FROM DataWeapon WHERE id=" + dbid;
					DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
					if (datatable.Rows.Count > 0)
					{
						DataRow dataRow = datatable.Rows[0];
						float length = Conversions.ToSingle(dataRow["Length"]);
						float width = Conversions.ToSingle(dataRow["Span"]);
						float num = Conversions.ToSingle(dataRow["Diameter"]);
						float mass = Conversions.ToSingle(dataRow["Weight"]);
						if (num == 0f && width > 0f)
						{
							num = width;
						}
						else if (width == 0f && num > 0f)
						{
							width = num;
						}
						float height = num * 1.1f;
						if (width > num)
						{
							height = width * 0.95f;
						}
						CargoData.Name = Conversions.ToString(dataRow["Name"]);
						CargoData.Crew = 0f;
						int result2;
						if (length != 0f && width != 0f && mass != 0f)
						{
							CargoData.Area = length * height;
							CargoData.Height = height;
							CargoData.Volume = CargoData.Area * CargoData.Height;
							CargoData.Size = GetCargoTypeCategory(length, height, height);
							CargoData.Mass = mass / 1000f;
							result2 = 1;
						}
						else if (!EstimateCargoWeaponData(ref sqliteConnection_0, dbid, ref length, ref width, ref height, ref mass))
						{
							CargoData.Size = CargoType.NoCargo;
							result2 = 1;
						}
						else
						{
							CargoData.Area = length * width;
							CargoData.Height = height;
							CargoData.Volume = CargoData.Area * CargoData.Height;
							CargoData.Size = GetCargoTypeCategory(length, width, height);
							CargoData.Mass = mass;
							result2 = 1;
						}
						return (byte)result2 != 0;
					}
					return false;
				}
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool EstimateCargoWeaponData(ref SQLiteConnection sqliteConnection_0, int dbid, ref float length, ref float width, ref float height, ref float mass)
	{
		if (sqliteConnection_0 != null)
		{
			SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
			string_0 = "SELECT DataWeapon.ID AS ID, DataWarhead.ProjectileCaliber AS Caliber FROM DataWeapon LEFT JOIN DataWeaponWarheads ON DataWeapon.ID = DataWeaponWarheads.ID LEFT JOIN DataWarhead ON DataWeaponWarheads.ComponentID = DataWarhead.ID WHERE DataWeapon.ID = " + Conversions.ToString(dbid);
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			if (datatable.Rows.Count > 0)
			{
				DataRow dataRow = datatable.Rows[0];
				int num = 2007;
				object objectValue = RuntimeHelpers.GetObjectValue(dataRow["Caliber"]);
				if (!(objectValue is int) && !(objectValue is long))
				{
					length = 1f;
					width = 1f;
					height = 1f;
					mass = 0.1f;
					return true;
				}
				int result;
				switch (Conversions.ToInteger(objectValue))
				{
				default:
					return false;
				case 2001:
				case 3001:
					length = 0.26f;
					width = 0.1f;
					height = 0.16f;
					mass = 0.03f;
					result = 1;
					break;
				case 2002:
				case 3002:
					length = 0.43f;
					width = 0.19f;
					height = 0.36f;
					mass = 0.04f;
					result = 1;
					break;
				case 2003:
				case 3003:
					length = 0.1f;
					width = 0.05f;
					height = 0.16f;
					mass = 0.003f;
					result = 1;
					break;
				case 2004:
				case 3004:
					length = 0.12f;
					width = 0.05f;
					height = 0.2f;
					mass = 0.005f;
					result = 1;
					break;
				case 2005:
				case 3005:
					length = 0.34f;
					width = 0.13f;
					height = 0.08f;
					mass = 0.03f;
					result = 1;
					break;
				case 2006:
				case 3006:
					length = 0.6f;
					width = 0.16f;
					height = 0.16f;
					mass = 0.05f;
					result = 1;
					break;
				case 2007:
				case 3007:
					length = 0.8f;
					width = 0.21f;
					height = 0.21f;
					mass = 0.12f;
					result = 1;
					break;
				case 2008:
				case 3008:
					length = 3.2f;
					width = 0.41f;
					height = 0.41f;
					mass = 0.9f;
					result = 1;
					break;
				}
				return (byte)result != 0;
			}
			return false;
		}
		return false;
	}

	public static int EstimateWeaponBurnoutWeight(Weapon theWeapon)
	{
		if (theWeapon != null)
		{
			int value = 0;
			if (!CurrentDatabaseCache.Cache_WeaponBurnoutWeight.TryGetValue(theWeapon.DBID, out value))
			{
				Engine.EngineType engineType = Engine.EngineType.None;
				if (theWeapon.Propulsion.Count > 0)
				{
					engineType = theWeapon.Propulsion[0].Type;
				}
				else if (theWeapon.UsesBoostCoastModel.Value)
				{
					engineType = Engine.EngineType.Rocket_BoostCoast;
				}
				switch (engineType)
				{
				default:
					value = (theWeapon.Flags.IsMultiStageMissile ? ((int)Math.Floor((double)theWeapon.MaxWeight * 0.1 + 0.5)) : ((int)Math.Floor((double)theWeapon.MaxWeight * 0.25 + 0.5)));
					break;
				case Engine.EngineType.Rocket_BoostCoast:
				case Engine.EngineType.Rocket_LongBurn:
				case Engine.EngineType.Ramjet:
				{
					float num = theWeapon.MaxWeight;
					float num2 = 0f;
					float num3 = 2460f;
					float num4 = (float)((double)theWeapon.Kinematics.GetMaximumSpeed() * 0.514444);
					if (engineType == Engine.EngineType.Ramjet)
					{
						num3 = 3400f;
					}
					bool flag;
					if (!(flag = theWeapon.MinLaunchAlt_AGL > 0f || theWeapon.MinLaunchAlt_ASL > 0f || CheckWeaponIsInAircraftLoadouts(theWeapon.ParentScen.DBConnection, theWeapon.DBID)) && theWeapon.IsAAW_GuidedMissile && theWeapon.MaxWeight < 20 && theWeapon.MaxAirRange < 10f)
					{
						flag = true;
					}
					if (theWeapon.DBID == 4110 && num == 210f)
					{
						num = 816f;
					}
					if (theWeapon.Flags.IsMultiStageMissile && num == 705f && theWeapon.Name.Contains("SM-6"))
					{
						num = 1500f;
					}
					num4 = ((!flag) ? (num4 * 1.5625f) : (num4 * 1.25f));
					num2 = (float)((double)num * (1.0 - Math.Exp((0f - num4) / num3)));
					num -= num2;
					if (theWeapon.Flags.IsMultiStageMissile)
					{
						num = 0.6f * num;
					}
					value = (int)Math.Floor((double)num + 0.5);
					break;
				}
				case Engine.EngineType.None:
				case Engine.EngineType.WeaponCoast:
					value = theWeapon.MaxWeight;
					break;
				}
				CurrentDatabaseCache.Cache_WeaponBurnoutWeight.TryAdd(theWeapon.DBID, value);
			}
			return value;
		}
		return 0;
	}

	public static DataTable GetAllMounts(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT ID, Name || ' (' || Comments || ')' as Name ";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			string_0 += ", Deprecated ";
		}
		string_0 += " from DataMount";
		return DBCache.GetDatatable(theHelper, string_0);
	}

	public static DataTable GetAllCargoAircraft(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		bool flag = false;
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0) && CheckColumnExists_SQLite("DataAircraft", "Deprecated", sqliteConnection_0))
		{
			flag = true;
		}
		string_0 = "SELECT 'Aircraft' as UnitType, CASE WHEN DataAircraft.Comments = '-' THEN DataAircraft.Name ELSE DataAircraft.Name || ' (' || DataAircraft.Comments || ')' END || ' ' || DataLoadout.Name AS Name, DataLoadout.Cargo_Type as Cargo_Type, DataLoadout.Cargo_Mass as Cargo_Mass, DataLoadout.Cargo_Area as Cargo_Area, DataLoadout.Cargo_Crew as Cargo_Crew, DataLoadout.Cargo_ParadropCapable as Cargo_ParadropCapable";
		if (!flag)
		{
			string_0 += ", 'FALSE' AS Deprecated";
		}
		else
		{
			string_0 += ", DataAircraft.Deprecated";
		}
		string_0 += " FROM DataAircraft, DataAircraftLoadouts, DataLoadout where DataLoadout.LoadoutRole = 9005 AND DataAircraftLoadouts.ComponentID = DataLoadOut.ID AND DataAircraft.ID = DataAircraftLoadouts.ID ORDER BY DataAircraft.Name";
		DataTable dataTable = DBCache.GetDatatable(theHelper, string_0);
		if (dataTable == null || dataTable.Rows.Count == 0)
		{
			Scenario theScen = null;
			Aircraft aircraft = new Aircraft(ref theScen);
			string_0 = "SELECT ID, CASE WHEN Comments = '-' THEN Name ELSE Name || ' (' || Comments || ')' END AS Name, Type, Length, Span, WeightEmpty, WeightMax, PhysicalSizeCode";
			if (!flag)
			{
				string_0 += ", 'FALSE' AS Deprecated";
			}
			else
			{
				string_0 += ", Deprecated";
			}
			string_0 += " FROM DataAircraft WHERE Length > 0 AND Span > 0 AND (Span < 6 OR Type = 8201 OR Type = 8202) ORDER BY Name";
			dataTable = DBCache.GetDatatable(theHelper, string_0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataTable dataTable2 = new DataTable();
				dataTable2.Columns.Add("unitType", typeof(string));
				dataTable2.Columns.Add("ID", typeof(int));
				dataTable2.Columns.Add("Name", typeof(string));
				dataTable2.Columns.Add("Cargo_Type", typeof(int));
				dataTable2.Columns.Add("Cargo_Mass", typeof(float));
				dataTable2.Columns.Add("Cargo_Area", typeof(float));
				dataTable2.Columns.Add("Cargo_Crew", typeof(int));
				dataTable2.Columns.Add("Cargo_ParadropCapable", typeof(bool));
				dataTable2.Columns.Add("Deprecated");
				int num = 0;
				bool flag2 = false;
				int num2 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					DataRow dataRow = dataTable.Rows[i];
					if (!flag || !Conversions.ToBoolean(dataRow["Deprecated"]))
					{
						aircraft.Cargo_Type = CargoType.NoCargo;
						aircraft.Type = (Aircraft._AircraftType)Conversions.ToInteger(dataRow["Type"]);
						aircraft.Span = Conversions.ToSingle(dataRow["Span"]);
						aircraft.Length = Conversions.ToSingle(dataRow["Length"]);
						aircraft.EmptyWeight = Conversions.ToInteger(dataRow["WeightEmpty"]);
						aircraft.MaxWeight = Conversions.ToInteger(dataRow["WeightMax"]);
						aircraft.Size = GetAircraftPhysicalSize(Conversions.ToInteger(dataRow["PhysicalSizeCode"]));
						PopulateAircraftMissingCargoData(aircraft);
						if (aircraft.Cargo_Type > CargoType.NoCargo)
						{
							object[] values = new object[9]
							{
								"Aircraft",
								Conversions.ToInteger(dataRow["ID"]),
								Conversions.ToString(dataRow["Name"]),
								aircraft.Cargo_Type,
								aircraft.GetRequiredMass(),
								aircraft.GetRequiredArea(),
								num,
								flag2,
								false
							};
							dataTable2.Rows.Add(values);
						}
					}
				}
				dataTable = dataTable2;
			}
		}
		return dataTable;
	}

	public static DataTable GetAllCargoWeapons(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		bool flag = false;
		int num = 0;
		bool flag2 = false;
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("unitType", typeof(string));
		dataTable.Columns.Add("ID", typeof(int));
		dataTable.Columns.Add("Name", typeof(string));
		dataTable.Columns.Add("Cargo_Type", typeof(int));
		dataTable.Columns.Add("Cargo_Mass", typeof(float));
		dataTable.Columns.Add("Cargo_Area", typeof(float));
		dataTable.Columns.Add("Cargo_Crew", typeof(int));
		dataTable.Columns.Add("Cargo_ParadropCapable", typeof(bool));
		dataTable.Columns.Add("Deprecated");
		if (CheckColumnExists_SQLite("DataWeapon", "Cargo_Area", sqliteConnection_0))
		{
			string text = "SELECT ID, Name, Cargo_Type, Cargo_Mass, Cargo_Area, Cargo_Volume, Cargo_Crew, Cargo_ParadropCapable";
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					flag = true;
					text += ", Deprecated";
				}
				else
				{
					text += ", 'FALSE' AS Deprecated";
				}
			}
			text += " FROM DataWeapon ORDER BY Name";
			DataTable datatable = DBCache.GetDatatable(theHelper, text);
			if (datatable.Rows.Count > 0)
			{
				for (int i = datatable.Rows.Count - 1; i >= 0; i += -1)
				{
					DataRow dataRow = datatable.Rows[i];
					if (flag && Conversions.ToBoolean(dataRow["Deprecated"]))
					{
						continue;
					}
					CargoType cargoType = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"]);
					if (cargoType != CargoType.NoCargo)
					{
						object[] array = new object[9]
						{
							"Munition",
							Conversions.ToInteger(dataRow["ID"]),
							Conversions.ToString(dataRow["Name"]),
							cargoType,
							Conversions.ToSingle(dataRow["Cargo_Mass"]),
							null,
							null,
							null,
							null
						};
						object objectValue = RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"]);
						if (!(objectValue is DBNull))
						{
							array[5] = Conversions.ToSingle(objectValue);
						}
						else
						{
							array[5] = 0;
						}
						array[6] = Conversions.ToSingle(dataRow["Cargo_Crew"]);
						array[7] = flag2;
						array[8] = false;
						dataTable.Rows.Add(array);
					}
				}
			}
		}
		else
		{
			string_0 = "SELECT ID, Name, Length, Span, Diameter, Weight";
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (!CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					string_0 += ", 'FALSE' AS Deprecated";
				}
				else
				{
					flag = true;
					string_0 += ", Deprecated";
				}
			}
			string_0 += " FROM DataWeapon WHERE ((Length <> 0 AND Span <> 0 AND Weight <> 0) OR Type = 2004) ORDER BY Name";
			DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
			if (datatable.Rows.Count > 0)
			{
				for (int j = datatable.Rows.Count - 1; j >= 0; j += -1)
				{
					DataRow dataRow2 = datatable.Rows[j];
					if (!flag || !Conversions.ToBoolean(dataRow2["Deprecated"]))
					{
						int num2 = Conversions.ToInteger(dataRow2["ID"]);
						string text2 = Conversions.ToString(dataRow2["Name"]);
						float length = Conversions.ToSingle(dataRow2["Length"]);
						float width = Conversions.ToSingle(dataRow2["Span"]);
						float num3 = Conversions.ToSingle(dataRow2["Diameter"]);
						float mass = Conversions.ToSingle(dataRow2["Weight"]);
						CargoType cargoType2 = CargoType.NoCargo;
						if (num3 == 0f && width > 0f)
						{
							num3 = width;
						}
						else if (width == 0f && num3 > 0f)
						{
							width = num3;
						}
						float height = num3 * 1.1f;
						if (width > num3)
						{
							height = width * 0.95f;
						}
						float num4 = length * height;
						if (length != 0f && width != 0f && mass != 0f)
						{
							cargoType2 = GetCargoTypeCategory(length, height, height);
							mass /= 1000f;
						}
						else if (EstimateCargoWeaponData(ref sqliteConnection_0, num2, ref length, ref width, ref height, ref mass))
						{
							num4 = length * width;
							cargoType2 = GetCargoTypeCategory(length, width, height);
						}
						if (cargoType2 != CargoType.NoCargo)
						{
							object[] values = new object[9] { "Munition", num2, text2, cargoType2, mass, num4, num, flag2, false };
							dataTable.Rows.Add(values);
						}
					}
				}
			}
		}
		dataTable.DefaultView.Sort = "Name ASC";
		return dataTable.DefaultView.ToTable();
	}

	public static DataTable GetAllCargoMounts(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT 'Mount' AS UnitType, ID, CASE WHEN Comments = '-' THEN Name ELSE Name || ' (' || Comments || ')' END AS Name, Cargo_Type, Cargo_Mass, Cargo_Area, Cargo_Crew, Cargo_ParadropCapable";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			string_0 += ", Deprecated";
		}
		string_0 += " from DataMount where Cargo_Type <> 0 order by Name";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row in datatable.Rows)
		{
			if (Conversions.ToInteger(row["Cargo_Type"]) == 1000 && (Conversions.ToSingle(row["Cargo_Mass"]) == 0f || Conversions.ToSingle(row["Cargo_Area"]) == 0f))
			{
				int num = Conversions.ToInteger(row["Cargo_Crew"]);
				row["Cargo_Mass"] = (float)num * Mount.PersonnelMass;
				row["Cargo_Area"] = (float)num * Mount.PersonnelArea;
			}
		}
		return datatable;
	}

	public static DataTable GetAllCargoContainers(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataContainer"))
		{
			string_0 = "Select * ";
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (!CheckColumnExists_SQLite("DataContainer", "Deprecated", sqliteConnection_0))
				{
					string_0 += ", 'FALSE' AS Deprecated";
				}
				else
				{
					string_0 += ", Deprecated";
				}
			}
			string_0 += " FROM DataContainer WHERE IsHold != 1 ORDER BY Name";
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("UnitType");
			dataTable.Columns.Add("ID");
			dataTable.Columns.Add("Name");
			dataTable.Columns.Add("Cargo_Type");
			dataTable.Columns.Add("Cargo_Mass");
			dataTable.Columns.Add("Cargo_Area");
			dataTable.Columns.Add("Cargo_Crew");
			dataTable.Columns.Add("Cargo_ParadropCapable");
			bool flag = CheckColumnExists_SQLite("DataContainer", "Container_ParadropCapable", sqliteConnection_0);
			bool flag2 = CheckColumnExists_SQLite("DataContainer", "Container_Crew", sqliteConnection_0);
			for (int i = datatable.Rows.Count - 1; i >= 0; i += -1)
			{
				DataRow dataRow = datatable.Rows[i];
				if (!Conversions.ToBoolean(dataRow["IsHold"]))
				{
					float length = Conversions.ToSingle(dataRow["Length"]);
					float width = Conversions.ToSingle(dataRow["Width"]);
					float height = Conversions.ToSingle(dataRow["Height"]);
					int num = (int)((Conversions.ToInteger(dataRow["Type"]) != 3001) ? GetCargoTypeCategory(length, width, height) : GetCargoTypeCategory(length, width, 0f));
					bool flag3 = flag && Conversions.ToBoolean(dataRow["Container_ParadropCapable"]);
					float num2 = (flag2 ? Conversions.ToSingle(dataRow["Container_Crew"]) : 0f);
					float cargoContainerArea = GetCargoContainerArea(length, width);
					dataTable.Rows.Add("Container", dataRow["ID"], dataRow["Name"], num, Conversions.ToSingle(dataRow["Weight"]) / 1000f, cargoContainerArea, num2, flag3);
				}
			}
			return dataTable;
		}
		return new DataTable();
	}

	public static DataTable GetAllCargoGroundUnits(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			if (!CheckColumnExists_SQLite("DataGroundUnit", "Self_Cargo_Type", sqliteConnection_0))
			{
				string_0 = "SELECT 'Ground Unit' AS UnitType, ID, CASE WHEN Comments = '-' THEN Name ELSE Name || ' (' || Comments || ')' END AS Name, CASE WHEN Category = 1000 THEN '1000' ELSE '4000' END AS Cargo_Type, Mass / 1000 as Cargo_Mass, Area as Cargo_Area, Crew as Cargo_Crew, 'FALSE' as Cargo_ParadropCapable";
			}
			else
			{
				string_0 = "SELECT 'Ground Unit' AS UnitType, ID, CASE WHEN Comments = '-' THEN Name ELSE Name || ' (' || Comments || ')' END AS Name, Self_Cargo_Type AS Cargo_Type, Self_Cargo_Mass as Cargo_Mass, Self_Cargo_Area as Cargo_Area, CASE WHEN Self_Cargo_Crew IS NULL OR (Self_Cargo_Crew = 0 AND Self_Cargo_Type = 1000) THEN Crew ELSE Self_Cargo_Crew END AS Cargo_Crew, Self_Cargo_ParadropCapable as Cargo_ParadropCapable";
			}
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (CheckColumnExists_SQLite("DataGroundUnit", "Deprecated", sqliteConnection_0))
				{
					string_0 += ", Deprecated";
				}
				else
				{
					string_0 += ", 'FALSE' AS Deprecated";
				}
			}
			string_0 += " from DataGroundUnit order by Name";
			return DBCache.GetDatatable(sQLiteHelper, string_0);
		}
		return new DataTable();
	}

	public static DataTable GetAllCargoFacilities(ref SQLiteConnection sqliteConnection_0, DataTable AllCargoMounts)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string text = "Select 'Mobile Facility' as UnitType, ID,  CASE WHEN Comments = '-' THEN Name ELSE Name || ' (' || Comments || ')' END AS Name";
		text += ", 3000 AS Cargo_Type, 0.00 as Cargo_Mass, 0.00 AS Cargo_Area, 0 AS Cargo_Crew, 'FALSE' AS Cargo_ParadropCapable";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			text = (CheckColumnExists_SQLite("DataFacility", "Deprecated", sqliteConnection_0) ? (text + ", Deprecated") : (text + ", 'FALSE' AS Deprecated"));
		}
		text += " FROM DataFacility WHERE MountsAreAimpoints <> 0 AND (Category = 5001 OR Category = 5002 OR Category = 5003 OR Category = 5004 OR Category = 5005)";
		text += " ORDER BY Name";
		DataTable datatable = DBCache.GetDatatable(theHelper, text);
		DataTable datatable2 = DBCache.GetDatatable(theHelper, "SELECT ID, ComponentID FROM DataFacilityMounts ORDER BY ID");
		foreach (DataRow row in datatable.Rows)
		{
			CargoType cargoType = CargoType.NoCargo;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			bool flag = true;
			DataRow[] array = datatable2.Select("ID = " + row["ID"].ToString());
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				DataRow[] array2 = AllCargoMounts.Select("ID = " + Conversions.ToInteger(array[i]["ComponentID"]));
				if (array2.Count() > 0)
				{
					CargoType cargoType2 = (CargoType)Conversions.ToInteger(array2[0]["Cargo_Type"]);
					if (cargoType2 != CargoType.NoCargo)
					{
						if (cargoType2 > cargoType)
						{
							cargoType = cargoType2;
						}
						num += Conversions.ToSingle(array2[0]["Cargo_Mass"]);
						num2 += Conversions.ToSingle(array2[0]["Cargo_Area"]);
						num3 += Conversions.ToSingle(array2[0]["Cargo_Crew"]);
						if (flag)
						{
							flag = Conversions.ToBoolean(array2[0]["Cargo_ParadropCapable"]);
						}
						continue;
					}
					row["Cargo_Type"] = 0;
					break;
				}
				row["Cargo_Type"] = 0;
				break;
			}
			if (cargoType == CargoType.Personnel && (num == 0f || num2 == 0f))
			{
				num = num3 * Mount.PersonnelMass;
				num2 = num3 * Mount.PersonnelArea;
			}
			row["Cargo_Type"] = cargoType;
			row["Cargo_Mass"] = num;
			row["Cargo_Area"] = num2;
			row["Cargo_Crew"] = num3;
			row["Cargo_ParadropCapable"] = flag;
		}
		for (int j = datatable.Rows.Count - 1; j >= 0; j += -1)
		{
			if (Conversions.ToInteger(datatable.Rows[j]["Cargo_Type"]) == 0)
			{
				datatable.Rows.RemoveAt(j);
			}
		}
		return datatable;
	}

	public static DataTable GetAllCargoItems(ref SQLiteConnection sqliteConnection_0)
	{
		DataTable allCargoGroundUnits = GetAllCargoGroundUnits(ref sqliteConnection_0);
		DataTable allCargoMounts = GetAllCargoMounts(ref sqliteConnection_0);
		DataTable allCargoFacilities = GetAllCargoFacilities(ref sqliteConnection_0, allCargoMounts);
		DataTable allCargoContainers = GetAllCargoContainers(ref sqliteConnection_0);
		DataTable dataTable = allCargoGroundUnits;
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in allCargoContainers.Rows)
			{
				dataTable.Rows.Add(row.ItemArray);
			}
		}
		else
		{
			dataTable = allCargoContainers;
		}
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow row2 in allCargoFacilities.Rows)
			{
				dataTable.Rows.Add(row2.ItemArray);
			}
		}
		else
		{
			dataTable = allCargoFacilities;
		}
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow row3 in allCargoMounts.Rows)
			{
				dataTable.Rows.Add(row3.ItemArray);
			}
		}
		else
		{
			dataTable = allCargoMounts;
		}
		return dataTable;
	}

	public static DataTable GetAllMags(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT ID, Name || ' (' || Comments || ')' as Name from DataMagazine";
		return DBCache.GetDatatable(theHelper, string_0);
	}

	public static DataTable GetAllSensors(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT ID, Name || ' (' || Comments || ')' as Name, Name || ' (' || Comments || ')' as LongName, Type";
		if (CheckColumnExists_SQLite("DataWeaponSensor", "Deprecated", sqliteConnection_0))
		{
			string_0 += ", Deprecated ";
		}
		string_0 += " from DataSensor";
		return DBCache.GetDatatable(theHelper, string_0);
	}

	public static DataTable GetAllWeaponRecs_Preformatted(ref SQLiteConnection sqliteConnection_0)
	{
		DataTable result = default(DataTable);
		try
		{
			SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
			DataTable dataTable = new DataTable();
			string_0 = "SELECT DataWeaponRecord.ID, DataWeaponRecord.ComponentID, DataWeaponRecord.DefaultLoad, DataWeaponRecord.MaxLoad, DataWeaponRecord.ROF, DataWeaponRecord.Multiple, DataWeapon.Name";
			if (CheckColumnExists_SQLite("DataWeaponRecord", "Deprecated", sqliteConnection_0))
			{
				string_0 += ", DataWeaponRecord.Deprecated ";
			}
			string_0 += " from DataWeaponRecord INNER JOIN DataWeapon on DataWeapon.ID = DataWeaponRecord.ComponentID";
			object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sQLiteHelper, string_0));
			if (objectValue == null)
			{
				sQLiteHelper.OpenConnection();
				SQLiteDataReader sQLiteDataReader;
				using (DbCommand dbCommand = sQLiteHelper.theConnection.CreateCommand())
				{
					dbCommand.CommandText = string_0;
					sQLiteDataReader = (SQLiteDataReader)dbCommand.ExecuteReader();
				}
				int fieldCount = sQLiteDataReader.FieldCount;
				int num = fieldCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dataTable.Columns.Add(sQLiteDataReader.GetName(i), sQLiteDataReader.GetFieldType(i));
				}
				dataTable.Columns.Add("Description", typeof(string));
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				while (sQLiteDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					int num2 = fieldCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						dataRow[j] = RuntimeHelpers.GetObjectValue(sQLiteDataReader[j]);
					}
					stringBuilder.Clear();
					stringBuilder.Append(RuntimeHelpers.GetObjectValue(dataRow[6])).Append(" (").Append(RuntimeHelpers.GetObjectValue(dataRow[2]))
						.Append("/")
						.Append(RuntimeHelpers.GetObjectValue(dataRow[3]))
						.Append(") - ROF:")
						.Append(RuntimeHelpers.GetObjectValue(dataRow[4]));
					dataRow[fieldCount] = stringBuilder.ToString();
					dataTable.Rows.Add(dataRow);
				}
				StringBuilderCache.Free(stringBuilder);
				sQLiteDataReader.Close();
				sQLiteDataReader = null;
				sQLiteHelper.CloseConnection();
				DBCache.SetCustomObject(sQLiteHelper, string_0, dataTable);
				result = dataTable;
				return result;
			}
			result = (DataTable)objectValue;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static DataTable GetAllWeapons(bool IncludeNonWeapons, ref Scenario theScen, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		if (IncludeNonWeapons)
		{
			if (!Information.IsNothing((object)theScen) && !theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
			{
				string_0 = "SELECT DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin";
				if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					string_0 += ", Deprecated";
				}
				string_0 += " from DataWeapon";
			}
			else
			{
				string_0 = "SELECT DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin, DataWeapon.TargetAltitudeMax_ASL, DataWeapon.TargetAltitudeMin_ASL";
				if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					string_0 += ", Deprecated";
				}
				string_0 += " from DataWeapon";
			}
		}
		else if (!Information.IsNothing((object)theScen) && !theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
		{
			string_0 = "Select DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin";
			if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
			{
				string_0 += ", Deprecated";
			}
			string_0 += " from DataWeapon where DataWeapon.Type Not In (2005, 2006, 2007, 2008, 3001, 3002, 3003, 3004, 4003, 9001, 9002, 9003)";
		}
		else
		{
			string_0 = "Select DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin, DataWeapon.TargetAltitudeMax_ASL, DataWeapon.TargetAltitudeMin_ASL";
			if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
			{
				string_0 += ", Deprecated";
			}
			string_0 += " From DataWeapon Where DataWeapon.Type Not In (2005, 2006, 2007, 2008, 3001, 3002, 3003, 3004, 4003, 9001, 9002, 9003)";
		}
		return DBCache.GetDatatable(theHelper, string_0);
	}

	public static Weapon._WeaponType GetWeaponType(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "Select type from DataWeapon where ID=" + Conversions.ToString(int_0);
		return (Weapon._WeaponType)Conversions.ToShort(DBCache.GetScalar(theHelper, string_0));
	}

	public static void GetSatellite(ref Scenario theScen, ref Satellite theSatellite, int SatDBID, int SpacecraftNumber = 0, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * from DataSatellite where ID = " + Conversions.ToString(SatDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No satellite With ID " + Conversions.ToString(SatDBID) + " was found in the current database!");
		}
		DataRow dataRow = datatable.Rows[0];
		theSatellite.DBID = SatDBID;
		theSatellite.UnitClass = dataRow["Name"].ToString();
		if (!datatable.Columns.Contains("OODADetectionCycle"))
		{
			datatable.Columns.Add("OODADetectionCycle", typeof(string));
			dataRow["OODADetectionCycle"] = 0;
		}
		if (!datatable.Columns.Contains("OODATargetingCycle"))
		{
			datatable.Columns.Add("OODATargetingCycle", typeof(string));
			dataRow["OODATargetingCycle"] = 0;
		}
		if (!datatable.Columns.Contains("OODAEvasiveCycle"))
		{
			datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
			dataRow["OODAEvasiveCycle"] = 0;
		}
		theSatellite.OODA_Detection = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
		theSatellite.OODA_Targeting = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
		theSatellite.OODA_Evasion = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
		if (datatable.Columns.Contains("Category"))
		{
			theSatellite.Category = (Satellite._SatelliteCategory)Conversions.ToInteger(dataRow["Category"]);
		}
		if (datatable.Columns.Contains("Type"))
		{
			theSatellite.Type = (Satellite._SatelliteType)Conversions.ToInteger(dataRow["Type"]);
		}
		if (datatable.Columns.Contains("Length"))
		{
			theSatellite.Length = Conversions.ToSingle(dataRow["Length"]);
		}
		if (datatable.Columns.Contains("Span"))
		{
			theSatellite.Span = Conversions.ToSingle(dataRow["Span"]);
		}
		if (datatable.Columns.Contains("Height"))
		{
			theSatellite.Height = Conversions.ToSingle(dataRow["Height"]);
		}
		if (datatable.Columns.Contains("WeightEmpty"))
		{
			theSatellite.WeightEmpty = Conversions.ToDouble(dataRow["WeightEmpty"]);
		}
		if (datatable.Columns.Contains("WeightMax"))
		{
			theSatellite.WeightMax = Conversions.ToDouble(dataRow["WeightMax"]);
		}
		if (datatable.Columns.Contains("WeightPayload"))
		{
			theSatellite.WeightPayload = Conversions.ToDouble(dataRow["WeightPayload"]);
		}
		if (datatable.Columns.Contains("Armor"))
		{
			theSatellite.Armor = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["Armor"]);
		}
		if (datatable.Columns.Contains("DamagePoints"))
		{
			theSatellite.DamagePoints = Conversions.ToSingle(dataRow["DamagePoints"]);
		}
		try
		{
			theSatellite.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (SpacecraftNumber != 0)
		{
			string_0 = "Select * from DataSatelliteOrbits where ID = " + Conversions.ToString(SatDBID) + " And ComponentNumber = " + Conversions.ToString(SpacecraftNumber);
			datatable = DBCache.GetDatatable(theHelper, string_0);
			dataRow = datatable.Rows[0];
			theSatellite.Name = dataRow["MissonName"].ToString();
			if (datatable.Columns.Contains("TLE") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["TLE"])) && Operators.CompareString(dataRow["TLE"].ToString(), "-", false) != 0)
			{
				string[] orbit_OT = (from theStr in Conversions.ToString(dataRow["TLE"]).Split(Conversions.ToCharArrayRankOne(Environment.NewLine))
					where !string.IsNullOrEmpty(theStr)
					select theStr).ToArray();
				theSatellite.Kinematics.SetOrbit_OT(orbit_OT);
			}
			else
			{
				long num = Conversions.ToLong(dataRow["Apogee"]) * 1000L;
				long num2 = Conversions.ToLong(dataRow["Perigee"]) * 1000L;
				if (num < num2)
				{
					num ^= num2;
					num2 = num ^ num2;
					num ^= num2;
				}
				theSatellite.Kinematics.SetOrbit_Tukey(Conversions.ToSingle(dataRow["Inclination"]), num, num2);
			}
			theSatellite.LaunchDate = Conversions.ToDate(dataRow["LaunchDate"]);
			theSatellite.DeOrbitDate = Conversions.ToDate(dataRow["DeOrbitingDate"]);
			theSatellite.SpacecraftID = dataRow["ID"].ToString() + "_" + dataRow["ComponentNumber"].ToString();
		}
		if (LoadComponents)
		{
			PopulateSensors(theSatellite, SatDBID);
			PopulateComms(theSatellite, SatDBID);
			ActiveUnit theUnit = theSatellite;
			PopulateMounts(ref theScen, ref theUnit, SatDBID);
			PopulateEyeballSensorIfNeeded(theScen, theSatellite);
		}
	}

	public static void PopulateAirFacilities(ref Platform theUnit, int UnitDBID)
	{
		string text = "";
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityAircraftFacilities";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitAircraftFacilities";
			break;
		}
		string_0 = "select * from " + text + " where id = " + Conversions.ToString(UnitDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int facilityDBID = Conversions.ToInteger(datatable.Rows[i]["ComponentID"]);
			SQLiteConnection sqliteConnection_ = theUnit.ParentScen.DBConnection;
			AirFacility airFacility = GetAirFacility(facilityDBID, ref sqliteConnection_, theUnit);
			theUnit.AddAirFacility(airFacility);
		}
	}

	public static void PopulateDockFacilities(ref Platform theUnit, int UnitDBID)
	{
		string text = "";
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityDockingFacilities";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitDockingFacilities";
			break;
		}
		string_0 = "select * from " + text + " where id = " + Conversions.ToString(UnitDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int facilityDBID = Conversions.ToInteger(datatable.Rows[i]["ComponentID"]);
			SQLiteConnection sqliteConnection_ = theUnit.ParentScen.DBConnection;
			DockFacility dockFacility = GetDockFacility(facilityDBID, ref sqliteConnection_, theUnit);
			theUnit.AddDockFacility(dockFacility);
		}
	}

	internal static IMobileGroundUnit._MobileUnitCategory MostCommonMobileUnitCategoryForThisMount(int theMountDBID, ref SQLiteConnection sqliteConnection_0)
	{
		Dictionary<IMobileGroundUnit._MobileUnitCategory, int> dictionary = new Dictionary<IMobileGroundUnit._MobileUnitCategory, int>();
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "select DataFacility.ID, DataFacility.Name from DataFacility, DataFacilityMounts where DataFacilityMounts.ID = DataFacility.ID and DataFacilityMounts.ComponentID = " + Conversions.ToString(theMountDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row in datatable.Rows)
		{
			IMobileGroundUnit._MobileUnitCategory key = Facility.MobileUnitCategory(row["Name"].ToString());
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, 1);
			}
			else
			{
				dictionary[key]++;
			}
		}
		if (dictionary.Count != 0)
		{
			return dictionary.OrderByDescending([SpecialName] (KeyValuePair<IMobileGroundUnit._MobileUnitCategory, int> theKVP) => theKVP.Value).First().Key;
		}
		return IMobileGroundUnit._MobileUnitCategory.None;
	}

	public static AirFacility GetAirFacility(int FacilityDBID, ref SQLiteConnection sqliteConnection_0, ActiveUnit theParent = null)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "Select * from DataAircraftFacility where ID = " + Conversions.ToString(FacilityDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count != 0)
		{
			_ = datatable.Rows.Count;
			DataRow dataRow = datatable.Rows[0];
			string scalar = DBCache.GetScalar(theHelper, "Select Description from EnumAircraftFacilityType where ID = " + dataRow["Type"].ToString());
			int num = Conversions.ToInteger(dataRow["PhysicalSize"]);
			GlobalVariables.AircraftSizeClass aircraftPhysicalSize = GetAircraftPhysicalSize(num);
			if (aircraftPhysicalSize == GlobalVariables.AircraftSizeClass.None && num != 1001 && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string text = "";
			text = ((!DBOps.DBHasLegacyRunwayLengthEnum) ? Misc.Description(aircraftPhysicalSize, sqliteConnection_0) : DBCache.GetScalar(theHelper, "Select Description from EnumAircraftFacilityPhysicalSize where ID = " + dataRow["PhysicalSize"].ToString()));
			GlobalVariables.RunwayLengthClass runwayLength = GetRunwayLength(Conversions.ToInteger(dataRow["RunwayLength"]));
			return new AirFacility(theParent, scalar + " (" + dataRow["capacity"].ToString() + "x " + text + ")", (AirFacility._AirFacType)Conversions.ToShort(dataRow["Type"]), (int)aircraftPhysicalSize, Conversions.ToInteger(dataRow["Capacity"]), runwayLength)
			{
				DBID = FacilityDBID
			};
		}
		throw new PlatformComponentNotFoundException();
	}

	public static DockFacility GetDockFacility(int FacilityDBID, ref SQLiteConnection sqliteConnection_0, ActiveUnit theParent = null)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "Select * from DataDockingFacility where ID = " + Conversions.ToString(FacilityDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		_ = datatable.Rows.Count;
		DataRow dataRow = datatable.Rows[0];
		string scalar = DBCache.GetScalar(theHelper, "Select Description from EnumDockingFacilityType where ID = " + dataRow["Type"].ToString());
		string scalar2 = DBCache.GetScalar(theHelper, "Select Description from EnumDockingFacilityPhysicalSize where ID = " + dataRow["PhysicalSize"].ToString());
		DockFacility.DockingPhysicalSize theSize = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSize"]);
		return new DockFacility(theParent, scalar + " (" + dataRow["capacity"].ToString() + "x " + scalar2 + ")", (DockFacility.DockFacilityType)Conversions.ToShort(dataRow["Type"]), theSize, Conversions.ToByte(dataRow["Capacity"]))
		{
			DBID = FacilityDBID
		};
	}

	public static int GetCommDeviceID(string CommDeviceName, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string_0 = "Select ID from DataComm where Name = '" + CommDeviceName + "'";
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, string_0));
	}

	public static void PopulateMagazines(ref Platform theUnit, int UnitDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		string text = default(string);
		int num;
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftMagazines";
			num = 5;
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipMagazines";
			num = 5;
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineMagazines";
			num = 5;
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityMagazines";
			num = 5;
			break;
		default:
			if (!Debugger.IsAttached)
			{
				num = 5;
				break;
			}
			Debugger.Break();
			num = 5;
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitMagazines";
			num = 5;
			break;
		}
		string[] array = new string[num];
		array[0] = "SELECT theTable.* FROM ";
		array[1] = text;
		array[2] = " as theTable, DataMagazine WHERE theTable.ComponentID = DataMagazine.ID And theTable.ID = ";
		array[3] = Conversions.ToString(UnitDBID);
		array[4] = " ORDER BY DataMagazine.Name ASC";
		string_0 = string.Concat(array);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num2 = datatable.Rows.Count - 1;
		for (int i = 0; i <= num2; i++)
		{
			Magazine magazine = GetMagazine(Conversions.ToInteger(datatable.Rows[i]["ComponentID"]), ref theUnit.ParentScen);
			theUnit.AddSharedMagazine(magazine);
			magazine.ParentPlatform = theUnit;
		}
	}

	public static int smethod_5(string theName, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT ID from DataMagazine where Name='" + Misc.RemoveHiddenString(theName) + "'";
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery));
	}

	public static Magazine GetMagazine(int MagazineDBID, ref Scenario theScen, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "Select * From DataMagazine where ID = " + Conversions.ToString(MagazineDBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count != 0)
		{
			DataRow dataRow = datatable.Rows[0];
			Magazine magazine_ = new Magazine(null, Conversions.ToInteger(dataRow["ID"]), Conversions.ToString(dataRow["Name"]), (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToBoolean(dataRow["AviationMagazine"]));
			try
			{
				magazine_.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200478", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
			if (LoadComponents)
			{
				smethod_6(ref magazine_, ref theScen);
			}
			return magazine_;
		}
		throw new PlatformComponentNotFoundException();
	}

	private static void smethod_6(ref Magazine magazine_0, ref Scenario scenario_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(scenario_0.DBConnection);
		string_0 = "SELECT DataWeaponRecord.* FROM DataMagazineWeapons, DataWeaponRecord, DataWeapon WHERE DataMagazineWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMagazineWeapons.ID = " + Conversions.ToString(magazine_0.DBID) + " ORDER BY DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec weaponRec = new WeaponRec(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
			weaponRec.ResetTimeToFire();
			magazine_0.Weapons.Add(weaponRec);
		}
	}

	public static (string, string, string) GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType theType, int UnitDBID, Scenario theScen)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		string text = null;
		int num;
		switch (theType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			num = 8;
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			num = 8;
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			num = 8;
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			num = 8;
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 8;
			}
			else
			{
				num = 8;
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			num = 8;
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			num = 8;
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			num = 8;
			break;
		}
		string[] array = new string[num];
		array[0] = "Select EnumOperatorCountry.Description As Country, YearCommissioned, YearDecommissioned FROM ";
		array[1] = text;
		array[2] = " Left Join EnumOperatorCountry On EnumOperatorCountry.ID = ";
		array[3] = text;
		array[4] = ".OperatorCountry where ";
		array[5] = text;
		array[6] = ".ID=";
		array[7] = Conversions.ToString(UnitDBID);
		string_0 = string.Concat(array);
		DataRow dataRow = sQLiteHelper.ExecuteDataTable(string_0).Rows[0];
		string item = Conversions.ToString(dataRow["Country"]);
		string item2 = Conversions.ToString(dataRow["YearCommissioned"]);
		string item3 = Conversions.ToString(dataRow["YearDecommissioned"]);
		return (item, item2, item3);
	}

	public static string[] GetPlatformsThatCarryThisWeapon(int int_0, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		HashSet<string> hashSet = new HashSet<string>();
		string_0 = "Select DISTINCT DataAircraft.ID As ID, DataAircraft.Name, EnumOperatorCountry.Description As Country, YearCommissioned FROM DataAircraft \r\n    Left JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry\r\n\tLEFT JOIN DataAircraftLoadouts ON DataAircraftLoadouts.ID = DataAircraft.ID \r\n\tLEFT JOIN DataLoadoutWeapons ON DataLoadoutWeapons.ID = DataAircraftLoadouts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataLoadoutWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row in datatable.Rows)
		{
			string text = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Country"]))) ? Conversions.ToString(row["Country"]) : "N/A");
			hashSet.Add("Aircraft_" + Conversions.ToString(row["ID"]) + "_" + Conversions.ToString(row["Name"]) + "_" + text + "_" + Conversions.ToString(row["YearCommissioned"]));
		}
		string_0 = "SELECT DISTINCT DataAircraft.ID, DataAircraft.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataAircraft\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry  \r\n\tLeft Join DataAircraftMounts ON DataAircraftMounts.ID = DataAircraft.ID \r\n    Left Join DataMountWeapons ON DataMountWeapons.ID = DataAircraftMounts.ComponentID \r\n    Left Join DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n    WHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row2 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Country"])) ? "N/A" : Conversions.ToString(row2["Country"]));
			hashSet.Add("Aircraft_" + Conversions.ToString(row2["ID"]) + "_" + Conversions.ToString(row2["Name"]) + "_" + text + "_" + Conversions.ToString(row2["YearCommissioned"]));
		}
		string_0 = "SELECT DISTINCT DataShip.ID, DataShip.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataShip\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataShip.OperatorCountry\r\n\tLEFT JOIN DataShipMounts ON DataShipMounts.ID = DataShip.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataShipMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row3 in datatable.Rows)
		{
			string text = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Country"]))) ? Conversions.ToString(row3["Country"]) : "N/A");
			hashSet.Add("Ship_" + Conversions.ToString(row3["ID"]) + "_" + Conversions.ToString(row3["Name"]) + "_" + text + "_" + Conversions.ToString(row3["YearCommissioned"]));
		}
		string_0 = "SELECT DISTINCT DataSubmarine.ID, DataSubmarine.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSubmarine\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSubmarine.OperatorCountry\r\n\tLEFT JOIN DataSubmarineMounts ON DataSubmarineMounts.ID = DataSubmarine.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataSubmarineMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row4 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row4["Country"])) ? "N/A" : Conversions.ToString(row4["Country"]));
			hashSet.Add("Submarine_" + Conversions.ToString(row4["ID"]) + "_" + Conversions.ToString(row4["Name"]) + "_" + text + "_" + Conversions.ToString(row4["YearCommissioned"]));
		}
		string_0 = "SELECT DISTINCT DataFacility.ID, DataFacility.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataFacility\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataFacility.OperatorCountry \r\n\tLEFT JOIN DataFacilityMounts ON DataFacilityMounts.ID = DataFacility.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataFacilityMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row5 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row5["Country"])) ? "N/A" : Conversions.ToString(row5["Country"]));
			hashSet.Add("Facility_" + Conversions.ToString(row5["ID"]) + "_" + Conversions.ToString(row5["Name"]) + "_" + text + "_" + Conversions.ToString(row5["YearCommissioned"]));
		}
		string_0 = "SELECT DISTINCT DataSatellite.ID, DataSatellite.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSatellite\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSatellite.OperatorCountry\r\n\tLEFT JOIN DataSatelliteMounts ON DataSatelliteMounts.ID = DataSatellite.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataSatelliteMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(theHelper, string_0);
		foreach (DataRow row6 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row6["Country"])) ? "N/A" : Conversions.ToString(row6["Country"]));
			hashSet.Add("Satellite_" + Conversions.ToString(row6["ID"]) + "_" + Conversions.ToString(row6["Name"]) + "_" + text + "_" + Conversions.ToString(row6["YearCommissioned"]));
		}
		return hashSet.ToArray();
	}

	public static string[] GetPlatformsThatCarryThisSensor(int DBID, Scenario theScen)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		HashSet<string> hashSet = new HashSet<string>();
		string theQuery = "SELECT DISTINCT DataAircraft.ID, DataAircraft.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataAircraft\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry  \r\n\tJOIN DataAircraftSensors ON DataAircraftSensors.ID = DataAircraft.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataAircraftSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		DataTable datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row in datatable.Rows)
		{
			string text = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Country"]))) ? Conversions.ToString(row["Country"]) : "N/A");
			hashSet.Add("Aircraft_" + Conversions.ToString(row["ID"]) + "_" + Conversions.ToString(row["Name"]) + "_" + text + "_" + Conversions.ToString(row["YearCommissioned"]));
		}
		theQuery = "SELECT DISTINCT DataShip.ID, DataShip.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataShip\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataShip.OperatorCountry\r\n\tJOIN DataShipSensors ON DataShipSensors.ID = DataShip.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataShipSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row2 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Country"])) ? "N/A" : Conversions.ToString(row2["Country"]));
			hashSet.Add("Ship_" + Conversions.ToString(row2["ID"]) + "_" + Conversions.ToString(row2["Name"]) + "_" + text + "_" + Conversions.ToString(row2["YearCommissioned"]));
		}
		theQuery = "Select DISTINCT DataSubmarine.ID, DataSubmarine.Name, EnumOperatorCountry.Description As Country, YearCommissioned From DataSubmarine\r\n    Left Join EnumOperatorCountry ON EnumOperatorCountry.ID = DataSubmarine.OperatorCountry\r\n    Join DataSubmarineSensors ON DataSubmarineSensors.ID = DataSubmarine.ID \r\n    Join DataSensor ON DataSensor.ID = DataSubmarineSensors.ComponentID\r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row3 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Country"])) ? "N/A" : Conversions.ToString(row3["Country"]));
			hashSet.Add("Submarine_" + Conversions.ToString(row3["ID"]) + "_" + Conversions.ToString(row3["Name"]) + "_" + text + "_" + Conversions.ToString(row3["YearCommissioned"]));
		}
		theQuery = "SELECT DISTINCT DataFacility.ID, DataFacility.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataFacility\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataFacility.OperatorCountry \r\n\tJOIN DataFacilitySensors ON DataFacilitySensors.ID = DataFacility.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataFacilitySensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row4 in datatable.Rows)
		{
			string text = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row4["Country"]))) ? Conversions.ToString(row4["Country"]) : "N/A");
			hashSet.Add("Facility_" + Conversions.ToString(row4["ID"]) + "_" + Conversions.ToString(row4["Name"]) + "_" + text + "_" + Conversions.ToString(row4["YearCommissioned"]));
		}
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			theQuery = "SELECT DISTINCT DataGroundUnit.ID, DataGroundUnit.Name, EnumOperatorCountry.Description As Country, YearCommissioned From DataGroundUnit\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataGroundUnit.OperatorCountry \r\n    JOIN DataGroundUnitSensors ON DataGroundUnitSensors.ID = DataGroundUnit.ID \r\n    JOIN DataSensor ON DataSensor.ID = DataGroundUnitSensors.ComponentID \r\n    WHERE DataSensor.ID = " + Conversions.ToString(DBID);
			datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
			foreach (DataRow row5 in datatable.Rows)
			{
				string text = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row5["Country"]))) ? Conversions.ToString(row5["Country"]) : "N/A");
				hashSet.Add("GroundUnit_" + Conversions.ToString(row5["ID"]) + "_" + Conversions.ToString(row5["Name"]) + "_" + text + "_" + Conversions.ToString(row5["YearCommissioned"]));
			}
		}
		theQuery = "SELECT DISTINCT DataSatellite.ID, DataSatellite.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSatellite\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSatellite.OperatorCountry\r\n\tJOIN DataSatelliteSensors ON DataSatelliteSensors.ID = DataSatellite.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataSatelliteSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row6 in datatable.Rows)
		{
			string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row6["Country"])) ? "N/A" : Conversions.ToString(row6["Country"]));
			hashSet.Add("Satellite_" + Conversions.ToString(row6["ID"]) + "_" + Conversions.ToString(row6["Name"]) + "_" + text + "_" + Conversions.ToString(row6["YearCommissioned"]));
		}
		theQuery = "SELECT  DISTINCT DataWeapon.ID, DataWeapon.Name FROM DataWeapon\r\n\tJOIN DataWeaponSensors ON DataWeaponSensors.ID = DataWeapon.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataWeaponSensors.ComponentID  \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(DBID);
		datatable = DBCache.GetDatatable(sQLiteHelper, theQuery);
		foreach (DataRow row7 in datatable.Rows)
		{
			string text = "N/A";
			hashSet.Add("Weapon_" + Conversions.ToString(row7["ID"]) + "_" + Conversions.ToString(row7["Name"]) + "_" + text + "_" + Conversions.ToString(0));
		}
		return hashSet.ToArray();
	}

	public static void PopulatePropulsion(ActiveUnit theUnit, int UnitDBID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		string value = "";
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			value = "DataAircraftPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			value = "DataShipPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			value = "DataSubmarinePropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			value = "DataFacilityPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			value = "DataWeaponPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			value = "DataGroundUnitPropulsion";
			break;
		}
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataPropulsion.* from DataPropulsion, ").Append(value).Append(" As theTable where DataPropulsion.ID = theTable.ComponentID And theTable.ID = ")
			.Append(UnitDBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<Struct16> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct16>(theHelper, string_0);
		int count = orBuildCachedQueryResult.Count;
		if (theUnit.IsAircraft)
		{
			foreach (Struct16 item in orBuildCachedQueryResult)
			{
				int int_ = Conversions.ToInteger(item.ID.ToString());
				string text = item.Name;
				if (text.Split(Conversions.ToCharArrayRankOne(" ")).ToArray().Length > 1 && text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0].EndsWith("x"))
				{
					string text2 = text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0];
					text = text.Substring(text2.Length + 1);
				}
				if (item.nullable_0.HasValue)
				{
					int num = (int)Math.Round(item.nullable_0.Value);
					if (num <= 0)
					{
						GameGeneral.WriteExceptionsToLog(new Exception("Incomplete propulsion - AC database # " + Conversions.ToString(UnitDBID) + " has 0 engines"));
					}
					else
					{
						int num2 = num;
						for (int i = 1; i <= num2; i++)
						{
							Engine engine = GetEngine(Conversions.ToInteger(item.ID.ToString()), ref theUnit);
							engine.Name = text + " #" + Conversions.ToString(i);
							theUnit.Propulsion.Add(engine);
						}
					}
				}
				else if (text.Split(Conversions.ToCharArrayRankOne(" ")).ToArray().Length > 1 && text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0].EndsWith("x"))
				{
					string text3 = text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0];
					int num3 = Conversions.ToInteger(text3.Substring(0, text3.Length - 1));
					for (int j = 1; j <= num3; j++)
					{
						Engine engine = GetEngine(int_, ref theUnit);
						engine.Name = text + " #" + Conversions.ToString(j);
						theUnit.Propulsion.Add(engine);
					}
				}
				else
				{
					int num4 = count - 1;
					for (int k = 0; k <= num4; k++)
					{
						Struct16 current = orBuildCachedQueryResult[k];
						Engine engine = GetEngine(int_, ref theUnit);
						theUnit.Propulsion.Add(engine);
					}
				}
			}
			return;
		}
		int num5 = count - 1;
		for (int l = 0; l <= num5; l++)
		{
			Engine engine = GetEngine(Conversions.ToInteger(orBuildCachedQueryResult[l].ID.ToString()), ref theUnit);
			theUnit.Propulsion.Add(engine);
		}
	}

	public static void PopulateComms(ActiveUnit theUnit, int UnitDBID)
	{
		string value = "";
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		if (theUnit.IsAircraft)
		{
			value = "DataAircraftComms";
		}
		else if (theUnit.IsWeapon)
		{
			value = "DataWeaponComms";
		}
		else if (theUnit.IsShip)
		{
			value = "DataShipComms";
		}
		else if (theUnit.IsSubmarine)
		{
			value = "DataSubmarineComms";
		}
		else if (!theUnit.IsFacility)
		{
			if (theUnit.IsMobileGroundUnit)
			{
				value = "DataGroundUnitComms";
			}
			else if (theUnit.IsSatellite)
			{
				value = "DataSatelliteComms";
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else
		{
			value = "DataFacilityComms";
		}
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataComm.ID As CommID, theTable.* From DataComm, ").Append(value).Append(" As theTable Where DataComm.ID = theTable.ComponentID And theTable.ID = ")
			.Append(UnitDBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<Struct17> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct17>(theHelper, string_0);
		int num = orBuildCachedQueryResult.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Struct17 @struct = orBuildCachedQueryResult[i];
			CommDevice commDevice = GetCommDevice((int)@struct.long_0, ref theUnit);
			commDevice.ParentSpecific = @struct.bool_0;
			if (theUnit.IsWeapon && ((Weapon)theUnit).Type == Weapon._WeaponType.Sonobuoy)
			{
				commDevice.ParentSpecific = false;
			}
			theUnit.AddCommDevice(commDevice);
		}
	}

	public static void PopulateWarheads(ref Warhead[] theWarheadsCollection, ref Weapon theWeapon)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theWeapon.ParentScen.DBConnection);
		string_0 = "Select ComponentID From DataWeaponWarheads Where ID =" + Conversions.ToString(theWeapon.DBID);
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "ComponentID");
		int num = orBuildCachedSingleFieldQueryResult.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Warhead warhead = GetWarhead(theWeapon.ParentScen, (int)orBuildCachedSingleFieldQueryResult[i]);
			ArrayExtensions.Add(ref theWarheadsCollection, warhead);
		}
	}

	public static Warhead GetWarhead(Scenario theScen, int WarheadID)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataWarhead.* From DataWarhead Where ID =").Append(WarheadID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		Struct18 @struct = DBCache.GetOrBuildCachedQueryResult<Struct18>(theHelper, string_0).Last();
		return new Warhead(@struct.Name, (float)@struct.DamagePoints, (Warhead.WarheadType)@struct.Type, (Warhead.WarheadExplosivesType)@struct.long_1, (Warhead.WarheadCaliber)@struct.long_0, @struct.long_2.ToString())
		{
			DBID = WarheadID,
			ClusterBombDispersionAreaLength = (short)@struct.long_3,
			ClusterBombDispersionAreaWidth = (short)@struct.long_4,
			ExplosivesWeight = (float)@struct.double_0,
			Hypothetical = @struct.bool_0
		};
	}

	public static void GetESMSpecificParameters(ref Sensor theS, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * From DataSensor Where ID = ").Append(theS.DBID);
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, GameGeneral.ThreadStaticSB.ToString());
		int num = datatableTyped.Rows.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			theS.ESMSensitivity = Conversions.ToSingle(dtrRow["ESMSensitivity"]);
			theS.ESMSystemLoss = Conversions.ToSingle(dtrRow["ESMSystemLoss"]);
			theS.short_3 = Conversions.ToShort(dtrRow["ESMNumberOfChannels"]);
			theS.ESM_PreciseEmitterID = Conversions.ToBoolean(dtrRow["ESMPreciseEmitterID"]);
		}
	}

	public static void GetCommDeviceFlags(ref CommDevice theCD, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "Select CodeID From DataCommCapabilities Where ID = " + Conversions.ToString(theCD.DBID);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i][0]))
			{
			case 1401:
				theCD.Flags.Secure = true;
				break;
			case 1310:
				theCD.Flags.DegradesWithRange = true;
				break;
			case 1450:
				theCD.Flags.LPI = true;
				break;
			case 1402:
				theCD.Flags.Broadcast = true;
				break;
			case 1300:
				theCD.Flags.LOS_Limited = true;
				break;
			case 1201:
				theCD.Flags._Receive_Only = true;
				break;
			case 1200:
				theCD.Flags._Send_Only = true;
				break;
			case 3001:
				theCD.Flags.ELF_Radio = true;
				break;
			case 3002:
				theCD.Flags.SLF_Radio = true;
				break;
			case 3003:
				theCD.Flags.ULF_Radio = true;
				break;
			case 3004:
				theCD.Flags.VLF_Radio = true;
				break;
			case 3005:
				theCD.Flags.LF_Radio = true;
				break;
			case 3006:
				theCD.Flags.MF_Radio = true;
				break;
			case 3007:
				theCD.Flags.HF_Radio = true;
				break;
			case 3008:
				theCD.Flags.VHF_Radio = true;
				break;
			case 3009:
				theCD.Flags.UHF_Radio = true;
				break;
			case 3010:
				theCD.Flags.SHF_Radio = true;
				break;
			case 3011:
				theCD.Flags.EHF_Radio = true;
				break;
			case 1500:
				theCD.Flags.Jam_Resistant = true;
				break;
			case 1475:
				theCD.Flags.Phased_Array_Antenna = true;
				break;
			case 3110:
				theCD.Flags.BLOS_MEO = true;
				break;
			case 3100:
				theCD.Flags.BLOS_LEO = true;
				break;
			default:
				_ = Debugger.IsAttached;
				break;
			case 4000:
				theCD.Flags.DaisyChain = true;
				break;
			case 3201:
				theCD.Flags.Acoustic_0_1kHz = true;
				break;
			case 3202:
				theCD.Flags.Acoustic_1_10kHz = true;
				break;
			case 3203:
				theCD.Flags.Acoustic_10_100kHz = true;
				break;
			}
		}
	}

	public static void GetCommBandwith(ref CommDevice theCD, SQLiteConnection sqliteConnection_0)
	{
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
			if (Convert.ToInt32(DBCache.GetScalar(theHelper, "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EnumCommQuality'")) <= 0)
			{
				theCD.QualityGradeinfo = new CommDevice.QualityGradeDetail();
				return;
			}
			string theQuery = "SELECT 1 AS TableFound, * FROM EnumCommQuality WHERE ID = " + Conversions.ToString(Convert.ToInt32((int)theCD.QualityGrade)) + " UNION ALL SELECT 0 AS TableFound, NULL, NULL, NULL, NULL WHERE NOT EXISTS (SELECT 1 FROM sqlite_master WHERE type='table' AND name='EnumCommQuality') LIMIT 1";
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			if (datatable != null && datatable.Rows.Count > 0 && Operators.CompareString(datatable.Rows[0]["TableFound"].ToString(), "1", false) == 0)
			{
				theCD.QualityGradeinfo = new CommDevice.QualityGradeDetail(int.Parse(datatable.Rows[0].ItemArray[1].ToString()), datatable.Rows[0].ItemArray[2].ToString(), datatable.Rows[0].ItemArray[3].ToString(), datatable.Rows[0].ItemArray[4].ToString());
			}
			else
			{
				theCD.QualityGradeinfo = new CommDevice.QualityGradeDetail();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			theCD.QualityGradeinfo = new CommDevice.QualityGradeDetail();
			ProjectData.ClearProjectError();
		}
	}

	public static void GetCommLatency(ref CommDevice theCD, SQLiteConnection sqliteConnection_0)
	{
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
			if (Convert.ToInt32(DBCache.GetScalar(theHelper, "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EnumCommQuality'")) <= 0)
			{
				theCD.LatencyGradenfo = new CommDevice.LatencyGradeDetail();
				return;
			}
			string theQuery = "SELECT 1 AS TableFound, * FROM EnumCommLatency WHERE ID = " + Conversions.ToString(Convert.ToInt32((int)theCD.QualityGrade)) + " UNION ALL SELECT 0 AS TableFound, NULL, NULL, NULL, NULL WHERE NOT EXISTS (SELECT 1 FROM sqlite_master WHERE type='table' AND name='EnumCommLatency') LIMIT 1";
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			if (datatable != null && datatable.Rows.Count > 0 && Operators.CompareString(datatable.Rows[0]["TableFound"].ToString(), "1", false) == 0)
			{
				theCD.LatencyGradenfo = new CommDevice.LatencyGradeDetail(int.Parse(datatable.Rows[0].ItemArray[1].ToString()), datatable.Rows[0].ItemArray[2].ToString(), datatable.Rows[0].ItemArray[3].ToString(), datatable.Rows[0].ItemArray[4].ToString());
			}
			else
			{
				theCD.LatencyGradenfo = new CommDevice.LatencyGradeDetail();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			theCD.LatencyGradenfo = new CommDevice.LatencyGradeDetail();
			ProjectData.ClearProjectError();
		}
	}

	public static void GetRadarSpecificParameters(ref Sensor theS, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * From DataSensor Where ID = ").Append(theS.DBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		Struct19 @struct = DBCache.GetOrBuildCachedQueryResult<Struct19>(theHelper, string_0).First();
		theS.RadarHorBeamwidth = (float)@struct.double_0;
		theS.RadarVertBeamwidth = (float)@struct.double_1;
		theS.RadarSystemNoiseLevel = (float)@struct.double_2;
		theS.RadarProcessingGainLoss = (float)@struct.double_3;
		theS.RadarPeakPower = (float)@struct.double_4;
		theS.RadarPulseWidth = (float)@struct.double_5;
		theS.RadarBlindTime = (float)@struct.double_6;
		theS.RadarPRF = @struct.long_0;
		theS.RadarHorBeamwidthIlluminate = (float)@struct.double_7;
		theS.RadarVertBeamwidthIlluminate = (float)@struct.double_8;
		theS.RadarSystemNoiseIlluminate = (float)@struct.double_9;
		theS.RadarProcessingGainLossIlluminate = (float)@struct.double_10;
		theS.RadarPeakPowerIlluminate = (float)@struct.double_11;
		theS.RadarPulseWidthIlluminate = (float)@struct.double_12;
		theS.RadarBlindTimeIlluminate = (float)@struct.double_13;
		theS.float_1 = @struct.long_1;
	}

	private static AltBand[] smethod_7(int int_0, ref ActiveUnit activeUnit_0)
	{
		if (!activeUnit_0.ParentScen.Cache_PowerplantAltBands.TryGetValue(int_0, out var value))
		{
			GameGeneral.InitThreadStaticSB();
			SQLiteHelper theHelper = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
			GameGeneral.ThreadStaticSB.Append("Select * From DataPropulsionPerformance As tPAS Where tPAS.ID = ").Append(int_0);
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, string_0);
			bool flag = !datatableTyped.Columns.Contains("AltitudeBand");
			int num = datatableTyped.Rows.Count();
			Dictionary<int, AltBand> dictionary = new Dictionary<int, AltBand>(num);
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				DtrRow dtrRow = datatableTyped.Rows[i];
				int key = ((!flag) ? Conversions.ToInteger(dtrRow["AltitudeBand"]) : Conversions.ToInteger(dtrRow["Band"]));
				AltBand altBand;
				if (dictionary.ContainsKey(key))
				{
					altBand = dictionary[key];
				}
				else
				{
					altBand = new AltBand(Conversions.ToSingle(dtrRow["AltitudeMax"]), Conversions.ToSingle(dtrRow["AltitudeMin"]));
					dictionary.Add(key, altBand);
				}
				try
				{
					switch ((ActiveUnit.Throttle)Conversions.ToByte(dtrRow["Throttle"]))
					{
					case ActiveUnit.Throttle.Loiter:
						altBand.Consumption_Loiter = Conversions.ToSingle(dtrRow["Consumption"]);
						altBand.Speed_Loiter = Conversions.ToInteger(dtrRow["Speed"]);
						break;
					case ActiveUnit.Throttle.Cruise:
						altBand.Consumption_Cruise = Conversions.ToSingle(dtrRow["Consumption"]);
						altBand.Speed_Cruise = Conversions.ToInteger(dtrRow["Speed"]);
						break;
					case ActiveUnit.Throttle.Full:
						altBand.Consumption_Full = Conversions.ToSingle(Conversions.ToString(dtrRow["Consumption"]));
						altBand.Speed_Full = Conversions.ToInteger(dtrRow["Speed"]);
						break;
					case ActiveUnit.Throttle.Flank:
						altBand.Consumption_Flank = Conversions.ToSingle(Conversions.ToString(dtrRow["Consumption"]));
						altBand.Speed_Flank = Conversions.ToInteger(dtrRow["Speed"]);
						break;
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			value = dictionary.Values.ToArray();
			activeUnit_0.ParentScen.Cache_PowerplantAltBands.TryAdd(int_0, value);
			return value;
		}
		return value;
	}

	public static Engine GetEngine(int int_0, ref ActiveUnit theParentPlatform)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theParentPlatform.ParentScen.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataPropulsion.* From DataPropulsion Where ID = ").Append(int_0);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<Struct20> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct20>(theHelper, string_0);
		if (orBuildCachedQueryResult.Count != 0)
		{
			Engine engine = null;
			_ = orBuildCachedQueryResult.Count;
			Struct20 @struct = orBuildCachedQueryResult.First();
			engine = new Engine(theParentPlatform, (int)@struct.ID, @struct.Name, (Engine.EngineType)@struct.Type);
			engine.ParentPlatform = theParentPlatform;
			engine.Hypothetical = @struct.bool_0;
			AltBand[] array = smethod_7(int_0, ref theParentPlatform);
			Array.Resize(ref engine.AltBands, array.Length);
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				engine.AltBands[i] = array[i];
			}
			return engine;
		}
		throw new PlatformComponentNotFoundException();
	}

	public static CommDevice GetCommDevice(int CommDeviceDBID, ref ActiveUnit theParentPlatform)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theParentPlatform.ParentScen.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * From DataComm Where ID = ").Append(CommDeviceDBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<Struct21> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct21>(theHelper, string_0);
		if (orBuildCachedQueryResult.Count != 0)
		{
			CommDevice theCommDevice = null;
			int num = orBuildCachedQueryResult.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Struct21 @struct = orBuildCachedQueryResult[i];
				theCommDevice = new CommDevice(theParentPlatform, theParentPlatform.ParentScen, (int)@struct.ID, @struct.Name, (CommDevice.CommLinkType)@struct.Type, @struct.long_0, (int)@struct.long_1, (CommDevice.EnumCommQuality)@struct.long_2, (CommDevice.EnumCommLatency)@struct.long_3, @struct.bool_0);
				theCommDevice.DBID = CommDeviceDBID;
				try
				{
					theCommDevice.Hypothetical = @struct.bool_2;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200481", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					_ = Debugger.IsAttached;
					ProjectData.ClearProjectError();
				}
			}
			GetCommDeviceFreqs(ref theCommDevice, theParentPlatform.ParentScen.DBConnection);
			return theCommDevice;
		}
		throw new PlatformComponentNotFoundException();
	}

	public static string GetSensorName(int int_0, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Name from DataSensor where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static Sensor GetSensor(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		if (int_0 != 0)
		{
			SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
			Sensor sensor = null;
			Sensor result = default(Sensor);
			try
			{
				GameGeneral.InitThreadStaticSB();
				GameGeneral.ThreadStaticSB.Append("Select DataSensor.*, EnumSensorRole.Description from DataSensor, EnumSensorRole where EnumSensorRole.ID = DataSensor.Role and DataSensor.ID = ").Append(int_0);
				string_0 = GameGeneral.ThreadStaticSB.ToString();
				List<Struct22> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct22>(theHelper, string_0);
				if (orBuildCachedQueryResult.Count == 0)
				{
					throw new PlatformComponentNotFoundException("No valid sensor with ID #" + Conversions.ToString(int_0) + " ! Please pester the DB author to fix this!");
				}
				Struct22 @struct = orBuildCachedQueryResult.First();
				int int_1 = (int)@struct.ID;
				string name = @struct.Name;
				float theVisualDetectZoom = (float)@struct.double_38;
				float theVisualClassZoom = (float)@struct.double_39;
				float theIRDetectZoom = (float)@struct.double_40;
				float theIRClassZoom = (float)@struct.double_41;
				Sensor.Sensor_Type theSensorType = (Sensor.Sensor_Type)@struct.Type;
				Sensor.Sensor_Role role = (Sensor.Sensor_Role)@struct.Role;
				GlobalVariables.TechGenerationClass theGeneration = (GlobalVariables.TechGenerationClass)@struct.long_0;
				float theMaxRange = (float)@struct.double_1;
				float theMinRange = (float)@struct.double_0;
				short theMineSweepWidth = (short)@struct.long_17;
				short theMineMaxSpeed = (short)@struct.long_20;
				int theMaxIntercept = (int)@struct.long_11;
				float theMaxAltitude = (int)@struct.long_3;
				float theMinAltitude = (int)@struct.long_2;
				float theMaxAltitude_ASL = (int)@struct.long_5;
				float theMinAltitude_ASL = (int)@struct.long_4;
				int theScanInterval = (int)@struct.long_6;
				float theRangeResolution = (float)@struct.double_2;
				float theHeightResolution = @struct.long_7;
				float theAngleResolution = (float)@struct.double_3;
				short theMasqueradeAs = (short)@struct.long_1;
				short theMaxContactsAir = (short)@struct.long_8;
				short theMaxContactsSurface = (short)@struct.long_9;
				short theMaxContactsSub = (short)@struct.long_10;
				float theAvailability = @struct.long_12;
				long theUpperFreq = (long)Math.Round(@struct.double_5);
				long theLowerFreq = (long)Math.Round(@struct.double_6);
				long theUpperFreqIlluminate = (long)Math.Round(@struct.double_8);
				long theLowerFreqIlluminate = (long)Math.Round(@struct.double_7);
				float float_ = (float)@struct.double_25;
				float theECMPeakPower = (float)@struct.double_26;
				float float_2 = (float)@struct.double_28;
				float theECMBandwidth = (float)@struct.double_27;
				float theECMNumberofTargets = @struct.long_15;
				float float_3 = (float)@struct.double_4;
				bool bool_ = @struct.bool_1;
				int thePassiveInput = default(int);
				sensor = new Sensor(ref sqliteConnection_0, int_1, name, theSensorType, role, theGeneration, theMaxRange, theMinRange, 0, 0, thePassiveInput, theMaxIntercept, theMaxAltitude, theMinAltitude, theMaxAltitude_ASL, theMinAltitude_ASL, theScanInterval, theRangeResolution, theAngleResolution, theHeightResolution, IsEyeball: false, theMasqueradeAs, theMaxContactsAir, theMaxContactsSurface, theMaxContactsSub, theAvailability, theUpperFreq, theLowerFreq, theUpperFreqIlluminate, theLowerFreqIlluminate, float_, theECMPeakPower, theECMBandwidth, theECMNumberofTargets, float_2, float_3, theMineSweepWidth, theMineMaxSpeed, theVisualDetectZoom, theVisualClassZoom, theIRDetectZoom, theIRClassZoom, bool_);
				sensor.SonarSourceLevel = (short)Math.Round(@struct.double_29);
				sensor.RoleDescription = @struct.Description;
				if (Operators.CompareString(sensor.RoleDescription, "None", false) == 0)
				{
					sensor.RoleDescription = Get_Sensor_Type_String(ref sqliteConnection_0, (int)sensor.Type);
				}
				GetSensorDefaultAcrs(ref sensor, sqliteConnection_0);
				if (sensor.IsPingIntercept)
				{
					sensor.maxRange = 150f;
				}
				result = sensor;
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		return Sensor.GetEyeball(sqliteConnection_0);
	}

	public static void GetSensorDefaultAcrs(ref Sensor theSensor, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.InitThreadStaticSB();
		try
		{
			if (!sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "MiscSensorDefault"))
			{
				Sensor obj = theSensor;
				obj.Coverage.PB1 = true;
				obj.Coverage.PB2 = true;
				obj.Coverage.PMF1 = true;
				obj.Coverage.PMF2 = true;
				obj.Coverage.PMA1 = true;
				obj.Coverage.PMA2 = true;
				obj.Coverage.PS1 = true;
				obj.Coverage.PS2 = true;
				obj.Coverage.SB1 = true;
				obj.Coverage.SB2 = true;
				obj.Coverage.SMF1 = true;
				obj.Coverage.SMF2 = true;
				obj.Coverage.SMA1 = true;
				obj.Coverage.SMA2 = true;
				obj.Coverage.SS1 = true;
				obj.Coverage.SS2 = true;
				obj.Coverage_Illuminate.PB1 = true;
				obj.Coverage_Illuminate.PB2 = true;
				obj.Coverage_Illuminate.PMF1 = true;
				obj.Coverage_Illuminate.PMF2 = true;
				obj.Coverage_Illuminate.PMA1 = true;
				obj.Coverage_Illuminate.PMA2 = true;
				obj.Coverage_Illuminate.PS1 = true;
				obj.Coverage_Illuminate.PS2 = true;
				obj.Coverage_Illuminate.SB1 = true;
				obj.Coverage_Illuminate.SB2 = true;
				obj.Coverage_Illuminate.SMF1 = true;
				obj.Coverage_Illuminate.SMF2 = true;
				obj.Coverage_Illuminate.SMA1 = true;
				obj.Coverage_Illuminate.SMA2 = true;
				obj.Coverage_Illuminate.SS1 = true;
				obj.Coverage_Illuminate.SS2 = true;
				return;
			}
			string_0 = "Select * from MiscSensorDefault WHERE ID = " + Conversions.ToString(theSensor.DBID);
			Struct23 @struct = default(Struct23);
			@struct._Coverage_0 = new PlatformComponent._Coverage();
			@struct._Coverage_1 = new PlatformComponent._Coverage();
			object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sQLiteHelper, string_0));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && (object)objectValue.GetType() == typeof(Struct23))
			{
				@struct = ((objectValue == null) ? default(Struct23) : ((Struct23)objectValue));
			}
			else
			{
				@struct._Coverage_0 = new PlatformComponent._Coverage();
				@struct._Coverage_1 = new PlatformComponent._Coverage();
				DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sQLiteHelper, string_0);
				if (datatableTyped.Rows.Count() == 0)
				{
					return;
				}
				DtrRow dtrRow = datatableTyped.Rows[0];
				@struct._Coverage_0.PB1 = Conversions.ToBoolean(dtrRow["PB1"]);
				@struct._Coverage_0.PB2 = Conversions.ToBoolean(dtrRow["PB2"]);
				@struct._Coverage_0.PMF1 = Conversions.ToBoolean(dtrRow["PMF1"]);
				@struct._Coverage_0.PMF2 = Conversions.ToBoolean(dtrRow["PMF2"]);
				@struct._Coverage_0.PMA1 = Conversions.ToBoolean(dtrRow["PMA1"]);
				@struct._Coverage_0.PMA2 = Conversions.ToBoolean(dtrRow["PMA2"]);
				@struct._Coverage_0.PS1 = Conversions.ToBoolean(dtrRow["PS1"]);
				@struct._Coverage_0.PS2 = Conversions.ToBoolean(dtrRow["PS2"]);
				@struct._Coverage_0.SB1 = Conversions.ToBoolean(dtrRow["SB1"]);
				@struct._Coverage_0.SB2 = Conversions.ToBoolean(dtrRow["SB2"]);
				@struct._Coverage_0.SMF1 = Conversions.ToBoolean(dtrRow["SMF1"]);
				@struct._Coverage_0.SMF2 = Conversions.ToBoolean(dtrRow["SMF2"]);
				@struct._Coverage_0.SMA1 = Conversions.ToBoolean(dtrRow["SMA1"]);
				@struct._Coverage_0.SMA2 = Conversions.ToBoolean(dtrRow["SMA2"]);
				@struct._Coverage_0.SS1 = Conversions.ToBoolean(dtrRow["SS1"]);
				@struct._Coverage_0.SS2 = Conversions.ToBoolean(dtrRow["SS2"]);
				@struct._Coverage_1.PB1 = Conversions.ToBoolean(dtrRow["PB1Max"]);
				@struct._Coverage_1.PB2 = Conversions.ToBoolean(dtrRow["PB2Max"]);
				@struct._Coverage_1.PMF1 = Conversions.ToBoolean(dtrRow["PMF1Max"]);
				@struct._Coverage_1.PMF2 = Conversions.ToBoolean(dtrRow["PMF2Max"]);
				@struct._Coverage_1.PMA1 = Conversions.ToBoolean(dtrRow["PMA1Max"]);
				@struct._Coverage_1.PMA2 = Conversions.ToBoolean(dtrRow["PMA2Max"]);
				@struct._Coverage_1.PS1 = Conversions.ToBoolean(dtrRow["PS1Max"]);
				@struct._Coverage_1.PS2 = Conversions.ToBoolean(dtrRow["PS2Max"]);
				@struct._Coverage_1.SB1 = Conversions.ToBoolean(dtrRow["SB1Max"]);
				@struct._Coverage_1.SB2 = Conversions.ToBoolean(dtrRow["SB2Max"]);
				@struct._Coverage_1.SMF1 = Conversions.ToBoolean(dtrRow["SMF1Max"]);
				@struct._Coverage_1.SMF2 = Conversions.ToBoolean(dtrRow["SMF2Max"]);
				@struct._Coverage_1.SMA1 = Conversions.ToBoolean(dtrRow["SMA1Max"]);
				@struct._Coverage_1.SMA2 = Conversions.ToBoolean(dtrRow["SMA2Max"]);
				@struct._Coverage_1.SS1 = Conversions.ToBoolean(dtrRow["SS1Max"]);
				@struct._Coverage_1.SS2 = Conversions.ToBoolean(dtrRow["SS2Max"]);
				DBCache.SetCustomObject(sQLiteHelper, string_0, @struct);
			}
			Sensor obj2 = theSensor;
			obj2.Coverage.PB1 = @struct._Coverage_0.PB1;
			obj2.Coverage.PB2 = @struct._Coverage_0.PB2;
			obj2.Coverage.PMF1 = @struct._Coverage_0.PMF1;
			obj2.Coverage.PMF2 = @struct._Coverage_0.PMF2;
			obj2.Coverage.PMA1 = @struct._Coverage_0.PMA1;
			obj2.Coverage.PMA2 = @struct._Coverage_0.PMA2;
			obj2.Coverage.PS1 = @struct._Coverage_0.PS1;
			obj2.Coverage.PS2 = @struct._Coverage_0.PS2;
			obj2.Coverage.SB1 = @struct._Coverage_0.SB1;
			obj2.Coverage.SB2 = @struct._Coverage_0.SB2;
			obj2.Coverage.SMF1 = @struct._Coverage_0.SMF1;
			obj2.Coverage.SMF2 = @struct._Coverage_0.SMF2;
			obj2.Coverage.SMA1 = @struct._Coverage_0.SMA1;
			obj2.Coverage.SMA2 = @struct._Coverage_0.SMA2;
			obj2.Coverage.SS1 = @struct._Coverage_0.SS1;
			obj2.Coverage.SS2 = @struct._Coverage_0.SS2;
			obj2.Coverage_Illuminate.PB1 = @struct._Coverage_1.PB1;
			obj2.Coverage_Illuminate.PB2 = @struct._Coverage_1.PB2;
			obj2.Coverage_Illuminate.PMF1 = @struct._Coverage_1.PMF1;
			obj2.Coverage_Illuminate.PMF2 = @struct._Coverage_1.PMF2;
			obj2.Coverage_Illuminate.PMA1 = @struct._Coverage_1.PMA1;
			obj2.Coverage_Illuminate.PMA2 = @struct._Coverage_1.PMA2;
			obj2.Coverage_Illuminate.PS1 = @struct._Coverage_1.PS1;
			obj2.Coverage_Illuminate.PS2 = @struct._Coverage_1.PS2;
			obj2.Coverage_Illuminate.SB1 = @struct._Coverage_1.SB1;
			obj2.Coverage_Illuminate.SB2 = @struct._Coverage_1.SB2;
			obj2.Coverage_Illuminate.SMF1 = @struct._Coverage_1.SMF1;
			obj2.Coverage_Illuminate.SMF2 = @struct._Coverage_1.SMF2;
			obj2.Coverage_Illuminate.SMA1 = @struct._Coverage_1.SMA1;
			obj2.Coverage_Illuminate.SMA2 = @struct._Coverage_1.SMA2;
			obj2.Coverage_Illuminate.SS1 = @struct._Coverage_1.SS1;
			obj2.Coverage_Illuminate.SS2 = @struct._Coverage_1.SS2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void PopulateSensors(ActiveUnit theUnit, int UnitDBID)
	{
		string text = "";
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		try
		{
			if (!theUnit.IsAircraft)
			{
				if (!theUnit.IsWeapon)
				{
					if (theUnit.IsShip)
					{
						text = "DataShipSensors";
					}
					else if (theUnit.IsSubmarine)
					{
						text = "DataSubmarineSensors";
					}
					else if (theUnit.IsFacility)
					{
						text = "DataFacilitySensors";
					}
					else if (!theUnit.IsMobileGroundUnit)
					{
						if (theUnit.IsSatellite)
						{
							text = "DataSatelliteSensors";
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						text = "DataGroundUnitSensors";
					}
				}
				else
				{
					text = "DataWeaponSensors";
				}
			}
			else
			{
				text = "DataAircraftSensors";
			}
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID As SensorID, DataSensor.Type As SensorType, theTable.* FROM DataSensor, ").Append(text).Append(" As theTable WHERE DataSensor.ID = theTable.ComponentID And theTable.ID = ")
				.Append(UnitDBID)
				.Append(" ORDER BY DataSensor.Type, DataSensor.Name ASC");
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			List<Struct24> orBuildCachedQueryResult = DBCache.GetOrBuildCachedQueryResult<Struct24>(theHelper, string_0);
			Operators.CompareString(text, "DataWeaponSensors", false);
			bool flag = CheckColumnExists_SQLite(text, "MastHeight", theUnit.ParentScen.DBConnection);
			foreach (Struct24 item in orBuildCachedQueryResult)
			{
				int int_ = (int)item.long_0;
				SQLiteConnection sqliteConnection_ = theUnit.ParentScen.DBConnection;
				Sensor sensor = GetSensor(int_, ref sqliteConnection_);
				if (sensor.Type == Sensor.Sensor_Type.SensorGroup)
				{
					string_0 = "Select ComponentID from DataSensorSensorGroups where ID = " + Conversions.ToString(sensor.DBID);
					List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "ComponentID");
					foreach (long item2 in orBuildCachedSingleFieldQueryResult)
					{
						int int_2 = (int)item2;
						sqliteConnection_ = theUnit.ParentScen.DBConnection;
						Sensor sensor2 = GetSensor(int_2, ref sqliteConnection_);
						sensor2.IsSensorInGroup = sensor.DBID;
						sensor2.Coverage.PB1 = item.bool_8;
						sensor2.Coverage.PMA1 = item.bool_12;
						sensor2.Coverage.PMF1 = item.bool_10;
						sensor2.Coverage.PS1 = item.bool_14;
						sensor2.Coverage.SB1 = item.bool_0;
						sensor2.Coverage.SMA1 = item.bool_4;
						sensor2.Coverage.SMF1 = item.bool_2;
						sensor2.Coverage.SS1 = item.bool_6;
						sensor2.Coverage.PB2 = item.bool_9;
						sensor2.Coverage.PMA2 = item.bool_13;
						sensor2.Coverage.PMF2 = item.bool_11;
						sensor2.Coverage.PS2 = item.bool_15;
						sensor2.Coverage.SB2 = item.bool_1;
						sensor2.Coverage.SMA2 = item.bool_5;
						sensor2.Coverage.SMF2 = item.bool_3;
						sensor2.Coverage.SS2 = item.bool_7;
						sensor2.Coverage_Illuminate.PB1 = item.bool_24;
						sensor2.Coverage_Illuminate.PMA1 = item.bool_28;
						sensor2.Coverage_Illuminate.PMF1 = item.bool_26;
						sensor2.Coverage_Illuminate.PS1 = item.YvEyBonbfdQ;
						sensor2.Coverage_Illuminate.SB1 = item.bool_16;
						sensor2.Coverage_Illuminate.SMA1 = item.bool_20;
						sensor2.Coverage_Illuminate.SMF1 = item.bool_18;
						sensor2.Coverage_Illuminate.SS1 = item.bool_22;
						sensor2.Coverage_Illuminate.PB2 = item.bool_25;
						sensor2.Coverage_Illuminate.PMA2 = item.WyyyBwHmlo1;
						sensor2.Coverage_Illuminate.PMF2 = item.bool_27;
						sensor2.Coverage_Illuminate.PS2 = item.bool_29;
						sensor2.Coverage_Illuminate.SB2 = item.bool_17;
						sensor2.Coverage_Illuminate.SMA2 = item.bool_21;
						sensor2.Coverage_Illuminate.SMF2 = item.bool_19;
						sensor2.Coverage_Illuminate.SS2 = item.bool_23;
						if (flag)
						{
							sensor2.MastHeight = (int)item.long_7;
						}
						sensor2.ParentPlatform = theUnit;
						theUnit.AddSensor(sensor2);
					}
				}
				else
				{
					sensor.Coverage.PB1 = item.bool_8;
					sensor.Coverage.PMA1 = item.bool_12;
					sensor.Coverage.PMF1 = item.bool_10;
					sensor.Coverage.PS1 = item.bool_14;
					sensor.Coverage.SB1 = item.bool_0;
					sensor.Coverage.SMA1 = item.bool_4;
					sensor.Coverage.SMF1 = item.bool_2;
					sensor.Coverage.SS1 = item.bool_6;
					sensor.Coverage.PB2 = item.bool_9;
					sensor.Coverage.PMA2 = item.bool_13;
					sensor.Coverage.PMF2 = item.bool_11;
					sensor.Coverage.PS2 = item.bool_15;
					sensor.Coverage.SB2 = item.bool_1;
					sensor.Coverage.SMA2 = item.bool_5;
					sensor.Coverage.SMF2 = item.bool_3;
					sensor.Coverage.SS2 = item.bool_7;
					sensor.Coverage_Illuminate.PB1 = item.bool_24;
					sensor.Coverage_Illuminate.PMA1 = item.bool_28;
					sensor.Coverage_Illuminate.PMF1 = item.bool_26;
					sensor.Coverage_Illuminate.PS1 = item.YvEyBonbfdQ;
					sensor.Coverage_Illuminate.SB1 = item.bool_16;
					sensor.Coverage_Illuminate.SMA1 = item.bool_20;
					sensor.Coverage_Illuminate.SMF1 = item.bool_18;
					sensor.Coverage_Illuminate.SS1 = item.bool_22;
					sensor.Coverage_Illuminate.PB2 = item.bool_25;
					sensor.Coverage_Illuminate.PMA2 = item.WyyyBwHmlo1;
					sensor.Coverage_Illuminate.PMF2 = item.bool_27;
					sensor.Coverage_Illuminate.PS2 = item.bool_29;
					sensor.Coverage_Illuminate.SB2 = item.bool_17;
					sensor.Coverage_Illuminate.SMA2 = item.bool_21;
					sensor.Coverage_Illuminate.SMF2 = item.bool_19;
					sensor.Coverage_Illuminate.SS2 = item.bool_23;
					if (flag)
					{
						sensor.MastHeight = (int)item.long_7;
					}
					if (theUnit.IsSatellite && ((Satellite)theUnit).Category == Satellite._SatelliteCategory.GeoStationary && sensor.Role == Sensor.Sensor_Role.Infrared_BMEWS)
					{
						sensor.maxRange = 30000f;
						sensor.float_2 = 2000f;
					}
					sensor.ParentPlatform = theUnit;
					theUnit.AddSensor(sensor);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetSensorCodes(ref Sensor theSensor, int SensorID, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorCodes where ID = ").Append(SensorID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "CodeID");
		int num = orBuildCachedSingleFieldQueryResult.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = orBuildCachedSingleFieldQueryResult[i];
			if (num2 > 2011L)
			{
				if (num2 > 4003L)
				{
					switch (num2)
					{
					case 6001L:
						theSensor.Codes.GeneratesAAWFireControl = true;
						break;
					case 5001L:
						theSensor.Codes.FrequencyAgile = true;
						break;
					case 9102L:
						theSensor.Codes.ShallowWaterCapable_Full = true;
						break;
					case 9101L:
						theSensor.Codes.ShallowWaterCapable_Partial = true;
						break;
					}
					continue;
				}
				if (num2 <= 3003L)
				{
					if (num2 != 2701L)
					{
						long num3 = num2 - 3001L;
						if ((ulong)num3 <= 2uL)
						{
							switch (num3)
							{
							case 0L:
								theSensor.Codes.Pulse_only = true;
								break;
							case 1L:
								theSensor.Codes.Doppler_LDSD_Full = true;
								break;
							case 2L:
								theSensor.Codes.Doppler_LDSD_Limited = true;
								break;
							}
						}
					}
					else
					{
						theSensor.Codes.VisualNightCapable = true;
					}
					continue;
				}
				long num4 = num2 - 3011L;
				if ((ulong)num4 <= 2uL)
				{
					switch (num4)
					{
					case 0L:
						theSensor.Codes.PESA = true;
						continue;
					case 1L:
						theSensor.Codes.AESA = true;
						continue;
					case 2L:
						theSensor.Codes.SyntheticApertureRadar = true;
						continue;
					}
				}
				long num5 = num2 - 4001L;
				if ((ulong)num5 <= 2uL)
				{
					switch (num5)
					{
					case 0L:
						theSensor.Codes.CWI = true;
						break;
					case 1L:
						theSensor.Codes.ICWI = true;
						break;
					case 2L:
						theSensor.Codes.bool_0 = true;
						break;
					}
				}
			}
			else if (num2 <= 1021L)
			{
				if (num2 > 1011L)
				{
					switch (num2)
					{
					case 1021L:
						theSensor.Codes.ContinousTrackingCapable_Visual = true;
						break;
					case 1012L:
						theSensor.Codes.ContinousTrackingCapable_RadarTracker = true;
						break;
					}
					continue;
				}
				long num6 = num2 - 1001L;
				if ((ulong)num6 <= 3uL)
				{
					switch (num6)
					{
					case 0L:
						theSensor.Codes.IFF_Capable = true;
						continue;
					case 1L:
						theSensor.Codes.Classification = true;
						continue;
					case 2L:
						theSensor.Codes.NCTR_JEM = true;
						continue;
					case 3L:
						theSensor.Codes.NCTR_NBILST = true;
						continue;
					}
				}
				if (num2 == 1011L)
				{
					theSensor.Codes.ContinuousTrackingCapable = true;
				}
			}
			else if (num2 <= 2001L)
			{
				long num7 = num2 - 1031L;
				if ((ulong)num7 <= 2uL)
				{
					switch (num7)
					{
					case 0L:
						theSensor.Codes.PeriscopeSearch_Basic = true;
						continue;
					case 1L:
						theSensor.Codes.PeriscopeAndSurfaceSearch_FineRangeResolution = true;
						continue;
					case 2L:
						theSensor.Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing = true;
						continue;
					}
				}
				if (num2 == 2001L)
				{
					theSensor.Codes.TWS = true;
				}
			}
			else
			{
				switch (num2)
				{
				case 2011L:
					theSensor.Codes.LPI = true;
					break;
				case 2002L:
					theSensor.Codes.MTI = true;
					break;
				}
			}
		}
	}

	public static List<string> GetSensorFlagDescriptions(int int_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string text2 = "";
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		List<string> list = new List<string>();
		text = "DataSensorCodes";
		text2 = "EnumSensorCode";
		string_0 = "SELECT EC.* from " + text2 + " as EC, " + text + " as DC where EC.ID = DC.CodeID and DC.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			return list;
		}
		foreach (DataRow row in datatable.Rows)
		{
			list.Add(Conversions.ToString(row["Description"]));
		}
		return list;
	}

	public static void GetSensorCapabilities(ref Sensor theSensor, int SensorID, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		try
		{
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("Select CodeID from DataSensorCapabilities where ID = ").Append(SensorID);
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "CodeID");
			int num = orBuildCachedSingleFieldQueryResult.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				long num2 = orBuildCachedSingleFieldQueryResult[i];
				if (num2 <= 4005L)
				{
					if (num2 <= 1023L)
					{
						long num3 = num2 - 1001L;
						if ((ulong)num3 <= 10uL)
						{
							switch (num3)
							{
							case 0L:
								break;
							case 1L:
								goto IL_01f3;
							case 2L:
								goto IL_0205;
							case 3L:
								goto IL_0217;
							case 4L:
								goto IL_0229;
							case 5L:
								goto IL_023b;
							case 6L:
								goto IL_024d;
							case 10L:
								goto IL_025f;
							default:
								goto IL_0272;
							case 7L:
							case 8L:
							case 9L:
								goto IL_033a;
							}
							theSensor.Capabilities.AirSearch = true;
							continue;
						}
						goto IL_0272;
					}
					long num4 = num2 - 2001L;
					if ((ulong)num4 <= 3uL)
					{
						switch (num4)
						{
						case 0L:
							theSensor.Capabilities.RangeInfo = true;
							continue;
						case 1L:
							theSensor.Capabilities.AltitudeInfo = true;
							continue;
						case 2L:
							theSensor.Capabilities.SpeedInfo = true;
							continue;
						case 3L:
							theSensor.Capabilities.HeadingInfo = true;
							continue;
						}
					}
					long num5 = num2 - 4001L;
					if ((ulong)num5 <= 4uL)
					{
						switch (num5)
						{
						case 0L:
							theSensor.Capabilities.NavigationOnly = true;
							continue;
						case 1L:
							theSensor.Capabilities.GroundMappingOnly = true;
							continue;
						case 2L:
							theSensor.Capabilities.TerrainAvoidanceFollowingOnly = true;
							continue;
						case 3L:
							theSensor.Capabilities.WeatherOnly = true;
							continue;
						case 4L:
							theSensor.Capabilities.WeatherAndNavigationOnly = true;
							continue;
						}
					}
				}
				else
				{
					switch (num2)
					{
					case 9002L:
						theSensor.Capabilities.OTH_SurfaceWave = true;
						continue;
					case 9001L:
						theSensor.Capabilities.OTH_Backscatter = true;
						continue;
					case 10001L:
					case 10002L:
						continue;
					}
				}
				goto IL_033a;
				IL_023b:
				theSensor.Capabilities.PeriscopeSearch = true;
				continue;
				IL_0229:
				theSensor.Capabilities.LandSearch_Mobile = true;
				continue;
				IL_0205:
				theSensor.Capabilities.SubSearch = true;
				continue;
				IL_0272:
				long num6 = num2 - 1021L;
				if ((ulong)num6 <= 2uL)
				{
					switch (num6)
					{
					case 0L:
						theSensor.Capabilities.Mine_Obstacle_Search = true;
						continue;
					case 1L:
						theSensor.Capabilities.TorpedoWarning = true;
						continue;
					case 2L:
						theSensor.Capabilities.MissileApproachWarning = true;
						continue;
					}
				}
				goto IL_033a;
				IL_033a:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				continue;
				IL_01f3:
				theSensor.Capabilities.SurfaceSearch = true;
				continue;
				IL_0217:
				theSensor.Capabilities.LandSearch_Fixed = true;
				continue;
				IL_025f:
				theSensor.Capabilities.SpaceSearch_ABM = true;
				continue;
				IL_024d:
				theSensor.Capabilities.C_RAM = true;
			}
			if (theSensor.Type == Sensor.Sensor_Type.ESM)
			{
				theSensor.Capabilities.AirSearch = true;
				theSensor.Capabilities.SurfaceSearch = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<string> GetSensorCapabilitiesDescriptions(int int_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string text2 = "";
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		List<string> list = new List<string>();
		text = "DataSensorCapabilities";
		text2 = "EnumSensorCapability";
		string_0 = "SELECT EC.* from " + text2 + " as EC, " + text + " as DC where EC.ID = DC.CodeID and DC.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (datatable.Rows.Count == 0)
		{
			return list;
		}
		foreach (DataRow row in datatable.Rows)
		{
			list.Add(Conversions.ToString(row["Description"]));
		}
		return list;
	}

	public static void GetCommDeviceFreqs(ref CommDevice theCommDevice, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * from DataCommCapabilities where ID = ").Append(theCommDevice.DBID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "CodeID");
		int num = orBuildCachedSingleFieldQueryResult.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = orBuildCachedSingleFieldQueryResult[i];
			if ((ulong)(num2 - 1200L) > 1uL && num2 != 1300L && (ulong)(num2 - 1401L) > 1uL)
			{
				Sensor.FrequencyBand item = (Sensor.FrequencyBand)orBuildCachedSingleFieldQueryResult[i];
				theCommDevice.UsedFrequencies.Add(item);
			}
		}
	}

	public static void GetSensorSearchFreqs(ref Sensor theSensor, int SensorID, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		if (theSensor.Type == Sensor.Sensor_Type.NonDetectingEmitter && theSensor.SearchFreqs.Count() == 0 && theSensor.IlluminationFreqs.Count() == 0 && theSensor.MasqueradeAs != 0)
		{
			SensorID = theSensor.MasqueradeAs;
		}
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorFrequencySearchAndTrack where ID = ").Append(SensorID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "Frequency");
		int count = orBuildCachedSingleFieldQueryResult.Count;
		theSensor.SearchFreqs = new Sensor.RadioElectronicFrequency[count - 1 + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor.RadioElectronicFrequency radioElectronicFrequency = new Sensor.RadioElectronicFrequency((Sensor.FrequencyBand)orBuildCachedSingleFieldQueryResult[i]);
			theSensor.SearchFreqs[i] = radioElectronicFrequency;
		}
	}

	public static void GetSensorIlluminationFreqs(ref Sensor theSensor, int SensorID, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		if (theSensor.Type == Sensor.Sensor_Type.NonDetectingEmitter && theSensor.SearchFreqs.Count() == 0 && theSensor.IlluminationFreqs.Count() == 0 && theSensor.MasqueradeAs != 0)
		{
			SensorID = theSensor.MasqueradeAs;
		}
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorFrequencyIlluminate where ID = ").Append(SensorID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, string_0);
		int num = datatableTyped.Rows.Count();
		theSensor.IlluminationFreqs = new Sensor.RadioElectronicFrequency[num - 1 + 1];
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			Sensor.RadioElectronicFrequency radioElectronicFrequency = new Sensor.RadioElectronicFrequency((Sensor.FrequencyBand)Conversions.ToLong(dtrRow["Frequency"]));
			theSensor.IlluminationFreqs[i] = radioElectronicFrequency;
		}
	}

	public static bool CheckFeatureCompatibility(int FeatureID, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "Select count(*) FROM sqlite_master WHERE type='table' AND name='Capabilities'";
		string scalar = DBCache.GetScalar(theHelper, theQuery);
		int result;
		if (!string.IsNullOrEmpty(scalar))
		{
			if (Versioned.IsNumeric((object)scalar))
			{
				if (Conversions.ToInteger(scalar) == 0)
				{
					return false;
				}
				if (FeatureID == 0)
				{
					return true;
				}
				theQuery = "SELECT Count(*) from Capabilities where ID='" + Conversions.ToString(FeatureID) + "'";
				return Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery)) > 0;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static XSection[] GetXSections(ActiveUnit theUnit)
	{
		if (theUnit.IsAggregatedUnit)
		{
			return ((AggregateGroundUnit)theUnit).GetXSections();
		}
		string value = "";
		SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			value = "DataAircraftSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			value = "DataShipSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			value = "DataSubmarineSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			value = "DataFacilitySignatures";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			value = "DataWeaponSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			value = "DataSatelliteSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			value = "DataGroundUnitSignatures";
			break;
		}
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select * From ").Append(value).Append(" as theTable where theTable.ID = ")
			.Append(theUnit.DBID);
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, GameGeneral.ThreadStaticSB.ToString());
		int num = datatableTyped.Rows.Count();
		XSection[] array = new XSection[num - 1 + 1];
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			XSection xSection = new XSection((XSection._SignatureType)Conversions.ToShort(dtrRow["Type"]), Conversions.ToSingle(dtrRow["Front"]), Conversions.ToSingle(dtrRow["Side"]), Conversions.ToSingle(dtrRow["Rear"]), 0f);
			array[i] = xSection;
		}
		return array;
	}

	public static void PopulateFuel(ActiveUnit theUnit, int UnitDBID)
	{
		string value = "";
		try
		{
			SQLiteHelper theHelper = new SQLiteHelper(theUnit.ParentScen.DBConnection);
			switch (theUnit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				value = "DataAircraftFuel";
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				value = "DataShipFuel";
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				value = "DataSubmarineFuel";
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				value = "DataFacilityFuel";
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				value = "DataWeaponFuel";
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				value = "DataGroundUnitFuel";
				break;
			}
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("Select * From ").Append(value).Append(" as theTable where theTable.ID = ")
				.Append(UnitDBID);
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "ComponentID");
			int num = orBuildCachedSingleFieldQueryResult.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				GameGeneral.ThreadStaticSB.Clear();
				GameGeneral.ThreadStaticSB.Append("Select * From DataFuel where ID = ").Append(orBuildCachedSingleFieldQueryResult[i].ToString());
				string_0 = GameGeneral.ThreadStaticSB.ToString();
				Struct25 @struct = DBCache.GetOrBuildCachedQueryResult<Struct25>(theHelper, string_0).First();
				FuelRec fuelRec = new FuelRec((int)@struct.long_0, (short)@struct.Type);
				fuelRec.DBID = (int)@struct.ID;
				theUnit.AddFuelRec(fuelRec);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101291", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static int GetMountIDByName(string theName, SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT ID from DataMount where Name='" + theName + "'";
		return Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery));
	}

	public static string GetMountName(int int_0, ref Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string theQuery = "SELECT Name from DataMount where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(theHelper, theQuery);
	}

	public static CargoType GetMountCargoType(int int_0, ref SQLiteConnection theConn)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theConn);
		string theQuery = "SELECT Cargo_Type from DataMount where ID='" + Conversions.ToString(int_0) + "'";
		return (CargoType)Conversions.ToInteger(DBCache.GetScalar(theHelper, theQuery));
	}

	public static int GetNearestAimpointfacilityMatchForThisMount(int MountID, ref Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "SELECT ID, Name from DataFacility where MountsAreAimpoints<>0 AND ID in (Select ID from DataFacilityMounts where ComponentID = " + Conversions.ToString(MountID) + ")";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		switch (datatable.Rows.Count)
		{
		default:
		{
			string mountName = GetMountName(MountID, ref theScen);
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (DataRow row in datatable.Rows)
			{
				dictionary.Add(Conversions.ToInteger(row["ID"]), Misc.LevenshteinDistance(mountName, Conversions.ToString(row["Name"])));
			}
			return dictionary.OrderBy([SpecialName] (KeyValuePair<int, int> theKVP) => theKVP.Value).ElementAtOrDefault(0).Key;
		}
		case 1:
			return Conversions.ToInteger(datatable.Rows[0]["ID"]);
		case 0:
			return 0;
		}
	}

	public static Mount GetMount(int int_0, ref Scenario theScen, bool LoadComponents = true)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("Select DataMount.* from DataMount WHERE DataMount.ID = ").Append(int_0);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(theHelper, string_0));
		Struct26 @struct;
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && (object)objectValue.GetType() == typeof(Struct26))
		{
			@struct = ((objectValue == null) ? default(Struct26) : ((Struct26)objectValue));
		}
		else
		{
			DataTableTyped datatableTyped = DBCache.GetDatatableTyped(theHelper, string_0);
			if (datatableTyped.Rows.Count() == 0)
			{
				throw new PlatformComponentNotFoundException();
			}
			DtrRow dtrRow = datatableTyped.Rows[0];
			@struct = new Struct26
			{
				ID = int_0,
				Name = Conversions.ToString(dtrRow["Name"]),
				armorRating_0 = (GlobalVariables.ArmorRating)Conversions.ToShort(dtrRow["ArmorGeneral"]),
				int_0 = Conversions.ToInteger(dtrRow["ROF"]),
				int_2 = Conversions.ToInteger(dtrRow["MagazineROF"]),
				int_1 = Conversions.ToInteger(dtrRow["Capacity"]),
				int_3 = Conversions.ToInteger(dtrRow["MagazineCapacity"]),
				bool_4 = Conversions.ToBoolean(dtrRow["Autonomous"]),
				bool_0 = Conversions.ToBoolean(dtrRow["Logistic"]),
				bool_2 = Conversions.ToBoolean(dtrRow["CanHotReload"]),
				bool_5 = Conversions.ToBoolean(dtrRow["LocalControl"]),
				bool_3 = Conversions.ToBoolean(dtrRow["Trainable"]),
				DamagePoints = Conversions.ToSingle(dtrRow["DamagePoints"]),
				bool_1 = Conversions.ToBoolean(dtrRow["ReserveTarget"])
			};
			if (datatableTyped.Columns.Contains("Hypothetical"))
			{
				@struct.bool_6 = Conversions.ToBoolean(dtrRow["Hypothetical"]);
			}
			if (datatableTyped.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Crew"])))
					{
						@struct.int_4 = Conversions.ToInteger(dtrRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Area"])))
					{
						@struct.float_2 = Conversions.ToSingle(dtrRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Type"])))
					{
						@struct.cargoType_0 = (CargoType)Conversions.ToInteger(dtrRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Mass"])))
					{
						@struct.float_1 = Conversions.ToSingle(dtrRow["Cargo_Mass"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_ParadropCapable"])))
					{
						@struct.bool_7 = Conversions.ToBoolean(dtrRow["Cargo_ParadropCapable"]);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (datatableTyped.Columns.Contains("MobileUnitCategory") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["MobileUnitCategory"])))
				{
					@struct._MobileUnitCategory_0 = (IMobileGroundUnit._MobileUnitCategory)Math.Round((double)Conversions.ToInteger(dtrRow["MobileUnitCategory"]) / 1000.0);
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			DBCache.SetCustomObject(theHelper, string_0, @struct);
		}
		Mount mount = null;
		mount = new Mount();
		Mount mount2 = mount;
		mount2.DBID = int_0;
		mount2.Name = @struct.Name;
		mount2.ArmorRating = @struct.armorRating_0;
		mount2.ROF = @struct.int_0;
		mount2.MountMagazine.ROF = @struct.int_2;
		mount2.MaxCapacity = @struct.int_1;
		mount2.MountMagazine.Capacity = @struct.int_3;
		mount2.IsAutonomous = @struct.bool_4;
		mount2.IsLogistic = @struct.bool_0;
		mount2.CanHotReload = @struct.bool_2;
		mount2.LocalControl = @struct.bool_5;
		mount2.IsTrainable = @struct.bool_3;
		mount2.DP = @struct.DamagePoints;
		mount2.ReserveTarget = @struct.bool_1;
		mount2.Hypothetical = @struct.bool_6;
		mount2.Cargo_Crew = @struct.int_4;
		mount2.Cargo_Area = @struct.float_2;
		mount2.Cargo_Type = @struct.cargoType_0;
		mount2.Cargo_Mass = @struct.float_1;
		mount2.Cargo_ParadropCapable = @struct.bool_7;
		mount2.MobileUnitCategory = @struct._MobileUnitCategory_0;
		smethod_3(theScen, ref mount);
		GetMountDefaultArcs(ref mount, theScen.DBConnection);
		if (LoadComponents)
		{
			PopulateMountSensors(ref mount, int_0, theScen.DBConnection);
			PopulateMountWeapons(ref theScen, ref mount, int_0);
			PopulateMountMagazineWeapons(ref theScen, ref mount, int_0);
		}
		PopulateMountComms(ref mount, int_0, theScen);
		PopulateMountMissingCargoData(mount);
		return mount;
	}

	public static void GetMountDefaultArcs(ref Mount theMount, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "MiscMountDefault"))
		{
			string_0 = "Select * from MiscMountDefault WHERE ID = " + Conversions.ToString(theMount.DBID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_0);
			if (datatable.Rows.Count > 0)
			{
				DataRow dataRow = datatable.Rows[0];
				Mount obj = theMount;
				obj.Coverage.PB1 = Conversions.ToBoolean(dataRow["PB1"]);
				obj.Coverage.PB2 = Conversions.ToBoolean(dataRow["PB2"]);
				obj.Coverage.PMF1 = Conversions.ToBoolean(dataRow["PMF1"]);
				obj.Coverage.PMF2 = Conversions.ToBoolean(dataRow["PMF2"]);
				obj.Coverage.PMA1 = Conversions.ToBoolean(dataRow["PMA1"]);
				obj.Coverage.PMA2 = Conversions.ToBoolean(dataRow["PMA2"]);
				obj.Coverage.PS1 = Conversions.ToBoolean(dataRow["PS1"]);
				obj.Coverage.PS2 = Conversions.ToBoolean(dataRow["PS2"]);
				obj.Coverage.SB1 = Conversions.ToBoolean(dataRow["SB1"]);
				obj.Coverage.SB2 = Conversions.ToBoolean(dataRow["SB2"]);
				obj.Coverage.SMF1 = Conversions.ToBoolean(dataRow["SMF1"]);
				obj.Coverage.SMF2 = Conversions.ToBoolean(dataRow["SMF2"]);
				obj.Coverage.SMA1 = Conversions.ToBoolean(dataRow["SMA1"]);
				obj.Coverage.SMA2 = Conversions.ToBoolean(dataRow["SMA2"]);
				obj.Coverage.SS1 = Conversions.ToBoolean(dataRow["SS1"]);
				obj.Coverage.SS2 = Conversions.ToBoolean(dataRow["SS2"]);
			}
		}
		else
		{
			Mount obj2 = theMount;
			obj2.Coverage.PB1 = true;
			obj2.Coverage.PB2 = true;
			obj2.Coverage.PMF1 = true;
			obj2.Coverage.PMF2 = true;
			obj2.Coverage.PMA1 = true;
			obj2.Coverage.PMA2 = true;
			obj2.Coverage.PS1 = true;
			obj2.Coverage.PS2 = true;
			obj2.Coverage.SB1 = true;
			obj2.Coverage.SB2 = true;
			obj2.Coverage.SMF1 = true;
			obj2.Coverage.SMF2 = true;
			obj2.Coverage.SMA1 = true;
			obj2.Coverage.SMA2 = true;
			obj2.Coverage.SS1 = true;
			obj2.Coverage.SS2 = true;
		}
	}

	public static void PopulateMounts(ref Scenario theScen, ref ActiveUnit theUnit, int UnitDBID)
	{
		string text = "";
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		int num;
		if (theUnit.IsAircraft)
		{
			text = "DataAircraftMounts";
			num = 5;
		}
		else if (theUnit.IsWeapon)
		{
			text = "DataWeaponMounts";
			num = 5;
		}
		else if (!theUnit.IsShip)
		{
			if (theUnit.IsSubmarine)
			{
				text = "DataSubmarineMounts";
				num = 5;
			}
			else if (theUnit.IsFacility)
			{
				text = "DataFacilityMounts";
				num = 5;
			}
			else if (theUnit.IsMobileGroundUnit)
			{
				text = "DataGroundUnitMounts";
				num = 5;
			}
			else if (theUnit.IsSatellite)
			{
				text = "DataSatelliteMounts";
				num = 5;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 5;
			}
			else
			{
				num = 5;
			}
		}
		else
		{
			text = "DataShipMounts";
			num = 5;
		}
		string[] array = new string[num];
		array[0] = "SELECT DataMount.*, theTable.PB1, theTable.PB2, theTable.PMF1, theTable.PMF2, theTable.PMA1, theTable.PMA2, theTable.PS1, theTable.PS2, theTable.SB1, theTable.SB2, theTable.SMF1, theTable.SMF2, theTable.SMA1, theTable.SMA2, theTable.SS1, theTable.SS2 FROM DataMount, ";
		array[1] = text;
		array[2] = " AS theTable WHERE DataMount.ID = theTable.ComponentID And theTable.ID = ";
		array[3] = Conversions.ToString(UnitDBID);
		array[4] = " ORDER BY DataMount.Name ASC";
		string_0 = string.Concat(array);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num2 = datatable.Rows.Count - 1;
		for (int i = 0; i <= num2; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			Mount theMount = new Mount();
			Mount mount = theMount;
			mount.ParentPlatform = theUnit;
			mount.DBID = Conversions.ToInteger(dataRow["ID"]);
			mount.Name = Conversions.ToString(dataRow["Name"]);
			mount.ArmorRating = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			mount.ROF = Conversions.ToInteger(dataRow["ROF"]);
			mount.MountMagazine.ROF = Conversions.ToInteger(dataRow["MagazineROF"]);
			mount.MaxCapacity = Conversions.ToInteger(dataRow["Capacity"]);
			mount.MountMagazine.Capacity = Conversions.ToInteger(dataRow["MagazineCapacity"]);
			mount.IsAutonomous = Conversions.ToBoolean(dataRow["Autonomous"]);
			mount.IsLogistic = Conversions.ToBoolean(dataRow["Logistic"]);
			mount.CanHotReload = Conversions.ToBoolean(dataRow["CanHotReload"]);
			mount.LocalControl = Conversions.ToBoolean(dataRow["LocalControl"]);
			mount.IsTrainable = Conversions.ToBoolean(dataRow["Trainable"]);
			mount.DP = Conversions.ToSingle(dataRow["DamagePoints"]);
			mount.ReserveTarget = Conversions.ToBoolean(dataRow["ReserveTarget"]);
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
			{
				mount.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
			{
				mount.Cargo_Area = Conversions.ToInteger(dataRow["Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
			{
				mount.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
			{
				mount.Cargo_Mass = Conversions.ToInteger(dataRow["Cargo_Mass"]);
			}
			mount.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
			mount.Coverage.PB1 = Conversions.ToBoolean(dataRow["PB1"]);
			mount.Coverage.PB2 = Conversions.ToBoolean(dataRow["PB2"]);
			mount.Coverage.PMF1 = Conversions.ToBoolean(dataRow["PMF1"]);
			mount.Coverage.PMF2 = Conversions.ToBoolean(dataRow["PMF2"]);
			mount.Coverage.PMA1 = Conversions.ToBoolean(dataRow["PMA1"]);
			mount.Coverage.PMA2 = Conversions.ToBoolean(dataRow["PMA2"]);
			mount.Coverage.PS1 = Conversions.ToBoolean(dataRow["PS1"]);
			mount.Coverage.PS2 = Conversions.ToBoolean(dataRow["PS2"]);
			mount.Coverage.SB1 = Conversions.ToBoolean(dataRow["SB1"]);
			mount.Coverage.SB2 = Conversions.ToBoolean(dataRow["SB2"]);
			mount.Coverage.SMF1 = Conversions.ToBoolean(dataRow["SMF1"]);
			mount.Coverage.SMF2 = Conversions.ToBoolean(dataRow["SMF2"]);
			mount.Coverage.SMA1 = Conversions.ToBoolean(dataRow["SMA1"]);
			mount.Coverage.SMA2 = Conversions.ToBoolean(dataRow["SMA2"]);
			mount.Coverage.SS1 = Conversions.ToBoolean(dataRow["SS1"]);
			mount.Coverage.SS2 = Conversions.ToBoolean(dataRow["SS2"]);
			mount = null;
			PopulateMountSensors(ref theMount, Conversions.ToInteger(dataRow["ID"]), theScen.DBConnection);
			PopulateMountComms(ref theMount, Conversions.ToInteger(dataRow["ID"]), theScen);
			PopulateMountWeapons(ref theScen, ref theMount, Conversions.ToInteger(dataRow["ID"]));
			PopulateMountMagazineWeapons(ref theScen, ref theMount, Conversions.ToInteger(dataRow["ID"]));
			PopulateMountMissingCargoData(theMount);
			smethod_3(theScen, ref theMount);
			theUnit.Mounts.Add(theMount);
		}
	}

	public static void PopulateMountMissingCargoData(Mount theMount)
	{
		if (theMount.Cargo_Type == CargoType.Personnel && (theMount.Cargo_Mass == 0f || theMount.Cargo_Area == 0f))
		{
			theMount.Cargo_Mass = (float)Math.Round((float)theMount.Cargo_Crew * Mount.PersonnelMass, 1);
			theMount.Cargo_Area = (float)Math.Round((float)theMount.Cargo_Crew * Mount.PersonnelArea, 2);
		}
	}

	public static void PopulateMountComms(ref Mount theMount, int int_0, Scenario theScen)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string text = "";
		if (!Comms_State_Cached)
		{
			Comms_HasQualityTable = false;
			Comms_HasLatencyTable = false;
			Comms_HasQualityCol = false;
			Comms_HasLatencyCol = false;
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(theScen.DBConnection))
			{
				sQLiteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='EnumCommQuality'";
				Comms_HasQualityTable = sQLiteCommand.ExecuteScalar() != null;
				Comms_HasQualityCol = false;
				sQLiteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='EnumCommLatency'";
				Comms_HasLatencyTable = sQLiteCommand.ExecuteScalar() != null;
				Comms_HasLatencyCol = false;
				sQLiteCommand.CommandText = "PRAGMA table_info(DataComm)";
				using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
				while (sQLiteDataReader.Read())
				{
					string? text2 = sQLiteDataReader["name"].ToString();
					if (text2.Equals("QualityGrade", StringComparison.OrdinalIgnoreCase))
					{
						Comms_HasQualityCol = true;
					}
					if (text2.Equals("LatencyGrade", StringComparison.OrdinalIgnoreCase))
					{
						Comms_HasLatencyCol = true;
					}
				}
			}
			Comms_QualityGradeSource = ((!Comms_HasQualityCol) ? "NULL" : "DataComm.QualityGrade");
			Comms_LatencyGradeSource = ((!Comms_HasLatencyCol) ? "NULL" : "DataComm.LatencyGrade");
			Comms_QualityCols = ((!Comms_HasQualityTable || !Comms_HasQualityCol) ? "NULL AS QualityDescription, NULL AS QualityCapability, NULL AS QualityExample, " : "q.Description AS QualityDescription, q.Capability AS QualityCapability, q.Example AS QualityExample, ");
			Comms_LatencyCols = ((!Comms_HasLatencyTable || !Comms_HasLatencyCol) ? "NULL AS LatencyDescription, NULL AS LatencyCapability, NULL AS LatencyExample, " : "l.Description AS LatencyDescription, l.Capability AS LatencyCapability, l.Example AS LatencyExample, ");
			Comms_SQLString = "SELECT DataComm.ID AS CommID, DataComm.Name, DataComm.Type, DataComm.Range, DataComm.Channels, DataComm.IsOptional, " + Comms_QualityGradeSource + " AS QualityGrade, " + Comms_LatencyGradeSource + " AS LatencyGrade, " + Comms_QualityCols + Comms_LatencyCols + "theTable.ID AS MountTableID, theTable.ComponentID FROM DataComm INNER JOIN DataMountComms AS theTable ON DataComm.ID = theTable.ComponentID ";
			if (Comms_HasQualityTable && Comms_HasQualityCol)
			{
				Comms_SQLString += "LEFT JOIN EnumCommQuality q ON DataComm.QualityGrade = q.ID ";
			}
			int comms_State_Cached;
			if (Comms_HasLatencyTable && Comms_HasLatencyCol)
			{
				Comms_SQLString += "LEFT JOIN EnumCommLatency l ON DataComm.LatencyGrade = l.ID ";
				comms_State_Cached = 1;
			}
			else
			{
				comms_State_Cached = 1;
			}
			Comms_State_Cached = (byte)comms_State_Cached != 0;
		}
		text = Comms_SQLString + " WHERE theTable.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, text);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			CommDevice commDevice = new CommDevice(theQualityGrade: (!(Comms_HasQualityTable & Comms_HasQualityCol)) ? ((CommDevice.EnumCommQuality)2147483647) : ((CommDevice.EnumCommQuality)Conversions.ToInteger(dataRow["QualityGrade"])), theLatencyGrade: (Comms_HasLatencyTable & Comms_HasLatencyCol) ? ((CommDevice.EnumCommLatency)Conversions.ToInteger(dataRow["LatencyGrade"])) : ((CommDevice.EnumCommLatency)2147483647), theParent: theMount.ParentPlatform, theScen: theScen, int_2: Conversions.ToInteger(dataRow["CommID"]), theName: Conversions.ToString(dataRow["Name"]), theType: (CommDevice.CommLinkType)Conversions.ToInteger(dataRow["Type"]), theRange: Conversions.ToSingle(dataRow["Range"]), theMaxChannels: Conversions.ToInteger(dataRow["Channels"]), DeviceIsOptional: Conversions.ToBoolean(dataRow["IsOptional"]));
			try
			{
				if (Comms_HasQualityTable & Comms_HasQualityCol)
				{
					commDevice.QualityGradeinfo = new CommDevice.QualityGradeDetail(Conversions.ToInteger(dataRow["QualityGrade"]), Conversions.ToString(dataRow["QualityDescription"]), Conversions.ToString(dataRow["QualityCapability"]), Conversions.ToString(dataRow["QualityExample"]));
				}
				else
				{
					commDevice.QualityGradeinfo = new CommDevice.QualityGradeDetail();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (!commDevice.IsWeaponDataLink() && !theScen.CommDALError.ContainsKey(commDevice.DBID))
				{
					theScen.CommDALError.Add(commDevice.DBID, "Comm device  with DBID " + commDevice.DBID + " has no quality grade info value");
				}
				commDevice.QualityGradeinfo = new CommDevice.QualityGradeDetail();
				ProjectData.ClearProjectError();
			}
			try
			{
				if (!(Comms_HasQualityTable & Comms_HasQualityCol))
				{
					commDevice.LatencyGradenfo = new CommDevice.LatencyGradeDetail();
				}
				else
				{
					commDevice.LatencyGradenfo = new CommDevice.LatencyGradeDetail(Conversions.ToInteger(dataRow["LatencyGrade"]), Conversions.ToString(dataRow["LatencyDescription"]), Conversions.ToString(dataRow["LatencyCapability"]), Conversions.ToString(dataRow["LatencyExample"]));
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (GameGeneral.Beta_PlatformComms && !commDevice.IsWeaponDataLink() && !theScen.CommDALError.ContainsKey(commDevice.DBID))
				{
					theScen.CommDALError.Add(commDevice.DBID, "Comm device " + commDevice.Name + " with DBID " + commDevice.DBID + "has no Latency info value");
				}
				commDevice.LatencyGradenfo = new CommDevice.LatencyGradeDetail();
				ProjectData.ClearProjectError();
			}
			ArrayExtensions.Add(ref theMount.CommDevices, commDevice);
		}
	}

	public static void PopulateMountSensors(ref Mount theMount, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string_0 = "SELECT S.ID from DataMountSensors as MS, DataSensor as S where S.ID = MS.ComponentID and MS.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		if (!Information.IsNothing((object)theMount.ParentPlatform))
		{
			_ = theMount.ParentPlatform;
		}
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = GetSensor(Conversions.ToInteger(datatable.Rows[i]["ID"]), ref sqliteConnection_0);
			sensor.ParentPlatform = theMount.ParentPlatform;
			sensor.Coverage.PB1 = theMount.Coverage.PB1;
			sensor.Coverage.PMA1 = theMount.Coverage.PMA1;
			sensor.Coverage.PMF1 = theMount.Coverage.PMF1;
			sensor.Coverage.PS1 = theMount.Coverage.PS1;
			sensor.Coverage.SB1 = theMount.Coverage.SB1;
			sensor.Coverage.SMA1 = theMount.Coverage.SMA1;
			sensor.Coverage.SMF1 = theMount.Coverage.SMF1;
			sensor.Coverage.SS1 = theMount.Coverage.SS1;
			sensor.Coverage.PB2 = theMount.Coverage.PB2;
			sensor.Coverage.PMA2 = theMount.Coverage.PMA2;
			sensor.Coverage.PMF2 = theMount.Coverage.PMF2;
			sensor.Coverage.PS2 = theMount.Coverage.PS2;
			sensor.Coverage.SB2 = theMount.Coverage.SB2;
			sensor.Coverage.SMA2 = theMount.Coverage.SMA2;
			sensor.Coverage.SMF2 = theMount.Coverage.SMF2;
			sensor.Coverage.SS2 = theMount.Coverage.SS2;
			sensor.Coverage_Illuminate.PB1 = theMount.Coverage.PB1;
			sensor.Coverage_Illuminate.PMA1 = theMount.Coverage.PMA1;
			sensor.Coverage_Illuminate.PMF1 = theMount.Coverage.PMF1;
			sensor.Coverage_Illuminate.PS1 = theMount.Coverage.PS1;
			sensor.Coverage_Illuminate.SB1 = theMount.Coverage.SB1;
			sensor.Coverage_Illuminate.SMA1 = theMount.Coverage.SMA1;
			sensor.Coverage_Illuminate.SMF1 = theMount.Coverage.SMF1;
			sensor.Coverage_Illuminate.SS1 = theMount.Coverage.SS1;
			sensor.Coverage_Illuminate.PB2 = theMount.Coverage.PB2;
			sensor.Coverage_Illuminate.PMA2 = theMount.Coverage.PMA2;
			sensor.Coverage_Illuminate.PMF2 = theMount.Coverage.PMF2;
			sensor.Coverage_Illuminate.PS2 = theMount.Coverage.PS2;
			sensor.Coverage_Illuminate.SB2 = theMount.Coverage.SB2;
			sensor.Coverage_Illuminate.SMA2 = theMount.Coverage.SMA2;
			sensor.Coverage_Illuminate.SMF2 = theMount.Coverage.SMF2;
			sensor.Coverage_Illuminate.SS2 = theMount.Coverage.SS2;
			theMount.AddSensor(sensor);
		}
	}

	public static void PopulateMountWeapons(ref Scenario theScen, ref Mount theMount, int int_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "SELECT DataWeaponRecord.* FROM DataMountWeapons, DataWeaponRecord, DataWeapon WHERE DataMountWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMountWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec item = new WeaponRec(ref theScen, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
			theMount.MountWeapons.Add(item);
		}
	}

	public static void PopulateMountMagazineWeapons(ref Scenario theScen, ref Mount theMount, int int_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
		string_0 = "SELECT DataWeaponRecord.*, DataMountMagazineWeapons.ComponentNumber FROM DataMountMagazineWeapons, DataWeaponRecord, DataWeapon WHERE DataMountMagazineWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMountMagazineWeapons.ID  = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(theHelper, string_0);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec item = new WeaponRec(ref theScen, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
			theMount.MountMagazine.Weapons.Add(item);
		}
	}

	public static void PopulateWeaponTargets(ref WeaponTargets theWeaponTargets, int WeaponID, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.InitThreadStaticSB();
		GameGeneral.ThreadStaticSB.Append("SELECT CodeID from DataWeaponTargets where ID = ").Append(WeaponID);
		string_0 = GameGeneral.ThreadStaticSB.ToString();
		List<long> orBuildCachedSingleFieldQueryResult = DBCache.GetOrBuildCachedSingleFieldQueryResult<long>(theHelper, string_0, "CodeID");
		int count = orBuildCachedSingleFieldQueryResult.Count;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = orBuildCachedSingleFieldQueryResult[i];
			if (num2 > 3004L)
			{
				if (num2 > 5001L)
				{
					switch (num2)
					{
					case 9001L:
						theWeaponTargets.AirBaseSingleUnit = true;
						continue;
					case 6001L:
						theWeaponTargets.AerostatMooring = true;
						continue;
					}
				}
				else
				{
					long num3 = num2 - 4001L;
					if ((ulong)num3 <= 2uL)
					{
						switch (num3)
						{
						case 0L:
							theWeaponTargets.MobileTarget_Soft = true;
							continue;
						case 1L:
							theWeaponTargets.MobileTarget_Hard = true;
							continue;
						case 2L:
							theWeaponTargets.MobileTarget_Personnel = true;
							continue;
						}
					}
					if (num2 == 5001L)
					{
						theWeaponTargets.UnderwaterStructure = true;
						continue;
					}
				}
			}
			else
			{
				long num4 = num2 - 1001L;
				if ((ulong)num4 <= 4uL)
				{
					switch (num4)
					{
					case 0L:
						theWeaponTargets.Aircraft = true;
						continue;
					case 1L:
						theWeaponTargets.Helicopter = true;
						continue;
					case 2L:
						theWeaponTargets.Missile = true;
						continue;
					case 3L:
						theWeaponTargets.Satellite = true;
						continue;
					case 4L:
						theWeaponTargets.RAMB = true;
						continue;
					}
				}
				long num5 = num2 - 2001L;
				if ((ulong)num5 <= 3uL)
				{
					switch (num5)
					{
					case 0L:
						theWeaponTargets.SurfaceVessel = true;
						continue;
					case 1L:
						theWeaponTargets.Submarine = true;
						continue;
					case 2L:
						theWeaponTargets.Mine = true;
						continue;
					case 3L:
						theWeaponTargets.Torpedo = true;
						continue;
					}
				}
				long num6 = num2 - 3001L;
				if ((ulong)num6 <= 3uL)
				{
					switch (num6)
					{
					case 0L:
						theWeaponTargets.LandStructure_Soft = true;
						continue;
					case 1L:
						theWeaponTargets.LandStructure_Hard = true;
						continue;
					case 2L:
						theWeaponTargets.Runway = true;
						continue;
					case 3L:
						theWeaponTargets.Radar = true;
						continue;
					}
				}
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (count > 1)
		{
			theWeaponTargets.MultipleTypes = true;
		}
	}

	public static CargoContainer GetCargoContainer(int ContainerDBID, ref Scenario theScen, bool LoadComponents = true)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		CargoContainer result;
		if (sQLiteHelper.CheckTableExists(GameGeneral.ThreadStaticSB, "DataContainer"))
		{
			GameGeneral.InitThreadStaticSB();
			GameGeneral.ThreadStaticSB.Append("Select DataContainer.* from DataContainer WHERE DataContainer.ID = ").Append(ContainerDBID);
			string_0 = GameGeneral.ThreadStaticSB.ToString();
			DataTableTyped datatableTyped;
			try
			{
				datatableTyped = DBCache.GetDatatableTyped(sQLiteHelper, string_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = null;
				ProjectData.ClearProjectError();
				goto IL_01d4;
			}
			if (datatableTyped.Rows.Count() < 1)
			{
				result = null;
			}
			else
			{
				DtrRow dtrRow = datatableTyped.Rows[0];
				string name = Conversions.ToString(dtrRow["Name"]);
				CargoContainer.CargoContainerType cargoContainerType = (CargoContainer.CargoContainerType)Conversions.ToInteger(dtrRow["Type"]);
				float num = Conversions.ToSingle(dtrRow["Length"]);
				float num2 = Conversions.ToSingle(dtrRow["Width"]);
				float num3 = Conversions.ToSingle(dtrRow["Height"]);
				bool flag = Conversions.ToBoolean(dtrRow["IsHold"]);
				float wgt = Conversions.ToInteger(dtrRow["Weight"]);
				float payloadCap = Conversions.ToInteger(dtrRow["PayloadCapacity"]);
				float payloadVol = Conversions.ToInteger(dtrRow["CubicCapacity"]);
				bool paradropCapacity = false;
				bool canbeParadropped = false;
				if (CheckColumnExists_SQLite("DataContainer", "Container_ParadropCapable", theScen.DBConnection))
				{
					canbeParadropped = Conversions.ToBoolean(dtrRow["Container_ParadropCapable"]);
				}
				CargoType cargoSize = ((!flag) ? ((cargoContainerType != CargoContainer.CargoContainerType.Pallet) ? GetCargoTypeCategory(num, num2, num3) : GetCargoTypeCategory(num, num2, 0f)) : CargoType.NoCargo);
				result = new CargoContainer(cargoContainerType, cargoSize, num, num2, num3, wgt, payloadCap, payloadVol, flag, paradropCapacity, canbeParadropped)
				{
					Name = name,
					DBID = ContainerDBID
				};
			}
		}
		else
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
		}
		goto IL_01d4;
		IL_01d4:
		return result;
	}

	internal static DockFacility.DockingPhysicalSize GetDockingPhysicalSize(float Length)
	{
		if (Length <= 11f)
		{
			return DockFacility.DockingPhysicalSize.const_1;
		}
		if (Length <= 17f)
		{
			return DockFacility.DockingPhysicalSize.SmallPier;
		}
		if (Length <= 25f)
		{
			return DockFacility.DockingPhysicalSize.MediumPier;
		}
		if (Length <= 45f)
		{
			return DockFacility.DockingPhysicalSize.LargePier;
		}
		if (Length <= 200f)
		{
			return DockFacility.DockingPhysicalSize.const_5;
		}
		return DockFacility.DockingPhysicalSize.const_6;
	}

	internal static DockFacility.DockingPhysicalSize GetAmphibiousVehicleDockingPhysicalSize(float Length)
	{
		if (Length <= 11f)
		{
			return DockFacility.DockingPhysicalSize.VSmallDockDavit;
		}
		if (Length <= 17f)
		{
			return DockFacility.DockingPhysicalSize.SmallDockDavit;
		}
		if (Length <= 25f)
		{
			return DockFacility.DockingPhysicalSize.MediumDock;
		}
		if (Length <= 45f)
		{
			return DockFacility.DockingPhysicalSize.LargeDock;
		}
		return DockFacility.DockingPhysicalSize.None;
	}

	internal static int GetDBRunwayLength(GlobalVariables.RunwayLengthClass RunwayLength)
	{
		int result;
		if (RunwayLength <= GlobalVariables.RunwayLengthClass.Between_451_900m)
		{
			if (RunwayLength <= GlobalVariables.RunwayLengthClass.VTOL)
			{
				switch (RunwayLength)
				{
				case GlobalVariables.RunwayLengthClass.VTOL:
					return 2001;
				case GlobalVariables.RunwayLengthClass.CatapultLaunched:
					return 1101;
				case GlobalVariables.RunwayLengthClass.ManualLaunch:
					return 1002;
				}
				result = 1001;
			}
			else
			{
				switch (RunwayLength)
				{
				case GlobalVariables.RunwayLengthClass.Between_451_900m:
					return 2003;
				case GlobalVariables.RunwayLengthClass.Between_1_450m:
					return 2002;
				case GlobalVariables.RunwayLengthClass.Between_1_250m:
					if (!DBOps.DBHasLegacyRunwayLengthEnum)
					{
						return 3005;
					}
					return 2010;
				}
				result = 1001;
			}
		}
		else if (RunwayLength > GlobalVariables.RunwayLengthClass.Between_2001_2600m)
		{
			switch (RunwayLength)
			{
			case GlobalVariables.RunwayLengthClass.Between_4000_5600m:
				return 2009;
			case GlobalVariables.RunwayLengthClass.Between_3201_4000m:
				return 2008;
			case GlobalVariables.RunwayLengthClass.Between_2601_3200m:
				return 2007;
			}
			result = 1001;
		}
		else
		{
			if (RunwayLength == GlobalVariables.RunwayLengthClass.Between_901_1400m)
			{
				return 2004;
			}
			if (RunwayLength == GlobalVariables.RunwayLengthClass.Between_1401_2000m)
			{
				return 2005;
			}
			if (RunwayLength == GlobalVariables.RunwayLengthClass.Between_2001_2600m)
			{
				return 2006;
			}
			result = 1001;
		}
		return result;
	}

	internal static GlobalVariables.RunwayLengthClass GetRunwayLength(int DBRunwayLength)
	{
		int result;
		if (DBRunwayLength > 1101)
		{
			switch (DBRunwayLength)
			{
			default:
				result = 1001;
				break;
			case 3005:
				return GlobalVariables.RunwayLengthClass.Between_1_250m;
			case 2001:
				return GlobalVariables.RunwayLengthClass.VTOL;
			case 2002:
				return GlobalVariables.RunwayLengthClass.Between_1_450m;
			case 2003:
				return GlobalVariables.RunwayLengthClass.Between_451_900m;
			case 2004:
				return GlobalVariables.RunwayLengthClass.Between_901_1400m;
			case 2005:
				return GlobalVariables.RunwayLengthClass.Between_1401_2000m;
			case 2006:
				return GlobalVariables.RunwayLengthClass.Between_2001_2600m;
			case 2007:
				return GlobalVariables.RunwayLengthClass.Between_2601_3200m;
			case 2008:
				return GlobalVariables.RunwayLengthClass.Between_3201_4000m;
			case 2009:
				return GlobalVariables.RunwayLengthClass.Between_4000_5600m;
			case 2010:
				if (!DBOps.DBHasLegacyRunwayLengthEnum)
				{
					result = 1001;
					break;
				}
				return GlobalVariables.RunwayLengthClass.Between_1_250m;
			}
		}
		else
		{
			if (DBRunwayLength == 1002)
			{
				return GlobalVariables.RunwayLengthClass.ManualLaunch;
			}
			if (DBRunwayLength == 1101)
			{
				return GlobalVariables.RunwayLengthClass.CatapultLaunched;
			}
			result = 1001;
		}
		return (GlobalVariables.RunwayLengthClass)result;
	}

	internal static GlobalVariables.AircraftSizeClass GetAircraftPhysicalSize(int DBAircraftSize)
	{
		switch (DBAircraftSize)
		{
		default:
			return GlobalVariables.AircraftSizeClass.None;
		case 3002:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Mini;
		case 3003:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Small;
		case 3004:
			return GlobalVariables.AircraftSizeClass.UAS_Class2;
		case 2000:
		case 3001:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Micro;
		case 2001:
			return GlobalVariables.AircraftSizeClass.Small;
		case 2002:
			return GlobalVariables.AircraftSizeClass.Medium;
		case 2003:
			return GlobalVariables.AircraftSizeClass.Large;
		case 2004:
			return GlobalVariables.AircraftSizeClass.VLarge;
		case 1001:
			return GlobalVariables.AircraftSizeClass.None;
		}
	}

	internal static int GetDBAircraftPhysicalSize(GlobalVariables.AircraftSizeClass AircraftSize)
	{
		int result;
		switch (AircraftSize)
		{
		default:
			result = 1001;
			goto IL_00a1;
		case GlobalVariables.AircraftSizeClass.VLarge:
			return 2004;
		case GlobalVariables.AircraftSizeClass.Large:
			return 2003;
		case (GlobalVariables.AircraftSizeClass)11:
		case (GlobalVariables.AircraftSizeClass)12:
		case (GlobalVariables.AircraftSizeClass)13:
		case (GlobalVariables.AircraftSizeClass)14:
		case (GlobalVariables.AircraftSizeClass)15:
		case (GlobalVariables.AircraftSizeClass)16:
		case (GlobalVariables.AircraftSizeClass)17:
		case (GlobalVariables.AircraftSizeClass)18:
		case (GlobalVariables.AircraftSizeClass)19:
			result = 1001;
			goto IL_00a1;
		case GlobalVariables.AircraftSizeClass.Medium:
			return 2002;
		case GlobalVariables.AircraftSizeClass.None:
			return 1001;
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
			return 3001;
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
			return 3002;
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
			return 3003;
		case GlobalVariables.AircraftSizeClass.UAS_Class2:
			return 3004;
		case (GlobalVariables.AircraftSizeClass)5:
		case (GlobalVariables.AircraftSizeClass)6:
		case (GlobalVariables.AircraftSizeClass)7:
		case (GlobalVariables.AircraftSizeClass)8:
		case (GlobalVariables.AircraftSizeClass)9:
			result = 1001;
			goto IL_00a1;
		case GlobalVariables.AircraftSizeClass.Small:
			{
				return 2001;
			}
			IL_00a1:
			return result;
		}
	}

	internal static CargoType GetCargoTypeCategory(float RelaventSize)
	{
		if (RelaventSize == 0f)
		{
			return CargoType.NoCargo;
		}
		if (RelaventSize < 1f)
		{
			return CargoType.Personnel;
		}
		if (RelaventSize < 5f)
		{
			return CargoType.SmallCargo;
		}
		if (RelaventSize < 7f)
		{
			return CargoType.MediumCargo;
		}
		if (RelaventSize < 9f)
		{
			return CargoType.LargeCargo;
		}
		return CargoType.const_5;
	}

	internal static CargoType GetCargoTypeCategory(float length, float width, float height)
	{
		if (height == 0f)
		{
			return GetCargoTypeCategory(Math.Min(length, width));
		}
		if (length >= width && length >= height)
		{
			return GetCargoTypeCategory(Math.Max(width, height));
		}
		if (width >= length && width >= height)
		{
			return GetCargoTypeCategory(Math.Max(length, height));
		}
		if (height >= length && height >= width)
		{
			return GetCargoTypeCategory(Math.Max(length, width));
		}
		return CargoType.NoCargo;
	}

	internal static float GetCargoContainerArea(float length, float width)
	{
		float num = length * width;
		if (num > 10f)
		{
			num = (float)Math.Round(num, MidpointRounding.AwayFromZero);
		}
		return num;
	}
}
