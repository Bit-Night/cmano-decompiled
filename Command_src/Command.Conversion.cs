using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Command_Core;
using Command.mdb2sq3;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class Conversion
{
	public static void ConvertToSQLite(string MSAccessPath)
	{
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MSAccessBackend mSAccessBackend = new MSAccessBackend(MSAccessPath);
			string text = CommandLineParametersHelper.databaseTarget;
			if (text == null)
			{
				text = Path.ChangeExtension(MSAccessPath, "db3");
			}
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			SQLiteBackend sQLiteBackend = new SQLiteBackend(text);
			SchemaTablesMetaData schemaTablesMetaData = mSAccessBackend.QuerySchemaDefinition(null);
			foreach (TableMetaData table in schemaTablesMetaData.tables)
			{
				if (table.tableName.Contains("Capabilities") || table.tableName.Contains("Data") || table.tableName.Contains("Enum"))
				{
					mSAccessBackend.QueryTableDefinition(table);
				}
			}
			schemaTablesMetaData.SortTablesByDependencies();
			if (CommandLineParametersHelper.verbose)
			{
				foreach (TableMetaData table2 in schemaTablesMetaData.tables)
				{
					_ = table2;
				}
			}
			sQLiteBackend.CloneSchema(schemaTablesMetaData);
			DateTime now = DateTime.Now;
			foreach (TableMetaData table3 in schemaTablesMetaData.tables)
			{
				if (table3.tableName.Contains("Capabilities") || table3.tableName.Contains("Data") || table3.tableName.Contains("Enum"))
				{
					mSAccessBackend.DumpTableContents(table3, sQLiteBackend);
				}
			}
			_ = DateTime.Now - now;
			smethod_0(text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (!ex2.Message.Contains("SQLite error"))
			{
				throw;
			}
			MessageBox.Show("Missing or corrupted SQLite data detected. Is this a valid MS Access file?");
			throw;
		}
	}

	private static void smethod_0(string string_0)
	{
		SQLiteConnection theConn = new SQLiteConnection("Data Source=" + string_0 + ";Version=3");
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theConn);
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_Capabilities_ID ON Capabilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraft_ID ON DataAircraft (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftCodes_CodeID ON DataAircraftCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftCodes_ID ON DataAircraftCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftComms_ComponentNumber ON DataAircraftComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftComms_ID ON DataAircraftComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftFuel_ComponentNumber ON DataAircraftFuel (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftFuel_ID ON DataAircraftFuel (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftLoadouts_ComponentID ON DataAircraftLoadouts (ComponentID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftLoadouts_ID ON DataAircraftLoadouts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftMounts_ComponentNumber ON DataAircraftMounts (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftMounts_ID ON DataAircraftMounts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftPropulsion_ComponentNumber ON DataAircraftPropulsion (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftPropulsion_ID ON DataAircraftPropulsion (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftSensors_ComponentNumber ON DataAircraftSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftSensors_ID ON DataAircraftSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftSignatures_ID ON DataAircraftSignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataAircraftSignatures_Type ON DataAircraftSignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataCommCapabilities_CodeID ON DataCommCapabilities (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataCommCapabilities_ID ON DataCommCapabilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataCommDirectors_ComponentNumber ON DataCommDirectors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataCommDirectors_ID ON DataCommDirectors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacility_ID ON DataFacility (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityAircraftFacilities_ComponentNumber ON DataFacilityAircraftFacilities (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityAircraftFacilities_ID ON DataFacilityAircraftFacilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityComms_ComponentNumber ON DataFacilityComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityComms_ID ON DataFacilityComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityDockingFacilities_ComponentNumber ON DataFacilityDockingFacilities (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityDockingFacilities_ID ON DataFacilityDockingFacilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityFuel_ComponentNumber ON DataFacilityFuel (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityFuel_ID ON DataFacilityFuel (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityMagazines_ComponentNumber ON DataFacilityMagazines (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityMagazines_ID ON DataFacilityMagazines (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityMounts_ComponentNumber ON DataFacilityMounts (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilityMounts_ID ON DataFacilityMounts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilitySensors_ComponentNumber ON DataFacilitySensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilitySensors_ID ON DataFacilitySensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilitySignatures_ID ON DataFacilitySignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataFacilitySignatures_Type ON DataFacilitySignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataLoadout_LoadoutRole ON DataLoadout (LoadoutRole)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataLoadoutWeapons_ComponentNumber ON DataLoadoutWeapons (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataLoadoutWeapons_ID ON DataLoadoutWeapons (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMagazine_ID ON DataMagazine (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMagazineWeapons_ComponentNumber ON DataMagazineWeapons (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMagazineWeapons_ID ON DataMagazineWeapons (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMount_ID ON DataMount (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountComms_ComponentNumber ON DataMountComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountComms_ID ON DataMountComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountDirectors_ComponentNumber ON DataMountDirectors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountDirectors_ID ON DataMountDirectors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountMagazineWeapons_ComponentNumber ON DataMountMagazineWeapons (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountMagazineWeapons_ID ON DataMountMagazineWeapons (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountSensors_ComponentNumber ON DataMountSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountSensors_ID ON DataMountSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountWeapons_ComponentNumber ON DataMountWeapons (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataMountWeapons_ID ON DataMountWeapons (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataPropulsionPerformance_AltitudeBand ON DataPropulsionPerformance (AltitudeBand)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataPropulsionPerformance_ID ON DataPropulsionPerformance (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataPropulsionPerformance_Throttle ON DataPropulsionPerformance (Throttle)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteCodes_CodeID ON DataSatelliteCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteCodes_ID ON DataSatelliteCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteComms_ComponentNumber ON DataSatelliteComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteComms_ID ON DataSatelliteComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteMounts_ComponentNumber ON DataSatelliteMounts (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteMounts_ID ON DataSatelliteMounts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteOrbits_ComponentNumber ON DataSatelliteOrbits (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteOrbits_ID ON DataSatelliteOrbits (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteSensors_ComponentNumber ON DataSatelliteSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteSensors_ID ON DataSatelliteSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteSignatures_ID ON DataSatelliteSignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSatelliteSignatures_Type ON DataSatelliteSignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorCapabilities_CodeID ON DataSensorCapabilities (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorCapabilities_ID ON DataSensorCapabilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorCodes_CodeID ON DataSensorCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorCodes_ID ON DataSensorCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorFrequencyIlluminate_Frequency ON DataSensorFrequencyIlluminate (Frequency)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorFrequencyIlluminate_ID ON DataSensorFrequencyIlluminate (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorFrequencySearchAndTrack_Frequency ON DataSensorFrequencySearchAndTrack (Frequency)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorFrequencySearchAndTrack_ID ON DataSensorFrequencySearchAndTrack (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorSensorGroups_ComponentNumber ON DataSensorSensorGroups (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSensorSensorGroups_ID ON DataSensorSensorGroups (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipAircraftFacilities_ComponentNumber ON DataShipAircraftFacilities (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipAircraftFacilities_ID ON DataShipAircraftFacilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipCodes_CodeID ON DataShipCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipCodes_ID ON DataShipCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipComms_ComponentNumber ON DataShipComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipComms_ID ON DataShipComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipDockingFacilities_ComponentNumber ON DataShipDockingFacilities (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipDockingFacilities_ID ON DataShipDockingFacilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipFuel_ComponentNumber ON DataShipFuel (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipFuel_ID ON DataShipFuel (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipMagazines_ComponentNumber ON DataShipMagazines (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipMagazines_ID ON DataShipMagazines (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipMounts_ComponentNumber ON DataShipMounts (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipMounts_ID ON DataShipMounts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipPropulsion_ComponentNumber ON DataShipPropulsion (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipPropulsion_ID ON DataShipPropulsion (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipSensors_ComponentNumber ON DataShipSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipSensors_ID ON DataShipSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipSignatures_ID ON DataShipSignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataShipSignatures_Type ON DataShipSignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarine_ID ON DataSubmarine (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineCodes_CodeID ON DataSubmarineCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineCodes_ID ON DataSubmarineCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineComms_ComponentNumber ON DataSubmarineComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineComms_ID ON DataSubmarineComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineDockingFacilities_ComponentNumber ON DataSubmarineDockingFacilities (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineDockingFacilities_ID ON DataSubmarineDockingFacilities (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineFuel_ComponentNumber ON DataSubmarineFuel (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineFuel_ID ON DataSubmarineFuel (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineMagazines_ComponentNumber ON DataSubmarineMagazines (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineMagazines_ID ON DataSubmarineMagazines (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineMounts_ComponentNumber ON DataSubmarineMounts (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineMounts_ID ON DataSubmarineMounts (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarinePropulsion_ComponentNumber ON DataSubmarinePropulsion (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarinePropulsion_ID ON DataSubmarinePropulsion (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineSensors_ComponentNumber ON DataSubmarineSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineSensors_ID ON DataSubmarineSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineSignatures_ID ON DataSubmarineSignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataSubmarineSignatures_Type ON DataSubmarineSignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponCodes_CodeID ON DataWeaponCodes (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponCodes_ID ON DataWeaponCodes (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponComms_ComponentNumber ON DataWeaponComms (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponComms_ID ON DataWeaponComms (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponDirectors_ComponentNumber ON DataWeaponDirectors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponDirectors_ID ON DataWeaponDirectors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponFuel_ComponentNumber ON DataWeaponFuel (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponFuel_ID ON DataWeaponFuel (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponPropulsion_ComponentNumber ON DataWeaponPropulsion (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponPropulsion_ID ON DataWeaponPropulsion (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponRecord_ComponentID ON DataWeaponRecord (ComponentID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponSensors_ComponentNumber ON DataWeaponSensors (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponSensors_ID ON DataWeaponSensors (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponSignatures_ID ON DataWeaponSignatures (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponSignatures_Type ON DataWeaponSignatures (Type)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponTargets_CodeID ON DataWeaponTargets (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponTargets_ID ON DataWeaponTargets (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWRA_CodeID ON DataWeaponWRA (CodeID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWRA_ID ON DataWeaponWRA (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWarheads_ComponentNumber ON DataWeaponWarheads (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWarheads_ID ON DataWeaponWarheads (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWeapons_ComponentNumber ON DataWeaponWeapons (ComponentNumber)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_DataWeaponWeapons_ID ON DataWeaponWeapons (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftCategory_ID ON EnumAircraftCategory (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftCode_ID ON EnumAircraftCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftFacilityPhysicalSize_ID ON EnumAircraftPhysicalSize  (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftFacilityRunwayLength_ID ON EnumRunwayLength (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftFacilityType_ID ON EnumAircraftFacilityType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftPhysicalSize_ID ON EnumAircraftPhysicalSize (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftRunwayLength_ID ON EnumRunwayLength (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumAircraftType_ID ON EnumAircraftType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumArcs_ID ON EnumArcs (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumArmorType_ID ON EnumArmorType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumCommCapability_ID ON EnumCommCapability (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumCommType_ID ON EnumCommType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumDockingFacilityPhysicalSize_ID ON EnumDockingFacilityPhysicalSize (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumDockingFacilityType_ID ON EnumDockingFacilityType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumFacilityCategory_ID ON EnumFacilityCategory (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumFuelType_ID ON EnumFuelType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumLoadoutMissionProfile_ID ON EnumLoadoutMissionProfile (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumLoadoutRole_ID ON EnumLoadoutRole (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumLoadoutTimeOfDay_ID ON EnumLoadoutTimeOfDay (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumLoadoutWeather_ID ON EnumLoadoutWeather (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumOperatorCountry_ID ON EnumOperatorCountry (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumOperatorService_ID ON EnumOperatorService (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumPropulsionType_ID ON EnumPropulsionType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSatelliteCategory_ID ON EnumSatelliteCategory (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSatelliteCode_ID ON EnumSatelliteCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSatelliteOrbitPlane_ID ON EnumSatelliteOrbitPlane (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSatelliteType_ID ON EnumSatelliteType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorCapability_ID ON EnumSensorCapability (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorCode_ID ON EnumSensorCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorFrequency_ID ON EnumSensorFrequency (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorGeneration_ID ON EnumSensorGeneration (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorRole_ID ON EnumSensorRole (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSensorType_ID ON EnumSensorType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumShipCategory_ID ON EnumShipCategory (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumShipCode_ID ON EnumShipCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumShipPhysicalSize_ID ON EnumShipPhysicalSize (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumShipType_ID ON EnumShipType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSignatureType_ID ON EnumSignatureType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSubmarineCategory_ID ON EnumSubmarineCategory (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSubmarineCode_ID ON EnumSubmarineCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSubmarinePhysicalSize_ID ON EnumSubmarinePhysicalSize (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumSubmarineType_ID ON EnumSubmarineType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWarheadCaliber_ID ON EnumWarheadCaliber (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWarheadExplosivesType_ID ON EnumWarheadExplosivesType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWarheadType_ID ON EnumWarheadType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponCode_ID ON EnumWeaponCode (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponGeneration_ID ON EnumWeaponGeneration (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponImpactType_ID ON EnumWeaponImpactType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponProfileAttack_ID ON EnumWeaponProfileAttack (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponProfileCruise_ID ON EnumWeaponProfileCruise (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponTarget_ID ON EnumWeaponTarget (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponType_ID ON EnumWeaponType (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponWRA_ID ON EnumWeaponWRA (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponWRASelfDefenceRange_ID ON EnumWeaponWRASelfDefenceRange (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponWRAShooterQty_ID ON EnumWeaponWRAShooterQty (ID)");
		sQLiteHelper.ExecuteNonQuery("CREATE INDEX IDX_EnumWeaponWRAWeaponQty_ID ON EnumWeaponWRAWeaponQty (ID)");
	}

	static Conversion()
	{
		Class72.smethod_20();
	}
}
