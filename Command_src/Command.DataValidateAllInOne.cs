using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateAllInOne
{
	public static bool Options_ValidateAircraft;

	public static bool Options_ValidateShips;

	public static bool Options_ValidateSubs;

	public static bool Options_ValidateFacilities;

	public static bool Options_ValidateSatellites;

	public static bool Options_ValidateWeapons;

	public static bool Options_ValidateMounts;

	public static bool Options_ValidateSensors;

	public static bool Options_ValidateMags;

	public static bool Options_ValidateLoadouts;

	public static bool Options_ValidateAirFacs;

	public static bool Options_ValidateDockFacs;

	public static bool Options_ValidateWarheads;

	public static bool Options_ValidateComms;

	public static bool Options_ValidatePropulsion;

	public static bool Options_ValidateWeaponRecs;

	public static bool Options_ValidateFuelRecs;

	public static bool Options_ValidateCargo;

	public static bool Options_ValidateCopyOver;

	public static bool Options_ValidateOperationalYearAndService;

	public static bool Options_ValidateMissingComponents;

	public static bool Options_ValidateDeprecationChecks;

	public static bool DeprecationImplemented;

	public static void RunValidationAllInOne()
	{
		try
		{
			Common.mySourceDB_Helper.OpenConnection();
			if (!Common.DoesTableColumnExist(ref Common.theSourceDB, "DataWeapon", "Deprecated"))
			{
				goto IL_0121;
			}
			int deprecationImplemented;
			if (!Common.DoesTableColumnExist(ref Common.theSourceDB, "DataComm", "Deprecated"))
			{
				deprecationImplemented = 0;
			}
			else if (!Common.DoesTableColumnExist(ref Common.theSourceDB, "DataFacility", "Deprecated"))
			{
				deprecationImplemented = 0;
			}
			else
			{
				if (!Common.DoesTableColumnExist(ref Common.theSourceDB, "DataLoadout", "Deprecated") || !Common.DoesTableColumnExist(ref Common.theSourceDB, "DataMagazine", "Deprecated"))
				{
					goto IL_0121;
				}
				deprecationImplemented = ((Common.DoesTableColumnExist(ref Common.theSourceDB, "DataMount", "Deprecated") && Common.DoesTableColumnExist(ref Common.theSourceDB, "DataSensor", "Deprecated") && Common.DoesTableColumnExist(ref Common.theSourceDB, "DataShip", "Deprecated") && Common.DoesTableColumnExist(ref Common.theSourceDB, "DataSubmarine", "Deprecated") && Common.DoesTableColumnExist(ref Common.theSourceDB, "DataWarhead", "Deprecated") && Common.DoesTableColumnExist(ref Common.theSourceDB, "DataWeapon", "Deprecated")) ? 1 : 0);
			}
			goto IL_0122;
			IL_0122:
			DeprecationImplemented = (byte)deprecationImplemented != 0;
			Common.StatusString = "Validating data...";
			Common.DeleteTableContent(Common.mySourceDB_Helper, "Validation");
			Common.StatusString = "Pre-caching data...";
			Common.PreCacheDataTables(Common.mySourceDB_Helper);
			if (Options_ValidateCopyOver)
			{
				Common.StatusString = "Validating Copy-Over IDs...";
				DataValidateCopyOver.ValidateCopyOverID();
			}
			if (Options_ValidateAircraft)
			{
				DataValidateAircraft.ValidateAircraftStatsAndFlags();
				DataValidateAircraft.ValidateAircraftNames();
				DataValidateAircraft.ValidateAircraftHaveIlluminatorsForWeapons();
				DataValidateAircraft.ValidateAircraftHaveDirectorsForMounts();
				DataValidateAircraft.ValidateAircraftDirectorsAndIlluminatorsHaveCorrespondingWeapons();
				DataValidateAircraft.ValidateAircraftHaveOnlyOnePropulsionAndFuelRecord();
				DataValidateAircraft.ValidateAircraftHaveCorrectFlags();
				DataValidateAircraft.ValidateLoadoutCapabilities();
				DataValidateAircraft.ValidateAircraftHaveDatalinksForWeapons();
				DataValidateAircraft.ValidateAircraftPropulsion();
				DataValidateAircraft.ValidateAircraftPropulsion2();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftComms", "DataComm", "Comm device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftPropulsion", "DataPropulsion", "Propulsion device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftFuel", "DataFuel", "Fuel record");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftLoadouts", "DataLoadout", "Loadout");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftMounts", "DataMount", "Mount");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Aircraft", "DataAircraftSensors", "DataSensor", "Sensor");
					Common.ValidateMissingComponent(Common.mySourceDB_Helper, "Aircraft", "DataAircraft", "DataAircraftComms", "comm device");
					Common.ValidateMissingComponent(Common.mySourceDB_Helper, "Aircraft", "DataAircraft", "DataAircraftPropulsion", "propulsion device");
					Common.ValidateMissingComponent(Common.mySourceDB_Helper, "Aircraft", "DataAircraft", "DataAircraftLoadouts", "loadout");
				}
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateAircraftPropulsion);
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateHelicopterPropulsion);
				if (Options_ValidateOperationalYearAndService)
				{
					DataValidateAircraft.ValidateAircraftHaveCorrectOperatorServiceAndYear();
				}
				DataValidateAircraft.ValidateAircraftHaveDatalinkDirectors();
			}
			if (Options_ValidateAirFacs)
			{
				Common.StatusString = "Validating Aircraft Facilities...";
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateAircraftFacilityDuplicates);
			}
			if (Options_ValidateCargo)
			{
				Common.StatusString = "Validating Cargo...";
				DataValidateCargo.ValidateCargoMandatoryValues();
			}
			if (Options_ValidateComms)
			{
				Common.StatusString = "Validating Comms...";
				DataValidateComm.ValidateCommNames();
				DataValidateComm.ValidateCommWeaponLinkDirectors();
			}
			if (Options_ValidateDockFacs)
			{
				Common.StatusString = "Validating Docking Facilities...";
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateDockingFacilityDuplicates);
			}
			if (Options_ValidateFacilities)
			{
				Common.StatusString = "Validating Facilities...";
				DataValidateFacility.ValidateFacilityStatsAndFlags();
				DataValidateFacility.ValidateFacilityNames();
				DataValidateFacility.ValidateFacilitiesHaveIlluminatorsForWeapons();
				DataValidateFacility.ValidateFacilitiesHaveDirectorsForMounts();
				DataValidateFacility.ValidateFacilityDirectorsAndIlluminatorsHaveCorrespondingWeapons();
				DataValidateFacility.ValidateFacilityMagazineWeaponsExistsOnMounts();
				DataValidateFacility.ValidateFacilitiesHaveDatalinksForWeapons();
				DataValidateFacility.ValidateFacilityMountsAreAimpoints();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilityAircraftFacilities", "DataAircraftFacility", "Air facility");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilityComms", "DataComm", "Comm device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilityFuel", "DataFuel", "Fuel record");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilityMagazines", "DataMagazine", "Magazine");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilityMounts", "DataMount", "Mount");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Facility", "DataFacilitySensors", "DataSensor", "Sensor");
				}
				if (Options_ValidateOperationalYearAndService)
				{
					DataValidateFacility.ValidateFacilityHaveCorrectOperatorServiceAndYear();
				}
				DataValidateFacility.ValidateFacilityAircraftFacilities();
				DataValidateFacility.ValidateFacilityHaveDatalinkDirectors();
			}
			if (Options_ValidateFuelRecs)
			{
				Common.StatusString = "Validating Fuel...";
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateFuelDuplicates);
			}
			if (Options_ValidateLoadouts)
			{
				Common.StatusString = "Validating Loadouts...";
				DataValidateLoadout.ValidateLoadoutNames();
				DataValidateLoadout.ValidateLoadoutStats();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Loadout", "DataLoadoutWeapons", "DataWeaponRecord", "Weapon");
				}
				DataValidateLoadout.ValidateLoadoutRoleVsProfile();
			}
			if (Options_ValidateMags)
			{
				Common.StatusString = "Validating Magazines...";
				DataValidateMagazine.ValidateMagazineNames();
				DataValidateMagazine.CheckMagazinesAreNotOverFilled();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Magazine", "DataMagazineWeapons", "DataWeaponRecord", "Weapon");
				}
			}
			if (Options_ValidateMounts)
			{
				Common.StatusString = "Validating Mounts...";
				DataValidateMount.ValidateMountStats();
				DataValidateMount.ValidateMountNames();
				DataValidateMount.CheckMountsAreNotOverFilled();
				DataValidateMount.CheckMountUnguidedRocketLaunchers();
				DataValidateMount.CheckMountMagazinesAreNotOverFilled();
				DataValidateMount.ValidateMountsHaveCorrectCommGear();
				DataValidateMount.ValidateMountMagazinesHaveCorrectAmmo();
				DataValidateMount.CheckNonLocalControlMountsHaveMountDirectorsOrWeaponDirectorsOrDatalinks();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Mount", "DataMountWeapons", "DataWeaponRecord", "Weapon");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Mount", "DataMountSensors", "DataSensor", "Sensor");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Mount", "DataMountComms", "DataComm", "Comm");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Mount", "DataMountMagazineWeapons", "DataWeaponRecord", "Magazine weapon");
				}
				DataValidateMount.ValidateMountDefaultArcs();
				DataValidateMount.ValidateWeaponsLegalTargetsVsMountDirectorCapabilities();
				DataValidateMount.ValidateAllSensorsOnMountsAreCapableVsSameTargets();
			}
			if (Options_ValidatePropulsion)
			{
				Common.StatusString = "Validating Propulsion Systems...";
				DataValidatePropulsion.ValidatePropulsionNames();
				DataValidatePropulsion.ValidatePropulsionUsersFuelQty();
				DataValidatePropulsion.ValidatePropulsionStats();
			}
			if (Options_ValidateSatellites)
			{
				Common.StatusString = "Validating Satellites...";
				DataValidateSatellite.ValidateSatelliteStatsAndFlags();
				DataValidateSatellite.ValidateSatelliteNames();
				DataValidateSatellite.ValidateGeostationnarySatelliteHaveCorrectSensor();
				if (Options_ValidateOperationalYearAndService)
				{
					DataValidateSatellite.ValidateSatelliteHaveCorrectOperatorServiceAndYear();
				}
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Satellite", "DataSatelliteMounts", "DataMount", "Mount");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Satellite", "DataSatelliteSensors", "DataSensor", "Sensor");
				}
				DataValidateAircraft.ValidateDP("Satellite", "DataSatellite");
				DataValidateSatellite.ValidateSatelliteOrbitsAndDates();
			}
			if (Options_ValidateSensors)
			{
				Common.StatusString = "Validating Sensors...";
				DataValidateSensor.ValidateSensorNames();
				DataValidateSensor.ValidateSensorStats();
				DataValidateSensor.ValidateSensorNumberOfArrays();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Sensor", "DataSensorSensorGroups", "DataSensor", "Sensor Group Sensor");
				}
				DataValidateSensor.ValidateSensorDefaultArcs();
				DataValidateSensor.ValidateAllSensorsInGroupAreCapableVsSameTargets();
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateSensorStdArcs);
			}
			if (Options_ValidateShips)
			{
				Common.StatusString = "Validating Ships...";
				DataValidateShip.ValidateShipStatsAndFlags();
				DataValidateShip.ValidateShipNames();
				DataValidateShip.ValidateShipsHaveIlluminatorsForWeapons();
				DataValidateShip.ValidateShipsHaveDirectorsForMounts();
				DataValidateShip.ValidateShipsDirectorsAndIlluminatorsHaveCorrespondingWeapons();
				DataValidateShip.ValidateShipMagazineWeaponsExistsOnMounts();
				DataValidateShip.ValidateShipsHaveOnlyOnePropulsionAndFuelRecord();
				DataValidateShip.ValidateShipsPropulsion();
				DataValidateShip.ValidateShipsHaveDatalinksForWeapons();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipAircraftFacilities", "DataAircraftFacility", "Aircraft facility");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipPropulsion", "DataPropulsion", "Propulsion device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipFuel", "DataFuel", "Fuel record");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipMagazines", "DataMagazine", "Magazine");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipMounts", "DataMount", "Mount");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipSensors", "DataSensor", "Sensor");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Ship", "DataShipDockingFacilities", "DataDockingFacility", "Docking facility");
					Common.ValidateMissingComponent(Common.mySourceDB_Helper, "Ship", "DataShip", "DataShipPropulsion", "propulsion device");
				}
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateShipPropulsion);
				DataValidateAircraft.ValidateDP("Ship", "DataShip");
				if (Options_ValidateOperationalYearAndService)
				{
					DataValidateShip.ValidateShipHaveCorrectOperatorServiceAndYear();
				}
				DataValidateShip.ValidateShipSonarSignatureModifierMatchesPropulsionTypeAndTonnage();
				DataValidateShip.ValidateShipAircraftFacilities();
				DataValidateShip.ValidateShipHaveDatalinkDirectors();
			}
			if (Options_ValidateSubs)
			{
				Common.StatusString = "Validating Submarines...";
				DataValidateSub.ValidateSubmarineStatsAndFlags();
				DataValidateSub.ValidateSubNames();
				DataValidateSub.ValidateSubMagazineWeaponsExistsOnMounts();
				DataValidateSub.ValidateSubPropulsion();
				DataValidateSub.ValidateSubsHaveDatalinksForWeapons();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineComms", "DataComm", "Comm device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarinePropulsion", "DataPropulsion", "Propulsion device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineFuel", "DataFuel", "Fuel record");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineMagazines", "DataMagazine", "Magazine");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineMounts", "DataMount", "Mount");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineSensors", "DataSensor", "Sensor");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Submarine", "DataSubmarineDockingFacilities", "DataDockingFacility", "Docking facility");
					Common.ValidateMissingComponent(Common.mySourceDB_Helper, "Submarine", "DataSubmarine", "DataSubmarinePropulsion", "propulsion device");
				}
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateSubmarinePropulsion);
				DataValidateAircraft.ValidateDP("Submarine", "DataSubmarine");
				if (Options_ValidateOperationalYearAndService)
				{
					DataValidateSub.ValidateSubmarineHaveCorrectOperatorServiceAndYear();
				}
				DataValidateSub.ValidateSubmarineSonarSignatureModifierMatchesPropulsionTypeAndTonnage();
				DataValidateSub.ValidateSubmarineHaveDatalinkDirectors();
				DataValidateSub.ValidateSubmarineAircraftFacilities();
			}
			if (Options_ValidateWarheads)
			{
				Common.StatusString = "Validating Warheads...";
				DataValidateWarhead.ValidateWarheadNames();
				DataValidateWarhead.ValidateWarheadTypeAndExplosives();
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateWarheadWeaponLink);
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateWarheadDP);
			}
			if (Options_ValidateWeapons)
			{
				Common.StatusString = "Validating Weapons...";
				DataValidateWeapon.ValidateWeaponPokVsRangeVsTargettype();
				DataValidateWeapon.ValidateTargetTypesForWeapons();
				DataValidateWeapon.ValidateWeaponNames();
				DataValidateWeapon.ValidateAntiAirMissilesRequiredHaveFlags();
				DataValidateWeapon.ValidateWeaponsHaveOnlyOnePropulsionAndFuelRecord();
				DataValidateWeapon.ValidateWeaponPropulsion();
				DataValidateWeapon.ValidateWeaponsCorrectFuelLoad();
				DataValidateWeapon.ValidateWeaponsHaveCorrectCommGear();
				DataValidateWeapon.ValidateWeaponStats();
				DataValidateWeapon.ValidateGunCaliberVsAltitudeStats();
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponComms", "DataComm", "Comm device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponDirectors", "DataSensor", "Director");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponPropulsion", "DataPropulsion", "Propulsion device");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponFuel", "DataFuel", "Fuel record");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponSensors", "DataSensor", "Sensor");
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon", "DataWeaponWarheads", "DataWarhead", "Warhead");
				}
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateWeaponPropulsion);
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateWeaponHasNoDirector);
				DataValidateWeapon.ValidateWeaponsLegalTargetsVsSensorAndIlluminatorCapabilities();
				DataValidateWeapon.ValidateWeaponsLegalTargetsVsWarheadCapabilities();
				DataValidateWeapon.ValidateAllSensorsonWeaponsAreCapableVsSameTargets();
				DataValidateWeapon.ValidateSpecialTorpedoStats();
				DataValidateWeapon.smethod_0();
			}
			if (Options_ValidateWeaponRecs)
			{
				Common.StatusString = "Validating Weapon Records...";
				if (Options_ValidateMissingComponents)
				{
					Common.ValidateMissingComponentInSubTable(Common.mySourceDB_Helper, "Weapon Rec", "DataWeaponRecord", "DataWeapon", "Weapon");
				}
				Common.mySourceDB_Helper.ExecuteNonQuery(Common.QueryValidateWeaponRecordDuplicates);
			}
			Common.mySourceDB_Helper.CloseConnection();
			return;
			IL_0121:
			deprecationImplemented = 0;
			goto IL_0122;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200140", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateAllInOne()
	{
		Class72.smethod_20();
	}
}
