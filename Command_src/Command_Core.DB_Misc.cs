using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Collections.Pooled;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DB_Misc
{
	private static HashSet<int> hashSet_0;

	private static HashSet<int> hashSet_1;

	private static HashSet<int> hashSet_2;

	private static HashSet<int> hashSet_3;

	private static HashSet<int> hashSet_4;

	private static HashSet<int> hashSet_5;

	private static HashSet<int> hashSet_6;

	private static HashSet<int> hashSet_7;

	private static HashSet<int> hashSet_8;

	private static HashSet<int> hashSet_9;

	private static HashSet<int> hashSet_10;

	private static HashSet<int> hashSet_11;

	private static HashSet<int> hashSet_12;

	private static HashSet<int> hashSet_13;

	private static HashSet<int> hashSet_14;

	private static HashSet<int> hashSet_15;

	private static HashSet<int> hashSet_16;

	static DB_Misc()
	{
		Class72.smethod_20();
		hashSet_0 = new HashSet<int>();
		hashSet_1 = new HashSet<int>();
		hashSet_2 = new HashSet<int>();
		hashSet_3 = new HashSet<int>();
		hashSet_4 = new HashSet<int>();
		hashSet_5 = new HashSet<int>();
		hashSet_6 = new HashSet<int>();
		hashSet_7 = new HashSet<int>();
		hashSet_8 = new HashSet<int>();
		hashSet_9 = new HashSet<int>();
		hashSet_10 = new HashSet<int>();
		hashSet_11 = new HashSet<int>();
		hashSet_12 = new HashSet<int>();
		hashSet_13 = new HashSet<int>();
		hashSet_14 = new HashSet<int>();
		hashSet_15 = new HashSet<int>();
		hashSet_16 = new HashSet<int>();
	}

	public static void BindScenToCustomDB(Scenario theScen, ref string CustomDBFileName)
	{
		DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
		DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(theScen.DBUsed, ref theResult);
		if (dBRecordByHash == null)
		{
			throw new Exception(DBOps.EnglishMessageString(theResult));
		}
		string text = Guid.NewGuid().ToString() + Path.GetExtension(dBRecordByHash.FileName);
		File.Copy(Path.Combine(GameGeneral.DBFolderPath, dBRecordByHash.FileName), Path.Combine(GameGeneral.DBFolderPath, text));
		SQLiteConnection theConn = new SQLiteConnection("Data Source=" + Path.Combine(GameGeneral.DBFolderPath, text) + ";Version=3");
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theConn);
		smethod_0(theScen);
		StripTables(sQLiteHelper);
		sQLiteHelper.ExecuteNonQuery("VACUUM");
		string fileHashFromFilename = Crypto.GetFileHashFromFilename(Path.Combine(GameGeneral.DBFolderPath, text));
		DBRecord theRecord = new DBRecord(dBRecordByHash.DBID, fileHashFromFilename, text, text);
		DBOps.AddUnregisteredDB(fileHashFromFilename, theRecord);
		theScen.DBUsed = fileHashFromFilename;
		CustomDBFileName = Path.Combine(GameGeneral.DBFolderPath, text);
	}

	private static void smethod_0(Scenario scenario_0)
	{
		hashSet_0.Clear();
		hashSet_1.Clear();
		hashSet_2.Clear();
		hashSet_3.Clear();
		hashSet_4.Clear();
		hashSet_5.Clear();
		hashSet_6.Clear();
		hashSet_7.Clear();
		hashSet_8.Clear();
		hashSet_9.Clear();
		hashSet_10.Clear();
		hashSet_11.Clear();
		hashSet_12.Clear();
		hashSet_13.Clear();
		hashSet_14.Clear();
		hashSet_15.Clear();
		hashSet_16.Clear();
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_ != null)
			{
				smethod_1(activeUnits_, scenario_0);
			}
		}
		foreach (UnguidedWeapon value in scenario_0.UnguidedWeapons.Values)
		{
			hashSet_6.Add(value.ReferenceWeapon.DBID);
		}
	}

	private static void smethod_1(object object_0, Scenario scenario_0)
	{
		switch (((ActiveUnit)object_0).UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			hashSet_0.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			hashSet_2.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			hashSet_3.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			hashSet_1.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			hashSet_6.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			hashSet_4.Add(((ActiveUnit)object_0).DBID);
			break;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)object_0).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (!sensor.IsMk1Eyeball)
			{
				hashSet_5.Add(sensor.DBID);
			}
		}
		foreach (Mount mount in ((ActiveUnit)object_0).Mounts)
		{
			hashSet_7.Add(mount.DBID);
			if (!Information.IsNothing((object)mount.MountMagazine))
			{
				hashSet_8.Add(mount.MountMagazine.DBID);
			}
			Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
			foreach (Sensor sensor2 in sensors_ReadOnly)
			{
				hashSet_5.Add(sensor2.DBID);
			}
			CommDevice[] commDevices = mount.CommDevices;
			foreach (CommDevice commDevice in commDevices)
			{
				hashSet_10.Add(commDevice.DBID);
			}
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				if (mountWeapon.WRecDBID.HasValue)
				{
					hashSet_16.Add(mountWeapon.WRecDBID.Value);
				}
				smethod_1(mountWeapon.get_ReferenceWeapon(scenario_0), scenario_0);
			}
		}
		if (!Information.IsNothing((object)((ActiveUnit)object_0).SharedMagazines))
		{
			Magazine[] sharedMagazines = ((ActiveUnit)object_0).SharedMagazines;
			foreach (Magazine magazine in sharedMagazines)
			{
				hashSet_8.Add(magazine.DBID);
			}
		}
		if (((ScenarioObject)object_0).IsAircraft)
		{
			List<Loadout> list = DBFunctions.LoadoutsForThisAircraft(((ActiveUnit)object_0).DBID, scenario_0);
			foreach (Loadout item in list)
			{
				hashSet_9.Add(item.DBID);
				WeaponRec[] weapons = item.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.WRecDBID.HasValue)
					{
						hashSet_16.Add(weaponRec.WRecDBID.Value);
					}
					smethod_1(weaponRec.get_ReferenceWeapon(scenario_0), scenario_0);
				}
				PooledList<Sensor> pooledList = item.Sensors(scenario_0);
				if (pooledList == null || pooledList.Count <= 0)
				{
					continue;
				}
				foreach (Sensor item2 in pooledList)
				{
					hashSet_5.Add(item2.DBID);
				}
				pooledList.Dispose();
			}
		}
		if (((Module_Unit.Unit)object_0).IsWeapon)
		{
			Warhead[] warheads = ((Weapon)object_0).Warheads;
			foreach (Warhead warhead in warheads)
			{
				hashSet_12.Add(warhead.DBID);
			}
		}
		foreach (WeaponRec value in ((ActiveUnit)object_0).Weaponry.AllDistinctWeaponsAboard_Potential_WeaponRecs(IncludeAviationMags: true).Values)
		{
			if (value.WRecDBID.HasValue)
			{
				hashSet_16.Add(value.WRecDBID.Value);
			}
			smethod_1(value.get_ReferenceWeapon(scenario_0), scenario_0);
		}
		CommDevice[] comms_ReadOnly = ((ActiveUnit)object_0).Comms_ReadOnly;
		foreach (CommDevice commDevice2 in comms_ReadOnly)
		{
			hashSet_10.Add(commDevice2.DBID);
		}
		foreach (Engine item3 in ((ActiveUnit)object_0).Propulsion)
		{
			hashSet_11.Add(item3.DBID);
		}
		AirFacility[] airFacilities_ReadOnly = ((ActiveUnit)object_0).AirFacilities_ReadOnly;
		foreach (AirFacility airFacility in airFacilities_ReadOnly)
		{
			hashSet_13.Add(airFacility.DBID);
		}
		DockFacility[] dockFacilities_ReadOnly = ((ActiveUnit)object_0).DockFacilities_ReadOnly;
		foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
		{
			hashSet_14.Add(dockFacility.DBID);
		}
		foreach (FuelRec item4 in ((ActiveUnit)object_0).Fuel_ReadOnly)
		{
			if (item4.DBID.HasValue)
			{
				hashSet_15.Add(item4.DBID.Value);
			}
		}
	}

	public static void StripTables(SQLiteHelper myHelper)
	{
		string string_ = "DELETE FROM DataAircraft WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftCodes WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftComms WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftFacility WHERE NOT ID IN (" + string.Join(",", hashSet_13) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftFuel WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftLoadouts WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftMounts WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftPropulsion WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftSensors WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftSignatures WHERE NOT ID IN (" + string.Join(",", hashSet_0) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataComm WHERE NOT ID IN (" + string.Join(",", hashSet_10) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataCommCapabilities WHERE NOT ID IN (" + string.Join(",", hashSet_10) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataCommDirectors WHERE NOT ID IN (" + string.Join(",", hashSet_10) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataDockingFacility WHERE NOT ID IN (" + string.Join(",", hashSet_14) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacility WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityAircraftFacilities WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityComms WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityDockingFacilities WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityFuel WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityMagazines WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityMounts WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilitySensors WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilitySignatures WHERE NOT ID IN (" + string.Join(",", hashSet_1) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFuel WHERE NOT ID IN (" + string.Join(",", hashSet_15) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataLoadout WHERE NOT ID IN (" + string.Join(",", hashSet_9) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataLoadoutWeapons WHERE NOT ID IN (" + string.Join(",", hashSet_9) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMagazine WHERE NOT ID IN (" + string.Join(",", hashSet_8) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMagazineWeapons WHERE NOT ID IN (" + string.Join(",", hashSet_8) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMount WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountComms WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountDirectors WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountMagazineWeapons WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountSensors WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountWeapons WHERE NOT ID IN (" + string.Join(",", hashSet_7) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataPropulsion WHERE NOT ID IN (" + string.Join(",", hashSet_11) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataPropulsionPerformance WHERE NOT ID IN (" + string.Join(",", hashSet_11) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatellite WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteCodes WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteComms WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteMounts WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteOrbits WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteSensors WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteSignatures WHERE NOT ID IN (" + string.Join(",", hashSet_4) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensor WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorCapabilities WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorCodes WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorFrequencyIlluminate WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorFrequencySearchAndTrack WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorSensorGroups WHERE NOT ID IN (" + string.Join(",", hashSet_5) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShip WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipAircraftFacilities WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipCodes WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipComms WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipDockingFacilities WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipFuel WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipMagazines WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipMounts WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipPropulsion WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipSensors WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipSignatures WHERE NOT ID IN (" + string.Join(",", hashSet_2) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarine WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineCodes WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineComms WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineDockingFacilities WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineFuel WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineMagazines WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineMounts WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarinePropulsion WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineSensors WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineSignatures WHERE NOT ID IN (" + string.Join(",", hashSet_3) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWarhead WHERE NOT ID IN (" + string.Join(",", hashSet_12) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeapon WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponCodes WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponComms WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponDirectors WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponFuel WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponPropulsion WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponRecord WHERE NOT ID IN (" + string.Join(",", hashSet_16) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponSensors WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponSignatures WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponTargets WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWarheads WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWeapons WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWRA WHERE NOT ID IN (" + string.Join(",", hashSet_6) + ")";
		myHelper.ExecuteNonQuery(string_);
	}
}
